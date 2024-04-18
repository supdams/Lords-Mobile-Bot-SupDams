//use std::collections::{HashMap, VecDeque};
//use std::iter::FromIterator;
//use std::sync::atomic::{AtomicBool, Ordering};
//use std::sync::Arc;
//use std::time::Duration;

//use async_trait::async_trait;
use serenity::client::EventHandler;
//use serde_json::Value;
//use serenity::client::{Context, EventHandler};
use serenity::http::Http;
//use serenity::model::channel::{Message, ReactionType};
//use serenity::model::gateway::Ready;
//use serenity::model::id::{ChannelId, UserId, WebhookId};
//use serenity::model::interaction::{ButtonStyle, ComponentType, Interaction, InteractionData, InteractionResponseType,};
//use serenity::Client;
//use strfmt::Format;
//use tokio::sync::Mutex;

//// crate::bot::{Bot, HandleStatus};
use crate::connection::Connection;

//pub type MutexChannel<T> = Arc<Mutex<VecDeque<T>>>;

pub struct DiscordBot {
    beat_time: f64,
    server_time: i64,
    // messages: MutexChannel<DiscordMessage>,
    chat_timeout: f64,
    // chat_queue: VecDeque<String>,
    discord: Http,
    rallies_to_notify: Option<String>,
    rally_cache: Option<RallyCache>,
    //  applicants: HashMap<Applicant, Message>,
    mobilization_score: u32,
    // reports: MutexChannel<(ChannelId, (String, i64))>,
    //gifts: Vec<AllianceGift>,
    config: DiscordConfig,
    opened_chat: bool,
    name: String,
    //  applications: MutexChannel<(String, i64, bool, Interaction)>,
    // application_wait: HashMap<i64, (String, Interaction)>,
    //stop: Arc<AtomicBool>,
}


impl DiscordBot {
    pub fn new(
        //messages: MutexChannel<DiscordMessage>,
        //reports: MutexChannel<(ChannelId, (String, i64))>,
        config: DiscordConfig,
        // applications: MutexChannel<(String, i64, bool, Interaction)>,
        //stop: Arc<AtomicBool>,
    ) -> Self {
        DiscordBot {
            beat_time: 0.0,
            server_time: -1,
            // messages,
            chat_timeout: 0.0,
            // chat_queue: VecDeque::new(),
            discord: Http::new_with_token(&config.token),
            rallies_to_notify: None,
            rally_cache: None,
            //   applicants: HashMap::new(),
            mobilization_score: 0,
            // reports,
            // gifts: Vec::new(),
            config,
            opened_chat: false,
            name: String::new(),
            //applications,
            //application_wait: Default::default(),
            //stop,
        }
    }
    pub fn heartbeat(&mut self, connection: &mut Connection) -> anyhow::Result<()> {
        self.make_beat(15.0);
        //  connection.send_packet(PacketType::ServerHeartBeat, true)?;
        Ok(())
    }
    pub fn make_beat(&mut self, time: f64) {
        self.beat_time = time;
    }

    async fn on_message(
        &mut self,
        //  message: ChatMessage,
       // connection: &mut Connection,
    ) -> anyhow::Result<()> {
        Ok(())
    }
    pub fn send_message(
        &mut self,
        message: String,
        connection: &mut Connection,
    ) -> anyhow::Result<()> {
        if !self.opened_chat {
            self.opened_chat = true;
        }
    //    self.chat_queue.push_back(message);
        Ok(())
    }
    pub fn send_rallies_request(&self, connection: &mut Connection) -> anyhow::Result<()> {
        // connection.send_packet(PacketType::ServerGetRallies, true)?;
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
    // pub chat_webhook_id: WebhookId,
    pub chat_webhook_token: String,
    //  pub rally_channel_id: ChannelId,
    pub rally_message_format: String,
    // pub applications_channel_id: ChannelId,
    pub applications_message_format: String,
    // pub mobilization_channel_id: ChannelId,
    pub mobilization_message_format: String,
    // pub chat_channel_id: ChannelId,
    pub token: String,
}



#[derive(Clone)]
pub struct DiscordMessage {
    pub author: String,
    //  pub channel: ChannelId,
    pub message: String,
}
