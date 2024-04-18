// Decompiled with JetBrains decompiler
// Type: UIAnnouncement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAnnouncement : GUIWindow, IUIButtonClickHandler
{
  private IGGGameSDK SDK;
  private GUIManager GM;
  private DataManager DM;
  private CString[] m_Str;
  private int MAX_STR = 2;
  private DateTime m_BeginTime;
  private DateTime m_EndTime;
  private UIText m_TitleText;
  private RectTransform m_ScrollViewRect;
  private UIText m_Msg;
  private RectTransform m_Content;
  private UIText m_TimeText;
  private float tickTime = 1f;
  private UISpritesArray m_SpArry;
  private Image m_BtnFBImage;
  private UIButton m_Exit;
  private UIButton[] m_Btn = new UIButton[2];
  private RectTransform[] m_BtnRect = new RectTransform[2];
  private UIText[] m_BtnText = new UIText[2];
  private GameMaintanceType m_MaintanceType;
  private bool bReConfig;

  public override void OnOpen(int arg1, int arg2)
  {
    this.bReConfig = false;
    this.SDK = IGGGameSDK.Instance;
    this.GM = GUIManager.Instance;
    this.DM = DataManager.Instance;
    this.m_Str = new CString[this.MAX_STR];
    this.SpawnStr();
    this.InitUI();
    this.UpdateUI(0, 0);
  }

  public override void OnClose() => this.DeSpawn();

  public override void UpdateUI(int arg1, int arg2)
  {
    if (!this.SDK.GameMaintanceDataReady)
      return;
    switch (arg1)
    {
      case 0:
        if (this.m_MaintanceType == GameMaintanceType.IsMaintain)
        {
          if (this.SDK.IsGameMaintanceType(GameMaintanceType.IsMaintain))
          {
            this.m_MaintanceType = GameMaintanceType.IsMaintain;
            break;
          }
          this.bReConfig = true;
          this.SDK.CanLogIn();
          break;
        }
        this.m_MaintanceType = this.SDK.GetGameMaintanceType();
        break;
      case 1:
        this.m_MaintanceType = GameMaintanceType.IsMaintain;
        break;
      case 2:
        this.m_MaintanceType = GameMaintanceType.HaveLoginInfo;
        break;
    }
    this.UpdateBtnText(this.m_MaintanceType);
    this.SetMaintainMsg(this.m_MaintanceType);
    this.SetMaintainTime(this.m_MaintanceType);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (arg1 != 0 || !bOK)
      return;
    Application.Quit();
  }

  public override bool OnBackButtonClick()
  {
    GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, string.Empty, this.DM.mStringTable.GetStringByID(242U));
    return false;
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (this.m_MaintanceType == GameMaintanceType.IsMaintain)
        {
          this.OpneURLByLanguage(GameConstants.GlobalEditionFUrl);
          break;
        }
        if (this.m_MaintanceType == GameMaintanceType.ForciblyUpdate)
        {
          this.OnBackButtonClick();
          break;
        }
        if (this.m_MaintanceType != GameMaintanceType.ProposalUpdate)
          break;
        if (this.SDK.IsGameMaintanceType(GameMaintanceType.IsMaintain))
        {
          this.UpdateUI(1, 0);
          break;
        }
        if (this.SDK.IsGameMaintanceType(GameMaintanceType.HaveLoginInfo))
        {
          this.UpdateUI(2, 0);
          break;
        }
        this.SDK.CanLogIn();
        break;
      case 1:
        if (this.m_MaintanceType == GameMaintanceType.IsMaintain)
        {
          if (!IGGGameSDK.Instance.GameMaintanceDataReady)
            break;
          IGGGameSDK.Instance.GameMaintanceDataReady = false;
          IGGSDKPlugin.LoadGameConfig();
          break;
        }
        if (this.m_MaintanceType == GameMaintanceType.HaveLoginInfo)
        {
          IGGGameSDK.Instance.CanLogIn();
          break;
        }
        if (this.m_MaintanceType == GameMaintanceType.ForciblyUpdate)
        {
          IGGSDKPlugin.OpenGooglePlayStoreApp(IGGGameSDK.Instance.MaintanceData.URL);
          break;
        }
        if (this.m_MaintanceType != GameMaintanceType.ProposalUpdate)
          break;
        IGGSDKPlugin.OpenGooglePlayStoreApp(IGGGameSDK.Instance.MaintanceData.URL);
        break;
      case 999:
        this.OnBackButtonClick();
        break;
    }
  }

  private void OpenThirdPartyUpadteURL()
  {
    int index = Mathf.Clamp((int) DataManager.Instance.UserLanguage, 1, GameConstants.GlobalEditionGameID.Length - 1);
    IGGSDKPlugin.OpenFbByUrl(GameConstants.ThirdPartyUpadteURL + GameConstants.GlobalEditionGameID[index]);
  }

  private void OpneURLByLanguage(string url)
  {
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
      IGGSDKPlugin.OpenFbByUrl(GameConstants.CommunityCN);
    else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
      IGGSDKPlugin.OpenFbByUrl(GameConstants.CommunityJP);
    else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Kor)
      IGGSDKPlugin.OpenFbByUrl(GameConstants.CommunityKR);
    else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Rus)
      IGGSDKPlugin.OpenFbByUrl(GameConstants.CommunityRU);
    else
      IGGSDKPlugin.OpenFbByUrl(url);
  }

  private void Update()
  {
    this.tickTime += Time.deltaTime;
    if ((double) this.tickTime < 1.0)
      return;
    if (this.CheckNeedCountDown())
      this.DateDiff(this.m_EndTime, DateTime.Now);
    this.tickTime = 0.0f;
  }

  private void InitUI()
  {
    this.m_SpArry = this.transform.GetComponent<UISpritesArray>();
    this.m_TitleText = this.transform.GetChild(1).GetComponent<UIText>();
    this.m_TitleText.font = this.GM.GetTTFFont();
    this.m_Content = this.transform.GetChild(2).GetChild(0).GetComponent<RectTransform>();
    this.m_ScrollViewRect = this.transform.GetChild(2).GetComponent<RectTransform>();
    this.m_Msg = this.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.m_Msg.font = this.GM.GetTTFFont();
    this.m_TimeText = this.transform.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.m_TimeText.font = this.GM.GetTTFFont();
    this.m_BtnRect[0] = (RectTransform) this.transform.GetChild(4);
    this.m_Btn[0] = this.transform.GetChild(4).GetComponent<UIButton>();
    this.m_Btn[0].m_Handler = (IUIButtonClickHandler) this;
    this.m_Btn[0].m_BtnID1 = 0;
    this.m_BtnFBImage = this.transform.GetChild(4).GetChild(0).GetComponent<Image>();
    if (GUIManager.Instance.IsArabic)
      this.transform.GetChild(4).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
      this.m_BtnFBImage.sprite = this.m_SpArry.GetSprite(4);
    else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
      this.m_BtnFBImage.sprite = this.m_SpArry.GetSprite(5);
    else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Kor)
      this.m_BtnFBImage.sprite = this.m_SpArry.GetSprite(6);
    else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Rus)
      this.m_BtnFBImage.sprite = this.m_SpArry.GetSprite(7);
    this.m_BtnText[0] = this.transform.GetChild(4).GetChild(1).GetComponent<UIText>();
    this.m_BtnText[0].font = this.GM.GetTTFFont();
    this.m_BtnRect[1] = (RectTransform) this.transform.GetChild(5);
    this.m_Btn[1] = this.transform.GetChild(5).GetComponent<UIButton>();
    this.m_Btn[1].m_Handler = (IUIButtonClickHandler) this;
    this.m_Btn[1].m_BtnID1 = 1;
    this.m_BtnText[1] = this.transform.GetChild(5).GetChild(0).GetComponent<UIText>();
    this.m_BtnText[1].font = this.GM.GetTTFFont();
    this.m_Exit = this.transform.GetChild(6).GetComponent<UIButton>();
    this.m_Exit.m_BtnID1 = 999;
    this.m_Exit.m_Handler = (IUIButtonClickHandler) this;
  }

  private void UpdateBtnText(GameMaintanceType type)
  {
    ((Component) this.m_BtnText[0]).gameObject.SetActive(true);
    ((Component) this.m_Btn[0]).gameObject.SetActive(true);
    this.m_Btn[0].image.sprite = this.m_SpArry.GetSprite(0);
    ((Graphic) this.m_BtnText[0]).rectTransform.anchoredPosition = new Vector2(34.8f, 0.0f);
    ((Behaviour) this.m_BtnFBImage).enabled = true;
    this.m_Btn[1].image.sprite = this.m_SpArry.GetSprite(0);
    this.m_BtnRect[1].anchoredPosition = new Vector2(151.5f, -219.5f);
    switch (type)
    {
      case GameMaintanceType.IsMaintain:
        this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID(8425U);
        this.m_BtnText[0].text = DataManager.Instance.UserLanguage != GameLanguage.GL_Chs ? (DataManager.Instance.UserLanguage != GameLanguage.GL_Jpn ? (DataManager.Instance.UserLanguage != GameLanguage.GL_Kor ? (DataManager.Instance.UserLanguage != GameLanguage.GL_Rus ? DataManager.Instance.mStringTable.GetStringByID(8427U) : DataManager.Instance.mStringTable.GetStringByID(9576U)) : DataManager.Instance.mStringTable.GetStringByID(9577U)) : DataManager.Instance.mStringTable.GetStringByID(9579U)) : DataManager.Instance.mStringTable.GetStringByID(9578U);
        this.m_Btn[0].image.sprite = this.m_SpArry.GetSprite(0);
        ((Behaviour) this.m_BtnFBImage).enabled = true;
        this.m_BtnText[1].text = DataManager.Instance.mStringTable.GetStringByID(8470U);
        ((Graphic) this.m_BtnText[1]).rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
        this.m_Btn[1].image.sprite = this.m_SpArry.GetSprite(0);
        break;
      case GameMaintanceType.HaveLoginInfo:
        this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID(8420U);
        ((Component) this.m_Btn[0]).gameObject.SetActive(false);
        this.m_BtnText[1].text = DataManager.Instance.mStringTable.GetStringByID(8428U);
        this.m_Btn[1].image.sprite = this.m_SpArry.GetSprite(1);
        this.m_BtnRect[1].anchoredPosition = new Vector2(0.0f, -219.5f);
        break;
      case GameMaintanceType.ForciblyUpdate:
        this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID(8421U);
        this.m_BtnText[0].text = DataManager.Instance.mStringTable.GetStringByID(8424U);
        ((Graphic) this.m_BtnText[0]).rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
        this.m_Btn[0].image.sprite = this.m_SpArry.GetSprite(0);
        ((Behaviour) this.m_BtnFBImage).enabled = false;
        this.m_BtnText[1].text = DataManager.Instance.mStringTable.GetStringByID(8422U);
        ((Graphic) this.m_BtnText[1]).rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
        this.m_Btn[1].image.sprite = this.m_SpArry.GetSprite(1);
        break;
      case GameMaintanceType.ProposalUpdate:
        this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID(8421U);
        this.m_BtnText[0].text = DataManager.Instance.mStringTable.GetStringByID(8423U);
        ((Graphic) this.m_BtnText[0]).rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
        this.m_Btn[0].image.sprite = this.m_SpArry.GetSprite(0);
        ((Behaviour) this.m_BtnFBImage).enabled = false;
        this.m_BtnText[1].text = DataManager.Instance.mStringTable.GetStringByID(8422U);
        ((Graphic) this.m_BtnText[1]).rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
        this.m_Btn[1].image.sprite = this.m_SpArry.GetSprite(1);
        break;
    }
  }

  private void SpawnStr()
  {
    for (int index = 0; index < this.MAX_STR; ++index)
      this.m_Str[index] = StringManager.Instance.SpawnString(200);
  }

  private void DeSpawn()
  {
    for (int index = 0; index < this.MAX_STR; ++index)
    {
      if (this.m_Str[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.m_Str[index]);
        this.m_Str[index] = (CString) null;
      }
    }
  }

  private void SetMaintainMsg(GameMaintanceType type)
  {
    this.m_Str[0].ClearString();
    switch (type)
    {
      case GameMaintanceType.IsMaintain:
        DateTimeOffset dateTimeOffset = new DateTimeOffset(Convert.ToDateTime(this.SDK.MaintanceData.StartTime), new TimeSpan(-5, 0, 0));
        this.m_Msg.text = ActivityManager.Instance.TransToLocalTime(this.GetMaintanceDataMessage(DataManager.Instance.UserLanguage));
        break;
      case GameMaintanceType.HaveLoginInfo:
        this.m_Msg.text = ActivityManager.Instance.TransToLocalTime(this.GetLoginBoxMsg(DataManager.Instance.UserLanguage));
        break;
      case GameMaintanceType.ForciblyUpdate:
        this.m_Msg.text = ActivityManager.Instance.TransToLocalTime(this.GetUpdateInfo(DataManager.Instance.UserLanguage));
        break;
      case GameMaintanceType.ProposalUpdate:
        this.m_Msg.text = ActivityManager.Instance.TransToLocalTime(this.GetUpdateInfo(DataManager.Instance.UserLanguage));
        break;
    }
    ((Graphic) this.m_Msg).rectTransform.sizeDelta = new Vector2(564f, this.m_Msg.preferredHeight);
    this.m_Content.sizeDelta = new Vector2(564f, this.m_Msg.preferredHeight);
    this.UpdateScrollRect();
  }

  private void SetMaintainTime(GameMaintanceType type)
  {
    if (type != GameMaintanceType.IsMaintain)
      return;
    DateTimeOffset dateTimeOffset = new DateTimeOffset(Convert.ToDateTime(this.SDK.MaintanceData.StartTime), new TimeSpan(-5, 0, 0));
    this.m_BeginTime = dateTimeOffset.UtcDateTime.ToLocalTime();
    dateTimeOffset = new DateTimeOffset(Convert.ToDateTime(this.SDK.MaintanceData.EndTime), new TimeSpan(-5, 0, 0));
    this.m_EndTime = dateTimeOffset.UtcDateTime.ToLocalTime();
  }

  private bool CheckNeedCountDown()
  {
    bool flag1 = false;
    bool flag2 = false;
    if (this.m_MaintanceType == GameMaintanceType.IsMaintain && DateTime.Compare(this.m_EndTime, DateTime.Now) >= 0)
    {
      flag1 = true;
      flag2 = true;
    }
    if (this.transform.GetChild(3).gameObject.activeSelf != flag2)
      this.transform.GetChild(3).gameObject.SetActive(flag2);
    if (!this.bReConfig && this.m_MaintanceType == GameMaintanceType.IsMaintain && !flag2 && IGGGameSDK.Instance.GameMaintanceDataReady)
    {
      this.bReConfig = true;
      IGGGameSDK.Instance.GameMaintanceDataReady = false;
      IGGSDKPlugin.LoadGameConfig();
    }
    return flag1;
  }

  private void DateDiff(DateTime DateTime1, DateTime DateTime2)
  {
    this.m_Str[1].ClearString();
    TimeSpan timeSpan = new TimeSpan(DateTime1.Ticks).Subtract(new TimeSpan(DateTime2.Ticks)).Duration();
    if (timeSpan.Days >= 1)
    {
      this.m_Str[1].IntToFormat((long) timeSpan.Days);
      this.m_Str[1].IntToFormat((long) timeSpan.Hours, 2, true);
      this.m_Str[1].IntToFormat((long) timeSpan.Minutes, 2, true);
      this.m_Str[1].IntToFormat((long) timeSpan.Seconds, 2, true);
      this.m_Str[1].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8456U));
    }
    else
    {
      this.m_Str[1].IntToFormat((long) timeSpan.Hours, 2, true);
      this.m_Str[1].IntToFormat((long) timeSpan.Minutes, 2, true);
      this.m_Str[1].IntToFormat((long) timeSpan.Seconds, 2, true);
      this.m_Str[1].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8426U));
    }
    this.m_TimeText.text = this.m_Str[1].ToString();
    this.m_TimeText.SetAllDirty();
    this.m_TimeText.cachedTextGenerator.Invalidate();
  }

  private void UpdateScrollRect()
  {
    Vector2 sizeDelta = this.m_ScrollViewRect.sizeDelta;
    Vector2 anchoredPosition = this.m_ScrollViewRect.anchoredPosition;
    if (this.m_Msg.text.Length > 1500)
    {
      ((Behaviour) ((Component) this.m_Msg).GetComponent<Shadow>()).enabled = false;
      if (this.m_Msg.text.Length > 3000)
        ((Behaviour) ((Component) this.m_Msg).GetComponent<Outline>()).enabled = false;
    }
    if (this.m_MaintanceType != GameMaintanceType.IsMaintain)
    {
      this.m_ScrollViewRect.anchoredPosition = new Vector2(anchoredPosition.x, -120f);
      this.m_ScrollViewRect.sizeDelta = new Vector2(sizeDelta.x, 365f);
    }
    else
    {
      this.m_ScrollViewRect.anchoredPosition = new Vector2(anchoredPosition.x, -103f);
      this.m_ScrollViewRect.sizeDelta = new Vector2(sizeDelta.x, 330f);
    }
  }

  public string GetMaintanceDataMessage(GameLanguage language)
  {
    switch (language)
    {
      case GameLanguage.GL_Eng:
        return this.SDK.MaintanceData.Message_Eg;
      case GameLanguage.GL_Cht:
        return this.SDK.MaintanceData.Message_Tw;
      case GameLanguage.GL_Fre:
        return this.SDK.MaintanceData.Message_FR;
      case GameLanguage.GL_Gem:
        return this.SDK.MaintanceData.Message_DE;
      case GameLanguage.GL_Spa:
        return this.SDK.MaintanceData.Message_ES;
      case GameLanguage.GL_Rus:
        return this.SDK.MaintanceData.Message_RU;
      case GameLanguage.GL_Chs:
        return this.SDK.MaintanceData.Message_CN.Trim() == string.Empty ? this.SDK.MaintanceData.Message_Tw : this.SDK.MaintanceData.Message_CN;
      case GameLanguage.GL_Idn:
        return this.SDK.MaintanceData.Message_ID;
      case GameLanguage.GL_Vet:
        return this.SDK.MaintanceData.Message_VI;
      case GameLanguage.GL_Tur:
        return this.SDK.MaintanceData.Message_TR;
      case GameLanguage.GL_Tha:
        return this.SDK.MaintanceData.Message_TH;
      case GameLanguage.GL_Ita:
        return this.SDK.MaintanceData.Message_IT;
      case GameLanguage.GL_Pot:
        return this.SDK.MaintanceData.Message_PT;
      case GameLanguage.GL_Kor:
        return this.SDK.MaintanceData.Message_KO;
      case GameLanguage.GL_Jpn:
        return this.SDK.MaintanceData.Message_JP;
      case GameLanguage.GL_Ukr:
        return this.SDK.MaintanceData.Message_UA;
      case GameLanguage.GL_Mys:
        return this.SDK.MaintanceData.Message_MY;
      case GameLanguage.GL_Arb:
        return this.SDK.MaintanceData.Message_ARB;
      default:
        return this.SDK.MaintanceData.Message_Eg;
    }
  }

  public string GetLoginBoxMsg(GameLanguage language)
  {
    switch (language)
    {
      case GameLanguage.GL_Eng:
        return this.SDK.MaintanceData.LoginBoxMsg_Eg;
      case GameLanguage.GL_Cht:
        return this.SDK.MaintanceData.LoginBoxMsg_Tw;
      case GameLanguage.GL_Fre:
        return this.SDK.MaintanceData.LoginBoxMsg_FR;
      case GameLanguage.GL_Gem:
        return this.SDK.MaintanceData.LoginBoxMsg_DE;
      case GameLanguage.GL_Spa:
        return this.SDK.MaintanceData.LoginBoxMsg_ES;
      case GameLanguage.GL_Rus:
        return this.SDK.MaintanceData.LoginBoxMsg_RU;
      case GameLanguage.GL_Chs:
        return this.SDK.MaintanceData.LoginBoxMsg_CN.Trim() == string.Empty ? this.SDK.MaintanceData.LoginBoxMsg_Tw : this.SDK.MaintanceData.LoginBoxMsg_CN;
      case GameLanguage.GL_Idn:
        return this.SDK.MaintanceData.LoginBoxMsg_ID;
      case GameLanguage.GL_Vet:
        return this.SDK.MaintanceData.LoginBoxMsg_VI;
      case GameLanguage.GL_Tur:
        return this.SDK.MaintanceData.LoginBoxMsg_TR;
      case GameLanguage.GL_Tha:
        return this.SDK.MaintanceData.LoginBoxMsg_TH;
      case GameLanguage.GL_Ita:
        return this.SDK.MaintanceData.LoginBoxMsg_IT;
      case GameLanguage.GL_Pot:
        return this.SDK.MaintanceData.LoginBoxMsg_PT;
      case GameLanguage.GL_Kor:
        return this.SDK.MaintanceData.LoginBoxMsg_KO;
      case GameLanguage.GL_Jpn:
        return this.SDK.MaintanceData.LoginBoxMsg_JP;
      case GameLanguage.GL_Ukr:
        return this.SDK.MaintanceData.LoginBoxMsg_UA;
      case GameLanguage.GL_Mys:
        return this.SDK.MaintanceData.LoginBoxMsg_MY;
      case GameLanguage.GL_Arb:
        return this.SDK.MaintanceData.LoginBoxMsg_ARB;
      default:
        return this.SDK.MaintanceData.LoginBoxMsg_Eg;
    }
  }

  public string GetUpdateInfo(GameLanguage language)
  {
    switch (language)
    {
      case GameLanguage.GL_Eng:
        return this.SDK.MaintanceData.UpdateInfo_Eg;
      case GameLanguage.GL_Cht:
        return this.SDK.MaintanceData.UpdateInfo_Tw;
      case GameLanguage.GL_Fre:
        return this.SDK.MaintanceData.UpdateInfo_FR;
      case GameLanguage.GL_Gem:
        return this.SDK.MaintanceData.UpdateInfo_DE;
      case GameLanguage.GL_Spa:
        return this.SDK.MaintanceData.UpdateInfo_ES;
      case GameLanguage.GL_Rus:
        return this.SDK.MaintanceData.UpdateInfo_RU;
      case GameLanguage.GL_Chs:
        return this.SDK.MaintanceData.UpdateInfo_CN.Trim() == string.Empty ? this.SDK.MaintanceData.UpdateInfo_Tw : this.SDK.MaintanceData.UpdateInfo_CN;
      case GameLanguage.GL_Idn:
        return this.SDK.MaintanceData.UpdateInfo_ID;
      case GameLanguage.GL_Vet:
        return this.SDK.MaintanceData.UpdateInfo_VI;
      case GameLanguage.GL_Tur:
        return this.SDK.MaintanceData.UpdateInfo_TR;
      case GameLanguage.GL_Tha:
        return this.SDK.MaintanceData.UpdateInfo_TH;
      case GameLanguage.GL_Ita:
        return this.SDK.MaintanceData.UpdateInfo_IT;
      case GameLanguage.GL_Pot:
        return this.SDK.MaintanceData.UpdateInfo_PT;
      case GameLanguage.GL_Kor:
        return this.SDK.MaintanceData.UpdateInfo_KO;
      case GameLanguage.GL_Jpn:
        return this.SDK.MaintanceData.UpdateInfo_JP;
      case GameLanguage.GL_Ukr:
        return this.SDK.MaintanceData.UpdateInfo_UA;
      case GameLanguage.GL_Mys:
        return this.SDK.MaintanceData.UpdateInfo_MY;
      case GameLanguage.GL_Arb:
        return this.SDK.MaintanceData.UpdateInfo_ARB;
      default:
        return this.SDK.MaintanceData.UpdateInfo_Eg;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.m_TitleText != (UnityEngine.Object) null && ((Behaviour) this.m_TitleText).enabled)
    {
      ((Behaviour) this.m_TitleText).enabled = false;
      ((Behaviour) this.m_TitleText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_Msg != (UnityEngine.Object) null && ((Behaviour) this.m_Msg).enabled)
    {
      ((Behaviour) this.m_Msg).enabled = false;
      ((Behaviour) this.m_Msg).enabled = true;
    }
    if ((UnityEngine.Object) this.m_TimeText != (UnityEngine.Object) null && ((Behaviour) this.m_TimeText).enabled)
    {
      ((Behaviour) this.m_TimeText).enabled = false;
      ((Behaviour) this.m_TimeText).enabled = true;
    }
    if (this.m_BtnText == null)
      return;
    for (int index = 0; index < this.m_BtnText.Length; ++index)
    {
      if ((UnityEngine.Object) this.m_BtnText[index] != (UnityEngine.Object) null && ((Behaviour) this.m_BtnText[index]).enabled)
      {
        ((Behaviour) this.m_BtnText[index]).enabled = false;
        ((Behaviour) this.m_BtnText[index]).enabled = true;
      }
    }
  }
}
