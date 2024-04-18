// Decompiled with JetBrains decompiler
// Type: BuyNumConfirm
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class BuyNumConfirm : UIBagFilterBase, IUICalculatorHandler, IUIUnitRSliderHandler
{
  private UIText NumText;
  private UIText ItemNameText;
  private UIText TitleText;
  private UIText TipText;
  private CString NumStr;
  private CString TipStr;
  private CString Cstr;
  private UnitResourcesSlider slider;
  private CSlider AutouseSlider;
  private Image MsgIcon;
  private UISpritesArray SpriteArray;
  private RectTransform ItemRect;
  private ushort ItemID;
  private ushort ItemSN;
  private byte StoreType;

  void IUIUnitRSliderHandler.OnVauleChang(UnitResourcesSlider sender)
  {
    this.Cstr.ClearString();
    StringManager.IntToStr(this.Cstr, sender.Value, bNumber: true);
    sender.m_inputText.text = this.Cstr.ToString();
    sender.m_inputText.SetAllDirty();
    sender.m_inputText.cachedTextGenerator.Invalidate();
    this.UpdatePrice();
  }

  void IUIUnitRSliderHandler.OnTextChang(UnitResourcesSlider sender)
  {
    this.Cstr.ClearString();
    StringManager.IntToStr(this.Cstr, sender.Value, bNumber: true);
    sender.m_inputText.text = this.Cstr.ToString();
    sender.m_inputText.SetAllDirty();
    sender.m_inputText.cachedTextGenerator.Invalidate();
    this.UpdatePrice();
  }

  void IUICalculatorHandler.OnCalculatorVauleChang(
    byte mkind,
    long mValue,
    UnitResourcesSlider URS)
  {
    URS.Value = mValue;
    URS.m_slider.value = (double) this.slider.Value;
  }

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager instance1 = GUIManager.Instance;
    DataManager instance2 = DataManager.Instance;
    Font ttfFont = instance1.GetTTFFont();
    this.ThisTransform = this.transform.GetChild(5);
    this.ThisTransform.GetChild(1).GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(507f, 447f);
    this.ThisTransform.GetChild(1).GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(-204f, 131f);
    this.NumText = this.ThisTransform.GetChild(2).GetChild(2).GetComponent<UIText>();
    this.NumText.font = ttfFont;
    ((Graphic) this.NumText).color = Color.white;
    this.AddRefreshText((Text) this.NumText);
    if (instance1.bOpenOnIPhoneX)
    {
      RectTransform component = this.ThisTransform.GetChild(0).GetComponent<RectTransform>();
      component.offsetMin = new Vector2(component.offsetMin.x - instance1.IPhoneX_DeltaX, component.offsetMin.y);
      component.offsetMax = new Vector2(component.offsetMax.x + instance1.IPhoneX_DeltaX, component.offsetMax.y);
    }
    this.NumStr = StringManager.Instance.SpawnString();
    this.TipStr = StringManager.Instance.SpawnString();
    this.Cstr = StringManager.Instance.SpawnString();
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((Object) menu != (Object) null)
    {
      Image component = this.ThisTransform.GetChild(0).GetComponent<Image>();
      ((MaskableGraphic) component).material = menu.LoadMaterial();
      component.sprite = menu.LoadSprite("UI_main_black");
      component.type = (Image.Type) 1;
    }
    this.ThisTransform.GetChild(2).GetChild(2).gameObject.SetActive(true);
    this.MsgIcon = this.ThisTransform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>();
    UIButton component1 = this.ThisTransform.GetChild(0).GetComponent<UIButton>();
    component1.m_BtnID1 = 1;
    component1.m_Handler = (IUIButtonClickHandler) this;
    this.ItemRect = this.ThisTransform.GetChild(4).GetComponent<RectTransform>();
    this.ItemRect.anchoredPosition = new Vector2(-148f, 83f);
    instance1.InitianHeroItemImg((Transform) this.ItemRect, eHeroOrItem.Item, this.ItemID, (byte) 0, (byte) 0, bShowText: false);
    this.AddRefreshText((Text) ((Transform) this.ItemRect).GetChild(4).GetComponent<UIText>());
    this.ItemNameText = this.ThisTransform.GetChild(2).GetChild(0).GetComponent<UIText>();
    ((Graphic) this.ItemNameText).rectTransform.anchoredPosition = new Vector2(51f, 337f);
    this.ItemNameText.font = ttfFont;
    this.AddRefreshText((Text) this.ItemNameText);
    this.TitleText = this.ThisTransform.GetChild(2).GetChild(1).GetComponent<UIText>();
    this.TitleText.font = ttfFont;
    this.AddRefreshText((Text) this.TitleText);
    ((Graphic) this.TitleText).rectTransform.anchoredPosition = new Vector2(3f, 32.5f);
    this.TitleText.text = instance2.mStringTable.GetStringByID(283U);
    int Max = 0;
    this.slider = this.ThisTransform.GetChild(5).gameObject.AddComponent<UnitResourcesSlider>();
    instance1.InitUnitResourcesSlider(this.slider.transform, eUnitSlider.AutoUse, 0U, 0U);
    instance1.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnLessen, 210.5f, -322.2f, 70f, 60f, 0.0f, 0.0f);
    instance1.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 384.5f, -322.2f, 257f, 19f, 0.0f, (float) Max);
    instance1.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.BtnIncrease, 541.2f, -322.2f, 70f, 60f, 0.0f, 0.0f);
    instance1.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.Input, 328f, -272.6f, 94f, 35f, 0.0f, 0.0f);
    RectTransform component2 = this.slider.transform.GetChild(3).GetComponent<RectTransform>();
    component2.anchoredPosition = new Vector2(328f, -272.6f);
    component2.sizeDelta = new Vector2(94f, 35f);
    this.slider.transform.GetChild(1).GetComponent<Image>().preserveAspect = true;
    this.slider.transform.GetChild(0).GetComponent<Image>().preserveAspect = true;
    this.slider.BtnInputText.m_Handler = (IUIButtonClickHandler) this;
    this.slider.BtnInputText.m_BtnID1 = 2;
    Text component3 = (Text) this.ThisTransform.GetChild(5).GetChild(3).GetChild(0).GetComponent<UIText>();
    component3.fontSize = 24;
    component3.alignment = TextAnchor.MiddleRight;
    this.AddRefreshText(component3);
    this.slider.m_Handler = (IUIUnitRSliderHandler) this;
    this.AutouseSlider = this.ThisTransform.GetChild(5).GetChild(2).GetComponent<CSlider>();
    ((Component) this.ThisTransform.GetChild(7).GetChild(0).GetComponent<RectTransform>()).gameObject.SetActive(false);
    this.ThisTransform.GetChild(8).GetChild(0).gameObject.SetActive(false);
    this.TipText = this.ThisTransform.GetChild(8).GetComponent<UIText>();
    this.TipText.font = ttfFont;
    ((Graphic) this.TipText).rectTransform.anchoredPosition = new Vector2(1.8f, -100f);
    this.TipText.fontSize = 18;
    this.AddRefreshText((Text) this.TipText);
    this.ThisTransform.GetChild(6).gameObject.SetActive(false);
    RectTransform component4 = this.ThisTransform.GetChild(9).GetComponent<RectTransform>();
    component4.anchoredPosition = new Vector2(115.5f, -163f);
    UIButton component5 = ((Component) component4).GetComponent<UIButton>();
    component5.m_BtnID1 = 0;
    component5.m_Handler = (IUIButtonClickHandler) this;
    this.ThisTransform.GetChild(10).GetComponent<RectTransform>().anchoredPosition = new Vector2(-111.5f, -163f);
    UIButton component6 = this.ThisTransform.GetChild(10).GetComponent<UIButton>();
    component6.m_Handler = (IUIButtonClickHandler) this;
    component6.m_BtnID1 = 1;
    Text component7 = (Text) this.ThisTransform.GetChild(9).GetChild(0).GetComponent<UIText>();
    component7.text = instance2.mStringTable.GetStringByID(284U);
    component7.font = ttfFont;
    this.AddRefreshText(component7);
    Text component8 = (Text) this.ThisTransform.GetChild(10).GetChild(0).GetComponent<UIText>();
    component8.text = instance2.mStringTable.GetStringByID(4U);
    component8.font = ttfFont;
    this.AddRefreshText(component8);
    this.SpriteArray = this.ThisTransform.GetChild(11).GetComponent<UISpritesArray>();
    this.UpdateData(arg1);
  }

  public override void OnClose()
  {
    if (this.NumStr == null)
      return;
    StringManager.Instance.DeSpawnString(this.NumStr);
    StringManager.Instance.DeSpawnString(this.TipStr);
    StringManager.Instance.DeSpawnString(this.Cstr);
    this.NumStr = (CString) null;
  }

  public override void UpdateUI(int arge1, int arge2)
  {
    if (arge1 >> 16 != 1 || arge1 != 65537)
      return;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0, -1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 65537, (int) (this.slider.Value << 16 | (long) this.ItemID));
  }

  public void UpdateData(int parm1)
  {
    if (parm1 == -1)
      return;
    GUIManager instance1 = GUIManager.Instance;
    DataManager instance2 = DataManager.Instance;
    this.ItemSN = (ushort) (parm1 >> 16);
    this.StoreType = (byte) ((int) ushort.MaxValue & parm1);
    bool flag = true;
    if ((int) this.StoreType >> 4 == 1)
    {
      this.StoreType = (byte) (15U & (uint) this.StoreType);
      flag = false;
    }
    StoreTbl recordByKey1 = instance2.StoreData.GetRecordByKey(this.ItemSN);
    this.ItemID = recordByKey1.ItemID;
    Equip recordByKey2 = instance2.EquipTable.GetRecordByKey(this.ItemID);
    this.ItemNameText.text = instance2.mStringTable.GetStringByID((uint) recordByKey2.EquipName);
    int Max = this.StoreType != (byte) 1 ? (int) (instance2.RoleAlliance.Money / recordByKey1.AlliancePoint) : (int) (instance2.RoleAttr.Diamond / recordByKey1.Price);
    if (flag)
    {
      if (Max + (int) instance2.GetCurItemQuantity(this.ItemID, (byte) 0) >= (int) ushort.MaxValue)
        Max = (int) ushort.MaxValue - (int) instance2.GetCurItemQuantity(this.ItemID, (byte) 0);
    }
    else if (Max > (int) ushort.MaxValue)
      Max = (int) ushort.MaxValue;
    this.MsgIcon.sprite = this.SpriteArray.GetSprite((int) this.StoreType + 9);
    this.MsgIcon.SetNativeSize();
    instance1.SetUnitResourcesSliderSize(this.slider.transform, eUnitSliderSize.m_slider, 384.5f, -322.2f, 257f, 19f, 0.0f, (float) Max);
    instance1.ChangeHeroItemImg((Transform) this.ItemRect, eHeroOrItem.Item, this.ItemID, (byte) 0, (byte) 0);
    this.slider.m_slider.value = 1.0;
    this.AutouseSlider.value = this.slider.m_slider.value;
    this.slider.Value = (long) this.slider.m_slider.value;
    this.Cstr.ClearString();
    StringManager.IntToStr(this.Cstr, this.slider.Value, bNumber: true);
    this.slider.m_inputText.text = this.Cstr.ToString();
    this.slider.m_inputText.SetAllDirty();
    this.slider.m_inputText.cachedTextGenerator.Invalidate();
    this.UpdatePrice();
  }

  private void UpdatePrice()
  {
    if (this.slider.Value <= 0L)
    {
      this.slider.Value = 1L;
      this.slider.m_slider.value = (double) this.slider.Value;
    }
    this.NumStr.ClearString();
    StoreTbl recordByKey = DataManager.Instance.StoreData.GetRecordByKey(this.ItemSN);
    int x;
    if (this.StoreType == (byte) 1)
    {
      x = (int) ((long) recordByKey.Price * this.slider.Value);
      this.NumStr.IntToFormat((long) x, bNumber: true);
      this.NumStr.IntToFormat((long) DataManager.Instance.RoleAttr.Diamond, bNumber: true);
    }
    else
    {
      x = (int) ((long) recordByKey.AlliancePoint * this.slider.Value);
      this.NumStr.IntToFormat((long) x, bNumber: true);
      this.NumStr.IntToFormat((long) DataManager.Instance.RoleAlliance.Money, bNumber: true);
    }
    if (GUIManager.Instance.IsArabic)
      this.NumStr.AppendFormat("{1}/{0}");
    else
      this.NumStr.AppendFormat("{0}/{1}");
    this.NumText.text = this.NumStr.ToString();
    this.NumText.SetAllDirty();
    this.NumText.cachedTextGenerator.Invalidate();
    this.NumText.cachedTextGeneratorForLayout.Invalidate();
    ((Graphic) this.MsgIcon).rectTransform.anchoredPosition = ((Graphic) this.MsgIcon).rectTransform.anchoredPosition with
    {
      x = (float) (-(double) this.NumText.preferredWidth * 0.5 - (double) ((Graphic) this.MsgIcon).rectTransform.sizeDelta.x * 0.5)
    };
    this.TipStr.ClearString();
    this.TipStr.IntToFormat((long) x, bNumber: true);
    this.TipStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(231U));
    this.TipText.text = this.TipStr.ToString();
    this.TipText.SetAllDirty();
    this.TipText.cachedTextGenerator.Invalidate();
  }

  public override void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (this.StoreType == (byte) 1)
        {
          if (GUIManager.Instance.OpenCheckCrystal((uint) ((ulong) DataManager.Instance.StoreData.GetRecordByKey(this.ItemSN).Price * (ulong) this.slider.Value), (byte) 1, 65537))
            break;
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0, -1);
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 65537, (int) (this.slider.Value << 16 | (long) this.ItemID));
          break;
        }
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0, -1);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 65537, (int) (this.slider.Value << 16 | (long) this.ItemID));
        break;
      case 1:
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 0, -1);
        break;
      case 2:
        GUIManager.Instance.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
        GUIManager.Instance.m_UICalculator.OpenCalculator(this.slider.MaxValue, this.slider.Value, 290.22f, -25.96f, this.slider, 0L);
        break;
    }
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
}
