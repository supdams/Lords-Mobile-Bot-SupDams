// Decompiled with JetBrains decompiler
// Type: SoldierData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct SoldierData
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort SoldierKey;
  [MarshalAs(UnmanagedType.U1)]
  public byte Kind;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Name;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Icon;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Model;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Caption;
  [MarshalAs(UnmanagedType.U1)]
  public byte SoldierKind;
  [MarshalAs(UnmanagedType.U1)]
  public byte Tier;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Attack;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Defence;
  [MarshalAs(UnmanagedType.U2)]
  public ushort MaxHp;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Speed;
  [MarshalAs(UnmanagedType.U1)]
  public byte Traffic;
  [MarshalAs(UnmanagedType.U1)]
  public byte Strength;
  [MarshalAs(UnmanagedType.U1)]
  public byte Salaries;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Radius;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Skill;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FoodRequire;
  [MarshalAs(UnmanagedType.U2)]
  public ushort StoneRequire;
  [MarshalAs(UnmanagedType.U2)]
  public ushort WoodRequire;
  [MarshalAs(UnmanagedType.U2)]
  public ushort IronRequire;
  [MarshalAs(UnmanagedType.U2)]
  public ushort MoneyRequire;
  [MarshalAs(UnmanagedType.U2)]
  public ushort TimeRequire;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Science;
}
