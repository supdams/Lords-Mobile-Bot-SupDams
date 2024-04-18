use std::sync::Arc;
use std::time::Duration;

use async_trait::async_trait;
use serde::Deserialize;
use tokio::sync::Mutex;

use crate::bot::{Bot, HandleStatus};
use crate::connection::Connection;
use crate::packet_type::PacketType;
use crate::point::Point;

pub struct RegisterBot {
    beat_time: f64,
    config: <Self as Bot>::Config,
}

#[async_trait]
impl Bot for RegisterBot {
    type Config = RegisterConfig;
    async fn handle_packet(
        &mut self,
        connection: &mut Connection,
        packet: PacketType,
    ) -> anyhow::Result<HandleStatus> {
      //  println!("Got {:?}", packet);
        match packet {
            PacketType::ClientServerTime { .. } => {
                self.make_beat(15.0);
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
                let renamed_guard = self.config.rename.lock().await;
                let renamed = *renamed_guard;
                drop(renamed_guard);
                match renamed {
                    RegisterState::New => {
                        connection.send_packet(PacketType::ServerUpdateNewbieLog(0), true)?;
                        connection.send_packet(PacketType::ServerUpdateNewbieLog(1), true)?;
                        connection.send_packet(PacketType::ServerPassNewbie, true)?;
                        self.heartbeat(connection)?;
                        connection.send_packet(
                            PacketType::ServerRename {
                                bought: false,
                                num: 0,
                                name: self.config.name.clone(),
                            },
                            true,
                        )?;
                    }
                    RegisterState::Renamed => {
                        connection.send_packet(
                            PacketType::ServerNewbieTeleport {
                                kingdom_id: self.config.kingdom,
                                point: self.config.point,
                            },
                            true,
                        )?;
                    }
                    RegisterState::Teleported => {
                        connection.send_packet(
                            PacketType::ServerAllianceApply(self.config.alliance.clone()),
                            true,
                        )?;
                    }
                }
            }
            PacketType::ClientRename { .. } => {
                *self.config.rename.lock().await = RegisterState::Renamed;
                return Ok(HandleStatus::Reconnect);
            }
            PacketType::ClientUseTeleport { .. } => {
                *self.config.rename.lock().await = RegisterState::Teleported;
                return Ok(HandleStatus::Reconnect);
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
        Ok(())
    }

    async fn start(connection: Connection, config: &Self::Config) -> anyhow::Result<HandleStatus> {
        connection
            .run_loop(RegisterBot::new(config.clone()).await)
            .await
    }
}

impl RegisterBot {
    pub async fn new(config: <Self as Bot>::Config) -> Self {
        RegisterBot {
            beat_time: 15.0,
            config,
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
}

#[derive(Deserialize)]
pub struct RegisterResponse {
    #[serde(rename = "errCode")]
    pub err_code: i32,
    #[serde(rename = "errStr")]
    pub err_str: String,
    pub result: RegisterResponseResult,
    pub result_type: String,
}

#[derive(Deserialize)]
pub struct RegisterResponseResult {
    pub login: String,
    pub iggid: String,
    #[serde(rename = "platformUid")]
    pub platform_uid: String,
    pub access_key: String,
}

#[derive(Clone)]
pub struct RegisterConfig {
    pub name: String,
    pub kingdom: u16,
    pub point: Point,
    pub alliance: String,
    pub rename: Arc<Mutex<RegisterState>>,
}

#[derive(Copy, Clone)]
pub enum RegisterState {
    New,
    Renamed,
    Teleported,
}
