// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.ResponseStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
namespace GooglePlayGames.BasicApi
{
  public enum ResponseStatus
  {
    Timeout = -5, // 0xFFFFFFFB
    VersionUpdateRequired = -4, // 0xFFFFFFFC
    NotAuthorized = -3, // 0xFFFFFFFD
    InternalError = -2, // 0xFFFFFFFE
    LicenseCheckFailed = -1, // 0xFFFFFFFF
    Success = 1,
    SuccessWithStale = 2,
  }
}
