// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.PlayGamesPlatform
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Events;
using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.BasicApi.Nearby;
using GooglePlayGames.BasicApi.Quests;
using GooglePlayGames.BasicApi.SavedGame;
using GooglePlayGames.OurUtils;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

#nullable disable
namespace GooglePlayGames
{
  public class PlayGamesPlatform : ISocialPlatform
  {
    private static volatile PlayGamesPlatform sInstance;
    private static volatile bool sNearbyInitializePending;
    private static volatile INearbyConnectionClient sNearbyConnectionClient;
    private readonly PlayGamesClientConfiguration mConfiguration;
    private PlayGamesLocalUser mLocalUser;
    private IPlayGamesClient mClient;
    private string mDefaultLbUi;
    private Dictionary<string, string> mIdMap = new Dictionary<string, string>();

    internal PlayGamesPlatform(IPlayGamesClient client)
    {
      this.mClient = Misc.CheckNotNull<IPlayGamesClient>(client);
      this.mLocalUser = new PlayGamesLocalUser(this);
      this.mConfiguration = PlayGamesClientConfiguration.DefaultConfiguration;
    }

    private PlayGamesPlatform(PlayGamesClientConfiguration configuration)
    {
      this.mLocalUser = new PlayGamesLocalUser(this);
      this.mConfiguration = configuration;
    }

    public static bool DebugLogEnabled
    {
      get => Logger.DebugLogEnabled;
      set => Logger.DebugLogEnabled = value;
    }

    public static PlayGamesPlatform Instance
    {
      get
      {
        if (PlayGamesPlatform.sInstance == null)
        {
          Logger.d("Instance was not initialized, using default configuration.");
          PlayGamesPlatform.InitializeInstance(PlayGamesClientConfiguration.DefaultConfiguration);
        }
        return PlayGamesPlatform.sInstance;
      }
    }

    public static INearbyConnectionClient Nearby
    {
      get
      {
        if (PlayGamesPlatform.sNearbyConnectionClient == null && !PlayGamesPlatform.sNearbyInitializePending)
        {
          PlayGamesPlatform.sNearbyInitializePending = true;
          PlayGamesPlatform.InitializeNearby((Action<INearbyConnectionClient>) null);
        }
        return PlayGamesPlatform.sNearbyConnectionClient;
      }
    }

    public IRealTimeMultiplayerClient RealTime => this.mClient.GetRtmpClient();

    public ITurnBasedMultiplayerClient TurnBased => this.mClient.GetTbmpClient();

    public ISavedGameClient SavedGame => this.mClient.GetSavedGameClient();

    public IEventsClient Events => this.mClient.GetEventsClient();

    public IQuestsClient Quests => this.mClient.GetQuestsClient();

    public ILocalUser localUser => (ILocalUser) this.mLocalUser;

    public static void InitializeInstance(PlayGamesClientConfiguration configuration)
    {
      if (PlayGamesPlatform.sInstance != null)
        Logger.w("PlayGamesPlatform already initialized. Ignoring this call.");
      else
        PlayGamesPlatform.sInstance = new PlayGamesPlatform(configuration);
    }

    public static void InitializeNearby(Action<INearbyConnectionClient> callback)
    {
      Debug.Log((object) "Calling InitializeNearby!");
      if (PlayGamesPlatform.sNearbyConnectionClient == null)
        NearbyConnectionClientFactory.Create((Action<INearbyConnectionClient>) (client =>
        {
          Debug.Log((object) "Nearby Client Created!!");
          PlayGamesPlatform.sNearbyConnectionClient = client;
          if (callback != null)
            callback(client);
          else
            Debug.Log((object) "Initialize Nearby callback is null");
        }));
      else if (callback != null)
      {
        Debug.Log((object) "Nearby Already initialized: calling callback directly");
        callback(PlayGamesPlatform.sNearbyConnectionClient);
      }
      else
        Debug.Log((object) "Nearby Already initialized");
    }

    public static PlayGamesPlatform Activate()
    {
      Logger.d("Activating PlayGamesPlatform.");
      Social.Active = (ISocialPlatform) PlayGamesPlatform.Instance;
      Logger.d("PlayGamesPlatform activated: " + (object) Social.Active);
      return PlayGamesPlatform.Instance;
    }

    public IntPtr GetApiClient() => this.mClient.GetApiClient();

    public void AddIdMapping(string fromId, string toId) => this.mIdMap[fromId] = toId;

    public void Authenticate(Action<bool> callback) => this.Authenticate(callback, false);

    public void Authenticate(Action<bool> callback, bool silent)
    {
      if (this.mClient == null)
      {
        Logger.d("Creating platform-specific Play Games client.");
        this.mClient = PlayGamesClientFactory.GetPlatformPlayGamesClient(this.mConfiguration);
      }
      this.mClient.Authenticate(callback, silent);
    }

    public void Authenticate(ILocalUser unused, Action<bool> callback)
    {
      this.Authenticate(callback, false);
    }

    public bool IsAuthenticated() => this.mClient != null && this.mClient.IsAuthenticated();

    public void SignOut()
    {
      if (this.mClient != null)
        this.mClient.SignOut();
      this.mLocalUser = new PlayGamesLocalUser(this);
    }

    public void LoadUsers(string[] userIds, Action<IUserProfile[]> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.e("GetUserId() can only be called after authentication.");
        callback(new IUserProfile[0]);
      }
      this.mClient.LoadUsers(userIds, callback);
    }

    public string GetUserId()
    {
      if (this.IsAuthenticated())
        return this.mClient.GetUserId();
      Logger.e("GetUserId() can only be called after authentication.");
      return "0";
    }

    public void GetIdToken(Action<string> idTokenCallback)
    {
      if (this.mClient != null)
      {
        this.mClient.GetIdToken(idTokenCallback);
      }
      else
      {
        Logger.e("No client available, calling back with null.");
        idTokenCallback((string) null);
      }
    }

    public string GetAccessToken()
    {
      return this.mClient != null ? this.mClient.GetAccessToken() : (string) null;
    }

    public void GetServerAuthCode(Action<CommonStatusCodes, string> callback)
    {
      if (this.mClient != null && this.mClient.IsAuthenticated())
      {
        if (GameInfo.WebClientIdInitialized())
        {
          this.mClient.GetServerAuthCode(string.Empty, callback);
        }
        else
        {
          Logger.e("GetServerAuthCode requires a webClientId.");
          callback(CommonStatusCodes.DeveloperError, string.Empty);
        }
      }
      else
      {
        Logger.e("GetServerAuthCode can only be called after authentication.");
        callback(CommonStatusCodes.SignInRequired, string.Empty);
      }
    }

    public string GetUserEmail()
    {
      return this.mClient != null ? this.mClient.GetUserEmail() : (string) null;
    }

    public void GetPlayerStats(Action<CommonStatusCodes, PlayerStats> callback)
    {
      if (this.mClient != null && this.mClient.IsAuthenticated())
      {
        this.mClient.GetPlayerStats(callback);
      }
      else
      {
        Logger.e("GetPlayerStats can only be called after authentication.");
        callback(CommonStatusCodes.SignInRequired, new PlayerStats());
      }
    }

    public Achievement GetAchievement(string achievementId)
    {
      if (this.IsAuthenticated())
        return this.mClient.GetAchievement(achievementId);
      Logger.e("GetAchievement can only be called after authentication.");
      return (Achievement) null;
    }

    public string GetUserDisplayName()
    {
      if (this.IsAuthenticated())
        return this.mClient.GetUserDisplayName();
      Logger.e("GetUserDisplayName can only be called after authentication.");
      return string.Empty;
    }

    public string GetUserImageUrl()
    {
      if (this.IsAuthenticated())
        return this.mClient.GetUserImageUrl();
      Logger.e("GetUserImageUrl can only be called after authentication.");
      return (string) null;
    }

    public void ReportProgress(string achievementID, double progress, Action<bool> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.e("ReportProgress can only be called after authentication.");
        if (callback == null)
          return;
        callback(false);
      }
      else
      {
        Logger.d("ReportProgress, " + achievementID + ", " + (object) progress);
        achievementID = this.MapId(achievementID);
        if (progress < 1E-06)
        {
          Logger.d("Progress 0.00 interpreted as request to reveal.");
          this.mClient.RevealAchievement(achievementID, callback);
        }
        else
        {
          int num1 = 0;
          int num2 = 0;
          Achievement achievement = this.mClient.GetAchievement(achievementID);
          bool flag;
          if (achievement == null)
          {
            Logger.w("Unable to locate achievement " + achievementID);
            Logger.w("As a quick fix, assuming it's standard.");
            flag = false;
          }
          else
          {
            flag = achievement.IsIncremental;
            num1 = achievement.CurrentSteps;
            num2 = achievement.TotalSteps;
            Logger.d("Achievement is " + (!flag ? "STANDARD" : "INCREMENTAL"));
            if (flag)
              Logger.d("Current steps: " + (object) num1 + "/" + (object) num2);
          }
          if (flag)
          {
            Logger.d("Progress " + (object) progress + " interpreted as incremental target (approximate).");
            if (progress >= 0.0 && progress <= 1.0)
              Logger.w("Progress " + (object) progress + " is less than or equal to 1. You might be trying to use values in the range of [0,1], while values are expected to be within the range [0,100]. If you are using the latter, you can safely ignore this message.");
            int num3 = (int) (progress / 100.0 * (double) num2);
            int steps = num3 - num1;
            Logger.d("Target steps: " + (object) num3 + ", cur steps:" + (object) num1);
            Logger.d("Steps to increment: " + (object) steps);
            if (steps < 0)
              return;
            this.mClient.IncrementAchievement(achievementID, steps, callback);
          }
          else if (progress >= 100.0)
          {
            Logger.d("Progress " + (object) progress + " interpreted as UNLOCK.");
            this.mClient.UnlockAchievement(achievementID, callback);
          }
          else
            Logger.d("Progress " + (object) progress + " not enough to unlock non-incremental achievement.");
        }
      }
    }

    public void IncrementAchievement(string achievementID, int steps, Action<bool> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.e("IncrementAchievement can only be called after authentication.");
        if (callback == null)
          return;
        callback(false);
      }
      else
      {
        Logger.d("IncrementAchievement: " + achievementID + ", steps " + (object) steps);
        achievementID = this.MapId(achievementID);
        this.mClient.IncrementAchievement(achievementID, steps, callback);
      }
    }

    public void SetStepsAtLeast(string achievementID, int steps, Action<bool> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.e("SetStepsAtLeast can only be called after authentication.");
        if (callback == null)
          return;
        callback(false);
      }
      else
      {
        Logger.d("SetStepsAtLeast: " + achievementID + ", steps " + (object) steps);
        achievementID = this.MapId(achievementID);
        this.mClient.SetStepsAtLeast(achievementID, steps, callback);
      }
    }

    public void LoadAchievementDescriptions(Action<IAchievementDescription[]> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.e("LoadAchievementDescriptions can only be called after authentication.");
        callback((IAchievementDescription[]) null);
      }
      this.mClient.LoadAchievements((Action<Achievement[]>) (ach =>
      {
        IAchievementDescription[] achievementDescriptionArray = new IAchievementDescription[ach.Length];
        for (int index = 0; index < achievementDescriptionArray.Length; ++index)
          achievementDescriptionArray[index] = (IAchievementDescription) new PlayGamesAchievement(ach[index]);
        callback(achievementDescriptionArray);
      }));
    }

    public void LoadAchievements(Action<IAchievement[]> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.e("LoadAchievements can only be called after authentication.");
        callback((IAchievement[]) null);
      }
      this.mClient.LoadAchievements((Action<Achievement[]>) (ach =>
      {
        IAchievement[] achievementArray = new IAchievement[ach.Length];
        for (int index = 0; index < achievementArray.Length; ++index)
          achievementArray[index] = (IAchievement) new PlayGamesAchievement(ach[index]);
        callback(achievementArray);
      }));
    }

    public IAchievement CreateAchievement() => (IAchievement) new PlayGamesAchievement();

    public void ReportScore(long score, string board, Action<bool> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.e("ReportScore can only be called after authentication.");
        if (callback == null)
          return;
        callback(false);
      }
      else
      {
        Logger.d("ReportScore: score=" + (object) score + ", board=" + board);
        this.mClient.SubmitScore(this.MapId(board), score, callback);
      }
    }

    public void ReportScore(long score, string board, string metadata, Action<bool> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.e("ReportScore can only be called after authentication.");
        if (callback == null)
          return;
        callback(false);
      }
      else
      {
        Logger.d("ReportScore: score=" + (object) score + ", board=" + board + " metadata=" + metadata);
        this.mClient.SubmitScore(this.MapId(board), score, metadata, callback);
      }
    }

    public void LoadScores(string leaderboardId, Action<IScore[]> callback)
    {
      this.LoadScores(leaderboardId, LeaderboardStart.PlayerCentered, this.mClient.LeaderboardMaxResults(), LeaderboardCollection.Public, LeaderboardTimeSpan.AllTime, (Action<LeaderboardScoreData>) (scoreData => callback(scoreData.Scores)));
    }

    public void LoadScores(
      string leaderboardId,
      LeaderboardStart start,
      int rowCount,
      LeaderboardCollection collection,
      LeaderboardTimeSpan timeSpan,
      Action<LeaderboardScoreData> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.e("LoadScores can only be called after authentication.");
        callback(new LeaderboardScoreData(leaderboardId, ResponseStatus.NotAuthorized));
      }
      else
        this.mClient.LoadScores(leaderboardId, start, rowCount, collection, timeSpan, callback);
    }

    public void LoadMoreScores(
      ScorePageToken token,
      int rowCount,
      Action<LeaderboardScoreData> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.e("LoadMoreScores can only be called after authentication.");
        callback(new LeaderboardScoreData(token.LeaderboardId, ResponseStatus.NotAuthorized));
      }
      else
        this.mClient.LoadMoreScores(token, rowCount, callback);
    }

    public ILeaderboard CreateLeaderboard()
    {
      return (ILeaderboard) new PlayGamesLeaderboard(this.mDefaultLbUi);
    }

    public void ShowAchievementsUI() => this.ShowAchievementsUI((Action<UIStatus>) null);

    public void ShowAchievementsUI(Action<UIStatus> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.e("ShowAchievementsUI can only be called after authentication.");
      }
      else
      {
        Logger.d("ShowAchievementsUI callback is " + (object) callback);
        this.mClient.ShowAchievementsUI(callback);
      }
    }

    public void ShowLeaderboardUI()
    {
      Logger.d("ShowLeaderboardUI with default ID");
      this.ShowLeaderboardUI(this.MapId(this.mDefaultLbUi), (Action<UIStatus>) null);
    }

    public void ShowLeaderboardUI(string leaderboardId)
    {
      if (leaderboardId != null)
        leaderboardId = this.MapId(leaderboardId);
      this.mClient.ShowLeaderboardUI(leaderboardId, LeaderboardTimeSpan.AllTime, (Action<UIStatus>) null);
    }

    public void ShowLeaderboardUI(string leaderboardId, Action<UIStatus> callback)
    {
      this.ShowLeaderboardUI(leaderboardId, LeaderboardTimeSpan.AllTime, callback);
    }

    public void ShowLeaderboardUI(
      string leaderboardId,
      LeaderboardTimeSpan span,
      Action<UIStatus> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.e("ShowLeaderboardUI can only be called after authentication.");
        callback(UIStatus.NotAuthorized);
      }
      else
      {
        Logger.d("ShowLeaderboardUI, lbId=" + leaderboardId + " callback is " + (object) callback);
        this.mClient.ShowLeaderboardUI(leaderboardId, span, callback);
      }
    }

    public void SetDefaultLeaderboardForUI(string lbid)
    {
      Logger.d("SetDefaultLeaderboardForUI: " + lbid);
      if (lbid != null)
        lbid = this.MapId(lbid);
      this.mDefaultLbUi = lbid;
    }

    public void LoadFriends(ILocalUser user, Action<bool> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.e("LoadScores can only be called after authentication.");
        if (callback != null)
          callback(false);
      }
      this.mClient.LoadFriends(callback);
    }

    public void LoadScores(ILeaderboard board, Action<bool> callback)
    {
      if (!this.IsAuthenticated())
      {
        Logger.e("LoadScores can only be called after authentication.");
        if (callback != null)
          callback(false);
      }
      LeaderboardTimeSpan timeSpan;
      switch (board.timeScope)
      {
        case TimeScope.Today:
          timeSpan = LeaderboardTimeSpan.Daily;
          break;
        case TimeScope.Week:
          timeSpan = LeaderboardTimeSpan.Weekly;
          break;
        case TimeScope.AllTime:
          timeSpan = LeaderboardTimeSpan.AllTime;
          break;
        default:
          timeSpan = LeaderboardTimeSpan.AllTime;
          break;
      }
      ((PlayGamesLeaderboard) board).loading = true;
      Logger.d("LoadScores, board=" + (object) board + " callback is " + (object) callback);
      this.mClient.LoadScores(board.id, LeaderboardStart.PlayerCentered, board.range.count <= 0 ? this.mClient.LeaderboardMaxResults() : board.range.count, board.userScope != UserScope.FriendsOnly ? LeaderboardCollection.Public : LeaderboardCollection.Social, timeSpan, (Action<LeaderboardScoreData>) (scoreData => this.HandleLoadingScores((PlayGamesLeaderboard) board, scoreData, callback)));
    }

    public bool GetLoading(ILeaderboard board) => board != null && board.loading;

    public void RegisterInvitationDelegate(InvitationReceivedDelegate deleg)
    {
      this.mClient.RegisterInvitationDelegate(deleg);
    }

    public string GetToken() => this.mClient.GetToken();

    internal void HandleLoadingScores(
      PlayGamesLeaderboard board,
      LeaderboardScoreData scoreData,
      Action<bool> callback)
    {
      bool flag = board.SetFromData(scoreData);
      if (flag && !board.HasAllScores() && scoreData.NextPageToken != null)
      {
        int rowCount = board.range.count - board.ScoreCount;
        this.mClient.LoadMoreScores(scoreData.NextPageToken, rowCount, (Action<LeaderboardScoreData>) (nextScoreData => this.HandleLoadingScores(board, nextScoreData, callback)));
      }
      else
        callback(flag);
    }

    internal IUserProfile[] GetFriends()
    {
      if (this.IsAuthenticated())
        return this.mClient.GetFriends();
      Logger.d("Cannot get friends when not authenticated!");
      return new IUserProfile[0];
    }

    private string MapId(string id)
    {
      if (id == null)
        return (string) null;
      if (!this.mIdMap.ContainsKey(id))
        return id;
      string mId = this.mIdMap[id];
      Logger.d("Mapping alias " + id + " to ID " + mId);
      return mId;
    }
  }
}
