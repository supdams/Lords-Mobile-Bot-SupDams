// Decompiled with JetBrains decompiler
// Type: WorldLeaderBoardTopBoard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class WorldLeaderBoardTopBoard
{
  public long SortTime;
  public WorldRankingBoardUnit PowerTop;
  public ushort PowerTopHead;
  public WorldRankingBoardUnit KillsTop;
  public ushort KillsTopHead;
  public WorldRankingBoardUnitAlliance AlliPowerTop;
  public ushort PowerTopEmblem;
  public WorldRankingBoardUnitAlliance AlliKillsTop;
  public ushort KillsTopEmblem;

  public WorldLeaderBoardTopBoard()
  {
    this.PowerTop = new WorldRankingBoardUnit();
    this.KillsTop = new WorldRankingBoardUnit();
    this.AlliPowerTop = new WorldRankingBoardUnitAlliance();
    this.AlliKillsTop = new WorldRankingBoardUnitAlliance();
  }
}
