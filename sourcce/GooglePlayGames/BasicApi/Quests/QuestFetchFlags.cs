// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.BasicApi.Quests.QuestFetchFlags
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
namespace GooglePlayGames.BasicApi.Quests
{
  [Flags]
  public enum QuestFetchFlags
  {
    Upcoming = 1,
    Open = 2,
    Accepted = 4,
    Completed = 8,
    CompletedNotClaimed = 16, // 0x00000010
    Expired = 32, // 0x00000020
    EndingSoon = 64, // 0x00000040
    Failed = 128, // 0x00000080
    All = -1, // 0xFFFFFFFF
  }
}
