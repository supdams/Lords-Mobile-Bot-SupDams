// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Nearby.IMessageListener
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
namespace GooglePlayGames.BasicApi.Nearby
{
  public interface IMessageListener
  {
    void OnMessageReceived(string remoteEndpointId, byte[] data, bool isReliableMessage);

    void OnRemoteEndpointDisconnected(string remoteEndpointId);
  }
}
