// Decompiled with JetBrains decompiler
// Type: UISearchList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable disable
public class UISearchList : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int MaxScrollCount = 7;
  private DataManager DM;
  private GUIManager GM;
  private Font TTF;
  private Door m_door;
  private SearchItemObj[] m_SearchItem;
  private UIEmojiInput m_InputField;
  private UIText m_SearchText;
  private ScrollPanel m_ScrollPanel;
  private Transform m_SearchPanel;
  private CScrollRect cScrollRect;
  private UIText Title;
  private UIText btn_Text;
  private UIText[] m_InputText = new UIText[2];
  private UIText[] m_TextStr = new UIText[2];
  private UIText[] m_ItemBtnStr = new UIText[7];
  private Transform Alliance;
  private UIEmojiInput s_input;
  private ScrollPanel m_scroll;
  private ScrollPanelItem[] m_panel;
  private UIText m_search;
  private UIText m_filter;
  private UIText[][] ItemTag = new UIText[7][];
  private UIText[] m_text = new UIText[9];
  private Transform Transformer;
  private RectTransform SearchRT;
  private StringBuilder Path = new StringBuilder();
  private List<float> ItemsHeight = new List<float>();
  private RectTransform m_ScrollContentRT;
  private Transform m_EmptyMsgPanel;
  private UIText m_EmptyMsgText;
  private UISpritesArray m_SPArray;
  private Image m_TabBg1;
  private Image m_TabBg2;
  private Image m_TabIcon1;
  private Image m_TabIcon2;
  private Transform m_TweenA1;
  private Transform m_TweenA2;
  private UIButton m_CancelInput;
  private eTabPanel m_TabType;
  private CString m_SearchTextStr;
  private CString m_SearchTitleStr;
  private CString m_EmptyMsgTextStr;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.TTF = this.GM.GetTTFFont();
    this.m_door = this.GM.FindMenu(EGUIWindow.Door) as Door;
    this.m_SearchItem = new SearchItemObj[7];
    this.m_TabType = (eTabPanel) this.DM.mLastSearchPage;
    this.m_SearchTextStr = StringManager.Instance.SpawnString();
    this.m_SearchTitleStr = StringManager.Instance.SpawnString(100);
    this.m_EmptyMsgTextStr = StringManager.Instance.SpawnString(100);
    this.m_SPArray = this.transform.GetComponent<UISpritesArray>();
    this.Title = this.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<UIText>();
    this.Title.font = this.TTF;
    Image component1 = this.transform.GetChild(7).GetComponent<Image>();
    component1.sprite = this.m_door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component1).material = this.m_door.LoadMaterial();
    if (this.GM.bOpenOnIPhoneX && (bool) (Object) component1)
      ((Behaviour) component1).enabled = false;
    UIButton component2 = this.transform.GetChild(7).GetChild(0).GetComponent<UIButton>();
    component2.image.sprite = this.m_door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component2.image).material = this.m_door.LoadMaterial();
    component2.m_BtnID1 = 999;
    component2.m_Handler = (IUIButtonClickHandler) this;
    this.m_InputField = this.transform.GetChild(1).GetChild(0).GetComponent<UIEmojiInput>();
    // ISSUE: method pointer
    this.m_InputField.onValueChange.AddListener(new UnityAction<string>((object) this, __methodptr(\u003COnOpen\u003Em__F4)));
    this.m_InputField.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
    this.m_InputText[0] = this.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.m_InputText[0].font = this.TTF;
    this.m_InputText[0].text = this.DM.mStringTable.GetStringByID(4718U);
    this.m_InputText[1] = this.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
    this.m_InputText[1].font = this.TTF;
    this.m_SearchPanel = this.transform.GetChild(1);
    this.m_TextStr[0] = this.transform.GetChild(1).GetChild(3).GetComponent<UIText>();
    this.m_TextStr[0].font = this.TTF;
    this.m_SearchTitleStr.StringToFormat(this.DM.mStringTable.GetStringByID(4717U));
    this.m_SearchTitleStr.AppendFormat("{0}");
    this.m_TextStr[0].text = this.m_SearchTitleStr.ToString();
    this.m_TextStr[1] = this.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
    this.m_TextStr[1].font = this.TTF;
    this.m_TextStr[1].text = this.DM.mStringTable.GetStringByID(7056U);
    this.m_SearchText = this.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
    this.m_SearchText.font = this.TTF;
    UIButton component3 = this.transform.GetChild(1).GetChild(1).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 998;
    this.m_CancelInput = this.transform.GetChild(1).GetChild(2).GetComponent<UIButton>();
    this.m_CancelInput.m_Handler = (IUIButtonClickHandler) this;
    this.m_CancelInput.m_BtnID1 = 997;
    this.m_EmptyMsgPanel = this.transform.GetChild(6);
    this.m_EmptyMsgText = this.m_EmptyMsgPanel.GetChild(1).GetComponent<UIText>();
    this.m_EmptyMsgText.font = this.TTF;
    this.SetEmptyMsgPanel(eMsgPanel.PlzInputName);
    this.GM.InitianHeroItemImg(((Component) this.transform.GetChild(3).GetChild(2).GetComponent<UIHIBtn>()).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.btn_Text = this.transform.GetChild(3).GetChild(8).GetChild(0).GetComponent<UIText>();
    this.btn_Text.font = this.TTF;
    this.btn_Text.text = this.DM.mStringTable.GetStringByID(4634U);
    UIButton component4 = this.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_BtnID1 = 996;
    this.m_TabBg1 = this.transform.GetChild(4).GetChild(0).GetComponent<Image>();
    this.m_TabIcon1 = this.transform.GetChild(4).GetChild(0).GetChild(1).GetComponent<Image>();
    this.m_TweenA1 = this.transform.GetChild(4).GetChild(0).GetChild(0);
    UIButton component5 = this.transform.GetChild(4).GetChild(1).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_BtnID1 = 995;
    this.m_TabBg2 = this.transform.GetChild(4).GetChild(1).GetComponent<Image>();
    this.m_TabIcon2 = this.transform.GetChild(4).GetChild(1).GetChild(1).GetComponent<Image>();
    this.m_TweenA2 = this.transform.GetChild(4).GetChild(1).GetChild(0);
    this.m_ScrollPanel = this.transform.GetChild(2).GetComponent<ScrollPanel>();
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < (int) this.DM.m_RecvSearchPlayerCount; ++index)
      _DataHeight.Add(72f);
    this.m_ScrollPanel.IntiScrollPanel(417f, 0.0f, 0.0f, _DataHeight, 7, (IUpDateScrollPanel) this);
    this.m_ScrollContentRT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
    this.cScrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
    if (!this.DM.bClaerSearchData)
    {
      if (this.DM.m_RecvSearchPlayerCount > (byte) 0)
      {
        this.m_ScrollPanel.GoTo(this.DM.m_SearchListScrollIndex, this.DM.m_SearchListScrollPos);
        this.m_InputField.text = string.Empty;
        this.m_InputField.text = this.DM.m_PreSearchName;
        this.SetSearchText(true);
      }
      else
        this.SetSearchText(false);
    }
    this.SetAlliancePanel();
    this.SetTabPanel(this.m_TabType);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.m_SearchTextStr);
    StringManager.Instance.DeSpawnString(this.m_SearchTitleStr);
    StringManager.Instance.DeSpawnString(this.m_EmptyMsgTextStr);
    for (int index = 0; index < 7; ++index)
    {
      if (this.m_SearchItem[index].NameStr != null)
        StringManager.Instance.DeSpawnString(this.m_SearchItem[index].NameStr);
      if (this.m_SearchItem[index].PowerStr != null)
        StringManager.Instance.DeSpawnString(this.m_SearchItem[index].PowerStr);
      if (this.m_SearchItem[index].KillStr != null)
        StringManager.Instance.DeSpawnString(this.m_SearchItem[index].KillStr);
    }
    this.DM.mLastSearchPage = this.DM.mLastSearchPage <= (byte) 1 ? (byte) 0 : (byte) 1;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg2 >= 100)
      return;
    this.AllianceUpdate(arg1, arg2);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        this.UpdateScroll();
        break;
      default:
        if (networkNews != NetworkNews.Refresh_SearchList)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.Refresh_FontTexture();
          break;
        }
        if (this.DM.bSearchError)
          break;
        if (this.DM.m_RecvSearchPlayerCount <= (byte) 0)
        {
          this.SetEmptyMsgPanel(eMsgPanel.SearchError);
          this.UpdateScroll();
          break;
        }
        this.SetEmptyMsgPanel(eMsgPanel.None);
        this.UpdateScroll();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.Title != (Object) null && ((Behaviour) this.Title).enabled)
    {
      ((Behaviour) this.Title).enabled = false;
      ((Behaviour) this.Title).enabled = true;
    }
    if ((Object) this.m_SearchText != (Object) null && ((Behaviour) this.m_SearchText).enabled)
    {
      ((Behaviour) this.m_SearchText).enabled = false;
      ((Behaviour) this.m_SearchText).enabled = true;
    }
    if ((Object) this.m_EmptyMsgText != (Object) null && ((Behaviour) this.m_EmptyMsgText).enabled)
    {
      ((Behaviour) this.m_EmptyMsgText).enabled = false;
      ((Behaviour) this.m_EmptyMsgText).enabled = true;
    }
    if ((Object) this.btn_Text != (Object) null && ((Behaviour) this.btn_Text).enabled)
    {
      ((Behaviour) this.btn_Text).enabled = false;
      ((Behaviour) this.btn_Text).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.m_InputText[index] != (Object) null && ((Behaviour) this.m_InputText[index]).enabled)
      {
        ((Behaviour) this.m_InputText[index]).enabled = false;
        ((Behaviour) this.m_InputText[index]).enabled = true;
      }
      if ((Object) this.m_TextStr[index] != (Object) null && ((Behaviour) this.m_TextStr[index]).enabled)
      {
        ((Behaviour) this.m_TextStr[index]).enabled = false;
        ((Behaviour) this.m_TextStr[index]).enabled = true;
      }
    }
    for (int index1 = 0; index1 < 7; ++index1)
    {
      if (this.m_ItemBtnStr != null && (Object) this.m_ItemBtnStr[index1] != (Object) null && ((Behaviour) this.m_ItemBtnStr[index1]).enabled)
      {
        ((Behaviour) this.m_ItemBtnStr[index1]).enabled = false;
        ((Behaviour) this.m_ItemBtnStr[index1]).enabled = true;
      }
      if (this.ItemTag != null)
      {
        for (int index2 = 0; index2 < 5; ++index2)
        {
          if ((Object) this.ItemTag[index1][index2] != (Object) null && ((Behaviour) this.ItemTag[index1][index2]).enabled)
          {
            ((Behaviour) this.ItemTag[index1][index2]).enabled = false;
            ((Behaviour) this.ItemTag[index1][index2]).enabled = true;
          }
        }
      }
    }
    if (this.m_SearchItem != null)
    {
      for (int index = 0; index < 7; ++index)
      {
        if ((Object) this.m_SearchItem[index].NameText != (Object) null && ((Behaviour) this.m_SearchItem[index].NameText).enabled)
        {
          ((Behaviour) this.m_SearchItem[index].NameText).enabled = false;
          ((Behaviour) this.m_SearchItem[index].NameText).enabled = true;
        }
        if ((Object) this.m_SearchItem[index].PowerText != (Object) null && ((Behaviour) this.m_SearchItem[index].PowerText).enabled)
        {
          ((Behaviour) this.m_SearchItem[index].PowerText).enabled = false;
          ((Behaviour) this.m_SearchItem[index].PowerText).enabled = true;
        }
        if ((Object) this.m_SearchItem[index].KillText != (Object) null && ((Behaviour) this.m_SearchItem[index].KillText).enabled)
        {
          ((Behaviour) this.m_SearchItem[index].KillText).enabled = false;
          ((Behaviour) this.m_SearchItem[index].KillText).enabled = true;
        }
        if ((Object) this.m_SearchItem[index].Hibtn != (Object) null && ((Behaviour) this.m_SearchItem[index].Hibtn).enabled)
          this.m_SearchItem[index].Hibtn.Refresh_FontTexture();
      }
    }
    for (int index = 0; index < 9; ++index)
    {
      if ((Object) this.m_text[index] != (Object) null && ((Behaviour) this.m_text[index]).enabled)
      {
        ((Behaviour) this.m_text[index]).enabled = false;
        ((Behaviour) this.m_text[index]).enabled = true;
      }
    }
    if ((Object) this.s_input != (Object) null)
    {
      if ((Object) this.s_input.textComponent != (Object) null && ((Behaviour) this.s_input.textComponent).enabled)
      {
        ((Behaviour) this.s_input.textComponent).enabled = false;
        ((Behaviour) this.s_input.textComponent).enabled = true;
      }
      if ((Object) this.s_input.placeholder != (Object) null && ((Behaviour) this.s_input.placeholder).enabled)
      {
        ((Behaviour) this.s_input.placeholder).enabled = false;
        ((Behaviour) this.s_input.placeholder).enabled = true;
      }
    }
    if (!((Object) this.m_InputField != (Object) null))
      return;
    if ((Object) this.m_InputField.textComponent != (Object) null && ((Behaviour) this.m_InputField.textComponent).enabled)
    {
      ((Behaviour) this.m_InputField.textComponent).enabled = false;
      ((Behaviour) this.m_InputField.textComponent).enabled = true;
    }
    if (!((Object) this.m_InputField.placeholder != (Object) null) || !((Behaviour) this.m_InputField.placeholder).enabled)
      return;
    ((Behaviour) this.m_InputField.placeholder).enabled = false;
    ((Behaviour) this.m_InputField.placeholder).enabled = true;
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID2 > 0)
    {
      if (sender.m_BtnID2 == 2)
      {
        this.DM.mLastSearchPage = (byte) 30;
        AllianceHint.Positioning = this.m_scroll.GetTopIdx();
        AllianceHint.Scrolling = this.SearchRT.anchoredPosition.y;
        this.DM.AllianceView.Id = AllianceHint.Search[sender.m_BtnID1].ID;
        this.m_door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5);
        this.DM.mAllianceSearchView = true;
      }
      else if (sender.m_BtnID1 == 31)
      {
        if (AllianceHint.FilterIdx == (byte) 0 && AllianceHint.FilterName.Length == 0)
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(4711U), (ushort) byte.MaxValue);
        else if (AllianceHint.FilterName.Length > 0 && AllianceHint.FilterName.Length < 3)
        {
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(4710U), (ushort) byte.MaxValue);
        }
        else
        {
          AllianceHint.Proceeding = 1L;
          GUIManager.Instance.ShowUILock(EUILock.AllianceCreate);
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_SEARCH;
          messagePacket.AddSeqId();
          messagePacket.Add(AllianceHint.FilterIdx);
          if (AllianceHint.FilterName.Length > 0)
          {
            messagePacket.Add((byte) AllianceHint.FilterName.Length);
            messagePacket.Add(AllianceHint.FilterName, AllianceHint.FilterName.Length);
          }
          messagePacket.Send();
          this.Path.Length = 0;
          this.m_filter.text = AllianceHint.SearchLang = AllianceHint.FilterIdx <= (byte) 0 ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703U), (object) this.Alliance.GetChild(3).GetChild(17).GetChild(0).GetComponent<UIText>().text).ToString();
          this.Path.Length = 0;
          this.m_text[8].text = AllianceHint.SearchName = AllianceHint.FilterName.Length <= 0 ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703U), (object) AllianceHint.FilterName).ToString();
          AllianceHint.SeekKind = byte.MaxValue;
        }
      }
      else if (sender.m_BtnID1 == 32)
      {
        this.DM.mLastSearchPage = (byte) 30;
        this.DM.CurSelectLanguage = AllianceHint.GenuineLang;
        this.m_door.OpenMenu(EGUIWindow.UI_LanguageSelect);
        this.DM.mAllianceSearchView = true;
      }
      else if (sender.m_BtnID1 == 33)
      {
        this.s_input.text = string.Empty;
        AllianceHint.SeekKind = (byte) 0;
        AllianceHint.SearchNum = 0;
        UIText uiText = this.m_text[8];
        string empty;
        AllianceHint.FilterName = empty = string.Empty;
        AllianceHint.SearchName = empty;
        uiText.text = empty;
        this.AllianceUpdate(4, 10);
      }
      else
      {
        if (sender.m_BtnID1 != 34)
          return;
        this.SetFilterName((byte) 0);
        AllianceHint.SeekKind = (byte) 0;
        AllianceHint.SearchNum = 0;
        AllianceHint.GenuineLang = AllianceHint.FilterIdx = this.DM.CurSelectLanguage = (byte) 0;
        this.m_filter.text = AllianceHint.SearchLang = string.Empty;
        this.AllianceUpdate(5, 10);
      }
    }
    else if (sender.m_BtnID1 == 999)
    {
      this.ClearUIInfo();
      this.ClearAlliance();
      this.m_door.CloseMenu();
    }
    else if (sender.m_BtnID1 == 998)
    {
      if (this.m_InputField.text.Length >= 3)
      {
        this.DM.SendSearchPlayer(this.m_InputField.text);
        this.SetSearchText(true);
      }
      else
        this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4710U), (ushort) byte.MaxValue);
    }
    else if (sender.m_BtnID1 == 997)
      this.SetEmptyInput();
    else if (sender.m_BtnID1 == 996)
      this.SetTabPanel(eTabPanel.Personal);
    else if (sender.m_BtnID1 == 995)
    {
      this.SetTabPanel(eTabPanel.Alliance);
    }
    else
    {
      if (sender.m_BtnID1 < 0 || sender.m_BtnID1 >= (int) this.DM.m_RecvSearchPlayerCount)
        return;
      this.SaveUIInfo();
      if (sender.m_BtnID1 >= (int) this.DM.m_RecvSearchPlayerCount || sender.m_BtnID1 < 0)
        return;
      this.DM.ShowLordProfile(this.DM.m_SearchPlayerData[sender.m_BtnID1].Name.ToString());
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelId == 0 && dataIdx < this.DM.m_SearchPlayerData.Length)
    {
      int num = dataIdx % 2;
      if ((Object) this.m_SearchItem[panelObjectIdx].Hibtn == (Object) null)
      {
        this.m_SearchItem[panelObjectIdx].Bg1 = item.transform.GetChild(0).GetComponent<Image>();
        this.m_SearchItem[panelObjectIdx].Bg2 = item.transform.GetChild(1).GetComponent<Image>();
        this.m_SearchItem[panelObjectIdx].Hibtn = item.transform.GetChild(2).GetComponent<UIHIBtn>();
        this.m_SearchItem[panelObjectIdx].NameText = item.transform.GetChild(5).GetComponent<UIText>();
        this.m_SearchItem[panelObjectIdx].NameText.font = this.TTF;
        this.m_SearchItem[panelObjectIdx].PowerText = item.transform.GetChild(6).GetComponent<UIText>();
        this.m_SearchItem[panelObjectIdx].PowerText.font = this.TTF;
        this.m_SearchItem[panelObjectIdx].KillText = item.transform.GetChild(7).GetComponent<UIText>();
        this.m_SearchItem[panelObjectIdx].KillText.font = this.TTF;
        this.m_SearchItem[panelObjectIdx].Btn = item.transform.GetChild(8).GetComponent<UIButton>();
        this.m_SearchItem[panelObjectIdx].Btn.m_Handler = (IUIButtonClickHandler) this;
        this.m_SearchItem[panelObjectIdx].NameStr = StringManager.Instance.SpawnString();
        this.m_SearchItem[panelObjectIdx].PowerStr = StringManager.Instance.SpawnString();
        this.m_SearchItem[panelObjectIdx].KillStr = StringManager.Instance.SpawnString();
        this.m_ItemBtnStr[panelObjectIdx] = item.transform.GetChild(8).GetChild(0).GetComponent<UIText>();
      }
      this.GM.ChangeHeroItemImg(((Component) this.m_SearchItem[panelObjectIdx].Hibtn).transform, eHeroOrItem.Hero, this.DM.m_SearchPlayerData[dataIdx].Head, (byte) 11, (byte) 0);
      this.m_SearchItem[panelObjectIdx].NameStr.ClearString();
      if (this.DM.m_SearchPlayerData[dataIdx].AllianceTag.Length != 0)
      {
        this.m_SearchItem[panelObjectIdx].NameStr.StringToFormat(this.DM.m_SearchPlayerData[dataIdx].AllianceTag);
        this.m_SearchItem[panelObjectIdx].NameStr.StringToFormat(this.DM.m_SearchPlayerData[dataIdx].Name);
        this.m_SearchItem[panelObjectIdx].NameStr.AppendFormat("[{0}]{1}");
      }
      else
        this.m_SearchItem[panelObjectIdx].NameStr.Append(this.DM.m_SearchPlayerData[dataIdx].Name);
      this.m_SearchItem[panelObjectIdx].NameText.text = this.m_SearchItem[panelObjectIdx].NameStr.ToString();
      this.m_SearchItem[panelObjectIdx].NameText.SetAllDirty();
      this.m_SearchItem[panelObjectIdx].NameText.cachedTextGenerator.Invalidate();
      this.m_SearchItem[panelObjectIdx].PowerStr.ClearString();
      this.m_SearchItem[panelObjectIdx].PowerStr.uLongToFormat(this.DM.m_SearchPlayerData[dataIdx].Power, bNumber: true);
      this.m_SearchItem[panelObjectIdx].PowerStr.AppendFormat("{0}");
      this.m_SearchItem[panelObjectIdx].PowerText.text = this.m_SearchItem[panelObjectIdx].PowerStr.ToString();
      this.m_SearchItem[panelObjectIdx].PowerText.SetAllDirty();
      this.m_SearchItem[panelObjectIdx].PowerText.cachedTextGenerator.Invalidate();
      this.m_SearchItem[panelObjectIdx].KillStr.ClearString();
      this.m_SearchItem[panelObjectIdx].KillStr.uLongToFormat(this.DM.m_SearchPlayerData[dataIdx].TroopKillNum, bNumber: true);
      this.m_SearchItem[panelObjectIdx].KillStr.AppendFormat("{0}");
      this.m_SearchItem[panelObjectIdx].KillText.text = this.m_SearchItem[panelObjectIdx].KillStr.ToString();
      this.m_SearchItem[panelObjectIdx].KillText.SetAllDirty();
      this.m_SearchItem[panelObjectIdx].KillText.cachedTextGenerator.Invalidate();
      this.m_SearchItem[panelObjectIdx].Btn.m_BtnID1 = dataIdx;
      if (num != 0)
        return;
      ((Behaviour) this.m_SearchItem[panelObjectIdx].Bg1).enabled = true;
      ((Behaviour) this.m_SearchItem[panelObjectIdx].Bg2).enabled = false;
    }
    else
    {
      if (panelId != 1)
        return;
      this.ItemTag[panelObjectIdx][0] = item.transform.GetChild(2).GetChild(9).GetComponent<UIText>();
      this.ItemTag[panelObjectIdx][0].font = this.TTF;
      this.ItemTag[panelObjectIdx][0].text = "[" + AllianceHint.Search[dataIdx].Tag + "]  " + AllianceHint.Search[dataIdx].Name;
      this.ItemTag[panelObjectIdx][1] = item.transform.GetChild(2).GetChild(11).GetComponent<UIText>();
      this.ItemTag[panelObjectIdx][1].font = this.TTF;
      this.Path.Length = 0;
      this.ItemTag[panelObjectIdx][1].text = AllianceHint.Search[dataIdx].Power.ToString("N0");
      this.ItemTag[panelObjectIdx][2] = item.transform.GetChild(2).GetChild(12).GetComponent<UIText>();
      this.ItemTag[panelObjectIdx][2].font = this.TTF;
      this.Path.Length = 0;
      this.ItemTag[panelObjectIdx][2].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4723U), (object) AllianceHint.Search[dataIdx].GiftLv).ToString();
      this.ItemTag[panelObjectIdx][3] = item.transform.GetChild(2).GetChild(13).GetComponent<UIText>();
      this.ItemTag[panelObjectIdx][3].font = this.TTF;
      this.Path.Length = 0;
      this.ItemTag[panelObjectIdx][3].text = this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(795U), (object) AllianceHint.Search[dataIdx].Member).ToString();
      this.ItemTag[panelObjectIdx][4] = item.transform.GetChild(2).GetChild(14).GetComponent<UIText>();
      this.ItemTag[panelObjectIdx][4].font = this.TTF;
      this.ItemTag[panelObjectIdx][4].text = DataManager.Instance.GetLanguageStr(AllianceHint.Search[dataIdx].Language);
      ushort emblem = AllianceHint.Search[dataIdx].Emblem;
      int num = (int) emblem & 7;
      int mBadge = ((int) emblem >> 3 & 7) * 8 + num + 1;
      if (mBadge > 64)
        mBadge = 64;
      int mTotem = ((int) emblem >> 6 & 63) + 1;
      if (mTotem > 64)
        mTotem = 64;
      this.GM.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(1), mBadge, mTotem);
      UIButton component = item.transform.GetChild(2).GetChild(8).GetComponent<UIButton>();
      component.m_BtnID1 = dataIdx;
      component.m_Handler = (IUIButtonClickHandler) this;
      if (!(bool) (Object) this.m_panel[panelObjectIdx])
        this.m_panel[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      item.transform.GetChild(2).gameObject.SetActive(AllianceHint.Search[dataIdx].ID > 0U);
      item.transform.GetChild(3).gameObject.SetActive(AllianceHint.Search[dataIdx].ID == 0U);
      item.transform.GetChild(0).GetChild(0).gameObject.SetActive(dataIdx % 2 == 0);
      item.transform.GetChild(0).GetChild(1).gameObject.SetActive(dataIdx % 2 == 1);
      if (AllianceHint.Proceeding != 1L || AllianceHint.Pending != 0L || AllianceHint.Search[dataIdx].ID != 0U)
        return;
      this.AllianceUpdate(22, 0);
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  private void UpdateScroll()
  {
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < (int) this.DM.m_RecvSearchPlayerCount; ++index)
      _DataHeight.Add(72f);
    this.m_ScrollPanel.AddNewDataHeight(_DataHeight);
  }

  private void ValueChange(string input)
  {
    if (input != string.Empty)
    {
      if (((Component) this.m_CancelInput).gameObject.activeSelf)
        return;
      ((Component) this.m_CancelInput).gameObject.SetActive(true);
    }
    else
    {
      if (((Component) this.m_CancelInput).gameObject.activeSelf)
        ((Component) this.m_CancelInput).gameObject.SetActive(false);
      this.SetSearchText(false);
    }
  }

  protected char OnValidateInput(string text, int index, char check)
  {
    return check >= 'A' && check <= 'Z' || check >= 'a' && check <= 'z' || check >= '0' && check <= '9' || check == ' ' ? check : char.MinValue;
  }

  private void SetEmptyInput()
  {
    this.m_InputField.text = string.Empty;
    this.SetSearchText(false);
    if (this.DM.m_RecvSearchPlayerCount == (byte) 0)
      this.SetEmptyMsgPanel(eMsgPanel.PlzInputName);
    else
      this.SetEmptyMsgPanel(eMsgPanel.None);
  }

  private void SetSearchText(bool bShow)
  {
    if (bShow)
    {
      this.m_SearchTextStr.ClearString();
      this.m_SearchTextStr.StringToFormat(this.m_InputField.text);
      this.m_SearchTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(7051U));
      this.m_SearchText.text = this.m_SearchTextStr.ToString();
      this.m_SearchText.SetAllDirty();
      this.m_SearchText.cachedTextGenerator.Invalidate();
    }
    else
      this.m_SearchText.text = string.Empty;
  }

  private void SetEmptyMsgPanel(eMsgPanel msg)
  {
    switch (msg)
    {
      case eMsgPanel.None:
        this.m_EmptyMsgPanel.gameObject.SetActive(false);
        break;
      case eMsgPanel.PlzInputName:
        this.m_EmptyMsgText.text = this.DM.mStringTable.GetStringByID(7021U);
        this.m_EmptyMsgPanel.gameObject.SetActive(true);
        break;
      case eMsgPanel.SearchError:
        this.m_EmptyMsgTextStr.ClearString();
        this.m_EmptyMsgTextStr.StringToFormat(this.m_InputField.text);
        this.m_EmptyMsgTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(7050U));
        this.m_EmptyMsgText.text = this.m_EmptyMsgTextStr.ToString();
        this.m_EmptyMsgText.SetAllDirty();
        this.m_EmptyMsgText.cachedTextGenerator.Invalidate();
        this.m_EmptyMsgPanel.gameObject.SetActive(true);
        break;
    }
  }

  private void SetTabPanel(eTabPanel tab)
  {
    if (tab == eTabPanel.Personal)
    {
      this.Title.text = this.DM.mStringTable.GetStringByID(7057U);
      this.m_TabType = eTabPanel.Personal;
      this.m_TweenA1.gameObject.SetActive(true);
      this.m_TweenA2.gameObject.SetActive(false);
      this.m_TabIcon1.sprite = this.m_SPArray.GetSprite(2);
      this.m_TabIcon2.sprite = this.m_SPArray.GetSprite(4);
      if (this.DM.m_RecvSearchPlayerCount > (byte) 0)
        this.SetEmptyMsgPanel(eMsgPanel.None);
      else
        this.SetEmptyMsgPanel(eMsgPanel.PlzInputName);
      this.m_SearchPanel.gameObject.SetActive(true);
      this.m_ScrollPanel.gameObject.SetActive(true);
      this.Alliance.gameObject.SetActive(false);
      if ((Object) this.cScrollRect != (Object) null)
        this.cScrollRect.StopMovement();
    }
    else
    {
      this.Title.text = this.DM.mStringTable.GetStringByID(7058U);
      this.m_TabType = eTabPanel.Alliance;
      this.m_TweenA1.gameObject.SetActive(false);
      this.m_TweenA2.gameObject.SetActive(true);
      this.m_TabIcon1.sprite = this.m_SPArray.GetSprite(2);
      this.m_TabIcon2.sprite = this.m_SPArray.GetSprite(4);
      this.m_EmptyMsgPanel.gameObject.SetActive(false);
      this.m_SearchPanel.gameObject.SetActive(false);
      this.m_ScrollPanel.gameObject.SetActive(false);
      this.Alliance.gameObject.SetActive(true);
      this.m_scroll.gameObject.SetActive(true);
      if (this.DM.mAllianceSearchView)
      {
        this.AllianceUpdate(3, 10);
        this.DM.mAllianceSearchView = false;
        this.m_scroll.GoTo(AllianceHint.Positioning, AllianceHint.Scrolling);
      }
      if (AllianceHint.SearchNum > 0)
        this.SetEmptyMsgAlly(eMsgPanel.None);
      else
        this.SetEmptyMsgAlly(eMsgPanel.PlzInputName);
    }
    this.DM.mLastSearchPage = (byte) tab;
  }

  private void SaveUIInfo()
  {
    this.DM.m_SearchListScrollIndex = this.m_ScrollPanel.GetTopIdx();
    this.DM.m_SearchListScrollPos = this.m_ScrollContentRT.anchoredPosition.y;
    this.DM.m_PreSearchName = this.m_InputField.text;
    this.DM.bClaerSearchData = false;
  }

  private void ClearUIInfo()
  {
    this.DM.m_SearchListScrollIndex = 0;
    this.DM.m_SearchListScrollPos = 0.0f;
    this.DM.m_RecvSearchPlayerCount = (byte) 0;
    this.DM.m_PreSearchName = string.Empty;
    this.DM.bClaerSearchData = false;
  }

  private void SetAlliancePanel()
  {
    for (int index = 0; index < 7; ++index)
      this.ItemTag[index] = new UIText[5];
    this.Alliance = this.transform.GetChild(5).GetChild(0);
    this.Alliance.GetChild(3).GetChild(16).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.Alliance.GetChild(3).GetChild(20).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.Alliance.GetChild(3).GetChild(21).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.Alliance.GetChild(3).GetChild(17).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.Alliance.GetChild(3).GetChild(17).GetChild(0).GetComponent<UIText>().font = this.TTF;
    this.m_text[0] = this.Alliance.GetChild(3).GetChild(17).GetChild(0).GetComponent<UIText>();
    this.Alliance.GetChild(3).GetChild(17).GetChild(1).GetComponent<UnityEngine.UI.Text>().font = this.TTF;
    this.m_text[1] = this.Alliance.GetChild(3).GetChild(4).GetChild(0).GetComponent<UIText>();
    this.m_text[1].font = this.TTF;
    this.m_text[1].text = this.DM.mStringTable.GetStringByID(4702U);
    this.m_text[2] = this.Alliance.GetChild(3).GetChild(4).GetChild(1).GetComponent<UIText>();
    this.m_text[2].font = this.TTF;
    this.m_text[3] = this.Alliance.GetChild(3).GetChild(5).GetChild(0).GetComponent<UIText>();
    this.m_text[3].font = this.TTF;
    this.m_text[3].text = this.DM.mStringTable.GetStringByID(4704U);
    this.m_text[4] = this.Alliance.GetChild(3).GetChild(15).GetChild(0).GetComponent<UIText>();
    this.m_text[4].font = this.TTF;
    this.m_text[5] = this.Alliance.GetChild(3).GetChild(15).GetChild(1).GetComponent<UIText>();
    this.m_text[5].font = this.TTF;
    this.m_text[5].text = this.DM.mStringTable.GetStringByID(793U);
    this.m_text[6] = this.Alliance.GetChild(3).GetChild(17).GetChild(1).GetComponent<UIText>();
    this.m_text[6].font = this.TTF;
    this.m_text[6].text = this.DM.mStringTable.GetStringByID(794U);
    this.m_text[7] = this.Alliance.GetChild(5).GetChild(2).GetChild(8).GetChild(0).GetComponent<UIText>();
    this.m_text[7].text = this.DM.mStringTable.GetStringByID(4634U);
    this.m_text[7].font = this.TTF;
    this.m_text[8] = this.Alliance.GetChild(3).GetChild(4).GetChild(2).GetComponent<UIText>();
    this.m_text[8].font = this.TTF;
    this.m_filter = this.Alliance.GetChild(3).GetChild(5).GetChild(1).GetComponent<UIText>();
    this.m_filter.font = this.TTF;
    this.s_input = this.Alliance.GetChild(3).GetChild(15).GetComponent<UIEmojiInput>();
    // ISSUE: method pointer
    this.s_input.onValueChange.AddListener(new UnityAction<string>((object) this, __methodptr(\u003CSetAlliancePanel\u003Em__F5)));
    this.s_input.characterLimit = 20;
    AllianceHint.GenuineLang = this.DM.GetUserLanguageID();
    this.m_panel = new ScrollPanelItem[7];
    if (AllianceHint.Search == null)
      AllianceHint.Search = new AllianceSearch[101];
    this.GM.InitBadgeTotem(this.Alliance.GetChild(5).GetChild(2).GetChild(1), (ushort) 0);
    this.m_scroll = this.Alliance.GetChild(4).GetComponent<ScrollPanel>();
    this.m_scroll.IntiScrollPanel(420f, 3f, 4f, this.ItemsHeight, 7, (IUpDateScrollPanel) this);
    this.m_scroll.AddNewDataHeight(this.ItemsHeight);
    this.SearchRT = this.m_scroll.transform.GetChild(0).GetComponent<RectTransform>();
    if (!this.DM.mAllianceSearchView)
    {
      AllianceHint.SeekKind = (byte) 0;
      AllianceHint.SearchNum = 0;
      AllianceHint.GenuineLang = AllianceHint.FilterIdx = this.DM.CurSelectLanguage = (byte) 0;
      string empty;
      AllianceHint.FilterName = empty = string.Empty;
      AllianceHint.SearchName = empty;
      AllianceHint.SearchLang = empty;
    }
    else
    {
      this.m_text[8].text = AllianceHint.SearchName = AllianceHint.FilterName.Length <= 0 ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703U), (object) AllianceHint.FilterName).ToString();
      this.Path.Length = 0;
      this.SetFilterName(AllianceHint.GenuineLang = this.DM.CurSelectLanguage);
      this.m_filter.text = AllianceHint.SearchLang = AllianceHint.FilterIdx <= (byte) 0 ? string.Empty : this.Path.AppendFormat(this.DM.mStringTable.GetStringByID(4703U), (object) this.Alliance.GetChild(3).GetChild(17).GetChild(0).GetComponent<UIText>().text).ToString();
      this.s_input.text = AllianceHint.FilterName;
      this.SearchChange(AllianceHint.FilterName);
    }
  }

  private void ClearAlliance() => this.DM.mAllianceSearchView = false;

  private void AllianceUpdate(int arg1, int arg2)
  {
    if (AllianceHint.Search == null)
      return;
    switch (arg1)
    {
      case 0:
        AllianceHint.Pending = (long) (AllianceHint.SearchNum = Mathf.Min((int) DataManager.msgBuffer[1], 100));
        break;
      case 2:
        for (AllianceHint.SearchPage = 0; AllianceHint.SearchPage < AllianceHint.SearchNum && (bool) (Object) this.m_scroll && AllianceHint.SearchPage < this.m_panel.Length && (bool) (Object) this.m_panel[AllianceHint.SearchPage] && this.m_panel[AllianceHint.SearchPage].m_BtnID1 >= 0; ++AllianceHint.SearchPage)
          this.UpDateRowItem(((Component) this.m_panel[AllianceHint.SearchPage]).gameObject, this.m_panel[AllianceHint.SearchPage].m_BtnID1, 0, 1);
        break;
      case 22:
        if ((AllianceHint.SearchNum / 10 > (int) AllianceHint.SearchIdx || AllianceHint.SearchNum / 10 == (int) AllianceHint.SearchIdx && AllianceHint.SearchNum % 10 != 0) && NetworkManager.Connected())
        {
          AllianceHint.Pending = (long) AllianceHint.SearchIdx++;
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_SEARCHRESULT;
          messagePacket.AddSeqId();
          messagePacket.Add(AllianceHint.SearchIdx);
          messagePacket.Send();
          break;
        }
        break;
      case 23:
        this.m_scroll.gameObject.SetActive(false);
        break;
      case 24:
        this.m_scroll.gameObject.SetActive(true);
        break;
    }
    if (arg2 != 10)
      return;
    if (AllianceHint.SearchNum > 0)
    {
      this.SetEmptyMsgAlly(eMsgPanel.None);
      for (int index = 0; index < AllianceHint.SearchNum; ++index)
      {
        if (!this.DM.mAllianceSearchView)
          AllianceHint.Search[index].ID = 0U;
        if (this.ItemsHeight.Count < AllianceHint.SearchNum)
          this.ItemsHeight.Add(96f);
      }
      if (this.ItemsHeight.Count > AllianceHint.SearchNum)
        this.ItemsHeight.RemoveRange(AllianceHint.SearchNum - 1, this.ItemsHeight.Count - AllianceHint.SearchNum);
    }
    else
    {
      this.ItemsHeight.Clear();
      AllianceHint.SearchIdx = (byte) 0;
      this.SetEmptyMsgAlly(eMsgPanel.PlzInputName);
    }
    if (!(bool) (Object) this.m_scroll)
      return;
    this.m_scroll.gameObject.SetActive(true);
    this.m_scroll.AddNewDataHeight(this.ItemsHeight);
  }

  private void SearchChange(string input)
  {
    AllianceHint.FilterName = input;
    this.Alliance.GetChild(3).GetChild(16).gameObject.SetActive(AllianceHint.FilterName.Length > 0);
  }

  private void SetFilterName(byte Filter)
  {
    AllianceHint.FilterIdx = Filter;
    this.Alliance.GetChild(3).GetChild(17).GetChild(1).gameObject.SetActive(Filter == (byte) 0);
    this.Alliance.GetChild(3).GetChild(20).gameObject.SetActive(Filter > (byte) 0);
    if (Filter > (byte) 0)
      this.Alliance.GetChild(3).GetChild(17).GetChild(0).GetComponent<UIText>().text = this.DM.GetLanguageStr(Filter);
    else
      this.Alliance.GetChild(3).GetChild(17).GetChild(0).GetComponent<UIText>().text = string.Empty;
  }

  private void SetEmptyMsgAlly(eMsgPanel msg)
  {
    switch (msg)
    {
      case eMsgPanel.None:
        this.m_EmptyMsgPanel.gameObject.SetActive(false);
        break;
      case eMsgPanel.PlzInputName:
        this.m_EmptyMsgTextStr.ClearString();
        if (AllianceHint.SeekKind == (byte) 0)
          this.m_EmptyMsgTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(4711U));
        else if (AllianceHint.SearchLang != string.Empty && AllianceHint.SearchName != string.Empty)
        {
          this.m_EmptyMsgTextStr.StringToFormat(AllianceHint.FilterName);
          this.m_EmptyMsgTextStr.StringToFormat(this.DM.GetLanguageStr(AllianceHint.FilterIdx));
          this.m_EmptyMsgTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(735U));
        }
        else if (AllianceHint.SearchName != string.Empty)
        {
          this.m_EmptyMsgTextStr.StringToFormat(AllianceHint.FilterName);
          this.m_EmptyMsgTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(4709U));
        }
        else if (AllianceHint.SearchLang != string.Empty)
        {
          this.m_EmptyMsgTextStr.StringToFormat(this.DM.GetLanguageStr(AllianceHint.FilterIdx));
          this.m_EmptyMsgTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(4709U));
        }
        this.m_EmptyMsgText.text = this.m_EmptyMsgTextStr.ToString();
        this.m_EmptyMsgText.SetAllDirty();
        this.m_EmptyMsgText.cachedTextGenerator.Invalidate();
        this.m_EmptyMsgPanel.gameObject.SetActive(true);
        break;
      case eMsgPanel.SearchError:
        this.m_EmptyMsgTextStr.ClearString();
        this.m_EmptyMsgTextStr.StringToFormat(this.m_InputField.text);
        this.m_EmptyMsgTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(7050U));
        this.m_EmptyMsgText.text = this.m_EmptyMsgTextStr.ToString();
        this.m_EmptyMsgText.SetAllDirty();
        this.m_EmptyMsgText.cachedTextGenerator.Invalidate();
        this.m_EmptyMsgPanel.gameObject.SetActive(true);
        break;
    }
  }
}
