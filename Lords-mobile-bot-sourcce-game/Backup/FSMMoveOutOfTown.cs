// Decompiled with JetBrains decompiler
// Type: FSMMoveOutOfTown
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMMoveOutOfTown : FSMUnit
{
  public FSMMoveOutOfTown(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.MOVE_OUTOF_TOWN;
  }

  public override void Enter(Soldier sam)
  {
    sam.PlayAnim(ESheetMeshAnim.moving);
    sam.ActionMode = EActionMode.Personal;
    sam.Flag = (byte) 0;
    sam.Timer = Random.Range(0.0f, 0.5f);
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if (sam.Flag == (byte) 0)
    {
      sam.Timer -= deltaTime;
      if ((double) sam.Timer > 0.0)
        return;
      sam.Flag = (byte) 1;
      sam.PlayAnim(ESheetMeshAnim.moving, bRandomStartPoint: false);
    }
    Vector3 zero = Vector3.zero;
    Transform transform = sam.transform;
    Vector3 vector3;
    if (sam.Flag == (byte) 1)
      vector3 = FSMUnit.WALL_BACK;
    else if (sam.Flag == (byte) 2)
    {
      vector3 = FSMUnit.WALL_FRONT;
    }
    else
    {
      sam.Flag = (byte) 0;
      if (FSMManager.Instance.bIsBattleOver && DataManager.Instance.War_LordCapture != (byte) 0)
      {
        sam.FSMController = FSMManager.Instance.getState(EStateName.GO_CAPTIVING);
        return;
      }
      sam.FSMController = FSMManager.Instance.getState(EStateName.IDLE_FASTRUN);
      return;
    }
    Vector3 forward = vector3 - transform.position;
    if (forward != Vector3.zero)
    {
      Quaternion to = Quaternion.LookRotation(forward);
      if (transform.rotation != to)
        transform.rotation = Quaternion.Slerp(transform.rotation, to, 5f * deltaTime);
    }
    FSMUnit.MoveSoldier(sam, vector3, (float) ((double) parent.MoveSpeed * (double) deltaTime * 2.5));
    if ((double) GameConstants.DistanceSquare(transform.position, vector3) > 9.9999997473787516E-05)
      return;
    ++sam.Flag;
  }
}
