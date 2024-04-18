// Decompiled with JetBrains decompiler
// Type: HideArmyManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
internal class HideArmyManager
{
  private const int TroopDataMax = 16;
  private static HideArmyManager instance;
  private uint[] TroopData = new uint[16];
  private TimeEventDataType ShelterTime;
  private byte LordInShelter;
  private ushort LordID;

  public static HideArmyManager Instance
  {
    get
    {
      if (HideArmyManager.instance == null)
        HideArmyManager.instance = new HideArmyManager();
      return HideArmyManager.instance;
    }
  }

  public bool IsHideArmy() => this.ShelterTime.BeginTime != 0L;

  public void OpenHideArmyUI()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (UnityEngine.Object) menu)
      return;
    if (!this.IsHideArmy())
      menu.m_GroundInfo.OpenAttackPanel(true, true);
    else
      menu.OpenMenu(EGUIWindow.UI_ArmyInfo, 1);
  }

  public uint[] GetHideTroopData() => this.TroopData;

  public bool IsLordInShelter() => this.LordInShelter == (byte) 1;

  public TimeEventDataType GetShelterTime() => this.ShelterTime;

  public long GetTotalHideArmy()
  {
    long totalHideArmy = 0;
    for (int index = 0; index < this.TroopData.Length; ++index)
      totalHideArmy += (long) this.TroopData[index];
    return totalHideArmy;
  }

  public void SendHideTroopInshelter(byte HideLord, byte TimeIndex, ref uint[] _TroopData)
  {
    byte[] numArray = new byte[64];
    ushort data = 0;
    int num = 1;
    int startIdx = 0;
    if (!GUIManager.Instance.ShowUILock(EUILock.HideArmy))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_HIDETROOPINSHELTER;
    messagePacket.AddSeqId();
    messagePacket.Add(HideLord);
    messagePacket.Add(TimeIndex);
    for (int index = 0; index < _TroopData.Length && index < this.TroopData.Length; ++index)
    {
      this.LordInShelter = HideLord;
      this.TroopData[index] = _TroopData[index];
      if (_TroopData[index] != 0U)
      {
        data |= (ushort) (num << index);
        GameConstants.GetBytes(_TroopData[index], numArray, startIdx);
        startIdx += 4;
      }
    }
    messagePacket.Add(data);
    messagePacket.Add(numArray);
    messagePacket.Send();
  }

  public void SendReleaseShelterTroop()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.HideArmy))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_RELEASESHELTERTROOP;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void RecvShelterData(MessagePacket MP)
  {
    this.LordID = MP.ReadUShort();
    this.LordInShelter = this.LordID == (ushort) 0 ? (byte) 0 : (byte) 1;
    this.ShelterTime.BeginTime = MP.ReadLong();
    this.ShelterTime.RequireTime = MP.ReadUInt();
    ushort num = MP.ReadUShort();
    Array.Clear((Array) this.TroopData, 0, this.TroopData.Length);
    for (int index = 0; index < 16; ++index)
    {
      if (((int) num >> index & 1) == 1)
        this.TroopData[index] = MP.ReadUInt();
    }
    if (this.LordInShelter == (byte) 1)
    {
      if (this.LordID != (ushort) 0 && (int) this.LordID < DataManager.Instance.TempFightHeroID.Length)
        DataManager.Instance.TempFightHeroID[(int) this.LordID] = (byte) 1;
      DataManager.Instance.SetFightHeroData();
      GameManager.OnRefresh(NetworkNews.Refresh_Hero);
    }
    if (this.ShelterTime.BeginTime > 0L)
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.HideArmy, true, this.ShelterTime.BeginTime, this.ShelterTime.RequireTime);
    else
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.HideArmy, false, 0L, 0U);
    DataManager.Instance.SetRecvQueueBarData(31);
    DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Hide, byte.MaxValue);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 2);
  }

  public void RecvHideTroopInshelter(MessagePacket MP)
  {
    HideArmyManager.HIDETROOP_RESULT Result = (HideArmyManager.HIDETROOP_RESULT) MP.ReadByte();
    if (Result == HideArmyManager.HIDETROOP_RESULT.HIDETROOP_SUCCESS)
    {
      this.ShelterTime.BeginTime = MP.ReadLong();
      this.ShelterTime.RequireTime = MP.ReadUInt();
      for (int index = 0; index < 16; ++index)
      {
        DataManager.Instance.RoleAttr.m_Soldier[index] -= this.TroopData[index];
        DataManager.Instance.SoldierTotal -= (long) this.TroopData[index];
      }
      DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Hide, byte.MaxValue);
      DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Inner, byte.MaxValue);
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8589U), (ushort) 13);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Expedition, 2);
      if (this.LordInShelter == (byte) 1)
      {
        ushort leaderId = DataManager.Instance.GetLeaderID();
        if (leaderId != (ushort) 0 && (int) leaderId < DataManager.Instance.TempFightHeroID.Length)
          DataManager.Instance.TempFightHeroID[(int) leaderId] = (byte) 1;
        DataManager.Instance.SetFightHeroData();
        GameManager.OnRefresh(NetworkNews.Refresh_Hero);
      }
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.HideArmy, true, this.ShelterTime.BeginTime, this.ShelterTime.RequireTime);
    }
    else
    {
      this.LordInShelter = (byte) 0;
      Array.Clear((Array) this.TroopData, 0, this.TroopData.Length);
      this.ShowHideTroopResultMsg(Result);
    }
    GUIManager.Instance.HideUILock(EUILock.HideArmy);
  }

  public void RecvReleaseShelterTroop(MessagePacket MP)
  {
    HideArmyManager.HIDETROOP_RESULT Result = (HideArmyManager.HIDETROOP_RESULT) MP.ReadByte();
    if (Result == HideArmyManager.HIDETROOP_RESULT.HIDETROOP_SUCCESS)
    {
      this.ShelterTime.BeginTime = 0L;
      this.ShelterTime.RequireTime = 0U;
      for (int index = 0; index < 16; ++index)
      {
        DataManager.Instance.RoleAttr.m_Soldier[index] += this.TroopData[index];
        DataManager.Instance.SoldierTotal += (long) this.TroopData[index];
      }
      DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Hide, (byte) 0);
      DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Inner, byte.MaxValue);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 1);
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8592U), (ushort) 13);
      if (this.LordInShelter == (byte) 1)
      {
        this.LordInShelter = (byte) 0;
        ushort leaderId = DataManager.Instance.GetLeaderID();
        if (leaderId != (ushort) 0 && (int) leaderId < DataManager.Instance.TempFightHeroID.Length)
          DataManager.Instance.TempFightHeroID[(int) leaderId] = (byte) 0;
        DataManager.Instance.SetFightHeroData();
        GameManager.OnRefresh(NetworkNews.Refresh_Hero);
      }
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.HideArmy, false, 0L, 0U);
      Array.Clear((Array) this.TroopData, 0, this.TroopData.Length);
    }
    else
      this.ShowHideTroopResultMsg(Result);
    GUIManager.Instance.HideUILock(EUILock.HideArmy);
  }

  public void RecvShelterTimesUp()
  {
    this.ShelterTime.BeginTime = 0L;
    this.ShelterTime.RequireTime = 0U;
    if (this.LordInShelter == (byte) 1)
    {
      this.LordInShelter = (byte) 0;
      ushort leaderId = DataManager.Instance.GetLeaderID();
      if (leaderId != (ushort) 0 && (int) leaderId < DataManager.Instance.TempFightHeroID.Length)
        DataManager.Instance.TempFightHeroID[(int) leaderId] = (byte) 0;
      DataManager.Instance.SetFightHeroData();
      GameManager.OnRefresh(NetworkNews.Refresh_Hero);
    }
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.HideArmy, false, 0L, 0U);
    for (int index = 0; index < 16; ++index)
    {
      DataManager.Instance.RoleAttr.m_Soldier[index] += this.TroopData[index];
      DataManager.Instance.SoldierTotal += (long) this.TroopData[index];
    }
    GameManager.OnRefresh(NetworkNews.Refresh_Soldier);
    Array.Clear((Array) this.TroopData, 0, this.TroopData.Length);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_DevelopmentDetails, 6);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 1);
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8592U), (ushort) 13);
    DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Hide, (byte) 0);
    DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Inner, byte.MaxValue);
  }

  private void ShowHideTroopResultMsg(HideArmyManager.HIDETROOP_RESULT Result)
  {
    switch (Result)
    {
      case HideArmyManager.HIDETROOP_RESULT.HIDETROOP_NOTEMPTY:
      case HideArmyManager.HIDETROOP_RESULT.HIDETROOP_LORDERR:
      case HideArmyManager.HIDETROOP_RESULT.HIDETROOP_TIMEERR:
        GUIManager.Instance.MsgStr.ClearString();
        GUIManager.Instance.MsgStr.IntToFormat((long) Result);
        GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12067U));
        GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), (ushort) byte.MaxValue);
        break;
      case HideArmyManager.HIDETROOP_RESULT.HIDETROOP_TROOPERR:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9769U), (ushort) byte.MaxValue);
        break;
    }
  }

  private enum HIDETROOP_RESULT : byte
  {
    HIDETROOP_SUCCESS,
    HIDETROOP_NOTEMPTY,
    HIDETROOP_LORDERR,
    HIDETROOP_TROOPERR,
    HIDETROOP_TIMEERR,
  }
}
