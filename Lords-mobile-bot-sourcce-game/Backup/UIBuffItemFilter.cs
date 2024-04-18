// Decompiled with JetBrains decompiler
// Type: UIBuffItemFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIBuffItemFilter : UIFilterBase
{
  private ushort ItemKind;
  private ushort PropKey;
  private int BagCount;
  private UIText Title;
  private CString TitleStr;
  private UIButton Sender;

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager instance = DataManager.Instance;
    this.TitleStr = StringManager.Instance.SpawnString(200);
    base.OnOpen(arg1, arg2);
    this.ThisTransform = this.SetFunc(this.transform.GetChild(4));
    this.ThisTransform.gameObject.SetActive(true);
    this.MainText.text = instance.mStringTable.GetStringByID(6093U);
    this.Title = this.ThisTransform.GetChild(1).GetComponent<UIText>();
    this.Title.font = GUIManager.Instance.GetTTFFont();
    ((Component) this.Title).gameObject.SetActive(true);
    if (GUIManager.Instance.IsArabic)
      ((Transform) ((Graphic) this.Title).rectTransform).localRotation = new Quaternion(0.0f, 180f, 0.0f, 0.0f);
    this.AddRefreshText((Text) this.Title);
    ItemBuff recordByIndex = instance.ItemBuffTable.GetRecordByIndex(arg2);
    Equip recordByKey = instance.EquipTable.GetRecordByKey(recordByIndex.BuffItemID);
    this.ItemKind = (ushort) recordByKey.EquipKind;
    this.PropKey = recordByKey.PropertiesInfo[0].Propertieskey;
    this.Title.text = instance.mStringTable.GetStringByID((uint) recordByIndex.BuffTipID);
  }

  public override void Init()
  {
    base.Init();
    this.ChangeItemType();
  }

  public override void OnClose()
  {
    base.OnClose();
    StringManager.Instance.DeSpawnString(this.TitleStr);
  }

  private void ChangeItemType(bool bMoveTop = false)
  {
    if (this.ItemKind == (ushort) 0)
      return;
    DataManager instance = DataManager.Instance;
    Vector2 vector2 = Vector2.zero;
    instance.SortResourceFilterData();
    int itemidx = 0;
    instance.SortCurItemDataForBag();
    instance.SortStoreData();
    this.BagCount = -1;
    this.FilterScrollRect.StopMovement();
    if (!bMoveTop)
    {
      vector2 = this.ScrollContent.anchoredPosition;
      itemidx = this.FilterScrollView.GetBeginIdx();
    }
    this.SetItemData(instance.sortItemData, instance.sortItemDataStart[(int) this.ItemKind - 1], instance.sortItemDataCount[(int) this.ItemKind - 1], true, (byte) 0);
    this.BagCount = this.ItemsHeight.Count;
    this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[(int) this.ItemKind], instance.SortSotreDataCount[(int) this.ItemKind], sort: (byte) 0);
    this.UpdateScrollItemsCount();
    if (bMoveTop)
      return;
    this.FilterScrollView.GoTo(itemidx, vector2.y);
  }

  public override bool CheckItemRule(ushort id)
  {
    Equip recordByKey1;
    if (this.BagCount == -1)
    {
      recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(id);
    }
    else
    {
      StoreTbl recordByKey2 = DataManager.Instance.StoreData.GetRecordByKey(id);
      if (recordByKey2.AddDiamondBuy == (byte) 0 || recordByKey2.Filter == (byte) 2 || DataManager.Instance.GetCurItemQuantity(recordByKey2.ItemID, (byte) 0) > (ushort) 0)
        return false;
      recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
    }
    return (int) recordByKey1.PropertiesInfo[0].Propertieskey == (int) this.PropKey;
  }

  public override void SendPack(UIButton sender)
  {
    this.Sender = sender;
    if (this.Sender.m_BtnID1 == 1004)
    {
      DataManager instance = DataManager.Instance;
      if (instance.StoreData.GetRecordByKey((ushort) this.Sender.m_BtnID3).Price > instance.RoleAttr.Diamond)
        GUIManager.Instance.OpenMessageBox(instance.mStringTable.GetStringByID(3966U), instance.mStringTable.GetStringByID(646U), 4, instance.mStringTable.GetStringByID(4507U), bCloseIDSet: true);
      else
        this.CheckMessage((ushort) this.Sender.m_BtnID2);
    }
    else
      this.CheckMessage((ushort) this.Sender.m_BtnID2);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (this.Sender.m_BtnID1)
    {
      case 1002:
        DataManager.Instance.UseItem((ushort) this.Sender.m_BtnID2, (ushort) 1, (ushort) 0, (ushort) 0, (ushort) 0, 0U, string.Empty);
        break;
      case 1004:
        this.CheckBuy((byte) 1, (ushort) this.Sender.m_BtnID3, (ushort) this.Sender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), Parameter3: 0U);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.ChangeItemType();
        break;
      case NetworkNews.Refresh_Item:
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((Object) menu != (Object) null))
          break;
        menu.CloseMenu();
        break;
    }
  }

  public override void UpDateRowItem(
    GameObject item,
    int dataIdx,
    int panelObjectIdx,
    int panelId)
  {
    base.UpDateRowItem(item, dataIdx, panelObjectIdx, panelId);
    if (this.ItemsData.Count <= dataIdx)
      return;
    DataManager instance = DataManager.Instance;
    this.FilterItem[panelObjectIdx].KeyID = this.ItemsData[dataIdx];
    ushort x = 1;
    ushort InKey;
    if (this.BagCount > dataIdx)
    {
      InKey = this.FilterItem[panelObjectIdx].KeyID;
      this.SetItemType(panelObjectIdx, UIFilterBase.eItemType.Use);
    }
    else
    {
      StoreTbl recordByKey = instance.StoreData.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
      InKey = recordByKey.ItemID;
      x = recordByKey.Num;
      this.SetItemType(panelObjectIdx, UIFilterBase.eItemType.BuyAndUse);
      this.FilterItem[panelObjectIdx].BuyPriceStr.ClearString();
      this.FilterItem[panelObjectIdx].BuyPriceStr.IntToFormat((long) recordByKey.Price, bNumber: true);
      this.FilterItem[panelObjectIdx].BuyPriceStr.AppendFormat("{0}");
      this.FilterItem[panelObjectIdx].BuyPrice.text = this.FilterItem[panelObjectIdx].BuyPriceStr.ToString();
      this.FilterItem[panelObjectIdx].BuyPrice.SetAllDirty();
      this.FilterItem[panelObjectIdx].BuyPrice.cachedTextGenerator.Invalidate();
      this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID3 = (int) recordByKey.ID;
    }
    Equip recordByKey1 = instance.EquipTable.GetRecordByKey(InKey);
    ushort curItemQuantity = instance.GetCurItemQuantity(recordByKey1.EquipKey, (byte) 0);
    ((Component) this.FilterItem[panelObjectIdx].AutouseBtnTrans).gameObject.SetActive(false);
    GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[panelObjectIdx].ItemTrans, eHeroOrItem.Item, recordByKey1.EquipKey, (byte) 0, (byte) 0);
    if (x == (ushort) 1)
    {
      this.FilterItem[panelObjectIdx].Name.text = instance.mStringTable.GetStringByID((uint) recordByKey1.EquipName);
    }
    else
    {
      this.FilterItem[panelObjectIdx].NameStr.ClearString();
      this.FilterItem[panelObjectIdx].NameStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
      this.FilterItem[panelObjectIdx].NameStr.IntToFormat((long) x);
      this.FilterItem[panelObjectIdx].NameStr.AppendFormat("{0} x {1}");
      this.FilterItem[panelObjectIdx].Name.text = this.FilterItem[panelObjectIdx].NameStr.ToString();
      this.FilterItem[panelObjectIdx].Name.SetAllDirty();
      this.FilterItem[panelObjectIdx].Name.cachedTextGenerator.Invalidate();
    }
    this.FilterItem[panelObjectIdx].Content.text = instance.mStringTable.GetStringByID((uint) recordByKey1.EquipInfo);
    this.FilterItem[panelObjectIdx].OwnerStr.ClearString();
    this.FilterItem[panelObjectIdx].OwnerStr.StringToFormat(this.OwnerStr);
    this.FilterItem[panelObjectIdx].OwnerStr.IntToFormat((long) curItemQuantity, bNumber: true);
    this.FilterItem[panelObjectIdx].OwnerStr.AppendFormat("{0}{1}");
    this.FilterItem[panelObjectIdx].Owner.text = this.FilterItem[panelObjectIdx].OwnerStr.ToString();
    this.FilterItem[panelObjectIdx].Owner.SetAllDirty();
    this.FilterItem[panelObjectIdx].Owner.cachedTextGenerator.Invalidate();
    this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = (int) recordByKey1.EquipKey;
  }
}
