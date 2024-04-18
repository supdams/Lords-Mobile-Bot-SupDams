// Decompiled with JetBrains decompiler
// Type: FSMAttackerChasing
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMAttackerChasing : FSMUnit
{
  public FSMAttackerChasing(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.ATTACKER_CHASING;
  }

  public override void Enter(Soldier sam)
  {
    float x = Random.Range(75f, 95f);
    if ((double) sam.transform.position.x >= (double) x)
    {
      sam.Flag = (byte) 1;
      sam.PlayAnim(ESheetMeshAnim.victory);
    }
    else
    {
      float z = Random.Range(5f, 25f);
      sam.SpreadPos = new Vector3(x, 0.0f, z);
      sam.Flag = (byte) 0;
      sam.PlayAnim(ESheetMeshAnim.moving, bForceReset: true);
    }
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if (sam.Flag == (byte) 1)
      return;
    if (sam.Flag == (byte) 2)
    {
      Transform transform = sam.transform;
      Vector3 forward = (Camera.main.transform.position - transform.position) with
      {
        y = 0.0f
      };
      if (!(forward != Vector3.zero))
        return;
      Quaternion to = Quaternion.LookRotation(forward);
      if (to != transform.rotation)
        transform.rotation = Quaternion.Slerp(transform.rotation, to, 5f * deltaTime);
      else
        sam.Flag = (byte) 1;
    }
    else
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
      if ((double) GameConstants.DistanceSquare(transform.position, sam.SpreadPos) > 9.9999997473787516E-05)
        return;
      sam.Flag = (byte) 2;
      sam.PlayAnim(ESheetMeshAnim.victory);
    }
  }
}
