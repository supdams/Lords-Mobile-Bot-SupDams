// Decompiled with JetBrains decompiler
// Type: FSMUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMUnit
{
  public const float OFFTEAM_SPEED_RATE = 1.3f;
  public const float FAST_OFFTEAM_SPEED_RATE = 2.5f;
  public const float SPREAD_RANGE = 5f;
  public const float SPREAD_SPEED_RATE = 1.3f;
  public const float DYING_SPREAD_RANGE = 0.05f;
  public const float ROTATE_SPEED = 5f;
  public const float SQR_OF_CM = 0.0001f;
  public const float DEADBODY_HIDE_FLAG = -10f;
  public const float DEADBODY_HIDE_SPEED = 1f;
  public const float DEADBODY_HIDE_LEN = 2f;
  public const float DEADBODY_SHOWING_TIME = 20f;
  public const float ATTACK_TIMER = 1.5f;
  public const float LORD_ATTACK_TIMER = 3f;
  public const float DEFAULT_SPEED = 4.5f;
  public static readonly Vector3 JUMP_FROM_WALL_CENTER_OFFSET = new Vector3(-5f, 10f, 0.0f);
  public static readonly Vector3 JUMP_FROM_WALL_END_OFFSET = new Vector3(-10f, 0.0f, 0.0f);
  public static readonly Vector3 WALL_FRONT = new Vector3(52f, 0.0f, 15f);
  public static readonly Vector3 WALL_BACK = new Vector3(62f, 0.0f, 15f);
  public static Soldier SolRef = (Soldier) null;
  protected FSMManager pManager;
  public EStateName StateName;

  public virtual void Enter(Soldier sam)
  {
  }

  public virtual void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
  }

  public static bool CheckTargetActiving(Soldier sam)
  {
    return sam.Target != null && sam.Target.FSMController != null && sam.Target.CurFSM != EStateName.DIE && sam.Target.CurFSM != EStateName.DYING;
  }

  public static Soldier ReallocTarget(Soldier self, ArmyGroup targetAry)
  {
    if (self.Target != null)
      return self.Target;
    if (self.IsHeroSoldier && targetAry.heroSoldier != null || targetAry.bNpcMode)
      return targetAry.heroSoldier;
    int rowCount = self.Parent.RowCount;
    int num1 = (int) self.Index / rowCount;
    int num2 = rowCount * (num1 + 1) - ((int) self.Index + 1);
    int num3 = rowCount * num1 + num2;
    int index = Mathf.Max(num3 < targetAry.CurrentSoldierCount ? num3 : Random.Range(0, targetAry.CurrentSoldierCount), 0);
    Soldier soldier = targetAry.soldiers[index];
    if (soldier.CurFSM == EStateName.DIE)
      soldier = targetAry.soldiers[0];
    return soldier;
  }

  public static void MoveSoldier(Soldier sol, Vector3 end, float speed)
  {
    sol.transform.position = GameConstants.MoveTowards(sol.transform.position, end, speed);
    sol.LastMovingFrame = Time.frameCount;
  }

  public static void CheckDirectionToTarget(Soldier sol, float deltaTime)
  {
    if (sol.Target == null)
      return;
    FSMUnit.SolRef = sol.Target;
    if (sol.bNewTargetDirty || FSMUnit.SolRef.IsMoveDirty)
    {
      sol.bNewTargetDirty = false;
      sol.Direction = FSMUnit.SolRef.transform.position - sol.transform.position;
      sol.Direction.y = 0.0f;
      if ((double) Vector3.Angle(sol.Direction, sol.transform.forward) >= 0.0099999997764825821)
        sol.bRotateDirty = true;
    }
    if (!sol.bRotateDirty)
      return;
    Quaternion to = Quaternion.LookRotation(sol.Direction);
    sol.transform.rotation = Quaternion.Slerp(sol.transform.rotation, to, deltaTime * 5f);
    if ((double) Vector3.Angle(sol.Direction, sol.transform.forward) > 0.0099999997764825821)
      return;
    sol.bRotateDirty = false;
  }
}
