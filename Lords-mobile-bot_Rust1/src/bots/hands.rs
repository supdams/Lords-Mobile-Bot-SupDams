use std::time::Duration;

use async_trait::async_trait;

use crate::bot::{Bot, HandleStatus};
use crate::connection::Connection;
use crate::packet_type::{AllianceAttr, ChatMessage, HelpKind, HelpRequest, PacketType};

pub struct HandsBot {
    beat_time: f64,
    server_time: i64,
    cancel_time: f64,
    igg_id: i64,
}

#[async_trait]
impl Bot for HandsBot {
    type Config = ();

    async fn handle_packet(
        &mut self,
        connection: &mut Connection,
        packet: PacketType,
    ) -> anyhow::Result<HandleStatus> {
        println!("{} got {:?}", self.igg_id, packet);
        match packet {
            PacketType::ClientLoginAgain => return Ok(HandleStatus::Reconnect),
            PacketType::ClientSomebodyNeedsHelp {
                help:
                    HelpRequest {
                        record_sn,
                        player_name,
                        ..
                    },
            } => {
                if player_name.starts_with("42 ") {
                    return Ok(HandleStatus::Ok);
                }
                connection.send_packet(
                    PacketType::ServerSendHelp {
                        record_sns: vec![record_sn],
                    },
                    true,
                )?;
            }
            PacketType::ClientNeedHelp { helps, .. } => {
                for help in helps.chunks(30) {
                    let help = help
                        .iter()
                        .filter(|h| !h.player_name.starts_with("42 "))
                        .collect::<Vec<&HelpRequest>>();
                    connection.send_packet(
                        PacketType::ServerSendHelp {
                            record_sns: help.iter().map(|help| help.record_sn).collect(),
                        },
                        true,
                    )?;
                }
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
                self.heartbeat(connection)?;
            }
            PacketType::ClientChatMessage { messages, .. } => {
                for message in messages {
                    self.process_message(message, connection).await?;
                }
            }
            PacketType::ClientAllianceData(AllianceAttr::AllianceBox1 { gift, .. }) => {
                if gift.status == 0 {
                    connection.send_packet(PacketType::ServerOpenGift(gift.sn), true)?;
                }
            }
            PacketType::ClientGiftInfo { gifts, .. } => {
                for gift in gifts {
                    if gift.status == 0 {
                        connection.send_packet(PacketType::ServerOpenGift(gift.sn), true)?;
                    }
                }
            }
            PacketType::ClientBuildComplete { .. } => {
                if self.igg_id == 1019941342 {
                    connection.send_packet(
                        PacketType::ServerSendChat {
                            channel: 1,
                            message: "Здание улучшено. Что дальше делать?".to_string(),
                        },
                        true,
                    )?;
                }
            }
            PacketType::ClientBuildingError(err) => {
                connection.send_packet(
                    PacketType::ServerSendChat {
                        channel: 1,
                        message: format!("Ошибка {} при постройке", err),
                    },
                    true,
                )?;
            }
            PacketType::ClientBuildBegin {
                food,
                stone,
                timber: wood,
                ore,
                gold,
                ..
            } => {
                if self.igg_id == 1019941342 {
                    connection.send_packet(PacketType::ServerSendChat { channel: 1, message: format!("Начинаю строить. Ресурсы, которые остались: {} еды, {} камня, {} дерева, {} руды, {} золота.", food, stone, wood, ore, gold) }, true)?;
                }
                connection.send_packet(PacketType::ServerNeedHelp(HelpKind::Building), true)?;
            }
            _ => (),
        }
        Ok(HandleStatus::Ok)
    }
    async fn tick(&mut self, connection: &mut Connection, delta: Duration) -> anyhow::Result<()> {
        if self.beat_time > 0.0 && self.beat_time - delta.as_secs_f64() <= 0.0 {
            self.heartbeat(connection)?;
        }
        self.beat_time -= delta.as_secs_f64();
        if self.cancel_time > 0.0 && self.cancel_time - delta.as_secs_f64() <= 0.0 {
            connection.send_packet(PacketType::ServerBuildCancel, true)?;
        }
        self.cancel_time -= delta.as_secs_f64();
        Ok(())
    }

    async fn start(connection: Connection, _: &Self::Config) -> anyhow::Result<HandleStatus> {
        let igg_id = connection.igg_id;
        connection.run_loop(HandsBot::new(igg_id)).await
    }
}

impl HandsBot {
    pub fn new(igg_id: i64) -> Self {
        HandsBot {
            beat_time: 0.0,
            server_time: -1,
            cancel_time: 0.0,
            igg_id,
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
    pub async fn process_message(
        &mut self,
        message: ChatMessage,
        connection: &mut Connection,
    ) -> anyhow::Result<()> {
        if message.player_name.starts_with("A4 ") {
            return Ok(());
        }
        if let Some(text) = message.original_text {
            if text == *"+р" {
                if self.cancel_time > 0.0 {
                    connection.send_packet(PacketType::ServerBuildCancel, true)?;
                }
                connection.send_packet(
                    PacketType::ServerBuildBegin {
                        manor_id: 0x0001,
                        build_id: 0x0008,
                    },
                    true,
                )?;
                connection.send_packet(PacketType::ServerNeedHelp(HelpKind::Building), true)?;
                self.cancel_time = 10.0;
            } else if text.starts_with("+стр") {
                if let [_, build, manor] = &text.split(' ').collect::<Vec<&str>>()[..] {
                    connection.send_packet(
                        PacketType::ServerBuildBegin {
                            manor_id: manor.parse()?,
                            build_id: build.parse()?,
                        },
                        true,
                    )?;
                }
            }
        }
        Ok(())
    }
}
