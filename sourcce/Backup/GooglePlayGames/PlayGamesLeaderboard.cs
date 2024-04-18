// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.PlayGamesLeaderboard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.BasicApi;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

#nullable disable
namespace GooglePlayGames
{
  public class PlayGamesLeaderboard : ILeaderboard
  {
    private string mId;
    private UserScope mUserScope;
    private Range mRange;
    private TimeScope mTimeScope;
    private string[] mFilteredUserIds;
    private bool mLoading;
    private IScore mLocalUserScore;
    private uint mMaxRange;
    private List<PlayGamesScore> mScoreList = new List<PlayGamesScore>();
    private string mTitle;

    public PlayGamesLeaderboard(string id) => this.mId = id;

    public void SetUserFilter(string[] userIDs) => this.mFilteredUserIds = userIDs;

    public void LoadScores(Action<bool> callback)
    {
      PlayGamesPlatform.Instance.LoadScores((ILeaderboard) this, callback);
    }

    public bool loading
    {
      get => this.mLoading;
      internal set => this.mLoading = value;
    }

    public string id
    {
      get => this.mId;
      set => this.mId = value;
    }

    public UserScope userScope
    {
      get => this.mUserScope;
      set => this.mUserScope = value;
    }

    public Range range
    {
      get => this.mRange;
      set => this.mRange = value;
    }

    public TimeScope timeScope
    {
      get => this.mTimeScope;
      set => this.mTimeScope = value;
    }

    public IScore localUserScore => this.mLocalUserScore;

    public uint maxRange => this.mMaxRange;

    public IScore[] scores
    {
      get
      {
        PlayGamesScore[] array = new PlayGamesScore[this.mScoreList.Count];
        this.mScoreList.CopyTo(array);
        return (IScore[]) array;
      }
    }

    public string title => this.mTitle;

    internal bool SetFromData(LeaderboardScoreData data)
    {
      if (data.Valid)
      {
        Debug.Log((object) ("Setting leaderboard from: " + (object) data));
        this.SetMaxRange(data.ApproximateCount);
        this.SetTitle(data.Title);
        this.SetLocalUserScore((PlayGamesScore) data.PlayerScore);
        foreach (PlayGamesScore score in data.Scores)
          this.AddScore(score);
        this.mLoading = data.Scores.Length == 0 || this.HasAllScores();
      }
      return data.Valid;
    }

    internal void SetMaxRange(ulong val) => this.mMaxRange = (uint) val;

    internal void SetTitle(string value) => this.mTitle = value;

    internal void SetLocalUserScore(PlayGamesScore score) => this.mLocalUserScore = (IScore) score;

    internal int AddScore(PlayGamesScore score)
    {
      if (this.mFilteredUserIds == null || this.mFilteredUserIds.Length == 0)
      {
        this.mScoreList.Add(score);
      }
      else
      {
        foreach (string mFilteredUserId in this.mFilteredUserIds)
        {
          if (mFilteredUserId.Equals(score.userID))
            return this.mScoreList.Count;
        }
        this.mScoreList.Add(score);
      }
      return this.mScoreList.Count;
    }

    public int ScoreCount => this.mScoreList.Count;

    internal bool HasAllScores()
    {
      return this.mScoreList.Count >= this.mRange.count || (long) this.mScoreList.Count >= (long) this.maxRange;
    }
  }
}
