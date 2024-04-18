// Decompiled with JetBrains decompiler
// Type: SortNonFightHeroIDComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class SortNonFightHeroIDComparer : IComparer<uint>
{
  public int MyCompare(int state, CurHeroData data1, CurHeroData data2)
  {
    int num1 = 0;
    int num2 = 0;
    switch (state)
    {
      case 1:
        num1 = (int) data1.Star;
        num2 = (int) data2.Star;
        break;
      case 2:
        num1 = (int) data1.Enhance;
        num2 = (int) data2.Enhance;
        break;
      case 3:
        num1 = (int) data1.Level;
        num2 = (int) data2.Level;
        break;
      case 4:
        num1 = (int) data1.ID;
        num2 = (int) data2.ID;
        break;
    }
    return num1 > num2 ? -1 : 1;
  }

  public int Compare(uint x, uint y)
  {
    CurHeroData data1 = DataManager.Instance.curHeroData[(uint) (ushort) x];
    CurHeroData data2 = DataManager.Instance.curHeroData[(uint) (ushort) y];
    ushort leaderId = DataManager.Instance.GetLeaderID();
    if ((int) data2.ID == (int) leaderId && (int) data1.ID != (int) leaderId)
      return 1;
    return (int) data1.ID == (int) leaderId && (int) data2.ID != (int) leaderId ? -1 : ((int) data1.Star != (int) data2.Star ? this.MyCompare(1, data1, data2) : ((int) data1.Enhance != (int) data2.Enhance ? this.MyCompare(2, data1, data2) : ((int) data1.Level != (int) data2.Level ? this.MyCompare(3, data1, data2) : this.MyCompare(4, data1, data2))));
  }
}
