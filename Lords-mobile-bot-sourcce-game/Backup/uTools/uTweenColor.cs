// Decompiled with JetBrains decompiler
// Type: uTools.uTweenColor
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace uTools
{
  [AddComponentMenu("uTools/Tween/Tween Color(uTools)")]
  public class uTweenColor : uTweener
  {
    public Color from = Color.white;
    public Color to = Color.white;
    public bool includeChilds;
    public MaskableGraphic mMaskableGraphic;
    private Color mColor = Color.white;

    public Color colorValue
    {
      get => this.mColor;
      set
      {
        this.SetColor(this.transform, value);
        this.mColor = value;
      }
    }

    protected override void OnUpdate(float factor, bool isFinished)
    {
      this.colorValue = Color.Lerp(this.from, this.to, factor);
    }

    public static uTweenColor Begin(
      GameObject go,
      float duration,
      float delay,
      Color from,
      Color to)
    {
      uTweenColor uTweenColor = uTweener.Begin<uTweenColor>(go, duration);
      uTweenColor.from = from;
      uTweenColor.to = to;
      uTweenColor.delay = delay;
      if ((double) duration <= 0.0)
      {
        uTweenColor.Sample(1f, true);
        uTweenColor.enabled = false;
      }
      return uTweenColor;
    }

    private void SetColor(Transform _transform, Color _color)
    {
      if ((Object) this.mMaskableGraphic == (Object) null)
        this.mMaskableGraphic = _transform.GetComponent<MaskableGraphic>();
      if (!((Object) this.mMaskableGraphic != (Object) null))
        return;
      ((Graphic) this.mMaskableGraphic).color = _color;
    }
  }
}
