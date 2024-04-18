use std::fs::OpenOptions;
use std::io::{Cursor, Write};
use std::net::TcpStream;
use std::pin::Pin;
use std::sync::Arc;

use futures::future::join_all;
use rand::distributions::Alphanumeric;
use rand::{thread_rng, Rng};
use reqwest::{Client, Proxy};
use rocket::config::LogLevel;
use rocket::routes;
use rocket::{get, Config};
use serenity::model::id::{ChannelId, WebhookId};
use tokio::sync::Mutex;
use tokio::time::Duration;

use bots::autodevelopment::AutoBot;
use bots::discord::{DiscordBot, DiscordConfig};
use bots::hands::HandsBot;
use bots::register::{RegisterBot, RegisterConfig, RegisterResponse, RegisterState};

use crate::bot::{Bot, HandleStatus};
use crate::bot_bootstrapper::BotBootstrapper;
use crate::bots::apply::ApplyBot;
use crate::bots::autodevelopment_manual_hands::AutoManualHandsBot;
use crate::connection::Connection;
use crate::point::Point;
use crate::util::get_ip;

mod bot;
mod bot_bootstrapper;
mod bots;
mod connection;
mod packet;
mod packet_type;
mod point;
mod register;
mod util;

const BOOTSTRAP_SERVER_IP: &str = "192.243.44.63";
const BOOTSTRAP_SERVER_PORT: u16 = 5999;
const ENCRYPTION_KEY: &str = "L*#)@!&8";

#[tokio::main]
async fn main() -> anyhow::Result<()> {
    let mut bots = Vec::<Pin<Box<dyn futures::Future<Output = ()>>>>::new();
    for line in std::fs::read_to_string("bots.dat")
        .expect("WHERE bots.dat")
        .lines()
    {
        if line.starts_with('#') || line.trim().is_empty() {
            continue;
        }
        let args = line
            .replace("\\/", "\u{5555}")
            .split('/')
            .map(|arg| arg.to_string().replace('\u{5555}', "/"))
            .collect::<Vec<String>>();
        match args[0].as_str() {
            "HANDS" => bots.push(Box::pin(start_bot::<HandsBot, _>(
                args[1].parse()?,
                args[2].clone(),
                (),
            ))),
            "REGISTER" => bots.push(Box::pin(register_bot(RegisterConfig {
                name: generate_name().await,
                kingdom: args[1].parse()?,
                point: Point::from_xy(args[2].parse()?, args[3].parse()?),
                alliance: args[4].clone(),
                rename: Arc::new(Mutex::new(RegisterState::New)),
            }))),
            "AUTO" => bots.push(Box::pin(start_bot::<AutoBot, _>(
                args[1].parse()?,
                args[2].clone(),
                (),
            ))),
            "MANUAL" => bots.push(Box::pin(start_bot::<AutoManualHandsBot, _>(
                args[1].parse()?,
                args[2].clone(),
                (),
            ))),
            "DISCORD" => bots.push(Box::pin(start_bot::<DiscordBot, _>(
                args[1].parse()?,
                args[2].clone(),
                DiscordConfig {
                    auto_message_invite_link: args[3].clone(),
                    chat_webhook_id: WebhookId(args[4].parse()?),
                    chat_webhook_token: args[5].clone(),
                    rally_channel_id: ChannelId(args[6].parse()?),
                    rally_message_format: args[7].clone(),
                    applications_channel_id: ChannelId(args[8].parse()?),
                    applications_message_format: args[9].clone(),
                    mobilization_channel_id: ChannelId(args[10].parse()?),
                    mobilization_message_format: args[11].clone(),
                    chat_channel_id: ChannelId(args[12].parse()?),
                    token: args[13].clone(),
                },
            ))),
            "APPLY" => bots.push(Box::pin(start_bot::<ApplyBot, _>(
                args[1].parse()?,
                args[2].clone(),
                args[3].to_string(),
            ))),
            _ => panic!("Unknown bot type"),
        }
    }
    let service = async {
        println!("Starting service");
        rocket::build()
            .configure(Config {
                log_level: LogLevel::Off,
                port: 8000,
                ..Default::default()
            })
            .mount("/", routes![status])
            .ignite()
            .await
            .unwrap()
            .launch()
            .await
            .unwrap();
    };
    let bots = join_all(bots);
    futures::future::select(Box::pin(service), bots).await;
    Ok(())
}

#[get("/status")]
fn status() -> &'static str {
    "All systems operational\n"
}

async fn start_bot<B, A>(igg_id: i64, access_key: A, config: B::Config)
where
    B: Bot + Send,
    B::Config: Send + Sync,
    A: Into<String> + Clone,
{
    // println!("{igg_id} waiting for 90 seconds");
    // tokio::time::sleep(Duration::from_secs(90)).await;
    // println!("{igg_id} starting");
    loop {
        let server = get_server();
        let stream = TcpStream::connect(server).unwrap();
        let mut connection = Connection::new(igg_id, access_key.clone().into(), stream);
        if connection.connect_bootstrap().is_ok() {
            match connection
                .run_loop(BotBootstrapper::<B>::new(&config))
                .await
            {
                Ok(handle_status) => {
                    println!("disconnected");
                    match handle_status {
                        HandleStatus::Ok => (),
                        HandleStatus::Disconnect => {
                            println!("disconnecting");
                            break;
                        }
                        HandleStatus::Reconnect => {
                            println!("waiting 2s");
                            tokio::time::sleep(Duration::from_secs(2)).await;
                            continue;
                        }
                    }
                }
                Err(error) => {
                    println!("Error: {}", error);
                }
            }
        }
        tokio::time::sleep(Duration::from_secs(5)).await;
    }
}

fn get_server() -> String {
    let hostname = get_ip(BOOTSTRAP_SERVER_IP.to_string(), false);
    format!("{}:{}", hostname, BOOTSTRAP_SERVER_PORT)
}

async fn register_bot(config: RegisterConfig) {
    let proxies = std::fs::read_to_string("proxy_list.txt").unwrap();
    let proxies = proxies.split('\n').collect::<Vec<&str>>();
    let used_proxies = std::fs::read_to_string("used_proxies.txt").unwrap();
    let used_proxies = used_proxies.split('\n').collect::<Vec<&str>>();
    let proxy_string = proxies
        .iter()
        .find(|proxy| !used_proxies.contains(proxy))
        .expect("Не хватает прокси!");
    println!("Using proxy {}", proxy_string);
    let mut used = OpenOptions::new()
        .write(true)
        .append(true)
        .open("used_proxies.txt")
        .unwrap();
    used.write_all(format!("{}\n", proxy_string).as_bytes())
        .unwrap();
    used.flush().unwrap();
    drop(used);

    let mut attempts = 1;
    while attempts > 0 {
        let proxy = if proxy_string.contains('@') {
            if let [auth, proxy] = proxy_string.split('@').collect::<Vec<&str>>().as_slice() {
                if let [username, password] = auth.split(':').collect::<Vec<&str>>().as_slice() {
                    println!("{}", proxy);
                    Proxy::all(*proxy).unwrap().basic_auth(username, password)
                } else {
                    panic!("Invalid proxy")
                }
            } else {
                panic!("Invalid proxy")
            }
        } else {
            Proxy::all(*proxy_string).unwrap()
        };
        let client = reqwest::Client::builder()
            .proxy(proxy)
            .timeout(Duration::from_secs(10))
            .build()
            .unwrap();
        let email = format!(
            "{}@gmail.com",
            thread_rng()
                .sample_iter(&Alphanumeric)
                .take(thread_rng().gen_range(8..=16))
                .map(char::from)
                .collect::<String>()
        );
        let password = format!(
            "1{}a",
            thread_rng()
                .sample_iter(&Alphanumeric)
                .take(thread_rng().gen_range(10..=14))
                .map(char::from)
                .collect::<String>()
        );
        println!("{} : {}", email, password);
        let response = client.get(format!("http://cgi.igg.com/public/igg_register?m_game_id=1051019902&email={0}&m_pass={1}&m_pass2={1}", email, password)).send().await.unwrap();
        let text = response.text().await.unwrap();
        let text = text.trim_end_matches(|c| c != '}');
        println!("{}", text);
        let response: serde_json::Result<RegisterResponse> =
            serde_json::from_reader(Cursor::new(text));
        if response.is_err() {
            attempts += 1;
            continue;
        }
        let response = response.unwrap();
        let mut bots = OpenOptions::new()
            .write(true)
            .append(true)
            .open("bots.dat")
            .unwrap();
        bots.write_all(
            format!(
                "#/{}/{}\n",
                response.result.iggid, response.result.access_key
            )
            .as_bytes(),
        )
        .unwrap();
        bots.flush().unwrap();
        drop(bots);
        let mut successfully_used = OpenOptions::new()
            .write(true)
            .append(true)
            .open("successfully_used_proxies.txt")
            .unwrap();
        successfully_used
            .write_all(format!("{}\n", proxy_string).as_bytes())
            .unwrap();
        successfully_used.flush().unwrap();
        drop(successfully_used);
        loop {
            let server = get_server();
            let stream = TcpStream::connect(server).unwrap();
            let mut connection = Connection::new(
                response.result.iggid.parse().unwrap(),
                response.result.access_key.clone(),
                stream,
            );
            println!("connecting");
            if connection.connect_bootstrap().is_ok() {
                println!("connected");
                if let Ok(handle_status) = connection
                    .run_loop(BotBootstrapper::<RegisterBot>::new(&config))
                    .await
                {
                    println!("disconnected");
                    match handle_status {
                        HandleStatus::Ok => (),
                        HandleStatus::Disconnect => {
                            println!("disconnecting");
                            return;
                        }
                        HandleStatus::Reconnect => {
                            println!("waiting 2s");
                            tokio::time::sleep(Duration::from_secs(2)).await;
                            continue;
                        }
                    }
                }
            }
            println!("waiting 5s");
            tokio::time::sleep(Duration::from_secs(5)).await;
        }
    }
}

async fn generate_name() -> String {
    Client::new()
        .post("https://uzby.com/api.php".to_string())
        .header(
            "Content-Type",
            "application/x-www-form-urlencoded; charset=UTF-8",
        )
        .body("min=9&max=13")
        .send()
        .await
        .unwrap()
        .text()
        .await
        .unwrap()
}
