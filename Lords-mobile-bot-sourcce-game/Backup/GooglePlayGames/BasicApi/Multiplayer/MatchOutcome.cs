// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Multiplayer.MatchOutcome
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
namespace GooglePlayGames.BasicApi.Multiplayer
{
  public class MatchOutcome
  {
    public const uint PlacementUnset = 0;
    private List<string> mParticipantIds = new List<string>();
    private Dictionary<string, uint> mPlacements = new Dictionary<string, uint>();
    private Dictionary<string, MatchOutcome.ParticipantResult> mResults = new Dictionary<string, MatchOutcome.ParticipantResult>();

    public void SetParticipantResult(
      string participantId,
      MatchOutcome.ParticipantResult result,
      uint placement)
    {
      if (!this.mParticipantIds.Contains(participantId))
        this.mParticipantIds.Add(participantId);
      this.mPlacements[participantId] = placement;
      this.mResults[participantId] = result;
    }

    public void SetParticipantResult(string participantId, MatchOutcome.ParticipantResult result)
    {
      this.SetParticipantResult(participantId, result, 0U);
    }

    public void SetParticipantResult(string participantId, uint placement)
    {
      this.SetParticipantResult(participantId, MatchOutcome.ParticipantResult.Unset, placement);
    }

    public List<string> ParticipantIds => this.mParticipantIds;

    public MatchOutcome.ParticipantResult GetResultFor(string participantId)
    {
      return this.mResults.ContainsKey(participantId) ? this.mResults[participantId] : MatchOutcome.ParticipantResult.Unset;
    }

    public uint GetPlacementFor(string participantId)
    {
      return this.mPlacements.ContainsKey(participantId) ? this.mPlacements[participantId] : 0U;
    }

    public override string ToString()
    {
      string str = "[MatchOutcome";
      foreach (string mParticipantId in this.mParticipantIds)
        str += string.Format(" {0}->({1},{2})", (object) mParticipantId, (object) this.GetResultFor(mParticipantId), (object) this.GetPlacementFor(mParticipantId));
      return str + "]";
    }

    public enum ParticipantResult
    {
      Unset = -1, // 0xFFFFFFFF
      None = 0,
      Win = 1,
      Loss = 2,
      Tie = 3,
    }
  }
}
