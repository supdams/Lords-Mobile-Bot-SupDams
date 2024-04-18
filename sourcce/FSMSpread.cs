// Decompiled with JetBrains decompiler
// Type: FSMSpread
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMSpread : FSMUnit
{
  public FSMSpread(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.SPREAD;
  }

  public override void Enter(Soldier sam)
  {
    sam.ActionMode = EActionMode.Personal;
    sam.PlayAnim(ESheetMeshAnim.moving);
    if ((double) GameConstants.DistanceSquare(sam.SpreadPos, Vector3.zero) > 9.9999997473787516E-05)
      return;
    Vector3 position1 = sam.transform.position;
    Vector3 position2 = new Vector3(Random.Range(-5f, 5f), 0.0f, Random.Range(0.0f, 5f));
    sam.SpreadPos = sam.transform.TransformPoint(position2);
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    Transform transform = sam.transform;
    Vector3 forward = sam.SpreadPos - transform.position;
    if (forward != Vector3.zero)
    {
      Quaternion to = Quaternion.LookRotation(forward);
      if (transform.rotation != to)
        transform.rotation = Quaternion.Slerp(transform.rotation, to, 5f * deltaTime);
    }
    FSMUnit.MoveSoldier(sam, sam.SpreadPos, parent.MoveSpeed * 1.3f * deltaTime);
    if ((double) GameConstants.DistanceSquare(transform.position, sam.SpreadPos) > 9.9999997473787516E-05)
      return;
    if (sam.Parent.Target.GroupKind == EGroupKind.CastleGate)
      sam.FSMController = FSMManager.Instance.getState(EStateName.MOVETO_TARGET);
    else
      sam.FSMController = FSMManager.Instance.getState(EStateName.TRYFIGHT);
  }
}
