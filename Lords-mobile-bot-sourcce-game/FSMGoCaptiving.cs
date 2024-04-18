// Decompiled with JetBrains decompiler
// Type: FSMGoCaptiving
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMGoCaptiving : FSMUnit
{
  public FSMGoCaptiving(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.GO_CAPTIVING;
  }

  public override void Enter(Soldier sam)
  {
    if (sam.Parent.SoldierTarget != null)
    {
      Vector3 position = sam.Parent.SoldierTarget.transform.position;
      Vector3 zero = Vector3.zero;
      Vector3 vector3_1;
      do
      {
        Vector3 vector3_2 = Quaternion.AngleAxis((float) Random.Range(0, 360), Vector3.up) * Vector3.forward;
        float num = sam.SoldierKind != (byte) 3 ? Random.Range(6f, 9f) : 10f;
        vector3_1 = position + vector3_2 * num;
      }
      while (FSMManager.Instance.bIsSiegeMode && (double) vector3_1.x >= 50.0);
      sam.CaptivePos = vector3_1;
      sam.CaptiveFlag = (byte) 1;
      sam.PlayAnim(ESheetMeshAnim.moving);
    }
    else
    {
      sam.FSMController = FSMManager.Instance.getState(EStateName.IDLE);
      --FSMManager.Instance.CaptivingCount;
    }
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if (sam.CaptiveFlag == (byte) 0)
      return;
    if (sam.CaptiveFlag == (byte) 1)
    {
      Transform transform = sam.transform;
      Vector3 forward = sam.CaptivePos - transform.position;
      if (forward != Vector3.zero)
      {
        Quaternion to = Quaternion.LookRotation(forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, to, 5f * deltaTime);
      }
      FSMUnit.MoveSoldier(sam, sam.CaptivePos, parent.MoveSpeed * 2.5f * deltaTime);
      if ((double) GameConstants.DistanceSquare(transform.position, sam.CaptivePos) > 9.9999997473787516E-05)
        return;
      sam.CaptiveFlag = (byte) 2;
      sam.PlayAnim(ESheetMeshAnim.victory);
      ++FSMManager.Instance.CaptivingCount;
      sam.CaptivePos = sam.Parent.SoldierTarget.transform.position - transform.position;
    }
    else
    {
      if (sam.CaptiveFlag != (byte) 2)
        return;
      Transform transform = sam.transform;
      if (!(sam.CaptivePos != Vector3.zero))
        return;
      Quaternion to = Quaternion.LookRotation(sam.CaptivePos);
      if (to != transform.rotation)
        transform.rotation = Quaternion.Slerp(transform.rotation, to, 5f * deltaTime);
      else
        sam.CaptiveFlag = (byte) 0;
    }
  }
}
