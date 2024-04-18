// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.CommonErrorStatus
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class CommonErrorStatus
  {
    internal enum ResponseStatus
    {
      ERROR_TIMEOUT = -5, // 0xFFFFFFFB
      ERROR_VERSION_UPDATE_REQUIRED = -4, // 0xFFFFFFFC
      ERROR_NOT_AUTHORIZED = -3, // 0xFFFFFFFD
      ERROR_INTERNAL = -2, // 0xFFFFFFFE
      ERROR_LICENSE_CHECK_FAILED = -1, // 0xFFFFFFFF
      VALID = 1,
      VALID_BUT_STALE = 2,
    }

    internal enum FlushStatus
    {
      ERROR_TIMEOUT = -5, // 0xFFFFFFFB
      ERROR_VERSION_UPDATE_REQUIRED = -4, // 0xFFFFFFFC
      ERROR_NOT_AUTHORIZED = -3, // 0xFFFFFFFD
      ERROR_INTERNAL = -2, // 0xFFFFFFFE
      FLUSHED = 4,
    }

    internal enum AuthStatus
    {
      ERROR_TIMEOUT = -5, // 0xFFFFFFFB
      ERROR_VERSION_UPDATE_REQUIRED = -4, // 0xFFFFFFFC
      ERROR_NOT_AUTHORIZED = -3, // 0xFFFFFFFD
      ERROR_INTERNAL = -2, // 0xFFFFFFFE
      VALID = 1,
    }

    internal enum UIStatus
    {
      ERROR_LEFT_ROOM = -18, // 0xFFFFFFEE
      ERROR_UI_BUSY = -12, // 0xFFFFFFF4
      ERROR_CANCELED = -6, // 0xFFFFFFFA
      ERROR_TIMEOUT = -5, // 0xFFFFFFFB
      ERROR_VERSION_UPDATE_REQUIRED = -4, // 0xFFFFFFFC
      ERROR_NOT_AUTHORIZED = -3, // 0xFFFFFFFD
      ERROR_INTERNAL = -2, // 0xFFFFFFFE
      VALID = 1,
    }

    internal enum MultiplayerStatus
    {
      ERROR_REAL_TIME_ROOM_NOT_JOINED = -17, // 0xFFFFFFEF
      ERROR_MATCH_OUT_OF_DATE = -11, // 0xFFFFFFF5
      ERROR_INVALID_MATCH = -10, // 0xFFFFFFF6
      ERROR_INVALID_RESULTS = -9, // 0xFFFFFFF7
      ERROR_INACTIVE_MATCH = -8, // 0xFFFFFFF8
      ERROR_MATCH_ALREADY_REMATCHED = -7, // 0xFFFFFFF9
      ERROR_TIMEOUT = -5, // 0xFFFFFFFB
      ERROR_VERSION_UPDATE_REQUIRED = -4, // 0xFFFFFFFC
      ERROR_NOT_AUTHORIZED = -3, // 0xFFFFFFFD
      ERROR_INTERNAL = -2, // 0xFFFFFFFE
      VALID = 1,
      VALID_BUT_STALE = 2,
    }

    internal enum QuestAcceptStatus
    {
      ERROR_QUEST_NOT_STARTED = -14, // 0xFFFFFFF2
      ERROR_QUEST_NO_LONGER_AVAILABLE = -13, // 0xFFFFFFF3
      ERROR_TIMEOUT = -5, // 0xFFFFFFFB
      ERROR_NOT_AUTHORIZED = -3, // 0xFFFFFFFD
      ERROR_INTERNAL = -2, // 0xFFFFFFFE
      VALID = 1,
    }

    internal enum QuestClaimMilestoneStatus
    {
      ERROR_MILESTONE_CLAIM_FAILED = -16, // 0xFFFFFFF0
      ERROR_MILESTONE_ALREADY_CLAIMED = -15, // 0xFFFFFFF1
      ERROR_TIMEOUT = -5, // 0xFFFFFFFB
      ERROR_NOT_AUTHORIZED = -3, // 0xFFFFFFFD
      ERROR_INTERNAL = -2, // 0xFFFFFFFE
      VALID = 1,
    }

    internal enum SnapshotOpenStatus
    {
      ERROR_TIMEOUT = -5, // 0xFFFFFFFB
      ERROR_NOT_AUTHORIZED = -3, // 0xFFFFFFFD
      ERROR_INTERNAL = -2, // 0xFFFFFFFE
      VALID = 1,
      VALID_WITH_CONFLICT = 3,
    }
  }
}
