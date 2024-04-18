﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.MultiplayerParticipant
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.Native.Cwrapper;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class MultiplayerParticipant : BaseReferenceHolder
  {
    private static readonly Dictionary<Types.ParticipantStatus, Participant.ParticipantStatus> StatusConversion = new Dictionary<Types.ParticipantStatus, Participant.ParticipantStatus>()
    {
      {
        Types.ParticipantStatus.INVITED,
        Participant.ParticipantStatus.Invited
      },
      {
        Types.ParticipantStatus.JOINED,
        Participant.ParticipantStatus.Joined
      },
      {
        Types.ParticipantStatus.DECLINED,
        Participant.ParticipantStatus.Declined
      },
      {
        Types.ParticipantStatus.LEFT,
        Participant.ParticipantStatus.Left
      },
      {
        Types.ParticipantStatus.NOT_INVITED_YET,
        Participant.ParticipantStatus.NotInvitedYet
      },
      {
        Types.ParticipantStatus.FINISHED,
        Participant.ParticipantStatus.Finished
      },
      {
        Types.ParticipantStatus.UNRESPONSIVE,
        Participant.ParticipantStatus.Unresponsive
      }
    };

    internal MultiplayerParticipant(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    internal Types.ParticipantStatus Status()
    {
      return GooglePlayGames.Native.Cwrapper.MultiplayerParticipant.MultiplayerParticipant_Status(this.SelfPtr());
    }

    internal bool IsConnectedToRoom() => this.Status() == Types.ParticipantStatus.JOINED;

    internal string DisplayName()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, size) => GooglePlayGames.Native.Cwrapper.MultiplayerParticipant.MultiplayerParticipant_DisplayName(this.SelfPtr(), out_string, size)));
    }

    internal NativePlayer Player()
    {
      return !GooglePlayGames.Native.Cwrapper.MultiplayerParticipant.MultiplayerParticipant_HasPlayer(this.SelfPtr()) ? (NativePlayer) null : new NativePlayer(GooglePlayGames.Native.Cwrapper.MultiplayerParticipant.MultiplayerParticipant_Player(this.SelfPtr()));
    }

    internal string Id()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, size) => GooglePlayGames.Native.Cwrapper.MultiplayerParticipant.MultiplayerParticipant_Id(this.SelfPtr(), out_string, size)));
    }

    internal bool Valid() => GooglePlayGames.Native.Cwrapper.MultiplayerParticipant.MultiplayerParticipant_Valid(this.SelfPtr());

    protected override void CallDispose(HandleRef selfPointer)
    {
      GooglePlayGames.Native.Cwrapper.MultiplayerParticipant.MultiplayerParticipant_Dispose(selfPointer);
    }

    internal Participant AsParticipant()
    {
      NativePlayer nativePlayer = this.Player();
      return new Participant(this.DisplayName(), this.Id(), MultiplayerParticipant.StatusConversion[this.Status()], nativePlayer?.AsPlayer(), this.IsConnectedToRoom());
    }

    internal static MultiplayerParticipant FromPointer(IntPtr pointer)
    {
      return PInvokeUtilities.IsNull(pointer) ? (MultiplayerParticipant) null : new MultiplayerParticipant(pointer);
    }

    internal static MultiplayerParticipant AutomatchingSentinel()
    {
      return new MultiplayerParticipant(Sentinels.Sentinels_AutomatchingParticipant());
    }
  }
}
