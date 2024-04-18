// Decompiled with JetBrains decompiler
// Type: AudioCloseQueue
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class AudioCloseQueue
{
  public float FadeTime;
  public float MaxFadeTime;
  public byte key;
  public AudioSource audioSource;
  private bool bUpdate;

  public void SetAudio(AudioSource audioSource, byte key, float MaxTime = 1.5f)
  {
    this.audioSource = audioSource;
    this.key = key;
    this.FadeTime = 0.0f;
    this.bUpdate = true;
    this.MaxFadeTime = MaxTime;
  }

  public void Update()
  {
    if (!this.bUpdate)
      return;
    if ((Object) this.audioSource == (Object) null)
    {
      this.bUpdate = false;
    }
    else
    {
      this.audioSource.volume = AudioManager.Instance.OutQuintic(this.FadeTime, 1f, -1f, this.MaxFadeTime);
      if ((double) this.FadeTime > (double) this.MaxFadeTime)
      {
        this.audioSource.Stop();
        this.bUpdate = false;
        AudioManager.Instance.NotifyCloseSFX(this.key);
      }
      else
        this.FadeTime += Time.deltaTime;
    }
  }
}
