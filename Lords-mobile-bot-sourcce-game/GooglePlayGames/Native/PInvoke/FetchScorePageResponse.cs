// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.FetchScorePageResponse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.Native.Cwrapper;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class FetchScorePageResponse : BaseReferenceHolder
  {
    internal FetchScorePageResponse(IntPtr selfPointer)
      : base(selfPointer)
    {
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchScorePageResponse_Dispose(this.SelfPtr());
    }

    internal CommonErrorStatus.ResponseStatus GetStatus()
    {
      return GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchScorePageResponse_GetStatus(this.SelfPtr());
    }

    internal NativeScorePage GetScorePage()
    {
      return NativeScorePage.FromPointer(GooglePlayGames.Native.Cwrapper.LeaderboardManager.LeaderboardManager_FetchScorePageResponse_GetData(this.SelfPtr()));
    }

    internal static FetchScorePageResponse FromPointer(IntPtr pointer)
    {
      return pointer.Equals((object) IntPtr.Zero) ? (FetchScorePageResponse) null : new FetchScorePageResponse(pointer);
    }
  }
}
