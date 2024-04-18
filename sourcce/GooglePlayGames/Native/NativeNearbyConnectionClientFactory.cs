// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.NativeNearbyConnectionClientFactory
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.Android;
using GooglePlayGames.BasicApi.Nearby;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.Native.PInvoke;
using GooglePlayGames.OurUtils;
using System;
using UnityEngine;

#nullable disable
namespace GooglePlayGames.Native
{
  public class NativeNearbyConnectionClientFactory
  {
    private static volatile NearbyConnectionsManager sManager;
    private static Action<INearbyConnectionClient> sCreationCallback;

    internal static NearbyConnectionsManager GetManager()
    {
      return NativeNearbyConnectionClientFactory.sManager;
    }

    public static void Create(Action<INearbyConnectionClient> callback)
    {
      if (NativeNearbyConnectionClientFactory.sManager == null)
      {
        NativeNearbyConnectionClientFactory.sCreationCallback = callback;
        NativeNearbyConnectionClientFactory.InitializeFactory();
      }
      else
        callback((INearbyConnectionClient) new NativeNearbyConnectionsClient(NativeNearbyConnectionClientFactory.GetManager()));
    }

    internal static void InitializeFactory()
    {
      PlayGamesHelperObject.CreateObject();
      NearbyConnectionsManager.ReadServiceId();
      NearbyConnectionsManagerBuilder connectionsManagerBuilder = new NearbyConnectionsManagerBuilder();
      connectionsManagerBuilder.SetOnInitializationFinished(new Action<NearbyConnectionsStatus.InitializationStatus>(NativeNearbyConnectionClientFactory.OnManagerInitialized));
      PlatformConfiguration platformConfiguration = new AndroidClient().CreatePlatformConfiguration();
      Debug.Log((object) "Building manager Now");
      NativeNearbyConnectionClientFactory.sManager = connectionsManagerBuilder.Build(platformConfiguration);
    }

    internal static void OnManagerInitialized(
      NearbyConnectionsStatus.InitializationStatus status)
    {
      Debug.Log((object) ("Nearby Init Complete: " + (object) status + " sManager = " + (object) NativeNearbyConnectionClientFactory.sManager));
      if (status == NearbyConnectionsStatus.InitializationStatus.VALID)
      {
        if (NativeNearbyConnectionClientFactory.sCreationCallback == null)
          return;
        NativeNearbyConnectionClientFactory.sCreationCallback((INearbyConnectionClient) new NativeNearbyConnectionsClient(NativeNearbyConnectionClientFactory.GetManager()));
        NativeNearbyConnectionClientFactory.sCreationCallback = (Action<INearbyConnectionClient>) null;
      }
      else
        Debug.LogError((object) ("ERROR: NearbyConnectionManager not initialized: " + (object) status));
    }
  }
}
