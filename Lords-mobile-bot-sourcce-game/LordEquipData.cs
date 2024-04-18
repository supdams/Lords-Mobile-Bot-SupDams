// Decompiled with JetBrains decompiler
// Type: LordEquipData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class LordEquipData
{
  private const float limitRequestTime = 10f;
  public const ushort MaterialStackMax = 65535;
  public const byte MaxLordEquip = 200;
  public const ushort LordEquipEffectTypeTalkID = 8484;
  private static LordEquipData _instance = (LordEquipData) null;
  public readonly double[] forgeGold = new double[6]
  {
    0.0,
    1.0,
    2.0,
    4.0,
    7.0,
    11.0
  };
  public readonly double[] forgeTime = new double[6]
  {
    0.0,
    1.0,
    2.0,
    4.0,
    7.0,
    11.0
  };
  public ItemLordEquip[] LordEquip = new ItemLordEquip[200];
  public LordEquipMaterial[] LEGem = new LordEquipMaterial[1000];
  public LordEquipMaterial[] LEMaterial = new LordEquipMaterial[1000];
  public static uint[] RoleEquipSerial = new uint[8];
  public static LordEquipSerialData[] RoleEquip = new LordEquipSerialData[8];
  public LordEquipSet[] LordEquipSets = new LordEquipSet[10];
  public int LordEquipSetsCount;
  private bool MatCountingCache;
  private bool EvoCountingReq = true;
  public Dictionary<ushort, int> MatValue;
  public bool isEquipEvoReady;
  private long LastUpdateTime_Equip = -1;
  private long LastUpdateTime_Gem = -1;
  private long LastUpdateTime_Material = -1;
  public static bool EqDataReq = false;
  public static bool GemDataReq = false;
  public static bool MaterialDataReq = false;
  public bool ForgeItem_bLvFilter = true;
  public byte ForgeItem_mEquip;
  public byte ForgeItem_mColor;
  public ushort ForgeItem_mSeletedFilter;
  public int ForgeItem_ScrollIdx;
  public byte ForgeActivity_mColor;
  public byte ForgeActivity_mKind;
  public int ForgeActivity_ScrollIdx;
  public int ForgeActivity_KindScrollIdx;
  public float ForgeActivity_KindScroll_Y;
  public bool QuickSetSerialCheck;
  private Dictionary<uint, int> EquipDic;
  public List<long> EquipExpireTime = new List<long>();

  protected LordEquipData()
  {
    for (int index = 0; index < 200; ++index)
      this.LordEquip[index].Init();
    this.EquipDic = new Dictionary<uint, int>();
  }

  public bool isRoleEquipThis(uint Serial)
  {
    if (Serial == 0U)
      return false;
    for (int index = 0; index < LordEquipData.RoleEquipSerial.Length; ++index)
    {
      if ((int) LordEquipData.RoleEquipSerial[index] == (int) Serial)
        return true;
    }
    return false;
  }

  public static LordEquipData Instance()
  {
    if (LordEquipData._instance == null)
      LordEquipData._instance = new LordEquipData();
    return LordEquipData._instance;
  }

  public bool LoadLordEquip(bool noLock = false)
  {
    if (LordEquipData.EqDataReq)
      return false;
    if (noLock || GUIManager.Instance.ShowUILock(EUILock.LordEquip))
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_LOADEQUIP;
      messagePacket.AddSeqId();
      messagePacket.Add(this.LastUpdateTime_Equip);
      messagePacket.Send();
    }
    return true;
  }

  public bool LoadLEGem(bool noLock = false)
  {
    if (LordEquipData.GemDataReq)
      return false;
    if (noLock || GUIManager.Instance.ShowUILock(EUILock.LordEquip))
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ITEMGEM;
      messagePacket.AddSeqId();
      messagePacket.Add(this.LastUpdateTime_Gem);
      messagePacket.Send();
    }
    return true;
  }

  public bool LoadLEMaterial(bool noLock = false)
  {
    if (LordEquipData.MaterialDataReq)
      return false;
    if (noLock || GUIManager.Instance.ShowUILock(EUILock.LordEquip))
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ITEMMAT;
      messagePacket.AddSeqId();
      messagePacket.Add(this.LastUpdateTime_Material);
      messagePacket.Send();
    }
    return true;
  }

  public void Recv_MSG_RESP_LORDEQUIP(MessagePacket MP)
  {
    if (DataManager.Instance.mLordEquip == null)
      DataManager.Instance.mLordEquip = LordEquipData.Instance();
    switch (MP.ReadByte())
    {
      case 0:
        LordEquipData.EqDataReq = true;
        LordEquipData.SetItemTime(MP.ReadLong());
        ushort num1 = MP.ReadUShort();
        ushort num2 = MP.ReadUShort();
        if (num1 == (ushort) 0)
        {
          for (int index = 0; index < 200; ++index)
            this.LordEquip[index].Clear();
        }
        for (int index1 = 0; index1 < (int) num2; ++index1)
        {
          this.LordEquip[(int) num1 + index1].ItemID = MP.ReadUShort();
          this.LordEquip[(int) num1 + index1].Color = MP.ReadByte();
          for (int index2 = 0; index2 < 4; ++index2)
            this.LordEquip[(int) num1 + index1].GemColor[index2] = MP.ReadByte();
          for (int index3 = 0; index3 < 4; ++index3)
            this.LordEquip[(int) num1 + index1].Gem[index3] = MP.ReadUShort();
          this.LordEquip[(int) num1 + index1].SerialNO = MP.ReadUInt();
        }
        break;
      case 1:
        LordEquipData.EqDataReq = true;
        this.EvoCountingReq = true;
        this.QuickSetSerialCheck = false;
        this.ScanEquipUpdate();
        GUIManager.Instance.HideUILock(EUILock.LordEquip);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
        GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1);
        break;
      case 2:
        this.EvoCountingReq = true;
        this.QuickSetSerialCheck = false;
        this.ScanEquipUpdate();
        GUIManager.Instance.HideUILock(EUILock.LordEquip);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Forge_Item, 1);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Forge_ActivityItem, 1);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquipSetEdit, 1);
        GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1);
        break;
    }
  }

  public void Recv_MSG_RESP_Gem(MessagePacket MP)
  {
    if (DataManager.Instance.mLordEquip == null)
      DataManager.Instance.mLordEquip = LordEquipData.Instance();
    switch (MP.ReadByte())
    {
      case 0:
        LordEquipData.GemDataReq = true;
        LordEquipData.SetGemTime(MP.ReadLong());
        ushort num1 = MP.ReadUShort();
        ushort num2 = MP.ReadUShort();
        if ((int) num2 + (int) num1 > this.LEGem.Length)
          break;
        if (num1 == (ushort) 0)
        {
          for (int index = 0; index < this.LEGem.Length; ++index)
            this.LEGem[index].Clear();
        }
        for (int index = 0; index < (int) num2; ++index)
        {
          this.LEGem[(int) num1 + index].ItemID = MP.ReadUShort();
          this.LEGem[(int) num1 + index].Color = MP.ReadByte();
          this.LEGem[(int) num1 + index].Quantity = MP.ReadUShort();
        }
        break;
      case 1:
        LordEquipData.GemDataReq = true;
        GUIManager.Instance.HideUILock(EUILock.LordEquip);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 2);
        GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1);
        break;
      case 2:
        GUIManager.Instance.HideUILock(EUILock.LordEquip);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 2);
        GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1);
        break;
    }
  }

  public void Recv_MSG_RESP_ITEMMAT(MessagePacket MP)
  {
    if (DataManager.Instance.mLordEquip == null)
      DataManager.Instance.mLordEquip = LordEquipData.Instance();
    switch (MP.ReadByte())
    {
      case 0:
        LordEquipData.MaterialDataReq = true;
        LordEquipData.SetMatTime(MP.ReadLong());
        ushort num1 = MP.ReadUShort();
        ushort num2 = MP.ReadUShort();
        if ((int) num2 + (int) num1 > this.LEMaterial.Length)
          break;
        if (num1 == (ushort) 0)
        {
          for (int index = 0; index < this.LEMaterial.Length; ++index)
            this.LEMaterial[index].Clear();
          if (!this.MatCountingCache)
            this.StartMaterialCache();
          this.MatValue.Clear();
        }
        for (int index = 0; index < (int) num2; ++index)
        {
          this.LEMaterial[(int) num1 + index].ItemID = MP.ReadUShort();
          this.LEMaterial[(int) num1 + index].Color = MP.ReadByte();
          this.LEMaterial[(int) num1 + index].Quantity = MP.ReadUShort();
          double num3 = (double) this.LEMaterial[(int) num1 + index].Quantity * Math.Pow(4.0, (double) ((int) this.LEMaterial[(int) num1 + index].Color - 1));
          int num4;
          if (this.MatValue.TryGetValue(this.LEMaterial[(int) num1 + index].ItemID, out num4))
          {
            num4 += (int) num3;
            this.MatValue.Remove(this.LEMaterial[(int) num1 + index].ItemID);
            this.MatValue.Add(this.LEMaterial[(int) num1 + index].ItemID, num4);
          }
          else
            this.MatValue.Add(this.LEMaterial[(int) num1 + index].ItemID, (int) num3);
        }
        break;
      case 1:
        LordEquipData.MaterialDataReq = true;
        this.EvoCountingReq = true;
        this.ScanEquipUpdate();
        GUIManager.Instance.HideUILock(EUILock.LordEquip);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 3);
        GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetFusion, 3);
        break;
      case 2:
        this.EvoCountingReq = true;
        this.ScanEquipUpdate();
        GUIManager.Instance.HideUILock(EUILock.LordEquip);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 3);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Forge_Item, 2);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Forge_ActivityItem, 2);
        GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetFusion, 3);
        break;
    }
  }

  public void Recv_MSG_RESP_LORDEQUIP_EX(MessagePacket MP)
  {
    LordEquipData.SetItemTime(MP.ReadLong());
    ushort num = MP.ReadUShort();
    for (int index = 0; index < (int) num; ++index)
      LordEquipData.updateEquipTime(MP.ReadUInt(), MP.ReadLong());
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquipSetEdit, 3);
  }

  public static void AddItem(MessagePacket MP)
  {
    if (!LordEquipData.EqDataReq)
      return;
    ushort num = MP.ReadUShort();
    if (num == (ushort) 0)
      return;
    ItemLordEquip itemLordEquip = new ItemLordEquip();
    itemLordEquip.Init();
    itemLordEquip.ItemID = num;
    itemLordEquip.Color = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      itemLordEquip.GemColor[index] = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      itemLordEquip.Gem[index] = MP.ReadUShort();
    itemLordEquip.SerialNO = MP.ReadUInt();
    for (int index = 0; index < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index)
    {
      if (LordEquipData._instance.LordEquip[index].ItemID == (ushort) 0)
      {
        LordEquipData._instance.LordEquip[index] = itemLordEquip.Clone();
        break;
      }
    }
  }

  public static void DeleteItem(MessagePacket MP)
  {
    if (!LordEquipData.EqDataReq)
      return;
    uint num = MP.ReadUInt();
    if (num == 0U)
      return;
    for (int index = 0; index < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index)
    {
      if ((int) LordEquipData._instance.LordEquip[index].SerialNO == (int) num)
      {
        LordEquipData._instance.LordEquip[index].Clear();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1, 1);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquipSetEdit, 3);
        LordEquipData._instance.ScanEquipUpdate();
        break;
      }
    }
  }

  public static void Recv_MSG_RESP_ONLORDEQUIP_INFO(MessagePacket MP)
  {
    for (int index1 = 0; index1 < 8; ++index1)
    {
      LordEquipData.RoleEquip[index1].Init();
      LordEquipData.RoleEquip[index1].ItemID = MP.ReadUShort();
      LordEquipData.RoleEquip[index1].Color = MP.ReadByte();
      for (int index2 = 0; index2 < 4; ++index2)
        LordEquipData.RoleEquip[index1].GemColor[index2] = MP.ReadByte();
      for (int index3 = 0; index3 < 4; ++index3)
        LordEquipData.RoleEquip[index1].Gem[index3] = MP.ReadUShort();
      LordEquipData.RoleEquipSerial[index1] = MP.ReadUInt();
    }
    DataManager.Instance.AttribVal.UpdateLordEquipData();
  }

  public void ChangeEquip(byte equipPos, uint serial)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.LordEquip))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PUTON_TAKEOFF_LORDEQUIP;
    messagePacket.AddSeqId();
    messagePacket.Add(equipPos);
    messagePacket.Add(serial);
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_PUTON_TAKEOFF_LORDEQUIP(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    byte index1 = MP.ReadByte();
    uint num = MP.ReadUInt();
    LordEquipData.RoleEquipSerial[(int) index1] = num;
    LordEquipData.RoleEquip[(int) index1].Clear();
    if (num != 0U)
    {
      for (int index2 = 0; index2 < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index2)
      {
        if ((int) this.LordEquip[index2].SerialNO == (int) num)
          LordEquipData.RoleEquip[(int) index1] = this.LordEquip[index2].CloneSerial();
      }
    }
    DataManager.Instance.AttribVal.UpdateLordEquipData();
    if ((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_LordEquip) != (UnityEngine.Object) null)
      ((Door) GUIManager.Instance.FindMenu(EGUIWindow.Door)).CloseMenu();
    GUIManager.Instance.HideUILock(EUILock.LordEquip);
    AudioManager.Instance.PlayUISFX(UIKind.EquipTake);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
  }

  public static void ResetData()
  {
    LordEquipData.EqDataReq = false;
    LordEquipData.GemDataReq = false;
    LordEquipData.MaterialDataReq = false;
    if ((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Anvil) == (UnityEngine.Object) null)
      DataManager.Instance.RemoveDoorUIStack(EGUIWindow.UI_Anvil);
    LordEquipData.Instance().LoadLordEquip(true);
    LordEquipData.Instance().LoadLEMaterial(true);
    LordEquipData.Instance().LoadLEGem(true);
    LordEquipData.Instance().LordEquipSetsCount = 0;
  }

  public void upgradeMaterial(ushort itemID, byte targetColor, ushort Quantity)
  {
    byte data = DataManager.Instance.EquipTable.GetRecordByKey(itemID).EquipKind != (byte) 20 ? (byte) 1 : (byte) 0;
    if (!GUIManager.Instance.ShowUILock(EUILock.LordEquip))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_SYN_MATGEM;
    messagePacket.AddSeqId();
    messagePacket.Add(data);
    messagePacket.Add(itemID);
    messagePacket.Add(targetColor);
    messagePacket.Add(Quantity);
    messagePacket.Send();
  }

  public void Recv_MSG_LORD_RESPSYN_MATGEM(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    byte num = MP.ReadByte();
    LordEquipData.setItemQuantity(MP.ReadUShort(), MP.ReadByte(), MP.ReadUShort(), 0L);
    LordEquipData.setItemQuantity(MP.ReadUShort(), MP.ReadByte(), MP.ReadUShort(), 0L);
    long time = MP.ReadLong();
    if (num == (byte) 0)
      LordEquipData.SetMatTime(time);
    else
      LordEquipData.SetGemTime(time);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, num != (byte) 0 ? 2 : 3, 1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UIDonation, 1);
    AudioManager.Instance.PlayUISFX(UIKind.EquipFoundry);
    GUIManager.Instance.HideUILock(EUILock.LordEquip);
  }

  public void CombineEquip(ushort itemID, uint Serial)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.LordEquip))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_SYN_LORDEQUIP;
    messagePacket.AddSeqId();
    messagePacket.Add(itemID);
    messagePacket.Add(Serial);
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_SYN_LORDEQUIP(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    DataManager.Instance.RoleAttr.LordEquipEventData.Init();
    DataManager.Instance.RoleAttr.LordEquipEventData.ItemID = MP.ReadUShort();
    DataManager.Instance.RoleAttr.LordEquipEventData.Color = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      DataManager.Instance.RoleAttr.LordEquipEventData.GemColor[index] = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      DataManager.Instance.RoleAttr.LordEquipEventData.Gem[index] = MP.ReadUShort();
    DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO = MP.ReadUInt();
    DataManager.Instance.RoleAttr.LordEquipEventTime.BeginTime = MP.ReadLong();
    DataManager.Instance.RoleAttr.LordEquipEventTime.RequireTime = MP.ReadUInt();
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Forging, true, DataManager.Instance.RoleAttr.LordEquipEventTime.BeginTime, DataManager.Instance.RoleAttr.LordEquipEventTime.RequireTime);
    for (int index = 0; index < 4; ++index)
      LordEquipData.setItemQuantity(MP.ReadUShort(), MP.ReadByte(), MP.ReadUShort(), 0L);
    DataManager.Instance.Resource[4].Stock = MP.ReadUInt();
    LordEquipData.SetMatTime(MP.ReadLong());
    for (int index = 0; index < 8; ++index)
    {
      if ((int) LordEquipData.RoleEquipSerial[index] == (int) DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO)
      {
        LordEquipData.RoleEquipSerial[index] = 0U;
        LordEquipData.RoleEquip[index].Clear();
        DataManager.Instance.AttribVal.UpdateLordEquipData();
        break;
      }
    }
    this.ScanEquipUpdate();
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
    UIAnvil.OpenKind = eUI_Anvil_OpenKind.NowForging;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 2);
    AudioManager.Instance.PlayUISFX(UIKind.EquipFoundry);
    GUIManager.Instance.HideUILock(EUILock.LordEquip);
    FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_EQUIPMENT_FORGED);
  }

  public static void CancelCombine()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.LordEquip))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_SYN_LORDEQUIP_EVENT_CANCEL;
    messagePacket.AddSeqId();
    messagePacket.Add(DataManager.Instance.RoleAttr.LordEquipEventData.ItemID);
    messagePacket.Add(DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO);
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_SYN_LORDEQUIP_EVENT_CANCEL(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    for (int index = 0; index < 4; ++index)
      LordEquipData.setItemQuantity(MP.ReadUShort(), MP.ReadByte(), MP.ReadUShort(), 0L);
    DataManager.Instance.Resource[4].Stock = MP.ReadUInt();
    LordEquipData.SetMatTime(MP.ReadLong());
    int equipIndex = this.GetEquipIndex(DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO);
    if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.NowForging && equipIndex < 0)
      UIAnvil.preSetID = DataManager.Instance.RoleAttr.LordEquipEventData.ItemID;
    LordEquipData.CleanForgeQuere();
    this.ScanEquipUpdate();
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 3, equipIndex);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Forge, 1);
    GUIManager.Instance.HideUILock(EUILock.LordEquip);
  }

  public void Recv_MSG_RESP_SYN_LORDEQUIP_EVENT_COMPLETE(MessagePacket MP)
  {
    ItemLordEquip equip = new ItemLordEquip();
    equip.Init();
    equip.ItemID = MP.ReadUShort();
    equip.Color = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      equip.GemColor[index] = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      equip.Gem[index] = MP.ReadUShort();
    equip.SerialNO = MP.ReadUInt();
    LordEquipData.ShowItemFinish(equip);
    int num1 = -1;
    long num2 = MP.ReadLong();
    if (LordEquipData.EqDataReq)
    {
      num1 = LordEquipData.updateEquip(equip);
      this.LastUpdateTime_Equip = num2;
    }
    LordEquipData.CleanForgeQuere();
    this.ScanEquipUpdate();
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
    if ((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Anvil) != (UnityEngine.Object) null)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 3, num1);
    else if (num1 >= 0)
    {
      UIAnvil.preSetIndex = (ushort) num1;
      UIAnvil.OpenKind = eUI_Anvil_OpenKind.UpgradeItem;
    }
    else
      DataManager.Instance.RemoveDoorUIStack(EGUIWindow.UI_Anvil);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Forge, 1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquipSetEdit, 1);
    GUIManager.Instance.HideUILock(EUILock.LordEquip);
  }

  public void QuickCombine(ushort itemID, uint Serial)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.LordEquip))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_SYN_LORDEQUIP_INSTANT;
    messagePacket.AddSeqId();
    messagePacket.Add(itemID);
    messagePacket.Add(Serial);
    messagePacket.Send();
  }

  public static void Recv_MSG_RESP_SYN_LORDEQUIP_INSTANT(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    ItemLordEquip equip = new ItemLordEquip();
    equip.Init();
    equip.ItemID = MP.ReadUShort();
    equip.Color = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      equip.GemColor[index] = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      equip.Gem[index] = MP.ReadUShort();
    equip.SerialNO = MP.ReadUInt();
    LordEquipData.ShowItemFinish(equip);
    for (int index = 0; index < 4; ++index)
      LordEquipData.setItemQuantity(MP.ReadUShort(), MP.ReadByte(), MP.ReadUShort(), 0L);
    DataManager.Instance.Resource[4].Stock = MP.ReadUInt();
    GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0, eSpentCredits.eInstantCraftLordEquip);
    long num1 = MP.ReadLong();
    int num2 = 0;
    if (LordEquipData.EqDataReq)
    {
      num2 = LordEquipData.updateEquip(equip);
      LordEquipData._instance.LastUpdateTime_Equip = num1;
    }
    LordEquipData.SetMatTime(MP.ReadLong());
    for (int index = 0; index < 8; ++index)
    {
      if ((int) LordEquipData.RoleEquipSerial[index] == (int) equip.SerialNO)
      {
        LordEquipData.RoleEquipSerial[index] = 0U;
        LordEquipData.RoleEquip[index].Clear();
        DataManager.Instance.AttribVal.UpdateLordEquipData();
        break;
      }
    }
    LordEquipData.CleanForgeQuere();
    LordEquipData.Instance().ScanEquipUpdate();
    GameManager.OnRefresh();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 5, num2);
    AudioManager.Instance.PlayUISFX(UIKind.EquipFoundry);
    GUIManager.Instance.HideUILock(EUILock.LordEquip);
    FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_EQUIPMENT_FORGED);
  }

  public static void QuickCombineinForge()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.LordEquip))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_FINISH_SYN_LORDEQUIP_EVENT;
    messagePacket.AddSeqId();
    messagePacket.Add(DataManager.Instance.RoleAttr.LordEquipEventData.ItemID);
    messagePacket.Add(DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO);
    messagePacket.Send();
  }

  public static void Recv_MSG_RESP_FINISH_SYN_LORDEQUIP_EVENT(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    ItemLordEquip equip = new ItemLordEquip();
    equip.Init();
    equip.ItemID = MP.ReadUShort();
    equip.Color = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      equip.GemColor[index] = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      equip.Gem[index] = MP.ReadUShort();
    equip.SerialNO = MP.ReadUInt();
    LordEquipData.ShowItemFinish(equip);
    GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0, eSpentCredits.eCraftLordEquipInstantFinish);
    long num1 = MP.ReadLong();
    int num2 = -1;
    if (LordEquipData.EqDataReq)
    {
      num2 = LordEquipData.updateEquip(equip);
      LordEquipData._instance.LastUpdateTime_Equip = num1;
    }
    LordEquipData.CleanForgeQuere();
    LordEquipData.Instance().ScanEquipUpdate();
    GameManager.OnRefresh();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 3, num2);
    AudioManager.Instance.PlayUISFX(UIKind.EquipFoundry);
    GUIManager.Instance.HideUILock(EUILock.LordEquip);
  }

  public void DeleteEquip(uint Serial)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.LordEquip))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_DECOMPOSE_LORDEQUIP;
    messagePacket.AddSeqId();
    messagePacket.Add(Serial);
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_DECOMPOSE_LORDEQUIP(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    byte index = MP.ReadByte();
    ushort num = MP.ReadUShort();
    byte color = MP.ReadByte();
    ushort Quantity = MP.ReadUShort();
    LordEquipData.setItemQuantity(num, color, Quantity, 0L);
    uint serial = MP.ReadUInt();
    LordEquipData.SetItemTime(MP.ReadLong());
    LordEquipData.SetMatTime(MP.ReadLong());
    int equipIndex = this.GetEquipIndex(serial);
    CString msgStr = GUIManager.Instance.MsgStr;
    CString tmpS = StringManager.Instance.StaticString1024();
    tmpS.ClearString();
    Equip recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(num);
    tmpS.Append(GameConstants.SItemRareHeader[(int) color]);
    tmpS.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
    tmpS.Append("</color>");
    Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(this.LordEquip[equipIndex].ItemID);
    msgStr.ClearString();
    msgStr.StringToFormat(tmpS);
    msgStr.IntToFormat((long) recordByKey2.SyntheticParts[(int) index].SyntheticItemNum);
    msgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7507U));
    GUIManager.Instance.AddHUDMessage(msgStr.ToString(), (ushort) byte.MaxValue);
    this.LordEquip[equipIndex].Clear();
    this.ScanEquipUpdate();
    this.QuickSetSerialCheck = false;
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1, 1);
    GUIManager.Instance.HideUILock(EUILock.LordEquip);
  }

  public void InlayGem(ushort GemID, byte GemColor, uint ItemSerial, byte Pos)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.LordEquip))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_INLAY_LORDEQUIP;
    messagePacket.AddSeqId();
    messagePacket.Add(GemID);
    messagePacket.Add(GemColor);
    messagePacket.Add(ItemSerial);
    messagePacket.Add(Pos);
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_INLAY_LORDEQUIP(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    LordEquipData.setItemQuantity(MP.ReadUShort(), MP.ReadByte(), MP.ReadUShort(), 0L);
    ItemLordEquip equip = new ItemLordEquip();
    equip.Init();
    equip.ItemID = MP.ReadUShort();
    equip.Color = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      equip.GemColor[index] = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      equip.Gem[index] = MP.ReadUShort();
    equip.SerialNO = MP.ReadUInt();
    LordEquipData.updateEquip(equip);
    LordEquipData.SetItemTime(MP.ReadLong());
    LordEquipData.SetGemTime(MP.ReadLong());
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7480U), (ushort) byte.MaxValue);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1);
    GUIManager.Instance.HideUILock(EUILock.LordEquip);
  }

  public void RemoveGameFree(uint ItemSerial, byte Pos)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.LordEquip))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_FREE_TAKEOFF_GEM;
    messagePacket.AddSeqId();
    messagePacket.Add(Pos);
    messagePacket.Add(ItemSerial);
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_FREE_TAKEOFF_GEM(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    ItemLordEquip equip = new ItemLordEquip();
    equip.Init();
    equip.ItemID = MP.ReadUShort();
    equip.Color = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      equip.GemColor[index] = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      equip.Gem[index] = MP.ReadUShort();
    equip.SerialNO = MP.ReadUInt();
    LordEquipData.updateEquip(equip);
    LordEquipData.SetItemTime(MP.ReadLong());
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7485U), (ushort) byte.MaxValue);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1);
    if ((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter) != (UnityEngine.Object) null)
      ((Door) GUIManager.Instance.FindMenu(EGUIWindow.Door)).CloseMenu();
    GUIManager.Instance.HideUILock(EUILock.LordEquip);
  }

  public void Recv_Gem_TAKEOFF(MessagePacket MP)
  {
    LordEquipData.setItemQuantity(MP.ReadUShort(), MP.ReadByte(), MP.ReadUShort(), 0L);
    ItemLordEquip equip = new ItemLordEquip();
    equip.Init();
    equip.ItemID = MP.ReadUShort();
    equip.Color = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      equip.GemColor[index] = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      equip.Gem[index] = MP.ReadUShort();
    equip.SerialNO = MP.ReadUInt();
    LordEquipData.updateEquip(equip);
    LordEquipData.SetItemTime(MP.ReadLong());
    LordEquipData.SetGemTime(MP.ReadLong());
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7485U), (ushort) byte.MaxValue);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 1);
    if ((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter) != (UnityEngine.Object) null)
      ((Door) GUIManager.Instance.FindMenu(EGUIWindow.Door)).CloseMenu();
    GUIManager.Instance.HideUILock(EUILock.LordEquip);
  }

  public void DeComposeMaterial(ushort itemID, byte targetColor, ushort Quantity)
  {
    byte data = DataManager.Instance.EquipTable.GetRecordByKey(itemID).EquipKind != (byte) 20 ? (byte) 1 : (byte) 0;
    if (!GUIManager.Instance.ShowUILock(EUILock.LordEquip))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_DECOMPOSE_MATGEM;
    messagePacket.AddSeqId();
    messagePacket.Add(data);
    messagePacket.Add(itemID);
    messagePacket.Add(targetColor);
    messagePacket.Add(Quantity);
    messagePacket.Send();
  }

  public void Recv_MSG_LORD_RESPDECOMPOSE_MATGEM(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    byte num = MP.ReadByte();
    LordEquipData.setItemQuantity(MP.ReadUShort(), MP.ReadByte(), MP.ReadUShort(), 0L);
    LordEquipData.setItemQuantity(MP.ReadUShort(), MP.ReadByte(), MP.ReadUShort(), 0L);
    long time = MP.ReadLong();
    if (num == (byte) 0)
      LordEquipData.SetMatTime(time);
    else
      LordEquipData.SetGemTime(time);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, num != (byte) 0 ? 2 : 3, 1);
    AudioManager.Instance.PlayUISFX(UIKind.EquipFoundry);
    GUIManager.Instance.HideUILock(EUILock.LordEquip);
  }

  public void RESP_ALL_LORDEQUIP_MEMORY(MessagePacket MP)
  {
    byte num1 = MP.ReadByte();
    int newSize = ((int) num1 + 1) * 10;
    if (this.LordEquipSets.Length < newSize)
      Array.Resize<LordEquipSet>(ref this.LordEquipSets, newSize);
    int num2 = (int) MP.ReadByte() + (int) num1 * 10;
    this.LordEquipSetsCount = num2;
    for (int index1 = (int) num1 * 10; index1 < num2; ++index1)
    {
      if (this.LordEquipSets[index1] == null)
        this.LordEquipSets[index1] = new LordEquipSet();
      if (this.LordEquipSets[index1].Name == null)
        this.LordEquipSets[index1].Name = StringManager.Instance.SpawnString();
      MP.ReadStringPlus((int) GameConstants.MAX_TALENT_CACHE_NAME_BYTE, this.LordEquipSets[index1].Name);
      for (int index2 = 0; index2 < 8; ++index2)
        this.LordEquipSets[index1].SerialNO[index2] = MP.ReadUInt();
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordInfo, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquipSetSelect, 0);
  }

  public void RESP_LORDEQUIP_CHANGE(MessagePacket MP)
  {
    if (MP.ReadByte() == (byte) 0)
    {
      for (int index1 = 0; index1 < LordEquipData.RoleEquipSerial.Length; ++index1)
      {
        LordEquipData.RoleEquipSerial[index1] = MP.ReadUInt();
        if (LordEquipData.RoleEquipSerial[index1] == 0U)
        {
          LordEquipData.RoleEquip[index1].Clear();
        }
        else
        {
          for (int index2 = 0; index2 < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index2)
          {
            if ((int) this.LordEquip[index2].SerialNO == (int) LordEquipData.RoleEquipSerial[index1])
              LordEquipData.RoleEquip[index1] = this.LordEquip[index2].CloneSerial();
          }
        }
      }
    }
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(927U), (ushort) byte.MaxValue);
    DataManager.Instance.AttribVal.UpdateLordEquipData();
    AudioManager.Instance.PlayUISFX(UIKind.EquipTake);
    GUIManager.Instance.HideUILock(EUILock.LordInfo);
    if (!((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_LordEquipSetSelect) != (UnityEngine.Object) null))
      return;
    Door menu = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.CloseMenu();
  }

  public static ushort getItemQuantity(ushort ItemID, byte color)
  {
    switch (DataManager.Instance.EquipTable.GetRecordByKey(ItemID).EquipKind)
    {
      case 20:
        if (!LordEquipData.MaterialDataReq)
          return 0;
        for (int index = 0; index < LordEquipData._instance.LEMaterial.Length; ++index)
        {
          if ((int) LordEquipData._instance.LEMaterial[index].ItemID == (int) ItemID && (int) LordEquipData._instance.LEMaterial[index].Color == (int) color)
            return LordEquipData._instance.LEMaterial[index].Quantity;
        }
        break;
      case 27:
        if (!LordEquipData.GemDataReq)
          return 0;
        for (int index = 0; index < LordEquipData._instance.LEGem.Length; ++index)
        {
          if ((int) LordEquipData._instance.LEGem[index].ItemID == (int) ItemID && (int) LordEquipData._instance.LEGem[index].Color == (int) color)
            return LordEquipData._instance.LEGem[index].Quantity;
        }
        break;
      default:
        if (!LordEquipData.EqDataReq)
          return 0;
        ushort itemQuantity = 0;
        for (int index = 0; index < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index)
        {
          if ((int) LordEquipData._instance.LordEquip[index].ItemID == (int) ItemID && (int) LordEquipData._instance.LordEquip[index].Color == (int) color)
            ++itemQuantity;
        }
        return itemQuantity;
    }
    return 0;
  }

  public static void setItemQuantity(
    ushort ItemID,
    byte color,
    ushort Quantity,
    long lastUpdateTime = 0)
  {
    switch (DataManager.Instance.EquipTable.GetRecordByKey(ItemID).EquipKind)
    {
      case 20:
        if (!LordEquipData.MaterialDataReq)
          break;
        for (int index = 0; index < LordEquipData._instance.LEMaterial.Length; ++index)
        {
          if ((int) LordEquipData._instance.LEMaterial[index].ItemID == (int) ItemID && (int) LordEquipData._instance.LEMaterial[index].Color == (int) color)
          {
            if (Quantity == (ushort) 0)
              LordEquipData._instance.LEMaterial[index].Clear();
            else
              LordEquipData._instance.LEMaterial[index].Quantity = Quantity;
            LordEquipData._instance.CountMat(ItemID);
            if (lastUpdateTime == 0L)
              return;
            LordEquipData.SetMatTime(lastUpdateTime);
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 3);
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 1);
            return;
          }
        }
        if (Quantity == (ushort) 0)
          break;
        for (int index = 0; index < LordEquipData._instance.LEMaterial.Length; ++index)
        {
          if (LordEquipData._instance.LEMaterial[index].ItemID == (ushort) 0)
          {
            LordEquipData._instance.LEMaterial[index].ItemID = ItemID;
            LordEquipData._instance.LEMaterial[index].Color = color;
            LordEquipData._instance.LEMaterial[index].Quantity = Quantity;
            if (lastUpdateTime != 0L)
            {
              LordEquipData.SetMatTime(lastUpdateTime);
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 3);
              GUIManager.Instance.UpdateUI(EGUIWindow.UI_Anvil, 1);
            }
            LordEquipData._instance.CountMat(ItemID);
            break;
          }
        }
        break;
      case 27:
        if (!LordEquipData.GemDataReq)
          break;
        for (int index = 0; index < LordEquipData._instance.LEGem.Length; ++index)
        {
          if ((int) LordEquipData._instance.LEGem[index].ItemID == (int) ItemID && (int) LordEquipData._instance.LEGem[index].Color == (int) color)
          {
            if (Quantity == (ushort) 0)
              LordEquipData._instance.LEGem[index].Clear();
            else
              LordEquipData._instance.LEGem[index].Quantity = Quantity;
            if (lastUpdateTime == 0L)
              return;
            LordEquipData.SetGemTime(lastUpdateTime);
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 2);
            return;
          }
        }
        for (int index = 0; index < LordEquipData._instance.LEGem.Length; ++index)
        {
          if (LordEquipData._instance.LEGem[index].ItemID == (ushort) 0)
          {
            LordEquipData._instance.LEGem[index].ItemID = ItemID;
            LordEquipData._instance.LEGem[index].Color = color;
            LordEquipData._instance.LEGem[index].Quantity = Quantity;
            if (lastUpdateTime == 0L)
              break;
            LordEquipData.SetGemTime(lastUpdateTime);
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 2);
            break;
          }
        }
        break;
    }
  }

  public static void SetItemTime(long time)
  {
    if (!LordEquipData.EqDataReq)
      return;
    LordEquipData._instance.LastUpdateTime_Equip = time;
  }

  public static void SetGemTime(long time)
  {
    if (!LordEquipData.GemDataReq)
      return;
    LordEquipData._instance.LastUpdateTime_Gem = time;
  }

  public static void SetMatTime(long time)
  {
    if (!LordEquipData.MaterialDataReq)
      return;
    LordEquipData._instance.LastUpdateTime_Material = time;
  }

  public static int updateEquip(ItemLordEquip equip)
  {
    if (equip.SerialNO != 0U)
    {
      for (int index = 0; index < 8; ++index)
      {
        if ((int) LordEquipData.RoleEquipSerial[index] == (int) equip.SerialNO)
        {
          LordEquipData.RoleEquip[index] = equip.CloneSerial();
          DataManager.Instance.AttribVal.UpdateLordEquipData();
          break;
        }
      }
    }
    if (LordEquipData.EqDataReq)
    {
      for (int index = 0; index < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index)
      {
        if ((int) LordEquipData._instance.LordEquip[index].SerialNO == (int) equip.SerialNO)
        {
          equip.ExpireTime = LordEquipData._instance.LordEquip[index].ExpireTime;
          LordEquipData._instance.LordEquip[index] = equip.Clone();
          return index;
        }
      }
      for (int index = 0; index < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index)
      {
        if (LordEquipData._instance.LordEquip[index].SerialNO == 0U)
        {
          LordEquipData._instance.LordEquip[index] = equip.Clone();
          return index;
        }
      }
    }
    return -1;
  }

  public static int updateEquipTime(uint Serial, long time)
  {
    if (Serial == 0U || !LordEquipData.EqDataReq)
      return -1;
    for (int index = 0; index < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index)
    {
      if ((int) LordEquipData._instance.LordEquip[index].SerialNO == (int) Serial)
      {
        LordEquipData._instance.LordEquip[index].ExpireTime = time;
        LordEquipData._instance.EquipExpireTime.Add(time);
        LordEquipData._instance.EquipExpireTime.Sort(new Comparison<long>(LordEquipData.timeSort));
        return index;
      }
    }
    return -1;
  }

  public static void CheckEquipExpired()
  {
    ushort data = 0;
    for (int index = 0; index < LordEquipData._instance.EquipExpireTime.Count && DataManager.Instance.ServerTime >= LordEquipData._instance.EquipExpireTime[index]; ++index)
      ++data;
    if (data == (ushort) 0)
      return;
    long serverTime = DataManager.Instance.ServerTime;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_LORDEQUIP_CHECKEXPIRE;
    messagePacket.AddSeqId();
    messagePacket.Add(data);
    for (int index = 0; index < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index)
    {
      if (LordEquipData._instance.LordEquip[index].ExpireTime > 0L && LordEquipData._instance.LordEquip[index].ExpireTime <= serverTime)
        messagePacket.Add(LordEquipData._instance.LordEquip[index].SerialNO);
    }
    messagePacket.Send();
  }

  public static long getEquipTime(uint Serial)
  {
    if (Serial == 0U || !LordEquipData.EqDataReq)
      return 0;
    for (int index = 0; index < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index)
    {
      if ((int) LordEquipData._instance.LordEquip[index].SerialNO == (int) Serial)
        return LordEquipData._instance.LordEquip[index].ExpireTime;
    }
    return 0;
  }

  public static void CleanForgeQuere()
  {
    DataManager.Instance.RoleAttr.LordEquipEventData.Clear();
    DataManager.Instance.RoleAttr.LordEquipEventTime.BeginTime = 0L;
    DataManager.Instance.RoleAttr.LordEquipEventTime.RequireTime = 0U;
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Forging, false, DataManager.Instance.RoleAttr.LordEquipEventTime.BeginTime, DataManager.Instance.RoleAttr.LordEquipEventTime.RequireTime);
  }

  public static void ShowItemFinish(ItemLordEquip equip)
  {
    CString msgStr = GUIManager.Instance.MsgStr;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    GameConstants.GetColoredLordEquipString(cstring, equip.ItemID, equip.Color);
    msgStr.ClearString();
    msgStr.StringToFormat(cstring);
    if ((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Anvil) != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Forge) != (UnityEngine.Object) null)
    {
      msgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7448U));
      GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(7447U), msgStr.ToString());
    }
    else
    {
      msgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7510U));
      GUIManager.Instance.AddHUDMessage(msgStr.ToString(), (ushort) 10);
    }
  }

  public int GetEquipIndex(uint serial)
  {
    if (serial == 0U)
      return -1;
    for (byte equipIndex = 0; (int) equipIndex < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++equipIndex)
    {
      if ((int) this.LordEquip[(int) equipIndex].SerialNO == (int) serial)
        return (int) equipIndex;
    }
    return -1;
  }

  public int GetEquipPos(ushort itemid)
  {
    switch (DataManager.Instance.EquipTable.GetRecordByKey(itemid).EquipKind)
    {
      case 21:
        return 0;
      case 22:
        return 1;
      case 23:
        return 2;
      case 24:
        return 3;
      case 25:
        return 4;
      case 26:
        return 5;
      default:
        return -1;
    }
  }

  public static void GetEffectList(
    ItemLordEquip item,
    List<LordEquipEffectSet> effList,
    byte overrideColor = 0)
  {
    if (item.ItemID == (ushort) 0 || item.Color == (byte) 0)
      return;
    Equip recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(item.ItemID);
    byte color = item.Color;
    if (overrideColor > (byte) 0)
      color = overrideColor;
    for (int index = 0; index < 6; ++index)
    {
      if (recordByKey1.PropertiesInfo[index].PropertiesValue > (ushort) 0)
      {
        LordEquipEffectSet singleEquipEffect = LordEquipData.GetSingleEquipEffect(recordByKey1.PropertiesInfo[index].Propertieskey, color);
        LordEquipData.AddEquipEffect(effList, singleEquipEffect);
      }
    }
    for (int index1 = 0; index1 < 4; ++index1)
    {
      if (item.Gem[index1] != (ushort) 0)
      {
        Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(item.Gem[index1]);
        for (int index2 = 0; index2 < 6; ++index2)
        {
          if (recordByKey2.PropertiesInfo[index2].PropertiesValue > (ushort) 0)
          {
            LordEquipEffectSet singleEquipEffect = LordEquipData.GetSingleEquipEffect(recordByKey2.PropertiesInfo[index2].Propertieskey, item.GemColor[index1]);
            LordEquipData.AddEquipEffect(effList, singleEquipEffect);
          }
        }
      }
    }
  }

  public static void GetEffectList(
    LordEquipSerialData item,
    List<LordEquipEffectSet> effList,
    byte overrideColor = 0)
  {
    if (item.ItemID == (ushort) 0 || item.Color == (byte) 0)
      return;
    Equip recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(item.ItemID);
    byte color = item.Color;
    if (overrideColor > (byte) 0)
      color = overrideColor;
    for (int index = 0; index < 6; ++index)
    {
      if (recordByKey1.PropertiesInfo[index].PropertiesValue > (ushort) 0)
      {
        LordEquipEffectSet singleEquipEffect = LordEquipData.GetSingleEquipEffect(recordByKey1.PropertiesInfo[index].Propertieskey, color);
        LordEquipData.AddEquipEffect(effList, singleEquipEffect);
      }
    }
    for (int index1 = 0; index1 < 4; ++index1)
    {
      if (item.Gem[index1] != (ushort) 0)
      {
        Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(item.Gem[index1]);
        for (int index2 = 0; index2 < 6; ++index2)
        {
          if (recordByKey2.PropertiesInfo[index2].PropertiesValue > (ushort) 0)
          {
            LordEquipEffectSet singleEquipEffect = LordEquipData.GetSingleEquipEffect(recordByKey2.PropertiesInfo[index2].Propertieskey, item.GemColor[index1]);
            LordEquipData.AddEquipEffect(effList, singleEquipEffect);
          }
        }
      }
    }
  }

  public static void GetEffectList(LordEquipMaterial gem, List<LordEquipEffectSet> effList)
  {
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(gem.ItemID);
    for (int index = 0; index < 6; ++index)
    {
      if (recordByKey.PropertiesInfo[index].PropertiesValue > (ushort) 0)
      {
        LordEquipEffectSet singleEquipEffect = LordEquipData.GetSingleEquipEffect(recordByKey.PropertiesInfo[index].Propertieskey, gem.Color);
        LordEquipData.AddEquipEffect(effList, singleEquipEffect);
      }
    }
  }

  public static void GetEffectList(ushort ItemID, byte color, List<LordEquipEffectSet> effList)
  {
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(ItemID);
    for (int index = 0; index < 6; ++index)
    {
      if (recordByKey.PropertiesInfo[index].PropertiesValue > (ushort) 0)
      {
        LordEquipEffectSet singleEquipEffect = LordEquipData.GetSingleEquipEffect(recordByKey.PropertiesInfo[index].Propertieskey, color);
        LordEquipData.AddEquipEffect(effList, singleEquipEffect);
      }
    }
  }

  public static void GetEffectCompareList(
    ItemLordEquip item,
    ItemLordEquip newItem,
    out List<LordEquipEffectCompareSet> effCompareList)
  {
    effCompareList = new List<LordEquipEffectCompareSet>();
    List<LordEquipEffectSet> effList1 = new List<LordEquipEffectSet>();
    List<LordEquipEffectSet> effList2 = new List<LordEquipEffectSet>();
    LordEquipData.GetEffectList(newItem, effList1, (byte) 0);
    LordEquipData.GetEffectList(item, effList2, (byte) 0);
    for (int index1 = 0; index1 < effList1.Count; ++index1)
    {
      bool flag = false;
      for (int index2 = 0; index2 < effList2.Count; ++index2)
      {
        if ((int) effList1[index1].EffectID == (int) effList2[index2].EffectID)
        {
          flag = true;
          if ((int) effList1[index1].EffectValue == (int) effList2[index2].EffectValue)
            effCompareList.Add(new LordEquipEffectCompareSet(effList1[index1].EffectID, (int) effList1[index1].EffectValue, true, (byte) 0));
          else
            effCompareList.Add(new LordEquipEffectCompareSet(effList1[index1].EffectID, (int) effList1[index1].EffectValue - (int) effList2[index2].EffectValue, false, (byte) 0));
        }
      }
      if (!flag)
        effCompareList.Add(new LordEquipEffectCompareSet(effList1[index1].EffectID, (int) effList1[index1].EffectValue, false, (byte) 0));
    }
    for (int index3 = 0; index3 < effList2.Count; ++index3)
    {
      bool flag = false;
      for (int index4 = 0; index4 < effList1.Count; ++index4)
      {
        if ((int) effList2[index3].EffectID == (int) effList1[index4].EffectID)
          flag = true;
      }
      if (!flag)
        effCompareList.Add(new LordEquipEffectCompareSet(effList2[index3].EffectID, (int) -effList2[index3].EffectValue, false, (byte) 0));
    }
  }

  public static void GetEffectCompareList(
    LordEquipSerialData item,
    ItemLordEquip newItem,
    out List<LordEquipEffectCompareSet> effCompareList)
  {
    effCompareList = new List<LordEquipEffectCompareSet>();
    List<LordEquipEffectSet> effList1 = new List<LordEquipEffectSet>();
    List<LordEquipEffectSet> effList2 = new List<LordEquipEffectSet>();
    LordEquipData.GetEffectList(newItem, effList1, (byte) 0);
    LordEquipData.GetEffectList(item, effList2, (byte) 0);
    for (int index1 = 0; index1 < effList1.Count; ++index1)
    {
      bool flag = false;
      for (int index2 = 0; index2 < effList2.Count; ++index2)
      {
        if ((int) effList1[index1].EffectID == (int) effList2[index2].EffectID)
        {
          flag = true;
          if ((int) effList1[index1].EffectValue == (int) effList2[index2].EffectValue)
            effCompareList.Add(new LordEquipEffectCompareSet(effList1[index1].EffectID, (int) effList1[index1].EffectValue, true, (byte) 0));
          else
            effCompareList.Add(new LordEquipEffectCompareSet(effList1[index1].EffectID, (int) effList1[index1].EffectValue - (int) effList2[index2].EffectValue, false, (byte) 0));
        }
      }
      if (!flag)
        effCompareList.Add(new LordEquipEffectCompareSet(effList1[index1].EffectID, (int) effList1[index1].EffectValue, false, (byte) 0));
    }
    for (int index3 = 0; index3 < effList2.Count; ++index3)
    {
      bool flag = false;
      for (int index4 = 0; index4 < effList1.Count; ++index4)
      {
        if ((int) effList2[index3].EffectID == (int) effList1[index4].EffectID)
          flag = true;
      }
      if (!flag)
        effCompareList.Add(new LordEquipEffectCompareSet(effList2[index3].EffectID, (int) -effList2[index3].EffectValue, false, (byte) 0));
    }
  }

  public static void AddEquipEffect(List<LordEquipEffectSet> effList, LordEquipEffectSet add)
  {
    if (add.EffectID == (ushort) 0)
      return;
    for (int index = 0; index < effList.Count; ++index)
    {
      if ((int) effList[index].EffectID == (int) add.EffectID)
      {
        effList[index].EffectValue += add.EffectValue;
        return;
      }
    }
    effList.Add(add);
  }

  public static LordEquipEffectSet GetSingleEquipEffect(ushort EquipEffectID, byte color)
  {
    LordEquipEffectSet singleEquipEffect = new LordEquipEffectSet();
    LordEquipEffectData recordByKey = DataManager.Instance.LordEquipEffectTable.GetRecordByKey(EquipEffectID);
    singleEquipEffect.EffectID = recordByKey.EffectID;
    singleEquipEffect.EffectValue = (ushort) 0;
    if (color == (byte) 0)
      return singleEquipEffect;
    singleEquipEffect.EffectValue = color < (byte) 5 ? recordByKey.RarePercent[(int) color - 1] : recordByKey.RarePercent[4];
    return singleEquipEffect;
  }

  public static string GetItemKindTalkID(byte ItemKind)
  {
    switch (ItemKind)
    {
      case 20:
      case 27:
        return DataManager.Instance.mStringTable.GetStringByID(7454U);
      case 21:
        return DataManager.Instance.mStringTable.GetStringByID(7431U);
      case 22:
        return DataManager.Instance.mStringTable.GetStringByID(7432U);
      case 23:
        return DataManager.Instance.mStringTable.GetStringByID(7433U);
      case 24:
        return DataManager.Instance.mStringTable.GetStringByID(7434U);
      case 25:
        return DataManager.Instance.mStringTable.GetStringByID(7435U);
      case 26:
        return DataManager.Instance.mStringTable.GetStringByID(7436U);
      default:
        return string.Empty;
    }
  }

  public static int EffectCompare(LordEquipEffectCompareSet x, LordEquipEffectCompareSet y)
  {
    if ((int) x.group == (int) y.group)
      return 0;
    return (int) x.group > (int) y.group ? 1 : -1;
  }

  public static void EffectTitleListCreater(List<LordEquipEffectCompareSet> list)
  {
    for (int index = 0; index < list.Count; ++index)
    {
      for (int Index = 0; Index < DataManager.Instance.LordEquipEffectFilter.TableCount; ++Index)
      {
        LordEquipEffectFilterData recordByIndex = DataManager.Instance.LordEquipEffectFilter.GetRecordByIndex(Index);
        if ((int) list[index].EffectID == (int) recordByIndex.effectID)
          list[index].group = recordByIndex.effectType;
      }
    }
    list.Sort(new Comparison<LordEquipEffectCompareSet>(LordEquipData.EffectCompare));
    byte group = 0;
    for (int index = 0; index < list.Count; ++index)
    {
      if ((int) list[index].group > (int) group)
      {
        group = list[index].group;
        list.Insert(index, new LordEquipEffectCompareSet((ushort) 0, 0, false, group, true));
      }
    }
  }

  public static void effectListAddToEffectCompareList(
    List<LordEquipEffectSet> effList,
    List<LordEquipEffectCompareSet> list)
  {
    for (int index = 0; index < effList.Count; ++index)
      list.Add(new LordEquipEffectCompareSet(effList[index]));
  }

  public bool CheckItemEnough(Equip mEquip, byte mcolor)
  {
    if (!LordEquipData.MaterialDataReq || !LordEquipData.EqDataReq || mcolor > (byte) 1 && LordEquipData.getItemQuantity(mEquip.EquipKey, (byte) ((uint) mcolor - 1U)) <= (ushort) 0)
      return false;
    for (int index = 0; index < 4; ++index)
    {
      if (mEquip.SyntheticParts[index].SyntheticItem > (ushort) 0 && (int) LordEquipData.getItemQuantity(mEquip.SyntheticParts[index].SyntheticItem, mcolor) < (int) mEquip.SyntheticParts[index].SyntheticItemNum)
        return false;
    }
    return true;
  }

  public bool CheckMaterialEnough(ushort itemID, byte color, ushort number, bool AllColors)
  {
    if (!LordEquipData.MaterialDataReq)
      return false;
    if (!AllColors)
      return (int) LordEquipData.getItemQuantity(itemID, color) >= (int) number;
    if (!this.MatCountingCache)
      this.StartMaterialCache();
    int num;
    return this.MatValue.TryGetValue(itemID, out num) && (double) number * Math.Pow(4.0, (double) ((int) color - 1)) <= (double) num;
  }

  public bool CheckItemUpgradeReady(ItemLordEquip item)
  {
    if (!LordEquipData.MaterialDataReq || !LordEquipData.EqDataReq || item.ItemID == (ushort) 0)
      return false;
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(item.ItemID);
    if (item.Color >= (byte) 5 || (int) item.SerialNO == (int) DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO)
      return false;
    for (int index = 0; index < 4; ++index)
    {
      if (recordByKey.SyntheticParts != null && recordByKey.SyntheticParts[index].SyntheticItem > (ushort) 0 && !this.CheckMaterialEnough(recordByKey.SyntheticParts[index].SyntheticItem, (byte) ((uint) item.Color + 1U), (ushort) recordByKey.SyntheticParts[index].SyntheticItemNum, true))
        return false;
    }
    return true;
  }

  public void StartMaterialCache()
  {
    if (!LordEquipData.EqDataReq || !LordEquipData.MaterialDataReq || !this.EvoCountingReq)
      return;
    this.EvoCountingReq = false;
    this.MatCountingCache = true;
    if (this.MatValue != null)
      return;
    this.MatValue = new Dictionary<ushort, int>();
  }

  public void CountMat(ushort itemID)
  {
    if (!LordEquipData.MaterialDataReq || !this.MatCountingCache)
      return;
    this.MatValue.Remove(itemID);
    double num = 0.0;
    for (int index = 0; index < this.LEMaterial.Length; ++index)
    {
      if ((int) this.LEMaterial[index].ItemID == (int) itemID)
        num += (double) this.LEMaterial[index].Quantity * Math.Pow(4.0, (double) ((int) this.LEMaterial[index].Color - 1));
    }
    if (num <= 0.0)
      return;
    this.MatValue.Add(itemID, (int) num);
  }

  public void Scan_MaterialOrEquipIncreace()
  {
    if (this.isEquipEvoReady)
      return;
    this.ScanEquipUpdate();
  }

  public void ScanEquipUpdate()
  {
    if (!this.MatCountingCache)
      this.StartMaterialCache();
    this.isEquipEvoReady = false;
    for (int index = 0; index < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index)
    {
      if (this.CheckItemUpgradeReady(this.LordEquip[index]))
      {
        this.isEquipEvoReady = true;
        break;
      }
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Forge, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LordEquip, 0);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public bool isItemCombineReady(Equip itemData, byte mcolor)
  {
    if (!LordEquipData.MaterialDataReq || !LordEquipData.EqDataReq)
      return false;
    for (int index = 0; index < 4; ++index)
    {
      if (itemData.SyntheticParts[index].SyntheticItem > (ushort) 0 && (int) LordEquipData.getItemQuantity(itemData.SyntheticParts[index].SyntheticItem, mcolor) < (int) itemData.SyntheticParts[index].SyntheticItemNum)
        return false;
    }
    return mcolor <= (byte) 1 || LordEquipData.getItemQuantity(itemData.EquipKey, (byte) ((uint) mcolor - 1U)) > (ushort) 0;
  }

  public bool isItemCombineReady(ushort itemID, byte mcolor)
  {
    return LordEquipData.MaterialDataReq && LordEquipData.EqDataReq && this.isItemCombineReady(DataManager.Instance.EquipTable.GetRecordByKey(itemID), mcolor);
  }

  public void SetDictionary(bool Reset)
  {
    this.EquipDic.Clear();
    if (Reset)
      return;
    for (int index = 0; index < LordEquipData.RoleEquipSerial.Length; ++index)
    {
      if (LordEquipData.RoleEquipSerial[index] > 0U)
        this.EquipDic.Add(LordEquipData.RoleEquipSerial[index], index + 1);
    }
  }

  public static int ItemSort(ushort x, ushort y)
  {
    Equip recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(LordEquipData._instance.LordEquip[(int) x].ItemID);
    Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(LordEquipData._instance.LordEquip[(int) y].ItemID);
    if ((int) recordByKey1.EquipKind < (int) recordByKey2.EquipKind)
      return -1;
    if ((int) recordByKey1.EquipKind > (int) recordByKey2.EquipKind)
      return 1;
    bool flag1 = LordEquipData._instance.EquipDic.ContainsKey(LordEquipData._instance.LordEquip[(int) x].SerialNO);
    bool flag2 = LordEquipData._instance.EquipDic.ContainsKey(LordEquipData._instance.LordEquip[(int) y].SerialNO);
    if (flag1 && !flag2)
      return -1;
    if (flag2 && !flag1)
      return 1;
    if (flag1 && flag2)
    {
      int num1;
      LordEquipData._instance.EquipDic.TryGetValue(LordEquipData._instance.LordEquip[(int) x].SerialNO, out num1);
      int num2;
      LordEquipData._instance.EquipDic.TryGetValue(LordEquipData._instance.LordEquip[(int) y].SerialNO, out num2);
      if (num1 > num2)
        return 1;
      if (num1 < num2)
        return -1;
    }
    if ((int) recordByKey1.NeedLv < (int) recordByKey2.NeedLv)
      return 1;
    if ((int) recordByKey1.NeedLv > (int) recordByKey2.NeedLv)
      return -1;
    if ((int) LordEquipData._instance.LordEquip[(int) x].ItemID < (int) LordEquipData._instance.LordEquip[(int) y].ItemID)
      return 1;
    if ((int) LordEquipData._instance.LordEquip[(int) x].ItemID > (int) LordEquipData._instance.LordEquip[(int) y].ItemID)
      return -1;
    if ((int) LordEquipData._instance.LordEquip[(int) x].Color < (int) LordEquipData._instance.LordEquip[(int) y].Color)
      return 1;
    return (int) LordEquipData._instance.LordEquip[(int) x].Color > (int) LordEquipData._instance.LordEquip[(int) y].Color ? -1 : 0;
  }

  public static int GemSort(ushort x, ushort y)
  {
    if ((int) LordEquipData._instance.LEGem[(int) x].ItemID < (int) LordEquipData._instance.LEGem[(int) y].ItemID)
      return 1;
    if ((int) LordEquipData._instance.LEGem[(int) x].ItemID > (int) LordEquipData._instance.LEGem[(int) y].ItemID || (int) LordEquipData._instance.LEGem[(int) x].Color < (int) LordEquipData._instance.LEGem[(int) y].Color)
      return -1;
    return (int) LordEquipData._instance.LEGem[(int) x].Color > (int) LordEquipData._instance.LEGem[(int) y].Color ? 1 : 0;
  }

  public static int MatSort(ushort x, ushort y)
  {
    if ((int) LordEquipData._instance.LEMaterial[(int) x].ItemID < (int) LordEquipData._instance.LEMaterial[(int) y].ItemID)
      return 1;
    if ((int) LordEquipData._instance.LEMaterial[(int) x].ItemID > (int) LordEquipData._instance.LEMaterial[(int) y].ItemID || (int) LordEquipData._instance.LEMaterial[(int) x].Color < (int) LordEquipData._instance.LEMaterial[(int) y].Color)
      return -1;
    return (int) LordEquipData._instance.LEMaterial[(int) x].Color > (int) LordEquipData._instance.LEMaterial[(int) y].Color ? 1 : 0;
  }

  public static int timeSort(long x, long y)
  {
    if (x < y)
      return -1;
    return y > x ? 1 : 0;
  }

  public bool HaveEquipSpace()
  {
    bool flag = DataManager.Instance.RoleAttr.LordEquipEventData.ItemID != (ushort) 0;
    for (int index = 0; index < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index)
    {
      if (this.LordEquip[index].SerialNO == 0U)
      {
        if (!flag)
          return true;
        flag = false;
      }
    }
    return false;
  }

  public static bool OpenItemSource(ushort itemID)
  {
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(itemID);
    if (recordByKey.ActivitySuitIndex != (byte) 0)
    {
      if (MallManager.Instance.FindAndOpenMall((int) recordByKey.ActivitySuitIndex))
        return true;
      GUIManager.Instance.OpenItemKindFilterUI((ushort) 18, (byte) 1, recordByKey.ActivitySuitIndex);
    }
    else
      GUIManager.Instance.OpenItemKindFilterUI((ushort) 18, (byte) 1, (byte) 0);
    return true;
  }

  public static int CheckHaveEquipKind(byte Kind, bool CheckRole = true)
  {
    if (!LordEquipData.EqDataReq)
      return 0;
    bool flag = false;
    for (int index = 0; index < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index)
    {
      if (LordEquipData._instance.LordEquip[index].ItemID != (ushort) 0)
      {
        Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(LordEquipData._instance.LordEquip[index].ItemID);
        if ((int) recordByKey.EquipKind == (int) Kind && (!CheckRole || !LordEquipData._instance.isRoleEquipThis(LordEquipData._instance.LordEquip[index].SerialNO)))
        {
          flag = true;
          if ((int) LordEquipData._instance.LordEquip[index].SerialNO != (int) DataManager.Instance.RoleAttr.LordEquipEventData.SerialNO && (int) DataManager.Instance.RoleAttr.Level >= (int) recordByKey.NeedLv)
            return 1;
        }
      }
    }
    return flag ? 2 : 0;
  }

  public static void ResetLordEquipFont(UILEBtn lebtn)
  {
    if (!((Component) lebtn).gameObject.activeInHierarchy)
      return;
    if ((UnityEngine.Object) lebtn.Name != (UnityEngine.Object) null && ((Component) lebtn.Name).gameObject.activeInHierarchy)
    {
      ((Behaviour) lebtn.Name).enabled = false;
      ((Behaviour) lebtn.Name).enabled = true;
    }
    if ((UnityEngine.Object) lebtn.Quantity != (UnityEngine.Object) null && ((Component) lebtn.Quantity).gameObject.activeInHierarchy)
    {
      ((Behaviour) lebtn.Quantity).enabled = false;
      ((Behaviour) lebtn.Quantity).enabled = true;
    }
    if (!((UnityEngine.Object) lebtn.Level != (UnityEngine.Object) null) || !((Component) lebtn.Level).gameObject.activeInHierarchy)
      return;
    ((Behaviour) lebtn.Level).enabled = false;
    ((Behaviour) lebtn.Level).enabled = true;
  }

  public static void ResetLordEquipFont(Transform tf)
  {
    UILEBtn component = tf.GetComponent<UILEBtn>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null))
      return;
    LordEquipData.ResetLordEquipFont(component);
  }

  public void OpenForgeSet(ushort SetNo, byte Color)
  {
    int num = DataManager.Instance.ActivitylistEquip.BinarySearch(SetNo, (IComparer<ushort>) DataManager.Instance.mActSortItem);
    if (num >= 0)
    {
      this.ForgeActivity_mKind = (byte) (num + 1);
      this.ForgeActivity_mColor = Color;
    }
    else
    {
      num = 0;
      this.ForgeActivity_mKind = (byte) 1;
      this.ForgeActivity_mColor = Color;
    }
    this.ForgeActivity_KindScrollIdx = num;
    this.ForgeActivity_KindScroll_Y = (float) (79 * this.ForgeActivity_KindScrollIdx);
    if (DataManager.Instance.ActivitylistEquip.Count - this.ForgeActivity_KindScrollIdx < 5)
      this.ForgeActivity_KindScroll_Y = (float) (79 * (DataManager.Instance.ActivitylistEquip.Count - 5) + 32);
    Door menu = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.OpenMenu(EGUIWindow.UI_Forge_ActivityItem);
  }

  public void CheckQuickSets()
  {
    if (this.QuickSetSerialCheck || !LordEquipData.EqDataReq || this.LordEquipSetsCount < 1)
      return;
    this.QuickSetSerialCheck = true;
    for (int index1 = 0; index1 < this.LordEquipSetsCount; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        if (this.LordEquipSets[index1].SerialNO[index2] > 0U)
        {
          bool flag = false;
          for (int index3 = 0; index3 < (int) DataManager.Instance.RoleAttr.LordEquipBagSize; ++index3)
          {
            if ((int) this.LordEquip[index3].SerialNO == (int) this.LordEquipSets[index1].SerialNO[index2])
            {
              flag = true;
              break;
            }
          }
          if (!flag)
            this.LordEquipSets[index1].SerialNO[index2] = 0U;
        }
      }
    }
  }
}
