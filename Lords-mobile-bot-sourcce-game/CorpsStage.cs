// Decompiled with JetBrains decompiler
// Type: CorpsStage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct CorpsStage
{
  [MarshalAs(UnmanagedType.U2)]
  public ushort CorpsStageKey;
  [MarshalAs(UnmanagedType.U2)]
  public ushort StageName;
  [MarshalAs(UnmanagedType.U2)]
  public ushort StageForeword;
  [MarshalAs(UnmanagedType.U2)]
  public ushort StageEndword;
  [MarshalAs(UnmanagedType.Struct)]
  public WordVector3 StagePos;
  [MarshalAs(UnmanagedType.Struct)]
  public WordVector3 CastlePos;
  [MarshalAs(UnmanagedType.U2)]
  public ushort CastleRotY;
  [MarshalAs(UnmanagedType.U2)]
  public ushort CastleScale;
  [MarshalAs(UnmanagedType.Struct)]
  public WordVector3 LordPos;
  [MarshalAs(UnmanagedType.U2)]
  public ushort LordScale;
  [MarshalAs(UnmanagedType.U2)]
  public ushort LordTile;
  [MarshalAs(UnmanagedType.U2)]
  public ushort LordName;
  [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
  public CorpsHeroAttribute[] Heros;
  [MarshalAs(UnmanagedType.U2)]
  public ushort BattleForeword;
  [MarshalAs(UnmanagedType.U2)]
  public ushort BattleEndword;
  [MarshalAs(UnmanagedType.U2)]
  public ushort Info;
  [MarshalAs(UnmanagedType.U2)]
  public ushort HeroExp;
  [MarshalAs(UnmanagedType.U2)]
  public ushort LeadExp;
}
