// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Achievement
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
namespace GooglePlayGames.BasicApi
{
  public class Achievement
  {
    private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
    private string mId = string.Empty;
    private bool mIsIncremental;
    private bool mIsRevealed;
    private bool mIsUnlocked;
    private int mCurrentSteps;
    private int mTotalSteps;
    private string mDescription = string.Empty;
    private string mName = string.Empty;
    private long mLastModifiedTime;
    private ulong mPoints;
    private string mRevealedImageUrl;
    private string mUnlockedImageUrl;

    public override string ToString()
    {
      return string.Format("[Achievement] id={0}, name={1}, desc={2}, type={3}, revealed={4}, unlocked={5}, steps={6}/{7}", (object) this.mId, (object) this.mName, (object) this.mDescription, !this.mIsIncremental ? (object) "STANDARD" : (object) "INCREMENTAL", (object) this.mIsRevealed, (object) this.mIsUnlocked, (object) this.mCurrentSteps, (object) this.mTotalSteps);
    }

    public bool IsIncremental
    {
      get => this.mIsIncremental;
      set => this.mIsIncremental = value;
    }

    public int CurrentSteps
    {
      get => this.mCurrentSteps;
      set => this.mCurrentSteps = value;
    }

    public int TotalSteps
    {
      get => this.mTotalSteps;
      set => this.mTotalSteps = value;
    }

    public bool IsUnlocked
    {
      get => this.mIsUnlocked;
      set => this.mIsUnlocked = value;
    }

    public bool IsRevealed
    {
      get => this.mIsRevealed;
      set => this.mIsRevealed = value;
    }

    public string Id
    {
      get => this.mId;
      set => this.mId = value;
    }

    public string Description
    {
      get => this.mDescription;
      set => this.mDescription = value;
    }

    public string Name
    {
      get => this.mName;
      set => this.mName = value;
    }

    public DateTime LastModifiedTime
    {
      get => Achievement.UnixEpoch.AddMilliseconds((double) this.mLastModifiedTime);
      set => this.mLastModifiedTime = (long) (value - Achievement.UnixEpoch).TotalMilliseconds;
    }

    public ulong Points
    {
      get => this.mPoints;
      set => this.mPoints = value;
    }

    public string RevealedImageUrl
    {
      get => this.mRevealedImageUrl;
      set => this.mRevealedImageUrl = value;
    }

    public string UnlockedImageUrl
    {
      get => this.mUnlockedImageUrl;
      set => this.mUnlockedImageUrl = value;
    }
  }
}
