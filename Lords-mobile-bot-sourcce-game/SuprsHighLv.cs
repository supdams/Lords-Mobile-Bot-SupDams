// Decompiled with JetBrains decompiler
// Type: SuprsHighLv
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class SuprsHighLv : TrapBehavior
{
  public SuprsHighLv(Vector3[] defaultPos)
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
      {
        Vector3 localPosition = suprs[index].localPosition with
        {
          y = -5f
        };
        suprs[index].localPosition = localPosition;
      }
      this.targetPosCache.Clear();
      this.trapState = (byte) 2;
    }
    else if (this.trapState == (byte) 2)
    {
      float num = suprs[0].localPosition.y + 25f * deltaTime;
      bool flag = false;
      if ((double) num >= 0.0)
      {
        flag = true;
        num = 0.0f;
        this.trapState = (byte) 3;
      }
      for (int index = 0; index < suprs.Length; ++index)
      {
        Vector3 localPosition = suprs[index].localPosition with
        {
          y = num
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
      float num = suprs[0].localPosition.y - 10f * deltaTime;
      if ((double) num <= -1.0)
      {
        num = -1f;
        this.trapState = (byte) 4;
        this.timer = 0.0f;
      }
      for (int index = 0; index < suprs.Length; ++index)
      {
        Vector3 localPosition = suprs[index].localPosition with
        {
          y = num
        };
        suprs[index].localPosition = localPosition;
      }
    }
    else if (this.trapState == (byte) 4)
    {
      this.timer += deltaTime;
      if ((double) this.timer < 0.5)
        return;
      this.trapState = (byte) 5;
    }
    else if (this.trapState == (byte) 5)
    {
      float num = suprs[0].localPosition.y + 5f * deltaTime;
      if ((double) num >= 0.0)
      {
        num = 0.0f;
        this.trapState = (byte) 6;
      }
      for (int index = 0; index < suprs.Length; ++index)
      {
        Vector3 localPosition = suprs[index].localPosition with
        {
          y = num
        };
        suprs[index].localPosition = localPosition;
      }
    }
    else
    {
      if (this.trapState != (byte) 6)
        return;
      float num = suprs[0].localPosition.y - 25f * deltaTime;
      if ((double) num <= -5.0)
      {
        num = -5f;
        this.trapState = (byte) 0;
      }
      for (int index = 0; index < suprs.Length; ++index)
      {
        Vector3 localPosition = suprs[index].localPosition with
        {
          y = num
        };
        suprs[index].localPosition = localPosition;
      }
    }
  }
}
