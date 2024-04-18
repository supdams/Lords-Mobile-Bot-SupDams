// Decompiled with JetBrains decompiler
// Type: MailReportHead
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class MailReportHead
{
  public uint SerialID;
  public long Times;
  public byte Index;
  public byte Flag;
  public byte More;
  public byte UnSeen;
  public bool BeSave;
  public bool BeRead;
  public bool BeKept;
  public bool BeKill;
  public bool BeChecked;
  public byte MoreIndex;
  public string DateTime;

  public void SetData(byte flag, long Time = 0)
  {
    this.Flag = flag;
    this.DateTime = GameConstants.GetDateTime(this.Times = Time).ToString("MM/dd/yy HH:mm:ss");
  }
}
