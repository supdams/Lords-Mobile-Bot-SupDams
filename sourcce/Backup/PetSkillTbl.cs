// Decompiled with JetBrains decompiler
// Type: PetSkillTbl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PetSkillTbl
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Name;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Icon;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Effect1;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Effect2;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Effect3;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Status;
  [MarshalAs(UnmanagedType.U1)]
  public byte Type;
  [MarshalAs(UnmanagedType.U1)]
  public byte Kind;
  [MarshalAs(UnmanagedType.U1)]
  public byte Subject;
  [MarshalAs(UnmanagedType.U1)]
  public byte Class;
  [MarshalAs(UnmanagedType.U1)]
  public byte UpLevel;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Diamond;
  [MarshalAs(UnmanagedType.U1)]
  public byte ShowReport;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ZValue;
  [MarshalAs(UnmanagedType.U2)]
  public ushort XValue;
  [MarshalAs(UnmanagedType.U2)]
  public ushort YValue;
  [MarshalAs(UnmanagedType.U2)]
  public ushort AValue;
  [MarshalAs(UnmanagedType.U2)]
  public ushort BValue;
  [MarshalAs(UnmanagedType.U2)]
  public ushort CValue;
  [MarshalAs(UnmanagedType.U2)]
  public ushort DValue;
  [MarshalAs(UnmanagedType.U2)]
  public ushort CoolDown;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Fatigue;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Experience;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
  public byte[] OpenLevel;
  [MarshalAs(UnmanagedType.U2)]
  public ushort DamageRange;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HitSound;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FlyParticle;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FlySound;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SoundNo;
  [MarshalAs(UnmanagedType.U2)]
  public ushort EffectTime;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Reserved1;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Reserved2;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Reserved3;
}
