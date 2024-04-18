// Decompiled with JetBrains decompiler
// Type: MallDataComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class MallDataComparer : IComparer<MallDataType>
{
  public int Compare(MallDataType x, MallDataType y)
  {
    if (x.Type != ETreasureType.ETST_SHLevelUp && y.Type == ETreasureType.ETST_SHLevelUp)
      return 1;
    if (x.Type == ETreasureType.ETST_SHLevelUp && y.Type != ETreasureType.ETST_SHLevelUp)
      return -1;
    if (MallManager.Instance.bNewbie)
    {
      if (x.Type != ETreasureType.ETST_Newbie && y.Type == ETreasureType.ETST_Newbie)
        return 1;
      if (x.Type == ETreasureType.ETST_Newbie && y.Type != ETreasureType.ETST_Newbie)
        return -1;
    }
    if ((int) x.RenderWeight < (int) y.RenderWeight)
      return 1;
    return (int) x.RenderWeight > (int) y.RenderWeight ? -1 : 0;
  }
}
