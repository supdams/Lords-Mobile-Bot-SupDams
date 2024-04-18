// Decompiled with JetBrains decompiler
// Type: UIBookMark
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIBookMark : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private List<UIText> RefreshTextList = new List<UIText>();
  private byte[] TypeId = new byte[4]
  {
    (byte) 3,
    (byte) 0,
    (byte) 2,
    (byte) 1
  };
  private ScrollPanel BookScrollView;
  protected List<float> ItemsHeight = new List<float>(16);
  private byte[] KindData;
  private byte DataCount;
  private Color TabTextColor;
  private UISpritesArray BookSpriteArr;
  private Transform ThisTransfrom;
  private Transform Type1;
  private Transform Type2;
  private RectTransform MessageTrans;
  private RectTransform BookScrollRect;
  private UIBookMark.ClickType CurrentTag;
  private UIBookMark.ClickType CurrentAllianceTag;
  private UIText MainTitle;
  private UIText PageInfo;
  private UIText MessageText;
  private CString PageInfoStr;
  private CanvasGroup[] BookTag = new CanvasGroup[4];
  private CanvasGroup[] AllianceTag = new CanvasGroup[2];
  private UIText[] BookTagText = new UIText[4];
  private GameObject BookTagObj;
  private byte SelectCount;
  private byte SelectCountMax = 10;
  private byte[] BookMarkSel;
  private float DeltaTime;
  private AllianceRank AllianceRank = AllianceRank.RANK5;
  protected UIBookMark.ItemEdit[] BookItem;
  private UIBookMark.BookMarkType Type = UIBookMark.BookMarkType.Type1;

  public override void OnOpen(int arg1, int arg2)
  {
    this.ThisTransfrom = this.transform.GetChild(0);
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    this.PageInfoStr = StringManager.Instance.SpawnString();
    DataManager.Instance.RoleBookMark.CheckUpdate(false);
    if (DataManager.Instance.RoleAlliance.Id > 0U)
      DataManager.Instance.RoleBookMark.CheckUpdate_Alliance(false);
    instance2.UpdateUI(EGUIWindow.Door, 1, 2);
    Font ttfFont = instance2.GetTTFFont();
    this.MainTitle = this.ThisTransfrom.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.MainTitle.font = ttfFont;
    this.AddRefreshText(this.MainTitle);
    this.PageInfo = this.ThisTransfrom.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.PageInfo.font = ttfFont;
    this.AddRefreshText(this.PageInfo);
    if (instance2.bOpenOnIPhoneX)
      ((Behaviour) this.ThisTransfrom.GetChild(7).GetComponent<CustomImage>()).enabled = false;
    else
      this.ThisTransfrom.GetChild(7).GetComponent<CustomImage>().hander = (UILoadImageHander) instance2.m_ItemInfo;
    this.ThisTransfrom.GetChild(7).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) instance2.m_ItemInfo;
    UIButton component1 = this.ThisTransfrom.GetChild(7).GetChild(0).GetComponent<UIButton>();
    component1.m_BtnID1 = 7;
    component1.m_Handler = (IUIButtonClickHandler) this;
    this.Type1 = this.ThisTransfrom.GetChild(3);
    this.Type2 = this.ThisTransfrom.GetChild(4);
    UIButton component2 = this.Type2.GetChild(0).GetComponent<UIButton>();
    component2.m_BtnID1 = 8;
    component2.m_Handler = (IUIButtonClickHandler) this;
    UIText component3 = this.Type2.GetChild(0).GetChild(0).GetComponent<UIText>();
    component3.font = ttfFont;
    component3.text = instance1.mStringTable.GetStringByID(6089U);
    this.AddRefreshText(component3);
    this.BookSpriteArr = this.ThisTransfrom.GetChild(5).GetComponent<UISpritesArray>();
    for (byte index = 0; (int) index < this.BookTag.Length; ++index)
    {
      UIButton component4 = this.ThisTransfrom.GetChild(1).GetChild((int) index).GetComponent<UIButton>();
      this.BookTag[(int) index] = this.ThisTransfrom.GetChild(1).GetChild((int) index).GetChild(0).GetComponent<CanvasGroup>();
      this.BookTagText[(int) index] = this.ThisTransfrom.GetChild(1).GetChild((int) index).GetChild(1).GetComponent<UIText>();
      component4.m_BtnID1 = (int) index;
      component4.m_Handler = (IUIButtonClickHandler) this;
      this.BookTagText[(int) index].font = ttfFont;
      this.BookTagText[(int) index].text = instance1.mStringTable.GetStringByID(4584U + (uint) index);
      this.AddRefreshText(this.BookTagText[(int) index]);
    }
    this.TabTextColor = ((Graphic) this.BookTagText[0]).color;
    this.BookTagObj = this.ThisTransfrom.GetChild(1).gameObject;
    for (int index = 0; index < this.AllianceTag.Length; ++index)
    {
      UIButton component5 = this.ThisTransfrom.GetChild(2).GetChild(index).GetComponent<UIButton>();
      this.AllianceTag[index] = this.ThisTransfrom.GetChild(2).GetChild(index).GetChild(0).GetComponent<CanvasGroup>();
      component5.m_BtnID1 = index + 9;
      component5.m_Handler = (IUIButtonClickHandler) this;
    }
    this.MessageTrans = this.ThisTransfrom.GetChild(6).GetComponent<RectTransform>();
    this.MessageText = ((Transform) this.MessageTrans).GetChild(0).GetComponent<UIText>();
    this.MessageText.font = ttfFont;
    this.AddRefreshText(this.MessageText);
    this.MessageTrans.sizeDelta = this.MessageTrans.sizeDelta with
    {
      x = component3.preferredWidth + 165f
    };
    Transform child = this.ThisTransfrom.GetChild(8);
    Image component6 = child.GetChild(1).GetComponent<Image>();
    component6.sprite = instance2.LoadFrameSprite("if001");
    ((MaskableGraphic) component6).material = instance2.GetFrameMaterial();
    child.GetChild(4).GetComponent<UIText>().font = ttfFont;
    child.GetChild(5).GetComponent<UIText>().font = ttfFont;
    UIText component7 = child.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
    component7.font = ttfFont;
    component7.text = instance1.mStringTable.GetStringByID(4589U);
    byte _PanelObjectsCount = 7;
    this.BookScrollView = this.ThisTransfrom.GetChild(5).GetChild(0).GetComponent<ScrollPanel>();
    this.BookItem = new UIBookMark.ItemEdit[(int) _PanelObjectsCount];
    this.CurrentTag = UIBookMark.ClickType.TabAll;
    this.CurrentAllianceTag = (UIBookMark.ClickType) (arg1 >> 16);
    float _PanelHeight = 472f;
    if (this.CurrentAllianceTag != UIBookMark.ClickType.RoleTag && this.CurrentAllianceTag != UIBookMark.ClickType.AllianceTag)
      this.CurrentAllianceTag = UIBookMark.ClickType.RoleTag;
    arg1 &= (int) ushort.MaxValue;
    if (arg1 >= 5)
    {
      this.CurrentAllianceTag = UIBookMark.ClickType.RoleTag;
      this.Type = UIBookMark.BookMarkType.Type2;
      this.Type1.gameObject.SetActive(false);
      this.Type2.gameObject.SetActive(true);
      RectTransform component8 = this.BookScrollView.GetComponent<RectTransform>();
      Vector2 anchoredPosition = component8.anchoredPosition;
      anchoredPosition.Set(-30f, -36.09f);
      component8.anchoredPosition = anchoredPosition;
      anchoredPosition.Set(776f, 392.8f);
      component8.sizeDelta = anchoredPosition;
      this.BookMarkSel = new byte[100];
    }
    this.BookScrollView.IntiScrollPanel(_PanelHeight, 0.0f, 0.0f, this.ItemsHeight, (int) _PanelObjectsCount, (IUpDateScrollPanel) this);
    this.BookScrollRect = this.ThisTransfrom.GetChild(5).GetChild(0).GetChild(0).GetComponent<RectTransform>();
    if (instance2.BookMarkSaved[0] > (byte) 0)
      this.CurrentTag = (UIBookMark.ClickType) instance2.BookMarkSaved[0];
    if (instance2.BookMarkSaved[7] > (byte) 0)
      this.CurrentAllianceTag = (UIBookMark.ClickType) instance2.BookMarkSaved[7];
    if (this.CurrentAllianceTag == UIBookMark.ClickType.RoleTag && arg1 > 0 && this.Type == UIBookMark.BookMarkType.Type1)
    {
      if (this.CurrentTag == UIBookMark.ClickType.TabAll)
      {
        arg2 = 0;
      }
      else
      {
        switch (arg1)
        {
          case 1:
            this.CurrentTag = UIBookMark.ClickType.TabFavor;
            break;
          case 3:
            this.CurrentTag = UIBookMark.ClickType.TabEnemy;
            break;
          default:
            this.CurrentTag = UIBookMark.ClickType.TabFriend;
            break;
        }
      }
    }
    else if (this.CurrentAllianceTag == UIBookMark.ClickType.AllianceTag && instance1.RoleAlliance.Id == 0U)
    {
      this.CurrentAllianceTag = UIBookMark.ClickType.RoleTag;
      this.CurrentTag = UIBookMark.ClickType.TabAll;
    }
    this.ChangeAllianceTag(this.CurrentAllianceTag, this.CurrentTag, true);
    if (arg2 > 0)
      this.BookScrollView.GoTo(this.getBookMarkIndex((int) this.TypeId[(int) this.CurrentTag], arg2, this.CurrentAllianceTag));
    else
      this.BookScrollView.GoTo((int) GameConstants.ConvertBytesToUShort(GUIManager.Instance.BookMarkSaved, 1), GameConstants.ConvertBytesToFloat(GUIManager.Instance.BookMarkSaved, 3));
    this.AllianceRank = instance1.RoleAlliance.Rank;
  }

  public override void OnClose()
  {
    for (int index = 0; index < this.BookItem.Length; ++index)
      this.BookItem[index].Destroy();
    GUIManager.Instance.BookMarkSaved[0] = (byte) this.CurrentTag;
    GUIManager.Instance.BookMarkSaved[7] = (byte) this.CurrentAllianceTag;
    GameConstants.GetBytes((ushort) this.BookScrollView.GetBeginIdx(), GUIManager.Instance.BookMarkSaved, 1);
    GameConstants.GetBytes(this.BookScrollView.transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition.y, GUIManager.Instance.BookMarkSaved, 3);
    StringManager.Instance.DeSpawnString(this.PageInfoStr);
  }

  public void OnButtonClick(UIButton sender)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    switch (sender.m_BtnID1)
    {
      case 0:
      case 1:
      case 2:
      case 3:
        this.ChangeTag((UIBookMark.ClickType) sender.m_BtnID1);
        break;
      case 4:
        if (this.CurrentAllianceTag == UIBookMark.ClickType.RoleTag)
          menu.m_GroundInfo.ModifyBookmarksPanel((ushort) sender.m_BtnID2, UIGroundInfo._BookmarkSwitch.eType.ModifyBookmark);
        else
          menu.m_GroundInfo.ModifyBookmarksPanel((ushort) sender.m_BtnID2, UIGroundInfo._BookmarkSwitch.eType.ModifyAlliancemark);
        menu.CloseMenu();
        break;
      case 5:
        if (this.CurrentAllianceTag == UIBookMark.ClickType.RoleTag)
        {
          DataManager.Instance.RoleBookMark.sendDelBookMark((ushort) sender.m_BtnID2);
          break;
        }
        DataManager.Instance.RoleBookMark.sendDelBookMark_Alliance((byte) sender.m_BtnID2);
        break;
      case 6:
        BookMark.eBookType bookType = (BookMark.eBookType) (this.CurrentAllianceTag - 9);
        menu.GoToMapID(DataManager.Instance.RoleBookMark.GetKingdomID((ushort) sender.m_BtnID2, bookType), DataManager.Instance.RoleBookMark.GetMapID((ushort) sender.m_BtnID2, bookType), (byte) 0, (byte) 1);
        break;
      case 7:
        menu.CloseMenu();
        break;
      case 8:
        if (this.Type != UIBookMark.BookMarkType.Type2)
          break;
        BookMark roleBookMark = DataManager.Instance.RoleBookMark;
        Array.Clear((Array) roleBookMark.SelectBookMarkIndex, 0, roleBookMark.SelectBookMarkIndex.Length);
        roleBookMark.SelectCount = this.SelectCount;
        int num = 0;
        for (int index = 0; index < this.BookMarkSel.Length && this.SelectCount != (byte) 0; ++index)
        {
          if (this.BookMarkSel[index] > (byte) 0)
          {
            roleBookMark.SelectBookMarkIndex[num++] = this.BookMarkSel[index];
            --this.SelectCount;
          }
        }
        menu.CloseMenu();
        break;
      case 9:
        this.ChangeAllianceTag(UIBookMark.ClickType.RoleTag, this.CurrentTag);
        break;
      case 10:
        this.ChangeAllianceTag(UIBookMark.ClickType.AllianceTag, this.CurrentTag);
        break;
    }
  }

  private void ChangeTag(UIBookMark.ClickType Tag, bool bForceUpdatge = false, bool bForceMoveBegin = true)
  {
    if (!bForceUpdatge && Tag == this.CurrentTag)
      return;
    if (!bForceUpdatge || Tag != this.CurrentTag)
    {
      UIBookMark.ClickType currentTag = this.CurrentTag;
      this.BookTag[(int) (byte) this.CurrentTag].alpha = 0.0f;
      this.CurrentTag = Tag;
      ((Graphic) this.BookTagText[(int) (byte) currentTag]).color = this.TabTextColor;
      ((Graphic) this.BookTagText[(int) (byte) this.CurrentTag]).color = Color.white;
    }
    else
      ((Graphic) this.BookTagText[(int) (byte) this.CurrentTag]).color = Color.white;
    DataManager instance = DataManager.Instance;
    int itemidx = 0;
    Vector2 vector2 = Vector2.zero;
    if (!bForceMoveBegin)
    {
      itemidx = this.BookScrollView.GetBeginIdx();
      vector2 = this.BookScrollRect.anchoredPosition;
    }
    this.ItemsHeight.Clear();
    int currentTag1 = (int) this.CurrentTag;
    this.KindData = instance.RoleBookMark.KindDataIDIndex[(int) this.TypeId[currentTag1]];
    this.DataCount = this.CurrentTag != UIBookMark.ClickType.TabAll ? instance.RoleBookMark.KindDataCount[(int) this.TypeId[currentTag1]] : (byte) instance.RoleAttr.BookmarkNum;
    for (byte index = 0; (int) index < (int) this.DataCount; ++index)
      this.ItemsHeight.Add(83f);
    if (this.ItemsHeight.Count == 0)
    {
      this.BookScrollView.gameObject.SetActive(false);
      ((Component) this.MessageTrans).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.MessageTrans).gameObject.SetActive(false);
      this.BookScrollView.gameObject.SetActive(true);
      this.BookScrollView.AddNewDataHeight(this.ItemsHeight);
    }
    if (bForceMoveBegin)
      return;
    this.BookScrollView.GoTo(itemidx, vector2.y);
  }

  private void ChangeAllianceTag(
    UIBookMark.ClickType Tag,
    UIBookMark.ClickType RoleSubTag,
    bool bForceUpdatge = false,
    bool bForceMoveBegin = true)
  {
    if (!bForceUpdatge && Tag == this.CurrentAllianceTag)
      return;
    if (DataManager.Instance.RoleAlliance.Id == 0U && Tag == UIBookMark.ClickType.AllianceTag)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      DataManager.Instance.SetSelectRequest = 0;
      menu.OpenMenu(EGUIWindow.UI_AllianceHint);
    }
    else
    {
      bool bForceUpdatge1 = false;
      if (!bForceUpdatge || Tag != this.CurrentAllianceTag)
      {
        if (Tag != this.CurrentAllianceTag)
          bForceUpdatge1 = true;
        this.AllianceTag[(int) (this.CurrentAllianceTag - 9)].alpha = 0.0f;
        this.CurrentAllianceTag = Tag;
      }
      else
        bForceUpdatge1 = bForceUpdatge;
      DataManager instance = DataManager.Instance;
      if (this.CurrentAllianceTag == UIBookMark.ClickType.RoleTag)
        this.BookTagObj.SetActive(true);
      else
        this.BookTagObj.SetActive(false);
      this.PageInfoStr.ClearString();
      if (this.CurrentAllianceTag == UIBookMark.ClickType.RoleTag)
      {
        this.MainTitle.text = instance.mStringTable.GetStringByID(4583U);
        this.MessageText.text = instance.mStringTable.GetStringByID(790U);
        this.PageInfoStr.IntToFormat((long) instance.RoleAttr.BookmarkNum);
        this.PageInfoStr.IntToFormat((long) instance.RoleAttr.BookmarkLimit);
      }
      else
      {
        this.MainTitle.text = instance.mStringTable.GetStringByID(12636U);
        this.MessageText.text = instance.mStringTable.GetStringByID(12630U);
        this.PageInfoStr.IntToFormat((long) instance.RoleBookMark.AllianceBookCount);
        this.PageInfoStr.IntToFormat(20L);
      }
      if (GUIManager.Instance.IsArabic)
        this.PageInfoStr.AppendFormat("{1} / {0}");
      else
        this.PageInfoStr.AppendFormat("{0} / {1}");
      this.PageInfo.text = this.PageInfoStr.ToString();
      this.PageInfo.SetAllDirty();
      this.PageInfo.cachedTextGenerator.Invalidate();
      if (Tag == UIBookMark.ClickType.RoleTag)
      {
        this.ChangeTag(RoleSubTag, bForceUpdatge1, bForceMoveBegin);
      }
      else
      {
        int itemidx = 0;
        Vector2 vector2 = Vector2.zero;
        if (!bForceMoveBegin)
        {
          itemidx = this.BookScrollView.GetBeginIdx();
          vector2 = this.BookScrollRect.anchoredPosition;
        }
        this.ItemsHeight.Clear();
        this.KindData = instance.RoleBookMark.AllianceIDIndex;
        this.DataCount = instance.RoleBookMark.AllianceBookCount;
        for (byte index = 0; (int) index < (int) this.DataCount; ++index)
          this.ItemsHeight.Add(83f);
        if (this.ItemsHeight.Count == 0)
        {
          this.BookScrollView.gameObject.SetActive(false);
          ((Component) this.MessageTrans).gameObject.SetActive(true);
        }
        else
        {
          ((Component) this.MessageTrans).gameObject.SetActive(false);
          this.BookScrollView.gameObject.SetActive(true);
          this.BookScrollView.AddNewDataHeight(this.ItemsHeight);
        }
        if (bForceMoveBegin)
          return;
        this.BookScrollView.GoTo(itemidx, vector2.y);
      }
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        DataManager.Instance.RoleBookMark.CheckUpdate(false);
        if (DataManager.Instance.RoleAlliance.Id <= 0U)
          break;
        DataManager.Instance.RoleBookMark.CheckUpdate_Alliance(false);
        break;
      case NetworkNews.Refresh_Alliance:
        if (this.CurrentAllianceTag != UIBookMark.ClickType.AllianceTag)
          break;
        if (DataManager.Instance.RoleAlliance.Id == 0U)
        {
          Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
          if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
            menu.CloseMenu_Alliance(EGUIWindow.UI_BagFilter);
        }
        if (this.AllianceRank == DataManager.Instance.RoleAlliance.Rank)
          break;
        this.UpdateAllianceRank(DataManager.Instance.RoleAlliance.Rank);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        for (int index = 0; index < this.RefreshTextList.Count; ++index)
        {
          if ((UnityEngine.Object) this.RefreshTextList[index] != (UnityEngine.Object) null && ((Component) this.RefreshTextList[index]).gameObject.activeSelf && ((Behaviour) this.RefreshTextList[index]).enabled)
          {
            ((Behaviour) this.RefreshTextList[index]).enabled = false;
            ((Behaviour) this.RefreshTextList[index]).enabled = true;
          }
        }
        break;
    }
  }

  public override void UpdateUI(int arge1, int arge2)
  {
    UIBookMark.ClickType clickType = this.CurrentAllianceTag;
    UIBookMark.ClickType currentTag = this.CurrentTag;
    if (arge1 > 0)
    {
      clickType = (UIBookMark.ClickType) (arge1 >> 16);
      currentTag = (UIBookMark.ClickType) this.TypeId[arge1 & (int) ushort.MaxValue];
    }
    this.ChangeAllianceTag(clickType, currentTag, true, false);
    if (arge2 <= 0)
      return;
    this.BookScrollView.GoTo(this.getBookMarkIndex(arge1, arge2, clickType));
  }

  private void UpdateAllianceRank(AllianceRank rank = AllianceRank.RANK5)
  {
    if (rank != this.AllianceRank)
    {
      bool bEdit = rank == AllianceRank.RANK5 || rank == AllianceRank.RANK4;
      for (int index = 0; index < this.BookItem.Length; ++index)
        this.BookItem[index].EditMode(bEdit);
    }
    this.AllianceRank = rank;
  }

  private int getBookMarkIndex(int type, int mapID, UIBookMark.ClickType bookType)
  {
    BookMark roleBookMark = DataManager.Instance.RoleBookMark;
    switch (bookType)
    {
      case UIBookMark.ClickType.RoleTag:
        if (roleBookMark.KindDataCount.Length <= type)
          return 0;
        for (int index = (int) roleBookMark.KindDataCount[type] - 1; index >= 0; --index)
        {
          if (roleBookMark.AllData[(int) roleBookMark.KindDataIDIndex[type][index]].MapID == mapID)
          {
            int bookMarkIndex = (int) roleBookMark.KindDataCount[type] - index - 3;
            if (bookMarkIndex < 0)
              bookMarkIndex = 0;
            if ((int) roleBookMark.KindDataCount[type] - 6 < bookMarkIndex)
              bookMarkIndex = (int) roleBookMark.KindDataCount[type] - 6;
            return bookMarkIndex;
          }
        }
        break;
      case UIBookMark.ClickType.AllianceTag:
        for (int index = (int) roleBookMark.AllianceBookCount - 1; index >= 0; --index)
        {
          if (roleBookMark.AllAllianceData[(int) roleBookMark.AllianceIDIndex[index]].MapID == mapID)
          {
            int bookMarkIndex = (int) roleBookMark.AllianceBookCount - index - 3;
            if (bookMarkIndex < 0)
              bookMarkIndex = 0;
            if ((int) roleBookMark.AllianceBookCount - 6 < bookMarkIndex)
              bookMarkIndex = (int) roleBookMark.AllianceBookCount - 6;
            return bookMarkIndex;
          }
        }
        break;
    }
    return 0;
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    DataManager instance = DataManager.Instance;
    if ((UnityEngine.Object) this.BookItem[panelObjectIdx].BookIcon == (UnityEngine.Object) null)
    {
      Transform child = this.ThisTransfrom.GetChild(5).GetChild(0).GetChild(0).GetChild(panelObjectIdx);
      this.BookItem[panelObjectIdx].BookIcon = child.GetChild(0).GetComponent<Image>();
      this.BookItem[panelObjectIdx].Edit = child.GetChild(2).GetChild(0).GetComponent<UIButton>();
      this.BookItem[panelObjectIdx].Name = child.GetChild(4).GetComponent<UIText>();
      this.BookItem[panelObjectIdx].Name.SetCheckArabic(true);
      this.BookItem[panelObjectIdx].Content = child.GetChild(5).GetComponent<UIText>();
      this.AddRefreshText(this.BookItem[panelObjectIdx].Name);
      this.AddRefreshText(this.BookItem[panelObjectIdx].Content);
      this.BookItem[panelObjectIdx].Trash = child.GetChild(2).GetChild(2).GetComponent<UIButton>();
      this.BookItem[panelObjectIdx].Move = child.GetChild(2).GetChild(1).GetComponent<UIButton>();
      this.BookItem[panelObjectIdx].Type1 = child.GetChild(2);
      this.BookItem[panelObjectIdx].Type2 = child.GetChild(3);
      this.BookItem[panelObjectIdx].SelImage = this.BookItem[panelObjectIdx].Type2.GetChild(0).GetChild(0).GetComponent<Image>();
      this.AddRefreshText(child.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>());
      this.BookItem[panelObjectIdx].Edit.m_BtnID1 = 4;
      this.BookItem[panelObjectIdx].Edit.m_Handler = (IUIButtonClickHandler) this;
      this.BookItem[panelObjectIdx].Move.m_BtnID1 = 6;
      this.BookItem[panelObjectIdx].Move.m_Handler = (IUIButtonClickHandler) this;
      this.BookItem[panelObjectIdx].Trash.m_BtnID1 = 5;
      this.BookItem[panelObjectIdx].Trash.m_Handler = (IUIButtonClickHandler) this;
      this.BookItem[panelObjectIdx].Init();
    }
    if (instance.RoleBookMark.AllData == null)
      return;
    int index = (int) this.DataCount - 1 - dataIdx;
    if (index < 0)
      return;
    BookMarkData bookMarkData = this.CurrentAllianceTag != UIBookMark.ClickType.RoleTag ? instance.RoleBookMark.AllAllianceData[(int) this.KindData[index]] : instance.RoleBookMark.AllData[(int) this.KindData[index]];
    this.BookItem[panelObjectIdx].dataIndex = index;
    this.BookItem[panelObjectIdx].BookIcon.sprite = this.BookSpriteArr.GetSprite((int) bookMarkData.Type);
    this.BookItem[panelObjectIdx].Edit.m_BtnID2 = (int) bookMarkData.ID;
    this.BookItem[panelObjectIdx].Trash.m_BtnID2 = (int) bookMarkData.ID;
    this.BookItem[panelObjectIdx].Move.m_BtnID2 = (int) bookMarkData.ID;
    this.BookItem[panelObjectIdx].SetName(bookMarkData.Name);
    this.BookItem[panelObjectIdx].SetContent(bookMarkData.KingdomID, instance.RoleBookMark.GetMapID(bookMarkData.ID, (BookMark.eBookType) (this.CurrentAllianceTag - 9)));
    this.BookItem[panelObjectIdx].SetType(this.Type);
    if (this.Type == UIBookMark.BookMarkType.Type2)
      this.BookItem[panelObjectIdx].SetSelect(this.BookMarkSel[index] > (byte) 0);
    if (this.CurrentAllianceTag == UIBookMark.ClickType.RoleTag || instance.RoleAlliance.Rank >= AllianceRank.RANK4)
      this.BookItem[panelObjectIdx].EditMode();
    else
      this.BookItem[panelObjectIdx].EditMode(false);
  }

  public void Update()
  {
    this.DeltaTime += Time.deltaTime;
    if ((double) this.DeltaTime >= 2.0)
      this.DeltaTime = 0.0f;
    float num = (double) this.DeltaTime <= 1.0 ? this.DeltaTime : 2f - this.DeltaTime;
    this.BookTag[(int) this.CurrentTag].alpha = num;
    this.AllianceTag[(int) (this.CurrentAllianceTag - 9)].alpha = num;
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    if (this.Type == UIBookMark.BookMarkType.Type1)
      return;
    if ((int) this.SelectCount == (int) this.SelectCountMax)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(6088U), (ushort) byte.MaxValue);
    }
    else
    {
      for (int index = 0; index < this.BookItem.Length; ++index)
      {
        if (this.BookItem[index].dataIndex == dataIndex)
        {
          if (!this.BookItem[index].bSelect)
          {
            ++this.SelectCount;
            this.BookMarkSel[dataIndex] = (byte) this.BookItem[index].Edit.m_BtnID2;
          }
          else
          {
            this.BookMarkSel[dataIndex] = (byte) 0;
            --this.SelectCount;
          }
          this.BookItem[index].SetSelect(this.BookMarkSel[dataIndex] > (byte) 0);
          break;
        }
      }
    }
  }

  private void AddRefreshText(UIText text) => this.RefreshTextList.Add(text);

  protected struct ItemEdit
  {
    public int dataIndex;
    public Image BookIcon;
    public Image SelImage;
    public UIButton Edit;
    public UIText Name;
    public UIText Content;
    public UIButton Trash;
    public UIButton Move;
    public Transform Type1;
    public Transform Type2;
    public bool bSelect;
    private UIBookMark.BookMarkType CurType;
    public CString NameStr;
    public CString ContentStr;

    public void Init()
    {
      this.NameStr = StringManager.Instance.SpawnString(50);
      this.ContentStr = StringManager.Instance.SpawnString(100);
      this.CurType = UIBookMark.BookMarkType.Type2;
      this.bSelect = false;
    }

    public void SetType(UIBookMark.BookMarkType type)
    {
      if (this.CurType == type)
        return;
      this.CurType = type;
      if (this.CurType == UIBookMark.BookMarkType.Type1)
      {
        this.Type2.gameObject.SetActive(false);
        this.Type1.gameObject.SetActive(true);
      }
      else
      {
        this.Type2.gameObject.SetActive(true);
        this.Type1.gameObject.SetActive(false);
      }
    }

    public void Destroy()
    {
      StringManager.Instance.DeSpawnString(this.NameStr);
      StringManager.Instance.DeSpawnString(this.ContentStr);
    }

    public void SetName(CString bookmarkName)
    {
      this.NameStr.ClearString();
      this.NameStr.Append(bookmarkName);
      this.Name.text = this.NameStr.ToString();
      this.Name.SetAllDirty();
      this.Name.cachedTextGenerator.Invalidate();
    }

    public void SetContent(ushort KingdomID, int MapID)
    {
      StringTable mStringTable = DataManager.Instance.mStringTable;
      this.ContentStr.ClearString();
      this.ContentStr.StringToFormat(mStringTable.GetStringByID(4588U));
      this.ContentStr.StringToFormat(mStringTable.GetStringByID(4504U));
      this.ContentStr.IntToFormat((long) KingdomID);
      uint WonderID = DataManager.MapDataController.CheckWonderMapID((uint) MapID, KingdomID);
      Vector2 vector2 = WonderID != 40U ? DataManager.MapDataController.GetYolkPos((ushort) WonderID, KingdomID) : GameConstants.getTileMapPosbyMapID(MapID);
      this.ContentStr.StringToFormat(mStringTable.GetStringByID(4505U));
      this.ContentStr.IntToFormat((long) vector2.x);
      this.ContentStr.StringToFormat(mStringTable.GetStringByID(4506U));
      this.ContentStr.IntToFormat((long) vector2.y);
      if (GUIManager.Instance.IsArabic)
        this.ContentStr.AppendFormat("{0} : {2}{1} {4}{3} {6}{5}");
      else
        this.ContentStr.AppendFormat("{0} : {1}{2} {3}{4} {5}{6}");
      this.Content.text = this.ContentStr.ToString();
      this.Content.SetAllDirty();
      this.Content.cachedTextGenerator.Invalidate();
    }

    public void SetSelect(bool bSelect)
    {
      if (this.bSelect == bSelect)
        return;
      this.bSelect = bSelect;
      ((Behaviour) this.SelImage).enabled = bSelect;
    }

    public void EditMode(bool bEdit = true)
    {
      if ((UnityEngine.Object) this.Edit == (UnityEngine.Object) null)
        return;
      ((Component) this.Edit).gameObject.SetActive(bEdit);
      ((Component) this.Trash).gameObject.SetActive(bEdit);
    }
  }

  public enum ClickType
  {
    TabAll,
    TabFavor,
    TabEnemy,
    TabFriend,
    ItemEdit,
    ItemDel,
    ItemMove,
    Close,
    Import,
    RoleTag,
    AllianceTag,
  }

  private enum UIControl
  {
    BackImage,
    BookTag,
    AllianceTag,
    Type1,
    Type2,
    ScrollCont,
    Message,
    Close,
    Item,
  }

  private enum ItemControl
  {
    Icon,
    Frame,
    Type1,
    Type2,
    Name,
    Content,
  }

  public enum BookMarkType
  {
    Type1 = 5,
    Type2 = 6,
  }

  private enum SaveHeader
  {
    Tag = 0,
    ScrollIndex = 1,
    ScrollPos = 3,
    AllianceTag = 7,
  }
}
