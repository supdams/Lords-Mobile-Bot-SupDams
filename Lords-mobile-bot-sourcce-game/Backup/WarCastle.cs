// Decompiled with JetBrains decompiler
// Type: WarCastle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable disable
public class WarCastle : ArmyGroup
{
  private StringBuilder StringInstance = new StringBuilder(64);
  public ArmyGroup[] archerDefenser;
  private Transform[] buildList = new Transform[9];
  private AssetBundle[] bundleList = new AssetBundle[9];
  private Transform[] spursList = new Transform[5];
  private Transform[] woodList = new Transform[9];
  private readonly float[] TOWER_Y = new float[4]
  {
    11.62f,
    -11.62f,
    22.47f,
    -22.47f
  };
  private readonly float[] ARCHER_Y = new float[2]
  {
    16.97f,
    -16.97f
  };
  private Vector3[] towerFirePoint = new Vector3[4];
  private readonly Vector3[] towerFireOffset = new Vector3[5]
  {
    new Vector3(0.0f, 0.0f, 0.0f),
    new Vector3(0.0f, 0.5f, 0.0f),
    new Vector3(0.0f, -0.5f, 0.0f),
    new Vector3(0.5f, 0.0f, 0.0f),
    new Vector3(-0.5f, 0.0f, 0.0f)
  };
  private readonly Vector3[] spursPosLowLv = new Vector3[5]
  {
    new Vector3(-0.75f, -6f, 0.0f),
    new Vector3(-0.75f, -6f, 9.13f),
    new Vector3(-0.75f, -6f, -9.13f),
    new Vector3(-0.75f, -6f, 18.26f),
    new Vector3(-0.75f, -6f, -18.26f)
  };
  private readonly Vector3[] spursPosHighLv = new Vector3[5]
  {
    new Vector3(-6.75f, -5f, 0.0f),
    new Vector3(-8.47f, -5f, 9.13f),
    new Vector3(-9.34f, -5f, -9.13f),
    new Vector3(-5.14f, -5f, 18.26f),
    new Vector3(-6.75f, -5f, -18.26f)
  };
  private readonly Vector3[] woodPos = new Vector3[9]
  {
    new Vector3(-2.5f, 6f, 0.0f),
    new Vector3(-2.5f, 6f, -12f),
    new Vector3(-2.5f, 6f, 12f),
    new Vector3(-2.5f, 6f, -3f),
    new Vector3(-2.5f, 6f, 3f),
    new Vector3(-2.5f, 6f, -15f),
    new Vector3(-2.5f, 6f, 15f),
    new Vector3(-2.5f, 6f, -9f),
    new Vector3(-2.5f, 6f, 9f)
  };
  private Transform castleRoot;
  private TrapBehavior suprsBehavior;
  private TrapBehavior woodBehavior;
  private List<GameObject> fireParticle = new List<GameObject>(4);
  private int towerDisplayFlag;
  private int ActiveTowerCount;
  private int DestroyedTowerCount;
  private byte FireSoundKey = 10;

  public WarCastle(byte tier, Transform renderRoot, byte[] towerInfo)
  {
    this.groupRoot = new GameObject("Castle")
    {
      transform = {
        position = new Vector3(55f, 0.0f, 15f),
        rotation = Quaternion.LookRotation(Vector3.left)
      }
    }.transform;
    this.buildCastleModel(tier, towerInfo);
    this.GroupKind = EGroupKind.CastleGate;
    this.m_State = ArmyGroup.EGROUPSTATE.IDLE;
  }

  public override WarParticleManager particleManager
  {
    get => this.particleMgr;
    set
    {
      this.particleMgr = value;
      if (this.woodBehavior != null)
        this.woodBehavior.particleManager = this.particleMgr;
      if (this.suprsBehavior == null)
        return;
      this.suprsBehavior.particleManager = this.particleMgr;
    }
  }

  public override int MaxHP
  {
    get => this.m_HP;
    set
    {
      this.m_HP = value;
      this.m_CurHP = this.m_HP;
    }
  }

  public override int CurHP => this.m_CurHP;

  public override int GotHurt
  {
    set
    {
      this.m_CurHP -= value;
      this.m_CurHP = Mathf.Max(this.m_CurHP, 0);
    }
  }

  private void buildCastleModel(byte tier, byte[] towerInfo)
  {
    this.castleRoot = new GameObject().transform;
    this.castleRoot.parent = this.groupRoot;
    this.castleRoot.localPosition = Vector3.zero;
    tier *= (byte) 10;
    byte num1 = 1;
    Vector3 rotate = new Vector3(0.0f, 270f, 0.0f);
    this.StringInstance.Length = 0;
    this.StringInstance.AppendFormat("Role/Castle_{0:000}", (object) ((int) tier + (int) num1));
    AssetBundle assetBundle1 = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
    if ((Object) assetBundle1 != (Object) null)
    {
      this.cacheBuild(this.loadModel(assetBundle1, Vector3.zero, rotate), (byte) 4);
      this.cacheBuild(this.loadModel(assetBundle1, new Vector3(0.0f, 0.0f, 0.1f), new Vector3(0.0f, 90f, 0.0f)), (byte) 5);
      this.bundleList[4] = assetBundle1;
    }
    byte num2 = (byte) ((uint) num1 + 1U);
    this.StringInstance.Length = 0;
    this.StringInstance.AppendFormat("Role/Castle_{0:000}", (object) ((int) tier + (int) num2));
    AssetBundle assetBundle2 = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
    if ((Object) assetBundle2 != (Object) null)
    {
      this.cacheBuild(this.loadModel(assetBundle2, Vector3.zero, rotate), (byte) 6);
      this.bundleList[5] = assetBundle2;
    }
    byte num3 = (byte) ((uint) num2 + 1U);
    for (int index1 = 0; index1 < 4; ++index1)
    {
      if (towerInfo[index1] != (byte) 0)
      {
        byte index2 = (byte) ((uint) towerInfo[index1] - 1U);
        if ((Object) this.bundleList[(int) index2] == (Object) null)
        {
          this.StringInstance.Length = 0;
          this.StringInstance.AppendFormat("Role/Castle_{0:000}", (object) ((int) towerInfo[index1] * 10 + (int) num3));
          this.bundleList[(int) index2] = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
        }
        GameObject go = (GameObject) null;
        if ((Object) this.bundleList[(int) index2] != (Object) null)
        {
          go = this.loadModel(this.bundleList[(int) index2], new Vector3(0.0f, 0.0f, this.TOWER_Y[index1]), rotate);
          this.cacheBuild(go, (byte) (0 + index1));
        }
        if ((Object) go != (Object) null)
        {
          Vector3 vector3 = go.transform.position + new Vector3(-3f, 5f, -1f);
          this.towerFirePoint[index1] = vector3;
          ++this.ActiveTowerCount;
        }
      }
    }
    byte num4 = (byte) ((uint) num3 + 1U);
    this.StringInstance.Length = 0;
    this.StringInstance.AppendFormat("Role/Castle_{0:000}", (object) ((int) tier + (int) num4));
    AssetBundle assetBundle3 = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
    if ((Object) assetBundle3 != (Object) null)
    {
      for (int index = 0; index < 2; ++index)
        this.cacheBuild(this.loadModel(assetBundle3, new Vector3(0.0f, 0.0f, this.ARCHER_Y[index]), rotate), (byte) (7 + index));
      this.bundleList[6] = assetBundle3;
    }
    byte num5 = (byte) ((uint) num4 + 1U);
    if (towerInfo[4] != (byte) 0)
    {
      this.StringInstance.Length = 0;
      this.StringInstance.AppendFormat("Role/Castle_{0:000}", (object) ((int) towerInfo[4] * 10 + (int) num5));
      AssetBundle assetBundle4 = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
      if ((Object) assetBundle4 != (Object) null)
      {
        Vector3[] vector3Array = this.spursPosLowLv;
        if (towerInfo[4] == (byte) 2 || towerInfo[4] == (byte) 4)
          vector3Array = this.spursPosHighLv;
        for (int index = 0; index < 5; ++index)
          this.spursList[index] = this.loadModel(assetBundle4, vector3Array[index], rotate).transform;
        this.bundleList[7] = assetBundle4;
      }
      this.suprsBehavior = towerInfo[4] == (byte) 2 || towerInfo[4] == (byte) 4 ? (TrapBehavior) new SuprsHighLv(this.spursPosHighLv) : (TrapBehavior) new SuprsLowLv(this.spursPosLowLv);
    }
    byte num6 = (byte) ((uint) num5 + 1U);
    if (towerInfo[5] == (byte) 0)
      return;
    this.StringInstance.Length = 0;
    this.StringInstance.AppendFormat("Role/Castle_{0:000}", (object) ((int) towerInfo[5] * 10 + (int) num6));
    AssetBundle assetBundle5 = AssetManager.GetAssetBundle(this.StringInstance.ToString(), 0L);
    if (!((Object) assetBundle5 != (Object) null))
      return;
    byte unitCount = towerInfo[5] == (byte) 1 || towerInfo[5] == (byte) 3 ? (byte) 9 : (byte) 3;
    for (int index = 0; index < (int) unitCount; ++index)
    {
      GameObject gameObject = this.loadModel(assetBundle5, this.woodPos[index], rotate);
      this.woodList[index] = gameObject.transform;
      gameObject.SetActive(false);
    }
    this.bundleList[8] = assetBundle5;
    this.woodBehavior = (TrapBehavior) new WoodRun(this.woodPos, unitCount);
  }

  private GameObject loadModel(AssetBundle bundle, Vector3 pos, Vector3 rotate)
  {
    GameObject gameObject = Object.Instantiate(bundle.mainAsset) as GameObject;
    int num = 2 + LightmapManager.Instance.SceneLightmapSize;
    MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
    ESheetMeshTexKind kind = !WarManager.IsNpcModeEnable ? ESheetMeshTexKind.WAR_BLUE : ESheetMeshTexKind.WAR_GRAY;
    component.material = SheetAnimInfo.GetMaterial(kind);
    component.lightmapIndex = num;
    gameObject.transform.parent = this.castleRoot;
    gameObject.transform.localPosition = pos;
    gameObject.transform.Rotate(rotate);
    return gameObject;
  }

  private void cacheBuild(GameObject go, byte idx)
  {
    if (!((Object) go != (Object) null) || idx >= (byte) 9)
      return;
    this.buildList[(int) idx] = go.transform;
  }

  public override void Update(float deltaTime, float moveDeltaTime)
  {
    if (this.m_State == ArmyGroup.EGROUPSTATE.DESTROYING)
    {
      float x = Random.Range(-0.5f, 0.5f);
      float z = Random.Range(-0.5f, 0.5f);
      float y = this.castleRoot.localPosition.y - deltaTime * 5.3f;
      this.castleRoot.localPosition = new Vector3(x, y, z);
      this.MoveSpeed += 30f * deltaTime;
      if ((double) this.MoveSpeed <= 20.0)
        this.castleRoot.Rotate(0.0f, 0.0f, -30f * deltaTime);
      if ((double) y > -16.0)
        return;
      this.m_State = ArmyGroup.EGROUPSTATE.DESTROYED;
    }
    else
    {
      if (this.suprsBehavior != null)
        this.suprsBehavior.Update(this.spursList, deltaTime);
      if (this.woodBehavior != null)
        this.woodBehavior.Update(this.woodList, deltaTime);
      if (this.towerDisplayFlag == 0)
        return;
      for (int index = 0; index < 4; ++index)
      {
        if ((this.towerDisplayFlag >> index & 1) != 0)
        {
          Vector3 localPosition = this.buildList[index].localPosition;
          localPosition.y -= deltaTime * 5f;
          float x = Random.Range(-0.5f, 0.5f);
          float num = Random.Range(-0.5f, 0.5f);
          Vector3 vector3 = new Vector3(x, localPosition.y, this.TOWER_Y[index] + num);
          this.buildList[index].localPosition = vector3;
          this.buildList[index].Rotate(20f * deltaTime, 0.0f, 0.0f);
          if ((double) localPosition.y <= -16.0)
            this.towerDisplayFlag ^= 1 << index;
        }
      }
    }
  }

  public override void Destroy()
  {
    for (int index = 0; index < 9; ++index)
    {
      if ((Object) this.buildList[index] != (Object) null)
        Object.Destroy((Object) this.buildList[index].gameObject);
    }
    for (int index = 0; index < this.bundleList.Length; ++index)
    {
      if ((Object) this.bundleList[index] != (Object) null)
        this.bundleList[index].Unload(true);
    }
    this.buildList = (Transform[]) null;
    this.bundleList = (AssetBundle[]) null;
    if ((Object) this.castleRoot != (Object) null)
      Object.Destroy((Object) this.castleRoot.gameObject);
    this.suprsBehavior = (TrapBehavior) null;
    this.woodBehavior = (TrapBehavior) null;
    base.Destroy();
  }

  public override void AllDie(int param = 0)
  {
    if (param == 0)
    {
      base.AllDie();
      for (int index = 0; index < this.spursList.Length; ++index)
      {
        if ((Object) this.spursList[index] != (Object) null)
          this.spursList[index].gameObject.SetActive(false);
      }
      if (this.suprsBehavior != null)
        this.suprsBehavior.setState(ETrapState.STOP);
      if (this.woodBehavior != null)
        this.woodBehavior.setState(ETrapState.STOP);
      for (int index = 0; index < this.woodList.Length; ++index)
      {
        if ((Object) this.woodList[index] != (Object) null)
          this.woodList[index].gameObject.SetActive(false);
      }
      this.particleManager.Spawn((ushort) 2007, this.groupRoot, this.groupRoot.transform.position + new Vector3(-3f, 3f, 0.0f), 1f, true, false);
      for (int index = 0; index < this.fireParticle.Count; ++index)
        this.particleManager.DeSpawn(this.fireParticle[index]);
      this.fireParticle.Clear();
      if (this.FireSoundKey < (byte) 21)
        AudioManager.Instance.StopSFX(this.FireSoundKey);
      AudioManager.Instance.PlaySFX((ushort) 20010, PlayObj: this.groupRoot);
      this.MoveSpeed = 0.0f;
      this.m_State = ArmyGroup.EGROUPSTATE.DESTROYING;
    }
    else
    {
      if (param <= 0 || param > 4)
        return;
      Vector3 position = this.buildList[param - 1].position with
      {
        y = 2f
      };
      position.x -= 3f;
      position.z -= 2f;
      GameObject gameObject = this.particleManager.Spawn((ushort) 2008, this.buildList[param - 1], position, 1f, true, false);
      if ((Object) gameObject != (Object) null)
        this.fireParticle.Add(gameObject);
      this.towerDisplayFlag |= 1 << param - 1;
      ++this.DestroyedTowerCount;
      byte Key = 0;
      if (this.FireSoundKey < (byte) 21)
      {
        AudioManager.Instance.PlaySFXLoop((ushort) 20009, out Key, this.groupRoot, SFXEffect.HighPassFilter);
        this.FireSoundKey = Key;
      }
      AudioManager.Instance.SetFireSize((float) this.DestroyedTowerCount / (float) this.ActiveTowerCount);
    }
  }

  public override void FireRange(
    ArmyGroup targetGroup,
    FlyingObjectManager mgr,
    FOKind kind,
    float ms,
    ushort skillID,
    byte param = 0)
  {
    if (this.Target.GroupKind == EGroupKind.CastleGate || param <= (byte) 0 || param > (byte) 4)
      return;
    int currentSoldierCount = this.Target.CurrentSoldierCount;
    for (int index1 = 0; index1 < 5; ++index1)
    {
      Vector3 begin = this.towerFirePoint[(int) param - 1] + this.towerFireOffset[index1];
      int index2 = index1 < currentSoldierCount ? index1 : currentSoldierCount - 1;
      mgr.addFlyingObject(kind, begin, this.Target.soldiers[index2].transform, ms, new Vector3(0.0f, 1f, 0.0f), CurveType: ChaseType.Straight);
    }
  }

  public override void Attack(ArmyGroup target, bool bForceRetarget = false, byte param = 0)
  {
    if (param == (byte) 5 && this.suprsBehavior != null)
      this.suprsBehavior.setState(ETrapState.START);
    if (param != (byte) 6 || this.woodBehavior == null)
      return;
    this.woodBehavior.setState(ETrapState.START);
  }

  public void cacheTrapHitPos(byte trapKind, ArmyGroup ag)
  {
    TrapBehavior trapBehavior = trapKind != (byte) 0 ? this.woodBehavior : this.suprsBehavior;
    if (trapBehavior == null)
      return;
    int currentSoldierCount = ag.CurrentSoldierCount;
    Vector3 zero = Vector3.zero;
    for (int index = 0; index < currentSoldierCount; ++index)
      zero += ag.soldiers[index].transform.position;
    Vector3 vector3 = zero / (float) currentSoldierCount;
    trapBehavior.targetPosCache.Add(vector3);
  }

  public override void Reset()
  {
    this.groupRoot.gameObject.SetActive(true);
    this.castleRoot.localPosition = Vector3.zero;
    this.castleRoot.rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1f);
    this.towerDisplayFlag = 0;
    for (int index = 0; index < 4; ++index)
    {
      if ((Object) this.buildList[index] != (Object) null)
      {
        this.buildList[index].localPosition = new Vector3(0.0f, 0.0f, this.TOWER_Y[index]);
        this.buildList[index].rotation = new Quaternion(0.0f, 0.0f, 0.0f, 1f);
        this.buildList[index].Rotate(0.0f, 270f, 0.0f);
      }
    }
    for (int index = 0; index < this.fireParticle.Count; ++index)
      this.particleManager.DeSpawn(this.fireParticle[index]);
    this.fireParticle.Clear();
    if (this.FireSoundKey >= (byte) 21)
      return;
    AudioManager.Instance.StopSFX(this.FireSoundKey);
  }
}
