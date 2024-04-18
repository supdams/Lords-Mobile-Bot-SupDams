// Decompiled with JetBrains decompiler
// Type: MapLine
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class MapLine
{
  public uint lineID;
  public CString playerName;
  public CString allianceTag;
  public ushort kingdomID;
  public PointCode start;
  public PointCode end;
  public ulong begin;
  public uint during;
  public uint EXbegin;
  public uint EXduring;
  public byte lineFlag;
  public Vector2 zoneMax;
  public Vector2 zoneMin;
  public double Slope;
  public double YIntercept;
  public double XIntercept;
  public int[] ZoneIDTable = new int[8];
  public ushort zoneNum;
  public byte baseFlag;
  public ushort emojiID;
  public GameObject lineObject;

  public MapLine()
  {
    this.playerName = new CString(13);
    this.allianceTag = new CString(4);
    this.MapLineInit();
  }

  public void MapLineInit()
  {
    this.playerName.ClearString();
    this.allianceTag.ClearString();
    this.lineID = 1048576U;
    this.begin = 0UL;
    this.during = 0U;
    this.lineFlag = (byte) 0;
    this.zoneNum = (ushort) 0;
    this.Slope = this.YIntercept = this.XIntercept = 0.0;
    if (this.ZoneIDTable != null)
    {
      for (int index = 0; index < this.ZoneIDTable.Length; ++index)
        this.ZoneIDTable[index] = (int) this.lineID;
    }
    this.lineObject = (GameObject) null;
  }
}
