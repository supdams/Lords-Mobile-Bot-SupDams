// Decompiled with JetBrains decompiler
// Type: Fader
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class Fader : Image
{
  private bool bWorking;
  private float speed = 0.5f;
  private Color _color = new Color(0.0f, 0.0f, 0.0f, 0.0f);

  public void Reset()
  {
    this._color.a = 0.0f;
    ((Graphic) this).color = this._color;
    this.bWorking = false;
  }

  public void Update()
  {
    if (!this.bWorking)
      return;
    float num = this._color.a + Time.deltaTime * this.speed;
    if ((double) num > 1.0)
    {
      num = 1f;
      this.bWorking = false;
    }
    this._color.a = num;
    ((Graphic) this).color = this._color;
  }

  public void Action() => this.bWorking = true;
}
