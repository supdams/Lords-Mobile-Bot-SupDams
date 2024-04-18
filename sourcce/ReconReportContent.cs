// Decompiled with JetBrains decompiler
// Type: ReconReportContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class ReconReportContent : MailReportHead
{
  public ushort KingdomID;
  public ushort CombatlZone;
  public byte CombatPoint;
  public POINT_KIND CombatPointKind;
  public byte AntiScout;
  public byte WatchLevel;
  public ushort SrcKingdomID;
  public string SrcName;
  public string SrcAllianceTag;
  public ushort SrcHead;
  public byte bAmbush;
}
