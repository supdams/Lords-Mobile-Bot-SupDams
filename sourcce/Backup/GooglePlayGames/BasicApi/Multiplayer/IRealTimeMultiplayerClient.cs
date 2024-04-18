// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Multiplayer.IRealTimeMultiplayerClient
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace GooglePlayGames.BasicApi.Multiplayer
{
  public interface IRealTimeMultiplayerClient
  {
    void CreateQuickGame(
      uint minOpponents,
      uint maxOpponents,
      uint variant,
      RealTimeMultiplayerListener listener);

    void CreateQuickGame(
      uint minOpponents,
      uint maxOpponents,
      uint variant,
      ulong exclusiveBitMask,
      RealTimeMultiplayerListener listener);

    void CreateWithInvitationScreen(
      uint minOpponents,
      uint maxOppponents,
      uint variant,
      RealTimeMultiplayerListener listener);

    void ShowWaitingRoomUI();

    void GetAllInvitations(Action<Invitation[]> callback);

    void AcceptFromInbox(RealTimeMultiplayerListener listener);

    void AcceptInvitation(string invitationId, RealTimeMultiplayerListener listener);

    void SendMessageToAll(bool reliable, byte[] data);

    void SendMessageToAll(bool reliable, byte[] data, int offset, int length);

    void SendMessage(bool reliable, string participantId, byte[] data);

    void SendMessage(bool reliable, string participantId, byte[] data, int offset, int length);

    List<Participant> GetConnectedParticipants();

    Participant GetSelf();

    Participant GetParticipant(string participantId);

    Invitation GetInvitation();

    void LeaveRoom();

    bool IsRoomConnected();

    void DeclineInvitation(string invitationId);
  }
}
