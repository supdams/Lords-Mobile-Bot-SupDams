// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.GameServicesBuilder
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
  internal class GameServicesBuilder : BaseReferenceHolder
  {
    private GameServicesBuilder(IntPtr selfPointer)
      : base(selfPointer)
    {
      InternalHooks.InternalHooks_ConfigureForUnityPlugin(this.SelfPtr());
    }

    internal void SetOnAuthFinishedCallback(GameServicesBuilder.AuthFinishedCallback callback)
    {
      GooglePlayGames.Native.Cwrapper.Builder.GameServices_Builder_SetOnAuthActionFinished(this.SelfPtr(), new GooglePlayGames.Native.Cwrapper.Builder.OnAuthActionFinishedCallback(GameServicesBuilder.InternalAuthFinishedCallback), Callbacks.ToIntPtr((Delegate) callback));
    }

    internal void EnableSnapshots() => GooglePlayGames.Native.Cwrapper.Builder.GameServices_Builder_EnableSnapshots(this.SelfPtr());

    internal void RequireGooglePlus()
    {
      GooglePlayGames.Native.Cwrapper.Builder.GameServices_Builder_RequireGooglePlus(this.SelfPtr());
    }

    internal void AddOauthScope(string scope)
    {
      GooglePlayGames.Native.Cwrapper.Builder.GameServices_Builder_AddOauthScope(this.SelfPtr(), scope);
    }

    [MonoPInvokeCallback(typeof (GooglePlayGames.Native.Cwrapper.Builder.OnAuthActionFinishedCallback))]
    private static void InternalAuthFinishedCallback(
      Types.AuthOperation op,
      CommonErrorStatus.AuthStatus status,
      IntPtr data)
    {
      GameServicesBuilder.AuthFinishedCallback permanentCallback = Callbacks.IntPtrToPermanentCallback<GameServicesBuilder.AuthFinishedCallback>(data);
      if (permanentCallback == null)
        return;
      try
      {
        permanentCallback(op, status);
      }
      catch (Exception ex)
      {
        Logger.e("Error encountered executing InternalAuthFinishedCallback. Smothering to avoid passing exception into Native: " + (object) ex);
      }
    }

    internal void SetOnAuthStartedCallback(GameServicesBuilder.AuthStartedCallback callback)
    {
      GooglePlayGames.Native.Cwrapper.Builder.GameServices_Builder_SetOnAuthActionStarted(this.SelfPtr(), new GooglePlayGames.Native.Cwrapper.Builder.OnAuthActionStartedCallback(GameServicesBuilder.InternalAuthStartedCallback), Callbacks.ToIntPtr((Delegate) callback));
    }

    [MonoPInvokeCallback(typeof (GooglePlayGames.Native.Cwrapper.Builder.OnAuthActionStartedCallback))]
    private static void InternalAuthStartedCallback(Types.AuthOperation op, IntPtr data)
    {
      GameServicesBuilder.AuthStartedCallback permanentCallback = Callbacks.IntPtrToPermanentCallback<GameServicesBuilder.AuthStartedCallback>(data);
      try
      {
        if (permanentCallback == null)
          return;
        permanentCallback(op);
      }
      catch (Exception ex)
      {
        Logger.e("Error encountered executing InternalAuthStartedCallback. Smothering to avoid passing exception into Native: " + (object) ex);
      }
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      GooglePlayGames.Native.Cwrapper.Builder.GameServices_Builder_Dispose(selfPointer);
    }

    [MonoPInvokeCallback(typeof (GooglePlayGames.Native.Cwrapper.Builder.OnTurnBasedMatchEventCallback))]
    private static void InternalOnTurnBasedMatchEventCallback(
      Types.MultiplayerEvent eventType,
      string matchId,
      IntPtr match,
      IntPtr userData)
    {
      Action<Types.MultiplayerEvent, string, NativeTurnBasedMatch> permanentCallback = Callbacks.IntPtrToPermanentCallback<Action<Types.MultiplayerEvent, string, NativeTurnBasedMatch>>(userData);
      using (NativeTurnBasedMatch nativeTurnBasedMatch = NativeTurnBasedMatch.FromPointer(match))
      {
        try
        {
          if (permanentCallback == null)
            return;
          permanentCallback(eventType, matchId, nativeTurnBasedMatch);
        }
        catch (Exception ex)
        {
          Logger.e("Error encountered executing InternalOnTurnBasedMatchEventCallback. Smothering to avoid passing exception into Native: " + (object) ex);
        }
      }
    }

    internal void SetOnTurnBasedMatchEventCallback(
      Action<Types.MultiplayerEvent, string, NativeTurnBasedMatch> callback)
    {
      IntPtr intPtr = Callbacks.ToIntPtr((Delegate) callback);
      GooglePlayGames.Native.Cwrapper.Builder.GameServices_Builder_SetOnTurnBasedMatchEvent(this.SelfPtr(), new GooglePlayGames.Native.Cwrapper.Builder.OnTurnBasedMatchEventCallback(GameServicesBuilder.InternalOnTurnBasedMatchEventCallback), intPtr);
    }

    [MonoPInvokeCallback(typeof (GooglePlayGames.Native.Cwrapper.Builder.OnMultiplayerInvitationEventCallback))]
    private static void InternalOnMultiplayerInvitationEventCallback(
      Types.MultiplayerEvent eventType,
      string matchId,
      IntPtr match,
      IntPtr userData)
    {
      Action<Types.MultiplayerEvent, string, MultiplayerInvitation> permanentCallback = Callbacks.IntPtrToPermanentCallback<Action<Types.MultiplayerEvent, string, MultiplayerInvitation>>(userData);
      using (MultiplayerInvitation multiplayerInvitation = MultiplayerInvitation.FromPointer(match))
      {
        try
        {
          if (permanentCallback == null)
            return;
          permanentCallback(eventType, matchId, multiplayerInvitation);
        }
        catch (Exception ex)
        {
          Logger.e("Error encountered executing InternalOnMultiplayerInvitationEventCallback. Smothering to avoid passing exception into Native: " + (object) ex);
        }
      }
    }

    internal void SetOnMultiplayerInvitationEventCallback(
      Action<Types.MultiplayerEvent, string, MultiplayerInvitation> callback)
    {
      IntPtr intPtr = Callbacks.ToIntPtr((Delegate) callback);
      GooglePlayGames.Native.Cwrapper.Builder.GameServices_Builder_SetOnMultiplayerInvitationEvent(this.SelfPtr(), new GooglePlayGames.Native.Cwrapper.Builder.OnMultiplayerInvitationEventCallback(GameServicesBuilder.InternalOnMultiplayerInvitationEventCallback), intPtr);
    }

    internal GameServices Build(PlatformConfiguration configRef)
    {
      IntPtr selfPointer = GooglePlayGames.Native.Cwrapper.Builder.GameServices_Builder_Create(this.SelfPtr(), HandleRef.ToIntPtr(configRef.AsHandle()));
      return !selfPointer.Equals((object) IntPtr.Zero) ? new GameServices(selfPointer) : throw new InvalidOperationException("There was an error creating a GameServices object. Check for log errors from GamesNativeSDK");
    }

    internal static GameServicesBuilder Create()
    {
      return new GameServicesBuilder(GooglePlayGames.Native.Cwrapper.Builder.GameServices_Builder_Construct());
    }

    internal delegate void AuthFinishedCallback(
      Types.AuthOperation operation,
      CommonErrorStatus.AuthStatus status);

    internal delegate void AuthStartedCallback(Types.AuthOperation operation);
  }
}
