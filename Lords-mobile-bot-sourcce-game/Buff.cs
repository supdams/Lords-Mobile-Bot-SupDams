// Decompiled with JetBrains decompiler
// Type: Buff
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Buff
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort BuffKey;
  [MarshalAs(UnmanagedType.U1)]
  public byte StateBehavior;
  [MarshalAs(UnmanagedType.U1)]
  public byte EffectNumber;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Length;
  [MarshalAs(UnmanagedType.U2)]
  public ushort StepTime;
  [MarshalAs(UnmanagedType.U1)]
  public byte SpecialEffects;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SpecialEffectValue;
  [MarshalAs(UnmanagedType.U1)]
  public byte ReplaceGroups;
  [MarshalAs(UnmanagedType.U1)]
  public byte ReplaceOrder;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Particle;
  [MarshalAs(UnmanagedType.U1)]
  public byte ParticlePos;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HitParticle;
  [MarshalAs(UnmanagedType.U1)]
  public byte ColorModify;
  [MarshalAs(UnmanagedType.U1)]
  public byte FaceCamera;
}
