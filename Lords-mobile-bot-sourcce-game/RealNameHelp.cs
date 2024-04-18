// Decompiled with JetBrains decompiler
// Type: RealNameHelp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
internal class RealNameHelp
{
  private const int MaxRepeatCount = 3;
  private const float CheckPetSecond = 15f;
  private const float testTime = 3f;
  private static RealNameHelp instance;
  private RealNameState m_State;
  private RealNameState m_PreState;
  private RealNameHelp.UpdateCheckState m_UpdateCheckState;
  private bool bIsDlgOpening;
  private float m_tickTime = 15f;
  private int m_NowRepeatCont;
  private bool bFromQuitGameDlg;
  private float testTick;
  private int bBeginTest;
  private RealNameState testState;

  private RealNameHelp()
  {
    this.m_State = RealNameState.None;
    this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.None;
    this.m_NowRepeatCont = 0;
    this.bFromQuitGameDlg = false;
    this.bIsDlgOpening = false;
  }

  public static RealNameHelp Instance
  {
    get
    {
      if (RealNameHelp.instance == null)
        RealNameHelp.instance = new RealNameHelp();
      return RealNameHelp.instance;
    }
  }

  public void SetRealNameState(RealNameState state) => this.m_State = state;

  public bool CheckOpenRealNameDlg()
  {
    if (this.m_State == RealNameState.Authorized)
      return false;
    this.OpenAuthenticateDlg(RealNameState.None);
    return true;
  }

  public void OpenAuthenticateDlg(RealNameState state)
  {
    GUIManager.Instance.OpenRealNameMessageBox(RealNameState.None);
  }

  public void OpenRealNameByWebView()
  {
    if (!IGGGameSDK.Instance.MaintanceData.RealNameCheck.Equals("0"))
      IGGSDKPlugin.OpenRealNameUrlByWebView(IGGGameSDK.Instance.MaintanceData.RealNameCheck);
    else
      IGGSDKPlugin.OpenRealNameUrlByWebView("2");
    this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.CheckRealNameState;
  }

  public void OpenQuitGameRealNameByWebView()
  {
    if (!IGGGameSDK.Instance.MaintanceData.RealNameCheck.Equals("0"))
      IGGSDKPlugin.OpenRealNameUrlByWebView(IGGGameSDK.Instance.MaintanceData.RealNameCheck);
    else
      IGGSDKPlugin.OpenRealNameUrlByWebView("2");
    this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.CheckRealNameState;
    this.bFromQuitGameDlg = true;
    this.m_NowRepeatCont = 0;
  }

  public void OpenRealNameAsyncByWebView()
  {
    IGGSDKPlugin.OpenRealNameUrlByWebView("2");
    this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.CheckRealNameState;
    this.m_NowRepeatCont = 0;
  }

  public void CheckRealNameState()
  {
    IGGSDKPlugin.CheckRealNameState();
    this.m_PreState = this.m_State;
  }

  public void CheckRealNameCallBack(RealNameState state)
  {
    this.m_State = state;
    if (this.m_UpdateCheckState == RealNameHelp.UpdateCheckState.UpdateCheckLoopWaitResult)
    {
      if (this.m_State == RealNameState.Authorized)
      {
        if (this.bIsDlgOpening)
        {
          GUIManager.Instance.CloseOKCancelBox();
          this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.None;
          this.bIsDlgOpening = false;
        }
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14578U), (ushort) byte.MaxValue);
        this.m_NowRepeatCont = 0;
        if (AntiAddictive.Instance.m_SaveStage != NotificationStage.Stage5)
          return;
        this.CheckFromQuitGameDlgFlag();
      }
      else if (this.m_NowRepeatCont == 0)
      {
        if (this.bIsDlgOpening)
        {
          GUIManager.Instance.CloseOKCancelBox();
          this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.None;
          this.bIsDlgOpening = false;
        }
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14579U), (ushort) byte.MaxValue);
        this.m_NowRepeatCont = 0;
        if (AntiAddictive.Instance.m_SaveStage != NotificationStage.Stage5)
          return;
        this.CheckFromQuitGameDlgFlag();
      }
      else
        this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.UpdateCheckLoop;
    }
    else
    {
      if (this.m_UpdateCheckState != RealNameHelp.UpdateCheckState.WaitResult)
        return;
      if (this.m_State == RealNameState.Sumbitted)
      {
        this.OpenSumbittedDlg();
        this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.UpdateCheckLoop;
        this.m_NowRepeatCont = 3;
        this.m_tickTime = 15f;
      }
      else if (this.m_State == RealNameState.Authorized)
      {
        this.OpenAuthorizedDlg();
        this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.Result;
      }
      else
      {
        if (this.m_State != RealNameState.UnAuthorized)
          return;
        this.OpenUnAuthorizedDlg();
        this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.Result;
      }
    }
  }

  public void OpenSumbittedDlg()
  {
    this.bIsDlgOpening = true;
    GUIManager.Instance.CloseOKCancelBox();
    GUIManager.Instance.OpenRealNameMessageBox(RealNameState.Sumbitted);
  }

  public void OpenUnAuthorizedDlg()
  {
    this.bIsDlgOpening = true;
    GUIManager.Instance.CloseOKCancelBox();
    GUIManager.Instance.OpenRealNameMessageBox(RealNameState.UnAuthorized);
  }

  public void OpenAuthorizedDlg()
  {
    this.bIsDlgOpening = true;
    GUIManager.Instance.CloseOKCancelBox();
    GUIManager.Instance.OpenRealNameMessageBox(RealNameState.Authorized);
  }

  public bool IsbDlgOpening() => this.bIsDlgOpening;

  public void Update()
  {
    if (this.m_UpdateCheckState == RealNameHelp.UpdateCheckState.CheckRealNameState)
    {
      this.CheckRealNameState();
      this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.WaitResult;
    }
    else
    {
      if (this.m_UpdateCheckState != RealNameHelp.UpdateCheckState.UpdateCheckLoop || this.m_NowRepeatCont <= 0)
        return;
      this.m_tickTime += Time.deltaTime;
      if ((double) this.m_tickTime < 15.0)
        return;
      this.m_tickTime -= 15f;
      this.CheckRealNameState();
      this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.UpdateCheckLoopWaitResult;
      --this.m_NowRepeatCont;
    }
  }

  public bool IsUpdateCheckState() => this.m_UpdateCheckState != RealNameHelp.UpdateCheckState.None;

  public void ClearUpdateCheckState()
  {
    if (this.m_UpdateCheckState != RealNameHelp.UpdateCheckState.UpdateCheckLoop)
      this.m_UpdateCheckState = RealNameHelp.UpdateCheckState.None;
    this.bIsDlgOpening = false;
  }

  public void CheckFromQuitGameDlgFlag()
  {
    if (!this.bFromQuitGameDlg)
      return;
    AntiAddictive.Instance.SetFinalRepeat();
    this.bFromQuitGameDlg = false;
  }

  ~RealNameHelp()
  {
  }

  private enum UpdateCheckState
  {
    None,
    CheckRealNameState,
    WaitResult,
    Result,
    UpdateCheckLoop,
    UpdateCheckLoopWaitResult,
    UpdateCheckLoopResult,
  }
}
