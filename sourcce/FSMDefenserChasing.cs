// Decompiled with JetBrains decompiler
// Type: FSMDefenserChasing
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMDefenserChasing : FSMUnit
{
  public FSMDefenserChasing(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.DEFENSER_CHASING;
  }

  public override void Enter(Soldier sam)
  {
    Vector3 position = sam.transform.position with
    {
      x = -500f
    };
    sam.SpreadPos = position;
    sam.Timer = 2f;
    sam.Flag = (byte) 0;
    sam.PlayAnim(ESheetMeshAnim.idle);
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if (sam.Flag != (byte) 0)
      return;
    sam.Timer -= deltaTime;
    if ((double) sam.Timer > 0.0)
      return;
    sam.PlayAnim(ESheetMeshAnim.victory);
    sam.Flag = (byte) 1;
  }
}
