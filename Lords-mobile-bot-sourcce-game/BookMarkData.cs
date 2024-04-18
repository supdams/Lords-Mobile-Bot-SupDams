// Decompiled with JetBrains decompiler
// Type: BookMarkData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct BookMarkData
{
  public ushort ID;
  public byte Type;
  public CString Name;
  public ushort KingdomID;
  public int MapID;
  public PointCode KingdomPoint;

  public BookMarkData(ushort size)
  {
    this.Name = new CString((int) size);
    this.ID = (ushort) 0;
    this.Type = (byte) 0;
    this.KingdomID = (ushort) 0;
    this.MapID = 0;
    this.KingdomPoint.pointID = (byte) 0;
    this.KingdomPoint.zoneID = (ushort) 0;
  }

  public void Clear()
  {
    this.ID = (ushort) 0;
    this.Type = (byte) 0;
    this.KingdomID = (ushort) 0;
    this.MapID = 0;
    this.KingdomPoint.pointID = (byte) 0;
    this.KingdomPoint.zoneID = (ushort) 0;
    this.Name.ClearString();
  }
}
