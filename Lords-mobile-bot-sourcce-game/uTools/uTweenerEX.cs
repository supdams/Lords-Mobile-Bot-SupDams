// Decompiled with JetBrains decompiler
// Type: uTools.uTweenerEX
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.Events;

#nullable disable
namespace uTools
{
  public abstract class uTweenerEX : MonoBehaviour
  {
    public AnimationCurve animationCurve1 = new AnimationCurve(new Keyframe[2]
    {
      new Keyframe(0.0f, 0.0f, 0.0f, 1f),
      new Keyframe(1f, 1f, 1f, 0.0f)
    });
    public AnimationCurve animationCurve2 = new AnimationCurve(new Keyframe[2]
    {
      new Keyframe(0.0f, 0.0f, 0.0f, 1f),
      new Keyframe(1f, 1f, 1f, 0.0f)
    });
    public EaseType easeType1;
    public EaseType easeType2;
    private LoopStyle loopStyle = LoopStyle.PingPong;
    public float delay;
    public float duration = 1f;
    public bool ignoreTimeScale = true;
    public UnityEvent onFinished;
    private float mAmountPerDelta = 1000f;
    private float mDuration;
    private float mStartTime = -1f;
    private float mFactor;

    public float factor
    {
      get => this.mFactor;
      set => this.mFactor = Mathf.Clamp01(value);
    }

    public float amountPerDelta
    {
      get
      {
        if ((double) this.mDuration != (double) this.duration)
        {
          this.mDuration = this.duration;
          this.mAmountPerDelta = (double) this.duration <= 0.0 ? 1000f : 1f / this.duration;
        }
        return this.mAmountPerDelta;
      }
    }

    private void Start() => this.Update();

    private void Update()
    {
      float num1 = !this.ignoreTimeScale ? Time.deltaTime : Time.unscaledDeltaTime;
      float num2 = !this.ignoreTimeScale ? Time.time : Time.unscaledTime;
      if ((double) this.mStartTime < 0.0)
        this.mStartTime = num2 + this.delay;
      if ((double) num2 < (double) this.mStartTime)
        return;
      this.mFactor += this.amountPerDelta * num1;
      if (this.loopStyle == LoopStyle.Loop)
      {
        if ((double) this.mFactor > 1.0)
          this.mFactor -= Mathf.Floor(this.mFactor);
      }
      else if (this.loopStyle == LoopStyle.PingPong)
      {
        if ((double) this.mFactor > 1.0)
        {
          this.mFactor = (float) (1.0 - ((double) this.mFactor - (double) Mathf.Floor(this.mFactor)));
          this.mAmountPerDelta = -this.mAmountPerDelta;
        }
        else if ((double) this.mFactor < 0.0)
        {
          this.mFactor = -this.mFactor;
          this.mFactor -= Mathf.Floor(this.mFactor);
          this.mAmountPerDelta = -this.mAmountPerDelta;
        }
      }
      if (this.loopStyle == LoopStyle.Once && ((double) this.duration == 0.0 || (double) this.mFactor > 1.0 || (double) this.mFactor < 0.0))
      {
        this.mFactor = Mathf.Clamp01(this.mFactor);
        this.Sample(this.mFactor, true);
        this.enabled = false;
        if (this.onFinished == null)
          return;
        this.onFinished.Invoke();
      }
      else
        this.Sample(this.mFactor, false);
    }

    public void Sample(float _factor, bool _isFinished)
    {
      float num = Mathf.Clamp01(_factor);
      this.OnUpdate((double) this.mAmountPerDelta < 0.0 ? (this.easeType2 != EaseType.none ? EaseManager.EasingFromType(0.0f, 1f, num, this.easeType2) : this.animationCurve2.Evaluate(num)) : (this.easeType1 != EaseType.none ? EaseManager.EasingFromType(0.0f, 1f, num, this.easeType1) : this.animationCurve1.Evaluate(num)), _isFinished);
    }

    protected virtual void OnUpdate(float _factor, bool _isFinished)
    {
    }

    public void Reset()
    {
      this.enabled = true;
      this.easeType1 = EaseType.linear;
      this.easeType2 = EaseType.linear;
      this.loopStyle = LoopStyle.PingPong;
      this.delay = 0.0f;
      this.duration = 1f;
      this.ignoreTimeScale = true;
      this.onFinished = (UnityEvent) null;
      this.mAmountPerDelta = 1000f;
      this.mDuration = 0.0f;
      this.mStartTime = -1f;
      this.mFactor = 0.0f;
    }

    public static T Begin<T>(GameObject _go, float _duration) where T : uTweener
    {
      T obj = _go.GetComponent<T>();
      if ((Object) obj == (Object) null)
        obj = _go.AddComponent<T>();
      obj.Reset();
      obj.duration = _duration;
      obj.enabled = true;
      return obj;
    }

    public void Play(PlayDirection dir = PlayDirection.Forward)
    {
      this.mAmountPerDelta = dir != PlayDirection.Reverse ? Mathf.Abs(this.amountPerDelta) : -Mathf.Abs(this.amountPerDelta);
      this.enabled = true;
      this.Update();
    }

    public void Toggle()
    {
      this.mAmountPerDelta *= -1f;
      this.enabled = true;
    }

    [ContextMenu("Set 'From' to current value")]
    public virtual void SetStartToCurrentValue()
    {
    }

    [ContextMenu("Set 'To' to current value")]
    public virtual void SetEndToCurrentValue()
    {
    }

    [ContextMenu("Assume value of 'From'")]
    public virtual void SetCurrentValueToStart()
    {
    }

    [ContextMenu("Assume value of 'To'")]
    public virtual void SetCurrentValueToEnd()
    {
    }
  }
}
