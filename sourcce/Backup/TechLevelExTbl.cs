// Decompiled with JetBrains decompiler
// Type: TechLevelExTbl
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TechLevelExTbl
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort TechID;
  [MarshalAs(UnmanagedType.U1)]
  public byte Level;
  [MarshalAs(UnmanagedType.U4)]
  public uint PetResource;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
  public uint[] Reserve;
}
