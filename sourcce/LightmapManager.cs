// Decompiled with JetBrains decompiler
// Type: LightmapManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class LightmapManager
{
  private LightmapData[] LightmapDataArr;
  private Renderer twinkleRender;
  public int SceneLightmapSize;
  private int twinkleLightIndex;
  private float twinkleHalfTotalTime = 0.4f;
  private float twinkleCurTime;
  private static LightmapManager instance;
  private bool Reverse;
  private Color MaskMaxColor = new Color(0.65f, 0.65f, 0.65f);

  private LightmapManager()
  {
    this.twinkleRender = (Renderer) null;
    this.twinkleCurTime = 0.0f;
    this.InitialCustomLightmap();
  }

  public static LightmapManager Instance
  {
    get
    {
      if (LightmapManager.instance == null)
        LightmapManager.instance = new LightmapManager();
      return LightmapManager.instance;
    }
  }

  public void InitialCustomLightmap()
  {
    ushort length = 9;
    this.LightmapDataArr = new LightmapData[(int) length];
    Color[] colorArray = new Color[(int) length];
    Color color1 = new Color(0.175f, 0.175f, 0.175f);
    Color color2 = new Color(0.88f, 0.88f, 0.88f);
    Color color3 = new Color(0.045f, 0.045f, 0.045f);
    Color color4 = new Color(0.325f, 0.325f, 0.325f);
    Color color5 = BattleController.StateSkin[0];
    Color color6 = BattleController.StateSkin[1];
    Color color7 = BattleController.StateSkin[2];
    Color color8 = BattleController.StateSkin[3];
    colorArray[0] = color1;
    colorArray[1] = color2;
    colorArray[2] = color2;
    colorArray[3] = color3;
    colorArray[4] = color4;
    colorArray[5] = color5;
    colorArray[6] = color6;
    colorArray[7] = color7;
    colorArray[8] = color8;
    for (ushort index = 0; (int) index < (int) length; ++index)
    {
      LightmapData lightmapData = new LightmapData();
      Texture2D texture2D = new Texture2D(1, 1);
      for (int x = 0; x < texture2D.width; ++x)
      {
        for (int y = 0; y < texture2D.height; ++y)
          texture2D.SetPixel(x, y, colorArray[(int) index]);
      }
      texture2D.Apply();
      lightmapData.lightmapFar = texture2D;
      this.LightmapDataArr[(int) index] = lightmapData;
    }
  }

  public byte GetCustomLightmapNum() => 9;

  public void SetTwinkle(Renderer render, bool bTwinkle, float HalfTotalTime = 0.4f)
  {
    if (bTwinkle)
    {
      if ((UnityEngine.Object) this.twinkleRender != (UnityEngine.Object) null)
        this.SetTwinkle(render, false);
      this.twinkleHalfTotalTime = HalfTotalTime;
      this.twinkleRender = render;
      this.twinkleLightIndex = render.lightmapIndex;
      render.lightmapIndex = this.SceneLightmapSize + 3;
    }
    else
    {
      if (!((UnityEngine.Object) this.twinkleRender != (UnityEngine.Object) null))
        return;
      this.twinkleRender.lightmapIndex = this.twinkleLightIndex;
      this.twinkleRender = (Renderer) null;
    }
  }

  public void SetRenderIndex(Renderer render, Lightmap_Enum State)
  {
    render.lightmapIndex = (int) (State + this.SceneLightmapSize);
  }

  public void UpdateCurLightmap(LightmapData[] lightmapData)
  {
    this.SceneLightmapSize = lightmapData.Length - (int) this.GetCustomLightmapNum();
    this.LightmapDataArr.CopyTo((Array) lightmapData, this.SceneLightmapSize);
  }

  public void Update() => this.UpdateTwinkle();

  private void UpdateTwinkle()
  {
    if ((UnityEngine.Object) this.twinkleRender == (UnityEngine.Object) null)
      return;
    Texture2D lightmapFar = LightmapSettings.lightmaps[this.SceneLightmapSize + 3].lightmapFar;
    lightmapFar.GetPixel(1, 1);
    Color color;
    if ((double) this.twinkleCurTime <= (double) this.twinkleHalfTotalTime && !this.Reverse)
    {
      color = Color.Lerp(Color.white, this.MaskMaxColor, this.twinkleCurTime / this.twinkleHalfTotalTime);
    }
    else
    {
      this.Reverse = true;
      color = Color.Lerp(Color.white, this.MaskMaxColor, (float) (1.0 - ((double) this.twinkleCurTime - (double) this.twinkleHalfTotalTime) / (double) this.twinkleHalfTotalTime));
    }
    lightmapFar.SetPixel(1, 1, color);
    lightmapFar.Apply();
    this.twinkleCurTime += Time.deltaTime;
    if ((double) this.twinkleCurTime <= (double) this.twinkleHalfTotalTime * 2.0)
      return;
    this.twinkleCurTime = 0.0f;
    this.Reverse = false;
  }

  public void UpdateSceneAmbient()
  {
    Texture2D lightmapFar = LightmapSettings.lightmaps[this.SceneLightmapSize + 2].lightmapFar;
    lightmapFar.SetPixel(1, 1, RenderSettings.ambientLight);
    lightmapFar.Apply();
    Debug.Log((object) ("Update Scene Ambient To " + RenderSettings.ambientLight.ToString()));
  }

  public int GetLightmapIndex(Lightmap_Enum kind) => (int) (this.SceneLightmapSize + kind);

  public Texture2D GetLightmapTexture(Lightmap_Enum kind)
  {
    return LightmapSettings.lightmaps[(int) (this.SceneLightmapSize + kind)].lightmapFar;
  }
}
