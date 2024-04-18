// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.StatsManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class StatsManager
  {
    [DllImport("gpg")]
    internal static extern void StatsManager_FetchForPlayer(
      HandleRef self,
      Types.DataSource data_source,
      StatsManager.FetchForPlayerCallback callback,
      IntPtr callback_arg);

    [DllImport("gpg")]
    internal static extern void StatsManager_FetchForPlayerResponse_Dispose(HandleRef self);

    [DllImport("gpg")]
    internal static extern CommonErrorStatus.ResponseStatus StatsManager_FetchForPlayerResponse_GetStatus(
      HandleRef self);

    [DllImport("gpg")]
    internal static extern IntPtr StatsManager_FetchForPlayerResponse_GetData(HandleRef self);

    internal delegate void FetchForPlayerCallback(IntPtr arg0, IntPtr arg1);
  }
}
