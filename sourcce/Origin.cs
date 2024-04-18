// Decompiled with JetBrains decompiler
// Type: Origin
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class Origin : Gameplay
{
  private World worldController;
  private Door doorController;
  private byte HideUI;

  public World WorldController => this.worldController;

  ~Origin()
  {
  }

  protected override void UpdateNews(byte[] meg)
  {
    GAME_PLAYER_NEWS gamePlayerNews = (GAME_PLAYER_NEWS) meg[0];
    switch (gamePlayerNews)
    {
      case GAME_PLAYER_NEWS.ORIGIN_OpenStage:
        if (GUIManager.Instance.m_WindowStack.Count != 0)
          break;
        if (DataManager.StageDataController._stageMode == StageMode.Corps)
        {
          this.doorController.OpenMenu(EGUIWindow.UI_StageSelect2, DataManager.Instance.lastBattleResult != (short) 1 ? (int) DataManager.StageDataController.StageRecord[2] + 1 : (int) DataManager.StageDataController.StageRecord[2]);
          break;
        }
        this.doorController.OpenMenu(EGUIWindow.UI_StageSelect, (int) DataManager.StageDataController.currentChapterID);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_OpenStageStory:
        if (meg[1] == (byte) 1)
          this.doorController.CloseMenu();
        if (DataManager.StageDataController._stageMode == StageMode.Corps)
          this.doorController.OpenMenu(EGUIWindow.UI_StageStory, meg[1] != (byte) 1 ? (int) DataManager.StageDataController.StageRecord[2] + 1 : (int) DataManager.StageDataController.StageRecord[2], (int) meg[1], true);
        else
          this.doorController.OpenMenu(EGUIWindow.UI_StageStory, (int) DataManager.StageDataController.currentChapterID, (int) meg[1], true);
        GUIManager.Instance.m_HUDMessage.MapHud.SkipMsg();
        break;
      case GAME_PLAYER_NEWS.ORIGIN_CloseStageStory:
        this.doorController.CloseMenu();
        DataManager.msgBuffer[0] = (byte) 16;
        this.worldController.Renew(DataManager.msgBuffer, (byte[]) null);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_OpenStageInfo:
        this.doorController.OpenMenu(EGUIWindow.UI_StageInfo, bCameraMode: true);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_OpenPve:
        this.doorController.m_GroundInfo.OpenPvePanel(true, (ushort) ((uint) DataManager.StageDataController.StageRecord[2] + 1U));
        break;
      case GAME_PLAYER_NEWS.ORIGIN_CameraStateWild:
        this.worldController.Renew(meg, (byte[]) null);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_CloseNewTerritory:
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_NewTerritory);
        if (NewbieManager.CheckGoldGuy())
          NewbieManager.CheckTeach(ETeachKind.GOLDGUY);
        else if (NewbieManager.CheckArmyHole(true))
          NewbieManager.CheckTeach(ETeachKind.ARMY_HOLE);
        else
          NewbieManager.CheckGambleNormal();
        this.worldController.WorldUIQueueLockRelease();
        this.worldController.WorldUIQueueLockRelease();
        break;
      case GAME_PLAYER_NEWS.ORIGIN_OpenUpWild:
        GUIManager.Instance.CloseCheckCrystalBox();
        GUIManager.Instance.CloseOKCancelBox();
        this.doorController.CloseMenu(true);
        DataManager.msgBuffer[0] = (byte) 21;
        this.worldController.Renew(DataManager.msgBuffer, (byte[]) null);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_OpenBuild:
        GUIManager.Instance.BuildingData.OpenUI(GameConstants.ConvertBytesToUShort(meg, 1), this.doorController);
        DataManager.msgBuffer[0] = (byte) 23;
        this.worldController.Renew(DataManager.msgBuffer, (byte[]) null);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_UpdateBuild:
        this.worldController.Renew(meg, (byte[]) null);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_CloseBuild:
        this.doorController.CloseMenu();
        DataManager.msgBuffer[0] = (byte) 33;
        this.worldController.Renew(DataManager.msgBuffer, (byte[]) null);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_ChangeStageMode:
        if (!(bool) (Object) this.worldController || !(bool) (Object) this.doorController)
          break;
        UIStageSelect menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) as UIStageSelect;
        if (!(bool) (Object) menu)
          break;
        if (menu.NFlash.activeSelf)
          meg[1] = (byte) 1;
        else if (menu.EFlash.activeSelf)
          meg[1] = (byte) 2;
        else if (menu.AFlash.activeSelf)
          meg[1] = (byte) 3;
        this.worldController.Renew(meg, (byte[]) null);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_OpenTreasureInfo:
        if (meg[1] == (byte) 1)
          this.doorController.CloseMenu();
        this.doorController.OpenMenu(EGUIWindow.UI_ChapterRewards, (int) DataManager.StageDataController.currentChapterID, (int) meg[1], true);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_CloseTreasureInfo:
        this.doorController.CloseMenu();
        DataManager.msgBuffer[0] = (byte) 39;
        this.worldController.Renew(DataManager.msgBuffer, (byte[]) null);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_SetCastleLevel:
        AssetManager.OriginSetCastleLevel(meg[1], meg[2]);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_ShowUI:
        this.HideUI = (byte) 0;
        ((Component) this.doorController.m_TopLayer).gameObject.SetActive(true);
        for (int index = 1; index < ((Transform) GUIManager.Instance.m_WindowsTransform).childCount; ++index)
          ((Transform) GUIManager.Instance.m_WindowsTransform).GetChild(index).gameObject.SetActive(true);
        if (GUIManager.Instance.m_WindowStack.Count == 0)
        {
          if (DataManager.StageDataController._stageMode == StageMode.Corps)
          {
            if ((Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect2) == (Object) null)
              this.doorController.OpenMenu(EGUIWindow.UI_StageSelect2, DataManager.Instance.lastBattleResult != (short) 1 ? (int) DataManager.StageDataController.StageRecord[2] + 1 : (int) DataManager.StageDataController.StageRecord[2]);
          }
          else if ((Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_StageSelect) == (Object) null)
            this.doorController.OpenMenu(EGUIWindow.UI_StageSelect, (int) DataManager.StageDataController.currentChapterID);
        }
        this.doorController.HideFightButton();
        break;
      case GAME_PLAYER_NEWS.ORIGIN_HideUI:
        this.HideUI = (byte) 1;
        ((Component) this.doorController.m_TopLayer).gameObject.SetActive(false);
        for (int index = 1; index < ((Transform) GUIManager.Instance.m_WindowsTransform).childCount; ++index)
          ((Transform) GUIManager.Instance.m_WindowsTransform).GetChild(index).gameObject.SetActive(false);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_BackgroundEnable:
        if (!(bool) (Object) this.worldController || ((Component) this.worldController).gameObject.activeSelf)
          break;
        ((Component) this.worldController).gameObject.SetActive(true);
        if (LandWalkerManager.alive)
          LandWalkerManager.Instance.enabled = true;
        GameManager.RemoveObserver((byte) 0, (byte) 3, (IObserver) this);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_BackgroundDisable:
        if (!(bool) (Object) this.worldController || !((Component) this.worldController).gameObject.activeSelf)
          break;
        ((Component) this.worldController).gameObject.SetActive(false);
        if (LandWalkerManager.alive)
          LandWalkerManager.Instance.enabled = false;
        GameManager.RegisterObserver((byte) 0, (byte) 3, (IObserver) this);
        break;
      case GAME_PLAYER_NEWS.ORIGIN_DoorFadeOut:
        if (!((Object) this.doorController != (Object) null))
          break;
        this.doorController.BeginFadeInOut();
        break;
      case GAME_PLAYER_NEWS.ORIGIN_DoorFadeIn:
        if (!((Object) this.doorController != (Object) null))
          break;
        this.doorController.BeginFadeIn();
        break;
      default:
        switch (gamePlayerNews)
        {
          case GAME_PLAYER_NEWS.Network_Update:
            if (meg[1] == (byte) 43)
              this.doorController.ViewKingdom();
            else if (meg[1] == (byte) 42 && (int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
            {
              DataManager.MapDataController.FocusKingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
              GUIManager.Instance.HideUILock(EUILock.Normal);
              DataManager.MapDataController.gotoKingdomState = (byte) 0;
            }
            this.worldController.Renew(meg, (byte[]) null);
            return;
          case GAME_PLAYER_NEWS.HeroTalk_Close:
            if (NewbieManager.IsNewbie)
              NewbieManager.Get().NextStep();
            Indemnify.UpdateNetwork(meg);
            return;
          default:
            this.worldController.Renew(meg, (byte[]) null);
            return;
        }
    }
  }

  protected override void UpdateNext(byte[] meg)
  {
    this.ClearUpdateDelegates();
    this.doorController.DeSpawnMainEff();
    this.doorController.setFightButton((AssetBundle) null);
    GUIManager.Instance.CloseMenu(EGUIWindow.Door);
    this.doorController = (Door) null;
    Object.Destroy((Object) ((Component) this.worldController).gameObject);
    this.worldController = (World) null;
    GUIManager.Instance.ClearMapSprite();
    GUIManager.Instance.DestroyTechIconSprite();
    GUIManager.Instance.UnloadWonderSprite();
    GUIManager.Instance.EmojiManager.Clear();
    ActivityGiftManager.Instance.DespawnActivityGiftEffect();
    ParticleManager.Instance.Clear();
  }

  protected override void UpdateLoad(byte[] meg)
  {
    DataManager.Instance.GoToBattleOrWar = GameplayKind.Origin;
    ParticleManager.Instance.Setup();
    GameManager.RemoveObserver((byte) 0, (byte) 3, (IObserver) this);
    GameManager.RegisterObserver((byte) 1, (byte) 0, (IObserver) this);
    GameObject gameObject = new GameObject("Catcher");
    gameObject.layer = 5;
    GUIManager.Instance.StretchTransform(gameObject.AddComponent<RectTransform>());
    gameObject.transform.SetParent((Transform) GUIManager.Instance.m_WindowsTransform, false);
    gameObject.transform.SetAsFirstSibling();
    this.worldController = gameObject.AddComponent<World>();
    this.doorController = GUIManager.Instance.OpenMenu(EGUIWindow.Door, bCameraMode: true) as Door;
    this.worldController.sprite = GUIManager.Instance.m_ChatImage.sprite;
    ((MaskableGraphic) this.worldController).material = ((MaskableGraphic) GUIManager.Instance.m_ChatImage).material;
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
    AudioManager.Instance.LoadAndPlayBGM(BGMType.Main, (byte) 1);
    NewbieManager.CheckNewbie();
    if (NewbieManager.IsNewbie)
      Camera.main.transform.position = new Vector3(-26.9f, 180f, 154.9f);
    AssetManager.Instance.AssetManagerState = AssetState.Ready;
  }

  protected override void UpdateReady(byte[] meg)
  {
    if (DataManager.StageDataController.currentWorldMode == WorldMode.OpenUp && this.HideUI == (byte) 0)
    {
      DataManager.msgBuffer[0] = (byte) 14;
      this.UpdateNews(DataManager.msgBuffer);
    }
    if (NetworkManager.Connected())
      GUIManager.Instance.HideUILock(EUILock.Network);
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Update);
    this.doorController.LoadMainEff(EMapEffectKind.ORIGIN);
  }

  protected override void UpdateRun(byte[] meg)
  {
    this.worldController.updateDelegates[(int) this.worldController.worldState]();
  }
}
