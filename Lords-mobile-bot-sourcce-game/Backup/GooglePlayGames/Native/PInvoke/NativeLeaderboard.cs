// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.PInvoke.NativeLeaderboard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames.Native.Cwrapper;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.PInvoke
{
  internal class NativeLeaderboard : BaseReferenceHolder
  {
    internal NativeLeaderboard(IntPtr selfPtr)
      : base(selfPtr)
    {
    }

    protected override void CallDispose(HandleRef selfPointer)
    {
      Leaderboard.Leaderboard_Dispose(selfPointer);
    }

    internal string Title()
    {
      return PInvokeUtilities.OutParamsToString((PInvokeUtilities.OutStringMethod) ((out_string, out_size) => Leaderboard.Leaderboard_Name(this.SelfPtr(), out_string, out_size)));
    }

    internal static NativeLeaderboard FromPointer(IntPtr pointer)
    {
      return pointer.Equals((object) IntPtr.Zero) ? (NativeLeaderboard) null : new NativeLeaderboard(pointer);
    }
  }
}
