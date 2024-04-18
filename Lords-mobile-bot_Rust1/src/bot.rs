use async_trait::async_trait;
use tokio::time::Duration;

use crate::connection::Connection;
use crate::packet_type::PacketType;

#[async_trait]
pub trait Bot {
    type Config;
    async fn handle_packet(
        &mut self,
        connection: &mut Connection,
        packet: PacketType,
    ) -> anyhow::Result<HandleStatus>;

    async fn tick(&mut self, connection: &mut Connection, duration: Duration)
        -> anyhow::Result<()>;

    async fn start(connection: Connection, config: &Self::Config) -> anyhow::Result<HandleStatus>;
}

#[allow(unused)]
#[derive(Debug)]
pub enum HandleStatus {
    Ok,
    Reconnect,
    Disconnect,
}
