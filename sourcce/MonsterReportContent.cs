// Decompiled with JetBrains decompiler
// Type: MonsterReportContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class MonsterReportContent : MailReportHead
{
  public ushort KindgomID;
  public ushort Zone;
  public byte Point;
  public byte Result;
  public ushort Head;
  public ushort MonsterID;
  public byte MonsterLv;
  public uint BeginHPPercent;
  public uint EndHPPercent;
  public uint MonsterMaxHP;
  public uint Exp;
  public ushort[] HeroID;
  public uint[] HeroExp;
  public MonsterReportContent.HeroDataType[] HeroData;
  public byte SequentialDamageTimes;
  public byte EffectiveDamageTimes;
  public MonsterReportContent.MonsterDataType AttrScale;
  public ushort RandomSeed;
  public byte RandomGap;
  public uint Version;
  public uint PatchNo;
  public byte ItemLen;
  public MonsterReportContent.ItemDataType[] Item;
  public string AllianceTag;

  public class MonsterDataType
  {
    public byte ActionTimes;
    public uint SequentialDamageScale;
    public uint DamageScale;
    public uint MaxHPScale;
    public uint HealingScale;
    public ushort InitMP;
  }

  public class HeroDataType
  {
    public byte SkillLV1;
    public byte SkillLV2;
    public byte SkillLV3;
    public byte SkillLV4;
    public byte LV;
    public byte Star;
    public byte Enhance;
    public byte Equip;
  }

  public class ItemDataType
  {
    public ushort ItemID;
    public ushort Num;
    public byte ItemRank;
  }
}
