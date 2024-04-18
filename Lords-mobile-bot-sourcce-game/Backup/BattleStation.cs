// Decompiled with JetBrains decompiler
// Type: BattleStation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct BattleStation
{
  public AllianceWarManager._RegisterData[] Autobot;
  public AllianceWarManager._RegisterData[] Decepticon;
  public AlliWarWarDetail[] BattleMatch;
  public CString DecepticonTag;
  public ushort DecepticonIcon;
  public CString AutobotTag;
  public ushort AutobotIcon;
  public byte DecepticonPos;
  public byte Decepticons;
  public byte AutobotPos;
  public byte Autobots;
  public byte Received;
  public byte OnLive;
  public byte MatchID;
  public byte GameRound;
  public long BeginTime;
  public byte BattleSide;
  public byte BattleRound;
  public byte BattleWinner;
  public byte BattleMatchs;
  public byte BattlePosition;
  public byte CampDecepticon;
  public byte CampAutobot;

  public void Clear()
  {
    StringManager.Instance.DeSpawnString(this.DecepticonTag);
    StringManager.Instance.DeSpawnString(this.AutobotTag);
    this.AutobotTag = this.DecepticonTag = (CString) null;
    this.Autobot = this.Decepticon = (AllianceWarManager._RegisterData[]) null;
    this.BattleMatch = (AlliWarWarDetail[]) null;
    this.BattlePosition = (byte) 0;
    this.CampDecepticon = (byte) 0;
    this.CampAutobot = (byte) 0;
    this.BattleSide = (byte) 0;
    this.BeginTime = 0L;
    this.Received = (byte) 0;
  }

  public void SetData(
    AllianceWarManager._RegisterData[] wins = null,
    AllianceWarManager._RegisterData[] loss = null)
  {
    this.Autobot = wins;
    this.Decepticon = loss;
  }
}
