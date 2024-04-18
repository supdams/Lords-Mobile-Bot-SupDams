// Decompiled with JetBrains decompiler
// Type: MailContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class MailContent : MailReportHead
{
  public byte MailType;
  public ushort SenderHead;
  public ushort SenderKindom;
  public string SenderName;
  public string SenderTag;
  public byte ExtraFlag;
  public byte AttachNum;
  public uint ReplyID;
  public string Title;
  public string TitleT;
  public byte TitleLen;
  public string Content;
  public string ContentT;
  public ushort ContentLen;
  public byte LanguageSent;
  public byte LanguageSource;
  public byte LanguageTarget;
  public bool Translation;
  public bool TranslationError;
  public BookmarkMailType[] Attach = new BookmarkMailType[6];
}
