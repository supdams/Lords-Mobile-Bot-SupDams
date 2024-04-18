// Decompiled with JetBrains decompiler
// Type: GamblingManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class GamblingManager
{
  private const int MaxGambleGameDataNum = 2;
  private static GamblingManager instance;
  public GamblingManager.GambleGameInfo m_GambleGameInfo;
  public GamblingManager.GambleEventSave m_GambleEventSave;
  public Vector2 m_ItemPos;
  public List<GamblingManager.GamebleJackpot> m_GamebleJackpots = new List<GamblingManager.GamebleJackpot>();
  public List<CommonItemDataType> m_QueueGamebleItem = new List<CommonItemDataType>();
  public UIBattle_Gambling.eMode GambleMode = UIBattle_Gambling.eMode.Normal;
  public bool bIsFirstOpen;
  public GambleBoxAnim m_GambleBoxAnim;
  public NpcParticleType m_NpcParticleType;
  public HeroBattleData[] BattleHeroData = new HeroBattleData[5];
  public byte BattleHeroCount;
  public ushort BattleMonsterID;
  private DataIndexTbl[][] MonsterPriceIndex = new DataIndexTbl[2][];
  public List<CString> GambleCountStr = new List<CString>();
  public byte bOpenTreasure;
  public byte mComboMax;

  public static GamblingManager Instance
  {
    get
    {
      if (GamblingManager.instance == null)
        GamblingManager.instance = new GamblingManager();
      return GamblingManager.instance;
    }
  }

  public void Send_MSG_REQUEST_GAMBLE_INFO()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.UIBattleGambling))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_GAMBLE_INFO;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void Send_MSG_REQUEST_GAMBLE_STARTGAME(byte Type)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.UIBattleGambling))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_GAMBLE_STARTGAME;
    messagePacket.AddSeqId();
    messagePacket.Add(Type);
    messagePacket.Send();
  }

  public void Send_MSG_REQUEST_GAMBLE_PRIZE()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_GAMBLE_PRIZE;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_GAMBLE_INFO(MessagePacket MP)
  {
    byte num = MP.ReadByte();
    GUIManager.Instance.HideUILock(EUILock.UIBattleGambling);
    if (num != (byte) 0 && num != (byte) 1)
      return;
    this.m_GambleGameInfo.InitGambleGameInfo();
    this.m_GambleGameInfo.BigCost = MP.ReadUInt();
    this.m_GambleGameInfo.SmallCost = MP.ReadUInt();
    for (int index = 0; index < this.m_GambleGameInfo.GambleData.Length; ++index)
    {
      this.m_GambleGameInfo.GambleData[index].Stage = MP.ReadByte();
      this.m_GambleGameInfo.GambleData[index].RemainFreePlay = MP.ReadByte();
      if (this.m_GambleGameInfo.GambleData[index].RemainFreePlay != (byte) 0 && this.mComboMax == (byte) 0)
      {
        this.mComboMax = this.m_GambleGameInfo.GambleData[index].RemainFreePlay;
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 22);
      }
    }
    this.m_GambleGameInfo.Prize = MP.ReadUInt();
    GUIManager instance1 = GUIManager.Instance;
    DataManager instance2 = DataManager.Instance;
    instance1.bClearWindowStack = false;
    this.BattleMonsterID = this.m_GambleEventSave.MonsterID;
    if (!DataManager.CheckGambleBattleResources())
      GUIManager.Instance.AddHUDMessage(instance2.mStringTable.GetStringByID(8350U), (ushort) byte.MaxValue);
    else if (BattleController.IsGambleMode)
    {
      BattleController.GambleResult = 0;
      BattleNetwork.RefreshGambleMode(BattleController.GambleMode);
    }
    else
    {
      DataManager.Instance.WorldCameraTransitionsPos = GameConstants.GamblingGuy;
      BattleController.GambleMode = EGambleMode.Normal;
      BattleController.GambleResult = 0;
      BattleController.BattleMode = EBattleMode.Gambling;
      instance1.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.GambleBattle);
    }
  }

  public void Recv_MSG_RESP_GAMBLE_STARTGAME(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.UIBattleGambling);
    byte num1 = 0;
    if (this.GambleMode < (UIBattle_Gambling.eMode) this.m_GambleGameInfo.GambleData.Length)
      num1 = this.m_GambleGameInfo.GambleData[(int) this.GambleMode].RemainFreePlay;
    bool flag = this.IsDailyFreeScardStar(this.GambleMode);
    byte num2 = MP.ReadByte();
    byte index = MP.ReadByte();
    if ((int) index >= this.m_GambleGameInfo.GambleData.Length || num2 > (byte) 100)
      return;
    this.m_GambleGameInfo.GambleData[(int) index].Stage = MP.ReadByte();
    uint num3 = MP.ReadUInt();
    GUIManager.Instance.SetRoleAttrDiamond(DataManager.Instance.RoleAttr.Diamond + num3, (ushort) 0);
    DataManager.Instance.RoleAttr.ScardStar = MP.ReadUInt();
    this.m_GambleGameInfo.Prize = MP.ReadUInt();
    CommonItemDataType commonItemDataType = new CommonItemDataType();
    commonItemDataType.ItemID = MP.ReadUShort();
    commonItemDataType.Num = MP.ReadUShort();
    commonItemDataType.ItemRank = MP.ReadByte();
    int remainFreePlay = (int) this.m_GambleGameInfo.GambleData[(int) index].RemainFreePlay;
    this.m_GambleGameInfo.GambleData[(int) index].RemainFreePlay = MP.ReadByte();
    if (remainFreePlay == 0 && this.m_GambleGameInfo.GambleData[(int) index].RemainFreePlay > (byte) 0)
    {
      this.mComboMax = this.m_GambleGameInfo.GambleData[(int) index].RemainFreePlay;
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 22);
    }
    DataManager.Instance.RoleAttr.DailyFreeScardStar = MP.ReadByte();
    if (BattleController.IsGambleMode)
    {
      BattleController activeGameplay = GameManager.ActiveGameplay as BattleController;
      if (num2 == (byte) 0)
        BattleNetwork.SetBattleGambleState(EBattleGambleState.MONSTER_HIT);
      else if (num2 == (byte) 1 || num2 == (byte) 4)
      {
        BattleNetwork.SetBattleGambleState(EBattleGambleState.MONSTER_DIE);
        if (num2 == (byte) 4)
          DataManager.MissionDataManager.CheckChanged(eMissionKind.Mark, (ushort) 159, (ushort) 1);
      }
      else
      {
        switch (num2)
        {
          case 2:
            BattleNetwork.SetBattleGambleState(EBattleGambleState.SUPPORT_WORK);
            DataManager.MissionDataManager.CheckChanged(eMissionKind.Mark, (ushort) 158, (ushort) 1);
            break;
          case 3:
            BattleNetwork.SetBattleGambleState(EBattleGambleState.MONSTER_LEAVE);
            break;
        }
      }
      if (num2 != (byte) 4 && commonItemDataType.ItemID != (ushort) 0)
      {
        this.m_QueueGamebleItem.Add(commonItemDataType);
        activeGameplay.AddGambleItemBox(commonItemDataType.ItemID, commonItemDataType.ItemRank);
        if (num3 == 0U)
        {
          ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(commonItemDataType.ItemID, commonItemDataType.ItemRank);
          DataManager.Instance.SetCurItemQuantity(commonItemDataType.ItemID, (ushort) ((uint) curItemQuantity + (uint) commonItemDataType.Num), commonItemDataType.ItemRank, 0L);
        }
      }
    }
    if (num2 == (byte) 1 || num2 == (byte) 2)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 7);
    else if (this.m_GambleGameInfo.GambleData[(int) index].Stage != (byte) 1)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 6);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 8, (int) num2);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_MonsterCrypt, 0);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
    GameManager.OnRefresh();
    if (num1 != (byte) 0 && this.m_GambleGameInfo.GambleData[(int) this.GambleMode].RemainFreePlay == (byte) 0 && this.m_GambleGameInfo.GambleData[(int) index].RemainFreePlay == (byte) 0)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 16);
    if (flag && !this.IsDailyFreeScardStar(this.GambleMode) && DataManager.Instance.RoleAttr.DailyFreeScardStar == (byte) 1)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 16);
    if (num1 != (byte) 0 || this.m_GambleGameInfo.GambleData[(int) this.GambleMode].RemainFreePlay <= (byte) 0)
      return;
    AudioManager.Instance.PlaySFX((ushort) 40029);
  }

  public void Recv_MSG_RESP_GAMBLE_PRIZE(MessagePacket MP)
  {
    this.m_GambleGameInfo.Prize = MP.ReadUInt();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 2);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_MonsterCrypt, 0);
  }

  public void Recv_MSG_GAMBLE_JACKPOT(MessagePacket MP)
  {
    GamblingManager.GamebleJackpot data = new GamblingManager.GamebleJackpot();
    uint num = 0;
    data.KingdomID = MP.ReadUShort();
    MP.ReadStringPlus(3, data.Tag);
    MP.ReadStringPlus(13, data.Name);
    num = MP.ReadUInt();
    data.PrizeWins = MP.ReadUInt();
    data.GameType = (UIBattle_Gambling.eMode) MP.ReadByte();
    data.WonTime = MP.ReadLong();
    bool flag = DataManager.CompareStr(data.Name, DataManager.Instance.RoleAttr.Name) == 0;
    this.AddJackpotData(data);
    if ((bool) (Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) || (int) data.KingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID)
    {
      DataManager instance = DataManager.Instance;
      CString tmpS1 = StringManager.Instance.StaticString1024();
      tmpS1.Append("<color=#FFFF00>");
      tmpS1.IntToFormat((long) data.PrizeWins, bNumber: true);
      tmpS1.AppendFormat(instance.mStringTable.GetStringByID(8473U));
      tmpS1.Append("</color>");
      MapMonster recordByKey1 = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.m_GambleEventSave.MonsterID);
      HeroTeam recordByKey2 = instance.TeamTable.GetRecordByKey(recordByKey1.MapTeamInfo[0].TeamID);
      Hero recordByKey3 = instance.HeroTable.GetRecordByKey(recordByKey2.Arrays[10].Hero);
      CString FromattedName = StringManager.Instance.StaticString1024();
      GameConstants.FormatRoleName(FromattedName, data.Name, data.Tag, bCheckedNickname: (byte) 0, KingdomID: (int) data.KingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID ? data.KingdomID : (ushort) 0);
      CString tmpS2 = StringManager.Instance.StaticString1024();
      tmpS2.Append("<color=#FFFF00>");
      tmpS2.Append(FromattedName);
      tmpS2.Append("</color>");
      CString str = StringManager.Instance.SpawnString(1024);
      str.StringToFormat(tmpS2);
      if (data.GameType == UIBattle_Gambling.eMode.Normal)
        str.StringToFormat(instance.mStringTable.GetStringByID(9171U));
      else
        str.StringToFormat(instance.mStringTable.GetStringByID(9179U));
      str.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey3.HeroName));
      str.StringToFormat(tmpS1);
      str.AppendFormat(instance.mStringTable.GetStringByID(9180U));
      this.GambleCountStr.Add(str);
      GUIManager.Instance.SetRunningText(str);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 2);
    if (flag)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 9);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_MonsterCrypt, 0);
  }

  public void Recv_MSG_RESP_GAMBLE_UPDATEINFO(MessagePacket MP)
  {
    uint sn = this.m_GambleEventSave.SN;
    this.m_GambleEventSave.SN = MP.ReadUInt();
    this.m_GambleEventSave.State = (EActivityState) MP.ReadByte();
    this.m_GambleEventSave.BeginTime = MP.ReadLong();
    this.m_GambleEventSave.RequireTime = MP.ReadUInt();
    this.m_GambleEventSave.GroupID = MP.ReadUShort();
    this.m_GambleEventSave.MonsterID = MP.ReadUShort();
    if (this.m_GambleEventSave.State != EActivityState.EAS_Run)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 13);
    if (!BattleController.IsGambleMode || (int) sn == (int) this.m_GambleEventSave.SN)
      return;
    this.Send_MSG_REQUEST_GAMBLE_INFO();
  }

  public void Recv_MSG_GAMBLE_HISTORY(MessagePacket MP)
  {
    if (this.m_GamebleJackpots == null)
      return;
    this.m_GamebleJackpots.Clear();
    GamblingManager.GamebleJackpot[] gamebleJackpotArray = new GamblingManager.GamebleJackpot[3];
    for (int index = 0; index < 3; ++index)
    {
      gamebleJackpotArray[index] = new GamblingManager.GamebleJackpot();
      gamebleJackpotArray[index].KingdomID = MP.ReadUShort();
      MP.ReadStringPlus(3, gamebleJackpotArray[index].Tag);
      MP.ReadStringPlus(13, gamebleJackpotArray[index].Name);
      gamebleJackpotArray[index].PrizeWins = MP.ReadUInt();
      gamebleJackpotArray[index].GameType = (UIBattle_Gambling.eMode) MP.ReadByte();
      gamebleJackpotArray[index].WonTime = MP.ReadLong();
    }
    for (int index = 2; index >= 0 && index < gamebleJackpotArray.Length; --index)
    {
      if (gamebleJackpotArray[index].PrizeWins != 0U)
        this.AddJackpotData(gamebleJackpotArray[index]);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 2);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_MonsterCrypt, 0);
  }

  public void AddJackpotData(GamblingManager.GamebleJackpot data)
  {
    this.m_GamebleJackpots.Insert(0, data);
    if (this.m_GamebleJackpots.Count < 4)
      return;
    this.m_GamebleJackpots.RemoveAt(this.m_GamebleJackpots.Count - 1);
  }

  public uint GetCost()
  {
    if (this.GetRemainFreePlay(this.GambleMode) > (byte) 0 || this.IsDailyFreeScardStar(this.GambleMode))
      return 0;
    return this.GambleMode == UIBattle_Gambling.eMode.Normal ? this.m_GambleGameInfo.SmallCost : this.m_GambleGameInfo.BigCost;
  }

  public bool IsDailyFreeScardStar(UIBattle_Gambling.eMode mod)
  {
    if (mod == UIBattle_Gambling.eMode.Turbo)
      return DataManager.Instance.CheckPrizeFlag((byte) 9) && DataManager.Instance.RoleAttr.DailyFreeScardStar != (byte) 1 && DataManager.Instance.RoleAttr.DailyFreeScardStar != (byte) 3;
    if (!DataManager.Instance.CheckPrizeFlag((byte) 9))
      return DataManager.Instance.RoleAttr.DailyFreeScardStar != (byte) 2 && DataManager.Instance.RoleAttr.DailyFreeScardStar != (byte) 3;
    return DataManager.Instance.RoleAttr.DailyFreeScardStar == (byte) 0 && NewbieManager.IsTeachWorking(ETeachKind.GAMBLING1);
  }

  public byte GetRemainFreePlay(UIBattle_Gambling.eMode mod)
  {
    return mod == UIBattle_Gambling.eMode.Normal ? GamblingManager.Instance.m_GambleGameInfo.GambleData[1].RemainFreePlay : GamblingManager.Instance.m_GambleGameInfo.GambleData[0].RemainFreePlay;
  }

  public bool IsSpecialType(UIBattle_Gambling.eMode mod)
  {
    return GamblingManager.Instance.m_GambleGameInfo.GambleData[mod != UIBattle_Gambling.eMode.Normal ? 0 : 1].Stage > (byte) 10;
  }

  public void MakeMonsterPriceIndexTable()
  {
    CExternalTableWithWordKey<MonsterPriceTbl>[] monsterPriceTable = DataManager.Instance.GambleMonsterPriceTable;
    this.MonsterPriceIndex[0] = new DataIndexTbl[(int) monsterPriceTable[0].GetRecordByIndex(monsterPriceTable[0].TableCount - 1).Group + 1];
    this.MonsterPriceIndex[1] = new DataIndexTbl[(int) monsterPriceTable[1].GetRecordByIndex(monsterPriceTable[1].TableCount - 1).Group + 1];
    for (int index = 0; index < monsterPriceTable.Length; ++index)
    {
      for (int Index = 0; Index < monsterPriceTable[index].TableCount; ++Index)
      {
        MonsterPriceTbl recordByIndex = monsterPriceTable[index].GetRecordByIndex(Index);
        if (this.MonsterPriceIndex[index][(int) recordByIndex.Group].BeginIdx == (ushort) 0)
          this.MonsterPriceIndex[index][(int) recordByIndex.Group].BeginIdx = (ushort) (Index + 1);
        ++this.MonsterPriceIndex[index][(int) recordByIndex.Group].Num;
      }
    }
  }

  public bool GetMonsterPriceGroupIndex(ushort group, ref DataIndexTbl Data)
  {
    int gambleMode = (int) BattleController.GambleMode;
    if (gambleMode >= this.MonsterPriceIndex.Length)
      return false;
    Data = this.MonsterPriceIndex[gambleMode][(int) group];
    return true;
  }

  public void ClearGambleStr()
  {
    for (int index = 0; index < this.GambleCountStr.Count; ++index)
      StringManager.Instance.DeSpawnString(this.GambleCountStr[index]);
    this.GambleCountStr.Clear();
  }

  public bool OpenMenu(EGUIWindow eWin, int arg1 = 0, int arg2 = 0, bool bCameraMode = false)
  {
    GUIManager instance = GUIManager.Instance;
    if ((Object) instance.FindMenu(eWin) != (Object) null)
    {
      if (!((Object) instance.m_Chat != (Object) null) || !instance.m_Chat.activeInHierarchy)
        return false;
      instance.CloseMenu(instance.Chatwin.m_eWindow);
      GUIWindowStackData guiWindowStackData;
      guiWindowStackData.m_eWindow = eWin;
      guiWindowStackData.m_Arg1 = arg1;
      guiWindowStackData.m_Arg2 = arg2;
      guiWindowStackData.bCameraMode = bCameraMode;
      instance.m_WindowStack.Add(guiWindowStackData);
      return true;
    }
    instance.OpenMenu(eWin, arg1, arg2, bCameraMode);
    GUIWindowStackData guiWindowStackData1;
    guiWindowStackData1.m_eWindow = eWin;
    if (eWin == EGUIWindow.UI_Chat)
      arg1 = 0;
    guiWindowStackData1.m_Arg1 = arg1;
    guiWindowStackData1.m_Arg2 = arg2;
    guiWindowStackData1.bCameraMode = bCameraMode;
    instance.m_WindowStack.Add(guiWindowStackData1);
    if (eWin != EGUIWindow.UI_Chat && eWin != EGUIWindow.UI_OpenBox)
    {
      UIBattle_Gambling menu = instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
      if ((Object) menu != (Object) null)
        menu.DimPanle.gameObject.SetActive(true);
    }
    else
    {
      UIBattle_Gambling menu = instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
      if ((Object) menu != (Object) null)
        menu.DimPanle.gameObject.SetActive(false);
    }
    instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 11);
    return true;
  }

  public void CloseMenu(bool bClear = false)
  {
    GUIManager instance = GUIManager.Instance;
    if (instance.m_WindowStack.Count == 0)
      return;
    EGUIWindow eWindow = instance.m_WindowStack[instance.m_WindowStack.Count - 1].m_eWindow;
    if (bClear)
    {
      for (int index = instance.m_WindowStack.Count - 1; index > -1; --index)
        instance.CloseMenu(instance.m_WindowStack[index].m_eWindow);
      instance.m_WindowStack.Clear();
      instance.bClearWindowStack = bClear;
    }
    else
    {
      instance.CloseMenu(eWindow);
      instance.m_WindowStack.RemoveAt(instance.m_WindowStack.Count - 1);
    }
    if (instance.m_WindowStack.Count == 0)
    {
      UIBattle_Gambling menu = instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
      if ((Object) menu != (Object) null)
        menu.DimPanle.gameObject.SetActive(false);
      if ((Object) instance.m_ChatBox != (Object) null)
        ((Component) instance.m_ChatBox).gameObject.SetActive(true);
      instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 10);
    }
    else
    {
      if ((Object) instance.m_Window2 == (Object) null || eWindow != EGUIWindow.UI_Chat)
        instance.OpenMenu(instance.m_WindowStack[instance.m_WindowStack.Count - 1].m_eWindow, instance.m_WindowStack[instance.m_WindowStack.Count - 1].m_Arg1, instance.m_WindowStack[instance.m_WindowStack.Count - 1].m_Arg2, instance.m_WindowStack[instance.m_WindowStack.Count - 1].bCameraMode);
      else
        instance.m_Window2.ReOnOpen();
      if (instance.m_WindowStack[instance.m_WindowStack.Count - 1].m_eWindow != EGUIWindow.UI_Chat && instance.m_WindowStack[instance.m_WindowStack.Count - 1].m_eWindow != EGUIWindow.UI_OpenBox)
      {
        UIBattle_Gambling menu = instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
        if ((Object) menu != (Object) null)
          menu.DimPanle.gameObject.SetActive(true);
      }
      else
      {
        UIBattle_Gambling menu = instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
        if ((Object) menu != (Object) null)
          menu.DimPanle.gameObject.SetActive(false);
      }
      instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 11);
    }
  }

  public bool OnBackButtonClick()
  {
    GUIManager instance = GUIManager.Instance;
    if (instance.m_WindowStack.Count != 0)
    {
      GUIWindow menu = instance.FindMenu(instance.m_WindowStack[instance.m_WindowStack.Count - 1].m_eWindow);
      if ((Object) menu != (Object) null && menu.OnBackButtonClick())
        return true;
      this.CloseMenu();
    }
    else
    {
      UIBattle_Gambling menu = instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
      if ((Object) menu != (Object) null)
        menu.CloseUI();
    }
    return true;
  }

  public void saveGambleMode()
  {
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.uLongToFormat((ulong) DataManager.Instance.RoleAttr.UserId);
    cstring.AppendFormat("{0}_GambleMode");
    PlayerPrefs.SetInt(cstring.ToString(), (int) (this.GambleMode + 1));
  }

  public void loadGambleMode()
  {
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.uLongToFormat((ulong) DataManager.Instance.RoleAttr.UserId);
    cstring.AppendFormat("{0}_GambleMode");
    int num = PlayerPrefs.GetInt(cstring.ToString());
    if (num > 0 && num < 3)
    {
      this.GambleMode = (UIBattle_Gambling.eMode) (num - 1);
    }
    else
    {
      this.GambleMode = UIBattle_Gambling.eMode.Normal;
      this.saveGambleMode();
    }
  }

  public struct GambleEventSave
  {
    public uint SN;
    public EActivityState State;
    public long BeginTime;
    public uint RequireTime;
    public ushort GroupID;
    public ushort MonsterID;
  }

  public struct GambleGameData
  {
    public byte Stage;
    public byte RemainFreePlay;

    public void InitGambleGameData()
    {
      this.Stage = (byte) 0;
      this.RemainFreePlay = (byte) 0;
    }
  }

  public struct GambleGameInfo
  {
    public uint BigCost;
    public uint SmallCost;
    public GamblingManager.GambleGameData[] GambleData;
    public uint Prize;

    public void InitGambleGameInfo()
    {
      this.BigCost = 0U;
      this.SmallCost = 0U;
      this.GambleData = new GamblingManager.GambleGameData[2];
      for (int index = 0; index < this.GambleData.Length; ++index)
        this.GambleData[index].InitGambleGameData();
    }
  }

  public class GamebleJackpot
  {
    public ushort KingdomID;
    public CString Tag;
    public CString Name;
    public uint PrizeWins;
    public UIBattle_Gambling.eMode GameType;
    public long WonTime;

    public GamebleJackpot()
    {
      this.KingdomID = (ushort) 0;
      this.Tag = StringManager.Instance.SpawnString();
      this.Name = StringManager.Instance.SpawnString();
      this.PrizeWins = 0U;
      this.GameType = UIBattle_Gambling.eMode.Normal;
      this.WonTime = 0L;
    }
  }
}
