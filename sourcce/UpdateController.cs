// Decompiled with JetBrains decompiler
// Type: UpdateController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UpdateController : Gameplay, IUIButtonClickHandler
{
  public static bool InitialInstall;
  public static bool UpdateCritical;
  public static byte UpdateFallback;
  public static byte UserLanguageId;
  public static byte StageController;
  public static float CheckController;
  public static string MessageReturner;
  public static UpdateController.WebClient UpdatePuller;
  public static UpdateController Updater;
  private SevenZip.Compression.LZMA.Decoder coder = new SevenZip.Compression.LZMA.Decoder();
  private StringBuilder Path = new StringBuilder();
  private string OSPath = string.Empty;
  private string Prefix = string.Empty;
  private string CDNRoot;
  private string[] RoyalHost;
  private string[] AssList;
  private Coroutine Router;
  private GameObject GSpot;
  private GameObject Loader;
  private GameObject Player;
  private GameObject Server;
  private GameObject Starter;
  private GameObject Chatter;
  private GameManager GameMan;
  private RectTransform Runner;
  private AssetBundle Initiator;
  private bool RequestDirector;
  private float Buffer;
  private float Terminator;
  private UnityEngine.UI.Text Booster;
  private UnityEngine.UI.Text Teller;
  private UnityEngine.UI.Text Hint;
  private bool Failure;
  private bool BufferUnderrun;
  private bool NoStringAttached;
  private bool Reload;
  private byte[] Properties = new byte[8];
  private Dictionary<string, long> AssSheet;
  private UIButton Selection;
  private uint Extraction;
  private ushort Patching;
  private string UAV;
  private string AV;
  private string Status;
  private WWW bundle;

  public UpdateController(GameManager Gm)
  {
    UpdateController.Updater = this;
    DownloadController.Init(this.GameMan = Gm);
    UpdateController.CheckController = NetworkManager.RealTime;
    AssetManager.Instance.AssetManagerState = AssetState.Ready;
    Directory.CreateDirectory(AssetManager.persistentDataPath + "/Scene");
    Directory.CreateDirectory(AssetManager.persistentDataPath + "/Store");
    Directory.CreateDirectory(AssetManager.persistentDataPath + "/Role");
    Directory.CreateDirectory(AssetManager.persistentDataPath + "/Data");
    Directory.CreateDirectory(AssetManager.persistentDataPath + "/Loading");
    Directory.CreateDirectory(AssetManager.persistentDataPath + "/Particle");
    Directory.CreateDirectory(AssetManager.persistentDataPath + "/Sound");
    Directory.CreateDirectory(AssetManager.persistentDataPath + "/Music");
    Directory.CreateDirectory(AssetManager.persistentDataPath + "/Misc");
    Directory.CreateDirectory(AssetManager.persistentDataPath + "/UI");
  }

  ~UpdateController()
  {
  }

  protected override void UpdateNews(byte[] meg)
  {
    if (meg[0] == (byte) 0 && meg[1] == (byte) 35)
    {
      this.RefreshFontRebuilt();
    }
    else
    {
      if (meg[0] != (byte) 1)
        return;
      if (meg[1] == (byte) 27)
      {
        this.OnUpdateFail(meg[2]);
      }
      else
      {
        if (meg[1] != (byte) 28)
          return;
        this.LoadIGGData();
      }
    }
  }

  protected override void UpdateRun(byte[] meg)
  {
    if (!(bool) (UnityEngine.Object) this.GSpot)
      return;
    if ((double) NetworkManager.Instance.CheckTime > 0.0)
      this.Loading(0.4f * Time.deltaTime);
    if (IGGGameSDK.Instance.IGGIdIsReady)
      this.OnIGGReady();
    if (UpdateController.UpdatePuller != null && (UnityEngine.Object) this.Runner != (UnityEngine.Object) null)
    {
      this.Runner.sizeDelta = new Vector2(376f * UpdateController.WebClient.Progressing, this.Runner.sizeDelta.y);
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(99U));
      cstring.FloatToFormat((float) ((1.0 - (double) UpdateController.WebClient.Progressing) * 100.0), 1);
      cstring.AppendFormat("{0} {1}%");
      this.Booster.text = cstring.ToString();
    }
    if (!UpdateController.WebClient.Processed)
      return;
    UpdateController.DownloadReset();
    try
    {
      if (UpdateController.WebClient.FileLength == 0L && !UpdateController.WebClient.FileError)
      {
        using (UpdateController.UpdatePuller = new UpdateController.WebClient())
        {
          UpdateController.UpdatePuller.OpenRead(UpdateController.WebClient.Url);
          UpdateController.WebClient.FileLength = Convert.ToInt64(UpdateController.UpdatePuller.ResponseHeaders["Content-Length"]);
          UpdateController.UpdatePuller.Close();
          UpdateController.UpdatePuller = (UpdateController.WebClient) null;
        }
      }
      FileInfo fileInfo = new FileInfo(AssetManager.persistentDataPath + (object) System.IO.Path.AltDirectorySeparatorChar + "Download.apk");
      UpdateController.WebClient.FileError = !fileInfo.Exists || fileInfo.Length == 0L || fileInfo.Length != UpdateController.WebClient.FileLength || UpdateController.WebClient.FileError;
      if (!UpdateController.WebClient.FileError)
      {
        using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
          AndroidJavaObject androidJavaObject1 = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
          AndroidJavaObject androidJavaObject2 = new AndroidJavaObject("android.content.Intent", new object[1]
          {
            (object) "android.intent.action.VIEW"
          });
          AndroidJavaObject androidJavaObject3 = new AndroidJavaClass("android.net.Uri").CallStatic<AndroidJavaObject>("fromFile", (object) new AndroidJavaObject("java.io.File", new object[1]
          {
            (object) fileInfo.FullName
          }));
          androidJavaObject2.Call<AndroidJavaObject>("setDataAndType", (object) androidJavaObject3, (object) "application/vnd.android.package-archive").Call<AndroidJavaObject>("addFlags", (object) 268500992);
          androidJavaObject1.Call("startActivity", (object) androidJavaObject2);
        }
      }
    }
    catch (Exception ex)
    {
      UpdateController.WebClient.FileError = true;
      UpdateController.DownloadReset();
    }
    NetworkManager.LetmeIn(DataManager.Instance.mStringTable.GetStringByID(!UpdateController.WebClient.FileError ? 99U : 8474U), (byte) 0);
    UpdateController.WebClient.Processed = false;
  }

  protected override void UpdateNext(byte[] meg)
  {
    UpdateController.Updater = (UpdateController) null;
    this.ClearUpdateDelegates();
    DownloadController.Reset();
    DownloadController.Refresh();
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Loader);
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Player);
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Chatter);
    UnityEngine.Object.Destroy((UnityEngine.Object) Camera.main.GetComponent<GUILayer>());
  }

  protected override void UpdateLoad(byte[] meg)
  {
    GameManager.RegisterObserver((byte) 1, (byte) 0, (IObserver) this);
    AssetManager.UnloadAsses();
    GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Update);
    GUIManager.Instance.m_UICanvas.renderMode = (RenderMode) 1;
    GUIManager.Instance.SetCameraorthOgraphic(true);
    AssetManager.Instance.AssetManagerState = AssetState.Ready;
    NetworkManager.Instance.SetStage(LoginPhase.LP_Pending, 0L);
    this.GameMan.gameObject.AddComponent<ImmersiveModeEnabler>();
  }

  protected override void UpdateReady(byte[] meg)
  {
    this.Router = this.GameMan.StartCoroutine(this.LoadStreamAssToPersistent());
  }

  public static void ReturnToBase()
  {
    if (UpdateController.Updater != null)
      return;
    GameManager.SwitchGameplay(GameplayKind.Update);
  }

  [DebuggerHidden]
  private IEnumerator LoadStreamAssToPersistent()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UpdateController.\u003CLoadStreamAssToPersistent\u003Ec__Iterator4()
    {
      \u003C\u003Ef__this = this
    };
  }

  public void OnGameLogin()
  {
    this.Loader.SetActive(true);
    this.Server.SetActive(false);
    this.Starter.GetComponent<InputField>().text = this.Prefix;
  }

  public void OnUpdateFail(byte Fatal)
  {
    this.bundle = (WWW) null;
    if (Fatal <= (byte) 0)
      return;
    this.Failure = false;
    this.GameMan.StopAllCoroutines();
    if (DataManager.Instance.mStringTable == null)
    {
      this.Path.Length = 0;
      DataManager.Instance.mStringTable = new StringTable();
      UpdateController.UserLanguageId = DataManager.Instance.UserLanguage < GameLanguage.GL_Eng || DataManager.Instance.UserLanguage >= GameLanguage.GL_MAX ? (byte) 1 : (byte) DataManager.Instance.UserLanguage;
      if (!System.IO.File.Exists(this.Path.AppendFormat("{0}/{1}/{2}.unity3d", (object) AssetManager.persistentDataPath, (object) "Loading", (object) AssetManager.StringAsset[(int) UpdateController.UserLanguageId - 1]).ToString()) || !DataManager.Instance.mStringTable.LoadStringTable("Loading/" + AssetManager.StringAsset[(int) UpdateController.UserLanguageId - 1], true))
        DataManager.Instance.mStringTable.LoadStringTable();
    }
    this.Path.Length = 0;
    this.Teller.text = (int) this.Patching <= (int) GameConstants.Version[2] ? this.Path.AppendFormat("v{0}.{1}", (object) GameConstants.Version[0], (object) GameConstants.Version[1]).ToString() : this.Path.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7049U), (object) GameConstants.Version[0], (object) GameConstants.Version[1], (object) this.Patching).ToString();
    GUIManager.Instance.InitialMessageBox();
    GUIManager.Instance.LoadFont();
  }

  public static void BuildStreamAssData(bool Rebuild = false)
  {
    new UpdateController((GameManager) null).Initialing(Rebuild);
  }

  public void RefreshFontRebuilt()
  {
    if ((bool) (UnityEngine.Object) this.Chatter)
    {
      ((Behaviour) this.Chatter.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>()).enabled = false;
      ((Behaviour) this.Chatter.transform.GetChild(1).GetComponent<UnityEngine.UI.Text>()).enabled = true;
    }
    if ((bool) (UnityEngine.Object) this.Booster)
    {
      ((Behaviour) this.Booster).enabled = false;
      ((Behaviour) this.Booster).enabled = true;
    }
    if ((bool) (UnityEngine.Object) this.Teller)
    {
      ((Behaviour) this.Teller).enabled = false;
      ((Behaviour) this.Teller).enabled = true;
    }
    if (!(bool) (UnityEngine.Object) this.Hint)
      return;
    ((Behaviour) this.Hint).enabled = false;
    ((Behaviour) this.Hint).enabled = true;
  }

  public void OnIGGReady()
  {
    if (this.Chatter.activeSelf)
      return;
    this.Chatter.SetActive(true);
  }

  public static void OnIGGLogin(bool Force = false)
  {
    NetworkManager.Instance.SetStage(LoginPhase.LP_Auto, 0L);
    if (Force)
    {
      IGGSDKPlugin.GeustLogin();
    }
    else
    {
      if (!NetworkManager.OnReady())
        return;
      if (IGGGameSDK.Instance.IGGIdIsReady && !UpdateController.WebClient.FileError)
        IGGGameSDK.Instance.CanLogIn();
      else
        IGGSDKPlugin.AutoLogin();
    }
  }

  public static bool OnIGGLogin(IGGLoginCode Code)
  {
    if (UpdateController.UpdateCritical || UpdateController.StageController < (byte) 3)
      return !UpdateController.UpdateCritical;
    if (Code == IGGLoginCode.IggReady)
      IGGGameSDK.Instance.CanLogIn();
    else if (Code < IGGLoginCode.Paranormal || Code == IGGLoginCode.None)
      NetworkManager.Instance.SetStage(LoginPhase.LP_KissAss, Code <= IGGLoginCode.None ? 104L : (long) Code, true);
    else
      NetworkManager.Instance.SetStage(LoginPhase.LP_GG, (long) Code, true);
    return false;
  }

  public static bool OnIGGLoginBBS()
  {
    NetworkManager.Instance.SetStage(LoginPhase.LP_BBS, 0L);
    return !UpdateController.UpdateCritical;
  }

  public static void OnIGGLoginBind() => NetworkManager.Instance.SetStage(LoginPhase.LP_Fail, 0L);

  public static void OnIGGLoginFail() => NetworkManager.Instance.SetStage(LoginPhase.LP_GG, 119L);

  public static void OnFail(bool Fatal = true)
  {
    if (UpdateController.UpdateCritical)
      return;
    UpdateController.UpdateCritical = Fatal;
    NetworkManager.Instance.SetStage(LoginPhase.LP_EpicFail, 1L, true);
    NetworkManager.Instance.SetStage(LoginPhase.LP_KissAss, 826L, Fatal);
  }

  public static void OnExit(uint Unknown, bool Fatal = true)
  {
    if (UpdateController.UpdateCritical)
      return;
    UpdateController.UpdateCritical = Fatal;
    NetworkManager.Instance.SetStage(LoginPhase.LP_KissAss, (long) Unknown, Fatal);
  }

  public static void OnExit(string Uknowhy, bool Fatal = true)
  {
    if (UpdateController.UpdateCritical)
      return;
    UpdateController.MessageReturner = Uknowhy;
    NetworkManager.Instance.SetStage(LoginPhase.LP_KissAss, 0L, Fatal);
  }

  private void OnReady()
  {
    if (this.Reload)
      DataManager.LoadTableData();
    DataManager.MissionDataManager.AchievementMgr.Signin();
    AssetManager.Instance.LoadShader("Shader");
    GUIManager.Instance.InitialAssets();
    Camera.main.backgroundColor = Color.black;
    Resources.UnloadUnusedAssets();
    Shader.WarmupAllShaders();
    AudioManager.Instance.LoadSFXObj();
    GC.Collect();
    AssetManager.Instance.AssetManagerState = AssetState.Run;
    this.Runner.sizeDelta = new Vector2(378f, UpdateController.Updater.Runner.sizeDelta.y);
    this.Booster.text = DataManager.Instance.mStringTable.GetStringByID(38U);
  }

  private bool Inception()
  {
    if (PlayerPrefs.HasKey(nameof (Inception)))
      return true;
    this.Server.SetActive(true);
    this.Server.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.Teller = this.Server.transform.GetChild(0).gameObject.GetComponent<UnityEngine.UI.Text>();
    this.Teller.text = DataManager.Instance.mStringTable.GetStringByID(7096U);
    this.Teller.font = GUIManager.Instance.GetTTFFont();
    return false;
  }

  public void Loading(float value)
  {
    if ((bool) (UnityEngine.Object) this.Loader && (double) value > 0.0)
    {
      this.Loader.transform.localScale += Vector3.left * value;
      this.Runner.sizeDelta = new Vector2((float) (376.0 * (1.0 - (double) this.Loader.transform.localScale.magnitude / 2.0)), this.Runner.sizeDelta.y);
    }
    else if ((double) value != 0.0)
    {
      this.Loader = new GameObject("Loader");
      this.Loader.AddComponent<GUITexture>();
      this.Loader.guiTexture.color = Color.green;
      this.Loader.guiTexture.texture = (Texture) new Texture2D(1, 1);
      this.Loader.transform.localScale = new Vector3(0.0f, 0.0f, 0.1f);
      float num = Mathf.Max((float) Screen.height / 480f, 1f);
      this.Loader.AddComponent<GUIText>();
      this.Loader.guiText.fontSize = (int) (17.0 * (double) num);
      Camera.main.gameObject.AddComponent<GUILayer>();
      this.Runner.sizeDelta = new Vector2(376f, this.Runner.sizeDelta.y);
      UnityEngine.UI.Text booster = this.Booster;
      Font font1 = this.Loader.guiText.font;
      this.Hint.font = font1;
      Font font2 = font1;
      this.Teller.font = font2;
      Font font3 = font2;
      booster.font = font3;
      this.Loader.guiTexture.border = new RectOffset(Screen.width, 0, 0, 0);
      this.GSpot.transform.parent.parent.GetChild(2).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.GSpot.transform.parent.parent.GetChild(2).GetChild(1).GetComponent<UnityEngine.UI.Text>().font = this.Booster.font;
    }
    else
    {
      if (!(bool) (UnityEngine.Object) this.Loader)
        return;
      this.Loader.transform.localScale = new Vector3(0.0f, 0.0f, 0.1f);
      this.Runner.sizeDelta = new Vector2(376f, this.Runner.sizeDelta.y);
    }
  }

  private void PromptLogin()
  {
    this.Reload = false;
    ++UpdateController.StageController;
    AssetManager.SetAssetMap(0);
    GUIManager.Instance.LoadFont();
    GUIManager.Instance.CloseLoadingTalk();
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Loader);
    this.Loader = new GameObject("Logger");
    this.Server = this.GSpot.transform.parent.parent.GetChild(1).GetChild(0).gameObject;
    this.Loader.transform.SetParent(((UnityEngine.Component) GUIManager.Instance.m_WindowsTransform).transform, false);
    this.Loader.transform.localScale = this.Player.transform.localScale;
    UpdateController.OnIGGLogin();
  }

  public void OnButtonClick(UIButton Sender)
  {
    if (Sender.m_BtnID2 > 0)
      DataManager.AchievementMgr.OpenAchievementUI();
    else if (Sender.m_BtnID1 > 0)
    {
      if (DataManager.Instance.UserLanguage == GameLanguage.GL_Eng || DataManager.Instance.UserLanguage == GameLanguage.GL_Idn)
        IGGSDKPlugin.SupportLiveOnLogin_GlobalEdition((byte) DataManager.Instance.UserLanguage);
      else
        IGGSDKPlugin.SubmitQuestion();
    }
    else if ((bool) (UnityEngine.Object) this.Starter)
      this.OnGameLogin();
    else
      UpdateController.OnIGGLogin();
  }

  public static void CheckNewApk(string url)
  {
    if (url == null || url.Trim().Length == 0 || UpdateController.UpdatePuller != null)
      return;
    UpdateController.Updater.GSpot.SetActive(true);
    UpdateController.Updater.Hint.text = string.Empty;
    try
    {
      UpdateController.WebClient webClient = UpdateController.UpdatePuller = new UpdateController.WebClient();
      webClient.Clear();
      webClient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(UpdateController.AsyncCompletedEventHandler);
      webClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(UpdateController.DownloadProgressChangedEventHandler);
      webClient.DownloadFileAsync(new Uri(url), AssetManager.persistentDataPath + (object) System.IO.Path.AltDirectorySeparatorChar + "Download.apk", (object) null);
    }
    catch (Exception ex)
    {
      UpdateController.DownloadReset();
      UpdateController.WebClient.Processed = UpdateController.WebClient.FileError = true;
    }
  }

  public static void test()
  {
  }

  public static void AsyncCompletedEventHandler(object sender, AsyncCompletedEventArgs e)
  {
    if (e.Cancelled || e.Error != null)
    {
      ((System.ComponentModel.Component) sender).Dispose();
      UpdateController.WebClient.FileError = true;
    }
    UpdateController.WebClient.Processed = true;
  }

  public static void DownloadProgressChangedEventHandler(
    object sender,
    DownloadProgressChangedEventArgs e)
  {
    UpdateController.WebClient.Progressing = (float) (1.0 - (e.TotalBytesToReceive <= 0L ? 0.0 : (double) e.BytesReceived / (double) e.TotalBytesToReceive));
  }

  public static void DownloadReset(bool Clear = false)
  {
    if (UpdateController.UpdatePuller != null)
    {
      UpdateController.UpdatePuller.CancelAsync();
      UpdateController.UpdatePuller.Close();
      UpdateController.UpdatePuller = (UpdateController.WebClient) null;
    }
    if (!Clear)
      return;
    UpdateController.WebClient.FileError = false;
    UpdateController.WebClient.Url = (Uri) null;
  }

  public void SetPremature(string GString)
  {
    if ((bool) (UnityEngine.Object) this.Loader)
      this.Loader.guiText.text = GString;
    if ((bool) (UnityEngine.Object) this.Booster)
      this.Booster.text = GString;
    DataManager.Instance.mStringTable = new StringTable();
    DataManager.Instance.mStringTable.LoadStringTable();
    GameConstants.Version[2] = this.Patching;
    DownloadController.Reset();
    UpdateController.UpdateCritical = false;
    UpdateController.StageController = (byte) 123;
    Caching.CleanCache();
    this.Reload = true;
    this.OnReady();
  }

  private void Initialing(bool Force = false)
  {
    UpdateController.ReadStreamAssData();
    IEnumerator streamingAsset = this.ParseStreamingAsset(Force);
    do
      ;
    while (streamingAsset.MoveNext());
  }

  [DebuggerHidden]
  private IEnumerator LoadStreamTableData()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UpdateController.\u003CLoadStreamTableData\u003Ec__Iterator5()
    {
      \u003C\u003Ef__this = this
    };
  }

  private void LoadIGGData()
  {
    this.Loading(0.0f);
    GUIManager.Instance.UnloadMessageBox();
    this.GameMan.StartCoroutine(this.LoadStreamAssData());
  }

  [DebuggerHidden]
  private IEnumerator LoadStreamAssData()
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UpdateController.\u003CLoadStreamAssData\u003Ec__Iterator6()
    {
      \u003C\u003Ef__this = this
    };
  }

  [DebuggerHidden]
  private IEnumerator ParseStreamingAsset(bool clear)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UpdateController.\u003CParseStreamingAsset\u003Ec__Iterator7()
    {
      clear = clear,
      \u003C\u0024\u003Eclear = clear,
      \u003C\u003Ef__this = this
    };
  }

  public static void ReadStreamAssData()
  {
    StringBuilder stringBuilder = new StringBuilder();
    Directory.CreateDirectory(Application.streamingAssetsPath + "/Data");
    string str = "Android";
    string[] directories = Directory.GetDirectories(Application.streamingAssetsPath + str);
    using (StreamWriter streamWriter = new StreamWriter(Application.streamingAssetsPath + "/Data/Asset.plist"))
    {
      for (int index1 = 0; index1 < directories.Length; ++index1)
      {
        if (Directory.Exists(directories[index1]))
        {
          string[] files = Directory.GetFiles(directories[index1]);
          for (int index2 = 0; index2 < files.Length; ++index2)
          {
            AssetBundle fromFile;
            if (files[index2].Substring(files[index2].Length - 11).Equals("assetbundle") && (bool) (UnityEngine.Object) (fromFile = AssetBundle.CreateFromFile(files[index2])))
            {
              stringBuilder.Length = 0;
              if (DateTime.TryParse((fromFile.Load(System.IO.Path.GetFileNameWithoutExtension(files[index2]) + "crc") as TextAsset).text, out DateTime _))
                streamWriter.WriteLine(stringBuilder.AppendFormat("{0}/{1}/{2}", (object) files[index2].Substring(Application.streamingAssetsPath.Length + 1, files[index2].Length - 13 - Application.streamingAssetsPath.Length).Replace("iOS", string.Empty), (object) DateTime.Parse((fromFile.Load(System.IO.Path.GetFileNameWithoutExtension(files[index2]) + "crc") as TextAsset).text).Ticks).ToString(), (object) new FileInfo(files[index2]).Length);
              else
                streamWriter.WriteLine((object) stringBuilder.AppendFormat("{0}/{1}/{2}", (object) files[index2].Substring(Application.streamingAssetsPath.Length + str.Length + 1, files[index2].Length - 13 - Application.streamingAssetsPath.Length - str.Length).Replace("iOS", string.Empty), (object) (fromFile.Load(System.IO.Path.GetFileNameWithoutExtension(files[index2]) + "crc") as TextAsset).text, (object) new FileInfo(files[index2]).Length));
              fromFile.Unload(true);
            }
          }
        }
      }
    }
    System.IO.File.WriteAllText(Application.streamingAssetsPath + "/Data/Assetver", DateTime.UtcNow.Ticks.ToString());
    AssetManager.Instance.AssetManagerState = AssetState.Ready;
  }

  [DebuggerHidden]
  private IEnumerator LoadStreamAssToPersistent(
    string data,
    string path,
    string file,
    bool notify = true,
    int revision = 0,
    byte lang = 0,
    bool unpack = true)
  {
    // ISSUE: object of a compiler-generated type is created
    return (IEnumerator) new UpdateController.\u003CLoadStreamAssToPersistent\u003Ec__Iterator8()
    {
      unpack = unpack,
      path = path,
      lang = lang,
      file = file,
      data = data,
      revision = revision,
      notify = notify,
      \u003C\u0024\u003Eunpack = unpack,
      \u003C\u0024\u003Epath = path,
      \u003C\u0024\u003Elang = lang,
      \u003C\u0024\u003Efile = file,
      \u003C\u0024\u003Edata = data,
      \u003C\u0024\u003Erevision = revision,
      \u003C\u0024\u003Enotify = notify,
      \u003C\u003Ef__this = this
    };
  }

  public class WebClient : System.Net.WebClient
  {
    public static float Progressing;
    public static long FileResume;
    public static long FileLength;
    public static bool FileError;
    public static bool Processed;
    public static Uri Url;
    private WebRequest Request;

    protected override WebRequest GetWebRequest(Uri uri)
    {
      this.Request = base.GetWebRequest(UpdateController.WebClient.Url = uri);
      try
      {
        this.Request.Timeout = 15000;
      }
      catch (Exception ex)
      {
        UnityEngine.Debug.LogError((object) ex);
      }
      return this.Request;
    }

    public void Close()
    {
      if (this.Request != null)
        this.Request.Abort();
      this.Dispose();
    }

    public void Clear()
    {
      UpdateController.WebClient.Processed = UpdateController.WebClient.FileError = false;
      UpdateController.WebClient.FileResume = UpdateController.WebClient.FileLength = 0L;
      UpdateController.WebClient.Progressing = 1f;
    }
  }
}
