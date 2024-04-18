// Decompiled with JetBrains decompiler
// Type: MapTileGraphic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class MapTileGraphic
{
  private Transform GraphicLayout;
  private Transform MainGraphicLayout;
  private Transform YolkGraphicLayout;
  private GameObject[][] GraphicGameObject;
  private RectTransform[][] GraphicRectTransform;
  private Image[][] GraphicImage;
  private GameObject[][] GraphicGameObjectPools;
  private RectTransform[][] GraphicRectTransformPools;
  private Image[][] GraphicImagePools;
  private UISpritesArray GraphicSprites;
  private Vector2 GraphicImageOffSet = new Vector2(0.0f, 30f);
  private Vector2 inisize = new Vector2(44f, 62f);
  private Vector3 inipos = new Vector3(0.0f, 1024f, 0.0f);
  private int[] poolCounter;
  private int poolsCounter;
  private float oBaseScale;
  private float BaseScale;
  private int HeightGraphicID = 4;
  private Sprite HeightSprite;
  private GameObject[] YolkGraphicGameObject;
  private RectTransform[] YolkGraphicRectTransform;
  private Image[] YolkGraphicImage;
  private ushort YolkEmblem = ushort.MaxValue;
  private Vector2 YolkGraphicImageOffSet = Vector2.zero;
  private float YolkGraphicScale = 0.85f;
  private int Yolkrow = -1;
  private int Yolkcol = -1;
  private int YolkGraphic = 6;
  private Vector2[][] GraphicImagePosOffSet;

  public MapTileGraphic(Transform realmGroup, GameObject mapTileGraphic)
  {
    this.GraphicSprites = mapTileGraphic.GetComponent<UISpritesArray>();
    ((MaskableGraphic) this.GraphicSprites.m_Image).material.renderQueue = 2750;
    this.GraphicLayout = mapTileGraphic.transform;
    this.GraphicLayout.position = Vector3.forward * 3198f;
    this.GraphicLayout.SetParent(realmGroup, false);
    this.MainGraphicLayout = new GameObject("graphiclayout").transform;
    this.MainGraphicLayout.SetParent(this.GraphicLayout, false);
    this.YolkGraphicLayout = new GameObject("yolklayout").transform;
    this.YolkGraphicLayout.SetParent(this.GraphicLayout, false);
    this.HeightSprite = this.GraphicSprites.GetSprite(this.HeightGraphicID);
  }

  public void OnDestroy()
  {
    if (this.GraphicGameObject != null)
    {
      for (int index = 0; index < this.GraphicGameObject.Length; ++index)
      {
        Array.Clear((Array) this.GraphicGameObject[index], 0, this.GraphicGameObject[index].Length);
        this.GraphicGameObject[index] = (GameObject[]) null;
      }
    }
    if (this.GraphicRectTransform != null)
    {
      for (int index = 0; index < this.GraphicRectTransform.Length; ++index)
      {
        Array.Clear((Array) this.GraphicRectTransform[index], 0, this.GraphicRectTransform[index].Length);
        this.GraphicRectTransform[index] = (RectTransform[]) null;
      }
    }
    if (this.GraphicImage != null)
    {
      for (int index = 0; index < this.GraphicImage.Length; ++index)
      {
        Array.Clear((Array) this.GraphicImage[index], 0, this.GraphicImage[index].Length);
        this.GraphicImage[index] = (Image[]) null;
      }
    }
    if (this.GraphicGameObjectPools != null)
    {
      for (int index = 0; index < this.GraphicGameObjectPools.Length; ++index)
      {
        if (this.GraphicGameObjectPools[index] != null)
        {
          Array.Clear((Array) this.GraphicGameObjectPools[index], 0, this.GraphicGameObjectPools[index].Length);
          this.GraphicGameObjectPools[index] = (GameObject[]) null;
        }
      }
    }
    if (this.GraphicRectTransformPools != null)
    {
      for (int index = 0; index < this.GraphicRectTransformPools.Length; ++index)
      {
        if (this.GraphicRectTransformPools[index] != null)
        {
          Array.Clear((Array) this.GraphicRectTransformPools[index], 0, this.GraphicRectTransformPools[index].Length);
          this.GraphicRectTransformPools[index] = (RectTransform[]) null;
        }
      }
    }
    if (this.GraphicImagePools != null)
    {
      for (int index = 0; index < this.GraphicImagePools.Length; ++index)
      {
        if (this.GraphicImagePools[index] != null)
        {
          Array.Clear((Array) this.GraphicImagePools[index], 0, this.GraphicImagePools[index].Length);
          this.GraphicImagePools[index] = (Image[]) null;
        }
      }
    }
    if (this.poolCounter != null)
    {
      Array.Clear((Array) this.poolCounter, 0, this.poolCounter.Length);
      this.poolCounter = (int[]) null;
    }
    if (this.YolkGraphicGameObject != null)
    {
      Array.Clear((Array) this.YolkGraphicGameObject, 0, this.YolkGraphicGameObject.Length);
      this.YolkGraphicGameObject = (GameObject[]) null;
    }
    if (this.YolkGraphicRectTransform != null)
    {
      Array.Clear((Array) this.YolkGraphicRectTransform, 0, this.YolkGraphicRectTransform.Length);
      this.YolkGraphicRectTransform = (RectTransform[]) null;
    }
    if (this.YolkGraphicImage != null)
    {
      Array.Clear((Array) this.YolkGraphicImage, 0, this.YolkGraphicImage.Length);
      this.YolkGraphicImage = (Image[]) null;
    }
    if (this.GraphicImagePosOffSet != null)
    {
      Array.Clear((Array) this.GraphicImagePosOffSet, 0, this.GraphicImagePosOffSet.Length);
      this.GraphicImagePosOffSet = (Vector2[][]) null;
    }
    this.GraphicSprites = (UISpritesArray) null;
    if ((UnityEngine.Object) this.GraphicLayout != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.GraphicLayout);
    this.GraphicLayout = (Transform) null;
  }

  public void IniGraphicImag(int rowNum, int colNum, float tileBaseScale)
  {
    this.GraphicGameObject = new GameObject[colNum][];
    this.GraphicRectTransform = new RectTransform[colNum][];
    this.GraphicImage = new Image[colNum][];
    this.GraphicImagePosOffSet = new Vector2[colNum][];
    for (int index1 = 0; index1 < colNum; ++index1)
    {
      this.GraphicGameObject[index1] = new GameObject[rowNum];
      this.GraphicRectTransform[index1] = new RectTransform[rowNum];
      this.GraphicImage[index1] = new Image[rowNum];
      Array.Clear((Array) this.GraphicGameObject[index1], 0, this.GraphicGameObject[index1].Length);
      Array.Clear((Array) this.GraphicRectTransform[index1], 0, this.GraphicRectTransform[index1].Length);
      Array.Clear((Array) this.GraphicImage[index1], 0, this.GraphicImage[index1].Length);
      this.GraphicImagePosOffSet[index1] = new Vector2[rowNum];
      for (int index2 = 0; index2 < rowNum; ++index2)
        this.GraphicImagePosOffSet[index1][index2] = Vector2.zero;
    }
    this.oBaseScale = this.BaseScale = tileBaseScale;
    this.BaseScale *= 0.725f;
    this.GraphicGameObjectPools = new GameObject[rowNum][];
    this.GraphicRectTransformPools = new RectTransform[rowNum][];
    this.GraphicImagePools = new Image[rowNum][];
    this.poolCounter = new int[rowNum];
    Array.Clear((Array) this.GraphicGameObjectPools, 0, this.GraphicGameObjectPools.Length);
    Array.Clear((Array) this.GraphicRectTransformPools, 0, this.GraphicRectTransformPools.Length);
    Array.Clear((Array) this.GraphicImagePools, 0, this.GraphicImagePools.Length);
    for (int index = 0; index < this.poolCounter.Length; ++index)
      this.poolCounter[index] = -1;
    this.YolkGraphicGameObject = new GameObject[2];
    this.YolkGraphicImage = new Image[2];
    this.YolkGraphicRectTransform = new RectTransform[2];
    for (int index = 0; index < this.YolkGraphicGameObject.Length; ++index)
    {
      GameObject gameObject = new GameObject("yolkgraphic");
      gameObject.SetActive(false);
      this.YolkGraphicImage[index] = gameObject.AddComponent<Image>();
      ((MaskableGraphic) this.YolkGraphicImage[index]).material = UnityEngine.Object.Instantiate((UnityEngine.Object) GUIManager.Instance.GetBadgeMaterial(index == 0)) as Material;
      ((MaskableGraphic) this.YolkGraphicImage[index]).material.renderQueue = 2750;
      this.YolkGraphicRectTransform[index] = gameObject.transform as RectTransform;
      this.YolkGraphicRectTransform[index].sizeDelta = this.inisize;
      ((Transform) this.YolkGraphicRectTransform[index]).localPosition = this.inipos;
      ((Transform) this.YolkGraphicRectTransform[index]).localScale = Vector3.one * this.YolkGraphicScale;
      ((Transform) this.YolkGraphicRectTransform[index]).SetParent(this.YolkGraphicLayout, false);
      this.YolkGraphicGameObject[index] = gameObject;
    }
    this.GraphicGameObjectPools[0] = new GameObject[colNum];
    this.GraphicImagePools[0] = new Image[colNum];
    this.GraphicRectTransformPools[0] = new RectTransform[colNum];
    for (int index = 0; index < this.GraphicGameObjectPools[0].Length; ++index)
    {
      GameObject gameObject = new GameObject("graphic");
      gameObject.SetActive(false);
      this.GraphicImagePools[0][index] = gameObject.AddComponent<Image>();
      ((MaskableGraphic) this.GraphicImagePools[0][index]).material = ((MaskableGraphic) this.GraphicSprites.m_Image).material;
      this.GraphicRectTransformPools[0][index] = gameObject.transform as RectTransform;
      this.GraphicRectTransformPools[0][index].sizeDelta = this.inisize;
      ((Transform) this.GraphicRectTransformPools[0][index]).localPosition = this.inipos;
      ((Transform) this.GraphicRectTransformPools[0][index]).localScale = Vector3.one * this.BaseScale;
      ((Transform) this.GraphicRectTransformPools[0][index]).SetParent(this.MainGraphicLayout, false);
      this.GraphicGameObjectPools[0][index] = gameObject;
    }
    this.poolCounter[0] = colNum;
    this.poolsCounter = 1;
  }

  public void setGraphicImage(int graphic, int row, int col, Vector2 pos, ushort mEmblem = 65535)
  {
    if (graphic >= this.YolkGraphic)
      ++graphic;
    if (graphic <= -1)
    {
      int index = -graphic - 1;
      if ((int) this.YolkEmblem != (int) mEmblem)
      {
        this.YolkEmblem = mEmblem;
        int x1 = (((int) mEmblem >> 3 & 7) << 3) + ((int) mEmblem & 7) + 1;
        CString str = StringManager.Instance.SpawnString();
        str.ClearString();
        str.StringToFormat("UI_league_badge_");
        str.IntToFormat((long) x1, 2);
        str.AppendFormat("{0}{1}");
        str.SetLength(str.Length);
        this.YolkGraphicImage[0].sprite = GUIManager.Instance.LoadBadgeSprite(true, str.ToString());
        str.SetLength(str.MaxLength);
        this.YolkGraphicRectTransform[0].pivot = Vector2.one * 0.5f;
        this.YolkGraphicRectTransform[0].anchorMin = Vector2.one * 0.5f;
        this.YolkGraphicRectTransform[0].anchorMax = Vector2.one * 0.5f;
        this.YolkGraphicRectTransform[0].offsetMin = Vector2.zero;
        this.YolkGraphicRectTransform[0].offsetMax = Vector2.zero;
        this.YolkGraphicRectTransform[0].anchoredPosition = Vector2.zero;
        this.YolkGraphicRectTransform[0].sizeDelta = Vector2.one * 64f;
        int x2 = ((int) mEmblem >> 6 & 63) + 1;
        str.ClearString();
        str.StringToFormat("UI_league_totem_");
        str.IntToFormat((long) x2, 2);
        str.AppendFormat("{0}{1}");
        str.SetLength(str.Length);
        this.YolkGraphicImage[1].sprite = GUIManager.Instance.LoadBadgeSprite(false, str.ToString());
        str.SetLength(str.MaxLength);
        this.YolkGraphicImage[1].SetNativeSize();
        StringManager.Instance.DeSpawnString(str);
      }
      KingdomYolkDeploy recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(0);
      int Index;
      for (Index = 1; Index < DataManager.MapDataController.KingdomYolkDeployTable.TableCount; ++Index)
      {
        recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(Index);
        if ((int) recordByIndex.kingdomID == (int) DataManager.MapDataController.FocusKingdomID)
          break;
      }
      if (Index >= DataManager.MapDataController.KingdomYolkDeployTable.TableCount)
        recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(0);
      this.YolkGraphicImageOffSet.y = (float) DataManager.MapDataController.YolkDeployTable.GetRecordByKey(recordByIndex.yolkDeployIDs[index]).AllianceIconHeight;
      this.YolkGraphicGameObject[0].SetActive(true);
      this.YolkGraphicGameObject[1].SetActive(true);
      this.Yolkrow = row;
      this.Yolkcol = col;
      graphic = this.YolkGraphic;
    }
    if (graphic < 1 || graphic > this.GraphicSprites.m_Sprites.Length)
    {
      if (!((UnityEngine.Object) this.GraphicGameObject[col][row] != (UnityEngine.Object) null))
        return;
      if (col == this.Yolkcol && row == this.Yolkrow)
      {
        this.Yolkrow = -1;
        this.Yolkcol = -1;
        this.YolkGraphicGameObject[0].SetActive(false);
        this.YolkGraphicGameObject[1].SetActive(false);
      }
      this.GraphicGameObject[col][row].SetActive(false);
      ((Transform) this.GraphicRectTransform[col][row]).localScale = Vector3.one * this.BaseScale;
      for (int index = 0; index < this.poolsCounter; ++index)
      {
        if (this.poolCounter[index] < this.GraphicGameObjectPools[index].Length)
        {
          this.GraphicGameObjectPools[index][this.poolCounter[index]] = this.GraphicGameObject[col][row];
          this.GraphicImagePools[index][this.poolCounter[index]] = this.GraphicImage[col][row];
          this.GraphicRectTransformPools[index][this.poolCounter[index]] = this.GraphicRectTransform[col][row];
          this.GraphicGameObject[col][row] = (GameObject) null;
          this.GraphicImage[col][row] = (Image) null;
          this.GraphicRectTransform[col][row] = (RectTransform) null;
          ++this.poolCounter[index];
          break;
        }
      }
      this.GraphicImagePosOffSet[col][row] = Vector2.zero;
    }
    else
    {
      if ((UnityEngine.Object) this.GraphicGameObject[col][row] == (UnityEngine.Object) null)
      {
        int index1;
        for (index1 = 0; index1 < this.poolsCounter; ++index1)
        {
          if (this.poolCounter[index1] > 0)
          {
            --this.poolCounter[index1];
            this.GraphicGameObject[col][row] = this.GraphicGameObjectPools[index1][this.poolCounter[index1]];
            this.GraphicImage[col][row] = this.GraphicImagePools[index1][this.poolCounter[index1]];
            this.GraphicRectTransform[col][row] = this.GraphicRectTransformPools[index1][this.poolCounter[index1]];
            this.GraphicGameObjectPools[index1][this.poolCounter[index1]] = (GameObject) null;
            this.GraphicImagePools[index1][this.poolCounter[index1]] = (Image) null;
            this.GraphicRectTransformPools[index1][this.poolCounter[index1]] = (RectTransform) null;
            break;
          }
        }
        if (index1 == this.poolsCounter)
        {
          this.GraphicGameObjectPools[index1] = new GameObject[this.GraphicGameObjectPools[0].Length];
          this.GraphicImagePools[index1] = new Image[this.GraphicImagePools[0].Length];
          this.GraphicRectTransformPools[index1] = new RectTransform[this.GraphicRectTransformPools[0].Length];
          for (int index2 = 0; index2 < this.GraphicGameObjectPools[index1].Length; ++index2)
          {
            GameObject gameObject = new GameObject(nameof (graphic));
            gameObject.SetActive(false);
            this.GraphicImagePools[index1][index2] = gameObject.AddComponent<Image>();
            ((MaskableGraphic) this.GraphicImagePools[index1][index2]).material = ((MaskableGraphic) this.GraphicSprites.m_Image).material;
            this.GraphicRectTransformPools[index1][index2] = gameObject.transform as RectTransform;
            this.GraphicRectTransformPools[index1][index2].sizeDelta = this.inisize;
            ((Transform) this.GraphicRectTransformPools[index1][index2]).localPosition = this.inipos;
            ((Transform) this.GraphicRectTransformPools[index1][index2]).localScale = graphic == 6 || graphic < 5 ? Vector3.one * this.oBaseScale : Vector3.one * this.BaseScale;
            ((Transform) this.GraphicRectTransformPools[index1][index2]).SetParent(this.MainGraphicLayout, false);
            this.GraphicGameObjectPools[index1][index2] = gameObject;
          }
          ++this.poolsCounter;
          this.poolCounter[index1] = this.GraphicGameObjectPools[index1].Length;
          --this.poolCounter[index1];
          this.GraphicGameObject[col][row] = this.GraphicGameObjectPools[index1][this.poolCounter[index1]];
          this.GraphicImage[col][row] = this.GraphicImagePools[index1][this.poolCounter[index1]];
          this.GraphicRectTransform[col][row] = this.GraphicRectTransformPools[index1][this.poolCounter[index1]];
          this.GraphicGameObjectPools[index1][this.poolCounter[index1]] = (GameObject) null;
          this.GraphicImagePools[index1][this.poolCounter[index1]] = (Image) null;
          this.GraphicRectTransformPools[index1][this.poolCounter[index1]] = (RectTransform) null;
        }
        this.GraphicGameObject[col][row].SetActive(true);
        if (graphic == this.YolkGraphic)
          ((Transform) this.GraphicRectTransform[col][row]).localScale = Vector3.one * this.YolkGraphicScale;
        else if (graphic == 6 || graphic < 5)
          ((Transform) this.GraphicRectTransform[col][row]).localScale = Vector3.one * this.oBaseScale;
        else
          ((Transform) this.GraphicRectTransform[col][row]).localScale = Vector3.one * this.BaseScale;
      }
      else if (graphic == this.YolkGraphic)
        ((Transform) this.GraphicRectTransform[col][row]).localScale = Vector3.one * this.YolkGraphicScale;
      else if (this.Yolkrow == row && this.Yolkcol == col)
      {
        this.Yolkrow = -1;
        this.Yolkcol = -1;
        this.YolkGraphicGameObject[0].SetActive(false);
        this.YolkGraphicGameObject[1].SetActive(false);
        ((Transform) this.GraphicRectTransform[col][row]).localScale = graphic == 6 || graphic < 5 ? Vector3.one * this.oBaseScale : Vector3.one * this.BaseScale;
      }
      else if (graphic == 6 || graphic < 5)
        ((Transform) this.GraphicRectTransform[col][row]).localScale = Vector3.one * this.oBaseScale;
      else
        ((Transform) this.GraphicRectTransform[col][row]).localScale = Vector3.one * this.BaseScale;
      if ((UnityEngine.Object) this.GraphicImage[col][row].sprite != (UnityEngine.Object) this.GraphicSprites.GetSprite(graphic - 1))
      {
        this.GraphicImage[col][row].sprite = this.GraphicSprites.GetSprite(graphic - 1);
        if ((UnityEngine.Object) this.GraphicImage[col][row].sprite == (UnityEngine.Object) null)
          this.GraphicImage[col][row].sprite = this.GraphicSprites.GetSprite(46);
        this.GraphicImage[col][row].SetNativeSize();
      }
      this.GraphicImagePosOffSet[col][row] = graphic != this.YolkGraphic ? (graphic == 5 || graphic > 6 ? this.GraphicImageOffSet * 2f : this.GraphicImageOffSet) : this.YolkGraphicImageOffSet;
      this.setGraphicImage(row, col, pos);
    }
  }

  public void setGraphicImage(int row, int col, Vector2 pos)
  {
    if (!((UnityEngine.Object) this.GraphicGameObject[col][row] != (UnityEngine.Object) null))
      return;
    if (col == this.Yolkcol && row == this.Yolkrow)
    {
      this.YolkGraphicRectTransform[0].anchoredPosition = pos + this.YolkGraphicImageOffSet;
      this.YolkGraphicRectTransform[1].anchoredPosition = pos + this.YolkGraphicImageOffSet;
    }
    this.GraphicRectTransform[col][row].anchoredPosition = pos + this.GraphicImagePosOffSet[col][row];
  }
}
