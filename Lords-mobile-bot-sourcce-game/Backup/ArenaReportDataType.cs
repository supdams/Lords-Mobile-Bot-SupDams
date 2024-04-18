// Decompiled with JetBrains decompiler
// Type: ArenaReportDataType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct ArenaReportDataType
{
  public uint SimulatorVersion;
  public uint SimulatorPatchNo;
  public byte Flag;
  public byte[] TopicID;
  public ArenaTopicEffectDataType[] TopicEffect;
  public uint ChangePlace;
  public ArenaHeroDataType[] MyHeroData;
  public ushort EnemyHead;
  public string EnemyName;
  public string EnemyAllianceTag;
  public ArenaHeroDataType[] EnemyHeroData;
  public ushort RandomSeed;
  public byte RandomGap;
  public byte PrimarySide;
  public long Time;
}
