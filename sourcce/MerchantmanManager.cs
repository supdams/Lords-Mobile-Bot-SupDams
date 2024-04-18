// Decompiled with JetBrains decompiler
// Type: MerchantmanManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class MerchantmanManager
{
  private static MerchantmanManager instance;
  public BlackMarketTradeData[] MerchantmanData = new BlackMarketTradeData[4];
  public byte TradeLocks;
  public byte TradeStatus;
  public byte ExtraData;
  public BlackMarketExtraTradeData MerchantmanExtraData = new BlackMarketExtraTradeData((byte) 0);
  public byte SendCheckBuy;
  public bool bLockBuy;
  public bool bNeedUpDateExtra;
  public uint ExtraTreasureID;

  private MerchantmanManager()
  {
  }

  public static MerchantmanManager Instance
  {
    get
    {
      if (MerchantmanManager.instance == null)
        MerchantmanManager.instance = new MerchantmanManager();
      return MerchantmanManager.instance;
    }
  }

  public void SendReQusetBlackMarket_Data()
  {
    GUIManager.Instance.ShowUILock(EUILock.BlackMarket);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUSET_BLACKMARKET_DATA;
    messagePacket.AddSeqId();
    messagePacket.Add((byte) 1);
    messagePacket.Send();
  }

  public void RecvBlackMarket_Data(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.BlackMarket);
    MP.ReadLong();
    this.TradeLocks = MP.ReadByte();
    this.TradeStatus = MP.ReadByte();
    for (int index = 0; index < 4; ++index)
    {
      this.MerchantmanData[index].itemID = MP.ReadUShort();
      this.MerchantmanData[index].itemCount = MP.ReadUShort();
      this.MerchantmanData[index].ResourceKind = MP.ReadByte();
      this.MerchantmanData[index].ResourceCount = MP.ReadUInt();
      this.MerchantmanData[index].Rare = MP.ReadByte();
    }
    this.ExtraData = MP.ReadByte();
    this.ExtraTreasureID = MallManager.Instance.TreasureIDTransToNew(MP.ReadUInt());
    if (this.ExtraData == (byte) 1)
      return;
    this.ClearSendCheckBuy();
    this.bNeedUpDateExtra = false;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_OpenBox, 3);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public void SendReQusetBlackMarket_Lock(byte mlock)
  {
    GUIManager.Instance.ShowUILock(EUILock.BlackMarket);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_BLACKMARKET_LOCK;
    messagePacket.AddSeqId();
    messagePacket.Add(mlock);
    messagePacket.Send();
  }

  public void RecvBlackMarket_Lock(MessagePacket MP)
  {
    this.TradeLocks = MP.ReadByte();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 3);
    GUIManager.Instance.HideUILock(EUILock.BlackMarket);
  }

  public void SendReQusetBlackMarket_Buy(byte mIdx, bool checkPay = true, bool bPay = false)
  {
    GUIManager.Instance.ShowUILock(EUILock.BlackMarket);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_BLACKMARKET_BUY;
    messagePacket.AddSeqId();
    messagePacket.Add(mIdx);
    messagePacket.Send();
  }

  public void RecvBlackMarket_Buy(MessagePacket MP)
  {
    switch (MP.ReadByte())
    {
      case 0:
        byte num1 = MP.ReadByte();
        byte num2 = (byte) ((uint) num1 - (uint) this.TradeStatus);
        for (int index = 0; index < 4; ++index)
        {
          if (((int) num2 >> index & 1) == 1)
          {
            int num3 = (int) MP.ReadUShort();
            int num4 = (int) MP.ReadUShort();
            DataManager.Instance.Resource[(int) (byte) Mathf.Clamp((int) MP.ReadByte(), 0, DataManager.Instance.Resource.Length - 1)].Stock = MP.ReadUInt();
            this.TradeStatus = num1;
          }
        }
        GameManager.OnRefresh(NetworkNews.Refresh_Resource);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 2);
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1500U), (ushort) 18);
        GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
        AudioManager.Instance.PlayUISFX(UIKind.ItemUse);
        FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_CARGO_SHIP_EXCHANGE);
        break;
      case 1:
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 4);
        break;
      case 2:
        this.MerchantmanExtraData.LocksBought = MP.ReadByte();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 1);
        this.SendCheckBuy = (byte) 1;
        IGGSDKPlugin.BuyProduct(MallManager.Instance.SmallID.ToString(), (int) DataManager.MapDataController.kingdomData.kingdomID);
        break;
      case 3:
        AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
        AudioManager.Instance.PlayUISFX(UIKind.ItemUse);
        this.MerchantmanExtraData.LocksBought = MP.ReadByte();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 1);
        this.ClearSendCheckBuy();
        FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_CARGO_SHIP_EXCHANGE);
        break;
      case 4:
        this.MerchantmanExtraData.LocksBought = MP.ReadByte();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 1);
        break;
    }
    GUIManager.Instance.HideUILock(EUILock.BlackMarket);
  }

  public void RecvExtraTrade(MessagePacket MP)
  {
    bool flag = false;
    if (this.ExtraData == (byte) 0)
      flag = true;
    this.bNeedUpDateExtra = false;
    this.ExtraData = (byte) 1;
    this.MerchantmanExtraData.TradePos = MP.ReadByte();
    this.MerchantmanExtraData.LocksBought = MP.ReadByte();
    this.MerchantmanExtraData.itemID = MP.ReadUShort();
    this.MerchantmanExtraData.Discount = MP.ReadByte();
    if (this.MerchantmanExtraData.Discount > (byte) 3)
      this.MerchantmanExtraData.Discount = (byte) 3;
    this.MerchantmanExtraData.DataLen = MP.ReadByte();
    if (this.MerchantmanExtraData.DataLen > (byte) 200)
      this.MerchantmanExtraData.DataLen = (byte) 0;
    for (int index = 0; index < (int) this.MerchantmanExtraData.DataLen; ++index)
    {
      this.MerchantmanExtraData.ItemContain[index].ItemID = MP.ReadUShort();
      this.MerchantmanExtraData.ItemContain[index].Num = MP.ReadUShort();
      this.MerchantmanExtraData.ItemContain[index].ItemRank = MP.ReadByte();
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 1);
    if (flag)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 5);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_OpenBox, 2);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
    GUIManager.Instance.HideUILock(EUILock.BlackMarket);
  }

  public void RecvExtraChange(MessagePacket MP)
  {
    if (this.ExtraData != (byte) 1)
      return;
    this.bNeedUpDateExtra = true;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_OpenBox, 1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Merchantman, 6);
  }

  public void SendReQusetBlackMarket_ExtraLock(byte block)
  {
    GUIManager.Instance.ShowUILock(EUILock.BlackMarket);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_BLACKMARKET_EXTRA_LOCK;
    messagePacket.AddSeqId();
    messagePacket.Add(block);
    messagePacket.Send();
  }

  public bool CheckbWaitBuy(bool bShowMessage = false)
  {
    if (!this.bLockBuy)
      return false;
    if (bShowMessage)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(656U), (ushort) byte.MaxValue);
    return true;
  }

  public void ClearSendCheckBuy()
  {
    this.SendCheckBuy = (byte) 0;
    this.bLockBuy = false;
  }

  ~MerchantmanManager()
  {
  }
}
