// Decompiled with JetBrains decompiler
// Type: Equip
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Equip
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort EquipKey;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EquipName;
  [MarshalAs(UnmanagedType.U1)]
  public byte Color;
  [MarshalAs(UnmanagedType.U1)]
  public byte NeedLv;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EquipInfo;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EquipPicture;
  [MarshalAs(UnmanagedType.U4)]
  public uint RecoverPrice;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
  public Properties[] PropertiesInfo;
  [MarshalAs(UnmanagedType.U1)]
  public byte EquipKind;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
  public Synthetic[] SyntheticParts;
  [MarshalAs(UnmanagedType.U4)]
  public uint MixPrice;
  [MarshalAs(UnmanagedType.U4)]
  public uint MixTime;
  [MarshalAs(UnmanagedType.U4)]
  public uint ForgingExp;
  [MarshalAs(UnmanagedType.U1)]
  public byte Hide;
  [MarshalAs(UnmanagedType.U1)]
  public byte ActivitySuitIndex;
  [MarshalAs(UnmanagedType.U4)]
  public uint TimedTime;
  [MarshalAs(UnmanagedType.U1)]
  public byte TimedType;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15)]
  public byte[] Reserve;
}
