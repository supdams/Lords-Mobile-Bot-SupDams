// Decompiled with JetBrains decompiler
// Type: uTools.uTweenSlider
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace uTools
{
  [AddComponentMenu("uTools/Tween/Tween Slider(uTools)")]
  public class uTweenSlider : uTweenValue
  {
    private Slider mSlider;
    public bool NeedCarry;

    public Slider cacheSlider
    {
      get
      {
        this.mSlider = this.GetComponent<Slider>();
        if ((Object) this.mSlider == (Object) null)
          Debug.LogError((object) "'uTweenSlider' can't find 'Slider'");
        return this.mSlider;
      }
    }

    public float sliderValue
    {
      set
      {
        if (this.NeedCarry)
          this.cacheSlider.value = (double) value < 1.0 ? value : value - Mathf.Floor(value);
        else
          this.cacheSlider.value = (double) value <= 1.0 ? value : value - Mathf.Floor(value);
      }
    }

    protected override void ValueUpdate(float value, bool isFinished) => this.sliderValue = value;

    public static uTweenSlider Begin(
      Slider slider,
      float duration,
      float delay,
      float from,
      float to)
    {
      uTweenSlider uTweenSlider = uTweener.Begin<uTweenSlider>(((Component) slider).gameObject, duration);
      uTweenSlider.from = from;
      uTweenSlider.to = to;
      uTweenSlider.delay = delay;
      if ((double) duration <= 0.0)
      {
        uTweenSlider.Sample(1f, true);
        uTweenSlider.enabled = false;
      }
      return uTweenSlider;
    }
  }
}
