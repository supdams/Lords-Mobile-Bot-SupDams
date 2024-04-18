// Decompiled with JetBrains decompiler
// Type: MotionEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class MotionEffect : IMotionUpdate
{
  public static MotionEffect[] SpriteStack = new MotionEffect[4];
  public static byte Index = 0;
  public IMotionUpdate Motion;
  public bool bMove;

  public static byte SetStack(MotionEffect e)
  {
    MotionEffect.SpriteStack[(int) MotionEffect.Index] = e;
    byte index = MotionEffect.Index;
    ++MotionEffect.Index;
    if ((int) MotionEffect.Index >= MotionEffect.SpriteStack.Length)
      MotionEffect.Index = (byte) 0;
    return index;
  }

  public static void RemoveStack(byte Index)
  {
    MotionEffect.SpriteStack[(int) Index] = (MotionEffect) null;
  }

  public static void Update()
  {
    for (int index = 0; index < MotionEffect.SpriteStack.Length; ++index)
    {
      if (MotionEffect.SpriteStack[index] != null && !MotionEffect.SpriteStack[index].Motion.UpdateRun(Time.deltaTime))
        MotionEffect.SpriteStack[index] = (MotionEffect) null;
    }
  }

  public virtual bool UpdateRun(float delta) => true;
}
