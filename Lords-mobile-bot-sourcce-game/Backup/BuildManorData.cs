// Decompiled with JetBrains decompiler
// Type: BuildManorData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BuildManorData
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort MapGroup;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ChapterID;
  [MarshalAs(UnmanagedType.U1)]
  public byte SearchPriority;
  [MarshalAs(UnmanagedType.U1)]
  public byte Kind;
  [MarshalAs(UnmanagedType.U2)]
  public ushort bPosionX;
  [MarshalAs(UnmanagedType.U2)]
  public ushort bPosionY;
  [MarshalAs(UnmanagedType.U2)]
  public ushort bPosionZ;
  [MarshalAs(UnmanagedType.U2)]
  public ushort mPosionX;
  [MarshalAs(UnmanagedType.U2)]
  public ushort mPosionY;
  [MarshalAs(UnmanagedType.U2)]
  public ushort mPosionZ;
}
