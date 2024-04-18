// Decompiled with JetBrains decompiler
// Type: uTools.EaseManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
namespace uTools
{
  public class EaseManager
  {
    private static float linear(float start, float end, float value)
    {
      return Mathf.Lerp(start, end, value);
    }

    private static float clerp(float start, float end, float value)
    {
      float num1 = 0.0f;
      float num2 = 360f;
      float num3 = Mathf.Abs((float) (((double) num2 - (double) num1) / 2.0));
      float num4;
      if ((double) end - (double) start < -(double) num3)
      {
        float num5 = (num2 - start + end) * value;
        num4 = start + num5;
      }
      else if ((double) end - (double) start > (double) num3)
      {
        float num6 = (float) -((double) num2 - (double) end + (double) start) * value;
        num4 = start + num6;
      }
      else
        num4 = start + (end - start) * value;
      return num4;
    }

    private static float spring(float start, float end, float value)
    {
      value = Mathf.Clamp01(value);
      value = (float) (((double) Mathf.Sin((float) ((double) value * 3.1415927410125732 * (0.20000000298023224 + 2.5 * (double) value * (double) value * (double) value))) * (double) Mathf.Pow(1f - value, 2.2f) + (double) value) * (1.0 + 1.2000000476837158 * (1.0 - (double) value)));
      return start + (end - start) * value;
    }

    private static float easeInQuad(float start, float end, float value)
    {
      end -= start;
      return end * value * value + start;
    }

    private static float easeOutQuad(float start, float end, float value)
    {
      end -= start;
      return (float) (-(double) end * (double) value * ((double) value - 2.0)) + start;
    }

    private static float easeInOutQuad(float start, float end, float value)
    {
      value /= 0.5f;
      end -= start;
      if ((double) value < 1.0)
        return end / 2f * value * value + start;
      --value;
      return (float) (-(double) end / 2.0 * ((double) value * ((double) value - 2.0) - 1.0)) + start;
    }

    private static float easeInCubic(float start, float end, float value)
    {
      end -= start;
      return end * value * value * value + start;
    }

    private static float easeOutCubic(float start, float end, float value)
    {
      --value;
      end -= start;
      return end * (float) ((double) value * (double) value * (double) value + 1.0) + start;
    }

    private static float easeInOutCubic(float start, float end, float value)
    {
      value /= 0.5f;
      end -= start;
      if ((double) value < 1.0)
        return end / 2f * value * value * value + start;
      value -= 2f;
      return (float) ((double) end / 2.0 * ((double) value * (double) value * (double) value + 2.0)) + start;
    }

    private static float easeInQuart(float start, float end, float value)
    {
      end -= start;
      return end * value * value * value * value + start;
    }

    private static float easeOutQuart(float start, float end, float value)
    {
      --value;
      end -= start;
      return (float) (-(double) end * ((double) value * (double) value * (double) value * (double) value - 1.0)) + start;
    }

    private static float easeInOutQuart(float start, float end, float value)
    {
      value /= 0.5f;
      end -= start;
      if ((double) value < 1.0)
        return end / 2f * value * value * value * value + start;
      value -= 2f;
      return (float) (-(double) end / 2.0 * ((double) value * (double) value * (double) value * (double) value - 2.0)) + start;
    }

    private static float easeInQuint(float start, float end, float value)
    {
      end -= start;
      return end * value * value * value * value * value + start;
    }

    private static float easeOutQuint(float start, float end, float value)
    {
      --value;
      end -= start;
      return end * (float) ((double) value * (double) value * (double) value * (double) value * (double) value + 1.0) + start;
    }

    private static float easeInOutQuint(float start, float end, float value)
    {
      value /= 0.5f;
      end -= start;
      if ((double) value < 1.0)
        return end / 2f * value * value * value * value * value + start;
      value -= 2f;
      return (float) ((double) end / 2.0 * ((double) value * (double) value * (double) value * (double) value * (double) value + 2.0)) + start;
    }

    private static float easeInSine(float start, float end, float value)
    {
      end -= start;
      return -end * Mathf.Cos((float) ((double) value / 1.0 * 1.5707963705062866)) + end + start;
    }

    private static float easeOutSine(float start, float end, float value)
    {
      end -= start;
      return end * Mathf.Sin((float) ((double) value / 1.0 * 1.5707963705062866)) + start;
    }

    private static float easeInOutSine(float start, float end, float value)
    {
      end -= start;
      return (float) (-(double) end / 2.0 * ((double) Mathf.Cos((float) (3.1415927410125732 * (double) value / 1.0)) - 1.0)) + start;
    }

    private static float easeInExpo(float start, float end, float value)
    {
      end -= start;
      return end * Mathf.Pow(2f, (float) (10.0 * ((double) value / 1.0 - 1.0))) + start;
    }

    private static float easeOutExpo(float start, float end, float value)
    {
      end -= start;
      return end * (float) (-(double) Mathf.Pow(2f, (float) (-10.0 * (double) value / 1.0)) + 1.0) + start;
    }

    private static float easeInOutExpo(float start, float end, float value)
    {
      value /= 0.5f;
      end -= start;
      if ((double) value < 1.0)
        return end / 2f * Mathf.Pow(2f, (float) (10.0 * ((double) value - 1.0))) + start;
      --value;
      return (float) ((double) end / 2.0 * (-(double) Mathf.Pow(2f, -10f * value) + 2.0)) + start;
    }

    private static float easeInCirc(float start, float end, float value)
    {
      end -= start;
      return (float) (-(double) end * ((double) Mathf.Sqrt((float) (1.0 - (double) value * (double) value)) - 1.0)) + start;
    }

    private static float easeOutCirc(float start, float end, float value)
    {
      --value;
      end -= start;
      return end * Mathf.Sqrt((float) (1.0 - (double) value * (double) value)) + start;
    }

    private static float easeInOutCirc(float start, float end, float value)
    {
      value /= 0.5f;
      end -= start;
      if ((double) value < 1.0)
        return (float) (-(double) end / 2.0 * ((double) Mathf.Sqrt((float) (1.0 - (double) value * (double) value)) - 1.0)) + start;
      value -= 2f;
      return (float) ((double) end / 2.0 * ((double) Mathf.Sqrt((float) (1.0 - (double) value * (double) value)) + 1.0)) + start;
    }

    private static float easeInBounce(float start, float end, float value)
    {
      end -= start;
      float num = 1f;
      return end - EaseManager.easeOutBounce(0.0f, end, num - value) + start;
    }

    private static float easeOutBounce(float start, float end, float value)
    {
      value /= 1f;
      end -= start;
      if ((double) value < 0.36363637447357178)
        return end * (121f / 16f * value * value) + start;
      if ((double) value < 0.72727274894714355)
      {
        value -= 0.545454562f;
        return end * (float) (121.0 / 16.0 * (double) value * (double) value + 0.75) + start;
      }
      if ((double) value < 10.0 / 11.0)
      {
        value -= 0.8181818f;
        return end * (float) (121.0 / 16.0 * (double) value * (double) value + 15.0 / 16.0) + start;
      }
      value -= 0.954545438f;
      return end * (float) (121.0 / 16.0 * (double) value * (double) value + 63.0 / 64.0) + start;
    }

    private static float easeInOutBounce(float start, float end, float value)
    {
      end -= start;
      float num = 1f;
      return (double) value < (double) num / 2.0 ? EaseManager.easeInBounce(0.0f, end, value * 2f) * 0.5f + start : (float) ((double) EaseManager.easeOutBounce(0.0f, end, value * 2f - num) * 0.5 + (double) end * 0.5) + start;
    }

    private static float easeInBack(float start, float end, float value)
    {
      end -= start;
      value /= 1f;
      float num = 1.70158f;
      return (float) ((double) end * (double) value * (double) value * (((double) num + 1.0) * (double) value - (double) num)) + start;
    }

    private static float easeOutBack(float start, float end, float value)
    {
      float num = 1.70158f;
      end -= start;
      value = (float) ((double) value / 1.0 - 1.0);
      return end * (float) ((double) value * (double) value * (((double) num + 1.0) * (double) value + (double) num) + 1.0) + start;
    }

    private static float easeInOutBack(float start, float end, float value)
    {
      float num1 = 1.70158f;
      end -= start;
      value /= 0.5f;
      if ((double) value < 1.0)
      {
        float num2 = num1 * 1.525f;
        return (float) ((double) end / 2.0 * ((double) value * (double) value * (((double) num2 + 1.0) * (double) value - (double) num2))) + start;
      }
      value -= 2f;
      float num3 = num1 * 1.525f;
      return (float) ((double) end / 2.0 * ((double) value * (double) value * (((double) num3 + 1.0) * (double) value + (double) num3) + 2.0)) + start;
    }

    private static float punch(float amplitude, float value)
    {
      if ((double) value == 0.0 || (double) value == 1.0)
        return 0.0f;
      float num1 = 0.3f;
      float num2 = num1 / 6.28318548f * Mathf.Asin(0.0f);
      return amplitude * Mathf.Pow(2f, -10f * value) * Mathf.Sin((float) (((double) value * 1.0 - (double) num2) * 6.2831854820251465) / num1);
    }

    private static float easeInElastic(float start, float end, float value)
    {
      end -= start;
      float num1 = 1f;
      float num2 = num1 * 0.3f;
      float num3 = 0.0f;
      if ((double) value == 0.0)
        return start;
      if ((double) (value /= num1) == 1.0)
        return start + end;
      float num4;
      if ((double) num3 == 0.0 || (double) num3 < (double) Mathf.Abs(end))
      {
        num3 = end;
        num4 = num2 / 4f;
      }
      else
        num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
      return (float) -((double) num3 * (double) Mathf.Pow(2f, 10f * --value) * (double) Mathf.Sin((float) (((double) value * (double) num1 - (double) num4) * 6.2831854820251465) / num2)) + start;
    }

    private static float easeOutElastic(float start, float end, float value)
    {
      end -= start;
      float num1 = 1f;
      float num2 = num1 * 0.3f;
      float num3 = 0.0f;
      if ((double) value == 0.0)
        return start;
      if ((double) (value /= num1) == 1.0)
        return start + end;
      float num4;
      if ((double) num3 == 0.0 || (double) num3 < (double) Mathf.Abs(end))
      {
        num3 = end;
        num4 = num2 / 4f;
      }
      else
        num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
      return num3 * Mathf.Pow(2f, -10f * value) * Mathf.Sin((float) (((double) value * (double) num1 - (double) num4) * 6.2831854820251465) / num2) + end + start;
    }

    private static float easeInOutElastic(float start, float end, float value)
    {
      end -= start;
      float num1 = 1f;
      float num2 = num1 * 0.3f;
      float num3 = 0.0f;
      if ((double) value == 0.0)
        return start;
      if ((double) (value /= num1 / 2f) == 2.0)
        return start + end;
      float num4;
      if ((double) num3 == 0.0 || (double) num3 < (double) Mathf.Abs(end))
      {
        num3 = end;
        num4 = num2 / 4f;
      }
      else
        num4 = num2 / 6.28318548f * Mathf.Asin(end / num3);
      return (double) value < 1.0 ? (float) (-0.5 * ((double) num3 * (double) Mathf.Pow(2f, 10f * --value) * (double) Mathf.Sin((float) (((double) value * (double) num1 - (double) num4) * 6.2831854820251465) / num2))) + start : (float) ((double) num3 * (double) Mathf.Pow(2f, -10f * --value) * (double) Mathf.Sin((float) (((double) value * (double) num1 - (double) num4) * 6.2831854820251465) / num2) * 0.5) + end + start;
    }

    public static float EasingFromType(float start, float end, float t, EaseType type)
    {
      switch (type)
      {
        case EaseType.easeInQuad:
          return EaseManager.easeInQuad(start, end, t);
        case EaseType.easeOutQuad:
          return EaseManager.easeOutQuad(start, end, t);
        case EaseType.easeInOutQuad:
          return EaseManager.easeInOutQuad(start, end, t);
        case EaseType.easeInCubic:
          return EaseManager.easeInCubic(start, end, t);
        case EaseType.easeOutCubic:
          return EaseManager.easeOutCubic(start, end, t);
        case EaseType.easeInOutCubic:
          return EaseManager.easeInOutCubic(start, end, t);
        case EaseType.easeInQuart:
          return EaseManager.easeInQuart(start, end, t);
        case EaseType.easeOutQuart:
          return EaseManager.easeOutQuart(start, end, t);
        case EaseType.easeInOutQuart:
          return EaseManager.easeInOutQuart(start, end, t);
        case EaseType.easeInQuint:
          return EaseManager.easeInQuint(start, end, t);
        case EaseType.easeOutQuint:
          return EaseManager.easeOutQuint(start, end, t);
        case EaseType.easeInOutQuint:
          return EaseManager.easeInOutQuint(start, end, t);
        case EaseType.easeInSine:
          return EaseManager.easeInSine(start, end, t);
        case EaseType.easeOutSine:
          return EaseManager.easeOutSine(start, end, t);
        case EaseType.easeInOutSine:
          return EaseManager.easeInOutSine(start, end, t);
        case EaseType.easeInExpo:
          return EaseManager.easeInExpo(start, end, t);
        case EaseType.easeOutExpo:
          return EaseManager.easeOutExpo(start, end, t);
        case EaseType.easeInOutExpo:
          return EaseManager.easeInOutExpo(start, end, t);
        case EaseType.easeInCirc:
          return EaseManager.easeInCirc(start, end, t);
        case EaseType.easeOutCirc:
          return EaseManager.easeOutCirc(start, end, t);
        case EaseType.easeInOutCirc:
          return EaseManager.easeInOutCirc(start, end, t);
        case EaseType.linear:
          return EaseManager.linear(start, end, t);
        case EaseType.spring:
          return EaseManager.spring(start, end, t);
        case EaseType.easeInBounce:
          return EaseManager.easeInBounce(start, end, t);
        case EaseType.easeOutBounce:
          return EaseManager.easeOutBounce(start, end, t);
        case EaseType.easeInOutBounce:
          return EaseManager.easeInOutBounce(start, end, t);
        case EaseType.easeInBack:
          return EaseManager.easeInBack(start, end, t);
        case EaseType.easeOutBack:
          return EaseManager.easeOutBack(start, end, t);
        case EaseType.easeInOutBack:
          return EaseManager.easeInOutBack(start, end, t);
        case EaseType.easeInElastic:
          return EaseManager.easeInElastic(start, end, t);
        case EaseType.easeOutElastic:
          return EaseManager.easeOutElastic(start, end, t);
        case EaseType.easeInOutElastic:
          return EaseManager.easeInOutElastic(start, end, t);
        default:
          return EaseManager.linear(start, end, t);
      }
    }

    public delegate float EaseDelegate(float start, float end, float t);
  }
}
