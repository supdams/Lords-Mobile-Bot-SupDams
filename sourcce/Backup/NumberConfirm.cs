// Decompiled with JetBrains decompiler
// Type: NumberConfirm
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class NumberConfirm : UIBagFilterBase, IUICalculatorHandler, IUIUnitRSliderHandler
{
  private ushort ItemID;
  private EItemType eType;
  private UnitResourcesSlider slider;
  private UISpritesArray SpriteArray;
  private UIText MaxQtyStr;
  private UIText TipText;
  private UIText ExpChange;
  private UIText TitleText;
  private UIText TimeMsgText;
  private UIText ItemNameText;
  private RectTransform TipImageRect;
  private RectTransform InputRect;
  private RectTransform SlashRect;
  private CSlider AutouseSlider;
  private CString QtyStr;
  private CString TimeStr;
  private CString NameTitle;
  private CString ItemNameStr;
  private CString Cstr;
  private CString TimeMsgStr;
  private CString TipStr;
  private byte QuequIndex;
  private byte saveRoleLv;
  private byte RoleExpRatio;
  private byte bFreeSpeedup;
  private byte petRare;
  private UIButtonHint InfoHint;
  private GameObject InfoImgObj;
  private CanvasGroup InfoCanvasGroup;
  private float DeltaTime;
  private NumberConfirm._UseType UseType;
  private ushort OriginExpRatio;
  private uint MaxUseCount = (uint) ushort.MaxValue;
  private uint ItemAddVal;
  private Color TimeMsgColor;
  private RectTransform BackgroundRect;
  private RectTransform LineImageRect;
  private RectTransform ItemRect;
  private RectTransform OkRect;
  private RectTransform CancelRect;
  private float SliderTop = -287.2f;
  private float SliderInputTop = -237.6f;
  private uint RemainRss;
  private uint NeedRss;
  private Image MsgIcon;
  private Image TipImage;
  private ResourceType NeedResourceType;

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager instance1 = GUIManager.Instance;
    DataManager instance2 = DataManager.Instance;
    Font ttfFont = instance1.GetTTFFont();
    this.ThisTransform = this.transform.GetChild(this.transform.childCount - 1);
    this.ItemID = (ushort) arg1;
    if (instance1.bOpenOnIPhoneX)
    {
      RectTransform component = this.ThisTransform.GetChild(0).GetComponent<RectTransform>();
      component.offsetMin = new Vector2(component.offsetMin.x - instance1.IPhoneX_DeltaX, component.offsetMin.y);
      component.offsetMax = new Vector2(component.offsetMax.x + instance1.IPhoneX_DeltaX, component.offsetMax.y);
    }
    this.BackgroundRect = this.ThisTransform.GetChild(1).GetChild(0).GetComponent<RectTransform>();
    this.LineImageRect = this.ThisTransform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
    this.MsgIcon = this.ThisTransform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>();
    this.UseType = NumberConfirm._UseType.Normal;
    this.QtyStr = StringManager.Instance.SpawnString();
    this.TimeStr = StringManager.Instance.SpawnString(100);
    this.NameTitle = StringManager.Instance.SpawnString();
    this.Cstr = StringManager.Instance.SpawnString();
    this.TimeMsgStr = StringManager.Instance.SpawnString(100);
    this.ItemNameStr = StringManager.Instance.SpawnString(100);
    this.TipStr = StringManager.Instance.SpawnString(150);
    UIButton component1 = this.ThisTransform.GetChild(0).GetComponent<UIButton>();
    component1.m_BtnID1 = 1;
    component1.m_Handler = (IUIButtonClickHandler) this;
    this.SlashRect = this.ThisTransform.GetChild(7).GetChild(0).GetComponent<RectTransform>();
    this.ItemRect = ((Component) this.ThisTransform.GetChild(4).GetComponent<UIHIBtn>()).GetComponent<RectTransform>();
    instance1.InitianHeroItemImg((Transform) this.ItemRect, eHeroOrItem.Item, this.ItemID, (byte) 0, (byte) 0, bShowText: false);
    this.AddRefreshText((Text) ((Transform) this.ItemRect).GetChild(4).GetComponent<UIText>());
    Equip recordByKey1 = instance2.EquipTable.GetRecordByKey(this.ItemID);
    this.eType = (EItemType) ((uint) recordByKey1.EquipKind - 1U);
    bool flag = this.eType >= EItemType.EIT_AllianceTreasureBox && this.eType <= EItemType.EIT_ComboTreasureBox;
    int num1 = (int) instance2.GetCurItemQuantity(this.ItemID, (byte) 0);
    int num2 = 1;
    UIButton component2 = this.ThisTransform.GetChild(9).GetComponent<UIButton>();
    component2.m_BtnID1 = 0;
    component2.m_Handler = (IUIButtonClickHandler) this;
    this.OkRect = ((Component) component2).GetComponent<RectTransform>();
    UIButton component3 = this.ThisTransform.GetChild(10).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 1;
    this.CancelRect = ((Component) component3).GetComponent<RectTransform>();
    this.ItemNameText = this.ThisTransform.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.ItemNameText.font = ttfFont;
    this.ItemNameText.text = instance2.mStringTable.GetStringByID((uint) recordByKey1.EquipName);
    this.AddRefreshText((Text) this.ItemNameText);
    if (this.eType == EItemType.EIT_MaterialTreasureBox && recordByKey1.PropertiesInfo[0].Propertieskey == (ushort) 4)
      num2 = Mathf.Clamp(num1, 1, 100);
    else if (this.eType == EItemType.EIT_MaterialTreasureBox && (recordByKey1.PropertiesInfo[2].Propertieskey < (ushort) 1 || recordByKey1.PropertiesInfo[2].Propertieskey > (ushort) 3))
    {
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.StringToFormat(instance2.mStringTable.GetStringByID(7734U + (uint) recordByKey1.PropertiesInfo[0].Propertieskey));
      cstring.AppendFormat(instance2.mStringTable.GetStringByID(7739U));
      cstring.Append(instance2.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
      this.ItemNameStr.ClearString();
      this.ItemNameStr.Append(cstring);
      this.ItemNameText.text = this.ItemNameStr.ToString();
      this.ItemNameText.SetAllDirty();
      this.ItemNameText.cachedTextGenerator.Invalidate();
      num2 = Mathf.Clamp(num1, 1, 100);
    }
    this.TitleText = this.ThisTransform.GetChild(2).GetChild(1).GetComponent<UIText>();
    this.TitleText.text = !flag ? instance2.mStringTable.GetStringByID(283U) : instance2.mStringTable.GetStringByID(234U);
    this.TitleText.font = ttfFont;
    this.AddRefreshText((Text) this.TitleText);
    this.TipText = this.ThisTransform.GetChild(8).GetComponent<UIText>();
    this.TipText.font = ttfFont;
    this.AddRefreshText((Text) this.TipText);
    this.TipImageRect = this.ThisTransform.GetChild(8).GetChild(0).GetComponent<RectTransform>();
    this.TipImage = ((Component) this.TipImageRect).GetComponent<Image>();
    this.TimeMsgText = this.ThisTransform.GetChild(2).GetChild(2).GetComponent<UIText>();
    this.TimeMsgText.font = ttfFont;
    this.AddRefreshText((Text) this.TimeMsgText);
    UIText component4 = this.ThisTransform.GetChild(9).GetChild(0).GetComponent<UIText>();
    component4.text = instance2.mStringTable.GetStringByID(94U);
    component4.font = ttfFont;
    this.AddRefreshText((Text) component4);
    UIText component5 = this.ThisTransform.GetChild(10).GetChild(0).GetComponent<UIText>();
    component5.text = instance2.mStringTable.GetStringByID(4U);
    component5.font = ttfFont;
    this.AddRefreshText((Text) component5);
    this.MaxQtyStr = this.ThisTransform.GetChild(6).GetComponent<UIText>();
    this.MaxQtyStr.font = ttfFont;
    this.AddRefreshText((Text) this.MaxQtyStr);
    this.UseTargetID = (ushort) arg2;
    this.SpriteArray = this.ThisTransform.GetChild(11).GetComponent<UISpritesArray>();
    byte equipKind = recordByKey1.EquipKind;
    byte num3 = 0;
    byte num4 = (byte) ((uint) equipKind - 1U);
    this.QuequIndex = instance1.BagTagSaved[9];
    switch (num4)
    {
      case 5:
        this.ItemAddVal = (uint) recordByKey1.PropertiesInfo[0].PropertiesValue;
        int num5;
        string stringById;
        if (PetManager.Instance.IsPetItem(this.ItemID))
        {
          PetData petData = PetManager.Instance.FindPetData(this.UseTargetID);
          if (petData == null)
          {
            this.slider = this.ThisTransform.GetChild(5).gameObject.AddComponent<UnitResourcesSlider>();
            this.slider.gameObject.SetActive(false);
            return;
          }
          this.petRare = petData.Rare;
          if (this.petRare > (byte) 0 && this.petRare <= (byte) 5)
            --this.petRare;
          else
            this.petRare = (byte) 0;
          PetExpTbl recordByKey2 = PetManager.Instance.PetExpTable.GetRecordByKey((ushort) petData.Level);
          if (petData.Level >= (byte) 60)
            this.OriginExpRatio = (ushort) 0;
          else if (recordByKey2.ExpValue[(int) this.petRare] > 0U)
            this.OriginExpRatio = (ushort) (petData.Exp * 100U / recordByKey2.ExpValue[(int) this.petRare]);
          if ((int) recordByKey2.ExpValue[(int) this.petRare] - (int) petData.Exp == 1)
            this.OriginExpRatio = (ushort) 99;
          num5 = Mathf.Clamp(this.GetMaxPetExpItems(), 0, num1);
          this.UseType = NumberConfirm._UseType.PetExp;
          stringById = instance2.mStringTable.GetStringByID((uint) PetManager.Instance.PetTable.GetRecordByKey(petData.ID).Name);
          instance1.InitianHeroItemImg(this.ThisTransform.GetChild(3).GetChild(0), eHeroOrItem.Pet, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
          instance1.ChangeHeroItemImg(this.ThisTransform.GetChild(3).GetChild(0), eHeroOrItem.Pet, petData.ID, petData.Enhance, (byte) 0);
        }
        else
        {
          CurHeroData curHeroData = instance2.curHeroData.Find((uint) this.UseTargetID);
          LevelUp recordByKey3 = instance2.LevelUpTable.GetRecordByKey((ushort) curHeroData.Level);
          this.OriginExpRatio = (ushort) (curHeroData.Exp * 100U / recordByKey3.HeroExp);
          if ((int) recordByKey3.HeroExp - (int) curHeroData.Exp == 1)
            this.OriginExpRatio = (ushort) 99;
          num5 = Mathf.Clamp(this.GetMaxHerExpItems(), 0, num1);
          this.UseType = NumberConfirm._UseType.Hero;
          stringById = instance2.mStringTable.GetStringByID((uint) instance2.HeroTable.GetRecordByKey(curHeroData.ID).HeroTitle);
          instance1.InitianHeroItemImg(this.ThisTransform.GetChild(3).GetChild(0), eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
          instance1.ChangeHeroItemImg(this.ThisTransform.GetChild(3).GetChild(0), eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, (byte) 0);
        }
        if (num5 == 0 && num1 > 0)
          num3 = (byte) 1;
        num1 = num5;
        this.ThisTransform.GetChild(3).gameObject.SetActive(true);
        this.ThisTransform.GetChild(8).GetChild(0).gameObject.SetActive(false);
        this.ThisTransform.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(true);
        RectTransform component6 = this.ThisTransform.GetChild(4).GetComponent<RectTransform>();
        Vector2 anchoredPosition1 = component6.anchoredPosition;
        anchoredPosition1.Set(-148f, 74.5f);
        component6.anchoredPosition = anchoredPosition1;
        Vector2 anchoredPosition2 = ((Graphic) this.ItemNameText).rectTransform.anchoredPosition;
        anchoredPosition2.Set(50.3f, 339.21f);
        ((Graphic) this.ItemNameText).rectTransform.anchoredPosition = anchoredPosition2;
        this.TipText = this.ThisTransform.GetChild(2).GetChild(1).GetComponent<UIText>();
        Vector2 anchoredPosition3 = ((Graphic) this.TipText).rectTransform.anchoredPosition;
        anchoredPosition3.Set(0.8f, -66.5f);
        ((Graphic) this.TipText).rectTransform.anchoredPosition = anchoredPosition3;
        this.NameTitle.ClearString();
        this.NameTitle.StringToFormat(stringById);
        this.NameTitle.AppendFormat(instance2.mStringTable.GetStringByID(246U));
        UIText component7 = this.ThisTransform.GetChild(3).GetChild(1).GetComponent<UIText>();
        component7.text = this.NameTitle.ToString();
        component7.font = ttfFont;
        this.AddRefreshText((Text) component7);
        this.ExpChange = this.ThisTransform.GetChild(3).GetChild(2).GetComponent<UIText>();
        this.ExpChange.text = instance2.mStringTable.GetStringByID(4U);
        this.ExpChange.font = ttfFont;
        this.AddRefreshText((Text) this.ExpChange);
        break;
      case 10:
        this.ThisTransform.GetChild(8).GetChild(0).gameObject.SetActive(true);
        if (recordByKey1.PropertiesInfo[0].Propertieskey <= (ushort) 7)
        {
          this.TipImage.sprite = this.SpriteArray.GetSprite(4 + (int) recordByKey1.PropertiesInfo[0].Propertieskey);
          this.MsgIcon.sprite = this.SpriteArray.GetSprite(4 + (int) recordByKey1.PropertiesInfo[0].Propertieskey);
        }
        else
        {
          this.TipImage.sprite = this.SpriteArray.GetSprite(13);
          this.MsgIcon.sprite = this.SpriteArray.GetSprite(13);
        }
        this.TipImage.SetNativeSize();
        this.MsgIcon.SetNativeSize();
        this.NeedResourceType = (ResourceType) ((uint) recordByKey1.PropertiesInfo[0].Propertieskey - 1U);
        ((Graphic) this.TipText).color = new Color(0.0f, 1f, 0.8f);
        ((Graphic) this.TipText).rectTransform.sizeDelta = new Vector2(((Graphic) this.TipText).rectTransform.sizeDelta.x - 32f, ((Graphic) this.TipText).rectTransform.sizeDelta.y);
        ((Graphic) this.TipText).rectTransform.anchoredPosition = new Vector2(((Graphic) this.TipText).rectTransform.anchoredPosition.x + 16f, ((Graphic) this.TipText).rectTransform.anchoredPosition.y);
        break;
      default:
        this.ThisTransform.GetChild(8).GetChild(0).gameObject.SetActive(false);
        break;
    }
    switch (num4)
    {
      case 9:
        if (recordByKey1.PropertiesInfo[0].Propertieskey == (ushort) 30)
        {
          this.bFreeSpeedup = (byte) 3;
          this.SetTimeUI();
          ((Graphic) this.TimeMsgText).color = Color.white;
          this.ItemAddVal = (uint) recordByKey1.PropertiesInfo[1].Propertieskey * (uint) recordByKey1.PropertiesInfo[1].PropertiesValue;
          num2 = (int) Mathf.Clamp((float) ((instance2.GetMaxMonsterPoint() - instance2.RoleAttr.MonsterPoint) / this.ItemAddVal), 1f, (float) num1);
          if (num1 > num2)
          {
            num1 = num2 + 1;
            break;
          }
          break;
        }
        if (recordByKey1.PropertiesInfo[0].Propertieskey == (ushort) 40)
        {
          ((Component) this.TipImageRect).gameObject.SetActive(true);
          this.TipImage.sprite = this.SpriteArray.GetSprite(12);
          ((Component) this.TipImageRect).GetComponent<Image>().SetNativeSize();
          if (instance2.RoleAttr.ScardStar < 100000000U)
          {
            uint num6 = 100000000U - instance2.RoleAttr.ScardStar;
            int num7 = (int) recordByKey1.PropertiesInfo[1].Propertieskey * (int) recordByKey1.PropertiesInfo[1].PropertiesValue;
            int num8 = (int) Mathf.Min((float) ((long) num6 / (long) num7) + Mathf.Clamp((float) ((long) num6 % (long) num7), 0.0f, 1f), (float) ushort.MaxValue);
            if (num1 > num8)
              num1 = num8;
            num2 = num1;
            break;
          }
          num2 = num1 = 0;
          break;
        }
        if (recordByKey1.PropertiesInfo[0].Propertieskey == (ushort) 49)
        {
          this.ThisTransform.GetChild(8).GetChild(0).gameObject.SetActive(true);
          this.TipImage.sprite = this.SpriteArray.GetSprite(13);
          this.MsgIcon.sprite = this.SpriteArray.GetSprite(13);
          this.TipImage.SetNativeSize();
          this.MsgIcon.SetNativeSize();
          this.NeedResourceType = (ResourceType) ((uint) recordByKey1.PropertiesInfo[0].Propertieskey - 1U);
          ((Graphic) this.TipText).color = new Color(0.0f, 1f, 0.8f);
          ((Graphic) this.TipText).rectTransform.sizeDelta = new Vector2(((Graphic) this.TipText).rectTransform.sizeDelta.x - 32f, ((Graphic) this.TipText).rectTransform.sizeDelta.y);
          ((Graphic) this.TipText).rectTransform.anchoredPosition = new Vector2(((Graphic) this.TipText).rectTransform.anchoredPosition.x + 16f, ((Graphic) this.TipText).rectTransform.anchoredPosition.y);
          break;
        }
        break;
      case 11:
        this.SetTimeUI();
        int num9 = (int) (instance2.queueBarData[(int) this.QuequIndex].StartTime + (long) instance2.queueBarData[(int) this.QuequIndex].TotalTime - instance2.ServerTime - (long) this.GetFreeCompleteTime());
        if (num9 < 0)
          num9 = 0;
        int num10 = 60 * (int) recordByKey1.PropertiesInfo[1].Propertieskey;
        int num11 = num9 / num10 + Mathf.Clamp(num9 % num10, 0, 1);
        if (num11 <= num1)
        {
          num1 = num11;
          num2 = num9 / num10;
          if (num2 == 0)
          {
            ++num2;
            break;
          }
          break;
        }
        num2 = num1;
        break;
      case 12:
        num2 = num1;
        break;
      case 16:
      case 17:
      case 18:
        num2 = Mathf.Clamp(num1, 1, 100);
        if (recordByKey1.PropertiesInfo[0].Propertieskey == (ushort) 5)
        {
          if ((UnityEngine.Object) this.InfoHint == (UnityEngine.Object) null)
            this.InfoHint = this.ThisTransform.GetChild(4).GetComponent<UIButtonHint>();
          if ((UnityEngine.Object) this.InfoImgObj == (UnityEngine.Object) null)
          {
            this.InfoImgObj = this.ThisTransform.GetChild(4).GetChild(0).gameObject;
            this.InfoCanvasGroup = this.ThisTransform.GetChild(4).GetChild(0).GetChild(0).GetComponent<CanvasGroup>();
            this.InfoImgObj.transform.SetAsLastSibling();
          }
          this.InfoHint.GetComponent<UIHIBtn>().m_Handler = (IUIHIBtnClickHandler) this;
          instance1.SetItemScaleClickSound(this.InfoHint.GetComponent<UIHIBtn>(), true, true);
          this.InfoHint.enabled = false;
          this.InfoImgObj.SetActive(true);
          this.UseType = NumberConfirm._UseType.Pet;
          break;
        }
        break;
    }
    if ((this.UseType == NumberConfirm._UseType.Hero || this.UseType == NumberConfirm._UseType.PetExp) && num1 == 0 && num3 == (byte) 0)
    {
      instance1.AddHUDMessage(instance2.mStringTable.GetStringByID(744U), (ushort) byte.MaxValue);
      this.OnClose();
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0);
    }
    else
    {
      this.slider = this.ThisTransform.GetChild(5).gameObject.AddComponent<UnitResourcesSlider>();
      instance1.InitUnitResourcesSlider(this.slider.transform, eUnitSlider.AutoUse, 0U, 0U);
      instance1.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnLessen, 210.5f, this.SliderTop, 70f, 60f, 0.0f, 0.0f);
      if (flag)
        instance1.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 384.5f, this.SliderTop, 257f, 19f, 0.0f, (float) Mathf.Clamp(num1, 1, 100));
      else
        instance1.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 384.5f, this.SliderTop, 257f, 19f, 0.0f, (float) num1);
      instance1.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnIncrease, 541.2f, this.SliderTop, 70f, 60f, 0.0f, 0.0f);
      instance1.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.Input, 328f, this.SliderInputTop, 94f, 35f, 0.0f, 0.0f);
      this.InputRect = this.slider.transform.GetChild(3).GetComponent<RectTransform>();
      this.slider.transform.GetChild(1).GetComponent<Image>().preserveAspect = true;
      this.slider.transform.GetChild(0).GetComponent<Image>().preserveAspect = true;
      this.slider.BtnInputText.m_Handler = (IUIButtonClickHandler) this;
      this.slider.BtnInputText.m_BtnID1 = 2;
      UIText component8 = this.ThisTransform.GetChild(5).GetChild(3).GetChild(0).GetComponent<UIText>();
      component8.fontSize = 24;
      component8.alignment = TextAnchor.MiddleRight;
      this.AddRefreshText((Text) component8);
      this.slider.m_Handler = (IUIUnitRSliderHandler) this;
      this.QtyStr.ClearString();
      this.QtyStr.IntToFormat((long) num1, bNumber: true);
      this.QtyStr.AppendFormat("{0}");
      this.MaxQtyStr.text = this.QtyStr.ToString();
      Material material = ((MaskableGraphic) this.ThisTransform.GetChild(1).GetChild(0).GetComponent<Image>()).material;
      Image component9 = this.ThisTransform.GetChild(5).GetChild(3).GetComponent<Image>();
      ((MaskableGraphic) component9).material = material;
      component9.sprite = this.SpriteArray.GetSprite(0);
      Image component10 = this.ThisTransform.GetChild(5).GetChild(0).GetComponent<Image>();
      ((MaskableGraphic) component10).material = material;
      component10.sprite = this.SpriteArray.GetSprite(1);
      Image component11 = this.ThisTransform.GetChild(5).GetChild(0).GetChild(0).GetComponent<Image>();
      ((MaskableGraphic) component11).material = material;
      component11.sprite = this.SpriteArray.GetSprite(1);
      Image component12 = this.ThisTransform.GetChild(5).GetChild(1).GetComponent<Image>();
      ((MaskableGraphic) component12).material = material;
      component12.sprite = this.SpriteArray.GetSprite(2);
      Image component13 = this.ThisTransform.GetChild(5).GetChild(1).GetChild(0).GetComponent<Image>();
      ((MaskableGraphic) component13).material = material;
      component13.sprite = this.SpriteArray.GetSprite(2);
      Image component14 = this.ThisTransform.GetChild(5).GetChild(2).GetChild(0).GetComponent<Image>();
      ((MaskableGraphic) component14).material = material;
      component14.sprite = this.SpriteArray.GetSprite(3);
      Image component15 = this.ThisTransform.GetChild(5).GetChild(2).GetChild(1).GetChild(0).GetComponent<Image>();
      ((MaskableGraphic) component15).material = material;
      component15.sprite = this.SpriteArray.GetSprite(3);
      Image component16 = this.ThisTransform.GetChild(5).GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>();
      ((MaskableGraphic) component16).material = material;
      component16.sprite = this.SpriteArray.GetSprite(4);
      if (instance1.IsArabic)
        ((Transform) this.SlashRect).localScale = new Vector3(-1f, 1f, 1f);
      this.AutouseSlider = this.ThisTransform.GetChild(5).GetChild(2).GetComponent<CSlider>();
      this.AutouseSlider.value = (double) num2;
      this.slider.Value = (long) num2;
      this.UpdateHeroExpText();
      this.UpdatePetExpText();
      this.UpdateResource();
      this.UpdateExp();
      this.UpdateVip();
      this.OnTextChang(this.slider);
      this.UpdateTipText();
    }
  }

  private void SetTimeUI()
  {
    this.BackgroundRect.sizeDelta = new Vector2(507f, 447f);
    this.LineImageRect.anchoredPosition = new Vector2(-204f, 131f);
    ((Component) this.TimeMsgText).gameObject.SetActive(true);
    this.ItemRect.anchoredPosition = new Vector2(-148f, 83f);
    ((Graphic) this.ItemNameText).rectTransform.anchoredPosition = new Vector2(51f, 337f);
    this.SliderTop = -322.2f;
    this.SliderInputTop = -272.6f;
    if (((Component) this.TipImageRect).gameObject.activeSelf)
      ((Graphic) this.TipText).rectTransform.anchoredPosition = new Vector2(17.8f, -100f);
    else
      ((Graphic) this.TipText).rectTransform.anchoredPosition = new Vector2(1.8f, -100f);
    this.TipText.fontSize = 18;
    ((Graphic) this.TitleText).rectTransform.anchoredPosition = new Vector2(3f, 32.5f);
    ((Graphic) this.MaxQtyStr).rectTransform.anchoredPosition = new Vector2(101f, -5f);
    this.OkRect.anchoredPosition = new Vector2(115.5f, -163f);
    this.CancelRect.anchoredPosition = new Vector2(-111.5f, -163f);
    ((Component) this.MsgIcon).gameObject.SetActive(false);
    this.SlashRect.anchoredPosition = new Vector2(11.6f, -2.8f);
  }

  public override void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (this.slider.Value > 0L)
        {
          if (this.UseType == NumberConfirm._UseType.Normal)
          {
            GUIManager.Instance.bContinuousUse = true;
            DataManager.Instance.UseItem(this.ItemID, (ushort) this.slider.Value, this.UseTargetID, (ushort) 0, (ushort) 0, 0U, string.Empty);
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0);
            break;
          }
          if (this.UseType == NumberConfirm._UseType.Pet)
          {
            if (!GUIManager.Instance.ShowUILock(EUILock.UseItem))
              break;
            MessagePacket messagePacket = new MessagePacket((ushort) 1024);
            messagePacket.Protocol = Protocol._MSG_REQUEST_PET_OPENPETBOX;
            messagePacket.AddSeqId();
            messagePacket.Add(this.ItemID);
            messagePacket.Add(this.slider.Value);
            messagePacket.Send();
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetList, 16);
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0);
            break;
          }
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroUse, 0);
          DataManager.Instance.UseItem(this.ItemID, (ushort) this.slider.Value, this.UseTargetID, (ushort) 0, (ushort) 0, 0U, string.Empty);
          break;
        }
        if (this.MaxUseCount != 0U)
          break;
        if (this.UseType == NumberConfirm._UseType.Hero)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(533U), (ushort) byte.MaxValue);
          break;
        }
        if (this.UseType != NumberConfirm._UseType.PetExp)
          break;
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(16041U), (ushort) byte.MaxValue);
        break;
      case 1:
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0);
        break;
      case 2:
        GUIManager.Instance.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
        GUIManager.Instance.m_UICalculator.OpenCalculator(this.slider.MaxValue, this.slider.Value, 290.22f, -25.96f, this.slider, 0L);
        break;
    }
  }

  public override void OnHIButtonClick(UIHIBtn sender)
  {
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_OpenBox, 1, (int) this.ItemID);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0);
  }

  public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
  {
    URS.Value = mValue;
    URS.m_slider.value = (double) this.slider.Value;
    this.UpdateResource();
    this.UpdateExp();
    this.UpdateVip();
    this.UpdateHeroExpText();
    this.UpdatePetExpText();
    this.UpdateTipText();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    if (meg[0] == (byte) 35 && (UnityEngine.Object) this.slider != (UnityEngine.Object) null)
      this.slider.Refresh_FontTexture();
    if (this.bFreeSpeedup == (byte) 2 && meg[0] == (byte) 7 || meg[0] == (byte) 40)
    {
      int needResourceType = (int) this.NeedResourceType;
      if (needResourceType < DataManager.Instance.Resource.Length)
      {
        this.RemainRss = DataManager.Instance.Resource[needResourceType].Stock;
      }
      else
      {
        if (needResourceType != 8)
          return;
        this.RemainRss = DataManager.Instance.PetResource.Stock;
      }
      this.UpdateResource();
    }
    else
    {
      if (this.bFreeSpeedup != (byte) 3 || meg[0] != (byte) 34)
        return;
      this.UpdateTipText();
    }
  }

  public override void UpdateUI(int arge1, int arge2)
  {
    if (arge1 == -1)
      return;
    if ((arge1 & 1073741824) > 0)
    {
      this.bFreeSpeedup = (byte) (arge1 & -1073741825);
      this.TimeMsgColor = this.bFreeSpeedup != (byte) 0 ? new Color(0.773f, 0.447f, 1f) : new Color(0.0f, 1f, 0.8f);
      this.ItemUIUpdate((int) this.ItemID, (int) this.UseTargetID);
      this.UpdateFreeTimeStr();
      this.OnTextChang(this.slider);
    }
    else
    {
      if (this.UseType != NumberConfirm._UseType.Normal)
        return;
      this.ItemUIUpdate(arge1, arge2);
    }
  }

  public void ItemUIUpdate(int arge1, int arge2)
  {
    GUIManager instance1 = GUIManager.Instance;
    DataManager instance2 = DataManager.Instance;
    this.UseType = NumberConfirm._UseType.Normal;
    this.ItemID = (ushort) arge1;
    instance1.ChangeHeroItemImg((Transform) this.ItemRect, eHeroOrItem.Item, this.ItemID, (byte) 0, (byte) 0);
    this.QtyStr.ClearString();
    this.QuequIndex = instance1.BagTagSaved[9];
    ((Component) this.TipImageRect).gameObject.SetActive(false);
    int num1 = (int) instance2.GetCurItemQuantity(this.ItemID, (byte) 0);
    int num2 = 1;
    Equip recordByKey = instance2.EquipTable.GetRecordByKey(this.ItemID);
    this.eType = (EItemType) ((uint) recordByKey.EquipKind - 1U);
    bool flag = this.eType >= EItemType.EIT_AllianceTreasureBox && this.eType <= EItemType.EIT_ComboTreasureBox;
    this.TitleText.text = !flag ? instance2.mStringTable.GetStringByID(283U) : instance2.mStringTable.GetStringByID(234U);
    this.ItemNameText.text = instance2.mStringTable.GetStringByID((uint) recordByKey.EquipName);
    if (this.eType == EItemType.EIT_MaterialTreasureBox && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 4)
      num2 = Mathf.Clamp(num1, 1, 100);
    else if (recordByKey.EquipKind == (byte) 18 && (recordByKey.PropertiesInfo[2].Propertieskey < (ushort) 1 || recordByKey.PropertiesInfo[2].Propertieskey > (ushort) 3))
    {
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.StringToFormat(instance2.mStringTable.GetStringByID(7734U + (uint) recordByKey.PropertiesInfo[0].Propertieskey));
      cstring.AppendFormat(instance2.mStringTable.GetStringByID(7739U));
      cstring.Append(instance2.mStringTable.GetStringByID((uint) recordByKey.EquipName));
      this.ItemNameStr.ClearString();
      this.ItemNameStr.Append(cstring);
      this.ItemNameText.text = this.ItemNameStr.ToString();
      this.ItemNameText.SetAllDirty();
      this.ItemNameText.cachedTextGenerator.Invalidate();
      num2 = Mathf.Clamp(num1, 1, 100);
    }
    else if (recordByKey.EquipKind == (byte) 12)
    {
      int num3 = (int) (instance2.queueBarData[(int) this.QuequIndex].StartTime + (long) instance2.queueBarData[(int) this.QuequIndex].TotalTime - instance2.ServerTime - (long) this.GetFreeCompleteTime());
      if (num3 < 0)
        num3 = 0;
      int num4 = 60 * (int) recordByKey.PropertiesInfo[1].Propertieskey;
      int num5 = num3 / num4 + Mathf.Clamp(num3 % num4, 0, 1);
      if (num5 <= num1)
      {
        num1 = num5;
        num2 = num3 / num4;
        if (num2 == 0)
          ++num2;
      }
      else
        num2 = num1;
    }
    else if (recordByKey.EquipKind == (byte) 13)
      num2 = num1;
    else if (recordByKey.EquipKind == (byte) 17 || recordByKey.EquipKind == (byte) 18 || recordByKey.EquipKind == (byte) 19)
      num2 = Mathf.Clamp(num1, 1, 100);
    else if (recordByKey.EquipKind == (byte) 10)
    {
      if (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 30)
      {
        this.ItemAddVal = (uint) recordByKey.PropertiesInfo[1].Propertieskey * (uint) recordByKey.PropertiesInfo[1].PropertiesValue;
        num2 = (int) Mathf.Clamp((float) ((instance2.GetMaxMonsterPoint() - instance2.RoleAttr.MonsterPoint) / this.ItemAddVal), 1f, (float) num1);
        if (num1 > num2)
          num1 = num2 + 1;
      }
      else if (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 40)
      {
        ((Component) this.TipImageRect).gameObject.SetActive(true);
        this.TipImage.sprite = this.SpriteArray.GetSprite(12);
        this.TipImage.SetNativeSize();
        if (instance2.RoleAttr.ScardStar < 100000000U)
        {
          uint num6 = 100000000U - instance2.RoleAttr.ScardStar;
          int num7 = (int) recordByKey.PropertiesInfo[1].Propertieskey * (int) recordByKey.PropertiesInfo[1].PropertiesValue;
          int num8 = (int) Mathf.Min((float) ((long) num6 / (long) num7) + Mathf.Clamp((float) ((long) num6 % (long) num7), 0.0f, 1f), (float) ushort.MaxValue);
          if (num1 > num8)
            num1 = num8;
          num2 = num1;
        }
        else
          num2 = num1 = 0;
      }
    }
    if (flag)
      instance1.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 384.5f, this.SliderTop, 257f, 19f, 0.0f, (float) Mathf.Clamp(num1, 1, 100));
    else
      instance1.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 384.5f, this.SliderTop, 257f, 19f, 0.0f, (float) num1);
    this.slider.m_slider.value = (double) num2;
    this.AutouseSlider.value = this.slider.m_slider.value;
    this.slider.Value = (long) this.slider.m_slider.value;
    if (recordByKey.EquipKind == (byte) 11)
    {
      ((Component) this.TipImageRect).gameObject.SetActive(true);
      if (recordByKey.PropertiesInfo[0].Propertieskey <= (ushort) 7)
      {
        this.TipImage.sprite = this.SpriteArray.GetSprite(4 + (int) recordByKey.PropertiesInfo[0].Propertieskey);
        this.MsgIcon.sprite = this.SpriteArray.GetSprite(4 + (int) recordByKey.PropertiesInfo[0].Propertieskey);
      }
      else
      {
        this.TipImage.sprite = this.SpriteArray.GetSprite(13);
        this.MsgIcon.sprite = this.SpriteArray.GetSprite(13);
      }
      this.TipImage.SetNativeSize();
      this.MsgIcon.SetNativeSize();
      this.NeedResourceType = (ResourceType) ((uint) recordByKey.PropertiesInfo[0].Propertieskey - 1U);
    }
    this.QtyStr.IntToFormat((long) num1, bNumber: true);
    this.QtyStr.AppendFormat("{0}");
    this.MaxQtyStr.text = this.QtyStr.ToString();
    this.UpdateResource();
    this.UpdateExp();
    this.UpdateVip();
    this.UpdateTipText();
  }

  public void SetNeedItemQty(uint Remain, uint Need)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    Equip recordByKey = instance1.EquipTable.GetRecordByKey(this.ItemID);
    this.ItemAddVal = (uint) recordByKey.PropertiesInfo[1].Propertieskey * (uint) recordByKey.PropertiesInfo[1].PropertiesValue;
    if (Remain >= Need)
      return;
    int curItemQuantity = (int) instance1.GetCurItemQuantity(this.ItemID, (byte) 0);
    this.RemainRss = Remain;
    this.NeedRss = Need;
    this.slider.m_slider.value = (double) Mathf.Clamp((float) ((this.NeedRss - this.RemainRss) / this.ItemAddVal), 1f, (float) curItemQuantity);
    this.AutouseSlider.value = this.slider.m_slider.value;
    this.slider.Value = (long) this.slider.m_slider.value;
    this.bFreeSpeedup = (byte) 2;
    this.SetTimeUI();
    ((Component) this.MsgIcon).gameObject.SetActive(true);
    instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnLessen, 210.5f, this.SliderTop, 70f, 60f, 0.0f, 0.0f);
    instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 384.5f, this.SliderTop, 257f, 19f, 0.0f, (float) curItemQuantity);
    instance2.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnIncrease, 541.2f, this.SliderTop, 70f, 60f, 0.0f, 0.0f);
    this.InputRect.anchoredPosition = new Vector2(328f, this.SliderInputTop);
    this.InputRect.sizeDelta = new Vector2(94f, 35f);
    this.OnTextChang(this.slider);
  }

  public void OnVauleChang(UnitResourcesSlider sender)
  {
    this.Cstr.ClearString();
    StringManager.IntToStr(this.Cstr, sender.Value, bNumber: true);
    sender.m_inputText.text = this.Cstr.ToString();
    sender.m_inputText.SetAllDirty();
    sender.m_inputText.cachedTextGenerator.Invalidate();
    this.UpdateResource();
    this.UpdateExp();
    this.UpdateVip();
    this.UpdateHeroExpText();
    this.UpdatePetExpText();
    this.UpdateTipText();
  }

  public void OnTextChang(UnitResourcesSlider sender)
  {
    this.Cstr.ClearString();
    StringManager.IntToStr(this.Cstr, sender.Value, bNumber: true);
    sender.m_inputText.text = this.Cstr.ToString();
    sender.m_inputText.SetAllDirty();
    sender.m_inputText.cachedTextGenerator.Invalidate();
    this.UpdateHeroExpText();
    this.UpdatePetExpText();
    this.UpdateResource();
    this.UpdateExp();
    this.UpdateVip();
    this.UpdateTipText();
  }

  public override void OnClose()
  {
    if (this.QtyStr == null)
      return;
    StringManager.Instance.DeSpawnString(this.QtyStr);
    StringManager.Instance.DeSpawnString(this.TimeStr);
    StringManager.Instance.DeSpawnString(this.NameTitle);
    StringManager.Instance.DeSpawnString(this.Cstr);
    StringManager.Instance.DeSpawnString(this.ItemNameStr);
    StringManager.Instance.DeSpawnString(this.TimeMsgStr);
    StringManager.Instance.DeSpawnString(this.TipStr);
    this.QtyStr = (CString) null;
  }

  public void UpdateTipText()
  {
    if (this.UseType == NumberConfirm._UseType.Hero || this.UseType == NumberConfirm._UseType.PetExp)
      return;
    float num1 = 0.0f;
    DataManager instance = DataManager.Instance;
    Equip recordByKey = instance.EquipTable.GetRecordByKey(this.ItemID);
    CString cstring = StringManager.Instance.StaticString1024();
    this.TipStr.ClearString();
    ((Graphic) this.TipText).color = new Color(0.0f, 1f, 0.8f);
    if (recordByKey.EquipKind == (byte) 11)
    {
      if (this.slider.Value == (long) this.MaxUseCount)
      {
        ((Graphic) this.TipText).color = new Color(1f, 0.29f, 0.459f);
        this.TipStr.Append(instance.mStringTable.GetStringByID(898U));
      }
      else
      {
        ((Graphic) this.TipText).color = Color.white;
        cstring.IntToFormat((long) (uint) ((ulong) ((int) recordByKey.PropertiesInfo[1].Propertieskey * (int) recordByKey.PropertiesInfo[1].PropertiesValue) * (ulong) this.slider.Value), bNumber: true);
        cstring.AppendFormat("{0}");
        this.TipStr.StringToFormat(cstring);
        this.TipStr.AppendFormat(instance.mStringTable.GetStringByID(231U));
        if (this.bFreeSpeedup == (byte) 2 && (long) this.NeedRss < (long) this.RemainRss + (long) this.ItemAddVal * this.slider.Value)
        {
          ((Graphic) this.TipText).color = new Color(1f, 0.53f, 0.56f);
          this.TipStr.Append(" ");
          this.TipStr.Append(instance.mStringTable.GetStringByID(973U));
        }
      }
    }
    else if (recordByKey.EquipKind == (byte) 12 && ((byte) recordByKey.PropertiesInfo[0].Propertieskey == (byte) 1 || (byte) recordByKey.PropertiesInfo[0].Propertieskey == (byte) 12 || (byte) recordByKey.PropertiesInfo[0].Propertieskey == (byte) 17 || (byte) recordByKey.PropertiesInfo[0].Propertieskey == (byte) 18 || (byte) recordByKey.PropertiesInfo[0].Propertieskey == (byte) 21 || (byte) recordByKey.PropertiesInfo[0].Propertieskey == (byte) 22))
    {
      ((Graphic) this.TipText).color = Color.white;
      this.ItemAddVal = (uint) recordByKey.PropertiesInfo[1].Propertieskey;
      TimeSpan timeSpan = new TimeSpan((long) (60U * this.ItemAddVal) * this.slider.Value * 10000000L);
      this.TimeStr.ClearString();
      if (timeSpan.Days > 0)
      {
        this.TimeStr.IntToFormat((long) timeSpan.Days);
        this.TimeStr.IntToFormat((long) timeSpan.Hours, 2);
        this.TimeStr.IntToFormat((long) timeSpan.Minutes, 2);
        this.TimeStr.IntToFormat((long) timeSpan.Seconds, 2);
        this.TimeStr.AppendFormat("{0}d:{1}:{2}:{3}");
      }
      else if (timeSpan.Ticks > 0L)
      {
        if (timeSpan.Hours > 0)
        {
          this.TimeStr.IntToFormat((long) timeSpan.Hours, 2);
          this.TimeStr.IntToFormat((long) timeSpan.Minutes, 2);
          this.TimeStr.IntToFormat((long) timeSpan.Seconds, 2);
          this.TimeStr.AppendFormat("{0}:{1}:{2}");
        }
        else if (timeSpan.Minutes > 0)
        {
          this.TimeStr.IntToFormat((long) timeSpan.Minutes, 2);
          this.TimeStr.IntToFormat((long) timeSpan.Seconds, 2);
          this.TimeStr.AppendFormat("{0}:{1}");
        }
      }
      else
      {
        this.TimeStr.SetChar(0, '0');
        this.TimeStr.SetChar(1, char.MinValue);
      }
      this.TipStr.StringToFormat(this.TimeStr);
      this.TipStr.AppendFormat(instance.mStringTable.GetStringByID(232U));
      if (instance.queueBarData[(int) this.QuequIndex].StartTime + (long) instance.queueBarData[(int) this.QuequIndex].TotalTime - instance.ServerTime < timeSpan.Ticks / 10000000L)
      {
        ((Graphic) this.TipText).color = new Color(1f, 0.53f, 0.56f);
        this.TipStr.Append(" ");
        this.TipStr.Append(instance.mStringTable.GetStringByID(233U));
      }
      this.UpdateFreeTimeStr();
    }
    else if (recordByKey.EquipKind == (byte) 10)
    {
      if (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 33)
      {
        cstring.Append("<color=#FFFFFFFF>");
        cstring.IntToFormat((long) instance.RoleAttr.Level);
        cstring.IntToFormat((long) Mathf.Clamp((int) this.OriginExpRatio, 0, 99));
        cstring.IntToFormat((long) this.saveRoleLv);
        cstring.IntToFormat((long) Mathf.Clamp((int) this.RoleExpRatio, 0, 99));
        cstring.AppendFormat(instance.mStringTable.GetStringByID(531U));
        cstring.Append("</color>");
        if (this.saveRoleLv == (byte) 60)
        {
          cstring.StringToFormat(" <color=#ff4a75ff>");
          cstring.StringToFormat(instance.mStringTable.GetStringByID(898U));
          cstring.StringToFormat("</color>");
          cstring.AppendFormat("{0}{1}{2}");
        }
        this.TipStr.Append(cstring);
      }
      else if (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 30)
      {
        string str = (string) null;
        this.TimeMsgStr.ClearString();
        uint num2 = (uint) ((ulong) ((int) recordByKey.PropertiesInfo[1].Propertieskey * (int) recordByKey.PropertiesInfo[1].PropertiesValue) * (ulong) this.slider.Value);
        GameConstants.FormatResourceValue(cstring, num2);
        uint x = instance.RoleAttr.MonsterPoint + num2;
        if (x > instance.GetMaxMonsterPoint())
        {
          ((Graphic) this.TipText).color = new Color(1f, 0.29f, 0.459f);
          str = instance.mStringTable.GetStringByID(906U);
          this.TimeMsgStr.Append("<color=#ff4a75ff>");
        }
        else
        {
          ((Graphic) this.TipText).color = Color.white;
          this.TimeMsgStr.Append("<color=#ffffffff>");
        }
        this.TipStr.StringToFormat(cstring);
        this.TipStr.AppendFormat(instance.mStringTable.GetStringByID(905U));
        if (str != null)
        {
          this.TipStr.Append(" ");
          this.TipStr.Append(str);
        }
        if (GUIManager.Instance.IsArabic)
        {
          this.TimeMsgStr.ClearString();
          this.TimeMsgStr.IntToFormat((long) x, bNumber: true);
          this.TimeMsgStr.IntToFormat((long) instance.GetMaxMonsterPoint(), bNumber: true);
          this.TimeMsgStr.StringToFormat("</color>");
          if (x > instance.GetMaxMonsterPoint())
            this.TimeMsgStr.StringToFormat("<color=#ff4a75ff>");
          else
            this.TimeMsgStr.StringToFormat("<color=#ffffffff>");
          this.TimeMsgStr.AppendFormat("{1}/{3}{0}{2}");
        }
        else
        {
          this.TimeMsgStr.IntToFormat((long) x, bNumber: true);
          this.TimeMsgStr.StringToFormat("</color>");
          this.TimeMsgStr.IntToFormat((long) instance.GetMaxMonsterPoint(), bNumber: true);
          this.TimeMsgStr.AppendFormat("{0}{1}/{2}");
        }
        this.TimeMsgText.text = this.TimeMsgStr.ToString();
        this.TimeMsgText.SetAllDirty();
        this.TimeMsgText.cachedTextGenerator.Invalidate();
      }
      else if (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 40)
      {
        int num3 = (int) recordByKey.PropertiesInfo[1].Propertieskey * (int) recordByKey.PropertiesInfo[1].PropertiesValue;
        cstring.Append("<color=#FFFFFFFF>");
        cstring.IntToFormat(this.slider.Value * (long) num3, bNumber: true);
        cstring.AppendFormat(instance.mStringTable.GetStringByID(231U));
        cstring.Append("</color>");
        this.TipStr.Append(cstring);
        num1 = -4f;
      }
      else if (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 49)
      {
        if (this.slider.Value == (long) this.MaxUseCount)
        {
          ((Graphic) this.TipText).color = new Color(1f, 0.29f, 0.459f);
          this.TipStr.Append(instance.mStringTable.GetStringByID(898U));
        }
        else
        {
          ((Graphic) this.TipText).color = Color.white;
          cstring.IntToFormat((long) (uint) ((ulong) ((int) recordByKey.PropertiesInfo[1].Propertieskey * (int) recordByKey.PropertiesInfo[1].PropertiesValue) * (ulong) this.slider.Value), bNumber: true);
          cstring.AppendFormat("{0}");
          this.TipStr.StringToFormat(cstring);
          this.TipStr.AppendFormat(instance.mStringTable.GetStringByID(231U));
          if (this.bFreeSpeedup == (byte) 2 && (long) this.NeedRss < (long) this.RemainRss + (long) this.ItemAddVal * this.slider.Value)
          {
            ((Graphic) this.TipText).color = new Color(1f, 0.53f, 0.56f);
            this.TipStr.Append(" ");
            this.TipStr.Append(instance.mStringTable.GetStringByID(973U));
          }
        }
      }
    }
    else if (recordByKey.EquipKind == (byte) 13)
    {
      cstring.Append("<color=#FFFFFFFF>");
      cstring.IntToFormat((long) instance.RoleAttr.VIPLevel);
      cstring.IntToFormat((long) Mathf.Clamp((int) this.OriginExpRatio, 0, 99));
      cstring.IntToFormat((long) this.saveRoleLv);
      cstring.IntToFormat((long) this.RoleExpRatio);
      cstring.AppendFormat(instance.mStringTable.GetStringByID(620U));
      cstring.Append("</color>");
      if ((int) this.saveRoleLv == (int) instance.RoleAttr.VIPLevelMax)
      {
        cstring.StringToFormat(" <color=#ff4a75ff>");
        cstring.StringToFormat(instance.mStringTable.GetStringByID(898U));
        cstring.StringToFormat("</color>");
        cstring.AppendFormat("{0}{1}{2}");
      }
      this.TipStr.Append(cstring);
    }
    this.TipText.text = this.TipStr.ToString();
    this.TipText.SetAllDirty();
    this.TipText.cachedTextGenerator.Invalidate();
    this.TipText.cachedTextGeneratorForLayout.Invalidate();
    Vector2 anchoredPosition = this.TipImageRect.anchoredPosition with
    {
      x = (float) (-(double) this.TipText.preferredWidth * 0.5 - (double) this.TipImageRect.sizeDelta.x * 0.5)
    };
    anchoredPosition.x += num1;
    if ((double) anchoredPosition.x < -239.0)
      anchoredPosition.x = -239f;
    this.TipImageRect.anchoredPosition = anchoredPosition;
  }

  private void UpdateFreeTimeStr()
  {
    DataManager instance = DataManager.Instance;
    TimeSpan timeSpan = new TimeSpan((long) (60U * this.ItemAddVal) * this.slider.Value * 10000000L);
    if (instance.queueBarData[(int) this.QuequIndex].StartTime + (long) instance.queueBarData[(int) this.QuequIndex].TotalTime - instance.ServerTime < timeSpan.Ticks / 10000000L)
    {
      ((Graphic) this.TimeMsgText).color = new Color(1f, 0.53f, 0.56f);
      this.TimeMsgText.text = instance.mStringTable.GetStringByID(971U);
    }
    else if (this.bFreeSpeedup == (byte) 1 && instance.queueBarData[(int) this.QuequIndex].StartTime + (long) instance.queueBarData[(int) this.QuequIndex].TotalTime - instance.ServerTime - (long) this.GetFreeCompleteTime() <= timeSpan.Ticks / 10000000L)
    {
      ((Graphic) this.TimeMsgText).color = this.TimeMsgColor;
      this.TimeMsgText.text = instance.mStringTable.GetStringByID(970U);
    }
    else
    {
      ((Graphic) this.TimeMsgText).color = this.TimeMsgColor;
      timeSpan = new TimeSpan((instance.queueBarData[(int) this.QuequIndex].StartTime + (long) instance.queueBarData[(int) this.QuequIndex].TotalTime - instance.ServerTime - (long) this.GetFreeCompleteTime() - (long) (60U * this.ItemAddVal) * this.slider.Value) * 10000000L);
      CString tmpS = StringManager.Instance.StaticString1024();
      if (timeSpan.Days > 0)
      {
        tmpS.IntToFormat((long) timeSpan.Days);
        tmpS.IntToFormat((long) timeSpan.Hours, 2);
        tmpS.IntToFormat((long) timeSpan.Minutes, 2);
        tmpS.IntToFormat((long) timeSpan.Seconds, 2);
        tmpS.AppendFormat("{0}d:{1}:{2}:{3}");
      }
      else if (timeSpan.Ticks > 0L)
      {
        if (timeSpan.Hours > 0)
        {
          tmpS.IntToFormat((long) timeSpan.Hours, 2);
          tmpS.IntToFormat((long) timeSpan.Minutes, 2);
          tmpS.IntToFormat((long) timeSpan.Seconds, 2);
          tmpS.AppendFormat("{0}:{1}:{2}");
        }
        else if (timeSpan.Minutes > 0)
        {
          tmpS.IntToFormat((long) timeSpan.Minutes, 2);
          tmpS.IntToFormat((long) timeSpan.Seconds, 2);
          tmpS.AppendFormat("{0}:{1}");
        }
        else
        {
          tmpS.IntToFormat((long) timeSpan.Seconds, 2);
          tmpS.AppendFormat("00:{0}");
        }
      }
      else
      {
        tmpS.SetChar(0, '0');
        tmpS.SetChar(1, char.MinValue);
      }
      this.TimeMsgStr.ClearString();
      this.TimeMsgStr.StringToFormat(tmpS);
      if (this.bFreeSpeedup == (byte) 1)
        this.TimeMsgStr.AppendFormat(instance.mStringTable.GetStringByID(969U));
      else
        this.TimeMsgStr.AppendFormat(instance.mStringTable.GetStringByID(972U));
      this.TimeMsgText.text = this.TimeMsgStr.ToString();
      this.TimeMsgText.SetAllDirty();
      this.TimeMsgText.cachedTextGenerator.Invalidate();
    }
  }

  private ushort GetFreeCompleteTime()
  {
    return this.bFreeSpeedup == (byte) 0 ? (ushort) 0 : DataManager.Instance.GetFreeCompleteTime();
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!this.ThisTransform.gameObject.activeSelf)
      return;
    if (bOnSecond && this.bFreeSpeedup < (byte) 2 && ((Component) this.TimeMsgText).gameObject.activeSelf)
      this.UpdateFreeTimeStr();
    if (!((UnityEngine.Object) this.InfoImgObj != (UnityEngine.Object) null) || !this.InfoImgObj.activeSelf)
      return;
    this.DeltaTime += Time.deltaTime;
    if ((double) this.DeltaTime >= 2.0)
      this.DeltaTime = 0.0f;
    this.InfoCanvasGroup.alpha = (double) this.DeltaTime <= 1.0 ? this.DeltaTime : 2f - this.DeltaTime;
  }

  public void UpdateResource()
  {
    switch (this.eType)
    {
      case EItemType.EIT_CaseByCase:
        if ((byte) DataManager.Instance.EquipTable.GetRecordByKey(this.ItemID).PropertiesInfo[0].Propertieskey != (byte) 49)
          break;
        goto case EItemType.EIT_Resource;
      case EItemType.EIT_Resource:
        DataManager instance = DataManager.Instance;
        Equip recordByKey = instance.EquipTable.GetRecordByKey(this.ItemID);
        this.MaxUseCount = 0U;
        uint num1 = (uint) recordByKey.PropertiesInfo[1].Propertieskey * (uint) recordByKey.PropertiesInfo[1].PropertiesValue;
        uint num2 = 0;
        if ((int) recordByKey.PropertiesInfo[0].Propertieskey <= instance.Resource.Length)
          num2 = uint.MaxValue - instance.Resource[(int) recordByKey.PropertiesInfo[0].Propertieskey - 1].Stock;
        else if (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 6)
          num2 = uint.MaxValue - instance.RoleAttr.Diamond;
        else if ((byte) recordByKey.PropertiesInfo[0].Propertieskey == (byte) 49)
          num2 = uint.MaxValue - instance.PetResource.Stock;
        if (num2 >= num1)
        {
          this.MaxUseCount = num2 / num1 + (uint) Mathf.Clamp((float) (num2 % num1), 0.0f, 1f);
          if (this.slider.Value > (long) this.MaxUseCount)
            this.slider.Value = (long) this.MaxUseCount;
        }
        else
          this.slider.Value = 0L;
        this.slider.m_slider.value = (double) this.slider.Value;
        if (this.bFreeSpeedup != (byte) 2)
          break;
        this.TimeMsgStr.ClearString();
        ((Graphic) this.TimeMsgText).color = Color.white;
        if ((long) this.NeedRss > (long) this.RemainRss + (long) this.ItemAddVal * this.slider.Value)
        {
          this.TimeMsgStr.StringToFormat("<color=#ef3a54ff>");
          this.TimeMsgStr.IntToFormat((long) this.RemainRss + (long) this.ItemAddVal * this.slider.Value, bNumber: true);
          this.TimeMsgStr.StringToFormat("</color>");
          this.TimeMsgStr.IntToFormat((long) this.NeedRss, bNumber: true);
          if (GUIManager.Instance.IsArabic)
            this.TimeMsgStr.AppendFormat("{3}/{0}{1}{2}");
          else
            this.TimeMsgStr.AppendFormat("{0}{1}{2}/{3}");
        }
        else
        {
          this.TimeMsgStr.IntToFormat((long) this.RemainRss + (long) this.ItemAddVal * this.slider.Value, bNumber: true);
          this.TimeMsgStr.IntToFormat((long) this.NeedRss, bNumber: true);
          if (GUIManager.Instance.IsArabic)
            this.TimeMsgStr.AppendFormat("{1}/{0}");
          else
            this.TimeMsgStr.AppendFormat("{0}/{1}");
        }
        this.TimeMsgText.text = this.TimeMsgStr.ToString();
        this.TimeMsgText.SetAllDirty();
        this.TimeMsgText.cachedTextGenerator.Invalidate();
        this.TimeMsgText.cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.MsgIcon).rectTransform.anchoredPosition = ((Graphic) this.MsgIcon).rectTransform.anchoredPosition with
        {
          x = (float) (-(double) this.TimeMsgText.preferredWidth * 0.5 - (double) ((Graphic) this.MsgIcon).rectTransform.sizeDelta.x * 0.5)
        };
        break;
    }
  }

  public void UpdateExp()
  {
    if (this.eType != EItemType.EIT_CaseByCase)
      return;
    DataManager instance = DataManager.Instance;
    Equip recordByKey1 = instance.EquipTable.GetRecordByKey(this.ItemID);
    switch ((byte) recordByKey1.PropertiesInfo[0].Propertieskey)
    {
      case 30:
        int num1 = (int) recordByKey1.PropertiesInfo[1].Propertieskey * (int) recordByKey1.PropertiesInfo[1].PropertiesValue;
        this.MaxUseCount = 0U;
        if (instance.RoleAttr.MonsterPoint >= instance.GetMaxMonsterPoint())
          break;
        uint num2 = instance.GetMaxMonsterPoint() - instance.RoleAttr.MonsterPoint;
        this.MaxUseCount = (uint) ((ulong) num2 / (ulong) num1 + (ulong) Mathf.Clamp((int) num2 % num1, 1, 0));
        break;
      case 33:
        int num3 = (int) recordByKey1.PropertiesInfo[1].Propertieskey * (int) recordByKey1.PropertiesInfo[1].PropertiesValue;
        long num4 = (long) num3 * this.slider.Value;
        this.MaxUseCount = 0U;
        this.saveRoleLv = instance.RoleAttr.Level;
        if (this.saveRoleLv < (byte) 60)
        {
          LevelUp recordByKey2 = instance.LevelUpTable.GetRecordByKey((ushort) this.saveRoleLv);
          this.OriginExpRatio = (ushort) (instance.RoleAttr.Exp * 100U / recordByKey2.KingdomExp);
          uint num5 = recordByKey2.KingdomExp - instance.RoleAttr.Exp;
          while (num4 > 0L && this.saveRoleLv != (byte) 60)
          {
            if (num4 >= (long) num5)
            {
              num4 -= (long) num5;
              recordByKey2 = instance.LevelUpTable.GetRecordByKey((ushort) ++this.saveRoleLv);
              num5 = recordByKey2.KingdomExp;
            }
            else
            {
              num5 -= (uint) num4;
              num4 = 0L;
            }
          }
          if (num4 > 0L)
            this.slider.Value -= num4 / (long) num3;
          this.RoleExpRatio = this.saveRoleLv >= (byte) 60 ? (byte) 0 : (this.slider.Value <= 0L ? (byte) this.OriginExpRatio : (byte) ((double) (100U - num5 * 100U / recordByKey2.KingdomExp) - (double) Mathf.Clamp((float) (num5 * 100U % recordByKey2.KingdomExp), 0.0f, 1f)));
        }
        else
        {
          this.slider.Value = 0L;
          this.RoleExpRatio = (byte) 0;
          this.OriginExpRatio = (ushort) 0;
        }
        this.slider.m_slider.value = (double) this.slider.Value;
        break;
    }
  }

  private int GetMaxHerExpItems()
  {
    DataManager instance = DataManager.Instance;
    CurHeroData curHeroData = instance.curHeroData.Find((uint) this.UseTargetID);
    byte num1 = (byte) Mathf.Clamp((int) instance.RoleAttr.Level, 15, 60);
    LevelUp recordByKey = instance.LevelUpTable.GetRecordByKey((ushort) curHeroData.Level);
    if ((int) curHeroData.Level == (int) num1 && (int) curHeroData.Exp == (int) recordByKey.HeroExp - 1)
      return 0;
    byte level = curHeroData.Level;
    uint num2 = recordByKey.HeroExp - curHeroData.Exp;
    while ((int) level < (int) num1)
    {
      recordByKey = instance.LevelUpTable.GetRecordByKey((ushort) ++level);
      num2 += recordByKey.HeroExp;
    }
    return (int) (num2 / this.ItemAddVal) + Mathf.Clamp((int) (num2 % this.ItemAddVal), 0, 1);
  }

  private int GetMaxPetExpItems()
  {
    PetManager instance = PetManager.Instance;
    PetData petData = instance.FindPetData(this.UseTargetID);
    if (petData == null)
      return 0;
    byte maxLevel = petData.GetMaxLevel();
    if (petData.Level == (byte) 60)
      return 0;
    PetExpTbl recordByKey1 = instance.PetExpTable.GetRecordByKey((ushort) petData.Level);
    byte level = petData.Level;
    uint num = recordByKey1.ExpValue[(int) this.petRare] - petData.Exp;
    while ((int) level < (int) maxLevel)
    {
      PetExpTbl recordByKey2 = instance.PetExpTable.GetRecordByKey((ushort) ++level);
      if (level != (byte) 60)
        num += recordByKey2.ExpValue[(int) this.petRare];
      else
        break;
    }
    return (int) (num / this.ItemAddVal) + Mathf.Clamp((int) (num % this.ItemAddVal), 0, 1);
  }

  public void UpdateHeroExpText()
  {
    if (this.UseType != NumberConfirm._UseType.Hero)
      return;
    DataManager instance = DataManager.Instance;
    CurHeroData curHeroData = instance.curHeroData.Find((uint) this.UseTargetID);
    byte num1 = (byte) Mathf.Clamp((int) instance.RoleAttr.Level, 15, 60);
    LevelUp recordByKey = instance.LevelUpTable.GetRecordByKey((ushort) curHeroData.Level);
    uint num2 = (uint) ((ulong) curHeroData.Exp + (ulong) this.ItemAddVal * (ulong) this.slider.Value);
    byte num3 = 0;
    byte x1;
    if (num2 < recordByKey.HeroExp)
    {
      x1 = curHeroData.Level;
    }
    else
    {
      while (num2 >= recordByKey.HeroExp && (int) curHeroData.Level + (int) num3 + 1 <= (int) num1)
      {
        ++num3;
        num2 -= recordByKey.HeroExp;
        byte InKey = (byte) ((uint) curHeroData.Level + (uint) num3);
        recordByKey = instance.LevelUpTable.GetRecordByKey((ushort) InKey);
        if ((int) InKey >= (int) num1)
          break;
      }
      x1 = (byte) ((uint) num3 + (uint) curHeroData.Level);
    }
    float x2 = (float) ((double) num2 / (double) recordByKey.HeroExp * 100.0);
    if ((int) x1 == (int) num1 && (double) x2 > 100.0)
    {
      this.TipText.text = instance.mStringTable.GetStringByID(533U);
      ((Graphic) this.TipText).color = new Color(1f, 0.29f, 0.459f);
      long num4 = 1;
      for (float num5 = x2; (double) num5 >= 100.0; num5 = (float) (((double) num2 - (double) ((long) this.ItemAddVal * num4++)) / ((double) recordByKey.HeroExp - 1.0) * 100.0))
        x2 = num5;
      this.slider.Value = this.slider.Value - num4 + 2L;
      x2 = Mathf.Clamp(x2, 0.0f, 99.999f);
      this.MaxUseCount = (uint) this.slider.Value;
      this.slider.m_slider.value = (double) this.slider.Value;
    }
    else if (this.slider.Value != (long) this.MaxUseCount)
    {
      this.TipText.text = instance.mStringTable.GetStringByID(283U);
      ((Graphic) this.TipText).color = new Color(1f, 1f, 1f);
    }
    else
    {
      this.TipText.text = instance.mStringTable.GetStringByID(533U);
      ((Graphic) this.TipText).color = new Color(1f, 0.29f, 0.459f);
    }
    if ((int) recordByKey.HeroExp - (int) num2 == 1 && (int) num1 == (int) curHeroData.Level)
      x2 = 99f;
    this.TimeStr.ClearString();
    this.TimeStr.IntToFormat((long) curHeroData.Level);
    this.TimeStr.IntToFormat((long) this.OriginExpRatio);
    this.TimeStr.IntToFormat((long) x1);
    this.TimeStr.IntToFormat((long) (int) x2);
    this.TimeStr.AppendFormat(instance.mStringTable.GetStringByID(531U));
    this.ExpChange.text = this.TimeStr.ToString();
    this.ExpChange.SetAllDirty();
    this.ExpChange.cachedTextGenerator.Invalidate();
  }

  public void UpdatePetExpText()
  {
    if (this.UseType != NumberConfirm._UseType.PetExp)
      return;
    PetManager instance1 = PetManager.Instance;
    DataManager instance2 = DataManager.Instance;
    PetData petData = instance1.FindPetData(this.UseTargetID);
    if (petData == null)
      return;
    byte maxLevel = petData.GetMaxLevel();
    PetExpTbl recordByKey = instance1.PetExpTable.GetRecordByKey((ushort) petData.Level);
    uint num1 = (uint) ((ulong) petData.Exp + (ulong) this.ItemAddVal * (ulong) this.slider.Value);
    byte num2 = 0;
    byte x1;
    if (num1 < recordByKey.ExpValue[(int) this.petRare])
    {
      x1 = petData.Level;
    }
    else
    {
      while (num1 >= recordByKey.ExpValue[(int) this.petRare] && (int) petData.Level + (int) num2 + 1 <= (int) maxLevel)
      {
        ++num2;
        num1 -= recordByKey.ExpValue[(int) this.petRare];
        byte InKey = (byte) ((uint) petData.Level + (uint) num2);
        recordByKey = instance1.PetExpTable.GetRecordByKey((ushort) InKey);
        if ((int) InKey >= (int) maxLevel)
          break;
      }
      x1 = (byte) ((uint) num2 + (uint) petData.Level);
    }
    float x2 = (float) ((double) num1 / (double) recordByKey.ExpValue[(int) this.petRare] * 100.0);
    if (petData.Level == (byte) 60)
    {
      this.slider.Value = 0L;
      this.MaxUseCount = 0U;
    }
    if (x1 == (byte) 60)
    {
      this.TipText.text = instance2.mStringTable.GetStringByID(16041U);
      ((Graphic) this.TipText).color = new Color(1f, 0.29f, 0.459f);
      x2 = 0.0f;
    }
    else if ((int) x1 == (int) maxLevel && (double) x2 >= 100.0)
    {
      this.TipText.text = x1 == (byte) 20 && petData.Enhance == (byte) 0 || x1 == (byte) 50 && petData.Enhance == (byte) 1 ? instance2.mStringTable.GetStringByID(17099U) : instance2.mStringTable.GetStringByID(17140U);
      ((Graphic) this.TipText).color = new Color(1f, 0.29f, 0.459f);
      long num3 = 1;
      for (float num4 = x2; (double) num4 >= 100.0; num4 = (float) (((double) num1 - (double) ((long) this.ItemAddVal * num3++)) / ((double) recordByKey.ExpValue[(int) this.petRare] - 1.0) * 100.0))
        x2 = num4;
      this.slider.Value = this.slider.Value - num3 + 2L;
      x2 = Mathf.Clamp(x2, 0.0f, 99.999f);
      this.MaxUseCount = (uint) this.slider.Value;
      this.slider.m_slider.value = (double) this.slider.Value;
    }
    else if (this.slider.Value != (long) this.MaxUseCount)
    {
      this.TipText.text = instance2.mStringTable.GetStringByID(283U);
      ((Graphic) this.TipText).color = new Color(1f, 1f, 1f);
    }
    if ((int) recordByKey.ExpValue[(int) this.petRare] - (int) num1 == 1 && (int) maxLevel == (int) petData.Level)
      x2 = 99f;
    this.TimeStr.ClearString();
    this.TimeStr.IntToFormat((long) petData.Level);
    this.TimeStr.IntToFormat((long) this.OriginExpRatio);
    this.TimeStr.IntToFormat((long) x1);
    this.TimeStr.IntToFormat((long) (int) x2);
    this.TimeStr.AppendFormat(instance2.mStringTable.GetStringByID(531U));
    this.ExpChange.text = this.TimeStr.ToString();
    this.ExpChange.SetAllDirty();
    this.ExpChange.cachedTextGenerator.Invalidate();
  }

  public void UpdateVip()
  {
    if (this.eType != EItemType.EIT_VIP)
      return;
    DataManager instance = DataManager.Instance;
    Equip recordByKey1 = instance.EquipTable.GetRecordByKey(this.ItemID);
    this.saveRoleLv = instance.RoleAttr.VIPLevel;
    uint vipPoint = instance.VIPLevelTable.GetRecordByKey((ushort) --this.saveRoleLv).VIPPoint;
    VIP_DataTbl recordByKey2 = instance.VIPLevelTable.GetRecordByKey((ushort) ++this.saveRoleLv);
    this.OriginExpRatio = (int) instance.RoleAttr.VIPLevel >= (int) instance.RoleAttr.VIPLevelMax ? (ushort) 0 : (ushort) ((uint) (((int) instance.RoleAttr.VipPoint - (int) vipPoint) * 100) / (recordByKey2.VIPPoint - vipPoint));
    this.RoleExpRatio = (byte) this.OriginExpRatio;
    int propertieskey = (int) recordByKey1.PropertiesInfo[1].Propertieskey;
    if ((int) instance.RoleAttr.VIPLevel < (int) instance.RoleAttr.VIPLevelMax)
    {
      while ((long) instance.RoleAttr.VipPoint + this.slider.Value * (long) propertieskey >= (long) recordByKey2.VIPPoint)
      {
        vipPoint = recordByKey2.VIPPoint;
        recordByKey2 = instance.VIPLevelTable.GetRecordByKey((ushort) ++this.saveRoleLv);
        if ((int) this.saveRoleLv >= (int) instance.RoleAttr.VIPLevelMax)
          goto label_5;
      }
      this.RoleExpRatio = (byte) ((ulong) (((long) instance.RoleAttr.VipPoint + this.slider.Value * (long) propertieskey - (long) vipPoint) * 100L) / (ulong) (recordByKey2.VIPPoint - vipPoint));
label_5:
      if ((int) this.saveRoleLv == (int) instance.RoleAttr.VIPLevelMax)
      {
        this.RoleExpRatio = (byte) 0;
        this.MaxUseCount = (uint) ((ulong) (recordByKey2.VIPPoint - instance.RoleAttr.VipPoint) / (ulong) propertieskey + (ulong) Mathf.Clamp(((int) recordByKey2.VIPPoint - (int) instance.RoleAttr.VipPoint) % propertieskey, 0, 1));
        if ((long) this.MaxUseCount < this.slider.Value)
          this.slider.Value = (long) this.MaxUseCount;
      }
    }
    else
      this.slider.Value = 0L;
    this.slider.m_slider.value = (double) this.slider.Value;
  }

  private enum UIControl : byte
  {
    MaskImage,
    Background,
    Title,
    Hero,
    HiBtn,
    Slider,
    MaxQty,
    ArabicRot,
    Tip,
    Confirm,
    Cancel,
    SpriteArray,
  }

  private enum UISliderControl
  {
    Increase,
    Decrease,
    Slider,
    Input,
  }

  private enum ClickType
  {
    Confirm,
    Cancel,
    InputText,
  }

  private enum _UseType
  {
    Normal = 0,
    Hero = 1,
    Pet = 2,
    PetExp = 4,
  }
}
