// Decompiled with JetBrains decompiler
// Type: ManorAimTbl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ManorAimTbl
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U1)]
  public byte UIKind;
  [MarshalAs(UnmanagedType.U2)]
  public ushort UIPriority;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Narrative;
  [MarshalAs(UnmanagedType.U1)]
  public byte MissionKind;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Parm1;
  [MarshalAs(UnmanagedType.U4)]
  public uint Parm2;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
  public _RewardItem[] RewardItems;
  [MarshalAs(UnmanagedType.U4)]
  public uint Exp;
  [MarshalAs(UnmanagedType.U4)]
  public uint Force;
  [MarshalAs(UnmanagedType.U1)]
  public byte RewardMorale;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
  public uint[] RewardResource;
}
