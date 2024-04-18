// Decompiled with JetBrains decompiler
// Type: FSMRangeFight_Wall
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMRangeFight_Wall : FSMUnit
{
  public FSMRangeFight_Wall(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.RANGE_FIGHT_WALL;
  }

  public override void Enter(Soldier sam)
  {
    sam.PlayAnim(ESheetMeshAnim.idle);
    Vector3 forward = new Vector3(52f, 0.0f, sam.transform.position.z) - sam.transform.position;
    if (!(forward != Vector3.zero))
      return;
    sam.transform.rotation = Quaternion.LookRotation(forward);
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if (((int) parent.OnceFlag & 1) == 0)
      return;
    sam.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Default, false);
  }
}
