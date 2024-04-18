﻿// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.PlayerManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using AOT;
using GooglePlayGames.Native.Cwrapper;
using GooglePlayGames.OurUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class PlayerManager
  {
    private readonly GameServices mGameServices;

    internal PlayerManager(GameServices services)
    {
      this.mGameServices = Misc.CheckNotNull<GameServices>(services);
    }

    internal void FetchSelf(Action<PlayerManager.FetchSelfResponse> callback)
    {
      GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchSelf(this.mGameServices.AsHandle(), Types.DataSource.CACHE_OR_NETWORK, new GooglePlayGames.Native.Cwrapper.PlayerManager.FetchSelfCallback(PlayerManager.InternalFetchSelfCallback), Callbacks.ToIntPtr<PlayerManager.FetchSelfResponse>(callback, new Func<IntPtr, PlayerManager.FetchSelfResponse>(PlayerManager.FetchSelfResponse.FromPointer)));
    }

    [MonoPInvokeCallback(typeof (GooglePlayGames.Native.Cwrapper.PlayerManager.FetchSelfCallback))]
    private static void InternalFetchSelfCallback(IntPtr response, IntPtr data)
    {
      Callbacks.PerformInternalCallback("PlayerManager#InternalFetchSelfCallback", Callbacks.Type.Temporary, response, data);
    }

    internal void FetchList(string[] userIds, Action<NativePlayer[]> callback)
    {
      PlayerManager.FetchResponseCollector coll = new PlayerManager.FetchResponseCollector();
      coll.pendingCount = userIds.Length;
      coll.callback = callback;
      foreach (string userId in userIds)
        GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_Fetch(this.mGameServices.AsHandle(), Types.DataSource.CACHE_OR_NETWORK, userId, new GooglePlayGames.Native.Cwrapper.PlayerManager.FetchCallback(PlayerManager.InternalFetchCallback), Callbacks.ToIntPtr<PlayerManager.FetchResponse>((Action<PlayerManager.FetchResponse>) (rsp => this.HandleFetchResponse(coll, rsp)), new Func<IntPtr, PlayerManager.FetchResponse>(PlayerManager.FetchResponse.FromPointer)));
    }

    [MonoPInvokeCallback(typeof (GooglePlayGames.Native.Cwrapper.PlayerManager.FetchCallback))]
    private static void InternalFetchCallback(IntPtr response, IntPtr data)
    {
      Callbacks.PerformInternalCallback("PlayerManager#InternalFetchCallback", Callbacks.Type.Temporary, response, data);
    }

    internal void HandleFetchResponse(
      PlayerManager.FetchResponseCollector collector,
      PlayerManager.FetchResponse resp)
    {
      if (resp.Status() == CommonErrorStatus.ResponseStatus.VALID || resp.Status() == CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
      {
        NativePlayer player = resp.GetPlayer();
        collector.results.Add(player);
      }
      --collector.pendingCount;
      if (collector.pendingCount != 0)
        return;
      collector.callback(collector.results.ToArray());
    }

    internal void FetchFriends(Action<GooglePlayGames.BasicApi.ResponseStatus, List<GooglePlayGames.BasicApi.Multiplayer.Player>> callback)
    {
      GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchConnected(this.mGameServices.AsHandle(), Types.DataSource.CACHE_OR_NETWORK, new GooglePlayGames.Native.Cwrapper.PlayerManager.FetchListCallback(PlayerManager.InternalFetchConnectedCallback), Callbacks.ToIntPtr<PlayerManager.FetchListResponse>((Action<PlayerManager.FetchListResponse>) (rsp => this.HandleFetchCollected(rsp, callback)), new Func<IntPtr, PlayerManager.FetchListResponse>(PlayerManager.FetchListResponse.FromPointer)));
    }

    [MonoPInvokeCallback(typeof (GooglePlayGames.Native.Cwrapper.PlayerManager.FetchListCallback))]
    private static void InternalFetchConnectedCallback(IntPtr response, IntPtr data)
    {
      Callbacks.PerformInternalCallback("PlayerManager#InternalFetchConnectedCallback", Callbacks.Type.Temporary, response, data);
    }

    internal void HandleFetchCollected(
      PlayerManager.FetchListResponse rsp,
      Action<GooglePlayGames.BasicApi.ResponseStatus, List<GooglePlayGames.BasicApi.Multiplayer.Player>> callback)
    {
      List<GooglePlayGames.BasicApi.Multiplayer.Player> playerList = new List<GooglePlayGames.BasicApi.Multiplayer.Player>();
      if (rsp.Status() == CommonErrorStatus.ResponseStatus.VALID || rsp.Status() == CommonErrorStatus.ResponseStatus.VALID_BUT_STALE)
      {
        Logger.d("Got " + (object) rsp.Length().ToUInt64() + " players");
        foreach (NativePlayer nativePlayer in rsp)
          playerList.Add(nativePlayer.AsPlayer());
      }
      callback((GooglePlayGames.BasicApi.ResponseStatus) rsp.Status(), playerList);
    }

    internal class FetchListResponse : BaseReferenceHolder, IEnumerable, IEnumerable<NativePlayer>
    {
      internal FetchListResponse(IntPtr selfPointer)
        : base(selfPointer)
      {
      }

      IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

      protected override void CallDispose(HandleRef selfPointer)
      {
        GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchListResponse_Dispose(this.SelfPtr());
      }

      internal CommonErrorStatus.ResponseStatus Status()
      {
        return GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchListResponse_GetStatus(this.SelfPtr());
      }

      public IEnumerator<NativePlayer> GetEnumerator()
      {
        return PInvokeUtilities.ToEnumerator<NativePlayer>(this.Length(), (Func<UIntPtr, NativePlayer>) (index => this.GetElement(index)));
      }

      internal UIntPtr Length()
      {
        return GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchListResponse_GetData_Length(this.SelfPtr());
      }

      internal NativePlayer GetElement(UIntPtr index)
      {
        return index.ToUInt64() < this.Length().ToUInt64() ? new NativePlayer(GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchListResponse_GetData_GetElement(this.SelfPtr(), index)) : throw new ArgumentOutOfRangeException();
      }

      internal static PlayerManager.FetchListResponse FromPointer(IntPtr selfPointer)
      {
        return PInvokeUtilities.IsNull(selfPointer) ? (PlayerManager.FetchListResponse) null : new PlayerManager.FetchListResponse(selfPointer);
      }
    }

    internal class FetchResponseCollector
    {
      internal int pendingCount;
      internal List<NativePlayer> results = new List<NativePlayer>();
      internal Action<NativePlayer[]> callback;
    }

    internal class FetchResponse : BaseReferenceHolder
    {
      internal FetchResponse(IntPtr selfPointer)
        : base(selfPointer)
      {
      }

      protected override void CallDispose(HandleRef selfPointer)
      {
        GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchResponse_Dispose(this.SelfPtr());
      }

      internal NativePlayer GetPlayer()
      {
        return new NativePlayer(GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchResponse_GetData(this.SelfPtr()));
      }

      internal CommonErrorStatus.ResponseStatus Status()
      {
        return GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchResponse_GetStatus(this.SelfPtr());
      }

      internal static PlayerManager.FetchResponse FromPointer(IntPtr selfPointer)
      {
        return PInvokeUtilities.IsNull(selfPointer) ? (PlayerManager.FetchResponse) null : new PlayerManager.FetchResponse(selfPointer);
      }
    }

    internal class FetchSelfResponse : BaseReferenceHolder
    {
      internal FetchSelfResponse(IntPtr selfPointer)
        : base(selfPointer)
      {
      }

      internal CommonErrorStatus.ResponseStatus Status()
      {
        return GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchSelfResponse_GetStatus(this.SelfPtr());
      }

      internal NativePlayer Self()
      {
        return new NativePlayer(GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchSelfResponse_GetData(this.SelfPtr()));
      }

      protected override void CallDispose(HandleRef selfPointer)
      {
        GooglePlayGames.Native.Cwrapper.PlayerManager.PlayerManager_FetchSelfResponse_Dispose(this.SelfPtr());
      }

      internal static PlayerManager.FetchSelfResponse FromPointer(IntPtr selfPointer)
      {
        return PInvokeUtilities.IsNull(selfPointer) ? (PlayerManager.FetchSelfResponse) null : new PlayerManager.FetchSelfResponse(selfPointer);
      }
    }
  }
}
