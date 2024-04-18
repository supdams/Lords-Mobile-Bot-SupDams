// Decompiled with JetBrains decompiler
// Type: uTools.uTweenRotation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
namespace uTools
{
  [AddComponentMenu("uTools/Tween/Tween Rotation(uTools)")]
  public class uTweenRotation : uTweener
  {
    public Vector3 from;
    public Vector3 to;
    private RectTransform mRectTransfrom;
    public RectTransform target;

    public RectTransform cacheRectTransfrom
    {
      get
      {
        this.mRectTransfrom = !((Object) this.target == (Object) null) ? this.target : this.GetComponent<RectTransform>();
        return this.mRectTransfrom;
      }
    }

    public Quaternion value
    {
      get => ((Transform) this.cacheRectTransfrom).localRotation;
      set => ((Transform) this.cacheRectTransfrom).localRotation = value;
    }

    protected override void OnUpdate(float _factor, bool _isFinished)
    {
      this.value = Quaternion.Euler(Vector3.Lerp(this.from, this.to, _factor));
    }

    public static uTweenRotation Begin(
      GameObject go,
      Vector3 from,
      Vector3 to,
      float duration = 1f,
      float delay = 0.0f)
    {
      uTweenRotation uTweenRotation = uTweener.Begin<uTweenRotation>(go, duration);
      uTweenRotation.from = from;
      uTweenRotation.to = to;
      uTweenRotation.duration = duration;
      uTweenRotation.delay = delay;
      if ((double) duration <= 0.0)
      {
        uTweenRotation.Sample(1f, true);
        uTweenRotation.enabled = false;
      }
      return uTweenRotation;
    }
  }
}
