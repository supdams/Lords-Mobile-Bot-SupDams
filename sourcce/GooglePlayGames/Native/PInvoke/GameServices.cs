// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.GameServices
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
  internal class GameServices : BaseReferenceHolder
  {
    internal GameServices(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    internal bool IsAuthenticated() => GooglePlayGames.Native.Cwrapper.GameServices.GameServices_IsAuthorized(this.SelfPtr());

    internal void SignOut() => GooglePlayGames.Native.Cwrapper.GameServices.GameServices_SignOut(this.SelfPtr());

    internal void StartAuthorizationUI()
    {
      GooglePlayGames.Native.Cwrapper.GameServices.GameServices_StartAuthorizationUI(this.SelfPtr());
    }

    public GooglePlayGames.Native.PInvoke.AchievementManager AchievementManager()
    {
      return new GooglePlayGames.Native.PInvoke.AchievementManager(this);
    }

    public GooglePlayGames.Native.PInvoke.LeaderboardManager LeaderboardManager()
    {
      return new GooglePlayGames.Native.PInvoke.LeaderboardManager(this);
    }

    public GooglePlayGames.Native.PInvoke.PlayerManager PlayerManager() => new GooglePlayGames.Native.PInvoke.PlayerManager(this);

    public GooglePlayGames.Native.PInvoke.StatsManager StatsManager() => new GooglePlayGames.Native.PInvoke.StatsManager(this);

    internal HandleRef AsHandle() => this.SelfPtr();

    protected override void CallDispose(HandleRef selfPointer)
    {
      GooglePlayGames.Native.Cwrapper.GameServices.GameServices_Dispose(selfPointer);
    }

    internal void FetchServerAuthCode(
      string server_client_id,
      Action<GameServices.FetchServerAuthCodeResponse> callback)
    {
      Misc.CheckNotNull<Action<GameServices.FetchServerAuthCodeResponse>>(callback);
      Misc.CheckNotNull<string>(server_client_id);
      GooglePlayGames.Native.Cwrapper.GameServices.GameServices_FetchServerAuthCode(this.AsHandle(), server_client_id, new GooglePlayGames.Native.Cwrapper.GameServices.FetchServerAuthCodeCallback(GameServices.InternalFetchServerAuthCodeCallback), Callbacks.ToIntPtr<GameServices.FetchServerAuthCodeResponse>(callback, new Func<IntPtr, GameServices.FetchServerAuthCodeResponse>(GameServices.FetchServerAuthCodeResponse.FromPointer)));
    }

    [MonoPInvokeCallback(typeof (GooglePlayGames.Native.Cwrapper.GameServices.FetchServerAuthCodeCallback))]
    private static void InternalFetchServerAuthCodeCallback(IntPtr response, IntPtr data)
    {
      Callbacks.PerformInternalCallback("GameServices#InternalFetchServerAuthCodeCallback", Callbacks.Type.Temporary, response, data);
    }

    internal class FetchServerAuthCodeResponse : BaseReferenceHolder
    {
      internal FetchServerAuthCodeResponse(IntPtr selfPointer)
        : base(selfPointer)
      {
      }

      internal CommonErrorStatus.ResponseStatus Status()
      {
        return GooglePlayGames.Native.Cwrapper.GameServices.GameServices_FetchServerAuthCodeResponse_GetStatus(this.SelfPtr());
      }

      internal string Code()
      {
        return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => GooglePlayGames.Native.Cwrapper.GameServices.GameServices_FetchServerAuthCodeResponse_GetCode(this.SelfPtr(), out_string, out_size)));
      }

      protected override void CallDispose(HandleRef selfPointer)
      {
        GooglePlayGames.Native.Cwrapper.GameServices.GameServices_FetchServerAuthCodeResponse_Dispose(selfPointer);
      }

      internal static GameServices.FetchServerAuthCodeResponse FromPointer(IntPtr pointer)
      {
        return pointer.Equals((object) IntPtr.Zero) ? (GameServices.FetchServerAuthCodeResponse) null : new GameServices.FetchServerAuthCodeResponse(pointer);
      }
    }
  }
}
