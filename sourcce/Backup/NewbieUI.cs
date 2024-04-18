// Decompiled with JetBrains decompiler
// Type: NewbieUI
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct NewbieUI
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U1)]
  public byte TalkType;
  [MarshalAs(UnmanagedType.U2)]
  public ushort TalkID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort TalkBoxX;
  [MarshalAs(UnmanagedType.U1)]
  public byte TalkBoxX_Sign;
  [MarshalAs(UnmanagedType.U2)]
  public ushort TalkBoxY;
  [MarshalAs(UnmanagedType.U1)]
  public byte TalkBoxY_Sign;
  [MarshalAs(UnmanagedType.U1)]
  public byte ArrowDir;
  [MarshalAs(UnmanagedType.U2)]
  public ushort TouchWidth;
  [MarshalAs(UnmanagedType.U2)]
  public ushort TouchHeight;
}
