// Decompiled with JetBrains decompiler
// Type: MailData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
[Serializable]
public struct MailData
{
  public uint Total;
  public uint Unread;
  public uint MaxSerial;
  public uint NewSerial;
  public uint ReportTotal;
  public uint ReportUnread;
  public uint ReportMaxSerial;
  public uint ReportNewSerial;
  public uint ReportOldSerial;
  public MailSerial MailSerial;
  public FavorSerial FavorSerial;
  public ReportSerial ReportSerial;
  public SystemSerial SystemSerial;
  public uint MailPacksize;
  public ushort MyFavorite;
  public long UserId;
  public bool Loaded;
  public bool Failed;
  public bool Refresh;
  public long Caliber;
  public MailSave Flag;
}
