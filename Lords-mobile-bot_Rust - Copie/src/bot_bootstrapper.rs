use crate::bot::{Bot, HandleStatus};
use crate::connection::Connection;
use crate::packet_type::PacketType;
use crate::util::get_ip;
use async_trait::async_trait;
use std::net::TcpStream;
use tokio::time::Duration;

pub struct BotBootstrapper<'a, T>(&'a T::Config)
where
    T: Bot + Send;

impl<T> BotBootstrapper<'_, T>
where
    T: Bot + Send,
{
    pub fn new(config: &T::Config) -> BotBootstrapper<T> {
        BotBootstrapper(config)
    }
}

#[async_trait]
impl<T> Bot for BotBootstrapper<'_, T>
where
    T: Bot + Send,
    T::Config: Send + Sync,
{
    type Config = T::Config;

    async fn handle_packet(
        &mut self,
        connection: &mut Connection,
        packet: PacketType,
    ) -> anyhow::Result<HandleStatus> {
        println!("Got {:?}", packet);
        return match packet {
            PacketType::ClientGuestLogIn {
                ip,
                igg_id: _,
                port,
            } => {
                connection.disconnect()?;
                let ip = get_ip(ip, true);
                let mut connection = Connection::new(
                    connection.igg_id,
                    connection.access_key.clone(),
                    TcpStream::connect(format!("{}:{}", ip, port))?,
                );
                connection.connect_game()?;
                T::start(connection, self.0).await
            }
            PacketType::ClientLoginAgain => Ok(HandleStatus::Reconnect),
            _ => unreachable!(),
        };
    }

    async fn tick(&mut self, _: &mut Connection, _: Duration) -> anyhow::Result<()> {
        Ok(())
    }

    async fn start(_: Connection, _: &Self::Config) -> anyhow::Result<HandleStatus> {
        unimplemented!()
    }
}
