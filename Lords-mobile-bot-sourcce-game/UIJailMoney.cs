// Decompiled with JetBrains decompiler
// Type: UIJailMoney
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIJailMoney : GUIWindow, IUIButtonClickHandler, IUICalculatorHandler
{
  private Transform AGS_Form;
  private UIJailMoney.eOpenKind OpenKind;
  private uint MoneyAmount;
  private byte PrisonerDMIdx;
  private CString haveGold;
  private CString PopString;
  private CString MoneyText;
  private UIText MoneyTextField;
  private bool openOkBox;

  public override void OnOpen(int arg1, int arg2)
  {
    this.OpenKind = (UIJailMoney.eOpenKind) arg1;
    this.PrisonerDMIdx = (byte) arg2;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    this.AGS_Form.GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.haveGold = StringManager.Instance.SpawnString();
    this.PopString = StringManager.Instance.SpawnString(200);
    this.MoneyText = StringManager.Instance.SpawnString();
    switch (this.OpenKind)
    {
      case UIJailMoney.eOpenKind.Ransom:
        UIText component1 = this.AGS_Form.GetChild(9).GetComponent<UIText>();
        component1.font = ttfFont;
        component1.text = DataManager.Instance.mStringTable.GetStringByID(7769U);
        UIText component2 = this.AGS_Form.GetChild(10).GetComponent<UIText>();
        component2.font = ttfFont;
        component2.text = DataManager.Instance.mStringTable.GetStringByID(7765U);
        UIText component3 = this.AGS_Form.GetChild(14).GetComponent<UIText>();
        component3.font = ttfFont;
        component3.text = DataManager.Instance.mStringTable.GetStringByID(7770U);
        break;
      case UIJailMoney.eOpenKind.Bounty:
        UIText component4 = this.AGS_Form.GetChild(9).GetComponent<UIText>();
        component4.font = ttfFont;
        component4.text = DataManager.Instance.mStringTable.GetStringByID(7781U);
        UIText component5 = this.AGS_Form.GetChild(10).GetComponent<UIText>();
        component5.font = ttfFont;
        component5.text = DataManager.Instance.mStringTable.GetStringByID(7783U);
        UIText component6 = this.AGS_Form.GetChild(14).GetComponent<UIText>();
        component6.font = ttfFont;
        component6.text = DataManager.Instance.mStringTable.GetStringByID(7782U);
        break;
    }
    UIButton component7 = this.AGS_Form.GetChild(11).GetChild(0).GetComponent<UIButton>();
    component7.m_Handler = (IUIButtonClickHandler) this;
    component7.m_BtnID2 = 2;
    UIText component8 = this.AGS_Form.GetChild(11).GetChild(0).GetChild(0).GetComponent<UIText>();
    component8.font = ttfFont;
    component8.text = string.Empty;
    this.MoneyTextField = component8;
    UIText component9 = this.AGS_Form.GetChild(11).GetChild(1).GetComponent<UIText>();
    component9.font = ttfFont;
    RectTransform component10 = this.AGS_Form.GetChild(11).GetComponent<RectTransform>();
    switch (this.OpenKind)
    {
      case UIJailMoney.eOpenKind.Ransom:
        component10.anchoredPosition = new Vector2(-63f, -22f);
        ((Component) component9).gameObject.SetActive(false);
        break;
      case UIJailMoney.eOpenKind.Bounty:
        component10.anchoredPosition = new Vector2(-125f, -22f);
        this.haveGold.ClearString();
        this.haveGold.IntToFormat((long) DataManager.Instance.Resource[4].Stock, bNumber: true);
        if (!GUIManager.Instance.IsArabic)
          this.haveGold.AppendFormat("/ {0}");
        else
          this.haveGold.AppendFormat("{0} /");
        component9.text = this.haveGold.ToString();
        break;
    }
    UIText component11 = this.AGS_Form.GetChild(12).GetComponent<UIText>();
    component11.font = ttfFont;
    component11.text = DataManager.Instance.mStringTable.GetStringByID(7772U);
    UIButton component12 = this.AGS_Form.GetChild(13).GetComponent<UIButton>();
    component12.m_Handler = (IUIButtonClickHandler) this;
    component12.m_EffectType = e_EffectType.e_Scale;
    UIText component13 = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
    component13.font = ttfFont;
    component13.text = DataManager.Instance.mStringTable.GetStringByID(5026U);
    if (!GUIManager.Instance.bOpenOnIPhoneX)
      return;
    RectTransform component14 = this.AGS_Form.GetChild(0).GetComponent<RectTransform>();
    component14.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    component14.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
  }

  public override void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.PopString);
    StringManager.Instance.DeSpawnString(this.haveGold);
    StringManager.Instance.DeSpawnString(this.MoneyText);
    if (this.openOkBox)
      GUIManager.Instance.CloseOKCancelBox();
    if (!((Object) GUIManager.Instance.Obj_UICalculator != (Object) null))
      return;
    Object.Destroy((Object) GUIManager.Instance.Obj_UICalculator);
    GUIManager.Instance.Obj_UICalculator = (GameObject) null;
    GUIManager.Instance.m_UICalculator.mUnitRslider = (UnitResourcesSlider) null;
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID2)
    {
      case 0:
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_JailMoney);
        break;
      case 1:
        switch (this.OpenKind)
        {
          case UIJailMoney.eOpenKind.Ransom:
            if (this.MoneyAmount < 10000U)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7794U), (ushort) byte.MaxValue);
              return;
            }
            this.PopString.ClearString();
            this.PopString.IntToFormat((long) this.MoneyAmount);
            this.PopString.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7766U));
            this.PopString.Append("\n");
            this.PopString.Append(DataManager.Instance.mStringTable.GetStringByID(7771U));
            GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(7769U), this.PopString.ToString());
            this.openOkBox = true;
            return;
          case UIJailMoney.eOpenKind.Bounty:
            if (this.MoneyAmount < 10000U)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7795U), (ushort) byte.MaxValue);
              return;
            }
            if (DataManager.Instance.Resource[4].Stock < this.MoneyAmount)
              return;
            if ((ulong) this.MoneyAmount + (ulong) DataManager.Instance.beCaptured.Bounty > (ulong) uint.MaxValue)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7796U), (ushort) byte.MaxValue);
              return;
            }
            this.PopString.ClearString();
            this.PopString.IntToFormat((long) this.MoneyAmount);
            this.PopString.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7779U));
            this.PopString.Append("\n");
            this.PopString.Append(DataManager.Instance.mStringTable.GetStringByID(7780U));
            GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(7781U), this.PopString.ToString(), 1);
            this.openOkBox = true;
            return;
          default:
            return;
        }
      case 2:
        if (this.OpenKind == UIJailMoney.eOpenKind.Bounty)
        {
          GUIManager.Instance.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
          GUIManager.Instance.m_UICalculator.OpenCalculator((long) DataManager.Instance.Resource[4].Stock, 10000L, 350f, 0.0f, mMinValue: 10000L);
          break;
        }
        GUIManager.Instance.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
        GUIManager.Instance.m_UICalculator.OpenCalculator(999999999L, 10000L, 350f, 0.0f, mMinValue: 10000L);
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    this.openOkBox = false;
    if (!bOK)
      return;
    switch (arg1)
    {
      case 0:
        Debug.Log((object) ("贖金:" + (object) this.MoneyAmount));
        MessagePacket messagePacket1 = new MessagePacket((ushort) 1024);
        messagePacket1.Protocol = Protocol._MSG_REQUEST_CHANGE_RANSOM;
        messagePacket1.AddSeqId();
        messagePacket1.Add(this.PrisonerDMIdx);
        messagePacket1.Add(this.MoneyAmount);
        messagePacket1.Send();
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_JailMoney);
        break;
      case 1:
        Debug.Log((object) ("賞金:" + (object) this.MoneyAmount));
        MessagePacket messagePacket2 = new MessagePacket((ushort) 1024);
        messagePacket2.Protocol = Protocol._MSG_REQUEST_CHANGE_BOUNTY;
        messagePacket2.AddSeqId();
        messagePacket2.Add(this.MoneyAmount);
        messagePacket2.Send();
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_JailMoney);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(9).GetComponent<UIText>();
    if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.AGS_Form.GetChild(10).GetComponent<UIText>();
    if ((Object) component2 != (Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.AGS_Form.GetChild(11).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((Object) component3 != (Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.AGS_Form.GetChild(11).GetChild(1).GetComponent<UIText>();
    if ((Object) component4 != (Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    UIText component5 = this.AGS_Form.GetChild(12).GetComponent<UIText>();
    if ((Object) component5 != (Object) null && ((Behaviour) component5).enabled)
    {
      ((Behaviour) component5).enabled = false;
      ((Behaviour) component5).enabled = true;
    }
    UIText component6 = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
    if ((Object) component6 != (Object) null && ((Behaviour) component6).enabled)
    {
      ((Behaviour) component6).enabled = false;
      ((Behaviour) component6).enabled = true;
    }
    UIText component7 = this.AGS_Form.GetChild(14).GetComponent<UIText>();
    if (!((Object) component7 != (Object) null) || !((Behaviour) component7).enabled)
      return;
    ((Behaviour) component7).enabled = false;
    ((Behaviour) component7).enabled = true;
  }

  public void SetMoney(uint money)
  {
    this.MoneyAmount = money;
    this.MoneyText.ClearString();
    StringManager.IntToStr(this.MoneyText, (long) this.MoneyAmount, bNumber: true);
    this.MoneyTextField.text = this.MoneyText.ToString();
    this.MoneyTextField.SetAllDirty();
    this.MoneyTextField.cachedTextGenerator.Invalidate();
  }

  public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS = null)
  {
    this.SetMoney((uint) mValue);
  }

  public enum eOpenKind
  {
    Ransom,
    Bounty,
  }

  private enum e_AGS_UI_JailMoney_Editor
  {
    Black,
    Image,
    deco1,
    deco2,
    deco3,
    deco4,
    deco5,
    TopBar,
    ButtomBar,
    TitleText,
    FuncText,
    deco6,
    FuncDisp,
    UIButton,
    Text,
  }

  private enum e_AGS_deco6
  {
    MoneyText,
    TotalMoney,
    coin,
  }

  private enum e_AGS_UIButton
  {
    Text,
  }
}
