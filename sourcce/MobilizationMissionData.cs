// Decompiled with JetBrains decompiler
// Type: MobilizationMissionData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MobilizationMissionData
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort MissionKey;
  [MarshalAs(UnmanagedType.U2)]
  public ushort MissionType;
  [MarshalAs(UnmanagedType.U2)]
  public ushort MissionInfo;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
  public uint[] MissionMaxValue;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
  public ushort[] MissionScore;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
  public ushort[] MissionTime;
  [MarshalAs(UnmanagedType.U1)]
  public byte MissionIcon;
  [MarshalAs(UnmanagedType.U1)]
  public byte MissionIcon2;
}
