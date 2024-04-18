// Decompiled with JetBrains decompiler
// Type: FSMLoseTarget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMLoseTarget : FSMUnit
{
  public FSMLoseTarget(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.LOSETARGET;
  }

  public override void Enter(Soldier sam)
  {
    if (sam.Target != null && sam.Target.Parent.CurrentSoldierCount <= 0)
    {
      sam.FSMController = FSMManager.Instance.getState(EStateName.IDLE);
    }
    else
    {
      switch (sam.Parent.State)
      {
        case ArmyGroup.EGROUPSTATE.MOVING:
          sam.FSMController = FSMManager.Instance.getState(EStateName.MOVING);
          break;
        case ArmyGroup.EGROUPSTATE.IDLE:
          sam.FSMController = FSMManager.Instance.getState(EStateName.IDLE);
          break;
        case ArmyGroup.EGROUPSTATE.FIGHT:
        case ArmyGroup.EGROUPSTATE.FIGHT_IMMEDIATE:
          sam.FSMController = FSMManager.Instance.getState(EStateName.TRYFIGHT);
          break;
        default:
          Debug.LogError((object) "Lose Target Bug");
          break;
      }
    }
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
  }
}
