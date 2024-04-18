// Decompiled with JetBrains decompiler
// Type: FSMRangeFight
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class FSMRangeFight : FSMUnit
{
  public FSMRangeFight(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.RANGE_FIGHT;
  }

  public override void Enter(Soldier sam) => sam.PlayAnim(ESheetMeshAnim.idle);

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if (!FSMUnit.CheckTargetActiving(sam))
      sam.Target = FSMUnit.ReallocTarget(sam, parent.Target);
    FSMUnit.CheckDirectionToTarget(sam, deltaTime);
    if (((int) parent.OnceFlag & 1) == 0)
      return;
    if (sam.Target.CurFSM == EStateName.DYING || sam.Target.CurFSM == EStateName.DIE)
    {
      sam.Target = (Soldier) null;
      sam.Target = FSMUnit.ReallocTarget(sam, parent.Target);
    }
    sam.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Default, false);
  }
}
