// Decompiled with JetBrains decompiler
// Type: LandWalkerManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class LandWalkerManager
{
  public const int LandWalkerFrontLayer = -30;
  public const int LandWalkerBackLayer = -60;
  public const byte ChapterBattle = 200;
  public const byte ChapterBattleLose = 201;
  public const byte ChapterBattleWin = 202;
  public const ushort WinningPerformTime = 1200;
  public const ushort LosingPerformTime = 1200;
  public const ushort MinResultTime = 30;
  public List<ushort> WalkerMarks;
  public WalkerGenData[] WalkerCount;
  public ushort[] WalkerGroupIdx;
  private LandWalkerData walkerData;
  public GameObject WalkerCenter;
  public bool enabled;
  public LandWalkerManager.WalkerBattleState walkerBattleState;
  public static LandWalkerManager.WalkerBattleState performState;
  public static bool StartBattle;
  public static long LastBattleTime;
  public static bool isWinning;
  public long nextPerformTime;
  public byte CastleLevel;
  private List<LandWalker> walkers;
  private List<LandWalker> freeWalkers;
  public float ActionGap = 1f;
  public float nextActionTime;
  public int actionChangeTime = 1;
  public int BattleTime = 30;
  private static LandWalkerManager _instance;
  private bool firstUpdate = true;
  public GameObject EffectGameObject;
  public GameObject[] FireEffectGameObject = new GameObject[7];

  public static bool alive => LandWalkerManager._instance != null;

  public static LandWalkerManager Instance
  {
    get
    {
      if (LandWalkerManager._instance == null)
      {
        LandWalkerManager._instance = new LandWalkerManager();
        LandWalkerManager._instance.Awake();
      }
      return LandWalkerManager._instance;
    }
  }

  public static void Release()
  {
    if (LandWalkerManager._instance == null)
      return;
    LandWalkerManager._instance.ClearWalkers();
    for (int index = 0; index < LandWalkerManager._instance.freeWalkers.Count; ++index)
    {
      LandWalkerManager._instance.freeWalkers[index].movingUnit.RecoverUnit();
      LandWalkerManager._instance.freeWalkers[index].movingUnit = (SheetAnimationUnitGroup) null;
    }
    LandWalkerManager._instance.freeWalkers.Clear();
    LandWalkerManager instance = LandWalkerManager._instance;
    LandWalkerManager._instance = (LandWalkerManager) null;
    SheetAnimationUnitGroup.FreeResource();
    if (!((UnityEngine.Object) instance.WalkerCenter != (UnityEngine.Object) null))
      return;
    UnityEngine.Object.Destroy((UnityEngine.Object) instance.WalkerCenter);
  }

  public void OnApplicationQuit() => LandWalkerManager.Release();

  protected void Awake()
  {
    LandWalkerManager._instance = this;
    this.WalkerCenter = new GameObject();
    this.WalkerCenter.name = "LandWalkers";
    this.WalkerCenter.transform.position = Vector3.zero;
    SheetAnimationUnitGroup.InitResource();
    this.walkers = new List<LandWalker>();
    this.freeWalkers = new List<LandWalker>();
    this.WalkerMarks = new List<ushort>();
    this.WalkerGroupIdx = new ushort[DataManager.Instance.LandWalkerData.TableCount + 1];
    int num1 = 0;
    ushort num2 = 0;
    for (ushort Index = 0; (int) Index < DataManager.Instance.LandWalkerData.TableCount; ++Index)
    {
      this.walkerData = DataManager.Instance.LandWalkerData.GetRecordByIndex((int) Index);
      if (num1 != (int) this.walkerData.groupID)
      {
        num1 = (int) this.walkerData.groupID;
        this.WalkerMarks.Add(Index);
        ++num2;
      }
      this.WalkerGroupIdx[(int) Index] = num2;
    }
    this.WalkerCount = new WalkerGenData[this.WalkerMarks.Count];
    LandWalkerManager.SetNewCastleLevel(GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level);
    this.enabled = true;
  }

  public void Update()
  {
    if (!this.enabled)
      return;
    float deltaTime = Time.deltaTime;
    for (int index = 0; index < this.walkers.Count; ++index)
      this.walkers[index].update(deltaTime);
    if ((double) Time.time <= (double) this.nextActionTime)
      return;
    this.nextActionTime = Time.time + this.ActionGap;
    switch (this.walkerBattleState)
    {
      case LandWalkerManager.WalkerBattleState.ChangeForBattle:
        if (DataManager.Instance.ServerTime <= this.nextPerformTime)
          return;
        this.BattleStateChange(LandWalkerManager.WalkerBattleState.BattleNow);
        return;
      case LandWalkerManager.WalkerBattleState.BattleNow:
        if (DataManager.Instance.ServerTime > this.nextPerformTime)
        {
          this.BattleStateChange(LandWalkerManager.WalkerBattleState.ChangeForResult);
          return;
        }
        break;
      case LandWalkerManager.WalkerBattleState.ChangeForResult:
        if (DataManager.Instance.ServerTime <= this.nextPerformTime)
          return;
        this.BattleStateChange(LandWalkerManager.performState);
        return;
      case LandWalkerManager.WalkerBattleState.BattleLose:
      case LandWalkerManager.WalkerBattleState.BattleWin:
        if (DataManager.Instance.ServerTime > this.nextPerformTime)
        {
          this.BattleStateChange(LandWalkerManager.WalkerBattleState.ChangeBackNormal);
          return;
        }
        break;
      case LandWalkerManager.WalkerBattleState.ChangeBackNormal:
        if (DataManager.Instance.ServerTime > this.nextPerformTime)
        {
          this.BattleStateChange(LandWalkerManager.WalkerBattleState.None);
          return;
        }
        break;
    }
    if (this.firstUpdate)
    {
      this.firstUpdate = false;
      this.PreCreateWalker();
    }
    for (ushort index = 0; (int) index < this.WalkerMarks.Count; ++index)
    {
      if ((double) Time.time >= (double) this.WalkerCount[(int) index].NextGenTime)
      {
        this.walkerData = DataManager.Instance.LandWalkerData.GetRecordByIndex((int) this.WalkerMarks[(int) index]);
        switch (this.walkerBattleState)
        {
          case LandWalkerManager.WalkerBattleState.None:
            if ((int) DataManager.StageDataController.StageRecord[2] < (int) this.walkerData.chapter)
            {
              this.WalkerCount[(int) index].NextGenTime = Time.time + 60f;
              continue;
            }
            break;
          case LandWalkerManager.WalkerBattleState.ChangeForBattle:
            return;
          case LandWalkerManager.WalkerBattleState.BattleNow:
            if (this.walkerData.chapter != (byte) 200)
            {
              this.WalkerCount[(int) index].NextGenTime = Time.time + 60f;
              continue;
            }
            break;
          case LandWalkerManager.WalkerBattleState.ChangeForResult:
            return;
          case LandWalkerManager.WalkerBattleState.BattleLose:
            if (this.walkerData.chapter != (byte) 201)
            {
              this.WalkerCount[(int) index].NextGenTime = Time.time + 60f;
              continue;
            }
            break;
          case LandWalkerManager.WalkerBattleState.BattleWin:
            if (this.walkerData.chapter != (byte) 202)
            {
              this.WalkerCount[(int) index].NextGenTime = Time.time + 60f;
              continue;
            }
            break;
          case LandWalkerManager.WalkerBattleState.ChangeBackNormal:
            return;
        }
        if (this.WalkerCount[(int) index].isRepeat)
        {
          this.WalkerCount[(int) index].NextGenTime = Time.time + 60f;
          if (this.WalkerCount[(int) index].Count == (byte) 0 && (int) this.CastleLevel >= (int) this.walkerData.GenData[(int) this.WalkerCount[(int) index].GenBlock].castleLevel)
          {
            this.addWalker(this.WalkerMarks[(int) index], this.WalkerCount[(int) index].GenBlock, true);
            ++this.WalkerCount[(int) index].Count;
          }
        }
        else if ((this.walkerData.GenData[(int) this.WalkerCount[(int) index].GenBlock].GenLimit == (byte) 0 || (int) this.WalkerCount[(int) index].Count < (int) this.walkerData.GenData[(int) this.WalkerCount[(int) index].GenBlock].GenLimit) && (int) this.CastleLevel >= (int) this.walkerData.GenData[(int) this.WalkerCount[(int) index].GenBlock].castleLevel)
        {
          this.WalkerCount[(int) index].NextGenTime = (float) ((double) Time.time + (double) this.walkerData.GenData[(int) this.WalkerCount[(int) index].GenBlock].GenGap + (double) this.walkerData.GenData[(int) this.WalkerCount[(int) index].GenBlock].GenRandom * (double) UnityEngine.Random.value);
          this.addWalker(this.WalkerMarks[(int) index], this.WalkerCount[(int) index].GenBlock);
          ++this.WalkerCount[(int) index].Count;
        }
      }
    }
  }

  public static bool IsBattleFire()
  {
    if (LandWalkerManager.isWinning)
    {
      if (LandWalkerManager.LastBattleTime + 1200L > DataManager.Instance.ServerTime)
        return true;
    }
    else if (LandWalkerManager.LastBattleTime + 1200L > DataManager.Instance.ServerTime)
      return true;
    return false;
  }

  private void PreCreateWalker()
  {
    switch (LandWalkerManager.performState)
    {
      case LandWalkerManager.WalkerBattleState.BattleLose:
        if (LandWalkerManager.LastBattleTime + 1200L > DataManager.Instance.ServerTime)
        {
          if (LandWalkerManager.StartBattle)
          {
            LandWalkerManager.StartBattle = false;
            this.BattleStateChange(LandWalkerManager.WalkerBattleState.ChangeForBattle);
            return;
          }
          this.BattleStateChange(LandWalkerManager.performState);
          return;
        }
        break;
      case LandWalkerManager.WalkerBattleState.BattleWin:
        if (LandWalkerManager.LastBattleTime + 1200L > DataManager.Instance.ServerTime)
        {
          if (LandWalkerManager.StartBattle)
          {
            LandWalkerManager.StartBattle = false;
            this.BattleStateChange(LandWalkerManager.WalkerBattleState.ChangeForBattle);
            return;
          }
          this.BattleStateChange(LandWalkerManager.performState);
          return;
        }
        break;
    }
    for (ushort index = 0; (int) index < this.WalkerMarks.Count; ++index)
    {
      if ((double) UnityEngine.Random.value <= 0.5)
      {
        this.walkerData = DataManager.Instance.LandWalkerData.GetRecordByIndex((int) this.WalkerMarks[(int) index]);
        if ((int) DataManager.StageDataController.StageRecord[2] < (int) this.walkerData.chapter)
          this.WalkerCount[(int) index].NextGenTime = Time.time + 60f;
        else if (!this.WalkerCount[(int) index].isRepeat && (this.walkerData.GenData[(int) this.WalkerCount[(int) index].GenBlock].GenLimit == (byte) 0 || (int) this.WalkerCount[(int) index].Count < (int) this.walkerData.GenData[(int) this.WalkerCount[(int) index].GenBlock].GenLimit) && (int) this.CastleLevel >= (int) this.walkerData.GenData[(int) this.WalkerCount[(int) index].GenBlock].castleLevel)
        {
          this.WalkerCount[(int) index].NextGenTime = (float) ((double) Time.time + (double) this.walkerData.GenData[(int) this.WalkerCount[(int) index].GenBlock].GenGap + (double) this.walkerData.GenData[(int) this.WalkerCount[(int) index].GenBlock].GenRandom * (double) UnityEngine.Random.value);
          LandWalker landWalker = this.addWalker((int) index + 1 >= this.WalkerMarks.Count ? (ushort) UnityEngine.Random.Range((int) this.WalkerMarks[(int) index], DataManager.Instance.LandWalkerData.TableCount - 1) : (ushort) UnityEngine.Random.Range((int) this.WalkerMarks[(int) index], (int) this.WalkerMarks[(int) index + 1] - 1), this.WalkerCount[(int) index].GenBlock);
          landWalker.nowTime = landWalker.totalTime * UnityEngine.Random.value;
          ++this.WalkerCount[(int) index].Count;
        }
      }
    }
  }

  public static void EndAction(LandWalker done)
  {
    ushort num = LandWalkerManager._instance.WalkerGroupIdx[(int) done.idx];
    switch (LandWalkerManager._instance.walkerBattleState)
    {
      case LandWalkerManager.WalkerBattleState.ChangeForBattle:
      case LandWalkerManager.WalkerBattleState.ChangeForResult:
      case LandWalkerManager.WalkerBattleState.ChangeBackNormal:
        --LandWalkerManager._instance.WalkerCount[(int) num - 1].Count;
        LandWalkerManager._instance.walkers.Remove(done);
        LandWalkerManager._instance.freeWalkers.Add(done);
        done.movingUnit.gameObject.SetActive(false);
        done.movingUnit.RecoverUnit();
        break;
      default:
        if ((int) done.idx + 1 < DataManager.Instance.LandWalkerData.TableCount && (int) num == (int) LandWalkerManager._instance.WalkerGroupIdx[(int) done.idx + 1])
        {
          done.movingUnit.RecoverUnit();
          done.setUnit((ushort) ((uint) done.idx + 1U), LandWalkerManager._instance.WalkerCount[(int) num - 1].GenBlock);
          break;
        }
        if (LandWalkerManager._instance.WalkerCount[(int) num - 1].isRepeat)
        {
          done.movingUnit.RecoverUnit();
          done.setUnit(LandWalkerManager._instance.WalkerMarks[(int) num - 1], LandWalkerManager._instance.WalkerCount[(int) num - 1].GenBlock);
          break;
        }
        --LandWalkerManager._instance.WalkerCount[(int) num - 1].Count;
        LandWalkerManager._instance.walkers.Remove(done);
        LandWalkerManager._instance.freeWalkers.Add(done);
        done.movingUnit.gameObject.SetActive(false);
        done.movingUnit.RecoverUnit();
        break;
    }
  }

  public LandWalker addWalker(ushort idx, byte block, bool forceFade = false)
  {
    if (this.freeWalkers.Count > 0)
    {
      LandWalker freeWalker = this.freeWalkers[0];
      this.freeWalkers.RemoveAt(0);
      this.walkers.Add(freeWalker);
      freeWalker.setUnit(idx, block, forceFade);
      return freeWalker;
    }
    LandWalker landWalker = new LandWalker(this.WalkerCenter.transform);
    this.walkers.Add(landWalker);
    landWalker.setUnit(idx, block, forceFade);
    return landWalker;
  }

  public void ClearWalkers()
  {
    if ((UnityEngine.Object) this.EffectGameObject != (UnityEngine.Object) null)
      ParticleManager.Instance.DeSpawn(this.EffectGameObject);
    for (int index = 0; index < this.FireEffectGameObject.Length; ++index)
    {
      if ((UnityEngine.Object) this.FireEffectGameObject[index] != (UnityEngine.Object) null)
        ParticleManager.Instance.DeSpawn(this.FireEffectGameObject[index]);
    }
    for (int index = 0; index < this.walkers.Count; ++index)
    {
      this.walkers[index].movingUnit.gameObject.SetActive(false);
      this.freeWalkers.Add(this.walkers[index]);
    }
    this.walkers.Clear();
  }

  public static void SetNewCastleLevel(byte level)
  {
    if (LandWalkerManager._instance == null)
      return;
    LandWalkerManager._instance.CastleLevel = level;
    for (int index1 = 0; index1 < LandWalkerManager._instance.WalkerMarks.Count; ++index1)
    {
      LandWalkerManager._instance.walkerData = DataManager.Instance.LandWalkerData.GetRecordByIndex((int) LandWalkerManager._instance.WalkerMarks[index1]);
      LandWalkerManager._instance.WalkerCount[index1].isRepeat = LandWalkerManager._instance.walkerData.NeverGone != (byte) 0;
      for (byte index2 = 0; index2 < (byte) 4; ++index2)
      {
        if ((int) level >= (int) LandWalkerManager._instance.walkerData.GenData[(int) index2].castleLevel && LandWalkerManager._instance.walkerData.GenData[(int) index2].castleLevel != (byte) 0)
        {
          LandWalkerManager._instance.WalkerCount[index1].GenBlock = index2;
          LandWalkerManager._instance.WalkerCount[index1].NextGenTime = (float) ((double) Time.time + (double) LandWalkerManager._instance.walkerData.GenData[(int) LandWalkerManager._instance.WalkerCount[index1].GenBlock].GenGap + (double) LandWalkerManager._instance.walkerData.GenData[(int) LandWalkerManager._instance.WalkerCount[index1].GenBlock].GenRandom * (double) UnityEngine.Random.value);
        }
      }
    }
  }

  public static void HappenAttack(long HappenTime, bool isWinning)
  {
    if (LandWalkerManager.LastBattleTime == HappenTime)
      return;
    LandWalkerManager.performState = !isWinning ? LandWalkerManager.WalkerBattleState.BattleLose : LandWalkerManager.WalkerBattleState.BattleWin;
    if (LandWalkerManager._instance != null)
      LandWalkerManager._instance.BattleStateChange(LandWalkerManager.WalkerBattleState.ChangeForBattle);
    else
      LandWalkerManager.StartBattle = true;
    LandWalkerManager.isWinning = isWinning;
    LandWalkerManager.LastBattleTime = HappenTime;
  }

  public static void SetActionNormal()
  {
    LandWalkerManager.LastBattleTime = 0L;
    if (LandWalkerManager._instance == null)
      return;
    LandWalkerManager._instance.BattleStateChange(LandWalkerManager.WalkerBattleState.ChangeBackNormal);
  }

  public void BattleStateChange(LandWalkerManager.WalkerBattleState battleState)
  {
    this.walkerBattleState = battleState;
    this.firstUpdate = false;
    switch (battleState)
    {
      case LandWalkerManager.WalkerBattleState.None:
        this.nextPerformTime = 0L;
        for (int index = 0; index < this.walkers.Count; ++index)
          this.walkers[index].SetFade();
        if ((UnityEngine.Object) this.EffectGameObject != (UnityEngine.Object) null)
          ParticleManager.Instance.DeSpawn(this.EffectGameObject);
        for (int index = 0; index < this.FireEffectGameObject.Length; ++index)
        {
          if ((UnityEngine.Object) this.FireEffectGameObject[index] != (UnityEngine.Object) null)
            ParticleManager.Instance.DeSpawn(this.FireEffectGameObject[index]);
        }
        break;
      case LandWalkerManager.WalkerBattleState.ChangeForBattle:
      case LandWalkerManager.WalkerBattleState.ChangeForResult:
      case LandWalkerManager.WalkerBattleState.ChangeBackNormal:
        this.nextPerformTime = DataManager.Instance.ServerTime + (long) this.actionChangeTime;
        for (int index = 0; index < this.walkers.Count; ++index)
          this.walkers[index].SetFade();
        if ((UnityEngine.Object) this.EffectGameObject != (UnityEngine.Object) null)
          ParticleManager.Instance.DeSpawn(this.EffectGameObject);
        for (int index = 0; index < this.FireEffectGameObject.Length; ++index)
        {
          if ((UnityEngine.Object) this.FireEffectGameObject[index] != (UnityEngine.Object) null)
            ParticleManager.Instance.DeSpawn(this.FireEffectGameObject[index]);
        }
        break;
      case LandWalkerManager.WalkerBattleState.BattleNow:
        this.nextPerformTime = DataManager.Instance.ServerTime + (long) this.BattleTime;
        break;
      case LandWalkerManager.WalkerBattleState.BattleLose:
        this.nextPerformTime = Math.Max(DataManager.Instance.ServerTime + 30L, LandWalkerManager.LastBattleTime + 1200L);
        this.PlayEffect(false);
        break;
      case LandWalkerManager.WalkerBattleState.BattleWin:
        this.nextPerformTime = Math.Max(DataManager.Instance.ServerTime + 30L, LandWalkerManager.LastBattleTime + 1200L);
        this.PlayEffect(true);
        break;
    }
    for (ushort index = 0; (int) index < this.WalkerMarks.Count; ++index)
    {
      this.walkerData = DataManager.Instance.LandWalkerData.GetRecordByIndex((int) this.WalkerMarks[(int) index]);
      this.WalkerCount[(int) index].NextGenTime = !this.WalkerCount[(int) index].isRepeat ? Time.time + 3f * UnityEngine.Random.value : Time.time;
    }
  }

  public void PlayEffect(bool isFireWork)
  {
    if (isFireWork)
    {
      BuildManorData recordByKey = DataManager.Instance.BuildManorData.GetRecordByKey((ushort) 0);
      float x = (float) ((recordByKey.bPosionX <= (ushort) 30000 ? (double) recordByKey.bPosionX : (double) recordByKey.bPosionX - (double) ushort.MaxValue) * 0.0099999997764825821);
      float num1 = (float) ((recordByKey.bPosionY <= (ushort) 32768 ? (double) recordByKey.bPosionY : (double) recordByKey.bPosionY - (double) ushort.MaxValue) * 0.0099999997764825821);
      float num2 = (float) ((recordByKey.bPosionZ <= (ushort) 32768 ? (double) recordByKey.bPosionZ : (double) recordByKey.bPosionZ - (double) ushort.MaxValue) * 0.0099999997764825821);
      if ((UnityEngine.Object) this.EffectGameObject != (UnityEngine.Object) null)
        ParticleManager.Instance.DeSpawn(this.EffectGameObject);
      this.EffectGameObject = ParticleManager.Instance.Spawn((ushort) 358, (Transform) null, new Vector3(x, num1 + 40f, num2 + 20f), 2f, true, false);
      this.EffectGameObject.transform.localRotation = this.EffectGameObject.transform.localRotation with
      {
        eulerAngles = new Vector3(0.0f, 180f, 0.0f)
      };
    }
    else
    {
      float[,] numArray = new float[7, 4]
      {
        {
          -48f,
          19f,
          0.0f,
          3f
        },
        {
          -75f,
          13f,
          13f,
          2f
        },
        {
          16f,
          16f,
          10.5f,
          2f
        },
        {
          -15.8f,
          16f,
          21.5f,
          2f
        },
        {
          -64f,
          12.7f,
          41.3f,
          1f
        },
        {
          31f,
          11f,
          33.3f,
          1f
        },
        {
          22f,
          10.2f,
          53.5f,
          2f
        }
      };
      for (int index = 0; index < 7; ++index)
      {
        if ((UnityEngine.Object) this.FireEffectGameObject[index] != (UnityEngine.Object) null)
          ParticleManager.Instance.DeSpawn(this.FireEffectGameObject[index]);
        this.FireEffectGameObject[index] = ParticleManager.Instance.Spawn((ushort) 370, (Transform) null, new Vector3(numArray[index, 0], numArray[index, 1], numArray[index, 2]), numArray[index, 3], true, false);
        Quaternion localRotation = this.FireEffectGameObject[index].transform.localRotation with
        {
          eulerAngles = new Vector3(0.0f, 180f, 0.0f)
        };
        this.FireEffectGameObject[index].transform.localRotation = localRotation;
      }
    }
  }

  public enum WalkerBattleState
  {
    None,
    ChangeForBattle,
    BattleNow,
    ChangeForResult,
    BattleLose,
    BattleWin,
    ChangeBackNormal,
  }
}
