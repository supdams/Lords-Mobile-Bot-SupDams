// Decompiled with JetBrains decompiler
// Type: SerialContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class SerialContent
{
  public long Timing;
  public uint Unread;
  public uint Unseen;
  public uint Select;
  public uint Total;
  public uint Count;
  public uint Max;
  public uint New;
  public uint Old;
  public uint Last;
  public uint Fetch;
  public uint Purge;
  public uint Change;
  public bool Pulling;
  public bool Parsing;
  public bool Holding;
  public bool Loading;
  public bool Initial;
  public bool Bulking;
  public bool Metalog;
  public bool Infolog;
  public bool Disavow;
  public uint OldSave;
  public uint NewSave;
  public uint MaxSave;
  public uint LastSave;
  public uint HoldSave;
  public uint FetchSave;
  public uint TotalSave;
  public uint CountSave;
  public uint UnreadSave;
  public MailBox[] Inbox;
  public List<uint> Caliber;
  public CHashTable<uint, SerialBox> SID = new CHashTable<uint, SerialBox>(400);
  public SerialBox[] Serial;
  public Dictionary<uint, SerialBox> Matrix = new Dictionary<uint, SerialBox>();
  public Dictionary<uint, SerialBox> Temp = new Dictionary<uint, SerialBox>();
  public uint SerialNumber;
  public List<MailSaveOrder> Order = new List<MailSaveOrder>();

  public void Clear()
  {
    this.New = this.Count = this.Last = 0U;
    this.Old = this.Change = this.Fetch = 0U;
    Array.Clear((Array) this.Inbox, 0, this.Inbox.Length);
  }

  public void Sort()
  {
    if (this.Count <= 0U)
      return;
    this.Change = 0U;
    Array.Sort<MailBox>(this.Inbox, (IComparer<MailBox>) DataManager.MailDC);
  }
}
