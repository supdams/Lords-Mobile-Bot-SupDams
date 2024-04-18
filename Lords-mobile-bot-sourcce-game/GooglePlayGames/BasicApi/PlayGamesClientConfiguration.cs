// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.PlayGamesClientConfiguration
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.BasicApi.Multiplayer;
using GooglePlayGames.OurUtils;

#nullable disable
namespace GooglePlayGames.BasicApi
{
  public struct PlayGamesClientConfiguration
  {
    public static readonly PlayGamesClientConfiguration DefaultConfiguration = new PlayGamesClientConfiguration.Builder().Build();
    private readonly bool mEnableSavedGames;
    private readonly bool mRequireGooglePlus;
    private readonly InvitationReceivedDelegate mInvitationDelegate;
    private readonly MatchDelegate mMatchDelegate;
    private readonly string mPermissionRationale;

    private PlayGamesClientConfiguration(PlayGamesClientConfiguration.Builder builder)
    {
      this.mEnableSavedGames = builder.HasEnableSaveGames();
      this.mInvitationDelegate = builder.GetInvitationDelegate();
      this.mMatchDelegate = builder.GetMatchDelegate();
      this.mPermissionRationale = builder.GetPermissionRationale();
      this.mRequireGooglePlus = builder.HasRequireGooglePlus();
    }

    public bool EnableSavedGames => this.mEnableSavedGames;

    public bool RequireGooglePlus => this.mRequireGooglePlus;

    public InvitationReceivedDelegate InvitationDelegate => this.mInvitationDelegate;

    public MatchDelegate MatchDelegate => this.mMatchDelegate;

    public string PermissionRationale => this.mPermissionRationale;

    public class Builder
    {
      private bool mEnableSaveGames;
      private bool mRequireGooglePlus;
      private InvitationReceivedDelegate mInvitationDelegate = (InvitationReceivedDelegate) ((_param0, _param1) => { });
      private MatchDelegate mMatchDelegate = (MatchDelegate) ((_param0, _param1) => { });
      private string mRationale;

      public PlayGamesClientConfiguration.Builder EnableSavedGames()
      {
        this.mEnableSaveGames = true;
        return this;
      }

      public PlayGamesClientConfiguration.Builder RequireGooglePlus()
      {
        this.mRequireGooglePlus = true;
        return this;
      }

      public PlayGamesClientConfiguration.Builder WithInvitationDelegate(
        InvitationReceivedDelegate invitationDelegate)
      {
        this.mInvitationDelegate = Misc.CheckNotNull<InvitationReceivedDelegate>(invitationDelegate);
        return this;
      }

      public PlayGamesClientConfiguration.Builder WithMatchDelegate(MatchDelegate matchDelegate)
      {
        this.mMatchDelegate = Misc.CheckNotNull<MatchDelegate>(matchDelegate);
        return this;
      }

      public PlayGamesClientConfiguration.Builder WithPermissionRationale(string rationale)
      {
        this.mRationale = rationale;
        return this;
      }

      public PlayGamesClientConfiguration Build()
      {
        this.mRequireGooglePlus = GameInfo.RequireGooglePlus();
        return new PlayGamesClientConfiguration(this);
      }

      internal bool HasEnableSaveGames() => this.mEnableSaveGames;

      internal bool HasRequireGooglePlus() => this.mRequireGooglePlus;

      internal MatchDelegate GetMatchDelegate() => this.mMatchDelegate;

      internal InvitationReceivedDelegate GetInvitationDelegate() => this.mInvitationDelegate;

      internal string GetPermissionRationale() => this.mRationale;
    }
  }
}
