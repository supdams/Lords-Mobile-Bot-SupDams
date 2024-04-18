// Decompiled with JetBrains decompiler
// Type: CHAOS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class CHAOS : Gameplay
{
  public Realm realmController;
  private Door doorController;

  ~CHAOS()
  {
  }

  private void UpdateMap(ushort ZoneID, byte resetYolk = 0)
  {
    if (!((Object) this.realmController != (Object) null))
      return;
    if (resetYolk == (byte) 2 && (Object) this.realmController.mapTileController != (Object) null)
    {
      bool flag = false;
      if (ActivityManager.Instance.KVKHuntOrder == (byte) 1)
      {
        if (this.realmController.mapTileController.frontIsSheep != (byte) 0)
        {
          flag = true;
          this.realmController.mapTileController.frontIsSheep = (byte) 0;
          this.realmController.mapTileController.UpdateTickImage();
        }
      }
      else if (ActivityManager.Instance.KVKHuntOrder == (byte) 2)
      {
        if (this.realmController.mapTileController.frontIsSheep != (byte) 1)
        {
          flag = true;
          this.realmController.mapTileController.frontIsSheep = (byte) 1;
          this.realmController.mapTileController.UpdateTickImage();
        }
      }
      else if (this.realmController.mapTileController.frontIsSheep != (byte) 3)
      {
        flag = true;
        this.realmController.mapTileController.frontIsSheep = (byte) 3;
      }
      if (!flag)
        return;
      this.realmController.UpdateTileMap(ZoneID);
      this.realmController.ResetYolk();
    }
    else if (resetYolk == (byte) 1)
    {
      if (!this.realmController.ResetYolk())
        return;
      this.realmController.UpdateTileMap(ZoneID);
    }
    else
      this.realmController.UpdateTileMap(ZoneID);
  }

  private void UpdatePoint(uint LayoutMapInfoID)
  {
    if (!((Object) this.realmController != (Object) null))
      return;
    this.realmController.UpdatePoint(LayoutMapInfoID);
  }

  private void CheckFocus()
  {
    if (DataManager.MapDataController.isOpenGroundInfo == (byte) 1)
    {
      AudioManager.Instance.PlayUISFX(UIKind.UIClickKindom);
      this.doorController.OpenGroundInfo(DataManager.MapDataController.FocusMapID);
      DataManager.MapDataController.isOpenGroundInfo = (byte) 0;
    }
    if (DataManager.MapDataController.isMarkGroundInfo == (byte) 1)
    {
      if ((Object) this.realmController != (Object) null)
        this.realmController.Mark();
      DataManager.MapDataController.isMarkGroundInfo = (byte) 0;
    }
    if (DataManager.MapDataController.FocusGroupID == (byte) 10 || !((Object) this.realmController != (Object) null))
      return;
    this.realmController.ClickGroup();
  }

  private void ReLoadMap()
  {
    if ((Object) this.doorController != (Object) null)
    {
      this.doorController.ShowKingdomMark();
      if ((Object) this.doorController.m_GroundInfo.TileMapMat != (Object) null)
      {
        Object.DestroyObject((Object) this.doorController.m_GroundInfo.TileMapMat);
        this.doorController.m_GroundInfo.TileMapMat = (Material) null;
      }
      this.doorController.setFightButton((AssetBundle) null);
      this.doorController.m_GroundInfo.Close();
      this.doorController.SetTileMapController((MapTile) null);
    }
    if ((Object) this.realmController != (Object) null)
    {
      this.realmController.mapTileController.centerMapID = -1;
      this.realmController.ClearEffect();
      Object.DestroyObject((Object) this.realmController.gameObject);
    }
    this.realmController = (Realm) null;
    this.doorController.DeSpawnMainEff();
    ParticleManager.Instance.Clear();
    ParticleManager.Instance.Setup();
    AudioManager.Instance.LoadAndPlayBGM(BGMType.Legion, (byte) 1);
    GameObject gameObject = new GameObject("RealmGroup");
    gameObject.transform.SetParent(((Component) GUIManager.Instance.m_UICanvas).transform, false);
    gameObject.transform.SetAsFirstSibling();
    this.realmController = gameObject.GetComponent<Realm>();
    if ((Object) this.realmController == (Object) null)
      this.realmController = gameObject.AddComponent<Realm>();
    gameObject.transform.localScale = Vector3.one * DataManager.MapDataController.zoomSize;
    Vector2 mapPosbySpriteId = GameConstants.getTileMapPosbySpriteID(DataManager.Instance.RoleAttr.CapitalPoint);
    this.doorController.notifyHomeBtnPos();
    this.doorController.SetCapitalLocation((ushort) mapPosbySpriteId.x, (ushort) mapPosbySpriteId.y);
    this.doorController.SetTileMapController(this.realmController.mapTileController);
    this.realmController.CheckCenterPos();
    if (this.doorController.m_WindowStack.Count != 0)
    {
      GameManager.RegisterObserver((byte) 0, (byte) 3, (IObserver) this);
      this.realmController.gameObject.SetActive(false);
    }
    if ((int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
      this.doorController.SetShowHomeBtn(false);
    if (DataManager.MapDataController.FocusKingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
      this.doorController.LoadMainEff(EMapEffectKind.WORLDWAR);
    else
      this.doorController.LoadMainEff(EMapEffectKind.CHAOS);
  }

  protected override void UpdateNews(byte[] meg)
  {
    switch (meg[0])
    {
      case 0:
        NetworkNews networkNews = (NetworkNews) meg[1];
        switch (networkNews)
        {
          case NetworkNews.Login:
            if ((int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
            {
              if (!NetworkManager.GuestController.Connecting() || !NetworkManager.GuestController.Connected())
              {
                GUIManager.Instance.ShowUILock(EUILock.Normal);
                NetworkManager.Instance.ViewKingdom(DataManager.MapDataController.FocusKingdomID);
              }
            }
            else if ((Object) this.realmController != (Object) null)
              this.realmController.UpdateNetwork();
            DataManager.MapDataController.RequsetYolkswitch();
            return;
          case NetworkNews.Refresh_Asset:
            if (meg[2] != (byte) 0 || meg[3] != (byte) 0)
              return;
            this.UpdateMap((ushort) 1024, (byte) 0);
            return;
          default:
            switch (networkNews - (byte) 42)
            {
              case NetworkNews.Login:
                if ((int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
                  return;
                DataManager.MapDataController.FocusKingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
                GUIManager.Instance.HideUILock(EUILock.Normal);
                DataManager.MapDataController.gotoKingdomState = (byte) 0;
                if (GUIManager.Instance.pDVMgr == null)
                  return;
                GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
                return;
              case NetworkNews.Fallout:
                if ((int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
                {
                  if (DataManager.MapDataController.gotoKingdomState == (byte) 0)
                  {
                    if ((Object) this.realmController != (Object) null)
                      this.realmController.UpdateNetwork();
                    GUIManager.Instance.HideUILock(EUILock.Normal);
                  }
                  else
                  {
                    if (GUIManager.Instance.m_HUDMessage != null && GUIManager.Instance.m_HUDMessage.MapHud != null)
                      GUIManager.Instance.m_HUDMessage.MapHud.AddChangeKindomMapMsg();
                    this.ReLoadMap();
                    this.doorController.ViewKingdom();
                  }
                  if (GUIManager.Instance.pDVMgr != null)
                    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
                }
                else
                  NetworkManager.Instance.ViewClose();
                Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
                if (!(bool) (Object) menu)
                  return;
                menu.RefreshMainEff();
                return;
              case NetworkNews.Refresh:
                if ((int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
                  return;
                if (DataManager.MapDataController.gotoKingdomState == (byte) 0)
                {
                  GUIManager.Instance.ShowUILock(EUILock.Normal);
                  NetworkManager.Instance.ViewKingdom(DataManager.MapDataController.FocusKingdomID);
                  return;
                }
                DataManager.MapDataController.FocusKingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
                GUIManager.Instance.HideUILock(EUILock.Normal);
                DataManager.MapDataController.gotoKingdomState = (byte) 0;
                GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
                return;
              default:
                if (networkNews != NetworkNews.Refresh_FontTextureRebuilt || !((Object) this.realmController != (Object) null))
                  return;
                this.realmController.BloodNameFontTextureRebuilt();
                return;
            }
        }
      case 52:
        this.UpdateMap(GameConstants.ConvertBytesToUShort(meg, 1), (byte) 0);
        break;
      case 53:
        if (!((Object) this.realmController != (Object) null))
          break;
        if (!this.realmController.isMyPointIn() || meg[1] == (byte) 1 || meg[1] == (byte) 2)
          this.UpdateMap((ushort) 1024, meg[1]);
        if (meg[1] == (byte) 2)
          break;
        this.realmController.ResetAllLine();
        break;
      case 54:
        this.UpdatePoint(GameConstants.ConvertBytesToUInt(meg, 1));
        break;
      case 55:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.DelLine((int) GameConstants.ConvertBytesToUInt(meg, 1), meg[5]);
        break;
      case 56:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.AddLine((int) GameConstants.ConvertBytesToUInt(meg, 1));
        break;
      case 57:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.UpdateLineOwner((int) GameConstants.ConvertBytesToUInt(meg, 1));
        break;
      case 58:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.UpdateLineTag((int) GameConstants.ConvertBytesToUInt(meg, 1));
        break;
      case 59:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.UpdateLinePos(GameConstants.ConvertBytesToFloat(meg, 1), GameConstants.ConvertBytesToFloat(meg, 5));
        break;
      case 60:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.UpdateLineBegin((int) GameConstants.ConvertBytesToUInt(meg, 1));
        break;
      case 61:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.UpdateLineEmoji((int) GameConstants.ConvertBytesToUInt(meg, 1));
        break;
      case 62:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.UpdateLineWeapon((int) GameConstants.ConvertBytesToUInt(meg, 1));
        break;
      case 63:
        this.doorController.UpdateLocation((ushort) GameConstants.ConvertBytesToFloat(meg, 1), (ushort) GameConstants.ConvertBytesToFloat(meg, 5), GameConstants.ConvertBytesToFloat(meg, 9), GameConstants.ConvertBytesToFloat(meg, 13));
        break;
      case 64:
        AudioManager.Instance.PlayUISFX(UIKind.UIClickKindom);
        if (meg[13] == (byte) 10)
          this.doorController.OpenMenu(EGUIWindow.UI_MapMonster, GameConstants.ConvertBytesToInt(meg, 1));
        else
          this.doorController.OpenGroundInfo(GameConstants.ConvertBytesToInt(meg, 1), (POINT_KIND) meg[13]);
        if (!((Object) this.realmController != (Object) null))
          break;
        if (meg[13] == (byte) 11)
        {
          if (!((Object) this.realmController.mapTileController != (Object) null))
            break;
          Vector2 tilePosition = this.realmController.mapTileController.getTilePosition(GameConstants.ConvertBytesToUShort(meg, 5), meg[9]);
          this.realmController.ClickSelect(tilePosition.x, tilePosition.y, true);
          break;
        }
        this.realmController.ClickSelect(GameConstants.ConvertBytesToFloat(meg, 5), GameConstants.ConvertBytesToFloat(meg, 9), false);
        break;
      case 65:
        if ((Object) this.realmController != (Object) null)
          this.realmController.stopFocusGroup();
        this.doorController.m_GroundInfo.Close();
        break;
      case 66:
        AudioManager.Instance.PlayUISFX(UIKind.UIClickKindom);
        this.doorController.OpenGroundInfo((int) GameConstants.ConvertBytesToUInt(meg, 1), POINT_KIND.PK_UNDEFINED);
        break;
      case 67:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.CloseEffect();
        break;
      case 68:
        this.doorController.ShowLoadingImg();
        break;
      case 69:
        this.doorController.HideLoadingImg();
        break;
      case 70:
        if (this.doorController.m_GroundInfo != null)
          this.doorController.m_GroundInfo.UpdateUI(0, 0);
        this.CheckFocus();
        GameManager.OnRefresh(NetworkNews.Refresh_QBarTime);
        break;
      case 71:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.CheckLineUpdate();
        break;
      case 72:
      case 73:
        if (!((Object) this.realmController != (Object) null) || !((Object) this.realmController.mapTileController != (Object) null))
          break;
        this.realmController.mapTileController.setGoHomeButtonPos((GAME_PLAYER_NEWS) meg[0]);
        break;
      case 74:
        this.doorController.SetShowHomeBtn(false);
        break;
      case 75:
        this.doorController.SetShowHomeBtn(true);
        break;
      case 76:
        this.doorController.SetHomeBtnLocation((ushort) GameConstants.ConvertBytesToFloat(meg, 1), (ushort) GameConstants.ConvertBytesToFloat(meg, 5));
        break;
      case 77:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.CloseSelect();
        break;
      case 78:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.CloseMark();
        break;
      case 79:
        this.doorController.CheckMapID((int) GameConstants.ConvertBytesToUInt(meg, 1));
        break;
      case 80:
        if (this.doorController.m_GroundInfo == null)
          break;
        this.doorController.m_GroundInfo.UpdateUI(1, (int) GameConstants.ConvertBytesToUInt(meg, 1));
        break;
      case 81:
        this.doorController.GoToGroup((int) GameConstants.ConvertBytesToUShort(meg, 1), (byte) 0);
        break;
      case 82:
        this.CheckFocus();
        break;
      case 83:
        if ((Object) this.realmController != (Object) null)
          this.realmController.UpdateHomePos();
        Vector2 mapPosbySpriteId = GameConstants.getTileMapPosbySpriteID(DataManager.Instance.RoleAttr.CapitalPoint);
        this.doorController.ShowKingdomMark();
        this.doorController.SetCapitalLocation((ushort) mapPosbySpriteId.x, (ushort) mapPosbySpriteId.y);
        this.doorController.GoToGroup(-1, (byte) 0, meg[1] == (byte) 1);
        break;
      case 84:
        if (!((Object) this.realmController != (Object) null) || !this.realmController.gameObject.activeSelf)
          break;
        GameManager.RegisterObserver((byte) 0, (byte) 3, (IObserver) this);
        this.realmController.gameObject.SetActive(false);
        break;
      case 85:
        if (!((Object) this.realmController != (Object) null) || this.realmController.gameObject.activeSelf)
          break;
        GameManager.RemoveObserver((byte) 0, (byte) 3, (IObserver) this);
        this.realmController.gameObject.SetActive(true);
        break;
      case 86:
        if (!((Object) this.realmController != (Object) null))
          break;
        int index = (int) GameConstants.ConvertBytesToUInt(meg, 1);
        this.realmController.mapTileController.UpdateMapNPCHurt((uint) GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[index].start.zoneID, DataManager.MapDataController.MapLineTable[index].start.pointID));
        break;
      case 87:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.mapTileController.UpdateMapNPCBlood(GameConstants.ConvertBytesToUInt(meg, 1), GameConstants.ConvertBytesToFloat(meg, 5));
        break;
      case 88:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.UpdateMapNPCNameBlood(meg[1], meg[2], GameConstants.ConvertBytesToFloat(meg, 3));
        break;
      case 89:
        this.ReLoadMap();
        break;
      case 90:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.UpdatePoint(meg[1], meg[2]);
        break;
      case 91:
        if (!((Object) this.realmController != (Object) null))
          break;
        int num = (int) GameConstants.ConvertBytesToUInt(meg, 1);
        if (!((Object) this.realmController.mapTileController != (Object) null))
          break;
        this.realmController.mapTileController.UpdateMapNPCFighterLeave((uint) GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[num].start.zoneID, DataManager.MapDataController.MapLineTable[num].start.pointID), num);
        break;
      case 92:
        if (!((Object) this.realmController != (Object) null) || this.realmController.mapLineController == null)
          break;
        this.realmController.mapLineController.ResetLineState();
        break;
      case 93:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.reflashEffect();
        if (!((Object) this.realmController.mapTileController != (Object) null))
          break;
        this.realmController.mapTileController.ReflashGraphic();
        break;
      case 94:
        if (!((Object) this.doorController != (Object) null))
          break;
        this.doorController.SetPVPWonderID(GameConstants.ConvertBytesToUShort(meg, 1));
        break;
      case 95:
        if (!((Object) this.doorController != (Object) null))
          break;
        GameConstants.ConvertBytesToUShort(meg, 1);
        this.doorController.ClearPVPWonderID();
        break;
      case 96:
        if (!((Object) this.doorController != (Object) null))
          break;
        this.doorController.BeginFadeOut();
        break;
      case 97:
        if (!((Object) this.doorController != (Object) null))
          break;
        this.doorController.BeginFadeIn();
        break;
      case 98:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.ShowDamageRange(GameConstants.ConvertBytesToUShort(meg, 1), meg[3], GameConstants.ConvertBytesToUShort(meg, 4));
        break;
      case 99:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.HideDamageRange();
        break;
      case 100:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.UseMapWeapon(GameConstants.ConvertBytesToUShort(meg, 1), GameConstants.ConvertBytesToUShort(meg, 3));
        break;
      case 101:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.StopMapWeaponShow();
        break;
      case 102:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.MapWeaponAttack(GameConstants.ConvertBytesToUShort(meg, 1), meg[3], GameConstants.ConvertBytesToUShort(meg, 4), GameConstants.ConvertBytesToFloat(meg, 6));
        break;
      case 103:
        if (!((Object) this.realmController != (Object) null))
          break;
        this.realmController.MapWeaponDefense(GameConstants.ConvertBytesToUShort(meg, 1), meg[3], GameConstants.ConvertBytesToUShort(meg, 4), GameConstants.ConvertBytesToFloat(meg, 6));
        break;
      case 104:
        if (!((Object) this.doorController != (Object) null))
          break;
        this.doorController.CheckFocusGroup();
        DataManager.MapDataController.FocusGroupID = (byte) 10;
        this.doorController.GoToMapID(DataManager.MapDataController.OtherKingdomData.kingdomID, DataManager.Instance.RoleAttr.CapitalPoint, (byte) 0, (byte) 1);
        break;
    }
  }

  protected override void UpdateNext(byte[] meg)
  {
    if (NetworkManager.GuestController.Connected() || NetworkManager.GuestController.Connecting())
      NetworkManager.Instance.ViewClose();
    DataManager.MapDataController.OutMap();
    DataManager.MapDataController.zoomSize = this.realmController.transform.localScale.x;
    if ((Object) this.doorController != (Object) null)
    {
      this.doorController.DeSpawnMainEff();
      this.doorController.ShowKingdomMark(true);
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
    if ((Object) this.realmController != (Object) null)
    {
      this.realmController.ClearEffect();
      Object.DestroyObject((Object) this.realmController.gameObject);
    }
    this.realmController = (Realm) null;
    GUIManager.Instance.ClearMapSprite();
    GUIManager.Instance.DestroyTechIconSprite();
    GUIManager.Instance.UnloadWonderSprite();
    GUIManager.Instance.EmojiManager.Clear();
    ParticleManager.Instance.Clear();
  }

  protected override void UpdateLoad(byte[] meg)
  {
    if ((int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID && !NetworkManager.GuestController.Connected() && !NetworkManager.GuestController.Connecting())
    {
      ++DataManager.MapDataController.gotoKingdomState;
      GUIManager.Instance.ShowUILock(EUILock.Normal);
      NetworkManager.Instance.ViewKingdom(DataManager.MapDataController.FocusKingdomID);
    }
    RenderSettings.ambientLight = (Color) GameConstants.DefaultAmbientLight;
    DataManager.Instance.GoToBattleOrWar = GameplayKind.CHAOS;
    GameManager.RemoveObserver((byte) 0, (byte) 3, (IObserver) this);
    GameManager.RegisterObserver((byte) 1, (byte) 0, (IObserver) this);
    ParticleManager.Instance.Setup();
    if ((double) Camera.main.fieldOfView != 25.0)
      Camera.main.fieldOfView = 25f;
    this.doorController = GUIManager.Instance.OpenMenu(EGUIWindow.Door, bCameraMode: true) as Door;
    this.doorController.SwitchMapMode(EUIOriginMapMode.KingdomMap);
    this.doorController.ShowKingdomMark();
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
    GameObject gameObject = new GameObject("RealmGroup");
    gameObject.transform.SetParent(((Component) GUIManager.Instance.m_UICanvas).transform, false);
    gameObject.transform.SetAsFirstSibling();
    this.realmController = gameObject.GetComponent<Realm>();
    if ((Object) this.realmController == (Object) null)
      this.realmController = gameObject.AddComponent<Realm>();
    gameObject.transform.localScale = Vector3.one * DataManager.MapDataController.zoomSize;
    Vector2 mapPosbySpriteId = GameConstants.getTileMapPosbySpriteID(DataManager.Instance.RoleAttr.CapitalPoint);
    this.doorController.notifyHomeBtnPos();
    this.doorController.SetCapitalLocation((ushort) mapPosbySpriteId.x, (ushort) mapPosbySpriteId.y);
    this.doorController.SetTileMapController(this.realmController.mapTileController);
    this.realmController.CheckCenterPos();
    if (this.doorController.m_WindowStack.Count != 0)
    {
      GameManager.RegisterObserver((byte) 0, (byte) 3, (IObserver) this);
      this.realmController.gameObject.SetActive(false);
    }
    if ((int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
    {
      this.doorController.SetShowHomeBtn(false);
      if (NetworkManager.GuestController.Connected())
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
    }
    else
      GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
    if (DataManager.MapDataController.FocusKingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
      this.doorController.LoadMainEff(EMapEffectKind.WORLDWAR);
    else
      this.doorController.LoadMainEff(EMapEffectKind.CHAOS);
  }

  protected override void UpdateRun(byte[] meg)
  {
    this.realmController.LineControllerUpdate();
    this.realmController.NPCControllerUpdate();
  }
}
