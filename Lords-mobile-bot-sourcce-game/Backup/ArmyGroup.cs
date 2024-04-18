// Decompiled with JetBrains decompiler
// Type: ArmyGroup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ArmyGroup
{
  public int RowCount = 3;
  public int SoldierCount = 9;
  public int CurrentSoldierCount = 9;
  public int SoldierCountDefault;
  public int DeadCount;
  public Vector3 targetPosition = Vector3.zero;
  protected Vector3 m_lastTargetPos;
  public byte TextureColor;
  protected static Vector3 Vec3Instance = Vector3.zero;
  protected static Quaternion QuatInstance = new Quaternion(0.0f, 0.0f, 0.0f, 1f);
  public static byte[] ConstSoldierCount = new byte[4]
  {
    (byte) 12,
    (byte) 9,
    (byte) 6,
    (byte) 1
  };
  public static Vector3 ConstHeroOffset = new Vector3(0.0f, 0.0f, 3f);
  public static float[] ConstSoldierSpeed = new float[5]
  {
    5.5f,
    4.5f,
    7f,
    4.5f,
    0.0f
  };
  public Vector3[] soldierArray;
  public Soldier[] soldiers;
  public Soldier heroSoldier;
  protected ArmyGroup.EGROUPSTATE m_State = ArmyGroup.EGROUPSTATE.IDLE;
  protected ArmyGroup.EGROUPSTATE lastState = ArmyGroup.EGROUPSTATE.IDLE;
  public ArmyGroup Target;
  public Soldier SoldierTarget;
  public Transform groupRoot;
  public Quaternion m_Direction = Quaternion.identity;
  public static FSMManager FSMMgr = (FSMManager) null;
  public EGroupKind GroupKind = EGroupKind.Infantry;
  public float MoveSpeed = 4.5f;
  public Vector3 CenterWithTarget = Vector3.zero;
  public uint OnceFlag;
  public byte Side;
  public byte Tier;
  public byte Index;
  public byte DataIndex;
  private int lightmapIndex;
  public int SoldierFlagCount;
  public uint CommonFlag;
  public float CommonTimer;
  public bool HasHeroDisplay;
  public ushort heroSoldierID;
  public ushort heroSoldierFO;
  public ushort heroSoldierSkillFO;
  private bool hasLord;
  public bool bAttackMode = true;
  public bool bInsideSkill;
  public ArmyGroup AttackBy;
  public bool ForceEnterFSM;
  protected Vector3 hitPointOffset = Vector3.zero;
  public int m_HP = 100;
  public int m_CurHP;
  public int HpDefault;
  protected WarParticleManager particleMgr;
  protected static List<byte> RandomPosList = new List<byte>(16);
  public static Dictionary<ArmyGroup.EGROUPSTATE, EStateName> m_FSMMap = (Dictionary<ArmyGroup.EGROUPSTATE, EStateName>) null;
  public bool bNpcMode;

  protected ArmyGroup()
  {
  }

  public ArmyGroup(
    EGroupKind groupKind,
    byte tier,
    Transform renderRoot,
    byte side,
    byte texColor,
    ushort heroID,
    byte index,
    bool hasLord,
    float scaleFactor = 1f)
  {
    if (ArmyGroup.m_FSMMap == null)
    {
      ArmyGroup.m_FSMMap = new Dictionary<ArmyGroup.EGROUPSTATE, EStateName>();
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.MOVING, EStateName.MOVING);
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.RETREAT_MOVING_SPREAD, EStateName.MOVING);
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.RETREAT_MOVING, EStateName.MOVING);
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.FIGHT, EStateName.TRYFIGHT);
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.FIGHT_IMMEDIATE, EStateName.MELEE_FIGHT_IMMEDIATE);
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.IDLE_WITHOUT_CLUMP, EStateName.IDLE_WITHOUT_CLUMP);
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.VICTORY, EStateName.VICTORY);
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN, EStateName.MOVE_OUTOF_TOWN);
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL, EStateName.JUMP_FROM_WALL);
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.GO_CAPTIVING, EStateName.GO_CAPTIVING);
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.ATTACKER_RUN_AWAY, EStateName.ATTACKER_RUN_AWAY);
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.DEFENSER_CHASING, EStateName.DEFENSER_CHASING);
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.DEFENSER_RUN_AWAY, EStateName.DEFENSER_RUN_AWAY);
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.ATTACKER_CHASING, EStateName.ATTACKER_CHASING);
      ArmyGroup.m_FSMMap.Add(ArmyGroup.EGROUPSTATE.IDLE, EStateName.IDLE);
    }
    if (ArmyGroup.FSMMgr == null)
      ArmyGroup.FSMMgr = FSMManager.Instance;
    this.bNpcMode = false;
    if (WarManager.IsNpcModeEnable)
    {
      if (heroID != (ushort) 0)
      {
        Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(heroID);
        if ((int) recordByKey.HeroKey == (int) heroID && recordByKey.Summary != (ushort) 0)
          this.bNpcMode = true;
      }
      if (side != (byte) 0)
        texColor = (byte) 2;
    }
    this.DataIndex = index;
    this.Side = side;
    this.Tier = tier;
    this.GroupKind = groupKind;
    this.TextureColor = texColor;
    this.groupRoot = new GameObject(nameof (ArmyGroup)).transform;
    if (FSMManager.Instance.bIsSiegeMode && this.Side == (byte) 1)
      this.bAttackMode = false;
    switch (groupKind)
    {
      case EGroupKind.Archer:
        this.hitPointOffset.y = 1f;
        break;
      case EGroupKind.Cavalry:
        this.RowCount = 2;
        break;
      case EGroupKind.Catapults:
        this.RowCount = 1;
        this.hitPointOffset.y = 1.5f;
        break;
    }
    int index1 = (int) (groupKind - (byte) 1);
    this.MoveSpeed = ArmyGroup.ConstSoldierSpeed[index1];
    if (!this.bNpcMode)
    {
      this.SoldierCount = (int) ArmyGroup.ConstSoldierCount[index1];
      this.CurrentSoldierCount = (int) ArmyGroup.ConstSoldierCount[index1];
      this.SoldierCountDefault = this.SoldierCount;
      this.soldierArray = new Vector3[this.SoldierCount];
      this.soldiers = new Soldier[this.SoldierCount];
      this.setupSoldierArray(groupKind);
    }
    else
    {
      this.SoldierCount = 1;
      this.CurrentSoldierCount = 1;
      this.SoldierCountDefault = 1;
      this.soldierArray = new Vector3[this.SoldierCount];
      this.soldiers = new Soldier[this.SoldierCount];
      this.soldierArray[0] = Vector3.zero;
    }
    float num1 = scaleFactor;
    int num2 = 2 + LightmapManager.Instance.SceneLightmapSize;
    this.groupRoot.localScale = new Vector3(num1 * 1f, num1 * 1f, num1 * 1f);
    for (int index2 = 0; index2 < this.SoldierCount; ++index2)
    {
      this.soldiers[index2] = new Soldier((byte) groupKind, tier, texColor);
      GameObject gameObject = this.soldiers[index2].gameObject;
      this.soldiers[index2].renderer.lightmapIndex = num2;
      this.soldiers[index2].Parent = this;
      this.soldiers[index2].Index = (ushort) index2;
      this.soldiers[index2].FSMController = ArmyGroup.FSMMgr.getState(EStateName.IDLE);
      this.soldiers[index2].pListener = new Soldier.ParentListener(this.SoldierCallBack);
      gameObject.transform.parent = renderRoot;
      Vector3 vector3 = this.targetPosition + this.groupRoot.TransformPoint(this.soldierArray[index2]);
      gameObject.transform.position = vector3;
      gameObject.transform.rotation = Quaternion.LookRotation(this.groupRoot.forward);
      gameObject.transform.localScale = new Vector3(num1, num1, num1);
      if (this.bNpcMode)
      {
        this.soldiers[index2].renderer.enabled = false;
        this.soldiers[index2].EnableShadow = false;
      }
    }
    this.lightmapIndex = num2;
    if (heroID != (ushort) 0)
    {
      this.heroSoldier = (Soldier) new Lord(heroID, (byte) groupKind, tier, this.Side, hasLord, this.DataIndex);
      this.heroSoldier.renderer.lightmapIndex = (int) byte.MaxValue;
      this.heroSoldier.Parent = this;
      this.heroSoldier.Index = (ushort) byte.MaxValue;
      this.heroSoldier.transform.parent = renderRoot;
      this.heroSoldier.transform.position = this.groupRoot.TransformPoint(this.HeroOffset);
      this.heroSoldier.FSMController = ArmyGroup.FSMMgr.getState(EStateName.IDLE);
      this.HasHeroDisplay = true;
    }
    this.m_State = ArmyGroup.EGROUPSTATE.IDLE;
  }

  public ArmyGroup.EGROUPSTATE State
  {
    get => this.m_State;
    set => this.m_State = value;
  }

  public bool HasLord
  {
    get => this.hasLord;
    set
    {
      this.hasLord = value;
      if (this.heroSoldier == null)
        return;
      this.heroSoldier.IsLord = value;
    }
  }

  public Vector3 CurrentHitPoint => this.groupRoot.position + this.hitPointOffset;

  public virtual int MaxHP
  {
    get => this.m_HP;
    set
    {
      this.m_HP = value;
      this.m_CurHP = this.m_HP;
      this.HpDefault = this.m_HP;
      if (this.bNpcMode || this.m_HP >= (int) ArmyGroup.ConstSoldierCount[(int) (this.GroupKind - (byte) 1)])
        return;
      this.SoldierCount = this.m_HP;
      for (int soldierCount = this.SoldierCount; soldierCount < this.SoldierCountDefault; ++soldierCount)
        this.soldiers[soldierCount].gameObject.SetActive(false);
      this.SoldierCountDefault = this.SoldierCount;
      this.CurrentSoldierCount = this.SoldierCount;
    }
  }

  public virtual int CurHP => this.m_CurHP;

  public virtual int GotHurt
  {
    set
    {
      this.m_CurHP -= value;
      this.m_CurHP = Mathf.Max(this.m_CurHP, 0);
      if (this.CurrentSoldierCount <= 1)
        return;
      this.CurrentSoldierCount = (int) ((double) this.m_CurHP / (double) this.m_HP * (double) (this.SoldierCountDefault - 1)) + 1;
    }
  }

  public virtual WarParticleManager particleManager
  {
    get => this.particleMgr;
    set
    {
      this.particleMgr = value;
      if (this.heroSoldier == null || !this.hasLord)
        return;
      this.particleMgr.Spawn(this.TextureColor != (byte) 0 ? (ushort) 2017 : (ushort) 2014, this.heroSoldier.transform, Vector3.zero, 1f, true);
    }
  }

  public Vector3 HeroOffset => this.bNpcMode ? Vector3.zero : ArmyGroup.ConstHeroOffset;

  private byte getRandowPos()
  {
    int index = Random.Range(0, ArmyGroup.RandomPosList.Count);
    byte randomPos = ArmyGroup.RandomPosList[index];
    ArmyGroup.RandomPosList.RemoveAt(index);
    return randomPos;
  }

  private void setupSoldierArray(EGroupKind groupKind)
  {
    Vector3 zero = Vector3.zero;
    switch (groupKind)
    {
      case EGroupKind.Archer:
        ArmyGroup.RandomPosList.Clear();
        for (byte index = 0; index < (byte) 9; ++index)
          ArmyGroup.RandomPosList.Add(index);
        float new_x = 1.5f;
        zero.Set(0.0f, 0.0f, 0.0f);
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(-new_x, 0.0f, (float) (-(double) new_x * 1.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(0.0f, 0.0f, (float) (-(double) new_x * 1.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(new_x, 0.0f, (float) (-(double) new_x * 1.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(-new_x, 0.0f, (float) (-(double) new_x * 2.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(0.0f, 0.0f, (float) (-(double) new_x * 2.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(new_x, 0.0f, (float) (-(double) new_x * 2.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(-new_x, 0.0f, (float) (-(double) new_x * 3.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(new_x, 0.0f, (float) (-(double) new_x * 3.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        break;
      case EGroupKind.Cavalry:
        float num1 = 1f;
        zero.Set(-num1, 0.0f, num1);
        this.soldierArray[0] = zero;
        zero.Set(num1, 0.0f, num1);
        this.soldierArray[1] = zero;
        zero.Set((float) (-(double) num1 * 3.0), 0.0f, -num1);
        this.soldierArray[2] = zero;
        zero.Set(num1 * 3f, 0.0f, -num1);
        this.soldierArray[3] = zero;
        zero.Set((float) (-(double) num1 * 3.0), 0.0f, (float) (-(double) num1 * 3.5));
        this.soldierArray[4] = zero;
        zero.Set(num1 * 3f, 0.0f, (float) (-(double) num1 * 3.5));
        this.soldierArray[5] = zero;
        break;
      case EGroupKind.Catapults:
        zero.Set(0.0f, 0.0f, 0.0f);
        this.soldierArray[0] = zero;
        break;
      default:
        ArmyGroup.RandomPosList.Clear();
        for (byte index = 0; index < (byte) 12; ++index)
          ArmyGroup.RandomPosList.Add(index);
        float num2 = 1.5f;
        float num3 = 1.8f;
        zero.Set(0.0f, 0.0f, num2);
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(-num2, 0.0f, 0.0f);
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(0.0f, 0.0f, 0.0f);
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(num2, 0.0f, 0.0f);
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(-num2, 0.0f, (float) (-(double) num3 * 1.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(0.0f, 0.0f, (float) (-(double) num3 * 1.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(num2, 0.0f, (float) (-(double) num3 * 1.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(-num2, 0.0f, (float) (-(double) num3 * 2.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(0.0f, 0.0f, (float) (-(double) num3 * 2.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(num2, 0.0f, (float) (-(double) num3 * 2.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(-num2, 0.0f, (float) (-(double) num3 * 3.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        zero.Set(num2, 0.0f, (float) (-(double) num3 * 3.0));
        this.soldierArray[(int) this.getRandowPos()] = zero;
        break;
    }
  }

  public virtual void Destroy()
  {
    this.soldierArray = (Vector3[]) null;
    this.Target = (ArmyGroup) null;
    if (this.heroSoldier != null)
    {
      if (!this.heroSoldier.gameObject.activeSelf)
        this.heroSoldier.gameObject.SetActive(true);
      this.heroSoldier.Destroy();
      this.heroSoldier = (Soldier) null;
    }
    if ((Object) this.groupRoot != (Object) null)
    {
      Object.Destroy((Object) this.groupRoot.gameObject);
      this.groupRoot = (Transform) null;
    }
    if (this.soldiers == null)
      return;
    for (int index = 0; index < this.soldiers.Length; ++index)
    {
      if (this.soldiers[index] != null)
      {
        this.soldiers[index].Destroy();
        this.soldiers[index] = (Soldier) null;
      }
    }
  }

  public virtual void Update(float deltaTime, float moveDeltaTime)
  {
    if (this.SoldierCount == 0)
    {
      if (this.heroSoldier == null)
        return;
      this.heroSoldier.FSMController.Update(this.heroSoldier, this, deltaTime);
    }
    else
    {
      this.checkMove(moveDeltaTime);
      FSMUnit fsmUnit = (FSMUnit) null;
      if (this.ForceEnterFSM || this.lastState != this.m_State)
      {
        EStateName fsm = ArmyGroup.m_FSMMap[this.m_State];
        fsmUnit = ArmyGroup.FSMMgr.getState(fsm);
        if (this.m_State == ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN || this.m_State == ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL)
          this.bAttackMode = true;
        else if ((WarManager.IsNpcModeEnable && this.Side != (byte) 0 || !this.hasLord) && (this.m_State == ArmyGroup.EGROUPSTATE.ATTACKER_RUN_AWAY || this.m_State == ArmyGroup.EGROUPSTATE.DEFENSER_RUN_AWAY))
          this.LordRunAway(this.m_State == ArmyGroup.EGROUPSTATE.ATTACKER_RUN_AWAY);
        this.ForceEnterFSM = false;
      }
      byte num1 = 1;
      int num2 = this.SoldierCountDefault - this.CurrentSoldierCount;
      if (num2 != this.DeadCount)
      {
        if (num2 - this.DeadCount > 5)
          num1 = (byte) 2;
        this.DeadCount = num2;
      }
      for (int index = 0; index < this.SoldierCount; ++index)
      {
        if (index >= this.CurrentSoldierCount)
        {
          switch (this.soldiers[index].CurFSM)
          {
            case EStateName.DIE:
            case EStateName.DYING:
              break;
            default:
              this.soldiers[index].Flag = (byte) 2;
              this.soldiers[index].Target = this.AttackBy == null ? (Soldier) null : (this.AttackBy.heroSoldier == null ? this.AttackBy.soldiers[0] : this.AttackBy.heroSoldier);
              this.soldiers[index].FSMController = ArmyGroup.FSMMgr.getState(EStateName.DYING);
              break;
          }
        }
        else if (fsmUnit != null)
          this.soldiers[index].FSMController = fsmUnit;
        this.soldiers[index].FSMController.Update(this.soldiers[index], this, deltaTime);
        this.soldiers[index].Update(deltaTime);
      }
      if (this.heroSoldier != null)
      {
        if (!this.bAttackMode && this.hasLord)
        {
          this.SiegeModeDefenserLordRun(deltaTime);
        }
        else
        {
          if (this.CurrentSoldierCount != 0 && fsmUnit != null && this.m_State != ArmyGroup.EGROUPSTATE.ATTACKER_RUN_AWAY && this.m_State != ArmyGroup.EGROUPSTATE.DEFENSER_RUN_AWAY)
            this.heroSoldier.FSMController = !this.heroSoldier.IsLord || this.m_State != ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN ? fsmUnit : FSMManager.Instance.getState(EStateName.JUMP_FROM_WALL);
          this.heroSoldier.FSMController.Update(this.heroSoldier, this, deltaTime);
          this.heroSoldier.Update(deltaTime);
        }
      }
      if (this.bInsideSkill)
      {
        if (this.heroSoldier != null)
          ((Lord) this.heroSoldier).bExtraScaleWork = false;
        this.bInsideSkill = false;
      }
      this.OnceFlag = 0U;
      this.AttackBy = (ArmyGroup) null;
      this.lastState = this.m_State;
    }
  }

  public virtual void Reset()
  {
    this.CurrentSoldierCount = this.SoldierCountDefault;
    this.SoldierCount = this.SoldierCountDefault;
    this.DeadCount = 0;
    for (int index = 0; index < this.SoldierCount; ++index)
    {
      if (!this.soldiers[index].gameObject.activeSelf)
        this.soldiers[index].gameObject.SetActive(true);
      Vector3 vector3 = this.groupRoot.TransformPoint(this.soldierArray[index]);
      this.soldiers[index].transform.position = vector3;
      this.soldiers[index].transform.rotation = Quaternion.LookRotation(this.groupRoot.forward);
      this.soldiers[index].Reset();
    }
    if (this.heroSoldier != null)
    {
      this.heroSoldier.gameObject.SetActive(true);
      this.heroSoldier.transform.position = this.groupRoot.TransformPoint(this.HeroOffset);
      this.heroSoldier.ResetAnimSettingToDefault();
      this.heroSoldier.ResetAnimToIdle();
      this.heroSoldier.Reset();
    }
    this.CommonFlag = 0U;
    this.OnceFlag = 0U;
    this.m_State = ArmyGroup.EGROUPSTATE.IDLE;
  }

  private bool checkMove(float moveDeltaTime)
  {
    if (this.m_State == ArmyGroup.EGROUPSTATE.MOVING)
    {
      ArmyGroup.Vec3Instance = this.Target != null ? (this.Target.GroupKind != EGroupKind.CastleGate ? this.Target.groupRoot.position : this.targetPosition) : this.targetPosition;
      if (this.Target != null && this.Target.GroupKind == EGroupKind.CastleGate && (this.GroupKind == EGroupKind.Infantry || this.GroupKind == EGroupKind.Cavalry) && (double) GameConstants.DistanceSquare(this.groupRoot.position, ArmyGroup.Vec3Instance) < 64.0)
        this.Attack(this.Target, param: (byte) 0);
      else if (this.Target != null && (this.GroupKind == EGroupKind.Infantry || this.GroupKind == EGroupKind.Cavalry) && (double) GameConstants.DistanceSquare(this.groupRoot.position, ArmyGroup.Vec3Instance) < 144.0)
      {
        this.Attack(this.Target, param: (byte) 0);
      }
      else
      {
        float num = moveDeltaTime;
        if (this.m_lastTargetPos != ArmyGroup.Vec3Instance)
          this.updateDirection(ArmyGroup.Vec3Instance);
        this.groupRoot.position = GameConstants.MoveTowards(this.groupRoot.position, ArmyGroup.Vec3Instance, this.MoveSpeed * num);
        this.groupRoot.rotation = this.m_Direction;
        return true;
      }
    }
    else
    {
      if (this.m_State == ArmyGroup.EGROUPSTATE.RETREAT_MOVING_SPREAD)
      {
        if (this.m_lastTargetPos != this.targetPosition)
          this.updateDirection(this.targetPosition);
        this.groupRoot.position = GameConstants.MoveTowards(this.groupRoot.position, this.targetPosition, this.MoveSpeed * moveDeltaTime);
        this.groupRoot.rotation = this.m_Direction;
        if ((double) GameConstants.DistanceSquare(this.targetPosition, this.groupRoot.position) <= 1.0 / 1000.0)
        {
          this.targetPosition.x = this.Side != (byte) 1 ? 1000f : -1000f;
          this.m_State = ArmyGroup.EGROUPSTATE.RETREAT_MOVING;
          Quaternion quaternion = Quaternion.LookRotation(this.targetPosition - this.groupRoot.position);
          if (this.m_Direction != quaternion)
            this.m_Direction = quaternion;
          this.groupRoot.rotation = this.m_Direction;
          for (int index = 0; index < this.SoldierCount; ++index)
            this.soldiers[index].ActionMode = EActionMode.Personal;
        }
        return true;
      }
      if (this.m_State == ArmyGroup.EGROUPSTATE.RETREAT_MOVING)
      {
        this.groupRoot.position = GameConstants.MoveTowards(this.groupRoot.position, this.targetPosition, this.MoveSpeed * moveDeltaTime);
        return true;
      }
    }
    return false;
  }

  public virtual void Attack(ArmyGroup target, bool bForceRetarget = false, byte param = 0)
  {
    if (this.Target != target)
      bForceRetarget = true;
    if (this.lastState == ArmyGroup.EGROUPSTATE.FIGHT && !bForceRetarget && param == (byte) 0)
    {
      this.OnceFlag |= 1U;
      if (this.Target != null)
        return;
      this.Target = target;
    }
    else
    {
      this.OnceFlag |= 1U;
      this.Target = target;
      this.m_State = param == (byte) 0 ? ArmyGroup.EGROUPSTATE.FIGHT : ArmyGroup.EGROUPSTATE.FIGHT_IMMEDIATE;
      this.CenterWithTarget = target.GroupKind == EGroupKind.Infantry || target.GroupKind == EGroupKind.Cavalry ? this.groupRoot.position + (target.groupRoot.position - this.groupRoot.position) / 2f : (target.GroupKind != EGroupKind.CastleGate ? target.groupRoot.position : this.groupRoot.position + (new Vector3(52f - this.soldiers[0].AttackRadius, 0.0f, this.groupRoot.position.z) - this.groupRoot.position) / 2f);
      if (!bForceRetarget)
        return;
      this.lastState = ArmyGroup.EGROUPSTATE.IDLE;
      for (int index = 0; index < this.CurrentSoldierCount; ++index)
      {
        this.soldiers[index].ActionMode = EActionMode.Personal;
        this.soldiers[index].ResetTarget(true);
      }
      if (this.heroSoldier == null)
        return;
      this.heroSoldier.ActionMode = EActionMode.Personal;
      this.heroSoldier.ResetTarget();
    }
  }

  public void PlaySkill(ushort skillID, ArmyGroup target)
  {
    this.Target = target;
    this.m_State = ArmyGroup.EGROUPSTATE.FIGHT;
    if (this.heroSoldier == null)
      return;
    Lord heroSoldier = (Lord) this.heroSoldier;
    heroSoldier.PlaySkillAnim(skillID);
    this.particleMgr.Spawn((ushort) 2009, heroSoldier.GetHitPointTrans(), Vector3.zero, 1f, true);
    AudioManager.Instance.PlaySFX((ushort) 40039, PlayObj: heroSoldier.modelTrans);
    this.bInsideSkill = true;
  }

  public virtual void AllDie(int param = 0)
  {
    this.CurrentSoldierCount = 0;
    if (this.heroSoldier == null)
      return;
    this.heroSoldier.FSMController = FSMManager.Instance.getState(EStateName.LORD_DYING);
  }

  public Vector3 GetBloodBarPos()
  {
    return this.bNpcMode && this.heroSoldier != null ? this.heroSoldier.transform.position : this.soldiers[0].transform.position;
  }

  private Vector3 GetRandVector3(float max)
  {
    return new Vector3(Random.Range(0.0f, max), Random.Range(0.0f, max), Random.Range(0.0f, max));
  }

  public virtual void FireRange(
    ArmyGroup targetGroup,
    FlyingObjectManager mgr,
    FOKind kind,
    float ms,
    ushort skillID,
    byte param = 0)
  {
    ushort heroSoldierFo = this.heroSoldierFO;
    if (skillID <= (ushort) 7 && this.soldiers != null && !this.bNpcMode)
    {
      for (int index = 0; index < this.CurrentSoldierCount; ++index)
      {
        Soldier soldier = this.soldiers[index];
        if (targetGroup.GroupKind != EGroupKind.CastleGate)
        {
          Transform end = soldier.Target == null ? targetGroup.groupRoot : soldier.Target.transform;
          mgr.addFlyingObject(kind, soldier.RangeFirePoint, end, ms, new Vector3(0.0f, 1f, 0.0f));
        }
        else
        {
          Vector3 offset = new Vector3(-3f, Random.Range(5f, 10f), soldier.transform.position.z - 15f) + this.GetRandVector3(2f);
          mgr.addFlyingObject(kind, soldier.RangeFirePoint, this.Target.groupRoot, ms, offset);
          if (soldier.hitParticleCount < (byte) 2)
          {
            soldier.hitParticlePos[(int) soldier.hitParticleCount] = this.Target.groupRoot.position + offset;
            ++soldier.hitParticleCount;
          }
        }
      }
    }
    if (this.heroSoldier == null)
      return;
    Soldier heroSoldier = this.heroSoldier;
    Transform modelTrans = ((Lord) this.heroSoldier).modelTrans;
    bool flag = !this.bAttackMode && this.hasLord;
    if (targetGroup.GroupKind != EGroupKind.CastleGate)
    {
      if (skillID <= (ushort) 7 && this.heroSoldierFO != (ushort) 0 && this.GroupKind != EGroupKind.Catapults && !flag)
      {
        Transform end = heroSoldier.Target == null ? targetGroup.groupRoot : heroSoldier.Target.transform;
        mgr.addFlyingObject((FOKind) ((uint) this.heroSoldierFO - 1U), heroSoldier.RangeFirePoint, end, ms, new Vector3(0.0f, 1f, 0.0f), modelTrans);
      }
      else
      {
        if (skillID <= (ushort) 7 || this.heroSoldierSkillFO == (ushort) 0)
          return;
        Transform end = heroSoldier.Target == null ? targetGroup.groupRoot : heroSoldier.Target.transform;
        Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
        GameObject particle = this.particleManager.Spawn(this.heroSoldierSkillFO, (Transform) null, Vector3.zero, 1f, true, false);
        if (!((Object) particle != (Object) null))
          return;
        ChaseType CurveType = recordByKey.FlyType != (byte) 1 ? ChaseType.Straight : ChaseType.CurveA;
        mgr.addFlyingObject(FOKind.FreeParticle, heroSoldier.RangeFirePoint, end, ms, new Vector3(0.0f, 1f, 0.0f), modelTrans, CurveType, particle);
      }
    }
    else if (skillID <= (ushort) 7 && this.heroSoldierFO != (ushort) 0)
    {
      Vector3 offset = new Vector3(-3f, Random.Range(5f, 10f), heroSoldier.transform.position.z - 15f);
      mgr.addFlyingObject((FOKind) ((uint) this.heroSoldierFO - 1U), heroSoldier.RangeFirePoint, this.Target.groupRoot, ms, offset, modelTrans);
      if (heroSoldier.hitParticleCount >= (byte) 2)
        return;
      heroSoldier.hitParticlePos[(int) heroSoldier.hitParticleCount] = this.Target.groupRoot.position + offset;
      ++heroSoldier.hitParticleCount;
    }
    else
    {
      if (skillID <= (ushort) 7 || this.heroSoldierSkillFO == (ushort) 0)
        return;
      Vector3 vector3 = new Vector3(-3f, Random.Range(5f, 10f), heroSoldier.transform.position.z - 15f);
      Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
      GameObject particle = this.particleManager.Spawn(this.heroSoldierSkillFO, (Transform) null, Vector3.zero, 1f, true, false);
      if ((Object) particle != (Object) null)
      {
        ChaseType CurveType = recordByKey.FlyType != (byte) 1 ? ChaseType.Straight : ChaseType.CurveA;
        mgr.addFlyingObject(FOKind.FreeParticle, heroSoldier.RangeFirePoint, this.Target.groupRoot, ms, new Vector3(0.0f, 1f, 0.0f), modelTrans, CurveType, particle);
      }
      if (heroSoldier.hitParticleCount >= (byte) 2)
        return;
      heroSoldier.hitParticlePos[(int) heroSoldier.hitParticleCount] = this.Target.groupRoot.position + vector3;
      ++heroSoldier.hitParticleCount;
    }
  }

  public void updateDirection(Vector3 curTargetPos)
  {
    this.m_lastTargetPos = curTargetPos;
    this.m_lastTargetPos.y = 0.0f;
    Vector3 forward = this.m_lastTargetPos - this.groupRoot.position;
    if (!(forward != Vector3.zero))
      return;
    this.m_Direction = Quaternion.LookRotation(forward);
  }

  public void Move(ArmyGroup target)
  {
    this.Target = target;
    if (this.Target == null)
      return;
    this.targetPosition = target.GroupKind != EGroupKind.CastleGate ? this.Target.groupRoot.position : new Vector3(52f, 0.0f, this.groupRoot.position.z);
    Quaternion quaternion = Quaternion.LookRotation(this.targetPosition - this.groupRoot.position);
    if (this.m_Direction != quaternion)
      this.m_Direction = quaternion;
    this.groupRoot.rotation = this.m_Direction;
    for (int index = 0; index < this.SoldierCount; ++index)
    {
      if (this.soldiers[index].CurFSM != EStateName.DYING)
      {
        this.soldiers[index].ActionMode = EActionMode.Personal;
        this.soldiers[index].ResetTarget(true);
      }
    }
    if (this.heroSoldier != null)
    {
      this.heroSoldier.ActionMode = EActionMode.Personal;
      this.heroSoldier.ResetTarget();
    }
    this.m_State = ArmyGroup.EGROUPSTATE.MOVING;
  }

  public void Move(Vector3 target, bool bRetreat = false)
  {
    this.Target = (ArmyGroup) null;
    this.targetPosition = target;
    Quaternion quaternion = Quaternion.LookRotation(this.targetPosition - this.groupRoot.position);
    if (this.m_Direction != quaternion)
      this.m_Direction = quaternion;
    this.groupRoot.rotation = this.m_Direction;
    for (int index = 0; index < this.SoldierCount; ++index)
    {
      this.soldiers[index].ActionMode = EActionMode.Personal;
      this.soldiers[index].ResetTarget(true);
    }
    if (this.heroSoldier != null)
    {
      this.heroSoldier.ActionMode = EActionMode.Personal;
      this.heroSoldier.ResetTarget();
    }
    if (bRetreat)
      this.m_State = ArmyGroup.EGROUPSTATE.RETREAT_MOVING_SPREAD;
    else
      this.m_State = ArmyGroup.EGROUPSTATE.MOVING;
  }

  public void setPosition(Vector3 pos, Vector3 faceTo, byte heroOffsetType = 0)
  {
    Quaternion quaternion = Quaternion.LookRotation(faceTo - pos);
    this.groupRoot.transform.position = pos;
    this.groupRoot.transform.rotation = quaternion;
    for (int index = 0; index < this.SoldierCount; ++index)
    {
      Vector3 vector3 = this.groupRoot.TransformPoint(this.soldierArray[index]) with
      {
        y = pos.y
      };
      this.soldiers[index].transform.position = vector3;
      this.soldiers[index].transform.rotation = quaternion;
    }
    if (this.heroSoldier == null)
      return;
    this.heroSoldier.transform.position = this.groupRoot.TransformPoint(heroOffsetType != (byte) 0 ? Vector3.zero : this.HeroOffset);
    this.heroSoldier.transform.rotation = quaternion;
  }

  public void setPosition(float posX, float posY)
  {
    this.groupRoot.transform.position = new Vector3(posX, 0.0f, posY);
  }

  public void setPositionInstantlyIgnoreHeroAndAxisY(float posX, float posY, Vector3 faceTo)
  {
    Quaternion quaternion = Quaternion.LookRotation(faceTo);
    this.groupRoot.transform.rotation = quaternion;
    this.setPosition(posX, posY);
    for (int index = 0; index < this.SoldierCount; ++index)
    {
      Vector3 vector3 = this.groupRoot.TransformPoint(this.soldierArray[index]);
      this.soldiers[index].transform.position = vector3;
      this.soldiers[index].transform.rotation = quaternion;
    }
  }

  public void setPositionAndMove(float posX, float posY)
  {
    this.setPosition(posX, posY);
    for (int index = 0; index < this.SoldierCount; ++index)
    {
      this.soldiers[index].ActionMode = EActionMode.Personal;
      this.soldiers[index].FSMController.Enter(this.soldiers[index]);
    }
  }

  public Vector3 getTransformPoint(int idx)
  {
    return idx == (int) byte.MaxValue ? this.groupRoot.TransformPoint(this.HeroOffset) : this.groupRoot.TransformPoint(this.soldierArray[idx]);
  }

  public void resetLightmap(int curLightmapIdx)
  {
    if (this.lightmapIndex == curLightmapIdx)
      return;
    int sceneLightmapSize = LightmapManager.Instance.SceneLightmapSize;
    int num1 = 1 + sceneLightmapSize;
    if (curLightmapIdx == num1)
    {
      int num2 = 2 + sceneLightmapSize;
      for (int index = 0; index < this.SoldierCount; ++index)
      {
        int num3 = this.soldiers[index].CurAnim != ESheetMeshAnim.die ? num1 : num2;
        this.soldiers[index].renderer.lightmapIndex = num3;
      }
      if (this.heroSoldier != null)
        this.heroSoldier.renderer.lightmapIndex = num1;
    }
    else
    {
      for (int index = 0; index < this.SoldierCount; ++index)
        this.soldiers[index].renderer.lightmapIndex = curLightmapIdx;
      if (this.heroSoldier != null)
        this.heroSoldier.renderer.lightmapIndex = (int) byte.MaxValue;
    }
    this.lightmapIndex = curLightmapIdx;
  }

  public void SoldierCallBack(int idx, int param)
  {
    if (this.m_State != ArmyGroup.EGROUPSTATE.JUMP_FROM_WALL && this.m_State != ArmyGroup.EGROUPSTATE.MOVE_OUTOF_TOWN)
      return;
    ++this.SoldierFlagCount;
    if (this.SoldierFlagCount < this.CurrentSoldierCount || ((int) this.CommonFlag & 1) == 0)
      return;
    this.CommonFlag ^= 1U;
  }

  public void SiegeModeDefenserLordInit()
  {
    this.heroSoldier.transform.position = new Vector3(55f, 7.6f, 15f);
    this.heroSoldier.LordAnimSetting((byte) 0);
    this.CommonTimer = (float) Random.Range(2, 6);
    this.heroSoldier.PlayAnim(ESheetMeshAnim.idle);
  }

  public void SiegeModeDefenserLordRun(float deltaTime)
  {
    if ((double) this.CommonTimer > 0.0)
    {
      this.CommonTimer -= deltaTime;
      if ((double) this.CommonTimer <= 0.0 && this.GroupKind != EGroupKind.Archer && this.GroupKind != EGroupKind.Catapults)
        this.heroSoldier.PlayAnim(ESheetMeshAnim.victory, SAWrapMode.Default);
    }
    else
    {
      Animation animComponent = this.heroSoldier.getAnimComponent();
      if ((Object) animComponent != (Object) null && (double) animComponent["victory"].time <= 0.0)
        this.CommonTimer = (float) Random.Range(2, 6);
    }
    this.heroSoldier.Update(deltaTime);
  }

  public void setLordAnimEnable(bool bEnable)
  {
    if (this.heroSoldier == null)
      return;
    Animation animComponent = this.heroSoldier.getAnimComponent();
    if (!((Object) animComponent != (Object) null))
      return;
    float num1 = !bEnable ? 0.0f : 1f;
    if (this.heroSoldier.lastAnim == ESheetMeshAnim.die)
      animComponent["daze"].speed = num1;
    else if (this.heroSoldier.lastAnim == ESheetMeshAnim.attack)
    {
      if (!bEnable)
      {
        animComponent["attack"].speed = 0.0f;
      }
      else
      {
        float num2 = (float) DataManager.Instance.HeroTable.GetRecordByKey(this.heroSoldierID).HeroAttackInfo[0].HitTime * Soldier.ARCHER_HITTIME_INVERSE;
        animComponent["attack"].speed = num2;
      }
    }
    else
      animComponent[this.heroSoldier.lastAnim.ToString()].speed = num1;
    animComponent["idle"].speed = num1;
    animComponent["moving"].speed = num1;
  }

  public void BeforeDeadDisable()
  {
  }

  public void LordRunAway(bool bAttacker)
  {
    if (this.heroSoldier == null || (!this.heroSoldier.IsLord || WarManager.IsNpcModeEnable && this.Side != (byte) 0) && (this.heroSoldier.CurFSM == EStateName.LORD_DYING || this.heroSoldier.CurFSM == EStateName.DIE))
      return;
    Animation animComponent = this.heroSoldier.getAnimComponent();
    if ((Object) animComponent != (Object) null)
      animComponent["moving"].layer = 1;
    if (bAttacker)
      this.heroSoldier.FSMController = FSMManager.Instance.getState(EStateName.ATTACKER_RUN_AWAY);
    else
      this.heroSoldier.FSMController = FSMManager.Instance.getState(EStateName.DEFENSER_RUN_AWAY);
  }

  public enum EGROUPSTATE
  {
    MOVING,
    IDLE,
    FIGHT,
    FIGHT_IMMEDIATE,
    IDLE_WITHOUT_CLUMP,
    RETREAT_MOVING_SPREAD,
    RETREAT_MOVING,
    VICTORY,
    MOVE_OUTOF_TOWN,
    JUMP_FROM_WALL,
    GO_CAPTIVING,
    ATTACKER_RUN_AWAY,
    DEFENSER_CHASING,
    DEFENSER_RUN_AWAY,
    ATTACKER_CHASING,
    DESTROYING,
    DESTROYED,
  }
}
