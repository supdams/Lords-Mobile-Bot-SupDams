// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.NativePlayerStats
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class NativePlayerStats : BaseReferenceHolder
  {
    internal NativePlayerStats(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    internal bool Valid() => GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_Valid(this.SelfPtr());

    internal bool HasAverageSessionLength()
    {
      return GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_HasAverageSessionLength(this.SelfPtr());
    }

    internal float AverageSessionLength()
    {
      return GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_AverageSessionLength(this.SelfPtr());
    }

    internal bool HasChurnProbability()
    {
      return GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_HasChurnProbability(this.SelfPtr());
    }

    internal float ChurnProbability() => GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_ChurnProbability(this.SelfPtr());

    internal bool HasDaysSinceLastPlayed()
    {
      return GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_HasDaysSinceLastPlayed(this.SelfPtr());
    }

    internal int DaysSinceLastPlayed()
    {
      return GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_DaysSinceLastPlayed(this.SelfPtr());
    }

    internal bool HasNumberOfPurchases()
    {
      return GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_HasNumberOfPurchases(this.SelfPtr());
    }

    internal int NumberOfPurchases() => GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_NumberOfPurchases(this.SelfPtr());

    internal bool HasNumberOfSessions()
    {
      return GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_HasNumberOfSessions(this.SelfPtr());
    }

    internal int NumberOfSessions() => GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_NumberOfSessions(this.SelfPtr());

    internal bool HasSessionPercentile()
    {
      return GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_HasSessionPercentile(this.SelfPtr());
    }

    internal float SessionPercentile() => GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_SessionPercentile(this.SelfPtr());

    internal bool HasSpendPercentile()
    {
      return GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_HasSpendPercentile(this.SelfPtr());
    }

    internal float SpendPercentile() => GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_SpendPercentile(this.SelfPtr());

    protected override void CallDispose(HandleRef selfPointer)
    {
      GooglePlayGames.Native.Cwrapper.PlayerStats.PlayerStats_Dispose(selfPointer);
    }

    internal GooglePlayGames.BasicApi.PlayerStats AsPlayerStats()
    {
      GooglePlayGames.BasicApi.PlayerStats playerStats = new GooglePlayGames.BasicApi.PlayerStats();
      playerStats.Valid = this.Valid();
      if (this.Valid())
      {
        playerStats.AvgSessonLength = this.AverageSessionLength();
        playerStats.ChurnProbability = this.ChurnProbability();
        playerStats.DaysSinceLastPlayed = this.DaysSinceLastPlayed();
        playerStats.NumberOfPurchases = this.NumberOfPurchases();
        playerStats.NumberOfSessions = this.NumberOfSessions();
        playerStats.SessPercentile = this.SessionPercentile();
        playerStats.SpendPercentile = this.SpendPercentile();
      }
      return playerStats;
    }
  }
}
