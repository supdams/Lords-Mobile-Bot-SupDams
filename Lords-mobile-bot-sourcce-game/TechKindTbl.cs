// Decompiled with JetBrains decompiler
// Type: TechKindTbl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TechKindTbl
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort TechKind;
  [MarshalAs(UnmanagedType.U2)]
  public ushort KindName;
  [MarshalAs(UnmanagedType.U1)]
  public byte Graphic;
  [MarshalAs(UnmanagedType.U1)]
  public byte Priority;
  [MarshalAs(UnmanagedType.U1)]
  public byte ResearchLevel;
  [MarshalAs(UnmanagedType.U1)]
  public byte ConditionalType;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Parm;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
  public uint[] Reserve;
}
