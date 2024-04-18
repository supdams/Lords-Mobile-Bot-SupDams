// Decompiled with JetBrains decompiler
// Type: WorldMap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class WorldMap : MonoBehaviour
{
  private const float startMovedeltaFactor = 0.25f;
  private const byte spriteIDoffset = 2;
  private const float OnDragStopTime = 0.5f;
  public Vector2 Movedelta = Vector2.zero;
  public byte[] TileMapInfo;
  public UISpritesArray TileSprites;
  public float TileBaseScale;
  public Vector2 homePos;
  private byte homeSide;
  private byte TileHeight;
  private ushort TileMapInfoWidthMax;
  private ushort TileMapInfoHeightMax;
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
  private RectTransform TileMapRectTransform;
  private RectTransform[] TileRowGroupRectTransform;
  private RectTransform[][] TileObjectRectTransform;
  private RectTransform[][] TileBaseRectTransform;
  private RectTransform[][] OverTileBaseRectTransform;
  private GameObject[][] OverTileBaseGameObject;
  private Image[][] TileBaseImage;
  private Image[][] OverTileBaseImage;
  private byte[] BaseTileMapInfo;
  private WorldMap.InPutState inputState;
  private float MovedeltaFactor = 0.25f;
  private float onDragTimer;
  private Vector2 OnDragPos;
  private Vector2 lastOnDragPos;
  private Vector2 goHomeButtonOffset;
  private WorldMapImage nowWorldMapImage;
  private Vector2 BaseCenterID = -Vector2.one;
  private Vector2 centerID = -Vector2.one;
  private int centerMapID = -1;
  private float clickspeed = 6.66666651f;
  private WorldMapName kingdomName;
  private WorldMapYolk kingdomYolk;
  private WorldMapGraphic kingdomGraphic;
  private WorldMapEffect effect;
  private Color deepblue = new Color(0.207843125f, 0.654902f, 1f);
  private Color lightblue = new Color(0.0f, 1f, 1f);
  private Color lightyellow = new Color(1f, 0.6117647f, 0.0f);
  private Color lightred = new Color(1f, 0.0f, 0.117647f);
  private Vector2 inpos = new Vector2(-182f, -201.5f);
  private Vector2 outpos = new Vector2(-55f, -63.5f);
  private RectTransform Canvasrectran;
  private Transform RealmGroup_3DTransform;
  private Sprite kvkButtonSprite;
  private Sprite titleButtonSprite;
  private Transform kvkButton;
  private float kvkButtonSpeed = 24f;
  private bool bkvkButtonClick;
  private bool btitleButtonClick;
  private bool btitleHintShow;
  private WorldMapGraphicImage nowkvkGraphicImage;

  protected void Awake()
  {
    this.TileHeight = (byte) 128;
    int num1 = (int) DataManager.MapDataController.WorldMaxX - (int) DataManager.MapDataController.WorldMinX + 1;
    int num2 = (int) DataManager.MapDataController.WorldMaxY - (int) DataManager.MapDataController.WorldMinY + 1;
    this.TileMapInfoWidthMax = (ushort) num1;
    this.TileMapInfoHeightMax = (ushort) num2;
    this.LoadTileMapFile();
    this.Canvasrectran = ((Component) GUIManager.Instance.m_UICanvas).transform as RectTransform;
    this.TileMapRectTransform = this.transform as RectTransform;
    ((Transform) this.TileMapRectTransform).position = Vector3.forward * 2048f;
    this.TileMapRectTransform.sizeDelta = this.Canvasrectran.sizeDelta;
    this.TileMapRectTransform.anchoredPosition = Vector2.zero;
    this.TileSprites = this.gameObject.GetComponent<UISpritesArray>();
    this.kvkButtonSprite = this.TileSprites.GetSprite(9);
    this.titleButtonSprite = this.TileSprites.GetSprite(101);
    this.kvkButton = (Transform) null;
    this.nowkvkGraphicImage = (WorldMapGraphicImage) null;
    this.SetRect(16, 16);
    this.OnDragPos = -Vector2.zero;
    this.lastOnDragPos = -Vector2.zero;
    this.onDragTimer = 0.5f;
    this.updateBaseCenter();
  }

  protected void OnDestroy()
  {
    DataManager.MapDataController.FocusWorldMapPos.x = (float) this.BoundStartX;
    DataManager.MapDataController.FocusWorldMapPos.y = (float) this.BoundStartY;
    int index1 = this.TileColMapStartIDOffset & (int) this.TileRowNumSubtractOne;
    int index2 = this.TileRowMapStartIDOffset & (int) this.TileColNumSubtractOne;
    DataManager.MapDataController.coloneWorldMapPos = this.TileRowGroupRectTransform[index1].anchoredPosition + this.TileObjectRectTransform[index2][index1].anchoredPosition;
    int index3 = this.TileColMapStartIDOffset + 1 & (int) this.TileRowNumSubtractOne;
    int index4 = this.TileRowMapStartIDOffset & (int) this.TileColNumSubtractOne;
    DataManager.MapDataController.coltwoWorldMapPos = this.TileRowGroupRectTransform[index3].anchoredPosition + this.TileObjectRectTransform[index4][index3].anchoredPosition;
    DataManager.MapDataController.StartID = this.StartID;
    this.RealmGroup_3DTransform = (Transform) null;
    if (this.TileMapInfo != null)
      Array.Clear((Array) this.TileMapInfo, 0, this.TileMapInfo.Length);
    if (this.TileRowGroupRectTransform != null)
      Array.Clear((Array) this.TileRowGroupRectTransform, 0, this.TileRowGroupRectTransform.Length);
    if (this.TileObjectRectTransform != null)
    {
      for (int index5 = 0; index5 < this.TileObjectRectTransform.Length; ++index5)
      {
        Array.Clear((Array) this.TileObjectRectTransform[index5], 0, this.TileObjectRectTransform[index5].Length);
        this.TileObjectRectTransform[index5] = (RectTransform[]) null;
      }
    }
    if (this.TileBaseRectTransform != null)
    {
      for (int index6 = 0; index6 < this.TileBaseRectTransform.Length; ++index6)
      {
        Array.Clear((Array) this.TileBaseRectTransform[index6], 0, this.TileBaseRectTransform[index6].Length);
        this.TileBaseRectTransform[index6] = (RectTransform[]) null;
      }
    }
    if (this.OverTileBaseRectTransform != null)
    {
      for (int index7 = 0; index7 < this.OverTileBaseRectTransform.Length; ++index7)
      {
        Array.Clear((Array) this.OverTileBaseRectTransform[index7], 0, this.OverTileBaseRectTransform[index7].Length);
        this.OverTileBaseRectTransform[index7] = (RectTransform[]) null;
      }
    }
    if (this.OverTileBaseGameObject != null)
    {
      for (int index8 = 0; index8 < this.OverTileBaseGameObject.Length; ++index8)
      {
        Array.Clear((Array) this.OverTileBaseGameObject[index8], 0, this.OverTileBaseGameObject[index8].Length);
        this.OverTileBaseGameObject[index8] = (GameObject[]) null;
      }
    }
    if (this.TileBaseImage != null)
    {
      for (int index9 = 0; index9 < this.TileBaseImage.Length; ++index9)
      {
        Array.Clear((Array) this.TileBaseImage[index9], 0, this.TileBaseImage[index9].Length);
        this.TileBaseImage[index9] = (Image[]) null;
      }
    }
    if (this.OverTileBaseImage != null)
    {
      for (int index10 = 0; index10 < this.OverTileBaseImage.Length; ++index10)
      {
        Array.Clear((Array) this.OverTileBaseImage[index10], 0, this.OverTileBaseImage[index10].Length);
        this.OverTileBaseImage[index10] = (Image[]) null;
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
    this.Canvasrectran = (RectTransform) null;
  }

  protected void Update()
  {
    DataManager.MapDataController.UpdateWaitKingdom();
    if (this.inputState == WorldMap.InPutState.Zoom)
      this.ZoomTile();
    else if (this.inputState == WorldMap.InPutState.KingdomUp)
    {
      Color color = ((Graphic) this.nowWorldMapImage).color;
      float num = this.clickspeed * Time.deltaTime;
      ((Graphic) this.nowWorldMapImage).color = color + new Color(num, num, num, 0.0f);
      if ((double) ((Graphic) this.nowWorldMapImage).color.g < 1.0)
        return;
      this.inputState = WorldMap.InPutState.KingdomDown;
    }
    else if (this.inputState == WorldMap.InPutState.KingdomDown)
    {
      Color color = ((Graphic) this.nowWorldMapImage).color;
      float num = -this.clickspeed * Time.deltaTime;
      ((Graphic) this.nowWorldMapImage).color = color + new Color(num, num, num, 0.0f);
      if ((double) ((Graphic) this.nowWorldMapImage).color.g > 0.0)
        return;
      DataManager.MapDataController.FocusKingdomID = this.nowWorldMapImage.kingdomID;
      byte kingdomTableID = 0;
      if (DataManager.MapDataController.GetWorldKingdomTableID(this.nowWorldMapImage.kingdomID, out kingdomTableID))
        DataManager.MapDataController.FocusKingdomPeriod = DataManager.MapDataController.WorldKingdomTable[(int) kingdomTableID].kingdomPeriod;
      this.nowWorldMapImage = (WorldMapImage) null;
      this.inputState = WorldMap.InPutState.None;
      if (DataManager.MapDataController.gotoKingdomState > (byte) 0)
      {
        DataManager.msgBuffer[0] = (byte) 113;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      }
      else
        GUIManager.Instance.HideUILock(EUILock.Normal);
    }
    else if ((UnityEngine.Object) this.kvkButton != (UnityEngine.Object) null)
    {
      float num1 = 1.56f;
      if ((double) this.kvkButtonSpeed > 0.0 && (double) this.kvkButton.localScale.x < (double) num1)
      {
        this.kvkButton.localScale += Vector3.one * Time.deltaTime * this.kvkButtonSpeed;
        if ((double) this.kvkButton.localScale.x > (double) num1)
          this.kvkButton.localScale = Vector3.one * num1;
      }
      float num2 = 1.3f;
      if ((double) this.kvkButtonSpeed >= 0.0 || (double) this.kvkButton.localScale.x <= (double) num2)
        return;
      this.kvkButton.localScale += Vector3.one * Time.deltaTime * this.kvkButtonSpeed;
      if ((double) this.kvkButton.localScale.x >= (double) num2)
        return;
      this.kvkButton.localScale = Vector3.one * num2;
      if (this.bkvkButtonClick)
      {
        this.bkvkButtonClick = false;
        DataManager.Instance.MoveTo(this.nowkvkGraphicImage.kingdomID);
      }
      if (this.btitleButtonClick)
      {
        this.btitleButtonClick = false;
        TitleManager.Instance.OpenTitleListN(this.nowkvkGraphicImage.kingdomID);
      }
      this.kvkButton = (Transform) null;
      this.nowkvkGraphicImage = (WorldMapGraphicImage) null;
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
          if ((double) this.onDragTimer > 0.5)
          {
            this.onDragTimer = 0.0f;
            this.OnDragPos = this.lastOnDragPos = -Vector2.one;
            this.RequestMapdata(Vector2.zero);
          }
        }
      }
      if (!(this.Movedelta != Vector2.zero))
        return;
      for (int index = 0; index < 2; ++index)
      {
        if ((double) this.Movedelta[index] != 0.0)
        {
          this.Movedelta[index] *= this.MovedeltaFactor;
          if ((double) Math.Abs(this.Movedelta[index]) < 0.0099999997764825821)
            this.Movedelta[index] = 0.0f;
        }
      }
      float num = 0.95f;
      if ((double) this.MovedeltaFactor >= (double) num)
        return;
      this.MovedeltaFactor += Time.deltaTime * 49f;
      if ((double) this.MovedeltaFactor <= (double) num)
        return;
      this.MovedeltaFactor = num;
    }
  }

  public void OnDrag(PointerEventData eventData)
  {
    switch (this.inputState)
    {
      case WorldMap.InPutState.Click:
        if (!((UnityEngine.Object) eventData.pointerPress != (UnityEngine.Object) this.kvkButton))
          break;
        if ((double) (eventData.position - eventData.pressPosition).magnitude > 50.0)
        {
          this.inputState = WorldMap.InPutState.Drag;
          this.lastOnDragPos = -Vector2.one;
          this.onDragTimer = 0.0f;
          if (this.btitleHintShow)
          {
            GUIManager.Instance.m_Hint.Hide(true);
            this.btitleHintShow = false;
          }
        }
        if (!((UnityEngine.Object) this.kvkButton != (UnityEngine.Object) null) || (double) this.kvkButtonSpeed <= 0.0)
          break;
        this.kvkButtonSpeed *= -1f;
        break;
      case WorldMap.InPutState.Drag:
        this.Movedelta = eventData.delta * (this.TileMapRectTransform.sizeDelta.y / (float) Screen.height);
        this.MoveTileBase();
        this.OnDragPos = eventData.position;
        break;
    }
  }

  public void OnPointerDown(PointerEventData eventData)
  {
    switch (this.inputState)
    {
      case WorldMap.InPutState.None:
        this.inputState = WorldMap.InPutState.Click;
        if ((UnityEngine.Object) this.kvkButton == (UnityEngine.Object) null && (UnityEngine.Object) eventData.pointerEnter != (UnityEngine.Object) null && eventData.pointerEnter.activeSelf)
        {
          WorldMapGraphicImage component = eventData.pointerEnter.GetComponent<WorldMapGraphicImage>();
          if ((UnityEngine.Object) component != (UnityEngine.Object) null)
          {
            if ((UnityEngine.Object) this.kvkButtonSprite == (UnityEngine.Object) component.sprite || (UnityEngine.Object) this.titleButtonSprite == (UnityEngine.Object) component.sprite)
            {
              if ((double) this.kvkButtonSpeed < 0.0)
                this.kvkButtonSpeed *= -1f;
              this.kvkButton = eventData.pointerEnter.transform;
              this.nowkvkGraphicImage = component;
            }
            else
            {
              Vector2 zero = Vector2.zero;
              for (KINGDOM_DESIGNATION kingdomDesignation = KINGDOM_DESIGNATION.KD_1; kingdomDesignation < KINGDOM_DESIGNATION.KD_MAX; ++kingdomDesignation)
              {
                if ((UnityEngine.Object) component.sprite == (UnityEngine.Object) this.TileSprites.GetSprite((int) ((byte) 60 + kingdomDesignation)))
                {
                  this.nowkvkGraphicImage = component;
                  Vector2 viewportPoint = (Vector2) Camera.main.ScreenToViewportPoint((Vector3) eventData.position);
                  viewportPoint.x *= this.Canvasrectran.sizeDelta.x;
                  viewportPoint.y *= this.Canvasrectran.sizeDelta.y;
                  viewportPoint.y -= this.Canvasrectran.sizeDelta.y - 30f * this.TileBaseScale;
                  GUIManager.Instance.m_Hint.Show(viewportPoint, UIHintStyle.eHintSimple, (byte) 1, 300f, 22, 11035, (int) component.kingdomID);
                  this.btitleHintShow = true;
                  return;
                }
              }
            }
          }
        }
        if (this.btitleHintShow)
        {
          GUIManager.Instance.m_Hint.Hide(true);
          this.btitleHintShow = false;
          break;
        }
        break;
      case WorldMap.InPutState.Click:
      case WorldMap.InPutState.Drag:
        if (Input.touchCount > 1)
        {
          this.inputState = WorldMap.InPutState.Zoom;
          if (this.btitleHintShow)
          {
            GUIManager.Instance.m_Hint.Hide(true);
            this.btitleHintShow = false;
            break;
          }
          break;
        }
        break;
    }
    this.Movedelta = Vector2.zero;
  }

  public void OnPointerUp(PointerEventData eventData)
  {
    if ((UnityEngine.Object) this.kvkButton != (UnityEngine.Object) null && (double) this.kvkButtonSpeed > 0.0)
      this.kvkButtonSpeed *= -1f;
    switch (this.inputState)
    {
      case WorldMap.InPutState.Click:
        if ((UnityEngine.Object) this.kvkButton != (UnityEngine.Object) null && (UnityEngine.Object) eventData.pointerEnter == (UnityEngine.Object) this.kvkButton.gameObject)
        {
          WorldMapGraphicImage component = eventData.pointerEnter.GetComponent<WorldMapGraphicImage>();
          if ((UnityEngine.Object) component != (UnityEngine.Object) null && (UnityEngine.Object) component.sprite == (UnityEngine.Object) this.titleButtonSprite)
            this.btitleButtonClick = true;
          else if (DataManager.Instance.bHaveWarBuff)
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9943U), (ushort) byte.MaxValue);
          else
            this.bkvkButtonClick = true;
          this.inputState = WorldMap.InPutState.None;
          break;
        }
        Vector2 in_TileBaseID = this.PosToTileBaseID(eventData.position);
        uint mapInfoIdbyStartId = (uint) this.getTileMapInfoIDbyStartID(in_TileBaseID);
        if ((double) in_TileBaseID.x < 0.0)
          in_TileBaseID = Vector2.zero;
        int num1 = this.TileColMapStartIDOffset + (int) in_TileBaseID.y & (int) this.TileRowNumSubtractOne;
        int num2 = this.TileRowMapStartIDOffset + (int) in_TileBaseID.x & (int) this.TileColNumSubtractOne;
        this.inputState = WorldMap.InPutState.None;
        if (!((UnityEngine.Object) eventData.pointerEnter != (UnityEngine.Object) null) || !eventData.pointerEnter.activeSelf)
          break;
        WorldMapImage component1 = eventData.pointerEnter.GetComponent<WorldMapImage>();
        if ((UnityEngine.Object) component1 != (UnityEngine.Object) null)
        {
          this.inputState = WorldMap.InPutState.KingdomUp;
          GUIManager.Instance.ShowUILock(EUILock.Normal);
          if (this.kingdomYolk != null)
          {
            if ((UnityEngine.Object) this.kingdomYolk.tickYolkImage == (UnityEngine.Object) component1)
            {
              ((Graphic) this.kingdomYolk.tickYolkImage).color = Color.black;
              this.kingdomYolk.tickYolkImage = (WorldMapImage) null;
            }
            else
            {
              bool flag = true;
              for (int index = 0; index < this.kingdomYolk.sheepTickImageNum; ++index)
              {
                if ((UnityEngine.Object) this.kingdomYolk.sheepTickImage[index] != (UnityEngine.Object) null && (UnityEngine.Object) this.kingdomYolk.sheepTickImage[index] == (UnityEngine.Object) component1)
                {
                  --this.kingdomYolk.sheepTickImageNum;
                  ((Graphic) this.kingdomYolk.sheepTickImage[index]).color = Color.black;
                  this.kingdomYolk.sheepTickImage[index] = this.kingdomYolk.sheepTickImage[this.kingdomYolk.sheepTickImageNum];
                  this.kingdomYolk.sheepTickImage[this.kingdomYolk.sheepTickImageNum] = (WorldMapImage) null;
                  flag = false;
                  break;
                }
              }
              if (flag)
              {
                for (int index = 0; index < this.kingdomYolk.wolfTickImageNum; ++index)
                {
                  if ((UnityEngine.Object) this.kingdomYolk.wolfTickImage[index] != (UnityEngine.Object) null && (UnityEngine.Object) this.kingdomYolk.wolfTickImage[index] == (UnityEngine.Object) component1)
                  {
                    --this.kingdomYolk.wolfTickImageNum;
                    ((Graphic) this.kingdomYolk.wolfTickImage[index]).color = Color.black;
                    this.kingdomYolk.wolfTickImage[index] = this.kingdomYolk.wolfTickImage[this.kingdomYolk.wolfTickImageNum];
                    this.kingdomYolk.wolfTickImage[this.kingdomYolk.wolfTickImageNum] = (WorldMapImage) null;
                    break;
                  }
                }
              }
            }
          }
          this.nowWorldMapImage = component1;
          ++DataManager.MapDataController.gotoKingdomState;
          DataManager.msgBuffer[0] = (byte) 106;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          DataManager.msgBuffer[0] = (byte) 117;
          GameConstants.GetBytes(this.nowWorldMapImage.kingdomID, DataManager.msgBuffer, 1);
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          break;
        }
        WorldMapText component2 = eventData.pointerEnter.GetComponent<WorldMapText>();
        if (!((UnityEngine.Object) component2 != (UnityEngine.Object) null))
          break;
        this.inputState = WorldMap.InPutState.KingdomUp;
        GUIManager.Instance.ShowUILock(EUILock.Normal);
        this.nowWorldMapImage = this.kingdomYolk.getYolkImage(component2.row, component2.col);
        if ((UnityEngine.Object) this.kingdomYolk.tickYolkImage == (UnityEngine.Object) this.nowWorldMapImage)
        {
          ((Graphic) this.kingdomYolk.tickYolkImage).color = Color.black;
          this.kingdomYolk.tickYolkImage = (WorldMapImage) null;
        }
        else
        {
          bool flag = true;
          for (int index = 0; index < this.kingdomYolk.sheepTickImageNum; ++index)
          {
            if ((UnityEngine.Object) this.kingdomYolk.sheepTickImage[index] != (UnityEngine.Object) null && (UnityEngine.Object) this.kingdomYolk.sheepTickImage[index] == (UnityEngine.Object) this.nowWorldMapImage)
            {
              --this.kingdomYolk.sheepTickImageNum;
              ((Graphic) this.kingdomYolk.sheepTickImage[index]).color = Color.black;
              this.kingdomYolk.sheepTickImage[index] = this.kingdomYolk.sheepTickImage[this.kingdomYolk.sheepTickImageNum];
              this.kingdomYolk.sheepTickImage[this.kingdomYolk.sheepTickImageNum] = (WorldMapImage) null;
              flag = false;
              break;
            }
          }
          if (flag)
          {
            for (int index = 0; index < this.kingdomYolk.wolfTickImageNum; ++index)
            {
              if ((UnityEngine.Object) this.kingdomYolk.wolfTickImage[index] != (UnityEngine.Object) null && (UnityEngine.Object) this.kingdomYolk.wolfTickImage[index] == (UnityEngine.Object) this.nowWorldMapImage)
              {
                --this.kingdomYolk.wolfTickImageNum;
                ((Graphic) this.kingdomYolk.wolfTickImage[index]).color = Color.black;
                this.kingdomYolk.wolfTickImage[index] = this.kingdomYolk.wolfTickImage[this.kingdomYolk.wolfTickImageNum];
                this.kingdomYolk.wolfTickImage[this.kingdomYolk.wolfTickImageNum] = (WorldMapImage) null;
                break;
              }
            }
          }
        }
        ++DataManager.MapDataController.gotoKingdomState;
        DataManager.msgBuffer[0] = (byte) 106;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        DataManager.msgBuffer[0] = (byte) 117;
        GameConstants.GetBytes(this.nowWorldMapImage.kingdomID, DataManager.msgBuffer, 1);
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
      case WorldMap.InPutState.Drag:
        this.Movedelta = eventData.delta * (this.TileMapRectTransform.sizeDelta.y / (float) Screen.height);
        this.MovedeltaFactor = 0.25f;
        this.inputState = WorldMap.InPutState.None;
        this.OnDragPos = -Vector2.one;
        Vector2 movedelta1 = this.Movedelta;
        Vector2 movedelta2 = this.Movedelta;
        float num3 = this.MovedeltaFactor;
        while (movedelta2 != Vector2.zero)
        {
          for (int index = 0; index < 2; ++index)
          {
            if ((double) movedelta2[index] != 0.0)
            {
              movedelta2[index] *= num3;
              if ((double) Math.Abs(movedelta2[index]) < 0.0099999997764825821)
                movedelta2[index] = 0.0f;
            }
          }
          movedelta1 += movedelta2;
          float num4 = 0.95f;
          if ((double) num3 < (double) num4)
          {
            num3 += Time.deltaTime * 49f;
            if ((double) num3 > (double) num4)
              num3 = num4;
          }
        }
        Vector2 inout_movedelta = movedelta1 / DataManager.MapDataController.worldZoomSize;
        this.CheckLimit(this.StartID % (int) this.TileMapInfoWidthMax, this.StartID / (int) this.TileMapInfoWidthMax, ref inout_movedelta);
        this.RequestMapdata(inout_movedelta);
        break;
      case WorldMap.InPutState.Zoom:
        if (Input.touchCount == 1)
        {
          this.inputState = WorldMap.InPutState.Drag;
          if (!this.btitleHintShow)
            break;
          GUIManager.Instance.m_Hint.Hide(true);
          this.btitleHintShow = false;
          break;
        }
        if (Input.touchCount >= 1)
          break;
        this.inputState = WorldMap.InPutState.None;
        if (!this.btitleHintShow)
          break;
        GUIManager.Instance.m_Hint.Hide(true);
        this.btitleHintShow = false;
        break;
    }
  }

  public void UpdateKingdom(byte kingdomtableid, byte updatekind)
  {
    if ((int) kingdomtableid >= DataManager.MapDataController.WorldKingdomTable.Length)
      return;
    KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomID);
    int num1 = (int) recordByKey.worldPosX - (int) DataManager.MapDataController.WorldMinX - this.BoundStartX;
    if (num1 < 0 || num1 >= (int) this.TileColNum)
      return;
    int num2 = (int) recordByKey.worldPosY - (int) DataManager.MapDataController.WorldMinY - this.BoundStartY;
    if (num2 < 0 || num2 >= (int) this.TileRowNum)
      return;
    int row = this.TileColMapStartIDOffset + num2 & (int) this.TileRowNumSubtractOne;
    int col = this.TileRowMapStartIDOffset + num1 & (int) this.TileColNumSubtractOne;
    Vector2 pos1 = this.TileRowGroupRectTransform[row].anchoredPosition + this.TileObjectRectTransform[col][row].anchoredPosition;
    switch ((MAP_UPDATE_KIND) updatekind)
    {
      case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_FLAG:
        this.kingdomName.setName(kingdomtableid, row, col, Color.white, pos1);
        int num3 = 0;
        byte title1 = (byte) ((uint) DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomFlag >> 3);
        if (title1 > (byte) 0)
          num3 = 8;
        else if (DataManager.Instance.RoleAttr.WorldTitle_Personal == (ushort) 1 && TitleManager.Instance.CheckGivetNTile() && DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod < KINGDOM_PERIOD.KP_WORLD_WAR)
          num3 = 4;
        if ((int) recordByKey.KingdomMapKey == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
        {
          switch (ActivityManager.Instance.getKvKKingdomType(recordByKey.KingdomMapKey))
          {
            case EKvKKingdomType.EKKT_Target:
              num3 += 16;
              break;
            case EKvKKingdomType.EKKT_Hunter:
              num3 += 32;
              break;
          }
          this.kingdomGraphic.setGraphicImage(1 + num3, row, col, pos1, (int) recordByKey.mapID, recordByKey.KingdomMapKey, title1);
        }
        else if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && (int) recordByKey.KingdomMapKey == (int) DataManager.MapDataController.kingdomData.kingdomID || DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && this.CheckShowTransmission(recordByKey.KingdomMapKey) && DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod == KINGDOM_PERIOD.KP_KVK)
        {
          switch (ActivityManager.Instance.getKvKKingdomType(recordByKey.KingdomMapKey))
          {
            case EKvKKingdomType.EKKT_Target:
              num3 += 16;
              break;
            case EKvKKingdomType.EKKT_Hunter:
              num3 += 32;
              break;
          }
          this.kingdomGraphic.setGraphicImage(2 + num3, row, col, pos1, (int) recordByKey.mapID, recordByKey.KingdomMapKey, title1);
        }
        else
          this.kingdomGraphic.setGraphicImage(0 + num3, row, col, pos1, (int) recordByKey.mapID, recordByKey.KingdomMapKey, title1);
        if (DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && ((int) DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomFlag & 2) != 0)
        {
          this.effect.setEffect((byte) 1, row, col, pos1, (byte) 0);
          break;
        }
        this.effect.setEffect((byte) 0, row, col, pos1, (byte) 0);
        break;
      case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_PERIOD:
        Vector2 pos2 = this.TileRowGroupRectTransform[row].anchoredPosition + this.TileObjectRectTransform[col][row].anchoredPosition;
        this.kingdomYolk.setYolkImage((int) recordByKey.KingdomMapKey, row, col, pos2);
        this.kingdomName.setName(kingdomtableid, row, col, Color.white, pos2);
        int num4 = 0;
        byte title2 = (byte) ((uint) DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomFlag >> 3);
        if (title2 > (byte) 0)
          num4 = 8;
        else if (DataManager.Instance.RoleAttr.WorldTitle_Personal == (ushort) 1 && TitleManager.Instance.CheckGivetNTile() && DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod < KINGDOM_PERIOD.KP_WORLD_WAR)
          num4 = 4;
        if ((int) recordByKey.KingdomMapKey == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
        {
          switch (ActivityManager.Instance.getKvKKingdomType(recordByKey.KingdomMapKey))
          {
            case EKvKKingdomType.EKKT_Target:
              num4 += 16;
              break;
            case EKvKKingdomType.EKKT_Hunter:
              num4 += 32;
              break;
          }
          this.kingdomGraphic.setGraphicImage(1 + num4, row, col, pos2, (int) recordByKey.mapID, recordByKey.KingdomMapKey, title2);
          break;
        }
        if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && (int) recordByKey.KingdomMapKey == (int) DataManager.MapDataController.kingdomData.kingdomID || DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && this.CheckShowTransmission(recordByKey.KingdomMapKey) && DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod == KINGDOM_PERIOD.KP_KVK)
        {
          switch (ActivityManager.Instance.getKvKKingdomType(recordByKey.KingdomMapKey))
          {
            case EKvKKingdomType.EKKT_Target:
              num4 += 16;
              break;
            case EKvKKingdomType.EKKT_Hunter:
              num4 += 32;
              break;
          }
          this.kingdomGraphic.setGraphicImage(2 + num4, row, col, pos2, (int) recordByKey.mapID, recordByKey.KingdomMapKey, title2);
          break;
        }
        this.kingdomGraphic.setGraphicImage(0 + num4, row, col, pos2, (int) recordByKey.mapID, recordByKey.KingdomMapKey, title2);
        break;
      case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM:
        Vector2 pos3 = this.TileRowGroupRectTransform[row].anchoredPosition + this.TileObjectRectTransform[col][row].anchoredPosition;
        this.kingdomYolk.setYolkImage((int) recordByKey.KingdomMapKey, row, col, pos3);
        this.kingdomName.setName(kingdomtableid, row, col, Color.white, pos3);
        int num5 = 0;
        byte title3 = (byte) ((uint) DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomFlag >> 3);
        if (title3 > (byte) 0)
          num5 = 8;
        else if (DataManager.Instance.RoleAttr.WorldTitle_Personal == (ushort) 1 && TitleManager.Instance.CheckGivetNTile() && DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod < KINGDOM_PERIOD.KP_WORLD_WAR)
          num5 = 4;
        if ((int) recordByKey.KingdomMapKey == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
        {
          switch (ActivityManager.Instance.getKvKKingdomType(recordByKey.KingdomMapKey))
          {
            case EKvKKingdomType.EKKT_Target:
              num5 += 16;
              break;
            case EKvKKingdomType.EKKT_Hunter:
              num5 += 32;
              break;
          }
          this.kingdomGraphic.setGraphicImage(1 + num5, row, col, pos3, (int) recordByKey.mapID, recordByKey.KingdomMapKey, title3);
        }
        else if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && (int) recordByKey.KingdomMapKey == (int) DataManager.MapDataController.kingdomData.kingdomID || DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && this.CheckShowTransmission(recordByKey.KingdomMapKey) && DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod == KINGDOM_PERIOD.KP_KVK)
        {
          switch (ActivityManager.Instance.getKvKKingdomType(recordByKey.KingdomMapKey))
          {
            case EKvKKingdomType.EKKT_Target:
              num5 += 16;
              break;
            case EKvKKingdomType.EKKT_Hunter:
              num5 += 32;
              break;
          }
          this.kingdomGraphic.setGraphicImage(2 + num5, row, col, pos3, (int) recordByKey.mapID, recordByKey.KingdomMapKey, title3);
        }
        else
          this.kingdomGraphic.setGraphicImage(0 + num5, row, col, pos3, (int) recordByKey.mapID, recordByKey.KingdomMapKey, title3);
        if (DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && ((int) DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomFlag & 2) != 0)
        {
          this.effect.setEffect((byte) 1, row, col, pos3, (byte) 0);
          break;
        }
        this.effect.setEffect((byte) 0, row, col, pos3, (byte) 0);
        break;
      case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_TIME:
      case MAP_UPDATE_KIND.MAPUPDATE_KINGDOM_OWNERKINGDOMID:
        this.kingdomName.setName(kingdomtableid, row, col, Color.white, pos1);
        if (DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && ((int) DataManager.MapDataController.WorldKingdomTable[(int) kingdomtableid].kingdomFlag & 2) != 0)
        {
          this.effect.setEffect((byte) 1, row, col, pos1, (byte) 0);
          break;
        }
        this.effect.setEffect((byte) 0, row, col, pos1, (byte) 0);
        break;
    }
  }

  public bool CheckShowTransmission(ushort mkingdomID)
  {
    bool flag = false;
    if (((int) mkingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID || ActivityManager.Instance.GetKvKState() == EActivityState.EAS_Run) && (!ActivityManager.Instance.IsMatchKvk() || ActivityManager.Instance.IsMatchKvk_kingdom(mkingdomID)))
      flag = true;
    else if ((int) mkingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID && ActivityManager.Instance.GetKvKState() == EActivityState.EAS_Run && ActivityManager.Instance.IsMatchKvk_kingdom(mkingdomID))
      flag = true;
    return flag;
  }

  public void setKingdomYolk(WorldMapYolk kingdomYolkLayout)
  {
    this.kingdomYolk = kingdomYolkLayout;
    this.kingdomYolk.IniYolkImag((int) this.TileRowNum, (int) this.TileColNum, this.TileBaseScale, ((MaskableGraphic) this.TileSprites.m_Image).material);
  }

  public void setKingdomName(WorldMapName worldMapNameLayout)
  {
    this.kingdomName = worldMapNameLayout;
    this.kingdomName.IniName((int) this.TileRowNum, (int) this.TileColNum, this.TileBaseScale);
  }

  public void setKingdomGraphic(WorldMapGraphic worldMapGraphicLayout)
  {
    this.kingdomGraphic = worldMapGraphicLayout;
    this.kingdomGraphic.IniGraphicImag((int) this.TileRowNum, (int) this.TileColNum, this.TileBaseScale);
  }

  public void setEffect(WorldMapEffect mapEffectLayout)
  {
    this.effect = mapEffectLayout;
    this.effect.IniEffect((int) this.TileRowNum, (int) this.TileColNum, this.TileBaseScale);
  }

  public void setRealmGroup_3DTransform(Transform mapLine3DTransform)
  {
    this.RealmGroup_3DTransform = mapLine3DTransform;
  }

  public void setLayoutPosition(int rowsatrt, int rowend, int colstart, int colend)
  {
    if (this.kingdomName == null)
      return;
    for (int index1 = rowsatrt; index1 < rowend; ++index1)
    {
      int row = this.TileColMapStartIDOffset + index1 & (int) this.TileRowNumSubtractOne;
      for (int index2 = colstart; index2 < colend; ++index2)
      {
        int col = this.TileRowMapStartIDOffset + index2 & (int) this.TileColNumSubtractOne;
        Vector2 pos = this.TileRowGroupRectTransform[row].anchoredPosition + this.TileObjectRectTransform[col][row].anchoredPosition;
        this.kingdomYolk.setYolkImage(row, col, pos);
        this.kingdomName.setName(row, col, pos);
        this.kingdomGraphic.setGraphicImage(row, col, pos);
        this.effect.setEffect(row, col, pos);
      }
    }
  }

  public bool MovebyTileMapPos(int in_posx, int in_posy, bool bsend = true)
  {
    if (!GameConstants.CheckTileMapPos(in_posx, in_posy))
      return false;
    int index1 = this.TileColMapStartIDOffset + (int) this.BaseCenterID.y & (int) this.TileRowNumSubtractOne;
    int index2 = this.TileRowMapStartIDOffset + (int) this.BaseCenterID.x & (int) this.TileColNumSubtractOne;
    this.Movedelta.y = (((float) in_posy - this.centerID.y) * (float) ((int) this.TileHeight >> 1) - this.TileRowGroupRectTransform[index1].anchoredPosition.y) * DataManager.MapDataController.worldZoomSize;
    this.Movedelta.x = ((this.centerID.x - (float) in_posx) * (float) this.TileHeight - this.TileObjectRectTransform[index2][index1].anchoredPosition.x) * DataManager.MapDataController.worldZoomSize;
    this.MoveTileBase();
    this.Movedelta = Vector2.zero;
    if (bsend)
      this.RequestMapdata(this.Movedelta);
    return true;
  }

  public void setGoHomeButtonPos(GAME_PLAYER_NEWS buttonmod)
  {
    this.goHomeButtonOffset = this.TileMapRectTransform.sizeDelta * 0.5f;
    if (buttonmod == GAME_PLAYER_NEWS.COSMOS_GoHomePosIn)
      this.goHomeButtonOffset += this.inpos;
    else
      this.goHomeButtonOffset += this.outpos;
    this.updateGoHomeButtonPos();
  }

  public void updateGoHomeButtonPos()
  {
    Vector2 zero = Vector2.zero with
    {
      x = Mathf.Round(this.goHomeButtonOffset.x / ((float) this.TileHeight * DataManager.MapDataController.worldZoomSize)),
      y = Mathf.Round(this.goHomeButtonOffset.y / ((float) ((int) this.TileHeight >> 1) * DataManager.MapDataController.worldZoomSize))
    };
    DataManager.msgBuffer[0] = (byte) 112;
    GameConstants.GetBytes(zero.x, DataManager.msgBuffer, 1);
    GameConstants.GetBytes(zero.y, DataManager.msgBuffer, 5);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public bool RequestMapdata(Vector2 offset, bool renew = false)
  {
    int num1 = (double) offset.x <= 0.0 ? Mathf.FloorToInt(offset.x * 0.5f / (float) this.TileHeight) : Mathf.CeilToInt(offset.x * 0.5f / (float) this.TileHeight);
    int num2 = ((double) offset.y <= 0.0 ? Mathf.FloorToInt(offset.y / (float) this.TileHeight) : Mathf.CeilToInt(offset.y / (float) this.TileHeight)) * 2;
    int minX = this.BoundStartX + num1;
    if (minX < 0)
      minX = 0;
    int minY = this.BoundStartY + num2;
    if (minY < 0)
      minY = 0;
    int maxX = this.BoundStartX + (int) this.TileColNumSubtractOne + num1;
    if (maxX >= (int) this.TileMapInfoWidthMax)
      maxX = (int) this.TileMapInfoWidthMax - 1;
    int maxY = this.BoundStartY + (int) this.TileRowNumSubtractOne + num2;
    if (maxY >= (int) this.TileMapInfoHeightMax)
      maxY = (int) this.TileMapInfoHeightMax - 1;
    DataManager.MapDataController.RequestKingdomData(minX, minY, maxX, maxY);
    return true;
  }

  public void CheckCenterPos()
  {
    this.updateBaseCenter();
    int mapInfoIdbyStartId = this.getTileMapInfoIDbyStartID(this.BaseCenterID);
    if (this.centerMapID != mapInfoIdbyStartId)
    {
      this.centerMapID = mapInfoIdbyStartId;
      this.centerID.y = (float) (this.centerMapID / (int) this.TileMapInfoWidthMax);
      this.centerID.x = (float) (this.centerMapID % (int) this.TileMapInfoWidthMax * 2 + ((int) this.centerID.y & 1));
    }
    Vector2 zero = Vector2.zero;
    int index1 = this.TileColMapStartIDOffset + (int) this.BaseCenterID.y & (int) this.TileRowNumSubtractOne;
    int index2 = this.TileRowMapStartIDOffset + (int) this.BaseCenterID.x & (int) this.TileColNumSubtractOne;
    zero.y = this.TileRowGroupRectTransform[index1].anchoredPosition.y / (float) ((int) this.TileHeight >> 1);
    zero.x = this.TileObjectRectTransform[index2][index1].anchoredPosition.x / (float) this.TileHeight;
    DataManager.msgBuffer[0] = (byte) 114;
    GameConstants.GetBytes(this.centerID.x, DataManager.msgBuffer, 1);
    GameConstants.GetBytes(this.centerID.y, DataManager.msgBuffer, 5);
    GameConstants.GetBytes(zero.x, DataManager.msgBuffer, 9);
    GameConstants.GetBytes(zero.y, DataManager.msgBuffer, 13);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    zero.y = (double) this.BoundStartY + (double) this.BaseCenterID.y <= (double) ((int) this.TileMapInfoHeightMax - 1) ? (float) ((((double) this.homePos.y - (double) this.centerID.y) * (double) ((int) this.TileHeight >> 1) - (double) this.TileRowGroupRectTransform[index1].anchoredPosition.y) * (double) DataManager.MapDataController.worldZoomSize * 2.0) : (float) ((((double) this.homePos.y - (double) this.centerID.y - (double) this.TileMapInfoHeightMax) * (double) ((int) this.TileHeight >> 1) - (double) this.TileRowGroupRectTransform[index1].anchoredPosition.y) * (double) DataManager.MapDataController.worldZoomSize * 2.0);
    zero.x = (float) ((((double) this.centerID.x - (double) this.homePos.x) * (double) this.TileHeight - (double) this.TileObjectRectTransform[index2][index1].anchoredPosition.x) * (double) DataManager.MapDataController.worldZoomSize * 2.0);
    if (this.homeSide == (byte) 0)
    {
      if ((double) Math.Abs(zero.y) <= (double) this.TileMapRectTransform.sizeDelta.y && (double) Math.Abs(zero.x) <= (double) this.TileMapRectTransform.sizeDelta.x)
        return;
      this.homeSide = (byte) 1;
      DataManager.msgBuffer[0] = (byte) 111;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
    else
    {
      if ((double) Math.Abs(zero.y) >= (double) this.TileMapRectTransform.sizeDelta.y || (double) Math.Abs(zero.x) >= (double) this.TileMapRectTransform.sizeDelta.x)
        return;
      this.homeSide = (byte) 0;
      DataManager.msgBuffer[0] = (byte) 110;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
  }

  public void Check3DPos(float scale)
  {
    Vector2 vector2 = Vector2.zero;
    for (int index1 = 0; index1 < (int) this.TileRowNum; ++index1)
    {
      int row = this.TileColMapStartIDOffset + index1 & (int) this.TileRowNumSubtractOne;
      for (int index2 = 0; index2 < (int) this.TileColNum; ++index2)
      {
        int col = this.TileRowMapStartIDOffset + index2 & (int) this.TileColNumSubtractOne;
        vector2 = this.TileRowGroupRectTransform[row].anchoredPosition + this.TileObjectRectTransform[col][row].anchoredPosition;
        this.effect.setEffect(row, col, scale);
      }
    }
  }

  public bool updateHomePos()
  {
    KingdomMap recordByKey1 = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.OtherKingdomData.kingdomID);
    this.homePos.x = (float) ((int) recordByKey1.worldPosX - (int) DataManager.MapDataController.WorldMinX);
    this.homePos.y = (float) ((int) recordByKey1.worldPosY - (int) DataManager.MapDataController.WorldMinY);
    this.homePos.x *= 2f;
    this.homePos.x += (float) ((int) this.homePos.y & 1);
    if ((double) DataManager.MapDataController.FocusWorldMapPos.x == -1.0 && (double) DataManager.MapDataController.FocusWorldMapPos.y == -1.0)
    {
      if ((int) DataManager.MapDataController.gotokingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
      {
        KingdomMap recordByKey2 = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.gotokingdomID);
        DataManager.MapDataController.FocusWorldMapPos.x = (float) ((int) recordByKey2.worldPosX - (int) DataManager.MapDataController.WorldMinX);
        DataManager.MapDataController.FocusWorldMapPos.y = (float) ((int) recordByKey2.worldPosY - (int) DataManager.MapDataController.WorldMinY);
        DataManager.MapDataController.FocusWorldMapPos.x *= 2f;
        DataManager.MapDataController.FocusWorldMapPos.x += (float) ((int) DataManager.MapDataController.FocusWorldMapPos.y & 1);
      }
      else
        DataManager.MapDataController.FocusWorldMapPos = this.homePos;
      DataManager.MapDataController.gotokingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
      return true;
    }
    DataManager.MapDataController.gotokingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
    return false;
  }

  public void moveToKingdom(ushort KingdomID)
  {
    KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(KingdomID);
    Vector2 zero = Vector2.zero with
    {
      x = (float) ((int) recordByKey.worldPosX - (int) DataManager.MapDataController.WorldMinX),
      y = (float) ((int) recordByKey.worldPosY - (int) DataManager.MapDataController.WorldMinY)
    };
    zero.x *= 2f;
    zero.x += (float) ((int) zero.y & 1);
    this.MovebyTileMapPos((int) zero.x, (int) zero.y);
  }

  public void resetMap()
  {
    int num1 = 4;
    int num2 = (int) DataManager.MapDataController.WorldMaxX - (int) DataManager.MapDataController.WorldMinX;
    int num3;
    if (num2 < 16)
    {
      num1 = Mathf.CeilToInt((float) (16 - num2) * 0.5f);
      DataManager.MapDataController.WorldMaxX += (ushort) num1;
      DataManager.MapDataController.WorldMinX -= (ushort) num1;
      num3 = (int) DataManager.MapDataController.WorldMaxX - (int) DataManager.MapDataController.WorldMinX;
    }
    else
    {
      DataManager.MapDataController.WorldMaxX += (ushort) num1;
      DataManager.MapDataController.WorldMinX -= (ushort) num1;
      num3 = (int) DataManager.MapDataController.WorldMaxX - (int) DataManager.MapDataController.WorldMinX;
    }
    int num4 = (int) DataManager.MapDataController.WorldMaxY - (int) DataManager.MapDataController.WorldMinY;
    int num5;
    if (num4 < 16)
    {
      int num6 = Mathf.CeilToInt((float) (16 - num4) * 0.5f);
      DataManager.MapDataController.WorldMaxY += (ushort) num6;
      DataManager.MapDataController.WorldMinY -= (ushort) num6;
      num5 = (int) DataManager.MapDataController.WorldMaxY - (int) DataManager.MapDataController.WorldMinY;
    }
    else
    {
      DataManager.MapDataController.WorldMaxY += (ushort) num1;
      DataManager.MapDataController.WorldMinY -= (ushort) num1;
      num5 = (int) DataManager.MapDataController.WorldMaxY - (int) DataManager.MapDataController.WorldMinY;
    }
  }

  private bool LoadTileMapFile()
  {
    AssetBundle tableAb = DataManager.Instance.GetTableAB();
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.AppendFormat(nameof (WorldMap));
    TextAsset textAsset = tableAb.Load(cstring.ToString()) as TextAsset;
    if ((UnityEngine.Object) textAsset == (UnityEngine.Object) null)
      return false;
    if (this.BaseTileMapInfo != null)
      Array.Clear((Array) this.BaseTileMapInfo, 0, this.BaseTileMapInfo.Length);
    Stream input = (Stream) new MemoryStream(textAsset.bytes);
    using (BinaryReader binaryReader = new BinaryReader(input))
    {
      this.BaseTileMapInfo = binaryReader.ReadBytes((int) input.Length);
      binaryReader.Close();
    }
    input.Close();
    if (this.TileMapInfo == null)
      this.TileMapInfo = new byte[(int) this.TileMapInfoWidthMax * (int) this.TileMapInfoHeightMax];
    Array.Clear((Array) this.TileMapInfo, 0, this.TileMapInfo.Length);
    int num1 = (int) DataManager.MapDataController.WorldOX - (int) DataManager.MapDataController.WorldMinX;
    int num2 = (int) DataManager.MapDataController.WorldOY - (int) DataManager.MapDataController.WorldMinY;
    int num3 = num2;
    int num4 = 0;
    while (num3 < (int) this.TileMapInfoHeightMax)
    {
      int num5 = num4 % 16;
      int num6 = num1;
      int num7 = 0;
      while (num6 < (int) this.TileMapInfoWidthMax)
      {
        int num8 = num7 % 8;
        int index = num5 * 8 + num8;
        this.TileMapInfo[num3 * (int) this.TileMapInfoWidthMax + num6] = this.BaseTileMapInfo[index];
        ++num6;
        num7 = num8 + 1;
      }
      ++num3;
      num4 = num5 + 1;
    }
    int num9 = num2;
    int num10 = 0;
    while (num9 < (int) this.TileMapInfoHeightMax)
    {
      int num11 = num10 % 16;
      int num12 = num1 - 1;
      int num13 = -1;
      while (num12 > -1)
      {
        if (num13 < 0)
          num13 += 8;
        int num14 = num13 % 8;
        int index = num11 * 8 + num14;
        this.TileMapInfo[num9 * (int) this.TileMapInfoWidthMax + num12] = this.BaseTileMapInfo[index];
        --num12;
        num13 = num14 - 1;
      }
      ++num9;
      num10 = num11 + 1;
    }
    int num15 = num2 - 1;
    int num16 = -1;
    while (num15 > -1)
    {
      if (num16 < 0)
        num16 += 16;
      int num17 = num16 % 16;
      int num18 = num1;
      int num19 = 0;
      while (num18 < (int) this.TileMapInfoWidthMax)
      {
        int num20 = num19 % 8;
        int index = num17 * 8 + num20;
        this.TileMapInfo[num15 * (int) this.TileMapInfoWidthMax + num18] = this.BaseTileMapInfo[index];
        ++num18;
        num19 = num20 + 1;
      }
      --num15;
      num16 = num17 - 1;
    }
    int num21 = num2 - 1;
    int num22 = -1;
    while (num21 > -1)
    {
      if (num22 < 0)
        num22 += 16;
      int num23 = num22 % 16;
      int num24 = num1 - 1;
      int num25 = -1;
      while (num24 > -1)
      {
        if (num25 < 0)
          num25 += 8;
        int num26 = num25 % 8;
        int index = num23 * 8 + num26;
        this.TileMapInfo[num21 * (int) this.TileMapInfoWidthMax + num24] = this.BaseTileMapInfo[index];
        --num24;
        num25 = num26 - 1;
      }
      --num21;
      num22 = num23 - 1;
    }
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
    Vector2 vector2_1 = new Vector2((float) ((int) this.TileColNum * x1), (float) tileHeight);
    Vector2 vector2_2 = new Vector2((float) x1, (float) tileHeight);
    int num2 = 0;
    bool flag = false;
    if (this.updateHomePos())
    {
      int num3 = (int) (((double) DataManager.MapDataController.FocusWorldMapPos.x - (double) ((int) DataManager.MapDataController.FocusWorldMapPos.y & 1)) * 0.5);
      int y1 = (int) DataManager.MapDataController.FocusWorldMapPos.y;
      Xnum >>= 1;
      --Xnum;
      int num4 = num3 - Xnum;
      this.BoundStartX = num4;
      if (num4 < 0)
        num4 += (int) this.TileMapInfoWidthMax;
      int x2 = num4 % (int) this.TileMapInfoWidthMax;
      Ynum >>= 1;
      int num5 = y1 - Ynum;
      this.BoundStartY = num5;
      if (num5 < 0)
        num5 += (int) this.TileMapInfoHeightMax;
      int y2 = num5 % (int) this.TileMapInfoHeightMax;
      this.StartID = y2 * (int) this.TileMapInfoWidthMax + x2;
      Vector2 in_StartMapInfoID = new Vector2((float) x2, (float) y2);
      float num6 = (float) ((int) this.TileColNumSubtractOne * (num1 >> 1));
      float num7 = (float) ((int) -this.TileColNum * (int) tileHeight - num1 + (int) tileHeight);
      for (int y3 = 0; y3 < this.TileRowGroupRectTransform.Length; ++y3)
      {
        GameObject gameObject1 = new GameObject("TileRowGroup");
        RectTransform rectTransform1 = this.TileRowGroupRectTransform[y3] = gameObject1.AddComponent<RectTransform>();
        rectTransform1.sizeDelta = vector2_1;
        rectTransform1.anchoredPosition = Vector2.up * (num6 - (float) (y3 * num1));
        ((Transform) rectTransform1).SetParent((Transform) this.TileMapRectTransform, false);
        int num8 = this.BoundStartY + y3;
        flag = num8 < 0 || num8 > (int) this.TileMapInfoHeightMax - 1;
        for (int x3 = 0; x3 < (int) this.TileColNum; ++x3)
        {
          GameObject gameObject2 = new GameObject("TileObject");
          RectTransform rectTransform2 = this.TileObjectRectTransform[x3][y3] = gameObject2.AddComponent<RectTransform>();
          rectTransform2.sizeDelta = vector2_2;
          rectTransform2.anchoredPosition = Vector2.right * (num7 + (float) ((int) tileHeight * (y3 + y2 & 1)) + (float) (x3 * x1));
          ((Transform) rectTransform2).SetParent((Transform) this.TileRowGroupRectTransform[y3], false);
          GameObject gameObject3 = new GameObject("TileBase");
          Image image = this.TileBaseImage[x3][y3] = gameObject3.AddComponent<Image>();
          int tileMapInfoId = this.getTileMapInfoID(new Vector2((float) x3, (float) y3), in_StartMapInfoID);
          image.sprite = this.TileSprites.GetSprite((int) this.TileMapInfo[tileMapInfoId] + 2);
          ((MaskableGraphic) image).material = ((MaskableGraphic) this.TileSprites.m_Image).material;
          image.SetNativeSize();
          num2 = this.BoundStartX + x3;
          RectTransform rectTransform3 = this.TileBaseRectTransform[x3][y3] = gameObject3.transform as RectTransform;
          if ((double) this.TileBaseScale == 0.0)
            this.TileBaseScale = (float) x1 / rectTransform3.sizeDelta.x;
          ((Transform) rectTransform3).localScale = Vector3.one * this.TileBaseScale;
          rectTransform3.anchoredPosition = Vector2.up * (rectTransform3.sizeDelta.y * this.TileBaseScale - (float) this.TileHeight) * 0.5f;
          ((Transform) rectTransform3).SetParent((Transform) this.TileObjectRectTransform[x3][y3], false);
          this.OverTileBaseGameObject[x3][y3] = new GameObject("OverTileBase");
          RectTransform rectTransform4 = this.OverTileBaseGameObject[x3][y3].AddComponent<RectTransform>();
          rectTransform4.sizeDelta = vector2_2;
          rectTransform4.anchoredPosition = (Vector2) Vector3.zero;
          ((Transform) rectTransform4).SetParent((Transform) this.TileObjectRectTransform[x3][y3], false);
          GameObject gameObject4 = new GameObject("Ground");
          ((MaskableGraphic) (this.OverTileBaseImage[x3][y3] = gameObject4.AddComponent<Image>())).material = ((MaskableGraphic) this.TileSprites.m_Image).material;
          RectTransform rectTransform5 = this.OverTileBaseRectTransform[x3][y3] = gameObject4.transform as RectTransform;
          ((Transform) rectTransform5).localScale = Vector3.one * this.TileBaseScale;
          ((Transform) rectTransform5).SetParent(this.OverTileBaseGameObject[x3][y3].transform, false);
          this.OverTileBaseGameObject[x3][y3].SetActive(false);
        }
      }
      this.Movedelta.x = this.TileObjectRectTransform[Xnum][Ynum].anchoredPosition.x;
      this.Movedelta.y = this.TileRowGroupRectTransform[Ynum].anchoredPosition.y;
      this.Movedelta *= -DataManager.MapDataController.worldZoomSize;
      this.MoveTileBase();
      this.Movedelta = Vector2.zero;
    }
    else
    {
      this.StartID = DataManager.MapDataController.StartID;
      int x4 = this.StartID % (int) this.TileMapInfoWidthMax;
      int y4 = this.StartID / (int) this.TileMapInfoWidthMax;
      this.BoundStartX = (int) DataManager.MapDataController.FocusWorldMapPos.x;
      this.BoundStartY = (int) DataManager.MapDataController.FocusWorldMapPos.y;
      Vector2 in_StartMapInfoID = new Vector2((float) x4, (float) y4);
      float y5 = DataManager.MapDataController.coloneWorldMapPos.y;
      float x5 = DataManager.MapDataController.coloneWorldMapPos.x;
      float x6 = DataManager.MapDataController.coltwoWorldMapPos.x;
      for (int y6 = 0; y6 < this.TileRowGroupRectTransform.Length; ++y6)
      {
        GameObject gameObject5 = new GameObject("TileRowGroup");
        RectTransform rectTransform6 = this.TileRowGroupRectTransform[y6] = gameObject5.AddComponent<RectTransform>();
        rectTransform6.sizeDelta = vector2_1;
        rectTransform6.anchoredPosition = Vector2.up * (y5 - (float) (y6 * num1));
        ((Transform) rectTransform6).SetParent((Transform) this.TileMapRectTransform, false);
        int num9 = this.BoundStartY + y6;
        flag = num9 < 0 || num9 > (int) this.TileMapInfoHeightMax - 1;
        if ((y6 & 1) == 0)
        {
          for (int x7 = 0; x7 < (int) this.TileColNum; ++x7)
          {
            GameObject gameObject6 = new GameObject("TileObject");
            RectTransform rectTransform7 = this.TileObjectRectTransform[x7][y6] = gameObject6.AddComponent<RectTransform>();
            rectTransform7.sizeDelta = vector2_2;
            rectTransform7.anchoredPosition = Vector2.right * (x5 + (float) (x7 * x1));
            ((Transform) rectTransform7).SetParent((Transform) this.TileRowGroupRectTransform[y6], false);
            GameObject gameObject7 = new GameObject("TileBase");
            Image image = this.TileBaseImage[x7][y6] = gameObject7.AddComponent<Image>();
            int tileMapInfoId = this.getTileMapInfoID(new Vector2((float) x7, (float) y6), in_StartMapInfoID);
            image.sprite = this.TileSprites.GetSprite((int) this.TileMapInfo[tileMapInfoId] + 2);
            ((MaskableGraphic) image).material = ((MaskableGraphic) this.TileSprites.m_Image).material;
            image.SetNativeSize();
            num2 = this.BoundStartX + x7;
            RectTransform rectTransform8 = this.TileBaseRectTransform[x7][y6] = gameObject7.transform as RectTransform;
            if ((double) this.TileBaseScale == 0.0)
              this.TileBaseScale = (float) x1 / rectTransform8.sizeDelta.x;
            ((Transform) rectTransform8).localScale = Vector3.one * this.TileBaseScale;
            rectTransform8.anchoredPosition = Vector2.up * (rectTransform8.sizeDelta.y * this.TileBaseScale - (float) this.TileHeight) * 0.5f;
            ((Transform) rectTransform8).SetParent((Transform) this.TileObjectRectTransform[x7][y6], false);
            this.OverTileBaseGameObject[x7][y6] = new GameObject("OverTileBase");
            RectTransform rectTransform9 = this.OverTileBaseGameObject[x7][y6].AddComponent<RectTransform>();
            rectTransform9.sizeDelta = vector2_2;
            rectTransform9.anchoredPosition = (Vector2) Vector3.zero;
            ((Transform) rectTransform9).SetParent((Transform) this.TileObjectRectTransform[x7][y6], false);
            GameObject gameObject8 = new GameObject("Ground");
            ((MaskableGraphic) (this.OverTileBaseImage[x7][y6] = gameObject8.AddComponent<Image>())).material = ((MaskableGraphic) this.TileSprites.m_Image).material;
            RectTransform rectTransform10 = this.OverTileBaseRectTransform[x7][y6] = gameObject8.transform as RectTransform;
            ((Transform) rectTransform10).localScale = Vector3.one * this.TileBaseScale;
            ((Transform) rectTransform10).SetParent(this.OverTileBaseGameObject[x7][y6].transform, false);
            this.OverTileBaseGameObject[x7][y6].SetActive(false);
          }
        }
        else
        {
          for (int x8 = 0; x8 < (int) this.TileColNum; ++x8)
          {
            GameObject gameObject9 = new GameObject("TileObject");
            RectTransform rectTransform11 = this.TileObjectRectTransform[x8][y6] = gameObject9.AddComponent<RectTransform>();
            rectTransform11.sizeDelta = vector2_2;
            rectTransform11.anchoredPosition = Vector2.right * (x6 + (float) (x8 * x1));
            ((Transform) rectTransform11).SetParent((Transform) this.TileRowGroupRectTransform[y6], false);
            GameObject gameObject10 = new GameObject("TileBase");
            Image image = this.TileBaseImage[x8][y6] = gameObject10.AddComponent<Image>();
            int tileMapInfoId = this.getTileMapInfoID(new Vector2((float) x8, (float) y6), in_StartMapInfoID);
            image.sprite = this.TileSprites.GetSprite((int) this.TileMapInfo[tileMapInfoId] + 2);
            ((MaskableGraphic) image).material = ((MaskableGraphic) this.TileSprites.m_Image).material;
            image.SetNativeSize();
            num2 = this.BoundStartX + x8;
            RectTransform rectTransform12 = this.TileBaseRectTransform[x8][y6] = gameObject10.transform as RectTransform;
            if ((double) this.TileBaseScale == 0.0)
              this.TileBaseScale = (float) x1 / rectTransform12.sizeDelta.x;
            ((Transform) rectTransform12).localScale = Vector3.one * this.TileBaseScale;
            rectTransform12.anchoredPosition = Vector2.up * (rectTransform12.sizeDelta.y * this.TileBaseScale - (float) this.TileHeight) * 0.5f;
            ((Transform) rectTransform12).SetParent((Transform) this.TileObjectRectTransform[x8][y6], false);
            this.OverTileBaseGameObject[x8][y6] = new GameObject("OverTileBase");
            RectTransform rectTransform13 = this.OverTileBaseGameObject[x8][y6].AddComponent<RectTransform>();
            rectTransform13.sizeDelta = vector2_2;
            rectTransform13.anchoredPosition = (Vector2) Vector3.zero;
            ((Transform) rectTransform13).SetParent((Transform) this.TileObjectRectTransform[x8][y6], false);
            GameObject gameObject11 = new GameObject("Ground");
            ((MaskableGraphic) (this.OverTileBaseImage[x8][y6] = gameObject11.AddComponent<Image>())).material = ((MaskableGraphic) this.TileSprites.m_Image).material;
            RectTransform rectTransform14 = this.OverTileBaseRectTransform[x8][y6] = gameObject11.transform as RectTransform;
            ((Transform) rectTransform14).localScale = Vector3.one * this.TileBaseScale;
            ((Transform) rectTransform14).SetParent(this.OverTileBaseGameObject[x8][y6].transform, false);
            this.OverTileBaseGameObject[x8][y6].SetActive(false);
          }
        }
      }
    }
  }

  private void CheckLimit(int in_Startpointx, int in_Startpointy, ref Vector2 inout_movedelta)
  {
    if ((double) inout_movedelta.y < 0.0)
    {
      if (this.BoundStartY < 0)
      {
        float num1 = this.TileMapRectTransform.sizeDelta.y / DataManager.MapDataController.worldZoomSize;
        float num2 = num1 * 0.5f;
        float num3 = this.TileRowGroupRectTransform[this.TileColMapStartIDOffset - 1 & (int) this.TileRowNumSubtractOne].anchoredPosition.y + (float) ((in_Startpointy + (int) this.TileRowNumSubtractOne) % (int) this.TileMapInfoHeightMax * ((int) this.TileHeight >> 1)) + num2;
        if ((double) num3 < 0.0)
          num3 += (float) (((int) this.TileHeight >> 1) * (int) this.TileMapInfoHeightMax) + num1;
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
      float num5 = this.TileMapRectTransform.sizeDelta.y / DataManager.MapDataController.worldZoomSize;
      float num6 = num5 * 0.5f;
      float num7 = this.TileRowGroupRectTransform[this.TileColMapStartIDOffset].anchoredPosition.y - (float) (((int) this.TileMapInfoHeightMax - in_Startpointy - 1) * ((int) this.TileHeight >> 1)) - num6;
      if ((double) num7 > 0.0)
        num7 -= (float) (((int) this.TileHeight >> 1) * (int) this.TileMapInfoHeightMax) + num5;
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
      float num9 = this.TileMapRectTransform.sizeDelta.x / DataManager.MapDataController.worldZoomSize;
      float num10 = num9 * 0.5f;
      float num11 = this.TileObjectRectTransform[this.TileRowMapStartIDOffset][0].anchoredPosition.x + (float) (((int) this.TileMapInfoWidthMax - in_Startpointx - 1) * ((int) this.TileHeight << 1)) + num10;
      if ((double) num11 < 0.0)
        num11 += (float) (((int) this.TileHeight << 1) * (int) this.TileMapInfoWidthMax) + num9;
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
      float num13 = this.TileMapRectTransform.sizeDelta.x / DataManager.MapDataController.worldZoomSize;
      float num14 = num13 * 0.5f;
      float num15 = this.TileObjectRectTransform[this.TileRowMapStartIDOffset - 1 & (int) this.TileColNumSubtractOne][0].anchoredPosition.x - (float) ((in_Startpointx + (int) this.TileColNumSubtractOne) % (int) this.TileMapInfoWidthMax * ((int) this.TileHeight << 1)) - num14;
      if ((double) num15 > 0.0)
        num15 -= (float) (((int) this.TileHeight << 1) * (int) this.TileMapInfoWidthMax) + num13;
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
      bool flag1 = num1 < 0 || num1 > (int) this.TileMapInfoHeightMax - 1;
      int row = this.TileColMapStartIDOffset + index1 & (int) this.TileRowNumSubtractOne;
      for (int index2 = colstart; index2 < colend; ++index2)
      {
        int col = this.TileRowMapStartIDOffset + index2 & (int) this.TileColNumSubtractOne;
        Image image = this.TileBaseImage[col][row];
        zero.x = (float) index2;
        zero.y = (float) index1;
        int tileMapInfoId = this.getTileMapInfoID(zero, in_StartMapInfoID);
        int num2 = this.BoundStartX + index2;
        bool flag2 = flag1 || num2 < 0 || num2 > (int) this.TileMapInfoWidthMax - 1;
        image.sprite = this.TileSprites.GetSprite((int) this.TileMapInfo[tileMapInfoId] + 2);
        image.SetNativeSize();
        RectTransform rectTransform = this.TileBaseRectTransform[col][row];
        rectTransform.anchoredPosition = Vector2.up * (rectTransform.sizeDelta.y * this.TileBaseScale - (float) this.TileHeight) * 0.5f;
        this.OverTileBaseGameObject[col][row].SetActive(false);
        ((Graphic) image).color = Color.white;
        if (this.kingdomName != null)
        {
          ushort kingdomId = DataManager.MapDataController.TileMapKingdomID[tileMapInfoId].KingdomID;
          if (kingdomId == (ushort) 0 || flag2)
          {
            this.kingdomName.setName((byte) 32, row, col, Color.white, pos);
            this.kingdomYolk.setYolkImage(-1, row, col, pos);
            this.kingdomGraphic.setGraphicImage(0, row, col, pos, kingdomID: kingdomId, title: (byte) 0);
            this.effect.setEffect((byte) 0, row, col, Vector2.zero, (byte) 0);
          }
          else
          {
            pos = this.TileRowGroupRectTransform[row].anchoredPosition + this.TileObjectRectTransform[col][row].anchoredPosition;
            byte tableId = DataManager.MapDataController.TileMapKingdomID[tileMapInfoId].tableID;
            if (tableId < (byte) 32 && (int) kingdomId == (int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomID)
            {
              this.kingdomYolk.setYolkImage((int) kingdomId, row, col, pos);
              this.kingdomName.setName(tableId, row, col, Color.white, pos);
            }
            else
            {
              this.kingdomName.setName((byte) 32, row, col, Color.white, pos);
              this.kingdomYolk.setYolkImage(-1, row, col, pos);
            }
            int num3 = 0;
            byte title = (byte) ((uint) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomFlag >> 3);
            if (title > (byte) 0)
              num3 = 8;
            else if (DataManager.Instance.RoleAttr.WorldTitle_Personal == (ushort) 1 && TitleManager.Instance.CheckGivetNTile() && DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomPeriod < KINGDOM_PERIOD.KP_WORLD_WAR)
              num3 = 4;
            if ((int) kingdomId == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
            {
              switch (ActivityManager.Instance.getKvKKingdomType(kingdomId))
              {
                case EKvKKingdomType.EKKT_Target:
                  num3 += 16;
                  break;
                case EKvKKingdomType.EKKT_Hunter:
                  num3 += 32;
                  break;
              }
              KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(kingdomId);
              this.kingdomGraphic.setGraphicImage(1 + num3, row, col, pos, (int) recordByKey.mapID, kingdomId, title);
            }
            else if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && (int) kingdomId == (int) DataManager.MapDataController.kingdomData.kingdomID || DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && this.CheckShowTransmission(kingdomId) && tableId < (byte) 32 && DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomPeriod == KINGDOM_PERIOD.KP_KVK)
            {
              switch (ActivityManager.Instance.getKvKKingdomType(kingdomId))
              {
                case EKvKKingdomType.EKKT_Target:
                  num3 += 16;
                  break;
                case EKvKKingdomType.EKKT_Hunter:
                  num3 += 32;
                  break;
              }
              this.kingdomGraphic.setGraphicImage(2 + num3, row, col, pos, kingdomID: kingdomId, title: title);
            }
            else
              this.kingdomGraphic.setGraphicImage(0 + num3, row, col, pos, kingdomID: kingdomId, title: title);
            if (DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR && ((int) DataManager.MapDataController.WorldKingdomTable[(int) tableId].kingdomFlag & 2) != 0)
              this.effect.setEffect((byte) 1, row, col, pos, (byte) 0);
            else
              this.effect.setEffect((byte) 0, row, col, pos, (byte) 0);
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
    return this.getTileMapInfoID(in_TileBaseID, new Vector2((float) (this.StartID % (int) this.TileMapInfoWidthMax), (float) (this.StartID / (int) this.TileMapInfoWidthMax)));
  }

  private Vector2 getTileMapSpritePosbyStartID(Vector2 in_TileBaseID)
  {
    int num = this.StartID % (int) this.TileMapInfoWidthMax;
    int y = (this.StartID / (int) this.TileMapInfoWidthMax + (int) in_TileBaseID.y) % (int) this.TileMapInfoHeightMax;
    return new Vector2((float) ((num + (int) in_TileBaseID.x) % (int) this.TileMapInfoWidthMax), (float) y);
  }

  private Vector2 getTileMapSpritePosbyBoundID(Vector2 in_TileBaseID)
  {
    int boundStartX = this.BoundStartX;
    int y = this.BoundStartY + (int) in_TileBaseID.y;
    if (y < 0)
      y = 0;
    else if (y > (int) this.TileMapInfoHeightMax - 1)
      y = (int) this.TileMapInfoHeightMax - 1;
    int x = boundStartX + (int) in_TileBaseID.x;
    if (x < 0)
      x = 0;
    else if (x > (int) this.TileMapInfoWidthMax - 1)
      x = (int) this.TileMapInfoWidthMax - 1;
    return new Vector2((float) x, (float) y);
  }

  private int getTileMapInfoID(Vector2 in_TileBaseID, Vector2 in_StartMapInfoID)
  {
    int x = (int) in_StartMapInfoID.x;
    return ((int) in_StartMapInfoID.y + (int) in_TileBaseID.y) % (int) this.TileMapInfoHeightMax * (int) this.TileMapInfoWidthMax + (x + (int) in_TileBaseID.x) % (int) this.TileMapInfoWidthMax;
  }

  private void MoveTileBase()
  {
    if (this.Movedelta == Vector2.zero)
      return;
    int in_Startpointx = this.StartID % (int) this.TileMapInfoWidthMax;
    int in_Startpointy = this.StartID / (int) this.TileMapInfoWidthMax;
    Vector2 inout_movedelta = this.Movedelta / DataManager.MapDataController.worldZoomSize;
    this.CheckLimit(in_Startpointx, in_Startpointy, ref inout_movedelta);
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
      this.inputState = Input.touchCount != 1 ? WorldMap.InPutState.None : WorldMap.InPutState.Drag;
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
      DataManager.MapDataController.worldZoomSize = num3 = Mathf.Clamp(num2, 0.75f, 1.75f);
      parent.localScale = Vector3.one * num3;
      this.RealmGroup_3DTransform.localScale = Vector3.one * num3;
      this.CheckCenterPos();
      this.updateGoHomeButtonPos();
      this.Check3DPos(parent.localScale.x);
    }
  }

  private Vector2 screenToMap(Vector2 screenPos)
  {
    screenPos.x -= (float) Screen.width * 0.5f;
    screenPos.y -= (float) Screen.height * 0.5f;
    screenPos *= this.TileMapRectTransform.sizeDelta.y / ((float) Screen.height * DataManager.MapDataController.worldZoomSize);
    return screenPos;
  }

  private void updateBaseCenter()
  {
    this.BaseCenterID = this.PosToTileBaseID(new Vector2((float) Screen.width * 0.5f, (float) Screen.height * 0.5f));
  }

  private enum InPutState : byte
  {
    None,
    Click,
    Drag,
    Zoom,
    KingdomUp,
    KingdomDown,
    Count,
  }
}
