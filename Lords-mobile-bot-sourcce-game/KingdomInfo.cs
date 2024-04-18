// Decompiled with JetBrains decompiler
// Type: KingdomInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Runtime.InteropServices;

#nullable disable
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public struct KingdomInfo
{
  public ushort kingdomID;
  public byte kingdomFlag;
  public KINGDOM_PERIOD kingdomPeriod;
  public ushort kingKingdomID;
  public CString kingName;
  public ushort allianceKingdomID;
  public CString allianceTag;
  public CString allianceName;
  public CString kingdomName;
  public ulong kingdomTime;
}
