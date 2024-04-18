use std::time::Duration;

use async_trait::async_trait;

use crate::bot::{Bot, HandleStatus};
use crate::connection::Connection;
use crate::packet_type::PacketType;

pub struct ApplyBot {
    beat_time: f64,
    config: <Self as Bot>::Config,
}

#[async_trait]
impl Bot for ApplyBot {
    type Config = String;
    async fn handle_packet(
        &mut self,
        connection: &mut Connection,
        packet: PacketType,
    ) -> anyhow::Result<HandleStatus> {
        println!("Got {:?}", packet);
        match packet {
            PacketType::ClientLoginAgain => return Ok(HandleStatus::Reconnect),
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
                connection
                    .send_packet(PacketType::ServerAllianceApply(self.config.clone()), true)?;
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
            .run_loop(ApplyBot::new(config.clone()).await)
            .await
    }
}

impl ApplyBot {
    pub async fn new(config: <Self as Bot>::Config) -> Self {
        ApplyBot {
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
