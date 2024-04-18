// Decompiled with JetBrains decompiler
// Type: AnimationUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable disable
public class AnimationUnit : MonoBehaviour
{
  private const ushort MAX_SKILL_FIRING_PARTICLE = 16;
  private const int m_ChannelSkillKindCount = 10;
  public const float MOVE_SPEED = 2f;
  public const float ROTATE_SPEED = 8f;
  public const float SUPPORT_HIDE_DIST_Y = 3f;
  public const float SUPPORT_SHOWTIMES_FROM_GROUND = 3f;
  public const float SUPPORT_HIDE_HEIGHT = 10f;
  public const float SUPPORT_SHOWTIMES_FROM_SKY = 20f;
  public const float SUPPORT_RANDOM_OFFSET_XZ = 3f;
  private const float SHAKE_RANGE = 0.45f;
  private const float SHAKE_TIME = 0.2f;
  private const uint CC_STATE = 1473;
  private const uint STATE_INTERRUPT_MAGIC = 1509;
  private const uint STATE_INTERRUPT_PHYS = 1513;
  public const int MAX_SPECIAL_EFFECT = 6;
  public static readonly string[] ANIM_STRING = new string[10]
  {
    "idle",
    "moving",
    "attack",
    "skill_1",
    "skill_2",
    "skill_3",
    "hurt",
    "die",
    "victory",
    "daze"
  };
  public static readonly string FLY_WEAPON_ROOTBONE = "wp";
  public static readonly string HIT_POINT_ROOTBONE = "Bip01 Spine1";
  private static Vector3 Vec3Instance = new Vector3(0.0f, 0.0f, 0.0f);
  private static Quaternion QuatInstance = new Quaternion(0.0f, 0.0f, 0.0f, 1f);
  private static StringBuilder StringInstance = new StringBuilder(64);
  private static readonly Vector3 NON_TARGET_POS = new Vector3(-1f, -1f, -1f);
  private static CHashSet<byte> m_ChannelSkillKindList = (CHashSet<byte>) null;
  public Vector3? movePos;
  private Vector3 m_targetPos;
  private Vector3 m_lastTargetPos;
  private Quaternion m_Direction;
  public Vector3 Forward = Vector3.zero;
  private bool m_bMoveDirty;
  private bool m_bMoveSpeedFix = true;
  public BattleController controller;
  private float m_VictoryDelay;
  private ushort m_NpcID;
  private CHashTable<ushort, uint> m_AttackAnimInfo = new CHashTable<ushort, uint>(5, false);
  private float m_CurMoveSpeed = 2f;
  private bool m_bIsBoss;
  private bool m_bIsEnemy;
  private float m_MovingDeltaTime;
  private byte m_ScaleWorkingState;
  private float m_ScaleTemp = 1f;
  private float m_NpcScale = 1f;
  private float m_AnimTimeScale = 1f;
  private Transform modelRoot;
  private byte m_bShakeSelf;
  private float m_ShakeCounter = 0.2f;
  private Transform BipTrans;
  private float m_HitPointTime;
  private float m_LastHitPointTime;
  private bool bKnockBacking;
  private ushort m_FightParticleID;
  private byte m_FightParticlePos;
  private GameObject m_FightParticleObj;
  private GameObject m_PreFireParticleObj;
  private ushort m_FightSoundID;
  private ushort m_FightSoundDelay;
  private uint m_LastRangeHitSoundTick;
  private byte m_HitSoundFlag;
  private bool m_bHitPointSlowDown;
  private float m_OldSpeed = 1f;
  private AnimationUnit.AnimName m_OldAnimName = AnimationUnit.AnimName.DIE;
  private bool bSlowMotion;
  private float slowMotionCounter;
  private float slowMotionTime;
  private int m_FrontAnimTemp;
  private byte m_ChannelSkillFlag;
  private ushort m_ChannelSkillID;
  private Vector3 m_RangeParticlePosTemp = Vector3.zero;
  private CHashTable<uint, AnimationUnit.EStateNode> m_StateParticleMap = new CHashTable<uint, AnimationUnit.EStateNode>(10);
  private List<Transform> m_StateRotationParticleList = new List<Transform>(10);
  private List<Transform> m_StateParticleList = new List<Transform>(10);
  private List<byte> m_StateParticlePosList = new List<byte>(10);
  private AnimationUnit.EBuffStatus m_bIsInHurricane;
  private float m_HurricanFinishSpeed;
  private Vector3 Vec3HurricaneUse = Vector3.zero;
  private AnimationUnit.EBuffStatus m_bIsInHitFlying;
  private float m_HitFlyingLength;
  private float m_HitFlyingTime;
  private Vector3 Vec3HitFlyingUse = Vector3.zero;
  private uint m_CurStateKey;
  private uint m_SpecialEffList;
  private AnimationUnit.EState m_DisplayState;
  public List<byte> StateEffList = new List<byte>(10);
  private int m_CurSEIndex;
  private ushort m_LastSkinStateID;
  public uint StateColorSkin;
  public GameObject ResidentEffect;
  private int m_SupportType;
  public AnimationUnit.AnimName m_CurAnimName;
  private AnimationState m_CurAnimState;
  private bool m_IsAttacking;
  private float m_DeltaTimeCounter;
  private byte m_bDeadBodyHiding;
  private ushort m_MaxSkillID;
  private bool bMaxSkillLooping;
  private Transform m_hitParticleRoot;
  private int m_dwHitParticle = -1;
  private Transform m_FlyRoot;
  private uint m_LastRangeParticleTick;
  private GameObject m_ShadowObj;
  private Transform m_ShadowTrans;
  private GameObject m_RangeHitParticleObj;
  private GameObject m_Target;
  private Animation m_Animation;
  private HERO_STATE_ENUM m_HeroState;
  private bool m_bIsStateFreeze;
  private bool m_bIsFreeze;
  private float m_BoundingHight;
  private Renderer m_ModelRenderer;
  public AnimationUnit.ParentListener pListener;
  public bool IsInitialized;
  public bool IsCharging;
  public static List<Transform> SkeletalTransCache = new List<Transform>(50);

  public ushort NpcID
  {
    set => this.m_NpcID = value;
    get => this.m_NpcID;
  }

  public bool IsBoss
  {
    set => this.m_bIsBoss = value;
    get => this.m_bIsBoss;
  }

  public bool IsEnemy
  {
    set => this.m_bIsEnemy = value;
    get => this.m_bIsEnemy;
  }

  public float MovingDeltaTime
  {
    get => this.m_MovingDeltaTime;
    set => this.m_MovingDeltaTime = value;
  }

  public float ScaleRate => this.m_NpcScale;

  public bool hasRangeParticlePos => this.m_RangeParticlePosTemp != Vector3.zero;

  public AnimationUnit.EState DisplayState => this.m_DisplayState;

  public bool IsMaxSkillLooping => this.bMaxSkillLooping;

  public byte DeadBodyHidingFlag => this.m_bDeadBodyHiding;

  public AnimationState CurAnimState => this.m_CurAnimState;

  public int hitParticle
  {
    get => this.m_dwHitParticle;
    set => this.m_dwHitParticle = value;
  }

  public Vector3 FlyRootPos
  {
    get
    {
      return (UnityEngine.Object) this.m_FlyRoot != (UnityEngine.Object) null ? this.m_FlyRoot.position : this.modelRoot.position;
    }
  }

  public Transform WP => (UnityEngine.Object) this.m_FlyRoot != (UnityEngine.Object) null ? this.m_FlyRoot : this.modelRoot;

  public GameObject Shadow
  {
    set
    {
      this.m_ShadowObj = value;
      if (!((UnityEngine.Object) this.m_ShadowObj != (UnityEngine.Object) null))
        return;
      this.m_ShadowTrans = this.m_ShadowObj.transform;
    }
  }

  public GameObject Target
  {
    set => this.m_Target = value;
    get => this.m_Target;
  }

  public Vector3 TargetPos
  {
    set => this.m_targetPos = value;
    get => this.m_targetPos;
  }

  public Animation getAnimation => this.m_Animation;

  public HERO_STATE_ENUM heroState
  {
    get => this.m_HeroState;
    set => this.m_HeroState = value;
  }

  public bool IsFreeze
  {
    get => this.m_bIsFreeze;
    set => this.m_bIsFreeze = value;
  }

  public float BoundingHight => this.m_BoundingHight * this.m_NpcScale;

  public Vector3 Position => this.transform.position;

  public Transform ModelRoot => this.modelRoot;

  public Transform HitPointRoot
  {
    get
    {
      return (UnityEngine.Object) this.m_hitParticleRoot != (UnityEngine.Object) null ? this.m_hitParticleRoot : this.modelRoot;
    }
  }

  public Renderer getRenderer => this.m_ModelRenderer;

  public static Transform GetSkeletalTrans(GameObject rootGo, string skeletal_name)
  {
    AnimationUnit.SkeletalTransCache.Clear();
    rootGo.GetComponentsInChildren<Transform>(true, AnimationUnit.SkeletalTransCache);
    for (int index = 0; index < AnimationUnit.SkeletalTransCache.Count; ++index)
    {
      if (AnimationUnit.SkeletalTransCache[index].name == skeletal_name)
        return AnimationUnit.SkeletalTransCache[index];
    }
    return (Transform) null;
  }

  public void initComponent(ushort NpcID)
  {
    if (AnimationUnit.m_ChannelSkillKindList == null)
    {
      AnimationUnit.m_ChannelSkillKindList = new CHashSet<byte>(10, false);
      AnimationUnit.m_ChannelSkillKindList.Add((byte) 10);
      AnimationUnit.m_ChannelSkillKindList.Add((byte) 11);
      AnimationUnit.m_ChannelSkillKindList.Add((byte) 12);
      AnimationUnit.m_ChannelSkillKindList.Add((byte) 13);
      AnimationUnit.m_ChannelSkillKindList.Add((byte) 14);
      AnimationUnit.m_ChannelSkillKindList.Add((byte) 15);
      AnimationUnit.m_ChannelSkillKindList.Add((byte) 57);
      AnimationUnit.m_ChannelSkillKindList.Add((byte) 58);
      AnimationUnit.m_ChannelSkillKindList.Add((byte) 59);
      AnimationUnit.m_ChannelSkillKindList.Add((byte) 60);
    }
    if (!this.IsInitialized)
    {
      this.m_Animation = this.GetComponentInChildren<Animation>();
      this.m_Animation.cullingType = AnimationCullingType.AlwaysAnimate;
      this.modelRoot = this.transform.FindChild("AnimationObject");
      this.BipTrans = this.modelRoot.GetChild(0);
      this.m_ModelRenderer = this.GetComponentInChildren<SkinnedMeshRenderer>().transform.renderer;
      Transform[] componentsInChildren = this.modelRoot.gameObject.GetComponentsInChildren<Transform>();
      for (int index = 0; index < componentsInChildren.Length; ++index)
      {
        if (componentsInChildren[index].name == AnimationUnit.FLY_WEAPON_ROOTBONE)
          this.m_FlyRoot = componentsInChildren[index];
        else if (componentsInChildren[index].name == AnimationUnit.HIT_POINT_ROOTBONE)
          this.m_hitParticleRoot = componentsInChildren[index];
      }
      if ((UnityEngine.Object) this.m_FlyRoot == (UnityEngine.Object) null)
        this.m_FlyRoot = this.BipTrans;
      if ((UnityEngine.Object) this.m_hitParticleRoot == (UnityEngine.Object) null)
        this.m_hitParticleRoot = this.BipTrans;
      if ((UnityEngine.Object) this.m_Animation != (UnityEngine.Object) null)
        this.initAnimation();
    }
    this.m_NpcID = NpcID;
    this.m_ChannelSkillFlag = (byte) 0;
    if (!this.m_Animation.enabled)
      this.m_Animation.enabled = true;
    Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.m_NpcID);
    this.m_AttackAnimInfo.Clear();
    for (uint index = 0; index < 5U; ++index)
    {
      uint val = (uint) ((int) recordByKey.HeroAttackInfo[(IntPtr) index].HitTime << 16 | (int) index + 1);
      this.m_AttackAnimInfo.Add(recordByKey.AttackPower[(IntPtr) index], val);
      if (index == 1U)
        this.m_MaxSkillID = recordByKey.AttackPower[(IntPtr) index];
    }
    AnimationUnit.QuatInstance.Set(0.0f, 0.0f, 0.0f, 1f);
    this.modelRoot.localPosition = Vector3.zero;
    this.modelRoot.localRotation = AnimationUnit.QuatInstance;
    this.bKnockBacking = false;
    this.m_BoundingHight = (float) recordByKey.Height * 0.01f;
    this.m_lastTargetPos = this.transform.position;
    this.m_targetPos = AnimationUnit.NON_TARGET_POS;
    this.movePos = new Vector3?();
    this.m_NpcScale = 1f;
    this.m_ScaleTemp = 1f;
    this.m_bIsFreeze = false;
    this.m_bIsStateFreeze = false;
    this.m_bIsInHurricane = AnimationUnit.EBuffStatus.NONE;
    this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.NONE;
    this.IsCharging = false;
    this.m_Direction = this.transform.rotation;
    this.m_bMoveSpeedFix = true;
    if ((UnityEngine.Object) this.m_ShadowObj != (UnityEngine.Object) null)
      this.m_ShadowObj.SetActive(true);
    this.m_bDeadBodyHiding = (byte) 0;
    this.m_HeroState = HERO_STATE_ENUM.HERO_COMMANDS_IDLE;
    this.changeAnim(AnimationUnit.AnimName.IDLE);
    this.enabled = true;
    this.IsInitialized = true;
  }

  public void resetComponent()
  {
    this.m_Target = (GameObject) null;
    this.m_LastRangeParticleTick = 0U;
    this.m_LastRangeHitSoundTick = 0U;
    this.cleanAttackParticle();
    this.cleanStateParticle();
    this.StateColorSkin = 0U;
    this.m_LastSkinStateID = (ushort) 0;
    this.m_CurStateKey = 0U;
    this.m_SpecialEffList = 0U;
    this.m_DisplayState = AnimationUnit.EState.NONE;
    this.m_CurMoveSpeed = 2f;
    this.IsCharging = false;
    if ((UnityEngine.Object) this.ResidentEffect != (UnityEngine.Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.ResidentEffect);
      this.ResidentEffect = (GameObject) null;
    }
    if (this.modelRoot.gameObject.activeSelf)
      return;
    this.modelRoot.gameObject.SetActive(true);
  }

  public void cleanAttackParticle()
  {
    if ((UnityEngine.Object) this.m_RangeHitParticleObj != (UnityEngine.Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.m_RangeHitParticleObj);
      this.m_RangeHitParticleObj = (GameObject) null;
    }
    if ((UnityEngine.Object) this.m_FightParticleObj != (UnityEngine.Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.m_FightParticleObj);
      this.m_FightParticleObj = (GameObject) null;
    }
    if (!((UnityEngine.Object) this.m_PreFireParticleObj != (UnityEngine.Object) null))
      return;
    ParticleManager.Instance.DeSpawn(this.m_PreFireParticleObj);
    this.m_PreFireParticleObj = (GameObject) null;
  }

  public void cleanStateParticle()
  {
    this.m_StateParticleList.Clear();
    this.m_StateParticlePosList.Clear();
    this.m_StateRotationParticleList.Clear();
    for (uint index = 0; index < 10U; ++index)
    {
      GameObject particle = (GameObject) this.m_StateParticleMap.Values[(IntPtr) index].particle;
      if ((UnityEngine.Object) particle != (UnityEngine.Object) null)
        ParticleManager.Instance.DeSpawn(particle);
    }
    this.m_StateParticleMap.Clear();
    this.StateEffList.Clear();
    this.m_CurSEIndex = 0;
    this.StateColorSkin = 0U;
    this.m_LastSkinStateID = (ushort) 0;
    this.m_ModelRenderer.lightmapIndex = -1;
  }

  private void Update()
  {
    this.updateAnimation();
    this.m_ShadowTrans.position = this.BipTrans.position with
    {
      y = 0.0f
    };
    if (this.m_HitSoundFlag != (byte) 0)
    {
      Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.m_NpcID);
      if ((int) recordByKey.HeroKey == (int) this.m_NpcID && recordByKey.HurtSound != (ushort) 0 && UnityEngine.Random.Range(0, 100) <= this.controller.hitSoundTriggerRate)
        AudioManager.Instance.PlaySFX(recordByKey.HurtSound, pitchkind: PitchKind.SpeechSound, PlayObj: this.transform);
      this.m_HitSoundFlag = (byte) 0;
    }
    for (int index = 0; index < this.m_StateRotationParticleList.Count; ++index)
    {
      this.m_StateRotationParticleList[index].position = this.m_hitParticleRoot.position;
      Quaternion quaternion = Quaternion.LookRotation(Camera.main.transform.position - this.m_hitParticleRoot.position);
      this.m_StateRotationParticleList[index].rotation = quaternion;
    }
    for (int index = 0; index < this.m_StateParticleList.Count; ++index)
    {
      switch (this.m_StateParticlePosList[index])
      {
        case 0:
          this.m_StateParticleList[index].position = this.m_hitParticleRoot.position;
          break;
        case 4:
          this.m_StateParticleList[index].position = this.transform.position;
          break;
      }
    }
  }

  private void OnDestroy() => this.resetComponent();

  private void updateAnimation()
  {
    if (!this.IsInitialized || (double) Time.timeScale <= 1.0 / 1000.0)
      return;
    float smoothDeltaTime = Time.smoothDeltaTime;
    if (this.heroState == HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_LOOP || this.heroState == HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_IDLE)
    {
      if (this.heroState == HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_LOOP)
      {
        if ((double) this.m_VictoryDelay > 1.0 / 1000.0)
          this.m_VictoryDelay -= smoothDeltaTime;
        else if (this.m_CurAnimName != AnimationUnit.AnimName.VICTORY)
          this.changeAnim(AnimationUnit.AnimName.VICTORY);
      }
      if (!(this.transform.rotation != this.m_Direction))
        return;
      this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.m_Direction, smoothDeltaTime * 10f);
    }
    else
    {
      if (this.heroState == HERO_STATE_ENUM.HERO_COMMANDS_WAITING_SUPPORT)
        return;
      if (this.heroState == HERO_STATE_ENUM.HERO_COMMANDS_SUPPORT_DISPLAY)
      {
        if ((double) Vector3.Distance(this.modelRoot.localPosition, this.m_targetPos) > 9.9999997473787516E-05)
        {
          this.modelRoot.localPosition = Vector3.MoveTowards(this.modelRoot.localPosition, this.m_targetPos, smoothDeltaTime * 20f);
        }
        else
        {
          this.heroState = HERO_STATE_ENUM.HERO_COMMANDS_IDLE;
          this.changeAnim(AnimationUnit.AnimName.IDLE);
          if (this.m_SupportType == 1)
            ParticleManager.Instance.Spawn((ushort) 296, (Transform) null, this.Position, 1f, true, false);
          if ((UnityEngine.Object) this.ResidentEffect != (UnityEngine.Object) null)
            this.ResidentEffect.SetActive(true);
          if (!BattleController.IsGambleMode)
            return;
          AudioManager.Instance.PlaySFX((ushort) 1106);
        }
      }
      else
      {
        if (this.heroState == HERO_STATE_ENUM.HERO_COMMANDS_FINISHING_SPREAD)
        {
          if (!this.checkMove())
            this.setState(HERO_STATE_ENUM.HERO_COMMANDS_IDLE);
        }
        else if (this.heroState == HERO_STATE_ENUM.HERO_COMMANDS_PVPNPC_IDLE)
        {
          if ((double) this.m_VictoryDelay > 1.0 / 1000.0)
          {
            this.m_VictoryDelay -= smoothDeltaTime;
          }
          else
          {
            this.m_Animation.CrossFade(AnimationUnit.ANIM_STRING[8]);
            this.m_VictoryDelay = UnityEngine.Random.Range(2f, 4f);
          }
          if (!(this.transform.rotation != this.m_Direction))
            return;
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.m_Direction, smoothDeltaTime * 10f);
          return;
        }
        if (this.m_bIsFreeze)
          return;
        bool flag = false;
        if (((int) this.m_SpecialEffList & 192) != 0)
          flag = true;
        if (!flag)
        {
          if (this.m_bDeadBodyHiding != (byte) 0)
          {
            Vector3 position = this.transform.position;
            if (this.m_bDeadBodyHiding == (byte) 1)
            {
              if ((UnityEngine.Object) this.m_ShadowObj != (UnityEngine.Object) null)
                this.m_ShadowObj.SetActive(false);
              this.resetComponent();
              this.m_bDeadBodyHiding = (byte) 2;
            }
            AnimationUnit.Vec3Instance.Set(position.x, -1f, position.z);
            this.transform.position = Vector3.MoveTowards(this.transform.position, AnimationUnit.Vec3Instance, smoothDeltaTime);
            if ((double) this.transform.position.y > -1.0)
              return;
            this.enabled = false;
            this.gameObject.SetActive(false);
            if (this.m_bDeadBodyHiding != (byte) 2)
              return;
            this.m_bDeadBodyHiding = (byte) 3;
            return;
          }
          if (this.m_ScaleWorkingState == (byte) 1)
          {
            if ((double) this.m_ScaleTemp <= 1.0)
            {
              this.m_ScaleTemp = 1f;
              this.m_ScaleWorkingState = (byte) 0;
            }
            else
              this.m_ScaleTemp -= 0.5f * smoothDeltaTime;
            float num = this.m_NpcScale * this.m_ScaleTemp;
            AnimationUnit.Vec3Instance.Set(num, num, num);
            this.modelRoot.localScale = AnimationUnit.Vec3Instance;
          }
          if (this.m_bIsInHurricane != AnimationUnit.EBuffStatus.NONE)
          {
            if (this.m_bIsInHurricane == AnimationUnit.EBuffStatus.BEGIN)
            {
              if (this.m_bIsInHitFlying != AnimationUnit.EBuffStatus.NONE)
                this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.NONE;
              this.Vec3HurricaneUse = Vector3.zero;
              this.Vec3HurricaneUse.y = 2.5f;
              this.modelRoot.localPosition = Vector3.MoveTowards(this.modelRoot.localPosition, this.Vec3HurricaneUse, smoothDeltaTime * 5f);
              this.modelRoot.Rotate(Vector3.up, 1440f * smoothDeltaTime, Space.Self);
            }
            else
            {
              this.Vec3HurricaneUse = Vector3.zero;
              this.modelRoot.localPosition = Vector3.MoveTowards(this.modelRoot.localPosition, this.Vec3HurricaneUse, smoothDeltaTime * this.m_HurricanFinishSpeed);
              this.modelRoot.Rotate(Vector3.up, 1440f * smoothDeltaTime, Space.Self);
              if ((double) this.modelRoot.localPosition.y <= 1.0 / 1000.0)
              {
                AnimationUnit.QuatInstance.Set(0.0f, 0.0f, 0.0f, 1f);
                this.modelRoot.localRotation = AnimationUnit.QuatInstance;
                this.modelRoot.localPosition = Vector3.zero;
                this.m_bIsInHurricane = AnimationUnit.EBuffStatus.NONE;
              }
            }
          }
          else if (this.m_bIsInHitFlying != AnimationUnit.EBuffStatus.NONE)
            this.RunHitFly(smoothDeltaTime);
          else if (this.m_bShakeSelf != (byte) 0)
          {
            this.m_ShakeCounter -= smoothDeltaTime;
            if ((double) this.m_ShakeCounter <= 0.0)
            {
              this.m_bShakeSelf = (byte) 0;
              this.modelRoot.localPosition = Vector3.zero;
            }
            else if (this.m_bShakeSelf == (byte) 1)
            {
              this.m_bShakeSelf = (byte) 2;
              AnimationUnit.Vec3Instance.Set(this.m_ShakeCounter * 0.45f, 0.0f, (float) (-(double) this.m_ShakeCounter * 0.44999998807907104));
              this.modelRoot.localPosition = AnimationUnit.Vec3Instance;
            }
            else
            {
              this.m_bShakeSelf = (byte) 1;
              AnimationUnit.Vec3Instance.Set((float) (-(double) this.m_ShakeCounter * 0.44999998807907104), 0.0f, this.m_ShakeCounter * 0.45f);
              this.modelRoot.localPosition = AnimationUnit.Vec3Instance;
            }
          }
          if (this.m_IsAttacking)
          {
            if ((double) this.m_HitPointTime >= 9.9999997473787516E-06 && (double) this.m_DeltaTimeCounter < (double) this.m_HitPointTime && (double) this.m_CurAnimState.time >= (double) this.m_HitPointTime)
            {
              if (this.m_CurAnimName != AnimationUnit.AnimName.SKILL1 || this.IsEnemy && !this.controller.IsType(EBattleType.PVP))
              {
                this.checkFireParticle();
                if (this.m_ChannelSkillFlag == (byte) 1)
                {
                  AnimationUnit.StringInstance.Length = 0;
                  AnimationUnit.StringInstance.Append(AnimationUnit.ANIM_STRING[(int) this.m_CurAnimName]);
                  AnimationUnit.StringInstance.Append("_ch");
                  string str = AnimationUnit.StringInstance.ToString();
                  if ((UnityEngine.Object) this.m_Animation.GetClip(str) != (UnityEngine.Object) null)
                  {
                    this.m_Animation.CrossFade(str);
                    this.m_CurAnimState = this.m_Animation[str];
                  }
                  else
                    this.m_CurAnimState.speed = 0.0f;
                  this.m_ChannelSkillFlag = (byte) 2;
                  this.m_HitPointTime = 0.0f;
                }
              }
              else if (this.pListener != null)
                this.pListener(this, EAUCallBack.MAXSKILL_HITPOINT);
            }
            if ((double) this.m_LastHitPointTime > 9.9999997473787516E-05)
            {
              if ((double) this.m_DeltaTimeCounter < (double) this.m_LastHitPointTime && (double) this.m_CurAnimState.time >= (double) this.m_LastHitPointTime && (this.m_bIsEnemy || this.m_CurAnimName != AnimationUnit.AnimName.SKILL1 || (double) this.m_LastHitPointTime != (double) this.m_HitPointTime) && this.m_bHitPointSlowDown)
                this.setAttackSlowDown();
              if (this.bSlowMotion)
              {
                this.slowMotionCounter -= smoothDeltaTime;
                if ((double) this.slowMotionCounter <= 0.0)
                {
                  this.bSlowMotion = false;
                  float num = this.m_CurAnimState.time + this.slowMotionTime - this.slowMotionCounter;
                  if ((double) num < (double) this.m_CurAnimState.length)
                  {
                    this.m_CurAnimState.speed = (float) (((double) this.m_CurAnimState.length - (double) this.m_CurAnimState.time) / ((double) this.m_CurAnimState.length - (double) num)) * this.m_AnimTimeScale;
                    this.m_LastHitPointTime = 0.0f;
                  }
                }
              }
            }
            this.m_DeltaTimeCounter = this.m_CurAnimState.time;
          }
        }
        else if (((int) this.m_SpecialEffList & 128) == 0)
          this.RunHitFly(smoothDeltaTime);
        if (this.checkMove())
          return;
        if (!flag && !this.m_Animation.isPlaying)
        {
          if (this.m_HeroState != HERO_STATE_ENUM.HERO_COMMANDS_DIE)
          {
            this.changeAnim(AnimationUnit.AnimName.IDLE);
            this.m_HeroState = HERO_STATE_ENUM.HERO_COMMANDS_IDLE;
          }
          else
          {
            this.m_Animation.enabled = false;
            if (!NewbieManager.IsNewbie)
              this.m_bDeadBodyHiding = (byte) 1;
            else if (DataManager.Instance.HeroTable.GetRecordByKey(this.m_NpcID).Modle != (ushort) 232)
              this.m_bDeadBodyHiding = (byte) 1;
          }
        }
        if (!(this.transform.rotation != this.m_Direction))
          return;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.m_Direction, smoothDeltaTime * 8f);
      }
    }
  }

  public void RunHitFly(float _deltaTime)
  {
    if (this.m_bIsInHitFlying == AnimationUnit.EBuffStatus.NONE)
      return;
    if (this.m_bIsInHitFlying == AnimationUnit.EBuffStatus.BEGIN)
    {
      this.Vec3HitFlyingUse = Vector3.zero;
      this.Vec3HitFlyingUse.y = 5.5f;
      this.m_HitFlyingTime += _deltaTime;
      if ((double) this.m_HitFlyingTime >= (double) this.m_HitFlyingLength)
      {
        this.m_HitFlyingTime = this.m_HitFlyingLength;
        this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.END;
      }
      this.modelRoot.localPosition = GameConstants.QuadraticBezierCurves(Vector3.zero, this.Vec3HitFlyingUse, Vector3.zero, 1f / this.m_HitFlyingLength, this.m_HitFlyingTime);
    }
    else
    {
      AnimationUnit.QuatInstance.Set(0.0f, 0.0f, 0.0f, 1f);
      this.modelRoot.localRotation = AnimationUnit.QuatInstance;
      this.modelRoot.localPosition = Vector3.zero;
      this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.NONE;
    }
  }

  public void checkFireParticle()
  {
    if (this.m_FightParticleID == (ushort) 0)
      return;
    this.m_FightParticleObj = this.m_FightParticlePos != (byte) 1 ? (this.m_FightParticlePos != (byte) 2 ? ParticleManager.Instance.Spawn(this.m_FightParticleID, this.transform, this.transform.position, 1f, true, false) : ParticleManager.Instance.Spawn(this.m_FightParticleID, this.m_hitParticleRoot, Vector3.zero, 1f, true)) : ParticleManager.Instance.Spawn(this.m_FightParticleID, this.m_FlyRoot, Vector3.zero, 1f, true);
    if (!((UnityEngine.Object) this.m_FightParticleObj != (UnityEngine.Object) null))
      return;
    ParticleSystem component = this.m_FightParticleObj.transform.GetChild(0).GetComponent<ParticleSystem>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null) || component.loop)
      return;
    this.m_FightParticleObj = (GameObject) null;
  }

  public void checkPreFireParticle(ushort skillID)
  {
    if (skillID == (ushort) 0)
      return;
    Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
    if (recordByKey.PreFireParticle == (ushort) 0)
      return;
    this.m_PreFireParticleObj = recordByKey.PreFireParticlePos != (byte) 1 ? (recordByKey.PreFireParticlePos != (byte) 2 ? ParticleManager.Instance.Spawn(recordByKey.PreFireParticle, this.transform, this.transform.position, 1f, true, false) : ParticleManager.Instance.Spawn(recordByKey.PreFireParticle, this.m_hitParticleRoot, Vector3.zero, 1f, true)) : ParticleManager.Instance.Spawn(recordByKey.PreFireParticle, this.m_FlyRoot, Vector3.zero, 1f, true);
    if (!((UnityEngine.Object) this.m_PreFireParticleObj != (UnityEngine.Object) null))
      return;
    ParticleSystem component = this.m_PreFireParticleObj.transform.GetChild(0).GetComponent<ParticleSystem>();
    if (!((UnityEngine.Object) component != (UnityEngine.Object) null) || component.loop)
      return;
    this.m_PreFireParticleObj = (GameObject) null;
  }

  public void playUltraLoopAnim(bool bPlay)
  {
    if (bPlay)
    {
      AnimationUnit.StringInstance.Length = 0;
      AnimationUnit.StringInstance.Append(AnimationUnit.ANIM_STRING[(int) this.m_CurAnimName]);
      AnimationUnit.StringInstance.Append("_w");
      string str = AnimationUnit.StringInstance.ToString();
      if ((UnityEngine.Object) this.m_Animation.GetClip(str) != (UnityEngine.Object) null)
      {
        this.m_CurAnimState.speed = 0.3f;
        this.m_Animation.CrossFade(str, 0.1f);
        this.m_CurAnimState = this.m_Animation[str];
        this.bMaxSkillLooping = true;
      }
      else
      {
        this.m_CurAnimState.speed = 0.0f;
        this.bMaxSkillLooping = true;
      }
      this.m_HitPointTime = 0.0f;
    }
    else
    {
      if (!this.bMaxSkillLooping || this.checkChannelSkillAnim() || (double) this.m_CurAnimState.speed == 0.0)
        return;
      float num = (float) DataManager.Instance.HeroTable.GetRecordByKey(this.m_NpcID).HeroAttackInfo[1].HitTime * (1f / 1000f);
      this.changeAnim(AnimationUnit.AnimName.SKILL1);
      this.m_CurAnimState.time = num;
    }
  }

  public bool checkChannelSkillAnim()
  {
    if (this.m_ChannelSkillFlag != (byte) 1)
      return false;
    AnimationUnit.StringInstance.Length = 0;
    AnimationUnit.StringInstance.Append(AnimationUnit.ANIM_STRING[(int) this.m_CurAnimName]);
    AnimationUnit.StringInstance.Append("_ch");
    string str = AnimationUnit.StringInstance.ToString();
    if ((UnityEngine.Object) this.m_Animation.GetClip(str) != (UnityEngine.Object) null)
    {
      this.m_Animation.CrossFade(str, 0.1f);
      this.m_CurAnimState = this.m_Animation[str];
    }
    else
      this.m_CurAnimState.speed = 0.0f;
    this.m_ChannelSkillFlag = (byte) 2;
    this.m_HitPointTime = 0.0f;
    return true;
  }

  public void playUltraHitSound()
  {
    if (this.m_FightSoundID == (ushort) 0)
      return;
    AudioManager.Instance.PlaySFX(this.m_FightSoundID, PlayObj: this.transform);
  }

  public void setStateFreeze(bool bEnable)
  {
    this.m_bIsStateFreeze = bEnable;
    if (!this.m_bIsStateFreeze && this.m_bIsFreeze != this.m_bIsStateFreeze || this.m_bIsStateFreeze && this.m_bIsFreeze == this.m_bIsStateFreeze)
      return;
    this.freeze(this.m_bIsStateFreeze);
    if (bEnable)
      return;
    this.changeAnim(AnimationUnit.AnimName.IDLE);
  }

  public void setMaxSkillFreeze(bool bEnable)
  {
    this.m_bIsFreeze = bEnable;
    if (!this.m_bIsFreeze && this.m_bIsFreeze != this.m_bIsStateFreeze || this.m_bIsFreeze && this.m_bIsFreeze == this.m_bIsStateFreeze)
      return;
    this.freeze(this.m_bIsFreeze);
  }

  public void freeze(bool bEnable)
  {
    if (bEnable)
    {
      if ((double) this.m_CurAnimState.speed >= 9.9999997473787516E-06)
      {
        this.m_OldSpeed = this.m_CurAnimState.speed;
        this.m_OldAnimName = this.m_CurAnimName;
      }
      this.m_CurAnimState.speed = 0.0f;
    }
    else if (this.m_CurAnimName == this.m_OldAnimName)
      this.m_CurAnimState.speed = this.m_OldSpeed;
    else
      this.resetAnimationSpeed();
  }

  private bool checkMove()
  {
    if (this.m_bMoveDirty && ((UnityEngine.Object) this.m_Target != (UnityEngine.Object) null || (double) this.m_targetPos.x >= 0.0 || this.movePos.HasValue))
    {
      if (this.movePos.HasValue)
        AnimationUnit.Vec3Instance = this.movePos.Value;
      else if ((double) this.m_targetPos.x >= 0.0)
        AnimationUnit.Vec3Instance = this.m_targetPos;
      else if ((UnityEngine.Object) this.m_Target != (UnityEngine.Object) null)
        AnimationUnit.Vec3Instance = this.m_Target.transform.position;
      if (this.transform.position == AnimationUnit.Vec3Instance)
      {
        if (this.m_CurAnimName == AnimationUnit.AnimName.RUN)
        {
          this.changeAnim(AnimationUnit.AnimName.IDLE);
          this.m_HeroState = HERO_STATE_ENUM.HERO_COMMANDS_IDLE;
        }
        this.m_bMoveDirty = false;
        this.m_Target = (GameObject) null;
      }
      else
      {
        float num = !this.m_bMoveSpeedFix ? Time.smoothDeltaTime : this.m_MovingDeltaTime;
        if (this.m_lastTargetPos != AnimationUnit.Vec3Instance)
        {
          if (this.bKnockBacking)
          {
            this.m_lastTargetPos = AnimationUnit.Vec3Instance;
            this.m_lastTargetPos.y = 0.0f;
          }
          else
            this.updateDirection(AnimationUnit.Vec3Instance);
        }
        this.transform.position = GameConstants.MoveTowards(this.transform.position, this.m_lastTargetPos, this.m_CurMoveSpeed * num);
        if (this.m_Direction != this.transform.rotation)
          this.transform.rotation = Quaternion.Slerp(this.transform.rotation, this.m_Direction, 8f * num);
        return true;
      }
    }
    return false;
  }

  public void SetWaitIdle()
  {
    this.m_Animation["idle"].speed = 1f;
    this.m_Animation["idle"].wrapMode = WrapMode.Loop;
    this.m_CurAnimState = this.m_Animation.CrossFadeQueued("idle");
    this.m_IsAttacking = false;
    this.m_CurAnimName = AnimationUnit.AnimName.IDLE;
    this.bMaxSkillLooping = false;
    this.m_ChannelSkillFlag = (byte) 0;
  }

  public void SetupResidentEffect(ushort EffID)
  {
    if ((UnityEngine.Object) this.ResidentEffect != (UnityEngine.Object) null)
      ParticleManager.Instance.DeSpawn(this.ResidentEffect);
    this.ResidentEffect = ParticleManager.Instance.Spawn(EffID, this.transform, Vector3.zero, 1f, true, bCheckOnecEffect: false);
  }

  private void changeAnim(AnimationUnit.AnimName an, float fadeLength = 0.1f)
  {
    if (an != AnimationUnit.AnimName.RUN && this.m_bMoveDirty)
      this.m_bMoveDirty = false;
    if (this.m_bIsInHurricane == AnimationUnit.EBuffStatus.END || this.m_bIsInHitFlying == AnimationUnit.EBuffStatus.END)
    {
      if (this.m_bIsInHurricane == AnimationUnit.EBuffStatus.END)
        this.m_bIsInHurricane = AnimationUnit.EBuffStatus.NONE;
      if (this.m_bIsInHitFlying == AnimationUnit.EBuffStatus.END)
        this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.NONE;
      if (this.m_bIsInHurricane == AnimationUnit.EBuffStatus.NONE && this.m_bIsInHitFlying == AnimationUnit.EBuffStatus.NONE)
      {
        AnimationUnit.QuatInstance.Set(0.0f, 0.0f, 0.0f, 1f);
        this.modelRoot.localRotation = AnimationUnit.QuatInstance;
        this.modelRoot.localPosition = Vector3.zero;
      }
    }
    if ((UnityEngine.Object) this.m_Animation.GetClip(AnimationUnit.ANIM_STRING[(int) an]) == (UnityEngine.Object) null)
      an = an == AnimationUnit.AnimName.SKILL1 || an == AnimationUnit.AnimName.SKILL2 || an == AnimationUnit.AnimName.SKILL3 ? AnimationUnit.AnimName.ATTACK : AnimationUnit.AnimName.IDLE;
    this.m_Animation.CrossFade(AnimationUnit.ANIM_STRING[(int) an], fadeLength);
    this.m_CurAnimState = this.m_Animation[AnimationUnit.ANIM_STRING[(int) an]];
    this.m_IsAttacking = false;
    this.m_CurAnimName = an;
    this.bMaxSkillLooping = false;
    if (this.m_bIsFreeze || this.m_bIsStateFreeze)
    {
      this.m_OldSpeed = this.m_AnimTimeScale;
      this.m_CurAnimState.speed = 0.0f;
    }
    else
      this.resetAnimationSpeed();
    if (this.m_ChannelSkillFlag == (byte) 2)
      this.m_ChannelSkillFlag = (byte) 0;
    if (this.m_ChannelSkillFlag != (byte) 1)
    {
      if ((bool) (UnityEngine.Object) this.m_RangeHitParticleObj || (bool) (UnityEngine.Object) this.m_FightParticleObj)
        this.m_CurMoveSpeed = 2f;
      this.cleanAttackParticle();
    }
    if (this.m_ScaleWorkingState != (byte) 2)
      return;
    this.m_ScaleWorkingState = (byte) 1;
  }

  private void resetAnimationSpeed()
  {
    float num = this.m_AnimTimeScale;
    if (this.m_CurAnimName == AnimationUnit.AnimName.RUN)
      num = 1f / this.m_NpcScale * (float) (1.0 + ((double) this.m_CurMoveSpeed - 2.0) * 0.20000000298023224);
    else if (this.m_CurAnimName != AnimationUnit.AnimName.ATTACK && this.m_CurAnimName != AnimationUnit.AnimName.SKILL1 && this.m_CurAnimName != AnimationUnit.AnimName.SKILL2 && this.m_CurAnimName != AnimationUnit.AnimName.SKILL3)
      num = 1f;
    this.m_CurAnimState.speed = num;
  }

  private void initAnimation()
  {
    this.m_Animation.wrapMode = WrapMode.Loop;
    if ((bool) (UnityEngine.Object) this.m_Animation.GetClip(AnimationUnit.ANIM_STRING[2]))
      this.m_Animation[AnimationUnit.ANIM_STRING[2]].wrapMode = WrapMode.Once;
    if ((bool) (UnityEngine.Object) this.m_Animation.GetClip(AnimationUnit.ANIM_STRING[3]))
      this.m_Animation[AnimationUnit.ANIM_STRING[3]].wrapMode = WrapMode.Once;
    if ((bool) (UnityEngine.Object) this.m_Animation.GetClip(AnimationUnit.ANIM_STRING[4]))
      this.m_Animation[AnimationUnit.ANIM_STRING[4]].wrapMode = WrapMode.Once;
    if ((bool) (UnityEngine.Object) this.m_Animation.GetClip(AnimationUnit.ANIM_STRING[5]))
      this.m_Animation[AnimationUnit.ANIM_STRING[5]].wrapMode = WrapMode.Once;
    if ((bool) (UnityEngine.Object) this.m_Animation.GetClip(AnimationUnit.ANIM_STRING[6]))
      this.m_Animation[AnimationUnit.ANIM_STRING[6]].wrapMode = WrapMode.Once;
    if (!(bool) (UnityEngine.Object) this.m_Animation.GetClip(AnimationUnit.ANIM_STRING[7]))
      return;
    this.m_Animation[AnimationUnit.ANIM_STRING[7]].wrapMode = WrapMode.Once;
  }

  public void setAttackSlowDown()
  {
    if (!this.m_IsAttacking)
      return;
    this.slowMotionTime = this.m_CurAnimState.length * 0.2f;
    this.slowMotionTime = Mathf.Clamp(this.slowMotionTime, 0.1f, 0.2f);
    if ((double) this.m_CurAnimState.time + (double) this.slowMotionTime >= (double) this.m_CurAnimState.length)
      return;
    this.slowMotionCounter = this.slowMotionTime;
    this.m_CurAnimState.speed = 0.0f;
    this.bSlowMotion = true;
  }

  public bool checkRangeHitParticle(
    ushort skillID,
    Transform targetPos,
    uint curTick,
    byte fromSide)
  {
    if ((UnityEngine.Object) this.m_RangeHitParticleObj != (UnityEngine.Object) null || skillID == (ushort) 0 || (int) curTick == (int) this.m_LastRangeParticleTick)
      return false;
    Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
    if (recordByKey.RangeHitParticle == (ushort) 0)
      return false;
    if (recordByKey.SkillKind == (byte) 13)
    {
      AnimationUnit.Vec3Instance.Set(11.9f, 0.0f, 5.5f);
      this.m_RangeHitParticleObj = ParticleManager.Instance.Spawn(recordByKey.RangeHitParticle, (Transform) null, AnimationUnit.Vec3Instance, 1f, true, false);
      if ((UnityEngine.Object) this.m_RangeHitParticleObj != (UnityEngine.Object) null)
      {
        if (fromSide == (byte) 0)
          AnimationUnit.QuatInstance.Set(0.0f, 0.7f, 0.0f, 0.7f);
        else
          AnimationUnit.QuatInstance.Set(0.0f, -0.7f, 0.0f, 0.7f);
        this.m_RangeHitParticleObj.transform.rotation = AnimationUnit.QuatInstance;
      }
    }
    if ((UnityEngine.Object) this.m_RangeHitParticleObj != (UnityEngine.Object) null)
    {
      ParticleSystem component = this.m_RangeHitParticleObj.transform.GetChild(0).GetComponent<ParticleSystem>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null && !component.loop)
        this.m_RangeHitParticleObj = (GameObject) null;
    }
    this.m_LastRangeParticleTick = curTick;
    return true;
  }

  public bool checkRangeHitParticle_position(
    ushort skillID,
    Vector3 targetPos,
    uint curTick,
    byte fromSide)
  {
    if ((UnityEngine.Object) this.m_RangeHitParticleObj != (UnityEngine.Object) null || skillID == (ushort) 0)
      return false;
    Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
    if (recordByKey.RangeHitParticle == (ushort) 0)
      return false;
    byte skillKind = recordByKey.SkillKind;
    switch (skillKind)
    {
      case 1:
      case 2:
      case 3:
        this.m_RangeHitParticleObj = ParticleManager.Instance.Spawn(recordByKey.RangeHitParticle, this.transform, this.transform.position, 1f, true, false);
        break;
      case 4:
label_8:
        this.m_RangeHitParticleObj = ParticleManager.Instance.Spawn(recordByKey.RangeHitParticle, this.transform, targetPos, 1f, true, false);
        break;
      case 5:
label_9:
        AnimationUnit.Vec3Instance.Set(11.9f, 0.0f, 5.5f);
        this.m_RangeHitParticleObj = ParticleManager.Instance.Spawn(recordByKey.RangeHitParticle, (Transform) null, AnimationUnit.Vec3Instance, 1f, true, false);
        if ((UnityEngine.Object) this.m_RangeHitParticleObj != (UnityEngine.Object) null)
        {
          if (fromSide == (byte) 0)
            AnimationUnit.QuatInstance.Set(0.0f, 0.7f, 0.0f, 0.7f);
          else
            AnimationUnit.QuatInstance.Set(0.0f, -0.7f, 0.0f, 0.7f);
          this.m_RangeHitParticleObj.transform.rotation = AnimationUnit.QuatInstance;
          break;
        }
        break;
      case 10:
label_14:
        this.m_RangeHitParticleObj = ParticleManager.Instance.Spawn(recordByKey.RangeHitParticle, (Transform) null, targetPos, 1f, true, false);
        if ((UnityEngine.Object) this.m_RangeHitParticleObj != (UnityEngine.Object) null)
        {
          if (fromSide == (byte) 0)
            AnimationUnit.QuatInstance.Set(0.0f, 0.7f, 0.0f, 0.7f);
          else
            AnimationUnit.QuatInstance.Set(0.0f, -0.7f, 0.0f, 0.7f);
          this.m_RangeHitParticleObj.transform.rotation = AnimationUnit.QuatInstance;
          break;
        }
        break;
      case 12:
label_19:
        this.m_RangeHitParticleObj = ParticleManager.Instance.Spawn(recordByKey.RangeHitParticle, (Transform) null, this.transform.position, 1f, true, false);
        if ((UnityEngine.Object) this.m_RangeHitParticleObj != (UnityEngine.Object) null)
        {
          if (fromSide == (byte) 0)
            AnimationUnit.QuatInstance.Set(0.0f, 0.7f, 0.0f, 0.7f);
          else
            AnimationUnit.QuatInstance.Set(0.0f, -0.7f, 0.0f, 0.7f);
          this.m_RangeHitParticleObj.transform.rotation = AnimationUnit.QuatInstance;
          break;
        }
        break;
      default:
        switch (skillKind)
        {
          case 57:
            goto label_14;
          case 59:
            goto label_19;
          default:
            switch (skillKind)
            {
              case 51:
                goto label_8;
              case 52:
                goto label_9;
            }
            break;
        }
    }
    if ((UnityEngine.Object) this.m_RangeHitParticleObj != (UnityEngine.Object) null)
    {
      ParticleSystem component = this.m_RangeHitParticleObj.transform.GetChild(0).GetComponent<ParticleSystem>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null && !component.loop)
        this.m_RangeHitParticleObj = (GameObject) null;
    }
    this.m_LastRangeParticleTick = curTick;
    return true;
  }

  public void checkRangeHitSound(ushort skillID, uint curTick)
  {
    if (skillID == (ushort) 0 || (int) curTick == (int) this.m_LastRangeHitSoundTick)
      return;
    Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
    if ((int) recordByKey.SkillKey == (int) skillID && recordByKey.HitSound != (ushort) 0)
      AudioManager.Instance.PlaySFX(recordByKey.HitSound, pitchkind: PitchKind.Hit, PlayObj: this.transform);
    this.m_LastRangeHitSoundTick = curTick;
  }

  public void setState(
    HERO_STATE_ENUM state,
    GameObject target = null,
    int paramA = 0,
    int paramB = 0,
    int paramC = 0)
  {
    if (this.m_HeroState == HERO_STATE_ENUM.HERO_COMMANDS_DIE && this.m_CurAnimName == AnimationUnit.AnimName.DIE)
      return;
    HERO_STATE_ENUM heroState = this.m_HeroState;
    this.m_HeroState = state;
    switch (state)
    {
      case HERO_STATE_ENUM.HERO_COMMANDS_IDLE:
        if ((UnityEngine.Object) target != (UnityEngine.Object) null)
          this.updateDirection(target.transform.position);
        float fadeLength = 0.1f;
        if (paramA != 0)
          fadeLength = (float) paramA * 0.01f;
        this.changeAnim(AnimationUnit.AnimName.IDLE, fadeLength);
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_MOVE:
        this.m_targetPos = AnimationUnit.NON_TARGET_POS;
        this.m_Target = target;
        this.m_bMoveDirty = true;
        this.changeAnim(AnimationUnit.AnimName.RUN, DataManager.Instance.HeroTable.GetRecordByKey(this.m_NpcID).Modle != (ushort) 251 ? 0.1f : 0.5f);
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_ATTACK:
        this.Attack(target, (ushort) paramA);
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_GETHIT:
        byte num1 = (byte) (paramC & 1);
        byte num2 = (byte) (paramC >> 1 & 1);
        byte num3 = (byte) (paramC >> 2 & 1);
        byte num4 = (byte) (paramC >> 3 & 1);
        if (num2 != (byte) 0)
        {
          if (num1 != (byte) 0)
          {
            if (this.m_ChannelSkillFlag == (byte) 0 && ((int) this.m_SpecialEffList & 1473) == 0)
            {
              this.changeAnim(AnimationUnit.AnimName.PAIN, 0.2f);
              this.m_HitSoundFlag = (byte) 1;
              if ((TrackedReference) this.m_CurAnimState != (TrackedReference) null)
                this.m_CurAnimState.speed = this.m_CurAnimState.length / 0.7f;
            }
          }
          else if (heroState == HERO_STATE_ENUM.HERO_COMMANDS_IDLE && ((int) this.m_SpecialEffList & 1473) == 0 && this.m_CurAnimName != AnimationUnit.AnimName.SKILL1)
          {
            this.changeAnim(AnimationUnit.AnimName.PAIN);
            this.m_HitSoundFlag = (byte) 1;
          }
          this.m_ShakeCounter = 0.2f;
          if (this.m_bShakeSelf == (byte) 0)
            this.m_bShakeSelf = (byte) 1;
        }
        this.m_HeroState = heroState;
        if (num4 != (byte) 0)
        {
          ParticleManager.Instance.Spawn((ushort) 63, this.transform, this.HitPointRoot.position, 1f, true, false);
          break;
        }
        this.playHitParticle(paramA, num3 == (byte) 1);
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_DIE:
        if (!this.modelRoot.gameObject.activeSelf)
          this.modelRoot.gameObject.SetActive(true);
        this.cleanStateParticle();
        this.CleanStateDisplay();
        this.m_HeroState = HERO_STATE_ENUM.HERO_COMMANDS_DIE;
        this.m_SpecialEffList = 0U;
        if (this.m_bIsStateFreeze)
          this.setStateFreeze(false);
        this.StateColorSkin = 0U;
        this.m_LastSkinStateID = (ushort) 0;
        this.changeAnim(AnimationUnit.AnimName.DIE);
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_GOT_STATE:
        Buff recordByKey1 = DataManager.Instance.BuffTable.GetRecordByKey((ushort) paramA);
        uint key = (uint) (ushort) paramA & (uint) ushort.MaxValue | (uint) recordByKey1.SpecialEffects << 24 | (uint) recordByKey1.ReplaceGroups << 16;
        if (paramB == 1)
        {
          switch ((AnimationUnit.EState) recordByKey1.SpecialEffects)
          {
            case AnimationUnit.EState.BANISH:
            case AnimationUnit.EState.HURRICANE:
              this.cleanStateParticle();
              this.cleanAttackParticle();
              break;
          }
          if (this.m_ChannelSkillFlag == (byte) 2)
          {
            Skill recordByKey2 = DataManager.Instance.SkillTable.GetRecordByKey(this.m_ChannelSkillID);
            uint num5 = recordByKey1.SpecialEffects == (byte) 0 ? 0U : (uint) (1 << (int) recordByKey1.SpecialEffects - 1);
            if (recordByKey2.HurtKind == (byte) 0 && ((int) num5 & 1513) != 0)
              this.cleanAttackParticle();
            else if (recordByKey2.HurtKind == (byte) 1 && ((int) num5 & 1509) != 0)
              this.cleanAttackParticle();
            else if (((int) num5 & 1473) != 0)
              this.cleanAttackParticle();
          }
          GameObject gameObject = (GameObject) null;
          ushort particle = recordByKey1.Particle;
          bool flag1 = this.m_StateParticleMap.ContainsKey(key);
          if (particle != (ushort) 0 && !flag1)
          {
            AnimationUnit.QuatInstance.Set(0.0f, 0.0f, 0.0f, 1f);
            bool flag2 = recordByKey1.FaceCamera != (byte) 0;
            gameObject = recordByKey1.ParticlePos != (byte) 1 ? (recordByKey1.ParticlePos != (byte) 2 ? (recordByKey1.ParticlePos != (byte) 3 ? ParticleManager.Instance.Spawn(particle, this.transform, this.transform.position, this.m_NpcScale, true, false) : ParticleManager.Instance.Spawn(particle, this.transform, Vector3.zero, this.m_NpcScale, true, !flag2)) : ParticleManager.Instance.Spawn(particle, this.HitPointRoot, Vector3.zero, this.m_NpcScale, true, !flag2)) : ParticleManager.Instance.Spawn(particle, this.m_FlyRoot, Vector3.zero, this.m_NpcScale, true, !flag2);
            if ((UnityEngine.Object) gameObject != (UnityEngine.Object) null)
            {
              if (recordByKey1.ParticlePos == (byte) 3)
                gameObject.transform.localRotation = Quaternion.identity;
              else
                gameObject.transform.rotation = AnimationUnit.QuatInstance;
              if (flag2)
              {
                this.m_StateRotationParticleList.Add(gameObject.transform);
              }
              else
              {
                this.m_StateParticleList.Add(gameObject.transform);
                this.m_StateParticlePosList.Add(recordByKey1.ParticlePos);
              }
            }
          }
          if (flag1)
          {
            AnimationUnit.EStateNode stateParticle = this.m_StateParticleMap[key];
            ++stateParticle.refCount;
            this.m_StateParticleMap[key] = stateParticle;
            break;
          }
          this.m_StateParticleMap.Add(key, new AnimationUnit.EStateNode()
          {
            refCount = (byte) 1,
            particle = (UnityEngine.Object) gameObject
          });
          if (recordByKey1.SpecialEffects != (byte) 0)
          {
            if (recordByKey1.SpecialEffects == (byte) 8)
              this.CleanStateDisplay();
            uint specialEffList = this.m_SpecialEffList;
            this.m_SpecialEffList |= (uint) (1 << (int) recordByKey1.SpecialEffects - 1);
            if ((int) this.m_SpecialEffList != (int) specialEffList)
              this.updateStateDisplay(recordByKey1.SpecialEffects, false);
            if (recordByKey1.SpecialEffects == (byte) 11)
            {
              this.m_HitFlyingLength = (float) recordByKey1.Length * (1f / 1000f);
              this.m_HitFlyingTime = 0.0f;
              if (!this.IsCharging)
                this.m_bMoveDirty = false;
              if (((int) this.m_SpecialEffList & 192) == 0)
              {
                this.changeAnim(AnimationUnit.AnimName.PAIN, 0.2f);
                if ((TrackedReference) this.m_CurAnimState != (TrackedReference) null && this.m_CurAnimName == AnimationUnit.AnimName.PAIN)
                  this.m_CurAnimState.speed = this.m_CurAnimState.length / (this.m_HitFlyingLength * 0.5f);
              }
            }
          }
          if (recordByKey1.SpecialEffects > (byte) 0 && recordByKey1.SpecialEffects <= (byte) 6)
          {
            if (!this.StateEffList.Contains(recordByKey1.SpecialEffects) && this.m_CurSEIndex < 6)
            {
              this.StateEffList.Insert(this.m_CurSEIndex, recordByKey1.SpecialEffects);
              ++this.m_CurSEIndex;
            }
          }
          else if (recordByKey1.EffectNumber > (byte) 0 && recordByKey1.EffectNumber <= (byte) 200)
          {
            byte num6 = (byte) ((uint) recordByKey1.EffectNumber + 6U);
            if (this.StateEffList.Count < 10 && !this.StateEffList.Contains(num6))
              this.StateEffList.Add(num6);
          }
          if (recordByKey1.ColorModify == (byte) 0)
            break;
          if (this.StateColorSkin != 0U)
          {
            Buff recordByKey3 = DataManager.Instance.BuffTable.GetRecordByKey(this.m_LastSkinStateID);
            if ((int) recordByKey1.ReplaceGroups <= (int) recordByKey3.ReplaceGroups)
              break;
            this.StateColorSkin = (uint) recordByKey1.ColorModify;
            this.m_LastSkinStateID = recordByKey1.BuffKey;
            break;
          }
          this.StateColorSkin = (uint) recordByKey1.ColorModify;
          this.m_LastSkinStateID = recordByKey1.BuffKey;
          break;
        }
        AnimationUnit.EStateNode stateParticle1 = this.m_StateParticleMap[key];
        --stateParticle1.refCount;
        bool flag3 = false;
        if (stateParticle1.refCount <= (byte) 0)
        {
          if (recordByKey1.Particle != (ushort) 0)
          {
            GameObject particle = (GameObject) stateParticle1.particle;
            if ((UnityEngine.Object) particle != (UnityEngine.Object) null)
            {
              if (recordByKey1.FaceCamera != (byte) 0)
              {
                for (int index = 0; index < this.m_StateRotationParticleList.Count; ++index)
                {
                  if ((UnityEngine.Object) this.m_StateRotationParticleList[index] == (UnityEngine.Object) particle.transform)
                  {
                    this.m_StateRotationParticleList.RemoveAt(index);
                    break;
                  }
                }
              }
              else
              {
                for (int index = 0; index < this.m_StateParticleList.Count; ++index)
                {
                  if ((UnityEngine.Object) this.m_StateParticleList[index] == (UnityEngine.Object) particle.transform)
                  {
                    this.m_StateParticleList.RemoveAt(index);
                    this.m_StateParticlePosList.RemoveAt(index);
                    break;
                  }
                }
              }
              ParticleManager.Instance.DeSpawn(particle);
            }
          }
          this.m_StateParticleMap.Remove(key);
          flag3 = true;
        }
        else
          this.m_StateParticleMap[key] = stateParticle1;
        if (!flag3)
          break;
        if (recordByKey1.SpecialEffects != (byte) 0)
        {
          bool flag4 = false;
          for (int index = 0; index < this.m_StateParticleMap.Keys.Length; ++index)
          {
            if (this.m_StateParticleMap.Keys[index] != 0U && (int) (byte) (this.m_StateParticleMap.Keys[index] >> 24) == (int) recordByKey1.SpecialEffects)
            {
              flag4 = true;
              break;
            }
          }
          if (!flag4)
          {
            this.m_SpecialEffList &= (uint) ~(1 << (int) recordByKey1.SpecialEffects - 1);
            this.updateStateDisplay(recordByKey1.SpecialEffects, true);
            if (recordByKey1.SpecialEffects == (byte) 9)
              this.m_HurricanFinishSpeed = recordByKey1.StepTime == (ushort) 0 ? 1000f : (float) (1.0 / ((double) recordByKey1.StepTime * (1.0 / 1000.0))) * this.modelRoot.localPosition.y;
          }
        }
        if (this.StateEffList.Count > 0)
        {
          if (recordByKey1.SpecialEffects > (byte) 0 && recordByKey1.SpecialEffects <= (byte) 6)
          {
            if (this.StateEffList.Contains(recordByKey1.SpecialEffects))
            {
              this.StateEffList.Remove(recordByKey1.SpecialEffects);
              this.m_CurSEIndex = this.m_CurSEIndex <= 0 ? 0 : this.m_CurSEIndex - 1;
            }
          }
          else if (recordByKey1.EffectNumber > (byte) 0 && recordByKey1.EffectNumber <= (byte) 200)
          {
            byte num7 = (byte) ((uint) recordByKey1.EffectNumber + 6U);
            if (this.StateEffList.Contains(num7))
            {
              bool flag5 = false;
              for (int index = 0; index < this.m_StateParticleMap.Keys.Length; ++index)
              {
                if (this.m_StateParticleMap.Keys[index] != 0U && (int) DataManager.Instance.BuffTable.GetRecordByKey((ushort) (this.m_StateParticleMap.Keys[index] & (uint) ushort.MaxValue)).EffectNumber + 6 == (int) num7)
                {
                  flag5 = true;
                  break;
                }
              }
              if (!flag5)
                this.StateEffList.Remove(num7);
            }
          }
        }
        if (this.StateColorSkin == 0U || (int) this.m_LastSkinStateID != (int) recordByKey1.BuffKey)
          break;
        int num8 = 0;
        this.StateColorSkin = 0U;
        this.m_LastSkinStateID = (ushort) 0;
        if (this.m_StateParticleMap.Count <= 0)
          break;
        for (int index = 0; index < this.m_StateParticleMap.Keys.Length; ++index)
        {
          if (this.m_StateParticleMap.Keys[index] != 0U)
          {
            Buff recordByKey4 = DataManager.Instance.BuffTable.GetRecordByKey((ushort) (this.m_StateParticleMap.Keys[index] & (uint) ushort.MaxValue));
            if (recordByKey4.ColorModify != (byte) 0 && (int) recordByKey4.ReplaceGroups > num8)
            {
              int replaceGroups = (int) recordByKey4.ReplaceGroups;
              this.StateColorSkin = (uint) recordByKey4.ColorModify;
              this.m_LastSkinStateID = recordByKey4.BuffKey;
              break;
            }
          }
        }
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_STOP_CHANNEL:
        if (this.m_ChannelSkillFlag == (byte) 0)
          break;
        int an1 = this.m_FrontAnimTemp & (int) ushort.MaxValue;
        float num9 = (float) (this.m_FrontAnimTemp >> 16) * (1f / 1000f);
        this.changeAnim((AnimationUnit.AnimName) an1);
        this.m_CurAnimState.time = num9;
        this.m_ChannelSkillFlag = (byte) 0;
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_POINT:
        Skill recordByKey5 = DataManager.Instance.SkillTable.GetRecordByKey((ushort) paramA);
        if (recordByKey5.SkillKind == (byte) 16 || recordByKey5.SkillKind == (byte) 17)
        {
          this.transform.position = this.m_targetPos;
          break;
        }
        this.m_bMoveDirty = true;
        this.m_CurMoveSpeed *= 10f;
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_POINT_END:
        if (this.transform.position != this.m_targetPos)
          this.transform.position = this.m_targetPos;
        if (this.m_ChannelSkillFlag != (byte) 0)
        {
          int an2 = this.m_FrontAnimTemp & (int) ushort.MaxValue;
          float num10 = (float) (this.m_FrontAnimTemp >> 16) * (1f / 1000f);
          this.changeAnim((AnimationUnit.AnimName) an2);
          this.m_CurAnimState.time = num10;
          this.m_ChannelSkillFlag = (byte) 0;
        }
        this.m_CurMoveSpeed = 2f;
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_TARGET:
        Skill recordByKey6 = DataManager.Instance.SkillTable.GetRecordByKey((ushort) paramA);
        if (recordByKey6.SkillKind == (byte) 16 || recordByKey6.SkillKind == (byte) 17)
        {
          this.transform.position = this.m_targetPos;
          break;
        }
        this.m_bMoveDirty = true;
        this.m_CurMoveSpeed *= 10f;
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_TARGET_END:
        if (this.transform.position != this.m_targetPos)
          this.transform.position = this.m_targetPos;
        if (this.m_ChannelSkillFlag != (byte) 0)
        {
          int an3 = this.m_FrontAnimTemp & (int) ushort.MaxValue;
          float num11 = (float) (this.m_FrontAnimTemp >> 16) * (1f / 1000f);
          this.changeAnim((AnimationUnit.AnimName) an3);
          this.m_CurAnimState.time = num11;
          this.m_ChannelSkillFlag = (byte) 0;
        }
        this.m_CurMoveSpeed = 2f;
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_KNOCK_BACK:
        this.m_CurMoveSpeed = 2f;
        this.m_CurMoveSpeed *= 6f;
        this.bKnockBacking = true;
        if (!this.m_bIsFreeze && !this.IsStateDisplay(AnimationUnit.EState.FREEZE))
        {
          this.changeAnim(AnimationUnit.AnimName.PAIN);
          float num12 = Vector3.Distance(this.transform.position, this.m_targetPos);
          if ((double) num12 >= 1.0 / 1000.0 && (double) this.m_CurMoveSpeed >= 1.0 / 1000.0)
            this.m_CurAnimState.speed = this.m_CurAnimState.length / (num12 / this.m_CurMoveSpeed);
          this.m_Direction = Quaternion.LookRotation(this.transform.position - this.m_targetPos);
        }
        this.m_bMoveDirty = true;
        this.IsCharging = true;
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_KNOCK_BACK_END:
        this.m_CurMoveSpeed = 2f;
        this.bKnockBacking = false;
        AnimationUnit.Vec3Instance = this.modelRoot.position;
        AnimationUnit.Vec3Instance.y = 0.0f;
        this.modelRoot.position = AnimationUnit.Vec3Instance;
        this.updateStateDisplay((byte) this.m_DisplayState, false);
        this.IsCharging = false;
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_VICTORY:
        AnimationUnit.Vec3Instance.Set(Camera.main.transform.position.x, 0.0f, Camera.main.transform.position.z);
        this.m_Direction = Quaternion.LookRotation(AnimationUnit.Vec3Instance - this.transform.position);
        this.cleanStateParticle();
        this.m_VictoryDelay = UnityEngine.Random.Range(0.0f, 0.2f);
        this.m_HeroState = HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_LOOP;
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_IDLE:
        float num13 = 100f;
        AnimationUnit.Vec3Instance.Set(this.transform.position.x + num13, 0.0f, this.transform.position.z);
        this.m_targetPos = AnimationUnit.Vec3Instance;
        this.m_Target = (GameObject) null;
        this.m_Direction = Quaternion.LookRotation(AnimationUnit.Vec3Instance - this.transform.position);
        this.cleanStateParticle();
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_RUN:
        this.m_bMoveDirty = true;
        this.m_bMoveSpeedFix = false;
        this.m_CurMoveSpeed = 10f;
        this.changeAnim(AnimationUnit.AnimName.RUN);
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_VICTORY_RUN_GAMBLE:
        this.m_targetPos = Vector3.right * 1000f;
        this.cleanStateParticle();
        this.m_bMoveDirty = true;
        this.m_bMoveSpeedFix = false;
        this.m_CurMoveSpeed = 10f;
        this.changeAnim(AnimationUnit.AnimName.RUN);
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_PVPNPC_IDLE:
        this.m_Animation["victory"].wrapMode = WrapMode.Once;
        this.m_Animation["victory"].layer = 1;
        this.m_Animation["idle"].wrapMode = WrapMode.Loop;
        this.m_Animation["idle"].layer = 0;
        this.changeAnim(AnimationUnit.AnimName.IDLE, 0.3f);
        this.m_VictoryDelay = UnityEngine.Random.Range(1f, 3f);
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_CHARGE_DAZE:
        if (heroState == HERO_STATE_ENUM.HERO_COMMANDS_DIE)
        {
          this.m_HeroState = HERO_STATE_ENUM.HERO_COMMANDS_DIE;
          break;
        }
        if (this.m_bIsFreeze || ((int) this.m_SpecialEffList & 192) != 0)
          break;
        this.changeAnim(AnimationUnit.AnimName.DAZE);
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_WAITING_SUPPORT:
        this.m_SupportType = paramA;
        this.modelRoot.gameObject.SetActive(false);
        this.m_targetPos = this.modelRoot.localPosition;
        if (this.m_SupportType == 1)
        {
          Vector3 targetPos = this.m_targetPos with
          {
            y = 10f
          };
          float f = UnityEngine.Random.Range(0.0f, 360f);
          Vector3 vector3 = new Vector3(Mathf.Cos(f), 0.0f, Mathf.Sin(f));
          vector3.Normalize();
          targetPos += vector3 * 3f;
          this.modelRoot.localPosition = targetPos;
        }
        else if (this.m_SupportType == 2)
        {
          this.modelRoot.localPosition = this.m_targetPos with
          {
            y = -3f
          };
          ParticleManager.Instance.Spawn((ushort) 297, (Transform) null, this.Position, 1f, true, false);
        }
        if (BattleController.IsGambleMode)
          this.transform.LookAt(Vector3.left);
        if (!((UnityEngine.Object) this.ResidentEffect != (UnityEngine.Object) null))
          break;
        this.ResidentEffect.SetActive(false);
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_SUPPORT_DISPLAY:
        this.m_targetPos = Vector3.zero;
        this.modelRoot.gameObject.SetActive(true);
        this.changeAnim(AnimationUnit.AnimName.RUN);
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_FINISHING_SPREAD:
        this.m_bMoveDirty = true;
        this.m_bMoveSpeedFix = false;
        this.m_CurMoveSpeed = 2f;
        this.changeAnim(AnimationUnit.AnimName.RUN);
        break;
      case HERO_STATE_ENUM.HERO_COMMANDS_GAMBLEFAILED:
        this.changeAnim(AnimationUnit.AnimName.DAZE);
        break;
    }
  }

  public bool IsStateDisplay(AnimationUnit.EState eff)
  {
    return eff != AnimationUnit.EState.NONE && ((int) (this.m_SpecialEffList >> (int) (byte) eff - 1) & 1) != 0;
  }

  public void CleanStateDisplay()
  {
    for (int index = 0; index < 9; ++index)
    {
      if (((long) this.m_SpecialEffList & (long) (1 << index)) != 0L)
        this.updateStateDisplay((byte) (index + 1), true);
    }
    if (this.IsStateDisplay(AnimationUnit.EState.HURRICANE) || this.IsStateDisplay(AnimationUnit.EState.HITFLYING))
    {
      AnimationUnit.QuatInstance.Set(0.0f, 0.0f, 0.0f, 1f);
      this.modelRoot.localRotation = AnimationUnit.QuatInstance;
      this.modelRoot.localPosition = Vector3.zero;
      this.m_bIsInHurricane = AnimationUnit.EBuffStatus.NONE;
      this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.NONE;
    }
    this.m_SpecialEffList = 0U;
  }

  public void updateStateDisplay(byte specialEff, bool bRemove)
  {
    if (!bRemove)
    {
      switch (specialEff)
      {
        case 1:
          this.changeAnim(AnimationUnit.AnimName.DAZE);
          this.m_DisplayState = AnimationUnit.EState.DAZE;
          break;
        case 2:
          if (this.m_CurAnimName != AnimationUnit.AnimName.RUN)
            break;
          this.m_bMoveDirty = false;
          this.changeAnim(AnimationUnit.AnimName.IDLE);
          break;
        case 7:
          this.setStateFreeze(true);
          this.m_bMoveDirty = false;
          this.m_DisplayState = AnimationUnit.EState.FREEZE;
          break;
        case 8:
          this.modelRoot.gameObject.SetActive(false);
          this.m_bMoveDirty = false;
          this.m_DisplayState = AnimationUnit.EState.BANISH;
          break;
        case 9:
          this.m_DisplayState = AnimationUnit.EState.HURRICANE;
          this.m_bMoveDirty = false;
          this.m_bIsInHurricane = AnimationUnit.EBuffStatus.BEGIN;
          break;
        case 11:
          this.m_DisplayState = AnimationUnit.EState.HITFLYING;
          this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.BEGIN;
          break;
      }
    }
    else
    {
      this.m_DisplayState = AnimationUnit.EState.NONE;
      switch (specialEff)
      {
        case 1:
          this.changeAnim(AnimationUnit.AnimName.IDLE);
          this.heroState = HERO_STATE_ENUM.HERO_COMMANDS_IDLE;
          break;
        case 2:
          if (this.m_CurAnimName != AnimationUnit.AnimName.RUN)
            break;
          this.m_bMoveDirty = true;
          break;
        case 7:
          this.setStateFreeze(false);
          break;
        case 8:
          this.modelRoot.gameObject.SetActive(true);
          this.changeAnim(AnimationUnit.AnimName.IDLE);
          this.heroState = HERO_STATE_ENUM.HERO_COMMANDS_IDLE;
          break;
        case 9:
          this.m_bIsInHurricane = AnimationUnit.EBuffStatus.END;
          break;
        case 11:
          this.m_bIsInHitFlying = AnimationUnit.EBuffStatus.END;
          break;
      }
    }
  }

  public void updateDirection(Vector3 curTargetPos)
  {
    this.m_lastTargetPos = curTargetPos;
    this.m_lastTargetPos.y = 0.0f;
    this.Forward = this.m_lastTargetPos - this.transform.position;
    if (!(this.Forward != Vector3.zero))
      return;
    this.m_Direction = Quaternion.LookRotation(this.Forward);
  }

  public void Attack(GameObject target, ushort skillID)
  {
    this.m_Target = target;
    Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
    if (recordByKey.SkillKind == (byte) 61)
    {
      if (this.m_SpecialEffList != 0U)
      {
        this.CleanStateDisplay();
        this.cleanStateParticle();
        this.m_SpecialEffList = 0U;
      }
      if (this.m_bIsStateFreeze)
        this.setStateFreeze(false);
    }
    int num = 2;
    uint skillKey = this.m_AttackAnimInfo.Find(skillID);
    if (skillKey != 0U)
      num += ((int) skillKey & (int) ushort.MaxValue) - 1;
    if (this.m_ChannelSkillFlag != (byte) 0)
      this.m_ChannelSkillFlag = (byte) 0;
    if (skillKey >> 16 != 0U)
      this.changeAnim((AnimationUnit.AnimName) num, 0.2f);
    this.m_IsAttacking = true;
    this.m_DeltaTimeCounter = 0.0f;
    this.setupAttack(ref recordByKey, (int) skillID, num, skillKey);
    if (!((UnityEngine.Object) this.m_Target != (UnityEngine.Object) null))
      return;
    this.updateDirection(this.m_Target.transform.position);
  }

  private void setupAttack(ref Skill sSkill, int skillID, int attackPos, uint skillKey)
  {
    this.m_HitPointTime = (float) (skillKey >> 16) * (1f / 1000f);
    int index = attackPos - 2;
    int attackAnimation = (int) DataManager.Instance.HeroTable.GetRecordByKey(this.m_NpcID).HeroAttackInfo[index].AttackAnimation;
    if (attackAnimation == 0)
    {
      this.m_LastHitPointTime = this.m_HitPointTime;
    }
    else
    {
      Combo recordByKey = DataManager.Instance.ComboTable.GetRecordByKey((ushort) attackAnimation);
      this.m_LastHitPointTime = (float) recordByKey.HitPoint[(int) recordByKey.Count - 1] * (1f / 1000f);
    }
    this.m_bHitPointSlowDown = sSkill.IsShake != (byte) 0;
    this.m_FightParticleID = sSkill.FireParticle;
    this.m_FightParticlePos = sSkill.FireParticlePos;
    this.m_FightSoundID = sSkill.UltraHitSound;
    this.m_FightSoundDelay = sSkill.FireSoundDelay;
    byte skillKind = sSkill.SkillKind;
    if (AnimationUnit.m_ChannelSkillKindList.Find(skillKind))
    {
      this.m_ChannelSkillFlag = (byte) 1;
      this.m_ChannelSkillID = (ushort) skillID;
      this.m_FrontAnimTemp = (int) skillKey & -65536 | attackPos;
    }
    if ((int) this.m_MaxSkillID == skillID)
      ParticleManager.Instance.Spawn((ushort) 16, this.HitPointRoot, Vector3.zero, 1f, true);
    this.checkPreFireParticle((ushort) skillID);
    if (UnityEngine.Random.Range(0, 4) == 0 && sSkill.FireVocal != (ushort) 0)
      AudioManager.Instance.PlaySFX(sSkill.FireVocal, (float) sSkill.FireVocalDelay * (1f / 1000f), PlayObj: this.transform);
    if (sSkill.FireSound == (ushort) 0)
      return;
    AudioManager.Instance.PlaySFX(sSkill.FireSound, (float) sSkill.FireSoundDelay * (1f / 1000f), PlayObj: this.transform);
  }

  public void playMaxSkill()
  {
    if (this.m_MaxSkillID == (ushort) 0)
      return;
    this.Attack(this.m_Target, this.m_MaxSkillID);
  }

  public bool IsUltraSkill(ushort skillID) => (int) this.m_MaxSkillID == (int) skillID;

  private void playHitParticle(int skillID, bool bIsState)
  {
    Hero recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(this.m_NpcID);
    float npcScale = this.m_NpcScale;
    if ((int) recordByKey1.HeroKey == (int) this.m_NpcID && recordByKey1.HitParticleScaleRate != (ushort) 0)
      npcScale *= (float) recordByKey1.HitParticleScaleRate * 0.01f;
    if (bIsState)
    {
      Buff recordByKey2 = DataManager.Instance.BuffTable.GetRecordByKey((ushort) skillID);
      if (recordByKey2.HitParticle == (ushort) 0)
        return;
      ParticleManager.Instance.Spawn(recordByKey2.HitParticle, this.transform, this.HitPointRoot.position, npcScale, true, false);
    }
    else
    {
      Skill recordByKey3 = DataManager.Instance.SkillTable.GetRecordByKey((ushort) skillID);
      if (recordByKey3.HitParticle == (ushort) 0)
        return;
      switch (recordByKey3.HitParticlePos)
      {
        case 1:
          ParticleManager.Instance.Spawn(recordByKey3.HitParticle, this.m_FlyRoot, Vector3.zero, npcScale, true);
          break;
        case 2:
          ParticleManager.Instance.Spawn(recordByKey3.HitParticle, this.transform, this.HitPointRoot.position, npcScale, true, false);
          break;
        default:
          ParticleManager.Instance.Spawn(recordByKey3.HitParticle, this.transform, this.transform.position, npcScale, true, false);
          break;
      }
    }
  }

  public void setPositionInstantly(Vector3 pos) => this.transform.position = pos;

  public void setNpcScale(float rate)
  {
    AnimationUnit.Vec3Instance.Set(rate, rate, rate);
    this.modelRoot.localScale = AnimationUnit.Vec3Instance;
    this.m_NpcScale = rate;
  }

  public void setScaleInstantly(float rate)
  {
    float num = rate * this.m_NpcScale;
    AnimationUnit.Vec3Instance.Set(num, num, num);
    this.modelRoot.localScale = AnimationUnit.Vec3Instance;
    this.m_ScaleTemp = rate;
    this.m_ScaleWorkingState = (byte) 2;
  }

  public void restoreScale(bool bScale) => this.m_ScaleWorkingState = (byte) 2;

  public bool checkCanUseMaxSkill()
  {
    return this.m_DisplayState != AnimationUnit.EState.DAZE && this.m_DisplayState != AnimationUnit.EState.FREEZE && this.m_DisplayState != AnimationUnit.EState.BANISH && this.m_DisplayState != AnimationUnit.EState.HURRICANE && this.m_DisplayState != AnimationUnit.EState.HITFLYING;
  }

  public enum AnimName : byte
  {
    IDLE,
    RUN,
    ATTACK,
    SKILL1,
    SKILL2,
    SKILL3,
    PAIN,
    DIE,
    VICTORY,
    DAZE,
  }

  public enum EState
  {
    NONE,
    DAZE,
    MOVELOCK,
    MAGICLOCK,
    PHYSLOCK,
    LOSESPIRIT,
    ADDICT,
    FREEZE,
    BANISH,
    HURRICANE,
    MOCK,
    HITFLYING,
  }

  public enum EBuffStatus
  {
    NONE,
    BEGIN,
    STEP,
    END,
  }

  private struct EStateNode
  {
    public byte refCount;
    public UnityEngine.Object particle;
  }

  public delegate void ParentListener(AnimationUnit au, EAUCallBack type, int param = 0);
}
