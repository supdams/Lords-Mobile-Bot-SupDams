// Decompiled with JetBrains decompiler
// Type: SpriteColorLerpLoop
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class SpriteColorLerpLoop : MotionEffect
{
  public Color a = Color.black;
  public Color b = Color.white;
  private SpriteRenderer Render;
  private float Halftime = 1.5f;
  private float Curtime;
  private bool Reverse;

  public void SetSpriteRender(SpriteRenderer render)
  {
    this.Render = render;
    if ((Object) this.Render == (Object) null)
    {
      this.bMove = false;
    }
    else
    {
      this.bMove = true;
      int num = (int) MotionEffect.SetStack((MotionEffect) this);
    }
  }

  public override bool UpdateRun(float delta)
  {
    if (!this.Reverse && (double) this.Curtime < (double) this.Halftime)
    {
      this.Render.color = Color.Lerp(this.a, this.b, this.Curtime / this.Halftime);
    }
    else
    {
      this.Reverse = true;
      this.Render.color = Color.Lerp(this.a, this.b, (float) (1.0 - ((double) this.Curtime - (double) this.Halftime) / (double) this.Halftime));
    }
    this.Curtime += delta;
    if ((double) this.Curtime >= (double) this.Halftime * 2.0)
    {
      this.Reverse = false;
      this.Curtime = 0.0f;
    }
    return true;
  }
}
