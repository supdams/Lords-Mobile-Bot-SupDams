// Decompiled with JetBrains decompiler
// Type: MapTileBloodName
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class MapTileBloodName
{
  private const int npcnamemax = 128;
  private const int npccitynamemax = 128;
  public static Color[] lineNameColor = new Color[4]
  {
    new Color(0.0f, 1f, 1f),
    new Color(1f, 0.6862745f, 0.0f),
    new Color(1f, 0.0f, 0.117647f),
    new Color(0.0784313f, 0.764706f, 1f)
  };
  public Transform BloodNameLayout;
  private Texture2D NameTex;
  private Sprite NameSprite;
  private Vector2 NameImageSize = new Vector2(0.0f, 34f);
  private Vector2 NameTextSize = new Vector2(256f, 34f);
  private Vector2 NameTextOffset = new Vector2(0.0f, -33.5f);
  private Vector3 iniNamePos = new Vector3(0.0f, 1024f, 0.0f);
  private MapTileName[][] PointName;
  private MapTileName[][] PointNamePools;
  private int[] PointPoolCounter;
  private int PointPoolsCounter;
  private List<MapTileName> LineNamePools = new List<MapTileName>(256);
  private int LinePoolsCounter = 256;
  private Transform NPCBloodLayout;
  private CString npcname = new CString(128);
  private CString npccityname = new CString(128);
  private AssetBundle NPCBloodAB;
  private int NPCBloodABKey;
  private Transform[][] NPCBloodPools;
  private int[] NPCBloodPoolCounter;
  private int NPCBloodPoolsCounter;
  private float[][] NPCBloodValue;
  private float[][] NPCBloodSpeed;
  private float NPCBloodScale = 1.5f;
  private Vector3 NPCBloodpos = new Vector3(-11f, -23f, 0.0f);
  private byte NPCTimeState;
  private CString[] NPCLevelStr;
  private CString NPCTimeStr = new CString(64);
  private CString[][] NPCBloodStr;
  private float NPCBloodStrAlpha = 1f;
  private int maxlevel = 8;
  private float AlphaSpeed = 4f;
  private float maxblood = 86f;
  private float BloodSpeed = 2f;
  private float maxWaiteTimer = 2f;
  private float WaiteTimer;
  private float ChekTimer;
  private float NPCNameOffSet = -14f;
  private float NPCTimeStrXOffSet = 10f;
  private int minTime = 600;
  private Material MapEmojiImageMaterial;

  public MapTileBloodName(Transform realmGroup)
  {
    GUIManager.Instance.EmojiManager.EmojiCenterIni();
    this.NPCBloodAB = GUIManager.Instance.EmojiManager.EmojiAB;
    this.BloodNameLayout = new GameObject(nameof (MapTileBloodName)).transform;
    this.BloodNameLayout.position = Vector3.forward * 2944f;
    this.BloodNameLayout.SetParent(realmGroup, false);
    this.NPCBloodLayout = new GameObject("MapTileNPCBlood").transform;
    this.NPCBloodLayout.position = Vector3.forward * 2944f;
    this.NPCBloodLayout.SetParent(this.BloodNameLayout, false);
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
    this.LinePoolsCounter = 0;
    this.NPCLevelStr = new CString[this.maxlevel];
    this.NPCLevelStr[0] = (CString) null;
    for (int x = 1; x < this.NPCLevelStr.Length; ++x)
    {
      this.NPCLevelStr[x] = new CString(2);
      this.NPCLevelStr[x].ClearString();
      this.NPCLevelStr[x].IntToFormat((long) x);
      this.NPCLevelStr[x].AppendFormat("{0}");
    }
    this.NPCTimeStr.ClearString();
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
          this.PointName[index1] = (MapTileName[]) null;
        }
      }
      this.PointName = (MapTileName[][]) null;
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
          this.PointNamePools[index3] = (MapTileName[]) null;
        }
      }
      this.PointNamePools = (MapTileName[][]) null;
    }
    if (this.PointPoolCounter != null)
    {
      Array.Clear((Array) this.PointPoolCounter, 0, this.PointPoolCounter.Length);
      this.PointPoolCounter = (int[]) null;
    }
    if (this.LineNamePools != null)
    {
      for (int index = 0; index < this.LineNamePools.Count; ++index)
      {
        if (this.LineNamePools[index] != null)
          this.LineNamePools[index].Release();
        this.LineNamePools[index] = (MapTileName) null;
      }
    }
    if (this.NPCBloodPools != null)
    {
      for (int index = 0; index < this.NPCBloodPools.Length; ++index)
      {
        if (this.NPCBloodPools[index] != null)
        {
          Array.Clear((Array) this.NPCBloodPools[index], 0, this.NPCBloodPools[index].Length);
          this.NPCBloodPools[index] = (Transform[]) null;
        }
      }
      this.NPCBloodPools = (Transform[][]) null;
    }
    if (this.NPCBloodPoolCounter != null)
    {
      Array.Clear((Array) this.NPCBloodPoolCounter, 0, this.NPCBloodPoolCounter.Length);
      this.NPCBloodPoolCounter = (int[]) null;
    }
    if (this.NPCBloodValue != null)
    {
      for (int index = 0; index < this.NPCBloodValue.Length; ++index)
        Array.Clear((Array) this.NPCBloodValue[index], 0, this.NPCBloodValue[index].Length);
      this.NPCBloodValue = (float[][]) null;
    }
    if (this.NPCBloodSpeed != null)
    {
      for (int index = 0; index < this.NPCBloodSpeed.Length; ++index)
        Array.Clear((Array) this.NPCBloodSpeed[index], 0, this.NPCBloodSpeed[index].Length);
      this.NPCBloodSpeed = (float[][]) null;
    }
    if (this.NPCLevelStr != null)
    {
      Array.Clear((Array) this.NPCLevelStr, 1, this.NPCLevelStr.Length - 1);
      this.NPCLevelStr = (CString[]) null;
    }
    if (this.NPCBloodStr != null)
    {
      for (int index5 = 0; index5 < this.NPCBloodStr.Length; ++index5)
      {
        for (int index6 = 0; index6 < this.NPCBloodStr[index5].Length; ++index6)
        {
          this.NPCBloodStr[index5][index6].ClearString();
          this.NPCBloodStr[index5][index6] = (CString) null;
        }
        this.NPCBloodStr[index5] = (CString[]) null;
      }
    }
    if ((UnityEngine.Object) this.NPCBloodLayout != (UnityEngine.Object) null)
      this.NPCBloodLayout = (Transform) null;
    if ((UnityEngine.Object) this.BloodNameLayout != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.BloodNameLayout);
    this.BloodNameLayout = (Transform) null;
    this.NPCBloodAB = (AssetBundle) null;
  }

  public void IniName(int rowNum, int colNum)
  {
    this.PointName = new MapTileName[colNum][];
    for (int index = 0; index < colNum; ++index)
    {
      this.PointName[index] = new MapTileName[rowNum];
      Array.Clear((Array) this.PointName[index], 0, this.PointName[index].Length);
    }
    this.PointNamePools = new MapTileName[rowNum][];
    this.PointPoolCounter = new int[rowNum];
    Array.Clear((Array) this.PointNamePools, 0, this.PointNamePools.Length);
    for (int index = 0; index < this.PointPoolCounter.Length; ++index)
      this.PointPoolCounter[index] = -1;
    this.PointNamePools[0] = new MapTileName[colNum];
    for (int index = 0; index < this.PointNamePools[0].Length; ++index)
      this.PointNamePools[0][index] = new MapTileName(this.BloodNameLayout, (Vector2) this.iniNamePos, this.NameTextSize);
    this.PointPoolCounter[0] = colNum;
    this.PointPoolsCounter = 1;
    for (int index = 0; index < this.LinePoolsCounter; ++index)
      this.LineNamePools[index] = new MapTileName(this.BloodNameLayout, (Vector2) this.iniNamePos, this.NameTextSize);
    this.NPCBloodPools = new Transform[rowNum][];
    this.NPCBloodPoolCounter = new int[rowNum];
    Array.Clear((Array) this.NPCBloodPools, 0, this.NPCBloodPools.Length);
    for (int index = 0; index < this.NPCBloodPoolCounter.Length; ++index)
      this.NPCBloodPoolCounter[index] = -1;
    this.NPCBloodPools[0] = new Transform[colNum];
    for (int index = 0; index < this.NPCBloodPools[0].Length; ++index)
    {
      GameObject gameObject = UnityEngine.Object.Instantiate(this.NPCBloodAB.mainAsset) as GameObject;
      this.NPCBloodPools[0][index] = gameObject.transform;
      this.NPCBloodPools[0][index].localScale = Vector3.one * this.NPCBloodScale;
      this.NPCBloodPools[0][index].position = this.NPCBloodpos;
      this.NPCBloodPools[0][index].SetParent(this.NPCBloodLayout, false);
      Text component1 = this.NPCBloodPools[0][index].GetChild(4).GetComponent<Text>();
      component1.font = GUIManager.Instance.GetTTFFont();
      ((MaskableGraphic) component1).material = component1.font.material;
      Text component2 = this.NPCBloodPools[0][index].GetChild(3).GetComponent<Text>();
      component2.font = GUIManager.Instance.GetTTFFont();
      ((MaskableGraphic) component2).material = component2.font.material;
      component2.verticalOverflow = (VerticalWrapMode) 1;
      this.NPCBloodPools[0][index].gameObject.SetActive(false);
    }
    this.NPCBloodPoolCounter[0] = colNum;
    this.NPCBloodPoolsCounter = 1;
    this.NPCBloodValue = new float[rowNum][];
    for (int index = 0; index < this.NPCBloodValue.Length; ++index)
    {
      this.NPCBloodValue[index] = new float[colNum];
      Array.Clear((Array) this.NPCBloodValue[index], 0, this.NPCBloodValue[index].Length);
    }
    this.NPCBloodSpeed = new float[rowNum][];
    for (int index = 0; index < this.NPCBloodSpeed.Length; ++index)
    {
      this.NPCBloodSpeed[index] = new float[colNum];
      Array.Clear((Array) this.NPCBloodSpeed[index], 0, this.NPCBloodSpeed[index].Length);
    }
    this.NPCBloodStr = new CString[rowNum][];
    for (int index1 = 0; index1 < this.NPCBloodStr.Length; ++index1)
    {
      this.NPCBloodStr[index1] = new CString[colNum];
      for (int index2 = 0; index2 < this.NPCBloodStr[index1].Length; ++index2)
        this.NPCBloodStr[index1][index2] = new CString(8);
    }
    this.npccityname.ClearString();
    this.npccityname.Append(DataManager.Instance.mStringTable.GetStringByID(12033U));
  }

  public void setName(
    CString Name,
    CString Tag,
    int row,
    int col,
    Color textcolor,
    Vector2 pos,
    byte npclevel = 0,
    float npcbloods = 0.0f,
    ushort kingdomID = 0,
    CString First = null,
    int emojiID = -1,
    float offsety = 0.0f)
  {
    if ((Name == null || Name.Length == 0) && emojiID == -1)
    {
      if (this.PointName[col][row] == null)
        return;
      this.setName(row, col, (short) -1);
      this.PointName[col][row].SetActive(false);
      if (this.PointName[col][row].bloodtextID > 0)
      {
        Transform child = ((Transform) this.PointName[col][row].NameRectTransform).GetChild(this.PointName[col][row].bloodtextID);
        this.PointName[col][row].bloodtextID = -1;
        for (int index = 0; index < this.NPCBloodPoolsCounter; ++index)
        {
          if (this.NPCBloodPoolCounter[index] < this.NPCBloodPools[index].Length)
          {
            this.NPCBloodPools[index][this.NPCBloodPoolCounter[index]] = child;
            child.SetParent(this.NPCBloodLayout, false);
            ((Graphic) child.GetChild(3).GetComponent<Text>()).color = Color.white;
            child.gameObject.SetActive(false);
            ++this.NPCBloodPoolCounter[index];
            break;
          }
        }
      }
      if (this.PointName[col][row].mapEmoji != null)
      {
        GUIManager.Instance.pushEmojiIcon(this.PointName[col][row].mapEmoji);
        this.PointName[col][row].mapEmoji = (EmojiUnit) null;
      }
      if (this.PointName[col][row].mapEmojiBack != null)
      {
        GUIManager.Instance.pushEmojiIcon(this.PointName[col][row].mapEmojiBack);
        this.PointName[col][row].mapEmojiBack = (EmojiUnit) null;
      }
      for (int index = 0; index < this.PointPoolsCounter; ++index)
      {
        if (this.PointPoolCounter[index] < this.PointNamePools[index].Length)
        {
          this.PointNamePools[index][this.PointPoolCounter[index]] = this.PointName[col][row];
          this.PointName[col][row].NameOffset = 0.0f;
          this.PointName[col][row] = (MapTileName) null;
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
            this.PointNamePools[index1][this.PointPoolCounter[index1]] = (MapTileName) null;
            break;
          }
        }
        if (index1 == this.PointPoolsCounter)
        {
          this.PointNamePools[index1] = new MapTileName[this.PointNamePools[0].Length];
          for (int index2 = 0; index2 < this.PointNamePools[index1].Length; ++index2)
            this.PointNamePools[index1][index2] = new MapTileName(this.BloodNameLayout, (Vector2) this.iniNamePos, this.NameTextSize);
          ++this.PointPoolsCounter;
          this.PointPoolCounter[index1] = this.PointNamePools[index1].Length;
          --this.PointPoolCounter[index1];
          this.PointName[col][row] = this.PointNamePools[index1][this.PointPoolCounter[index1]];
          this.PointNamePools[index1][this.PointPoolCounter[index1]] = (MapTileName) null;
        }
      }
      this.setName(row, col, (short) -1);
      Transform transform = (Transform) null;
      if (npclevel != (byte) 0 && this.PointName[col][row].bloodtextID < 1)
      {
        int index3;
        for (index3 = 0; index3 < this.NPCBloodPoolsCounter; ++index3)
        {
          if (this.NPCBloodPoolCounter[index3] > 0)
          {
            this.PointName[col][row].bloodtextID = ((Transform) this.PointName[col][row].NameRectTransform).childCount;
            --this.NPCBloodPoolCounter[index3];
            this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]].SetParent((Transform) this.PointName[col][row].NameRectTransform, false);
            this.NPCBloodValue[col][row] = 0.0f;
            this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]].GetChild(0).gameObject.SetActive(true);
            this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]].GetChild(2).gameObject.SetActive(false);
            RectTransform component1 = this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]].GetChild(1).GetComponent<RectTransform>();
            ((Component) component1).gameObject.SetActive(true);
            Vector2 sizeDelta = component1.sizeDelta with
            {
              x = (float) ((double) this.maxblood * (double) npcbloods / 100.0)
            };
            component1.sizeDelta = sizeDelta;
            Transform child1 = this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]].GetChild(4);
            child1.gameObject.SetActive(true);
            child1.GetComponent<Text>().text = this.NPCLevelStr[(int) npclevel].ToString();
            Transform child2 = this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]].GetChild(3);
            child2.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.NPCTimeStrXOffSet, 0.0f);
            Text component2 = child2.GetComponent<Text>();
            this.NPCBloodStr[col][row].ClearString();
            this.NPCBloodStr[col][row].FloatToFormat(this.checkNpdBlood(npcbloods), 2);
            if (GUIManager.Instance.IsArabic)
              this.NPCBloodStr[col][row].AppendFormat("%{0}");
            else
              this.NPCBloodStr[col][row].AppendFormat("{0}%");
            ((Graphic) component2).color = Color.white;
            if (this.NPCTimeState == (byte) 0)
            {
              component2.text = this.NPCBloodStr[col][row].ToString();
            }
            else
            {
              if (ActivityManager.Instance.ActivityData[0].EventCountTime < (long) this.minTime)
                ((Graphic) component2).color = Color.yellow;
              component2.text = this.NPCTimeStr.ToString();
            }
            ((Graphic) component2).SetAllDirty();
            component2.cachedTextGenerator.Invalidate();
            this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]].gameObject.SetActive(true);
            this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]] = (Transform) null;
            break;
          }
        }
        if (index3 == this.NPCBloodPoolsCounter)
        {
          this.NPCBloodPools[index3] = new Transform[this.NPCBloodPools[0].Length];
          for (int index4 = 0; index4 < this.NPCBloodPools[index3].Length; ++index4)
          {
            GameObject gameObject = UnityEngine.Object.Instantiate(this.NPCBloodAB.mainAsset) as GameObject;
            this.NPCBloodPools[index3][index4] = gameObject.transform;
            this.NPCBloodPools[index3][index4].localScale = Vector3.one * this.NPCBloodScale;
            this.NPCBloodPools[index3][index4].position = this.NPCBloodpos;
            this.NPCBloodPools[index3][index4].SetParent(this.NPCBloodLayout, false);
            Text component3 = this.NPCBloodPools[index3][index4].GetChild(4).GetComponent<Text>();
            component3.font = GUIManager.Instance.GetTTFFont();
            ((MaskableGraphic) component3).material = component3.font.material;
            Text component4 = this.NPCBloodPools[index3][index4].GetChild(3).GetComponent<Text>();
            component4.font = GUIManager.Instance.GetTTFFont();
            ((MaskableGraphic) component4).material = component4.font.material;
            component4.verticalOverflow = (VerticalWrapMode) 1;
            this.NPCBloodPools[index3][index4].gameObject.SetActive(false);
          }
          this.PointName[col][row].bloodtextID = ((Transform) this.PointName[col][row].NameRectTransform).childCount;
          ++this.NPCBloodPoolsCounter;
          this.NPCBloodPoolCounter[index3] = this.NPCBloodPools[index3].Length;
          --this.NPCBloodPoolCounter[index3];
          this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]].SetParent((Transform) this.PointName[col][row].NameRectTransform, false);
          this.NPCBloodValue[col][row] = 0.0f;
          this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]].GetChild(0).gameObject.SetActive(true);
          this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]].GetChild(2).gameObject.SetActive(false);
          RectTransform component5 = this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]].GetChild(1).GetComponent<RectTransform>();
          ((Component) component5).gameObject.SetActive(true);
          Vector2 sizeDelta = component5.sizeDelta with
          {
            x = (float) ((double) this.maxblood * (double) npcbloods / 100.0)
          };
          component5.sizeDelta = sizeDelta;
          Transform child3 = this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]].GetChild(4);
          child3.gameObject.SetActive(true);
          child3.GetComponent<Text>().text = this.NPCLevelStr[(int) npclevel].ToString();
          Transform child4 = this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]].GetChild(3);
          child4.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.NPCTimeStrXOffSet, 0.0f);
          Text component6 = child4.GetComponent<Text>();
          this.NPCBloodStr[col][row].ClearString();
          this.NPCBloodStr[col][row].FloatToFormat(this.checkNpdBlood(npcbloods), 2);
          if (GUIManager.Instance.IsArabic)
            this.NPCBloodStr[col][row].AppendFormat("%{0}");
          else
            this.NPCBloodStr[col][row].AppendFormat("{0}%");
          ((Graphic) component6).color = Color.white;
          if (this.NPCTimeState == (byte) 0)
          {
            component6.text = this.NPCBloodStr[col][row].ToString();
          }
          else
          {
            if (ActivityManager.Instance.ActivityData[0].EventCountTime < (long) this.minTime)
              ((Graphic) component6).color = Color.yellow;
            component6.text = this.NPCTimeStr.ToString();
          }
          ((Graphic) component6).SetAllDirty();
          component6.cachedTextGenerator.Invalidate();
          this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]].gameObject.SetActive(true);
          this.NPCBloodPools[index3][this.NPCBloodPoolCounter[index3]] = (Transform) null;
        }
        this.PointName[col][row].NameOffset = this.NPCNameOffSet;
      }
      else
      {
        if (npclevel == (byte) 0 && this.PointName[col][row].bloodtextID > 0)
        {
          Transform child = ((Transform) this.PointName[col][row].NameRectTransform).GetChild(this.PointName[col][row].bloodtextID);
          this.PointName[col][row].bloodtextID = -1;
          for (int index = 0; index < this.NPCBloodPoolsCounter; ++index)
          {
            if (this.NPCBloodPoolCounter[index] < this.NPCBloodPools[index].Length)
            {
              this.NPCBloodPools[index][this.NPCBloodPoolCounter[index]] = child;
              child.SetParent(this.NPCBloodLayout, false);
              ((Graphic) child.GetChild(3).GetComponent<Text>()).color = Color.white;
              child.gameObject.SetActive(false);
              transform = (Transform) null;
              ++this.NPCBloodPoolCounter[index];
              break;
            }
          }
        }
        if (this.PointName[col][row].bloodtextID > 0)
        {
          this.PointName[col][row].NameOffset = this.NPCNameOffSet;
          this.NPCBloodValue[col][row] = 0.0f;
          Transform child5 = ((Transform) this.PointName[col][row].NameRectTransform).GetChild(this.PointName[col][row].bloodtextID);
          child5.GetChild(0).gameObject.SetActive(true);
          child5.GetChild(2).gameObject.SetActive(false);
          RectTransform component7 = child5.GetChild(1).GetComponent<RectTransform>();
          ((Component) component7).gameObject.SetActive(true);
          Vector2 sizeDelta = component7.sizeDelta with
          {
            x = (float) ((double) this.maxblood * (double) npcbloods / 100.0)
          };
          component7.sizeDelta = sizeDelta;
          Transform child6 = child5.GetChild(4);
          child6.gameObject.SetActive(true);
          child6.GetComponent<Text>().text = this.NPCLevelStr[(int) npclevel].ToString();
          Transform child7 = child5.GetChild(3);
          child7.GetComponent<RectTransform>().anchoredPosition = new Vector2(this.NPCTimeStrXOffSet, 0.0f);
          Text component8 = child7.GetComponent<Text>();
          this.NPCBloodStr[col][row].ClearString();
          this.NPCBloodStr[col][row].FloatToFormat(this.checkNpdBlood(npcbloods), 2);
          if (GUIManager.Instance.IsArabic)
            this.NPCBloodStr[col][row].AppendFormat("%{0}");
          else
            this.NPCBloodStr[col][row].AppendFormat("{0}%");
          ((Graphic) component8).color = Color.white;
          if (this.NPCTimeState == (byte) 0)
          {
            component8.text = this.NPCBloodStr[col][row].ToString();
          }
          else
          {
            if (ActivityManager.Instance.ActivityData[0].EventCountTime < (long) this.minTime)
              ((Graphic) component8).color = Color.yellow;
            component8.text = this.NPCTimeStr.ToString();
          }
          ((Graphic) component8).SetAllDirty();
          component8.cachedTextGenerator.Invalidate();
        }
        else
          this.PointName[col][row].NameOffset = 0.0f;
      }
      if (emojiID > -1)
      {
        EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey((ushort) emojiID);
        if ((int) recordByKey.EmojiKey == emojiID)
        {
          float num1 = (int) recordByKey.sizeX <= (int) recordByKey.sizeY ? (float) recordByKey.sizeY : (float) recordByKey.sizeX;
          float num2 = ((double) num1 != 0.0 ? num1 * 0.9f + (GUIManager.Instance.EmojiManager != null ? GUIManager.Instance.EmojiManager.basebackoffset : 25f) : (GUIManager.Instance.EmojiManager != null ? GUIManager.Instance.EmojiManager.basebacksize : 73f)) / (GUIManager.Instance.EmojiManager != null ? GUIManager.Instance.EmojiManager.basebacksize : 73f);
          if (this.PointName[col][row].mapEmoji == null)
          {
            this.PointName[col][row].mapEmoji = GUIManager.Instance.pullEmojiIcon(recordByKey.IconID, recordByKey.KeyFrame);
            if ((UnityEngine.Object) this.MapEmojiImageMaterial == (UnityEngine.Object) null)
            {
              this.MapEmojiImageMaterial = new Material(((MaskableGraphic) this.PointName[col][row].mapEmoji.EmojiImage).material);
              this.MapEmojiImageMaterial.renderQueue = 2999;
            }
            ((MaskableGraphic) this.PointName[col][row].mapEmoji.EmojiImage).material = this.MapEmojiImageMaterial;
            this.PointName[col][row].mapEmoji.EmojiTransform.localPosition = new Vector3(0.0f, offsety, 0.0f);
            this.PointName[col][row].mapEmoji.EmojiTransform.localScale = Vector3.one * 0.9f;
            this.PointName[col][row].mapEmoji.EmojiTransform.SetParent((Transform) this.PointName[col][row].NameRectTransform, false);
            this.PointName[col][row].mapEmoji.EmojiTransform.SetAsFirstSibling();
            if (this.PointName[col][row].bloodtextID > 0)
              ++this.PointName[col][row].bloodtextID;
            if (this.PointName[col][row].mapEmojiBack == null)
            {
              this.PointName[col][row].mapEmojiBack = GUIManager.Instance.pullEmojiIcon(ushort.MaxValue, (byte) 0);
              if ((UnityEngine.Object) this.MapEmojiImageMaterial == (UnityEngine.Object) null)
              {
                this.MapEmojiImageMaterial = new Material(((MaskableGraphic) this.PointName[col][row].mapEmojiBack.EmojiImage).material);
                this.MapEmojiImageMaterial.renderQueue = 2999;
              }
              ((MaskableGraphic) this.PointName[col][row].mapEmojiBack.EmojiImage).material = this.MapEmojiImageMaterial;
              if ((double) offsety != 0.0)
                this.PointName[col][row].mapEmojiBack.EmojiTransform.localPosition = new Vector3(0.0f, offsety - 5f, 0.0f);
              this.PointName[col][row].mapEmojiBack.EmojiTransform.localScale = Vector3.one * num2;
              this.PointName[col][row].mapEmojiBack.EmojiTransform.SetParent((Transform) this.PointName[col][row].NameRectTransform, false);
              this.PointName[col][row].mapEmojiBack.EmojiTransform.SetAsFirstSibling();
              if (this.PointName[col][row].bloodtextID > 0)
                ++this.PointName[col][row].bloodtextID;
            }
          }
          else if ((int) this.PointName[col][row].mapEmoji.IconID != (int) recordByKey.IconID)
          {
            GUIManager.Instance.pushEmojiIcon(this.PointName[col][row].mapEmoji);
            this.PointName[col][row].mapEmoji = GUIManager.Instance.pullEmojiIcon(recordByKey.IconID, recordByKey.KeyFrame);
            if ((UnityEngine.Object) this.MapEmojiImageMaterial == (UnityEngine.Object) null)
            {
              this.MapEmojiImageMaterial = new Material(((MaskableGraphic) this.PointName[col][row].mapEmoji.EmojiImage).material);
              this.MapEmojiImageMaterial.renderQueue = 2999;
            }
            ((MaskableGraphic) this.PointName[col][row].mapEmoji.EmojiImage).material = this.MapEmojiImageMaterial;
            this.PointName[col][row].mapEmoji.EmojiTransform.localPosition = new Vector3(0.0f, offsety, 0.0f);
            this.PointName[col][row].mapEmoji.EmojiTransform.localScale = Vector3.one * 0.9f;
            this.PointName[col][row].mapEmoji.EmojiTransform.SetParent((Transform) this.PointName[col][row].NameRectTransform, false);
            this.PointName[col][row].mapEmoji.EmojiTransform.SetAsFirstSibling();
            if ((double) offsety != 0.0)
              this.PointName[col][row].mapEmojiBack.EmojiTransform.localPosition = new Vector3(0.0f, offsety - 5f, 0.0f);
            this.PointName[col][row].mapEmojiBack.EmojiTransform.localScale = Vector3.one * num2;
            this.PointName[col][row].mapEmojiBack.EmojiTransform.SetAsFirstSibling();
          }
        }
      }
      else if (this.PointName[col][row].mapEmoji != null)
      {
        GUIManager.Instance.pushEmojiIcon(this.PointName[col][row].mapEmoji);
        this.PointName[col][row].mapEmoji = (EmojiUnit) null;
        if (this.PointName[col][row].bloodtextID > 0)
          --this.PointName[col][row].bloodtextID;
        if (this.PointName[col][row].mapEmojiBack != null)
        {
          GUIManager.Instance.pushEmojiIcon(this.PointName[col][row].mapEmojiBack);
          this.PointName[col][row].mapEmojiBack = (EmojiUnit) null;
          if (this.PointName[col][row].bloodtextID > 0)
            --this.PointName[col][row].bloodtextID;
        }
      }
      this.PointName[col][row].updateName(Name, Tag, textcolor, pos + this.NameTextOffset, kingdomID, First);
    }
  }

  public void setName(
    ushort NPCNum,
    int row,
    int col,
    Color textcolor,
    Vector2 pos,
    byte npclevel,
    float npcbloods,
    int emojiID = -1,
    CString tag = null,
    short pointID = -1)
  {
    if (this.NPCTimeStr.Length == 0)
    {
      this.NPCTimeStr.ClearString();
      GameConstants.GetTimeString(this.NPCTimeStr, (uint) ActivityManager.Instance.ActivityData[0].EventCountTime, hideTimeIfDays: true, showZeroHour: false);
    }
    MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(NPCNum);
    this.npcname.ClearString();
    this.npcname.Append(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.NameID));
    this.setName(this.npcname, tag, row, col, textcolor, pos, npclevel, npcbloods, (ushort) 0, emojiID: emojiID, offsety: 92f);
    if (tag == null || tag[0] == char.MinValue)
      this.setName(row, col, (short) -1);
    else
      this.setName(row, col, pointID);
  }

  public void setName(CString Tag, int row, int col, Color textcolor, Vector2 pos, int emojiID = -1)
  {
    this.setName(this.npccityname, Tag, row, col, textcolor, pos, (byte) 0, kingdomID: (ushort) 0, emojiID: emojiID, offsety: 92f);
  }

  public void setName(int row, int col, Vector2 pos)
  {
    if (this.PointName[col][row] == null)
      return;
    this.PointName[col][row].updateName(pos + this.NameTextOffset);
  }

  public void setName(int row, int col, float blood)
  {
    if (this.PointName[col][row] == null || this.PointName[col][row].bloodtextID <= 0)
      return;
    this.NPCBloodValue[col][row] = blood;
    RectTransform component = ((Transform) this.PointName[col][row].NameRectTransform).GetChild(this.PointName[col][row].bloodtextID).GetChild(1).GetComponent<RectTransform>();
    this.NPCBloodSpeed[col][row] = component.sizeDelta.x * 100f / this.maxblood - blood;
    this.NPCBloodSpeed[col][row] *= this.BloodSpeed;
    this.NPCBloodStr[col][row].ClearString();
    this.NPCBloodStr[col][row].FloatToFormat(blood, 2);
    this.NPCBloodStr[col][row].AppendFormat("{0}%");
  }

  public void setName(int row, int col, short pointid)
  {
    if (this.PointName[col][row] == null)
      return;
    if (pointid > (short) -1 && pointid < (short) 2048)
    {
      this.PointName[col][row].pointID = pointid;
      if (this.PointName[col][row].TimeString == null)
        this.PointName[col][row].TimeString = StringManager.Instance.SpawnString(64);
      Text component = ((Transform) this.PointName[col][row].NameRectTransform).GetChild(this.PointName[col][row].bloodtextID).GetChild(3).GetComponent<Text>();
      this.PointName[col][row].TimeString.ClearString();
      uint sec = DataManager.MapDataController.NPCPointTable[(int) this.PointName[col][row].pointID].endTime <= (ulong) DataManager.Instance.ServerTime ? 0U : (uint) (DataManager.MapDataController.NPCPointTable[(int) this.PointName[col][row].pointID].endTime - (ulong) DataManager.Instance.ServerTime);
      GameConstants.GetTimeString(this.PointName[col][row].TimeString, sec, hideTimeIfDays: true, showZeroHour: false);
      component.text = this.PointName[col][row].TimeString.ToString();
      ((Graphic) component).SetAllDirty();
      component.cachedTextGenerator.Invalidate();
      if ((long) sec < (long) this.minTime)
        ((Graphic) component).color = Color.yellow;
      else
        ((Graphic) component).color = Color.white;
    }
    else
    {
      this.PointName[col][row].pointID = (short) -1;
      if (this.PointName[col][row].TimeString == null)
        return;
      StringManager.Instance.DeSpawnString(this.PointName[col][row].TimeString);
      this.PointName[col][row].TimeString = (CString) null;
    }
  }

  public MapTileName pullLineName(
    CString Name,
    CString Tag,
    ELineColor textcolor,
    Vector2 pos,
    ushort kingdomID = 0)
  {
    if (Name == null)
      return (MapTileName) null;
    if (this.LinePoolsCounter == 0)
    {
      this.LinePoolsCounter = 256;
      for (int index = 0; index < this.LinePoolsCounter; ++index)
      {
        if (index < this.LineNamePools.Count)
          this.LineNamePools[index] = new MapTileName(this.BloodNameLayout, (Vector2) this.iniNamePos, this.NameTextSize);
        else
          this.LineNamePools.Add(new MapTileName(this.BloodNameLayout, (Vector2) this.iniNamePos, this.NameTextSize));
      }
    }
    --this.LinePoolsCounter;
    MapTileName lineNamePool = this.LineNamePools[this.LinePoolsCounter];
    this.LineNamePools[this.LinePoolsCounter] = (MapTileName) null;
    lineNamePool.updateName(Name, Tag, MapTileBloodName.lineNameColor[(int) textcolor], pos, kingdomID);
    return lineNamePool;
  }

  public void pushLineName(ref MapTileName Name)
  {
    if (Name == null)
      return;
    if (Name.mapEmoji != null)
    {
      GUIManager.Instance.pushEmojiIcon(Name.mapEmoji);
      Name.mapEmoji = (EmojiUnit) null;
    }
    if (Name.mapEmojiBack != null)
    {
      GUIManager.Instance.pushEmojiIcon(Name.mapEmojiBack);
      Name.mapEmojiBack = (EmojiUnit) null;
    }
    if (Name.TimeString != null)
    {
      StringManager.Instance.DeSpawnString(Name.TimeString);
      Name.TimeString = (CString) null;
    }
    Name.pointID = (short) -1;
    Name.SetActive(false);
    if (this.LinePoolsCounter < this.LineNamePools.Count)
      this.LineNamePools[this.LinePoolsCounter] = Name;
    else
      this.LineNamePools.Add(Name);
    ++this.LinePoolsCounter;
    Name = (MapTileName) null;
  }

  public void updateLineNameColor(
    MapTileName Name,
    ELineColor textcolor,
    CString player = null,
    CString tag = null)
  {
    if (player == null)
      Name.updateName(MapTileBloodName.lineNameColor[(int) textcolor]);
    else
      Name.updateName(player, tag, MapTileBloodName.lineNameColor[(int) textcolor], (ushort) 0);
  }

  public void npcTimeRun()
  {
    if ((double) this.WaiteTimer == 0.0)
    {
      this.NPCBloodStrAlpha -= Time.deltaTime * this.AlphaSpeed;
      if ((double) this.NPCBloodStrAlpha < 0.0)
      {
        this.NPCBloodStrAlpha = 0.0f;
        this.AlphaSpeed *= -1f;
        ++this.NPCTimeState;
        this.NPCTimeState &= (byte) 1;
        if (this.NPCTimeState == (byte) 0)
        {
          for (int index1 = 0; index1 < this.PointName.Length; ++index1)
          {
            for (int index2 = 0; index2 < this.PointName[index1].Length; ++index2)
            {
              if (this.PointName[index1][index2] != null && this.PointName[index1][index2].bloodtextID > 0)
              {
                RectTransform component1 = ((Transform) this.PointName[index1][index2].NameRectTransform).GetChild(this.PointName[index1][index2].bloodtextID).GetChild(1).GetComponent<RectTransform>();
                if (((Component) component1).gameObject.activeSelf)
                {
                  if ((double) this.NPCBloodValue[index1][index2] != 0.0)
                  {
                    Vector2 sizeDelta = component1.sizeDelta;
                    sizeDelta.x -= Time.deltaTime * this.NPCBloodSpeed[index1][index2];
                    if ((double) (sizeDelta.x * 100f / this.maxblood) < (double) this.NPCBloodValue[index1][index2])
                    {
                      float num = this.NPCBloodValue[index1][index2];
                      sizeDelta.x = (float) ((double) num * (double) this.maxblood / 100.0);
                      this.NPCBloodValue[index1][index2] = 0.0f;
                    }
                    component1.sizeDelta = sizeDelta;
                  }
                  Text component2 = ((Transform) this.PointName[index1][index2].NameRectTransform).GetChild(this.PointName[index1][index2].bloodtextID).GetChild(3).GetComponent<Text>();
                  component2.text = this.NPCBloodStr[index1][index2].ToString();
                  ((Graphic) component2).SetAllDirty();
                  component2.cachedTextGenerator.Invalidate();
                  ((Graphic) component2).color = Color.white;
                  Color color = ((Graphic) component2).color with
                  {
                    a = this.NPCBloodStrAlpha
                  };
                  ((Graphic) component2).color = color;
                }
              }
            }
          }
        }
        else
        {
          this.NPCTimeStr.ClearString();
          GameConstants.GetTimeString(this.NPCTimeStr, (uint) ActivityManager.Instance.ActivityData[0].EventCountTime, hideTimeIfDays: true, showZeroHour: false);
          for (int index3 = 0; index3 < this.PointName.Length; ++index3)
          {
            for (int index4 = 0; index4 < this.PointName[index3].Length; ++index4)
            {
              if (this.PointName[index3][index4] != null && this.PointName[index3][index4].bloodtextID > 0)
              {
                RectTransform component3 = ((Transform) this.PointName[index3][index4].NameRectTransform).GetChild(this.PointName[index3][index4].bloodtextID).GetChild(1).GetComponent<RectTransform>();
                if (((Component) component3).gameObject.activeSelf)
                {
                  if ((double) this.NPCBloodValue[index3][index4] != 0.0)
                  {
                    Vector2 sizeDelta = component3.sizeDelta;
                    sizeDelta.x -= Time.deltaTime * this.NPCBloodSpeed[index3][index4];
                    if ((double) (sizeDelta.x * 100f / this.maxblood) < (double) this.NPCBloodValue[index3][index4])
                    {
                      sizeDelta.x = (float) ((double) this.NPCBloodValue[index3][index4] * (double) this.maxblood / 100.0);
                      this.NPCBloodValue[index3][index4] = 0.0f;
                    }
                    component3.sizeDelta = sizeDelta;
                  }
                  Text component4 = ((Transform) this.PointName[index3][index4].NameRectTransform).GetChild(this.PointName[index3][index4].bloodtextID).GetChild(3).GetComponent<Text>();
                  if (this.PointName[index3][index4].pointID > (short) -1 && this.PointName[index3][index4].pointID < (short) 2048)
                  {
                    this.PointName[index3][index4].TimeString.ClearString();
                    uint sec = DataManager.MapDataController.NPCPointTable[(int) this.PointName[index3][index4].pointID].endTime <= (ulong) DataManager.Instance.ServerTime ? 0U : (uint) (DataManager.MapDataController.NPCPointTable[(int) this.PointName[index3][index4].pointID].endTime - (ulong) DataManager.Instance.ServerTime);
                    GameConstants.GetTimeString(this.PointName[index3][index4].TimeString, sec, hideTimeIfDays: true, showZeroHour: false);
                    component4.text = this.PointName[index3][index4].TimeString.ToString();
                    ((Graphic) component4).SetAllDirty();
                    component4.cachedTextGenerator.Invalidate();
                    if ((long) sec < (long) this.minTime)
                      ((Graphic) component4).color = Color.yellow;
                    else
                      ((Graphic) component4).color = Color.white;
                  }
                  else
                  {
                    component4.text = this.NPCTimeStr.ToString();
                    ((Graphic) component4).SetAllDirty();
                    component4.cachedTextGenerator.Invalidate();
                    if (ActivityManager.Instance.ActivityData[0].EventCountTime < (long) this.minTime)
                      ((Graphic) component4).color = Color.yellow;
                    else
                      ((Graphic) component4).color = Color.white;
                  }
                  Color color = ((Graphic) component4).color with
                  {
                    a = this.NPCBloodStrAlpha
                  };
                  ((Graphic) component4).color = color;
                }
              }
            }
          }
        }
      }
      else
      {
        if ((double) this.NPCBloodStrAlpha > 1.0)
        {
          this.NPCBloodStrAlpha = 1f;
          this.AlphaSpeed *= -1f;
          this.WaiteTimer = this.maxWaiteTimer;
        }
        if (this.NPCTimeState == (byte) 0)
        {
          for (int index5 = 0; index5 < this.PointName.Length; ++index5)
          {
            for (int index6 = 0; index6 < this.PointName[index5].Length; ++index6)
            {
              if (this.PointName[index5][index6] != null && this.PointName[index5][index6].bloodtextID > 0)
              {
                RectTransform component5 = ((Transform) this.PointName[index5][index6].NameRectTransform).GetChild(this.PointName[index5][index6].bloodtextID).GetChild(1).GetComponent<RectTransform>();
                if (((Component) component5).gameObject.activeSelf)
                {
                  if ((double) this.NPCBloodValue[index5][index6] != 0.0)
                  {
                    Vector2 sizeDelta = component5.sizeDelta;
                    sizeDelta.x -= Time.deltaTime * this.NPCBloodSpeed[index5][index6];
                    if ((double) (sizeDelta.x * 100f / this.maxblood) < (double) this.NPCBloodValue[index5][index6])
                    {
                      sizeDelta.x = (float) ((double) this.NPCBloodValue[index5][index6] * (double) this.maxblood / 100.0);
                      this.NPCBloodValue[index5][index6] = 0.0f;
                    }
                    component5.sizeDelta = sizeDelta;
                  }
                  Text component6 = ((Transform) this.PointName[index5][index6].NameRectTransform).GetChild(this.PointName[index5][index6].bloodtextID).GetChild(3).GetComponent<Text>();
                  Color color = ((Graphic) component6).color with
                  {
                    a = this.NPCBloodStrAlpha
                  };
                  ((Graphic) component6).color = color;
                }
              }
            }
          }
        }
        else
        {
          this.ChekTimer += Time.deltaTime;
          if ((double) this.ChekTimer >= 1.0)
          {
            this.ChekTimer = 0.0f;
            this.NPCTimeStr.ClearString();
            GameConstants.GetTimeString(this.NPCTimeStr, (uint) ActivityManager.Instance.ActivityData[0].EventCountTime, hideTimeIfDays: true, showZeroHour: false);
          }
          for (int index7 = 0; index7 < this.PointName.Length; ++index7)
          {
            for (int index8 = 0; index8 < this.PointName[index7].Length; ++index8)
            {
              if (this.PointName[index7][index8] != null && this.PointName[index7][index8].bloodtextID > 0)
              {
                RectTransform component7 = ((Transform) this.PointName[index7][index8].NameRectTransform).GetChild(this.PointName[index7][index8].bloodtextID).GetChild(1).GetComponent<RectTransform>();
                if (((Component) component7).gameObject.activeSelf)
                {
                  if ((double) this.NPCBloodValue[index7][index8] != 0.0)
                  {
                    Vector2 sizeDelta = component7.sizeDelta;
                    sizeDelta.x -= Time.deltaTime * this.NPCBloodSpeed[index7][index8];
                    if ((double) (sizeDelta.x * 100f / this.maxblood) < (double) this.NPCBloodValue[index7][index8])
                    {
                      sizeDelta.x = (float) ((double) this.NPCBloodValue[index7][index8] * (double) this.maxblood / 100.0);
                      this.NPCBloodValue[index7][index8] = 0.0f;
                    }
                    component7.sizeDelta = sizeDelta;
                  }
                  Text component8 = ((Transform) this.PointName[index7][index8].NameRectTransform).GetChild(this.PointName[index7][index8].bloodtextID).GetChild(3).GetComponent<Text>();
                  if ((double) this.ChekTimer == 0.0)
                  {
                    if (this.PointName[index7][index8].pointID > (short) -1 && this.PointName[index7][index8].pointID < (short) 2048)
                    {
                      this.PointName[index7][index8].TimeString.ClearString();
                      uint sec = DataManager.MapDataController.NPCPointTable[(int) this.PointName[index7][index8].pointID].endTime <= (ulong) DataManager.Instance.ServerTime ? 0U : (uint) (DataManager.MapDataController.NPCPointTable[(int) this.PointName[index7][index8].pointID].endTime - (ulong) DataManager.Instance.ServerTime);
                      GameConstants.GetTimeString(this.PointName[index7][index8].TimeString, sec, hideTimeIfDays: true, showZeroHour: false);
                      component8.text = this.PointName[index7][index8].TimeString.ToString();
                    }
                    else
                      component8.text = this.NPCTimeStr.ToString();
                    ((Graphic) component8).SetAllDirty();
                    component8.cachedTextGenerator.Invalidate();
                  }
                  Color color = ((Graphic) component8).color with
                  {
                    a = this.NPCBloodStrAlpha
                  };
                  ((Graphic) component8).color = color;
                }
              }
            }
          }
        }
      }
    }
    else
    {
      this.WaiteTimer -= Time.deltaTime;
      if ((double) this.WaiteTimer < 0.0)
        this.WaiteTimer = 0.0f;
      if (this.NPCTimeState != (byte) 0)
      {
        this.ChekTimer += Time.deltaTime;
        if ((double) this.ChekTimer >= 1.0)
        {
          this.ChekTimer = 0.0f;
          this.NPCTimeStr.ClearString();
          GameConstants.GetTimeString(this.NPCTimeStr, (uint) ActivityManager.Instance.ActivityData[0].EventCountTime, hideTimeIfDays: true, showZeroHour: false);
        }
      }
      for (int index9 = 0; index9 < this.PointName.Length; ++index9)
      {
        for (int index10 = 0; index10 < this.PointName[index9].Length; ++index10)
        {
          if (this.PointName[index9][index10] != null && this.PointName[index9][index10].bloodtextID > 0)
          {
            RectTransform component9 = ((Transform) this.PointName[index9][index10].NameRectTransform).GetChild(this.PointName[index9][index10].bloodtextID).GetChild(1).GetComponent<RectTransform>();
            if (((Component) component9).gameObject.activeSelf && (double) this.NPCBloodValue[index9][index10] != 0.0)
            {
              Vector2 sizeDelta = component9.sizeDelta;
              sizeDelta.x -= Time.deltaTime * this.NPCBloodSpeed[index9][index10];
              if ((double) (sizeDelta.x * 100f / this.maxblood) < (double) this.NPCBloodValue[index9][index10])
              {
                sizeDelta.x = (float) ((double) this.NPCBloodValue[index9][index10] * (double) this.maxblood / 100.0);
                this.NPCBloodValue[index9][index10] = 0.0f;
              }
              component9.sizeDelta = sizeDelta;
            }
            if (this.NPCTimeState != (byte) 0 && (double) this.ChekTimer == 0.0)
            {
              Text component10 = ((Transform) this.PointName[index9][index10].NameRectTransform).GetChild(this.PointName[index9][index10].bloodtextID).GetChild(3).GetComponent<Text>();
              if (this.PointName[index9][index10].pointID > (short) -1 && this.PointName[index9][index10].pointID < (short) 2048)
              {
                this.PointName[index9][index10].TimeString.ClearString();
                uint sec = DataManager.MapDataController.NPCPointTable[(int) this.PointName[index9][index10].pointID].endTime <= (ulong) DataManager.Instance.ServerTime ? 0U : (uint) (DataManager.MapDataController.NPCPointTable[(int) this.PointName[index9][index10].pointID].endTime - (ulong) DataManager.Instance.ServerTime);
                GameConstants.GetTimeString(this.PointName[index9][index10].TimeString, sec, hideTimeIfDays: true, showZeroHour: false);
                component10.text = this.PointName[index9][index10].TimeString.ToString();
              }
              else
                component10.text = this.NPCTimeStr.ToString();
              ((Graphic) component10).SetAllDirty();
              component10.cachedTextGenerator.Invalidate();
            }
          }
        }
      }
    }
  }

  public void MapTileNameRebuilt()
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

  private float checkNpdBlood(float booldvalue)
  {
    if ((double) booldvalue > 0.0 && (double) booldvalue < 0.0099999997764825821)
      booldvalue = 0.012f;
    return booldvalue;
  }
}
