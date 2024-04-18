// Decompiled with JetBrains decompiler
// Type: FusionData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct FusionData
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U1)]
  public byte Fusion_Kind;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Fusion_ItemID;
  [MarshalAs(UnmanagedType.U4)]
  public uint FoodRequire;
  [MarshalAs(UnmanagedType.U4)]
  public uint StoneRequire;
  [MarshalAs(UnmanagedType.U4)]
  public uint WoodRequire;
  [MarshalAs(UnmanagedType.U4)]
  public uint IronRequire;
  [MarshalAs(UnmanagedType.U4)]
  public uint MoneyRequire;
  [MarshalAs(UnmanagedType.U4)]
  public uint PetRequire;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
  public ComboBoxItem[] ItemData;
  [MarshalAs(UnmanagedType.U4)]
  public uint TimeRequire;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Science;
}
