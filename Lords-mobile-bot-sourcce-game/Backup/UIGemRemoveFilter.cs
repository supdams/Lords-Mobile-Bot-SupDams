// Decompiled with JetBrains decompiler
// Type: UIGemRemoveFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIGemRemoveFilter : UIFilterBase
{
  private int BagCount;
  private byte ItemKind;
  private byte EffectVal;
  private UIText Title;
  private CString TitleStr;
  private byte itemPos;
  private byte gemPos;

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager instance = DataManager.Instance;
    base.OnOpen(arg1, arg2);
    this.ThisTransform = this.SetFunc(this.transform.GetChild(4));
    this.ThisTransform.gameObject.SetActive(true);
    this.Title = this.ThisTransform.GetComponent<UIText>();
    this.Title.font = GUIManager.Instance.GetTTFFont();
    this.itemPos = (byte) arg1;
    this.gemPos = (byte) arg2;
    this.ItemKind = (byte) 10;
    this.EffectVal = (byte) 29;
    this.TitleStr = StringManager.Instance.SpawnString();
    this.MainText.text = instance.mStringTable.GetStringByID(7516U);
    this.Title.text = instance.mStringTable.GetStringByID(7517U);
    this.AddRefreshText((Text) this.Title);
  }

  public override void Init()
  {
    base.Init();
    this.ChangeItemType();
  }

  public override void OnClose()
  {
    base.OnClose();
    StringManager.Instance.DeSpawnString(this.TitleStr);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    DataManager.Instance.mLordEquip.RemoveGameFree(DataManager.Instance.mLordEquip.LordEquip[(int) this.itemPos].SerialNO, this.gemPos);
  }

  private void ChangeItemType(bool bMoveTop = false)
  {
    DataManager instance = DataManager.Instance;
    Vector2 vector2 = Vector2.zero;
    instance.SortCurItemDataForBag();
    instance.SortStoreData();
    int itemidx = 0;
    this.FilterScrollRect.StopMovement();
    if (!bMoveTop)
    {
      vector2 = this.ScrollContent.anchoredPosition;
      itemidx = this.FilterScrollView.GetBeginIdx();
    }
    this.BagCount = -1;
    this.ItemsHeight.Clear();
    this.ItemsData.Clear();
    this.ItemsData.Add((ushort) 1161);
    this.ItemsHeight.Add(121f);
    this.SetItemData(instance.sortItemData, instance.sortItemDataStart[(int) this.ItemKind - 1], instance.sortItemDataCount[(int) this.ItemKind - 1], sort: (byte) 0);
    this.BagCount = this.ItemsHeight.Count;
    this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[(int) this.ItemKind], instance.SortSotreDataCount[(int) this.ItemKind], sort: (byte) 0);
    this.UpdateScrollItemsCount();
    if (bMoveTop)
      return;
    this.FilterScrollView.GoTo(itemidx, vector2.y);
  }

  public override bool CheckItemRule(ushort id)
  {
    DataManager instance = DataManager.Instance;
    Equip recordByKey1;
    if (this.BagCount == -1)
    {
      recordByKey1 = instance.EquipTable.GetRecordByKey(id);
    }
    else
    {
      StoreTbl recordByKey2 = instance.StoreData.GetRecordByKey(id);
      if (recordByKey2.AddDiamondBuy == (byte) 0 || recordByKey2.Filter == (byte) 2 || instance.GetCurItemQuantity(recordByKey2.ItemID, (byte) 0) > (ushort) 0)
        return false;
      recordByKey1 = instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
    }
    return (int) recordByKey1.PropertiesInfo[0].Propertieskey == (int) this.EffectVal;
  }

  public override void SendPack(UIButton sender)
  {
    if (sender.m_BtnID2 == 1161)
    {
      GUIManager.Instance.OpenOKCancelBox(GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), DataManager.Instance.mStringTable.GetStringByID(7481U), DataManager.Instance.mStringTable.GetStringByID(7482U));
    }
    else
    {
      switch (sender.m_BtnID1)
      {
        case 1002:
          if ((int) DataManager.Instance.EquipTable.GetRecordByKey((ushort) sender.m_BtnID2).Color < (int) LordEquipData.Instance().LordEquip[(int) this.itemPos].GemColor[(int) this.gemPos])
            break;
          DataManager.Instance.UseItem((ushort) sender.m_BtnID2, (ushort) 1, (ushort) this.gemPos, (ushort) 0, (ushort) 0, DataManager.Instance.mLordEquip.LordEquip[(int) this.itemPos].SerialNO, string.Empty);
          break;
        case 1004:
          if ((int) DataManager.Instance.EquipTable.GetRecordByKey((ushort) sender.m_BtnID2).Color < (int) LordEquipData.Instance().LordEquip[(int) this.itemPos].GemColor[(int) this.gemPos])
            break;
          this.CheckBuy((byte) 1, (ushort) sender.m_BtnID3, (ushort) sender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), (int) this.gemPos, Parameter3: DataManager.Instance.mLordEquip.LordEquip[(int) this.itemPos].SerialNO);
          break;
      }
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.ChangeItemType();
        break;
      case NetworkNews.Refresh_Item:
        ((Door) GUIManager.Instance.FindMenu(EGUIWindow.Door)).CloseMenu();
        break;
    }
  }

  public override void UpDateRowItem(
    GameObject item,
    int dataIdx,
    int panelObjectIdx,
    int panelId)
  {
    base.UpDateRowItem(item, dataIdx, panelObjectIdx, panelId);
    if (this.ItemsData.Count <= dataIdx)
      return;
    DataManager instance = DataManager.Instance;
    this.FilterItem[panelObjectIdx].KeyID = this.ItemsData[dataIdx];
    ushort x = 1;
    ushort InKey;
    if (this.FilterItem[panelObjectIdx].KeyID == (ushort) 1161)
    {
      InKey = this.FilterItem[panelObjectIdx].KeyID;
      this.SetItemType(panelObjectIdx, UIFilterBase.eItemType.Use);
    }
    else if (this.BagCount > dataIdx)
    {
      InKey = this.FilterItem[panelObjectIdx].KeyID;
      this.SetItemType(panelObjectIdx, UIFilterBase.eItemType.Use);
    }
    else
    {
      StoreTbl recordByKey = instance.StoreData.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
      InKey = recordByKey.ItemID;
      x = recordByKey.Num;
      this.SetItemType(panelObjectIdx, UIFilterBase.eItemType.BuyAndUse);
      this.FilterItem[panelObjectIdx].BuyPriceStr.ClearString();
      this.FilterItem[panelObjectIdx].BuyPriceStr.IntToFormat((long) recordByKey.Price, bNumber: true);
      this.FilterItem[panelObjectIdx].BuyPriceStr.AppendFormat("{0}");
      this.FilterItem[panelObjectIdx].BuyPrice.text = this.FilterItem[panelObjectIdx].BuyPriceStr.ToString();
      this.FilterItem[panelObjectIdx].BuyPrice.SetAllDirty();
      this.FilterItem[panelObjectIdx].BuyPrice.cachedTextGenerator.Invalidate();
      this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID3 = (int) recordByKey.ID;
    }
    Equip recordByKey1 = instance.EquipTable.GetRecordByKey(InKey);
    ushort curItemQuantity = instance.GetCurItemQuantity(recordByKey1.EquipKey, (byte) 0);
    ((Component) this.FilterItem[panelObjectIdx].AutouseBtnTrans).gameObject.SetActive(false);
    GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[panelObjectIdx].ItemTrans, eHeroOrItem.Item, recordByKey1.EquipKey, (byte) 0, (byte) 0);
    if (x == (ushort) 1)
    {
      this.FilterItem[panelObjectIdx].Name.text = instance.mStringTable.GetStringByID((uint) recordByKey1.EquipName);
    }
    else
    {
      this.FilterItem[panelObjectIdx].NameStr.ClearString();
      this.FilterItem[panelObjectIdx].NameStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
      this.FilterItem[panelObjectIdx].NameStr.IntToFormat((long) x);
      this.FilterItem[panelObjectIdx].NameStr.AppendFormat("{0} x {1}");
      this.FilterItem[panelObjectIdx].Name.text = this.FilterItem[panelObjectIdx].NameStr.ToString();
      this.FilterItem[panelObjectIdx].Name.SetAllDirty();
      this.FilterItem[panelObjectIdx].Name.cachedTextGenerator.Invalidate();
    }
    this.FilterItem[panelObjectIdx].Content.text = instance.mStringTable.GetStringByID((uint) recordByKey1.EquipInfo);
    this.FilterItem[panelObjectIdx].OwnerStr.ClearString();
    if (this.FilterItem[panelObjectIdx].KeyID != (ushort) 1161)
    {
      this.FilterItem[panelObjectIdx].OwnerStr.StringToFormat(this.OwnerStr);
      this.FilterItem[panelObjectIdx].OwnerStr.IntToFormat((long) curItemQuantity, bNumber: true);
      this.FilterItem[panelObjectIdx].OwnerStr.AppendFormat("{0}{1}");
    }
    this.FilterItem[panelObjectIdx].Owner.text = this.FilterItem[panelObjectIdx].OwnerStr.ToString();
    this.FilterItem[panelObjectIdx].Owner.SetAllDirty();
    this.FilterItem[panelObjectIdx].Owner.cachedTextGenerator.Invalidate();
    this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = (int) recordByKey1.EquipKey;
    if ((int) LordEquipData.Instance().LordEquip[(int) this.itemPos].GemColor[(int) this.gemPos] > (int) recordByKey1.Color && this.FilterItem[panelObjectIdx].KeyID != (ushort) 1161)
      ((Graphic) this.FilterItem[panelObjectIdx].BuyCaption).color = (Color) new Color32(byte.MaxValue, (byte) 85, (byte) 129, byte.MaxValue);
    else
      ((Graphic) this.FilterItem[panelObjectIdx].BuyCaption).color = (Color) new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
  }
}
