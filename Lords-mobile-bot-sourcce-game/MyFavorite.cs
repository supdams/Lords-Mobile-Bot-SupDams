// Decompiled with JetBrains decompiler
// Type: MyFavorite
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class MyFavorite
{
  public uint Serial;
  public byte MailVer;
  public MailType Type;
  public MailType Kind;
  public SerialBox Box;
  public MailContent Mail;
  public CombatReport Combat;
  public NoticeContent System;

  public MyFavorite(MailType type = MailType.EMAIL_MAX, uint Id = 0)
  {
    this.Kind = this.Type = type;
    this.Serial = Id;
  }
}
