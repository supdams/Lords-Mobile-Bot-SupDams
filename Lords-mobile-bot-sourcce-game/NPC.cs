// Decompiled with JetBrains decompiler
// Type: NPC
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class NPC
{
  public byte NPCKindID;
  public sbyte NPCDir;
  public NPCState CurNPCState;
  public Vector2 NPCPos;
  public List<float> hurt;
  public List<LineNode> fighters;
  public float DieTimer;
  public uint NPCTableID = 262144;
  public GameObject NPCGameObject;
  public ushort NPCTid = 2048;
  public SpriteRenderer NPCSpriteRenderer;
  private byte NPCSheetID;
  private byte HitFrame;
  private Sprite[][] NPCAnimation;
  private float AnimationSpeed;
  private float AnimationTimer;
  private float HurtTimer;
  private float HitTimer;
  private float posxoffset;
  private float posyoffset;
  private byte row;
  private byte col;
  private Transform NPCTransform;
  private List<Damage> damage;
  private MapTileNPC NPCControl;

  public NPC(Vector2 inipos, byte npcKindID, NPCState npcState, MapTileNPC npcControl)
  {
    this.NPCControl = npcControl;
    this.NPCGameObject = new GameObject("npc");
    this.NPCTransform = this.NPCGameObject.transform;
    this.NPCSpriteRenderer = this.NPCGameObject.AddComponent<SpriteRenderer>();
    this.NPCSpriteRenderer.material = npcControl.NPCMaterial[(int) npcKindID];
    this.NPCTransform.localScale = Vector3.one * npcControl.npcscale;
    this.NPCTransform.SetParent(npcControl.NPCLayout, false);
    this.NPCKindID = npcKindID;
    this.NPCAnimation = npcControl.NPCSprite[(int) npcKindID];
    this.CurNPCState = npcState < NPCState.NPC_Hit ? npcState : NPCState.NPC_Attack;
    this.HitFrame = npcControl.HitFrame[(int) npcKindID];
    this.NPCDir = (sbyte) UnityEngine.Random.Range(0, 2);
    if (this.NPCDir == (sbyte) 0)
    {
      this.NPCDir = (sbyte) -1;
      this.NPCTransform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
    }
    else
      this.NPCTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    this.NPCSheetID = (byte) UnityEngine.Random.Range(0, this.NPCAnimation[(int) this.CurNPCState].Length);
    this.AnimationSpeed = 15f;
    this.AnimationTimer = 1f;
    this.posxoffset = this.posyoffset = this.HurtTimer = this.HitTimer = this.DieTimer = 0.0f;
    this.damage = new List<Damage>(3);
    this.fighters = new List<LineNode>(16);
    this.hurt = new List<float>(16);
    this.updateNPC(inipos);
    this.SetActive(false);
  }

  public NPC(
    Vector2 inipos,
    float iniscale,
    sbyte iniDir,
    byte npcID,
    NPCState npcState,
    Transform parent,
    ref int ABKey)
  {
    this.NPCControl = (MapTileNPC) null;
    this.NPCGameObject = new GameObject("npc");
    this.NPCTransform = this.NPCGameObject.transform;
    this.NPCTransform.localScale = Vector3.one * iniscale;
    this.NPCSpriteRenderer = this.NPCGameObject.AddComponent<SpriteRenderer>();
    MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey((ushort) npcID);
    CString cstring = StringManager.Instance.SpawnString();
    cstring.ClearString();
    cstring.IntToFormat((long) recordByKey.MapNPCNO, 3);
    cstring.AppendFormat("UI/NPC_{0}");
    AssetBundle assetBundle = AssetManager.GetAssetBundle(cstring, out ABKey);
    StringManager.Instance.DeSpawnString(cstring);
    GameObject gameObject = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
    gameObject.SetActive(false);
    Transform transform = gameObject.transform;
    UISpritesArray component1 = transform.GetChild(0).GetComponent<UISpritesArray>();
    UISpritesArray component2 = transform.GetChild(1).GetComponent<UISpritesArray>();
    UISpritesArray component3 = transform.GetChild(2).GetComponent<UISpritesArray>();
    transform.SetParent(parent, false);
    this.NPCTransform.SetParent(parent, false);
    this.NPCSpriteRenderer.material = ((MaskableGraphic) component1.m_Image).material;
    this.NPCSpriteRenderer.material.renderQueue = 3000;
    this.NPCAnimation = new Sprite[3][];
    this.NPCAnimation[0] = component1.m_Sprites;
    this.NPCAnimation[1] = component2.m_Sprites;
    this.NPCAnimation[2] = component3.m_Sprites;
    this.HitFrame = recordByKey.HitFrame;
    this.NPCKindID = npcID;
    this.CurNPCState = npcState < NPCState.NPC_Hit ? npcState : NPCState.NPC_Attack;
    this.NPCDir = iniDir;
    if (this.NPCDir == (sbyte) 0)
    {
      this.NPCDir = (sbyte) -1;
      this.NPCTransform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
    }
    else
      this.NPCTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
    this.NPCSheetID = (byte) UnityEngine.Random.Range(0, this.NPCAnimation[(int) this.CurNPCState].Length);
    this.AnimationSpeed = 15f;
    this.AnimationTimer = 1f;
    this.posxoffset = this.posyoffset = this.HurtTimer = this.HitTimer = this.DieTimer = 0.0f;
    this.damage = new List<Damage>(3);
    this.fighters = new List<LineNode>(16);
    this.hurt = new List<float>(16);
    this.updateNPC(inipos.x, inipos.y);
    this.SetActive(false);
  }

  public void Release()
  {
    if (this.NPCTid < (ushort) 2048)
      this.releaseNPC();
    if (this.hurt != null)
    {
      this.HurtClear();
      this.hurt = (List<float>) null;
    }
    if (this.fighters != null)
    {
      this.fighters.Clear();
      this.fighters = (List<LineNode>) null;
    }
    if (this.damage != null)
    {
      this.damage.Clear();
      this.damage = (List<Damage>) null;
    }
    if (this.NPCControl == null)
      Array.Clear((Array) this.NPCAnimation, 0, this.NPCAnimation.Length);
    this.NPCAnimation = (Sprite[][]) null;
    this.NPCGameObject = (GameObject) null;
    this.NPCTransform = (Transform) null;
    this.NPCSpriteRenderer = (SpriteRenderer) null;
    this.NPCControl = (MapTileNPC) null;
  }

  public void updateNPC()
  {
    if (this.CurNPCState != NPCState.NPC_Idle)
      this.updateNPC(NPCState.NPC_Idle);
    if (this.NPCTableID >= 262144U)
      return;
    ushort tableId = DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCTableID].tableID;
    if (this.hurt.Count <= 0 || DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCTableID].pointKind != (byte) 10 || (int) tableId >= DataManager.MapDataController.NPCPointTable.Length)
      return;
    DataManager.MapDataController.NPCPointTable[(int) tableId].Blood = this.hurt[0];
    this.hurt.RemoveAt(0);
    DataManager.msgBuffer[0] = (byte) 88;
    DataManager.msgBuffer[1] = this.row;
    DataManager.msgBuffer[2] = this.col;
    GameConstants.GetBytes(DataManager.MapDataController.NPCPointTable[(int) tableId].Blood, DataManager.msgBuffer, 3);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void updateNPC(NPCState npcState)
  {
    this.CurNPCState = npcState;
    this.NPCSheetID = (byte) 0;
  }

  public void updateNPC(uint npctableid, byte npcrow, byte npccol)
  {
    this.CurNPCState = NPCState.NPC_Idle;
    if ((int) npctableid != (int) this.NPCTableID && npctableid < 262144U && DataManager.MapDataController.LayoutMapInfo[(IntPtr) npctableid].pointKind == (byte) 10)
    {
      this.NPCDir = (sbyte) UnityEngine.Random.Range(0, 2);
      if (this.NPCDir == (sbyte) 0)
      {
        this.NPCDir = (sbyte) -1;
        this.NPCTransform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
      }
      else
        this.NPCTransform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
      this.NPCTableID = npctableid;
      this.NPCTid = (ushort) 2048;
    }
    this.NPCSheetID = (byte) UnityEngine.Random.Range(0, this.NPCAnimation[(int) this.CurNPCState].Length);
    this.row = npcrow;
    this.col = npccol;
    this.Clear();
  }

  public void updateNPC(float npcboold)
  {
    if ((double) npcboold <= 0.0)
    {
      npcboold = 0.0f;
      if (this.hurt.Count == 0 || (double) this.hurt[this.hurt.Count - 1] > 0.0)
        this.hurt.Add(npcboold);
    }
    else
      this.hurt.Add(npcboold);
    if (this.CurNPCState == NPCState.NPC_Attack)
      return;
    this.updateNPC(NPCState.NPC_Attack);
  }

  public void updateNPC(LineNode npclineNode) => this.fighters.Add(npclineNode);

  public void FighterLeave(LineNode npclineNode)
  {
    for (int index = 0; index < this.fighters.Count; ++index)
    {
      if (this.fighters[index] == npclineNode)
      {
        this.fighters.RemoveAt(index);
        break;
      }
    }
  }

  public void updateNPC(Vector2 pos)
  {
    this.NPCPos.x = pos.x + this.NPCControl.npcposxoffset[(int) this.NPCKindID] * (float) this.NPCDir * DataManager.MapDataController.zoomSize;
    this.NPCPos.y = pos.y + this.NPCControl.npcposyoffset[(int) this.NPCKindID] * DataManager.MapDataController.zoomSize;
    this.NPCTransform.position = new Vector3(this.NPCPos.x + this.posxoffset, this.NPCPos.y + this.posyoffset, 37f);
  }

  public void updateNPC(float posx, float posy)
  {
    this.NPCPos.x = posx;
    this.NPCPos.y = posy;
    this.NPCTransform.position = new Vector3(posx, posy, 37f);
  }

  public void releaseNPC()
  {
    if (this.NPCTableID < 262144U)
    {
      if (DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCTableID].pointKind == (byte) 10)
      {
        DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCTableID].pointKind = (byte) 0;
        ushort tableId = DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCTableID].tableID;
        if ((int) tableId < DataManager.MapDataController.NPCPointTable.Length)
          DataManager.MapDataController.NPCPointTableIDpool.despawn((int) tableId);
      }
    }
    else if (this.NPCTid < (ushort) 2048)
      DataManager.MapDataController.NPCPointTableIDpool.despawn((int) this.NPCTid);
    this.NPCTableID = 262144U;
    this.NPCTid = (ushort) 2048;
  }

  public void SetActive(bool active)
  {
    if (active)
    {
      this.CurNPCState = NPCState.NPC_Idle;
      this.NPCSheetID = (byte) UnityEngine.Random.Range(0, this.NPCAnimation[(int) this.CurNPCState].Length);
      this.AnimationSpeed = 15f;
      this.AnimationTimer = 1f;
      this.posxoffset = this.posyoffset = this.HurtTimer = this.HitTimer = this.DieTimer = 0.0f;
    }
    else
      this.Clear();
    this.NPCGameObject.SetActive(active);
  }

  public void Run()
  {
    this.AnimationTimer -= Time.deltaTime * this.AnimationSpeed;
    if ((double) this.AnimationTimer < 0.0)
    {
      this.AnimationTimer = 1f;
      this.NPCSpriteRenderer.sprite = this.NPCAnimation[(int) this.CurNPCState][(int) this.NPCSheetID];
      if (this.CurNPCState == NPCState.NPC_Attack)
      {
        if ((int) this.NPCSheetID == (int) this.HitFrame)
          this.HIT();
        if ((int) ++this.NPCSheetID >= this.NPCAnimation[0].Length)
        {
          this.NPCSheetID = (byte) 0;
          if (this.fighters.Count == 0)
            this.updateNPC(NPCState.NPC_Idle);
        }
      }
      else if ((int) ++this.NPCSheetID >= this.NPCAnimation[(int) this.CurNPCState].Length)
      {
        if (this.CurNPCState == NPCState.NPC_Die)
        {
          --this.NPCSheetID;
          this.DieTimer = 1f;
          this.AnimationSpeed = 0.0f;
        }
        else
          this.NPCSheetID = (byte) 0;
      }
    }
    if ((double) this.HurtTimer != 0.0)
    {
      this.HurtTimer -= Time.deltaTime;
      Vector3 npcPos = (Vector3) this.NPCPos with
      {
        z = 37f
      };
      if ((double) this.HurtTimer <= 0.0)
      {
        this.HurtTimer = 0.0f;
        this.AnimationSpeed = 15f;
        this.NPCTransform.position = npcPos;
        this.posyoffset = this.posxoffset = 0.0f;
      }
      else
      {
        this.posxoffset = Mathf.PerlinNoise(this.posxoffset * 9f, 0.0f) - 0.5f;
        this.posyoffset = Mathf.PerlinNoise(this.posyoffset * 9f, 0.0f) - 0.5f;
        npcPos.x += this.posxoffset;
        npcPos.y += this.posyoffset;
        this.NPCTransform.position = npcPos;
      }
    }
    if ((double) this.HitTimer != 0.0)
    {
      this.HitTimer -= Time.deltaTime;
      if ((double) this.HitTimer <= 0.0)
      {
        this.HitTimer = 0.0f;
        this.AnimationSpeed = 15f;
      }
    }
    if ((double) this.DieTimer != 0.0)
    {
      this.DieTimer -= Time.deltaTime;
      if ((double) this.DieTimer <= 0.0)
      {
        this.DieTimer = 0.0f;
        this.NPCSheetID = (byte) 0;
        this.AnimationSpeed = 0.0f;
        this.fighters.Clear();
        this.HurtClear();
        this.releaseNPC();
        if (this.NPCControl != null)
          this.NPCControl.pushNPC((int) this.row, (int) this.col);
        DataManager.msgBuffer[0] = (byte) 90;
        DataManager.msgBuffer[1] = this.row;
        DataManager.msgBuffer[2] = this.col;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      }
    }
    for (int index = 0; index < this.damage.Count; ++index)
      this.damage[index].Tick(Time.deltaTime);
  }

  public void Hurt()
  {
    if (this.CurNPCState == NPCState.NPC_Die)
      return;
    if (this.CurNPCState != NPCState.NPC_Attack)
      this.updateNPC(NPCState.NPC_Attack);
    ushort index = this.NPCTid;
    if (this.NPCTableID < 262144U && DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCTableID].pointKind == (byte) 10)
      index = DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCTableID].tableID;
    if (this.hurt.Count == 0 && (int) index < DataManager.MapDataController.NPCPointTable.Length && (double) DataManager.MapDataController.NPCPointTable[(int) index].Blood == 0.0 || this.hurt.Count > 0 && (double) this.hurt[0] == 0.0)
    {
      this.Die();
    }
    else
    {
      this.AnimationSpeed = 0.0f;
      if (this.hurt.Count > 0)
      {
        float num = this.hurt[0];
        if ((double) num >= 0.0 && this.NPCControl != null && this.NPCTableID < 262144U && DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCTableID].pointKind == (byte) 10 && (int) index < DataManager.MapDataController.NPCPointTable.Length)
        {
          Damage damage = this.NPCControl.pullDamage();
          damage.updateDamage(this);
          float DamageValue = DataManager.MapDataController.NPCPointTable[(int) index].Blood - num;
          DataManager.MapDataController.NPCPointTable[(int) index].Blood = this.hurt[0];
          damage.updateDamage(DamageValue);
          if (this.damage.Count == 3)
          {
            this.NPCControl.pushDamage(this.damage[0]);
            this.damage.RemoveAt(0);
          }
          this.damage.Add(damage);
          damage.SetActive(true);
          DataManager.msgBuffer[0] = (byte) 88;
          DataManager.msgBuffer[1] = this.row;
          DataManager.msgBuffer[2] = this.col;
          GameConstants.GetBytes(DataManager.MapDataController.NPCPointTable[(int) index].Blood, DataManager.msgBuffer, 3);
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
        this.hurt.RemoveAt(0);
      }
      this.HurtTimer = 0.2f;
      this.HitTimer = 0.0f;
      this.posxoffset = Mathf.PerlinNoise(this.NPCTransform.position.x * 9f, 0.0f) - 0.5f;
      this.posyoffset = Mathf.PerlinNoise(this.NPCTransform.position.y * 9f, 0.0f) - 0.5f;
      this.NPCTransform.position = new Vector3(this.NPCPos.x + this.posxoffset, this.NPCPos.y + this.posyoffset, 37f);
    }
  }

  public void Die()
  {
    if (this.hurt.Count > 0)
    {
      float num = this.hurt[0];
      if (this.NPCControl != null)
      {
        ushort index = this.NPCTid;
        if (this.NPCTableID < 262144U && DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCTableID].pointKind == (byte) 10)
          index = DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCTableID].tableID;
        if ((int) index < DataManager.MapDataController.NPCPointTable.Length)
        {
          Damage damage = this.NPCControl.pullDamage();
          damage.updateDamage(this);
          float DamageValue = DataManager.MapDataController.NPCPointTable[(int) index].Blood - num;
          damage.updateDamage(DamageValue);
          if (this.damage.Count == 3)
          {
            this.NPCControl.pushDamage(this.damage[0]);
            this.damage.RemoveAt(0);
          }
          this.damage.Add(damage);
          damage.SetActive(true);
        }
      }
      this.HurtClear();
      if (this.fighters.Count > 0)
        this.fighters.Clear();
    }
    DataManager.msgBuffer[0] = (byte) 88;
    DataManager.msgBuffer[1] = this.row;
    DataManager.msgBuffer[2] = this.col;
    GameConstants.GetBytes(0.0f, DataManager.msgBuffer, 3);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    this.AnimationSpeed = 5f;
    this.posxoffset = this.posyoffset = this.HitTimer = this.HurtTimer = this.DieTimer = 0.0f;
    this.updateNPC(NPCState.NPC_Die);
  }

  public void HIT()
  {
    for (int index = 0; index < this.fighters.Count; ++index)
      this.fighters[index].Shake();
    this.AnimationSpeed = 5f;
    this.HitTimer = 0.2f;
    this.HurtTimer = 0.0f;
    if (this.CurNPCState == NPCState.NPC_Attack)
      return;
    this.updateNPC(NPCState.NPC_Attack);
  }

  public void Clear()
  {
    if (this.NPCControl != null)
    {
      for (int index = 0; index < this.damage.Count; ++index)
        this.NPCControl.pushDamage(this.damage[index]);
    }
    this.damage.Clear();
    this.fighters.Clear();
    this.HurtClear();
  }

  public void DelDamage(Damage deldamage)
  {
    int index1 = -1;
    for (int index2 = 0; index2 < this.damage.Count; ++index2)
    {
      if (deldamage == this.damage[index2])
      {
        index1 = index2;
        break;
      }
    }
    if (index1 > -1)
      this.damage.RemoveAt(index1);
    if (this.NPCControl == null)
      return;
    this.NPCControl.pushDamage(deldamage);
  }

  public void HurtClear()
  {
    if (this.NPCControl != null)
    {
      ushort index1 = this.NPCTid;
      if (this.NPCTableID < 262144U && DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCTableID].pointKind == (byte) 10)
        index1 = DataManager.MapDataController.LayoutMapInfo[(IntPtr) this.NPCTableID].tableID;
      if ((int) index1 < DataManager.MapDataController.NPCPointTable.Length)
      {
        for (int index2 = this.hurt.Count - 1; index2 > -1; --index2)
        {
          if ((double) this.hurt[index2] >= 0.0)
          {
            DataManager.MapDataController.NPCPointTable[(int) index1].Blood = this.hurt[index2];
            break;
          }
        }
      }
    }
    this.hurt.Clear();
  }
}
