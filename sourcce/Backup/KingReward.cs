// Decompiled with JetBrains decompiler
// Type: KingReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class KingReward
{
  public const byte ListMaxSize = 30;
  private List<KingGiftInfo> KingGiftListPool = new List<KingGiftInfo>();
  private int GiftDataCountIdx;
  private GiftData[] KingGift = new GiftData[40];
  private byte _WonderID;

  public byte WonderID
  {
    get => this._WonderID;
    set
    {
      this._WonderID = value;
      if ((int) this._WonderID >= this.KingGift.Length)
        this._WonderID = (byte) 0;
      this.CheckValid(this._WonderID);
    }
  }

  private void CheckValid(byte wonderID)
  {
    if ((int) wonderID >= this.KingGift.Length)
      wonderID = (byte) 0;
    if (this.KingGift[(int) wonderID] != null)
      return;
    this.KingGift[(int) wonderID] = new GiftData();
  }

  public KingGiftInfo GetKingGiftObj()
  {
    KingGiftInfo kingGiftObj = (KingGiftInfo) null;
    if (this.GiftDataCountIdx == this.KingGiftListPool.Count)
    {
      int count = this.KingGiftListPool.Count;
      for (byte index = 0; index < (byte) 10; ++index)
        this.KingGiftListPool.Insert(count + (int) index, new KingGiftInfo(count + (int) index));
    }
    int giftDataCountIdx = this.GiftDataCountIdx;
    for (int index1 = 0; index1 < this.KingGiftListPool.Count; ++index1)
    {
      int index2 = (index1 + giftDataCountIdx) % this.KingGiftListPool.Count;
      kingGiftObj = this.KingGiftListPool[index2];
      if (kingGiftObj != null)
      {
        this.KingGiftListPool[index2] = (KingGiftInfo) null;
        break;
      }
    }
    ++this.GiftDataCountIdx;
    return kingGiftObj;
  }

  public void ReleaseKingGiftObj(KingGiftInfo Data)
  {
    if (Data == null || this.GiftDataCountIdx == 0)
      return;
    --this.GiftDataCountIdx;
    this.KingGiftListPool[Data.DataIdx] = Data;
  }

  public List<KingGiftInfo> GetGiftList()
  {
    this.CheckValid(this.WonderID);
    return DataManager.MapDataController.FocusKingdomID == (ushort) 0 || (int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID ? this.KingGift[(int) this.WonderID].KingGiftList : this.KingGift[(int) this.WonderID].GustKingGiftList;
  }

  public void SetGiftList(ushort ItemID, CString Name, long UserID)
  {
    List<KingGiftInfo> giftList = this.GetGiftList();
    for (int index = 0; index < giftList.Count; ++index)
    {
      if ((int) giftList[index].ItemID == (int) ItemID)
      {
        giftList[index].List[(int) giftList[index].ListCount++].Set(DataManager.Instance.RoleAlliance.Tag, Name, UserID);
        if (DataManager.MapDataController.FocusKingdomID == (ushort) 0 || (int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
        {
          this.KingGift[(int) this.WonderID].KingGiftNum = (ushort) 0;
          break;
        }
        this.KingGift[(int) this.WonderID].GuetGiftnum = (ushort) 0;
        break;
      }
    }
  }

  public void Reset()
  {
    for (int index = 0; index < this.KingGift.Length; ++index)
    {
      if (this.KingGift[index] != null)
      {
        this.KingGift[index].GustKingdomID = (ushort) 0;
        this.KingGift[index].KingGiftNum = (ushort) 0;
        this.KingGift[index].GuetGiftnum = (ushort) 0;
      }
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 9, 2);
  }

  public void sendKingGiftInfo(byte wonderID = 0)
  {
    this.WonderID = wonderID;
    ushort data;
    MessagePacket messagePacket;
    if (DataManager.MapDataController.FocusKingdomID == (ushort) 0 || (int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
    {
      data = this.KingGift[(int) this.WonderID].KingGiftNum;
      messagePacket = new MessagePacket((ushort) 1024);
    }
    else
    {
      if ((int) DataManager.MapDataController.FocusKingdomID != (int) this.KingGift[(int) this.WonderID].GustKingdomID)
      {
        for (int index = 0; index < this.KingGift[(int) this.WonderID].GustKingGiftList.Count; ++index)
          this.ReleaseKingGiftObj(this.KingGift[(int) this.WonderID].GustKingGiftList[index]);
        this.KingGift[(int) this.WonderID].GustKingGiftList.Clear();
        this.KingGift[(int) this.WonderID].GustKingdomID = DataManager.MapDataController.FocusKingdomID;
        this.KingGift[(int) this.WonderID].GuetGiftnum = (ushort) 0;
      }
      data = this.KingGift[(int) this.WonderID].GuetGiftnum;
      messagePacket = MessagePacket.GetGuestMessagePack();
    }
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_KING_GIFT_INFO_PLUS;
    messagePacket.Add(data);
    messagePacket.Add(DataManager.Instance.RoleAttr.Name.ToString(), 13);
    messagePacket.Add(wonderID);
    messagePacket.Send();
  }

  public void RecvKingGiftInfo(MessagePacket MP)
  {
    ushort num1 = MP.ReadUShort();
    this.CheckValid(this.WonderID);
    List<KingGiftInfo> kingGiftInfoList;
    if (DataManager.MapDataController.FocusKingdomID == (ushort) 0 || (int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
    {
      if (this.KingGift[(int) this.WonderID].StartPos == (byte) 0 && (int) num1 == (int) this.KingGift[(int) this.WonderID].KingGiftNum)
        return;
      this.KingGift[(int) this.WonderID].KingGiftNum = num1;
      kingGiftInfoList = this.KingGift[(int) this.WonderID].KingGiftList;
    }
    else
    {
      if (this.KingGift[(int) this.WonderID].StartPos == (byte) 0 && (int) num1 == (int) this.KingGift[(int) this.WonderID].GuetGiftnum)
        return;
      this.KingGift[(int) this.WonderID].GuetGiftnum = num1;
      kingGiftInfoList = this.KingGift[(int) this.WonderID].GustKingGiftList;
    }
    byte num2 = MP.ReadByte();
    byte num3 = (byte) ((int) num2 >> 6 & 1);
    byte num4 = (byte) ((uint) num2 & 31U);
    byte num5 = (byte) ((int) num2 >> 5 & 1);
    if (this.KingGift[(int) this.WonderID].StartPos == (byte) 0 && num5 == (byte) 0)
    {
      for (int index = 0; index < kingGiftInfoList.Count; ++index)
        this.ReleaseKingGiftObj(kingGiftInfoList[index]);
      kingGiftInfoList.Clear();
    }
    CString cstring1 = StringManager.Instance.StaticString1024();
    CString cstring2 = StringManager.Instance.StaticString1024();
    for (byte index1 = 0; (int) index1 < (int) num4; ++index1)
    {
      KingGiftInfo kingGiftInfo = (KingGiftInfo) null;
      int num6 = -1;
      ushort num7 = MP.ReadUShort();
      if (num5 == (byte) 0)
      {
        kingGiftInfo = this.GetKingGiftObj();
      }
      else
      {
        for (int index2 = 0; index2 < kingGiftInfoList.Count; ++index2)
        {
          if ((int) kingGiftInfoList[index2].ItemID == (int) num7)
          {
            num6 = index2;
            kingGiftInfo = kingGiftInfoList[index2];
            break;
          }
        }
      }
      if (kingGiftInfo == null)
        kingGiftInfo = this.GetKingGiftObj();
      kingGiftInfo.ItemID = num7;
      kingGiftInfo.GiftCount = MP.ReadByte();
      byte num8;
      if (num5 == (byte) 0)
      {
        kingGiftInfo.ListCount = MP.ReadByte();
        num8 = kingGiftInfo.ListCount;
      }
      else
        num8 = MP.ReadByte();
      for (byte index3 = 0; (int) index3 < (int) num8; ++index3)
      {
        byte index4 = num5 != (byte) 0 ? (byte) ((uint) kingGiftInfo.ListCount + (uint) index3) : index3;
        MP.ReadStringPlus(3, cstring2);
        MP.ReadStringPlus(13, cstring1);
        if (num3 == (byte) 0)
          kingGiftInfo.List[(int) index4].Set(cstring2, cstring1, 0L);
        else
          kingGiftInfo.List[(int) index4].Set(cstring2, cstring1, MP.ReadLong());
      }
      if (num5 == (byte) 1)
        kingGiftInfo.ListCount += num8;
      if (num6 == -1)
        kingGiftInfoList.Add(kingGiftInfo);
    }
    if (((int) num2 >> 7 & 1) > 0)
    {
      this.KingGift[(int) this.WonderID].StartPos += num4;
    }
    else
    {
      this.KingGift[(int) this.WonderID].StartPos = (byte) 0;
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 9, 1);
    }
  }

  public void SendKingGift(long userid, ushort itemId, bool bIsKingOfWorld = false, bool bGuest = false)
  {
    GUIManager.Instance.ShowUILock(EUILock.KingGift);
    MessagePacket messagePacket = !bGuest ? new MessagePacket((ushort) 1024) : MessagePacket.GetGuestMessagePack();
    messagePacket.Protocol = !bIsKingOfWorld ? Protocol._MSG_REQUEST_KING_GIFT : Protocol._MSG_REQUEST_EMPEROR_GIFT;
    messagePacket.AddSeqId();
    messagePacket.Add(userid);
    messagePacket.Add(itemId);
    messagePacket.Send();
  }

  public void SendNobilityGift(long userid, ushort itemId, bool bGuest = false)
  {
    GUIManager.Instance.ShowUILock(EUILock.KingGift);
    MessagePacket messagePacket = !bGuest ? new MessagePacket((ushort) 1024) : MessagePacket.GetGuestMessagePack();
    messagePacket.Protocol = Protocol._MSG_REQUEST_FEDERAL_GIFT;
    messagePacket.AddSeqId();
    messagePacket.Add(this.WonderID);
    messagePacket.Add(userid);
    messagePacket.Add(itemId);
    messagePacket.Send();
  }

  public void RecvKingGift(MessagePacket MP)
  {
    CString cstring = StringManager.Instance.StaticString1024();
    GUIManager.Instance.HideUILock(EUILock.KingGift);
    byte num = MP.ReadByte();
    if (num == (byte) 0)
    {
      ushort ItemID = MP.ReadUShort();
      long UserID = MP.ReadLong();
      MP.ReadStringPlus(13, cstring);
      this.SetGiftList(ItemID, cstring, UserID);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_List, 3);
    }
    else
    {
      switch (num)
      {
        case 1:
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9718U), (ushort) byte.MaxValue);
          break;
        case 6:
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(744U), (ushort) byte.MaxValue);
          break;
      }
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_List, 4);
    }
  }

  public void RecvKingGiftRecived(MessagePacket MP)
  {
    ushort ItemID = MP.ReadUShort();
    ushort Quantity = MP.ReadUShort();
    DataManager.Instance.SetCurItemQuantity(ItemID, Quantity, (byte) 0, 0L);
    this.SetGiftList(ItemID, DataManager.Instance.RoleAttr.Name, 0L);
    GameManager.OnRefresh(NetworkNews.Refresh_Item);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 9, 1);
  }
}
