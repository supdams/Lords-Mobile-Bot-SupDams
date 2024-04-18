// Decompiled with JetBrains decompiler
// Type: uTools.uTweenScale
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
namespace uTools
{
  [AddComponentMenu("uTools/Tween/Tween Scale(uTools)")]
  public class uTweenScale : uTweener
  {
    public Vector3 from = Vector3.zero;
    public Vector3 to = Vector3.one;
    private RectTransform mRectTransform;

    public RectTransform cachedRectTransform
    {
      get
      {
        if ((Object) this.mRectTransform == (Object) null)
          this.mRectTransform = this.GetComponent<RectTransform>();
        return this.mRectTransform;
      }
    }

    public Vector3 value
    {
      get => ((Transform) this.cachedRectTransform).localScale;
      set => ((Transform) this.cachedRectTransform).localScale = value;
    }

    protected override void OnUpdate(float factor, bool isFinished)
    {
      this.value = this.from + factor * (this.to - this.from);
    }

    public static uTweenScale Begin(
      GameObject go,
      Vector3 from,
      Vector3 to,
      float duration = 1f,
      float delay = 0.0f)
    {
      uTweenScale uTweenScale = uTweener.Begin<uTweenScale>(go, duration);
      uTweenScale.from = from;
      uTweenScale.to = to;
      uTweenScale.duration = duration;
      uTweenScale.delay = delay;
      if ((double) duration <= 0.0)
      {
        uTweenScale.Sample(1f, true);
        uTweenScale.enabled = false;
      }
      return uTweenScale;
    }

    [ContextMenu("Set 'From' to current value")]
    public override void SetStartToCurrentValue() => this.from = this.value;

    [ContextMenu("Set 'To' to current value")]
    public override void SetEndToCurrentValue() => this.to = this.value;

    [ContextMenu("Assume value of 'From'")]
    public override void SetCurrentValueToStart() => this.value = this.from;

    [ContextMenu("Assume value of 'To'")]
    public override void SetCurrentValueToEnd() => this.value = this.to;
  }
}
