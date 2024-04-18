// Decompiled with JetBrains decompiler
// Type: TroopLeaderType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct TroopLeaderType
{
  public ushort HeroID;
  public byte Rank;
  public byte Star;

  public TroopLeaderType(ushort heroID, byte rank, byte star)
  {
    this.HeroID = heroID;
    this.Rank = rank;
    this.Star = star;
  }
}
