// Decompiled with JetBrains decompiler
// Type: UIOther_Account
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIOther_Account : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int MaxScrollCount = 5;
  private const float ScrollItemHeight = 54f;
  private const int MaxTempTextNum = 36;
  private Font TTF;
  private GUIManager GM;
  private DataManager DM;
  private IGGGameSDK SDK;
  private Door m_Door;
  private string AssName = "UIOther";
  private int MaxStr = 4;
  private AccItemObject[] m_ItemObject;
  private Image m_GIcon;
  private Image m_SettingAccImage;
  private UIText m_SettingTitleText;
  private UIText m_SettingIGGIDText;
  private UIText m_SettingAccText;
  private UIText m_BindAccountText;
  private Transform m_BindGiftTf;
  private Image m_SwitchEmpty;
  private UIText m_SwitchTitleText;
  private UIButton m_BindBtn;
  private UIButton m_LogoutBtn;
  private UIButton m_SwitchBtn;
  private UIButton m_SwitchPlatform;
  private UIButton m_RealName;
  private UIButton m_YesBtn;
  private UIButton m_NoBtn;
  private Transform m_SettingPanel;
  private Transform m_SwitchPanel;
  private Transform m_CrossPlatformPanel;
  private Transform m_PlatformBindPanel;
  private Transform m_PlatformLoginPanel;
  private Transform m_SwitchGoogleAccountPanel;
  private Transform m_CrossPlatformList;
  private Transform m_SwitchWechatFacebookPlatform;
  private Transform m_WeChatPlatformLogin;
  private Transform m_FBPlatformLogin;
  private ScrollPanel m_ScrollPanel;
  private CString[] m_Str;
  private List<sAccount> m_Data;
  private eUIAccountType m_UIType;
  private int NowSelectDataIdx;
  private bool bScrollPanelInit;
  private UIText[] m_TempText = new UIText[36];
  private int m_TempTextIdx;
  private Material mat;
  private Image[] m_RotImage = new Image[9];
  private byte UseWechat;
  private UIOther_Account.eCrossType CrossType;
  private Sprite[] CrossPlatformIcons = new Sprite[2];
  private UIOther_Account._CrossPlatformSetup CrossPlatformSetup;

  public override void OnOpen(int arg1, int arg2)
  {
    this.GM = GUIManager.Instance;
    this.DM = DataManager.Instance;
    this.TTF = this.GM.GetTTFFont();
    this.SDK = IGGGameSDK.Instance;
    this.m_Door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.SetFakeDate();
    HelperUIButton helperUiButton = this.gameObject.AddComponent<HelperUIButton>();
    helperUiButton.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton.m_BtnID1 = 5;
    for (int index = 0; index < this.transform.childCount; ++index)
      Object.Destroy((Object) this.transform.GetChild(index).GetChild(0).GetComponent<IgnoreRaycast>());
    this.m_Str = new CString[this.MaxStr];
    for (int index = 0; index < this.MaxStr; ++index)
      this.m_Str[index] = StringManager.Instance.SpawnString();
    this.m_Data = new List<sAccount>();
    this.m_ItemObject = new AccItemObject[5];
    for (int index = 0; index < 5; ++index)
      this.m_ItemObject[index].Str = StringManager.Instance.SpawnString();
    this.GM.AddSpriteAsset(this.AssName);
    this.mat = this.GM.LoadMaterial(this.AssName, "UI_other_m");
    Image component1 = this.transform.GetComponent<Image>();
    component1.sprite = this.GM.LoadSprite(this.AssName, "UI_con_black_02");
    ((MaskableGraphic) component1).material = this.mat;
    if (this.GM.bOpenOnIPhoneX)
    {
      ((RectTransform) this.transform).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.transform).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0.0f);
    }
    Transform child1 = this.transform.GetChild(0);
    this.m_SettingPanel = child1;
    Image component2 = child1.GetChild(0).GetComponent<Image>();
    component2.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
    ((MaskableGraphic) component2).material = this.mat;
    this.m_SettingPanel = child1;
    Image component3 = child1.GetChild(0).GetChild(0).GetComponent<Image>();
    component3.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
    ((MaskableGraphic) component3).material = this.mat;
    component3.type = (Image.Type) 1;
    this.m_GIcon = child1.GetChild(1).GetComponent<Image>();
    this.SetLoginIcon();
    this.m_RotImage[0] = this.m_GIcon;
    this.m_SettingAccImage = child1.GetChild(2).GetComponent<Image>();
    this.m_SettingAccImage.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_10");
    ((MaskableGraphic) this.m_SettingAccImage).material = this.mat;
    this.m_SettingTitleText = child1.GetChild(3).GetComponent<UIText>();
    this.m_SettingTitleText.font = this.TTF;
    this.m_SettingIGGIDText = child1.GetChild(4).GetComponent<UIText>();
    this.m_SettingIGGIDText.font = this.TTF;
    this.m_SettingAccText = child1.GetChild(5).GetComponent<UIText>();
    this.m_SettingAccText.font = this.TTF;
    this.m_BindAccountText = child1.GetChild(6).GetComponent<UIText>();
    this.m_BindAccountText.font = this.TTF;
    this.m_BindAccountText.text = this.DM.mStringTable.GetStringByID(7080U);
    this.m_BindGiftTf = child1.GetChild(7);
    Image component4 = this.m_BindGiftTf.GetComponent<Image>();
    component4.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_14");
    ((MaskableGraphic) component4).material = this.mat;
    Image component5 = this.m_BindGiftTf.GetChild(1).GetComponent<Image>();
    component5.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_09");
    ((MaskableGraphic) component5).material = this.mat;
    UIText component6 = this.m_BindGiftTf.GetChild(0).GetComponent<UIText>();
    component6.font = this.TTF;
    component6.text = this.DM.mStringTable.GetStringByID(8409U);
    this.SetCenterText(component5, component6, 600f);
    this.m_TempText[this.m_TempTextIdx++] = component6;
    this.m_BindBtn = child1.GetChild(8).GetComponent<UIButton>();
    this.m_BindBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_BindBtn.m_BtnID1 = 0;
    this.m_BindBtn.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_02");
    ((MaskableGraphic) this.m_BindBtn.image).material = this.mat;
    UIText component7 = child1.GetChild(8).GetChild(0).GetComponent<UIText>();
    component7.font = this.TTF;
    component7.text = this.DM.mStringTable.GetStringByID(7074U);
    this.m_TempText[this.m_TempTextIdx++] = component7;
    this.m_LogoutBtn = child1.GetChild(9).GetComponent<UIButton>();
    this.m_LogoutBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_LogoutBtn.m_BtnID1 = 1;
    this.m_LogoutBtn.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) this.m_LogoutBtn.image).material = this.mat;
    UIText component8 = child1.GetChild(9).GetChild(0).GetComponent<UIText>();
    component8.font = this.TTF;
    component8.text = this.DM.mStringTable.GetStringByID(9015U);
    this.m_TempText[this.m_TempTextIdx++] = component8;
    this.m_SwitchBtn = child1.GetChild(10).GetComponent<UIButton>();
    this.m_SwitchBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_SwitchBtn.m_BtnID1 = 2;
    this.m_SwitchBtn.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) this.m_SwitchBtn.image).material = this.mat;
    UIText component9 = child1.GetChild(10).GetChild(0).GetComponent<UIText>();
    component9.font = this.TTF;
    component9.text = this.DM.mStringTable.GetStringByID(7075U);
    Image component10 = child1.GetChild(10).GetChild(1).GetComponent<Image>();
    component10.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_08");
    component10.SetNativeSize();
    this.m_RotImage[1] = component10;
    ((Component) component10).gameObject.SetActive(false);
    ((Graphic) component9).rectTransform.anchoredPosition = new Vector2(35.5f, 0.0f);
    ((MaskableGraphic) component10).material = this.mat;
    this.m_TempText[this.m_TempTextIdx++] = component9;
    this.m_SwitchPlatform = child1.GetChild(11).GetComponent<UIButton>();
    this.m_SwitchPlatform.m_Handler = (IUIButtonClickHandler) this;
    this.m_SwitchPlatform.m_BtnID1 = 3;
    this.m_SwitchPlatform.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) this.m_SwitchPlatform.image).material = this.mat;
    this.m_SwitchPlatform.image.type = (Image.Type) 1;
    UIText component11 = child1.GetChild(11).GetChild(0).GetComponent<UIText>();
    component11.font = this.TTF;
    component11.text = this.DM.mStringTable.GetStringByID(9001U);
    this.m_TempText[this.m_TempTextIdx++] = component11;
    this.m_RealName = child1.GetChild(13).GetComponent<UIButton>();
    this.m_RealName.m_Handler = (IUIButtonClickHandler) this;
    this.m_RealName.m_BtnID1 = 4;
    this.m_RealName.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) this.m_RealName.image).material = this.mat;
    this.m_RealName.image.type = (Image.Type) 1;
    UIText component12 = child1.GetChild(13).GetChild(0).GetComponent<UIText>();
    component12.font = this.TTF;
    component12.text = this.DM.mStringTable.GetStringByID(9677U);
    this.m_TempText[this.m_TempTextIdx++] = component12;
    ((Component) this.m_SwitchPlatform).gameObject.SetActive(true);
    UIButton component13 = child1.GetChild(12).GetComponent<UIButton>();
    component13.image.sprite = this.m_Door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component13.image).material = this.m_Door.LoadMaterial();
    component13.image.SetNativeSize();
    component13.m_Handler = (IUIButtonClickHandler) this;
    component13.m_BtnID1 = 5;
    Transform child2 = this.transform.GetChild(1);
    this.m_SwitchPanel = child2;
    Image component14 = child2.GetChild(0).GetComponent<Image>();
    component14.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
    ((MaskableGraphic) component14).material = this.mat;
    Image component15 = child2.GetChild(0).GetChild(0).GetComponent<Image>();
    component15.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
    ((MaskableGraphic) component15).material = this.mat;
    component15.type = (Image.Type) 1;
    this.m_SwitchTitleText = child2.GetChild(1).GetComponent<UIText>();
    this.m_SwitchTitleText.font = this.TTF;
    this.m_SwitchTitleText.text = this.DM.mStringTable.GetStringByID(7076U);
    Image component16 = child2.GetChild(2).GetComponent<Image>();
    component16.sprite = this.GM.LoadSprite(this.AssName, "UI_other_alpha");
    ((MaskableGraphic) component16).material = this.mat;
    this.m_ScrollPanel = child2.GetChild(2).GetComponent<ScrollPanel>();
    this.m_YesBtn = child2.GetChild(3).GetComponent<UIButton>();
    this.m_YesBtn.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) this.m_YesBtn.image).material = this.mat;
    UIText component17 = child2.GetChild(3).GetChild(0).GetComponent<UIText>();
    component17.font = this.TTF;
    component17.text = this.DM.mStringTable.GetStringByID(7077U);
    this.m_TempText[this.m_TempTextIdx++] = component17;
    this.m_YesBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_YesBtn.m_BtnID1 = 7;
    this.m_NoBtn = child2.GetChild(4).GetComponent<UIButton>();
    this.m_NoBtn.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_02");
    ((MaskableGraphic) this.m_NoBtn.image).material = this.mat;
    this.m_NoBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_NoBtn.m_BtnID1 = 8;
    UIText component18 = child2.GetChild(4).GetChild(0).GetComponent<UIText>();
    component18.font = this.TTF;
    component18.text = this.DM.mStringTable.GetStringByID(7078U);
    this.m_TempText[this.m_TempTextIdx++] = component18;
    UIButton component19 = child2.GetChild(5).GetComponent<UIButton>();
    component19.image.sprite = this.m_Door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component19.image).material = this.m_Door.LoadMaterial();
    component19.image.SetNativeSize();
    component19.m_Handler = (IUIButtonClickHandler) this;
    component19.m_BtnID1 = 6;
    ((MaskableGraphic) child2.GetChild(6).GetComponent<Image>()).material = this.mat;
    Image component20 = child2.GetChild(6).GetChild(0).GetComponent<Image>();
    component20.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_12_a");
    ((MaskableGraphic) component20).material = this.mat;
    Image component21 = child2.GetChild(6).GetChild(1).GetComponent<Image>();
    component21.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_12_b");
    ((MaskableGraphic) component21).material = this.mat;
    Image component22 = child2.GetChild(6).GetChild(2).GetComponent<Image>();
    component22.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_03");
    ((MaskableGraphic) component22).material = this.mat;
    Image component23 = child2.GetChild(6).GetChild(2).GetChild(0).GetComponent<Image>();
    component23.sprite = this.GM.LoadSprite(this.AssName, "UI_other_select");
    ((MaskableGraphic) component23).material = this.mat;
    UIText component24 = child2.GetChild(6).GetChild(3).GetComponent<UIText>();
    component24.font = this.TTF;
    this.m_TempText[this.m_TempTextIdx++] = component24;
    this.m_SwitchEmpty = child2.GetChild(7).GetComponent<Image>();
    this.m_SwitchEmpty.sprite = this.GM.LoadSprite(this.AssName, "UI_market_bar_01");
    ((MaskableGraphic) this.m_SwitchEmpty).material = this.mat;
    UIText component25 = child2.GetChild(7).GetChild(0).GetComponent<UIText>();
    component25.font = this.TTF;
    component25.text = this.DM.mStringTable.GetStringByID(7087U);
    this.m_TempText[this.m_TempTextIdx++] = component25;
    Transform child3 = this.transform.GetChild(2);
    this.m_CrossPlatformPanel = child3;
    Image component26 = child3.GetChild(0).GetComponent<Image>();
    component26.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
    ((MaskableGraphic) component26).material = this.mat;
    Image component27 = child3.GetChild(0).GetChild(0).GetComponent<Image>();
    component27.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
    ((MaskableGraphic) component27).material = this.mat;
    component27.type = (Image.Type) 1;
    UIText component28 = child3.GetChild(1).GetComponent<UIText>();
    component28.font = this.TTF;
    component28.text = DataManager.Instance.mStringTable.GetStringByID(9001U);
    this.m_TempText[this.m_TempTextIdx++] = component28;
    UIButton component29 = child3.GetChild(2).GetComponent<UIButton>();
    component29.m_Handler = (IUIButtonClickHandler) this;
    component29.m_BtnID1 = 9;
    component29.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) component29.image).material = this.mat;
    UIButton component30 = child3.GetChild(3).GetComponent<UIButton>();
    component30.m_Handler = (IUIButtonClickHandler) this;
    component30.m_BtnID1 = 10;
    component30.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) component30.image).material = this.mat;
    UIButton component31 = child3.GetChild(4).GetComponent<UIButton>();
    component31.m_Handler = (IUIButtonClickHandler) this;
    component31.m_BtnID1 = 11;
    component31.image.sprite = this.m_Door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component31.image).material = this.m_Door.LoadMaterial();
    component31.image.SetNativeSize();
    Image component32 = child3.GetChild(2).GetChild(2).GetComponent<Image>();
    component32.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
    if (GUIManager.Instance.IsArabic)
      ((Component) component32).gameObject.AddComponent<ArabicItemTextureRot>();
    ((MaskableGraphic) component32).material = this.mat;
    component32.SetNativeSize();
    this.CrossPlatformSetup.BindImg = component32;
    this.m_RotImage[2] = component32;
    UIText component33 = child3.GetChild(2).GetChild(1).GetComponent<UIText>();
    component33.font = this.TTF;
    component33.text = DataManager.Instance.mStringTable.GetStringByID(9002U);
    this.m_TempText[this.m_TempTextIdx++] = component33;
    UIText component34 = child3.GetChild(2).GetChild(0).GetComponent<UIText>();
    component34.font = this.TTF;
    component34.text = DataManager.Instance.mStringTable.GetStringByID(7074U);
    this.SetCenterText(component32, component34, 576f);
    this.m_TempText[this.m_TempTextIdx++] = component34;
    Image component35 = child3.GetChild(3).GetChild(2).GetComponent<Image>();
    component35.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
    if (GUIManager.Instance.IsArabic)
      ((Component) component35).gameObject.AddComponent<ArabicItemTextureRot>();
    ((MaskableGraphic) component35).material = this.mat;
    component35.SetNativeSize();
    this.CrossPlatformSetup.LoginImg = component35;
    this.m_RotImage[3] = component35;
    UIText component36 = child3.GetChild(3).GetChild(1).GetComponent<UIText>();
    component36.font = this.TTF;
    component36.text = DataManager.Instance.mStringTable.GetStringByID(9003U);
    this.m_TempText[this.m_TempTextIdx++] = component36;
    UIText component37 = child3.GetChild(3).GetChild(0).GetComponent<UIText>();
    component37.font = this.TTF;
    component37.text = DataManager.Instance.mStringTable.GetStringByID(8428U);
    this.SetCenterText(component35, component37, 576f);
    this.m_TempText[this.m_TempTextIdx++] = component37;
    Transform child4 = this.transform.GetChild(3);
    this.m_PlatformBindPanel = child4;
    Image component38 = child4.GetChild(0).GetComponent<Image>();
    component38.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
    ((MaskableGraphic) component38).material = this.mat;
    component38.type = (Image.Type) 1;
    Image component39 = child4.GetChild(0).GetChild(0).GetComponent<Image>();
    component39.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
    ((MaskableGraphic) component39).material = this.mat;
    component39.type = (Image.Type) 1;
    UIText component40 = child4.GetChild(1).GetComponent<UIText>();
    component40.font = this.TTF;
    component40.text = DataManager.Instance.mStringTable.GetStringByID(9004U);
    this.m_TempText[this.m_TempTextIdx++] = component40;
    this.CrossPlatformSetup.BindTitle = component40;
    UIText component41 = child4.GetChild(2).GetComponent<UIText>();
    component41.font = this.TTF;
    component41.text = DataManager.Instance.mStringTable.GetStringByID(7067U);
    this.m_TempText[this.m_TempTextIdx++] = component41;
    this.m_Str[3].ClearString();
    this.m_Str[3].StringToFormat(this.SDK.m_IGGID);
    this.m_Str[3].AppendFormat(this.DM.mStringTable.GetStringByID(7067U));
    component41.text = this.m_Str[3].ToString();
    this.m_TempText[this.m_TempTextIdx++] = component41;
    UIText component42 = child4.GetChild(3).GetComponent<UIText>();
    component42.font = this.TTF;
    component42.text = DataManager.Instance.mStringTable.GetStringByID(9005U);
    this.CrossPlatformSetup.Tip = component42;
    component42.resizeTextForBestFit = true;
    component42.resizeTextMaxSize = 24;
    component42.resizeTextMinSize = 10;
    this.m_TempText[this.m_TempTextIdx++] = component42;
    UIButton component43 = child4.GetChild(4).GetComponent<UIButton>();
    component43.m_Handler = (IUIButtonClickHandler) this;
    component43.m_BtnID1 = 12;
    component43.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) component43.image).material = this.mat;
    Image component44 = child4.GetChild(4).GetChild(0).GetComponent<Image>();
    component44.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
    if (GUIManager.Instance.IsArabic && (Object) ((Component) component44).gameObject.GetComponent<ArabicItemTextureRot>() == (Object) null)
      ((Component) component44).gameObject.AddComponent<ArabicItemTextureRot>();
    ((MaskableGraphic) component44).material = this.mat;
    component44.SetNativeSize();
    this.CrossPlatformSetup.BindPanelImg = component44;
    this.m_RotImage[4] = component44;
    UIText component45 = child4.GetChild(4).GetChild(1).GetComponent<UIText>();
    component45.font = this.TTF;
    component45.text = DataManager.Instance.mStringTable.GetStringByID(7074U);
    this.m_TempText[this.m_TempTextIdx++] = component45;
    UIButton component46 = child4.GetChild(5).GetComponent<UIButton>();
    component46.m_Handler = (IUIButtonClickHandler) this;
    component46.m_BtnID1 = 13;
    component46.image.sprite = this.m_Door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component46.image).material = this.m_Door.LoadMaterial();
    component46.image.SetNativeSize();
    this.SetCenterText(component44, component45, 576f);
    Transform child5 = this.transform.GetChild(4);
    this.m_PlatformLoginPanel = child5;
    Image component47 = child5.GetChild(0).GetComponent<Image>();
    component47.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
    ((MaskableGraphic) component47).material = this.mat;
    component47.type = (Image.Type) 1;
    Image component48 = child5.GetChild(0).GetChild(0).GetComponent<Image>();
    component48.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
    ((MaskableGraphic) component48).material = this.mat;
    component48.type = (Image.Type) 1;
    UIText component49 = child5.GetChild(1).GetComponent<UIText>();
    component49.font = this.TTF;
    component49.text = DataManager.Instance.mStringTable.GetStringByID(9009U);
    this.CrossPlatformSetup.LoginTitle = component49;
    UIText component50 = child5.GetChild(2).GetComponent<UIText>();
    component50.font = this.TTF;
    component50.text = DataManager.Instance.mStringTable.GetStringByID(9010U);
    this.m_TempText[this.m_TempTextIdx++] = component50;
    this.CrossPlatformSetup.Title = component50;
    UIButton component51 = child5.GetChild(3).GetComponent<UIButton>();
    component51.m_Handler = (IUIButtonClickHandler) this;
    component51.m_BtnID1 = 14;
    component51.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) component51.image).material = this.mat;
    UIButton component52 = child5.GetChild(4).GetComponent<UIButton>();
    component52.m_Handler = (IUIButtonClickHandler) this;
    component52.m_BtnID1 = 15;
    component52.image.sprite = this.m_Door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component52.image).material = this.m_Door.LoadMaterial();
    component52.image.SetNativeSize();
    Image component53 = child5.GetChild(3).GetChild(0).GetComponent<Image>();
    component53.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
    if (GUIManager.Instance.IsArabic && (Object) ((Component) component53).gameObject.GetComponent<ArabicItemTextureRot>() == (Object) null)
      ((Component) component53).gameObject.AddComponent<ArabicItemTextureRot>();
    ((MaskableGraphic) component53).material = this.mat;
    component53.SetNativeSize();
    this.CrossPlatformSetup.LoginPanelImg = component53;
    this.m_RotImage[5] = component53;
    UIText component54 = child5.GetChild(3).GetChild(1).GetComponent<UIText>();
    component54.font = this.TTF;
    component54.text = this.DM.mStringTable.GetStringByID(8428U);
    this.SetCenterText(component53, component54, 576f);
    this.m_TempText[this.m_TempTextIdx++] = component54;
    Transform child6 = this.transform.GetChild(5);
    this.m_SwitchGoogleAccountPanel = child6;
    Image component55 = child6.GetChild(0).GetComponent<Image>();
    component55.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
    ((MaskableGraphic) component55).material = this.mat;
    Image component56 = child6.GetChild(0).GetChild(0).GetComponent<Image>();
    component56.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
    ((MaskableGraphic) component56).material = this.mat;
    component56.type = (Image.Type) 1;
    UIText component57 = child6.GetChild(1).GetComponent<UIText>();
    component57.font = this.TTF;
    component57.text = DataManager.Instance.mStringTable.GetStringByID(7075U);
    this.m_TempText[this.m_TempTextIdx++] = component57;
    UIButton component58 = child6.GetChild(2).GetComponent<UIButton>();
    component58.m_Handler = (IUIButtonClickHandler) this;
    component58.m_BtnID1 = 16;
    component58.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) component58.image).material = this.mat;
    UIButton component59 = child6.GetChild(3).GetComponent<UIButton>();
    component59.m_Handler = (IUIButtonClickHandler) this;
    component59.m_BtnID1 = 17;
    component59.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) component59.image).material = this.mat;
    UIText component60 = child6.GetChild(2).GetChild(0).GetComponent<UIText>();
    component60.font = this.TTF;
    component60.text = DataManager.Instance.mStringTable.GetStringByID(7069U);
    this.m_TempText[this.m_TempTextIdx++] = component60;
    UIButton component61 = child6.GetChild(4).GetComponent<UIButton>();
    component61.m_Handler = (IUIButtonClickHandler) this;
    component61.m_BtnID1 = 18;
    component61.image.sprite = this.m_Door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component61.image).material = this.m_Door.LoadMaterial();
    component61.image.SetNativeSize();
    UIText component62 = child6.GetChild(3).GetChild(0).GetComponent<UIText>();
    component62.font = this.TTF;
    component62.text = DataManager.Instance.mStringTable.GetStringByID(7075U);
    component62.text = DataManager.Instance.mStringTable.GetStringByID(16016U);
    this.m_TempText[this.m_TempTextIdx++] = component62;
    Image component63 = child6.GetChild(3).GetChild(1).GetComponent<Image>();
    component63.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_08");
    ((Graphic) component63).rectTransform.sizeDelta = new Vector2(64f, 65f);
    ((Graphic) component63).rectTransform.anchoredPosition = new Vector2(-199.5f, -19f);
    ((Graphic) component62).rectTransform.anchoredPosition = new Vector2(281f, -35.5f);
    ((MaskableGraphic) component63).material = this.mat;
    this.m_RotImage[6] = component63;
    this.SetCenterText(component63, component62, 576f);
    Transform child7 = this.transform.GetChild(6);
    this.m_CrossPlatformList = child7;
    Image component64 = child7.GetChild(0).GetComponent<Image>();
    component64.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
    ((MaskableGraphic) component64).material = this.mat;
    Image component65 = child7.GetChild(0).GetChild(0).GetComponent<Image>();
    component65.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
    ((MaskableGraphic) component65).material = this.mat;
    component65.type = (Image.Type) 1;
    UIText component66 = child7.GetChild(1).GetComponent<UIText>();
    component66.font = this.TTF;
    component66.text = DataManager.Instance.mStringTable.GetStringByID(9001U);
    this.m_TempText[this.m_TempTextIdx++] = component66;
    UIButton component67 = child7.GetChild(2).GetComponent<UIButton>();
    component67.m_Handler = (IUIButtonClickHandler) this;
    component67.m_BtnID1 = 19;
    component67.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) component67.image).material = this.mat;
    UIButton component68 = child7.GetChild(3).GetComponent<UIButton>();
    component68.m_Handler = (IUIButtonClickHandler) this;
    component68.m_BtnID1 = 20;
    component68.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) component68.image).material = this.mat;
    UIText component69 = child7.GetChild(2).GetChild(0).GetComponent<UIText>();
    component69.font = this.TTF;
    component69.text = this.DM.mStringTable.GetStringByID(8427U);
    this.m_TempText[this.m_TempTextIdx++] = component69;
    Image component70 = child7.GetChild(2).GetChild(1).GetComponent<Image>();
    component70.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
    this.CrossPlatformIcons[0] = component70.sprite;
    ((MaskableGraphic) component70).material = this.mat;
    component70.SetNativeSize();
    this.m_RotImage[7] = component70;
    Image component71 = child7.GetChild(3).GetChild(1).GetComponent<Image>();
    component71.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_19");
    this.CrossPlatformIcons[1] = component71.sprite;
    ((MaskableGraphic) component71).material = this.mat;
    component71.SetNativeSize();
    this.m_RotImage[8] = component71;
    UIText component72 = child7.GetChild(3).GetChild(0).GetComponent<UIText>();
    component72.font = this.TTF;
    component72.text = DataManager.Instance.mStringTable.GetStringByID(9514U);
    UIButton component73 = child7.GetChild(4).GetComponent<UIButton>();
    component73.image.sprite = this.m_Door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component73.image).material = this.m_Door.LoadMaterial();
    component73.image.SetNativeSize();
    component73.m_Handler = (IUIButtonClickHandler) this;
    component73.m_BtnID1 = 21;
    Transform child8 = this.transform.GetChild(7);
    this.m_SwitchWechatFacebookPlatform = child8;
    Image component74 = child8.GetChild(0).GetComponent<Image>();
    component74.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
    ((MaskableGraphic) component74).material = this.mat;
    Image component75 = child8.GetChild(0).GetChild(0).GetComponent<Image>();
    component75.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
    ((MaskableGraphic) component75).material = this.mat;
    component75.type = (Image.Type) 1;
    UIText component76 = child8.GetChild(1).GetComponent<UIText>();
    component76.font = this.TTF;
    component76.text = DataManager.Instance.mStringTable.GetStringByID(7075U);
    this.m_TempText[this.m_TempTextIdx++] = component76;
    UIButton component77 = child8.GetChild(2).GetComponent<UIButton>();
    component77.m_Handler = (IUIButtonClickHandler) this;
    component77.m_BtnID1 = 26;
    component77.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) component77.image).material = this.mat;
    UIButton component78 = child8.GetChild(3).GetComponent<UIButton>();
    component78.m_Handler = (IUIButtonClickHandler) this;
    component78.m_BtnID1 = 28;
    component78.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) component78.image).material = this.mat;
    UIButton component79 = child8.GetChild(4).GetComponent<UIButton>();
    component79.m_Handler = (IUIButtonClickHandler) this;
    component79.m_BtnID1 = 25;
    component79.image.sprite = this.m_Door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component79.image).material = this.m_Door.LoadMaterial();
    component79.image.SetNativeSize();
    Image component80 = child8.GetChild(2).GetChild(2).GetComponent<Image>();
    component80.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_19");
    ((MaskableGraphic) component80).material = this.mat;
    component80.SetNativeSize();
    this.m_RotImage[2] = component80;
    UIText component81 = child8.GetChild(2).GetChild(1).GetComponent<UIText>();
    component81.font = this.TTF;
    component81.text = DataManager.Instance.mStringTable.GetStringByID(9003U);
    this.m_TempText[this.m_TempTextIdx++] = component81;
    UIText component82 = child8.GetChild(2).GetChild(0).GetComponent<UIText>();
    component82.font = this.TTF;
    component82.text = DataManager.Instance.mStringTable.GetStringByID(8428U);
    this.SetCenterText(component80, component82, 576f);
    this.m_TempText[this.m_TempTextIdx++] = component82;
    Image component83 = child8.GetChild(3).GetChild(2).GetComponent<Image>();
    component83.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
    ((MaskableGraphic) component83).material = this.mat;
    component83.SetNativeSize();
    this.m_RotImage[3] = component83;
    UIText component84 = child8.GetChild(3).GetChild(1).GetComponent<UIText>();
    component84.font = this.TTF;
    component84.text = DataManager.Instance.mStringTable.GetStringByID(9003U);
    this.m_TempText[this.m_TempTextIdx++] = component84;
    UIText component85 = child8.GetChild(3).GetChild(0).GetComponent<UIText>();
    component85.font = this.TTF;
    component85.text = DataManager.Instance.mStringTable.GetStringByID(8428U);
    this.SetCenterText(component83, component85, 576f);
    this.m_TempText[this.m_TempTextIdx++] = component85;
    Transform child9 = this.transform.GetChild(8);
    this.m_WeChatPlatformLogin = child9;
    Image component86 = child9.GetChild(0).GetComponent<Image>();
    component86.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
    ((MaskableGraphic) component86).material = this.mat;
    component86.type = (Image.Type) 1;
    Image component87 = child9.GetChild(0).GetChild(0).GetComponent<Image>();
    component87.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
    ((MaskableGraphic) component87).material = this.mat;
    component87.type = (Image.Type) 1;
    UIText component88 = child9.GetChild(1).GetComponent<UIText>();
    component88.font = this.TTF;
    component88.text = DataManager.Instance.mStringTable.GetStringByID(9516U);
    UIText component89 = child9.GetChild(2).GetComponent<UIText>();
    component89.font = this.TTF;
    component89.text = DataManager.Instance.mStringTable.GetStringByID(9517U);
    this.m_TempText[this.m_TempTextIdx++] = component89;
    UIButton component90 = child9.GetChild(3).GetComponent<UIButton>();
    component90.m_Handler = (IUIButtonClickHandler) this;
    component90.m_BtnID1 = 14;
    component90.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) component90.image).material = this.mat;
    UIButton component91 = child9.GetChild(4).GetComponent<UIButton>();
    component91.m_Handler = (IUIButtonClickHandler) this;
    component91.m_BtnID1 = 27;
    component91.image.sprite = this.m_Door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component91.image).material = this.m_Door.LoadMaterial();
    component91.image.SetNativeSize();
    Image component92 = child9.GetChild(3).GetChild(0).GetComponent<Image>();
    component92.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_19");
    ((MaskableGraphic) component92).material = this.mat;
    component92.SetNativeSize();
    this.m_RotImage[5] = component92;
    UIText component93 = child9.GetChild(3).GetChild(1).GetComponent<UIText>();
    component93.font = this.TTF;
    component93.text = this.DM.mStringTable.GetStringByID(8428U);
    this.SetCenterText(component92, component93, 576f);
    this.m_TempText[this.m_TempTextIdx++] = component93;
    Transform child10 = this.transform.GetChild(9);
    this.m_FBPlatformLogin = child10;
    Image component94 = child10.GetChild(0).GetComponent<Image>();
    component94.sprite = this.GM.LoadSprite(this.AssName, "UI_other_box_08");
    ((MaskableGraphic) component94).material = this.mat;
    component94.type = (Image.Type) 1;
    Image component95 = child10.GetChild(0).GetChild(0).GetComponent<Image>();
    component95.sprite = this.GM.LoadSprite(this.AssName, "UI_con_title_orange");
    ((MaskableGraphic) component95).material = this.mat;
    component95.type = (Image.Type) 1;
    UIText component96 = child10.GetChild(1).GetComponent<UIText>();
    component96.font = this.TTF;
    component96.text = DataManager.Instance.mStringTable.GetStringByID(9516U);
    UIText component97 = child10.GetChild(2).GetComponent<UIText>();
    component97.font = this.TTF;
    component97.text = DataManager.Instance.mStringTable.GetStringByID(9517U);
    this.m_TempText[this.m_TempTextIdx++] = component97;
    UIButton component98 = child10.GetChild(3).GetComponent<UIButton>();
    component98.m_Handler = (IUIButtonClickHandler) this;
    component98.m_BtnID1 = 14;
    component98.image.sprite = this.GM.LoadSprite(this.AssName, "UI_other_butt_01");
    ((MaskableGraphic) component98.image).material = this.mat;
    UIButton component99 = child10.GetChild(4).GetComponent<UIButton>();
    component99.m_Handler = (IUIButtonClickHandler) this;
    component99.m_BtnID1 = 29;
    component99.image.sprite = this.m_Door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component99.image).material = this.m_Door.LoadMaterial();
    component99.image.SetNativeSize();
    Image component100 = child10.GetChild(3).GetChild(0).GetComponent<Image>();
    component100.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_19");
    ((MaskableGraphic) component100).material = this.mat;
    component100.SetNativeSize();
    this.m_RotImage[5] = component100;
    UIText component101 = child10.GetChild(3).GetChild(1).GetComponent<UIText>();
    component101.font = this.TTF;
    component101.text = this.DM.mStringTable.GetStringByID(8428U);
    this.SetCenterText(component100, component101, 576f);
    this.m_TempText[this.m_TempTextIdx++] = component101;
    if (this.GM.IsArabic)
    {
      for (int index = 0; index < this.m_RotImage.Length; ++index)
      {
        if ((Object) this.m_RotImage[index] != (Object) null && (Object) ((Component) this.m_RotImage[index]).gameObject.GetComponent<ArabicItemTextureRot>() == (Object) null)
          ((Component) this.m_RotImage[index]).gameObject.AddComponent<ArabicItemTextureRot>();
      }
    }
    this.SetMailData(eUIAccountType.AccountSetting);
    this.SetPanelType(this.m_UIType);
    if (!this.CheckReceive() && IGGGameSDK.Instance.bBindingGoogle)
      DataManager.Instance.SendAccountBind();
    this.CheckBind();
    this.IosExamine();
    GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
  }

  public override void OnClose()
  {
    for (int index = 0; index < this.MaxStr; ++index)
      StringManager.Instance.DeSpawnString(this.m_Str[index]);
    for (int index = 0; index < 5; ++index)
      StringManager.Instance.DeSpawnString(this.m_ItemObject[index].Str);
    this.GM.RemoveSpriteAsset(this.AssName);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.SetPanelType(eUIAccountType.AccountSetting);
        break;
      case 2:
        GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_TreasureBox, 2, 1, openMode: (byte) 0);
        break;
      case 3:
        this.SetPanelType(eUIAccountType.AccountSetting);
        break;
      case 100:
        this.GM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(7077U), this.DM.mStringTable.GetStringByID(7079U), 2);
        return;
      case 200:
        this.GM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(7077U), this.DM.mStringTable.GetStringByID(7088U), 1);
        return;
      default:
        this.SetPanelType(this.m_UIType);
        break;
    }
    this.SetMailData(this.m_UIType);
    this.UpdateScrollPanel();
    this.CheckBind();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 1:
        IGGSDKPlugin.LinkingGoogleAccount(this.SDK.SelectAccount);
        break;
      case 2:
        if (!this.GM.ShowUILock(EUILock.SwitchingGoogleAccount))
          break;
        IGGSDKPlugin.GoogleAccountLogin(this.SDK.SelectAccount);
        break;
      case 5:
        if (this.CrossType == UIOther_Account.eCrossType.Facebook)
        {
          this.SwitchFacebook();
          break;
        }
        this.SwitchWeChat();
        break;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    int mailIdx = this.m_Data[dataIdx].MailIdx;
    if ((Object) this.m_ItemObject[panelObjectIdx].AccText == (Object) null)
    {
      this.m_ItemObject[panelObjectIdx].Img1 = item.transform.GetChild(0).GetComponent<Image>();
      this.m_ItemObject[panelObjectIdx].Img2 = item.transform.GetChild(1).GetComponent<Image>();
      this.m_ItemObject[panelObjectIdx].Select = item.transform.GetChild(2).GetChild(0).GetComponent<Image>();
      this.m_ItemObject[panelObjectIdx].AccText = item.transform.GetChild(3).GetComponent<UIText>();
    }
    ((Behaviour) this.m_ItemObject[panelObjectIdx].Select).enabled = this.m_Data[dataIdx].bSelect;
    ((Behaviour) this.m_ItemObject[panelObjectIdx].Img2).enabled = this.m_Data[dataIdx].bSelect;
    if (this.m_Data[dataIdx].AccountType == eAccountType.DeviceLogin)
    {
      if (mailIdx < this.SDK.m_MailList.Count)
        this.m_ItemObject[panelObjectIdx].AccText.text = this.DM.mStringTable.GetStringByID(7069U);
    }
    else if (mailIdx < this.SDK.m_MailList.Count)
      this.m_ItemObject[panelObjectIdx].AccText.text = this.SDK.m_MailList[mailIdx];
    this.m_ItemObject[panelObjectIdx].AccText.SetAllDirty();
    this.m_ItemObject[panelObjectIdx].AccText.cachedTextGenerator.Invalidate();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    if (this.NowSelectDataIdx >= this.m_Data.Count || this.m_Data[dataIndex].bSelect)
      return;
    if (this.NowSelectDataIdx >= 0 && this.NowSelectDataIdx < this.m_Data.Count)
      this.m_Data[this.NowSelectDataIdx] = this.m_Data[this.NowSelectDataIdx] with
      {
        bSelect = false
      };
    this.NowSelectDataIdx = dataIndex;
    sAccount sAccount = this.m_Data[dataIndex] with
    {
      bSelect = !this.m_Data[dataIndex].bSelect
    };
    this.m_Data[dataIndex] = sAccount;
    this.UpdateScrollPanel();
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        this.SetPanelType(eUIAccountType.AccountBind);
        break;
      case 1:
        IGGSDKPlugin.ClearFacebookSession();
        break;
      case 2:
        this.SetPanelType(eUIAccountType.SwitchGoogleAccountPlatform);
        break;
      case 3:
        if (this.UseWechat == (byte) 1)
        {
          this.SetPanelType(eUIAccountType.CrossPlatformList);
          break;
        }
        this.CrossType = UIOther_Account.eCrossType.Facebook;
        this.CrossPlatformSetup.SetPlatform(this.CrossType, this.CrossPlatformIcons[(int) this.CrossType]);
        this.m_CrossPlatformPanel.gameObject.SetActive(true);
        this.m_CrossPlatformList.gameObject.SetActive(false);
        break;
      case 4:
        RealNameHelp.Instance.OpenRealNameAsyncByWebView();
        break;
      case 5:
        GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        this.GM.CloseMenu(EGUIWindow.UI_Other_Account);
        break;
      case 6:
        this.SetPanelType(eUIAccountType.AccountSetting);
        break;
      case 7:
        if (this.m_UIType == eUIAccountType.AccountBind)
        {
          if (this.NowSelectDataIdx < 0)
            break;
          this.GM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(7077U), this.DM.mStringTable.GetStringByID(7088U), 1);
          break;
        }
        if (this.m_UIType != eUIAccountType.SwitchAccount || this.NowSelectDataIdx < 0)
          break;
        if (this.m_Data[this.NowSelectDataIdx].AccountType != eAccountType.DeviceLogin)
        {
          this.GM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(7077U), this.DM.mStringTable.GetStringByID(7079U), 2);
          break;
        }
        this.OnOKCancelBoxClick(true, 2, 0);
        break;
      case 8:
        this.SetPanelType(eUIAccountType.AccountSetting);
        break;
      case 9:
        this.SetPanelType(eUIAccountType.PlatformBind);
        break;
      case 10:
        this.SetPanelType(eUIAccountType.PlatformLogin);
        break;
      case 11:
        if (this.UseWechat == (byte) 1)
        {
          this.SetPanelType(eUIAccountType.CrossPlatformList);
          break;
        }
        this.SetPanelType(eUIAccountType.AccountSetting);
        break;
      case 12:
        if (this.CrossType == UIOther_Account.eCrossType.Facebook)
        {
          this.BindFacebook();
          break;
        }
        this.BindWechat();
        break;
      case 13:
        this.SetPanelType(eUIAccountType.CrossPlatform);
        break;
      case 14:
        this.GM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(7077U), this.CrossPlatformSetup.MsgStr, 5);
        break;
      case 15:
        this.SetPanelType(eUIAccountType.CrossPlatform);
        break;
      case 16:
        if (!this.GM.ShowUILock(EUILock.SwitchAccount))
          break;
        IGGSDKPlugin.GeustLogin();
        break;
      case 17:
        this.SetPanelType(eUIAccountType.SwitchAccount);
        break;
      case 18:
        this.SetPanelType(eUIAccountType.AccountSetting);
        break;
      case 19:
        this.CrossType = UIOther_Account.eCrossType.Facebook;
        this.CrossPlatformSetup.SetPlatform(this.CrossType, this.CrossPlatformIcons[(int) this.CrossType]);
        this.m_CrossPlatformPanel.gameObject.SetActive(true);
        this.m_CrossPlatformList.gameObject.SetActive(false);
        break;
      case 20:
        if (!IGGSDKPlugin.isWXAppInstalled())
        {
          GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(614U), this.DM.mStringTable.GetStringByID(9525U));
          break;
        }
        this.CrossType = UIOther_Account.eCrossType.WeChat;
        this.CrossPlatformSetup.SetPlatform(this.CrossType, this.CrossPlatformIcons[(int) this.CrossType]);
        this.m_CrossPlatformPanel.gameObject.SetActive(true);
        this.m_CrossPlatformList.gameObject.SetActive(false);
        break;
      case 21:
        this.SetPanelType(eUIAccountType.AccountSetting);
        break;
      case 22:
        this.BindWechat();
        break;
      case 23:
        this.SwitchWeChat();
        break;
    }
  }

  private void SetPanelType(eUIAccountType type)
  {
    if (type != eUIAccountType.SwitchAccount && type != eUIAccountType.AccountBind)
      this.Close();
    this.m_UIType = type;
    switch (type)
    {
      case eUIAccountType.AccountSetting:
        this.SetLoginIcon();
        this.m_SettingPanel.gameObject.SetActive(true);
        this.m_SwitchPanel.gameObject.SetActive(false);
        this.m_CrossPlatformList.gameObject.SetActive(false);
        this.m_SettingTitleText.text = this.DM.mStringTable.GetStringByID(7071U);
        this.m_Str[0].ClearString();
        this.m_Str[0].StringToFormat(this.SDK.m_IGGID);
        this.m_Str[0].AppendFormat(this.DM.mStringTable.GetStringByID(7067U));
        this.m_SettingIGGIDText.text = this.m_Str[0].ToString();
        if (this.SDK.m_IGGLoginType == IGGLoginType.Facebook || this.SDK.m_IGGLoginType == IGGLoginType.WeChat)
        {
          ((Component) this.m_LogoutBtn).gameObject.SetActive(true);
          ((Component) this.m_BindBtn).gameObject.SetActive(false);
          this.m_SettingAccText.text = this.SDK.m_BindGoogleAccount;
          ((Component) this.m_SwitchPlatform).gameObject.SetActive(false);
          ((Component) this.m_SwitchBtn).GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, -137.5f);
          break;
        }
        if (this.SDK.m_IGGLoginType == IGGLoginType.GOOGLE_PLAY)
        {
          ((Component) this.m_LogoutBtn).gameObject.SetActive(false);
          ((Behaviour) this.m_BindAccountText).enabled = true;
          ((Component) this.m_BindBtn).gameObject.SetActive(false);
          this.m_SettingAccText.text = this.SDK.m_BindGoogleAccount;
          ((Graphic) this.m_SettingAccImage).rectTransform.sizeDelta = new Vector2(514f, 47f);
          ((Graphic) this.m_SettingAccImage).rectTransform.anchoredPosition = new Vector2(25f, -11.5f);
          if (this.SDK.m_BindGoogleAccount == string.Empty)
          {
            ((Behaviour) this.m_BindAccountText).enabled = false;
            this.m_SettingAccText.text = this.DM.mStringTable.GetStringByID(7085U);
            break;
          }
          break;
        }
        ((Component) this.m_LogoutBtn).gameObject.SetActive(false);
        ((Behaviour) this.m_BindAccountText).enabled = true;
        this.m_SettingAccText.text = this.SDK.m_BindGoogleAccount;
        if (this.SDK.bBindingGoogle)
        {
          ((Component) this.m_BindBtn).gameObject.SetActive(false);
          ((Behaviour) this.m_BindAccountText).enabled = true;
          ((Graphic) this.m_SettingAccImage).rectTransform.sizeDelta = new Vector2(514f, 47f);
          ((Graphic) this.m_SettingAccImage).rectTransform.anchoredPosition = new Vector2(25f, -11.5f);
          if (this.SDK.m_BindGoogleAccount == string.Empty)
          {
            this.m_SettingAccText.text = this.DM.mStringTable.GetStringByID(7085U);
            break;
          }
          break;
        }
        ((Component) this.m_BindBtn).gameObject.SetActive(true);
        ((Behaviour) this.m_BindAccountText).enabled = false;
        ((Graphic) this.m_SettingAccImage).rectTransform.sizeDelta = new Vector2(367f, 47f);
        ((Graphic) this.m_SettingAccImage).rectTransform.anchoredPosition = new Vector2(-48.5f, -11.5f);
        if (this.SDK.m_BindGoogleAccount == string.Empty)
        {
          this.m_SettingAccText.text = this.DM.mStringTable.GetStringByID(7072U);
          break;
        }
        break;
      case eUIAccountType.AccountBind:
        IGGSDKPlugin.ShowAccount(true);
        this.SDK.bShowAccountState = true;
        break;
      case eUIAccountType.SwitchAccount:
        IGGSDKPlugin.ShowAccount(false);
        this.SDK.bShowAccountState = true;
        break;
      case eUIAccountType.CrossPlatform:
        if (this.UseWechat == (byte) 1)
        {
          this.m_CrossPlatformList.gameObject.SetActive(true);
          break;
        }
        this.m_CrossPlatformPanel.gameObject.SetActive(true);
        break;
      case eUIAccountType.PlatformBind:
        this.m_PlatformBindPanel.gameObject.SetActive(true);
        break;
      case eUIAccountType.PlatformLogin:
        this.m_PlatformLoginPanel.gameObject.SetActive(true);
        break;
      case eUIAccountType.SwitchGoogleAccountPlatform:
        this.m_SwitchGoogleAccountPanel.gameObject.SetActive(true);
        break;
      case eUIAccountType.CrossPlatformList:
        this.m_CrossPlatformList.gameObject.SetActive(true);
        break;
      case eUIAccountType.SwitchWechatFacebookPlatform:
        this.m_SwitchWechatFacebookPlatform.gameObject.SetActive(true);
        break;
      case eUIAccountType.WeChatPlatformLogin:
        this.m_WeChatPlatformLogin.gameObject.SetActive(true);
        break;
    }
    this.IosExamine();
  }

  private void UpdateScrollPanel(bool bSetToTop = false)
  {
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_Data.Count; ++index)
      _DataHeight.Add(54f);
    this.m_ScrollPanel.AddNewDataHeight(_DataHeight, bSetToTop);
  }

  private void SetMailData(eUIAccountType type)
  {
    List<float> _DataHeight = new List<float>();
    this.m_Data.Clear();
    this.NowSelectDataIdx = -1;
    ((Component) this.m_SwitchEmpty).gameObject.SetActive(false);
    switch (type)
    {
      case eUIAccountType.AccountSetting:
        _DataHeight.Clear();
        if (!this.bScrollPanelInit)
        {
          this.m_ScrollPanel.IntiScrollPanel(202f, 10f, 0.0f, _DataHeight, 5, (IUpDateScrollPanel) this);
          this.bScrollPanelInit = true;
          break;
        }
        this.UpdateScrollPanel();
        break;
      case eUIAccountType.AccountBind:
        for (int index = 0; index < this.SDK.m_MailList.Count; ++index)
        {
          this.m_Data.Add(new sAccount()
          {
            AccountType = eAccountType.BindGoogle,
            MailIdx = index
          });
          if (this.NowSelectDataIdx == -1)
            this.NowSelectDataIdx = 0;
        }
        this.UpdateScrollPanel();
        if (this.NowSelectDataIdx == -1)
        {
          ((Component) this.m_SwitchEmpty).gameObject.SetActive(true);
          break;
        }
        ((Component) this.m_SwitchEmpty).gameObject.SetActive(false);
        break;
      case eUIAccountType.SwitchAccount:
        sAccount sAccount1 = new sAccount();
        sAccount1.AccountType = eAccountType.DeviceLogin;
        sAccount1.MailIdx = -1;
        if (!this.SDK.bBindingGoogle)
          this.NowSelectDataIdx = -1;
        else if (this.SDK.m_BindGoogleAccount == string.Empty)
        {
          this.NowSelectDataIdx = 0;
          sAccount1.bSelect = true;
        }
        this.m_Data.Add(sAccount1);
        for (int index = 0; index < this.SDK.m_MailList.Count; ++index)
        {
          sAccount sAccount2 = new sAccount();
          if (this.SDK.bBindingGoogle && this.SDK.m_MailList[index] == this.SDK.m_BindGoogleAccount)
          {
            this.NowSelectDataIdx = index + 1;
            sAccount2.bSelect = true;
          }
          sAccount2.AccountType = eAccountType.BindGoogle;
          sAccount2.MailIdx = index;
          this.m_Data.Add(sAccount2);
        }
        for (int index = 0; index < this.m_Data.Count; ++index)
          _DataHeight.Add(54f);
        this.m_ScrollPanel.AddNewDataHeight(_DataHeight, false);
        break;
    }
  }

  private void CheckBind()
  {
    if (IGGGameSDK.Instance.bBindingGoogle || this.SDK.m_IGGLoginType == IGGLoginType.Facebook)
      this.m_BindGiftTf.gameObject.SetActive(false);
    else
      this.m_BindGiftTf.gameObject.SetActive(true);
  }

  private bool CheckReceive() => DataManager.Instance.CheckPrizeFlag((byte) 2);

  private void SetFakeDate()
  {
  }

  private void BindFacebook() => IGGSDKPlugin.GetToken();

  private void BindWechat()
  {
    if (!IGGSDKPlugin.isWXAppInstalled())
      GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(614U), this.DM.mStringTable.GetStringByID(9525U));
    else
      IGGSDKPlugin.BindWeChat();
  }

  private void SwitchFacebook() => IGGSDKPlugin.SwitchFacebook();

  private void SwitchWeChat()
  {
    if (!IGGSDKPlugin.isWXAppInstalled())
      GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(614U), this.DM.mStringTable.GetStringByID(9525U));
    else
      IGGSDKPlugin.LoginWeChat();
  }

  private void BindAmazon()
  {
  }

  private void LoginAmazon()
  {
  }

  private void Close()
  {
    this.m_SettingPanel.gameObject.SetActive(false);
    this.m_PlatformBindPanel.gameObject.SetActive(false);
    this.m_PlatformLoginPanel.gameObject.SetActive(false);
    this.m_SwitchPanel.gameObject.SetActive(false);
    this.m_CrossPlatformPanel.gameObject.SetActive(false);
    this.m_SwitchGoogleAccountPanel.gameObject.SetActive(false);
    this.m_SwitchWechatFacebookPlatform.gameObject.SetActive(false);
    this.m_WeChatPlatformLogin.gameObject.SetActive(false);
    this.m_FBPlatformLogin.gameObject.SetActive(false);
  }

  private void SetCenterText(Image image, UIText text, float width)
  {
    float num = 10f;
    float x = (float) (((double) width - ((double) ((Graphic) image).rectTransform.sizeDelta.x + (double) text.preferredWidth + (double) num)) / 2.0);
    ((Graphic) image).rectTransform.anchoredPosition = new Vector2(x, ((Graphic) image).rectTransform.anchoredPosition.y);
    ((Graphic) text).rectTransform.anchoredPosition = new Vector2(((Graphic) image).rectTransform.anchoredPosition.x + ((Graphic) image).rectTransform.sizeDelta.x + num, ((Graphic) text).rectTransform.anchoredPosition.y);
  }

  private void SetLoginIcon()
  {
    if (!((Object) this.m_GIcon != (Object) null) || !((Object) this.mat != (Object) null))
      return;
    if (IGGGameSDK.Instance.m_IGGLoginType == IGGLoginType.Facebook)
      this.m_GIcon.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
    else if (IGGGameSDK.Instance.m_IGGLoginType == IGGLoginType.WeChat)
    {
      this.m_GIcon.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_19");
    }
    else
    {
      this.m_GIcon.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_08");
      ((Graphic) this.m_GIcon).rectTransform.sizeDelta = new Vector2(42f, 43f);
    }
    ((MaskableGraphic) this.m_GIcon).material = this.mat;
  }

  private void SetSetttingPos()
  {
    if (this.SDK.m_IGGLoginType == IGGLoginType.WeChat || this.SDK.m_IGGLoginType == IGGLoginType.Facebook)
    {
      ((Behaviour) this.m_BindAccountText).enabled = false;
      ((Component) this.m_BindBtn).gameObject.SetActive(false);
      ((Component) this.m_GIcon).gameObject.SetActive(true);
      ((Component) this.m_LogoutBtn).gameObject.SetActive(true);
      ((Component) this.m_SwitchBtn).gameObject.SetActive(false);
      ((Graphic) this.m_SettingAccImage).rectTransform.sizeDelta = new Vector2(367f, 47f);
      ((Graphic) this.m_SettingAccImage).rectTransform.anchoredPosition = new Vector2(-48.5f, -11.5f);
      this.m_SettingAccText.text = this.SDK.m_BindGoogleAccount;
      this.m_BindBtn.m_BtnID1 = 22;
      this.m_SwitchBtn.m_BtnID1 = 23;
    }
    else
    {
      if (this.SDK.bBindingGoogle)
      {
        ((Behaviour) this.m_BindAccountText).enabled = true;
        ((Component) this.m_BindBtn).gameObject.SetActive(false);
        ((Component) this.m_GIcon).gameObject.SetActive(false);
        ((Component) this.m_LogoutBtn).gameObject.SetActive(false);
        ((Component) this.m_SwitchBtn).gameObject.SetActive(true);
        ((Graphic) this.m_SettingAccImage).rectTransform.sizeDelta = new Vector2(514f, 47f);
        ((Graphic) this.m_SettingAccImage).rectTransform.anchoredPosition = new Vector2(0.0f, -11.5f);
        if (this.SDK.m_BindGoogleAccount == string.Empty)
          this.m_SettingAccText.text = this.DM.mStringTable.GetStringByID(7085U);
        ((Graphic) this.m_SettingAccText).rectTransform.anchoredPosition = new Vector2(-67f, -10f);
        ((Graphic) this.m_BindAccountText).rectTransform.anchoredPosition = new Vector2(-5f, -10f);
      }
      else
      {
        ((Behaviour) this.m_BindAccountText).enabled = false;
        ((Component) this.m_LogoutBtn).gameObject.SetActive(false);
        ((Component) this.m_BindBtn).gameObject.SetActive(true);
        this.m_BindBtn.m_BtnID1 = 22;
        RectTransform component1 = ((Component) this.m_BindBtn).gameObject.GetComponent<RectTransform>();
        component1.sizeDelta = new Vector2(204f, 73f);
        Vector2 anchoredPosition = component1.anchoredPosition with
        {
          x = 200f
        };
        component1.anchoredPosition = anchoredPosition;
        ((Component) this.m_GIcon).transform.SetParent(((Component) this.m_BindBtn).transform, false);
        ((Graphic) this.m_GIcon).rectTransform.anchorMax = new Vector2(0.0f, 0.5f);
        ((Graphic) this.m_GIcon).rectTransform.anchorMin = new Vector2(0.0f, 0.5f);
        ((Graphic) this.m_GIcon).rectTransform.pivot = new Vector2(0.0f, 0.5f);
        ((Graphic) this.m_GIcon).rectTransform.anchoredPosition = new Vector2(15f, -2f);
        UIText component2 = ((Component) this.m_BindBtn).transform.GetChild(0).GetComponent<UIText>();
        if ((Object) component2 != (Object) null)
        {
          ((Graphic) component2).rectTransform.anchorMax = new Vector2(0.0f, 0.5f);
          ((Graphic) component2).rectTransform.anchorMin = new Vector2(0.0f, 0.5f);
          ((Graphic) component2).rectTransform.pivot = new Vector2(0.0f, 0.5f);
          ((Graphic) component2).rectTransform.anchoredPosition = new Vector2(69f, 0.0f);
        }
        ((Graphic) this.m_SettingAccImage).rectTransform.sizeDelta = new Vector2(367f, 47f);
        if (this.SDK.m_BindGoogleAccount == string.Empty)
          this.m_SettingAccText.text = this.DM.mStringTable.GetStringByID(7085U);
        ((Graphic) this.m_SettingAccImage).rectTransform.anchoredPosition = new Vector2(-108f, -11.5f);
        ((Graphic) this.m_SettingAccText).rectTransform.anchoredPosition = new Vector2(-108f, -10f);
      }
      ((Graphic) this.m_SettingIGGIDText).rectTransform.anchoredPosition = new Vector2(25f, 43f);
    }
    ((Component) this.m_SwitchPlatform).gameObject.SetActive(false);
    ((Component) this.m_SwitchBtn).GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, -137.5f);
    this.m_SwitchBtn.m_BtnID1 = 24;
    ((Component) this.m_SwitchBtn).transform.GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7075U);
    Vector2 vector2;
    vector2.x = -140f;
    vector2.y = -137.5f;
    ((Component) this.m_RealName).gameObject.transform.GetComponent<RectTransform>().anchoredPosition = vector2;
    vector2.x = 140f;
    ((Component) this.m_SwitchBtn).GetComponent<RectTransform>().anchoredPosition = vector2;
    ((Component) this.m_RealName).gameObject.SetActive(true);
  }

  private void SetSetttingPos_Amazon()
  {
    if (this.SDK.m_IGGLoginType == IGGLoginType.AMAZON)
    {
      ((Behaviour) this.m_BindAccountText).enabled = false;
      ((Component) this.m_BindBtn).gameObject.SetActive(false);
      ((Component) this.m_GIcon).gameObject.SetActive(true);
      this.m_GIcon.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_24");
      ((Component) this.m_LogoutBtn).gameObject.SetActive(true);
      ((Component) this.m_SwitchBtn).gameObject.SetActive(false);
      ((Component) this.m_SwitchPlatform).gameObject.SetActive(false);
      ((Graphic) this.m_SettingAccImage).rectTransform.sizeDelta = new Vector2(367f, 47f);
      ((Graphic) this.m_SettingAccImage).rectTransform.anchoredPosition = new Vector2(-48.5f, -11.5f);
      this.m_SettingAccText.text = this.SDK.m_BindGoogleAccount;
      this.m_BindBtn.m_BtnID1 = 22;
      this.m_SwitchBtn.m_BtnID1 = 23;
    }
    else if (this.SDK.m_IGGLoginType == IGGLoginType.Facebook)
    {
      ((Behaviour) this.m_BindAccountText).enabled = false;
      ((Component) this.m_BindBtn).gameObject.SetActive(false);
      ((Component) this.m_GIcon).gameObject.SetActive(true);
      this.m_GIcon.sprite = this.GM.LoadSprite(this.AssName, "UI_other_icon_04");
      ((Component) this.m_LogoutBtn).gameObject.SetActive(true);
      ((Component) this.m_SwitchBtn).gameObject.SetActive(false);
      ((Component) this.m_SwitchPlatform).gameObject.SetActive(false);
      ((Graphic) this.m_SettingAccImage).rectTransform.sizeDelta = new Vector2(367f, 47f);
      ((Graphic) this.m_SettingAccImage).rectTransform.anchoredPosition = new Vector2(-48.5f, -11.5f);
      this.m_SettingAccText.text = this.SDK.m_BindGoogleAccount;
      this.m_BindBtn.m_BtnID1 = 22;
      this.m_SwitchBtn.m_BtnID1 = 23;
    }
    else
    {
      if (this.SDK.bBindingGoogle)
      {
        ((Behaviour) this.m_BindAccountText).enabled = true;
        ((Component) this.m_BindBtn).gameObject.SetActive(false);
        ((Component) this.m_GIcon).gameObject.SetActive(false);
        ((Component) this.m_LogoutBtn).gameObject.SetActive(false);
        ((Component) this.m_SwitchBtn).gameObject.SetActive(true);
        ((Graphic) this.m_SettingAccImage).rectTransform.sizeDelta = new Vector2(514f, 47f);
        ((Graphic) this.m_SettingAccImage).rectTransform.anchoredPosition = new Vector2(0.0f, -11.5f);
        if (this.SDK.m_BindGoogleAccount == string.Empty)
          this.m_SettingAccText.text = this.DM.mStringTable.GetStringByID(7085U);
        ((Graphic) this.m_SettingAccText).rectTransform.anchoredPosition = new Vector2(-67f, -10f);
        ((Graphic) this.m_BindAccountText).rectTransform.anchoredPosition = new Vector2(-5f, -10f);
      }
      else
      {
        ((Behaviour) this.m_BindAccountText).enabled = false;
        ((Component) this.m_LogoutBtn).gameObject.SetActive(false);
        ((Component) this.m_BindBtn).gameObject.SetActive(true);
        this.m_BindBtn.m_BtnID1 = 22;
        ((Component) this.m_LogoutBtn).gameObject.SetActive(false);
        if (this.SDK.m_BindGoogleAccount == string.Empty)
          this.m_SettingAccText.text = this.DM.mStringTable.GetStringByID(7085U);
      }
      ((Graphic) this.m_SettingIGGIDText).rectTransform.anchoredPosition = new Vector2(25f, 43f);
      ((Component) this.m_SwitchPlatform).gameObject.SetActive(true);
    }
    this.m_SwitchBtn.m_BtnID1 = 23;
    ((Component) this.m_SwitchBtn).transform.GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(8428U);
  }

  private void IosExamine()
  {
  }

  private void SetIosCnUI()
  {
    if ((Object) this.m_SettingPanel == (Object) null)
      return;
    RectTransform component1 = this.m_SettingPanel.GetChild(0).GetComponent<RectTransform>();
    Vector2 sizeDelta = component1.sizeDelta with
    {
      y = 407f
    };
    component1.sizeDelta = sizeDelta;
    for (int index = 1; index < this.m_SettingPanel.childCount; ++index)
    {
      if ((Object) this.m_SettingPanel.GetChild(index) != (Object) null)
      {
        RectTransform component2 = this.m_SettingPanel.GetChild(index).GetComponent<RectTransform>();
        if ((Object) component2 != (Object) null)
        {
          Vector2 anchoredPosition = component2.anchoredPosition;
          anchoredPosition.y += 40.5f;
          component2.anchoredPosition = anchoredPosition;
        }
      }
    }
    RectTransform component3 = ((Component) this.m_RealName).gameObject.transform.GetComponent<RectTransform>();
    Vector2 anchoredPosition1 = component3.anchoredPosition with
    {
      y = -175f
    };
    component3.anchoredPosition = anchoredPosition1;
    ((Component) this.m_RealName).gameObject.SetActive(true);
  }

  private void SetAndroidCnUI()
  {
    if ((Object) this.m_SettingPanel == (Object) null)
      return;
    RectTransform component = ((Component) this.m_RealName).gameObject.transform.GetComponent<RectTransform>();
    Vector2 anchoredPosition = component.anchoredPosition with
    {
      x = 140f,
      y = -137.5f
    };
    component.anchoredPosition = anchoredPosition;
    ((Component) this.m_RealName).gameObject.SetActive(true);
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.m_SettingTitleText != (Object) null && ((Behaviour) this.m_SettingTitleText).enabled)
    {
      ((Behaviour) this.m_SettingTitleText).enabled = false;
      ((Behaviour) this.m_SettingTitleText).enabled = true;
    }
    if ((Object) this.m_SettingIGGIDText != (Object) null && ((Behaviour) this.m_SettingIGGIDText).enabled)
    {
      ((Behaviour) this.m_SettingIGGIDText).enabled = false;
      ((Behaviour) this.m_SettingIGGIDText).enabled = true;
    }
    if ((Object) this.m_SettingAccText != (Object) null && ((Behaviour) this.m_SettingAccText).enabled)
    {
      ((Behaviour) this.m_SettingAccText).enabled = false;
      ((Behaviour) this.m_SettingAccText).enabled = true;
    }
    if ((Object) this.m_BindAccountText != (Object) null && ((Behaviour) this.m_BindAccountText).enabled)
    {
      ((Behaviour) this.m_BindAccountText).enabled = false;
      ((Behaviour) this.m_BindAccountText).enabled = true;
    }
    if ((Object) this.m_SwitchTitleText != (Object) null && ((Behaviour) this.m_SwitchTitleText).enabled)
    {
      ((Behaviour) this.m_SwitchTitleText).enabled = false;
      ((Behaviour) this.m_SwitchTitleText).enabled = true;
    }
    if (this.m_ItemObject != null)
    {
      for (int index = 0; index < this.m_ItemObject.Length; ++index)
      {
        if ((Object) this.m_ItemObject[index].AccText != (Object) null && ((Behaviour) this.m_ItemObject[index].AccText).enabled)
        {
          ((Behaviour) this.m_ItemObject[index].AccText).enabled = false;
          ((Behaviour) this.m_ItemObject[index].AccText).enabled = true;
        }
      }
    }
    if (this.m_TempText == null)
      return;
    for (int index = 0; index < this.m_TempText.Length; ++index)
    {
      if ((Object) this.m_TempText[index] != (Object) null && ((Behaviour) this.m_TempText[index]).enabled)
      {
        ((Behaviour) this.m_TempText[index]).enabled = false;
        ((Behaviour) this.m_TempText[index]).enabled = true;
      }
    }
  }

  private enum eCrossType
  {
    Facebook,
    WeChat,
  }

  private struct _CrossPlatformSetup
  {
    public Image BindImg;
    public Image LoginImg;
    public Image BindPanelImg;
    public Image LoginPanelImg;
    public UIText Title;
    public UIText Tip;
    public UIText LoginTitle;
    public UIText BindTitle;
    public string MsgStr;

    public void SetPlatform(UIOther_Account.eCrossType type, Sprite sprite)
    {
      Image bindImg = this.BindImg;
      Sprite sprite1 = sprite;
      this.LoginPanelImg.sprite = sprite1;
      Sprite sprite2 = sprite1;
      this.BindPanelImg.sprite = sprite2;
      Sprite sprite3 = sprite2;
      this.LoginImg.sprite = sprite3;
      Sprite sprite4 = sprite3;
      bindImg.sprite = sprite4;
      StringTable mStringTable = DataManager.Instance.mStringTable;
      if (type == UIOther_Account.eCrossType.Facebook)
      {
        this.Title.text = mStringTable.GetStringByID(9010U);
        this.Tip.text = mStringTable.GetStringByID(9005U);
        this.MsgStr = mStringTable.GetStringByID(9011U);
        this.LoginTitle.text = mStringTable.GetStringByID(9009U);
        this.BindTitle.text = mStringTable.GetStringByID(9004U);
      }
      else
      {
        this.Title.text = mStringTable.GetStringByID(9517U);
        this.Tip.text = mStringTable.GetStringByID(9512U);
        this.MsgStr = mStringTable.GetStringByID(9518U);
        this.LoginTitle.text = mStringTable.GetStringByID(9516U);
        this.BindTitle.text = mStringTable.GetStringByID(9511U);
      }
    }
  }
}
