// Decompiled with JetBrains decompiler
// Type: MobilizationGroupBroudUnit
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public class MobilizationGroupBroudUnit
{
  public uint AlliacneID;
  public CString AllianceTag;
  public CString Name;
  public uint Score;
  public int ChangeRank;
  public int Rank;

  public MobilizationGroupBroudUnit()
  {
    this.AllianceTag = StringManager.Instance.SpawnString();
    this.Name = StringManager.Instance.SpawnString();
  }
}
