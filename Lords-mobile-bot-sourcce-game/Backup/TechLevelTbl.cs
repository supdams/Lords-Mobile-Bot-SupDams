// Decompiled with JetBrains decompiler
// Type: TechLevelTbl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TechLevelTbl
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort TechID;
  [MarshalAs(UnmanagedType.U1)]
  public byte Level;
  [MarshalAs(UnmanagedType.U4)]
  public uint LevelupTime;
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
  [MarshalAs(UnmanagedType.U1)]
  public byte ResearchLevel;
  [MarshalAs(UnmanagedType.U2)]
  public ushort RequireTechID1;
  [MarshalAs(UnmanagedType.U1)]
  public byte RequireTechLv1;
  [MarshalAs(UnmanagedType.U2)]
  public ushort RequireTechID2;
  [MarshalAs(UnmanagedType.U1)]
  public byte RequireTechLv2;
  [MarshalAs(UnmanagedType.U2)]
  public ushort RequireTechID3;
  [MarshalAs(UnmanagedType.U1)]
  public byte RequireTechLv3;
  [MarshalAs(UnmanagedType.U2)]
  public ushort RequireTechID4;
  [MarshalAs(UnmanagedType.U1)]
  public byte RequireTechLv4;
  [MarshalAs(UnmanagedType.U4)]
  public uint Strength;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Effect;
  [MarshalAs(UnmanagedType.U4)]
  public uint EffectVal;
}
