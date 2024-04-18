// Decompiled with JetBrains decompiler
// Type: PetReportContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class PetReportContent : MailReportHead
{
  public ushort KindgomID;
  public ushort Zone;
  public byte Point;
  public byte Kind;
  public byte Side;
  public ushort AssaultKingdomID;
  public string AssaultAllianceTag;
  public string AssaultName;
  public ushort AssaultCapitalZone;
  public byte AssaultCapitalPoint;
  public byte AssaultLevel;
  public ushort AssaultHead;
  public byte AssaultVIPLevel;
  public byte AssaultAllianceRank;
  public ushort DefenceKingdomID;
  public string DefenceAllianceTag;
  public string DefenceName;
  public ushort DefenceCapitalZone;
  public byte DefenceCapitalPoint;
  public byte DefenceLevel;
  public ushort DefenceHead;
  public byte DefenceVIPLevel;
  public byte DefenceAllianceRank;
  public uint PatchNo;
  public ushort PetID;
  public byte PetStar;
  public ushort SkillID;
  public byte SkillLevel;
  public PetReportResultType Result;
  public uint[] Resource;
  public ulong LostPower;
  public uint TotalInjure;
  public uint TotalDead;
  public uint[] InjureTroops;
  public uint[] DeadTroops;
  public uint WallDamage;
}
