// Decompiled with JetBrains decompiler
// Type: RenderSettingsData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class RenderSettingsData : ScriptableObject
{
  public bool mfog;
  public Color mfogcolor;
  public Color mambientLight;
  public float mfogDensity;
  public byte mfogMode;
  public float mfogStartDistance;
  public float mfogEndDistance;

  public void init()
  {
    this.mfog = RenderSettings.fog;
    this.mfogcolor = RenderSettings.fogColor;
    this.mfogDensity = RenderSettings.fogDensity;
    this.mfogMode = (byte) RenderSettings.fogMode;
    this.mfogStartDistance = RenderSettings.fogStartDistance;
    this.mfogEndDistance = RenderSettings.fogEndDistance;
    this.mambientLight = RenderSettings.ambientLight;
  }
}
