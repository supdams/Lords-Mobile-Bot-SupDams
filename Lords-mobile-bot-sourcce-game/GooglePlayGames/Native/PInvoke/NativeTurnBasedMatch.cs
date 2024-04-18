// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.NativeTurnBasedMatch
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class NativeTurnBasedMatch : BaseReferenceHolder
  {
    internal NativeTurnBasedMatch(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    internal uint AvailableAutomatchSlots()
    {
      return GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_AutomatchingSlotsAvailable(this.SelfPtr());
    }

    internal ulong CreationTime() => GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_CreationTime(this.SelfPtr());

    internal IEnumerable<MultiplayerParticipant> Participants()
    {
      return PInvokeUtilities.ToEnumerable<MultiplayerParticipant>(GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_Participants_Length(this.SelfPtr()), (Func<UIntPtr, MultiplayerParticipant>) (index => new MultiplayerParticipant(GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_Participants_GetElement(this.SelfPtr(), index))));
    }

    internal uint Version() => GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_Version(this.SelfPtr());

    internal uint Variant() => GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_Variant(this.SelfPtr());

    internal ParticipantResults Results()
    {
      return new ParticipantResults(GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_ParticipantResults(this.SelfPtr()));
    }

    internal MultiplayerParticipant ParticipantWithId(string participantId)
    {
      foreach (MultiplayerParticipant participant in this.Participants())
      {
        if (participant.Id().Equals(participantId))
          return participant;
        participant.Dispose();
      }
      return (MultiplayerParticipant) null;
    }

    internal MultiplayerParticipant PendingParticipant()
    {
      MultiplayerParticipant multiplayerParticipant = new MultiplayerParticipant(GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_PendingParticipant(this.SelfPtr()));
      if (multiplayerParticipant.Valid())
        return multiplayerParticipant;
      multiplayerParticipant.Dispose();
      return (MultiplayerParticipant) null;
    }

    internal Types.MatchStatus MatchStatus()
    {
      return GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_Status(this.SelfPtr());
    }

    internal string Description()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, size) => GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_Description(this.SelfPtr(), out_string, size)));
    }

    internal bool HasRematchId()
    {
      string str = this.RematchId();
      return string.IsNullOrEmpty(str) || !str.Equals("(null)");
    }

    internal string RematchId()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, size) => GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_RematchId(this.SelfPtr(), out_string, size)));
    }

    internal byte[] Data()
    {
      if (GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_HasData(this.SelfPtr()))
        return PInvokeUtilities.OutParamsToArray<byte>((PInvokeUtilities.OutMethod<byte>) ((bytes, size) => GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_Data(this.SelfPtr(), bytes, size)));
      Logger.d("Match has no data.");
      return (byte[]) null;
    }

    internal string Id()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, size) => GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_Id(this.SelfPtr(), out_string, size)));
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      GooglePlayGames.Native.Cwrapper.TurnBasedMatch.TurnBasedMatch_Dispose(selfPointer);
    }

    internal GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch AsTurnBasedMatch(
      string selfPlayerId)
    {
      List<Participant> participants = new List<Participant>();
      string selfParticipantId = (string) null;
      string pendingParticipantId = (string) null;
      using (MultiplayerParticipant multiplayerParticipant = this.PendingParticipant())
      {
        if (multiplayerParticipant != null)
          pendingParticipantId = multiplayerParticipant.Id();
      }
      foreach (MultiplayerParticipant participant in this.Participants())
      {
        using (participant)
        {
          using (NativePlayer nativePlayer = participant.Player())
          {
            if (nativePlayer != null)
            {
              if (nativePlayer.Id().Equals(selfPlayerId))
                selfParticipantId = participant.Id();
            }
          }
          participants.Add(participant.AsParticipant());
        }
      }
      bool canRematch = this.MatchStatus() == Types.MatchStatus.COMPLETED && !this.HasRematchId();
      return new GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch(this.Id(), this.Data(), canRematch, selfParticipantId, participants, this.AvailableAutomatchSlots(), pendingParticipantId, NativeTurnBasedMatch.ToTurnStatus(this.MatchStatus()), NativeTurnBasedMatch.ToMatchStatus(pendingParticipantId, this.MatchStatus()), this.Variant(), this.Version());
    }

    private static GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchTurnStatus ToTurnStatus(
      Types.MatchStatus status)
    {
      switch (status)
      {
        case Types.MatchStatus.INVITED:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchTurnStatus.Invited;
        case Types.MatchStatus.THEIR_TURN:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchTurnStatus.TheirTurn;
        case Types.MatchStatus.MY_TURN:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchTurnStatus.MyTurn;
        case Types.MatchStatus.PENDING_COMPLETION:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchTurnStatus.Complete;
        case Types.MatchStatus.COMPLETED:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchTurnStatus.Complete;
        case Types.MatchStatus.CANCELED:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchTurnStatus.Complete;
        case Types.MatchStatus.EXPIRED:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchTurnStatus.Complete;
        default:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchTurnStatus.Unknown;
      }
    }

    private static GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchStatus ToMatchStatus(
      string pendingParticipantId,
      Types.MatchStatus status)
    {
      switch (status)
      {
        case Types.MatchStatus.INVITED:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchStatus.Active;
        case Types.MatchStatus.THEIR_TURN:
          return pendingParticipantId == null ? GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchStatus.AutoMatching : GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchStatus.Active;
        case Types.MatchStatus.MY_TURN:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchStatus.Active;
        case Types.MatchStatus.PENDING_COMPLETION:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchStatus.Complete;
        case Types.MatchStatus.COMPLETED:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchStatus.Complete;
        case Types.MatchStatus.CANCELED:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchStatus.Cancelled;
        case Types.MatchStatus.EXPIRED:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchStatus.Expired;
        default:
          return GooglePlayGames.BasicApi.Multiplayer.TurnBasedMatch.MatchStatus.Unknown;
      }
    }

    internal static NativeTurnBasedMatch FromPointer(IntPtr selfPointer)
    {
      return PInvokeUtilities.IsNull(selfPointer) ? (NativeTurnBasedMatch) null : new NativeTurnBasedMatch(selfPointer);
    }
  }
}
