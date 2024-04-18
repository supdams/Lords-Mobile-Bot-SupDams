// Decompiled with JetBrains decompiler
// Type: Hero
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Hero
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort HeroKey;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HeroTitle;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HeroName;
  [MarshalAs(UnmanagedType.U1)]
  public byte defaultStar;
  [MarshalAs(UnmanagedType.U1)]
  public byte HeroType;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Description;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Summary;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Graph;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Modle;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Pos;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Radius;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Height;
  [MarshalAs(UnmanagedType.U2)]
  public ushort AI;
  [MarshalAs(UnmanagedType.Struct)]
  public HeroAttribute DefaultAtt;
  [MarshalAs(UnmanagedType.U2)]
  public ushort MaxHealth;
  [MarshalAs(UnmanagedType.U2)]
  public ushort AttackDamage;
  [MarshalAs(UnmanagedType.U2)]
  public ushort AbilityPower;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Armor;
  [MarshalAs(UnmanagedType.U2)]
  public ushort MagicResist;
  [MarshalAs(UnmanagedType.U2)]
  public ushort PhysiclaCrit;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SpellCrit;
  [MarshalAs(UnmanagedType.Struct)]
  public HeroAttribute StarUp;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
  public ushort[] AttackPower;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
  public HeroAttack[] HeroAttackInfo;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SoulStone;
  [MarshalAs(UnmanagedType.U1)]
  public byte SoldierKind;
  [MarshalAs(UnmanagedType.U2)]
  public ushort GroupSkill1;
  [MarshalAs(UnmanagedType.U2)]
  public ushort GroupSkill2;
  [MarshalAs(UnmanagedType.U2)]
  public ushort GroupSkill3;
  [MarshalAs(UnmanagedType.U2)]
  public ushort GroupSkill4;
  [MarshalAs(UnmanagedType.U1)]
  public byte TextureNo;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Scale;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HurtSound;
  [MarshalAs(UnmanagedType.U2)]
  public ushort DyingSound;
  [MarshalAs(UnmanagedType.U1)]
  public byte bShowHeroStone;
  [MarshalAs(UnmanagedType.U2)]
  public ushort CameraDistance;
  [MarshalAs(UnmanagedType.U2)]
  public ushort CameraScaleRate;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EnergyAfterKill;
  [MarshalAs(UnmanagedType.U2)]
  public ushort CameraScaleRate_C;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Camera_Horizontal;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Camera_Angle_Prison;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EquipEX;
  [MarshalAs(UnmanagedType.U1)]
  public byte SupportShowType;
  [MarshalAs(UnmanagedType.U2)]
  public ushort CameraYAxis_Prison;
  [MarshalAs(UnmanagedType.U2)]
  public ushort CameraXAxis_Prison;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HitParticleScaleRate;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ResidentEffect;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ParticlePackNo;
  [MarshalAs(UnmanagedType.U2)]
  public ushort AudioPackNo;
}
