// Decompiled with JetBrains decompiler
// Type: GameConstants
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Text;
using UnityEngine;

#nullable disable
public static class GameConstants
{
  public const int TimeSpanHour = -5;
  public const byte YolkMax = 40;
  public const ushort StageLineNum = 6;
  public const ushort FightButtonEff_keep = 65;
  public const ushort FightButtonEff_fight = 59;
  public const byte TileHeight = 128;
  public const byte TileMapInfoKindMax = 25;
  public const byte TileMapInfoWidthMaxOffSet = 8;
  public const byte TileMapInfoHeightMaxOffSet = 10;
  public const byte TileMapInfoWidthMaxSubTractOne = 255;
  public const ushort TileMapInfoWidthMax = 256;
  public const ushort TileMapInfoHeightMax = 1024;
  public const ushort TileMapZoneNum = 1024;
  public const int TileMapPointNum = 262144;
  public const int TileMapZoneLineTableNum = 2048;
  public const int TileMapRAMSataeInfoNum = 8;
  public const int TileMapROMSataeInfoNum = 120;
  public const byte UpdateZoneMax = 4;
  public const byte MAX_COMBAT_STAGE_SOLDIER = 10;
  public const int LineTableSize = 256;
  public const int ZonePointTableSize = 256;
  public const int PointTableSize = 2048;
  public const int ObstacleMin = 0;
  public const int ObstacleMax = 21;
  public const int LineMax = 1048576;
  public const float RequestMapdataWaiteTime = 1.5f;
  public const byte KingdomUpdateMax = 32;
  public const byte KingdomReqMax = 16;
  public const byte OpenDareLeanChapterMax = 4;
  public const int CanvasLayer = 5;
  public const int DefaultLayer = 0;
  public const byte MAX_BUFFER_LEN = 32;
  public const byte MAX_BUFFER_CACHE = 128;
  public const ushort MASK_MAP_OUT = 16384;
  public const ushort MASK_ZONE_ID = 1023;
  public const ushort KINGDOM_OPEN_TABLE_SIZE = 38;
  public const int MAP_WEAPONE_SHOW_TIME = 3;
  public const int PLAYER_NICKNAME_LEN = 10;
  public const int PLAYER_NAME_LEN = 12;
  public const int SOCIAL_NAME_LEN = 41;
  public const int MAX_NAME = 13;
  public const int MAX_TITLENAME = 3;
  public const int MAX_NICKNAME = 41;
  public const int MAX_TALKNAME = 18;
  public const int MAX_TALKCONTENT = 400;
  public const int ALLIANCE_TAG_LEN = 3;
  public const int ALLIANCE_NAME_LEN = 20;
  public const int ALLIANCE_HEADER_LEN = 20;
  public const int ALLIANCE_NOTICE_LEN = 1300;
  public const int ALLIANCE_BULLETIN_LEN = 900;
  public const int MAX_ALLIANCE_APPLYLIST = 100;
  public const int MAX_ALLIANCE_SEARCH_NUM = 100;
  public const int MAX_PLAYER_ALLIANCE_APPLY = 10;
  public const int MAX_ALLIANCE_SEARCH_ONEGROUP = 10;
  public const int MAX_ALLREPORT_SIZE = 130;
  public const int MAX_MAIL_NUM = 100;
  public const int MAX_FAVOR_NUM = 100;
  public const int MAX_SYSTEM_NUM = 50;
  public const int MAX_REPORT_NUM = 400;
  public const int MAX_MAILSIZE_NUM = 6;
  public const int MAX_MAILATTACH_NUM = 6;
  public const int MAX_MAILMULTIPLIER = 2;
  public const int MAX_MAILTITLE_LEN = 32;
  public const int MAX_MAILTITLES_LEN = 32;
  public const int MAX_MAILINGPACK_NUM = 1;
  public const int MAX_MAILINGSIZE_NUM = 10;
  public const int MAX_MAILCONTENT_LEN = 501;
  public const int MAX_COMBATREPORT_LEN = 100;
  public const int MAX_ANTISCOUTREPORT_NUM = 10;
  public const int MAX_RESOURCEREPORT_NUM = 10;
  public const int MAX_COMBATREPORT_NUM = 100;
  public const int MAX_GATHERREPORT_NUM = 10;
  public const int MAX_RECONREPORT_NUM = 10;
  public const int MAX_GATHERITEM_NUM = 10;
  public const int MAX_KINGDOM_NAME = 20;
  public const int MAX_SEARCH_PLAYER = 20;
  public const int KINGDOM_BULLITIN = 1024;
  public const byte MAX_QB_NORMAL_TIMES = 10;
  public const byte MAX_QB_ADVANCE_TIMES = 3;
  public const byte MAX_QB_REWARD_NUM = 220;
  public const byte MAX_HERO_EXPITEM_NUM = 6;
  public const float WALL_HIT_X = 52f;
  public const float WALL_HIT_PARTICLE_X = 51f;
  public const float WAR_SCALE_FACTOR = 1.5f;
  public const int MAX_ALLIANCE_MEMBER = 100;
  public const int MAX_GROUP = 8;
  public const int MAP_WEAPON_ID = 9;
  public const int MAX_GROUP_EX = 10;
  public const int MAX_Hero = 5;
  public const int MAX_Fs_InfoPlayers = 30;
  public const int MAX_Prisoner = 30;
  public const byte MaxBuildLevel = 25;
  public const int MAX_TROOP_DATA_LEN = 64;
  public const byte MAX_ACTIVITY_GETSCORE_FACTOR_NUM = 6;
  public const byte MAX_ACTIVITY_RANK = 5;
  public const byte MAX_ACTIVITY_DEGREE = 3;
  public const byte MAX_ACTIVITY_PRIZE = 20;
  public const byte MAX_ACTIVITY_RANKING_REGION = 7;
  public const byte MAX_ALLIANCEMOBILIZATION_RANKING_REGION = 5;
  public const byte MAX_ACTIVITY_RANKING_PLACE = 100;
  public const ushort ACTIVITY_PREPARE_TIME = 300;
  public const byte MAX_ACTIVITY_MONSTER = 5;
  public const byte ALLIANCEWAR_RANKPRIZE_REGION = 5;
  public const byte MAX_ALLIANCEWAR_RANKPRIZE = 4;
  public const byte MAX_TREASURE_ALLIANCEGIFT_NUM = 5;
  public const byte MAX_TREASURE_COMBOBOX_ITEM = 200;
  public const byte MAX_TREASURE_BRIEF_COMBOBOX_ITEM = 3;
  public const byte MAX_MSG_TREASURE_DATA_NUM = 30;
  public const byte MAX_MSG_TREASURE_COMBOBOX_DATA_NUM = 9;
  public const byte MAX_TREASURE_LIST_NUM = 50;
  public const byte MAX_MSG_TREASURE_INFO_NUM = 25;
  public const byte MAX_TREASURE_EXTRADATA = 3;
  public const byte MAX_HERO_ENGAGE = 5;
  public const byte MAX_SKILL = 4;
  public const byte MAX_LORD_LEVEL = 60;
  public const byte MAX_RALLY_COUNT = 30;
  public const byte AllianceMoblizationMissionMax = 20;
  public const ushort MoblizationMissionCD = 1001;
  public const int MAX_ALLIANCEMOBILIZATION_DEGREE = 35;
  public const int MAX_ALLIANCEMOBILIZATION_DEGREEPRIZE_OPTION = 3;
  public const ushort mapeomjibackiconid = 65535;
  public const float mapemojiscale = 0.9f;
  public const float mapemojicityoffset = 92f;
  public const char SComma = ',';
  public const char SDot = '.';
  public const char SMinus = '-';
  public const char StringEnd = '\0';
  public const char SSpace = ' ';
  public const char SLeftBracket = '[';
  public const char SRightBracket = ']';
  public const char SSharp = '#';
  public const string SMultiply = "x{0}";
  public const string SPercent = "{0}%";
  public const string SNumber = "{0:N}";
  public const string SLessItemColor = "<color=#FF5581FF>";
  public const string SColorWhite = "<color=#FFFFFFFF>";
  public const string SColorEnd = "</color>";
  public const string baseHostName = ".igg.com";
  public const string baseLoginHostName = "lm-login-";
  public const string baseProxyHostName = "lm-proxy-";
  public const char RePlaceChar = '*';
  public const int BundleVersionCode = 152;
  public const ushort MonsterHeroID = 50000;
  public const ushort Arena_Effect = 9200;
  public const ulong HeroPower = 1000000;
  public static readonly string[] TranslateLanguage = new string[42]
  {
    "ar",
    "af",
    "aq",
    "bg",
    "ca",
    "zh-TW",
    "hr",
    "cs",
    "da",
    "nl",
    "en",
    "et",
    "fi",
    "fr",
    "de",
    "el",
    "iw",
    "hi",
    "hu",
    "id",
    "it",
    "ja",
    "ko",
    "lv",
    "lt",
    "ms",
    "no",
    "fa",
    "pl",
    "pt",
    "ro",
    "ru",
    "sr",
    "sk",
    "sl",
    "es",
    "sv",
    "th",
    "tr",
    "uk",
    "vi",
    "zh-CN"
  };
  public static readonly string[] TranslateTragetLanguage = new string[19]
  {
    string.Empty,
    "en",
    "zh-TW",
    "fr",
    "de",
    "es",
    "ru",
    "zh-CN",
    "id",
    "vi",
    "tr",
    "th",
    "it",
    "pt",
    "ko",
    "ja",
    "uk",
    "ms",
    "ar"
  };
  public static readonly string[] GameLanguageName = new string[19]
  {
    string.Empty,
    "EN",
    "TW",
    "FR",
    "DE",
    "ES",
    "RU",
    "CN",
    "ID",
    "VN",
    "TR",
    "TH",
    "IT",
    "PT",
    "KR",
    "JP",
    "UA",
    "MY",
    "ARB"
  };
  public static readonly string GameName = "Lords Mobile";
  public static readonly string HealthGame = "健康游戏忠告\n抵制不良游戏，拒绝盗版游戏。 注意自我保护，谨防受骗上当。\n适度游戏益脑，沉迷游戏伤身。 合理安排时间，享受健康生活。";
  public static readonly string HealthGameCN = "抵制不良游戏，拒绝盗版游戏。 注意自我保护，谨防受骗上当。\n适度游戏益脑，沉迷游戏伤身。 合理安排时间，享受健康生活。\n著作权人：IGG SINGAPORE PTE. LTD.  出版单位：福州天盟数码有限公司\n批准文号：新广出审[2017]5382号  出版物号：ISBN978-7-7979-8893-3\n进口网络游戏批准号：网游进字〔2017〕0094 号";
  public static readonly string CommunityCN = "http://lordsmobile.igg.com/cn/";
  public static readonly string CommunityJP = "https://web.lobi.co/game/lords_mobile/group";
  public static readonly string CommunityKR = "http://cafe.naver.com/lordsmobile";
  public static readonly string CommunityRU = "https://vk.com/lordsmobile";
  public static readonly string Url176 = "http://lordsmobile.176.com/main.php";
  public static readonly string TWGameID = "1051019902";
  public static readonly string TWSecretKey = "f6239975b2faae941ec24695e4db5bba";
  public static readonly string TWGCMSenderId = "489219977954";
  public static readonly string TWPaymentKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEApLvdDnDjVKFDgVZGsDfdDyjNcpnvxFgST61I1CL1zdMoQ/9GUQ/mvBr4fw19uhC2gyD+vA8HqfhYJ8hpNPbUbDB9+MYnaPgufR6vEtFMnAr62DOSwcc4g8KRGCqiNO+wkTm5ytK6jx6ykD0TTYh4XhciQcNifdvJLBcS1s6xDMWjvcKPEMrCWz/KScmfPXrTnh/jlwu2bDafmVnzLED2CXDH3Z4mj0XaxR1YB9OxJJ4xaK2UytLMKKeVZLwGE3J6lXX+KnchHx/O/J2+7qCOJRNKbEbMLzFOSecN2UNqVHfCZbH1hqiSSVzwdF6maW5dK9rft/MLoJlaKCRyHVCbuQIDAQAB";
  public static readonly string[] GlobalEditionGameID = new string[19]
  {
    string.Empty,
    "1051029902",
    "1051039902",
    "1051059902",
    "1051049902",
    "1051069902",
    "1051079902",
    "1051089902",
    "1051159902",
    "1051169902",
    "1051139902",
    "1051149902",
    "1051119902",
    "1051129902",
    "1051099902",
    "1051109902",
    "1051189902",
    "1051199902",
    "1051179902"
  };
  public static readonly string[] AmazonEditionGameID = new string[19]
  {
    string.Empty,
    "1051019905",
    "1051029905",
    "1051039905",
    "1051049905",
    "1051059905",
    "1051069905",
    "1051079905",
    "1051149905",
    "1051159905",
    "1051129905",
    "1051139905",
    "1051109905",
    "1051119905",
    "1051089905",
    "1051099905",
    "1051169905",
    "1051179905",
    "1051189905"
  };
  public static readonly string[] AmazonEditionSecretKey = new string[19]
  {
    string.Empty,
    "b871ac535980040bbee4a709e5c2d3df",
    "21bffb9414be3322275a762415040027",
    "e44587b24e8ba90a5584973009d3e4b8",
    "c3c0ebffb25a86d62e36a44f19deedc9",
    "26ddc0401c12488e3ea44c7eb842d89a",
    "f0819fc3facd9d6ba1d56366e8f59f38",
    "f52e263e05a4c767fd47b6ff8d0a1757",
    "eb0a69489d38efa9e4c1169182678c79",
    "4c9a49b2964e9014dd12dd8b55d1243e",
    "94579bde8cda536e6d6d193d55d2b6f8",
    "ab453a16ca366f808ae01c1682373b67",
    "01aca668352391f7c5d221ae11220a2a",
    "81cfe6c0bb1ecef902fe95ea951d0c53",
    "32e82273adac1dbbf88d5fddb4d911a9",
    "b698451d9fa306b72711286ee9e29622",
    "fdfc379ce3702c95765de698affcc5e8",
    "68327e5deb2dc00a4604060dc837fd15",
    "755058b572b2215ef3e69b9e264d7b2e"
  };
  public static readonly string[] GlobalEditionSecretKey = new string[19]
  {
    string.Empty,
    "0d87c3e251c04d496196781e48da0abb",
    "92af4fd8e7dc4f1c299c29ec137d50e1",
    "cf62a92688a8ee779af1ed36802f7f01",
    "d3593cd0c41dd772b8f9b2e27b95a5a7",
    "215cac4e9adfb0ac829ff1f67a06a085",
    "20fe87550a4e157860a1c80377aa2b28",
    "236f724c3c121f4ea3f5b5be729c3229",
    "bd7270648b6b76407370fd95586d0075",
    "7fe03c9b27dd6fa068cbe6242dee2436",
    "db9a860cd48e730ef6f0b12030789fef",
    "f944f5fec0dedc1cb0ca338dc35bd54b",
    "37f0471f9b463562e2f5e4c406775e52",
    "6d02dc798cc6da28a14fee2c5256d389",
    "b1485ff2add0c83b3d2a0e584be9304f",
    "79d965a6e4208c0d2d2133e14cd1eccf",
    "72c0587b902d0a997794dffd1d23485a",
    "21902fdc5860b7f48fd33ce6d091aeae",
    "f69562f90d3b99c7424d9c91a3fe3945"
  };
  public static readonly string GlobalEditionGCMSenderId = "489219977954";
  public static readonly string GlobalEditionPaymentKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAjBWGQ7uE1DawEzXWEKCAeIfcqMCbmxZALu2CVtmQFAzwsWnGyowHxVcFVc1tAcBfnBWnP82KfdZ9MvilANRJ5iVNhEqYgfF7/orpkPChFIz8TJdgyNGaOjwHDsvcA5UJe5n5wBlIBFL4nGRi431gYGFPMr9Gi2jh2oUYPA+jolZlt1Xt4wVmkfR1eMVTNw+gDMlduvjZtVyOoZbFsvcvJbk4OJcP+SBvjyKk5N/8gWqr8KNMV/eUmMoKCzYkwHLB3SWuk47f12KbEIocRc2jEMvrCu7MtC+tjnHLr6/FbmhLThahR85xRdJtA41KpHbw6lTQytiF7Fh5CFc/I/t42QIDAQAB";
  public static readonly string CNGameID = "1051089911";
  public static readonly string CNSecretKey = "85325e58784353a8f9ae271fd996dc76";
  public static readonly string CNGCMSenderId = "489219977954";
  public static readonly string CNPaymentKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEApLvdDnDjVKFDgVZGsDfdDyjNcpnvxFgST61I1CL1zdMoQ/9GUQ/mvBr4fw19uhC2gyD+vA8HqfhYJ8hpNPbUbDB9+MYnaPgufR6vEtFMnAr62DOSwcc4g8KRGCqiNO+wkTm5ytK6jx6ykD0TTYh4XhciQcNifdvJLBcS1s6xDMWjvcKPEMrCWz/KScmfPXrTnh/jlwu2bDafmVnzLED2CXDH3Z4mj0XaxR1YB9OxJJ4xaK2UytLMKKeVZLwGE3J6lXX+KnchHx/O/J2+7qCOJRNKbEbMLzFOSecN2UNqVHfCZbH1hqiSSVzwdF6maW5dK9rft/MLoJlaKCRyHVCbuQIDAQAB";
  public static readonly string TWMailTo = "mailto:help.lordsonline.android.tw@igg.com";
  public static readonly string[] GlobalEditionMailTo = new string[19]
  {
    string.Empty,
    "mailto:help.lordsmobile.android@igg.com",
    "mailto:service@fantasyplus.game.tw",
    "mailto:help.lordsmobile.android.fr@igg.com",
    "mailto:help.lordsmobile.android.de@igg.com",
    "mailto:help.lordsmobile.android.es@igg.com",
    "mailto:help.lordsmobile.android.ru@igg.com",
    "mailto:help.lordsmobile.android.cn@igg.com",
    "mailto:help.lordsmobile.android.id@igg.com",
    "mailto:help.lordsmobile.android.vn@igg.com",
    "mailto:help.lordsmobile.android.tr@igg.com",
    "mailto:help.lordsmobile.android.th@igg.com",
    "mailto:help.lordsmobile.android.it@igg.com",
    "mailto:help.lordsmobile.android.pt@igg.com",
    "mailto:help.lordsmobile.android.kr@igg.com",
    "mailto:help.lordsmobile.android.jp@igg.com",
    "mailto:help.lordsmobile.android.ua@igg.com",
    "mailto:help.lordsmobile.android.my@igg.com",
    "mailto:help.lordsmobile.android.arb@igg.com"
  };
  public static readonly string TWGuideURL = "http://lo.tw.igg.com/project/guide/?";
  public static readonly string GlobalEditionGuideURL = "http://lordsmobile.igg.com/project/guide/?";
  public static readonly string TWNewsUrl = "http://lo.tw.igg.com/project/news/?";
  public static readonly string GlobalEditionTWNewsUrl = "http://lordsmobile.igg.com/project/news/?";
  public static readonly string TWNewsUrlKey = "0ebmQCLWxSdT5bUXu";
  public static readonly string GlobalEditionNewsUrlKey = "0etuaxaXNbBANAzvFBvH";
  public static readonly string TWFbUrl = "https://www.facebook.com/LordsOnlineTW/";
  public static readonly string GlobalEditionFUrl = "https://www.facebook.com/lordsmobile/";
  public static readonly string InternalClassName = "com.IgeeRD2.LordsOnline";
  public static readonly string TWClassName = "com.igg.android.lordsonline_tw";
  public static readonly string GlobalEditionClassNames = "com.igg.android.lordsmobile";
  public static readonly string ThirdPartyUpadteURL = "http://lordsmobile.igg.com/payment/?game_id=";
  public static readonly ushort[] StagePointNum = new ushort[4]
  {
    (ushort) 18,
    (ushort) 6,
    (ushort) 1,
    (ushort) 18
  };
  public static readonly ushort[] LinePointNum = new ushort[4]
  {
    (ushort) 3,
    (ushort) 1,
    (ushort) 1,
    (ushort) 3
  };
  public static readonly ushort[] StageInfoSize = new ushort[4]
  {
    (ushort) 12,
    (ushort) 48,
    (ushort) 0,
    (ushort) 18
  };
  public static readonly float[,] MAP_POS_EX = new float[64, 2]
  {
    {
      0.0f,
      0.0f
    },
    {
      16f,
      0.0f
    },
    {
      32f,
      0.0f
    },
    {
      48f,
      0.0f
    },
    {
      64f,
      0.0f
    },
    {
      80f,
      0.0f
    },
    {
      96f,
      0.0f
    },
    {
      112f,
      0.0f
    },
    {
      0.0f,
      -16f
    },
    {
      16f,
      -16f
    },
    {
      32f,
      -16f
    },
    {
      48f,
      -16f
    },
    {
      64f,
      -16f
    },
    {
      80f,
      -16f
    },
    {
      96f,
      -16f
    },
    {
      -16f,
      48f
    },
    {
      0.0f,
      -32f
    },
    {
      16f,
      -32f
    },
    {
      32f,
      -32f
    },
    {
      48f,
      -32f
    },
    {
      64f,
      -32f
    },
    {
      -48f,
      32f
    },
    {
      -32f,
      32f
    },
    {
      -16f,
      32f
    },
    {
      0.0f,
      -48f
    },
    {
      16f,
      -48f
    },
    {
      32f,
      -48f
    },
    {
      -80f,
      16f
    },
    {
      -64f,
      16f
    },
    {
      -48f,
      16f
    },
    {
      -32f,
      16f
    },
    {
      -16f,
      16f
    },
    {
      0.0f,
      64f
    },
    {
      -112f,
      0.0f
    },
    {
      -96f,
      0.0f
    },
    {
      -80f,
      0.0f
    },
    {
      -64f,
      0.0f
    },
    {
      -48f,
      0.0f
    },
    {
      -32f,
      0.0f
    },
    {
      -16f,
      0.0f
    },
    {
      0.0f,
      48f
    },
    {
      16f,
      48f
    },
    {
      32f,
      48f
    },
    {
      -80f,
      -16f
    },
    {
      -64f,
      -16f
    },
    {
      -48f,
      -16f
    },
    {
      -32f,
      -16f
    },
    {
      -16f,
      -16f
    },
    {
      0.0f,
      32f
    },
    {
      16f,
      32f
    },
    {
      32f,
      32f
    },
    {
      48f,
      32f
    },
    {
      64f,
      32f
    },
    {
      -48f,
      -32f
    },
    {
      -32f,
      -32f
    },
    {
      -16f,
      -32f
    },
    {
      0.0f,
      16f
    },
    {
      16f,
      16f
    },
    {
      32f,
      16f
    },
    {
      48f,
      16f
    },
    {
      64f,
      16f
    },
    {
      80f,
      16f
    },
    {
      96f,
      16f
    },
    {
      -16f,
      -48f
    }
  };
  public static readonly byte[] troopSortByTeir = new byte[16]
  {
    (byte) 3,
    (byte) 7,
    (byte) 11,
    (byte) 15,
    (byte) 2,
    (byte) 6,
    (byte) 10,
    (byte) 14,
    (byte) 1,
    (byte) 5,
    (byte) 9,
    (byte) 13,
    (byte) 0,
    (byte) 4,
    (byte) 8,
    (byte) 12
  };
  public static readonly byte[] trapSortByTeir = new byte[12]
  {
    (byte) 3,
    (byte) 7,
    (byte) 11,
    (byte) 2,
    (byte) 6,
    (byte) 10,
    (byte) 1,
    (byte) 5,
    (byte) 9,
    (byte) 0,
    (byte) 4,
    (byte) 8
  };
  public static readonly double[] cryptInterest = new double[4]
  {
    0.0,
    0.03,
    0.27,
    0.85
  };
  public static readonly uint[] CryptSecends = new uint[4]
  {
    0U,
    604800U,
    1209600U,
    2592000U
  };
  public static byte MAX_TALENT_CACHE_NAME_BYTE = 40;
  public static ushort TalentSaveItemID = 1254;
  public static ushort LESaveItemID = 1256;
  public static ushort NewbieTeleportItemID = 1005;
  public static ushort AdvanceTeleportItemID = 1004;
  public static ushort WorldTeleportItemID = 1275;
  public static ushort RandomTeleportItemID = 1003;
  public static ushort WorldWarTeleportItemID = 1002;
  public static ushort[] RandomTB = new ushort[1000]
  {
    (ushort) 599,
    (ushort) 699,
    (ushort) 691,
    (ushort) 642,
    (ushort) 146,
    (ushort) 740,
    (ushort) 170,
    (ushort) 895,
    (ushort) 618,
    (ushort) 768,
    (ushort) 529,
    (ushort) 656,
    (ushort) 771,
    (ushort) 941,
    (ushort) 906,
    (ushort) 411,
    (ushort) 55,
    (ushort) 897,
    (ushort) 120,
    (ushort) 439,
    (ushort) 196,
    (ushort) 98,
    (ushort) 904,
    (ushort) 70,
    (ushort) 171,
    (ushort) 420,
    (ushort) 754,
    (ushort) 804,
    (ushort) 425,
    (ushort) 519,
    (ushort) 330,
    (ushort) 508,
    (ushort) 523,
    (ushort) 653,
    (ushort) 824,
    (ushort) 51,
    (ushort) 826,
    (ushort) 611,
    (ushort) 400,
    (ushort) 390,
    (ushort) 558,
    (ushort) 502,
    (ushort) 384,
    (ushort) 144,
    (ushort) 498,
    (ushort) 268,
    (ushort) 339,
    (ushort) 136,
    (ushort) 697,
    (ushort) 859,
    (ushort) 736,
    (ushort) 827,
    (ushort) 122,
    (ushort) 474,
    (ushort) 40,
    (ushort) 938,
    (ushort) 62,
    (ushort) 639,
    (ushort) 291,
    (ushort) 948,
    (ushort) 745,
    (ushort) 417,
    (ushort) 899,
    (ushort) 881,
    (ushort) 32,
    (ushort) 237,
    (ushort) 178,
    (ushort) 580,
    (ushort) 293,
    (ushort) 121,
    (ushort) 511,
    (ushort) 587,
    (ushort) 557,
    (ushort) 846,
    (ushort) 635,
    (ushort) 199,
    (ushort) 934,
    (ushort) 58,
    (ushort) 74,
    (ushort) 373,
    (ushort) 84,
    (ushort) 365,
    (ushort) 168,
    (ushort) 686,
    (ushort) 44,
    (ushort) 323,
    (ushort) 141,
    (ushort) 679,
    (ushort) 997,
    (ushort) 379,
    (ushort) 241,
    (ushort) 750,
    (ushort) 320,
    (ushort) 473,
    (ushort) 789,
    (ushort) 280,
    (ushort) 93,
    (ushort) 970,
    (ushort) 844,
    (ushort) 724,
    (ushort) 359,
    (ushort) 290,
    (ushort) 549,
    (ushort) 92,
    (ushort) 715,
    (ushort) 973,
    (ushort) 990,
    (ushort) 837,
    (ushort) 452,
    (ushort) 617,
    (ushort) 933,
    (ushort) 119,
    (ushort) 338,
    (ushort) 467,
    (ushort) 874,
    (ushort) 994,
    (ushort) 324,
    (ushort) 643,
    (ushort) 160,
    (ushort) 749,
    (ushort) 377,
    (ushort) 579,
    (ushort) 727,
    (ushort) 832,
    (ushort) 504,
    (ushort) 840,
    (ushort) 622,
    (ushort) 139,
    (ushort) 993,
    (ushort) 492,
    (ushort) 661,
    (ushort) 690,
    (ushort) 457,
    (ushort) 964,
    (ushort) 129,
    (ushort) 23,
    (ushort) 244,
    (ushort) 930,
    (ushort) 834,
    (ushort) 974,
    (ushort) 702,
    (ushort) 730,
    (ushort) 345,
    (ushort) 923,
    (ushort) 603,
    (ushort) 926,
    (ushort) 813,
    (ushort) 576,
    (ushort) 368,
    (ushort) 773,
    (ushort) 394,
    (ushort) 668,
    (ushort) 114,
    (ushort) 117,
    (ushort) 162,
    (ushort) 407,
    (ushort) 202,
    (ushort) 586,
    (ushort) 157,
    (ushort) 409,
    (ushort) 896,
    (ushort) 584,
    (ushort) 289,
    (ushort) 108,
    (ushort) 673,
    (ushort) 49,
    (ushort) 210,
    (ushort) 95,
    (ushort) 537,
    (ushort) 648,
    (ushort) 109,
    (ushort) 167,
    (ushort) 239,
    (ushort) 698,
    (ushort) 910,
    (ushort) 966,
    (ushort) 194,
    (ushort) 654,
    (ushort) 610,
    (ushort) 208,
    (ushort) 725,
    (ushort) 209,
    (ushort) 791,
    (ushort) 2,
    (ushort) 306,
    (ushort) 982,
    (ushort) 590,
    (ushort) 708,
    (ushort) 128,
    (ushort) 408,
    (ushort) 685,
    (ushort) 367,
    (ushort) 880,
    (ushort) 868,
    (ushort) 442,
    (ushort) 828,
    (ushort) 103,
    (ushort) 717,
    (ushort) 438,
    (ushort) 446,
    (ushort) 65,
    (ushort) 986,
    (ushort) 222,
    (ushort) 190,
    (ushort) 831,
    (ushort) 544,
    (ushort) 105,
    (ushort) 509,
    (ushort) 16,
    (ushort) 503,
    (ushort) 795,
    (ushort) 772,
    (ushort) 68,
    (ushort) 305,
    (ushort) 249,
    (ushort) 660,
    (ushort) 902,
    (ushort) 253,
    (ushort) 385,
    (ushort) 440,
    (ushort) 381,
    (ushort) 682,
    (ushort) 719,
    (ushort) 191,
    (ushort) 113,
    (ushort) 429,
    (ushort) 158,
    (ushort) 206,
    (ushort) 981,
    (ushort) 596,
    (ushort) 436,
    (ushort) 889,
    (ushort) 292,
    (ushort) 216,
    (ushort) 349,
    (ushort) 496,
    (ushort) 760,
    (ushort) 488,
    (ushort) 929,
    (ushort) 135,
    (ushort) 100,
    (ushort) 539,
    (ushort) 177,
    (ushort) 101,
    (ushort) 512,
    (ushort) 110,
    (ushort) 36,
    (ushort) 836,
    (ushort) 659,
    (ushort) 99,
    (ushort) 845,
    (ushort) 522,
    (ushort) 755,
    (ushort) 149,
    (ushort) 4,
    (ushort) 743,
    (ushort) 742,
    (ushort) 41,
    (ushort) 311,
    (ushort) 979,
    (ushort) 621,
    (ushort) 134,
    (ushort) 169,
    (ushort) 969,
    (ushort) 652,
    (ushort) 159,
    (ushort) 77,
    (ushort) 593,
    (ushort) 961,
    (ushort) 482,
    (ushort) 118,
    (ushort) 213,
    (ushort) 507,
    (ushort) 304,
    (ushort) 166,
    (ushort) 207,
    (ushort) 254,
    (ushort) 314,
    (ushort) 541,
    (ushort) 399,
    (ushort) 873,
    (ushort) 29,
    (ushort) 234,
    (ushort) 215,
    (ushort) 601,
    (ushort) 811,
    (ushort) 347,
    (ushort) 397,
    (ushort) 86,
    (ushort) 341,
    (ushort) 501,
    (ushort) 515,
    (ushort) 972,
    (ushort) 640,
    (ushort) 830,
    (ushort) 301,
    (ushort) 856,
    (ushort) 644,
    (ushort) 761,
    (ushort) 953,
    (ushort) 5,
    (ushort) 362,
    (ushort) 329,
    (ushort) 877,
    (ushort) 581,
    (ushort) 34,
    (ushort) 414,
    (ushort) 885,
    (ushort) 333,
    (ushort) 104,
    (ushort) 893,
    (ushort) 404,
    (ushort) 187,
    (ushort) 531,
    (ushort) 536,
    (ushort) 271,
    (ushort) 631,
    (ushort) 72,
    (ushort) 573,
    (ushort) 403,
    (ushort) 677,
    (ushort) 3,
    (ushort) 371,
    (ushort) 786,
    (ushort) 274,
    (ushort) 287,
    (ushort) 353,
    (ushort) 608,
    (ushort) 182,
    (ushort) 582,
    (ushort) 797,
    (ushort) 900,
    (ushort) 283,
    (ushort) 204,
    (ushort) 7,
    (ushort) 453,
    (ushort) 613,
    (ushort) 585,
    (ushort) 328,
    (ushort) 495,
    (ushort) 38,
    (ushort) 481,
    (ushort) 751,
    (ushort) 218,
    (ushort) 569,
    (ushort) 871,
    (ushort) 450,
    (ushort) 858,
    (ushort) 402,
    (ushort) 998,
    (ushort) 710,
    (ushort) 316,
    (ushort) 675,
    (ushort) 87,
    (ushort) 197,
    (ushort) 296,
    (ushort) 313,
    (ushort) 24,
    (ushort) 219,
    (ushort) 360,
    (ushort) 294,
    (ushort) 176,
    (ushort) 875,
    (ushort) 939,
    (ushort) 882,
    (ushort) 272,
    (ushort) 391,
    (ushort) 443,
    (ushort) 578,
    (ushort) 357,
    (ushort) 150,
    (ushort) 91,
    (ushort) 140,
    (ushort) 240,
    (ushort) 321,
    (ushort) 386,
    (ushort) 960,
    (ushort) 996,
    (ushort) 925,
    (ushort) 21,
    (ushort) 777,
    (ushort) 335,
    (ushort) 634,
    (ushort) 180,
    (ushort) 435,
    (ushort) 909,
    (ushort) 217,
    (ushort) 628,
    (ushort) 83,
    (ushort) 80,
    (ushort) 655,
    (ushort) 233,
    (ushort) 383,
    (ushort) 914,
    (ushort) 985,
    (ushort) 568,
    (ushort) 198,
    (ushort) 286,
    (ushort) byte.MaxValue,
    (ushort) 221,
    (ushort) 382,
    (ushort) 718,
    (ushort) 546,
    (ushort) 705,
    (ushort) 211,
    (ushort) 303,
    (ushort) 67,
    (ushort) 995,
    (ushort) 282,
    (ushort) 25,
    (ushort) 756,
    (ushort) 312,
    (ushort) 469,
    (ushort) 692,
    (ushort) 433,
    (ushort) 250,
    (ushort) 463,
    (ushort) 667,
    (ushort) 59,
    (ushort) 604,
    (ushort) 258,
    (ushort) 694,
    (ushort) 164,
    (ushort) 556,
    (ushort) 729,
    (ushort) 663,
    (ushort) 645,
    (ushort) 112,
    (ushort) 843,
    (ushort) 776,
    (ushort) 630,
    (ushort) 680,
    (ushort) 672,
    (ushort) 901,
    (ushort) 924,
    (ushort) 723,
    (ushort) 563,
    (ushort) 766,
    (ushort) 887,
    (ushort) 862,
    (ushort) 468,
    (ushort) 10,
    (ushort) 137,
    (ushort) 388,
    (ushort) 759,
    (ushort) 514,
    (ushort) 547,
    (ushort) 285,
    (ushort) 790,
    (ushort) 11,
    (ushort) 978,
    (ushort) 342,
    (ushort) 186,
    (ushort) 798,
    (ushort) 931,
    (ushort) 392,
    (ushort) 666,
    (ushort) 928,
    (ushort) 458,
    (ushort) 369,
    (ushort) 535,
    (ushort) 870,
    (ushort) 242,
    (ushort) 416,
    (ushort) 733,
    (ushort) 860,
    (ushort) 555,
    (ushort) 415,
    (ushort) 189,
    (ushort) 803,
    (ushort) 102,
    (ushort) 82,
    (ushort) 506,
    (ushort) 28,
    (ushort) 256,
    (ushort) 505,
    (ushort) 816,
    (ushort) 90,
    (ushort) 552,
    (ushort) 309,
    (ushort) 688,
    (ushort) 820,
    (ushort) 455,
    (ushort) 47,
    (ushort) 331,
    (ushort) 18,
    (ushort) 614,
    (ushort) 891,
    (ushort) 79,
    (ushort) 595,
    (ushort) 956,
    (ushort) 574,
    (ushort) 423,
    (ushort) 43,
    (ushort) 14,
    (ushort) 470,
    (ushort) 464,
    (ushort) 297,
    (ushort) 46,
    (ushort) 641,
    (ushort) 851,
    (ushort) 447,
    (ushort) 577,
    (ushort) 73,
    (ushort) 534,
    (ushort) 775,
    (ushort) 229,
    (ushort) 812,
    (ushort) 975,
    (ushort) 13,
    (ushort) 633,
    (ushort) 863,
    (ushort) 327,
    (ushort) 513,
    (ushort) 432,
    (ushort) 116,
    (ushort) 247,
    (ushort) 193,
    (ushort) 814,
    (ushort) 583,
    (ushort) 592,
    (ushort) 78,
    (ushort) 315,
    (ushort) 308,
    (ushort) 426,
    (ushort) 56,
    (ushort) 810,
    (ushort) 410,
    (ushort) 770,
    (ushort) 510,
    (ushort) 731,
    (ushort) 554,
    (ushort) 720,
    (ushort) 124,
    (ushort) 876,
    (ushort) 151,
    (ushort) 334,
    (ushort) 636,
    (ushort) 406,
    (ushort) 629,
    (ushort) 153,
    (ushort) 246,
    (ushort) 275,
    (ushort) 527,
    (ushort) 350,
    (ushort) 884,
    (ushort) 395,
    (ushort) 486,
    (ushort) 748,
    (ushort) 800,
    (ushort) 721,
    (ushort) 401,
    (ushort) 267,
    (ushort) 220,
    (ushort) 517,
    (ushort) 115,
    (ushort) 152,
    (ushort) 913,
    (ushort) 200,
    (ushort) 559,
    (ushort) 142,
    (ushort) 248,
    (ushort) 734,
    (ushort) 937,
    (ushort) 231,
    (ushort) 917,
    (ushort) 822,
    (ushort) 263,
    (ushort) 905,
    (ushort) 520,
    (ushort) 817,
    (ushort) 111,
    (ushort) 732,
    (ushort) 477,
    (ushort) 594,
    (ushort) 784,
    (ushort) 188,
    (ushort) 955,
    (ushort) 472,
    (ushort) 336,
    (ushort) 126,
    (ushort) 8,
    (ushort) 669,
    (ushort) 861,
    (ushort) 888,
    (ushort) 670,
    (ushort) 172,
    (ushort) 346,
    (ushort) 739,
    (ushort) 533,
    (ushort) 245,
    (ushort) 528,
    (ushort) 225,
    (ushort) 163,
    (ushort) 145,
    (ushort) 543,
    (ushort) 476,
    (ushort) 278,
    (ushort) 269,
    (ushort) 722,
    (ushort) 532,
    (ushort) 228,
    (ushort) 802,
    (ushort) 81,
    (ushort) 819,
    (ushort) 60,
    (ushort) 566,
    (ushort) 709,
    (ushort) 147,
    (ushort) 703,
    (ushort) 485,
    (ushort) 808,
    (ushort) 848,
    (ushort) 376,
    (ushort) 421,
    (ushort) 968,
    (ushort) 550,
    (ushort) 835,
    (ushort) 572,
    (ushort) 936,
    (ushort) 638,
    (ushort) 758,
    (ushort) 944,
    (ushort) 20,
    (ushort) 676,
    (ushort) 951,
    (ushort) 358,
    (ushort) 689,
    (ushort) 479,
    (ushort) 307,
    (ushort) 389,
    (ushort) 422,
    (ushort) 69,
    (ushort) 864,
    (ushort) 852,
    (ushort) 75,
    (ushort) 726,
    (ushort) 300,
    (ushort) 821,
    (ushort) 201,
    (ushort) 746,
    (ushort) 801,
    (ushort) 872,
    (ushort) 97,
    (ushort) 259,
    (ushort) 794,
    (ushort) 823,
    (ushort) 940,
    (ushort) 19,
    (ushort) 674,
    (ushort) 427,
    (ushort) 318,
    (ushort) 451,
    (ushort) 449,
    (ushort) 270,
    (ushort) 545,
    (ushort) 437,
    (ushort) 916,
    (ushort) 632,
    (ushort) 793,
    (ushort) 809,
    (ushort) 310,
    (ushort) 475,
    (ushort) 466,
    (ushort) 842,
    (ushort) 548,
    (ushort) 538,
    (ushort) 1,
    (ushort) 616,
    (ushort) 714,
    (ushort) 987,
    (ushort) 138,
    (ushort) 561,
    (ushort) 921,
    (ushort) 700,
    (ushort) 174,
    (ushort) 947,
    (ushort) 854,
    (ushort) 516,
    (ushort) 704,
    (ushort) 325,
    (ushort) 878,
    (ushort) 337,
    (ushort) 780,
    (ushort) 657,
    (ushort) 932,
    (ushort) 959,
    (ushort) 175,
    (ushort) 838,
    (ushort) 480,
    (ushort) 154,
    (ushort) 89,
    (ushort) 526,
    (ushort) 626,
    (ushort) 491,
    (ushort) 883,
    (ushort) 352,
    (ushort) 737,
    (ushort) 606,
    (ushort) 490,
    (ushort) 665,
    (ushort) 762,
    (ushort) 565,
    (ushort) 785,
    (ushort) 850,
    (ushort) 567,
    (ushort) 396,
    (ushort) 984,
    (ushort) 148,
    (ushort) 343,
    (ushort) 273,
    (ushort) 553,
    (ushort) 462,
    (ushort) 9,
    (ushort) 279,
    (ushort) 26,
    (ushort) 64,
    (ushort) 588,
    (ushort) 922,
    (ushort) 605,
    (ushort) 465,
    (ushort) 788,
    (ushort) 497,
    (ushort) 943,
    (ushort) 299,
    (ushort) 155,
    (ushort) 179,
    (ushort) 264,
    (ushort) 230,
    (ushort) 713,
    (ushort) 54,
    (ushort) 181,
    (ushort) 894,
    (ushort) 94,
    (ushort) 908,
    (ushort) 302,
    (ushort) 912,
    (ushort) 53,
    (ushort) 431,
    (ushort) 419,
    (ushort) 627,
    (ushort) 807,
    (ushort) 33,
    (ushort) 185,
    (ushort) 227,
    (ushort) 17,
    (ushort) 806,
    (ushort) 22,
    (ushort) 983,
    (ushort) 378,
    (ushort) 319,
    (ushort) 66,
    (ushort) 63,
    (ushort) 1000,
    (ushort) 500,
    (ushort) 281,
    (ushort) 478,
    (ushort) 687,
    (ushort) 132,
    (ushort) 869,
    (ushort) 232,
    (ushort) 867,
    (ushort) 647,
    (ushort) 243,
    (ushort) 918,
    (ushort) 945,
    (ushort) 96,
    (ushort) 332,
    (ushort) 143,
    (ushort) 6,
    (ushort) 701,
    (ushort) 853,
    (ushort) 88,
    (ushort) 12,
    (ushort) 678,
    (ushort) 744,
    (ushort) 991,
    (ushort) 866,
    (ushort) 460,
    (ushort) 949,
    (ushort) 499,
    (ushort) 530,
    (ushort) 412,
    (ushort) 387,
    (ushort) 156,
    (ushort) 898,
    (ushort) 471,
    (ushort) 326,
    (ushort) 214,
    (ushort) 260,
    (ushort) 763,
    (ushort) 45,
    (ushort) 521,
    (ushort) 890,
    (ushort) 564,
    (ushort) 361,
    (ushort) 695,
    (ushort) 815,
    (ushort) 295,
    (ushort) 372,
    (ushort) 915,
    (ushort) 363,
    (ushort) 48,
    (ushort) 847,
    (ushort) 277,
    (ushort) 919,
    (ushort) 298,
    (ushort) 600,
    (ushort) 957,
    (ushort) 380,
    (ushort) 224,
    (ushort) 818,
    (ushort) 562,
    (ushort) 525,
    (ushort) 252,
    (ushort) 841,
    (ushort) sbyte.MaxValue,
    (ushort) 413,
    (ushort) 651,
    (ushort) 461,
    (ushort) 782,
    (ushort) 664,
    (ushort) 71,
    (ushort) 954,
    (ushort) 855,
    (ushort) 226,
    (ushort) 623,
    (ushort) 619,
    (ushort) 752,
    (ushort) 61,
    (ushort) 518,
    (ushort) 31,
    (ushort) 792,
    (ushort) 671,
    (ushort) 489,
    (ushort) 716,
    (ushort) 524,
    (ushort) 30,
    (ushort) 375,
    (ushort) 971,
    (ushort) 825,
    (ushort) 935,
    (ushort) 494,
    (ushort) 952,
    (ushort) 15,
    (ushort) 52,
    (ushort) 598,
    (ushort) 454,
    (ushort) 398,
    (ushort) 706,
    (ushort) 76,
    (ushort) 212,
    (ushort) 778,
    (ushort) 977,
    (ushort) 753,
    (ushort) 637,
    (ushort) 989,
    (ushort) 707,
    (ushort) 907,
    (ushort) 205,
    (ushort) 257,
    (ushort) 235,
    (ushort) 493,
    (ushort) 418,
    (ushort) 364,
    (ushort) 693,
    (ushort) 266,
    (ushort) 597,
    (ushort) 487,
    (ushort) 829,
    (ushort) 658,
    (ushort) 927,
    (ushort) 223,
    (ushort) 571,
    (ushort) 769,
    (ushort) 540,
    (ushort) 238,
    (ushort) 107,
    (ushort) 405,
    (ushort) 711,
    (ushort) 106,
    (ushort) 344,
    (ushort) 445,
    (ushort) 942,
    (ushort) 456,
    (ushort) 192,
    (ushort) 351,
    (ushort) 173,
    (ushort) 712,
    (ushort) 251,
    (ushort) 37,
    (ushort) 747,
    (ushort) 130,
    (ushort) 607,
    (ushort) 591,
    (ushort) 839,
    (ushort) 833,
    (ushort) 483,
    (ushort) 920,
    (ushort) 560,
    (ushort) 620,
    (ushort) 879,
    (ushort) 696,
    (ushort) 609,
    (ushort) 35,
    (ushort) 366,
    (ushort) 799,
    (ushort) 980,
    (ushort) 774,
    (ushort) 612,
    (ushort) 317,
    (ushort) 783,
    (ushort) 428,
    (ushort) 123,
    (ushort) 374,
    (ushort) 735,
    (ushort) 849,
    (ushort) 340,
    (ushort) 356,
    (ushort) 424,
    (ushort) 946,
    (ushort) 988,
    (ushort) 184,
    (ushort) 484,
    (ushort) 684,
    (ushort) 131,
    (ushort) 57,
    (ushort) 125,
    (ushort) 39,
    (ushort) 738,
    (ushort) 575,
    (ushort) 857,
    (ushort) 967,
    (ushort) 602,
    (ushort) 165,
    (ushort) 551,
    (ushort) 542,
    (ushort) 728,
    (ushort) 958,
    (ushort) 764,
    (ushort) 796,
    (ushort) 203,
    (ushort) 681,
    (ushort) 757,
    (ushort) 683,
    (ushort) 741,
    (ushort) 999,
    (ushort) 624,
    (ushort) 911,
    (ushort) 288,
    (ushort) 42,
    (ushort) 615,
    (ushort) 355,
    (ushort) 236,
    (ushort) 625,
    (ushort) 85,
    (ushort) 27,
    (ushort) 787,
    (ushort) 779,
    (ushort) 903,
    (ushort) 441,
    (ushort) 805,
    (ushort) 459,
    (ushort) 765,
    (ushort) 865,
    (ushort) 322,
    (ushort) 950,
    (ushort) 434,
    (ushort) 354,
    (ushort) 892,
    (ushort) 976,
    (ushort) 370,
    (ushort) 992,
    (ushort) 767,
    (ushort) 262,
    (ushort) 276,
    (ushort) 962,
    (ushort) 50,
    (ushort) 448,
    (ushort) 444,
    (ushort) 133,
    (ushort) 183,
    (ushort) 161,
    (ushort) 662,
    (ushort) 430,
    (ushort) 650,
    (ushort) 393,
    (ushort) 348,
    (ushort) 963,
    (ushort) 261,
    (ushort) 646,
    (ushort) 781,
    (ushort) 284,
    (ushort) 265,
    (ushort) 195,
    (ushort) 886,
    (ushort) 589,
    (ushort) 965,
    (ushort) 570,
    (ushort) 649
  };
  public static Vector3 lineeomji = new Vector3(0.0f, 1.071f, 0.0f);
  public static Vector3 lineeomjiback = new Vector3(0.0f, 1.03f, 0.12f);
  public static readonly char[] numChar = new char[10]
  {
    '0',
    '1',
    '2',
    '3',
    '4',
    '5',
    '6',
    '7',
    '8',
    '9'
  };
  public static readonly string[] SItemRareHeader = new string[6]
  {
    string.Empty,
    "<color=#FFFFFFFF>",
    "<color=#4DDA65FF>",
    "<color=#74A5FFFF>",
    "<color=#C37DF9FF>",
    "<color=#F3D84EFF>"
  };
  public static readonly ushort[] Version = new ushort[3]
  {
    (ushort) 1,
    (ushort) 71,
    (ushort) 22
  };
  public static readonly string[] IPMan = new string[1]
  {
    "192.243.44.63"
  };
  public static Color32 DefaultAmbientLight = new Color32((byte) 137, (byte) 137, (byte) 137, byte.MaxValue);
  public static readonly string[] m_Mail = new string[19]
  {
    string.Empty,
    "help.lordsmobile.android@igg.com",
    "service@fantasyplus.game.tw",
    "help.lordsmobile.android.fr@igg.com",
    "help.lordsmobile.android.de@igg.com",
    "help.lordsmobile.android.es@igg.com",
    "help.lordsmobile.android.ru@igg.com",
    "help.lordsmobile.android.cn@igg.com",
    "help.lordsmobile.android.id@igg.com",
    "help.lordsmobile.android.vn@igg.com",
    "help.lordsmobile.android.tr@igg.com",
    "help.lordsmobile.android.th@igg.com",
    "help.lordsmobile.android.it@igg.com",
    "help.lordsmobile.android.pt@igg.com",
    "help.lordsmobile.android.kr@igg.com",
    "help.lordsmobile.android.jp@igg.com",
    "help.lordsmobile.android.ua@igg.com",
    "help.lordsmobile.android.my@igg.com",
    "help.lordsmobile.android.arb@igg.com"
  };
  public static Vector3 GoldGuy = new Vector3(22f, 181f, 224f);
  public static Vector3 GamblingGuy = new Vector3(128f, 181f, 150f);
  public static Vector3 Vec3Instance = new Vector3(0.0f, 0.0f, 0.0f);
  private static Vector3 inv_direction = new Vector3();
  public static readonly double[] HeroRankMod = new double[9]
  {
    0.0,
    0.03,
    0.1,
    0.18,
    0.3,
    0.45,
    0.65,
    0.9,
    1.0
  };
  public static readonly double[] HeroColorMod = new double[6]
  {
    0.0,
    0.05,
    0.1,
    0.2,
    0.4,
    1.0
  };

  public static float FastInvSqrt(float x)
  {
    if ((double) x < 9.9999997171806854E-10)
      return 1E-09f;
    float num1 = x * 0.5f;
    float num2 = x;
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    int num3 = 1597463007 - (^(int&) ref num2 >> 1);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    float num4 = ^(float&) ref num3;
    return num4 * (float) (1.5 - (double) num1 * (double) num4 * (double) num4);
  }

  public static float fastSine(float f)
  {
    return (float) -(1.2732394933700562 * (double) f + -0.40528470277786255 * (double) f * ((double) f >= 0.0 ? (double) f : -(double) f));
  }

  public static Vector3 MoveTowards(Vector3 current, Vector3 target, float deltaTime)
  {
    float num1 = target.x - current.x;
    float num2 = target.z - current.z;
    float num3 = GameConstants.FastInvSqrt((float) ((double) num1 * (double) num1 + (double) num2 * (double) num2)) * deltaTime;
    float num4 = (double) num3 <= 0.99000000953674316 ? num3 : 1f;
    float num5 = num1 * num4;
    float num6 = num2 * num4;
    GameConstants.Vec3Instance.Set(current.x + num5, 0.0f, current.z + num6);
    return GameConstants.Vec3Instance;
  }

  public static Vector3 MoveTowardsPlus(Vector3 current, Vector3 target, float deltaTime)
  {
    float num1 = target.x - current.x;
    float num2 = target.y - current.y;
    float num3 = target.z - current.z;
    float num4 = GameConstants.FastInvSqrt((float) ((double) num1 * (double) num1 + (double) num2 * (double) num2 + (double) num3 * (double) num3)) * deltaTime;
    float num5 = (double) num4 <= 0.99000000953674316 ? num4 : 1f;
    float num6 = num1 * num5;
    float num7 = num2 * num5;
    float num8 = num3 * num5;
    GameConstants.Vec3Instance.Set(current.x + num6, current.y + num7, current.z + num8);
    return GameConstants.Vec3Instance;
  }

  public static float DistanceSquare(Vector3 p1, Vector3 p2)
  {
    float num1 = p2.x - p1.x;
    float num2 = p2.z - p1.z;
    return (float) ((double) num1 * (double) num1 + (double) num2 * (double) num2);
  }

  public static DateTime GetDateTime(long Time)
  {
    Time = Time * 10000000L + 621355968000000000L;
    return DateTime.FromBinary(Time < 0L || Time > DateTime.MaxValue.Ticks ? 0L : Time).ToLocalTime();
  }

  public static ushort ConvertBytesToUShort(byte[] value, int startIdx)
  {
    if (startIdx < 0 || startIdx + 2 > value.Length)
      startIdx = value.Length - 2;
    return (ushort) ((uint) value[startIdx] | (uint) value[startIdx + 1] << 8);
  }

  public static int ConvertBytesToInt(byte[] value, int startIdx)
  {
    if (startIdx < 0 || startIdx + 4 > value.Length)
      startIdx = value.Length - 4;
    return (int) value[startIdx] | (int) value[startIdx + 1] << 8 | (int) value[startIdx + 2] << 16 | (int) value[startIdx + 3] << 24;
  }

  public static uint ConvertBytesToUInt(byte[] value, int startIdx)
  {
    return (uint) GameConstants.ConvertBytesToInt(value, startIdx);
  }

  public static long ConvertBytesToLong(byte[] value, int startIdx)
  {
    if (startIdx < 0 || startIdx + 8 > value.Length)
      startIdx = value.Length - 8;
    return (long) ((int) value[startIdx] | (int) value[startIdx + 1] << 8 | (int) value[startIdx + 2] << 16 | (int) value[startIdx + 3] << 24 | (int) value[startIdx + 4] | (int) value[startIdx + 5] << 8 | (int) value[startIdx + 6] << 16 | (int) value[startIdx + 7] << 24);
  }

  public static float ConvertBytesToFloat(byte[] value, int startIdx)
  {
    int num = GameConstants.ConvertBytesToInt(value, startIdx);
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    return ^(float&) ref num;
  }

  public static void GetBytes(ushort value, byte[] goal, int startIdx = 0)
  {
    if (startIdx < 0 || startIdx + 2 > goal.Length)
      startIdx = goal.Length - 2;
    goal[startIdx++] = (byte) ((uint) value & (uint) byte.MaxValue);
    goal[startIdx] = (byte) ((int) value >> 8 & (int) byte.MaxValue);
  }

  public static void GetBytes(uint value, byte[] goal, int startIdx = 0)
  {
    if (startIdx < 0 || startIdx + 4 > goal.Length)
      startIdx = goal.Length - 4;
    goal[startIdx++] = (byte) (value & (uint) byte.MaxValue);
    goal[startIdx++] = (byte) (value >> 8 & (uint) byte.MaxValue);
    goal[startIdx++] = (byte) (value >> 16 & (uint) byte.MaxValue);
    goal[startIdx] = (byte) (value >> 24 & (uint) byte.MaxValue);
  }

  public static void GetBytes(float value, byte[] goal, int startIdx = 0)
  {
    // ISSUE: cast to a reference type
    // ISSUE: explicit reference operation
    GameConstants.GetBytes(^(uint&) ref value, goal, startIdx);
  }

  public static unsafe GameObject GameObjectPick(
    Vector2 touch,
    GameObject[] in_gameObjects,
    System.Type t,
    bool Overlay = false)
  {
    GameConstants.inv_direction.Set(touch.x, touch.y, 0.0f);
    Ray ray = Camera.main.ScreenPointToRay(GameConstants.inv_direction);
    // ISSUE: untyped stack allocation
    int* numPtr = (int*) __untypedstackalloc((int) checked (3U * 4U));
    // ISSUE: untyped stack allocation
    Vector3* vector3Ptr = (Vector3*) __untypedstackalloc((int) checked (2U * unchecked ((uint) sizeof (Vector3))));
    if (Input.touchCount > 1)
      return (GameObject) null;
    GameConstants.inv_direction.Set(1f / ray.direction.x, 1f / ray.direction.y, 1f / ray.direction.z);
    *numPtr = (double) GameConstants.inv_direction.x >= 0.0 ? 0 : 1;
    numPtr[1] = (double) GameConstants.inv_direction.y >= 0.0 ? 0 : 1;
    numPtr[2] = (double) GameConstants.inv_direction.z >= 0.0 ? 0 : 1;
    float num1 = 65536f;
    GameObject gameObject = (GameObject) null;
    byte num2 = (byte) (in_gameObjects.Length - 1);
    for (short index = (short) num2; index >= (short) 0; --index)
    {
      if ((bool) (UnityEngine.Object) in_gameObjects[(int) index] && in_gameObjects[(int) index].activeSelf)
      {
        Renderer renderer = in_gameObjects[(int) index].GetComponent(t) as Renderer;
        if ((UnityEngine.Object) renderer == (UnityEngine.Object) null && in_gameObjects[(int) index].transform.childCount > 0)
          renderer = in_gameObjects[(int) index].transform.GetChild(0).GetComponent(t) as Renderer;
        if ((UnityEngine.Object) renderer == (UnityEngine.Object) null)
          renderer = in_gameObjects[(int) index].GetComponentInChildren(t) as Renderer;
        if (!((UnityEngine.Object) renderer == (UnityEngine.Object) null) && renderer.enabled)
        {
          *vector3Ptr = renderer.bounds.min;
          vector3Ptr[1] = renderer.bounds.max;
          float num3 = (vector3Ptr[*numPtr].x - ray.origin.x) * GameConstants.inv_direction.x;
          float num4 = (vector3Ptr[1 - *numPtr].x - ray.origin.x) * GameConstants.inv_direction.x;
          float num5 = (vector3Ptr[numPtr[1]].y - ray.origin.y) * GameConstants.inv_direction.y;
          float num6 = (vector3Ptr[1 - numPtr[1]].y - ray.origin.y) * GameConstants.inv_direction.y;
          if ((double) num3 <= (double) num6 && (double) num5 <= (double) num4)
          {
            if ((double) num5 > (double) num3)
              num3 = num5;
            if ((double) num6 < (double) num4)
              num4 = num6;
            float num7 = (vector3Ptr[numPtr[2]].z - ray.origin.z) * GameConstants.inv_direction.z;
            float num8 = (vector3Ptr[1 - numPtr[2]].z - ray.origin.z) * GameConstants.inv_direction.z;
            if ((double) num3 <= (double) num8 && (double) num7 <= (double) num4)
            {
              if ((double) num7 > (double) num3)
                num3 = num7;
              if ((double) num1 > (double) num3)
              {
                num1 = num3;
                gameObject = in_gameObjects[(int) index];
                if (!Overlay)
                  break;
              }
            }
          }
        }
      }
    }
    return gameObject;
  }

  public static void ArrayFill<T>(T[] arrayToFill, T fillValue) => arrayToFill.Fill<T>(fillValue);

  public static void Fill<T>(this T[] destinationArray, params T[] value)
  {
    if (destinationArray == null || value.Length >= destinationArray.Length)
      return;
    Array.Copy((Array) value, (Array) destinationArray, value.Length);
    int num = destinationArray.Length % 2 == 0 ? destinationArray.Length / 2 : destinationArray.Length / 2 + 1;
    int length;
    for (length = value.Length; length < num; length <<= 1)
      Array.Copy((Array) destinationArray, 0, (Array) destinationArray, length, length);
    Array.Copy((Array) destinationArray, 0, (Array) destinationArray, length, destinationArray.Length - length);
  }

  public static void FormatResourceValue(StringBuilder sb, uint value)
  {
    if (value >= 1000000000U)
      sb.AppendFormat("{0:#.##}B", (object) (float) ((double) (value / 10000000U) / 100.0));
    else if (value >= 100000000U)
      sb.AppendFormat("{0}M", (object) (value / 1000000U));
    else if (value >= 10000000U)
      sb.AppendFormat("{0:#.#}M", (object) (float) ((double) (value / 100000U) / 10.0));
    else if (value >= 1000000U)
      sb.AppendFormat("{0:#.##}M", (object) (float) ((double) (value / 10000U) / 100.0));
    else if (value >= 100000U)
      sb.AppendFormat("{0}K", (object) (value / 1000U));
    else if (value >= 10000U)
      sb.AppendFormat("{0:#.#}K", (object) (float) ((double) (value / 100U) / 10.0));
    else if (value >= 1000U)
      sb.AppendFormat("{0},{1:000}", (object) (value / 1000U), (object) (value % 1000U));
    else
      sb.Append(value);
  }

  public static void FormatResourceValue(CString CStr, uint value)
  {
    if (value >= 1000000000U)
    {
      CStr.FloatToFormat((float) value / 1E+09f, 2, false);
      CStr.AppendFormat("{0}B");
    }
    else if (value >= 100000000U)
    {
      CStr.IntToFormat((long) (value / 1000000U));
      CStr.AppendFormat("{0}M");
    }
    else if (value >= 10000000U)
    {
      CStr.FloatToFormat((float) value / 1000000f, 1, false);
      CStr.AppendFormat("{0}M");
    }
    else if (value >= 1000000U)
    {
      CStr.FloatToFormat((float) value / 1000000f, 2, false);
      CStr.AppendFormat("{0}M");
    }
    else if (value >= 100000U)
    {
      CStr.IntToFormat((long) (value / 1000U));
      CStr.AppendFormat("{0}K");
    }
    else if (value >= 10000U)
    {
      CStr.FloatToFormat((float) value / 1000f, 1, false);
      CStr.AppendFormat("{0}K");
    }
    else if (value >= 1000U)
    {
      CStr.IntToFormat((long) (value / 1000U));
      CStr.IntToFormat((long) (value % 1000U), 3);
      CStr.AppendFormat("{0},{1}");
    }
    else
    {
      CStr.IntToFormat((long) value);
      CStr.AppendFormat("{0}");
    }
  }

  public static void FormatResourceValue_Int(CString CStr, int value)
  {
    if (value < 0)
    {
      value = -value;
      CStr.Append("-");
    }
    GameConstants.FormatResourceValue(CStr, (uint) value);
  }

  public static void FormatValue(StringBuilder sb, uint value)
  {
    if (value >= 1000000000U)
      sb.AppendFormat("{0},{1:000},{2:000},{3:000}", (object) (value / 1000000000U), (object) (value % 1000000000U / 1000000U), (object) (value % 1000000U / 1000U), (object) (value % 1000U));
    else if (value >= 1000000U)
      sb.AppendFormat("{0},{1:000},{2:000}", (object) (value / 1000000U), (object) (value % 1000000U / 1000U), (object) (value % 1000U));
    else if (value >= 1000U)
      sb.AppendFormat("{0},{1:000}", (object) (value / 1000U), (object) (value % 1000U));
    else
      sb.Append(value);
  }

  public static void FormatEstimateValue(StringBuilder sb, uint value)
  {
    if (value >= 1000000000U)
      sb.AppendFormat("~{0}B", (object) (float) (value / 1000000000U));
    else if (value >= 100000000U)
      sb.AppendFormat("~{0}00M", (object) (float) (value / 100000000U));
    else if (value >= 10000000U)
      sb.AppendFormat("~{0}0M", (object) (float) (value / 10000000U));
    else if (value >= 1000000U)
      sb.AppendFormat("~{0}M", (object) (float) (value / 1000000U));
    else if (value >= 100000U)
      sb.AppendFormat("~{0}00K", (object) (value / 100000U));
    else if (value >= 10000U)
      sb.AppendFormat("~{0}0K", (object) (value / 10000U));
    else if (value >= 1000U)
      sb.AppendFormat("~{0}K", (object) (value / 1000U));
    else if (value >= 100U)
      sb.AppendFormat("~{0}00", (object) (value / 100U));
    else if (value >= 10U)
      sb.AppendFormat("~{0}0", (object) (value / 10U));
    else
      sb.Append(value);
  }

  public static Vector2 MapPosToPointCode(Vector2 in_mapPos)
  {
    ushort x1 = (ushort) in_mapPos.x;
    ushort y1 = (ushort) in_mapPos.y;
    ushort x2 = (ushort) in_mapPos.x;
    ushort y2 = (ushort) in_mapPos.y;
    ushort num1 = (ushort) ((uint) (ushort) ((uint) x1 >> 5) + (uint) (ushort) ((uint) (ushort) ((uint) y1 >> 4) << 4));
    byte num2 = (byte) ((uint) (byte) (ushort) ((uint) (ushort) ((uint) x2 >> 1) & 15U) + (uint) (byte) ((uint) (ushort) ((uint) y2 & 15U) << 4));
    in_mapPos.x = (float) num1;
    in_mapPos.y = (float) num2;
    return in_mapPos;
  }

  public static Vector2 getTileMapPosbySpriteID(int in_spriteId)
  {
    if (in_spriteId <= -1 || in_spriteId >= 262144)
      return Vector2.zero;
    int y = in_spriteId >> 8;
    return new Vector2((float) (((in_spriteId & (int) byte.MaxValue) << 1) + (y & 1)), (float) y);
  }

  public static bool IsPetSkillLine(int lineTableID)
  {
    return ((int) DataManager.MapDataController.MapLineTable[lineTableID].baseFlag & 2) != 0;
  }

  public static Mesh CreatePlane(
    Vector3 up,
    Vector3 right,
    Rect uvRect,
    Color color,
    float radius)
  {
    Mesh plane = new Mesh();
    Vector3[] vector3Array = new Vector3[4]
    {
      up * radius - right * radius,
      up * radius + right * radius,
      -up * radius - right * radius,
      -up * radius + right * radius
    };
    Vector2[] vector2Array = new Vector2[4]
    {
      new Vector2(uvRect.x, uvRect.y + uvRect.height),
      new Vector2(uvRect.x + uvRect.width, uvRect.y + uvRect.height),
      new Vector2(uvRect.x, uvRect.y),
      new Vector2(uvRect.x + uvRect.width, uvRect.y)
    };
    Color[] colorArray = new Color[4]
    {
      color,
      color,
      color,
      color
    };
    int[] triangles = new int[6]{ 0, 1, 3, 0, 3, 2 };
    plane.vertices = vector3Array;
    plane.uv = vector2Array;
    plane.colors = colorArray;
    plane.SetTriangles(triangles, 0);
    return plane;
  }

  public static Vector3 WordToVector3(
    ushort posx,
    ushort posy,
    ushort posz,
    int offset = -100,
    float in_decimal = 0.01f)
  {
    int num = 32768;
    int maxValue = (int) short.MaxValue;
    Vector2 vector2 = new Vector2(in_decimal, -in_decimal);
    return Vector3.zero with
    {
      x = (float) ((int) posx & maxValue) * vector2[((int) posx & num) >> 15] + (float) offset,
      y = (float) ((int) posy & maxValue) * vector2[((int) posy & num) >> 15] + (float) offset,
      z = (float) ((int) posz & maxValue) * vector2[((int) posz & num) >> 15] + (float) offset
    };
  }

  public static int PointCodeToMapID(ushort zoneID, byte pointID)
  {
    return (((int) zoneID & 1023 & 15) << 4) + ((int) pointID & 15) + ((((int) zoneID & 1023) >> 4 << 4) + ((int) pointID >> 4) << 8);
  }

  public static int TileMapPosToMapID(int in_posx, int in_posy)
  {
    return (in_posy << 8) + (++in_posx - (in_posy & 1) >> 1);
  }

  public static bool CheckTileMapPos(int in_posx, int in_posy)
  {
    return in_posx > -1 && in_posx < 512 && in_posy > -1 && in_posy < 1024;
  }

  public static void MapIDToPointCode(int mapID, out ushort zoneID, out byte pointID)
  {
    int num1 = mapID & (int) byte.MaxValue;
    int num2 = mapID >> 8;
    zoneID = (ushort) ((num2 >> 4 << 4) + (num1 >> 4));
    pointID = (byte) (((num2 & 15) << 4) + (num1 & 15));
  }

  public static Vector2 getTileMapPosbyMapID(int mapID)
  {
    if (mapID <= -1 || mapID >= 262144)
      return Vector2.zero;
    int y = mapID >> 8;
    return new Vector2((float) (((mapID & (int) byte.MaxValue) << 1) + (y & 1)), (float) y);
  }

  public static Vector2 getTileMapPosbyPointCode(ushort zoneID, byte pointID)
  {
    return GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(zoneID, pointID));
  }

  public static Vector2 CubicBezierCurves(
    Vector2 start,
    Vector2 center,
    Vector2 center2,
    Vector2 end,
    float inverseLength,
    float timeStep)
  {
    float num1 = timeStep * inverseLength;
    float num2 = 1f - num1;
    return num2 * num2 * num2 * start + 3f * num1 * num2 * num2 * center + 3f * num2 * num1 * num1 * center2 + num1 * num1 * num1 * end;
  }

  public static Vector2 QuadraticBezierCurves(
    Vector2 start,
    Vector2 center,
    Vector2 end,
    float inverseLength,
    float timeStep)
  {
    float num1 = timeStep * inverseLength;
    float num2 = 1f - num1;
    return num2 * num2 * start + 2f * num1 * num2 * center + num1 * num1 * end;
  }

  public static Vector3 QuadraticBezierCurves(
    Vector3 start,
    Vector3 center,
    Vector3 end,
    float inverseLength,
    float timeStep)
  {
    float num1 = timeStep * inverseLength;
    float num2 = 1f - num1;
    return num2 * num2 * start + 2f * num1 * num2 * center + num1 * num1 * end;
  }

  public static uint appCeil(float InFloat)
  {
    uint num1 = (uint) Mathf.Round(InFloat);
    float num2 = (float) num1;
    return (double) num2 < (double) InFloat && (double) InFloat - (double) num2 > 0.0099999997764825821 ? num1 + 1U : num1;
  }

  public static void GetEffectValue(
    StringBuilder sb,
    ushort meffectId,
    uint mValue = 0,
    byte Kind = 0,
    float fValue = 0,
    long mValue2 = 0)
  {
    sb.Length = 0;
    Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(meffectId);
    switch (Kind)
    {
      case 0:
        sb.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.StringID));
        break;
      case 1:
        StringBuilder sb1 = new StringBuilder();
        GameConstants.FormatValue(sb1, mValue);
        sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.String_infoID), (object) sb1);
        break;
      case 2:
        sb.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.String_infoID));
        if (recordByKey.ValueID == (ushort) 4378)
          mValue /= 100U;
        sb.AppendFormat("{0:N0}", (object) mValue);
        sb.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.ValueID));
        break;
      case 3:
        if (meffectId > (ushort) 1000)
        {
          sb.AppendFormat("{0}", (object) DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.InfoID));
          break;
        }
        if (meffectId == (ushort) 0)
        {
          sb.Length = 0;
          break;
        }
        if (recordByKey.ValueID == (ushort) 4378)
        {
          fValue = (float) mValue / 100f;
          if (GUIManager.Instance.IsArabic)
          {
            sb.AppendFormat("%{0:#.##}", (object) fValue);
            break;
          }
          sb.AppendFormat("{0:#.##}%", (object) fValue);
          break;
        }
        sb.AppendFormat("{0:N0}", (object) mValue);
        if (recordByKey.ValueID == (ushort) 0)
          break;
        sb.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.ValueID));
        break;
      case 4:
        sb.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.InfoID));
        if (recordByKey.ValueID == (ushort) 4378)
          mValue /= 100U;
        sb.AppendFormat("{0:N0}", (object) mValue);
        sb.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.ValueID));
        break;
      case 7:
        if (meffectId > (ushort) 1000)
        {
          sb.AppendFormat("{0}", (object) DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.String_infoID));
          break;
        }
        if (meffectId == (ushort) 0)
        {
          sb.Length = 0;
          break;
        }
        sb.AppendFormat("{0}", (object) DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.String_infoID));
        if (recordByKey.ValueID == (ushort) 4378)
        {
          if (mValue2 != 0L)
          {
            fValue = (float) mValue2 / 100f;
            sb.AppendFormat("{0:#0.##%}", (object) (float) ((double) fValue / 100.0));
            break;
          }
          fValue = (float) mValue / 100f;
          sb.AppendFormat("{0:#0.##%}", (object) (float) ((double) fValue / 100.0));
          break;
        }
        if (mValue2 != 0L)
          sb.AppendFormat("{0:N0}", (object) mValue2);
        else
          sb.AppendFormat("{0:N0}", (object) mValue);
        if (recordByKey.ValueID == (ushort) 0)
          break;
        sb.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.ValueID));
        break;
    }
  }

  public static void GetEffectValue(
    CString CStr,
    ushort meffectId,
    uint mValue = 0,
    byte Kind = 0,
    float fValue = 0)
  {
    CStr.ClearString();
    Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(meffectId);
    switch (Kind)
    {
      case 0:
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.StringID));
        break;
      case 1:
        CStr.IntToFormat((long) mValue, bNumber: true);
        CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.String_infoID));
        break;
      case 2:
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.String_infoID));
        if (recordByKey.ValueID == (ushort) 4378)
          mValue /= 100U;
        CStr.IntToFormat((long) mValue, bNumber: true);
        CStr.AppendFormat("{0}");
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.ValueID));
        break;
      case 3:
        if (meffectId > (ushort) 1000)
        {
          CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.InfoID));
          break;
        }
        if (meffectId == (ushort) 0)
        {
          CStr.ClearString();
          break;
        }
        if (recordByKey.ValueID == (ushort) 4378)
        {
          fValue = (float) mValue / 100f;
          CStr.FloatToFormat(fValue, 2, false);
          if (GUIManager.Instance.IsArabic)
          {
            CStr.AppendFormat("%{0}");
            break;
          }
          CStr.AppendFormat("{0}%");
          break;
        }
        CStr.IntToFormat((long) mValue, bNumber: true);
        CStr.AppendFormat("{0}");
        if (recordByKey.ValueID == (ushort) 0)
          break;
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.ValueID));
        break;
      case 4:
        CStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.InfoID));
        if (recordByKey.ValueID == (ushort) 4378)
          mValue /= 100U;
        CStr.IntToFormat((long) mValue, bNumber: true);
        CStr.AppendFormat("{0}");
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.ValueID));
        break;
      case 5:
        if (recordByKey.ValueID == (ushort) 4378)
          fValue /= 100f;
        CStr.FloatToFormat(fValue);
        if (recordByKey.ValueID != (ushort) 4378)
        {
          if (GUIManager.Instance.IsArabic)
          {
            CStr.AppendFormat("{0}+");
            break;
          }
          CStr.AppendFormat("+{0}");
          break;
        }
        if (GUIManager.Instance.IsArabic)
        {
          CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.ValueID));
          CStr.AppendFormat("{0}+");
          break;
        }
        CStr.AppendFormat("+{0}");
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.ValueID));
        break;
      case 6:
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.String_infoID));
        if (recordByKey.ValueID == (ushort) 4378)
          fValue /= 100f;
        CStr.FloatToFormat(fValue, bAfterPointShowZero: false);
        CStr.AppendFormat("{0}");
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.ValueID));
        break;
      case 7:
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.String_infoID));
        break;
      case 8:
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.InfoID));
        break;
      case 9:
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.String_infoID));
        CStr.IntToFormat((long) mValue, bNumber: true);
        CStr.AppendFormat("{0}");
        break;
      case 10:
        CStr.IntToFormat((long) mValue, bNumber: true);
        CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.InfoID));
        break;
      case 11:
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.InfoID));
        if (recordByKey.ValueID == (ushort) 4378)
          mValue /= 100U;
        CStr.FloatToFormat((float) mValue);
        if (recordByKey.StatusIcon == (ushort) 0 || recordByKey.StatusIcon == (ushort) 2)
          CStr.AppendFormat("+{0}");
        else
          CStr.AppendFormat("-{0}");
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.ValueID));
        break;
      case 12:
        if (recordByKey.ValueID == (ushort) 4378)
        {
          double f = (double) mValue / 100.0;
          CStr.DoubleToFormat(f, 2, false);
          if (GUIManager.Instance.IsArabic)
          {
            CStr.AppendFormat("%{0}");
            break;
          }
          CStr.AppendFormat("{0}%");
          break;
        }
        CStr.IntToFormat((long) mValue, bNumber: true);
        CStr.AppendFormat("{0}");
        if (recordByKey.ValueID == (ushort) 0)
          break;
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.ValueID));
        break;
      case 13:
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.InfoID));
        if (recordByKey.ValueID == (ushort) 4378)
          fValue = (float) mValue / 100f;
        CStr.FloatToFormat(fValue, bAfterPointShowZero: false);
        CStr.AppendFormat("+{0}");
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.ValueID));
        break;
      case 14:
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.InfoID));
        if (mValue != 0U)
        {
          if (recordByKey.ValueID == (ushort) 4378)
            mValue /= 100U;
          CStr.FloatToFormat((float) mValue);
          if (recordByKey.StatusIcon == (ushort) 0 || recordByKey.StatusIcon == (ushort) 2)
            CStr.AppendFormat("+{0}");
          else
            CStr.AppendFormat("-{0}");
        }
        CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.ValueID));
        break;
    }
  }

  public static void UpdataRedImgNum(RectTransform mRT, int Num)
  {
    if (Num / 100 > 0)
    {
      mRT.sizeDelta = new Vector2(35f, mRT.sizeDelta.y);
      mRT.sizeDelta = new Vector2(35f, mRT.sizeDelta.y);
    }
    else if (Num / 10 > 0)
    {
      mRT.sizeDelta = new Vector2(27f, mRT.sizeDelta.y);
      mRT.sizeDelta = new Vector2(27f, mRT.sizeDelta.y);
    }
    else
    {
      mRT.sizeDelta = new Vector2(19f, mRT.sizeDelta.y);
      mRT.sizeDelta = new Vector2(19f, mRT.sizeDelta.y);
    }
  }

  public static void GetTimeString(
    CString CStr,
    uint sec,
    bool useSpace = false,
    bool hideTimeIfDays = false,
    bool showZeroHour = true,
    bool withArabic = false,
    bool bShowDay = true)
  {
    uint num = sec;
    if (!GUIManager.Instance.IsArabic || !withArabic)
    {
      if (bShowDay && num > 86400U)
      {
        CStr.IntToFormat((long) (int) (num / 86400U));
        CStr.AppendFormat("{0}d ");
        if (hideTimeIfDays)
          return;
        num %= 86400U;
      }
      if (showZeroHour || num >= 3600U)
      {
        CStr.IntToFormat((long) (int) (num / 3600U), 2);
        if (useSpace)
          CStr.AppendFormat("{0} : ");
        else
          CStr.AppendFormat("{0}:");
        num %= 3600U;
      }
      CStr.IntToFormat((long) (int) (num / 60U), 2);
      if (useSpace)
        CStr.AppendFormat("{0} : ");
      else
        CStr.AppendFormat("{0}:");
      uint x = num % 60U;
      CStr.IntToFormat((long) x, 2);
      CStr.AppendFormat("{0}");
    }
    else
    {
      int x1 = 0;
      if (bShowDay && num > 86400U)
      {
        x1 = (int) (num / 86400U);
        if (hideTimeIfDays)
        {
          CStr.IntToFormat((long) x1);
          CStr.AppendFormat("{0}d");
          return;
        }
        num %= 86400U;
      }
      if (showZeroHour || num >= 3600U)
      {
        CStr.IntToFormat((long) (int) (num / 3600U), 2);
        if (useSpace)
          CStr.AppendFormat("{0} : ");
        else
          CStr.AppendFormat("{0}:");
        num %= 3600U;
      }
      CStr.IntToFormat((long) (int) (num / 60U), 2);
      if (useSpace)
        CStr.AppendFormat("{0} : ");
      else
        CStr.AppendFormat("{0}:");
      uint x2 = num % 60U;
      CStr.IntToFormat((long) x2, 2);
      CStr.AppendFormat("{0}");
      if (x1 <= 0)
        return;
      CStr.IntToFormat((long) x1);
      CStr.AppendFormat(" {0}d");
    }
  }

  public static void GetTimeInfoString(CString CStr, uint sec)
  {
    uint num1 = sec;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    if (num1 > 86400U)
    {
      CStr.IntToFormat((long) (int) (num1 / 86400U));
      CStr.AppendFormat(mStringTable.GetStringByID(5764U));
      uint num2 = num1 % 86400U;
      if (num2 < 3600U)
        return;
      CStr.Append(" ");
      CStr.IntToFormat((long) (int) (num2 / 3600U));
      CStr.AppendFormat(mStringTable.GetStringByID(5763U));
      uint num3 = num2 % 3600U;
    }
    else
    {
      if (num1 >= 3600U)
      {
        CStr.IntToFormat((long) (int) (num1 / 3600U));
        CStr.AppendFormat(mStringTable.GetStringByID(5763U));
        num1 %= 3600U;
      }
      if (num1 < 60U)
        return;
      CStr.IntToFormat((long) (int) (num1 / 60U));
      CStr.AppendFormat(mStringTable.GetStringByID(5762U));
    }
  }

  public static void GetTimeStringShort(CString CStr, uint sec)
  {
    uint num1 = sec;
    if (num1 > 86400U)
    {
      CStr.IntToFormat((long) (int) (num1 / 86400U));
      CStr.AppendFormat("{0}d ");
    }
    else
    {
      uint num2 = num1 % 86400U;
      if (num2 >= 3600U)
      {
        CStr.IntToFormat((long) (int) (num2 / 3600U));
        CStr.AppendFormat("{0}h");
      }
      else
      {
        uint num3 = num2 % 3600U;
        if (num3 >= 60U)
        {
          CStr.IntToFormat((long) (int) (num3 / 60U));
          CStr.AppendFormat("{0}m");
        }
        else
        {
          uint x = num3 % 60U;
          CStr.IntToFormat((long) x);
          CStr.AppendFormat("{0}s");
        }
      }
    }
  }

  public static void GetNameString(
    CString CStr,
    ushort KingdomID,
    CString Name,
    CString AlliTag,
    bool alwaysShowKingdom = false)
  {
    GameConstants.FormatRoleName(CStr, Name, AlliTag, bCheckedNickname: (byte) 0, KingdomID: alwaysShowKingdom || KingdomID != (ushort) 0 && (int) KingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID ? KingdomID : (ushort) 0);
  }

  public static void GetAllianceNameString(
    CString CStr,
    ushort KingdomID,
    CString Name,
    CString AlliTag,
    bool alwaysShowKingdom = false)
  {
    if (DataManager.Instance.RoleAlliance.Id > 0U)
      GameConstants.FormatRoleName(CStr, Name, AlliTag, bCheckedNickname: (byte) 0, KingdomID: alwaysShowKingdom || KingdomID != (ushort) 0 && (int) KingdomID != (int) DataManager.Instance.RoleAlliance.KingdomID ? KingdomID : (ushort) 0);
    else
      GameConstants.FormatRoleName(CStr, Name, AlliTag, bCheckedNickname: (byte) 0, KingdomID: KingdomID);
  }

  public static void GetHostName(CString CStr, string in_ip, string hostname)
  {
    CStr.StringToFormat(hostname);
    CStr.StringToFormat(in_ip);
    CStr.StringToFormat(".igg.com");
    CStr.AppendFormat("{0}{1}{2}");
    byte num = 0;
    for (int index = 0; index < CStr.Length && num < (byte) 3; ++index)
    {
      if (CStr[index] == '.')
      {
        ++num;
        CStr.SetChar(index, '-');
      }
    }
  }

  public static void GetColoredLordEquipString(CString CStr, ushort ItemID, byte color)
  {
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(ItemID);
    CStr.Append(GameConstants.SItemRareHeader[(int) color]);
    CStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.EquipName));
    CStr.Append("</color>");
  }

  public static void GetKingdomXYString(
    CString CStr,
    ushort KingdomID,
    int MapID,
    bool NoKingdomID = false)
  {
    if (!GUIManager.Instance.IsArabic)
    {
      if (!NoKingdomID && KingdomID != (ushort) 0)
      {
        CStr.IntToFormat((long) KingdomID);
        CStr.AppendFormat("K:{0} ");
      }
      Vector2 tileMapPosbyMapId = GameConstants.getTileMapPosbyMapID(MapID);
      CStr.IntToFormat((long) tileMapPosbyMapId.x);
      CStr.IntToFormat((long) tileMapPosbyMapId.y);
      CStr.AppendFormat("X:{0} Y:{1}");
    }
    else
    {
      Vector2 tileMapPosbyMapId = GameConstants.getTileMapPosbyMapID(MapID);
      CStr.IntToFormat((long) tileMapPosbyMapId.x);
      CStr.IntToFormat((long) tileMapPosbyMapId.y);
      CStr.AppendFormat("{1}:Y {0}:X");
      if (NoKingdomID || KingdomID == (ushort) 0)
        return;
      CStr.IntToFormat((long) KingdomID);
      CStr.AppendFormat(" {0}:K");
    }
  }

  public static bool IsBetween(int item, int start, int end) => item >= start && item <= end;

  public static bool IsBetween(long item, long start, long end) => item >= start && item <= end;

  public static Vector3 HalfShortsToVector3(ushort x, ushort y, ushort z)
  {
    return new Vector3()
    {
      x = x <= (ushort) 32768 ? (float) x : (float) x - (float) ushort.MaxValue,
      y = y <= (ushort) 32768 ? (float) y : (float) y - (float) ushort.MaxValue,
      z = z <= (ushort) 32768 ? (float) z : (float) z - (float) ushort.MaxValue
    };
  }

  public static bool IsBigStyle()
  {
    return DataManager.Instance.UserLanguage == GameLanguage.GL_Cht || DataManager.Instance.UserLanguage == GameLanguage.GL_Chs || DataManager.Instance.UserLanguage == GameLanguage.GL_Kor || DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn;
  }

  public static ulong GetHeroPower(CurHeroData heroData)
  {
    return (ulong) (1000000.0 * GameConstants.HeroRankMod[(int) heroData.Enhance] * GameConstants.HeroColorMod[(int) heroData.Star]);
  }

  public static void SetPivot(RectTransform rectTransform, Vector2 pivot)
  {
    if ((UnityEngine.Object) rectTransform == (UnityEngine.Object) null)
      return;
    Vector2 size = rectTransform.rect.size;
    Vector2 vector2 = rectTransform.pivot - pivot;
    Vector3 vector3 = new Vector3(vector2.x * size.x, vector2.y * size.y);
    rectTransform.pivot = pivot;
    RectTransform rectTransform1 = rectTransform;
    ((Transform) rectTransform1).localPosition = ((Transform) rectTransform1).localPosition - vector3;
  }

  public static bool FormatRoleName(
    CString FromattedName,
    CString Name,
    CString Tag = null,
    CString Nickname = null,
    byte bCheckedNickname = 0,
    ushort KingdomID = 0,
    string KingdomColor = null,
    string NameColor = null,
    string TagColor = null,
    string NickColor = null)
  {
    bool flag = false;
    if (FromattedName == null)
      return flag;
    FromattedName.ClearString();
    if (Nickname != null && Nickname.Length > 0)
    {
      switch (bCheckedNickname)
      {
        case 0:
          flag = ArabicTransfer.Instance.IsArabicStr(Nickname.ToString());
          break;
        case 2:
          flag = true;
          break;
      }
    }
    bool isArabic = GUIManager.Instance.IsArabic;
    if (flag)
    {
      if (isArabic && KingdomID > (ushort) 0)
      {
        FromattedName.IntToFormat((long) KingdomID);
        if (KingdomColor != null)
        {
          FromattedName.StringToFormat(KingdomColor);
          FromattedName.StringToFormat("</color>");
          FromattedName.AppendFormat("{1}#{0}{2} ");
        }
        else
          FromattedName.AppendFormat("#{0} ");
      }
      if (Nickname != null && Nickname.Length > 0)
      {
        if (NickColor != null)
        {
          FromattedName.StringToFormat(NickColor);
          FromattedName.StringToFormat(Nickname);
          FromattedName.StringToFormat("</color>");
          FromattedName.AppendFormat("{0}{1}{2}");
        }
        else
          FromattedName.Append(Nickname);
        FromattedName.Append(" ");
      }
      if (NameColor != null)
      {
        FromattedName.StringToFormat(NameColor);
        FromattedName.StringToFormat(Name);
        FromattedName.StringToFormat("</color>");
        FromattedName.AppendFormat("{0}{1}{2}");
      }
      else
        FromattedName.Append(Name);
      if (Tag != null && Tag.Length > 0)
      {
        FromattedName.StringToFormat(Tag);
        if (TagColor != null)
        {
          FromattedName.StringToFormat(TagColor);
          FromattedName.StringToFormat("</color>");
          FromattedName.AppendFormat("{1}[{0}]{2}");
        }
        else
          FromattedName.AppendFormat("[{0}]");
      }
      if (!isArabic && KingdomID > (ushort) 0)
      {
        FromattedName.IntToFormat((long) KingdomID);
        if (KingdomColor != null)
        {
          FromattedName.StringToFormat(KingdomColor);
          FromattedName.StringToFormat("</color>");
          FromattedName.AppendFormat(" {1}{0}#{2}");
        }
        else
          FromattedName.AppendFormat(" {0}#");
      }
    }
    else
    {
      if (!isArabic && KingdomID > (ushort) 0)
      {
        FromattedName.IntToFormat((long) KingdomID);
        if (KingdomColor != null)
        {
          FromattedName.StringToFormat(KingdomColor);
          FromattedName.StringToFormat("</color>");
          FromattedName.AppendFormat("{1}#{0}{2} ");
        }
        else
          FromattedName.AppendFormat("#{0} ");
      }
      if (Tag != null && Tag.Length > 0)
      {
        FromattedName.StringToFormat(Tag);
        if (TagColor != null)
        {
          FromattedName.StringToFormat(TagColor);
          FromattedName.StringToFormat("</color>");
          FromattedName.AppendFormat("{1}[{0}]{2}");
        }
        else
          FromattedName.AppendFormat("[{0}]");
      }
      if (NameColor != null)
      {
        FromattedName.StringToFormat(NameColor);
        FromattedName.StringToFormat(Name);
        FromattedName.StringToFormat("</color>");
        FromattedName.AppendFormat("{0}{1}{2}");
      }
      else
        FromattedName.Append(Name);
      if (Nickname != null && Nickname.Length > 0)
      {
        FromattedName.Append(" ");
        if (NickColor != null)
        {
          FromattedName.StringToFormat(NickColor);
          FromattedName.StringToFormat(Nickname);
          FromattedName.StringToFormat("</color>");
          FromattedName.AppendFormat("{0}{1}{2}");
        }
        else
          FromattedName.Append(Nickname);
      }
      if (isArabic && KingdomID > (ushort) 0)
      {
        FromattedName.IntToFormat((long) KingdomID);
        if (KingdomColor != null)
        {
          FromattedName.StringToFormat(KingdomColor);
          FromattedName.StringToFormat("</color>");
          FromattedName.AppendFormat("{1} {0}#{2}");
        }
        else
          FromattedName.AppendFormat(" {0}#");
      }
    }
    return flag;
  }

  public static ushort SetHintValue(ushort[] pAttr, byte mskillkind, bool bValue1)
  {
    ushort num = 0;
    switch (mskillkind)
    {
      case 0:
        num = pAttr[3];
        break;
      case 1:
        num = pAttr[4];
        break;
      case 3:
        num = !bValue1 ? pAttr[4] : pAttr[3];
        break;
      case 4:
        if (bValue1)
        {
          num = pAttr[3];
          break;
        }
        break;
      case 5:
        num = !bValue1 ? pAttr[3] : pAttr[4];
        break;
      case 6:
        if (bValue1)
        {
          num = pAttr[4];
          break;
        }
        break;
      case 7:
        if (!bValue1)
        {
          num = pAttr[3];
          break;
        }
        break;
      case 8:
        if (!bValue1)
        {
          num = pAttr[4];
          break;
        }
        break;
    }
    return num;
  }

  public static ushort RandomValue(ushort seed, byte gap, ushort count)
  {
    return GameConstants.RandomTB[((int) seed + (int) gap * (int) count) % 1000];
  }
}
