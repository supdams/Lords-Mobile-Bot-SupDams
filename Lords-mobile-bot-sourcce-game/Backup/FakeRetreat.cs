// Decompiled with JetBrains decompiler
// Type: FakeRetreat
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct FakeRetreat
{
  public EUnitSide unitSide;
  public ELineColor lineColor;
  public PointCode point;
  public PointCode point2;
  public EMarchEventType lineFlag;
  public CString playerName;
  public CString allianceTag;
  public byte flag;
  public ushort emoji;

  public FakeRetreat(int i)
  {
    this.unitSide = EUnitSide.BLUE;
    this.lineColor = ELineColor.BLUE;
    this.point = new PointCode();
    this.point2 = new PointCode();
    this.lineFlag = EMarchEventType.EMET_Standby;
    this.flag = (byte) 0;
    this.playerName = new CString(13);
    this.allianceTag = new CString(4);
    this.emoji = (ushort) 0;
  }
}
