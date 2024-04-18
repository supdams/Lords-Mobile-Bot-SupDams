// Decompiled with JetBrains decompiler
// Type: MarchOffset
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MarchOffset
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U1)]
  public byte Kind;
  [MarshalAs(UnmanagedType.U1)]
  public byte AttackerDirection;
  [MarshalAs(UnmanagedType.U1)]
  public byte SignedX;
  [MarshalAs(UnmanagedType.U2)]
  public ushort OffsetX;
  [MarshalAs(UnmanagedType.U1)]
  public byte SignedY;
  [MarshalAs(UnmanagedType.U2)]
  public ushort OffsetY;
}
