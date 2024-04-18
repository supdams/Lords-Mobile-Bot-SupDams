// Decompiled with JetBrains decompiler
// Type: PushCallBack
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct PushCallBack
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U1)]
  public byte LowLevel;
  [MarshalAs(UnmanagedType.U1)]
  public byte HighLevel;
  [MarshalAs(UnmanagedType.U1)]
  public byte Hour;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Ube1;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Ube2;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Ube3;
}
