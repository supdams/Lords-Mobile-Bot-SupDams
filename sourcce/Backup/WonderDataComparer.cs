// Decompiled with JetBrains decompiler
// Type: WonderDataComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class WonderDataComparer : IComparer<WonderData>
{
  public int MyCompare(int state, WonderData data1, WonderData data2)
  {
    int num1 = 0;
    int num2 = 0;
    switch (state)
    {
      case 1:
        num1 = (int) DataManager.MapDataController.kingdomData.kingdomID != (int) data1.KingdomID ? (int) data1.KingdomID : 0;
        num2 = (int) DataManager.MapDataController.kingdomData.kingdomID != (int) data2.KingdomID ? (int) data2.KingdomID : 0;
        break;
      case 2:
        num1 = (int) data1.WonderID;
        num2 = (int) data2.WonderID;
        break;
    }
    if (num1 == num2)
      return 0;
    return num1 < num2 ? -1 : 1;
  }

  public int Compare(WonderData x, WonderData y)
  {
    if ((int) x.KingdomID == (int) y.KingdomID && (int) x.WonderID == (int) y.WonderID)
      return 0;
    return (int) x.OpenState == (int) y.OpenState ? ((int) x.KingdomID == (int) y.KingdomID ? this.MyCompare(2, x, y) : this.MyCompare(1, x, y)) : ((int) x.OpenState > (int) y.OpenState ? -1 : 1);
  }
}
