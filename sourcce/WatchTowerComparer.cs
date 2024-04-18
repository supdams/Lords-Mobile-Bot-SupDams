// Decompiled with JetBrains decompiler
// Type: WatchTowerComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;

#nullable disable
public class WatchTowerComparer : IComparer<WatchTowerSortData>
{
  public int Compare(WatchTowerSortData x, WatchTowerSortData y)
  {
    return (x.LineType == (byte) 0 ? DataManager.Instance.mtmpIdx[(IntPtr) (x.ListIdx - 1U)] : DataManager.Instance.tmp_WatchTowerData[(int) x.ListIdx]).MarchTimeData.BeginTime < (y.LineType == (byte) 0 ? DataManager.Instance.mtmpIdx[(IntPtr) (y.ListIdx - 1U)] : DataManager.Instance.tmp_WatchTowerData[(int) y.ListIdx]).MarchTimeData.BeginTime ? -1 : 1;
  }
}
