// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.PlayGamesLocalUser
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.BasicApi;
using System;
using UnityEngine.SocialPlatforms;

#nullable disable
namespace GooglePlayGames
{
  public class PlayGamesLocalUser : PlayGamesUserProfile, IUserProfile, ILocalUser
  {
    internal PlayGamesPlatform mPlatform;
    private string emailAddress;
    private PlayerStats mStats;

    internal PlayGamesLocalUser(PlayGamesPlatform plaf)
      : base("localUser", string.Empty, string.Empty)
    {
      this.mPlatform = plaf;
      this.emailAddress = (string) null;
      this.mStats = (PlayerStats) null;
    }

    public void Authenticate(Action<bool> callback) => this.mPlatform.Authenticate(callback);

    public void Authenticate(Action<bool> callback, bool silent)
    {
      this.mPlatform.Authenticate(callback, silent);
    }

    public void LoadFriends(Action<bool> callback)
    {
      this.mPlatform.LoadFriends((ILocalUser) this, callback);
    }

    public IUserProfile[] friends => this.mPlatform.GetFriends();

    [Obsolete("Use PlayGamesPlatform.GetServerAuthCode()")]
    public void GetIdToken(Action<string> idTokenCallback)
    {
      if (this.authenticated)
        this.mPlatform.GetIdToken(idTokenCallback);
      else
        idTokenCallback((string) null);
    }

    public bool authenticated => this.mPlatform.IsAuthenticated();

    public bool underage => true;

    public new string userName
    {
      get
      {
        string displayName = string.Empty;
        if (this.authenticated)
        {
          displayName = this.mPlatform.GetUserDisplayName();
          if (!base.userName.Equals(displayName))
            this.ResetIdentity(displayName, this.mPlatform.GetUserId(), this.mPlatform.GetUserImageUrl());
        }
        return displayName;
      }
    }

    public new string id
    {
      get
      {
        string playerId = string.Empty;
        if (this.authenticated)
        {
          playerId = this.mPlatform.GetUserId();
          if (!base.id.Equals(playerId))
            this.ResetIdentity(this.mPlatform.GetUserDisplayName(), playerId, this.mPlatform.GetUserImageUrl());
        }
        return playerId;
      }
    }

    [Obsolete("Use PlayGamesPlatform.GetServerAuthCode()")]
    public string accessToken
    {
      get => this.authenticated ? this.mPlatform.GetAccessToken() : string.Empty;
    }

    public new bool isFriend => true;

    public new UserState state => UserState.Online;

    public new string AvatarURL
    {
      get
      {
        string avatarUrl = string.Empty;
        if (this.authenticated)
        {
          avatarUrl = this.mPlatform.GetUserImageUrl();
          if (!base.id.Equals(avatarUrl))
            this.ResetIdentity(this.mPlatform.GetUserDisplayName(), this.mPlatform.GetUserId(), avatarUrl);
        }
        return avatarUrl;
      }
    }

    public string Email
    {
      get
      {
        if (this.authenticated && string.IsNullOrEmpty(this.emailAddress))
        {
          this.emailAddress = this.mPlatform.GetUserEmail();
          this.emailAddress = this.emailAddress ?? string.Empty;
        }
        return this.authenticated ? this.emailAddress : string.Empty;
      }
    }

    public void GetStats(Action<CommonStatusCodes, PlayerStats> callback)
    {
      if (this.mStats == null || !this.mStats.Valid)
        this.mPlatform.GetPlayerStats((Action<CommonStatusCodes, PlayerStats>) ((rc, stats) =>
        {
          this.mStats = stats;
          callback(rc, stats);
        }));
      else
        callback(CommonStatusCodes.Success, this.mStats);
    }
  }
}
