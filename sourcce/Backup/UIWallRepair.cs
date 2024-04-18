// Decompiled with JetBrains decompiler
// Type: UIWallRepair
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIWallRepair : 
  GUIWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUTimeBarOnTimer
{
  private const int MaxStrCount = 2;
  private const int TextMax = 3;
  private eWallType m_WallType;
  private Image m_WallIcon;
  private Image m_Slider;
  private Image m_Slider_red;
  private Image m_WallImage;
  private Image m_WallTypeTextBg;
  private Image m_WallImage_red;
  private RectTransform m_SliderRect;
  private RectTransform m_WallTypeTextBgRt;
  private UIText m_IconText;
  private UIText m_sliderText;
  private UIText m_WallTypeText;
  private UITimeBar m_TimeBar;
  private Transform m_TimeBar_red;
  private UIText m_TimeText_red;
  private UIText m_TimeInfoText_red;
  private UIButton btn;
  private Image image;
  private Image m_WallImageIcon;
  private CString[] m_Str;
  private string str1;
  private string str2;
  private uint m_NowValue;
  private uint m_MaxValue;
  private float m_SliderTickTime;
  private DataManager DM;
  private Door door;
  private long m_WallBeginTime;
  private int mTextCount;
  private UIText[] m_tmptext = new UIText[3];

  public override void OnOpen(int arg1, int arg2)
  {
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.DM = DataManager.Instance;
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.m_SliderTickTime = 1f;
    this.m_Str = new CString[2];
    for (int index = 0; index < 2; ++index)
      this.m_Str[index] = StringManager.Instance.SpawnString(50);
    Transform child1 = this.transform.GetChild(0);
    this.m_tmptext[this.mTextCount] = child1.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(3746U);
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = child1.GetChild(4).GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(3761U);
    ++this.mTextCount;
    Transform child2 = this.transform.GetChild(1);
    this.m_WallIcon = child2.GetChild(0).GetChild(0).GetComponent<Image>();
    this.m_IconText = child2.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.m_IconText.font = ttfFont;
    this.m_IconText.text = this.DM.mStringTable.GetStringByID(3756U);
    this.m_SliderRect = child2.GetChild(2).GetChild(0).GetComponent<RectTransform>();
    this.m_Slider = child2.GetChild(2).GetChild(0).GetComponent<Image>();
    this.m_sliderText = child2.GetChild(2).GetChild(1).GetComponent<UIText>();
    this.m_sliderText.font = ttfFont;
    this.m_WallImageIcon = child2.GetChild(2).GetChild(2).GetComponent<Image>();
    UIButtonHint uiButtonHint = ((Component) this.m_WallImageIcon).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint.m_Handler = (MonoBehaviour) this;
    ((Component) this.m_WallImageIcon).gameObject.SetActive(true);
    Transform child3 = this.transform.GetChild(2);
    this.m_WallImage = child3.GetChild(0).GetChild(0).GetComponent<Image>();
    this.m_WallImage_red = child3.GetChild(0).GetChild(1).GetComponent<Image>();
    this.m_WallTypeTextBg = child3.GetChild(0).GetChild(0).GetComponent<Image>();
    this.m_WallTypeTextBgRt = child3.GetChild(1).GetChild(0).GetComponent<RectTransform>();
    this.m_WallTypeText = child3.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.m_WallTypeText.font = ttfFont;
    this.m_TimeBar = child3.GetChild(2).GetComponent<UITimeBar>();
    if ((bool) (Object) this.m_TimeBar)
    {
      this.m_TimeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(260f, 30f);
      GUIManager.Instance.CreateTimerBar(this.m_TimeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
      GUIManager.Instance.SetTimerSpriteType(this.m_TimeBar, eTimerSpriteType.Speed);
      child3.GetChild(2).GetChild(5).gameObject.SetActive(false);
      this.m_TimeBar.m_Handler = (IUTimeBarOnTimer) this;
    }
    this.m_TimeBar_red = child3.GetChild(3);
    this.m_Slider_red = this.m_TimeBar_red.GetChild(1).GetComponent<Image>();
    this.m_TimeText_red = this.m_TimeBar_red.GetChild(3).GetComponent<UIText>();
    this.m_TimeText_red.font = ttfFont;
    this.m_TimeInfoText_red = this.m_TimeBar_red.GetChild(2).GetComponent<UIText>();
    this.m_TimeInfoText_red.font = ttfFont;
    this.m_TimeInfoText_red.text = this.DM.mStringTable.GetStringByID(1577U);
    this.btn = this.m_TimeBar_red.GetChild(4).GetComponent<UIButton>();
    this.btn.m_Handler = (IUIButtonClickHandler) this;
    this.btn.m_BtnID1 = 1;
    this.m_tmptext[this.mTextCount] = this.m_TimeBar_red.GetChild(4).GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(1578U);
    ++this.mTextCount;
    Transform child4 = this.transform.GetChild(3);
    this.image = child4.GetComponent<Image>();
    this.image.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.image).material = this.door.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (Object) this.image)
      ((Behaviour) this.image).enabled = false;
    this.btn = child4.GetChild(0).GetComponent<UIButton>();
    this.btn.m_BtnID1 = 0;
    this.btn.m_Handler = (IUIButtonClickHandler) this;
    this.btn.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn.image).material = this.door.LoadMaterial();
    this.CheckWallType();
    if (this.m_WallType == eWallType.eWallComplete)
      ((Behaviour) this.m_WallImage).enabled = false;
    else
      ((Behaviour) this.m_WallImage).enabled = true;
    this.m_NowValue = this.DM.m_WallRepairNowValue;
    this.m_MaxValue = this.DM.m_WallRepairMaxValue;
    this.SetIcon();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    if (!((Object) this.m_TimeBar != (Object) null))
      return;
    GUIManager.Instance.RemoverTimeBaarToList(this.m_TimeBar);
  }

  public override void UpdateUI(int arg1, int arg2) => this.SetSlider();

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_AttribEffectVal:
        this.SetSlider();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.m_IconText != (Object) null && ((Behaviour) this.m_IconText).enabled)
    {
      ((Behaviour) this.m_IconText).enabled = false;
      ((Behaviour) this.m_IconText).enabled = true;
    }
    if ((Object) this.m_sliderText != (Object) null && ((Behaviour) this.m_sliderText).enabled)
    {
      ((Behaviour) this.m_sliderText).enabled = false;
      ((Behaviour) this.m_sliderText).enabled = true;
    }
    if ((Object) this.m_WallTypeText != (Object) null && ((Behaviour) this.m_WallTypeText).enabled)
    {
      ((Behaviour) this.m_WallTypeText).enabled = false;
      ((Behaviour) this.m_WallTypeText).enabled = true;
    }
    if ((Object) this.m_TimeText_red != (Object) null && ((Behaviour) this.m_TimeText_red).enabled)
    {
      ((Behaviour) this.m_TimeText_red).enabled = false;
      ((Behaviour) this.m_TimeText_red).enabled = true;
    }
    if ((Object) this.m_TimeInfoText_red != (Object) null && ((Behaviour) this.m_TimeInfoText_red).enabled)
    {
      ((Behaviour) this.m_TimeInfoText_red).enabled = false;
      ((Behaviour) this.m_TimeInfoText_red).enabled = true;
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.m_tmptext[index] != (Object) null && ((Behaviour) this.m_tmptext[index]).enabled)
      {
        ((Behaviour) this.m_tmptext[index]).enabled = false;
        ((Behaviour) this.m_tmptext[index]).enabled = true;
      }
    }
    if (!((Object) this.m_TimeBar != (Object) null) || !this.m_TimeBar.enabled)
      return;
    this.m_TimeBar.Refresh_FontTexture();
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
  }

  public override bool OnBackButtonClick() => false;

  private void Update()
  {
    this.SetSlider();
    if (this.m_WallType != eWallType.eWallOnFire)
      return;
    this.SetFireTimeBar();
  }

  private void SetWallType(eWallType type)
  {
    this.m_WallType = type;
    if (this.m_WallType == eWallType.eWallComplete)
    {
      this.m_WallTypeTextBgRt.sizeDelta = new Vector2(421f, 76f);
      this.m_WallTypeText.text = DataManager.Instance.mStringTable.GetStringByID(3758U);
      this.m_TimeBar.gameObject.SetActive(false);
      this.m_TimeBar_red.gameObject.SetActive(false);
      ((Behaviour) this.m_WallImage).enabled = false;
      ((Behaviour) this.m_WallImage_red).enabled = false;
    }
    else if (this.m_WallType == eWallType.eWallRepair)
    {
      this.m_WallTypeTextBgRt.sizeDelta = new Vector2(421f, 46f);
      this.m_WallTypeText.text = DataManager.Instance.mStringTable.GetStringByID(3759U);
      this.m_TimeBar.gameObject.SetActive(true);
      this.m_TimeBar_red.gameObject.SetActive(false);
      ((Behaviour) this.m_WallImage).enabled = true;
      ((Behaviour) this.m_WallImage_red).enabled = false;
      if (this.m_WallBeginTime == this.DM.m_WallBeginTime)
        return;
      this.m_WallBeginTime = this.DM.m_WallBeginTime;
      DataManager.Instance.GetQueueBarTitle(EQueueBarIndex.WallRepair, GUIManager.Instance.tmpString, ref this.str1, ref this.str2);
      GUIManager.Instance.SetTimerBar(this.m_TimeBar, this.DM.m_WallBeginTime, this.DM.m_WallTargetTime, 0L, eTimeBarType.CancelType, this.str1, this.str2);
    }
    else
    {
      if (this.m_WallType != eWallType.eWallOnFire)
        return;
      this.m_WallTypeTextBgRt.sizeDelta = new Vector2(421f, 46f);
      this.m_WallTypeText.text = DataManager.Instance.mStringTable.GetStringByID(1576U);
      this.m_TimeBar.gameObject.SetActive(false);
      this.m_TimeBar_red.gameObject.SetActive(true);
      ((Behaviour) this.m_WallImage).enabled = false;
      ((Behaviour) this.m_WallImage_red).enabled = true;
    }
  }

  private void SetIcon()
  {
    this.m_WallIcon.sprite = GUIManager.Instance.BuildingData.GetBuildSprite((ushort) 12, GUIManager.Instance.BuildingData.GetBuildData((ushort) 12, (ushort) 0).Level);
    ((MaskableGraphic) this.m_WallIcon).material = GUIManager.Instance.BuildingData.mapspriteManager.SpriteUIMaterial;
    this.m_WallIcon.SetNativeSize();
  }

  private void SetSlider()
  {
    this.m_SliderTickTime += Time.deltaTime;
    if ((double) this.m_SliderTickTime >= 1.0)
    {
      if (this.m_Str[0] != null)
      {
        this.m_NowValue = this.DM.m_WallRepairNowValue;
        this.m_MaxValue = this.DM.m_WallRepairMaxValue;
        this.m_Str[0].ClearString();
        StringManager.Instance.IntToFormat((long) this.m_NowValue, bNumber: true);
        StringManager.Instance.IntToFormat((long) this.m_MaxValue, bNumber: true);
        if (GUIManager.Instance.IsArabic)
          this.m_Str[0].AppendFormat("{1}/{0}");
        else
          this.m_Str[0].AppendFormat("{0}/{1}");
        this.m_sliderText.text = this.m_Str[0].ToString();
        this.m_sliderText.SetAllDirty();
        this.m_sliderText.cachedTextGenerator.Invalidate();
      }
      this.m_SliderTickTime = 0.0f;
    }
    this.m_SliderRect.sizeDelta = new Vector2(152.5f * ((float) this.m_NowValue / (float) this.m_MaxValue), 20f);
    this.CheckWallType();
  }

  private void CheckWallType()
  {
    if (this.DM.m_WallRepairMaxValue != 0U && (int) this.DM.m_WallRepairNowValue == (int) this.DM.m_WallRepairMaxValue)
      this.SetWallType(eWallType.eWallComplete);
    else if (LandWalkerManager.IsBattleFire())
      this.SetWallType(eWallType.eWallOnFire);
    else
      this.SetWallType(eWallType.eWallRepair);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        this.door.CloseMenu();
        break;
      case 1:
        GUIManager.Instance.UseOrSpend((ushort) 1234, this.DM.mStringTable.GetStringByID(1505U), (ushort) 0, (ushort) 0, (ushort) 0, maxcount: (ushort) 0);
        break;
    }
  }

  public void OnTimer(UITimeBar sender)
  {
  }

  public void OnNotify(UITimeBar sender)
  {
  }

  public void Onfunc(UITimeBar sender)
  {
    switch (sender.m_TimerSpriteType)
    {
      case eTimerSpriteType.Speed:
        GUIManager.Instance.OpenMenu(EGUIWindow.UI_BagFilter, 2, 16);
        break;
      case eTimerSpriteType.Free:
        DataManager.Instance.SendHeroStarUp_Free();
        break;
    }
  }

  public void OnCancel(UITimeBar sender)
  {
  }

  public void SetFireTimeBar()
  {
    if (DataManager.Instance.ServerTime <= LandWalkerManager.LastBattleTime)
      return;
    this.m_Str[1].ClearString();
    ushort num = !LandWalkerManager.isWinning ? (ushort) 1200 : (ushort) 1200;
    GameConstants.GetTimeString(this.m_Str[1], (uint) (LandWalkerManager.LastBattleTime + (long) num - DataManager.Instance.ServerTime));
    this.m_TimeText_red.text = this.m_Str[1].ToString();
    this.m_TimeText_red.SetAllDirty();
    this.m_TimeText_red.cachedTextGenerator.Invalidate();
    ((Graphic) this.m_Slider_red).rectTransform.sizeDelta = new Vector2(211.5f * Mathf.Clamp((float) (DataManager.Instance.ServerTime - LandWalkerManager.LastBattleTime) / (float) num, 0.0f, 1f), 18.4f);
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, 11167, 0, Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Hide((bool) (Object) sender);
  }
}
