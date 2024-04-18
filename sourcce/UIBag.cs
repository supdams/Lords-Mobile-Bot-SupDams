// Decompiled with JetBrains decompiler
// Type: UIBag
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIBag : UIBagFilterBase, IUIHIBtnClickHandler
{
  private const byte ItemCount = 5;
  private CString[] OwnerStr;
  private CString[] PriceStr;
  private CString[] NameStr;
  private ScrollPanel BagScrollView;
  private CScrollRect BagScrollRect;
  private RectTransform ContentRect;
  private List<float> ItemsHeight = new List<float>();
  private List<ushort> ItemIDList = new List<ushort>();
  protected UIBag.ItemEdit[] ScrollItem;
  private Image StockIcon;
  private Image TitleBkImg;
  private UIText StockNum;
  private GameObject CurrencyStock;
  private CString StockNumStr;
  private RectTransform MessageTrans;
  private Color BagOwnColor = new Color(0.541f, 0.835f, 0.886f);
  private Color ShopOwnColor = new Color(0.902f, 0.886f, 0.667f);
  private UISpritesArray BagSpriteArr;
  protected UIText MainTitle;
  protected byte ShopType;
  protected byte SelBuyIndex;
  private float DeltaTime;
  private readonly byte[][][] ItemKind = new byte[2][][]
  {
    new byte[5][]
    {
      new byte[4]{ (byte) 5, (byte) 12, (byte) 9, byte.MaxValue },
      new byte[4]{ (byte) 10, (byte) 15, byte.MaxValue, (byte) 0 },
      new byte[4]{ (byte) 11, byte.MaxValue, (byte) 0, (byte) 0 },
      new byte[4]{ (byte) 13, (byte) 14, byte.MaxValue, (byte) 0 },
      new byte[4]
      {
        (byte) 17,
        (byte) 18,
        (byte) 16,
        byte.MaxValue
      }
    },
    new byte[5][]
    {
      new byte[4]{ (byte) 6, (byte) 10, (byte) 13, byte.MaxValue },
      new byte[4]{ (byte) 11, (byte) 16, byte.MaxValue, (byte) 0 },
      new byte[4]{ (byte) 12, byte.MaxValue, (byte) 0, (byte) 0 },
      new byte[4]{ (byte) 14, (byte) 15, byte.MaxValue, (byte) 0 },
      new byte[4]
      {
        (byte) 18,
        (byte) 19,
        (byte) 17,
        byte.MaxValue
      }
    }
  };
  private UIBag._BagTag[] BagTag = new UIBag._BagTag[3];
  private UIBag._ObjTag[] ObjectTag = new UIBag._ObjTag[5];
  private Color[] BagTextColor = new Color[3];
  private UIBag.ClickType CurrentTag = UIBag.ClickType.None;
  protected UIBag.ClickType CurrentObjTag = UIBag.ClickType.Tab1;
  private byte DelayInit = 2;

  public override void OnOpen(int arg1, int arg2)
  {
    if ((bool) (Object) this.ThisTransform)
      return;
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    base.OnOpen(arg1, arg2);
    instance2.UpdateUI(EGUIWindow.Door, 1, 2);
    this.ThisTransform = this.transform.GetChild(0);
    this.ThisTransform.gameObject.SetActive(true);
    Font ttfFont = instance2.GetTTFFont();
    this.TitleBkImg = this.ThisTransform.GetChild(0).GetChild(1).GetComponent<Image>();
    this.MainTitle = this.ThisTransform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.MainTitle.font = ttfFont;
    this.AddRefreshText((Text) this.MainTitle);
    UIButton component1 = this.ThisTransform.GetChild(2).GetChild(0).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 0;
    UIButton component2 = this.ThisTransform.GetChild(2).GetChild(1).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 1;
    UIButton component3 = this.ThisTransform.GetChild(2).GetChild(2).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 2;
    UIButton component4 = this.ThisTransform.GetChild(7).GetChild(0).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_BtnID1 = 3;
    if (instance2.bOpenOnIPhoneX)
      ((Behaviour) this.ThisTransform.GetChild(7).GetComponent<Image>()).enabled = false;
    this.CurrencyStock = this.ThisTransform.GetChild(1).gameObject;
    this.StockIcon = this.ThisTransform.GetChild(1).GetChild(0).GetComponent<Image>();
    this.StockNum = this.ThisTransform.GetChild(1).GetChild(2).GetComponent<UIText>();
    this.StockNum.font = ttfFont;
    this.AddRefreshText((Text) this.StockNum);
    this.ThisTransform.GetChild(1).GetChild(1).GetComponent<CustomImage>().hander = (UILoadImageHander) instance2.m_ItemInfo;
    UIButton component5 = this.ThisTransform.GetChild(1).GetChild(1).GetComponent<UIButton>();
    component5.m_BtnID1 = 12;
    component5.m_Handler = (IUIButtonClickHandler) this;
    this.StockNumStr = StringManager.Instance.SpawnString();
    this.MessageTrans = this.ThisTransform.GetChild(5).GetComponent<RectTransform>();
    UIText component6 = ((Transform) this.MessageTrans).GetChild(0).GetComponent<UIText>();
    component6.font = ttfFont;
    component6.text = instance1.mStringTable.GetStringByID(744U);
    this.AddRefreshText((Text) component6);
    this.MessageTrans.sizeDelta = this.MessageTrans.sizeDelta with
    {
      x = component6.preferredWidth + 165f
    };
    for (int index = 0; index < this.ObjectTag.Length; ++index)
    {
      UIButton component7 = this.ThisTransform.GetChild(3).GetChild(index).GetComponent<UIButton>();
      component7.m_Handler = (IUIButtonClickHandler) this;
      component7.m_BtnID1 = 4 + index;
      this.ObjectTag[index].Title = ((Component) component7).gameObject.transform.GetChild(1).GetComponent<UIText>();
      this.ObjectTag[index].Title.text = instance1.mStringTable.GetStringByID((uint) (276 + index));
      this.ObjectTag[index].Title.font = ttfFont;
      this.AddRefreshText((Text) this.ObjectTag[index].Title);
      this.ObjectTag[index].Background = this.ThisTransform.GetChild(3).GetChild(index).GetComponent<Image>();
      this.ObjectTag[index].AlphaImage = this.ThisTransform.GetChild(3).GetChild(index).GetChild(0).GetComponent<Image>();
      this.ObjectTag[index].Alpha = this.ThisTransform.GetChild(3).GetChild(index).GetChild(0).GetComponent<CanvasGroup>();
    }
    this.BagTextColor[0] = ((Graphic) this.ObjectTag[0].Title).color;
    this.BagTextColor[1] = ((Graphic) this.ObjectTag[1].Title).color;
    this.BagTextColor[2] = ((Graphic) this.ObjectTag[2].Title).color;
    this.BagSpriteArr = this.ThisTransform.GetChild(9).GetComponent<UISpritesArray>();
    Transform child = this.ThisTransform.GetChild(8);
    child.GetChild(1).GetChild(0).GetComponent<UIText>().font = ttfFont;
    UIText component8 = child.GetChild(1).GetChild(1).GetComponent<UIText>();
    component8.text = instance1.mStringTable.GetStringByID(94U);
    component8.font = ttfFont;
    child.GetChild(2).GetChild(1).GetComponent<UIText>().font = ttfFont;
    child.GetChild(2).GetChild(2).GetComponent<UIText>().font = ttfFont;
    child.GetChild(3).GetComponent<UIText>().font = ttfFont;
    child.GetChild(4).GetComponent<UIText>().font = ttfFont;
    UIText component9 = child.GetChild(5).GetChild(0).GetComponent<UIText>();
    component9.text = instance1.mStringTable.GetStringByID(282U);
    component9.font = ttfFont;
    this.OwnerStr = new CString[5];
    this.PriceStr = new CString[5];
    this.NameStr = new CString[5];
    this.ScrollItem = new UIBag.ItemEdit[5];
    for (byte index = 0; index < (byte) 5; ++index)
    {
      this.OwnerStr[(int) index] = StringManager.Instance.SpawnString();
      this.PriceStr[(int) index] = StringManager.Instance.SpawnString();
      this.NameStr[(int) index] = StringManager.Instance.SpawnString(100);
      this.ItemsHeight.Add(128f);
    }
    this.BagScrollView = this.ThisTransform.GetChild(6).GetChild(0).GetComponent<ScrollPanel>();
    for (int index = 0; index < this.BagTag.Length; ++index)
    {
      this.BagTag[index].Alpha = this.ThisTransform.GetChild(2).GetChild(index).GetChild(0).GetComponent<CanvasGroup>();
      this.BagTag[index].Icon = this.ThisTransform.GetChild(2).GetChild(index).GetChild(1).GetComponent<Image>();
    }
    if (arg2 > 0)
      instance2.BagTagSaved[0] = (byte) ((int) GUIManager.Instance.BagTagSaved[0] & -4 | arg2 - 1);
    UIBag.ClickType index1 = (UIBag.ClickType) ((int) GUIManager.Instance.BagTagSaved[0] & 3);
    Sprite sprite = (Sprite) null;
    if (index1 == UIBag.ClickType.AllianceTag && instance1.RoleAlliance.Id == 0U)
    {
      index1 = UIBag.ClickType.BagTag;
      GUIManager.Instance.BagTagSaved[0] = (byte) ((UIBag.ClickType) ((int) GUIManager.Instance.BagTagSaved[0] & -4) | index1);
    }
    switch (index1)
    {
      case UIBag.ClickType.BagTag:
        this.MainTitle.text = instance1.mStringTable.GetStringByID(285U);
        this.CurrencyStock.SetActive(false);
        this.TitleBkImg.sprite = this.BagSpriteArr.GetSprite(21);
        sprite = this.BagSpriteArr.GetSprite(5);
        break;
      case UIBag.ClickType.ShopTag:
        this.MainTitle.text = instance1.mStringTable.GetStringByID(286U);
        this.CurrencyStock.SetActive(true);
        this.TitleBkImg.sprite = this.BagSpriteArr.GetSprite(22);
        this.StockIcon.sprite = this.BagSpriteArr.GetSprite(24);
        this.StockIcon.SetNativeSize();
        ((Graphic) this.StockIcon).rectTransform.anchoredPosition = Vector2.zero;
        sprite = this.BagSpriteArr.GetSprite(7);
        break;
      case UIBag.ClickType.AllianceTag:
        this.MainTitle.text = instance1.mStringTable.GetStringByID(647U);
        this.CurrencyStock.SetActive(true);
        this.TitleBkImg.sprite = this.BagSpriteArr.GetSprite(23);
        sprite = this.BagSpriteArr.GetSprite(9);
        break;
    }
    for (byte index2 = 0; index2 < (byte) 5; ++index2)
    {
      this.ObjectTag[(int) index2].Background.sprite = sprite;
      ((Graphic) this.ObjectTag[(int) index2].Title).color = this.BagTextColor[(int) (byte) index1];
    }
    this.CurrentObjTag = (UIBag.ClickType) (4 + ((int) GUIManager.Instance.BagTagSaved[0] >> 2));
  }

  private void Init()
  {
    GUIManager.Instance.InitianHeroItemImg(this.ThisTransform.GetChild(8).GetChild(0), eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.BagScrollView.IntiScrollPanel(472f, 0.0f, 0.0f, this.ItemsHeight, 5, (IUpDateScrollPanel) this);
    this.BagScrollRect = this.ThisTransform.GetChild(6).GetChild(0).GetComponent<CScrollRect>();
    this.ContentRect = this.ThisTransform.GetChild(6).GetChild(0).GetChild(0).GetComponent<RectTransform>();
    this.ThisTransform.GetChild(6).gameObject.SetActive(true);
    this.ChangeBagTag((UIBag.ClickType) ((int) GUIManager.Instance.BagTagSaved[0] & 3));
    this.CurrentObjTag = (UIBag.ClickType) (4 + ((int) GUIManager.Instance.BagTagSaved[0] >> 2));
    this.ChangeObjTag(this.CurrentObjTag, true);
    if ((UIBag.ClickType) ((int) GUIManager.Instance.BagTagSaved[1] & 3) == this.CurrentTag && (UIBag.ClickType) (((int) GUIManager.Instance.BagTagSaved[1] >> 2) + 4) == this.CurrentObjTag)
      this.BagScrollView.GoTo((int) GameConstants.ConvertBytesToUShort(GUIManager.Instance.BagTagSaved, 2), GameConstants.ConvertBytesToFloat(GUIManager.Instance.BagTagSaved, 4));
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    GUIWindowStackData mWindow = menu.m_WindowStack[menu.m_WindowStack.Count - 1];
    if (mWindow.m_Arg2 <= 0)
      return;
    mWindow.m_Arg2 = 0;
    menu.m_WindowStack[menu.m_WindowStack.Count - 1] = mWindow;
  }

  public override void UpDateRowItem(
    GameObject item,
    int dataIdx,
    int panelObjectIdx,
    int panelId)
  {
    DataManager instance = DataManager.Instance;
    if (this.CurrentTag == UIBag.ClickType.None)
    {
      Transform transform = item.transform;
      int index = panelObjectIdx;
      this.ScrollItem[index].m_Rect = transform.GetComponent<RectTransform>();
      this.ScrollItem[index].BkImage = transform.GetComponent<Image>();
      this.ScrollItem[index].ItemTrans = transform.GetChild(0);
      this.ScrollItem[index].Info = this.ScrollItem[index].ItemTrans.GetChild(0).GetComponent<Image>();
      ((Component) this.ScrollItem[index].Info).transform.SetAsLastSibling();
      this.ScrollItem[index].ItemBtn = this.ScrollItem[index].ItemTrans.GetComponent<UIHIBtn>();
      this.ScrollItem[index].ItemBtn.m_BtnID1 = 13;
      this.ScrollItem[index].ItemBtn.m_Handler = (IUIHIBtnClickHandler) this;
      this.AddRefreshText((Text) this.ScrollItem[index].ItemTrans.GetChild(4).GetComponent<UIText>());
      this.ScrollItem[index].OwnBtnScale = transform.GetChild(1).GetComponent<uButtonScale>();
      this.ScrollItem[index].Owner = transform.GetChild(1).GetChild(0).GetComponent<UIText>();
      this.AddRefreshText((Text) this.ScrollItem[index].Owner);
      this.ScrollItem[index].OwnerUse = transform.GetChild(1).GetChild(1).GetComponent<UIText>();
      this.AddRefreshText((Text) this.ScrollItem[index].OwnerUse);
      this.ScrollItem[index].OwnerTextRect = transform.GetChild(1).GetChild(0).GetComponent<RectTransform>();
      this.ScrollItem[index].Name = transform.GetChild(3).GetComponent<UIText>();
      this.AddRefreshText((Text) this.ScrollItem[index].Name);
      this.ScrollItem[index].NameRect = transform.GetChild(3).GetComponent<RectTransform>();
      this.ScrollItem[index].Content = transform.GetChild(4).GetComponent<UIText>();
      this.AddRefreshText((Text) this.ScrollItem[index].Content);
      this.ScrollItem[index].ContentRect = transform.GetChild(4).GetComponent<RectTransform>();
      this.ScrollItem[index].OwnImg = transform.GetChild(1).GetComponent<Image>();
      this.ScrollItem[index].Currency = transform.GetChild(2).GetChild(0).GetComponent<Image>();
      this.ScrollItem[index].Price = transform.GetChild(2).GetChild(1).GetComponent<UIText>();
      this.AddRefreshText((Text) this.ScrollItem[index].Price);
      this.ScrollItem[index].BuyUseText = transform.GetChild(2).GetChild(2).GetComponent<UIText>();
      this.AddRefreshText((Text) this.ScrollItem[index].BuyUseText);
      this.ScrollItem[index].BuyUseTextTrans = transform.GetChild(2).GetChild(2).GetComponent<RectTransform>();
      this.ScrollItem[index].Ownbtn = transform.GetChild(1).GetComponent<UIButton>();
      this.ScrollItem[index].Ownbtn.m_Handler = (IUIButtonClickHandler) this;
      this.ScrollItem[index].Ownbtn.m_BtnID1 = 9;
      this.ScrollItem[index].Ownbtn.m_BtnID2 = index;
      this.ScrollItem[index].BuyTrans = transform.GetChild(2).GetComponent<RectTransform>();
      this.ScrollItem[index].BuyUseImage = ((Component) this.ScrollItem[index].BuyTrans).GetComponent<Image>();
      this.ScrollItem[index].BuyUseBtn = ((Component) this.ScrollItem[index].BuyTrans).GetComponent<UIButton>();
      this.ScrollItem[index].BuyUseBtn.m_Handler = (IUIButtonClickHandler) this;
      this.ScrollItem[index].BuyUseBtn.m_BtnID2 = index;
      this.ScrollItem[index].AutouseTrans = transform.GetChild(5);
      this.AddRefreshText((Text) this.ScrollItem[index].AutouseTrans.GetChild(0).GetComponent<UIText>());
      UIButton component = this.ScrollItem[index].AutouseTrans.GetComponent<UIButton>();
      component.m_Handler = (IUIButtonClickHandler) this;
      component.m_BtnID1 = 11;
    }
    if (this.ItemIDList.Count <= dataIdx)
      return;
    int index1 = panelObjectIdx;
    ushort x = 1;
    Equip recordByKey1;
    ushort curItemQuantity;
    if (this.CurrentTag == UIBag.ClickType.ShopTag || this.CurrentTag == UIBag.ClickType.AllianceTag)
    {
      StoreTbl recordByKey2 = instance.StoreData.GetRecordByKey(this.ItemIDList[dataIdx]);
      recordByKey1 = instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
      x = recordByKey2.Num;
      curItemQuantity = instance.GetCurItemQuantity(recordByKey1.EquipKey, (byte) 0);
      this.ScrollItem[index1].OwnImg.sprite = this.BagSpriteArr.GetSprite(curItemQuantity <= (ushort) 0 ? 11 : 12);
      ((Behaviour) this.ScrollItem[index1].Ownbtn).enabled = curItemQuantity > (ushort) 0;
      this.ScrollItem[index1].OwnBtnScale.enabled = ((Behaviour) this.ScrollItem[index1].Ownbtn).enabled;
      this.PriceStr[index1].ClearString();
      if (this.CurrentTag == UIBag.ClickType.AllianceTag)
      {
        this.PriceStr[index1].IntToFormat((long) recordByKey2.AlliancePoint, bNumber: true);
        this.ScrollItem[index1].ItemPrice = recordByKey2.AlliancePoint;
      }
      else
      {
        this.PriceStr[index1].IntToFormat((long) recordByKey2.Price, bNumber: true);
        this.ScrollItem[index1].ItemPrice = recordByKey2.Price;
      }
      this.PriceStr[index1].AppendFormat("{0}");
      this.ScrollItem[index1].Price.text = this.PriceStr[index1].ToString();
      this.ScrollItem[index1].Price.SetAllDirty();
      this.ScrollItem[index1].Price.cachedTextGenerator.Invalidate();
      this.ScrollItem[index1].ItemSN = recordByKey2.ID;
      if (recordByKey1.Hide == (byte) 1)
      {
        ((Behaviour) this.ScrollItem[index1].Ownbtn).enabled = false;
        ((Behaviour) this.ScrollItem[index1].OwnImg).enabled = false;
        ((Behaviour) this.ScrollItem[index1].OwnerUse).enabled = false;
      }
      else
      {
        ((Behaviour) this.ScrollItem[index1].OwnImg).enabled = true;
        ((Behaviour) this.ScrollItem[index1].OwnerUse).enabled = true;
      }
      if (!((Component) this.ScrollItem[index1].BuyTrans).gameObject.activeSelf)
        ((Component) this.ScrollItem[index1].BuyTrans).gameObject.SetActive(true);
    }
    else
    {
      recordByKey1 = instance.EquipTable.GetRecordByKey(this.ItemIDList[dataIdx]);
      curItemQuantity = instance.GetCurItemQuantity(this.ItemIDList[dataIdx], (byte) 0);
      if (recordByKey1.Hide == (byte) 1)
      {
        this.ScrollItem[index1].AutouseTrans.gameObject.SetActive(false);
        ((Component) this.ScrollItem[index1].BuyTrans).gameObject.SetActive(false);
      }
      else
      {
        if (!((Component) this.ScrollItem[index1].BuyTrans).gameObject.activeSelf)
          ((Component) this.ScrollItem[index1].BuyTrans).gameObject.SetActive(true);
        if (recordByKey1.EquipKind == (byte) 11 || recordByKey1.EquipKind == (byte) 19 || recordByKey1.EquipKind == (byte) 18 || recordByKey1.EquipKind == (byte) 13 || recordByKey1.EquipKind == (byte) 10 && (recordByKey1.PropertiesInfo[0].Propertieskey == (ushort) 33 || recordByKey1.PropertiesInfo[0].Propertieskey == (ushort) 49 || recordByKey1.PropertiesInfo[0].Propertieskey == (ushort) 40))
        {
          if (curItemQuantity >= (ushort) 2 && recordByKey1.Hide != (byte) 2)
            this.ScrollItem[index1].AutouseTrans.gameObject.SetActive(true);
          else
            this.ScrollItem[index1].AutouseTrans.gameObject.SetActive(false);
        }
        else
          this.ScrollItem[index1].AutouseTrans.gameObject.SetActive(false);
      }
    }
    if (x == (ushort) 1)
    {
      this.ScrollItem[index1].Name.text = instance.mStringTable.GetStringByID((uint) recordByKey1.EquipName);
    }
    else
    {
      this.NameStr[index1].ClearString();
      this.NameStr[index1].StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
      this.NameStr[index1].IntToFormat((long) x);
      this.NameStr[index1].AppendFormat("{0} x {1}");
      this.ScrollItem[index1].Name.text = this.NameStr[index1].ToString();
      this.ScrollItem[index1].Name.SetAllDirty();
      this.ScrollItem[index1].Name.cachedTextGenerator.Invalidate();
    }
    if (recordByKey1.EquipKind == (byte) 19)
    {
      ((Component) this.ScrollItem[index1].Info).gameObject.SetActive(true);
      this.ScrollItem[index1].ItemBtn.m_BtnID2 = (int) recordByKey1.EquipKey;
      GUIManager.Instance.SetItemScaleClickSound(this.ScrollItem[index1].ItemBtn, true, true);
    }
    else if (recordByKey1.EquipKind == (byte) 18 && recordByKey1.PropertiesInfo[0].Propertieskey == (ushort) 4)
    {
      ((Component) this.ScrollItem[index1].Info).gameObject.SetActive(true);
      this.ScrollItem[index1].ItemBtn.m_BtnID2 = (int) recordByKey1.EquipKey;
      GUIManager.Instance.SetItemScaleClickSound(this.ScrollItem[index1].ItemBtn, true, true);
    }
    else if (recordByKey1.EquipKind == (byte) 18 && (recordByKey1.PropertiesInfo[2].Propertieskey < (ushort) 1 || recordByKey1.PropertiesInfo[2].Propertieskey > (ushort) 3))
    {
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.StringToFormat(instance.mStringTable.GetStringByID(7734U + (uint) recordByKey1.PropertiesInfo[0].Propertieskey));
      cstring.AppendFormat(instance.mStringTable.GetStringByID(7739U));
      cstring.Append(instance.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
      this.NameStr[index1].ClearString();
      this.NameStr[index1].Append(cstring);
      this.ScrollItem[index1].Name.text = this.NameStr[index1].ToString();
      this.ScrollItem[index1].Name.SetAllDirty();
      this.ScrollItem[index1].Name.cachedTextGenerator.Invalidate();
      ((Component) this.ScrollItem[index1].Info).gameObject.SetActive(true);
      this.ScrollItem[index1].ItemBtn.m_BtnID2 = (int) recordByKey1.EquipKey;
      GUIManager.Instance.SetItemScaleClickSound(this.ScrollItem[index1].ItemBtn, true, true);
    }
    else
    {
      this.ScrollItem[index1].ItemBtn.m_BtnID2 = 0;
      ((Component) this.ScrollItem[index1].Info).gameObject.SetActive(false);
      GUIManager.Instance.SetItemScaleClickSound(this.ScrollItem[index1].ItemBtn, false, false);
    }
    this.ScrollItem[index1].Content.text = instance.mStringTable.GetStringByID((uint) recordByKey1.EquipInfo);
    CString cstring1 = StringManager.Instance.StaticString1024();
    this.OwnerStr[index1].ClearString();
    if (curItemQuantity < (ushort) 10000)
    {
      cstring1.IntToFormat((long) curItemQuantity, bNumber: true);
      cstring1.AppendFormat("{0}");
    }
    else
      GameConstants.FormatResourceValue(cstring1, (uint) curItemQuantity);
    this.OwnerStr[index1].StringToFormat(instance.mStringTable.GetStringByID(281U));
    this.OwnerStr[index1].StringToFormat(cstring1);
    this.OwnerStr[index1].AppendFormat("{0}{1}");
    this.ScrollItem[index1].Owner.text = this.OwnerStr[index1].ToString();
    this.ScrollItem[index1].Owner.SetAllDirty();
    this.ScrollItem[index1].Owner.cachedTextGenerator.Invalidate();
    GUIManager.Instance.ChangeHeroItemImg(this.ScrollItem[index1].ItemTrans, eHeroOrItem.Item, recordByKey1.EquipKey, (byte) 0, (byte) 0);
    this.ScrollItem[index1].ItemID = recordByKey1.EquipKey;
  }

  public override void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnButtonClick(UIButton sender)
  {
    if (this.DelayInit > (byte) 0)
      return;
    switch (sender.m_BtnID1)
    {
      case 0:
      case 1:
      case 2:
        this.ChangeBagTag((UIBag.ClickType) sender.m_BtnID1);
        if ((sender.m_BtnID1 != 2 || DataManager.Instance.RoleAlliance.Id <= 0U) && sender.m_BtnID1 == 2)
          break;
        this.ChangeObjTag(this.CurrentObjTag, true);
        break;
      case 3:
        Door menu1 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((Object) menu1 != (Object) null))
          break;
        menu1.CloseMenu();
        break;
      case 4:
      case 5:
      case 6:
      case 7:
      case 8:
        this.ChangeObjTag((UIBag.ClickType) sender.m_BtnID1);
        break;
      case 9:
        if (this.CheckItemEnergy(this.ScrollItem[sender.m_BtnID2].ItemID, (byte) 1))
          break;
        this.CheckMessage(this.ScrollItem[sender.m_BtnID2].ItemID);
        break;
      case 10:
        if (DataManager.Instance.GetCurItemQuantity(this.ScrollItem[sender.m_BtnID2].ItemID, (byte) 0) >= ushort.MaxValue)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(887U), (ushort) byte.MaxValue);
          break;
        }
        StringTable mStringTable = DataManager.Instance.mStringTable;
        if (this.ShopType == (byte) 2 && this.ScrollItem[sender.m_BtnID2].ItemPrice > DataManager.Instance.RoleAlliance.Money)
        {
          GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(614U), mStringTable.GetStringByID(649U), mStringTable.GetStringByID(650U));
          break;
        }
        if (this.ShopType == (byte) 1 && this.ScrollItem[sender.m_BtnID2].ItemPrice > DataManager.Instance.RoleAttr.Diamond)
        {
          GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(3966U), mStringTable.GetStringByID(646U), 4, mStringTable.GetStringByID(4507U), bCloseIDSet: true);
          break;
        }
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 10, (int) this.ScrollItem[sender.m_BtnID2].ItemSN << 16 | (int) this.ShopType);
        this.SelBuyIndex = (byte) sender.m_BtnID2;
        break;
      case 11:
        Debug.Log((object) "AutoUse");
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 3, (int) this.ScrollItem[((Component) sender).transform.parent.GetChild(2).GetComponent<UIButton>().m_BtnID2].ItemID);
        break;
      case 12:
        if (this.CurrentTag == UIBag.ClickType.AllianceTag)
        {
          GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(647U), DataManager.Instance.mStringTable.GetStringByID(700U), DataManager.Instance.mStringTable.GetStringByID(650U));
          break;
        }
        Door menu2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if ((Object) menu2 != (Object) null)
          menu2.ClearWindowStack(EGUIWindow.UI_BagFilter);
        MallManager.Instance.Send_Mall_Info();
        break;
    }
  }

  public override void OnHIButtonClick(UIHIBtn sender)
  {
    base.OnHIButtonClick(sender);
    if (sender.m_BtnID2 == 0)
      return;
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_OpenBox, 1, sender.m_BtnID2);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || DataManager.Instance.UseItemNote((ushort) arg1, (ushort) 0, (ushort) 0, (ushort) 0))
      return;
    DataManager.Instance.UseItem((ushort) arg1, (ushort) 1, (ushort) 0, (ushort) 0, (ushort) 0, 0U, string.Empty);
  }

  protected unsafe void ChangeObjTag(UIBag.ClickType Tag, bool bForceUpdate = false, bool bForceMoveBegin = true)
  {
    if (!bForceUpdate && Tag == this.CurrentObjTag)
      return;
    if (this.CurrentObjTag != UIBag.ClickType.None)
    {
      this.ObjectTag[(int) (this.CurrentObjTag - 4)].Alpha.alpha = 0.0f;
      ((Graphic) this.ObjectTag[(int) (this.CurrentObjTag - 4)].Title).color = this.BagTextColor[(int) (byte) this.CurrentTag];
    }
    this.CurrentObjTag = Tag;
    ((Graphic) this.ObjectTag[(int) (this.CurrentObjTag - 4)].Title).color = Color.white;
    DataManager instance = DataManager.Instance;
    if (this.CurrentTag == UIBag.ClickType.BagTag)
      instance.SortCurItemDataForBag();
    else
      instance.SortStoreData();
    ushort[] numArray1 = this.CurrentTag != UIBag.ClickType.BagTag ? instance.SortSotreData : instance.sortItemData;
    ushort[] numArray2;
    ushort[] numArray3;
    if (this.CurrentTag == UIBag.ClickType.BagTag)
    {
      numArray2 = instance.sortItemDataStart;
      numArray3 = instance.sortItemDataCount;
    }
    else
    {
      this.StockNumStr.ClearString();
      if (this.CurrentTag == UIBag.ClickType.ShopTag)
        this.StockNumStr.IntToFormat((long) instance.RoleAttr.Diamond, bNumber: true);
      else
        this.StockNumStr.IntToFormat((long) instance.RoleAlliance.Money, bNumber: true);
      this.StockNumStr.AppendFormat("{0}");
      this.StockNum.text = this.StockNumStr.ToString();
      this.StockNum.SetAllDirty();
      this.StockNum.cachedTextGenerator.Invalidate();
      numArray2 = instance.SortSotreDataStart;
      numArray3 = instance.SortSotreDataCount;
    }
    this.ItemIDList.Clear();
    this.ItemsHeight.Clear();
    int index1 = Mathf.Clamp((int) this.CurrentTag, 0, 1);
    byte* numPtr = this.ItemKind[index1][(int) (byte) (this.CurrentObjTag - 4)] == null || this.ItemKind[index1][(int) (byte) (this.CurrentObjTag - 4)].Length == 0 ? (byte*) null : &this.ItemKind[index1][(int) (byte) (this.CurrentObjTag - 4)][0];
    for (byte index2 = 0; index2 < (byte) 4 && numPtr[index2] != byte.MaxValue; ++index2)
    {
      int num1 = (int) numArray2[(int) numPtr[index2]];
      int num2 = num1 + (int) numArray3[(int) numPtr[index2]];
      for (int index3 = num1; index3 < num2; ++index3)
      {
        Equip recordByKey1;
        if (this.CurrentTag == UIBag.ClickType.BagTag)
        {
          if (instance.GetCurItemQuantity(numArray1[index3], (byte) 0) != (ushort) 0)
          {
            recordByKey1 = instance.EquipTable.GetRecordByKey(numArray1[index3]);
            if ((byte) ((uint) recordByKey1.EquipKind - 1U) != (byte) 16 || recordByKey1.PropertiesInfo[0].Propertieskey == (ushort) 3)
              this.ItemsHeight.Add(128f);
            else
              continue;
          }
          else
            continue;
        }
        else
        {
          StoreTbl recordByKey2 = instance.StoreData.GetRecordByKey(numArray1[index3]);
          if ((this.ShopType != (byte) 1 || recordByKey2.AddDiamondBuy != (byte) 0 && recordByKey2.Filter == (byte) 0) && (this.ShopType != (byte) 2 || recordByKey2.AddAllianceBuy != (byte) 0))
          {
            recordByKey1 = instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
            if ((byte) ((uint) recordByKey1.EquipKind - 1U) != (byte) 16 || recordByKey1.PropertiesInfo[0].Propertieskey == (ushort) 3)
              this.ItemsHeight.Add(157f);
            else
              continue;
          }
          else
            continue;
        }
        this.ItemIDList.Add(numArray1[index3]);
      }
    }
    numPtr = (byte*) null;
    int beginIdx = this.BagScrollView.GetBeginIdx();
    Vector2 anchoredPosition = this.ContentRect.anchoredPosition;
    this.BagScrollView.gameObject.SetActive(this.ItemsHeight.Count != 0);
    this.BagScrollView.AddNewDataHeight(this.ItemsHeight);
    if (bForceMoveBegin)
    {
      this.BagScrollRect.StopMovement();
      this.BagScrollView.GoTo(0);
    }
    else
      this.BagScrollView.GoTo(beginIdx, anchoredPosition.y);
    if (this.ItemsHeight.Count == 0)
      ((Component) this.MessageTrans).gameObject.SetActive(true);
    else
      ((Component) this.MessageTrans).gameObject.SetActive(false);
  }

  protected virtual void ChangeBagTag(UIBag.ClickType Tag)
  {
    if (Tag == this.CurrentTag)
      return;
    if (DataManager.Instance.RoleAlliance.Id == 0U && Tag == UIBag.ClickType.AllianceTag)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      DataManager.Instance.SetSelectRequest = 0;
      menu.OpenMenu(EGUIWindow.UI_AllianceHint);
    }
    else
    {
      if (this.CurrentTag >= UIBag.ClickType.BagTag && this.CurrentTag <= UIBag.ClickType.AllianceTag)
        this.BagTag[(int) (byte) this.CurrentTag].Alpha.alpha = 0.0f;
      this.CurrentTag = Tag;
      DataManager instance = DataManager.Instance;
      if (this.CurrentTag == UIBag.ClickType.BagTag)
      {
        instance.SortCurItemDataForBag();
      }
      else
      {
        this.ShopType = (byte) (1 + (this.CurrentTag - 1));
        instance.SortStoreData();
      }
      for (byte index = 0; (int) index < this.ScrollItem.Length; ++index)
      {
        Vector2 vector2 = this.ScrollItem[(int) index].m_Rect.sizeDelta;
        if (this.CurrentTag == UIBag.ClickType.BagTag)
        {
          vector2.y = 128f;
          this.ScrollItem[(int) index].m_Rect.sizeDelta = vector2;
          ((Behaviour) this.ScrollItem[(int) index].Ownbtn).enabled = false;
          ((Behaviour) this.ScrollItem[(int) index].OwnImg).enabled = false;
          ((Behaviour) this.ScrollItem[(int) index].OwnerUse).enabled = false;
          vector2.Set(this.ScrollItem[(int) index].OwnerTextRect.anchoredPosition.x, 18f);
          this.ScrollItem[(int) index].OwnerTextRect.anchoredPosition = vector2;
          ((Graphic) this.ScrollItem[(int) index].Owner).color = this.BagOwnColor;
          vector2.Set(131f, 47f);
          this.ScrollItem[(int) index].BuyTrans.sizeDelta = vector2;
          vector2.Set(669f, -35.5f);
          this.ScrollItem[(int) index].BuyTrans.anchoredPosition = vector2;
          this.ScrollItem[(int) index].BuyUseBtn.m_BtnID1 = 9;
          this.ScrollItem[(int) index].BuyUseImage.sprite = this.BagSpriteArr.GetSprite(13);
          ((Behaviour) this.ScrollItem[(int) index].Currency).enabled = false;
          ((Behaviour) this.ScrollItem[(int) index].Price).enabled = false;
          this.ScrollItem[(int) index].BuyUseText.text = instance.mStringTable.GetStringByID(94U);
          vector2.Set(131f, 57f);
          this.ScrollItem[(int) index].BuyUseTextTrans.sizeDelta = vector2;
          this.ScrollItem[(int) index].BuyTrans.sizeDelta = vector2;
          vector2.Set(65.5f, -28.5f);
          this.ScrollItem[(int) index].BuyUseTextTrans.anchoredPosition = vector2;
          vector2.Set(455f, this.ScrollItem[(int) index].NameRect.sizeDelta.y);
          this.ScrollItem[(int) index].NameRect.sizeDelta = vector2;
          this.ScrollItem[(int) index].Name.UpdateArabicPos();
          vector2.Set(455f, this.ScrollItem[(int) index].ContentRect.sizeDelta.y);
          this.ScrollItem[(int) index].ContentRect.sizeDelta = vector2;
          this.ScrollItem[(int) index].Content.UpdateArabicPos();
          this.ScrollItem[(int) index].AutouseTrans.gameObject.SetActive(true);
          this.TitleBkImg.sprite = this.BagSpriteArr.GetSprite(21);
          this.CurrencyStock.SetActive(false);
          this.ScrollItem[(int) index].BkImage.sprite = this.BagSpriteArr.GetSprite(15);
          this.MainTitle.text = instance.mStringTable.GetStringByID(285U);
        }
        else
        {
          vector2.y = 157f;
          this.ScrollItem[(int) index].m_Rect.sizeDelta = vector2;
          ((Behaviour) this.ScrollItem[(int) index].Ownbtn).enabled = true;
          ((Behaviour) this.ScrollItem[(int) index].OwnImg).enabled = true;
          ((Behaviour) this.ScrollItem[(int) index].OwnerUse).enabled = true;
          vector2.Set(this.ScrollItem[(int) index].OwnerTextRect.anchoredPosition.x, 10.4f);
          this.ScrollItem[(int) index].OwnerTextRect.anchoredPosition = vector2;
          ((Graphic) this.ScrollItem[(int) index].Owner).color = this.ShopOwnColor;
          vector2.Set(158f, 77f);
          this.ScrollItem[(int) index].BuyTrans.sizeDelta = vector2;
          vector2.Set(655f, -49.5f);
          this.ScrollItem[(int) index].BuyTrans.anchoredPosition = vector2;
          this.ScrollItem[(int) index].BuyUseBtn.m_BtnID1 = 10;
          this.ScrollItem[(int) index].BuyUseImage.sprite = this.BagSpriteArr.GetSprite(14);
          ((Behaviour) this.ScrollItem[(int) index].Currency).enabled = true;
          ((Behaviour) this.ScrollItem[(int) index].Price).enabled = true;
          this.ScrollItem[(int) index].BuyUseText.text = instance.mStringTable.GetStringByID(284U);
          vector2.Set(158f, 32f);
          this.ScrollItem[(int) index].BuyUseTextTrans.sizeDelta = vector2;
          vector2.Set(79f, -56.1f);
          this.ScrollItem[(int) index].BuyUseTextTrans.anchoredPosition = vector2;
          vector2.Set(420f, this.ScrollItem[(int) index].NameRect.sizeDelta.y);
          this.ScrollItem[(int) index].NameRect.sizeDelta = vector2;
          this.ScrollItem[(int) index].Name.UpdateArabicPos();
          vector2.Set(420f, this.ScrollItem[(int) index].ContentRect.sizeDelta.y);
          this.ScrollItem[(int) index].ContentRect.sizeDelta = vector2;
          this.ScrollItem[(int) index].Content.UpdateArabicPos();
          this.ScrollItem[(int) index].AutouseTrans.gameObject.SetActive(false);
          if (this.CurrentTag == UIBag.ClickType.ShopTag)
          {
            this.TitleBkImg.sprite = this.BagSpriteArr.GetSprite(22);
            this.CurrencyStock.SetActive(true);
            this.StockIcon.sprite = this.BagSpriteArr.GetSprite(24);
            this.StockIcon.SetNativeSize();
            vector2 = ((Graphic) this.StockIcon).rectTransform.anchoredPosition;
            vector2.Set(3.5f, 5f);
            ((Graphic) this.StockIcon).rectTransform.anchoredPosition = vector2;
            this.ScrollItem[(int) index].BkImage.sprite = this.BagSpriteArr.GetSprite(16);
            this.ScrollItem[(int) index].Currency.sprite = this.BagSpriteArr.GetSprite(19);
            this.ScrollItem[(int) index].Currency.SetNativeSize();
            ((Transform) ((Graphic) this.ScrollItem[(int) index].Currency).rectTransform).localScale = Vector3.one;
            this.MainTitle.text = instance.mStringTable.GetStringByID(286U);
          }
          else
          {
            this.TitleBkImg.sprite = this.BagSpriteArr.GetSprite(23);
            this.CurrencyStock.SetActive(true);
            this.StockIcon.sprite = this.BagSpriteArr.GetSprite(20);
            this.StockIcon.SetNativeSize();
            vector2 = ((Graphic) this.StockIcon).rectTransform.anchoredPosition;
            vector2.Set(7f, 1f);
            ((Graphic) this.StockIcon).rectTransform.anchoredPosition = vector2;
            this.ScrollItem[(int) index].BkImage.sprite = this.BagSpriteArr.GetSprite(17);
            this.ScrollItem[(int) index].Currency.sprite = this.BagSpriteArr.GetSprite(20);
            this.ScrollItem[(int) index].Currency.SetNativeSize();
            ((Transform) ((Graphic) this.ScrollItem[(int) index].Currency).rectTransform).localScale = Vector3.one * 0.8f;
            this.MainTitle.text = instance.mStringTable.GetStringByID(647U);
          }
        }
      }
      int index1 = this.CurrentTag != UIBag.ClickType.BagTag ? (this.CurrentTag != UIBag.ClickType.ShopTag ? 9 : 7) : 5;
      Sprite sprite1 = this.BagSpriteArr.GetSprite(index1);
      Sprite sprite2 = this.BagSpriteArr.GetSprite(index1 + 1);
      for (byte index2 = 0; index2 < (byte) 5; ++index2)
      {
        ((Graphic) this.ObjectTag[(int) index2].Title).color = this.BagTextColor[(int) (byte) this.CurrentTag];
        this.ObjectTag[(int) index2].Background.sprite = sprite1;
        this.ObjectTag[(int) index2].AlphaImage.sprite = sprite2;
        this.ObjectTag[(int) index2].AlphaImage.type = (Image.Type) 1;
      }
    }
  }

  public override void Update()
  {
    if (this.DelayInit > (byte) 0)
    {
      --this.DelayInit;
      if (this.DelayInit != (byte) 0)
        return;
      this.Init();
    }
    else
    {
      this.DeltaTime += Time.deltaTime;
      if ((double) this.DeltaTime >= 2.0)
        this.DeltaTime = 0.0f;
      float num = (double) this.DeltaTime <= 1.0 ? this.DeltaTime : 2f - this.DeltaTime;
      this.BagTag[(int) this.CurrentTag].Alpha.alpha = num;
      this.ObjectTag[(int) (this.CurrentObjTag - 4)].Alpha.alpha = num;
    }
  }

  public override void UpdateUI(int arge1, int arge2)
  {
    if (arge1 >> 16 != 1)
      return;
    switch ((UIBagFilterBase.BagUpdateType) arge1)
    {
      case UIBagFilterBase.BagUpdateType.Buy:
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) DataManager.Instance.EquipTable.GetRecordByKey((ushort) arge2).EquipName));
        cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(835U));
        GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) 18);
        break;
      case UIBagFilterBase.BagUpdateType.BuyConfirm:
        ushort b = (ushort) (arge2 >> 16);
        ushort num = (ushort) (arge2 & (int) ushort.MaxValue);
        if ((int) this.ScrollItem[(int) this.SelBuyIndex].ItemID != (int) num)
        {
          for (byte index = 0; (int) index < this.ScrollItem.Length; ++index)
          {
            if ((int) this.ScrollItem[(int) index].ItemID == (int) num)
            {
              this.SelBuyIndex = index;
              break;
            }
          }
        }
        DataManager.Instance.sendBuyItem(this.ShopType, this.ScrollItem[(int) this.SelBuyIndex].ItemSN, this.ScrollItem[(int) this.SelBuyIndex].ItemID, win: GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), Parameter3: 0U, name: string.Empty, Qty: (ushort) Mathf.Max(1, (int) b));
        break;
    }
  }

  public override void OnClose()
  {
    base.OnClose();
    for (int index = 0; index < this.OwnerStr.Length; ++index)
    {
      StringManager.Instance.DeSpawnString(this.OwnerStr[index]);
      StringManager.Instance.DeSpawnString(this.PriceStr[index]);
      StringManager.Instance.DeSpawnString(this.NameStr[index]);
    }
    StringManager.Instance.DeSpawnString(this.StockNumStr);
    if (this.CurrentTag == UIBag.ClickType.None)
      return;
    GUIManager.Instance.BagTagSaved[0] = (byte) (this.CurrentTag + ((int) (byte) (this.CurrentObjTag - 4) << 2));
    GUIManager.Instance.BagTagSaved[1] = GUIManager.Instance.BagTagSaved[0];
    GameConstants.GetBytes((ushort) this.BagScrollView.GetBeginIdx(), GUIManager.Instance.BagTagSaved, 2);
    GameConstants.GetBytes(this.ContentRect.anchoredPosition.y, GUIManager.Instance.BagTagSaved, 4);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (this.DelayInit > (byte) 0)
    {
      this.Init();
      this.DelayInit = (byte) 0;
    }
    base.UpdateNetwork(meg);
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_Item:
        if (this.CurrentTag == UIBag.ClickType.BagTag)
          DataManager.Instance.SortCurItemDataForBag();
        else
          DataManager.Instance.SortStoreData();
        this.ChangeObjTag(this.CurrentObjTag, true, false);
        break;
      case NetworkNews.Refresh_Alliance:
        if (this.CurrentTag != UIBag.ClickType.AllianceTag)
          break;
        if (DataManager.Instance.RoleAlliance.Id == 0U)
        {
          Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
          if (!((Object) menu != (Object) null))
            break;
          menu.CloseMenu_Alliance(EGUIWindow.UI_BagFilter);
          break;
        }
        this.StockNumStr.ClearString();
        this.StockNumStr.IntToFormat((long) DataManager.Instance.RoleAlliance.Money, bNumber: true);
        this.StockNumStr.AppendFormat("{0}");
        this.StockNum.text = this.StockNumStr.ToString();
        this.StockNum.SetAllDirty();
        this.StockNum.cachedTextGenerator.Invalidate();
        break;
      default:
        switch (networkNews)
        {
          case NetworkNews.Login:
            if (this.CurrentTag == UIBag.ClickType.AllianceTag && DataManager.Instance.RoleAlliance.Id == 0U)
            {
              Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
              if (!((Object) menu != (Object) null))
                return;
              menu.CloseMenu_Alliance(EGUIWindow.UI_BagFilter);
              return;
            }
            if (this.CurrentTag == UIBag.ClickType.BagTag)
              DataManager.Instance.SortCurItemDataForBag();
            else
              DataManager.Instance.SortStoreData();
            this.ChangeObjTag(this.CurrentObjTag, true, false);
            return;
          case NetworkNews.Refresh:
            this.StockNumStr.ClearString();
            if (this.CurrentTag == UIBag.ClickType.ShopTag)
              this.StockNumStr.IntToFormat((long) DataManager.Instance.RoleAttr.Diamond, bNumber: true);
            else
              this.StockNumStr.IntToFormat((long) DataManager.Instance.RoleAlliance.Money, bNumber: true);
            this.StockNumStr.AppendFormat("{0}");
            this.StockNum.text = this.StockNumStr.ToString();
            this.StockNum.SetAllDirty();
            this.StockNum.cachedTextGenerator.Invalidate();
            return;
          default:
            if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
              return;
            for (int index = 0; index < this.ScrollItem.Length && !((Object) this.ScrollItem[index].ItemBtn == (Object) null); ++index)
              this.ScrollItem[index].ItemBtn.Refresh_FontTexture();
            return;
        }
    }
  }

  protected struct ItemEdit
  {
    public RectTransform m_Rect;
    public Image BkImage;
    public Image Info;
    public Transform ItemTrans;
    public UIText Name;
    public UIText Content;
    public Image OwnImg;
    public UIHIBtn ItemBtn;
    public UIButton Ownbtn;
    public UIButton BuyUseBtn;
    public uButtonScale OwnBtnScale;
    public RectTransform BuyTrans;
    public RectTransform BuyUseTextTrans;
    public RectTransform NameRect;
    public RectTransform ContentRect;
    public RectTransform OwnerTextRect;
    public Transform AutouseTrans;
    public Image Currency;
    public Image BuyUseImage;
    public UIText Owner;
    public UIText OwnerUse;
    public UIText Price;
    public UIText BuyUseText;
    public ushort ItemID;
    public ushort ItemSN;
    public uint ItemPrice;
  }

  private struct _BagTag
  {
    public CanvasGroup Alpha;
    public Image Icon;
  }

  private struct _ObjTag
  {
    public Image Background;
    public Image AlphaImage;
    public CanvasGroup Alpha;
    public UIText Title;
  }

  private enum eBagSprite
  {
    BageOn,
    DiamondOn,
    AllianceOn,
    BageTagOff,
    BageTagOn,
    ObjectBagOff,
    ObjectBagOn,
    ObjectDiamondOff,
    ObjectDiamondOn,
    ObjectAllianceOff,
    ObjectAllianceOn,
    OwnerDisableBtn,
    OwnerBtn,
    UseBtn,
    BuyBtn,
    BageBack,
    DiamondBack,
    AllianceBack,
    BageTitleIcon,
    DiamondTitleIcon,
    AllianceTitleIcon,
    BageTitleBack,
    DiamondTitleBack,
    AllianceTitleBack,
    StockDiamond,
  }

  protected enum ClickType
  {
    BagTag,
    ShopTag,
    AllianceTag,
    Close,
    Tab1,
    Tab2,
    Tab3,
    Tab4,
    Tab5,
    Use,
    Buy,
    AutoUse,
    AddStock,
    ItemInfo,
    Gift,
    None,
  }

  protected enum UIControl
  {
    BackImage,
    Stock,
    BagTag,
    ObjTag,
    Image,
    Message,
    ScrollContent,
    Close,
    Item,
    SpriteArray,
  }

  protected enum ItemSubControl
  {
    ObjPic,
    Own,
    Buy,
    Name,
    Content,
    AutoUse,
  }
}
