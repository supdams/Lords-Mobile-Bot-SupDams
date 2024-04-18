// Decompiled with JetBrains decompiler
// Type: FSMVictory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMVictory : FSMUnit
{
  public FSMVictory(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.VICTORY;
  }

  public override void Enter(Soldier sam)
  {
    sam.PlayAnim(ESheetMeshAnim.victory);
    Vector3 position = Camera.main.transform.position;
    sam.SpreadPos = new Vector3(position.x, 0.0f, position.z) - sam.transform.position;
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if (!(sam.SpreadPos != Vector3.zero))
      return;
    Transform transform = sam.transform;
    Quaternion to = Quaternion.LookRotation(sam.SpreadPos);
    if (!(transform.rotation != to))
      return;
    transform.rotation = Quaternion.Slerp(transform.rotation, to, 5f * deltaTime);
  }
}
