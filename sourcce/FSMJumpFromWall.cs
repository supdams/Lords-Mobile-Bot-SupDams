// Decompiled with JetBrains decompiler
// Type: FSMJumpFromWall
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMJumpFromWall : FSMUnit
{
  public FSMJumpFromWall(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.JUMP_FROM_WALL;
  }

  public override void Enter(Soldier sam)
  {
    sam.ActionMode = EActionMode.Personal;
    sam.SpreadPos = sam.transform.position;
    sam.LastTargetPos = sam.transform.position + FSMUnit.JUMP_FROM_WALL_END_OFFSET;
    sam.LastTargetPos.y = 0.0f;
    sam.Flag = (byte) 1;
    sam.Timer = Random.Range(0.0f, 0.5f);
    sam.EnableShadow = false;
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if (sam.Flag != (byte) 0)
    {
      sam.Timer -= deltaTime;
      if ((double) sam.Timer > 0.0)
        return;
      sam.Flag = (byte) 0;
      sam.Timer = 0.0f;
      sam.SampleAnimation(ESheetMeshAnim.victory, 0.36f);
    }
    Vector3 center = sam.SpreadPos + FSMUnit.JUMP_FROM_WALL_CENTER_OFFSET;
    sam.transform.position = GameConstants.QuadraticBezierCurves(sam.SpreadPos, center, sam.LastTargetPos, 1.25f, sam.Timer);
    sam.Timer += deltaTime;
    if ((double) sam.Timer < 0.800000011920929)
      return;
    sam.EnableShadow = true;
    sam.SpreadPos = Vector3.zero;
    if (FSMManager.Instance.bIsBattleOver && DataManager.Instance.War_LordCapture != (byte) 0)
      sam.FSMController = FSMManager.Instance.getState(EStateName.GO_CAPTIVING);
    else
      sam.FSMController = FSMManager.Instance.getState(EStateName.IDLE_FASTRUN);
  }
}
