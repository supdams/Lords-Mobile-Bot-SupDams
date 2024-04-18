// Decompiled with JetBrains decompiler
// Type: MarchEventDataType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct MarchEventDataType
{
  public EMarchEventType Type;
  public ushort[] HeroID;
  public uint[][] TroopData;
  public PointCode Point;
  public uint[] ResourceGetCount;
  public uint Crystal;
  public uint MaxOverLoad;
  public POINT_KIND PointKind;
  public byte DesPointLevel;
  public string DesPlayerName;
  public byte bRallyHost;

  public bool IsAmbushCamp()
  {
    return this.bRallyHost == (byte) 1 && this.Type == EMarchEventType.EMET_Camp;
  }

  public bool IsAmbushCampMarching()
  {
    return this.bRallyHost == (byte) 1 && this.Type == EMarchEventType.EMET_CampMarching;
  }

  public bool IsAmbushCampReturn()
  {
    return this.bRallyHost == (byte) 1 && this.Type == EMarchEventType.EMET_CampReturn;
  }
}
