// Decompiled with JetBrains decompiler
// Type: uTools.uTweenText
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
namespace uTools
{
  [AddComponentMenu("uTools/Tween/Tween Text(uTools)")]
  public class uTweenText : uTweenValue
  {
    private Text mText;
    public int digits;

    public Text cacheText
    {
      get
      {
        this.mText = this.GetComponent<Text>();
        if ((UnityEngine.Object) this.mText == (UnityEngine.Object) null)
          Debug.LogError((object) "'uTweenText' can't find 'Text'");
        return this.mText;
      }
    }

    protected override void ValueUpdate(float value, bool isFinished)
    {
      this.cacheText.text = Math.Round((double) value, this.digits).ToString();
    }

    public static uTweenText Begin(Text label, float duration, float delay, float from, float to)
    {
      uTweenText uTweenText = uTweener.Begin<uTweenText>(((Component) label).gameObject, duration);
      uTweenText.from = from;
      uTweenText.to = to;
      uTweenText.delay = delay;
      if ((double) duration <= 0.0)
      {
        uTweenText.Sample(1f, true);
        uTweenText.enabled = false;
      }
      return uTweenText;
    }
  }
}
