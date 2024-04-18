// Decompiled with JetBrains decompiler
// Type: CastleSort
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class CastleSort : IComparer<ushort>
{
  public CastleSkin._SortType type = CastleSkin._SortType.All;

  public int Compare(ushort x, ushort y)
  {
    return this.type == CastleSkin._SortType.All ? this.CompareAll(x, y) : this.CompareOwn(x, y);
  }

  private int CompareAll(ushort x, ushort y)
  {
    CastleSkin castleSkin = GUIManager.Instance.BuildingData.castleSkin;
    CastleSkinTbl recordByKey1 = castleSkin.CastleSkinTable.GetRecordByKey(x);
    CastleSkinTbl recordByKey2 = castleSkin.CastleSkinTable.GetRecordByKey(y);
    bool flag1 = castleSkin.CheckUnlock((byte) x);
    bool flag2 = castleSkin.CheckUnlock((byte) y);
    bool flag3 = castleSkin.CheckSelect((byte) x);
    bool flag4 = castleSkin.CheckSelect((byte) y);
    if (flag1 && !flag2)
      return -1;
    if (!flag1 && flag2 || flag3 && !flag4)
      return 1;
    if (!flag3 && flag4 || (int) recordByKey1.Priority > (int) recordByKey2.Priority)
      return -1;
    return (int) recordByKey1.Priority < (int) recordByKey2.Priority ? 1 : 0;
  }

  private int CompareOwn(ushort x, ushort y)
  {
    CastleSkin castleSkin = GUIManager.Instance.BuildingData.castleSkin;
    CastleSkinTbl recordByKey1 = castleSkin.CastleSkinTable.GetRecordByKey(x);
    CastleSkinTbl recordByKey2 = castleSkin.CastleSkinTable.GetRecordByKey(y);
    if ((int) recordByKey1.Priority > (int) recordByKey2.Priority)
      return -1;
    return (int) recordByKey1.Priority < (int) recordByKey2.Priority ? 1 : 0;
  }
}
