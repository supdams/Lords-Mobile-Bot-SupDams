// Decompiled with JetBrains decompiler
// Type: FavorSerial
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class FavorSerial : SerialContent
{
  public MailSerial Mail;
  public SystemSerial System;
  public ReportSerial Combat;

  public FavorSerial()
  {
    this.Mail = new MailSerial();
    this.System = new SystemSerial();
    this.Combat = new ReportSerial();
    this.Inbox = new MailBox[100];
  }

  public new void Clear()
  {
    base.Clear();
    this.Mail.Clear();
    this.Combat.Clear();
    this.System.Clear();
    this.Mail.Mail.Clear();
    this.Combat.Mail.Clear();
  }
}
