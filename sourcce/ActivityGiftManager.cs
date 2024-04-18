// Decompiled with JetBrains decompiler
// Type: ActivityGiftManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ActivityGiftManager
{
  private static ActivityGiftManager instance;
  private byte m_EnableRedPocketNum;
  public List<AllianceActivityGiftDataType> mListActGift = new List<AllianceActivityGiftDataType>();
  public ushort mShowActGiftUnOpenIdx;
  public long mLeaderRedPocketResetTime;
  public long ActivityGiftBeginTime;
  public long ActivityGiftEndTime;
  public byte GroupID;
  public byte mActivityGiftPage;
  public bool bShowActivityGift;
  public long mMainGift_CDTime;
  public bool bReSetMainGift = true;
  public uint ParticleID;
  public GameObject mActGiftEffectParticle;
  private float mEffectTime;
  private AudioSourceController mActGiftcontroller;

  private ActivityGiftManager()
  {
  }

  public static ActivityGiftManager Instance
  {
    get
    {
      if (ActivityGiftManager.instance == null)
        ActivityGiftManager.instance = new ActivityGiftManager();
      return ActivityGiftManager.instance;
    }
  }

  public byte EnableRedPocketNum
  {
    get => this.m_EnableRedPocketNum;
    set
    {
      if (!this.bShowActivityGift && this.m_EnableRedPocketNum >= (byte) 0 && (int) value > (int) this.m_EnableRedPocketNum && (UnityEngine.Object) this.mActGiftEffectParticle == (UnityEngine.Object) null)
      {
        this.bShowActivityGift = true;
        this.CheckShowActivityGiftEffect();
      }
      else if (this.bShowActivityGift && value == (byte) 0)
        this.bShowActivityGift = false;
      this.m_EnableRedPocketNum = value;
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 17);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 6);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Info, 9);
    }
  }

  ~ActivityGiftManager()
  {
  }

  public void Update()
  {
    if (this.bReSetMainGift && this.mMainGift_CDTime != ActivityManager.Instance.ServerEventTime)
    {
      this.mMainGift_CDTime = ActivityManager.Instance.ServerEventTime;
      if (ActivityGiftManager.Instance.mLeaderRedPocketResetTime <= ActivityManager.Instance.ServerEventTime)
      {
        this.bReSetMainGift = false;
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 4);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Info, 11);
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 17);
      }
    }
    if (!((UnityEngine.Object) this.mActGiftEffectParticle != (UnityEngine.Object) null))
      return;
    this.mEffectTime -= Time.smoothDeltaTime;
    if ((double) this.mEffectTime > 0.0)
      return;
    this.DespawnActivityGiftEffect();
  }

  public static int GiftCompare(AllianceActivityGiftDataType x, AllianceActivityGiftDataType y)
  {
    bool flag;
    if (x.Status == (byte) 0)
    {
      if (y.Status != (byte) 0)
        return -1;
      flag = true;
    }
    else
    {
      if (y.Status == (byte) 0)
        return 1;
      flag = true;
    }
    return flag && x.RcvTime >= y.RcvTime && (x.RcvTime > y.RcvTime || (int) x.serverIndex <= (int) y.serverIndex) ? 1 : -1;
  }

  public void sortData()
  {
    this.mListActGift.Sort(new Comparison<AllianceActivityGiftDataType>(ActivityGiftManager.GiftCompare));
    int num = 0;
    for (int index = 0; index < this.mListActGift.Count; ++index)
    {
      if (this.mListActGift[index].Status == (byte) 0)
        ++num;
    }
  }

  public void cleanListData()
  {
    for (int index = 0; index < this.mListActGift.Count; ++index)
    {
      if (this.mListActGift[index].Name != null)
        StringManager.Instance.DeSpawnString(this.mListActGift[index].Name);
    }
    this.mListActGift.Clear();
    this.EnableRedPocketNum = (byte) 0;
  }

  public void cleanQuitAlliance()
  {
    this.cleanListData();
    this.mLeaderRedPocketResetTime = 0L;
    this.ActivityGiftBeginTime = 0L;
    this.ActivityGiftEndTime = 0L;
    this.bReSetMainGift = false;
  }

  public void Recv_MSG_RESP_REDPOCKET_LIST(MessagePacket MP)
  {
    byte num1 = MP.ReadByte();
    int num2 = (int) MP.ReadByte();
    if (num1 == byte.MaxValue)
    {
      this.cleanListData();
      for (int index = 0; index < num2; ++index)
      {
        AllianceActivityGiftDataType activityGiftDataType = new AllianceActivityGiftDataType();
        activityGiftDataType.serverIndex = MP.ReadByte();
        byte num3 = MP.ReadByte();
        uint num4 = MP.ReadUInt();
        bool flag = false;
        for (int Index = 0; Index < DataManager.Instance.FastivalSpecialDataTable.TableCount; ++Index)
        {
          flag = false;
          FastivalSpecialData recordByIndex = DataManager.Instance.FastivalSpecialDataTable.GetRecordByIndex(Index);
          if ((int) num3 == (int) recordByIndex.GroupID && (int) num4 == (int) recordByIndex.StoreID)
          {
            flag = true;
            activityGiftDataType.SN = recordByIndex.ID;
            activityGiftDataType.isLeader = recordByIndex.StoreID == 0U;
            activityGiftDataType.CDtime = false;
            break;
          }
        }
        activityGiftDataType.Name = StringManager.Instance.SpawnString();
        MP.ReadStringPlus(13, activityGiftDataType.Name);
        activityGiftDataType.Rank = MP.ReadByte();
        activityGiftDataType.RcvTime = MP.ReadLong();
        activityGiftDataType.Num = MP.ReadByte();
        activityGiftDataType.Status = MP.ReadByte();
        if (flag)
          this.mListActGift.Add(activityGiftDataType);
      }
      this.sortData();
    }
    else if (GameConstants.IsBetween((int) num1, 0, 9))
    {
      AllianceActivityGiftDataType activityGiftDataType = (AllianceActivityGiftDataType) null;
      bool flag1 = false;
      for (int index = 0; index < this.mListActGift.Count; ++index)
      {
        if ((int) this.mListActGift[index].serverIndex == (int) num1)
        {
          activityGiftDataType = this.mListActGift[index];
          flag1 = true;
          break;
        }
      }
      if (!flag1)
      {
        activityGiftDataType = new AllianceActivityGiftDataType();
        activityGiftDataType.Name = StringManager.Instance.SpawnString();
      }
      else
        activityGiftDataType.Name.ClearString();
      activityGiftDataType.serverIndex = MP.ReadByte();
      byte num5 = MP.ReadByte();
      uint num6 = MP.ReadUInt();
      bool flag2 = false;
      for (int Index = 0; Index < DataManager.Instance.FastivalSpecialDataTable.TableCount; ++Index)
      {
        flag2 = false;
        FastivalSpecialData recordByIndex = DataManager.Instance.FastivalSpecialDataTable.GetRecordByIndex(Index);
        if ((int) num5 == (int) recordByIndex.GroupID && (int) num6 == (int) recordByIndex.StoreID)
        {
          flag2 = true;
          activityGiftDataType.SN = recordByIndex.ID;
          activityGiftDataType.isLeader = recordByIndex.StoreID == 0U;
          activityGiftDataType.CDtime = false;
          break;
        }
      }
      if (!flag2)
        return;
      MP.ReadStringPlus(13, activityGiftDataType.Name);
      activityGiftDataType.Rank = MP.ReadByte();
      activityGiftDataType.RcvTime = MP.ReadLong();
      activityGiftDataType.Num = MP.ReadByte();
      activityGiftDataType.Status = MP.ReadByte();
      if (!flag1)
        this.mListActGift.Add(activityGiftDataType);
    }
    this.RecountGift();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 1);
  }

  public void Recv_MSG_RESP_REDPOCKET_LEADEREND(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.ActGift);
    switch (MP.ReadByte())
    {
      case 0:
        DataManager instance = DataManager.Instance;
        int tableCount = instance.FastivalSpecialDataTable.TableCount;
        for (int Index = 0; Index < tableCount; ++Index)
        {
          FastivalSpecialData recordByIndex = instance.FastivalSpecialDataTable.GetRecordByIndex(Index);
          if (recordByIndex.StoreID == 0U && (int) recordByIndex.GroupID == (int) this.GroupID)
          {
            CString cstring = StringManager.Instance.StaticString1024();
            cstring.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByIndex.ItemName));
            cstring.AppendFormat(instance.mStringTable.GetStringByID(11205U));
            GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
            break;
          }
        }
        break;
      case 5:
        CString cstring1 = StringManager.Instance.StaticString1024();
        cstring1.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11215U));
        GUIManager.Instance.AddHUDMessage(cstring1.ToString(), (ushort) byte.MaxValue);
        break;
    }
  }

  public void Recv_MSG_RESP_REDPOCKET_GET(MessagePacket MP)
  {
    byte num1 = MP.ReadByte();
    MP.ReadUInt();
    switch (MP.ReadByte())
    {
      case 0:
        DataManager instance1 = DataManager.Instance;
        GUIManager instance2 = GUIManager.Instance;
        uint num2 = MP.ReadUInt();
        uint num3 = MP.ReadUInt();
        ushort num4 = MP.ReadUShort();
        ushort num5 = MP.ReadUShort();
        byte Rare = MP.ReadByte();
        ushort x = num5;
        if (num2 > 0U)
        {
          GUIManager.Instance.SetRoleAttrDiamond(num2 + instance1.RoleAttr.Diamond, (ushort) 0);
          GameManager.OnRefresh();
        }
        else if (num3 > 0U)
        {
          instance1.RoleAlliance.Money += num3;
          GameManager.OnRefresh(NetworkNews.Refresh_Alliance);
        }
        else
        {
          ushort Quantity = (ushort) ((uint) num5 + (uint) instance1.GetCurItemQuantity(num4, Rare));
          instance1.SetCurItemQuantity(num4, Quantity, Rare, 0L);
          GameManager.OnRefresh(NetworkNews.Refresh_Item);
        }
        for (int index = 0; index < this.mListActGift.Count; ++index)
        {
          if ((int) this.mListActGift[index].serverIndex == (int) num1)
          {
            this.mListActGift[index].Status = (byte) 1;
            break;
          }
        }
        this.RecountGift();
        Equip recordByKey = instance1.EquipTable.GetRecordByKey(num4);
        bool flag1 = instance2.IsLeadItem(recordByKey.EquipKind);
        GUIManager.Instance.m_SpeciallyEffect.mDiamondValue = 0U;
        if (recordByKey.EquipKind != (byte) 11)
        {
          if (flag1)
          {
            instance2.SE_Item_L_Color[0] = Rare;
            instance2.m_SpeciallyEffect.AddIconShow(false, instance2.mStartV2, SpeciallyEffect_Kind.Item_Material, ItemID: recordByKey.EquipKey, EndTime: 2f);
          }
          else
            instance2.m_SpeciallyEffect.AddIconShow(false, instance2.mStartV2, SpeciallyEffect_Kind.Item, ItemID: recordByKey.EquipKey, EndTime: 2f);
        }
        else if (recordByKey.PropertiesInfo[0].Propertieskey < (ushort) 6)
          instance2.m_SpeciallyEffect.AddIconShow(false, instance2.mStartV2, SpeciallyEffect_Kind.Item, ItemID: recordByKey.EquipKey, EndTime: 2f);
        else if (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 6)
        {
          instance2.m_SpeciallyEffect.mDiamondValue = (uint) recordByKey.PropertiesInfo[1].Propertieskey * (uint) recordByKey.PropertiesInfo[1].PropertiesValue;
          instance2.m_SpeciallyEffect.AddIconShow(false, instance2.mStartV2, SpeciallyEffect_Kind.Diamond, ItemID: (ushort) 0, EndTime: 2f);
        }
        else
          instance2.m_SpeciallyEffect.AddIconShow(false, instance2.mStartV2, SpeciallyEffect_Kind.AllianceMoney, ItemID: (ushort) 0, EndTime: 2f);
        CString cstring1 = StringManager.Instance.StaticString1024();
        cstring1.ClearString();
        cstring1.Append(DataManager.Instance.mStringTable.GetStringByID(840U));
        if (x > (ushort) 1)
        {
          cstring1.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.EquipName));
          cstring1.IntToFormat((long) x, bNumber: true);
          cstring1.AppendFormat("{0} x {1}");
        }
        else
          cstring1.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.EquipName));
        instance2.AddHUDMessage(cstring1.ToString(), (ushort) byte.MaxValue);
        AudioManager.Instance.PlayUISFX(UIKind.ItemUse);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 1);
        break;
      case 1:
        DataManager instance3 = DataManager.Instance;
        FastivalSpecialData fastivalSpecialData = new FastivalSpecialData();
        bool flag2 = false;
        for (int Index = 0; Index < instance3.FastivalSpecialDataTable.TableCount; ++Index)
        {
          fastivalSpecialData = instance3.FastivalSpecialDataTable.GetRecordByIndex(Index);
          if ((int) fastivalSpecialData.GroupID == (int) this.GroupID && fastivalSpecialData.StoreID == 0U)
          {
            flag2 = true;
            break;
          }
        }
        if (!flag2)
          break;
        CString cstring2 = StringManager.Instance.StaticString1024();
        cstring2.StringToFormat(instance3.mStringTable.GetStringByID((uint) fastivalSpecialData.ItemName));
        cstring2.AppendFormat(instance3.mStringTable.GetStringByID(11206U));
        GUIManager.Instance.AddHUDMessage(cstring2.ToString(), (ushort) byte.MaxValue);
        break;
      case 4:
        CString cstring3 = StringManager.Instance.StaticString1024();
        cstring3.Append(DataManager.Instance.mStringTable.GetStringByID(11227U));
        GUIManager.Instance.AddHUDMessage(cstring3.ToString(), (ushort) byte.MaxValue);
        break;
      case 6:
        CString cstring4 = StringManager.Instance.StaticString1024();
        cstring4.Append(DataManager.Instance.mStringTable.GetStringByID(11226U));
        GUIManager.Instance.AddHUDMessage(cstring4.ToString(), (ushort) byte.MaxValue);
        break;
    }
  }

  public void Recv_MSG_RESP_REDPOCKET_BUY(MessagePacket MP)
  {
    switch (MP.ReadByte())
    {
      case 0:
        CString cstring1 = StringManager.Instance.StaticString1024();
        cstring1.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11207U));
        GUIManager.Instance.AddHUDMessage(cstring1.ToString(), (ushort) byte.MaxValue);
        break;
      case 1:
        CString cstring2 = StringManager.Instance.StaticString1024();
        cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11208U));
        GUIManager.Instance.AddHUDMessage(cstring2.ToString(), (ushort) byte.MaxValue);
        break;
    }
    AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
    AudioManager.Instance.PlayUISFX(UIKind.ItemUse);
    GUIManager.Instance.HideUILock(EUILock.Mall);
  }

  public void RecvUpdate_EventInfo(MessagePacket MP)
  {
    this.ActivityGiftBeginTime = MP.ReadLong();
    this.ActivityGiftEndTime = MP.ReadLong();
    this.GroupID = MP.ReadByte();
    for (int index = 0; index < DataManager.Instance.FastivalSpecialDataTable.TableCount; ++index)
    {
      FastivalSpecialData recordByKey = DataManager.Instance.FastivalSpecialDataTable.GetRecordByKey((ushort) (index + 1));
      if ((int) this.GroupID == (int) recordByKey.GroupID)
      {
        this.ParticleID = recordByKey.UB1;
        break;
      }
    }
    this.mLeaderRedPocketResetTime = MP.ReadLong();
    ActivityGiftManager.Instance.bReSetMainGift = ActivityGiftManager.Instance.mLeaderRedPocketResetTime > ActivityManager.Instance.ServerEventTime;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 17);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Info, 11);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 4);
  }

  public void SendRequestBoardData()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_REDPOCKET_LIST;
    messagePacket.Add(byte.MaxValue);
    messagePacket.Add((byte) 0);
    messagePacket.Send();
  }

  public void SendDataRequest(byte serverIndex)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_REDPOCKET_LIST;
    messagePacket.Add(serverIndex);
    messagePacket.Add((byte) 0);
    messagePacket.Send();
  }

  public void SendDataReset(byte serverIndex)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_REDPOCKET_LIST;
    messagePacket.Add(serverIndex);
    messagePacket.Add((byte) 1);
    messagePacket.Send();
  }

  public void AllianceLeaderSendGift()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_REDPOCKET_LEADERSEND;
    messagePacket.Send();
  }

  public void GetGift(byte serverIndex, uint StoreID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_REDPOCKET_GET;
    messagePacket.Add(serverIndex);
    messagePacket.Add(StoreID);
    messagePacket.Send();
  }

  public void updateGiftCount(byte serverIndex, byte giftCount)
  {
    for (int index = 0; index < this.mListActGift.Count; ++index)
    {
      if ((int) this.mListActGift[index].serverIndex == (int) serverIndex)
      {
        this.mListActGift[index].Num = giftCount;
        if (giftCount == (byte) 0)
        {
          if (this.mListActGift[index].Name != null)
            StringManager.Instance.DeSpawnString(this.mListActGift[index].Name);
          this.mListActGift.Remove(this.mListActGift[index]);
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 1);
        }
        else
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 2, (int) serverIndex);
        this.RecountGift();
        return;
      }
    }
    if (giftCount != (byte) 0)
      return;
    this.RecountGift();
  }

  public bool GetIconState()
  {
    bool iconState = true;
    if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
      iconState = false;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null) || menu.m_eMode != EUIOriginMode.Show || menu.m_eMapMode != EUIOriginMapMode.OriginMap)
      iconState = false;
    if ((UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null)
      iconState = false;
    if (!MallManager.Instance.bCanOpenMain)
      iconState = false;
    if (!(GameManager.ActiveGameplay is Origin))
      iconState = false;
    if (Indemnify.UIStatus == INDEMNIFY_STATE.ShowingTalk)
      iconState = false;
    return iconState;
  }

  public void CheckShowActivityGiftEffect()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!this.bShowActivityGift || NewbieManager.IsWorking() || !this.GetIconState() || !((UnityEngine.Object) menu != (UnityEngine.Object) null) || !((UnityEngine.Object) this.mActGiftEffectParticle == (UnityEngine.Object) null))
      return;
    if (this.mActGiftcontroller != null)
      this.mActGiftcontroller.Stop();
    if (this.ParticleID != 0U)
      this.mActGiftEffectParticle = ParticleManager.Instance.Spawn((ushort) this.ParticleID, (Transform) menu.m_RolePanel, Vector3.zero, 1f, true);
    this.mEffectTime = 7f;
    this.bShowActivityGift = false;
    AudioManager.Instance.PlayUISFX(ref this.mActGiftcontroller, UIKind.ActGift);
  }

  public void DespawnActivityGiftEffect(bool bstop = true)
  {
    if (!((UnityEngine.Object) this.mActGiftEffectParticle != (UnityEngine.Object) null))
      return;
    if (this.mActGiftcontroller != null && bstop)
      this.mActGiftcontroller.Stop();
    ParticleManager.Instance.DeSpawn(this.mActGiftEffectParticle);
    this.mActGiftEffectParticle = (GameObject) null;
    this.mEffectTime = 0.0f;
  }

  public void RecountGift()
  {
    int num = 0;
    for (int index = 0; index < this.mListActGift.Count; ++index)
    {
      if (this.mListActGift[index].Status == (byte) 0 && this.mListActGift[index].Num > (byte) 0)
        ++num;
    }
    if (num == (int) this.m_EnableRedPocketNum)
      return;
    this.EnableRedPocketNum = (byte) num;
  }
}
