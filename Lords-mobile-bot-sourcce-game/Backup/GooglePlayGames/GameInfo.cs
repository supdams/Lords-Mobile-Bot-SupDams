// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.GameInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
namespace GooglePlayGames
{
  public static class GameInfo
  {
    private const string UnescapedApplicationId = "APP_ID";
    private const string UnescapedIosClientId = "IOS_CLIENTID";
    private const string UnescapedWebClientId = "WEB_CLIENTID";
    private const string UnescapedNearbyServiceId = "NEARBY_SERVICE_ID";
    private const string UnescapedRequireGooglePlus = "REQUIRE_GOOGLE_PLUS";
    public const string ApplicationId = "334926755014";
    public const string IosClientId = "";
    public const string WebClientId = "";
    public const string NearbyConnectionServiceId = "";

    public static bool RequireGooglePlus() => false;

    public static bool ApplicationIdInitialized()
    {
      return !string.IsNullOrEmpty("334926755014") && !"334926755014".Equals(GameInfo.ToEscapedToken("APP_ID"));
    }

    public static bool IosClientIdInitialized()
    {
      return !string.IsNullOrEmpty(string.Empty) && !string.Empty.Equals(GameInfo.ToEscapedToken("IOS_CLIENTID"));
    }

    public static bool WebClientIdInitialized()
    {
      return !string.IsNullOrEmpty(string.Empty) && !string.Empty.Equals(GameInfo.ToEscapedToken("WEB_CLIENTID"));
    }

    public static bool NearbyConnectionsInitialized()
    {
      return !string.IsNullOrEmpty(string.Empty) && !string.Empty.Equals(GameInfo.ToEscapedToken("NEARBY_SERVICE_ID"));
    }

    private static string ToEscapedToken(string token) => string.Format("__{0}__", (object) token);
  }
}
