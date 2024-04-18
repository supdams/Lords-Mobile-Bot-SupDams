// Decompiled with JetBrains decompiler
// Type: UIItemKindFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIItemKindFilter : UIFilterBase
{
  private int BagCount;
  private byte ItemKind;
  private byte EffectVal;
  private byte SuitId;
  private UIText Title;
  private UIText BarText;
  private UIText VipLvText;
  private Text EnergyText;
  private RectTransform EnergyImgRect;
  private RectTransform GamebleRect;
  private CString TitleStr;
  private CString VipBarStr;
  private CString VipLvStr;
  private byte BuyAndUse;
  private byte ShowSopItem = 1;
  private UIButton ClickSender;
  private Transform VIPTrans;
  private RectTransform Degree;

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager instance = DataManager.Instance;
    base.OnOpen(arg1, arg2);
    this.ThisTransform = this.SetFunc(this.transform.GetChild(4));
    this.ThisTransform.gameObject.SetActive(true);
    this.Title = this.ThisTransform.GetComponent<UIText>();
    this.Title.font = GUIManager.Instance.GetTTFFont();
    this.AddRefreshText((Text) this.Title);
    this.ItemKind = (byte) arg1;
    this.EffectVal = (byte) arg2;
    this.SuitId = (byte) (arg2 >> 16);
    this.TitleStr = StringManager.Instance.SpawnString();
    EItemType eitemType = (EItemType) ((uint) this.ItemKind - 1U);
    switch (eitemType)
    {
      case EItemType.EIT_CaseByCase:
        if (this.EffectVal == (byte) 30)
        {
          GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 3);
          this.MainText.text = instance.mStringTable.GetStringByID(8330U);
          this.EnergyImgRect = this.ThisTransform.GetChild(3).GetChild(0).GetComponent<RectTransform>();
          ((Component) this.EnergyImgRect).GetComponent<UISpritesArray>().SetSpriteIndex(0);
          this.EnergyText = this.ThisTransform.GetChild(3).GetChild(1).GetComponent<Text>();
          this.EnergyText.font = GUIManager.Instance.GetTTFFont();
          this.AddRefreshText(this.EnergyText);
          this.VipLvStr = StringManager.Instance.SpawnString();
          break;
        }
        if (this.EffectVal == (byte) 40)
        {
          this.MainText.text = instance.mStringTable.GetStringByID(9642U);
          this.GamebleRect = this.ThisTransform.GetChild(3).GetChild(0).GetComponent<RectTransform>();
          ((Component) this.GamebleRect).GetComponent<UISpritesArray>().SetSpriteIndex(1);
          ((Component) this.GamebleRect).GetComponent<Image>().SetNativeSize();
          this.EnergyText = this.ThisTransform.GetChild(3).GetChild(1).GetComponent<Text>();
          this.EnergyText.font = GUIManager.Instance.GetTTFFont();
          this.AddRefreshText(this.EnergyText);
          this.VipLvStr = StringManager.Instance.SpawnString();
          break;
        }
        if (this.EffectVal != (byte) 33)
          break;
        this.MainText.text = instance.mStringTable.GetStringByID(894U);
        this.VIPTrans = this.ThisTransform.GetChild(2);
        this.VIPTrans.gameObject.SetActive(true);
        if (GUIManager.Instance.IsArabic)
          this.VIPTrans.localScale = new Vector3(-1f, 1f, 1f);
        this.Degree = this.VIPTrans.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        this.BarText = this.VIPTrans.GetChild(0).GetChild(1).GetComponent<UIText>();
        this.BarText.font = GUIManager.Instance.GetTTFFont();
        this.AddRefreshText((Text) this.BarText);
        this.VipLvText = this.VIPTrans.GetChild(1).GetComponent<UIText>();
        this.VipLvText.font = this.BarText.font;
        this.AddRefreshText((Text) this.VipLvText);
        this.VipBarStr = StringManager.Instance.SpawnString(150);
        this.VipLvStr = StringManager.Instance.SpawnString();
        this.ShowSopItem = (byte) 0;
        break;
      case EItemType.EIT_VIP:
        this.MainText.text = instance.mStringTable.GetStringByID(7709U);
        this.VIPTrans = this.ThisTransform.GetChild(2);
        this.VIPTrans.gameObject.SetActive(true);
        if (GUIManager.Instance.IsArabic)
          this.VIPTrans.localScale = new Vector3(-1f, 1f, 1f);
        this.Degree = this.VIPTrans.GetChild(0).GetChild(0).GetComponent<RectTransform>();
        this.BarText = this.VIPTrans.GetChild(0).GetChild(1).GetComponent<UIText>();
        this.BarText.font = GUIManager.Instance.GetTTFFont();
        this.AddRefreshText((Text) this.BarText);
        this.VipLvText = this.VIPTrans.GetChild(1).GetComponent<UIText>();
        this.VipLvText.font = this.BarText.font;
        this.AddRefreshText((Text) this.VipLvText);
        this.VipBarStr = StringManager.Instance.SpawnString(150);
        this.VipLvStr = StringManager.Instance.SpawnString();
        break;
      default:
        if (eitemType != EItemType.EIT_MaterialTreasureBox)
          break;
        switch (this.EffectVal)
        {
          case 1:
            this.MainText.text = instance.mStringTable.GetStringByID(7518U);
            this.Title.text = instance.mStringTable.GetStringByID(7519U);
            break;
          case 2:
            this.MainText.text = instance.mStringTable.GetStringByID(7521U);
            this.Title.text = instance.mStringTable.GetStringByID(7522U);
            break;
        }
        if (this.SuitId == (byte) 0)
          break;
        UIText component = ((Transform) this.MessageTrans).GetChild(0).GetComponent<UIText>();
        component.text = instance.mStringTable.GetStringByID(8405U);
        this.AddRefreshText((Text) component);
        this.MessageTrans.sizeDelta = this.MessageTrans.sizeDelta with
        {
          x = component.preferredWidth + 165f
        };
        break;
    }
  }

  public override void Init()
  {
    base.Init();
    this.ChangeItemType();
    switch ((byte) ((uint) this.ItemKind - 1U))
    {
      case 9:
        if (this.EffectVal == (byte) 30)
        {
          this.UpdateMonsterPoint();
          break;
        }
        if (this.EffectVal == (byte) 40)
        {
          this.UpdateGameblePoint();
          break;
        }
        this.UpdateExp();
        break;
      case 12:
        this.UpdateVip();
        break;
    }
  }

  public override void OnHIButtonClick(UIHIBtn sender)
  {
    if (sender.m_BtnID2 == 0)
      return;
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_OpenBox, 1, sender.m_BtnID2);
  }

  public override void OnClose()
  {
    base.OnClose();
    StringManager.Instance.DeSpawnString(this.TitleStr);
    StringManager.Instance.DeSpawnString(this.VipBarStr);
    StringManager.Instance.DeSpawnString(this.VipLvStr);
  }

  private void ChangeItemType(bool bMoveTop = false)
  {
    DataManager instance = DataManager.Instance;
    Vector2 vector2 = Vector2.zero;
    instance.SortCurItemDataForBag();
    instance.SortStoreData();
    int itemidx = 0;
    this.FilterScrollRect.StopMovement();
    if (!bMoveTop)
    {
      vector2 = this.ScrollContent.anchoredPosition;
      itemidx = this.FilterScrollView.GetBeginIdx();
    }
    this.BagCount = -1;
    if ((int) this.ItemKind <= instance.sortItemDataStart.Length)
      this.SetItemData(instance.sortItemData, instance.sortItemDataStart[(int) this.ItemKind - 1], instance.sortItemDataCount[(int) this.ItemKind - 1], true, (byte) 0);
    this.BagCount = this.ItemsHeight.Count;
    if (this.ShowSopItem == (byte) 1)
      this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[(int) this.ItemKind], instance.SortSotreDataCount[(int) this.ItemKind], sort: (byte) 0);
    this.UpdateScrollItemsCount();
    if (bMoveTop)
      return;
    this.FilterScrollView.GoTo(itemidx, vector2.y);
  }

  public override bool CheckItemRule(ushort id)
  {
    DataManager instance = DataManager.Instance;
    Equip recordByKey1;
    if (this.BagCount == -1)
    {
      recordByKey1 = instance.EquipTable.GetRecordByKey(id);
    }
    else
    {
      StoreTbl recordByKey2 = instance.StoreData.GetRecordByKey(id);
      if (recordByKey2.AddDiamondBuy == (byte) 0 || recordByKey2.Filter == (byte) 2 || instance.GetCurItemQuantity(recordByKey2.ItemID, (byte) 0) > (ushort) 0)
        return false;
      recordByKey1 = instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
    }
    if ((byte) ((uint) this.ItemKind - 1U) == (byte) 17)
    {
      if (this.SuitId > (byte) 0)
      {
        if ((int) recordByKey1.PropertiesInfo[3].Propertieskey == (int) this.EffectVal && (int) recordByKey1.ActivitySuitIndex == (int) this.SuitId)
          return true;
      }
      else if ((int) recordByKey1.PropertiesInfo[3].Propertieskey == (int) this.EffectVal)
        return true;
    }
    else if ((int) recordByKey1.PropertiesInfo[0].Propertieskey == (int) this.EffectVal)
      return true;
    return false;
  }

  public override void SendPack(UIButton sender)
  {
    if ((int) this.ItemKind - 1 == 12)
    {
      GUIManager.Instance.m_SpeciallyEffect.mAddVIP = true;
      RectTransform component1 = ((Component) sender).transform.parent.GetChild(0).GetComponent<RectTransform>();
      RectTransform component2 = ((Component) sender).transform.parent.GetComponent<RectTransform>();
      RectTransform component3 = ((Component) sender).transform.parent.parent.GetComponent<RectTransform>();
      RectTransform component4 = ((Component) sender).transform.parent.parent.parent.GetComponent<RectTransform>();
      RectTransform component5 = ((Component) sender).transform.parent.parent.parent.parent.GetComponent<RectTransform>();
      GUIManager.Instance.mStartV2 = new Vector2((float) ((double) GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 + (double) component5.anchoredPosition.x + 52.0) + component1.anchoredPosition.x + component3.anchoredPosition.x + component4.anchoredPosition.x, (float) ((double) GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 + 50.0) - component5.anchoredPosition.y - component4.anchoredPosition.y - component3.anchoredPosition.y - component2.anchoredPosition.y - component1.anchoredPosition.y);
      RectTransform component6 = this.VIPTrans.GetChild(0).GetComponent<RectTransform>();
      RectTransform component7 = this.VIPTrans.parent.GetComponent<RectTransform>();
      GUIManager.Instance.m_SpeciallyEffect.UI_bezieEnd = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f - component6.anchoredPosition.x, (float) -((double) GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 - (double) component7.anchoredPosition.y - (double) component6.anchoredPosition.y));
    }
    this.ClickSender = sender;
    switch (this.ClickSender.m_BtnID1)
    {
      case 1002:
        this.BuyAndUse = (byte) 0;
        if (this.CheckItemEnergy((ushort) this.ClickSender.m_BtnID2, (byte) 1))
          break;
        DataManager.Instance.UseItem((ushort) this.ClickSender.m_BtnID2, (ushort) 1, (ushort) 0, (ushort) 0, (ushort) 0, 0U, string.Empty);
        break;
      case 1004:
        this.BuyAndUse = (byte) 1;
        if (this.CheckItemEnergy((ushort) this.ClickSender.m_BtnID2, (byte) 2))
          break;
        this.CheckBuy((byte) 1, (ushort) this.ClickSender.m_BtnID3, (ushort) this.ClickSender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), Parameter3: 0U);
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg2)
    {
      case 1:
        DataManager.Instance.UseItem((ushort) this.ClickSender.m_BtnID2, (ushort) 1, (ushort) 0, (ushort) 0, (ushort) 0, 0U, string.Empty);
        break;
      case 2:
        this.CheckBuy((byte) 1, (ushort) this.ClickSender.m_BtnID3, (ushort) this.ClickSender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), Parameter3: 0U);
        break;
    }
  }

  public void UpdateVip()
  {
    if ((byte) ((uint) this.ItemKind - 1U) != (byte) 12)
      return;
    DataManager instance = DataManager.Instance;
    VIP_DataTbl recordByKey = instance.VIPLevelTable.GetRecordByKey((ushort) instance.RoleAttr.VIPLevel);
    float num = 424.47f / (float) recordByKey.VIPPoint;
    this.Degree.sizeDelta = this.Degree.sizeDelta with
    {
      x = num * (float) instance.RoleAttr.VipPoint
    };
    this.VipBarStr.ClearString();
    if ((int) instance.RoleAttr.VIPLevel < (int) instance.RoleAttr.VIPLevelMax)
    {
      this.VipBarStr.StringToFormat(instance.mStringTable.GetStringByID(7703U));
      this.VipBarStr.IntToFormat((long) instance.RoleAttr.VipPoint, bNumber: true);
      this.VipBarStr.IntToFormat((long) recordByKey.VIPPoint, bNumber: true);
      this.VipBarStr.AppendFormat("{0}{1} / {2}");
    }
    else
      this.VipBarStr.Append(instance.mStringTable.GetStringByID(7725U));
    this.BarText.text = this.VipBarStr.ToString();
    this.BarText.SetAllDirty();
    this.BarText.cachedTextGenerator.Invalidate();
    this.VipLvStr.ClearString();
    this.VipLvStr.IntToFormat((long) instance.RoleAttr.VIPLevel);
    this.VipLvStr.AppendFormat(instance.mStringTable.GetStringByID(7723U));
    this.VipLvText.text = this.VipLvStr.ToString();
    this.VipLvText.SetAllDirty();
    this.VipLvText.cachedTextGenerator.Invalidate();
  }

  public void UpdateMonsterPoint()
  {
    if ((Object) this.EnergyImgRect == (Object) null)
      return;
    this.ThisTransform.GetChild(3).gameObject.SetActive(true);
    DataManager instance = DataManager.Instance;
    this.VipLvStr.ClearString();
    this.VipLvStr.IntToFormat((long) instance.RoleAttr.MonsterPoint, bNumber: true);
    this.VipLvStr.IntToFormat((long) instance.GetMaxMonsterPoint(), bNumber: true);
    if (GUIManager.Instance.IsArabic)
      this.VipLvStr.AppendFormat("{1} / {0}");
    else
      this.VipLvStr.AppendFormat("{0} / {1}");
    this.EnergyText.text = this.VipLvStr.ToString();
    ((Graphic) this.EnergyText).SetAllDirty();
    this.EnergyText.cachedTextGenerator.Invalidate();
    this.EnergyText.cachedTextGeneratorForLayout.Invalidate();
    this.EnergyImgRect.anchoredPosition = new Vector2((float) ((double) this.EnergyText.preferredWidth * -0.5 - 17.5), this.EnergyImgRect.anchoredPosition.y);
  }

  private void UpdateGameblePoint()
  {
    if ((Object) this.GamebleRect == (Object) null)
      return;
    this.ThisTransform.GetChild(3).gameObject.SetActive(true);
    DataManager instance = DataManager.Instance;
    this.VipLvStr.ClearString();
    this.VipLvStr.IntToFormat((long) instance.RoleAttr.ScardStar, bNumber: true);
    this.VipLvStr.AppendFormat("{0}");
    this.EnergyText.text = this.VipLvStr.ToString();
    ((Graphic) this.EnergyText).SetAllDirty();
    this.EnergyText.cachedTextGenerator.Invalidate();
    this.EnergyText.cachedTextGeneratorForLayout.Invalidate();
    this.GamebleRect.anchoredPosition = new Vector2((float) ((double) this.EnergyText.preferredWidth * -0.5 - 24.5), this.GamebleRect.anchoredPosition.y);
  }

  public void UpdateExp()
  {
    if ((byte) ((uint) this.ItemKind - 1U) != (byte) 9 || this.EffectVal != (byte) 33)
      return;
    DataManager instance = DataManager.Instance;
    LevelUp recordByKey = instance.LevelUpTable.GetRecordByKey((ushort) instance.RoleAttr.Level);
    float num = 424.47f / (float) recordByKey.KingdomExp;
    Vector2 sizeDelta = this.Degree.sizeDelta;
    this.VipBarStr.ClearString();
    if (instance.RoleAttr.Level < (byte) 60)
    {
      this.VipBarStr.IntToFormat((long) instance.RoleAttr.Exp, bNumber: true);
      this.VipBarStr.IntToFormat((long) recordByKey.KingdomExp, bNumber: true);
      this.VipBarStr.AppendFormat(instance.mStringTable.GetStringByID(896U));
      sizeDelta.x = num * (float) instance.RoleAttr.Exp;
    }
    else
    {
      this.VipBarStr.Append(instance.mStringTable.GetStringByID(898U));
      sizeDelta.x = 424.7f;
    }
    this.Degree.sizeDelta = sizeDelta;
    this.BarText.text = this.VipBarStr.ToString();
    this.BarText.SetAllDirty();
    this.BarText.cachedTextGenerator.Invalidate();
    this.VipLvStr.ClearString();
    this.VipLvStr.IntToFormat((long) instance.RoleAttr.Level);
    this.VipLvStr.AppendFormat(instance.mStringTable.GetStringByID(895U));
    this.VipLvText.text = this.VipLvStr.ToString();
    this.VipLvText.SetAllDirty();
    this.VipLvText.cachedTextGenerator.Invalidate();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        GUIManager.Instance.m_SpeciallyEffect.mAddVIP = false;
        this.ChangeItemType();
        this.UpdateVip();
        this.UpdateExp();
        break;
      case NetworkNews.Refresh_Item:
        if (this.BuyAndUse == (byte) 0)
          this.ChangeItemType();
        this.BuyAndUse = (byte) 0;
        this.UpdateVip();
        this.UpdateMonsterPoint();
        this.UpdateGameblePoint();
        this.UpdateExp();
        break;
      case NetworkNews.Refresh_VIP:
        this.UpdateVip();
        break;
      case NetworkNews.Refresh_MonsterPoint:
        this.UpdateMonsterPoint();
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
    if (recordByKey1.EquipKind == (byte) 18 && (recordByKey1.PropertiesInfo[2].Propertieskey < (ushort) 1 || recordByKey1.PropertiesInfo[2].Propertieskey > (ushort) 3))
    {
      this.FilterItem[panelObjectIdx].NameStr.ClearString();
      this.FilterItem[panelObjectIdx].NameStr.StringToFormat(instance.mStringTable.GetStringByID(7732U + (uint) recordByKey1.Color));
      this.FilterItem[panelObjectIdx].NameStr.AppendFormat(instance.mStringTable.GetStringByID(7739U));
      this.FilterItem[panelObjectIdx].NameStr.Append(instance.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
      this.FilterItem[panelObjectIdx].Name.text = this.FilterItem[panelObjectIdx].NameStr.ToString();
      this.FilterItem[panelObjectIdx].Name.SetAllDirty();
      this.FilterItem[panelObjectIdx].Name.cachedTextGenerator.Invalidate();
      this.FilterItem[panelObjectIdx].InfoTrans.gameObject.SetActive(true);
      this.FilterItem[panelObjectIdx].ItemBtn.m_BtnID2 = (int) recordByKey1.EquipKey;
      GUIManager.Instance.SetItemScaleClickSound(this.FilterItem[panelObjectIdx].ItemBtn, true, true);
    }
    else if (x == (ushort) 1)
    {
      this.FilterItem[panelObjectIdx].Name.text = instance.mStringTable.GetStringByID((uint) recordByKey1.EquipName);
      this.FilterItem[panelObjectIdx].InfoTrans.gameObject.SetActive(false);
      this.FilterItem[panelObjectIdx].ItemBtn.m_BtnID2 = 0;
      GUIManager.Instance.SetItemScaleClickSound(this.FilterItem[panelObjectIdx].ItemBtn, false, false);
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
      this.FilterItem[panelObjectIdx].InfoTrans.gameObject.SetActive(false);
      this.FilterItem[panelObjectIdx].ItemBtn.m_BtnID2 = 0;
      GUIManager.Instance.SetItemScaleClickSound(this.FilterItem[panelObjectIdx].ItemBtn, false, false);
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
    ((Component) this.FilterItem[panelObjectIdx].AutouseBtnTrans).gameObject.SetActive(curItemQuantity > (ushort) 1);
  }
}
