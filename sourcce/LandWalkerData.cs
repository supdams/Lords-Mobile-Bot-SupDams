// Decompiled with JetBrains decompiler
// Type: LandWalkerData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LandWalkerData
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
  public ushort[] Data;
  [MarshalAs(UnmanagedType.U1)]
  public byte fadeEnd;
  [MarshalAs(UnmanagedType.U1)]
  public byte fadeStart;
  [MarshalAs(UnmanagedType.U2)]
  public ushort direction;
  [MarshalAs(UnmanagedType.U1)]
  public byte totalTime;
  [MarshalAs(UnmanagedType.U1)]
  public byte groupID;
  [MarshalAs(UnmanagedType.U1)]
  public byte SpriteSort;
  [MarshalAs(UnmanagedType.U1)]
  public byte chapter;
  [MarshalAs(UnmanagedType.U1)]
  public byte NeverGone;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
  public LandWalkerGenData[] GenData;
}
