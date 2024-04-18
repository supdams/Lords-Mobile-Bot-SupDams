// Decompiled with JetBrains decompiler
// Type: UIPaySetting
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIPaySetting : GUIWindow, IUIButtonClickHandler
{
  private uint BuyID;
  private GameObject CheckObj;
  private UIText[] RefreshText = new UIText[6];
  private byte PaySetting;
  private byte Type;

  void IUIButtonClickHandler.OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
      case 2:
        this.PaySetting = (byte) (((int) this.PaySetting & 4) + sender.m_BtnID1);
        if (this.BuyID == 0U)
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(964U), (ushort) byte.MaxValue);
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_PaySetting);
        break;
      case 3:
        this.PaySetting = (byte) 0;
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_PaySetting);
        break;
      case 4:
        this.PaySetting ^= (byte) 4;
        this.CheckObj.gameObject.SetActive(!this.CheckObj.gameObject.activeSelf);
        if (((int) this.PaySetting & 1) <= 0 && ((int) this.PaySetting & 2) <= 0)
          break;
        if (((int) this.PaySetting & 4) > 0)
          DataManager.Instance.MySysSetting.mPaySetting |= (byte) 4;
        else
          DataManager.Instance.MySysSetting.mPaySetting &= (byte) 251;
        PlayerPrefs.SetString("Other_mPaySetting", DataManager.Instance.MySysSetting.mPaySetting.ToString());
        break;
    }
  }

  public override void OnOpen(int arg1, int arg2)
  {
    Transform child = this.transform.GetChild(0);
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    StringTable mStringTable = DataManager.Instance.mStringTable;
    this.BuyID = (uint) arg1;
    this.Type = (byte) arg2;
    this.RefreshText[0] = child.GetChild(0).GetChild(2).GetComponent<UIText>();
    this.RefreshText[0].font = ttfFont;
    this.RefreshText[0].text = mStringTable.GetStringByID(960U);
    this.RefreshText[1] = child.GetChild(3).GetChild(2).GetComponent<UIText>();
    this.RefreshText[1].font = ttfFont;
    this.RefreshText[1].resizeTextForBestFit = true;
    this.RefreshText[1].resizeTextMaxSize = 26;
    this.RefreshText[1].text = mStringTable.GetStringByID(9514U);
    ((Graphic) this.RefreshText[1]).rectTransform.sizeDelta = ((Graphic) this.RefreshText[1]).rectTransform.sizeDelta with
    {
      y = 36f
    };
    this.RefreshText[2] = child.GetChild(3).GetChild(3).GetComponent<UIText>();
    this.RefreshText[2].font = ttfFont;
    this.RefreshText[2].resizeTextForBestFit = true;
    this.RefreshText[2].resizeTextMaxSize = 26;
    this.RefreshText[2].text = mStringTable.GetStringByID(961U);
    ((Graphic) this.RefreshText[2]).rectTransform.sizeDelta = ((Graphic) this.RefreshText[2]).rectTransform.sizeDelta with
    {
      y = 36f
    };
    this.RefreshText[3] = child.GetChild(3).GetChild(4).GetComponent<UIText>();
    this.RefreshText[3].font = ttfFont;
    this.RefreshText[3].text = mStringTable.GetStringByID(965U);
    this.RefreshText[4] = child.GetChild(3).GetChild(5).GetComponent<UIText>();
    this.RefreshText[4].font = ttfFont;
    this.RefreshText[4].resizeTextForBestFit = true;
    this.RefreshText[4].resizeTextMaxSize = 26;
    this.RefreshText[5] = child.GetChild(3).GetChild(6).GetComponent<UIText>();
    this.RefreshText[5].font = ttfFont;
    this.RefreshText[5].resizeTextForBestFit = true;
    this.RefreshText[5].resizeTextMaxSize = 26;
    if (GUIManager.Instance.IsArabic)
    {
      child.GetChild(3).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
      child.GetChild(3).GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
      child.GetChild(4).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    this.CheckObj = child.GetChild(4).GetChild(0).gameObject;
    UIButton component1 = child.GetChild(4).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 4;
    this.PaySetting = DataManager.Instance.MySysSetting.mPaySetting;
    this.CheckObj.SetActive(((int) this.PaySetting & 4) > 0);
    if (((int) this.PaySetting & 1) > 0)
      this.RefreshText[4].text = mStringTable.GetStringByID(968U);
    else if (((int) this.PaySetting & 2) > 0)
      this.RefreshText[5].text = mStringTable.GetStringByID(968U);
    UIButton[] uiButtonArray = new UIButton[4]
    {
      child.GetComponent<UIButton>(),
      child.GetChild(1).GetComponent<UIButton>(),
      null,
      null
    };
    uiButtonArray[1].m_BtnID1 = 1;
    uiButtonArray[1].m_Handler = (IUIButtonClickHandler) this;
    uiButtonArray[2] = child.GetChild(2).GetComponent<UIButton>();
    uiButtonArray[2].m_BtnID1 = 2;
    uiButtonArray[2].m_Handler = (IUIButtonClickHandler) this;
    uiButtonArray[3] = child.GetChild(5).GetComponent<UIButton>();
    uiButtonArray[3].m_BtnID1 = 3;
    uiButtonArray[3].m_Handler = (IUIButtonClickHandler) this;
    child.GetChild(3).GetChild(3).SetParent(((Component) uiButtonArray[2]).transform, false);
    child.GetChild(3).GetChild(2).SetParent(((Component) uiButtonArray[1]).transform, false);
    child.GetChild(3).GetChild(1).SetParent(((Component) uiButtonArray[2]).transform, false);
    child.GetChild(3).GetChild(0).SetParent(((Component) uiButtonArray[1]).transform, false);
    RectTransform component2 = ((Component) uiButtonArray[2]).transform.GetChild(0).GetComponent<RectTransform>();
    Vector2 anchoredPosition1 = component2.anchoredPosition with
    {
      y = 0.0f
    };
    component2.anchoredPosition = anchoredPosition1;
    RectTransform component3 = ((Component) uiButtonArray[2]).transform.GetChild(1).GetComponent<RectTransform>();
    Vector2 anchoredPosition2 = component3.anchoredPosition with
    {
      y = 0.0f
    };
    component3.anchoredPosition = anchoredPosition2;
    RectTransform component4 = ((Component) uiButtonArray[1]).transform.GetChild(0).GetComponent<RectTransform>();
    Vector2 anchoredPosition3 = component4.anchoredPosition with
    {
      y = 0.0f
    };
    component4.anchoredPosition = anchoredPosition3;
    RectTransform component5 = ((Component) uiButtonArray[1]).transform.GetChild(1).GetComponent<RectTransform>();
    Vector2 anchoredPosition4 = component5.anchoredPosition with
    {
      y = 0.0f
    };
    component5.anchoredPosition = anchoredPosition4;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    for (int index = 0; index < this.RefreshText.Length; ++index)
    {
      ((Behaviour) this.RefreshText[index]).enabled = false;
      ((Behaviour) this.RefreshText[index]).enabled = true;
    }
  }

  public override void OnClose()
  {
    if (this.PaySetting <= (byte) 0)
      return;
    DataManager.Instance.MySysSetting.mPaySetting = this.PaySetting;
    PlayerPrefs.SetString("Other_mPaySetting", DataManager.Instance.MySysSetting.mPaySetting.ToString());
    if (this.Type == byte.MaxValue)
    {
      MerchantmanManager.Instance.SendReQusetBlackMarket_Buy((byte) this.BuyID, false);
    }
    else
    {
      if (this.BuyID <= 0U)
        return;
      if (this.Type == (byte) 0)
        MallManager.Instance.Send_Mall_Check((ushort) this.BuyID, false);
      else
        MallManager.Instance.Send_SPTREASURE_PREBUY_CHECK((ESpcialTreasureType) ((int) this.Type - 1), this.BuyID, false);
    }
  }

  private enum UIControl
  {
    Background,
    WeChatPay,
    AliPay,
    Icon,
    Check,
    Close,
  }

  private enum ClickType
  {
    WeChat = 1,
    Ali = 2,
    Close = 3,
    Check = 4,
  }
}
