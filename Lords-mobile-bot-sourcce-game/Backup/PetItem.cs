// Decompiled with JetBrains decompiler
// Type: PetItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
public class PetItem : IComparable<ushort>, IComparable<PetItem>
{
  private ushort _ItemID;
  public byte EquipKind;
  public byte Color;
  public Properties[] PropertiesInfo;
  public Synthetic[] SyntheticParts;
  public ushort Quantity;

  public ushort ItemID
  {
    set
    {
      if ((int) this._ItemID != (int) value)
      {
        Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(value);
        this.EquipKind = recordByKey.EquipKind;
        this.Color = recordByKey.Color;
        this.PropertiesInfo = recordByKey.PropertiesInfo;
        this.SyntheticParts = recordByKey.SyntheticParts;
      }
      this._ItemID = value;
    }
    get => this._ItemID;
  }

  public void Init() => this.Quantity = (ushort) 0;

  public int CompareTo(PetItem obj)
  {
    if ((int) obj.ItemID > (int) this.ItemID)
      return -1;
    return (int) obj.ItemID < (int) this.ItemID ? 1 : 0;
  }

  public int CompareTo(ushort itemID)
  {
    if ((int) this.ItemID > (int) itemID)
      return -1;
    return (int) this.ItemID < (int) itemID ? 1 : 0;
  }
}
