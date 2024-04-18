// Decompiled with JetBrains decompiler
// Type: ReportSerial
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class ReportSerial : SerialContent
{
  public Dictionary<uint, CombatReport> Mail = new Dictionary<uint, CombatReport>(100);
  public List<uint> Gather = new List<uint>(10);
  public List<uint> Resource = new List<uint>(10);
  public List<uint> AntiScout = new List<uint>(10);
  public uint AntiScoutID;
  public uint GatheringID;
  public uint ResourceID;

  public ReportSerial()
  {
    this.Caliber = new List<uint>(230);
    this.Serial = new SerialBox[230];
    this.Inbox = new MailBox[400];
  }
}
