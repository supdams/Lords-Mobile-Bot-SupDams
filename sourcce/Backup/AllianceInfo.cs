// Decompiled with JetBrains decompiler
// Type: AllianceInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AllianceInfo
{
  public uint Id;
  public uint Channel;
  public byte Language;
  public AllianceRank Rank;
  public CString Tag;
  public CString Name;
  public string Notice;
  public string Bullet;
  public string Header;
  public CString Leader;
  public ulong Power;
  public uint Money;
  public ushort Emblem;
  public byte Member;
  public byte Applicant;
  public byte Approval;
  public byte Apply;
  public uint[] ApplyList;
  public ushort GiftNum;
  public byte GiftLv;
  public ushort PackItemID;
  public uint PackPoint;
  public uint GiftExp;
  public long ChatId;
  public long ChatMax;
  public ushort KingdomID;
  public long BookmarkTime;
  public byte BulletinFlag;
  public byte NoticeinFlag;
  public byte AMRank;
  public long JoinTime;

  public byte AMMaxDegree
  {
    get
    {
      return DataManager.Instance.AllianceMobilizationDegreeRange.GetRecordByIndex((int) this.AMRank).Range;
    }
  }
}
