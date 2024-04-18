// Decompiled with JetBrains decompiler
// Type: CastleSkinTbl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CastleSkinTbl
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Name;
  [MarshalAs(UnmanagedType.U1)]
  public byte Graphic;
  [MarshalAs(UnmanagedType.U1)]
  public byte Priority;
  [MarshalAs(UnmanagedType.U1)]
  public byte PreViewPercentage;
  [MarshalAs(UnmanagedType.U1)]
  public byte UnlockPercentage;
  [MarshalAs(UnmanagedType.U1)]
  public byte EnhancePercentage;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
  public ushort[] Effect;
  [MarshalAs(UnmanagedType.U4)]
  public uint ItemID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort GiftID;
  [MarshalAs(UnmanagedType.U1)]
  public byte GiftNum;
  [MarshalAs(UnmanagedType.U1)]
  public byte DefaultExclamation;
  [MarshalAs(UnmanagedType.U1)]
  public byte byteReserve;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
  public ushort[] Reserve;
}
