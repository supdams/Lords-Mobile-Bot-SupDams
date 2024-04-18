// Decompiled with JetBrains decompiler
// Type: FSMKickBack
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMKickBack : FSMUnit
{
  public FSMKickBack(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.KICKBACK;
  }

  public override void Enter(Soldier sam)
  {
    sam.LastTargetPos = sam.transform.position;
    sam.Timer = 0.0f;
    sam.Flag = (byte) 1;
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    Vector3 center = ((sam.LastTargetPos + sam.SpreadPos) * 0.5f) with
    {
      y = 10f
    };
    sam.transform.position = GameConstants.QuadraticBezierCurves(sam.LastTargetPos, center, sam.SpreadPos, 2f, sam.Timer);
    sam.Timer += deltaTime;
    if ((double) sam.Timer < 0.5)
      return;
    sam.Flag = (byte) 0;
    EStateName fsm = ArmyGroup.m_FSMMap[sam.Parent.State];
    sam.FSMController = FSMManager.Instance.getState(fsm);
  }
}
