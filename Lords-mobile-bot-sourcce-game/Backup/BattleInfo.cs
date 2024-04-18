// Decompiled with JetBrains decompiler
// Type: BattleInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct BattleInfo
{
  public ushort RandomSeed;
  public ushort RandomGap;
  public byte BattleType;
  public byte StageKind;
  public ushort StageID;
  public byte PrimarySide;
}
