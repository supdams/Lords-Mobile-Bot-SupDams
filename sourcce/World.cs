// Decompiled with JetBrains decompiler
// Type: World
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class World : 
  Image,
  IPointerUpHandler,
  IDragHandler,
  IPointerDownHandler,
  IEventSystemHandler,
  IObserver,
  IObservable
{
  private const ushort CastleModelEffID = 309;
  private int worldflag;
  private WorldMode nextWorldMode;
  public TickSubject worldState;
  public World.UpdateDelegate[] updateDelegates;
  private IObserver[][] Observers;
  public CameraMove cameraController;
  private CloudController cloudController;
  private Vector2 BeginPos;
  private GameObject CorpsStageGameObject;
  private GameObject CastleModel;
  private GameObject LordModel;
  private GameObject CastleModelEff;
  private Transform LordBipTransform;
  private Transform ShadowTransform;
  private int CastleassetKey;
  private int LordassetKey;
  private int ShadowassetKey;
  private int WorldInputLockCount;
  private int WorldQueueLockCount;
  private ushort currentCorpsStageRecord;

  public GameObject CastleObj => this.CastleModel;

  protected virtual void Awake()
  {
    ((UIBehaviour) this).Awake();
    ((Graphic) this).color = Color.clear;
    this.nextWorldMode = DataManager.StageDataController.currentWorldMode;
    this.worldflag |= 1;
    this.updateDelegates = new World.UpdateDelegate[4];
    this.updateDelegates[0] = new World.UpdateDelegate(this.WorldNext);
    this.updateDelegates[1] = new World.UpdateDelegate(this.WorldLoad);
    this.updateDelegates[2] = new World.UpdateDelegate(this.WorldReady);
    this.updateDelegates[3] = new World.UpdateDelegate(this.WorldRun);
    this.Observers = new IObserver[2][];
    this.Observers[0] = new IObserver[4];
    this.Observers[1] = new IObserver[1];
    this.cameraController = new CameraMove((CameraState) this.nextWorldMode);
    this.cloudController = new CloudController();
    AssetManager.LoadBigMap();
    this.worldState = TickSubject.Load;
    if (this.nextWorldMode != WorldMode.Wild || DataManager.Instance.bWorldF)
      return;
    this.cameraController.Limit = DataManager.Instance.WorldCameraLimit;
    Camera.main.transform.position = DataManager.Instance.WorldCameraPos;
    DataManager.Instance.bWorldF = true;
  }

  protected virtual void OnDestroy()
  {
    if (this.WorldInputLockCount > 0)
    {
      for (int index = 0; index < this.WorldInputLockCount; ++index)
        GUIManager.Instance.HideUILock(EUILock.Normal);
    }
    this.WorldInputLockCount = 0;
    DataManager.DataBuffer[0] = (byte) 0;
    DataManager.DataBuffer[1] = (byte) 0;
    this.notifyObservers(DataManager.DataBuffer, (byte[]) null);
    this.WorldNext();
    this.ClearObservers();
    if (this.updateDelegates != null)
    {
      Array.Clear((Array) this.updateDelegates, 0, this.updateDelegates.Length);
      this.updateDelegates = (World.UpdateDelegate[]) null;
    }
    AssetManager.UnloadBigMap();
    if (DataManager.Instance.bWorldF)
    {
      DataManager.Instance.WorldCameraLimit = this.cameraController.Limit;
      if ((UnityEngine.Object) Camera.main != (UnityEngine.Object) null)
        DataManager.Instance.WorldCameraPos = Camera.main.transform.position;
      DataManager.Instance.bWorldF = false;
    }
    this.cameraController = (CameraMove) null;
    this.cloudController.Destory();
    this.cloudController = (CloudController) null;
    ParticleManager.Instance.DeSpawn(this.CastleModelEff);
    this.CastleModelEff = (GameObject) null;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.CorpsStageGameObject);
    this.CorpsStageGameObject = (GameObject) null;
    this.ShadowTransform = (Transform) null;
    this.LordBipTransform = (Transform) null;
    AssetManager.UnloadAssetBundle(this.CastleassetKey);
    AssetManager.UnloadAssetBundle(this.LordassetKey);
    AssetManager.UnloadAssetBundle(this.ShadowassetKey);
    ((UIBehaviour) this).OnDestroy();
  }

  protected void Update()
  {
    this.updateDelegates[(int) this.worldState]();
    this.cameraController.CameraUpdata();
    this.cloudController.Update();
    this.CorpsStageUpdate();
  }

  public void RegisterObserver(byte[] Subject, IObserver pObserver)
  {
    this.Observers[(int) Subject[0]][(int) Subject[1]] = pObserver;
  }

  public void RegisterObserver(byte in_SubjectStyle, byte in_Subject, IObserver pObserver)
  {
    DataManager.DataBuffer[0] = in_SubjectStyle;
    DataManager.DataBuffer[1] = in_Subject;
    this.RegisterObserver(DataManager.DataBuffer, pObserver);
  }

  public void RemoveObserver(byte[] Subject)
  {
    this.Observers[(int) Subject[0]][(int) Subject[1]] = (IObserver) null;
  }

  public void notifyObservers(byte[] Subject, byte[] meg = null)
  {
    this.Observers[(int) Subject[0]][(int) Subject[1]].Renew(Subject, meg);
  }

  public void notifyNews(byte[] meg = null)
  {
    if (this.Observers[1][0] == null)
      return;
    DataManager.DataBuffer[0] = (byte) 1;
    DataManager.DataBuffer[1] = (byte) 0;
    this.notifyObservers(DataManager.DataBuffer, meg);
  }

  public void ClearObservers()
  {
    for (int index = 0; index < this.Observers.Length; ++index)
    {
      Array.Clear((Array) this.Observers[index], 0, this.Observers[index].Length);
      this.Observers[index] = (IObserver[]) null;
    }
    this.Observers = (IObserver[][]) null;
  }

  public void Renew(byte[] Subject, byte[] meg)
  {
    GAME_PLAYER_NEWS gamePlayerNews = (GAME_PLAYER_NEWS) Subject[0];
    switch (gamePlayerNews)
    {
      case GAME_PLAYER_NEWS.Network_Update:
        switch ((NetworkNews) Subject[1])
        {
          case NetworkNews.Login:
            if (this.WorldInputLockCount <= 0)
              return;
            for (int index = 0; index < this.WorldInputLockCount; ++index)
              GUIManager.Instance.ShowUILock(EUILock.Normal);
            return;
          case NetworkNews.Refresh_Hospital:
          case NetworkNews.Refresh_Trap:
            DataManager.msgBuffer[0] = (byte) 9;
            this.notifyNews(DataManager.msgBuffer);
            return;
          default:
            return;
        }
      case GAME_PLAYER_NEWS.ORIGIN_DoorOpenUp:
      case GAME_PLAYER_NEWS.ORIGIN_WildOpenUp:
        DataManager.msgBuffer[0] = (byte) 12;
        this.notifyNews(DataManager.msgBuffer);
        DataManager.Instance.WorldCameraPos = Camera.main.transform.position;
        DataManager.Instance.WorldCameraLimit = this.cameraController.Limit;
        DataManager.Instance.bWorldF = false;
        this.cameraController.SetCameraState(CameraState.Area, DataManager.StageDataController._stageMode == StageMode.Corps ? (byte) ((uint) DataManager.StageDataController.StageRecord[2] + 1U) : DataManager.StageDataController.currentChapterID, true);
        AudioManager.Instance.PlayUISFX(UIKind.ArmyExpewdition);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_DoorWild:
        if (this.nextWorldMode != WorldMode.OpenUp)
          break;
        DataManager.Instance.bWorldF = true;
        if (DataManager.StageDataController._stageMode == StageMode.Corps)
        {
          DataManager.msgBuffer[0] = (byte) 2;
          this.notifyNews(DataManager.msgBuffer);
        }
        else
          GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.DoorWild);
        GUIManager.Instance.m_HUDMessage.MapHud.ThisTransform.gameObject.SetActive(false);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_DoorNext:
        if (this.nextWorldMode != WorldMode.OpenUp)
          break;
        ++DataManager.StageDataController.currentChapterID;
        DataManager.StageDataController.currentPointID = (ushort) (((int) DataManager.StageDataController.currentChapterID - 1) * (int) GameConstants.StagePointNum[(int) DataManager.StageDataController._stageMode] + 1);
        DataManager.StageDataController.SaveUserStage(DataManager.StageDataController._stageMode);
        DataManager.Instance.lastBattleResult = (short) -1;
        this.cameraController.SetCameraPos((int) DataManager.StageDataController.currentChapterID);
        DataManager.msgBuffer[0] = (byte) 6;
        this.notifyNews(DataManager.msgBuffer);
        GUIManager.Instance.m_HUDMessage.MapHud.AddChapterMsg();
        break;
      case GAME_PLAYER_NEWS.ORIGIN_DoorLast:
        if (this.nextWorldMode != WorldMode.OpenUp)
          break;
        --DataManager.StageDataController.currentChapterID;
        DataManager.StageDataController.currentPointID = (ushort) ((uint) DataManager.StageDataController.currentChapterID * (uint) GameConstants.StagePointNum[(int) DataManager.StageDataController._stageMode]);
        DataManager.StageDataController.SaveUserStage(DataManager.StageDataController._stageMode);
        DataManager.Instance.lastBattleResult = (short) -1;
        this.cameraController.SetCameraPos((int) DataManager.StageDataController.currentChapterID);
        DataManager.msgBuffer[0] = (byte) 6;
        this.notifyNews(DataManager.msgBuffer);
        GUIManager.Instance.m_HUDMessage.MapHud.AddChapterMsg();
        break;
      case GAME_PLAYER_NEWS.ORIGIN_CameraOpenUp:
        if (DataManager.StageDataController._stageMode != StageMode.Corps || DataManager.StageDataController.isNotFirstInChapter[2] == (byte) 1)
        {
          this.SwitchWorldMode(WorldMode.OpenUp);
          DataManager.msgBuffer[0] = (byte) 14;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          GUIManager.Instance.m_HUDMessage.MapHud.AddChapterMsg();
          GUIManager.Instance.m_HUDMessage.MapHud.ShowMsg();
          GUIManager.Instance.m_HUDMessage.MapHud.ShowTime = 0.8f;
          GUIManager.Instance.m_HUDMessage.MapHud.StartCountdown();
          this.WorldUIQueueLockRelease();
          break;
        }
        DataManager.msgBuffer[0] = (byte) 47;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_CameraWild:
        if (DataManager.StageDataController._stageMode == StageMode.Corps)
        {
          this.cameraController.Limit = DataManager.Instance.WorldCameraLimit;
          this.cameraController.TmpV3Pos = DataManager.Instance.WorldCameraPos;
          this.cameraController.SetCameraState(CameraState.World, (byte) 0);
          break;
        }
        if (DataManager.StageDataController._stageMode == StageMode.Count)
        {
          this.cameraController.SetCameraState(CameraState.World, (byte) 0);
          GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
          break;
        }
        DataManager.Instance.WorldCameraLimit = 0.0f;
        this.cameraController.SetCamerPos_Out();
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_CameraForce:
        if (DataManager.StageDataController._stageMode != StageMode.Corps || DataManager.StageDataController.isNotFirstInChapter[2] != (byte) 0)
          break;
        this.cloudController.MapClick();
        break;
      case GAME_PLAYER_NEWS.ORIGIN_CloudOpenUp:
        this.SwitchWorldMode(WorldMode.OpenUp);
        DataManager.msgBuffer[0] = (byte) 14;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_LockInput:
        this.worldflag |= 1;
        break;
      case GAME_PLAYER_NEWS.ORIGIN_UnLockInput:
        this.worldflag &= -2;
        break;
      case GAME_PLAYER_NEWS.ORIGIN_CloseStageStory:
      case GAME_PLAYER_NEWS.ORIGIN_CloseTreasureInfo:
        if (DataManager.StageDataController.isNotFirstInChapter[(int) DataManager.StageDataController._stageMode] == (byte) 0)
        {
          if (DataManager.StageDataController._stageMode == StageMode.Corps)
          {
            this.worldflag |= 4;
            if (DataManager.StageDataController.StageRecord[2] == (ushort) 2 && DataManager.StageDataController.StageRecord[1] == (ushort) 0 && DataManager.StageDataController.StageRecord[0] == (ushort) 18)
              this.worldflag |= 2;
          }
          else if (((int) DataManager.StageDataController.currentChapterID + 1) * (int) GameConstants.LinePointNum[(int) DataManager.StageDataController._stageMode] < (int) DataManager.StageDataController.limitRecord[(int) DataManager.StageDataController._stageMode])
            ++DataManager.StageDataController.currentChapterID;
          DataManager.DataBuffer[0] = (byte) 4;
          this.Renew(DataManager.DataBuffer, (byte[]) null);
          if (Subject[0] == (byte) 39)
            this.WorldUIQueueLockRelease();
        }
        else if ((int) DataManager.StageDataController.StageRecord[(int) DataManager.StageDataController._stageMode] == (int) DataManager.StageDataController.limitRecord[(int) DataManager.StageDataController._stageMode])
        {
          if (DataManager.StageDataController._stageMode == StageMode.Corps)
            this.worldflag |= 4;
          DataManager.DataBuffer[0] = (byte) 4;
          this.Renew(DataManager.DataBuffer, (byte[]) null);
          if (Subject[0] == (byte) 39)
            this.WorldUIQueueLockRelease();
        }
        else
        {
          if (DataManager.StageDataController._stageMode == StageMode.Full && DataManager.StageDataController.StageRecord[0] == (ushort) 18)
            this.worldflag |= 2;
          DataManager.DataBuffer[0] = (byte) 0;
          DataManager.DataBuffer[1] = (byte) 1;
          this.notifyObservers(DataManager.DataBuffer, (byte[]) null);
          DataManager.msgBuffer[0] = (byte) 13;
          this.notifyNews(DataManager.msgBuffer);
          this.worldState = TickSubject.Ready;
          if (DataManager.StageDataController._stageMode == StageMode.Full || DataManager.StageDataController._stageMode == StageMode.Lean)
            this.WorldUIQueueLockRelease();
        }
        GUIManager.Instance.m_HUDMessage.MapHud.AddChapterMsg();
        if (DataManager.StageDataController._stageMode != StageMode.Corps || this.nextWorldMode == WorldMode.OpenUp)
          GUIManager.Instance.m_HUDMessage.MapHud.ShowMsg();
        GUIManager.Instance.m_HUDMessage.MapHud.ShowTime = 0.8f;
        GUIManager.Instance.m_HUDMessage.MapHud.StartCountdown();
        break;
      case GAME_PLAYER_NEWS.ORIGIN_CameraStateWild:
        if ((this.worldflag & 4) != 0)
        {
          this.worldflag &= -5;
          GUIManager.Instance.OpenMenu(EGUIWindow.UI_NewTerritory, (int) DataManager.StageDataController.StageRecord[2], bSecWindow: true);
        }
        else
          this.WorldUIQueueLockRelease();
        NewbieManager.EntryTest();
        Indemnify.CheckShowIndemnify();
        ActivityGiftManager.Instance.CheckShowActivityGiftEffect();
        DataManager.msgBuffer[0] = (byte) 47;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_OpenUpWild:
        this.SwitchWorldMode(WorldMode.Wild);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_OpenUpContinue:
        DataManager.msgBuffer[0] = (byte) 4;
        this.notifyNews(DataManager.msgBuffer);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_ManorGuildCameraMove:
        BuildManorData recordByKey = DataManager.Instance.BuildManorData.GetRecordByKey(GameConstants.ConvertBytesToUShort(DataManager.msgBuffer, 3));
        this.cameraController.CameraMoveTarget(CameraState.Build, new Vector3((float) ((recordByKey.bPosionX <= (ushort) 30000 ? (double) recordByKey.bPosionX : (double) recordByKey.bPosionX - (double) ushort.MaxValue) * 0.0099999997764825821) + 4f, (float) ((recordByKey.bPosionY <= (ushort) 32768 ? (double) recordByKey.bPosionY : (double) recordByKey.bPosionY - (double) ushort.MaxValue) * 0.0099999997764825821), (float) ((recordByKey.bPosionZ <= (ushort) 32768 ? (double) recordByKey.bPosionZ : (double) recordByKey.bPosionZ - (double) ushort.MaxValue) * 0.0099999997764825821) - 23.5f));
        DataManager.msgBuffer[0] = (byte) 11;
        this.notifyNews(DataManager.msgBuffer);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_ArneaGuildCameraMove:
        this.cameraController.CameraMoveTarget(CameraState.Build, new Vector3(119.07f, 30.8f, 78.78f));
        break;
      case GAME_PLAYER_NEWS.ORIGIN_DugoutGuildCameraMove:
        this.cameraController.CameraMoveTarget(CameraState.Build, new Vector3(-22.22f, 13.39f, -22.2f));
        break;
      case GAME_PLAYER_NEWS.ORIGIN_BlackMarketGuildCameraMove:
        this.cameraController.CameraMoveTarget(CameraState.Build, new Vector3(51.5f, -0.5f, 87.44f));
        break;
      case GAME_PLAYER_NEWS.ORIGIN_WarlobbyGuildCameraMove:
        if (!((UnityEngine.Object) GUIManager.Instance.BuildingData.ManorGride[6] != (UnityEngine.Object) null))
          break;
        this.cameraController.CameraMoveTarget(CameraState.Build, GUIManager.Instance.BuildingData.ManorGride[6].position);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_CasinoGuildCameraMove:
        this.cameraController.CameraMoveTarget(CameraState.Build, new Vector3(131.5f, 9.1f, -7.7f));
        break;
      case GAME_PLAYER_NEWS.ORIGIN_LaboratoryGuildCameraMove:
        this.cameraController.CameraMoveTarget(CameraState.Build, new Vector3(-5.2f, 0.6f, 130.1f));
        break;
      case GAME_PLAYER_NEWS.ORIGIN_PetListGuildCameraMove:
        this.cameraController.CameraMoveTarget(CameraState.Build, new Vector3(193.63f, 16.2f, -14.29f));
        break;
      case GAME_PLAYER_NEWS.ORIGIN_UpdateBuild:
        DataManager.msgBuffer[0] = (byte) 5;
        this.notifyNews(DataManager.msgBuffer);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_UpdateOpenUp:
        if (this.nextWorldMode != WorldMode.OpenUp)
          break;
        this.UpdateWorldState();
        break;
      case GAME_PLAYER_NEWS.ORIGIN_ChangeStageMode:
        if (this.nextWorldMode != WorldMode.OpenUp)
          break;
        if (Subject[1] == (byte) 1)
          DataManager.StageDataController.resetStageMode(StageMode.Full);
        else if (Subject[1] == (byte) 2)
          DataManager.StageDataController.resetStageMode(StageMode.Lean);
        else if (Subject[1] == (byte) 3)
        {
          DataManager.StageDataController.resetStageMode(StageMode.Dare);
          if ((int) DataManager.StageDataController.StageRecord[3] >= (int) GameConstants.StagePointNum[3] && !NewbieManager.IsLeadNewbiePass)
          {
            DataManager.StageDataController.currentChapterID = (byte) 1;
            DataManager.StageDataController.currentPointID = (ushort) (((int) DataManager.StageDataController.currentChapterID - 1) * (int) GameConstants.StagePointNum[(int) DataManager.StageDataController._stageMode] + 1);
            DataManager.StageDataController.SaveUserStage(DataManager.StageDataController._stageMode);
          }
        }
        DataManager.StageDataController.SaveUserStageMode(DataManager.StageDataController._stageMode);
        DataManager.Instance.lastBattleResult = (short) -1;
        this.cameraController.SetCameraPos((int) DataManager.StageDataController.currentChapterID);
        this.UpdateWorldState();
        GUIManager.Instance.m_HUDMessage.MapHud.AddChapterMsg();
        GUIManager.Instance.m_HUDMessage.MapHud.ShowMsg();
        GUIManager.Instance.m_HUDMessage.MapHud.ShowTime = 0.8f;
        GUIManager.Instance.m_HUDMessage.MapHud.StartCountdown();
        break;
      case GAME_PLAYER_NEWS.ORIGIN_HideCampain:
        DataManager.msgBuffer[0] = (byte) 8;
        this.notifyNews(DataManager.msgBuffer);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_OpenUpFirstRun:
        if (DataManager.StageDataController._stageMode == StageMode.Full)
        {
          if ((this.worldflag & 2) != 0)
          {
            NewbieManager.CheckTeach(ETeachKind.ELITE_STAGE, bEntry: true);
            this.worldflag &= -3;
          }
          if (DataManager.StageDataController.StageRecord[0] == (ushort) 0 && NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, bEntry: true) || !NewbieManager.CheckPutOnEquipTeach())
            break;
          NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP);
          break;
        }
        if (DataManager.StageDataController._stageMode != StageMode.Corps)
          break;
        NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, (object) this, true);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_BuildOpenUp:
        if (DataManager.StageDataController._stageMode == StageMode.Corps && DataManager.StageDataController.isNotFirstInChapter[2] != (byte) 1)
          break;
        if (DataManager.StageDataController._stageMode == StageMode.Dare && (int) DataManager.StageDataController.StageRecord[3] >= (int) GameConstants.StagePointNum[3] && !NewbieManager.IsLeadNewbiePass)
        {
          DataManager.StageDataController.currentChapterID = (byte) 1;
          DataManager.StageDataController.currentPointID = (ushort) (((int) DataManager.StageDataController.currentChapterID - 1) * (int) GameConstants.StagePointNum[(int) DataManager.StageDataController._stageMode] + 1);
          DataManager.StageDataController.SaveUserStage(DataManager.StageDataController._stageMode);
        }
        DataManager.Instance.WorldCameraPos = GameConstants.GoldGuy;
        DataManager.Instance.WorldCameraLimit = 0.0f;
        DataManager.Instance.bWorldF = false;
        this.cameraController.SetCameraPos((int) DataManager.StageDataController.currentChapterID);
        this.SwitchWorldMode(WorldMode.OpenUp);
        DataManager.msgBuffer[0] = (byte) 14;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_UIQueueLock:
        this.WorldUIQueueLock();
        break;
      case GAME_PLAYER_NEWS.ORIGIN_UIQueueLockRelease:
        this.WorldUIQueueLockRelease();
        break;
      case GAME_PLAYER_NEWS.ORIGIN_UIInputLock:
        ++this.WorldInputLockCount;
        GUIManager.Instance.ShowUILock(EUILock.Normal);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_UIInputLockRelease:
        --this.WorldInputLockCount;
        GUIManager.Instance.HideUILock(EUILock.Normal);
        break;
      default:
        if (gamePlayerNews != GAME_PLAYER_NEWS.ORIGIN_CameraReSetPressPosition)
          break;
        this.cameraController.ReSetPressPosition();
        break;
    }
  }

  public void OnDrag(PointerEventData eventData)
  {
    if ((this.worldflag & 1) != 0)
      return;
    this.cameraController.OnDrag(eventData);
    if ((double) Mathf.Abs(this.BeginPos.x - eventData.position.x) <= 50.0 && (double) Mathf.Abs(this.BeginPos.y - eventData.position.y) <= 50.0)
      return;
    DataManager.msgBuffer[0] = (byte) 7;
    this.notifyNews(DataManager.msgBuffer);
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    if ((this.worldflag & 1) != 0)
      return;
    DataManager.msgBuffer[0] = (byte) 0;
    GameConstants.GetBytes(eventData.position.x, DataManager.msgBuffer, 1);
    GameConstants.GetBytes(eventData.position.y, DataManager.msgBuffer, 5);
    this.notifyNews(DataManager.msgBuffer);
    this.cameraController.OnBeginDrag(eventData);
    this.BeginPos = eventData.pressPosition;
  }

  public void OnPointerUp(PointerEventData eventData)
  {
    if ((this.worldflag & 1) != 0)
      return;
    DataManager.msgBuffer[0] = (byte) 1;
    GameConstants.GetBytes(eventData.position.x, DataManager.msgBuffer, 1);
    GameConstants.GetBytes(eventData.position.y, DataManager.msgBuffer, 5);
    this.notifyNews(DataManager.msgBuffer);
    this.cameraController.OnEndDrag(eventData);
  }

  public void SwitchWorldMode(WorldMode in_nextWorldMode)
  {
    if (DataManager.StageDataController.currentWorldMode == in_nextWorldMode)
      return;
    this.nextWorldMode = in_nextWorldMode;
  }

  public void WorldUIQueueLock()
  {
    if (this.WorldQueueLockCount == 0)
      GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Stage);
    ++this.WorldQueueLockCount;
  }

  public void WorldUIQueueLockRelease()
  {
    --this.WorldQueueLockCount;
    if (this.WorldQueueLockCount != 0)
      return;
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Stage);
  }

  public void UpdateWorldState()
  {
    this.worldState = TickSubject.Next;
    DataManager.DataBuffer[0] = (byte) 0;
    DataManager.DataBuffer[1] = (byte) 0;
    this.notifyObservers(DataManager.DataBuffer, (byte[]) null);
    for (int index = 0; index < this.Observers.Length; ++index)
      Array.Clear((Array) this.Observers[index], 0, this.Observers[index].Length);
  }

  private void initCorpsStage()
  {
    ushort InKey;
    CorpsStage recordByKey1;
    if (DataManager.Instance.lastBattleResult == (short) 1)
    {
      InKey = DataManager.StageDataController.StageRecord[2];
      recordByKey1 = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(InKey);
    }
    else
    {
      if ((int) DataManager.StageDataController.StageRecord[2] >= (int) DataManager.StageDataController.limitRecord[2])
      {
        if (!((UnityEngine.Object) this.CorpsStageGameObject != (UnityEngine.Object) null))
          return;
        this.CorpsStageGameObject.SetActive(false);
        return;
      }
      InKey = (ushort) ((uint) DataManager.StageDataController.StageRecord[2] + 1U);
      recordByKey1 = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(InKey);
    }
    if ((UnityEngine.Object) this.CorpsStageGameObject == (UnityEngine.Object) null)
    {
      if ((int) InKey != (int) this.currentCorpsStageRecord)
        this.currentCorpsStageRecord = InKey;
      this.CorpsStageGameObject = new GameObject("CorpsStage");
    }
    else
    {
      if ((int) InKey == (int) this.currentCorpsStageRecord)
        return;
      this.currentCorpsStageRecord = InKey;
      this.CastleModelEff.transform.SetParent((Transform) null);
      this.CastleModel.transform.SetParent((Transform) null);
      this.LordModel.transform.SetParent((Transform) null);
      UnityEngine.Object.Destroy((UnityEngine.Object) this.LordModel);
      AssetManager.UnloadAssetBundle(this.LordassetKey);
      this.LordModel = (GameObject) null;
      AssetManager.UnloadAssetBundle(this.ShadowassetKey);
      this.ShadowassetKey = 0;
    }
    CString cstring = StringManager.Instance.SpawnString();
    Transform transform1 = this.CorpsStageGameObject.transform;
    transform1.position = GameConstants.WordToVector3(recordByKey1.CastlePos.X, recordByKey1.CastlePos.Y, recordByKey1.CastlePos.Z);
    if ((UnityEngine.Object) this.CastleModel == (UnityEngine.Object) null)
    {
      cstring.ClearString();
      cstring.AppendFormat("Role/npccastle");
      this.CastleModel = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle(cstring, out this.CastleassetKey).mainAsset) as GameObject;
    }
    Transform transform2 = this.CastleModel.transform;
    transform2.SetParent(transform1);
    transform2.localScale = Vector3.one * (float) recordByKey1.CastleScale * 0.01f;
    Vector3 eulerAngles = transform2.eulerAngles with
    {
      y = (float) recordByKey1.CastleRotY * 0.01f
    };
    transform2.eulerAngles = eulerAngles;
    transform2.position = GameConstants.WordToVector3(recordByKey1.CastlePos.X, recordByKey1.CastlePos.Y, recordByKey1.CastlePos.Z);
    ushort num = 0;
    if ((UnityEngine.Object) this.LordModel == (UnityEngine.Object) null)
    {
      Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(recordByKey1.Heros[0].HeroID);
      ushort x = recordByKey2.Modle;
      if (!DataManager.Instance.CheckHero3DMesh(recordByKey1.Heros[0].HeroID))
        x = (ushort) 1;
      num = recordByKey2.Radius;
      cstring.ClearString();
      cstring.StringToFormat("Role/hero_");
      cstring.IntToFormat((long) x, 5);
      cstring.AppendFormat("{0}{1}");
      AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.LordassetKey);
      if ((bool) (UnityEngine.Object) assetBundle)
        this.LordModel = UnityEngine.Object.Instantiate(assetBundle.Load("m")) as GameObject;
    }
    if ((bool) (UnityEngine.Object) this.LordModel)
      transform2 = this.LordModel.transform;
    transform2.SetParent(transform1);
    transform2.localScale = Vector3.one * (float) recordByKey1.LordScale * 0.01f;
    transform2.position = GameConstants.WordToVector3(recordByKey1.LordPos.X, recordByKey1.LordPos.Y, recordByKey1.LordPos.Z);
    if (this.ShadowassetKey == 0)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle("UI/shadow", out this.ShadowassetKey).mainAsset) as GameObject;
      this.ShadowTransform = gameObject.transform;
      this.ShadowTransform.SetParent(transform2, false);
      gameObject.GetComponent<MeshFilter>().mesh = GameConstants.CreatePlane(transform2.forward, transform2.right, new Rect(0.0f, 0.0f, 1f, 1f), new Color(1f, 1f, 1f, 0.6f), (float) num * 0.015f);
      this.LordBipTransform = transform2.GetChild(0);
    }
    ParticleManager.Instance.DeSpawn(this.CastleModelEff);
    this.CastleModelEff = ParticleManager.Instance.Spawn((ushort) 309, transform1, Vector3.zero, (float) recordByKey1.CastleScale * 0.01f, true);
    this.CastleModelEff.SetActive(true);
    StringManager.Instance.DeSpawnString(cstring);
  }

  private void CorpsStageUpdate()
  {
    if ((UnityEngine.Object) this.CorpsStageGameObject == (UnityEngine.Object) null || !this.CorpsStageGameObject.activeSelf || (UnityEngine.Object) this.LordModel == (UnityEngine.Object) null)
      return;
    this.ShadowTransform.position = this.LordBipTransform.position with
    {
      y = this.ShadowTransform.position.y
    };
  }

  private void WorldNext()
  {
    this.worldflag |= 1;
    this.worldState = TickSubject.Load;
    LandWalkerManager.Release();
  }

  private void WorldLoad()
  {
    GC.Collect();
    IObserver worldMode = this.CreateWorldMode(this.nextWorldMode);
    this.RegisterObserver((byte) 0, (byte) 0, worldMode);
    this.RegisterObserver((byte) 0, (byte) 1, worldMode);
    this.RegisterObserver((byte) 0, (byte) 2, worldMode);
    this.RegisterObserver((byte) 0, (byte) 3, worldMode);
    this.RegisterObserver((byte) 1, (byte) 0, worldMode);
    DataManager.DataBuffer[0] = (byte) 0;
    DataManager.DataBuffer[1] = (byte) 1;
    this.notifyObservers(DataManager.DataBuffer, (byte[]) null);
    DataManager.StageDataController.currentWorldMode = this.nextWorldMode;
    this.worldState = TickSubject.Ready;
  }

  private void WorldReady()
  {
    GC.Collect();
    DataManager.DataBuffer[0] = (byte) 0;
    DataManager.DataBuffer[1] = (byte) 2;
    this.notifyObservers(DataManager.DataBuffer, (byte[]) null);
    this.worldflag &= -2;
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
    this.worldState = TickSubject.Run;
    this.cloudController.UpdateColudController();
    if (DataManager.StageDataController.currentWorldMode != WorldMode.Wild)
      return;
    LandWalkerManager instance = LandWalkerManager.Instance;
  }

  private void WorldRun()
  {
    if (DataManager.StageDataController.currentWorldMode != this.nextWorldMode)
    {
      this.UpdateWorldState();
    }
    else
    {
      DataManager.DataBuffer[0] = (byte) 0;
      DataManager.DataBuffer[1] = (byte) 3;
      this.notifyObservers(DataManager.DataBuffer, (byte[]) null);
    }
  }

  private IObserver CreateWorldMode(WorldMode wm)
  {
    IObserver worldMode = (IObserver) null;
    this.initCorpsStage();
    switch (wm)
    {
      case WorldMode.Wild:
        worldMode = (IObserver) new Wild(this.CorpsStageGameObject);
        break;
      case WorldMode.OpenUp:
        worldMode = (IObserver) new OpenUp(this.CorpsStageGameObject);
        break;
    }
    return worldMode;
  }

  private enum World_Flag
  {
    Lock,
    OpenLeanMsg,
    OpenNewTerritory,
  }

  public delegate void UpdateDelegate();
}
