use crate::bot::{Bot, HandleStatus};
use crate::packet_type::PacketType;
use crate::ENCRYPTION_KEY;
use des::cipher::generic_array::GenericArray;
use des::cipher::{BlockEncrypt, NewBlockCipher};
use std::io::{Read, Write};
use std::net::{Shutdown, TcpStream};
use std::time::SystemTime;
use tokio::time::Duration;

pub struct Connection {
    pub(crate) stream: TcpStream,
    pub(crate) seq_id: u32,
    pub(crate) guest_seq_id: u32,
    pub(crate) igg_id: i64,
    pub(crate) access_key: String,
}

impl Connection {
    pub fn send_packet(&mut self, packet: PacketType, enc: bool) -> anyhow::Result<()> {
        println!("Send {:?}", packet);
        let bytes = packet.serialize(self)?;
        if enc {
            let protocol = &bytes[..2];
            let data = &bytes[2..];
            let data = encrypt(data, ENCRYPTION_KEY);
            let mut packet = Vec::with_capacity(2 + data.len());
            packet.extend(protocol);
            packet.extend(data);
            self.send(packet)?;
        } else {
            self.send(bytes)?;
        }
        Ok(())
    }
    fn reset_sequences(&mut self) {
        self.guest_seq_id = 0;
        self.seq_id = 0;
    }
    pub(crate) fn connect_bootstrap(&mut self) -> anyhow::Result<()> {
        self.reset_sequences();
        self.send_packet(
            PacketType::ServerGuestLogIn {
                igg_id: self.igg_id,
                ass_key: self.access_key.clone(),
            },
            false,
        )?;
        println!("Connected to the bootstrap server");
        Ok(())
    }
    pub(crate) fn connect_game(&mut self) -> anyhow::Result<()> {
        self.reset_sequences();
        self.send_packet(
            PacketType::ServerLogIn {
                igg_id: self.igg_id,
                battle_is_oul: true,
                b_recv_kingdom: 0,
                ass_key: self.access_key.clone(),
                inviter_igg_id: 0,
                inviter_name: "".to_string(),
            },
            false,
        )?;
        println!("Connected to the game server");
        Ok(())
    }
    pub(crate) fn disconnect(&mut self) -> anyhow::Result<()> {
        self.stream.shutdown(Shutdown::Both)?;
        Ok(())
    }
    fn send(&mut self, bytes: Vec<u8>) -> anyhow::Result<()> {
        let mut buf = (bytes.len() as u16 + 2).to_le_bytes().to_vec();
        buf.write_all(&bytes)?;
        self.stream.write_all(&buf)?;
        self.stream.flush()?;
        Ok(())
    }
    pub(crate) async fn run_loop<B>(mut self, mut bot: B) -> anyhow::Result<HandleStatus>
    where
        B: Bot,
    {
        self.stream.set_nonblocking(true)?;
        let mut time = SystemTime::now();
        loop {
            let mut buf = [0; 2];
            if self.stream.read_exact(&mut buf).is_ok() {
                let size_with_prefix = u16::from_le_bytes(buf) as usize;
                if size_with_prefix > 2 {
                    let mut buf = vec![0; size_with_prefix - 2];
                    if self.stream.read_exact(&mut buf).is_ok() {
                        match PacketType::deserialize(&buf, self.igg_id) {
                            Ok(packet) => {
                                match bot.handle_packet(&mut self, packet).await {
                                    Ok(HandleStatus::Ok) => (),
                                    Ok(HandleStatus::Reconnect) => {
                                        return Ok(HandleStatus::Reconnect)
                                    }
                                    Ok(HandleStatus::Disconnect) => {
                                        return Ok(HandleStatus::Disconnect)
                                    }
                                    Err(err) => {
                                        // println!("[{}] Bot error: {}, {:02X?}", self.igg_id, err, buf);
                                        return Err(err);
                                    }
                                }
                            }
                            Err(_error) => {
                                // println!("Error deserializing: {}, {:02X?}", error, buf);
                            }
                        }
                    }
                }
            }
            let delta = time.elapsed().unwrap();
            time = SystemTime::now();
            bot.tick(&mut self, delta).await?;
            tokio::time::sleep(Duration::from_millis(10)).await;
        }
    }
    pub fn new(igg_id: i64, access_key: String, stream: TcpStream) -> Connection {
        Connection {
            stream,
            seq_id: 0,
            guest_seq_id: 0,
            igg_id,
            access_key,
        }
    }
}

pub fn encrypt(data: &[u8], key: &str) -> Vec<u8> {
    let cipher = des::Des::new(GenericArray::from_slice(key.as_bytes()));
    let mut out = Vec::new();
    for chunk in data.chunks(8) {
        if chunk.len() < 8 {
            out.extend_from_slice(chunk);
            break;
        }
        let mut block = [0; 8];
        for (i, byte) in chunk.iter().enumerate() {
            block[i] = *byte;
        }
        let mut array = GenericArray::from(block);
        cipher.encrypt_block(&mut array);
        out.extend(array.to_vec());
    }
    out.truncate(data.len());
    out
}
