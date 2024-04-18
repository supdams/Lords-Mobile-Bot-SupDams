// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.NearbyConnectionsManagerBuilder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using AOT;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class NearbyConnectionsManagerBuilder : BaseReferenceHolder
  {
    internal NearbyConnectionsManagerBuilder()
      : base(NearbyConnectionsBuilder.NearbyConnections_Builder_Construct())
    {
    }

    internal NearbyConnectionsManagerBuilder SetOnInitializationFinished(
      Action<NearbyConnectionsStatus.InitializationStatus> callback)
    {
      NearbyConnectionsBuilder.NearbyConnections_Builder_SetOnInitializationFinished(this.SelfPtr(), new NearbyConnectionsBuilder.OnInitializationFinishedCallback(NearbyConnectionsManagerBuilder.InternalOnInitializationFinishedCallback), Callbacks.ToIntPtr((Delegate) callback));
      return this;
    }

    [MonoPInvokeCallback(typeof (NearbyConnectionsBuilder.OnInitializationFinishedCallback))]
    private static void InternalOnInitializationFinishedCallback(
      NearbyConnectionsStatus.InitializationStatus status,
      IntPtr userData)
    {
      Action<NearbyConnectionsStatus.InitializationStatus> permanentCallback = Callbacks.IntPtrToPermanentCallback<Action<NearbyConnectionsStatus.InitializationStatus>>(userData);
      if (permanentCallback == null)
      {
        Logger.w("Callback for Initialization is null. Received status: " + (object) status);
      }
      else
      {
        try
        {
          permanentCallback(status);
        }
        catch (Exception ex)
        {
          Logger.e("Error encountered executing NearbyConnectionsManagerBuilder#InternalOnInitializationFinishedCallback. Smothering exception: " + (object) ex);
        }
      }
    }

    internal NearbyConnectionsManagerBuilder SetLocalClientId(long localClientId)
    {
      NearbyConnectionsBuilder.NearbyConnections_Builder_SetClientId(this.SelfPtr(), localClientId);
      return this;
    }

    internal NearbyConnectionsManagerBuilder SetDefaultLogLevel(Types.LogLevel minLevel)
    {
      NearbyConnectionsBuilder.NearbyConnections_Builder_SetDefaultOnLog(this.SelfPtr(), minLevel);
      return this;
    }

    internal NearbyConnectionsManager Build(PlatformConfiguration configuration)
    {
      return new NearbyConnectionsManager(NearbyConnectionsBuilder.NearbyConnections_Builder_Create(this.SelfPtr(), configuration.AsPointer()));
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      NearbyConnectionsBuilder.NearbyConnections_Builder_Dispose(selfPointer);
    }
  }
}
