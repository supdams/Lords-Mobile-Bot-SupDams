// Decompiled with JetBrains decompiler
// Type: JailManage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;

#nullable disable
public class JailManage
{
  public const int Execution_CountDown = 21600;
  public const int Poison_Take = 108000;

  public static void MSG_RESP_LORD_BEINGCAPTIVE(MessagePacket MP)
  {
    if (DataManager.Instance.beCaptured.AlliTag == null)
      DataManager.Instance.beCaptured.AlliTag = StringManager.Instance.SpawnString();
    if (DataManager.Instance.beCaptured.name == null)
      DataManager.Instance.beCaptured.name = StringManager.Instance.SpawnString();
    DataManager.Instance.beCaptured.AlliTag.ClearString();
    DataManager.Instance.beCaptured.name.ClearString();
    DataManager.Instance.beCaptured.KingdomID = MP.ReadUShort();
    DataManager.Instance.beCaptured.head = MP.ReadUShort();
    MP.ReadStringPlus(3, DataManager.Instance.beCaptured.AlliTag);
    MP.ReadStringPlus(13, DataManager.Instance.beCaptured.name);
    PointCode pointCode = new PointCode();
    pointCode.zoneID = MP.ReadUShort();
    pointCode.pointID = MP.ReadByte();
    DataManager.Instance.beCaptured.MapID = GameConstants.PointCodeToMapID(pointCode.zoneID, pointCode.pointID);
    DataManager.Instance.beCaptured.prisonerStat = (PrisonerState) MP.ReadByte();
    DataManager.Instance.beCaptured.nowCaptureStat = LoadCaptureState.Captured;
    DataManager.Instance.beCaptured.StartActionTime = MP.ReadLong();
    DataManager.Instance.beCaptured.TotalTime = MP.ReadUInt();
    DataManager.Instance.beCaptured.Ransom = MP.ReadUInt();
    DataManager.Instance.beCaptured.Bounty = MP.ReadUInt();
    MP.ReadByte();
    DataManager.Instance.beCaptured.HomeKingdomID = MP.ReadUShort();
    ushort leaderId = DataManager.Instance.GetLeaderID();
    if (leaderId != (ushort) 0)
    {
      DataManager.Instance.TempFightHeroID[(int) leaderId] = (byte) 1;
      DataManager.Instance.SetFightHeroData();
      GameManager.OnRefresh(NetworkNews.Refresh_Hero);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroList_Soldier2, 1);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 3);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 18);
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Hero);
    DataManager.Instance.AttribVal.UpdateLordEquipData();
  }

  public static void MSG_RESP_UPDATE_CAPTIVE(MessagePacket MP)
  {
    switch (MP.ReadByte())
    {
      case 0:
        DataManager.Instance.beCaptured.head = MP.ReadUShort();
        break;
      case 1:
        DataManager.Instance.beCaptured.AlliTag.ClearString();
        MP.ReadStringPlus(3, DataManager.Instance.beCaptured.AlliTag);
        break;
      case 2:
        DataManager.Instance.beCaptured.name.ClearString();
        MP.ReadStringPlus(13, DataManager.Instance.beCaptured.name);
        break;
      case 3:
        PointCode pointCode1 = new PointCode();
        pointCode1.zoneID = MP.ReadUShort();
        pointCode1.pointID = MP.ReadByte();
        DataManager.Instance.beCaptured.MapID = GameConstants.PointCodeToMapID(pointCode1.zoneID, pointCode1.pointID);
        break;
      case 4:
        DataManager.Instance.beCaptured.prisonerStat = (PrisonerState) MP.ReadByte();
        DataManager.Instance.beCaptured.StartActionTime = MP.ReadLong();
        DataManager.Instance.beCaptured.TotalTime = MP.ReadUInt();
        break;
      case 5:
        DataManager.Instance.beCaptured.Ransom = MP.ReadUInt();
        break;
      case 6:
        PointCode pointCode2 = new PointCode();
        pointCode2.zoneID = MP.ReadUShort();
        pointCode2.pointID = MP.ReadByte();
        DataManager.Instance.beCaptured.MapID = GameConstants.PointCodeToMapID(pointCode2.zoneID, pointCode2.pointID);
        DataManager.Instance.beCaptured.KingdomID = MP.ReadUShort();
        DataManager.Instance.beCaptured.HomeKingdomID = MP.ReadUShort();
        break;
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
  }

  public static void MSG_RESP_CHANGE_BOUNTY(MessagePacket MP)
  {
    switch (MP.ReadByte())
    {
      case 0:
        DataManager.Instance.beCaptured.Bounty = MP.ReadUInt();
        DataManager.Instance.Resource[4].Stock = MP.ReadUInt();
        GameManager.OnRefresh(NetworkNews.Refresh_Resource);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
        break;
      case 3:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7796U), (ushort) byte.MaxValue);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
        break;
    }
  }

  public static void MSG_RESP_PAY_RANSOM(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    DataManager.Instance.Resource[4].Stock = MP.ReadUInt();
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
  }

  public static void RecvLordReleasedTime(MessagePacket MP)
  {
    DataManager.Instance.beCaptured.StartActionTime = MP.ReadLong();
    DataManager.Instance.beCaptured.TotalTime = MP.ReadUInt();
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.LordReturn, true, DataManager.Instance.beCaptured.StartActionTime, DataManager.Instance.beCaptured.TotalTime);
    DataManager.Instance.SetRecvQueueBarData(30);
    DataManager.Instance.CheckTroolCount();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
  }

  public static void MSG_RESP_LORD_BEINGRELEASED(MessagePacket MP)
  {
    PointCode pointCode = new PointCode();
    pointCode.zoneID = MP.ReadUShort();
    pointCode.pointID = MP.ReadByte();
    DataManager.Instance.beCaptured.nowCaptureStat = LoadCaptureState.Returning;
    DataManager.Instance.beCaptured.MapID = GameConstants.PointCodeToMapID(pointCode.zoneID, pointCode.pointID);
    DataManager.Instance.beCaptured.StartActionTime = MP.ReadLong();
    DataManager.Instance.beCaptured.TotalTime = MP.ReadUInt();
    MP.ReadByte();
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.LordReturn, true, DataManager.Instance.beCaptured.StartActionTime, DataManager.Instance.beCaptured.TotalTime);
    DataManager.Instance.SetRecvQueueBarData(30);
    DataManager.Instance.CheckTroolCount();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0);
    ushort leaderId = DataManager.Instance.GetLeaderID();
    if (leaderId != (ushort) 0)
    {
      DataManager.Instance.TempFightHeroID[(int) leaderId] = (byte) 1;
      DataManager.Instance.SetFightHeroData();
      GameManager.OnRefresh(NetworkNews.Refresh_Hero);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroList_Soldier2, 0);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 2);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 18);
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Hero);
    DataManager.Instance.AttribVal.UpdateLordEquipData();
    GUIManager.Instance.CloseMenu(EGUIWindow.UI_SuicideBox);
  }

  public static void MSG_RESP_LORD_BEINGEXECUTED(MessagePacket MP)
  {
    DataManager.Instance.beCaptured.nowCaptureStat = LoadCaptureState.Dead;
    DataManager.Instance.beCaptured.StartActionTime = MP.ReadLong();
    DataManager.Instance.beCaptured.TotalTime = MP.ReadUInt();
    ushort leaderId = DataManager.Instance.GetLeaderID();
    if (leaderId != (ushort) 0)
    {
      DataManager.Instance.TempFightHeroID[(int) leaderId] = (byte) 1;
      DataManager.Instance.SetFightHeroData();
      GameManager.OnRefresh(NetworkNews.Refresh_Hero);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroList_Soldier2, 0);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 2);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 18);
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Hero);
    DataManager.Instance.AttribVal.UpdateLordEquipData();
    GUIManager.Instance.CloseMenu(EGUIWindow.UI_SuicideBox);
  }

  public static void MSG_RESP_LORD_HOME(MessagePacket MP)
  {
    DataManager.Instance.beCaptured.nowCaptureStat = LoadCaptureState.None;
    DataManager.Instance.beCaptured.StartActionTime = 0L;
    DataManager.Instance.beCaptured.TotalTime = 0U;
    ushort leaderId = DataManager.Instance.GetLeaderID();
    if (leaderId != (ushort) 0)
    {
      DataManager.Instance.TempFightHeroID[(int) leaderId] = (byte) 0;
      DataManager.Instance.SetFightHeroData();
      GameManager.OnRefresh(NetworkNews.Refresh_Hero);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroList_Soldier2, 0);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 2);
    }
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.LordReturn, false, 0L, 0U);
    DataManager.Instance.CheckTroolCount();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 18);
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Hero);
    DataManager.Instance.AttribVal.UpdateLordEquipData();
  }

  public static void MSG_RESP_LORD_REVIVE(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    DataManager.Instance.beCaptured.nowCaptureStat = LoadCaptureState.None;
    DataManager.Instance.beCaptured.StartActionTime = 0L;
    DataManager.Instance.beCaptured.TotalTime = 0U;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 18);
    ushort leaderId = DataManager.Instance.GetLeaderID();
    if (leaderId != (ushort) 0)
    {
      DataManager.Instance.TempFightHeroID[(int) leaderId] = (byte) 0;
      DataManager.Instance.SetFightHeroData();
      GameManager.OnRefresh(NetworkNews.Refresh_Hero);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroList_Soldier2, 0);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 2);
    }
    GUIManager.Instance.HideUILock(EUILock.LordInfo);
  }

  public static void MSG_RESP_PRISONER_NUM_AND_HIGHESTLEVEL(MessagePacket MP)
  {
    DataManager.Instance.PrisonerNum = MP.ReadByte();
    DataManager.Instance.PrisonerHighestLevel = MP.ReadByte();
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 11, (ushort) byte.MaxValue);
    DataManager.Instance.AttribVal.UpdateJailData();
    if (DataManager.Instance.PrisonerNum <= (byte) 0 || DataManager.Instance.Prisoner_Requested)
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PRISONER_LIST;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public static void MSG_RESP_PRISONER_LIST(MessagePacket MP)
  {
    JailManage.CleanJail();
    DataManager.Instance.Prisoner_Requested = true;
    byte num = MP.ReadByte();
    for (int index = 0; index < (int) num; ++index)
      JailManage.readPrisonerData(MP);
    JailManage.sortJail();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_JailRoom, 0);
  }

  public static void MSG_RESP_ADD_PRISONER(MessagePacket MP)
  {
    JailManage.readPrisonerData(MP);
    JailManage.sortJail();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_JailRoom, 0);
  }

  public static void MSG_RESP_UPDATE_PRISONER(MessagePacket MP)
  {
    byte index = MP.ReadByte();
    switch (MP.ReadByte())
    {
      case 0:
        if (DataManager.Instance.PrisonerList[(int) index].AlliTag == null)
          DataManager.Instance.PrisonerList[(int) index].AlliTag = StringManager.Instance.SpawnString();
        DataManager.Instance.PrisonerList[(int) index].AlliTag.ClearString();
        MP.ReadStringPlus(3, DataManager.Instance.PrisonerList[(int) index].AlliTag);
        break;
      case 1:
        if (DataManager.Instance.PrisonerList[(int) index].name == null)
          DataManager.Instance.PrisonerList[(int) index].name = StringManager.Instance.SpawnString();
        DataManager.Instance.PrisonerList[(int) index].name.ClearString();
        MP.ReadStringPlus(13, DataManager.Instance.PrisonerList[(int) index].name);
        break;
      case 2:
        DataManager.Instance.PrisonerList[(int) index].nowStat = (PrisonerState) MP.ReadByte();
        DataManager.Instance.PrisonerList[(int) index].StartActionTime = MP.ReadLong();
        DataManager.Instance.PrisonerList[(int) index].TotalTime = MP.ReadUInt();
        break;
      case 4:
        DataManager.Instance.PrisonerList[(int) index].KingdomID = MP.ReadUShort();
        break;
    }
    JailManage.sortJail();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_JailRoom, 0);
  }

  public static void MSG_RESP_PRISONER_ESCAPED(MessagePacket MP)
  {
    byte index = MP.ReadByte();
    DataManager.Instance.PrisonerList[(int) index].nowStat = PrisonerState.None;
    JailManage.sortJail();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0);
    if (!((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom) != (UnityEngine.Object) null) || (int) ((UIJailRoom) GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom)).DMIdx != (int) index)
      return;
    ((Door) GUIManager.Instance.FindMenu(EGUIWindow.Door)).CloseMenu();
  }

  public static void MSG_RESP_PRISONER_BAILED(MessagePacket MP)
  {
    byte index = MP.ReadByte();
    if (!GameConstants.IsBetween((int) index, 0, 30))
      return;
    DataManager.Instance.PrisonerList[(int) index].nowStat = PrisonerState.None;
    DataManager.Instance.Resource[4].Stock = MP.ReadUInt();
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
    JailManage.sortJail();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0);
    if (!((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom) != (UnityEngine.Object) null) || (int) ((UIJailRoom) GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom)).DMIdx != (int) index)
      return;
    ((Door) GUIManager.Instance.FindMenu(EGUIWindow.Door)).CloseMenu();
  }

  public static void MSG_RESP_RELEASE_ALL_PRISONER(MessagePacket MP)
  {
    DataManager.Instance.PrisonerNum = (byte) 0;
    DataManager.Instance.PrisonerHighestLevel = (byte) 0;
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
    DataManager.Instance.AttribVal.UpdateJailData();
    for (byte index = 0; index < (byte) 30; ++index)
      DataManager.Instance.PrisonerList[(int) index].nowStat = PrisonerState.None;
    JailManage.sortJail();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0);
    if (!((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom) != (UnityEngine.Object) null))
      return;
    ((Door) GUIManager.Instance.FindMenu(EGUIWindow.Door)).CloseMenu();
  }

  public static void MSG_RESP_CHANGE_RANSOM(MessagePacket MP)
  {
    if (MP.ReadByte() == (byte) 0)
      DataManager.Instance.PrisonerList[(int) MP.ReadByte()].Ransom = MP.ReadUInt();
    JailManage.sortJail();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_JailRoom, 0);
  }

  public static void MSG_RESP_RELEASE_PRISONER(MessagePacket MP)
  {
    if (MP.ReadByte() == (byte) 0)
      DataManager.Instance.PrisonerList[(int) MP.ReadByte()].nowStat = PrisonerState.None;
    JailManage.sortJail();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_JailRoom, 0);
  }

  public static void MSG_RESP_EXECUTE_PRISONER(MessagePacket MP)
  {
    if (MP.ReadByte() == (byte) 0)
    {
      byte index = MP.ReadByte();
      if (!GameConstants.IsBetween((int) index, 0, 30))
        return;
      DataManager.Instance.PrisonerList[(int) index].nowStat = PrisonerState.None;
      GUIManager.Instance.MsgStr.ClearString();
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.ClearString();
      ushort kingdomId = (int) DataManager.Instance.PrisonerList[(int) index].KingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID ? (ushort) 0 : DataManager.Instance.PrisonerList[(int) index].KingdomID;
      GUIManager.Instance.FormatRoleNameForChat(cstring, DataManager.Instance.PrisonerList[(int) index].name, DataManager.Instance.PrisonerList[(int) index].AlliTag, kingdomId, GUIManager.Instance.IsArabic);
      GUIManager.Instance.MsgStr.StringToFormat(cstring);
      GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12062U));
      GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), (ushort) 31);
      Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(DataManager.Instance.PrisonerList[(int) index].head);
      if (DataManager.Instance.CheckHeroSound(DataManager.Instance.PrisonerList[(int) index].head))
        AudioManager.Instance.PlaySFX(recordByKey.DyingSound, pitchkind: PitchKind.SpeechSound);
      if ((UnityEngine.Object) (GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom) as UIJailRoom) != (UnityEngine.Object) null)
      {
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
          menu.CloseMenu();
      }
      FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_EXECUTION);
    }
    JailManage.sortJail();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_JailRoom, 0);
  }

  public static void MSG_PRISON_RESP_PRISONER_POISONEFFECT(MessagePacket MP)
  {
    byte index = MP.ReadByte();
    DataManager.Instance.PrisonerList[(int) index].nowStat = PrisonerState.None;
    JailManage.sortJail();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Jail, 0);
    if (!((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom) != (UnityEngine.Object) null) || (int) ((UIJailRoom) GUIManager.Instance.FindMenu(EGUIWindow.UI_JailRoom)).DMIdx != (int) index)
      return;
    ((Door) GUIManager.Instance.FindMenu(EGUIWindow.Door)).CloseMenu();
  }

  public static void Send_MSG_REQUEST_MAP_PRISONER_LIST(int MapPointID)
  {
    MessagePacket messagePacket = (int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID ? MessagePacket.GetGuestMessagePack() : new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_MAP_PRISONER_LIST;
    messagePacket.AddSeqId();
    ushort zoneID;
    byte pointID;
    GameConstants.MapIDToPointCode(MapPointID, out zoneID, out pointID);
    messagePacket.Add(zoneID);
    messagePacket.Add(pointID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Jail);
  }

  public static void MSG_RESP_MAP_PRISONER_LIST(MessagePacket MP)
  {
    byte num1 = MP.ReadByte();
    byte num2 = MP.ReadByte();
    if (DataManager.Instance.MapPrisoners == null)
      DataManager.Instance.MapPrisoners = new List<MapPrisoner>();
    for (int index = 0; index < DataManager.Instance.MapPrisoners.Count; ++index)
    {
      StringManager.Instance.DeSpawnString(DataManager.Instance.MapPrisoners[index].TagName);
      DataManager.Instance.MapPrisoners[index].TagName = (CString) null;
    }
    DataManager.Instance.MapPrisoners.Clear();
    CString cstring1 = StringManager.Instance.SpawnString();
    CString cstring2 = StringManager.Instance.SpawnString();
    for (int index = 0; index < (int) num2; ++index)
    {
      cstring1.ClearString();
      cstring2.ClearString();
      uint Money = MP.ReadUInt();
      ushort kingdomID = MP.ReadUShort();
      MP.ReadStringPlus(3, cstring1);
      MP.ReadStringPlus(13, cstring2);
      DataManager.Instance.MapPrisoners.Add(new MapPrisoner(Money, kingdomID, cstring1, cstring2));
    }
    if (num1 != (byte) 0)
    {
      ((Door) GUIManager.Instance.FindMenu(EGUIWindow.Door)).OpenMenu(EGUIWindow.UI_DevelopmentDetails, 5);
      GUIManager.Instance.HideUILock(EUILock.Jail);
    }
    StringManager.Instance.DeSpawnString(cstring1);
    StringManager.Instance.DeSpawnString(cstring2);
  }

  public static void LoginCheckPrisoner()
  {
    if (DataManager.Instance.PrisonerNum <= (byte) 0)
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PRISONER_LIST;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public static void readPrisonerData(MessagePacket MP)
  {
    byte index = MP.ReadByte();
    if (!GameConstants.IsBetween((int) index, 0, 30))
      return;
    if (DataManager.Instance.PrisonerList[(int) index].AlliTag == null)
      DataManager.Instance.PrisonerList[(int) index].AlliTag = StringManager.Instance.SpawnString();
    if (DataManager.Instance.PrisonerList[(int) index].name == null)
      DataManager.Instance.PrisonerList[(int) index].name = StringManager.Instance.SpawnString();
    DataManager.Instance.PrisonerList[(int) index].AlliTag.ClearString();
    DataManager.Instance.PrisonerList[(int) index].name.ClearString();
    DataManager.Instance.PrisonerList[(int) index].KingdomID = MP.ReadUShort();
    MP.ReadStringPlus(3, DataManager.Instance.PrisonerList[(int) index].AlliTag);
    MP.ReadStringPlus(13, DataManager.Instance.PrisonerList[(int) index].name);
    DataManager.Instance.PrisonerList[(int) index].LordLevel = MP.ReadByte();
    DataManager.Instance.PrisonerList[(int) index].head = MP.ReadUShort();
    byte num1 = MP.ReadByte();
    DataManager.Instance.PrisonerList[(int) index].nowStat = (PrisonerState) num1;
    DataManager.Instance.PrisonerList[(int) index].StartActionTime = MP.ReadLong();
    DataManager.Instance.PrisonerList[(int) index].TotalTime = MP.ReadUInt();
    DataManager.Instance.PrisonerList[(int) index].Ransom = MP.ReadUInt();
    int num2 = (int) MP.ReadUInt();
  }

  public static void sortJail()
  {
    if (!DataManager.Instance.Prisoner_Requested)
      return;
    DataManager.Instance.PrisonerNum = (byte) 0;
    DataManager.Instance.PrisonerHighestLevel = (byte) 0;
    for (byte index = 0; (int) index < DataManager.Instance.PrisonerList.Length; ++index)
    {
      DataManager.Instance.sortedPrisonerList[(int) index] = index;
      if (DataManager.Instance.PrisonerList[(int) index].nowStat != PrisonerState.None)
      {
        ++DataManager.Instance.PrisonerNum;
        if ((int) DataManager.Instance.PrisonerList[(int) index].LordLevel > (int) DataManager.Instance.PrisonerHighestLevel)
          DataManager.Instance.PrisonerHighestLevel = DataManager.Instance.PrisonerList[(int) index].LordLevel;
      }
    }
    Array.Sort<byte>(DataManager.Instance.sortedPrisonerList, new Comparison<byte>(JailManage.PrisonerListComparer));
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
    DataManager.Instance.AttribVal.UpdateJailData();
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 11, (ushort) byte.MaxValue);
  }

  public static byte FindPrisonerSortIndex(byte dataIndex)
  {
    for (byte prisonerSortIndex = 0; (int) prisonerSortIndex < DataManager.Instance.PrisonerList.Length; ++prisonerSortIndex)
    {
      if ((int) DataManager.Instance.sortedPrisonerList[(int) prisonerSortIndex] == (int) dataIndex)
        return prisonerSortIndex;
    }
    return (byte) DataManager.Instance.PrisonerList.Length;
  }

  public static void CleanJail()
  {
    for (byte index = 0; (int) index < DataManager.Instance.PrisonerList.Length; ++index)
      DataManager.Instance.PrisonerList[(int) index].nowStat = PrisonerState.None;
  }

  public static int PrisonerListComparer(byte x, byte y)
  {
    byte[] numArray = new byte[4]
    {
      (byte) 0,
      (byte) 1,
      (byte) 2,
      (byte) 3
    };
    Prisoner prisoner1 = DataManager.Instance.PrisonerList[(int) x];
    Prisoner prisoner2 = DataManager.Instance.PrisonerList[(int) y];
    if (prisoner1.nowStat > prisoner2.nowStat)
      return -1;
    if (prisoner1.nowStat < prisoner2.nowStat)
      return 1;
    if (prisoner1.nowStat == PrisonerState.None || prisoner1.nowStat != prisoner2.nowStat)
      return 0;
    if (prisoner1.StartActionTime + (long) prisoner1.TotalTime < prisoner2.StartActionTime + (long) prisoner2.TotalTime)
      return -1;
    return prisoner1.StartActionTime + (long) prisoner1.TotalTime < prisoner2.StartActionTime + (long) prisoner2.TotalTime ? 1 : 0;
  }
}
