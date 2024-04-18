// Decompiled with JetBrains decompiler
// Type: PetTbl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PetTbl
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HeroID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Name;
  [MarshalAs(UnmanagedType.U1)]
  public byte TexType;
  [MarshalAs(UnmanagedType.U1)]
  public byte Rare;
  [MarshalAs(UnmanagedType.U2)]
  public ushort MapRatio;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
  public _PetRatio[] PetRatio;
  [MarshalAs(UnmanagedType.U2)]
  public ushort CameraAngle;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SoulID;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
  public ushort[] PetSkill;
  [MarshalAs(UnmanagedType.U1)]
  public byte Army;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
  public ushort[] PetAttr;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
  public ushort[] EffectRatio;
  [MarshalAs(UnmanagedType.Struct)]
  public _PetRatio StartupRatio;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
  public ushort[] Reserve;
}
