// Decompiled with JetBrains decompiler
// Type: UIKingReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIKingReward : UIFilterBase
{
  private UIText TitleText;
  private string[] ItemBtnString = new string[2];
  private UIButton[] ListBtn;
  private CString SendName;
  private _WhoReward Who;

  public override void OnOpen(int arg1, int arg2)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    base.OnOpen(arg1, arg2);
    if (arg1 > 0)
    {
      this.Who = (_WhoReward) new Nobility();
      if (arg2 == 1)
        this.Who.IsKing = true;
    }
    else
      this.Who = !DataManager.MapDataController.IsFocusWorldWar() ? (_WhoReward) new King() : (_WhoReward) new WorldKing();
    DataManager.Instance.KingGift.sendKingGiftInfo((byte) arg1);
    this.ThisTransform = this.SetFunc(this.transform.GetChild(4));
    this.ThisTransform.gameObject.SetActive(true);
    this.TitleText = this.ThisTransform.GetComponent<UIText>();
    this.TitleText.font = GUIManager.Instance.GetTTFFont();
    this.AddRefreshText((Text) this.TitleText);
    this.TitleText.text = this.Who.TitleStr;
    this.MainText.text = this.Who.MainStr;
    this.OwnerStr = mStringTable.GetStringByID(5332U);
    this.ItemBtnString[0] = mStringTable.GetStringByID(9716U);
    this.ItemBtnString[1] = mStringTable.GetStringByID(9717U);
    this.SendName = StringManager.Instance.SpawnString();
  }

  public override void Init()
  {
    base.Init();
    this.ListBtn = new UIButton[this.FilterItem.Length];
    for (int ItemArrayIndex = 0; ItemArrayIndex < this.FilterItem.Length; ++ItemArrayIndex)
    {
      this.FilterItem[ItemArrayIndex].ItemBtn.m_Handler = (IUIHIBtnClickHandler) this;
      ((Transform) this.FilterItem[ItemArrayIndex].AutouseBtnTrans).GetChild(0).GetComponent<UIText>().text = this.ItemBtnString[1];
      this.ListBtn[ItemArrayIndex] = ((Component) this.FilterItem[ItemArrayIndex].AutouseBtnTrans).GetComponent<UIButton>();
      this.ListBtn[ItemArrayIndex].m_BtnID1 = 1;
      this.SetItemType(ItemArrayIndex, UIFilterBase.eItemType.Use);
      this.FilterItem[ItemArrayIndex].BuyCaption.text = this.ItemBtnString[0];
      this.FilterItem[ItemArrayIndex].BuyBtn.m_BtnID1 = 0;
      ((Component) this.FilterItem[ItemArrayIndex].BuyBtn).gameObject.SetActive(this.Who.IsKing);
      if (!this.Who.IsKing)
        this.FilterItem[ItemArrayIndex].AutouseBtnTrans.anchoredPosition = new Vector2(669f, -59f);
    }
    if (DataManager.Instance.KingGift.GetGiftList().Count == 0)
      this.FilterScrollView.gameObject.SetActive(false);
    else
      this.UpdateRewardItem();
  }

  private void UpdateRewardItem()
  {
    List<KingGiftInfo> giftList = DataManager.Instance.KingGift.GetGiftList();
    this.ItemsData.Clear();
    this.ItemsHeight.Clear();
    for (int index = 0; index < giftList.Count; ++index)
    {
      this.ItemsData.Add(giftList[index].ItemID);
      this.ItemsHeight.Add(121f);
    }
    this.UpdateScrollItemsCount();
  }

  public override void OnHIButtonClick(UIHIBtn sender)
  {
    if (sender.m_BtnID2 == 0)
      return;
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_OpenBox, 1, sender.m_BtnID2);
  }

  public override void OnButtonClick(UIButton sender)
  {
    switch ((UIKingReward.ClickType) sender.m_BtnID1)
    {
      case UIKingReward.ClickType.Reward:
        if (!this.Who.CheckReward())
          break;
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_Alliance_List, 6, sender.m_BtnID2);
        break;
      case UIKingReward.ClickType.List:
        this.Who.CheckAndOpenList(sender.m_BtnID2);
        break;
      default:
        base.OnButtonClick(sender);
        break;
    }
  }

  public override void OnClose()
  {
    base.OnClose();
    StringManager.Instance.DeSpawnString(this.SendName);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    if (meg[0] != (byte) 9 || DataManager.Instance.RoleAlliance.Id != 0U)
      return;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((Object) menu != (Object) null))
      return;
    menu.CloseMenu_Alliance(EGUIWindow.UI_BagFilter);
  }

  public override void UpdateUI(int arge1, int arge2)
  {
    switch (arge2)
    {
      case 1:
        if (!((Object) this.FilterScrollView != (Object) null))
          break;
        Vector2 zero = Vector2.zero;
        Vector2 anchoredPosition = this.ScrollContent.anchoredPosition;
        int beginIdx = this.FilterScrollView.GetBeginIdx();
        this.FilterScrollView.gameObject.SetActive(true);
        this.UpdateRewardItem();
        this.FilterScrollView.GoTo(beginIdx, anchoredPosition.y);
        break;
      case 2:
        if (DataManager.MapDataController.IsPeaceState(wonderID: DataManager.Instance.KingGift.WonderID))
        {
          DataManager.Instance.KingGift.sendKingGiftInfo(DataManager.Instance.KingGift.WonderID);
          break;
        }
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((Object) menu != (Object) null))
          break;
        menu.CloseMenu_Alliance(EGUIWindow.UI_BagFilter);
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
    ushort keyId = this.FilterItem[panelObjectIdx].KeyID;
    this.FilterItem[panelObjectIdx].ItemBtn.m_BtnID2 = (int) keyId;
    Equip recordByKey = instance.EquipTable.GetRecordByKey(keyId);
    ushort remainCount = (ushort) instance.KingGift.GetGiftList()[dataIdx].GetRemainCount();
    GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[panelObjectIdx].ItemTrans, eHeroOrItem.Item, recordByKey.EquipKey, (byte) 0, (byte) 0);
    this.FilterItem[panelObjectIdx].Name.text = instance.mStringTable.GetStringByID((uint) recordByKey.EquipName);
    if (recordByKey.EquipKind == (byte) 19)
    {
      this.FilterItem[panelObjectIdx].InfoTrans.gameObject.SetActive(true);
      this.FilterItem[panelObjectIdx].ItemBtn.m_BtnID2 = (int) recordByKey.EquipKey;
      GUIManager.Instance.SetItemScaleClickSound(this.FilterItem[panelObjectIdx].ItemBtn, true, true);
    }
    else if (recordByKey.EquipKind == (byte) 18 && (recordByKey.PropertiesInfo[2].Propertieskey < (ushort) 1 || recordByKey.PropertiesInfo[2].Propertieskey > (ushort) 3))
    {
      this.FilterItem[panelObjectIdx].NameStr.ClearString();
      this.FilterItem[panelObjectIdx].NameStr.StringToFormat(instance.mStringTable.GetStringByID(7732U + (uint) recordByKey.Color));
      this.FilterItem[panelObjectIdx].NameStr.AppendFormat(instance.mStringTable.GetStringByID(7739U));
      this.FilterItem[panelObjectIdx].NameStr.Append(instance.mStringTable.GetStringByID((uint) recordByKey.EquipName));
      this.FilterItem[panelObjectIdx].Name.text = this.FilterItem[panelObjectIdx].NameStr.ToString();
      this.FilterItem[panelObjectIdx].Name.SetAllDirty();
      this.FilterItem[panelObjectIdx].Name.cachedTextGenerator.Invalidate();
      this.FilterItem[panelObjectIdx].InfoTrans.gameObject.SetActive(true);
      this.FilterItem[panelObjectIdx].ItemBtn.m_BtnID2 = (int) recordByKey.EquipKey;
      GUIManager.Instance.SetItemScaleClickSound(this.FilterItem[panelObjectIdx].ItemBtn, true, true);
    }
    else
    {
      this.FilterItem[panelObjectIdx].ItemBtn.m_BtnID2 = 0;
      this.FilterItem[panelObjectIdx].InfoTrans.gameObject.SetActive(false);
    }
    this.FilterItem[panelObjectIdx].Content.text = instance.mStringTable.GetStringByID((uint) recordByKey.EquipInfo);
    this.FilterItem[panelObjectIdx].OwnerStr.ClearString();
    this.FilterItem[panelObjectIdx].OwnerStr.StringToFormat(this.OwnerStr);
    this.FilterItem[panelObjectIdx].OwnerStr.IntToFormat((long) remainCount, bNumber: true);
    this.FilterItem[panelObjectIdx].OwnerStr.AppendFormat("{0}{1}");
    this.FilterItem[panelObjectIdx].Owner.text = this.FilterItem[panelObjectIdx].OwnerStr.ToString();
    this.FilterItem[panelObjectIdx].Owner.SetAllDirty();
    this.FilterItem[panelObjectIdx].Owner.cachedTextGenerator.Invalidate();
    this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = (int) keyId;
    this.ListBtn[panelObjectIdx].m_BtnID2 = dataIdx;
  }

  private enum ClickType
  {
    Reward,
    List,
  }
}
