// Decompiled with JetBrains decompiler
// Type: FSMMoving
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMMoving : FSMUnit
{
  public FSMMoving(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.MOVING;
  }

  public override void Enter(Soldier sam)
  {
    sam.Timer = Random.Range(0.0f, 0.5f);
    sam.Flag = (byte) 1;
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if (sam.Flag != (byte) 0)
    {
      sam.Timer -= deltaTime;
      if ((double) sam.Timer > 0.0)
        return;
      sam.Flag = (byte) 0;
      sam.PlayAnim(ESheetMeshAnim.moving, bRandomStartPoint: false);
    }
    Vector3 transformPoint = parent.getTransformPoint((int) sam.Index);
    Transform transform = sam.transform;
    if (sam.ActionMode == EActionMode.Team)
    {
      transform.position = transformPoint;
      if (!(transform.rotation != parent.m_Direction))
        return;
      transform.rotation = Quaternion.Slerp(transform.rotation, parent.m_Direction, 5f * deltaTime);
    }
    else
    {
      Vector3 forward = transformPoint - transform.position;
      if (forward != Vector3.zero)
      {
        Quaternion to = Quaternion.LookRotation(forward);
        if (transform.rotation != to)
          transform.rotation = Quaternion.Slerp(transform.rotation, to, 5f * deltaTime);
      }
      FSMUnit.MoveSoldier(sam, transformPoint, parent.MoveSpeed * deltaTime);
      if ((double) GameConstants.DistanceSquare(transform.position, transformPoint) > 9.9999997473787516E-05)
        return;
      sam.ActionMode = EActionMode.Team;
    }
  }
}
