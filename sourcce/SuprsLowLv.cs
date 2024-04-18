// Decompiled with JetBrains decompiler
// Type: SuprsLowLv
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class SuprsLowLv : TrapBehavior
{
  private float posOffset;
  private Vector3[] posTemp = new Vector3[5];

  public SuprsLowLv(Vector3[] defaultPos)
  {
    this.oriPos = defaultPos;
    this.hitParticleID = (ushort) 2013;
  }

  public override void Update(Transform[] suprs, float deltaTime)
  {
    if (this.trapState == (byte) 0)
      return;
    if (this.trapState == (byte) 1)
    {
      for (int index = 0; index < suprs.Length; ++index)
        suprs[index].localPosition = this.oriPos[index];
      this.targetPosCache.Clear();
      this.posOffset = 0.0f;
      this.trapState = (byte) 2;
    }
    else if (this.trapState == (byte) 2)
    {
      this.posOffset += 6.6f * deltaTime;
      bool flag = false;
      if ((double) this.posOffset >= 1.0)
      {
        flag = true;
        this.posOffset = 1f;
        this.trapState = (byte) 3;
        this.timer = 0.0f;
      }
      for (int index = 0; index < suprs.Length; ++index)
      {
        Vector3 localPosition = suprs[index].localPosition with
        {
          y = this.oriPos[index].y + 6f * this.posOffset,
          x = this.oriPos[index].x - 6f * this.posOffset
        };
        suprs[index].localPosition = localPosition;
        if (flag)
        {
          Vector3 position = suprs[index].position;
          this.checkHitParticle(ref position);
        }
      }
    }
    else if (this.trapState == (byte) 3)
    {
      this.timer += deltaTime;
      if ((double) this.timer < 0.5)
        return;
      for (int index = 0; index < suprs.Length; ++index)
        this.posTemp[index] = suprs[index].localPosition;
      this.trapState = (byte) 4;
      this.posOffset = 0.0f;
    }
    else
    {
      if (this.trapState != (byte) 4)
        return;
      this.posOffset += 1f * deltaTime;
      if ((double) this.posOffset >= 1.0)
      {
        this.posOffset = 1f;
        this.trapState = (byte) 0;
      }
      for (int index = 0; index < suprs.Length; ++index)
      {
        Vector3 localPosition = suprs[index].localPosition with
        {
          y = this.posTemp[index].y - 6f * this.posOffset,
          x = this.posTemp[index].x + 6f * this.posOffset
        };
        suprs[index].localPosition = localPosition;
      }
    }
  }
}
