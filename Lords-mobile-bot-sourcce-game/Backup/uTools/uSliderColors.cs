// Decompiled with JetBrains decompiler
// Type: uTools.uSliderColors
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable disable
namespace uTools
{
  [AddComponentMenu("uTools/Tween/Slider Colors(uTools)")]
  public class uSliderColors : MonoBehaviour
  {
    public Image target;
    public Color[] colors = new Color[3]
    {
      Color.red,
      Color.yellow,
      Color.green
    };
    private Slider mSlider;

    private void Start()
    {
      this.mSlider = this.GetComponent<Slider>();
      if ((Object) this.mSlider == (Object) null)
      {
        Debug.LogError((object) " 'uSliderColors' can't find 'Slider'.");
      }
      else
      {
        if ((Object) this.target == (Object) null)
          this.target = ((Component) this.mSlider).GetComponentInChildren<Image>();
        // ISSUE: method pointer
        ((UnityEvent<float>) this.mSlider.onValueChanged).AddListener(new UnityAction<float>((object) this, __methodptr(OnValueChanged)));
        this.OnValueChanged(this.mSlider.value);
      }
    }

    public void OnValueChanged(float value)
    {
      float f = value * (float) (this.colors.Length - 1);
      int index = Mathf.FloorToInt(f);
      Color color = this.colors[0];
      if (index + 1 < this.colors.Length)
        color = Color.Lerp(this.colors[index], this.colors[index + 1], f - (float) index);
      else if (index < this.colors.Length)
        color = this.colors[index];
      ((Graphic) this.target).color = color;
    }
  }
}
