// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Multiplayer.Participant
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
namespace GooglePlayGames.BasicApi.Multiplayer
{
  public class Participant : IComparable<Participant>
  {
    private string mDisplayName = string.Empty;
    private string mParticipantId = string.Empty;
    private Participant.ParticipantStatus mStatus = Participant.ParticipantStatus.Unknown;
    private Player mPlayer;
    private bool mIsConnectedToRoom;

    internal Participant(
      string displayName,
      string participantId,
      Participant.ParticipantStatus status,
      Player player,
      bool connectedToRoom)
    {
      this.mDisplayName = displayName;
      this.mParticipantId = participantId;
      this.mStatus = status;
      this.mPlayer = player;
      this.mIsConnectedToRoom = connectedToRoom;
    }

    public string DisplayName => this.mDisplayName;

    public string ParticipantId => this.mParticipantId;

    public Participant.ParticipantStatus Status => this.mStatus;

    public Player Player => this.mPlayer;

    public bool IsConnectedToRoom => this.mIsConnectedToRoom;

    public bool IsAutomatch => this.mPlayer == null;

    public override string ToString()
    {
      return string.Format("[Participant: '{0}' (id {1}), status={2}, player={3}, connected={4}]", (object) this.mDisplayName, (object) this.mParticipantId, (object) this.mStatus.ToString(), this.mPlayer != null ? (object) this.mPlayer.ToString() : (object) "NULL", (object) this.mIsConnectedToRoom);
    }

    public int CompareTo(Participant other) => this.mParticipantId.CompareTo(other.mParticipantId);

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (object.ReferenceEquals((object) this, obj))
        return true;
      return (object) obj.GetType() == (object) typeof (Participant) && this.mParticipantId.Equals(((Participant) obj).mParticipantId);
    }

    public override int GetHashCode()
    {
      return this.mParticipantId != null ? this.mParticipantId.GetHashCode() : 0;
    }

    public enum ParticipantStatus
    {
      NotInvitedYet,
      Invited,
      Joined,
      Declined,
      Left,
      Finished,
      Unresponsive,
      Unknown,
    }
  }
}
