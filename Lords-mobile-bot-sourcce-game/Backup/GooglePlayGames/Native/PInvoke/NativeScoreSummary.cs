// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.NativeScoreSummary
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.Native.Cwrapper;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class NativeScoreSummary : BaseReferenceHolder
  {
    internal NativeScoreSummary(IntPtr selfPtr)
      : base(selfPtr)
    {
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      ScoreSummary.ScoreSummary_Dispose(selfPointer);
    }

    internal ulong ApproximateResults()
    {
      return ScoreSummary.ScoreSummary_ApproximateNumberOfScores(this.SelfPtr());
    }

    internal NativeScore LocalUserScore()
    {
      return NativeScore.FromPointer(ScoreSummary.ScoreSummary_CurrentPlayerScore(this.SelfPtr()));
    }

    internal static NativeScoreSummary FromPointer(IntPtr pointer)
    {
      return pointer.Equals((object) IntPtr.Zero) ? (NativeScoreSummary) null : new NativeScoreSummary(pointer);
    }
  }
}
