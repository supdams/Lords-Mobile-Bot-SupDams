// Decompiled with JetBrains decompiler
// Type: BuildLevelRequest
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BuildLevelRequest
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort BuildID;
  [MarshalAs(UnmanagedType.U1)]
  public byte Level;
  [MarshalAs(UnmanagedType.U4)]
  public uint BuildTime;
  [MarshalAs(UnmanagedType.U2)]
  public ushort GroupID;
  [MarshalAs(UnmanagedType.U4)]
  public uint RequestFood;
  [MarshalAs(UnmanagedType.U4)]
  public uint RequestRock;
  [MarshalAs(UnmanagedType.U4)]
  public uint RequestWood;
  [MarshalAs(UnmanagedType.U4)]
  public uint RequestIron;
  [MarshalAs(UnmanagedType.U4)]
  public uint RequestGold;
  [MarshalAs(UnmanagedType.U4)]
  public uint CastleArmy;
  [MarshalAs(UnmanagedType.U4)]
  public uint Strength;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Effect1;
  [MarshalAs(UnmanagedType.U4)]
  public uint Value1;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Effect2;
  [MarshalAs(UnmanagedType.U4)]
  public uint Value2;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Effect3;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Value3;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Effect4;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Value4;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Value5;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ExtEffect1;
  [MarshalAs(UnmanagedType.U4)]
  public uint ExtValue1;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ExtEffect2;
  [MarshalAs(UnmanagedType.U1)]
  public byte ExtValue2;
}
