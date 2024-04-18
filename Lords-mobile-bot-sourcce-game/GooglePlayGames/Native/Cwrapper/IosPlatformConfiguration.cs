// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.IosPlatformConfiguration
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class IosPlatformConfiguration
  {
    [DllImport("gpg")]
    internal static extern IntPtr IosPlatformConfiguration_Construct();

    [DllImport("gpg")]
    internal static extern void IosPlatformConfiguration_Dispose(HandleRef self);

    [DllImport("gpg")]
    [return: MarshalAs(UnmanagedType.I1)]
    internal static extern bool IosPlatformConfiguration_Valid(HandleRef self);

    [DllImport("gpg")]
    internal static extern void IosPlatformConfiguration_SetClientID(
      HandleRef self,
      string client_id);
  }
}
