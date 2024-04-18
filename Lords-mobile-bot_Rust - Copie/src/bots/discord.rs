use std::collections::{HashMap, VecDeque};
use std::iter::FromIterator;
use std::sync::atomic::{AtomicBool, Ordering};
use std::sync::Arc;
use std::time::Duration;

use async_trait::async_trait;
use serde_json::Value;
use serenity::client::{Context, EventHandler};
use serenity::http::Http;
use serenity::model::channel::{Message, ReactionType};
use serenity::model::gateway::Ready;
use serenity::model::id::{ChannelId, UserId, WebhookId};
use serenity::model::interactions::{
    ButtonStyle, ComponentType, Interaction, InteractionData, InteractionResponseType,
};
use serenity::Client;
use strfmt::Format;
use tokio::sync::Mutex;

use crate::bot::{Bot, HandleStatus};
use crate::connection::Connection;
use crate::packet_type::{
    AllianceAttr, AllianceGift, Applicant, ChatMessage, HelpRequest, PacketType,
};

pub type MutexChannel<T> = Arc<Mutex<VecDeque<T>>>;

pub struct DiscordBot {
    beat_time: f64,
    server_time: i64,
    messages: MutexChannel<DiscordMessage>,
    chat_timeout: f64,
    chat_queue: VecDeque<String>,
    discord: Http,
    rallies_to_notify: Option<String>,
    rally_cache: Option<RallyCache>,
    applicants: HashMap<Applicant, Message>,
    mobilization_score: u32,
    reports: MutexChannel<(ChannelId, (String, i64))>,
    gifts: Vec<AllianceGift>,
    config: DiscordConfig,
    opened_chat: bool,
    name: String,
    applications: MutexChannel<(String, i64, bool, Interaction)>,
    application_wait: HashMap<i64, (String, Interaction)>,
    stop: Arc<AtomicBool>,
}

#[async_trait]
impl Bot for DiscordBot {
    type Config = DiscordConfig;

    async fn handle_packet(
        &mut self,
        connection: &mut Connection,
        packet: PacketType,
    ) -> anyhow::Result<HandleStatus> {
        println!("DISCORD Got {:?}", packet);
        if self.stop.load(Ordering::Relaxed) {
            println!("Stopping !остановить");
            return Ok(HandleStatus::Disconnect);
        }
        match packet {
            PacketType::ClientLoginAgain => return Ok(HandleStatus::Reconnect),
            PacketType::ClientSomebodyNeedsHelp { help } => {
                self.on_hands(vec![help], connection).await;
            }
            PacketType::ClientNeedHelp { helps, .. } => {
                self.on_hands(helps, connection).await;
            }
            PacketType::ClientServerTime { server_time } => {
                self.make_beat(15.0);
                self.server_time = server_time;
            }
            PacketType::ClientSocialData { .. } => {
                connection.send_packet(
                    PacketType::ServerInitOver {
                        igg_id: connection.igg_id,
                    },
                    true,
                )?;
                connection.send_packet(
                    PacketType::ServerLoadEquip {
                        last_update_time: -1,
                    },
                    true,
                )?;
                connection.send_packet(
                    PacketType::ServerItemMat {
                        last_update_time: -1,
                    },
                    true,
                )?;
                connection.send_packet(
                    PacketType::ServerItemGem {
                        last_update_time: -1,
                    },
                    true,
                )?;
                connection.send_packet(
                    PacketType::ServerViewChat {
                        channel: 1,
                        prev: 1,
                        kind: 3,
                        data_id: Some(0),
                        data_time: Some(self.server_time + 5),
                    },
                    true,
                )?;
                connection.send_packet(PacketType::ServerGetGifts, true)?;
            }
            PacketType::ClientChatMessage { messages, .. } => {
                for message in messages {
                    self.on_message(message, connection).await?;
                }
            }
            PacketType::ClientBroadcastDarkNest { player_name, .. } => {
                self.rallies_to_notify = Some(player_name);
                self.send_rallies_request(connection)?;
            }
            PacketType::ClientRally {
                index,
                require_time,
                ally_name,
                ally_curr_troop,
                ally_max_troop,
                enemy_vip,
                ..
            } => {
                if self.rallies_to_notify == Some(ally_name.clone()) {
                    self.rallies_to_notify = None;
                    if require_time != 60 * 60 * 8 && enemy_vip >= 3 {
                        self.rally_cache = Some(RallyCache {
                            troops: ally_curr_troop,
                            max_troops: ally_max_troop,
                            player_name: ally_name,
                            level: enemy_vip,
                            time: require_time,
                        });
                        connection
                            .send_packet(PacketType::ServerGetRallyDetails { index }, true)?;
                    }
                }
            }
            PacketType::ClientRallyTroops {
                ally_name, troops, ..
            } => {
                if let Some(rally) = self.rally_cache.clone() {
                    if rally.player_name == ally_name {
                        self.rally_cache = None;
                        let infantry = troops.iter().position(|t| t[0] != 0).map(|i| i + 1);
                        let ranged = troops.iter().position(|t| t[1] != 0).map(|i| i + 1);
                        let cavalry = troops.iter().position(|t| t[2] != 0).map(|i| i + 1);
                        let siege = troops.iter().position(|t| t[3] != 0).map(|i| i + 1);
                        self.config
                            .rally_channel_id
                            .say(
                                &self.discord,
                                self.config
                                    .rally_message_format
                                    .format(&HashMap::from_iter([
                                        ("player_name".to_string(), rally.player_name),
                                        ("level".to_string(), rally.level.to_string()),
                                        ("troops".to_string(), rally.troops.to_string()),
                                        ("max_troops".to_string(), rally.max_troops.to_string()),
                                        ("time".to_string(), (rally.time / 60).to_string()),
                                        (
                                            "army".to_string(),
                                            format!(
                                                "{}{}{}{}",
                                                if let Some(t) = infantry {
                                                    format!("пехи т{}+, ", t)
                                                } else {
                                                    "".to_string()
                                                },
                                                if let Some(t) = ranged {
                                                    format!("луки т{}+, ", t)
                                                } else {
                                                    "".to_string()
                                                },
                                                if let Some(t) = cavalry {
                                                    format!("кава т{}+", t)
                                                } else {
                                                    "".to_string()
                                                },
                                                if let Some(t) = siege {
                                                    format!(", осадки т{}+", t)
                                                } else {
                                                    "".to_string()
                                                }
                                            ),
                                        ),
                                    ]))?,
                            )
                            .await?;
                    }
                }
            }
            PacketType::ClientAllianceData(attr) => match attr {
                AllianceAttr::Applicant(num) => {
                    if num > 0 {
                        connection.send_packet(PacketType::ServerApplyList, true)?;
                    } else {
                        for (applicant, mut message) in self.applicants.drain() {
                            let content = format!(
                                "{} (не актуально)",
                                self.config
                                    .applications_message_format
                                    .format(&HashMap::from_iter([
                                        ("name".to_string(), applicant.name.clone()),
                                        ("user_id".to_string(), applicant.user_id.to_string(),),
                                        ("power".to_string(), applicant.power.to_string()),
                                        ("kills".to_string(), applicant.kills.to_string()),
                                    ]))
                                    .unwrap()
                            );
                            message
                                .edit(&self.discord, |message| {
                                    message
                                        .content(content)
                                        .components(|c| c.set_action_rows(Vec::new()))
                                })
                                .await?;
                        }
                    }
                }
                AllianceAttr::MobilizationAMScore(score) => {
                    if score / 1000 != self.mobilization_score / 1000 {
                        self.config
                            .mobilization_channel_id
                            .say(
                                &self.discord,
                                self.config.mobilization_message_format.format(
                                    &HashMap::from_iter([(
                                        "score".to_string(),
                                        score / 1000 * 1000,
                                    )]),
                                )?,
                            )
                            .await?;
                    }
                    self.mobilization_score = score;
                }
                AllianceAttr::AllianceBox1 { gift, .. } => {
                    if gift.status == 0 {
                        connection.send_packet(PacketType::ServerOpenGift(gift.sn), true)?;
                    }
                    self.gifts.push(gift);
                }
                _ => (),
            },
            PacketType::ClientApplyList(.., applicants) => {
                for applicant in applicants.iter() {
                    if !self
                        .applicants
                        .keys()
                        .any(|a| a.user_id == applicant.user_id)
                    {
                        let message = self
                            .config
                            .applications_channel_id
                            .send_message(&self.discord, |message| {
                                message
                                    .content(
                                        self.config
                                            .applications_message_format
                                            .format(&HashMap::from_iter([
                                                ("name".to_string(), applicant.name.clone()),
                                                (
                                                    "user_id".to_string(),
                                                    applicant.user_id.to_string(),
                                                ),
                                                ("power".to_string(), applicant.power.to_string()),
                                                ("kills".to_string(), applicant.kills.to_string()),
                                            ]))
                                            .unwrap(),
                                    )
                                    .components(|components| {
                                        components.create_action_row(|row| {
                                            row.create_button(|button| {
                                                button
                                                    .custom_id(format!(
                                                        "false/{}/{}",
                                                        applicant.name, applicant.user_id
                                                    ))
                                                    .style(ButtonStyle::Danger)
                                                    .emoji(ReactionType::Unicode("✖️".to_string()))
                                            })
                                            .create_button(|button| {
                                                button
                                                    .custom_id(format!(
                                                        "true/{}/{}",
                                                        applicant.name, applicant.user_id
                                                    ))
                                                    .style(ButtonStyle::Success)
                                                    .emoji(ReactionType::Unicode("✔️".to_string()))
                                            })
                                        })
                                    })
                            })
                            .await?;
                        self.applicants.insert(applicant.clone(), message);
                    }
                }
                for (applicant, message) in self.applicants.iter_mut() {
                    if !applicants.iter().any(|a| a.user_id == applicant.user_id) {
                        let content = format!(
                            "{} (не актуально)",
                            self.config
                                .applications_message_format
                                .format(&HashMap::from_iter([
                                    ("name".to_string(), applicant.name.clone()),
                                    ("user_id".to_string(), applicant.user_id.to_string(),),
                                    ("power".to_string(), applicant.power.to_string()),
                                    ("kills".to_string(), applicant.kills.to_string()),
                                ]))
                                .unwrap()
                        );
                        message
                            .edit(&self.discord, |message| {
                                message
                                    .content(content)
                                    .components(|c| c.set_action_rows(Vec::new()))
                            })
                            .await?;
                    }
                }
            }
            PacketType::ClientGiftInfo { clear, gifts, .. } => {
                if clear {
                    self.gifts.clear();
                }
                for gift in gifts {
                    if gift.status == 0 {
                        connection.send_packet(PacketType::ServerOpenGift(gift.sn), true)?;
                    }
                    self.gifts.push(gift);
                }
            }
            PacketType::ClientRoleInfo { name, .. } => {
                self.name = name;
            }
            PacketType::ClientDealApplication(resp, _, result, id) => {
                if let Some((name, interaction)) = self.application_wait.get(&id) {
                    interaction
                        .create_interaction_response(&self.discord, |response| {
                            response
                                .kind(InteractionResponseType::UpdateMessage)
                                .interaction_response_data(|data| {
                                    data.content(format!(
                                        "Заявка {}#{} {} <@{}> ({})",
                                        name,
                                        id,
                                        if result {
                                            "принята"
                                        } else {
                                            "отклонена"
                                        },
                                        interaction.member.as_ref().unwrap().user.id.0,
                                        if resp == 0 {
                                            "Успех".to_string()
                                        } else {
                                            format!("Ошибка {}", resp)
                                        }
                                    ))
                                    .components(|components| components)
                                })
                        })
                        .await?;
                }
            }
            _ => (),
        }
        Ok(HandleStatus::Ok)
    }
    #[allow(clippy::needless_collect)]
    async fn tick(&mut self, connection: &mut Connection, delta: Duration) -> anyhow::Result<()> {
        if !self.chat_queue.is_empty() {
            self.chat_timeout -= delta.as_secs_f64();
            if self.chat_timeout <= 0.0 && !self.chat_queue.is_empty() {
                let message = self.chat_queue.pop_front().unwrap();
                connection.send_packet(
                    PacketType::ServerSendChat {
                        channel: 1,
                        message,
                    },
                    true,
                )?;
                self.chat_timeout = 3.0;
            }
        }
        let mut a = self.messages.lock().await;
        let messages = a
            .iter()
            .map(|message| format!("{}: {}", message.author, message.message))
            .collect::<Vec<String>>();
        a.clear();
        drop(a);
        for message in messages.into_iter() {
            self.send_message(message, connection)?;
        }
        {
            let mut applications = self.applications.lock().await;
            while let Some((name, id, bool, interaction)) = applications.pop_front() {
                interaction
                    .create_interaction_response(&self.discord, |response| {
                        response
                            .kind(InteractionResponseType::UpdateMessage)
                            .interaction_response_data(|data| {
                                data.content(format!(
                                    "Заявка {}#{} {} <@{}>",
                                    name,
                                    id,
                                    if bool {
                                        "принята"
                                    } else {
                                        "отклонена"
                                    },
                                    interaction.member.as_ref().unwrap().user.id.0,
                                ))
                                .components(|components| components)
                            })
                    })
                    .await?;
                self.applicants.retain(|a, _| a.user_id != id);
                self.application_wait.insert(id, (name, interaction));
                connection.send_packet(PacketType::ServerDealApplication(bool, id), true)?;
            }
        }
        {
            let mut reports = self.reports.lock().await;
            while let Some((channel, (report, time))) = reports.pop_front() {
                println!("Осталось: {:?}", reports);
                let included = self
                    .gifts
                    .iter()
                    .cloned()
                    .filter(|gift| {
                        gift.rcv_time >= (self.server_time - time.min(31 * 24) * 60 * 60) as i64
                    })
                    .collect::<Vec<_>>();
                channel
                    .say(
                        &self.discord,
                        match report.as_str() {
                            "" | "топ" | "top" => {
                                format!(
                                    "{} подарков
```
- Анонимных: {}

- Игроки:
    {}
```",
                                    included.len(),
                                    included
                                        .iter()
                                        .filter(|gift| gift.player.is_none()
                                            || gift.player.as_ref().unwrap().is_empty())
                                        .count(),
                                    {
                                        let mut map: HashMap<String, Vec<AllianceGift>> =
                                            HashMap::new();
                                        included
                                            .iter()
                                            .filter(|gift| {
                                                gift.player.is_some()
                                                    && !gift.player.as_ref().unwrap().is_empty()
                                            })
                                            .for_each(|gift| {
                                                let name = gift.player.clone().unwrap();
                                                if let Some(gifts) = map.get_mut(&name) {
                                                    gifts.push(gift.clone());
                                                } else {
                                                    map.insert(name, vec![gift.clone()]);
                                                }
                                            });
                                        let mut pairs =
                                            map.iter()
                                                .collect::<Vec<(&String, &Vec<AllianceGift>)>>();
                                        pairs.sort_by_key(|(_, gifts)| gifts.len());
                                        pairs.reverse();
                                        pairs
                                            .iter()
                                            .fold("    ".to_string(), |acc, (name, gifts)| {
                                                acc + &format!(
                                                    "    {}: {}{}\n",
                                                    name,
                                                    gifts.len(),
                                                    {
                                                        let mut s = Vec::new();
                                                        let common = gifts
                                                            .iter()
                                                            .filter(|gift| gift.item_rank == 0)
                                                            .count();
                                                        let uncommon = gifts
                                                            .iter()
                                                            .filter(|gift| gift.item_rank == 1)
                                                            .count();
                                                        let rare = gifts
                                                            .iter()
                                                            .filter(|gift| gift.item_rank == 2)
                                                            .count();
                                                        let epic = gifts
                                                            .iter()
                                                            .filter(|gift| gift.item_rank == 3)
                                                            .count();
                                                        let legendary = gifts
                                                            .iter()
                                                            .filter(|gift| gift.item_rank == 4)
                                                            .count();
                                                        if common > 0 {
                                                            s.push(format!("{common} серых"))
                                                        }
                                                        if uncommon > 0 {
                                                            s.push(format!("{uncommon} зелёных"))
                                                        }
                                                        if rare > 0 {
                                                            s.push(format!("{rare} синих"))
                                                        }
                                                        if epic > 0 {
                                                            s.push(format!("{epic} фиолетовых"))
                                                        }
                                                        if legendary > 0 {
                                                            s.push(format!("{legendary} золотых"))
                                                        }
                                                        if s.is_empty() {
                                                            String::new()
                                                        } else {
                                                            format!(" ({})", s.join(", "))
                                                        }
                                                    }
                                                )
                                            })
                                            .trim()
                                    }
                                )
                            }
                            "редкость" | "rarity" => {
                                format!(
                                    "{} подарков
```
{}
```",
                                    included.len(),
                                    {
                                        let mut map: HashMap<String, Vec<AllianceGift>> =
                                            HashMap::new();
                                        included.iter().for_each(|gift| {
                                            let color = match gift.item_rank {
                                                0 => "Обычных",
                                                1 => "Необычных",
                                                2 => "Редких",
                                                3 => "Эпических",
                                                4 => "Легендарных",
                                                _ => "Других",
                                            }
                                            .to_string();
                                            if let Some(gifts) = map.get_mut(&color) {
                                                gifts.push(gift.clone());
                                            } else {
                                                map.insert(color, vec![gift.clone()]);
                                            }
                                        });
                                        let mut pairs =
                                            map.iter()
                                                .collect::<Vec<(&String, &Vec<AllianceGift>)>>();
                                        pairs.sort_by_key(|(_, gifts)| gifts.len());
                                        pairs.reverse();
                                        pairs
                                            .iter()
                                            .fold("".to_string(), |acc, (color, gifts)| {
                                                acc + &format!("{}: {}\n", color, gifts.len())
                                            })
                                            .trim()
                                    }
                                )
                            }
                            "время" | "time" => {
                                format!(
                                    "{} подарков:
```
{}
```",
                                    included.len(),
                                    {
                                        let mut map: HashMap<String, Vec<AllianceGift>> =
                                            HashMap::new();
                                        included.iter().for_each(|gift| {
                                            let hour =
                                                format!("{:02}:00", (gift.rcv_time / 60 / 60 + 3) % 24);
                                            if let Some(gifts) = map.get_mut(&hour) {
                                                gifts.push(gift.clone());
                                            } else {
                                                map.insert(hour, vec![gift.clone()]);
                                            }
                                        });
                                        let mut pairs =
                                            map.iter()
                                                .collect::<Vec<(&String, &Vec<AllianceGift>)>>();
                                        pairs.sort_by_key(|(_, gifts)| gifts.len());
                                        pairs.reverse();
                                        pairs
                                            .iter()
                                            .fold("".to_string(), |acc, (color, gifts)| {
                                                acc + &format!("{}: {}\n", color, gifts.len())
                                            })
                                            .trim()
                                    }
                                )
                            }
                            "help" => "!report [top/rarity/time] [time (hours)]".to_string(),
                            _ => "!репорт [топ/редкость/время] [время (в часах)]".to_string(),
                        },
                    )
                    .await?;
            }
        }
        if self.beat_time > 0.0 && self.beat_time - delta.as_secs_f64() <= 0.0 {
            self.heartbeat(connection)?;
        }
        self.beat_time -= delta.as_secs_f64();
        Ok(())
    }

    async fn start(connection: Connection, config: &Self::Config) -> anyhow::Result<HandleStatus> {
        let messages = Arc::new(Mutex::new(VecDeque::new()));
        let reports = Arc::new(Mutex::new(VecDeque::new()));
        let applications = Arc::new(Mutex::new(VecDeque::new()));
        let stop = Arc::new(AtomicBool::new(false));
        let bot = DiscordBot::new(
            messages.clone(),
            reports.clone(),
            config.clone(),
            applications.clone(),
            Arc::clone(&stop),
        );
        let discord_handler = DiscordBotDiscord {
            messages,
            reports,
            config: config.clone(),
            applications,
            stop,
        };
        let mut client = Client::builder(&config.token)
            .event_handler(discord_handler)
            .application_id(839528384014450688)
            .await
            .expect("Err creating client");
        let lp = connection.run_loop(bot);
        let ds = client.start();
        tokio::select! {
            _ = lp => {
                Ok(HandleStatus::Reconnect)
            }
            _ = ds => {
                Ok(HandleStatus::Reconnect)
            }
            else => {
                Ok(HandleStatus::Disconnect)
            }
        }
    }
}

impl DiscordBot {
    pub fn new(
        messages: MutexChannel<DiscordMessage>,
        reports: MutexChannel<(ChannelId, (String, i64))>,
        config: DiscordConfig,
        applications: MutexChannel<(String, i64, bool, Interaction)>,
        stop: Arc<AtomicBool>,
    ) -> Self {
        DiscordBot {
            beat_time: 0.0,
            server_time: -1,
            messages,
            chat_timeout: 0.0,
            chat_queue: VecDeque::new(),
            discord: Http::new_with_token(&config.token),
            rallies_to_notify: None,
            rally_cache: None,
            applicants: HashMap::new(),
            mobilization_score: 0,
            reports,
            gifts: Vec::new(),
            config,
            opened_chat: false,
            name: String::new(),
            applications,
            application_wait: Default::default(),
            stop,
        }
    }
    pub fn heartbeat(&mut self, connection: &mut Connection) -> anyhow::Result<()> {
        self.make_beat(15.0);
        connection.send_packet(PacketType::ServerHeartBeat, true)?;
        Ok(())
    }
    pub fn make_beat(&mut self, time: f64) {
        self.beat_time = time;
    }
    async fn on_hands(&mut self, hands: Vec<HelpRequest>, connection: &mut Connection) {
        for help in hands.chunks(30) {
            connection
                .send_packet(
                    PacketType::ServerSendHelp {
                        record_sns: help.iter().map(|help| help.record_sn).collect(),
                    },
                    true,
                )
                .unwrap();
        }
    }
    async fn on_message(
        &mut self,
        message: ChatMessage,
        connection: &mut Connection,
    ) -> anyhow::Result<()> {
        if message.player_name == self.name {
            return Ok(());
        }
        if let Some(content) = message.original_text.as_ref() {
            if !content.trim().is_empty() {
                if content == "!discord" {
                    self.send_message(self.config.auto_message_invite_link.clone(), connection)?;
                } else {
                    let mut webhook = self
                        .config
                        .chat_webhook_id
                        .to_webhook(&self.discord)
                        .await
                        .unwrap();
                    webhook.token = Some(self.config.chat_webhook_token.clone());
                    webhook
                        .execute(&self.discord, true, |h| {
                            h.0.insert("content", Value::String(content.clone()));
                            h.0.insert("username", Value::String(message.player_name.clone()));
                            h
                        })
                        .await
                        .unwrap();
                }
            }
        }
        Ok(())
    }
    pub fn send_message(
        &mut self,
        message: String,
        connection: &mut Connection,
    ) -> anyhow::Result<()> {
        if !self.opened_chat {
            connection.send_packet(
                PacketType::ServerViewChat {
                    channel: 1,
                    prev: 0,
                    kind: 4,
                    data_id: Some(0),
                    data_time: Some(self.server_time + 5),
                },
                true,
            )?;
            self.opened_chat = true;
        }
        self.chat_queue.push_back(message);
        Ok(())
    }
    pub fn send_rallies_request(&self, connection: &mut Connection) -> anyhow::Result<()> {
        connection.send_packet(PacketType::ServerGetRallies, true)?;
        Ok(())
    }
}

#[derive(Clone)]
pub struct RallyCache {
    troops: u32,
    max_troops: u32,
    player_name: String,
    level: u8,
    time: u32,
}

#[derive(Clone)]
pub struct DiscordConfig {
    pub auto_message_invite_link: String,
    pub chat_webhook_id: WebhookId,
    pub chat_webhook_token: String,
    pub rally_channel_id: ChannelId,
    pub rally_message_format: String,
    pub applications_channel_id: ChannelId,
    pub applications_message_format: String,
    pub mobilization_channel_id: ChannelId,
    pub mobilization_message_format: String,
    pub chat_channel_id: ChannelId,
    pub token: String,
}

pub struct DiscordBotDiscord {
    pub messages: MutexChannel<DiscordMessage>,
    pub reports: MutexChannel<(ChannelId, (String, i64))>,
    pub config: DiscordConfig,
    pub applications: MutexChannel<(String, i64, bool, Interaction)>,
    pub stop: Arc<AtomicBool>,
}

#[async_trait]
impl EventHandler for DiscordBotDiscord {
    async fn message(&self, ctx: Context, msg: Message) {
        if msg.author.bot || msg.webhook_id.is_some() {
            return;
        }
        if msg.channel_id == self.config.chat_channel_id {
            let message = DiscordMessage {
                author: msg
                    .author
                    .nick_in(ctx.http, msg.guild_id.unwrap())
                    .await
                    .unwrap_or_else(|| msg.author.name.clone()),
                channel: msg.channel_id,
                message: msg.content,
            };
            self.messages.lock().await.push_back(message);
        } else if msg.content.starts_with("!репорт") || msg.content.starts_with("!report") {
            let arg1 = msg.content.split(' ').nth(1).unwrap_or("").to_string();
            let arg2 = msg
                .content
                .split(' ')
                .nth(2)
                .and_then(|s| s.parse().ok())
                .unwrap_or(31 * 24);
            self.reports
                .lock()
                .await
                .push_back((msg.channel_id, (arg1, arg2)));
        } else if msg.content == "!убить роботов" {
            if msg.author.id == UserId(942183095371702284) {
                msg.reply(ctx.http, "За что(((((((((( ладно").await.unwrap();
                std::process::exit(0);
            } else {
                msg.reply(ctx.http, "Сам убейся, ты кто вообще")
                    .await
                    .unwrap();
            }
        } else if msg.content == "!остановить роботов" {
            if msg.author.id == UserId(942183095371702284) {
                msg.reply(ctx.http, "ок только не забудь убить потом")
                    .await
                    .unwrap();
                self.stop.store(true, Ordering::Relaxed);
            } else {
                msg.reply(ctx.http, "Сам остановись, ты кто вообще")
                    .await
                    .unwrap();
            }
        }
    }

    async fn ready(&self, _: Context, ready: Ready) {
        println!("[DISCORD] {} is connected!", ready.user.name);
    }

    async fn interaction_create(&self, _ctx: Context, interaction: Interaction) {
        if let Some(ref data) = interaction.data {
            match data {
                InteractionData::ApplicationCommand(_command) => {
                    panic!("У нас же нет команд...")
                }
                InteractionData::MessageComponent(component) => {
                    if component.component_type == ComponentType::Button {
                        if let [bool, name, id] = component
                            .custom_id
                            .split('/')
                            .collect::<Vec<&str>>()
                            .as_slice()
                        {
                            let name = name.to_string();
                            let id = id.parse::<i64>().unwrap();
                            let bool = bool.parse::<bool>().unwrap();
                            self.applications.lock().await.push_back((
                                name,
                                id,
                                bool,
                                interaction.clone(),
                            ));
                        }
                    }
                }
            }
        }
    }
}

#[derive(Clone)]
pub struct DiscordMessage {
    pub author: String,
    pub channel: ChannelId,
    pub message: String,
}
