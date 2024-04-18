// Decompiled with JetBrains decompiler
// Type: UIResourceFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIResourceFilter : UIFilterBase
{
  private UIText[] ResourceText = new UIText[5];
  private CString[] ResourceStr;
  private Color TabTextColor;
  private float DeltaTime;
  private byte CastleLv;
  private UIResourceFilter.ClickType CurFilterTag;
  private UIResourceFilter.ResourceFilterType Type;
  protected int BagCount;
  private CanvasGroup[] ResourceTag = new CanvasGroup[5];
  private UIText ResourceNum;
  private Image SingleResourceImg;
  private Sprite SingleResource;
  private int RequireResource;
  private uint CurResource;
  private UIResourceFilter._TageSave[] TageSave = new UIResourceFilter._TageSave[6];
  private byte bFirstInit;
  private byte BuyAndUse;

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    this.CurFilterTag = UIResourceFilter.ClickType.None;
    base.OnOpen(arg1, arg2);
    this.ThisTransform = this.SetFunc(this.transform.GetChild(2));
    Font ttfFont = instance2.GetTTFFont();
    this.CastleLv = instance2.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level;
    this.ThisTransform.gameObject.SetActive(true);
    this.CurFilterTag = UIResourceFilter.ClickType.Grain;
    if (arg1 >= 5)
    {
      this.ResourceStr = new CString[1];
      this.ResourceStr[0] = StringManager.Instance.SpawnString(100);
      this.Type = UIResourceFilter.ResourceFilterType.Single;
      this.RequireResource = arg2;
      this.ThisTransform.GetChild(0).gameObject.SetActive(false);
      this.ResourceNum = this.ThisTransform.GetChild(1).GetComponent<UIText>();
      this.ResourceNum.font = ttfFont;
      this.AddRefreshText((Text) this.ResourceNum);
      this.SingleResourceImg = this.ThisTransform.GetChild(1).GetChild(0).GetComponent<Image>();
      Door menu = instance2.FindMenu(EGUIWindow.Door) as Door;
      if ((Object) menu != (Object) null)
      {
        switch (arg1)
        {
          case 5:
            this.SingleResource = menu.LoadSprite("UI_main_res_food");
            this.MainText.text = instance1.mStringTable.GetStringByID(299U);
            break;
          case 6:
            this.SingleResource = menu.LoadSprite("UI_main_res_stone");
            this.MainText.text = instance1.mStringTable.GetStringByID(300U);
            break;
          case 7:
            this.SingleResource = menu.LoadSprite("UI_main_res_wood");
            this.MainText.text = instance1.mStringTable.GetStringByID(301U);
            break;
          case 8:
            this.SingleResource = menu.LoadSprite("UI_main_res_iron");
            this.MainText.text = instance1.mStringTable.GetStringByID(302U);
            break;
          case 9:
            this.SingleResource = menu.LoadSprite("UI_main_money_01");
            this.MainText.text = instance1.mStringTable.GetStringByID(303U);
            break;
          case 10:
            this.SingleResource = menu.LoadSprite("UI_main_Force");
            this.MainText.text = instance1.mStringTable.GetStringByID(14670U);
            instance2.UpdateUI(EGUIWindow.Door, 1, 4);
            break;
        }
        this.SingleResourceImg.sprite = this.SingleResource;
        ((MaskableGraphic) this.SingleResourceImg).material = menu.LoadMaterial();
      }
      this.CurFilterTag = (UIResourceFilter.ClickType) (arg1 - 5);
    }
    else
    {
      this.ThisTransform.GetChild(1).gameObject.SetActive(false);
      this.MainText.text = instance1.mStringTable.GetStringByID(287U);
      this.Type = UIResourceFilter.ResourceFilterType.Mutile;
      int childCount = this.ThisTransform.GetChild(0).childCount;
      this.ResourceStr = new CString[childCount];
      for (int index = 0; index < childCount; ++index)
      {
        this.ResourceStr[index] = StringManager.Instance.SpawnString();
        this.ResourceTag[index] = this.ThisTransform.GetChild(0).GetChild(index).GetChild(0).GetComponent<CanvasGroup>();
        UIButton component = this.ThisTransform.GetChild(0).GetChild(index).GetComponent<UIButton>();
        component.m_Handler = (IUIButtonClickHandler) this;
        component.m_BtnID1 = 0 + index;
        this.ResourceText[index] = this.ThisTransform.GetChild(0).GetChild(index).GetChild(2).GetComponent<UIText>();
        this.ResourceText[index].font = ttfFont;
        this.AddRefreshText((Text) this.ResourceText[index]);
      }
      this.TabTextColor = ((Graphic) this.ResourceText[0]).color;
      this.CurFilterTag = arg2 != 0 ? (UIResourceFilter.ClickType) instance2.ResourceFilterSaved[36] : (UIResourceFilter.ClickType) arg1;
    }
    for (int index = 0; index < this.TageSave.Length; ++index)
    {
      this.TageSave[index].BeginIndex = GameConstants.ConvertBytesToUShort(instance2.ResourceFilterSaved, index * 6);
      this.TageSave[index].Position = GameConstants.ConvertBytesToFloat(instance2.ResourceFilterSaved, index * 6 + 2);
    }
    this.SortObj.SetActive(true);
  }

  public override void OnClose()
  {
    base.OnClose();
    for (int index = 0; index < this.ResourceStr.Length; ++index)
      StringManager.Instance.DeSpawnString(this.ResourceStr[index]);
    if ((Object) this.FilterScrollView != (Object) null)
      this.SaveCurScrollPosition();
    for (int index = 0; index < this.TageSave.Length; ++index)
    {
      GameConstants.GetBytes(this.TageSave[index].BeginIndex, GUIManager.Instance.ResourceFilterSaved, index * 6);
      GameConstants.GetBytes(this.TageSave[index].Position, GUIManager.Instance.ResourceFilterSaved, index * 6 + 2);
    }
    GUIManager.Instance.ResourceFilterSaved[36] = (byte) this.CurFilterTag;
    if (this.Type != UIResourceFilter.ResourceFilterType.Mutile)
      return;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((Object) menu != (Object) null) || menu.m_WindowStack.Count <= 0)
      return;
    GUIWindowStackData mWindow = menu.m_WindowStack[menu.m_WindowStack.Count - 1] with
    {
      m_Arg2 = 1
    };
    menu.m_WindowStack[menu.m_WindowStack.Count - 1] = mWindow;
  }

  public override void Init()
  {
    base.Init();
    this.ChangeFilterType(this.CurFilterTag, true);
    this.UpdateResourceData();
    this.bFirstInit = (byte) 1;
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).GoToGroup(-1, (byte) 0);
  }

  public override void OnButtonClick(UIButton sender)
  {
    if ((Object) this.FilterScrollRect == (Object) null)
      return;
    this.BuyAndUse = (byte) 0;
    switch (sender.m_BtnID1)
    {
      case 0:
        this.ChangeFilterType(UIResourceFilter.ClickType.Grain);
        break;
      case 1:
        this.ChangeFilterType(UIResourceFilter.ClickType.Rock);
        break;
      case 2:
        this.ChangeFilterType(UIResourceFilter.ClickType.Wood);
        break;
      case 3:
        this.ChangeFilterType(UIResourceFilter.ClickType.Steel);
        break;
      case 4:
        this.ChangeFilterType(UIResourceFilter.ClickType.Money);
        break;
      default:
        this.SaveCurScrollPosition();
        base.OnButtonClick(sender);
        if (this.Type != UIResourceFilter.ResourceFilterType.Single || sender.m_BtnID1 != 1003)
          break;
        ((GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter) as UIBagFilter).ActivateWindow as NumberConfirm).SetNeedItemQty(this.CurResource, (uint) this.RequireResource);
        break;
    }
  }

  private void ChangeFilterType(UIResourceFilter.ClickType FilterType, bool bForceUpdate = false)
  {
    if (!bForceUpdate && this.CurFilterTag == FilterType)
      return;
    if (this.Type == UIResourceFilter.ResourceFilterType.Mutile)
    {
      if (this.bFirstInit == (byte) 1)
        this.SaveCurScrollPosition();
      ((Graphic) this.ResourceText[(int) (byte) this.CurFilterTag]).color = this.TabTextColor;
      this.ResourceTag[(int) (byte) this.CurFilterTag].alpha = 0.0f;
      this.CurFilterTag = FilterType;
      ((Graphic) this.ResourceText[(int) (byte) this.CurFilterTag]).color = Color.white;
    }
    else
    {
      ((Component) this.SingleResourceImg).gameObject.SetActive(true);
      this.CurFilterTag = FilterType;
    }
    DataManager instance = DataManager.Instance;
    this.BagCount = -1;
    instance.SortResourceFilterData();
    int sortbeginIdx1 = 0;
    switch (this.CurFilterTag)
    {
      case UIResourceFilter.ClickType.Grain:
        this.SetItemData(instance.sortItemData, instance.sortItemDataStart[1], instance.sortItemDataCount[1], true, this.SortType, sortbeginIdx1);
        this.BagCount = this.ItemsHeight.Count;
        int sortbeginIdx2 = sortbeginIdx1 + this.BagCount;
        this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[1], instance.SortSotreDataCount[1], sort: this.SortType, sortbeginIdx: sortbeginIdx2);
        break;
      case UIResourceFilter.ClickType.Rock:
        this.SetItemData(instance.sortItemData, instance.sortItemDataStart[2], instance.sortItemDataCount[2], true, this.SortType, sortbeginIdx1);
        this.BagCount = this.ItemsHeight.Count;
        int sortbeginIdx3 = sortbeginIdx1 + this.BagCount;
        this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[2], instance.SortSotreDataCount[2], sort: this.SortType, sortbeginIdx: sortbeginIdx3);
        break;
      case UIResourceFilter.ClickType.Wood:
        this.SetItemData(instance.sortItemData, instance.sortItemDataStart[3], instance.sortItemDataCount[3], true, this.SortType, sortbeginIdx1);
        this.BagCount = this.ItemsHeight.Count;
        int sortbeginIdx4 = sortbeginIdx1 + this.BagCount;
        this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[3], instance.SortSotreDataCount[3], sort: this.SortType, sortbeginIdx: sortbeginIdx4);
        break;
      case UIResourceFilter.ClickType.Steel:
        this.SetItemData(instance.sortItemData, instance.sortItemDataStart[4], instance.sortItemDataCount[4], true, this.SortType, sortbeginIdx1);
        this.BagCount = this.ItemsHeight.Count;
        int sortbeginIdx5 = sortbeginIdx1 + this.BagCount;
        this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[4], instance.SortSotreDataCount[4], sort: this.SortType, sortbeginIdx: sortbeginIdx5);
        break;
      case UIResourceFilter.ClickType.Money:
        this.SetItemData(instance.sortItemData, instance.sortItemDataStart[5], instance.sortItemDataCount[5], true, this.SortType, sortbeginIdx1);
        this.BagCount = this.ItemsHeight.Count;
        int sortbeginIdx6 = sortbeginIdx1 + this.BagCount;
        this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[5], instance.SortSotreDataCount[5], sort: this.SortType, sortbeginIdx: sortbeginIdx6);
        break;
      case UIResourceFilter.ClickType.PetResource:
        this.SetItemData(instance.sortItemData, instance.sortItemDataStart[8], instance.sortItemDataCount[8], true, this.SortType, sortbeginIdx1);
        this.BagCount = this.ItemsHeight.Count;
        int sortbeginIdx7 = sortbeginIdx1 + this.BagCount;
        this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[8], instance.SortSotreDataCount[8], sort: this.SortType, sortbeginIdx: sortbeginIdx7);
        break;
    }
    if (this.CastleLv < (byte) 9 && ((long) instance.RoleAttr.Guide & 32L) != 0L && this.CurFilterTag != UIResourceFilter.ClickType.PetResource)
    {
      ++this.BagCount;
      this.ItemsHeight.Insert(0, 109f);
      this.ItemsData.Insert(0, (ushort) 0);
      this.UpdateScrollItemsCount();
      if (this.ItemsData.Count == 1)
        ((Component) this.MessageTrans).gameObject.SetActive(true);
    }
    else
      this.UpdateScrollItemsCount();
    this.FilterScrollRect.StopMovement();
    this.FilterScrollView.GoTo((int) this.TageSave[(int) this.CurFilterTag].BeginIndex, this.TageSave[(int) this.CurFilterTag].Position);
  }

  private void SaveCurScrollPosition()
  {
    this.TageSave[(int) this.CurFilterTag].BeginIndex = (ushort) this.FilterScrollView.GetBeginIdx();
    this.TageSave[(int) this.CurFilterTag].Position = this.ScrollContent.anchoredPosition.y;
  }

  public override bool CheckItemRule(ushort id)
  {
    DataManager instance = DataManager.Instance;
    if (this.BagCount == -1)
      return instance.GetCurItemQuantity(id, (byte) 0) != (ushort) 0;
    StoreTbl recordByKey = instance.StoreData.GetRecordByKey(id);
    return recordByKey.AddDiamondBuy != (byte) 0 && recordByKey.Filter != (byte) 2 && instance.GetCurItemQuantity(recordByKey.ItemID, (byte) 0) <= (ushort) 0;
  }

  public override void SendPack(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1002:
        this.BuyAndUse = (byte) 0;
        DataManager.Instance.UseItem((ushort) sender.m_BtnID2, (ushort) 1, (ushort) 0, (ushort) 0, (ushort) 0, 0U, string.Empty);
        break;
      case 1003:
        Debug.Log((object) "FilterBaseClickType.AutoUse");
        break;
      case 1004:
        this.BuyAndUse = (byte) 1;
        this.CheckBuy((byte) 1, (ushort) sender.m_BtnID3, (ushort) sender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), Parameter3: 0U);
        break;
      case 1005:
        if ((GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).m_eMapMode == EUIOriginMapMode.OriginMap)
        {
          if (NewbieManager.CheckRename())
            break;
          StringTable mStringTable = DataManager.Instance.mStringTable;
          GUIManager.Instance.OpenOKCancelBox(GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), mStringTable.GetStringByID(614U), mStringTable.GetStringByID(14595U), YesText: mStringTable.GetStringByID(3968U));
          break;
        }
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14580U), (ushort) byte.MaxValue);
        break;
      case 1006:
        this.ChangeFilterType(this.CurFilterTag, true);
        break;
    }
  }

  public override void UpdateUI(int arge1, int arge2)
  {
    base.UpdateUI(arge1, arge2);
    if (arge1 != 0)
      return;
    this.UpdateResourceData();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.ChangeFilterType(this.CurFilterTag, true);
        break;
      case NetworkNews.Refresh_Item:
        if (this.BuyAndUse != (byte) 0)
          break;
        this.ChangeFilterType(this.CurFilterTag, true);
        break;
      case NetworkNews.Refresh_Resource:
      case NetworkNews.Refresh_PetResource:
        this.UpdateResourceData();
        break;
      case NetworkNews.Refresh_BuildBase:
        byte level = GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level;
        if ((int) level == (int) this.CastleLv)
          break;
        this.CastleLv = level;
        this.ChangeFilterType(this.CurFilterTag, true);
        break;
    }
  }

  public void UpdateResourceData()
  {
    DataManager instance = DataManager.Instance;
    if (this.Type == UIResourceFilter.ResourceFilterType.Single)
    {
      this.ResourceStr[0].ClearString();
      if (this.CurFilterTag == UIResourceFilter.ClickType.PetResource)
      {
        if ((long) this.RequireResource > (long) instance.PetResource.Stock)
          this.ResourceStr[0].StringToFormat("<color=#e5004fff>");
        else
          this.ResourceStr[0].StringToFormat("<color=#ffffffff>");
      }
      else if ((long) this.RequireResource > (long) instance.Resource[(int) this.CurFilterTag].Stock)
        this.ResourceStr[0].StringToFormat("<color=#e5004fff>");
      else
        this.ResourceStr[0].StringToFormat("<color=#ffffffff>");
      switch (this.CurFilterTag)
      {
        case UIResourceFilter.ClickType.Grain:
          this.CurResource = instance.Resource[0].Stock;
          break;
        case UIResourceFilter.ClickType.Rock:
          this.CurResource = instance.Resource[1].Stock;
          break;
        case UIResourceFilter.ClickType.Wood:
          this.CurResource = instance.Resource[2].Stock;
          break;
        case UIResourceFilter.ClickType.Steel:
          this.CurResource = instance.Resource[3].Stock;
          break;
        case UIResourceFilter.ClickType.Money:
          this.CurResource = instance.Resource[4].Stock;
          break;
        case UIResourceFilter.ClickType.PetResource:
          this.CurResource = instance.PetResource.Stock;
          break;
      }
      this.ResourceStr[0].IntToFormat((long) this.CurResource, bNumber: true);
      this.ResourceStr[0].IntToFormat((long) this.RequireResource, bNumber: true);
      this.ResourceStr[0].StringToFormat("</color>");
      if (GUIManager.Instance.IsArabic)
        this.ResourceStr[0].AppendFormat("{2}/{0}{1}{3}");
      else
        this.ResourceStr[0].AppendFormat("{0}{1}{3}/{2}");
      this.ResourceNum.text = this.ResourceStr[0].ToString();
      this.ResourceNum.SetAllDirty();
      this.ResourceNum.cachedTextGenerator.Invalidate();
      this.ResourceNum.cachedTextGeneratorForLayout.Invalidate();
      Vector2 anchoredPosition = ((Graphic) this.SingleResourceImg).rectTransform.anchoredPosition;
      anchoredPosition.Set((float) (-(double) this.ResourceNum.preferredWidth * 0.5 - (double) this.SingleResource.rect.size.x * 0.5), 0.0f);
      ((Graphic) this.SingleResourceImg).rectTransform.anchoredPosition = anchoredPosition;
    }
    else
    {
      this.ResourceStr[0].ClearString();
      if (instance.Resource[0].Stock < 10000U)
      {
        this.ResourceStr[0].IntToFormat((long) instance.Resource[0].Stock, bNumber: true);
        this.ResourceStr[0].AppendFormat("{0}");
      }
      else
        GameConstants.FormatResourceValue(this.ResourceStr[0], instance.Resource[0].Stock);
      this.ResourceText[0].text = this.ResourceStr[0].ToString();
      this.ResourceStr[1].ClearString();
      if (instance.Resource[2].Stock < 10000U)
      {
        this.ResourceStr[1].IntToFormat((long) instance.Resource[2].Stock, bNumber: true);
        this.ResourceStr[1].AppendFormat("{0}");
      }
      else
        GameConstants.FormatResourceValue(this.ResourceStr[1], instance.Resource[2].Stock);
      this.ResourceText[2].text = this.ResourceStr[1].ToString();
      this.ResourceStr[2].ClearString();
      if (instance.Resource[1].Stock < 10000U)
      {
        this.ResourceStr[2].IntToFormat((long) instance.Resource[1].Stock, bNumber: true);
        this.ResourceStr[2].AppendFormat("{0}");
      }
      else
        GameConstants.FormatResourceValue(this.ResourceStr[2], instance.Resource[1].Stock);
      this.ResourceText[1].text = this.ResourceStr[2].ToString();
      this.ResourceStr[3].ClearString();
      if (instance.Resource[3].Stock < 10000U)
      {
        this.ResourceStr[3].IntToFormat((long) instance.Resource[3].Stock, bNumber: true);
        this.ResourceStr[3].AppendFormat("{0}");
      }
      else
        GameConstants.FormatResourceValue(this.ResourceStr[3], instance.Resource[3].Stock);
      this.ResourceText[3].text = this.ResourceStr[3].ToString();
      this.ResourceStr[4].ClearString();
      if (instance.Resource[4].Stock < 10000U)
      {
        this.ResourceStr[4].IntToFormat((long) instance.Resource[4].Stock, bNumber: true);
        this.ResourceStr[4].AppendFormat("{0}");
      }
      else
        GameConstants.FormatResourceValue(this.ResourceStr[4], instance.Resource[4].Stock);
      this.ResourceText[4].text = this.ResourceStr[4].ToString();
      for (int index = 0; index < this.ResourceText.Length; ++index)
      {
        this.ResourceText[index].SetAllDirty();
        this.ResourceText[index].cachedTextGenerator.Invalidate();
      }
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
    Equip recordByKey1;
    ushort curItemQuantity;
    if (this.BagCount > dataIdx)
    {
      if (this.FilterItem[panelObjectIdx].KeyID == (ushort) 0)
      {
        this.SetItemType(panelObjectIdx, (UIFilterBase.eItemType) (3 + this.CurFilterTag));
        return;
      }
      recordByKey1 = instance.EquipTable.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
      curItemQuantity = instance.GetCurItemQuantity(recordByKey1.EquipKey, (byte) 0);
      this.SetItemType(panelObjectIdx, UIFilterBase.eItemType.Use);
      if (curItemQuantity <= (ushort) 1)
        ((Component) this.FilterItem[panelObjectIdx].AutouseBtnTrans).gameObject.SetActive(false);
      else
        ((Component) this.FilterItem[panelObjectIdx].AutouseBtnTrans).gameObject.SetActive(true);
    }
    else
    {
      StoreTbl recordByKey2 = instance.StoreData.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
      recordByKey1 = instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
      curItemQuantity = instance.GetCurItemQuantity(recordByKey1.EquipKey, (byte) 0);
      this.SetItemType(panelObjectIdx, UIFilterBase.eItemType.BuyAndUse);
      this.FilterItem[panelObjectIdx].BuyPriceStr.ClearString();
      this.FilterItem[panelObjectIdx].BuyPriceStr.IntToFormat((long) recordByKey2.Price, bNumber: true);
      this.FilterItem[panelObjectIdx].BuyPriceStr.AppendFormat("{0}");
      this.FilterItem[panelObjectIdx].BuyPrice.text = this.FilterItem[panelObjectIdx].BuyPriceStr.ToString();
      this.FilterItem[panelObjectIdx].BuyPrice.SetAllDirty();
      this.FilterItem[panelObjectIdx].BuyPrice.cachedTextGenerator.Invalidate();
      this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID3 = (int) recordByKey2.ID;
    }
    GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[panelObjectIdx].ItemTrans, eHeroOrItem.Item, recordByKey1.EquipKey, (byte) 0, (byte) 0);
    this.FilterItem[panelObjectIdx].Name.text = instance.mStringTable.GetStringByID((uint) recordByKey1.EquipName);
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

  public override void Update()
  {
    base.Update();
    if (this.PassInit > (byte) 0 || this.Type != UIResourceFilter.ResourceFilterType.Mutile)
      return;
    this.DeltaTime += Time.deltaTime;
    if ((double) this.DeltaTime >= 2.0)
      this.DeltaTime = 0.0f;
    this.ResourceTag[(int) this.CurFilterTag].alpha = (double) this.DeltaTime <= 1.0 ? this.DeltaTime : 2f - this.DeltaTime;
  }

  private enum ClickType
  {
    Grain,
    Rock,
    Wood,
    Steel,
    Money,
    PetResource,
    None,
  }

  private enum ResourceFilterType
  {
    Mutile,
    Single,
  }

  private struct _TageSave
  {
    public ushort BeginIndex;
    public float Position;
  }
}
