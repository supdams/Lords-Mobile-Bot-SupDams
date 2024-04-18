// Decompiled with JetBrains decompiler
// Type: FSMMeleeFight_Wall
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMMeleeFight_Wall : FSMUnit
{
  public FSMMeleeFight_Wall(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.MELEE_FIGHT_WALL;
  }

  public override void Enter(Soldier sam)
  {
    sam.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Default);
    sam.fightTimer = 1.5f;
    Vector3 forward = new Vector3(52f, 0.0f, sam.transform.position.z) - sam.transform.position;
    if (!(forward != Vector3.zero))
      return;
    sam.transform.rotation = Quaternion.LookRotation(forward);
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if ((double) sam.fightTimer > 0.0)
    {
      sam.fightTimer -= deltaTime;
      if ((double) sam.fightTimer <= 0.0)
      {
        sam.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Default);
        sam.fightTimer = 1.5f;
      }
    }
    if (sam.CurAnim != ESheetMeshAnim.attack || (double) sam.LastAnimTime() >= 0.10000000149011612 || (double) sam.CurAnimTime() < 0.10000000149011612)
      return;
    Vector3 position = new Vector3(51f, 2f, sam.transform.position.z);
    parent.particleManager.Spawn((ushort) 2001, (Transform) null, position, 1f, true, false);
  }
}
