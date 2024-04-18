// Decompiled with JetBrains decompiler
// Type: UIOther_Forum
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIOther_Forum : GUIWindow, IUIButtonClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private Door door;
  private Transform GameT;
  private Transform P1_T;
  private Transform P2_T;
  private UIButton btn_EXIT;
  private UIButton[] btn_Function_P1 = new UIButton[3];
  private UIButton[] btn_Function_P2 = new UIButton[5];
  private UIButton[] btn_Email = new UIButton[4];
  private UIButton btn_Email_Exit;
  private UIButton btn_LiveChat;
  private Image tmpImg;
  private UIText textTitle;
  private UIText[] text_btn_P1 = new UIText[3];
  private UIText[] text_btn_P2 = new UIText[5];
  private UIText[] text_Email = new UIText[4];
  private UIText text_LiveChat;
  private Material m_Mat;
  private UISpritesArray SArray;
  private int mType;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.mType = arg1;
    this.textTitle = this.GameT.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.textTitle.font = this.TTFont;
    this.P1_T = this.GameT.GetChild(1);
    this.P2_T = this.GameT.GetChild(2);
    for (int index = 0; index < 1; ++index)
    {
      this.btn_Function_P1[index] = this.P1_T.GetChild(index).GetComponent<UIButton>();
      this.btn_Function_P1[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Function_P1[index].m_BtnID1 = 2 + index;
      this.btn_Function_P1[index].m_EffectType = e_EffectType.e_Scale;
      this.btn_Function_P1[index].transition = (Selectable.Transition) 0;
      this.text_btn_P1[index] = this.P1_T.GetChild(index).GetChild(1).GetComponent<UIText>();
      this.text_btn_P1[index].font = this.TTFont;
    }
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Cht)
    {
      this.btn_Function_P1[1] = this.P1_T.GetChild(1).GetComponent<UIButton>();
      this.btn_Function_P1[1].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Function_P1[1].m_BtnID1 = 14;
      this.btn_Function_P1[1].m_EffectType = e_EffectType.e_Scale;
      this.btn_Function_P1[1].transition = (Selectable.Transition) 0;
      this.text_btn_P1[1] = this.P1_T.GetChild(1).GetChild(1).GetComponent<UIText>();
      this.text_btn_P1[1].font = this.TTFont;
      this.text_btn_P1[1].text = this.DM.mStringTable.GetStringByID(9044U);
      ((Component) this.btn_Function_P1[1]).gameObject.SetActive(true);
      this.btn_Function_P1[2] = this.P1_T.GetChild(2).GetComponent<UIButton>();
      this.btn_Function_P1[2].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Function_P1[2].m_BtnID1 = 18;
      this.btn_Function_P1[2].m_EffectType = e_EffectType.e_Scale;
      this.btn_Function_P1[2].transition = (Selectable.Transition) 0;
      this.tmpImg = this.P1_T.GetChild(2).GetChild(0).GetComponent<Image>();
      this.tmpImg.sprite = this.SArray.m_Sprites[6];
      this.text_btn_P1[2] = this.P1_T.GetChild(2).GetChild(1).GetComponent<UIText>();
      this.text_btn_P1[2].font = this.TTFont;
      this.text_btn_P1[2].text = this.DM.mStringTable.GetStringByID(9556U);
      ((Component) this.btn_Function_P1[2]).gameObject.SetActive(true);
    }
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Eng)
    {
      this.btn_Function_P1[1] = this.P1_T.GetChild(1).GetComponent<UIButton>();
      this.btn_Function_P1[1].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Function_P1[1].m_BtnID1 = 15;
      this.btn_Function_P1[1].m_EffectType = e_EffectType.e_Scale;
      this.btn_Function_P1[1].transition = (Selectable.Transition) 0;
      this.tmpImg = this.P1_T.GetChild(1).GetChild(0).GetComponent<Image>();
      this.tmpImg.sprite = this.SArray.m_Sprites[2];
      this.text_btn_P1[1] = this.P1_T.GetChild(1).GetChild(1).GetComponent<UIText>();
      this.text_btn_P1[1].font = this.TTFont;
      this.text_btn_P1[1].text = this.DM.mStringTable.GetStringByID(9081U);
      ((Component) this.btn_Function_P1[1]).gameObject.SetActive(true);
    }
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
    {
      this.tmpImg = this.P1_T.GetChild(0).GetChild(0).GetComponent<Image>();
      this.tmpImg.sprite = this.SArray.m_Sprites[4];
      this.btn_Function_P1[1] = this.P1_T.GetChild(1).GetComponent<UIButton>();
      this.btn_Function_P1[1].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Function_P1[1].m_BtnID1 = 16;
      this.btn_Function_P1[1].m_EffectType = e_EffectType.e_Scale;
      this.btn_Function_P1[1].transition = (Selectable.Transition) 0;
      this.tmpImg = this.P1_T.GetChild(1).GetChild(0).GetComponent<Image>();
      this.tmpImg.sprite = this.SArray.m_Sprites[3];
      this.text_btn_P1[1] = this.P1_T.GetChild(1).GetChild(1).GetComponent<UIText>();
      this.text_btn_P1[1].font = this.TTFont;
      this.text_btn_P1[1].text = this.DM.mStringTable.GetStringByID(9524U);
      ((Component) this.btn_Function_P1[1]).gameObject.SetActive(true);
    }
    for (int index = 0; index < 5; ++index)
    {
      this.btn_Function_P2[index] = this.P2_T.GetChild(index).GetComponent<UIButton>();
      this.btn_Function_P2[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Function_P2[index].m_BtnID1 = 3 + index;
      this.btn_Function_P2[index].m_EffectType = e_EffectType.e_Scale;
      this.btn_Function_P2[index].transition = (Selectable.Transition) 0;
      this.text_btn_P2[index] = this.P2_T.GetChild(index).GetChild(1).GetComponent<UIText>();
      this.text_btn_P2[index].font = this.TTFont;
      if (index == 2 && this.GUIM.IsArabic)
      {
        this.tmpImg = this.P2_T.GetChild(index).GetChild(0).GetComponent<Image>();
        ((Component) this.tmpImg).transform.localScale = new Vector3(-1f, ((Component) this.tmpImg).transform.localScale.y, ((Component) this.tmpImg).transform.localScale.z);
      }
    }
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Ukr || DataManager.Instance.UserLanguage == GameLanguage.GL_Mys)
    {
      ((Component) this.btn_Function_P2[3]).gameObject.SetActive(false);
      RectTransform component = ((Component) this.btn_Function_P2[3]).transform.GetComponent<RectTransform>();
      ((Transform) ((Component) this.btn_Function_P2[4]).transform.GetComponent<RectTransform>()).localPosition = ((Transform) component).localPosition;
    }
    this.btn_LiveChat = this.P2_T.GetChild(5).GetComponent<UIButton>();
    this.btn_LiveChat.m_Handler = (IUIButtonClickHandler) this;
    this.btn_LiveChat.m_BtnID1 = 13;
    this.btn_LiveChat.m_EffectType = e_EffectType.e_Scale;
    this.btn_LiveChat.transition = (Selectable.Transition) 0;
    this.text_LiveChat = this.P2_T.GetChild(5).GetChild(1).GetComponent<UIText>();
    this.text_LiveChat.font = this.TTFont;
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Eng || DataManager.Instance.UserLanguage == GameLanguage.GL_Idn)
    {
      this.text_LiveChat.text = DataManager.Instance.mStringTable.GetStringByID(8458U);
      ((Component) this.btn_LiveChat).gameObject.SetActive(true);
    }
    this.btn_Email_Exit = this.GameT.GetChild(3).GetComponent<UIButton>();
    this.btn_Email_Exit.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Email_Exit.m_BtnID1 = 12;
    ((Graphic) this.btn_Email_Exit.image).color = new Color(1f, 1f, 1f, 0.475f);
    Transform child = this.GameT.GetChild(3);
    for (int index = 0; index < 4; ++index)
    {
      this.btn_Email[index] = child.GetChild(1 + index).GetComponent<UIButton>();
      this.btn_Email[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Email[index].m_BtnID1 = 8 + index;
      this.btn_Email[index].m_EffectType = e_EffectType.e_Scale;
      this.btn_Email[index].transition = (Selectable.Transition) 0;
      this.text_Email[index] = child.GetChild(1 + index).GetChild(0).GetComponent<UIText>();
      this.text_Email[index].font = this.TTFont;
    }
    if (this.mType == 0)
    {
      this.P1_T.gameObject.SetActive(true);
      this.textTitle.text = this.DM.mStringTable.GetStringByID(7030U);
      this.text_btn_P1[0].text = DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn ? this.DM.mStringTable.GetStringByID(9523U) : this.DM.mStringTable.GetStringByID(7044U);
    }
    else
    {
      this.P2_T.gameObject.SetActive(true);
      this.textTitle.text = this.DM.mStringTable.GetStringByID(7031U);
      for (int index = 0; index < 2; ++index)
        this.text_btn_P2[index].text = this.DM.mStringTable.GetStringByID((uint) (7045 + index));
      this.text_btn_P2[2].text = this.DM.mStringTable.GetStringByID(7098U);
      this.text_btn_P2[3].text = this.DM.mStringTable.GetStringByID(7099U);
      this.text_btn_P2[4].text = this.DM.mStringTable.GetStringByID(7100U);
      this.text_Email[0].text = this.DM.mStringTable.GetStringByID(8401U);
      this.text_Email[1].text = this.DM.mStringTable.GetStringByID(8402U);
      this.text_Email[2].text = this.DM.mStringTable.GetStringByID(8403U);
      this.text_Email[3].text = this.DM.mStringTable.GetStringByID(8404U);
    }
    this.m_Mat = this.door.LoadMaterial();
    this.tmpImg = this.GameT.GetChild(4).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(4).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.m_Mat;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 1:
        IGGSDKPlugin.OpenFbByUrl(GameConstants.GlobalEditionFUrl);
        break;
      case 2:
        if (DataManager.Instance.UserLanguage != GameLanguage.GL_Jpn)
        {
          IGGSDKPlugin.VisitForum();
          break;
        }
        IGGSDKPlugin.OpenFbByUrl("http://www.lordsmobile.jp");
        break;
      case 3:
        if (DataManager.Instance.UserLanguage == GameLanguage.GL_Cht)
        {
          IGGSDKPlugin.LoadWebView("http://lordsmobile.igg.com/project/agreement/");
          break;
        }
        if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
        {
          IGGSDKPlugin.LoadWebView("http://www.igg.com/member/agreement.php?lang=jp");
          break;
        }
        IGGSDKPlugin.LoadWebView("http://www.igg.com/member/agreement.php");
        break;
      case 4:
        if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
        {
          IGGSDKPlugin.LoadWebView("http://www.igg.com/about/privacy_policy.php?lang=jp");
          break;
        }
        IGGSDKPlugin.LoadWebView("http://www.igg.com/about/privacy_policy.php");
        break;
      case 5:
        IGGSDKPlugin.SubmitQuestion();
        break;
      case 6:
        ((Component) this.btn_Email_Exit).transform.SetParent((Transform) this.GUIM.m_SecWindowLayer, false);
        ((Component) this.btn_Email_Exit).gameObject.SetActive(true);
        break;
      case 7:
        IGGSDKPlugin.Guide(GameConstants.GlobalEditionGuideURL);
        break;
      case 8:
      case 9:
      case 10:
      case 11:
        ((Component) this.btn_Email_Exit).transform.SetParent(this.GameT, false);
        ((Component) this.btn_Email_Exit).transform.SetSiblingIndex(3);
        ((Component) this.btn_Email_Exit).gameObject.SetActive(false);
        CString cstring1 = StringManager.Instance.StaticString1024();
        cstring1.ClearString();
        string str1 = GameConstants.GetDateTime(DataManager.Instance.ServerTime).ToString();
        CString cstring2 = StringManager.Instance.StaticString1024();
        cstring2.ClearString();
        cstring2.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9025U));
        cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8468U));
        string str2 = cstring2.ToString();
        cstring1.StringToFormat(this.DM.mStringTable.GetStringByID(9025U));
        cstring1.AppendFormat(this.DM.mStringTable.GetStringByID((uint) (ushort) (8410 + sender.m_BtnID1 - 8)));
        string str3 = string.Format("{0}.{1}.{2}", (object) GameConstants.Version[0], (object) GameConstants.Version[1], (object) GameConstants.Version[2]);
        string iggid = IGGGameSDK.Instance.m_IGGID;
        string str4 = DataManager.Instance.UserLanguage <= (GameLanguage) 0 || DataManager.Instance.UserLanguage >= GameLanguage.GL_MAX ? GameConstants.GameLanguageName[1] : GameConstants.GameLanguageName[(int) DataManager.Instance.UserLanguage];
        string str5 = SystemInfo.deviceModel.ToString();
        string operatingSystem = SystemInfo.operatingSystem;
        int index = Mathf.Clamp((int) DataManager.Instance.UserLanguage, 1, GameConstants.GlobalEditionGameID.Length - 1);
        IGGSDKPlugin.SendMail(GameConstants.GlobalEditionMailTo[index], cstring1.ToString(), str1, str2, str3, iggid, str4, str5, operatingSystem);
        break;
      case 12:
        ((Component) this.btn_Email_Exit).transform.SetParent(this.GameT, false);
        ((Component) this.btn_Email_Exit).transform.SetSiblingIndex(3);
        ((Component) this.btn_Email_Exit).gameObject.SetActive(false);
        break;
      case 13:
        if (DataManager.Instance.UserLanguage != GameLanguage.GL_Eng && DataManager.Instance.UserLanguage != GameLanguage.GL_Idn)
          break;
        IGGSDKPlugin.SupportLiveOnLogin_GlobalEdition((byte) DataManager.Instance.UserLanguage);
        break;
      case 14:
        IGGSDKPlugin.OpenFbByUrl("http://lm20160316.pixnet.net/blog");
        break;
      case 15:
        IGGSDKPlugin.OpenFbByUrl("https://www.youtube.com/c/LordsMobile");
        break;
      case 16:
        IGGSDKPlugin.OpenFbByUrl("https://twitter.com/LordsMobileJP");
        break;
      case 17:
        IGGSDKPlugin.OpenFbByUrl("http://weibo.com/lordsmobile");
        break;
      case 18:
        IGGSDKPlugin.OpenFbByUrl("https://web.lobi.co/game/wang_guo_ji_yuan_lords_mobile_zh_tw");
        break;
    }
  }

  public override bool OnBackButtonClick()
  {
    if (((UIBehaviour) this.btn_Email_Exit).IsActive())
    {
      ((Component) this.btn_Email_Exit).transform.SetParent(this.GameT, false);
      ((Component) this.btn_Email_Exit).transform.SetSiblingIndex(3);
      ((Component) this.btn_Email_Exit).gameObject.SetActive(false);
    }
    return false;
  }

  public override void OnClose()
  {
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        break;
      case NetworkNews.Refresh:
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.textTitle != (Object) null && ((Behaviour) this.textTitle).enabled)
    {
      ((Behaviour) this.textTitle).enabled = false;
      ((Behaviour) this.textTitle).enabled = true;
    }
    if ((Object) this.text_LiveChat != (Object) null && ((Behaviour) this.text_LiveChat).enabled)
    {
      ((Behaviour) this.text_LiveChat).enabled = false;
      ((Behaviour) this.text_LiveChat).enabled = true;
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.text_btn_P1[index] != (Object) null && ((Behaviour) this.text_btn_P1[index]).enabled)
      {
        ((Behaviour) this.text_btn_P1[index]).enabled = false;
        ((Behaviour) this.text_btn_P1[index]).enabled = true;
      }
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((Object) this.text_Email[index] != (Object) null && ((Behaviour) this.text_Email[index]).enabled)
      {
        ((Behaviour) this.text_Email[index]).enabled = false;
        ((Behaviour) this.text_Email[index]).enabled = true;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.text_btn_P2[index] != (Object) null && ((Behaviour) this.text_btn_P2[index]).enabled)
      {
        ((Behaviour) this.text_btn_P2[index]).enabled = false;
        ((Behaviour) this.text_btn_P2[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 == 1)
      ;
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
