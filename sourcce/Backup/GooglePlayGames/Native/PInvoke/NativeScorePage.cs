// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.NativeScorePage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.Native.Cwrapper;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class NativeScorePage : BaseReferenceHolder
  {
    internal NativeScorePage(IntPtr selfPtr)
      : base(selfPtr)
    {
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      ScorePage.ScorePage_Dispose(selfPointer);
    }

    internal Types.LeaderboardCollection GetCollection()
    {
      return ScorePage.ScorePage_Collection(this.SelfPtr());
    }

    private UIntPtr Length() => ScorePage.ScorePage_Entries_Length(this.SelfPtr());

    private NativeScoreEntry GetElement(UIntPtr index)
    {
      return index.ToUInt64() < this.Length().ToUInt64() ? new NativeScoreEntry(ScorePage.ScorePage_Entries_GetElement(this.SelfPtr(), index)) : throw new ArgumentOutOfRangeException();
    }

    public IEnumerator<NativeScoreEntry> GetEnumerator()
    {
      return PInvokeUtilities.ToEnumerator<NativeScoreEntry>(ScorePage.ScorePage_Entries_Length(this.SelfPtr()), (Func<UIntPtr, NativeScoreEntry>) (index => this.GetElement(index)));
    }

    internal bool HasNextScorePage() => ScorePage.ScorePage_HasNextScorePage(this.SelfPtr());

    internal bool HasPrevScorePage() => ScorePage.ScorePage_HasPreviousScorePage(this.SelfPtr());

    internal NativeScorePageToken GetNextScorePageToken()
    {
      return new NativeScorePageToken(ScorePage.ScorePage_NextScorePageToken(this.SelfPtr()));
    }

    internal NativeScorePageToken GetPreviousScorePageToken()
    {
      return new NativeScorePageToken(ScorePage.ScorePage_PreviousScorePageToken(this.SelfPtr()));
    }

    internal bool Valid() => ScorePage.ScorePage_Valid(this.SelfPtr());

    internal Types.LeaderboardTimeSpan GetTimeSpan()
    {
      return ScorePage.ScorePage_TimeSpan(this.SelfPtr());
    }

    internal Types.LeaderboardStart GetStart() => ScorePage.ScorePage_Start(this.SelfPtr());

    internal string GetLeaderboardId()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => ScorePage.ScorePage_LeaderboardId(this.SelfPtr(), out_string, out_size)));
    }

    internal static NativeScorePage FromPointer(IntPtr pointer)
    {
      return pointer.Equals((object) IntPtr.Zero) ? (NativeScorePage) null : new NativeScorePage(pointer);
    }
  }
}
