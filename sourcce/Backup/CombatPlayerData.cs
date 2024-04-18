// Decompiled with JetBrains decompiler
// Type: CombatPlayerData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct CombatPlayerData
{
  public bool bMain;
  public string Name;
  public string AllianceTag;
  public byte AllianceRank;
  public ushort KingdomID;
  public byte StrongholdLevel;
  public byte Level;
  public ushort Head;
  public byte VIPLevel;
  public HeroDataType[] HeroInfo;
  public ulong LosePower;
  public uint[] SurviveTroop;
  public uint[] DeadTroop;
  public uint[] AttackAttr;
  public uint[] DefenceAttr;
  public uint[] HealthAttr;
  public byte ArmyCoordIndex;
}
