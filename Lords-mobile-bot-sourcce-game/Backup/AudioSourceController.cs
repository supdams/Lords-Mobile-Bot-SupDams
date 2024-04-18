// Decompiled with JetBrains decompiler
// Type: AudioSourceController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class AudioSourceController
{
  private byte Valid;
  private AudioSource Source;

  public void Set(AudioSource source)
  {
    this.Source = source;
    this.Valid = (byte) 1;
  }

  public void Stop()
  {
    if (this.Valid != (byte) 1)
      return;
    this.Source.Stop();
  }

  public void CheckValid(AudioSource source)
  {
    if (this.Valid == (byte) 0 || !((Object) this.Source == (Object) source))
      return;
    this.Valid = (byte) 0;
  }
}
