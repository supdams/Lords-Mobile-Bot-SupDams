// Decompiled with JetBrains decompiler
// Type: _PetItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
public struct _PetItem
{
  public byte bInit;
  private GameObject gameobject;
  private _PetCell[] PetCell;

  public _PetItem(Transform transform, IUIButtonClickHandler clickHandle)
  {
    this.bInit = (byte) 1;
    this.gameobject = transform.gameObject;
    this.PetCell = new _PetCell[4];
    for (int index = 0; index < 4; ++index)
      this.PetCell[index] = new _PetCell(transform.GetChild(index), clickHandle);
  }

  public void SetData(int DataIndex, int ItemBegin, int ItemCount, byte LockCheck)
  {
    PetManager instance = PetManager.Instance;
    int num1 = DataIndex * 4;
    int num2 = ItemCount;
    if (ItemCount == 0)
      ItemCount = 1;
    ushort[] sortPetItemData = instance.sortPetItemData;
    List<byte> sortPetData = instance.sortPetData;
    for (int index = 0; index < 4; ++index)
    {
      if (num1 + index < ItemCount)
      {
        int Index = num1 + index;
        if (num2 > Index)
        {
          PetItem itemData;
          if (ItemBegin + Index < sortPetItemData.Length && (itemData = instance.GetItemData((int) sortPetItemData[ItemBegin + Index])) != null)
          {
            this.PetCell[index].gameobject.SetActive(true);
            this.PetCell[index].SetData(itemData.ItemID, Index, _PetItem._ItemType.Item);
          }
          else
            this.PetCell[index].gameobject.SetActive(false);
        }
        else if (ItemCount == 1 && num2 == 0)
        {
          this.PetCell[index].gameobject.SetActive(true);
          this.PetCell[index].SetData((ushort) 0, 0, _PetItem._ItemType.Def);
        }
        else
          this.PetCell[index].gameobject.SetActive(false);
      }
      else
      {
        int num3 = num1 + index - ItemCount;
        if ((int) instance.PetDataCount > num3)
        {
          this.PetCell[index].gameobject.SetActive(true);
          this.PetCell[index].SetData(PetManager.Instance.GetPetData((int) sortPetData[num3]).ID, num3, _PetItem._ItemType.Pet);
          this.PetCell[index].UpdateState(LockCheck);
        }
        else
          this.PetCell[index].gameobject.SetActive(false);
      }
    }
  }

  public void UpdatePetState(byte LockCheck)
  {
    if ((Object) this.gameobject == (Object) null)
      return;
    for (int index = 0; index < 4; ++index)
      this.PetCell[index].UpdateState(LockCheck);
  }

  public void TextRefresh()
  {
    if (this.PetCell == null)
      return;
    for (int index = 0; index < this.PetCell.Length; ++index)
      this.PetCell[index].TextRefresh();
  }

  public void OnDestroy()
  {
    if (this.PetCell == null)
      return;
    for (int index = 0; index < this.PetCell.Length; ++index)
      this.PetCell[index].OnDestroy();
  }

  public enum _ItemType
  {
    Pet,
    Item,
    Def,
  }
}
