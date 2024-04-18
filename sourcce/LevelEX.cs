// Decompiled with JetBrains decompiler
// Type: LevelEX
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LevelEX
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort LevelKey;
  [MarshalAs(UnmanagedType.U1)]
  public byte LV;
  [MarshalAs(UnmanagedType.U1)]
  public byte Star;
  [MarshalAs(UnmanagedType.U1)]
  public byte Rank;
  [MarshalAs(UnmanagedType.U1)]
  public byte Equip;
  [MarshalAs(UnmanagedType.U2)]
  public ushort NodusOneID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort NodusTwoID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort NodusThrID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort RewardOneID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort RewardTwoID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort RewardThrID;
}
