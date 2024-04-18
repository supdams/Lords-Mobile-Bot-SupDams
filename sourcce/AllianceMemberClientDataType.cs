// Decompiled with JetBrains decompiler
// Type: AllianceMemberClientDataType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct AllianceMemberClientDataType
{
  public long UserId;
  public ushort Head;
  public string Name;
  public string NickName;
  public AllianceRank Rank;
  public ulong Power;
  public ulong TroopKillNum;
  public long LogoutTime;

  public AllianceMemberClientDataType(int len = 0)
  {
    this.UserId = 0L;
    this.LogoutTime = 0L;
    this.TroopKillNum = 0UL;
    this.Power = 0UL;
    this.Head = (ushort) 0;
    this.Rank = AllianceRank.RANK1;
    this.NickName = (string) null;
    this.Name = (string) null;
  }
}
