// Decompiled with JetBrains decompiler
// Type: CastleUpgradeRewardTbl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CastleUpgradeRewardTbl
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort UnlockBuilding;
  [MarshalAs(UnmanagedType.U4)]
  public uint Grain;
  [MarshalAs(UnmanagedType.U4)]
  public uint Rock;
  [MarshalAs(UnmanagedType.U4)]
  public uint Wood;
  [MarshalAs(UnmanagedType.U4)]
  public uint Iron;
  [MarshalAs(UnmanagedType.U4)]
  public uint Gold;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Item1;
  [MarshalAs(UnmanagedType.U1)]
  public byte Item1Count;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Item2;
  [MarshalAs(UnmanagedType.U1)]
  public byte Item2Count;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Item3;
  [MarshalAs(UnmanagedType.U1)]
  public byte Item3Count;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Item4;
  [MarshalAs(UnmanagedType.U1)]
  public byte Item4Count;
}
