// Decompiled with JetBrains decompiler
// Type: WorldMapYolk
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class WorldMapYolk
{
  private const int kingdom = 10;
  private const int YolkSpriteNum = 50;
  private const int TickImageMax = 16;
  public Transform YolkLayout;
  public WorldMapImage tickYolkImage;
  public WorldMapImage[] sheepTickImage;
  public WorldMapImage[] wolfTickImage;
  public int sheepTickImageNum;
  public int wolfTickImageNum;
  private Sprite[] YolkSprite;
  private GameObject[][] YolkGameObject;
  private RectTransform[][] YolkRectTransform;
  private WorldMapImage[][] YolkImage;
  private GameObject[][] YolkGameObjectPools;
  private RectTransform[][] YolkRectTransformPools;
  private WorldMapImage[][] YolkImagePools;
  private int[] poolCounter;
  private int poolsCounter;
  private Material YolkImageMaterial;
  private float BaseScale;
  private Vector2 YolkImageOffset = new Vector2(70.7f, -5.4f);
  private Vector2 inisize = new Vector2(52f, 29f);
  private Vector3 inipos = new Vector3(0.0f, 1024f, 0.0f);
  private float tickspeed = 2.15f;
  private Color tickYolkImageColor = Color.black;
  private Color sheepTickYolkImageColor = Color.black;
  private Color wolfTickYolkImageColor = Color.black;

  public WorldMapYolk(Transform totalityGroup, UISpritesArray tileSprites)
  {
    this.YolkSprite = new Sprite[50];
    for (int index = 0; index < this.YolkSprite.Length; ++index)
      this.YolkSprite[index] = tileSprites.GetSprite(10 + index);
    this.YolkLayout = new GameObject("MapTileYolk").transform;
    this.YolkLayout.position = Vector3.forward * 1920f;
    this.YolkLayout.SetParent(totalityGroup, false);
    this.poolsCounter = 0;
    this.sheepTickImage = new WorldMapImage[16];
    this.wolfTickImage = new WorldMapImage[16];
  }

  public void OnDestroy()
  {
    if (this.wolfTickImage != null)
    {
      for (int index = 0; index < this.wolfTickImage.Length; ++index)
        this.wolfTickImage[index] = (WorldMapImage) null;
      this.wolfTickImage = (WorldMapImage[]) null;
    }
    if (this.sheepTickImage != null)
    {
      for (int index = 0; index < this.sheepTickImage.Length; ++index)
        this.sheepTickImage[index] = (WorldMapImage) null;
      this.sheepTickImage = (WorldMapImage[]) null;
    }
    if (this.YolkGameObject != null)
    {
      for (int index = 0; index < this.YolkGameObject.Length; ++index)
      {
        Array.Clear((Array) this.YolkGameObject[index], 0, this.YolkGameObject[index].Length);
        this.YolkGameObject[index] = (GameObject[]) null;
      }
    }
    if (this.YolkRectTransform != null)
    {
      for (int index = 0; index < this.YolkRectTransform.Length; ++index)
      {
        Array.Clear((Array) this.YolkRectTransform[index], 0, this.YolkRectTransform[index].Length);
        this.YolkRectTransform[index] = (RectTransform[]) null;
      }
    }
    if (this.YolkImage != null)
    {
      for (int index = 0; index < this.YolkImage.Length; ++index)
      {
        Array.Clear((Array) this.YolkImage[index], 0, this.YolkImage[index].Length);
        this.YolkImage[index] = (WorldMapImage[]) null;
      }
    }
    if (this.YolkGameObjectPools != null)
    {
      for (int index = 0; index < this.YolkGameObjectPools.Length; ++index)
      {
        if (this.YolkGameObjectPools[index] != null)
        {
          Array.Clear((Array) this.YolkGameObjectPools[index], 0, this.YolkGameObjectPools[index].Length);
          this.YolkGameObjectPools[index] = (GameObject[]) null;
        }
      }
    }
    if (this.YolkRectTransformPools != null)
    {
      for (int index = 0; index < this.YolkRectTransformPools.Length; ++index)
      {
        if (this.YolkRectTransformPools[index] != null)
        {
          Array.Clear((Array) this.YolkRectTransformPools[index], 0, this.YolkRectTransformPools[index].Length);
          this.YolkRectTransformPools[index] = (RectTransform[]) null;
        }
      }
    }
    if (this.YolkImagePools != null)
    {
      for (int index = 0; index < this.YolkImagePools.Length; ++index)
      {
        if (this.YolkImagePools[index] != null)
        {
          Array.Clear((Array) this.YolkImagePools[index], 0, this.YolkImagePools[index].Length);
          this.YolkImagePools[index] = (WorldMapImage[]) null;
        }
      }
    }
    if (this.poolCounter != null)
    {
      Array.Clear((Array) this.poolCounter, 0, this.poolCounter.Length);
      this.poolCounter = (int[]) null;
    }
    Array.Clear((Array) this.YolkSprite, 0, this.YolkSprite.Length);
    if ((UnityEngine.Object) this.YolkLayout != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.YolkLayout);
    this.YolkLayout = (Transform) null;
  }

  public void IniYolkImag(int rowNum, int colNum, float tileBaseScale, Material imageMaterial)
  {
    this.YolkGameObject = new GameObject[colNum][];
    this.YolkRectTransform = new RectTransform[colNum][];
    this.YolkImage = new WorldMapImage[colNum][];
    for (int index = 0; index < colNum; ++index)
    {
      this.YolkGameObject[index] = new GameObject[rowNum];
      this.YolkRectTransform[index] = new RectTransform[rowNum];
      this.YolkImage[index] = new WorldMapImage[rowNum];
      Array.Clear((Array) this.YolkGameObject[index], 0, this.YolkGameObject[index].Length);
      Array.Clear((Array) this.YolkRectTransform[index], 0, this.YolkRectTransform[index].Length);
      Array.Clear((Array) this.YolkImage[index], 0, this.YolkImage[index].Length);
    }
    Shader shader = (Shader) null;
    for (int index = 0; index < AssetManager.Instance.Shaders.Length; ++index)
    {
      if (AssetManager.Instance.Shaders[index].name == "zTWRD2 Shaders/UI/Sprites Alpha R High Light")
      {
        shader = (Shader) AssetManager.Instance.Shaders[index];
        break;
      }
    }
    this.YolkImageMaterial = new Material(imageMaterial);
    this.YolkImageMaterial.shader = shader;
    this.BaseScale = tileBaseScale;
    this.YolkGameObjectPools = new GameObject[rowNum][];
    this.YolkRectTransformPools = new RectTransform[rowNum][];
    this.YolkImagePools = new WorldMapImage[rowNum][];
    this.poolCounter = new int[rowNum];
    Array.Clear((Array) this.YolkGameObjectPools, 0, this.YolkGameObjectPools.Length);
    Array.Clear((Array) this.YolkRectTransformPools, 0, this.YolkRectTransformPools.Length);
    Array.Clear((Array) this.YolkImagePools, 0, this.YolkImagePools.Length);
    for (int index = 0; index < this.poolCounter.Length; ++index)
      this.poolCounter[index] = -1;
    this.YolkGameObjectPools[0] = new GameObject[colNum];
    this.YolkImagePools[0] = new WorldMapImage[colNum];
    this.YolkRectTransformPools[0] = new RectTransform[colNum];
    for (int index = 0; index < this.YolkGameObjectPools[0].Length; ++index)
    {
      GameObject gameObject = new GameObject("yolk");
      gameObject.SetActive(false);
      this.YolkImagePools[0][index] = gameObject.AddComponent<WorldMapImage>();
      ((MaskableGraphic) this.YolkImagePools[0][index]).material = this.YolkImageMaterial;
      ((Graphic) this.YolkImagePools[0][index]).color = Color.black;
      this.YolkRectTransformPools[0][index] = gameObject.transform as RectTransform;
      this.YolkRectTransformPools[0][index].sizeDelta = this.inisize;
      ((Transform) this.YolkRectTransformPools[0][index]).localPosition = this.inipos;
      ((Transform) this.YolkRectTransformPools[0][index]).localScale = Vector3.one * tileBaseScale;
      ((Transform) this.YolkRectTransformPools[0][index]).SetParent(this.YolkLayout, false);
      this.YolkGameObjectPools[0][index] = gameObject;
    }
    this.poolCounter[0] = colNum;
    this.poolsCounter = 1;
  }

  public void setYolkImage(int kingdomid, int row, int col, Vector2 pos)
  {
    if (kingdomid < 0)
    {
      if (!((UnityEngine.Object) this.YolkGameObject[col][row] != (UnityEngine.Object) null))
        return;
      if ((UnityEngine.Object) this.tickYolkImage != (UnityEngine.Object) null && this.tickYolkImage.col == col && this.tickYolkImage.row == row)
        this.tickYolkImage = (WorldMapImage) null;
      if (this.sheepTickImageNum > 0 && this.sheepTickImage != null)
      {
        for (int index = 0; index < this.sheepTickImageNum; ++index)
        {
          if ((UnityEngine.Object) this.sheepTickImage[index] != (UnityEngine.Object) null && this.sheepTickImage[index].col == col && this.sheepTickImage[index].row == row)
          {
            --this.sheepTickImageNum;
            ((Graphic) this.sheepTickImage[index]).color = Color.black;
            this.sheepTickImage[index] = this.sheepTickImage[this.sheepTickImageNum];
            this.sheepTickImage[this.sheepTickImageNum] = (WorldMapImage) null;
            break;
          }
        }
      }
      if (this.wolfTickImageNum > 0 && this.wolfTickImage != null)
      {
        for (int index = 0; index < this.wolfTickImageNum; ++index)
        {
          if ((UnityEngine.Object) this.wolfTickImage[index] != (UnityEngine.Object) null && this.wolfTickImage[index].col == col && this.wolfTickImage[index].row == row)
          {
            --this.wolfTickImageNum;
            ((Graphic) this.wolfTickImage[index]).color = Color.black;
            this.wolfTickImage[index] = this.wolfTickImage[this.wolfTickImageNum];
            this.wolfTickImage[this.wolfTickImageNum] = (WorldMapImage) null;
            break;
          }
        }
      }
      this.YolkGameObject[col][row].SetActive(false);
      for (int index = 0; index < this.poolsCounter; ++index)
      {
        if (this.poolCounter[index] < this.YolkGameObjectPools[index].Length)
        {
          this.YolkGameObjectPools[index][this.poolCounter[index]] = this.YolkGameObject[col][row];
          ((Graphic) this.YolkImage[col][row]).color = Color.black;
          this.YolkImagePools[index][this.poolCounter[index]] = this.YolkImage[col][row];
          this.YolkRectTransformPools[index][this.poolCounter[index]] = this.YolkRectTransform[col][row];
          this.YolkGameObject[col][row] = (GameObject) null;
          this.YolkImage[col][row] = (WorldMapImage) null;
          this.YolkRectTransform[col][row] = (RectTransform) null;
          ++this.poolCounter[index];
          break;
        }
      }
    }
    else
    {
      if ((UnityEngine.Object) this.YolkGameObject[col][row] == (UnityEngine.Object) null)
      {
        int index1;
        for (index1 = 0; index1 < this.poolsCounter; ++index1)
        {
          if (this.poolCounter[index1] > 0)
          {
            --this.poolCounter[index1];
            this.YolkGameObject[col][row] = this.YolkGameObjectPools[index1][this.poolCounter[index1]];
            this.YolkImage[col][row] = this.YolkImagePools[index1][this.poolCounter[index1]];
            this.YolkRectTransform[col][row] = this.YolkRectTransformPools[index1][this.poolCounter[index1]];
            this.YolkGameObjectPools[index1][this.poolCounter[index1]] = (GameObject) null;
            this.YolkImagePools[index1][this.poolCounter[index1]] = (WorldMapImage) null;
            this.YolkRectTransformPools[index1][this.poolCounter[index1]] = (RectTransform) null;
            break;
          }
        }
        if (index1 == this.poolsCounter)
        {
          this.YolkGameObjectPools[index1] = new GameObject[this.YolkGameObjectPools[0].Length];
          this.YolkImagePools[index1] = new WorldMapImage[this.YolkGameObjectPools[0].Length];
          this.YolkRectTransformPools[index1] = new RectTransform[this.YolkGameObjectPools[0].Length];
          for (int index2 = 0; index2 < this.YolkGameObjectPools[index1].Length; ++index2)
          {
            GameObject gameObject = new GameObject("yolk");
            gameObject.SetActive(false);
            this.YolkImagePools[index1][index2] = gameObject.AddComponent<WorldMapImage>();
            ((MaskableGraphic) this.YolkImagePools[index1][index2]).material = this.YolkImageMaterial;
            ((Graphic) this.YolkImagePools[index1][index2]).color = Color.black;
            this.YolkRectTransformPools[index1][index2] = gameObject.transform as RectTransform;
            this.YolkRectTransformPools[index1][index2].sizeDelta = this.inisize;
            ((Transform) this.YolkRectTransformPools[index1][index2]).localPosition = this.inipos;
            ((Transform) this.YolkRectTransformPools[index1][index2]).localScale = Vector3.one * this.BaseScale;
            ((Transform) this.YolkRectTransformPools[index1][index2]).SetParent(this.YolkLayout, false);
            this.YolkGameObjectPools[index1][index2] = gameObject;
          }
          ++this.poolsCounter;
          this.poolCounter[index1] = this.YolkGameObjectPools[index1].Length;
          --this.poolCounter[index1];
          this.YolkGameObject[col][row] = this.YolkGameObjectPools[index1][this.poolCounter[index1]];
          this.YolkImage[col][row] = this.YolkImagePools[index1][this.poolCounter[index1]];
          this.YolkRectTransform[col][row] = this.YolkRectTransformPools[index1][this.poolCounter[index1]];
          this.YolkGameObjectPools[index1][this.poolCounter[index1]] = (GameObject) null;
          this.YolkImagePools[index1][this.poolCounter[index1]] = (WorldMapImage) null;
          this.YolkRectTransformPools[index1][this.poolCounter[index1]] = (RectTransform) null;
        }
        this.YolkGameObject[col][row].SetActive(true);
      }
      byte kingdomTableID = 0;
      KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey((ushort) kingdomid);
      byte index3 = (int) recordByKey.mapID < this.YolkSprite.Length ? recordByKey.mapID : (byte) 1;
      if (DataManager.MapDataController.GetWorldKingdomTableID((ushort) kingdomid, out kingdomTableID))
      {
        if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK)
        {
          if (DataManager.MapDataController.WorldKingdomTable[(int) kingdomTableID].kingdomPeriod == KINGDOM_PERIOD.KP_KVK && kingdomid != (int) DataManager.MapDataController.kingdomData.kingdomID && (!ActivityManager.Instance.IsMatchKvk() || ActivityManager.Instance.IsMatchKvk_kingdom((ushort) kingdomid)))
          {
            if ((UnityEngine.Object) this.YolkImage[col][row].sprite != (UnityEngine.Object) this.YolkSprite[0])
              this.YolkImage[col][row].sprite = this.YolkSprite[0];
            EKvKKingdomType kvKkingdomType = ActivityManager.Instance.getKvKKingdomType((ushort) kingdomid);
            int index4 = 0;
            switch (kvKkingdomType)
            {
              case EKvKKingdomType.EKKT_Target:
                for (; index4 < this.wolfTickImageNum; ++index4)
                {
                  if ((UnityEngine.Object) this.wolfTickImage[index4] == (UnityEngine.Object) this.YolkImage[col][row])
                  {
                    --this.wolfTickImageNum;
                    ((Graphic) this.wolfTickImage[index4]).color = Color.black;
                    this.wolfTickImage[index4] = this.wolfTickImage[this.wolfTickImageNum];
                    this.wolfTickImage[this.wolfTickImageNum] = (WorldMapImage) null;
                    break;
                  }
                }
                int index5 = 0;
                while (index5 < this.sheepTickImageNum && !((UnityEngine.Object) this.sheepTickImage[index5] == (UnityEngine.Object) this.YolkImage[col][row]))
                  ++index5;
                if (index5 == this.sheepTickImageNum)
                {
                  this.sheepTickImage[this.sheepTickImageNum] = this.YolkImage[col][row];
                  ((Graphic) this.sheepTickImage[this.sheepTickImageNum]).color = this.sheepTickYolkImageColor;
                  ++this.sheepTickImageNum;
                  break;
                }
                break;
              case EKvKKingdomType.EKKT_Hunter:
                for (; index4 < this.sheepTickImageNum; ++index4)
                {
                  if ((UnityEngine.Object) this.sheepTickImage[index4] == (UnityEngine.Object) this.YolkImage[col][row])
                  {
                    --this.sheepTickImageNum;
                    ((Graphic) this.sheepTickImage[index4]).color = Color.black;
                    this.sheepTickImage[index4] = this.sheepTickImage[this.sheepTickImageNum];
                    this.sheepTickImage[this.sheepTickImageNum] = (WorldMapImage) null;
                    break;
                  }
                }
                int index6 = 0;
                while (index6 < this.wolfTickImageNum && !((UnityEngine.Object) this.wolfTickImage[index6] == (UnityEngine.Object) this.YolkImage[col][row]))
                  ++index6;
                if (index6 == this.wolfTickImageNum)
                {
                  this.wolfTickImage[this.wolfTickImageNum] = this.YolkImage[col][row];
                  ((Graphic) this.wolfTickImage[this.wolfTickImageNum]).color = this.wolfTickYolkImageColor;
                  ++this.wolfTickImageNum;
                  break;
                }
                break;
              default:
                for (; index4 < this.sheepTickImageNum; ++index4)
                {
                  if ((UnityEngine.Object) this.sheepTickImage[index4] == (UnityEngine.Object) this.YolkImage[col][row])
                  {
                    --this.sheepTickImageNum;
                    ((Graphic) this.sheepTickImage[index4]).color = Color.black;
                    this.sheepTickImage[index4] = this.sheepTickImage[this.sheepTickImageNum];
                    this.sheepTickImage[this.sheepTickImageNum] = (WorldMapImage) null;
                    break;
                  }
                }
                if (index4 >= this.sheepTickImageNum)
                {
                  for (int index7 = 0; index7 < this.wolfTickImageNum; ++index7)
                  {
                    if ((UnityEngine.Object) this.wolfTickImage[index7] == (UnityEngine.Object) this.YolkImage[col][row])
                    {
                      --this.wolfTickImageNum;
                      ((Graphic) this.wolfTickImage[index7]).color = Color.black;
                      this.wolfTickImage[index7] = this.wolfTickImage[this.wolfTickImageNum];
                      this.wolfTickImage[this.wolfTickImageNum] = (WorldMapImage) null;
                      break;
                    }
                  }
                  break;
                }
                break;
            }
          }
          else if ((UnityEngine.Object) this.YolkImage[col][row].sprite != (UnityEngine.Object) this.YolkSprite[(int) index3])
          {
            this.YolkImage[col][row].sprite = this.YolkSprite[(int) index3];
            int index8;
            for (index8 = 0; index8 < this.wolfTickImageNum; ++index8)
            {
              if ((UnityEngine.Object) this.wolfTickImage[index8] == (UnityEngine.Object) this.YolkImage[col][row])
              {
                --this.wolfTickImageNum;
                ((Graphic) this.wolfTickImage[index8]).color = Color.black;
                this.wolfTickImage[index8] = this.wolfTickImage[this.wolfTickImageNum];
                this.wolfTickImage[this.wolfTickImageNum] = (WorldMapImage) null;
                break;
              }
            }
            if (index8 >= this.wolfTickImageNum)
            {
              for (int index9 = 0; index9 < this.sheepTickImageNum; ++index9)
              {
                if ((UnityEngine.Object) this.sheepTickImage[index9] == (UnityEngine.Object) this.YolkImage[col][row])
                {
                  --this.sheepTickImageNum;
                  ((Graphic) this.sheepTickImage[index9]).color = Color.black;
                  this.sheepTickImage[index9] = this.sheepTickImage[this.sheepTickImageNum];
                  this.sheepTickImage[this.sheepTickImageNum] = (WorldMapImage) null;
                  break;
                }
              }
            }
          }
        }
        else if ((UnityEngine.Object) this.YolkImage[col][row].sprite != (UnityEngine.Object) this.YolkSprite[(int) index3])
        {
          this.YolkImage[col][row].sprite = this.YolkSprite[(int) index3];
          int index10;
          for (index10 = 0; index10 < this.wolfTickImageNum; ++index10)
          {
            if ((UnityEngine.Object) this.wolfTickImage[index10] == (UnityEngine.Object) this.YolkImage[col][row])
            {
              --this.wolfTickImageNum;
              ((Graphic) this.wolfTickImage[index10]).color = Color.black;
              this.wolfTickImage[index10] = this.wolfTickImage[this.wolfTickImageNum];
              this.wolfTickImage[this.wolfTickImageNum] = (WorldMapImage) null;
              break;
            }
          }
          if (index10 == this.wolfTickImageNum)
          {
            for (int index11 = 0; index11 < this.sheepTickImageNum; ++index11)
            {
              if ((UnityEngine.Object) this.sheepTickImage[index11] == (UnityEngine.Object) this.YolkImage[col][row])
              {
                --this.sheepTickImageNum;
                ((Graphic) this.sheepTickImage[index11]).color = Color.black;
                this.sheepTickImage[index11] = this.sheepTickImage[this.sheepTickImageNum];
                this.sheepTickImage[this.sheepTickImageNum] = (WorldMapImage) null;
                break;
              }
            }
          }
        }
        if (DataManager.MapDataController.WorldKingdomTable[(int) kingdomTableID].kingdomPeriod == KINGDOM_PERIOD.KP_WORLD_WAR)
        {
          if ((UnityEngine.Object) this.tickYolkImage != (UnityEngine.Object) null)
          {
            Color black = Color.black;
            ((Graphic) this.tickYolkImage).color = black;
            this.tickYolkImageColor = black;
          }
          this.tickYolkImage = this.YolkImage[col][row];
        }
        else
        {
          if ((UnityEngine.Object) this.tickYolkImage == (UnityEngine.Object) this.YolkImage[col][row])
            this.tickYolkImage = (WorldMapImage) null;
          ((Graphic) this.YolkImage[col][row]).color = Color.black;
        }
      }
      else if ((UnityEngine.Object) this.YolkImage[col][row].sprite != (UnityEngine.Object) this.YolkSprite[(int) index3])
      {
        this.YolkImage[col][row].sprite = this.YolkSprite[(int) index3];
        ((Graphic) this.YolkImage[col][row]).color = Color.black;
      }
      if ((UnityEngine.Object) this.YolkImage[col][row].sprite == (UnityEngine.Object) null)
        this.YolkImage[col][row].sprite = this.YolkSprite[1];
      this.YolkImage[col][row].SetNativeSize();
      this.YolkImage[col][row].kingdomID = (ushort) kingdomid;
      this.YolkImage[col][row].col = col;
      this.YolkImage[col][row].row = row;
      this.setYolkImage(row, col, pos);
    }
  }

  public void setYolkImage(int row, int col, Vector2 pos)
  {
    if (!((UnityEngine.Object) this.YolkRectTransform[col][row] != (UnityEngine.Object) null))
      return;
    this.YolkRectTransform[col][row].anchoredPosition = pos + Vector2.up * (float) ((double) this.YolkRectTransform[col][row].sizeDelta.y * (double) this.BaseScale - 128.0) * 0.5f;
  }

  public WorldMapImage getYolkImage(int row, int col) => this.YolkImage[col][row];

  public void updateYolkImage()
  {
    float num1 = this.tickspeed * Time.deltaTime;
    float num2 = this.tickspeed * Time.deltaTime;
    this.wolfTickYolkImageColor.r += num2 * 0.239215687f;
    this.wolfTickYolkImageColor.b += num2 * 0.4392157f;
    this.sheepTickYolkImageColor.r += num2 * 0.466666669f;
    if ((double) this.sheepTickYolkImageColor.r <= 0.0 && (double) this.tickspeed < 0.0)
      this.tickspeed *= -1f;
    else if ((double) this.sheepTickYolkImageColor.r >= 0.46666666865348816 && (double) this.tickspeed > 0.0)
      this.tickspeed *= -1f;
    byte kingdomTableID = 0;
    if ((UnityEngine.Object) this.tickYolkImage != (UnityEngine.Object) null && ((Component) this.tickYolkImage).gameObject.activeSelf)
    {
      if (DataManager.MapDataController.GetWorldKingdomTableID(this.tickYolkImage.kingdomID, out kingdomTableID))
      {
        if (((int) DataManager.MapDataController.WorldKingdomTable[(int) kingdomTableID].kingdomFlag & 2) != 0)
        {
          Color color = ((Graphic) this.tickYolkImage).color;
          this.tickYolkImageColor.b = num2;
          this.tickYolkImageColor.g = this.tickYolkImageColor.r = this.tickYolkImageColor.a = 0.0f;
          ((Graphic) this.tickYolkImage).color = color + this.tickYolkImageColor;
        }
        else if ((double) ((Graphic) this.tickYolkImage).color.b > 0.0 && (double) ((Graphic) this.tickYolkImage).color.g == 0.0)
          ((Graphic) this.tickYolkImage).color = Color.black;
      }
      else if ((double) ((Graphic) this.tickYolkImage).color.b > 0.0 && (double) ((Graphic) this.tickYolkImage).color.g == 0.0)
        ((Graphic) this.tickYolkImage).color = Color.black;
    }
    if (this.wolfTickImage != null && this.wolfTickImageNum > 0)
    {
      for (int index = 0; index < this.wolfTickImageNum; ++index)
      {
        if ((UnityEngine.Object) this.wolfTickImage[index] != (UnityEngine.Object) null)
          ((Graphic) this.wolfTickImage[index]).color = this.wolfTickYolkImageColor;
      }
    }
    if (this.sheepTickImage == null || this.sheepTickImageNum <= 0)
      return;
    for (int index = 0; index < this.sheepTickImageNum; ++index)
    {
      if ((UnityEngine.Object) this.sheepTickImage[index] != (UnityEngine.Object) null)
        ((Graphic) this.sheepTickImage[index]).color = this.sheepTickYolkImageColor;
    }
  }
}
