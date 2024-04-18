// Decompiled with JetBrains decompiler
// Type: CorpsStageBattle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CorpsStageBattle
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort CorpsStageBattleKey;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
  public Properties[] PropertiesInfo;
  [MarshalAs(UnmanagedType.U1)]
  public byte WallLevel;
  [MarshalAs(UnmanagedType.U4)]
  public uint MaxWall;
  [MarshalAs(UnmanagedType.U1)]
  public byte Terrain;
  [MarshalAs(UnmanagedType.U1)]
  public byte Weather;
}
