// Decompiled with JetBrains decompiler
// Type: FSMLordDie
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMLordDie : FSMUnit
{
  public FSMLordDie(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.DIE;
  }

  public override void Enter(Soldier sam) => sam.DyingValue = 0.0f;

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if ((double) sam.DyingValue > -0.10000000149011612)
      sam.DyingValue += deltaTime;
    if ((double) sam.DyingValue >= 20.0)
    {
      sam.DyingValue = -10f;
    }
    else
    {
      if ((double) sam.DyingValue >= 0.0)
        return;
      Transform transform = sam.transform;
      Vector3 position = transform.position;
      position.y -= 1f * deltaTime;
      transform.position = position;
      if ((double) position.y > -2.0)
        return;
      parent.heroSoldier.gameObject.SetActive(false);
    }
  }
}
