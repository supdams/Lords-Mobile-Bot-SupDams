// Decompiled with JetBrains decompiler
// Type: WatchTowerComparer_LindID
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class WatchTowerComparer_LindID : IComparer<WatchTowerData>
{
  public int Compare(WatchTowerData x, WatchTowerData y)
  {
    if (x.LineID < y.LineID)
      return -1;
    return (int) x.LineID == (int) y.LineID ? 0 : 1;
  }
}
