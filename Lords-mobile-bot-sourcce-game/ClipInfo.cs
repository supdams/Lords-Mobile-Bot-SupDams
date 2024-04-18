// Decompiled with JetBrains decompiler
// Type: ClipInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class ClipInfo
{
  public AudioClip clip;
  public float Volume = 1f;
  public float Pitch = 1f;
  public float PanLevel = 1f;
  public bool Loop;
  public float? DelaySecond;

  public void clear()
  {
    this.clip = (AudioClip) null;
    this.Volume = 1f;
    this.Pitch = 1f;
    this.PanLevel = 1f;
    this.Loop = false;
    this.DelaySecond = new float?();
  }
}
