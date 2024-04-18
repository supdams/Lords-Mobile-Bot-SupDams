// Decompiled with JetBrains decompiler
// Type: SortGiftComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class SortGiftComparer : IComparer<uint>
{
  public int Compare(uint x, uint y)
  {
    DataManager instance = DataManager.Instance;
    AllianceBoxDataType allianceBoxDataType1 = instance.mListGift[x];
    AllianceBoxDataType allianceBoxDataType2 = instance.mListGift[y];
    bool flag;
    if (allianceBoxDataType1.Status == (byte) 0)
    {
      if (allianceBoxDataType2.Status != (byte) 0)
        return -1;
      flag = true;
    }
    else
    {
      if (allianceBoxDataType2.Status == (byte) 0)
        return 1;
      flag = true;
    }
    return flag && allianceBoxDataType1.RcvTime >= allianceBoxDataType2.RcvTime ? 1 : -1;
  }
}
