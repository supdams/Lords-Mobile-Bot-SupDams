// Decompiled with JetBrains decompiler
// Type: Cosmos
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class Cosmos : Gameplay
{
  private Totality totalityController;
  private Door doorController;

  ~Cosmos()
  {
  }

  private void UpdateWorld()
  {
    if ((Object) this.totalityController != (Object) null)
    {
      this.totalityController.ClearEffect();
      Object.DestroyObject((Object) this.totalityController.gameObject);
    }
    this.totalityController = (Totality) null;
    ParticleManager.Instance.Clear();
    ParticleManager.Instance.Setup();
    AudioManager.Instance.LoadAndPlayBGM(BGMType.Legion, (byte) 1);
    GameObject gameObject = new GameObject("TotalityGroup");
    gameObject.transform.SetParent(((Component) GUIManager.Instance.m_UICanvas).transform, false);
    gameObject.transform.SetAsFirstSibling();
    this.totalityController = gameObject.GetComponent<Totality>();
    if ((Object) this.totalityController == (Object) null)
      this.totalityController = gameObject.AddComponent<Totality>();
    gameObject.transform.localScale = Vector3.one * DataManager.MapDataController.worldZoomSize;
    this.doorController.notifyHomeBtnPos();
    this.doorController.SetCapitalLocation((ushort) this.totalityController.worldMapController.homePos.x, (ushort) this.totalityController.worldMapController.homePos.y);
    this.totalityController.worldMapController.CheckCenterPos();
    if (this.doorController.m_WindowStack.Count != 0)
      this.totalityController.gameObject.SetActive(false);
    byte kingdomtableid = (byte) ((uint) DataManager.MapDataController.WorldKingdomTableIDcounter & 31U);
    for (byte index = 0; (int) index < DataManager.MapDataController.WorldKingdomTable.Length; ++index)
    {
      if (DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomID != (ushort) 0)
      {
        KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomID);
        int num = (int) DataManager.MapDataController.WorldMaxX - (int) DataManager.MapDataController.WorldMinX + 1;
        if ((int) DataManager.MapDataController.TileMapKingdomID[(int) recordByKey.worldPosX - (int) DataManager.MapDataController.WorldMinX + ((int) recordByKey.worldPosY - (int) DataManager.MapDataController.WorldMinY) * num].tableID == (int) kingdomtableid)
          this.totalityController.UpdateKingdom(kingdomtableid, (byte) 25);
      }
      kingdomtableid = (byte) ((uint) (byte) ((uint) kingdomtableid + 1U) & 31U);
    }
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
  }

  protected override void UpdateNews(byte[] meg)
  {
    switch ((GAME_PLAYER_NEWS) meg[0])
    {
      case GAME_PLAYER_NEWS.Network_Update:
        if (meg[1] == (byte) 0)
        {
          if (!((Object) this.totalityController != (Object) null))
            break;
          this.totalityController.UpdateNetwork();
          break;
        }
        if (meg[1] == (byte) 43)
        {
          this.doorController.ViewKingdom();
          break;
        }
        if (meg[1] == (byte) 42 || meg[1] == (byte) 44)
        {
          if ((int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
            break;
          DataManager.MapDataController.FocusKingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
          DataManager.MapDataController.FocusKingdomPeriod = DataManager.MapDataController.OtherKingdomData.kingdomPeriod;
          GUIManager.Instance.HideUILock(EUILock.Normal);
          DataManager.MapDataController.gotoKingdomState = (byte) 0;
          this.doorController.HideLoadingImg();
          break;
        }
        if (meg[1] != (byte) 35 || !((Object) this.totalityController != (Object) null))
          break;
        this.totalityController.WorldMapNameFontTextureRebuilt();
        break;
      case GAME_PLAYER_NEWS.COSMOS_UpdateKingdom:
        if (!((Object) this.totalityController != (Object) null))
          break;
        this.totalityController.UpdateKingdom(meg[1], meg[2]);
        break;
      case GAME_PLAYER_NEWS.COSMOS_ShowMapLoading:
        this.doorController.ShowLoadingImg();
        break;
      case GAME_PLAYER_NEWS.COSMOS_FinishMapLoading:
        this.doorController.HideLoadingImg();
        break;
      case GAME_PLAYER_NEWS.COSMOS_GoHomePosIn:
      case GAME_PLAYER_NEWS.COSMOS_GoHomePosOut:
        if (!((Object) this.totalityController != (Object) null))
          break;
        this.totalityController.worldMapController.setGoHomeButtonPos((GAME_PLAYER_NEWS) meg[0]);
        break;
      case GAME_PLAYER_NEWS.COSMOS_HomeInSide:
        this.doorController.SetShowHomeBtn(false);
        break;
      case GAME_PLAYER_NEWS.COSMOS_HomeOutSide:
        this.doorController.SetShowHomeBtn(true);
        break;
      case GAME_PLAYER_NEWS.COSMOS_GoHomeOffSetUpdate:
        this.doorController.SetHomeBtnLocation((ushort) GameConstants.ConvertBytesToFloat(meg, 1), (ushort) GameConstants.ConvertBytesToFloat(meg, 5));
        break;
      case GAME_PLAYER_NEWS.COSMOS_FinishClickKingdom:
        this.doorController.ViewKingdom();
        break;
      case GAME_PLAYER_NEWS.COSMOS_UpdatePos:
        this.doorController.UpdateLocation((ushort) GameConstants.ConvertBytesToFloat(meg, 1), (ushort) GameConstants.ConvertBytesToFloat(meg, 5), GameConstants.ConvertBytesToFloat(meg, 9), GameConstants.ConvertBytesToFloat(meg, 13));
        break;
      case GAME_PLAYER_NEWS.COSMOS_DoorOpenMenu:
        if (!((Object) this.totalityController != (Object) null) || !this.totalityController.gameObject.activeSelf)
          break;
        this.totalityController.gameObject.SetActive(false);
        break;
      case GAME_PLAYER_NEWS.COSMOS_DoorCloseMenu:
        if (!((Object) this.totalityController != (Object) null) || this.totalityController.gameObject.activeSelf)
          break;
        this.totalityController.gameObject.SetActive(true);
        break;
      case GAME_PLAYER_NEWS.COSMOS_GoToKingdom:
        ushort kingdomID = GameConstants.ConvertBytesToUShort(meg, 1);
        if ((int) kingdomID == (int) ActivityManager.Instance.KOWKingdomID && ActivityManager.Instance.IsNobilityWarRunning())
        {
          this.doorController.GoToKingdom(kingdomID, (int) DataManager.MapDataController.GetYolkMapID((ushort) ActivityManager.Instance.FederalFullEventTimeWonderID, kingdomID));
          break;
        }
        this.doorController.GoToKingdom(kingdomID, (int) DataManager.MapDataController.GetYolkMapID((ushort) 0, kingdomID));
        break;
      case GAME_PLAYER_NEWS.COSMOS_MoveToKingdom:
        if (!((Object) this.totalityController != (Object) null))
          break;
        this.totalityController.MoveToKingdom(GameConstants.ConvertBytesToUShort(meg, 1));
        break;
      case GAME_PLAYER_NEWS.COSMOS_UpdateWorld:
        this.UpdateWorld();
        break;
      case GAME_PLAYER_NEWS.COSMOS_MoveToMyKingdom:
        this.doorController.GoToGroup(-1, (byte) 0);
        break;
      case GAME_PLAYER_NEWS.COSMOS_ReflashKingdomTitleButton:
        if (!((Object) this.totalityController != (Object) null))
          break;
        this.totalityController.mapGraphicController.reflashGraphicImage();
        break;
      case GAME_PLAYER_NEWS.COSMOS_reflashKvKKingdomType:
        byte kingdomTableID = 0;
        for (int index = 0; index < ActivityManager.Instance.MatchKingdomID.Length; ++index)
        {
          if (ActivityManager.Instance.MatchKingdomID[index] > (ushort) 0 && (int) ActivityManager.Instance.MatchKingdomID[index] != (int) DataManager.MapDataController.kingdomData.kingdomID && DataManager.MapDataController.GetWorldKingdomTableID(ActivityManager.Instance.MatchKingdomID[index], out kingdomTableID))
          {
            DataManager.msgBuffer[0] = (byte) 105;
            GameConstants.GetBytes((ushort) kingdomTableID, DataManager.msgBuffer, 1);
            GameConstants.GetBytes((ushort) 20, DataManager.msgBuffer, 2);
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          }
        }
        break;
    }
  }

  protected override void UpdateNext(byte[] meg)
  {
    DataManager.MapDataController.OutMap();
    DataManager.MapDataController.worldZoomSize = this.totalityController.transform.localScale.x;
    if ((Object) this.doorController != (Object) null)
    {
      this.doorController.DeSpawnMainEff();
      if ((Object) this.doorController.m_GroundInfo.TileMapMat != (Object) null)
      {
        Object.DestroyObject((Object) this.doorController.m_GroundInfo.TileMapMat);
        this.doorController.m_GroundInfo.TileMapMat = (Material) null;
      }
      this.doorController.setFightButton((AssetBundle) null);
      this.doorController.m_GroundInfo.Close();
      this.doorController.SetTileMapController((MapTile) null);
      GUIManager.Instance.CloseMenu(EGUIWindow.Door);
    }
    this.doorController = (Door) null;
    if ((Object) this.totalityController != (Object) null)
    {
      this.totalityController.ClearEffect();
      Object.DestroyObject((Object) this.totalityController.gameObject);
    }
    this.totalityController = (Totality) null;
    GUIManager.Instance.ClearMapSprite();
    GUIManager.Instance.DestroyTechIconSprite();
    GUIManager.Instance.UnloadWonderSprite();
    GUIManager.Instance.EmojiManager.Clear();
    ParticleManager.Instance.Clear();
  }

  protected override void UpdateLoad(byte[] meg)
  {
    if ((int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
    {
      DataManager.MapDataController.FocusKingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
      DataManager.MapDataController.FocusKingdomPeriod = DataManager.MapDataController.OtherKingdomData.kingdomPeriod;
    }
    RenderSettings.ambientLight = (Color) GameConstants.DefaultAmbientLight;
    DataManager.Instance.GoToBattleOrWar = GameplayKind.CHAOS;
    GameManager.RemoveObserver((byte) 0, (byte) 3, (IObserver) this);
    GameManager.RegisterObserver((byte) 1, (byte) 0, (IObserver) this);
    ParticleManager.Instance.Setup();
    if ((double) Camera.main.fieldOfView != 25.0)
      Camera.main.fieldOfView = 25f;
    this.doorController = GUIManager.Instance.OpenMenu(EGUIWindow.Door, bCameraMode: true) as Door;
    this.doorController.SwitchMapMode(EUIOriginMapMode.WorldMap);
    GUIManager.Instance.InitTowerSprite();
    DataManager.MissionDataManager.SetMissionComplete((ushort) 132);
    DataManager.Instance.RoleBookMark.CheckUpdate(false);
    if (DataManager.Instance.RoleAlliance.Id > 0U)
      DataManager.Instance.RoleBookMark.CheckUpdate_Alliance(false);
    AudioManager.Instance.LoadAndPlayBGM(BGMType.Legion, (byte) 1);
    AssetManager.Instance.AssetManagerState = AssetState.Ready;
  }

  protected override void UpdateReady(byte[] meg)
  {
    GameObject gameObject = new GameObject("TotalityGroup");
    gameObject.transform.SetParent(((Component) GUIManager.Instance.m_UICanvas).transform, false);
    gameObject.transform.SetAsFirstSibling();
    this.totalityController = gameObject.GetComponent<Totality>();
    if ((Object) this.totalityController == (Object) null)
      this.totalityController = gameObject.AddComponent<Totality>();
    gameObject.transform.localScale = Vector3.one * DataManager.MapDataController.worldZoomSize;
    this.doorController.notifyHomeBtnPos();
    this.doorController.SetCapitalLocation((ushort) this.totalityController.worldMapController.homePos.x, (ushort) this.totalityController.worldMapController.homePos.y);
    this.totalityController.worldMapController.CheckCenterPos();
    if (this.doorController.m_WindowStack.Count != 0)
      this.totalityController.gameObject.SetActive(false);
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
  }

  protected override void UpdateRun(byte[] meg)
  {
  }
}
