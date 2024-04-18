// Decompiled with JetBrains decompiler
// Type: MapTile
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class MapTile : MonoBehaviour
{
  private const float startMovedeltaFactor = 0.25f;
  private const float movelimit = 0.97f;
  private const float movespeed = 49f;
  private const float movemin = 0.03f;
  private const int grassland = 22;
  private const int lava = 35;
  private const int lavaborder = 49;
  private const int icefield = 69;
  private const int icefieldborder = 79;
  private const int rankone = 113;
  private const int slow = 109;
  private const int cityrankone = 145;
  private const int citylevelmin = 9;
  private const int citylevelmid = 17;
  private const int citylevelhigh = 25;
  private const int cityenemy = 151;
  private const int citynpc = 152;
  private const int camp = 149;
  private const int resourcesspriteid = 138;
  private const int yolkidmin = 98;
  private const int yolkidmax = 109;
  private const int OFFSET_POINTEX_ID = 10;
  private const float yolkidminpemojioffset = 300f;
  private const float yolkidmaxpemojioffset = 410f;
  private const int MaxTickImage = 256;
  public Vector2 Movedelta = Vector2.zero;
  public byte[] TileMapInfo;
  public UISpritesArray TileSprites;
  public float TileBaseScale;
  public int centerMapID = -1;
  public MapTileYolk yolk;
  public byte[] TileMapInfoEx;
  private byte bGraphicFake;
  private byte homeSide;
  private byte TileHeight;
  private byte TileMapInfoWidthMaxOffSet;
  private byte TileMapInfoHeightMaxOffSet;
  private ushort TileMapInfoWidthMax;
  private ushort TileMapInfoWidthMaxSubtractOne;
  private ushort TileMapInfoHeightMax;
  private ushort TileMapInfoHeightMaxSubtractOne;
  private ushort TileColNum;
  private ushort TileColNumSubtractOne;
  private ushort TileColNumOffset;
  private ushort TileRowNum;
  private ushort TileRowNumSubtractOne;
  private ushort TileRowNumOffset;
  private int TileColMapStartIDOffset;
  private int TileRowMapStartIDOffset;
  private int StartID;
  private int BoundStartX;
  private int BoundStartY;
  private int worldTitleIconStartID = 46;
  private int kingdomTitleIconStartID = 5;
  private int nobilityTitleIconStartID = 86;
  private RectTransform TileMapRectTransform;
  private RectTransform[] TileRowGroupRectTransform;
  private RectTransform[][] TileObjectRectTransform;
  private RectTransform[][] TileBaseRectTransform;
  private RectTransform[][] OverTileBaseRectTransform;
  private GameObject[][] OverTileBaseGameObject;
  private Image[][] TileBaseImage;
  private Image[][] OverTileBaseImage;
  private MapTile.InPutState inputState;
  private float MovedeltaFactor = 0.25f;
  private float onDragTimer;
  private Vector2 OnDragPos;
  private Vector2 lastOnDragPos;
  private Vector2 homePos;
  private Vector2 goHomeButtonOffset;
  private Vector2 BaseCenterID = -Vector2.one;
  private Vector2 centerID = -Vector2.one;
  private ushort[] TzoneID = new ushort[4];
  private MapTileLevel level;
  private MapTileBloodName bloodname;
  private MapTileGraphic graphic;
  private MapTileEffect effect;
  private FlowLineFactory line;
  private MapTileNPC npc;
  private MapTileModel weapon;
  private Color deepblue = new Color(0.0784313f, 0.764706f, 1f);
  private Color lightblue = new Color(0.0f, 1f, 1f);
  private Color lightyellow = new Color(1f, 0.6862745f, 0.0f);
  private Color lightred = new Color(1f, 0.5647059f, 0.5176471f);
  private Color npcnamecolor = new Color(1f, 0.9607843f, 0.419607848f);
  private Color yolknamecolor = new Color(1f, 0.5647059f, 0.5176471f);
  private Color32 color_1 = new Color32((byte) 73, (byte) 121, (byte) 188, byte.MaxValue);
  private Color32 color_2 = new Color32((byte) 121, (byte) 149, (byte) 199, byte.MaxValue);
  private Vector2 inpos = new Vector2(-222f, -241.5f);
  private Vector2 outpos = new Vector2(-95f, -104f);
  private float selectLineMoveX;
  private float selectLineMoveY;
  public LineNode selectLineNode;
  private RectTransform Canvasrectran;
  private Transform RealmGroup_3DTransform;
  private CString tmepStr;
  private bool bFront;
  private float focusMapWeaponTime;
  public byte frontIsSheep = 3;
  private Image[] tickImage;
  private byte[] tickImageIDToColRow;
  private ushort[][] tickColRowToImageID;
  private ushort frontTickImageNum;
  private ushort backTickImageNum;
  private Color sheepTickYolkImageColor = (Color) new Color32(byte.MaxValue, (byte) 88, (byte) 88, byte.MaxValue);
  private Color wolfTickYolkImageColor = (Color) new Color32((byte) 195, (byte) 124, byte.MaxValue, byte.MaxValue);

  protected void Awake()
  {
    this.bGraphicFake = (ActivityManager.Instance.bSpecialMonsterTreasureEvent & 4UL) <= 0UL ? (byte) 0 : (byte) 1;
    this.bFront = GameManager.ActiveGameplay is Front;
    this.tmepStr = StringManager.Instance.SpawnString(300);
    this.TileHeight = (byte) 128;
    this.TileMapInfoWidthMaxOffSet = (byte) 8;
    this.TileMapInfoHeightMaxOffSet = (byte) 10;
    this.TileMapInfoWidthMax = (ushort) 256;
    this.TileMapInfoWidthMaxSubtractOne = this.TileMapInfoWidthMax;
    --this.TileMapInfoWidthMaxSubtractOne;
    this.TileMapInfoHeightMax = (ushort) 1024;
    this.TileMapInfoHeightMaxSubtractOne = this.TileMapInfoHeightMax;
    --this.TileMapInfoHeightMaxSubtractOne;
    this.LoadTileMapFile();
    this.Canvasrectran = ((Component) GUIManager.Instance.m_UICanvas).transform as RectTransform;
    this.TileMapRectTransform = this.transform as RectTransform;
    ((Transform) this.TileMapRectTransform).position = Vector3.forward * 4096f;
    this.TileMapRectTransform.sizeDelta = this.Canvasrectran.sizeDelta;
    this.TileMapRectTransform.anchoredPosition = Vector2.zero;
    this.TileSprites = this.gameObject.GetComponent<UISpritesArray>();
    this.SetRect(16, 16);
    this.OnDragPos = -Vector2.zero;
    this.lastOnDragPos = -Vector2.zero;
    this.onDragTimer = 0.0f;
    this.updateHomePos();
    this.updateBaseCenter();
    this.tickImage = new Image[256];
    this.tickImageIDToColRow = new byte[256];
    this.tickColRowToImageID = new ushort[16][];
    for (int index1 = 0; index1 < this.tickColRowToImageID.Length; ++index1)
    {
      this.tickColRowToImageID[index1] = new ushort[16];
      for (int index2 = 0; index2 < this.tickColRowToImageID[index1].Length; ++index2)
        this.tickColRowToImageID[index1][index2] = (ushort) 256;
    }
    if (ActivityManager.Instance.KVKHuntOrder == (byte) 1)
    {
      this.frontIsSheep = (byte) 0;
    }
    else
    {
      if (ActivityManager.Instance.KVKHuntOrder != (byte) 2)
        return;
      this.frontIsSheep = (byte) 1;
    }
  }

  protected void OnDestroy()
  {
    if (this.tickImage != null)
    {
      Array.Clear((Array) this.tickImage, 0, this.tickImage.Length);
      this.tickImage = (Image[]) null;
    }
    if (this.tickImageIDToColRow != null)
    {
      Array.Clear((Array) this.tickImageIDToColRow, 0, this.tickImageIDToColRow.Length);
      this.tickImageIDToColRow = (byte[]) null;
    }
    if (this.tickColRowToImageID != null)
    {
      for (int index = 0; index < this.tickColRowToImageID.Length; ++index)
      {
        Array.Clear((Array) this.tickColRowToImageID[index], 0, this.tickColRowToImageID[index].Length);
        this.tickColRowToImageID[index] = (ushort[]) null;
      }
      this.tickColRowToImageID = (ushort[][]) null;
    }
    if (this.tmepStr != null)
      StringManager.Instance.DeSpawnString(this.tmepStr);
    if (this.centerMapID != -1)
      DataManager.MapDataController.FocusMapID = this.centerMapID;
    this.RealmGroup_3DTransform = (Transform) null;
    if (this.TileMapInfo != null)
      Array.Clear((Array) this.TileMapInfo, 0, this.TileMapInfo.Length);
    if (this.TileMapInfoEx != null)
      Array.Clear((Array) this.TileMapInfoEx, 0, this.TileMapInfoEx.Length);
    if (this.TileRowGroupRectTransform != null)
      Array.Clear((Array) this.TileRowGroupRectTransform, 0, this.TileRowGroupRectTransform.Length);
    if (this.TileObjectRectTransform != null)
    {
      for (int index = 0; index < this.TileObjectRectTransform.Length; ++index)
      {
        Array.Clear((Array) this.TileObjectRectTransform[index], 0, this.TileObjectRectTransform[index].Length);
        this.TileObjectRectTransform[index] = (RectTransform[]) null;
      }
    }
    if (this.TileBaseRectTransform != null)
    {
      for (int index = 0; index < this.TileBaseRectTransform.Length; ++index)
      {
        Array.Clear((Array) this.TileBaseRectTransform[index], 0, this.TileBaseRectTransform[index].Length);
        this.TileBaseRectTransform[index] = (RectTransform[]) null;
      }
    }
    if (this.OverTileBaseRectTransform != null)
    {
      for (int index = 0; index < this.OverTileBaseRectTransform.Length; ++index)
      {
        Array.Clear((Array) this.OverTileBaseRectTransform[index], 0, this.OverTileBaseRectTransform[index].Length);
        this.OverTileBaseRectTransform[index] = (RectTransform[]) null;
      }
    }
    if (this.OverTileBaseGameObject != null)
    {
      for (int index = 0; index < this.OverTileBaseGameObject.Length; ++index)
      {
        Array.Clear((Array) this.OverTileBaseGameObject[index], 0, this.OverTileBaseGameObject[index].Length);
        this.OverTileBaseGameObject[index] = (GameObject[]) null;
      }
    }
    if (this.TileBaseImage != null)
    {
      for (int index = 0; index < this.TileBaseImage.Length; ++index)
      {
        Array.Clear((Array) this.TileBaseImage[index], 0, this.TileBaseImage[index].Length);
        this.TileBaseImage[index] = (Image[]) null;
      }
    }
    if (this.OverTileBaseImage != null)
    {
      for (int index = 0; index < this.OverTileBaseImage.Length; ++index)
      {
        Array.Clear((Array) this.OverTileBaseImage[index], 0, this.OverTileBaseImage[index].Length);
        this.OverTileBaseImage[index] = (Image[]) null;
      }
    }
    if ((UnityEngine.Object) this.TileSprites != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.TileSprites.gameObject);
    this.TileSprites = (UISpritesArray) null;
    this.TileRowGroupRectTransform = (RectTransform[]) null;
    this.TileObjectRectTransform = (RectTransform[][]) null;
    this.TileBaseRectTransform = (RectTransform[][]) null;
    this.OverTileBaseRectTransform = (RectTransform[][]) null;
    this.OverTileBaseGameObject = (GameObject[][]) null;
    this.TileBaseImage = (Image[][]) null;
    this.OverTileBaseImage = (Image[][]) null;
    this.TileMapInfo = (byte[]) null;
    this.TileMapInfoEx = (byte[]) null;
    this.level = (MapTileLevel) null;
    this.bloodname = (MapTileBloodName) null;
    this.graphic = (MapTileGraphic) null;
    this.effect = (MapTileEffect) null;
    this.npc = (MapTileNPC) null;
    this.yolk = (MapTileYolk) null;
    if (this.selectLineNode != null)
    {
      if (this.line != null)
        this.line.easeLineNode(this.selectLineNode);
      else
        this.selectLineNode.bFocus = (byte) 0;
      this.selectLineNode = (LineNode) null;
    }
    this.Canvasrectran = (RectTransform) null;
  }

  protected void Update()
  {
    DataManager.MapDataController.UpdateWaitZone();
    if (this.inputState == MapTile.InPutState.Zoom)
      this.ZoomTile();
    else if (this.inputState == MapTile.InPutState.Group)
      this.FocusGroup((byte) 2);
    else if (this.inputState == MapTile.InPutState.Weapon)
    {
      this.FocusMapWeapon();
    }
    else
    {
      this.MoveTileBase();
      if ((double) this.OnDragPos.x > -1.0 && (double) this.OnDragPos.y > -1.0)
      {
        if (this.OnDragPos != this.lastOnDragPos)
        {
          this.lastOnDragPos = this.OnDragPos;
        }
        else
        {
          this.onDragTimer += Time.deltaTime;
          if ((double) this.onDragTimer > 0.30000001192092896)
          {
            this.onDragTimer = 0.0f;
            this.OnDragPos = this.lastOnDragPos = -Vector2.one;
            this.RequestMapdata(Vector2.zero);
          }
        }
      }
      if (!(this.Movedelta != Vector2.zero))
        return;
      float movedeltaFactor = this.MovedeltaFactor;
      for (int index = 0; index < 2; ++index)
      {
        if ((double) this.Movedelta[index] != 0.0)
        {
          this.Movedelta[index] *= movedeltaFactor;
          if (float.IsNaN(this.Movedelta[index]) || (double) Math.Abs(this.Movedelta[index]) < 0.029999999329447746)
            this.Movedelta[index] = 0.0f;
        }
      }
      if ((double) this.MovedeltaFactor < 0.97000002861022949)
      {
        this.MovedeltaFactor += Time.deltaTime * 49f;
        if ((double) this.MovedeltaFactor > 0.97000002861022949)
          this.MovedeltaFactor = 0.97f;
      }
      if ((double) this.Movedelta.magnitude <= 0.0)
        this.RequestMapdata(Vector2.zero);
      if ((double) this.Movedelta.magnitude >= 0.40000000596046448)
        return;
      DataManager.msgBuffer[0] = (byte) 97;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
  }

  public void OnDrag(PointerEventData eventData)
  {
    switch (this.inputState)
    {
      case MapTile.InPutState.Click:
        if ((double) (eventData.position - eventData.pressPosition).magnitude <= 50.0)
          break;
        this.inputState = MapTile.InPutState.Drag;
        this.ClosePointInfo();
        this.lastOnDragPos = -Vector2.one;
        this.onDragTimer = 0.0f;
        break;
      case MapTile.InPutState.Drag:
        this.Movedelta = eventData.delta * (this.TileMapRectTransform.sizeDelta.y / (float) Screen.height);
        if (float.IsNaN(this.Movedelta.magnitude))
          this.Movedelta = Vector2.zero;
        this.MoveTileBase();
        this.OnDragPos = eventData.position;
        break;
    }
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    switch (this.inputState)
    {
      case MapTile.InPutState.None:
        this.inputState = MapTile.InPutState.Click;
        break;
      case MapTile.InPutState.Click:
      case MapTile.InPutState.Drag:
        if (Input.touchCount > 1)
        {
          this.ClosePointInfo();
          this.inputState = MapTile.InPutState.Zoom;
          DataManager.msgBuffer[0] = (byte) 97;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          break;
        }
        break;
      case MapTile.InPutState.Group:
        this.ClosePointInfo();
        this.inputState = MapTile.InPutState.Click;
        break;
      default:
        this.ClosePointInfo();
        break;
    }
    this.Movedelta = Vector2.zero;
  }

  public void OnPointerUp(PointerEventData eventData)
  {
    switch (this.inputState)
    {
      case MapTile.InPutState.Click:
        if (this.line.OnClick(eventData.position, ref this.selectLineNode))
        {
          DataManager.msgBuffer[0] = (byte) 66;
          GameConstants.GetBytes((uint) this.selectLineNode.lineTableID, DataManager.msgBuffer, 1);
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          this.inputState = MapTile.InPutState.Group;
          DataManager.MapDataController.FocusGroupID = (byte) 10;
          this.FocusGroup((byte) 0);
          break;
        }
        Vector2 in_TileBaseID = this.PosToTileBaseID(eventData.position);
        uint mapInfoIdbyStartId = (uint) this.getTileMapInfoIDbyStartID(in_TileBaseID);
        if (this.yolk.OnYolkSelect(mapInfoIdbyStartId))
        {
          DataManager.msgBuffer[0] = (byte) 97;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          this.inputState = MapTile.InPutState.None;
          break;
        }
        if ((double) in_TileBaseID.x < 0.0)
          in_TileBaseID = Vector2.zero;
        int index1 = this.TileColMapStartIDOffset + (int) in_TileBaseID.y & (int) this.TileRowNumSubtractOne;
        int index2 = this.TileRowMapStartIDOffset + (int) in_TileBaseID.x & (int) this.TileColNumSubtractOne;
        Vector2 vector2 = this.TileRowGroupRectTransform[index1].anchoredPosition + this.TileObjectRectTransform[index2][index1].anchoredPosition;
        DataManager.msgBuffer[0] = (byte) 64;
        GameConstants.GetBytes(mapInfoIdbyStartId, DataManager.msgBuffer, 1);
        GameConstants.GetBytes(vector2.x, DataManager.msgBuffer, 5);
        GameConstants.GetBytes(vector2.y, DataManager.msgBuffer, 9);
        if (((Graphic) this.TileBaseImage[index2][index1]).color == Color.gray)
          GameConstants.GetBytes((ushort) 0, DataManager.msgBuffer, 13);
        else if (DataManager.MapDataController.LayoutMapInfo[(IntPtr) mapInfoIdbyStartId].pointKind == (byte) 10)
          GameConstants.GetBytes((ushort) 10, DataManager.msgBuffer, 13);
        else
          GameConstants.GetBytes((ushort) 14, DataManager.msgBuffer, 13);
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        DataManager.msgBuffer[0] = (byte) 97;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        this.inputState = MapTile.InPutState.None;
        break;
      case MapTile.InPutState.Drag:
        this.Movedelta = eventData.delta * (this.TileMapRectTransform.sizeDelta.y / (float) Screen.height);
        float num1 = 2f;
        if ((double) this.Movedelta.magnitude < (double) num1)
          this.Movedelta *= num1 / this.Movedelta.magnitude;
        if (float.IsNaN(this.Movedelta.magnitude))
          this.Movedelta = Vector2.zero;
        this.MovedeltaFactor = 0.25f;
        this.inputState = MapTile.InPutState.None;
        this.OnDragPos = -Vector2.one;
        if ((double) this.Movedelta.magnitude <= (double) num1)
        {
          DataManager.msgBuffer[0] = (byte) 97;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
        else if ((double) this.Movedelta.magnitude >= 20.0)
        {
          DataManager.msgBuffer[0] = (byte) 96;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
        Vector2 movedelta1 = this.Movedelta;
        Vector2 movedelta2 = this.Movedelta;
        float num2 = this.MovedeltaFactor;
        while (movedelta2 != Vector2.zero)
        {
          for (int index3 = 0; index3 < 2; ++index3)
          {
            if ((double) movedelta2[index3] != 0.0)
            {
              movedelta2[index3] *= num2;
              if (float.IsNaN(movedelta2[index3]) || (double) Math.Abs(movedelta2[index3]) < 0.029999999329447746)
                movedelta2[index3] = 0.0f;
            }
          }
          movedelta1 += movedelta2;
          if ((double) num2 < 0.97000002861022949)
          {
            num2 += Time.deltaTime * 49f;
            if ((double) num2 > 0.97000002861022949)
              num2 = 0.97f;
          }
        }
        Vector2 inout_movedelta = movedelta1 / DataManager.MapDataController.zoomSize;
        this.CheckLimit(this.StartID & (int) this.TileMapInfoWidthMaxSubtractOne, this.StartID >> (int) this.TileMapInfoWidthMaxOffSet, ref inout_movedelta);
        this.RequestMapdata(inout_movedelta);
        this.ClosePointInfo();
        break;
      case MapTile.InPutState.Zoom:
        if (Input.touchCount == 1)
          this.inputState = MapTile.InPutState.Drag;
        else if (Input.touchCount < 1)
        {
          DataManager.msgBuffer[0] = (byte) 97;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          this.inputState = MapTile.InPutState.None;
        }
        this.ClosePointInfo();
        break;
    }
  }

  public void UpdateTileMap(ushort ZoneID)
  {
    int startPointX = this.StartID & (int) this.TileMapInfoWidthMaxSubtractOne;
    int startPointY = this.StartID >> (int) this.TileMapInfoWidthMaxOffSet;
    if (ZoneID < (ushort) 1024)
    {
      int mapId = GameConstants.PointCodeToMapID(ZoneID, (byte) 0);
      int colstart = (mapId & (int) this.TileMapInfoWidthMaxSubtractOne) - startPointX;
      int tileColNum = (int) this.TileColNum;
      int num1;
      if (colstart < 0)
      {
        colstart = 0;
        num1 = tileColNum + colstart;
      }
      else
        num1 = tileColNum - colstart;
      if (num1 < 0)
        return;
      int rowsatrt = (mapId >> (int) this.TileMapInfoWidthMaxOffSet) - startPointY;
      int tileRowNum = (int) this.TileRowNum;
      int num2;
      if (rowsatrt < 0)
      {
        rowsatrt = 0;
        num2 = tileRowNum + rowsatrt;
      }
      else
        num2 = tileRowNum - rowsatrt;
      if (num2 < 0)
        return;
      this.UpdateMap(rowsatrt, rowsatrt + num2, colstart, colstart + num1, startPointX, startPointY);
    }
    else
      this.UpdateMap(0, (int) this.TileRowNum, 0, (int) this.TileColNum, startPointX, startPointY);
  }

  public void UpdatePoint(uint LayoutMapInfoID)
  {
    int startPointX = this.StartID & (int) this.TileMapInfoWidthMaxSubtractOne;
    int colstart = (int) ((long) (LayoutMapInfoID & (uint) this.TileMapInfoWidthMaxSubtractOne) - (long) startPointX) & (int) this.TileMapInfoWidthMaxSubtractOne;
    if (colstart < 0 || colstart >= (int) this.TileColNum)
      return;
    int startPointY = this.StartID >> (int) this.TileMapInfoWidthMaxOffSet;
    int rowsatrt = (int) ((long) (LayoutMapInfoID >> (int) this.TileMapInfoWidthMaxOffSet) - (long) startPointY) & (int) this.TileMapInfoHeightMaxSubtractOne;
    if (rowsatrt < 0 || rowsatrt >= (int) this.TileRowNum)
      return;
    this.UpdateMap(rowsatrt, rowsatrt + 1, colstart, colstart + 1, startPointX, startPointY);
  }

  public void UpdatePoint(byte row, byte col)
  {
    int rowsatrt = (int) row - this.TileColMapStartIDOffset & (int) this.TileRowNumSubtractOne;
    int colstart = (int) col - this.TileRowMapStartIDOffset & (int) this.TileColNumSubtractOne;
    this.UpdateMap(rowsatrt, rowsatrt + 1, colstart, colstart + 1, this.StartID & (int) this.TileMapInfoWidthMaxSubtractOne, this.StartID >> (int) this.TileMapInfoWidthMaxOffSet);
  }

  public void CheckMapNPCBlood(uint LayoutMapInfoID, float blood)
  {
    if (DataManager.MapDataController.LayoutMapInfo[(IntPtr) LayoutMapInfoID].pointKind != (byte) 10)
      return;
    if ((double) blood <= 0.0)
    {
      if ((double) blood > -2.0)
      {
        DataManager.MapDataController.NPCPointTableIDpool.despawn((int) DataManager.MapDataController.LayoutMapInfo[(IntPtr) LayoutMapInfoID].tableID);
        DataManager.MapDataController.LayoutMapInfo[(IntPtr) LayoutMapInfoID].pointKind = (byte) 0;
      }
    }
    else
      DataManager.MapDataController.NPCPointTable[(int) DataManager.MapDataController.LayoutMapInfo[(IntPtr) LayoutMapInfoID].tableID].Blood = blood;
    this.UpdatePoint(LayoutMapInfoID);
  }

  public void UpdateMapNPCBlood(uint LayoutMapInfoID, float blood)
  {
    if (this.npc == null)
    {
      this.CheckMapNPCBlood(LayoutMapInfoID, blood);
    }
    else
    {
      int row = 0;
      int col = 0;
      this.MapIDtoMapTileRowCol(LayoutMapInfoID, ref row, ref col);
      if (row < 0 || col < 0)
        this.CheckMapNPCBlood(LayoutMapInfoID, blood);
      else if ((double) blood == -1.0)
      {
        if ((double) this.npc.getNPCLastBlood(row, col) != 0.0)
          this.UpdatePoint(LayoutMapInfoID);
        else
          this.npc.pushDelNPC(row, col);
      }
      else if ((double) blood == -2.0)
        this.npc.checkNPC(row, col);
      else
        this.npc.setNPC(row, col, blood, LayoutMapInfoID);
    }
  }

  public void UpdateMapNPCHurt(uint LayoutMapInfoID, bool bShow = true)
  {
    if (this.npc == null)
      return;
    int row = 0;
    int col = 0;
    this.MapIDtoMapTileRowCol(LayoutMapInfoID, ref row, ref col);
    if (bShow)
      this.npc.setNPC(row, col, NPCState.NPC_Hurt);
    else
      this.npc.setNPC(row, col);
  }

  public void UpdateMapNPCFighterLeave(uint LayoutMapInfoID, int lineTableID)
  {
    if (this.npc == null)
      return;
    int row = 0;
    int col = 0;
    this.MapIDtoMapTileRowCol(LayoutMapInfoID, ref row, ref col);
    this.npc.setNPC(row, col, lineTableID);
  }

  public sbyte getNPCDir(uint LayoutMapInfoID)
  {
    if (this.npc == null)
      return 0;
    int row = 0;
    int col = 0;
    this.MapIDtoMapTileRowCol(LayoutMapInfoID, ref row, ref col);
    return row < 0 || col < 0 ? (sbyte) 0 : this.npc.getNPCDir(row, col);
  }

  public void setNPCLinenode(uint LayoutMapInfoID, LineNode lineNode)
  {
    if (this.npc == null)
      return;
    int row = 0;
    int col = 0;
    this.MapIDtoMapTileRowCol(LayoutMapInfoID, ref row, ref col);
    this.npc.setNPC(row, col, lineNode, LayoutMapInfoID);
  }

  public void setLine(FlowLineFactory mapLine) => this.line = mapLine;

  public void setWeapon(MapTileModel mapWeapon) => this.weapon = mapWeapon;

  public void setRealmGroup_3DTransform(Transform mapLine3DTransform)
  {
    this.RealmGroup_3DTransform = mapLine3DTransform;
  }

  public void setLevel(MapTileLevel mapLevelLayout)
  {
    this.level = mapLevelLayout;
    this.level.IniLevelImag((int) this.TileRowNum, (int) this.TileColNum, this.TileBaseScale, ((MaskableGraphic) this.TileSprites.m_Image).material);
  }

  public void setBloodName(MapTileBloodName mapBloodNameLayout)
  {
    this.bloodname = mapBloodNameLayout;
    this.bloodname.IniName((int) this.TileRowNum, (int) this.TileColNum);
  }

  public void setGraphicImage(MapTileGraphic mapGraphicLayout)
  {
    this.graphic = mapGraphicLayout;
    this.graphic.IniGraphicImag((int) this.TileRowNum, (int) this.TileColNum, this.TileBaseScale);
  }

  public void setEffect(MapTileEffect mapEffectLayout)
  {
    Front activeGameplay = GameManager.ActiveGameplay as Front;
    this.effect = mapEffectLayout;
    if (activeGameplay != null)
      this.effect.IniEffect((int) this.TileRowNum, (int) this.TileColNum, this.TileBaseScale, true);
    else
      this.effect.IniEffect((int) this.TileRowNum, (int) this.TileColNum, this.TileBaseScale);
  }

  public void setNPC(MapTileNPC mapTileNPCLayout)
  {
    this.npc = mapTileNPCLayout;
    this.npc.IniNPC((int) this.TileRowNum, (int) this.TileColNum, this.TileBaseScale / DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale, DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale, this);
  }

  public void setYolk(MapTileYolk mapTileYolkLayout)
  {
    this.yolk = mapTileYolkLayout;
    this.yolk.IniMapTileYolk(this.TileBaseScale, this.TileHeight);
    int num1 = 0;
    int tileRowNum = (int) this.TileRowNum;
    int num2 = 0;
    int tileColNum = (int) this.TileColNum;
    Vector2 in_StartMapInfoID = new Vector2((float) (this.StartID & (int) this.TileMapInfoWidthMaxSubtractOne), (float) (this.StartID >> (int) this.TileMapInfoWidthMaxOffSet));
    Vector2 zero = Vector2.zero;
    for (int index1 = num1; index1 < tileRowNum; ++index1)
    {
      int num3 = this.BoundStartY + index1;
      if (num3 >= 0 && num3 <= (int) this.TileMapInfoHeightMaxSubtractOne)
      {
        int index2 = this.TileColMapStartIDOffset + index1 & (int) this.TileRowNumSubtractOne;
        for (int index3 = num2; index3 < tileColNum; ++index3)
        {
          int index4 = this.TileRowMapStartIDOffset + index3 & (int) this.TileColNumSubtractOne;
          zero.x = (float) index3;
          zero.y = (float) index1;
          int tileMapInfoId = this.getTileMapInfoID(zero, in_StartMapInfoID);
          int num4 = this.BoundStartX + index3;
          if (num4 >= 0 && num4 <= (int) this.TileMapInfoWidthMaxSubtractOne && this.TileMapInfo[tileMapInfoId] > (byte) 98 && this.TileMapInfo[tileMapInfoId] < (byte) 109)
          {
            this.yolk.setYolk(tileMapInfoId, this.TileRowGroupRectTransform[index2].anchoredPosition + this.TileObjectRectTransform[index4][index2].anchoredPosition);
            return;
          }
        }
      }
    }
  }

  public void setLayoutPosition(int rowsatrt, int rowend, int colstart, int colend)
  {
    if (this.level == null)
      return;
    for (int index1 = rowsatrt; index1 < rowend; ++index1)
    {
      int row = this.TileColMapStartIDOffset + index1 & (int) this.TileRowNumSubtractOne;
      for (int index2 = colstart; index2 < colend; ++index2)
      {
        int col = this.TileRowMapStartIDOffset + index2 & (int) this.TileColNumSubtractOne;
        Vector2 pos = this.TileRowGroupRectTransform[row].anchoredPosition + this.TileObjectRectTransform[col][row].anchoredPosition;
        this.level.setLevelImage(row, col, pos);
        this.bloodname.setName(row, col, pos);
        this.graphic.setGraphicImage(row, col, pos);
        this.effect.setEffect(row, col, pos);
        this.npc.setNPC(row, col, pos);
      }
    }
  }

  public Vector2 getTilePosition(ushort zoneID, byte pointID)
  {
    float num1 = (float) ((((int) zoneID & 1023 & 15) << 4) + ((int) pointID & 15) - (this.centerMapID & (int) this.TileMapInfoWidthMaxSubtractOne));
    int num2 = (((int) zoneID & 1023) >> 4 << 4) + ((int) pointID >> 4);
    int num3 = this.centerMapID >> (int) this.TileMapInfoWidthMaxOffSet;
    float num4 = (num3 & 1) != 0 ? num1 - 0.5f * (float) (1 - (num2 & 1)) : num1 + 0.5f * (float) (num2 & 1);
    int num5 = num3 - num2;
    int index1 = this.TileColMapStartIDOffset + (int) this.BaseCenterID.y & (int) this.TileRowNumSubtractOne;
    int index2 = this.TileRowMapStartIDOffset + (int) this.BaseCenterID.x & (int) this.TileColNumSubtractOne;
    float y = this.TileRowGroupRectTransform[index1].anchoredPosition.y;
    float x = this.TileObjectRectTransform[index2][index1].anchoredPosition.x;
    if ((double) this.BoundStartY + (double) this.BaseCenterID.y > (double) this.TileMapInfoHeightMaxSubtractOne)
      num5 += (int) this.TileMapInfoHeightMax;
    return new Vector2(num4 * (float) ((int) this.TileHeight << 1) + x + GameConstants.MAP_POS_EX[(int) zoneID >> 10, 0], (float) (num5 * ((int) this.TileHeight >> 1)) + y + GameConstants.MAP_POS_EX[(int) zoneID >> 10, 1]);
  }

  public void getTileMapSprite(
    ref Image iImage,
    POINT_KIND pointKind,
    int pointIDorLevel = 0,
    CITY_OUTWARD outward = CITY_OUTWARD.CO_PLAYER)
  {
    int index;
    int num1;
    switch (pointKind)
    {
      case POINT_KIND.PK_NONE:
        if (this.TileMapInfoEx == null || this.TileMapInfoEx[pointIDorLevel] == (byte) 0)
        {
          index = (int) this.TileMapInfo[pointIDorLevel];
          ((Graphic) iImage).color = Color.white;
          goto label_16;
        }
        else
        {
          byte num2 = this.TileMapInfoEx[pointIDorLevel];
          if (num2 > (byte) 191)
          {
            index = (int) num2;
            ((Graphic) iImage).color = Color.white;
            goto label_16;
          }
          else if (num2 == (byte) 1)
          {
            index = 99;
            ((Graphic) iImage).color = (Color) this.color_1;
            goto label_16;
          }
          else if (num2 > (byte) 1 && num2 < (byte) 6)
          {
            index = 103 + (int) num2;
            ((Graphic) iImage).color = (Color) this.color_2;
            goto label_16;
          }
          else if (num2 > (byte) 5 && num2 < (byte) 10)
          {
            index = 95 + (int) num2;
            ((Graphic) iImage).color = (Color) this.color_2;
            goto label_16;
          }
          else
          {
            index = 22;
            ((Graphic) iImage).color = Color.white;
            goto label_16;
          }
        }
      case POINT_KIND.PK_CITY:
        num1 = outward <= CITY_OUTWARD.CO_PLAYER || outward >= CITY_OUTWARD.CO_MAX ? (pointIDorLevel >= 9 ? (pointIDorLevel >= 17 ? (pointIDorLevel >= 25 ? 148 : 147) : 146) : 145) : (int) ((byte) 151 + outward - (byte) 1);
        break;
      case POINT_KIND.PK_CAMP:
        num1 = 149;
        break;
      default:
        num1 = (int) ((byte) 138 + pointKind);
        break;
    }
    index = num1;
    ((Graphic) iImage).color = Color.white;
label_16:
    iImage.sprite = this.TileSprites.GetSprite(index);
  }

  public bool MovebyTileMapPos(int in_posx, int in_posy, bool bsend = true)
  {
    if (!GameConstants.CheckTileMapPos(in_posx, in_posy))
      return false;
    DataManager.msgBuffer[0] = (byte) 65;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    int index1 = this.TileColMapStartIDOffset + (int) this.BaseCenterID.y & (int) this.TileRowNumSubtractOne;
    int index2 = this.TileRowMapStartIDOffset + (int) this.BaseCenterID.x & (int) this.TileColNumSubtractOne;
    this.Movedelta.y = (((float) in_posy - this.centerID.y) * (float) ((int) this.TileHeight >> 1) - this.TileRowGroupRectTransform[index1].anchoredPosition.y) * DataManager.MapDataController.zoomSize;
    this.Movedelta.x = ((this.centerID.x - (float) in_posx) * (float) this.TileHeight - this.TileObjectRectTransform[index2][index1].anchoredPosition.x) * DataManager.MapDataController.zoomSize;
    this.MoveTileBase();
    DataManager.msgBuffer[0] = (byte) 59;
    GameConstants.GetBytes(this.Movedelta.x, DataManager.msgBuffer, 1);
    GameConstants.GetBytes(this.Movedelta.y, DataManager.msgBuffer, 5);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    this.Movedelta = Vector2.zero;
    if (bsend)
      this.RequestMapdata(this.Movedelta);
    return true;
  }

  public void setGoHomeButtonPos(GAME_PLAYER_NEWS buttonmod)
  {
    this.goHomeButtonOffset = this.TileMapRectTransform.sizeDelta * 0.5f;
    if (buttonmod == GAME_PLAYER_NEWS.CHAOS_GoHomePosIn)
      this.goHomeButtonOffset += this.inpos;
    else
      this.goHomeButtonOffset += this.outpos;
    this.updateGoHomeButtonPos();
  }

  public void updateGoHomeButtonPos()
  {
    Vector2 zero = Vector2.zero with
    {
      x = Mathf.Round(this.goHomeButtonOffset.x / ((float) this.TileHeight * DataManager.MapDataController.zoomSize)),
      y = Mathf.Round(this.goHomeButtonOffset.y / ((float) ((int) this.TileHeight >> 1) * DataManager.MapDataController.zoomSize))
    };
    DataManager.msgBuffer[0] = (byte) 76;
    GameConstants.GetBytes(zero.x, DataManager.msgBuffer, 1);
    GameConstants.GetBytes(zero.y, DataManager.msgBuffer, 5);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public bool CheckObstacle(int mapPointID)
  {
    int num1 = mapPointID >> (int) this.TileMapInfoWidthMaxOffSet;
    int num2 = mapPointID & (int) this.TileMapInfoWidthMaxSubtractOne;
    byte num3 = this.TileMapInfo[mapPointID];
    if (num3 >= (byte) 0 && num3 <= (byte) 21)
      return true;
    return num3 >= (byte) 99 && num3 <= (byte) 108;
  }

  public bool RequestMapdata(Vector2 offset, bool renew = false)
  {
    Vector2 spritePosbyBoundId = this.getTileMapSpritePosbyBoundID(!(offset == Vector2.zero) ? this.PosToTileBaseID(new Vector2((float) Screen.width * 0.5f - offset.x, (float) Screen.height * 0.5f - offset.y)) : this.BaseCenterID);
    ushort num1 = (ushort) Math.Max(spritePosbyBoundId.y - 7f, 0.0f);
    ushort num2 = (ushort) Math.Min(spritePosbyBoundId.y + 7f, (float) this.TileMapInfoHeightMaxSubtractOne);
    ushort num3 = (ushort) Math.Max(spritePosbyBoundId.x - 6f, 0.0f);
    ushort num4 = (ushort) Math.Min(spritePosbyBoundId.x + 6f, (float) this.TileMapInfoWidthMaxSubtractOne);
    byte index1 = 0;
    Array.Clear((Array) this.TzoneID, (int) index1, 4);
    ushort[] tzoneId = this.TzoneID;
    int index2 = (int) index1;
    byte nowZoneIDNum = (byte) (index2 + 1);
    int num5 = (int) (ushort) (((int) num3 >> 4) + ((int) num1 >> 4 << 4));
    tzoneId[index2] = (ushort) num5;
    ushort num6 = (ushort) (((int) num4 >> 4) + ((int) num1 >> 4 << 4));
    if ((int) this.TzoneID[(int) nowZoneIDNum - 1] < (int) num6)
      this.TzoneID[(int) nowZoneIDNum++] = num6;
    ushort num7 = (ushort) (((int) num3 >> 4) + ((int) num2 >> 4 << 4));
    if ((int) this.TzoneID[(int) nowZoneIDNum - 1] < (int) num7)
      this.TzoneID[(int) nowZoneIDNum++] = num7;
    ushort num8 = (ushort) (((int) num4 >> 4) + ((int) num2 >> 4 << 4));
    if ((int) this.TzoneID[(int) nowZoneIDNum - 1] < (int) num8)
      this.TzoneID[(int) nowZoneIDNum++] = num8;
    if ((int) DataManager.MapDataController.zoneIDNum == (int) nowZoneIDNum)
    {
      int index3 = -1;
      do
        ;
      while (++index3 < (int) nowZoneIDNum && (int) DataManager.MapDataController.zoneID[index3] == (int) this.TzoneID[index3]);
      if (index3 == (int) nowZoneIDNum)
      {
        DataManager.MapDataController.waitZoneIDNum = (byte) 0;
        DataManager.msgBuffer[0] = (byte) 82;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        return false;
      }
    }
    DataManager.MapDataController.setLastZoneInfo(nowZoneIDNum, this.TzoneID, renew);
    return true;
  }

  public void CheckCenterPos()
  {
    this.updateBaseCenter();
    int mapInfoIdbyStartId = this.getTileMapInfoIDbyStartID(this.BaseCenterID);
    if (this.centerMapID != mapInfoIdbyStartId)
    {
      this.centerMapID = mapInfoIdbyStartId;
      this.centerID = GameConstants.getTileMapPosbyMapID(this.centerMapID);
    }
    Vector2 zero = Vector2.zero;
    int index1 = this.TileColMapStartIDOffset + (int) this.BaseCenterID.y & (int) this.TileRowNumSubtractOne;
    int index2 = this.TileRowMapStartIDOffset + (int) this.BaseCenterID.x & (int) this.TileColNumSubtractOne;
    zero.y = this.TileRowGroupRectTransform[index1].anchoredPosition.y / (float) ((int) this.TileHeight >> 1);
    zero.x = this.TileObjectRectTransform[index2][index1].anchoredPosition.x / (float) this.TileHeight;
    DataManager.msgBuffer[0] = (byte) 63;
    GameConstants.GetBytes(this.centerID.x, DataManager.msgBuffer, 1);
    GameConstants.GetBytes(this.centerID.y, DataManager.msgBuffer, 5);
    GameConstants.GetBytes(zero.x, DataManager.msgBuffer, 9);
    GameConstants.GetBytes(zero.y, DataManager.msgBuffer, 13);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    zero.y = (double) this.BoundStartY + (double) this.BaseCenterID.y <= (double) this.TileMapInfoHeightMaxSubtractOne ? (float) ((((double) this.homePos.y - (double) this.centerID.y) * (double) ((int) this.TileHeight >> 1) - (double) this.TileRowGroupRectTransform[index1].anchoredPosition.y) * (double) DataManager.MapDataController.zoomSize * 2.0) : (float) ((((double) this.homePos.y - (double) this.centerID.y - (double) this.TileMapInfoHeightMax) * (double) ((int) this.TileHeight >> 1) - (double) this.TileRowGroupRectTransform[index1].anchoredPosition.y) * (double) DataManager.MapDataController.zoomSize * 2.0);
    zero.x = (float) ((((double) this.centerID.x - (double) this.homePos.x) * (double) this.TileHeight - (double) this.TileObjectRectTransform[index2][index1].anchoredPosition.x) * (double) DataManager.MapDataController.zoomSize * 2.0);
    if (this.homeSide == (byte) 0)
    {
      if ((double) Math.Abs(zero.y) <= (double) this.TileMapRectTransform.sizeDelta.y && (double) Math.Abs(zero.x) <= (double) this.TileMapRectTransform.sizeDelta.x)
        return;
      this.homeSide = (byte) 1;
      if ((int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
        return;
      DataManager.msgBuffer[0] = (byte) 75;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
    else
    {
      if ((double) Math.Abs(zero.y) >= (double) this.TileMapRectTransform.sizeDelta.y || (double) Math.Abs(zero.x) >= (double) this.TileMapRectTransform.sizeDelta.x)
        return;
      this.homeSide = (byte) 0;
      DataManager.msgBuffer[0] = (byte) 74;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
  }

  public void Check3DPos()
  {
    Vector2 zero = Vector2.zero;
    for (int index1 = 0; index1 < (int) this.TileRowNum; ++index1)
    {
      int row = this.TileColMapStartIDOffset + index1 & (int) this.TileRowNumSubtractOne;
      for (int index2 = 0; index2 < (int) this.TileColNum; ++index2)
      {
        int col = this.TileRowMapStartIDOffset + index2 & (int) this.TileColNumSubtractOne;
        Vector2 pos = this.TileRowGroupRectTransform[row].anchoredPosition + this.TileObjectRectTransform[col][row].anchoredPosition;
        this.effect.setEffect(row, col, DataManager.MapDataController.zoomSize);
        this.npc.setNPC(row, col, pos);
      }
    }
  }

  public void stopFocusGroup()
  {
    if (this.inputState != MapTile.InPutState.Group)
      return;
    if (this.selectLineNode != null)
    {
      DataManager.MapDataController.FocusGroupID = (byte) 10;
      if (this.line != null)
        this.line.easeLineNode(this.selectLineNode);
      else
        this.selectLineNode.bFocus = (byte) 0;
      this.selectLineNode = (LineNode) null;
    }
    DataManager.msgBuffer[0] = (byte) 97;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    this.inputState = MapTile.InPutState.None;
  }

  public bool ClickGroup()
  {
    if (!this.line.OnClick(DataManager.MapDataController.FocusGroupID, ref this.selectLineNode))
      return false;
    this.inputState = MapTile.InPutState.Group;
    this.selectLineMoveY = this.selectLineMoveX = 0.0f;
    DataManager.msgBuffer[0] = (byte) 66;
    GameConstants.GetBytes((uint) this.selectLineNode.lineTableID, DataManager.msgBuffer, 1);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    DataManager.MapDataController.FocusGroupID = (byte) 10;
    this.FocusGroup((byte) 0);
    return true;
  }

  public void updateHomePos()
  {
    this.homePos = GameConstants.getTileMapPosbyMapID(DataManager.Instance.RoleAttr.CapitalPoint);
  }

  public void notSend()
  {
    this.OnDragPos = (Vector2) -Vector3.one;
    this.level.LevelLayout.gameObject.SetActive(false);
    this.bloodname.BloodNameLayout.gameObject.SetActive(false);
  }

  public void SetFocusGroup(int LineTableID, ref LineNode focusNode)
  {
    this.line.OnClick(LineTableID, ref focusNode);
  }

  public void FocusGroup(byte movefactor = 2)
  {
    if (this.selectLineNode != null && this.selectLineNode.gameObject.activeSelf)
    {
      float num1 = 1024f;
      float num2 = 512f;
      this.setFocusGroupDelta(out this.Movedelta);
      this.MoveTileBase();
      this.selectLineMoveX += this.Movedelta.x;
      this.selectLineMoveY += this.Movedelta.y;
      if ((double) Mathf.Abs(this.selectLineMoveX) > (double) num1 || (double) Mathf.Abs(this.selectLineMoveY) > (double) num2)
      {
        this.selectLineMoveX = this.selectLineMoveY = 0.0f;
        this.RequestMapdata(this.Movedelta * (float) movefactor);
      }
      float num3 = DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale * DataManager.MapDataController.zoomSize;
      this.selectLineNode.NodeName.updateNamePos(new Vector2((float) (int) ((double) this.selectLineNode.movingNode.position.x / (double) num3), (float) (int) ((double) this.selectLineNode.movingNode.position.y / (double) num3) + 64f));
    }
    else
    {
      this.selectLineMoveY = this.selectLineMoveX = 0.0f;
      DataManager.msgBuffer[0] = (byte) 65;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
  }

  public void CheckDelFocusGroup(int LineTableID, byte Send = 1)
  {
    if (this.selectLineNode == null || this.selectLineNode.lineTableID != LineTableID)
      return;
    MapLine mapLine = DataManager.MapDataController.MapLineTable[LineTableID];
    if (NetworkManager.ServerTime + 1.0 >= (double) (mapLine.begin + (ulong) mapLine.during))
    {
      PointCode end = DataManager.MapDataController.MapLineTable[LineTableID].end;
      Vector2 mapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(end.zoneID, end.pointID);
      this.MovebyTileMapPos((int) mapPosbyPointCode.x, (int) mapPosbyPointCode.y, Send == (byte) 1);
      this.stopFocusGroup();
    }
    else
    {
      DataManager.msgBuffer[0] = (byte) 65;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
  }

  public void MapIDtoMapTileRowCol(uint LayoutMapInfoID, ref int row, ref int col)
  {
    int num1 = (int) ((long) (LayoutMapInfoID & (uint) this.TileMapInfoWidthMaxSubtractOne) - (long) this.BoundStartX) & (int) this.TileMapInfoWidthMaxSubtractOne;
    if (num1 < 0 || num1 >= (int) this.TileColNum)
    {
      row = col = -1;
    }
    else
    {
      int num2 = (int) ((long) (LayoutMapInfoID >> (int) this.TileMapInfoWidthMaxOffSet) - (long) this.BoundStartY) & (int) this.TileMapInfoHeightMaxSubtractOne;
      if (num2 < 0 || num2 >= (int) this.TileRowNum)
      {
        row = col = -1;
      }
      else
      {
        row = this.TileColMapStartIDOffset + num2 & (int) this.TileRowNumSubtractOne;
        col = this.TileRowMapStartIDOffset + num1 & (int) this.TileColNumSubtractOne;
      }
    }
  }

  public Color getMapTileColorByMapID(uint LayoutMapInfoID)
  {
    if (this.TileMapInfoEx == null || this.TileMapInfoEx[(IntPtr) LayoutMapInfoID] == (byte) 0)
      return Color.white;
    byte num = this.TileMapInfoEx[(IntPtr) LayoutMapInfoID];
    if (num > (byte) 191)
      return Color.white;
    if (num == (byte) 1)
      return (Color) this.color_1;
    if (num > (byte) 1 && num < (byte) 6)
      return (Color) this.color_2;
    return num > (byte) 5 && num < (byte) 10 ? (Color) this.color_2 : Color.white;
  }

  public void ReflashGraphic()
  {
    byte bGraphicFake = this.bGraphicFake;
    this.bGraphicFake = (ActivityManager.Instance.bSpecialMonsterTreasureEvent & 4UL) <= 0UL ? (byte) 0 : (byte) 1;
    if ((int) bGraphicFake == (int) this.bGraphicFake)
      return;
    Vector2 in_StartMapInfoID = new Vector2((float) (this.StartID & (int) this.TileMapInfoWidthMaxSubtractOne), (float) (this.StartID >> (int) this.TileMapInfoWidthMaxOffSet));
    Vector2 zero1 = Vector2.zero;
    Vector2 zero2 = Vector2.zero;
    for (int index1 = 0; index1 < (int) this.TileRowNum; ++index1)
    {
      int num1 = this.BoundStartY + index1;
      bool flag1 = num1 < 0 || num1 > (int) this.TileMapInfoHeightMaxSubtractOne;
      int row = this.TileColMapStartIDOffset + index1 & (int) this.TileRowNumSubtractOne;
      for (int index2 = 0; index2 < (int) this.TileColNum; ++index2)
      {
        int col = this.TileRowMapStartIDOffset + index2 & (int) this.TileColNumSubtractOne;
        zero1.x = (float) index2;
        zero1.y = (float) index1;
        int tileMapInfoId = this.getTileMapInfoID(zero1, in_StartMapInfoID);
        int num2 = this.BoundStartX + index2;
        bool flag2 = flag1 || num2 < 0 || num2 > (int) this.TileMapInfoWidthMaxSubtractOne;
        if (this.level != null && !flag2 && DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) tileMapInfoId) == POINT_KIND.PK_CITY && tileMapInfoId < DataManager.MapDataController.LayoutMapInfo.Length)
        {
          Vector2 pos = this.TileRowGroupRectTransform[row].anchoredPosition + this.TileObjectRectTransform[col][row].anchoredPosition;
          ushort tableId = DataManager.MapDataController.LayoutMapInfo[tileMapInfoId].tableID;
          if ((int) tableId < DataManager.MapDataController.PlayerPointTable.Length)
          {
            PlayerPoint playerPoint = DataManager.MapDataController.PlayerPointTable[(int) tableId];
            if (playerPoint.cityProperty != CITY_PROPERTY.CP_NPC && this.bGraphicFake == (byte) 1)
              this.graphic.setGraphicImage(this.worldTitleIconStartID + (int) DataManager.Instance.TitleDataW.GetRecordByKey((ushort) 1).IconID, row, col, pos, ushort.MaxValue);
            else if (playerPoint.worldTitle == WORLD_PLAYER_DESIGNATION.WKD_1)
              this.graphic.setGraphicImage(this.worldTitleIconStartID + (int) DataManager.Instance.TitleDataW.GetRecordByKey((ushort) playerPoint.worldTitle).IconID, row, col, pos, ushort.MaxValue);
            else if (playerPoint.kingdomTitle == KINGDOM_DESIGNATION.KD_1)
              this.graphic.setGraphicImage(this.kingdomTitleIconStartID + (int) DataManager.Instance.TitleData.GetRecordByKey((ushort) playerPoint.kingdomTitle).IconID, row, col, pos, ushort.MaxValue);
            else if (playerPoint.worldTitle > WORLD_PLAYER_DESIGNATION.WKD_1 && playerPoint.worldTitle < WORLD_PLAYER_DESIGNATION.WKD_MAX)
              this.graphic.setGraphicImage(this.worldTitleIconStartID + (int) DataManager.Instance.TitleDataW.GetRecordByKey((ushort) playerPoint.worldTitle).IconID, row, col, pos, ushort.MaxValue);
            else if (playerPoint.kingdomTitle > KINGDOM_DESIGNATION.KD_1 && playerPoint.kingdomTitle < KINGDOM_DESIGNATION.KD_MAX)
              this.graphic.setGraphicImage(this.kingdomTitleIconStartID + (int) DataManager.Instance.TitleData.GetRecordByKey((ushort) playerPoint.kingdomTitle).IconID, row, col, pos, ushort.MaxValue);
            else if (((int) playerPoint.capitalFlag & 8) != 0)
              this.graphic.setGraphicImage(this.kingdomTitleIconStartID, row, col, pos, ushort.MaxValue);
            else
              this.graphic.setGraphicImage(0, row, col, pos, ushort.MaxValue);
          }
        }
      }
    }
  }

  public void mapTileShowDamageRange(int row, int col, Color in_color)
  {
    if (col >= this.TileBaseImage.Length || row >= this.TileBaseImage[col].Length)
      return;
    ((Graphic) this.TileBaseImage[col][row]).color = in_color;
  }

  public void startFocusMapWeapon(byte focusTypeID = 0)
  {
    this.inputState = MapTile.InPutState.Weapon;
    switch (focusTypeID)
    {
      case 1:
        if ((int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
          break;
        this.startFocusMapWeapon((byte) 0);
        break;
      case 2:
        break;
      case 3:
        break;
      default:
        this.focusMapWeaponTime = 0.0f;
        DataManager.msgBuffer[0] = (byte) 104;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
    }
  }

  public void stopFocusMapWeapon()
  {
    if (this.inputState != MapTile.InPutState.Weapon)
      return;
    this.inputState = MapTile.InPutState.None;
  }

  private bool LoadTileMapFile()
  {
    KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.FocusKingdomID);
    AssetBundle tableAb = DataManager.Instance.GetTableAB();
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.IntToFormat((long) recordByKey.mapID, 3);
    cstring.AppendFormat("TileMap_{0}");
    TextAsset textAsset1 = tableAb.Load(cstring.ToString()) as TextAsset;
    if ((UnityEngine.Object) textAsset1 == (UnityEngine.Object) null)
      return false;
    if (this.TileMapInfo != null)
      Array.Clear((Array) this.TileMapInfo, 0, this.TileMapInfo.Length);
    Stream input1 = (Stream) new MemoryStream(textAsset1.bytes);
    using (BinaryReader binaryReader = new BinaryReader(input1))
    {
      this.TileMapInfo = binaryReader.ReadBytes((int) input1.Length);
      binaryReader.Close();
    }
    input1.Close();
    cstring.ClearString();
    cstring.IntToFormat((long) recordByKey.mapID, 3);
    cstring.AppendFormat("TileMapEx_{0}");
    TextAsset textAsset2 = tableAb.Load(cstring.ToString()) as TextAsset;
    if ((UnityEngine.Object) textAsset2 == (UnityEngine.Object) null)
    {
      this.TileMapInfoEx = (byte[]) null;
      return true;
    }
    if (this.TileMapInfoEx != null)
      Array.Clear((Array) this.TileMapInfoEx, 0, this.TileMapInfoEx.Length);
    Stream input2 = (Stream) new MemoryStream(textAsset2.bytes);
    using (BinaryReader binaryReader = new BinaryReader(input2))
    {
      this.TileMapInfoEx = binaryReader.ReadBytes((int) input2.Length);
      binaryReader.Close();
    }
    input2.Close();
    return true;
  }

  private void SetRect(int Xnum, int Ynum)
  {
    Xnum = Math.Abs(Xnum) & -2;
    Ynum = Math.Abs(Ynum) & -2;
    if (Xnum == 0)
      Xnum = 2;
    if (Ynum == 0)
      Ynum = 2;
    this.TileColNumOffset = (ushort) 0;
    do
      ;
    while (Xnum >> (int) ++this.TileColNumOffset != 1);
    Xnum = 1 << (int) this.TileColNumOffset;
    this.TileRowNumOffset = (ushort) 0;
    do
      ;
    while (Ynum >> (int) ++this.TileRowNumOffset != 1);
    Ynum = 1 << (int) this.TileRowNumOffset;
    byte tileHeight = this.TileHeight;
    int x1 = (int) tileHeight << 1;
    int num1 = (int) tileHeight >> 1;
    this.TileColNum = (ushort) Xnum;
    this.TileColNumSubtractOne = this.TileColNum;
    --this.TileColNumSubtractOne;
    this.TileRowNum = (ushort) Ynum;
    this.TileRowNumSubtractOne = this.TileRowNum;
    --this.TileRowNumSubtractOne;
    this.TileRowGroupRectTransform = new RectTransform[Ynum];
    Array.Clear((Array) this.TileRowGroupRectTransform, 0, this.TileRowGroupRectTransform.Length);
    this.TileObjectRectTransform = new RectTransform[Xnum][];
    for (int index = 0; index < this.TileObjectRectTransform.Length; ++index)
    {
      this.TileObjectRectTransform[index] = new RectTransform[Ynum];
      Array.Clear((Array) this.TileObjectRectTransform[index], 0, this.TileObjectRectTransform[index].Length);
    }
    this.TileBaseRectTransform = new RectTransform[Xnum][];
    for (int index = 0; index < this.TileBaseRectTransform.Length; ++index)
    {
      this.TileBaseRectTransform[index] = new RectTransform[Ynum];
      Array.Clear((Array) this.TileBaseRectTransform[index], 0, this.TileBaseRectTransform[index].Length);
    }
    this.OverTileBaseRectTransform = new RectTransform[Xnum][];
    for (int index = 0; index < this.OverTileBaseRectTransform.Length; ++index)
    {
      this.OverTileBaseRectTransform[index] = new RectTransform[Ynum];
      Array.Clear((Array) this.OverTileBaseRectTransform[index], 0, this.OverTileBaseRectTransform[index].Length);
    }
    this.OverTileBaseGameObject = new GameObject[Xnum][];
    for (int index = 0; index < this.OverTileBaseGameObject.Length; ++index)
    {
      this.OverTileBaseGameObject[index] = new GameObject[Ynum];
      Array.Clear((Array) this.OverTileBaseGameObject[index], 0, this.OverTileBaseGameObject[index].Length);
    }
    this.TileBaseImage = new Image[Xnum][];
    for (int index = 0; index < this.TileBaseImage.Length; ++index)
    {
      this.TileBaseImage[index] = new Image[Ynum];
      Array.Clear((Array) this.TileBaseImage[index], 0, this.TileBaseImage[index].Length);
    }
    this.OverTileBaseImage = new Image[Xnum][];
    for (int index = 0; index < this.OverTileBaseImage.Length; ++index)
    {
      this.OverTileBaseImage[index] = new Image[Ynum];
      Array.Clear((Array) this.OverTileBaseImage[index], 0, this.OverTileBaseImage[index].Length);
    }
    this.TileColMapStartIDOffset = this.TileRowMapStartIDOffset = 0;
    int num2 = DataManager.MapDataController.FocusMapID & (int) this.TileMapInfoWidthMaxSubtractOne;
    int num3 = DataManager.MapDataController.FocusMapID >> (int) this.TileMapInfoWidthMaxOffSet;
    Xnum >>= 1;
    --Xnum;
    int num4 = num2 - Xnum;
    this.BoundStartX = num4;
    int x2 = num4 & (int) this.TileMapInfoWidthMaxSubtractOne;
    Ynum >>= 1;
    int num5 = num3 - Ynum;
    this.BoundStartY = num5;
    int y1 = num5 & (int) this.TileMapInfoHeightMaxSubtractOne;
    this.StartID = y1 << (int) this.TileMapInfoWidthMaxOffSet | x2;
    Vector2 vector2_1 = new Vector2((float) ((int) this.TileColNum * x1), (float) tileHeight);
    Vector2 vector2_2 = new Vector2((float) x1, (float) tileHeight);
    Vector2 in_StartMapInfoID = new Vector2((float) x2, (float) y1);
    float num6 = (float) ((int) this.TileColNumSubtractOne * (num1 >> 1));
    float num7 = (float) ((int) -this.TileColNum * (int) tileHeight - num1 + (int) tileHeight);
    for (int y2 = 0; y2 < this.TileRowGroupRectTransform.Length; ++y2)
    {
      GameObject gameObject1 = new GameObject("TileRowGroup");
      RectTransform rectTransform1 = this.TileRowGroupRectTransform[y2] = gameObject1.AddComponent<RectTransform>();
      rectTransform1.sizeDelta = vector2_1;
      rectTransform1.anchoredPosition = Vector2.up * (num6 - (float) (y2 * num1));
      ((Transform) rectTransform1).SetParent((Transform) this.TileMapRectTransform, false);
      int num8 = this.BoundStartY + y2;
      bool flag = num8 < 0 || num8 > (int) this.TileMapInfoHeightMaxSubtractOne;
      for (int x3 = 0; x3 < (int) this.TileColNum; ++x3)
      {
        GameObject gameObject2 = new GameObject("TileObject");
        RectTransform rectTransform2 = this.TileObjectRectTransform[x3][y2] = gameObject2.AddComponent<RectTransform>();
        rectTransform2.sizeDelta = vector2_2;
        rectTransform2.anchoredPosition = Vector2.right * (num7 + (float) ((int) tileHeight * (y2 + y1 & 1)) + (float) (x3 * x1));
        ((Transform) rectTransform2).SetParent((Transform) this.TileRowGroupRectTransform[y2], false);
        GameObject gameObject3 = new GameObject("TileBase");
        Image image = this.TileBaseImage[x3][y2] = gameObject3.AddComponent<Image>();
        int tileMapInfoId = this.getTileMapInfoID(new Vector2((float) x3, (float) y2), in_StartMapInfoID);
        image.sprite = this.TileSprites.GetSprite((int) this.TileMapInfo[tileMapInfoId]);
        ((MaskableGraphic) image).material = ((MaskableGraphic) this.TileSprites.m_Image).material;
        image.SetNativeSize();
        int num9 = this.BoundStartX + x3;
        if (num9 < 0 || num9 > (int) this.TileMapInfoWidthMaxSubtractOne || flag)
          ((Graphic) image).color = Color.gray;
        RectTransform rectTransform3 = this.TileBaseRectTransform[x3][y2] = gameObject3.transform as RectTransform;
        if ((double) this.TileBaseScale == 0.0)
          this.TileBaseScale = (float) x1 / rectTransform3.sizeDelta.x;
        ((Transform) rectTransform3).localScale = Vector3.one * this.TileBaseScale;
        rectTransform3.anchoredPosition = Vector2.up * (rectTransform3.sizeDelta.y * this.TileBaseScale - (float) this.TileHeight) * 0.5f;
        ((Transform) rectTransform3).SetParent((Transform) this.TileObjectRectTransform[x3][y2], false);
        this.OverTileBaseGameObject[x3][y2] = new GameObject("OverTileBase");
        RectTransform rectTransform4 = this.OverTileBaseGameObject[x3][y2].AddComponent<RectTransform>();
        rectTransform4.sizeDelta = vector2_2;
        rectTransform4.anchoredPosition = (Vector2) Vector3.zero;
        ((Transform) rectTransform4).SetParent((Transform) this.TileObjectRectTransform[x3][y2], false);
        GameObject gameObject4 = new GameObject("Ground");
        ((MaskableGraphic) (this.OverTileBaseImage[x3][y2] = gameObject4.AddComponent<Image>())).material = ((MaskableGraphic) this.TileSprites.m_Image).material;
        RectTransform rectTransform5 = this.OverTileBaseRectTransform[x3][y2] = gameObject4.transform as RectTransform;
        ((Transform) rectTransform5).localScale = Vector3.one * this.TileBaseScale;
        ((Transform) rectTransform5).SetParent(this.OverTileBaseGameObject[x3][y2].transform, false);
        this.OverTileBaseGameObject[x3][y2].SetActive(false);
      }
    }
    this.Movedelta.x = this.TileObjectRectTransform[Xnum][Ynum].anchoredPosition.x;
    this.Movedelta.y = this.TileRowGroupRectTransform[Ynum].anchoredPosition.y;
    this.Movedelta *= -DataManager.MapDataController.zoomSize;
    this.MoveTileBase();
    this.Movedelta = Vector2.zero;
  }

  private void CheckLimit(int in_Startpointx, int in_Startpointy, ref Vector2 inout_movedelta)
  {
    if ((double) inout_movedelta.y < 0.0)
    {
      if (this.BoundStartY < 0)
      {
        float num1 = this.TileMapRectTransform.sizeDelta.y / DataManager.MapDataController.zoomSize;
        float num2 = num1 * 0.5f;
        float num3 = this.TileRowGroupRectTransform[this.TileColMapStartIDOffset - 1 & (int) this.TileRowNumSubtractOne].anchoredPosition.y + (float) ((in_Startpointy + (int) this.TileRowNumSubtractOne & (int) this.TileMapInfoHeightMaxSubtractOne) * ((int) this.TileHeight >> 1)) + num2;
        if ((double) num3 < 0.0)
          num3 += (float) ((int) this.TileHeight >> 1 << (int) this.TileMapInfoHeightMaxOffSet) + num1;
        float num4 = num3 - (num2 - inout_movedelta.y);
        if ((double) num4 < 0.0)
        {
          inout_movedelta.y -= num4;
          this.Movedelta.y = 0.0f;
        }
      }
    }
    else if ((double) inout_movedelta.y > 0.0 && this.BoundStartY >= 0)
    {
      float num5 = this.TileMapRectTransform.sizeDelta.y / DataManager.MapDataController.zoomSize;
      float num6 = num5 * 0.5f;
      float num7 = this.TileRowGroupRectTransform[this.TileColMapStartIDOffset].anchoredPosition.y - (float) (((int) this.TileMapInfoHeightMax - in_Startpointy - 1) * ((int) this.TileHeight >> 1)) - num6;
      if ((double) num7 > 0.0)
        num7 -= (float) ((int) this.TileHeight >> 1 << (int) this.TileMapInfoHeightMaxOffSet) + num5;
      float num8 = num7 + (inout_movedelta.y + num6);
      if ((double) num8 > 0.0)
      {
        inout_movedelta.y -= num8;
        this.Movedelta.y = 0.0f;
      }
    }
    if ((double) inout_movedelta.x < 0.0)
    {
      if (this.BoundStartX < 0)
        return;
      float num9 = this.TileMapRectTransform.sizeDelta.x / DataManager.MapDataController.zoomSize;
      float num10 = num9 * 0.5f;
      float num11 = this.TileObjectRectTransform[this.TileRowMapStartIDOffset][0].anchoredPosition.x + (float) (((int) this.TileMapInfoWidthMax - in_Startpointx - 1) * ((int) this.TileHeight << 1)) + num10;
      if ((double) num11 < 0.0)
        num11 += (float) ((int) this.TileHeight << 1 << (int) this.TileMapInfoWidthMaxOffSet) + num9;
      float num12 = num11 - (num10 - inout_movedelta.x);
      if ((double) num12 >= 0.0)
        return;
      inout_movedelta.x -= num12;
      this.Movedelta.x = 0.0f;
    }
    else
    {
      if ((double) inout_movedelta.x <= 0.0 || this.BoundStartX >= 0)
        return;
      float num13 = this.TileMapRectTransform.sizeDelta.x / DataManager.MapDataController.zoomSize;
      float num14 = num13 * 0.5f;
      float num15 = this.TileObjectRectTransform[this.TileRowMapStartIDOffset - 1 & (int) this.TileColNumSubtractOne][0].anchoredPosition.x - (float) ((in_Startpointx + (int) this.TileColNumSubtractOne & (int) this.TileMapInfoWidthMaxSubtractOne) * ((int) this.TileHeight << 1)) - num14;
      if ((double) num15 > 0.0)
        num15 -= (float) ((int) this.TileHeight << 1 << (int) this.TileMapInfoWidthMaxOffSet) + num13;
      float num16 = num15 + (num14 + inout_movedelta.x);
      if ((double) num16 <= 0.0)
        return;
      inout_movedelta.x -= num16;
      this.Movedelta.x = 0.0f;
    }
  }

  private bool CalculateRollingTime(
    Vector2 in_movedelta,
    out int updownTime,
    out int rightleftTime,
    ref int in_Startpointx,
    ref int in_Startpointy)
  {
    // ISSUE: unable to decompile the method.
  }

  private void SetTileSpriteByMapInfo(int MapInfoid, ref Image iTileImage)
  {
    if (this.TileMapInfoEx == null || this.TileMapInfoEx[MapInfoid] == (byte) 0)
    {
      iTileImage.sprite = this.TileSprites.GetSprite((int) this.TileMapInfo[MapInfoid]);
      ((Graphic) iTileImage).color = Color.white;
    }
    else
    {
      byte index = this.TileMapInfoEx[MapInfoid];
      if (index > (byte) 191)
      {
        iTileImage.sprite = this.TileSprites.GetSprite((int) index);
        ((Graphic) iTileImage).color = Color.white;
      }
      else if (index == (byte) 1)
      {
        iTileImage.sprite = this.TileSprites.GetSprite(99);
        ((Graphic) iTileImage).color = (Color) this.color_1;
      }
      else if (index > (byte) 1 && index < (byte) 6)
      {
        iTileImage.sprite = this.TileSprites.GetSprite(103 + (int) index);
        ((Graphic) iTileImage).color = (Color) this.color_2;
      }
      else if (index > (byte) 5 && index < (byte) 10)
      {
        iTileImage.sprite = this.TileSprites.GetSprite(95 + (int) index);
        ((Graphic) iTileImage).color = (Color) this.color_2;
      }
      else
      {
        iTileImage.sprite = this.TileSprites.GetSprite(22);
        ((Graphic) iTileImage).color = Color.white;
      }
    }
  }

  private void ChangeTileSpriteByMapInfo(int MapInfoid, ref Image iTileImage)
  {
    if (this.TileMapInfo[MapInfoid] < (byte) 22)
      iTileImage.sprite = this.TileSprites.GetSprite((int) this.TileMapInfo[MapInfoid]);
    else if (this.TileMapInfo[MapInfoid] < (byte) 35)
      iTileImage.sprite = this.TileSprites.GetSprite(22);
    else if (this.TileMapInfo[MapInfoid] < (byte) 49)
      iTileImage.sprite = this.TileSprites.GetSprite(35);
    else if (this.TileMapInfo[MapInfoid] < (byte) 69)
      iTileImage.sprite = this.TileSprites.GetSprite((int) this.TileMapInfo[MapInfoid]);
    else if (this.TileMapInfo[MapInfoid] < (byte) 79)
      iTileImage.sprite = this.TileSprites.GetSprite(69);
    else if (this.TileMapInfo[MapInfoid] < (byte) 109)
      iTileImage.sprite = this.TileSprites.GetSprite((int) this.TileMapInfo[MapInfoid]);
    else if (this.TileMapInfo[MapInfoid] < (byte) 113)
      iTileImage.sprite = this.TileMapInfoEx == null || this.TileMapInfoEx[MapInfoid] == (byte) 0 ? this.TileSprites.GetSprite(22) : this.TileSprites.GetSprite((int) this.TileMapInfoEx[MapInfoid]);
    ((Graphic) iTileImage).color = Color.white;
  }

  public void UpdateTickImage()
  {
    if (this.frontIsSheep == (byte) 0)
    {
      for (int index = 0; index < (int) this.frontTickImageNum; ++index)
      {
        if ((UnityEngine.Object) this.tickImage[index] != (UnityEngine.Object) null)
          ((Graphic) this.tickImage[index]).color = this.wolfTickYolkImageColor;
      }
      for (int index1 = 1; index1 <= (int) this.backTickImageNum; ++index1)
      {
        int index2 = 256 - index1;
        if ((UnityEngine.Object) this.tickImage[index2] != (UnityEngine.Object) null)
          ((Graphic) this.tickImage[index2]).color = this.sheepTickYolkImageColor;
      }
    }
    else
    {
      for (int index = 0; index < (int) this.frontTickImageNum; ++index)
      {
        if ((UnityEngine.Object) this.tickImage[index] != (UnityEngine.Object) null)
          ((Graphic) this.tickImage[index]).color = this.sheepTickYolkImageColor;
      }
      for (int index3 = 1; index3 <= (int) this.backTickImageNum; ++index3)
      {
        int index4 = 256 - index3;
        if ((UnityEngine.Object) this.tickImage[index4] != (UnityEngine.Object) null)
          ((Graphic) this.tickImage[index4]).color = this.wolfTickYolkImageColor;
      }
    }
  }

  private void SetTickImage(Image in_image, int in_col, int in_row, bool bseep)
  {
    if (bseep)
    {
      if (this.frontIsSheep == (byte) 0)
      {
        ++this.backTickImageNum;
        byte index = (byte) (256U - (uint) this.backTickImageNum);
        this.tickImageIDToColRow[(int) index] = (byte) ((in_col << 4 | in_row) & (int) byte.MaxValue);
        this.tickColRowToImageID[in_col][in_row] = (ushort) index;
        this.tickImage[(int) index] = in_image;
        ((Graphic) this.tickImage[(int) index]).color = this.sheepTickYolkImageColor;
      }
      else
      {
        this.tickImageIDToColRow[(int) this.frontTickImageNum] = (byte) ((in_col << 4 | in_row) & (int) byte.MaxValue);
        this.tickColRowToImageID[in_col][in_row] = this.frontTickImageNum;
        this.tickImage[(int) this.frontTickImageNum] = in_image;
        ((Graphic) this.tickImage[(int) this.frontTickImageNum]).color = this.sheepTickYolkImageColor;
        ++this.frontTickImageNum;
      }
    }
    else if (this.frontIsSheep == (byte) 0)
    {
      this.tickImageIDToColRow[(int) this.frontTickImageNum] = (byte) ((in_col << 4 | in_row) & (int) byte.MaxValue);
      this.tickColRowToImageID[in_col][in_row] = this.frontTickImageNum;
      this.tickImage[(int) this.frontTickImageNum] = in_image;
      ((Graphic) this.tickImage[(int) this.frontTickImageNum]).color = this.wolfTickYolkImageColor;
      ++this.frontTickImageNum;
    }
    else
    {
      ++this.backTickImageNum;
      byte index = (byte) (256U - (uint) this.backTickImageNum);
      this.tickImageIDToColRow[(int) index] = (byte) ((in_col << 4 | in_row) & (int) byte.MaxValue);
      this.tickColRowToImageID[in_col][in_row] = (ushort) index;
      this.tickImage[(int) index] = in_image;
      ((Graphic) this.tickImage[(int) index]).color = this.wolfTickYolkImageColor;
    }
  }

  private void CheckTickImageRecycling(int in_col, int in_row)
  {
    if (in_col >= this.tickColRowToImageID.Length || in_row >= this.tickColRowToImageID[in_col].Length || this.tickColRowToImageID[in_col][in_row] >= (ushort) 256 || !((UnityEngine.Object) this.tickImage[(int) this.tickColRowToImageID[in_col][in_row]] != (UnityEngine.Object) null))
      return;
    byte index1 = (byte) this.tickColRowToImageID[in_col][in_row];
    if ((int) index1 < (int) this.frontTickImageNum)
    {
      --this.frontTickImageNum;
      this.tickImageIDToColRow[(int) index1] = this.tickImageIDToColRow[(int) this.frontTickImageNum];
      this.tickColRowToImageID[(int) this.tickImageIDToColRow[(int) this.frontTickImageNum] >> 4 & 15][(int) this.tickImageIDToColRow[(int) this.frontTickImageNum] & 15] = (ushort) index1;
      ((Graphic) this.tickImage[(int) index1]).color = Color.white;
      this.tickImage[(int) index1] = this.tickImage[(int) this.frontTickImageNum];
      this.tickImageIDToColRow[(int) this.frontTickImageNum] = (byte) 0;
      this.tickColRowToImageID[in_col][in_row] = (ushort) 256;
      this.tickImage[(int) this.frontTickImageNum] = (Image) null;
    }
    else
    {
      if ((int) index1 < 256 - (int) this.backTickImageNum)
        return;
      byte index2 = (byte) (256U - (uint) this.backTickImageNum);
      --this.backTickImageNum;
      this.tickImageIDToColRow[(int) index1] = this.tickImageIDToColRow[(int) index2];
      this.tickColRowToImageID[(int) this.tickImageIDToColRow[(int) index2] >> 4 & 15][(int) this.tickImageIDToColRow[(int) index2] & 15] = (ushort) index1;
      ((Graphic) this.tickImage[(int) index1]).color = Color.white;
      this.tickImage[(int) index1] = this.tickImage[(int) index2];
      this.tickImageIDToColRow[(int) index2] = (byte) 0;
      this.tickColRowToImageID[in_col][in_row] = (ushort) 256;
      this.tickImage[(int) index2] = (Image) null;
    }
  }

  private void UpdateMap(
    int rowsatrt,
    int rowend,
    int colstart,
    int colend,
    int startPointX,
    int startPointY)
  {
    Vector2 in_StartMapInfoID = new Vector2((float) startPointX, (float) startPointY);
    Vector2 zero = Vector2.zero;
    Vector2 pos = Vector2.zero;
    for (int index1 = rowsatrt; index1 < rowend; ++index1)
    {
      int num1 = this.BoundStartY + index1;
      bool flag1 = num1 < 0 || num1 > (int) this.TileMapInfoHeightMaxSubtractOne;
      int index2 = this.TileColMapStartIDOffset + index1 & (int) this.TileRowNumSubtractOne;
      for (int index3 = colstart; index3 < colend; ++index3)
      {
        int emojiID = -1;
        int index4 = this.TileRowMapStartIDOffset + index3 & (int) this.TileColNumSubtractOne;
        Image iTileImage = this.TileBaseImage[index4][index2];
        zero.x = (float) index3;
        zero.y = (float) index1;
        int tileMapInfoId = this.getTileMapInfoID(zero, in_StartMapInfoID);
        int num2 = this.BoundStartX + index3;
        bool flag2 = flag1 || num2 < 0 || num2 > (int) this.TileMapInfoWidthMaxSubtractOne;
        if (this.level == null)
        {
          this.CheckTickImageRecycling(index4, index2);
          this.SetTileSpriteByMapInfo(tileMapInfoId, ref iTileImage);
          if (flag2)
            ((Graphic) iTileImage).color = Color.gray;
          iTileImage.SetNativeSize();
          RectTransform rectTransform = this.TileBaseRectTransform[index4][index2];
          rectTransform.anchoredPosition = Vector2.up * (rectTransform.sizeDelta.y * this.TileBaseScale - (float) this.TileHeight) * 0.5f;
          this.OverTileBaseGameObject[index4][index2].SetActive(false);
        }
        else if (flag2)
        {
          this.CheckTickImageRecycling(index4, index2);
          this.SetTileSpriteByMapInfo(tileMapInfoId, ref iTileImage);
          ((Graphic) iTileImage).color = Color.gray;
          iTileImage.SetNativeSize();
          RectTransform rectTransform = this.TileBaseRectTransform[index4][index2];
          rectTransform.anchoredPosition = Vector2.up * (rectTransform.sizeDelta.y * this.TileBaseScale - (float) this.TileHeight) * 0.5f;
          this.level.setLevelImage(0, index2, index4, Vector2.zero);
          this.bloodname.setName((CString) null, (CString) null, index2, index4, Color.white, Vector2.zero, (byte) 0, kingdomID: (ushort) 0);
          this.graphic.setGraphicImage(0, index2, index4, Vector2.zero, ushort.MaxValue);
          this.effect.setEffect((byte) 0, index2, index4, Vector2.zero, (byte) 0);
          this.npc.setNPC((ushort) 0, 0U, index2, index4, pos);
          this.OverTileBaseGameObject[index4][index2].SetActive(false);
        }
        else
        {
          POINT_KIND mapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) tileMapInfoId);
          switch (mapInfoPointKind)
          {
            case POINT_KIND.PK_NONE:
              this.CheckTickImageRecycling(index4, index2);
              this.SetTileSpriteByMapInfo(tileMapInfoId, ref iTileImage);
              iTileImage.SetNativeSize();
              RectTransform rectTransform1 = this.TileBaseRectTransform[index4][index2];
              rectTransform1.anchoredPosition = Vector2.up * (rectTransform1.sizeDelta.y * this.TileBaseScale - (float) this.TileHeight) * 0.5f;
              this.level.setLevelImage(0, index2, index4, Vector2.zero);
              this.bloodname.setName((CString) null, (CString) null, index2, index4, Color.white, Vector2.zero, (byte) 0, kingdomID: (ushort) 0);
              this.graphic.setGraphicImage(0, index2, index4, Vector2.zero, ushort.MaxValue);
              this.effect.setEffect((byte) 0, index2, index4, Vector2.zero, (byte) 0);
              this.npc.setNPC((ushort) 0, 0U, index2, index4, Vector2.zero);
              if (this.TileMapInfo[tileMapInfoId] > (byte) 98 && this.TileMapInfo[tileMapInfoId] < (byte) 109)
              {
                pos = this.TileRowGroupRectTransform[index2].anchoredPosition + this.TileObjectRectTransform[index4][index2].anchoredPosition;
                this.yolk.setYolk(tileMapInfoId, pos);
              }
              this.OverTileBaseGameObject[index4][index2].SetActive(false);
              continue;
            case POINT_KIND.PK_YOLK:
              this.SetTileSpriteByMapInfo(tileMapInfoId, ref iTileImage);
              iTileImage.SetNativeSize();
              RectTransform rectTransform2 = this.TileBaseRectTransform[index4][index2];
              rectTransform2.anchoredPosition = Vector2.up * (rectTransform2.sizeDelta.y * this.TileBaseScale - (float) this.TileHeight) * 0.5f;
              this.level.setLevelImage(0, index2, index4, Vector2.zero);
              if (tileMapInfoId == 130944 || tileMapInfoId == 130943)
              {
                this.bloodname.setName((CString) null, (CString) null, index2, index4, Color.white, Vector2.zero, (byte) 0, kingdomID: (ushort) 0);
                this.graphic.setGraphicImage(0, index2, index4, Vector2.zero, ushort.MaxValue);
                this.effect.setEffect((byte) 0, index2, index4, pos, (byte) 0);
              }
              else
              {
                MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int) DataManager.MapDataController.LayoutMapInfo[tileMapInfoId].tableID];
                pos = this.TileRowGroupRectTransform[index2].anchoredPosition + this.TileObjectRectTransform[index4][index2].anchoredPosition;
                if (((int) mapYolk.baseFlag & 1) != 0)
                  emojiID = (int) mapYolk.emojiID;
                if (mapYolk.WonderState == byte.MaxValue)
                  this.bloodname.setName((CString) null, (CString) null, index2, index4, Color.white, Vector2.zero, (byte) 0, kingdomID: (ushort) 0);
                else if (DataManager.MapDataController.FocusKingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
                {
                  if (mapYolk.WonderLeader == null || mapYolk.WonderLeader.Length == 0 || mapYolk.WonderLeader[0] == char.MinValue)
                    this.bloodname.setName(DataManager.MapDataController.GetYolkName((ushort) mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID), mapYolk.WonderAllianceTag, index2, index4, mapYolk.WonderState != (byte) 0 ? this.yolknamecolor : Color.green, pos, (byte) 0, kingdomID: (ushort) 0, emojiID: emojiID, offsety: mapYolk.WonderID <= (byte) 0 ? 410f : 300f);
                  else if (ActivityManager.Instance.IsKOWRunning())
                  {
                    this.tmepStr.ClearString();
                    if (mapYolk.WonderID == (byte) 0)
                      this.tmepStr.Append(DataManager.Instance.mStringTable.GetStringByID(11031U));
                    else
                      this.tmepStr.Append(DataManager.Instance.mStringTable.GetStringByID(11057U));
                    if (DataManager.Instance.IsSameAlliance(mapYolk.WonderAllianceTag))
                      this.bloodname.setName(mapYolk.WonderLeader, mapYolk.WonderAllianceTag, index2, index4, this.lightblue, pos, (byte) 0, kingdomID: (int) mapYolk.LeaderHomeKingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID ? mapYolk.LeaderHomeKingdomID : (ushort) 0, First: this.tmepStr, emojiID: emojiID, offsety: mapYolk.WonderID <= (byte) 0 ? 410f : 300f);
                    else
                      this.bloodname.setName(mapYolk.WonderLeader, mapYolk.WonderAllianceTag, index2, index4, mapYolk.WonderState != (byte) 0 ? this.yolknamecolor : Color.green, pos, (byte) 0, kingdomID: (int) mapYolk.LeaderHomeKingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID ? mapYolk.LeaderHomeKingdomID : (ushort) 0, First: this.tmepStr, emojiID: emojiID, offsety: mapYolk.WonderID <= (byte) 0 ? 410f : 300f);
                  }
                  else if (ActivityManager.Instance.IsNobilityWarRunning() && (int) ActivityManager.Instance.FederalFightingWonderID == (int) mapYolk.WonderID)
                  {
                    this.tmepStr.ClearString();
                    if (mapYolk.WonderID == (byte) 0)
                      this.tmepStr.Append(DataManager.Instance.mStringTable.GetStringByID(10013U));
                    else
                      this.tmepStr.Append(DataManager.Instance.mStringTable.GetStringByID(11031U));
                    if (DataManager.Instance.IsSameAlliance(mapYolk.WonderAllianceTag))
                      this.bloodname.setName(mapYolk.WonderLeader, mapYolk.WonderAllianceTag, index2, index4, this.lightblue, pos, (byte) 0, kingdomID: (int) mapYolk.LeaderHomeKingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID ? mapYolk.LeaderHomeKingdomID : (ushort) 0, First: this.tmepStr, emojiID: emojiID, offsety: mapYolk.WonderID <= (byte) 0 ? 410f : 300f);
                    else
                      this.bloodname.setName(mapYolk.WonderLeader, mapYolk.WonderAllianceTag, index2, index4, mapYolk.WonderState != (byte) 0 ? this.yolknamecolor : Color.green, pos, (byte) 0, kingdomID: (int) mapYolk.LeaderHomeKingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID ? mapYolk.LeaderHomeKingdomID : (ushort) 0, First: this.tmepStr, emojiID: emojiID, offsety: mapYolk.WonderID <= (byte) 0 ? 410f : 300f);
                  }
                  else
                  {
                    this.tmepStr.ClearString();
                    if (mapYolk.WonderID == (byte) 0)
                      this.tmepStr.Append(DataManager.Instance.mStringTable.GetStringByID(10013U));
                    else
                      this.tmepStr.Append(DataManager.Instance.mStringTable.GetStringByID(11057U));
                    if (DataManager.Instance.IsSameAlliance(mapYolk.WonderAllianceTag))
                      this.bloodname.setName(mapYolk.WonderLeader, mapYolk.WonderAllianceTag, index2, index4, this.lightblue, pos, (byte) 0, kingdomID: (int) mapYolk.LeaderHomeKingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID ? mapYolk.LeaderHomeKingdomID : (ushort) 0, First: this.tmepStr, emojiID: emojiID, offsety: mapYolk.WonderID <= (byte) 0 ? 410f : 300f);
                    else
                      this.bloodname.setName(mapYolk.WonderLeader, mapYolk.WonderAllianceTag, index2, index4, mapYolk.WonderState != (byte) 0 ? this.yolknamecolor : Color.green, pos, (byte) 0, kingdomID: (int) mapYolk.LeaderHomeKingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID ? mapYolk.LeaderHomeKingdomID : (ushort) 0, First: this.tmepStr, emojiID: emojiID, offsety: mapYolk.WonderID <= (byte) 0 ? 410f : 300f);
                  }
                }
                else if (DataManager.Instance.IsSameAlliance(mapYolk.WonderAllianceTag))
                  this.bloodname.setName(DataManager.MapDataController.GetYolkName((ushort) mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID), mapYolk.WonderAllianceTag, index2, index4, this.lightblue, pos, (byte) 0, kingdomID: mapYolk.WonderAllianceTag[0] == char.MinValue || (int) mapYolk.AllianceKingdomID == (int) DataManager.Instance.RoleAlliance.KingdomID ? (ushort) 0 : mapYolk.AllianceKingdomID, emojiID: emojiID, offsety: mapYolk.WonderID <= (byte) 0 ? 410f : 300f);
                else
                  this.bloodname.setName(DataManager.MapDataController.GetYolkName((ushort) mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID), mapYolk.WonderAllianceTag, index2, index4, mapYolk.WonderState != (byte) 0 ? this.yolknamecolor : Color.green, pos, (byte) 0, kingdomID: mapYolk.WonderAllianceTag[0] == char.MinValue || (int) mapYolk.AllianceKingdomID == (int) DataManager.Instance.RoleAlliance.KingdomID ? (ushort) 0 : mapYolk.AllianceKingdomID, emojiID: emojiID, offsety: mapYolk.WonderID <= (byte) 0 ? 410f : 300f);
                if (mapYolk.WonderAllianceTag[0] == char.MinValue)
                  this.graphic.setGraphicImage(0, index2, index4, Vector2.zero, ushort.MaxValue);
                else
                  this.graphic.setGraphicImage(-((int) mapYolk.WonderID + 1), index2, index4, pos, mapYolk.OwnerEmblem);
                this.effect.setEffect(mapYolk.WonderFlag, index2, index4, pos, mapYolk.WonderID != (byte) 0 ? (byte) 1 : (byte) 2);
              }
              this.npc.setNPC((ushort) 0, 0U, index2, index4, pos);
              this.yolk.setYolk(tileMapInfoId, pos);
              this.OverTileBaseGameObject[index4][index2].SetActive(false);
              continue;
            case POINT_KIND.PK_DYNAMIC_OBSTACLE:
              this.CheckTickImageRecycling(index4, index2);
              this.SetTileSpriteByMapInfo(tileMapInfoId, ref iTileImage);
              iTileImage.SetNativeSize();
              RectTransform rectTransform3 = this.TileBaseRectTransform[index4][index2];
              rectTransform3.anchoredPosition = Vector2.up * (rectTransform3.sizeDelta.y * this.TileBaseScale - (float) this.TileHeight) * 0.5f;
              this.level.setLevelImage(0, index2, index4, Vector2.zero);
              this.bloodname.setName((CString) null, (CString) null, index2, index4, Color.white, Vector2.zero, (byte) 0, kingdomID: (ushort) 0);
              this.graphic.setGraphicImage(0, index2, index4, Vector2.zero, ushort.MaxValue);
              pos = this.TileRowGroupRectTransform[index2].anchoredPosition + this.TileObjectRectTransform[index4][index2].anchoredPosition;
              if (DataManager.MapDataController.LayoutMapInfo[tileMapInfoId].tableID == (ushort) 1)
                this.effect.setEffect((byte) 16, index2, index4, pos, (byte) 4);
              else
                this.effect.setEffect((byte) 16, index2, index4, pos, (byte) 3);
              this.npc.setNPC((ushort) 0, 0U, index2, index4, pos);
              this.OverTileBaseGameObject[index4][index2].SetActive(false);
              continue;
            default:
              pos = this.TileRowGroupRectTransform[index2].anchoredPosition + this.TileObjectRectTransform[index4][index2].anchoredPosition;
              this.ChangeTileSpriteByMapInfo(tileMapInfoId, ref iTileImage);
              iTileImage.SetNativeSize();
              RectTransform rectTransform4 = this.TileBaseRectTransform[index4][index2];
              rectTransform4.anchoredPosition = Vector2.up * (rectTransform4.sizeDelta.y * this.TileBaseScale - (float) this.TileHeight) * 0.5f;
              Image in_image = this.OverTileBaseImage[index4][index2];
              RectTransform rectTransform5 = this.OverTileBaseRectTransform[index4][index2];
              ushort tableId = DataManager.MapDataController.LayoutMapInfo[tileMapInfoId].tableID;
              switch (mapInfoPointKind)
              {
                case POINT_KIND.PK_CITY:
                  PlayerPoint playerPoint1 = DataManager.MapDataController.PlayerPointTable[(int) tableId];
                  bool flag3 = DataManager.MapDataController.IsEnemy(playerPoint1.kingdomID);
                  TitleData recordByKey;
                  if (playerPoint1.cityProperty != CITY_PROPERTY.CP_NPC && this.bGraphicFake == (byte) 1)
                  {
                    recordByKey = DataManager.Instance.TitleDataW.GetRecordByKey((ushort) 1);
                    this.graphic.setGraphicImage(this.worldTitleIconStartID + (int) recordByKey.IconID, index2, index4, pos, ushort.MaxValue);
                  }
                  else if (playerPoint1.worldTitle == WORLD_PLAYER_DESIGNATION.WKD_1)
                  {
                    recordByKey = DataManager.Instance.TitleDataW.GetRecordByKey((ushort) playerPoint1.worldTitle);
                    this.graphic.setGraphicImage(this.worldTitleIconStartID + (int) recordByKey.IconID, index2, index4, pos, ushort.MaxValue);
                  }
                  else if (playerPoint1.nobilityTitle == (byte) 1)
                  {
                    recordByKey = DataManager.Instance.TitleDataF.GetRecordByKey((ushort) playerPoint1.nobilityTitle);
                    this.graphic.setGraphicImage(this.nobilityTitleIconStartID + (int) recordByKey.IconID, index2, index4, pos, ushort.MaxValue);
                  }
                  else if (playerPoint1.kingdomTitle == KINGDOM_DESIGNATION.KD_1)
                  {
                    recordByKey = DataManager.Instance.TitleData.GetRecordByKey((ushort) playerPoint1.kingdomTitle);
                    this.graphic.setGraphicImage(this.kingdomTitleIconStartID + (int) recordByKey.IconID, index2, index4, pos, ushort.MaxValue);
                  }
                  else if (playerPoint1.worldTitle > WORLD_PLAYER_DESIGNATION.WKD_1 && playerPoint1.worldTitle < WORLD_PLAYER_DESIGNATION.WKD_MAX)
                  {
                    recordByKey = DataManager.Instance.TitleDataW.GetRecordByKey((ushort) playerPoint1.worldTitle);
                    this.graphic.setGraphicImage(this.worldTitleIconStartID + (int) recordByKey.IconID, index2, index4, pos, ushort.MaxValue);
                  }
                  else if (playerPoint1.nobilityTitle > (byte) 1 && playerPoint1.nobilityTitle < (byte) 40)
                  {
                    recordByKey = DataManager.Instance.TitleDataF.GetRecordByKey((ushort) playerPoint1.nobilityTitle);
                    this.graphic.setGraphicImage(this.nobilityTitleIconStartID + (int) recordByKey.IconID, index2, index4, pos, ushort.MaxValue);
                  }
                  else if (playerPoint1.kingdomTitle > KINGDOM_DESIGNATION.KD_1 && playerPoint1.kingdomTitle < KINGDOM_DESIGNATION.KD_MAX)
                  {
                    recordByKey = DataManager.Instance.TitleData.GetRecordByKey((ushort) playerPoint1.kingdomTitle);
                    this.graphic.setGraphicImage(this.kingdomTitleIconStartID + (int) recordByKey.IconID, index2, index4, pos, ushort.MaxValue);
                  }
                  else if (((int) playerPoint1.capitalFlag & 8) != 0)
                    this.graphic.setGraphicImage(this.kingdomTitleIconStartID, index2, index4, pos, ushort.MaxValue);
                  else
                    this.graphic.setGraphicImage(0, index2, index4, pos, ushort.MaxValue);
                  this.npc.setNPC((ushort) 0, 0U, index2, index4, pos);
                  if (((int) playerPoint1.baseFlag & 1) != 0)
                    emojiID = (int) playerPoint1.emojiID;
                  if (playerPoint1.cityProperty == CITY_PROPERTY.CP_NPC)
                  {
                    this.CheckTickImageRecycling(index4, index2);
                    this.effect.setEffect(playerPoint1.capitalFlag, index2, index4, pos, (byte) 4);
                    this.level.setLevelImage((int) playerPoint1.level, index2, index4, pos, true);
                    this.bloodname.setName(playerPoint1.allianceTag, index2, index4, this.npcnamecolor, pos, emojiID);
                    in_image.sprite = playerPoint1.cityOutward == CITY_OUTWARD.CO_PLAYER ? (playerPoint1.level >= (byte) 9 ? (playerPoint1.level >= (byte) 17 ? (playerPoint1.level >= (byte) 25 ? this.TileSprites.GetSprite(148) : this.TileSprites.GetSprite(147)) : this.TileSprites.GetSprite(146)) : this.TileSprites.GetSprite(145)) : (playerPoint1.cityOutward <= CITY_OUTWARD.CO_MAX ? this.TileSprites.GetSprite((int) ((byte) 151 + playerPoint1.cityOutward - (byte) 1)) : this.TileSprites.GetSprite(190));
                    break;
                  }
                  this.effect.setEffect(playerPoint1.capitalFlag, index2, index4, pos, (byte) 3);
                  this.level.setLevelImage((int) playerPoint1.level, index2, index4, pos);
                  if (playerPoint1.playerName == null || playerPoint1.playerName.Length == 0)
                    this.bloodname.setName(playerPoint1.playerName, playerPoint1.allianceTag, index2, index4, Color.white, pos, (byte) 0, kingdomID: (ushort) 0, emojiID: emojiID, offsety: 92f);
                  else if (DataManager.CompareStr(playerPoint1.playerName, DataManager.Instance.RoleAttr.Name) == 0)
                    this.bloodname.setName(playerPoint1.playerName, playerPoint1.allianceTag, index2, index4, this.deepblue, pos, (byte) 0, kingdomID: (ushort) 0, emojiID: emojiID, offsety: 92f);
                  else if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && flag3)
                    this.bloodname.setName(playerPoint1.playerName, playerPoint1.allianceTag, index2, index4, this.lightred, pos, (byte) 0, kingdomID: playerPoint1.kingdomID, emojiID: emojiID, offsety: 92f);
                  else if (DataManager.Instance.IsSameAlliance(playerPoint1.allianceTag))
                    this.bloodname.setName(playerPoint1.playerName, playerPoint1.allianceTag, index2, index4, this.lightblue, pos, (byte) 0, kingdomID: (ushort) 0, emojiID: emojiID, offsety: 92f);
                  else
                    this.bloodname.setName(playerPoint1.playerName, playerPoint1.allianceTag, index2, index4, this.lightyellow, pos, (byte) 0, kingdomID: (ushort) 0, emojiID: emojiID, offsety: 92f);
                  if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && flag3 && !this.bFront)
                  {
                    in_image.sprite = this.TileSprites.GetSprite(151);
                    switch (ActivityManager.Instance.getKvKKingdomType(playerPoint1.kingdomID))
                    {
                      case EKvKKingdomType.EKKT_Target:
                        ushort index5 = this.tickColRowToImageID[index4][index2];
                        if (index5 < (ushort) 256 && (UnityEngine.Object) this.tickImage[(int) index5] != (UnityEngine.Object) null)
                        {
                          if (this.frontIsSheep == (byte) 0)
                          {
                            if ((int) index5 < (int) this.frontTickImageNum)
                            {
                              --this.frontTickImageNum;
                              this.tickImageIDToColRow[(int) index5] = this.tickImageIDToColRow[(int) this.frontTickImageNum];
                              this.tickColRowToImageID[(int) this.tickImageIDToColRow[(int) this.frontTickImageNum] >> 4 & 15][(int) this.tickImageIDToColRow[(int) this.frontTickImageNum] & 15] = index5;
                              ((Graphic) this.tickImage[(int) index5]).color = Color.white;
                              this.tickImage[(int) index5] = this.tickImage[(int) this.frontTickImageNum];
                              this.tickImageIDToColRow[(int) this.frontTickImageNum] = (byte) 0;
                              this.tickColRowToImageID[index4][index2] = (ushort) 256;
                              this.tickImage[(int) this.frontTickImageNum] = (Image) null;
                              this.SetTickImage(in_image, index4, index2, true);
                              break;
                            }
                            break;
                          }
                          if ((int) index5 >= 256 - (int) this.backTickImageNum)
                          {
                            byte index6 = (byte) (256U - (uint) this.backTickImageNum);
                            --this.backTickImageNum;
                            this.tickImageIDToColRow[(int) index5] = this.tickImageIDToColRow[(int) index6];
                            this.tickColRowToImageID[(int) this.tickImageIDToColRow[(int) index6] >> 4 & 15][(int) this.tickImageIDToColRow[(int) index6] & 15] = index5;
                            ((Graphic) this.tickImage[(int) index5]).color = Color.white;
                            this.tickImage[(int) index5] = this.tickImage[(int) index6];
                            this.tickImageIDToColRow[(int) index6] = (byte) 0;
                            this.tickColRowToImageID[index4][index2] = (ushort) 256;
                            this.tickImage[(int) index6] = (Image) null;
                            this.SetTickImage(in_image, index4, index2, true);
                            break;
                          }
                          break;
                        }
                        this.SetTickImage(in_image, index4, index2, true);
                        break;
                      case EKvKKingdomType.EKKT_Hunter:
                        ushort index7 = this.tickColRowToImageID[index4][index2];
                        if (index7 < (ushort) 256 && (UnityEngine.Object) this.tickImage[(int) index7] != (UnityEngine.Object) null)
                        {
                          if (this.frontIsSheep == (byte) 0)
                          {
                            if ((int) index7 >= 256 - (int) this.backTickImageNum)
                            {
                              byte index8 = (byte) (256U - (uint) this.backTickImageNum);
                              --this.backTickImageNum;
                              this.tickImageIDToColRow[(int) index7] = this.tickImageIDToColRow[(int) index8];
                              this.tickColRowToImageID[(int) this.tickImageIDToColRow[(int) index8] >> 4 & 15][(int) this.tickImageIDToColRow[(int) index8] & 15] = index7;
                              ((Graphic) this.tickImage[(int) index7]).color = Color.white;
                              this.tickImage[(int) index7] = this.tickImage[(int) index8];
                              this.tickImageIDToColRow[(int) index8] = (byte) 0;
                              this.tickColRowToImageID[index4][index2] = (ushort) 256;
                              this.tickImage[(int) index8] = (Image) null;
                              this.SetTickImage(in_image, index4, index2, false);
                              break;
                            }
                            break;
                          }
                          if ((int) index7 < (int) this.frontTickImageNum)
                          {
                            --this.frontTickImageNum;
                            this.tickImageIDToColRow[(int) index7] = this.tickImageIDToColRow[(int) this.frontTickImageNum];
                            this.tickColRowToImageID[(int) this.tickImageIDToColRow[(int) this.frontTickImageNum] >> 4 & 15][(int) this.tickImageIDToColRow[(int) this.frontTickImageNum] & 15] = index7;
                            ((Graphic) this.tickImage[(int) index7]).color = Color.white;
                            this.tickImage[(int) index7] = this.tickImage[(int) this.frontTickImageNum];
                            this.tickImageIDToColRow[(int) this.frontTickImageNum] = (byte) 0;
                            this.tickColRowToImageID[index4][index2] = (ushort) 256;
                            this.tickImage[(int) this.frontTickImageNum] = (Image) null;
                            this.SetTickImage(in_image, index4, index2, false);
                            break;
                          }
                          break;
                        }
                        this.SetTickImage(in_image, index4, index2, false);
                        break;
                      default:
                        this.CheckTickImageRecycling(index4, index2);
                        break;
                    }
                  }
                  else
                  {
                    this.CheckTickImageRecycling(index4, index2);
                    in_image.sprite = playerPoint1.cityOutward == CITY_OUTWARD.CO_PLAYER ? (playerPoint1.level >= (byte) 9 ? (playerPoint1.level >= (byte) 17 ? (playerPoint1.level >= (byte) 25 ? this.TileSprites.GetSprite(148) : this.TileSprites.GetSprite(147)) : this.TileSprites.GetSprite(146)) : this.TileSprites.GetSprite(145)) : (playerPoint1.cityOutward <= CITY_OUTWARD.CO_MAX ? this.TileSprites.GetSprite((int) ((byte) 151 + playerPoint1.cityOutward - (byte) 1)) : this.TileSprites.GetSprite(190));
                    break;
                  }
                  break;
                case POINT_KIND.PK_CAMP:
                  this.CheckTickImageRecycling(index4, index2);
                  PlayerPoint playerPoint2 = DataManager.MapDataController.PlayerPointTable[(int) tableId];
                  if (((int) playerPoint2.baseFlag & 1) != 0)
                    emojiID = (int) playerPoint2.emojiID;
                  this.level.setLevelImage(0, index2, index4, pos);
                  this.bloodname.setName((CString) null, (CString) null, index2, index4, Color.white, pos, (byte) 0, kingdomID: (ushort) 0, emojiID: emojiID, offsety: 92f);
                  this.graphic.setGraphicImage(0, index2, index4, pos, ushort.MaxValue);
                  this.effect.setEffect((byte) 0, index2, index4, pos, (byte) 0);
                  this.npc.setNPC((ushort) 0, 0U, index2, index4, pos);
                  in_image.sprite = this.TileSprites.GetSprite(149);
                  break;
                case POINT_KIND.PK_NPC:
                  this.CheckTickImageRecycling(index4, index2);
                  NPCPoint npcPoint = DataManager.MapDataController.NPCPointTable[(int) tableId];
                  if (((int) npcPoint.baseFlag & 1) != 0)
                    emojiID = (int) npcPoint.emojiID;
                  this.level.setLevelImage(0, index2, index4, pos);
                  this.bloodname.setName(npcPoint.NPCNum, index2, index4, this.npcnamecolor, pos, npcPoint.level, npcPoint.Blood, emojiID, npcPoint.NPCAllianceTag, (short) tableId);
                  this.graphic.setGraphicImage(0, index2, index4, pos, ushort.MaxValue);
                  this.effect.setEffect((byte) 0, index2, index4, pos, (byte) 0);
                  this.npc.setNPC(npcPoint.NPCNum, (uint) tileMapInfoId, index2, index4, pos);
                  this.OverTileBaseGameObject[index4][index2].SetActive(false);
                  continue;
                default:
                  this.CheckTickImageRecycling(index4, index2);
                  ResourcesPoint resourcesPoint = DataManager.MapDataController.ResourcesPointTable[(int) tableId];
                  if (((int) resourcesPoint.baseFlag & 1) != 0)
                    emojiID = (int) resourcesPoint.emojiID;
                  this.level.setLevelImage((int) resourcesPoint.level, index2, index4, pos);
                  this.bloodname.setName((CString) null, (CString) null, index2, index4, Color.white, pos, (byte) 0, kingdomID: (ushort) 0, emojiID: emojiID, offsety: 92f);
                  if (resourcesPoint.playerName == null || resourcesPoint.playerName.Length == 0)
                    this.graphic.setGraphicImage(0, index2, index4, pos, ushort.MaxValue);
                  else if (DataManager.CompareStr(resourcesPoint.playerName, DataManager.Instance.RoleAttr.Name) == 0)
                    this.graphic.setGraphicImage(2, index2, index4, pos, ushort.MaxValue);
                  else if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && DataManager.MapDataController.IsEnemy(resourcesPoint.kingdomID))
                    this.graphic.setGraphicImage(4, index2, index4, pos, ushort.MaxValue);
                  else if (DataManager.Instance.IsSameAlliance(resourcesPoint.allianceTag))
                    this.graphic.setGraphicImage(1, index2, index4, pos, ushort.MaxValue);
                  else
                    this.graphic.setGraphicImage(3, index2, index4, pos, ushort.MaxValue);
                  this.effect.setEffect((byte) 0, index2, index4, pos, (byte) 0);
                  this.npc.setNPC((ushort) 0, 0U, index2, index4, pos);
                  in_image.sprite = this.TileSprites.GetSprite((int) ((byte) 138 + mapInfoPointKind));
                  break;
              }
              in_image.SetNativeSize();
              Bounds bounds = in_image.sprite.bounds;
              rectTransform5.pivot = Vector2.one * 0.5f + Vector2.right * (float) (-(double) bounds.center.x / (double) bounds.extents.x / 2.0);
              rectTransform5.anchoredPosition = Vector2.up * (rectTransform5.sizeDelta.y * this.TileBaseScale - (float) this.TileHeight) * 0.5f;
              this.OverTileBaseGameObject[index4][index2].SetActive(true);
              continue;
          }
        }
      }
    }
  }

  private Vector2 PosToTileBaseID(Vector2 in_Pos)
  {
    in_Pos = this.screenToMap(in_Pos);
    float num1 = 0.0f;
    int num2 = 0;
    int y = (int) this.TileRowNumSubtractOne;
    for (int index = y + num2 >> 1; num2 != index; index = y + num2 >> 1)
    {
      num1 = in_Pos.y - this.TileRowGroupRectTransform[this.TileColMapStartIDOffset + index & (int) this.TileRowNumSubtractOne].anchoredPosition.y;
      if ((double) num1 > 0.0)
        y = index;
      else
        num2 = index;
    }
    if (y - num2 != 1)
      return -Vector2.one;
    float num3 = this.TileObjectRectTransform[this.TileRowMapStartIDOffset][this.TileColMapStartIDOffset + num2 & (int) this.TileRowNumSubtractOne].anchoredPosition.x;
    if ((double) this.TileObjectRectTransform[this.TileRowMapStartIDOffset][this.TileColMapStartIDOffset + y & (int) this.TileRowNumSubtractOne].anchoredPosition.x < (double) num3)
    {
      int num4 = num2;
      num2 = y;
      y = num4;
    }
    int num5 = 0;
    int x = (int) this.TileColNumSubtractOne;
    int index1 = this.TileColMapStartIDOffset + num2 & (int) this.TileRowNumSubtractOne;
    for (int index2 = x + num5 >> 1; num5 != index2; index2 = x + num5 >> 1)
    {
      num3 = in_Pos.x - this.TileObjectRectTransform[this.TileRowMapStartIDOffset + index2 & (int) this.TileColNumSubtractOne][index1].anchoredPosition.x;
      if ((double) num3 > 0.0)
        num5 = index2;
      else
        x = index2;
    }
    if ((double) num3 > (double) ((int) this.TileHeight << 1))
      ++x;
    if ((double) num1 < 0.0)
      num1 += (float) ((int) this.TileHeight >> 1);
    float num6 = in_Pos.x - this.TileObjectRectTransform[this.TileRowMapStartIDOffset + x - 1 & (int) this.TileColNumSubtractOne][this.TileColMapStartIDOffset + y & (int) this.TileRowNumSubtractOne].anchoredPosition.x;
    if ((double) num6 < 0.0)
    {
      float num7 = num6 + (float) this.TileHeight;
      --x;
      if (num2 < y)
      {
        if ((double) num1 * 2.0 > (double) num7)
          y = num2;
      }
      else if ((double) num1 < (double) ((int) this.TileHeight >> 1) - 0.5 * (double) num7)
        y = num2;
    }
    else if (num2 < y)
    {
      if ((double) num1 < (double) ((int) this.TileHeight >> 1) - 0.5 * (double) num6)
        --x;
      else
        y = num2;
    }
    else if ((double) num1 * 2.0 < (double) num6)
      y = num2;
    else
      --x;
    return new Vector2((float) x, (float) y);
  }

  private int getTileMapInfoIDbyStartID(Vector2 in_TileBaseID)
  {
    return this.getTileMapInfoID(in_TileBaseID, new Vector2((float) (this.StartID & (int) this.TileMapInfoWidthMaxSubtractOne), (float) (this.StartID >> (int) this.TileMapInfoWidthMaxOffSet)));
  }

  private Vector2 getTileMapSpritePosbyStartID(Vector2 in_TileBaseID)
  {
    int num = this.StartID & (int) this.TileMapInfoWidthMaxSubtractOne;
    int y = (this.StartID >> (int) this.TileMapInfoWidthMaxOffSet) + (int) in_TileBaseID.y & (int) this.TileMapInfoHeightMaxSubtractOne;
    return new Vector2((float) (num + (int) in_TileBaseID.x & (int) this.TileMapInfoWidthMaxSubtractOne), (float) y);
  }

  private Vector2 getTileMapSpritePosbyBoundID(Vector2 in_TileBaseID)
  {
    int boundStartX = this.BoundStartX;
    int y = this.BoundStartY + (int) in_TileBaseID.y;
    if (y < 0)
      y = 0;
    else if (y > (int) this.TileMapInfoHeightMaxSubtractOne)
      y = (int) this.TileMapInfoHeightMaxSubtractOne;
    int x = boundStartX + (int) in_TileBaseID.x;
    if (x < 0)
      x = 0;
    else if (x > (int) this.TileMapInfoWidthMaxSubtractOne)
      x = (int) this.TileMapInfoWidthMaxSubtractOne;
    return new Vector2((float) x, (float) y);
  }

  private int getTileMapInfoID(Vector2 in_TileBaseID, Vector2 in_StartMapInfoID)
  {
    int x = (int) in_StartMapInfoID.x;
    return ((int) in_StartMapInfoID.y + (int) in_TileBaseID.y & (int) this.TileMapInfoHeightMaxSubtractOne) << (int) this.TileMapInfoWidthMaxOffSet | x + (int) in_TileBaseID.x & (int) this.TileMapInfoWidthMaxSubtractOne;
  }

  private void MoveTileBase()
  {
    if (this.Movedelta == Vector2.zero)
      return;
    int in_Startpointx = this.StartID & (int) this.TileMapInfoWidthMaxSubtractOne;
    int in_Startpointy = this.StartID >> (int) this.TileMapInfoWidthMaxOffSet;
    Vector2 inout_movedelta = this.Movedelta / DataManager.MapDataController.zoomSize;
    this.CheckLimit(in_Startpointx, in_Startpointy, ref inout_movedelta);
    if (this.line != null)
      this.line.MoveLine(inout_movedelta * DataManager.MapDataController.zoomSize);
    if (this.weapon != null)
      this.weapon.MapWeaponEffectMove(inout_movedelta * DataManager.MapDataController.zoomSize);
    if (this.yolk != null)
      this.yolk.MoveYolk(inout_movedelta);
    int updownTime = 0;
    int rightleftTime = 0;
    if (this.CalculateRollingTime(inout_movedelta, out updownTime, out rightleftTime, ref in_Startpointx, ref in_Startpointy))
    {
      this.UpdateMap(0, (int) this.TileRowNum, 0, (int) this.TileColNum, in_Startpointx, in_Startpointy);
    }
    else
    {
      int num1 = 0;
      int num2 = (int) this.TileRowNum;
      int colstart = 0;
      int num3 = (int) this.TileColNum;
      if (updownTime > 0)
      {
        num2 = (int) this.TileRowNum - updownTime;
        this.UpdateMap(num2, (int) this.TileRowNum, 0, (int) this.TileColNum, in_Startpointx, in_Startpointy);
      }
      else if (updownTime < 0)
      {
        num1 = -updownTime;
        this.UpdateMap(0, num1, 0, (int) this.TileColNum, in_Startpointx, in_Startpointy);
      }
      if (rightleftTime < 0)
      {
        colstart = -rightleftTime;
        this.UpdateMap(num1, num2, 0, -rightleftTime, in_Startpointx, in_Startpointy);
      }
      else if (rightleftTime > 0)
      {
        num3 = (int) this.TileColNum - rightleftTime;
        this.UpdateMap(num1, num2, num3, (int) this.TileColNum, in_Startpointx, in_Startpointy);
      }
      this.setLayoutPosition(num1, num2, colstart, num3);
    }
    this.StartID = in_Startpointx + in_Startpointy * (int) this.TileMapInfoWidthMax;
    this.CheckCenterPos();
  }

  private void ZoomTile()
  {
    if (Input.touchCount < 2)
    {
      this.inputState = Input.touchCount != 1 ? MapTile.InPutState.None : MapTile.InPutState.Drag;
    }
    else
    {
      Touch touch1 = Input.GetTouch(0);
      Touch touch2 = Input.GetTouch(1);
      Vector2 position1 = touch1.position;
      Vector2 position2 = touch2.position;
      float num1 = (position1 - touch1.deltaPosition - position2 + touch2.deltaPosition).magnitude - (position2 - position1).magnitude;
      Transform parent = ((Transform) this.TileMapRectTransform).parent;
      float num2 = parent.localScale.x + num1 * -0.005f;
      float num3;
      DataManager.MapDataController.zoomSize = num3 = Mathf.Clamp(num2, 0.75f, 1.75f);
      parent.localScale = Vector3.one * num3;
      this.RealmGroup_3DTransform.localScale = Vector3.one * num3;
      this.CheckCenterPos();
      this.updateGoHomeButtonPos();
      this.Check3DPos();
    }
  }

  private void setFocusGroupDelta(out Vector2 out_delta)
  {
    out_delta = new Vector2(this.selectLineNode.movingNode.position.x, this.selectLineNode.movingNode.position.y);
    out_delta /= -((Transform) this.Canvasrectran).localScale.x;
  }

  private Vector2 screenToMap(Vector2 screenPos)
  {
    screenPos.x -= (float) Screen.width * 0.5f;
    screenPos.y -= (float) Screen.height * 0.5f;
    screenPos *= this.TileMapRectTransform.sizeDelta.y / ((float) Screen.height * DataManager.MapDataController.zoomSize);
    return screenPos;
  }

  private void updateBaseCenter()
  {
    this.BaseCenterID = this.PosToTileBaseID(new Vector2((float) Screen.width * 0.5f, (float) Screen.height * 0.5f));
  }

  private void ClosePointInfo()
  {
    DataManager.MapDataController.isMarkGroundInfo = (byte) 0;
    DataManager.msgBuffer[0] = (byte) 65;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  private void FocusMapWeapon()
  {
    this.focusMapWeaponTime -= Time.deltaTime;
    if ((double) this.focusMapWeaponTime >= 0.0)
      return;
    this.focusMapWeaponTime = 0.0f;
    DataManager.MapDataController.SendUseMapWeapon();
  }

  private enum InPutState : byte
  {
    None,
    Click,
    Drag,
    Zoom,
    Group,
    Weapon,
    Count,
  }
}
