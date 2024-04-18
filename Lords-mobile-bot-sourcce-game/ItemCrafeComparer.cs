// Decompiled with JetBrains decompiler
// Type: ItemCrafeComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class ItemCrafeComparer : IComparer<ItemCraftDataType>
{
  public int Compare(ItemCraftDataType x, ItemCraftDataType y)
  {
    PetManager instance1 = PetManager.Instance;
    DataManager instance2 = DataManager.Instance;
    Equip recordByKey1 = instance2.EquipTable.GetRecordByKey(x.ItemID);
    Equip recordByKey2 = instance2.EquipTable.GetRecordByKey(y.ItemID);
    bool flag = false;
    if (recordByKey1.EquipKind == (byte) 30)
    {
      if (recordByKey2.EquipKind != (byte) 30)
        return -1;
      flag = true;
    }
    else if (recordByKey1.EquipKind != (byte) 30)
    {
      if (recordByKey2.EquipKind == (byte) 30)
        return 1;
      if (recordByKey1.EquipKind == (byte) 29)
      {
        if (recordByKey2.EquipKind != (byte) 29)
          return -1;
        PetData petData1 = instance1.FindPetData(instance2.EquipTable.GetRecordByKey(x.ItemID).SyntheticParts[0].SyntheticItem);
        PetData petData2 = instance1.FindPetData(instance2.EquipTable.GetRecordByKey(y.ItemID).SyntheticParts[0].SyntheticItem);
        if (petData1 != null)
        {
          if (petData2 != null)
          {
            if (petData1.Enhance == (byte) 2)
            {
              if (petData2.Enhance != (byte) 2)
                return 1;
              flag = true;
            }
            else
            {
              if (petData2.Enhance == (byte) 2)
                return -1;
              flag = true;
            }
          }
          else
          {
            if (petData1.Enhance == (byte) 2)
              return 1;
            flag = true;
          }
        }
        else if (petData2 != null)
        {
          if (petData2.Enhance == (byte) 2)
            return -1;
          flag = true;
        }
        else
          flag = true;
      }
      else
      {
        if (recordByKey2.EquipKind == (byte) 29)
          return 1;
        flag = true;
      }
    }
    if (!flag)
      return 0;
    return (int) x.mNo < (int) y.mNo ? -1 : 1;
  }
}
