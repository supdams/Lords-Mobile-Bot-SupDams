// Decompiled with JetBrains decompiler
// Type: AmbushManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
public class AmbushManager
{
  private static AmbushManager instance;
  private DataManager DM;
  private GUIManager GM;
  private Door m_Door;
  public CString m_AmbushPlayerName;
  public PointCode m_AmbushPlayerCapitalPos;
  public ushort m_AmbushPlayerHead;
  public TroopLeaderType[] m_HeroInfo;
  public ushort m_TroopFlag;
  public uint[] m_TroopData;
  public PointCode ObjPoint;
  public CString m_Str;

  private AmbushManager()
  {
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.m_AmbushPlayerName = StringManager.Instance.SpawnString(13);
    this.m_HeroInfo = new TroopLeaderType[5];
    this.m_TroopData = new uint[16];
    this.m_Str = StringManager.Instance.SpawnString(300);
  }

  public static AmbushManager Instance
  {
    get
    {
      if (AmbushManager.instance == null)
        AmbushManager.instance = new AmbushManager();
      return AmbushManager.instance;
    }
  }

  ~AmbushManager()
  {
    if (this.m_AmbushPlayerName != null)
      StringManager.Instance.DeSpawnString(this.m_AmbushPlayerName);
    if (this.m_Str == null)
      return;
    StringManager.Instance.DeSpawnString(this.m_Str);
  }

  public void RecvAmbushInfo(MessagePacket MP)
  {
    this.ClearAmbushData();
    byte num = MP.ReadByte();
    MP.ReadStringPlus(13, this.m_AmbushPlayerName);
    this.m_AmbushPlayerCapitalPos.zoneID = MP.ReadUShort();
    this.m_AmbushPlayerCapitalPos.pointID = MP.ReadByte();
    this.m_AmbushPlayerHead = MP.ReadUShort();
    for (int index = 0; index < this.m_HeroInfo.Length; ++index)
    {
      this.m_HeroInfo[index].HeroID = MP.ReadUShort();
      this.m_HeroInfo[index].Rank = MP.ReadByte();
      this.m_HeroInfo[index].Star = MP.ReadByte();
    }
    this.m_TroopFlag = MP.ReadUShort();
    for (int index = 0; index < this.m_TroopData.Length; ++index)
    {
      if (((int) this.m_TroopFlag >> index & 1) == 1)
        this.m_TroopData[index] = MP.ReadUInt();
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Ambush, 0);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
    if (num != (byte) 0)
      return;
    this.m_Str.ClearString();
    this.m_Str.StringToFormat(this.m_AmbushPlayerName);
    this.m_Str.AppendFormat(this.DM.mStringTable.GetStringByID(9742U));
    this.GM.AddHUDMessage(this.m_Str.ToString(), (ushort) 29);
  }

  public void RecvAmbushUpdate(MessagePacket MP)
  {
    byte num = MP.ReadByte();
    switch (num)
    {
      case 0:
      case 1:
        if (num == (byte) 0)
        {
          this.m_Str.ClearString();
          this.m_Str.StringToFormat(this.m_AmbushPlayerName);
          this.m_Str.AppendFormat(this.DM.mStringTable.GetStringByID(9738U));
          this.GM.AddHUDMessage(this.m_Str.ToString(), (ushort) 29);
        }
        this.ClearAmbushData();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Ambush, 1);
        break;
      case 2:
        this.m_TroopFlag = MP.ReadUShort();
        Array.Clear((Array) this.m_TroopData, 0, this.m_TroopData.Length);
        for (int index = 0; index < this.m_TroopData.Length; ++index)
        {
          if (((int) this.m_TroopFlag >> index & 1) == 1)
            this.m_TroopData[index] = MP.ReadUInt();
        }
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Ambush, 0);
        break;
      case 3:
        this.m_AmbushPlayerCapitalPos.zoneID = MP.ReadUShort();
        this.m_AmbushPlayerCapitalPos.pointID = MP.ReadByte();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Ambush, 0);
        break;
      case 4:
        this.m_AmbushPlayerHead = MP.ReadUShort();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Ambush, 2);
        break;
      case 5:
        MP.ReadStringPlus(13, this.m_AmbushPlayerName);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Ambush, 3);
        break;
    }
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public void SendDismissAmbush()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Ambush))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_DISMISS_AMBUSH;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void RecvDismissAmbush(MessagePacket MP)
  {
    if (MP.ReadByte() == (byte) 0)
    {
      this.ClearAmbushData();
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Ambush, 1);
      GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(9732U), (ushort) 29);
    }
    GUIManager.Instance.HideUILock(EUILock.Ambush);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public void RecvAmbushDismisReturn(MessagePacket MP)
  {
    byte index = MP.ReadByte();
    if (index >= (byte) 8)
      return;
    this.DM.MarchEventTime[(int) index].BeginTime = MP.ReadLong();
    this.DM.MarchEventTime[(int) index].RequireTime = MP.ReadUInt();
    this.DM.SetQueueBarData((EQueueBarIndex) (2 + (int) index), true, this.DM.MarchEventTime[(int) index].BeginTime, this.DM.MarchEventTime[(int) index].RequireTime);
    GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(9730U), (ushort) 14);
  }

  public void SendAllyAmbushInfo(string name)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Ambush))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLY_AMBUSH_INFO;
    messagePacket.AddSeqId();
    messagePacket.Add(name, 13);
    messagePacket.Send();
  }

  public void RecvAllyAmbushInfo(MessagePacket MP)
  {
    if (MP.ReadByte() == (byte) 0)
    {
      this.ObjPoint.zoneID = MP.ReadUShort();
      this.ObjPoint.pointID = MP.ReadByte();
      if (MP.ReadByte() == (byte) 0)
      {
        if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyPointCode(this.ObjPoint.zoneID, this.ObjPoint.pointID)) == 0.0)
        {
          GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(4829U), this.DM.mStringTable.GetStringByID(119U));
        }
        else
        {
          this.m_Door = this.GetDoor();
          if ((UnityEngine.Object) this.m_Door != (UnityEngine.Object) null)
            this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, arg2: 5, bCameraMode: true);
        }
      }
      else
      {
        this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(4826U), this.DM.mStringTable.GetStringByID(9724U), this.DM.mStringTable.GetStringByID(4828U));
        this.m_Door = this.GetDoor();
        if ((UnityEngine.Object) this.m_Door != (UnityEngine.Object) null)
          this.m_Door.m_GroundInfo.Close();
      }
    }
    else
      this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(4826U), this.DM.mStringTable.GetStringByID(9725U), this.DM.mStringTable.GetStringByID(4828U));
    GUIManager.Instance.HideUILock(EUILock.Ambush);
  }

  public void SendAmbush(ushort[] Leader, uint[] TroopData)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Ambush))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_SEND_AMBUSH;
    messagePacket.AddSeqId();
    for (int index = 0; index < Leader.Length; ++index)
      messagePacket.Add(Leader[index]);
    for (int index = 0; index < TroopData.Length; ++index)
      messagePacket.Add(TroopData[index]);
    messagePacket.Add(this.ObjPoint.zoneID);
    messagePacket.Add(this.ObjPoint.pointID);
    messagePacket.Send();
  }

  public void RecvAmbush(MessagePacket MP)
  {
    switch (MP.ReadByte())
    {
      case 0:
        byte Index = MP.ReadByte();
        if (Index >= (byte) 8)
          return;
        this.DM.MarchEventData[(int) Index].Point.zoneID = MP.ReadUShort();
        this.DM.MarchEventData[(int) Index].Point.pointID = MP.ReadByte();
        this.DM.MarchEventTime[(int) Index].BeginTime = MP.ReadLong();
        this.DM.MarchEventTime[(int) Index].RequireTime = MP.ReadUInt();
        this.DM.MarchEventData[(int) Index].Type = EMarchEventType.EMET_CampMarching;
        this.DM.MarchEventData[(int) Index].bRallyHost = (byte) 1;
        this.DM.SetQueueBarData((EQueueBarIndex) (2 + (int) Index), true, this.DM.MarchEventTime[(int) Index].BeginTime, this.DM.MarchEventTime[(int) Index].RequireTime);
        this.DM.MarchEventData[(int) Index].PointKind = (POINT_KIND) MP.ReadByte();
        this.DM.MarchEventData[(int) Index].DesPointLevel = MP.ReadByte();
        this.DM.MarchEventData[(int) Index].DesPlayerName = MP.ReadString(13);
        for (int index = 0; index < 5; ++index)
        {
          this.DM.MarchEventData[(int) Index].HeroID[index] = MP.ReadUShort();
          if ((int) this.DM.MarchEventData[(int) Index].HeroID[index] < this.DM.TempFightHeroID.Length)
            this.DM.TempFightHeroID[(int) this.DM.MarchEventData[(int) Index].HeroID[index]] = (byte) 1;
        }
        ushort num = MP.ReadUShort();
        for (int index = 0; index < 16; ++index)
        {
          if (((int) num >> index & 1) == 1)
          {
            this.DM.MarchEventData[(int) Index].TroopData[index / 4][index % 4] = MP.ReadUInt();
            this.DM.RoleAttr.m_Soldier[index] -= this.DM.MarchEventData[(int) Index].TroopData[index / 4][index % 4];
            this.DM.SoldierTotal -= (long) this.DM.MarchEventData[(int) Index].TroopData[index / 4][index % 4];
          }
        }
        this.DM.CancelShieldItemBuff();
        this.DM.CheckTroolCount();
        GameManager.OnRefresh(NetworkNews.Refresh_Hero);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_DevelopmentDetails, 2);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0);
        this.m_Door = this.GetDoor();
        if ((UnityEngine.Object) this.m_Door != (UnityEngine.Object) null)
          this.m_Door.m_GroundInfo.UpdateUI(0, 0);
        this.DM.SetFightHeroData();
        if ((UnityEngine.Object) this.m_Door != (UnityEngine.Object) null)
        {
          if (this.m_Door.m_eMapMode == EUIOriginMapMode.OriginMap)
          {
            this.m_Door.CloseMenu();
          }
          else
          {
            DataManager.msgBuffer[0] = (byte) 81;
            GameConstants.GetBytes((ushort) Index, DataManager.msgBuffer, 1);
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          }
        }
        GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(9740U), (ushort) 29);
        DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Inner, byte.MaxValue);
        DataManager.Instance.AttribVal.UpdateSoldierConsume(SoldierConsumeType.Outer, Index);
        break;
      case 1:
        this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(5715U), this.DM.mStringTable.GetStringByID(5716U), this.DM.mStringTable.GetStringByID(5717U));
        break;
      case 2:
        this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(4826U), this.DM.mStringTable.GetStringByID(9725U), this.DM.mStringTable.GetStringByID(4828U));
        break;
      case 3:
        this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(4829U), this.DM.mStringTable.GetStringByID(119U));
        break;
      case 5:
        this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(4826U), this.DM.mStringTable.GetStringByID(9724U), this.DM.mStringTable.GetStringByID(4828U));
        this.m_Door = this.GetDoor();
        if ((UnityEngine.Object) this.m_Door != (UnityEngine.Object) null)
        {
          this.m_Door.m_GroundInfo.Close();
          break;
        }
        break;
    }
    GUIManager.Instance.HideUILock(EUILock.Ambush);
  }

  public void RecvAmbushArrived(MessagePacket MP)
  {
    byte index = MP.ReadByte();
    if (index >= (byte) 8)
      return;
    this.DM.MarchEventData[(int) index].Point.zoneID = MP.ReadUShort();
    this.DM.MarchEventData[(int) index].Point.pointID = MP.ReadByte();
    this.DM.MarchEventData[(int) index].Type = EMarchEventType.EMET_Camp;
    this.DM.SetQueueBarData((EQueueBarIndex) (2 + (int) index), false, this.DM.MarchEventTime[(int) index].BeginTime, this.DM.MarchEventTime[(int) index].RequireTime);
    this.DM.CheckTroolCount();
    GameManager.OnRefresh(NetworkNews.Refresh_Hero);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_DevelopmentDetails, 2);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0);
    this.m_Door = this.GetDoor();
    if ((UnityEngine.Object) this.m_Door != (UnityEngine.Object) null)
      this.m_Door.m_GroundInfo.UpdateUI(0, 0);
    this.DM.SetFightHeroData();
    GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(9741U), (ushort) 29);
  }

  public void SendAmbushReturn(byte TroopIndex)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Ambush))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_AMBUSH_RETURN;
    messagePacket.AddSeqId();
    messagePacket.Add(TroopIndex);
    messagePacket.Send();
  }

  public void RecvAmbushReturn(MessagePacket MP)
  {
    byte num = MP.ReadByte();
    byte index = MP.ReadByte();
    if (index >= (byte) 8)
      return;
    this.DM.MarchEventData[(int) index].Point.zoneID = MP.ReadUShort();
    this.DM.MarchEventData[(int) index].Point.pointID = MP.ReadByte();
    this.DM.MarchEventTime[(int) index].BeginTime = MP.ReadLong();
    this.DM.MarchEventTime[(int) index].RequireTime = MP.ReadUInt();
    this.DM.MarchEventData[(int) index].PointKind = POINT_KIND.PK_CITY;
    this.DM.MarchEventData[(int) index].bRallyHost = (byte) 1;
    this.DM.SetQueueBarData((EQueueBarIndex) (2 + (int) index), true, this.DM.MarchEventTime[(int) index].BeginTime, this.DM.MarchEventTime[(int) index].RequireTime);
    switch (num)
    {
      case 0:
        this.DM.MarchEventData[(int) index].Type = EMarchEventType.EMET_CampReturn;
        break;
      case 1:
        this.DM.MarchEventData[(int) index].Type = EMarchEventType.EMET_CampReturn;
        GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(9730U), (ushort) 14);
        break;
      case 2:
        this.DM.MarchEventData[(int) index].Type = EMarchEventType.EMET_CampRetreat;
        break;
    }
    GUIManager.Instance.HideUILock(EUILock.Ambush);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_ArmyInfo, 0);
  }

  public uint GetMaxTroop()
  {
    uint maxTroop = 0;
    for (int index = 0; index < this.m_TroopData.Length; ++index)
      maxTroop += this.m_TroopData[index];
    return maxTroop;
  }

  public void ClearAmbushData()
  {
    this.m_AmbushPlayerName.ClearString();
    this.m_AmbushPlayerHead = (ushort) 0;
    Array.Clear((Array) this.m_HeroInfo, 0, this.m_HeroInfo.Length);
    this.m_TroopFlag = (ushort) 0;
    Array.Clear((Array) this.m_TroopData, 0, this.m_TroopData.Length);
  }

  private Door GetDoor()
  {
    if ((UnityEngine.Object) this.m_Door == (UnityEngine.Object) null)
      this.m_Door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    return this.m_Door;
  }
}
