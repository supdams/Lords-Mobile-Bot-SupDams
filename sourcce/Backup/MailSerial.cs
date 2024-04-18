// Decompiled with JetBrains decompiler
// Type: MailSerial
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class MailSerial : SerialContent
{
  public List<MailSaveOrder> Saviour = new List<MailSaveOrder>();
  public Dictionary<uint, MailContent> Mail = new Dictionary<uint, MailContent>(100);
  public Dictionary<uint, SubContent> SubMail = new Dictionary<uint, SubContent>(100);

  public MailSerial()
  {
    this.Caliber = new List<uint>(200);
    this.Serial = new SerialBox[200];
    this.Inbox = new MailBox[100];
  }
}
