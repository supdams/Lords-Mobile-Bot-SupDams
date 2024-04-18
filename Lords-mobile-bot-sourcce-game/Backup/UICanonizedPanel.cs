// Decompiled with JetBrains decompiler
// Type: UICanonizedPanel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal class UICanonizedPanel : GUIWindow, IUIButtonClickHandler
{
  private RectTransform btnRect1;
  private RectTransform btnRect2;
  private RectTransform btnRect3;
  private UIText text1;
  private UIText text2;
  private UIText text3;
  private Image background;
  private RectTransform panelRt;

  public override void OnOpen(int arg1, int arg2)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    Transform child = this.transform.GetChild(0);
    this.background = child.GetComponent<Image>();
    this.background.sprite = GUIManager.Instance.LoadFrameSprite("UI_kmap_black_01");
    ((MaskableGraphic) this.background).material = GUIManager.Instance.GetFrameMaterial();
    this.background.type = (Image.Type) 1;
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      ((RectTransform) child).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) child).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    UIButton component1 = this.transform.GetChild(0).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 0;
    this.panelRt = this.transform.GetChild(1).GetComponent<RectTransform>();
    Image component2 = this.transform.GetChild(1).GetComponent<Image>();
    component2.sprite = GUIManager.Instance.LoadFrameSprite("UI_league_box_11");
    ((MaskableGraphic) component2).material = GUIManager.Instance.GetFrameMaterial();
    component2.type = (Image.Type) 1;
    this.btnRect1 = this.transform.GetChild(1).GetChild(0).GetComponent<RectTransform>();
    Image component3 = this.transform.GetChild(1).GetChild(0).GetComponent<Image>();
    component3.sprite = GUIManager.Instance.LoadFrameSprite("UI_con_butt_08");
    ((MaskableGraphic) component3).material = GUIManager.Instance.GetFrameMaterial();
    component3.type = (Image.Type) 1;
    this.text1 = this.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text1.font = GUIManager.Instance.GetTTFFont();
    this.text1.text = DataManager.Instance.mStringTable.GetStringByID(11007U);
    UIButton component4 = this.transform.GetChild(1).GetChild(0).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_BtnID1 = 1;
    this.btnRect2 = this.transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
    Image component5 = this.transform.GetChild(1).GetChild(1).GetComponent<Image>();
    component5.sprite = GUIManager.Instance.LoadFrameSprite("UI_con_butt_08");
    ((MaskableGraphic) component5).material = GUIManager.Instance.GetFrameMaterial();
    component5.type = (Image.Type) 1;
    this.text2 = this.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text2.font = GUIManager.Instance.GetTTFFont();
    this.text2.text = DataManager.Instance.mStringTable.GetStringByID(11077U);
    UIButton component6 = this.transform.GetChild(1).GetChild(1).GetComponent<UIButton>();
    component6.m_Handler = (IUIButtonClickHandler) this;
    component6.m_BtnID1 = 2;
    this.btnRect3 = this.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
    Image component7 = this.transform.GetChild(1).GetChild(2).GetComponent<Image>();
    component7.sprite = GUIManager.Instance.LoadFrameSprite("UI_con_butt_08");
    ((MaskableGraphic) component7).material = GUIManager.Instance.GetFrameMaterial();
    component7.type = (Image.Type) 1;
    this.text3 = this.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<UIText>();
    this.text3.font = GUIManager.Instance.GetTTFFont();
    this.text3.text = DataManager.Instance.mStringTable.GetStringByID(11008U);
    UIButton component8 = this.transform.GetChild(1).GetChild(2).GetComponent<UIButton>();
    component8.m_Handler = (IUIButtonClickHandler) this;
    component8.m_BtnID1 = 3;
    switch (arg1)
    {
      case 0:
        ((Graphic) this.background).color = new Color(1f, 1f, 1f, 0.0f);
        this.panelRt.anchoredPosition = new Vector2(1.5f, -87.5f);
        break;
      case 1:
        ((Graphic) this.background).color = new Color(1f, 1f, 1f, 0.698f);
        break;
    }
    this.SetBtnPos(arg2);
  }

  public override void OnClose()
  {
  }

  public override void UpdateUI(int arg1, int arg2)
  {
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
  }

  public override bool OnBackButtonClick() => false;

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_CanonizedPanel);
        break;
      case 1:
        TitleManager.Instance.OpenTitleListW(GUIManager.Instance.CanonizedName);
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_CanonizedPanel);
        break;
      case 2:
        TitleManager.Instance.OpenNobilityTitleSet(GUIManager.Instance.CanonizedName);
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_CanonizedPanel);
        break;
      case 3:
        TitleManager.Instance.OpenTitleSet(GUIManager.Instance.CanonizedName);
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_CanonizedPanel);
        break;
    }
  }

  private void SetBtnPos(int type)
  {
    float[] numArray1 = new float[2]{ 40.5f, -40.5f };
    float[] numArray2 = new float[3]{ 75f, 0.0f, -75f };
    this.panelRt.sizeDelta = this.panelRt.sizeDelta with
    {
      y = 213f
    };
    switch (type)
    {
      case 3:
        ((Component) this.btnRect1).gameObject.SetActive(true);
        ((Component) this.btnRect2).gameObject.SetActive(false);
        ((Component) this.btnRect3).gameObject.SetActive(true);
        this.btnRect1.anchoredPosition = this.btnRect1.anchoredPosition with
        {
          y = numArray1[0]
        };
        this.btnRect3.anchoredPosition = this.btnRect3.anchoredPosition with
        {
          y = numArray1[1]
        };
        break;
      case 5:
        ((Component) this.btnRect1).gameObject.SetActive(false);
        ((Component) this.btnRect2).gameObject.SetActive(true);
        ((Component) this.btnRect3).gameObject.SetActive(true);
        this.btnRect2.anchoredPosition = this.btnRect2.anchoredPosition with
        {
          y = numArray1[0]
        };
        this.btnRect3.anchoredPosition = this.btnRect3.anchoredPosition with
        {
          y = numArray1[1]
        };
        break;
      case 6:
        ((Component) this.btnRect1).gameObject.SetActive(true);
        ((Component) this.btnRect2).gameObject.SetActive(true);
        ((Component) this.btnRect3).gameObject.SetActive(false);
        this.btnRect1.anchoredPosition = this.btnRect1.anchoredPosition with
        {
          y = numArray1[0]
        };
        this.btnRect2.anchoredPosition = this.btnRect2.anchoredPosition with
        {
          y = numArray1[1]
        };
        break;
      case 7:
        ((Component) this.btnRect1).gameObject.SetActive(true);
        ((Component) this.btnRect2).gameObject.SetActive(true);
        ((Component) this.btnRect3).gameObject.SetActive(true);
        this.btnRect1.anchoredPosition = this.btnRect1.anchoredPosition with
        {
          y = numArray2[0]
        };
        Vector2 anchoredPosition = this.btnRect2.anchoredPosition with
        {
          y = numArray2[1]
        };
        this.btnRect2.anchoredPosition = anchoredPosition;
        anchoredPosition = this.btnRect3.anchoredPosition with
        {
          y = numArray2[2]
        };
        this.btnRect3.anchoredPosition = anchoredPosition;
        this.panelRt.sizeDelta = this.panelRt.sizeDelta with
        {
          y = 273f
        };
        break;
    }
  }

  private void Refresh_FontTexture()
  {
    if ((Object) this.text1 != (Object) null && ((Behaviour) this.text1).enabled)
    {
      ((Behaviour) this.text1).enabled = false;
      ((Behaviour) this.text1).enabled = true;
    }
    if ((Object) this.text2 != (Object) null && ((Behaviour) this.text2).enabled)
    {
      ((Behaviour) this.text2).enabled = false;
      ((Behaviour) this.text2).enabled = true;
    }
    if (!((Object) this.text3 != (Object) null) || !((Behaviour) this.text3).enabled)
      return;
    ((Behaviour) this.text3).enabled = false;
    ((Behaviour) this.text3).enabled = true;
  }

  private enum eUICanonizedPanel
  {
    Background,
    Panel,
  }

  private enum eBtn
  {
    Exit,
    Function1,
    Function2,
    Function3,
  }
}
