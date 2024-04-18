// Decompiled with JetBrains decompiler
// Type: AERunnerSetter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal class AERunnerSetter
{
  public static AERunner SetFunctionTick(RectTransform RTF, Image[] Image)
  {
    AERunner aeRunner = new AERunner(RTF);
    aeRunner.CenterPivot = Vector2.zero;
    aeRunner.ActiveKind = new AERunner.AEType[2]
    {
      AERunner.AEType.scale,
      AERunner.AEType.alpha
    };
    aeRunner.AlphaApplyImages = Image;
    aeRunner.ScaleValue = new Vector2[4]
    {
      new Vector2(4.6f, 4.6f),
      new Vector2(4f, 4f),
      new Vector2(0.9f, 0.9f),
      new Vector2(1f, 1f)
    };
    aeRunner.ScaleKey = new float[4]
    {
      0.0f,
      0.166666672f,
      0.266666681f,
      0.333333343f
    };
    aeRunner.AlphaValue = new float[3]{ 0.0f, 100f, 100f };
    aeRunner.AlphaKey = new float[3]
    {
      0.0f,
      0.2f,
      0.333333343f
    };
    aeRunner.CheckLastKey();
    return aeRunner;
  }

  public static AERunner SetFunctionDisappear(RectTransform RTF, Image[] Image)
  {
    AERunner aeRunner = new AERunner(RTF);
    aeRunner.CenterPivot = Vector2.zero;
    aeRunner.ActiveKind = new AERunner.AEType[2]
    {
      AERunner.AEType.scale,
      AERunner.AEType.alpha
    };
    aeRunner.AlphaApplyImages = Image;
    aeRunner.ScaleValue = new Vector2[3]
    {
      new Vector2(1f, 1f),
      new Vector2(1.2f, 1.2f),
      new Vector2(0.0f, 0.0f)
    };
    aeRunner.ScaleKey = new float[3]
    {
      0.333333343f,
      0.6f,
      0.766666651f
    };
    aeRunner.AlphaValue = new float[2]{ 100f, 0.0f };
    aeRunner.AlphaKey = new float[2]{ 0.6333333f, 0.9f };
    aeRunner.CheckLastKey();
    return aeRunner;
  }

  public static AERunner SetFunctionAppear(RectTransform RTF, Image[] Image)
  {
    AERunner aeRunner = new AERunner(RTF);
    aeRunner.CenterPivot = Vector2.zero;
    aeRunner.ActiveKind = new AERunner.AEType[2]
    {
      AERunner.AEType.scale,
      AERunner.AEType.alpha
    };
    aeRunner.AlphaApplyImages = Image;
    aeRunner.ScaleValue = new Vector2[3]
    {
      new Vector2(0.0f, 0.0f),
      new Vector2(1.2f, 1.2f),
      new Vector2(1f, 1f)
    };
    aeRunner.ScaleKey = new float[3]
    {
      0.766666651f,
      1.0333333f,
      1.3f
    };
    aeRunner.AlphaValue = new float[2]{ 0.0f, 100f };
    aeRunner.AlphaKey = new float[2]
    {
      0.766666651f,
      1.26666665f
    };
    aeRunner.CheckLastKey();
    return aeRunner;
  }

  public static AERunner SetFunctionFirst(RectTransform RTF, Image[] Image)
  {
    AERunner aeRunner = new AERunner(RTF);
    aeRunner.CenterPivot = Vector2.zero;
    aeRunner.ActiveKind = new AERunner.AEType[2]
    {
      AERunner.AEType.scale,
      AERunner.AEType.alpha
    };
    aeRunner.AlphaApplyImages = Image;
    aeRunner.ScaleValue = new Vector2[3]
    {
      new Vector2(0.0f, 0.0f),
      new Vector2(1.2f, 1.2f),
      new Vector2(1f, 1f)
    };
    aeRunner.ScaleKey = new float[3]
    {
      0.0f,
      0.266666681f,
      0.533333361f
    };
    aeRunner.AlphaValue = new float[2]{ 0.0f, 100f };
    aeRunner.AlphaKey = new float[2]{ 0.0f, 0.5f };
    aeRunner.CheckLastKey();
    return aeRunner;
  }
}
