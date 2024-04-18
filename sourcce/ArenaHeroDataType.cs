// Decompiled with JetBrains decompiler
// Type: ArenaHeroDataType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct ArenaHeroDataType
{
  public ushort ID;
  public byte Level;
  public byte Rank;
  public byte Star;
  public byte Equip;
  public byte[] SkillLV;

  public static implicit operator HeroBattleData(ArenaHeroDataType ah) => new HeroBattleData(ah);
}
