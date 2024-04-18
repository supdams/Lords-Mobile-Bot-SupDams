// Decompiled with JetBrains decompiler
// Type: FSMOutsideHeroDisplay
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMOutsideHeroDisplay : FSMUnit
{
  public FSMOutsideHeroDisplay(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.OUTSIDE_HERO_DISPLAY;
  }

  public override void Enter(Soldier sam)
  {
    sam.PlayAnim(ESheetMeshAnim.idle);
    sam.Timer = (float) Random.Range(2, 6);
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if ((double) sam.Timer > 0.0)
    {
      sam.Timer -= deltaTime;
      if ((double) sam.Timer > 0.0)
        return;
      sam.PlayAnim(ESheetMeshAnim.victory, SAWrapMode.Default);
    }
    else
    {
      Animation animComponent = sam.getAnimComponent();
      if (!((Object) animComponent != (Object) null) || (double) animComponent["victory"].time > 0.0)
        return;
      sam.Timer = (float) Random.Range(2, 6);
    }
  }
}
