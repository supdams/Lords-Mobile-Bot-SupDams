use std::collections::HashMap;
use std::io::{Cursor, Read, Write};

use anyhow::anyhow;

use crate::connection::Connection;
use crate::packet::{ByteBufRead, ByteBufWrite};
use crate::point::Point;

const PATCH_VERSION: i32 = 0x00a3;

#[allow(unused)]
#[derive(Debug)]
pub enum PacketType {
    ServerGuestLogIn {
        igg_id: i64,
        ass_key: String,
    },
    ClientGuestLogIn {
        ip: String,
        igg_id: i64,
        port: u16,
    },
    ServerLogIn {
        igg_id: i64,
        battle_is_oul: bool,
        b_recv_kingdom: u8,
        ass_key: String,
        inviter_igg_id: i64,
        inviter_name: String,
    },
    ClientServerTime {
        server_time: i64,
    },
    ServerInitOver {
        igg_id: i64,
    },
    ClientSomebodyNeedsHelp {
        help: HelpRequest,
    },
    ClientNeedHelp {
        do_not_update_ui: bool,
        helps: Vec<HelpRequest>,
    },
    ServerSendHelp {
        record_sns: Vec<u32>,
    },
    ServerGetGifts,
    ClientHeroes(Vec<HeroData>),
    ClientItemInfo {
        state: EMsgState,
        items: HashMap<u16, u16>,
    },
    ClientMobilizationMissionGet {
        num: u8,
        mission_id: Option<u16>,
        mission_difficulty: Option<u8>,
        available_mission: Option<u8>,
        mission_status: Option<u8>,
        mission_time: Option<i64>,
        mission_target: Option<u32>,
        mission_start: Option<i64>,
    },
    ClientMissionFlag {
        bool_mark: Vec<u8>,
    },
    ServerViewChat {
        channel: u8,
        prev: u8,
        kind: i8,
        data_id: Option<i64>,
        data_time: Option<i64>,
    },
    ClientChatMessage {
        num2: u8,
        num3: u8,
        messages: Vec<ChatMessage>,
    },
    ServerHeartBeat,
    ServerLoadEquip {
        last_update_time: i64,
    },
    ClientSocialData {
        social_name: String,
        invited: u8,
        inviter_social_name: String,
        max_concurrent_friend: u8,
        friends: Vec<SocialFriend>,
    },
    ServerItemMat {
        last_update_time: i64,
    },
    ServerItemGem {
        last_update_time: i64,
    },
    ClientInitOpenKingdomInfo {
        kingdom_open_flag: Vec<u8>,
    },
    ServerSendChat {
        channel: u8,
        message: String,
    },
    ClientBroadcastDarkNest {
        data_index: i64,
        level: u8,
        player_name: String,
    },
    ClientRally {
        index: u32,
        kind: u8,
        begin_time: i64,
        require_time: u32,
        ally_zone_id: u16,
        ally_point_id: u8,
        ally_head: u16,
        ally_name: String,
        ally_vip: u8,
        ally_rank: u8,
        ally_curr_troop: u32,
        ally_max_troop: u32,
        ally_home_kingdom: u16,
        enemy_head: u16,
        enemy_zone_id: u16,
        enemy_point_id: u8,
        enemy_vip: u8,
        enemy_npc_id: u16,
    },
    ServerGetRallies,
    ServerGetRallyDetails {
        index: u32,
    },
    ClientRallyDetails {
        kind: u8,
        begin_time: i64,
        require_time: u32,
        ally_zone_id: u16,
        ally_point_id: u8,
        ally_head: u16,
        ally_name: String,
        ally_vip: u8,
        ally_rank: u8,
        ally_max_troop: u32,
        enemy_head: u16,
        enemy_zone_id: u16,
        enemy_point_id: u8,
        enemy_vip: u8,
        enemy_npc_id: u16,
        rec_num: u8,
        self_participate: u8,
        ally_home_kingdom: u16,
    },
    ClientRallyTroops {
        num1: u32,
        ally_name: String,
        ally_vip: u8,
        ally_rank: u8,
        begin_time: i64,
        require_time: u32,
        troops_total: u32,
        troops: [[u32; 4]; 5],
    },
    ClientLoginAgain,
    ServerBuildBegin {
        manor_id: u16,
        build_id: u16,
    },
    ServerBuildFree,
    ServerBuildCancel,
    ServerNeedHelp(HelpKind),
    ClientAllianceData(AllianceAttr),
    ServerApplyList,
    ClientApplyList(u8, u8, Vec<Applicant>),
    ClientGiftInfo {
        clear: bool,
        update_ui: bool,
        gifts: Vec<AllianceGift>,
    },
    ServerOpenGift(u32),
    ClientGiftOpened(u8, Option<AllianceGift>),
    ClientBuildingInfo(Vec<BuildingInfo>),
    ClientBuildingQueue {
        queue_build_type: u8,
        manor_id: u16,
        build_id: u16,
        num: u8,
        start_time: i64,
        total_time: u32,
    },
    ClientBuildingError(u8),
    ClientBuildBegin {
        manor_id: u16,
        build_id: u16,
        num: u8,
        start_time: i64,
        total_time: u32,
        food: u32,
        stone: u32,
        timber: u32,
        ore: u32,
        gold: u32,
        removed_special_items: Vec<(u16, u16)>,
    },
    ClientBuildComplete {
        manor_id: u16,
        build_id: u16,
        level: u8,
    },
    ClientBuildCancel {
        food: u32,
        stone: u32,
        wood: u32,
        ore: u32,
        gold: u32,
        added_special_items: Vec<(u16, u16)>,
    },
    ServerSendTroopsSkirmish {
        heroes: [u16; 5],
        troops: [[u32; 4]; 5],
    },
    ServerSendTroopsMap {
        heroes: [u16; 5],
        troops: [[u32; 4]; 5],
        x: u16,
        y: u8,
    },
    ServerSendTroopsReinforce {
        zone_id: u16,
        point_id: u8,
        heroes: [u16; 5],
        troops: [[u32; 4]; 5],
    },
    ServerUpdateNewbieLog(u16),
    ServerPassNewbie,
    ServerRename {
        bought: bool,
        num: u16,
        name: String,
    },
    ServerNewbieTeleport {
        kingdom_id: u16,
        point: Point,
    },
    ServerAllianceApply(String),
    ClientRename {
        num: u8,
        item: Option<u16>,
        amount_after_rename: Option<u16>,
        name: Option<String>,
        role_attr_diamond: Option<u32>,
    },
    ClientUseTeleport {
        item_id: u16,
        amount_after_use: u16,
        zone_id: u16,
        point_id: u8,
        kingdom_id: u16,
    },
    ClientTroopData([[u32; 4]; 5]),
    ClientInjuredData([[u32; 4]; 5]),
    ClientSkirmishCombatEnd {
        result: bool,
        rnd_seed: u16,
        rnd_gap: u8,
        army: [[u32; 4]; 5],
        injured: [[u32; 4]; 5],
        food_now: u32,
        food_speed_in_hour: i64,
        stage_record: u8,
        soldiers_now: [(u8, u32); 10],
        wall_now: u32,
        morale_winner: u8,
        eliminate: u8,
        wall_down: u8,
        assault_lost_force: u32,
        defence_lost_force: u32,
        role_attr_level: u8,
        role_attr_exp: u32,
        role_attr_morale: u16,
        role_attr_last_morale_recover_time: i64,
        role_attr_talent_points: u16,
        #[allow(clippy::type_complexity)]
        heroes: [(u16, (u8, u32, [u8; 4])); 5],
    },
    ClientRoleInfo {
        pack_num: i32,                    // 0
        user_id: i64,                     // 4
        name: String,                     // 12
        head: u16,                        // 25
        guide: u32,                       // what is it?, SKIP 27-62
        diamonds: u32,                    // 62
        player_level: u8,                 // 66
        last_hero_sp_recover_time: i64,   // 67
        enhance_event_hero_id: u16,       // 75
        hero_enhance_begin_time: i64,     // 77
        hero_enhance_require_time: u32,   // 85
        stage_info: ([u8; 12], [u8; 48]), // 89
        reflash_stage_record_info: u16,   // 149
        stage_record: u16,                // 151
        battle_id: u64,                   // 153
        // SKIP 161-175
        new_zone_id: u16,                        // 175
        new_point_id: u8,                        // 179
        last_chatter_time: u64,                  // 180
        alliance_chat_id: u32,                   // 188
        power: u64,                              // 192
        kills: u64,                              // 200
        vip_point: u32,                          // 208
        date_registered: i64,                    // 212
        prize_flag: u32,                         // 220
        bookmark_time: i64,                      // 204, what is it?
        bookmark_limit: u16,                     // 212
        bookmark_num: u16,                       // 214
        skirmishes: u8,                          // 234
        next_skirmish_soldiers: [(u8, u32); 10], // 216, how?
        next_skirmish_wall: u32,                 // 256
        successful_login_days: u16,              // 260
        use_morale_items_today: u8,              // 289
        equip_bag_size: u8,
        next_online_gift_open_time: i64,
        online_gift_open_times: u8,
        online_gift_item_id: u16,
        online_gift_item_quantity: u16,
        last_lord_equip_update_time: i64,
        last_item_mat_update_time: i64,
        last_item_gem_update_time: i64,
        equip_event_item_id: u16,
        equip_event_item_color: u8,
        equip_event_gem_color: [u8; 4],
        equip_event_gem: [u16; 4],
        equip_serial_no: u32,
        equip_begin_time: i64,
        equip_require_time: u32,
        vip_level_up: u8,
        my_kingdom: (u16, u16),
        monster_point: u32,
        last_energy_recover_time: i64,
        energy_recovers_in_hour: u16,
        set_notice: u16,
        tpp_point: u32,
        paid_crystal: u32,
        buy_month_treasure_time: i64,
        last_month_treasure_prize_time: i64,
        nickname: String,
        num5: u8,
        kingdom_title: u16,
        now_army_coord_index: u8,
        army_coord_flag: u32,
        mobilization_get_prize: u8,
        world_title_personal: u16,
        world_title_country: u16,
        daily_free_scard_star: u8,
        scard_star: u32,
        stage_record_3: u16,
        stage_record_3_part: [u8; 18],
        new_push_switch: u64,
        nobility_title: u16,
        guide_flag_bitwise_or_bitwise_right_32: u32,
        guide_ex: u32,
        pet_skill_fatigue: u16,
        join_time: i64,
        back_reward_combo_box_id: u16,
    },
    ClientResources([(u32, i64); 5]),
    ClientSkirmishCombatEndNoResult,
    ServerUseSimpleItem(u16, u16),
    ClientTimerMissionUpdate,
    ClientTimerMissionInfo {
        num: u8,
        missions: TimerMissions,
    },
    ServerTimerMissionStart(u8, usize),
    ServerTimerMissionGetReward(u8, usize),
    ClientTimerMissionStart(u8, usize, i64),
    ClientTimerMissionFinish(u8, usize),
    ClientResourceUpdate(u8, (u32, i64)),
    ServerMissionComplete(u16, Option<u16>),
    ClientMissionComplete {
        quest_id: u16,
        exp_now: u32,
        power_now: u64,
        now_level: u8,
        morale: u16,
        last_morale_recover_time: i64,
        talent_point: u16,
        resources: [u32; 5],
        items: HashMap<u16, u16>,
    },
    ClientMissionMark(Vec<u16>),
    ServerDealApplication(bool, i64),
    ClientDealApplication(u8, u32, bool, i64),
    ServerGiveLeadership(i64),
    ClientGiveLeadershipResponse(u8),
}

impl PacketType {
    pub fn serialize(&self, connection: &mut Connection) -> anyhow::Result<Vec<u8>> {
        let mut packet = Vec::new();
        match self {
            PacketType::ServerGuestLogIn { igg_id, ass_key } => {
                const CLIENT_VERSION: [i32; 3] = [0x4d, 0x02, PATCH_VERSION];
                const SESSION_KEY: [u8; 512] = [0; 512];
                const DEVICE_UUID: &str = "a658b2df-1f99-4f71-8cbd-b355185a9788";
                const RUSSIAN_LANGUAGE_CODE: u8 = 6;
                packet.write_u16(0x0413)?;
                packet.write_i64(*igg_id)?;
                packet.write_u8(CLIENT_VERSION[0] as u8)?;
                packet.write_u8(CLIENT_VERSION[1] as u8)?;
                packet.write_i16(CLIENT_VERSION[2] as i16)?;
                packet.write_u8(1)?;
                packet.write_u8(RUSSIAN_LANGUAGE_CODE)?;
                packet.write_string(DEVICE_UUID, 50)?;
                packet.write_u16(ass_key.len() as u16)?;
                packet.write_string(ass_key, SESSION_KEY.len())?;
            }
            PacketType::ServerLogIn {
                igg_id,
                battle_is_oul,
                b_recv_kingdom,
                ass_key,
                inviter_igg_id,
                inviter_name,
            } => {
                const VERSION: u32 = 0x00000000;
                const SESSION_KEY: [u8; 462] = [0; 462];
                packet.write_u16(0x0414)?;
                packet.write_i64(*igg_id)?;
                packet.write_all(&[0; 50])?;
                packet.write_u32(VERSION)?;
                packet.write_bool(!*battle_is_oul)?;
                packet.write_u8(*b_recv_kingdom)?;
                packet.write_u8(ass_key.len() as u8)?;
                packet.write_u8(1)?; // ???
                packet.write_string(ass_key, SESSION_KEY.len())?;
                packet.write_i64(*inviter_igg_id)?;
                packet.write_string(inviter_name, 42)?;
            }
            PacketType::ServerInitOver { igg_id } => {
                packet.write_u16(0x03FC)?;
                packet.write_seq_id(connection)?;
                packet.write_i64(*igg_id)?;
            }
            PacketType::ServerSendHelp { record_sns } => {
                packet.write_u16(0x0b27)?;
                packet.write_seq_id(connection)?;
                packet.write_u16(record_sns.len() as u16)?;
                for record_sn in record_sns.iter() {
                    packet.write_u32(*record_sn)?;
                }
            }
            PacketType::ServerGetGifts => {
                packet.write_u16(0x0B2E)?;
                packet.write_seq_id(connection)?;
            }
            PacketType::ServerViewChat {
                channel,
                prev,
                kind,
                data_id,
                data_time,
            } => {
                packet.write_u16(0x0BBA)?;
                packet.write_seq_id(connection)?;
                packet.write_u8(*channel)?;
                packet.write_u8(*prev)?;
                packet.write_i8(*kind)?;
                if *channel != 0x00 {
                    packet
                        .write_i64(data_id.expect("If channel is 0x00, data_id must be present"))?;
                    packet.write_i64(
                        data_time.expect("If channel is 0x00, data_time must be present"),
                    )?;
                }
            }
            PacketType::ServerHeartBeat => {
                packet.write_u16(0x0400)?;
                packet.write_seq_id(connection)?;
            }
            PacketType::ServerLoadEquip { last_update_time } => {
                packet.write_u16(0x0588)?;
                packet.write_seq_id(connection)?;
                packet.write_i64(*last_update_time)?;
            }
            PacketType::ServerItemMat { last_update_time } => {
                packet.write_u16(0x0586)?;
                packet.write_seq_id(connection)?;
                packet.write_i64(*last_update_time)?;
            }
            PacketType::ServerItemGem { last_update_time } => {
                packet.write_u16(0x058a)?;
                packet.write_seq_id(connection)?;
                packet.write_i64(*last_update_time)?;
            }
            PacketType::ServerSendChat { channel, message } => {
                packet.write_u16(0x0BB9)?;
                packet.write_seq_id(connection)?;
                packet.write_u8(*channel)?;
                packet.write_u8(0)?;
                packet.write_u8(5)?;
                let bytes = message.as_bytes();
                packet.write_u16(bytes.len() as u16)?;
                packet.write_all(bytes)?;
            }
            PacketType::ServerGetRallies => {
                packet.write_u16(0x09AC)?;
                packet.write_seq_id(connection)?;
            }
            PacketType::ServerGetRallyDetails { index } => {
                packet.write_u16(0x09b0)?;
                packet.write_seq_id(connection)?;
                packet.write_u8(0)?;
                packet.write_u32(*index)?;
            }
            PacketType::ServerBuildBegin { manor_id, build_id } => {
                packet.write_u16(0x07d3)?;
                packet.write_seq_id(connection)?;
                packet.write_u16(*manor_id)?;
                packet.write_u16(*build_id)?;
            }
            PacketType::ServerBuildFree => {
                packet.write_u16(0x07d8)?;
                packet.write_seq_id(connection)?;
            }
            PacketType::ServerBuildCancel => {
                packet.write_u16(0x07d6)?;
                packet.write_seq_id(connection)?;
            }
            PacketType::ServerNeedHelp(kind) => {
                packet.write_u16(0x0B24)?;
                packet.write_seq_id(connection)?;
                packet.write_u8(unsafe { std::mem::transmute(kind.clone()) })?;
            }
            PacketType::ServerApplyList => {
                packet.write_u16(0x0B09)?;
                packet.write_seq_id(connection)?;
            }
            PacketType::ServerOpenGift(sn) => {
                packet.write_u16(0x0B30)?;
                packet.write_seq_id(connection)?;
                packet.write_u32(*sn)?;
            }
            PacketType::ServerSendTroopsSkirmish { heroes, troops } => {
                packet.write_u16(0x0711)?;
                packet.write_seq_id(connection)?;
                for hero in heroes {
                    packet.write_u16(*hero)?;
                }
                for t in troops {
                    for class in t {
                        packet.write_u32(*class)?;
                    }
                }
            }
            PacketType::ServerSendTroopsMap {
                heroes,
                troops,
                x,
                y,
            } => {
                packet.write_u16(0x096F)?;
                packet.write_seq_id(connection)?;
                for hero in heroes {
                    packet.write_u16(*hero)?;
                }
                for t in troops {
                    for class in t {
                        packet.write_u32(*class)?;
                    }
                }
                packet.write_u16(*x)?;
                packet.write_u8(*y)?;
            }
            PacketType::ServerSendTroopsReinforce {
                zone_id,
                point_id,
                heroes,
                troops,
            } => {
                packet.write_u16(0x099A)?;
                packet.write_seq_id(connection)?;
                packet.write_u16(*zone_id)?;
                packet.write_u8(*point_id)?;
                for hero in heroes {
                    packet.write_u16(*hero)?;
                }
                for t in troops {
                    for class in t {
                        packet.write_u32(*class)?;
                    }
                }
            }
            PacketType::ServerUpdateNewbieLog(stage) => {
                packet.write_u16(0x0462)?;
                packet.write_seq_id(connection)?;
                packet.write_u16(*stage)?;
            }
            PacketType::ServerPassNewbie => {
                packet.write_u16(0x045F)?;
                packet.write_seq_id(connection)?;
            }
            PacketType::ServerRename { bought, num, name } => {
                packet.write_u16(0x0450)?;
                packet.write_seq_id(connection)?;
                packet.write_bool(*bought)?;
                packet.write_u16(*num)?;
                packet.write_u16(0x03ee)?;
                packet.write_u8(name.len() as u8)?;
                packet.write_string(name, 13)?;
            }
            PacketType::ServerNewbieTeleport { kingdom_id, point } => {
                packet.write_u16(0x057e)?;
                packet.write_seq_id(connection)?;
                packet.write_u16(0x03ed)?;
                packet.write_u16(0x0001)?;
                packet.write_u16(*kingdom_id)?;
                let (zone_id, point_id) = point.as_point_code();
                packet.write_u16(zone_id)?;
                packet.write_u16(point_id as u16)?;
                packet.write_u32(0)?;
            }
            PacketType::ServerAllianceApply(tag) => {
                packet.write_u16(0x0AF9)?;
                packet.write_seq_id(connection)?;
                packet.write_u8(1)?;
                packet.write_string(tag, 3)?;
            }
            PacketType::ServerUseSimpleItem(item, amount) => {
                packet.write_u16(0x057E)?;
                packet.write_seq_id(connection)?;
                packet.write_u16(*item)?;
                packet.write_u16(*amount)?;
                packet.write_all(&[0; 10])?;
            }
            PacketType::ServerTimerMissionStart(r#type, index) => {
                packet.write_u16(0x0C29)?;
                packet.write_seq_id(connection)?;
                packet.write_u8(*r#type + 1)?;
                packet.write_u8(*index as u8 + 1)?;
            }
            PacketType::ServerTimerMissionGetReward(r#type, index) => {
                packet.write_u16(0x0C2D)?;
                packet.write_seq_id(connection)?;
                packet.write_u8(*r#type + 1)?;
                packet.write_u8(*index as u8 + 1)?;
            }
            PacketType::ServerMissionComplete(mission_id, build_id) => {
                packet.write_u16(0x0C2F)?;
                packet.write_seq_id(connection)?;
                packet.write_u16(*mission_id)?;
                if let Some(build_id) = build_id {
                    packet.write_u16(*build_id)?;
                }
            }
            PacketType::ServerDealApplication(bool, igg_id) => {
                packet.write_u16(0x0AFD)?;
                packet.write_seq_id(connection)?;
                packet.write_i8(if *bool { 1 } else { 2 })?;
                packet.write_i64(*igg_id)?;
            }
            PacketType::ServerGiveLeadership(id) => {
                packet.write_u16(0x0B0D)?;
                packet.write_seq_id(connection)?;
                packet.write_i64(*id)?;
            }
            _ => {
                unreachable!()
            }
        }
        Ok(packet)
    }
    pub fn deserialize(bytes: &[u8], igg_id: i64) -> anyhow::Result<PacketType> {
        let mut packet = Cursor::new(bytes.to_owned());
        let packet_id = packet.read_u16()?;
        match packet_id {
            0x03EB => {
                let port = packet.read_i32()? as u16;
                let igg_id = packet.read_i64()?;
                let ip = packet.read_string(16)?;
                // and 5 more bytes that appear to be unused
                Ok(PacketType::ClientGuestLogIn { port, igg_id, ip })
            }
            0x0401 => {
                let server_time = packet.read_i64()?;
                Ok(PacketType::ClientServerTime { server_time })
            }
            0x0B26 => {
                let record_sn = packet.read_u32()?;
                let head = packet.read_u16()?;
                let rank = packet.read_u8()?;
                let player_name = packet.read_string(13)?;
                let help_kind: HelpKind = unsafe { std::mem::transmute(packet.read_u8()?) };
                let event_id = packet.read_u16()?;
                let event_data_lv = packet.read_u8()?;
                let already_helped = packet.read_u8()?;
                let help_max = packet.read_u8()?;
                Ok(PacketType::ClientSomebodyNeedsHelp {
                    help: HelpRequest {
                        record_sn,
                        head,
                        rank,
                        player_name,
                        help_kind,
                        building_or_research_id: event_id,
                        level: event_data_lv,
                        already_helped,
                        help_max,
                    },
                })
            }
            0x0B23 => {
                let do_not_update_ui = packet.read_bool()?;
                let length = packet.read_u8()?;
                let mut helps = Vec::new();
                for _ in 0..length {
                    helps.push(HelpRequest {
                        record_sn: packet.read_u32()?,
                        head: packet.read_u16()?,
                        rank: packet.read_u8()?,
                        player_name: packet.read_string(13)?,
                        help_kind: unsafe { std::mem::transmute(packet.read_u8()?) },
                        building_or_research_id: packet.read_u16()?,
                        level: packet.read_u8()?,
                        already_helped: packet.read_u8()?,
                        help_max: packet.read_u8()?,
                    })
                }
                Ok(PacketType::ClientNeedHelp {
                    helps,
                    do_not_update_ui,
                })
            }
            0x04B1 => {
                let _ = packet.read_i64()?;
                let heroes_num = packet.read_i16()?;
                let mut heroes = Vec::new();
                for _ in 0..heroes_num {
                    heroes.push(HeroData {
                        id: packet.read_u16()?,
                        level: packet.read_u8()?,
                        exp: packet.read_u32()?,
                        enhance: packet.read_u8()?,
                        star: packet.read_u8()?,
                        equip: packet.read_u8()?,
                        equip_enchant: {
                            let mut arr = [0; 6];
                            packet.read_exact(&mut arr)?;
                            arr
                        },
                        skill_lv: {
                            let mut arr = [0; 4];
                            packet.read_exact(&mut arr)?;
                            arr
                        },
                    });
                }
                Ok(PacketType::ClientHeroes(heroes))
            }
            0x0579 => {
                let state = unsafe { std::mem::transmute(packet.read_u8()?) };
                let mut items = HashMap::new();
                let num = packet.read_i16()?;
                for _ in 0..num {
                    items.insert(packet.read_u16()?, packet.read_u16()?);
                }
                Ok(PacketType::ClientItemInfo { state, items })
            }
            0x0E36 => {
                let num = packet.read_u8()?;
                Ok(match num {
                    0 => PacketType::ClientMobilizationMissionGet {
                        num,
                        mission_id: Some(packet.read_u16()?),
                        mission_difficulty: Some(packet.read_u8()?.clamp(0, 3)),
                        available_mission: Some(packet.read_u8()?),
                        mission_status: Some(0),
                        mission_time: Some(packet.read_i64()?),
                        mission_target: Some(packet.read_u32()?),
                        mission_start: None,
                    },
                    u8::MAX => PacketType::ClientMobilizationMissionGet {
                        num,
                        mission_id: Some(packet.read_u16()?),
                        mission_difficulty: Some(packet.read_u8()?.clamp(0, 3)),
                        available_mission: Some(packet.read_u8()?),
                        mission_status: None,
                        mission_time: Some(packet.read_i64()?),
                        mission_target: Some(packet.read_u32()?),
                        mission_start: Some(packet.read_i64()?),
                    },
                    _ => PacketType::ClientMobilizationMissionGet {
                        num,
                        mission_id: None,
                        mission_difficulty: None,
                        available_mission: None,
                        mission_status: None,
                        mission_time: None,
                        mission_target: None,
                        mission_start: None,
                    },
                })
            }
            0x0C31 => {
                let n = packet.read_u16()?;
                let mut bool_mark = vec![0; n as usize];
                packet.read_exact(&mut bool_mark)?;
                Ok(PacketType::ClientMissionFlag { bool_mark })
            }
            0x20DC => {
                let social_name = packet.read_string(41)?;
                let invited = packet.read_u8()?;
                let inviter_social_name = packet.read_string(41)?;
                // TODO max_concurrent_friend goes here
                let n = packet.read_u8()?;
                let mut friends = Vec::new();
                for _ in 0..n {
                    friends.push(SocialFriend {
                        num: packet.read_u8()?,
                        social_name: packet.read_string(41)?,
                        icon_no: packet.read_u8()?,
                    });
                }
                Ok(PacketType::ClientSocialData {
                    social_name,
                    invited,
                    inviter_social_name,
                    max_concurrent_friend: 0,
                    friends,
                })
            }
            0x08a9 => {
                let mut data_buffer = [0; 32];
                packet.read_exact(&mut data_buffer)?;
                let mut msg_buffer = [0; 32];
                for i in 0..38 - msg_buffer.len() {
                    msg_buffer[i] = packet.read_u8()?;
                }
                let num1 = packet.read_u8()?.min(38);
                let mut kingdom_open_flag = vec![0; num1 as usize];
                kingdom_open_flag[..data_buffer.len()].clone_from_slice(&data_buffer[..]);
                for len in data_buffer.len()..38 {
                    kingdom_open_flag[len] = msg_buffer[len - data_buffer.len()];
                }
                packet.read_exact(&mut kingdom_open_flag[38..])?;
                Ok(PacketType::ClientInitOpenKingdomInfo { kingdom_open_flag })
            }
            0x0BBB => {
                let num2 = packet.read_u8()?;
                let num3 = packet.read_u8()?;
                match num2 {
                    0 | 1 => {
                        let mut messages = Vec::new();
                        let num4 = packet.read_u16()?;
                        for _ in 0..num4 {
                            let num5 = packet.read_i64()?;
                            let num6 = packet.read_i64()?;
                            let num7 = packet.read_i64()?;
                            let alli_or_king = packet.read_u8()?;
                            let num8 = packet.read_u8()?;
                            let pic_id = packet.read_u16()?;
                            let player_name = packet.read_string(13)?;
                            let vip_rank = packet.read_u8()?;
                            let title_name = packet.read_string(3)?;
                            let special_block_id = packet.read_u8()?;
                            let title_id = packet.read_u8()?;
                            let b_have_arabic = packet.read_u8()?;
                            let num9 = packet.read_u16()?;
                            let mut message = ChatMessage {
                                num5,
                                num6,
                                num7,
                                alli_or_king,
                                num8,
                                pic_id,
                                player_name,
                                vip_rank,
                                title_name,
                                special_block_id,
                                title_id,
                                b_have_arabic,
                                num9,
                                talk_kind: 0,
                                kingdom_id: None,
                                str1: None,
                                str2: None,
                                emoji_key: None,
                                num10: None,
                                original_text: None,
                            };
                            if num8 == 108 {
                                message.talk_kind = 3;
                                message.kingdom_id = Some(packet.read_u16()?);
                                message.str1 = Some(packet.read_string(3)?);
                                message.str2 = Some(packet.read_string(13)?);
                            } else if num8 == 109 {
                                message.talk_kind = 0;
                                message.emoji_key = Some(packet.read_u16()?);
                                message.num10 = Some(packet.read_u16()?);
                            } else if num8 == 0 {
                                message.original_text = Some(packet.read_string(num9 as usize)?);
                            }
                            messages.push(message);
                        }
                        Ok(PacketType::ClientChatMessage {
                            num2,
                            num3,
                            messages,
                        })
                    }
                    _ => Err(anyhow!("Something unexpected in chat")),
                }
            }
            0x1C90 => {
                let data_index = packet.read_i64()?;
                let level = packet.read_u8()?;
                let player_name = packet.read_string(13)?;
                Ok(PacketType::ClientBroadcastDarkNest {
                    data_index,
                    level,
                    player_name,
                })
            }
            0x1C93 => {
                let index = packet.read_u32()?;
                let kind = packet.read_u8()?;
                let begin_time = packet.read_i64()?;
                let require_time = packet.read_u32()?;
                let ally_zone_id = packet.read_u16()?;
                let ally_point_id = packet.read_u8()?;
                let ally_head = packet.read_u16()?;
                let ally_name = packet.read_string(13)?;
                let ally_vip = packet.read_u8()?;
                let ally_rank = packet.read_u8()?;
                let ally_curr_troop = packet.read_u32()?;
                let ally_max_troop = packet.read_u32()?;
                let ally_home_kingdom = packet.read_u16()?;
                let enemy_head = u8::MAX as u16;
                let enemy_zone_id = packet.read_u16()?;
                let enemy_point_id = packet.read_u8()?;
                let enemy_vip = packet.read_u8()?;
                let enemy_npc_id = packet.read_u16()?;
                Ok(PacketType::ClientRally {
                    index,
                    kind,
                    begin_time,
                    require_time,
                    ally_zone_id,
                    ally_point_id,
                    ally_head,
                    ally_name,
                    ally_vip,
                    ally_rank,
                    ally_curr_troop,
                    ally_max_troop,
                    ally_home_kingdom,
                    enemy_head,
                    enemy_zone_id,
                    enemy_point_id,
                    enemy_vip,
                    enemy_npc_id,
                })
            }
            0x1C94 => {
                let kind = packet.read_u8()?;
                let begin_time = packet.read_i64()?;
                let require_time = packet.read_u32()?;
                let ally_zone_id = packet.read_u16()?;
                let ally_point_id = packet.read_u8()?;
                let ally_head = packet.read_u16()?;
                let ally_name = packet.read_string(13)?;
                let ally_vip = packet.read_u8()?;
                let ally_rank = packet.read_u8()?;
                let ally_max_troop = packet.read_u32()?;
                let enemy_head = u8::MAX as u16;
                let enemy_zone_id = packet.read_u16()?;
                let enemy_point_id = packet.read_u8()?;
                let enemy_vip = packet.read_u8()?;
                let enemy_npc_id = packet.read_u16()?;
                let rec_num = packet.read_u8()?;
                let self_participate = packet.read_u8()?;
                let ally_home_kingdom = packet.read_u16()?;
                Ok(PacketType::ClientRallyDetails {
                    kind,
                    begin_time,
                    require_time,
                    ally_zone_id,
                    ally_point_id,
                    ally_head,
                    ally_name,
                    ally_vip,
                    ally_rank,
                    ally_max_troop,
                    enemy_head,
                    enemy_zone_id,
                    enemy_point_id,
                    enemy_vip,
                    enemy_npc_id,
                    rec_num,
                    self_participate,
                    ally_home_kingdom,
                })
            }
            0x09B3 => {
                let num1 = packet.read_u32()?;
                let ally_name = packet.read_string(13)?;
                let ally_vip = packet.read_u8()?;
                let ally_rank = packet.read_u8()?;
                let begin_time = packet.read_i64()?;
                let require_time = packet.read_u32()?;
                let troop_flag = packet.read_u32()?;
                let mut troops_total = 0;
                let mut troops = [[0; 4]; 5];
                for index in 0..16 {
                    if (troop_flag >> index & 1) == 1 {
                        troops[index >> 2][index & 3] = packet.read_u32()?;
                        troops_total += troops[index >> 2][index & 3];
                    } else {
                        troops[index >> 2][index & 3] = 0;
                    }
                }
                Ok(PacketType::ClientRallyTroops {
                    num1,
                    ally_name,
                    ally_vip,
                    ally_rank,
                    begin_time,
                    require_time,
                    troops_total,
                    troops,
                })
            }
            0x03F2 => Ok(PacketType::ClientLoginAgain),
            0x0B2B => {
                use AllianceAttr::*;
                Ok(PacketType::ClientAllianceData(match packet.read_u8()? {
                    1 => Leader(packet.read_string(13)?),
                    2 => Power(packet.read_t()?),
                    3 => Tag(packet.read_string(3)?),
                    4 => Name(packet.read_string(20)?),
                    5 => Header(packet.read_string(20)?),
                    6 => Bullet(packet.read_string(900)?, packet.read_t()?),
                    7 => Emblem(packet.read_t()?),
                    8 => MemberAndPower(packet.read_t()?, packet.read_t()?),
                    9 => Approval(packet.read_t()?),
                    10 => Applicant(packet.read_t()?),
                    11 => Language(packet.read_t()?),
                    12 => Rank(packet.read_t()?),
                    13 => Money(packet.read_t()?),
                    14 => UpdateAlreadyHelped(packet.read_t()?, packet.read_t()?),
                    15 => HelpedMe {
                        player_name: packet.read_string(13)?,
                        kind: unsafe { std::mem::transmute(packet.read_u8()?) },
                        already_helped: packet.read_t()?,
                        start_time: packet.read_t()?,
                        total_time: packet.read_t()?,
                    },
                    16 => HelpRequested(
                        unsafe { std::mem::transmute(packet.read_u8()?) },
                        packet.read_t()?,
                    ),
                    17 => HelpRemove(packet.read_t()?),
                    18 => GiftCount(packet.read_t()?, packet.read_t()?),
                    19 => AllianceBox1 {
                        gift: AllianceGift {
                            sn: packet.read_t()?,
                            status: packet.read_t()?,
                            rcv_time: packet.read_t()?,
                            box_item_id: packet.read_t()?,
                            item_id: packet.read_t()?,
                            num: packet.read_t()?,
                            item_rank: packet.read_t()?,
                            diamond: None,
                            money: None,
                            player: Some(packet.read_string(13)?),
                        },
                        gift_update_sn: packet.read_t()?,
                    },
                    20 => AllianceBox2 {
                        gift: AllianceGift {
                            sn: packet.read_t()?,
                            status: packet.read_t()?,
                            rcv_time: packet.read_t()?,
                            box_item_id: packet.read_t()?,
                            item_id: packet.read_t()?,
                            num: packet.read_t()?,
                            item_rank: packet.read_t()?,
                            diamond: None,
                            money: None,
                            player: Some(packet.read_string(13)?),
                        },
                        key: packet.read_t()?,
                    },
                    21 => PackPoint(packet.read_t()?),
                    22 => GiftExp(packet.read_t()?),
                    23 => ChatMax(packet.read_t()?),
                    24 => Wonder1 {
                        kingdom_id: packet.read_t()?,
                        wonder_id: packet.read_t()?,
                        open_state: packet.read_t()?,
                        begin_time: packet.read_t()?,
                        require_time: packet.read_t()?,
                    },
                    25 => Wonder2 {
                        kingdom_id: packet.read_t()?,
                        wonder_id: packet.read_t()?,
                        open_state: packet.read_t()?,
                        begin_time: packet.read_t()?,
                        require_time: packet.read_t()?,
                    },
                    26 => Wonder3 {
                        kingdom_id: packet.read_t()?,
                        wonder_id: packet.read_t()?,
                    },
                    27 => GiftNum(packet.read_t()?, packet.read_t()?),
                    28 => MobilizationMission {
                        id: packet.read_t()?,
                        mission_type: packet.read_t()?,
                        difficulty: packet.read_t()?,
                    },
                    29 => MobilizationMissionTime {
                        id: packet.read_t()?,
                        time: packet.read_t()?,
                    },
                    30 => MobilizationInvolvedMember(packet.read_t()?),
                    31 => MobilizationAMScore(packet.read_t()?),
                    32 => Kingdom(packet.read_t()?),
                    34 => AMRank(packet.read_t()?),
                    35 => SummonScore(packet.read_t()?),
                    36 => SummonPoint(packet.read_t()?),
                    37 => {
                        SummonCombatAndScore(packet.read_t()?, packet.read_t()?, packet.read_t()?)
                    }
                    38 => SummonData {
                        num: packet.read_t()?,
                        gift_id: packet.read_t()?,
                        monster_id: packet.read_t()?,
                        cost_point: packet.read_t()?,
                    },
                    39 => SummonMonsterData {
                        kingdom_id: packet.read_t()?,
                        zone_id: packet.read_t()?,
                        point_id: packet.read_t()?,
                        end_time: packet.read_t()?,
                    },
                    40 => MonsterKilledHUDMessage(packet.read_string(13)?, packet.read_t()?),
                    41 => AllianceWarRegister(packet.read_t()?),
                    42 => AllianceWarState {
                        rank: packet.read_t()?,
                        member_count: packet.read_t()?,
                    },
                    43 => HelpUpdate {
                        id: packet.read_t()?,
                        start_time: packet.read_t()?,
                        total_time: packet.read_t()?,
                    },
                    44 => BookmarkTime(packet.read_t()?),
                    45 => FastivalSomething1(
                        packet.read_t()?,
                        packet.read_t()?,
                        packet.read_string(13)?,
                    ),
                    46 => FastivalSomething2(packet.read_t()?, packet.read_t()?),
                    47 => LeaderRedPocketResetTime(packet.read_t()?),
                    48 => UpdateGiftCount(packet.read_t()?, packet.read_t()?),
                    49 => ActivityGiftInfo {
                        begin_time: packet.read_t()?,
                        end_time: packet.read_t()?,
                        group_id: packet.read_t()?,
                        leader_red_pocket_reset_time: packet.read_t()?,
                    },
                    _ => return Err(anyhow!("Unexpected packet")),
                }))
            }
            0x0B0A => {
                let num1 = packet.read_u8()?;
                let num2 = packet.read_u8()?;
                let num3 = packet.read_u8()?;
                let mut applicants = Vec::new();
                for _ in 0..num3 {
                    applicants.push(Applicant {
                        user_id: packet.read_t()?,
                        head: packet.read_t()?,
                        name: packet.read_string(13)?,
                        rank: packet.read_t()?,
                        power: packet.read_t()?,
                        kills: packet.read_t()?,
                    })
                }
                Ok(PacketType::ClientApplyList(num1, num2, applicants))
            }
            0x0B2F => {
                let flag_field = packet.read_u8()?;
                Ok(PacketType::ClientGiftInfo {
                    clear: flag_field & 0b01 != 0,
                    update_ui: flag_field & 0b10 != 0,
                    gifts: {
                        let mut gifts = Vec::new();
                        for _ in 0..packet.read_u8()? {
                            gifts.push(AllianceGift {
                                sn: packet.read_t()?,
                                status: packet.read_t()?,
                                rcv_time: packet.read_t()?,
                                box_item_id: packet.read_t()?,
                                item_id: packet.read_t()?,
                                num: packet.read_t()?,
                                item_rank: packet.read_t()?,
                                diamond: None,
                                money: None,
                                player: Some(packet.read_string(13)?),
                            });
                        }
                        gifts
                    },
                })
            }
            0x0B31 => {
                let num = packet.read_u8()?;
                Ok(PacketType::ClientGiftOpened(
                    num,
                    if num == 0 || num == 2 {
                        Some(AllianceGift {
                            sn: packet.read_t()?,
                            status: packet.read_t()?,
                            rcv_time: packet.read_t()?,
                            box_item_id: packet.read_t()?,
                            item_id: packet.read_t()?,
                            num: packet.read_t()?,
                            item_rank: packet.read_t()?,
                            diamond: packet.read_t()?,
                            money: packet.read_t()?,
                            player: None,
                        })
                    } else {
                        None
                    },
                ))
            }
            0x07D1 => Ok(PacketType::ClientBuildingInfo({
                let mut vec = Vec::new();
                for _ in 0..packet.read_u8()? {
                    vec.push(BuildingInfo {
                        manor_id: packet.read_t()?,
                        build_id: packet.read_t()?,
                        level: packet.read_t()?,
                    });
                }
                vec
            })),
            0x07D2 => Ok(PacketType::ClientBuildingQueue {
                queue_build_type: packet.read_t()?,
                manor_id: packet.read_t()?,
                build_id: packet.read_t()?,
                num: packet.read_t()?,
                start_time: packet.read_t()?,
                total_time: packet.read_t()?,
            }),
            0x07DD => Ok(PacketType::ClientBuildingError(packet.read_u8()?)),
            0x07D4 => Ok(PacketType::ClientBuildBegin {
                manor_id: packet.read_t()?,
                build_id: packet.read_t()?,
                num: packet.read_t()?,
                start_time: packet.read_t()?,
                total_time: packet.read_t()?,
                food: packet.read_t()?,
                stone: packet.read_t()?,
                timber: packet.read_t()?,
                ore: packet.read_t()?,
                gold: packet.read_t()?,
                removed_special_items: {
                    let mut vec = Vec::new();
                    for _ in 0..packet.read_u16()? {
                        vec.push((packet.read_t()?, packet.read_t()?));
                    }
                    vec
                },
            }),
            0x07D5 => Ok(PacketType::ClientBuildComplete {
                manor_id: packet.read_t()?,
                build_id: packet.read_t()?,
                level: packet.read_t()?,
            }),
            0x07D7 => Ok(PacketType::ClientBuildCancel {
                food: packet.read_t()?,
                stone: packet.read_t()?,
                wood: packet.read_t()?,
                ore: packet.read_t()?,
                gold: packet.read_t()?,
                added_special_items: {
                    let mut vec = Vec::new();
                    for _ in 0..packet.read_u16()? {
                        vec.push((packet.read_t()?, packet.read_t()?));
                    }
                    vec
                },
            }),
            0x0451 => {
                let num = packet.read_u8()?;
                Ok(PacketType::ClientRename {
                    num,
                    item: if num == 0 {
                        Some(packet.read_t()?)
                    } else {
                        None
                    },
                    amount_after_rename: if num == 0 {
                        Some(packet.read_t()?)
                    } else {
                        None
                    },
                    name: if num == 0 {
                        Some(packet.read_string(13)?)
                    } else {
                        None
                    },
                    role_attr_diamond: if num == 0 {
                        Some(packet.read_t()?)
                    } else {
                        None
                    },
                })
            }
            0x057F => {
                if packet.read_u8()? == 0 {
                    let item_id = packet.read_u16()?;
                    return match item_id {
                        // Newbie teleport
                        1005 | 1004 | 1275 | 1003 | 1002 => Ok(PacketType::ClientUseTeleport {
                            item_id,
                            amount_after_use: packet.read_t()?,
                            zone_id: {
                                packet.read_u16()?;
                                packet.read_u16()?
                            },
                            point_id: packet.read_t()?,
                            kingdom_id: packet.read_t()?,
                        }),
                        _ => Err(anyhow!("Не повезло не повезло... Item ID: {:04X}", item_id)),
                    };
                } else {
                    Err(anyhow!(
                        "Не повезло не повезло... Ошибка использования предмета"
                    ))
                }
            }
            0x0961 => Ok(PacketType::ClientTroopData([
                [
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                ],
                [
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                ],
                [
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                ],
                [
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                ],
                [
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                ],
            ])),
            0x07EB => Ok(PacketType::ClientInjuredData([
                [
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                ],
                [
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                ],
                [
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                ],
                [
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                ],
                [
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                ],
            ])),
            0x0712 => {
                if let Ok(result) = packet.read_bool() {
                    Ok(PacketType::ClientSkirmishCombatEnd {
                        result,
                        rnd_seed: packet.read_t()?,
                        rnd_gap: packet.read_t()?,
                        army: [
                            [
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                            ],
                            [
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                            ],
                            [
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                            ],
                            [
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                            ],
                            [0, 0, 0, 0],
                        ],
                        injured: [
                            [
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                            ],
                            [
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                            ],
                            [
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                            ],
                            [
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                                packet.read_t()?,
                            ],
                            [0, 0, 0, 0],
                        ],
                        food_now: packet.read_t()?,
                        food_speed_in_hour: packet.read_t()?,
                        stage_record: packet.read_t()?,
                        soldiers_now: [
                            (packet.read_t()?, packet.read_t()?),
                            (packet.read_t()?, packet.read_t()?),
                            (packet.read_t()?, packet.read_t()?),
                            (packet.read_t()?, packet.read_t()?),
                            (packet.read_t()?, packet.read_t()?),
                            (packet.read_t()?, packet.read_t()?),
                            (packet.read_t()?, packet.read_t()?),
                            (packet.read_t()?, packet.read_t()?),
                            (packet.read_t()?, packet.read_t()?),
                            (packet.read_t()?, packet.read_t()?),
                        ],
                        wall_now: packet.read_t()?,
                        morale_winner: packet.read_t()?,
                        eliminate: packet.read_t()?,
                        wall_down: packet.read_t()?,
                        assault_lost_force: packet.read_t()?,
                        defence_lost_force: packet.read_t()?,
                        role_attr_level: packet.read_t()?,
                        role_attr_exp: packet.read_t()?,
                        role_attr_morale: packet.read_t()?,
                        role_attr_last_morale_recover_time: packet.read_t()?,
                        role_attr_talent_points: packet.read_t()?,
                        heroes: [
                            (
                                packet.read_t()?,
                                (
                                    packet.read_t()?,
                                    packet.read_t()?,
                                    [
                                        packet.read_t()?,
                                        packet.read_t()?,
                                        packet.read_t()?,
                                        packet.read_t()?,
                                    ],
                                ),
                            ),
                            (
                                packet.read_t()?,
                                (
                                    packet.read_t()?,
                                    packet.read_t()?,
                                    [
                                        packet.read_t()?,
                                        packet.read_t()?,
                                        packet.read_t()?,
                                        packet.read_t()?,
                                    ],
                                ),
                            ),
                            (
                                packet.read_t()?,
                                (
                                    packet.read_t()?,
                                    packet.read_t()?,
                                    [
                                        packet.read_t()?,
                                        packet.read_t()?,
                                        packet.read_t()?,
                                        packet.read_t()?,
                                    ],
                                ),
                            ),
                            (
                                packet.read_t()?,
                                (
                                    packet.read_t()?,
                                    packet.read_t()?,
                                    [
                                        packet.read_t()?,
                                        packet.read_t()?,
                                        packet.read_t()?,
                                        packet.read_t()?,
                                    ],
                                ),
                            ),
                            (
                                packet.read_t()?,
                                (
                                    packet.read_t()?,
                                    packet.read_t()?,
                                    [
                                        packet.read_t()?,
                                        packet.read_t()?,
                                        packet.read_t()?,
                                        packet.read_t()?,
                                    ],
                                ),
                            ),
                        ],
                    })
                } else {
                    Ok(PacketType::ClientSkirmishCombatEndNoResult)
                }
            }
            0x03F0 => Ok(PacketType::ClientRoleInfo {
                pack_num: packet.read_t()?,
                user_id: packet.read_t()?,
                name: packet.read_string(13)?,
                head: packet.read_t()?,
                guide: packet.read_t()?,
                diamonds: {
                    packet.read_exact(&mut [0; 31])?;
                    packet.read_t()?
                },
                player_level: packet.read_t()?,
                last_hero_sp_recover_time: packet.read_t()?,
                enhance_event_hero_id: packet.read_t()?,
                hero_enhance_begin_time: packet.read_t()?,
                hero_enhance_require_time: packet.read_t()?,
                stage_info: (
                    {
                        let mut a = [0; 12];
                        packet.read_exact(&mut a)?;
                        a
                    },
                    {
                        let mut a = [0; 48];
                        packet.read_exact(&mut a)?;
                        a
                    },
                ),
                reflash_stage_record_info: packet.read_t()?,
                stage_record: packet.read_t()?,
                battle_id: packet.read_t()?,
                new_zone_id: {
                    packet.read_exact(&mut [0; 14])?;
                    packet.read_t()?
                },
                new_point_id: packet.read_t()?,
                last_chatter_time: packet.read_t()?,
                alliance_chat_id: packet.read_t()?,
                power: packet.read_t()?,
                kills: packet.read_t()?,
                vip_point: packet.read_t()?,
                date_registered: packet.read_t()?,
                prize_flag: packet.read_t()?,
                bookmark_time: packet.read_t()?,
                bookmark_limit: packet.read_t()?,
                bookmark_num: packet.read_t()?,
                skirmishes: packet.read_t()?,
                next_skirmish_soldiers: [
                    (packet.read_t()?, packet.read_t()?),
                    (packet.read_t()?, packet.read_t()?),
                    (packet.read_t()?, packet.read_t()?),
                    (packet.read_t()?, packet.read_t()?),
                    (packet.read_t()?, packet.read_t()?),
                    (packet.read_t()?, packet.read_t()?),
                    (packet.read_t()?, packet.read_t()?),
                    (packet.read_t()?, packet.read_t()?),
                    (packet.read_t()?, packet.read_t()?),
                    (packet.read_t()?, packet.read_t()?),
                ],
                next_skirmish_wall: packet.read_t()?,
                successful_login_days: packet.read_t()?,
                use_morale_items_today: packet.read_t()?,
                equip_bag_size: packet.read_t()?,
                next_online_gift_open_time: packet.read_t()?,
                online_gift_open_times: packet.read_t()?,
                online_gift_item_id: packet.read_t()?,
                online_gift_item_quantity: packet.read_t()?,
                last_lord_equip_update_time: packet.read_t()?,
                last_item_mat_update_time: packet.read_t()?,
                last_item_gem_update_time: packet.read_t()?,
                equip_event_item_id: packet.read_t()?,
                equip_event_item_color: packet.read_t()?,
                equip_event_gem_color: [
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                ],
                equip_event_gem: [
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                ],
                equip_serial_no: packet.read_t()?,
                equip_begin_time: packet.read_t()?,
                equip_require_time: packet.read_t()?,
                vip_level_up: packet.read_t()?,
                my_kingdom: (packet.read_t()?, packet.read_t()?),
                monster_point: packet.read_t()?,
                last_energy_recover_time: packet.read_t()?,
                energy_recovers_in_hour: packet.read_t()?,
                set_notice: packet.read_t()?,
                tpp_point: packet.read_t()?,
                paid_crystal: packet.read_t()?,
                buy_month_treasure_time: packet.read_t()?,
                last_month_treasure_prize_time: packet.read_t()?,
                nickname: packet.read_string(41)?,
                num5: packet.read_t()?,
                kingdom_title: packet.read_t()?,
                now_army_coord_index: packet.read_t()?,
                army_coord_flag: packet.read_t()?,
                mobilization_get_prize: packet.read_t()?,
                world_title_personal: packet.read_t()?,
                world_title_country: packet.read_t()?,
                daily_free_scard_star: packet.read_t()?,
                scard_star: packet.read_t()?,
                stage_record_3: packet.read_t()?,
                stage_record_3_part: {
                    let mut a = [0; 18];
                    packet.read_exact(&mut a)?;
                    a
                },
                new_push_switch: packet.read_t()?,
                nobility_title: packet.read_t()?,
                guide_flag_bitwise_or_bitwise_right_32: packet.read_t()?,
                guide_ex: packet.read_t()?,
                pet_skill_fatigue: packet.read_t()?,
                join_time: packet.read_t()?,
                back_reward_combo_box_id: packet.read_t()?,
            }),
            0x07DE => Ok(PacketType::ClientResources([
                (packet.read_t()?, packet.read_t()?),
                (packet.read_t()?, packet.read_t()?),
                (packet.read_t()?, packet.read_t()?),
                (packet.read_t()?, packet.read_t()?),
                (packet.read_t()?, packet.read_t()?),
            ])),
            0x0C28 => Ok(match packet.read_u8()? {
                1 => PacketType::ClientTimerMissionUpdate,
                _ => PacketType::ClientTimerMissionInfo {
                    num: packet.read_u8()? - 1,
                    missions: TimerMissions {
                        reset_time: packet.read_i64()? as f64,
                        mission_time: packet.read_i64()? as f64,
                        missions: {
                            let mut missions = Vec::new();
                            for i in 0..packet.read_u8()? {
                                missions.push(TimerMission {
                                    index: i as usize,
                                    id: packet.read_t()?,
                                    quality: packet.read_t()?,
                                    base: packet.read_t()?,
                                    item_id: packet.read_t()?,
                                    state: unsafe { std::mem::transmute(packet.read_u8()?) },
                                })
                            }
                            missions
                        },
                        now: None,
                    },
                },
            }),
            0x0C2A => Ok(PacketType::ClientTimerMissionStart(
                packet.read_u8()? - 1,
                packet.read_u8()? as usize - 1,
                packet.read_i64()?,
            )),
            0x0C2E => Ok(PacketType::ClientTimerMissionFinish(
                packet.read_u8()? - 1,
                packet.read_u8()? as usize - 1,
            )),
            0x07DF => Ok(PacketType::ClientResourceUpdate(
                packet.read_u8()?,
                (packet.read_u32()?, packet.read_i64()?),
            )),
            0x0C30 => Ok(PacketType::ClientMissionComplete {
                quest_id: packet.read_t()?,
                exp_now: packet.read_t()?,
                power_now: packet.read_t()?,
                now_level: packet.read_t()?,
                morale: packet.read_t()?,
                last_morale_recover_time: packet.read_t()?,
                talent_point: packet.read_t()?,
                resources: [
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                    packet.read_t()?,
                ],
                items: {
                    let mut map = HashMap::new();
                    for _ in 0..packet.read_u8()? {
                        map.insert(packet.read_t()?, packet.read_t()?);
                    }
                    map
                },
            }),
            0x0C32 => Ok(PacketType::ClientMissionMark({
                let mut vec = Vec::new();
                for _ in 0..packet.read_u16()? {
                    vec.push(packet.read_u16()?);
                }
                vec
            })),
            0x0AFE => Ok(PacketType::ClientDealApplication(
                packet.read_u8()?,
                packet.read_u32()?, // ?
                packet.read_bool()?,
                packet.read_i64()?,
            )),
            0x0B0E => Ok(PacketType::ClientGiveLeadershipResponse(packet.read_u8()?)),
            _ => {
                println!(
                    "[{}] Unknown packet: {:04X} ({:02X?})",
                    igg_id, packet_id, bytes
                );
                Err(anyhow!("Не повезло не повезло... ID: {:04X}", packet_id))
            }
        }
    }
}

#[allow(unused)]
#[derive(Debug, Clone, Eq, PartialEq, Hash)]
pub struct Applicant {
    pub user_id: i64,
    pub head: u16,
    pub name: String,
    pub rank: u8,
    pub power: u64,
    pub kills: u64,
}

#[allow(unused)]
#[derive(Debug)]
pub enum AllianceAttr {
    Leader(String),
    Power(u64),
    Tag(String),
    Name(String),
    Header(String),
    Bullet(String, u8),
    Emblem(u16),
    MemberAndPower(u8, u64),
    Approval(u8),
    Applicant(u8),
    Language(u8),
    Rank(u8),
    Money(u32),
    UpdateAlreadyHelped(u32, u8),
    HelpedMe {
        player_name: String,
        kind: HelpKind,
        already_helped: u8,
        start_time: i64,
        total_time: u32,
    },
    HelpRequested(HelpKind, u8),
    HelpRemove(u32),
    GiftCount(u16, u16),
    AllianceBox1 {
        gift: AllianceGift,
        gift_update_sn: u32,
    },
    AllianceBox2 {
        gift: AllianceGift,
        key: u32,
    },
    PackPoint(u32),
    GiftExp(u32),
    ChatMax(i64),
    Wonder1 {
        kingdom_id: u16,
        wonder_id: u8,
        open_state: u8,
        begin_time: i64,
        require_time: u32,
    },
    Wonder2 {
        kingdom_id: u16,
        wonder_id: u8,
        open_state: u8,
        begin_time: i64,
        require_time: u32,
    },
    Wonder3 {
        kingdom_id: u16,
        wonder_id: u8,
    },
    GiftNum(u16, u16),
    MobilizationMission {
        id: u8,
        mission_type: u16,
        difficulty: u8,
    },
    MobilizationMissionTime {
        id: u8,
        time: i64,
    },
    MobilizationInvolvedMember(u8),
    MobilizationAMScore(u32),
    Kingdom(u16),
    AMRank(u8),
    SummonScore(u32),
    SummonPoint(u8),
    SummonCombatAndScore(u8, u8, u32),
    SummonData {
        num: u16,
        gift_id: u16,
        monster_id: u16,
        cost_point: u8,
    },
    SummonMonsterData {
        kingdom_id: u16,
        zone_id: u16,
        point_id: u8,
        end_time: i64,
    },
    MonsterKilledHUDMessage(String, u16),
    AllianceWarRegister(u8),
    AllianceWarState {
        rank: u8,
        member_count: u8,
    },
    HelpUpdate {
        id: u8,
        start_time: i64,
        total_time: u32,
    },
    BookmarkTime(i64),
    FastivalSomething1(u16, u8, String),
    FastivalSomething2(u16, u8),
    LeaderRedPocketResetTime(i64),
    UpdateGiftCount(u16, u16),
    ActivityGiftInfo {
        begin_time: i64,
        end_time: i64,
        group_id: u8,
        leader_red_pocket_reset_time: i64,
    },
}

#[allow(unused)]
#[derive(Debug)]
pub struct HelpRequest {
    pub record_sn: u32,
    pub head: u16,
    pub rank: u8,
    pub player_name: String,
    pub help_kind: HelpKind,
    pub building_or_research_id: u16,
    pub level: u8,
    pub already_helped: u8,
    pub help_max: u8,
}

#[allow(unused)]
#[repr(u8)]
#[derive(Debug, Clone)]
pub enum HelpKind {
    Research,
    Building,
    Max,
}

#[allow(unused)]
#[derive(Debug)]
pub struct HeroData {
    pub id: u16,
    pub level: u8,
    pub exp: u32,
    pub enhance: u8,
    pub star: u8,
    pub equip: u8,
    pub equip_enchant: [u8; 6],
    pub skill_lv: [u8; 4],
}

#[allow(unused)]
#[repr(u8)]
#[derive(Debug)]
pub enum EMsgState {
    Null,
    Begin,
    End,
    BeginAndEnd,
}

#[allow(unused)]
#[derive(Debug)]
pub struct SocialFriend {
    social_name: String,
    num: u8,
    icon_no: u8,
}

#[allow(unused)]
#[derive(Debug)]
pub struct ChatMessage {
    pub num5: i64,
    pub num6: i64,
    pub num7: i64,
    pub alli_or_king: u8,
    pub num8: u8,
    pub pic_id: u16,
    pub player_name: String,
    pub vip_rank: u8,
    pub title_name: String,
    pub special_block_id: u8,
    pub title_id: u8,
    pub b_have_arabic: u8,
    pub num9: u16,
    pub talk_kind: u8,
    pub kingdom_id: Option<u16>,
    pub str1: Option<String>,
    pub str2: Option<String>,
    pub emoji_key: Option<u16>,
    pub num10: Option<u16>,
    pub original_text: Option<String>,
}

#[allow(unused)]
#[derive(Debug, Clone)]
pub struct AllianceGift {
    pub sn: u32,
    pub status: u8,
    pub rcv_time: i64,
    pub box_item_id: u16,
    pub item_id: u16,
    pub num: u16,
    pub item_rank: u8,
    pub diamond: Option<u32>,
    pub money: Option<u32>,
    pub player: Option<String>,
}

#[allow(unused)]
#[derive(Debug)]
pub struct BuildingInfo {
    pub manor_id: u16,
    pub build_id: u16,
    pub level: u8,
}

#[derive(Debug)]
pub struct TimerMissions {
    pub reset_time: f64,
    pub mission_time: f64,
    pub missions: Vec<TimerMission>,
    pub now: Option<usize>,
}

#[allow(unused)]
#[derive(Debug)]
pub struct TimerMission {
    pub index: usize,
    pub id: u16,
    pub quality: u16,
    pub base: u16,
    pub item_id: u16,
    pub state: TimerMissionState,
}

#[allow(unused)]
#[derive(Debug, PartialEq)]
pub enum TimerMissionState {
    Wait,
    Complete,
    Reward,
    Countdown,
    AutoComplete,
    CompleteWaitingConfirmation,
}
