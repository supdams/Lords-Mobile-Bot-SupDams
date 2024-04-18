// Decompiled with JetBrains decompiler
// Type: uTools.uTweenAlpha
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace uTools
{
  [AddComponentMenu("uTools/Tween/Tween Alpha(uTools)")]
  public class uTweenAlpha : uTweenValue
  {
    public MaskableGraphic mMaskableGraphic;
    private float mAlpha;

    public float alpha
    {
      get => this.mAlpha;
      set
      {
        this.SetAlpha(this.transform, value);
        this.mAlpha = value;
      }
    }

    protected override void ValueUpdate(float value, bool isFinished) => this.alpha = value;

    private void SetAlpha(Transform _transform, float _alpha)
    {
      if ((Object) this.mMaskableGraphic == (Object) null)
        this.mMaskableGraphic = _transform.GetComponent<MaskableGraphic>();
      if (!((Object) this.mMaskableGraphic != (Object) null))
        return;
      ((Graphic) this.mMaskableGraphic).color = ((Graphic) this.mMaskableGraphic).color with
      {
        a = _alpha
      };
    }
  }
}
