// Decompiled with JetBrains decompiler
// Type: FastivalSpecialData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct FastivalSpecialData
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U1)]
  public byte GroupID;
  [MarshalAs(UnmanagedType.U4)]
  public uint StoreID;
  [MarshalAs(UnmanagedType.U1)]
  public byte PickupCount;
  [MarshalAs(UnmanagedType.U1)]
  public byte PackNo;
  [MarshalAs(UnmanagedType.U2)]
  public ushort FrameColor;
  [MarshalAs(UnmanagedType.U2)]
  public ushort PicNo;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ItemName;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ItemHint;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ItemID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort AlliGiveBoardCast;
  [MarshalAs(UnmanagedType.U2)]
  public ushort AlliGetBoardCast;
  [MarshalAs(UnmanagedType.U4)]
  public uint UB1;
  [MarshalAs(UnmanagedType.U4)]
  public uint UB2;
}
