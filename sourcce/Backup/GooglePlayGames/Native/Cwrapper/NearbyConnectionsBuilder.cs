// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.NearbyConnectionsBuilder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class NearbyConnectionsBuilder
  {
    [DllImport("gpg")]
    internal static extern void NearbyConnections_Builder_SetOnInitializationFinished(
      HandleRef self,
      NearbyConnectionsBuilder.OnInitializationFinishedCallback callback,
      IntPtr callback_arg);

    [DllImport("gpg")]
    internal static extern IntPtr NearbyConnections_Builder_Construct();

    [DllImport("gpg")]
    internal static extern void NearbyConnections_Builder_SetClientId(
      HandleRef self,
      long client_id);

    [DllImport("gpg")]
    internal static extern void NearbyConnections_Builder_SetOnLog(
      HandleRef self,
      NearbyConnectionsBuilder.OnLogCallback callback,
      IntPtr callback_arg,
      Types.LogLevel min_level);

    [DllImport("gpg")]
    internal static extern void NearbyConnections_Builder_SetDefaultOnLog(
      HandleRef self,
      Types.LogLevel min_level);

    [DllImport("gpg")]
    internal static extern IntPtr NearbyConnections_Builder_Create(HandleRef self, IntPtr platform);

    [DllImport("gpg")]
    internal static extern void NearbyConnections_Builder_Dispose(HandleRef self);

    internal delegate void OnInitializationFinishedCallback(
      NearbyConnectionsStatus.InitializationStatus arg0,
      IntPtr arg1);

    internal delegate void OnLogCallback(Types.LogLevel arg0, string arg1, IntPtr arg2);
  }
}
