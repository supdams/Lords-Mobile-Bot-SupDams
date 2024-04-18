// Decompiled with JetBrains decompiler
// Type: TrapBehavior
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class TrapBehavior
{
  protected byte trapState;
  protected float timer;
  protected Vector3[] oriPos;
  public WarParticleManager particleManager;
  public List<Vector3> targetPosCache = new List<Vector3>(10);
  public ushort hitParticleID;

  protected TrapBehavior()
  {
  }

  public virtual void setState(ETrapState state) => this.trapState = (byte) state;

  public void checkHitParticle(ref Vector3 trapPos)
  {
    bool flag = false;
    for (int index = 0; index < this.targetPosCache.Count; ++index)
    {
      if ((double) GameConstants.DistanceSquare(trapPos, this.targetPosCache[index]) <= 10.0)
      {
        flag = true;
        break;
      }
    }
    if (!flag || this.particleManager == null)
      return;
    this.particleManager.Spawn(this.hitParticleID, (Transform) null, trapPos, 1f, true, false);
  }

  public virtual void Update(Transform[] traps, float deltaTime)
  {
  }
}
