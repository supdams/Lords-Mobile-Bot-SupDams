// Decompiled with JetBrains decompiler
// Type: MapTileLevel
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class MapTileLevel
{
  private const int rankone = 113;
  private const int darkrankone = 256;
  public Transform LevelLayout;
  private Sprite[] LevelSprite;
  private Sprite[] DarkLevelSprite;
  private GameObject[][] LevelGameObject;
  private RectTransform[][] LevelRectTransform;
  private Image[][] LevelImage;
  private GameObject[][] LevelGameObjectPools;
  private RectTransform[][] LevelRectTransformPools;
  private Image[][] LevelImagePools;
  private int[] poolCounter;
  private int poolsCounter;
  private Material LevelImageMaterial;
  private float BaseScale;
  private Vector2 LevelImageOffset = new Vector2(70.7f, -5.4f);
  private Vector2 inisize = new Vector2(52f, 29f);
  private Vector3 inipos = new Vector3(0.0f, 1024f, 0.0f);

  public MapTileLevel(Transform realmGroup, UISpritesArray tileSprites)
  {
    this.LevelSprite = new Sprite[25];
    for (int index = 0; index < this.LevelSprite.Length; ++index)
      this.LevelSprite[index] = tileSprites.GetSprite(index + 113);
    this.DarkLevelSprite = new Sprite[5];
    for (int index = 0; index < this.DarkLevelSprite.Length; ++index)
      this.DarkLevelSprite[index] = tileSprites.GetSprite(index + 256);
    this.LevelLayout = new GameObject(nameof (MapTileLevel)).transform;
    this.LevelLayout.position = Vector3.forward * 3968f;
    this.LevelLayout.SetParent(realmGroup, false);
    this.poolsCounter = 0;
  }

  public void OnDestroy()
  {
    if (this.LevelGameObject != null)
    {
      for (int index = 0; index < this.LevelGameObject.Length; ++index)
      {
        Array.Clear((Array) this.LevelGameObject[index], 0, this.LevelGameObject[index].Length);
        this.LevelGameObject[index] = (GameObject[]) null;
      }
    }
    if (this.LevelRectTransform != null)
    {
      for (int index = 0; index < this.LevelRectTransform.Length; ++index)
      {
        Array.Clear((Array) this.LevelRectTransform[index], 0, this.LevelRectTransform[index].Length);
        this.LevelRectTransform[index] = (RectTransform[]) null;
      }
    }
    if (this.LevelImage != null)
    {
      for (int index = 0; index < this.LevelImage.Length; ++index)
      {
        Array.Clear((Array) this.LevelImage[index], 0, this.LevelImage[index].Length);
        this.LevelImage[index] = (Image[]) null;
      }
    }
    if (this.LevelGameObjectPools != null)
    {
      for (int index = 0; index < this.LevelGameObjectPools.Length; ++index)
      {
        if (this.LevelGameObjectPools[index] != null)
        {
          Array.Clear((Array) this.LevelGameObjectPools[index], 0, this.LevelGameObjectPools[index].Length);
          this.LevelGameObjectPools[index] = (GameObject[]) null;
        }
      }
    }
    if (this.LevelRectTransformPools != null)
    {
      for (int index = 0; index < this.LevelRectTransformPools.Length; ++index)
      {
        if (this.LevelRectTransformPools[index] != null)
        {
          Array.Clear((Array) this.LevelRectTransformPools[index], 0, this.LevelRectTransformPools[index].Length);
          this.LevelRectTransformPools[index] = (RectTransform[]) null;
        }
      }
    }
    if (this.LevelImagePools != null)
    {
      for (int index = 0; index < this.LevelImagePools.Length; ++index)
      {
        if (this.LevelImagePools[index] != null)
        {
          Array.Clear((Array) this.LevelImagePools[index], 0, this.LevelImagePools[index].Length);
          this.LevelImagePools[index] = (Image[]) null;
        }
      }
    }
    if (this.poolCounter != null)
    {
      Array.Clear((Array) this.poolCounter, 0, this.poolCounter.Length);
      this.poolCounter = (int[]) null;
    }
    Array.Clear((Array) this.LevelSprite, 0, this.LevelSprite.Length);
    Array.Clear((Array) this.DarkLevelSprite, 0, this.DarkLevelSprite.Length);
    if ((UnityEngine.Object) this.LevelLayout != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.LevelLayout);
    this.LevelLayout = (Transform) null;
  }

  public void IniLevelImag(int rowNum, int colNum, float tileBaseScale, Material imageMaterial)
  {
    this.LevelGameObject = new GameObject[colNum][];
    this.LevelRectTransform = new RectTransform[colNum][];
    this.LevelImage = new Image[colNum][];
    for (int index = 0; index < colNum; ++index)
    {
      this.LevelGameObject[index] = new GameObject[rowNum];
      this.LevelRectTransform[index] = new RectTransform[rowNum];
      this.LevelImage[index] = new Image[rowNum];
      Array.Clear((Array) this.LevelGameObject[index], 0, this.LevelGameObject[index].Length);
      Array.Clear((Array) this.LevelRectTransform[index], 0, this.LevelRectTransform[index].Length);
      Array.Clear((Array) this.LevelImage[index], 0, this.LevelImage[index].Length);
    }
    this.LevelImageMaterial = imageMaterial;
    this.BaseScale = tileBaseScale;
    this.LevelGameObjectPools = new GameObject[rowNum][];
    this.LevelRectTransformPools = new RectTransform[rowNum][];
    this.LevelImagePools = new Image[rowNum][];
    this.poolCounter = new int[rowNum];
    Array.Clear((Array) this.LevelGameObjectPools, 0, this.LevelGameObjectPools.Length);
    Array.Clear((Array) this.LevelRectTransformPools, 0, this.LevelRectTransformPools.Length);
    Array.Clear((Array) this.LevelImagePools, 0, this.LevelImagePools.Length);
    for (int index = 0; index < this.poolCounter.Length; ++index)
      this.poolCounter[index] = -1;
    this.LevelGameObjectPools[0] = new GameObject[colNum];
    this.LevelImagePools[0] = new Image[colNum];
    this.LevelRectTransformPools[0] = new RectTransform[colNum];
    for (int index = 0; index < this.LevelGameObjectPools[0].Length; ++index)
    {
      GameObject gameObject = new GameObject("level");
      gameObject.SetActive(false);
      this.LevelImagePools[0][index] = gameObject.AddComponent<Image>();
      ((MaskableGraphic) this.LevelImagePools[0][index]).material = imageMaterial;
      this.LevelRectTransformPools[0][index] = gameObject.transform as RectTransform;
      this.LevelRectTransformPools[0][index].sizeDelta = this.inisize;
      ((Transform) this.LevelRectTransformPools[0][index]).localPosition = this.inipos;
      ((Transform) this.LevelRectTransformPools[0][index]).localScale = Vector3.one * tileBaseScale;
      ((Transform) this.LevelRectTransformPools[0][index]).SetParent(this.LevelLayout, false);
      this.LevelGameObjectPools[0][index] = gameObject;
    }
    this.poolCounter[0] = colNum;
    this.poolsCounter = 1;
  }

  public void setLevelImage(int level, int row, int col, Vector2 pos, bool dark = false)
  {
    if (level < 1 || level > 25 || dark && level > 5)
    {
      if (!((UnityEngine.Object) this.LevelGameObject[col][row] != (UnityEngine.Object) null))
        return;
      this.LevelGameObject[col][row].SetActive(false);
      for (int index = 0; index < this.poolsCounter; ++index)
      {
        if (this.poolCounter[index] < this.LevelGameObjectPools[index].Length)
        {
          this.LevelGameObjectPools[index][this.poolCounter[index]] = this.LevelGameObject[col][row];
          this.LevelImagePools[index][this.poolCounter[index]] = this.LevelImage[col][row];
          this.LevelRectTransformPools[index][this.poolCounter[index]] = this.LevelRectTransform[col][row];
          this.LevelGameObject[col][row] = (GameObject) null;
          this.LevelImage[col][row] = (Image) null;
          this.LevelRectTransform[col][row] = (RectTransform) null;
          ++this.poolCounter[index];
          break;
        }
      }
    }
    else
    {
      if ((UnityEngine.Object) this.LevelGameObject[col][row] == (UnityEngine.Object) null)
      {
        int index1;
        for (index1 = 0; index1 < this.poolsCounter; ++index1)
        {
          if (this.poolCounter[index1] > 0)
          {
            --this.poolCounter[index1];
            this.LevelGameObject[col][row] = this.LevelGameObjectPools[index1][this.poolCounter[index1]];
            this.LevelImage[col][row] = this.LevelImagePools[index1][this.poolCounter[index1]];
            this.LevelRectTransform[col][row] = this.LevelRectTransformPools[index1][this.poolCounter[index1]];
            this.LevelGameObjectPools[index1][this.poolCounter[index1]] = (GameObject) null;
            this.LevelImagePools[index1][this.poolCounter[index1]] = (Image) null;
            this.LevelRectTransformPools[index1][this.poolCounter[index1]] = (RectTransform) null;
            break;
          }
        }
        if (index1 == this.poolsCounter)
        {
          this.LevelGameObjectPools[index1] = new GameObject[this.LevelGameObjectPools[0].Length];
          this.LevelImagePools[index1] = new Image[this.LevelGameObjectPools[0].Length];
          this.LevelRectTransformPools[index1] = new RectTransform[this.LevelGameObjectPools[0].Length];
          for (int index2 = 0; index2 < this.LevelGameObjectPools[index1].Length; ++index2)
          {
            GameObject gameObject = new GameObject(nameof (level));
            gameObject.SetActive(false);
            this.LevelImagePools[index1][index2] = gameObject.AddComponent<Image>();
            ((MaskableGraphic) this.LevelImagePools[index1][index2]).material = this.LevelImageMaterial;
            this.LevelRectTransformPools[index1][index2] = gameObject.transform as RectTransform;
            this.LevelRectTransformPools[index1][index2].sizeDelta = this.inisize;
            ((Transform) this.LevelRectTransformPools[index1][index2]).localPosition = this.inipos;
            ((Transform) this.LevelRectTransformPools[index1][index2]).localScale = Vector3.one * this.BaseScale;
            ((Transform) this.LevelRectTransformPools[index1][index2]).SetParent(this.LevelLayout, false);
            this.LevelGameObjectPools[index1][index2] = gameObject;
          }
          ++this.poolsCounter;
          this.poolCounter[index1] = this.LevelGameObjectPools[index1].Length;
          --this.poolCounter[index1];
          this.LevelGameObject[col][row] = this.LevelGameObjectPools[index1][this.poolCounter[index1]];
          this.LevelImage[col][row] = this.LevelImagePools[index1][this.poolCounter[index1]];
          this.LevelRectTransform[col][row] = this.LevelRectTransformPools[index1][this.poolCounter[index1]];
          this.LevelGameObjectPools[index1][this.poolCounter[index1]] = (GameObject) null;
          this.LevelImagePools[index1][this.poolCounter[index1]] = (Image) null;
          this.LevelRectTransformPools[index1][this.poolCounter[index1]] = (RectTransform) null;
        }
        this.LevelGameObject[col][row].SetActive(true);
      }
      if (dark)
      {
        if ((UnityEngine.Object) this.LevelImage[col][row].sprite != (UnityEngine.Object) this.DarkLevelSprite[level - 1])
        {
          this.LevelImage[col][row].sprite = this.DarkLevelSprite[level - 1];
          this.LevelImage[col][row].SetNativeSize();
        }
      }
      else if ((UnityEngine.Object) this.LevelImage[col][row].sprite != (UnityEngine.Object) this.LevelSprite[level - 1])
      {
        this.LevelImage[col][row].sprite = this.LevelSprite[level - 1];
        this.LevelImage[col][row].SetNativeSize();
      }
      this.setLevelImage(row, col, pos);
    }
  }

  public void setLevelImage(int row, int col, Vector2 pos)
  {
    if (!((UnityEngine.Object) this.LevelRectTransform[col][row] != (UnityEngine.Object) null))
      return;
    this.LevelRectTransform[col][row].anchoredPosition = pos + this.LevelImageOffset;
  }
}
