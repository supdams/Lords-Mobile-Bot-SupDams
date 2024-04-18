// Decompiled with JetBrains decompiler
// Type: MapTileYolk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class MapTileYolk
{
  public GameObject[] TileYolkGameObject = new GameObject[40];
  public GameObject[] tempTileYolkGameObject;
  private Vector2[] YOLK_POS = new Vector2[40];
  private uint[][] YOLK_MAPID = new uint[40][];
  private Transform realmGroup;
  private RectTransform[] TileYolkRectTransform = new RectTransform[40];
  private Image[] TileYolkImage = new Image[40];
  private int[] TileYolkABKey = new int[40];
  private byte[] tickcolorlittleYolkID = new byte[40];
  private byte tickcolorlittleYolkIDCount;
  private Color sheeplittleYolkTickColor = (Color) new Color32(byte.MaxValue, (byte) 109, (byte) 109, byte.MaxValue);
  private Color wolflittleYolkTickColor = (Color) new Color32((byte) 235, (byte) 103, byte.MaxValue, byte.MaxValue);
  private byte tickcolorbigYolkID = 40;
  private Color sheepbigYolkTickColor = (Color) new Color32(byte.MaxValue, (byte) 109, (byte) 109, byte.MaxValue);
  private Color wolfbigYolkTickColor = (Color) new Color32((byte) 216, (byte) 99, byte.MaxValue, byte.MaxValue);
  private EKvKKingdomType nowKvKKingdomType = EKvKKingdomType.EKKT_Normal;
  private float tickYolkImageColorSpeed;
  private float left = -2800f;
  private float right = 2800f;
  private float up = 1200f;
  private float down = -1200f;
  private float offset = 170f;
  private float LittleYolkoffset = 170f;
  private float w = 6f;
  private float h = 6f;
  private float forward = 3584f;
  private int[] tempTileYolkABKey;

  public MapTileYolk(Transform RealmGroup)
  {
    this.realmGroup = RealmGroup;
    ushort num = DataManager.MapDataController.FocusKingdomID != (ushort) 0 ? DataManager.MapDataController.FocusKingdomID : (ushort) 1;
    CString cstring = StringManager.Instance.SpawnString();
    cstring.ClearString();
    ushort WonderID1 = 0;
    KingdomMap recordByKey1 = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(num);
    if (ActivityManager.Instance.IsInKvK((ushort) 0) && (int) num != (int) ActivityManager.Instance.KOWKingdomID && DataManager.MapDataController.IsEnemy(num))
      cstring.IntToFormat(0L, 3);
    else
      cstring.IntToFormat(recordByKey1.mapID != (byte) 0 ? (long) recordByKey1.mapID : 1L, 3);
    cstring.AppendFormat("UI/Yolk_{0}");
    AssetBundle assetBundle1 = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int) WonderID1]);
    if ((UnityEngine.Object) assetBundle1 == (UnityEngine.Object) null)
    {
      cstring.ClearString();
      cstring.IntToFormat(1L);
      cstring.AppendFormat("UI/Yolk_{0}");
      assetBundle1 = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int) WonderID1]);
    }
    this.TileYolkGameObject[(int) WonderID1] = UnityEngine.Object.Instantiate(assetBundle1.mainAsset) as GameObject;
    this.TileYolkGameObject[(int) WonderID1].SetActive(false);
    this.TileYolkRectTransform[(int) WonderID1] = this.TileYolkGameObject[(int) WonderID1].transform as RectTransform;
    this.TileYolkImage[(int) WonderID1] = this.TileYolkGameObject[(int) WonderID1].GetComponent<Image>();
    ((MaskableGraphic) this.TileYolkImage[(int) WonderID1]).material.renderQueue = 2550;
    this.TileYolkImage[(int) WonderID1].SetNativeSize();
    ((Transform) this.TileYolkRectTransform[(int) WonderID1]).localPosition = Vector3.forward * this.forward;
    ((Transform) this.TileYolkRectTransform[(int) WonderID1]).SetParent(this.realmGroup, false);
    this.YOLK_POS[(int) WonderID1] = DataManager.MapDataController.GetYolkPos(WonderID1, num);
    ++this.YOLK_POS[(int) WonderID1].y;
    this.YOLK_MAPID[(int) WonderID1] = new uint[9];
    this.YOLK_MAPID[(int) WonderID1][0] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x, (int) this.YOLK_POS[(int) WonderID1].y);
    this.YOLK_MAPID[(int) WonderID1][1] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x + 1, (int) this.YOLK_POS[(int) WonderID1].y - 1);
    this.YOLK_MAPID[(int) WonderID1][2] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x - 1, (int) this.YOLK_POS[(int) WonderID1].y - 1);
    this.YOLK_MAPID[(int) WonderID1][3] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x + 2, (int) this.YOLK_POS[(int) WonderID1].y - 2);
    this.YOLK_MAPID[(int) WonderID1][4] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x, (int) this.YOLK_POS[(int) WonderID1].y - 2);
    this.YOLK_MAPID[(int) WonderID1][5] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x - 2, (int) this.YOLK_POS[(int) WonderID1].y - 2);
    this.YOLK_MAPID[(int) WonderID1][6] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x + 1, (int) this.YOLK_POS[(int) WonderID1].y - 3);
    this.YOLK_MAPID[(int) WonderID1][7] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x - 1, (int) this.YOLK_POS[(int) WonderID1].y - 3);
    this.YOLK_MAPID[(int) WonderID1][8] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x, (int) this.YOLK_POS[(int) WonderID1].y - 4);
    for (ushort WonderID2 = 1; WonderID2 < (ushort) 40; ++WonderID2)
    {
      if (DataManager.MapDataController.CheckYolk(WonderID2, num))
      {
        cstring.ClearString();
        if (ActivityManager.Instance.IsInKvK((ushort) 0) && (int) num != (int) ActivityManager.Instance.KOWKingdomID && DataManager.MapDataController.IsEnemy(num))
        {
          cstring.Append("UI/EnemyLittleYolk");
          AssetBundle assetBundle2 = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int) WonderID2]);
          this.TileYolkGameObject[(int) WonderID2] = UnityEngine.Object.Instantiate(assetBundle2.mainAsset) as GameObject;
          this.TileYolkGameObject[(int) WonderID2].SetActive(false);
          this.TileYolkRectTransform[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2].transform as RectTransform;
          this.TileYolkImage[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2].GetComponent<Image>();
          ((MaskableGraphic) this.TileYolkImage[(int) WonderID2]).material.renderQueue = 2550;
          this.TileYolkImage[(int) WonderID2].SetNativeSize();
          ((Transform) this.TileYolkRectTransform[(int) WonderID2]).localPosition = Vector3.forward * this.forward;
          ((Transform) this.TileYolkRectTransform[(int) WonderID2]).SetParent(this.realmGroup, false);
        }
        else
        {
          KingdomYolkDeploy recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(0);
          int Index;
          for (Index = 1; Index < DataManager.MapDataController.KingdomYolkDeployTable.TableCount; ++Index)
          {
            recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(Index);
            if ((int) recordByIndex.kingdomID == (int) num)
              break;
          }
          if (Index >= DataManager.MapDataController.KingdomYolkDeployTable.TableCount)
          {
            cstring.Append("UI/LittleYolk");
            AssetBundle assetBundle3 = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int) WonderID2]);
            this.TileYolkGameObject[(int) WonderID2] = UnityEngine.Object.Instantiate(assetBundle3.mainAsset) as GameObject;
            this.TileYolkGameObject[(int) WonderID2].SetActive(false);
            this.TileYolkRectTransform[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2].transform as RectTransform;
            this.TileYolkImage[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2].GetComponent<Image>();
            ((MaskableGraphic) this.TileYolkImage[(int) WonderID2]).material.renderQueue = 2550;
            this.TileYolkImage[(int) WonderID2].SetNativeSize();
            ((Transform) this.TileYolkRectTransform[(int) WonderID2]).localPosition = Vector3.forward * this.forward;
            ((Transform) this.TileYolkRectTransform[(int) WonderID2]).SetParent(this.realmGroup, false);
          }
          else
          {
            YolkDeploy recordByKey2 = DataManager.MapDataController.YolkDeployTable.GetRecordByKey(recordByIndex.yolkDeployIDs[(int) WonderID2]);
            cstring.ClearString();
            cstring.IntToFormat((long) recordByKey2.iconID, 3);
            cstring.AppendFormat("UI/LittleYolk_{0}");
            AssetBundle assetBundle4 = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int) WonderID2]);
            this.TileYolkGameObject[(int) WonderID2] = UnityEngine.Object.Instantiate(assetBundle4.mainAsset) as GameObject;
            this.TileYolkGameObject[(int) WonderID2].SetActive(false);
            this.TileYolkRectTransform[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2].transform as RectTransform;
            this.TileYolkImage[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2].GetComponent<Image>();
            ((MaskableGraphic) this.TileYolkImage[(int) WonderID2]).material.renderQueue = 2550;
            this.TileYolkImage[(int) WonderID2].SetNativeSize();
            ((Transform) this.TileYolkRectTransform[(int) WonderID2]).localPosition = Vector3.forward * this.forward;
            ((Transform) this.TileYolkRectTransform[(int) WonderID2]).SetParent(this.realmGroup, false);
          }
        }
      }
      else
      {
        this.TileYolkGameObject[(int) WonderID2] = (GameObject) null;
        this.TileYolkRectTransform[(int) WonderID2] = (RectTransform) null;
        this.TileYolkImage[(int) WonderID2] = (Image) null;
        this.TileYolkABKey[(int) WonderID2] = 0;
      }
      this.YOLK_POS[(int) WonderID2] = DataManager.MapDataController.GetYolkPos(WonderID2, num);
      ++this.YOLK_POS[(int) WonderID2].y;
      this.YOLK_MAPID[(int) WonderID2] = new uint[9];
      this.YOLK_MAPID[(int) WonderID2][0] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x, (int) this.YOLK_POS[(int) WonderID2].y);
      this.YOLK_MAPID[(int) WonderID2][1] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x + 1, (int) this.YOLK_POS[(int) WonderID2].y - 1);
      this.YOLK_MAPID[(int) WonderID2][2] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x - 1, (int) this.YOLK_POS[(int) WonderID2].y - 1);
      this.YOLK_MAPID[(int) WonderID2][3] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x + 2, (int) this.YOLK_POS[(int) WonderID2].y - 2);
      this.YOLK_MAPID[(int) WonderID2][4] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x, (int) this.YOLK_POS[(int) WonderID2].y - 2);
      this.YOLK_MAPID[(int) WonderID2][5] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x - 2, (int) this.YOLK_POS[(int) WonderID2].y - 2);
      this.YOLK_MAPID[(int) WonderID2][6] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x + 1, (int) this.YOLK_POS[(int) WonderID2].y - 3);
      this.YOLK_MAPID[(int) WonderID2][7] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x - 1, (int) this.YOLK_POS[(int) WonderID2].y - 3);
      this.YOLK_MAPID[(int) WonderID2][8] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x, (int) this.YOLK_POS[(int) WonderID2].y - 4);
    }
    StringManager.Instance.DeSpawnString(cstring);
  }

  public void IniMapTileYolk(float tileBaseScale, byte tileHeight)
  {
    Bounds bounds1 = this.TileYolkImage[0].sprite.bounds;
    this.TileYolkRectTransform[0].pivot = Vector2.one * 0.5f + Vector2.right * (float) (-(double) bounds1.center.x / (double) bounds1.extents.x / 2.0);
    this.offset = (float) (((double) this.TileYolkRectTransform[0].sizeDelta.y - (double) tileHeight) * 0.5);
    for (ushort index = 1; (int) index < this.TileYolkImage.Length; ++index)
    {
      if ((UnityEngine.Object) this.TileYolkImage[(int) index] != (UnityEngine.Object) null)
      {
        Bounds bounds2 = this.TileYolkImage[(int) index].sprite.bounds;
        this.TileYolkRectTransform[(int) index].pivot = Vector2.one * 0.5f + Vector2.right * (float) (-(double) bounds2.center.x / (double) bounds2.extents.x / 2.0);
        this.LittleYolkoffset = (float) (((double) this.TileYolkRectTransform[(int) index].sizeDelta.y - (double) tileHeight) * 0.5);
        break;
      }
    }
    this.nowKvKKingdomType = ActivityManager.Instance.getKvKKingdomType(DataManager.MapDataController.FocusKingdomID != (ushort) 0 ? DataManager.MapDataController.FocusKingdomID : (ushort) 1);
  }

  public void OnDestroy()
  {
    this.realmGroup = (Transform) null;
    if (this.TileYolkGameObject != null)
    {
      for (int index = 0; index < this.TileYolkGameObject.Length; ++index)
      {
        this.TileYolkImage[index] = (Image) null;
        this.TileYolkRectTransform[index] = (RectTransform) null;
        if (this.TileYolkABKey[index] != 0)
        {
          AssetManager.UnloadAssetBundle(this.TileYolkABKey[index]);
          this.TileYolkABKey[index] = 0;
        }
        if ((UnityEngine.Object) this.TileYolkGameObject[index] != (UnityEngine.Object) null)
        {
          UnityEngine.Object.Destroy((UnityEngine.Object) this.TileYolkGameObject[index]);
          this.TileYolkGameObject[index] = (GameObject) null;
        }
      }
      this.TileYolkImage = (Image[]) null;
      this.TileYolkRectTransform = (RectTransform[]) null;
      this.TileYolkABKey = (int[]) null;
      this.TileYolkGameObject = (GameObject[]) null;
    }
    if (this.tempTileYolkGameObject == null)
      return;
    for (int index = 0; index < this.tempTileYolkGameObject.Length; ++index)
    {
      if (this.tempTileYolkABKey[index] != 0)
      {
        AssetManager.UnloadAssetBundle(this.tempTileYolkABKey[index]);
        this.tempTileYolkABKey[index] = 0;
      }
      if ((UnityEngine.Object) this.tempTileYolkGameObject[index] != (UnityEngine.Object) null)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.tempTileYolkGameObject[index]);
        this.tempTileYolkGameObject[index] = (GameObject) null;
      }
    }
    this.tempTileYolkABKey = (int[]) null;
    this.tempTileYolkGameObject = (GameObject[]) null;
  }

  public void MoveYolk(Vector2 moveDelta)
  {
    // ISSUE: unable to decompile the method.
  }

  public int setYolk(int mapID, Vector2 pos)
  {
    ushort num1 = DataManager.MapDataController.FocusKingdomID != (ushort) 0 ? DataManager.MapDataController.FocusKingdomID : (ushort) 1;
    int WonderID = -1;
    Vector2 tileMapPosbyMapId = GameConstants.getTileMapPosbyMapID(mapID);
    Vector2 vector2_1 = Vector2.zero;
    for (int index1 = 0; index1 < (int) DataManager.MapDataController.showYolkNum; ++index1)
    {
      WonderID = (int) DataManager.MapDataController.showYolkMapYolkID[index1];
      vector2_1 = this.YOLK_POS[WonderID] - tileMapPosbyMapId;
      if ((double) Mathf.Abs(vector2_1.x) <= (double) this.w && (double) Mathf.Abs(vector2_1.y) <= (double) this.h)
      {
        if (DataManager.MapDataController.LayoutMapInfo[(IntPtr) DataManager.MapDataController.GetYolkMapID((ushort) WonderID, num1)].pointKind != (byte) 11)
        {
          if ((UnityEngine.Object) this.TileYolkGameObject[WonderID] != (UnityEngine.Object) null && this.TileYolkGameObject[WonderID].activeSelf)
          {
            this.TileYolkGameObject[WonderID].SetActive(false);
            if (WonderID == 0)
            {
              this.tickcolorbigYolkID = (byte) 40;
              ((Graphic) this.TileYolkImage[WonderID]).color = Color.white;
            }
            else if (this.tickcolorlittleYolkIDCount > (byte) 0)
            {
              for (int index2 = 0; index2 < (int) this.tickcolorlittleYolkIDCount; ++index2)
              {
                if ((int) this.tickcolorlittleYolkID[index2] == WonderID)
                {
                  --this.tickcolorlittleYolkIDCount;
                  this.tickcolorlittleYolkID[index2] = this.tickcolorlittleYolkID[(int) this.tickcolorlittleYolkIDCount];
                  this.tickcolorlittleYolkID[(int) this.tickcolorlittleYolkIDCount] = (byte) 0;
                  ((Graphic) this.TileYolkImage[WonderID]).color = Color.white;
                  break;
                }
              }
            }
            ushort num2 = (ushort) WonderID;
            DataManager.msgBuffer[0] = (byte) 95;
            GameConstants.GetBytes(num2, DataManager.msgBuffer, 1);
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          }
          return -1;
        }
        break;
      }
    }
    if ((UnityEngine.Object) this.TileYolkGameObject[WonderID] == (UnityEngine.Object) null)
    {
      CString cstring = StringManager.Instance.SpawnString();
      cstring.ClearString();
      if (WonderID == 0)
      {
        KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(num1);
        if (ActivityManager.Instance.IsInKvK((ushort) 0) && (int) num1 != (int) ActivityManager.Instance.KOWKingdomID && DataManager.MapDataController.IsEnemy(num1))
        {
          this.nowKvKKingdomType = ActivityManager.Instance.getKvKKingdomType(num1);
          cstring.IntToFormat(0L, 3);
        }
        else
        {
          this.nowKvKKingdomType = EKvKKingdomType.EKKT_Normal;
          cstring.IntToFormat(recordByKey.mapID != (byte) 0 ? (long) recordByKey.mapID : 1L, 3);
        }
        cstring.AppendFormat("UI/Yolk_{0}");
        AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[WonderID]);
        if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
        {
          cstring.ClearString();
          cstring.IntToFormat(1L);
          cstring.AppendFormat("UI/Yolk_{0}");
          assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[WonderID]);
        }
        this.TileYolkGameObject[WonderID] = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
        this.TileYolkGameObject[WonderID].SetActive(false);
        this.TileYolkRectTransform[WonderID] = this.TileYolkGameObject[WonderID].transform as RectTransform;
        this.TileYolkImage[WonderID] = this.TileYolkGameObject[WonderID].GetComponent<Image>();
        ((MaskableGraphic) this.TileYolkImage[WonderID]).material.renderQueue = 2550;
        this.TileYolkImage[WonderID].SetNativeSize();
        ((Transform) this.TileYolkRectTransform[WonderID]).localPosition = Vector3.forward * this.forward;
        ((Transform) this.TileYolkRectTransform[WonderID]).SetParent(this.realmGroup, false);
      }
      else if (ActivityManager.Instance.IsInKvK((ushort) 0) && (int) num1 != (int) ActivityManager.Instance.KOWKingdomID && DataManager.MapDataController.IsEnemy(num1))
      {
        this.nowKvKKingdomType = ActivityManager.Instance.getKvKKingdomType(num1);
        cstring.Append("UI/EnemyLittleYolk");
        AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[WonderID]);
        this.TileYolkGameObject[WonderID] = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
        this.TileYolkGameObject[WonderID].SetActive(false);
        this.TileYolkRectTransform[WonderID] = this.TileYolkGameObject[WonderID].transform as RectTransform;
        this.TileYolkImage[WonderID] = this.TileYolkGameObject[WonderID].GetComponent<Image>();
        ((MaskableGraphic) this.TileYolkImage[WonderID]).material.renderQueue = 2550;
        this.TileYolkImage[WonderID].SetNativeSize();
        ((Transform) this.TileYolkRectTransform[WonderID]).localPosition = Vector3.forward * this.forward;
        ((Transform) this.TileYolkRectTransform[WonderID]).SetParent(this.realmGroup, false);
      }
      else
      {
        this.nowKvKKingdomType = EKvKKingdomType.EKKT_Normal;
        KingdomYolkDeploy recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(0);
        int Index;
        for (Index = 1; Index < DataManager.MapDataController.KingdomYolkDeployTable.TableCount; ++Index)
        {
          recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(Index);
          if ((int) recordByIndex.kingdomID == (int) num1)
            break;
        }
        if (Index >= DataManager.MapDataController.KingdomYolkDeployTable.TableCount)
        {
          cstring.Append("UI/LittleYolk");
          AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[WonderID]);
          this.TileYolkGameObject[WonderID] = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
          this.TileYolkGameObject[WonderID].SetActive(false);
          this.TileYolkRectTransform[WonderID] = this.TileYolkGameObject[WonderID].transform as RectTransform;
          this.TileYolkImage[WonderID] = this.TileYolkGameObject[WonderID].GetComponent<Image>();
          ((MaskableGraphic) this.TileYolkImage[WonderID]).material.renderQueue = 2550;
          this.TileYolkImage[WonderID].SetNativeSize();
          ((Transform) this.TileYolkRectTransform[WonderID]).localPosition = Vector3.forward * this.forward;
          ((Transform) this.TileYolkRectTransform[WonderID]).SetParent(this.realmGroup, false);
        }
        else
        {
          YolkDeploy recordByKey = DataManager.MapDataController.YolkDeployTable.GetRecordByKey(recordByIndex.yolkDeployIDs[WonderID]);
          cstring.ClearString();
          cstring.IntToFormat((long) recordByKey.iconID, 3);
          cstring.AppendFormat("UI/LittleYolk_{0}");
          AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[WonderID]);
          this.TileYolkGameObject[WonderID] = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
          this.TileYolkGameObject[WonderID].SetActive(false);
          this.TileYolkRectTransform[WonderID] = this.TileYolkGameObject[WonderID].transform as RectTransform;
          this.TileYolkImage[WonderID] = this.TileYolkGameObject[WonderID].GetComponent<Image>();
          ((MaskableGraphic) this.TileYolkImage[WonderID]).material.renderQueue = 2550;
          this.TileYolkImage[WonderID].SetNativeSize();
          ((Transform) this.TileYolkRectTransform[WonderID]).localPosition = Vector3.forward * this.forward;
          ((Transform) this.TileYolkRectTransform[WonderID]).SetParent(this.realmGroup, false);
        }
      }
      StringManager.Instance.DeSpawnString(cstring);
    }
    if (!this.TileYolkGameObject[WonderID].activeSelf)
    {
      vector2_1.x *= 128f;
      vector2_1.y *= -64f;
      Vector2 vector2_2 = vector2_1 + pos;
      if (WonderID == 0)
      {
        vector2_2.y += this.offset;
        if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Hunter)
        {
          this.tickcolorbigYolkID = (byte) 0;
          ((Graphic) this.TileYolkImage[WonderID]).color = this.wolfbigYolkTickColor;
        }
        else if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Target)
        {
          this.tickcolorbigYolkID = (byte) 0;
          ((Graphic) this.TileYolkImage[WonderID]).color = this.sheepbigYolkTickColor;
        }
        else
        {
          this.tickcolorbigYolkID = (byte) 40;
          ((Graphic) this.TileYolkImage[WonderID]).color = Color.white;
        }
      }
      else
      {
        vector2_2.y += this.LittleYolkoffset;
        if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Hunter)
        {
          this.tickcolorlittleYolkID[(int) this.tickcolorlittleYolkIDCount] = (byte) WonderID;
          ++this.tickcolorlittleYolkIDCount;
          ((Graphic) this.TileYolkImage[WonderID]).color = this.wolflittleYolkTickColor;
        }
        else if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Target)
        {
          this.tickcolorlittleYolkID[(int) this.tickcolorlittleYolkIDCount] = (byte) WonderID;
          ++this.tickcolorlittleYolkIDCount;
          ((Graphic) this.TileYolkImage[WonderID]).color = this.sheeplittleYolkTickColor;
        }
        else
        {
          for (int index = 0; index < (int) this.tickcolorlittleYolkIDCount; ++index)
          {
            if ((int) this.tickcolorlittleYolkID[index] == WonderID)
            {
              --this.tickcolorlittleYolkIDCount;
              this.tickcolorlittleYolkID[index] = this.tickcolorlittleYolkID[(int) this.tickcolorlittleYolkIDCount];
              this.tickcolorlittleYolkID[(int) this.tickcolorlittleYolkIDCount] = (byte) 0;
              ((Graphic) this.TileYolkImage[WonderID]).color = Color.white;
              break;
            }
          }
        }
      }
      this.TileYolkGameObject[WonderID].SetActive(true);
      this.TileYolkRectTransform[WonderID].anchoredPosition = vector2_2;
      ushort num3 = (ushort) WonderID;
      DataManager.msgBuffer[0] = (byte) 94;
      GameConstants.GetBytes(num3, DataManager.msgBuffer, 1);
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
    return WonderID;
  }

  public bool OnYolkSelect(uint mapID)
  {
    for (int index1 = 0; index1 < (int) DataManager.MapDataController.showYolkNum; ++index1)
    {
      ushort WonderID = (ushort) DataManager.MapDataController.showYolkMapYolkID[index1];
      for (ushort index2 = 0; (int) index2 < this.YOLK_MAPID[(int) WonderID].Length; ++index2)
      {
        if ((int) mapID == (int) this.YOLK_MAPID[(int) WonderID][(int) index2])
        {
          switch (DataManager.MapDataController.YolkPointTable[(int) WonderID].WonderState)
          {
            case 0:
            case 1:
              Vector2 yolkPointCode = DataManager.MapDataController.GetYolkPointCode(WonderID, DataManager.MapDataController.FocusKingdomID);
              ushort x = (ushort) yolkPointCode.x;
              byte y = (byte) yolkPointCode.y;
              DataManager.MapDataController.isMarkGroundInfo = (byte) 0;
              DataManager.msgBuffer[0] = (byte) 64;
              GameConstants.GetBytes(this.YOLK_MAPID[(int) WonderID][0], DataManager.msgBuffer, 1);
              GameConstants.GetBytes(x, DataManager.msgBuffer, 5);
              GameConstants.GetBytes((ushort) y, DataManager.msgBuffer, 9);
              GameConstants.GetBytes((ushort) 11, DataManager.msgBuffer, 13);
              GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
              break;
            case 2:
              DataManager.msgBuffer[0] = (byte) 65;
              GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
              GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(614U), DataManager.Instance.mStringTable.GetStringByID(8597U));
              break;
            default:
              DataManager.msgBuffer[0] = (byte) 65;
              GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
              break;
          }
          return true;
        }
      }
    }
    return false;
  }

  public Sprite getMapTileYolkSprite(byte YolkID)
  {
    if ((int) YolkID >= this.TileYolkImage.Length || (UnityEngine.Object) this.TileYolkImage[(int) YolkID] == (UnityEngine.Object) null)
      YolkID = (byte) 1;
    return (UnityEngine.Object) this.TileYolkImage[(int) YolkID] == (UnityEngine.Object) null ? (Sprite) null : this.TileYolkImage[(int) YolkID].sprite;
  }

  public Material getMapTileYolkMaterial(byte YolkID)
  {
    if ((int) YolkID >= this.TileYolkImage.Length || (UnityEngine.Object) this.TileYolkImage[(int) YolkID] == (UnityEngine.Object) null)
      YolkID = (byte) 1;
    return (UnityEngine.Object) this.TileYolkImage[(int) YolkID] == (UnityEngine.Object) null ? (Material) null : ((MaskableGraphic) this.TileYolkImage[(int) YolkID]).material;
  }

  public bool resetYolk()
  {
    EKvKKingdomType nowKvKkingdomType = this.nowKvKKingdomType;
    bool flag = false;
    if (this.tempTileYolkABKey == null)
      this.tempTileYolkABKey = new int[40];
    if (this.tempTileYolkGameObject == null)
      this.tempTileYolkGameObject = new GameObject[40];
    ushort num = DataManager.MapDataController.FocusKingdomID != (ushort) 0 ? DataManager.MapDataController.FocusKingdomID : (ushort) 1;
    this.nowKvKKingdomType = ActivityManager.Instance.getKvKKingdomType(num);
    if (nowKvKkingdomType != this.nowKvKKingdomType)
      flag = true;
    CString cstring = StringManager.Instance.SpawnString();
    cstring.ClearString();
    ushort WonderID1 = 0;
    KingdomMap recordByKey1 = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(num);
    if (ActivityManager.Instance.IsInKvK((ushort) 0) && (int) num != (int) ActivityManager.Instance.KOWKingdomID && DataManager.MapDataController.IsEnemy(num))
      cstring.IntToFormat(0L, 3);
    else
      cstring.IntToFormat(recordByKey1.mapID != (byte) 0 ? (long) recordByKey1.mapID : 1L, 3);
    cstring.AppendFormat("UI/Yolk_{0}");
    this.tempTileYolkABKey[(int) WonderID1] = this.TileYolkABKey[(int) WonderID1];
    AssetBundle assetBundle1 = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int) WonderID1]);
    if ((UnityEngine.Object) assetBundle1 == (UnityEngine.Object) null)
    {
      cstring.ClearString();
      cstring.IntToFormat(1L);
      cstring.AppendFormat("UI/Yolk_{0}");
      assetBundle1 = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int) WonderID1]);
    }
    if (this.TileYolkABKey[(int) WonderID1] != this.tempTileYolkABKey[(int) WonderID1])
    {
      this.tempTileYolkGameObject[(int) WonderID1] = this.TileYolkGameObject[(int) WonderID1];
      RectTransform transform = this.tempTileYolkGameObject[(int) WonderID1].transform as RectTransform;
      this.TileYolkGameObject[(int) WonderID1] = UnityEngine.Object.Instantiate(assetBundle1.mainAsset) as GameObject;
      this.TileYolkGameObject[(int) WonderID1].SetActive(this.tempTileYolkGameObject[(int) WonderID1].activeSelf);
      this.TileYolkRectTransform[(int) WonderID1] = this.TileYolkGameObject[(int) WonderID1].transform as RectTransform;
      this.TileYolkImage[(int) WonderID1] = this.TileYolkGameObject[(int) WonderID1].GetComponent<Image>();
      ((MaskableGraphic) this.TileYolkImage[(int) WonderID1]).material.renderQueue = 2550;
      this.TileYolkImage[(int) WonderID1].SetNativeSize();
      ((Transform) this.TileYolkRectTransform[(int) WonderID1]).localPosition = Vector3.forward * this.forward;
      this.TileYolkRectTransform[(int) WonderID1].anchoredPosition = transform.anchoredPosition;
      ((Transform) this.TileYolkRectTransform[(int) WonderID1]).SetParent(this.realmGroup, false);
      flag = true;
    }
    else
      this.tempTileYolkGameObject[(int) WonderID1] = (GameObject) null;
    if (this.TileYolkGameObject[(int) WonderID1].activeSelf)
    {
      if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Hunter)
      {
        this.tickcolorbigYolkID = (byte) 0;
        ((Graphic) this.TileYolkImage[(int) WonderID1]).color = this.wolfbigYolkTickColor;
      }
      else if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Target)
      {
        this.tickcolorbigYolkID = (byte) 0;
        ((Graphic) this.TileYolkImage[(int) WonderID1]).color = this.sheepbigYolkTickColor;
      }
      else
      {
        this.tickcolorbigYolkID = (byte) 40;
        ((Graphic) this.TileYolkImage[(int) WonderID1]).color = Color.white;
      }
    }
    else
    {
      this.tickcolorbigYolkID = (byte) 40;
      ((Graphic) this.TileYolkImage[(int) WonderID1]).color = Color.white;
    }
    this.YOLK_POS[(int) WonderID1] = DataManager.MapDataController.GetYolkPos(WonderID1, num);
    ++this.YOLK_POS[(int) WonderID1].y;
    this.YOLK_MAPID[(int) WonderID1] = new uint[9];
    this.YOLK_MAPID[(int) WonderID1][0] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x, (int) this.YOLK_POS[(int) WonderID1].y);
    this.YOLK_MAPID[(int) WonderID1][1] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x + 1, (int) this.YOLK_POS[(int) WonderID1].y - 1);
    this.YOLK_MAPID[(int) WonderID1][2] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x - 1, (int) this.YOLK_POS[(int) WonderID1].y - 1);
    this.YOLK_MAPID[(int) WonderID1][3] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x + 2, (int) this.YOLK_POS[(int) WonderID1].y - 2);
    this.YOLK_MAPID[(int) WonderID1][4] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x, (int) this.YOLK_POS[(int) WonderID1].y - 2);
    this.YOLK_MAPID[(int) WonderID1][5] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x - 2, (int) this.YOLK_POS[(int) WonderID1].y - 2);
    this.YOLK_MAPID[(int) WonderID1][6] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x + 1, (int) this.YOLK_POS[(int) WonderID1].y - 3);
    this.YOLK_MAPID[(int) WonderID1][7] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x - 1, (int) this.YOLK_POS[(int) WonderID1].y - 3);
    this.YOLK_MAPID[(int) WonderID1][8] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID1].x, (int) this.YOLK_POS[(int) WonderID1].y - 4);
    for (ushort WonderID2 = 1; WonderID2 < (ushort) 40; ++WonderID2)
    {
      if (DataManager.MapDataController.CheckYolk(WonderID2, num))
      {
        cstring.ClearString();
        if (ActivityManager.Instance.IsInKvK((ushort) 0) && (int) num != (int) ActivityManager.Instance.KOWKingdomID && DataManager.MapDataController.IsEnemy(num))
        {
          cstring.Append("UI/EnemyLittleYolk");
          this.tempTileYolkABKey[(int) WonderID2] = this.TileYolkABKey[(int) WonderID2];
          AssetBundle assetBundle2 = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int) WonderID2]);
          if (this.tempTileYolkABKey[(int) WonderID2] != this.TileYolkABKey[(int) WonderID2])
          {
            this.tempTileYolkGameObject[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2];
            RectTransform transform = this.tempTileYolkGameObject[(int) WonderID2].transform as RectTransform;
            this.TileYolkGameObject[(int) WonderID2] = UnityEngine.Object.Instantiate(assetBundle2.mainAsset) as GameObject;
            this.TileYolkGameObject[(int) WonderID2].SetActive(this.tempTileYolkGameObject[(int) WonderID2].activeSelf);
            this.TileYolkRectTransform[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2].transform as RectTransform;
            this.TileYolkImage[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2].GetComponent<Image>();
            ((MaskableGraphic) this.TileYolkImage[(int) WonderID2]).material.renderQueue = 2550;
            this.TileYolkImage[(int) WonderID2].SetNativeSize();
            ((Transform) this.TileYolkRectTransform[(int) WonderID2]).localPosition = Vector3.forward * this.forward;
            this.TileYolkRectTransform[(int) WonderID2].anchoredPosition = transform.anchoredPosition;
            ((Transform) this.TileYolkRectTransform[(int) WonderID2]).SetParent(this.realmGroup, false);
            flag = true;
          }
          else
            this.tempTileYolkGameObject[(int) WonderID2] = (GameObject) null;
        }
        else
        {
          KingdomYolkDeploy recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(0);
          int Index;
          for (Index = 1; Index < DataManager.MapDataController.KingdomYolkDeployTable.TableCount; ++Index)
          {
            recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(Index);
            if ((int) recordByIndex.kingdomID == (int) num)
              break;
          }
          if (Index >= DataManager.MapDataController.KingdomYolkDeployTable.TableCount)
          {
            cstring.Append("UI/LittleYolk");
            this.tempTileYolkABKey[(int) WonderID2] = this.TileYolkABKey[(int) WonderID2];
            AssetBundle assetBundle3 = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int) WonderID2]);
            if (this.tempTileYolkABKey[(int) WonderID2] != this.TileYolkABKey[(int) WonderID2])
            {
              this.tempTileYolkGameObject[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2];
              RectTransform transform = this.tempTileYolkGameObject[(int) WonderID2].transform as RectTransform;
              this.TileYolkGameObject[(int) WonderID2] = UnityEngine.Object.Instantiate(assetBundle3.mainAsset) as GameObject;
              this.TileYolkGameObject[(int) WonderID2].SetActive(this.tempTileYolkGameObject[(int) WonderID2].activeSelf);
              this.TileYolkRectTransform[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2].transform as RectTransform;
              this.TileYolkImage[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2].GetComponent<Image>();
              ((MaskableGraphic) this.TileYolkImage[(int) WonderID2]).material.renderQueue = 2550;
              this.TileYolkImage[(int) WonderID2].SetNativeSize();
              ((Transform) this.TileYolkRectTransform[(int) WonderID2]).localPosition = Vector3.forward * this.forward;
              this.TileYolkRectTransform[(int) WonderID2].anchoredPosition = transform.anchoredPosition;
              ((Transform) this.TileYolkRectTransform[(int) WonderID2]).SetParent(this.realmGroup, false);
              flag = true;
            }
            else
              this.tempTileYolkGameObject[(int) WonderID2] = (GameObject) null;
          }
          else
          {
            YolkDeploy recordByKey2 = DataManager.MapDataController.YolkDeployTable.GetRecordByKey(recordByIndex.yolkDeployIDs[(int) WonderID2]);
            cstring.ClearString();
            cstring.IntToFormat((long) recordByKey2.iconID, 3);
            cstring.AppendFormat("UI/LittleYolk_{0}");
            this.tempTileYolkABKey[(int) WonderID2] = this.TileYolkABKey[(int) WonderID2];
            AssetBundle assetBundle4 = AssetManager.GetAssetBundle(cstring, out this.TileYolkABKey[(int) WonderID2]);
            if (this.tempTileYolkABKey[(int) WonderID2] != this.TileYolkABKey[(int) WonderID2])
            {
              this.tempTileYolkGameObject[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2];
              RectTransform transform = this.tempTileYolkGameObject[(int) WonderID2].transform as RectTransform;
              this.TileYolkGameObject[(int) WonderID2] = UnityEngine.Object.Instantiate(assetBundle4.mainAsset) as GameObject;
              this.TileYolkGameObject[(int) WonderID2].SetActive(this.tempTileYolkGameObject[(int) WonderID2].activeSelf);
              this.TileYolkRectTransform[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2].transform as RectTransform;
              this.TileYolkImage[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2].GetComponent<Image>();
              ((MaskableGraphic) this.TileYolkImage[(int) WonderID2]).material.renderQueue = 2550;
              this.TileYolkImage[(int) WonderID2].SetNativeSize();
              ((Transform) this.TileYolkRectTransform[(int) WonderID2]).localPosition = Vector3.forward * this.forward;
              this.TileYolkRectTransform[(int) WonderID2].anchoredPosition = transform.anchoredPosition;
              ((Transform) this.TileYolkRectTransform[(int) WonderID2]).SetParent(this.realmGroup, false);
              flag = true;
            }
            else
              this.tempTileYolkGameObject[(int) WonderID2] = (GameObject) null;
          }
        }
      }
      else
      {
        this.tempTileYolkGameObject[(int) WonderID2] = this.TileYolkGameObject[(int) WonderID2] = (GameObject) null;
        this.TileYolkRectTransform[(int) WonderID2] = (RectTransform) null;
        this.TileYolkImage[(int) WonderID2] = (Image) null;
        this.tempTileYolkABKey[(int) WonderID2] = this.TileYolkABKey[(int) WonderID2] = 0;
      }
      this.YOLK_POS[(int) WonderID2] = DataManager.MapDataController.GetYolkPos(WonderID2, num);
      ++this.YOLK_POS[(int) WonderID2].y;
      this.YOLK_MAPID[(int) WonderID2] = new uint[9];
      this.YOLK_MAPID[(int) WonderID2][0] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x, (int) this.YOLK_POS[(int) WonderID2].y);
      this.YOLK_MAPID[(int) WonderID2][1] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x + 1, (int) this.YOLK_POS[(int) WonderID2].y - 1);
      this.YOLK_MAPID[(int) WonderID2][2] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x - 1, (int) this.YOLK_POS[(int) WonderID2].y - 1);
      this.YOLK_MAPID[(int) WonderID2][3] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x + 2, (int) this.YOLK_POS[(int) WonderID2].y - 2);
      this.YOLK_MAPID[(int) WonderID2][4] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x, (int) this.YOLK_POS[(int) WonderID2].y - 2);
      this.YOLK_MAPID[(int) WonderID2][5] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x - 2, (int) this.YOLK_POS[(int) WonderID2].y - 2);
      this.YOLK_MAPID[(int) WonderID2][6] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x + 1, (int) this.YOLK_POS[(int) WonderID2].y - 3);
      this.YOLK_MAPID[(int) WonderID2][7] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x - 1, (int) this.YOLK_POS[(int) WonderID2].y - 3);
      this.YOLK_MAPID[(int) WonderID2][8] = (uint) GameConstants.TileMapPosToMapID((int) this.YOLK_POS[(int) WonderID2].x, (int) this.YOLK_POS[(int) WonderID2].y - 4);
      if (flag)
      {
        if (this.tickcolorlittleYolkIDCount > (byte) 0)
        {
          for (int index = 0; index < (int) this.tickcolorlittleYolkIDCount; ++index)
          {
            if ((int) this.tickcolorlittleYolkID[index] == (int) WonderID2)
            {
              --this.tickcolorlittleYolkIDCount;
              this.tickcolorlittleYolkID[index] = this.tickcolorlittleYolkID[(int) this.tickcolorlittleYolkIDCount];
              this.tickcolorlittleYolkID[(int) this.tickcolorlittleYolkIDCount] = (byte) 0;
              if ((UnityEngine.Object) this.TileYolkImage[(int) WonderID2] != (UnityEngine.Object) null)
              {
                ((Graphic) this.TileYolkImage[(int) WonderID2]).color = Color.white;
                break;
              }
              break;
            }
          }
        }
        if ((UnityEngine.Object) this.TileYolkGameObject[(int) WonderID2] != (UnityEngine.Object) null && this.TileYolkGameObject[(int) WonderID2].activeSelf)
        {
          if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Hunter)
          {
            this.tickcolorlittleYolkID[(int) this.tickcolorlittleYolkIDCount] = (byte) WonderID2;
            ++this.tickcolorlittleYolkIDCount;
            ((Graphic) this.TileYolkImage[(int) WonderID2]).color = this.wolflittleYolkTickColor;
          }
          else if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Target)
          {
            this.tickcolorlittleYolkID[(int) this.tickcolorlittleYolkIDCount] = (byte) WonderID2;
            ++this.tickcolorlittleYolkIDCount;
            ((Graphic) this.TileYolkImage[(int) WonderID2]).color = this.sheeplittleYolkTickColor;
          }
        }
      }
    }
    StringManager.Instance.DeSpawnString(cstring);
    if (this.tempTileYolkGameObject != null)
    {
      for (int index = 0; index < this.tempTileYolkGameObject.Length; ++index)
      {
        if (this.tempTileYolkABKey[index] != 0)
        {
          AssetManager.UnloadAssetBundle(this.tempTileYolkABKey[index]);
          this.tempTileYolkABKey[index] = 0;
        }
        if ((UnityEngine.Object) this.tempTileYolkGameObject[index] != (UnityEngine.Object) null)
        {
          UnityEngine.Object.Destroy((UnityEngine.Object) this.tempTileYolkGameObject[index]);
          this.tempTileYolkGameObject[index] = (GameObject) null;
        }
      }
    }
    return flag;
  }

  public void resetYolkTickColor()
  {
    this.nowKvKKingdomType = ActivityManager.Instance.getKvKKingdomType(DataManager.MapDataController.FocusKingdomID != (ushort) 0 ? DataManager.MapDataController.FocusKingdomID : (ushort) 1);
    this.TickColor();
  }

  public void TickColor()
  {
    if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Hunter)
    {
      if (this.tickcolorbigYolkID == (byte) 0)
        ((Graphic) this.TileYolkImage[(int) this.tickcolorbigYolkID]).color = this.wolfbigYolkTickColor;
      for (int index = 0; index < (int) this.tickcolorlittleYolkIDCount; ++index)
        ((Graphic) this.TileYolkImage[(int) this.tickcolorlittleYolkID[index]]).color = this.wolflittleYolkTickColor;
    }
    else if (this.nowKvKKingdomType == EKvKKingdomType.EKKT_Target)
    {
      if (this.tickcolorbigYolkID == (byte) 0)
        ((Graphic) this.TileYolkImage[(int) this.tickcolorbigYolkID]).color = this.sheepbigYolkTickColor;
      for (int index = 0; index < (int) this.tickcolorlittleYolkIDCount; ++index)
        ((Graphic) this.TileYolkImage[(int) this.tickcolorlittleYolkID[index]]).color = this.sheeplittleYolkTickColor;
    }
    else
    {
      this.tickcolorbigYolkID = (byte) 40;
      if ((UnityEngine.Object) this.TileYolkImage[0] != (UnityEngine.Object) null)
        ((Graphic) this.TileYolkImage[0]).color = Color.white;
      for (int index = 0; index < (int) this.tickcolorlittleYolkIDCount; ++index)
      {
        if ((UnityEngine.Object) this.TileYolkImage[(int) this.tickcolorlittleYolkID[index]] != (UnityEngine.Object) null)
          ((Graphic) this.TileYolkImage[(int) this.tickcolorlittleYolkID[index]]).color = Color.white;
        this.tickcolorlittleYolkID[index] = (byte) 0;
      }
      this.tickcolorlittleYolkIDCount = (byte) 0;
      for (int index = 0; index < this.TileYolkImage.Length; ++index)
      {
        if ((UnityEngine.Object) this.TileYolkImage[index] != (UnityEngine.Object) null)
          ((Graphic) this.TileYolkImage[index]).color = Color.white;
      }
    }
  }
}
