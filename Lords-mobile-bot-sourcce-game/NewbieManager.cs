// Decompiled with JetBrains decompiler
// Type: NewbieManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
public class NewbieManager
{
  public const uint WAR_STOP_POINT = 140;
  public const uint BATTLE_STOP_POINT = 150;
  public const ushort RENAME_ITEMID = 1006;
  public const ushort NON_RENAME_STRID = 8055;
  public const ushort PUTON_ITEMID = 1;
  public const int MAX_TEACH_COUNT = 38;
  public const ulong DEFAULT_TEACH = 274877906943;
  public const long WORLD_TEACH_INTERVAL = 300;
  private DataManager DM;
  private static readonly string NEWBIE_SAVE_NAME = "Newbie{0}";
  private int Step;
  public int SubStep;
  private string SaveName = string.Empty;
  private int TeachStep;
  private NewbieController Controller;
  private NewbieManager.ActiveStep pAction;
  private Dictionary<int, NewbieManager.NewbieNode> ActionMap = new Dictionary<int, NewbieManager.NewbieNode>();
  private object Target;
  private bool bRunAction;
  private float ActionDelay;
  public EGUIWindow NextUI = EGUIWindow.MAX;
  public int NextUIArg1;
  public int UIOperator;
  public object NextUIObj;
  private Dictionary<int, NewbieManager.ActiveStep> ClickActionMap = new Dictionary<int, NewbieManager.ActiveStep>();
  public ulong TeachFlag;
  public int WorkingKey;
  private GameObject NewbieRoot;
  private bool bFlagDirty;
  private bool bFlagDirty2;
  private bool bFlagDirty3;
  private bool bFlagDirty_Blackmarket;
  private bool bFlagDirty_TroopMemory;
  private bool bFlagDirty_DeShield;
  private bool bFlagDirty_Coord;
  private bool bFlagDirty_Metallurgy;
  private bool bFlagDirty_Gamble2;
  private bool bFlagDirty_DareFull;
  private bool bFlagDirty_DareLead;
  private bool bFlagDirty_SpawnSoldierDetail;
  private bool bFlagDirty_TreasBoxUpgrade;
  private bool bFlagDirty_SpawnPet;
  private byte SendGuideExFlag;
  public long UserID;
  private bool bIsNewUser = true;
  private ushort CurFakeData;
  private byte FakeBuildLvStep;
  private byte FakeMarkStep;
  private byte FakeBuildStep;
  public static bool bShowRenameMessage = false;
  public static bool bQueuePopMenu = false;
  public bool bOutsideHole;
  public bool bTargeting;
  public bool bUltraWorking;
  public float UltraTimeCache;
  public Vector2 PosCache = Vector2.zero;
  public static Transform pTrans = (Transform) null;
  public uint[] sortHeroDataCache = new uint[DataManager.Instance.MaxCurHeroData];
  public long WorldTeach_Point;
  protected static NewbieManager m_Self = (NewbieManager) null;
  public static long UserIdCache = 0;
  private bool bTimeBarOpen = true;
  public static bool EntryLock = false;
  public static bool AutoBattleFlag = false;
  public static GameObject[] HeroIconCache = new GameObject[6];
  public static int ClickBtnID = 0;
  public static bool BuildCastleImmediate = false;
  public static long NB_SpawnPetTimeCache = 0;
  public static bool bIgnoreGameplayCheck = false;

  protected NewbieManager()
  {
  }

  public NewbieController UIController => this.Controller;

  public static bool HasFlag => !DataManager.Instance.CheckPrizeFlag((byte) 1);

  public static bool IsNewbie => NewbieManager.m_Self != null && NewbieManager.HasFlag;

  public static bool IsTeaching
  {
    get => NewbieManager.m_Self != null && NewbieManager.m_Self.TeachFlag != 0UL;
  }

  public static void CheckNewbieLive()
  {
    if (!DataManager.Instance.CheckPrizeFlag((byte) 6))
      DataManager.Instance.RoleAttr.Guide &= 18446744073709551611UL;
    if (!DataManager.Instance.CheckPrizeFlag((byte) 7))
      DataManager.Instance.RoleAttr.Guide &= 18446744073709289471UL;
    if (!DataManager.Instance.CheckPrizeFlag((byte) 11))
      DataManager.Instance.RoleAttr.Guide &= 18446744073709027327UL;
    if (!DataManager.Instance.CheckPrizeFlag((byte) 12))
      DataManager.Instance.RoleAttr.Guide &= 18446744073708503039UL;
    if (!DataManager.Instance.CheckPrizeFlag((byte) 13))
      DataManager.Instance.RoleAttr.Guide &= 18446744073707454463UL;
    if (!DataManager.Instance.CheckPrizeFlag((byte) 14))
      DataManager.Instance.RoleAttr.Guide &= 18446744073705357311UL;
    if (!DataManager.Instance.CheckPrizeFlag((byte) 15))
      DataManager.Instance.RoleAttr.Guide &= 18446744073692774399UL;
    if (!DataManager.Instance.CheckPrizeFlag((byte) 16))
      DataManager.Instance.RoleAttr.Guide &= 18446744073675997183UL;
    if (!DataManager.Instance.CheckPrizeFlag((byte) 17))
      DataManager.Instance.RoleAttr.Guide &= 18446744073642442751UL;
    if (!DataManager.Instance.CheckPrizeFlag((byte) 18))
      DataManager.Instance.RoleAttr.Guide &= 18446744073575333887UL;
    if (!DataManager.Instance.CheckPrizeFlag((byte) 19))
      DataManager.Instance.RoleAttr.Guide &= 18446744073441116159UL;
    if (!DataManager.Instance.CheckPrizeFlag((byte) 22))
      DataManager.Instance.RoleAttr.Guide &= 18446744073172680703UL;
    if (!DataManager.Instance.CheckPrizeFlag((byte) 23))
      DataManager.Instance.RoleAttr.Guide &= 18446744072635809791UL;
    if (!DataManager.Instance.CheckPrizeFlag((byte) 24))
      DataManager.Instance.RoleAttr.Guide &= 18446744071562067967UL;
    NewbieManager.PreCheckFlag();
    if (DataManager.StageDataController.StageRecord[0] == (ushort) 0)
      DataManager.Instance.RoleAttr.Guide &= 18446744073709551487UL;
    NewbieManager.Create();
  }

  private static bool CheckGuideEx(EGuideFlagEx flag)
  {
    return ((int) DataManager.Instance.RoleAttr.GuideEx & 1 << (int) (flag & (EGuideFlagEx) 31)) != 0;
  }

  private static void PreCheckFlag()
  {
    if (!NewbieManager.CheckGuideEx(EGuideFlagEx.EGFE_PetInfo))
      DataManager.Instance.RoleAttr.Guide &= 18446744069414584319UL;
    if (!NewbieManager.CheckGuideEx(EGuideFlagEx.EGFE_PetFusion))
      DataManager.Instance.RoleAttr.Guide &= 18446744065119617023UL;
    if (!NewbieManager.CheckGuideEx(EGuideFlagEx.EGFE_PetTraining))
      DataManager.Instance.RoleAttr.Guide &= 18446744056529682431UL;
    if (!NewbieManager.CheckGuideEx(EGuideFlagEx.EGFE_PetSkill))
      DataManager.Instance.RoleAttr.Guide &= 18446744039349813247UL;
    if (!NewbieManager.CheckGuideEx(EGuideFlagEx.EGFE_Social_Invite))
      DataManager.Instance.RoleAttr.Guide &= 18446744004990074879UL;
    if (NewbieManager.CheckGuideEx(EGuideFlagEx.EGFE_Social_Invite_After_Mission))
      return;
    DataManager.Instance.RoleAttr.Guide &= 18446743936270598143UL;
  }

  public static void Create()
  {
    if (NewbieManager.m_Self == null)
      NewbieManager.m_Self = new NewbieManager();
    NewbieManager.m_Self.Init();
  }

  public static void Free()
  {
    if (NewbieManager.m_Self == null)
      return;
    NewbieManager.m_Self.Controller.FreeResource();
    UnityEngine.Object.Destroy((UnityEngine.Object) NewbieManager.m_Self.NewbieRoot);
    NewbieManager.m_Self = (NewbieManager) null;
  }

  public static NewbieManager Get() => NewbieManager.m_Self;

  public static void UpdateNetwork(byte[] meg)
  {
    if (NewbieManager.m_Self == null)
      return;
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if (NewbieManager.m_Self.Step < 4 || ((int) DataManager.Instance.RoleAttr.PrizeFlag & 2) != 0)
          break;
        NewbieManager.SendFinishNewbie();
        break;
      case NetworkNews.Refresh_Technology:
        NewbieManager.CheckArmyCoord();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        NewbieManager.m_Self.UIController.RebuildText();
        break;
    }
  }

  protected void Init()
  {
    this.DM = DataManager.Instance;
    this.SaveName = string.Format(NewbieManager.NEWBIE_SAVE_NAME, (object) this.DM.RoleAttr.UserId);
    NewbieManager.EntryLock = false;
    this.bIsNewUser = false;
    if (this.UserID != this.DM.RoleAttr.UserId)
    {
      this.UserID = this.DM.RoleAttr.UserId;
      this.CurFakeData = (ushort) 0;
      this.FakeBuildStep = (byte) 0;
      this.FakeMarkStep = (byte) 0;
      this.FakeBuildLvStep = (byte) 0;
      this.TeachStep = 0;
      NewbieManager.bQueuePopMenu = false;
      this.bIsNewUser = true;
      this.WorldTeach_Point = 0L;
      NewbieManager.NB_SpawnPetTimeCache = 0L;
    }
    if ((UnityEngine.Object) this.Controller == (UnityEngine.Object) null)
    {
      this.NewbieRoot = new GameObject("Newbie");
      RectTransform rectTransform = this.NewbieRoot.AddComponent<RectTransform>();
      rectTransform.anchorMax = Vector2.zero;
      rectTransform.anchorMin = Vector2.zero;
      rectTransform.pivot = Vector2.zero;
      this.NewbieRoot.transform.SetParent((Transform) GUIManager.Instance.m_NewbieLayer, false);
      this.Controller = this.NewbieRoot.AddComponent<NewbieController>();
      this.Controller.pManager = this;
    }
    if (this.bIsNewUser)
      this.Controller.PreClickFlag = 0;
    if (NewbieManager.IsNewbie)
    {
      if (this.bIsNewUser)
      {
        this.Step = PlayerPrefs.GetInt(this.SaveName);
        if (this.Step >= 4)
        {
          this.DM.ResetLocalSave();
          this.Step = 0;
        }
        else
          GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Newbie);
        if (this.Step == 0)
          PlayerPrefs.SetInt(this.SaveName, 1);
        this.LoadTeachFlag();
      }
      if (!DataManager.Instance.MySysSetting.bShowTimeBar)
        DataManager.Instance.MySysSetting.bShowTimeBar = true;
      this.DM.MySysSetting.bShowMission = true;
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
    }
    else
    {
      this.Step = 4;
      if (this.bIsNewUser)
      {
        this.LoadTeachFlag();
        this.LockControl(false);
      }
      else if (NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
      {
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
          menu.ForceQueueBarOpenClose(false);
      }
      else if (NewbieManager.IsTeachWorking(ETeachKind.TURBO))
        DataManager.Instance.MySysSetting.bShowTimeBar = true;
    }
    if (this.ActionMap.Count == 0)
    {
      this.ActionMap.Add(0, new NewbieManager.NewbieNode(2f, new NewbieManager.ActiveStep(this.WaitForIntoScene)));
      this.ActionMap.Add(100, new NewbieManager.NewbieNode(0.5f, new NewbieManager.ActiveStep(this.ShowDrama)));
      this.ActionMap.Add(101, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.FirstIntoDoor)));
      this.ActionMap.Add(102, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.Step1TargetGoal)));
      this.ActionMap.Add(103, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetManor)));
      this.ActionMap.Add(104, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.FirstIntoSuitBuilding)));
      this.ActionMap.Add(105, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.FirstIntoBarrack)));
      this.ActionMap.Add(106, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.ExitBarrackToDoor)));
      this.ActionMap.Add(107, new NewbieManager.NewbieNode(3f, new NewbieManager.ActiveStep(this.WaitBuilding)));
      this.ActionMap.Add(108, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.Step1TargetPrize)));
      this.ActionMap.Add(200, new NewbieManager.NewbieNode(1f, new NewbieManager.ActiveStep(this.IntoUpdateCastle)));
      this.ActionMap.Add(201, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Step2TargetGoal)));
      this.ActionMap.Add(202, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetCastle)));
      this.ActionMap.Add(203, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.IntoUICastle)));
      this.ActionMap.Add(204, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.IntoCastleUpgrade)));
      this.ActionMap.Add(205, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.CastleUpgradeRightNow)));
      this.ActionMap.Add(206, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.IntoLevelUpUI)));
      this.ActionMap.Add(207, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Step2TargetPrize)));
      this.ActionMap.Add(300, new NewbieManager.NewbieNode(1f, new NewbieManager.ActiveStep(this.IntoGetPrize)));
      this.ActionMap.Add(301, new NewbieManager.NewbieNode(1f, new NewbieManager.ActiveStep(this.VipLevelUp)));
      this.ActionMap.Add(302, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.VipLevelUp2)));
      this.ActionMap.Add(303, new NewbieManager.NewbieNode(1f, new NewbieManager.ActiveStep(this.Step3Talk2)));
      this.ActionMap.Add(304, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetPrize)));
      this.ActionMap.Add(1000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.SpawnSoldier)));
      this.ActionMap.Add(1001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetSoldierItem)));
      this.ActionMap.Add(1002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetTrain)));
      this.ActionMap.Add(1003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.FinishTrain)));
      this.ActionMap.Add(1004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.FinishTrain2)));
      this.ActionMap.Add(2000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Into_WarScout)));
      this.ActionMap.Add(2001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.WarScout_TargetCastle)));
      this.ActionMap.Add(2002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetScout)));
      this.ActionMap.Add(2003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetScoutInfo)));
      this.ActionMap.Add(2004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetScoutInfoExit)));
      this.ActionMap.Add(2005, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Into_WarAttack)));
      this.ActionMap.Add(2006, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Team_Select)));
      this.ActionMap.Add(2007, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Soldier_Select)));
      this.ActionMap.Add(2008, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Fight_Select)));
      this.ActionMap.Add(3000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoArena)));
      this.ActionMap.Add(3001, new NewbieManager.NewbieNode(1.2f, new NewbieManager.ActiveStep(this.GoArena2)));
      this.ActionMap.Add(3002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoArena3)));
      this.ActionMap.Add(3003, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GoArena4)));
      this.ActionMap.Add(3004, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GoArena5)));
      this.ActionMap.Add(4000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.IntoCollege)));
      this.ActionMap.Add(4001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetMilitary)));
      this.ActionMap.Add(4002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetTopSkill)));
      this.ActionMap.Add(4003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetTechInfo)));
      this.ActionMap.Add(4004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TechUpgrade)));
      this.ActionMap.Add(4005, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TechFinish)));
      this.ActionMap.Add(5000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Rename)));
      this.ActionMap.Add(6000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GotoWorld)));
      this.ActionMap.Add(6001, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GotoWorld2)));
      this.ActionMap.Add(6002, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GotoWorld3)));
      this.ActionMap.Add(6003, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GotoWorld4)));
      this.ActionMap.Add(7000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GotoSmith)));
      this.ActionMap.Add(7001, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GotoSmith2)));
      this.ActionMap.Add(7002, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GotoSmith3)));
      this.ActionMap.Add(8000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Battle_Before)));
      this.ActionMap.Add(8001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TargetLord)));
      this.ActionMap.Add(8002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.IntoStageInfo)));
      this.ActionMap.Add(8003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.BattleSelect_S1)));
      this.ActionMap.Add(8004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.BattleSelect_S2)));
      this.ActionMap.Add(8005, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.BattleSelect_Start)));
      this.ActionMap.Add(8006, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.Battle_StartNewbie)));
      this.ActionMap.Add(8007, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.Battle_NextLevel)));
      this.ActionMap.Add(8008, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Battle_FirstUltra)));
      this.ActionMap.Add(8009, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.Battle_NextLevel_FullScreen)));
      this.ActionMap.Add(8010, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Battle_SecondUltra)));
      this.ActionMap.Add(8011, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Battle_ThirdUltra)));
      this.ActionMap.Add(9000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.WorldHunt1)));
      this.ActionMap.Add(9001, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.WorldHunt2)));
      this.ActionMap.Add(9002, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.WorldHunt3)));
      this.ActionMap.Add(10000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.CheckPutOnEquip)));
      this.ActionMap.Add(10001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.ClickHeroList)));
      this.ActionMap.Add(10002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.ClickHeroFromList)));
      this.ActionMap.Add(10003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.ClickEquipBtn)));
      this.ActionMap.Add(10004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.ClickPutOn)));
      this.ActionMap.Add(10005, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.UpdateRank1)));
      this.ActionMap.Add(10006, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.UpdateRank2)));
      this.ActionMap.Add(10007, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.UpdateRank3)));
      this.ActionMap.Add(10008, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.UpdateRank4)));
      this.ActionMap.Add(10009, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.UpdateRank5)));
      this.ActionMap.Add(10010, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.UpdateRank6)));
      this.ActionMap.Add(10011, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.UpdateRank7)));
      this.ActionMap.Add(11000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.WorldAttack1)));
      this.ActionMap.Add(11001, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.WorldAttack2)));
      this.ActionMap.Add(11002, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.WorldAttack3)));
      this.ActionMap.Add(11003, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.WorldAttack4)));
      this.ActionMap.Add(12000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GetNewHero)));
      this.ActionMap.Add(12001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GetNewHero2)));
      this.ActionMap.Add(12002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GetNewHero3)));
      this.ActionMap.Add(12003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GetNewHero4)));
      this.ActionMap.Add(13000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TWipeOut)));
      this.ActionMap.Add(13001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TWipeOut2)));
      this.ActionMap.Add(13002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TWipeOut3)));
      this.ActionMap.Add(13003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TWipeOut4)));
      this.ActionMap.Add(13004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TWipeOut5)));
      this.ActionMap.Add(13005, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.TWipeOut6)));
      this.ActionMap.Add(14000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Turbo1)));
      this.ActionMap.Add(14001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Turbo2)));
      this.ActionMap.Add(14002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Turbo3)));
      this.ActionMap.Add(14003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.Turbo4)));
      this.ActionMap.Add(15000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoldGuy1)));
      this.ActionMap.Add(15001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoldGuy2)));
      this.ActionMap.Add(15002, new NewbieManager.NewbieNode(1f, new NewbieManager.ActiveStep(this.GoldGuy3)));
      this.ActionMap.Add(16000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.IntoActivity)));
      this.ActionMap.Add(16001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.IntoActivity2)));
      this.ActionMap.Add(17000, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GoAutoBattle)));
      this.ActionMap.Add(18000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoEliteStage1)));
      this.ActionMap.Add(18001, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GoEliteStage2)));
      this.ActionMap.Add(18002, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GoEliteStage3)));
      this.ActionMap.Add(19000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoArmyHole)));
      this.ActionMap.Add(19001, new NewbieManager.NewbieNode(1.2f, new NewbieManager.ActiveStep(this.GoArmyHole2)));
      this.ActionMap.Add(19002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoArmyHole3)));
      this.ActionMap.Add(20000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoBlackMarket1)));
      this.ActionMap.Add(20001, new NewbieManager.NewbieNode(1.2f, new NewbieManager.ActiveStep(this.GoBlackMarket2)));
      this.ActionMap.Add(20002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoBlackMarket3)));
      this.ActionMap.Add(21000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoTroopMemory)));
      this.ActionMap.Add(21001, new NewbieManager.NewbieNode(1.2f, new NewbieManager.ActiveStep(this.GoTroopMemory2)));
      this.ActionMap.Add(21002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoTroopMemory3)));
      this.ActionMap.Add(22000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDeShield)));
      this.ActionMap.Add(22001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDeShield2)));
      this.ActionMap.Add(22002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDeShield3)));
      this.ActionMap.Add(23000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoCoord)));
      this.ActionMap.Add(23001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoCoord2)));
      this.ActionMap.Add(23002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoCoord3)));
      this.ActionMap.Add(23003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoCoord4)));
      this.ActionMap.Add(24000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.PressX)));
      this.ActionMap.Add(25000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoMetallurgy)));
      this.ActionMap.Add(25001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoMetallurgy2)));
      this.ActionMap.Add(25002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoMetallurgy3)));
      this.ActionMap.Add(25003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoMetallurgy4)));
      this.ActionMap.Add(25004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoMetallurgy5)));
      this.ActionMap.Add(25005, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoMetallurgy6)));
      this.ActionMap.Add(26000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleNormal)));
      this.ActionMap.Add(26001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleNormal2)));
      this.ActionMap.Add(26002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleNormal3)));
      this.ActionMap.Add(26003, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GoGambleNormal4)));
      this.ActionMap.Add(26004, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleNormal5)));
      this.ActionMap.Add(26005, new NewbieManager.NewbieNode(4f, new NewbieManager.ActiveStep(this.GoGambleNormal6)));
      this.ActionMap.Add(26006, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleNormal7)));
      this.ActionMap.Add(26007, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleNormal8)));
      this.ActionMap.Add(27000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleElite)));
      this.ActionMap.Add(27001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleElite2)));
      this.ActionMap.Add(27002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoGambleElite3)));
      this.ActionMap.Add(28000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull)));
      this.ActionMap.Add(28001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull2)));
      this.ActionMap.Add(28002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull3)));
      this.ActionMap.Add(28003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull4)));
      this.ActionMap.Add(28004, new NewbieManager.NewbieNode(2.5f, new NewbieManager.ActiveStep(this.GoDareFull5)));
      this.ActionMap.Add(28005, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull6)));
      this.ActionMap.Add(28006, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull7)));
      this.ActionMap.Add(28007, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull8)));
      this.ActionMap.Add(28008, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull9)));
      this.ActionMap.Add(28009, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull10)));
      this.ActionMap.Add(28010, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull11)));
      this.ActionMap.Add(28011, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull12)));
      this.ActionMap.Add(28012, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareFull13)));
      this.ActionMap.Add(29000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareLead)));
      this.ActionMap.Add(29001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareLead2)));
      this.ActionMap.Add(29002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareLead3)));
      this.ActionMap.Add(29003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoDareLead4)));
      this.ActionMap.Add(30000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSpawnSoliderDetail)));
      this.ActionMap.Add(30001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSpawnSoliderDetail2)));
      this.ActionMap.Add(31000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoTreasBoxUpgrade)));
      this.ActionMap.Add(31001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoTreasBoxUpgrade2)));
      this.ActionMap.Add(31002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoTreasBoxUpgrade3)));
      this.ActionMap.Add(32000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSpawnPet)));
      this.ActionMap.Add(32001, new NewbieManager.NewbieNode(1f, new NewbieManager.ActiveStep(this.GoSpawnPet2)));
      this.ActionMap.Add(32002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSpawnPet3)));
      this.ActionMap.Add(32003, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GoSpawnPet4)));
      this.ActionMap.Add(32004, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GoSpawnPet5)));
      this.ActionMap.Add(33000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoPetInfo)));
      this.ActionMap.Add(33001, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GoPetInfo2)));
      this.ActionMap.Add(34000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoPetFusion)));
      this.ActionMap.Add(34001, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GoPetFusion2)));
      this.ActionMap.Add(35000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoPetTraining)));
      this.ActionMap.Add(35001, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GoPetTraining2)));
      this.ActionMap.Add(36000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoPetSkill)));
      this.ActionMap.Add(36001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoPetSkill2)));
      this.ActionMap.Add(36002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoPetSkill3)));
      this.ActionMap.Add(36003, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GoPetSkill4)));
      this.ActionMap.Add(37000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSocialInvite)));
      this.ActionMap.Add(37001, new NewbieManager.NewbieNode(0.0f, new NewbieManager.ActiveStep(this.GoSocialInvite2)));
      this.ActionMap.Add(37002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSocialInvite3)));
      this.ActionMap.Add(38000, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSocialInviteII)));
      this.ActionMap.Add(38001, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSocialInviteII2)));
      this.ActionMap.Add(38002, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSocialInviteII3)));
      this.ActionMap.Add(38003, new NewbieManager.NewbieNode(0.8f, new NewbieManager.ActiveStep(this.GoSocialInviteII4)));
    }
    if (this.ClickActionMap.Count != 0)
      return;
    this.ClickActionMap.Add(100, new NewbieManager.ActiveStep(this.RecvShowDrama));
    this.ClickActionMap.Add(101, new NewbieManager.ActiveStep(this.RecvFirstIntoDoor));
    this.ClickActionMap.Add(102, new NewbieManager.ActiveStep(this.RecvStep1TargetGoal));
    this.ClickActionMap.Add(105, new NewbieManager.ActiveStep(this.RecvBarrackUpgrade));
    this.ClickActionMap.Add(106, new NewbieManager.ActiveStep(this.RecvBarrackToDoor));
    this.ClickActionMap.Add(108, new NewbieManager.ActiveStep(this.Step1RecvTargetPrize));
    this.ClickActionMap.Add(200, new NewbieManager.ActiveStep(this.RecvIntoUpdateCastle));
    this.ClickActionMap.Add(201, new NewbieManager.ActiveStep(this.RecvStep2TargetGoal));
    this.ClickActionMap.Add(203, new NewbieManager.ActiveStep(this.RecvIntoUICastle));
    this.ClickActionMap.Add(204, new NewbieManager.ActiveStep(this.RecvIntoCastleUpgrade));
    this.ClickActionMap.Add(205, new NewbieManager.ActiveStep(this.RecvCastleUpgradeRightNow));
    this.ClickActionMap.Add(206, new NewbieManager.ActiveStep(this.RecvIntoLevelUpUI));
    this.ClickActionMap.Add(207, new NewbieManager.ActiveStep(this.Step2RecvTargetPrize));
    this.ClickActionMap.Add(300, new NewbieManager.ActiveStep(this.RecvIntoGetPrize));
    this.ClickActionMap.Add(301, new NewbieManager.ActiveStep(this.RecvVipLevelUp));
    this.ClickActionMap.Add(302, new NewbieManager.ActiveStep(this.RecvVipLevelUp2));
    this.ClickActionMap.Add(303, new NewbieManager.ActiveStep(this.RecvStep3Talk2));
    this.ClickActionMap.Add(304, new NewbieManager.ActiveStep(this.RecvTargetPrize));
    this.ClickActionMap.Add(1000, new NewbieManager.ActiveStep(this.RecvSpawnSoldier));
    this.ClickActionMap.Add(1001, new NewbieManager.ActiveStep(this.RecvTargetSoldierItem));
    this.ClickActionMap.Add(1002, new NewbieManager.ActiveStep(this.RecvTargetTrain));
    this.ClickActionMap.Add(1003, new NewbieManager.ActiveStep(this.RecvFinishTrain));
    this.ClickActionMap.Add(1004, new NewbieManager.ActiveStep(this.RecvFinishTrain2));
    this.ClickActionMap.Add(2000, new NewbieManager.ActiveStep(this.Recv_Into_WarScout));
    this.ClickActionMap.Add(2001, new NewbieManager.ActiveStep(this.Recv_WarScout_TargetCastle));
    this.ClickActionMap.Add(2002, new NewbieManager.ActiveStep(this.RecvTargetScout));
    this.ClickActionMap.Add(2003, new NewbieManager.ActiveStep(this.RecvTargetScoutInfo));
    this.ClickActionMap.Add(2004, new NewbieManager.ActiveStep(this.RecvTargetScoutInfoExit));
    this.ClickActionMap.Add(2005, new NewbieManager.ActiveStep(this.Recv_Into_WarAttack));
    this.ClickActionMap.Add(2006, new NewbieManager.ActiveStep(this.Recv_Team_Select));
    this.ClickActionMap.Add(2007, new NewbieManager.ActiveStep(this.Recv_Soldier_Select));
    this.ClickActionMap.Add(2008, new NewbieManager.ActiveStep(this.Recv_Fight_Select));
    this.ClickActionMap.Add(3000, new NewbieManager.ActiveStep(this.RecvGoArena));
    this.ClickActionMap.Add(3001, new NewbieManager.ActiveStep(this.RecvGoArena2));
    this.ClickActionMap.Add(3002, new NewbieManager.ActiveStep(this.RecvGoArena3));
    this.ClickActionMap.Add(3003, new NewbieManager.ActiveStep(this.RecvGoArena4));
    this.ClickActionMap.Add(3004, new NewbieManager.ActiveStep(this.RecvGoArena5));
    this.ClickActionMap.Add(4000, new NewbieManager.ActiveStep(this.RecvIntoCollege));
    this.ClickActionMap.Add(4001, new NewbieManager.ActiveStep(this.RecvTargetMilitary));
    this.ClickActionMap.Add(4002, new NewbieManager.ActiveStep(this.RecvTargetTopSkill));
    this.ClickActionMap.Add(4003, new NewbieManager.ActiveStep(this.RecvTargetTechInfo));
    this.ClickActionMap.Add(4004, new NewbieManager.ActiveStep(this.RecvTechUpgrade));
    this.ClickActionMap.Add(4005, new NewbieManager.ActiveStep(this.RecvTechFinish));
    this.ClickActionMap.Add(5000, new NewbieManager.ActiveStep(this.RecvRename));
    this.ClickActionMap.Add(6000, new NewbieManager.ActiveStep(this.RecvGotoWorld));
    this.ClickActionMap.Add(6001, new NewbieManager.ActiveStep(this.RecvGotoWorld2));
    this.ClickActionMap.Add(6002, new NewbieManager.ActiveStep(this.RecvGotoWorld3));
    this.ClickActionMap.Add(6003, new NewbieManager.ActiveStep(this.RecvGotoWorld4));
    this.ClickActionMap.Add(7000, new NewbieManager.ActiveStep(this.RecvGotoSmith));
    this.ClickActionMap.Add(7001, new NewbieManager.ActiveStep(this.RecvGotoSmith2));
    this.ClickActionMap.Add(7002, new NewbieManager.ActiveStep(this.RecvGotoSmith3));
    this.ClickActionMap.Add(8000, new NewbieManager.ActiveStep(this.Recv_Battle_Before));
    this.ClickActionMap.Add(8001, new NewbieManager.ActiveStep(this.Recv_TargetLord));
    this.ClickActionMap.Add(8002, new NewbieManager.ActiveStep(this.Recv_IntoStageInfo));
    this.ClickActionMap.Add(8003, new NewbieManager.ActiveStep(this.Recv_BattleSelect_S1));
    this.ClickActionMap.Add(8004, new NewbieManager.ActiveStep(this.Recv_BattleSelect_S2));
    this.ClickActionMap.Add(8005, new NewbieManager.ActiveStep(this.Recv_BattleSelect_Start));
    this.ClickActionMap.Add(8007, new NewbieManager.ActiveStep(this.Recv_Battle_NextLevel));
    this.ClickActionMap.Add(8008, new NewbieManager.ActiveStep(this.Recv_Battle_FirstUltra));
    this.ClickActionMap.Add(8009, new NewbieManager.ActiveStep(this.Recv_Battle_NextLevel));
    this.ClickActionMap.Add(8010, new NewbieManager.ActiveStep(this.Recv_Battle_SecondUltra));
    this.ClickActionMap.Add(8011, new NewbieManager.ActiveStep(this.Recv_Battle_ThirdUltra));
    this.ClickActionMap.Add(9000, new NewbieManager.ActiveStep(this.RecvWorldHunt1));
    this.ClickActionMap.Add(9001, new NewbieManager.ActiveStep(this.RecvWorldHunt2));
    this.ClickActionMap.Add(9002, new NewbieManager.ActiveStep(this.RecvWorldHunt3));
    this.ClickActionMap.Add(10000, new NewbieManager.ActiveStep(this.RecvCheckPutOnEquip));
    this.ClickActionMap.Add(10001, new NewbieManager.ActiveStep(this.RecvClickHeroList));
    this.ClickActionMap.Add(10002, new NewbieManager.ActiveStep(this.RecvClickHeroFromList));
    this.ClickActionMap.Add(10003, new NewbieManager.ActiveStep(this.RecvClickEquipBtn));
    this.ClickActionMap.Add(10004, new NewbieManager.ActiveStep(this.RecvClickPutOn));
    this.ClickActionMap.Add(10005, new NewbieManager.ActiveStep(this.RecvUpdateRank1));
    this.ClickActionMap.Add(10006, new NewbieManager.ActiveStep(this.RecvUpdateRank2));
    this.ClickActionMap.Add(10007, new NewbieManager.ActiveStep(this.RecvUpdateRank3));
    this.ClickActionMap.Add(10008, new NewbieManager.ActiveStep(this.RecvUpdateRank4));
    this.ClickActionMap.Add(10009, new NewbieManager.ActiveStep(this.RecvUpdateRank5));
    this.ClickActionMap.Add(10010, new NewbieManager.ActiveStep(this.RecvUpdateRank6));
    this.ClickActionMap.Add(10011, new NewbieManager.ActiveStep(this.RecvUpdateRank7));
    this.ClickActionMap.Add(11000, new NewbieManager.ActiveStep(this.RecvWorldAttack1));
    this.ClickActionMap.Add(11001, new NewbieManager.ActiveStep(this.RecvWorldAttack2));
    this.ClickActionMap.Add(11002, new NewbieManager.ActiveStep(this.RecvWorldAttack3));
    this.ClickActionMap.Add(11003, new NewbieManager.ActiveStep(this.RecvWorldAttack4));
    this.ClickActionMap.Add(12000, new NewbieManager.ActiveStep(this.RecvGetNewHero));
    this.ClickActionMap.Add(12001, new NewbieManager.ActiveStep(this.RecvGetNewHero2));
    this.ClickActionMap.Add(12002, new NewbieManager.ActiveStep(this.RecvGetNewHero3));
    this.ClickActionMap.Add(12003, new NewbieManager.ActiveStep(this.RecvGetNewHero4));
    this.ClickActionMap.Add(13000, new NewbieManager.ActiveStep(this.RecvTWipeOut));
    this.ClickActionMap.Add(13001, new NewbieManager.ActiveStep(this.RecvTWipeOut2));
    this.ClickActionMap.Add(13002, new NewbieManager.ActiveStep(this.RecvTWipeOut3));
    this.ClickActionMap.Add(13003, new NewbieManager.ActiveStep(this.RecvTWipeOut4));
    this.ClickActionMap.Add(13004, new NewbieManager.ActiveStep(this.RecvTWipeOut5));
    this.ClickActionMap.Add(13005, new NewbieManager.ActiveStep(this.RecvTWipeOut6));
    this.ClickActionMap.Add(14000, new NewbieManager.ActiveStep(this.RecvTurbo1));
    this.ClickActionMap.Add(14001, new NewbieManager.ActiveStep(this.RecvTurbo2));
    this.ClickActionMap.Add(14002, new NewbieManager.ActiveStep(this.RecvTurbo3));
    this.ClickActionMap.Add(14003, new NewbieManager.ActiveStep(this.RecvTurbo4));
    this.ClickActionMap.Add(15000, new NewbieManager.ActiveStep(this.RecvGoldGuy1));
    this.ClickActionMap.Add(15001, new NewbieManager.ActiveStep(this.RecvGoldGuy2));
    this.ClickActionMap.Add(15002, new NewbieManager.ActiveStep(this.RecvGoldGuy3));
    this.ClickActionMap.Add(16000, new NewbieManager.ActiveStep(this.RecvIntoActivity));
    this.ClickActionMap.Add(16001, new NewbieManager.ActiveStep(this.RecvIntoActivity2));
    this.ClickActionMap.Add(17000, new NewbieManager.ActiveStep(this.RecvGoAutoBattle));
    this.ClickActionMap.Add(18000, new NewbieManager.ActiveStep(this.RecvGoEliteStage1));
    this.ClickActionMap.Add(18001, new NewbieManager.ActiveStep(this.RecvGoEliteStage2));
    this.ClickActionMap.Add(18002, new NewbieManager.ActiveStep(this.RecvGoEliteStage3));
    this.ClickActionMap.Add(19000, new NewbieManager.ActiveStep(this.RecvGoArmyHole));
    this.ClickActionMap.Add(19001, new NewbieManager.ActiveStep(this.RecvGoArmyHole2));
    this.ClickActionMap.Add(19002, new NewbieManager.ActiveStep(this.RecvGoArmyHole3));
    this.ClickActionMap.Add(20000, new NewbieManager.ActiveStep(this.RecvGoBlackMarket1));
    this.ClickActionMap.Add(20001, new NewbieManager.ActiveStep(this.RecvGoBlackMarket2));
    this.ClickActionMap.Add(20002, new NewbieManager.ActiveStep(this.RecvGoBlackMarket3));
    this.ClickActionMap.Add(21000, new NewbieManager.ActiveStep(this.RecvGoTroopMemory));
    this.ClickActionMap.Add(21001, new NewbieManager.ActiveStep(this.RecvGoTroopMemory2));
    this.ClickActionMap.Add(21002, new NewbieManager.ActiveStep(this.RecvGoTroopMemory3));
    this.ClickActionMap.Add(22000, new NewbieManager.ActiveStep(this.RecvGoDeShield));
    this.ClickActionMap.Add(22001, new NewbieManager.ActiveStep(this.RecvGoDeShield2));
    this.ClickActionMap.Add(22002, new NewbieManager.ActiveStep(this.RecvGoDeShield3));
    this.ClickActionMap.Add(23000, new NewbieManager.ActiveStep(this.RecvGoCoord));
    this.ClickActionMap.Add(23001, new NewbieManager.ActiveStep(this.RecvGoCoord2));
    this.ClickActionMap.Add(23002, new NewbieManager.ActiveStep(this.RecvGoCoord3));
    this.ClickActionMap.Add(23003, new NewbieManager.ActiveStep(this.RecvGoCoord4));
    this.ClickActionMap.Add(24000, new NewbieManager.ActiveStep(this.RecvPressX));
    this.ClickActionMap.Add(25000, new NewbieManager.ActiveStep(this.RecvGoMetallurgy));
    this.ClickActionMap.Add(25001, new NewbieManager.ActiveStep(this.RecvGoMetallurgy2));
    this.ClickActionMap.Add(25002, new NewbieManager.ActiveStep(this.RecvGoMetallurgy3));
    this.ClickActionMap.Add(25003, new NewbieManager.ActiveStep(this.RecvGoMetallurgy4));
    this.ClickActionMap.Add(25004, new NewbieManager.ActiveStep(this.RecvGoMetallurgy5));
    this.ClickActionMap.Add(25005, new NewbieManager.ActiveStep(this.RecvGoMetallurgy6));
    this.ClickActionMap.Add(26000, new NewbieManager.ActiveStep(this.RecvGoGambleNormal));
    this.ClickActionMap.Add(26001, new NewbieManager.ActiveStep(this.RecvGoGambleNormal2));
    this.ClickActionMap.Add(26002, new NewbieManager.ActiveStep(this.RecvGoGambleNormal3));
    this.ClickActionMap.Add(26003, new NewbieManager.ActiveStep(this.RecvGoGambleNormal4));
    this.ClickActionMap.Add(26004, new NewbieManager.ActiveStep(this.RecvGoGambleNormal5));
    this.ClickActionMap.Add(26005, new NewbieManager.ActiveStep(this.RecvGoGambleNormal6));
    this.ClickActionMap.Add(26006, new NewbieManager.ActiveStep(this.RecvGoGambleNormal7));
    this.ClickActionMap.Add(26007, new NewbieManager.ActiveStep(this.RecvGoGambleNormal8));
    this.ClickActionMap.Add(27000, new NewbieManager.ActiveStep(this.RecvGoGambleElite));
    this.ClickActionMap.Add(27001, new NewbieManager.ActiveStep(this.RecvGoGambleElite2));
    this.ClickActionMap.Add(27002, new NewbieManager.ActiveStep(this.RecvGoGambleElite3));
    this.ClickActionMap.Add(28000, new NewbieManager.ActiveStep(this.RecvGoDareFull));
    this.ClickActionMap.Add(28001, new NewbieManager.ActiveStep(this.RecvGoDareFull2));
    this.ClickActionMap.Add(28002, new NewbieManager.ActiveStep(this.RecvGoDareFull3));
    this.ClickActionMap.Add(28003, new NewbieManager.ActiveStep(this.RecvGoDareFull4));
    this.ClickActionMap.Add(28004, new NewbieManager.ActiveStep(this.RecvGoDareFull5));
    this.ClickActionMap.Add(28005, new NewbieManager.ActiveStep(this.RecvGoDareFull6));
    this.ClickActionMap.Add(28006, new NewbieManager.ActiveStep(this.RecvGoDareFull7));
    this.ClickActionMap.Add(28007, new NewbieManager.ActiveStep(this.RecvGoDareFull8));
    this.ClickActionMap.Add(28008, new NewbieManager.ActiveStep(this.RecvGoDareFull9));
    this.ClickActionMap.Add(28009, new NewbieManager.ActiveStep(this.RecvGoDareFull10));
    this.ClickActionMap.Add(28010, new NewbieManager.ActiveStep(this.RecvGoDareFull11));
    this.ClickActionMap.Add(28011, new NewbieManager.ActiveStep(this.RecvGoDareFull12));
    this.ClickActionMap.Add(28012, new NewbieManager.ActiveStep(this.RecvGoDareFull13));
    this.ClickActionMap.Add(29000, new NewbieManager.ActiveStep(this.RecvGoDareLead));
    this.ClickActionMap.Add(29001, new NewbieManager.ActiveStep(this.RecvGoDareLead2));
    this.ClickActionMap.Add(29002, new NewbieManager.ActiveStep(this.RecvGoDareLead3));
    this.ClickActionMap.Add(29003, new NewbieManager.ActiveStep(this.RecvGoDareLead4));
    this.ClickActionMap.Add(30000, new NewbieManager.ActiveStep(this.RecvGoSpawnSoliderDetail));
    this.ClickActionMap.Add(30001, new NewbieManager.ActiveStep(this.RecvGoSpawnSoliderDetail2));
    this.ClickActionMap.Add(31000, new NewbieManager.ActiveStep(this.RecvGoTreasBoxUpgrade));
    this.ClickActionMap.Add(31001, new NewbieManager.ActiveStep(this.RecvGoTreasBoxUpgrade2));
    this.ClickActionMap.Add(31002, new NewbieManager.ActiveStep(this.RecvGoTreasBoxUpgrade3));
    this.ClickActionMap.Add(32000, new NewbieManager.ActiveStep(this.RecvGoSpawnPet));
    this.ClickActionMap.Add(32001, new NewbieManager.ActiveStep(this.RecvGoSpawnPet2));
    this.ClickActionMap.Add(32002, new NewbieManager.ActiveStep(this.RecvGoSpawnPet3));
    this.ClickActionMap.Add(32003, new NewbieManager.ActiveStep(this.RecvGoSpawnPet4));
    this.ClickActionMap.Add(32004, new NewbieManager.ActiveStep(this.RecvGoSpawnPet5));
    this.ClickActionMap.Add(33000, new NewbieManager.ActiveStep(this.RecvGoPetInfo));
    this.ClickActionMap.Add(33001, new NewbieManager.ActiveStep(this.RecvGoPetInfo2));
    this.ClickActionMap.Add(34000, new NewbieManager.ActiveStep(this.RecvGoPetFusion));
    this.ClickActionMap.Add(34001, new NewbieManager.ActiveStep(this.RecvGoPetFusion2));
    this.ClickActionMap.Add(35000, new NewbieManager.ActiveStep(this.RecvGoPetTraining));
    this.ClickActionMap.Add(35001, new NewbieManager.ActiveStep(this.RecvGoPetTraining2));
    this.ClickActionMap.Add(36000, new NewbieManager.ActiveStep(this.RecvGoPetSkill));
    this.ClickActionMap.Add(36001, new NewbieManager.ActiveStep(this.RecvGoPetSkill2));
    this.ClickActionMap.Add(36002, new NewbieManager.ActiveStep(this.RecvGoPetSkill3));
    this.ClickActionMap.Add(36003, new NewbieManager.ActiveStep(this.RecvGoPetSkill4));
    this.ClickActionMap.Add(37000, new NewbieManager.ActiveStep(this.RecvGoSocialInvite));
    this.ClickActionMap.Add(37001, new NewbieManager.ActiveStep(this.RecvGoSocialInvite2));
    this.ClickActionMap.Add(37002, new NewbieManager.ActiveStep(this.RecvGoSocialInvite3));
    this.ClickActionMap.Add(38000, new NewbieManager.ActiveStep(this.RecvGoSocialInviteII));
    this.ClickActionMap.Add(38001, new NewbieManager.ActiveStep(this.RecvGoSocialInviteII2));
    this.ClickActionMap.Add(38002, new NewbieManager.ActiveStep(this.RecvGoSocialInviteII3));
    this.ClickActionMap.Add(38003, new NewbieManager.ActiveStep(this.RecvGoSocialInviteII4));
  }

  public static void CheckInitData()
  {
    if (!NewbieManager.IsNewbie)
      return;
    NewbieManager.m_Self.InitData();
  }

  public void InitData()
  {
    if (this.Step < 0 || this.Step >= 4)
      return;
    if (this.bIsNewUser)
    {
      if (this.Step != 0)
        this.LockControl();
      if (this.Step == 1)
        this.CurFakeData = (ushort) 1;
      else if (this.Step == 2)
        this.CurFakeData = (ushort) 2;
      else if (this.Step == 3)
        this.CurFakeData = (ushort) 4;
      this.SetupFakeData((int) this.CurFakeData);
      if (this.Step < 2)
      {
        RoleBuildingData roleBuildingData = new RoleBuildingData((ushort) 5, (ushort) 0, (byte) 0);
        if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 5)
          GUIManager.Instance.BuildingData.AllBuildsData[5] = roleBuildingData;
        if (GUIManager.Instance.BuildingData.BuildIDCount != null)
          GUIManager.Instance.BuildingData.BuildIDCount[6] = (byte) 0;
      }
      if (this.Step < 3)
      {
        if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1)
          GUIManager.Instance.BuildingData.AllBuildsData[1].Level = (byte) 1;
        DataManager.MissionDataManager.SetCompleteWhileLogin(eMissionKind.Build);
        if (this.Step == 2)
          this.FakeBuildLvStep = (byte) 2;
      }
      if (this.Step >= 2)
        DataManager.MissionDataManager.sendMissionComplete((ushort) 6, (ushort) 0);
      if (this.Step != 3)
        return;
      this.FakeBuildLvStep = (byte) 4;
      DataManager.MissionDataManager.sendMissionComplete((ushort) 33, (ushort) 0);
    }
    else
    {
      if (this.FakeBuildLvStep < (byte) 1)
      {
        RoleBuildingData roleBuildingData = new RoleBuildingData((ushort) 5, (ushort) 0, (byte) 0);
        if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 5)
          GUIManager.Instance.BuildingData.AllBuildsData[5] = roleBuildingData;
        if (GUIManager.Instance.BuildingData.BuildIDCount != null)
          GUIManager.Instance.BuildingData.BuildIDCount[6] = (byte) 0;
        GUIManager.Instance.BuildingData.UpdateBuildState((byte) 6, (ushort) byte.MaxValue);
        DataManager.MissionDataManager.Reset();
        Array.Clear((Array) DataManager.MissionDataManager.BoolMark, 0, DataManager.MissionDataManager.BoolMark.Length);
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
      }
      if (this.FakeBuildLvStep < (byte) 3)
      {
        if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1)
          GUIManager.Instance.BuildingData.AllBuildsData[1].Level = (byte) 1;
        GUIManager.Instance.BuildingData.UpdateBuildState((byte) 6, (ushort) byte.MaxValue);
        if (this.FakeBuildLvStep == (byte) 2)
        {
          Array.Clear((Array) DataManager.MissionDataManager.BoolMark, 0, DataManager.MissionDataManager.BoolMark.Length);
          DataManager.MissionDataManager.sendMissionComplete((ushort) 6, (ushort) 0);
        }
      }
      if (this.FakeBuildLvStep >= (byte) 3)
      {
        Array.Clear((Array) DataManager.MissionDataManager.BoolMark, 0, DataManager.MissionDataManager.BoolMark.Length);
        DataManager.MissionDataManager.sendMissionComplete((ushort) 6, (ushort) 0);
        if (this.FakeBuildLvStep == (byte) 4)
          DataManager.MissionDataManager.sendMissionComplete((ushort) 33, (ushort) 0);
      }
      if (GUIManager.Instance.BuildingData.BuildIDCount != null)
        Array.Clear((Array) GUIManager.Instance.BuildingData.BuildIDCount, 0, GUIManager.Instance.BuildingData.BuildIDCount.Length);
      GUIManager.Instance.BuildingData.NeedSortData = true;
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuitBuilding, 0);
      if (this.FakeMarkStep >= (byte) 1)
      {
        DataManager.MissionDataManager.RecommandTable.SaveIndex = this.FakeMarkStep < (byte) 2 ? (ushort) 2 : (ushort) 3;
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
      }
      else
      {
        DataManager.MissionDataManager.RecommandTable.SaveIndex = (ushort) 1;
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
      }
      this.SetupFakeData((int) this.CurFakeData);
      if (this.FakeBuildStep == (byte) 1)
        this.DisplayBarrackQueue();
      else if (this.FakeBuildStep == (byte) 2)
        this.DisplayCastleQueue();
      GameManager.OnRefresh(NetworkNews.Refresh_AttribEffectVal);
    }
  }

  public void SkipForceNewbie()
  {
    RoleBuildingData roleBuildingData = new RoleBuildingData((ushort) 5, (ushort) 6, (byte) 1);
    if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 5)
      GUIManager.Instance.BuildingData.AllBuildsData[5] = roleBuildingData;
    if (GUIManager.Instance.BuildingData.BuildIDCount != null)
      GUIManager.Instance.BuildingData.BuildIDCount[6] = (byte) 1;
    GUIManager.Instance.BuildingData.AllBuildsData[1].Level = (byte) 2;
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 3, (ushort) 5);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 3, (ushort) 1);
    this.SetupFakeData(6);
    DataManager.MissionDataManager.sendMissionComplete((ushort) 6, (ushort) 0);
    DataManager.MissionDataManager.sendMissionComplete((ushort) 33, (ushort) 0);
    DataManager.Instance.RoleAttr.PrizeFlag |= 2U;
    bool result = true;
    bool.TryParse(PlayerPrefs.GetString("Other_bShowTimeBar"), out result);
    if (!result)
      DataManager.Instance.MySysSetting.bShowTimeBar = false;
    NewbieLog.Log(ENewbieLogKind.FORCE_4, (byte) 2);
    this.LockControl(false);
    this.Step = 3;
    this.FinishStep();
    NewbieManager.SendFinishNewbie();
    IGGSDKPlugin.SetFacebookEventCompletedTutorial();
    AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.TUTORIAL_COMPLETION);
    this.DM.GetSysSettingSave();
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Newbie);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27);
  }

  public void CheckTimeBarStatus()
  {
    if (!bool.TryParse(PlayerPrefs.GetString("Other_bShowTimeBar"), out this.bTimeBarOpen))
      this.bTimeBarOpen = false;
    if (DataManager.Instance.MySysSetting.bShowTimeBar)
      return;
    DataManager.Instance.MySysSetting.bShowTimeBar = true;
  }

  public void RestoreTimeBarStatus()
  {
    if (this.bTimeBarOpen)
      return;
    DataManager.Instance.MySysSetting.bShowTimeBar = false;
  }

  public void SetupFakeData(int key)
  {
    DataManager instance = DataManager.Instance;
    NewbieData recordByKey = instance.NewbieTable.GetRecordByKey((ushort) key);
    instance.Resource[0].Stock = (uint) recordByKey.Food;
    instance.Resource[1].Stock = (uint) recordByKey.Rock;
    instance.Resource[2].Stock = (uint) recordByKey.Wood;
    instance.Resource[3].Stock = (uint) recordByKey.Iron;
    instance.Resource[4].Stock = (uint) recordByKey.Gold;
    instance.RoleAttr.Power = (ulong) recordByKey.Power;
    DataManager.StageDataController.UpdateRoleAttrMorale(recordByKey.Morale);
    DataManager.StageDataController.UpdateRoleAttrExp((uint) recordByKey.Lead);
    GameManager.OnRefresh();
  }

  public void Update()
  {
    if (this.bRunAction)
    {
      if ((double) this.ActionDelay <= 0.0)
      {
        this.ActionDelay = 0.0f;
        this.bRunAction = false;
        if (this.pAction != null)
        {
          NewbieManager.ActiveStep pAction = this.pAction;
          this.pAction = (NewbieManager.ActiveStep) null;
          pAction();
        }
      }
      else
        this.ActionDelay -= Time.deltaTime;
    }
    if (this.bFlagDirty)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_UPDATEGUIDE;
      messagePacket.AddSeqId();
      messagePacket.Add((uint) (this.DM.RoleAttr.Guide & (ulong) uint.MaxValue));
      messagePacket.Add((uint) (this.DM.RoleAttr.Guide >> 32));
      if (messagePacket.Send())
        this.bFlagDirty = false;
    }
    if (this.bFlagDirty2)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_NEWBIE_FLAG;
      messagePacket.AddSeqId();
      if (messagePacket.Send())
        this.bFlagDirty2 = false;
    }
    if (this.bFlagDirty3)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_SHELTER_NEWBIE_FLAG;
      messagePacket.AddSeqId();
      if (messagePacket.Send())
        this.bFlagDirty3 = false;
    }
    if (this.bFlagDirty_Blackmarket)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_BLACKMARKET_NEWBIE_FLAG;
      messagePacket.AddSeqId();
      if (messagePacket.Send())
        this.bFlagDirty_Blackmarket = false;
    }
    if (this.bFlagDirty_TroopMemory)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 12);
      if (messagePacket.Send())
        this.bFlagDirty_TroopMemory = false;
    }
    if (this.bFlagDirty_DeShield)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 13);
      if (messagePacket.Send())
        this.bFlagDirty_DeShield = false;
    }
    if (this.bFlagDirty_Coord)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 14);
      if (messagePacket.Send())
        this.bFlagDirty_Coord = false;
    }
    if (this.bFlagDirty_Metallurgy)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 15);
      if (messagePacket.Send())
        this.bFlagDirty_Metallurgy = false;
    }
    if (this.bFlagDirty_Gamble2)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 17);
      if (messagePacket.Send())
        this.bFlagDirty_Gamble2 = false;
    }
    if (this.bFlagDirty_DareFull)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 18);
      if (messagePacket.Send())
        this.bFlagDirty_DareFull = false;
    }
    if (this.bFlagDirty_DareLead)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 19);
      if (messagePacket.Send())
        this.bFlagDirty_DareLead = false;
    }
    if (this.bFlagDirty_SpawnSoldierDetail)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 22);
      if (messagePacket.Send())
        this.bFlagDirty_SpawnSoldierDetail = false;
    }
    if (this.bFlagDirty_TreasBoxUpgrade)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 23);
      if (messagePacket.Send())
        this.bFlagDirty_TreasBoxUpgrade = false;
    }
    if (this.bFlagDirty_SpawnPet)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 24);
      if (messagePacket.Send())
        this.bFlagDirty_SpawnPet = false;
    }
    if (this.SendGuideExFlag != (byte) 0)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_NEWBIE_FLAG_MODIFY;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) 0);
      messagePacket.Add(this.SendGuideExFlag);
      if (messagePacket.Send())
        this.SendGuideExFlag = (byte) 0;
    }
    if (this.TeachStep != 14 || this.SubStep != 1 || this.Target == null)
      return;
    UITimeBar target = this.Target as UITimeBar;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null) || target.m_TimerSpriteType == eTimerSpriteType.Help)
      return;
    this.IgnoreStep(false, 2);
  }

  public NewbieStep GetStep() => (NewbieStep) this.Step;

  public void FinishStep(bool bSave = true)
  {
    ++this.Step;
    if (bSave)
      PlayerPrefs.SetInt(this.SaveName, this.Step);
    this.SubStep = 0;
  }

  public static ulong GetTeachFlag()
  {
    return (ulong) (~(long) DataManager.Instance.RoleAttr.Guide & 274877906943L);
  }

  public void LoadTeachFlag() => this.TeachFlag = NewbieManager.GetTeachFlag();

  public void ResetTeach()
  {
    this.TeachFlag = 274877906943UL;
    this.SaveTeachFlag();
  }

  public bool HasTeachFlag(ETeachKind t)
  {
    return ((long) this.TeachFlag & 1L << (int) (t & (ETeachKind.SPAWN_PET | ETeachKind.PET_INFO))) != 0L;
  }

  public void SaveTeachFlag(ulong? flag = null)
  {
    if (!flag.HasValue)
      flag = new ulong?(this.TeachFlag);
    this.DM.RoleAttr.Guide = (ulong) ~((long) flag.Value & -1L);
    this.bFlagDirty = true;
  }

  public void RemoveFlag(ETeachKind kind, byte type = 0, bool IgnoreUIQueue = false)
  {
    ulong num = this.TeachFlag & (ulong) ~(1L << (int) (kind & (ETeachKind.SPAWN_PET | ETeachKind.PET_INFO) & (ETeachKind.SPAWN_PET | ETeachKind.PET_INFO)));
    if (type == (byte) 0)
    {
      this.SaveTeachFlag(new ulong?(num));
    }
    else
    {
      this.TeachFlag = num;
      this.TeachStep = 0;
      if (IgnoreUIQueue)
        return;
      GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Newbie);
    }
  }

  public int GetCurActionKey() => this.Step * 100 + this.SubStep;

  public int GetCurTeachKey() => this.TeachStep * 1000 + this.SubStep;

  public static bool NeedQueuePopMenu() => NewbieManager.IsWorking() || NewbieManager.bQueuePopMenu;

  public static bool IsWorking()
  {
    return NewbieManager.m_Self != null && NewbieManager.m_Self.TeachStep != 0 || NewbieManager.IsNewbie;
  }

  public static bool IsTeachWorking(ETeachKind tk)
  {
    return NewbieManager.IsWorking() && (ETeachKind) NewbieManager.m_Self.TeachStep == tk + (byte) 1;
  }

  public static bool CheckNewbie(object target = null)
  {
    if (!NewbieManager.IsNewbie || NewbieManager.m_Self == null)
      return false;
    int curActionKey = NewbieManager.m_Self.GetCurActionKey();
    NewbieManager.m_Self.ExeAction(curActionKey, target);
    return true;
  }

  public static void ClosePopMenu()
  {
    if (NewbieManager.m_Self != null && NewbieManager.m_Self.TeachStep == 5)
      return;
    GUIManager instance = GUIManager.Instance;
    if (!((UnityEngine.Object) instance.m_SecWindow != (UnityEngine.Object) null))
      return;
    instance.CloseMenu(instance.m_SecWindow.m_eWindow);
    instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
  }

  private void CheckGuideExFlagDirty(ETeachKind kind)
  {
    switch (kind)
    {
      case ETeachKind.PET_INFO:
        this.SendGuideExFlag = (byte) 1;
        break;
      case ETeachKind.PET_FUSION:
        this.SendGuideExFlag = (byte) 2;
        break;
      case ETeachKind.PET_TRAINING:
        this.SendGuideExFlag = (byte) 3;
        break;
      case ETeachKind.PET_SKILL:
        this.SendGuideExFlag = (byte) 4;
        break;
      case ETeachKind.SOCIAL_INVITE:
        this.SendGuideExFlag = (byte) 5;
        break;
      case ETeachKind.SOCIAL_INVITE_AFTER_MISSION:
        this.SendGuideExFlag = (byte) 6;
        break;
    }
  }

  public static bool EntryTeach(ETeachKind kind)
  {
    if (NewbieManager.m_Self == null || NewbieManager.m_Self.TeachStep != 0 || !NewbieManager.IsTeaching)
      return false;
    NewbieManager.m_Self.LoadTeachFlag();
    ulong num1 = 1UL << (int) (kind & (ETeachKind.SPAWN_PET | ETeachKind.PET_INFO));
    if (((long) NewbieManager.m_Self.TeachFlag & (long) num1) == 0L)
      return false;
    int num2 = (int) (kind + (byte) 1);
    if (num2 != NewbieManager.m_Self.TeachStep)
    {
      NewbieManager.m_Self.TeachStep = num2;
      NewbieManager.m_Self.SubStep = 0;
      NewbieManager.m_Self.RemoveFlag(kind, (byte) 0);
      switch (kind)
      {
        case ETeachKind.ARENA:
          NewbieManager.m_Self.bFlagDirty2 = true;
          break;
        case ETeachKind.ARMY_HOLE:
          NewbieManager.m_Self.bFlagDirty3 = true;
          break;
        case ETeachKind.BLACK_MARKET:
          NewbieManager.m_Self.bFlagDirty_Blackmarket = true;
          break;
        case ETeachKind.TROOP_MEMORY:
          NewbieManager.m_Self.bFlagDirty_TroopMemory = true;
          break;
        case ETeachKind.DESHIELD:
          NewbieManager.m_Self.bFlagDirty_DeShield = true;
          break;
        case ETeachKind.ARMY_COORD:
          NewbieManager.m_Self.bFlagDirty_Coord = true;
          break;
        case ETeachKind.METALLURGY:
          NewbieManager.m_Self.bFlagDirty_Metallurgy = true;
          break;
        case ETeachKind.GAMBLING2:
          NewbieManager.m_Self.bFlagDirty_Gamble2 = true;
          break;
        case ETeachKind.DARE_FULL:
          NewbieManager.m_Self.bFlagDirty_DareFull = true;
          break;
        case ETeachKind.DARE_LEAD:
          NewbieManager.m_Self.bFlagDirty_DareLead = true;
          break;
        case ETeachKind.SPAWN_SOLDIER_DETAIL:
          NewbieManager.m_Self.bFlagDirty_SpawnSoldierDetail = true;
          break;
        case ETeachKind.TREASBOX_UPGRADE:
          NewbieManager.m_Self.bFlagDirty_TreasBoxUpgrade = true;
          break;
        case ETeachKind.SPAWN_PET:
          NewbieManager.m_Self.bFlagDirty_SpawnPet = true;
          break;
        default:
          NewbieManager.m_Self.CheckGuideExFlagDirty(kind);
          break;
      }
      NewbieManager.m_Self.LockControl();
      UIPriestTalk.Block1s = true;
      GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Newbie);
      NewbieManager.ClosePopMenu();
    }
    return true;
  }

  public static bool CheckTeach(ETeachKind kind, object target = null, bool bEntry = false)
  {
    if (NewbieManager.m_Self == null || !bEntry && NewbieManager.m_Self.TeachStep == 0)
      return false;
    int num1 = (int) (kind + (byte) 1);
    if (NewbieManager.m_Self.TeachStep != 0 && num1 != NewbieManager.m_Self.TeachStep || !NewbieManager.IsTeaching)
      return false;
    ulong num2 = 1UL << (int) (kind & (ETeachKind.SPAWN_PET | ETeachKind.PET_INFO));
    if (((long) NewbieManager.m_Self.TeachFlag & (long) num2) == 0L)
      return false;
    if (num1 != NewbieManager.m_Self.TeachStep)
    {
      NewbieManager.m_Self.TeachStep = num1;
      NewbieManager.m_Self.SubStep = 0;
      if (kind != ETeachKind.BATTLE_BEFORE)
        NewbieManager.m_Self.RemoveFlag(kind, (byte) 0);
      if (kind == ETeachKind.ARENA)
        NewbieManager.m_Self.bFlagDirty2 = true;
      else if (kind == ETeachKind.ARMY_HOLE)
        NewbieManager.m_Self.bFlagDirty3 = true;
      else if (kind == ETeachKind.BLACK_MARKET)
        NewbieManager.m_Self.bFlagDirty_Blackmarket = true;
      else if (kind == ETeachKind.TROOP_MEMORY)
        NewbieManager.m_Self.bFlagDirty_TroopMemory = true;
      else if (kind == ETeachKind.DESHIELD)
        NewbieManager.m_Self.bFlagDirty_DeShield = true;
      else if (kind == ETeachKind.ARMY_COORD)
        NewbieManager.m_Self.bFlagDirty_Coord = true;
      else if (kind == ETeachKind.METALLURGY)
        NewbieManager.m_Self.bFlagDirty_Metallurgy = true;
      else if (kind == ETeachKind.GAMBLING2)
        NewbieManager.m_Self.bFlagDirty_Gamble2 = true;
      else if (kind == ETeachKind.DARE_FULL)
        NewbieManager.m_Self.bFlagDirty_DareFull = true;
      else if (kind == ETeachKind.DARE_LEAD)
        NewbieManager.m_Self.bFlagDirty_DareLead = true;
      else if (kind == ETeachKind.SPAWN_SOLDIER_DETAIL)
        NewbieManager.m_Self.bFlagDirty_SpawnSoldierDetail = true;
      else if (kind == ETeachKind.TREASBOX_UPGRADE)
        NewbieManager.m_Self.bFlagDirty_TreasBoxUpgrade = true;
      else if (kind == ETeachKind.SPAWN_PET)
        NewbieManager.m_Self.bFlagDirty_SpawnPet = true;
      else
        NewbieManager.m_Self.CheckGuideExFlagDirty(kind);
      NewbieManager.m_Self.LockControl();
      UIPriestTalk.Block1s = true;
      GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Newbie);
      NewbieManager.ClosePopMenu();
    }
    if (NewbieManager.bQueuePopMenu)
      NewbieManager.bQueuePopMenu = false;
    int curTeachKey = NewbieManager.m_Self.GetCurTeachKey();
    NewbieManager.m_Self.ExeAction(curTeachKey, target);
    return true;
  }

  public static bool NeedTeach(ETeachKind kind)
  {
    if (NewbieManager.m_Self == null || NewbieManager.m_Self.TeachStep != 0 || !NewbieManager.IsTeaching)
      return false;
    NewbieManager.m_Self.LoadTeachFlag();
    ulong num = 1UL << (int) (kind & (ETeachKind.SPAWN_PET | ETeachKind.PET_INFO));
    return ((long) NewbieManager.m_Self.TeachFlag & (long) num) != 0L;
  }

  public static bool CheckRename(bool enableMessage = true)
  {
    DataManager instance = DataManager.Instance;
    string str = instance.RoleAttr.Name.ToString();
    int curItemQuantity = (int) instance.GetCurItemQuantity((ushort) 1006, (byte) 0);
    if (str.Substring(0, 3) == "ID." && curItemQuantity > 0)
    {
      instance.CheckUseItem((ushort) 1006, (ushort) 0, (ushort) 0, (ushort) 0);
      if (enableMessage)
        NewbieManager.bShowRenameMessage = true;
      NewbieManager.CheckTeach(ETeachKind.FIRST_RENAME, bEntry: true);
      return true;
    }
    if (NewbieManager.m_Self != null && NewbieManager.m_Self.HasTeachFlag(ETeachKind.FIRST_RENAME))
    {
      NewbieManager.m_Self.RemoveFlag(ETeachKind.FIRST_RENAME, (byte) 0);
      NewbieManager.m_Self.RemoveFlag(ETeachKind.FIRST_RENAME, (byte) 1);
    }
    return false;
  }

  public static bool CheckGoldGuy()
  {
    return DataManager.StageDataController.StageRecord[2] >= (ushort) 2 && !NewbieManager.IsWorking() && NewbieManager.EntryTeach(ETeachKind.GOLDGUY);
  }

  public static bool CheckArmyHole(bool JustEntry = false)
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 262144L) != 0L || NewbieManager.EntryLock || DataManager.StageDataController.StageRecord[2] < (ushort) 3 || DataManager.Instance.m_BuffListOpenIcon == (byte) 1)
      return false;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu == (UnityEngine.Object) null || DataManager.StageDataController.currentWorldMode != WorldMode.Wild || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap || (UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null || NewbieManager.IsWorking() || !NewbieManager.EntryTeach(ETeachKind.ARMY_HOLE))
      return false;
    if (JustEntry)
      NewbieManager.EntryTeach(ETeachKind.ARMY_HOLE);
    else
      NewbieManager.CheckTeach(ETeachKind.ARMY_HOLE, bEntry: true);
    return true;
  }

  public static bool CheckActivity(bool JustEntry = false)
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 32768L) == 0L && !NewbieManager.EntryLock)
    {
      bool flag = true;
      if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
        flag = false;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap)
        flag = false;
      if ((UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null)
        flag = false;
      if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1 && GUIManager.Instance.BuildingData.AllBuildsData[1].Level >= (byte) 5 && !NewbieManager.IsWorking() && flag)
      {
        if (JustEntry)
          NewbieManager.EntryTeach(ETeachKind.ACTIVITY);
        else
          NewbieManager.CheckTeach(ETeachKind.ACTIVITY, bEntry: true);
        return true;
      }
    }
    return false;
  }

  public static bool CheckArena(bool JustEntry = false)
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 4L) == 0L && !NewbieManager.EntryLock)
    {
      bool flag = true;
      if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
        flag = false;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap)
        flag = false;
      if ((UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null)
        flag = false;
      if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1 && GUIManager.Instance.BuildingData.AllBuildsData[1].Level >= (byte) 10 && !NewbieManager.IsWorking() && flag)
      {
        if (JustEntry)
          NewbieManager.EntryTeach(ETeachKind.ARENA);
        else
          NewbieManager.CheckTeach(ETeachKind.ARENA, bEntry: true);
        return true;
      }
    }
    return false;
  }

  public static bool CheckBlackmarket(bool JustEntry = false)
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 524288L) == 0L && !NewbieManager.EntryLock)
    {
      bool flag = true;
      if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
        flag = false;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap)
        flag = false;
      if ((UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null)
        flag = false;
      if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1 && GUIManager.Instance.BuildingData.AllBuildsData[1].Level >= (byte) 13 && !NewbieManager.IsWorking() && flag)
      {
        if (JustEntry)
          NewbieManager.EntryTeach(ETeachKind.BLACK_MARKET);
        else
          NewbieManager.CheckTeach(ETeachKind.BLACK_MARKET, bEntry: true);
        return true;
      }
    }
    return false;
  }

  public static bool CheckTroopMemory(bool JustEntry = false)
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 1048576L) == 0L && !NewbieManager.EntryLock)
    {
      bool flag = true;
      if ((UnityEngine.Object) GUIManager.Instance.BuildingData.ManorGride[6] == (UnityEngine.Object) null)
        flag = false;
      if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
        flag = false;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap)
        flag = false;
      if ((UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null)
        flag = false;
      if (DataManager.Instance.GetTechLevel((ushort) 120) > (byte) 0 && !NewbieManager.IsWorking() && flag)
      {
        if (JustEntry)
          NewbieManager.EntryTeach(ETeachKind.TROOP_MEMORY);
        else
          NewbieManager.CheckTeach(ETeachKind.TROOP_MEMORY, bEntry: true);
        return true;
      }
    }
    return false;
  }

  public static bool CheckDeShield()
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 2097152L) == 0L && !NewbieManager.EntryLock)
    {
      bool flag = true;
      if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
        flag = false;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap)
        flag = false;
      if ((UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null)
        flag = false;
      if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1 && GUIManager.Instance.BuildingData.AllBuildsData[1].Level >= (byte) 9 && !NewbieManager.IsWorking() && flag)
      {
        NewbieManager.CheckTeach(ETeachKind.DESHIELD, bEntry: true);
        return true;
      }
    }
    return false;
  }

  public static bool CheckArmyCoord()
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 4194304L) == 0L && !NewbieManager.EntryLock)
    {
      bool flag = true;
      if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
        flag = false;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap)
        flag = false;
      if ((UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null)
        flag = false;
      if ((DataManager.Instance.GetTechLevel((ushort) 136) > (byte) 0 || DataManager.Instance.GetTechLevel((ushort) 137) > (byte) 0) && !NewbieManager.IsWorking() && flag)
      {
        NewbieManager.CheckTeach(ETeachKind.ARMY_COORD, bEntry: true);
        return true;
      }
    }
    return false;
  }

  public static bool CheckNewHero()
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 2048L) == 0L && !NewbieManager.EntryLock && DataManager.StageDataController.StageRecord[2] >= (ushort) 2 && !NewbieManager.IsWorking())
    {
      bool flag = true;
      if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
        flag = false;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap)
        flag = false;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || !menu.bCanRecruit)
        flag = false;
      if ((UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null)
        flag = false;
      if (flag)
      {
        NewbieManager.CheckTeach(ETeachKind.NEW_HERO, bEntry: true);
        return true;
      }
    }
    return false;
  }

  public static bool PreCheckPutOnEquipTeach()
  {
    if (NewbieManager.Get() == null || !NewbieManager.Get().HasTeachFlag(ETeachKind.PUTON_EQUIP))
      return false;
    DataManager instance = DataManager.Instance;
    if (instance.GetLeaderID() == (ushort) 1 && (instance.beCaptured.nowCaptureStat == LoadCaptureState.Captured || instance.beCaptured.nowCaptureStat == LoadCaptureState.Dead))
      return false;
    CurHeroData curHeroData = DataManager.Instance.curHeroData.Find(1U);
    return curHeroData.ID == (ushort) 1 && curHeroData.Enhance == (byte) 1 && curHeroData.Equip == (byte) 62 && DataManager.Instance.GetCurItemQuantity((ushort) 1, (byte) 0) != (ushort) 0;
  }

  public static bool CheckPutOnEquipTeach()
  {
    if (NewbieManager.IsWorking())
      return false;
    if (NewbieManager.PreCheckPutOnEquipTeach())
      return NewbieManager.EntryTeach(ETeachKind.PUTON_EQUIP);
    if (NewbieManager.Get() != null && NewbieManager.Get().HasTeachFlag(ETeachKind.PUTON_EQUIP))
    {
      CurHeroData curHeroData = DataManager.Instance.curHeroData.Find(1U);
      if (curHeroData.ID == (ushort) 1 && (curHeroData.Enhance > (byte) 1 || curHeroData.Equip == (byte) 63))
      {
        NewbieManager.Get().RemoveFlag(ETeachKind.PUTON_EQUIP, (byte) 0);
        NewbieManager.Get().RemoveFlag(ETeachKind.PUTON_EQUIP, (byte) 1);
      }
    }
    return false;
  }

  public static bool CheckWipeOutTeach()
  {
    if (NewbieManager.m_Self == null || NewbieManager.IsWorking() || !NewbieManager.Get().HasTeachFlag(ETeachKind.WIPE_OUT))
      return false;
    StageManager stageDataController = DataManager.StageDataController;
    return (stageDataController._stageMode == StageMode.Full || stageDataController._stageMode == StageMode.Lean) && stageDataController.GetStagePoint((ushort) 0, (byte) 0) >= 3 && NewbieManager.CheckTeach(ETeachKind.WIPE_OUT, bEntry: true);
  }

  public static void CheckWorldTeach()
  {
    if (NewbieManager.m_Self == null || DataManager.Instance.ServerTime - NewbieManager.m_Self.WorldTeach_Point < 300L || NewbieManager.CheckTeach(ETeachKind.GOTO_WORLD, bEntry: true) || NewbieManager.CheckTeach(ETeachKind.WORLD_HUNT, bEntry: true))
      return;
    NewbieManager.CheckTeach(ETeachKind.WORLD_ATTACK, bEntry: true);
  }

  public static void CheckRemovePressXFlag()
  {
    if (NewbieManager.m_Self == null)
      return;
    ulong num = 8388608;
    if (((long) NewbieManager.m_Self.TeachFlag & (long) num) == 0L)
      return;
    NewbieManager.m_Self.RemoveFlag(ETeachKind.PRESS_X, (byte) 0, true);
    NewbieManager.m_Self.RemoveFlag(ETeachKind.PRESS_X, (byte) 1);
  }

  public static bool CheckMetallurgy()
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 16777216L) == 0L && !NewbieManager.EntryLock && GUIManager.Instance.BoxID[0] != (ushort) 0 && GUIManager.Instance.m_WindowStack.Count <= 0)
    {
      bool flag = true;
      if (!NewbieManager.bIgnoreGameplayCheck)
      {
        if (!(GameManager.ActiveGameplay is Origin))
          flag = false;
      }
      else
        NewbieManager.bIgnoreGameplayCheck = false;
      if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
        flag = false;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap)
        flag = false;
      if ((UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null)
        flag = false;
      if (!NewbieManager.IsWorking() && flag)
      {
        NewbieManager.CheckTeach(ETeachKind.METALLURGY, bEntry: true);
        return true;
      }
    }
    return false;
  }

  public static bool CheckGambleNormal()
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 33554432L) == 0L && !NewbieManager.EntryLock && DataManager.StageDataController.StageRecord[2] >= (ushort) 8 && GamblingManager.Instance.m_GambleEventSave.State == EActivityState.EAS_Run)
    {
      GamblingManager.Instance.BattleMonsterID = GamblingManager.Instance.m_GambleEventSave.MonsterID;
      if (!DataManager.CheckGambleBattleResources())
        return false;
      bool flag = true;
      if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
        flag = false;
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap)
        flag = false;
      if ((UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null)
        flag = false;
      if (!NewbieManager.IsWorking() && flag)
      {
        if (NewbieManager.CheckTeach(ETeachKind.GAMBLING1, bEntry: true))
          GamblingManager.Instance.GambleMode = UIBattle_Gambling.eMode.Normal;
        return true;
      }
    }
    return false;
  }

  public static bool CheckGambleElite()
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 67108864L) == 0L && !NewbieManager.EntryLock && BattleController.IsGambleMode && BattleController.GambleMode == EGambleMode.Normal && GamblingManager.Instance.GetRemainFreePlay(UIBattle_Gambling.eMode.Normal) <= (byte) 0 && !GamblingManager.Instance.IsSpecialType(UIBattle_Gambling.eMode.Normal) && DataManager.Instance.CheckPrizeFlag((byte) 9))
    {
      bool flag = true;
      if (!NewbieManager.IsWorking() && flag)
      {
        NewbieManager.CheckTeach(ETeachKind.GAMBLING2, bEntry: true);
        GUIManager.Instance.CloseCheckCrystalBox();
        return true;
      }
    }
    return false;
  }

  public static bool CheckDareFull(bool bFromWild = false)
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 134217728L) == 0L && !NewbieManager.EntryLock && DataManager.StageDataController.StageRecord[1] >= (ushort) 24 && (bFromWild || GUIManager.Instance.m_WindowStack.Count <= 0) && DataManager.StageDataController.StageRecord[3] == (ushort) 0)
    {
      bool flag = true;
      if (!bFromWild)
      {
        if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
          flag = false;
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap)
          flag = false;
        if ((UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null)
          flag = false;
      }
      if (!NewbieManager.IsWorking() && flag)
      {
        if (bFromWild)
        {
          if (NewbieManager.EntryTeach(ETeachKind.DARE_FULL))
          {
            NewbieManager.m_Self.SubStep = 2;
            NewbieManager.CheckTeach(ETeachKind.DARE_FULL);
          }
        }
        else
          NewbieManager.CheckTeach(ETeachKind.DARE_FULL, bEntry: true);
        return true;
      }
    }
    return false;
  }

  public static bool IsLeadNewbiePass
  {
    get => ((long) DataManager.Instance.RoleAttr.Guide & 268435456L) != 0L;
  }

  public static bool CheckDareLead()
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 268435456L) != 0L || NewbieManager.EntryLock || NewbieManager.IsWorking())
      return false;
    NewbieManager.CheckTeach(ETeachKind.DARE_LEAD, bEntry: true);
    return true;
  }

  public static bool CheckSpawnSoldierDetail()
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 536870912L) != 0L || NewbieManager.EntryLock || GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 11 || NewbieManager.IsWorking())
      return false;
    NewbieManager.CheckTeach(ETeachKind.SPAWN_SOLDIER_DETAIL, bEntry: true);
    return true;
  }

  public static bool CheckTreasBoxUpgrade()
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 1073741824L) != 0L || NewbieManager.EntryLock || !MallManager.Instance.bLevelUpPack || NewbieManager.BuildCastleImmediate)
      return false;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu == (UnityEngine.Object) null || DataManager.StageDataController.currentWorldMode != WorldMode.Wild || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap || (UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null || !menu.m_MallGO.activeSelf || NewbieManager.IsWorking())
      return false;
    NewbieManager.CheckTeach(ETeachKind.TREASBOX_UPGRADE, bEntry: true);
    return true;
  }

  public static bool CheckSpawnPet()
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 2147483648L) != 0L || NewbieManager.EntryLock || GUIManager.Instance.BuildingData.AllBuildsData[49].BuildID != (ushort) 20 || NewbieManager.NB_SpawnPetTimeCache != 0L && DataManager.Instance.ServerTime - NewbieManager.NB_SpawnPetTimeCache < 300L || DataManager.StageDataController.StageRecord[2] < (ushort) 8 || ((long) DataManager.Instance.RoleAttr.Guide & 33554432L) == 0L)
      return false;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu == (UnityEngine.Object) null || DataManager.StageDataController.currentWorldMode != WorldMode.Wild || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap || (UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null || NewbieManager.IsWorking())
      return false;
    NewbieManager.CheckTeach(ETeachKind.SPAWN_PET, bEntry: true);
    return true;
  }

  public static bool CheckSpawnPetFromUI()
  {
    if (NewbieManager.IsWorking() || ((long) DataManager.Instance.RoleAttr.Guide & 2147483648L) != 0L || NewbieManager.EntryLock || !NewbieManager.EntryTeach(ETeachKind.SPAWN_PET))
      return false;
    NewbieManager.m_Self.SubStep = 2;
    return NewbieManager.CheckTeach(ETeachKind.SPAWN_PET);
  }

  public static bool CheckPetInfo()
  {
    return !NewbieManager.IsWorking() && ((long) DataManager.Instance.RoleAttr.Guide & 4294967296L) == 0L && !NewbieManager.EntryLock && NewbieManager.CheckTeach(ETeachKind.PET_INFO, bEntry: true);
  }

  public static bool CheckPetFusionBuilding()
  {
    return !NewbieManager.IsWorking() && ((long) DataManager.Instance.RoleAttr.Guide & 8589934592L) == 0L && !NewbieManager.EntryLock && NewbieManager.CheckTeach(ETeachKind.PET_FUSION, bEntry: true);
  }

  public static bool CheckPetTraining()
  {
    return !NewbieManager.IsWorking() && ((long) DataManager.Instance.RoleAttr.Guide & 17179869184L) == 0L && !NewbieManager.EntryLock && NewbieManager.CheckTeach(ETeachKind.PET_TRAINING, bEntry: true);
  }

  public static bool CheckPetSkill()
  {
    if (((long) DataManager.Instance.RoleAttr.Guide & 34359738368L) != 0L || NewbieManager.EntryLock || !PetBuff.UpdateSkill())
      return false;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu == (UnityEngine.Object) null || !menu.m_PetSkillBtnGO.activeSelf || DataManager.StageDataController.currentWorldMode != WorldMode.Wild || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap || (UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null || NewbieManager.IsWorking())
      return false;
    NewbieManager.CheckTeach(ETeachKind.PET_SKILL, bEntry: true);
    return true;
  }

  public static bool CheckPetSkillFromUI()
  {
    if (NewbieManager.IsWorking() || ((long) DataManager.Instance.RoleAttr.Guide & 34359738368L) != 0L || NewbieManager.EntryLock || !PetBuff.UpdateSkill() || !NewbieManager.EntryTeach(ETeachKind.PET_SKILL))
      return false;
    NewbieManager.m_Self.SubStep = 2;
    return NewbieManager.CheckTeach(ETeachKind.PET_SKILL);
  }

  public static bool CheckSocialInvite()
  {
    if (NewbieManager.IsWorking() || ((long) DataManager.Instance.RoleAttr.Guide & 68719476736L) != 0L || NewbieManager.EntryLock || DataManager.Instance.RoleAttr.Invitation == (byte) 0 || GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 7 || DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0 && DataManager.FBMissionDataManager.GetRewardIndex() == (ushort) 0 && (int) DataManager.FBMissionDataManager.GetRewardSerial() == (int) DataManager.FBMissionDataManager.CurMissionProcess.UserSerialNo || DataManager.FBMissionDataManager.m_FBBindEnd || DataManager.Instance.RoleAttr.Inviter.Invited > (byte) 0 && !DataManager.Instance.CheckPrizeFlag((byte) 30) || !NewbieManager.EntryTeach(ETeachKind.SOCIAL_INVITE))
      return false;
    if (((long) DataManager.Instance.RoleAttr.Guide & 137438953472L) != 0L)
    {
      NewbieManager.m_Self.SubStep = 1;
      NewbieManager.m_Self.ActionMap[37001].DelayTime = 0.8f;
    }
    return NewbieManager.CheckTeach(ETeachKind.SOCIAL_INVITE);
  }

  public static bool CheckSocialInviteII()
  {
    if (NewbieManager.IsWorking() || ((long) DataManager.Instance.RoleAttr.Guide & 137438953472L) != 0L || NewbieManager.EntryLock || DataManager.Instance.RoleAttr.Invitation == (byte) 0 || GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 7 || !DataManager.Instance.CheckPrizeFlag((byte) 29))
      return false;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    return !((UnityEngine.Object) menu == (UnityEngine.Object) null) && DataManager.StageDataController.currentWorldMode == WorldMode.Wild && menu.m_eMode == EUIOriginMode.Show && menu.m_eMapMode == EUIOriginMapMode.OriginMap && !((UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null) && !((UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null) && NewbieManager.EntryTeach(ETeachKind.SOCIAL_INVITE_AFTER_MISSION) && NewbieManager.CheckTeach(ETeachKind.SOCIAL_INVITE_AFTER_MISSION);
  }

  public static void EntryTest()
  {
    if (NewbieManager.CheckActivity() || NewbieManager.CheckArena() || NewbieManager.CheckBlackmarket() || NewbieManager.CheckTroopMemory() || NewbieManager.CheckArmyHole() || NewbieManager.CheckDeShield() || NewbieManager.CheckArmyCoord() || NewbieManager.CheckMetallurgy() || NewbieManager.CheckGambleNormal() || NewbieManager.CheckDareFull() || NewbieManager.CheckNewHero() || NewbieManager.CheckTreasBoxUpgrade() || NewbieManager.CheckSpawnPet() || NewbieManager.CheckPetSkill() || !NewbieManager.CheckSocialInviteII())
      ;
  }

  public static void ClearFakeLineData()
  {
    if (NewbieManager.m_Self == null || NewbieManager.m_Self.Controller.m_FlowLineFactoryNewbie == null)
      return;
    NewbieManager.m_Self.Controller.m_FlowLineFactoryNewbie.Clear();
    NewbieManager.m_Self.Controller.m_FlowLineFactoryNewbie = (FlowLineFactoryNewbie) null;
  }

  public static void SetupFakeMonster(int value, LineNode line = null)
  {
    if (NewbieManager.m_Self == null || NewbieManager.m_Self.Controller.Npc_Node == null)
      return;
    if (value == 0)
      NewbieManager.m_Self.Controller.Npc_Node.Hurt();
    else if (value == 1 && line != null)
    {
      NewbieManager.m_Self.Controller.Npc_Node.updateNPC(line);
    }
    else
    {
      if (value != 2 || line == null)
        return;
      NewbieManager.m_Self.Controller.Npc_Node.FighterLeave(line);
    }
  }

  public void MoveNext(object target = null)
  {
    int curTeachKey = NewbieManager.m_Self.GetCurTeachKey();
    NewbieManager.m_Self.ExeAction(curTeachKey, target);
  }

  public void ExeAction(int step, object target = null)
  {
    this.Target = target;
    NewbieManager.NewbieNode newbieNode = (NewbieManager.NewbieNode) null;
    if (!this.ActionMap.TryGetValue(step, out newbieNode))
      return;
    this.ClearOperate();
    this.pAction = newbieNode.StepFunc;
    this.ActionDelay = newbieNode.DelayTime;
    this.WorkingKey = step;
    this.bRunAction = true;
  }

  public void ExeClickAction(int key)
  {
    NewbieManager.ActiveStep activeStep = (NewbieManager.ActiveStep) null;
    if (!this.ClickActionMap.TryGetValue(key, out activeStep))
      return;
    activeStep();
  }

  public void ClearOperate()
  {
    this.NextUI = EGUIWindow.MAX;
    this.NextUIArg1 = 0;
    this.UIOperator = 0;
    this.NextUIObj = (object) null;
    this.WorkingKey = 0;
  }

  public bool IsControlLocked()
  {
    return (bool) (UnityEngine.Object) this.Controller && (bool) (UnityEngine.Object) this.Controller.BlackPanel && ((Component) this.Controller.BlackPanel).gameObject.activeSelf;
  }

  public void LockControl(bool bLock = true)
  {
    if (bLock)
    {
      ((Component) this.Controller.BlackPanel).gameObject.SetActive(true);
      (((Component) this.Controller.BlackPanel).transform as RectTransform).anchoredPosition = Vector2.zero;
      this.Controller.SetBlackVisible(false);
    }
    else
      ((Component) this.Controller.BlackPanel).gameObject.SetActive(false);
  }

  public void NextStep() => this.Controller.TriggerButtonEvent();

  public void SendSetArenaNewbieFlag()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_NEWBIE_FLAG;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public static void SendFinishNewbie()
  {
    GUIManager.Instance.ShowUILock(EUILock.ForceNewbie);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PASSNEWBIE;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void SetupUI(ref Vector2 pos, bool setAP = false, int arg = 0, int arg2 = 0)
  {
    int InKey = this.TeachStep * 100 + this.SubStep;
    NewbieUI recordByKey = DataManager.Instance.NewbieUITable.GetRecordByKey((ushort) InKey);
    if ((int) recordByKey.ID != InKey)
      return;
    this.Controller.SetBlackVisible(true);
    if (recordByKey.TalkType == (byte) 1)
    {
      if (arg2 != 0)
      {
        if (!(bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk))
          GUIManager.Instance.OpenMenu(EGUIWindow.UI_PriestTalk, (int) recordByKey.TalkID, arg);
        else
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_PriestTalk, (int) recordByKey.TalkID, arg);
      }
      else if (!(bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk))
        GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_PriestTalk, (int) recordByKey.TalkID, arg);
      else
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_PriestTalk, (int) recordByKey.TalkID, arg);
    }
    else
    {
      if (recordByKey.TouchWidth == (ushort) 0 && recordByKey.TouchHeight == (ushort) 0)
      {
        Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
        recordByKey.TouchWidth = (ushort) ((double) sizeDelta.x * 2.0);
        recordByKey.TouchHeight = (ushort) ((double) sizeDelta.y * 2.0);
      }
      this.Controller.SetHoleVisible(true, new Rect?(new Rect(pos.x, pos.y, (float) recordByKey.TouchWidth, (float) recordByKey.TouchHeight)), setAP: setAP);
      if (recordByKey.ArrowDir > (byte) 0 && recordByKey.ArrowDir <= (byte) 4)
        this.Controller.SetArrow(true, (EArrowDir) ((int) recordByKey.ArrowDir - 1));
      if (recordByKey.TalkType != (byte) 2)
        return;
      Vector2 zero = Vector2.zero with
      {
        x = (float) recordByKey.TalkBoxX * (recordByKey.TalkBoxX_Sign == (byte) 0 ? 1f : -1f),
        y = (float) recordByKey.TalkBoxY * (recordByKey.TalkBoxY_Sign == (byte) 0 ? 1f : -1f)
      };
      this.Controller.SetText(recordByKey.TalkID, zero);
    }
  }

  public static void CheckShowArrow(bool bShow, GameObject Obj = null)
  {
    if (NewbieManager.m_Self == null)
      return;
    if (bShow)
    {
      StageManager stageDataController = DataManager.StageDataController;
      if (stageDataController._stageMode != StageMode.Full || stageDataController.StageRecord[0] == (ushort) 0 || stageDataController.StageRecord[0] > (ushort) 5 || (UnityEngine.Object) Obj == (UnityEngine.Object) null)
        return;
      Vector2 vector2 = (Vector2) Camera.main.WorldToScreenPoint(Obj.transform.position) / GUIManager.Instance.m_UICanvas.scaleFactor + new Vector2(0.0f, 100f);
      NewbieManager.m_Self.Controller.SetStageArrow(true, new Vector2?(vector2));
    }
    else
      NewbieManager.m_Self.Controller.SetStageArrow(false);
  }

  public bool PreTriggerCheck()
  {
    if (!this.IsSpecialKey() || this.bTargeting)
      return true;
    UIBattle target = this.Target as UIBattle;
    if ((UnityEngine.Object) target == (UnityEngine.Object) null)
      return false;
    target.bc.setupProjector(false, ref target.projectorType);
    target.projectorTrans = (Transform) null;
    target.SetTeachProjector(false);
    this.Controller.SetBlackVisible(true);
    this.Controller.ShowPointer(true);
    return false;
  }

  public bool IsSpecialKey() => this.WorkingKey == 8010 || this.WorkingKey == 8011;

  public void DisplayBarrackQueue()
  {
    if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 5)
    {
      GUIManager.Instance.BuildingData.AllBuildsData[5].BuildID = (ushort) 6;
      GUIManager.Instance.BuildingData.AllBuildsData[5].Level = (byte) 0;
    }
    GUIManager.Instance.BuildingData.BuildingManorID = (ushort) 5;
    GUIManager.Instance.BuildingData.QueueBuildType = (byte) 1;
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 2, GUIManager.Instance.BuildingData.BuildingManorID);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 10, (ushort) 1);
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, true, DataManager.Instance.ServerTime, 90U);
  }

  public void DisplayCastleQueue()
  {
    if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1)
    {
      GUIManager.Instance.BuildingData.AllBuildsData[1].BuildID = (ushort) 8;
      GUIManager.Instance.BuildingData.AllBuildsData[1].Level = (byte) 1;
    }
    GUIManager.Instance.BuildingData.BuildingManorID = (ushort) 1;
    GUIManager.Instance.BuildingData.QueueBuildType = (byte) 1;
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 2, GUIManager.Instance.BuildingData.BuildingManorID);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 10, (ushort) 1);
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, true, DataManager.Instance.ServerTime, 90U);
  }

  public static void SetNewbieControlLock(bool bLock)
  {
    if (!NewbieManager.IsWorking() || NewbieManager.m_Self.WorkingKey / 1000 != 8)
      return;
    NewbieManager.m_Self.LockControl(bLock);
  }

  public void IgnoreStep(bool bExitTeach, int MoveToSubStepIdx = -1)
  {
    if (bExitTeach)
    {
      this.Controller.HideUI();
      if ((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) != (UnityEngine.Object) null)
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_PriestTalk);
      if (this.TeachStep != 0)
        this.RemoveFlag((ETeachKind) (this.TeachStep - 1), (byte) 1);
      this.LockControl(false);
    }
    else
    {
      if (MoveToSubStepIdx == -1 || this.TeachStep == 0)
        return;
      this.Controller.HideUI();
      this.SubStep = MoveToSubStepIdx;
      NewbieManager.CheckTeach((ETeachKind) (this.TeachStep - 1), this.Target);
    }
  }

  public Vector2 LocalToScreenPoint(Transform t)
  {
    return (Vector2) Camera.main.WorldToScreenPoint(t.position) / GUIManager.Instance.m_UICanvas.scaleFactor;
  }

  public void SuckBugProtector()
  {
    this.Controller.HideUI(true);
    GUIManager.Instance.CloseMenu(EGUIWindow.UI_PriestTalk);
  }

  public Vector2 CheckMirror(Vector2 pos)
  {
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform canvasRt = GUIManager.Instance.pDVMgr.CanvasRT;
      float num = pos.x - canvasRt.sizeDelta.x * 0.5f;
      pos.x -= num * 2f;
    }
    return pos;
  }

  public void WaitForIntoScene()
  {
    this.FinishStep(false);
    NewbieManager.CheckNewbie();
  }

  public void ShowDrama()
  {
    if (!DataManager.Instance.MySysSetting.bShowTimeBar)
      DataManager.Instance.MySysSetting.bShowTimeBar = true;
    GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_HeroTalk, 13, 1);
    NewbieLog.Log(ENewbieLogKind.FORCE_2, (byte) 0);
  }

  public void RecvShowDrama() => NewbieManager.CheckNewbie();

  public void FirstIntoDoor()
  {
    this.Controller.SetBlackVisible(true);
    GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_PriestTalk, 1488);
    NewbieLog.Log(ENewbieLogKind.FORCE_2, (byte) 1);
  }

  public void RecvFirstIntoDoor() => NewbieManager.CheckNewbie();

  public void Step1TargetGoal()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && (UnityEngine.Object) menu.m_MissionHintTrans != (UnityEngine.Object) null)
    {
      Vector2 vector2 = this.UIController.ScreenPointTest((RectTransform) menu.m_MissionHintTrans.GetChild(1));
      this.Controller.SetBlackVisible(true);
      this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 170f, 100f)), setAP: true);
      this.Controller.SetArrow(true);
      this.Controller.SetText((ushort) 8078, new Vector2(0.0f, 85f));
    }
    NewbieLog.Log(ENewbieLogKind.FORCE_2, (byte) 2);
  }

  public void RecvStep1TargetGoal()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && (UnityEngine.Object) menu.m_MissionHintTrans != (UnityEngine.Object) null)
      menu.OnButtonClick(menu.m_MissionBtn);
    NewbieManager.CheckNewbie();
  }

  public void TargetManor()
  {
    Vector2 vector2 = this.CheckMirror((Vector2) Camera.main.WorldToScreenPoint(GUIManager.Instance.BuildingData.ManorGride[1].position) / GUIManager.Instance.m_UICanvas.scaleFactor + new Vector2(0.0f, 33.188f));
    this.Controller.SetBlackVisible(true);
    this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 140f, 140f)));
    this.Controller.SetArrow(true);
    this.NextUI = EGUIWindow.UI_SuitBuilding;
    this.NextUIArg1 = 5;
    NewbieLog.Log(ENewbieLogKind.FORCE_2, (byte) 3);
  }

  public void FirstIntoSuitBuilding()
  {
    UISuitBuilding target = this.Target as UISuitBuilding;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      Vector2 vector2 = this.UIController.ScreenPointTest(target.scrollPanel.m_PanelObjects[0].rectTransform);
      this.Controller.SetBlackVisible(true);
      this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 670f, 220f)));
      this.Controller.SetArrow(true);
      this.NextUI = EGUIWindow.UI_Barrack;
      this.NextUIArg1 = 5;
    }
    NewbieLog.Log(ENewbieLogKind.FORCE_2, (byte) 4);
  }

  public void FirstIntoBarrack()
  {
    UIBarrack target = this.Target as UIBarrack;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      Vector2 vector2 = this.UIController.ScreenPointTest(target.baseBuild.upgradeBtnRect);
      this.Controller.SetBlackVisible(true);
      this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 160f, 160f)));
      this.Controller.SetArrow(true);
      this.NextUI = EGUIWindow.UI_Barrack;
    }
    NewbieLog.Log(ENewbieLogKind.FORCE_2, (byte) 5);
  }

  public void RecvBarrackUpgrade()
  {
    this.FakeBuildStep = (byte) 1;
    this.DisplayBarrackQueue();
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu(true);
    this.CurFakeData = (ushort) 2;
    this.SetupFakeData((int) this.CurFakeData);
    NewbieManager.CheckNewbie();
  }

  public void ExitBarrackToDoor()
  {
    UIButton funtionBtn = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).m_QueueTimeBar[0].m_FuntionBtn;
    if ((UnityEngine.Object) funtionBtn != (UnityEngine.Object) null)
    {
      Vector2 vector2 = this.UIController.ScreenPointTest(((Component) funtionBtn).gameObject.transform as RectTransform);
      this.Controller.SetBlackVisible(true);
      this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 150f, 120f)), setAP: true);
      this.Controller.SetArrow(true);
      this.Controller.SetText((ushort) 1573, new Vector2(0.0f, -85f));
    }
    NewbieLog.Log(ENewbieLogKind.FORCE_2, (byte) 6);
  }

  public void RecvBarrackToDoor()
  {
    this.FakeBuildStep = (byte) 0;
    this.FakeBuildLvStep = (byte) 1;
    GUIManager.Instance.BuildingData.BuildingManorID = (ushort) 0;
    if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 5)
      GUIManager.Instance.BuildingData.AllBuildsData[5].Level = (byte) 1;
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 3, (ushort) 5);
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0U);
    NewbieManager.CheckNewbie();
  }

  public void WaitBuilding()
  {
    ++this.SubStep;
    NewbieManager.CheckNewbie();
    GUIManager.Instance.BuildingData.NeedSortData = true;
    DataManager.MissionDataManager.SetCompleteWhileLogin(eMissionKind.Build);
    this.FakeMarkStep = (byte) 1;
  }

  public void Step1TargetPrize()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && (UnityEngine.Object) menu.m_MissionHintTrans != (UnityEngine.Object) null)
    {
      Vector2 vector2 = this.UIController.ScreenPointTest((RectTransform) menu.m_MissionHintTrans.GetChild(1));
      this.Controller.SetBlackVisible(true);
      this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 170f, 100f)), setAP: true);
      this.Controller.SetArrow(true);
      this.Controller.SetText((ushort) 1575, new Vector2(0.0f, 85f));
    }
    NewbieLog.Log(ENewbieLogKind.FORCE_2, (byte) 7);
  }

  public void Step1RecvTargetPrize()
  {
    this.FinishStep();
    this.CurFakeData = (ushort) 3;
    this.FakeBuildLvStep = (byte) 2;
    this.SetupFakeData((int) this.CurFakeData);
    NewbieManager.CheckNewbie();
    DataManager.MissionDataManager.sendMissionComplete((ushort) 6, (ushort) 0);
    GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7945U), (ushort) 11);
    GUIManager.Instance.mStartV2 = new Vector2((float) ((double) ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x / 2.0 - 141.5), ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.y - 100f);
    Array.Clear((Array) GUIManager.Instance.SE_Kind, 0, GUIManager.Instance.SE_Kind.Length);
    Array.Clear((Array) GUIManager.Instance.m_SpeciallyEffect.mResValue, 0, GUIManager.Instance.m_SpeciallyEffect.mResValue.Length);
    Array.Clear((Array) GUIManager.Instance.SE_ItemID, 0, GUIManager.Instance.SE_ItemID.Length);
    GUIManager.Instance.SE_Kind[0] = SpeciallyEffect_Kind.Food;
    GUIManager.Instance.SE_Kind[1] = SpeciallyEffect_Kind.Stone;
    GUIManager.Instance.SE_Kind[2] = SpeciallyEffect_Kind.Wood;
    GUIManager.Instance.SE_Kind[3] = SpeciallyEffect_Kind.Iron;
    GUIManager.Instance.SE_Kind[4] = SpeciallyEffect_Kind.Money;
    GUIManager.Instance.mStartV2 = new Vector2((float) ((double) ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x / 2.0 - 141.5), ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.y - 100f);
    GUIManager.Instance.m_SpeciallyEffect.AddIconShow(GUIManager.Instance.mStartV2, GUIManager.Instance.SE_Kind, GUIManager.Instance.SE_ItemID);
  }

  public void IntoUpdateCastle()
  {
    this.Controller.SetBlackVisible(true);
    GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_PriestTalk, 1570);
    NewbieLog.Log(ENewbieLogKind.FORCE_3, (byte) 0);
  }

  public void RecvIntoUpdateCastle() => NewbieManager.CheckNewbie();

  public void Step2TargetGoal()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && (UnityEngine.Object) menu.m_MissionHintTrans != (UnityEngine.Object) null)
    {
      Vector2 vector2 = this.UIController.ScreenPointTest((RectTransform) menu.m_MissionHintTrans.GetChild(1));
      this.Controller.SetBlackVisible(true);
      this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 170f, 100f)), setAP: true);
      this.Controller.SetArrow(true);
      this.Controller.SetText((ushort) 8078, new Vector2(0.0f, 85f));
    }
    NewbieLog.Log(ENewbieLogKind.FORCE_3, (byte) 1);
  }

  public void RecvStep2TargetGoal()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && (UnityEngine.Object) menu.m_MissionHintTrans != (UnityEngine.Object) null)
      menu.OnButtonClick(menu.m_MissionBtn);
    NewbieManager.CheckNewbie();
  }

  public void TargetCastle()
  {
    Vector2 vector2 = this.CheckMirror((Vector2) Camera.main.WorldToScreenPoint(GUIManager.Instance.BuildingData.ManorGride[0].position) / GUIManager.Instance.m_UICanvas.scaleFactor + new Vector2(2f, 112.641f));
    this.Controller.SetBlackVisible(true);
    this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 290f, (float) byte.MaxValue)));
    this.Controller.SetArrow(true);
    this.NextUI = EGUIWindow.UI_Castle;
    this.NextUIArg1 = 1;
    NewbieLog.Log(ENewbieLogKind.FORCE_3, (byte) 2);
  }

  public void IntoUICastle()
  {
    UICastle target = this.Target as UICastle;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      Vector2 vector2 = this.UIController.ScreenPointTest(target.baseBuild.upgradeBtnRect);
      this.Controller.SetBlackVisible(true);
      this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 160f, 160f)));
      this.Controller.SetArrow(true);
    }
    NewbieLog.Log(ENewbieLogKind.FORCE_3, (byte) 3);
  }

  public void RecvIntoUICastle()
  {
    UICastle target = this.Target as UICastle;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
      target.baseBuild.OnButtonClick(target.baseBuild.upgradeBtn);
    NewbieManager.CheckNewbie(this.Target);
  }

  public void IntoCastleUpgrade()
  {
    UICastle target = this.Target as UICastle;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      Vector2 vector2 = this.UIController.ScreenPointTest(target.baseBuild.upgradeBtnRect);
      this.Controller.SetBlackVisible(true);
      this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 160f, 160f)));
      this.Controller.SetArrow(true);
    }
    NewbieLog.Log(ENewbieLogKind.FORCE_3, (byte) 4);
  }

  public void RecvIntoCastleUpgrade()
  {
    this.FakeBuildStep = (byte) 2;
    this.DisplayCastleQueue();
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu(true);
    this.CurFakeData = (ushort) 4;
    this.SetupFakeData((int) this.CurFakeData);
    NewbieManager.CheckNewbie();
  }

  public void CastleUpgradeRightNow()
  {
    UIButton funtionBtn = (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).m_QueueTimeBar[0].m_FuntionBtn;
    if ((UnityEngine.Object) funtionBtn != (UnityEngine.Object) null)
    {
      Vector2 vector2 = this.UIController.ScreenPointTest(((Component) funtionBtn).gameObject.transform as RectTransform);
      this.Controller.SetBlackVisible(true);
      this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 150f, 120f)), setAP: true);
      this.Controller.SetArrow(true);
    }
    NewbieLog.Log(ENewbieLogKind.FORCE_3, (byte) 5);
  }

  public void RecvCastleUpgradeRightNow()
  {
    this.FakeBuildStep = (byte) 0;
    this.FakeBuildLvStep = (byte) 3;
    GUIManager.Instance.BuildingData.BuildingManorID = (ushort) 0;
    if (GUIManager.Instance.BuildingData.AllBuildsData.Length > 1)
      GUIManager.Instance.BuildingData.AllBuildsData[1].Level = (byte) 2;
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 3, (ushort) 1);
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0U);
    object target = (object) GUIManager.Instance.OpenMenu(EGUIWindow.UI_CastleUpgradeReward, 2, bSecWindow: true);
    DataManager.MissionDataManager.SetCompleteWhileLogin(eMissionKind.Build);
    this.FakeMarkStep = (byte) 2;
    this.CurFakeData = (ushort) 5;
    this.SetupFakeData((int) this.CurFakeData);
    NewbieManager.CheckNewbie(target);
  }

  public void IntoLevelUpUI()
  {
    UICastleUpgradeReward target = this.Target as UICastleUpgradeReward;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      Vector2 vector2 = this.UIController.ScreenPointTest(target.ExitBtn);
      this.Controller.SetBlackVisible(true);
      this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 120f, 120f)), setAP: true);
      this.Controller.SetArrow(true);
      this.Controller.SetText((ushort) 1574, new Vector2(0.0f, -85f));
    }
    NewbieLog.Log(ENewbieLogKind.FORCE_3, (byte) 6);
  }

  public void RecvIntoLevelUpUI()
  {
    GUIManager.Instance.CloseMenu(EGUIWindow.UI_CastleUpgradeReward);
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    NewbieManager.CheckNewbie();
  }

  public void Step2TargetPrize()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && (UnityEngine.Object) menu.m_MissionHintTrans != (UnityEngine.Object) null)
    {
      Vector2 vector2 = this.UIController.ScreenPointTest((RectTransform) menu.m_MissionHintTrans.GetChild(1));
      this.Controller.SetBlackVisible(true);
      this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 170f, 100f)), setAP: true);
      this.Controller.SetArrow(true);
      this.Controller.SetText((ushort) 1575, new Vector2(0.0f, 85f));
    }
    NewbieLog.Log(ENewbieLogKind.FORCE_3, (byte) 7);
  }

  public void Step2RecvTargetPrize()
  {
    this.FinishStep();
    this.CurFakeData = (ushort) 6;
    this.FakeBuildLvStep = (byte) 4;
    this.SetupFakeData((int) this.CurFakeData);
    NewbieManager.CheckNewbie();
    DataManager.MissionDataManager.sendMissionComplete((ushort) 33, (ushort) 0);
    GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7945U), (ushort) 11);
    GUIManager.Instance.mStartV2 = new Vector2((float) ((double) ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x / 2.0 - 141.5), ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.y - 100f);
    Array.Clear((Array) GUIManager.Instance.SE_Kind, 0, GUIManager.Instance.SE_Kind.Length);
    Array.Clear((Array) GUIManager.Instance.m_SpeciallyEffect.mResValue, 0, GUIManager.Instance.m_SpeciallyEffect.mResValue.Length);
    Array.Clear((Array) GUIManager.Instance.SE_ItemID, 0, GUIManager.Instance.SE_ItemID.Length);
    GUIManager.Instance.SE_Kind[0] = SpeciallyEffect_Kind.Food;
    GUIManager.Instance.SE_Kind[1] = SpeciallyEffect_Kind.Stone;
    GUIManager.Instance.SE_Kind[2] = SpeciallyEffect_Kind.Wood;
    GUIManager.Instance.SE_Kind[3] = SpeciallyEffect_Kind.Iron;
    GUIManager.Instance.SE_Kind[4] = SpeciallyEffect_Kind.Money;
    GUIManager.Instance.mStartV2 = new Vector2((float) ((double) ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x / 2.0 - 141.5), ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.y - 100f);
    GUIManager.Instance.m_SpeciallyEffect.AddIconShow(GUIManager.Instance.mStartV2, GUIManager.Instance.SE_Kind, GUIManager.Instance.SE_ItemID);
  }

  public void IntoGetPrize()
  {
    this.Controller.SetBlackVisible(true);
    GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_PriestTalk, 1572);
    NewbieLog.Log(ENewbieLogKind.FORCE_4, (byte) 0);
  }

  public void RecvIntoGetPrize()
  {
    this.DM.RoleAttr.VipPoint = 10U;
    this.DM.RoleAttr.VIPLevel = this.DM.GetVIPLevel(this.DM.RoleAttr.VipPoint);
    DataManager.MissionDataManager.UpdateVipState();
    GameManager.OnRefresh();
    GUIManager.Instance.OpenMenu(EGUIWindow.UI_VipLevelUp, (int) DataManager.Instance.RoleAttr.VIPLevel, 2, bSecWindow: true);
    NewbieManager.CheckNewbie();
  }

  public void VipLevelUp()
  {
    UIVIPLevelUP menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_VipLevelUp) as UIVIPLevelUP;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    RectTransform bgRt = menu.BG_Rt;
    Vector2 vector2_1 = ((RectTransform) ((Transform) bgRt).GetChild(1)).sizeDelta * 1.1f;
    Vector2 vector2_2 = this.UIController.ScreenPointTest(bgRt);
    this.Controller.SetBlackVisible(true);
    this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2_2.x, vector2_2.y + 30f, vector2_1.x, vector2_1.y)), setAP: true);
    this.Controller.SetText((ushort) 7743, new Vector2(0.0f, (float) ((double) vector2_1.y * -0.5 - 30.0)));
  }

  public void RecvVipLevelUp() => NewbieManager.CheckNewbie();

  public void VipLevelUp2()
  {
    UIVIPLevelUP menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_VipLevelUp) as UIVIPLevelUP;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 vector2 = this.UIController.ScreenPointTest(((Component) menu.CloseBtn).transform as RectTransform);
    this.Controller.SetBlackVisible(true);
    this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 120f, 120f)), setAP: true);
    this.Controller.SetArrow(true);
    this.Controller.SetText((ushort) 8079, new Vector2(0.0f, -90f));
  }

  public void RecvVipLevelUp2()
  {
    GUIManager.Instance.CloseMenu(EGUIWindow.UI_VipLevelUp);
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    NewbieManager.CheckNewbie();
  }

  public void Step3Talk2()
  {
    this.Controller.SetBlackVisible(true);
    GUIManager.Instance.OpenOtherCanvasMenu(EGUIWindow.UI_PriestTalk, 1571);
    NewbieLog.Log(ENewbieLogKind.FORCE_4, (byte) 1);
  }

  public void RecvStep3Talk2() => NewbieManager.CheckNewbie();

  public void TargetPrize()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && (UnityEngine.Object) menu.m_MissionHintTrans != (UnityEngine.Object) null)
    {
      Vector2 vector2 = this.UIController.ScreenPointTest((RectTransform) menu.m_MissionHintTrans.GetChild(1));
      this.Controller.SetBlackVisible(true);
      this.Controller.SetHoleVisible(true, new Rect?(new Rect(vector2.x, vector2.y, 170f, 100f)), setAP: true);
      this.Controller.SetArrow(true);
      this.Controller.SetText((ushort) 8078, new Vector2(0.0f, 85f));
    }
    NewbieLog.Log(ENewbieLogKind.FORCE_4, (byte) 2);
  }

  public void RecvTargetPrize()
  {
    bool result = true;
    bool.TryParse(PlayerPrefs.GetString("Other_bShowTimeBar"), out result);
    if (!result)
      DataManager.Instance.MySysSetting.bShowTimeBar = false;
    this.LockControl(false);
    this.FinishStep();
    NewbieManager.SendFinishNewbie();
    IGGSDKPlugin.SetFacebookEventCompletedTutorial();
    AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.TUTORIAL_COMPLETION);
    this.DM.GetSysSettingSave();
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Newbie);
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || !((UnityEngine.Object) menu.m_MissionHintTrans != (UnityEngine.Object) null))
      return;
    menu.OnButtonClick(menu.m_MissionBtn);
  }

  public void SpawnSoldier()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvSpawnSoldier()
  {
    NewbieManager.CheckTeach(ETeachKind.SPAWN_SOLDIERS, this.Target);
  }

  public void TargetSoldierItem()
  {
    UIBarrack target = this.Target as UIBarrack;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) target.tmpItemBtn[3]).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvTargetSoldierItem()
  {
    UIBarrack target = this.Target as UIBarrack;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    target.OnButtonClick(target.tmpItemBtn[3]);
  }

  public void TargetTrain()
  {
    UIBarrack_Soldier target = this.Target as UIBarrack_Soldier;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) target.btn_Training).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvTargetTrain()
  {
    UIBarrack_Soldier target = this.Target as UIBarrack_Soldier;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    if (target.btn_Training.m_BtnType == e_BtnType.e_ChangeText)
      this.IgnoreStep(true);
    target.OnButtonClick(target.btn_Training);
  }

  public void FinishTrain()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvFinishTrain() => NewbieManager.CheckTeach(ETeachKind.SPAWN_SOLDIERS);

  public void FinishTrain2()
  {
    UIBarrack menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Barrack) as UIBarrack;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) menu.baseBuild.exitBtn).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvFinishTrain2()
  {
    this.RemoveFlag(ETeachKind.SPAWN_SOLDIERS, (byte) 1);
    this.LockControl(false);
    GUIManager.Instance.SetFrontMark((byte) 1);
    UIBarrack menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Barrack) as UIBarrack;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.baseBuild.OnButtonClick(menu.baseBuild.exitBtn);
  }

  public void Into_WarScout()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void Recv_Into_WarScout() => NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT);

  public void WarScout_TargetCastle()
  {
    if (!(GameManager.ActiveGameplay is Origin activeGameplay))
      return;
    Vector2 pos = this.CheckMirror((Vector2) Camera.main.WorldToScreenPoint(activeGameplay.WorldController.CastleObj.transform.position) / GUIManager.Instance.m_UICanvas.scaleFactor + new Vector2(0.0f, 27.188f));
    this.SetupUI(ref pos);
  }

  public void Recv_WarScout_TargetCastle()
  {
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).m_GroundInfo.OpenPvePanel(true, (ushort) ((uint) DataManager.StageDataController.StageRecord[2] + 1U));
  }

  public void TargetScout()
  {
    Vector2 pos = this.UIController.ScreenPointTest(((Transform) (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).m_GroundInfo.m_PvePanel).GetChild(10) as RectTransform);
    this.SetupUI(ref pos, true);
  }

  public void RecvTargetScout()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    UIButton component = ((Transform) menu.m_GroundInfo.m_PvePanel).GetChild(10).GetComponent<UIButton>();
    menu.m_GroundInfo.OnButtonClick(component);
  }

  public void TargetScoutInfo()
  {
    UIDevelopmentDetails target = this.Target as UIDevelopmentDetails;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    RectTransform rectTransform1 = target.tmpPanel.getScrollPanel().m_PanelObjects[0].rectTransform;
    Vector2 vector2 = this.UIController.ScreenPointTest(rectTransform1);
    RectTransform rectTransform2 = target.tmpPanel.getScrollPanel().m_PanelObjects[1].rectTransform;
    Vector2 pos = vector2 + new Vector2(0.0f, (float) -(((double) rectTransform1.sizeDelta.y + (double) rectTransform2.sizeDelta.y) * 0.5));
    this.SetupUI(ref pos);
  }

  public void RecvTargetScoutInfo() => NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, this.Target);

  public void TargetScoutInfoExit()
  {
    UIDevelopmentDetails target = this.Target as UIDevelopmentDetails;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) target.btn_EXIT).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvTargetScoutInfoExit()
  {
    UIDevelopmentDetails target = this.Target as UIDevelopmentDetails;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    target.OnButtonClick(target.btn_EXIT);
  }

  public void Into_WarAttack()
  {
    Vector2 pos = this.UIController.ScreenPointTest(((Transform) (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).m_GroundInfo.m_PvePanel).GetChild(11) as RectTransform);
    this.SetupUI(ref pos, true);
  }

  public void Recv_Into_WarAttack()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    UIButton component = ((Transform) menu.m_GroundInfo.m_PvePanel).GetChild(11).GetComponent<UIButton>();
    menu.m_GroundInfo.OnButtonClick(component);
  }

  public void Team_Select()
  {
    UIExpedition target = this.Target as UIExpedition;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(target.gameObject.transform.GetChild(2) as RectTransform);
    this.SetupUI(ref pos);
  }

  public void Recv_Team_Select() => NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, this.Target);

  public void Soldier_Select()
  {
    UIExpedition target = this.Target as UIExpedition;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(target.gameObject.transform.GetChild(3) as RectTransform);
    this.SetupUI(ref pos);
  }

  public void Recv_Soldier_Select() => NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, this.Target);

  public void Fight_Select()
  {
    UIExpedition target = this.Target as UIExpedition;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) target.btn_Expedition).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void Recv_Fight_Select()
  {
    UIExpedition target = this.Target as UIExpedition;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
      target.OnButtonClick(target.btn_Expedition);
    this.RemoveFlag(ETeachKind.WAR_SCOUT, (byte) 1);
    this.LockControl(false);
  }

  public void IntoCollege()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvIntoCollege() => NewbieManager.CheckTeach(ETeachKind.COLLEGE, this.Target);

  public void TargetMilitary()
  {
    UITechInstitute target = this.Target as UITechInstitute;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) target.TechItem[0].Button[2]).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvTargetMilitary()
  {
    UITechInstitute target = this.Target as UITechInstitute;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    target.OnButtonClick(target.TechItem[0].Button[2]);
  }

  public void TargetTopSkill()
  {
    UITechTree target = this.Target as UITechTree;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) target.TreeLayer[0].Tech[1].TechBtn).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvTargetTopSkill()
  {
    UITechTree target = this.Target as UITechTree;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    target.OnButtonClick(target.TreeLayer[0].Tech[1].TechBtn);
    NewbieManager.CheckTeach(ETeachKind.COLLEGE, this.Target);
  }

  public void TargetTechInfo()
  {
    UITechTree target = this.Target as UITechTree;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) target.InfoWindow.ConfirmBtn).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvTargetTechInfo()
  {
    UITechTree target = this.Target as UITechTree;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    target.InfoWindow.OnButtonClick(target.InfoWindow.ConfirmBtn);
  }

  public void TechUpgrade()
  {
    UITechUpgrade target = this.Target as UITechUpgrade;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(target.buildWin.upgradeBtnRect);
    this.SetupUI(ref pos);
  }

  public void RecvTechUpgrade()
  {
    UITechUpgrade target = this.Target as UITechUpgrade;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    if (target.buildWin.upgradeBtn.m_BtnID2 == 100)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5771U), (ushort) byte.MaxValue);
      this.RemoveFlag(ETeachKind.COLLEGE, (byte) 1);
      this.LockControl(false);
    }
    else
      target.buildWin.OnButtonClick(target.buildWin.upgradeBtn);
  }

  public void TechFinish()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvTechFinish()
  {
    this.RemoveFlag(ETeachKind.COLLEGE, (byte) 1);
    this.LockControl(false);
  }

  public void Rename()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvRename()
  {
    this.RemoveFlag(ETeachKind.FIRST_RENAME, (byte) 1);
    this.LockControl(false);
  }

  public void GotoWorld()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
    this.Controller.SetSpecialBox(true, (byte) 0);
    this.Controller.PreClickFlag = 1;
  }

  public void RecvGotoWorld() => this.MoveNext();

  public void GotoWorld2()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  public void RecvGotoWorld2() => this.MoveNext();

  public void GotoWorld3()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
    this.Controller.PreClickFlag = 0;
  }

  public void RecvGotoWorld3() => this.MoveNext();

  public void GotoWorld4()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) ((Component) menu.m_MapSwitchButton).GetComponent<UIButton>()).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvGotoWorld4()
  {
    this.RemoveFlag(ETeachKind.GOTO_WORLD, (byte) 1);
    this.LockControl(false);
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      UIButton component = ((Component) menu.m_MapSwitchButton).GetComponent<UIButton>();
      menu.OnButtonClick(component);
    }
    this.SuckBugProtector();
    this.WorldTeach_Point = DataManager.Instance.ServerTime;
  }

  public void Battle_Before()
  {
    if (!this.IsControlLocked())
      this.LockControl();
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void Recv_Battle_Before() => NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE);

  public void TargetLord()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.ForceQueueBarOpenClose(false);
    if (!((UnityEngine.Object) NewbieManager.pTrans != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.CheckMirror((Vector2) Camera.main.WorldToScreenPoint(NewbieManager.pTrans.position) / GUIManager.Instance.m_UICanvas.scaleFactor + new Vector2(0.0f, 34f));
    this.SetupUI(ref pos);
    NewbieManager.pTrans = (Transform) null;
  }

  public void Recv_TargetLord()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.OpenMenu(EGUIWindow.UI_StageInfo, bCameraMode: true);
  }

  public void IntoStageInfo()
  {
    UIStageInfo target = this.Target as UIStageInfo;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(target.transform.GetChild(21).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void Recv_IntoStageInfo()
  {
    UIStageInfo target = this.Target as UIStageInfo;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    UIButton component = target.transform.GetChild(21).GetComponent<UIButton>();
    target.OnButtonClick(component);
  }

  public void BattleSelect_S1()
  {
    UIBattleHeroSelect target = this.Target as UIBattleHeroSelect;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(target.m_HerosView.transform.GetChild(0).GetChild(0) as RectTransform);
    this.SetupUI(ref pos);
  }

  public void Recv_BattleSelect_S1()
  {
    UIBattleHeroSelect target = this.Target as UIBattleHeroSelect;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      UIHIBtn component = target.m_HerosView.transform.GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<UIHIBtn>();
      target.OnHIButtonClick(component);
    }
    NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, this.Target);
  }

  public void BattleSelect_S2()
  {
    UIBattleHeroSelect target = this.Target as UIBattleHeroSelect;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(target.m_HerosView.transform.GetChild(0).GetChild(1) as RectTransform);
    this.SetupUI(ref pos);
  }

  public void Recv_BattleSelect_S2()
  {
    UIBattleHeroSelect target = this.Target as UIBattleHeroSelect;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      UIHIBtn component = target.m_HerosView.transform.GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<UIHIBtn>();
      target.OnHIButtonClick(component);
    }
    NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, this.Target);
  }

  public void BattleSelect_Start()
  {
    UIBattleHeroSelect target = this.Target as UIBattleHeroSelect;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(target.transform.GetChild(15) as RectTransform);
    this.SetupUI(ref pos);
  }

  public void Recv_BattleSelect_Start()
  {
    UIBattleHeroSelect target = this.Target as UIBattleHeroSelect;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    UIButton component = target.transform.GetChild(15).gameObject.GetComponent<UIButton>();
    target.OnButtonClick(component);
  }

  public void Battle_StartNewbie() => ++this.SubStep;

  public void Battle_NextLevel()
  {
    if (!(this.Target is BattleController target))
      return;
    UIBattle uiBattle = target.uiBattle;
    if (!((UnityEngine.Object) uiBattle != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(uiBattle.btnRt[2]);
    this.SetupUI(ref pos);
  }

  public void Battle_NextLevel_FullScreen() => this.Controller.SetHoleVisible(true);

  public void Recv_Battle_NextLevel()
  {
    if (!(this.Target is BattleController target))
      return;
    target.controlPanel.OnPointerUp((PointerEventData) null);
  }

  public void Battle_FirstUltra()
  {
    UIBattle target = this.Target as UIBattle;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    target.ultraSkillWorking = true;
    target.bc.updateMaxSkillFreeze(true);
    target.bc.m_BattleState = BattleController.BattleState.BATTLE_MAXSKILL_WORKING;
    this.UltraTimeCache = target.bc.deltaTime;
    Vector2 pos = this.UIController.ScreenPointTest(target.btnRt[1]);
    this.SetupUI(ref pos);
  }

  public void Recv_Battle_FirstUltra()
  {
    UIBattle target = this.Target as UIBattle;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    target.bc.checkInitUltra(1);
    target.bc.maxSkillTimeCache = this.UltraTimeCache;
    target.bc.inputUltra(false);
    target.ultraSkillWorking = false;
  }

  public void Battle_SecondUltra()
  {
    UIBattle target = this.Target as UIBattle;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    target.ultraSkillWorking = true;
    target.bc.updateMaxSkillFreeze(true);
    target.bc.m_BattleState = BattleController.BattleState.BATTLE_MAXSKILL_WORKING;
    this.UltraTimeCache = target.bc.deltaTime;
    this.PosCache = this.UIController.ScreenPointTest(target.btnRt[2]);
    this.SetupUI(ref this.PosCache);
    this.Controller.ToEnemyPointer(this.PosCache, 0);
  }

  public void Battle_SecondUltra_BtnDown()
  {
    UIBattle target = this.Target as UIBattle;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null && !target.bc.IsMaxSkillWorking)
    {
      target.ultraSkillWorking = false;
      target.OnHIButtonDown(target.buttons[2]);
      this.bTargeting = false;
      this.bUltraWorking = true;
    }
    this.Controller.SetBlackVisible(false);
    this.Controller.ShowPointer(false);
    this.bOutsideHole = false;
  }

  public void Battle_SecondUltra_BtnDrag()
  {
    UIBattle target = this.Target as UIBattle;
    if ((UnityEngine.Object) target == (UnityEngine.Object) null)
      return;
    if (!this.bOutsideHole && this.Controller.CheckOutsideHole())
    {
      this.bOutsideHole = true;
      target.OnHIButtonDragExit(target.buttons[2]);
      target.UpdateProjector();
      target.SetTeachProjector(true);
    }
    if (!this.bOutsideHole || this.bTargeting || !(GameManager.ActiveGameplay is BattleController activeGameplay))
      return;
    Vector3 to = activeGameplay.enemyUnit[0].Position - activeGameplay.playerUnit[0].Position;
    if ((double) Vector3.Angle(activeGameplay.playerUnit[0].Forward, to) >= 20.0)
      return;
    Vector2 position = (Vector2) Camera.main.WorldToScreenPoint(activeGameplay.enemyUnit[0].Position) / GUIManager.Instance.m_UICanvas.scaleFactor;
    target.rayCache = Camera.main.ScreenPointToRay((Vector3) position);
    target.UpdateProjector(true, true);
    target.bProjectorMode = false;
    target.SetTeachProjector(false);
    this.bTargeting = true;
  }

  public void Recv_Battle_SecondUltra()
  {
    UIBattle target = this.Target as UIBattle;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    target.bc.maxSkillTimeCache = this.UltraTimeCache;
    target.OnHIButtonUp(target.buttons[2]);
  }

  public void Battle_ThirdUltra()
  {
    UIBattle target = this.Target as UIBattle;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    target.ultraSkillWorking = true;
    target.bc.updateMaxSkillFreeze(true);
    target.bc.m_BattleState = BattleController.BattleState.BATTLE_MAXSKILL_WORKING;
    this.UltraTimeCache = target.bc.deltaTime;
    this.PosCache = this.UIController.ScreenPointTest(target.btnRt[1]);
    this.SetupUI(ref this.PosCache);
    this.Controller.ToEnemyPointer(this.PosCache, 0, 1);
  }

  public void Battle_ThirdUltra_BtnDown()
  {
    UIBattle target = this.Target as UIBattle;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null && !target.bc.IsMaxSkillWorking)
    {
      target.ultraSkillWorking = false;
      target.OnHIButtonDown(target.buttons[1]);
      this.bTargeting = false;
      this.bUltraWorking = true;
    }
    this.Controller.SetBlackVisible(false);
    this.Controller.ShowPointer(false);
    this.bOutsideHole = false;
  }

  public void Battle_ThirdUltra_BtnDrag()
  {
    UIBattle target = this.Target as UIBattle;
    if ((UnityEngine.Object) target == (UnityEngine.Object) null)
      return;
    if (!this.bOutsideHole && this.Controller.CheckOutsideHole())
    {
      this.bOutsideHole = true;
      target.OnHIButtonDragExit(target.buttons[1]);
      target.UpdateProjector();
      target.SetTeachProjector(true);
    }
    if (!this.bOutsideHole || !(GameManager.ActiveGameplay is BattleController activeGameplay) || activeGameplay.lastNearestTargetIndex != 0)
      return;
    target.SetTeachProjector(false);
    target.bProjectorMode = false;
    this.bTargeting = true;
  }

  public void Recv_Battle_ThirdUltra()
  {
    UIBattle target = this.Target as UIBattle;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      target.bc.maxSkillTimeCache = this.UltraTimeCache;
      target.OnHIButtonUp(target.buttons[1]);
    }
    NewbieManager.bQueuePopMenu = true;
    this.RemoveFlag(ETeachKind.BATTLE_BEFORE, (byte) 1);
    this.LockControl(false);
    if (!NewbieManager.PreCheckPutOnEquipTeach())
      return;
    GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Newbie);
  }

  public void CheckPutOnEquip()
  {
    CurHeroData curHeroData = this.DM.curHeroData.Find(1U);
    if (curHeroData.ID == (ushort) 1 && curHeroData.Enhance == (byte) 1 && ((int) curHeroData.Equip & 1) == 0)
    {
      Vector2 zero = Vector2.zero;
      this.SetupUI(ref zero);
    }
    else
    {
      this.RemoveFlag(ETeachKind.PUTON_EQUIP, (byte) 1);
      this.LockControl(false);
    }
  }

  public void RecvCheckPutOnEquip()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && menu.m_bShowFuncButton != (byte) 1)
      menu.ShowFuncButton(true);
    NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, (object) menu);
  }

  public void ClickHeroList()
  {
    Door target = this.Target as Door;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(target.m_FuncRC[0]);
    this.SetupUI(ref pos);
  }

  public void RecvClickHeroList()
  {
    Door target = this.Target as Door;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    target.OnButtonClick(((Transform) target.m_FuncRC[0]).GetChild(1).GetComponent<UIButton>());
  }

  public void ClickHeroFromList()
  {
    UIHeroList target = this.Target as UIHeroList;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Transform) target.scrolCont).GetChild(0) as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvClickHeroFromList()
  {
    UIHeroList target = this.Target as UIHeroList;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    GameObject gameObject = ((Transform) target.scrolCont).GetChild(0).gameObject;
    target.ButtonOnClick(gameObject, 0);
  }

  public void ClickEquipBtn()
  {
    UIHero_Info target = this.Target as UIHero_Info;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) target.btn_Equip[0]).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvClickEquipBtn()
  {
    UIHero_Info target = this.Target as UIHero_Info;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    target.OnHIButtonClick(target.btn_Equip[0]);
  }

  public void ClickPutOn()
  {
    if (!(this.Target is UIItemInfo target))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) target.m_Button1).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvClickPutOn()
  {
    if (!(this.Target is UIItemInfo target))
      return;
    target.OnButtonClick(target.m_Button1);
  }

  public void UpdateRank1()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvUpdateRank1() => NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, this.Target);

  public void UpdateRank2()
  {
    UIHero_Info target = this.Target as UIHero_Info;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) target.btn_Evolution).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvUpdateRank2()
  {
    UIHero_Info target = this.Target as UIHero_Info;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
      target.OnButtonClick(target.btn_Evolution);
    ((Transform) GUIManager.Instance.m_MessageBoxLayer).GetChild(0).SetParent((Transform) GUIManager.Instance.m_FourthWindowLayer, false);
  }

  public void UpdateRank3()
  {
    Transform child = ((Transform) GUIManager.Instance.m_FourthWindowLayer).GetChild(((Transform) GUIManager.Instance.m_FourthWindowLayer).childCount - 1);
    if ((UnityEngine.Object) child == (UnityEngine.Object) null)
      this.IgnoreStep(true);
    Vector2 pos = this.UIController.ScreenPointTest(child.GetChild(1).GetChild(3).GetChild(5) as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvUpdateRank3()
  {
    GUIManager.Instance.CloseOKCancelBox();
    UIHero_Info menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Hero_Info) as UIHero_Info;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.OnOKCancelBoxClick(false, 1, 0);
  }

  public void UpdateRank4()
  {
    UIHero_Info target = this.Target as UIHero_Info;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) target.timeBarRank.m_FuntionBtn).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvUpdateRank4()
  {
    UIHero_Info target = this.Target as UIHero_Info;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
      target.timeBarRank.OnButtonClick(target.timeBarRank.m_FuntionBtn);
    NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP);
  }

  public void UpdateRank5()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvUpdateRank5() => NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP);

  public void UpdateRank6()
  {
    UIHero_Info menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Hero_Info) as UIHero_Info;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) menu.btn_EXIT).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvUpdateRank6()
  {
    UIHero_Info menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Hero_Info) as UIHero_Info;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.OnButtonClick(menu.btn_EXIT);
    NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP);
  }

  public void UpdateRank7()
  {
    UIHeroList menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_HeroList) as UIHeroList;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) menu.exitButton).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvUpdateRank7()
  {
    this.RemoveFlag(ETeachKind.PUTON_EQUIP, (byte) 1);
    this.LockControl(false);
    UIHeroList menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_HeroList) as UIHeroList;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.OnButtonClick(menu.exitButton);
  }

  public void Turbo1()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvTurbo1()
  {
    if (DataManager.Instance.RoleAlliance.Id == 0U)
      ++this.SubStep;
    NewbieManager.CheckTeach(ETeachKind.TURBO, this.Target);
  }

  public void Turbo2()
  {
    Vector2 pos = this.UIController.ScreenPointTest(((Component) this.Target).gameObject.transform.GetChild(6).GetChild(0) as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvTurbo2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.Onfunc((UITimeBar) this.Target);
    NewbieManager.CheckTeach(ETeachKind.TURBO, this.Target);
  }

  public void Turbo3()
  {
    Vector2 pos = this.UIController.ScreenPointTest(((Component) this.Target).gameObject.transform.GetChild(6).GetChild(0) as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvTurbo3()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.Onfunc((UITimeBar) this.Target);
    NewbieManager.CheckTeach(ETeachKind.TURBO, this.Target);
  }

  public void Turbo4()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvTurbo4()
  {
    this.RestoreTimeBarStatus();
    this.RemoveFlag(ETeachKind.TURBO, (byte) 1);
    this.LockControl(false);
  }

  public void GoldGuy1()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoldGuy1() => NewbieManager.CheckTeach(ETeachKind.GOLDGUY);

  public void GoldGuy2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) menu.m_MoraleBox).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvGoldGuy2()
  {
    if (GameManager.ActiveGameplay is Origin activeGameplay)
      activeGameplay.WorldController.cameraController.CameraMoveTarget(CameraState.Build, GUIManager.Instance.BuildingData.ManorGride[2].position);
    NewbieManager.CheckTeach(ETeachKind.GOLDGUY);
  }

  public void GoldGuy3()
  {
    Vector2 pos1 = (Vector2) Camera.main.WorldToScreenPoint(GUIManager.Instance.BuildingData.ManorGride[2].position) / GUIManager.Instance.m_UICanvas.scaleFactor;
    pos1.y += 97f;
    Vector2 pos2 = this.CheckMirror(pos1);
    this.SetupUI(ref pos2);
  }

  public void RecvGoldGuy3()
  {
    GUIManager.Instance.BuildingData.OpenUI((ushort) 100, GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
    this.RemoveFlag(ETeachKind.GOLDGUY, (byte) 1);
    this.LockControl(false);
  }

  public void GotoSmith()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  public void RecvGotoSmith() => this.MoveNext();

  public void GotoSmith2()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  public void RecvGotoSmith2() => this.MoveNext();

  public void GotoSmith3()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGotoSmith3()
  {
    this.RemoveFlag(ETeachKind.SMITH, (byte) 1);
    this.LockControl(false);
  }

  public void IntoActivity()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvIntoActivity() => NewbieManager.CheckTeach(ETeachKind.ACTIVITY);

  public void IntoActivity2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(menu.m_ActivityBtnT as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvIntoActivity2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      UIButton component = menu.m_ActivityBtnT.GetChild(2).GetComponent<UIButton>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
        menu.OnButtonClick(component);
    }
    this.RemoveFlag(ETeachKind.ACTIVITY, (byte) 1);
    this.LockControl(false);
  }

  public void GetNewHero()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGetNewHero()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && menu.m_bShowFuncButton != (byte) 1)
      menu.ShowFuncButton(true);
    NewbieManager.CheckTeach(ETeachKind.NEW_HERO, (object) menu);
  }

  public void GetNewHero2()
  {
    Door target = this.Target as Door;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(target.m_FuncRC[0]);
    this.SetupUI(ref pos);
  }

  public void RecvGetNewHero2()
  {
    Door target = this.Target as Door;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    target.OnButtonClick(((Transform) target.m_FuncRC[0]).GetChild(1).GetComponent<UIButton>());
  }

  public void GetNewHero3()
  {
    UIHeroList target = this.Target as UIHeroList;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null && (UnityEngine.Object) ((Transform) target.scrolCont).GetChild(0) != (UnityEngine.Object) null && (UnityEngine.Object) ((Transform) target.scrolCont).GetChild(0).GetChild(0).GetChild(9) != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest(((Transform) target.scrolCont).GetChild(0).GetChild(0).GetChild(9) as RectTransform);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGetNewHero3()
  {
    UIHeroList target = this.Target as UIHeroList;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      GameObject gameObject = ((Transform) target.scrolCont).GetChild(0).gameObject;
      target.ButtonOnClick(gameObject, 0);
      if (target.checkPanel.gameObject.activeSelf)
        NewbieManager.CheckTeach(ETeachKind.NEW_HERO, this.Target);
      else
        this.IgnoreStep(true);
    }
    else
      this.IgnoreStep(true);
  }

  public void GetNewHero4()
  {
    UIHeroList target = this.Target as UIHeroList;
    if (!((UnityEngine.Object) target != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(target.checkPanel.GetChild(7) as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvGetNewHero4()
  {
    UIHeroList target = this.Target as UIHeroList;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      UIButton component = target.checkPanel.GetChild(7).GetComponent<UIButton>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      {
        GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Newbie_Protocal_ExtLock);
        target.OnButtonClick(component);
      }
    }
    this.RemoveFlag(ETeachKind.NEW_HERO, (byte) 1);
    this.LockControl(false);
  }

  public void TWipeOut()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvTWipeOut() => NewbieManager.CheckTeach(ETeachKind.WIPE_OUT);

  public void TWipeOut2()
  {
    UIStageInfo menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageInfo) as UIStageInfo;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest(menu.Play1T as RectTransform);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvTWipeOut2()
  {
    UIStageInfo menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageInfo) as UIStageInfo;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    UIButton component = menu.Play1T.GetComponent<UIButton>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    menu.OnButtonClick(component);
  }

  public void TWipeOut3()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvTWipeOut3() => NewbieManager.CheckTeach(ETeachKind.WIPE_OUT, this.Target);

  public void TWipeOut4()
  {
    UIBattleReport target = this.Target as UIBattleReport;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest(target.ContentT.GetChild(3) as RectTransform);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvTWipeOut4() => NewbieManager.CheckTeach(ETeachKind.WIPE_OUT, this.Target);

  public void TWipeOut5()
  {
    UIBattleReport target = this.Target as UIBattleReport;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest(target.ContentT.GetChild(0) as RectTransform);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvTWipeOut5() => NewbieManager.CheckTeach(ETeachKind.WIPE_OUT, this.Target);

  public void TWipeOut6()
  {
    UIBattleReport target = this.Target as UIBattleReport;
    if ((UnityEngine.Object) target != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest(target.ContentT.GetChild(2).GetChild(1) as RectTransform);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvTWipeOut6()
  {
    this.RemoveFlag(ETeachKind.WIPE_OUT, (byte) 1);
    this.LockControl(false);
  }

  public void WorldAttack1()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
    this.Controller.SetSpecialBox(true, (byte) 1);
    this.Controller.PreClickFlag = 1;
  }

  public void RecvWorldAttack1() => this.MoveNext();

  public void WorldAttack2()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  public void RecvWorldAttack2() => this.MoveNext();

  public void WorldAttack3()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  public void RecvWorldAttack3() => this.MoveNext();

  public void WorldAttack4()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
    this.Controller.PreClickFlag = 0;
  }

  public void RecvWorldAttack4()
  {
    this.RemoveFlag(ETeachKind.WORLD_ATTACK, (byte) 1);
    this.LockControl(false);
    this.SuckBugProtector();
    this.WorldTeach_Point = DataManager.Instance.ServerTime;
  }

  public void WorldHunt1()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
    this.Controller.SetSpecialBox(true, (byte) 2);
    this.Controller.PreClickFlag = 1;
  }

  public void RecvWorldHunt1() => this.MoveNext();

  public void WorldHunt2()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  public void RecvWorldHunt2() => this.MoveNext();

  public void WorldHunt3()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
    this.Controller.PreClickFlag = 0;
  }

  public void RecvWorldHunt3()
  {
    this.RemoveFlag(ETeachKind.WORLD_HUNT, (byte) 1);
    this.LockControl(false);
    this.SuckBugProtector();
    this.WorldTeach_Point = DataManager.Instance.ServerTime;
  }

  public void GoAutoBattle()
  {
    UIBattle target = this.Target as UIBattle;
    target.ultraSkillWorking = true;
    target.bc.updateMaxSkillFreeze(true);
    target.bc.m_BattleState = BattleController.BattleState.BATTLE_MAXSKILL_WORKING;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) target.autoButtonUp).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvGoAutoBattle()
  {
    UIBattle target = this.Target as UIBattle;
    target.ultraSkillWorking = false;
    target.bc.updateMaxSkillFreeze(false);
    target.bc.m_BattleState = BattleController.BattleState.BATTLE_RUNNING;
    target.bc.deltaTime = 0.0f;
    target.bc.m_SubStateFlag = (byte) 0;
    target.OnButtonClick(target.autoButtonUp);
    NewbieManager.AutoBattleFlag = false;
    this.RemoveFlag(ETeachKind.AUTO_BATTLE, (byte) 1);
    this.LockControl(false);
  }

  public void GoEliteStage1()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  public void RecvGoEliteStage1() => this.MoveNext();

  public void GoEliteStage2()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoEliteStage2() => this.MoveNext();

  public void GoEliteStage3()
  {
    UIStageSelect menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(menu.transform.GetChild(2).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvGoEliteStage3()
  {
    this.RemoveFlag(ETeachKind.ELITE_STAGE, (byte) 1);
    this.LockControl(false);
    UIStageSelect menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    UIButton component = menu.transform.GetChild(2).GetComponent<UIButton>();
    menu.OnButtonClick(component);
  }

  public void GoArena()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoArena()
  {
    GUIManager.Instance.BuildingData.ArneaGuild();
    NewbieManager.CheckTeach(ETeachKind.ARENA);
  }

  public void GoArena2()
  {
    Vector2 pos = this.CheckMirror((Vector2) Camera.main.WorldToScreenPoint(GUIManager.Instance.BuildingData.ManorGride[3].position) / GUIManager.Instance.m_UICanvas.scaleFactor + new Vector2(7f, 90f));
    this.SetupUI(ref pos);
  }

  public void RecvGoArena2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.OpenMenu(EGUIWindow.UI_Arena);
  }

  public void GoArena3()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  public void RecvGoArena3() => this.MoveNext();

  public void GoArena4()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoArena4() => this.MoveNext();

  public void GoArena5()
  {
    UIArena menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Arena) as UIArena;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(((Component) menu.btn_Defend).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvGoArena5()
  {
    this.RemoveFlag(ETeachKind.ARENA, (byte) 1);
    this.LockControl(false);
  }

  public void GoArmyHole()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoArmyHole()
  {
    GUIManager.Instance.BuildingData.DugoutGuild();
    NewbieManager.CheckTeach(ETeachKind.ARMY_HOLE);
  }

  public void GoArmyHole2()
  {
    Vector2 pos = this.CheckMirror((Vector2) Camera.main.WorldToScreenPoint(GUIManager.Instance.BuildingData.ManorGride[4].position) / GUIManager.Instance.m_UICanvas.scaleFactor + new Vector2(-3f, 60f));
    this.SetupUI(ref pos);
  }

  public void RecvGoArmyHole2()
  {
    HideArmyManager.Instance.OpenHideArmyUI();
    NewbieManager.CheckTeach(ETeachKind.ARMY_HOLE);
  }

  public void GoArmyHole3()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoArmyHole3()
  {
    this.RemoveFlag(ETeachKind.ARMY_HOLE, (byte) 1);
    this.LockControl(false);
  }

  public void GoBlackMarket1()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoBlackMarket1()
  {
    GUIManager.Instance.BuildingData.BlackMarketGuild();
    NewbieManager.CheckTeach(ETeachKind.BLACK_MARKET);
  }

  public void GoBlackMarket2()
  {
    Vector2 pos = this.CheckMirror((Vector2) Camera.main.WorldToScreenPoint(GUIManager.Instance.BuildingData.ManorGride[5].position) / GUIManager.Instance.m_UICanvas.scaleFactor + new Vector2(-3f, 70f));
    this.SetupUI(ref pos);
  }

  public void RecvGoBlackMarket2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.OpenMenu(EGUIWindow.UI_Merchantman);
    NewbieManager.CheckTeach(ETeachKind.BLACK_MARKET);
  }

  public void GoBlackMarket3()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoBlackMarket3()
  {
    this.RemoveFlag(ETeachKind.BLACK_MARKET, (byte) 1);
    this.LockControl(false);
  }

  private void GoTroopMemory()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  private void RecvGoTroopMemory()
  {
    GUIManager.Instance.BuildingData.WarLobbyGuide();
    NewbieManager.CheckTeach(ETeachKind.TROOP_MEMORY);
  }

  private void GoTroopMemory2()
  {
    Transform transform = GUIManager.Instance.BuildingData.ManorGride[6];
    if ((UnityEngine.Object) transform != (UnityEngine.Object) null)
    {
      Vector2 pos = this.CheckMirror((Vector2) Camera.main.WorldToScreenPoint(transform.position) / GUIManager.Instance.m_UICanvas.scaleFactor + new Vector2(-3f, 60f));
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  private void RecvGoTroopMemory2()
  {
    GUIManager.Instance.BuildingData.OpenWarlobbyUI();
    NewbieManager.CheckTeach(ETeachKind.TROOP_MEMORY);
  }

  private void GoTroopMemory3()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  private void RecvGoTroopMemory3()
  {
    this.RemoveFlag(ETeachKind.TROOP_MEMORY, (byte) 1);
    this.LockControl(false);
  }

  private void GoDeShield()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  private void RecvGoDeShield() => NewbieManager.CheckTeach(ETeachKind.DESHIELD);

  private void GoDeShield2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && (UnityEngine.Object) menu.m_BuffRC != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest(((Component) menu.m_BuffBtn).GetComponent<RectTransform>());
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  private void RecvGoDeShield2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && (UnityEngine.Object) menu.m_BuffBtn != (UnityEngine.Object) null)
    {
      menu.OnButtonClick(menu.m_BuffBtn);
      NewbieManager.CheckTeach(ETeachKind.DESHIELD);
    }
    else
      this.IgnoreStep(true);
  }

  private void GoDeShield3()
  {
    UIBuffList menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_BuffList) as UIBuffList;
    if ((UnityEngine.Object) menu == (UnityEngine.Object) null)
    {
      this.IgnoreStep(true);
    }
    else
    {
      int index1 = -1;
      int count = menu.m_Data.Count;
      for (int index2 = 0; index2 < count; ++index2)
      {
        if ((int) menu.m_Data[index2] < this.DM.m_SortBuffData.Length && this.DM.ItemBuffTable.GetRecordByIndex((int) this.DM.m_SortBuffData[(int) menu.m_Data[index2]]).BuffKind == (byte) 7)
          index1 = index2;
      }
      if (index1 == -1)
      {
        this.IgnoreStep(true);
      }
      else
      {
        Transform child1;
        Transform child2;
        Transform child3;
        if ((UnityEngine.Object) (child1 = menu.transform.GetChild(1)) != (UnityEngine.Object) null && (UnityEngine.Object) (child2 = child1.GetChild(0)) != (UnityEngine.Object) null && (UnityEngine.Object) (child3 = child2.GetChild(index1)) != (UnityEngine.Object) null)
        {
          Vector2 pos = this.UIController.ScreenPointTest(child3 as RectTransform);
          pos.x += 20f;
          this.SetupUI(ref pos);
        }
        else
          this.IgnoreStep(true);
      }
    }
  }

  private void RecvGoDeShield3()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.OpenMenu(EGUIWindow.UI_BuffInformation);
    this.RemoveFlag(ETeachKind.DESHIELD, (byte) 1);
    this.LockControl(false);
  }

  public void GoCoord()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoCoord() => NewbieManager.CheckTeach(ETeachKind.ARMY_COORD);

  public void GoCoord2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && (UnityEngine.Object) menu.m_HeadImage != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest(((Component) menu.m_HeadImage).gameObject.GetComponent<RectTransform>());
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGoCoord2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      menu.OpenMenu(EGUIWindow.UI_LordInfo, 1, bCameraMode: true);
      NewbieManager.CheckTeach(ETeachKind.ARMY_COORD);
    }
    else
      this.IgnoreStep(true);
  }

  public void GoCoord3()
  {
    UILordInfo menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_LordInfo) as UILordInfo;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && (UnityEngine.Object) menu.CoordBtnRT != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest(menu.CoordBtnRT);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGoCoord3()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      menu.OpenMenu(EGUIWindow.UI_FormationSelect);
      NewbieManager.CheckTeach(ETeachKind.ARMY_COORD);
    }
    else
      this.IgnoreStep(true);
  }

  public void GoCoord4()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoCoord4()
  {
    this.RemoveFlag(ETeachKind.ARMY_COORD, (byte) 1);
    this.LockControl(false);
  }

  private void PressX()
  {
    UIStageSelect menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.CheckMirror((Vector2) Camera.main.WorldToScreenPoint(((Component) menu.m_ExitBtn).transform.position) / GUIManager.Instance.m_UICanvas.scaleFactor);
    this.SetupUI(ref pos);
  }

  private void RecvPressX()
  {
    UIStageSelect menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.OnButtonClick(menu.m_ExitBtn);
    this.RemoveFlag(ETeachKind.PRESS_X, (byte) 1);
    this.LockControl(false);
  }

  public void GoMetallurgy()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoMetallurgy()
  {
    GUIManager.Instance.BuildingData.LaboratoryGuide();
    NewbieManager.CheckTeach(ETeachKind.METALLURGY);
  }

  public void GoMetallurgy2()
  {
    Vector2 pos = this.CheckMirror((Vector2) Camera.main.WorldToScreenPoint(GUIManager.Instance.BuildingData.ManorGride[8].position) / GUIManager.Instance.m_UICanvas.scaleFactor + new Vector2(0.0f, 80f));
    this.SetupUI(ref pos);
  }

  public void RecvGoMetallurgy2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      GUIManager.Instance.BuildingData.OpenUI((ushort) 105, menu);
      NewbieManager.CheckTeach(ETeachKind.METALLURGY);
    }
    else
      this.IgnoreStep(true);
  }

  public void GoMetallurgy3()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoMetallurgy3() => NewbieManager.CheckTeach(ETeachKind.METALLURGY);

  public void GoMetallurgy4()
  {
    UIAlchemy menu = GUIManager.Instance.FindMenu(EGUIWindow.UIAlchemy) as UIAlchemy;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      Vector2 pos = this.CheckMirror((Vector2) Camera.main.WorldToScreenPoint(menu.WPT[0].position) / GUIManager.Instance.m_UICanvas.scaleFactor);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGoMetallurgy4()
  {
    UIAlchemy menu = GUIManager.Instance.FindMenu(EGUIWindow.UIAlchemy) as UIAlchemy;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      menu.OpenFront2(0);
      NewbieManager.CheckTeach(ETeachKind.METALLURGY);
    }
    else
      this.IgnoreStep(true);
  }

  public void GoMetallurgy5()
  {
    UIAlchemy menu = GUIManager.Instance.FindMenu(EGUIWindow.UIAlchemy) as UIAlchemy;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest((RectTransform) menu.tFront2.GetChild(8));
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGoMetallurgy5()
  {
    UIAlchemy menu = GUIManager.Instance.FindMenu(EGUIWindow.UIAlchemy) as UIAlchemy;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.OnButtonClick(menu.tFront2.GetChild(8).GetComponent<UIButton>());
    NewbieManager.CheckTeach(ETeachKind.METALLURGY);
  }

  public void GoMetallurgy6()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoMetallurgy6()
  {
    this.RemoveFlag(ETeachKind.METALLURGY, (byte) 1);
    this.LockControl(false);
  }

  public void GoGambleNormal()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoGambleNormal()
  {
    GUIManager.Instance.BuildingData.CasinoGuide();
    NewbieManager.CheckTeach(ETeachKind.GAMBLING1);
  }

  public void GoGambleNormal2()
  {
    Vector2 pos = this.CheckMirror((Vector2) Camera.main.WorldToScreenPoint(GUIManager.Instance.BuildingData.ManorGride[7].position) / GUIManager.Instance.m_UICanvas.scaleFactor + new Vector2(3f, 60f));
    this.SetupUI(ref pos);
  }

  public void RecvGoGambleNormal2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      GUIManager.Instance.BuildingData.OpenUI((ushort) 106, menu);
    else
      this.IgnoreStep(true);
  }

  public void GoGambleNormal3()
  {
    UIBattle_Gambling menu1 = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
    if ((UnityEngine.Object) menu1 != (UnityEngine.Object) null)
    {
      Vector2 zero = Vector2.zero;
      this.SetupUI(ref zero, arg: 1, arg2: 1);
      UIPriestTalk menu2 = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
      if ((UnityEngine.Object) menu2 != (UnityEngine.Object) null)
      {
        menu2.transform.SetParent(menu1.transform.parent);
        menu2.transform.SetAsLastSibling();
        menu2.transform.localRotation = Quaternion.identity;
        menu2.transform.localPosition = Vector3.zero;
        menu2.transform.localScale = Vector3.one;
      }
      this.Controller.transform.SetParent(menu1.transform.parent, false);
      this.Controller.transform.SetSiblingIndex(1);
      this.Controller.transform.localRotation = Quaternion.identity;
      this.Controller.transform.localScale = Vector3.one;
      Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
      this.Controller.transform.localPosition = new Vector3(sizeDelta.x * -0.5f, sizeDelta.y * -0.5f, 700f);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGoGambleNormal3() => this.MoveNext();

  public void GoGambleNormal4()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoGambleNormal4()
  {
    UIPriestTalk menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.transform.SetParent((Transform) GUIManager.Instance.m_WindowsTransform);
    this.MoveNext();
  }

  public void GoGambleNormal5()
  {
    UIBattle_Gambling menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest((RectTransform) ((Component) menu.btn_Hint2).transform);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGoGambleNormal5()
  {
    UIBattle_Gambling menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.OnButtonClick(menu.btn_Hint2);
    this.MoveNext();
  }

  public void GoGambleNormal6()
  {
    UIBattle_Gambling menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest((RectTransform) ((Component) menu.btn_Item[2]).transform);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGoGambleNormal6() => this.MoveNext();

  public void GoGambleNormal7()
  {
    UIBattle_Gambling menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
      RectTransform transform = ((Component) menu.Img_ItemListT).transform as RectTransform;
      Vector2 pos = new Vector2(sizeDelta.x - transform.sizeDelta.x * 0.5f, transform.sizeDelta.y * 0.5f);
      pos = (Vector2) new Vector3(pos.x + 83f, pos.y);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGoGambleNormal7() => this.MoveNext();

  public void GoGambleNormal8()
  {
    UIBattle_Gambling menu1 = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
    if ((UnityEngine.Object) menu1 != (UnityEngine.Object) null)
    {
      Vector2 zero = Vector2.zero;
      this.SetupUI(ref zero, arg2: 1);
      UIPriestTalk menu2 = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
      if (!((UnityEngine.Object) menu2 != (UnityEngine.Object) null))
        return;
      menu2.transform.SetParent(menu1.transform.parent);
      menu2.transform.SetAsLastSibling();
      menu2.transform.localRotation = Quaternion.identity;
      menu2.transform.localPosition = Vector3.zero;
      menu2.transform.localScale = Vector3.one;
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGoGambleNormal8()
  {
    UIPriestTalk menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.transform.SetParent((Transform) GUIManager.Instance.m_WindowsTransform);
    this.Controller.transform.SetParent((Transform) GUIManager.Instance.m_NewbieLayer);
    this.Controller.transform.localRotation = Quaternion.identity;
    this.Controller.transform.localScale = Vector3.one;
    Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
    this.Controller.transform.localPosition = new Vector3(sizeDelta.x * -0.5f, sizeDelta.y * -0.5f, 0.0f);
    this.RemoveFlag(ETeachKind.GAMBLING1, (byte) 1);
    this.LockControl(false);
    NewbieManager.CheckGambleElite();
    NewbieManager.NB_SpawnPetTimeCache = DataManager.Instance.ServerTime;
  }

  public void GoGambleElite()
  {
    UIBattle_Gambling menu1 = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
    if ((UnityEngine.Object) menu1 != (UnityEngine.Object) null)
    {
      Vector2 zero = Vector2.zero;
      this.SetupUI(ref zero, arg2: 1);
      UIPriestTalk menu2 = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
      if ((UnityEngine.Object) menu2 != (UnityEngine.Object) null)
      {
        menu2.transform.SetParent(menu1.transform.parent);
        menu2.transform.SetAsLastSibling();
        menu2.transform.localRotation = Quaternion.identity;
        menu2.transform.localPosition = Vector3.zero;
        menu2.transform.localScale = Vector3.one;
      }
      this.Controller.transform.SetParent(menu1.transform.parent, false);
      this.Controller.transform.SetSiblingIndex(1);
      this.Controller.transform.localRotation = Quaternion.identity;
      this.Controller.transform.localScale = Vector3.one;
      Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
      this.Controller.transform.localPosition = new Vector3(sizeDelta.x * -0.5f, sizeDelta.y * -0.5f, 700f);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGoGambleElite()
  {
    UIPriestTalk menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.transform.SetParent((Transform) GUIManager.Instance.m_WindowsTransform);
    this.MoveNext();
  }

  public void GoGambleElite2()
  {
    UIBattle_Gambling menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest((RectTransform) ((Component) menu.btn_ChangeModel_Turbo).transform);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGoGambleElite2()
  {
    UIBattle_Gambling menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.OnButtonClick(menu.btn_ChangeModel_Turbo);
  }

  public void GoGambleElite3()
  {
    UIBattle_Gambling menu1 = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
    if ((UnityEngine.Object) menu1 != (UnityEngine.Object) null)
    {
      Vector2 zero = Vector2.zero;
      this.SetupUI(ref zero, arg2: 1);
      UIPriestTalk menu2 = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
      if (!((UnityEngine.Object) menu2 != (UnityEngine.Object) null))
        return;
      menu2.transform.SetParent(menu1.transform.parent);
      menu2.transform.SetAsLastSibling();
      menu2.transform.localRotation = Quaternion.identity;
      menu2.transform.localPosition = Vector3.zero;
      menu2.transform.localScale = Vector3.one;
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGoGambleElite3()
  {
    UIPriestTalk menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_PriestTalk) as UIPriestTalk;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.transform.SetParent((Transform) GUIManager.Instance.m_WindowsTransform);
    this.Controller.transform.SetParent((Transform) GUIManager.Instance.m_NewbieLayer);
    this.Controller.transform.localRotation = Quaternion.identity;
    this.Controller.transform.localScale = Vector3.one;
    Vector2 sizeDelta = GUIManager.Instance.pDVMgr.CanvasRT.sizeDelta;
    this.Controller.transform.localPosition = new Vector3(sizeDelta.x * -0.5f, sizeDelta.y * -0.5f, 0.0f);
    this.RemoveFlag(ETeachKind.GAMBLING2, (byte) 1);
    this.LockControl(false);
  }

  public void GoDareFull()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoDareFull()
  {
    if (GameManager.ActiveGameplay is Origin activeGameplay)
      activeGameplay.WorldController.cameraController.CameraMoveTarget(CameraState.Build, GUIManager.Instance.BuildingData.ManorGride[2].position);
    NewbieManager.CheckTeach(ETeachKind.DARE_FULL);
  }

  public void GoDareFull2()
  {
    Vector2 pos1 = (Vector2) Camera.main.WorldToScreenPoint(GUIManager.Instance.BuildingData.ManorGride[2].position) / GUIManager.Instance.m_UICanvas.scaleFactor;
    pos1.y += 97f;
    Vector2 pos2 = this.CheckMirror(pos1);
    this.SetupUI(ref pos2);
  }

  public void RecvGoDareFull2()
  {
    GUIManager.Instance.BuildingData.OpenUI((ushort) 100, GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door);
  }

  public void GoDareFull3()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoDareFull3() => NewbieManager.CheckTeach(ETeachKind.DARE_FULL);

  public void GoDareFull4()
  {
    UIStageSelect menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(menu.transform.GetChild(3).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvGoDareFull4()
  {
    UIStageSelect menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    UIButton component = menu.transform.GetChild(3).GetComponent<UIButton>();
    menu.OnButtonClick(component);
  }

  public void GoDareFull5()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.ForceQueueBarOpenClose(false);
    if (!((UnityEngine.Object) NewbieManager.pTrans != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.CheckMirror((Vector2) Camera.main.WorldToScreenPoint(NewbieManager.pTrans.position) / GUIManager.Instance.m_UICanvas.scaleFactor + new Vector2(0.0f, 34f));
    this.SetupUI(ref pos);
    NewbieManager.pTrans = (Transform) null;
  }

  public void RecvGoDareFull5()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.OpenMenu(EGUIWindow.UI_StageInfo, bCameraMode: true);
    NewbieManager.CheckTeach(ETeachKind.DARE_FULL);
  }

  public void GoDareFull6()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoDareFull6() => NewbieManager.CheckTeach(ETeachKind.DARE_FULL);

  public void GoDareFull7()
  {
    UIStageInfo menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageInfo) as UIStageInfo;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(menu.transform.GetChild(58).transform as RectTransform);
    pos.y -= 50f;
    this.SetupUI(ref pos);
  }

  public void RecvGoDareFull7() => NewbieManager.CheckTeach(ETeachKind.DARE_FULL);

  public void GoDareFull8()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoDareFull8() => NewbieManager.CheckTeach(ETeachKind.DARE_FULL);

  public void GoDareFull9()
  {
    UIStageInfo menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageInfo) as UIStageInfo;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(menu.transform.GetChild(21).transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvGoDareFull9()
  {
    UIStageInfo menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageInfo) as UIStageInfo;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    UIButton component = menu.transform.GetChild(21).GetComponent<UIButton>();
    menu.OnButtonClick(component);
    NewbieManager.CheckTeach(ETeachKind.DARE_FULL);
  }

  public void GoDareFull10()
  {
    UIBattleHeroSelect menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_BattleHeroSelect) as UIBattleHeroSelect;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(menu.transform.GetChild(25) as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvGoDareFull10()
  {
    UIBattleHeroSelect menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_BattleHeroSelect) as UIBattleHeroSelect;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      UIButton component = menu.transform.GetChild(25).GetComponent<UIButton>();
      menu.OnButtonClick(component);
    }
    NewbieManager.CheckTeach(ETeachKind.DARE_FULL);
  }

  public void GoDareFull11()
  {
    UIBattleHeroSelect menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_BattleHeroSelect) as UIBattleHeroSelect;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(menu.transform.GetChild(26).GetChild(0) as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvGoDareFull11() => NewbieManager.CheckTeach(ETeachKind.DARE_FULL);

  public void GoDareFull12()
  {
    UIBattleHeroSelect menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_BattleHeroSelect) as UIBattleHeroSelect;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(menu.m_HerosView.transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvGoDareFull12() => NewbieManager.CheckTeach(ETeachKind.DARE_FULL);

  public void GoDareFull13()
  {
    UIBattleHeroSelect menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_BattleHeroSelect) as UIBattleHeroSelect;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(menu.transform.GetChild(25) as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvGoDareFull13()
  {
    UIBattleHeroSelect menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_BattleHeroSelect) as UIBattleHeroSelect;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      UIButton component = menu.transform.GetChild(25).GetComponent<UIButton>();
      menu.OnButtonClick(component);
    }
    this.RemoveFlag(ETeachKind.DARE_FULL, (byte) 1);
    this.LockControl(false);
  }

  public void GoDareLead()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoDareLead() => NewbieManager.CheckTeach(ETeachKind.DARE_LEAD);

  public void GoDareLead2()
  {
    for (int index = 0; index < 6; ++index)
    {
      if (!((UnityEngine.Object) NewbieManager.HeroIconCache[index] == (UnityEngine.Object) null))
      {
        Vector2 pos = (Vector2) Camera.main.WorldToScreenPoint(NewbieManager.HeroIconCache[index].transform.position);
        float scaleFactor = GUIManager.Instance.m_UICanvas.scaleFactor;
        pos /= scaleFactor;
        pos = this.CheckMirror(pos);
        if (index == 0)
          this.SetupUI(ref pos);
        else
          this.Controller.SetOtherHoleVisible(index - 1, true, pos);
      }
    }
  }

  public void RecvGoDareLead2()
  {
    DataManager.StageDataController.currentPointID = (ushort) ((uint) (((int) DataManager.StageDataController.currentChapterID - 1) * 6 + NewbieManager.ClickBtnID + 1) * (uint) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode]);
    DataManager.StageDataController.SaveUserStage(DataManager.StageDataController._stageMode);
    DataManager.msgBuffer[0] = (byte) 17;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    NewbieManager.CheckTeach(ETeachKind.DARE_LEAD);
  }

  public void GoDareLead3()
  {
    UIStageInfo menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageInfo) as UIStageInfo;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(menu.transform.GetChild(68).transform as RectTransform);
    pos.y += 20f;
    this.SetupUI(ref pos);
  }

  public void RecvGoDareLead3() => NewbieManager.CheckTeach(ETeachKind.DARE_LEAD);

  public void GoDareLead4()
  {
    UIStageInfo menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageInfo) as UIStageInfo;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(menu.transform.GetChild(7).transform as RectTransform);
    pos.y -= 40f;
    this.SetupUI(ref pos);
  }

  public void RecvGoDareLead4()
  {
    this.RemoveFlag(ETeachKind.DARE_FULL, (byte) 1);
    this.LockControl(false);
  }

  public void GoSpawnSoliderDetail()
  {
    UIBarrack_Soldier menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Barrack_Soldier) as UIBarrack_Soldier;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest(((Component) menu.m_UnitRS.BtnInputText).transform as RectTransform);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGoSpawnSoliderDetail()
  {
    UIBarrack_Soldier menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Barrack_Soldier) as UIBarrack_Soldier;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.OnButtonClick(menu.m_UnitRS.BtnInputText);
    NewbieManager.CheckTeach(ETeachKind.SPAWN_SOLDIER_DETAIL);
  }

  public void GoSpawnSoliderDetail2()
  {
    if ((UnityEngine.Object) GUIManager.Instance.Obj_UICalculator != (UnityEngine.Object) null && GUIManager.Instance.m_UICalculator != null)
    {
      Vector2 pos = this.UIController.ScreenPointTest(GUIManager.Instance.m_UICalculator.CalculatorRT);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  public void RecvGoSpawnSoliderDetail2()
  {
    this.RemoveFlag(ETeachKind.SPAWN_SOLDIER_DETAIL, (byte) 1);
    this.LockControl(false);
  }

  public void GoTreasBoxUpgrade()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoTreasBoxUpgrade() => NewbieManager.CheckTeach(ETeachKind.TREASBOX_UPGRADE);

  public void GoTreasBoxUpgrade2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(menu.m_MallGO.transform as RectTransform);
    this.SetupUI(ref pos);
  }

  public void RecvGoTreasBoxUpgrade2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.OnButtonClick(menu.m_MallGO.GetComponent<UIButton>());
  }

  public void GoTreasBoxUpgrade3()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoTreasBoxUpgrade3()
  {
    this.RemoveFlag(ETeachKind.TREASBOX_UPGRADE, (byte) 1);
    this.LockControl(false);
  }

  public void GoSpawnPet()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoSpawnPet()
  {
    GUIManager.Instance.BuildingData.PetListGuide();
    NewbieManager.CheckTeach(ETeachKind.SPAWN_PET);
  }

  public void GoSpawnPet2()
  {
    Vector2 pos = this.CheckMirror((Vector2) Camera.main.WorldToScreenPoint(GUIManager.Instance.BuildingData.ManorGride[9].position) / GUIManager.Instance.m_UICanvas.scaleFactor + new Vector2(-2f, 60f));
    this.SetupUI(ref pos);
  }

  public void RecvGoSpawnPet2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      menu.OpenMenu(EGUIWindow.UI_PetList, 49, 20);
      NewbieManager.CheckTeach(ETeachKind.SPAWN_PET);
    }
    else
      this.IgnoreStep(true);
  }

  public void GoSpawnPet3()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  public void RecvGoSpawnPet3() => NewbieManager.CheckTeach(ETeachKind.SPAWN_PET);

  public void GoSpawnPet4()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  public void RecvGoSpawnPet4() => NewbieManager.CheckTeach(ETeachKind.SPAWN_PET);

  public void GoSpawnPet5()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  public void RecvGoSpawnPet5()
  {
    this.RemoveFlag(ETeachKind.SPAWN_PET, (byte) 1);
    this.LockControl(false);
  }

  private void GoPetInfo()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  private void RecvGoPetInfo() => this.MoveNext();

  private void GoPetInfo2()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  private void RecvGoPetInfo2()
  {
    this.RemoveFlag(ETeachKind.PET_INFO, (byte) 1);
    this.LockControl(false);
  }

  private void GoPetFusion()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  private void RecvGoPetFusion() => this.MoveNext();

  private void GoPetFusion2()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  private void RecvGoPetFusion2()
  {
    this.RemoveFlag(ETeachKind.PET_FUSION, (byte) 1);
    this.LockControl(false);
  }

  private void GoPetTraining()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  private void RecvGoPetTraining() => this.MoveNext();

  private void GoPetTraining2()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  private void RecvGoPetTraining2()
  {
    this.RemoveFlag(ETeachKind.PET_TRAINING, (byte) 1);
    this.LockControl(false);
  }

  private void GoPetSkill()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  private void RecvGoPetSkill() => this.MoveNext();

  private void GoPetSkill2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest(menu.m_PetSkillBtnGO.transform as RectTransform);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  private void RecvGoPetSkill2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      menu.OpenMenu(EGUIWindow.UI_PetBuff);
      this.MoveNext();
    }
    else
      this.IgnoreStep(true);
  }

  private void GoPetSkill3()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  private void RecvGoPetSkill3() => this.MoveNext();

  private void GoPetSkill4()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  private void RecvGoPetSkill4()
  {
    this.RemoveFlag(ETeachKind.PET_SKILL, (byte) 1);
    this.LockControl(false);
  }

  private void GoSocialInvite()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero, arg: 1);
  }

  private void RecvGoSocialInvite() => this.MoveNext();

  private void GoSocialInvite2()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  private void RecvGoSocialInvite2() => this.MoveNext();

  private void GoSocialInvite3()
  {
    UIFBWindow menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_MissionFB) as UIFBWindow;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      Vector2 pos = this.UIController.ScreenPointTest(((Component) menu.btnInvite).transform as RectTransform);
      this.SetupUI(ref pos);
    }
    else
      this.IgnoreStep(true);
  }

  private void RecvGoSocialInvite3()
  {
    this.RemoveFlag(ETeachKind.SOCIAL_INVITE, (byte) 1);
    this.LockControl(false);
  }

  private void GoSocialInviteII()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  private void RecvGoSocialInviteII()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && menu.m_bShowFuncButton != (byte) 1)
      menu.ShowFuncButton(true);
    this.MoveNext();
  }

  private void GoSocialInviteII2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    Vector2 pos = this.UIController.ScreenPointTest(menu.m_FuncRC[2]);
    this.SetupUI(ref pos);
  }

  private void RecvGoSocialInviteII2()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.OnButtonClick(((Transform) menu.m_FuncRC[2]).GetChild(0).GetComponent<UIButton>());
    this.MoveNext();
  }

  private void GoSocialInviteII3()
  {
    UIOther menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Other) as UIOther;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      for (int index = 0; index < 15; ++index)
      {
        if ((UnityEngine.Object) menu.btnItem[index] != (UnityEngine.Object) null && menu.btnItem[index].m_BtnID1 == 1 && menu.btnItem[index].m_BtnID2 == 13)
        {
          Vector2 pos = this.UIController.ScreenPointTest(((Component) menu.btnItem[index]).transform as RectTransform);
          this.SetupUI(ref pos);
          return;
        }
      }
    }
    this.IgnoreStep(true);
  }

  private void RecvGoSocialInviteII3()
  {
    UIOther menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Other) as UIOther;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.OnClickBtn(13);
    this.MoveNext();
  }

  private void GoSocialInviteII4()
  {
    Vector2 zero = Vector2.zero;
    this.SetupUI(ref zero);
  }

  private void RecvGoSocialInviteII4()
  {
    this.RemoveFlag(ETeachKind.SOCIAL_INVITE_AFTER_MISSION, (byte) 1);
    this.LockControl(false);
    NewbieManager.CheckSocialInvite();
  }

  public class NewbieNode
  {
    public float DelayTime;
    public NewbieManager.ActiveStep StepFunc;

    public NewbieNode(float delay, NewbieManager.ActiveStep step)
    {
      this.DelayTime = delay;
      this.StepFunc = step;
    }
  }

  public delegate void ActiveStep();
}
