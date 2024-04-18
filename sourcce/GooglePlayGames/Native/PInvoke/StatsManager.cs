// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.StatsManager
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
  internal class StatsManager
  {
    private readonly GameServices mServices;

    internal StatsManager(GameServices services)
    {
      this.mServices = Misc.CheckNotNull<GameServices>(services);
    }

    internal void FetchForPlayer(
      Action<StatsManager.FetchForPlayerResponse> callback)
    {
      Misc.CheckNotNull<Action<StatsManager.FetchForPlayerResponse>>(callback);
      GooglePlayGames.Native.Cwrapper.StatsManager.StatsManager_FetchForPlayer(this.mServices.AsHandle(), Types.DataSource.CACHE_OR_NETWORK, new GooglePlayGames.Native.Cwrapper.StatsManager.FetchForPlayerCallback(StatsManager.InternalFetchForPlayerCallback), Callbacks.ToIntPtr<StatsManager.FetchForPlayerResponse>(callback, new Func<IntPtr, StatsManager.FetchForPlayerResponse>(StatsManager.FetchForPlayerResponse.FromPointer)));
    }

    [MonoPInvokeCallback(typeof (GooglePlayGames.Native.Cwrapper.StatsManager.FetchForPlayerCallback))]
    private static void InternalFetchForPlayerCallback(IntPtr response, IntPtr data)
    {
      Callbacks.PerformInternalCallback("StatsManager#InternalFetchForPlayerCallback", Callbacks.Type.Temporary, response, data);
    }

    internal class FetchForPlayerResponse : BaseReferenceHolder
    {
      internal FetchForPlayerResponse(IntPtr selfPointer)
        : base(selfPointer)
      {
      }

      internal CommonErrorStatus.ResponseStatus Status()
      {
        return GooglePlayGames.Native.Cwrapper.StatsManager.StatsManager_FetchForPlayerResponse_GetStatus(this.SelfPtr());
      }

      internal NativePlayerStats PlayerStats()
      {
        return new NativePlayerStats(GooglePlayGames.Native.Cwrapper.StatsManager.StatsManager_FetchForPlayerResponse_GetData(this.SelfPtr()));
      }

      protected override void CallDispose(HandleRef selfPointer)
      {
        GooglePlayGames.Native.Cwrapper.StatsManager.StatsManager_FetchForPlayerResponse_Dispose(selfPointer);
      }

      internal static StatsManager.FetchForPlayerResponse FromPointer(IntPtr pointer)
      {
        return pointer.Equals((object) IntPtr.Zero) ? (StatsManager.FetchForPlayerResponse) null : new StatsManager.FetchForPlayerResponse(pointer);
      }
    }
  }
}
