// Decompiled with JetBrains decompiler
// Type: GooglePlayGames.Native.Cwrapper.SnapshotMetadataChangeBuilder
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace GooglePlayGames.Native.Cwrapper
{
  internal static class SnapshotMetadataChangeBuilder
  {
    [DllImport("gpg")]
    internal static extern void SnapshotMetadataChange_Builder_SetDescription(
      HandleRef self,
      string description);

    [DllImport("gpg")]
    internal static extern IntPtr SnapshotMetadataChange_Builder_Construct();

    [DllImport("gpg")]
    internal static extern void SnapshotMetadataChange_Builder_SetPlayedTime(
      HandleRef self,
      ulong played_time);

    [DllImport("gpg")]
    internal static extern void SnapshotMetadataChange_Builder_SetCoverImageFromPngData(
      HandleRef self,
      byte[] png_data,
      UIntPtr png_data_size);

    [DllImport("gpg")]
    internal static extern IntPtr SnapshotMetadataChange_Builder_Create(HandleRef self);

    [DllImport("gpg")]
    internal static extern void SnapshotMetadataChange_Builder_Dispose(HandleRef self);
  }
}
