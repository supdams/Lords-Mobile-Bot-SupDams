// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.InternalHooks
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class InternalHooks
  {
    [DllImport("gpg")]
    internal static extern void InternalHooks_ConfigureForUnityPlugin(HandleRef builder);

    [DllImport("gpg")]
    internal static extern IntPtr InternalHooks_GetApiClient(HandleRef services);
  }
}
