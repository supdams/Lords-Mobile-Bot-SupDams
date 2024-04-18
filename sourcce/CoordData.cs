// Decompiled with JetBrains decompiler
// Type: CoordData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CoordData
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U1)]
  public byte Type;
  [MarshalAs(UnmanagedType.U2)]
  public ushort AtkX;
  [MarshalAs(UnmanagedType.U2)]
  public ushort AtkY;
  [MarshalAs(UnmanagedType.U2)]
  public ushort DefX;
  [MarshalAs(UnmanagedType.U2)]
  public ushort DefY;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SiegeAtkX;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SiegeAtkY;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SiegeDefX;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SiegeDefY;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Siege23DefX;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Siege23DefY;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SiegeRangeNoWallDefX;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SiegeRangeNoWallDefY;
}
