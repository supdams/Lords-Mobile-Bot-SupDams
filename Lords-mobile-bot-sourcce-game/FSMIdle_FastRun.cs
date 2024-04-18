// Decompiled with JetBrains decompiler
// Type: FSMIdle_FastRun
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMIdle_FastRun : FSMUnit
{
  public FSMIdle_FastRun(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.IDLE_FASTRUN;
  }

  public override void Enter(Soldier sam)
  {
    if (sam.ActionMode == EActionMode.Team)
      sam.PlayAnim(ESheetMeshAnim.idle);
    else
      sam.PlayAnim(ESheetMeshAnim.moving);
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if (sam.ActionMode == EActionMode.Personal)
    {
      Transform transform = sam.transform;
      Vector3 transformPoint = parent.getTransformPoint((int) sam.Index);
      Vector3 forward = transformPoint - transform.position;
      if (forward != Vector3.zero)
      {
        Quaternion to = Quaternion.LookRotation(forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, to, 5f * deltaTime);
      }
      FSMUnit.MoveSoldier(sam, transformPoint, parent.MoveSpeed * 2.5f * deltaTime);
      if ((double) GameConstants.DistanceSquare(transform.position, transformPoint) > 9.9999997473787516E-05)
        return;
      sam.ActionMode = EActionMode.Team;
      sam.PlayAnim(ESheetMeshAnim.idle);
      sam.NotifyingParent();
    }
    else
    {
      if (!(sam.transform.rotation != parent.groupRoot.rotation))
        return;
      sam.transform.rotation = Quaternion.Slerp(sam.transform.rotation, parent.groupRoot.rotation, 5f * deltaTime);
    }
  }
}
