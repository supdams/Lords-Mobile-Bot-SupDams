// Decompiled with JetBrains decompiler
// Type: BattleController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class BattleController : Gameplay
{
  public const int MAX_GRAPHKIND = 8;
  public const float SCENE_CENTER_X = 11.9f;
  public const float SCENE_CENTER_Z = 5.5f;
  public const float BATTLE_SCENE_SIZE_X = 23.8f;
  public const float BATTLE_SCENE_SIZE_Z = 11f;
  public const ushort MAX_ENERGY = 1000;
  public const float GLOBAL_MODEL_SCALE = 1.17f;
  public const float NEWBIE_ULTRA_DELAY = 0.85f;
  public const int MAX_ENEMIES = 20;
  public const int MAX_PLAYERS = 5;
  public const int MAX_ACTORS = 25;
  public const byte PLAYER_ATTR_DIRTY = 1;
  public const byte ENEMY_ATTR_DIRTY = 2;
  public const int MAX_SOUNDTRIGGER_RATE = 60;
  public static readonly Color[] StateSkin = new Color[4]
  {
    new Color(1f, 0.2f, 0.2f),
    new Color(0.2f, 1f, 0.2f),
    new Color(0.1f, 0.1f, 0.1f),
    new Color(0.4f, 0.4f, 0.4f)
  };
  public Rect[] ProjectorUV = new Rect[8];
  public byte[][] PJ_GraphKind = new byte[6][]
  {
    new byte[7]
    {
      (byte) 4,
      (byte) 9,
      (byte) 10,
      (byte) 14,
      (byte) 51,
      (byte) 56,
      (byte) 57
    },
    new byte[4]{ (byte) 3, (byte) 12, (byte) 18, (byte) 59 },
    new byte[1]{ (byte) 1 },
    new byte[1]{ (byte) 2 },
    new byte[12]
    {
      (byte) 6,
      (byte) 7,
      (byte) 8,
      (byte) 11,
      (byte) 15,
      (byte) 16,
      (byte) 17,
      (byte) 19,
      (byte) 53,
      (byte) 54,
      (byte) 55,
      (byte) 58
    },
    new byte[4]{ (byte) 5, (byte) 13, (byte) 52, (byte) 60 }
  };
  public Vector2[] F_SpreadOffset = new Vector2[8]
  {
    new Vector2(0.0f, 2f),
    new Vector2(2f, 2f),
    new Vector2(2f, 0.0f),
    new Vector2(2f, -2f),
    new Vector2(0.0f, -2f),
    new Vector2(-2f, -2f),
    new Vector2(-2f, 0.0f),
    new Vector2(-2f, 2f)
  };
  public ChaseType[] FT2CT = new ChaseType[8]
  {
    ChaseType.Straight,
    ChaseType.CurveA,
    ChaseType.Straight,
    ChaseType.Straight,
    ChaseType.CurveLeft,
    ChaseType.CurveRight,
    ChaseType.Straight,
    ChaseType.CurveRandom
  };
  private Vector3 Vec3Instance = new Vector3(0.0f, 0.0f, 0.0f);
  private StringBuilder StringInstance = new StringBuilder(64);
  public static EBattleMode BattleMode = EBattleMode.Default;
  public EBattleType BattleType;
  public AnimationUnit[] playerUnit = new AnimationUnit[5];
  public BattleController.HeroAttr[] playerAttr = new BattleController.HeroAttr[5];
  public AnimationUnit[] enemyUnit = new AnimationUnit[20];
  public BattleController.HeroAttr[] enemyAttr = new BattleController.HeroAttr[20];
  public int playerCount;
  public int enemyCount;
  public int enemyAliveCount;
  public int totalAliveCount;
  public float totalDieAliveRate;
  public byte m_bHPMPDirty;
  public float FirstPlayerPosX;
  public bool bTimeUp;
  private int[] m_HeroIDFilter = new int[25];
  private int m_IDFilterCount;
  private BattleController.HeroRef HeroRefInstance = new BattleController.HeroRef();
  private Dictionary<int, BattleController.HeroRef> m_HeroMap = new Dictionary<int, BattleController.HeroRef>(25);
  private Dictionary<int, UnityEngine.Object> m_HeroTemp = new Dictionary<int, UnityEngine.Object>(25);
  public uint m_ui32Tcik;
  private static byte[] RecvBufferLeft;
  private static byte[] RecvBufferRight;
  private static byte[] BufferForServer;
  private int m_MaxSkillList;
  private int m_MaxSkillWorkingList;
  private static int[] m_MaxSkillIdTemp;
  private uint m_HitContainer;
  private byte m_HitContainerSide;
  private int m_CurUltraIndex = -1;
  private GameObject ultraLoopParticle;
  public float PJ_FireRadius;
  public float PJ_FireRange;
  public int lastNearestTargetIndex = -1;
  private ulong m_StateUpdateFlag;
  private ushort m_RewardOffset;
  private ushort m_DropRewardCount;
  private ushort m_RewardCount;
  private byte m_RewardRandomFlag = 9;
  private byte[] m_DropPerEnemy = new byte[20];
  private Vector3[] m_RewardRandomPos = new Vector3[9]
  {
    new Vector3(-1.5f, 0.0f, -1.5f),
    new Vector3(-1.5f, 0.0f, -3f),
    new Vector3(-1.5f, 0.0f, -4.5f),
    new Vector3(-3f, 0.0f, -1.5f),
    new Vector3(-3f, 0.0f, -3f),
    new Vector3(-3f, 0.0f, -4.5f),
    new Vector3(-4.5f, 0.0f, -1.5f),
    new Vector3(-4.5f, 0.0f, -3f),
    new Vector3(-4.5f, 0.0f, -4.5f)
  };
  public float deltaTime;
  private float autoBattleDeltaTime;
  private float fixMoveDeltaTime;
  private float canMoveDeltaTime;
  public float maxSkillTimeCache;
  private byte closetHeroIndexCache;
  private bool bUseTimeCache;
  public static bool AutoBattleFlag = false;
  private bool bAutoBattle;
  private BSInvokeUtil BSUtil;
  private ChaseManager ChaseMgr;
  private BattleCamera BCamera = new BattleCamera();
  public static byte CameraModel = 0;
  public static bool IsPVPDefSide = false;
  private byte m_BattleResult;
  public BattleController.BattleState m_BattleState;
  public byte m_SubStateFlag;
  public bool IsBattleEnd;
  public bool NextLevelWorking;
  public HeroTeam[] teamTable = new HeroTeam[3];
  public int m_MaxStageLevel;
  public int m_CurStageLevel;
  public Transform mapObject1;
  public Transform mapObject2;
  private List<Transform>[] soundList = new List<Transform>[10];
  private CHashTable<ushort, int> soundPlayMap = new CHashTable<ushort, int>(10);
  private int m_LastSoundListIdx;
  private bool m_bSoundDirty;
  public int hitSoundTriggerRate;
  public int hitSoundRateBase;
  public float m_StateSkinTimeLen;
  public int m_StateSkinFlag = 1;
  public float m_StateSkinTimer;
  private int[] m_SkinColorLightmapIndex = new int[4];
  private Texture2D[] m_SkinColorLightmapTex = new Texture2D[4];
  public UIBattle uiBattle;
  public int ProjectorABKey;
  public Transform projector_parent;
  public ShadowProjector sp_projector;
  public ShadowProjector sp_projector_dist;
  public MeshFilter sp_projector_line;
  public Transform sp_projector_transform;
  public Transform sp_projector_line_transform;
  public Transform newbie_projector_parent;
  public Transform newbie_projector_transform;
  public ShadowProjector newbie_projector;
  public MeshFilter newbie_projector_line;
  public Transform newbie_projector_line_transform;
  public BattleControllerPanel controlPanel;
  private BattleController.MSNode[] ms_viewer = new BattleController.MSNode[5];
  private byte ultraHitSoundKey = byte.MaxValue;
  private float? UltraNewbieDelay;
  private byte NewbieUltraTimes;
  public List<AnimationUnit> m_SupportDisplayList = new List<AnimationUnit>(10);
  public uint DramaTriggerFlag;
  public bool bDramaWorking;
  private int shadowABKey;
  private HeroBattleData tempBattleData = new HeroBattleData();
  private HeroBattleData[] heroBattleData;
  private int MonsterIdxTemp;
  public bool IsReplay_PVP;
  public AnimationUnit PVPWatcher;
  public readonly ushort[] PVPWatcherList = new ushort[64]
  {
    (ushort) 1,
    (ushort) 2,
    (ushort) 3,
    (ushort) 4,
    (ushort) 5,
    (ushort) 6,
    (ushort) 7,
    (ushort) 8,
    (ushort) 9,
    (ushort) 10,
    (ushort) 11,
    (ushort) 12,
    (ushort) 13,
    (ushort) 14,
    (ushort) 15,
    (ushort) 16,
    (ushort) 17,
    (ushort) 18,
    (ushort) 19,
    (ushort) 20,
    (ushort) 21,
    (ushort) 22,
    (ushort) 23,
    (ushort) 24,
    (ushort) 25,
    (ushort) 26,
    (ushort) 27,
    (ushort) 28,
    (ushort) 29,
    (ushort) 30,
    (ushort) 100,
    (ushort) 192,
    (ushort) 193,
    (ushort) 194,
    (ushort) 195,
    (ushort) 196,
    (ushort) 197,
    (ushort) 199,
    (ushort) 201,
    (ushort) 202,
    (ushort) 203,
    (ushort) 204,
    (ushort) 205,
    (ushort) 206,
    (ushort) 207,
    (ushort) 208,
    (ushort) 209,
    (ushort) 210,
    (ushort) 211,
    (ushort) 212,
    (ushort) 213,
    (ushort) 214,
    (ushort) 215,
    (ushort) 216,
    (ushort) 217,
    (ushort) 218,
    (ushort) 219,
    (ushort) 220,
    (ushort) 224,
    (ushort) 225,
    (ushort) 226,
    (ushort) 227,
    (ushort) 228,
    (ushort) 230
  };
  public static EGambleMode GambleMode = EGambleMode.Normal;
  public static int GambleResult = 0;
  public long GambleTimeCache;
  public bool CasinoHitDirty;
  public bool bIgnoreSupport;
  public AnimationUnit SupportAU;
  public int SupportIdx;
  public ushort CurrentStageID;
  private Fader fader;

  public static byte[] EventBuffer => BattleController.BufferForServer;

  public int MaxSkillBitList => this.m_MaxSkillList;

  public uint HitContainer => this.m_HitContainer;

  public bool StartAutoBattle
  {
    get => this.bAutoBattle;
    set
    {
      this.bAutoBattle = value;
      BattleController.AutoBattleFlag = value;
      if (this.bAutoBattle)
      {
        this.autoBattleDeltaTime = 0.0f;
        if (this.m_BattleState != BattleController.BattleState.BATTLE_FINISHED)
          return;
        this.movePlayerOutside();
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.Battle);
      }
      else
      {
        if (this.m_BattleState != BattleController.BattleState.BATTLE_AUTOBATTLE_WAITING)
          return;
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 6, 1);
        this.m_BattleState = BattleController.BattleState.BATTLE_FINISHED;
      }
    }
  }

  public bool IsMaxSkillWorking => this.m_MaxSkillWorkingList != 0;

  public static bool IsActive => GameManager.ActiveGameplay is BattleController;

  public static bool IsGambleMode
  {
    get
    {
      return BattleController.IsActive && ((BattleController) GameManager.ActiveGameplay).IsType(EBattleType.GAMBLE);
    }
  }

  public static bool IsDareMode
  {
    get
    {
      return BattleController.IsActive && ((BattleController) GameManager.ActiveGameplay).IsType(EBattleType.NORMAL) && DataManager.StageDataController._stageMode == StageMode.Dare;
    }
  }

  ~BattleController()
  {
  }

  protected override void UpdateNews(byte[] meg)
  {
    GAME_PLAYER_NEWS gamePlayerNews = (GAME_PLAYER_NEWS) meg[0];
    switch (gamePlayerNews)
    {
      case GAME_PLAYER_NEWS.Network_Update:
        if (meg[1] == (byte) 15)
        {
          GUIManager.Instance.pDVMgr.NextTransitions(eTrans.FORCEEND, eTransFunc.MapToBattle);
          this.m_BattleState = BattleController.BattleState.BATTLE_STOP;
          if (this.IsType(EBattleType.NORMAL))
            BattleNetwork.NetworkError = (byte) 1;
          GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
          break;
        }
        if (meg[1] == (byte) 35)
        {
          if (!RewardManager.getInstance.IsWorking)
            break;
          RewardManager.getInstance.FontRefresh();
          break;
        }
        if (meg[1] != (byte) 0)
          break;
        if (this.IsType(EBattleType.GAMBLE))
        {
          Time.timeScale = 1f;
          break;
        }
        if (DataManager.Instance.BattleSeqID == 0UL || (long) DataManager.Instance.RoleAttr.BattleID != (long) DataManager.Instance.BattleSeqID || BattleNetwork.SendBattleEndStatus != (byte) 2)
          break;
        BattleNetwork.SendBattleEndStatus = (byte) 1;
        break;
      case GAME_PLAYER_NEWS.HeroTalk_Close:
        this.CloseDrama();
        break;
      default:
        if (gamePlayerNews != GAME_PLAYER_NEWS.BATTLE_PVPFadeOut || this.m_BattleState != BattleController.BattleState.WAITING_FOR_START || this.m_SubStateFlag == (byte) 2)
          break;
        this.m_SubStateFlag = (byte) 2;
        break;
    }
  }

  protected override void UpdateNext(byte[] meg)
  {
    if ((UnityEngine.Object) this.controlPanel != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) ((Component) this.controlPanel).gameObject);
      this.controlPanel = (BattleControllerPanel) null;
    }
    if ((UnityEngine.Object) this.fader != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) ((Component) this.fader).gameObject);
      this.fader = (Fader) null;
    }
    if ((UnityEngine.Object) this.projector_parent != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.projector_parent.gameObject);
      this.projector_parent = (Transform) null;
    }
    if ((UnityEngine.Object) this.sp_projector_dist != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.sp_projector_dist.gameObject);
      this.sp_projector_dist = (ShadowProjector) null;
    }
    if ((UnityEngine.Object) this.sp_projector_line_transform != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.sp_projector_line_transform.gameObject);
      this.sp_projector_line_transform = (Transform) null;
    }
    if ((UnityEngine.Object) this.newbie_projector_parent != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.newbie_projector_parent.gameObject);
      this.newbie_projector_parent = (Transform) null;
    }
    if ((UnityEngine.Object) this.newbie_projector_line_transform != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.newbie_projector_line_transform.gameObject);
      this.newbie_projector_line_transform = (Transform) null;
    }
    if (this.ProjectorABKey != 0)
    {
      AssetManager.UnloadAssetBundle(this.ProjectorABKey);
      this.ProjectorABKey = 0;
    }
    AudioManager.Instance.RetrieveSFX();
    if (this.playerUnit != null)
    {
      for (int index = 0; index < this.playerCount; ++index)
      {
        ModelLoader.Instance.Unload((UnityEngine.Object) this.playerUnit[index].gameObject);
        this.playerUnit[index] = (AnimationUnit) null;
      }
    }
    if (this.enemyUnit != null)
    {
      for (int index = 0; index < this.enemyCount; ++index)
      {
        ModelLoader.Instance.Unload((UnityEngine.Object) this.enemyUnit[index].gameObject);
        this.enemyUnit[index] = (AnimationUnit) null;
      }
    }
    if ((UnityEngine.Object) this.PVPWatcher != (UnityEngine.Object) null)
    {
      ModelLoader.Instance.Unload((UnityEngine.Object) this.PVPWatcher.gameObject);
      this.PVPWatcher = (AnimationUnit) null;
    }
    ModelLoader.Instance.Clear();
    this.m_HeroMap.Keys.CopyTo(this.m_HeroIDFilter, 0);
    this.m_IDFilterCount = this.m_HeroMap.Keys.Count;
    for (int index = 0; index < this.m_IDFilterCount; ++index)
      AssetManager.UnloadAssetBundle(this.m_HeroMap[this.m_HeroIDFilter[index]].assetKey);
    this.m_HeroMap.Clear();
    this.BSUtil = (BSInvokeUtil) null;
    this.ClearUpdateDelegates();
    ChaseManager.Instance.DestroyAll();
    RewardManager.getInstance.Free();
    this.BCamera = (BattleCamera) null;
    GUIManager.Instance.pDVMgr.EndFightClear();
    ParticleManager.Instance.Clear();
    AssetManager.QuitScene();
    DataManager.StageDataController.ReBackCurrentChapter();
    if (this.shadowABKey != 0)
    {
      AssetManager.UnloadAssetBundle(this.shadowABKey);
      this.shadowABKey = 0;
    }
    DataManager.Instance.BattleSeqID = 0UL;
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Battle);
    GUIManager.Instance.EmojiManager.Clear();
  }

  protected override void UpdateLoad(byte[] meg)
  {
    GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Battle);
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_ArenaBattle);
    GameManager.RegisterObserver((byte) 1, (byte) 0, (IObserver) this);
    DataManager instance1 = DataManager.Instance;
    instance1.battleInfo.PrimarySide = (byte) 0;
    if (NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
    {
      this.BattleType = EBattleType.TEACH;
      instance1.heroBattleData[0].AttrData.LV = (byte) 1;
      instance1.heroBattleData[0].AttrData.Enhance = (byte) 1;
      instance1.heroBattleData[0].AttrData.Equip = (byte) 0;
      instance1.heroBattleData[0].AttrData.Star = (byte) 1;
      instance1.heroBattleData[0].AttrData.SkillLV1 = (byte) 4;
      instance1.heroBattleData[0].AttrData.SkillLV2 = (byte) 0;
      instance1.heroBattleData[0].AttrData.SkillLV3 = (byte) 0;
      instance1.heroBattleData[0].AttrData.SkillLV4 = (byte) 0;
      instance1.heroBattleData[1].AttrData.LV = (byte) 1;
      instance1.heroBattleData[1].AttrData.Enhance = (byte) 1;
      instance1.heroBattleData[1].AttrData.Equip = (byte) 0;
      instance1.heroBattleData[1].AttrData.Star = (byte) 1;
      instance1.heroBattleData[1].AttrData.SkillLV1 = (byte) 1;
      instance1.heroBattleData[1].AttrData.SkillLV2 = (byte) 0;
      instance1.heroBattleData[1].AttrData.SkillLV3 = (byte) 0;
      instance1.heroBattleData[1].AttrData.SkillLV4 = (byte) 0;
      instance1.battleInfo.RandomGap = (ushort) 75;
      instance1.battleInfo.RandomSeed = (ushort) 600;
    }
    else if (NewbieManager.IsNewbie)
    {
      this.BattleType = EBattleType.NEWBIE_FAKE;
    }
    else
    {
      switch (BattleController.BattleMode)
      {
        case EBattleMode.Monster:
          this.BattleType = EBattleType.PLAYBACK;
          GUIManager instance2 = GUIManager.Instance;
          ushort teamId1 = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(instance2.WM_MonsterID).MapTeamInfo[(int) instance2.WM_MonsterLv - 1].TeamID;
          instance1.battleInfo.StageID = teamId1;
          instance1.battleInfo.BattleType = (byte) 2;
          instance1.battleInfo.StageKind = (byte) 0;
          instance1.battleInfo.RandomSeed = instance2.WM_RandomSeed;
          instance1.battleInfo.RandomGap = (ushort) instance2.WM_RandomGap;
          break;
        case EBattleMode.PVP:
        case EBattleMode.PVP_Replay:
          this.BattleType = EBattleType.PVP;
          this.IsReplay_PVP = BattleController.BattleMode != EBattleMode.PVP;
          instance1.battleInfo.StageID = (ushort) 0;
          instance1.battleInfo.BattleType = (byte) 3;
          instance1.battleInfo.StageKind = (byte) 0;
          instance1.battleInfo.RandomSeed = ArenaManager.Instance.ArenaPlayingData.RandomSeed;
          instance1.battleInfo.RandomGap = (ushort) ArenaManager.Instance.ArenaPlayingData.RandomGap;
          instance1.battleInfo.PrimarySide = ArenaManager.Instance.ArenaPlayingData.PrimarySide;
          break;
        case EBattleMode.Gambling:
          this.BattleType = EBattleType.GAMBLE;
          BattleNetwork.GambleGetRandomHero();
          GamblingManager instance3 = GamblingManager.Instance;
          BattleController.GambleMode = instance3.GambleMode != UIBattle_Gambling.eMode.Normal ? EGambleMode.Turbo : EGambleMode.Normal;
          ushort teamId2 = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(instance3.BattleMonsterID).MapTeamInfo[0].TeamID;
          instance1.battleInfo.StageID = teamId2;
          instance1.battleInfo.BattleType = (byte) 5;
          instance1.battleInfo.StageKind = (byte) 0;
          instance1.battleInfo.RandomSeed = (ushort) 1;
          instance1.battleInfo.RandomGap = (ushort) 1;
          BattleController.CameraModel = (byte) 0;
          break;
      }
    }
    BattleController.BattleMode = EBattleMode.Default;
    BattleController.IsPVPDefSide = false;
    if (this.IsType(EBattleType.PLAYBACK))
    {
      this.heroBattleData = GUIManager.Instance.WM_HeroData;
      this.playerCount = (int) GUIManager.Instance.WM_HeroCount;
    }
    else if (this.IsType(EBattleType.GAMBLE))
    {
      this.heroBattleData = GamblingManager.Instance.BattleHeroData;
      this.playerCount = (int) GamblingManager.Instance.BattleHeroCount;
    }
    else if (this.IsType(EBattleType.PVP))
    {
      this.heroBattleData = new HeroBattleData[5];
      this.playerCount = 0;
      this.enemyCount = 0;
      for (int index = 0; index < 5; ++index)
      {
        this.heroBattleData[index] = (HeroBattleData) ArenaManager.Instance.ArenaPlayingData.MyHeroData[index];
        if (this.heroBattleData[index].HeroID != (ushort) 0)
          ++this.playerCount;
        if (ArenaManager.Instance.ArenaPlayingData.EnemyHeroData[index].ID != (ushort) 0)
          ++this.enemyCount;
      }
      if (((int) ArenaManager.Instance.ArenaPlayingData.Flag & 2) == 0)
        BattleController.IsPVPDefSide = true;
    }
    else
    {
      this.heroBattleData = DataManager.Instance.heroBattleData;
      this.playerCount = (int) DataManager.Instance.heroCount;
    }
    if (this.IsType(EBattleType.NEWBIE_FAKE) || this.IsType(EBattleType.PLAYBACK) || this.IsType(EBattleType.PVP) || this.IsType(EBattleType.GAMBLE) || BattleController.IsDareMode)
    {
      Array.Clear((Array) instance1.RewardLen, 0, 4);
      Array.Clear((Array) instance1.RewardData, 0, 128);
      instance1.RewardCount = 0;
    }
    this.BSUtil = BSInvokeUtil.getInstance;
    this.BSUtil.SetUserData(DataManager.Instance.RoleAttr.UserId, DataManager.Instance.BattleSeqID);
    this.BSUtil.InitSimulator(ref DataManager.Instance.battleInfo);
    DataManager.Instance.lastBattleResult = (short) -1;
    if (this.IsType(EBattleType.PVP))
      this.BSUtil.SetArenaTopic(ArenaManager.Instance.ArenaPlayingData.TopicID[0], ArenaManager.Instance.ArenaPlayingData.TopicID[1], ArenaManager.Instance.ArenaPlayingData.TopicEffect[0], ArenaManager.Instance.ArenaPlayingData.TopicEffect[1]);
    this.deltaTime = 0.0f;
    this.autoBattleDeltaTime = 0.0f;
    if (BattleController.RecvBufferLeft == null)
      BattleController.RecvBufferLeft = new byte[1024];
    if (BattleController.RecvBufferRight == null)
      BattleController.RecvBufferRight = new byte[1024];
    if (BattleController.BufferForServer == null)
      BattleController.BufferForServer = new byte[1024];
    if (BattleController.m_MaxSkillIdTemp == null)
      BattleController.m_MaxSkillIdTemp = new int[25];
    for (int index = 0; index < 10; ++index)
      this.soundList[index] = new List<Transform>(25);
    this.FirstPlayerPosX = (float) DataManager.Instance.ArrayTable.GetRecordByKey((ushort) 1).HeroArrayInfo[0].posX * 0.01f;
    ParticleManager.Instance.Setup();
    this.CurrentStageID = this.loadBattleInfo();
    AssetManager.LoadScene(this.CurrentStageID);
    if (this.IsType(EBattleType.PVP))
    {
      long Time = ArenaManager.Instance.ArenaPlayingData.Time;
      if (Time == 0L)
        Time = instance1.ServerTime;
      int hour = GameConstants.GetDateTime(Time).Hour;
      AssetManager.LoadStage(hour < 14 || hour >= 20 ? (hour >= 20 || hour < 5 ? (byte) 2 : (byte) 1) : (byte) 3, ref this.mapObject1, ref this.mapObject2);
    }
    else
      AssetManager.LoadStage((byte) 1, ref this.mapObject1, ref this.mapObject2);
    this.CheckSetDareDifficulty();
    this.BSUtil.setHeroOver(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
    this.decodeHeroAttribute(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
    this.ChaseMgr = ChaseManager.Instance;
    this.BCamera.initCamera(this.playerUnit, this.playerCount, this.enemyUnit, this.enemyCount);
    int num1;
    int num2;
    if (this.BattleType == EBattleType.PLAYBACK)
    {
      num1 = (int) GUIManager.Instance.WM_MonsterLv << 16 | (int) GUIManager.Instance.WM_MonsterID;
      num2 = this.MonsterIdxTemp;
    }
    else
    {
      num1 = 0;
      num2 = 0;
    }
    this.uiBattle = (UIBattle) GUIManager.Instance.OpenMenu(EGUIWindow.UI_Battle, num1, num2);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 8);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 10, 1);
    if (this.IsType(EBattleType.PVP))
      GUIManager.Instance.OpenPvPUI();
    else if (this.IsType(EBattleType.NEWBIE_FAKE))
    {
      this.uiBattle.gameObject.SetActive(false);
      GUIManager.Instance.HideChatBox();
    }
    else if (this.IsType(EBattleType.GAMBLE))
    {
      this.uiBattle.gameObject.SetActive(false);
      GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_Battle_Gambling);
    }
    if (this.IsType(EBattleType.GAMBLE))
      RewardManager.getInstance.Init();
    else
      RewardManager.getInstance.Init();
    GameObject gameObject1 = new GameObject("Catcher");
    gameObject1.layer = 5;
    GUIManager.Instance.StretchTransform(gameObject1.AddComponent<RectTransform>());
    gameObject1.transform.SetParent(((Component) GUIManager.Instance.m_UICanvas).transform, false);
    gameObject1.transform.SetAsFirstSibling();
    this.controlPanel = gameObject1.AddComponent<BattleControllerPanel>();
    this.controlPanel.sprite = (Sprite) null;
    ((MaskableGraphic) this.controlPanel).material = GUIManager.Instance.m_IconSpriteAsset.GetMaterial();
    ((Graphic) this.controlPanel).color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    this.controlPanel.battleController = this;
    if (BattleController.IsDareMode)
    {
      GameObject gameObject2 = new GameObject("Fader");
      gameObject2.layer = 5;
      RectTransform tran = gameObject2.AddComponent<RectTransform>();
      GUIManager.Instance.StretchTransform(tran);
      gameObject2.transform.SetParent((Transform) GUIManager.Instance.m_FourthWindowLayer, false);
      gameObject2.AddComponent<IgnoreRaycast>();
      this.fader = gameObject2.AddComponent<Fader>();
      this.fader.sprite = (Sprite) null;
      ((MaskableGraphic) this.fader).material = GUIManager.Instance.m_IconSpriteAsset.GetMaterial();
      this.fader.Reset();
      if (GUIManager.Instance.bOpenOnIPhoneX)
      {
        tran.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
        tran.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      }
    }
    if (this.IsType(EBattleType.GAMBLE))
      ((Component) this.controlPanel).gameObject.SetActive(false);
    AssetManager.Instance.AssetManagerState = AssetState.Ready;
    this.BCamera.updateCamera(this.playerUnit, this.playerCount, this.enemyUnit, this.enemyCount);
    GUIManager.Instance.pDVMgr.BeginFightInitial();
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
    int num3 = 5;
    for (int index = 0; index < 4; ++index)
    {
      this.m_SkinColorLightmapIndex[index] = LightmapManager.Instance.GetLightmapIndex((Lightmap_Enum) (num3 + index));
      this.m_SkinColorLightmapTex[index] = LightmapManager.Instance.GetLightmapTexture((Lightmap_Enum) (num3 + index));
    }
    this.ProjectorABKey = 0;
    AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/BCProjector", out this.ProjectorABKey);
    UnityEngine.Object[] objectArray = assetBundle.LoadAll(typeof (Sprite));
    float num4 = 1f / (float) ((Sprite) objectArray[0]).texture.height;
    for (int index = 0; index < 8; ++index)
    {
      Rect textureRect = ((Sprite) objectArray[index]).textureRect;
      this.ProjectorUV[index] = new Rect(textureRect.x * num4, textureRect.y * num4, textureRect.width * num4, textureRect.height * num4);
    }
    GameObject gameObject3 = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
    Material sharedMaterial = gameObject3.GetComponent<MeshRenderer>().sharedMaterial;
    this.sp_projector_line = gameObject3.GetComponent<MeshFilter>();
    this.sp_projector_line.mesh = GameConstants.CreatePlane(Vector3.up, Vector3.right, this.ProjectorUV[7], Color.white, 10f);
    this.sp_projector_line_transform = gameObject3.transform;
    gameObject3.SetActive(false);
    GameObject gameObject4 = new GameObject("SP");
    this.sp_projector = gameObject4.AddComponent<ShadowProjector>();
    this.sp_projector.SetShadowProjectorMaterial(sharedMaterial);
    this.sp_projector.ShadowOpacity = 1f;
    this.sp_projector.ShadowSize = 1f;
    this.projector_parent = new GameObject("SP_P").transform;
    this.projector_parent.position = new Vector3(0.0f, 0.01f, 0.0f);
    this.sp_projector.transform.parent = this.projector_parent;
    this.sp_projector.transform.localPosition = Vector3.zero;
    this.sp_projector_transform = gameObject4.transform.GetChild(0);
    this.sp_projector_transform.Rotate(90f, 0.0f, 0.0f);
    gameObject4.SetActive(false);
    if (this.IsType(EBattleType.TEACH))
    {
      GameObject gameObject5 = new GameObject("SP_Teach");
      this.newbie_projector = gameObject5.AddComponent<ShadowProjector>();
      this.newbie_projector.SetShadowProjectorMaterial(sharedMaterial);
      this.newbie_projector.ShadowOpacity = 0.3f;
      this.newbie_projector.ShadowSize = 1f;
      this.newbie_projector_parent = new GameObject("SP_P_Teach").transform;
      this.newbie_projector_parent.position = new Vector3(0.0f, 0.005f, 0.0f);
      this.newbie_projector.transform.parent = this.newbie_projector_parent;
      this.newbie_projector.transform.localPosition = Vector3.zero;
      this.newbie_projector_transform = gameObject5.transform.GetChild(0);
      this.newbie_projector_transform.Rotate(90f, 0.0f, 0.0f);
      gameObject5.SetActive(false);
      GameObject gameObject6 = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
      gameObject6.GetComponent<MeshRenderer>();
      this.newbie_projector_line = gameObject6.GetComponent<MeshFilter>();
      this.newbie_projector_line.mesh = GameConstants.CreatePlane(Vector3.up, Vector3.right, this.ProjectorUV[7], new Color(1f, 1f, 1f, 0.3f), 10f);
      this.newbie_projector_line_transform = gameObject6.transform;
      gameObject6.SetActive(false);
      NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, (object) this.uiBattle);
    }
    GameObject gameObject7 = new GameObject("SP_DIST");
    this.sp_projector_dist = gameObject7.AddComponent<ShadowProjector>();
    this.sp_projector_dist.SetShadowProjectorMaterial(sharedMaterial);
    this.sp_projector_dist.ShadowOpacity = 1f;
    this.sp_projector_dist.ShadowSize = 1f;
    this.sp_projector_dist.UVRect = this.ProjectorUV[0];
    gameObject7.transform.GetChild(0).Rotate(90f, 0.0f, 0.0f);
    gameObject7.SetActive(false);
    NewbieManager.AutoBattleFlag = false;
    if (this.IsType(EBattleType.NORMAL) && !NewbieManager.IsWorking() && ((Component) this.uiBattle.autoButtonUp).gameObject.activeSelf && NewbieManager.NeedTeach(ETeachKind.AUTO_BATTLE))
      NewbieManager.AutoBattleFlag = true;
    if ((ushort) (this.DramaTriggerFlag & (uint) ushort.MaxValue) == (ushort) 0 && this.IsType(EBattleType.NORMAL) && !NewbieManager.IsWorking() && ((Component) this.uiBattle.autoButtonUp).gameObject.activeSelf)
      NewbieManager.EntryTeach(ETeachKind.AUTO_BATTLE);
    if (this.IsType(EBattleType.PVP))
      this.SetupPVPOutsideNPC();
    if (this.IsType(EBattleType.NORMAL))
    {
      int count1 = GUIManager.Instance.m_WindowStack.Count;
      for (int index = 0; index < count1; ++index)
      {
        if (GUIManager.Instance.m_WindowStack[index].m_eWindow == EGUIWindow.UI_BattleHeroSelect)
          GUIManager.Instance.m_WindowStack.RemoveAt(index);
      }
      int count2 = GUIManager.Instance.m_WindowStack.Count;
      for (int index = 0; index < count2; ++index)
      {
        if (GUIManager.Instance.m_WindowStack[index].m_eWindow == EGUIWindow.UI_StageInfo)
          GUIManager.Instance.m_WindowStack.RemoveAt(index);
      }
    }
    this.m_BattleState = BattleController.BattleState.WAITING_FOR_START;
  }

  protected override void UpdateReady(byte[] meg)
  {
    if (!BattleController.IsGambleMode)
      return;
    GUIManager.Instance.m_HUDMessage.MapHud.AddGambleMsg();
    GUIManager.Instance.m_HUDMessage.MapHud.ShowMsg();
    GUIManager.Instance.m_HUDMessage.MapHud.ShowTime = 1.3f;
    GUIManager.Instance.m_HUDMessage.MapHud.StartCountdown();
  }

  protected override void UpdateRun(byte[] meg)
  {
    if (this.m_BattleState == BattleController.BattleState.BATTLE_STOP)
      return;
    float smoothDeltaTime = Time.smoothDeltaTime;
    this.deltaTime += smoothDeltaTime;
    this.autoBattleDeltaTime += smoothDeltaTime;
    this.m_StateSkinTimer += smoothDeltaTime;
    float num1 = 0.0f;
    if (this.bUseTimeCache)
    {
      this.deltaTime = this.maxSkillTimeCache;
      this.bUseTimeCache = false;
    }
    if ((double) this.deltaTime >= 0.10000000149011612)
    {
      if (this.m_BattleState == BattleController.BattleState.WAITING_FOR_START)
      {
        if ((double) this.deltaTime >= 1.1000000238418579)
        {
          if (this.IsType(EBattleType.PVP))
          {
            if (this.m_SubStateFlag == (byte) 0)
            {
              GUIManager.Instance.BeginPvPOpening();
              this.m_SubStateFlag = (byte) 1;
            }
            else if (this.m_SubStateFlag != (byte) 1)
              ;
          }
          else if (this.m_SubStateFlag == (byte) 0)
          {
            ushort num2 = (ushort) (this.DramaTriggerFlag & (uint) ushort.MaxValue);
            if (num2 != (ushort) 0)
            {
              if (this.IsType(EBattleType.TEACH))
                NewbieManager.SetNewbieControlLock(false);
              GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, (int) num2, (int) this.heroBattleData[0].HeroID);
              if ((UnityEngine.Object) this.controlPanel != (UnityEngine.Object) null)
                ((Component) this.controlPanel).gameObject.SetActive(false);
              this.DramaTriggerFlag &= 4294901760U;
              this.bDramaWorking = true;
              this.m_SubStateFlag = (byte) 1;
            }
            else
              this.m_SubStateFlag = (byte) 2;
          }
          else if (this.m_SubStateFlag == (byte) 1 && !this.bDramaWorking)
          {
            this.m_SubStateFlag = (byte) 2;
            if (this.IsType(EBattleType.NORMAL) && !NewbieManager.IsWorking() && ((Component) this.uiBattle.autoButtonUp).gameObject.activeSelf)
              NewbieManager.EntryTeach(ETeachKind.AUTO_BATTLE);
          }
        }
        if (this.m_SubStateFlag == (byte) 2)
        {
          this.m_BattleState = BattleController.BattleState.BATTLE_RUNNING;
          this.deltaTime = 0.0f;
          this.m_SubStateFlag = (byte) 0;
          if (NewbieManager.IsTeachWorking(ETeachKind.AUTO_BATTLE))
            NewbieManager.CheckTeach(ETeachKind.AUTO_BATTLE, (object) this.uiBattle);
          else if (NewbieManager.IsTeachWorking(ETeachKind.GAMBLING1))
            NewbieManager.CheckTeach(ETeachKind.GAMBLING1);
          else if (NewbieManager.IsTeachWorking(ETeachKind.GAMBLING2))
            NewbieManager.CheckTeach(ETeachKind.GAMBLING2);
          else
            NewbieManager.CheckGambleElite();
        }
      }
      else if (this.m_BattleState == BattleController.BattleState.BATTLE_RUNNING)
      {
        if (this.m_MaxSkillList != 0)
          this.m_MaxSkillList = 0;
        BattleController.RecvBufferLeft[0] = (byte) 0;
        BattleController.RecvBufferRight[0] = (byte) 0;
        this.m_BattleResult = this.BSUtil.updateBattleData(this.m_ui32Tcik, BattleController.RecvBufferLeft, BattleController.RecvBufferRight, BattleController.BufferForServer);
        ++this.m_ui32Tcik;
        if (this.IsType(EBattleType.GAMBLE) && BattleController.GambleResult != 0)
          this.m_BattleResult = (byte) BattleController.GambleResult;
        this.deltaTime -= 0.1f;
        num1 = Mathf.Min(0.1f, this.deltaTime);
        this.fixMoveDeltaTime = num1;
        this.canMoveDeltaTime = 0.1f;
        if (!this.IsType(EBattleType.PLAYBACK) && !this.IsType(EBattleType.PVP) || !this.decodeUltraSkill(BattleController.BufferForServer) || this.m_BattleResult != (byte) 0)
          this.decodeSimuPackage(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
        if (this.IsType(EBattleType.GAMBLE) && this.CasinoHitDirty)
        {
          this.PlayGambleHitEffect();
          this.CasinoHitDirty = false;
        }
        if (this.m_bHPMPDirty != (byte) 0)
        {
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 1);
          this.m_bHPMPDirty = (byte) 0;
        }
        if (this.m_StateUpdateFlag != 0UL)
        {
          this.updateSkillState();
          this.m_StateUpdateFlag = 0UL;
        }
        if (this.m_IDFilterCount > 0)
        {
          for (int index = 0; index < 25; ++index)
          {
            if (this.m_HeroIDFilter[index] != 0)
            {
              uint iValue = (uint) this.m_HeroIDFilter[index];
              this.m_HeroIDFilter[index] = 0;
              int Side = 0;
              int iIndex = index;
              if (index > 4)
              {
                Side = 1;
                iIndex = 25 - index - 1;
              }
              GUIManager.Instance.pDVMgr.AddDamageValueEffect(iValue, Side, iIndex, HERO_EFFECTTYPE_ENUM.HERO_EFFECT_HEMOPHAGIA);
            }
          }
          this.m_IDFilterCount = 0;
        }
        uint num3 = !BattleController.IsPVPDefSide ? this.BSUtil.checkUltraCondition() : this.BSUtil.checkRightUltraCondition();
        for (int btnIdx = 0; btnIdx < 5; ++btnIdx)
        {
          if (this.ms_viewer[btnIdx].working != (byte) 0 && !((UnityEngine.Object) this.playerUnit[btnIdx] == (UnityEngine.Object) null) && this.playerUnit[btnIdx].enabled)
          {
            if (((int) (num3 >> btnIdx) & 1) != 0)
            {
              if (this.ms_viewer[btnIdx].ui_state == (byte) 0)
              {
                this.ms_viewer[btnIdx].ui_state = (byte) 1;
                this.uiBattle.SetBtnTween(btnIdx, 1);
              }
            }
            else if (this.ms_viewer[btnIdx].ui_state == (byte) 1)
            {
              this.ms_viewer[btnIdx].ui_state = (byte) 0;
              this.uiBattle.SetBtnTween(btnIdx, 0);
            }
          }
        }
        if (this.m_bSoundDirty)
        {
          Transform transform = Camera.main.transform;
          for (int index1 = 0; index1 < this.soundPlayMap.Length; ++index1)
          {
            ushort key = this.soundPlayMap.Keys[index1];
            if (key != (ushort) 0)
            {
              int index2 = this.soundPlayMap.Values[index1];
              int index3 = -1;
              float num4 = 0.0f;
              for (int index4 = 0; index4 < this.soundList[index2].Count; ++index4)
              {
                float num5 = Vector3.Distance(transform.position, this.soundList[index2][index4].position);
                if (index3 == -1 || (double) num5 < (double) num4)
                {
                  num4 = num5;
                  index3 = index4;
                }
              }
              AudioManager.Instance.PlaySFX(key, pitchkind: PitchKind.SpeechSound, PlayObj: this.soundList[index2][index3]);
              this.soundList[index2].Clear();
            }
          }
          this.soundPlayMap.Clear();
          this.m_LastSoundListIdx = 0;
          this.m_bSoundDirty = false;
        }
        if (this.m_BattleResult == (byte) 1 || this.m_BattleResult == (byte) 2)
        {
          this.m_BattleState = BattleController.BattleState.BATTLE_FINISHING;
          if (this.IsType(EBattleType.PVP))
            this.m_BattleResult = ((int) ArenaManager.Instance.ArenaPlayingData.Flag & 1) == 0 ? (byte) 2 : (byte) 1;
          this.bTimeUp = false;
          if (this.m_BattleResult == (byte) 2)
          {
            for (int index = 0; index < this.playerCount; ++index)
            {
              if (this.playerUnit[index].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
              {
                this.bTimeUp = true;
                break;
              }
            }
          }
        }
      }
      else if (this.m_BattleState == BattleController.BattleState.BATTLE_MAXSKILL_WORKING)
      {
        if (this.m_MaxSkillWorkingList == 0 && !this.uiBattle.ultraSkillWorking)
        {
          this.updateMaxSkillFreeze(false);
          this.UpdateSkillLightmap(false);
          this.bUseTimeCache = true;
          DamageValueManager pDvMgr = GUIManager.Instance.pDVMgr;
          for (int iIndex = 0; iIndex < this.playerCount; ++iIndex)
            pDvMgr.HideBloodBar(0, iIndex);
          for (int iIndex = 0; iIndex < this.enemyCount; ++iIndex)
            pDvMgr.HideBloodBar(1, iIndex);
          this.m_BattleState = BattleController.BattleState.BATTLE_RUNNING;
          if (this.IsType(EBattleType.PLAYBACK))
            this.decodeSimuPackage(BattleController.RecvBufferLeft, BattleController.RecvBufferRight, 4);
          else if (this.IsType(EBattleType.PVP))
            this.decodeSimuPackage(BattleController.RecvBufferLeft, BattleController.RecvBufferRight, 12);
        }
      }
      else if (this.m_BattleState == BattleController.BattleState.BATTLE_CHECK_DIE_BEFORE_SUPPORT)
      {
        for (int index = 0; index < this.enemyCount; ++index)
        {
          if (this.enemyUnit[index].heroState == HERO_STATE_ENUM.HERO_COMMANDS_DIE && this.enemyUnit[index].DeadBodyHidingFlag == (byte) 3)
          {
            this.ExeSupport(this.SupportAU, this.SupportIdx);
            break;
          }
        }
      }
      else if (this.m_BattleState == BattleController.BattleState.BATTLE_SUPPORT_DISPLAY)
      {
        if (this.m_SubStateFlag == (byte) 0)
        {
          if ((double) this.deltaTime > 1.0)
          {
            for (int index = 0; index < this.m_SupportDisplayList.Count; ++index)
              this.m_SupportDisplayList[index].setState(HERO_STATE_ENUM.HERO_COMMANDS_SUPPORT_DISPLAY);
            this.m_SubStateFlag = (byte) 1;
          }
        }
        else if (this.m_SubStateFlag == (byte) 1)
        {
          for (int index = this.m_SupportDisplayList.Count - 1; index >= 0; --index)
          {
            if (this.m_SupportDisplayList[index].heroState != HERO_STATE_ENUM.HERO_COMMANDS_SUPPORT_DISPLAY)
            {
              this.m_SupportDisplayList[index].setMaxSkillFreeze(true);
              this.m_SupportDisplayList.RemoveAt(index);
            }
          }
          if (this.m_SupportDisplayList.Count == 0)
          {
            this.deltaTime = 0.0f;
            this.m_SubStateFlag = (byte) 2;
          }
        }
        else if ((double) this.deltaTime > 0.5)
        {
          this.updateSupportDisplayFreeze(false);
          this.deltaTime = 0.0f;
          this.m_BattleState = BattleController.BattleState.BATTLE_RUNNING;
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 4);
          if (this.IsType(EBattleType.GAMBLE))
          {
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 18);
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 15);
          }
        }
      }
      else if (this.m_BattleState == BattleController.BattleState.BATTLE_FINISHING)
      {
        this.m_MaxSkillWorkingList = 0;
        this.updateMaxSkillFreeze(false);
        this.UpdateSkillLightmap(false, true);
        AnimationUnit[] animationUnitArray1 = this.m_BattleResult != (byte) 2 ? this.playerUnit : this.enemyUnit;
        int num6 = this.m_BattleResult != (byte) 2 ? this.playerCount : this.enemyCount;
        for (int index = 0; index < num6; ++index)
        {
          if (animationUnitArray1[index].enabled)
          {
            if (animationUnitArray1[index].heroState == HERO_STATE_ENUM.HERO_COMMANDS_MOVE)
              animationUnitArray1[index].setState(HERO_STATE_ENUM.HERO_COMMANDS_IDLE);
            else if ((TrackedReference) animationUnitArray1[index].CurAnimState != (TrackedReference) null && animationUnitArray1[index].CurAnimState.wrapMode == WrapMode.Loop)
              animationUnitArray1[index].setState(HERO_STATE_ENUM.HERO_COMMANDS_IDLE, paramA: 50);
            else if (animationUnitArray1[index].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE && (UnityEngine.Object) animationUnitArray1[index].getAnimation != (UnityEngine.Object) null)
              animationUnitArray1[index].SetWaitIdle();
            animationUnitArray1[index].CleanStateDisplay();
            animationUnitArray1[index].cleanStateParticle();
          }
        }
        AnimationUnit[] animationUnitArray2 = this.m_BattleResult != (byte) 2 ? this.enemyUnit : this.playerUnit;
        BattleController.HeroAttr[] heroAttrArray = this.m_BattleResult != (byte) 2 ? this.enemyAttr : this.playerAttr;
        int num7 = this.m_BattleResult != (byte) 2 ? this.enemyCount : this.playerCount;
        HERO_STATE_ENUM state = !this.bTimeUp ? HERO_STATE_ENUM.HERO_COMMANDS_DIE : HERO_STATE_ENUM.HERO_COMMANDS_IDLE;
        for (int index = 0; index < num7; ++index)
        {
          if (animationUnitArray2[index].enabled && animationUnitArray2[index].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
          {
            animationUnitArray2[index].setState(state);
            if (state == HERO_STATE_ENUM.HERO_COMMANDS_DIE)
              heroAttrArray[index].CUR_HP = 0U;
            else if (!BattleController.IsDareMode || this.m_BattleResult != (byte) 2 || this.BSUtil.GetHeroChallengeFailedQuest() == (byte) 0)
            {
              animationUnitArray2[index].CleanStateDisplay();
              animationUnitArray2[index].cleanStateParticle();
            }
          }
        }
        this.deltaTime = 0.0f;
        this.m_BattleState = BattleController.BattleState.BATTLE_WAITTING_FOR_VICTORY;
      }
      else if (this.m_BattleState == BattleController.BattleState.BATTLE_FINISHING_SPREAD)
      {
        AnimationUnit[] animationUnitArray = this.m_BattleResult != (byte) 2 ? this.playerUnit : this.enemyUnit;
        int num8 = this.m_BattleResult != (byte) 2 ? this.playerCount : this.enemyCount;
        int num9 = 0;
        for (int index = 0; index < num8; ++index)
        {
          if (animationUnitArray[index].enabled && animationUnitArray[index].heroState == HERO_STATE_ENUM.HERO_COMMANDS_FINISHING_SPREAD)
            ++num9;
        }
        if (num9 == 0)
        {
          this.deltaTime = 0.0f;
          this.m_BattleState = BattleController.BattleState.BATTLE_WAITTING_FOR_VICTORY;
        }
      }
      else if (this.m_BattleState == BattleController.BattleState.BATTLE_WAITTING_FOR_VICTORY)
      {
        float num10 = !NewbieManager.IsNewbie ? 0.5f : 2.5f;
        if ((this.IsType(EBattleType.GAMBLE) || !RewardManager.getInstance.IsWorking) && (double) this.deltaTime >= (double) num10)
        {
          if (this.m_BattleResult == (byte) 2)
          {
            if (!this.IsType(EBattleType.GAMBLE))
            {
              for (int index = 0; index < this.enemyCount; ++index)
              {
                if (this.enemyUnit[index].enabled)
                {
                  this.enemyUnit[index].setState(HERO_STATE_ENUM.HERO_COMMANDS_VICTORY);
                  this.enemyUnit[index].StateEffList.Clear();
                  this.m_StateUpdateFlag |= (ulong) (1 << 10 + index);
                }
              }
            }
            else
            {
              for (int index = 0; index < this.enemyCount; ++index)
              {
                if (this.enemyUnit[index].enabled)
                {
                  Vector3 position = this.enemyUnit[index].Position with
                  {
                    x = !this.IsType(EBattleType.GAMBLE) ? -100f : 100f
                  };
                  this.enemyUnit[index].movePos = new Vector3?(position);
                  this.enemyUnit[index].Target = (GameObject) null;
                  this.enemyUnit[index].setState(HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_RUN);
                  this.enemyUnit[index].StateEffList.Clear();
                  this.m_StateUpdateFlag |= (ulong) (1 << 10 + index);
                }
              }
              if (this.IsType(EBattleType.GAMBLE))
                GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 14);
            }
            if (this.bTimeUp)
            {
              if (!this.IsType(EBattleType.GAMBLE))
              {
                byte challengeFailedQuest;
                if (!BattleController.IsDareMode || (challengeFailedQuest = this.BSUtil.GetHeroChallengeFailedQuest()) == (byte) 0)
                  this.movePlayerOutside(EMovePlayerOutside.BattleFailed);
                else
                  DataManager.Instance.BattleFailureIndex = challengeFailedQuest;
              }
              else
                this.movePlayerOutside(EMovePlayerOutside.GambleFailed);
            }
            else
              DataManager.Instance.BattleFailureIndex = (byte) 0;
            this.updateSkillState(true);
            this.m_StateUpdateFlag = 0UL;
            this.m_BattleState = BattleController.BattleState.BATTLE_SHOW_RESULT_UI;
          }
          else if (this.m_BattleResult == (byte) 1)
          {
            HERO_STATE_ENUM state = HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_IDLE;
            if (this.m_CurStageLevel == this.m_MaxStageLevel)
              state = HERO_STATE_ENUM.HERO_COMMANDS_VICTORY;
            for (int index = 0; index < this.playerCount; ++index)
            {
              if (this.playerUnit[index].enabled)
              {
                this.playerUnit[index].setState(state);
                this.playerUnit[index].StateEffList.Clear();
                this.m_StateUpdateFlag |= (ulong) (1 << index);
              }
            }
            this.updateSkillState(true);
            this.m_StateUpdateFlag = 0UL;
            if (this.IsType(EBattleType.GAMBLE) && (UnityEngine.Object) this.enemyUnit[1] != (UnityEngine.Object) null && this.enemyUnit[1].gameObject.activeSelf)
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 14);
            this.m_BattleState = BattleController.BattleState.BATTLE_SHOW_RESULT_UI;
          }
          if (this.m_BattleState == BattleController.BattleState.BATTLE_SHOW_RESULT_UI)
          {
            this.deltaTime = 1f;
            for (int btnIdx = 0; btnIdx < 5; ++btnIdx)
            {
              if (this.ms_viewer[btnIdx].working == (byte) 1)
              {
                this.ms_viewer[btnIdx].ui_state = (byte) 0;
                this.uiBattle.SetBtnTween(btnIdx, 0);
              }
            }
            if (this.CheckNextLevel())
            {
              if (this.m_BattleResult == (byte) 1)
              {
                if (!this.bAutoBattle)
                {
                  GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 6, 1);
                  this.m_BattleState = BattleController.BattleState.BATTLE_FINISHED;
                  if (this.IsType(EBattleType.TEACH))
                    NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, (object) this);
                }
                else
                  this.m_BattleState = BattleController.BattleState.BATTLE_AUTOBATTLE_WAITING;
              }
            }
            else
            {
              if (this.IsType(EBattleType.NORMAL) || this.IsType(EBattleType.TEACH))
              {
                if (this.m_BattleResult == (byte) 2)
                {
                  DataManager.Instance.lastBattleResult = (short) 0;
                  if ((UnityEngine.Object) this.fader != (UnityEngine.Object) null)
                    this.fader.Reset();
                }
                else
                  BattleNetwork.SendBattleEndStatus = (byte) 1;
              }
              else if (this.IsType(EBattleType.NEWBIE_FAKE))
              {
                Time.timeScale = 1f;
                GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, 3, 1);
                if ((UnityEngine.Object) this.controlPanel != (UnityEngine.Object) null)
                  ((Component) this.controlPanel).gameObject.SetActive(false);
                this.bDramaWorking = true;
                NewbieLog.Log(ENewbieLogKind.FORCE_1, (byte) 4);
                this.m_BattleState = BattleController.BattleState.BATTLE_STOP;
              }
              this.IsBattleEnd = true;
              this.m_SubStateFlag = (byte) 0;
            }
          }
        }
      }
      else if (this.m_BattleState == BattleController.BattleState.BATTLE_SHOW_RESULT_UI)
      {
        if ((double) this.deltaTime >= 4.0 && (this.IsType(EBattleType.PLAYBACK) || this.IsType(EBattleType.PVP) || this.IsType(EBattleType.GAMBLE) || DataManager.Instance.lastBattleResult >= (short) 0))
        {
          if (this.m_SubStateFlag == (byte) 0)
          {
            ushort num11 = (ushort) (this.DramaTriggerFlag >> 16 & (uint) ushort.MaxValue);
            if (num11 != (ushort) 0 && this.m_BattleResult == (byte) 1)
            {
              GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, (int) num11, (int) this.heroBattleData[0].HeroID);
              if ((UnityEngine.Object) this.controlPanel != (UnityEngine.Object) null)
                ((Component) this.controlPanel).gameObject.SetActive(false);
              this.DramaTriggerFlag = 0U;
              this.bDramaWorking = true;
              this.m_SubStateFlag = (byte) 1;
              if (this.IsType(EBattleType.TEACH))
                NewbieManager.Get().RemoveFlag(ETeachKind.BATTLE_BEFORE, (byte) 0);
            }
            else
              this.m_SubStateFlag = (byte) 2;
          }
          else if (this.m_SubStateFlag == (byte) 1 && !this.bDramaWorking)
            this.m_SubStateFlag = (byte) 2;
        }
        else if (this.m_BattleResult == (byte) 2 && (UnityEngine.Object) this.fader != (UnityEngine.Object) null && this.IsType(EBattleType.NORMAL) && DataManager.StageDataController._stageMode == StageMode.Dare && (double) this.deltaTime >= 2.0)
          this.fader.Action();
        if (this.m_SubStateFlag == (byte) 2)
        {
          ChaseManager.Instance.Clear();
          if (this.IsType(EBattleType.PLAYBACK))
            GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
          else if (this.IsType(EBattleType.GAMBLE))
          {
            this.m_BattleResult = (byte) 1;
            this.movePlayerOutside();
            this.GambleTimeCache = DataManager.Instance.ServerTime;
            this.m_BattleState = BattleController.BattleState.BATTLE_CHECK_GAMBLE_TIMEOUT;
            this.deltaTime = 0.0f;
          }
          else if (this.IsType(EBattleType.PVP))
          {
            if (!this.IsReplay_PVP)
              GUIManager.Instance.OpenMenu(EGUIWindow.UI_Settlement, 1, bCameraMode: true);
            else
              GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
          }
          else
          {
            int num12 = !BattleController.IsDareMode ? 0 : 2;
            int num13 = this.m_BattleResult != (byte) 2 || DataManager.Instance.lastBattleResult != (short) 0 ? 1 : 0;
            GUIManager.Instance.OpenMenu(EGUIWindow.UI_Settlement, num12, num13, true);
            if (num12 == 2 && (UnityEngine.Object) this.fader != (UnityEngine.Object) null)
              this.fader.Reset();
          }
          if (!this.IsType(EBattleType.GAMBLE))
            this.m_BattleState = BattleController.BattleState.BATTLE_FINISHED;
          this.m_SubStateFlag = (byte) 0;
        }
      }
      else if (this.m_BattleState == BattleController.BattleState.BATTLE_CHECK_GAMBLE_TIMEOUT)
      {
        if ((double) this.deltaTime > 1.0)
        {
          BattleController.GambleResult = 0;
          BattleNetwork.RefreshGambleMode(BattleController.GambleMode);
          this.m_BattleState = BattleController.BattleState.BATTLE_FINISHED;
        }
      }
      else if (this.m_BattleState == BattleController.BattleState.BATTLE_AUTOBATTLE_WAITING && (double) this.deltaTime >= 1.5)
      {
        this.m_BattleState = BattleController.BattleState.BATTLE_FINISHED;
        this.movePlayerOutside();
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.Battle);
      }
    }
    if ((this.IsType(EBattleType.NORMAL) || this.IsType(EBattleType.TEACH)) && BattleNetwork.SendBattleEndStatus == (byte) 1 && BattleNetwork.sendBattleEnd())
      BattleNetwork.SendBattleEndStatus = (byte) 2;
    if ((double) this.m_StateSkinTimer >= 0.05000000074505806)
    {
      Color color1 = new Color(0.5f, 0.5f, 0.5f);
      this.m_StateSkinTimeLen += this.m_StateSkinTimer;
      if ((double) this.m_StateSkinTimeLen >= 1.0)
      {
        this.m_StateSkinFlag *= -1;
        this.m_StateSkinTimeLen = 0.0f;
      }
      float t = this.m_StateSkinTimeLen / 1f;
      for (int index = 0; index < 4; ++index)
      {
        if (index != 3)
        {
          Color color2 = this.m_StateSkinFlag != 1 ? Color.Lerp(color1 * 0.5f, BattleController.StateSkin[index] * 0.5f, t) : Color.Lerp(BattleController.StateSkin[index] * 0.5f, color1 * 0.5f, t);
          this.m_SkinColorLightmapTex[index].SetPixel(1, 1, color2);
          this.m_SkinColorLightmapTex[index].Apply();
        }
      }
      this.m_StateSkinTimer = 0.0f;
    }
    if (this.UltraNewbieDelay.HasValue)
    {
      this.UltraNewbieDelay = new float?(this.UltraNewbieDelay.Value - Time.deltaTime);
      if ((double) this.UltraNewbieDelay.Value < 0.0)
      {
        this.inputUltra(false);
        this.UltraNewbieDelay = new float?();
      }
    }
    if (this.m_BattleState == BattleController.BattleState.BATTLE_RUNNING)
    {
      if ((this.bAutoBattle || this.IsType(EBattleType.NEWBIE_FAKE)) && (double) this.autoBattleDeltaTime >= 1.0)
      {
        for (int idx = 0; idx < this.playerCount; ++idx)
        {
          if (this.playerAttr[idx].CUR_MP >= this.playerAttr[idx].MAX_MP && this.ms_viewer[idx].working != (byte) 0 && this.ms_viewer[idx].ui_state == (byte) 1 && (this.m_MaxSkillList >> idx & 1) == 0 && this.checkInitUltra(idx))
          {
            if (this.IsType(EBattleType.NEWBIE_FAKE))
              ++this.NewbieUltraTimes;
            if (this.NewbieUltraTimes > (byte) 1)
            {
              this.UltraNewbieDelay = new float?(0.85f);
              Time.timeScale = 0.5f;
            }
            else
              this.inputUltra(false);
          }
        }
      }
      float a;
      if ((double) this.fixMoveDeltaTime + (double) smoothDeltaTime > 1.0)
      {
        a = Mathf.Max(0.0f, 1f - this.fixMoveDeltaTime) + num1;
      }
      else
      {
        this.fixMoveDeltaTime += smoothDeltaTime;
        a = smoothDeltaTime + num1;
      }
      float num14 = Mathf.Min(a, 0.1f);
      if ((double) this.canMoveDeltaTime <= 0.0)
        num14 = 0.0f;
      else if ((double) this.canMoveDeltaTime < (double) num14)
      {
        num14 = this.canMoveDeltaTime;
        this.canMoveDeltaTime = 0.0f;
      }
      else
        this.canMoveDeltaTime -= num14;
      for (int index = 0; index < this.playerCount; ++index)
        this.playerUnit[index].MovingDeltaTime = num14;
      for (int index = 0; index < this.enemyCount; ++index)
        this.enemyUnit[index].MovingDeltaTime = num14;
    }
    ChaseManager.Instance.Update();
    RewardManager.getInstance.Update(smoothDeltaTime);
    this.BCamera.updateCamera(this.playerUnit, this.playerCount, this.enemyUnit, this.enemyCount);
  }

  public bool IsType(EBattleType type) => this.BattleType == type;

  private void updateSkillState(bool ignoreSkin = false)
  {
    bool flag1 = ((long) this.m_StateUpdateFlag & 1023L) != 0L;
    bool flag2 = this.m_StateUpdateFlag >> 10 != 0UL;
    if (flag1)
    {
      for (int HEIndex = 0; HEIndex < this.playerCount; ++HEIndex)
      {
        ulong num = this.m_StateUpdateFlag >> HEIndex;
        if (num != 0UL)
        {
          if (((long) num & 1L) != 0L)
          {
            GUIManager.Instance.pDVMgr.CheckBuffIcon((byte) 0, (byte) HEIndex);
            if (!ignoreSkin)
            {
              if (this.playerUnit[HEIndex].StateColorSkin != 0U && this.playerUnit[HEIndex].StateColorSkin <= 4U)
                this.playerUnit[HEIndex].getRenderer.lightmapIndex = this.m_SkinColorLightmapIndex[(IntPtr) (this.playerUnit[HEIndex].StateColorSkin - 1U)];
              else if (!this.IsMaxSkillWorking)
                this.playerUnit[HEIndex].getRenderer.lightmapIndex = -1;
            }
          }
        }
        else
          break;
      }
    }
    if (!flag2)
      return;
    for (int HEIndex = 0; HEIndex < this.enemyCount; ++HEIndex)
    {
      ulong num = this.m_StateUpdateFlag >> HEIndex + 10;
      if (num == 0UL)
        break;
      if (((long) num & 1L) != 0L)
      {
        GUIManager.Instance.pDVMgr.CheckBuffIcon((byte) 1, (byte) HEIndex);
        if (!ignoreSkin)
        {
          if (this.enemyUnit[HEIndex].StateColorSkin != 0U && this.enemyUnit[HEIndex].StateColorSkin <= 4U)
            this.enemyUnit[HEIndex].getRenderer.lightmapIndex = this.m_SkinColorLightmapIndex[(IntPtr) (this.enemyUnit[HEIndex].StateColorSkin - 1U)];
          else if (!this.IsMaxSkillWorking)
            this.enemyUnit[HEIndex].getRenderer.lightmapIndex = -1;
        }
      }
    }
  }

  private unsafe void caleHeroNewPosition(AnimationUnit[] au, int count)
  {
    // ISSUE: untyped stack allocation
    int* numPtr1 = (int*) __untypedstackalloc((int) checked (unchecked ((uint) count) * 4U));
    // ISSUE: untyped stack allocation
    int* numPtr2 = (int*) __untypedstackalloc((int) checked (unchecked ((uint) count) * 4U));
    for (int index1 = 0; index1 < count; ++index1)
    {
      Vector3 position = au[index1].Position;
      int num1 = 2 * Mathf.CeilToInt(position.x / 2f);
      int num2 = 2 * Mathf.RoundToInt(position.z / 2f);
      int index2 = 0;
      int index3 = 0;
      int num3 = num1;
      int num4 = num2;
      while (true)
      {
        while (numPtr1[index2] != num1 || numPtr2[index2] != num2)
        {
          ++index2;
          if (index2 >= index1)
            goto label_8;
        }
        if (index3 <= 7)
        {
          num1 = num3 + (int) this.F_SpreadOffset[index3].x;
          num2 = num4 + (int) this.F_SpreadOffset[index3].y;
          ++index3;
          index2 = 0;
        }
        else
          break;
      }
      num1 = num3;
      num2 = num4;
label_8:
      numPtr1[index1] = num1;
      numPtr2[index1] = num2;
      position.x = (float) num1;
      position.z = (float) (num2 + UnityEngine.Random.Range(-1, 1));
      position.x = (double) position.x >= 0.0 ? position.x : 0.0f;
      position.y = 0.0f;
      au[index1].TargetPos = position;
    }
  }

  public void SetSceneGameObjectName(byte SceneID, UnityEngine.Object SceneObj)
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendFormat("{0}_m1", (object) SceneID.ToString("d3"));
    this.mapObject1 = ((GameObject) SceneObj).transform.FindChild(stringBuilder.ToString());
    stringBuilder.Length = 0;
    stringBuilder.AppendFormat("{0}_m2", (object) SceneID.ToString("d3"));
    this.mapObject2 = ((GameObject) SceneObj).transform.FindChild(stringBuilder.ToString());
  }

  private void decodeHeroAttribute(byte[] RecvBufferLeft, byte[] RecvBufferRight)
  {
    int num1 = (int) RecvBufferLeft[0] <= (int) RecvBufferRight[0] ? (int) RecvBufferRight[0] : (int) RecvBufferLeft[0];
    int startIdx1 = 1;
    int startIdx2 = 1;
    byte[] numArray1 = RecvBufferLeft;
    byte[] numArray2 = RecvBufferRight;
    if (BattleController.IsPVPDefSide)
    {
      numArray1 = RecvBufferRight;
      numArray2 = RecvBufferLeft;
    }
    byte num2 = 0;
    if (this.IsType(EBattleType.GAMBLE))
    {
      switch (BattleController.GambleMode)
      {
        case EGambleMode.Normal:
          num2 = GamblingManager.Instance.m_GambleGameInfo.GambleData[1].Stage;
          break;
        case EGambleMode.Turbo:
          num2 = GamblingManager.Instance.m_GambleGameInfo.GambleData[0].Stage;
          break;
      }
    }
    for (int index1 = 0; index1 < num1; ++index1)
    {
      if (index1 < (int) numArray1[0])
      {
        int index2 = (int) GameConstants.ConvertBytesToUShort(numArray1, startIdx1);
        int startIdx3 = startIdx1 + 2;
        this.playerAttr[index2].MAX_HP = GameConstants.ConvertBytesToUInt(numArray1, startIdx3);
        int startIdx4 = startIdx3 + 4;
        this.playerAttr[index2].CUR_HP = GameConstants.ConvertBytesToUInt(numArray1, startIdx4);
        int startIdx5 = startIdx4 + 4;
        this.playerAttr[index2].CUR_MP = (uint) GameConstants.ConvertBytesToUShort(numArray1, startIdx5);
        int index3 = startIdx5 + 2;
        this.playerAttr[index2].MAX_MP = 1000U;
        byte num3 = numArray1[index3];
        startIdx1 = index3 + 1;
        if (this.playerAttr[index2].CUR_HP == 0U)
          this.playerUnit[index2].gameObject.SetActive(false);
      }
      if (index1 < (int) numArray2[0])
      {
        int index4 = (int) GameConstants.ConvertBytesToUShort(numArray2, startIdx2);
        int startIdx6 = startIdx2 + 2;
        this.enemyAttr[index4].MAX_HP = GameConstants.ConvertBytesToUInt(numArray2, startIdx6);
        int startIdx7 = startIdx6 + 4;
        this.enemyAttr[index4].CUR_HP = GameConstants.ConvertBytesToUInt(numArray2, startIdx7);
        int startIdx8 = startIdx7 + 4;
        this.enemyAttr[index4].CUR_MP = (uint) GameConstants.ConvertBytesToUShort(numArray2, startIdx8);
        int index5 = startIdx8 + 2;
        byte num4 = numArray2[index5];
        startIdx2 = index5 + 1;
        if (this.IsType(EBattleType.GAMBLE) && num2 > (byte) 10)
        {
          switch (index4)
          {
            case 0:
              this.BSUtil.CasinoModeInput((byte) 3);
              num4 = (byte) 0;
              break;
            case 1:
              num4 = (byte) 1;
              this.bIgnoreSupport = true;
              break;
          }
        }
        if (num4 == (byte) 0)
          this.enemyUnit[index4].gameObject.SetActive(false);
        else if (this.IsType(EBattleType.GAMBLE))
        {
          bool flag = false;
          switch (index4)
          {
            case 0:
              switch (BattleController.GambleMode)
              {
                case EGambleMode.Normal:
                  this.enemyUnit[index4].setState(HERO_STATE_ENUM.HERO_COMMANDS_GOT_STATE, paramA: 300, paramB: 1);
                  flag = true;
                  break;
                case EGambleMode.Turbo:
                  this.enemyUnit[index4].setState(HERO_STATE_ENUM.HERO_COMMANDS_GOT_STATE, paramA: 301, paramB: 1);
                  flag = true;
                  break;
              }
              break;
            case 1:
              this.enemyUnit[index4].setState(HERO_STATE_ENUM.HERO_COMMANDS_GOT_STATE, paramA: 303, paramB: 1);
              break;
          }
          if (flag)
            this.m_StateUpdateFlag |= (ulong) (1 << 10 + index4);
        }
      }
    }
  }

  private ushort loadBattleInfo()
  {
    Level level;
    if (this.IsType(EBattleType.NEWBIE_FAKE))
    {
      this.m_MaxStageLevel = 1;
      this.teamTable[0] = DataManager.Instance.TeamTable.GetRecordByKey((ushort) 578);
      this.teamTable[1] = DataManager.Instance.TeamTable.GetRecordByKey((ushort) 577);
      level = new Level();
    }
    else if (this.IsType(EBattleType.PLAYBACK) || this.IsType(EBattleType.GAMBLE))
    {
      this.m_MaxStageLevel = 1;
      this.teamTable[0] = DataManager.Instance.TeamTable.GetRecordByKey(DataManager.Instance.battleInfo.StageID);
      level = new Level();
    }
    else if (this.IsType(EBattleType.PVP))
    {
      this.m_MaxStageLevel = 1;
      level = new Level();
    }
    else
    {
      ushort LevelID;
      level = DataManager.StageDataController.LevelTable[(int) DataManager.StageDataController.GetcurrentPointLevelID(out LevelID, (ushort) 0)].GetRecordByKey(LevelID);
      int num = 0;
      if (BattleController.IsDareMode && DataManager.StageDataController.StageDareMode(DataManager.StageDataController.currentPointID) == StageMode.Full)
        num = (int) DataManager.StageDataController.GetLevelEXBycurrentPointID((ushort) 0).NodusOneID;
      for (int index = 0; index < 3; ++index)
      {
        if (level.Team[index] != (ushort) 0)
        {
          this.teamTable[index] = DataManager.Instance.TeamTable.GetRecordByKey((ushort) ((uint) level.Team[index] + (uint) num));
          ++this.m_MaxStageLevel;
        }
      }
      bool flag = true;
      ushort currentPointId = DataManager.StageDataController.currentPointID;
      byte stageMode = (byte) DataManager.StageDataController._stageMode;
      if (currentPointId != (ushort) 0 && (int) currentPointId > (int) DataManager.StageDataController.StageRecord[(int) stageMode])
        flag = false;
      this.DramaTriggerFlag = !flag ? (uint) level.TalkAfter << 16 | (uint) level.TalkBefore : 0U;
      if (this.DramaTriggerFlag != 0U)
      {
        if (BattleNetwork.bStageFirstTry[(int) stageMode])
          BattleNetwork.bStageFirstTry[(int) stageMode] = false;
        else
          this.DramaTriggerFlag &= 4294901760U;
        if (BattleController.IsDareMode)
          this.DramaTriggerFlag = 0U;
      }
    }
    this.loadHeroInfo(0);
    this.m_CurStageLevel = 1;
    this.initRewardData();
    this.enemyAliveCount = this.enemyCount;
    this.totalAliveCount = this.enemyCount + this.playerCount;
    this.totalDieAliveRate = 1f;
    this.hitSoundRateBase = 20 + this.totalAliveCount;
    this.hitSoundTriggerRate = this.hitSoundRateBase;
    ushort num1 = 1;
    if (this.IsType(EBattleType.PLAYBACK))
    {
      MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(GUIManager.Instance.WM_MonsterID);
      if (recordByKey.StageID != (ushort) 0)
        num1 = recordByKey.StageID;
    }
    else if (this.IsType(EBattleType.GAMBLE))
    {
      MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(GamblingManager.Instance.BattleMonsterID);
      if (recordByKey.StageID != (ushort) 0)
        num1 = recordByKey.StageID;
    }
    else if (this.IsType(EBattleType.PVP))
      num1 = (ArenaManager.Instance.ArenaPlayingData.Time & 1L) == 0L ? (ushort) 998 : (ushort) 999;
    else if (!this.IsType(EBattleType.NEWBIE_FAKE))
      num1 = level.LevelInfoNo;
    return num1;
  }

  private void loadHeroInfo(int curLevelIdx)
  {
    if (this.IsType(EBattleType.NEWBIE_FAKE))
    {
      Array.Clear((Array) DataManager.Instance.heroBattleData, 0, 5);
      DataManager.Instance.heroCount = (byte) 0;
      ushort idx1 = 0;
      HeroArray recordByKey1 = DataManager.Instance.ArrayTable.GetRecordByKey(this.teamTable[1].ArrayID);
      for (int index = 0; index < 20; ++index)
      {
        ushort hero = this.teamTable[1].Arrays[index].Hero;
        byte type = this.teamTable[1].Arrays[index].Type;
        if (hero != (ushort) 0)
        {
          float posX = (float) recordByKey1.HeroArrayInfo[index].posX * 0.01f;
          float posY = (float) recordByKey1.HeroArrayInfo[index].posY * 0.01f;
          this.tempBattleData.AttrData.Enhance = this.teamTable[1].HeroClass;
          this.tempBattleData.AttrData.Star = this.teamTable[1].HeroStar;
          this.tempBattleData.AttrData.Equip = (byte) 0;
          this.tempBattleData.AttrData.LV = this.teamTable[1].HeroLevel;
          this.tempBattleData.AttrData.SkillLV1 = this.teamTable[1].HeroLevel;
          this.tempBattleData.AttrData.SkillLV2 = this.teamTable[1].HeroLevel;
          this.tempBattleData.AttrData.SkillLV3 = this.teamTable[1].HeroLevel;
          this.tempBattleData.AttrData.SkillLV4 = this.teamTable[1].HeroLevel;
          this.initHero((ushort) 0, idx1, hero, posX, posY, (byte) 0, (byte) 2);
          DataManager.Instance.heroBattleData[index].HeroID = hero;
          DataManager.Instance.heroBattleData[index].AttrData = this.tempBattleData.AttrData;
          ++DataManager.Instance.heroCount;
          ++idx1;
        }
      }
      this.playerCount = (int) idx1;
      ushort idx2 = 0;
      HeroArray recordByKey2 = DataManager.Instance.ArrayTable.GetRecordByKey(this.teamTable[0].ArrayID);
      for (int index = 0; index < 20; ++index)
      {
        ushort hero = this.teamTable[0].Arrays[index].Hero;
        byte type = this.teamTable[0].Arrays[index].Type;
        if (hero != (ushort) 0)
        {
          float posX = (float) recordByKey2.HeroArrayInfo[index].posX * 0.01f;
          float posY = (float) recordByKey2.HeroArrayInfo[index].posY * 0.01f;
          this.tempBattleData.AttrData.Enhance = this.teamTable[0].HeroClass;
          this.tempBattleData.AttrData.Star = this.teamTable[0].HeroStar;
          this.tempBattleData.AttrData.Equip = (byte) 0;
          this.tempBattleData.AttrData.LV = this.teamTable[0].HeroLevel;
          this.tempBattleData.AttrData.SkillLV1 = this.teamTable[0].HeroLevel;
          this.tempBattleData.AttrData.SkillLV2 = this.teamTable[0].HeroLevel;
          this.tempBattleData.AttrData.SkillLV3 = this.teamTable[0].HeroLevel;
          this.tempBattleData.AttrData.SkillLV4 = this.teamTable[0].HeroLevel;
          this.initHero((ushort) 1, idx2, hero, posX, posY, type, (byte) 2);
          ++idx2;
        }
      }
      this.enemyCount = (int) idx2;
    }
    else if (this.IsType(EBattleType.PVP))
    {
      ushort InKey1 = !BattleController.IsPVPDefSide ? (ushort) 1 : (ushort) 2;
      ushort InKey2 = InKey1 != (ushort) 1 ? (ushort) 1 : (ushort) 2;
      HeroArray recordByKey3 = DataManager.Instance.ArrayTable.GetRecordByKey(InKey1);
      for (int idx = 0; idx < this.playerCount; ++idx)
      {
        float posX = (float) recordByKey3.HeroArrayInfo[idx].posX * 0.01f;
        float posY = (float) recordByKey3.HeroArrayInfo[idx].posY * 0.01f;
        this.tempBattleData.AttrData = this.heroBattleData[idx].AttrData;
        this.initHero((ushort) 0, (ushort) idx, this.heroBattleData[idx].HeroID, posX, posY, (byte) 0, (byte) 3);
      }
      HeroArray recordByKey4 = DataManager.Instance.ArrayTable.GetRecordByKey(InKey2);
      for (int idx = 0; idx < this.enemyCount; ++idx)
      {
        HeroBattleData heroBattleData = (HeroBattleData) ArenaManager.Instance.ArenaPlayingData.EnemyHeroData[idx];
        ushort heroId = heroBattleData.HeroID;
        if (heroId != (ushort) 0)
        {
          float posX = (float) recordByKey4.HeroArrayInfo[idx].posX * 0.01f;
          float posY = (float) recordByKey4.HeroArrayInfo[idx].posY * 0.01f;
          this.tempBattleData.AttrData = heroBattleData.AttrData;
          this.initHero((ushort) 1, (ushort) idx, heroId, posX, posY, (byte) 0, (byte) 3);
        }
      }
    }
    else
    {
      byte bSetupSim = curLevelIdx != 0 ? (byte) 0 : (byte) 1;
      HeroArray recordByKey5 = DataManager.Instance.ArrayTable.GetRecordByKey((ushort) 1);
      int num1 = 0;
      float num2 = (float) this.teamTable[curLevelIdx].ShiftX * 0.01f;
      for (int idx = 0; idx < this.playerCount; ++idx)
      {
        float posX = 0.0f;
        float posY = 0.0f;
        if (curLevelIdx > 0 && this.playerUnit != null && (UnityEngine.Object) this.playerUnit[idx] != (UnityEngine.Object) null)
        {
          if (this.playerUnit[idx].heroState == HERO_STATE_ENUM.HERO_COMMANDS_DIE)
          {
            ++num1;
          }
          else
          {
            int index = idx - num1;
            posX = (float) recordByKey5.HeroArrayInfo[index].posX * 0.01f + num2;
            posY = (float) recordByKey5.HeroArrayInfo[index].posY * 0.01f;
          }
        }
        else
        {
          posX = (float) recordByKey5.HeroArrayInfo[idx].posX * 0.01f + num2;
          posY = (float) recordByKey5.HeroArrayInfo[idx].posY * 0.01f;
          if (this.playerUnit != null && (UnityEngine.Object) this.playerUnit[idx] != (UnityEngine.Object) null)
          {
            this.playerUnit[idx].resetComponent();
            this.playerUnit[idx].gameObject.SetActive(true);
          }
        }
        if (idx == 0)
          this.FirstPlayerPosX = posX;
        this.initHero((ushort) 0, (ushort) idx, this.heroBattleData[idx].HeroID, posX, posY, (byte) 0, bSetupSim);
      }
      ushort idx3 = 0;
      HeroArray recordByKey6 = DataManager.Instance.ArrayTable.GetRecordByKey(this.teamTable[curLevelIdx].ArrayID);
      for (int index = 0; index < 20; ++index)
      {
        ushort hero = this.teamTable[curLevelIdx].Arrays[index].Hero;
        byte type = this.teamTable[curLevelIdx].Arrays[index].Type;
        if (hero != (ushort) 0)
        {
          float posX = (float) recordByKey6.HeroArrayInfo[index].posX * 0.01f;
          float posY = (float) recordByKey6.HeroArrayInfo[index].posY * 0.01f;
          this.initHero((ushort) 1, idx3, hero, posX, posY, type, (byte) 1);
          ++idx3;
        }
      }
      this.enemyCount = (int) idx3;
    }
    if (this.BattleType == EBattleType.PLAYBACK)
    {
      GUIManager instance = GUIManager.Instance;
      int num = (int) this.BSUtil.SetMonsterHP(instance.WM_MonsterMaxHP, instance.WM_MonsterNowHP);
      this.BSUtil.SetMonsterAttrData(ref instance.WM_MonsterAttr);
    }
    else if (this.IsType(EBattleType.GAMBLE))
    {
      int num3 = (int) this.BSUtil.SetMonsterHP(100U, 100U);
    }
    int count = this.m_HeroTemp.Count;
    if (count > 0)
    {
      this.m_HeroTemp.Keys.CopyTo(this.m_HeroIDFilter, 0);
      for (int index = 0; index < count; ++index)
      {
        if (this.m_HeroTemp[this.m_HeroIDFilter[index]] != (UnityEngine.Object) null)
        {
          ModelLoader.Instance.Unload(this.m_HeroTemp[this.m_HeroIDFilter[index]]);
          this.m_HeroTemp.Remove(this.m_HeroIDFilter[index]);
          int key = this.m_HeroIDFilter[index] & (int) ushort.MaxValue;
          BattleController.HeroRef hero = this.m_HeroMap[key];
          --hero.refCount;
          this.m_HeroMap[key] = hero;
        }
      }
    }
    if (this.IsType(EBattleType.PVP))
      return;
    ParticleManager.Instance.PreLoadEnemyEffect(this.m_MaxStageLevel - 1);
  }

  public bool NextLevel()
  {
    if (this.m_CurStageLevel >= this.m_MaxStageLevel || this.m_BattleResult != (byte) 1)
      return false;
    ++this.m_CurStageLevel;
    this.m_IDFilterCount = 0;
    int num1 = this.playerCount <= this.enemyCount ? this.enemyCount : this.playerCount;
    for (int index = 0; index < num1; ++index)
    {
      if (index < this.playerCount)
        this.playerUnit[index].resetComponent();
      if (index < this.enemyCount)
      {
        Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.enemyUnit[index].NpcID);
        BattleController.HeroRef hero = this.m_HeroMap[(int) recordByKey.Modle];
        --hero.activeCount;
        this.m_HeroMap[(int) recordByKey.Modle] = hero;
        int key = (int) hero.activeCount << 16 | (int) recordByKey.Modle;
        this.enemyUnit[index].resetComponent();
        this.m_HeroTemp.Add(key, (UnityEngine.Object) this.enemyUnit[index].gameObject);
      }
    }
    HeroTeamAttribute[] arrays = this.teamTable[this.m_CurStageLevel - 1].Arrays;
    this.m_HeroMap.Keys.CopyTo(this.m_HeroIDFilter, 0);
    int count = this.m_HeroMap.Count;
    for (int index1 = 0; index1 < count; ++index1)
    {
      ushort num2 = 0;
      for (int index2 = 0; index2 < 20; ++index2)
      {
        ushort hero = arrays[index2].Hero;
        if (hero != (ushort) 0)
        {
          Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(hero);
          if (this.m_HeroIDFilter[index1] == (int) recordByKey.Modle)
            ++num2;
        }
      }
      BattleController.HeroRef hero1 = this.m_HeroMap[this.m_HeroIDFilter[index1]];
      if (num2 > (ushort) 0)
      {
        for (short refCount = hero1.refCount; (int) refCount > (int) num2 + (int) hero1.activeCount; --refCount)
        {
          int key = (int) refCount - 1 << 16 | (int) (ushort) this.m_HeroIDFilter[index1];
          if (this.m_HeroTemp.ContainsKey(key))
          {
            GameObject gameObject = this.m_HeroTemp[key] as GameObject;
            gameObject.SetActive(true);
            ModelLoader.Instance.Unload((UnityEngine.Object) gameObject);
            this.m_HeroTemp.Remove(key);
          }
        }
      }
      else
      {
        short refCount = hero1.refCount;
        for (short activeCount = hero1.activeCount; (int) activeCount < (int) refCount; ++activeCount)
        {
          int key = (int) activeCount << 16 | (int) (ushort) this.m_HeroIDFilter[index1];
          if (this.m_HeroTemp.ContainsKey(key))
          {
            GameObject gameObject = this.m_HeroTemp[key] as GameObject;
            gameObject.SetActive(true);
            ModelLoader.Instance.Unload((UnityEngine.Object) gameObject);
            this.m_HeroTemp.Remove(key);
            --hero1.refCount;
            this.m_HeroMap[this.m_HeroIDFilter[index1]] = hero1;
          }
        }
        if (hero1.refCount <= (short) 0)
        {
          this.m_HeroMap.Remove(this.m_HeroIDFilter[index1]);
          AssetManager.UnloadAssetBundle(hero1.assetKey);
        }
      }
    }
    Array.Clear((Array) this.enemyUnit, 0, 20);
    Array.Clear((Array) this.enemyAttr, 0, 20);
    Array.Clear((Array) BattleController.m_MaxSkillIdTemp, 0, 5);
    this.m_MaxSkillWorkingList = 0;
    this.m_MaxSkillList = 0;
    this.m_BattleResult = (byte) 0;
    this.m_ui32Tcik = 0U;
    this.deltaTime = 0.0f;
    this.autoBattleDeltaTime = 0.0f;
    this.fixMoveDeltaTime = 0.0f;
    this.m_StateUpdateFlag = 0UL;
    this.IsBattleEnd = false;
    this.m_SubStateFlag = (byte) 0;
    ChaseManager.Instance.Clear();
    ParticleManager.Instance.ClearOnecEffect();
    if (this.ultraHitSoundKey != byte.MaxValue)
    {
      AudioManager.Instance.StopSFX(this.ultraHitSoundKey);
      this.ultraHitSoundKey = byte.MaxValue;
    }
    AssetManager.LoadStage((byte) this.m_CurStageLevel, ref this.mapObject1, ref this.mapObject2);
    this.loadHeroInfo(this.m_CurStageLevel - 1);
    this.decodeHeroAttribute(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
    this.BCamera.initCamera(this.playerUnit, this.playerCount, this.enemyUnit, this.enemyCount);
    GUIManager.Instance.pDVMgr.NextFightStage();
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
    Array.Clear((Array) this.m_HeroIDFilter, 0, 25);
    this.m_IDFilterCount = 0;
    this.initRewardData();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 10, this.m_CurStageLevel);
    this.enemyAliveCount = this.enemyCount;
    this.totalAliveCount = this.enemyCount;
    for (int index = 0; index < this.playerCount; ++index)
    {
      if ((UnityEngine.Object) this.playerUnit[index] != (UnityEngine.Object) null && this.playerUnit[index].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
        ++this.totalAliveCount;
    }
    this.totalDieAliveRate = (float) (this.totalAliveCount / (this.enemyCount + this.playerCount));
    this.hitSoundRateBase = 20 + this.totalAliveCount;
    this.hitSoundTriggerRate = this.hitSoundRateBase;
    int num3 = 5;
    for (int index = 0; index < 4; ++index)
    {
      this.m_SkinColorLightmapIndex[index] = LightmapManager.Instance.GetLightmapIndex((Lightmap_Enum) (num3 + index));
      this.m_SkinColorLightmapTex[index] = LightmapManager.Instance.GetLightmapTexture((Lightmap_Enum) (num3 + index));
    }
    this.CasinoHitDirty = false;
    this.m_BattleState = BattleController.BattleState.WAITING_FOR_START;
    this.NextLevelWorking = false;
    return true;
  }

  public bool ResetLevel()
  {
    this.uiBattle.InterruptInput();
    this.updateMaxSkillFreeze(false);
    this.UpdateSkillLightmap(false, true);
    this.m_CurStageLevel = 1;
    this.m_IDFilterCount = 0;
    int enemyCount = this.enemyCount;
    this.enemyCount = 0;
    int num1 = this.playerCount <= enemyCount ? enemyCount : this.playerCount;
    for (int index = 0; index < num1; ++index)
    {
      if (index < this.playerCount)
        this.playerUnit[index].resetComponent();
      if (index < enemyCount)
      {
        Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.enemyUnit[index].NpcID);
        BattleController.HeroRef hero = this.m_HeroMap[(int) recordByKey.Modle];
        --hero.activeCount;
        this.m_HeroMap[(int) recordByKey.Modle] = hero;
        int key = (int) hero.activeCount << 16 | (int) recordByKey.Modle;
        this.enemyUnit[index].resetComponent();
        this.m_HeroTemp.Add(key, (UnityEngine.Object) this.enemyUnit[index].gameObject);
      }
    }
    HeroTeamAttribute[] arrays = this.teamTable[this.m_CurStageLevel - 1].Arrays;
    this.m_HeroMap.Keys.CopyTo(this.m_HeroIDFilter, 0);
    int count = this.m_HeroMap.Count;
    for (int index1 = 0; index1 < count; ++index1)
    {
      ushort num2 = 0;
      for (int index2 = 0; index2 < 20; ++index2)
      {
        ushort hero = arrays[index2].Hero;
        if (hero != (ushort) 0)
        {
          Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(hero);
          if (this.m_HeroIDFilter[index1] == (int) recordByKey.Modle)
            ++num2;
        }
      }
      BattleController.HeroRef hero1 = this.m_HeroMap[this.m_HeroIDFilter[index1]];
      if (num2 > (ushort) 0)
      {
        for (short refCount = hero1.refCount; (int) refCount > (int) num2 + (int) hero1.activeCount; --refCount)
        {
          int key = (int) refCount - 1 << 16 | (int) (ushort) this.m_HeroIDFilter[index1];
          if (this.m_HeroTemp.ContainsKey(key))
          {
            GameObject gameObject = this.m_HeroTemp[key] as GameObject;
            gameObject.SetActive(true);
            ModelLoader.Instance.Unload((UnityEngine.Object) gameObject);
            this.m_HeroTemp.Remove(key);
          }
        }
      }
      else
      {
        short refCount = hero1.refCount;
        for (short activeCount = hero1.activeCount; (int) activeCount < (int) refCount; ++activeCount)
        {
          int key = (int) activeCount << 16 | (int) (ushort) this.m_HeroIDFilter[index1];
          if (this.m_HeroTemp.ContainsKey(key))
          {
            GameObject gameObject = this.m_HeroTemp[key] as GameObject;
            gameObject.SetActive(true);
            ModelLoader.Instance.Unload((UnityEngine.Object) gameObject);
            this.m_HeroTemp.Remove(key);
            --hero1.refCount;
            this.m_HeroMap[this.m_HeroIDFilter[index1]] = hero1;
          }
        }
        if (hero1.refCount <= (short) 0)
        {
          this.m_HeroMap.Remove(this.m_HeroIDFilter[index1]);
          AssetManager.UnloadAssetBundle(hero1.assetKey);
        }
      }
    }
    Array.Clear((Array) this.enemyUnit, 0, 20);
    Array.Clear((Array) this.enemyAttr, 0, 20);
    Array.Clear((Array) BattleController.BufferForServer, 0, 1024);
    Array.Clear((Array) BattleController.m_MaxSkillIdTemp, 0, 5);
    this.m_MaxSkillWorkingList = 0;
    this.m_MaxSkillList = 0;
    this.m_BattleResult = (byte) 0;
    this.m_ui32Tcik = 0U;
    this.deltaTime = 0.0f;
    this.autoBattleDeltaTime = 0.0f;
    this.fixMoveDeltaTime = 0.0f;
    this.m_StateUpdateFlag = 0UL;
    this.IsBattleEnd = false;
    this.m_SubStateFlag = (byte) 0;
    ChaseManager.Instance.Clear();
    ParticleManager.Instance.ClearOnecEffect();
    if (this.ultraHitSoundKey != byte.MaxValue)
    {
      AudioManager.Instance.StopSFX(this.ultraHitSoundKey);
      this.ultraHitSoundKey = byte.MaxValue;
    }
    this.BSUtil.SetUserData(DataManager.Instance.RoleAttr.UserId, DataManager.Instance.BattleSeqID);
    this.BSUtil.InitSimulator(ref DataManager.Instance.battleInfo);
    DataManager.Instance.lastBattleResult = (short) -1;
    AssetManager.LoadStage((byte) this.m_CurStageLevel, ref this.mapObject1, ref this.mapObject2);
    this.loadHeroInfo(this.m_CurStageLevel - 1);
    this.CheckSetDareDifficulty();
    this.BSUtil.setHeroOver(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
    this.decodeHeroAttribute(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
    this.BCamera.initCamera(this.playerUnit, this.playerCount, this.enemyUnit, this.enemyCount);
    GUIManager.Instance.pDVMgr.NextFightStage();
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
    Array.Clear((Array) this.m_HeroIDFilter, 0, 25);
    this.m_IDFilterCount = 0;
    this.m_RewardOffset = (ushort) 0;
    RewardManager.getInstance.Clear();
    this.initRewardData();
    for (int index = 0; index < 5; ++index)
      this.ms_viewer[index] = new BattleController.MSNode();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 8);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 10, 1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 11);
    this.enemyAliveCount = this.enemyCount;
    this.totalAliveCount = this.enemyCount + this.playerCount;
    this.totalDieAliveRate = 1f;
    this.hitSoundRateBase = 20 + this.totalAliveCount;
    this.hitSoundTriggerRate = this.hitSoundRateBase;
    this.CasinoHitDirty = false;
    this.m_BattleState = BattleController.BattleState.WAITING_FOR_START;
    this.NextLevelWorking = false;
    return true;
  }

  public void CheckSetDareDifficulty()
  {
    StageManager stageDataController = DataManager.StageDataController;
    if (!this.IsType(EBattleType.NORMAL) || stageDataController._stageMode != StageMode.Dare)
      return;
    LevelEX bycurrentPointId = stageDataController.GetLevelEXBycurrentPointID((ushort) 0);
    if (stageDataController.StageDareMode(DataManager.StageDataController.currentPointID) == StageMode.Lean)
    {
      if (stageDataController.currentNodus == (byte) 1)
        this.BSUtil.SetHeroChallengeDifficulty(bycurrentPointId.NodusOneID, (ushort) 0);
      else if (stageDataController.currentNodus == (byte) 2)
      {
        this.BSUtil.SetHeroChallengeDifficulty(bycurrentPointId.NodusTwoID, (ushort) 0);
      }
      else
      {
        if (stageDataController.currentNodus != (byte) 3)
          return;
        this.BSUtil.SetHeroChallengeDifficulty(bycurrentPointId.NodusThrID, (ushort) 0);
      }
    }
    else
      this.BSUtil.SetHeroChallengeDifficulty(bycurrentPointId.NodusOneID, bycurrentPointId.NodusTwoID);
  }

  public void ResetGamble()
  {
    MapMonster recordByKey1 = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(GamblingManager.Instance.BattleMonsterID);
    DataManager.Instance.battleInfo.StageID = recordByKey1.MapTeamInfo[0].TeamID;
    this.teamTable[0] = DataManager.Instance.TeamTable.GetRecordByKey(DataManager.Instance.battleInfo.StageID);
    this.m_CurStageLevel = 1;
    this.m_IDFilterCount = 0;
    int num1 = this.playerCount <= this.enemyCount ? this.enemyCount : this.playerCount;
    for (int index = 0; index < num1; ++index)
    {
      if (index < this.playerCount)
        this.playerUnit[index].resetComponent();
      if (index < this.enemyCount)
      {
        Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(this.enemyUnit[index].NpcID);
        BattleController.HeroRef hero = this.m_HeroMap[(int) recordByKey2.Modle];
        --hero.activeCount;
        this.m_HeroMap[(int) recordByKey2.Modle] = hero;
        int key = (int) hero.activeCount << 16 | (int) recordByKey2.Modle;
        this.enemyUnit[index].resetComponent();
        this.m_HeroTemp.Add(key, (UnityEngine.Object) this.enemyUnit[index].gameObject);
      }
    }
    this.teamTable[0] = DataManager.Instance.TeamTable.GetRecordByKey(DataManager.Instance.battleInfo.StageID);
    HeroTeamAttribute[] arrays = this.teamTable[0].Arrays;
    this.m_HeroMap.Keys.CopyTo(this.m_HeroIDFilter, 0);
    int count = this.m_HeroMap.Count;
    for (int index1 = 0; index1 < count; ++index1)
    {
      ushort num2 = 0;
      for (int index2 = 0; index2 < 20; ++index2)
      {
        ushort hero = arrays[index2].Hero;
        if (hero != (ushort) 0)
        {
          Hero recordByKey3 = DataManager.Instance.HeroTable.GetRecordByKey(hero);
          if (this.m_HeroIDFilter[index1] == (int) recordByKey3.Modle)
            ++num2;
        }
      }
      BattleController.HeroRef hero1 = this.m_HeroMap[this.m_HeroIDFilter[index1]];
      if (num2 > (ushort) 0)
      {
        for (short refCount = hero1.refCount; (int) refCount > (int) num2 + (int) hero1.activeCount; --refCount)
        {
          int key = (int) refCount - 1 << 16 | (int) (ushort) this.m_HeroIDFilter[index1];
          if (this.m_HeroTemp.ContainsKey(key))
          {
            GameObject gameObject = this.m_HeroTemp[key] as GameObject;
            gameObject.SetActive(true);
            ModelLoader.Instance.Unload((UnityEngine.Object) gameObject);
            this.m_HeroTemp.Remove(key);
          }
        }
      }
      else
      {
        short refCount = hero1.refCount;
        for (short activeCount = hero1.activeCount; (int) activeCount < (int) refCount; ++activeCount)
        {
          int key = (int) activeCount << 16 | (int) (ushort) this.m_HeroIDFilter[index1];
          if (this.m_HeroTemp.ContainsKey(key))
          {
            GameObject gameObject = this.m_HeroTemp[key] as GameObject;
            gameObject.SetActive(true);
            ModelLoader.Instance.Unload((UnityEngine.Object) gameObject);
            this.m_HeroTemp.Remove(key);
            --hero1.refCount;
            this.m_HeroMap[this.m_HeroIDFilter[index1]] = hero1;
          }
        }
        if (hero1.refCount <= (short) 0)
        {
          this.m_HeroMap.Remove(this.m_HeroIDFilter[index1]);
          AssetManager.UnloadAssetBundle(hero1.assetKey);
        }
      }
    }
    Array.Clear((Array) this.enemyUnit, 0, 20);
    Array.Clear((Array) this.enemyAttr, 0, 20);
    Array.Clear((Array) BattleController.m_MaxSkillIdTemp, 0, 5);
    this.m_MaxSkillWorkingList = 0;
    this.m_MaxSkillList = 0;
    this.m_BattleResult = (byte) 0;
    this.m_ui32Tcik = 0U;
    this.deltaTime = 0.0f;
    this.autoBattleDeltaTime = 0.0f;
    this.fixMoveDeltaTime = 0.0f;
    this.m_StateUpdateFlag = 0UL;
    this.IsBattleEnd = false;
    this.m_SubStateFlag = (byte) 0;
    ChaseManager.Instance.Clear();
    ParticleManager.Instance.ClearOnecEffect();
    if (this.ultraHitSoundKey != byte.MaxValue)
    {
      AudioManager.Instance.StopSFX(this.ultraHitSoundKey);
      this.ultraHitSoundKey = byte.MaxValue;
    }
    this.BSUtil.SetUserData(DataManager.Instance.RoleAttr.UserId, DataManager.Instance.BattleSeqID);
    this.BSUtil.InitSimulator(ref DataManager.Instance.battleInfo);
    DataManager.Instance.lastBattleResult = (short) -1;
    if ((int) recordByKey1.StageID != (int) this.CurrentStageID)
    {
      AssetManager.QuitScene();
      AssetManager.LoadScene(recordByKey1.StageID);
      this.CurrentStageID = recordByKey1.StageID;
    }
    AssetManager.LoadStage((byte) 1, ref this.mapObject1, ref this.mapObject2);
    this.loadHeroInfo(0);
    this.BSUtil.setHeroOver(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
    this.decodeHeroAttribute(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
    this.BCamera.initCamera(this.playerUnit, this.playerCount, this.enemyUnit, this.enemyCount);
    GUIManager.Instance.pDVMgr.NextFightStage();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 23);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 3);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 4);
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
    Array.Clear((Array) this.m_HeroIDFilter, 0, 25);
    this.m_IDFilterCount = 0;
    RewardManager.getInstance.Clear();
    this.enemyAliveCount = this.enemyCount;
    this.totalAliveCount = this.enemyCount;
    for (int index = 0; index < this.playerCount; ++index)
    {
      if ((UnityEngine.Object) this.playerUnit[index] != (UnityEngine.Object) null && this.playerUnit[index].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
        ++this.totalAliveCount;
    }
    this.totalDieAliveRate = (float) (this.totalAliveCount / (this.enemyCount + this.playerCount));
    this.hitSoundRateBase = 20 + this.totalAliveCount;
    this.hitSoundTriggerRate = this.hitSoundRateBase;
    int num3 = 5;
    for (int index = 0; index < 4; ++index)
    {
      this.m_SkinColorLightmapIndex[index] = LightmapManager.Instance.GetLightmapIndex((Lightmap_Enum) (num3 + index));
      this.m_SkinColorLightmapTex[index] = LightmapManager.Instance.GetLightmapTexture((Lightmap_Enum) (num3 + index));
    }
    this.CasinoHitDirty = false;
    this.m_BattleState = BattleController.BattleState.WAITING_FOR_START;
    this.NextLevelWorking = false;
  }

  private void initHero(
    ushort side,
    ushort idx,
    ushort id,
    float posX,
    float posY,
    byte npcType,
    byte bSetupSim = 1)
  {
    if (side == (ushort) 0 && bSetupSim == (byte) 1)
    {
      this.BSUtil.setHeroState(side, id, ref this.heroBattleData[(int) idx].AttrData);
    }
    else
    {
      switch (bSetupSim)
      {
        case 2:
          this.BSUtil.setHeroState(side, id, ref this.tempBattleData.AttrData);
          break;
        case 3:
          ushort Side = side;
          if (BattleController.IsPVPDefSide)
          {
            switch (Side)
            {
              case 0:
                Side = (ushort) 1;
                break;
              case 1:
                Side = (ushort) 0;
                break;
            }
          }
          this.BSUtil.setHeroState(Side, id, ref this.tempBattleData.AttrData);
          break;
      }
    }
    AnimationUnit[] animationUnitArray = side != (ushort) 0 ? this.enemyUnit : this.playerUnit;
    Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(id);
    if ((UnityEngine.Object) animationUnitArray[(int) idx] == (UnityEngine.Object) null)
    {
      if (!this.m_HeroMap.ContainsKey((int) recordByKey.Modle))
      {
        this.StringInstance.Length = 0;
        this.StringInstance.AppendFormat("Role/hero_{0:00000}", (object) recordByKey.Modle);
        int Key = 0;
        string str = this.StringInstance.ToString();
        AssetBundle assetBundle = AssetManager.GetAssetBundle(str, out Key);
        GameObject go = ModelLoader.Instance.Load(recordByKey.Modle, assetBundle, (ushort) recordByKey.TextureNo);
        GameObject outGO = (GameObject) null;
        this.setupAnimationObject(go, side, idx, id, out outGO);
        this.HeroRefInstance.Set(Key, (short) 1, (short) 1, (UnityEngine.Object) assetBundle, str);
        this.m_HeroMap.Add((int) recordByKey.Modle, this.HeroRefInstance);
      }
      else
      {
        BattleController.HeroRef hero = this.m_HeroMap[(int) recordByKey.Modle];
        GameObject outGO = (GameObject) null;
        bool flag = false;
        if ((int) hero.activeCount < (int) hero.refCount)
        {
          int key = (int) hero.activeCount << 16 | (int) recordByKey.Modle;
          if (this.m_HeroTemp.ContainsKey(key))
          {
            outGO = (GameObject) this.m_HeroTemp[key];
            this.m_HeroTemp.Remove(key);
            flag = true;
          }
        }
        if (!flag)
        {
          AssetBundle heroObj = (AssetBundle) hero.heroObj;
          this.setupAnimationObject(ModelLoader.Instance.Load(recordByKey.Modle, heroObj, (ushort) recordByKey.TextureNo), side, idx, id, out outGO);
          ++hero.refCount;
        }
        ++hero.activeCount;
        this.m_HeroMap[(int) recordByKey.Modle] = hero;
        animationUnitArray[(int) idx] = outGO.GetComponent<AnimationUnit>();
        animationUnitArray[(int) idx].gameObject.SetActive(true);
        if (flag)
        {
          SkinnedMeshRenderer componentInChildren = outGO.GetComponentInChildren<SkinnedMeshRenderer>();
          if ((UnityEngine.Object) componentInChildren != (UnityEngine.Object) null && (int) animationUnitArray[(int) idx].NpcID != (int) id)
          {
            AssetBundle heroObj = (AssetBundle) hero.heroObj;
            ModelLoader.Instance.UnloadMaterial(componentInChildren.sharedMaterial);
            componentInChildren.material = ModelLoader.Instance.LoadMaterial(recordByKey.Modle, heroObj, (ushort) recordByKey.TextureNo);
          }
        }
      }
    }
    if (!animationUnitArray[(int) idx].gameObject.activeSelf)
      return;
    animationUnitArray[(int) idx].initComponent(id);
    this.Vec3Instance.Set(posX, 0.0f, posY);
    Vector3 vec3Instance = this.Vec3Instance;
    animationUnitArray[(int) idx].setPositionInstantly(this.Vec3Instance);
    if (BattleController.IsPVPDefSide)
    {
      if (side == (ushort) 0)
        this.Vec3Instance.Set(-10000f, vec3Instance.y, vec3Instance.z);
      else
        this.Vec3Instance.Set(10000f, vec3Instance.y, vec3Instance.z);
    }
    else if (side == (ushort) 0)
      this.Vec3Instance.Set(10000f, vec3Instance.y, vec3Instance.z);
    else
      this.Vec3Instance.Set(this.FirstPlayerPosX, vec3Instance.y, vec3Instance.z);
    animationUnitArray[(int) idx].updateDirection(this.Vec3Instance);
    float num = 1.17f;
    float rate = recordByKey.Scale == (ushort) 100 ? num : (float) recordByKey.Scale / 100f * num;
    if (side == (ushort) 1 && this.IsType(EBattleType.GAMBLE) && BattleController.GambleMode == EGambleMode.Normal)
      rate *= 0.7f;
    animationUnitArray[(int) idx].setNpcScale(rate);
    animationUnitArray[(int) idx].IsBoss = npcType == (byte) 3;
    animationUnitArray[(int) idx].IsEnemy = side != (ushort) 0;
    if (recordByKey.ResidentEffect != (ushort) 0)
      animationUnitArray[(int) idx].SetupResidentEffect(recordByKey.ResidentEffect);
    if (!animationUnitArray[(int) idx].IsEnemy || !animationUnitArray[(int) idx].IsBoss)
      return;
    this.MonsterIdxTemp = (int) idx;
  }

  private AnimationUnit setupAnimationObject(
    GameObject go,
    ushort side,
    ushort idx,
    ushort id,
    out GameObject outGO)
  {
    GameObject gameObject1 = new GameObject("hero");
    go.name = "AnimationObject";
    go.transform.localPosition = Vector3.zero;
    go.transform.parent = gameObject1.transform;
    GameObject gameObject2 = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle("UI/shadow", out this.shadowABKey).mainAsset) as GameObject;
    gameObject2.transform.parent = gameObject1.transform;
    MeshFilter component = gameObject2.GetComponent<MeshFilter>();
    Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(id);
    float num = (float) recordByKey.Scale * 0.01f;
    component.mesh = GameConstants.CreatePlane(go.transform.forward, go.transform.right, new Rect(0.0f, 0.0f, 1f, 1f), new Color(1f, 1f, 1f, 0.6f), (float) ((double) num * (double) recordByKey.Radius * 0.014999999664723873));
    AnimationUnit animationUnit = gameObject1.AddComponent<AnimationUnit>();
    animationUnit.pListener = new AnimationUnit.ParentListener(this.EventCallBack);
    animationUnit.Shadow = gameObject2;
    animationUnit.controller = this;
    if (side < (ushort) 2)
      (side != (ushort) 0 ? this.enemyUnit : this.playerUnit)[(int) idx] = animationUnit;
    outGO = gameObject1;
    return animationUnit;
  }

  public void useMaxSkill(int side, int idx)
  {
    int idx1 = side == 0 ? idx : idx + 5;
    if (idx1 < 0 || idx1 >= 25)
      return;
    if (this.m_MaxSkillList == 0)
    {
      this.maxSkillTimeCache = this.deltaTime;
      this.m_BattleState = BattleController.BattleState.BATTLE_MAXSKILL_WORKING;
    }
    this.m_MaxSkillList |= 1 << idx1;
    this.setMaxSkillWorkingList(idx1, true);
    if (side == 0)
      this.playerUnit[idx].playMaxSkill();
    else
      this.enemyUnit[idx].playMaxSkill();
    this.updateMaxSkillFreeze(true);
    this.UpdateSkillLightmap(true);
  }

  public void setMaxSkillWorkingList(int idx, bool bWorking, int skillID = 0)
  {
    if (!bWorking)
    {
      if ((this.m_MaxSkillWorkingList >> idx & 1) == 0)
        return;
      this.m_MaxSkillWorkingList ^= 1 << idx;
      BattleController.m_MaxSkillIdTemp[idx] = 0;
    }
    else
    {
      this.m_MaxSkillWorkingList |= 1 << idx;
      BattleController.m_MaxSkillIdTemp[idx] = skillID;
    }
  }

  private bool isSkillWorking(int idx) => (this.m_MaxSkillWorkingList >> idx & 1) != 0;

  private void SetTarget(int side, int idx, int tside, int tidx)
  {
    if (side == 0)
    {
      if (tside == 0)
        this.playerUnit[idx].Target = this.playerUnit[tidx].gameObject;
      else
        this.playerUnit[idx].Target = this.enemyUnit[tidx].gameObject;
    }
    else if (tside == 0)
      this.enemyUnit[idx].Target = this.playerUnit[tidx].gameObject;
    else
      this.enemyUnit[idx].Target = this.enemyUnit[tidx].gameObject;
  }

  private bool decodeUltraSkill(byte[] Buffer)
  {
    if (Buffer[0] == (byte) 0)
      return false;
    if (this.IsType(EBattleType.PLAYBACK))
      this.decodeSimuPackage(BattleController.RecvBufferLeft, BattleController.RecvBufferRight, 1);
    else if (this.IsType(EBattleType.PVP))
      this.decodeSimuPackage(BattleController.RecvBufferLeft, BattleController.RecvBufferRight, 3);
    int index1 = 1;
    for (int index2 = 0; index2 < (int) Buffer[0]; ++index2)
    {
      int side = (int) Buffer[index1];
      int startIdx1 = index1 + 1;
      int idx = (int) GameConstants.ConvertBytesToUShort(Buffer, startIdx1);
      int index3 = startIdx1 + 2;
      int tside = (int) Buffer[index3];
      int startIdx2 = index3 + 1;
      int tidx = (int) GameConstants.ConvertBytesToUShort(Buffer, startIdx2);
      int startIdx3 = startIdx2 + 2;
      int num = (int) GameConstants.ConvertBytesToUShort(Buffer, startIdx3);
      index1 = startIdx3 + 2;
      if (BattleController.IsPVPDefSide)
      {
        side = side != 1 ? 1 : 0;
        tside = tside != 1 ? 1 : 0;
      }
      this.SetTarget(side, idx, tside, tidx);
      this.useMaxSkill(side, idx);
    }
    return true;
  }

  private void decodeSimuPackage(byte[] RecvBufferLeft, byte[] RecvBufferRight, int Cmd = 0)
  {
    if (BattleController.IsPVPDefSide)
    {
      this.decodeSimuPackage(RecvBufferRight, 0, Cmd & 5);
      this.decodeSimuPackage(RecvBufferLeft, 1, Cmd & 10);
    }
    else if (this.IsType(EBattleType.PLAYBACK))
    {
      this.decodeSimuPackage(RecvBufferLeft, 0, Cmd);
      this.decodeSimuPackage(RecvBufferRight, 1, Cmd);
    }
    else
    {
      this.decodeSimuPackage(RecvBufferLeft, 0, Cmd & 5);
      this.decodeSimuPackage(RecvBufferRight, 1, Cmd & 10);
    }
  }

  private int CheckTargetSide(int side)
  {
    if (!BattleController.IsPVPDefSide)
      return side;
    return side == 1 ? 0 : 1;
  }

  private bool IsDotOrHot(int EffectID)
  {
    switch ((HERO_EFFECTTYPE_ENUM) EffectID)
    {
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_DOT:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_DOT_CIR:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_HOT:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_HOT_CIR:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_IMM_BUFF:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_PHYSIMM_BUFF:
      case HERO_EFFECTTYPE_ENUM.HERO_EFFECT_MAGIIMM_BUFF:
        return true;
      default:
        return false;
    }
  }

  private void decodeSimuPackage(byte[] RecvBuffer, int Side, int Cmd = 0)
  {
    byte num1 = RecvBuffer[0];
    if (num1 == (byte) 0)
      return;
    AnimationUnit[] animationUnitArray1 = Side != 0 ? this.enemyUnit : this.playerUnit;
    int startIdx1 = 1;
    for (int index1 = 0; index1 < (int) num1; ++index1)
    {
      int index2 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx1);
      int index3 = startIdx1 + 2;
      int State = (int) RecvBuffer[index3];
      startIdx1 = index3 + 1;
      switch ((byte) State)
      {
        case 0:
          int side1 = (int) RecvBuffer[startIdx1];
          int startIdx2 = startIdx1 + 1;
          int index4 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx2);
          startIdx1 = startIdx2 + 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            AnimationUnit[] animationUnitArray2 = this.CheckTargetSide(side1) != 0 ? this.enemyUnit : this.playerUnit;
            animationUnitArray1[index2].setState(HERO_STATE_ENUM.HERO_COMMANDS_IDLE, animationUnitArray2[index4].gameObject);
            break;
          }
          break;
        case 1:
          int side2 = (int) RecvBuffer[startIdx1];
          int startIdx3 = startIdx1 + 1;
          int index5 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx3);
          int startIdx4 = startIdx3 + 2;
          float new_x1 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx4);
          int startIdx5 = startIdx4 + 4;
          float new_z1 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx5);
          startIdx1 = startIdx5 + 4;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            AnimationUnit[] animationUnitArray3 = this.CheckTargetSide(side2) != 0 ? this.enemyUnit : this.playerUnit;
            this.Vec3Instance.Set(new_x1, 0.0f, new_z1);
            animationUnitArray1[index2].setPositionInstantly(this.Vec3Instance);
            animationUnitArray1[index2].setState(HERO_STATE_ENUM.HERO_COMMANDS_MOVE, animationUnitArray3[index5].gameObject);
            break;
          }
          break;
        case 2:
          int side3 = (int) RecvBuffer[startIdx1];
          int startIdx6 = startIdx1 + 1;
          int index6 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx6);
          int startIdx7 = startIdx6 + 2;
          int num2 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx7);
          startIdx1 = startIdx7 + 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            AnimationUnit[] animationUnitArray4 = this.CheckTargetSide(side3) != 0 ? this.enemyUnit : this.playerUnit;
            animationUnitArray1[index2].setState(HERO_STATE_ENUM.HERO_COMMANDS_ATTACK, animationUnitArray4[index6].gameObject, num2);
            if (DataManager.Instance.SkillTable.GetRecordByKey((ushort) num2).SkillKind == (byte) 61)
            {
              this.m_StateUpdateFlag |= (ulong) (1 << Side * 10 + index2);
              break;
            }
            break;
          }
          break;
        case 3:
          float x1 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx1);
          int startIdx8 = startIdx1 + 4;
          float z1 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx8);
          int startIdx9 = startIdx8 + 4;
          int skillID1 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx9);
          startIdx1 = startIdx9 + 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            Vector3 targetPos = new Vector3(x1, 0.0f, z1);
            animationUnitArray1[index2].checkRangeHitParticle_position((ushort) skillID1, targetPos, this.m_ui32Tcik, (byte) Side);
            break;
          }
          break;
        case 4:
          int side4 = (int) RecvBuffer[startIdx1];
          int startIdx10 = startIdx1 + 1;
          int index7 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx10);
          int index8 = startIdx10 + 2;
          int num3 = (int) RecvBuffer[index8];
          int startIdx11 = index8 + 1;
          int num4 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx11);
          int startIdx12 = startIdx11 + 2;
          uint num5 = GameConstants.ConvertBytesToUInt(RecvBuffer, startIdx12);
          int index9 = startIdx12 + 4;
          int num6 = (int) RecvBuffer[index9];
          startIdx1 = index9 + 1;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            int fromSide = this.CheckTargetSide(side4);
            int num7 = 0;
            if (num3 == 0 || num3 == 10 || num3 == 11 || num3 == 8)
              num7 = 1;
            this.setupHPMP(Side, index2, num3, num5);
            int paramC = 0 | (num6 == 0 ? 0 : 1) | (num7 == 0 ? 0 : 2);
            if (this.IsDotOrHot(num3))
              paramC |= 4;
            bool flag = false;
            if (num3 == 14)
            {
              paramC |= 8;
              flag = true;
            }
            animationUnitArray1[index2].setState(HERO_STATE_ENUM.HERO_COMMANDS_GETHIT, paramA: num4, paramB: (int) num5, paramC: paramC);
            if (!this.IsDotOrHot(num3))
            {
              AnimationUnit[] animationUnitArray5 = fromSide != 0 ? this.enemyUnit : this.playerUnit;
              animationUnitArray5[index7].checkRangeHitParticle((ushort) num4, animationUnitArray1[index2].transform, this.m_ui32Tcik, (byte) fromSide);
              animationUnitArray5[index7].checkRangeHitSound((ushort) num4, this.m_ui32Tcik);
            }
            if (!this.IsType(EBattleType.GAMBLE))
            {
              if (flag)
              {
                if (Side == 0)
                  this.m_HeroIDFilter[index2] += (int) num5;
                else
                  this.m_HeroIDFilter[25 - index2 - 1] += (int) num5;
                ++this.m_IDFilterCount;
                break;
              }
              if (num3 != 0 && num3 != 1 || num5 != 0U)
              {
                GUIManager.Instance.pDVMgr.AddDamageValueEffect(num5, Side, index2, (HERO_EFFECTTYPE_ENUM) num3);
                break;
              }
              break;
            }
            break;
          }
          break;
        case 5:
          int num8 = (int) RecvBuffer[startIdx1];
          ++startIdx1;
          for (int index10 = 0; index10 < num8; ++index10)
            startIdx1 += 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            animationUnitArray1[index2].setState(HERO_STATE_ENUM.HERO_COMMANDS_DIE);
            BattleController.HeroAttr[] heroAttrArray = Side != 0 ? this.enemyAttr : this.playerAttr;
            heroAttrArray[index2].CUR_HP = 0U;
            heroAttrArray[index2].CUR_MP = 0U;
            this.m_bHPMPDirty |= (byte) (Side + 1);
            this.m_StateUpdateFlag |= (ulong) (1 << Side * 10 + index2);
            --this.enemyAliveCount;
            --this.totalAliveCount;
            this.totalDieAliveRate = (float) this.totalAliveCount / (float) (this.enemyCount + this.playerCount);
            this.hitSoundTriggerRate = 60 - (int) ((double) (60 - this.hitSoundRateBase) * (double) this.totalDieAliveRate);
            if (Side == 0)
              this.ms_viewer[index2].working = (byte) 0;
            if (Side == 1)
              this.CaleRewardDropDown(animationUnitArray1[index2]);
            Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(animationUnitArray1[index2].NpcID);
            if ((int) recordByKey.HeroKey == (int) animationUnitArray1[index2].NpcID && recordByKey.DyingSound != (ushort) 0)
            {
              bool flag = true;
              if (Side == 1 && !animationUnitArray1[index2].IsBoss)
                flag = (double) UnityEngine.Random.value <= 0.5;
              if (flag)
              {
                if (this.soundPlayMap.ContainsKey(recordByKey.DyingSound))
                {
                  this.soundList[this.soundPlayMap[recordByKey.DyingSound]].Add(animationUnitArray1[index2].transform);
                }
                else
                {
                  this.soundList[this.m_LastSoundListIdx].Add(animationUnitArray1[index2].transform);
                  this.soundPlayMap.Add(recordByKey.DyingSound, this.m_LastSoundListIdx);
                  ++this.m_LastSoundListIdx;
                }
                this.m_bSoundDirty = true;
                break;
              }
              break;
            }
            break;
          }
          break;
        case 6:
          int side5 = (int) RecvBuffer[startIdx1];
          int startIdx13 = startIdx1 + 1;
          int index11 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx13);
          int startIdx14 = startIdx13 + 2;
          int skillID2 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx14);
          int startIdx15 = startIdx14 + 2;
          int flyTime1 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx15);
          startIdx1 = startIdx15 + 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            int num9 = this.CheckTargetSide(side5);
            if (flyTime1 > 0)
            {
              AnimationUnit[] animationUnitArray6 = num9 != 0 ? this.enemyUnit : this.playerUnit;
              this.setupFlyItem(animationUnitArray1[index2].FlyRootPos, animationUnitArray6[index11], flyTime1, skillID2, animationUnitArray1[index2].ScaleRate);
              break;
            }
            break;
          }
          break;
        case 7:
          float x2 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx1);
          int startIdx16 = startIdx1 + 4;
          float z2 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx16);
          int startIdx17 = startIdx16 + 4;
          int num10 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx17);
          int startIdx18 = startIdx17 + 2;
          int flyTime2 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx18);
          startIdx1 = startIdx18 + 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State) && flyTime2 > 0)
          {
            Vector3 targetPos = new Vector3(x2, 0.0f, z2);
            if (DataManager.Instance.SkillTable.GetRecordByKey((ushort) num10).FlyType != (byte) 3)
            {
              this.setupFlyItem(animationUnitArray1[index2].FlyRootPos, targetPos, flyTime2, num10, animationUnitArray1[index2].ScaleRate);
              break;
            }
            Vector3 vector3 = animationUnitArray1[index2].Position - targetPos;
            vector3.Normalize();
            this.setupFlyItem((targetPos + vector3 * 3f) with
            {
              y = 7.5f
            }, targetPos, flyTime2, num10, animationUnitArray1[index2].ScaleRate);
            break;
          }
          break;
        case 8:
          int paramA1 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx1);
          startIdx1 += 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            animationUnitArray1[index2].setState(HERO_STATE_ENUM.HERO_COMMANDS_GOT_STATE, paramA: paramA1, paramB: 1);
            this.m_StateUpdateFlag |= (ulong) (1 << Side * 10 + index2);
            break;
          }
          break;
        case 9:
          int paramA2 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx1);
          startIdx1 += 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            animationUnitArray1[index2].setState(HERO_STATE_ENUM.HERO_COMMANDS_GOT_STATE, paramA: paramA2);
            this.m_StateUpdateFlag |= (ulong) (1 << Side * 10 + index2);
            break;
          }
          break;
        case 10:
          int num11 = (int) RecvBuffer[startIdx1];
          int startIdx19 = startIdx1 + 1;
          uint num12 = (uint) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx19);
          startIdx1 = startIdx19 + 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            int num13 = num11 % 100;
            this.setupHPMP(Side, index2, num13, num12);
            if (num11 / 100 != 0 && num12 != 0U)
            {
              GUIManager.Instance.pDVMgr.AddDamageValueEffect(num12, Side, index2, (HERO_EFFECTTYPE_ENUM) num13);
              break;
            }
            break;
          }
          break;
        case 11:
          int startIdx20 = startIdx1 + 1 + 2;
          int num14 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx20);
          startIdx1 = startIdx20 + 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
            break;
          break;
        case 12:
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            animationUnitArray1[index2].setState(HERO_STATE_ENUM.HERO_COMMANDS_STOP_CHANNEL);
            break;
          }
          break;
        case 13:
          int num15 = (int) GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx1);
          startIdx1 += 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State) && animationUnitArray1[index2].hasRangeParticlePos && DataManager.Instance.SkillTable.GetRecordByKey((ushort) num15).FlyParticle == (ushort) 0)
          {
            animationUnitArray1[index2].checkRangeHitParticle((ushort) num15, (Transform) null, this.m_ui32Tcik, (byte) Side);
            break;
          }
          break;
        case 14:
          ushort InKey = GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx1);
          int startIdx21 = startIdx1 + 2;
          float new_x2 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx21);
          int startIdx22 = startIdx21 + 4;
          float new_z2 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx22);
          startIdx1 = startIdx22 + 4;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(InKey);
            this.Vec3Instance.Set(new_x2, 0.0f, new_z2);
            ParticleManager.Instance.Spawn(recordByKey.RangeHitParticle, (Transform) null, this.Vec3Instance, 1f, true, false);
            break;
          }
          break;
        case 15:
          float new_x3 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx1);
          int startIdx23 = startIdx1 + 4;
          float new_z3 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx23);
          int startIdx24 = startIdx23 + 4;
          ushort paramA3 = GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx24);
          startIdx1 = startIdx24 + 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            this.Vec3Instance.Set(new_x3, 0.0f, new_z3);
            animationUnitArray1[index2].TargetPos = this.Vec3Instance;
            animationUnitArray1[index2].setState(HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_POINT, paramA: (int) paramA3);
            break;
          }
          break;
        case 16:
          startIdx1 += 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            animationUnitArray1[index2].setState(HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_POINT_END);
            break;
          }
          break;
        case 17:
          byte side6 = RecvBuffer[startIdx1];
          int startIdx25 = startIdx1 + 1;
          ushort index12 = GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx25);
          int startIdx26 = startIdx25 + 2;
          float new_x4 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx26);
          int startIdx27 = startIdx26 + 4;
          float new_z4 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx27);
          int startIdx28 = startIdx27 + 4;
          ushort num16 = GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx28);
          startIdx1 = startIdx28 + 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            AnimationUnit[] animationUnitArray7 = (byte) this.CheckTargetSide((int) side6) != (byte) 0 ? this.enemyUnit : this.playerUnit;
            Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(num16);
            if (recordByKey.SkillKind != (byte) 16 && recordByKey.SkillKind != (byte) 17)
              animationUnitArray7[(int) index12].setState(HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_DAZE);
            this.Vec3Instance.Set(new_x4, 0.0f, new_z4);
            animationUnitArray1[index2].TargetPos = this.Vec3Instance;
            animationUnitArray1[index2].setState(HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_TARGET, animationUnitArray7[(int) index12].gameObject, (int) num16);
            break;
          }
          break;
        case 18:
          byte side7 = RecvBuffer[startIdx1];
          int startIdx29 = startIdx1 + 1;
          ushort index13 = GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx29);
          startIdx1 = startIdx29 + 2 + 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            AnimationUnit[] animationUnitArray8 = (byte) this.CheckTargetSide((int) side7) != (byte) 0 ? this.enemyUnit : this.playerUnit;
            animationUnitArray1[index2].setState(HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_TARGET_END, animationUnitArray8[(int) index13].gameObject);
            break;
          }
          break;
        case 19:
          float new_x5 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx1);
          int startIdx30 = startIdx1 + 4;
          float new_z5 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx30);
          int startIdx31 = startIdx30 + 4;
          GameConstants.ConvertBytesToUShort(RecvBuffer, startIdx31);
          startIdx1 = startIdx31 + 2;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            this.Vec3Instance.Set(new_x5, 0.0f, new_z5);
            animationUnitArray1[index2].TargetPos = this.Vec3Instance;
            animationUnitArray1[index2].setState(HERO_STATE_ENUM.HERO_COMMANDS_KNOCK_BACK);
            break;
          }
          break;
        case 20:
          float new_x6 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx1);
          int startIdx32 = startIdx1 + 4;
          float new_z6 = GameConstants.ConvertBytesToFloat(RecvBuffer, startIdx32);
          startIdx1 = startIdx32 + 4;
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            this.Vec3Instance.Set(new_x6, 0.0f, new_z6);
            animationUnitArray1[index2].setPositionInstantly(this.Vec3Instance);
            animationUnitArray1[index2].setState(HERO_STATE_ENUM.HERO_COMMANDS_KNOCK_BACK_END);
            break;
          }
          break;
        case 21:
          if (this.IsType(EBattleType.GAMBLE))
          {
            if (this.bIgnoreSupport)
            {
              this.bIgnoreSupport = false;
              break;
            }
            this.SupportAU = animationUnitArray1[index2];
            this.SupportIdx = index2;
            this.updateWaitingNPCDieFreeze(true);
            this.m_BattleState = BattleController.BattleState.BATTLE_CHECK_DIE_BEFORE_SUPPORT;
            this.PlayGambleHitEffect();
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 17);
            break;
          }
          if (this.CheckExec(Cmd, Side, (HERO_STATE_ENUM) State))
          {
            this.ExeSupport(animationUnitArray1[index2], index2);
            break;
          }
          break;
        case 22:
          if (!this.IsType(EBattleType.GAMBLE) || !this.bIgnoreSupport)
          {
            this.CasinoHitDirty = true;
            break;
          }
          break;
      }
    }
  }

  public void ExeSupport(AnimationUnit au, int playerIdx)
  {
    au.gameObject.SetActive(true);
    if (au.IsEnemy && this.IsType(EBattleType.GAMBLE))
    {
      bool flag = false;
      if (BattleController.GambleMode == EGambleMode.Normal || BattleController.GambleMode == EGambleMode.Turbo)
      {
        au.setState(HERO_STATE_ENUM.HERO_COMMANDS_GOT_STATE, paramA: 303, paramB: 1);
        flag = true;
      }
      if (flag)
        this.m_StateUpdateFlag |= (ulong) (1 << 10 + playerIdx);
    }
    this.uiBattle.AddCenterMsg();
    byte num = 0;
    if (this.teamTable[this.m_CurStageLevel - 1].SupportType != (byte) 2)
    {
      Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(au.NpcID);
      if (recordByKey.SupportShowType != (byte) 0)
      {
        num = recordByKey.SupportShowType;
        au.setState(HERO_STATE_ENUM.HERO_COMMANDS_WAITING_SUPPORT, paramA: (int) recordByKey.SupportShowType);
        this.m_SupportDisplayList.Add(au);
        if (this.m_BattleState != BattleController.BattleState.BATTLE_SUPPORT_DISPLAY)
        {
          this.m_BattleState = BattleController.BattleState.BATTLE_SUPPORT_DISPLAY;
          this.m_SubStateFlag = (byte) 0;
          this.deltaTime = 0.0f;
          this.updateSupportDisplayFreeze(true);
        }
      }
    }
    if (num != (byte) 0)
      return;
    ParticleManager.Instance.Spawn((ushort) 295, (Transform) null, au.Position, 1f, true, false);
  }

  private bool CheckExec(int Cmd, int Side, HERO_STATE_ENUM State)
  {
    if (State == HERO_STATE_ENUM.HERO_COMMANDS_REMOVE_STATE || State == HERO_STATE_ENUM.HERO_COMMANDS_STOP_CHANNEL || State == HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_POINT_END || State == HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_TARGET_END || State == HERO_STATE_ENUM.HERO_COMMANDS_KNOCK_BACK_END)
    {
      if ((Cmd & 1) != 0 && Side == 1 || (Cmd & 2) != 0 && Side == 0 || (Cmd & 4) != 0 && Side == 0 || (Cmd & 8) != 0 && Side == 1)
        return false;
    }
    else if ((Cmd & 3) != 0)
      return false;
    return true;
  }

  public void updateMaxSkillFreeze(bool bWorking)
  {
    if (bWorking)
    {
      int playerCount = this.playerCount;
      int num = this.enemyCount <= playerCount ? playerCount : this.enemyCount;
      for (int idx = 0; idx < num; ++idx)
      {
        if (idx < this.playerCount)
        {
          if (!this.isSkillWorking(idx))
            this.playerUnit[idx].setMaxSkillFreeze(true);
          else if (idx != this.m_CurUltraIndex)
            this.playerUnit[idx].setMaxSkillFreeze(false);
        }
        if (idx < this.enemyCount)
        {
          if (!this.isSkillWorking(idx + 5))
            this.enemyUnit[idx].setMaxSkillFreeze(true);
          else
            this.enemyUnit[idx].setMaxSkillFreeze(false);
        }
      }
      ChaseManager.Instance.SetStopAllParticleChase(true);
      GameObject allEffecet = ParticleManager.Instance.GetAllEffecet();
      if (!(bool) (UnityEngine.Object) allEffecet)
        return;
      int childCount = allEffecet.transform.childCount;
      for (int index = 0; index < childCount; ++index)
      {
        GameObject gameObject = allEffecet.transform.GetChild(index).gameObject;
        if (gameObject.activeSelf && (UnityEngine.Object) gameObject != (UnityEngine.Object) this.ultraLoopParticle)
          ParticleManager.Instance.Pause(gameObject, true);
      }
    }
    else
    {
      int playerCount = this.playerCount;
      int num = this.enemyCount <= playerCount ? playerCount : this.enemyCount;
      for (int index = 0; index < num; ++index)
      {
        if (index < this.playerCount)
          this.playerUnit[index].setMaxSkillFreeze(false);
        if (index < this.enemyCount)
          this.enemyUnit[index].setMaxSkillFreeze(false);
      }
      ChaseManager.Instance.SetStopAllParticleChase(false);
      GameObject allEffecet = ParticleManager.Instance.GetAllEffecet();
      if (!(bool) (UnityEngine.Object) allEffecet)
        return;
      int childCount = allEffecet.transform.childCount;
      for (int index = 0; index < childCount; ++index)
      {
        GameObject gameObject = allEffecet.transform.GetChild(index).gameObject;
        if (gameObject.activeSelf)
          ParticleManager.Instance.Pause(gameObject, false);
      }
    }
  }

  private void updateSupportDisplayFreeze(bool bWorking)
  {
    if (bWorking)
    {
      int playerCount = this.playerCount;
      int num = this.enemyCount <= playerCount ? playerCount : this.enemyCount;
      for (int index = 0; index < num; ++index)
      {
        if (index < this.playerCount)
          this.playerUnit[index].setMaxSkillFreeze(true);
        if (index < this.enemyCount && this.enemyUnit[index].gameObject.activeSelf && this.enemyUnit[index].heroState != HERO_STATE_ENUM.HERO_COMMANDS_WAITING_SUPPORT)
          this.enemyUnit[index].setMaxSkillFreeze(true);
      }
      ChaseManager.Instance.SetStopAllParticleChase(true);
      GameObject allEffecet = ParticleManager.Instance.GetAllEffecet();
      if (!(bool) (UnityEngine.Object) allEffecet)
        return;
      int childCount = allEffecet.transform.childCount;
      for (int index = 0; index < childCount; ++index)
      {
        GameObject gameObject = allEffecet.transform.GetChild(index).gameObject;
        if (gameObject.activeSelf && (UnityEngine.Object) gameObject != (UnityEngine.Object) this.ultraLoopParticle)
          ParticleManager.Instance.Pause(gameObject, true);
      }
    }
    else
    {
      int playerCount = this.playerCount;
      int num = this.enemyCount <= playerCount ? playerCount : this.enemyCount;
      for (int index = 0; index < num; ++index)
      {
        if (index < this.playerCount)
          this.playerUnit[index].setMaxSkillFreeze(false);
        if (index < this.enemyCount)
          this.enemyUnit[index].setMaxSkillFreeze(false);
      }
      ChaseManager.Instance.SetStopAllParticleChase(false);
      GameObject allEffecet = ParticleManager.Instance.GetAllEffecet();
      if (!(bool) (UnityEngine.Object) allEffecet)
        return;
      int childCount = allEffecet.transform.childCount;
      for (int index = 0; index < childCount; ++index)
      {
        GameObject gameObject = allEffecet.transform.GetChild(index).gameObject;
        if (gameObject.activeSelf)
          ParticleManager.Instance.Pause(gameObject, false);
      }
    }
  }

  private void updateWaitingNPCDieFreeze(bool bWorking)
  {
    if (bWorking)
    {
      for (int index = 0; index < this.playerCount; ++index)
      {
        if (index < this.playerCount)
          this.playerUnit[index].setMaxSkillFreeze(true);
      }
      ChaseManager.Instance.SetStopAllParticleChase(true);
      GameObject allEffecet = ParticleManager.Instance.GetAllEffecet();
      if (!(bool) (UnityEngine.Object) allEffecet)
        return;
      int childCount = allEffecet.transform.childCount;
      for (int index = 0; index < childCount; ++index)
      {
        GameObject gameObject = allEffecet.transform.GetChild(index).gameObject;
        if (gameObject.activeSelf && (UnityEngine.Object) gameObject != (UnityEngine.Object) this.ultraLoopParticle)
          ParticleManager.Instance.Pause(gameObject, true);
      }
    }
    else
    {
      for (int index = 0; index < this.playerCount; ++index)
      {
        if (index < this.playerCount)
          this.playerUnit[index].setMaxSkillFreeze(false);
      }
      ChaseManager.Instance.SetStopAllParticleChase(false);
      GameObject allEffecet = ParticleManager.Instance.GetAllEffecet();
      if (!(bool) (UnityEngine.Object) allEffecet)
        return;
      int childCount = allEffecet.transform.childCount;
      for (int index = 0; index < childCount; ++index)
      {
        GameObject gameObject = allEffecet.transform.GetChild(index).gameObject;
        if (gameObject.activeSelf)
          ParticleManager.Instance.Pause(gameObject, false);
      }
    }
  }

  public void PlayGambleHitEffect()
  {
    int paramA = BattleController.GambleMode != EGambleMode.Normal ? 859 : 858;
    if ((UnityEngine.Object) this.enemyUnit[1] != (UnityEngine.Object) null && this.enemyUnit[1].gameObject.activeSelf)
      this.enemyUnit[1].setState(HERO_STATE_ENUM.HERO_COMMANDS_GETHIT, paramA: paramA, paramB: 100, paramC: 3);
    else
      this.enemyUnit[0].setState(HERO_STATE_ENUM.HERO_COMMANDS_GETHIT, paramA: paramA, paramB: 100, paramC: 3);
  }

  private ChaseType getChaseType(byte flyType)
  {
    return (int) flyType >= this.FT2CT.Length ? ChaseType.Straight : this.FT2CT[(int) flyType];
  }

  private void setupFlyItem(
    Vector3 startPos,
    AnimationUnit target,
    int flyTime,
    int skillID,
    float scaleRate)
  {
    Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey((ushort) skillID);
    if (recordByKey.FlyParticle == (ushort) 0)
      return;
    ChaseType chaseType = this.getChaseType(recordByKey.FlyType);
    Transform Target = recordByKey.FlyType != (byte) 2 ? target.HitPointRoot : target.transform;
    if (recordByKey.FlyType == (byte) 2)
      startPos.y = 0.0f;
    if (recordByKey.FlyType == (byte) 6)
    {
      this.ChaseMgr.AddChase(startPos, Target, (float) flyTime * (1f / 1000f), recordByKey.FlyParticle, scaleRate, ChaseType.CurveLeft);
      this.ChaseMgr.AddChase(startPos, Target, (float) flyTime * (1f / 1000f), recordByKey.FlyParticle, scaleRate, ChaseType.CurveRight);
    }
    else
      this.ChaseMgr.AddChase(startPos, Target, (float) flyTime * (1f / 1000f), recordByKey.FlyParticle, scaleRate, chaseType);
  }

  private void setupFlyItem(
    Vector3 startPos,
    Vector3 targetPos,
    int flyTime,
    int skillID,
    float scaleRate)
  {
    Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey((ushort) skillID);
    if (recordByKey.FlyParticle == (ushort) 0)
      return;
    ChaseType chaseType = this.getChaseType(recordByKey.FlyType);
    if (recordByKey.FlyType == (byte) 2)
    {
      startPos.y = 0.0f;
      targetPos.y = 0.0f;
    }
    if (recordByKey.FlyType == (byte) 6)
    {
      this.ChaseMgr.AddChase(startPos, targetPos, (float) flyTime * (1f / 1000f), recordByKey.FlyParticle, scaleRate, ChaseType.CurveLeft);
      this.ChaseMgr.AddChase(startPos, targetPos, (float) flyTime * (1f / 1000f), recordByKey.FlyParticle, scaleRate, ChaseType.CurveRight);
    }
    else
      this.ChaseMgr.AddChase(startPos, targetPos, (float) flyTime * (1f / 1000f), recordByKey.FlyParticle, scaleRate, chaseType);
  }

  private void setupHPMP(int side, int heroIdx, int effectIdx, uint val)
  {
    BattleController.HeroAttr[] heroAttrArray = side != 0 ? this.enemyAttr : this.playerAttr;
    switch (effectIdx)
    {
      case 0:
      case 8:
      case 10:
      case 11:
        long num1 = Math.Max((long) heroAttrArray[heroIdx].CUR_HP - (long) val, 0L);
        heroAttrArray[heroIdx].CUR_HP = (uint) num1;
        if (side != 0)
          break;
        this.uiBattle.UpdateSetSliderHP(heroIdx);
        break;
      case 1:
      case 9:
      case 12:
      case 13:
      case 14:
        uint curHp = heroAttrArray[heroIdx].CUR_HP;
        uint num2 = Math.Min(heroAttrArray[heroIdx].CUR_HP + val, heroAttrArray[heroIdx].MAX_HP);
        heroAttrArray[heroIdx].CUR_HP = num2;
        if (side == 0)
          this.uiBattle.UpdateSetSliderHP(heroIdx);
        if (curHp != 0U || num2 <= 0U)
          break;
        GUIManager.Instance.pDVMgr.SetBloodBarFillAmount(side, heroIdx, (float) num2 / (float) heroAttrArray[heroIdx].MAX_HP);
        break;
      case 2:
        uint num3 = Math.Min(heroAttrArray[heroIdx].CUR_MP + val, heroAttrArray[heroIdx].MAX_MP);
        heroAttrArray[heroIdx].CUR_MP = num3;
        if (side == 0)
          this.uiBattle.UpdateSetSliderHP(heroIdx);
        if (side != 0 || (int) num3 != (int) heroAttrArray[heroIdx].MAX_MP || this.ms_viewer[heroIdx].working != (byte) 0)
          break;
        this.ms_viewer[heroIdx].working = (byte) 1;
        break;
      case 3:
        long num4 = Math.Max((long) heroAttrArray[heroIdx].CUR_MP - (long) val, 0L);
        heroAttrArray[heroIdx].CUR_MP = (uint) num4;
        if (side == 0)
          this.uiBattle.UpdateSetSliderHP(heroIdx);
        if (side != 0 || num4 == (long) heroAttrArray[heroIdx].MAX_MP || this.ms_viewer[heroIdx].working != (byte) 1)
          break;
        this.ms_viewer[heroIdx].working = (byte) 0;
        this.ms_viewer[heroIdx].ui_state = (byte) 0;
        this.uiBattle.SetBtnTween(heroIdx, 0);
        break;
    }
  }

  public void UpdateSkillLightmap(bool bEnable, bool bBattleFinish = false)
  {
    int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
    int num1 = -1;
    int num2 = 0 + sceneLightmapSize;
    int num3 = 1 + sceneLightmapSize;
    if (!bEnable)
    {
      if ((UnityEngine.Object) this.mapObject1 != (UnityEngine.Object) null)
        this.mapObject1.renderer.lightmapIndex = 0;
      if ((UnityEngine.Object) this.mapObject2 != (UnityEngine.Object) null)
        this.mapObject2.renderer.lightmapIndex = 1;
      for (int index = 0; index < this.playerCount; ++index)
      {
        if (!((UnityEngine.Object) this.playerUnit[index].getRenderer == (UnityEngine.Object) null))
        {
          int num4 = bBattleFinish || this.playerUnit[index].StateColorSkin == 0U || this.playerUnit[index].StateColorSkin > 4U ? num1 : this.m_SkinColorLightmapIndex[(IntPtr) (this.playerUnit[index].StateColorSkin - 1U)];
          this.playerUnit[index].getRenderer.lightmapIndex = num4;
        }
      }
      for (int index = 0; index < this.enemyCount; ++index)
      {
        if (!((UnityEngine.Object) this.enemyUnit[index].getRenderer == (UnityEngine.Object) null))
        {
          int num5 = bBattleFinish || this.enemyUnit[index].StateColorSkin == 0U || this.enemyUnit[index].StateColorSkin > 4U ? num1 : this.m_SkinColorLightmapIndex[(IntPtr) (this.enemyUnit[index].StateColorSkin - 1U)];
          this.enemyUnit[index].getRenderer.lightmapIndex = num5;
        }
      }
    }
    else
    {
      int skillWorkingList = this.m_MaxSkillWorkingList;
      if ((UnityEngine.Object) this.mapObject1 != (UnityEngine.Object) null)
        this.mapObject1.renderer.lightmapIndex = num2;
      if ((UnityEngine.Object) this.mapObject2 != (UnityEngine.Object) null)
        this.mapObject2.renderer.lightmapIndex = num2;
      int index1 = 0;
      while (index1 < this.playerCount)
      {
        if (!((UnityEngine.Object) this.playerUnit[index1].getRenderer == (UnityEngine.Object) null))
          this.playerUnit[index1].getRenderer.lightmapIndex = (skillWorkingList & 1) <= 0 ? num2 : num3;
        ++index1;
        skillWorkingList >>= 1;
      }
      int num6 = this.m_MaxSkillWorkingList >> 5;
      int index2 = 0;
      while (index2 < this.enemyCount)
      {
        if (!((UnityEngine.Object) this.enemyUnit[index2].getRenderer == (UnityEngine.Object) null))
          this.enemyUnit[index2].getRenderer.lightmapIndex = (num6 & 1) <= 0 ? num2 : num3;
        ++index2;
        num6 >>= 1;
      }
    }
  }

  public void updateUltraSelectLightmap(uint hitList)
  {
    int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
    int num1 = -1;
    int num2 = 0 + sceneLightmapSize;
    DamageValueManager pDvMgr = GUIManager.Instance.pDVMgr;
    Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(DataManager.Instance.HeroTable.GetRecordByKey(this.playerUnit[this.m_CurUltraIndex].NpcID).AttackPower[1]);
    AnimationUnit[] animationUnitArray = recordByKey.SkillKind <= (byte) 50 ? this.enemyUnit : this.playerUnit;
    int num3 = recordByKey.SkillKind <= (byte) 50 ? this.enemyCount : this.playerCount;
    int side = recordByKey.SkillKind <= (byte) 50 ? 1 : 0;
    for (int iIndex = 0; iIndex < num3; ++iIndex)
    {
      if (((int) (hitList >> iIndex) & 1) != 0)
      {
        animationUnitArray[iIndex].getRenderer.lightmapIndex = num1;
        pDvMgr.ShowBloodBar(side, iIndex);
      }
      else
      {
        animationUnitArray[iIndex].getRenderer.lightmapIndex = num2;
        pDvMgr.HideBloodBar(side, iIndex);
      }
    }
  }

  public bool movePlayerOutside(EMovePlayerOutside mode = EMovePlayerOutside.Default)
  {
    if (this.m_BattleResult == (byte) 1)
    {
      if (!this.IsType(EBattleType.GAMBLE))
      {
        for (int index = 0; index < this.playerCount; ++index)
        {
          if (this.playerUnit[index].enabled && this.playerUnit[index].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
            this.playerUnit[index].setState(HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_RUN);
        }
        int num1 = (int) this.BSUtil.setNextStage(BattleController.RecvBufferLeft, BattleController.RecvBufferRight);
        int startIdx1 = 1;
        for (int index1 = 0; index1 < (int) BattleController.RecvBufferLeft[0]; ++index1)
        {
          int iIndex = (int) GameConstants.ConvertBytesToUShort(BattleController.RecvBufferLeft, startIdx1);
          int startIdx2 = startIdx1 + 6;
          uint num2 = GameConstants.ConvertBytesToUInt(BattleController.RecvBufferLeft, startIdx2);
          int startIdx3 = startIdx2 + 4;
          ushort num3 = GameConstants.ConvertBytesToUShort(BattleController.RecvBufferLeft, startIdx3);
          int index2 = startIdx3 + 2;
          byte num4 = BattleController.RecvBufferLeft[index2];
          startIdx1 = index2 + 1;
          long iValue1 = (long) (num2 - this.playerAttr[iIndex].CUR_HP);
          if (iValue1 > 0L)
            GUIManager.Instance.pDVMgr.AddDamageValueEffect((uint) iValue1, 0, iIndex, HERO_EFFECTTYPE_ENUM.HERO_EFFECT_RECOVER);
          this.playerAttr[iIndex].CUR_HP = num2;
          long iValue2 = (long) ((uint) num3 - this.playerAttr[iIndex].CUR_MP);
          if (iValue2 > 0L)
            GUIManager.Instance.pDVMgr.AddDamageValueEffect((uint) iValue2, 0, iIndex, HERO_EFFECTTYPE_ENUM.HERO_EFFECT_ADDENERGY);
          this.playerAttr[iIndex].CUR_MP = (uint) num3;
        }
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle, 1);
      }
      else
      {
        for (int index = 0; index < this.playerCount; ++index)
        {
          if (this.playerUnit[index].enabled && this.playerUnit[index].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
            this.playerUnit[index].setState(HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_RUN_GAMBLE);
        }
      }
    }
    else
    {
      switch (mode)
      {
        case EMovePlayerOutside.BattleFailed:
          for (int index = 0; index < this.playerCount; ++index)
          {
            if (this.playerUnit[index].enabled && this.playerUnit[index].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
            {
              Vector3 position = this.playerUnit[index].Position with
              {
                x = -100f
              };
              this.playerUnit[index].movePos = new Vector3?(position);
              this.playerUnit[index].Target = (GameObject) null;
              this.playerUnit[index].cleanAttackParticle();
              this.playerUnit[index].cleanStateParticle();
              this.playerUnit[index].setState(HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_RUN);
            }
          }
          break;
        case EMovePlayerOutside.GambleFailed:
          for (int index = 0; index < this.playerCount; ++index)
          {
            if (this.playerUnit[index].enabled && this.playerUnit[index].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
            {
              Vector3 position = this.playerUnit[index].Position with
              {
                x = 100f
              };
              this.playerUnit[index].movePos = new Vector3?(position);
              this.playerUnit[index].Target = (GameObject) null;
              this.playerUnit[index].cleanAttackParticle();
              this.playerUnit[index].cleanStateParticle();
            }
          }
          break;
      }
    }
    return true;
  }

  public bool CheckNextLevel()
  {
    return this.m_CurStageLevel < this.m_MaxStageLevel && this.m_BattleResult == (byte) 1;
  }

  public bool ReturnFirstStage()
  {
    if (this.m_BattleResult != (byte) 2 && (this.m_CurStageLevel != this.m_MaxStageLevel || this.m_BattleResult != (byte) 1))
      return false;
    GUIManager.Instance.OpenMenu(EGUIWindow.UI_Settlement, bCameraMode: true);
    return true;
  }

  public void SetBattleCameraModel()
  {
    if (this.BCamera == null)
      return;
    BattleController.CameraModel = BattleController.CameraModel != (byte) 0 ? (byte) 0 : (byte) 1;
    this.BCamera.initCamera(this.playerUnit, this.playerCount, this.enemyUnit, this.enemyCount);
  }

  private Vector3 getRewardRandomPos()
  {
    int index = UnityEngine.Random.Range(0, (int) this.m_RewardRandomFlag);
    Vector3 rewardRandomPo = this.m_RewardRandomPos[index];
    if (this.m_RewardRandomFlag == (byte) 1)
    {
      this.m_RewardRandomFlag = (byte) this.m_RewardRandomPos.Length;
    }
    else
    {
      --this.m_RewardRandomFlag;
      this.m_RewardRandomPos[index] = this.m_RewardRandomPos[(int) this.m_RewardRandomFlag];
      this.m_RewardRandomPos[(int) this.m_RewardRandomFlag] = rewardRandomPo;
    }
    return rewardRandomPo;
  }

  private void initRewardData()
  {
    if (this.m_CurStageLevel == 1)
      this.m_RewardCount = (ushort) 0;
    this.m_RewardOffset += this.m_RewardCount;
    this.m_RewardCount = (ushort) DataManager.Instance.RewardLen[this.m_CurStageLevel - 1];
    this.m_DropRewardCount = (ushort) 0;
    int num1 = Mathf.Max(1, this.m_MaxStageLevel != this.m_CurStageLevel ? this.enemyCount : this.enemyCount - 1);
    byte num2 = (byte) ((uint) this.m_RewardCount / (uint) num1);
    byte num3 = (byte) ((uint) this.m_RewardCount - (uint) num2 * (uint) num1);
    Array.Clear((Array) this.m_DropPerEnemy, 0, 20);
    int enemyCount = this.enemyCount;
    for (int index = 0; index < enemyCount; ++index)
    {
      this.m_HeroIDFilter[index] = index;
      this.m_DropPerEnemy[index] = num2;
    }
    for (int index1 = 0; index1 < (int) num3; ++index1)
    {
      int index2 = UnityEngine.Random.Range(0, enemyCount);
      --enemyCount;
      int index3 = this.m_HeroIDFilter[index2];
      this.m_HeroIDFilter[index2] = this.m_HeroIDFilter[enemyCount];
      ++this.m_DropPerEnemy[index3];
    }
    Array.Clear((Array) this.m_HeroIDFilter, 0, 25);
  }

  public void CaleRewardDropDown(AnimationUnit au)
  {
    if ((UnityEngine.Object) au == (UnityEngine.Object) null)
      return;
    int num1 = 1;
    if ((double) ((Vector2) Camera.main.WorldToScreenPoint(au.Position)).y < (double) RewardManager.getInstance.ScreenSize.y * 0.5)
      num1 = -1;
    DataManager instance = DataManager.Instance;
    int num2 = 0;
    if (this.enemyCount <= 1 || this.enemyAliveCount == 0)
    {
      num2 = (int) this.m_RewardCount - (int) this.m_DropRewardCount;
    }
    else
    {
      int index = this.enemyCount - this.enemyAliveCount - 1;
      if (index < this.m_DropPerEnemy.Length)
        num2 = (int) this.m_DropPerEnemy[index];
    }
    for (int index = 0; index < num2 && (int) this.m_DropRewardCount < (int) this.m_RewardCount; ++index)
    {
      ushort itemID = instance.RewardData[(int) this.m_RewardOffset + (int) this.m_DropRewardCount];
      ++this.m_DropRewardCount;
      RewardManager.getInstance.addReward(itemID, au.HitPointRoot.position, au.Position + this.getRewardRandomPos() * (float) num1, (byte) 0);
    }
    if (!au.IsBoss)
      return;
    int num3 = (int) instance.RewardLen[0] + (int) instance.RewardLen[1] + (int) instance.RewardLen[2];
    for (int index = 0; index < (int) instance.RewardLen[3]; ++index)
      RewardManager.getInstance.addReward(instance.RewardData[num3 + index], au.HitPointRoot.position, au.Position + this.getRewardRandomPos() * (float) num1, (byte) 0);
  }

  public static Vector3? Tracing(Vector3 lineVector, Vector3 linePoint)
  {
    if ((double) Math.Abs(lineVector[1]) < 9.9999997473787516E-05)
      return new Vector3?();
    Vector3 zero = Vector3.zero;
    float num = -linePoint[1] / lineVector[1];
    zero[0] = linePoint[0] + lineVector[0] * num;
    zero[1] = linePoint[1] + lineVector[1] * num;
    zero[2] = linePoint[2] + lineVector[2] * num;
    return new Vector3?(zero);
  }

  public void EventCallBack(AnimationUnit au, EAUCallBack type, int param = 0)
  {
    if (type != EAUCallBack.MAXSKILL_HITPOINT)
      return;
    AnimationUnit[] animationUnitArray = !au.IsEnemy ? this.playerUnit : this.enemyUnit;
    int num = !au.IsEnemy ? this.playerCount : this.enemyCount;
    for (int index = 0; index < num; ++index)
    {
      if ((UnityEngine.Object) au == (UnityEngine.Object) animationUnitArray[index])
      {
        int idx = !au.IsEnemy ? index : index + 5;
        if (au.IsEnemy || index != this.m_CurUltraIndex)
        {
          this.setMaxSkillWorkingList(idx, false);
          this.updateMaxSkillFreeze(true);
          this.UpdateSkillLightmap(true);
          au.checkFireParticle();
          au.playUltraHitSound();
          au.checkChannelSkillAnim();
          break;
        }
        au.playUltraLoopAnim(true);
        Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(DataManager.Instance.HeroTable.GetRecordByKey(au.NpcID).AttackPower[1]);
        Transform transform = recordByKey.UltraParticlePos != (byte) 1 ? au.transform : au.WP;
        Transform parent = recordByKey.UltraParticlePos != (byte) 2 ? transform : au.HitPointRoot;
        bool flag = recordByKey.UltraParticlePos != (byte) 0;
        if ((UnityEngine.Object) this.ultraLoopParticle == (UnityEngine.Object) null)
        {
          if (flag)
          {
            this.ultraLoopParticle = ParticleManager.Instance.Spawn(recordByKey.UltraParticle, parent, Vector3.zero, 1f, true);
            if ((UnityEngine.Object) this.ultraLoopParticle != (UnityEngine.Object) null && recordByKey.UltraParticlePos == (byte) 3)
              this.ultraLoopParticle.transform.rotation = Quaternion.LookRotation(au.transform.forward);
          }
          else
            this.ultraLoopParticle = ParticleManager.Instance.Spawn(recordByKey.UltraParticle, au.transform, parent.position, 1f, true, false);
        }
        if (this.ultraHitSoundKey != byte.MaxValue)
          AudioManager.Instance.StopSFX(this.ultraHitSoundKey);
        AudioManager.Instance.PlaySFXLoop(recordByKey.UltraSound, out this.ultraHitSoundKey, au.transform);
        break;
      }
    }
  }

  public bool checkInitUltra(int idx)
  {
    if (this.m_BattleState != BattleController.BattleState.BATTLE_RUNNING && this.m_BattleState != BattleController.BattleState.BATTLE_MAXSKILL_WORKING || this.MaxSkillBitList != 0 && this.m_BattleState != BattleController.BattleState.BATTLE_MAXSKILL_WORKING || (this.MaxSkillBitList >> idx & 1) != 0)
      return false;
    float posX = 0.0f;
    float posY = 0.0f;
    if (!this.BSUtil.initUltra((byte) idx, ref this.closetHeroIndexCache, ref posX, ref posY))
      return false;
    this.playerUnit[idx].setPositionInstantly(new Vector3(posX, 0.0f, posY));
    this.useMaxSkill(0, idx);
    this.m_CurUltraIndex = idx;
    this.lastNearestTargetIndex = -1;
    this.m_HitContainerSide = DataManager.Instance.SkillTable.GetRecordByKey(DataManager.Instance.HeroTable.GetRecordByKey(this.playerUnit[this.m_CurUltraIndex].NpcID).AttackPower[1]).SkillKind <= (byte) 50 ? (byte) 1 : (byte) 0;
    return true;
  }

  public void inputUltraForNewbie(Vector3 pos)
  {
    if ((double) Vector3.Distance(pos, this.playerUnit[this.m_CurUltraIndex].Position) > (double) this.PJ_FireRange)
    {
      Vector3 vector3 = pos - this.playerUnit[this.m_CurUltraIndex].Position;
      vector3.Normalize();
      pos = this.playerUnit[this.m_CurUltraIndex].Position + vector3 * this.PJ_FireRange;
      pos.y = 0.0f;
    }
    this.BSUtil.ultraInput((double) pos.x > 0.0 ? (byte) (((double) pos.x > 23.799999237060547 ? 23.799999237060547 : (double) pos.x) * 10.0) : (byte) 0, (double) pos.z > 0.0 ? (byte) (((double) pos.z > 11.0 ? 11.0 : (double) pos.z) * 10.0) : (byte) 0);
    if (this.m_HitContainerSide != (byte) 0)
    {
      DamageValueManager pDvMgr = GUIManager.Instance.pDVMgr;
      if (this.m_HitContainerSide != (byte) 0)
      {
        for (int iIndex = 0; iIndex < this.enemyCount; ++iIndex)
          pDvMgr.HideBloodBar(1, iIndex);
      }
      else
      {
        for (int iIndex = 0; iIndex < this.playerCount; ++iIndex)
          pDvMgr.HideBloodBar(0, iIndex);
      }
    }
    if (this.playerUnit[this.m_CurUltraIndex].IsMaxSkillLooping)
    {
      this.playerUnit[this.m_CurUltraIndex].playUltraLoopAnim(false);
      if ((UnityEngine.Object) this.ultraLoopParticle != (UnityEngine.Object) null)
      {
        ParticleManager.Instance.DeSpawn(this.ultraLoopParticle);
        this.ultraLoopParticle = (GameObject) null;
      }
      this.setMaxSkillWorkingList(this.m_CurUltraIndex, false);
      this.updateMaxSkillFreeze(true);
      this.playerUnit[this.m_CurUltraIndex].checkFireParticle();
      this.playerUnit[this.m_CurUltraIndex].playUltraHitSound();
      if (this.ultraHitSoundKey != byte.MaxValue)
      {
        AudioManager.Instance.StopSFX(this.ultraHitSoundKey);
        this.ultraHitSoundKey = byte.MaxValue;
      }
    }
    this.m_CurUltraIndex = -1;
  }

  public void inputUltra(bool bControlSelf, Ray? ray = null)
  {
    if (bControlSelf)
    {
      if (this.lastNearestTargetIndex != -1)
      {
        this.BSUtil.ultraInput((byte) this.lastNearestTargetIndex, (byte) 0);
      }
      else
      {
        if (!ray.HasValue)
          ray = new Ray?(new Ray());
        Vector3 a = BattleController.Tracing(ray.Value.direction, ray.Value.origin).Value;
        if (NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
          a = this.enemyUnit[0].Position;
        if ((double) Vector3.Distance(a, this.playerUnit[this.m_CurUltraIndex].Position) > (double) this.PJ_FireRange)
        {
          Vector3 vector3 = a - this.playerUnit[this.m_CurUltraIndex].Position;
          vector3.Normalize();
          a = (this.playerUnit[this.m_CurUltraIndex].Position + vector3 * this.PJ_FireRange) with
          {
            y = 0.0f
          };
        }
        this.BSUtil.ultraInput((double) a.x > 0.0 ? (byte) (((double) a.x > 23.799999237060547 ? 23.799999237060547 : (double) a.x) * 10.0) : (byte) 0, (double) a.z > 0.0 ? (byte) (((double) a.z > 11.0 ? 11.0 : (double) a.z) * 10.0) : (byte) 0);
      }
      if (this.m_HitContainerSide != (byte) 0)
      {
        DamageValueManager pDvMgr = GUIManager.Instance.pDVMgr;
        if (this.m_HitContainerSide != (byte) 0)
        {
          for (int iIndex = 0; iIndex < this.enemyCount; ++iIndex)
            pDvMgr.HideBloodBar(1, iIndex);
        }
        else
        {
          for (int iIndex = 0; iIndex < this.playerCount; ++iIndex)
            pDvMgr.HideBloodBar(0, iIndex);
        }
      }
    }
    else
    {
      Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(DataManager.Instance.HeroTable.GetRecordByKey(this.playerUnit[this.m_CurUltraIndex].NpcID).AttackPower[1]);
      int num1 = recordByKey.SkillKind <= (byte) 50 ? this.enemyCount : this.playerCount;
      AnimationUnit[] animationUnitArray = recordByKey.SkillKind <= (byte) 50 ? this.enemyUnit : this.playerUnit;
      if (Array.IndexOf<byte>(this.PJ_GraphKind[4], recordByKey.SkillKind) > -1)
      {
        int index1 = -1;
        float num2 = -1f;
        this.BSUtil.checkUltraHitTarget((byte) 0, (byte) 0, ref this.m_HitContainer);
        for (int index2 = 0; index2 < num1; ++index2)
        {
          if (((int) (this.m_HitContainer >> index2) & 1) != 0)
          {
            float num3 = GameConstants.DistanceSquare(animationUnitArray[index2].Position, this.playerUnit[this.m_CurUltraIndex].Position);
            if ((double) num3 > (double) num2)
            {
              index1 = index2;
              num2 = num3;
            }
          }
        }
        if (index1 != -1)
        {
          if (recordByKey.SkillKind <= (byte) 50 || index1 != this.m_CurUltraIndex)
            this.playerUnit[this.m_CurUltraIndex].updateDirection(animationUnitArray[index1].Position);
          this.BSUtil.ultraInput((byte) index1, (byte) 0);
        }
      }
      else if (this.closetHeroIndexCache >= (byte) 0 && (int) this.closetHeroIndexCache < num1)
      {
        bool flag = false;
        byte num4;
        byte num5;
        if ((double) Vector3.Distance(this.playerUnit[this.m_CurUltraIndex].Position, animationUnitArray[(int) this.closetHeroIndexCache].Position) > (double) recordByKey.SkillDistance * 0.0099999997764825821)
        {
          Vector3 vector3 = animationUnitArray[(int) this.closetHeroIndexCache].Position - this.playerUnit[this.m_CurUltraIndex].Position;
          vector3.Normalize();
          vector3 = this.playerUnit[this.m_CurUltraIndex].Position + vector3 * ((float) recordByKey.SkillDistance * 0.01f);
          num4 = (byte) ((double) vector3.x * 10.0);
          num5 = (byte) ((double) vector3.z * 10.0);
          if (recordByKey.SkillDistance == (ushort) 0)
            flag = true;
        }
        else
        {
          num4 = (byte) ((double) animationUnitArray[(int) this.closetHeroIndexCache].Position.x * 10.0);
          num5 = (byte) ((double) animationUnitArray[(int) this.closetHeroIndexCache].Position.z * 10.0);
        }
        if ((recordByKey.SkillKind <= (byte) 50 || (int) this.closetHeroIndexCache != this.m_CurUltraIndex) && !flag)
          this.playerUnit[this.m_CurUltraIndex].updateDirection(new Vector3((float) num4 * 0.1f, 0.0f, (float) num5 * 0.1f));
        this.BSUtil.ultraInput(num4, num5);
      }
    }
    if (this.playerUnit[this.m_CurUltraIndex].IsMaxSkillLooping)
    {
      this.playerUnit[this.m_CurUltraIndex].playUltraLoopAnim(false);
      if ((UnityEngine.Object) this.ultraLoopParticle != (UnityEngine.Object) null)
      {
        ParticleManager.Instance.DeSpawn(this.ultraLoopParticle);
        this.ultraLoopParticle = (GameObject) null;
      }
      this.setMaxSkillWorkingList(this.m_CurUltraIndex, false);
      this.updateMaxSkillFreeze(true);
      this.playerUnit[this.m_CurUltraIndex].checkFireParticle();
      this.playerUnit[this.m_CurUltraIndex].playUltraHitSound();
      if (this.ultraHitSoundKey != byte.MaxValue)
      {
        AudioManager.Instance.StopSFX(this.ultraHitSoundKey);
        this.ultraHitSoundKey = byte.MaxValue;
      }
    }
    this.m_CurUltraIndex = -1;
  }

  public void getUltraTargets(byte param1, byte param2)
  {
    uint HitNum = 0;
    this.BSUtil.checkUltraHitTarget(param1, param2, ref HitNum);
    if ((int) HitNum != (int) this.m_HitContainer)
      this.updateUltraSelectLightmap(HitNum);
    this.m_HitContainer = HitNum;
  }

  public Transform getProjectorParent() => this.projector_parent;

  public AnimationUnit getUltraSkiller() => this.playerUnit[this.m_CurUltraIndex];

  public void updateNearestTargetHightlight(Vector3 mousePos)
  {
    if (this.m_HitContainer == 0U)
      return;
    bool flag1 = DataManager.Instance.SkillTable.GetRecordByKey(DataManager.Instance.HeroTable.GetRecordByKey(this.playerUnit[this.m_CurUltraIndex].NpcID).AttackPower[1]).SkillKind > (byte) 50;
    AnimationUnit[] animationUnitArray = !flag1 ? this.enemyUnit : this.playerUnit;
    int num1 = !flag1 ? this.enemyCount : this.playerCount;
    int index1 = -1;
    float num2 = 999999f;
    for (int index2 = 0; index2 < num1; ++index2)
    {
      if (((int) (this.m_HitContainer >> index2) & 1) != 0)
      {
        float num3 = GameConstants.DistanceSquare(animationUnitArray[index2].Position, mousePos);
        if ((double) num3 < (double) num2)
        {
          index1 = index2;
          num2 = num3;
        }
      }
    }
    if (index1 == -1 || this.lastNearestTargetIndex == index1)
      return;
    this.lastNearestTargetIndex = index1;
    int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
    int num4 = -1;
    int num5 = 0 + sceneLightmapSize;
    DamageValueManager pDvMgr = GUIManager.Instance.pDVMgr;
    int side = !flag1 ? 1 : 0;
    for (int iIndex = 0; iIndex < num1; ++iIndex)
    {
      if (!flag1 || flag1 && iIndex != this.m_CurUltraIndex)
      {
        bool flag2 = iIndex == this.lastNearestTargetIndex;
        animationUnitArray[iIndex].getRenderer.lightmapIndex = !flag2 ? num5 : num4;
        if (flag2)
          pDvMgr.ShowBloodBar(side, iIndex);
        else
          pDvMgr.HideBloodBar(side, iIndex);
      }
    }
    Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(animationUnitArray[index1].NpcID);
    this.sp_projector.ShadowSize = (float) recordByKey.Radius * (1f / 500f);
    this.sp_projector.transform.position = animationUnitArray[index1].Position;
    if (!flag1 || flag1 && index1 != this.m_CurUltraIndex)
      this.playerUnit[this.m_CurUltraIndex].updateDirection(animationUnitArray[index1].Position);
    float num6 = Vector3.Distance(this.enemyUnit[index1].Position, this.playerUnit[this.m_CurUltraIndex].Position) - (float) recordByKey.Radius * 0.02f;
    float num7 = (double) num6 <= 1.0 ? num6 : num6 - 0.5f;
    this.sp_projector_line_transform.localScale = new Vector3(3f / 500f, num7 * 0.05f, 3f / 500f);
    Vector3 forward = this.enemyUnit[index1].Position - this.playerUnit[this.m_CurUltraIndex].Position;
    forward.Normalize();
    this.sp_projector_line.transform.rotation = Quaternion.LookRotation(forward);
    this.sp_projector_line.transform.Rotate(270f, 0.0f, 0.0f);
    this.sp_projector_line.transform.position = this.playerUnit[this.m_CurUltraIndex].Position + forward * num7 * 0.5f;
  }

  public Transform setupTeachProjector(bool bShow, int projectorType)
  {
    if (bShow)
    {
      Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(DataManager.Instance.HeroTable.GetRecordByKey(this.playerUnit[this.m_CurUltraIndex].NpcID).AttackPower[1]);
      this.newbie_projector_parent.position = new Vector3(0.0f, 0.01f, 0.0f);
      this.newbie_projector_parent.rotation = Quaternion.identity;
      this.newbie_projector.gameObject.SetActive(true);
      switch (projectorType)
      {
        case 3:
          this.newbie_projector_parent.position = this.playerUnit[this.m_CurUltraIndex].Position with
          {
            y = 0.01f
          };
          this.newbie_projector.UVRect = this.ProjectorUV[2];
          this.newbie_projector.ShadowSize = (float) recordByKey.Rangeparameter1 * 0.0005f;
          break;
        case 5:
          this.newbie_projector.UVRect = this.ProjectorUV[4];
          this.newbie_projector_line.gameObject.SetActive(true);
          break;
      }
      return this.newbie_projector.gameObject.transform;
    }
    this.newbie_projector.gameObject.SetActive(false);
    this.newbie_projector_line.gameObject.SetActive(false);
    return (Transform) null;
  }

  public Transform setupProjector(bool bShow, ref int projectorType)
  {
    if (bShow)
    {
      Hero recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(this.playerUnit[this.m_CurUltraIndex].NpcID);
      Skill recordByKey2 = DataManager.Instance.SkillTable.GetRecordByKey(recordByKey1.AttackPower[1]);
      projectorType = 0;
      for (int index = 0; index < this.PJ_GraphKind.Length; ++index)
      {
        if (Array.IndexOf<byte>(this.PJ_GraphKind[index], recordByKey2.SkillKind) > -1)
        {
          projectorType = index + 1;
          break;
        }
      }
      this.projector_parent.position = new Vector3(0.0f, 0.01f, 0.0f);
      this.projector_parent.rotation = Quaternion.identity;
      this.sp_projector_dist.gameObject.SetActive(true);
      this.sp_projector.gameObject.SetActive(true);
      switch (projectorType)
      {
        case 0:
          this.sp_projector_dist.ShadowSize = 0.0f;
          this.sp_projector.UVRect = this.ProjectorUV[1];
          this.sp_projector.ShadowSize = 0.0f;
          this.sp_projector_transform.localScale = Vector3.zero;
          break;
        case 1:
          this.sp_projector_dist.ShadowSize = (float) ((int) recordByKey1.Radius + (int) recordByKey2.SkillDistance) * (1f / 1000f);
          this.sp_projector_dist.transform.position = this.playerUnit[this.m_CurUltraIndex].Position;
          this.sp_projector.UVRect = this.ProjectorUV[1];
          this.sp_projector.ShadowSize = (float) recordByKey2.Rangeparameter1 * (1f / 1000f);
          break;
        case 2:
          this.sp_projector_dist.ShadowSize = 0.0f;
          this.sp_projector.UVRect = this.ProjectorUV[1];
          this.sp_projector.ShadowSize = (float) recordByKey2.Rangeparameter1 * (1f / 1000f);
          this.sp_projector.transform.position = this.playerUnit[this.m_CurUltraIndex].Position;
          this.BSUtil.checkUltraHitTarget((byte) 0, (byte) 0, ref this.m_HitContainer);
          bool flag = recordByKey2.SkillKind > (byte) 50;
          AnimationUnit[] animationUnitArray = !flag ? this.enemyUnit : this.playerUnit;
          int num1 = !flag ? this.enemyCount : this.playerCount;
          DamageValueManager pDvMgr1 = GUIManager.Instance.pDVMgr;
          int side = !flag ? 1 : 0;
          int sceneLightmapSize1 = LightmapManager.Instance.SceneLightmapSize;
          int num2 = -1;
          int num3 = 0 + sceneLightmapSize1;
          for (int iIndex = 0; iIndex < num1; ++iIndex)
          {
            if (((int) (this.m_HitContainer >> iIndex) & 1) != 0 && animationUnitArray[iIndex].getRenderer.lightmapIndex == num3)
            {
              animationUnitArray[iIndex].getRenderer.lightmapIndex = num2;
              pDvMgr1.ShowBloodBar(side, iIndex);
            }
          }
          break;
        case 3:
          this.sp_projector_dist.ShadowSize = 0.0f;
          this.projector_parent.position = this.playerUnit[this.m_CurUltraIndex].Position with
          {
            y = 0.01f
          };
          this.sp_projector.UVRect = this.ProjectorUV[2];
          this.sp_projector.ShadowSize = (float) recordByKey2.Rangeparameter1 * 0.0005f;
          break;
        case 4:
          this.sp_projector_dist.ShadowSize = 0.0f;
          this.projector_parent.position = this.playerUnit[this.m_CurUltraIndex].Position with
          {
            y = 0.01f
          };
          this.sp_projector.UVRect = this.ProjectorUV[3];
          float num4 = (float) recordByKey2.Rangeparameter1 * 0.0005f;
          float y = (float) recordByKey2.Rangeparameter2 * 0.0005f;
          this.sp_projector_transform.localScale = new Vector3(num4, y, num4);
          break;
        case 5:
          this.sp_projector_dist.ShadowSize = (float) ((int) recordByKey1.Radius + (int) recordByKey2.SkillDistance) * (1f / 1000f);
          this.sp_projector_dist.transform.position = this.playerUnit[this.m_CurUltraIndex].Position;
          this.sp_projector.UVRect = this.ProjectorUV[4];
          this.BSUtil.checkUltraHitTarget((byte) 0, (byte) 0, ref this.m_HitContainer);
          this.sp_projector_line.gameObject.SetActive(true);
          break;
        case 6:
          this.sp_projector_dist.ShadowSize = 0.0f;
          this.sp_projector.UVRect = this.ProjectorUV[1];
          this.sp_projector.ShadowSize = 0.0f;
          this.sp_projector_transform.localScale = Vector3.zero;
          int sceneLightmapSize2 = LightmapManager.Instance.SceneLightmapSize;
          int num5 = -1;
          int num6 = 0 + sceneLightmapSize2;
          DamageValueManager pDvMgr2 = GUIManager.Instance.pDVMgr;
          if (recordByKey2.SkillKind > (byte) 50)
          {
            for (int iIndex = 0; iIndex < this.playerCount; ++iIndex)
            {
              if (this.playerUnit[iIndex].getRenderer.lightmapIndex == num6 && this.playerUnit[iIndex].gameObject.activeSelf && this.playerUnit[iIndex].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
              {
                this.playerUnit[iIndex].getRenderer.lightmapIndex = num5;
                pDvMgr2.ShowBloodBar(0, iIndex);
              }
            }
            break;
          }
          for (int iIndex = 0; iIndex < this.enemyCount; ++iIndex)
          {
            if (this.enemyUnit[iIndex].gameObject.activeSelf && this.enemyUnit[iIndex].heroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
            {
              this.enemyUnit[iIndex].getRenderer.lightmapIndex = num5;
              pDvMgr2.ShowBloodBar(1, iIndex);
            }
          }
          break;
      }
      this.PJ_FireRadius = recordByKey2.Rangeparameter2 == (ushort) 0 ? (float) recordByKey2.Rangeparameter1 * 0.01f : (float) recordByKey2.Rangeparameter2 * 0.01f;
      this.PJ_FireRange = (float) ((int) recordByKey1.Radius + (int) recordByKey2.SkillDistance) * 0.01f;
      return this.sp_projector.gameObject.transform;
    }
    if (projectorType == 4)
      this.sp_projector.ShadowSize = 0.0f;
    projectorType = 0;
    this.sp_projector.gameObject.SetActive(false);
    this.sp_projector_dist.gameObject.SetActive(false);
    this.sp_projector_line.gameObject.SetActive(false);
    return (Transform) null;
  }

  public uint NumberOfSetBits(uint i)
  {
    i -= i >> 1 & 1431655765U;
    i = (uint) (((int) i & 858993459) + ((int) (i >> 2) & 858993459));
    return (uint) (((int) i + (int) (i >> 4) & 252645135) * 16843009 >>> 24);
  }

  public void CloseDrama()
  {
    if (!this.bDramaWorking)
      return;
    this.bDramaWorking = false;
    if ((UnityEngine.Object) this.controlPanel != (UnityEngine.Object) null)
      ((Component) this.controlPanel).gameObject.SetActive(true);
    if (this.IsType(EBattleType.NEWBIE_FAKE))
    {
      DataManager.StageDataController.currentWorldMode = WorldMode.Wild;
      DataManager.StageDataController._stageMode = StageMode.Count;
      DataManager.Instance.GoToBattleOrWar = GameplayKind.Origin;
      GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
      NewbieManager.Get().LockControl();
      NewbieManager.CheckNewbie();
      GUIManager.Instance.ShowChatBox();
      GUIManager.Instance.CloseMenu(EGUIWindow.UI_Front);
    }
    else
    {
      if (!this.IsType(EBattleType.TEACH))
        return;
      NewbieManager.SetNewbieControlLock(true);
    }
  }

  public void SetupPVPOutsideNPC()
  {
    ushort pvpWatcher = this.PVPWatcherList[UnityEngine.Random.Range(0, this.PVPWatcherList.Length)];
    Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(pvpWatcher);
    GameObject go;
    if (this.m_HeroMap.ContainsKey((int) recordByKey.Modle))
    {
      BattleController.HeroRef hero = this.m_HeroMap[(int) recordByKey.Modle];
      ++hero.activeCount;
      ++hero.refCount;
      AssetBundle heroObj = (AssetBundle) hero.heroObj;
      go = ModelLoader.Instance.Load(recordByKey.Modle, heroObj, (ushort) recordByKey.TextureNo);
    }
    else
    {
      this.StringInstance.Length = 0;
      this.StringInstance.AppendFormat("Role/hero_{0:00000}", (object) recordByKey.Modle);
      int Key = 0;
      string str = this.StringInstance.ToString();
      AssetBundle assetBundle = AssetManager.GetAssetBundle(str, out Key);
      go = ModelLoader.Instance.Load(recordByKey.Modle, assetBundle, (ushort) recordByKey.TextureNo);
      this.HeroRefInstance.Set(Key, (short) 1, (short) 1, (UnityEngine.Object) assetBundle, str);
      this.m_HeroMap.Add((int) recordByKey.Modle, this.HeroRefInstance);
    }
    if (!((UnityEngine.Object) go != (UnityEngine.Object) null))
      return;
    GameObject outGO = (GameObject) null;
    AnimationUnit animationUnit = this.setupAnimationObject(go, (ushort) 3, (ushort) 0, pvpWatcher, out outGO);
    animationUnit.initComponent(pvpWatcher);
    animationUnit.IsBoss = false;
    animationUnit.IsEnemy = false;
    float rate = recordByKey.Scale == (ushort) 100 ? 1.17f : (float) ((double) recordByKey.Scale / 100.0 * 1.1699999570846558);
    animationUnit.setNpcScale(rate);
    if ((ArenaManager.Instance.ArenaPlayingData.Time & 1L) != 1L)
    {
      this.Vec3Instance.Set(12.07f, 0.43f, 10000f);
      animationUnit.updateDirection(this.Vec3Instance);
      this.Vec3Instance.Set(12.07f, 0.43f, -4.72f);
    }
    else
    {
      this.Vec3Instance.Set(12.07f, 0.43f, -10000f);
      animationUnit.updateDirection(this.Vec3Instance);
      this.Vec3Instance.Set(12.07f, 0.43f, 15.66f);
    }
    Vector3 vec3Instance = this.Vec3Instance;
    animationUnit.setPositionInstantly(this.Vec3Instance);
    animationUnit.setState(HERO_STATE_ENUM.HERO_COMMANDS_PVPNPC_IDLE);
    this.PVPWatcher = animationUnit;
  }

  public void AddGambleItemBox(ushort ItemID, byte ItemRank)
  {
    AnimationUnit animationUnit = !((UnityEngine.Object) this.enemyUnit[1] != (UnityEngine.Object) null) || !this.enemyUnit[1].gameObject.activeSelf ? this.enemyUnit[0] : this.enemyUnit[1];
    int num = 1;
    if ((double) ((Vector2) Camera.main.WorldToScreenPoint(animationUnit.Position)).y < (double) RewardManager.getInstance.ScreenSize.y * 0.5)
      num = -1;
    RewardManager.getInstance.addReward(ItemID, animationUnit.HitPointRoot.position, animationUnit.Position + this.getRewardRandomPos() * (float) num, ItemRank);
  }

  public struct HeroAttr
  {
    public uint MAX_HP;
    public uint MAX_MP;
    public uint CUR_HP;
    public uint CUR_MP;
  }

  private struct HeroRef
  {
    public UnityEngine.Object heroAsset;
    public int assetKey;
    public short refCount;
    public short activeCount;
    public CString path;

    public UnityEngine.Object heroObj
    {
      set => this.heroAsset = value;
      get
      {
        if (this.heroAsset == (UnityEngine.Object) null && this.path != null)
        {
          AssetManager.UnloadAssetBundle(this.assetKey);
          this.heroAsset = (UnityEngine.Object) AssetManager.GetAssetBundle(this.path, out this.assetKey);
        }
        return this.heroAsset;
      }
    }

    public void Set(
      int _assetKey,
      short _refCount,
      short _activeCount,
      UnityEngine.Object _heroAsset,
      string _path)
    {
      this.assetKey = _assetKey;
      this.refCount = _refCount;
      this.activeCount = _activeCount;
      this.heroAsset = _heroAsset;
      this.path = new CString(20);
      this.path.ClearString();
      this.path.Append(_path);
    }
  }

  public enum BattleState
  {
    BATTLE_STOP,
    WAITING_FOR_START,
    BATTLE_RUNNING,
    BATTLE_FINISHING,
    BATTLE_WAITTING_FOR_VICTORY,
    BATTLE_SHOW_RESULT_UI,
    BATTLE_AUTOBATTLE_WAITING,
    BATTLE_MAXSKILL_WORKING,
    BATTLE_SUPPORT_DISPLAY,
    BATTLE_FINISHING_SPREAD,
    BATTLE_CHECK_GAMBLE_TIMEOUT,
    BATTLE_CHECK_DIE_BEFORE_SUPPORT,
    BATTLE_FINISHED,
  }

  public struct MSNode
  {
    public byte working;
    public byte ui_state;
  }
}
