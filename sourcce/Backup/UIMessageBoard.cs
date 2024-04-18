// Decompiled with JetBrains decompiler
// Type: UIMessageBoard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIMessageBoard : GUIWindow, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int UnitCount = 9;
  private const float SendTalkTime = 3f;
  private const float TranslateHeight = 10f;
  private Transform m_transform;
  private DataManager DM = DataManager.Instance;
  private GUIManager GM = GUIManager.Instance;
  private UIText LeftmainText;
  private float BaseHeight = 55f;
  private ScrollPanel Scroll;
  private CScrollRect cScrollRect;
  private GameObject PanelGO;
  private GameObject NoMessageGO;
  private List<MessageBoard> NowList;
  private List<float> NowHeightList = new List<float>();
  private bool[] bFindScrollComp = new bool[9];
  private BMUnitComp[] Scroll_1_Comp = new BMUnitComp[9];
  private CString[] TimeStr = new CString[9];
  private CString[] NameStr = new CString[9];
  private CString[] LanguageStr = new CString[9];
  private CString[] DeleteMsgStr = new CString[9];
  private UIEmojiInput Input;
  private Font m_Font;
  private uint AllianceID;
  private UIText[] RBText = new UIText[2];
  private UIButton SendBtn;
  private Image SendImg;
  private CString InputErroeCString;
  private Color InputColor;
  private Color InputErrorColor;
  private long DeleteMessageID;
  private int DeleteMessageIndex;

  public override void OnOpen(int arg1, int arg2)
  {
    this.m_transform = this.transform;
    this.m_Font = this.GM.GetTTFFont();
    this.RBText[0] = this.m_transform.GetChild(2).GetComponent<UIText>();
    this.RBText[0].font = this.m_Font;
    this.RBText[0].text = this.DM.mStringTable.GetStringByID(8206U);
    this.NoMessageGO = this.m_transform.GetChild(3).gameObject;
    this.RBText[1] = this.m_transform.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.RBText[1].font = this.m_Font;
    this.RBText[1].text = this.DM.mStringTable.GetStringByID(8207U);
    this.Input = this.m_transform.GetChild(7).GetComponent<UIEmojiInput>();
    this.Input.placeholder = (Graphic) this.m_transform.GetChild(7).GetChild(0).GetComponent<UIText>();
    this.Input.textComponent = this.m_transform.GetChild(7).GetChild(1).GetComponent<UIText>();
    ((Component) this.Input).transform.GetChild(0).GetComponent<UIText>().font = this.m_Font;
    ((Component) this.Input).transform.GetChild(1).GetComponent<UIText>().font = this.m_Font;
    this.Input.shouldHideMobileInput = false;
    this.Input.lineType = UIEmojiInput.LineType.MultiLineNewline;
    ((Component) this.Input.placeholder).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(8208U);
    this.InputColor = ((Graphic) ((Component) this.Input.placeholder).GetComponent<UIText>()).color;
    this.InputErrorColor = new Color(0.596f, 0.0f, 0.0f);
    this.InputErroeCString = StringManager.Instance.SpawnString(200);
    this.InputErroeCString.IntToFormat(8L);
    this.InputErroeCString.AppendFormat(this.DM.mStringTable.GetStringByID(9167U));
    this.SendBtn = this.m_transform.GetChild(6).GetComponent<UIButton>();
    this.SendBtn.m_Handler = (IUIButtonClickHandler) this;
    this.SendBtn.transition = (Selectable.Transition) 1;
    this.SendImg = ((Component) this.SendBtn).transform.GetChild(0).GetComponent<Image>();
    this.m_transform.GetChild(8).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(8).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(8).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(8).GetComponent<CustomImage>()).enabled = false;
    Transform child1 = this.m_transform.GetChild(5).GetChild(0);
    this.GM.InitBadgeTotem(child1.GetChild(1).GetChild(0), (ushort) 0);
    this.GM.InitianHeroItemImg(child1.GetChild(2), eHeroOrItem.Hero, (ushort) 1, (byte) 11, (byte) 0);
    UIText component = child1.GetChild(3).GetComponent<UIText>();
    component.font = this.m_Font;
    component.resizeTextForBestFit = true;
    component.resizeTextMaxSize = 18;
    component.alignment = TextAnchor.MiddleLeft;
    ((Graphic) component).rectTransform.sizeDelta = new Vector2(480f, ((Graphic) component).rectTransform.sizeDelta.y);
    this.LeftmainText = child1.GetChild(4).GetComponent<UIText>();
    this.LeftmainText.font = this.m_Font;
    child1.GetChild(5).GetComponent<UIText>().font = this.m_Font;
    Transform child2 = this.m_transform.GetChild(5).GetChild(1);
    child2.GetChild(1).GetComponent<UIText>().font = this.m_Font;
    child2.GetChild(2).GetComponent<UIText>().font = this.m_Font;
    this.AllianceID = this.DM.SendAllianceID;
    this.NowList = this.DM.MessageBoardList;
    this.PanelGO = this.m_transform.GetChild(4).gameObject;
    this.Scroll = this.m_transform.GetChild(4).GetComponent<ScrollPanel>();
    this.Scroll.IntiScrollPanel(446f, 0.0f, 4f, this.NowHeightList, 9, (IUpDateScrollPanel) this);
    this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
    this.UpDateHeight();
    if (arg1 == 1)
      this.Scroll.gameObject.SetActive(false);
    else if ((int) this.DM.PreSendAllianceID != (int) this.DM.SendAllianceID)
    {
      this.DM.PreSendAllianceID = this.DM.SendAllianceID;
      this.Scroll.GoToLast();
    }
    else
      this.Scroll.GoTo(this.DM.MessageBoardScroll_Idx, this.DM.MessageBoardScroll_Y);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    for (int index = 8; index >= 0; --index)
    {
      if (this.TimeStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.TimeStr[index]);
        this.TimeStr[index] = (CString) null;
      }
      if (this.NameStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.NameStr[index]);
        this.NameStr[index] = (CString) null;
      }
      if (this.LanguageStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.LanguageStr[index]);
        this.LanguageStr[index] = (CString) null;
      }
      if (this.DeleteMsgStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.DeleteMsgStr[index]);
        this.DeleteMsgStr[index] = (CString) null;
      }
    }
    StringManager.Instance.DeSpawnString(this.InputErroeCString);
    this.DM.MessageBoardScroll_Y = this.cScrollRect.content.anchoredPosition.y;
    this.DM.MessageBoardScroll_Idx = this.Scroll.GetTopIdx();
  }

  private void InputEnd(string tmpStr)
  {
    if ((double) this.DM.sendTimer > 0.0)
    {
      this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(658U), (ushort) byte.MaxValue);
    }
    else
    {
      int num = 0;
      for (int index = 0; index < tmpStr.Length; ++index)
      {
        if (tmpStr[index] == '\n')
          ++num;
      }
      if (num >= 5)
        this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(244U), (ushort) byte.MaxValue);
      else if (Encoding.UTF8.GetBytes(tmpStr.ToCharArray(), 0, tmpStr.Length).Length > 400)
        this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(243U), (ushort) byte.MaxValue);
      else
        this.SendChat(tmpStr);
    }
  }

  private void SendChat(string tmpStr)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_SENDALLY;
    char[] charArray = tmpStr.ToCharArray();
    if (this.DM.m_BannedWord != null)
      this.DM.m_BannedWord.CheckBannedWord(charArray);
    byte[] bytes = Encoding.UTF8.GetBytes(charArray, 0, tmpStr.Length);
    if (bytes.Length <= 0)
      return;
    this.DM.FindBlack = (byte) 0;
    messagePacket.AddSeqId();
    messagePacket.Add(this.AllianceID);
    if (this.DM.ServerVersionMajor != (byte) 0)
      messagePacket.Add(!ArabicTransfer.Instance.IsArabicStr(tmpStr) ? (byte) 1 : (byte) 2);
    messagePacket.Add((ushort) bytes.Length);
    messagePacket.Add(bytes);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.MessageBoard);
    this.DM.sendTimer = 3f;
    this.Input.text = string.Empty;
  }

  private void UpDateHeight(bool GoToTop = true, bool bStopMove = true)
  {
    if (this.NowList.Count > 0)
    {
      this.PanelGO.SetActive(true);
      this.NoMessageGO.SetActive(false);
      this.NowHeightList.Clear();
      for (int Index = 0; Index < this.NowList.Count; ++Index)
        this.NowHeightList.Add(this.GetUnitHeight(Index));
      this.Scroll.AddNewDataHeight(this.NowHeightList, GoToTop, bStopMove);
    }
    else
    {
      this.PanelGO.SetActive(false);
      this.NoMessageGO.SetActive(true);
    }
    this.CheckSpeakInKindom();
  }

  private void CheckSpeakInKindom()
  {
    if (this.GM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 8)
    {
      this.Input.interactable = false;
      this.SendBtn.interactable = false;
      ((Graphic) this.SendImg).color = Color.gray;
      UIText component = ((Component) this.Input.placeholder).GetComponent<UIText>();
      component.text = this.InputErroeCString.ToString();
      ((Graphic) component).color = this.InputErrorColor;
    }
    else
    {
      this.Input.interactable = true;
      this.SendBtn.interactable = true;
      ((Graphic) this.SendImg).color = Color.white;
      UIText component = ((Component) this.Input.placeholder).GetComponent<UIText>();
      component.text = this.DM.mStringTable.GetStringByID(779U);
      ((Graphic) component).color = this.InputColor;
    }
  }

  private float GetUnitHeight(int Index)
  {
    if (Index < 0 || Index >= this.NowList.Count)
      return 0.0f;
    float unitHeight = 120f;
    if (this.NowList[Index].AllianceOrRole == (byte) 0 || this.NowList[Index].AllianceOrRole == (byte) 1)
    {
      float num = 55f;
      if (this.GM.bAutoTranslate && this.NowList[Index].TranslateShow != (byte) 0 && !this.NowList[Index].bSelfMessage && this.NowList[Index].TranslateState == eTranslateState.completed)
      {
        if ((double) this.NowList[Index].TotalHeightT != 0.0)
          return this.NowList[Index].TotalHeightT;
        unitHeight += 10f;
        this.LeftmainText.text = this.NowList[Index].TranslateText.ToString();
        if ((double) this.LeftmainText.preferredHeight > (double) num)
          unitHeight += this.LeftmainText.preferredHeight - num;
        this.NowList[Index].TotalHeightT = unitHeight;
      }
      else
      {
        if ((double) this.NowList[Index].TotalHeight != 0.0)
          return this.NowList[Index].TotalHeight;
        if (this.GM.bAutoTranslate && !this.NowList[Index].bSelfMessage && this.NowList[Index].TranslateState != eTranslateState.NoNeedTranslate)
          unitHeight += 10f;
        this.LeftmainText.text = this.NowList[Index].MessageStr.ToString();
        if ((double) this.LeftmainText.preferredHeight > (double) num)
          unitHeight += this.LeftmainText.preferredHeight - num;
        this.NowList[Index].TotalHeight = unitHeight;
      }
    }
    else if (this.NowList[Index].AllianceOrRole >= (byte) 2 && this.NowList[Index].AllianceOrRole <= (byte) 5)
    {
      if ((double) this.NowList[Index].TotalHeight != 0.0)
        return this.NowList[Index].TotalHeight;
      unitHeight = 55f;
      this.LeftmainText.text = this.DM.mStringTable.GetStringByID(10070U);
      this.LeftmainText.SetAllDirty();
      this.LeftmainText.cachedTextGeneratorForLayout.Invalidate();
      if ((double) this.LeftmainText.preferredHeight > 32.0)
        unitHeight = this.LeftmainText.preferredHeight + 25f;
      this.NowList[Index].TotalHeight = unitHeight;
    }
    return unitHeight;
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelObjectIdx >= 9)
      return;
    if (!this.bFindScrollComp[panelObjectIdx])
    {
      this.bFindScrollComp[panelObjectIdx] = true;
      this.Scroll_1_Comp[panelObjectIdx].NormalItemGO = item.transform.GetChild(0).gameObject;
      this.Scroll_1_Comp[panelObjectIdx].DeleteItemGO = item.transform.GetChild(1).gameObject;
      Transform child1 = item.transform.GetChild(0);
      this.Scroll_1_Comp[panelObjectIdx].BackRC = item.transform.GetComponent<RectTransform>();
      this.Scroll_1_Comp[panelObjectIdx].BadageT = child1.GetChild(1);
      this.Scroll_1_Comp[panelObjectIdx].RoleIconT = child1.GetChild(2);
      this.Scroll_1_Comp[panelObjectIdx].NameText = child1.GetChild(3).GetComponent<UIText>();
      this.Scroll_1_Comp[panelObjectIdx].MessageText = child1.GetChild(4).GetComponent<UIText>();
      this.Scroll_1_Comp[panelObjectIdx].TimeText = child1.GetChild(5).GetComponent<UIText>();
      this.TimeStr[panelObjectIdx] = StringManager.Instance.SpawnString();
      this.NameStr[panelObjectIdx] = StringManager.Instance.SpawnString(100);
      this.LanguageStr[panelObjectIdx] = StringManager.Instance.SpawnString(150);
      this.Scroll_1_Comp[panelObjectIdx].NameText.SetCheckArabic(true);
      this.Scroll_1_Comp[panelObjectIdx].MessageText.SetCheckArabic(true);
      this.Scroll_1_Comp[panelObjectIdx].TranslateImgGO = child1.GetChild(6).gameObject;
      this.Scroll_1_Comp[panelObjectIdx].TranslateText = child1.GetChild(8).GetComponent<UIText>();
      this.Scroll_1_Comp[panelObjectIdx].TranslateText.font = this.m_Font;
      this.Scroll_1_Comp[panelObjectIdx].TranslateBtnGO = child1.GetChild(7).gameObject;
      UIButton component1 = this.Scroll_1_Comp[panelObjectIdx].TranslateBtnGO.transform.GetComponent<UIButton>();
      component1.m_Handler = (IUIButtonClickHandler) this;
      component1.m_BtnID2 = panelObjectIdx;
      UIButton component2 = child1.GetChild(9).GetComponent<UIButton>();
      component2.m_Handler = (IUIButtonClickHandler) this;
      component2.m_BtnID2 = panelObjectIdx;
      UIButton component3 = child1.GetChild(10).GetComponent<UIButton>();
      component3.m_Handler = (IUIButtonClickHandler) this;
      component3.m_BtnID1 = 5;
      component3.m_BtnID2 = panelObjectIdx;
      this.Scroll_1_Comp[panelObjectIdx].ProfileBtn2 = (RectTransform) ((Component) component3).transform;
      this.Scroll_1_Comp[panelObjectIdx].DeleteBtnGO = child1.GetChild(11).gameObject;
      UIButton component4 = this.Scroll_1_Comp[panelObjectIdx].DeleteBtnGO.transform.GetComponent<UIButton>();
      component4.m_Handler = (IUIButtonClickHandler) this;
      component4.m_BtnID2 = panelObjectIdx;
      Transform child2 = item.transform.GetChild(1);
      this.Scroll_1_Comp[panelObjectIdx].Delete_RC = child2.GetComponent<RectTransform>();
      this.Scroll_1_Comp[panelObjectIdx].Delete_TimeText = child2.GetChild(1).GetComponent<UIText>();
      this.Scroll_1_Comp[panelObjectIdx].Delete_MessageText = child2.GetChild(2).GetComponent<UIText>();
      this.DeleteMsgStr[panelObjectIdx] = StringManager.Instance.SpawnString(300);
    }
    if (dataIdx < 0 || dataIdx >= this.NowList.Count)
      return;
    MessageBoard now = this.NowList[dataIdx];
    this.Scroll_1_Comp[panelObjectIdx].DataIndex = dataIdx;
    if (this.NowList[dataIdx].AllianceOrRole == (byte) 0 || this.NowList[dataIdx].AllianceOrRole == (byte) 1)
    {
      this.Scroll_1_Comp[panelObjectIdx].NormalItemGO.SetActive(true);
      this.Scroll_1_Comp[panelObjectIdx].DeleteItemGO.SetActive(false);
      bool flag = !this.NowList[dataIdx].bSelfMessage && this.GM.bAutoTranslate && this.NowList[dataIdx].TranslateState != eTranslateState.NoNeedTranslate;
      if (flag)
      {
        if (this.NowList[dataIdx].TranslateState == eTranslateState.Translation)
        {
          this.Scroll_1_Comp[panelObjectIdx].TranslateImgGO.SetActive(true);
          this.Scroll_1_Comp[panelObjectIdx].TranslateBtnGO.SetActive(false);
        }
        else
        {
          this.Scroll_1_Comp[panelObjectIdx].TranslateImgGO.SetActive(false);
          this.Scroll_1_Comp[panelObjectIdx].TranslateBtnGO.SetActive(true);
        }
        ((Component) this.Scroll_1_Comp[panelObjectIdx].TranslateText).gameObject.SetActive(true);
        if (this.NowList[dataIdx].TranslateShow == (byte) 0)
        {
          this.Scroll_1_Comp[panelObjectIdx].TranslateText.text = this.DM.mStringTable.GetStringByID(9052U);
        }
        else
        {
          this.LanguageStr[panelObjectIdx].Length = 0;
          this.LanguageStr[panelObjectIdx].StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte) this.NowList[dataIdx].TranslateLanguage));
          this.LanguageStr[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(9054U));
          this.Scroll_1_Comp[panelObjectIdx].TranslateText.text = this.LanguageStr[panelObjectIdx].ToString();
          ((Graphic) this.Scroll_1_Comp[panelObjectIdx].TranslateText).SetVerticesDirty();
          ((Graphic) this.Scroll_1_Comp[panelObjectIdx].TranslateText).SetLayoutDirty();
          this.Scroll_1_Comp[panelObjectIdx].TranslateText.cachedTextGenerator.Invalidate();
        }
      }
      else
      {
        this.Scroll_1_Comp[panelObjectIdx].TranslateImgGO.SetActive(false);
        this.Scroll_1_Comp[panelObjectIdx].TranslateBtnGO.SetActive(false);
        ((Component) this.Scroll_1_Comp[panelObjectIdx].TranslateText).gameObject.SetActive(false);
      }
      this.Scroll_1_Comp[panelObjectIdx].BackRC.sizeDelta = !flag || this.NowList[dataIdx].TranslateShow == (byte) 0 || this.NowList[dataIdx].TranslateState != eTranslateState.completed ? new Vector2(702f, now.TotalHeight) : new Vector2(702f, now.TotalHeightT);
      if (now.AllianceOrRole == (byte) 1)
      {
        this.Scroll_1_Comp[panelObjectIdx].BadageT.gameObject.SetActive(true);
        this.Scroll_1_Comp[panelObjectIdx].RoleIconT.gameObject.SetActive(false);
        this.GM.SetBadgeTotemImg(this.Scroll_1_Comp[panelObjectIdx].BadageT.GetChild(0), now.PicID);
      }
      else
      {
        this.Scroll_1_Comp[panelObjectIdx].BadageT.gameObject.SetActive(false);
        this.Scroll_1_Comp[panelObjectIdx].RoleIconT.gameObject.SetActive(true);
        this.GM.ChangeHeroItemImg(this.Scroll_1_Comp[panelObjectIdx].RoleIconT, eHeroOrItem.Hero, now.PicID, (byte) 11, (byte) 0);
      }
      if (now.AllianceOrRole == (byte) 0)
      {
        this.NameStr[panelObjectIdx].Length = 0;
        this.NameStr[panelObjectIdx].StringToFormat(now.NameStr);
        this.NameStr[panelObjectIdx].AppendFormat("<color=#00479DFF>{0}</color>");
        this.Scroll_1_Comp[panelObjectIdx].NameText.text = this.NameStr[panelObjectIdx].ToString();
        this.Scroll_1_Comp[panelObjectIdx].NameText.SetAllDirty();
        this.Scroll_1_Comp[panelObjectIdx].NameText.cachedTextGenerator.Invalidate();
      }
      else
      {
        this.NameStr[panelObjectIdx].Length = 0;
        this.NameStr[panelObjectIdx].StringToFormat(now.AllianceTagStr);
        this.NameStr[panelObjectIdx].StringToFormat(now.AllianceNameStr);
        this.NameStr[panelObjectIdx].StringToFormat(now.NameStr);
        this.NameStr[panelObjectIdx].AppendFormat("[{0}]{1} <color=#00479DFF>{2}</color>");
        this.Scroll_1_Comp[panelObjectIdx].NameText.text = this.NameStr[panelObjectIdx].ToString();
        this.Scroll_1_Comp[panelObjectIdx].NameText.SetAllDirty();
        this.Scroll_1_Comp[panelObjectIdx].NameText.cachedTextGenerator.Invalidate();
      }
      int num = 0;
      this.Scroll_1_Comp[panelObjectIdx].MessageText.text = !flag || this.NowList[dataIdx].TranslateShow == (byte) 0 || this.NowList[dataIdx].TranslateState != eTranslateState.completed ? now.MessageStr.ToString() : now.TranslateText.ToString();
      if ((double) this.Scroll_1_Comp[panelObjectIdx].MessageText.preferredHeight > (double) this.BaseHeight)
      {
        ((Graphic) this.Scroll_1_Comp[panelObjectIdx].MessageText).rectTransform.sizeDelta = new Vector2(((Graphic) this.Scroll_1_Comp[panelObjectIdx].MessageText).rectTransform.sizeDelta.x, this.Scroll_1_Comp[panelObjectIdx].MessageText.preferredHeight);
        num = (int) ((double) this.Scroll_1_Comp[panelObjectIdx].MessageText.preferredHeight - (double) this.BaseHeight);
      }
      this.Scroll_1_Comp[panelObjectIdx].ProfileBtn2.sizeDelta = num <= 0 ? new Vector2(this.Scroll_1_Comp[panelObjectIdx].ProfileBtn2.sizeDelta.x, 103f) : new Vector2(this.Scroll_1_Comp[panelObjectIdx].ProfileBtn2.sizeDelta.x, (float) (103 + num));
      this.DM.SetSBTime(this.DM.ServerTime - now.MessageTime, this.TimeStr[panelObjectIdx]);
      this.Scroll_1_Comp[panelObjectIdx].TimeText.text = this.TimeStr[panelObjectIdx].ToString();
      this.Scroll_1_Comp[panelObjectIdx].TimeText.SetAllDirty();
      this.Scroll_1_Comp[panelObjectIdx].TimeText.cachedTextGenerator.Invalidate();
      if ((int) this.AllianceID == (int) this.DM.RoleAlliance.Id && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
        this.Scroll_1_Comp[panelObjectIdx].DeleteBtnGO.SetActive(true);
      else
        this.Scroll_1_Comp[panelObjectIdx].DeleteBtnGO.SetActive(false);
    }
    else
    {
      if (this.NowList[dataIdx].AllianceOrRole < (byte) 2 || this.NowList[dataIdx].AllianceOrRole > (byte) 5)
        return;
      this.Scroll_1_Comp[panelObjectIdx].NormalItemGO.SetActive(false);
      this.Scroll_1_Comp[panelObjectIdx].DeleteItemGO.SetActive(true);
      this.Scroll_1_Comp[panelObjectIdx].BackRC.sizeDelta = new Vector2(702f, now.TotalHeight);
      this.Scroll_1_Comp[panelObjectIdx].Delete_RC.sizeDelta = new Vector2(702f, now.TotalHeight - 3f);
      this.Scroll_1_Comp[panelObjectIdx].Delete_MessageText.text = this.DM.mStringTable.GetStringByID(10070U);
      this.DM.SetSBTime(this.DM.ServerTime - now.MessageTime, this.TimeStr[panelObjectIdx]);
      this.Scroll_1_Comp[panelObjectIdx].Delete_TimeText.text = this.TimeStr[panelObjectIdx].ToString();
      this.Scroll_1_Comp[panelObjectIdx].Delete_TimeText.SetAllDirty();
      this.Scroll_1_Comp[panelObjectIdx].Delete_TimeText.cachedTextGenerator.Invalidate();
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if ((bool) (Object) this.GM.FindMenu(EGUIWindow.UI_Chat))
          break;
        this.Scroll.gameObject.SetActive(false);
        this.DM.AskMessageBoard(this.AllianceID);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        for (int index = 0; index < 9; ++index)
        {
          if (this.bFindScrollComp[index])
          {
            if ((Object) this.Scroll_1_Comp[index].NameText != (Object) null && ((Behaviour) this.Scroll_1_Comp[index].NameText).enabled)
            {
              ((Behaviour) this.Scroll_1_Comp[index].NameText).enabled = false;
              ((Behaviour) this.Scroll_1_Comp[index].NameText).enabled = true;
            }
            if ((Object) this.Scroll_1_Comp[index].MessageText != (Object) null && ((Behaviour) this.Scroll_1_Comp[index].MessageText).enabled)
            {
              ((Behaviour) this.Scroll_1_Comp[index].MessageText).enabled = false;
              ((Behaviour) this.Scroll_1_Comp[index].MessageText).enabled = true;
            }
            if ((Object) this.Scroll_1_Comp[index].TimeText != (Object) null && ((Behaviour) this.Scroll_1_Comp[index].TimeText).enabled)
            {
              ((Behaviour) this.Scroll_1_Comp[index].TimeText).enabled = false;
              ((Behaviour) this.Scroll_1_Comp[index].TimeText).enabled = true;
            }
            if ((Object) this.Scroll_1_Comp[index].TranslateText != (Object) null && ((Behaviour) this.Scroll_1_Comp[index].TranslateText).enabled)
            {
              ((Behaviour) this.Scroll_1_Comp[index].TranslateText).enabled = false;
              ((Behaviour) this.Scroll_1_Comp[index].TranslateText).enabled = true;
            }
            if ((Object) this.Scroll_1_Comp[index].Delete_MessageText != (Object) null && ((Behaviour) this.Scroll_1_Comp[index].Delete_MessageText).enabled)
            {
              ((Behaviour) this.Scroll_1_Comp[index].Delete_MessageText).enabled = false;
              ((Behaviour) this.Scroll_1_Comp[index].Delete_MessageText).enabled = true;
            }
            if ((Object) this.Scroll_1_Comp[index].Delete_TimeText != (Object) null && ((Behaviour) this.Scroll_1_Comp[index].Delete_TimeText).enabled)
            {
              ((Behaviour) this.Scroll_1_Comp[index].Delete_TimeText).enabled = false;
              ((Behaviour) this.Scroll_1_Comp[index].Delete_TimeText).enabled = true;
            }
          }
        }
        for (int index = 0; index < this.RBText.Length; ++index)
        {
          if ((Object) this.RBText[index] != (Object) null && ((Behaviour) this.RBText[index]).enabled)
          {
            ((Behaviour) this.RBText[index]).enabled = false;
            ((Behaviour) this.RBText[index]).enabled = true;
          }
        }
        if (!((Object) this.Input != (Object) null))
          break;
        if ((Object) this.Input.textComponent != (Object) null && ((Behaviour) this.Input.textComponent).enabled)
        {
          ((Behaviour) this.Input.textComponent).enabled = false;
          ((Behaviour) this.Input.textComponent).enabled = true;
        }
        if (!((Object) this.Input.placeholder != (Object) null) || !((Behaviour) this.Input.placeholder).enabled)
          break;
        ((Behaviour) this.Input.placeholder).enabled = false;
        ((Behaviour) this.Input.placeholder).enabled = true;
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.UpDateHeight();
        this.Scroll.GoToLast();
        break;
      case 2:
      case 3:
        this.UpDateHeight();
        if ((int) this.DM.PreSendAllianceID != (int) this.DM.SendAllianceID)
        {
          this.DM.PreSendAllianceID = this.DM.SendAllianceID;
          this.Scroll.GoToLast();
        }
        else
          this.Scroll.GoTo(this.DM.MessageBoardScroll_Idx, this.DM.MessageBoardScroll_Y);
        this.Scroll.gameObject.SetActive(true);
        break;
      case 4:
        this.UpDateHeight(false, false);
        break;
      case 5:
        this.CheckSpeakInKindom();
        break;
      case 6:
        this.SendDeleteMessage();
        break;
      case 7:
        this.UpDateHeight(false, false);
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      switch (sender.m_BtnID2)
      {
        case 1:
          (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
          break;
        case 2:
          this.InputEnd(this.Input.text);
          break;
      }
    }
    else if (sender.m_BtnID1 == 3)
    {
      if (!this.bFindScrollComp[sender.m_BtnID2])
        return;
      int dataIndex = this.Scroll_1_Comp[sender.m_BtnID2].DataIndex;
      if (dataIndex >= this.NowList.Count)
        return;
      if (this.NowList[dataIndex].TranslateState == eTranslateState.completed)
      {
        this.NowList[dataIndex].TranslateShow = this.NowList[dataIndex].TranslateShow != (byte) 0 ? (byte) 0 : (byte) 1;
        this.UpDateHeight(false, false);
      }
      else
      {
        if (this.NowList[dataIndex].TranslateState == eTranslateState.Translation || this.NowList[dataIndex].TranslateState != eTranslateState.Untranslated && this.NowList[dataIndex].TranslateState != eTranslateState.TranslateFail || this.GM.bWaitTranslate_MB)
          return;
        this.GM.MB_TranslateBatch(this.NowList[dataIndex]);
        this.NowList[dataIndex].TranslateState = eTranslateState.Translation;
        this.GM.MB_SendTranslateBatch();
        this.UpDateHeight(false, false);
      }
    }
    else if (sender.m_BtnID1 == 4 || sender.m_BtnID1 == 5)
    {
      if (!this.bFindScrollComp[sender.m_BtnID2])
        return;
      int dataIndex = this.Scroll_1_Comp[sender.m_BtnID2].DataIndex;
      if (dataIndex >= this.NowList.Count)
        return;
      Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
      if ((Object) menu == (Object) null)
        return;
      if (this.NowList[dataIndex].AllianceOrRole == (byte) 0 || sender.m_BtnID1 == 5)
        this.DM.ShowLordProfile(this.NowList[dataIndex].NameStr.ToString());
      else
        menu.AllianceInfo(this.NowList[dataIndex].AllianceTagStr.ToString());
    }
    else
    {
      if (sender.m_BtnID1 != 6 || !this.bFindScrollComp[sender.m_BtnID2])
        return;
      this.DeleteMessageIndex = this.Scroll_1_Comp[sender.m_BtnID2].DataIndex;
      if (this.DeleteMessageIndex >= this.NowList.Count)
        return;
      this.DeleteMessageID = this.NowList[this.DeleteMessageIndex].MessageID;
      if (this.GM.bCheckDeleteMsg)
        this.GM.OpenCheckDeleteMsg();
      else
        this.SendDeleteMessage();
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void SendDeleteMessage()
  {
    if (this.DM.RoleAlliance.Rank < AllianceRank.RANK4)
      GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
    else if (this.DeleteMessageIndex < this.NowList.Count && this.NowList[this.DeleteMessageIndex].AllianceOrRole >= (byte) 2)
    {
      GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(10074U), (ushort) byte.MaxValue);
    }
    else
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.AddSeqId();
      messagePacket.Protocol = Protocol._MSG_REQUEST_DELETECHAT;
      messagePacket.Add(this.AllianceID);
      messagePacket.Add(this.DeleteMessageID);
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.MessageBoard);
    }
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (Object) menu)
      return;
    img.sprite = menu.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = menu.LoadMaterial();
  }
}
