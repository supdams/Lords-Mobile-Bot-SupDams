// Decompiled with JetBrains decompiler
// Type: MobilizationManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class MobilizationManager
{
  private static MobilizationManager instance;
  public bool bFirstOpen = true;
  public int mMobilizationScroll;
  public float mMobilizationScroll_Y;
  public byte availableMission;
  public byte extraMission;
  public byte involvedMember;
  public byte AllianceError;
  public byte mActivityLv;
  public byte mMissionStatus;
  public ushort mMissionID;
  public byte mMissionDifficulty;
  public long mMissionTime;
  public uint mMissionTarget;
  public long mMissionStart;
  public int mScrollFrame;
  public uint CompleteScore;
  public uint AMScore;
  public byte AMCompleteDegree;
  private float CheckTime;
  public MobilizationData[] mMobilizationMission = new MobilizationData[21];
  public byte mextraMissionBuyLimit;
  public ushort mextraMissionPrize;
  public byte mMobilizationFutureRank;
  public bool bFirstRequestActivityAmDegeePrize;
  public long AllyMobilizationBeginTime;
  public sRecvRewardsSelect[] m_RecvRewardsSelect = new sRecvRewardsSelect[35];
  public ushort[] RSAnimationItemID = new ushort[35];
  public uint PrizeCrystal;
  public uint PrizeAllianceMoney;
  public int UIRewardsSelectIndex;
  public float RewardsSelectPosY;
  public bool bRewardsSelectFirstClickItem;
  public byte SpecialPrize;
  private byte[] _DegreeRanges;
  public byte mMoreRewards;

  private MobilizationManager() => this.InitRewardsSelect();

  public static MobilizationManager Instance
  {
    get
    {
      if (MobilizationManager.instance == null)
        MobilizationManager.instance = new MobilizationManager();
      return MobilizationManager.instance;
    }
  }

  public byte[] DegreeRanges
  {
    get
    {
      if (this._DegreeRanges == null)
      {
        int tableCount = DataManager.Instance.AllianceMobilizationDegreeRange.TableCount;
        this._DegreeRanges = new byte[tableCount + 1];
        for (int Index = 0; Index < tableCount; ++Index)
          this._DegreeRanges[Index + 1] = DataManager.Instance.AllianceMobilizationDegreeRange.GetRecordByIndex(Index).Range;
      }
      return this._DegreeRanges;
    }
  }

  public void Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DATA()
  {
    GUIManager.Instance.ShowUILock(EUILock.AllianceMobilization);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DATA;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_DATA(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.AllianceMobilization);
    this.availableMission = MP.ReadByte();
    this.extraMission = MP.ReadByte();
    this.involvedMember = MP.ReadByte();
    this.AllianceError = MP.ReadByte();
    if (this.mMissionID != (ushort) 0 && this.AllianceError != (byte) 0)
    {
      this.mMissionID = (ushort) 0;
      this.mMissionStatus = (byte) 0;
      ActivityManager.Instance.CheckAMShowHint();
    }
    Array.Clear((Array) this.mMobilizationMission, 0, this.mMobilizationMission.Length);
    for (int index1 = 1; index1 < 21; ++index1)
    {
      this.mMobilizationMission[index1].MissionType = MP.ReadUShort();
      if (this.mMobilizationMission[index1].MissionType == (ushort) 1001)
      {
        this.mMobilizationMission[index1].CDTime = MP.ReadLong();
      }
      else
      {
        this.mMobilizationMission[index1].Difficulty = MP.ReadByte();
        this.mMobilizationMission[index1].Difficulty = (byte) Mathf.Clamp((int) this.mMobilizationMission[index1].Difficulty, 0, 3);
        for (int index2 = 0; index2 < 7; ++index2)
        {
          int num = (int) MP.ReadByte();
        }
      }
    }
    this.mMoreRewards = MP.ReadByte();
    this.mextraMissionBuyLimit = MP.ReadByte();
    this.mextraMissionPrize = MP.ReadUShort();
    this.mMobilizationFutureRank = MP.ReadByte();
    this.mMobilizationFutureRank = (byte) Mathf.Clamp((int) this.mMobilizationFutureRank, 0, 5);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 0);
  }

  public void Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_REFLASH()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_REFLASH;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_BUY()
  {
    GUIManager.Instance.ShowUILock(EUILock.AllianceMobilization);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_BUY;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_BUY(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.AllianceMobilization);
    if (MP.ReadByte() != (byte) 0)
      return;
    this.availableMission = MP.ReadByte();
    this.extraMission = MP.ReadByte();
    GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0, eSpentCredits.eHeroEnhance);
    this.mextraMissionPrize = MP.ReadUShort();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 10);
  }

  public void Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_GET(byte MissionPos)
  {
    GUIManager.Instance.ShowUILock(EUILock.AllianceMobilization);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_GET;
    messagePacket.AddSeqId();
    messagePacket.Add(MissionPos);
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_GET(MessagePacket MP)
  {
    byte num = MP.ReadByte();
    if (num != byte.MaxValue)
      GUIManager.Instance.HideUILock(EUILock.AllianceMobilization);
    switch (num)
    {
      case 0:
        AudioManager.Instance.PlayUISFX(UIKind.ItemUse);
        this.mMissionID = MP.ReadUShort();
        this.mMissionDifficulty = MP.ReadByte();
        this.mMissionDifficulty = (byte) Mathf.Clamp((int) this.mMissionDifficulty, 0, 3);
        this.availableMission = MP.ReadByte();
        this.mMissionStatus = (byte) 0;
        this.mMissionTime = MP.ReadLong();
        this.mMissionTarget = MP.ReadUInt();
        DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, true, DataManager.Instance.ServerTime, (uint) (this.mMissionTime - DataManager.Instance.ServerTime));
        DataManager.Instance.SetRecvQueueBarData(32);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 9);
        FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_GUILD_FEST_QUEST);
        break;
      case 4:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1344U), (ushort) byte.MaxValue);
        break;
      case byte.MaxValue:
        this.mMissionID = MP.ReadUShort();
        this.mMissionDifficulty = MP.ReadByte();
        this.mMissionDifficulty = (byte) Mathf.Clamp((int) this.mMissionDifficulty, 0, 3);
        this.availableMission = MP.ReadByte();
        this.mMissionTime = MP.ReadLong();
        this.mMissionTarget = MP.ReadUInt();
        this.mMissionStart = MP.ReadLong();
        if (this.mMissionID != (ushort) 0)
        {
          DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, true, this.mMissionStart, (uint) (this.mMissionTime - this.mMissionStart));
          DataManager.Instance.SetRecvQueueBarData(32);
        }
        else
          DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, false, 0L, 0U);
        this.mMissionStatus = (byte) 0;
        MobilizationMissionData recordByKey = DataManager.Instance.AllianceMobilizationMission.GetRecordByKey(this.mMissionID);
        if (recordByKey.MissionMaxValue != null && (int) this.mMissionTarget == (int) recordByKey.MissionMaxValue[(int) this.mMissionDifficulty])
        {
          this.mMissionStatus = (byte) 1;
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 8);
          ActivityManager.Instance.CheckAMShowHint();
          break;
        }
        if (this.mMissionID == (ushort) 0 || this.mMissionStatus != (byte) 0 || this.mMissionTime - DataManager.Instance.ServerTime >= 0L)
          break;
        this.mMissionStatus = (byte) 2;
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 8);
        ActivityManager.Instance.CheckAMShowHint();
        break;
    }
  }

  public void Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DEL(byte MissionPos)
  {
    GUIManager.Instance.ShowUILock(EUILock.AllianceMobilization);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DEL;
    messagePacket.AddSeqId();
    messagePacket.Add(MissionPos);
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_DEL(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.AllianceMobilization);
    switch (MP.ReadByte())
    {
      case 0:
        AudioManager.Instance.PlayUISFX(UIKind.Research);
        break;
      case 4:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1344U), (ushort) byte.MaxValue);
        break;
      case byte.MaxValue:
        AudioManager.Instance.PlayUISFX(UIKind.Research);
        this.mMissionID = (ushort) 0;
        this.mMissionStatus = (byte) 0;
        DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, false, 0L, 0U);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 9);
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(3669U), (ushort) byte.MaxValue);
        ActivityManager.Instance.CheckAMShowHint();
        break;
    }
  }

  public void Send_MSG_REQUEST_ALLIANVEMOBLIZATION_MISSION_FINISH()
  {
    GUIManager.Instance.ShowUILock(EUILock.AllianceMobilization);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_FINISH;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_ALLIANCEMOBLIZATION_MISSION_FINISH(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.AllianceMobilization);
    if (MP.ReadByte() != (byte) 0)
      return;
    AudioManager.Instance.PlayUISFX(UIKind.MissionReward);
    this.mMissionID = (ushort) 0;
    this.mMissionStatus = (byte) 0;
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, false, 0L, 0U);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 9, 1);
    ActivityManager.Instance.CheckAMShowHint();
    FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.CREDITS_FOR_GUILD_FEST, ActivityManager.Instance.AllyMobilizationData.EventBeginTime, 0UL);
  }

  public void Recv_MSG_RESP_ALLIANCEMOBILIZATION_MISSION_UPDATE(MessagePacket MP)
  {
    this.mMissionTarget = MP.ReadUInt();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 7);
    if ((int) this.mMissionTarget != (int) DataManager.Instance.AllianceMobilizationMission.GetRecordByKey(this.mMissionID).MissionMaxValue[(int) this.mMissionDifficulty])
      return;
    this.mMissionStatus = (byte) 1;
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, true, 0L, 0U);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 8);
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1361U), (ushort) byte.MaxValue);
    ActivityManager.Instance.CheckAMShowHint();
  }

  public void Recv_MSG_RESP_ALLIANCEMOBILIZATION_MISSION_DONE(MessagePacket MP)
  {
    this.mMissionStatus = (byte) 1;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 8);
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1361U), (ushort) byte.MaxValue);
    ActivityManager.Instance.CheckAMShowHint();
  }

  public void SetAllyMobilizationBeginTime(long time) => this.AllyMobilizationBeginTime = time;

  public void InitRewardsSelect()
  {
    for (int index = 0; index < this.m_RecvRewardsSelect.Length; ++index)
      this.m_RecvRewardsSelect[index].Init();
  }

  public void ClearRewardsSelectData()
  {
    this.bFirstRequestActivityAmDegeePrize = false;
    this.UIRewardsSelectIndex = 0;
    this.RewardsSelectPosY = 0.0f;
    Array.Clear((Array) this.m_RecvRewardsSelect, 0, this.m_RecvRewardsSelect.Length);
    Array.Clear((Array) this.RSAnimationItemID, 0, this.RSAnimationItemID.Length);
  }

  public void SendActivityAmDegeePrize()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AM_DEGREEPRIZE;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void RecvActivityAmDegeePrize(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    for (int index1 = 0; index1 < this.m_RecvRewardsSelect.Length; ++index1)
    {
      this.m_RecvRewardsSelect[index1].SelectIndex = index1 < (int) this.AMCompleteDegree ? (byte) 0 : (byte) 4;
      if (index1 < 20)
      {
        for (int index2 = 0; index2 < this.m_RecvRewardsSelect[index1].ItemIndex.Length; ++index2)
          this.m_RecvRewardsSelect[index1].ItemIndex[index2] = (int) MP.ReadByte();
      }
    }
    this.SpecialPrize = MP.ReadByte();
    this.bFirstRequestActivityAmDegeePrize = true;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_RewardsSelect, 1);
  }

  public void RecvActivityAmDegeePrize_New(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    this.SpecialPrize = MP.ReadByte();
    for (int index1 = 0; index1 < this.m_RecvRewardsSelect.Length; ++index1)
    {
      this.m_RecvRewardsSelect[index1].SelectIndex = index1 < (int) this.AMCompleteDegree ? (byte) 0 : (byte) 4;
      for (int index2 = 0; index2 < this.m_RecvRewardsSelect[index1].ItemIndex.Length; ++index2)
        this.m_RecvRewardsSelect[index1].ItemIndex[index2] = index2 >= (int) DataManager.Instance.RoleAlliance.AMMaxDegree ? 0 : (int) MP.ReadByte();
    }
    this.bFirstRequestActivityAmDegeePrize = true;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_RewardsSelect, 1);
  }

  public void SendActivityAmGetDegreePrize()
  {
    GUIManager.Instance.ShowUILock(EUILock.AllianceMobilization);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AM_GET_DEGREEPRIZE;
    messagePacket.AddSeqId();
    for (int index = 0; index < this.m_RecvRewardsSelect.Length; ++index)
      messagePacket.Add(this.m_RecvRewardsSelect[index].SelectIndex);
    messagePacket.Send();
  }

  public void RecvActivityAmGetDegreePrize(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.AllianceMobilization);
    if (MP.ReadByte() != (byte) 0)
      return;
    Array.Clear((Array) this.RSAnimationItemID, 0, this.RSAnimationItemID.Length);
    this.PrizeCrystal = 0U;
    this.PrizeAllianceMoney = 0U;
    uint num1 = MP.ReadUInt();
    uint num2 = MP.ReadUInt();
    if (num1 > DataManager.Instance.RoleAttr.Diamond)
      this.PrizeCrystal = num1 - DataManager.Instance.RoleAttr.Diamond;
    if (num2 > DataManager.Instance.RoleAlliance.Money)
      this.PrizeAllianceMoney = num2 - DataManager.Instance.RoleAlliance.Money;
    DataManager.Instance.RoleAttr.Diamond = num1;
    DataManager.Instance.RoleAlliance.Money = num2;
    byte num3 = MP.ReadByte();
    for (int index = 0; index < (int) num3; ++index)
    {
      ushort ItemID = MP.ReadUShort();
      ushort Quantity = MP.ReadUShort();
      byte Rare = MP.ReadByte();
      DataManager.Instance.SetCurItemQuantity(ItemID, Quantity, Rare, 0L);
      if (index < this.RSAnimationItemID.Length)
        this.RSAnimationItemID[index] = ItemID;
      DataManager.Instance.RoleAttr.bAllianceMobilizationGetPrize = (byte) 1;
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_RewardsSelect, 0);
    GameManager.OnRefresh(NetworkNews.Refresh_Alliance);
    GameManager.OnRefresh();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 99);
    ActivityManager.Instance.CheckAMShowHint();
  }

  public bool IsGetPrize()
  {
    return DataManager.Instance.RoleAttr.bAllianceMobilizationGetPrize == (byte) 1;
  }

  public void OnAMCompleteDegreeChange()
  {
    for (int index = 0; index < this.m_RecvRewardsSelect.Length; ++index)
      this.m_RecvRewardsSelect[index].SelectIndex = index < (int) this.AMCompleteDegree ? (byte) 0 : (byte) 4;
  }

  public void SetRewardsSelectDataSave()
  {
    PlayerPrefs.SetString("RewardsSelectFirstClickItem", this.bRewardsSelectFirstClickItem.ToString());
  }

  public void GetRewardsSelecteDataSave()
  {
    bool.TryParse(PlayerPrefs.GetString("RewardsSelectFirstClickItem"), out this.bRewardsSelectFirstClickItem);
  }

  ~MobilizationManager()
  {
  }

  public void Update()
  {
    this.CheckTime -= Time.unscaledDeltaTime;
    if ((double) this.CheckTime > 0.0)
      return;
    this.CheckTime = 1f;
    if (this.mMissionID == (ushort) 0 || this.mMissionStatus != (byte) 0 || this.mMissionTime - DataManager.Instance.ServerTime >= 0L)
      return;
    this.mMissionStatus = (byte) 2;
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Mobilization, true, 0L, 0U);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 8);
    ActivityManager.Instance.CheckAMShowHint();
  }
}
