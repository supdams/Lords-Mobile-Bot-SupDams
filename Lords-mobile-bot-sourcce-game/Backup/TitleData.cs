// Decompiled with JetBrains decompiler
// Type: TitleData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TitleData
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort StringID;
  [MarshalAs(UnmanagedType.U1)]
  public byte IconID;
  [MarshalAs(UnmanagedType.U1)]
  public byte isDebuff;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
  public TitleEffectSet[] Effects;
}
