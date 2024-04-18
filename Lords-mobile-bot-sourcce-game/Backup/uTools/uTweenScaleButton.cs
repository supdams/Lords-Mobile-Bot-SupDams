// Decompiled with JetBrains decompiler
// Type: uTools.uTweenScaleButton
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
namespace uTools
{
  [AddComponentMenu("uTools/Tween/Tween Scale(uTools)")]
  public class uTweenScaleButton : uTweener
  {
    public IUIButtonScaleHandler m_Handler;
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
      if (!isFinished || this.m_Handler == null)
        return;
      this.m_Handler.OnFinish();
    }

    public static uTweenScaleButton Begin(
      GameObject go,
      Vector3 from,
      Vector3 to,
      float duration = 1f,
      float delay = 0.0f)
    {
      uTweenScaleButton tweenScaleButton = uTweener.Begin<uTweenScaleButton>(go, duration);
      tweenScaleButton.from = from;
      tweenScaleButton.to = to;
      tweenScaleButton.duration = duration;
      tweenScaleButton.delay = delay;
      if ((double) duration <= 0.0)
      {
        tweenScaleButton.Sample(1f, true);
        tweenScaleButton.enabled = false;
      }
      return tweenScaleButton;
    }
  }
}
