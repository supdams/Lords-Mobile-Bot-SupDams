// Decompiled with JetBrains decompiler
// Type: IconScaleValue
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
internal struct IconScaleValue
{
  public float selectSize;
  public float iconSize;
  public float sliderSize;
  public float time;
  public float colorA;
  public byte bShowIconEffect;
  public byte NowType;

  public IconScaleValue(int i)
  {
    this.NowType = (byte) 1;
    this.selectSize = 1f;
    this.sliderSize = 82f;
    this.iconSize = 68f;
    this.time = 0.0f;
    this.colorA = 0.0f;
    this.bShowIconEffect = (byte) 0;
  }
}
