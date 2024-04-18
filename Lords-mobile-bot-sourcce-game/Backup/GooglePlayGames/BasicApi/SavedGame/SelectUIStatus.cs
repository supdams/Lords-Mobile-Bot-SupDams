// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.SavedGame.SelectUIStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
namespace GooglePlayGames.BasicApi.SavedGame
{
  public enum SelectUIStatus
  {
    BadInputError = -4, // 0xFFFFFFFC
    AuthenticationError = -3, // 0xFFFFFFFD
    TimeoutError = -2, // 0xFFFFFFFE
    InternalError = -1, // 0xFFFFFFFF
    SavedGameSelected = 1,
    UserClosedUI = 2,
  }
}
