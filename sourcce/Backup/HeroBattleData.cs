// Decompiled with JetBrains decompiler
// Type: HeroBattleData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HeroBattleData
{
  public ushort HeroID;
  public CalcAttrDataType AttrData;

  public HeroBattleData(ArenaHeroDataType ah)
  {
    this.HeroID = ah.ID;
    this.AttrData = new CalcAttrDataType();
    this.AttrData.LV = ah.Level;
    this.AttrData.Star = ah.Star;
    this.AttrData.Enhance = ah.Rank;
    this.AttrData.Equip = ah.Equip;
    if (ah.SkillLV == null || ah.SkillLV.Length != 4)
      return;
    this.AttrData.SkillLV1 = ah.SkillLV[0];
    this.AttrData.SkillLV2 = ah.SkillLV[1];
    this.AttrData.SkillLV3 = ah.SkillLV[2];
    this.AttrData.SkillLV4 = ah.SkillLV[3];
  }
}
