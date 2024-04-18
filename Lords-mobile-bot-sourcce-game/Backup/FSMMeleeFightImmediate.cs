// Decompiled with JetBrains decompiler
// Type: FSMMeleeFightImmediate
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class FSMMeleeFightImmediate : FSMUnit
{
  public FSMMeleeFightImmediate(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.MELEE_FIGHT_IMMEDIATE;
  }

  public override void Enter(Soldier sam)
  {
    sam.PlayAnim(ESheetMeshAnim.attack, SAWrapMode.Default, false, true);
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
  }
}
