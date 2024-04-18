// Decompiled with JetBrains decompiler
// Type: PetMarchEventDataType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct PetMarchEventDataType
{
  public ushort PetID;
  public PointCode Point;
  public TimeEventDataType MarchEventTime;
  public POINT_KIND DesPointKind;
  public byte DesPointLevel;
  public CString DesPlayerName;

  public void Empty()
  {
    this.PetID = (ushort) 0;
    this.Point.pointID = (byte) 0;
    this.Point.zoneID = (ushort) 0;
    this.MarchEventTime.BeginTime = 0L;
    this.MarchEventTime.RequireTime = 0U;
    this.DesPointLevel = (byte) 0;
    if (this.DesPlayerName == null)
      return;
    this.DesPlayerName.ClearString();
  }
}
