// Decompiled with JetBrains decompiler
// Type: SceneData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
[Serializable]
public class SceneData : ScriptableObject
{
  public bool mfog;
  public Color mfogcolor;
  public Color mambientLight;
  public float mfogDensity;
  public byte mfogMode;
  public float mfogStartDistance;
  public float mfogEndDistance;
  public Texture2D[] Lightmap;
  public LightProbes Lightprobe;
  public Color cameraBackgroundColor;

  public void init()
  {
    this.mfog = RenderSettings.fog;
    this.mfogcolor = RenderSettings.fogColor;
    this.mfogDensity = RenderSettings.fogDensity;
    this.mfogMode = (byte) RenderSettings.fogMode;
    this.mfogStartDistance = RenderSettings.fogStartDistance;
    this.mfogEndDistance = RenderSettings.fogEndDistance;
    this.mambientLight = RenderSettings.ambientLight;
    if (LightmapSettings.lightmaps.Length > 0)
    {
      this.Lightmap = new Texture2D[LightmapSettings.lightmaps.Length];
      for (int index = 0; index < this.Lightmap.Length; ++index)
        this.Lightmap[index] = LightmapSettings.lightmaps[index].lightmapFar;
    }
    this.Lightprobe = LightmapSettings.lightProbes;
    this.cameraBackgroundColor = Camera.main.backgroundColor;
  }
}
