// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.OurUtils;
using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace GooglePlayGames.BasicApi.Multiplayer
{
  public class TurnBasedMatch
  {
    private string mMatchId;
    private byte[] mData;
    private bool mCanRematch;
    private uint mAvailableAutomatchSlots;
    private string mSelfParticipantId;
    private List<Participant> mParticipants;
    private string mPendingParticipantId;
    private TurnBasedMatch.MatchTurnStatus mTurnStatus;
    private TurnBasedMatch.MatchStatus mMatchStatus;
    private uint mVariant;
    private uint mVersion;

    internal TurnBasedMatch(
      string matchId,
      byte[] data,
      bool canRematch,
      string selfParticipantId,
      List<Participant> participants,
      uint availableAutomatchSlots,
      string pendingParticipantId,
      TurnBasedMatch.MatchTurnStatus turnStatus,
      TurnBasedMatch.MatchStatus matchStatus,
      uint variant,
      uint version)
    {
      this.mMatchId = matchId;
      this.mData = data;
      this.mCanRematch = canRematch;
      this.mSelfParticipantId = selfParticipantId;
      this.mParticipants = participants;
      this.mParticipants.Sort();
      this.mAvailableAutomatchSlots = availableAutomatchSlots;
      this.mPendingParticipantId = pendingParticipantId;
      this.mTurnStatus = turnStatus;
      this.mMatchStatus = matchStatus;
      this.mVariant = variant;
      this.mVersion = version;
    }

    public string MatchId => this.mMatchId;

    public byte[] Data => this.mData;

    public bool CanRematch => this.mCanRematch;

    public string SelfParticipantId => this.mSelfParticipantId;

    public Participant Self => this.GetParticipant(this.mSelfParticipantId);

    public Participant GetParticipant(string participantId)
    {
      foreach (Participant mParticipant in this.mParticipants)
      {
        if (mParticipant.ParticipantId.Equals(participantId))
          return mParticipant;
      }
      Logger.w("Participant not found in turn-based match: " + participantId);
      return (Participant) null;
    }

    public List<Participant> Participants => this.mParticipants;

    public string PendingParticipantId => this.mPendingParticipantId;

    public Participant PendingParticipant
    {
      get
      {
        return this.mPendingParticipantId == null ? (Participant) null : this.GetParticipant(this.mPendingParticipantId);
      }
    }

    public TurnBasedMatch.MatchTurnStatus TurnStatus => this.mTurnStatus;

    public TurnBasedMatch.MatchStatus Status => this.mMatchStatus;

    public uint Variant => this.mVariant;

    public uint Version => this.mVersion;

    public uint AvailableAutomatchSlots => this.mAvailableAutomatchSlots;

    public override string ToString()
    {
      return string.Format("[TurnBasedMatch: mMatchId={0}, mData={1}, mCanRematch={2}, mSelfParticipantId={3}, mParticipants={4}, mPendingParticipantId={5}, mTurnStatus={6}, mMatchStatus={7}, mVariant={8}, mVersion={9}]", (object) this.mMatchId, (object) this.mData, (object) this.mCanRematch, (object) this.mSelfParticipantId, (object) string.Join(",", this.mParticipants.Select<Participant, string>((Func<Participant, string>) (p => p.ToString())).ToArray<string>()), (object) this.mPendingParticipantId, (object) this.mTurnStatus, (object) this.mMatchStatus, (object) this.mVariant, (object) this.mVersion);
    }

    public enum MatchStatus
    {
      Active,
      AutoMatching,
      Cancelled,
      Complete,
      Expired,
      Unknown,
      Deleted,
    }

    public enum MatchTurnStatus
    {
      Complete,
      Invited,
      MyTurn,
      TheirTurn,
      Unknown,
    }
  }
}
