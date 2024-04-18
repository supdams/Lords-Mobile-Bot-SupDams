// Decompiled with JetBrains decompiler
// Type: BagItemDataComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class BagItemDataComparer : IComparer<ushort>
{
  public byte SortType;

  public int Compare(ushort x, ushort y)
  {
    if (this.SortType == (byte) 0)
      return this.BagCompare(x, y);
    if (this.SortType == (byte) 1)
      return this.ShopCompare(x, y);
    if (this.SortType == (byte) 2)
      return this.ShopResourceCompare(x, y);
    return this.SortType == (byte) 3 ? this.BagResourceCompare(x, y) : this.PetBagCompare(x, y);
  }

  public int BagCompare(ushort x, ushort y)
  {
    if ((int) x == (int) y)
      return 0;
    if (x == (ushort) 0)
      return 1;
    if (y == (ushort) 0)
      return -1;
    Equip recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(x);
    Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(y);
    if ((int) recordByKey1.EquipKey != (int) x)
      return (int) recordByKey2.EquipKey == (int) y ? -1 : 1;
    if ((int) recordByKey2.EquipKey != (int) y)
      return -1;
    if ((int) recordByKey1.EquipKey != (int) x)
      return (int) recordByKey2.EquipKey == (int) y ? -1 : 1;
    if ((int) recordByKey2.EquipKey != (int) y)
      return -1;
    byte equipKind1 = recordByKey1.EquipKind;
    byte equipKind2 = recordByKey2.EquipKind;
    if ((int) equipKind1 < (int) equipKind2)
      return -1;
    if ((int) equipKind1 > (int) equipKind2)
      return 1;
    if ((int) recordByKey1.PropertiesInfo[0].Propertieskey < (int) recordByKey2.PropertiesInfo[0].Propertieskey)
      return -1;
    if ((int) recordByKey1.PropertiesInfo[0].Propertieskey > (int) recordByKey2.PropertiesInfo[0].Propertieskey)
      return 1;
    switch (equipKind1)
    {
      case 6:
        if ((int) recordByKey1.PropertiesInfo[0].PropertiesValue < (int) recordByKey2.PropertiesInfo[0].PropertiesValue)
          return -1;
        if ((int) recordByKey1.PropertiesInfo[0].PropertiesValue > (int) recordByKey2.PropertiesInfo[0].PropertiesValue)
          return 1;
        break;
      case 10:
        ushort propertieskey1 = recordByKey1.PropertiesInfo[0].Propertieskey;
        ushort propertieskey2 = recordByKey2.PropertiesInfo[0].Propertieskey;
        if ((int) propertieskey1 > (int) propertieskey2)
          return 1;
        if ((int) propertieskey1 < (int) propertieskey2)
          return -1;
        if (propertieskey1 == (ushort) 30 || propertieskey1 == (ushort) 33 || propertieskey1 == (ushort) 40)
        {
          if ((int) recordByKey1.PropertiesInfo[1].PropertiesValue * (int) recordByKey1.PropertiesInfo[1].Propertieskey < (int) recordByKey2.PropertiesInfo[1].PropertiesValue * (int) recordByKey2.PropertiesInfo[1].Propertieskey)
            return -1;
          if ((int) recordByKey1.PropertiesInfo[1].PropertiesValue * (int) recordByKey1.PropertiesInfo[1].Propertieskey > (int) recordByKey2.PropertiesInfo[1].PropertiesValue * (int) recordByKey2.PropertiesInfo[1].Propertieskey)
            return 1;
        }
        if ((int) x < (int) y)
          return -1;
        if ((int) x > (int) y)
          return 1;
        break;
      case 11:
        if ((int) recordByKey1.PropertiesInfo[1].Propertieskey * (int) recordByKey1.PropertiesInfo[1].PropertiesValue < (int) recordByKey2.PropertiesInfo[1].Propertieskey * (int) recordByKey2.PropertiesInfo[1].PropertiesValue)
          return -1;
        if ((int) recordByKey1.PropertiesInfo[1].Propertieskey * (int) recordByKey1.PropertiesInfo[1].PropertiesValue > (int) recordByKey2.PropertiesInfo[1].Propertieskey * (int) recordByKey2.PropertiesInfo[1].PropertiesValue)
          return 1;
        break;
      case 12:
      case 15:
      case 16:
        if ((int) recordByKey1.PropertiesInfo[1].Propertieskey < (int) recordByKey2.PropertiesInfo[1].Propertieskey)
          return -1;
        if ((int) recordByKey1.PropertiesInfo[1].Propertieskey > (int) recordByKey2.PropertiesInfo[1].Propertieskey)
          return 1;
        if ((int) recordByKey1.PropertiesInfo[1].PropertiesValue < (int) recordByKey2.PropertiesInfo[1].PropertiesValue)
          return -1;
        if ((int) recordByKey1.PropertiesInfo[1].PropertiesValue > (int) recordByKey2.PropertiesInfo[1].PropertiesValue)
          return 1;
        break;
      case 13:
      case 14:
      case 19:
        if ((int) recordByKey1.PropertiesInfo[1].Propertieskey < (int) recordByKey2.PropertiesInfo[1].Propertieskey)
          return -1;
        if ((int) recordByKey1.PropertiesInfo[1].Propertieskey > (int) recordByKey2.PropertiesInfo[1].Propertieskey)
          return 1;
        if ((int) x < (int) y)
          return -1;
        if ((int) x > (int) y)
          return 1;
        break;
      case 18:
        if ((int) recordByKey1.PropertiesInfo[2].Propertieskey < (int) recordByKey2.PropertiesInfo[2].Propertieskey)
          return -1;
        if ((int) recordByKey1.PropertiesInfo[2].Propertieskey > (int) recordByKey2.PropertiesInfo[2].Propertieskey)
          return 1;
        if ((int) recordByKey1.Color < (int) recordByKey2.Color)
          return -1;
        if ((int) recordByKey1.Color > (int) recordByKey2.Color)
          return 1;
        if ((int) x < (int) y)
          return -1;
        if ((int) x > (int) y)
          return 1;
        break;
    }
    return 0;
  }

  public int ShopCompare(ushort x, ushort y)
  {
    if ((int) x == (int) y)
      return 0;
    StoreTbl recordByKey1 = DataManager.Instance.StoreData.GetRecordByKey(x);
    StoreTbl recordByKey2 = DataManager.Instance.StoreData.GetRecordByKey(y);
    Equip recordByKey3 = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey1.ItemID);
    Equip recordByKey4 = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
    if ((int) recordByKey3.EquipKind < (int) recordByKey4.EquipKind)
      return -1;
    if ((int) recordByKey3.EquipKind > (int) recordByKey4.EquipKind)
      return 1;
    if ((int) recordByKey1.ID < (int) recordByKey2.ID)
      return -1;
    return (int) recordByKey1.ID > (int) recordByKey2.ID ? 1 : 0;
  }

  public int ShopResourceCompare(ushort x, ushort y)
  {
    if ((int) x == (int) y)
      return 0;
    StoreTbl recordByKey1 = DataManager.Instance.StoreData.GetRecordByKey(x);
    StoreTbl recordByKey2 = DataManager.Instance.StoreData.GetRecordByKey(y);
    Equip recordByKey3 = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey1.ItemID);
    Equip recordByKey4 = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
    if ((int) recordByKey3.EquipKind < (int) recordByKey4.EquipKind)
      return -1;
    if ((int) recordByKey3.EquipKind > (int) recordByKey4.EquipKind)
      return 1;
    if ((int) recordByKey1.Num < (int) recordByKey2.Num)
      return -1;
    if ((int) recordByKey1.Num > (int) recordByKey2.Num)
      return 1;
    if (recordByKey3.EquipKind == (byte) 10)
    {
      bool flag1 = recordByKey3.PropertiesInfo[0].Propertieskey == (ushort) 49;
      bool flag2 = recordByKey4.PropertiesInfo[0].Propertieskey == (ushort) 49;
      if (!flag1 && flag2)
        return 1;
      if (flag1 && !flag2)
        return -1;
    }
    if ((int) recordByKey3.PropertiesInfo[0].Propertieskey < (int) recordByKey4.PropertiesInfo[0].Propertieskey)
      return -1;
    if ((int) recordByKey3.PropertiesInfo[0].Propertieskey > (int) recordByKey4.PropertiesInfo[0].Propertieskey)
      return 1;
    if (recordByKey3.EquipKind == (byte) 12)
    {
      if ((int) recordByKey3.PropertiesInfo[1].Propertieskey < (int) recordByKey4.PropertiesInfo[1].Propertieskey)
        return -1;
      if ((int) recordByKey3.PropertiesInfo[1].Propertieskey > (int) recordByKey4.PropertiesInfo[1].Propertieskey)
        return 1;
      if ((int) recordByKey3.PropertiesInfo[1].PropertiesValue < (int) recordByKey4.PropertiesInfo[1].PropertiesValue)
        return -1;
      if ((int) recordByKey3.PropertiesInfo[1].PropertiesValue > (int) recordByKey4.PropertiesInfo[1].PropertiesValue)
        return 1;
    }
    if (recordByKey3.EquipKind == (byte) 11)
    {
      if ((int) recordByKey3.PropertiesInfo[1].Propertieskey * (int) recordByKey3.PropertiesInfo[1].PropertiesValue < (int) recordByKey4.PropertiesInfo[1].Propertieskey * (int) recordByKey4.PropertiesInfo[1].PropertiesValue)
        return -1;
      if ((int) recordByKey3.PropertiesInfo[1].Propertieskey * (int) recordByKey3.PropertiesInfo[1].PropertiesValue > (int) recordByKey4.PropertiesInfo[1].Propertieskey * (int) recordByKey4.PropertiesInfo[1].PropertiesValue)
        return 1;
    }
    if (recordByKey3.EquipKind == (byte) 10)
    {
      if ((int) recordByKey3.PropertiesInfo[1].Propertieskey * (int) recordByKey3.PropertiesInfo[1].PropertiesValue < (int) recordByKey4.PropertiesInfo[1].Propertieskey * (int) recordByKey4.PropertiesInfo[1].PropertiesValue)
        return -1;
      if ((int) recordByKey3.PropertiesInfo[1].Propertieskey * (int) recordByKey3.PropertiesInfo[1].PropertiesValue > (int) recordByKey4.PropertiesInfo[1].Propertieskey * (int) recordByKey4.PropertiesInfo[1].PropertiesValue)
        return 1;
    }
    return 0;
  }

  public int BagResourceCompare(ushort x, ushort y)
  {
    if ((int) x == (int) y)
      return 0;
    if (x == (ushort) 0)
      return 1;
    if (y == (ushort) 0)
      return -1;
    Equip recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(x);
    Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(y);
    if ((int) recordByKey1.EquipKey != (int) x)
      return (int) recordByKey2.EquipKey == (int) y ? -1 : 1;
    if ((int) recordByKey2.EquipKey != (int) y || (int) recordByKey1.EquipKind < (int) recordByKey2.EquipKind)
      return -1;
    if ((int) recordByKey1.EquipKind > (int) recordByKey2.EquipKind)
      return 1;
    if (recordByKey1.EquipKind == (byte) 12)
    {
      if ((int) recordByKey1.PropertiesInfo[1].Propertieskey < (int) recordByKey2.PropertiesInfo[1].Propertieskey)
        return -1;
      if ((int) recordByKey1.PropertiesInfo[1].Propertieskey > (int) recordByKey2.PropertiesInfo[1].Propertieskey)
        return 1;
      if (recordByKey1.PropertiesInfo[0].Propertieskey == (ushort) 11 || recordByKey1.PropertiesInfo[0].Propertieskey == (ushort) 16)
      {
        if ((int) recordByKey1.EquipKey < (int) recordByKey2.EquipKey)
          return -1;
        if ((int) recordByKey1.EquipKey > (int) recordByKey2.EquipKey)
          return 1;
      }
    }
    if (recordByKey1.EquipKind == (byte) 6)
    {
      if ((int) recordByKey1.PropertiesInfo[0].Propertieskey < (int) recordByKey2.PropertiesInfo[0].Propertieskey)
        return -1;
      if ((int) recordByKey1.PropertiesInfo[0].Propertieskey > (int) recordByKey2.PropertiesInfo[0].Propertieskey)
        return 1;
      if ((int) recordByKey1.PropertiesInfo[0].PropertiesValue < (int) recordByKey2.PropertiesInfo[0].PropertiesValue)
        return -1;
      if ((int) recordByKey1.PropertiesInfo[0].PropertiesValue > (int) recordByKey2.PropertiesInfo[0].PropertiesValue)
        return 1;
    }
    if ((int) recordByKey1.PropertiesInfo[0].Propertieskey < (int) recordByKey2.PropertiesInfo[0].Propertieskey)
      return -1;
    if ((int) recordByKey1.PropertiesInfo[0].Propertieskey > (int) recordByKey2.PropertiesInfo[0].Propertieskey)
      return 1;
    if ((int) recordByKey1.PropertiesInfo[1].Propertieskey * (int) recordByKey1.PropertiesInfo[1].PropertiesValue < (int) recordByKey2.PropertiesInfo[1].Propertieskey * (int) recordByKey2.PropertiesInfo[1].PropertiesValue)
      return -1;
    return (int) recordByKey1.PropertiesInfo[1].Propertieskey * (int) recordByKey1.PropertiesInfo[1].PropertiesValue > (int) recordByKey2.PropertiesInfo[1].Propertieskey * (int) recordByKey2.PropertiesInfo[1].PropertiesValue ? 1 : 0;
  }

  public int PetBagCompare(ushort x, ushort y)
  {
    PetItem itemData1 = PetManager.Instance.GetItemData((int) x);
    PetItem itemData2 = PetManager.Instance.GetItemData((int) y);
    if (itemData1 != null && itemData2 == null)
      return -1;
    if (itemData1 == null && itemData2 != null)
      return 1;
    if (itemData1 == null && itemData2 == null)
      return 0;
    byte num1 = itemData1.EquipKind;
    byte num2 = itemData2.EquipKind;
    if (num1 == (byte) 0)
      num1 = (byte) 29;
    else if (num1 <= (byte) 30)
      --num1;
    else if (num1 <= (byte) 30)
      num1 -= (byte) 6;
    if (num2 == (byte) 0)
      num2 = (byte) 29;
    else if (num2 <= (byte) 30)
      --num2;
    else if (num2 <= (byte) 30)
      num2 -= (byte) 6;
    if ((int) num1 < (int) num2)
      return -1;
    if ((int) num1 > (int) num2)
      return 1;
    switch ((EItemType) num1)
    {
      case EItemType.EIT_Consumables:
        if ((int) itemData1.PropertiesInfo[0].PropertiesValue < (int) itemData2.PropertiesInfo[0].PropertiesValue)
          return -1;
        if ((int) itemData1.PropertiesInfo[0].PropertiesValue > (int) itemData2.PropertiesInfo[0].PropertiesValue)
          return 1;
        break;
      case EItemType.EIT_CaseByCase:
        if ((int) itemData1.PropertiesInfo[0].Propertieskey < (int) itemData2.PropertiesInfo[0].Propertieskey)
          return -1;
        if ((int) itemData1.PropertiesInfo[0].Propertieskey > (int) itemData2.PropertiesInfo[0].Propertieskey)
          return 1;
        if ((int) itemData1.Color < (int) itemData2.Color)
          return -1;
        if ((int) itemData1.Color > (int) itemData2.Color)
          return 1;
        break;
      case EItemType.EIT_MaterialTreasureBox:
        if ((int) itemData1.SyntheticParts[0].SyntheticItem < (int) itemData2.SyntheticParts[0].SyntheticItem)
          return 1;
        if ((int) itemData1.SyntheticParts[0].SyntheticItem > (int) itemData2.SyntheticParts[0].SyntheticItem)
          return -1;
        if ((int) itemData1.Color < (int) itemData2.Color)
          return 1;
        if ((int) itemData1.Color > (int) itemData2.Color)
          return -1;
        if ((int) itemData1.ItemID < (int) itemData2.ItemID)
          return 1;
        if ((int) itemData1.ItemID > (int) itemData2.ItemID)
          return -1;
        break;
      case EItemType.EIT_EnhanceStone:
        if ((int) itemData1.Quantity < (int) itemData2.Quantity)
          return 1;
        if ((int) itemData1.Quantity > (int) itemData2.Quantity)
          return -1;
        break;
    }
    if ((int) itemData1.ItemID < (int) itemData2.ItemID)
      return -1;
    return (int) itemData1.ItemID > (int) itemData2.ItemID ? 1 : 0;
  }
}
