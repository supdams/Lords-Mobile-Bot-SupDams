// Decompiled with JetBrains decompiler
// Type: IGGGameSDK
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using MiniJSON;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

#nullable disable
public class IGGGameSDK : MonoBehaviour
{
  private const int MaxTransString = 10;
  private const int MaxTransStringLen = 1024;
  private const int MaxTranslateBatchStringLen = 4100;
  private const int MaxTransString_Mail = 5;
  private const int MaxTransStringLen_Mail = 1100;
  private const int MaxTranslateBatchStringLen_Mail = 4500;
  private const int MaxTransString_Diplomatic = 20;
  private const int MaxTransStringLen_Diplomatic = 1024;
  private const int MaxTranslateBatchStringLen_Diplomatic = 8200;
  private const int MaxTransStringLen_KA = 1400;
  private const int MaxTransStringLen_AA = 1400;
  private static IGGGameSDK instance;
  private string[] CallBackWords;
  private IGGLoginState m_LoginState;
  private bool bNeedShowCheckBox;
  private bool bNeedUpdateAccountUI;
  private bool bNeedOpenAnnouncement;
  private bool bNeedSendAccountBind;
  private bool bFacebookBindSuccessful;
  private bool bWeChatBindSuccessful;
  private bool bBindingNameSuccessful;
  private bool bNeedUpdateIOSAccountUI;
  private bool bNeedShowSwitchCheckBox;
  private bool bNeedShowBindAccountCheckBox;
  private bool bGuestLoginFailedCallBackNeedUpdate;
  private bool bAmazonBindSuccessful;
  private bool bIGGIdIsReady;
  private bool bRateSucceeded;
  private byte bBuyPackageSucceed;
  private byte bSprinklesSucceed;
  private int PurchaseLimitType;
  private PayErrorCode payErrorCode;
  private bool bPayErrorNoCode;
  private IGGLoginCode iggLoginCode;
  private bool bNeedUpdateRealNameState;
  public bool bBindingGoogle;
  public string m_IGGID = string.Empty;
  public string m_SessionKey = string.Empty;
  private string m_SaveBindGoogleAccount = string.Empty;
  public IGGLoginType m_IGGLoginType;
  public string m_PlatformLoginName = string.Empty;
  public bool bUsingTranslate;
  public string m_BindGoogleAccount = string.Empty;
  public List<string> m_MailList;
  public bool bPaymentReady;
  private Dictionary<int, IGGGameItem> m_IGGProductItem = new Dictionary<int, IGGGameItem>();
  private bool bGameMaintanceDataReady;
  private GameMaintanceData m_MaintanceData;
  private bool bNotConnect;
  public int[] HiVersion;
  public int[] LowVersion;
  public string MinVersion;
  public CString[] TranslateString = new CString[10];
  private CString TranslateBatchString;
  public CString[] TranslateString_Mail = new CString[5];
  private CString TranslateBatchString_Mail;
  public CString[] TranslateString_Diplomatic = new CString[20];
  private CString TranslateBatchString_Diplomatic;
  public CString TranslateStringOut_KA;
  public CString TranslateStringOut_AA_Info;
  public CString TranslateStringOut_AA_Public;
  private byte _UserLanguageMapToTranslateLanguageIdx;
  private string m_SelectAccount = string.Empty;
  public bool bShowAccountState;
  public RealNameState m_RealNameState;
  public AgeState m_AgeState;
  private float m_RealNameTickTime;

  public bool IGGIdIsReady => this.bIGGIdIsReady;

  public string SaveBindGoogleAccount
  {
    get => this.m_SaveBindGoogleAccount;
    set => this.m_SaveBindGoogleAccount = value;
  }

  public string SessionKey => this.m_SessionKey;

  public bool GameMaintanceDataReady
  {
    set => this.bGameMaintanceDataReady = value;
    get => this.bGameMaintanceDataReady;
  }

  public bool NotConnect
  {
    get => this.bNotConnect;
    set => this.bNotConnect = value;
  }

  public GameMaintanceData MaintanceData => this.m_MaintanceData;

  public byte UserLanguageMapToTranslateLanguageIdx => this._UserLanguageMapToTranslateLanguageIdx;

  public string SelectAccount => this.m_SelectAccount;

  public static IGGGameSDK Instance => IGGGameSDK.instance;

  protected void Awake()
  {
    if ((UnityEngine.Object) IGGGameSDK.instance == (UnityEngine.Object) null)
      IGGGameSDK.instance = this;
    int index1 = Mathf.Clamp((int) DataManager.Instance.UserLanguage, 1, GameConstants.GlobalEditionGameID.Length - 1);
    IGGSDKPlugin.SetupIGGPlatform(GameConstants.GlobalEditionGameID[index1], GameConstants.GlobalEditionSecretKey[index1], GameConstants.GlobalEditionPaymentKey, GameConstants.GlobalEditionGCMSenderId);
    int UseLanguage = Mathf.Clamp((int) DataManager.Instance.UserLanguage, 1, GameConstants.TranslateTragetLanguage.Length - 1);
    IGGSDKPlugin.SetTragetLanguage(GameConstants.TranslateTragetLanguage[UseLanguage]);
    this._UserLanguageMapToTranslateLanguageIdx = this.GetTranslateLanguageIdxByUseLanguage((byte) UseLanguage);
    IGGSDKPlugin.SetAppsFlyerKey();
    PushManage.ClearPush();
    for (int index2 = 0; index2 < this.TranslateString.Length; ++index2)
    {
      if (this.TranslateString[index2] == null)
        this.TranslateString[index2] = new CString(1024);
    }
    if (this.TranslateBatchString == null)
      this.TranslateBatchString = new CString(4100);
    for (int index3 = 0; index3 < this.TranslateString_Mail.Length; ++index3)
    {
      if (this.TranslateString_Mail[index3] == null)
        this.TranslateString_Mail[index3] = new CString(1100);
    }
    if (this.TranslateBatchString_Mail == null)
      this.TranslateBatchString_Mail = new CString(4500);
    for (int index4 = 0; index4 < this.TranslateString_Diplomatic.Length; ++index4)
    {
      if (this.TranslateString_Diplomatic[index4] == null)
        this.TranslateString_Diplomatic[index4] = new CString(1024);
    }
    if (this.TranslateBatchString_Diplomatic == null)
      this.TranslateBatchString_Diplomatic = new CString(8200);
    if (this.TranslateStringOut_KA == null)
      this.TranslateStringOut_KA = new CString(1400);
    if (this.TranslateStringOut_AA_Info == null)
      this.TranslateStringOut_AA_Info = new CString(1400);
    if (this.TranslateStringOut_AA_Public != null)
      return;
    this.TranslateStringOut_AA_Public = new CString(1400);
  }

  private void DebugLog(string pMessage)
  {
  }

  private void NotifyIggIdIsReadyNow()
  {
    this.m_MailList = new List<string>();
    this.m_IGGProductItem.Clear();
    this.bPaymentReady = false;
    IGGSDKPlugin.GetProductList();
    IGGSDKPlugin.OpenPushNotification();
    IGGSDKPlugin.SetFacebookEventActivateApp();
    IGGSDKPlugin.SetFacebookSdkInitialize();
    IGGSDKPlugin.RegisterCallback();
    IGGSDKPlugin.FacebookCheckInvites();
    IGGSDKPlugin.AppsFlyerSignUp();
    IGGSDKPlugin.ShowFacebookDebug();
    IGGSDKPlugin.CompleteRegistration("IGGSDK");
    IGGSDKPlugin.SetFacebookEventLaunched();
    if (NetworkManager.OnContinue())
    {
      this.SetLoginMsg(IGGLoginCode.IggReady);
    }
    else
    {
      this.bGameMaintanceDataReady = false;
      IGGSDKPlugin.LoadGameConfig();
    }
  }

  private void GameConfigIsReady()
  {
    if (this.m_RealNameState == RealNameState.Authorized)
      ;
    this.LoginOrOpenAnnouncement();
  }

  private void LoginOrOpenAnnouncement()
  {
    if (this.GetGameMaintanceType() == GameMaintanceType.None)
      this.SetLoginMsg(IGGLoginCode.IggReady);
    else
      this.bNeedOpenAnnouncement = true;
  }

  private bool SetLoginMsg(IGGLoginCode code)
  {
    if (this.bNeedShowCheckBox)
      return false;
    this.iggLoginCode = code;
    return this.bNeedShowCheckBox = true;
  }

  private bool SetLoginMsg(string code)
  {
    IGGLoginCode code1 = IGGLoginCode.Paranormal;
    int result;
    if (int.TryParse(code, out result))
      code1 = (IGGLoginCode) result <= code1 ? (IGGLoginCode) (result + 400000) : (IGGLoginCode) result;
    return this.SetLoginMsg(code1);
  }

  public void CanLogIn() => NetworkManager.LogmeIn(this.m_IGGID, this.SessionKey);

  private void Update()
  {
    if (this.bNeedShowCheckBox)
      this.bNeedShowCheckBox = UpdateController.OnIGGLogin(this.iggLoginCode);
    if (this.bNeedUpdateAccountUI)
    {
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other_Account, 1);
      this.bNeedUpdateAccountUI = false;
      this.bNeedSendAccountBind = true;
      SocialManager.Instance.BindingPlatform();
    }
    if (this.bNeedOpenAnnouncement)
    {
      this.bNeedOpenAnnouncement = false;
      if (UpdateController.OnIGGLoginBBS())
      {
        if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Announcement))
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Announcement, 0);
        else
          GUIManager.Instance.OpenMenu(EGUIWindow.UI_Announcement);
      }
    }
    if (this.bNeedSendAccountBind && NetworkManager.Connected())
    {
      DataManager.Instance.SendAccountBind();
      this.bNeedSendAccountBind = false;
    }
    if (this.bRateSucceeded)
    {
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_TreasureBox, 1);
      this.bRateSucceeded = false;
    }
    if (this.bBuyPackageSucceed != (byte) 0 && NetworkManager.Connected())
    {
      if (this.bBuyPackageSucceed == (byte) 1)
      {
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(899U), DataManager.Instance.mStringTable.GetStringByID(900U), DataManager.Instance.mStringTable.GetStringByID(3U));
        ushort sendCheckBuySn = (ushort) MallManager.Instance.SendCheckBuySN;
        if (sendCheckBuySn != (ushort) 0 && MallManager.Instance.FindIndexBySN(sendCheckBuySn) != -1)
          MallManager.Instance.bLockBuy = true;
        ushort sendCheckEmojiId = MallManager.Instance.SendCheckEmojiID;
        if (sendCheckEmojiId != (ushort) 0 && !GUIManager.Instance.HasEmotionPck(sendCheckEmojiId))
          MallManager.Instance.bLockBuyEmojiID = true;
        ushort sendCheckCastleId = MallManager.Instance.SendCheckCastleID;
        if (sendCheckCastleId != (ushort) 0 && !GUIManager.Instance.BuildingData.castleSkin.CheckUnlock((byte) sendCheckCastleId))
          MallManager.Instance.bLockBuyCastleID = true;
        if (MallManager.Instance.SendCheckRedPocketID != (ushort) 0)
          MallManager.Instance.bLockBuyRedPocket = true;
        if (MerchantmanManager.Instance.SendCheckBuy != (byte) 0)
          MerchantmanManager.Instance.bLockBuy = true;
      }
      this.bBuyPackageSucceed = (byte) 0;
    }
    if (this.bSprinklesSucceed == (byte) 1)
    {
      GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(11231U), DataManager.Instance.mStringTable.GetStringByID(11232U), DataManager.Instance.mStringTable.GetStringByID(3U));
      this.bSprinklesSucceed = (byte) 0;
    }
    if (this.bFacebookBindSuccessful)
    {
      GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(614U), DataManager.Instance.mStringTable.GetStringByID(9006U));
      this.bFacebookBindSuccessful = false;
      SocialManager.Instance.BindingPlatform();
    }
    if (this.bBindingNameSuccessful)
    {
      SocialManager.Instance.BindingPlatform();
      this.bBindingNameSuccessful = false;
    }
    if (this.bWeChatBindSuccessful)
    {
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other_Account, 1);
      this.bWeChatBindSuccessful = false;
      this.bNeedSendAccountBind = true;
      SocialManager.Instance.BindingPlatform();
    }
    if (this.bNeedUpdateIOSAccountUI)
    {
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other_Account, 3);
      this.bNeedUpdateIOSAccountUI = false;
    }
    if (this.bNeedShowSwitchCheckBox)
    {
      this.bNeedShowSwitchCheckBox = false;
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other_Account, 100);
    }
    if (this.bNeedShowBindAccountCheckBox)
    {
      this.bNeedShowBindAccountCheckBox = false;
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other_Account, 200);
    }
    if (this.bGuestLoginFailedCallBackNeedUpdate)
    {
      this.bGuestLoginFailedCallBackNeedUpdate = false;
      GUIManager.Instance.HideUILock(EUILock.SwitchAccount);
    }
    if (this.bAmazonBindSuccessful)
      SocialManager.Instance.BindingPlatform();
    if (this.PurchaseLimitType > 0)
    {
      if (this.PurchaseLimitType == 1)
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(614U), DataManager.Instance.mStringTable.GetStringByID(10044U), DataManager.Instance.mStringTable.GetStringByID(3U));
      else if (this.PurchaseLimitType == 2 || this.PurchaseLimitType == 3)
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(614U), DataManager.Instance.mStringTable.GetStringByID(10043U), DataManager.Instance.mStringTable.GetStringByID(3U));
      else if (this.PurchaseLimitType == 4)
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(614U), DataManager.Instance.mStringTable.GetStringByID(14557U), DataManager.Instance.mStringTable.GetStringByID(3U));
      this.PurchaseLimitType = 0;
    }
    if (this.payErrorCode != PayErrorCode.None)
    {
      GUIManager.Instance.MsgStr.ClearString();
      GUIManager.Instance.MsgStr.IntToFormat((long) this.payErrorCode);
      GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10050U));
      GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(614U), GUIManager.Instance.MsgStr.ToString(), DataManager.Instance.mStringTable.GetStringByID(3U));
      this.payErrorCode = PayErrorCode.None;
    }
    if (this.bPayErrorNoCode)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(10069U), (ushort) byte.MaxValue);
      this.bPayErrorNoCode = false;
    }
    if (this.bNeedUpdateRealNameState)
    {
      RealNameHelp.Instance.SetRealNameState(this.m_RealNameState);
      RealNameHelp.Instance.CheckRealNameCallBack(this.m_RealNameState);
      AntiAddictive.Instance.Start(IGGGameSDK.Instance.GetAddictedCheckNoticeSW(), IGGGameSDK.Instance.GetAddictedCheckLimitLoginSW(), IGGGameSDK.Instance.m_RealNameState, IGGGameSDK.Instance.m_AgeState);
      this.bNeedUpdateRealNameState = false;
    }
    AntiAddictive.Instance.Update();
    RealNameHelp.Instance.Update();
  }

  public void AutoLoginSuccessfulCallBack(string pString)
  {
    this.m_LoginState = IGGLoginState.IGGID_READY;
    this.CallBackWords = pString.Split(';');
    this.m_IGGID = this.CallBackWords[0];
    this.m_SessionKey = this.CallBackWords[1];
    this.bBindingGoogle = this.CallBackWords[3] == "1";
    this.m_BindGoogleAccount = this.CallBackWords.Length <= 4 || !(this.CallBackWords[4] != "0") ? string.Empty : this.CallBackWords[4];
    if (this.CallBackWords.Length > 5)
    {
      if (this.CallBackWords[5] == "GOOGLE_PLAY")
      {
        this.m_IGGLoginType = IGGLoginType.GOOGLE_PLAY;
        this.SetBindingName(string.Empty);
      }
      else if (this.CallBackWords[5] == "gameCenter")
      {
        this.m_IGGLoginType = IGGLoginType.GameCenter;
        this.SetBindingName(string.Empty);
      }
      else if (this.CallBackWords[5] == "Facebook" || this.CallBackWords[5] == "facebook" || this.CallBackWords[5] == "FACEBOOK")
      {
        this.m_IGGLoginType = IGGLoginType.Facebook;
        this.m_BindGoogleAccount = this.CallBackWords[4];
        if (this.CallBackWords.Length > 6 && this.CallBackWords[6] != null)
          this.m_PlatformLoginName = this.CallBackWords[6];
      }
      else if (this.CallBackWords[5] == "wechat" || this.CallBackWords[5] == "WECHAT")
      {
        this.m_IGGLoginType = IGGLoginType.WeChat;
        if (this.CallBackWords.Length > 6 && this.CallBackWords[6] != null)
          this.m_PlatformLoginName = this.CallBackWords[6];
        if (this.CallBackWords.Length > 7 && this.CallBackWords[7] != null)
          this.SetBindingName(this.CallBackWords[7]);
      }
      else if (this.CallBackWords[5] == "AMAZON")
      {
        this.m_IGGLoginType = IGGLoginType.AMAZON;
        this.m_BindGoogleAccount = this.CallBackWords[4];
        if (this.CallBackWords.Length > 7 && this.CallBackWords[7] != null)
          this.SetBindingName(this.CallBackWords[7]);
      }
      else
      {
        this.m_IGGLoginType = IGGLoginType.GUEST;
        if (this.CallBackWords.Length > 7 && this.CallBackWords[7] != null)
          this.SetBindingName(this.CallBackWords[7]);
      }
    }
    if (this.bBindingGoogle && this.m_BindGoogleAccount == string.Empty)
      this.m_BindGoogleAccount = DataManager.Instance.LoadBindMail();
    this.bIGGIdIsReady = true;
    this.NotifyIggIdIsReadyNow();
  }

  public void AutoLoginFailedCallBack(string pString) => this.SetLoginMsg(pString);

  public void GuestLoginSuccessfulCallBack(string pString)
  {
    if (GUIManager.Instance.GetUILock() == EUILock.SwitchAccount)
    {
      IGGSDKPlugin.NotificationUninitialize();
      this.SetLoginMsg(IGGLoginCode.SwitchOk);
    }
    else
    {
      this.CallBackWords = pString.Split(';');
      this.m_IGGID = this.CallBackWords[0];
      this.m_SessionKey = this.CallBackWords[1];
      if (this.CallBackWords[2] == "1")
      {
        this.bBindingGoogle = true;
        this.SetBindingName(string.Empty);
      }
      else
        this.bBindingGoogle = false;
      this.m_BindGoogleAccount = string.Empty;
      if (this.bBindingGoogle && this.m_BindGoogleAccount == string.Empty)
        this.m_BindGoogleAccount = DataManager.Instance.LoadBindMail();
      this.bIGGIdIsReady = true;
      this.NotifyIggIdIsReadyNow();
    }
  }

  public void GuestLoginFailedCallBack(string pString)
  {
    this.bGuestLoginFailedCallBackNeedUpdate = true;
    this.SetLoginMsg(pString);
  }

  public void FacebookLoginSuccessfulCallBack(string pString)
  {
    IGGSDKPlugin.NotificationUninitialize();
    this.SetLoginMsg(IGGLoginCode.SwitchOk);
  }

  public void ClearFacebookSessionCallBack(string pString)
  {
    IGGSDKPlugin.NotificationUninitialize();
    this.SetLoginMsg(IGGLoginCode.SwitchOk);
  }

  public void FacebookLoginFailedCallBack(string pString)
  {
    GUIManager.Instance.AddHUDMessage(string.Format("{0}:{1}", (object) DataManager.Instance.mStringTable.GetStringByID(7081U), (object) pString), (ushort) byte.MaxValue);
  }

  public void FacebookBindSuccessfulCallBack(string pString)
  {
    this.bFacebookBindSuccessful = true;
    this.SetBindingNameByJSON(pString);
  }

  public void FacebookBindFailedCallBack(string pString)
  {
    switch (pString)
    {
      case "10023":
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9544U), (ushort) byte.MaxValue);
        break;
      case "10024":
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9008U), (ushort) byte.MaxValue);
        break;
      default:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9007U), (ushort) byte.MaxValue);
        break;
    }
  }

  public void WechatLoginCallBackSuccessful(string pString)
  {
    IGGSDKPlugin.UninitializeGeTu();
    this.SetLoginMsg(IGGLoginCode.SwitchOk);
  }

  public void WeChatLoginCallBackFailed(string pString)
  {
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7081U), (ushort) byte.MaxValue);
  }

  public void BindWeChatCallBackFailed(string pString)
  {
    GUIManager instance = GUIManager.Instance;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    int ID;
    switch (pString)
    {
      case "2":
        ID = 9515;
        break;
      case "3":
        ID = 9545;
        break;
      default:
        ID = 9007;
        break;
    }
    string stringById = mStringTable.GetStringByID((uint) ID);
    instance.AddHUDMessage(stringById, (ushort) byte.MaxValue);
  }

  public void BindWeChatCallBackSuccessful(string pString)
  {
    this.bBindingGoogle = true;
    this.bWeChatBindSuccessful = true;
    this.SetBindingNameByJSON(pString);
  }

  public void GameCenterLoginSuccessfulCallBack(string pString)
  {
    MonoBehaviour.print((object) ("GameCenterLoginSuccessfulCallBack:" + pString));
  }

  public void SwitchAccountCallBack(string pString)
  {
    this.m_SelectAccount = pString;
    this.bShowAccountState = false;
    this.bNeedShowSwitchCheckBox = true;
  }

  public void SwitchingGoogleAccountSuccessfulCallBack(string pString)
  {
    GUIManager.Instance.HideUILock(EUILock.SwitchingGoogleAccount);
    this.SetLoginMsg(IGGLoginCode.SwitchOk);
  }

  public void SwitchingGoogleAccountCancelCallBack(string pString)
  {
    GUIManager.Instance.HideUILock(EUILock.SwitchAccount);
    this.bNotConnect = false;
    NetworkManager.TimeOut();
  }

  public void SwitchingGoogleAccountFailedCallBack(string pString)
  {
    GUIManager.Instance.HideUILock(EUILock.SwitchAccount);
    GUIManager.Instance.AddHUDMessage(string.Format("{0}:{1}", (object) DataManager.Instance.mStringTable.GetStringByID(7081U), (object) pString), (ushort) byte.MaxValue);
    this.bNotConnect = false;
    NetworkManager.TimeOut();
  }

  public void setFailedCallBack(string pString)
  {
    this.payErrorCode = PayErrorCode.ErrorPaymentFailed;
  }

  public void preparingPaymentFailedCallBack(string pString)
  {
    this.payErrorCode = PayErrorCode.ErrorPaymentIsNotReady;
  }

  public void paySuccessCallBack(string pString)
  {
    uint result = 0;
    if (uint.TryParse(pString, out result))
    {
      AFAdvanceManager.Instance.CheckPurchase(result);
      AFAdvanceManager.Instance.SupplyHest(result);
    }
    this.bBuyPackageSucceed = (byte) 1;
  }

  public void SprinklesSuccessCallBack(string pString) => this.bSprinklesSucceed = (byte) 1;

  public void payGatewayFailedCallBack(string pString)
  {
    this.payErrorCode = PayErrorCode.ErrorPaymentGetway;
  }

  public void payFailedCallBack(string pString)
  {
    this.payErrorCode = PayErrorCode.ErrorPaymentFailed;
    MallManager.Instance.ClearSendCheckBuySN();
  }

  public void payCancelCallBack(string pString) => MallManager.Instance.ClearSendCheckBuySN();

  public void payErrorNoCode(string pString) => this.bPayErrorNoCode = true;

  public void getProductCallBack(string pString)
  {
    MallManager instance = MallManager.Instance;
    this.m_IGGProductItem.Clear();
    if (pString == null || string.Empty == pString || pString.Length <= 0)
    {
      IGGSDKPlugin.GetProductList();
    }
    else
    {
      string[] strArray1 = pString.Split('}');
      for (int index = 0; index < strArray1.Length; ++index)
      {
        if (strArray1[index] != string.Empty)
        {
          string[] strArray2 = strArray1[index].Split(';');
          IGGGameItem iggGameItem = new IGGGameItem();
          iggGameItem.Id = int.Parse(strArray2[0]);
          iggGameItem.Title = strArray2[1];
          iggGameItem.Price = strArray2[2];
          iggGameItem.Currency = strArray2[3];
          iggGameItem.Flag = (IGGGameItemFlag) int.Parse(strArray2[4]);
          iggGameItem.FreePoint = int.Parse(strArray2[5]);
          iggGameItem.Point = int.Parse(strArray2[6]);
          iggGameItem.Memo = strArray2[7];
          iggGameItem.PlatformPrice = strArray2[8];
          this.m_IGGProductItem.Add(iggGameItem.Id, iggGameItem);
          MallItemPrice mallItemPrice;
          if (!instance.m_MallItemPrice.ContainsKey(iggGameItem.Id))
          {
            mallItemPrice = new MallItemPrice();
            mallItemPrice.Id = iggGameItem.Id;
            mallItemPrice.Price = iggGameItem.Price;
            mallItemPrice.Currency = iggGameItem.Currency;
            mallItemPrice.Point = iggGameItem.Point;
            mallItemPrice.PaltformPrice = iggGameItem.PlatformPrice;
            instance.m_MallItemPrice.Add(mallItemPrice.Id, mallItemPrice);
          }
          else if (instance.m_MallItemPrice[iggGameItem.Id].Price != iggGameItem.Price || instance.m_MallItemPrice[iggGameItem.Id].Point != iggGameItem.Point)
          {
            mallItemPrice = instance.m_MallItemPrice[iggGameItem.Id] with
            {
              Id = iggGameItem.Id,
              Price = iggGameItem.Price,
              Currency = iggGameItem.Currency,
              Point = iggGameItem.Point,
              PaltformPrice = iggGameItem.PlatformPrice
            };
            instance.m_MallItemPrice[iggGameItem.Id] = mallItemPrice;
            instance.bNeedUpDateItemPtice = true;
          }
        }
      }
      this.bPaymentReady = true;
    }
  }

  public void GCMRegisterSuccessfulCallBack(string pString)
  {
  }

  public void GCMRegisterFailedCallBack(string pString)
  {
  }

  public void BindAccountCallBack(string pString)
  {
    this.m_SelectAccount = pString;
    this.bShowAccountState = false;
    this.bNeedShowBindAccountCheckBox = true;
  }

  public void BindingGoogleSuccessfulCallBack(string pString)
  {
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7086U), (ushort) byte.MaxValue);
    GUIManager.Instance.HideUILock(EUILock.Normal);
    DataManager.Instance.SaveBindMail(this.SaveBindGoogleAccount);
    this.m_BindGoogleAccount = this.SaveBindGoogleAccount;
    this.bBindingGoogle = true;
    this.bNeedUpdateAccountUI = true;
    this.SetBindingNameByJSON(string.Empty);
  }

  public void BindingGoogleFailedCallBack(string pString)
  {
    if (pString == "1")
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8478U), (ushort) byte.MaxValue);
    else
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7082U), (ushort) byte.MaxValue);
    this.SaveBindGoogleAccount = string.Empty;
    GUIManager.Instance.HideUILock(EUILock.Normal);
  }

  public void TapcashViewSuccessfulCallBack(string pString)
  {
  }

  public void TapcashViewFailedCallBack(string pString)
  {
  }

  public void RateUsSuccessfulCallBack(string pString)
  {
  }

  public void RateUsFailedCallBack(string pString)
  {
  }

  public void FacebookLikeCallBack(string pString)
  {
  }

  public void EventCarnivalCallBackSuccessful(string pString)
  {
  }

  public void EventCarnivalCallBackFailed(string pString)
  {
  }

  public void GameMaintanceCallBackSuccessful(string pString)
  {
    if (!(Json.Deserialize(pString) is Dictionary<string, object> dictionary1))
      return;
    this.m_MaintanceData = new GameMaintanceData();
    if (dictionary1.ContainsKey("Update"))
    {
      if (!(dictionary1["Update"] is Dictionary<string, object> dictionary2))
        return;
      if (dictionary2.ContainsKey("isMaintain"))
        this.m_MaintanceData.IsMaintain = dictionary2["isMaintain"].ToString();
      if (dictionary2.ContainsKey("message_tw"))
        this.m_MaintanceData.Message_Tw = dictionary2["message_tw"].ToString();
      if (dictionary2.ContainsKey("message_Eg"))
        this.m_MaintanceData.Message_Eg = dictionary2["message_Eg"].ToString();
      if (dictionary2.ContainsKey("message_de"))
        this.m_MaintanceData.Message_DE = dictionary2["message_de"].ToString();
      if (dictionary2.ContainsKey("message_fr"))
        this.m_MaintanceData.Message_FR = dictionary2["message_fr"].ToString();
      if (dictionary2.ContainsKey("message_es"))
        this.m_MaintanceData.Message_ES = dictionary2["message_es"].ToString();
      if (dictionary2.ContainsKey("message_ru"))
        this.m_MaintanceData.Message_RU = dictionary2["message_ru"].ToString();
      if (dictionary2.ContainsKey("message_cn"))
        this.m_MaintanceData.Message_CN = dictionary2["message_cn"].ToString();
      if (dictionary2.ContainsKey("message_id"))
        this.m_MaintanceData.Message_ID = dictionary2["message_id"].ToString();
      if (dictionary2.ContainsKey("message_vi"))
        this.m_MaintanceData.Message_VI = dictionary2["message_vi"].ToString();
      if (dictionary2.ContainsKey("message_tr"))
        this.m_MaintanceData.Message_TR = dictionary2["message_tr"].ToString();
      if (dictionary2.ContainsKey("message_th"))
        this.m_MaintanceData.Message_TH = dictionary2["message_th"].ToString();
      if (dictionary2.ContainsKey("message_it"))
        this.m_MaintanceData.Message_IT = dictionary2["message_it"].ToString();
      if (dictionary2.ContainsKey("message_pt"))
        this.m_MaintanceData.Message_PT = dictionary2["message_pt"].ToString();
      if (dictionary2.ContainsKey("message_ko"))
        this.m_MaintanceData.Message_KO = dictionary2["message_ko"].ToString();
      if (dictionary2.ContainsKey("message_jp"))
        this.m_MaintanceData.Message_JP = dictionary2["message_jp"].ToString();
      if (dictionary2.ContainsKey("message_ua"))
        this.m_MaintanceData.Message_UA = dictionary2["message_ua"].ToString();
      if (dictionary2.ContainsKey("message_my"))
        this.m_MaintanceData.Message_MY = dictionary2["message_my"].ToString();
      if (dictionary2.ContainsKey("message_arb"))
        this.m_MaintanceData.Message_ARB = dictionary2["message_arb"].ToString();
      if (dictionary2.ContainsKey("startTime"))
        this.m_MaintanceData.StartTime = dictionary2["startTime"].ToString();
      if (dictionary2.ContainsKey("endTime"))
        this.m_MaintanceData.EndTime = dictionary2["endTime"].ToString();
    }
    if (dictionary1.ContainsKey("loginBox"))
    {
      if (!(dictionary1["loginBox"] is Dictionary<string, object> dictionary3))
        return;
      if (dictionary3.ContainsKey("msg_tw"))
        this.m_MaintanceData.LoginBoxMsg_Tw = dictionary3["msg_tw"].ToString();
      if (dictionary3.ContainsKey("msg_Eg"))
        this.m_MaintanceData.LoginBoxMsg_Eg = dictionary3["msg_Eg"].ToString();
      if (dictionary3.ContainsKey("msg_de"))
        this.m_MaintanceData.LoginBoxMsg_DE = dictionary3["msg_de"].ToString();
      if (dictionary3.ContainsKey("msg_fr"))
        this.m_MaintanceData.LoginBoxMsg_FR = dictionary3["msg_fr"].ToString();
      if (dictionary3.ContainsKey("msg_es"))
        this.m_MaintanceData.LoginBoxMsg_ES = dictionary3["msg_es"].ToString();
      if (dictionary3.ContainsKey("msg_ru"))
        this.m_MaintanceData.LoginBoxMsg_RU = dictionary3["msg_ru"].ToString();
      if (dictionary3.ContainsKey("msg_cn"))
        this.m_MaintanceData.LoginBoxMsg_CN = dictionary3["msg_cn"].ToString();
      if (dictionary3.ContainsKey("msg_id"))
        this.m_MaintanceData.LoginBoxMsg_ID = dictionary3["msg_id"].ToString();
      if (dictionary3.ContainsKey("msg_vi"))
        this.m_MaintanceData.LoginBoxMsg_VI = dictionary3["msg_vi"].ToString();
      if (dictionary3.ContainsKey("msg_tr"))
        this.m_MaintanceData.LoginBoxMsg_TR = dictionary3["msg_tr"].ToString();
      if (dictionary3.ContainsKey("msg_th"))
        this.m_MaintanceData.LoginBoxMsg_TH = dictionary3["msg_th"].ToString();
      if (dictionary3.ContainsKey("msg_it"))
        this.m_MaintanceData.LoginBoxMsg_IT = dictionary3["msg_it"].ToString();
      if (dictionary3.ContainsKey("msg_pt"))
        this.m_MaintanceData.LoginBoxMsg_PT = dictionary3["msg_pt"].ToString();
      if (dictionary3.ContainsKey("msg_ko"))
        this.m_MaintanceData.LoginBoxMsg_KO = dictionary3["msg_ko"].ToString();
      if (dictionary3.ContainsKey("msg_jp"))
        this.m_MaintanceData.LoginBoxMsg_JP = dictionary3["msg_jp"].ToString();
      if (dictionary3.ContainsKey("msg_ua"))
        this.m_MaintanceData.LoginBoxMsg_UA = dictionary3["msg_ua"].ToString();
      if (dictionary3.ContainsKey("msg_my"))
        this.m_MaintanceData.LoginBoxMsg_MY = dictionary3["msg_my"].ToString();
      if (dictionary3.ContainsKey("msg_arb"))
        this.m_MaintanceData.LoginBoxMsg_ARB = dictionary3["msg_arb"].ToString();
      if (dictionary3.ContainsKey("startTime"))
        this.m_MaintanceData.LoginBoxStartTime = dictionary3["startTime"].ToString();
      if (dictionary3.ContainsKey("endTime"))
        this.m_MaintanceData.LoginBoxEndTime = dictionary3["endTime"].ToString();
    }
    if (dictionary1.ContainsKey("clientUpdate"))
    {
      if (!(dictionary1["clientUpdate"] is Dictionary<string, object> dictionary4))
        return;
      if (dictionary4.ContainsKey("versionCode"))
        this.m_MaintanceData.VersionCode = dictionary4["versionCode"].ToString();
      if (dictionary4.ContainsKey("minVersion"))
        this.m_MaintanceData.MinVersion = dictionary4["minVersion"].ToString();
      if (dictionary4.ContainsKey("url"))
        this.m_MaintanceData.URL = dictionary4["url"].ToString();
      if (dictionary4.ContainsKey("version"))
        this.m_MaintanceData.Version = dictionary4["version"].ToString();
      if (dictionary4.ContainsKey("package"))
        this.m_MaintanceData.Package = dictionary4["package"].ToString();
      if (dictionary4.ContainsKey("size"))
        this.m_MaintanceData.Size = dictionary4["size"].ToString();
      if (dictionary4.ContainsKey("loginInfo_tw"))
        this.m_MaintanceData.loginInfo_Tw = dictionary4["loginInfo_tw"].ToString();
      if (dictionary4.ContainsKey("loginInfo_Eg"))
        this.m_MaintanceData.loginInfo_Eg = dictionary4["loginInfo_Eg"].ToString();
      if (dictionary4.ContainsKey("updateInfo_tw"))
        this.m_MaintanceData.UpdateInfo_Tw = dictionary4["updateInfo_tw"].ToString();
      if (dictionary4.ContainsKey("updateInfo_Eg"))
        this.m_MaintanceData.UpdateInfo_Eg = dictionary4["updateInfo_Eg"].ToString();
      if (dictionary4.ContainsKey("updateInfo_de"))
        this.m_MaintanceData.UpdateInfo_DE = dictionary4["updateInfo_de"].ToString();
      if (dictionary4.ContainsKey("updateInfo_fr"))
        this.m_MaintanceData.UpdateInfo_FR = dictionary4["updateInfo_fr"].ToString();
      if (dictionary4.ContainsKey("updateInfo_es"))
        this.m_MaintanceData.UpdateInfo_ES = dictionary4["updateInfo_es"].ToString();
      if (dictionary4.ContainsKey("updateInfo_ru"))
        this.m_MaintanceData.UpdateInfo_RU = dictionary4["updateInfo_ru"].ToString();
      if (dictionary4.ContainsKey("updateInfo_cn"))
        this.m_MaintanceData.UpdateInfo_CN = dictionary4["updateInfo_cn"].ToString();
      if (dictionary4.ContainsKey("updateInfo_id"))
        this.m_MaintanceData.UpdateInfo_ID = dictionary4["updateInfo_id"].ToString();
      if (dictionary4.ContainsKey("updateInfo_vi"))
        this.m_MaintanceData.UpdateInfo_VI = dictionary4["updateInfo_vi"].ToString();
      if (dictionary4.ContainsKey("updateInfo_tr"))
        this.m_MaintanceData.UpdateInfo_TR = dictionary4["updateInfo_tr"].ToString();
      if (dictionary4.ContainsKey("updateInfo_th"))
        this.m_MaintanceData.UpdateInfo_TH = dictionary4["updateInfo_th"].ToString();
      if (dictionary4.ContainsKey("updateInfo_it"))
        this.m_MaintanceData.UpdateInfo_IT = dictionary4["updateInfo_it"].ToString();
      if (dictionary4.ContainsKey("updateInfo_pt"))
        this.m_MaintanceData.UpdateInfo_PT = dictionary4["updateInfo_pt"].ToString();
      if (dictionary4.ContainsKey("updateInfo_ko"))
        this.m_MaintanceData.UpdateInfo_KO = dictionary4["updateInfo_ko"].ToString();
      if (dictionary4.ContainsKey("updateInfo_jp"))
        this.m_MaintanceData.UpdateInfo_JP = dictionary4["updateInfo_jp"].ToString();
      if (dictionary4.ContainsKey("updateInfo_ua"))
        this.m_MaintanceData.UpdateInfo_UA = dictionary4["updateInfo_ua"].ToString();
      if (dictionary4.ContainsKey("updateInfo_my"))
        this.m_MaintanceData.UpdateInfo_MY = dictionary4["updateInfo_my"].ToString();
      if (dictionary4.ContainsKey("updateInfo_arb"))
        this.m_MaintanceData.UpdateInfo_ARB = dictionary4["updateInfo_arb"].ToString();
      if (dictionary4.ContainsKey("starStatus"))
        this.m_MaintanceData.StarStatus = dictionary4["starStatus"].ToString();
      if (dictionary4.ContainsKey("translate"))
        this.m_MaintanceData.TranslateStatus = dictionary4["translate"].ToString();
      if (dictionary4.ContainsKey("realNamePayCheck"))
        this.m_MaintanceData.RealNameCheck = dictionary4["realNamePayCheck"].ToString();
      if (dictionary4.ContainsKey("minorsDailySpendAmount"))
        this.m_MaintanceData.MinorsDailySpendAmount = dictionary4["minorsDailySpendAmount"].ToString();
      if (dictionary4.ContainsKey("addictedCheckNotice"))
        this.m_MaintanceData.AddictedCheckNotice = dictionary4["addictedCheckNotice"].ToString();
      if (dictionary4.ContainsKey("addictedCheckLimitLogin"))
        this.m_MaintanceData.AddictedCheckLimitLogin = dictionary4["addictedCheckLimitLogin"].ToString();
      if (dictionary4.ContainsKey("otherDownloadUrl"))
        this.m_MaintanceData.OtherDownloadUrl = dictionary4["otherDownloadUrl"].ToString();
    }
    if (dictionary1.ContainsKey("loginServer"))
    {
      List<object> objectList = dictionary1["loginServer"] as List<object>;
      this.m_MaintanceData.LoginServer = new LoginServerData[objectList.Count];
      for (int index = 0; index < objectList.Count; ++index)
      {
        Dictionary<string, object> dictionary5 = objectList[index] as Dictionary<string, object>;
        if (dictionary5.ContainsKey("isOpen"))
          this.m_MaintanceData.LoginServer[index].IsOpen = dictionary5["isOpen"].ToString();
        if (dictionary5.ContainsKey("host"))
          this.m_MaintanceData.LoginServer[index].Host = dictionary5["host"].ToString();
      }
    }
    this.HiVersion = new int[3];
    this.LowVersion = new int[3];
    string[] strArray1 = this.m_MaintanceData.VersionCode.Split('.');
    int result = 0;
    for (int index = 0; index < strArray1.Length; ++index)
    {
      if (int.TryParse(strArray1[index], out result))
        this.HiVersion[index] = result;
    }
    string[] strArray2 = this.m_MaintanceData.MinVersion.Split('.');
    for (int index = 0; index < strArray2.Length; ++index)
    {
      if (int.TryParse(strArray2[index], out result))
        this.LowVersion[index] = result;
    }
    this.bGameMaintanceDataReady = true;
    this.GameConfigIsReady();
  }

  public void GameMaintanceCallBackFailed(string pString)
  {
    this.SetLoginMsg(IGGLoginCode.IggReady);
  }

  public void RateGooglePlayApplicationSucceeded(string pString)
  {
    if (!(pString == "true"))
      return;
    this.bRateSucceeded = true;
  }

  public void TranslateSuccessfulCallBack(string pString)
  {
    this.bUsingTranslate = false;
    GUIManager.Instance.TranslateStr = pString;
    GUIManager.Instance.bBackTranslate = true;
    Debug.Log((object) nameof (TranslateSuccessfulCallBack));
  }

  public void TranslateFailedCallBack(string pString)
  {
    this.bUsingTranslate = false;
    GUIManager.Instance.bBackTranslateFail = (byte) 1;
    Debug.Log((object) nameof (TranslateFailedCallBack));
  }

  public void TranslateBatchSuccessfulCallBack(string pString)
  {
    this.bUsingTranslate = false;
    this.Split(pString);
    GUIManager.Instance.bBackTranslateBatch = true;
    Debug.Log((object) nameof (TranslateBatchSuccessfulCallBack));
  }

  public void TranslateBatchFailedCallBack(string pString)
  {
    this.bUsingTranslate = false;
    GUIManager.Instance.bBackTranslateFail = (byte) 2;
    Debug.Log((object) nameof (TranslateBatchFailedCallBack));
  }

  public void Translate_MailSuccessfulCallBack(string pString)
  {
  }

  public void Translate_MailFailedCallBack(string pString)
  {
    Debug.Log((object) nameof (Translate_MailFailedCallBack));
  }

  public void TranslateBatch_MailSuccessfulCallBack(string pString)
  {
    this.Split_Mail(pString);
    DataManager.Instance.MIB.Read = true;
    DataManager.Instance.MIB.Change = true;
  }

  public void TranslateBatch_MailFailedCallBack(string pString)
  {
    DataManager.Instance.MIB.Change = true;
    DataManager.Instance.MIB.Read = false;
  }

  public void TranslateBatch_DiplomaticSuccessfulCallBack(string pString)
  {
    this.Split_Diplomatic(pString);
    GUIManager.Instance.bBackTranslateBatch_MB = true;
  }

  public void Translate_KASuccessfulCallBack(string pString)
  {
    DataManager.Instance.mKingdomClassifieds_L = this.GetTranslateSplite(pString);
    DataManager.Instance.bTranslateClassifieds = true;
    DataManager.Instance.bWaitTranslateClassifieds = false;
  }

  public void Translate_KAFailedCallBack(string pString)
  {
    DataManager.Instance.bTranslateClassifiedsFailed = true;
    DataManager.Instance.bWaitTranslateClassifieds = false;
  }

  public void TranslateBatch_DiplomaticFailedCallBack(string pString)
  {
    GUIManager.Instance.bBackTranslateFail_MB = (byte) 1;
  }

  public void TranslateBatchByList(List<CString> list)
  {
    char ch = '\u001F';
    this.TranslateBatchString.ClearString();
    int num = 10 <= list.Count ? 9 : list.Count - 1;
    for (int index = 0; index < 10 && index < list.Count; ++index)
    {
      this.TranslateBatchString.Append(list[index].ToString());
      if (index != num)
        this.TranslateBatchString.Append(ch);
    }
    this.TranslateBatchString.SetLength(this.TranslateBatchString.Length);
    IGGSDKPlugin.TranslateBatch(this.TranslateBatchString.ToString());
    this.TranslateBatchString.SetLength(this.TranslateBatchString.MaxLength);
  }

  public void TranslateBatchByList_Mail(List<CString> list)
  {
    char ch = '\u001F';
    this.TranslateBatchString_Mail.ClearString();
    int num = 5 <= list.Count ? 4 : list.Count - 1;
    for (int index = 0; index < 5 && index < list.Count; ++index)
    {
      this.TranslateBatchString_Mail.Append(list[index].ToString());
      if (index != num)
        this.TranslateBatchString_Mail.Append(ch);
    }
    this.TranslateBatchString_Mail.SetLength(this.TranslateBatchString_Mail.Length);
    IGGSDKPlugin.TranslateBatch_Mail(this.TranslateBatchString_Mail.ToString());
    this.TranslateBatchString_Mail.SetLength(this.TranslateBatchString_Mail.MaxLength);
  }

  public void TranslateBatchByList_Diplomatic(List<CString> list)
  {
    char ch = '\u001F';
    this.TranslateBatchString_Diplomatic.ClearString();
    int num = 20 <= list.Count ? 19 : list.Count - 1;
    for (int index = 0; index < 20 && index < list.Count; ++index)
    {
      this.TranslateBatchString_Diplomatic.Append(list[index].ToString());
      if (index != num)
        this.TranslateBatchString_Diplomatic.Append(ch);
    }
    this.TranslateBatchString_Diplomatic.SetLength(this.TranslateBatchString_Diplomatic.Length);
    IGGSDKPlugin.TranslateBatch_Diplomatic(this.TranslateBatchString_Diplomatic.ToString());
    this.TranslateBatchString_Diplomatic.SetLength(this.TranslateBatchString_Diplomatic.MaxLength);
  }

  public void Translate_AASuccessfulCallBack(string pString)
  {
    if (DataManager.Instance.bTransAA)
    {
      DataManager.Instance.mAA_Info_L = this.GetTranslateSplite_AA_Info(pString);
      DataManager.Instance.bTranslate_AA_Info = true;
    }
    else
    {
      DataManager.Instance.mAA_P_L = this.GetTranslateSplite_AA_Public(pString);
      DataManager.Instance.bTranslate_AA_P = true;
    }
    DataManager.Instance.bWaitTranslate_AA = false;
  }

  public void Translate_AAFailedCallBack(string pString)
  {
    if (DataManager.Instance.bTransAA)
      DataManager.Instance.bTranslate_AA_InfoFailed = true;
    else
      DataManager.Instance.bTranslate_AA_PFailed = true;
    DataManager.Instance.bWaitTranslate_AA = false;
  }

  public unsafe void Split(string pString)
  {
    char ch = '\u001F';
    int index1 = 0;
    int index2 = 0;
    for (int index3 = 0; index3 < this.TranslateString.Length; ++index3)
      this.TranslateString[index3].Length = 0;
    for (int index4 = 0; index4 < pString.Length; ++index4)
    {
      string str1 = pString.ToString();
      char* chPtr1 = (char*) ((IntPtr) str1 + RuntimeHelpers.OffsetToStringData);
      if ((int) chPtr1[index4] == (int) ch)
      {
        ++index1;
        if (index1 >= this.TranslateString.Length)
          break;
        string str2 = this.TranslateString[index1].ToString();
        char* chPtr2 = (char*) ((IntPtr) str2 + RuntimeHelpers.OffsetToStringData);
        chPtr2[index2] = char.MinValue;
        str2 = (string) null;
        index2 = 0;
      }
      else
      {
        str1 = (string) null;
        if (index1 < this.TranslateString.Length)
        {
          string str3 = this.TranslateString[index1].ToString();
          char* chPtr3 = (char*) ((IntPtr) str3 + RuntimeHelpers.OffsetToStringData);
          chPtr3[index2++] = pString[index4];
          str3 = (string) null;
          ++this.TranslateString[index1].Length;
        }
      }
    }
  }

  public unsafe void Split_Mail(string pString)
  {
    char ch = '\u001F';
    int index1 = 0;
    int index2 = 0;
    for (int index3 = 0; index3 < this.TranslateString_Mail.Length; ++index3)
      this.TranslateString_Mail[index3].Length = 0;
    for (int index4 = 0; index4 < pString.Length; ++index4)
    {
      string str1 = pString.ToString();
      char* chPtr1 = (char*) ((IntPtr) str1 + RuntimeHelpers.OffsetToStringData);
      if ((int) chPtr1[index4] == (int) ch)
      {
        ++index1;
        if (index1 >= this.TranslateString_Mail.Length)
          break;
        string str2 = this.TranslateString_Mail[index1].ToString();
        char* chPtr2 = (char*) ((IntPtr) str2 + RuntimeHelpers.OffsetToStringData);
        chPtr2[index2] = char.MinValue;
        str2 = (string) null;
        index2 = 0;
      }
      else
      {
        str1 = (string) null;
        if (index1 < this.TranslateString_Mail.Length)
        {
          string str3 = this.TranslateString_Mail[index1].ToString();
          char* chPtr3 = (char*) ((IntPtr) str3 + RuntimeHelpers.OffsetToStringData);
          chPtr3[index2++] = pString[index4];
          str3 = (string) null;
          ++this.TranslateString_Mail[index1].Length;
        }
      }
    }
  }

  public unsafe void Split_Diplomatic(string pString)
  {
    char ch = '\u001F';
    int index1 = 0;
    int index2 = 0;
    for (int index3 = 0; index3 < this.TranslateString_Diplomatic.Length; ++index3)
      this.TranslateString_Diplomatic[index3].Length = 0;
    for (int index4 = 0; index4 < pString.Length; ++index4)
    {
      string str1 = pString.ToString();
      char* chPtr1 = (char*) ((IntPtr) str1 + RuntimeHelpers.OffsetToStringData);
      if ((int) chPtr1[index4] == (int) ch)
      {
        ++index1;
        if (index1 >= this.TranslateString_Diplomatic.Length)
          break;
        string str2 = this.TranslateString_Diplomatic[index1].ToString();
        char* chPtr2 = (char*) ((IntPtr) str2 + RuntimeHelpers.OffsetToStringData);
        chPtr2[index2] = char.MinValue;
        str2 = (string) null;
        index2 = 0;
      }
      else
      {
        str1 = (string) null;
        if (index1 < this.TranslateString_Diplomatic.Length)
        {
          string str3 = this.TranslateString_Diplomatic[index1].ToString();
          char* chPtr3 = (char*) ((IntPtr) str3 + RuntimeHelpers.OffsetToStringData);
          chPtr3[index2++] = pString[index4];
          str3 = (string) null;
          ++this.TranslateString_Diplomatic[index1].Length;
        }
      }
    }
  }

  public ushort GetTranslateSplite(string pString)
  {
    if (pString == null)
      return 0;
    char ch = '\u007F';
    CString cstring = StringManager.Instance.StaticString1024();
    int index;
    for (index = 0; index < pString.Length && (int) pString[index] != (int) ch; ++index)
      cstring.Append(pString[index]);
    cstring.SetLength(cstring.Length);
    ushort languageStringId = (ushort) this.GetTranslateLanguageStringId(cstring.ToString());
    cstring.SetLength(cstring.MaxLength);
    this.TranslateStringOut_KA.Length = 0;
    this.TranslateStringOut_KA.Substring(pString, index + 1);
    this.TranslateStringOut_KA.CheckBannedWord();
    return languageStringId;
  }

  public ushort GetTranslateSplite_AA_Info(string pString)
  {
    if (pString == null)
      return 0;
    char ch = '\u007F';
    CString cstring = StringManager.Instance.StaticString1024();
    int index;
    for (index = 0; index < pString.Length && (int) pString[index] != (int) ch; ++index)
      cstring.Append(pString[index]);
    cstring.SetLength(cstring.Length);
    ushort languageStringId = (ushort) this.GetTranslateLanguageStringId(cstring.ToString());
    cstring.SetLength(cstring.MaxLength);
    this.TranslateStringOut_AA_Info.Length = 0;
    this.TranslateStringOut_AA_Info.Substring(pString, index + 1);
    this.TranslateStringOut_AA_Info.CheckBannedWord();
    return languageStringId;
  }

  public ushort GetTranslateSplite_AA_Public(string pString)
  {
    if (pString == null)
      return 0;
    char ch = '\u007F';
    CString cstring = StringManager.Instance.StaticString1024();
    int index;
    for (index = 0; index < pString.Length && (int) pString[index] != (int) ch; ++index)
      cstring.Append(pString[index]);
    cstring.SetLength(cstring.Length);
    ushort languageStringId = (ushort) this.GetTranslateLanguageStringId(cstring.ToString());
    cstring.SetLength(cstring.MaxLength);
    this.TranslateStringOut_AA_Public.Length = 0;
    this.TranslateStringOut_AA_Public.Substring(pString, index + 1);
    this.TranslateStringOut_AA_Public.CheckBannedWord();
    return languageStringId;
  }

  public void AliPayCallBackSuccessful(string pString)
  {
    this.bBuyPackageSucceed = (byte) 1;
    GUIManager.Instance.HideUILock(EUILock.AliPay);
  }

  public void AliPayCallBackFailed(string pString)
  {
    MallManager.Instance.ClearSendCheckBuySN();
    GUIManager.Instance.HideUILock(EUILock.AliPay);
  }

  public void AliPayConfirming(string pString)
  {
    MallManager.Instance.ClearSendCheckBuySN();
    GUIManager.Instance.HideUILock(EUILock.AliPay);
  }

  public void WeChatPayCallBackSuccessful(string pString)
  {
    this.bBuyPackageSucceed = (byte) 1;
    GUIManager.Instance.HideUILock(EUILock.WeChatPay);
  }

  public void WeChatPayCallBackFailed(string pString)
  {
    MallManager.Instance.ClearSendCheckBuySN();
    GUIManager.Instance.HideUILock(EUILock.WeChatPay);
  }

  public void WeChatPatCallBackCencel(string pString)
  {
    MallManager.Instance.ClearSendCheckBuySN();
    GUIManager.Instance.HideUILock(EUILock.WeChatPay);
  }

  public void AmoutOfLimitFailed(string pString)
  {
    this.PurchaseLimitType = 4;
    GUIManager.Instance.HideUILock(EUILock.AliPay);
    GUIManager.Instance.HideUILock(EUILock.WeChatPay);
  }

  public void AmoutOfLimitErrorFailed(string pString)
  {
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.StringToFormat(pString);
    cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(16018U));
    GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
    GUIManager.Instance.HideUILock(EUILock.AliPay);
    GUIManager.Instance.HideUILock(EUILock.WeChatPay);
  }

  public void BindingAmazonSuccessfulCallBack()
  {
    this.bBindingGoogle = true;
    this.bAmazonBindSuccessful = true;
    this.SetBindingName(string.Empty);
  }

  public void BindingAmazonFailedCallBack()
  {
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9007U), (ushort) byte.MaxValue);
  }

  public void AmazonLoginCallBackSuccessful() => this.SetLoginMsg(IGGLoginCode.SwitchOk);

  public void AmazonLoginCallBackFailed()
  {
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7081U), (ushort) byte.MaxValue);
  }

  public void PurchaseLimitCallBack(string type)
  {
    switch (type)
    {
      case "1":
        this.PurchaseLimitType = 1;
        break;
      case "2":
        this.PurchaseLimitType = 2;
        break;
      case "3":
        this.PurchaseLimitType = 3;
        break;
    }
  }

  public void RealNameCallBackFailed(string errorcode)
  {
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.StringToFormat(errorcode);
    cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(16018U));
    GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
  }

  public void RealNameCheckCallBack(string state)
  {
    this.m_RealNameState = RealNameState.UnAuthorized;
    this.m_AgeState = AgeState.Nonage;
    switch (state)
    {
      case "1":
        this.m_RealNameState = RealNameState.Sumbitted;
        this.m_AgeState = AgeState.Nonage;
        break;
      case "2":
        this.m_RealNameState = RealNameState.Authorized;
        this.m_AgeState = AgeState.GrownUp;
        break;
      case "3":
        this.m_RealNameState = RealNameState.Authorized;
        this.m_AgeState = AgeState.Nonage;
        break;
      case "4":
        this.m_RealNameState = RealNameState.UnAuthorized;
        this.m_AgeState = AgeState.Nonage;
        break;
    }
    this.bNeedUpdateRealNameState = true;
  }

  public void OnInstallConversionDataLoaded(string pData)
  {
    Debug.LogError((object) pData);
    SocialManager.Instance.InviterIGGId = 0L;
    SocialManager.Instance.InviterName = string.Empty;
    if (!(Json.Deserialize(pData) is Dictionary<string, object> dictionary) || !dictionary.ContainsKey("media_source") || !dictionary["media_source"].ToString().Equals("friend-recommendation"))
      return;
    if (dictionary.ContainsKey("af_sub1"))
      long.TryParse(dictionary["af_sub1"].ToString(), out SocialManager.Instance.InviterIGGId);
    if (!dictionary.ContainsKey("af_sub2"))
      return;
    SocialManager.Instance.InviterName = dictionary["af_sub2"].ToString();
    if (!SocialManager.Instance.InviterName.Equals("null"))
      return;
    SocialManager.Instance.InviterName = string.Empty;
  }

  public void OnInstallConversionFailure(string pData)
  {
    Debug.LogError((object) pData);
    SocialManager.Instance.InviterIGGId = 0L;
    SocialManager.Instance.InviterName = string.Empty;
  }

  public void OnAppOpenAttribution(string pData) => Debug.LogError((object) pData);

  public void OnAttributionFailure(string pData) => Debug.LogError((object) pData);

  public string GetProductPriceByID(int id)
  {
    return this.bPaymentReady && this.m_IGGProductItem.ContainsKey(id) ? this.m_IGGProductItem[id].Price : (string) null;
  }

  public bool GetProductPointByID(int id, out int point)
  {
    bool productPointById = false;
    point = 0;
    if (this.bPaymentReady && this.m_IGGProductItem.ContainsKey(id))
    {
      point = this.m_IGGProductItem[id].Point;
      productPointById = true;
    }
    return productPointById;
  }

  public string GetCurrency(int id)
  {
    return this.bPaymentReady && this.m_IGGProductItem.ContainsKey(id) ? this.m_IGGProductItem[id].Currency : (string) null;
  }

  public string GetProductTitleByID(int id)
  {
    return this.bPaymentReady && this.m_IGGProductItem.ContainsKey(id) ? this.m_IGGProductItem[id].Title : (string) null;
  }

  public GameMaintanceType GetGameMaintanceType()
  {
    DateTimeOffset dateTimeOffset;
    DateTime t2_1;
    if (this.MaintanceData.StartTime != string.Empty && this.MaintanceData.StartTime != "0")
    {
      dateTimeOffset = new DateTimeOffset(Convert.ToDateTime(this.MaintanceData.StartTime), new TimeSpan(-5, 0, 0));
      t2_1 = dateTimeOffset.UtcDateTime.ToLocalTime();
    }
    else
      t2_1 = new DateTime();
    DateTime t1_1;
    if (this.MaintanceData.EndTime != string.Empty && this.MaintanceData.EndTime != "0")
    {
      dateTimeOffset = new DateTimeOffset(Convert.ToDateTime(this.MaintanceData.EndTime), new TimeSpan(-5, 0, 0));
      t1_1 = dateTimeOffset.UtcDateTime.ToLocalTime();
    }
    else
      t1_1 = new DateTime();
    DateTime t1_2;
    if (this.MaintanceData.LoginBoxEndTime != string.Empty && this.MaintanceData.LoginBoxEndTime != "0")
    {
      dateTimeOffset = new DateTimeOffset(Convert.ToDateTime(this.MaintanceData.LoginBoxEndTime), new TimeSpan(-5, 0, 0));
      t1_2 = dateTimeOffset.UtcDateTime.ToLocalTime();
    }
    else
      t1_2 = new DateTime();
    DateTime t2_2;
    if (this.MaintanceData.LoginBoxStartTime != string.Empty && this.MaintanceData.LoginBoxStartTime != "0")
    {
      dateTimeOffset = new DateTimeOffset(Convert.ToDateTime(this.MaintanceData.LoginBoxStartTime), new TimeSpan(-5, 0, 0));
      t2_2 = dateTimeOffset.UtcDateTime.ToLocalTime();
    }
    else
      t2_2 = new DateTime();
    GameMaintanceType gameMaintanceType = this.NeedUpdateVession();
    return gameMaintanceType == GameMaintanceType.None ? (!(this.m_MaintanceData.IsMaintain == "1") || DateTime.Compare(DateTime.Now, t2_1) < 0 || DateTime.Compare(t1_1, DateTime.Now) < 0 ? (!(this.m_MaintanceData.LoginBoxMsg_Tw != string.Empty) || DateTime.Compare(DateTime.Now, t2_2) < 0 || DateTime.Compare(t1_2, DateTime.Now) < 0 ? GameMaintanceType.None : GameMaintanceType.HaveLoginInfo) : GameMaintanceType.IsMaintain) : gameMaintanceType;
  }

  public GameMaintanceType NeedUpdateVession()
  {
    ushort num1 = (ushort) ((uint) (ushort) (this.LowVersion[0] << 8) | (uint) this.LowVersion[1]);
    ushort num2 = (ushort) ((uint) (ushort) (this.HiVersion[0] << 8) | (uint) this.HiVersion[1]);
    ushort num3 = (ushort) ((uint) (ushort) ((uint) GameConstants.Version[0] << 8) | (uint) GameConstants.Version[1]);
    if ((int) num3 >= (int) num2)
      return GameMaintanceType.None;
    return (int) num3 >= (int) num1 ? GameMaintanceType.ProposalUpdate : GameMaintanceType.ForciblyUpdate;
  }

  public bool IsGameMaintanceType(GameMaintanceType _GameMaintanceType)
  {
    bool flag = false;
    DateTimeOffset dateTimeOffset;
    DateTime t2_1;
    if (this.MaintanceData.StartTime != string.Empty && this.MaintanceData.StartTime != "0")
    {
      dateTimeOffset = new DateTimeOffset(Convert.ToDateTime(this.MaintanceData.StartTime), new TimeSpan(-5, 0, 0));
      t2_1 = dateTimeOffset.UtcDateTime.ToLocalTime();
    }
    else
      t2_1 = new DateTime();
    DateTime t1_1;
    if (this.MaintanceData.EndTime != string.Empty && this.MaintanceData.EndTime != "0")
    {
      dateTimeOffset = new DateTimeOffset(Convert.ToDateTime(this.MaintanceData.EndTime), new TimeSpan(-5, 0, 0));
      t1_1 = dateTimeOffset.UtcDateTime.ToLocalTime();
    }
    else
      t1_1 = new DateTime();
    DateTime t1_2;
    if (this.MaintanceData.LoginBoxEndTime != string.Empty && this.MaintanceData.LoginBoxEndTime != "0")
    {
      dateTimeOffset = new DateTimeOffset(Convert.ToDateTime(this.MaintanceData.LoginBoxEndTime), new TimeSpan(-5, 0, 0));
      t1_2 = dateTimeOffset.UtcDateTime.ToLocalTime();
    }
    else
      t1_2 = new DateTime();
    DateTime t2_2;
    if (this.MaintanceData.LoginBoxStartTime != string.Empty && this.MaintanceData.LoginBoxStartTime != "0")
    {
      dateTimeOffset = new DateTimeOffset(Convert.ToDateTime(this.MaintanceData.LoginBoxStartTime), new TimeSpan(-5, 0, 0));
      t2_2 = dateTimeOffset.UtcDateTime.ToLocalTime();
    }
    else
      t2_2 = new DateTime();
    switch (_GameMaintanceType)
    {
      case GameMaintanceType.IsMaintain:
        if (this.m_MaintanceData.IsMaintain == "1" && DateTime.Compare(DateTime.Now, t2_1) >= 0 && DateTime.Compare(t1_1, DateTime.Now) >= 0)
        {
          flag = true;
          break;
        }
        break;
      case GameMaintanceType.HaveLoginInfo:
        if (this.m_MaintanceData.LoginBoxMsg_Tw != string.Empty && DateTime.Compare(DateTime.Now, t2_2) >= 0 && DateTime.Compare(t1_2, DateTime.Now) >= 0)
        {
          flag = true;
          break;
        }
        break;
    }
    return flag;
  }

  public bool GetStarStatus()
  {
    return this.m_MaintanceData.StarStatus != null && !(this.m_MaintanceData.StarStatus == string.Empty) && this.m_MaintanceData.StarStatus == "1";
  }

  public bool GetTranslateStatus()
  {
    return this.m_MaintanceData.TranslateStatus != null && !(this.m_MaintanceData.TranslateStatus == string.Empty) && this.m_MaintanceData.TranslateStatus == "1";
  }

  public byte GetTranslateLanguageStringId(string str)
  {
    for (byte index = 0; (int) index < GameConstants.TranslateLanguage.Length; ++index)
    {
      if (str.Equals(GameConstants.TranslateLanguage[(int) index]))
        return (byte) ((uint) index + 1U);
    }
    return 0;
  }

  public string GetLanguageStringID(byte idx)
  {
    switch (idx)
    {
      case 0:
        return DataManager.Instance.mStringTable.GetStringByID(9053U);
      case 6:
        return DataManager.Instance.mStringTable.GetStringByID(9075U);
      case 42:
        return DataManager.Instance.mStringTable.GetStringByID(9074U);
      default:
        return DataManager.Instance.mStringTable.GetStringByID((uint) (ushort) (4651U + (uint) idx));
    }
  }

  public byte GetTranslateLanguageIdxByUseLanguage(byte UseLanguage)
  {
    byte idxByUseLanguage = 0;
    if ((int) UseLanguage < GameConstants.TranslateTragetLanguage.Length)
    {
      for (int index = 0; index < GameConstants.TranslateLanguage.Length; ++index)
      {
        if (GameConstants.TranslateLanguage[index] == GameConstants.TranslateTragetLanguage[(int) UseLanguage])
          idxByUseLanguage = (byte) (index + 1);
      }
    }
    return idxByUseLanguage;
  }

  public byte GetRealNameSW()
  {
    return this.m_MaintanceData.RealNameCheck != null && !this.m_MaintanceData.RealNameCheck.Equals("0") && (this.m_MaintanceData.RealNameCheck.Equals("1") || this.m_MaintanceData.RealNameCheck.Equals("2")) ? (byte) 1 : (byte) 0;
  }

  public byte GetAddictedCheckNoticeSW()
  {
    return this.m_MaintanceData.AddictedCheckNotice != null && this.m_MaintanceData.AddictedCheckNotice.Equals("1") ? (byte) 1 : (byte) 0;
  }

  public byte GetAddictedCheckLimitLoginSW()
  {
    return this.m_MaintanceData.AddictedCheckLimitLogin != null && this.m_MaintanceData.AddictedCheckLimitLogin.Equals("1") ? (byte) 1 : (byte) 0;
  }

  public float GetMinorsDailySpendAmount()
  {
    float result = 0.0f;
    try
    {
      return float.TryParse(this.m_MaintanceData.MinorsDailySpendAmount, out result) ? result : 0.0f;
    }
    catch (Exception ex)
    {
      Debug.LogError((object) ("GetMinorsDailySpendAmount Exception =" + this.m_MaintanceData.MinorsDailySpendAmount));
      return 0.0f;
    }
  }

  public string Encode(string source)
  {
    try
    {
      string s1 = "abcdefgh";
      StringBuilder stringBuilder = new StringBuilder();
      using (DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider())
      {
        byte[] bytes1 = Encoding.ASCII.GetBytes(s1);
        byte[] bytes2 = Encoding.ASCII.GetBytes(s1);
        byte[] bytes3 = Encoding.UTF8.GetBytes(source);
        cryptoServiceProvider.Mode = CipherMode.CBC;
        cryptoServiceProvider.Key = bytes1;
        cryptoServiceProvider.IV = bytes2;
        string s2 = string.Empty;
        using (MemoryStream memoryStream = new MemoryStream())
        {
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, cryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write))
          {
            cryptoStream.Write(bytes3, 0, bytes3.Length);
            cryptoStream.FlushFinalBlock();
            s2 = Convert.ToBase64String(memoryStream.ToArray());
          }
        }
        return WWW.EscapeURL(s2);
      }
    }
    catch (Exception ex)
    {
      Debug.Log((object) ex.StackTrace);
      return source;
    }
  }

  public void SetBindingNameByJSON(string pString)
  {
    try
    {
      SocialManager.Instance.BindingName = string.Empty;
      if (!(Json.Deserialize(pString) is Dictionary<string, object> dictionary))
        return;
      if (dictionary.ContainsKey("name"))
        SocialManager.Instance.BindingName = dictionary["name"].ToString();
      if (!SocialManager.Instance.BindingName.Equals("null"))
        return;
      SocialManager.Instance.BindingName = string.Empty;
    }
    catch (Exception ex)
    {
      SocialManager.Instance.BindingName = string.Empty;
      Debug.Log((object) ex.StackTrace);
    }
  }

  public void SetBindingName(string pName)
  {
    try
    {
      SocialManager.Instance.BindingName = pName;
      if (!SocialManager.Instance.BindingName.Equals("null"))
        return;
      SocialManager.Instance.BindingName = string.Empty;
    }
    catch (Exception ex)
    {
      SocialManager.Instance.BindingName = string.Empty;
      Debug.Log((object) ex.StackTrace);
    }
  }
}
