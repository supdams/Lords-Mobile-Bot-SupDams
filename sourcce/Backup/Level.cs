// Decompiled with JetBrains decompiler
// Type: Level
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct Level
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort LevelKey;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
  public ushort[] Team;
  [MarshalAs(UnmanagedType.U2)]
  public ushort TreasureNo;
  [MarshalAs(UnmanagedType.U2)]
  public ushort LevelInfoNo;
  [MarshalAs(UnmanagedType.U2)]
  public ushort LeadLV;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Money;
  [MarshalAs(UnmanagedType.U2)]
  public ushort TalkBefore;
  [MarshalAs(UnmanagedType.U2)]
  public ushort TalkAfter;
}
