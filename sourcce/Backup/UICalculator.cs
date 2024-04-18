// Decompiled with JetBrains decompiler
// Type: UICalculator
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UICalculator : IUIButtonClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private Door door;
  public IUICalculatorHandler m_CalculatorHandler;
  private RectTransform ImgRT;
  public RectTransform CalculatorRT;
  public UnitResourcesSlider mUnitRslider;
  private Text text_Value;
  private Text[] text_Str = new Text[12];
  public byte mKXY;
  public ushort[] KXY_Value = new ushort[3];
  public long tmpValue;
  public long MinValue;
  public long MaxValue;
  public byte OpenKind;
  public bool bOpen = true;

  public void OpenCalculator(
    long mMaxValue,
    long mValue,
    float PosX = 0,
    float PosY = 0,
    UnitResourcesSlider URS = null,
    long mMinValue = 0)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    if ((Object) this.GUIM.Obj_UICalculator != (Object) null)
      return;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    Object original = this.GUIM.m_CalculatorAssetBundle.Load(nameof (UICalculator));
    if (original == (Object) null)
      return;
    if (this.GUIM.m_CalculatorStr == null)
      this.GUIM.m_CalculatorStr = StringManager.Instance.SpawnString();
    this.GUIM.Obj_UICalculator = (GameObject) Object.Instantiate(original);
    this.GUIM.Obj_UICalculator.transform.SetParent((Transform) this.GUIM.m_SecWindowLayer, false);
    if ((Object) URS != (Object) null)
      this.mUnitRslider = URS;
    this.bOpen = true;
    RectTransform component1 = ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>();
    UIButton component2 = this.GUIM.Obj_UICalculator.transform.GetChild(0).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 1;
    ((Graphic) component2.image).color = new Color(1f, 1f, 1f, 0.0f);
    component2.m_EffectType = e_EffectType.e_Scale;
    component2.transition = (Selectable.Transition) 0;
    Image component3 = this.GUIM.Obj_UICalculator.transform.GetChild(1).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Transform) ((Graphic) component3).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    this.CalculatorRT = this.GUIM.Obj_UICalculator.transform.GetChild(1).GetComponent<RectTransform>();
    if ((double) PosX > 0.0 && (double) PosX + 137.0 >= (double) component1.sizeDelta.x / 2.0)
      PosX = (float) ((double) component1.sizeDelta.x / 2.0 - 137.0);
    else if ((double) PosX < 0.0 && (double) PosX - 137.0 < -(double) component1.sizeDelta.x / 2.0)
      PosX = (float) (-(double) component1.sizeDelta.x / 2.0 + 137.0);
    if ((double) PosY > 0.0 && (double) PosY - 163.0 >= 163.0)
      PosY = (float) ((double) component1.sizeDelta.y / 2.0 - 163.0);
    else if ((double) PosY < 0.0 && (double) PosY - 163.0 < -(double) component1.sizeDelta.y)
      PosY = (float) (-(double) component1.sizeDelta.y / 2.0 + 163.0);
    this.CalculatorRT.anchoredPosition = new Vector2(PosX, PosY);
    Transform child = this.GUIM.Obj_UICalculator.transform.GetChild(1);
    for (int index = 0; index < 9; ++index)
    {
      UIButton component4 = child.GetChild(index).GetComponent<UIButton>();
      component4.m_Handler = (IUIButtonClickHandler) this;
      component4.m_BtnID1 = 2 + index;
      component4.m_EffectType = e_EffectType.e_Scale;
      component4.transition = (Selectable.Transition) 0;
      this.text_Str[index] = child.GetChild(index).GetChild(0).GetComponent<Text>();
      this.text_Str[index].font = this.GUIM.GetTTFFont();
      this.text_Str[index].text = (index + 1).ToString();
    }
    UIButton component5 = child.GetChild(9).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_BtnID1 = 11;
    component5.m_EffectType = e_EffectType.e_Scale;
    component5.transition = (Selectable.Transition) 0;
    this.text_Str[9] = child.GetChild(9).GetChild(0).GetComponent<Text>();
    this.text_Str[9].font = this.GUIM.GetTTFFont();
    this.text_Str[9].text = GameConstants.numChar[0].ToString();
    UIButton component6 = child.GetChild(10).GetComponent<UIButton>();
    component6.m_Handler = (IUIButtonClickHandler) this;
    component6.m_BtnID1 = 12;
    component6.m_EffectType = e_EffectType.e_Scale;
    component6.transition = (Selectable.Transition) 0;
    child.GetChild(10).GetChild(0).GetComponent<Image>().SetNativeSize();
    UIButton component7 = child.GetChild(11).GetComponent<UIButton>();
    component7.m_Handler = (IUIButtonClickHandler) this;
    component7.m_BtnID1 = 13;
    component7.m_EffectType = e_EffectType.e_Scale;
    component7.transition = (Selectable.Transition) 0;
    child.GetChild(11).GetChild(0).GetComponent<Image>().SetNativeSize();
    this.MaxValue = mMaxValue;
    this.tmpValue = mValue;
    this.MinValue = mMinValue;
    Image component8 = child.GetChild(12).GetComponent<Image>();
    this.ImgRT = child.GetChild(12).GetChild(0).GetComponent<RectTransform>();
    component8 = child.GetChild(12).GetChild(0).GetComponent<Image>();
    this.text_Value = child.GetChild(12).GetChild(1).GetComponent<Text>();
    this.text_Value.font = this.GUIM.GetTTFFont();
    this.GUIM.m_CalculatorStr.ClearString();
    StringManager.IntToStr(this.GUIM.m_CalculatorStr, this.tmpValue, bNumber: true);
    this.text_Value.text = this.GUIM.m_CalculatorStr.ToString();
    ((Graphic) this.text_Value).SetAllDirty();
    this.text_Value.cachedTextGenerator.Invalidate();
    this.text_Value.cachedTextGeneratorForLayout.Invalidate();
    this.ImgRT.sizeDelta = new Vector2(this.text_Value.preferredWidth + 4f, this.ImgRT.sizeDelta.y);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
        Object.Destroy((Object) this.GUIM.Obj_UICalculator);
        this.GUIM.Obj_UICalculator = (GameObject) null;
        this.mUnitRslider = (UnitResourcesSlider) null;
        break;
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
      case 8:
      case 9:
      case 10:
        this.SetNum(sender.m_BtnID1 - 1);
        break;
      case 11:
        this.SetNum(sender.m_BtnID1 - 11);
        break;
      case 12:
        if (this.bOpen)
        {
          this.bOpen = false;
          ((Component) this.ImgRT).gameObject.SetActive(false);
          this.tmpValue = 0L;
        }
        else
          this.tmpValue /= 10L;
        this.GUIM.m_CalculatorStr.ClearString();
        StringManager.IntToStr(this.GUIM.m_CalculatorStr, this.tmpValue, bNumber: true);
        this.text_Value.text = this.GUIM.m_CalculatorStr.ToString();
        ((Graphic) this.text_Value).SetAllDirty();
        this.text_Value.cachedTextGenerator.Invalidate();
        break;
      case 13:
        if (this.tmpValue < this.MinValue)
        {
          this.GUIM.MsgStr.ClearString();
          this.GUIM.MsgStr.IntToFormat(this.MinValue);
          this.GUIM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(8537U));
          this.GUIM.AddHUDMessage(this.GUIM.MsgStr.ToString(), (ushort) byte.MaxValue);
          break;
        }
        if ((Object) this.mUnitRslider != (Object) null)
          this.m_CalculatorHandler.OnCalculatorVauleChang((byte) 0, this.tmpValue, this.mUnitRslider);
        else if (this.m_CalculatorHandler != null)
          this.m_CalculatorHandler.OnCalculatorVauleChang((byte) 0, this.tmpValue);
        Object.Destroy((Object) this.GUIM.Obj_UICalculator);
        this.GUIM.Obj_UICalculator = (GameObject) null;
        this.mUnitRslider = (UnitResourcesSlider) null;
        break;
    }
  }

  public void SetNum(int mNum)
  {
    if (this.bOpen)
    {
      this.bOpen = false;
      ((Component) this.ImgRT).gameObject.SetActive(false);
      this.tmpValue = (long) mNum;
    }
    else
      this.tmpValue = this.tmpValue * 10L + (long) mNum >= this.MaxValue ? this.MaxValue : (long) (uint) ((ulong) (this.tmpValue * 10L) + (ulong) mNum);
    this.GUIM.m_CalculatorStr.ClearString();
    StringManager.IntToStr(this.GUIM.m_CalculatorStr, this.tmpValue, bNumber: true);
    this.text_Value.text = this.GUIM.m_CalculatorStr.ToString();
    ((Graphic) this.text_Value).SetAllDirty();
    this.text_Value.cachedTextGenerator.Invalidate();
  }

  public void TextRefresh()
  {
    if ((Object) this.text_Value != (Object) null && ((Behaviour) this.text_Value).enabled)
    {
      ((Behaviour) this.text_Value).enabled = false;
      ((Behaviour) this.text_Value).enabled = true;
    }
    for (int index = 0; index < 10; ++index)
    {
      if ((Object) this.text_Str[index] != (Object) null && ((Behaviour) this.text_Str[index]).enabled)
      {
        ((Behaviour) this.text_Str[index]).enabled = false;
        ((Behaviour) this.text_Str[index]).enabled = true;
      }
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
