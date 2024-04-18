// Decompiled with JetBrains decompiler
// Type: UIItemInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIItemInfo : 
  IMotionUpdate,
  UILoadImageHander,
  IUIButtonClickHandler,
  IUICalculatorHandler,
  IUIUnitRSliderHandler
{
  public RectTransform m_RectTransform;
  public UIButton m_Background;
  public RectTransform m_InfoPanel;
  public RectTransform m_SlashRect;
  public UIHIBtn m_ItemBtn;
  public UIText m_Name;
  public UIText m_OwnedText;
  public UIText KindText;
  public UIText m_Properties;
  public UIText m_Info;
  public UIButton m_Button1;
  public UIButton m_Button2;
  public Image m_CoinIcon;
  public Image m_UseIcon;
  public UIText m_TotalText;
  public UIText m_Price;
  public UIText m_ButtonText1;
  public UIText m_MaxQtyText;
  public UIText m_ButtonText2;
  public RectTransform m_QuantityPanel;
  public EUIItemInfo m_eItemInfo;
  public ushort m_Quantity = 1;
  public ushort m_HeroID;
  public byte m_EquipPos;
  private UnitResourcesSlider slider;
  private EasingEffect ItemInfoMotion;
  private CString Cstr;
  private CString NameStr;
  private CString PropertiesStr;
  private CString OwnedStr;
  private CString MaxQtyStr;
  private CString PriceStr;
  private Vector2 DestPos;
  private Vector2 StartPos;
  private UISynthesis synthesisInst;
  private CanvasGroup Gleam;
  private float GleamTime;
  private byte m_SynthesisKind;
  public ushort m_ItemID;
  private byte DelayCloseSynthesis;
  private Rect[] OriginBtnRect = new Rect[9];

  public void Load()
  {
    Object original = GUIManager.Instance.m_ManagerAssetBundle.Load(nameof (UIItemInfo));
    if (original == (Object) null)
      return;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    GameObject gameObject = (GameObject) Object.Instantiate(original);
    gameObject.transform.SetParent((Transform) GUIManager.Instance.m_WindowTopLayer, false);
    gameObject.SetActive(false);
    this.m_RectTransform = (RectTransform) gameObject.transform;
    Transform child1 = gameObject.transform.GetChild(0);
    this.m_Background = child1.GetComponent<UIButton>();
    this.m_Background.SoundIndex = byte.MaxValue;
    this.m_Background.m_Handler = (IUIButtonClickHandler) this;
    child1.GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      RectTransform component = child1.GetComponent<RectTransform>();
      component.offsetMin = new Vector2(component.offsetMin.x - GUIManager.Instance.IPhoneX_DeltaX, component.offsetMin.y);
      component.offsetMax = new Vector2(component.offsetMax.x + GUIManager.Instance.IPhoneX_DeltaX, component.offsetMax.y);
    }
    this.m_InfoPanel = (RectTransform) gameObject.transform.GetChild(1);
    ((Component) this.m_InfoPanel).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    Transform child2 = ((Transform) this.m_InfoPanel).GetChild(0);
    child2.GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    child2.GetChild(1).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    child2.GetChild(2).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    Transform child3 = ((Transform) this.m_InfoPanel).GetChild(1);
    this.m_ItemBtn = child3.GetComponent<UIHIBtn>();
    GUIManager.Instance.InitianHeroItemImg(child3, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.m_Name = ((Transform) this.m_InfoPanel).GetChild(2).GetComponent<UIText>();
    this.m_Name.font = ttfFont;
    this.m_OwnedText = ((Transform) this.m_InfoPanel).GetChild(3).GetComponent<UIText>();
    this.m_OwnedText.font = ttfFont;
    this.KindText = ((Transform) this.m_InfoPanel).GetChild(4).GetComponent<UIText>();
    this.KindText.font = ttfFont;
    this.m_Properties = ((Transform) this.m_InfoPanel).GetChild(5).GetComponent<UIText>();
    this.m_Properties.font = ttfFont;
    this.m_Info = ((Transform) this.m_InfoPanel).GetChild(6).GetComponent<UIText>();
    this.m_Info.font = ttfFont;
    Transform child4 = ((Transform) this.m_InfoPanel).GetChild(7);
    this.m_Button1 = child4.GetComponent<UIButton>();
    this.m_Button1.m_Handler = (IUIButtonClickHandler) this;
    child4.GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.Gleam = child4.GetChild(0).GetComponent<CanvasGroup>();
    child4.GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    child4.GetChild(1).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    RectTransform component1 = child4.GetComponent<RectTransform>();
    Vector2 anchoredPosition = component1.anchoredPosition;
    this.OriginBtnRect[0].x = anchoredPosition.x;
    this.OriginBtnRect[0].y = anchoredPosition.y;
    Vector2 sizeDelta = component1.sizeDelta;
    this.OriginBtnRect[0].width = sizeDelta.x;
    this.OriginBtnRect[0].height = sizeDelta.y;
    Vector2 vector2;
    for (int index = 1; index < child4.childCount; ++index)
    {
      RectTransform component2 = child4.GetChild(index).GetComponent<RectTransform>();
      vector2 = component2.anchoredPosition;
      this.OriginBtnRect[index].x = vector2.x;
      this.OriginBtnRect[index].y = vector2.y;
      vector2 = component2.sizeDelta;
      this.OriginBtnRect[index].width = vector2.x;
      this.OriginBtnRect[index].height = vector2.y;
    }
    Transform child5 = ((Transform) this.m_InfoPanel).GetChild(8);
    this.m_Button2 = child5.GetComponent<UIButton>();
    this.m_Button2.m_Handler = (IUIButtonClickHandler) this;
    child5.GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    RectTransform component3 = child5.GetComponent<RectTransform>();
    vector2 = component3.anchoredPosition;
    this.OriginBtnRect[5].x = vector2.x;
    this.OriginBtnRect[5].y = vector2.y;
    vector2 = component3.sizeDelta;
    this.OriginBtnRect[5].width = vector2.x;
    this.OriginBtnRect[5].height = vector2.y;
    for (int index = 0; index < child5.childCount; ++index)
    {
      RectTransform component4 = child5.GetChild(index).GetComponent<RectTransform>();
      vector2 = component4.anchoredPosition;
      this.OriginBtnRect[index + 6].x = vector2.x;
      this.OriginBtnRect[index + 6].y = vector2.y;
      vector2 = component4.sizeDelta;
      this.OriginBtnRect[index + 6].width = vector2.x;
      this.OriginBtnRect[index + 6].height = vector2.y;
    }
    if ((double) ((Component) GUIManager.Instance.m_UICanvas).GetComponent<RectTransform>().sizeDelta.x / (double) GUIManager.Instance.m_UICanvas.scaleFactor <= 853.0)
      this.m_InfoPanel.anchoredPosition = this.m_InfoPanel.anchoredPosition with
      {
        x = -32.5f
      };
    this.OriginBtnRect[8].x = this.m_InfoPanel.anchoredPosition.x;
    this.OriginBtnRect[8].y = this.m_InfoPanel.anchoredPosition.y;
    this.m_CoinIcon = ((Component) this.m_Button1).transform.GetChild(1).GetComponent<Image>();
    this.m_TotalText = ((Component) this.m_Button1).transform.GetChild(2).GetComponent<UIText>();
    this.m_TotalText.font = ttfFont;
    this.m_Price = ((Component) this.m_Button1).transform.GetChild(3).GetComponent<UIText>();
    this.m_Price.font = ttfFont;
    this.m_ButtonText1 = ((Component) this.m_Button1).transform.GetChild(4).GetComponent<UIText>();
    this.m_ButtonText1.font = ttfFont;
    this.m_UseIcon = ((Component) this.m_Button2).transform.GetChild(0).GetComponent<Image>();
    this.m_ButtonText2 = ((Component) this.m_Button2).transform.GetChild(1).GetComponent<UIText>();
    this.m_ButtonText2.font = ttfFont;
    this.m_QuantityPanel = (RectTransform) ((Transform) this.m_InfoPanel).GetChild(9);
    this.m_MaxQtyText = ((Transform) this.m_InfoPanel).GetChild(9).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.m_SlashRect = ((Transform) this.m_InfoPanel).GetChild(9).GetChild(0).GetChild(1).GetComponent<RectTransform>();
    ((Component) this.m_SlashRect).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_MaxQtyText.font = ttfFont;
    this.synthesisInst = (UISynthesis) null;
    this.Cstr = StringManager.Instance.SpawnString();
    this.NameStr = StringManager.Instance.SpawnString(80);
    this.PropertiesStr = StringManager.Instance.SpawnString(200);
    this.OwnedStr = StringManager.Instance.SpawnString();
    this.MaxQtyStr = StringManager.Instance.SpawnString();
    this.PriceStr = StringManager.Instance.SpawnString();
    this.ItemInfoMotion = new EasingEffect();
    this.ItemInfoMotion.Motion = (IMotionUpdate) this;
  }

  public void Unload()
  {
    if ((Object) this.m_RectTransform == (Object) null)
      return;
    Object.Destroy((Object) ((Component) this.m_RectTransform).gameObject);
    this.m_RectTransform = (RectTransform) null;
    this.m_Background = (UIButton) null;
    this.m_InfoPanel = (RectTransform) null;
    this.m_ItemBtn = (UIHIBtn) null;
    this.m_Name = (UIText) null;
    this.m_OwnedText = (UIText) null;
    this.m_Properties = (UIText) null;
    this.m_Info = (UIText) null;
    this.m_Button1 = (UIButton) null;
    this.m_Button2 = (UIButton) null;
    this.m_CoinIcon = (Image) null;
    this.m_TotalText = (UIText) null;
    this.m_Price = (UIText) null;
    this.m_ButtonText1 = (UIText) null;
    this.m_ButtonText2 = (UIText) null;
    this.m_QuantityPanel = (RectTransform) null;
    StringManager.Instance.DeSpawnString(this.Cstr);
    StringManager.Instance.DeSpawnString(this.NameStr);
    StringManager.Instance.DeSpawnString(this.PropertiesStr);
    StringManager.Instance.DeSpawnString(this.PriceStr);
    StringManager.Instance.DeSpawnString(this.MaxQtyStr);
    StringManager.Instance.DeSpawnString(this.OwnedStr);
  }

  public void OnButtonClick(UIButton sender)
  {
    DataManager instance = DataManager.Instance;
    switch (sender.m_BtnID1)
    {
      case 1:
        this.Hide();
        break;
      case 2:
        switch (this.m_eItemInfo)
        {
          case EUIItemInfo.ItemList:
            if (sender.m_BtnID2 == 0)
            {
              GUIManager.Instance.m_ItemInfo.Show(EUIItemInfo.SellItem, this.m_ItemBtn.HIID, (ushort) 0, (byte) 0);
              return;
            }
            if (sender.m_BtnID2 == 1)
            {
              instance.UseItem(this.m_ItemID, (ushort) 1, (ushort) 0, (ushort) 0, (ushort) 0, 0U, string.Empty);
              this.Hide();
              return;
            }
            if (sender.m_BtnID2 == 2)
            {
              GUIManager.Instance.OpenMenu(EGUIWindow.UI_PetStoneTrans, (int) this.m_ItemID, bSecWindow: true);
              this.Hide();
              return;
            }
            DataManager.Instance.UseItem(this.m_ItemID, (ushort) 1, (ushort) 0, (ushort) 0, (ushort) 0, 0U, string.Empty);
            this.Hide();
            return;
          case EUIItemInfo.SellItem:
            if (this.m_Quantity > (ushort) 0)
              instance.SendSellItem(this.m_ItemBtn.HIID, this.m_Quantity);
            this.Hide();
            return;
          case EUIItemInfo.HeroEquip:
            CurHeroData curHeroData = instance.curHeroData.Find((uint) this.m_HeroID);
            int curItemQuantity = (int) instance.GetCurItemQuantity(this.m_ItemBtn.HIID, (byte) 0);
            if (this.m_EquipPos == (byte) 0 || ((int) curHeroData.Equip >> (int) this.m_EquipPos - 1 & 1) != 0)
            {
              this.Hide();
              return;
            }
            if (curItemQuantity > 0)
            {
              Equip recordByKey = instance.EquipTable.GetRecordByKey(this.m_ItemBtn.HIID);
              if ((int) curHeroData.Level < (int) recordByKey.NeedLv)
                return;
              eHeroState heroState = instance.GetHeroState(this.m_HeroID);
              if ((int) instance.GetLeaderID() == (int) this.m_HeroID && (heroState == eHeroState.Dead || heroState == eHeroState.Captured))
                GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(889U), (ushort) byte.MaxValue);
              else
                instance.SendHeroPutOnEq(this.m_HeroID, this.m_EquipPos);
              this.synthesisInst = GUIManager.Instance.FindMenu(EGUIWindow.UI_Synthesis) as UISynthesis;
              if ((Object) this.synthesisInst != (Object) null)
              {
                this.synthesisInst.OnButtonClick(this.synthesisInst.m_ExiteBtn);
                this.synthesisInst = (UISynthesis) null;
              }
              this.Hide();
              return;
            }
            if (curItemQuantity != 0)
              return;
            ((Component) this.m_Background).gameObject.SetActive(false);
            this.m_ButtonText1.text = instance.mStringTable.GetStringByID(150U);
            this.UpdateSynthesis();
            (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_Synthesis, (int) this.m_ItemBtn.HIID);
            return;
          default:
            return;
        }
      case 3:
        GUIManager.Instance.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
        GUIManager.Instance.m_UICalculator.OpenCalculator(this.slider.MaxValue, this.slider.Value, 290.22f, -132.9f, this.slider, 0L);
        break;
    }
  }

  public void UpdateSynthesis()
  {
    DataManager instance = DataManager.Instance;
    CurHeroData curHeroData = instance.curHeroData.Find((uint) this.m_HeroID);
    Equip recordByKey = instance.EquipTable.GetRecordByKey(this.m_ItemBtn.HIID);
    int curItemQuantity = (int) instance.GetCurItemQuantity(this.m_ItemBtn.HIID, (byte) 0);
    if (curItemQuantity > 0)
    {
      if ((int) curHeroData.Level >= (int) recordByKey.NeedLv)
      {
        this.m_Button1.interactable = true;
        ((Graphic) this.m_ButtonText1).color = Color.white;
        ((Component) this.Gleam).gameObject.SetActive(true);
        int num = (int) MotionEffect.SetStack((MotionEffect) this.ItemInfoMotion);
        this.GleamTime = 0.0f;
      }
      else
      {
        this.m_Button1.interactable = false;
        ((Graphic) this.m_ButtonText1).color = Color.gray;
      }
      this.m_ButtonText1.text = instance.mStringTable.GetStringByID(150U);
      if (this.m_SynthesisKind == (byte) 1)
      {
        Vector2 startPos = this.StartPos;
        this.StartPos = this.DestPos;
        this.DestPos = startPos;
        UISynthesis menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_Synthesis) as UISynthesis;
        if ((Object) menu != (Object) null)
          menu.m_MovingExit = true;
      }
      else
        this.DelayCloseSynthesis = (byte) 1;
    }
    else
    {
      this.m_Button1.interactable = false;
      ((Graphic) this.m_ButtonText1).color = Color.red;
      this.m_ButtonText1.text = recordByKey.SyntheticParts[0].SyntheticItem != (ushort) 0 ? instance.mStringTable.GetStringByID(235U) : instance.mStringTable.GetStringByID(236U);
    }
    this.OwnedStr.ClearString();
    this.OwnedStr.IntToFormat((long) curItemQuantity, bNumber: true);
    this.OwnedStr.AppendFormat(instance.mStringTable.GetStringByID(79U));
    this.m_OwnedText.text = this.OwnedStr.ToString();
    this.m_OwnedText.SetAllDirty();
    this.m_OwnedText.cachedTextGenerator.Invalidate();
  }

  public void Show(EUIItemInfo eItemInfo, ushort ItemID, ushort HeroID = 0, byte EquipPos = 0)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    Equip recordByKey = instance1.EquipTable.GetRecordByKey(ItemID);
    this.m_eItemInfo = eItemInfo;
    this.m_ItemID = ItemID;
    if ((Object) instance2.FindMenu(EGUIWindow.UI_Synthesis) == (Object) null)
    {
      this.m_HeroID = HeroID;
      this.m_EquipPos = EquipPos;
    }
    if ((int) recordByKey.EquipKey == (int) ItemID)
    {
      ushort curItemQuantity = instance1.GetCurItemQuantity(ItemID, (byte) 0);
      Vector2 pos = Vector2.zero;
      Color white = Color.white;
      ((Transform) this.m_RectTransform).SetSiblingIndex(2);
      ((Component) this.m_RectTransform).gameObject.SetActive(true);
      instance2.ChangeHeroItemImg(((Component) this.m_ItemBtn).transform, eHeroOrItem.Item, ItemID, (byte) 0, (byte) 0);
      UIItemInfo.SetNameProperties(this.m_Name, this.m_Properties, this.NameStr, this.PropertiesStr, ref recordByKey);
      EItemType eitemType1 = (EItemType) ((uint) recordByKey.EquipKind - 1U);
      switch (eitemType1)
      {
        case EItemType.EIT_SingleNumSynEquip:
        case EItemType.EIT_MultiNumSynEquip:
          this.KindText.text = instance1.mStringTable.GetStringByID(886U);
          break;
        case EItemType.EIT_SynBook:
          this.KindText.text = instance1.mStringTable.GetStringByID((uint) byte.MaxValue);
          break;
        case EItemType.EIT_SynBaseEquip:
          this.KindText.text = instance1.mStringTable.GetStringByID(254U);
          break;
        case EItemType.EIT_HeroStone:
          this.KindText.text = instance1.mStringTable.GetStringByID(256U);
          break;
        case EItemType.EIT_Consumables:
          this.KindText.text = instance1.mStringTable.GetStringByID(253U);
          break;
        case EItemType.EIT_CaseByCase:
          switch ((ECaseByCaseType) recordByKey.PropertiesInfo[0].Propertieskey)
          {
            case ECaseByCaseType.ECBCT_PetCore:
              this.KindText.text = instance1.mStringTable.GetStringByID(14654U);
              break;
            case ECaseByCaseType.ECBCT_PetMaterial:
              this.KindText.text = instance1.mStringTable.GetStringByID(879U);
              break;
            default:
              this.KindText.text = string.Empty;
              break;
          }
          break;
        default:
          this.KindText.text = eitemType1 == EItemType.EIT_EnhanceStone ? instance1.mStringTable.GetStringByID(16050U) : string.Empty;
          break;
      }
      this.OwnedStr.ClearString();
      this.OwnedStr.IntToFormat((long) curItemQuantity, bNumber: true);
      this.OwnedStr.AppendFormat(instance1.mStringTable.GetStringByID(79U));
      this.m_OwnedText.text = this.OwnedStr.ToString();
      this.m_OwnedText.SetAllDirty();
      this.m_OwnedText.cachedTextGenerator.Invalidate();
      this.m_Info.text = eItemInfo == EUIItemInfo.SellItem || recordByKey.EquipKind == (byte) 6 && (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 9 || recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 5 || recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 6) || recordByKey.EquipKind == (byte) 10 && (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 45 || recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 46) || recordByKey.EquipKind == (byte) 29 ? string.Empty : instance1.mStringTable.GetStringByID((uint) recordByKey.EquipInfo);
      this.m_Button1.interactable = true;
      if (instance2.IsArabic && (double) ((Transform) ((Graphic) this.m_Price).rectTransform).localScale.x < 0.0)
        this.m_Price.alignment = TextAnchor.MiddleRight;
      else
        this.m_Price.alignment = TextAnchor.MiddleLeft;
      switch (eItemInfo)
      {
        case EUIItemInfo.ItemList:
          if (recordByKey.RecoverPrice == 0U)
          {
            ((Component) this.m_Button1).gameObject.SetActive(false);
            if ((byte) ((uint) recordByKey.EquipKind - 1U) == (byte) 5 && (byte) recordByKey.PropertiesInfo[0].Propertieskey == (byte) 4)
            {
              ((Component) this.m_Button2).gameObject.SetActive(true);
              this.m_ButtonText2.text = instance1.mStringTable.GetStringByID(94U);
              this.LoadCustomImage(this.m_UseIcon, "UI_main_icon_001", (string) null);
              this.m_Button2.m_BtnID2 = 1;
            }
            else
            {
              ushort propertieskey = recordByKey.PropertiesInfo[0].Propertieskey;
              if ((byte) ((uint) recordByKey.EquipKind - 1U) == (byte) 5 && propertieskey == (ushort) 6)
              {
                ((Component) this.m_Button2).gameObject.SetActive(true);
                this.m_ButtonText2.text = instance1.mStringTable.GetStringByID(94U);
                this.LoadCustomImage(this.m_UseIcon, "UI_main_icon_001", (string) null);
                this.m_Button2.m_BtnID2 = 1;
              }
              else
                ((Component) this.m_Button2).gameObject.SetActive(false);
            }
          }
          else
          {
            ((Component) this.m_Button1).gameObject.SetActive(true);
            ((Component) this.m_Button2).gameObject.SetActive(false);
            EItemType eitemType2 = (EItemType) ((uint) recordByKey.EquipKind - 1U);
            switch (eitemType2)
            {
              case EItemType.EIT_SynBaseEquip:
                (((Component) this.m_Button1).transform as RectTransform).anchoredPosition = (((Component) this.m_Button2).transform as RectTransform).anchoredPosition;
                break;
              case EItemType.EIT_Consumables:
                ushort propertieskey = recordByKey.PropertiesInfo[0].Propertieskey;
                ((Component) this.m_Button2).gameObject.SetActive(propertieskey == (ushort) 2 || propertieskey >= (ushort) 4 && propertieskey <= (ushort) 8);
                this.m_ButtonText2.text = instance1.mStringTable.GetStringByID(94U);
                this.LoadCustomImage(this.m_UseIcon, "UI_main_icon_001", (string) null);
                this.m_Button2.m_BtnID2 = 1;
                break;
              default:
                if (eitemType2 == EItemType.EIT_EnhanceStone)
                {
                  this.m_Button2.m_BtnID2 = 2;
                  ((Component) this.m_Button2).gameObject.SetActive(true);
                  this.m_ButtonText2.text = instance1.mStringTable.GetStringByID(14586U);
                  this.LoadCustomImage(this.m_UseIcon, "UI_main_icon_001", (string) null);
                  break;
                }
                break;
            }
            ((Component) this.m_CoinIcon).gameObject.SetActive(true);
            ((Component) this.m_TotalText).gameObject.SetActive(false);
            this.PriceStr.ClearString();
            this.PriceStr.IntToFormat((long) recordByKey.RecoverPrice, bNumber: true);
            this.PriceStr.AppendFormat("{0}");
            this.m_Price.text = this.PriceStr.ToString();
            this.m_Price.SetAllDirty();
            this.m_Price.cachedTextGenerator.Invalidate();
            this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(80U);
            if (!((Component) this.m_Button2).gameObject.activeSelf)
              (((Component) this.m_Button1).transform as RectTransform).anchoredPosition = (((Component) this.m_Button2).transform as RectTransform).anchoredPosition;
          }
          ((Component) this.m_QuantityPanel).gameObject.SetActive(false);
          break;
        case EUIItemInfo.SellItem:
          if ((Object) this.slider == (Object) null)
          {
            RectTransform child1 = ((Transform) this.m_QuantityPanel).GetChild(0) as RectTransform;
            Transform child2 = ((Transform) this.m_QuantityPanel).GetChild(0);
            this.slider = ((Component) this.m_QuantityPanel).gameObject.AddComponent<UnitResourcesSlider>();
            instance2.InitUnitResourcesSlider(this.slider.transform, eUnitSlider.AutoUse, 0U, 0U);
            child2.SetParent(((Component) this.m_InfoPanel).transform);
            instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnLessen, -110f, 22f, 70f, 60f, 0.0f, 0.0f);
            instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 29.5f, 22f, 172f, 19f, 1f, (float) curItemQuantity);
            instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnIncrease, 158f, 22f, 70f, 60f, 0.0f, 0.0f);
            instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.Input, -17.7f, 64.7f, 81f, 32f, 0.0f, 0.0f);
            this.slider.m_Handler = (IUIUnitRSliderHandler) this;
            this.slider.m_inputText.fontSize = 22;
            this.slider.m_inputText.alignment = TextAnchor.MiddleRight;
            this.slider.BtnInputText.m_Handler = (IUIButtonClickHandler) this;
            this.slider.BtnInputText.m_BtnID1 = 3;
            child2.SetParent(((Component) this.m_QuantityPanel).transform);
            if (instance2.IsArabic)
              ((Transform) this.m_SlashRect).localScale = new Vector3(-1f, 1f, 1f);
          }
          else
            instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 29.5f, 22f, 172f, 19f, 0.0f, (float) curItemQuantity);
          ((Behaviour) this.m_Info).enabled = false;
          this.Cstr.ClearString();
          this.slider.m_slider.value = 1.0;
          StringManager.IntToStr(this.Cstr, 1L, bNumber: true);
          this.slider.m_inputText.text = this.Cstr.ToString();
          this.MaxQtyStr.ClearString();
          this.MaxQtyStr.IntToFormat((long) curItemQuantity, bNumber: true);
          this.MaxQtyStr.AppendFormat("{0}");
          this.m_MaxQtyText.text = this.MaxQtyStr.ToString();
          this.m_MaxQtyText.SetAllDirty();
          this.m_MaxQtyText.cachedTextGenerator.Invalidate();
          ((Component) this.m_Button1).gameObject.SetActive(true);
          ((Component) this.m_Button2).gameObject.SetActive(false);
          RectTransform transform1 = (RectTransform) ((Component) this.m_Button1).transform;
          pos.Set(187f, -93.5f);
          transform1.anchoredPosition = pos;
          pos.Set(290f, 81f);
          transform1.sizeDelta = pos;
          ((Component) this.m_CoinIcon).gameObject.SetActive(true);
          ((Component) this.m_TotalText).gameObject.SetActive(true);
          this.m_TotalText.text = DataManager.Instance.mStringTable.GetStringByID(81U);
          this.PriceStr.ClearString();
          this.PriceStr.IntToFormat((long) recordByKey.RecoverPrice, bNumber: true);
          this.PriceStr.AppendFormat("{0}");
          this.m_Price.text = this.PriceStr.ToString();
          this.m_Price.SetAllDirty();
          this.m_Price.cachedTextGenerator.Invalidate();
          this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(82U);
          pos.Set(123f, -8f);
          ((Graphic) this.m_CoinIcon).rectTransform.anchoredPosition = pos;
          pos.x = 163f;
          pos = this.m_Price.ArabicFixPos(pos);
          ((Graphic) this.m_Price).rectTransform.anchoredPosition = pos;
          ((Component) this.m_QuantityPanel).gameObject.SetActive(true);
          break;
        case EUIItemInfo.HeroEquip:
          CurHeroData curHeroData = instance1.curHeroData.Find((uint) this.m_HeroID);
          ((Component) this.m_Button1).gameObject.SetActive(true);
          ((Component) this.m_Button2).gameObject.SetActive(false);
          ((Component) this.m_CoinIcon).gameObject.SetActive(false);
          ((Component) this.m_TotalText).gameObject.SetActive(false);
          ((Component) this.m_QuantityPanel).gameObject.SetActive(false);
          this.PriceStr.ClearString();
          if (this.m_EquipPos == (byte) 0 || ((int) curHeroData.Equip >> (int) this.m_EquipPos - 1 & 1) != 0)
          {
            this.PriceStr.IntToFormat((long) recordByKey.NeedLv);
            this.PriceStr.AppendFormat(instance1.mStringTable.GetStringByID(86U));
            this.m_ButtonText1.text = instance1.mStringTable.GetStringByID(3U);
          }
          else if (instance1.GetCurItemQuantity(ItemID, (byte) 0) > (ushort) 0)
          {
            if ((int) curHeroData.Level >= (int) recordByKey.NeedLv)
            {
              this.PriceStr.Append(instance1.mStringTable.GetStringByID(149U));
              ((Component) this.Gleam).gameObject.SetActive(true);
              int num = (int) MotionEffect.SetStack((MotionEffect) this.ItemInfoMotion);
              this.GleamTime = 0.0f;
            }
            else
            {
              this.m_Button1.interactable = false;
              this.PriceStr.IntToFormat((long) recordByKey.NeedLv);
              this.PriceStr.AppendFormat(instance1.mStringTable.GetStringByID(86U));
              ((Graphic) this.m_ButtonText1).color = Color.gray;
            }
            this.m_ButtonText1.text = instance1.mStringTable.GetStringByID(150U);
          }
          else
          {
            this.PriceStr.IntToFormat((long) recordByKey.NeedLv);
            this.PriceStr.AppendFormat(instance1.mStringTable.GetStringByID(86U));
            if (recordByKey.SyntheticParts[0].SyntheticItem == (ushort) 0)
            {
              this.m_ButtonText1.text = instance1.mStringTable.GetStringByID(199U);
            }
            else
            {
              this.m_ButtonText1.text = instance1.mStringTable.GetStringByID(87U);
              this.m_SynthesisKind = (byte) 1;
            }
          }
          this.m_Price.text = this.PriceStr.ToString();
          this.m_Price.SetAllDirty();
          this.m_Price.cachedTextGenerator.Invalidate();
          RectTransform transform2 = (RectTransform) ((Component) this.m_Button1).transform;
          pos.Set(187f, -93.5f);
          transform2.anchoredPosition = pos;
          pos.Set(290f, 81f);
          transform2.sizeDelta = pos;
          pos.Set(0.0f, -6.9f);
          ((Graphic) this.m_Price).rectTransform.anchoredPosition = this.m_Price.ArabicFixPos(pos);
          ((Graphic) this.m_Price).rectTransform.sizeDelta = ((Graphic) this.m_Price).rectTransform.sizeDelta with
          {
            x = 290f
          };
          this.m_Price.UpdateArabicPos();
          this.m_Price.alignment = TextAnchor.MiddleCenter;
          ((Graphic) this.m_Price).color = (int) curHeroData.Level < (int) recordByKey.NeedLv ? Color.red : Color.yellow;
          this.DestPos = this.m_InfoPanel.anchoredPosition;
          this.DestPos.y = 166f;
          this.StartPos = this.m_InfoPanel.anchoredPosition;
          if ((bool) (Object) instance2.FindMenu(EGUIWindow.UI_Synthesis))
          {
            ((Component) this.m_Background).gameObject.SetActive(false);
            this.UpdateSynthesis();
          }
          NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, (object) this);
          break;
      }
    }
    else
      this.Hide();
  }

  public void DestroySlider()
  {
    if ((Object) this.slider == (Object) null)
      return;
    for (int index = ((Component) this.m_QuantityPanel).transform.childCount - 2; index >= 0; --index)
      Object.Destroy((Object) ((Transform) this.m_QuantityPanel).GetChild(index).gameObject);
    Object.Destroy((Object) this.slider);
    this.slider = (UnitResourcesSlider) null;
  }

  public void Hide()
  {
    if (!((Component) this.m_Background).gameObject.activeSelf)
      ((Component) this.m_Background).gameObject.SetActive(true);
    if (!((Component) this.m_RectTransform).gameObject.activeSelf)
      return;
    ((Component) this.m_RectTransform).gameObject.SetActive(false);
    this.m_Name.text = string.Empty;
    this.m_OwnedText.text = string.Empty;
    this.m_Properties.text = string.Empty;
    this.m_Info.text = string.Empty;
    RectTransform component1 = ((Component) this.m_Button1).transform.GetComponent<RectTransform>();
    Vector2 anchoredPosition = component1.anchoredPosition;
    anchoredPosition.Set(this.OriginBtnRect[0].x, this.OriginBtnRect[0].y);
    component1.anchoredPosition = anchoredPosition;
    Vector2 sizeDelta = component1.sizeDelta;
    sizeDelta.Set(this.OriginBtnRect[0].width, this.OriginBtnRect[0].height);
    component1.sizeDelta = sizeDelta;
    Vector2 vector2;
    for (int index = 1; index < ((Component) this.m_Button1).transform.childCount; ++index)
    {
      RectTransform component2 = ((Component) this.m_Button1).transform.GetChild(index).GetComponent<RectTransform>();
      vector2 = component2.anchoredPosition;
      vector2.Set(this.OriginBtnRect[index].x, this.OriginBtnRect[index].y);
      component2.anchoredPosition = vector2;
      vector2 = component2.sizeDelta;
      vector2.Set(this.OriginBtnRect[index].width, this.OriginBtnRect[index].height);
      component2.sizeDelta = vector2;
    }
    RectTransform component3 = ((Component) this.m_Button2).transform.GetComponent<RectTransform>();
    vector2 = component3.anchoredPosition;
    vector2.Set(this.OriginBtnRect[5].x, this.OriginBtnRect[5].y);
    component3.anchoredPosition = vector2;
    vector2 = component3.sizeDelta;
    vector2.Set(this.OriginBtnRect[5].width, this.OriginBtnRect[5].height);
    component3.sizeDelta = vector2;
    for (int index = 0; index < ((Component) this.m_Button2).transform.childCount; ++index)
    {
      RectTransform component4 = ((Component) this.m_Button2).transform.GetChild(index).GetComponent<RectTransform>();
      vector2 = component4.anchoredPosition;
      vector2.Set(this.OriginBtnRect[index + 6].x, this.OriginBtnRect[index + 6].y);
      component4.anchoredPosition = vector2;
      vector2 = component4.sizeDelta;
      vector2.Set(this.OriginBtnRect[index + 6].width, this.OriginBtnRect[index + 6].height);
      component4.sizeDelta = vector2;
    }
    vector2 = this.m_InfoPanel.anchoredPosition;
    vector2.Set(this.OriginBtnRect[8].x, this.OriginBtnRect[8].y);
    this.m_InfoPanel.anchoredPosition = vector2;
    if (GUIManager.Instance.IsArabic)
    {
      ((Graphic) this.m_Price).rectTransform.anchoredPosition = this.m_Price.ArabicFixPos(((Graphic) this.m_Price).rectTransform.anchoredPosition);
      this.m_Price.alignment = TextAnchor.MiddleRight;
      ((Graphic) this.m_TotalText).rectTransform.anchoredPosition = this.m_TotalText.ArabicFixPos(((Graphic) this.m_TotalText).rectTransform.anchoredPosition);
    }
    else
      this.m_Price.alignment = TextAnchor.MiddleLeft;
    ((Graphic) this.m_Price).color = Color.white;
    ((Graphic) this.m_ButtonText1).color = (Color) new Color32(byte.MaxValue, (byte) 247, (byte) 153, byte.MaxValue);
    ((Behaviour) this.m_Info).enabled = true;
    ((Component) this.Gleam).gameObject.SetActive(false);
    this.m_Button1.interactable = false;
    this.m_SynthesisKind = (byte) 0;
    this.DelayCloseSynthesis = (byte) 0;
    this.m_Button2.m_BtnID2 = 0;
  }

  public void TextRefresh()
  {
    if ((Object) this.m_RectTransform == (Object) null || !((Component) this.m_RectTransform).gameObject.activeSelf)
      return;
    ((Behaviour) this.m_Name).enabled = false;
    ((Behaviour) this.m_Name).enabled = true;
    ((Behaviour) this.m_OwnedText).enabled = false;
    ((Behaviour) this.m_OwnedText).enabled = true;
    ((Behaviour) this.KindText).enabled = false;
    ((Behaviour) this.KindText).enabled = true;
    ((Behaviour) this.m_Properties).enabled = false;
    ((Behaviour) this.m_Properties).enabled = true;
    ((Behaviour) this.m_Info).enabled = false;
    ((Behaviour) this.m_Info).enabled = true;
    ((Behaviour) this.m_TotalText).enabled = false;
    ((Behaviour) this.m_TotalText).enabled = true;
    ((Behaviour) this.m_Price).enabled = false;
    ((Behaviour) this.m_Price).enabled = true;
    ((Behaviour) this.m_ButtonText1).enabled = false;
    ((Behaviour) this.m_ButtonText1).enabled = true;
    ((Behaviour) this.m_MaxQtyText).enabled = false;
    ((Behaviour) this.m_MaxQtyText).enabled = true;
    ((Behaviour) this.m_ButtonText2).enabled = false;
    ((Behaviour) this.m_ButtonText2).enabled = true;
    if (!((Object) this.slider != (Object) null))
      return;
    this.slider.Refresh_FontTexture();
  }

  public static void SetNameProperties(
    UIText name,
    UIText properties,
    CString nameStr,
    CString propertiesStr,
    ref Equip record,
    CString AddionalStr = null)
  {
    DataManager instance = DataManager.Instance;
    nameStr.ClearString();
    propertiesStr?.ClearString();
    AddionalStr?.ClearString();
    bool flag1 = GameConstants.IsBigStyle();
    bool flag2 = false;
    EItemType eitemType = (EItemType) ((uint) record.EquipKind - 1U);
    switch (eitemType)
    {
      case EItemType.EIT_SingleNumSynEquip:
      case EItemType.EIT_MultiNumSynEquip:
        nameStr.Append(instance.mStringTable.GetStringByID((uint) record.EquipName));
        if (propertiesStr != null)
        {
          CString cstring = StringManager.Instance.StaticString1024();
          for (int index = 0; index < record.PropertiesInfo.Length; ++index)
          {
            if (record.PropertiesInfo[index].Propertieskey != (ushort) 0)
            {
              if (index > 0)
                propertiesStr.Append("\n");
              int propertiesValue = (int) record.PropertiesInfo[index].PropertiesValue;
              cstring.ClearString();
              Effect recordByKey = instance.EffectData.GetRecordByKey(record.PropertiesInfo[index].Propertieskey);
              cstring.IntToFormat((long) propertiesValue);
              cstring.AppendFormat(instance.mStringTable.GetStringByID((uint) recordByKey.String_infoID));
              propertiesStr.Append(cstring);
            }
          }
          break;
        }
        break;
      case EItemType.EIT_SynBook:
        nameStr.StringToFormat(instance.mStringTable.GetStringByID((uint) record.EquipName));
        nameStr.StringToFormat(instance.mStringTable.GetStringByID(88U));
        if (flag1)
          nameStr.AppendFormat("{0}{1}");
        else
          nameStr.AppendFormat("{0} {1}");
        if (propertiesStr != null)
        {
          propertiesStr.StringToFormat(instance.mStringTable.GetStringByID(89U));
          propertiesStr.StringToFormat(instance.mStringTable.GetStringByID((uint) record.EquipName));
          propertiesStr.AppendFormat("{0}{1}");
          break;
        }
        break;
      case EItemType.EIT_SynBaseEquip:
        nameStr.StringToFormat(instance.mStringTable.GetStringByID((uint) record.EquipName));
        if (record.SyntheticParts[1].SyntheticItemNum == (byte) 1)
        {
          nameStr.StringToFormat(instance.mStringTable.GetStringByID(88U));
          nameStr.StringToFormat(instance.mStringTable.GetStringByID(90U));
          if (flag1)
            nameStr.AppendFormat("{0}{1}{2}");
          else
            nameStr.AppendFormat("{0} {1} {2}");
        }
        else
        {
          nameStr.StringToFormat(instance.mStringTable.GetStringByID(90U));
          if (flag1)
            nameStr.AppendFormat("{0}{1}");
          else
            nameStr.AppendFormat("{0} {1}");
        }
        if (propertiesStr != null)
        {
          propertiesStr.IntToFormat((long) record.SyntheticParts[0].SyntheticItemNum);
          propertiesStr.AppendFormat(instance.mStringTable.GetStringByID(91U));
          propertiesStr.StringToFormat(instance.mStringTable.GetStringByID(89U));
          propertiesStr.StringToFormat(instance.mStringTable.GetStringByID((uint) record.EquipName));
          if (record.SyntheticParts[1].SyntheticItemNum == (byte) 1)
          {
            propertiesStr.StringToFormat(instance.mStringTable.GetStringByID(88U));
            propertiesStr.AppendFormat("{0}{1}{2}");
            break;
          }
          propertiesStr.AppendFormat("{0}{1}");
          break;
        }
        break;
      case EItemType.EIT_HeroStone:
        nameStr.StringToFormat(instance.mStringTable.GetStringByID((uint) record.EquipName));
        nameStr.StringToFormat(instance.mStringTable.GetStringByID(92U));
        if (flag1)
          nameStr.AppendFormat("{0}{1}");
        else
          nameStr.AppendFormat("{0} {1}");
        Hero recordByKey1 = instance.HeroTable.GetRecordByKey(record.SyntheticParts[0].SyntheticItem);
        if ((int) recordByKey1.HeroKey == (int) record.SyntheticParts[0].SyntheticItem)
        {
          if (propertiesStr != null)
          {
            int x = 0;
            int num = (int) recordByKey1.defaultStar >= instance.Medal.Length ? instance.Medal.Length : (int) recordByKey1.defaultStar;
            for (int index = 0; index < num; ++index)
              x += (int) instance.Medal[index];
            propertiesStr.IntToFormat((long) x);
            propertiesStr.StringToFormat(instance.mStringTable.GetStringByID((uint) record.EquipName));
            propertiesStr.AppendFormat(instance.mStringTable.GetStringByID(93U));
          }
          if (AddionalStr != null)
          {
            AddionalStr.Append("\n");
            AddionalStr.StringToFormat(instance.mStringTable.GetStringByID(367U));
            AddionalStr.StringToFormat(instance.mStringTable.GetStringByID(3841U + (uint) recordByKey1.SoldierKind));
            AddionalStr.AppendFormat("{0} : <color=#FFC961FF>{1}</color>\n");
            AddionalStr.StringToFormat(instance.mStringTable.GetStringByID(369U));
            AddionalStr.AppendFormat("{0}:\n");
            CString Content = StringManager.Instance.StaticString1024();
            for (int index = 0; index < 3; ++index)
            {
              ushort InKey;
              byte RankStr;
              if (index == 0)
              {
                InKey = recordByKey1.GroupSkill2;
                RankStr = (byte) 2;
              }
              else if (index == 1)
              {
                InKey = recordByKey1.GroupSkill3;
                RankStr = (byte) 4;
              }
              else
              {
                InKey = recordByKey1.GroupSkill4;
                RankStr = (byte) 7;
              }
              Skill recordByKey2 = instance.SkillTable.GetRecordByKey(InKey);
              Content.ClearString();
              GUIManager.Instance.m_SkillInfo.GetLegionHintStr((byte) 5, ref recordByKey2, ref Content, RankStr);
              Content.Append("\n");
              AddionalStr.Append(Content);
            }
            AddionalStr.StringToFormat(instance.mStringTable.GetStringByID(61U));
            AddionalStr.AppendFormat("<color=#FFFF00FF>{0}</color>");
            break;
          }
          break;
        }
        break;
      case EItemType.EIT_Consumables:
        nameStr.Append(instance.mStringTable.GetStringByID((uint) record.EquipName));
        if (propertiesStr != null)
        {
          propertiesStr.Append(instance.mStringTable.GetStringByID((uint) record.EquipInfo));
          break;
        }
        break;
      case EItemType.EIT_SellItem:
        nameStr.Append(instance.mStringTable.GetStringByID((uint) record.EquipName));
        if (propertiesStr != null)
        {
          propertiesStr.IntToFormat((long) record.RecoverPrice);
          propertiesStr.AppendFormat(instance.mStringTable.GetStringByID(118U));
          break;
        }
        break;
      case EItemType.EIT_CaseByCase:
        if ((byte) record.PropertiesInfo[0].Propertieskey == (byte) 45)
        {
          flag2 = true;
          nameStr.StringToFormat(instance.mStringTable.GetStringByID((uint) record.EquipName));
          nameStr.StringToFormat(instance.mStringTable.GetStringByID(14669U));
          if (flag1)
            nameStr.AppendFormat("{0}{1}");
          else
            nameStr.AppendFormat("{0} {1}");
          if (propertiesStr != null)
          {
            propertiesStr.StringToFormat(instance.mStringTable.GetStringByID((uint) record.SyntheticParts[1].SyntheticItem));
            propertiesStr.AppendFormat(instance.mStringTable.GetStringByID(11692U));
            break;
          }
          break;
        }
        nameStr.Append(instance.mStringTable.GetStringByID((uint) record.EquipName));
        break;
      case EItemType.EIT_MaterialTreasureBox:
        if (record.PropertiesInfo[0].Propertieskey != (ushort) 4 && record.PropertiesInfo[2].Propertieskey > (ushort) 3)
        {
          nameStr.StringToFormat(instance.mStringTable.GetStringByID(7734U + (uint) record.PropertiesInfo[0].Propertieskey));
          nameStr.AppendFormat(instance.mStringTable.GetStringByID(7739U));
        }
        nameStr.Append(instance.mStringTable.GetStringByID((uint) record.EquipName));
        break;
      default:
        if (eitemType == EItemType.EIT_EnhanceStone)
        {
          nameStr.StringToFormat(instance.mStringTable.GetStringByID((uint) record.EquipName));
          nameStr.StringToFormat(instance.mStringTable.GetStringByID(16072U));
          if (flag1)
            nameStr.AppendFormat("{0}{1}");
          else
            nameStr.AppendFormat("{0} {1}");
          if (propertiesStr != null)
          {
            propertiesStr.Append(instance.mStringTable.GetStringByID((uint) record.EquipInfo));
            break;
          }
          break;
        }
        nameStr.Append(instance.mStringTable.GetStringByID((uint) record.EquipName));
        break;
    }
    if (!flag2 && propertiesStr != null && record.EquipKind >= (byte) 10 && record.EquipKind <= (byte) 19)
      propertiesStr.Append(instance.mStringTable.GetStringByID((uint) record.EquipInfo));
    if ((bool) (Object) properties)
    {
      properties.text = propertiesStr.ToString();
      properties.SetAllDirty();
      properties.cachedTextGenerator.Invalidate();
      properties.cachedTextGeneratorForLayout.Invalidate();
    }
    if (!(bool) (Object) name)
      return;
    name.text = nameStr.ToString();
    name.SetAllDirty();
    name.cachedTextGenerator.Invalidate();
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (Object) menu)
    {
      img.sprite = menu.LoadSprite(ImageName);
      ((MaskableGraphic) img).material = menu.LoadMaterial();
      if (!((Object) img.sprite == (Object) null))
        return;
      img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
      ((MaskableGraphic) img).material = GUIManager.Instance.GetFrameMaterial();
    }
    else
    {
      img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
      ((MaskableGraphic) img).material = GUIManager.Instance.GetFrameMaterial();
    }
  }

  public void OnVauleChang(UnitResourcesSlider sender)
  {
    this.Cstr.ClearString();
    StringManager.IntToStr(this.Cstr, sender.Value, bNumber: true);
    sender.m_inputText.text = this.Cstr.ToString();
    sender.m_inputText.SetAllDirty();
    sender.m_inputText.cachedTextGenerator.Invalidate();
    this.m_Quantity = (ushort) sender.Value;
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(this.m_ItemBtn.HIID);
    this.PriceStr.ClearString();
    this.PriceStr.IntToFormat((long) (recordByKey.RecoverPrice * (uint) this.m_Quantity), bNumber: true);
    this.PriceStr.AppendFormat("{0}");
    this.m_Price.text = this.PriceStr.ToString();
    this.m_Price.SetAllDirty();
    this.m_Price.cachedTextGenerator.Invalidate();
  }

  public bool UpdateRun(float delta)
  {
    if (!((Component) this.m_RectTransform).gameObject.activeSelf)
      return false;
    if (this.DelayCloseSynthesis > (byte) 0)
    {
      --this.DelayCloseSynthesis;
      if (this.DelayCloseSynthesis == (byte) 0)
      {
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
        this.Show(this.m_eItemInfo, this.m_ItemID, this.m_HeroID, this.m_EquipPos);
      }
    }
    if (((Component) this.Gleam).gameObject.activeSelf)
    {
      float num = this.GleamTime / 1f;
      if ((double) num <= 1.0)
        this.Gleam.alpha = 1f - num;
      else if ((double) num <= 2.0)
        this.Gleam.alpha = num - 1f;
      else
        this.GleamTime = 0.0f;
      this.GleamTime += Time.deltaTime;
    }
    return true;
  }

  public void UpdatePosition(float delta)
  {
    if (!((Component) this.m_RectTransform).gameObject.activeSelf)
      return;
    float d = 0.3f;
    this.m_InfoPanel.anchoredPosition = this.m_InfoPanel.anchoredPosition with
    {
      y = EasingEffect.Linear(delta, this.StartPos.y, this.DestPos.y - this.StartPos.y, d)
    };
  }

  public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
  {
    URS.Value = mValue;
    URS.m_slider.value = (double) this.slider.Value;
  }

  public void OnTextChang(UnitResourcesSlider sender)
  {
    this.Cstr.ClearString();
    StringManager.IntToStr(this.Cstr, sender.Value, bNumber: true);
    sender.m_inputText.text = this.Cstr.ToString();
    sender.m_inputText.SetAllDirty();
    sender.m_inputText.cachedTextGenerator.Invalidate();
    this.m_Quantity = (ushort) sender.Value;
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(this.m_ItemBtn.HIID);
    this.PriceStr.ClearString();
    this.PriceStr.IntToFormat((long) (recordByKey.RecoverPrice * (uint) this.m_Quantity), bNumber: true);
    this.PriceStr.AppendFormat("{0}");
    this.m_Price.text = this.PriceStr.ToString();
    this.m_Price.SetAllDirty();
    this.m_Price.cachedTextGenerator.Invalidate();
  }

  private enum UIController
  {
    Background,
    InfoPanel,
  }

  private enum InfoPanel
  {
    Background,
    Obj,
    Name,
    Owner,
    Kind,
    Properties,
    Info,
    Sell,
    Make,
    Quantity,
  }
}
