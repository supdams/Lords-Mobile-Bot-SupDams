// Decompiled with JetBrains decompiler
// Type: MapDamageEffTb
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MapDamageEffTb
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort RangeTbID;
  [MarshalAs(UnmanagedType.U1)]
  public byte CrossID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort BeginID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort AttackID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EndID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort PaltformKey;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FireSound;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FireParticle;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FireParticleDuring;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HitSound;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HitParticle;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HitParticleDuring;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
  public PetSkillLineStyle[] LineStyle;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ParticlePakNO;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SoundPakNO;
}
