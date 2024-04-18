// Decompiled with JetBrains decompiler
// Type: EasingEffect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class EasingEffect : MotionEffect
{
  public static float Quintic(float t, float b, float c, float d)
  {
    float num1 = (t /= d) * t;
    float num2 = num1 * t;
    return b + c * (num2 * num1);
  }

  public static float Linear(float t, float b, float c, float d)
  {
    t /= d;
    return b + c * t;
  }

  public static float Bounce(float t, float b, float c, float d)
  {
    if ((double) (t /= d) < 4.0 / 11.0)
    {
      Debug.Log((object) 1);
      return c * (121f / 16f * t * t) + b;
    }
    if ((double) t < 8.0 / 11.0)
    {
      Debug.Log((object) 2);
      return c * (float) (121.0 / 16.0 * (double) (t -= 0.545454562f) * (double) t + 0.75) + b;
    }
    if ((double) t < 10.0 / 11.0)
    {
      Debug.Log((object) 3);
      return c * (float) (121.0 / 16.0 * (double) (t -= 0.8181818f) * (double) t + 15.0 / 16.0) + b;
    }
    Debug.Log((object) 4);
    return c * (float) (121.0 / 16.0 * (double) (t -= 0.954545438f) * (double) t + 63.0 / 64.0) + b;
  }

  public static float InQuadratic(float t, float b, float c, float d)
  {
    float num1 = (t /= d) * t;
    float num2 = num1 * t;
    return b + c * (float) (4.0999999046325684 * (double) num2 * (double) num1 + -4.3000001907348633 * (double) num1 * (double) num1 + 1.2000000476837158 * (double) num2);
  }
}
