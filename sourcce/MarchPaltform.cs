// Decompiled with JetBrains decompiler
// Type: MarchPaltform
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MarchPaltform
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort UpStartID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort UpEndID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort UpRightStartID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort UpRightEndID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort RightStartID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort RightEndID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort DownRightStartID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort DownRightEndID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort DownStartID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort DownEndID;
}
