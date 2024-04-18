// Decompiled with JetBrains decompiler
// Type: Realm
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.EventSystems;

#nullable disable
public class Realm : 
  MonoBehaviour,
  IPointerUpHandler,
  IDragHandler,
  IPointerDownHandler,
  IEventSystemHandler
{
  public MapTile mapTileController;
  public Transform RealmGroup_3DTransform;
  public FlowLineFactory mapLineController;
  private RectTransform Canvasrectran;
  private int TileBaseABKey;
  private int MapTileGraphicABKey;
  private float CanvasrectranScale;
  private MapTileLevel TileLevelController;
  private MapTileSelect TileSelectController;
  private MapTileBloodName mapNameController;
  private MapTileGraphic mapGraphicController;
  private MapTileNPC mapNPCController;
  private MapTileYolk TileYolkController;
  private MapTileEffect mapEffectController;
  private MapTileModel mapTileModelController;
  private ushort mapWeaponID;
  private ushort mapSkillID;

  protected void Awake()
  {
    this.RealmGroup_3DTransform = new GameObject("RealmGroup3D").transform;
    this.RealmGroup_3DTransform.localScale = Vector3.one * DataManager.MapDataController.zoomSize;
    GameObject gameObject = UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle("UI/TileBase", out this.TileBaseABKey).mainAsset) as GameObject;
    RectTransform component = gameObject.GetComponent<RectTransform>();
    this.Canvasrectran = GUIManager.Instance.pDVMgr.CanvasRT;
    component.sizeDelta = this.Canvasrectran.sizeDelta;
    if (GUIManager.Instance.m_UICanvas.renderMode == 1)
      DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale = this.CanvasrectranScale = ((Transform) this.Canvasrectran).localScale.x;
    else
      this.CanvasrectranScale = DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
    this.mapTileController = gameObject.GetComponent<MapTile>();
    if ((UnityEngine.Object) this.mapTileController == (UnityEngine.Object) null)
      this.mapTileController = gameObject.AddComponent<MapTile>();
    ((Transform) component).SetParent(((Component) GUIManager.Instance.m_UICanvas).transform.GetChild(0), false);
    ((Transform) component).SetAsFirstSibling();
    this.TileLevelController = new MapTileLevel(this.transform, this.mapTileController.TileSprites);
    this.TileSelectController = new MapTileSelect(this.transform, this.mapTileController.TileSprites);
    this.TileYolkController = new MapTileYolk(this.transform);
    this.mapGraphicController = new MapTileGraphic(this.transform, UnityEngine.Object.Instantiate(AssetManager.GetAssetBundle("UI/MapTileGraphic", out this.MapTileGraphicABKey).mainAsset) as GameObject);
    this.mapNameController = new MapTileBloodName(this.transform);
    this.mapNPCController = new MapTileNPC(this.RealmGroup_3DTransform);
    this.mapTileController.setNPC(this.mapNPCController);
    this.mapLineController = new FlowLineFactory(this.RealmGroup_3DTransform, this.mapNameController, this.mapTileController.TileBaseScale);
    this.mapTileController.setLine(this.mapLineController);
    this.mapEffectController = new MapTileEffect(this.RealmGroup_3DTransform, this.mapTileController.TileBaseScale);
    this.mapTileController.setEffect(this.mapEffectController);
    this.mapTileModelController = new MapTileModel(this.RealmGroup_3DTransform, this.mapTileController.TileBaseScale);
    this.mapTileController.setWeapon(this.mapTileModelController);
    this.mapTileController.setLevel(this.TileLevelController);
    this.mapTileController.setBloodName(this.mapNameController);
    this.mapTileController.setGraphicImage(this.mapGraphicController);
    this.mapTileController.setRealmGroup_3DTransform(this.RealmGroup_3DTransform);
    this.mapTileController.setYolk(this.TileYolkController);
  }

  protected void OnDestroy()
  {
    if (this.mapTileModelController != null)
      this.mapTileModelController.OnDestroy();
    this.mapTileModelController = (MapTileModel) null;
    if (this.mapNPCController != null)
      this.mapNPCController.OnDestroy();
    this.mapNPCController = (MapTileNPC) null;
    this.ClearEffect();
    if (this.mapGraphicController != null)
      this.mapGraphicController.OnDestroy();
    this.mapGraphicController = (MapTileGraphic) null;
    if (this.mapLineController != null)
      this.mapLineController.Clear();
    this.mapLineController = (FlowLineFactory) null;
    NewbieManager.ClearFakeLineData();
    if (this.mapNameController != null)
      this.mapNameController.OnDestroy();
    this.mapNameController = (MapTileBloodName) null;
    if (this.TileYolkController != null)
      this.TileYolkController.OnDestroy();
    this.TileYolkController = (MapTileYolk) null;
    if (this.TileSelectController != null)
      this.TileSelectController.OnDestroy();
    this.TileSelectController = (MapTileSelect) null;
    if (this.TileLevelController != null)
      this.TileLevelController.OnDestroy();
    this.TileLevelController = (MapTileLevel) null;
    if ((UnityEngine.Object) this.mapTileController != (UnityEngine.Object) null)
      UnityEngine.Object.DestroyObject((UnityEngine.Object) this.mapTileController.gameObject);
    this.mapTileController = (MapTile) null;
    this.Canvasrectran = (RectTransform) null;
    if ((UnityEngine.Object) this.RealmGroup_3DTransform != (UnityEngine.Object) null)
      UnityEngine.Object.DestroyObject((UnityEngine.Object) this.RealmGroup_3DTransform.gameObject);
    this.RealmGroup_3DTransform = (Transform) null;
    AssetManager.UnloadAssetBundle(this.TileBaseABKey);
    AssetManager.UnloadAssetBundle(this.MapTileGraphicABKey);
  }

  protected void Update()
  {
    this.LineControllerUpdate();
    this.TileSelectController.SelectUpdate();
    this.mapEffectController.EffectCheck();
    this.NPCControllerUpdate();
    this.mapTileModelController.MapTileModelUpdate();
  }

  public void OnDrag(PointerEventData eventData)
  {
    this.mapTileController.OnDrag(eventData);
    this.mapTileController.Movedelta = Vector2.zero;
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    this.mapTileController.OnPointerDown(eventData);
  }

  public void OnPointerUp(PointerEventData eventData)
  {
    this.mapTileController.OnPointerUp(eventData);
  }

  public void UpdateTileMap(ushort ZoneID) => this.mapTileController.UpdateTileMap(ZoneID);

  public void UpdatePoint(uint LayoutMapInfoID)
  {
    this.mapTileController.UpdatePoint(LayoutMapInfoID);
    POINT_KIND mapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind(LayoutMapInfoID);
    if (this.mapLineController == null || !DataManager.MapDataController.IsCityOrCamp(LayoutMapInfoID) && mapInfoPointKind != POINT_KIND.PK_YOLK || ((int) DataManager.MapDataController.PlayerPointTable[(int) DataManager.MapDataController.LayoutMapInfo[(IntPtr) LayoutMapInfoID].tableID].capitalFlag & (int) (byte) (1U | 2U)) == 0 && mapInfoPointKind != POINT_KIND.PK_YOLK)
      return;
    PointCode pointCode = new PointCode();
    GameConstants.MapIDToPointCode((int) LayoutMapInfoID, out pointCode.zoneID, out pointCode.pointID);
    this.mapLineController.PointModifyList.Add(new PointModifyNode()
    {
      Code = pointCode,
      Kind = mapInfoPointKind
    });
  }

  public void DelLine(int LineTableID, byte Send = 1)
  {
    if (this.mapLineController == null || !((UnityEngine.Object) DataManager.MapDataController.MapLineTable[LineTableID].lineObject != (UnityEngine.Object) null))
      return;
    if (!GameConstants.IsPetSkillLine(LineTableID))
    {
      if (DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == (byte) 27 && NetworkManager.ServerTime - (double) DataManager.MapDataController.MapLineTable[LineTableID].begin < 5.0)
        this.mapTileController.UpdateMapNPCFighterLeave((uint) GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[LineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].start.pointID), LineTableID);
      else if (DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == (byte) 12)
      {
        this.mapLineController.LastRallyName.ClearString();
        this.mapLineController.LastRallyName.Append(DataManager.MapDataController.MapLineTable[LineTableID].playerName);
      }
      if (Send != byte.MaxValue && (DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == (byte) 5 || DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == (byte) 6 || DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == (byte) 7 || DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == (byte) 12 || DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == (byte) 9))
      {
        bool flag = true;
        int mapId = GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[LineTableID].end.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].end.pointID);
        POINT_KIND pointKind = (POINT_KIND) DataManager.MapDataController.LayoutMapInfo[mapId].pointKind;
        if (pointKind == POINT_KIND.PK_NONE)
          flag = false;
        else if (DataManager.MapDataController.IsResources((uint) mapId))
        {
          if (DataManager.CompareStr(DataManager.MapDataController.ResourcesPointTable[(int) DataManager.MapDataController.LayoutMapInfo[mapId].tableID].playerName, string.Empty) == 0)
            flag = false;
        }
        else if (pointKind == POINT_KIND.PK_CITY && DataManager.CompareStr(DataManager.MapDataController.PlayerPointTable[(int) DataManager.MapDataController.LayoutMapInfo[mapId].tableID].allianceTag, DataManager.MapDataController.MapLineTable[LineTableID].allianceTag) == 0)
          flag = false;
        if (flag)
        {
          FakeRetreat fakeRetreat = new FakeRetreat(0);
          fakeRetreat.point = DataManager.MapDataController.MapLineTable[LineTableID].end;
          fakeRetreat.point2 = DataManager.MapDataController.MapLineTable[LineTableID].start;
          fakeRetreat.lineFlag = (EMarchEventType) DataManager.MapDataController.MapLineTable[LineTableID].lineFlag;
          bool bEase = true;
          ELineColor lineColorid = ELineColor.BLUE;
          EUnitSide unitSideid = EUnitSide.BLUE;
          DataManager.checkLineColorID(LineTableID, out lineColorid, out unitSideid, out bEase);
          fakeRetreat.unitSide = unitSideid;
          fakeRetreat.lineColor = lineColorid;
          fakeRetreat.playerName.ClearString();
          fakeRetreat.playerName.Append(DataManager.MapDataController.MapLineTable[LineTableID].playerName);
          fakeRetreat.allianceTag.ClearString();
          fakeRetreat.allianceTag.Append(DataManager.MapDataController.MapLineTable[LineTableID].allianceTag);
          fakeRetreat.emoji = DataManager.MapDataController.MapLineTable[LineTableID].emojiID;
          this.mapLineController.FakeRetreatList.Add(fakeRetreat);
        }
      }
    }
    else
    {
      long num1 = (long) DataManager.MapDataController.MapLineTable[LineTableID].begin + (long) DataManager.MapDataController.MapLineTable[LineTableID].during;
      if (DataManager.MapDataController.MapLineTable[LineTableID].during <= 2U || Math.Abs(num1 - DataManager.Instance.ServerTime) <= 1L)
      {
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if ((UnityEngine.Object) menu == (UnityEngine.Object) null || menu.m_eMode == EUIOriginMode.Show)
        {
          byte lineFlag = DataManager.MapDataController.MapLineTable[LineTableID].lineFlag;
          MapDamageEffTb recordByKey = PetManager.Instance.MapDamageEffTable.GetRecordByKey((ushort) lineFlag);
          if ((int) recordByKey.ID == (int) lineFlag)
          {
            float num2 = DataManager.MapDataController.zoomSize * this.CanvasrectranScale;
            Vector2 vector2 = this.mapTileController.getTilePosition(DataManager.MapDataController.MapLineTable[LineTableID].end.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].end.pointID) * num2;
            Vector3 vector3 = new Vector3(vector2.x, vector2.y, 0.0f);
            CString cstring = StringManager.Instance.SpawnString();
            if (recordByKey.SoundPakNO != (ushort) 0)
            {
              cstring.ClearString();
              cstring.StringToFormat("Role/");
              cstring.IntToFormat((long) recordByKey.SoundPakNO, 3);
              cstring.AppendFormat("{0}{1}");
              if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Role, AssetType.HeroSFX, recordByKey.SoundPakNO))
                AudioManager.Instance.PlaySFX(recordByKey.HitSound, Position: new Vector3?(vector3));
            }
            else
              AudioManager.Instance.PlaySFX(recordByKey.HitSound, Position: new Vector3?(vector3));
            if (recordByKey.ParticlePakNO != (ushort) 0)
            {
              cstring.ClearString();
              cstring.StringToFormat("Particle/Monster_Effects_");
              cstring.IntToFormat((long) recordByKey.ParticlePakNO, 3);
              cstring.AppendFormat("{0}{1}");
              if (AssetManager.GetAssetBundleDownload(cstring, AssetPath.Particle, AssetType.Effects, recordByKey.ParticlePakNO))
                DataManager.MapDataController.MapWeaponDefense(DataManager.MapDataController.MapLineTable[LineTableID].end.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].end.pointID, recordByKey.HitParticle, (float) recordByKey.HitParticleDuring * (1f / 1000f));
            }
            else
              DataManager.MapDataController.MapWeaponDefense(DataManager.MapDataController.MapLineTable[LineTableID].end.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].end.pointID, recordByKey.HitParticle, (float) recordByKey.HitParticleDuring * (1f / 1000f));
            StringManager.Instance.DeSpawnString(cstring);
          }
        }
      }
    }
    Send = Send != byte.MaxValue ? Send : (byte) 1;
    this.mapTileController.CheckDelFocusGroup(LineTableID, Send);
    this.mapLineController.removeLine(DataManager.MapDataController.MapLineTable[LineTableID].lineObject);
  }

  public void AddLine(int LineTableID, bool show = true)
  {
    if ((UnityEngine.Object) DataManager.MapDataController.MapLineTable[LineTableID].lineObject != (UnityEngine.Object) null)
      return;
    EUnitSide? nullable1 = new EUnitSide?();
    ELineColor? nullable2 = new ELineColor?();
    ushort num1 = 0;
    if (!GameConstants.IsPetSkillLine(LineTableID))
    {
      for (int index = 0; index < this.mapLineController.FakeRetreatList.Count; ++index)
      {
        POINT_KIND pointKind = (POINT_KIND) DataManager.MapDataController.LayoutMapInfo[GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[LineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].start.pointID)].pointKind;
        PointCode start = DataManager.MapDataController.MapLineTable[LineTableID].start;
        if ((int) start.pointID == (int) this.mapLineController.FakeRetreatList[index].point.pointID && (int) start.zoneID == (int) this.mapLineController.FakeRetreatList[index].point.zoneID)
        {
          if (this.mapLineController.FakeRetreatList[index].flag != (byte) 0)
          {
            nullable1 = new EUnitSide?(this.mapLineController.FakeRetreatList[index].unitSide);
            nullable2 = new ELineColor?(this.mapLineController.FakeRetreatList[index].lineColor);
          }
          num1 = this.mapLineController.FakeRetreatList[index].emoji;
          this.mapLineController.FakeRetreatList.RemoveAt(index);
          break;
        }
        if (this.mapLineController.FakeRetreatList[index].lineFlag == EMarchEventType.EMET_RallyAttack && DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == (byte) 17 && DataManager.MapDataController.LayoutMapInfo[GameConstants.PointCodeToMapID(this.mapLineController.FakeRetreatList[index].point.zoneID, this.mapLineController.FakeRetreatList[index].point.pointID)].pointKind == (byte) 11 && (int) DataManager.MapDataController.MapLineTable[LineTableID].end.pointID == (int) this.mapLineController.FakeRetreatList[index].point2.pointID && (int) DataManager.MapDataController.MapLineTable[LineTableID].end.zoneID == (int) this.mapLineController.FakeRetreatList[index].point2.zoneID)
        {
          this.mapLineController.FakeRetreatList.RemoveAt(index);
          break;
        }
      }
    }
    bool bEase = true;
    ELineColor lineColorid = ELineColor.BLUE;
    EUnitSide unitSideid = EUnitSide.BLUE;
    DataManager.checkLineColorID(LineTableID, out lineColorid, out unitSideid, out bEase);
    if (nullable1.HasValue)
    {
      unitSideid = nullable1.Value;
      lineColorid = nullable2.Value;
    }
    float num2 = DataManager.MapDataController.zoomSize * this.CanvasrectranScale;
    Vector2 vector2_1 = this.mapTileController.getTilePosition(DataManager.MapDataController.MapLineTable[LineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].start.pointID) * num2;
    Vector3 from = new Vector3(vector2_1.x, vector2_1.y, 0.0f);
    Vector2 vector2_2 = this.mapTileController.getTilePosition(DataManager.MapDataController.MapLineTable[LineTableID].end.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].end.pointID) * num2;
    int LayoutMapInfoID = 0;
    sbyte num3 = 0;
    if (!GameConstants.IsPetSkillLine(LineTableID) && DataManager.MapDataController.MapLineTable[LineTableID].lineFlag == (byte) 27)
    {
      if (NetworkManager.ServerTime - (double) DataManager.MapDataController.MapLineTable[LineTableID].begin < 5.0)
      {
        LayoutMapInfoID = GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[LineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].start.pointID);
        num3 = this.mapTileController.getNPCDir((uint) LayoutMapInfoID);
      }
      else
      {
        this.mapTileController.UpdateMapNPCHurt((uint) GameConstants.PointCodeToMapID(DataManager.MapDataController.MapLineTable[LineTableID].start.zoneID, DataManager.MapDataController.MapLineTable[LineTableID].start.pointID), false);
        LayoutMapInfoID = 0;
      }
    }
    LineNode line = this.mapLineController.createLine(LineTableID, from, new Vector3(vector2_2.x, vector2_2.y, 0.0f), lineColorid, unitSideid, bEase, show, num3 >= (sbyte) 0 ? EMonsterFace.LEFT : EMonsterFace.RIGHT);
    DataManager.MapDataController.MapLineTable[LineTableID].lineObject = line?.gameObject;
    if (line != null && num3 != (sbyte) 0)
      this.mapTileController.setNPCLinenode((uint) LayoutMapInfoID, line);
    if (num1 != (ushort) 0 && line.action != ELineAction.NORMAL)
    {
      DataManager.MapDataController.MapLineTable[LineTableID].baseFlag |= (byte) 1;
      DataManager.MapDataController.MapLineTable[LineTableID].emojiID = num1;
      this.UpdateLineEmoji(LineTableID);
    }
    this.CheckShowMapWeaponLine(LineTableID);
  }

  public void CheckShowMapWeaponLine(int LineTableID)
  {
    if (this.mapWeaponID == (ushort) 0 && this.mapSkillID == (ushort) 0 || ((int) DataManager.MapDataController.MapLineTable[LineTableID].baseFlag & 2) == 0 || DataManager.CompareStr(DataManager.MapDataController.MapLineTable[LineTableID].playerName, DataManager.Instance.RoleAttr.Name) != 0)
      return;
    if (DataManager.Instance.ServerTime - (long) DataManager.MapDataController.MapLineTable[LineTableID].begin < 3L)
      this.MapWeaponDebut(-90f - DataManager.MapDataController.MapLineTable[LineTableID].lineObject.transform.localEulerAngles.z);
    else
      this.StopMapWeaponShow();
  }

  public void UpdateLineOwner(int LineTableID)
  {
    this.mapLineController.getLineValue(DataManager.MapDataController.MapLineTable[LineTableID].lineObject).NodeName.updateName(DataManager.MapDataController.MapLineTable[LineTableID].playerName, DataManager.MapDataController.MapLineTable[LineTableID].allianceTag, (ushort) 0);
  }

  public void UpdateLineTag(int LineTableID)
  {
    if (DataManager.CompareStr(DataManager.MapDataController.MapLineTable[LineTableID].playerName, DataManager.Instance.RoleAttr.Name) == 0)
    {
      DataManager.Instance.RoleAlliance.Tag.ClearString();
      DataManager.Instance.RoleAlliance.Tag.Append(DataManager.MapDataController.MapLineTable[LineTableID].allianceTag);
      if (DataManager.Instance.RoleAlliance.Tag.Length == 0)
      {
        DataManager.Instance.RoleAlliance.Id = 0U;
        DataManager.Instance.RoleAlliance.KingdomID = (ushort) 0;
      }
      this.mapLineController.getLineValue(DataManager.MapDataController.MapLineTable[LineTableID].lineObject).NodeName.updateName(DataManager.MapDataController.MapLineTable[LineTableID].playerName, DataManager.MapDataController.MapLineTable[LineTableID].allianceTag, (ushort) 0);
    }
    else
    {
      bool bEase = true;
      ELineColor lineColorid = ELineColor.BLUE;
      EUnitSide unitSideid = EUnitSide.BLUE;
      DataManager.checkLineColorID(LineTableID, out lineColorid, out unitSideid, out bEase);
      this.mapLineController.setLineColor(DataManager.MapDataController.MapLineTable[LineTableID].lineObject, lineColorid, unitSideid, DataManager.MapDataController.MapLineTable[LineTableID].playerName, DataManager.MapDataController.MapLineTable[LineTableID].allianceTag, bEase);
    }
  }

  public void ResetAllLine()
  {
    if (this.mapLineController == null)
      return;
    this.mapLineController.resetAllLineColor();
  }

  public void UpdateLinePos(float movedeltax, float movedeltay)
  {
  }

  public void UpdateLineBegin(int LineTableID) => this.mapLineController.recaleSpeed(LineTableID);

  public void UpdateLineEmoji(int LineTableID)
  {
    LineNode lineValue = this.mapLineController.getLineValue(DataManager.MapDataController.MapLineTable[LineTableID].lineObject);
    if (((int) DataManager.MapDataController.MapLineTable[LineTableID].baseFlag & 1) != 0)
    {
      EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(DataManager.MapDataController.MapLineTable[LineTableID].emojiID);
      if ((int) recordByKey.EmojiKey != (int) DataManager.MapDataController.MapLineTable[LineTableID].emojiID)
        return;
      float num1 = (int) recordByKey.sizeX <= (int) recordByKey.sizeY ? (float) recordByKey.sizeY : (float) recordByKey.sizeX;
      float num2 = ((double) num1 != 0.0 ? num1 * 0.9f + (GUIManager.Instance.EmojiManager != null ? GUIManager.Instance.EmojiManager.basebackoffset : 25f) : (GUIManager.Instance.EmojiManager != null ? GUIManager.Instance.EmojiManager.basebacksize : 73f)) / (GUIManager.Instance.EmojiManager != null ? GUIManager.Instance.EmojiManager.basebacksize : 73f);
      if (lineValue.NodeName.mapEmojiBack == null)
      {
        lineValue.NodeName.mapEmojiBack = GUIManager.Instance.pullEmojiIcon(ushort.MaxValue, (byte) 0, true);
        SheetAnimationUnitGroup sheetUnit = lineValue.sheetUnit as SheetAnimationUnitGroup;
        lineValue.NodeName.mapEmojiBack.EmojiTransform.SetParent(sheetUnit.transform, false);
      }
      lineValue.NodeName.mapEmojiBack.EmojiTransform.localPosition = GameConstants.lineeomjiback;
      lineValue.NodeName.mapEmojiBack.EmojiTransform.localScale = Vector3.one * num2;
      if (lineValue.NodeName.mapEmoji != null)
      {
        GUIManager.Instance.pushEmojiIcon(lineValue.NodeName.mapEmoji);
        lineValue.NodeName.mapEmoji = (EmojiUnit) null;
      }
      lineValue.NodeName.mapEmoji = GUIManager.Instance.pullEmojiIcon(recordByKey.IconID, recordByKey.KeyFrame, true);
      lineValue.NodeName.mapEmoji.EmojiTransform.localPosition = GameConstants.lineeomji;
      lineValue.NodeName.mapEmoji.EmojiTransform.localScale = Vector3.one * 0.9f;
      SheetAnimationUnitGroup sheetUnit1 = lineValue.sheetUnit as SheetAnimationUnitGroup;
      lineValue.NodeName.mapEmoji.EmojiTransform.SetParent(sheetUnit1.transform, false);
    }
    else
    {
      if (lineValue.NodeName.mapEmoji == null)
        return;
      GUIManager.Instance.pushEmojiIcon(lineValue.NodeName.mapEmoji);
      lineValue.NodeName.mapEmoji = (EmojiUnit) null;
      if (lineValue.NodeName.mapEmojiBack == null)
        return;
      GUIManager.Instance.pushEmojiIcon(lineValue.NodeName.mapEmojiBack);
      lineValue.NodeName.mapEmojiBack = (EmojiUnit) null;
    }
  }

  public void UpdateLineWeapon(int LineTableID)
  {
  }

  public void ClickSelect(float selectX, float selectY, bool big)
  {
    this.TileSelectController.OnSelect(new Vector2(selectX, selectY), big, (byte) 0);
  }

  public void UpdateHomePos() => this.mapTileController.updateHomePos();

  public void Mark()
  {
    ushort zoneID = 0;
    byte pointID = 0;
    Vector2 zero = Vector2.zero;
    GameConstants.MapIDToPointCode(DataManager.MapDataController.FocusMapID, out zoneID, out pointID);
    for (ushort WonderID = 0; WonderID < (ushort) 40; ++WonderID)
    {
      if (DataManager.MapDataController.CheckYolk(WonderID, (ushort) 0))
      {
        Vector2 yolkPointCode = DataManager.MapDataController.GetYolkPointCode(WonderID, DataManager.MapDataController.FocusKingdomID);
        if ((double) yolkPointCode.x == (double) zoneID && (double) yolkPointCode.y == (double) pointID)
        {
          this.TileSelectController.OnMark(this.mapTileController.getTilePosition(zoneID, pointID), true);
          return;
        }
      }
    }
    this.TileSelectController.OnMark(this.mapTileController.getTilePosition(zoneID, pointID));
  }

  public bool ClickGroup() => this.mapTileController.ClickGroup();

  public void CloseEffect() => this.mapEffectController.setActive((byte) 0);

  public void CloseSelect()
  {
    this.stopFocusGroup();
    this.TileSelectController.Close();
  }

  public void CloseMark() => this.TileSelectController.Close();

  public void CheckLineUpdate()
  {
    if (this.mapLineController != null)
      return;
    this.mapLineController = new FlowLineFactory(this.RealmGroup_3DTransform, this.mapNameController, this.mapTileController.TileBaseScale);
    this.mapTileController.setLine(this.mapLineController);
    this.mapEffectController = new MapTileEffect(this.RealmGroup_3DTransform, this.mapTileController.TileBaseScale);
    this.mapTileController.setEffect(this.mapEffectController);
    this.mapNPCController = new MapTileNPC(this.RealmGroup_3DTransform);
    this.mapTileController.setNPC(this.mapNPCController);
    this.mapTileModelController = new MapTileModel(this.RealmGroup_3DTransform, this.mapTileController.TileBaseScale);
    this.mapTileController.setWeapon(this.mapTileModelController);
  }

  public void UpdateNetwork()
  {
    DataManager.MapDataController.ClearAll();
    if (this.mapLineController != null)
      this.mapLineController.ResetLineState();
    if (DataManager.MapDataController.gotoKingdomState != byte.MaxValue)
      this.mapTileController.RequestMapdata(Vector2.zero, true);
    if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Kingdom_Classifieds))
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Kingdom_Classifieds, 5);
    this.StopMapWeaponShow();
  }

  public void CheckCenterPos() => this.mapTileController.CheckCenterPos();

  public void stopFocusGroup() => this.mapTileController.stopFocusGroup();

  public void ClearEffect()
  {
    if (this.mapEffectController != null)
      this.mapEffectController.OnDestroy();
    this.mapEffectController = (MapTileEffect) null;
  }

  public void notSend() => this.mapTileController.notSend();

  public void LineControllerUpdate()
  {
    if (this.mapLineController == null)
      return;
    this.mapLineController.Update(Time.deltaTime);
  }

  public void NPCControllerUpdate()
  {
    this.mapNameController.npcTimeRun();
    if (this.mapNPCController == null)
      return;
    this.mapNPCController.Run();
  }

  public void BloodNameFontTextureRebuilt()
  {
    if (this.mapNameController != null)
      this.mapNameController.MapTileNameRebuilt();
    if (this.mapLineController == null)
      return;
    this.mapLineController.LineNameTextRebuilt();
  }

  public bool isMyPointIn()
  {
    ushort zoneID;
    byte pointID;
    GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out zoneID, out pointID);
    for (int index = 0; index < (int) DataManager.MapDataController.zoneIDNum; ++index)
    {
      if ((int) DataManager.MapDataController.zoneID[index] == (int) zoneID)
        return true;
    }
    uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    for (int index1 = 0; (long) index1 < (long) effectBaseVal; ++index1)
    {
      if (DataManager.Instance.MarchEventData[index1].Type < EMarchEventType.EMET_InforceStanby)
      {
        GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out zoneID, out pointID);
        for (int index2 = 0; index2 < (int) DataManager.MapDataController.zoneIDNum; ++index2)
        {
          if ((int) DataManager.MapDataController.zoneID[index2] == (int) zoneID)
            return true;
        }
      }
    }
    return false;
  }

  public void UpdateMapNPCNameBlood(byte row, byte col, float blood)
  {
    if ((double) blood == 0.0)
      this.mapNameController.setName((CString) null, (CString) null, (int) row, (int) col, Color.white, Vector2.zero, (byte) 0, kingdomID: (ushort) 0);
    else
      this.mapNameController.setName((int) row, (int) col, blood);
  }

  public void UpdatePoint(byte row, byte col) => this.mapTileController.UpdatePoint(row, col);

  public bool ResetYolk() => this.TileYolkController != null && this.TileYolkController.resetYolk();

  public void reflashEffect()
  {
    if (this.mapEffectController == null)
      return;
    this.mapEffectController.ReflashEffect();
  }

  public void ShowDamageRange(ushort zoneID, byte pointID, ushort damageRangeID = 1)
  {
    if (this.TileSelectController == null || !((UnityEngine.Object) this.mapTileController != (UnityEngine.Object) null))
      return;
    this.TileSelectController.OnTarget(damageRangeID, zoneID, pointID, this.mapTileController);
  }

  public void HideDamageRange()
  {
    if (this.TileSelectController == null)
      return;
    this.TileSelectController.NoneTarget(this.mapTileController);
  }

  public void UseMapWeapon(ushort MapWeaponID, ushort MapSkillID)
  {
    if (MapWeaponID == (ushort) 0 || MapSkillID == (ushort) 0 || (UnityEngine.Object) this.mapTileController == (UnityEngine.Object) null || this.mapTileModelController == null)
      return;
    this.mapWeaponID = MapWeaponID;
    this.mapSkillID = MapSkillID;
    if (!this.mapTileModelController.SetWeaponResources(MapWeaponID, MapSkillID))
      this.mapSkillID = this.mapWeaponID = (ushort) 0;
    this.mapTileController.startFocusMapWeapon((byte) 0);
  }

  public void StopMapWeaponShow()
  {
    if ((UnityEngine.Object) this.mapTileController != (UnityEngine.Object) null)
      this.mapTileController.stopFocusMapWeapon();
    if (this.mapTileModelController != null)
      this.mapTileModelController.Stop();
    this.mapWeaponID = (ushort) 0;
    this.mapSkillID = (ushort) 0;
  }

  public void MapWeaponDebut(float RotationY)
  {
    if (this.mapTileModelController != null)
    {
      this.mapTileModelController.startDebut(RotationY);
    }
    else
    {
      if (!((UnityEngine.Object) this.mapTileController != (UnityEngine.Object) null))
        return;
      this.mapTileController.stopFocusMapWeapon();
    }
  }

  public void MapWeaponAttack(ushort zoneID, byte pointID, ushort effectID, float effectTime)
  {
    if (this.mapWeaponID != (ushort) 0 && this.mapSkillID != (ushort) 0 && GameConstants.PointCodeToMapID(zoneID, pointID) == DataManager.Instance.RoleAttr.CapitalPoint || this.mapTileModelController == null)
      return;
    Vector2 tilePosition = this.mapTileController.getTilePosition(zoneID, pointID);
    Vector3 pos = new Vector3(tilePosition.x, tilePosition.y, 0.0f);
    if (this.mapTileModelController.MapWeaponEffect(effectID, pos, effectTime))
      return;
    this.mapTileModelController.MapWeaponEffect((ushort) 60402, pos, 0.6f);
  }

  public void MapWeaponDefense(ushort zoneID, byte pointID, ushort effectID, float effectTime)
  {
    if (this.mapTileModelController == null)
      return;
    Vector2 tilePosition = this.mapTileController.getTilePosition(zoneID, pointID);
    Vector3 pos = new Vector3(tilePosition.x, tilePosition.y, 0.0f);
    if (this.mapTileModelController.MapWeaponEffect(effectID, pos, effectTime))
      return;
    this.mapTileModelController.MapWeaponEffect((ushort) 60403, pos, 1.5f);
  }
}
