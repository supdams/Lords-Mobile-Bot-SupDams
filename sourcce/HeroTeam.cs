// Decompiled with JetBrains decompiler
// Type: HeroTeam
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct HeroTeam
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort TeamKey;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ArrayID;
  [MarshalAs(UnmanagedType.U1)]
  public byte HeroLevel;
  [MarshalAs(UnmanagedType.U1)]
  public byte HeroClass;
  [MarshalAs(UnmanagedType.U1)]
  public byte HeroStar;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ShiftX;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
  public HeroTeamAttribute[] Arrays;
  [MarshalAs(UnmanagedType.U1)]
  public byte SupportType;
  [MarshalAs(UnmanagedType.U1)]
  public byte SupportValue;
}
