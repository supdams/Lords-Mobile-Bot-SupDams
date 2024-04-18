// Decompiled with JetBrains decompiler
// Type: AllianceWarManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class AllianceWarManager
{
  public const byte MemberCountMax = 100;
  public AllianceWarManager._RegisterData[] RegisterData;
  public AllianceWarManager._RegisterData[] WaitData;
  private byte RegisterDataCount;
  private byte RecvCount;
  public bool bReplaying;
  public byte ReplayGame;
  public byte MyPosition;
  public byte MyAllySide;
  public byte MyFinalGame;
  public byte MyRank;
  public byte UpdateSort;
  private byte RegisterMaxCount = 80;
  public AllianceWartHintDataType m_AllianceWarHintData = new AllianceWartHintDataType();
  public CombatPlayerData[] m_CombatPlayerData = new CombatPlayerData[2];
  public ushort mReportRandSeed;
  public byte mReportRandGap;
  public byte mReportResult;

  public AllianceWarManager() => this.Initial();

  public void Initial()
  {
    if (this.RegisterData != null)
      return;
    this.RegisterData = new AllianceWarManager._RegisterData[100];
    this.WaitData = new AllianceWarManager._RegisterData[100];
    this.m_AllianceWarHintData.HeroData = new HeroDataType[5];
    this.m_AllianceWarHintData.Name = new CString(13);
    this.m_AllianceWarHintData.TroopData = new uint[16];
    for (int index = 0; index < 2; ++index)
    {
      this.m_CombatPlayerData[index].HeroInfo = new HeroDataType[5];
      this.m_CombatPlayerData[index].SurviveTroop = new uint[16];
      this.m_CombatPlayerData[index].DeadTroop = new uint[16];
      this.m_CombatPlayerData[index].AttackAttr = new uint[4];
      this.m_CombatPlayerData[index].DefenceAttr = new uint[4];
      this.m_CombatPlayerData[index].HealthAttr = new uint[4];
    }
  }

  public byte GetRegisterCount() => this.RegisterDataCount;

  public void InsertData(int index, ref AllianceWarManager._RegisterData Data)
  {
    int arrayIdx = 0;
    AllianceWarManager._RegisterData[] data = this.GetData(index, ref arrayIdx);
    if ((int) this.RegisterDataCount < (int) this.RegisterMaxCount)
    {
      if ((int) this.RegisterDataCount - arrayIdx > 0)
        Array.Copy((Array) data, arrayIdx, (Array) data, arrayIdx + 1, (int) this.RegisterDataCount - arrayIdx);
    }
    else if (index < (int) this.RegisterMaxCount)
    {
      AllianceWarManager._RegisterData registerData = data[(int) this.RegisterMaxCount - 1];
      int length1 = (int) this.RegisterMaxCount - arrayIdx - 1;
      if (length1 > 0)
        Array.Copy((Array) data, arrayIdx, (Array) data, arrayIdx + 1, length1);
      int length2 = (int) this.RegisterDataCount - (int) this.RegisterMaxCount;
      if (length2 > 0)
        Array.Copy((Array) this.WaitData, 0, (Array) this.WaitData, 1, length2);
      this.WaitData[0] = registerData;
    }
    else
    {
      int length = (int) this.RegisterDataCount - (int) this.RegisterMaxCount - arrayIdx;
      if (length > 0)
        Array.Copy((Array) data, arrayIdx, (Array) data, arrayIdx + 1, length);
    }
    data[arrayIdx] = Data;
    ++this.RegisterDataCount;
  }

  private void MoveData(int index, int newIndex)
  {
    if (index == newIndex)
      return;
    int arrayIdx1 = 0;
    int arrayIdx2 = 0;
    AllianceWarManager._RegisterData[] data1 = this.GetData(index, ref arrayIdx1);
    AllianceWarManager._RegisterData[] data2 = this.GetData(newIndex, ref arrayIdx2);
    if (data1 == data2)
    {
      AllianceWarManager._RegisterData registerData = data1[arrayIdx1];
      if (index > newIndex)
        Array.Copy((Array) data1, arrayIdx2, (Array) data1, arrayIdx2 + 1, arrayIdx1 - arrayIdx2);
      else
        Array.Copy((Array) data1, arrayIdx1 + 1, (Array) data1, arrayIdx1, arrayIdx2 - arrayIdx1);
      data1[arrayIdx2] = registerData;
    }
    else if (index > newIndex)
    {
      AllianceWarManager._RegisterData registerData1 = data2[(int) this.RegisterMaxCount - 1];
      AllianceWarManager._RegisterData registerData2 = data1[arrayIdx1];
      int length = (int) this.RegisterMaxCount - 1 - arrayIdx2;
      if (length > 0)
        Array.Copy((Array) data2, arrayIdx2, (Array) data2, arrayIdx2 + 1, length);
      data2[arrayIdx2] = registerData2;
      if (arrayIdx1 > 0)
        Array.Copy((Array) data1, 0, (Array) data1, 1, arrayIdx1);
      data1[0] = registerData1;
    }
    else
    {
      AllianceWarManager._RegisterData registerData3 = data2[0];
      AllianceWarManager._RegisterData registerData4 = data1[arrayIdx1];
      int length = (int) this.RegisterMaxCount - arrayIdx1 - 1;
      if (length > 0)
        Array.Copy((Array) data1, arrayIdx1 + 1, (Array) data1, arrayIdx1, length);
      data1[(int) this.RegisterMaxCount - 1] = registerData3;
      if (arrayIdx2 > 0)
        Array.Copy((Array) data2, 1, (Array) data2, 0, arrayIdx2);
      data2[arrayIdx2] = registerData4;
    }
  }

  private AllianceWarManager._RegisterData[] GetData(int index, ref int arrayIdx)
  {
    if ((int) this.RegisterMaxCount > index)
    {
      arrayIdx = index;
      if (arrayIdx >= this.RegisterData.Length)
        arrayIdx = 0;
      return this.RegisterData;
    }
    arrayIdx = index - (int) this.RegisterMaxCount;
    if (arrayIdx >= this.WaitData.Length)
      arrayIdx = 0;
    return this.WaitData;
  }

  public void Clear()
  {
    for (int index = 0; index < this.RegisterData.Length && this.RegisterData[index].Name != null; ++index)
      this.RegisterData[index].Clear();
    for (int index = 0; index < this.WaitData.Length && this.WaitData[index].Name != null; ++index)
      this.WaitData[index].Clear();
    this.RegisterDataCount = (byte) 0;
  }

  public byte GetRegisterMaxCount() => this.RegisterMaxCount;

  public void SetRegisterMaxCount(byte memberCount) => this.RegisterMaxCount = memberCount;

  public void SendAllianceWarList()
  {
    this.RecvCount = (byte) 0;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_MEMBERLIST;
    messagePacket.Send();
    this.SetRegisterMaxCount(ActivityManager.Instance.AW_MemberCount);
  }

  public void RecvAllianceWarMemberListBegin(MessagePacket MP)
  {
    this.MyRank = MP.ReadByte();
    this.RegisterDataCount = MP.ReadByte();
    if (this.RegisterDataCount > (byte) 100)
      this.RegisterDataCount = (byte) 100;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarRegister, 1, (int) this.RegisterDataCount);
    if (ActivityManager.Instance.AW_State != EAllianceWarState.EAWS_Replay)
      return;
    LeaderBoardManager.Instance.AllianceWarAlliBoardUpdateTime = DataManager.Instance.ServerTime + 180L;
    LeaderBoardManager.Instance.MobiGroupAllianceID = DataManager.Instance.RoleAlliance.Id;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_AlliVSAlliBoard, 0);
  }

  public void RecvAllianceWarMemberList(MessagePacket MP)
  {
    byte num = MP.ReadByte();
    int arrayIdx = 0;
    for (byte index = 0; (int) index < (int) num && this.RecvCount != (byte) 100; ++index)
    {
      AllianceWarManager._RegisterData[] data = this.GetData((int) this.RecvCount, ref arrayIdx);
      if (arrayIdx >= data.Length)
        break;
      data[arrayIdx].Initial();
      MP.ReadStringPlus(13, data[arrayIdx].Name);
      data[arrayIdx].Power = MP.ReadULong();
      ++this.RecvCount;
    }
  }

  public void RecvUpdateAllianceWarMemberList(MessagePacket MP)
  {
    if ((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarRegister) == (UnityEngine.Object) null)
      return;
    byte num1 = MP.ReadByte();
    byte num2 = MP.ReadByte();
    if (num1 == (byte) 0 || num2 == (byte) 0 || num1 > (byte) 100 || num2 > (byte) 100)
    {
      this.SendAllianceWarList();
    }
    else
    {
      if (this.MyRank > (byte) 0)
      {
        if ((int) num1 == (int) this.MyRank)
          this.MyRank = num2;
        else if ((int) num1 > (int) num2)
        {
          if ((int) num1 > (int) this.MyRank && (int) num2 <= (int) this.MyRank)
            ++this.MyRank;
        }
        else if ((int) num1 < (int) num2 && (int) num2 >= (int) this.MyRank && (int) num1 < (int) this.MyRank)
          --this.MyRank;
      }
      byte index = (byte) ((uint) num1 - 1U);
      byte newIndex = (byte) ((uint) num2 - 1U);
      int arrayIdx = 0;
      AllianceWarManager._RegisterData[] data = this.GetData((int) index, ref arrayIdx);
      if (data[arrayIdx].Name == null)
        return;
      MP.ReadStringPlus(13, data[arrayIdx].Name);
      data[arrayIdx].Power = MP.ReadULong();
      if ((int) index != (int) newIndex)
        this.MoveData((int) index, (int) newIndex);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarRegister, 2);
    }
  }

  public void RecvInsertAllianceWarMemberList(MessagePacket MP)
  {
    if ((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarRegister) == (UnityEngine.Object) null)
      return;
    byte num = MP.ReadByte();
    if (num == (byte) 0 || num >= (byte) 100)
    {
      this.SendAllianceWarList();
    }
    else
    {
      if (this.MyRank > (byte) 0 && (int) this.MyRank >= (int) num)
        ++this.MyRank;
      byte index = (byte) ((uint) num - 1U);
      AllianceWarManager._RegisterData Data = new AllianceWarManager._RegisterData();
      Data.Initial();
      MP.ReadStringPlus(13, Data.Name);
      Data.Power = MP.ReadULong();
      if (this.RegisterDataCount < (byte) 100)
      {
        this.InsertData((int) index, ref Data);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarRegister, 1, (int) this.RegisterDataCount);
      }
      else
        Data.Clear();
    }
  }

  public ulong GetEnrollPower()
  {
    if (this.RegisterDataCount == (byte) 0)
      return 0;
    if ((int) this.RegisterDataCount < (int) this.RegisterMaxCount)
      return this.RegisterData[(int) this.RegisterDataCount - 1].Power;
    return this.RegisterMaxCount > (byte) 0 ? this.RegisterData[(int) this.RegisterMaxCount - 1].Power : this.RegisterData[(int) this.RegisterMaxCount].Power;
  }

  public AllianceWarManager._RegisterData GetDataIndex(int index)
  {
    int arrayIdx = 0;
    if (index < 0 || (int) this.RegisterDataCount <= index)
    {
      AllianceWarManager._RegisterData[] data = this.GetData(0, ref arrayIdx);
      data[arrayIdx].Initial();
      return data[arrayIdx];
    }
    if ((int) this.RegisterMaxCount <= index)
      return this.GetData(index, ref arrayIdx)[arrayIdx];
    return (int) this.RegisterDataCount < (int) this.RegisterMaxCount ? this.GetData(index, ref arrayIdx)[(int) this.RegisterDataCount - arrayIdx - 1] : this.GetData(index, ref arrayIdx)[(int) this.RegisterMaxCount - arrayIdx - 1];
  }

  public AllianceWarManager._RegisterData GetMyDataIdx(int index)
  {
    if (index <= 0)
      return new AllianceWarManager._RegisterData();
    int arrayIdx = 0;
    return this.GetData(index - 1, ref arrayIdx)[arrayIdx];
  }

  public int getMyRankIndex()
  {
    if (this.MyRank <= (byte) 0)
      return -1;
    if ((int) this.RegisterDataCount < (int) this.RegisterMaxCount)
      return (int) this.RegisterDataCount - (int) this.MyRank + 1;
    return (int) this.RegisterMaxCount > (int) this.MyRank - 1 ? (int) this.RegisterMaxCount - (int) this.MyRank + 1 : (int) this.MyRank;
  }

  public void FormatRank(int index, ref CString Str)
  {
    Str.ClearString();
    int arrayIdx = 0;
    if (this.RegisterData == this.GetData(index, ref arrayIdx))
    {
      Str.IntToFormat((long) (arrayIdx + 1));
      Str.AppendFormat("{0}");
    }
    else
    {
      Str.StringToFormat("~");
      Str.IntToFormat((long) (arrayIdx + 1));
      Str.AppendFormat("{0}{1}");
    }
  }

  public void Recv_MSG_RESP_SIGNUP_ALLIANCEWAR(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Expedition);
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Expedition);
    switch ((ERESP_SIGNUP_ALLIANCEWAR_RESULT) MP.ReadByte())
    {
      case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_SUCCESS:
        byte num = MP.ReadByte();
        ActivityManager.Instance.AW_SignUpAllianceID = DataManager.Instance.RoleAlliance.Id;
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Expedition, 2);
        if (this.MyRank > (byte) 0)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17006U), (ushort) byte.MaxValue);
        }
        else
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17018U), (ushort) byte.MaxValue);
          FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_GUILD_SHOWDOWN_REGISTRATION);
        }
        this.MyRank = num;
        break;
      case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_TROOPERR:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7226U), (ushort) byte.MaxValue);
        break;
      case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_LATE:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17035U), (ushort) byte.MaxValue);
        break;
      case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_OTHERALLY:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17010U), (ushort) byte.MaxValue);
        break;
      case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_NOALLY:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17020U), (ushort) byte.MaxValue);
        break;
      case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_STRONGHOLD:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17037U), (ushort) byte.MaxValue);
        break;
      case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_FULL:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17011U), (ushort) byte.MaxValue);
        break;
      case ERESP_SIGNUP_ALLIANCEWAR_RESULT.ERESP_SIGNUP_ALLIANCEWAR_UNKNOWNERR:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9771U), (ushort) byte.MaxValue);
        break;
    }
  }

  public void Recv_MSG_RESP_ALLIANCEWAR_REPLAY_FAILED(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Activity);
    this.MyFinalGame = MP.ReadByte();
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      ActivityManager.Instance.AllianceWarReopenCheck();
      if (this.MyFinalGame < (byte) 1 || this.MyFinalGame > (byte) 4)
      {
        menu.OpenMenu(EGUIWindow.UI_AllianceWarBattle, bCameraMode: true);
      }
      else
      {
        ActivityManager.Instance.AW_bcalculateEnd = true;
        menu.OpenMenu(EGUIWindow.UI_AllianceWarOver);
      }
    }
    if (this.MyFinalGame >= (byte) 1 && this.MyFinalGame <= (byte) 4)
      return;
    Debug.LogError((object) ("ErrCode " + (object) this.MyFinalGame));
  }

  public void Send_MSG_REQUEST_ALLIANCEWAR_MEMBER_DATA(byte Position)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_MEMBER_DATA;
    messagePacket.AddSeqId();
    messagePacket.Add(Position);
    messagePacket.Send();
    int arrayIdx = 0;
    this.m_AllianceWarHintData.Name.ClearString();
    this.m_AllianceWarHintData.Name.Append(this.GetData((int) Position - 1, ref arrayIdx)[arrayIdx].Name);
    this.m_AllianceWarHintData.AllianceTagTag = DataManager.Instance.RoleAlliance.Tag.ToString();
    Array.Clear((Array) this.m_AllianceWarHintData.HeroData, 0, this.m_AllianceWarHintData.HeroData.Length);
    Array.Clear((Array) this.m_AllianceWarHintData.TroopData, 0, this.m_AllianceWarHintData.TroopData.Length);
  }

  public void Recv_MSG_RESP_ALLIANCEWAR_MEMBER_DATA(MessagePacket MP)
  {
    this.m_AllianceWarHintData.bMain = false;
    this.m_AllianceWarHintData.Head = MP.ReadUShort();
    for (int index = 0; index < 5; ++index)
    {
      this.m_AllianceWarHintData.HeroData[index].ID = MP.ReadUShort();
      this.m_AllianceWarHintData.HeroData[index].Rank = MP.ReadByte();
      this.m_AllianceWarHintData.HeroData[index].Star = MP.ReadByte();
    }
    this.m_AllianceWarHintData.bMain = this.m_AllianceWarHintData.HeroData[0].ID != (ushort) 0 && (int) this.m_AllianceWarHintData.Head == (int) this.m_AllianceWarHintData.HeroData[0].ID;
    for (int index = 0; index < 16; ++index)
      this.m_AllianceWarHintData.TroopData[index] = MP.ReadUInt();
    this.m_AllianceWarHintData.ArmyCoordIndex = MP.ReadByte();
    this.m_AllianceWarHintData.ArmyCoordIndex = (byte) Mathf.Clamp((int) this.m_AllianceWarHintData.ArmyCoordIndex, 0, 5);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarRegister, 4);
  }

  public void Send_MSG_REQUEST_ALLIANCEWAR_MATCH_PLAYERDATA(byte MatchID, byte Side, byte Position)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_MATCH_PLAYERDATA;
    messagePacket.AddSeqId();
    messagePacket.Add(MatchID);
    messagePacket.Add(Side);
    messagePacket.Add(Position);
    messagePacket.Send();
    Array.Clear((Array) this.m_AllianceWarHintData.HeroData, 0, this.m_AllianceWarHintData.HeroData.Length);
    Array.Clear((Array) this.m_AllianceWarHintData.TroopData, 0, this.m_AllianceWarHintData.TroopData.Length);
  }

  public void Recv_MSG_RESP_ALLIANCEWAR_MATCH_PLAYERDATA(MessagePacket MP)
  {
    this.m_AllianceWarHintData.bMain = false;
    this.m_AllianceWarHintData.Head = MP.ReadUShort();
    for (int index = 0; index < 5; ++index)
    {
      this.m_AllianceWarHintData.HeroData[index].ID = MP.ReadUShort();
      this.m_AllianceWarHintData.HeroData[index].Rank = MP.ReadByte();
      this.m_AllianceWarHintData.HeroData[index].Star = MP.ReadByte();
    }
    this.m_AllianceWarHintData.bMain = (int) this.m_AllianceWarHintData.Head == (int) this.m_AllianceWarHintData.HeroData[0].ID;
    for (int index = 0; index < 16; ++index)
      this.m_AllianceWarHintData.TroopData[index] = MP.ReadUInt();
    this.m_AllianceWarHintData.ArmyCoordIndex = MP.ReadByte();
    this.m_AllianceWarHintData.ArmyCoordIndex = (byte) Mathf.Clamp((int) this.m_AllianceWarHintData.ArmyCoordIndex, 0, 5);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarBattle, 10);
  }

  public void Send_MSG_REQUEST_ALLIANCEWAR_COMBAT_REPORT(byte MatchID, byte CombatID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_COMBAT_REPORT;
    messagePacket.AddSeqId();
    messagePacket.Add(MatchID);
    messagePacket.Add(CombatID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.AllianceWar_Fs);
  }

  public void Recv_MSG_RESP_ALLIANCEWAR_COMBAT_REPORT(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.AllianceWar_Fs);
    this.mReportRandSeed = MP.ReadUShort();
    this.mReportRandGap = MP.ReadByte();
    this.mReportResult = MP.ReadByte();
    for (int index1 = 0; index1 < 2; ++index1)
    {
      this.m_CombatPlayerData[index1].Name = MP.ReadString(13);
      this.m_CombatPlayerData[index1].KingdomID = MP.ReadUShort();
      this.m_CombatPlayerData[index1].StrongholdLevel = MP.ReadByte();
      this.m_CombatPlayerData[index1].Level = MP.ReadByte();
      this.m_CombatPlayerData[index1].Head = MP.ReadUShort();
      this.m_CombatPlayerData[index1].VIPLevel = MP.ReadByte();
      this.m_CombatPlayerData[index1].AllianceRank = MP.ReadByte();
      for (int index2 = 0; index2 < 5; ++index2)
      {
        this.m_CombatPlayerData[index1].HeroInfo[index2].ID = MP.ReadUShort();
        this.m_CombatPlayerData[index1].HeroInfo[index2].Rank = MP.ReadByte();
        this.m_CombatPlayerData[index1].HeroInfo[index2].Star = MP.ReadByte();
      }
      this.m_CombatPlayerData[index1].bMain = this.m_CombatPlayerData[index1].HeroInfo[0].ID != (ushort) 0 && (int) this.m_CombatPlayerData[index1].Head == (int) this.m_CombatPlayerData[index1].HeroInfo[0].ID;
      this.m_CombatPlayerData[index1].LosePower = MP.ReadULong();
      for (int index3 = 0; index3 < 16; ++index3)
        this.m_CombatPlayerData[index1].SurviveTroop[index3] = MP.ReadUInt();
      for (int index4 = 0; index4 < 16; ++index4)
        this.m_CombatPlayerData[index1].DeadTroop[index4] = MP.ReadUInt();
      for (int index5 = 0; index5 < 4; ++index5)
        this.m_CombatPlayerData[index1].AttackAttr[index5] = MP.ReadUInt();
      for (int index6 = 0; index6 < 4; ++index6)
        this.m_CombatPlayerData[index1].DefenceAttr[index6] = MP.ReadUInt();
      for (int index7 = 0; index7 < 4; ++index7)
        this.m_CombatPlayerData[index1].HealthAttr[index7] = MP.ReadUInt();
      this.m_CombatPlayerData[index1].ArmyCoordIndex = MP.ReadByte();
      this.m_CombatPlayerData[index1].ArmyCoordIndex = (byte) Mathf.Clamp((int) this.m_CombatPlayerData[index1].ArmyCoordIndex, 0, 5);
    }
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.OpenMenu(EGUIWindow.UI_Alliance_FS);
  }

  public struct _RegisterData
  {
    public CString Name;
    public ushort Head;
    public ulong Power;

    public void Initial()
    {
      if (this.Name != null)
        return;
      this.Name = StringManager.Instance.SpawnString();
    }

    public void Clear()
    {
      StringManager.Instance.DeSpawnString(this.Name);
      this.Name = (CString) null;
    }
  }
}
