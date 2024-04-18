// Decompiled with JetBrains decompiler
// Type: FSMTryFight
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMTryFight : FSMUnit
{
  public FSMTryFight(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.TRYFIGHT;
  }

  public override void Enter(Soldier sam)
  {
    if (sam.Parent.Target.GroupKind == EGroupKind.CastleGate)
    {
      if (sam.Parent.GroupKind == EGroupKind.Infantry || sam.Parent.GroupKind == EGroupKind.Cavalry)
      {
        sam.SpreadMode = ESpreadMode.NotSpread;
        sam.FSMController = FSMManager.Instance.getState(EStateName.SPREAD);
      }
      else
      {
        if (sam.Parent.GroupKind == EGroupKind.Archer && sam.SpreadMode == ESpreadMode.Enable)
        {
          Vector3 position = sam.transform.position;
          float x = Random.Range(position.x - 5f, position.x + 5f);
          float z = Random.Range(position.z - 5f, position.z + 5f);
          sam.SpreadPos = new Vector3(x, 0.0f, z);
        }
        sam.FSMController = FSMManager.Instance.getState(EStateName.RANGE_FIGHT_WALL);
      }
    }
    else
    {
      if (sam.Target != null && sam.Target.Parent != sam.Parent.Target)
        sam.Target = (Soldier) null;
      if (sam.Target == null)
        sam.Target = FSMUnit.ReallocTarget(sam, sam.Parent.Target);
      if (sam.Parent.GroupKind == EGroupKind.Infantry || sam.Parent.GroupKind == EGroupKind.Cavalry)
      {
        if ((int) sam.Index / sam.Parent.RowCount != 0 && sam.SpreadMode == ESpreadMode.Enable)
        {
          sam.SpreadMode = ESpreadMode.NotSpread;
          sam.FSMController = FSMManager.Instance.getState(EStateName.SPREAD);
        }
        else
        {
          sam.ActionMode = EActionMode.Personal;
          sam.PlayAnim(ESheetMeshAnim.moving);
        }
      }
      else
      {
        if (sam.Parent.GroupKind == EGroupKind.Archer && !this.pManager.bIsSiegeMode && sam.SpreadMode == ESpreadMode.Enable)
        {
          Vector3 position = sam.transform.position;
          float x = Random.Range(position.x - 5f, position.x + 5f);
          float z = Random.Range(position.z - 5f, position.z + 5f);
          sam.SpreadPos = new Vector3(x, 0.0f, z);
        }
        sam.FSMController = FSMManager.Instance.getState(EStateName.RANGE_FIGHT);
      }
    }
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if (sam.Target == null || sam.Target.FSMController == null || sam.Target.CurFSM == EStateName.DIE || sam.Target.CurFSM == EStateName.DYING)
      sam.FSMController = FSMManager.Instance.getState(EStateName.LOSETARGET);
    Transform transform1 = sam.Target.transform;
    Transform transform2 = sam.transform;
    FSMUnit.CheckDirectionToTarget(sam, deltaTime);
    FSMUnit.MoveSoldier(sam, transform1.position, parent.MoveSpeed * 1.3f * deltaTime);
    float num = sam.AttackRadius + sam.Target.Radius;
    if ((double) GameConstants.DistanceSquare(transform2.position, transform1.position) >= (double) num * (double) num)
      return;
    sam.FSMController = FSMManager.Instance.getState(EStateName.MELEE_FIGHT);
  }
}
