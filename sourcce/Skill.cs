// Decompiled with JetBrains decompiler
// Type: Skill
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Skill
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort SkillKey;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SkillName;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SkillIcon;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Describe;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ValueInfo;
  [MarshalAs(UnmanagedType.U1)]
  public byte SkillType;
  [MarshalAs(UnmanagedType.U1)]
  public byte SkillKind;
  [MarshalAs(UnmanagedType.U2)]
  public ushort CoolDown;
  [MarshalAs(UnmanagedType.U1)]
  public byte InFightingCD;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SkillDistance;
  [MarshalAs(UnmanagedType.U1)]
  public byte HurtKind;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HurtAddition;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HurtValue;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HurtIncreaseValue;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Rangeparameter1;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Rangeparameter2;
  [MarshalAs(UnmanagedType.U2)]
  public ushort TargetState;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SelfState;
  [MarshalAs(UnmanagedType.U2)]
  public ushort StateAddition;
  [MarshalAs(UnmanagedType.U2)]
  public ushort StateValue;
  [MarshalAs(UnmanagedType.U2)]
  public ushort StateIncreaseValue;
  [MarshalAs(UnmanagedType.U2)]
  public ushort PreFireParticle;
  [MarshalAs(UnmanagedType.U1)]
  public byte PreFireParticlePos;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FireParticle;
  [MarshalAs(UnmanagedType.U1)]
  public byte FireParticlePos;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FireVocalDelay;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FireVocal;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FireSoundDelay;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FireSound;
  [MarshalAs(UnmanagedType.U2)]
  public ushort UltraHitSound;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HitParticle;
  [MarshalAs(UnmanagedType.U1)]
  public byte HitParticlePos;
  [MarshalAs(UnmanagedType.U2)]
  public ushort RangeHitParticle;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HitSound;
  [MarshalAs(UnmanagedType.U2)]
  public ushort UltraParticle;
  [MarshalAs(UnmanagedType.U1)]
  public byte UltraParticlePos;
  [MarshalAs(UnmanagedType.U2)]
  public ushort UltraSound;
  [MarshalAs(UnmanagedType.U1)]
  public byte FlyTarget;
  [MarshalAs(UnmanagedType.U1)]
  public byte FlyType;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FlyParticle;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FlySound;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FlyRate;
  [MarshalAs(UnmanagedType.U1)]
  public byte IsShake;
  [MarshalAs(UnmanagedType.U1)]
  public byte WorkingAI;
  [MarshalAs(UnmanagedType.U2)]
  public ushort RecvEnergy;
}
