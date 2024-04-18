// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.PlayGamesClientFactory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.Android;
using GooglePlayGames.BasicApi;
using GooglePlayGames.Native;
using GooglePlayGames.OurUtils;
using UnityEngine;

#nullable disable
namespace GooglePlayGames
{
  internal class PlayGamesClientFactory
  {
    internal static IPlayGamesClient GetPlatformPlayGamesClient(PlayGamesClientConfiguration config)
    {
      if (Application.isEditor)
      {
        Logger.d("Creating IPlayGamesClient in editor, using DummyClient.");
        return (IPlayGamesClient) new DummyClient();
      }
      Logger.d("Creating Android IPlayGamesClient Client");
      return (IPlayGamesClient) new NativeClient(config, (IClientImpl) new AndroidClient());
    }
  }
}
