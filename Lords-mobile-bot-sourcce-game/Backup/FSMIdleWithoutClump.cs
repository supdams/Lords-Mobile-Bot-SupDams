// Decompiled with JetBrains decompiler
// Type: FSMIdleWithoutClump
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class FSMIdleWithoutClump : FSMUnit
{
  public FSMIdleWithoutClump(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.IDLE_WITHOUT_CLUMP;
  }

  public override void Enter(Soldier sam)
  {
    if (sam.Index == (ushort) byte.MaxValue)
      sam.PlayAnim(ESheetMeshAnim.idle);
    else
      sam.playMode = SAWrapMode.Default;
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
  }
}
