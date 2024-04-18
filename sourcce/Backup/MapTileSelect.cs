// Decompiled with JetBrains decompiler
// Type: MapTileSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class MapTileSelect
{
  private const int selectSpriteID = 138;
  private const int markSpriteID = 150;
  private const float markYoffset = 92f;
  private ushort nowDamageRangeID;
  private ushort nowDamageTargetZoneID = 1024;
  private byte nowDamageTargetPointID;
  private float TileSelectStart;
  private float TileMarkSpeed = 10f;
  private float TileMarkPosY;
  private GameObject TileMarkGameObject;
  private RectTransform TileSelect;
  private RectTransform TileMark;
  private Image TileSelectImage;
  private Image TileMarkImage;
  private Color TileSelectColor = Color.white;

  public MapTileSelect(Transform realmGroup, UISpritesArray tileSprites)
  {
    GameObject gameObject = new GameObject(nameof (MapTileSelect));
    this.TileSelect = gameObject.AddComponent<RectTransform>();
    ((Transform) this.TileSelect).position = Vector3.forward * 3840f;
    ((Transform) this.TileSelect).SetParent(realmGroup, false);
    this.TileSelect.sizeDelta = new Vector2(256f, 128f);
    this.TileSelect.anchoredPosition = Vector2.zero;
    this.TileSelectImage = gameObject.AddComponent<Image>();
    this.TileSelectImage.sprite = tileSprites.GetSprite(138);
    ((MaskableGraphic) this.TileSelectImage).material = ((MaskableGraphic) tileSprites.m_Image).material;
    gameObject.SetActive(false);
    this.TileMarkGameObject = new GameObject("MapTileMark");
    this.TileMark = this.TileMarkGameObject.AddComponent<RectTransform>();
    ((Transform) this.TileMark).position = Vector3.forward * 3712f;
    ((Transform) this.TileMark).SetParent(realmGroup, false);
    this.TileMark.sizeDelta = new Vector2(256f, 128f);
    this.TileMark.anchoredPosition = Vector2.zero;
    this.TileMarkImage = this.TileMarkGameObject.AddComponent<Image>();
    this.TileMarkImage.sprite = tileSprites.GetSprite(150);
    ((MaskableGraphic) this.TileMarkImage).material = ((MaskableGraphic) tileSprites.m_Image).material;
    ((Graphic) this.TileMarkImage).color = Color.white;
    this.TileMarkImage.SetNativeSize();
    this.TileMarkGameObject.SetActive(false);
  }

  public void OnDestroy()
  {
    if ((Object) this.TileSelectImage != (Object) null)
      this.TileSelectImage = (Image) null;
    if ((Object) this.TileMarkImage != (Object) null)
      this.TileMarkImage = (Image) null;
    if ((Object) this.TileSelect != (Object) null)
      Object.Destroy((Object) this.TileSelect);
    this.TileSelect = (RectTransform) null;
    if ((Object) this.TileMark != (Object) null)
      Object.Destroy((Object) this.TileMarkGameObject);
    this.TileMark = (RectTransform) null;
    this.TileMarkGameObject = (GameObject) null;
  }

  public void SelectUpdate()
  {
    // ISSUE: unable to decompile the method.
  }

  public void OnSelect(Vector2 TileAnchoredPosition, bool big = false, byte markID = 0)
  {
    this.TileSelectStart = 1f;
    this.TileSelectColor.a = 0.3f;
    ((Graphic) this.TileSelectImage).color = this.TileSelectColor;
    if (big)
    {
      TileAnchoredPosition.y += 64f;
      ((Transform) this.TileSelect).localScale = Vector3.one * 2f;
    }
    else
      ((Transform) this.TileSelect).localScale = Vector3.one;
    this.TileSelect.anchoredPosition = TileAnchoredPosition;
    ((Component) this.TileSelect).gameObject.SetActive(true);
    this.TileMarkGameObject.SetActive(false);
  }

  public void OnMark(Vector2 TileAnchoredPosition, bool big = false)
  {
    this.OnSelect(TileAnchoredPosition, big, (byte) 0);
    if (big)
      return;
    this.TileMarkSpeed = 75f;
    this.TileMark.anchoredPosition = TileAnchoredPosition + Vector2.up * 92f;
    this.TileMarkPosY = this.TileMark.anchoredPosition.y;
    this.TileMarkGameObject.SetActive(true);
  }

  public void Close()
  {
    this.TileSelectStart = 0.0f;
    this.TileSelectColor.a = 0.0f;
    ((Graphic) this.TileSelectImage).color = this.TileSelectColor;
    ((Component) this.TileSelect).gameObject.SetActive(false);
    this.TileMarkGameObject.SetActive(false);
  }

  public void OnTarget(
    ushort targetRangeID,
    ushort targetZoneID,
    byte targetPointID,
    MapTile MapTileController)
  {
    if (DataManager.MapDataController.MapWeaponDamageRangeTable == null)
    {
      DataManager.MapDataController.MapWeaponDamageRangeTable = new CExternalTableWithWordKey<MapWeaponDamageRange>();
      DataManager.MapDataController.MapWeaponDamageRangeTable.LoadTable("MapDamageRange");
    }
    this.NoneTarget(MapTileController);
    this.nowDamageRangeID = targetRangeID;
    this.nowDamageTargetZoneID = targetZoneID;
    this.nowDamageTargetPointID = targetPointID;
    ushort WonderID = 0;
    Vector2 zero = Vector2.zero;
    for (; WonderID < (ushort) 40; ++WonderID)
    {
      if (DataManager.MapDataController.CheckYolk(WonderID, (ushort) 0))
      {
        Vector2 yolkPointCode = DataManager.MapDataController.GetYolkPointCode(WonderID, DataManager.MapDataController.FocusKingdomID);
        if ((double) yolkPointCode.x == (double) targetZoneID && (double) yolkPointCode.y == (double) targetPointID)
          break;
      }
    }
    MapWeaponDamageRange recordByKey = DataManager.MapDataController.MapWeaponDamageRangeTable.GetRecordByKey(targetRangeID);
    if (!((Object) MapTileController != (Object) null))
      return;
    this.OnSelect(MapTileController.getTilePosition(targetZoneID, targetPointID), WonderID < (ushort) 40, recordByKey.MarkID);
    Vector2 mapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(targetZoneID, targetPointID);
    Vector2 vector2 = mapPosbyPointCode;
    int num1 = recordByKey.OffSetX <= (byte) 128 ? (int) recordByKey.OffSetX : -((int) recordByKey.OffSetX - 128);
    vector2.x += (float) num1;
    if ((double) vector2.x > 511.0)
      vector2.x = 511f;
    if ((double) vector2.x < 0.0)
      vector2.x = 0.0f;
    int num2 = recordByKey.OffSetY <= (byte) 128 ? (int) recordByKey.OffSetY : -((int) recordByKey.OffSetY - 128);
    vector2.y += (float) num2;
    if ((double) vector2.y > 1023.0)
      vector2.y = 1023f;
    if ((double) vector2.y < 0.0)
      vector2.y = 0.0f;
    Color in_color1 = (Color) new Color32(recordByKey.ColorR, recordByKey.ColorG, recordByKey.ColorB, byte.MaxValue);
    uint mapId1 = (uint) GameConstants.TileMapPosToMapID((int) vector2.x, (int) vector2.y);
    int row = -1;
    int col = -1;
    MapTileController.MapIDtoMapTileRowCol(mapId1, ref row, ref col);
    if (row > -1 && col > -1)
      MapTileController.mapTileShowDamageRange(row, col, in_color1);
    while (recordByKey.NextID != (ushort) 0)
    {
      ushort nextId = recordByKey.NextID;
      recordByKey = DataManager.MapDataController.MapWeaponDamageRangeTable.GetRecordByKey(nextId);
      if ((int) nextId != (int) recordByKey.ID)
        break;
      vector2 = mapPosbyPointCode;
      int num3 = recordByKey.OffSetX <= (byte) 128 ? (int) recordByKey.OffSetX : -((int) recordByKey.OffSetX - 128);
      vector2.x += (float) num3;
      if ((double) vector2.x > 511.0)
        vector2.x = 511f;
      if ((double) vector2.x < 0.0)
        vector2.x = 0.0f;
      int num4 = recordByKey.OffSetY <= (byte) 128 ? (int) recordByKey.OffSetY : -((int) recordByKey.OffSetY - 128);
      vector2.y += (float) num4;
      if ((double) vector2.y > 1023.0)
        vector2.y = 1023f;
      if ((double) vector2.y < 0.0)
        vector2.y = 0.0f;
      Color in_color2 = (Color) new Color32(recordByKey.ColorR, recordByKey.ColorG, recordByKey.ColorB, byte.MaxValue);
      uint mapId2 = (uint) GameConstants.TileMapPosToMapID((int) vector2.x, (int) vector2.y);
      MapTileController.MapIDtoMapTileRowCol(mapId2, ref row, ref col);
      if (row > -1 && col > -1)
        MapTileController.mapTileShowDamageRange(row, col, in_color2);
    }
  }

  public void NoneTarget(MapTile MapTileController)
  {
    this.Close();
    if (this.nowDamageRangeID == (ushort) 0 || this.nowDamageTargetZoneID >= (ushort) 1024 || (Object) MapTileController == (Object) null)
    {
      this.nowDamageRangeID = (ushort) 0;
      this.nowDamageTargetZoneID = (ushort) 1024;
      this.nowDamageTargetPointID = (byte) 0;
    }
    else
    {
      MapWeaponDamageRange recordByKey = DataManager.MapDataController.MapWeaponDamageRangeTable.GetRecordByKey(this.nowDamageRangeID);
      Vector2 mapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(this.nowDamageTargetZoneID, this.nowDamageTargetPointID);
      Vector2 vector2 = mapPosbyPointCode;
      int num1 = recordByKey.OffSetX <= (byte) 128 ? (int) recordByKey.OffSetX : -((int) recordByKey.OffSetX - 128);
      vector2.x += (float) num1;
      if ((double) vector2.x > 511.0)
        vector2.x = 511f;
      if ((double) vector2.x < 0.0)
        vector2.x = 0.0f;
      int num2 = recordByKey.OffSetY <= (byte) 128 ? (int) recordByKey.OffSetY : -((int) recordByKey.OffSetY - 128);
      vector2.y += (float) num2;
      if ((double) vector2.y > 1023.0)
        vector2.y = 1023f;
      if ((double) vector2.y < 0.0)
        vector2.y = 0.0f;
      uint mapId1 = (uint) GameConstants.TileMapPosToMapID((int) vector2.x, (int) vector2.y);
      int row = -1;
      int col = -1;
      MapTileController.MapIDtoMapTileRowCol(mapId1, ref row, ref col);
      Color tileColorByMapId1 = MapTileController.getMapTileColorByMapID(mapId1);
      if (row > -1 && col > -1)
        MapTileController.mapTileShowDamageRange(row, col, tileColorByMapId1);
      while (recordByKey.NextID != (ushort) 0)
      {
        recordByKey = DataManager.MapDataController.MapWeaponDamageRangeTable.GetRecordByKey(recordByKey.NextID);
        vector2 = mapPosbyPointCode;
        int num3 = recordByKey.OffSetX <= (byte) 128 ? (int) recordByKey.OffSetX : -((int) recordByKey.OffSetX - 128);
        vector2.x += (float) num3;
        if ((double) vector2.x > 511.0)
          vector2.x = 511f;
        if ((double) vector2.x < 0.0)
          vector2.x = 0.0f;
        int num4 = recordByKey.OffSetY <= (byte) 128 ? (int) recordByKey.OffSetY : -((int) recordByKey.OffSetY - 128);
        vector2.y += (float) num4;
        if ((double) vector2.y > 1023.0)
          vector2.y = 1023f;
        if ((double) vector2.y < 0.0)
          vector2.y = 0.0f;
        uint mapId2 = (uint) GameConstants.TileMapPosToMapID((int) vector2.x, (int) vector2.y);
        MapTileController.MapIDtoMapTileRowCol(mapId2, ref row, ref col);
        Color tileColorByMapId2 = MapTileController.getMapTileColorByMapID(mapId2);
        if (row > -1 && col > -1)
          MapTileController.mapTileShowDamageRange(row, col, tileColorByMapId2);
      }
      this.nowDamageRangeID = (ushort) 0;
      this.nowDamageTargetZoneID = (ushort) 1024;
      this.nowDamageTargetPointID = (byte) 0;
    }
  }
}
