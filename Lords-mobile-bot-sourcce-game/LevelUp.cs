// Decompiled with JetBrains decompiler
// Type: LevelUp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct LevelUp
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort LevelUpKey;
  [MarshalAs(UnmanagedType.U4)]
  public uint KingdomExp;
  [MarshalAs(UnmanagedType.U4)]
  public uint HeroExp;
  [MarshalAs(UnmanagedType.U1)]
  public byte Morale;
  [MarshalAs(UnmanagedType.U4)]
  public uint AddForce;
  [MarshalAs(UnmanagedType.U1)]
  public byte AddCoin;
  [MarshalAs(UnmanagedType.U2)]
  public ushort BattleHeroExp;
  [MarshalAs(UnmanagedType.U2)]
  public ushort BattleHeroLeadExp;
  [MarshalAs(UnmanagedType.U2)]
  public ushort PrisonEffect;
}
