// Decompiled with JetBrains decompiler
// Type: CALC_ATTRDATA_STRUCT
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct CALC_ATTRDATA_STRUCT
{
  public byte[] SkillLV;
  public byte LV;
  public byte Star;
  public byte Enhance;
  public byte Equip;

  private CALC_ATTRDATA_STRUCT(byte tmp)
  {
    this.SkillLV = new byte[4];
    this.LV = (byte) 0;
    this.Star = (byte) 0;
    this.Enhance = (byte) 0;
    this.Equip = (byte) 0;
  }
}
