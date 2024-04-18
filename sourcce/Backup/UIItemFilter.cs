// Decompiled with JetBrains decompiler
// Type: UIItemFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIItemFilter : UIFilterBase
{
  private UIItemFilter._SubType SubType;
  private UIItemFilter.ItemFilterType Type;
  private ushort FilterItemID;
  private ushort NeedCount;
  private RectTransform ItemTrans;
  private UIText Title;
  private CString TitleStr;

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager instance = DataManager.Instance;
    base.OnOpen(arg1, arg2);
    this.ThisTransform = this.SetFunc(this.transform.GetChild(4));
    this.ThisTransform.gameObject.SetActive(true);
    this.Title = this.ThisTransform.GetComponent<UIText>();
    this.Title.font = GUIManager.Instance.GetTTFFont();
    this.AddRefreshText((Text) this.Title);
    this.ItemTrans = this.ThisTransform.GetChild(0).GetComponent<RectTransform>();
    if (arg1 == 0)
    {
      this.SubType = (UIItemFilter._SubType) arg2;
      this.Type = UIItemFilter.ItemFilterType.Experience;
      if (this.SubType == UIItemFilter._SubType.Pet || this.SubType == UIItemFilter._SubType.PetFormDetail)
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
      if (this.SubType == UIItemFilter._SubType.Hero)
      {
        this.Title.text = instance.mStringTable.GetStringByID(738U);
        this.MainText.text = instance.mStringTable.GetStringByID(737U);
        UIText component = ((Transform) this.MessageTrans).GetChild(0).GetComponent<UIText>();
        component.text = instance.mStringTable.GetStringByID(745U);
        this.MessageTrans.sizeDelta = this.MessageTrans.sizeDelta with
        {
          x = component.preferredWidth + 165f
        };
      }
      else
      {
        this.Title.text = instance.mStringTable.GetStringByID(16043U);
        this.MainText.text = instance.mStringTable.GetStringByID(16042U);
        UIText component = ((Transform) this.MessageTrans).GetChild(0).GetComponent<UIText>();
        component.text = instance.mStringTable.GetStringByID(744U);
        this.MessageTrans.sizeDelta = this.MessageTrans.sizeDelta with
        {
          x = component.preferredWidth + 165f
        };
      }
    }
    else
    {
      this.Type = UIItemFilter.ItemFilterType.ItemID;
      this.TitleStr = StringManager.Instance.SpawnString();
      this.MainText.text = instance.mStringTable.GetStringByID(785U);
      this.Title.text = instance.mStringTable.GetStringByID(785U);
      this.FilterItemID = (ushort) arg1;
      this.NeedCount = (ushort) arg2;
      if (!PetManager.Instance.IsPetItem(this.FilterItemID))
        return;
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
    }
  }

  public override void Init()
  {
    base.Init();
    this.ChangeItemType();
    if (this.Type == UIItemFilter.ItemFilterType.Experience)
      return;
    GUIManager.Instance.InitianHeroItemImg((Transform) this.ItemTrans, eHeroOrItem.Item, this.FilterItemID, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    ((Component) this.ItemTrans).gameObject.SetActive(true);
    this.UpdateNeedItemCount();
  }

  public override void OnClose()
  {
    base.OnClose();
    if (this.TitleStr == null)
      return;
    StringManager.Instance.DeSpawnString(this.TitleStr);
  }

  private void UpdateNeedItemCount()
  {
    if (this.Type == UIItemFilter.ItemFilterType.Experience)
      return;
    ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(this.FilterItemID, (byte) 0);
    this.TitleStr.ClearString();
    this.TitleStr.IntToFormat((long) curItemQuantity);
    this.TitleStr.IntToFormat((long) this.NeedCount);
    if (GUIManager.Instance.IsArabic)
    {
      if ((int) this.NeedCount > (int) curItemQuantity)
        this.TitleStr.AppendFormat("{1} / <color=#ff004fff>{0}</color>");
      else
        this.TitleStr.AppendFormat("{1} / {0}");
    }
    else if ((int) this.NeedCount > (int) curItemQuantity)
      this.TitleStr.AppendFormat("<color=#ff004fff>{0}</color> / {1}");
    else
      this.TitleStr.AppendFormat("{0} / {1}");
    this.Title.text = this.TitleStr.ToString();
    this.Title.SetAllDirty();
    this.Title.cachedTextGenerator.Invalidate();
    this.Title.cachedTextGeneratorForLayout.Invalidate();
    this.ItemTrans.anchoredPosition = this.ItemTrans.anchoredPosition with
    {
      x = (float) ((26.0 + (double) this.Title.preferredWidth * 0.5) * -1.0)
    };
  }

  private void ChangeItemType(bool bMoveTop = false)
  {
    DataManager instance = DataManager.Instance;
    Vector2 vector2 = Vector2.zero;
    if (this.SubType == UIItemFilter._SubType.Pet || this.SubType == UIItemFilter._SubType.PetFormDetail)
      PetManager.Instance.SortPetItemData();
    else
      instance.SortResourceFilterData();
    int itemidx = 0;
    this.FilterScrollRect.StopMovement();
    if (!bMoveTop)
    {
      vector2 = this.ScrollContent.anchoredPosition;
      itemidx = this.FilterScrollView.GetBeginIdx();
    }
    switch (this.Type)
    {
      case UIItemFilter.ItemFilterType.Experience:
        if (this.SubType == UIItemFilter._SubType.Hero)
        {
          this.SetItemData(instance.sortItemData, instance.sortItemDataStart[15], instance.sortItemDataCount[15], true, (byte) 0);
          break;
        }
        this.SetItemData(PetManager.Instance.PetItemData, instance.sortItemDataStart[5], instance.sortItemDataCount[5], true);
        this.ItemsHeight.Insert(0, 128f);
        this.ItemsData.Insert(0, (ushort) 0);
        break;
      case UIItemFilter.ItemFilterType.ItemID:
        this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[7], instance.SortSotreDataCount[7], true, (byte) 0);
        break;
    }
    this.UpdateScrollItemsCount();
    if (this.Type == UIItemFilter.ItemFilterType.Experience && this.SubType == UIItemFilter._SubType.PetFormDetail && this.ItemsData.Count == 1)
      ((Component) this.MessageTrans).gameObject.SetActive(true);
    if (bMoveTop)
      return;
    this.FilterScrollView.GoTo(itemidx, vector2.y);
  }

  public override bool CheckItemRule(ushort id)
  {
    if (this.Type == UIItemFilter.ItemFilterType.ItemID)
    {
      StoreTbl recordByKey = DataManager.Instance.StoreData.GetRecordByKey(id);
      return recordByKey.AddDiamondBuy != (byte) 0 && recordByKey.Filter != (byte) 2 && (int) recordByKey.ItemID == (int) this.FilterItemID;
    }
    if (this.Type != UIItemFilter.ItemFilterType.Experience || this.SubType != UIItemFilter._SubType.Pet && this.SubType != UIItemFilter._SubType.PetFormDetail)
      return true;
    ushort Index = 0;
    PetItem itemData = PetManager.Instance.FindItemData(id, ref Index);
    return itemData != null && (int) itemData.EquipKind - 1 == 5 && (itemData.PropertiesInfo[0].Propertieskey == (ushort) 5 || itemData.PropertiesInfo[0].Propertieskey == (ushort) 6);
  }

  public override void SendPack(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1002:
        if (this.SubType == UIItemFilter._SubType.PetFormDetail)
        {
          DataManager.Instance.UseItem((ushort) sender.m_BtnID2, (ushort) 1, (ushort) 0, PetManager.Instance.PetUI_UseItemPetID, (ushort) 0, 0U, string.Empty);
          break;
        }
        DataManager.Instance.UseItem((ushort) sender.m_BtnID2, (ushort) 1, (ushort) 0, (ushort) 0, (ushort) 0, 0U, string.Empty);
        break;
      case 1004:
        if (DataManager.Instance.GetCurItemQuantity((ushort) sender.m_BtnID2, (byte) 0) >= ushort.MaxValue)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(887U), (ushort) byte.MaxValue);
          break;
        }
        this.CheckBuy((byte) 1, (ushort) sender.m_BtnID3, (ushort) sender.m_BtnID2, win: GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), Parameter3: 0U);
        break;
      case 1005:
        GUIManager.Instance.BuildingData.ManorGuild((ushort) sender.m_BtnID2);
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu(true);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh_Item:
        this.UpdateNeedItemCount();
        this.ChangeItemType();
        break;
      case NetworkNews.Refresh_Pet:
        if (this.SubType != UIItemFilter._SubType.Pet && this.SubType != UIItemFilter._SubType.PetFormDetail)
          break;
        this.ChangeItemType();
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
    if (this.Type == UIItemFilter.ItemFilterType.Experience)
    {
      InKey = this.FilterItem[panelObjectIdx].KeyID;
      if (this.SubType == UIItemFilter._SubType.PetFormDetail && dataIdx == 0)
      {
        this.SetItemType(panelObjectIdx, UIFilterBase.eItemType.PetTraining);
        return;
      }
      this.SetItemType(panelObjectIdx, UIFilterBase.eItemType.Use);
    }
    else
    {
      StoreTbl recordByKey = instance.StoreData.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
      InKey = recordByKey.ItemID;
      x = recordByKey.Num;
      this.SetItemType(panelObjectIdx, UIFilterBase.eItemType.BuyAndUse);
      this.FilterItem[panelObjectIdx].BuyCaption.text = instance.mStringTable.GetStringByID(284U);
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

  private enum ItemFilterType
  {
    Experience,
    ItemID,
    ItemKind,
  }

  public enum _SubType
  {
    Hero,
    Pet,
    PetFormDetail,
  }
}
