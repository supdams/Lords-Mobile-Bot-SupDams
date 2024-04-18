use std::collections::HashMap;
use std::time::{Duration, SystemTime};

use async_trait::async_trait;

use build::*;

use crate::bot::{Bot, HandleStatus};
use crate::connection::Connection;
use crate::packet_type::{
    AllianceAttr, EMsgState, HelpKind, HelpRequest, HeroData, PacketType, TimerMissionState,
    TimerMissions,
};

mod item_ids {
    pub const FOOD_30K: u16 = 0x03F1;
    pub const STONE_10K: u16 = 0x03F2;
    pub const TIMBER_10K: u16 = 0x03F3;
    pub const ORE_10K: u16 = 0x03F4;
    pub const GOLD_3K: u16 = 0x03F5;
    pub const FOOD_150K: u16 = 0x03F6;
    pub const STONE_50K: u16 = 0x03F7;
    pub const TIMBER_50K: u16 = 0x03F8;
    pub const ORE_50K: u16 = 0x03F9;
    pub const GOLD_15K: u16 = 0x03FA;
    pub const FOOD_500K: u16 = 0x03FB;
    pub const STONE_150K: u16 = 0x03FC;
    pub const TIMBER_150K: u16 = 0x03FD;
    pub const ORE_150K: u16 = 0x03FE;
    pub const GOLD_50K: u16 = 0x03FF;
    pub const FOOD_2M: u16 = 0x0400;
    pub const STONE_500K: u16 = 0x0401;
    pub const TIMBER_500K: u16 = 0x0402;
    pub const ORE_500K: u16 = 0x0403;
    pub const GOLD_200K: u16 = 0x0404;
    pub const FOOD_6M: u16 = 0x0445;
    pub const STONE_1_5M: u16 = 0x0446;
    pub const TIMBER_1_5M: u16 = 0x0447;
    pub const ORE_1_5M: u16 = 0x0448;
    pub const GOLD_600K: u16 = 0x0449;
    pub const FOOD_20M: u16 = 0x044A;
    pub const STONE_5M: u16 = 0x044B;
    pub const TIMBER_5M: u16 = 0x044C;
    pub const ORE_5M: u16 = 0x044D;
    pub const GOLD_2M: u16 = 0x044E;
    pub const FOOD_60M: u16 = 0x044F;
    pub const STONE_15M: u16 = 0x0450;
    pub const TIMBER_15M: u16 = 0x0451;
    pub const ORE_15M: u16 = 0x0452;
    pub const GOLD_6M: u16 = 0x0453;
    pub const FOOD_5K: u16 = 0x0492;
    pub const STONE_3K: u16 = 0x0493;
    pub const TIMBER_3K: u16 = 0x0494;
    pub const ORE_3K: u16 = 0x0495;

    pub const RESOURCE_ITEMS: [u16; 39] = [
        FOOD_30K,
        STONE_10K,
        TIMBER_10K,
        ORE_10K,
        GOLD_3K,
        FOOD_150K,
        STONE_50K,
        TIMBER_50K,
        ORE_50K,
        GOLD_15K,
        FOOD_500K,
        STONE_150K,
        TIMBER_150K,
        ORE_150K,
        GOLD_50K,
        FOOD_2M,
        STONE_500K,
        TIMBER_500K,
        ORE_500K,
        GOLD_200K,
        FOOD_6M,
        STONE_1_5M,
        TIMBER_1_5M,
        ORE_1_5M,
        GOLD_600K,
        FOOD_20M,
        STONE_5M,
        TIMBER_5M,
        ORE_5M,
        GOLD_2M,
        FOOD_60M,
        STONE_15M,
        TIMBER_15M,
        ORE_15M,
        GOLD_6M,
        FOOD_5K,
        STONE_3K,
        TIMBER_3K,
        ORE_3K,
    ];
}

#[allow(unused)]
mod manor_ids {
    pub const CASTLE: u16 = 1;
    pub const WALL: u16 = 2;
    pub const VAULT: u16 = 3;
    pub const WATCHTOWER: u16 = 4;
    pub const BARRACKS_1: u16 = 5;
    pub const INFIRMARY_1: u16 = 6;
    pub const STONE_1: u16 = 7;
    pub const TIMBER_1: u16 = 8;
    pub const ORE_1: u16 = 10;
    pub const FOOD_1: u16 = 11;
    pub const TRADING_POST: u16 = 13;
    pub const ACADEMY: u16 = 14;
    pub const WORKSHOP: u16 = 16;
    pub const EMBASSY: u16 = 17;
    pub const MANOR_1: u16 = 19;
}

#[allow(unused)]
mod build_ids {
    pub const TIMBER: u16 = 1;
    pub const STONE: u16 = 2;
    pub const ORE: u16 = 3;
    pub const FOOD: u16 = 4;
    pub const MANOR: u16 = 5;
    pub const BARRACKS: u16 = 6;
    pub const INFIRMARY: u16 = 7;
    pub const CASTLE: u16 = 8;
    pub const VAULT: u16 = 9;
    pub const ACADEMY: u16 = 10;
    pub const WALL: u16 = 12;
    pub const WATCHTOWER: u16 = 13;
    pub const EMBASSY: u16 = 14;
    pub const WORKSHOP: u16 = 15;
    pub const TRADING_POST: u16 = 17;
}

#[allow(unused)]
mod build {
    use super::build_ids;
    use super::manor_ids;

    pub const TIMBER: (u16, u16) = (manor_ids::TIMBER_1, build_ids::TIMBER);
    pub const STONE: (u16, u16) = (manor_ids::STONE_1, build_ids::STONE);
    pub const ORE: (u16, u16) = (manor_ids::ORE_1, build_ids::ORE);
    pub const FOOD: (u16, u16) = (manor_ids::FOOD_1, build_ids::FOOD);
    pub const MANOR: (u16, u16) = (manor_ids::MANOR_1, build_ids::MANOR);
    pub const BARRACKS: (u16, u16) = (manor_ids::BARRACKS_1, build_ids::BARRACKS);
    pub const INFIRMARY: (u16, u16) = (manor_ids::INFIRMARY_1, build_ids::INFIRMARY);
    pub const CASTLE: (u16, u16) = (manor_ids::CASTLE, build_ids::CASTLE);
    pub const VAULT: (u16, u16) = (manor_ids::VAULT, build_ids::VAULT);
    pub const ACADEMY: (u16, u16) = (manor_ids::ACADEMY, build_ids::ACADEMY);
    pub const WALL: (u16, u16) = (manor_ids::WALL, build_ids::WALL);
    pub const WATCHTOWER: (u16, u16) = (manor_ids::WATCHTOWER, build_ids::WATCHTOWER);
    pub const EMBASSY: (u16, u16) = (manor_ids::EMBASSY, build_ids::EMBASSY);
    pub const WORKSHOP: (u16, u16) = (manor_ids::WORKSHOP, build_ids::WORKSHOP);
    pub const TRADING_POST: (u16, u16) = (manor_ids::TRADING_POST, build_ids::TRADING_POST);
}

// (manor, build)
const BUILD_PRIORITY: [(u16, u16); 204] = [
    WALL,
    CASTLE,
    WALL,
    CASTLE,
    WALL,
    CASTLE,
    VAULT,
    VAULT,
    VAULT,
    VAULT,
    WALL,
    CASTLE,
    STONE,
    STONE,
    STONE,
    STONE,
    STONE,
    STONE,
    BARRACKS,
    BARRACKS,
    BARRACKS,
    BARRACKS,
    BARRACKS,
    INFIRMARY,
    INFIRMARY,
    INFIRMARY,
    INFIRMARY,
    INFIRMARY,
    ORE,
    ORE,
    ORE,
    ORE,
    ORE,
    ORE,
    WORKSHOP,
    WORKSHOP,
    WORKSHOP,
    WORKSHOP,
    WORKSHOP,
    WORKSHOP,
    WALL,
    CASTLE,
    ACADEMY,
    ACADEMY,
    ACADEMY,
    ACADEMY,
    ACADEMY,
    ACADEMY,
    ACADEMY,
    ORE,
    WORKSHOP,
    WALL,
    CASTLE,
    TRADING_POST,
    TRADING_POST,
    TRADING_POST,
    TRADING_POST,
    TRADING_POST,
    TRADING_POST,
    TRADING_POST,
    TRADING_POST,
    FOOD,
    FOOD,
    FOOD,
    FOOD,
    FOOD,
    FOOD,
    FOOD,
    FOOD,
    TIMBER,
    TIMBER,
    TIMBER,
    TIMBER,
    TIMBER,
    TIMBER,
    TIMBER,
    TIMBER,
    MANOR,
    MANOR,
    MANOR,
    MANOR,
    MANOR,
    MANOR,
    MANOR,
    MANOR,
    ORE,
    WORKSHOP,
    WALL,
    CASTLE,
    STONE,
    STONE,
    STONE,
    BARRACKS,
    BARRACKS,
    BARRACKS,
    ORE,
    WORKSHOP,
    WALL,
    CASTLE,
    CASTLE,
    BARRACKS,
    WATCHTOWER,
    WATCHTOWER,
    WATCHTOWER,
    WATCHTOWER,
    WATCHTOWER,
    WATCHTOWER,
    WATCHTOWER,
    WATCHTOWER,
    WATCHTOWER,
    ORE,
    WORKSHOP,
    WALL,
    CASTLE,
    VAULT,
    VAULT,
    VAULT,
    VAULT,
    VAULT,
    VAULT,
    ORE,
    WORKSHOP,
    WALL,
    CASTLE,
    STONE,
    STONE,
    BARRACKS,
    BARRACKS,
    INFIRMARY,
    INFIRMARY,
    INFIRMARY,
    INFIRMARY,
    INFIRMARY,
    INFIRMARY,
    ORE,
    WORKSHOP,
    WALL,
    CASTLE,
    ACADEMY,
    ACADEMY,
    ACADEMY,
    ACADEMY,
    ACADEMY,
    ACADEMY,
    ORE,
    WORKSHOP,
    WALL,
    CASTLE,
    TRADING_POST,
    TRADING_POST,
    TRADING_POST,
    TRADING_POST,
    TRADING_POST,
    TRADING_POST,
    ORE,
    WORKSHOP,
    WALL,
    CASTLE,
    STONE,
    STONE,
    STONE,
    BARRACKS,
    BARRACKS,
    BARRACKS,
    ORE,
    WORKSHOP,
    WALL,
    CASTLE,
    STONE,
    BARRACKS,
    WATCHTOWER,
    WATCHTOWER,
    WATCHTOWER,
    WATCHTOWER,
    WATCHTOWER,
    WATCHTOWER,
    FOOD,
    FOOD,
    FOOD,
    FOOD,
    FOOD,
    FOOD,
    FOOD,
    FOOD,
    TIMBER,
    TIMBER,
    TIMBER,
    TIMBER,
    TIMBER,
    TIMBER,
    TIMBER,
    TIMBER,
    MANOR,
    MANOR,
    MANOR,
    MANOR,
    MANOR,
    MANOR,
    MANOR,
    MANOR,
    ORE,
    WORKSHOP,
    WALL,
    CASTLE,
];

#[allow(unused)]
pub struct AutoManualHandsBot {
    beat_time: f64,
    server_time: f64,
    igg_id: i64,
    build_time: f64,
    progress: Option<usize>,
    buildings: HashMap<u16, u8>, // manor id => level, build id is fixed
    initialization_finished: bool,
    building: bool,
    army: [[u32; 4]; 5],
    injured: [[u32; 4]; 5],
    skirmish: u8,
    resources: [(f64, i64); 5],
    heroes: Vec<HeroData>,
    items: HashMap<u16, u16>,
    timer_missions: [TimerMissions; 2],
    hands: SystemTime,
}

#[async_trait]
impl Bot for AutoManualHandsBot {
    type Config = ();

    async fn handle_packet(
        &mut self,
        connection: &mut Connection,
        packet: PacketType,
    ) -> anyhow::Result<HandleStatus> {
        println!("{} AutoManualHandsBot got {:?}", self.igg_id, packet);
        match packet {
            PacketType::ClientLoginAgain => return Ok(HandleStatus::Reconnect),
            PacketType::ClientSomebodyNeedsHelp {
                help: HelpRequest { record_sn, .. },
            } => {
                if self.hands > SystemTime::now() {
                    connection.send_packet(
                        PacketType::ServerSendHelp {
                            record_sns: vec![record_sn],
                        },
                        true,
                    )?;
                }
            }
            PacketType::ClientNeedHelp { helps, .. } => {
                for help in helps.chunks(30) {
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
                self.server_time = server_time as f64;
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
                        data_time: Some(self.server_time as i64 + 5),
                    },
                    true,
                )?;
                connection.send_packet(PacketType::ServerGetGifts, true)?;
                self.heartbeat(connection)?;
                self.initialization_finished = true;
                if self.skirmish < 3 {
                    self.start_skirmish(connection)?;
                }
            }
            PacketType::ClientAllianceData(attr) => match attr {
                AllianceAttr::AllianceBox1 { gift, .. } => {
                    if gift.status == 0 {
                        connection.send_packet(PacketType::ServerOpenGift(gift.sn), true)?;
                    }
                }
                AllianceAttr::HelpedMe {
                    kind,
                    start_time,
                    total_time,
                    already_helped,
                    ..
                } => {
                    let one_hand = 60f64.min(total_time as f64 / 100.0);
                    #[allow(clippy::single_match)]
                    match kind {
                        HelpKind::Building => {
                            self.build_time = start_time as f64
                                + (total_time as f64 - one_hand * already_helped as f64)
                        }
                        _ => (),
                    }
                }
                _ => (),
            },
            PacketType::ClientGiftInfo { gifts, .. } => {
                for gift in gifts {
                    if gift.status == 0 {
                        connection.send_packet(PacketType::ServerOpenGift(gift.sn), true)?;
                    }
                }
            }
            PacketType::ClientBuildingError(_error) => {
                //connection.send_packet(
                //    PacketType::ServerSendChat {
                //        channel: 1,
                //        message: format!("Ошибка {} при постройке", err),
                //    },
                //    true,
                //)?;
                self.building = false;
                self.build_time = self.server_time + 30.0;
            }
            PacketType::ClientBuildBegin {
                start_time,
                total_time,
                food,
                stone,
                timber,
                ore,
                gold,
                ..
            } => {
                self.build_time = (start_time + total_time as i64) as f64;
                self.building = true;
                self.resources[0].0 = food as f64;
                self.resources[1].0 = stone as f64;
                self.resources[2].0 = timber as f64;
                self.resources[3].0 = ore as f64;
                self.resources[4].0 = gold as f64;
                connection.send_packet(PacketType::ServerNeedHelp(HelpKind::Building), true)?;
            }
            PacketType::ClientBuildingInfo(buildings) => {
                for building in buildings {
                    self.buildings.insert(building.manor_id, building.level);
                }
                self.building = false;
                self.build_time = self.server_time + 5.0;
            }
            PacketType::ClientBuildComplete {
                manor_id,
                build_id: _,
                level,
            } => {
                self.building = false;
                self.build_time = self.server_time + 3.0;
                self.buildings.insert(manor_id, level);
                self.update_progress();
                /*
                connection.send_packet(
                    PacketType::ServerMissionComplete(build_quest_id(build_id, level), Some(manor_id)),
                    true,
                )?;
                */
            }
            PacketType::ClientBuildingQueue {
                start_time,
                total_time,
                ..
            } => {
                self.building = true;
                self.build_time = start_time as f64 + total_time as f64;
            }
            PacketType::ClientTroopData(army) => {
                self.army = army;
            }
            PacketType::ClientRoleInfo { skirmishes, .. } => {
                self.skirmish = skirmishes;
            }
            PacketType::ClientResources(resources) => {
                for (i, (amount, production_rate)) in resources.iter().enumerate() {
                    self.resources[i] = (*amount as f64, *production_rate)
                }
            }
            PacketType::ClientHeroes(heroes) => {
                self.heroes = heroes;
            }
            PacketType::ClientSkirmishCombatEnd {
                result,
                army,
                injured,
                food_now,
                food_speed_in_hour,
                ..
            } => {
                if result {
                    // connection.send_packet(PacketType::ServerMissionComplete(skirmish_quest_id(self.skirmish), None), true)?;
                    self.skirmish += 1;
                }
                self.army = army;
                self.injured = injured;
                self.resources[0] = (food_now as f64, food_speed_in_hour);
                if self.skirmish < 3
                    && self
                        .army
                        .iter()
                        .flatten()
                        .copied()
                        .reduce(|n1, n2| n1 + n2)
                        .unwrap()
                        > 50
                {
                    self.start_skirmish(connection)?;
                }
            }
            PacketType::ClientSkirmishCombatEndNoResult => {
                if self.skirmish < 3
                    && self
                        .army
                        .iter()
                        .flatten()
                        .copied()
                        .reduce(|n1, n2| n1 + n2)
                        .unwrap()
                        > 50
                {
                    return Ok(HandleStatus::Reconnect);
                }
            }
            PacketType::ClientItemInfo { state, items } => {
                let mut _end = false;
                match state {
                    EMsgState::Null => (),
                    EMsgState::Begin => self.items.clear(),
                    EMsgState::End => _end = true,
                    EMsgState::BeginAndEnd => {
                        self.items.clear();
                        _end = true
                    }
                }
                self.items.extend(items);
            }
            PacketType::ClientTimerMissionInfo { num, missions } => {
                self.timer_missions[num as usize] = missions;
                for (i, mission) in self.timer_missions[num as usize]
                    .missions
                    .iter()
                    .enumerate()
                {
                    if mission.state == TimerMissionState::Countdown {
                        self.timer_missions[num as usize].now = Some(i);
                    }
                }
            }
            PacketType::ClientTimerMissionUpdate => {
                if self.timer_missions[0].reset_time < 0.0 {
                    self.timer_missions[0].reset_time = self.server_time + 2.0;
                } else {
                    self.timer_missions[1].reset_time = self.server_time + 2.0;
                }
            }
            PacketType::ClientTimerMissionStart(r#type, index, time) => {
                if r#type < self.timer_missions.len() as u8 {
                    self.timer_missions[r#type as usize].now = Some(index);
                    self.timer_missions[r#type as usize].mission_time = time as f64;
                    self.timer_missions[r#type as usize].missions[index].state =
                        TimerMissionState::Countdown;
                }
            }
            PacketType::ClientTimerMissionFinish(r#type, index) => {
                if r#type < self.timer_missions.len() as u8 {
                    self.timer_missions[r#type as usize].now = None;
                    self.timer_missions[r#type as usize].missions[index].state =
                        TimerMissionState::Complete;
                }
            }
            PacketType::ClientResourceUpdate(resource_type, (resources, speed)) => {
                self.resources[resource_type as usize] = (resources as f64, speed);
            }
            PacketType::ClientChatMessage { messages, .. } => {
                for message in messages {
                    if let Some(text) = message.original_text {
                        match &text[..] {
                            "+старт1м" => {
                                self.hands = SystemTime::now() + Duration::from_secs(1 * 60);
                            }
                            "+старт5м" => {
                                self.hands = SystemTime::now() + Duration::from_secs(5 * 60);
                            }
                            "+старт10м" => {
                                self.hands = SystemTime::now() + Duration::from_secs(10 * 60);
                            }
                            "+стоп" => {
                                self.hands = SystemTime::now();
                            }
                            _ => (),
                        }
                    }
                }
            }
            _ => (),
        }
        Ok(HandleStatus::Ok)
    }
    async fn tick(&mut self, connection: &mut Connection, delta: Duration) -> anyhow::Result<()> {
        let secs = delta.as_secs_f64();
        self.server_time += secs;
        if self.beat_time > 0.0 && self.beat_time - secs <= 0.0 {
            self.heartbeat(connection)?;
        }
        self.beat_time -= secs;
        if self.initialization_finished {
            if self.build_time <= self.server_time && !self.building {
                self.update_progress();
                self.build_next(connection)?;
            } else if self.build_time < self.server_time + 7.0 * 60.0 && self.building {
                connection.send_packet(PacketType::ServerBuildFree, true)?;
                self.build_time += 7.0 * 60.0 + 5.0;
            }

            for (item, amount) in &self.items {
                if item_ids::RESOURCE_ITEMS.contains(item) {
                    connection
                        .send_packet(PacketType::ServerUseSimpleItem(*item, *amount), true)?;
                }
            }
            self.items
                .retain(|item, _| !item_ids::RESOURCE_ITEMS.contains(item));

            for (i, missions) in self.timer_missions.iter_mut().enumerate() {
                if missions.missions.is_empty() {
                    continue;
                }
                if missions.now.is_none() {
                    if let Some(mission) = missions
                        .missions
                        .iter_mut()
                        .find(|mission| mission.state == TimerMissionState::Reward)
                    {
                        connection.send_packet(
                            PacketType::ServerTimerMissionGetReward(i as u8, mission.index),
                            true,
                        )?;
                        mission.state = TimerMissionState::CompleteWaitingConfirmation;
                    }
                    if let Some(mission) = missions.missions.iter().find(|mission| {
                        mission.state == TimerMissionState::Wait
                            || mission.state == TimerMissionState::AutoComplete
                    }) {
                        if !missions.missions.iter().any(|mission| {
                            mission.state == TimerMissionState::CompleteWaitingConfirmation
                        }) {
                            connection.send_packet(
                                PacketType::ServerTimerMissionStart(i as u8, mission.index),
                                true,
                            )?;
                            missions.now = Some(usize::MAX);
                        }
                    }
                } else if missions.now.unwrap() != usize::MAX
                    && missions.mission_time <= self.server_time
                {
                    connection.send_packet(
                        PacketType::ServerTimerMissionGetReward(i as u8, missions.now.unwrap()),
                        true,
                    )?;
                    missions.missions[missions.now.unwrap()].state =
                        TimerMissionState::CompleteWaitingConfirmation;
                    missions.now = Some(usize::MAX);
                }
            }
        }
        for (resource, production_rate) in self.resources.iter_mut() {
            *resource = (*resource + *production_rate as f64 / 60.0 / 60.0 * secs).max(0.0);
        }
        Ok(())
    }

    async fn start(connection: Connection, _: &Self::Config) -> anyhow::Result<HandleStatus> {
        let igg_id = connection.igg_id;
        connection.run_loop(AutoManualHandsBot::new(igg_id)).await
    }
}

impl AutoManualHandsBot {
    pub fn new(igg_id: i64) -> Self {
        AutoManualHandsBot {
            beat_time: 0.0,
            server_time: -1.0,
            igg_id,
            build_time: f64::MAX,
            progress: None,
            buildings: HashMap::new(),
            initialization_finished: false,
            building: false,
            army: [[0; 4]; 5],
            injured: [[0; 4]; 5],
            skirmish: 0,
            resources: [(0.0, 0); 5],
            heroes: Vec::new(),
            items: HashMap::new(),
            timer_missions: [
                TimerMissions {
                    reset_time: -1.0,
                    mission_time: -1.0,
                    missions: Vec::new(),
                    now: None,
                },
                TimerMissions {
                    reset_time: -1.0,
                    mission_time: -1.0,
                    missions: Vec::new(),
                    now: None,
                },
            ],
            hands: SystemTime::now(),
        }
    }

    pub fn heartbeat(&mut self, connection: &mut Connection) -> anyhow::Result<()> {
        self.make_beat(15.0);
        connection.send_packet(PacketType::ServerHeartBeat, true)?;
        //println!("{} > {}", self.igg_id, self.build_time - self.server_time);
        Ok(())
    }

    pub fn make_beat(&mut self, time: f64) {
        self.beat_time = time;
    }

    fn build_next(&mut self, connection: &mut Connection) -> anyhow::Result<()> {
        if let Some(progress) = self.progress {
            if let Some((manor_id, build_id)) = BUILD_PRIORITY.get(progress) {
                connection.send_packet(
                    PacketType::ServerBuildBegin {
                        manor_id: *manor_id,
                        build_id: *build_id,
                    },
                    true,
                )?;
                self.build_time = f64::MAX;
            }
        }
        Ok(())
    }

    fn update_progress(&mut self) {
        let mut buildings_at_step = HashMap::<u16, u8>::new();
        buildings_at_step.insert(manor_ids::CASTLE, 2);
        buildings_at_step.insert(manor_ids::WALL, 1);
        buildings_at_step.insert(manor_ids::WATCHTOWER, 1);
        buildings_at_step.insert(manor_ids::VAULT, 1);
        buildings_at_step.insert(manor_ids::BARRACKS_1, 1);
        buildings_at_step.insert(manor_ids::INFIRMARY_1, 1);
        for (i, (manor_id, _)) in BUILD_PRIORITY.iter().enumerate() {
            if buildings_at_step.contains_key(manor_id) {
                *buildings_at_step.get_mut(manor_id).unwrap() += 1;
            } else {
                buildings_at_step.insert(*manor_id, 1);
            }
            if !self.buildings.contains_key(manor_id)
                || buildings_at_step[manor_id] > self.buildings[manor_id]
            {
                self.progress = Some(i);
                return;
            }
        }
    }

    fn start_skirmish(&self, connection: &mut Connection) -> anyhow::Result<()> {
        connection.send_packet(
            PacketType::ServerSendTroopsSkirmish {
                heroes: {
                    let mut heroes = [0; 5];
                    heroes[0] = self.heroes.first().map(|hero| hero.id).unwrap_or(0);
                    heroes
                },
                troops: self.army,
            },
            true,
        )?;
        Ok(())
    }
}

#[allow(unused)]
fn build_quest_id(build_id: u16, level: u8) -> u16 {
    build_id + level as u16 * 0x19
}

#[allow(unused)]
fn skirmish_quest_id(num: u8) -> u16 {
    0x03e9 + num as u16
}
