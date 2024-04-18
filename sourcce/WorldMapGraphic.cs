// Decompiled with JetBrains decompiler
// Type: WorldMapGraphic
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class WorldMapGraphic
{
  private const int kingdom = 10;
  private const float GraphicScale = 1f;
  private Transform GraphicLayout;
  private Material GraphicSpriteMaterial;
  private Vector2 GraphicImageOffSet = new Vector2(0.0f, 42f);
  private Vector2 inisize = new Vector2(44f, 62f);
  private Vector3 inipos = new Vector3(0.0f, 1024f, 0.0f);
  private float BaseScale;
  private Sprite[] WorldMapSprites = new Sprite[46];
  private float[] kindomYolkHeight;
  private Transform G1;
  private GameObject[][] GraphicGameObject;
  private RectTransform[][] GraphicRectTransform;
  private WorldMapGraphicImage[][] GraphicImage;
  private GameObject[][] GraphicGameObjectPools;
  private RectTransform[][] GraphicRectTransformPools;
  private WorldMapGraphicImage[][] GraphicImagePools;
  private int[] poolCounter;
  private int poolsCounter;
  private Vector2[][] HeightOffset;
  private Transform G2;
  private GameObject[][] GraphicExGameObject;
  private RectTransform[][] GraphicExRectTransform;
  private WorldMapGraphicImage[][] GraphicExImage;
  private GameObject[][] GraphicExGameObjectPools;
  private RectTransform[][] GraphicExRectTransformPools;
  private WorldMapGraphicImage[][] GraphicExImagePools;
  private int[] poolExCounter;
  private int poolsExCounter;
  private Vector2[][] HeightExOffset;
  private Transform G3;
  private GameObject[][] GraphicTrdGameObject;
  private RectTransform[][] GraphicTrdRectTransform;
  private WorldMapGraphicImage[][] GraphicTrdImage;
  private GameObject[][] GraphicTrdGameObjectPools;
  private RectTransform[][] GraphicTrdRectTransformPools;
  private WorldMapGraphicImage[][] GraphicTrdImagePools;
  private int[] poolTrdCounter;
  private int poolsTrdCounter;
  private Vector2[][] HeightTrdOffset;

  public WorldMapGraphic(Transform totalityGroup, UISpritesArray tileSprites)
  {
    this.WorldMapSprites[0] = tileSprites.GetSprite(1);
    this.WorldMapSprites[1] = tileSprites.GetSprite(9);
    this.WorldMapSprites[3] = tileSprites.GetSprite(101);
    int index1 = 60;
    for (int index2 = 4; index2 < this.WorldMapSprites.Length - 2; ++index2)
    {
      this.WorldMapSprites[index2] = tileSprites.GetSprite(index1);
      ++index1;
    }
    this.WorldMapSprites[44] = tileSprites.GetSprite(102);
    this.WorldMapSprites[45] = tileSprites.GetSprite(103);
    this.GraphicSpriteMaterial = new Material(((MaskableGraphic) tileSprites.m_Image).material);
    this.GraphicSpriteMaterial.renderQueue = 2750;
    this.GraphicLayout = new GameObject(nameof (WorldMapGraphic)).transform;
    this.GraphicLayout.position = Vector3.forward * 1536f;
    this.GraphicLayout.SetParent(totalityGroup, false);
    this.G1 = new GameObject(nameof (G1)).transform;
    this.G1.SetParent(this.GraphicLayout, false);
    this.G2 = new GameObject(nameof (G2)).transform;
    this.G2.SetParent(this.GraphicLayout, false);
    this.G3 = new GameObject(nameof (G3)).transform;
    this.G3.SetParent(this.GraphicLayout, false);
    this.kindomYolkHeight = new float[tileSprites.m_Sprites.Length - 10];
    for (int index3 = 0; index3 < this.kindomYolkHeight.Length; ++index3)
      this.kindomYolkHeight[index3] = tileSprites.GetSprite(index3 + 10).rect.size.y;
  }

  public void OnDestroy()
  {
    if (this.HeightOffset != null)
    {
      for (int index = 0; index < this.HeightOffset.Length; ++index)
      {
        Array.Clear((Array) this.HeightOffset[index], 0, this.HeightOffset[index].Length);
        this.HeightOffset[index] = (Vector2[]) null;
      }
      this.HeightOffset = (Vector2[][]) null;
    }
    if (this.HeightExOffset != null)
    {
      for (int index = 0; index < this.HeightExOffset.Length; ++index)
      {
        Array.Clear((Array) this.HeightExOffset[index], 0, this.HeightExOffset[index].Length);
        this.HeightExOffset[index] = (Vector2[]) null;
      }
      this.HeightExOffset = (Vector2[][]) null;
    }
    if (this.HeightTrdOffset != null)
    {
      for (int index = 0; index < this.HeightTrdOffset.Length; ++index)
      {
        Array.Clear((Array) this.HeightTrdOffset[index], 0, this.HeightTrdOffset[index].Length);
        this.HeightTrdOffset[index] = (Vector2[]) null;
      }
      this.HeightTrdOffset = (Vector2[][]) null;
    }
    if (this.GraphicGameObject != null)
    {
      for (int index = 0; index < this.GraphicGameObject.Length; ++index)
      {
        Array.Clear((Array) this.GraphicGameObject[index], 0, this.GraphicGameObject[index].Length);
        this.GraphicGameObject[index] = (GameObject[]) null;
      }
    }
    if (this.GraphicExGameObject != null)
    {
      for (int index = 0; index < this.GraphicExGameObject.Length; ++index)
      {
        Array.Clear((Array) this.GraphicExGameObject[index], 0, this.GraphicExGameObject[index].Length);
        this.GraphicExGameObject[index] = (GameObject[]) null;
      }
    }
    if (this.GraphicTrdGameObject != null)
    {
      for (int index = 0; index < this.GraphicTrdGameObject.Length; ++index)
      {
        Array.Clear((Array) this.GraphicTrdGameObject[index], 0, this.GraphicTrdGameObject[index].Length);
        this.GraphicTrdGameObject[index] = (GameObject[]) null;
      }
    }
    if (this.GraphicRectTransform != null)
    {
      for (int index = 0; index < this.GraphicRectTransform.Length; ++index)
      {
        Array.Clear((Array) this.GraphicRectTransform[index], 0, this.GraphicRectTransform[index].Length);
        this.GraphicRectTransform[index] = (RectTransform[]) null;
      }
      this.GraphicRectTransform = (RectTransform[][]) null;
    }
    if (this.GraphicExRectTransform != null)
    {
      for (int index = 0; index < this.GraphicExRectTransform.Length; ++index)
      {
        Array.Clear((Array) this.GraphicExRectTransform[index], 0, this.GraphicExRectTransform[index].Length);
        this.GraphicExRectTransform[index] = (RectTransform[]) null;
      }
      this.GraphicExRectTransform = (RectTransform[][]) null;
    }
    if (this.GraphicTrdRectTransform != null)
    {
      for (int index = 0; index < this.GraphicTrdRectTransform.Length; ++index)
      {
        Array.Clear((Array) this.GraphicTrdRectTransform[index], 0, this.GraphicTrdRectTransform[index].Length);
        this.GraphicTrdRectTransform[index] = (RectTransform[]) null;
      }
      this.GraphicTrdRectTransform = (RectTransform[][]) null;
    }
    if (this.GraphicImage != null)
    {
      for (int index = 0; index < this.GraphicImage.Length; ++index)
      {
        Array.Clear((Array) this.GraphicImage[index], 0, this.GraphicImage[index].Length);
        this.GraphicImage[index] = (WorldMapGraphicImage[]) null;
      }
      this.GraphicImage = (WorldMapGraphicImage[][]) null;
    }
    if (this.GraphicExImage != null)
    {
      for (int index = 0; index < this.GraphicExImage.Length; ++index)
      {
        Array.Clear((Array) this.GraphicExImage[index], 0, this.GraphicExImage[index].Length);
        this.GraphicExImage[index] = (WorldMapGraphicImage[]) null;
      }
      this.GraphicExImage = (WorldMapGraphicImage[][]) null;
    }
    if (this.GraphicTrdImage != null)
    {
      for (int index = 0; index < this.GraphicTrdImage.Length; ++index)
      {
        Array.Clear((Array) this.GraphicTrdImage[index], 0, this.GraphicTrdImage[index].Length);
        this.GraphicTrdImage[index] = (WorldMapGraphicImage[]) null;
      }
      this.GraphicTrdImage = (WorldMapGraphicImage[][]) null;
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
    if (this.GraphicExGameObjectPools != null)
    {
      for (int index = 0; index < this.GraphicExGameObjectPools.Length; ++index)
      {
        if (this.GraphicExGameObjectPools[index] != null)
        {
          Array.Clear((Array) this.GraphicExGameObjectPools[index], 0, this.GraphicExGameObjectPools[index].Length);
          this.GraphicExGameObjectPools[index] = (GameObject[]) null;
        }
      }
    }
    if (this.GraphicTrdGameObjectPools != null)
    {
      for (int index = 0; index < this.GraphicTrdGameObjectPools.Length; ++index)
      {
        if (this.GraphicTrdGameObjectPools[index] != null)
        {
          Array.Clear((Array) this.GraphicTrdGameObjectPools[index], 0, this.GraphicTrdGameObjectPools[index].Length);
          this.GraphicTrdGameObjectPools[index] = (GameObject[]) null;
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
    if (this.GraphicExRectTransformPools != null)
    {
      for (int index = 0; index < this.GraphicExRectTransformPools.Length; ++index)
      {
        if (this.GraphicExRectTransformPools[index] != null)
        {
          Array.Clear((Array) this.GraphicExRectTransformPools[index], 0, this.GraphicExRectTransformPools[index].Length);
          this.GraphicExRectTransformPools[index] = (RectTransform[]) null;
        }
      }
    }
    if (this.GraphicTrdRectTransformPools != null)
    {
      for (int index = 0; index < this.GraphicTrdRectTransformPools.Length; ++index)
      {
        if (this.GraphicTrdRectTransformPools[index] != null)
        {
          Array.Clear((Array) this.GraphicTrdRectTransformPools[index], 0, this.GraphicTrdRectTransformPools[index].Length);
          this.GraphicTrdRectTransformPools[index] = (RectTransform[]) null;
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
          this.GraphicImagePools[index] = (WorldMapGraphicImage[]) null;
        }
      }
    }
    if (this.GraphicExImagePools != null)
    {
      for (int index = 0; index < this.GraphicExImagePools.Length; ++index)
      {
        if (this.GraphicExImagePools[index] != null)
        {
          Array.Clear((Array) this.GraphicExImagePools[index], 0, this.GraphicExImagePools[index].Length);
          this.GraphicExImagePools[index] = (WorldMapGraphicImage[]) null;
        }
      }
    }
    if (this.GraphicTrdGameObjectPools != null)
    {
      for (int index = 0; index < this.GraphicTrdImagePools.Length; ++index)
      {
        if (this.GraphicTrdImagePools[index] != null)
        {
          Array.Clear((Array) this.GraphicTrdImagePools[index], 0, this.GraphicTrdImagePools[index].Length);
          this.GraphicTrdImagePools[index] = (WorldMapGraphicImage[]) null;
        }
      }
    }
    if (this.poolCounter != null)
    {
      Array.Clear((Array) this.poolCounter, 0, this.poolCounter.Length);
      this.poolCounter = (int[]) null;
    }
    if (this.poolExCounter != null)
    {
      Array.Clear((Array) this.poolExCounter, 0, this.poolExCounter.Length);
      this.poolExCounter = (int[]) null;
    }
    if (this.poolTrdCounter != null)
    {
      Array.Clear((Array) this.poolTrdCounter, 0, this.poolTrdCounter.Length);
      this.poolTrdCounter = (int[]) null;
    }
    if (this.WorldMapSprites != null)
    {
      Array.Clear((Array) this.WorldMapSprites, 0, this.WorldMapSprites.Length);
      this.WorldMapSprites = (Sprite[]) null;
    }
    if (this.kindomYolkHeight != null)
    {
      Array.Clear((Array) this.kindomYolkHeight, 0, this.kindomYolkHeight.Length);
      this.kindomYolkHeight = (float[]) null;
    }
    if ((UnityEngine.Object) this.GraphicLayout != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.GraphicLayout);
    this.GraphicLayout = (Transform) null;
  }

  public void IniGraphicImag(int rowNum, int colNum, float tileBaseScale)
  {
    this.HeightOffset = new Vector2[colNum][];
    this.HeightExOffset = new Vector2[colNum][];
    this.HeightTrdOffset = new Vector2[colNum][];
    this.GraphicGameObject = new GameObject[colNum][];
    this.GraphicExGameObject = new GameObject[colNum][];
    this.GraphicTrdGameObject = new GameObject[colNum][];
    this.GraphicRectTransform = new RectTransform[colNum][];
    this.GraphicExRectTransform = new RectTransform[colNum][];
    this.GraphicTrdRectTransform = new RectTransform[colNum][];
    this.GraphicImage = new WorldMapGraphicImage[colNum][];
    this.GraphicExImage = new WorldMapGraphicImage[colNum][];
    this.GraphicTrdImage = new WorldMapGraphicImage[colNum][];
    for (int index1 = 0; index1 < colNum; ++index1)
    {
      this.GraphicGameObject[index1] = new GameObject[rowNum];
      this.GraphicExGameObject[index1] = new GameObject[rowNum];
      this.GraphicTrdGameObject[index1] = new GameObject[rowNum];
      this.GraphicRectTransform[index1] = new RectTransform[rowNum];
      this.GraphicExRectTransform[index1] = new RectTransform[rowNum];
      this.GraphicTrdRectTransform[index1] = new RectTransform[rowNum];
      this.GraphicImage[index1] = new WorldMapGraphicImage[rowNum];
      this.GraphicExImage[index1] = new WorldMapGraphicImage[rowNum];
      this.GraphicTrdImage[index1] = new WorldMapGraphicImage[rowNum];
      Array.Clear((Array) this.GraphicGameObject[index1], 0, this.GraphicGameObject[index1].Length);
      Array.Clear((Array) this.GraphicExGameObject[index1], 0, this.GraphicExGameObject[index1].Length);
      Array.Clear((Array) this.GraphicTrdGameObject[index1], 0, this.GraphicTrdGameObject[index1].Length);
      Array.Clear((Array) this.GraphicRectTransform[index1], 0, this.GraphicRectTransform[index1].Length);
      Array.Clear((Array) this.GraphicExRectTransform[index1], 0, this.GraphicExRectTransform[index1].Length);
      Array.Clear((Array) this.GraphicTrdRectTransform[index1], 0, this.GraphicTrdRectTransform[index1].Length);
      Array.Clear((Array) this.GraphicImage[index1], 0, this.GraphicImage[index1].Length);
      Array.Clear((Array) this.GraphicExImage[index1], 0, this.GraphicImage[index1].Length);
      Array.Clear((Array) this.GraphicTrdImage[index1], 0, this.GraphicImage[index1].Length);
      this.HeightOffset[index1] = new Vector2[rowNum];
      this.HeightExOffset[index1] = new Vector2[rowNum];
      this.HeightTrdOffset[index1] = new Vector2[rowNum];
      for (int index2 = 0; index2 < rowNum; ++index2)
        this.HeightOffset[index1][index2] = this.HeightExOffset[index1][index2] = this.HeightTrdOffset[index1][index2] = Vector2.zero;
    }
    this.BaseScale = tileBaseScale;
    this.GraphicGameObjectPools = new GameObject[rowNum][];
    this.GraphicExGameObjectPools = new GameObject[rowNum][];
    this.GraphicTrdGameObjectPools = new GameObject[rowNum][];
    this.GraphicRectTransformPools = new RectTransform[rowNum][];
    this.GraphicExRectTransformPools = new RectTransform[rowNum][];
    this.GraphicTrdRectTransformPools = new RectTransform[rowNum][];
    this.GraphicImagePools = new WorldMapGraphicImage[rowNum][];
    this.GraphicExImagePools = new WorldMapGraphicImage[rowNum][];
    this.GraphicTrdImagePools = new WorldMapGraphicImage[rowNum][];
    this.poolCounter = new int[rowNum];
    this.poolExCounter = new int[rowNum];
    this.poolTrdCounter = new int[rowNum];
    Array.Clear((Array) this.GraphicGameObjectPools, 0, this.GraphicGameObjectPools.Length);
    Array.Clear((Array) this.GraphicExGameObjectPools, 0, this.GraphicGameObjectPools.Length);
    Array.Clear((Array) this.GraphicTrdGameObjectPools, 0, this.GraphicGameObjectPools.Length);
    Array.Clear((Array) this.GraphicRectTransformPools, 0, this.GraphicRectTransformPools.Length);
    Array.Clear((Array) this.GraphicExRectTransformPools, 0, this.GraphicRectTransformPools.Length);
    Array.Clear((Array) this.GraphicTrdRectTransformPools, 0, this.GraphicRectTransformPools.Length);
    Array.Clear((Array) this.GraphicImagePools, 0, this.GraphicImagePools.Length);
    Array.Clear((Array) this.GraphicExImagePools, 0, this.GraphicImagePools.Length);
    Array.Clear((Array) this.GraphicTrdImagePools, 0, this.GraphicImagePools.Length);
    for (int index = 0; index < this.poolCounter.Length; ++index)
      this.poolCounter[index] = this.poolExCounter[index] = this.poolTrdCounter[index] = -1;
    this.GraphicGameObjectPools[0] = new GameObject[colNum];
    this.GraphicExGameObjectPools[0] = new GameObject[colNum];
    this.GraphicTrdGameObjectPools[0] = new GameObject[colNum];
    this.GraphicImagePools[0] = new WorldMapGraphicImage[colNum];
    this.GraphicExImagePools[0] = new WorldMapGraphicImage[colNum];
    this.GraphicTrdImagePools[0] = new WorldMapGraphicImage[colNum];
    this.GraphicRectTransformPools[0] = new RectTransform[colNum];
    this.GraphicExRectTransformPools[0] = new RectTransform[colNum];
    this.GraphicTrdRectTransformPools[0] = new RectTransform[colNum];
    for (int index = 0; index < this.GraphicGameObjectPools[0].Length; ++index)
    {
      GameObject gameObject = new GameObject("graphic");
      gameObject.SetActive(false);
      this.GraphicImagePools[0][index] = gameObject.AddComponent<WorldMapGraphicImage>();
      ((MaskableGraphic) this.GraphicImagePools[0][index]).material = this.GraphicSpriteMaterial;
      this.GraphicRectTransformPools[0][index] = gameObject.transform as RectTransform;
      this.GraphicRectTransformPools[0][index].sizeDelta = this.inisize;
      ((Transform) this.GraphicRectTransformPools[0][index]).localPosition = this.inipos;
      ((Transform) this.GraphicRectTransformPools[0][index]).localScale = Vector3.one * tileBaseScale * 1f;
      ((Transform) this.GraphicRectTransformPools[0][index]).SetParent(this.G1, false);
      this.GraphicGameObjectPools[0][index] = gameObject;
    }
    this.poolCounter[0] = colNum;
    this.poolsCounter = 1;
    for (int index = 0; index < this.GraphicExGameObjectPools[0].Length; ++index)
    {
      GameObject gameObject = new GameObject("graphicEx");
      gameObject.SetActive(false);
      this.GraphicExImagePools[0][index] = gameObject.AddComponent<WorldMapGraphicImage>();
      ((MaskableGraphic) this.GraphicExImagePools[0][index]).material = this.GraphicSpriteMaterial;
      this.GraphicExRectTransformPools[0][index] = gameObject.transform as RectTransform;
      this.GraphicExRectTransformPools[0][index].sizeDelta = this.inisize;
      ((Transform) this.GraphicExRectTransformPools[0][index]).localPosition = this.inipos;
      ((Transform) this.GraphicExRectTransformPools[0][index]).localScale = Vector3.one * tileBaseScale * 1f;
      ((Transform) this.GraphicExRectTransformPools[0][index]).SetParent(this.G2, false);
      this.GraphicExGameObjectPools[0][index] = gameObject;
    }
    this.poolExCounter[0] = colNum;
    this.poolsExCounter = 1;
    for (int index = 0; index < this.GraphicTrdGameObjectPools[0].Length; ++index)
    {
      GameObject gameObject = new GameObject("graphicTrd");
      gameObject.SetActive(false);
      this.GraphicTrdImagePools[0][index] = gameObject.AddComponent<WorldMapGraphicImage>();
      ((MaskableGraphic) this.GraphicTrdImagePools[0][index]).material = this.GraphicSpriteMaterial;
      this.GraphicTrdRectTransformPools[0][index] = gameObject.transform as RectTransform;
      this.GraphicTrdRectTransformPools[0][index].sizeDelta = this.inisize;
      ((Transform) this.GraphicTrdRectTransformPools[0][index]).localPosition = this.inipos;
      ((Transform) this.GraphicTrdRectTransformPools[0][index]).localScale = Vector3.one * tileBaseScale * 1f;
      ((Transform) this.GraphicTrdRectTransformPools[0][index]).SetParent(this.G2, false);
      this.GraphicTrdGameObjectPools[0][index] = gameObject;
    }
    this.poolTrdCounter[0] = colNum;
    this.poolsTrdCounter = 1;
  }

  public void setGraphicImage(
    int graphic,
    int row,
    int col,
    Vector2 pos,
    int yolkid = 0,
    ushort kingdomID = 0,
    byte title = 0)
  {
    if (graphic < 1 || graphic > 42)
    {
      if ((UnityEngine.Object) this.GraphicGameObject[col][row] != (UnityEngine.Object) null)
      {
        this.GraphicGameObject[col][row].SetActive(false);
        for (int index = 0; index < this.poolsCounter; ++index)
        {
          if (this.poolCounter[index] < this.GraphicGameObjectPools[index].Length)
          {
            this.GraphicGameObjectPools[index][this.poolCounter[index]] = this.GraphicGameObject[col][row];
            this.GraphicImagePools[index][this.poolCounter[index]] = this.GraphicImage[col][row];
            this.GraphicRectTransformPools[index][this.poolCounter[index]] = this.GraphicRectTransform[col][row];
            this.GraphicGameObject[col][row] = (GameObject) null;
            this.GraphicImage[col][row] = (WorldMapGraphicImage) null;
            this.GraphicRectTransform[col][row] = (RectTransform) null;
            ++this.poolCounter[index];
            break;
          }
        }
        this.HeightOffset[col][row].y = 0.0f;
      }
      if ((UnityEngine.Object) this.GraphicExGameObject[col][row] != (UnityEngine.Object) null)
      {
        this.GraphicExGameObject[col][row].SetActive(false);
        for (int index = 0; index < this.poolsExCounter; ++index)
        {
          if (this.poolExCounter[index] < this.GraphicExGameObjectPools[index].Length)
          {
            this.GraphicExGameObjectPools[index][this.poolExCounter[index]] = this.GraphicExGameObject[col][row];
            this.GraphicExImagePools[index][this.poolExCounter[index]] = this.GraphicExImage[col][row];
            this.GraphicExRectTransformPools[index][this.poolExCounter[index]] = this.GraphicExRectTransform[col][row];
            this.GraphicExGameObject[col][row] = (GameObject) null;
            this.GraphicExImage[col][row] = (WorldMapGraphicImage) null;
            this.GraphicExRectTransform[col][row] = (RectTransform) null;
            ++this.poolExCounter[index];
            break;
          }
        }
        this.HeightExOffset[col][row] = Vector2.zero;
      }
      if (!((UnityEngine.Object) this.GraphicTrdGameObject[col][row] != (UnityEngine.Object) null))
        return;
      this.GraphicTrdGameObject[col][row].SetActive(false);
      for (int index = 0; index < this.poolsTrdCounter; ++index)
      {
        if (this.poolTrdCounter[index] < this.GraphicTrdGameObjectPools[index].Length)
        {
          this.GraphicTrdGameObjectPools[index][this.poolTrdCounter[index]] = this.GraphicTrdGameObject[col][row];
          this.GraphicTrdImagePools[index][this.poolTrdCounter[index]] = this.GraphicTrdImage[col][row];
          this.GraphicTrdRectTransformPools[index][this.poolTrdCounter[index]] = this.GraphicTrdRectTransform[col][row];
          this.GraphicTrdGameObject[col][row] = (GameObject) null;
          this.GraphicTrdImage[col][row] = (WorldMapGraphicImage) null;
          this.GraphicTrdRectTransform[col][row] = (RectTransform) null;
          ++this.poolTrdCounter[index];
          break;
        }
      }
      this.HeightTrdOffset[col][row] = Vector2.zero;
    }
    else
    {
      int num1 = graphic & 3;
      int num2 = graphic & 12;
      int num3 = graphic & 48;
      if (num1 > 0)
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
              this.GraphicImagePools[index1][this.poolCounter[index1]] = (WorldMapGraphicImage) null;
              this.GraphicRectTransformPools[index1][this.poolCounter[index1]] = (RectTransform) null;
              break;
            }
          }
          if (index1 == this.poolsCounter)
          {
            this.GraphicGameObjectPools[index1] = new GameObject[this.GraphicGameObjectPools[0].Length];
            this.GraphicImagePools[index1] = new WorldMapGraphicImage[this.GraphicImagePools[0].Length];
            this.GraphicRectTransformPools[index1] = new RectTransform[this.GraphicRectTransformPools[0].Length];
            for (int index2 = 0; index2 < this.GraphicGameObjectPools[index1].Length; ++index2)
            {
              GameObject gameObject = new GameObject(nameof (graphic));
              gameObject.SetActive(false);
              this.GraphicImagePools[index1][index2] = gameObject.AddComponent<WorldMapGraphicImage>();
              ((MaskableGraphic) this.GraphicImagePools[index1][index2]).material = this.GraphicSpriteMaterial;
              this.GraphicRectTransformPools[index1][index2] = gameObject.transform as RectTransform;
              this.GraphicRectTransformPools[index1][index2].sizeDelta = this.inisize;
              ((Transform) this.GraphicRectTransformPools[index1][index2]).localPosition = this.inipos;
              ((Transform) this.GraphicRectTransformPools[index1][index2]).localScale = Vector3.one * this.BaseScale * 1f;
              ((Transform) this.GraphicRectTransformPools[index1][index2]).SetParent(this.G1, false);
              this.GraphicGameObjectPools[index1][index2] = gameObject;
            }
            ++this.poolsCounter;
            this.poolCounter[index1] = this.GraphicGameObjectPools[index1].Length;
            --this.poolCounter[index1];
            this.GraphicGameObject[col][row] = this.GraphicGameObjectPools[index1][this.poolCounter[index1]];
            this.GraphicImage[col][row] = this.GraphicImagePools[index1][this.poolCounter[index1]];
            this.GraphicRectTransform[col][row] = this.GraphicRectTransformPools[index1][this.poolCounter[index1]];
            this.GraphicGameObjectPools[index1][this.poolCounter[index1]] = (GameObject) null;
            this.GraphicImagePools[index1][this.poolCounter[index1]] = (WorldMapGraphicImage) null;
            this.GraphicRectTransformPools[index1][this.poolCounter[index1]] = (RectTransform) null;
          }
          this.GraphicGameObject[col][row].SetActive(true);
        }
        if ((UnityEngine.Object) this.GraphicImage[col][row].sprite != (UnityEngine.Object) this.WorldMapSprites[num1 - 1])
          this.GraphicImage[col][row].sprite = this.WorldMapSprites[num1 - 1];
        this.GraphicImage[col][row].SetNativeSize();
        this.HeightOffset[col][row].y = num1 != 2 ? this.kindomYolkHeight[yolkid] + ((Graphic) this.GraphicImage[col][row]).rectTransform.sizeDelta.y * 0.5f : -50f;
        this.GraphicImage[col][row].kingdomID = kingdomID;
        if ((UnityEngine.Object) this.GraphicGameObject[col][row] != (UnityEngine.Object) null)
          this.GraphicRectTransform[col][row].anchoredPosition = pos + this.HeightOffset[col][row];
      }
      else if ((UnityEngine.Object) this.GraphicGameObject[col][row] != (UnityEngine.Object) null)
      {
        this.GraphicGameObject[col][row].SetActive(false);
        for (int index = 0; index < this.poolsCounter; ++index)
        {
          if (this.poolCounter[index] < this.GraphicGameObjectPools[index].Length)
          {
            this.GraphicGameObjectPools[index][this.poolCounter[index]] = this.GraphicGameObject[col][row];
            this.GraphicImagePools[index][this.poolCounter[index]] = this.GraphicImage[col][row];
            this.GraphicRectTransformPools[index][this.poolCounter[index]] = this.GraphicRectTransform[col][row];
            this.GraphicGameObject[col][row] = (GameObject) null;
            this.GraphicImage[col][row] = (WorldMapGraphicImage) null;
            this.GraphicRectTransform[col][row] = (RectTransform) null;
            ++this.poolCounter[index];
            break;
          }
        }
        this.HeightOffset[col][row].y = 0.0f;
      }
      if (num2 > 0)
      {
        if ((UnityEngine.Object) this.GraphicExGameObject[col][row] == (UnityEngine.Object) null)
        {
          int index3;
          for (index3 = 0; index3 < this.poolsExCounter; ++index3)
          {
            if (this.poolExCounter[index3] > 0)
            {
              --this.poolExCounter[index3];
              this.GraphicExGameObject[col][row] = this.GraphicExGameObjectPools[index3][this.poolExCounter[index3]];
              this.GraphicExImage[col][row] = this.GraphicExImagePools[index3][this.poolExCounter[index3]];
              this.GraphicExRectTransform[col][row] = this.GraphicExRectTransformPools[index3][this.poolExCounter[index3]];
              this.GraphicExGameObjectPools[index3][this.poolExCounter[index3]] = (GameObject) null;
              this.GraphicExImagePools[index3][this.poolExCounter[index3]] = (WorldMapGraphicImage) null;
              this.GraphicExRectTransformPools[index3][this.poolExCounter[index3]] = (RectTransform) null;
              break;
            }
          }
          if (index3 == this.poolsExCounter)
          {
            this.GraphicExGameObjectPools[index3] = new GameObject[this.GraphicExGameObjectPools[0].Length];
            this.GraphicExImagePools[index3] = new WorldMapGraphicImage[this.GraphicExImagePools[0].Length];
            this.GraphicExRectTransformPools[index3] = new RectTransform[this.GraphicExRectTransformPools[0].Length];
            for (int index4 = 0; index4 < this.GraphicExGameObjectPools[index3].Length; ++index4)
            {
              GameObject gameObject = new GameObject("graphicEx");
              gameObject.SetActive(false);
              this.GraphicExImagePools[index3][index4] = gameObject.AddComponent<WorldMapGraphicImage>();
              ((MaskableGraphic) this.GraphicExImagePools[index3][index4]).material = this.GraphicSpriteMaterial;
              this.GraphicExRectTransformPools[index3][index4] = gameObject.transform as RectTransform;
              this.GraphicExRectTransformPools[index3][index4].sizeDelta = this.inisize;
              ((Transform) this.GraphicExRectTransformPools[index3][index4]).localPosition = this.inipos;
              ((Transform) this.GraphicExRectTransformPools[index3][index4]).localScale = Vector3.one * this.BaseScale * 1f;
              ((Transform) this.GraphicExRectTransformPools[index3][index4]).SetParent(this.G2, false);
              this.GraphicExGameObjectPools[index3][index4] = gameObject;
            }
            ++this.poolsExCounter;
            this.poolExCounter[index3] = this.GraphicExGameObjectPools[index3].Length;
            --this.poolExCounter[index3];
            this.GraphicExGameObject[col][row] = this.GraphicExGameObjectPools[index3][this.poolExCounter[index3]];
            this.GraphicExImage[col][row] = this.GraphicExImagePools[index3][this.poolExCounter[index3]];
            this.GraphicExRectTransform[col][row] = this.GraphicExRectTransformPools[index3][this.poolExCounter[index3]];
            this.GraphicExGameObjectPools[index3][this.poolExCounter[index3]] = (GameObject) null;
            this.GraphicExImagePools[index3][this.poolExCounter[index3]] = (WorldMapGraphicImage) null;
            this.GraphicExRectTransformPools[index3][this.poolExCounter[index3]] = (RectTransform) null;
          }
          this.GraphicExGameObject[col][row].SetActive(true);
        }
        if (num2 == 4)
        {
          if ((UnityEngine.Object) this.GraphicExImage[col][row].sprite != (UnityEngine.Object) this.WorldMapSprites[num2 - 1])
            this.GraphicExImage[col][row].sprite = this.WorldMapSprites[num2 - 1];
          this.GraphicExImage[col][row].SetNativeSize();
          this.HeightExOffset[col][row].y = this.kindomYolkHeight[yolkid] - ((Graphic) this.GraphicExImage[col][row]).rectTransform.sizeDelta.y;
          this.HeightExOffset[col][row].x = 202f;
          if (GUIManager.Instance.IsArabic)
            this.HeightExOffset[col][row].x *= -1f;
          this.GraphicExImage[col][row].kingdomID = kingdomID;
        }
        else
        {
          TitleData recordByKey = DataManager.Instance.TitleDataN.GetRecordByKey((ushort) title);
          if ((UnityEngine.Object) this.GraphicExImage[col][row].sprite != (UnityEngine.Object) this.WorldMapSprites[4 + (int) recordByKey.IconID])
            this.GraphicExImage[col][row].sprite = this.WorldMapSprites[4 + (int) recordByKey.IconID];
          this.GraphicExImage[col][row].SetNativeSize();
          this.HeightExOffset[col][row].y = -145f;
          this.HeightExOffset[col][row].x = -180f;
          if (GUIManager.Instance.IsArabic)
            this.HeightExOffset[col][row].x *= -1f;
          this.GraphicExImage[col][row].kingdomID = (ushort) title;
        }
        if ((UnityEngine.Object) this.GraphicExGameObject[col][row] != (UnityEngine.Object) null)
          this.GraphicExRectTransform[col][row].anchoredPosition = pos + this.HeightExOffset[col][row];
      }
      else if ((UnityEngine.Object) this.GraphicExGameObject[col][row] != (UnityEngine.Object) null)
      {
        this.GraphicExGameObject[col][row].SetActive(false);
        for (int index = 0; index < this.poolsExCounter; ++index)
        {
          if (this.poolExCounter[index] < this.GraphicExGameObjectPools[index].Length)
          {
            this.GraphicExGameObjectPools[index][this.poolExCounter[index]] = this.GraphicExGameObject[col][row];
            this.GraphicExImagePools[index][this.poolExCounter[index]] = this.GraphicExImage[col][row];
            this.GraphicExRectTransformPools[index][this.poolExCounter[index]] = this.GraphicExRectTransform[col][row];
            this.GraphicExGameObject[col][row] = (GameObject) null;
            this.GraphicExImage[col][row] = (WorldMapGraphicImage) null;
            this.GraphicExRectTransform[col][row] = (RectTransform) null;
            ++this.poolExCounter[index];
            break;
          }
        }
        this.HeightExOffset[col][row] = Vector2.zero;
      }
      if (num3 > 0)
      {
        if ((UnityEngine.Object) this.GraphicTrdGameObject[col][row] == (UnityEngine.Object) null)
        {
          int index5;
          for (index5 = 0; index5 < this.poolsTrdCounter; ++index5)
          {
            if (this.poolTrdCounter[index5] > 0)
            {
              --this.poolTrdCounter[index5];
              this.GraphicTrdGameObject[col][row] = this.GraphicTrdGameObjectPools[index5][this.poolTrdCounter[index5]];
              this.GraphicTrdImage[col][row] = this.GraphicTrdImagePools[index5][this.poolTrdCounter[index5]];
              this.GraphicTrdRectTransform[col][row] = this.GraphicTrdRectTransformPools[index5][this.poolTrdCounter[index5]];
              this.GraphicTrdGameObjectPools[index5][this.poolTrdCounter[index5]] = (GameObject) null;
              this.GraphicTrdImagePools[index5][this.poolTrdCounter[index5]] = (WorldMapGraphicImage) null;
              this.GraphicTrdRectTransformPools[index5][this.poolTrdCounter[index5]] = (RectTransform) null;
              break;
            }
          }
          if (index5 == this.poolsTrdCounter)
          {
            this.GraphicTrdGameObjectPools[index5] = new GameObject[this.GraphicTrdGameObjectPools[0].Length];
            this.GraphicTrdImagePools[index5] = new WorldMapGraphicImage[this.GraphicTrdImagePools[0].Length];
            this.GraphicTrdRectTransformPools[index5] = new RectTransform[this.GraphicTrdRectTransformPools[0].Length];
            for (int index6 = 0; index6 < this.GraphicTrdGameObjectPools[index5].Length; ++index6)
            {
              GameObject gameObject = new GameObject("graphicTrd");
              gameObject.SetActive(false);
              this.GraphicTrdImagePools[index5][index6] = gameObject.AddComponent<WorldMapGraphicImage>();
              ((MaskableGraphic) this.GraphicTrdImagePools[index5][index6]).material = this.GraphicSpriteMaterial;
              this.GraphicTrdRectTransformPools[index5][index6] = gameObject.transform as RectTransform;
              this.GraphicTrdRectTransformPools[index5][index6].sizeDelta = this.inisize;
              ((Transform) this.GraphicTrdRectTransformPools[index5][index6]).localPosition = this.inipos;
              ((Transform) this.GraphicTrdRectTransformPools[index5][index6]).localScale = Vector3.one * this.BaseScale * 1f;
              ((Transform) this.GraphicTrdRectTransformPools[index5][index6]).SetParent(this.G3, false);
              this.GraphicTrdGameObjectPools[index5][index6] = gameObject;
            }
            ++this.poolsTrdCounter;
            this.poolTrdCounter[index5] = this.GraphicTrdGameObjectPools[index5].Length;
            --this.poolTrdCounter[index5];
            this.GraphicTrdGameObject[col][row] = this.GraphicTrdGameObjectPools[index5][this.poolTrdCounter[index5]];
            this.GraphicTrdImage[col][row] = this.GraphicTrdImagePools[index5][this.poolTrdCounter[index5]];
            this.GraphicTrdRectTransform[col][row] = this.GraphicTrdRectTransformPools[index5][this.poolTrdCounter[index5]];
            this.GraphicTrdGameObjectPools[index5][this.poolTrdCounter[index5]] = (GameObject) null;
            this.GraphicTrdImagePools[index5][this.poolTrdCounter[index5]] = (WorldMapGraphicImage) null;
            this.GraphicTrdRectTransformPools[index5][this.poolTrdCounter[index5]] = (RectTransform) null;
          }
          this.GraphicTrdGameObject[col][row].SetActive(true);
        }
        if (num3 == 16)
        {
          if ((UnityEngine.Object) this.GraphicTrdImage[col][row].sprite != (UnityEngine.Object) this.WorldMapSprites[44])
            this.GraphicTrdImage[col][row].sprite = this.WorldMapSprites[44];
          this.GraphicTrdImage[col][row].SetNativeSize();
          this.HeightTrdOffset[col][row].y = (float) ((double) this.kindomYolkHeight[yolkid] - (double) ((Graphic) this.GraphicTrdImage[col][row]).rectTransform.sizeDelta.y + 10.0);
          this.GraphicTrdImage[col][row].kingdomID = kingdomID;
        }
        else
        {
          DataManager.Instance.TitleDataN.GetRecordByKey((ushort) title);
          if ((UnityEngine.Object) this.GraphicTrdImage[col][row].sprite != (UnityEngine.Object) this.WorldMapSprites[45])
            this.GraphicTrdImage[col][row].sprite = this.WorldMapSprites[45];
          this.GraphicTrdImage[col][row].SetNativeSize();
          this.HeightTrdOffset[col][row].y = (float) ((double) this.kindomYolkHeight[yolkid] - (double) ((Graphic) this.GraphicTrdImage[col][row]).rectTransform.sizeDelta.y + 10.0);
          this.GraphicTrdImage[col][row].kingdomID = (ushort) title;
        }
        if (!((UnityEngine.Object) this.GraphicTrdGameObject[col][row] != (UnityEngine.Object) null))
          return;
        this.GraphicTrdRectTransform[col][row].anchoredPosition = pos + this.HeightTrdOffset[col][row];
      }
      else
      {
        if (!((UnityEngine.Object) this.GraphicTrdGameObject[col][row] != (UnityEngine.Object) null))
          return;
        this.GraphicTrdGameObject[col][row].SetActive(false);
        for (int index = 0; index < this.poolsTrdCounter; ++index)
        {
          if (this.poolTrdCounter[index] < this.GraphicTrdGameObjectPools[index].Length)
          {
            this.GraphicTrdGameObjectPools[index][this.poolTrdCounter[index]] = this.GraphicTrdGameObject[col][row];
            this.GraphicTrdImagePools[index][this.poolTrdCounter[index]] = this.GraphicTrdImage[col][row];
            this.GraphicTrdRectTransformPools[index][this.poolTrdCounter[index]] = this.GraphicTrdRectTransform[col][row];
            this.GraphicTrdGameObject[col][row] = (GameObject) null;
            this.GraphicTrdImage[col][row] = (WorldMapGraphicImage) null;
            this.GraphicTrdRectTransform[col][row] = (RectTransform) null;
            ++this.poolTrdCounter[index];
            break;
          }
        }
        this.HeightTrdOffset[col][row] = Vector2.zero;
      }
    }
  }

  public void setGraphicImage(int row, int col, Vector2 pos)
  {
    if ((UnityEngine.Object) this.GraphicGameObject[col][row] != (UnityEngine.Object) null)
      this.GraphicRectTransform[col][row].anchoredPosition = pos + this.HeightOffset[col][row];
    if ((UnityEngine.Object) this.GraphicExGameObject[col][row] != (UnityEngine.Object) null)
      this.GraphicExRectTransform[col][row].anchoredPosition = pos + this.HeightExOffset[col][row];
    if (!((UnityEngine.Object) this.GraphicTrdGameObject[col][row] != (UnityEngine.Object) null))
      return;
    this.GraphicTrdRectTransform[col][row].anchoredPosition = pos + this.HeightTrdOffset[col][row];
  }

  public void reflashGraphicImage()
  {
    for (int index1 = 0; index1 < this.GraphicExGameObject.Length; ++index1)
    {
      for (int index2 = 0; index2 < this.GraphicExGameObject[index1].Length; ++index2)
      {
        if ((UnityEngine.Object) this.GraphicExGameObject[index1][index2] != (UnityEngine.Object) null && (UnityEngine.Object) this.GraphicExImage[index1][index2].sprite == (UnityEngine.Object) this.WorldMapSprites[3])
        {
          this.GraphicExGameObject[index1][index2].SetActive(false);
          for (int index3 = 0; index3 < this.poolsExCounter; ++index3)
          {
            if (this.poolExCounter[index3] < this.GraphicExGameObjectPools[index3].Length)
            {
              this.GraphicExGameObjectPools[index3][this.poolExCounter[index3]] = this.GraphicExGameObject[index1][index2];
              this.GraphicExImagePools[index3][this.poolExCounter[index3]] = this.GraphicExImage[index1][index2];
              this.GraphicExRectTransformPools[index3][this.poolExCounter[index3]] = this.GraphicExRectTransform[index1][index2];
              this.GraphicExGameObject[index1][index2] = (GameObject) null;
              this.GraphicExImage[index1][index2] = (WorldMapGraphicImage) null;
              this.GraphicExRectTransform[index1][index2] = (RectTransform) null;
              ++this.poolExCounter[index3];
              break;
            }
          }
          this.HeightExOffset[index1][index2] = Vector2.zero;
        }
      }
    }
  }
}
