// Decompiled with JetBrains decompiler
// Type: ActivityManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

#nullable disable
public class ActivityManager
{
  public const byte MAX_ACTIVITY_COMING_SOON_SPEVENT = 5;
  public const byte MAX_ACTIVITY_SPECIAL_EVENT = 5;
  private const float ActivityFadeTime = 0.3f;
  private const float ActivityLastTime = 3f;
  private const float ActivityBtnChangeTime = 5f;
  public const byte ACTNEWS_MAX = 30;
  public const byte MAX_NPC_CITY_LEVEL = 5;
  public const byte MAX_NOBILITY_KINGDOM = 50;
  public const ushort MAX_ACTIVITY_MKEVENT_MATCH = 6;
  private static ActivityManager instance;
  private Door m_door;
  public ActivityDataType[] ActivityData = new ActivityDataType[2];
  public SPActivityDataType[] CSActivityData = new SPActivityDataType[5];
  public SPActivityDataType[] SPActivityData = new SPActivityDataType[5];
  public ActivityDataType[] KvKActivityData = new ActivityDataType[5];
  public ActivityDataType AllyMobilizationData = new ActivityDataType();
  public ActivityDataType KOWData = new ActivityDataType();
  public ActivityDataType AllianceSummonData = new ActivityDataType();
  public ActivityDataType NobilityActivityData = new ActivityDataType();
  public ActivityDataType AllianceWarData = new ActivityDataType();
  public bool bAskFirstData;
  public bool bAskSecondData;
  public bool bAskDetailData;
  public bool bCastleLevel;
  public bool bReOpen;
  public bool bReOpenPrize;
  private byte m_ActivityKind = 1;
  private int m_ActivityIndex;
  private float m_ActivityTime = 5f;
  private int LastTimeIndex = -1;
  public long[] LastCSActivityTime = new long[5];
  public bool[] bShowNewCSActivity = new bool[5];
  public long[] LastSPActivityTime = new long[5];
  public bool[] bShowNewSPActivity = new bool[5];
  public long AMActivityTime = -1;
  public bool bForceAMActivity;
  public long NWActivityTime = -1;
  public byte NWWonderID;
  public bool bForceNWActivity;
  public long AWActivityTime = -1;
  public byte AWActivityFlash;
  public byte MonsterCount;
  public ushort[] Monster = new ushort[5];
  public ushort[] MonsterType = new ushort[5];
  public CString[] MonstrCStr = new CString[5];
  public ulong bSpecialMonsterTreasureEvent;
  public CString[] SPActivityCStr = new CString[5];
  public int Act1arg1 = -1;
  public Vector2 Act1Pos = Vector2.zero;
  public int Act2arg1 = -1;
  public Vector2 Act2Pos = Vector2.zero;
  public int Act4arg2 = -1;
  public Vector2 Act4Pos = Vector2.zero;
  public long[] CSActivityTime = new long[5];
  public bool[] bOpenCSActivity = new bool[5];
  public long[] SPActivityTime = new long[5];
  public bool[] bOpenSPActivity = new bool[5];
  public long KvKActivityTime = -1;
  public bool bOpenKvKActivity;
  public bool bShowAMHint;
  public bool bShowAWHint;
  public uint ShowNewsNo;
  public long ReadNewsTime;
  public long RcvDailyActNewsTime;
  public byte DailyNewsLen;
  public uint[] DailyNews = new uint[30];
  public byte NewsDataLen;
  public ActNewsDataType[] NewsData = new ActNewsDataType[30];
  public SpriteAsset m_ActivityListAsset;
  public SpriteAsset m_ActivityAsset;
  public SpriteAsset m_DoorBoxAsset;
  public bool bDownLoadPic1;
  public bool bDownLoadPic2;
  public bool bDownLoadPic3;
  public bool bUpDatePic1;
  public bool bUpDatePic2;
  public bool bUpDatePic3;
  private bool bShowRunningP;
  private bool bShowRunningE;
  private long NowBeginTime;
  private long ShowRunningTime;
  public MarqueeInfoDataType[] MarqueeInfo = new MarqueeInfoDataType[14];
  public MarqueeInfoDataType[] MarqueeInfoCS = new MarqueeInfoDataType[5];
  public MarqueeInfoDataType[] MarqueeInfoSP = new MarqueeInfoDataType[5];
  public uint AllianceSummonAllianceID;
  public ushort AllianceSummonEventInfoID;
  public uint AllianceSummon_Score;
  public AllianceSummonDataType AllianceSummon_SummonData;
  public byte[] NPCCityCombatTimes = new byte[5];
  public byte FederalActKingdomWonderID;
  public byte FederalHomeKingdomWonderID;
  public byte FederalFightingWonderID;
  public byte FederalFullEventTimeWonderID;
  public ushort FederalActKingdomID;
  public byte NW_UI_SelectIndex;
  public int NW_UI_SelectWonderID = -1;
  public NWComparer NW_Comparer = new NWComparer();
  public byte NobilityKingdomNum;
  public ushort[] NobilityKingdomID = new ushort[50];
  public long AW_EventBeginTime;
  public uint AW_SignUpAllianceID;
  public byte AW_NowAllianceEnterWar;
  public byte AW_GetGift;
  public byte AW_Rank;
  public byte AW_MemberCount;
  public ushort AW_PrepareTime;
  public byte AW_FightTime;
  public ushort AW_WaitTime;
  public byte AW_PrizeGroupID;
  public EAllianceWarState AW_State;
  public EAllianceWarState AW_StateOld;
  public bool AW_bWaitOpenNext;
  public bool AW_bcalculateEnd;
  public byte AW_Round;
  public long AW_RoundBeginTime;
  public long AW_RoundEndTime;
  public uint mAW_OneRoundTime;
  public byte AW_NextRank;
  public byte AW_MaxRank = 5;
  public byte AW_MinRank = 1;
  public long _ServerEventDeltaTime;
  private long m_LastServerTime;
  private CString TimeStr = new CString(100);
  public ushort TreasureBoxID;
  private EActivityType tmpActivityType = EActivityType.EAT_MAX;
  private EActivityKingdomEventType tmpActivityKingdomEventType = EActivityKingdomEventType.EAKET_MAX;
  public Dictionary<ushort, int> m_ActivityFactorIDMap_KVK = new Dictionary<ushort, int>();
  public Dictionary<ushort, int> m_ActivityFactorIDMap_AllianceSummon = new Dictionary<ushort, int>();
  public CExternalTableWithWordKey<KVKActivityScoreData> KVKScoreData;
  public CExternalTableWithWordKey<SummonScoreData> AllianceSummonScoreData;
  public double KingdomKvKRank;
  public long SPLastGetDailyGiftTime;
  public ushort KOWKingdomID;
  public CString WKTag = new CString(4);
  public CString WKName = new CString(14);
  public ushort WKIcon;
  public ushort WKKingdom;
  public uint AMAllianceID;
  public byte MatchKingdomCount;
  public ushort MatchKingdomIDCount;
  public ushort[] MatchKingdomID = new ushort[6];
  public ushort[] MatchKingdomID_4 = new ushort[4];
  public long NPCCityEndTime;
  public long NPCCityCountTime;
  public ActGetScoreFactorDataType[][] GetHuntFactor = new ActGetScoreFactorDataType[3][];
  public ushort KVKHuntCircleMin;
  public byte KVKHuntOrder;
  public long KVKReTime;
  public bool bNeedSendUpData = true;
  public float NeedSendUpDataTime = 180f;
  public BoardData[] mAllianceDonationData = new BoardData[4];
  public ushort mAllianceDonation_RandomSeed = 1;
  public byte mAllianceDonation_Gap;
  public uint mAllianceDonation_Score;
  public uint mPointIncreased;
  public long mAllianceDonation_EndTime;
  public ushort mSendAddCount;
  public List<ushort> mDonateChanceData = new List<ushort>();
  public byte RewardWonderID;
  public ActPrizeDataType[] RewardRankingPrize = new ActPrizeDataType[9];
  private AllianceWarManager _AllianceWarMgr;

  private ActivityManager()
  {
    int num1 = 2;
    for (int index = 0; index < num1; ++index)
    {
      ActivityDataType activityDataType = new ActivityDataType();
      this.ActivityData[index] = activityDataType;
    }
    int num2 = 5;
    for (int index = 0; index < num2; ++index)
    {
      ActivityDataType activityDataType = new ActivityDataType();
      this.KvKActivityData[index] = activityDataType;
    }
    int num3 = 5;
    for (int index = 0; index < num3; ++index)
    {
      SPActivityDataType activityDataType = new SPActivityDataType();
      this.CSActivityData[index] = activityDataType;
    }
    int num4 = 5;
    for (int index = 0; index < num4; ++index)
    {
      SPActivityDataType activityDataType = new SPActivityDataType();
      this.SPActivityData[index] = activityDataType;
    }
    int num5 = 5;
    for (int index = 0; index < num5; ++index)
      this.MonstrCStr[index] = new CString(300);
    for (int index = 0; index < 5; ++index)
    {
      this.LastCSActivityTime[index] = -1L;
      this.bShowNewCSActivity[index] = false;
      this.CSActivityTime[index] = -1L;
      this.bOpenCSActivity[index] = false;
    }
    for (int index = 0; index < 5; ++index)
    {
      this.LastSPActivityTime[index] = -1L;
      this.bShowNewSPActivity[index] = false;
      this.SPActivityTime[index] = -1L;
      this.bOpenSPActivity[index] = false;
      this.SPActivityCStr[index] = new CString(300);
    }
    int num6 = 14;
    for (int index = 0; index < num6; ++index)
    {
      MarqueeInfoDataType marqueeInfoDataType = new MarqueeInfoDataType();
      this.MarqueeInfo[index] = marqueeInfoDataType;
      this.MarqueeInfo[index].ActivityStr = new CString(300);
    }
    int num7 = 5;
    for (int index = 0; index < num7; ++index)
    {
      MarqueeInfoDataType marqueeInfoDataType = new MarqueeInfoDataType();
      this.MarqueeInfoCS[index] = marqueeInfoDataType;
      this.MarqueeInfoCS[index].ActivityStr = new CString(300);
    }
    int num8 = 5;
    for (int index = 0; index < num8; ++index)
    {
      MarqueeInfoDataType marqueeInfoDataType = new MarqueeInfoDataType();
      this.MarqueeInfoSP[index] = marqueeInfoDataType;
      this.MarqueeInfoSP[index].ActivityStr = new CString(300);
    }
    this.LoadActivity();
  }

  public static ActivityManager Instance
  {
    get
    {
      if (ActivityManager.instance == null)
        ActivityManager.instance = new ActivityManager();
      return ActivityManager.instance;
    }
  }

  public Door door
  {
    get
    {
      if ((UnityEngine.Object) this.m_door == (UnityEngine.Object) null)
        this.m_door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      return this.m_door;
    }
    set => this.m_door = value;
  }

  public uint AW_OneRoundTime
  {
    get
    {
      if (this.AW_Rank == (byte) 0)
        return 0;
      if (this.mAW_OneRoundTime == 0U)
        this.mAW_OneRoundTime = (uint) ((int) this.AW_PrepareTime + (int) this.AW_WaitTime + ((int) this.AW_MemberCount * 2 - 1) * (int) this.AW_FightTime);
      return this.mAW_OneRoundTime;
    }
  }

  public long ServerEventTime => DataManager.Instance.ServerTime;

  public AllianceWarManager AllianceWarMgr
  {
    get
    {
      if (this._AllianceWarMgr == null)
        this._AllianceWarMgr = new AllianceWarManager();
      return this._AllianceWarMgr;
    }
  }

  ~ActivityManager()
  {
  }

  public void CheckActivityShow()
  {
    if (!(bool) (UnityEngine.Object) this.door)
      return;
    bool flag1 = this.bShowNewCSActivity[0] || this.bShowNewCSActivity[1] || this.bShowNewCSActivity[2] || this.bShowNewCSActivity[3] || this.bShowNewCSActivity[4];
    bool flag2 = this.bShowNewSPActivity[0] || this.bShowNewSPActivity[1] || this.bShowNewSPActivity[2] || this.bShowNewSPActivity[3] || this.bShowNewSPActivity[4];
    this.door.m_ActivityAlert.SetActive(flag1 || flag2 || this.bShowAMHint || this.bForceNWActivity || this.bShowAWHint || this.ShowNewsNo > 0U);
  }

  public void SaveLastActivityTime(int Kind, int bIndex)
  {
    switch (Kind)
    {
      case 0:
        switch (bIndex)
        {
          case 0:
            PlayerPrefs.SetString("LastCSActivityTime_1", this.LastCSActivityTime[bIndex].ToString());
            return;
          case 1:
            PlayerPrefs.SetString("LastCSActivityTime_2", this.LastCSActivityTime[bIndex].ToString());
            return;
          case 2:
            PlayerPrefs.SetString("LastCSActivityTime_3", this.LastCSActivityTime[bIndex].ToString());
            return;
          case 3:
            PlayerPrefs.SetString("LastCSActivityTime_4", this.LastCSActivityTime[bIndex].ToString());
            return;
          case 4:
            PlayerPrefs.SetString("LastCSActivityTime_5", this.LastCSActivityTime[bIndex].ToString());
            return;
          default:
            return;
        }
      case 1:
        switch (bIndex)
        {
          case 0:
            PlayerPrefs.SetString("LastSPActivityTime_1", this.LastSPActivityTime[bIndex].ToString());
            return;
          case 1:
            PlayerPrefs.SetString("LastSPActivityTime_2", this.LastSPActivityTime[bIndex].ToString());
            return;
          case 2:
            PlayerPrefs.SetString("LastSPActivityTime_3", this.LastSPActivityTime[bIndex].ToString());
            return;
          case 3:
            PlayerPrefs.SetString("LastSPActivityTime_4", this.LastSPActivityTime[bIndex].ToString());
            return;
          case 4:
            PlayerPrefs.SetString("LastSPActivityTime_5", this.LastSPActivityTime[bIndex].ToString());
            return;
          default:
            return;
        }
    }
  }

  public void SavebShowNewActivity(int Kind, int bIndex)
  {
    switch (Kind)
    {
      case 0:
        switch (bIndex)
        {
          case 0:
            PlayerPrefs.SetString("bShowNewCSActivity_1", this.bShowNewCSActivity[bIndex].ToString());
            return;
          case 1:
            PlayerPrefs.SetString("bShowNewCSActivity_2", this.bShowNewCSActivity[bIndex].ToString());
            return;
          case 2:
            PlayerPrefs.SetString("bShowNewCSActivity_3", this.bShowNewCSActivity[bIndex].ToString());
            return;
          case 3:
            PlayerPrefs.SetString("bShowNewCSActivity_4", this.bShowNewCSActivity[bIndex].ToString());
            return;
          case 4:
            PlayerPrefs.SetString("bShowNewCSActivity_5", this.bShowNewCSActivity[bIndex].ToString());
            return;
          default:
            return;
        }
      case 1:
        switch (bIndex)
        {
          case 0:
            PlayerPrefs.SetString("bShowNewSPActivity_1", this.bShowNewSPActivity[bIndex].ToString());
            return;
          case 1:
            PlayerPrefs.SetString("bShowNewSPActivity_2", this.bShowNewSPActivity[bIndex].ToString());
            return;
          case 2:
            PlayerPrefs.SetString("bShowNewSPActivity_3", this.bShowNewSPActivity[bIndex].ToString());
            return;
          case 3:
            PlayerPrefs.SetString("bShowNewSPActivity_4", this.bShowNewSPActivity[bIndex].ToString());
            return;
          case 4:
            PlayerPrefs.SetString("bShowNewSPActivity_5", this.bShowNewSPActivity[bIndex].ToString());
            return;
          default:
            return;
        }
    }
  }

  public void CheckActivity(int Kind, int bIndex, long sTime)
  {
    switch (Kind)
    {
      case 0:
        if (sTime == 0L || sTime != this.LastCSActivityTime[bIndex])
        {
          this.LastCSActivityTime[bIndex] = sTime;
          this.SaveLastActivityTime(Kind, bIndex);
          this.SaveActivity(0, bIndex, sTime != 0L);
          break;
        }
        break;
      case 1:
        if (sTime == 0L || sTime != this.LastSPActivityTime[bIndex])
        {
          this.LastSPActivityTime[bIndex] = sTime;
          this.SaveLastActivityTime(Kind, bIndex);
          this.SaveActivity(1, bIndex, sTime != 0L);
          break;
        }
        break;
    }
    this.CheckActivityShow();
  }

  public void SaveActivity(int Kind, int bIndex, bool bShow)
  {
    switch (Kind)
    {
      case 0:
        this.bShowNewCSActivity[bIndex] = bShow;
        this.SavebShowNewActivity(Kind, bIndex);
        break;
      case 1:
        this.bShowNewSPActivity[bIndex] = bShow;
        this.SavebShowNewActivity(Kind, bIndex);
        break;
    }
    this.CheckActivityShow();
  }

  public void CheckNewsNo()
  {
    byte num1 = 0;
    if (this.DailyNewsLen > (byte) 0 && this.RcvDailyActNewsTime > this.ReadNewsTime)
    {
      for (int index1 = 0; index1 < (int) this.DailyNewsLen; ++index1)
      {
        for (int index2 = 0; index2 < (int) this.NewsDataLen; ++index2)
        {
          if ((int) this.DailyNews[index1] == (int) this.NewsData[index2].ID)
            ++num1;
        }
      }
    }
    byte num2 = 0;
    for (int index = 0; index < (int) this.NewsDataLen; ++index)
    {
      if (this.NewsData[index].Time > this.ReadNewsTime)
        ++num2;
    }
    this.ShowNewsNo = (int) num1 <= (int) num2 ? (uint) num2 : (uint) num1;
    this.CheckActivityShow();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 8);
  }

  public void ClearNewsNo()
  {
    this.ReadNewsTime = DataManager.Instance.ServerTime;
    PlayerPrefs.SetString("ReadNewsTime", this.ReadNewsTime.ToString());
    this.CheckNewsNo();
  }

  public void LoadActivity()
  {
    bool.TryParse(PlayerPrefs.GetString("bShowNewCSActivity_1"), out this.bShowNewCSActivity[0]);
    bool.TryParse(PlayerPrefs.GetString("bShowNewCSActivity_2"), out this.bShowNewCSActivity[1]);
    bool.TryParse(PlayerPrefs.GetString("bShowNewCSActivity_3"), out this.bShowNewCSActivity[2]);
    bool.TryParse(PlayerPrefs.GetString("bShowNewCSActivity_4"), out this.bShowNewCSActivity[3]);
    bool.TryParse(PlayerPrefs.GetString("bShowNewCSActivity_5"), out this.bShowNewCSActivity[4]);
    bool.TryParse(PlayerPrefs.GetString("bShowNewSPActivity_1"), out this.bShowNewSPActivity[0]);
    bool.TryParse(PlayerPrefs.GetString("bShowNewSPActivity_2"), out this.bShowNewSPActivity[1]);
    bool.TryParse(PlayerPrefs.GetString("bShowNewSPActivity_3"), out this.bShowNewSPActivity[2]);
    bool.TryParse(PlayerPrefs.GetString("bShowNewSPActivity_4"), out this.bShowNewSPActivity[3]);
    bool.TryParse(PlayerPrefs.GetString("bShowNewSPActivity_5"), out this.bShowNewSPActivity[4]);
    long.TryParse(PlayerPrefs.GetString("LastCSActivityTime_1"), out this.LastCSActivityTime[0]);
    long.TryParse(PlayerPrefs.GetString("LastCSActivityTime_2"), out this.LastCSActivityTime[1]);
    long.TryParse(PlayerPrefs.GetString("LastCSActivityTime_3"), out this.LastCSActivityTime[2]);
    long.TryParse(PlayerPrefs.GetString("LastCSActivityTime_4"), out this.LastCSActivityTime[3]);
    long.TryParse(PlayerPrefs.GetString("LastCSActivityTime_5"), out this.LastCSActivityTime[4]);
    long.TryParse(PlayerPrefs.GetString("LastSPActivityTime_1"), out this.LastSPActivityTime[0]);
    long.TryParse(PlayerPrefs.GetString("LastSPActivityTime_2"), out this.LastSPActivityTime[1]);
    long.TryParse(PlayerPrefs.GetString("LastSPActivityTime_3"), out this.LastSPActivityTime[2]);
    long.TryParse(PlayerPrefs.GetString("LastSPActivityTime_4"), out this.LastSPActivityTime[3]);
    long.TryParse(PlayerPrefs.GetString("LastSPActivityTime_5"), out this.LastSPActivityTime[4]);
    long.TryParse(PlayerPrefs.GetString("ReadNewsTime"), out this.ReadNewsTime);
    long.TryParse(PlayerPrefs.GetString("AMActivityTime"), out this.AMActivityTime);
    bool.TryParse(PlayerPrefs.GetString("bForceAMActivity"), out this.bForceAMActivity);
    long.TryParse(PlayerPrefs.GetString("NWActivityTime"), out this.NWActivityTime);
    byte.TryParse(PlayerPrefs.GetString("NWWonderID"), out this.NWWonderID);
    bool.TryParse(PlayerPrefs.GetString("bForceNWActivity"), out this.bForceNWActivity);
    long.TryParse(PlayerPrefs.GetString("AWActivityTime"), out this.AWActivityTime);
    byte.TryParse(PlayerPrefs.GetString("AWActivityFlash"), out this.AWActivityFlash);
  }

  public void ResetPara()
  {
    this.m_LastServerTime = 0L;
    this.m_ActivityKind = (byte) 1;
    this.m_ActivityIndex = 0;
    this.LastTimeIndex = -1;
    this.m_door = (Door) null;
    this.bAskFirstData = false;
    this.bAskSecondData = false;
    this.bAskDetailData = false;
    this.bCastleLevel = false;
    this.MonsterCount = (byte) 0;
    this.m_ActivityTime = 5f;
    this.Act1arg1 = -1;
    this.Act1Pos = Vector2.zero;
    this.Act2arg1 = -1;
    this.Act2Pos = Vector2.zero;
    this.Act4arg2 = -1;
    this.Act4Pos = Vector2.zero;
    for (int index = 0; index < 5; ++index)
    {
      this.CSActivityTime[index] = -1L;
      this.bOpenCSActivity[index] = false;
    }
    for (int index = 0; index < 5; ++index)
    {
      this.SPActivityTime[index] = -1L;
      this.bOpenSPActivity[index] = false;
    }
  }

  public void CheckNWActivityTime()
  {
    if (this.NobilityActivityData.EventState == EActivityState.EAS_None || this.NobilityActivityData.EventBeginTime == 0L || this.NWActivityTime != this.NobilityActivityData.EventBeginTime || (int) this.NWWonderID != (int) this.FederalFightingWonderID)
    {
      this.NWActivityTime = this.NobilityActivityData.EventState != EActivityState.EAS_None ? this.NobilityActivityData.EventBeginTime : 0L;
      PlayerPrefs.SetString("NWActivityTime", this.NWActivityTime.ToString());
      this.NWWonderID = this.FederalFightingWonderID;
      PlayerPrefs.SetString("NWWonderID", this.NWWonderID.ToString());
      this.SavebForceNWActivity(this.NobilityActivityData.EventBeginTime != 0L && this.NobilityActivityData.EventState == EActivityState.EAS_Run && (int) this.FederalFightingWonderID == (int) this.FederalActKingdomWonderID);
    }
    this.CheckNWShowHint();
  }

  public void SavebForceNWActivity(bool bForce)
  {
    this.bForceNWActivity = bForce;
    PlayerPrefs.SetString("bForceNWActivity", this.bForceNWActivity.ToString());
  }

  public void CheckNWShowHint()
  {
    this.CheckActivityShow();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 14);
  }

  public void CheckAMActivityTime()
  {
    if (this.AllyMobilizationData.EventState == EActivityState.EAS_None || this.AllyMobilizationData.EventBeginTime == 0L || this.AMActivityTime != this.AllyMobilizationData.EventBeginTime)
    {
      this.AMActivityTime = this.AllyMobilizationData.EventState != EActivityState.EAS_None ? this.AllyMobilizationData.EventBeginTime : 0L;
      PlayerPrefs.SetString("AMActivityTime", this.AMActivityTime.ToString());
      this.SavebForceAMActivity(this.AllyMobilizationData.EventBeginTime != 0L && this.AllyMobilizationData.EventState != EActivityState.EAS_None);
    }
    this.CheckAMShowHint();
  }

  public void SavebForceAMActivity(bool bForce)
  {
    this.bForceAMActivity = bForce;
    PlayerPrefs.SetString("bForceAMActivity", this.bForceAMActivity.ToString());
  }

  public void CheckAMShowHint()
  {
    if (this.bForceAMActivity)
    {
      this.bShowAMHint = true;
    }
    else
    {
      this.bShowAMHint = false;
      if (DataManager.Instance.RoleAlliance.Id > 0U)
      {
        MobilizationManager instance = MobilizationManager.Instance;
        if (instance.mMissionID != (ushort) 0 && (instance.mMissionStatus == (byte) 1 || instance.mMissionStatus == (byte) 2))
          this.bShowAMHint = true;
        if (!this.bShowAMHint && this.AllyMobilizationData.EventState == EActivityState.EAS_ReplayRanking && GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 15 && instance.AMCompleteDegree != (byte) 0 && (int) this.AMAllianceID == (int) DataManager.Instance.RoleAlliance.Id && !instance.IsGetPrize())
          this.bShowAMHint = true;
      }
    }
    this.CheckActivityShow();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 11);
  }

  public void CheckAWActivityTime()
  {
    if (this.AllianceWarData.EventState == EActivityState.EAS_None || this.AllianceWarData.EventBeginTime == 0L || this.AWActivityTime != this.AllianceWarData.EventBeginTime)
    {
      this.AWActivityTime = this.AllianceWarData.EventState != EActivityState.EAS_None ? this.AllianceWarData.EventBeginTime : 0L;
      this.AWActivityFlash = (byte) 0;
      PlayerPrefs.SetString("AWActivityFlash", this.AWActivityFlash.ToString());
      PlayerPrefs.SetString("AWActivityTime", this.AWActivityTime.ToString());
    }
    this.CheckAWShowHint();
  }

  public void CheckAWActivityFlash()
  {
    if (this.AWActivityFlash != (byte) 1 && this.AWActivityFlash != (byte) 3)
      return;
    ++this.AWActivityFlash;
    PlayerPrefs.SetString("AWActivityFlash", this.AWActivityFlash.ToString());
    this.CheckAWShowHint();
  }

  public void CheckAWShowHint()
  {
    this.bShowAWHint = false;
    if (this.AllianceWarData.EventState == EActivityState.EAS_Prepare)
    {
      if (this.AWActivityFlash == (byte) 0)
        this.AWActivityFlash = (byte) 1;
    }
    else if (this.AllianceWarData.EventState == EActivityState.EAS_ReplayRanking && this.AW_OneRoundTime != 0U)
    {
      if (this.AW_State == EAllianceWarState.EAWS_Run)
      {
        if (this.AWActivityFlash < (byte) 3)
          this.AWActivityFlash = (byte) 3;
      }
      else if (this.AW_State == EAllianceWarState.EAWS_Replay && DataManager.Instance.RoleAlliance.Id > 0U && !this.bShowAWHint && this.AllianceWarData.EventState == EActivityState.EAS_ReplayRanking && this.AW_State == EAllianceWarState.EAWS_Replay && this.AW_NowAllianceEnterWar != (byte) 0 && (int) this.AW_SignUpAllianceID == (int) DataManager.Instance.RoleAlliance.Id && this.AW_GetGift == (byte) 0)
        this.bShowAWHint = true;
    }
    if (this.AWActivityFlash == (byte) 1 || this.AWActivityFlash == (byte) 3)
      this.bShowAWHint = true;
    this.CheckActivityShow();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 16);
  }

  private void CheckCountTime(EActivityCircleEventType eType)
  {
    if (eType == EActivityCircleEventType.EACET_MAX)
      return;
    int index = (int) eType;
    switch (this.ActivityData[index].EventState)
    {
      case EActivityState.EAS_None:
        this.ActivityData[index].EventCountTime = 0L;
        break;
      case EActivityState.EAS_Run:
        this.ActivityData[index].EventCountTime = this.ActivityData[index].EventBeginTime + (long) this.ActivityData[index].EventReqiureTIme - DataManager.Instance.ServerTime;
        break;
      case EActivityState.EAS_Prepare:
        this.ActivityData[index].EventCountTime = this.ActivityData[index].EventBeginTime - DataManager.Instance.ServerTime;
        break;
    }
    if (this.ActivityData[index].EventCountTime >= 0L)
      return;
    this.ActivityData[index].EventCountTime = 0L;
  }

  private void CheckKVKCountTime(EKVKActivityType eType)
  {
    if (eType == EKVKActivityType.EKAT_MAX)
      return;
    int index = (int) eType;
    switch (this.KvKActivityData[index].EventState)
    {
      case EActivityState.EAS_None:
      case EActivityState.EAS_ReplayRanking:
        this.KvKActivityData[index].EventCountTime = 0L;
        break;
      case EActivityState.EAS_Run:
      case EActivityState.EAS_HomeStart:
      case EActivityState.EAS_HomeEnd:
      case EActivityState.EAS_StartRanking:
        this.KvKActivityData[index].EventCountTime = this.KvKActivityData[index].EventBeginTime + (long) this.KvKActivityData[index].EventReqiureTIme - DataManager.Instance.ServerTime;
        break;
      case EActivityState.EAS_Prepare:
        this.KvKActivityData[index].EventCountTime = this.KvKActivityData[index].EventBeginTime - DataManager.Instance.ServerTime;
        break;
    }
    if (this.KvKActivityData[index].EventCountTime >= 0L)
      return;
    this.KvKActivityData[index].EventCountTime = 0L;
  }

  private void CheckAMCountTime()
  {
    switch (this.AllyMobilizationData.EventState)
    {
      case EActivityState.EAS_None:
        this.AllyMobilizationData.EventCountTime = 0L;
        break;
      case EActivityState.EAS_Run:
      case EActivityState.EAS_HomeStart:
      case EActivityState.EAS_HomeEnd:
      case EActivityState.EAS_StartRanking:
      case EActivityState.EAS_ReplayRanking:
        this.AllyMobilizationData.EventCountTime = this.AllyMobilizationData.EventBeginTime + (long) this.AllyMobilizationData.EventReqiureTIme - DataManager.Instance.ServerTime;
        break;
      case EActivityState.EAS_Prepare:
        this.AllyMobilizationData.EventCountTime = this.AllyMobilizationData.EventBeginTime - DataManager.Instance.ServerTime;
        break;
    }
    if (this.AllyMobilizationData.EventCountTime >= 0L)
      return;
    this.AllyMobilizationData.EventCountTime = 0L;
  }

  private void CheckKOWCountTime()
  {
    switch (this.KOWData.EventState)
    {
      case EActivityState.EAS_None:
        this.KOWData.EventCountTime = 0L;
        break;
      case EActivityState.EAS_Run:
      case EActivityState.EAS_HomeStart:
      case EActivityState.EAS_HomeEnd:
      case EActivityState.EAS_StartRanking:
      case EActivityState.EAS_ReplayRanking:
        this.KOWData.EventCountTime = this.KOWData.EventBeginTime + (long) this.KOWData.EventReqiureTIme - DataManager.Instance.ServerTime;
        break;
      case EActivityState.EAS_Prepare:
        this.KOWData.EventCountTime = this.KOWData.EventBeginTime - DataManager.Instance.ServerTime;
        break;
    }
    if (this.KOWData.EventCountTime >= 0L)
      return;
    this.KOWData.EventCountTime = 0L;
  }

  private void CheckASCountTime()
  {
    switch (this.AllianceSummonData.EventState)
    {
      case EActivityState.EAS_None:
        this.AllianceSummonData.EventCountTime = 0L;
        break;
      case EActivityState.EAS_Run:
      case EActivityState.EAS_HomeStart:
      case EActivityState.EAS_HomeEnd:
      case EActivityState.EAS_StartRanking:
      case EActivityState.EAS_ReplayRanking:
        this.AllianceSummonData.EventCountTime = this.AllianceSummonData.EventBeginTime + (long) this.AllianceSummonData.EventReqiureTIme - DataManager.Instance.ServerTime;
        break;
      case EActivityState.EAS_Prepare:
        this.AllianceSummonData.EventCountTime = this.AllianceSummonData.EventBeginTime - DataManager.Instance.ServerTime;
        break;
    }
    if (this.AllianceSummonData.EventCountTime >= 0L)
      return;
    this.AllianceSummonData.EventCountTime = 0L;
  }

  private void CheckNWCountTime()
  {
    switch (this.NobilityActivityData.EventState)
    {
      case EActivityState.EAS_None:
        this.NobilityActivityData.EventCountTime = 0L;
        break;
      case EActivityState.EAS_Run:
      case EActivityState.EAS_HomeStart:
      case EActivityState.EAS_HomeEnd:
      case EActivityState.EAS_StartRanking:
      case EActivityState.EAS_ReplayRanking:
        this.NobilityActivityData.EventCountTime = this.NobilityActivityData.EventBeginTime + (long) this.NobilityActivityData.EventReqiureTIme - DataManager.Instance.ServerTime;
        break;
      case EActivityState.EAS_Prepare:
        this.NobilityActivityData.EventCountTime = this.NobilityActivityData.EventBeginTime - DataManager.Instance.ServerTime;
        break;
    }
    if (this.NobilityActivityData.EventCountTime >= 0L)
      return;
    this.NobilityActivityData.EventCountTime = 0L;
  }

  private void CheckAWCountTime(bool bLogin = false)
  {
    switch (this.AllianceWarData.EventState)
    {
      case EActivityState.EAS_None:
        this.AllianceWarData.EventCountTime = 0L;
        break;
      case EActivityState.EAS_Run:
      case EActivityState.EAS_HomeStart:
      case EActivityState.EAS_HomeEnd:
      case EActivityState.EAS_StartRanking:
      case EActivityState.EAS_ReplayRanking:
        this.AllianceWarData.EventCountTime = this.AllianceWarData.EventBeginTime + (long) this.AllianceWarData.EventReqiureTIme - this.ServerEventTime;
        break;
      case EActivityState.EAS_Prepare:
        this.AllianceWarData.EventCountTime = this.AllianceWarData.EventBeginTime - this.ServerEventTime;
        break;
    }
    if (this.AllianceWarData.EventCountTime < 0L)
      this.AllianceWarData.EventCountTime = 0L;
    if (bLogin || this.AllianceWarData.EventState != EActivityState.EAS_ReplayRanking)
      return;
    this.SetNowState();
  }

  private void CheckNPCCityCountTime()
  {
    if (this.NPCCityEndTime == 0L)
    {
      this.NPCCityCountTime = 0L;
    }
    else
    {
      this.NPCCityCountTime = this.NPCCityEndTime - DataManager.Instance.ServerTime;
      if (this.NPCCityCountTime >= 0L)
        return;
      this.NPCCityCountTime = 0L;
    }
  }

  private void SetActivityBtn()
  {
    if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
      return;
    this.TimeStr.Length = 0;
    ((Behaviour) this.door.m_FlashKVKImg).enabled = false;
    if (this.m_ActivityKind == (byte) 0)
    {
      this.door.m_ActivityBackSA.SetSpriteIndex(5);
      this.TimeStr.Append(DataManager.Instance.mStringTable.GetStringByID(8168U));
    }
    else if (this.m_ActivityKind == (byte) 1)
    {
      this.door.m_ActivityBackSA.SetSpriteIndex(this.m_ActivityIndex);
      this.TimeStr.Append(this.GetActivityName(this.ActivityData[this.m_ActivityIndex].ActiveType, true));
      this.TimeStr.Append(" ");
      GameConstants.GetTimeString(this.TimeStr, (uint) this.ActivityData[this.m_ActivityIndex].EventCountTime, hideTimeIfDays: true, showZeroHour: false);
    }
    else if (this.m_ActivityKind != (byte) 2 && this.m_ActivityKind == (byte) 4)
    {
      this.door.m_ActivityBackSA.SetSpriteIndex(6);
      if (this.IsMatchKvk())
        this.TimeStr.Append(DataManager.Instance.mStringTable.GetStringByID(12004U));
      else
        this.TimeStr.Append(DataManager.Instance.mStringTable.GetStringByID(9853U));
      ((Behaviour) this.door.m_FlashKVKImg).enabled = true;
    }
    this.door.m_ActivityBtnImg.SetNativeSize();
    this.door.m_ActivityTitleText.text = this.TimeStr.ToString();
    this.door.m_ActivityTitleText.SetAllDirty();
    this.door.m_ActivityTitleText.cachedTextGenerator.Invalidate();
  }

  public void SetActivityBtnToFirst()
  {
    this.m_ActivityKind = (byte) 1;
    this.m_ActivityIndex = 0;
    this.m_ActivityTime = 4.7f;
    this.SetActivityBtn();
    if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
      return;
    this.door.m_ActivityBtnCG.alpha = 1f;
  }

  private void UpDateKVKCountTime()
  {
    ActivityDataType activityDataType = this.KvKActivityData[4];
    if (activityDataType.EventState == EActivityState.EAS_Prepare)
    {
      if (this.bShowRunningP || activityDataType.EventBeginTime == 0L || activityDataType.EventBeginTime - DataManager.Instance.ServerTime != 600L)
        return;
      this.bShowRunningP = true;
      CString str = StringManager.Instance.SpawnString(300);
      str.Append(DataManager.Instance.mStringTable.GetStringByID(9375U));
      GUIManager.Instance.WonderCountStr.Add(str);
      GUIManager.Instance.SetRunningText(str);
    }
    else
    {
      if (activityDataType.EventState != EActivityState.EAS_Run || this.bShowRunningE || activityDataType.EventBeginTime == 0L || activityDataType.EventBeginTime + (long) activityDataType.EventReqiureTIme - DataManager.Instance.ServerTime != 600L)
        return;
      this.bShowRunningE = true;
      CString str = StringManager.Instance.SpawnString(300);
      str.Append(DataManager.Instance.mStringTable.GetStringByID(9377U));
      GUIManager.Instance.WonderCountStr.Add(str);
      GUIManager.Instance.SetRunningText(str);
    }
  }

  public void Update()
  {
    if (this.bAskFirstData)
    {
      this.UpDateKVKCountTime();
      if (DataManager.Instance.ServerTime != this.m_LastServerTime)
      {
        this.m_LastServerTime = DataManager.Instance.ServerTime;
        this.CheckRunningText();
        int num1 = 2;
        for (int eType = 0; eType < num1; ++eType)
        {
          if (this.ActivityData[eType] != null)
            this.CheckCountTime((EActivityCircleEventType) eType);
        }
        int num2 = 5;
        for (int eType = 0; eType < num2; ++eType)
        {
          if (this.KvKActivityData[eType] != null)
            this.CheckKVKCountTime((EKVKActivityType) eType);
        }
        this.CheckAMCountTime();
        this.CheckKOWCountTime();
        this.CheckNPCCityCountTime();
        this.CheckASCountTime();
        this.CheckNWCountTime();
        this.CheckAWCountTime();
        if (this.m_ActivityKind == (byte) 1)
          this.SetActivityBtn();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 1);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 3);
        if ((UnityEngine.Object) GUIManager.Instance.m_ActivityWindow != (UnityEngine.Object) null)
          GUIManager.Instance.m_ActivityWindow.UpdateTime();
      }
      if ((UnityEngine.Object) this.door != (UnityEngine.Object) null && this.LastTimeIndex == -1)
      {
        byte activityKind = this.m_ActivityKind;
        int activityIndex = this.m_ActivityIndex;
        if (this.IsInKvK((ushort) 0))
        {
          if (this.m_ActivityKind != (byte) 4)
          {
            this.m_ActivityKind = (byte) 4;
            this.SetActivityBtn();
            this.door.m_ActivityBtnCG.alpha = 1f;
          }
        }
        else if (this.m_ActivityKind == (byte) 4)
        {
          this.m_ActivityKind = (byte) 1;
          this.m_ActivityIndex = 0;
          this.SetActivityBtn();
        }
        else
        {
          bool flag = false;
          this.m_ActivityTime -= Time.unscaledDeltaTime;
          if ((double) this.m_ActivityTime <= 0.0 || this.m_ActivityKind == (byte) 1 && this.ActivityData[this.m_ActivityIndex].EventState != EActivityState.EAS_Run)
          {
            if (this.m_ActivityKind == (byte) 1)
              ++this.m_ActivityIndex;
            for (int index = 0; index <= 3; ++index)
            {
              if (this.m_ActivityKind == (byte) 1 && this.m_ActivityIndex >= 2)
              {
                this.m_ActivityKind = (byte) 1;
                this.m_ActivityIndex = 0;
                flag = true;
                break;
              }
              if (this.m_ActivityKind == (byte) 1 && this.ActivityData[this.m_ActivityIndex].EventState == EActivityState.EAS_Run)
              {
                flag = true;
                break;
              }
              ++this.m_ActivityIndex;
            }
            if (!flag || (int) activityKind == (int) this.m_ActivityKind && activityIndex == this.m_ActivityIndex)
            {
              this.m_ActivityIndex = 0;
              this.m_ActivityTime = 4.7f;
            }
            else
              this.m_ActivityTime = 5f;
            this.SetActivityBtn();
          }
          this.door.m_ActivityBtnCG.alpha = (double) this.m_ActivityTime <= 4.6999998092651367 ? 1f : Mathf.Lerp(0.0f, 1f, (float) ((5.0 - (double) this.m_ActivityTime) / 0.30000001192092896));
        }
      }
    }
    if (this.bNeedSendUpData)
      return;
    this.NeedSendUpDataTime -= Time.unscaledDeltaTime;
    if ((double) this.NeedSendUpDataTime > 0.0)
      return;
    this.bNeedSendUpData = true;
    this.NeedSendUpDataTime = 180f;
  }

  public string GetActivityName(EActivityType type, bool bShort = false)
  {
    switch (type)
    {
      case EActivityType.EAT_SoloEvent:
        return DataManager.Instance.mStringTable.GetStringByID(!bShort ? 8101U : 8156U);
      case EActivityType.EAT_InfernalEvent:
        return DataManager.Instance.mStringTable.GetStringByID(!bShort ? 8102U : 8157U);
      case EActivityType.EAT_ComingSoonSpEvent:
        return DataManager.Instance.mStringTable.GetStringByID(!bShort ? 8106U : 8106U);
      case EActivityType.EAT_SpecialEvent:
        return DataManager.Instance.mStringTable.GetStringByID(!bShort ? 8105U : 8105U);
      default:
        return string.Empty;
    }
  }

  public void ChangeStateReOpenMenu(byte index)
  {
    this.bReOpen = true;
    switch (index)
    {
      case 201:
      case 202:
      case 203:
      case 204:
      case 205:
        this.KvKActivityData[(int) index - 201].bAskDetailData = false;
        this.Send_ACTIVITY_KEVENT_LIST_SINGLE(index);
        this.Send_ACTIVITY_KEVENT_DETAIL(index);
        break;
      case 207:
        if (this.KOWData.EventState == EActivityState.EAS_ReplayRanking && !this.KOWData.bAskDetailData)
        {
          this.Send_KINGOFTHEWORLD_KINGINFO();
          break;
        }
        this.bReOpen = false;
        if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity2))
          this.door.CloseMenu();
        this.door.OpenMenu(EGUIWindow.UI_Activity2, 207, bCameraMode: true);
        break;
      case 208:
        this.Send_ACTIVITY_EVENT_LIST_SINGLE((byte) 11);
        break;
      case 209:
        this.NobilityActivityData.bAskDetailData = false;
        this.Send_FEDERAL_ORDERLIST();
        break;
      default:
        if ((int) index >= this.ActivityData.Length)
          break;
        this.ActivityData[(int) index].bAskDetailData = false;
        this.Send_ACTIVITY_EVENT_LIST_SINGLE(index);
        this.Send_ACTIVITY_EVENT_DETAIL(index);
        break;
    }
  }

  public void ChangeStateReOpenPrize(byte index)
  {
    this.bReOpenPrize = true;
    switch (index)
    {
      case 201:
      case 202:
      case 203:
      case 204:
      case 205:
        this.KvKActivityData[(int) index - 201].bAskDetailData = false;
        this.Send_ACTIVITY_KEVENT_LIST_SINGLE(index);
        this.Send_ACTIVITY_KEVENT_DETAIL(index);
        this.Send_ACTIVITY_KEVENT_RANKING_PRIZE(index);
        break;
      case 206:
        this.Send_ACTIVITY_AM_RANKING_PRIZE();
        break;
      case 210:
        this.Send_REQUEST_ALLIANCEWAR_RANKPRIZE();
        break;
      default:
        if ((int) index >= this.ActivityData.Length)
          break;
        this.ActivityData[(int) index].bAskDetailData = false;
        this.Send_ACTIVITY_EVENT_LIST_SINGLE(index);
        this.Send_ACTIVITY_EVENT_DETAIL(index);
        this.Send_ACTIVITY_RANKING_PRIZE(index);
        break;
    }
  }

  public void CheckCastleLevel()
  {
    bool bCastleLevel = this.bCastleLevel;
    if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 5)
      this.bCastleLevel = true;
    if ((UnityEngine.Object) this.door != (UnityEngine.Object) null && !bCastleLevel && this.bCastleLevel)
    {
      this.door.CheckSetShowActivityBtn();
      this.SetActivityBtn();
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Chat, 13);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_MessageBoard, 5);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 20);
  }

  public void SetbOpenCSActivity(byte Index, bool value)
  {
    this.bOpenCSActivity[(int) Index] = value;
    if (value)
      return;
    this.Act1Pos = Vector2.zero;
  }

  public void SetbOpenSPActivity(byte Index, bool value)
  {
    this.bOpenSPActivity[(int) Index] = value;
    if (value)
      return;
    this.Act1Pos = Vector2.zero;
  }

  public void SetbOpenKvKActivity(bool value) => this.bOpenKvKActivity = value;

  public EActivityState GetKvKState() => this.KvKActivityData[4].EventState;

  public bool IsInKvK(ushort KingdomID = 0, bool bExceptRanking = false)
  {
    EActivityState eventState = this.KvKActivityData[4].EventState;
    if (KingdomID == (ushort) 0)
    {
      if (bExceptRanking)
        return eventState == EActivityState.EAS_Run;
      return eventState > EActivityState.EAS_None && eventState < EActivityState.EAS_ReplayRanking && eventState != EActivityState.EAS_Prepare;
    }
    if ((int) KingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID)
      return DataManager.MapDataController.kingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK;
    if ((int) KingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
      return DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK;
    if ((int) KingdomID == (int) DataManager.MapDataController.FocusKingdomID)
      return DataManager.MapDataController.FocusKingdomPeriod == KINGDOM_PERIOD.KP_KVK;
    byte kingdomTableID = 0;
    return DataManager.MapDataController.GetWorldKingdomTableID(KingdomID, out kingdomTableID) && DataManager.MapDataController.WorldKingdomTable[(int) kingdomTableID].kingdomPeriod == KINGDOM_PERIOD.KP_KVK;
  }

  public bool IsMatchKvk()
  {
    return this.KvKActivityData[4].ActiveType == EActivityType.EAT_KingdomMatchEvent;
  }

  public bool CheckIsMatchKingdom(ushort KingdomID)
  {
    for (int index = 0; index < (int) this.MatchKingdomIDCount && index < 6 && this.MatchKingdomID[index] != (ushort) 0; ++index)
    {
      if ((int) this.MatchKingdomID[index] == (int) KingdomID)
        return true;
    }
    return false;
  }

  public bool IsMatchKvk_kingdom(ushort KingdomID)
  {
    return this.IsMatchKvk() && this.CheckIsMatchKingdom(KingdomID);
  }

  public bool IsKOWRunning(bool bIncludeRanking = false)
  {
    if (!bIncludeRanking)
      return this.KOWData.EventState == EActivityState.EAS_Run;
    return this.KOWData.EventState == EActivityState.EAS_Run || this.KOWData.EventState == EActivityState.EAS_ReplayRanking;
  }

  public byte GetHuntBonusRate(byte index, EGetScoreFactor tmpFactor)
  {
    switch (index)
    {
      case 203:
        index = (byte) 0;
        break;
      case 204:
        index = (byte) 1;
        break;
      case 205:
        index = (byte) 2;
        break;
      default:
        return 0;
    }
    for (int index1 = 0; index1 < 6; ++index1)
    {
      if (this.GetHuntFactor[(int) index][index1].Factor == tmpFactor)
        return this.GetHuntFactor[(int) index][index1].BonusRate;
    }
    return 0;
  }

  public void UpDateKvKState(EActivityState OldState)
  {
    EActivityState eventState = this.KvKActivityData[4].EventState;
    switch (eventState)
    {
      case EActivityState.EAS_Run:
      case EActivityState.EAS_HomeStart:
      case EActivityState.EAS_HomeEnd:
      case EActivityState.EAS_StartRanking:
        DataManager.MapDataController.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_KVK;
        if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID)
          DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_KVK;
        if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.FocusKingdomID)
          DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_KVK;
        else if (this.IsMatchKvk())
        {
          for (int index = 0; index < this.MatchKingdomID.Length; ++index)
          {
            if (this.MatchKingdomID[index] != (ushort) 0 && (int) this.MatchKingdomID[index] == (int) DataManager.MapDataController.FocusKingdomID)
            {
              DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_KVK;
              break;
            }
          }
        }
        if (eventState != EActivityState.EAS_Run)
        {
          DataManager.MapDataController.UpdateKingdomPeriod();
          break;
        }
        break;
      default:
        if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
        {
          if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID)
            DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
          if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.FocusKingdomID)
          {
            DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
            break;
          }
          if (this.IsMatchKvk())
          {
            for (int index = 0; index < this.MatchKingdomID.Length; ++index)
            {
              if (this.MatchKingdomID[index] != (ushort) 0 && (int) this.MatchKingdomID[index] == (int) DataManager.MapDataController.FocusKingdomID)
              {
                if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_WORLD_WAR)
                {
                  DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
                  break;
                }
                break;
              }
            }
            break;
          }
          break;
        }
        DataManager.MapDataController.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
        if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID)
          DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
        if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.FocusKingdomID)
        {
          DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
          break;
        }
        if (this.IsMatchKvk())
        {
          for (int index = 0; index < this.MatchKingdomID.Length; ++index)
          {
            if (this.MatchKingdomID[index] != (ushort) 0 && (int) this.MatchKingdomID[index] == (int) DataManager.MapDataController.FocusKingdomID)
            {
              DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
              break;
            }
          }
          break;
        }
        break;
    }
    this.reflashKvKKingdomType();
    if (OldState != eventState)
    {
      switch (eventState)
      {
        case EActivityState.EAS_Run:
          DataManager.MapDataController.UpdateKingdomPeriod();
          GUIManager.Instance.UpdateUI(EGUIWindow.Door, 25);
          DataManager.msgBuffer[0] = (byte) 53;
          DataManager.msgBuffer[1] = (byte) 1;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          break;
        case EActivityState.EAS_ReplayRanking:
          DataManager.MapDataController.UpdateKingdomPeriod(KINGDOM_PERIOD.KP_INFIGHTING);
          GUIManager.Instance.UpdateUI(EGUIWindow.Door, 25);
          DataManager.msgBuffer[0] = (byte) 53;
          DataManager.msgBuffer[1] = (byte) 1;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          break;
      }
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Info, 6);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 6);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena_Info, 2);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderLand, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 25);
  }

  private void SettmpKvKTypeByIndex(byte index)
  {
    if (index < (byte) 201 || index > (byte) 205)
    {
      this.tmpActivityType = EActivityType.EAT_MAX;
      this.tmpActivityKingdomEventType = EActivityKingdomEventType.EAKET_MAX;
    }
    else
    {
      this.tmpActivityType = index >= (byte) 203 ? this.KvKActivityData[4].ActiveType : EActivityType.EAT_KingdomNormalEvent;
      switch (index)
      {
        case 201:
        case 203:
          this.tmpActivityKingdomEventType = EActivityKingdomEventType.EAKET_SoloEvent;
          break;
        case 202:
        case 204:
          this.tmpActivityKingdomEventType = EActivityKingdomEventType.EAKET_AllianceEvent;
          break;
        default:
          this.tmpActivityKingdomEventType = EActivityKingdomEventType.EAKET_KingdomEvent;
          break;
      }
    }
  }

  public int GetKvkDataIndexByType(EActivityType InType, EActivityKingdomEventType InKvKType)
  {
    switch (InType)
    {
      case EActivityType.EAT_KingdomKillEvent:
        switch (InKvKType)
        {
          case EActivityKingdomEventType.EAKET_SoloEvent:
            return 203;
          case EActivityKingdomEventType.EAKET_AllianceEvent:
            return 204;
          case EActivityKingdomEventType.EAKET_KingdomEvent:
            return 205;
        }
        break;
      case EActivityType.EAT_KingdomNormalEvent:
        switch (InKvKType)
        {
          case EActivityKingdomEventType.EAKET_SoloEvent:
            return 201;
          case EActivityKingdomEventType.EAKET_AllianceEvent:
            return 202;
        }
        break;
      case EActivityType.EAT_KingdomMatchEvent:
        switch (InKvKType)
        {
          case EActivityKingdomEventType.EAKET_SoloEvent:
            return 203;
          case EActivityKingdomEventType.EAKET_AllianceEvent:
            return 204;
          case EActivityKingdomEventType.EAKET_KingdomEvent:
            return 205;
        }
        break;
    }
    return -1;
  }

  public bool IsNobilityWarRunning(bool bCheckMyGroup = false)
  {
    if (!bCheckMyGroup)
      return this.NobilityActivityData.EventState == EActivityState.EAS_Run;
    return this.NobilityActivityData.EventState == EActivityState.EAS_Run && this.FederalActKingdomWonderID != (byte) 0 && (int) this.FederalActKingdomWonderID == (int) this.FederalFullEventTimeWonderID;
  }

  public EKvKKingdomType getKvKKingdomType(ushort checkKingdomID)
  {
    if (this.KVKHuntOrder > (byte) 0 && this.KvKActivityData[4].EventState == EActivityState.EAS_Run)
    {
      for (int index1 = 0; index1 < (int) this.MatchKingdomIDCount; ++index1)
      {
        if ((int) this.MatchKingdomID[index1] == (int) DataManager.MapDataController.kingdomData.kingdomID)
        {
          for (int index2 = 0; index2 < (int) this.MatchKingdomIDCount; ++index2)
          {
            if ((int) this.MatchKingdomID[index2] == (int) checkKingdomID)
            {
              if (index2 == (int) this.MatchKingdomIDCount - 1 && index1 == 0 || index2 == index1 - 1)
                return this.KVKHuntOrder == (byte) 1 ? EKvKKingdomType.EKKT_Hunter : EKvKKingdomType.EKKT_Target;
              if ((index1 != (int) this.MatchKingdomIDCount - 1 || index2 != 0) && index2 != index1 + 1)
                return EKvKKingdomType.EKKT_Normal;
              return this.KVKHuntOrder == (byte) 1 ? EKvKKingdomType.EKKT_Target : EKvKKingdomType.EKKT_Hunter;
            }
          }
          break;
        }
      }
    }
    return EKvKKingdomType.EKKT_None;
  }

  public void reflashKvKKingdomType()
  {
    if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
      this.door.ShowKVKTime();
    DataManager.msgBuffer[0] = (byte) 53;
    DataManager.msgBuffer[1] = (byte) 2;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    DataManager.msgBuffer[0] = (byte) 122;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public Sprite LoadActivityListSprite(ushort IconID)
  {
    if (this.m_ActivityListAsset.m_AssetBundleKey == 0)
      return (Sprite) null;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.IntToFormat((long) IconID, 3);
    cstring.AppendFormat("A{0:000}");
    Sprite sprite;
    this.m_ActivityListAsset.m_Dict.TryGetValue(cstring.GetHashCode(false), out sprite);
    return sprite;
  }

  public Sprite LoadActivitySprite(ushort IconID)
  {
    if (this.m_ActivityAsset.m_AssetBundleKey == 0)
      return (Sprite) null;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.IntToFormat((long) IconID, 3);
    cstring.AppendFormat("A{0:000}_b");
    Sprite sprite;
    this.m_ActivityAsset.m_Dict.TryGetValue(cstring.GetHashCode(false), out sprite);
    return sprite;
  }

  public Sprite LoadDoorBoxSprite(ushort IconID, bool bDark = false)
  {
    if ((UnityEngine.Object) this.m_DoorBoxAsset.m_AssetBundle == (UnityEngine.Object) null)
      return (Sprite) null;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.IntToFormat((long) IconID);
    if (bDark)
      cstring.AppendFormat("UI_chest_{0}a");
    else
      cstring.AppendFormat("UI_chest_{0}b");
    Sprite sprite;
    this.m_DoorBoxAsset.m_Dict.TryGetValue(cstring.GetHashCode(false), out sprite);
    return sprite;
  }

  public Material GetActivityListMaterial()
  {
    return this.m_ActivityListAsset.m_AssetBundleKey == 0 ? (Material) null : this.m_ActivityListAsset.m_Material;
  }

  public Material GetActivityMaterial()
  {
    return this.m_ActivityAsset.m_AssetBundleKey == 0 ? (Material) null : this.m_ActivityAsset.m_Material;
  }

  public Material GetDoorBoxMaterial()
  {
    return this.m_DoorBoxAsset.m_AssetBundleKey == 0 ? (Material) null : this.m_DoorBoxAsset.m_Material;
  }

  private ushort ActivityFactorIDToSN(byte Factor, byte Level)
  {
    return (ushort) ((uint) Factor << 8 | (uint) Level);
  }

  public void InitKVKActivityScoreTable()
  {
    this.m_ActivityFactorIDMap_KVK.Clear();
    int tableCount = this.KVKScoreData.TableCount;
    for (int Index = 0; Index < tableCount; ++Index)
    {
      KVKActivityScoreData recordByIndex = this.KVKScoreData.GetRecordByIndex(Index);
      ushort sn = this.ActivityFactorIDToSN(recordByIndex.ScoreFactor, recordByIndex.Level);
      if (this.m_ActivityFactorIDMap_KVK.ContainsKey(sn))
        break;
      this.m_ActivityFactorIDMap_KVK.Add(sn, Index);
    }
  }

  public KVKActivityScoreData GetKVKActivityScore_SDataByFactor(byte facotr, byte level)
  {
    if (this.KVKScoreData == null)
    {
      this.KVKScoreData = new CExternalTableWithWordKey<KVKActivityScoreData>();
      this.KVKScoreData.LoadTable("KingdomEventFactorScore");
      this.InitKVKActivityScoreTable();
    }
    ushort sn = this.ActivityFactorIDToSN(facotr, level);
    return this.m_ActivityFactorIDMap_KVK.Count <= 0 || !this.m_ActivityFactorIDMap_KVK.ContainsKey(sn) ? this.KVKScoreData.GetRecordByIndex(0) : this.KVKScoreData.GetRecordByIndex(this.m_ActivityFactorIDMap_KVK[sn]);
  }

  public void InitAllianceSummonScoreTable()
  {
    this.m_ActivityFactorIDMap_AllianceSummon.Clear();
    int tableCount = this.AllianceSummonScoreData.TableCount;
    for (int Index = 0; Index < tableCount; ++Index)
    {
      SummonScoreData recordByIndex = this.AllianceSummonScoreData.GetRecordByIndex(Index);
      ushort sn = this.ActivityFactorIDToSN(recordByIndex.ScoreFactor, recordByIndex.Level);
      if (this.m_ActivityFactorIDMap_AllianceSummon.ContainsKey(sn))
        break;
      this.m_ActivityFactorIDMap_AllianceSummon.Add(sn, Index);
    }
  }

  public SummonScoreData GetAllianceSummonScore_SDataByFactor(byte facotr, byte level)
  {
    if (this.AllianceSummonScoreData == null)
    {
      this.AllianceSummonScoreData = new CExternalTableWithWordKey<SummonScoreData>();
      this.AllianceSummonScoreData.LoadTable("AllianceSummonFactorScore");
      this.InitAllianceSummonScoreTable();
    }
    ushort sn = this.ActivityFactorIDToSN(facotr, level);
    return this.m_ActivityFactorIDMap_AllianceSummon.Count <= 0 || !this.m_ActivityFactorIDMap_AllianceSummon.ContainsKey(sn) ? this.AllianceSummonScoreData.GetRecordByIndex(0) : this.AllianceSummonScoreData.GetRecordByIndex(this.m_ActivityFactorIDMap_AllianceSummon[sn]);
  }

  public void Send_ACTIVITY_EVENT_LIST()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_EVENT_LIST;
    messagePacket.AddSeqId();
    for (int index = 0; index < 2; ++index)
      messagePacket.Add(this.ActivityData[index].EventRank);
    messagePacket.Add(this.KvKActivityData[0].EventRank);
    messagePacket.Add(this.KvKActivityData[2].EventRank);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Activity);
  }

  public void Send_ACTIVITY_EVENT_LIST_SINGLE(byte index)
  {
    if (index >= (byte) 14)
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_EVENT_LIST_SINGLE;
    messagePacket.AddSeqId();
    messagePacket.Add((byte) ((uint) index + 1U));
    if (index <= (byte) 1)
      messagePacket.Add(this.ActivityData[(int) index].EventRank);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Activity);
  }

  public void Send_ACTIVITY_EVENT_DETAIL(byte index)
  {
    if ((int) index >= this.ActivityData.Length)
      return;
    if (this.ActivityData[(int) index].bAskDetailData)
    {
      if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
        return;
      this.door.OpenMenu(EGUIWindow.UI_Activity2, (int) index);
    }
    else if (this.ActivityData[(int) index].EventState == EActivityState.EAS_None)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107U), (ushort) byte.MaxValue);
    }
    else
    {
      this.bAskDetailData = true;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_EVENT_DETAIL;
      messagePacket.AddSeqId();
      messagePacket.Add(index);
      if (index < (byte) 2)
        messagePacket.Add(this.ActivityData[(int) index].EventRank);
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Activity);
    }
  }

  public void Send_ACTIVITY_RANKING_PRIZE(byte index)
  {
    if ((int) index >= this.ActivityData.Length)
      return;
    if (this.ActivityData[(int) index].bAskRankPrize)
    {
      if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
        return;
      this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, (int) index);
    }
    else
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_RANKING_PRIZE;
      messagePacket.AddSeqId();
      messagePacket.Add(index);
      if (index < (byte) 2)
        messagePacket.Add(this.ActivityData[(int) index].EventRank);
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Activity);
    }
  }

  public void Send_ACTIVITY_KEVENT_DETAIL(byte index)
  {
    if (index < (byte) 201 || index > (byte) 205)
      return;
    this.SettmpKvKTypeByIndex(index);
    if (this.tmpActivityType == EActivityType.EAT_MAX || this.tmpActivityKingdomEventType == EActivityKingdomEventType.EAKET_MAX)
      return;
    int index1 = (int) index - 201;
    if (this.KvKActivityData[index1].bAskDetailData)
    {
      if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
        return;
      this.door.OpenMenu(EGUIWindow.UI_Activity2, (int) index);
    }
    else if (this.KvKActivityData[index1].EventState == EActivityState.EAS_None)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107U), (ushort) byte.MaxValue);
    }
    else
    {
      this.bAskDetailData = true;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_KEVENT_DETAIL;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) (this.tmpActivityType + 1));
      messagePacket.Add((byte) this.tmpActivityKingdomEventType);
      messagePacket.Add(this.KvKActivityData[index1].EventRank);
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Activity);
    }
  }

  public void Send_ACTIVITY_KEVENT_LIST_SINGLE(byte index)
  {
    if (index < (byte) 201 || index > (byte) 205)
      return;
    this.SettmpKvKTypeByIndex(index);
    if (this.tmpActivityType == EActivityType.EAT_MAX || this.tmpActivityKingdomEventType == EActivityKingdomEventType.EAKET_MAX)
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_KEVENT_LIST_SINGLE;
    messagePacket.AddSeqId();
    messagePacket.Add((byte) (this.tmpActivityType + 1));
    messagePacket.Add((byte) this.tmpActivityKingdomEventType);
    messagePacket.Add(this.KvKActivityData[(int) index - 201].EventRank);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Activity);
  }

  public void Send_ACTIVITY_KEVENT_RANKING_PRIZE(byte index)
  {
    if (index < (byte) 201 || index > (byte) 205)
      return;
    int index1 = (int) index - 201;
    if (this.KvKActivityData[index1].bAskRankPrize)
    {
      if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
        return;
      this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, (int) index);
    }
    else
    {
      this.SettmpKvKTypeByIndex(index);
      if (this.tmpActivityType == EActivityType.EAT_MAX || this.tmpActivityKingdomEventType == EActivityKingdomEventType.EAKET_MAX)
        return;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_KEVENT_RANKING_PRIZE;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) (this.tmpActivityType + 1));
      messagePacket.Add((byte) this.tmpActivityKingdomEventType);
      messagePacket.Add(this.KvKActivityData[index1].EventRank);
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Activity);
    }
  }

  public void Send_ACTIVITY_SPEVENT_LIST_SINGLE(EActivityType Type, byte index)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_EVENT_LIST_SINGLE;
    messagePacket.AddSeqId();
    messagePacket.Add((byte) ((uint) (byte) Type + 1U));
    messagePacket.Add(index);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Activity);
  }

  public void Send_ACTIVITY_AM_RANKING_PRIZE()
  {
    if (this.AllyMobilizationData.bAskRankPrize)
    {
      if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
        return;
      this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, 206);
    }
    else
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AM_RANKING_PRIZE;
      messagePacket.AddSeqId();
      messagePacket.Add(DataManager.Instance.RoleAlliance.AMRank);
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Activity);
    }
  }

  public void Send_KINGOFTHEWORLD_KINGINFO()
  {
    this.bAskDetailData = true;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_KINGOFTHEWORLD_KINGINFO;
    messagePacket.AddSeqId();
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Activity);
  }

  public void RecvEventPoint(byte DataTypeIndex, MessagePacket MP)
  {
    if ((int) DataTypeIndex < this.ActivityData.Length)
      this.ActivityData[(int) DataTypeIndex].EventScore = MP.ReadULong();
    DataManager.MissionDataManager.CheckChanged(eMissionKind.Mark, (ushort) 103, (ushort) DataTypeIndex);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 2, (int) DataTypeIndex);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 1);
  }

  public void RecvKVKEventPoint(byte DataTypeIndex, MessagePacket MP)
  {
    this.SetKVKEventPoint(DataTypeIndex, MP.ReadULong());
  }

  public void SetKVKEventPoint(byte DataTypeIndex, ulong Score)
  {
    if ((int) DataTypeIndex < this.KvKActivityData.Length)
      this.KvKActivityData[(int) DataTypeIndex].EventScore = Score;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 2, (int) DataTypeIndex + 201);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 1);
    DataManager.MissionDataManager.CheckChanged(eMissionKind.Mark, (ushort) 136, (ushort) DataTypeIndex);
    if (Score == 0UL || DataTypeIndex != (byte) 2 || this.KvKActivityData[4].EventState != EActivityState.EAS_Run)
      return;
    FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.CREDITS_FOR_KVK, this.KvKActivityData[4].EventBeginTime, this.KvKActivityData[(int) DataTypeIndex].EventScore);
  }

  public void RecvActivity_Info(MessagePacket MP)
  {
    EActivityState eventState = this.KvKActivityData[4].EventState;
    int num1 = 2;
    for (int index = 0; index < num1; ++index)
    {
      this.ActivityData[index].Initial();
      this.ActivityData[index].ActiveType = (EActivityType) index;
      this.ActivityData[index].EventState = (EActivityState) MP.ReadByte();
      this.ActivityData[index].EventBeginTime = MP.ReadLong();
      this.ActivityData[index].EventReqiureTIme = MP.ReadUInt();
      this.ActivityData[index].EventScore = MP.ReadULong();
      if (this.ActivityData[index].EventState == EActivityState.EAS_Prepare)
        this.ActivityData[index].EventScore = 0UL;
      this.ActivityData[index].EventRank = MP.ReadByte();
      this.CheckCountTime((EActivityCircleEventType) index);
      DataManager.MissionDataManager.CheckChanged(eMissionKind.Mark, (ushort) 103, (ushort) index);
    }
    this.SetActivityBtnToFirst();
    this.bAskFirstData = true;
    this.bAskSecondData = false;
    this.CheckMonster(MP);
    this.CheckMonsterType(MP);
    this.CheckShowNpcMessage();
    this.SetCSData(MP);
    this.SetSPData(MP);
    this.SetTreasureBoxID(MP.ReadUShort());
    for (byte Index = 0; Index < (byte) 5; ++Index)
    {
      if (this.SPActivityData[(int) Index].EventBeginTime != this.SPActivityTime[(int) Index])
      {
        this.SPActivityTime[(int) Index] = this.SPActivityData[(int) Index].EventBeginTime;
        this.SetbOpenSPActivity(Index, false);
      }
    }
    for (byte Index = 0; Index < (byte) 5; ++Index)
    {
      if (this.CSActivityData[(int) Index].EventBeginTime != this.CSActivityTime[(int) Index])
      {
        this.CSActivityTime[(int) Index] = this.CSActivityData[(int) Index].EventBeginTime;
        this.SetbOpenCSActivity(Index, false);
      }
    }
    this.SendAskDownLoad();
    this.KvKActivityData[0].Initial();
    this.KvKActivityData[0].ActiveType = EActivityType.EAT_KingdomNormalEvent;
    this.KvKActivityData[0].KVKActiveType = EKVKActivityType.EKAT_KNormalSoloEvent;
    this.KvKActivityData[0].EventState = (EActivityState) MP.ReadByte();
    this.KvKActivityData[0].EventBeginTime = MP.ReadLong();
    this.KvKActivityData[0].EventReqiureTIme = MP.ReadUInt();
    this.KvKActivityData[0].EventScore = MP.ReadULong();
    if (this.KvKActivityData[0].EventState == EActivityState.EAS_Prepare)
      this.KvKActivityData[0].EventScore = 0UL;
    this.KvKActivityData[0].EventRank = MP.ReadByte();
    this.CheckKVKCountTime(EKVKActivityType.EKAT_KNormalSoloEvent);
    this.KvKActivityData[1].Initial();
    this.KvKActivityData[1].ActiveType = EActivityType.EAT_KingdomNormalEvent;
    this.KvKActivityData[1].KVKActiveType = EKVKActivityType.EKAT_KNormalAllianceEvent;
    this.AllyMobilizationData.Initial();
    this.AllyMobilizationData.ActiveType = EActivityType.EAT_AllianceMobilization;
    this.AllyMobilizationData.EventState = (EActivityState) MP.ReadByte();
    this.AllyMobilizationData.EventBeginTime = MP.ReadLong();
    this.AllyMobilizationData.EventReqiureTIme = MP.ReadUInt();
    this.AllyMobilizationData.EventScore = MP.ReadULong();
    if (this.AllyMobilizationData.EventState == EActivityState.EAS_Prepare)
      this.AllyMobilizationData.EventScore = 0UL;
    this.AllyMobilizationData.EventRank = MP.ReadByte();
    MobilizationManager.Instance.SetAllyMobilizationBeginTime(this.AllyMobilizationData.EventBeginTime);
    this.CheckAMCountTime();
    this.CheckAMActivityTime();
    EActivityState eactivityState1 = (EActivityState) MP.ReadByte();
    long num2 = MP.ReadLong();
    uint num3 = MP.ReadUInt();
    ulong num4 = MP.ReadULong();
    byte num5 = MP.ReadByte();
    for (int eType = 2; eType < 5; ++eType)
    {
      this.KvKActivityData[eType].Initial();
      this.KvKActivityData[eType].ActiveType = EActivityType.EAT_KingdomKillEvent;
      this.KvKActivityData[eType].KVKActiveType = (EKVKActivityType) eType;
      this.KvKActivityData[eType].EventState = eactivityState1;
      this.KvKActivityData[eType].EventBeginTime = num2;
      this.KvKActivityData[eType].EventReqiureTIme = num3;
      this.KvKActivityData[eType].EventScore = num4;
      if (this.KvKActivityData[eType].EventState == EActivityState.EAS_Prepare)
        this.KvKActivityData[eType].EventScore = 0UL;
      this.KvKActivityData[eType].EventRank = num5;
      this.CheckKVKCountTime((EKVKActivityType) eType);
    }
    this.KOWData.ActiveType = EActivityType.EAT_KingOfTheWorld;
    this.KOWData.EventState = (EActivityState) MP.ReadByte();
    this.KOWData.EventBeginTime = MP.ReadLong();
    this.KOWData.EventReqiureTIme = MP.ReadUInt();
    this.KOWData.EventPrizeID = MP.ReadUShort();
    this.KOWData.bAskDetailData = this.KOWData.EventState != EActivityState.EAS_ReplayRanking;
    this.CheckKOWCountTime();
    this.SetLastGetDailyGiftTime(MP.ReadLong());
    this.KOWKingdomID = MP.ReadUShort();
    if ((int) DataManager.MapDataController.FocusKingdomID == (int) this.KOWKingdomID)
      DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
    if ((int) DataManager.MapDataController.kingdomData.kingdomID == (int) this.KOWKingdomID)
      DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
    if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) this.KOWKingdomID)
      DataManager.MapDataController.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
    this.AMAllianceID = MP.ReadUInt();
    this.CheckAMShowHint();
    EActivityState eactivityState2 = (EActivityState) MP.ReadByte();
    long num6 = MP.ReadLong();
    uint num7 = MP.ReadUInt();
    ulong num8 = MP.ReadULong();
    byte num9 = MP.ReadByte();
    if (this.KvKActivityData[2].EventBeginTime == 0L && num6 > 0L)
    {
      for (int eType = 2; eType < 5; ++eType)
      {
        this.KvKActivityData[eType].Initial();
        this.KvKActivityData[eType].ActiveType = EActivityType.EAT_KingdomMatchEvent;
        this.KvKActivityData[eType].KVKActiveType = (EKVKActivityType) eType;
        this.KvKActivityData[eType].EventState = eactivityState2;
        this.KvKActivityData[eType].EventBeginTime = num6;
        this.KvKActivityData[eType].EventReqiureTIme = num7;
        this.KvKActivityData[eType].EventScore = num8;
        if (this.KvKActivityData[eType].EventState == EActivityState.EAS_Prepare)
          this.KvKActivityData[eType].EventScore = 0UL;
        this.KvKActivityData[eType].EventRank = num9;
        this.CheckKVKCountTime((EKVKActivityType) eType);
      }
    }
    if (this.KvKActivityData[4].EventState != EActivityState.EAS_Run)
    {
      this.KVKHuntOrder = (byte) 0;
      this.KVKReTime = 0L;
    }
    this.KOWData.EventPrizeID2 = MP.ReadUShort();
    this.KOWData.EventPrizeID3 = MP.ReadUShort();
    this.AllianceSummonData.Initial();
    this.AllianceSummonData.ActiveType = EActivityType.EAT_AllianceSummon;
    this.AllianceSummonData.EventState = (EActivityState) MP.ReadByte();
    this.AllianceSummonData.EventBeginTime = MP.ReadLong();
    this.AllianceSummonData.EventReqiureTIme = MP.ReadUInt();
    this.AllianceSummonAllianceID = MP.ReadUInt();
    this.AllianceSummonEventInfoID = MP.ReadUShort();
    this.SetAllianceSummonDate();
    this.CheckASCountTime();
    this.NobilityActivityData.Initial();
    this.NobilityActivityData.InitialNobility();
    this.NobilityActivityData.ActiveType = EActivityType.EAT_FederalEvent;
    this.NobilityActivityData.EventState = (EActivityState) MP.ReadByte();
    this.NobilityActivityData.EventBeginTime = MP.ReadLong();
    this.NobilityActivityData.EventReqiureTIme = MP.ReadUInt();
    this.FederalActKingdomWonderID = MP.ReadByte();
    this.FederalHomeKingdomWonderID = MP.ReadByte();
    this.FederalFightingWonderID = MP.ReadByte();
    this.FederalFullEventTimeWonderID = MP.ReadByte();
    this.CheckNWCountTime();
    this.CheckNWActivityTime();
    this.AllianceWarData.Initial();
    this.AllianceWarData.ActiveType = EActivityType.EAT_AllianceWar;
    this.AllianceWarData.EventState = (EActivityState) MP.ReadByte();
    this.AllianceWarData.EventBeginTime = MP.ReadLong();
    this.AllianceWarData.EventReqiureTIme = MP.ReadUInt();
    this.CheckAWCountTime(true);
    this.SetNowState(false);
    if (this.AW_EventBeginTime == 0L)
      this.AW_EventBeginTime = this.AllianceWarData.EventBeginTime;
    else if (this.AW_EventBeginTime != this.AllianceWarData.EventBeginTime)
      this.ClearAllianceWarData();
    this.CheckAWActivityTime();
    if (this.KvKActivityData[4].EventBeginTime != this.KvKActivityTime)
    {
      this.KvKActivityTime = this.KvKActivityData[4].EventBeginTime;
      this.SetbOpenKvKActivity(false);
    }
    if (this.KvKActivityData[4].EventState == EActivityState.EAS_Run && this.NowBeginTime != this.KvKActivityData[4].EventBeginTime)
    {
      this.bShowRunningP = false;
      this.bShowRunningE = false;
      this.NowBeginTime = this.KvKActivityData[4].EventBeginTime;
      this.ShowRunningTime = DataManager.Instance.ServerTime;
      CString str = StringManager.Instance.SpawnString(300);
      str.Append(DataManager.Instance.mStringTable.GetStringByID(9376U));
      GUIManager.Instance.WonderCountStr.Add(str);
      GUIManager.Instance.SetRunningText(str);
    }
    this.UpDateKVKCountTime();
    this.UpDateKvKState(eventState);
    if (this.KvKActivityData[4].EventState != EActivityState.EAS_Run || this.KvKActivityData[0].EventScore <= 0UL)
      return;
    FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.CREDITS_FOR_KVK, this.KvKActivityData[4].EventBeginTime, this.KvKActivityData[0].EventScore);
  }

  public void RecvActivity_Prepare(MessagePacket MP)
  {
    byte eType = MP.ReadByte();
    if ((int) eType < this.ActivityData.Length)
    {
      this.ActivityData[(int) eType].EventState = EActivityState.EAS_Prepare;
      this.ActivityData[(int) eType].EventBeginTime = MP.ReadLong();
      this.ActivityData[(int) eType].EventReqiureTIme = MP.ReadUInt();
      this.ActivityData[(int) eType].EventRank = MP.ReadByte();
      this.ActivityData[(int) eType].EventScore = 0UL;
      this.ActivityData[(int) eType].bAskDetailData = false;
      this.ActivityData[(int) eType].bAskRankPrize = false;
      this.CheckCountTime((EActivityCircleEventType) eType);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, (int) eType);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, (int) eType);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity4, 1, (int) eType);
    }
    this.CheckMonster(MP, eType == (byte) 0);
    this.CheckMonsterType(MP, eType == (byte) 0);
  }

  public void RecvActivity_Run(MessagePacket MP)
  {
    byte eType = MP.ReadByte();
    if ((int) eType < this.ActivityData.Length)
    {
      this.ActivityData[(int) eType].EventState = EActivityState.EAS_Run;
      this.ActivityData[(int) eType].EventScore = 0UL;
      this.CheckCountTime((EActivityCircleEventType) eType);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, (int) eType);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, (int) eType);
    }
    if (eType != (byte) 0)
      return;
    this.CheckShowNpcMessage();
  }

  public void RecvActivity_End(MessagePacket MP)
  {
    byte eType = MP.ReadByte();
    if ((int) eType >= this.ActivityData.Length)
      return;
    this.ActivityData[(int) eType].EventState = EActivityState.EAS_None;
    this.ActivityData[(int) eType].EventScore = 0UL;
    this.ActivityData[(int) eType].bAskDetailData = false;
    this.ActivityData[(int) eType].bAskRankPrize = false;
    this.CheckCountTime((EActivityCircleEventType) eType);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, (int) eType);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, (int) eType);
  }

  public void RecvActivity_EventList(MessagePacket MP)
  {
    int num1 = 2;
    for (int index1 = 0; index1 < num1; ++index1)
    {
      this.ActivityData[index1].ActiveType = (EActivityType) index1;
      this.ActivityData[index1].Name = MP.ReadUShort();
      this.ActivityData[index1].Pic = MP.ReadUShort();
      this.ActivityData[index1].PicStr = MP.ReadUShort();
      this.ActivityData[index1].DetailContentStrID = MP.ReadUShort();
      for (int index2 = 0; index2 < 3; ++index2)
        this.ActivityData[index1].RequireScore[index2] = MP.ReadUInt();
      this.ActivityData[index1].EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt();
      this.ActivityData[index1].EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt();
      this.ActivityData[index1].EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort();
    }
    for (int index = 0; index < 5; ++index)
    {
      this.CSActivityData[index].Name = MP.ReadUShort();
      this.CSActivityData[index].Pic = MP.ReadUShort();
      this.CSActivityData[index].PicStr = MP.ReadUShort();
    }
    for (int index = 0; index < 5; ++index)
    {
      this.SPActivityData[index].Name = MP.ReadUShort();
      this.SPActivityData[index].Pic = MP.ReadUShort();
      this.SPActivityData[index].PicStr = MP.ReadUShort();
    }
    this.KvKActivityData[0].KVKActiveType = EKVKActivityType.EKAT_KNormalSoloEvent;
    this.KvKActivityData[0].Name = MP.ReadUShort();
    this.KvKActivityData[0].Pic = MP.ReadUShort();
    this.KvKActivityData[0].PicStr = MP.ReadUShort();
    this.KvKActivityData[0].DetailContentStrID = MP.ReadUShort();
    for (int index = 0; index < 3; ++index)
      this.KvKActivityData[0].RequireScore[index] = MP.ReadUInt();
    this.KvKActivityData[0].EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt();
    this.KvKActivityData[0].EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt();
    this.KvKActivityData[0].EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort();
    this.AllyMobilizationData.Name = MP.ReadUShort();
    this.AllyMobilizationData.Pic = MP.ReadUShort();
    this.AllyMobilizationData.PicStr = MP.ReadUShort();
    this.AllyMobilizationData.DetailContentStrID = MP.ReadUShort();
    for (int index = 0; index < 3; ++index)
      this.AllyMobilizationData.RequireScore[index] = MP.ReadUInt();
    this.AllyMobilizationData.EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt();
    this.AllyMobilizationData.EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt();
    this.AllyMobilizationData.EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort();
    int num2 = 5;
    for (int index3 = 2; index3 < num2; ++index3)
    {
      this.KvKActivityData[index3].KVKActiveType = (EKVKActivityType) index3;
      this.KvKActivityData[index3].Name = MP.ReadUShort();
      this.KvKActivityData[index3].Pic = MP.ReadUShort();
      this.KvKActivityData[index3].PicStr = MP.ReadUShort();
      this.KvKActivityData[index3].DetailContentStrID = MP.ReadUShort();
      for (int index4 = 0; index4 < 3; ++index4)
        this.KvKActivityData[index3].RequireScore[index4] = MP.ReadUInt();
      this.KvKActivityData[index3].EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt();
      this.KvKActivityData[index3].EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt();
      this.KvKActivityData[index3].EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort();
    }
    this.KOWData.Name = MP.ReadUShort();
    this.KOWData.Pic = MP.ReadUShort();
    this.KOWData.PicStr = MP.ReadUShort();
    this.KOWData.DetailContentStrID = MP.ReadUShort();
    this.ActivityData[0].SpDegreePrizeFlag = MP.ReadByte();
    this.ActivityData[1].SpDegreePrizeFlag = MP.ReadByte();
    this.KvKActivityData[0].SpDegreePrizeFlag = MP.ReadByte();
    this.KvKActivityData[2].SpDegreePrizeFlag = MP.ReadByte();
    this.KvKActivityData[3].SpDegreePrizeFlag = MP.ReadByte();
    this.ActivityData[0].EventBonusType = (EActEventBonusType) MP.ReadByte();
    this.ActivityData[1].EventBonusType = (EActEventBonusType) MP.ReadByte();
    this.KvKActivityData[0].EventBonusType = (EActEventBonusType) MP.ReadByte();
    this.AllianceSummonData.Name = MP.ReadUShort();
    this.AllianceSummonData.Pic = MP.ReadUShort();
    this.AllianceSummonData.PicStr = MP.ReadUShort();
    this.AllianceSummonData.DetailContentStrID = MP.ReadUShort();
    this.AllianceSummonEventInfoID = MP.ReadUShort();
    this.SetAllianceSummonDate();
    this.NobilityActivityData.Name = MP.ReadUShort();
    this.NobilityActivityData.Pic = MP.ReadUShort();
    this.NobilityActivityData.PicStr = MP.ReadUShort();
    this.NobilityActivityData.DetailContentStrID = MP.ReadUShort();
    this.AllianceWarData.Name = MP.ReadUShort();
    this.AllianceWarData.Pic = MP.ReadUShort();
    this.AllianceWarData.PicStr = MP.ReadUShort();
    this.AllianceWarData.DetailContentStrID = MP.ReadUShort();
    this.AW_PrepareTime = MP.ReadUShort();
    this.AW_FightTime = MP.ReadByte();
    this.AW_WaitTime = MP.ReadUShort();
    this.AW_PrizeGroupID = MP.ReadByte();
    this.SetNowState();
    this.bAskSecondData = true;
    GUIManager.Instance.HideUILock(EUILock.Activity);
    if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity1))
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5);
    else if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
      this.door.OpenMenu(EGUIWindow.UI_Activity1);
    for (int index = this.door.m_WindowStack.Count - 1; index >= 0; --index)
    {
      if (this.door.m_WindowStack[index].m_eWindow == EGUIWindow.UI_LetterDetail || this.door.m_WindowStack[index].m_eWindow == EGUIWindow.UI_Letter)
        this.door.m_WindowStack.RemoveAt(index);
    }
  }

  public void RecvActivity_EventListSingle(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Activity);
    if (MP.ReadByte() != (byte) 0)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107U), (ushort) byte.MaxValue);
    }
    else
    {
      byte index1 = (byte) ((uint) MP.ReadByte() - 1U);
      switch (index1)
      {
        case 0:
        case 1:
          this.ActivityData[(int) index1].Name = MP.ReadUShort();
          this.ActivityData[(int) index1].Pic = MP.ReadUShort();
          this.ActivityData[(int) index1].PicStr = MP.ReadUShort();
          this.ActivityData[(int) index1].DetailContentStrID = MP.ReadUShort();
          for (int index2 = 0; index2 < 3; ++index2)
            this.ActivityData[(int) index1].RequireScore[index2] = MP.ReadUInt();
          this.ActivityData[(int) index1].EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt();
          this.ActivityData[(int) index1].EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt();
          this.ActivityData[(int) index1].EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort();
          this.ActivityData[(int) index1].SpDegreePrizeFlag = MP.ReadByte();
          this.ActivityData[(int) index1].EventBonusType = (EActEventBonusType) MP.ReadByte();
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 4, (int) index1);
          break;
        case 6:
          this.AllyMobilizationData.Name = MP.ReadUShort();
          this.AllyMobilizationData.Pic = MP.ReadUShort();
          this.AllyMobilizationData.PicStr = MP.ReadUShort();
          this.AllyMobilizationData.DetailContentStrID = MP.ReadUShort();
          for (int index3 = 0; index3 < 3; ++index3)
            this.AllyMobilizationData.RequireScore[index3] = MP.ReadUInt();
          this.AllyMobilizationData.EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt();
          this.AllyMobilizationData.EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt();
          this.AllyMobilizationData.EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort();
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 4, 206);
          break;
        case 7:
          this.KOWData.Name = MP.ReadUShort();
          this.KOWData.Pic = MP.ReadUShort();
          this.KOWData.PicStr = MP.ReadUShort();
          this.KOWData.DetailContentStrID = MP.ReadUShort();
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 4, 207);
          break;
        case 11:
          this.AllianceSummonData.Name = MP.ReadUShort();
          this.AllianceSummonData.Pic = MP.ReadUShort();
          this.AllianceSummonData.PicStr = MP.ReadUShort();
          this.AllianceSummonData.DetailContentStrID = MP.ReadUShort();
          this.AllianceSummonEventInfoID = MP.ReadUShort();
          this.SetAllianceSummonDate();
          if (this.bReOpen)
          {
            if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
              break;
            if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity2))
              this.door.CloseMenu();
            this.bReOpen = false;
            this.door.OpenMenu(EGUIWindow.UI_Activity2, 208);
            break;
          }
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 4, 208);
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, 208);
          GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 3);
          break;
        case 12:
          this.NobilityActivityData.Name = MP.ReadUShort();
          this.NobilityActivityData.Pic = MP.ReadUShort();
          this.NobilityActivityData.PicStr = MP.ReadUShort();
          this.NobilityActivityData.DetailContentStrID = MP.ReadUShort();
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 4, 209);
          break;
        case 13:
          this.AllianceWarData.Name = MP.ReadUShort();
          this.AllianceWarData.Pic = MP.ReadUShort();
          this.AllianceWarData.PicStr = MP.ReadUShort();
          this.AllianceWarData.DetailContentStrID = MP.ReadUShort();
          this.AW_PrepareTime = MP.ReadUShort();
          this.AW_FightTime = MP.ReadByte();
          this.AW_WaitTime = MP.ReadUShort();
          this.AW_PrizeGroupID = MP.ReadByte();
          this.SetNowState();
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 4, 210);
          break;
      }
    }
  }

  public void RecvActivity_EventDetail(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Activity);
    if (MP.ReadByte() != (byte) 0)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107U), (ushort) byte.MaxValue);
    }
    else
    {
      byte index1 = MP.ReadByte();
      if ((int) index1 < this.ActivityData.Length)
      {
        for (int index2 = 0; index2 < 6; ++index2)
        {
          this.ActivityData[(int) index1].GetScoreFactor[index2].Factor = (EGetScoreFactor) MP.ReadByte();
          this.ActivityData[(int) index1].GetScoreFactor[index2].BonusRate = MP.ReadByte();
        }
        for (int index3 = 0; index3 < 3; ++index3)
        {
          this.ActivityData[(int) index1].EventPrizeWorthData[index3].Crystal = MP.ReadUInt();
          this.ActivityData[(int) index1].EventPrizeWorthData[index3].CrystalPrice = MP.ReadUInt();
          this.ActivityData[(int) index1].EventPrizeWorthData[index3].Priceless = MP.ReadUShort();
        }
        int num = 0;
        for (int index4 = 0; index4 < 3; ++index4)
        {
          this.ActivityData[(int) index1].DataLen[index4] = MP.ReadByte();
          num += (int) this.ActivityData[(int) index1].DataLen[index4];
        }
        for (int index5 = 0; index5 < num; ++index5)
        {
          this.ActivityData[(int) index1].DegreePrize[index5].Rank = MP.ReadByte();
          this.ActivityData[(int) index1].DegreePrize[index5].ItemID = MP.ReadUShort();
          this.ActivityData[(int) index1].DegreePrize[index5].Num = MP.ReadByte();
        }
        this.ActivityData[(int) index1].bAskDetailData = true;
      }
      if (!this.bAskDetailData || this.bReOpenPrize || !((UnityEngine.Object) this.door != (UnityEngine.Object) null))
        return;
      if (this.bReOpen)
      {
        if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity2))
          this.door.CloseMenu();
        this.bReOpen = false;
      }
      this.door.OpenMenu(EGUIWindow.UI_Activity2, (int) index1);
    }
  }

  public void RecvActivity_RankingPrize(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Activity);
    if (MP.ReadByte() != (byte) 0)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107U), (ushort) byte.MaxValue);
    }
    else
    {
      byte index1 = MP.ReadByte();
      if ((int) index1 < this.ActivityData.Length)
      {
        for (int index2 = 0; index2 < 7; ++index2)
        {
          this.ActivityData[(int) index1].RankPrizeWorthData[index2].Crystal = MP.ReadUInt();
          this.ActivityData[(int) index1].RankPrizeWorthData[index2].CrystalPrice = MP.ReadUInt();
          this.ActivityData[(int) index1].RankPrizeWorthData[index2].Priceless = MP.ReadUShort();
        }
        int num = 0;
        for (int index3 = 0; index3 < 7; ++index3)
        {
          this.ActivityData[(int) index1].RankingPrizeDataLen[index3] = MP.ReadByte();
          num += (int) this.ActivityData[(int) index1].RankingPrizeDataLen[index3];
        }
        for (int index4 = 0; index4 < num; ++index4)
        {
          this.ActivityData[(int) index1].RankingPrize[index4].Rank = MP.ReadByte();
          this.ActivityData[(int) index1].RankingPrize[index4].ItemID = MP.ReadUShort();
          this.ActivityData[(int) index1].RankingPrize[index4].Num = MP.ReadByte();
        }
        this.ActivityData[(int) index1].bAskRankPrize = true;
      }
      if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
        return;
      if (this.bReOpenPrize)
      {
        if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity4))
          this.door.CloseMenu();
        this.bReOpenPrize = false;
      }
      this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, (int) index1);
    }
  }

  public void RecvActivity_GetPrize(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0);
    instance.RoleAlliance.Money = MP.ReadUInt();
    byte num = MP.ReadByte();
    bool flag = false;
    for (int index = 0; index < (int) num; ++index)
    {
      ushort ItemID = MP.ReadUShort();
      ushort Quantity = MP.ReadUShort();
      byte Rare = MP.ReadByte();
      instance.SetCurItemQuantity(ItemID, Quantity, Rare, 0L);
      if (Rare > (byte) 0)
        flag = true;
    }
    if (flag)
      LordEquipData.Instance().Scan_MaterialOrEquipIncreace();
    GameManager.OnRefresh();
  }

  public void RecvActivity_Close(MessagePacket MP)
  {
  }

  public void RecvActivity_SpEvent_List_Single(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Activity);
    byte num = MP.ReadByte();
    EActivityType eactivityType = (EActivityType) ((int) MP.ReadByte() - 1);
    byte index = MP.ReadByte();
    if (num != (byte) 0)
      return;
    switch (eactivityType)
    {
      case EActivityType.EAT_ComingSoonSpEvent:
        if (index >= (byte) 5)
          break;
        this.CSActivityData[(int) index].Name = MP.ReadUShort();
        this.CSActivityData[(int) index].Pic = MP.ReadUShort();
        this.CSActivityData[(int) index].PicStr = MP.ReadUShort();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 9, (int) index);
        break;
      case EActivityType.EAT_SpecialEvent:
        if (index >= (byte) 5)
          break;
        this.SPActivityData[(int) index].Name = MP.ReadUShort();
        this.SPActivityData[(int) index].Pic = MP.ReadUShort();
        this.SPActivityData[(int) index].PicStr = MP.ReadUShort();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 10, (int) index);
        break;
    }
  }

  public void RecvActivity_UpDateInfo(MessagePacket MP)
  {
    EActivityType Type = (EActivityType) ((int) MP.ReadByte() - 1);
    byte index = MP.ReadByte();
    switch (Type)
    {
      case EActivityType.EAT_ComingSoonSpEvent:
        if (index >= (byte) 5)
          return;
        this.SetCSData(MP, (int) index);
        if (this.CSActivityData[(int) index].EventBeginTime != 0L)
          this.SendAskDownLoad();
        if (this.CSActivityData[(int) index].EventBeginTime != this.CSActivityTime[(int) index])
          this.CSActivityTime[(int) index] = this.CSActivityData[(int) index].EventBeginTime;
        this.SetbOpenCSActivity(index, false);
        if (this.CSActivityData[(int) index].EventBeginTime != 0L && (bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity1))
          ActivityManager.Instance.Send_ACTIVITY_SPEVENT_LIST_SINGLE(Type, index);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity3, 3, (int) Type);
        break;
      case EActivityType.EAT_SpecialEvent:
        if (index >= (byte) 5)
          return;
        this.SetSPData(MP, (int) index);
        if (this.SPActivityData[(int) index].EventBeginTime != 0L)
          this.SendAskDownLoad();
        if (this.SPActivityData[(int) index].EventBeginTime != this.SPActivityTime[(int) index])
          this.SPActivityTime[(int) index] = this.SPActivityData[(int) index].EventBeginTime;
        this.SetbOpenSPActivity(index, false);
        if (this.SPActivityData[(int) index].EventBeginTime != 0L && (bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity1))
          ActivityManager.Instance.Send_ACTIVITY_SPEVENT_LIST_SINGLE(Type, index);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity3, 3, (int) Type);
        break;
    }
    this.SetTreasureBoxID(MP.ReadUShort());
  }

  public void RecvActivity_KEventListSingle(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Activity);
    if (MP.ReadByte() != (byte) 0)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107U), (ushort) byte.MaxValue);
    }
    else
    {
      int kvkDataIndexByType = this.GetKvkDataIndexByType((EActivityType) ((int) MP.ReadByte() - 1), (EActivityKingdomEventType) MP.ReadByte());
      if (kvkDataIndexByType == -1)
        return;
      int index1 = kvkDataIndexByType - 201;
      if (index1 >= this.KvKActivityData.Length)
        return;
      this.KvKActivityData[index1].Name = MP.ReadUShort();
      this.KvKActivityData[index1].Pic = MP.ReadUShort();
      this.KvKActivityData[index1].PicStr = MP.ReadUShort();
      this.KvKActivityData[index1].DetailContentStrID = MP.ReadUShort();
      for (int index2 = 0; index2 < 3; ++index2)
        this.KvKActivityData[index1].RequireScore[index2] = MP.ReadUInt();
      this.KvKActivityData[index1].EventAllDegreePrizeWorthData.Crystal = MP.ReadUInt();
      this.KvKActivityData[index1].EventAllDegreePrizeWorthData.CrystalPrice = MP.ReadUInt();
      this.KvKActivityData[index1].EventAllDegreePrizeWorthData.Priceless = MP.ReadUShort();
      this.KvKActivityData[index1].SpDegreePrizeFlag = MP.ReadByte();
      this.KvKActivityData[index1].EventBonusType = (EActEventBonusType) MP.ReadByte();
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 4, kvkDataIndexByType);
    }
  }

  public void RecvActivity_KEventDetail(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Activity);
    if (MP.ReadByte() != (byte) 0)
      return;
    EActivityType InType = (EActivityType) ((int) MP.ReadByte() - 1);
    EActivityKingdomEventType InKvKType = (EActivityKingdomEventType) MP.ReadByte();
    int kvkDataIndexByType = this.GetKvkDataIndexByType(InType, InKvKType);
    if (kvkDataIndexByType == -1)
      return;
    int index1 = kvkDataIndexByType - 201;
    if (index1 >= this.KvKActivityData.Length)
      return;
    for (int index2 = 0; index2 < 6; ++index2)
    {
      this.KvKActivityData[index1].GetScoreFactor[index2].Factor = (EGetScoreFactor) MP.ReadByte();
      this.KvKActivityData[index1].GetScoreFactor[index2].BonusRate = MP.ReadByte();
    }
    for (int index3 = 0; index3 < 3; ++index3)
    {
      this.KvKActivityData[index1].EventPrizeWorthData[index3].Crystal = MP.ReadUInt();
      this.KvKActivityData[index1].EventPrizeWorthData[index3].CrystalPrice = MP.ReadUInt();
      this.KvKActivityData[index1].EventPrizeWorthData[index3].Priceless = MP.ReadUShort();
    }
    double num1 = MP.ReadDouble();
    if (InKvKType == EActivityKingdomEventType.EAKET_KingdomEvent)
      this.KingdomKvKRank = num1;
    int num2 = 0;
    for (int index4 = 0; index4 < 3; ++index4)
    {
      this.KvKActivityData[index1].DataLen[index4] = MP.ReadByte();
      num2 += (int) this.KvKActivityData[index1].DataLen[index4];
    }
    for (int index5 = 0; index5 < num2; ++index5)
    {
      this.KvKActivityData[index1].DegreePrize[index5].Rank = MP.ReadByte();
      this.KvKActivityData[index1].DegreePrize[index5].ItemID = MP.ReadUShort();
      this.KvKActivityData[index1].DegreePrize[index5].Num = MP.ReadByte();
    }
    this.KvKActivityData[index1].bAskDetailData = true;
    if (!this.bAskDetailData || this.bReOpenPrize || !((UnityEngine.Object) this.door != (UnityEngine.Object) null))
      return;
    if (this.bReOpen)
    {
      if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity2))
        this.door.CloseMenu();
      this.bReOpen = false;
    }
    this.door.OpenMenu(EGUIWindow.UI_Activity2, kvkDataIndexByType);
  }

  public void RecvActivity_Kevent_UpdateStateE(MessagePacket MP)
  {
    EActivityState eventState1 = this.KvKActivityData[4].EventState;
    EActivityType eactivityType = (EActivityType) ((int) MP.ReadByte() - 1);
    EActivityKingdomEventType InKvKType = (EActivityKingdomEventType) MP.ReadByte();
    EActivityState State = (EActivityState) MP.ReadByte();
    long time = MP.ReadLong();
    uint num1 = MP.ReadUInt();
    byte num2 = MP.ReadByte();
    switch (eactivityType)
    {
      case EActivityType.EAT_KingdomKillEvent:
      case EActivityType.EAT_KingdomNormalEvent:
      case EActivityType.EAT_KingdomMatchEvent:
        int kvkDataIndexByType = this.GetKvkDataIndexByType(eactivityType, InKvKType);
        if (kvkDataIndexByType == -1)
          break;
        int index1 = kvkDataIndexByType - 201;
        if (index1 >= this.KvKActivityData.Length)
          break;
        this.KvKActivityData[index1].ActiveType = eactivityType;
        EActivityState eventState2 = this.KvKActivityData[index1].EventState;
        this.SetKVKState(index1, State);
        this.KvKActivityData[index1].EventBeginTime = time;
        this.KvKActivityData[index1].EventReqiureTIme = num1;
        if (index1 == 0 && State == EActivityState.EAS_Prepare || index1 == 4 && State == EActivityState.EAS_Run)
          this.KvKActivityData[index1].EventRank = num2;
        this.CheckKVKCountTime((EKVKActivityType) index1);
        if (index1 == 4)
        {
          for (int index2 = 2; index2 <= 3; ++index2)
          {
            this.SetKVKState(index2, State);
            this.KvKActivityData[index2].ActiveType = this.KvKActivityData[4].ActiveType;
            this.KvKActivityData[index2].EventBeginTime = time;
            this.KvKActivityData[index2].EventReqiureTIme = num1;
            if (State == EActivityState.EAS_Run)
              this.KvKActivityData[index2].EventRank = num2;
            this.CheckKVKCountTime((EKVKActivityType) index2);
          }
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, 203);
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, 204);
          if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity1))
          {
            switch (State)
            {
              case EActivityState.EAS_Run:
                ActivityManager.Instance.Send_ACTIVITY_KEVENT_LIST_SINGLE((byte) 203);
                ActivityManager.Instance.Send_ACTIVITY_KEVENT_LIST_SINGLE((byte) 204);
                break;
              case EActivityState.EAS_Prepare:
                ActivityManager.Instance.Send_ACTIVITY_KEVENT_LIST_SINGLE((byte) 205);
                break;
            }
          }
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5);
          if (eventState2 == EActivityState.EAS_Prepare && this.KvKActivityData[4].EventState == EActivityState.EAS_Run)
          {
            this.bShowRunningP = false;
            this.bShowRunningE = false;
            CString str = StringManager.Instance.SpawnString(300);
            str.Append(DataManager.Instance.mStringTable.GetStringByID(9376U));
            GUIManager.Instance.WonderCountStr.Add(str);
            GUIManager.Instance.SetRunningText(str);
          }
          else if (eventState2 == EActivityState.EAS_Run && this.KvKActivityData[4].EventState == EActivityState.EAS_HomeStart)
          {
            this.bShowRunningP = false;
            this.bShowRunningE = false;
            CString str = StringManager.Instance.SpawnString(300);
            str.Append(DataManager.Instance.mStringTable.GetStringByID(9811U));
            GUIManager.Instance.WonderCountStr.Add(str);
            GUIManager.Instance.SetRunningText(str);
          }
          if (State == EActivityState.EAS_HomeStart)
          {
            this.KVKHuntOrder = (byte) 0;
            this.KVKReTime = 0L;
          }
        }
        else if (index1 == 0 && State == EActivityState.EAS_Prepare && (bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity1))
          ActivityManager.Instance.Send_ACTIVITY_KEVENT_LIST_SINGLE((byte) 201);
        if (State == EActivityState.EAS_None || eventState2 == EActivityState.EAS_None)
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5);
        else
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, kvkDataIndexByType);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, kvkDataIndexByType);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity4, 1, kvkDataIndexByType);
        GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
        this.UpDateKvKState(eventState1);
        break;
      case EActivityType.EAT_AllianceMobilization:
        MobilizationManager.Instance.SetAllyMobilizationBeginTime(time);
        this.AllyMobilizationData.EventState = State;
        this.AllyMobilizationData.EventBeginTime = time;
        this.AllyMobilizationData.EventReqiureTIme = num1;
        switch (State)
        {
          case EActivityState.EAS_None:
          case EActivityState.EAS_Prepare:
            this.AllyMobilizationData.EventScore = 0UL;
            this.AllyMobilizationData.bAskDetailData = false;
            this.AllyMobilizationData.bAskRankPrize = false;
            if (State == EActivityState.EAS_Prepare)
              this.Send_ACTIVITY_EVENT_LIST_SINGLE((byte) eactivityType);
            this.AMAllianceID = 0U;
            break;
          case EActivityState.EAS_Run:
            this.AllyMobilizationData.EventScore = 0UL;
            this.AMAllianceID = DataManager.Instance.RoleAlliance.Id;
            break;
          case EActivityState.EAS_ReplayRanking:
            this.AllyMobilizationData.bAskDetailData = false;
            break;
        }
        this.CheckAMActivityTime();
        this.CheckAMCountTime();
        if (State == EActivityState.EAS_Prepare || State == EActivityState.EAS_None)
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5);
        else
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, 206);
        if (State == EActivityState.EAS_ReplayRanking || State == EActivityState.EAS_Prepare)
          MobilizationManager.Instance.bFirstOpen = true;
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 6);
        if (State == EActivityState.EAS_ReplayRanking)
        {
          MobilizationManager.Instance.mMissionID = (ushort) 0;
          DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, false, 0L, 0U);
          this.CheckAMShowHint();
          break;
        }
        if (State != EActivityState.EAS_None)
          break;
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_RewardsSelect, 2);
        break;
      case EActivityType.EAT_KingOfTheWorld:
        if (this.KOWData.EventState != State)
        {
          this.KOWData.EventState = State;
          byte kingdomTableID = 0;
          if (DataManager.MapDataController.GetWorldKingdomTableID(this.KOWKingdomID, out kingdomTableID))
            DataManager.MapDataController.KingdomNotifyObserver(kingdomTableID, MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_OWNERKINGDOMID);
        }
        this.KOWData.EventBeginTime = time;
        this.KOWData.EventReqiureTIme = num1;
        this.KOWData.EventPrizeID = MP.ReadUShort();
        this.KOWData.EventPrizeID2 = MP.ReadUShort();
        this.KOWData.EventPrizeID3 = MP.ReadUShort();
        this.KOWData.bAskDetailData = this.KOWData.EventState != EActivityState.EAS_ReplayRanking;
        if ((State == EActivityState.EAS_Prepare || State == EActivityState.EAS_None) && State == EActivityState.EAS_Prepare)
          this.Send_ACTIVITY_EVENT_LIST_SINGLE((byte) eactivityType);
        this.CheckKOWCountTime();
        if (State == EActivityState.EAS_Prepare || State == EActivityState.EAS_None)
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5);
        else
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, 207);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, 207);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_WonderReward, 0);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 6);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 9, 1);
        DataManager.Instance.UpdateItemBuffIcon();
        GameManager.OnRefresh(NetworkNews.Refresh_BuffList);
        break;
    }
  }

  public void RecvActivity_Kevent_RankingPrize(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Activity);
    if (MP.ReadByte() != (byte) 0)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107U), (ushort) byte.MaxValue);
    }
    else
    {
      int kvkDataIndexByType = this.GetKvkDataIndexByType((EActivityType) ((int) MP.ReadByte() - 1), (EActivityKingdomEventType) MP.ReadByte());
      if (kvkDataIndexByType == -1)
        return;
      int index1 = kvkDataIndexByType - 201;
      if (index1 >= this.KvKActivityData.Length)
        return;
      for (int index2 = 0; index2 < 7; ++index2)
      {
        this.KvKActivityData[index1].RankPrizeWorthData[index2].Crystal = MP.ReadUInt();
        this.KvKActivityData[index1].RankPrizeWorthData[index2].CrystalPrice = MP.ReadUInt();
        this.KvKActivityData[index1].RankPrizeWorthData[index2].Priceless = MP.ReadUShort();
      }
      int num = 0;
      for (int index3 = 0; index3 < 7; ++index3)
      {
        this.KvKActivityData[index1].RankingPrizeDataLen[index3] = MP.ReadByte();
        num += (int) this.KvKActivityData[index1].RankingPrizeDataLen[index3];
      }
      for (int index4 = 0; index4 < num; ++index4)
      {
        this.KvKActivityData[index1].RankingPrize[index4].Rank = MP.ReadByte();
        this.KvKActivityData[index1].RankingPrize[index4].ItemID = MP.ReadUShort();
        this.KvKActivityData[index1].RankingPrize[index4].Num = MP.ReadByte();
      }
      this.KvKActivityData[index1].bAskRankPrize = true;
      if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
        return;
      if (this.bReOpenPrize)
      {
        if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity4))
          this.door.CloseMenu();
        this.bReOpenPrize = false;
      }
      this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, kvkDataIndexByType);
    }
  }

  public void RecvActivity_AM_RankingPrize(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Activity);
    if (MP.ReadByte() != (byte) 0)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107U), (ushort) byte.MaxValue);
    }
    else
    {
      for (int index = 0; index < 5; ++index)
      {
        this.AllyMobilizationData.RankPrizeWorthData[index].Crystal = MP.ReadUInt();
        this.AllyMobilizationData.RankPrizeWorthData[index].CrystalPrice = MP.ReadUInt();
        this.AllyMobilizationData.RankPrizeWorthData[index].Priceless = MP.ReadUShort();
      }
      int num = 0;
      for (int index = 0; index < 5; ++index)
      {
        this.AllyMobilizationData.RankingPrizeDataLen[index] = MP.ReadByte();
        num += (int) this.AllyMobilizationData.RankingPrizeDataLen[index];
      }
      for (int index = 0; index < num; ++index)
      {
        this.AllyMobilizationData.RankingPrize[index].Rank = MP.ReadByte();
        this.AllyMobilizationData.RankingPrize[index].ItemID = MP.ReadUShort();
        this.AllyMobilizationData.RankingPrize[index].Num = MP.ReadByte();
      }
      this.AllyMobilizationData.bAskRankPrize = true;
      if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
        return;
      if (this.bReOpenPrize)
      {
        if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity4))
          this.door.CloseMenu();
        this.bReOpenPrize = false;
      }
      this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, 206);
    }
  }

  public void RecvActivity_KOW_KingInfo(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Activity);
    this.WKKingdom = MP.ReadUShort();
    this.WKTag.Length = 0;
    MP.ReadStringPlus(3, this.WKTag);
    this.WKName.Length = 0;
    MP.ReadStringPlus(13, this.WKName);
    this.WKIcon = MP.ReadUShort();
    this.KOWData.bAskDetailData = true;
    if (!this.bAskDetailData || !((UnityEngine.Object) this.door != (UnityEngine.Object) null))
      return;
    if (this.bReOpen)
    {
      if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity2))
        this.door.CloseMenu();
      this.bReOpen = false;
    }
    this.door.OpenMenu(EGUIWindow.UI_Activity2, 207, bCameraMode: true);
  }

  public void RecvActivity_AllianceSummon_UpdateState(MessagePacket MP)
  {
    EActivityState eactivityState = (EActivityState) MP.ReadByte();
    long num1 = MP.ReadLong();
    uint num2 = MP.ReadUInt();
    this.AllianceSummonData.EventState = eactivityState;
    this.AllianceSummonData.EventBeginTime = num1;
    this.AllianceSummonData.EventReqiureTIme = num2;
    switch (eactivityState)
    {
      case EActivityState.EAS_None:
      case EActivityState.EAS_Prepare:
        this.AllianceSummonAllianceID = 0U;
        this.AllianceSummonEventInfoID = (ushort) 0;
        this.SetAllianceSummon_Score(0U);
        this.ClearAllianceSummonData();
        this.AllianceSummonData.bAskRankPrize = false;
        if (eactivityState == EActivityState.EAS_Prepare)
        {
          this.Send_ACTIVITY_EVENT_LIST_SINGLE((byte) 11);
          break;
        }
        break;
      case EActivityState.EAS_Run:
        this.AllianceSummonData.EventScore = 0UL;
        this.AllianceSummonAllianceID = DataManager.Instance.RoleAlliance.Id;
        break;
      case EActivityState.EAS_ReplayRanking:
        this.AllianceSummonData.bAskDetailData = false;
        break;
    }
    this.CheckASCountTime();
    if (eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5);
    else
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, 208);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, 208);
    if (eactivityState == EActivityState.EAS_Run)
      return;
    GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 5);
  }

  public void RecvActivity_AllianceSummon_KMSG(MessagePacket MP)
  {
    CString tmp = StringManager.Instance.StaticString1024();
    CString cstring1 = StringManager.Instance.StaticString1024();
    CString cstring2 = StringManager.Instance.StaticString1024();
    MP.ReadStringPlus(3, cstring1);
    MP.ReadStringPlus(20, cstring2);
    uint nameId = (uint) DataManager.MapDataController.MapMonsterTable.GetRecordByKey(MP.ReadUShort()).NameID;
    tmp.ClearString();
    tmp.StringToFormat(cstring1);
    tmp.StringToFormat(cstring2);
    tmp.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(nameId));
    tmp.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(14513U));
    DataManager.Instance.AddSystemMessage(tmp, (byte) 8, -1L);
  }

  public void RecvActivity_UPDATESTATE(MessagePacket MP)
  {
    EActivityType index = (EActivityType) ((int) MP.ReadByte() - 1);
    EActivityState eactivityState = (EActivityState) MP.ReadByte();
    long num1 = MP.ReadLong();
    uint num2 = MP.ReadUInt();
    switch (index)
    {
      case EActivityType.EAT_FederalEvent:
        this.NobilityActivityData.EventState = eactivityState;
        this.NobilityActivityData.EventBeginTime = num1;
        this.NobilityActivityData.EventReqiureTIme = num2;
        switch (eactivityState)
        {
          case EActivityState.EAS_None:
            this.FederalHomeKingdomWonderID = (byte) 0;
            this.FederalFightingWonderID = (byte) 0;
            this.FederalFullEventTimeWonderID = (byte) 0;
            break;
          case EActivityState.EAS_Prepare:
            this.Send_ACTIVITY_EVENT_LIST_SINGLE((byte) 12);
            break;
        }
        this.CheckNWActivityTime();
        this.CheckNWCountTime();
        if (eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None)
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5);
        else
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 3, 209);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 2, 209);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_MiniMap, 1);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 6);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena_Info, 2);
        break;
      case EActivityType.EAT_AllianceWar:
        this.AllianceWarData.EventState = eactivityState;
        this.AllianceWarData.EventBeginTime = num1;
        this.AllianceWarData.EventReqiureTIme = num2;
        this.AW_EventBeginTime = this.AllianceWarData.EventBeginTime;
        if (eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None)
        {
          this.AllianceWarData.bAskRankPrize = false;
          if (eactivityState == EActivityState.EAS_Prepare)
            this.Send_ACTIVITY_EVENT_LIST_SINGLE((byte) index);
        }
        this.CheckAWCountTime();
        this.SetNowState();
        this.CheckAWActivityTime();
        this.UpDateAllianceWarTop();
        if (eactivityState == EActivityState.EAS_Prepare || eactivityState == EActivityState.EAS_None)
        {
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 5);
          break;
        }
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 17);
        break;
    }
  }

  private void SetKVKState(int DataTypeIndex, EActivityState State)
  {
    if (DataTypeIndex >= this.KvKActivityData.Length)
      return;
    this.KvKActivityData[DataTypeIndex].EventState = State;
    switch (State)
    {
      case EActivityState.EAS_None:
      case EActivityState.EAS_Prepare:
        this.KvKActivityData[DataTypeIndex].EventScore = 0UL;
        this.KvKActivityData[DataTypeIndex].bAskDetailData = false;
        this.KvKActivityData[DataTypeIndex].bAskRankPrize = false;
        break;
      case EActivityState.EAS_Run:
        this.KvKActivityData[DataTypeIndex].EventScore = 0UL;
        break;
      case EActivityState.EAS_ReplayRanking:
        this.KvKActivityData[DataTypeIndex].bAskDetailData = false;
        break;
    }
  }

  public void SetTreasureBoxID(ushort ID)
  {
    this.TreasureBoxID = ID;
    CString Name = StringManager.Instance.StaticString1024();
    Name.Append("UI/UIActivityBack_3");
    if (AssetManager.GetAssetBundleDownload(Name, AssetPath.Activity, AssetType.ActivityBack, (ushort) 3))
      this.bDownLoadPic3 = true;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 23);
  }

  public void SendAskDownLoad()
  {
    CString Name1 = StringManager.Instance.StaticString1024();
    Name1.Append("UI/UIActivityBack_1");
    if (AssetManager.GetAssetBundleDownload(Name1, AssetPath.Activity, AssetType.ActivityBack, (ushort) 1))
      this.bDownLoadPic1 = true;
    CString Name2 = StringManager.Instance.StaticString1024();
    Name2.Append("UI/UIActivityBack_2");
    if (AssetManager.GetAssetBundleDownload(Name2, AssetPath.Activity, AssetType.ActivityBack, (ushort) 2))
      this.bDownLoadPic2 = true;
    for (int index = 0; index < this.CSActivityData.Length; ++index)
    {
      if (this.CSActivityData[index].EventBeginTime != 0L)
      {
        CString Name3 = StringManager.Instance.StaticString1024();
        Name3.IntToFormat((long) this.CSActivityData[index].DetailStr);
        Name3.AppendFormat("UI/UIActivityPackage_{0}");
        if (AssetManager.GetAssetBundleDownload(Name3, AssetPath.Activity, AssetType.ActivityPackage, this.CSActivityData[index].DetailStr))
          this.CSActivityData[index].bDownLoadStr = true;
      }
    }
    for (int index = 0; index < this.SPActivityData.Length; ++index)
    {
      if (this.SPActivityData[index].EventBeginTime != 0L)
      {
        CString Name4 = StringManager.Instance.StaticString1024();
        Name4.IntToFormat((long) this.SPActivityData[index].DetailStr);
        Name4.AppendFormat("UI/UIActivityPackage_{0}");
        if (AssetManager.GetAssetBundleDownload(Name4, AssetPath.Activity, AssetType.ActivityPackage, this.SPActivityData[index].DetailStr))
          this.SPActivityData[index].bDownLoadStr = true;
      }
    }
  }

  public void UpDateDownLoad(byte[] meg)
  {
    byte num = meg[2];
    ushort id = GameConstants.ConvertBytesToUShort(meg, 3);
    if (meg[5] == (byte) 1)
    {
      if (num == (byte) 0)
        AssetManager.RequestActivityBundle(id, true);
      else
        AssetManager.RequestActivityPackage(id, true);
    }
    else
    {
      if (meg[5] == (byte) 2)
        return;
      if (num == (byte) 0)
      {
        switch (id)
        {
          case 1:
            if (this.bDownLoadPic1)
              this.bUpDatePic1 = true;
            else
              this.bDownLoadPic1 = true;
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 6);
            break;
          case 2:
            if (this.bDownLoadPic2)
              this.bUpDatePic2 = true;
            else
              this.bDownLoadPic2 = true;
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity3, 1);
            break;
          case 3:
            if (this.bDownLoadPic3)
              this.bUpDatePic3 = true;
            else
              this.bDownLoadPic3 = true;
            GUIManager.Instance.UpdateUI(EGUIWindow.Door, 23);
            break;
        }
      }
      else
      {
        for (int index = 0; index < this.CSActivityData.Length; ++index)
        {
          if (this.CSActivityData[index].EventBeginTime != 0L && (int) this.CSActivityData[index].DetailStr == (int) id)
          {
            if (this.CSActivityData[index].bDownLoadStr)
              this.CSActivityData[index].bUpDateStr = true;
            else
              this.CSActivityData[index].bDownLoadStr = true;
          }
        }
        for (int index = 0; index < this.SPActivityData.Length; ++index)
        {
          if (this.SPActivityData[index].EventBeginTime != 0L && (int) this.SPActivityData[index].DetailStr == (int) id)
          {
            if (this.SPActivityData[index].bDownLoadStr)
              this.SPActivityData[index].bUpDateStr = true;
            else
              this.SPActivityData[index].bDownLoadStr = true;
          }
        }
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 7);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity3, 2);
      }
    }
  }

  public void SetCSData(MessagePacket MP, int tmpIndex = -1)
  {
    if (tmpIndex == -1)
    {
      for (int bIndex = 0; bIndex < 5; ++bIndex)
      {
        this.CSActivityData[bIndex].Initial();
        this.CSActivityData[bIndex].DetailPic = MP.ReadUShort();
        this.CSActivityData[bIndex].HeadStr = MP.ReadUShort();
        this.CSActivityData[bIndex].DetailStr = MP.ReadUShort();
        this.CSActivityData[bIndex].GoToButton = MP.ReadUShort();
        this.CSActivityData[bIndex].Marquee = MP.ReadUShort();
        this.CSActivityData[bIndex].EventBeginTime = MP.ReadLong();
        this.CSActivityData[bIndex].EventEndTime = MP.ReadLong();
        if (this.CSActivityData[bIndex].EventBeginTime == 0L)
          this.CSActivityData[bIndex].Initial();
        this.CheckActivity(0, bIndex, this.CSActivityData[bIndex].EventBeginTime);
      }
    }
    else
    {
      if (tmpIndex >= 5)
        return;
      this.CSActivityData[tmpIndex].Initial();
      this.CSActivityData[tmpIndex].DetailPic = MP.ReadUShort();
      this.CSActivityData[tmpIndex].HeadStr = MP.ReadUShort();
      this.CSActivityData[tmpIndex].DetailStr = MP.ReadUShort();
      this.CSActivityData[tmpIndex].GoToButton = MP.ReadUShort();
      this.CSActivityData[tmpIndex].Marquee = MP.ReadUShort();
      this.CSActivityData[tmpIndex].EventBeginTime = MP.ReadLong();
      this.CSActivityData[tmpIndex].EventEndTime = MP.ReadLong();
      if (this.CSActivityData[tmpIndex].EventBeginTime == 0L)
        this.CSActivityData[tmpIndex].Initial();
      this.CheckActivity(0, tmpIndex, this.CSActivityData[tmpIndex].EventBeginTime);
    }
  }

  public void SetSPData(MessagePacket MP, int tmpIndex = -1)
  {
    if (tmpIndex == -1)
    {
      for (int index = 0; index < 5; ++index)
      {
        this.SPActivityData[index].Initial();
        this.SPActivityData[index].DetailPic = MP.ReadUShort();
        this.SPActivityData[index].HeadStr = MP.ReadUShort();
        this.SPActivityData[index].DetailStr = MP.ReadUShort();
        this.SPActivityData[index].GoToButton = MP.ReadUShort();
        this.SPActivityData[index].Marquee = MP.ReadUShort();
        this.SPActivityData[index].EventBeginTime = MP.ReadLong();
        this.SPActivityData[index].EventEndTime = MP.ReadLong();
        if (this.SPActivityData[index].EventBeginTime == 0L)
          this.SPActivityData[index].Initial();
        this.CheckActivity(1, index, this.SPActivityData[index].EventBeginTime);
        this.CheckShowSPMessage(index);
      }
    }
    else
    {
      if (tmpIndex >= 5)
        return;
      this.SPActivityData[tmpIndex].Initial();
      this.SPActivityData[tmpIndex].DetailPic = MP.ReadUShort();
      this.SPActivityData[tmpIndex].HeadStr = MP.ReadUShort();
      this.SPActivityData[tmpIndex].DetailStr = MP.ReadUShort();
      this.SPActivityData[tmpIndex].GoToButton = MP.ReadUShort();
      this.SPActivityData[tmpIndex].Marquee = MP.ReadUShort();
      this.SPActivityData[tmpIndex].EventBeginTime = MP.ReadLong();
      this.SPActivityData[tmpIndex].EventEndTime = MP.ReadLong();
      if (this.SPActivityData[tmpIndex].EventBeginTime == 0L)
        this.SPActivityData[tmpIndex].Initial();
      this.CheckActivity(1, tmpIndex, this.SPActivityData[tmpIndex].EventBeginTime);
      this.CheckShowSPMessage(tmpIndex);
    }
  }

  public void CheckMonster(MessagePacket MP, bool bSolo = true)
  {
    if (!bSolo)
    {
      for (int index = 0; index < 5; ++index)
      {
        int num = (int) MP.ReadUShort();
      }
    }
    else
    {
      this.MonsterCount = (byte) 0;
      for (int index = 0; index < 5; ++index)
      {
        this.Monster[index] = MP.ReadUShort();
        if (this.Monster[index] != (ushort) 0)
        {
          ++this.MonsterCount;
          MapMonster recordByKey1 = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.Monster[index]);
          CString cstring = StringManager.Instance.SpawnString(128);
          cstring.ClearString();
          cstring.IntToFormat((long) recordByKey1.MapNPCNO, 3);
          cstring.AppendFormat("UI/NPC_{0}");
          AssetManager.GetAssetBundleDownload(cstring, AssetPath.UI, AssetType.NPC, this.Monster[index]);
          Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(recordByKey1.ModelID);
          cstring.ClearString();
          cstring.IntToFormat((long) recordByKey2.Graph);
          cstring.AppendFormat("UI/MapNPCHead_{0}");
          if (recordByKey2.Graph > (ushort) 0)
            AssetManager.GetAssetBundleDownload(cstring, AssetPath.UI, AssetType.NPCHead, recordByKey2.Graph);
          cstring.ClearString();
          cstring.IntToFormat((long) recordByKey2.Modle, 5);
          cstring.AppendFormat("Role/hero_{0}");
          if (recordByKey2.Modle > (ushort) 0)
            AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.Hero, recordByKey2.Modle);
          if (recordByKey1.SoundPackNO != (ushort) 0)
          {
            cstring.ClearString();
            cstring.IntToFormat((long) recordByKey1.SoundPackNO, 3);
            cstring.AppendFormat("Role/{0}");
            AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.HeroSFX, recordByKey1.SoundPackNO);
          }
          if (recordByKey1.ParticlePackNO != (ushort) 0)
          {
            cstring.ClearString();
            cstring.IntToFormat((long) recordByKey1.ParticlePackNO, 3);
            cstring.AppendFormat("Particle/Monster_Effects_{0}");
            AssetManager.GetAssetBundleDownload(cstring, AssetPath.Particle, AssetType.Effects, recordByKey1.ParticlePackNO);
          }
          StringManager.Instance.DeSpawnString(cstring);
        }
        else
          this.MonsterType[index] = (ushort) 0;
      }
    }
  }

  public void CheckMonsterType(MessagePacket MP, bool bSolo = true)
  {
    if (!bSolo)
    {
      for (int index = 0; index < 5; ++index)
      {
        int num = (int) MP.ReadUShort();
      }
    }
    else
    {
      for (int index = 0; index < 5; ++index)
        this.MonsterType[index] = MP.ReadUShort();
    }
  }

  private void CheckShowNpcMessage()
  {
    if (this.ActivityData[0].EventState != EActivityState.EAS_Run || DataManager.Instance.ServerTime - this.ActivityData[0].EventBeginTime > 600L)
      return;
    for (int index = 0; index < 5; ++index)
    {
      if (this.MonsterType[index] == (ushort) 1 && this.Monster[index] != (ushort) 0)
      {
        uint ID = this.Monster[index] != (ushort) 22 ? (this.Monster[index] != (ushort) 23 ? (this.Monster[index] != (ushort) 24 ? (this.Monster[index] != (ushort) 25 ? (this.Monster[index] != (ushort) 26 ? (this.Monster[index] != (ushort) 14 ? (this.Monster[index] != (ushort) 32 ? (this.Monster[index] != (ushort) 33 ? (this.Monster[index] != (ushort) 34 ? (this.Monster[index] != (ushort) 35 ? 9076U : 9565U) : 9564U) : 9563U) : 9562U) : 9561U) : 9503U) : 9502U) : 9501U) : 9087U) : 9071U;
        if (ID > 0U)
        {
          this.MonstrCStr[index].Length = 0;
          this.MonstrCStr[index].Append(DataManager.Instance.mStringTable.GetStringByID(ID));
          GUIManager.Instance.SetRunningText(this.MonstrCStr[index]);
        }
      }
    }
  }

  private void CheckShowSPMessage(int tmpIndex)
  {
    if (tmpIndex >= 5 || this.SPActivityData[tmpIndex].Marquee <= (ushort) 0 || this.SPActivityData[tmpIndex].EventBeginTime <= 0L || DataManager.Instance.ServerTime - this.SPActivityData[tmpIndex].EventBeginTime > 600L)
      return;
    this.MonstrCStr[tmpIndex].Length = 0;
    this.MonstrCStr[tmpIndex].Append(DataManager.Instance.mStringTable.GetStringByID((uint) this.SPActivityData[tmpIndex].Marquee));
    GUIManager.Instance.SetRunningText(this.MonstrCStr[tmpIndex]);
  }

  public void RecvActNews(MessagePacket MP)
  {
    this.NewsDataLen = MP.ReadByte();
    if (this.NewsDataLen > (byte) 30)
      this.NewsDataLen = (byte) 30;
    for (int index = 0; index < (int) this.NewsDataLen; ++index)
    {
      this.NewsData[index].ID = MP.ReadUInt();
      this.NewsData[index].Time = MP.ReadLong();
    }
    this.CheckNewsNo();
  }

  public void RecvDailyActNews(MessagePacket MP)
  {
    this.RcvDailyActNewsTime = MP.ReadLong();
    this.DailyNewsLen = MP.ReadByte();
    if (this.DailyNewsLen > (byte) 30)
      this.DailyNewsLen = (byte) 30;
    for (int index = 0; index < (int) this.DailyNewsLen; ++index)
      this.DailyNews[index] = MP.ReadUInt();
    this.CheckNewsNo();
  }

  public void SetLastGetDailyGiftTime(long lTime)
  {
    this.SPLastGetDailyGiftTime = lTime;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 23);
  }

  public void RecvRunningText(MessagePacket MP)
  {
    byte index1 = (byte) ((uint) MP.ReadByte() - 1U);
    if (index1 >= (byte) 14)
      return;
    byte index2 = MP.ReadByte();
    switch ((EActivityType) index1)
    {
      case EActivityType.EAT_ComingSoonSpEvent:
        if (index2 >= (byte) 5)
          break;
        this.MarqueeInfoCS[(int) index2].StrID = MP.ReadUShort();
        this.MarqueeInfoCS[(int) index2].BeginTime = MP.ReadLong();
        this.MarqueeInfoCS[(int) index2].RequireTime = MP.ReadUInt();
        this.MarqueeInfoCS[(int) index2].CircleHour = (uint) MP.ReadByte();
        this.MarqueeInfoCS[(int) index2].PlayMin = (uint) MP.ReadUShort();
        this.MarqueeInfoCS[(int) index2].EndTime = this.MarqueeInfoCS[(int) index2].BeginTime + (long) this.MarqueeInfoCS[(int) index2].RequireTime;
        this.MarqueeInfoCS[(int) index2].CircleHour *= 3600U;
        this.MarqueeInfoCS[(int) index2].PlayMin *= 60U;
        this.MarqueeInfoCS[(int) index2].NowTimes = 0L;
        if (this.MarqueeInfoCS[(int) index2].StrID <= (ushort) 0)
          break;
        this.CheckOne(ref this.MarqueeInfoCS[(int) index2]);
        break;
      case EActivityType.EAT_SpecialEvent:
        if (index2 >= (byte) 5)
          break;
        this.MarqueeInfoSP[(int) index2].StrID = MP.ReadUShort();
        this.MarqueeInfoSP[(int) index2].BeginTime = MP.ReadLong();
        this.MarqueeInfoSP[(int) index2].RequireTime = MP.ReadUInt();
        this.MarqueeInfoSP[(int) index2].CircleHour = (uint) MP.ReadByte();
        this.MarqueeInfoSP[(int) index2].PlayMin = (uint) MP.ReadUShort();
        this.MarqueeInfoSP[(int) index2].EndTime = this.MarqueeInfoSP[(int) index2].BeginTime + (long) this.MarqueeInfoSP[(int) index2].RequireTime;
        this.MarqueeInfoSP[(int) index2].CircleHour *= 3600U;
        this.MarqueeInfoSP[(int) index2].PlayMin *= 60U;
        this.MarqueeInfoSP[(int) index2].NowTimes = 0L;
        if (this.MarqueeInfoSP[(int) index2].StrID <= (ushort) 0)
          break;
        this.CheckOne(ref this.MarqueeInfoSP[(int) index2]);
        break;
      default:
        this.MarqueeInfo[(int) index1].StrID = MP.ReadUShort();
        this.MarqueeInfo[(int) index1].BeginTime = MP.ReadLong();
        this.MarqueeInfo[(int) index1].RequireTime = MP.ReadUInt();
        this.MarqueeInfo[(int) index1].CircleHour = (uint) MP.ReadByte();
        this.MarqueeInfo[(int) index1].PlayMin = (uint) MP.ReadUShort();
        this.MarqueeInfo[(int) index1].NowTimes = 0L;
        this.MarqueeInfo[(int) index1].EndTime = this.MarqueeInfo[(int) index1].BeginTime + (long) this.MarqueeInfo[(int) index1].RequireTime;
        this.MarqueeInfo[(int) index1].CircleHour *= 3600U;
        this.MarqueeInfo[(int) index1].PlayMin *= 60U;
        this.MarqueeInfo[(int) index1].NowTimes = 0L;
        if (this.MarqueeInfo[(int) index1].StrID <= (ushort) 0)
          break;
        this.CheckOne(ref this.MarqueeInfo[(int) index1]);
        break;
    }
  }

  private void CheckOne(ref MarqueeInfoDataType tmp)
  {
    long serverTime = DataManager.Instance.ServerTime;
    if (serverTime < tmp.BeginTime || serverTime >= tmp.EndTime)
      return;
    bool flag = false;
    if (tmp.CircleHour == 0U)
    {
      if (tmp.NowTimes == 0L && serverTime - tmp.BeginTime < (long) tmp.PlayMin)
      {
        flag = true;
        tmp.NowTimes = 1L;
      }
    }
    else
    {
      long num1 = serverTime - tmp.BeginTime;
      long num2 = num1 / (long) tmp.CircleHour;
      if (num1 - (long) tmp.CircleHour * num2 < (long) tmp.PlayMin && num2 >= tmp.NowTimes)
      {
        flag = true;
        tmp.NowTimes = num2 + 1L;
      }
    }
    if (!flag)
      return;
    tmp.ActivityStr.Length = 0;
    tmp.ActivityStr.Append(DataManager.Instance.mStringTable.GetStringByID((uint) tmp.StrID));
    GUIManager.Instance.SetRunningText(tmp.ActivityStr);
  }

  private void CheckRunningText()
  {
    for (int index = 0; index < 5; ++index)
    {
      if (this.MarqueeInfoCS[index].StrID > (ushort) 0)
        this.CheckOne(ref this.MarqueeInfoCS[index]);
    }
    for (int index = 0; index < 5; ++index)
    {
      if (this.MarqueeInfoSP[index].StrID > (ushort) 0)
        this.CheckOne(ref this.MarqueeInfoSP[index]);
    }
    for (int index = 0; index < this.MarqueeInfo.Length; ++index)
    {
      if (index != 4 && index != 5 && this.MarqueeInfo[index].StrID > (ushort) 0)
        this.CheckOne(ref this.MarqueeInfo[index]);
    }
  }

  public void RecvSPExtraData(MessagePacket MP)
  {
    byte num1 = (byte) ((uint) MP.ReadByte() - 1U);
    if (num1 >= (byte) 14)
      return;
    byte index1 = MP.ReadByte();
    byte num2 = MP.ReadByte();
    switch ((EActivityType) num1)
    {
      case EActivityType.EAT_ComingSoonSpEvent:
        if (index1 >= (byte) 5)
          break;
        for (int index2 = 0; index2 < (int) num2 && index2 < 4; ++index2)
        {
          this.CSActivityData[(int) index1].ContentTimeData[index2].BeginTime = MP.ReadLong();
          this.CSActivityData[(int) index1].ContentTimeData[index2].RequireTime = MP.ReadUInt();
        }
        break;
      case EActivityType.EAT_SpecialEvent:
        if (index1 >= (byte) 5)
          break;
        for (int index3 = 0; index3 < (int) num2 && index3 < 4; ++index3)
        {
          this.SPActivityData[(int) index1].ContentTimeData[index3].BeginTime = MP.ReadLong();
          this.SPActivityData[(int) index1].ContentTimeData[index3].RequireTime = MP.ReadUInt();
        }
        break;
    }
  }

  public void RecvKvKMatchInfo(MessagePacket MP)
  {
    this.MatchKingdomIDCount = MP.ReadUShort();
    for (int index = 0; index < 6; ++index)
      this.MatchKingdomID[index] = MP.ReadUShort();
    this.MatchKingdomCount = MP.ReadByte();
    this.KVKHuntCircleMin = MP.ReadUShort();
    for (int index1 = 0; index1 < 3; ++index1)
    {
      this.GetHuntFactor[index1] = new ActGetScoreFactorDataType[6];
      for (int index2 = 0; index2 < 6; ++index2)
      {
        this.GetHuntFactor[index1][index2].Factor = (EGetScoreFactor) MP.ReadByte();
        this.GetHuntFactor[index1][index2].BonusRate = MP.ReadByte();
      }
    }
    if (this.MatchKingdomCount == (byte) 4)
    {
      Array.Clear((Array) this.MatchKingdomID_4, 0, this.MatchKingdomID_4.Length);
      for (int index3 = 0; index3 < 4; ++index3)
      {
        if (this.MatchKingdomID[index3] != (ushort) 0 && (int) this.MatchKingdomID[index3] == (int) DataManager.MapDataController.kingdomData.kingdomID)
        {
          int index4 = index3;
          int index5 = 0;
          while (index5 < this.MatchKingdomID_4.Length && index5 < (int) this.MatchKingdomIDCount)
          {
            this.MatchKingdomID_4[index5] = this.MatchKingdomID[index4];
            ++index5;
            ++index4;
            if (index4 >= 4 || this.MatchKingdomID[index4] == (ushort) 0)
              index4 = 0;
          }
          if (this.MatchKingdomIDCount == (ushort) 4)
          {
            ushort num = this.MatchKingdomID_4[2];
            this.MatchKingdomID_4[2] = this.MatchKingdomID_4[3];
            this.MatchKingdomID_4[3] = num;
            break;
          }
          break;
        }
      }
    }
    bool flag = false;
    EActivityState eventState = this.KvKActivityData[4].EventState;
    switch (eventState)
    {
      case EActivityState.EAS_Run:
      case EActivityState.EAS_HomeStart:
      case EActivityState.EAS_HomeEnd:
      case EActivityState.EAS_StartRanking:
        if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_KVK)
        {
          DataManager.MapDataController.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_KVK;
          flag = true;
        }
        if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID && DataManager.MapDataController.kingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_KVK)
        {
          DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_KVK;
          flag = true;
        }
        if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.FocusKingdomID)
        {
          if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_KVK)
          {
            DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_KVK;
            flag = true;
          }
        }
        else if (this.IsMatchKvk())
        {
          for (int index = 0; index < this.MatchKingdomID.Length; ++index)
          {
            if (this.MatchKingdomID[index] != (ushort) 0 && (int) this.MatchKingdomID[index] == (int) DataManager.MapDataController.FocusKingdomID)
            {
              if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_KVK)
              {
                DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_KVK;
                flag = true;
                break;
              }
              break;
            }
          }
        }
        if (eventState != EActivityState.EAS_Run)
        {
          DataManager.MapDataController.UpdateKingdomPeriod();
          break;
        }
        break;
      default:
        if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
        {
          if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID)
            DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
          if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.FocusKingdomID)
          {
            DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_WORLD_WAR;
            break;
          }
          if (this.IsMatchKvk())
          {
            for (int index = 0; index < this.MatchKingdomID.Length; ++index)
            {
              if (this.MatchKingdomID[index] != (ushort) 0 && (int) this.MatchKingdomID[index] == (int) DataManager.MapDataController.FocusKingdomID)
              {
                if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_INFIGHTING && DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_WORLD_WAR)
                {
                  DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
                  flag = true;
                  break;
                }
                break;
              }
            }
            break;
          }
          break;
        }
        if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_INFIGHTING)
        {
          DataManager.MapDataController.OtherKingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
          flag = true;
        }
        if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID && DataManager.MapDataController.kingdomData.kingdomPeriod != KINGDOM_PERIOD.KP_INFIGHTING)
        {
          DataManager.MapDataController.kingdomData.kingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
          flag = true;
        }
        if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.FocusKingdomID)
        {
          if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_INFIGHTING)
          {
            DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
            flag = true;
            break;
          }
          break;
        }
        if (this.IsMatchKvk())
        {
          for (int index = 0; index < this.MatchKingdomID.Length; ++index)
          {
            if (this.MatchKingdomID[index] != (ushort) 0 && (int) this.MatchKingdomID[index] == (int) DataManager.MapDataController.FocusKingdomID)
            {
              if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_INFIGHTING)
              {
                DataManager.MapDataController.FocusKingdomPeriod = KINGDOM_PERIOD.KP_INFIGHTING;
                flag = true;
                break;
              }
              break;
            }
          }
          break;
        }
        break;
    }
    if (!flag)
      return;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 25);
    DataManager.msgBuffer[0] = (byte) 53;
    DataManager.msgBuffer[1] = (byte) 1;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void RecvKvKHuntInfo(MessagePacket MP)
  {
    byte num = MP.ReadByte();
    this.KVKReTime = MP.ReadLong();
    if ((int) this.KVKHuntOrder != (int) num)
    {
      this.KVKHuntOrder = num;
      this.reflashKvKKingdomType();
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 25);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 9);
  }

  public void RecvNPCCITY_UPDATEINFO(MessagePacket MP) => this.NPCCityEndTime = MP.ReadLong();

  private void SetAllianceSummonDate()
  {
    if (this.AllianceSummonEventInfoID == (ushort) 0)
      return;
    SummonInfo recordByKey = DataManager.Instance.SummonInfoData.GetRecordByKey(this.AllianceSummonEventInfoID);
    if ((int) recordByKey.ID != (int) this.AllianceSummonEventInfoID)
      return;
    for (int index = 0; index < 3; ++index)
      this.AllianceSummonData.RequireScore[index] = recordByKey.PointData[index].Score;
    for (int index = 0; index < 6 && index < recordByKey.FactorKey.Length; ++index)
    {
      this.AllianceSummonData.GetScoreFactor[index].Factor = (EGetScoreFactor) recordByKey.FactorKey[index];
      if (this.AllianceSummonData.GetScoreFactor[index].Factor != (EGetScoreFactor) 0)
        this.AllianceSummonData.GetScoreFactor[index].BonusRate = (byte) 1;
    }
    this.AllianceSummonData.bAskDetailData = true;
  }

  public void SetAllianceSummon_Score(uint score)
  {
    this.AllianceSummon_Score = score;
    this.AllianceSummonData.EventScore = (ulong) score;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 2, 208);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 1, 208);
    if (this.mAllianceDonation_Score >= score)
      return;
    this.mAllianceDonation_Score = score;
    GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 3);
  }

  public void SetAllianceSummon_NPCCityCombatTimes(byte Index, byte Times)
  {
    if (Index <= (byte) 0 || Index > (byte) 5)
      return;
    ActivityManager.Instance.NPCCityCombatTimes[(int) Index - 1] = Times;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 5, 208);
  }

  public void ClearAllianceSummonData()
  {
    this.AllianceSummon_SummonData.SummonPoint = (byte) 0;
    this.AllianceSummon_SummonData.MonsterID = (ushort) 0;
    this.AllianceSummon_SummonData.MonsterPos.KingdomID = (ushort) 0;
    this.AllianceSummon_SummonData.MonsterPos.CombatPoint.zoneID = (ushort) 0;
    this.AllianceSummon_SummonData.MonsterPos.CombatPoint.pointID = (byte) 0;
    this.AllianceSummon_SummonData.MonsterEndTime = 0L;
    for (int index = 0; index < 5; ++index)
      this.NPCCityCombatTimes[index] = (byte) 0;
  }

  public void Send_FEDERAL_ORDERLIST()
  {
    if (this.NobilityActivityData.bAskDetailData)
    {
      if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
        return;
      this.door.OpenMenu(EGUIWindow.UI_Activity2, 209, bCameraMode: true);
    }
    else if (this.NobilityActivityData.EventState == EActivityState.EAS_None)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107U), (ushort) byte.MaxValue);
    }
    else
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_FEDERAL_ORDERLIST;
      messagePacket.AddSeqId();
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Activity);
    }
  }

  public void Recv_FEDERAL_ORDERLIST(MessagePacket MP)
  {
    byte Count = MP.ReadByte();
    this.NobilityActivityData.InitGroupData(Count);
    for (int index = 0; index < (int) Count; ++index)
    {
      this.NobilityActivityData.NobilityGroupData[index].KingdomID = MP.ReadUShort();
      this.NobilityActivityData.NobilityGroupData[index].WonderID = MP.ReadByte();
      this.NobilityActivityData.NobilityGroupData[index].EventState = (EActivityState) MP.ReadByte();
      this.NobilityActivityData.NobilityGroupData[index].EventBeginTime = MP.ReadLong();
      this.NobilityActivityData.NobilityGroupData[index].EventRequireTime = MP.ReadUInt();
      this.NobilityActivityData.NobilityGroupDataIndex[(int) this.NobilityActivityData.NobilityGroupData[index].WonderID] = (byte) index;
    }
    this.NobilityActivityData.SetGroupEventTime();
    this.NobilityActivityData.NobilityGroupDataSortIndex.Sort((IComparer<byte>) this.NW_Comparer);
    this.NobilityActivityData.bAskDetailData = true;
    if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
    {
      if (this.bReOpen)
      {
        if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity2))
          this.door.CloseMenu();
        this.bReOpen = false;
      }
      this.door.OpenMenu(EGUIWindow.UI_Activity2, 209, bCameraMode: true);
    }
    GUIManager.Instance.HideUILock(EUILock.Activity);
  }

  public void Send_FEDERAL_ORDERDETAIL(byte WonderID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_FEDERAL_ORDERDETAIL;
    messagePacket.AddSeqId();
    messagePacket.Add(WonderID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Activity);
  }

  public void Recv_FEDERAL_ORDERDETAIL(MessagePacket MP)
  {
    byte index1 = this.NobilityActivityData.NobilityGroupDataIndex[(int) MP.ReadByte()];
    switch ((EActivityState) MP.ReadByte())
    {
      case EActivityState.EAS_Run:
        for (int index2 = 0; index2 < 3; ++index2)
        {
          for (int index3 = 0; index3 < 3; ++index3)
          {
            this.NobilityActivityData.NobilityGroupData[(int) index1].PreparePrize[index2][index3].Rank = MP.ReadByte();
            this.NobilityActivityData.NobilityGroupData[(int) index1].PreparePrize[index2][index3].ItemID = MP.ReadUShort();
            this.NobilityActivityData.NobilityGroupData[(int) index1].PreparePrize[index2][index3].Num = MP.ReadByte();
          }
        }
        byte length = MP.ReadByte();
        this.NobilityActivityData.NobilityGroupData[(int) index1].FightKingdomCount = length;
        this.NobilityActivityData.NobilityGroupData[(int) index1].FightKingdomID = new ushort[(int) length];
        for (int index4 = 0; index4 < (int) length; ++index4)
          this.NobilityActivityData.NobilityGroupData[(int) index1].FightKingdomID[index4] = MP.ReadUShort();
        this.NobilityActivityData.NobilityGroupData[(int) index1].bAskPrizeData = true;
        this.NobilityActivityData.NobilityGroupData[(int) index1].bAskKingdomData = true;
        break;
      case EActivityState.EAS_Prepare:
        for (int index5 = 0; index5 < 3; ++index5)
        {
          for (int index6 = 0; index6 < 3; ++index6)
          {
            this.NobilityActivityData.NobilityGroupData[(int) index1].PreparePrize[index5][index6].Rank = MP.ReadByte();
            this.NobilityActivityData.NobilityGroupData[(int) index1].PreparePrize[index5][index6].ItemID = MP.ReadUShort();
            this.NobilityActivityData.NobilityGroupData[(int) index1].PreparePrize[index5][index6].Num = MP.ReadByte();
          }
        }
        this.NobilityActivityData.NobilityGroupData[(int) index1].bAskPrizeData = true;
        break;
      default:
        this.NobilityActivityData.NobilityGroupData[(int) index1].NobilityKingdomID = MP.ReadUShort();
        CString outString1 = StringManager.Instance.StaticString1024();
        CString outString2 = StringManager.Instance.StaticString1024();
        MP.ReadStringPlus(3, outString1);
        MP.ReadStringPlus(13, outString2);
        this.NobilityActivityData.NobilityGroupData[(int) index1].NobilityName.Length = 0;
        this.NobilityActivityData.NobilityGroupData[(int) index1].NobilityName.Append(outString2);
        this.NobilityActivityData.NobilityGroupData[(int) index1].NobilityHeroID = MP.ReadUShort();
        this.NobilityActivityData.NobilityGroupData[(int) index1].bAskNobilityData = true;
        break;
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 7, 209);
    GUIManager.Instance.HideUILock(EUILock.Activity);
  }

  public void Recv_FEDERAL_UPDATE_ORDERLIST(MessagePacket MP)
  {
    MP.ReadUShort();
    byte index1 = MP.ReadByte();
    EActivityState eactivityState = (EActivityState) MP.ReadByte();
    long num1 = MP.ReadLong();
    uint num2 = MP.ReadUInt();
    bool flag = (int) index1 == (int) this.FederalActKingdomWonderID;
    switch (eactivityState)
    {
      case EActivityState.EAS_Run:
        this.FederalFightingWonderID = index1;
        this.FederalFullEventTimeWonderID = index1;
        break;
      case EActivityState.EAS_ReplayRanking:
        this.FederalFightingWonderID = (byte) 0;
        break;
    }
    if (this.NobilityActivityData.GroupCount > (byte) 0)
    {
      byte index2 = this.NobilityActivityData.NobilityGroupDataIndex[(int) index1];
      this.NobilityActivityData.NobilityGroupData[(int) index2].EventState = eactivityState;
      this.NobilityActivityData.NobilityGroupData[(int) index2].EventBeginTime = num1;
      this.NobilityActivityData.NobilityGroupData[(int) index2].EventRequireTime = num2;
      if (eactivityState == EActivityState.EAS_ReplayRanking)
        this.NobilityActivityData.NobilityGroupData[(int) index2].bAskNobilityData = MP.ReadByte() == (byte) 0;
      this.NobilityActivityData.NobilityGroupDataSortIndex.Sort((IComparer<byte>) this.NW_Comparer);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 6, 209);
    }
    this.CheckNWActivityTime();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_MiniMap, 1);
  }

  public void Recv_FEDERAL_ORDERKINGDOMS(MessagePacket MP)
  {
    if (!(bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_WonderLand))
      return;
    DukeNukem.FederalOrderKingdom(MP);
  }

  public void Recv_FEDERAL_RESETEVENT(MessagePacket MP)
  {
    long num1 = MP.ReadLong();
    uint num2 = MP.ReadUInt();
    this.NobilityActivityData.EventBeginTime = num1;
    this.NobilityActivityData.EventReqiureTIme = num2;
    this.NobilityActivityData.bAskDetailData = false;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity2, 8, 209);
  }

  public void Send_REQUEST_ALLIANCEWAR_RANKPRIZE()
  {
    if (this.AllianceWarData.bAskRankPrize)
    {
      if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
        return;
      this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, 210);
    }
    else
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_RANKPRIZE;
      messagePacket.AddSeqId();
      messagePacket.Add(this.AW_Rank);
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Activity);
    }
  }

  public void Recv_RESP_ALLIANCEWAR_RANKPRIZE(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Activity);
    if (MP.ReadByte() != (byte) 0)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107U), (ushort) byte.MaxValue);
    }
    else
    {
      int num = 0;
      for (int index = 0; index < 7 && index < 5; ++index)
      {
        this.AllianceWarData.RankingPrizeDataLen[index] = (byte) 4;
        num += (int) this.AllianceWarData.RankingPrizeDataLen[index];
      }
      for (int index = 0; index < num; ++index)
      {
        this.AllianceWarData.RankingPrize[index].Rank = MP.ReadByte();
        this.AllianceWarData.RankingPrize[index].ItemID = MP.ReadUShort();
        this.AllianceWarData.RankingPrize[index].Num = MP.ReadByte();
      }
      this.AllianceWarData.bAskRankPrize = true;
      if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
        return;
      if (this.bReOpenPrize)
      {
        if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Activity4))
          this.door.CloseMenu();
        this.bReOpenPrize = false;
      }
      this.door.OpenMenu(EGUIWindow.UI_Activity4, 2, 210);
    }
  }

  public void ClearAllianceWarData()
  {
    this.AW_EventBeginTime = this.AllianceWarData.EventBeginTime;
    UIAllianceWar_Rank.isDataReady = false;
    this.AW_NextRank = (byte) 0;
    this.AW_MinRank = (byte) 1;
    this.AW_MaxRank = (byte) 5;
    LeaderBoardManager.Instance.AllianceWarGroupBoardUpdateTime = 0L;
    LeaderBoardManager.Instance.AllianceWarAlliBoardUpdateTime = 0L;
    this.AW_bcalculateEnd = false;
  }

  public void ClearAWPara()
  {
    this.AW_SignUpAllianceID = 0U;
    this.AW_GetGift = (byte) 0;
    this.AW_PrepareTime = (ushort) 0;
    this.AW_FightTime = (byte) 0;
    this.AW_WaitTime = (ushort) 0;
    this.AW_State = EAllianceWarState.EAWS_None;
    this.AW_Round = (byte) 0;
    this.AW_RoundBeginTime = 0L;
    this.AW_RoundEndTime = 0L;
    this.AllianceWarMgr.Clear();
  }

  public void SetNowState(bool bNeedUpDate = true)
  {
    this.AW_StateOld = this.AW_State;
    if (this.AllianceWarData.EventState == EActivityState.EAS_Prepare)
    {
      this.AW_Round = (byte) 0;
      this.AW_RoundBeginTime = 0L;
      this.AW_RoundEndTime = 0L;
      this.AW_State = EAllianceWarState.EAWS_SignUp;
    }
    else if (this.AllianceWarData.EventState == EActivityState.EAS_Run)
      this.AW_State = EAllianceWarState.EAWS_Prepare;
    else if (this.AllianceWarData.EventState == EActivityState.EAS_ReplayRanking)
    {
      if (DataManager.Instance.RoleAlliance.Id == 0U)
      {
        this.AW_State = EAllianceWarState.EAWS_Replay;
      }
      else
      {
        if (this.AW_OneRoundTime == 0U)
        {
          this.AW_State = EAllianceWarState.EAWS_Run;
          return;
        }
        byte awRound = this.AW_Round;
        long num1 = this.ServerEventTime - this.AllianceWarData.EventBeginTime;
        if (num1 < 0L)
          return;
        long num2 = num1 / (long) this.AW_OneRoundTime + 1L;
        if (num2 <= 0L || num2 > 4L)
        {
          this.AW_Round = (byte) 0;
          this.AW_RoundBeginTime = 0L;
          this.AW_RoundEndTime = 0L;
          this.AW_State = EAllianceWarState.EAWS_Replay;
        }
        else
        {
          this.AW_Round = (byte) num2;
          this.AW_RoundBeginTime = this.AllianceWarData.EventBeginTime + (long) ((int) this.AW_Round - 1) * (long) this.AW_OneRoundTime;
          this.AW_RoundEndTime = this.AW_RoundBeginTime + (long) this.AW_OneRoundTime;
          this.AW_State = EAllianceWarState.EAWS_Run;
        }
        if ((int) awRound != (int) this.AW_Round)
        {
          GameManager.OnRefresh(NetworkNews.Refresh_AllianceWarRound, DataManager.msgBuffer);
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 17);
        }
      }
    }
    else
    {
      this.ClearAWPara();
      this.ClearAllianceWarData();
    }
    if (!bNeedUpDate || this.AW_StateOld == this.AW_State)
      return;
    this.CheckAWShowHint();
    if (!this.OpenNextStateUI())
      GameManager.OnRefresh(NetworkNews.Refresh_AllianceWarState, DataManager.msgBuffer);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Activity1, 17);
  }

  public void OpenAllianceWarDetail()
  {
    byte num = 0;
    if (DataManager.Instance.RoleAlliance.Id == 0U || this.AW_NowAllianceEnterWar == (byte) 0)
    {
      num = this.AW_State != EAllianceWarState.EAWS_Replay ? (byte) 1 : (byte) 3;
    }
    else
    {
      if (this.AW_OneRoundTime == 0U)
      {
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8459U), (ushort) byte.MaxValue);
        return;
      }
      if (this.AW_State == EAllianceWarState.EAWS_SignUp || this.AW_State == EAllianceWarState.EAWS_Prepare)
        num = (byte) 1;
      else if (this.AW_State == EAllianceWarState.EAWS_Run)
        num = (byte) 2;
      else if (this.AW_State == EAllianceWarState.EAWS_Replay)
        num = (byte) 3;
    }
    switch (num)
    {
      case 1:
        this.AllianceWarReopenCheck();
        this.door.OpenMenu(EGUIWindow.UI_AllianceWarRegister);
        break;
      case 2:
        this.Send_ALLIANCEWAR_REPLAY();
        break;
      case 3:
        UIAllianceWar_Rank.OpenUI();
        break;
    }
  }

  public void UpDateAllianceWarTop()
  {
    if (!((UnityEngine.Object) GUIManager.Instance.m_ActivityWindow != (UnityEngine.Object) null))
      return;
    GUIManager.Instance.m_ActivityWindow.RefreshTop();
  }

  public void SetActivityWindowTimeVisible(bool bVisible)
  {
    if (!((UnityEngine.Object) GUIManager.Instance.m_ActivityWindow != (UnityEngine.Object) null))
      return;
    GUIManager.Instance.m_ActivityWindow.SetTopTimeVivsible(bVisible);
  }

  public bool OpenNextStateUI()
  {
    if ((!(bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarRegister) || this.AW_State < EAllianceWarState.EAWS_Run) && (!(bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarOver) || this.AW_State < EAllianceWarState.EAWS_Replay))
      return false;
    this.AllianceWarSendReOpenMenu();
    return true;
  }

  public void AllianceWarSendReOpenMenu()
  {
    this.AW_bWaitOpenNext = true;
    this.OpenAllianceWarDetail();
  }

  public void AllianceWarReopenCheck()
  {
    if (!this.AW_bWaitOpenNext)
      return;
    if ((UnityEngine.Object) this.door != (UnityEngine.Object) null && ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarRegister) || (bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWar_Rank) || (bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarOver) || (bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarBattle)))
      this.door.CloseMenu();
    this.AW_bWaitOpenNext = false;
  }

  public void Send_ACTIVITY_AS_DONATE_BOARD()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AS_DONATE_BOARD;
    messagePacket.AddSeqId();
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.UIDonation);
  }

  public void Recv_Alliance_Donate(MessagePacket MP)
  {
    for (int index = 0; index < 4; ++index)
    {
      this.mAllianceDonationData[index].itemRank = MP.ReadByte();
      this.mAllianceDonationData[index].itemID = MP.ReadUShort();
      this.mAllianceDonationData[index].RequireIdx = MP.ReadUShort();
    }
    this.mAllianceDonation_EndTime = MP.ReadLong();
    this.mAllianceDonation_RandomSeed = MP.ReadUShort();
    this.mAllianceDonation_Gap = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
    {
      this.mAllianceDonationData[index].DonateNumber = MP.ReadUShort();
      byte num1 = MP.ReadByte();
      if (num1 == (byte) 0)
      {
        this.mAllianceDonationData[index].Multiple = (byte) 1;
      }
      else
      {
        byte num2 = (byte) Mathf.Clamp((int) num1, 1, 9);
        this.mAllianceDonationData[index].Multiple = num2;
      }
    }
    byte num = MP.ReadByte();
    this.mDonateChanceData.Clear();
    for (int index = 0; index < (int) num; ++index)
      this.mDonateChanceData.Add(MP.ReadUShort());
    GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1);
    GUIManager.Instance.HideUILock(EUILock.UIDonation);
  }

  public void Send_ACTIVITY_AS_DONATE_DATA(ushort startTotalDonate, byte Len, byte[] DonateData)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AS_DONATE_DATA;
    messagePacket.AddSeqId();
    messagePacket.Add(startTotalDonate);
    messagePacket.Add(Len);
    messagePacket.Add(DonateData);
    messagePacket.Send();
    ++this.mSendAddCount;
  }

  public void Recv_Alliance_Donate_Data(MessagePacket MP)
  {
    byte x = MP.ReadByte();
    this.mPointIncreased = MP.ReadUInt();
    switch (x)
    {
      case 0:
        this.mAllianceDonation_Score = MP.ReadUInt();
        break;
      case 1:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14548U), (ushort) byte.MaxValue);
        this.mAllianceDonation_Score = this.AllianceSummon_Score;
        int num1 = (int) MP.ReadUInt();
        break;
    }
    if (x < (byte) 2)
    {
      for (int index = 0; index < 4; ++index)
      {
        this.mAllianceDonationData[index].DonateNumber = MP.ReadUShort();
        byte num2 = MP.ReadByte();
        if (num2 == (byte) 0)
        {
          this.mAllianceDonationData[index].Multiple = (byte) 1;
        }
        else
        {
          byte num3 = (byte) Mathf.Clamp((int) num2, 1, 9);
          this.mAllianceDonationData[index].Multiple = num3;
        }
      }
      byte num4 = 0;
      for (int index = 0; index < 4; ++index)
      {
        ushort num5 = MP.ReadUShort();
        num4 = MP.ReadByte();
        ushort Quantity = MP.ReadUShort();
        if ((int) num5 == (int) this.mAllianceDonationData[index].itemID)
          DataManager.Instance.SetCurItemQuantity(this.mAllianceDonationData[index].itemID, Quantity, this.mAllianceDonationData[index].itemRank, 0L);
      }
      GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 2, (int) x);
      GameManager.OnRefresh(NetworkNews.Refresh_Item);
    }
    else if (x != (byte) 2)
    {
      GUIManager.Instance.MsgStr.ClearString();
      GUIManager.Instance.MsgStr.IntToFormat((long) x);
      GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(14555U));
      GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), (ushort) byte.MaxValue);
    }
    if (x < (byte) 3)
      --this.mSendAddCount;
    if (this.mSendAddCount < (ushort) 0)
      this.mSendAddCount = (ushort) 0;
    if (this.mSendAddCount != (ushort) 0)
      return;
    GUIManager.Instance.HideUILock(EUILock.UIDonation);
  }

  public void Recv_Alliancesummon_DonateBoardChange(MessagePacket MP)
  {
    this.mAllianceDonation_EndTime = MP.ReadLong();
    if (MP.ReadByte() == (byte) 1 || DataManager.Instance.RoleAlliance.Id == 0U || this.AllianceSummonAllianceID == 0U || (int) DataManager.Instance.RoleAlliance.Id != (int) this.AllianceSummonAllianceID)
      return;
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14550U), (ushort) byte.MaxValue);
    GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 4);
  }

  public void Send_ACTIVITY_REQUEST_FEDERAL_PRIZE(byte WonderID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_FEDERAL_PRIZE;
    messagePacket.AddSeqId();
    messagePacket.Add(WonderID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.WonderReward);
  }

  public void Recv_ACTIVITY_MSG_RESP_FEDERAL_PRIZE(MessagePacket MP)
  {
    if (MP.ReadByte() == (byte) 0)
    {
      this.RewardWonderID = MP.ReadByte();
      for (int index = 0; index < 9; ++index)
      {
        this.RewardRankingPrize[index].Rank = MP.ReadByte();
        this.RewardRankingPrize[index].ItemID = MP.ReadUShort();
        this.RewardRankingPrize[index].Num = MP.ReadByte();
      }
      if ((UnityEngine.Object) this.door != (UnityEngine.Object) null)
        this.door.OpenMenu(EGUIWindow.UI_WonderReward, 1, (int) this.RewardWonderID);
    }
    else
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(11155U), (ushort) byte.MaxValue);
    GUIManager.Instance.HideUILock(EUILock.WonderReward);
  }

  public void Recv_RESP_FEDERAL_KINGKINGDOMS(MessagePacket MP)
  {
    Array.Clear((Array) this.NobilityKingdomID, 0, this.NobilityKingdomID.Length);
    this.NobilityKingdomNum = (byte) 0;
    this.NobilityKingdomNum = MP.ReadByte();
    for (int index = 0; index < this.NobilityKingdomID.Length && index < (int) this.NobilityKingdomNum; ++index)
      this.NobilityKingdomID[index] = MP.ReadUShort();
  }

  public bool CheckCanonizationNoility(ushort kingdomID)
  {
    if (kingdomID > (ushort) 0)
    {
      for (int index = 0; index < (int) this.NobilityKingdomNum && index < this.NobilityKingdomID.Length; ++index)
      {
        if ((int) this.NobilityKingdomID[index] == (int) kingdomID)
          return true;
      }
    }
    return false;
  }

  public void Send_ALLIANCEWAR_REPLAY()
  {
    if ((bool) (UnityEngine.Object) this.door && AllianceBattle.Check())
    {
      ActivityManager.Instance.AllianceWarReopenCheck();
      if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarBattle))
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarBattle, 4);
      else
        this.door.OpenMenu(EGUIWindow.UI_AllianceWarBattle, bCameraMode: true);
    }
    else
    {
      GUIManager.Instance.ShowUILock(EUILock.Activity);
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_REPLAY;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 1);
      messagePacket.Add(ActivityManager.instance.AW_Round);
      messagePacket.Send();
    }
  }

  public string TransToLocalTime(string Content)
  {
    int num1 = -1;
    int num2 = -1;
    int num3 = -1;
    int num4 = -1;
    int num5 = -1;
    int hours = 0;
    CString str1 = StringManager.Instance.SpawnString();
    CString str2 = StringManager.Instance.SpawnString();
    CString str3 = StringManager.Instance.SpawnString();
    try
    {
      int num6 = 0;
      for (int index1 = 0; index1 < Content.Length; ++index1)
      {
        ++num6;
        if (num6 > Content.Length)
        {
          Debug.Log((object) "TotalCount > Content.Length");
          StringManager.Instance.DeSpawnString(str1);
          StringManager.Instance.DeSpawnString(str2);
          StringManager.Instance.DeSpawnString(str3);
          return Content;
        }
        if (Content[index1] != char.MinValue)
        {
          if (Content[index1] == '[')
            num1 = index1;
          else if (num1 != -1)
          {
            if (num4 == -1 && Content[index1] == '(' && index1 + 1 < Content.Length && Content[index1 + 1] == 'G' && index1 + 2 < Content.Length && Content[index1 + 2] == 'M' && index1 + 3 < Content.Length && Content[index1 + 3] == 'T')
            {
              num4 = index1;
              int index2 = num4;
              int num7 = 0;
              while (index2 < Content.Length && num5 == -1)
              {
                if (Content[index2] == ')')
                  num5 = index2;
                ++index2;
                ++num7;
                if (num7 >= 10)
                {
                  Debug.Log((object) "Not Find GMT End");
                  StringManager.Instance.DeSpawnString(str1);
                  StringManager.Instance.DeSpawnString(str2);
                  StringManager.Instance.DeSpawnString(str3);
                  return Content;
                }
              }
              if (index1 + 4 < Content.Length)
              {
                int index3 = index1 + 4;
                bool flag;
                if (Content[index3] == '+')
                  flag = true;
                else if (Content[index3] == '-')
                {
                  flag = false;
                }
                else
                {
                  Debug.Log((object) "GMT Error");
                  StringManager.Instance.DeSpawnString(str1);
                  StringManager.Instance.DeSpawnString(str2);
                  StringManager.Instance.DeSpawnString(str3);
                  return Content;
                }
                if (index1 + 5 < Content.Length)
                {
                  int index4 = index1 + 5;
                  num7 = 0;
                  char ch = Content[index4];
                  while (ch >= '0' && ch <= '9' && index4 < num5 && num7 < 24)
                  {
                    num7 = num7 * 10 + (int) ch - 48;
                    ++index4;
                    ch = Content[index4];
                    if (ch == '.')
                    {
                      StringManager.Instance.DeSpawnString(str1);
                      StringManager.Instance.DeSpawnString(str2);
                      StringManager.Instance.DeSpawnString(str3);
                      return Content;
                    }
                  }
                }
                hours = !flag ? -num7 : num7;
                index1 = num5;
              }
              else
              {
                Debug.Log((object) ((index1 + 4).ToString() + " > StrLen"));
                StringManager.Instance.DeSpawnString(str1);
                StringManager.Instance.DeSpawnString(str2);
                StringManager.Instance.DeSpawnString(str3);
                return Content;
              }
            }
            else if (Content[index1] == '-' || Content[index1] == '～')
              num2 = index1;
            else if (num1 != -1 && num2 == -1 && num4 == -1)
              str1.Append(Content[index1]);
            else if (num2 != -1 && num4 == -1)
              str2.Append(Content[index1]);
            else if (Content[index1] == ']')
            {
              num3 = index1;
              break;
            }
          }
        }
        else
          break;
      }
      if (num1 == -1 || num3 == -1 || num4 == -1 || num5 == -1)
      {
        if (num1 == -1)
          Debug.Log((object) " Can't Find BeginIndex");
        if (num3 == -1)
          Debug.Log((object) " Can't Find EndIndex");
        if (num4 == -1)
          Debug.Log((object) " Can't Find GMTBegin");
        if (num5 == -1)
          Debug.Log((object) " Can't Find GMTEnd");
        StringManager.Instance.DeSpawnString(str1);
        StringManager.Instance.DeSpawnString(str2);
        StringManager.Instance.DeSpawnString(str3);
        return Content;
      }
      string format;
      switch (DataManager.Instance.UserLanguage)
      {
        case GameLanguage.GL_Cht:
        case GameLanguage.GL_Chs:
        case GameLanguage.GL_Jpn:
          format = "yyyy/MM/dd HH:mm";
          break;
        default:
          format = "MM/dd/yyyy HH:mm";
          break;
      }
      string tmpS1 = (string) null;
      TimeSpan offset = new TimeSpan(hours, 0, 0);
      str1.SetLength(str1.Length);
      DateTime exact1 = DateTime.ParseExact(str1.ToString(), format, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
      str1.SetLength(str1.MaxLength);
      string tmpS2 = new DateTimeOffset(exact1, offset).UtcDateTime.ToLocalTime().ToString(format);
      if (str2.Length > 0)
      {
        str2.SetLength(str2.Length);
        DateTime exact2 = DateTime.ParseExact(str2.ToString(), format, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
        str2.SetLength(str2.MaxLength);
        tmpS1 = new DateTimeOffset(exact2, offset).UtcDateTime.ToLocalTime().ToString(format);
      }
      if (tmpS1 != null)
      {
        str3.StringToFormat(tmpS2);
        str3.StringToFormat(tmpS1);
        str3.AppendFormat("{0} - {1}");
      }
      else
        str3.Append(tmpS2);
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < num1; ++index)
        stringBuilder.Append(Content[index]);
      for (int index = 0; index < str3.Length; ++index)
        stringBuilder.Append(str3[index]);
      for (int index = num3 + 1; index < Content.Length; ++index)
        stringBuilder.Append(Content[index]);
      StringManager.Instance.DeSpawnString(str1);
      StringManager.Instance.DeSpawnString(str2);
      StringManager.Instance.DeSpawnString(str3);
      return stringBuilder.ToString();
    }
    catch
    {
      Debug.Log((object) "ParseExact Error");
      str1.SetLength(str1.MaxLength);
      str2.SetLength(str2.MaxLength);
      StringManager.Instance.DeSpawnString(str1);
      StringManager.Instance.DeSpawnString(str2);
      StringManager.Instance.DeSpawnString(str3);
      return Content;
    }
  }

  public unsafe bool TransToLocalTime(CString Content)
  {
    int num1 = -1;
    int num2 = -1;
    int num3 = -1;
    int num4 = -1;
    int num5 = -1;
    int hours = 0;
    CString str1 = StringManager.Instance.SpawnString();
    CString str2 = StringManager.Instance.SpawnString();
    CString str3 = StringManager.Instance.SpawnString();
    try
    {
      int num6 = 0;
      for (int index1 = 0; index1 < Content.Length; ++index1)
      {
        ++num6;
        if (num6 > Content.Length)
        {
          Debug.Log((object) "TotalCount > Content.Length");
          StringManager.Instance.DeSpawnString(str1);
          StringManager.Instance.DeSpawnString(str2);
          StringManager.Instance.DeSpawnString(str3);
          return false;
        }
        if (Content[index1] != char.MinValue)
        {
          if (Content[index1] == '[')
            num1 = index1;
          else if (num1 != -1)
          {
            if (num4 == -1 && Content[index1] == '(' && index1 + 1 < Content.Length && Content[index1 + 1] == 'G' && index1 + 2 < Content.Length && Content[index1 + 2] == 'M' && index1 + 3 < Content.Length && Content[index1 + 3] == 'T')
            {
              num4 = index1;
              int index2 = num4;
              int num7 = 0;
              while (index2 < Content.Length && num5 == -1)
              {
                if (Content[index2] == ')')
                  num5 = index2;
                ++index2;
                ++num7;
                if (num7 >= 10)
                {
                  Debug.Log((object) "Not Find GMT End");
                  StringManager.Instance.DeSpawnString(str1);
                  StringManager.Instance.DeSpawnString(str2);
                  StringManager.Instance.DeSpawnString(str3);
                  return false;
                }
              }
              if (index1 + 4 < Content.Length)
              {
                int index3 = index1 + 4;
                bool flag;
                if (Content[index3] == '+')
                  flag = true;
                else if (Content[index3] == '-')
                {
                  flag = false;
                }
                else
                {
                  Debug.Log((object) "GMT Error");
                  StringManager.Instance.DeSpawnString(str1);
                  StringManager.Instance.DeSpawnString(str2);
                  StringManager.Instance.DeSpawnString(str3);
                  return false;
                }
                if (index1 + 5 < Content.Length)
                {
                  int index4 = index1 + 5;
                  num7 = 0;
                  char ch = Content[index4];
                  while (ch >= '0' && ch <= '9' && index4 < num5 && num7 < 24)
                  {
                    num7 = num7 * 10 + (int) ch - 48;
                    ++index4;
                    ch = Content[index4];
                    if (ch == '.')
                    {
                      StringManager.Instance.DeSpawnString(str1);
                      StringManager.Instance.DeSpawnString(str2);
                      StringManager.Instance.DeSpawnString(str3);
                      return false;
                    }
                  }
                }
                hours = !flag ? -num7 : num7;
                index1 = num5;
              }
              else
              {
                Debug.Log((object) ((index1 + 4).ToString() + " > StrLen"));
                StringManager.Instance.DeSpawnString(str1);
                StringManager.Instance.DeSpawnString(str2);
                StringManager.Instance.DeSpawnString(str3);
                return false;
              }
            }
            else if (Content[index1] == '-' || Content[index1] == '～')
              num2 = index1;
            else if (num1 != -1 && num2 == -1 && num4 == -1)
              str1.Append(Content[index1]);
            else if (num2 != -1 && num4 == -1)
              str2.Append(Content[index1]);
            else if (Content[index1] == ']')
            {
              num3 = index1;
              break;
            }
          }
        }
        else
          break;
      }
      if (num1 == -1 || num3 == -1 || num4 == -1 || num5 == -1)
      {
        if (num1 == -1)
          Debug.Log((object) " Can't Find BeginIndex");
        if (num3 == -1)
          Debug.Log((object) " Can't Find EndIndex");
        if (num4 == -1)
          Debug.Log((object) " Can't Find GMTBegin");
        if (num5 == -1)
          Debug.Log((object) " Can't Find GMTEnd");
        StringManager.Instance.DeSpawnString(str1);
        StringManager.Instance.DeSpawnString(str2);
        StringManager.Instance.DeSpawnString(str3);
        return false;
      }
      string format;
      switch (DataManager.Instance.UserLanguage)
      {
        case GameLanguage.GL_Cht:
        case GameLanguage.GL_Chs:
        case GameLanguage.GL_Jpn:
          format = "yyyy/MM/dd HH:mm";
          break;
        default:
          format = "MM/dd/yyyy HH:mm";
          break;
      }
      string tmpS1 = (string) null;
      TimeSpan offset = new TimeSpan(hours, 0, 0);
      str1.SetLength(str1.Length);
      DateTime exact1 = DateTime.ParseExact(str1.ToString(), format, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
      str1.SetLength(str1.MaxLength);
      string tmpS2 = new DateTimeOffset(exact1, offset).UtcDateTime.ToLocalTime().ToString(format);
      if (str2.Length > 0)
      {
        str2.SetLength(str2.Length);
        DateTime exact2 = DateTime.ParseExact(str2.ToString(), format, (IFormatProvider) CultureInfo.InvariantCulture, DateTimeStyles.AllowWhiteSpaces);
        str2.SetLength(str2.MaxLength);
        tmpS1 = new DateTimeOffset(exact2, offset).UtcDateTime.ToLocalTime().ToString(format);
      }
      if (tmpS1 != null)
      {
        str3.StringToFormat(tmpS2);
        str3.StringToFormat(tmpS1);
        str3.AppendFormat("{0} - {1}");
      }
      else
        str3.Append(tmpS2);
      string str4 = Content.ToString();
      char* chPtr = (char*) ((IntPtr) str4 + RuntimeHelpers.OffsetToStringData);
      int index5 = num1;
      for (int index6 = 0; index5 < Content.MaxLength && index6 < str3.Length; ++index6)
      {
        chPtr[index5] = str3[index6];
        ++index5;
      }
      for (int index7 = num3 + 1; index5 < Content.MaxLength && index7 < Content.Length; ++index7)
      {
        chPtr[index5] = Content[index7];
        ++index5;
      }
      if (index5 < Content.MaxLength)
      {
        Content.Length = index5;
        chPtr[index5] = char.MinValue;
      }
      else
      {
        Content.Length = Content.MaxLength - 1;
        chPtr[Content.MaxLength - 1] = char.MinValue;
      }
      str4 = (string) null;
      StringManager.Instance.DeSpawnString(str1);
      StringManager.Instance.DeSpawnString(str2);
      StringManager.Instance.DeSpawnString(str3);
      return true;
    }
    catch
    {
      Debug.Log((object) "ParseExact Error");
      str1.SetLength(str1.MaxLength);
      str2.SetLength(str2.MaxLength);
      StringManager.Instance.DeSpawnString(str1);
      StringManager.Instance.DeSpawnString(str2);
      StringManager.Instance.DeSpawnString(str3);
      return false;
    }
  }
}
