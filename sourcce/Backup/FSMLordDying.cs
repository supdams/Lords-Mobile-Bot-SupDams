// Decompiled with JetBrains decompiler
// Type: FSMLordDying
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class FSMLordDying : FSMUnit
{
  public FSMLordDying(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.LORD_DYING;
  }

  public override void Enter(Soldier sam)
  {
    sam.PlayAnim(ESheetMeshAnim.die, SAWrapMode.Once);
    sam.EnableShadow = false;
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if (sam.IsLord || !(sam is Lord lord) || lord.getAnimComponent().IsPlaying("die"))
      return;
    sam.FSMController = FSMManager.Instance.getState(EStateName.LORD_DIE);
  }
}
