// Decompiled with JetBrains decompiler
// Type: ShowMap
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct ShowMap
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort ShowMapID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ListID;
  [MarshalAs(UnmanagedType.U4)]
  public uint ShowTime;
  [MarshalAs(UnmanagedType.U2)]
  public ushort NextListID;
}
