// Decompiled with JetBrains decompiler
// Type: FSMMeleeFight
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMMeleeFight : FSMUnit
{
  public FSMMeleeFight(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.MELEE_FIGHT;
  }

  public override void Enter(Soldier sam)
  {
    sam.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Default);
    sam.fightTimer = !sam.IsHeroSoldier ? 1.5f : 3f;
    Transform transform = sam.Target.transform;
    Vector3 forward = transform.position - sam.transform.position;
    if (forward != Vector3.zero)
      sam.transform.rotation = Quaternion.LookRotation(forward);
    sam.LastTargetPos = transform.position;
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if (parent.Target != null && parent.Target.GroupKind == EGroupKind.CastleGate)
      return;
    if (sam.Target == null)
      sam.FSMController = FSMManager.Instance.getState(EStateName.LOSETARGET);
    if ((double) sam.fightTimer > 0.0)
    {
      sam.fightTimer -= deltaTime;
      if ((double) sam.fightTimer <= 0.0)
      {
        sam.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Default);
        sam.fightTimer = !sam.IsHeroSoldier ? 1.5f : 3f;
      }
    }
    Transform transform1 = sam.Target.transform;
    Transform transform2 = sam.transform;
    if (parent.Target.CurHP <= 0)
      sam.FSMController = FSMManager.Instance.getState(EStateName.IDLE);
    else if (sam.Target.CurFSM == EStateName.DIE)
    {
      sam.ResetTarget();
      sam.FSMController = FSMManager.Instance.getState(EStateName.TRYFIGHT);
    }
    else if ((double) GameConstants.DistanceSquare(sam.LastTargetPos, transform1.position) <= 9.9999997473787516E-05)
    {
      FSMUnit.CheckDirectionToTarget(sam, deltaTime);
      if (sam.CurAnim != ESheetMeshAnim.attack || (double) sam.LastAnimTime() >= 0.10000000149011612 || (double) sam.CurAnimTime() < 0.10000000149011612)
        return;
      ushort num = 1;
      if (parent.GroupKind == EGroupKind.Catapults)
        num = (ushort) 2006;
      if (parent.GroupKind == EGroupKind.Archer && parent.Tier == (byte) 4)
        num = (ushort) 2005;
      sam.Target.ParticleFlag = (int) num <= (int) sam.Target.ParticleFlag ? sam.Target.ParticleFlag : num;
    }
    else
    {
      float num = sam.AttackRadius + sam.Target.Radius;
      if ((double) GameConstants.DistanceSquare(transform2.position, transform1.position) <= (double) num * (double) num)
        return;
      sam.FSMController = FSMManager.Instance.getState(EStateName.TRYFIGHT);
    }
  }
}
