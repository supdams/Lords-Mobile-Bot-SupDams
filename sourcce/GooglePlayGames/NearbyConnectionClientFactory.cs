// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.NearbyConnectionClientFactory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.BasicApi.Nearby;
using GooglePlayGames.Native;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;
using System;
using UnityEngine;

#nullable disable
namespace GooglePlayGames
{
  public static class NearbyConnectionClientFactory
  {
    public static void Create(Action<INearbyConnectionClient> callback)
    {
      if (Application.isEditor)
      {
        Logger.d("Creating INearbyConnection in editor, using DummyClient.");
        callback((INearbyConnectionClient) new DummyNearbyConnectionClient());
      }
      Logger.d("Creating real INearbyConnectionClient");
      NativeNearbyConnectionClientFactory.Create(callback);
    }

    private static GooglePlayGames.BasicApi.Nearby.InitializationStatus ToStatus(
      NearbyConnectionsStatus.InitializationStatus status)
    {
      switch (status + 4)
      {
        case ~(NearbyConnectionsStatus.InitializationStatus.ERROR_INTERNAL | NearbyConnectionsStatus.InitializationStatus.VALID):
          return GooglePlayGames.BasicApi.Nearby.InitializationStatus.VersionUpdateRequired;
        case ~(NearbyConnectionsStatus.InitializationStatus.ERROR_VERSION_UPDATE_REQUIRED | NearbyConnectionsStatus.InitializationStatus.VALID):
          return GooglePlayGames.BasicApi.Nearby.InitializationStatus.InternalError;
        case (NearbyConnectionsStatus.InitializationStatus) 5:
          return GooglePlayGames.BasicApi.Nearby.InitializationStatus.Success;
        default:
          Logger.w("Unknown initialization status: " + (object) status);
          return GooglePlayGames.BasicApi.Nearby.InitializationStatus.InternalError;
      }
    }
  }
}
