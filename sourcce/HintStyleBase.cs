// Decompiled with JetBrains decompiler
// Type: HintStyleBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class HintStyleBase
{
  public RectTransform rectTrans;
  protected Vector2 Size;
  public Sprite HintFrameSprite;
  public Material HintFrameMat;

  public virtual void SetStyle(byte style)
  {
  }

  public virtual Vector2 GetSize() => Vector2.zero;

  public virtual void SetContent(int kind, int fontsize, float width, int Parm1, int Parm2 = 0)
  {
  }

  public virtual void SetContent(int kind, int fontsize, float width, CString cont)
  {
  }

  public virtual void SetActive(bool active)
  {
    ((Component) this.rectTrans).gameObject.SetActive(active);
  }

  public virtual void TextRefresh()
  {
  }
}
