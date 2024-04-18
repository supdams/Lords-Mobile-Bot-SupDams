// Decompiled with JetBrains decompiler
// Type: NobilityGroupDataType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct NobilityGroupDataType
{
  public ushort KingdomID;
  public byte WonderID;
  public EActivityState EventState;
  public long EventBeginTime;
  public uint EventRequireTime;
  public long EventCountTime;
  public bool bAskPrizeData;
  public ActPrizeDataType[][] PreparePrize;
  public bool bAskKingdomData;
  public byte FightKingdomCount;
  public ushort[] FightKingdomID;
  public bool bAskNobilityData;
  public ushort NobilityKingdomID;
  public ushort NobilityHeroID;
  public CString NobilityName;
  public CString EventTimeStr;
}
