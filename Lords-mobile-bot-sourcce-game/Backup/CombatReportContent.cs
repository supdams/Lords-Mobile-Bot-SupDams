// Decompiled with JetBrains decompiler
// Type: CombatReportContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class CombatReportContent : MailReportHead
{
  public ushort KingdomID;
  public ushort CombatlZone;
  public byte CombatPoint;
  public POINT_KIND CombatPointKind;
  public byte Side;
  public ushort AssaultKingdomID;
  public string AssaultAllianceTag;
  public string AssaultName;
  public ushort DefenceKingdomID;
  public string DefenceAllianceTag;
  public string DefenceName;
  public CombatReportResultType Result;
  public int[] Resource;
  public CombatHeroExpData[] HeroData;
  public uint EarnLordExp;
  public uint EarnHeroExp;
  public ulong DetailAutoID;
  public int DetailDbServerID;
  public int AccessKey;
  public byte DetailSelfIndex;
  public ECombatReportCaptureResultType CaptureResult;
  public CombatSummaryContent Summary;
  public uint Version;
  public uint PatchNo;
  public byte Atkcoord;
  public byte Defcoord;
  public uint PetSkillPatchNo;
  public ushort[] m_AssaultPetSkill_ID;
  public byte[] m_AssaultPetSkill_LV;
  public ushort[] m_DefencePetSkill_ID;
  public byte[] m_DefencePetSkill_LV;
}
