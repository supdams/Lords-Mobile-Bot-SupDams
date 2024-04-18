// Decompiled with JetBrains decompiler
// Type: MapTileNPC
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class MapTileNPC
{
  public const float AnimationSpeed = 15f;
  public const float HitSpeed = 5f;
  public const float DieSpeed = 5f;
  public const float HurtTimer = 0.2f;
  public const float HitTimer = 0.2f;
  public const float DieTimer = 1f;
  public const float ReadyDieTimer = 8f;
  public const float PerlinNoiseScale = 9f;
  public const float damagexoffset = 1f;
  public const float damageyoffset = 0.0f;
  public const float DamageScaleSpeed = 25f;
  public const float DamageAlphaSpeed = 0.8333333f;
  public const float DamageYoffsetSpeed = 0.25f;
  public const float Spritenpcscale = 1.29032f;
  public const float maxDamageScale = 10f;
  public const float npcposz = 37f;
  public MapTile mapTileController;
  public Transform NPCLayout;
  public Transform DamageLayout;
  public float[] npcposyoffset;
  public float[] npcposxoffset;
  public Material[] NPCMaterial;
  public byte[] HitFrame;
  public float npcscale = 1f;
  public Sprite[][][] NPCSprite;
  public List<NPCFighter> npcfighters;
  private Transform NPCABLayout;
  private NPC[][] NPCs;
  private ushort[] NPCNum;
  private byte NPCKindCount;
  private NPC[][][] NPCPools;
  private int[][] poolCounter;
  private int[] poolsCounter;
  private int[] NPCABKey;
  private List<NPC> delnpc;
  private Font DamageFont;
  private Damage[][] DamagePools;
  private int[] DamagePoolCounter;
  private int DamagePoolsCounter;

  public MapTileNPC(Transform realmGroup)
  {
    this.npcposyoffset = new float[5];
    Array.Clear((Array) this.npcposyoffset, 0, 5);
    this.npcposxoffset = new float[5];
    Array.Clear((Array) this.npcposxoffset, 0, 5);
    this.NPCSprite = new Sprite[5][][];
    for (int index1 = 0; index1 < this.NPCSprite.Length; ++index1)
    {
      this.NPCSprite[index1] = new Sprite[3][];
      for (int index2 = 0; index2 < 3; ++index2)
        this.NPCSprite[index1][index2] = (Sprite[]) null;
    }
    this.HitFrame = new byte[5];
    Array.Clear((Array) this.HitFrame, 0, 5);
    this.NPCMaterial = new Material[5];
    Array.Clear((Array) this.NPCMaterial, 0, 5);
    this.NPCNum = new ushort[5];
    Array.Clear((Array) this.NPCNum, 0, 5);
    this.NPCPools = new NPC[5][][];
    Array.Clear((Array) this.NPCPools, 0, 5);
    this.poolCounter = new int[5][];
    Array.Clear((Array) this.poolCounter, 0, 5);
    this.poolsCounter = new int[5];
    Array.Clear((Array) this.poolsCounter, 0, 5);
    this.NPCABKey = new int[5];
    Array.Clear((Array) this.NPCABKey, 0, 5);
    this.NPCKindCount = (byte) 0;
    this.NPCLayout = new GameObject(nameof (MapTileNPC)).transform;
    this.NPCLayout.localScale = Vector3.one * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
    this.NPCLayout.position = Vector3.forward * 3200f * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale;
    this.NPCLayout.SetParent(realmGroup, false);
    this.NPCABLayout = new GameObject("MapTileNPCAB").transform;
    this.NPCABLayout.position = Vector3.zero;
    this.NPCABLayout.SetParent(this.NPCLayout, false);
    this.DamageLayout = new GameObject("MapTileNPCDamage").transform;
    this.DamageLayout.position = Vector3.zero;
    this.DamageLayout.SetParent(this.NPCLayout, false);
    this.npcfighters = new List<NPCFighter>(16);
    this.delnpc = new List<NPC>(16);
  }

  public void pushDamage(Damage damageText)
  {
    if (damageText == null)
      return;
    for (int index = 0; index < this.DamagePoolsCounter; ++index)
    {
      if (this.DamagePoolCounter[index] < this.DamagePools[index].Length)
      {
        this.DamagePools[index][this.DamagePoolCounter[index]] = damageText;
        ++this.DamagePoolCounter[index];
        damageText.SetActive(false);
        break;
      }
    }
  }

  public Damage pullDamage()
  {
    Damage damage = (Damage) null;
    int index1;
    for (index1 = 0; index1 < this.DamagePoolsCounter; ++index1)
    {
      if (this.DamagePoolCounter[index1] > 0)
      {
        --this.DamagePoolCounter[index1];
        damage = this.DamagePools[index1][this.DamagePoolCounter[index1]];
        this.DamagePools[index1][this.DamagePoolCounter[index1]] = (Damage) null;
        break;
      }
    }
    if (index1 == this.DamagePoolsCounter)
    {
      this.DamagePools[index1] = new Damage[this.DamagePools[0].Length];
      for (int index2 = 0; index2 < this.DamagePools[index1].Length; ++index2)
        this.DamagePools[index1][index2] = new Damage(this.DamageLayout, this.DamageFont);
      ++this.DamagePoolsCounter;
      this.DamagePoolCounter[index1] = this.DamagePools[index1].Length;
      --this.DamagePoolCounter[index1];
      damage = this.DamagePools[index1][this.DamagePoolCounter[index1]];
      this.DamagePools[index1][this.DamagePoolCounter[index1]] = (Damage) null;
    }
    return damage;
  }

  public void OnDestroy()
  {
    this.mapTileController = (MapTile) null;
    if (this.npcfighters != null)
    {
      this.npcfighters.Clear();
      this.npcfighters = (List<NPCFighter>) null;
    }
    this.DamageFont = (Font) null;
    this.NPCABLayout = (Transform) null;
    if (this.NPCs != null)
    {
      for (int index1 = 0; index1 < this.NPCs.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.NPCs[index1].Length; ++index2)
        {
          if (this.NPCs[index1][index2] != null)
            this.NPCs[index1][index2].Release();
        }
        Array.Clear((Array) this.NPCs[index1], 0, this.NPCs[index1].Length);
        this.NPCs[index1] = (NPC[]) null;
      }
    }
    if (this.NPCPools != null)
    {
      for (int index3 = 0; index3 < this.NPCPools.Length; ++index3)
      {
        if (this.NPCPools[index3] != null)
        {
          for (int index4 = 0; index4 < this.NPCPools[index3].Length; ++index4)
          {
            if (this.NPCPools[index3][index4] != null)
            {
              for (int index5 = 0; index5 < this.NPCPools[index3][index4].Length; ++index5)
              {
                if (this.NPCPools[index3][index4][index5] != null)
                  this.NPCPools[index3][index4][index5].Release();
                this.NPCPools[index3][index4][index5] = (NPC) null;
              }
            }
            this.NPCPools[index3][index4] = (NPC[]) null;
          }
        }
        this.NPCPools[index3] = (NPC[][]) null;
      }
    }
    if (this.NPCSprite != null)
    {
      for (int index6 = 0; index6 < this.NPCSprite.Length; ++index6)
      {
        if (this.NPCSprite[index6] != null)
        {
          for (int index7 = 0; index7 < this.NPCSprite[index6].Length; ++index7)
          {
            if (this.NPCSprite[index6][index7] != null)
              Array.Clear((Array) this.NPCSprite[index6][index7], 0, this.NPCSprite[index6][index7].Length);
            this.NPCSprite[index6][index7] = (Sprite[]) null;
          }
        }
        this.NPCSprite[index6] = (Sprite[][]) null;
      }
    }
    if (this.NPCMaterial != null)
    {
      Array.Clear((Array) this.NPCMaterial, 0, this.NPCMaterial.Length);
      this.NPCMaterial = (Material[]) null;
    }
    if (this.NPCNum != null)
    {
      Array.Clear((Array) this.NPCNum, 0, this.NPCNum.Length);
      this.NPCNum = (ushort[]) null;
    }
    if (this.poolCounter != null)
    {
      for (int index = 0; index < this.poolCounter.Length; ++index)
      {
        if (this.poolCounter[index] != null)
          Array.Clear((Array) this.poolCounter[index], 0, this.poolCounter[index].Length);
        this.poolCounter[index] = (int[]) null;
      }
      this.poolCounter = (int[][]) null;
    }
    if (this.poolsCounter != null)
    {
      Array.Clear((Array) this.poolsCounter, 0, this.poolsCounter.Length);
      this.poolsCounter = (int[]) null;
    }
    if (this.NPCABKey != null)
    {
      for (int index = 0; index < this.NPCABKey.Length; ++index)
      {
        if (this.NPCABKey[index] != 0)
          AssetManager.UnloadAssetBundle(this.NPCABKey[index]);
      }
      this.NPCABKey = (int[]) null;
    }
    if (this.DamagePools != null)
    {
      for (int index8 = 0; index8 < this.DamagePools.Length; ++index8)
      {
        if (this.DamagePools[index8] != null)
        {
          for (int index9 = 0; index9 < this.DamagePools[index8].Length; ++index9)
          {
            if (this.DamagePools[index8][index9] != null)
              this.DamagePools[index8][index9].Release();
          }
          Array.Clear((Array) this.DamagePools[index8], 0, this.DamagePools[index8].Length);
          this.DamagePools[index8] = (Damage[]) null;
        }
      }
      this.DamagePools = (Damage[][]) null;
    }
    if (this.DamagePoolCounter != null)
    {
      Array.Clear((Array) this.DamagePoolCounter, 0, this.DamagePoolCounter.Length);
      this.DamagePoolCounter = (int[]) null;
    }
    if (this.npcposyoffset != null)
    {
      Array.Clear((Array) this.npcposyoffset, 0, this.npcposyoffset.Length);
      this.npcposyoffset = (float[]) null;
    }
    if (this.npcposxoffset != null)
    {
      Array.Clear((Array) this.npcposxoffset, 0, this.npcposxoffset.Length);
      this.npcposxoffset = (float[]) null;
    }
    this.DamageLayout = (Transform) null;
    this.NPCLayout = (Transform) null;
  }

  public void IniNPC(int rowNum, int colNum, float nowscale, float canvasScale, MapTile mapTile)
  {
    this.mapTileController = mapTile;
    this.NPCs = new NPC[colNum][];
    for (int index = 0; index < colNum; ++index)
    {
      this.NPCs[index] = new NPC[rowNum];
      Array.Clear((Array) this.NPCs[index], 0, this.NPCs[index].Length);
    }
    this.npcscale = nowscale * 1.29032f;
    this.DamageFont = GUIManager.Instance.pDVMgr.DamageValueFont;
    this.DamagePools = new Damage[rowNum][];
    this.DamagePoolCounter = new int[rowNum];
    Array.Clear((Array) this.DamagePools, 0, this.DamagePools.Length);
    for (int index = 0; index < this.DamagePoolCounter.Length; ++index)
      this.DamagePoolCounter[index] = -1;
    this.DamagePools[0] = new Damage[colNum * 3];
    for (int index = 0; index < this.DamagePools[0].Length; ++index)
      this.DamagePools[0][index] = new Damage(this.DamageLayout, this.DamageFont);
    this.DamagePoolCounter[0] = this.DamagePools[0].Length;
    this.DamagePoolsCounter = 1;
  }

  public void setNPC(ushort npcNum, uint npcTableID, int row, int col, Vector2 pos)
  {
    if (npcNum < (ushort) 2)
    {
      if (this.NPCs[col][row] == null)
        return;
      this.pushNPC(row, col);
    }
    else
    {
      if (this.NPCs[col][row] != null && ((int) this.NPCs[col][row].NPCKindID >= this.NPCNum.Length || (int) this.NPCNum[(int) this.NPCs[col][row].NPCKindID] != (int) npcNum))
        this.pushNPC(row, col);
      if (this.NPCs[col][row] == null)
      {
        int npcKindID = 0;
        int num = 0;
        while (num < (int) this.NPCKindCount)
        {
          npcKindID %= this.NPCNum.Length;
          if ((int) this.NPCNum[npcKindID] != (int) npcNum)
          {
            ++num;
            ++npcKindID;
          }
          else
            break;
        }
        if (num == (int) this.NPCKindCount)
        {
          npcKindID %= this.NPCNum.Length;
          this.NPCNum[npcKindID] = npcNum;
          MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(npcNum);
          CString cstring = StringManager.Instance.SpawnString();
          cstring.ClearString();
          cstring.IntToFormat((long) recordByKey.MapNPCNO, 3);
          cstring.AppendFormat("UI/NPC_{0}");
          AssetBundle assetBundle = !AssetManager.GetAssetBundleDownload(cstring, AssetPath.UI, AssetType.NPC, recordByKey.MapNPCNO, true) ? (AssetBundle) null : AssetManager.GetAssetBundle(cstring, out this.NPCABKey[npcKindID]);
          StringManager.Instance.DeSpawnString(cstring);
          if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
            return;
          ++this.NPCKindCount;
          GameObject gameObject = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
          gameObject.SetActive(false);
          Transform transform = gameObject.transform;
          UISpritesArray component1 = transform.GetChild(0).GetComponent<UISpritesArray>();
          UISpritesArray component2 = transform.GetChild(1).GetComponent<UISpritesArray>();
          UISpritesArray component3 = transform.GetChild(2).GetComponent<UISpritesArray>();
          transform.SetParent(this.NPCABLayout, false);
          this.NPCSprite[npcKindID][0] = component1.m_Sprites;
          this.NPCSprite[npcKindID][1] = component2.m_Sprites;
          this.NPCSprite[npcKindID][2] = component3.m_Sprites;
          this.HitFrame[npcKindID] = recordByKey.HitFrame;
          this.NPCMaterial[npcKindID] = ((MaskableGraphic) component1.m_Image).material;
          this.NPCMaterial[npcKindID].renderQueue = 2600;
          Vector3 vector3 = GameConstants.WordToVector3(recordByKey.Xoffset, recordByKey.Yoffset, (ushort) 0);
          this.npcposxoffset[npcKindID] = vector3.x * 1.29032f / this.npcscale;
          this.npcposyoffset[npcKindID] = (float) ((double) vector3.y * 4.0 * 1.2903200387954712) / this.npcscale;
          if ((int) this.NPCKindCount <= this.NPCNum.Length)
          {
            this.poolsCounter[npcKindID] = 1;
            this.poolCounter[npcKindID] = new int[64];
            this.poolCounter[npcKindID][0] = 4;
            this.NPCPools[npcKindID] = new NPC[64][];
            this.NPCPools[npcKindID][0] = new NPC[this.poolCounter[npcKindID][0]];
            for (int index = 0; index < this.poolCounter[npcKindID][0]; ++index)
              this.NPCPools[npcKindID][0][index] = new NPC(pos, (byte) npcKindID, NPCState.NPC_Idle, this);
          }
          else
          {
            for (int index1 = 0; index1 < this.poolsCounter[npcKindID]; ++index1)
            {
              for (int index2 = 0; index2 < this.poolCounter[npcKindID][index1]; ++index2)
                this.NPCPools[npcKindID][index1][index2].NPCSpriteRenderer.material = this.NPCMaterial[npcKindID];
            }
          }
        }
        int index3;
        for (index3 = 0; index3 < this.poolsCounter[npcKindID]; ++index3)
        {
          if (this.poolCounter[npcKindID][index3] > 0)
          {
            --this.poolCounter[npcKindID][index3];
            this.NPCs[col][row] = this.NPCPools[npcKindID][index3][this.poolCounter[npcKindID][index3]];
            this.NPCPools[npcKindID][index3][this.poolCounter[npcKindID][index3]] = (NPC) null;
            break;
          }
        }
        if (index3 == this.poolsCounter[npcKindID])
        {
          this.NPCPools[npcKindID][index3] = new NPC[this.NPCPools[npcKindID][0].Length];
          for (int index4 = 0; index4 < this.NPCPools[npcKindID][index3].Length; ++index4)
            this.NPCPools[npcKindID][index3][index4] = new NPC(pos, (byte) npcKindID, NPCState.NPC_Idle, this);
          ++this.poolsCounter[npcKindID];
          this.poolCounter[npcKindID][index3] = this.NPCPools[npcKindID][index3].Length;
          --this.poolCounter[npcKindID][index3];
          this.NPCs[col][row] = this.NPCPools[npcKindID][index3][this.poolCounter[npcKindID][index3]];
          this.NPCPools[npcKindID][index3][this.poolCounter[npcKindID][index3]] = (NPC) null;
        }
        this.NPCs[col][row].SetActive(true);
        int row1 = 0;
        int col1 = 0;
        for (int index5 = 0; index5 < this.npcfighters.Count; ++index5)
        {
          this.mapTileController.MapIDtoMapTileRowCol(this.npcfighters[index5].mapID, ref row1, ref col1);
          if (row1 == row && col == col1)
          {
            this.setNPC(row, col, this.npcfighters[index5].linefighter, this.npcfighters[index5].mapID);
            this.npcfighters.RemoveAt(index5);
            break;
          }
        }
      }
      this.setNPC(row, col, pos, npcTableID);
    }
  }

  public void setNPC(int row, int col, Vector2 pos, uint tableid)
  {
    if (this.NPCs[col][row] == null)
      return;
    this.NPCs[col][row].updateNPC(tableid, (byte) row, (byte) col);
    this.NPCs[col][row].updateNPC(pos * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale * DataManager.MapDataController.zoomSize);
  }

  public void setNPC(int row, int col, Vector2 pos)
  {
    if (this.NPCs[col][row] == null)
      return;
    this.NPCs[col][row].updateNPC(pos * DataManager.MapDataController.ScreenSpaceCameraCanvasrectranScale * DataManager.MapDataController.zoomSize);
  }

  public void setNPC(int row, int col, NPCState npcState)
  {
    if (row <= -1 || col <= -1 || this.NPCs[col][row] == null)
      return;
    switch (npcState)
    {
      case NPCState.NPC_Hit:
        this.NPCs[col][row].HIT();
        break;
      case NPCState.NPC_Hurt:
        this.NPCs[col][row].Hurt();
        break;
      default:
        this.NPCs[col][row].updateNPC(npcState);
        break;
    }
  }

  public void setNPC(int row, int col, float hurt, uint mapID)
  {
    if (this.NPCs[col][row] == null)
      this.mapTileController.CheckMapNPCBlood(mapID, hurt);
    else
      this.NPCs[col][row].updateNPC(hurt);
  }

  public void setNPC(int row, int col, LineNode linenode, uint mapID)
  {
    if (row > -1 && row > -1 && this.NPCs[col][row] != null)
    {
      this.NPCs[col][row].updateNPC(linenode);
    }
    else
    {
      NPCFighter npcFighter;
      npcFighter.mapID = mapID;
      npcFighter.linefighter = linenode;
      this.npcfighters.Add(npcFighter);
    }
  }

  public void setNPC(int row, int col, int lineTableID)
  {
    if (row > -1 && col > -1 && this.NPCs[col][row] != null)
    {
      for (int index = 0; index < this.NPCs[col][row].fighters.Count; ++index)
      {
        if (this.NPCs[col][row].fighters[index].lineTableID == lineTableID)
        {
          this.NPCs[col][row].fighters.RemoveAt(index);
          break;
        }
      }
    }
    else
    {
      for (int index = 0; index < this.npcfighters.Count; ++index)
      {
        if (this.npcfighters[index].linefighter.lineTableID == lineTableID)
        {
          this.npcfighters.RemoveAt(index);
          break;
        }
      }
    }
  }

  public void setNPC(int row, int col)
  {
    if (row <= -1 || col <= -1 || this.NPCs[col][row] == null)
      return;
    this.NPCs[col][row].updateNPC();
  }

  public void pushNPC(int row, int col)
  {
    this.NPCs[col][row].SetActive(false);
    int npcKindId = (int) this.NPCs[col][row].NPCKindID;
    for (int index = 0; index < this.poolsCounter[npcKindId]; ++index)
    {
      if (this.poolCounter[npcKindId][index] < this.NPCPools[npcKindId][index].Length)
      {
        if (this.NPCs[col][row].NPCTid < (ushort) 2048)
          this.NPCs[col][row].releaseNPC();
        this.NPCPools[npcKindId][index][this.poolCounter[npcKindId][index]] = this.NPCs[col][row];
        this.NPCs[col][row] = (NPC) null;
        ++this.poolCounter[npcKindId][index];
        break;
      }
    }
  }

  public void pushDelNPC(int row, int col)
  {
    if (this.NPCs[col][row] == null)
      return;
    this.NPCs[col][row].DieTimer = 8f;
    if (this.NPCs[col][row].NPCTableID >= 262144U)
      return;
    this.NPCs[col][row].NPCTid = DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCs[col][row].NPCTableID].tableID;
    if (DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCs[col][row].NPCTableID].pointKind == (byte) 10)
      DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCs[col][row].NPCTableID].pointKind = (byte) 0;
    this.NPCs[col][row].NPCTableID = 262144U;
  }

  public void checkNPC(int row, int col)
  {
    if (this.NPCs[col][row] == null)
    {
      DataManager.msgBuffer[0] = (byte) 90;
      DataManager.msgBuffer[1] = (byte) row;
      DataManager.msgBuffer[2] = (byte) col;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
    else
    {
      if (this.NPCs[col][row].NPCTableID >= 262144U && this.NPCs[col][row].NPCTid < (ushort) 2048)
        return;
      this.NPCs[col][row].releaseNPC();
      DataManager.msgBuffer[0] = (byte) 90;
      DataManager.msgBuffer[1] = (byte) row;
      DataManager.msgBuffer[2] = (byte) col;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
  }

  public void Run()
  {
    for (int index1 = 0; index1 < this.NPCs.Length; ++index1)
    {
      for (int index2 = 0; index2 < this.NPCs[index1].Length; ++index2)
      {
        if (this.NPCs[index1][index2] != null)
          this.NPCs[index1][index2].Run();
      }
    }
  }

  public sbyte getNPCDir(int row, int col)
  {
    return this.NPCs[col][row] != null ? this.NPCs[col][row].NPCDir : (sbyte) 1;
  }

  public float getNPCLastBlood(int row, int col)
  {
    if (this.NPCs[col][row] == null)
      return -1f;
    if (this.NPCs[col][row].hurt.Count > 0)
    {
      if ((double) this.NPCs[col][row].hurt[this.NPCs[col][row].hurt.Count - 1] == 0.0)
        return this.NPCs[col][row].hurt[this.NPCs[col][row].hurt.Count - 1];
      this.NPCs[col][row].releaseNPC();
      return -1f;
    }
    this.NPCs[col][row].releaseNPC();
    return -1f;
  }
}
