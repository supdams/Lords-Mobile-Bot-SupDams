// Decompiled with JetBrains decompiler
// Type: MapMonster
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MapMonster
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort Index;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ModelID;
  [MarshalAs(UnmanagedType.U1)]
  public byte HitFrame;
  [MarshalAs(UnmanagedType.U2)]
  public ushort NameID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Xoffset;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Yoffset;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
  public ushort[] Content;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
  public MapTeam[] MapTeamInfo;
  [MarshalAs(UnmanagedType.U2)]
  public ushort CameraHeight;
  [MarshalAs(UnmanagedType.U2)]
  public ushort StageID;
  [MarshalAs(UnmanagedType.U2)]
  public ushort ParticlePackNO;
  [MarshalAs(UnmanagedType.U2)]
  public ushort SoundPackNO;
  [MarshalAs(UnmanagedType.U2)]
  public ushort MapNPCNO;
}
