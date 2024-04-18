// Decompiled with JetBrains decompiler
// Type: GameManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class GameManager : MonoBehaviour
{
  private static GameManager gameManager;
  public static bool bQuitGame;
  public static Gameplay ActiveGameplay;
  private GameplayKind currentGameplay;
  private GameplayKind nextGameplay;
  private int[][] observerCounts;
  private IObserver[][][] observers;
  private GameManager.SceneState sceneState;
  private GameManager.UpdateDelegate[] updateDelegates;
  private GameManager.NotifyInfo[] notifyInfos;
  private byte notifyInfoStart;
  private byte notifyInfoCount;
  private GameManager.CheckNotifyDelegate[] checkNotifyDelegates;

  public static void SwitchGameplay(GameplayKind changeGameplay)
  {
    if (!((UnityEngine.Object) GameManager.gameManager != (UnityEngine.Object) null) || GameManager.gameManager.currentGameplay == changeGameplay)
      return;
    GameManager.gameManager.nextGameplay = changeGameplay;
  }

  public static bool RegisterObserver(
    byte in_SubjectStyle,
    byte in_Subject,
    IObserver pObserver,
    int ObserverMax = 1)
  {
    if ((UnityEngine.Object) GameManager.gameManager != (UnityEngine.Object) null)
    {
      if (GameManager.gameManager.observers[(int) in_SubjectStyle][(int) in_Subject] == null)
        GameManager.gameManager.observers[(int) in_SubjectStyle][(int) in_Subject] = new IObserver[ObserverMax];
      if (GameManager.gameManager.observerCounts[(int) in_SubjectStyle][(int) in_Subject] < GameManager.gameManager.observers[(int) in_SubjectStyle][(int) in_Subject].Length)
      {
        GameManager.gameManager.observers[(int) in_SubjectStyle][(int) in_Subject][GameManager.gameManager.observerCounts[(int) in_SubjectStyle][(int) in_Subject]++] = pObserver;
        return true;
      }
    }
    return false;
  }

  public static void RemoveObserver(byte in_SubjectStyle, byte in_Subject, IObserver pObserver)
  {
    if (!((UnityEngine.Object) GameManager.gameManager != (UnityEngine.Object) null) || GameManager.gameManager.observerCounts[(int) in_SubjectStyle][(int) in_Subject] <= 0)
      return;
    GameManager.gameManager.observers[(int) in_SubjectStyle][(int) in_Subject][--GameManager.gameManager.observerCounts[(int) in_SubjectStyle][(int) in_Subject]] = (IObserver) null;
  }

  public static void notifyObservers(byte in_SubjectStyle, byte in_Subject, byte[] meg = null)
  {
    GameManager.gameManager.checkNotifyDelegates[(int) in_SubjectStyle](in_SubjectStyle, in_Subject, meg);
  }

  public static void OnRefresh(NetworkNews Flash = NetworkNews.Refresh, byte[] meg = null)
  {
    if (meg != null)
    {
      Array.Copy((Array) meg, 0, (Array) DataManager.refreshBuffer, 1, Math.Min(DataManager.refreshBuffer.Length - 1, meg.Length));
      DataManager.refreshBuffer[0] = (byte) Flash;
      GUIManager.Instance.UpdateNetwork(DataManager.refreshBuffer);
      Array.Copy((Array) meg, 0, (Array) DataManager.msgBuffer, 2, Math.Min(DataManager.msgBuffer.Length - 2, meg.Length));
      DataManager.msgBuffer[0] = (byte) 0;
      DataManager.msgBuffer[1] = (byte) Flash;
    }
    else
    {
      DataManager.refreshBuffer[0] = (byte) Flash;
      GUIManager.Instance.UpdateNetwork(DataManager.refreshBuffer);
      DataManager.msgBuffer[0] = (byte) 0;
      DataManager.msgBuffer[1] = (byte) Flash;
    }
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public static void OnLogin()
  {
    if ((UnityEngine.Object) GameManager.gameManager != (UnityEngine.Object) null && GameManager.gameManager.currentGameplay != GameplayKind.Origin)
    {
      if (NewbieManager.IsNewbie && NewbieManager.Get().GetStep() == NewbieStep.FRONT_DISPLAY)
      {
        GameManager.SwitchGameplay(GameplayKind.Front);
      }
      else
      {
        DataManager.StageDataController.currentWorldMode = WorldMode.Wild;
        DataManager.StageDataController._stageMode = StageMode.Count;
        GameManager.SwitchGameplay(GameplayKind.Origin);
      }
    }
    else
      GameManager.OnRefresh(NetworkNews.Login);
  }

  public static void OnGuestLogin() => GameManager.OnRefresh(NetworkNews.GuestLogin);

  protected void Awake()
  {
    UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object) this.gameObject);
    GameManager.gameManager = this;
    this.updateDelegates = new GameManager.UpdateDelegate[7];
    this.updateDelegates[0] = new GameManager.UpdateDelegate(this.UpdateSceneReset);
    this.updateDelegates[1] = new GameManager.UpdateDelegate(this.UpdateScenePreload);
    this.updateDelegates[2] = new GameManager.UpdateDelegate(this.UpdateSceneLoad);
    this.updateDelegates[3] = new GameManager.UpdateDelegate(this.UpdateSceneUnload);
    this.updateDelegates[4] = new GameManager.UpdateDelegate(this.UpdateScenePostload);
    this.updateDelegates[5] = new GameManager.UpdateDelegate(this.UpdateSceneReady);
    this.updateDelegates[6] = new GameManager.UpdateDelegate(this.UpdateSceneRun);
    this.observers = new IObserver[2][][];
    Array.Clear((Array) this.observers, 0, this.observers.Length);
    this.observers[0] = new IObserver[4][];
    Array.Clear((Array) this.observers[0], 0, this.observers[0].Length);
    this.observers[1] = new IObserver[1][];
    Array.Clear((Array) this.observers[1], 0, this.observers[1].Length);
    this.observerCounts = new int[2][];
    Array.Clear((Array) this.observerCounts, 0, this.observerCounts.Length);
    this.observerCounts[0] = new int[4];
    Array.Clear((Array) this.observerCounts[0], 0, this.observerCounts[0].Length);
    this.observerCounts[1] = new int[1];
    Array.Clear((Array) this.observerCounts[1], 0, this.observerCounts[1].Length);
    this.checkNotifyDelegates = new GameManager.CheckNotifyDelegate[2];
    this.checkNotifyDelegates[0] = new GameManager.CheckNotifyDelegate(this.CheckTickNotify);
    this.checkNotifyDelegates[1] = new GameManager.CheckNotifyDelegate(this.CheckErraticNotify);
    this.nextGameplay = GameplayKind.Obb;
    if (IGGSDKPlugin.GetObbDir() == string.Empty)
    {
      this.nextGameplay = GameplayKind.Count;
      IGGSDKPlugin.ShowExit();
    }
    this.sceneState = GameManager.SceneState.Reset;
    DataManager.Instance.SetUserLanguage();
    GUIManager.Instance.Update();
    Screen.sleepTimeout = -1;
  }

  protected void OnDestroy()
  {
    this.ClearObservers();
    for (int index = 0; index < this.observers.Length; ++index)
    {
      Array.Clear((Array) this.observers[index], 0, this.observers[index].Length);
      Array.Clear((Array) this.observerCounts[index], 0, this.observerCounts[index].Length);
    }
    this.observers = (IObserver[][][]) null;
    this.observerCounts = (int[][]) null;
    if (this.updateDelegates != null)
    {
      Array.Clear((Array) this.updateDelegates, 0, this.updateDelegates.Length);
      this.updateDelegates = (GameManager.UpdateDelegate[]) null;
    }
    GameManager.ActiveGameplay = (Gameplay) null;
    BSInvokeUtil.free();
    AssetManager.FreeAss();
    NetworkManager.Destroy();
    AudioManager.Instance.Destroy();
    GUIManager.Instance.Free();
    if (!((UnityEngine.Object) GameManager.gameManager != (UnityEngine.Object) null))
      return;
    GameManager.gameManager = (GameManager) null;
  }

  protected void OnApplicationPause(bool pause)
  {
    NetworkManager.Reload(pause);
    PushManage.Instance.SetPushToSDK(pause);
    GUIManager.Instance.OnUIBattlePause(pause);
    if (!pause)
      IGGSDKPlugin.SetFacebookEventActivateApp();
    else
      IGGSDKPlugin.SetFacebookEventDeactivateApp();
    if (!pause)
      return;
    AFAdvanceManager.Instance.SaveOnlineTime();
    AFAdvanceManager.Instance.SaveEventData();
  }

  protected void OnApplicationFocus(bool hasFocus)
  {
    if (!hasFocus)
      return;
    AFAdvanceManager.Instance.GetOnlineTime();
    AFAdvanceManager.Instance.GetEventData();
  }

  protected void OnApplicationQuit()
  {
    GameManager.bQuitGame = true;
    PushManage.Instance.SetPushToSDK(true);
    AFAdvanceManager.Instance.SaveOnlineTime();
    AFAdvanceManager.Instance.SaveEventData();
    LandWalkerManager.Release();
  }

  protected void Update()
  {
    NetworkManager.Instance.Update();
    this.updateDelegates[(int) this.sceneState]();
  }

  public void CheckTickNotify(byte checkSubjectStyle, byte checkSubject, byte[] checkMeg)
  {
    for (int index = 0; index < this.observerCounts[(int) checkSubjectStyle][(int) checkSubject]; ++index)
    {
      DataManager.DataBuffer[0] = checkSubjectStyle;
      DataManager.DataBuffer[1] = checkSubject;
      this.observers[(int) checkSubjectStyle][(int) checkSubject][index].Renew(DataManager.DataBuffer, checkMeg);
    }
  }

  public void CheckErraticNotify(byte checkSubjectStyle, byte checkSubject, byte[] checkMeg)
  {
    if (this.sceneState < GameManager.SceneState.Unload)
    {
      if (this.notifyInfos == null)
        this.notifyInfos = new GameManager.NotifyInfo[128];
      if (this.notifyInfoCount == (byte) 128)
      {
        this.notifyInfos[(int) this.notifyInfoStart].Subject = checkSubject;
        if (checkMeg == null)
          Array.Clear((Array) this.notifyInfos[(int) this.notifyInfoStart].Info, 0, 32);
        else
          Array.Copy((Array) checkMeg, (Array) this.notifyInfos[(int) this.notifyInfoStart].Info, 32);
        ++this.notifyInfoStart;
        this.notifyInfoStart &= (byte) 127;
      }
      else
      {
        this.notifyInfos[(int) this.notifyInfoCount].Subject = checkSubject;
        if (this.notifyInfos[(int) this.notifyInfoCount].Info == null)
          this.notifyInfos[(int) this.notifyInfoCount].Info = new byte[32];
        if (checkMeg == null)
          Array.Clear((Array) this.notifyInfos[(int) this.notifyInfoCount].Info, 0, 32);
        else
          Array.Copy((Array) checkMeg, (Array) this.notifyInfos[(int) this.notifyInfoCount].Info, 32);
        ++this.notifyInfoCount;
      }
    }
    else
      this.CheckTickNotify(checkSubjectStyle, checkSubject, checkMeg);
  }

  private void ClearObservers()
  {
    for (int index1 = 0; index1 < this.observers.Length; ++index1)
    {
      for (int index2 = 0; index2 < this.observers[index1].Length; ++index2)
      {
        if (this.observers[index1][index2] != null)
          Array.Clear((Array) this.observers[index1][index2], 0, this.observers[index1][index2].Length);
        this.observerCounts[index1][index2] = 0;
      }
    }
  }

  private void UpdateSceneReset()
  {
    this.ClearObservers();
    GameManager.ActiveGameplay = (Gameplay) null;
    GC.Collect();
    this.sceneState = GameManager.SceneState.Preload;
  }

  private void UpdateScenePreload()
  {
    this.sceneState = GameManager.SceneState.Load;
    AssetManager.Instance.AssetManagerState = AssetState.Preload;
  }

  private void UpdateSceneLoad()
  {
    if (AssetManager.Instance.AssetManagerState == AssetState.Preload)
    {
      AssetManager.Instance.AssetManagerState = AssetState.Load;
      GameManager.ActiveGameplay = this.CreateGameplay(this.nextGameplay);
      if (GameManager.ActiveGameplay != null)
      {
        GameManager.RegisterObserver((byte) 0, (byte) 0, (IObserver) GameManager.ActiveGameplay);
        GameManager.RegisterObserver((byte) 0, (byte) 1, (IObserver) GameManager.ActiveGameplay);
        GameManager.RegisterObserver((byte) 0, (byte) 2, (IObserver) GameManager.ActiveGameplay);
        GameManager.RegisterObserver((byte) 0, (byte) 3, (IObserver) GameManager.ActiveGameplay);
      }
      GameManager.notifyObservers((byte) 0, (byte) 1);
    }
    else
    {
      if (AssetManager.Instance.AssetManagerState != AssetState.Ready)
        return;
      this.sceneState = GameManager.SceneState.Unload;
      this.CheckNotify();
    }
  }

  private void UpdateSceneUnload() => this.sceneState = GameManager.SceneState.Postload;

  private void UpdateScenePostload()
  {
    this.currentGameplay = this.nextGameplay;
    this.sceneState = GameManager.SceneState.Ready;
  }

  private void UpdateSceneReady()
  {
    GC.Collect();
    this.sceneState = GameManager.SceneState.Run;
    AssetManager.Instance.AssetManagerState = AssetState.Run;
    GameManager.notifyObservers((byte) 0, (byte) 2);
  }

  private void UpdateSceneRun()
  {
    if (this.currentGameplay != this.nextGameplay)
    {
      this.sceneState = GameManager.SceneState.Reset;
      GameManager.notifyObservers((byte) 0, (byte) 0);
      GUIManager.Instance.UpdateNext();
    }
    else
    {
      GameManager.notifyObservers((byte) 0, (byte) 3);
      ParticleManager.Instance.Update();
      GUIManager.Instance.Update();
      AudioManager.Instance.Update();
      ActivityManager.Instance.Update();
      MallManager.Instance.Update();
      MobilizationManager.Instance.Update();
      PetManager.Instance.Update();
      ActivityGiftManager.Instance.Update();
    }
  }

  private Gameplay CreateGameplay(GameplayKind gp)
  {
    Gameplay gameplay = (Gameplay) null;
    switch (gp)
    {
      case GameplayKind.Origin:
        gameplay = (Gameplay) new Origin();
        break;
      case GameplayKind.Update:
        gameplay = (Gameplay) new UpdateController(this);
        break;
      case GameplayKind.Battle:
        gameplay = (Gameplay) new BattleController();
        break;
      case GameplayKind.War:
        gameplay = (Gameplay) new WarManager();
        break;
      case GameplayKind.CHAOS:
        gameplay = (Gameplay) new CHAOS();
        break;
      case GameplayKind.Front:
        gameplay = (Gameplay) new Front();
        break;
      case GameplayKind.Cosmos:
        gameplay = (Gameplay) new Cosmos();
        break;
      case GameplayKind.Obb:
        gameplay = (Gameplay) new ObbManager();
        break;
    }
    return gameplay;
  }

  private void CheckNotify()
  {
    if (this.notifyInfoCount == (byte) 0)
      return;
    byte num1 = this.notifyInfoStart;
    int num2 = 0;
    while (num2 < (int) this.notifyInfoCount)
    {
      byte index = (byte) ((uint) num1 & (uint) sbyte.MaxValue);
      this.CheckTickNotify((byte) 1, this.notifyInfos[(int) index].Subject, this.notifyInfos[(int) index].Info);
      ++num2;
      num1 = (byte) ((uint) index + 1U);
    }
    this.notifyInfoStart = this.notifyInfoCount = (byte) 0;
  }

  private enum SceneState : byte
  {
    Reset,
    Preload,
    Load,
    Unload,
    Postload,
    Ready,
    Run,
    Count,
  }

  private struct NotifyInfo
  {
    public byte Subject;
    public byte[] Info;
  }

  private delegate void UpdateDelegate();

  private delegate void CheckNotifyDelegate(
    byte checkSubjectStyle,
    byte checkSubject,
    byte[] checkMeg);
}
