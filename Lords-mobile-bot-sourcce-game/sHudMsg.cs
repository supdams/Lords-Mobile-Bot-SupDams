// Decompiled with JetBrains decompiler
// Type: sHudMsg
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal class sHudMsg
{
  public Vector2 Pos;
  public float ColorA;
  public float time;
  public bool Enable;
  public Transform Trnas;
  public int Idx;
  public UIText Msg;
  public Image Bg;

  public sHudMsg(int len = 0)
  {
    this.Pos = Vector2.zero;
    this.ColorA = 1f;
    this.time = 0.0f;
    this.Enable = false;
    this.Trnas = (Transform) null;
    this.Idx = -1;
    this.Msg = (UIText) null;
    this.Bg = (Image) null;
  }
}
