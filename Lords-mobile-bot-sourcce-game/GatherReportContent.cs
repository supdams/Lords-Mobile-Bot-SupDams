// Decompiled with JetBrains decompiler
// Type: GatherReportContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class GatherReportContent
{
  public ushort KingdomID;
  public ushort GatherZone;
  public byte GatherPoint;
  public POINT_KIND GatherPointKind;
  public byte GatherPointLevel;
  public uint Resource;
  public byte HeroNum;
  public byte ItemLen;
  public byte[] Item;
  public GatherHeroExpData[] mHero;
  public ResourceItem[] mResourceItem;
}
