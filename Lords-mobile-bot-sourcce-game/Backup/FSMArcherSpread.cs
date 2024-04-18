// Decompiled with JetBrains decompiler
// Type: FSMArcherSpread
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMArcherSpread : FSMUnit
{
  public FSMArcherSpread(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.ARCHER_SPREAD;
  }

  public override void Enter(Soldier sam)
  {
    sam.ActionMode = EActionMode.Personal;
    sam.PlayAnim(ESheetMeshAnim.moving);
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
    sam.SpreadPos = Vector3.zero;
    sam.SpreadMode = ESpreadMode.NotSpread;
    if (sam.Parent.Target.GroupKind == EGroupKind.CastleGate)
      sam.FSMController = FSMManager.Instance.getState(EStateName.RANGE_FIGHT_WALL);
    else
      sam.FSMController = FSMManager.Instance.getState(EStateName.RANGE_FIGHT);
  }
}
