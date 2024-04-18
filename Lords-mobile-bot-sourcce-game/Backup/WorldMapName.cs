// Decompiled with JetBrains decompiler
// Type: WorldMapName
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class WorldMapName
{
  public const float NamePosX = 128f;
  public const float MyPosY = 0.0f;
  public const float notMyPosY = -20f;
  public const float MySizeW = 512f;
  public const float MySizeH = 215f;
  public const float notMySizeH = 178f;
  public Transform BloodNameLayout;
  private Texture2D NameTex;
  private Sprite NameSprite;
  private Vector2 NameImageSize = new Vector2(0.0f, 34f);
  private Vector2 NameTextSize = new Vector2(512f, 118f);
  private Vector2 NameTextOffset = new Vector2(0.0f, -85f);
  private Vector3 iniNamePos = new Vector3(0.0f, 1024f, 0.0f);
  private Image myPosImage;
  private Sprite myPosSprite;
  private Material myPosMaterial;
  private GameObject myPosGameObject;
  private RectTransform myPosRectTransform;
  private float myPosImageSpeed = 25f;
  private float myPosImagePosY = 58f;
  private WorldKingdomName[][] PointName;
  private WorldKingdomName[][] PointNamePools;
  private int[] PointPoolCounter;
  private int PointPoolsCounter;

  public WorldMapName(Transform totalityGroup, UISpritesArray tileSprites)
  {
    this.BloodNameLayout = new GameObject("WorldMapNameName").transform;
    this.BloodNameLayout.position = Vector3.forward * 1664f;
    this.BloodNameLayout.SetParent(totalityGroup, false);
    Color color = new Color(0.0f, 0.0f, 0.0f, 0.3f);
    this.NameTex = new Texture2D(2, 2);
    int y = 0;
    for (; y < this.NameTex.height; ++y)
    {
      for (int x = 0; x < this.NameTex.width; ++x)
        this.NameTex.SetPixel(x, y, color);
    }
    this.NameTex.Apply();
    this.NameSprite = Sprite.Create(this.NameTex, new Rect(0.0f, 0.0f, 2f, 2f), new Vector2(0.5f, 0.5f));
    this.PointPoolsCounter = 0;
    this.myPosSprite = tileSprites.GetSprite(0);
    this.myPosMaterial = new Material(((MaskableGraphic) tileSprites.m_Image).material);
    this.myPosMaterial.renderQueue = 2800;
  }

  public void OnDestroy()
  {
    if ((UnityEngine.Object) this.NameTex != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.NameTex);
    this.NameTex = (Texture2D) null;
    if (this.PointName != null)
    {
      for (int index1 = 0; index1 < this.PointName.Length; ++index1)
      {
        if (this.PointName[index1] != null)
        {
          for (int index2 = 0; index2 < this.PointName[index1].Length; ++index2)
          {
            if (this.PointName[index1][index2] != null)
              this.PointName[index1][index2].Release();
          }
          Array.Clear((Array) this.PointName[index1], 0, this.PointName[index1].Length);
          this.PointName[index1] = (WorldKingdomName[]) null;
        }
      }
      this.PointName = (WorldKingdomName[][]) null;
    }
    if (this.PointNamePools != null)
    {
      for (int index3 = 0; index3 < this.PointNamePools.Length; ++index3)
      {
        if (this.PointNamePools[index3] != null)
        {
          for (int index4 = 0; index4 < this.PointNamePools[index3].Length; ++index4)
          {
            if (this.PointNamePools[index3][index4] != null)
              this.PointNamePools[index3][index4].Release();
          }
          Array.Clear((Array) this.PointNamePools[index3], 0, this.PointNamePools[index3].Length);
          this.PointNamePools[index3] = (WorldKingdomName[]) null;
        }
      }
      this.PointNamePools = (WorldKingdomName[][]) null;
    }
    if (this.PointPoolCounter != null)
    {
      Array.Clear((Array) this.PointPoolCounter, 0, this.PointPoolCounter.Length);
      this.PointPoolCounter = (int[]) null;
    }
    if ((UnityEngine.Object) this.BloodNameLayout != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.BloodNameLayout);
    this.BloodNameLayout = (Transform) null;
  }

  public void IniName(int rowNum, int colNum, float tileBaseScale)
  {
    this.PointName = new WorldKingdomName[colNum][];
    for (int index = 0; index < colNum; ++index)
    {
      this.PointName[index] = new WorldKingdomName[rowNum];
      Array.Clear((Array) this.PointName[index], 0, this.PointName[index].Length);
    }
    this.PointNamePools = new WorldKingdomName[rowNum][];
    this.PointPoolCounter = new int[rowNum];
    Array.Clear((Array) this.PointNamePools, 0, this.PointNamePools.Length);
    for (int index = 0; index < this.PointPoolCounter.Length; ++index)
      this.PointPoolCounter[index] = -1;
    this.PointNamePools[0] = new WorldKingdomName[colNum];
    for (int index = 0; index < this.PointNamePools[0].Length; ++index)
      this.PointNamePools[0][index] = new WorldKingdomName(this.BloodNameLayout, (Vector2) this.iniNamePos, this.NameTextSize);
    this.PointPoolCounter[0] = colNum;
    this.PointPoolsCounter = 1;
    this.myPosGameObject = new GameObject("myKingdom");
    this.myPosGameObject.SetActive(false);
    this.myPosImage = this.myPosGameObject.AddComponent<Image>();
    ((MaskableGraphic) this.myPosImage).material = this.myPosMaterial;
    this.myPosImage.sprite = this.myPosSprite;
    this.myPosImage.SetNativeSize();
    this.myPosRectTransform = this.myPosGameObject.transform as RectTransform;
    ((Transform) this.myPosRectTransform).localScale = Vector3.one * tileBaseScale;
    this.myPosRectTransform.anchoredPosition = new Vector2(-103f, 68f);
    ((Transform) this.myPosRectTransform).SetParent(this.BloodNameLayout, false);
  }

  public void setName(byte SetKingdomTableID, int row, int col, Color textcolor, Vector2 pos)
  {
    if ((int) SetKingdomTableID >= DataManager.MapDataController.WorldKingdomTable.Length)
    {
      if (this.PointName[col][row] == null)
        return;
      this.PointName[col][row].SetActive(false);
      for (int index = 0; index < this.PointPoolsCounter; ++index)
      {
        if (this.PointPoolCounter[index] < this.PointNamePools[index].Length)
        {
          this.PointNamePools[index][this.PointPoolCounter[index]] = this.PointName[col][row];
          this.PointName[col][row] = (WorldKingdomName) null;
          ++this.PointPoolCounter[index];
          break;
        }
      }
    }
    else
    {
      if (this.PointName[col][row] == null)
      {
        int index1;
        for (index1 = 0; index1 < this.PointPoolsCounter; ++index1)
        {
          if (this.PointPoolCounter[index1] > 0)
          {
            --this.PointPoolCounter[index1];
            this.PointName[col][row] = this.PointNamePools[index1][this.PointPoolCounter[index1]];
            this.PointNamePools[index1][this.PointPoolCounter[index1]] = (WorldKingdomName) null;
            break;
          }
        }
        if (index1 == this.PointPoolsCounter)
        {
          this.PointNamePools[index1] = new WorldKingdomName[this.PointNamePools[0].Length];
          for (int index2 = 0; index2 < this.PointNamePools[index1].Length; ++index2)
            this.PointNamePools[index1][index2] = new WorldKingdomName(this.BloodNameLayout, (Vector2) this.iniNamePos, this.NameTextSize);
          ++this.PointPoolsCounter;
          this.PointPoolCounter[index1] = this.PointNamePools[index1].Length;
          --this.PointPoolCounter[index1];
          this.PointName[col][row] = this.PointNamePools[index1][this.PointPoolCounter[index1]];
          this.PointNamePools[index1][this.PointPoolCounter[index1]] = (WorldKingdomName) null;
        }
      }
      this.PointName[col][row].SetNameText(row, col);
      if ((int) DataManager.MapDataController.WorldKingdomTable[(int) SetKingdomTableID].kingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
        this.PointName[col][row].updateName(SetKingdomTableID, this.myPosImage, textcolor, pos + this.NameTextOffset);
      else
        this.PointName[col][row].updateName(SetKingdomTableID, (Image) null, textcolor, pos + this.NameTextOffset);
    }
  }

  public void setName(int row, int col, Vector2 pos)
  {
    if (this.PointName[col][row] == null)
      return;
    this.PointName[col][row].updateName(pos + this.NameTextOffset);
  }

  public void myPosImageRun()
  {
    // ISSUE: unable to decompile the method.
  }

  public void WorldKingdomNameRebuilt()
  {
    if (this.PointName == null)
      return;
    for (int index1 = 0; index1 < this.PointName.Length; ++index1)
    {
      if (this.PointName[index1] != null)
      {
        for (int index2 = 0; index2 < this.PointName[index1].Length; ++index2)
        {
          if (this.PointName[index1][index2] != null)
            this.PointName[index1][index2].NameTextRebuilt();
        }
      }
    }
  }

  public void SetTimeText()
  {
    if (this.PointName == null)
      return;
    for (int index1 = 0; index1 < this.PointName.Length; ++index1)
    {
      if (this.PointName[index1] != null)
      {
        for (int index2 = 0; index2 < this.PointName[index1].Length; ++index2)
        {
          if (this.PointName[index1][index2] != null)
            this.PointName[index1][index2].SetTimeText();
        }
      }
    }
  }
}
