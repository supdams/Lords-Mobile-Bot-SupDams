// Decompiled with JetBrains decompiler
// Type: LeaderBoardTopBoard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class LeaderBoardTopBoard
{
  public long SortTime;
  public BoardUnit PowerTop;
  public ushort PowerTopHead;
  public BoardUnit KillsTop;
  public ushort KillTopHead;
  public BoardUnit AlliPowerTop;
  public ushort PowerTopEmblem;
  public BoardUnit AlliKillsTop;
  public ushort KillsTopEmblem;
  public BoardUnit ArenaTop;
  public ushort ArenaTopHead;

  public LeaderBoardTopBoard()
  {
    this.PowerTop = new BoardUnit();
    this.KillsTop = new BoardUnit();
    this.AlliPowerTop = new BoardUnit();
    this.AlliKillsTop = new BoardUnit();
    this.ArenaTop = new BoardUnit();
  }
}
