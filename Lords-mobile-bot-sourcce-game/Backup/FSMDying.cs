// Decompiled with JetBrains decompiler
// Type: FSMDying
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class FSMDying : FSMUnit
{
  public FSMDying(FSMManager pMgr)
  {
    this.pManager = pMgr;
    this.StateName = EStateName.DYING;
  }

  public override void Enter(Soldier sam)
  {
    sam.EnableShadow = false;
    if (sam.Parent.GroupKind == EGroupKind.Catapults)
    {
      sam.PlayAnim(ESheetMeshAnim.die, SAWrapMode.Once);
      sam.SpreadPos = sam.transform.position;
      sam.Flag = (byte) 0;
    }
    else if (sam.Flag != (byte) 0)
    {
      sam.ActionMode = EActionMode.Personal;
      float x = sam.Parent.Side != (byte) 0 ? -1f : 1f;
      if (sam.Flag == (byte) 1)
        sam.transform.rotation = Quaternion.LookRotation(new Vector3(x, 0.0f, Random.Range(-0.5f, 0.5f)));
      else
        sam.transform.rotation = Quaternion.LookRotation(new Vector3(Random.Range(-1f, 1f), 0.0f, Random.Range(-1f, 1f)));
      float num1 = Random.Range(5f, 12f);
      if (sam.Target != null)
      {
        Vector3 vector3 = sam.transform.position - sam.Target.transform.position;
        vector3.Normalize();
        sam.SpreadPos = sam.transform.TransformPoint(vector3 * num1);
      }
      else
        sam.SpreadPos = sam.transform.TransformPoint(new Vector3(0.0f, 0.0f, -num1));
      sam.LastTargetPos = sam.transform.position;
      sam.LastTargetPos.y = 0.0f;
      float num2 = sam.Flag != (byte) 1 ? 15f : 10f;
      float num3 = 1f / num2;
      sam.DyingValue = Random.Range(num2 - 5f, num2 + 5f);
      sam.fightTimer = (float) ((double) sam.DyingValue * (double) num3 * ((double) num1 * 0.11764705926179886) * 0.699999988079071);
      sam.Timer = 0.0f;
      if (sam.SoldierKind == (byte) 3 && sam.SoldierTier == (byte) 4 && sam.CurAnim == ESheetMeshAnim.attack)
      {
        float num4 = sam.CurAnimTime();
        if ((double) num4 >= 0.20000000298023224 && (double) num4 <= 0.9660000205039978)
          sam.SampleAnimation(ESheetMeshAnim.attack, 0.0f);
      }
      sam.IsPlaying = false;
    }
    else
    {
      sam.PlayAnim(ESheetMeshAnim.die, SAWrapMode.Once);
      Vector3 position = sam.transform.position;
      float x = Random.Range(position.x - 0.05f, position.x + 0.05f);
      float z = Random.Range(position.z - 0.05f, position.z + 0.05f);
      sam.SpreadPos = new Vector3(x, 0.0f, z);
      sam.DyingValue = Vector3.Distance(position, sam.SpreadPos) * sam.AnimLength;
    }
  }

  public override void Update(Soldier sam, ArmyGroup parent, float deltaTime)
  {
    if (sam.Index == (ushort) byte.MaxValue)
    {
      Transform transform = sam.transform;
      Vector3 forward = sam.SpreadPos - transform.position;
      if (forward != Vector3.zero)
        transform.rotation = Quaternion.LookRotation(forward);
      FSMUnit.MoveSoldier(sam, sam.SpreadPos, sam.DyingValue * deltaTime);
      if (sam.DieState != (byte) 1 || !(sam.SpreadPos == Vector3.zero) && (double) GameConstants.DistanceSquare(transform.position, sam.SpreadPos) > 9.9999997473787516E-05)
        return;
      sam.FSMController = FSMManager.Instance.getState(EStateName.DIE);
    }
    else if (sam.Flag != (byte) 0)
    {
      float fightTimer = sam.fightTimer;
      float inverseLength = 1f / fightTimer;
      Vector3 center = ((sam.SpreadPos + sam.LastTargetPos) * 0.5f) with
      {
        y = sam.DyingValue
      };
      sam.transform.position = GameConstants.QuadraticBezierCurves(sam.LastTargetPos, center, sam.SpreadPos, inverseLength, sam.Timer);
      sam.Timer += deltaTime;
      if ((double) sam.Timer < (double) fightTimer)
        return;
      sam.transform.position = sam.SpreadPos;
      sam.SpreadPos = Vector3.zero;
      sam.FSMController = FSMManager.Instance.getState(EStateName.DIE);
      sam.PlayAnim(ESheetMeshAnim.die, SAWrapMode.Once);
      sam.Flag = (byte) 0;
    }
    else
    {
      Transform transform = sam.transform;
      Vector3 forward = sam.SpreadPos - transform.position;
      if (forward != Vector3.zero)
      {
        transform.rotation = Quaternion.LookRotation(forward);
        FSMUnit.MoveSoldier(sam, sam.SpreadPos, sam.DyingValue * deltaTime);
      }
      if (sam.DieState != (byte) 1 || !(sam.SpreadPos == Vector3.zero) && (double) GameConstants.DistanceSquare(transform.position, sam.SpreadPos) > 9.9999997473787516E-05)
        return;
      sam.FSMController = FSMManager.Instance.getState(EStateName.DIE);
    }
  }
}
