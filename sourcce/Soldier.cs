// Decompiled with JetBrains decompiler
// Type: Soldier
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class Soldier : SheetAnimMesh
{
  public static int shadowABKey = 0;
  protected GameObject shadowObj;
  public EActionMode ActionMode;
  public ArmyGroup Parent;
  public ushort Index;
  protected FSMUnit m_FSMController;
  public Vector3 SpreadPos = Vector3.zero;
  public ESpreadMode SpreadMode;
  public float DyingValue;
  public Vector3 LastTargetPos = Vector3.zero;
  public byte DieState;
  public EStateName CurFSM = EStateName.IDLE;
  public ushort ParticleFlag;
  public Vector3[] hitParticlePos = new Vector3[2];
  public byte hitParticleCount;
  public float Timer;
  public byte Flag;
  public byte SoldierKind;
  public byte SoldierTier;
  public ESheetMeshAnim lastAnim = ESheetMeshAnim.all;
  public float fightTimer;
  public bool IsLord;
  public bool IsHeroSoldier;
  public int LastMovingFrame;
  public bool bFakeSoldier;
  public Vector3 Direction = Vector3.zero;
  public bool bRotateDirty;
  public byte CaptiveFlag;
  public Vector3 CaptivePos = Vector3.zero;
  protected Soldier m_Target;
  public bool bNewTargetDirty;
  public float attackAnimSpeedRate;
  public static float ARCHER_HITTIME_INVERSE = 1f / 800f;
  protected static readonly Vector3[,] rangeFirePoint = new Vector3[2, 4]
  {
    {
      new Vector3(0.18f, 1.407f, 0.393f),
      new Vector3(0.244f, 1.572f, 0.713f),
      new Vector3(0.087f, 1.162f, 0.53f),
      new Vector3(0.1f, 1.403f, 0.112f)
    },
    {
      new Vector3(0.0f, 4.817f, -0.444f),
      new Vector3(0.0f, 6.889f, -6.819f),
      new Vector3(0.0f, 6.236f, -3.515f),
      new Vector3(0.0f, 5.339f, 2.517f)
    }
  };
  private static readonly Vector3[] hitPointOffset = new Vector3[4]
  {
    new Vector3(0.0f, 3f, 0.0f),
    new Vector3(0.0f, 2.5f, 0.0f),
    new Vector3(0.0f, 5f, 0.0f),
    new Vector3(0.0f, 3.5f, 0.0f)
  };
  private static readonly float[] attackRadius = new float[4]
  {
    3f,
    110f,
    6.3f,
    110f
  };
  private static readonly float[] hitRadius = new float[4]
  {
    0.9f,
    0.9f,
    1.5f,
    1.5f
  };
  public Soldier.ParentListener pListener;

  protected Soldier()
  {
  }

  public Soldier(byte kind, byte tier, byte side)
    : base(EWarMeshKind.SOLDIER, kind, tier, side)
  {
    this.animNotify = new SheetAnimMesh.AnimNotify(this.AnimOnceNotify);
    this.SoldierKind = kind;
    this.SoldierTier = tier;
    double radius;
    switch (kind)
    {
      case 3:
        radius = 1.5;
        break;
      case 4:
        return;
      default:
        radius = 0.75;
        break;
    }
    this.createShadow((float) radius);
  }

  public Soldier Target
  {
    get => this.m_Target;
    set
    {
      this.m_Target = value;
      this.bNewTargetDirty = true;
    }
  }

  public bool IsMoveDirty => Time.frameCount - this.LastMovingFrame <= 1;

  public virtual Vector3 RangeFirePoint
  {
    get
    {
      if (this.SoldierKind != (byte) 4 && this.SoldierKind != (byte) 2)
        return Vector3.zero;
      int index = this.SoldierKind != (byte) 4 ? 0 : 1;
      return this.transform.TransformPoint(Soldier.rangeFirePoint[index, (int) this.SoldierTier - 1]);
    }
  }

  public FSMUnit FSMController
  {
    get => this.m_FSMController;
    set
    {
      if (this.CurFSM == EStateName.KICKBACK && this.Flag == (byte) 1)
        return;
      this.m_FSMController = value;
      this.CurFSM = this.m_FSMController.StateName;
      this.m_FSMController.Enter(this);
    }
  }

  public bool EnableShadow
  {
    get => (bool) (Object) this.shadowObj && this.shadowObj.activeSelf;
    set
    {
      if (!(bool) (Object) this.shadowObj)
        return;
      this.shadowObj.SetActive(value);
    }
  }

  public virtual ESheetMeshAnim CurAnim => this.curAnim;

  public virtual float AnimLength => this.animLength;

  public virtual Renderer renderer => this.meshRenderer;

  public Vector3 hitPoint
  {
    get
    {
      return this.transform.TransformPoint(Soldier.hitPointOffset[(int) this.SoldierKind - 1]) + new Vector3(Random.Range(-1.5f, 1.5f), 0.0f, Random.Range(-1.5f, 1.5f));
    }
  }

  public float Radius => Soldier.hitRadius[(int) this.SoldierKind - 1];

  public float AttackRadius
  {
    get
    {
      return this.Index == (ushort) byte.MaxValue && (this.SoldierKind == (byte) 1 || this.SoldierKind == (byte) 3) ? Soldier.attackRadius[2] : Soldier.attackRadius[(int) this.SoldierKind - 1];
    }
  }

  protected void createShadow(float radius)
  {
    this.shadowObj = Object.Instantiate(AssetManager.GetAssetBundle("UI/shadow", out Soldier.shadowABKey).mainAsset) as GameObject;
    this.shadowObj.transform.parent = this.transform;
    this.shadowObj.GetComponent<MeshFilter>().mesh = GameConstants.CreatePlane(this.transform.forward, this.transform.right, new Rect(0.0f, 0.0f, 1f, 1f), new Color(1f, 1f, 1f, 0.5f), radius);
  }

  public override void Destroy()
  {
    this.Target = (Soldier) null;
    base.Destroy();
  }

  public override void Update(float delteTime)
  {
    if (this.ParticleFlag > (ushort) 0)
    {
      ushort EffID = this.ParticleFlag;
      this.ParticleFlag = (ushort) 0;
      if ((this.CurAnim != ESheetMeshAnim.die || this.DieState != (byte) 1) && this.Parent.particleManager != null)
      {
        if (EffID == (ushort) 1)
          EffID = (ushort) Random.Range(2001, 2005);
        this.Parent.particleManager.Spawn(EffID, (Transform) null, this.hitPoint, 1f, true, false);
      }
    }
    base.Update(delteTime);
  }

  public void ResetTarget(bool bResetSpread = false)
  {
    this.Target = (Soldier) null;
    this.SpreadPos = Vector3.zero;
    this.SpreadMode = !bResetSpread ? this.SpreadMode : ESpreadMode.Enable;
  }

  public void AnimOnceNotify(ESheetMeshAnim finishAnim)
  {
    if (finishAnim == ESheetMeshAnim.die)
      this.DieState = (byte) 1;
    else if (this.CurFSM == EStateName.MELEE_FIGHT_IMMEDIATE)
    {
      this.FSMController = FSMManager.Instance.getState(EStateName.TRYFIGHT);
    }
    else
    {
      if (this.SoldierKind != (byte) 4 || finishAnim != ESheetMeshAnim.attack || this.Parent == null)
        return;
      this.Parent.resetLightmap(2 + LightmapManager.Instance.SceneLightmapSize);
    }
  }

  public void NotifyingParent(int param = 0)
  {
    if (this.pListener == null)
      return;
    this.pListener((int) this.Index, param);
  }

  public virtual float LastAnimTime() => this.lastTime;

  public virtual float CurAnimTime() => this.time;

  public virtual void LordAnimSetting(byte type)
  {
  }

  public virtual Animation getAnimComponent() => (Animation) null;

  public virtual void ResetAnimToIdle()
  {
  }

  public virtual void ResetAnimSettingToDefault()
  {
  }

  public virtual void Reset()
  {
    this.DieState = (byte) 0;
    this.Flag = (byte) 0;
    this.speed = 1f;
    this.EnableShadow = true;
    this.ActionMode = EActionMode.Team;
    this.LastMovingFrame = 0;
    this.FSMController = FSMManager.Instance.getState(EStateName.IDLE);
  }

  public virtual void RunAnimSpeedUp()
  {
  }

  public delegate void ParentListener(int idx, int param);
}
