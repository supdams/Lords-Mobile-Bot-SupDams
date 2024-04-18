// Decompiled with JetBrains decompiler
// Type: ItemDataComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class ItemDataComparer : IComparer<ushort>
{
  public int Compare(ushort x, ushort y)
  {
    if ((int) x == (int) y)
      return 0;
    Equip recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(x);
    Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(y);
    if (DataManager.Instance.GetCurItemQuantity(x, (byte) 0) == (ushort) 0)
      return 1;
    if ((int) recordByKey1.EquipKey != (int) x)
      return (int) recordByKey2.EquipKey == (int) y ? -1 : 1;
    if ((int) recordByKey2.EquipKey != (int) y)
      return -1;
    byte num1 = recordByKey1.EquipKind;
    byte num2 = recordByKey2.EquipKind;
    if (num1 == (byte) 0)
      num1 = (byte) 30;
    else if (num1 <= (byte) 5)
      ++num1;
    else if (num1 <= (byte) 30)
      num1 -= (byte) 6;
    if (num2 == (byte) 0)
      num2 = (byte) 30;
    else if (num2 <= (byte) 5)
      ++num2;
    else if (num2 <= (byte) 30)
      num2 -= (byte) 6;
    if ((int) num1 < (int) num2)
      return -1;
    if ((int) num1 > (int) num2)
      return 1;
    if ((int) recordByKey1.PropertiesInfo[0].Propertieskey < (int) recordByKey2.PropertiesInfo[0].Propertieskey)
      return -1;
    if ((int) recordByKey1.PropertiesInfo[0].Propertieskey > (int) recordByKey2.PropertiesInfo[0].Propertieskey)
      return 1;
    if (num1 == (byte) 6 || num1 == (byte) 7)
    {
      if ((int) recordByKey1.PropertiesInfo[0].PropertiesValue < (int) recordByKey2.PropertiesInfo[0].PropertiesValue)
        return -1;
      if ((int) recordByKey1.PropertiesInfo[0].PropertiesValue > (int) recordByKey2.PropertiesInfo[0].PropertiesValue)
        return 1;
    }
    if ((int) recordByKey1.Color < (int) recordByKey2.Color)
      return -1;
    if ((int) recordByKey1.Color > (int) recordByKey2.Color)
      return 1;
    if ((int) recordByKey1.NeedLv < (int) recordByKey2.NeedLv)
      return -1;
    if ((int) recordByKey1.NeedLv > (int) recordByKey2.NeedLv)
      return 1;
    if ((int) x < (int) y)
      return -1;
    return (int) x > (int) y ? 1 : 0;
  }
}
