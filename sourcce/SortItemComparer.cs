// Decompiled with JetBrains decompiler
// Type: SortItemComparer
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;

#nullable disable
public class SortItemComparer : IComparer<ushort>
{
  public byte SortType;
  public byte SortColor;
  public byte SortLv;

  public int Compare(ushort x, ushort y)
  {
    DataManager instance = DataManager.Instance;
    Equip tmpEquip1;
    Equip tmpEquip2;
    if (this.SortType == (byte) 0)
    {
      tmpEquip1 = instance.EquipTable.GetRecordByIndex((int) x);
      tmpEquip2 = instance.EquipTable.GetRecordByIndex((int) y);
    }
    else
    {
      tmpEquip1 = instance.EquipTable.GetRecordByKey(x);
      tmpEquip2 = instance.EquipTable.GetRecordByKey(y);
    }
    bool flag1 = true;
    bool flag2 = true;
    int num1 = 0;
    int num2 = 0;
    if (this.SortLv == (byte) 0)
    {
      if ((int) tmpEquip1.NeedLv <= (int) instance.RoleAttr.Level)
      {
        if ((int) tmpEquip2.NeedLv <= (int) instance.RoleAttr.Level)
        {
          for (int index = 0; index < 4; ++index)
          {
            if (tmpEquip2.SyntheticParts[index].SyntheticItem > (ushort) 0)
            {
              ++num1;
              if (instance.mLordEquip.CheckMaterialEnough(tmpEquip2.SyntheticParts[index].SyntheticItem, (byte) 1, (ushort) tmpEquip2.SyntheticParts[index].SyntheticItemNum, true))
                ++num2;
            }
          }
          if (num2 < num1)
            flag2 = false;
        }
        else if ((int) tmpEquip2.NeedLv > (int) instance.RoleAttr.Level)
          flag2 = false;
        int num3 = 0;
        int num4 = 0;
        for (int index = 0; index < 4; ++index)
        {
          if (tmpEquip1.SyntheticParts[index].SyntheticItem > (ushort) 0)
          {
            ++num3;
            if (instance.mLordEquip.CheckMaterialEnough(tmpEquip1.SyntheticParts[index].SyntheticItem, (byte) 1, (ushort) tmpEquip1.SyntheticParts[index].SyntheticItemNum, true))
              ++num4;
          }
        }
        if (num4 < num3)
          flag1 = false;
      }
      else if ((int) tmpEquip1.NeedLv > (int) instance.RoleAttr.Level)
      {
        flag1 = false;
        if ((int) tmpEquip2.NeedLv <= (int) instance.RoleAttr.Level)
        {
          for (int index = 0; index < 4; ++index)
          {
            if (tmpEquip2.SyntheticParts[index].SyntheticItem > (ushort) 0)
            {
              ++num1;
              if (instance.mLordEquip.CheckMaterialEnough(tmpEquip2.SyntheticParts[index].SyntheticItem, (byte) 1, (ushort) tmpEquip2.SyntheticParts[index].SyntheticItemNum, true))
                ++num2;
            }
          }
          if (num2 < num1)
            flag2 = false;
        }
        else if ((int) tmpEquip2.NeedLv > (int) instance.RoleAttr.Level)
          flag2 = false;
      }
      if (flag1)
      {
        if (!flag2)
          return -1;
        if ((int) tmpEquip2.NeedLv > (int) tmpEquip1.NeedLv)
          return 1;
        return (int) tmpEquip2.NeedLv == (int) tmpEquip1.NeedLv ? this.CheckKindLv(tmpEquip1, tmpEquip2) : -1;
      }
      if (flag2 || (int) tmpEquip1.NeedLv > (int) tmpEquip2.NeedLv)
        return 1;
      return (int) tmpEquip1.NeedLv == (int) tmpEquip2.NeedLv ? this.CheckKindLv(tmpEquip1, tmpEquip2) : -1;
    }
    if ((int) tmpEquip1.NeedLv > (int) tmpEquip2.NeedLv)
      return 1;
    return (int) tmpEquip1.NeedLv == (int) tmpEquip2.NeedLv ? this.CheckKindLv(tmpEquip1, tmpEquip2) : -1;
  }

  public int CheckKindLv(Equip tmpEquip1, Equip tmpEquip2)
  {
    int num1 = -1;
    int num2 = this.CheckKind(tmpEquip1.EquipKind);
    int num3 = this.CheckKind(tmpEquip2.EquipKind);
    if ((int) tmpEquip1.NeedLv == (int) tmpEquip2.NeedLv)
      num1 = num2 >= num3 ? (num2 != num3 || (int) tmpEquip1.EquipKey < (int) tmpEquip2.EquipKey ? -1 : 1) : 1;
    return num1;
  }

  public int CheckKind(byte EquipKind)
  {
    int num = 0;
    switch (EquipKind)
    {
      case 21:
        num = 3;
        break;
      case 22:
        num = 2;
        break;
      case 23:
        num = 1;
        break;
      case 24:
        num = 5;
        break;
      case 25:
        num = 4;
        break;
      case 26:
        num = 0;
        break;
    }
    return num;
  }
}
