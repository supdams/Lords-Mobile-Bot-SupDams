// Decompiled with JetBrains decompiler
// Type: UICryptDig
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UICryptDig : 
  GUIWindow,
  IUIButtonClickHandler,
  IUICalculatorHandler,
  IUIUnitRSliderHandler
{
  private const ushort BaseFunds = 10000;
  private Transform AGS_Form;
  private UISpritesArray AGS_Icon;
  private UISpritesArray AGS_SuperBtn_SA;
  private Door door;
  private DataManager DM;
  private byte OpenDigType;
  private UnitResourcesSlider slider;
  private CString interestText;
  private CString fundsText;
  private CString profitText;
  private CString timeText;
  private CString MaxFundText;
  private ushort funds;
  private ushort MaxFunds;
  private double interest;
  private uint profit;
  private Image Light;
  private float LightTime;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.door = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    this.OpenDigType = (byte) arg1;
    this.interestText = StringManager.Instance.SpawnString(50);
    this.fundsText = StringManager.Instance.SpawnString(50);
    this.profitText = StringManager.Instance.SpawnString(50);
    this.timeText = StringManager.Instance.SpawnString(50);
    this.MaxFundText = StringManager.Instance.SpawnString(50);
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = this.DM.mStringTable.GetStringByID((uint) (3986 + (int) this.OpenDigType - 1));
    Image component2 = this.AGS_Form.GetChild(4).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component2).material = this.door.LoadMaterial();
    ((Behaviour) component2).enabled = !GUIManager.Instance.bOpenOnIPhoneX;
    Image component3 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<Image>();
    component3.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component3).material = this.door.LoadMaterial();
    UIButton component4 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_EffectType = e_EffectType.e_Scale;
    this.AGS_Icon = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UISpritesArray>();
    this.AGS_Icon.SetSpriteIndex((int) this.OpenDigType - 1);
    UIText component5 = this.AGS_Form.GetChild(6).GetChild(3).GetComponent<UIText>();
    component5.font = ttfFont;
    component5.text = this.DM.mStringTable.GetStringByID(3993U);
    UIText component6 = this.AGS_Form.GetChild(6).GetChild(4).GetComponent<UIText>();
    component6.font = ttfFont;
    component6.text = this.DM.mStringTable.GetStringByID(3994U);
    UIText component7 = this.AGS_Form.GetChild(6).GetChild(5).GetComponent<UIText>();
    component7.font = ttfFont;
    component7.text = this.DM.mStringTable.GetStringByID(3995U);
    UIText component8 = this.AGS_Form.GetChild(6).GetChild(6).GetComponent<UIText>();
    component8.font = ttfFont;
    component8.text = this.DM.mStringTable.GetStringByID(3996U);
    UIText component9 = this.AGS_Form.GetChild(6).GetChild(7).GetComponent<UIText>();
    component9.font = ttfFont;
    component9.text = this.DM.mStringTable.GetStringByID(3930U);
    UIText component10 = this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>();
    component10.font = ttfFont;
    component10.text = string.Empty;
    UIText component11 = this.AGS_Form.GetChild(6).GetChild(9).GetComponent<UIText>();
    component11.font = ttfFont;
    component11.text = string.Empty;
    UIText component12 = this.AGS_Form.GetChild(6).GetChild(10).GetComponent<UIText>();
    component12.font = ttfFont;
    component12.text = string.Empty;
    ((Graphic) component12).color = (Color) new Color32((byte) 0, byte.MaxValue, (byte) 0, byte.MaxValue);
    UIText component13 = this.AGS_Form.GetChild(6).GetChild(11).GetComponent<UIText>();
    component13.font = ttfFont;
    component13.text = string.Empty;
    UIText component14 = this.AGS_Form.GetChild(6).GetChild(12).GetComponent<UIText>();
    component14.font = ttfFont;
    component14.text = string.Empty;
    UIText component15 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
    component15.font = ttfFont;
    component15.text = string.Empty;
    UIText component16 = this.AGS_Form.GetChild(8).GetChild(2).GetComponent<UIText>();
    component16.font = ttfFont;
    component16.text = this.DM.mStringTable.GetStringByID(4055U);
    UIText component17 = this.AGS_Form.GetChild(8).GetChild(3).GetComponent<UIText>();
    component17.font = ttfFont;
    component17.text = string.Empty;
    UIText component18 = this.AGS_Form.GetChild(8).GetChild(4).GetChild(1).GetComponent<UIText>();
    component18.font = ttfFont;
    component18.text = string.Empty;
    UIText component19 = this.AGS_Form.GetChild(9).GetChild(1).GetComponent<UIText>();
    component19.font = ttfFont;
    component19.text = this.DM.mStringTable.GetStringByID(3934U);
    UIText component20 = this.AGS_Form.GetChild(9).GetChild(2).GetComponent<UIText>();
    component20.font = ttfFont;
    component20.text = this.DM.mStringTable.GetStringByID(5897U);
    UIButton component21 = this.AGS_Form.GetChild(10).GetComponent<UIButton>();
    component21.m_Handler = (IUIButtonClickHandler) this;
    component21.m_EffectType = e_EffectType.e_Scale;
    this.AGS_SuperBtn_SA = this.AGS_Form.GetChild(10).GetComponent<UISpritesArray>();
    UIText component22 = this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UIText>();
    component22.font = ttfFont;
    component22.text = string.Empty;
    ((Component) component22).gameObject.AddComponent<Outline>();
    UIText component23 = this.AGS_Form.GetChild(10).GetChild(2).GetComponent<UIText>();
    component23.font = ttfFont;
    component23.text = this.DM.mStringTable.GetStringByID(4090U);
    ((Graphic) component23).color = (Color) new Color32((byte) 209, (byte) 192, (byte) 165, byte.MaxValue);
    this.AGS_Form.GetChild(9).gameObject.SetActive(false);
    this.Light = this.AGS_Form.GetChild(10).GetChild(0).GetComponent<Image>();
    this.LoadInfo();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.interestText);
    StringManager.Instance.DeSpawnString(this.fundsText);
    StringManager.Instance.DeSpawnString(this.profitText);
    StringManager.Instance.DeSpawnString(this.timeText);
    StringManager.Instance.DeSpawnString(this.MaxFundText);
  }

  public override void UpdateUI(int arg1, int arg2) => this.LoadInfo();

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.LoadInfo();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!bOnSecond)
      return;
    this.updateTimeBar();
  }

  private void LoadInfo()
  {
    switch (this.OpenDigType)
    {
      case 1:
        this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(3990U);
        this.AGS_Form.GetChild(6).GetChild(9).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(4058U);
        break;
      case 2:
        this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(3991U);
        this.AGS_Form.GetChild(6).GetChild(9).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(4059U);
        break;
      case 3:
        this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(3992U);
        this.AGS_Form.GetChild(6).GetChild(9).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(4060U);
        break;
    }
    if (this.DM.m_CryptData.money == (ushort) 0)
    {
      this.interest = 1.0 + GameConstants.cryptInterest[(int) this.OpenDigType] + (double) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 277) / 10000.0;
      if (this.funds < (ushort) 10000)
        this.funds = (ushort) 10000;
      this.profit = (uint) Math.Floor((double) this.funds * this.interest);
      this.MaxFunds = (ushort) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 278);
      UIText component = this.AGS_Form.GetChild(6).GetChild(10).GetComponent<UIText>();
      this.interestText.ClearString();
      this.interestText.FloatToFormat((float) (this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 277) / 100U), 2, false);
      if (!GUIManager.Instance.IsArabic)
        this.interestText.AppendFormat("+{0}%");
      else
        this.interestText.AppendFormat("%{0}+");
      component.text = this.interestText.ToString();
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
      if ((UnityEngine.Object) this.slider == (UnityEngine.Object) null)
      {
        GameObject gameObject = new GameObject("Slider");
        gameObject.AddComponent<RectTransform>().anchoredPosition = new Vector2(-110f, -215f);
        gameObject.transform.SetParent(this.AGS_Form.GetChild(9), false);
        this.slider = gameObject.AddComponent<UnitResourcesSlider>();
        GUIManager.Instance.InitUnitResourcesSlider(gameObject.transform, eUnitSlider.Crypt, 10000U, (uint) this.MaxFunds);
        this.slider.m_Handler = (IUIUnitRSliderHandler) this;
        this.slider.m_ID = 1;
        this.slider.BtnInputText.m_Handler = (IUIButtonClickHandler) this;
        this.slider.BtnInputText.m_BtnID1 = 4;
      }
      this.slider.MaxValue = (long) this.MaxFunds;
      this.slider.m_slider.maxValue = (double) this.MaxFunds;
      this.MaxFundText.ClearString();
      this.MaxFundText.IntToFormat((long) this.MaxFunds, bNumber: true);
      this.MaxFundText.AppendFormat("{0}");
      this.slider.m_TotalText.text = this.MaxFundText.ToString();
      this.slider.m_TotalText.SetAllDirty();
      this.slider.m_TotalText.cachedTextGenerator.Invalidate();
      StringManager.IntToStr(this.fundsText, (long) this.funds, bNumber: true);
      this.slider.m_inputText.text = this.fundsText.ToString();
      this.slider.m_inputText.SetAllDirty();
      this.slider.m_inputText.cachedTextGenerator.Invalidate();
      this.AGS_Form.GetChild(9).GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(-110f, -281f);
      this.AGS_Form.GetChild(9).GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(-170f, -213f);
      this.AGS_Form.GetChild(9).GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector2(54f, -223f);
      this.AGS_SuperBtn_SA.SetSpriteIndex(0);
      this.AGS_Form.GetChild(10).GetChild(0).gameObject.SetActive(false);
      this.AGS_Form.GetChild(10).GetChild(2).gameObject.SetActive(false);
      this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(4089U);
      this.AGS_Form.GetChild(10).GetComponent<UIButton>().m_BtnID1 = 1;
      ((Graphic) this.AGS_Form.GetChild(6).GetChild(12).GetComponent<UIText>()).color = (Color) new Color32((byte) 0, byte.MaxValue, (byte) 0, byte.MaxValue);
      this.AGS_Form.GetChild(9).gameObject.SetActive(true);
      this.AGS_Form.GetChild(10).gameObject.SetActive(true);
      this.AGS_Form.GetChild(9).GetChild(1).gameObject.SetActive(true);
      this.AGS_Form.GetChild(9).GetChild(2).gameObject.SetActive(true);
    }
    else
    {
      if ((int) this.DM.m_CryptData.kind == (int) this.OpenDigType)
      {
        BuildLevelRequest levelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort) 16, this.DM.m_CryptData.level);
        this.interest = 1.0 + GameConstants.cryptInterest[(int) this.DM.m_CryptData.kind] + (double) levelRequestData.Value2 / 10000.0;
        this.funds = this.DM.m_CryptData.money;
        this.profit = (uint) Math.Floor((double) this.funds * this.interest);
        UIText component1 = this.AGS_Form.GetChild(6).GetChild(10).GetComponent<UIText>();
        this.interestText.ClearString();
        this.interestText.FloatToFormat((float) (levelRequestData.Value2 / 100U), 2, false);
        if (!GUIManager.Instance.IsArabic)
          this.interestText.AppendFormat("+{0}%");
        else
          this.interestText.AppendFormat("%{0}+");
        component1.text = this.interestText.ToString();
        component1.SetAllDirty();
        component1.cachedTextGenerator.Invalidate();
        ((Graphic) this.AGS_Form.GetChild(6).GetChild(12).GetComponent<UIText>()).color = Color.yellow;
        this.AGS_Form.GetChild(8).gameObject.SetActive(true);
        this.AGS_Form.GetChild(10).gameObject.SetActive(true);
        UIText component2 = this.AGS_Form.GetChild(8).GetChild(3).GetComponent<UIText>();
        this.profitText.ClearString();
        this.profitText.IntToFormat((long) this.profit, bNumber: true);
        this.profitText.AppendFormat("{0}");
        component2.text = this.profitText.ToString();
        this.updateTimeBar();
      }
      else
      {
        this.interest = 1.0 + GameConstants.cryptInterest[(int) this.OpenDigType] + (double) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 277) / 10000.0;
        this.funds = (ushort) 0;
        this.profit = 0U;
        UIText component3 = this.AGS_Form.GetChild(6).GetChild(10).GetComponent<UIText>();
        this.interestText.ClearString();
        this.interestText.FloatToFormat((float) (this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 277) / 100U), 2, false);
        if (!GUIManager.Instance.IsArabic)
          this.interestText.AppendFormat("+{0}%");
        else
          this.interestText.AppendFormat("%{0}+");
        component3.text = this.interestText.ToString();
        component3.SetAllDirty();
        component3.cachedTextGenerator.Invalidate();
        ((Graphic) this.AGS_Form.GetChild(6).GetChild(12).GetComponent<UIText>()).color = Color.yellow;
        UIText component4 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
        component4.text = this.DM.mStringTable.GetStringByID(4092U);
        ((Component) component4).transform.parent.gameObject.SetActive(true);
        ((Component) component4).gameObject.SetActive(true);
      }
      this.AGS_Form.GetChild(9).GetChild(1).gameObject.SetActive(false);
      this.AGS_Form.GetChild(9).GetChild(2).gameObject.SetActive(false);
    }
    this.SetNumbers();
  }

  private void updateTimeBar()
  {
    if (this.DM.m_CryptData.money == (ushort) 0)
    {
      this.AGS_SuperBtn_SA.SetSpriteIndex(0);
      this.AGS_Form.GetChild(10).GetComponent<UIButton>().m_BtnID1 = 1;
    }
    else
    {
      long sec = this.DM.m_CryptData.startTime + (long) GameConstants.CryptSecends[(int) this.DM.m_CryptData.kind] - this.DM.ServerTime;
      if (sec < 0L)
        sec = 0L;
      if (sec == 0L)
      {
        UIText component = this.AGS_Form.GetChild(8).GetChild(4).GetChild(1).GetComponent<UIText>();
        this.timeText.ClearString();
        this.timeText.Append(this.DM.mStringTable.GetStringByID(5881U));
        component.text = this.timeText.ToString();
        component.SetAllDirty();
        component.cachedTextGenerator.Invalidate();
        this.AGS_SuperBtn_SA.SetSpriteIndex(2);
        this.AGS_Form.GetChild(10).GetChild(2).gameObject.SetActive(false);
        this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(4091U);
        ((Component) this.Light).gameObject.SetActive(true);
        this.AGS_Form.GetChild(10).GetComponent<UIButton>().m_BtnID1 = 2;
      }
      else
      {
        UIText component = this.AGS_Form.GetChild(8).GetChild(4).GetChild(1).GetComponent<UIText>();
        this.timeText.ClearString();
        this.timeText.Append(this.DM.mStringTable.GetStringByID(3933U));
        this.timeText.Append(" ");
        this.AGS_Form.GetChild(8).GetChild(4).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) (256.0 * (1.0 - (double) sec / (double) GameConstants.CryptSecends[(int) this.DM.m_CryptData.kind])));
        GameConstants.GetTimeString(this.timeText, (uint) sec, withArabic: true);
        component.text = this.timeText.ToString();
        component.SetAllDirty();
        component.cachedTextGenerator.Invalidate();
        this.AGS_SuperBtn_SA.SetSpriteIndex(1);
        this.AGS_Form.GetChild(10).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(5880U);
        ((Component) this.Light).gameObject.SetActive(false);
        this.AGS_Form.GetChild(10).GetComponent<UIButton>().m_BtnID1 = 3;
      }
    }
  }

  private void SetNumbers()
  {
    UIText component1 = this.AGS_Form.GetChild(6).GetChild(11).GetComponent<UIText>();
    this.fundsText.ClearString();
    this.fundsText.IntToFormat((long) this.funds, bNumber: true);
    this.fundsText.AppendFormat("{0}");
    component1.text = this.fundsText.ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    UIText component2 = this.AGS_Form.GetChild(6).GetChild(12).GetComponent<UIText>();
    this.profitText.ClearString();
    this.profitText.IntToFormat((long) this.profit, bNumber: true);
    this.profitText.AppendFormat("{0}");
    component2.text = this.profitText.ToString();
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
    if ((uint) this.funds > this.DM.RoleAttr.Diamond && this.DM.m_CryptData.money == (ushort) 0)
      ((Graphic) this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UIText>()).color = (Color) new Color32((byte) 229, (byte) 0, (byte) 79, byte.MaxValue);
    else
      ((Graphic) this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UIText>()).color = (Color) new Color32(byte.MaxValue, (byte) 238, (byte) 158, byte.MaxValue);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        this.door.CloseMenu();
        break;
      case 1:
        if (this.DM.RoleAttr.Diamond < 10000U)
        {
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(4093U), (ushort) byte.MaxValue);
          break;
        }
        if (this.slider.Value > (long) this.DM.RoleAttr.Diamond)
        {
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(4095U), (ushort) byte.MaxValue);
          break;
        }
        if (this.slider.Value < 10000L)
          this.slider.Value = 10000L;
        MessagePacket messagePacket1 = new MessagePacket((ushort) 1024);
        messagePacket1.Protocol = Protocol._MSG_REQUEST_CRYPT_START;
        messagePacket1.AddSeqId();
        messagePacket1.Add((ushort) this.slider.Value);
        messagePacket1.Add(this.OpenDigType);
        messagePacket1.Send();
        GUIManager.Instance.ShowUILock(EUILock.Crypt);
        break;
      case 2:
        MessagePacket messagePacket2 = new MessagePacket((ushort) 1024);
        messagePacket2.Protocol = Protocol._MSG_REQUEST_CRYPT_REWARD;
        messagePacket2.AddSeqId();
        messagePacket2.Send();
        GUIManager.Instance.ShowUILock(EUILock.Crypt);
        GUIManager.Instance.mStartV2 = new Vector2((float) ((double) GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 - 342.95999145507813), (float) ((double) GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 + 236.5));
        break;
      case 3:
        GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4096U), this.DM.mStringTable.GetStringByID(4097U), YesText: this.DM.mStringTable.GetStringByID(4098U), NoText: this.DM.mStringTable.GetStringByID(4099U));
        break;
      case 4:
        GUIManager.Instance.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
        GUIManager.Instance.m_UICalculator.OpenCalculator(this.slider.MaxValue, this.slider.Value, 250f, -140f, this.slider, 10000L);
        break;
    }
  }

  public void OnVauleChang(UnitResourcesSlider sender)
  {
    if (sender.Value < 10000L)
      sender.Value = 10000L;
    this.funds = (ushort) sender.Value;
    this.profit = (uint) Math.Floor((double) this.funds * this.interest);
    this.SetNumbers();
    StringManager.IntToStr(this.fundsText, (long) this.funds, bNumber: true);
    sender.m_inputText.text = this.fundsText.ToString();
    sender.m_inputText.SetAllDirty();
    sender.m_inputText.cachedTextGenerator.Invalidate();
  }

  public void OnTextChang(UnitResourcesSlider sender)
  {
    this.funds = (ushort) sender.Value;
    this.profit = (uint) Math.Floor((double) this.funds * this.interest);
    StringManager.IntToStr(this.fundsText, (long) this.funds, bNumber: true);
    sender.m_inputText.text = this.fundsText.ToString();
    sender.m_inputText.SetAllDirty();
    sender.m_inputText.cachedTextGenerator.Invalidate();
  }

  public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS = null)
  {
    URS.m_slider.value = (double) mValue;
    URS.SliderValueChange();
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_CRYPT_CANCEL;
    messagePacket.AddSeqId();
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Crypt);
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.AGS_Form.GetChild(6).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.AGS_Form.GetChild(6).GetChild(4).GetComponent<UIText>();
    if ((UnityEngine.Object) component3 != (UnityEngine.Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.AGS_Form.GetChild(6).GetChild(5).GetComponent<UIText>();
    if ((UnityEngine.Object) component4 != (UnityEngine.Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    UIText component5 = this.AGS_Form.GetChild(6).GetChild(6).GetComponent<UIText>();
    if ((UnityEngine.Object) component5 != (UnityEngine.Object) null && ((Behaviour) component5).enabled)
    {
      ((Behaviour) component5).enabled = false;
      ((Behaviour) component5).enabled = true;
    }
    UIText component6 = this.AGS_Form.GetChild(6).GetChild(7).GetComponent<UIText>();
    if ((UnityEngine.Object) component6 != (UnityEngine.Object) null && ((Behaviour) component6).enabled)
    {
      ((Behaviour) component6).enabled = false;
      ((Behaviour) component6).enabled = true;
    }
    UIText component7 = this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>();
    if ((UnityEngine.Object) component7 != (UnityEngine.Object) null && ((Behaviour) component7).enabled)
    {
      ((Behaviour) component7).enabled = false;
      ((Behaviour) component7).enabled = true;
    }
    UIText component8 = this.AGS_Form.GetChild(6).GetChild(9).GetComponent<UIText>();
    if ((UnityEngine.Object) component8 != (UnityEngine.Object) null && ((Behaviour) component8).enabled)
    {
      ((Behaviour) component8).enabled = false;
      ((Behaviour) component8).enabled = true;
    }
    UIText component9 = this.AGS_Form.GetChild(6).GetChild(10).GetComponent<UIText>();
    if ((UnityEngine.Object) component9 != (UnityEngine.Object) null && ((Behaviour) component9).enabled)
    {
      ((Behaviour) component9).enabled = false;
      ((Behaviour) component9).enabled = true;
    }
    UIText component10 = this.AGS_Form.GetChild(6).GetChild(11).GetComponent<UIText>();
    if ((UnityEngine.Object) component10 != (UnityEngine.Object) null && ((Behaviour) component10).enabled)
    {
      ((Behaviour) component10).enabled = false;
      ((Behaviour) component10).enabled = true;
    }
    UIText component11 = this.AGS_Form.GetChild(6).GetChild(12).GetComponent<UIText>();
    if ((UnityEngine.Object) component11 != (UnityEngine.Object) null && ((Behaviour) component11).enabled)
    {
      ((Behaviour) component11).enabled = false;
      ((Behaviour) component11).enabled = true;
    }
    UIText component12 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component12 != (UnityEngine.Object) null && ((Behaviour) component12).enabled)
    {
      ((Behaviour) component12).enabled = false;
      ((Behaviour) component12).enabled = true;
    }
    UIText component13 = this.AGS_Form.GetChild(8).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component13 != (UnityEngine.Object) null && ((Behaviour) component13).enabled)
    {
      ((Behaviour) component13).enabled = false;
      ((Behaviour) component13).enabled = true;
    }
    UIText component14 = this.AGS_Form.GetChild(8).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component14 != (UnityEngine.Object) null && ((Behaviour) component14).enabled)
    {
      ((Behaviour) component14).enabled = false;
      ((Behaviour) component14).enabled = true;
    }
    UIText component15 = this.AGS_Form.GetChild(8).GetChild(4).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component15 != (UnityEngine.Object) null && ((Behaviour) component15).enabled)
    {
      ((Behaviour) component15).enabled = false;
      ((Behaviour) component15).enabled = true;
    }
    UIText component16 = this.AGS_Form.GetChild(9).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component16 != (UnityEngine.Object) null && ((Behaviour) component16).enabled)
    {
      ((Behaviour) component16).enabled = false;
      ((Behaviour) component16).enabled = true;
    }
    UIText component17 = this.AGS_Form.GetChild(9).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component17 != (UnityEngine.Object) null && ((Behaviour) component17).enabled)
    {
      ((Behaviour) component17).enabled = false;
      ((Behaviour) component17).enabled = true;
    }
    UIText component18 = this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component18 != (UnityEngine.Object) null && ((Behaviour) component18).enabled)
    {
      ((Behaviour) component18).enabled = false;
      ((Behaviour) component18).enabled = true;
    }
    UIText component19 = this.AGS_Form.GetChild(10).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component19 != (UnityEngine.Object) null && ((Behaviour) component19).enabled)
    {
      ((Behaviour) component19).enabled = false;
      ((Behaviour) component19).enabled = true;
    }
    if (!((UnityEngine.Object) this.slider != (UnityEngine.Object) null))
      return;
    this.slider.Refresh_FontTexture();
  }

  public void Update()
  {
    this.LightTime += Time.smoothDeltaTime;
    if ((double) this.LightTime >= 2.0)
      this.LightTime = 0.0f;
    ((Graphic) this.Light).color = new Color(1f, 1f, 1f, (double) this.LightTime <= 1.0 ? this.LightTime : 2f - this.LightTime);
  }

  private enum e_AGS_UI_CryptDig_Editor
  {
    BGFrame,
    BGFrameTitle,
    BGFrameLTop,
    BGFrameRTop,
    exitImage,
    BGImage,
    Main,
    frame2,
    Timebar,
    Funds,
    SuperBtn,
    BGFrameLeft,
    BGFrameRight,
  }

  private enum e_AGS_Main
  {
    frame,
    Icon,
    frame2,
    Desc1,
    Desc2,
    Desc3,
    Desc4,
    Desc5,
    Value1,
    Value2,
    Value3,
    Value4,
    Value5,
  }

  private enum e_AGS_Timebar
  {
    GemBg,
    Icon1,
    desc,
    GemValue,
    Bar,
  }

  private enum e_AGS_Bar
  {
    Bar,
    Text,
  }

  private enum e_AGS_Funds
  {
    Icon1,
    Text,
    Text2,
  }

  private enum e_AGS_SuperBtn
  {
    Image,
    Text,
    desc,
  }
}
