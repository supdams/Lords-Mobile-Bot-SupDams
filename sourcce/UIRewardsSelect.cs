// Decompiled with JetBrains decompiler
// Type: UIRewardsSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal class UIRewardsSelect : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUILEBtnClickHandler
{
  private const ushort MaxRank = 3;
  private const int MaxData = 35;
  private const int MaxScrollCount = 6;
  private const float ItemHeight = 111f;
  private const float FingerShowRangeBegin = -30f;
  private const float FingerShowRangeEnd = 40f;
  private GUIManager GM;
  private DataManager DM;
  private MobilizationManager MD;
  private ActivityManager AC;
  private Font TTF;
  private Door door;
  private ScrollPanel m_ScrollPanel;
  private RectTransform m_ScrollContentRT;
  private UIButton m_Send;
  private UIButton m_Exit;
  private UIText m_TimeText;
  private UIText m_OverText;
  private UIText m_TitleText1;
  private UIText m_TitleText2;
  private Image m_FlashImage;
  private Image m_TimeIcon;
  private Image m_SpecialPrize;
  private Image m_AllyRankImage;
  private UIButtonHint m_GitImageHint;
  private UIButtonHint m_AllyRankImageHint;
  private GameObject m_FingerImageObject;
  private float ColorTime;
  private float FlashTime = 1.8f;
  private CString m_TimeSrt;
  private CString m_GiftHintStr;
  private UISpritesArray m_SpArray;
  private UIRewardsSelect.sRewardsSelect[] m_Data = new UIRewardsSelect.sRewardsSelect[35];
  private UIRewardsSelect.panelObject[] m_PanelObject = new UIRewardsSelect.panelObject[6];
  private byte[] m_SendData = new byte[35];
  private bool bFirstInit = true;
  private bool bReadOnly;
  private bool bShowFirstClick;
  private UIRewardsSelect.eRewardsSelectType m_Type = UIRewardsSelect.eRewardsSelectType.Selection;
  private int SelectCount;
  private float m_TimeTick = 1f;
  private byte MaxDegree;

  public override void OnOpen(int arg1, int arg2)
  {
    this.bReadOnly = arg1 == 1;
    this.GM = GUIManager.Instance;
    this.DM = DataManager.Instance;
    this.MD = MobilizationManager.Instance;
    this.AC = ActivityManager.Instance;
    this.TTF = this.GM.GetTTFFont();
    this.door = this.GM.FindMenu(EGUIWindow.Door) as Door;
    this.m_TimeSrt = StringManager.Instance.SpawnString();
    this.m_GiftHintStr = StringManager.Instance.SpawnString(100);
    this.MaxDegree = this.GetDegree();
    this.InitUI();
    this.MD.GetRewardsSelecteDataSave();
    if (this.MD.bFirstRequestActivityAmDegeePrize)
    {
      this.m_ScrollPanel.gameObject.SetActive(true);
      this.SetData();
      this.UpdateScrollPanel();
      this.m_ScrollPanel.GoTo(this.MD.UIRewardsSelectIndex, this.MD.RewardsSelectPosY);
    }
    else
    {
      this.MD.SendActivityAmDegeePrize();
      this.SetFakeData();
      this.m_ScrollPanel.gameObject.SetActive(false);
    }
    this.CheckType();
    this.bShowFirstClick = this.CheckFirstClick();
    ((Component) this.m_SpecialPrize).gameObject.SetActive(this.IsSpecialPrize());
  }

  public override void OnClose()
  {
    for (int index1 = 0; index1 < 6; ++index1)
    {
      if (this.m_PanelObject[index1].m_NumTextStr != null)
      {
        StringManager.Instance.DeSpawnString(this.m_PanelObject[index1].m_NumTextStr);
        this.m_PanelObject[index1].m_NumTextStr = (CString) null;
      }
      for (int index2 = 0; index2 < 3; ++index2)
      {
        if (this.m_PanelObject[index1].m_ItemNumTextStr[index2] != null)
        {
          StringManager.Instance.DeSpawnString(this.m_PanelObject[index1].m_ItemNumTextStr[index2]);
          this.m_PanelObject[index1].m_ItemNumTextStr[index2] = (CString) null;
        }
      }
    }
    if (this.m_TimeSrt != null)
    {
      StringManager.Instance.DeSpawnString(this.m_TimeSrt);
      this.m_TimeSrt = (CString) null;
    }
    if (this.m_GiftHintStr != null)
    {
      StringManager.Instance.DeSpawnString(this.m_GiftHintStr);
      this.m_GiftHintStr = (CString) null;
    }
    if ((Object) this.m_ScrollPanel != (Object) null && (Object) this.m_ScrollContentRT != (Object) null)
    {
      this.MD.UIRewardsSelectIndex = this.m_ScrollPanel.GetTopIdx();
      this.MD.RewardsSelectPosY = this.m_ScrollContentRT.anchoredPosition.y;
    }
    this.MD.SetRewardsSelectDataSave();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 1:
        if (!this.m_ScrollPanel.gameObject.activeSelf)
          this.m_ScrollPanel.gameObject.SetActive(true);
        this.SetData();
        this.UpdateScrollPanel();
        this.CheckType();
        this.bShowFirstClick = this.CheckFirstClick();
        if (this.MD == null || !((Object) this.m_SpecialPrize != (Object) null))
          break;
        ((Component) this.m_SpecialPrize).gameObject.SetActive(this.IsSpecialPrize());
        break;
      case 2:
        this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1594U), (ushort) byte.MaxValue);
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 3:
        if (!this.m_ScrollPanel.gameObject.activeSelf)
          this.m_ScrollPanel.gameObject.SetActive(true);
        this.SetData();
        this.UpdateScrollPanel();
        this.CheckType();
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if (ActivityManager.Instance.AllyMobilizationData.EventBeginTime == this.MD.AllyMobilizationBeginTime)
          break;
        this.MD.SendActivityAmDegeePrize();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public override bool OnBackButtonClick() => false;

  private void Update()
  {
    this.UpdateTimer();
    if (this.MD.bRewardsSelectFirstClickItem || !this.bShowFirstClick)
      return;
    if (this.CheckFingerRange())
      this.m_FingerImageObject.SetActive(true);
    else
      this.m_FingerImageObject.SetActive(false);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID4 == 300)
    {
      this.OnClick(sender.m_BtnID1, sender.m_BtnID2, sender.m_BtnID3);
      this.OpenDetail(sender.m_BtnID1, sender.m_BtnID2);
    }
    else
    {
      switch (sender.m_BtnID1)
      {
        case 100:
          if (!((Object) this.door != (Object) null))
            break;
          this.door.CloseMenu();
          break;
        case 200:
          if (this.m_Type == UIRewardsSelect.eRewardsSelectType.Decide)
          {
            this.MD.SendActivityAmGetDegreePrize();
            break;
          }
          if (this.m_Type == UIRewardsSelect.eRewardsSelectType.Preview)
          {
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9794U), (ushort) 254);
            break;
          }
          if (this.m_Type != UIRewardsSelect.eRewardsSelectType.Selection)
            break;
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1372U), (ushort) byte.MaxValue);
          break;
        default:
          this.OnClick(sender.m_BtnID1, sender.m_BtnID2, sender.m_BtnID3, true);
          break;
      }
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelObjectIdx >= this.m_PanelObject.Length || panelObjectIdx < 0)
      return;
    if ((Object) this.m_PanelObject[panelObjectIdx].m_NumText == (Object) null)
    {
      this.m_PanelObject[panelObjectIdx].m_Background = item.transform.GetChild(0).GetComponent<Image>();
      this.m_PanelObject[panelObjectIdx].m_NumText = item.transform.GetChild(1).GetChild(1).GetComponent<UIText>();
      this.m_PanelObject[panelObjectIdx].m_NumText.font = this.TTF;
      this.m_PanelObject[panelObjectIdx].m_SpecialPrize = item.transform.GetChild(1).GetChild(2).GetComponent<Image>();
      for (int index = 0; index < 3; ++index)
      {
        this.m_PanelObject[panelObjectIdx].m_ItemBackground[index] = item.transform.GetChild(2 + index).GetChild(0).GetComponent<Image>();
        this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[index] = item.transform.GetChild(2 + index).GetChild(0).GetChild(0).GetComponent<UIHIBtn>();
        this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[index].m_Handler = (IUIHIBtnClickHandler) this;
        this.m_PanelObject[panelObjectIdx].m_BtnHint[index] = item.transform.GetChild(2 + index).GetChild(0).GetChild(0).GetComponent<UIButtonHint>();
        this.m_PanelObject[panelObjectIdx].m_BtnHint[index].m_eHint = EUIButtonHint.CountDown;
        this.m_PanelObject[panelObjectIdx].m_BtnHint[index].m_Handler = (MonoBehaviour) this;
        this.m_PanelObject[panelObjectIdx].m_BtnHint[index].DelayTime = 0.2f;
        this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[index] = item.transform.GetChild(2 + index).GetChild(0).GetChild(3).GetComponent<UILEBtn>();
        this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[index].m_Handler = (IUILEBtnClickHandler) this;
        this.m_PanelObject[panelObjectIdx].m_BtnHint_LE[index] = item.transform.GetChild(2 + index).GetChild(0).GetChild(3).GetComponent<UIButtonHint>();
        this.m_PanelObject[panelObjectIdx].m_BtnHint_LE[index].m_eHint = EUIButtonHint.CountDown;
        this.m_PanelObject[panelObjectIdx].m_BtnHint_LE[index].m_Handler = (MonoBehaviour) this;
        this.m_PanelObject[panelObjectIdx].m_BtnHint_LE[index].DelayTime = 0.2f;
        this.m_PanelObject[panelObjectIdx].m_DetailBtn[index] = item.transform.GetChild(2 + index).GetChild(0).GetChild(4).GetComponent<UIButton>();
        this.m_PanelObject[panelObjectIdx].m_DetailBtn[index].m_Handler = (IUIButtonClickHandler) this;
        this.m_PanelObject[panelObjectIdx].m_ItemSelectImage[index] = item.transform.GetChild(2 + index).GetChild(0).GetChild(1).GetComponent<Image>();
        this.m_PanelObject[panelObjectIdx].m_ItemNumText[index] = item.transform.GetChild(2 + index).GetChild(0).GetChild(2).GetComponent<UIText>();
        this.m_PanelObject[panelObjectIdx].m_ItemNumText[index].font = this.TTF;
        this.m_PanelObject[panelObjectIdx].m_Btn[index] = item.transform.GetChild(2 + index).GetChild(0).GetComponent<UIButton>();
        this.m_PanelObject[panelObjectIdx].m_Btn[index].m_Handler = (IUIButtonClickHandler) this;
        this.m_PanelObject[panelObjectIdx].m_LockImage[index] = item.transform.GetChild(2 + index).GetChild(0).GetChild(5).GetComponent<Image>();
      }
      this.m_PanelObject[panelObjectIdx].m_MaskImage = item.transform.GetChild(6).GetComponent<Image>();
    }
    this.SetScrollItem(dataIdx, panelObjectIdx);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnClick(int btnID1, int btnID2, int btnID3, bool showMsg = false)
  {
    if (btnID1 >= (int) this.DM.RoleAlliance.AMMaxDegree)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(3713U), (ushort) 254);
    else if (!this.bReadOnly && btnID1 >= 0 && btnID1 < 35 && btnID1 < this.MD.m_RecvRewardsSelect.Length)
    {
      if (this.m_Data[btnID1].SelectIndex == (byte) 4)
        return;
      this.m_Data[btnID1].SelectIndex = (byte) (btnID2 + 1);
      this.MD.m_RecvRewardsSelect[btnID1].SelectIndex = this.m_Data[btnID1].SelectIndex;
      this.SetItemSelect(btnID1, btnID3);
      this.CheckType();
      if (btnID1 != 0 || this.MD.bRewardsSelectFirstClickItem)
        return;
      this.MD.bRewardsSelectFirstClickItem = true;
      this.CheckFirstClick();
    }
    else
    {
      if (!showMsg)
        return;
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9794U), (ushort) 254);
    }
  }

  public void OpenDetail(int btnID1, int btnID2)
  {
    ushort HIID = 0;
    if (btnID1 >= 0 && btnID1 < this.m_Data.Length && btnID2 < 3)
      HIID = this.m_Data[btnID1].ItemID[btnID2];
    MallManager.Instance.OpenDetail(HIID);
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    this.OnClick(sender.m_BtnID1, sender.m_BtnID2, sender.m_BtnID3);
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
    this.OnClick(sender.m_BtnID1, sender.m_BtnID2, sender.m_BtnID3);
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if ((Object) sender != (Object) null && (Object) this.m_AllyRankImageHint != (Object) null && (Object) sender == (Object) this.m_AllyRankImageHint)
    {
      ushort[] numArray = new ushort[5]
      {
        (ushort) 1028,
        (ushort) 1027,
        (ushort) 1026,
        (ushort) 1025,
        (ushort) 1024
      };
      this.m_GiftHintStr.ClearString();
      if (this.DM.RoleAlliance.AMRank >= (byte) 0 && (int) this.DM.RoleAlliance.AMRank < numArray.Length)
        this.m_GiftHintStr.Append(this.DM.mStringTable.GetStringByID((uint) numArray[(int) this.DM.RoleAlliance.AMRank]));
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.m_GiftHintStr, Vector2.zero);
    }
    else if ((Object) sender != (Object) null && (Object) this.m_GitImageHint != (Object) null && (Object) sender == (Object) this.m_GitImageHint && this.IsSpecialPrize())
    {
      this.m_GiftHintStr.ClearString();
      this.m_GiftHintStr.StringToFormat(this.DM.mStringTable.GetStringByID(1339U));
      this.m_GiftHintStr.AppendFormat(this.DM.mStringTable.GetStringByID(1003U));
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.m_GiftHintStr, Vector2.zero);
    }
    else
    {
      if (this.GM.IsLeadItem(DataManager.Instance.EquipTable.GetRecordByKey(sender.Parm1).EquipKind))
      {
        sender.SetFadeOutObject(EUIButtonHint.UILeBtn);
        this.GM.m_LordInfo.Show(sender, sender.Parm1, sender.Parm2);
      }
      else
      {
        sender.SetFadeOutObject(EUIButtonHint.UIHIBtn);
        this.GM.m_SimpleItemInfo.Show(sender, sender.Parm1);
      }
      AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if ((Object) sender != (Object) null && (Object) this.m_GitImageHint != (Object) null && (Object) sender == (Object) this.m_AllyRankImageHint)
      GUIManager.Instance.m_Hint.Hide(true);
    else if ((Object) sender != (Object) null && (Object) this.m_GitImageHint != (Object) null && (Object) sender == (Object) this.m_GitImageHint)
      GUIManager.Instance.m_Hint.Hide(true);
    else
      this.GM.m_SimpleItemInfo.Hide(sender);
  }

  private void InitUI()
  {
    for (int index = 0; index < this.m_Data.Length; ++index)
      this.m_Data[index].Init();
    for (int index = 0; index < this.m_PanelObject.Length; ++index)
      this.m_PanelObject[index].Init();
    this.m_SpArray = this.transform.gameObject.GetComponent<UISpritesArray>();
    this.m_TitleText1 = this.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
    this.m_TitleText1.font = this.TTF;
    this.m_TitleText1.text = this.DM.mStringTable.GetStringByID(1339U);
    this.m_TitleText2 = this.transform.GetChild(0).GetChild(8).GetComponent<UIText>();
    this.m_TitleText2.font = this.TTF;
    this.m_TitleText2.text = this.DM.mStringTable.GetStringByID(1368U);
    this.m_OverText = this.transform.GetChild(0).GetChild(10).GetComponent<UIText>();
    this.m_OverText.font = this.TTF;
    this.m_OverText.text = this.DM.mStringTable.GetStringByID(1369U);
    ((Graphic) this.m_OverText).color = new Color(1f, 0.968f, 0.6f, 1f);
    this.m_TimeIcon = this.transform.GetChild(0).GetChild(6).GetComponent<Image>();
    this.m_TimeText = this.transform.GetChild(0).GetChild(7).GetComponent<UIText>();
    this.m_TimeText.font = this.TTF;
    this.m_GitImageHint = this.transform.GetChild(0).GetChild(9).gameObject.AddComponent<UIButtonHint>();
    this.m_GitImageHint.m_Handler = (MonoBehaviour) this;
    this.m_GitImageHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.m_SpecialPrize = this.transform.GetChild(0).GetChild(11).GetComponent<Image>();
    this.m_ScrollPanel = this.transform.GetChild(1).GetComponent<ScrollPanel>();
    this.m_Send = this.transform.GetChild(3).GetComponent<UIButton>();
    this.m_Send.m_BtnID1 = 200;
    this.m_Send.m_Handler = (IUIButtonClickHandler) this;
    this.m_FlashImage = this.transform.GetChild(3).GetChild(0).GetComponent<Image>();
    UIText component1 = this.transform.GetChild(3).GetChild(1).GetComponent<UIText>();
    component1.font = this.TTF;
    component1.text = this.DM.mStringTable.GetStringByID(1542U);
    this.m_Exit = this.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
    this.m_Exit.m_BtnID1 = 100;
    this.m_Exit.m_Handler = (IUIButtonClickHandler) this;
    Image component2 = this.transform.GetChild(4).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component2).material = this.door.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (Object) component2)
      ((Behaviour) component2).enabled = false;
    this.m_Exit.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.m_Exit.image).material = this.door.LoadMaterial();
    this.m_FingerImageObject = this.transform.GetChild(5).gameObject;
    for (int index = 2; index <= 4; ++index)
    {
      this.GM.InitianHeroItemImg(((Component) this.transform.GetChild(2).GetChild(index).GetChild(0).GetChild(0).GetComponent<UIHIBtn>()).gameObject.transform, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false);
      UILEBtn component3 = this.transform.GetChild(2).GetChild(index).GetChild(0).GetChild(3).GetComponent<UILEBtn>();
      ((Component) component3).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
      this.GM.InitLordEquipImg(((Component) component3).gameObject.transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    }
    this.m_AllyRankImage = this.transform.GetChild(0).GetChild(12).GetComponent<Image>();
    this.m_AllyRankImageHint = this.transform.GetChild(0).GetChild(12).gameObject.AddComponent<UIButtonHint>();
    this.m_AllyRankImageHint.m_Handler = (MonoBehaviour) this;
    this.m_AllyRankImageHint.m_eHint = EUIButtonHint.DownUpHandler;
    if ((Object) this.m_AllyRankImage != (Object) null)
    {
      if (this.DM.RoleAlliance.AMRank >= (byte) 0)
      {
        this.GM.SetAllyRankImage(this.m_AllyRankImage, this.DM.RoleAlliance.AMRank);
        ((Component) this.m_AllyRankImage).gameObject.SetActive(true);
      }
      else
        ((Component) this.m_AllyRankImage).gameObject.SetActive(false);
    }
    ((Graphic) this.transform.GetChild(2).GetChild(5).GetComponent<Image>()).color = new Color(1f, 1f, 1f, 0.6274f);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 1);
  }

  private void SetData()
  {
    this.SelectCount = 0;
    for (int Index = 0; Index < this.MD.m_RecvRewardsSelect.Length && Index < 35 && Index < (int) this.MaxDegree; ++Index)
    {
      MobilizationDegreeData mobilizationDegreeData = this.MD.SpecialPrize != (byte) 2 ? (this.MD.SpecialPrize != (byte) 3 ? (this.MD.SpecialPrize != (byte) 4 ? (this.MD.SpecialPrize != (byte) 5 ? this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex(Index) : this.DM.AllianceMobilizationDegreeInfos[3].GetRecordByIndex(Index)) : this.DM.AllianceMobilizationDegreeInfos[2].GetRecordByIndex(Index)) : this.DM.AllianceMobilizationDegreeInfos[1].GetRecordByIndex(Index)) : this.DM.AllianceMobilizationDegreeInfos[0].GetRecordByIndex(Index);
      for (int index1 = 0; index1 < this.MD.m_RecvRewardsSelect[Index].ItemIndex.Length && index1 < 3; ++index1)
      {
        int index2 = this.MD.m_RecvRewardsSelect[Index].ItemIndex[index1] - 1;
        if (index2 >= 0 && index2 < mobilizationDegreeData.MissionItemData.Length)
        {
          this.m_Data[Index].ItemID[index1] = mobilizationDegreeData.MissionItemData[index2].ItemID;
          this.m_Data[Index].ItemNum[index1] = mobilizationDegreeData.MissionItemData[index2].ItemNum;
          this.m_Data[Index].ItemRank[index1] = mobilizationDegreeData.MissionItemData[index2].ItemRank;
        }
        this.m_Data[Index].SelectIndex = this.MD.m_RecvRewardsSelect[Index].SelectIndex;
      }
    }
  }

  private void UpdateScrollPanel()
  {
    if ((Object) this.m_ScrollPanel == (Object) null)
      return;
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < 35 && index < (int) this.MaxDegree; ++index)
      _DataHeight.Add(111f);
    if (this.bFirstInit)
      this.m_ScrollPanel.IntiScrollPanel(395f, 0.0f, 0.0f, _DataHeight, 6, (IUpDateScrollPanel) this);
    else
      this.m_ScrollPanel.AddNewDataHeight(_DataHeight, false, false);
    UIButtonHint.scrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
    this.m_ScrollContentRT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
    this.bFirstInit = false;
  }

  private void SetScrollItem(int dataIdx, int panelObjectIdx)
  {
    if (dataIdx < 0 || dataIdx >= this.m_Data.Length)
      return;
    this.SetItemNumText(dataIdx, panelObjectIdx);
    this.SetItemHIBtn(dataIdx, panelObjectIdx);
    this.SetItemSelect(dataIdx, panelObjectIdx);
    this.SetItemCount(dataIdx, panelObjectIdx);
    this.SetItemClickBtn(dataIdx, panelObjectIdx);
    this.SetItemMask(dataIdx, panelObjectIdx);
    this.SetBtnHint(dataIdx, panelObjectIdx);
    this.SetSpecialPrizeImg(dataIdx, panelObjectIdx);
    this.SetItemBackground(dataIdx, panelObjectIdx);
  }

  private void SetItemNumText(int dataIdx, int panelObjectIdx)
  {
    this.m_PanelObject[panelObjectIdx].m_NumTextStr.ClearString();
    this.m_PanelObject[panelObjectIdx].m_NumTextStr.IntToFormat((long) (dataIdx + 1));
    this.m_PanelObject[panelObjectIdx].m_NumTextStr.AppendFormat("{0}");
    this.m_PanelObject[panelObjectIdx].m_NumText.text = this.m_PanelObject[panelObjectIdx].m_NumTextStr.ToString();
    this.m_PanelObject[panelObjectIdx].m_NumText.SetAllDirty();
    this.m_PanelObject[panelObjectIdx].m_NumText.cachedTextGenerator.Invalidate();
    if (this.m_Data[dataIdx].SelectIndex == (byte) 4)
      ((Graphic) this.m_PanelObject[panelObjectIdx].m_NumText).color = new Color(1f, 1f, 1f, 0.5333f);
    else
      ((Graphic) this.m_PanelObject[panelObjectIdx].m_NumText).color = new Color(1f, 1f, 1f, 1f);
  }

  private void SetItemCount(int dataIdx, int panelObjectIdx)
  {
    for (int index = 0; index < 3; ++index)
    {
      if (dataIdx >= (int) this.DM.RoleAlliance.AMMaxDegree)
      {
        ((Component) this.m_PanelObject[panelObjectIdx].m_ItemNumText[index]).gameObject.SetActive(false);
      }
      else
      {
        this.m_PanelObject[panelObjectIdx].m_ItemNumTextStr[index].ClearString();
        this.m_PanelObject[panelObjectIdx].m_ItemNumTextStr[index].IntToFormat((long) this.m_Data[dataIdx].ItemNum[index]);
        if (GUIManager.Instance.IsArabic)
          this.m_PanelObject[panelObjectIdx].m_ItemNumTextStr[index].AppendFormat("{0}X");
        else
          this.m_PanelObject[panelObjectIdx].m_ItemNumTextStr[index].AppendFormat("X{0}");
        this.m_PanelObject[panelObjectIdx].m_ItemNumText[index].text = this.m_PanelObject[panelObjectIdx].m_ItemNumTextStr[index].ToString();
        this.m_PanelObject[panelObjectIdx].m_ItemNumText[index].SetAllDirty();
        this.m_PanelObject[panelObjectIdx].m_ItemNumText[index].cachedTextGenerator.Invalidate();
        if (this.m_Data[dataIdx].SelectIndex == (byte) 4)
          ((Graphic) this.m_PanelObject[panelObjectIdx].m_ItemNumText[index]).color = new Color(1f, 1f, 1f, 0.666666f);
        else
          ((Graphic) this.m_PanelObject[panelObjectIdx].m_ItemNumText[index]).color = new Color(1f, 1f, 1f, 1f);
        ((Component) this.m_PanelObject[panelObjectIdx].m_ItemNumText[index]).gameObject.SetActive(true);
      }
    }
  }

  private void SetItemClickBtn(int dataIdx, int panelObjectIdx)
  {
    for (int index = 0; index < 3; ++index)
    {
      this.m_PanelObject[panelObjectIdx].m_Btn[index].m_BtnID1 = dataIdx;
      this.m_PanelObject[panelObjectIdx].m_Btn[index].m_BtnID2 = index;
      this.m_PanelObject[panelObjectIdx].m_Btn[index].m_BtnID3 = panelObjectIdx;
      this.m_PanelObject[panelObjectIdx].m_DetailBtn[index].m_BtnID1 = dataIdx;
      this.m_PanelObject[panelObjectIdx].m_DetailBtn[index].m_BtnID2 = index;
      this.m_PanelObject[panelObjectIdx].m_DetailBtn[index].m_BtnID3 = panelObjectIdx;
      this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[index].m_BtnID1 = dataIdx;
      this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[index].m_BtnID2 = index;
      this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[index].m_BtnID3 = panelObjectIdx;
      this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[index].m_BtnID1 = dataIdx;
      this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[index].m_BtnID2 = index;
      this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[index].m_BtnID3 = panelObjectIdx;
    }
  }

  private void SetItemHIBtn(int dataIdx, int panelObjectIdx)
  {
    for (int index = 0; index < 3; ++index)
    {
      ushort num1 = this.m_Data[dataIdx].ItemID[index];
      byte num2 = this.m_Data[dataIdx].ItemRank[index];
      bool flag1 = this.GM.IsLeadItem(this.DM.EquipTable.GetRecordByKey(num1).EquipKind);
      bool flag2 = MallManager.Instance.CheckCanOpenDetail(num1);
      this.m_PanelObject[panelObjectIdx].m_DetailBtn[index].targetGraphic = (Graphic) this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[index].HIImage;
      if (dataIdx >= (int) this.DM.RoleAlliance.AMMaxDegree)
      {
        ((Component) this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[index]).gameObject.SetActive(false);
        ((Component) this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[index]).gameObject.SetActive(false);
        ((Component) this.m_PanelObject[panelObjectIdx].m_DetailBtn[index]).gameObject.SetActive(false);
        ((Component) this.m_PanelObject[panelObjectIdx].m_LockImage[index]).gameObject.SetActive(true);
      }
      else
      {
        if (flag1)
        {
          this.GM.ChangeLordEquipImg(((Component) this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[index]).transform, num1, num2, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
          ((Component) this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[index]).gameObject.SetActive(true);
          ((Component) this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[index]).gameObject.SetActive(false);
          ((Component) this.m_PanelObject[panelObjectIdx].m_DetailBtn[index]).gameObject.SetActive(false);
        }
        else
        {
          if (flag2)
          {
            this.m_PanelObject[panelObjectIdx].m_DetailBtn[index].m_BtnID4 = 300;
            this.m_PanelObject[panelObjectIdx].m_DetailBtn[index].m_BtnID2 = (int) num1;
            ((Component) this.m_PanelObject[panelObjectIdx].m_DetailBtn[index]).gameObject.SetActive(true);
          }
          else
          {
            this.m_PanelObject[panelObjectIdx].m_DetailBtn[index].m_BtnID4 = 301;
            this.m_PanelObject[panelObjectIdx].m_DetailBtn[index].m_BtnID2 = 0;
            ((Component) this.m_PanelObject[panelObjectIdx].m_DetailBtn[index]).gameObject.SetActive(false);
          }
          this.GM.ChangeHeroItemImg(((Component) this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[index]).transform, eHeroOrItem.Item, num1, num2, (byte) 0);
          ((Component) this.m_PanelObject[panelObjectIdx].m_ItemHIBtn[index]).gameObject.SetActive(true);
          ((Component) this.m_PanelObject[panelObjectIdx].m_ItemLEBtn[index]).gameObject.SetActive(false);
        }
        ((Component) this.m_PanelObject[panelObjectIdx].m_LockImage[index]).gameObject.SetActive(false);
      }
    }
  }

  private void SetItemSelect(int dataIdx, int panelObjectIdx)
  {
    for (int index = 0; index < 3; ++index)
      ((Behaviour) this.m_PanelObject[panelObjectIdx].m_ItemSelectImage[index]).enabled = false;
    int selectIndex = (int) this.m_Data[dataIdx].SelectIndex;
    if (selectIndex <= 0 || selectIndex > 3)
      return;
    ((Behaviour) this.m_PanelObject[panelObjectIdx].m_ItemSelectImage[selectIndex - 1]).enabled = true;
  }

  private void SetItemMask(int dataIdx, int panelObjectIdx)
  {
    if (this.m_Data[dataIdx].SelectIndex == (byte) 4 || dataIdx >= (int) this.MaxDegree)
      ((Behaviour) this.m_PanelObject[panelObjectIdx].m_MaskImage).enabled = true;
    else
      ((Behaviour) this.m_PanelObject[panelObjectIdx].m_MaskImage).enabled = false;
  }

  private void SetBtnHint(int dataIdx, int panelObjectIdx)
  {
    for (int index = 0; index < 3; ++index)
    {
      if (dataIdx >= 0 && dataIdx < this.m_Data.Length)
      {
        this.m_PanelObject[panelObjectIdx].m_BtnHint[index].Parm1 = this.m_Data[dataIdx].ItemID[index];
        this.m_PanelObject[panelObjectIdx].m_BtnHint[index].Parm2 = this.m_Data[dataIdx].ItemRank[index];
        this.m_PanelObject[panelObjectIdx].m_BtnHint_LE[index].Parm1 = this.m_Data[dataIdx].ItemID[index];
        this.m_PanelObject[panelObjectIdx].m_BtnHint_LE[index].Parm2 = this.m_Data[dataIdx].ItemRank[index];
      }
    }
  }

  private void SetSpecialPrizeImg(int dataIdx, int panelObjectIdx)
  {
    ((Component) this.m_PanelObject[panelObjectIdx].m_SpecialPrize).gameObject.SetActive(this.IsSpecialPrize());
  }

  private void SetItemBackground(int dataIdx, int panelObjectIdx)
  {
    int rankImageIdx = this.GetRankImageIdx(dataIdx);
    if (rankImageIdx > 0)
    {
      this.m_PanelObject[panelObjectIdx].m_Background.sprite = this.m_SpArray.GetSprite(rankImageIdx + 2);
      ((Component) this.m_PanelObject[panelObjectIdx].m_Background).gameObject.SetActive(true);
    }
    else
      ((Component) this.m_PanelObject[panelObjectIdx].m_Background).gameObject.SetActive(false);
    for (int index = 0; index < 3; ++index)
      this.m_PanelObject[panelObjectIdx].m_ItemBackground[index].sprite = this.m_SpArray.GetSprite(rankImageIdx + 7);
  }

  private int GetRankImageIdx(int dataIdx)
  {
    for (int rankImageIdx = 0; rankImageIdx < this.MD.DegreeRanges.Length - 1; ++rankImageIdx)
    {
      if (dataIdx >= (int) this.MD.DegreeRanges[rankImageIdx] && dataIdx < (int) this.MD.DegreeRanges[rankImageIdx + 1])
        return rankImageIdx;
    }
    return 0;
  }

  private void UpdateSendBtnType(UIRewardsSelect.eRewardsSelectType type)
  {
    switch (type)
    {
      case UIRewardsSelect.eRewardsSelectType.Preview:
        ((Component) this.m_OverText).gameObject.SetActive(true);
        ((Component) this.m_Send).gameObject.SetActive(false);
        ((Component) this.m_FlashImage).gameObject.SetActive(false);
        break;
      case UIRewardsSelect.eRewardsSelectType.Selection:
        this.m_Send.image.sprite = this.m_SpArray.GetSprite(1);
        this.m_Send.ForTextChange(e_BtnType.e_ChangeText);
        ((Component) this.m_Send).gameObject.SetActive(true);
        ((Component) this.m_OverText).gameObject.SetActive(false);
        ((Component) this.m_FlashImage).gameObject.SetActive(false);
        break;
      case UIRewardsSelect.eRewardsSelectType.Decide:
        this.m_Send.image.sprite = this.m_SpArray.GetSprite(0);
        this.m_Send.ForTextChange(e_BtnType.e_Normal);
        ((Component) this.m_Send).gameObject.SetActive(true);
        ((Component) this.m_OverText).gameObject.SetActive(false);
        ((Component) this.m_FlashImage).gameObject.SetActive(true);
        break;
    }
  }

  private void SetType(UIRewardsSelect.eRewardsSelectType type)
  {
    this.m_Type = type;
    this.UpdateSendBtnType(this.m_Type);
  }

  private void CheckType()
  {
    this.SelectCount = 0;
    for (int index = 0; index < this.m_Data.Length; ++index)
    {
      if (this.m_Data[index].SelectIndex != (byte) 0 && this.m_Data[index].SelectIndex != (byte) 4)
        ++this.SelectCount;
    }
    if (this.bReadOnly)
    {
      this.SetType(UIRewardsSelect.eRewardsSelectType.Preview);
      ((Component) this.m_TimeIcon).gameObject.SetActive(false);
      ((Component) this.m_TimeText).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.m_TimeIcon).gameObject.SetActive(true);
      ((Component) this.m_TimeText).gameObject.SetActive(true);
      if (this.SelectCount >= (int) this.MD.AMCompleteDegree)
        this.SetType(UIRewardsSelect.eRewardsSelectType.Decide);
      else
        this.SetType(UIRewardsSelect.eRewardsSelectType.Selection);
    }
  }

  private bool IsSpecialPrize() => this.MD != null && this.MD.SpecialPrize > (byte) 1;

  private void UpdateTimer()
  {
    if (this.bReadOnly)
      return;
    this.m_TimeTick += Time.deltaTime;
    if ((double) this.m_TimeTick < 1.0)
      return;
    this.m_TimeSrt.ClearString();
    GameConstants.GetTimeString(this.m_TimeSrt, (uint) this.AC.AllyMobilizationData.EventCountTime);
    this.m_TimeText.text = this.m_TimeSrt.ToString();
    this.m_TimeText.SetAllDirty();
    this.m_TimeText.cachedTextGenerator.Invalidate();
    this.m_TimeTick = 0.0f;
  }

  public float ATween(float t, float b, float c, float d)
  {
    float num1 = (t /= d) * t;
    float num2 = num1 * t;
    return b + c * (num2 * num1);
  }

  private void FlashImageAlpha()
  {
    if (this.m_Type == UIRewardsSelect.eRewardsSelectType.Decide)
    {
      this.ColorTime += Time.deltaTime;
      if ((double) this.ColorTime >= (double) this.FlashTime)
        this.ColorTime = 0.0f;
      if (!((Object) this.m_FlashImage != (Object) null))
        return;
      if ((double) this.ColorTime > 1.0)
        ((Graphic) this.m_FlashImage).color = new Color(1f, 1f, 1f, 2f - this.ColorTime);
      else
        ((Graphic) this.m_FlashImage).color = new Color(1f, 1f, 1f, this.ColorTime);
    }
    else
    {
      if (this.m_Type != UIRewardsSelect.eRewardsSelectType.Selection || (double) ((Graphic) this.m_FlashImage).color.a >= 1.0)
        return;
      ((Graphic) this.m_FlashImage).color = new Color(1f, 1f, 1f, 1f);
    }
  }

  private void SetFakeData()
  {
    if (this.bFirstInit)
      return;
    for (int index = 0; index < this.m_Data.Length; ++index)
      this.m_Data[index].SelectIndex = (byte) 4;
    this.m_Data[0].SelectIndex = (byte) 0;
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < 35 && index < (int) this.MaxDegree; ++index)
      _DataHeight.Add(111f);
    this.m_ScrollPanel.AddNewDataHeight(_DataHeight, false, false);
  }

  private bool CheckFirstClick()
  {
    bool flag = !this.MD.bRewardsSelectFirstClickItem && this.m_Type == UIRewardsSelect.eRewardsSelectType.Selection && this.MD.AMCompleteDegree >= (byte) 1;
    if (flag)
    {
      this.SetFakeData();
      this.m_FingerImageObject.SetActive(true);
    }
    else
    {
      this.m_FingerImageObject.SetActive(false);
      if (this.MD.bFirstRequestActivityAmDegeePrize)
        this.UpdateUI(3, 0);
    }
    return flag;
  }

  private bool CheckFingerRange()
  {
    bool flag = false;
    if ((Object) this.m_ScrollContentRT != (Object) null)
      flag = (double) this.m_ScrollContentRT.anchoredPosition.y <= 40.0 && (double) this.m_ScrollContentRT.anchoredPosition.y > -30.0;
    return flag;
  }

  private byte GetDegree()
  {
    byte Index = (byte) ((uint) this.DM.RoleAlliance.AMRank + 1U);
    return Index > (byte) 3 ? this.DM.AllianceMobilizationDegreeRange.GetRecordByIndex(3).Range : this.DM.AllianceMobilizationDegreeRange.GetRecordByIndex((int) Index).Range;
  }

  private void Refresh_FontTexture()
  {
    if (!this.bFirstInit && this.m_PanelObject != null)
    {
      for (int index1 = 0; index1 < this.m_PanelObject.Length; ++index1)
      {
        if ((Object) this.m_PanelObject[index1].m_NumText != (Object) null && ((Behaviour) this.m_PanelObject[index1].m_NumText).enabled)
        {
          ((Behaviour) this.m_PanelObject[index1].m_NumText).enabled = false;
          ((Behaviour) this.m_PanelObject[index1].m_NumText).enabled = true;
        }
        for (int index2 = 0; index2 < 3; ++index2)
        {
          if (this.m_PanelObject[index1].m_ItemNumText != null && (Object) this.m_PanelObject[index1].m_ItemNumText[index2] != (Object) null && ((Behaviour) this.m_PanelObject[index1].m_ItemNumText[index2]).enabled)
          {
            ((Behaviour) this.m_PanelObject[index1].m_ItemNumText[index2]).enabled = false;
            ((Behaviour) this.m_PanelObject[index1].m_ItemNumText[index2]).enabled = true;
          }
          if ((Object) this.m_PanelObject[index1].m_ItemHIBtn[index2] != (Object) null)
            this.m_PanelObject[index1].m_ItemHIBtn[index2].Refresh_FontTexture();
          if ((Object) this.m_PanelObject[index1].m_ItemLEBtn[index2] != (Object) null)
            LordEquipData.ResetLordEquipFont(this.m_PanelObject[index1].m_ItemLEBtn[index2]);
        }
      }
    }
    if ((Object) this.m_TimeText != (Object) null && ((Behaviour) this.m_TimeText).enabled)
    {
      ((Behaviour) this.m_TimeText).enabled = false;
      ((Behaviour) this.m_TimeText).enabled = true;
    }
    if ((Object) this.m_OverText != (Object) null && ((Behaviour) this.m_OverText).enabled)
    {
      ((Behaviour) this.m_OverText).enabled = false;
      ((Behaviour) this.m_OverText).enabled = true;
    }
    if ((Object) this.m_TitleText1 != (Object) null && ((Behaviour) this.m_TitleText1).enabled)
    {
      ((Behaviour) this.m_TitleText1).enabled = false;
      ((Behaviour) this.m_TitleText1).enabled = true;
    }
    if (!((Object) this.m_TitleText2 != (Object) null) || !((Behaviour) this.m_TitleText2).enabled)
      return;
    ((Behaviour) this.m_TitleText2).enabled = false;
    ((Behaviour) this.m_TitleText2).enabled = true;
  }

  private struct panelObject
  {
    public Image m_Background;
    public UIText m_NumText;
    public UIText[] m_ItemNumText;
    public UIHIBtn[] m_ItemHIBtn;
    public UILEBtn[] m_ItemLEBtn;
    public UIButtonHint[] m_BtnHint;
    public UIButtonHint[] m_BtnHint_LE;
    public UIButton[] m_DetailBtn;
    public Image[] m_ItemBackground;
    public Image[] m_ItemSelectImage;
    public Image m_MaskImage;
    public Image m_SpecialPrize;
    public Image[] m_LockImage;
    public UIButton[] m_Btn;
    public CString m_NumTextStr;
    public CString[] m_ItemNumTextStr;

    public void Init()
    {
      this.m_Background = (Image) null;
      this.m_NumText = (UIText) null;
      this.m_ItemNumText = new UIText[3];
      this.m_ItemHIBtn = new UIHIBtn[3];
      this.m_ItemLEBtn = new UILEBtn[3];
      this.m_BtnHint = new UIButtonHint[3];
      this.m_BtnHint_LE = new UIButtonHint[3];
      this.m_DetailBtn = new UIButton[3];
      this.m_ItemBackground = new Image[3];
      this.m_ItemSelectImage = new Image[3];
      this.m_MaskImage = (Image) null;
      this.m_SpecialPrize = (Image) null;
      this.m_LockImage = new Image[3];
      this.m_Btn = new UIButton[3];
      this.m_NumTextStr = StringManager.Instance.SpawnString();
      this.m_ItemNumTextStr = new CString[3];
      for (int index = 0; index < 3; ++index)
        this.m_ItemNumTextStr[index] = StringManager.Instance.SpawnString();
    }
  }

  private struct sRewardsSelect
  {
    public int Num;
    public byte SelectIndex;
    public ushort[] ItemID;
    public byte[] ItemRank;
    public byte[] ItemNum;

    public void Init()
    {
      this.Num = 0;
      this.SelectIndex = (byte) 0;
      this.ItemID = new ushort[3];
      this.ItemNum = new byte[3];
      this.ItemRank = new byte[3];
    }
  }

  private enum eRewardsSelect
  {
    BGPanel,
    ScrollView,
    Item,
    Send,
    Exit,
    FingerImage,
  }

  private enum eRewardsSelectType
  {
    Preview,
    Selection,
    Decide,
  }

  private enum eSpriteArry
  {
    ButtonDark,
    ButtonLight,
    ImageBox,
    BackgroundRank1,
    BackgroundRank2,
    BackgroundRank3,
    BackgroundRank4,
    ItemBackgroundRank0,
    ItemBackgroundRank1,
    ItemBackgroundRank2,
    ItemBackgroundRank3,
    ItemBackgroundRank4,
  }
}
