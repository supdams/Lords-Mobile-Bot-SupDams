// Decompiled with JetBrains decompiler
// Type: UIKingBufferFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIKingBufferFilter : UIFilterBase
{
  private ushort ItemKind;
  private ushort PropKey;
  private UIText Title;
  private CString TitleStr;
  private UIButton Sender;
  private bool IsKing;
  private UIText[] RemainTimeText;
  private CString[] RemainTimeStr;
  private GameObject[] TimeObj;

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager instance = DataManager.Instance;
    this.TitleStr = StringManager.Instance.SpawnString(200);
    Image component1 = this.transform.GetChild(1).GetChild(5).GetComponent<Image>();
    base.OnOpen(arg1, arg2);
    this.ThisTransform = this.SetFunc(this.transform.GetChild(4));
    this.ThisTransform.gameObject.SetActive(true);
    this.MainText.text = instance.mStringTable.GetStringByID(1453U);
    component1.sprite = this.FilterSpriteArr.GetSprite(4);
    this.Title = this.ThisTransform.GetChild(1).GetComponent<UIText>();
    this.Title.font = GUIManager.Instance.GetTTFFont();
    ((Component) this.Title).gameObject.SetActive(true);
    this.AddRefreshText((Text) this.Title);
    RectTransform component2 = this.ThisTransform.GetChild(4).GetComponent<RectTransform>();
    ((Transform) component2).SetParent(((Component) component1).transform);
    component2.anchoredPosition = Vector2.zero;
    ((Transform) component2).GetChild(1).GetComponent<UIText>().font = this.Title.font;
    ItemBuff recordByIndex = instance.ItemBuffTable.GetRecordByIndex(arg2);
    Equip recordByKey = instance.EquipTable.GetRecordByKey(recordByIndex.BuffItemID);
    this.ItemKind = (ushort) recordByKey.EquipKind;
    this.PropKey = recordByKey.PropertiesInfo[0].Propertieskey;
    this.Title.text = instance.mStringTable.GetStringByID(1454U);
    this.Title.alignment = TextAnchor.MiddleCenter;
    RectTransform component3 = ((Component) this.Title).gameObject.GetComponent<RectTransform>();
    component3.anchoredPosition = new Vector2(1f, 0.0f);
    component3.sizeDelta = new Vector2(738f, 26f);
    if (GUIManager.Instance.IsArabic)
      ((Transform) ((Graphic) this.Title).rectTransform).localRotation = new Quaternion(0.0f, 180f, 0.0f, 0.0f);
    this.IsKing = DataManager.MapDataController.IsKing();
  }

  public override void Init()
  {
    base.Init();
    this.RemainTimeText = new UIText[this.FilterItem.Length];
    this.RemainTimeStr = new CString[this.FilterItem.Length];
    this.TimeObj = new GameObject[this.FilterItem.Length];
    string stringById = DataManager.Instance.mStringTable.GetStringByID(1456U);
    for (int ItemArrayIndex = 0; ItemArrayIndex < this.FilterItem.Length; ++ItemArrayIndex)
    {
      this.SetItemType(ItemArrayIndex, UIFilterBase.eItemType.BuyAndUse);
      this.TimeObj[ItemArrayIndex] = ((Component) this.FilterItem[ItemArrayIndex].BkImage).transform.GetChild(((Component) this.FilterItem[ItemArrayIndex].BkImage).transform.childCount - 1).gameObject;
      this.RemainTimeText[ItemArrayIndex] = this.TimeObj[ItemArrayIndex].transform.GetChild(1).GetComponent<UIText>();
      this.RemainTimeStr[ItemArrayIndex] = StringManager.Instance.SpawnString();
      this.AddRefreshText((Text) this.RemainTimeText[ItemArrayIndex]);
      if (!this.IsKing)
      {
        this.FilterItem[ItemArrayIndex].BuyCaption.text = stringById;
        ((Graphic) this.FilterItem[ItemArrayIndex].BuyCaption).color = Color.red;
      }
    }
    this.ChangeItemType();
  }

  public override void OnClose()
  {
    base.OnClose();
    StringManager.Instance.DeSpawnString(this.TitleStr);
    for (int index = 0; index < this.RemainTimeStr.Length; ++index)
      StringManager.Instance.DeSpawnString(this.RemainTimeStr[index]);
  }

  private void ChangeItemType(bool bMoveTop = false)
  {
    if (this.ItemKind == (ushort) 0)
      return;
    DataManager instance = DataManager.Instance;
    Vector2 vector2 = Vector2.zero;
    instance.SortResourceFilterData();
    int itemidx = 0;
    instance.SortCurItemDataForBag();
    instance.SortStoreData();
    this.FilterScrollRect.StopMovement();
    if (!bMoveTop)
    {
      vector2 = this.ScrollContent.anchoredPosition;
      itemidx = this.FilterScrollView.GetBeginIdx();
    }
    this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[(int) this.ItemKind], instance.SortSotreDataCount[(int) this.ItemKind], true, (byte) 0);
    this.UpdateScrollItemsCount();
    if (bMoveTop)
      return;
    this.FilterScrollView.GoTo(itemidx, vector2.y);
  }

  public override bool CheckItemRule(ushort id)
  {
    return (int) DataManager.Instance.EquipTable.GetRecordByKey(DataManager.Instance.StoreData.GetRecordByKey(id).ItemID).PropertiesInfo[0].Propertieskey == (int) this.PropKey;
  }

  public override void SendPack(UIButton sender)
  {
    DataManager instance = DataManager.Instance;
    if (!this.IsKing)
    {
      GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(1456U), (ushort) byte.MaxValue);
    }
    else
    {
      if (!DataManager.MapDataController.CheckKingFunction(eKingFunction.eStrengthen))
        return;
      this.Sender = sender;
      if (this.Sender.m_BtnID1 == 1004)
      {
        if (instance.KingCoolEndTime > instance.ServerTime)
          GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(1457U), (ushort) byte.MaxValue);
        else if (instance.StoreData.GetRecordByKey((ushort) this.Sender.m_BtnID3).Price > instance.RoleAttr.Diamond)
          GUIManager.Instance.OpenMessageBox(instance.mStringTable.GetStringByID(3966U), instance.mStringTable.GetStringByID(646U), 4, instance.mStringTable.GetStringByID(4507U), bCloseIDSet: true);
        else
          this.CheckMessage((ushort) this.Sender.m_BtnID2);
      }
      else
        this.CheckMessage((ushort) this.Sender.m_BtnID2);
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (this.Sender.m_BtnID1)
    {
      case 1002:
        DataManager.Instance.UseItem((ushort) this.Sender.m_BtnID2, (ushort) 1, (ushort) 0, (ushort) 0, (ushort) 0, 0U, string.Empty);
        break;
      case 1004:
        this.CheckBuy((byte) 1, (ushort) this.Sender.m_BtnID3, (ushort) this.Sender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), Parameter3: 0U);
        break;
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
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((Object) menu != (Object) null))
          break;
        menu.CloseMenu();
        break;
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!bOnSecond || this.FilterItem == null)
      return;
    DataManager instance = DataManager.Instance;
    uint time = 0;
    if (instance.KingCoolEndTime > instance.ServerTime)
      time = (uint) (instance.KingCoolEndTime - instance.ServerTime);
    CString cstring = DataManager.MissionDataManager.FormatMissionTime(time);
    for (int index = 0; index < this.RemainTimeText.Length; ++index)
    {
      if (((Component) this.FilterItem[index].BkImage).gameObject.activeSelf)
      {
        this.RemainTimeStr[index].ClearString();
        if (time > 0U)
        {
          if (!this.TimeObj[index].activeSelf)
            this.TimeObj[index].SetActive(true);
          this.RemainTimeStr[index].Append(cstring);
          this.RemainTimeText[index].text = this.RemainTimeStr[index].ToString();
          this.RemainTimeText[index].SetAllDirty();
          this.RemainTimeText[index].cachedTextGenerator.Invalidate();
        }
        else if (this.TimeObj[index].activeSelf)
          this.TimeObj[index].SetActive(false);
      }
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
    StoreTbl recordByKey1 = instance.StoreData.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
    ushort itemId = recordByKey1.ItemID;
    ushort num = recordByKey1.Num;
    this.FilterItem[panelObjectIdx].BuyPriceStr.ClearString();
    this.FilterItem[panelObjectIdx].BuyPriceStr.IntToFormat((long) recordByKey1.Price, bNumber: true);
    this.FilterItem[panelObjectIdx].BuyPriceStr.AppendFormat("{0}");
    this.FilterItem[panelObjectIdx].BuyPrice.text = this.FilterItem[panelObjectIdx].BuyPriceStr.ToString();
    this.FilterItem[panelObjectIdx].BuyPrice.SetAllDirty();
    this.FilterItem[panelObjectIdx].BuyPrice.cachedTextGenerator.Invalidate();
    this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID3 = (int) recordByKey1.ID;
    Equip recordByKey2 = instance.EquipTable.GetRecordByKey(itemId);
    ((Component) this.FilterItem[panelObjectIdx].AutouseBtnTrans).gameObject.SetActive(false);
    GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[panelObjectIdx].ItemTrans, eHeroOrItem.Item, recordByKey2.EquipKey, (byte) 0, (byte) 0);
    if (num == (ushort) 1)
    {
      this.FilterItem[panelObjectIdx].Name.text = instance.mStringTable.GetStringByID((uint) recordByKey2.EquipName);
    }
    else
    {
      this.FilterItem[panelObjectIdx].NameStr.ClearString();
      this.FilterItem[panelObjectIdx].NameStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey2.EquipName));
      this.FilterItem[panelObjectIdx].NameStr.IntToFormat((long) num);
      this.FilterItem[panelObjectIdx].NameStr.AppendFormat("{0} x {1}");
      this.FilterItem[panelObjectIdx].Name.text = this.FilterItem[panelObjectIdx].NameStr.ToString();
      this.FilterItem[panelObjectIdx].Name.SetAllDirty();
      this.FilterItem[panelObjectIdx].Name.cachedTextGenerator.Invalidate();
    }
    this.FilterItem[panelObjectIdx].Content.text = instance.mStringTable.GetStringByID((uint) recordByKey2.EquipInfo);
    this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = (int) recordByKey2.EquipKey;
  }
}
