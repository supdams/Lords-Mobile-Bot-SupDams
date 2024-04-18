// Decompiled with JetBrains decompiler
// Type: AntiAddictive
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
internal class AntiAddictive
{
  private const long TimeStage1 = 3600;
  private const long TimeStage2 = 7200;
  private const long TimeStage3 = 9000;
  private const long TimeStage4 = 10500;
  private const long TimeStage5 = 10800;
  private const float CheckPetSecond = 1f;
  private string AntiAddictiveSatge = "AntiAddictiveStage";
  private string AntiAddictiveDate = nameof (AntiAddictiveDate);
  private static AntiAddictive instance;
  private float m_tickTime = 1f;
  private bool bInit;
  private byte m_AntiAddictiveSwitch;
  private byte m_RestrictLoginSwitch;
  private byte m_FinalRepeat;
  private NotificationStage m_AnitAddicitvDlgStage;
  private RealNameState m_RealNameState = RealNameState.UnAuthorized;
  private AgeState m_AgeState = AgeState.Nonage;
  private long m_CumulativeTime;
  public NotificationStage m_SaveStage;
  private DateTime m_Data;
  private long m_CrossDaysSecond;
  private byte m_StackCount;
  private byte[] m_DlgStack;
  private CString m_CStr;
  private static string str;

  private AntiAddictive()
  {
    this.bInit = false;
    this.m_AntiAddictiveSwitch = (byte) 0;
    this.m_RestrictLoginSwitch = (byte) 0;
    this.m_FinalRepeat = (byte) 0;
    this.m_CrossDaysSecond = 0L;
    this.m_AnitAddicitvDlgStage = NotificationStage.None;
    this.m_DlgStack = new byte[6];
    this.m_StackCount = (byte) 0;
    Array.Clear((Array) this.m_DlgStack, 0, this.m_DlgStack.Length);
    if (this.m_CStr == null)
      this.m_CStr = StringManager.Instance.SpawnString(200);
    try
    {
      byte result = 0;
      byte.TryParse(PlayerPrefs.GetString(this.AntiAddictiveSatge), out result);
      if ((new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) - Convert.ToDateTime(PlayerPrefs.GetString(this.AntiAddictiveDate))).Days <= 0)
        this.m_SaveStage = (NotificationStage) result;
      else
        this.m_SaveStage = NotificationStage.None;
    }
    catch (Exception ex)
    {
      this.m_SaveStage = NotificationStage.None;
      Debug.Log((object) "AntiAddictive() Exception");
    }
  }

  public static AntiAddictive Instance
  {
    get
    {
      if (AntiAddictive.instance == null)
        AntiAddictive.instance = new AntiAddictive();
      return AntiAddictive.instance;
    }
  }

  public void Start(
    byte AddictiveSwitch,
    byte RestrictLoginSwitch,
    RealNameState realNameState,
    AgeState ageState)
  {
    this.m_RealNameState = realNameState;
    this.m_AgeState = ageState;
    this.GetStage();
    this.SetCrossDaysSecond();
    this.SetFinalRepeat();
    this.bInit = true;
  }

  public void SetCumulativeTime(long time)
  {
    this.m_CumulativeTime = time;
    this.bInit = true;
  }

  public void Restart()
  {
    this.m_FinalRepeat = (byte) 0;
    this.m_CumulativeTime = 0L;
    this.SetCrossDaysSecond();
    this.SaveStage(NotificationStage.None);
    this.SetFinalRepeat();
    if (this.m_AnitAddicitvDlgStage == NotificationStage.None)
      return;
    GUIManager.Instance.CloseAntiAddictiveMessageBox();
  }

  public void Update()
  {
    if (!this.bInit || !NetworkManager.Connected() || this.m_AntiAddictiveSwitch != (byte) 1 || this.m_AgeState != AgeState.Nonage)
      return;
    this.m_tickTime += Time.unscaledDeltaTime;
    if ((double) this.m_tickTime < 1.0)
      return;
    if ((double) this.m_CrossDaysSecond >= 1.0)
    {
      ++this.m_CumulativeTime;
      --this.m_tickTime;
      --this.m_CrossDaysSecond;
      if (this.m_RestrictLoginSwitch == (byte) 1 && !this.CheckRestrictLoginStage())
        this.CheckNotificationStage();
      if (this.m_StackCount <= (byte) 0 || !this.CheckDlgStack())
        return;
      this.ClearDlgStack();
    }
    else
      this.Restart();
  }

  public void SetAnitAddicitvDlgStage(NotificationStage stage)
  {
    this.m_AnitAddicitvDlgStage = stage;
  }

  public NotificationStage GetAnitAddicitvDlgStage() => this.m_AnitAddicitvDlgStage;

  private void CheckNotificationStage()
  {
    if (this.m_CumulativeTime >= 9000L && this.m_SaveStage < NotificationStage.Stage3)
      this.OpeenNotificationDlg(NotificationStage.Stage3);
    else if (this.m_CumulativeTime >= 7200L && this.m_SaveStage < NotificationStage.Stage2)
    {
      this.OpeenNotificationDlg(NotificationStage.Stage2);
    }
    else
    {
      if (this.m_CumulativeTime < 3600L || this.m_SaveStage >= NotificationStage.Stage1)
        return;
      this.OpeenNotificationDlg(NotificationStage.Stage1);
    }
  }

  private bool CheckRestrictLoginStage()
  {
    bool flag = false;
    if (this.m_CumulativeTime >= 10800L && (this.m_SaveStage < NotificationStage.Stage5 || this.m_FinalRepeat == (byte) 1 && !RealNameHelp.Instance.IsbDlgOpening()))
    {
      this.OpeenNotificationDlg(NotificationStage.Stage5);
      flag = true;
    }
    else if (this.m_CumulativeTime >= 10500L && (this.m_SaveStage < NotificationStage.Stage4 || this.m_FinalRepeat == (byte) 1 && !RealNameHelp.Instance.IsbDlgOpening()))
    {
      this.OpeenNotificationDlg(NotificationStage.Stage4);
      flag = true;
    }
    return flag;
  }

  private bool CheckDlgStack()
  {
    if (this.GetDlgStack(NotificationStage.Stage3))
      return this.OpeenNotificationDlg(NotificationStage.Stage3);
    if (this.GetDlgStack(NotificationStage.Stage2))
      return this.OpeenNotificationDlg(NotificationStage.Stage2);
    return this.GetDlgStack(NotificationStage.Stage1) && this.OpeenNotificationDlg(NotificationStage.Stage1);
  }

  private bool OpeenNotificationDlg(NotificationStage stage)
  {
    bool flag1 = false;
    bool bShowCloseBtn1 = true;
    bool flag2 = BattleController.IsGambleMode || BattleController.IsActive || WarManager.IsActive;
    this.m_CStr.ClearString();
    switch (stage)
    {
      case NotificationStage.Stage1:
        if (!flag2)
        {
          if (this.m_RealNameState != RealNameState.Authorized)
          {
            bool bShowRealNameBtn = true;
            this.m_CStr.IntToFormat(1L);
            this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10140U));
            GUIManager.Instance.CloseAntiAddictiveMessageBox();
            GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147U), this.m_CStr.ToString(), (string) null, bShowRealNameBtn, bShowCloseBtn1, 21, 0);
          }
          else if (this.m_RealNameState == RealNameState.Authorized)
          {
            bool bShowRealNameBtn = false;
            this.m_CStr.IntToFormat(1L);
            this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10141U));
            GUIManager.Instance.CloseAntiAddictiveMessageBox();
            GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147U), this.m_CStr.ToString(), (string) null, bShowRealNameBtn, bShowCloseBtn1, 21, 0);
          }
          flag1 = true;
          this.SaveStage(NotificationStage.Stage1);
          break;
        }
        this.SetDlgStack(NotificationStage.Stage1, true);
        break;
      case NotificationStage.Stage2:
        if (!flag2)
        {
          if (this.m_RealNameState != RealNameState.Authorized)
          {
            bool bShowRealNameBtn = true;
            this.m_CStr.IntToFormat(2L);
            this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10140U));
            GUIManager.Instance.CloseAntiAddictiveMessageBox();
            GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147U), this.m_CStr.ToString(), (string) null, bShowRealNameBtn, bShowCloseBtn1, 21, 0);
          }
          else if (this.m_RealNameState == RealNameState.Authorized)
          {
            bool bShowRealNameBtn = false;
            this.m_CStr.IntToFormat(2L);
            this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10141U));
            GUIManager.Instance.CloseAntiAddictiveMessageBox();
            GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147U), this.m_CStr.ToString(), (string) null, bShowRealNameBtn, bShowCloseBtn1, 21, 0);
          }
          flag1 = true;
          this.SaveStage(NotificationStage.Stage2);
          break;
        }
        this.SetDlgStack(NotificationStage.Stage2, true);
        break;
      case NotificationStage.Stage3:
        if (!flag2)
        {
          if (this.m_RealNameState != RealNameState.Authorized)
          {
            bool bShowRealNameBtn = true;
            this.m_CStr.FloatToFormat(2.5f);
            this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10140U));
            GUIManager.Instance.CloseAntiAddictiveMessageBox();
            GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147U), this.m_CStr.ToString(), (string) null, bShowRealNameBtn, bShowCloseBtn1, 21, 0);
          }
          else if (this.m_RealNameState == RealNameState.Authorized)
          {
            bool bShowRealNameBtn = false;
            this.m_CStr.FloatToFormat(2.5f);
            this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10141U));
            GUIManager.Instance.CloseAntiAddictiveMessageBox();
            GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147U), this.m_CStr.ToString(), (string) null, bShowRealNameBtn, bShowCloseBtn1, 21, 0);
          }
          flag1 = true;
          this.SaveStage(NotificationStage.Stage3);
          break;
        }
        this.SetDlgStack(NotificationStage.Stage3, true);
        break;
      case NotificationStage.Stage4:
        if (!flag2)
        {
          GUIManager.Instance.CloseAntiAddictiveMessageBox();
          long num1 = 0;
          if (10800L >= this.m_CumulativeTime)
          {
            long num2 = 10800L - this.m_CumulativeTime;
            num1 = num2 % 60L != 0L ? num2 / 60L + 1L : num2 / 60L;
          }
          long x = (long) Mathf.Clamp((float) num1, 1f, 5f);
          if (this.m_RealNameState != RealNameState.Authorized)
          {
            bool bShowRealNameBtn = true;
            this.m_CStr.IntToFormat(x);
            this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10142U));
            GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147U), this.m_CStr.ToString(), (string) null, bShowRealNameBtn, bShowCloseBtn1, 21, 0);
          }
          else if (this.m_RealNameState == RealNameState.Authorized)
          {
            bool bShowRealNameBtn = false;
            this.m_CStr.IntToFormat(x);
            this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10143U));
            GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147U), this.m_CStr.ToString(), (string) null, bShowRealNameBtn, bShowCloseBtn1, 21, 0);
          }
          this.m_FinalRepeat = (byte) 0;
          flag1 = true;
          this.SaveStage(NotificationStage.Stage4);
          break;
        }
        this.SetDlgStack(NotificationStage.Stage4, true);
        break;
      case NotificationStage.Stage5:
        bool bShowCloseBtn2 = false;
        GUIManager.Instance.CloseAntiAddictiveMessageBox();
        DateTime tomorrow = this.GetTomorrow();
        this.m_CStr.IntToFormat((long) tomorrow.Year);
        this.m_CStr.IntToFormat((long) tomorrow.Month);
        this.m_CStr.IntToFormat((long) tomorrow.Day);
        this.m_CStr.IntToFormat((long) tomorrow.Hour);
        if (this.m_RealNameState != RealNameState.Authorized)
        {
          bool bShowRealNameBtn = true;
          this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10144U));
          GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147U), this.m_CStr.ToString(), (string) null, bShowRealNameBtn, bShowCloseBtn2, 21, 0);
        }
        else
        {
          bool bShowRealNameBtn = false;
          this.m_CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10145U));
          GUIManager.Instance.OpenAntiAddictiveMessageBox(stage, DataManager.Instance.mStringTable.GetStringByID(10147U), this.m_CStr.ToString(), (string) null, bShowRealNameBtn, bShowCloseBtn2, 21, 0);
        }
        this.m_FinalRepeat = (byte) 0;
        flag1 = true;
        this.SaveStage(NotificationStage.Stage5);
        break;
    }
    return flag1;
  }

  private void SaveStage(NotificationStage stage)
  {
    if (stage < NotificationStage.None)
      return;
    if (stage > NotificationStage.Stage5)
      return;
    try
    {
      long userId = DataManager.Instance.RoleAttr.UserId;
      this.m_SaveStage = stage;
      this.m_Data = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
      PlayerPrefs.SetInt(this.AntiAddictiveSatge + (object) userId, (int) this.m_SaveStage);
      PlayerPrefs.SetString(this.AntiAddictiveDate + (object) userId, this.m_Data.ToString());
    }
    catch (Exception ex)
    {
      Debug.Log((object) "AntiAddictive SaveStage Exception");
    }
  }

  private void GetStage()
  {
    try
    {
      long userId = DataManager.Instance.RoleAttr.UserId;
      string str = PlayerPrefs.GetString(this.AntiAddictiveDate + (object) userId);
      this.m_Data = str == null || !(str != string.Empty) ? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day) : Convert.ToDateTime(str);
      if ((this.m_Data - new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)).Days > 0)
        this.m_SaveStage = NotificationStage.None;
      else
        this.m_SaveStage = (NotificationStage) Mathf.Clamp(PlayerPrefs.GetInt(this.AntiAddictiveSatge + (object) userId), 0, 5);
    }
    catch (Exception ex)
    {
      Debug.Log((object) "AntiAddictive GetStage Exception");
    }
  }

  private void SetDlgStack(NotificationStage stage, bool enable)
  {
    if (stage >= (NotificationStage) this.m_DlgStack.Length || stage <= NotificationStage.None)
      return;
    if (enable)
    {
      if (this.m_DlgStack[(int) stage] == (byte) 1)
        return;
      this.m_DlgStack[(int) stage] = (byte) 1;
      ++this.m_StackCount;
    }
    else
    {
      if (this.m_DlgStack[(int) stage] == (byte) 0)
        return;
      this.m_DlgStack[(int) stage] = (byte) 0;
      --this.m_StackCount;
    }
  }

  private bool GetDlgStack(NotificationStage stage)
  {
    return stage < (NotificationStage) this.m_DlgStack.Length && stage > NotificationStage.None && this.m_DlgStack[(int) stage] == (byte) 1;
  }

  private void ClearDlgStack()
  {
    this.m_StackCount = (byte) 0;
    Array.Clear((Array) this.m_DlgStack, 0, this.m_DlgStack.Length);
  }

  private void SetCrossDaysSecond()
  {
    try
    {
      DateTime dateTime = DateTime.UtcNow.AddHours(8.0);
      this.m_CrossDaysSecond = (long) (new DateTime(dateTime.Year, dateTime.Month, dateTime.Day).AddDays(1.0) - dateTime).TotalSeconds;
    }
    catch (Exception ex)
    {
      this.m_CrossDaysSecond = 86400L;
      Debug.Log((object) ("SetCrossDaysSecond  Exception " + ex.ToString()));
    }
  }

  private DateTime GetTomorrow()
  {
    try
    {
      return new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).AddDays(1.0);
    }
    catch (Exception ex)
    {
      return new DateTime();
    }
  }

  public void SetFinalRepeat()
  {
    if (this.m_CumulativeTime >= 10500L)
      this.m_FinalRepeat = (byte) 1;
    else
      this.m_FinalRepeat = (byte) 0;
  }

  ~AntiAddictive()
  {
    if (this.m_CStr == null)
      return;
    StringManager.Instance.DeSpawnString(this.m_CStr);
    this.m_CStr = (CString) null;
  }

  public string GetDebugStr()
  {
    AntiAddictive.str = string.Empty;
    AntiAddictive.str = AntiAddictive.str + "[" + (object) 3600L + "," + (object) 7200L + "," + (object) 9000L + "," + (object) 10500L + "," + (object) 10800L + "]\n";
    AntiAddictive.str = AntiAddictive.str + "日期 = " + this.m_Data.ToShortDateString() + "\n";
    AntiAddictive.str = AntiAddictive.str + "重置秒數 = " + (object) this.m_CrossDaysSecond + "\n";
    AntiAddictive.str = AntiAddictive.str + "DeltaTime = " + (object) Time.unscaledDeltaTime + "\n";
    AntiAddictive.str = AntiAddictive.str + "實名認證開關 = " + (object) IGGGameSDK.Instance.GetRealNameSW() + "\n";
    AntiAddictive.str = AntiAddictive.str + "購買限制金額 = " + (object) IGGGameSDK.Instance.GetMinorsDailySpendAmount() + "\n";
    AntiAddictive.str = AntiAddictive.str + "防沉迷提醒開關 = " + (object) this.m_AntiAddictiveSwitch + "\n";
    AntiAddictive.str = AntiAddictive.str + "限制登入開關 = " + (object) this.m_RestrictLoginSwitch + "\n";
    AntiAddictive.str = AntiAddictive.str + "累加上線時間 = " + (object) this.m_CumulativeTime + "\n";
    AntiAddictive.str = AntiAddictive.str + "階段 = " + (object) this.m_SaveStage + "\n";
    AntiAddictive.str = AntiAddictive.str + "堆疊數量 = " + (object) this.m_StackCount + "\n";
    AntiAddictive.str = AntiAddictive.str + "開啟對話視窗類型 = " + (object) this.m_AnitAddicitvDlgStage + "\n";
    AntiAddictive.str = AntiAddictive.str + "是否成年 = " + (object) this.m_AgeState + "\n";
    AntiAddictive.str = AntiAddictive.str + "是否實名認證 = " + (object) this.m_RealNameState + "\n";
    return AntiAddictive.str;
  }

  public void ClearSave() => PlayerPrefs.DeleteAll();

  public void SetNameType(RealNameState nameState) => this.m_RealNameState = nameState;

  public void SetAgeType(AgeState ageState) => this.m_AgeState = ageState;

  public bool IsNonage() => this.m_AgeState == AgeState.Nonage;
}
