// Decompiled with JetBrains decompiler
// Type: ActItemComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class ActItemComparer : IComparer<ushort>
{
  public int Compare(ushort x, ushort y)
  {
    DataManager instance = DataManager.Instance;
    if ((int) instance.MallEquipmantTable.GetRecordByKey(x).SortValue == (int) instance.MallEquipmantTable.GetRecordByKey(y).SortValue)
      return 0;
    return (int) instance.MallEquipmantTable.GetRecordByKey(x).SortValue < (int) instance.MallEquipmantTable.GetRecordByKey(y).SortValue ? 1 : -1;
  }
}
