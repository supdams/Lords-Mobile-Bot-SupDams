// Decompiled with JetBrains decompiler
// Type: CombatReport
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class CombatReport : MailReportHead
{
  public new uint SerialID;
  public PetReportContent Pet;
  public ResourceReportContent Resource;
  public MonsterReportContent Monster;
  public ScoutReportContent Scout;
  public ReconReportContent Recon;
  public CombatCollectReport Type;
  public GatherReportContent Gather;
  public CombatReportContent Combat;
  public NPCScoutReportContent NPCScout;
  public NPCCombatReportContent NPCCombat;

  public CombatReport(uint Id = 0, CombatCollectReport Kind = CombatCollectReport.CCR_BATTLE)
  {
    this.SerialID = Id;
    this.Type = Kind;
  }
}
