// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.PlayGamesUserProfile
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.OurUtils;
using System.Collections;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SocialPlatforms;

#nullable disable
namespace GooglePlayGames
{
  public class PlayGamesUserProfile : IUserProfile
  {
    private string mDisplayName;
    private string mPlayerId;
    private string mAvatarUrl;
    private volatile bool mImageLoading;
    private Texture2D mImage;

    internal PlayGamesUserProfile(string displayName, string playerId, string avatarUrl)
    {
      this.mDisplayName = displayName;
      this.mPlayerId = playerId;
      this.mAvatarUrl = avatarUrl;
      this.mImageLoading = false;
    }

    protected void ResetIdentity(string displayName, string playerId, string avatarUrl)
    {
      this.mDisplayName = displayName;
      this.mPlayerId = playerId;
      this.mAvatarUrl = avatarUrl;
      this.mImageLoading = false;
    }

    public string userName => this.mDisplayName;

    public string id => this.mPlayerId;

    public bool isFriend => true;

    public UserState state => UserState.Online;

    public Texture2D image
    {
      get
      {
        if (!this.mImageLoading && (Object) this.mImage == (Object) null && !string.IsNullOrEmpty(this.AvatarURL))
        {
          UnityEngine.Debug.Log((object) ("Starting to load image: " + this.AvatarURL));
          this.mImageLoading = true;
          PlayGamesHelperObject.RunCoroutine(this.LoadImage());
        }
        return this.mImage;
      }
    }

    public string AvatarURL => this.mAvatarUrl;

    [DebuggerHidden]
    internal IEnumerator LoadImage()
    {
      // ISSUE: object of a compiler-generated type is created
      return (IEnumerator) new PlayGamesUserProfile.\u003CLoadImage\u003Ec__Iterator0()
      {
        \u003C\u003Ef__this = this
      };
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
        return false;
      if (object.ReferenceEquals((object) this, obj))
        return true;
      return typeof (object).IsSubclassOf(typeof (PlayGamesUserProfile)) && this.mPlayerId.Equals(((PlayGamesUserProfile) obj).mPlayerId);
    }

    public override int GetHashCode()
    {
      return typeof (PlayGamesUserProfile).GetHashCode() ^ this.mPlayerId.GetHashCode();
    }

    public override string ToString()
    {
      return string.Format("[Player: '{0}' (id {1})]", (object) this.mDisplayName, (object) this.mPlayerId);
    }
  }
}
