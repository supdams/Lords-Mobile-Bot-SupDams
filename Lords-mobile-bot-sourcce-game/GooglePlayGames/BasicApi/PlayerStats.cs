// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.PlayerStats
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
namespace GooglePlayGames.BasicApi
{
  public class PlayerStats
  {
    private static float UNSET_VALUE = -1f;

    public PlayerStats() => this.Valid = false;

    public bool Valid { get; set; }

    public int NumberOfPurchases { get; set; }

    public float AvgSessonLength { get; set; }

    public int DaysSinceLastPlayed { get; set; }

    public int NumberOfSessions { get; set; }

    public float SessPercentile { get; set; }

    public float SpendPercentile { get; set; }

    public float ChurnProbability { get; set; }

    public bool HasNumberOfPurchases() => this.NumberOfPurchases != (int) PlayerStats.UNSET_VALUE;

    public bool HasAvgSessonLength()
    {
      return (double) this.AvgSessonLength != (double) PlayerStats.UNSET_VALUE;
    }

    public bool HasDaysSinceLastPlayed()
    {
      return this.DaysSinceLastPlayed != (int) PlayerStats.UNSET_VALUE;
    }

    public bool HasNumberOfSessions() => this.NumberOfSessions != (int) PlayerStats.UNSET_VALUE;

    public bool HasSessPercentile()
    {
      return (double) this.SessPercentile != (double) PlayerStats.UNSET_VALUE;
    }

    public bool HasSpendPercentile()
    {
      return (double) this.SpendPercentile != (double) PlayerStats.UNSET_VALUE;
    }

    public bool HasChurnProbability()
    {
      return (double) this.ChurnProbability != (double) PlayerStats.UNSET_VALUE;
    }
  }
}
