// Decompiled with JetBrains decompiler
// Type: Lord
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Text;
using UnityEngine;

#nullable disable
public class Lord : Soldier
{
  public const int constLordScaleVal = 3;
  private const float constLordSkilllScale = 1.5f;
  public Animation animComponent;
  public SkinnedMeshRenderer skinRenderer;
  public int assetKey;
  public ushort lordID;
  public float? specHitPoint;
  public float specHitPointCounter;
  private static readonly Vector3 constLordScale = new Vector3(3f, 3f, 3f);
  public float? extraLordScale;
  public bool bExtraScaleWork = true;
  public Vector3 lordScale = Vector3.one;
  public Transform modelTrans;
  public Transform HitPointRoot;
  public Transform WPRoot;
  public bool bCheckHitPoint;
  public bool bHitPointFreezeWork;
  public float FreezePoint;
  public float FreezeLen;
  public float FreezeCounter;

  public Lord(ushort heroID, byte kind, byte tier, byte side, bool isLord, byte param = 0)
  {
    this.transform = new GameObject(((uint) heroID << 16 | (uint) (((int) side | (!isLord ? 0 : 2)) << 8) | (uint) param).ToString()).transform;
    StringBuilder stringBuilder = new StringBuilder(64);
    stringBuilder.Length = 0;
    this.lordID = heroID;
    Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(heroID);
    stringBuilder.AppendFormat("Role/hero_{0:00000}", (object) recordByKey.Modle);
    AssetBundle assetBundle = AssetManager.GetAssetBundle(stringBuilder.ToString(), out this.assetKey);
    GameObject gameObject = ModelLoader.Instance.Load(recordByKey.Modle, assetBundle, (ushort) recordByKey.TextureNo);
    this.modelTrans = gameObject.transform;
    this.modelTrans.parent = this.transform;
    this.lordScale = Lord.constLordScale * ((float) recordByKey.Scale * 0.01f);
    this.modelTrans.localScale = this.lordScale;
    this.modelTrans.position = Vector3.zero;
    this.skinRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
    this.animComponent = gameObject.GetComponent<Animation>();
    AnimationState animationState1 = this.animComponent["idle"];
    animationState1.wrapMode = WrapMode.Loop;
    animationState1.layer = 0;
    if ((Object) this.animComponent.GetClip("moving") == (Object) null)
      this.animComponent.AddClip(this.animComponent.GetClip("idle"), "moving");
    AnimationState animationState2 = this.animComponent["moving"];
    animationState2.layer = 0;
    animationState2.wrapMode = WrapMode.Loop;
    AnimationState animationState3 = this.animComponent["attack"];
    if (kind == (byte) 1 || kind == (byte) 3)
    {
      animationState3.layer = 0;
      animationState3.wrapMode = WrapMode.Loop;
      this.FreezeLen = Mathf.Clamp(animationState3.length * 0.2f, 0.1f, 0.2f);
      this.FreezePoint = (float) recordByKey.HeroAttackInfo[0].HitTime * (1f / 1000f);
    }
    else
    {
      animationState3.layer = 1;
      if (kind == (byte) 2)
      {
        this.attackAnimSpeedRate = (float) recordByKey.HeroAttackInfo[0].HitTime * Soldier.ARCHER_HITTIME_INVERSE;
        animationState3.speed = this.attackAnimSpeedRate;
      }
    }
    AnimationState animationState4 = this.animComponent["daze"];
    animationState4.wrapMode = WrapMode.Loop;
    animationState4.layer = 1;
    Transform[] componentsInChildren = gameObject.GetComponentsInChildren<Transform>();
    for (int index = 0; index < componentsInChildren.Length; ++index)
    {
      if (componentsInChildren[index].name == AnimationUnit.HIT_POINT_ROOTBONE)
        this.HitPointRoot = componentsInChildren[index];
      else if (componentsInChildren[index].name == AnimationUnit.FLY_WEAPON_ROOTBONE)
        this.WPRoot = componentsInChildren[index];
    }
    if ((Object) this.HitPointRoot == (Object) null)
      this.HitPointRoot = this.modelTrans;
    if ((Object) this.WPRoot == (Object) null)
      this.WPRoot = this.modelTrans;
    this.SoldierKind = kind;
    this.SoldierTier = tier;
    this.IsHeroSoldier = true;
    this.createShadow((float) ((double) recordByKey.Radius * 0.0099999997764825821 * 3.0));
  }

  public override Vector3 RangeFirePoint => this.WPRoot.position;

  public override ESheetMeshAnim CurAnim => ESheetMeshAnim.idle;

  public override float AnimLength => this.animComponent[this.lastAnim.ToString()].length;

  public override Renderer renderer => (Renderer) this.skinRenderer;

  public override void Destroy()
  {
    if ((Object) this.animComponent != (Object) null)
    {
      ModelLoader.Instance.Unload((Object) this.animComponent.gameObject);
      AssetManager.UnloadAssetBundle(this.assetKey);
    }
    this.Target = (Soldier) null;
    base.Destroy();
  }

  public override void Update(float delteTime)
  {
    if (this.extraLordScale.HasValue)
    {
      if ((double) this.extraLordScale.Value <= 1.0)
      {
        this.modelTrans.localScale = this.lordScale;
        this.extraLordScale = new float?();
      }
      else if (this.bExtraScaleWork)
      {
        this.modelTrans.localScale = this.lordScale * this.extraLordScale.Value;
        Lord lord = this;
        float? extraLordScale = lord.extraLordScale;
        lord.extraLordScale = !extraLordScale.HasValue ? new float?() : new float?(extraLordScale.Value - delteTime * 2f);
      }
    }
    if (this.specHitPoint.HasValue)
    {
      float specHitPointCounter = this.specHitPointCounter;
      this.specHitPointCounter += delteTime;
      if ((double) specHitPointCounter < (double) this.specHitPoint.Value && (double) this.specHitPointCounter >= (double) this.specHitPoint.Value)
      {
        this.specHitPointCounter = 0.0f;
        this.specHitPoint = new float?();
      }
    }
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
    if (!((Object) this.animComponent != (Object) null))
      return;
    if (this.CurFSM == EStateName.MELEE_FIGHT_IMMEDIATE && !this.animComponent.IsPlaying("attack"))
      this.AnimOnceNotify(ESheetMeshAnim.attack);
    else if (!this.animComponent.isPlaying && this.lastAnim != ESheetMeshAnim.die)
      this.animComponent.CrossFade("idle");
    if (this.bCheckHitPoint)
    {
      float time = this.animComponent["attack"].time;
      if ((double) this.FreezePoint >= (double) this.lastTime && (double) this.FreezePoint <= (double) time)
      {
        this.animComponent["attack"].speed = 0.0f;
        this.bHitPointFreezeWork = true;
        this.bCheckHitPoint = false;
        this.FreezeCounter = 0.0f;
      }
      this.lastTime = time;
    }
    if (!this.bHitPointFreezeWork)
      return;
    if ((double) this.FreezeCounter >= (double) this.FreezeLen)
    {
      this.animComponent["attack"].speed = 1f;
      this.bHitPointFreezeWork = false;
    }
    else
      this.FreezeCounter += delteTime;
  }

  public Vector3 GetHitPoint() => this.HitPointRoot.position;

  public Transform GetHitPointTrans() => this.HitPointRoot;

  public override bool PlayAnim(
    ESheetMeshAnim eAnim,
    SAWrapMode mode = SAWrapMode.Loop,
    bool bRandomStartPoint = true,
    bool bForceReset = false,
    bool bBrokenFO = false)
  {
    if (!((Object) this.animComponent != (Object) null) || !bForceReset && this.lastAnim == ESheetMeshAnim.die)
      return false;
    mode = eAnim != ESheetMeshAnim.die ? mode : SAWrapMode.Once;
    this.animComponent[eAnim.ToString()].wrapMode = mode != SAWrapMode.Loop ? WrapMode.Once : WrapMode.Loop;
    if (eAnim == ESheetMeshAnim.attack)
      this.animComponent.CrossFade("idle");
    if (eAnim == ESheetMeshAnim.die && this.IsLord && (!WarManager.IsNpcModeEnable || this.Parent == null || this.Parent.Side == (byte) 0))
      this.animComponent.CrossFade("daze");
    else if (eAnim == ESheetMeshAnim.attack && this.animComponent.IsPlaying("attack"))
    {
      this.animComponent.CrossFadeQueued("attack", 0.3f, QueueMode.PlayNow).speed = (double) this.attackAnimSpeedRate <= 1.0 / 1000.0 ? 1f : this.attackAnimSpeedRate;
      this.bCheckHitPoint = true;
      this.lastTime = 0.0f;
    }
    else
    {
      if (eAnim == ESheetMeshAnim.attack)
      {
        this.animComponent["attack"].speed = 1f;
        this.bCheckHitPoint = true;
        this.lastTime = 0.0f;
      }
      if (eAnim == ESheetMeshAnim.die)
        this.animComponent.CrossFade(eAnim.ToString(), 0.1f, PlayMode.StopAll);
      else
        this.animComponent.CrossFade(eAnim.ToString());
    }
    this.lastAnim = eAnim;
    this.bExtraScaleWork = true;
    return true;
  }

  public void PlaySkillAnim(ushort skillID)
  {
    if ((Object) this.animComponent == (Object) null)
      return;
    Skill recordByKey = DataManager.Instance.SkillTable.GetRecordByKey(skillID);
    int num1 = 2;
    if (!((Object) this.animComponent.GetClip(AnimationUnit.ANIM_STRING[num1 + (int) recordByKey.StateAddition]) != (Object) null))
      return;
    string animation = AnimationUnit.ANIM_STRING[num1 + (int) recordByKey.StateAddition];
    this.animComponent.CrossFade("idle");
    AnimationState animationState = this.animComponent.CrossFadeQueued(animation, 0.1f, QueueMode.PlayNow);
    animationState.layer = 1;
    animationState.wrapMode = WrapMode.Default;
    ushort num2 = (ushort) ((double) animationState.length * 1000.0);
    if (num2 != (ushort) 0 && (int) num2 != (int) recordByKey.StateValue)
    {
      float num3 = recordByKey.StateValue != (ushort) 0 ? (float) recordByKey.StateValue : (float) num2;
      float num4 = (float) num2 / num3;
      animationState.speed = num4;
      this.specHitPoint = new float?((float) recordByKey.StateIncreaseValue * (1f / 1000f));
    }
    this.lastAnim = ESheetMeshAnim.attack;
    this.extraLordScale = new float?(1.5f);
    this.modelTrans.localScale = this.lordScale * this.extraLordScale.Value;
    this.bExtraScaleWork = false;
  }

  public override void SampleAnimation(ESheetMeshAnim eAnim, float sampleTime)
  {
    if (!((Object) this.animComponent != (Object) null))
      return;
    this.animComponent.Stop();
    this.animComponent.CrossFade("idle");
  }

  public override void LordAnimSetting(byte type)
  {
    if ((Object) this.animComponent == (Object) null)
      return;
    switch (type)
    {
      case 0:
        this.animComponent["victory"].wrapMode = WrapMode.Default;
        this.animComponent["victory"].layer = 1;
        break;
      case 1:
        this.animComponent["victory"].wrapMode = WrapMode.Loop;
        this.animComponent["victory"].layer = 1;
        break;
      case 2:
        this.animComponent["victory"].wrapMode = WrapMode.Loop;
        this.animComponent["victory"].layer = 0;
        break;
    }
    this.animComponent["idle"].wrapMode = WrapMode.Loop;
    this.animComponent["idle"].layer = 0;
  }

  public override Animation getAnimComponent() => this.animComponent;

  public override void ResetAnimToIdle()
  {
    if (!((Object) this.animComponent != (Object) null))
      return;
    this.animComponent.Stop();
    this.animComponent["idle"].wrapMode = WrapMode.Loop;
    this.animComponent.CrossFade("idle", 0.3f, PlayMode.StopSameLayer);
    this.lastAnim = ESheetMeshAnim.idle;
  }

  public override void ResetAnimSettingToDefault()
  {
    AnimationState animationState1 = this.animComponent["idle"];
    animationState1.wrapMode = WrapMode.Loop;
    animationState1.layer = 0;
    AnimationState animationState2 = this.animComponent["moving"];
    animationState2.layer = 0;
    animationState2.speed = 1f;
    animationState2.wrapMode = WrapMode.Loop;
    AnimationState animationState3 = this.animComponent["attack"];
    if (this.SoldierKind == (byte) 1 || this.SoldierKind == (byte) 3)
    {
      animationState3.layer = 0;
      animationState3.wrapMode = WrapMode.Loop;
      animationState3.speed = 1f;
    }
    else
    {
      animationState3.layer = 1;
      if (this.SoldierKind == (byte) 2)
      {
        this.attackAnimSpeedRate = (float) DataManager.Instance.HeroTable.GetRecordByKey(this.Parent.heroSoldierID).HeroAttackInfo[0].HitTime * Soldier.ARCHER_HITTIME_INVERSE;
        animationState3.speed = this.attackAnimSpeedRate;
      }
    }
    AnimationState animationState4 = this.animComponent["daze"];
    animationState4.wrapMode = WrapMode.Loop;
    animationState4.layer = 1;
  }

  public override void RunAnimSpeedUp() => this.animComponent["moving"].speed = 2f;
}
