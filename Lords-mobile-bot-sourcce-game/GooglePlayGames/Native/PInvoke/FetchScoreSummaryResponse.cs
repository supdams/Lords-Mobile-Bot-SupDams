// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.FetchScoreSummaryResponse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.Native.Cwrapper;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class FetchScoreSummaryResponse : BaseReferenceHolder
  {
    internal FetchScoreSummaryResponse(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchScoreSummaryResponse_Dispose(selfPointer);
    }

    internal CommonErrorStatus.ResponseStatus GetStatus()
    {
      return GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchScoreSummaryResponse_GetStatus(this.SelfPtr());
    }

    internal NativeScoreSummary GetScoreSummary()
    {
      return NativeScoreSummary.FromPointer(GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchScoreSummaryResponse_GetData(this.SelfPtr()));
    }

    internal static FetchScoreSummaryResponse FromPointer(IntPtr pointer)
    {
      return pointer.Equals((object) IntPtr.Zero) ? (FetchScoreSummaryResponse) null : new FetchScoreSummaryResponse(pointer);
    }
  }
}
