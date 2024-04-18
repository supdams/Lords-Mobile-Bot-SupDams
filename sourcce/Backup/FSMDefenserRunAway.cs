// Decompiled with JetBrains decompiler
// Type: FSMDefenserRunAway
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMDefenserRunAway : FSMUnit
{
  public FSMDefenserRunAway(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.DEFENSER_RUN_AWAY;
  }

  public override void Enter(Soldier sam)
  {
    Vector3 position = sam.transform.position with
    {
      x = 500f
    };
    sam.SpreadPos = position;
    sam.PlayAnim(ESheetMeshAnim.moving, bForceReset: true);
    sam.RunAnimSpeedUp();
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    Transform transform = sam.transform;
    Vector3 forward = sam.SpreadPos - transform.position;
    if (forward != Vector3.zero)
    {
      Quaternion to = Quaternion.LookRotation(forward);
      if (to != transform.rotation)
        transform.rotation = Quaternion.Slerp(transform.rotation, to, 5f * deltaTime);
    }
    float num = parent != null ? parent.MoveSpeed : 4.5f;
    FSMUnit.MoveSoldier(sam, sam.SpreadPos, (float) ((double) num * 2.5 * (double) deltaTime * 1.5));
  }
}
