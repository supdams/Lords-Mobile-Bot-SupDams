// Decompiled with JetBrains decompiler
// Type: UIChat
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIChat : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int UnitCount = 13;
  private const float SendTalkTime = 3f;
  private const float TranslateHeight = 10f;
  private Transform m_transform;
  private Transform LeftT;
  private RectTransform ViewStateImgRC;
  private RectTransform ViewStateTextRC;
  private GameObject ClickChatObject;
  private GameObject AllianceRequestObject;
  private GameObject HelpBtnObj;
  private GameObject PreBtnObject;
  private GameObject MiddleBtnObject;
  private GameObject FlashObj;
  private GameObject PosBtnObject;
  private GameObject PosImgObject;
  private GameObject BLBtnObject;
  private GameObject SendBLBtnObject;
  private GameObject KindomFlash;
  private GameObject AllianceFlash;
  private GameObject CopyMsgObj;
  private GameObject EmojiAleretObj;
  private UIButton PreBtn;
  private UIButton MiddleBtn;
  private UIButton BottomBtn;
  private UIButton SendBtn;
  private UIButton PlayerInfoBtn;
  private UIButton EmojiBnt;
  private DataManager DM = DataManager.Instance;
  private GUIManager GM = GUIManager.Instance;
  private ScrollPanel Scroll;
  private ScrollPanel ScrollBL;
  private CScrollRect cScrollRect;
  private UIEmojiInput mInput;
  private Font m_Font;
  private UIText LeftmainText;
  private UIText ViewStateText;
  private UIText PlayerNameText;
  private UIText PosText;
  private UIText PosText2;
  private UIText BLText;
  private UIText InputText;
  private UIText TitleText;
  private Image ViewStateImg;
  private Image SendImg;
  private Image EmojiImg;
  private Image PosImage;
  private byte NowInputType;
  private byte NowChannel = byte.MaxValue;
  private float TitleHeight = 25f;
  private float UnitbaseHeight = 75f;
  private float PosTextWidth;
  private List<TalkDataType> NowList;
  private List<float> NowHeightList = new List<float>();
  private List<int> NowIndexList = new List<int>();
  private TalkDataType ClickChatData;
  private long ClickChatPlayID;
  private UISpritesArray SArray;
  private bool[] bFindScrollComp = new bool[13];
  private UnitComp[] Scroll_1_Comp = new UnitComp[13];
  private CString[] TimeStr = new CString[13];
  private CString[] LanguageStr = new CString[13];
  private CString[] NameCStr = new CString[13];
  private CString[] VIPCStr = new CString[13];
  private CString PosStr;
  private CString InputErroeCString;
  private ListViewState NowViewState;
  private byte AllianceChatState;
  private int BeginIndex;
  private int EndIndex;
  private RectTransform UnReadCountRC;
  private UIText UnReadCountText;
  private CString UnreadStr;
  private float CheckTimer;
  private int NewTalkCount;
  private byte OpenSendAsk;
  private Color OriginalColor;
  private Color InputColor;
  private Color InputErrorColor;

  public override void OnOpen(int arg1, int arg2)
  {
    // ISSUE: unable to decompile the method.
  }

  public void OpenUpdate(int arg1)
  {
    if (this.ClickChatObject.activeInHierarchy)
      this.CloseClickChatObj();
    this.CheckUnRead(this.DM.unReadCount > 0 && this.DM.bShowUnreadCount);
    this.NowChannel = byte.MaxValue;
    if (!(arg1 == 0 ? this.SetChannel(this.DM.NowChannel) : this.SetChannel((byte) (arg1 - 1))) || this.DM.bChangeKingdomClear)
      this.RefreshScrollPanel(false, false);
    this.DM.bChangeKingdomClear = false;
    if (!BattleController.IsGambleMode)
      return;
    ((Component) this.GM.m_ChatBox).gameObject.SetActive(false);
  }

  private void CheckAutoScroll()
  {
    if (this.NowList.Count <= 0)
      return;
    if (this.DM.NowChannel == (byte) 0)
    {
      if (this.DM.NowKingdomIndex != -1)
        this.Scroll.GoTo(this.DM.NowKingdomIndex, this.DM.NowKingdomPos);
      else
        this.Scroll.GoToLast();
    }
    else
    {
      if (this.NowChannel == (byte) 1 && this.DM.unReadIndex != -1 && !this.DM.bClearUnread)
        this.DM.bClearUnread = true;
      if (this.AllianceChatState == (byte) 1)
      {
        if (this.DM.NowAllianceIndex2 != -1)
          this.Scroll.GoTo(this.DM.NowAllianceIndex2, this.DM.NowAlliancePos2);
        else
          this.Scroll.GoToLast();
      }
      else if (this.DM.NowAllianceIndex1 != -1)
        this.Scroll.GoTo(this.DM.NowAllianceIndex1, this.DM.NowAlliancePos1);
      else
        this.Scroll.GoToLast();
    }
  }

  public override void OnClose()
  {
    this.SavePagePara();
    for (int index = 12; index >= 0; --index)
    {
      if (this.TimeStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.TimeStr[index]);
        this.TimeStr[index] = (CString) null;
      }
      if (this.LanguageStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.LanguageStr[index]);
        this.LanguageStr[index] = (CString) null;
      }
      if (this.NameCStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.NameCStr[index]);
        this.NameCStr[index] = (CString) null;
      }
      if (this.VIPCStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.VIPCStr[index]);
        this.VIPCStr[index] = (CString) null;
      }
      if (this.Scroll_1_Comp[index].Emoji != null)
      {
        this.GM.pushEmojiIcon(this.Scroll_1_Comp[index].Emoji);
        this.Scroll_1_Comp[index].Emoji = (EmojiUnit) null;
      }
    }
    StringManager.Instance.DeSpawnString(this.InputErroeCString);
    StringManager.Instance.DeSpawnString(this.UnreadStr);
    this.UnreadStr = (CString) null;
    if (this.PosStr == null)
      return;
    StringManager.Instance.DeSpawnString(this.PosStr);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    for (int index1 = 0; index1 < 13; ++index1)
    {
      if (this.bFindScrollComp[index1])
      {
        if ((Object) this.Scroll_1_Comp[index1].VIPText != (Object) null && ((Behaviour) this.Scroll_1_Comp[index1].VIPText).enabled)
        {
          ((Behaviour) this.Scroll_1_Comp[index1].VIPText).enabled = false;
          ((Behaviour) this.Scroll_1_Comp[index1].VIPText).enabled = true;
        }
        if ((Object) this.Scroll_1_Comp[index1].PlayerName != (Object) null && ((Behaviour) this.Scroll_1_Comp[index1].PlayerName).enabled)
        {
          ((Behaviour) this.Scroll_1_Comp[index1].PlayerName).enabled = false;
          ((Behaviour) this.Scroll_1_Comp[index1].PlayerName).enabled = true;
        }
        for (int index2 = 0; index2 < this.Scroll_1_Comp[index1].TitleNameText.Length; ++index2)
        {
          if (this.Scroll_1_Comp[index1].TitleNameText != null && (Object) this.Scroll_1_Comp[index1].TitleNameText[index2] != (Object) null && ((Behaviour) this.Scroll_1_Comp[index1].TitleNameText[index2]).enabled)
          {
            ((Behaviour) this.Scroll_1_Comp[index1].TitleNameText[index2]).enabled = false;
            ((Behaviour) this.Scroll_1_Comp[index1].TitleNameText[index2]).enabled = true;
          }
        }
        if ((Object) this.Scroll_1_Comp[index1].MainText != (Object) null && ((Behaviour) this.Scroll_1_Comp[index1].MainText).enabled)
        {
          ((Behaviour) this.Scroll_1_Comp[index1].MainText).enabled = false;
          ((Behaviour) this.Scroll_1_Comp[index1].MainText).enabled = true;
        }
        if ((Object) this.Scroll_1_Comp[index1].TimeText != (Object) null && ((Behaviour) this.Scroll_1_Comp[index1].TimeText).enabled)
        {
          ((Behaviour) this.Scroll_1_Comp[index1].TimeText).enabled = false;
          ((Behaviour) this.Scroll_1_Comp[index1].TimeText).enabled = true;
        }
        if ((Object) this.Scroll_1_Comp[index1].Base2Text != (Object) null && ((Behaviour) this.Scroll_1_Comp[index1].Base2Text).enabled)
        {
          ((Behaviour) this.Scroll_1_Comp[index1].Base2Text).enabled = false;
          ((Behaviour) this.Scroll_1_Comp[index1].Base2Text).enabled = true;
        }
        if ((Object) this.Scroll_1_Comp[index1].Base3Text != (Object) null && ((Behaviour) this.Scroll_1_Comp[index1].Base3Text).enabled)
        {
          ((Behaviour) this.Scroll_1_Comp[index1].Base3Text).enabled = false;
          ((Behaviour) this.Scroll_1_Comp[index1].Base3Text).enabled = true;
        }
        if ((Object) this.Scroll_1_Comp[index1].Base3TimeText != (Object) null && ((Behaviour) this.Scroll_1_Comp[index1].Base3TimeText).enabled)
        {
          ((Behaviour) this.Scroll_1_Comp[index1].Base3TimeText).enabled = false;
          ((Behaviour) this.Scroll_1_Comp[index1].Base3TimeText).enabled = true;
        }
        if ((Object) this.Scroll_1_Comp[index1].TranslateText != (Object) null && ((Behaviour) this.Scroll_1_Comp[index1].TranslateText).enabled)
        {
          ((Behaviour) this.Scroll_1_Comp[index1].TranslateText).enabled = false;
          ((Behaviour) this.Scroll_1_Comp[index1].TranslateText).enabled = true;
        }
      }
    }
    if ((Object) this.mInput != (Object) null)
    {
      if ((Object) this.mInput.textComponent != (Object) null && ((Behaviour) this.mInput.textComponent).enabled)
      {
        ((Behaviour) this.mInput.textComponent).enabled = false;
        ((Behaviour) this.mInput.textComponent).enabled = true;
      }
      if ((Object) this.mInput.placeholder != (Object) null && ((Behaviour) this.mInput.placeholder).enabled)
      {
        ((Behaviour) this.mInput.placeholder).enabled = false;
        ((Behaviour) this.mInput.placeholder).enabled = true;
      }
    }
    if ((Object) this.PlayerNameText != (Object) null && ((Behaviour) this.PlayerNameText).enabled)
    {
      ((Behaviour) this.PlayerNameText).enabled = false;
      ((Behaviour) this.PlayerNameText).enabled = true;
    }
    if ((Object) this.PosText != (Object) null && ((Behaviour) this.PosText).enabled)
    {
      ((Behaviour) this.PosText).enabled = false;
      ((Behaviour) this.PosText).enabled = true;
    }
    if ((Object) this.PosText2 != (Object) null && ((Behaviour) this.PosText2).enabled)
    {
      ((Behaviour) this.PosText2).enabled = false;
      ((Behaviour) this.PosText2).enabled = true;
    }
    if (!((Object) this.BLText != (Object) null) || !((Behaviour) this.BLText).enabled)
      return;
    ((Behaviour) this.BLText).enabled = false;
    ((Behaviour) this.BLText).enabled = true;
  }

  private void Update()
  {
    this.CheckTimer -= Time.deltaTime;
    if ((double) this.CheckTimer <= 0.0)
    {
      this.CheckTimer = 0.5f;
      if (this.NowChannel == (byte) 1)
      {
        if (this.DM.unReadCount > 0 && this.DM.unReadIndex != -1 && !this.Scroll.CheckInPanel(this.DM.unReadIndex - this.BeginIndex))
        {
          ColorBlock colors = this.MiddleBtn.colors;
          ((ColorBlock) ref colors).normalColor = Color.white;
          ((ColorBlock) ref colors).highlightedColor = Color.white;
          this.MiddleBtn.colors = colors;
        }
        else
        {
          ColorBlock colors = this.MiddleBtn.colors;
          ((ColorBlock) ref colors).normalColor = Color.gray;
          ((ColorBlock) ref colors).highlightedColor = Color.gray;
          this.MiddleBtn.colors = colors;
        }
        if (this.OpenSendAsk == (byte) 2 && (this.AllianceChatState == (byte) 0 || !this.Scroll.CheckInPanel(this.DM.LastTimeIndex)))
        {
          ColorBlock colors = this.PreBtn.colors;
          ((ColorBlock) ref colors).normalColor = Color.white;
          ((ColorBlock) ref colors).highlightedColor = Color.white;
          this.PreBtn.colors = colors;
        }
        else
        {
          ColorBlock colors = this.PreBtn.colors;
          ((ColorBlock) ref colors).normalColor = Color.gray;
          ((ColorBlock) ref colors).highlightedColor = Color.gray;
          this.PreBtn.colors = colors;
        }
        bool flag = this.Scroll.CheckAtLast();
        if (this.AllianceChatState == (byte) 1 || this.AllianceChatState != (byte) 1 && !flag)
        {
          ColorBlock colors = this.BottomBtn.colors;
          ((ColorBlock) ref colors).normalColor = Color.white;
          ((ColorBlock) ref colors).highlightedColor = Color.white;
          this.BottomBtn.colors = colors;
        }
        else
        {
          ColorBlock colors = this.BottomBtn.colors;
          ((ColorBlock) ref colors).normalColor = Color.gray;
          ((ColorBlock) ref colors).highlightedColor = Color.gray;
          this.BottomBtn.colors = colors;
        }
        this.CheckFlashBottomBtn();
      }
      else
      {
        bool flag = this.Scroll.CheckAtLast();
        if (this.NowList.Count > 0 && !flag)
        {
          ColorBlock colors = this.BottomBtn.colors;
          ((ColorBlock) ref colors).normalColor = Color.white;
          ((ColorBlock) ref colors).highlightedColor = Color.white;
          this.BottomBtn.colors = colors;
        }
        else
        {
          ColorBlock colors = this.BottomBtn.colors;
          ((ColorBlock) ref colors).normalColor = Color.gray;
          ((ColorBlock) ref colors).highlightedColor = Color.gray;
          this.BottomBtn.colors = colors;
        }
      }
    }
    if (this.cScrollRect.bStopViewState && this.cScrollRect.bStopViewState_Up || this.NowViewState == this.cScrollRect.ViewState)
      return;
    this.NowViewState = this.cScrollRect.ViewState;
    switch (this.NowViewState)
    {
      case ListViewState.LVS_PULL_REFRESH:
        this.ViewStateTextRC.anchoredPosition = new Vector2(30f, 267.5f);
        this.ViewStateImgRC.anchoredPosition = new Vector2(-75f, 267.5f);
        ((Transform) this.ViewStateImgRC).localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        this.ViewStateImgRC.sizeDelta = new Vector2(26f, 25f);
        this.ViewStateImg.sprite = this.SArray.m_Sprites[15];
        break;
      case ListViewState.LVS_RELEASE_REFRESH:
        this.ViewStateTextRC.anchoredPosition = new Vector2(30f, 267.5f);
        this.ViewStateImgRC.anchoredPosition = new Vector2(-75f, 267.5f);
        ((Transform) this.ViewStateImgRC).localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        this.ViewStateImgRC.sizeDelta = new Vector2(26f, 25f);
        this.ViewStateImg.sprite = this.SArray.m_Sprites[14];
        break;
      case ListViewState.LVS_LOADING:
        this.ViewStateTextRC.anchoredPosition = new Vector2(30f, 267.5f);
        this.ViewStateImgRC.anchoredPosition = new Vector2(-12f, 267.5f);
        this.ViewStateImgRC.sizeDelta = new Vector2(26f, 26f);
        this.ViewStateImg.sprite = this.SArray.m_Sprites[16];
        int nowTopIndex = this.FindNowTopIndex();
        if (this.DM.SendAskKind == -1 && nowTopIndex != -1)
        {
          if (this.AllianceChatState == (byte) 0)
            this.DM.SendAskKind = 2;
          else if (this.AllianceChatState == (byte) 1)
            this.DM.SendAskKind = 0;
          else if (this.AllianceChatState == (byte) 2)
            this.DM.SendAskKind = 0;
          this.DM.SendAskData(this.NowChannel, (byte) 1, this.DM.SendAskKind, this.NowList[nowTopIndex].TalkID, this.NowList[nowTopIndex].TalkTime);
          this.cScrollRect.SwitchViewState(ListViewState.LVS_WAITLOADING);
          break;
        }
        this.cScrollRect.SwitchViewState(ListViewState.LVS_NORMAL);
        break;
      case ListViewState.LVS_PULL_REFRESH_UP:
        this.ViewStateTextRC.anchoredPosition = new Vector2(30f, -205f);
        this.ViewStateImgRC.anchoredPosition = new Vector2(-75f, -205f);
        ((Transform) this.ViewStateImgRC).localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        this.ViewStateImgRC.sizeDelta = new Vector2(26f, 25f);
        this.ViewStateImg.sprite = this.SArray.m_Sprites[14];
        break;
      case ListViewState.LVS_RELEASE_REFRESH_UP:
        this.ViewStateTextRC.anchoredPosition = new Vector2(30f, -205f);
        this.ViewStateImgRC.anchoredPosition = new Vector2(-75f, -205f);
        ((Transform) this.ViewStateImgRC).localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        this.ViewStateImgRC.sizeDelta = new Vector2(26f, 25f);
        this.ViewStateImg.sprite = this.SArray.m_Sprites[15];
        break;
      case ListViewState.LVS_LOADING_UP:
        this.ViewStateTextRC.anchoredPosition = new Vector2(30f, -205f);
        this.ViewStateImgRC.anchoredPosition = new Vector2(-12f, -205f);
        this.ViewStateImgRC.sizeDelta = new Vector2(26f, 26f);
        this.ViewStateImg.sprite = this.SArray.m_Sprites[16];
        if (this.DM.SendAskKind == -1 && this.DM.MiddleTopIndex != -1)
        {
          this.DM.SendAskKind = 1;
          this.DM.SendAskData(this.NowChannel, (byte) 0, this.DM.SendAskKind, this.NowList[this.DM.MiddleTopIndex].TalkID, this.NowList[this.DM.MiddleTopIndex].TalkTime);
          this.cScrollRect.SwitchViewState(ListViewState.LVS_WAITLOADING_UP);
          break;
        }
        this.cScrollRect.SwitchViewState(ListViewState.LVS_NORMAL);
        break;
    }
  }

  private int FindNowTopIndex()
  {
    if (this.BeginIndex != -1)
    {
      for (int beginIndex = this.BeginIndex; beginIndex <= this.EndIndex && beginIndex >= 0 && beginIndex < this.NowList.Count; ++beginIndex)
      {
        if (this.NowList[beginIndex].TalkID != 0L)
          return beginIndex;
      }
    }
    return -1;
  }

  private void CheckFlashBottomBtn()
  {
    if (this.NewTalkCount > 0)
    {
      if (this.NowChannel == (byte) 0 && this.FlashObj.activeInHierarchy)
        this.FlashObj.SetActive(false);
      if (this.NowChannel != (byte) 1)
        return;
      bool flag = this.Scroll.CheckAtLast();
      if (this.AllianceChatState == (byte) 1 || this.AllianceChatState != (byte) 1 && !flag)
      {
        if (this.FlashObj.activeInHierarchy)
          return;
        this.FlashObj.SetActive(true);
      }
      else
      {
        if (!this.FlashObj.activeInHierarchy)
          return;
        this.FlashObj.SetActive(false);
        if (this.AllianceChatState == (byte) 1 || !flag)
          return;
        this.NewTalkCount = 0;
      }
    }
    else
    {
      if (!this.FlashObj.activeInHierarchy)
        return;
      this.FlashObj.SetActive(false);
    }
  }

  private bool SetChannel(byte Channel)
  {
    if ((int) Channel == (int) this.NowChannel)
      return false;
    this.NowChannel = Channel;
    this.DM.NowChannel = this.NowChannel;
    this.cScrollRect.StopMovement();
    if (this.NowChannel == (byte) 0)
    {
      this.HelpBtnObj.SetActive(false);
      this.PreBtnObject.SetActive(false);
      this.MiddleBtnObject.SetActive(false);
      this.NowList = this.DM.TalkData_Kingdom;
      this.NowHeightList = this.DM.Height_Kingdom;
      this.KindomFlash.SetActive(true);
      this.AllianceFlash.SetActive(false);
      this.DM.SendAskData((byte) 0, (byte) 0, DataID: 0L, DataTime: 0L);
      this.CheckStopViewState();
    }
    else if (this.NowChannel == (byte) 1)
    {
      this.HelpBtnObj.SetActive(false);
      this.PreBtnObject.SetActive(true);
      this.MiddleBtnObject.SetActive(true);
      this.NowList = this.DM.TalkData_Alliance;
      this.NowHeightList = this.DM.Height_Alliance;
      this.KindomFlash.SetActive(false);
      this.AllianceFlash.SetActive(true);
      if (this.DM.NowAlliancePage != -1)
      {
        this.SetAllianceState((byte) this.DM.NowAlliancePage);
      }
      else
      {
        this.SetAllianceState((byte) 0);
        this.DM.NowAlliancePage = 0;
      }
      this.CheckUnRead(false);
      if (this.DM.RoleAlliance.Id > 0U && this.DM.SendAskKind == -1 && this.OpenSendAsk == (byte) 0 && this.DM.AskOldData == (byte) 0)
      {
        this.OpenSendAsk = (byte) 1;
        this.DM.SendAskKind = 4;
        this.DM.AskOldData = (byte) 1;
        this.DM.SendAskData((byte) 1, (byte) 0, this.DM.SendAskKind, 0L, this.DM.LastTime);
      }
    }
    this.RefreshScrollPanel();
    this.CheckAutoScroll();
    this.CheckFlashBottomBtn();
    this.CheckSpeakInKindom();
    this.GM.UpdateChatBox(this.NowChannel != (byte) 0 ? 7 : 6);
    return true;
  }

  private void CheckEmojiAlert()
  {
    if (this.DM.CheckShowOnGroundInfo())
      this.EmojiAleretObj.SetActive(true);
    else
      this.EmojiAleretObj.SetActive(false);
  }

  private void CheckSpeakInKindom()
  {
    if (this.NowChannel == (byte) 0 && this.GM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 8)
    {
      this.mInput.interactable = false;
      this.SendBtn.interactable = false;
      this.EmojiBnt.interactable = false;
      ((Graphic) this.EmojiImg).color = Color.gray;
      ((Graphic) this.SendImg).color = Color.gray;
      this.EmojiAleretObj.SetActive(false);
      UIText component = ((Component) this.mInput.placeholder).GetComponent<UIText>();
      component.text = this.InputErroeCString.ToString();
      ((Graphic) component).color = this.InputErrorColor;
      this.mInput.text = string.Empty;
    }
    else
    {
      this.mInput.interactable = true;
      this.SendBtn.interactable = true;
      this.EmojiBnt.interactable = true;
      ((Graphic) this.EmojiImg).color = Color.white;
      ((Graphic) this.SendImg).color = Color.white;
      this.CheckEmojiAlert();
      UIText component = ((Component) this.mInput.placeholder).GetComponent<UIText>();
      component.text = this.DM.mStringTable.GetStringByID(779U);
      ((Graphic) component).color = this.InputColor;
    }
  }

  private void CheckStopViewState()
  {
    this.cScrollRect.bStopViewState = this.NowChannel != (byte) 1 || this.NowList.Count <= 0;
    if (this.NowChannel == (byte) 1 && this.AllianceChatState == (byte) 1)
      this.cScrollRect.bStopViewState_Up = false;
    else
      this.cScrollRect.bStopViewState_Up = true;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        if (arg2 != (int) this.NowChannel && arg2 != 2)
          break;
        if (this.cScrollRect.ViewState == ListViewState.LVS_WAITLOADING || this.cScrollRect.ViewState == ListViewState.LVS_WAITLOADING_UP)
          this.cScrollRect.SwitchViewState(ListViewState.LVS_NORMAL);
        bool flag1 = this.NowList[this.NowList.Count - 1].PlayID == this.DM.RoleAttr.UserId;
        bool flag2 = this.cScrollRect.IsAtLast();
        if (this.NowChannel == (byte) 0)
        {
          if (this.NowList.Count < 30 && this.DM.KindomRecvType == (byte) 0)
          {
            this.NowIndexList.Add(this.NowList.Count - 1);
            this.Scroll.AddItem(this.GetUnitHeight(this.NowList.Count - 1));
          }
          else
          {
            this.SavePagePara();
            this.RefreshScrollPanel();
            this.CheckAutoScroll();
          }
          if (!flag1 && !flag2)
            break;
          this.Scroll.GoToLast();
          break;
        }
        if (this.NowChannel != (byte) 1)
          break;
        if (this.AllianceChatState == (byte) 1)
        {
          if (flag1)
          {
            this.SetAllianceState((byte) 0);
            this.RefreshScrollPanel();
            this.Scroll.GoToLast();
          }
          ++this.NewTalkCount;
          break;
        }
        int beginIndex = this.BeginIndex;
        int endIndex = this.EndIndex;
        this.CheckBeginEndIndex();
        if (beginIndex != this.BeginIndex || endIndex != this.EndIndex)
        {
          this.NowIndexList.Add(this.NowList.Count - 1);
          this.Scroll.AddItem(this.GetUnitHeight(this.NowList.Count - 1));
        }
        else
          this.RefreshScrollPanel();
        if (flag1 || flag2)
        {
          this.SetAllianceState((byte) 0);
          this.Scroll.GoToLast();
        }
        if (flag2)
          break;
        ++this.NewTalkCount;
        break;
      case 2:
        if (this.cScrollRect.ViewState != ListViewState.LVS_WAITLOADING && this.cScrollRect.ViewState != ListViewState.LVS_WAITLOADING_UP)
          break;
        this.cScrollRect.SwitchViewState(ListViewState.LVS_NORMAL);
        break;
      case 3:
        if (this.NowChannel != (byte) 1)
          break;
        bool flag3 = this.Scroll.CheckAtLast();
        int topIdx = this.Scroll.GetTopIdx();
        if (arg2 == 4 && this.OpenSendAsk != (byte) 1)
          this.SetAllianceState((byte) 1);
        else
          this.SetAllianceState(this.AllianceChatState);
        if (arg2 == 4 && this.OpenSendAsk == (byte) 1)
          this.OpenSendAsk = (byte) 2;
        this.RefreshScrollPanel();
        this.cScrollRect.StopMovement();
        if (arg2 == 4 && this.AllianceChatState == (byte) 2)
        {
          this.Scroll.GoToLast();
          this.SavePagePara();
        }
        else if (arg2 == 0 || arg2 == 2)
        {
          this.Scroll.GoTo(this.DM.ThisTimeCounts - 1);
        }
        else
        {
          switch (arg2)
          {
            case 1:
              this.Scroll.GoTo(topIdx + 1);
              break;
            case 5:
              this.Scroll.GoTo(topIdx);
              break;
            default:
              if (flag3)
              {
                this.Scroll.GoToLast();
                break;
              }
              this.Scroll.GoTo(topIdx);
              break;
          }
        }
        if (this.cScrollRect.ViewState != ListViewState.LVS_WAITLOADING && this.cScrollRect.ViewState != ListViewState.LVS_WAITLOADING_UP)
          break;
        this.cScrollRect.SwitchViewState(ListViewState.LVS_NORMAL);
        break;
      case 4:
        this.OpenSendAsk = (byte) 2;
        this.SetAllianceState((byte) 1);
        this.RefreshScrollPanel();
        break;
      case 5:
        this.SetAllianceState((byte) 0);
        this.RefreshScrollPanel();
        break;
      case 6:
        this.SetAllianceState((byte) 0);
        this.SetChannel((byte) 0);
        break;
      case 7:
        this.CheckUnRead(true);
        break;
      case 8:
        this.OpenSendAsk = (byte) 3;
        ColorBlock colors = this.PreBtn.colors;
        ((ColorBlock) ref colors).normalColor = Color.gray;
        ((ColorBlock) ref colors).highlightedColor = Color.gray;
        this.PreBtn.colors = colors;
        break;
      case 9:
        this.OpenUpdate(arg2);
        break;
      case 10:
        this.CheckTranslated();
        break;
      case 12:
        this.RefreshScrollPanel(false, false);
        break;
      case 13:
        this.CheckSpeakInKindom();
        break;
      case 14:
        if (arg2 != (int) this.NowChannel)
          break;
        this.SavePagePara();
        this.RefreshScrollPanel();
        this.CheckAutoScroll();
        break;
      case 15:
        this.SendEmoji((ushort) arg2);
        break;
      case 16:
        this.CheckEmojiAlert();
        break;
    }
  }

  private float CheckTitleHeight(int Index)
  {
    float num1 = 0.0f;
    byte index1 = 0;
    TitleData recordByKey = this.DM.TitleData.GetRecordByKey((ushort) 0);
    float num2 = -1f;
    float num3 = 0.0f;
    this.NowList[Index].TitleLine = (byte) 1;
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    for (int index2 = 0; index2 < 3; ++index2)
    {
      ushort num4 = 0;
      if (!flag1 && this.NowList[Index].WTitleID == (ushort) 1)
      {
        num4 = (ushort) 1;
        recordByKey = this.DM.TitleDataW.GetRecordByKey((ushort) 1);
        flag1 = true;
      }
      else if (!flag2 && this.NowList[Index].NTitleID == (ushort) 1)
      {
        num4 = (ushort) 1;
        recordByKey = this.DM.TitleDataF.GetRecordByKey((ushort) 1);
        flag2 = true;
      }
      else if (!flag3 && this.NowList[Index].TitleID == (byte) 1)
      {
        num4 = (ushort) 1;
        recordByKey = this.DM.TitleData.GetRecordByKey((ushort) 1);
        flag3 = true;
      }
      else if (!flag1 && this.NowList[Index].WTitleID != (ushort) 0)
      {
        num4 = this.NowList[Index].WTitleID;
        recordByKey = this.DM.TitleDataW.GetRecordByKey(this.NowList[Index].WTitleID);
        flag1 = true;
      }
      else if (!flag2 && this.NowList[Index].NTitleID != (ushort) 0)
      {
        num4 = this.NowList[Index].NTitleID;
        recordByKey = this.DM.TitleDataF.GetRecordByKey(this.NowList[Index].NTitleID);
        flag2 = true;
      }
      else if (!flag3 && this.NowList[Index].TitleID != (byte) 0)
      {
        num4 = (ushort) this.NowList[Index].TitleID;
        recordByKey = this.DM.TitleData.GetRecordByKey((ushort) this.NowList[Index].TitleID);
        flag3 = true;
      }
      if (num4 != (ushort) 0)
      {
        this.TitleText.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID);
        if ((double) num2 > 0.0)
        {
          float preferredWidth = this.TitleText.preferredWidth;
          float num5;
          if ((double) num2 + (double) preferredWidth + 35.0 > 425.0)
          {
            num1 += this.TitleHeight;
            num5 = -1f;
            num3 += this.TitleHeight;
            num2 = preferredWidth;
            ++this.NowList[Index].TitleLine;
          }
          else
          {
            num5 = num2;
            num2 = (float) ((double) num2 + (double) preferredWidth + 35.0);
          }
          this.NowList[Index].TitlePos[(int) index1].x = num5;
          this.NowList[Index].TitlePos[(int) index1].y = num3;
          ++index1;
        }
        else
          num2 = this.TitleText.preferredWidth;
      }
    }
    return num1;
  }

  private float GetUnitHeight(int Index)
  {
    if (Index < 0 || Index >= this.NowList.Count)
      return 0.0f;
    if (this.GM.bAutoTranslate && this.NowList[Index].TalkKind == (byte) 0 && this.NowList[Index].TranslateShow != (byte) 0 && this.NowList[Index].PlayID != this.DM.RoleAttr.UserId && this.NowList[Index].TranslateState == eTranslateState.completed)
    {
      if ((double) this.NowList[Index].TotalHeightT != 0.0)
        return this.NowList[Index].TotalHeightT;
      float num = this.UnitbaseHeight + 10f;
      this.LeftmainText.text = this.NowList[Index].TranslateText.ToString();
      if (this.NowList[Index].TitleID > (byte) 0 || this.NowList[Index].WTitleID > (ushort) 0 || this.NowList[Index].NTitleID > (ushort) 0)
        num = num + this.CheckTitleHeight(Index) + this.LeftmainText.preferredHeight;
      else if ((double) this.LeftmainText.preferredHeight > (double) this.TitleHeight)
        num += this.LeftmainText.preferredHeight - this.TitleHeight;
      float unitHeight = num + 5f;
      this.NowList[Index].TotalHeightT = unitHeight;
      return unitHeight;
    }
    if ((double) this.NowList[Index].TotalHeight != 0.0)
      return this.NowList[Index].TotalHeight;
    float unitHeight1 = this.UnitbaseHeight;
    if (this.NowList[Index].TalkKind == (byte) 0)
    {
      if (this.NowList[Index].FuncKind == (byte) 109)
      {
        EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(this.NowList[Index].EmojiKey);
        unitHeight1 = (this.NowList[Index].TitleID > (byte) 0 || this.NowList[Index].WTitleID > (ushort) 0 || this.NowList[Index].NTitleID > (ushort) 0 ? unitHeight1 + this.CheckTitleHeight(Index) + (float) recordByKey.sizeY : unitHeight1 + ((float) recordByKey.sizeY - this.TitleHeight)) + 5f;
      }
      else
      {
        if (this.GM.bAutoTranslate && this.NowList[Index].PlayID != this.DM.RoleAttr.UserId && this.NowList[Index].TranslateState != eTranslateState.NoNeedTranslate)
          unitHeight1 += 10f;
        this.LeftmainText.text = this.NowList[Index].MainText.ToString();
        if (this.NowList[Index].TitleID > (byte) 0 || this.NowList[Index].WTitleID > (ushort) 0 || this.NowList[Index].NTitleID > (ushort) 0)
          unitHeight1 = unitHeight1 + this.CheckTitleHeight(Index) + this.LeftmainText.preferredHeight;
        else if ((double) this.LeftmainText.preferredHeight > (double) this.TitleHeight)
          unitHeight1 += this.LeftmainText.preferredHeight - this.TitleHeight;
        unitHeight1 += 5f;
      }
    }
    else if (this.NowList[Index].TalkKind == (byte) 1 || this.NowList[Index].TalkKind == (byte) 2)
      unitHeight1 = 49f;
    else if (this.NowList[Index].TalkKind >= (byte) 3 && this.NowList[Index].TalkKind <= (byte) 11)
    {
      this.LeftmainText.text = this.NowList[Index].MainText.ToString();
      unitHeight1 = this.LeftmainText.preferredHeight + 30f;
    }
    this.NowList[Index].TotalHeight = unitHeight1;
    return unitHeight1;
  }

  private void RefreshScrollPanel(bool GoToTop = true, bool bStopMove = true)
  {
    this.NowHeightList.Clear();
    this.NowIndexList.Clear();
    if (this.NowChannel == (byte) 0)
    {
      this.BeginIndex = 0;
      this.EndIndex = this.NowList.Count - 1;
      for (int Index = 0; Index < this.NowList.Count; ++Index)
      {
        this.NowHeightList.Add(this.GetUnitHeight(Index));
        this.NowIndexList.Add(Index);
      }
    }
    else
    {
      this.CheckBeginEndIndex();
      if (this.BeginIndex != -1)
      {
        for (int beginIndex = this.BeginIndex; beginIndex < this.EndIndex + 1; ++beginIndex)
        {
          if (beginIndex >= 0 && beginIndex < this.NowList.Count && !this.DM.CheckHideTalk(this.NowList[beginIndex]))
          {
            this.NowHeightList.Add(this.GetUnitHeight(beginIndex));
            this.NowIndexList.Add(beginIndex);
          }
        }
      }
    }
    this.Scroll.AddNewDataHeight(this.NowHeightList, GoToTop, bStopMove);
  }

  private void InputEnd(string tmpStr, eTextCheck State = eTextCheck.Text_None)
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
        this.SendChat(tmpStr, State);
    }
  }

  private void SendChat(string tmpStr, eTextCheck State = eTextCheck.Text_None)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_SENDCHAT;
    char[] charArray = tmpStr.ToCharArray();
    if (this.DM.m_BannedWord != null)
      this.DM.m_BannedWord.CheckBannedWord(charArray);
    byte[] bytes = Encoding.UTF8.GetBytes(charArray, 0, tmpStr.Length);
    if (bytes.Length <= 0)
      return;
    messagePacket.AddSeqId();
    messagePacket.Add(this.NowChannel);
    messagePacket.Add(this.NowInputType);
    if (this.DM.ServerVersionMajor != (byte) 0)
      messagePacket.Add((byte) State);
    messagePacket.Add((ushort) bytes.Length);
    messagePacket.Add(bytes);
    messagePacket.Send();
    this.DM.sendTimer = 3f;
    this.NowInputType = (byte) 0;
    this.mInput.text = string.Empty;
    if (this.NowChannel != (byte) 1)
      return;
    AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.CHAT_INGUILD);
  }

  private void SendEmoji(ushort EmojiKey)
  {
    if ((double) this.DM.sendTimer > 0.0)
    {
      this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(658U), (ushort) byte.MaxValue);
    }
    else
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_SENDCHAT;
      EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(EmojiKey);
      messagePacket.AddSeqId();
      messagePacket.Add(this.NowChannel);
      messagePacket.Add((byte) 109);
      if (this.DM.ServerVersionMajor != (byte) 0)
        messagePacket.Add((byte) 0);
      messagePacket.Add((ushort) 4);
      messagePacket.Add(EmojiKey);
      messagePacket.Add(recordByKey.IconID);
      messagePacket.Send();
      this.DM.sendTimer = 3f;
      if (this.NowChannel != (byte) 1)
        return;
      AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.CHAT_INGUILD);
    }
  }

  private void CheckTranslated()
  {
    for (int index = 0; index < 13; ++index)
    {
      if (this.bFindScrollComp[index] && this.Scroll_1_Comp[index].ItemGO.activeInHierarchy && this.Scroll_1_Comp[index].TalkDataIndex != -1 && this.NowList[this.Scroll_1_Comp[index].TalkDataIndex].TalkID == this.GM.TranslateData.TalkID)
      {
        this.Scroll_1_Comp[index].TranslateImgGO.SetActive(false);
        this.Scroll_1_Comp[index].TranslateBtnGO.SetActive(true);
        this.RefreshScrollPanel(false, false);
        break;
      }
    }
    for (int index = 0; index < 13; ++index)
    {
      if (this.bFindScrollComp[index] && this.Scroll_1_Comp[index].ItemGO.activeInHierarchy && this.Scroll_1_Comp[index].TalkDataIndex != -1)
      {
        int talkDataIndex = this.Scroll_1_Comp[index].TalkDataIndex;
        if (this.NowList[talkDataIndex].TranslateState != eTranslateState.Translation)
        {
          if ((this.NowList[talkDataIndex].PlayID != this.DM.RoleAttr.UserId ? 0 : 1) == 0 && this.GM.bAutoTranslate && this.NowList[talkDataIndex].TranslateState != eTranslateState.NoNeedTranslate)
            this.Scroll_1_Comp[index].TranslateBtnGO.SetActive(true);
          this.Scroll_1_Comp[index].TranslateImgGO.SetActive(false);
        }
      }
    }
  }

  private void CheckTranslateNext()
  {
    if (!this.GM.bAutoTranslate || this.GM.bWaitTranslate)
      return;
    for (int index = 0; index < 13; ++index)
    {
      if (this.bFindScrollComp[index] && this.Scroll_1_Comp[index].ItemGO.activeInHierarchy && this.Scroll_1_Comp[index].TalkDataIndex != -1)
      {
        int talkDataIndex = this.Scroll_1_Comp[index].TalkDataIndex;
        if (this.NowList[talkDataIndex].TranslateState == eTranslateState.Untranslated && this.NowList[talkDataIndex].TalkKind == (byte) 0 && this.NowList[talkDataIndex].PlayID != this.DM.RoleAttr.UserId && this.GM.TransLatebyIndex(this.NowList[talkDataIndex]))
        {
          this.Scroll_1_Comp[index].TranslateImgGO.SetActive(true);
          this.Scroll_1_Comp[index].TranslateBtnGO.SetActive(false);
          break;
        }
      }
    }
  }

  public byte GetBackImageIndex(int dataIdx)
  {
    if (this.NowChannel == (byte) 0 && this.NowList[dataIdx].KingdomID != (ushort) 0 && (int) DataManager.MapDataController.OtherKingdomData.kingdomID != (int) ActivityManager.Instance.KOWKingdomID && (int) DataManager.MapDataController.kingdomData.kingdomID != (int) this.NowList[dataIdx].KingdomID || this.NowList[dataIdx].SpecialBlockID == (byte) 1)
      return 11;
    if (this.NowList[dataIdx].SpecialBlockID == (byte) 2)
      return 10;
    if (this.NowList[dataIdx].SpecialBlockID == (byte) 3 || this.NowList[dataIdx].SpecialBlockID == (byte) 7 || this.NowList[dataIdx].SpecialBlockID == (byte) 8)
      return 9;
    if (this.NowList[dataIdx].SpecialBlockID == (byte) 4 || this.NowList[dataIdx].SpecialBlockID == (byte) 9)
      return 8;
    return this.NowList[dataIdx].SpecialBlockID == (byte) 5 ? (byte) 7 : (byte) 6;
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelId != 1 || panelObjectIdx >= 13)
      return;
    float num1 = 0.0f;
    if (!this.bFindScrollComp[panelObjectIdx])
    {
      this.bFindScrollComp[panelObjectIdx] = true;
      Transform child1 = item.transform.GetChild(1);
      this.Scroll_1_Comp[panelObjectIdx].TalkDataIndex = -1;
      this.Scroll_1_Comp[panelObjectIdx].ItemGO = item.gameObject;
      this.Scroll_1_Comp[panelObjectIdx].Base0RC = item.transform.GetChild(0).GetComponent<RectTransform>();
      this.Scroll_1_Comp[panelObjectIdx].Base1RC = child1.GetComponent<RectTransform>();
      this.Scroll_1_Comp[panelObjectIdx].VIPText = child1.GetChild(7).GetComponent<UIText>();
      this.VIPCStr[panelObjectIdx] = StringManager.Instance.SpawnString(10);
      this.Scroll_1_Comp[panelObjectIdx].GuildRankImg = child1.GetChild(11).GetComponent<Image>();
      this.Scroll_1_Comp[panelObjectIdx].PlayerName = child1.GetChild(3).GetComponent<UIText>();
      this.Scroll_1_Comp[panelObjectIdx].PlayerName.SetCheckArabic(true);
      this.NameCStr[panelObjectIdx] = StringManager.Instance.SpawnString(80);
      this.Scroll_1_Comp[panelObjectIdx].ChairmanT = new Transform[3];
      this.Scroll_1_Comp[panelObjectIdx].ChairmanImg = new Image[3];
      this.Scroll_1_Comp[panelObjectIdx].TitleNameT = new Transform[3];
      this.Scroll_1_Comp[panelObjectIdx].TitleNameText = new UIText[3];
      this.Scroll_1_Comp[panelObjectIdx].ChairmanT[0] = child1.GetChild(2);
      this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[0] = this.Scroll_1_Comp[panelObjectIdx].ChairmanT[0].GetComponent<Image>();
      this.Scroll_1_Comp[panelObjectIdx].ChairmanT[1] = child1.GetChild(12);
      this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[1] = this.Scroll_1_Comp[panelObjectIdx].ChairmanT[1].GetComponent<Image>();
      this.Scroll_1_Comp[panelObjectIdx].ChairmanT[2] = child1.GetChild(16);
      this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[2] = this.Scroll_1_Comp[panelObjectIdx].ChairmanT[2].GetComponent<Image>();
      this.Scroll_1_Comp[panelObjectIdx].TitleNameT[0] = child1.GetChild(4);
      this.Scroll_1_Comp[panelObjectIdx].TitleNameText[0] = this.Scroll_1_Comp[panelObjectIdx].TitleNameT[0].GetComponent<UIText>();
      this.Scroll_1_Comp[panelObjectIdx].TitleNameT[1] = child1.GetChild(13);
      this.Scroll_1_Comp[panelObjectIdx].TitleNameText[1] = this.Scroll_1_Comp[panelObjectIdx].TitleNameT[1].GetComponent<UIText>();
      this.Scroll_1_Comp[panelObjectIdx].TitleNameT[2] = child1.GetChild(15);
      this.Scroll_1_Comp[panelObjectIdx].TitleNameText[2] = this.Scroll_1_Comp[panelObjectIdx].TitleNameT[2].GetComponent<UIText>();
      this.Scroll_1_Comp[panelObjectIdx].TranslateImgGO = child1.GetChild(8).gameObject;
      this.Scroll_1_Comp[panelObjectIdx].TranslateText = child1.GetChild(9).GetComponent<UIText>();
      this.Scroll_1_Comp[panelObjectIdx].TranslateText.font = this.m_Font;
      this.Scroll_1_Comp[panelObjectIdx].TranslateBtnGO = child1.GetChild(10).gameObject;
      UIButton component = this.Scroll_1_Comp[panelObjectIdx].TranslateBtnGO.transform.GetComponent<UIButton>();
      component.m_Handler = (IUIButtonClickHandler) this;
      component.m_BtnID2 = panelObjectIdx;
      Transform child2 = child1.GetChild(5);
      this.Scroll_1_Comp[panelObjectIdx].MainRC = child2.GetComponent<RectTransform>();
      this.Scroll_1_Comp[panelObjectIdx].MainText = child2.GetComponent<UIText>();
      this.Scroll_1_Comp[panelObjectIdx].MainText.SetCheckArabic(true);
      this.Scroll_1_Comp[panelObjectIdx].BackImgRC = child1.GetChild(0).GetComponent<RectTransform>();
      this.Scroll_1_Comp[panelObjectIdx].BackImg = child1.GetChild(0).GetComponent<Image>();
      this.Scroll_1_Comp[panelObjectIdx].TimeText = child1.GetChild(6).GetComponent<UIText>();
      this.Scroll_1_Comp[panelObjectIdx].Base2GO = item.transform.GetChild(2).gameObject;
      this.Scroll_1_Comp[panelObjectIdx].Base2Text = item.transform.GetChild(2).GetChild(2).GetComponent<UIText>();
      this.Scroll_1_Comp[panelObjectIdx].Base2Text.font = this.m_Font;
      this.Scroll_1_Comp[panelObjectIdx].Base3GO = item.transform.GetChild(3).GetComponent<RectTransform>();
      this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC = item.transform.GetChild(3).GetChild(0).GetComponent<RectTransform>();
      this.Scroll_1_Comp[panelObjectIdx].Base3Text = item.transform.GetChild(3).GetChild(1).GetComponent<UIText>();
      this.Scroll_1_Comp[panelObjectIdx].Base3Text.font = this.m_Font;
      this.Scroll_1_Comp[panelObjectIdx].Base3TimeText = item.transform.GetChild(3).GetChild(2).GetComponent<UIText>();
      this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.font = this.m_Font;
      this.OriginalColor = ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).color;
      this.TimeStr[panelObjectIdx] = StringManager.Instance.SpawnString(20);
      this.LanguageStr[panelObjectIdx] = StringManager.Instance.SpawnString(150);
      this.Scroll_1_Comp[panelObjectIdx].EmojiRC = child1.GetChild(14).GetComponent<RectTransform>();
      if (this.GM.IsArabic)
        ((Transform) this.Scroll_1_Comp[panelObjectIdx].EmojiRC).localScale = new Vector3(-1f, 1f, 1f);
    }
    if (dataIdx < 0 || dataIdx >= this.NowIndexList.Count)
      return;
    dataIdx = this.NowIndexList[dataIdx];
    if (dataIdx < 0 || dataIdx >= this.NowList.Count)
      return;
    this.Scroll_1_Comp[panelObjectIdx].TalkDataIndex = -1;
    if (this.NowList[dataIdx].TalkKind == (byte) 0)
    {
      this.Scroll_1_Comp[panelObjectIdx].TalkDataIndex = dataIdx;
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base0RC).gameObject.SetActive(true);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base1RC).gameObject.SetActive(true);
      this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base3GO).gameObject.SetActive(false);
      int num2 = this.NowList[dataIdx].PlayID != this.DM.RoleAttr.UserId ? 0 : 1;
      this.VIPCStr[panelObjectIdx].Length = 0;
      StringManager.IntToStr(this.VIPCStr[panelObjectIdx], (long) this.NowList[dataIdx].VIPRank);
      this.Scroll_1_Comp[panelObjectIdx].VIPText.text = this.VIPCStr[panelObjectIdx].ToString();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].VIPText).SetVerticesDirty();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].VIPText).SetLayoutDirty();
      this.Scroll_1_Comp[panelObjectIdx].VIPText.cachedTextGenerator.Invalidate();
      if (this.NowList[dataIdx].AllyRank > (byte) 0)
      {
        ((Component) this.Scroll_1_Comp[panelObjectIdx].GuildRankImg).gameObject.SetActive(true);
        this.Scroll_1_Comp[panelObjectIdx].GuildRankImg.sprite = this.SArray.m_Sprites[(int) this.NowList[dataIdx].AllyRank + 16];
        Vector2 pos = new Vector2(113f, -7f);
        ((Graphic) this.Scroll_1_Comp[panelObjectIdx].PlayerName).rectTransform.sizeDelta = new Vector2(385f, 25f);
        Vector2 vector2 = this.Scroll_1_Comp[panelObjectIdx].PlayerName.ArabicFixPos(pos);
        ((Graphic) this.Scroll_1_Comp[panelObjectIdx].PlayerName).rectTransform.anchoredPosition = vector2;
      }
      else
      {
        ((Component) this.Scroll_1_Comp[panelObjectIdx].GuildRankImg).gameObject.SetActive(false);
        Vector2 pos = new Vector2(78f, -7f);
        ((Graphic) this.Scroll_1_Comp[panelObjectIdx].PlayerName).rectTransform.sizeDelta = new Vector2(410f, 25f);
        Vector2 vector2 = this.Scroll_1_Comp[panelObjectIdx].PlayerName.ArabicFixPos(pos);
        ((Graphic) this.Scroll_1_Comp[panelObjectIdx].PlayerName).rectTransform.anchoredPosition = vector2;
      }
      if (this.NowList[dataIdx].NickNameText.Length > 0)
      {
        ushort kingdomId = this.NowChannel != (byte) 0 || this.NowList[dataIdx].KingdomID <= (ushort) 0 || (int) this.NowList[dataIdx].KingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID ? (ushort) 0 : this.NowList[dataIdx].KingdomID;
        GameConstants.FormatRoleName(this.NameCStr[panelObjectIdx], this.NowList[dataIdx].PlayerName, this.NowList[dataIdx].TitleName, this.NowList[dataIdx].NickNameText, (byte) 0, kingdomId, NickColor: "<color=#005EA5>");
        this.Scroll_1_Comp[panelObjectIdx].PlayerName.text = this.NameCStr[panelObjectIdx].ToString();
        this.Scroll_1_Comp[panelObjectIdx].PlayerName.SetAllDirty();
        this.Scroll_1_Comp[panelObjectIdx].PlayerName.cachedTextGenerator.Invalidate();
      }
      else
        this.Scroll_1_Comp[panelObjectIdx].PlayerName.text = this.NowList[dataIdx].ShowName.ToString();
      this.Scroll_1_Comp[panelObjectIdx].ChairmanT[0].gameObject.SetActive(false);
      this.Scroll_1_Comp[panelObjectIdx].TitleNameT[0].gameObject.SetActive(false);
      this.Scroll_1_Comp[panelObjectIdx].ChairmanT[1].gameObject.SetActive(false);
      this.Scroll_1_Comp[panelObjectIdx].TitleNameT[1].gameObject.SetActive(false);
      this.Scroll_1_Comp[panelObjectIdx].ChairmanT[2].gameObject.SetActive(false);
      this.Scroll_1_Comp[panelObjectIdx].TitleNameT[2].gameObject.SetActive(false);
      byte index1 = 0;
      eTitleKind kind = eTitleKind.KvkTitle;
      bool flag1 = false;
      bool flag2 = false;
      bool flag3 = false;
      TitleData recordByKey1 = this.DM.TitleData.GetRecordByKey((ushort) 0);
      for (int index2 = 0; index2 < 3; ++index2)
      {
        ushort num3 = 0;
        if (!flag1 && this.NowList[dataIdx].WTitleID == (ushort) 1)
        {
          kind = eTitleKind.WorldTitle;
          num3 = (ushort) 1;
          recordByKey1 = this.DM.TitleDataW.GetRecordByKey((ushort) 1);
          flag1 = true;
        }
        else if (!flag2 && this.NowList[dataIdx].NTitleID == (ushort) 1)
        {
          kind = eTitleKind.NobilityTitle;
          num3 = (ushort) 1;
          recordByKey1 = this.DM.TitleDataF.GetRecordByKey((ushort) 1);
          flag2 = true;
        }
        else if (!flag3 && this.NowList[dataIdx].TitleID == (byte) 1)
        {
          kind = eTitleKind.KvkTitle;
          num3 = (ushort) 1;
          recordByKey1 = this.DM.TitleData.GetRecordByKey((ushort) 1);
          flag3 = true;
        }
        else if (!flag1 && this.NowList[dataIdx].WTitleID != (ushort) 0)
        {
          kind = eTitleKind.WorldTitle;
          num3 = this.NowList[dataIdx].WTitleID;
          recordByKey1 = this.DM.TitleDataW.GetRecordByKey(this.NowList[dataIdx].WTitleID);
          flag1 = true;
        }
        else if (!flag2 && this.NowList[dataIdx].NTitleID != (ushort) 0)
        {
          kind = eTitleKind.NobilityTitle;
          num3 = this.NowList[dataIdx].NTitleID;
          recordByKey1 = this.DM.TitleDataF.GetRecordByKey(this.NowList[dataIdx].NTitleID);
          flag2 = true;
        }
        else if (!flag3 && this.NowList[dataIdx].TitleID != (byte) 0)
        {
          kind = eTitleKind.KvkTitle;
          num3 = (ushort) this.NowList[dataIdx].TitleID;
          recordByKey1 = this.DM.TitleData.GetRecordByKey((ushort) this.NowList[dataIdx].TitleID);
          flag3 = true;
        }
        if (num3 != (ushort) 0)
        {
          this.Scroll_1_Comp[panelObjectIdx].ChairmanT[(int) index1].gameObject.SetActive(true);
          this.Scroll_1_Comp[panelObjectIdx].TitleNameT[(int) index1].gameObject.SetActive(true);
          this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[(int) index1].sprite = this.GM.LoadTitleSprite(recordByKey1.IconID, kind);
          ((MaskableGraphic) this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[(int) index1]).material = this.GM.GetTitleMaterial();
          this.Scroll_1_Comp[panelObjectIdx].TitleNameText[(int) index1].text = this.DM.mStringTable.GetStringByID((uint) recordByKey1.StringID);
          if (index1 > (byte) 0)
          {
            if ((double) this.NowList[dataIdx].TitlePos[(int) index1 - 1].x < 0.0)
            {
              ((Graphic) this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[(int) index1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[0]).rectTransform.anchoredPosition.x, ((Graphic) this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[0]).rectTransform.anchoredPosition.y - this.NowList[dataIdx].TitlePos[(int) index1 - 1].y);
              ((Graphic) this.Scroll_1_Comp[panelObjectIdx].TitleNameText[(int) index1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Scroll_1_Comp[panelObjectIdx].TitleNameText[0]).rectTransform.anchoredPosition.x, ((Graphic) this.Scroll_1_Comp[panelObjectIdx].TitleNameText[0]).rectTransform.anchoredPosition.y - this.NowList[dataIdx].TitlePos[(int) index1 - 1].y);
            }
            else
            {
              ((Graphic) this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[(int) index1]).rectTransform.anchoredPosition = new Vector2((float) ((double) ((Graphic) this.Scroll_1_Comp[panelObjectIdx].TitleNameText[0]).rectTransform.anchoredPosition.x + (double) this.NowList[dataIdx].TitlePos[(int) index1 - 1].x + 5.0), ((Graphic) this.Scroll_1_Comp[panelObjectIdx].TitleNameText[0]).rectTransform.anchoredPosition.y - this.NowList[dataIdx].TitlePos[(int) index1 - 1].y);
              ((Graphic) this.Scroll_1_Comp[panelObjectIdx].TitleNameText[(int) index1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[(int) index1]).rectTransform.anchoredPosition.x + 30f, ((Graphic) this.Scroll_1_Comp[panelObjectIdx].ChairmanImg[(int) index1]).rectTransform.anchoredPosition.y);
            }
          }
          ++index1;
        }
      }
      bool flag4 = this.NowList[dataIdx].FuncKind == (byte) 109;
      bool flag5 = num2 == 0 && this.GM.bAutoTranslate && this.NowList[dataIdx].TranslateState != eTranslateState.NoNeedTranslate;
      float num4 = 0.0f;
      if (flag5)
      {
        num4 = 10f;
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
      float y;
      if (flag4)
      {
        ((Component) this.Scroll_1_Comp[panelObjectIdx].MainText).gameObject.SetActive(false);
        ((Component) this.Scroll_1_Comp[panelObjectIdx].EmojiRC).gameObject.SetActive(true);
        EmojiData recordByKey2 = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(this.NowList[dataIdx].EmojiKey);
        y = (float) recordByKey2.sizeY;
        if (this.Scroll_1_Comp[panelObjectIdx].Emoji != null)
        {
          this.GM.pushEmojiIcon(this.Scroll_1_Comp[panelObjectIdx].Emoji);
          this.Scroll_1_Comp[panelObjectIdx].Emoji = (EmojiUnit) null;
        }
        this.Scroll_1_Comp[panelObjectIdx].Emoji = this.GM.pullEmojiIcon(recordByKey2.IconID, recordByKey2.KeyFrame);
        this.Scroll_1_Comp[panelObjectIdx].Emoji.EmojiTransform.SetParent((Transform) this.Scroll_1_Comp[panelObjectIdx].EmojiRC, false);
        if ((double) y <= 70.0)
          ((RectTransform) this.Scroll_1_Comp[panelObjectIdx].Emoji.EmojiTransform).anchoredPosition = Vector2.zero;
        else
          ((RectTransform) this.Scroll_1_Comp[panelObjectIdx].Emoji.EmojiTransform).anchoredPosition = new Vector2(0.0f, (float) -(((double) y - 70.0) / 2.0));
      }
      else
      {
        ((Component) this.Scroll_1_Comp[panelObjectIdx].MainText).gameObject.SetActive(true);
        ((Component) this.Scroll_1_Comp[panelObjectIdx].EmojiRC).gameObject.SetActive(false);
        if (flag5 && this.NowList[dataIdx].TranslateShow != (byte) 0 && this.NowList[dataIdx].TranslateState == eTranslateState.completed)
          this.Scroll_1_Comp[panelObjectIdx].MainText.text = this.NowList[dataIdx].TranslateText.ToString();
        else
          this.Scroll_1_Comp[panelObjectIdx].MainText.SetText(this.NowList[dataIdx].MainText.ToString(), (eTextCheck) this.NowList[dataIdx].bHaveArabic);
        ((Graphic) this.Scroll_1_Comp[panelObjectIdx].MainText).SetLayoutDirty();
        this.Scroll_1_Comp[panelObjectIdx].MainText.cachedTextGeneratorForLayout.Invalidate();
        y = this.Scroll_1_Comp[panelObjectIdx].MainText.preferredHeight;
      }
      this.Scroll_1_Comp[panelObjectIdx].MainRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].MainRC.sizeDelta.x, y);
      if (index1 > (byte) 0)
      {
        num1 = y + this.TitleHeight * (float) ((int) this.NowList[dataIdx].TitleLine - 1);
        this.Scroll_1_Comp[panelObjectIdx].MainRC.anchoredPosition = new Vector2(this.Scroll_1_Comp[panelObjectIdx].MainRC.anchoredPosition.x, (float) (-38.0 - (double) this.TitleHeight * (double) this.NowList[dataIdx].TitleLine));
      }
      else
      {
        this.Scroll_1_Comp[panelObjectIdx].MainRC.anchoredPosition = new Vector2(this.Scroll_1_Comp[panelObjectIdx].MainRC.anchoredPosition.x, -38f);
        if ((double) y > (double) this.TitleHeight)
          num1 = y - this.TitleHeight;
      }
      this.Scroll_1_Comp[panelObjectIdx].BackImg.sprite = this.SArray.m_Sprites[(int) this.GetBackImageIndex(dataIdx)];
      if (flag4)
        this.Scroll_1_Comp[panelObjectIdx].EmojiRC.anchoredPosition = new Vector2(50.4f, this.Scroll_1_Comp[panelObjectIdx].MainRC.anchoredPosition.y) + (!this.GM.IsArabic ? Vector2.zero : new Vector2(70f, 0.0f));
      float num5 = num1 + num4;
      this.Scroll_1_Comp[panelObjectIdx].Base1RC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base1RC.sizeDelta.x, this.UnitbaseHeight + num5);
      this.Scroll_1_Comp[panelObjectIdx].BackImgRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].BackImgRC.sizeDelta.x, this.UnitbaseHeight + num5);
      if (num2 == 0)
      {
        this.Scroll_1_Comp[panelObjectIdx].Base1RC.anchoredPosition = new Vector2(99f, 0.0f);
        this.Scroll_1_Comp[panelObjectIdx].BackImgRC.anchoredPosition = new Vector2(0.0f, 0.0f);
        ((Transform) this.Scroll_1_Comp[panelObjectIdx].BackImgRC).localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
      }
      else
      {
        this.Scroll_1_Comp[panelObjectIdx].Base1RC.anchoredPosition = new Vector2(2f, 0.0f);
        this.Scroll_1_Comp[panelObjectIdx].BackImgRC.anchoredPosition = new Vector2(638f, 0.0f);
        ((Transform) this.Scroll_1_Comp[panelObjectIdx].BackImgRC).localRotation = new Quaternion(0.0f, -180f, 0.0f, 0.0f);
      }
      this.Scroll_1_Comp[panelObjectIdx].Base0RC.anchoredPosition = num2 != 0 ? new Vector2(638f, -2f) : new Vector2(28f, -2f);
      GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(0), eHeroOrItem.Hero, this.NowList[dataIdx].PlayerPicID, (byte) 11, (byte) 0);
      this.SetSBTime(this.DM.ServerTime - this.NowList[dataIdx].TalkTime, this.TimeStr[panelObjectIdx]);
      this.Scroll_1_Comp[panelObjectIdx].TimeText.text = this.TimeStr[panelObjectIdx].ToString();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].TimeText).SetVerticesDirty();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].TimeText).SetLayoutDirty();
      this.Scroll_1_Comp[panelObjectIdx].TimeText.cachedTextGenerator.Invalidate();
    }
    else if (this.NowList[dataIdx].TalkKind == (byte) 1)
    {
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base0RC).gameObject.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base1RC).gameObject.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base3GO).gameObject.SetActive(false);
      this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(true);
      this.Scroll_1_Comp[panelObjectIdx].Base2Text.text = this.DM.mStringTable.GetStringByID(305U);
    }
    else if (this.NowList[dataIdx].TalkKind == (byte) 2)
    {
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base0RC).gameObject.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base1RC).gameObject.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base3GO).gameObject.SetActive(false);
      this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(true);
      this.Scroll_1_Comp[panelObjectIdx].Base2Text.text = this.DM.mStringTable.GetStringByID(306U);
    }
    else if (this.NowList[dataIdx].TalkKind == (byte) 3)
    {
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base0RC).gameObject.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base1RC).gameObject.SetActive(false);
      this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base3GO).gameObject.SetActive(true);
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).color = this.OriginalColor;
      this.Scroll_1_Comp[panelObjectIdx].Base3Text.text = this.NowList[dataIdx].MainText.ToString();
      float y = this.Scroll_1_Comp[panelObjectIdx].Base3Text.preferredHeight + 18f;
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).rectTransform.sizeDelta = new Vector2(((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).rectTransform.sizeDelta.x, y);
      this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta.x, y);
      this.SetSBTime(this.DM.ServerTime - this.NowList[dataIdx].TalkTime, this.TimeStr[panelObjectIdx]);
      this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.text = this.TimeStr[panelObjectIdx].ToString();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3TimeText).SetVerticesDirty();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3TimeText).SetLayoutDirty();
      this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.cachedTextGenerator.Invalidate();
    }
    else if (this.NowList[dataIdx].TalkKind == (byte) 4)
    {
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base0RC).gameObject.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base1RC).gameObject.SetActive(false);
      this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base3GO).gameObject.SetActive(true);
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).color = Color.green;
      this.Scroll_1_Comp[panelObjectIdx].Base3Text.text = this.NowList[dataIdx].MainText.ToString();
      float y = this.Scroll_1_Comp[panelObjectIdx].Base3Text.preferredHeight + 18f;
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).rectTransform.sizeDelta = new Vector2(((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).rectTransform.sizeDelta.x, y);
      this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta.x, y);
      this.SetSBTime(this.DM.ServerTime - this.NowList[dataIdx].TalkTime, this.TimeStr[panelObjectIdx]);
      this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.text = this.TimeStr[panelObjectIdx].ToString();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3TimeText).SetVerticesDirty();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3TimeText).SetLayoutDirty();
      this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.cachedTextGenerator.Invalidate();
    }
    else if (this.NowList[dataIdx].TalkKind == (byte) 5)
    {
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base0RC).gameObject.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base1RC).gameObject.SetActive(false);
      this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base3GO).gameObject.SetActive(true);
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).color = Color.green;
      this.Scroll_1_Comp[panelObjectIdx].Base3Text.text = this.NowList[dataIdx].MainText.ToString();
      float y = this.Scroll_1_Comp[panelObjectIdx].Base3Text.preferredHeight + 18f;
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).rectTransform.sizeDelta = new Vector2(((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).rectTransform.sizeDelta.x, y);
      this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta.x, y);
      this.SetSBTime(this.DM.ServerTime - this.NowList[dataIdx].TalkTime, this.TimeStr[panelObjectIdx]);
      this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.text = this.TimeStr[panelObjectIdx].ToString();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3TimeText).SetVerticesDirty();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3TimeText).SetLayoutDirty();
      this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.cachedTextGenerator.Invalidate();
    }
    else if (this.NowList[dataIdx].TalkKind == (byte) 6 || this.NowList[dataIdx].TalkKind == (byte) 7)
    {
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base0RC).gameObject.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base1RC).gameObject.SetActive(false);
      this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base3GO).gameObject.SetActive(true);
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).color = Color.green;
      this.Scroll_1_Comp[panelObjectIdx].Base3Text.text = this.NowList[dataIdx].MainText.ToString();
      float y = this.Scroll_1_Comp[panelObjectIdx].Base3Text.preferredHeight + 18f;
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).rectTransform.sizeDelta = new Vector2(((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).rectTransform.sizeDelta.x, y);
      this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta.x, y);
      this.SetSBTime(this.DM.ServerTime - this.NowList[dataIdx].TalkTime, this.TimeStr[panelObjectIdx]);
      this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.text = this.TimeStr[panelObjectIdx].ToString();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3TimeText).SetVerticesDirty();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3TimeText).SetLayoutDirty();
      this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.cachedTextGenerator.Invalidate();
    }
    else if (this.NowList[dataIdx].TalkKind == (byte) 8)
    {
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base0RC).gameObject.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base1RC).gameObject.SetActive(false);
      this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base3GO).gameObject.SetActive(true);
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).color = this.OriginalColor;
      this.Scroll_1_Comp[panelObjectIdx].Base3Text.text = this.NowList[dataIdx].MainText.ToString();
      float y = this.Scroll_1_Comp[panelObjectIdx].Base3Text.preferredHeight + 18f;
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).rectTransform.sizeDelta = new Vector2(((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).rectTransform.sizeDelta.x, y);
      this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta.x, y);
      this.SetSBTime(this.DM.ServerTime - this.NowList[dataIdx].TalkTime, this.TimeStr[panelObjectIdx]);
      this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.text = this.TimeStr[panelObjectIdx].ToString();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3TimeText).SetVerticesDirty();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3TimeText).SetLayoutDirty();
      this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.cachedTextGenerator.Invalidate();
    }
    else
    {
      if (this.NowList[dataIdx].TalkKind < (byte) 9 || this.NowList[dataIdx].TalkKind > (byte) 11)
        return;
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base0RC).gameObject.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base1RC).gameObject.SetActive(false);
      this.Scroll_1_Comp[panelObjectIdx].Base2GO.SetActive(false);
      ((Component) this.Scroll_1_Comp[panelObjectIdx].Base3GO).gameObject.SetActive(true);
      if (this.NowList[dataIdx].TalkKind == (byte) 10 || this.NowList[dataIdx].TalkKind == (byte) 11)
        ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).color = (Color) new Color32(byte.MaxValue, (byte) 238, (byte) 158, byte.MaxValue);
      else
        ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).color = (Color) new Color32(byte.MaxValue, (byte) 235, (byte) 4, byte.MaxValue);
      this.Scroll_1_Comp[panelObjectIdx].Base3Text.text = this.NowList[dataIdx].MainText.ToString();
      float y = this.Scroll_1_Comp[panelObjectIdx].Base3Text.preferredHeight + 18f;
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).rectTransform.sizeDelta = new Vector2(((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3Text).rectTransform.sizeDelta.x, y);
      this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta = new Vector2(this.Scroll_1_Comp[panelObjectIdx].Base3BackImgRC.sizeDelta.x, y);
      this.SetSBTime(this.DM.ServerTime - this.NowList[dataIdx].TalkTime, this.TimeStr[panelObjectIdx]);
      this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.text = this.TimeStr[panelObjectIdx].ToString();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3TimeText).SetVerticesDirty();
      ((Graphic) this.Scroll_1_Comp[panelObjectIdx].Base3TimeText).SetLayoutDirty();
      this.Scroll_1_Comp[panelObjectIdx].Base3TimeText.cachedTextGenerator.Invalidate();
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    if (panelId == 1)
    {
      int nowIndex = this.NowIndexList[dataIndex];
      if (this.NowList[nowIndex].TalkKind == (byte) 0)
      {
        int count = this.NowList.Count;
        if (count <= 0 || nowIndex >= count)
          return;
        this.ClickChatData = this.NowList[nowIndex];
        this.ClickChatPlayID = this.ClickChatData.PlayID;
        this.PlayerNameText.text = this.ClickChatData.PlayerName.ToString();
        if (BattleController.IsGambleMode)
          ((Graphic) this.PlayerNameText).color = Color.gray;
        else
          ((Graphic) this.PlayerNameText).color = Color.white;
        if (this.ClickChatData.FuncKind == (byte) 109)
          this.CopyMsgObj.SetActive(false);
        else
          this.CopyMsgObj.SetActive(true);
        if (this.ClickChatData.bHasLoc)
        {
          this.PosBtnObject.SetActive(true);
          this.PosImgObject.SetActive(true);
          if (this.PosStr == null)
            this.PosStr = StringManager.Instance.SpawnString();
          this.PosStr.Length = 0;
          if (this.ClickChatData.King != -1)
          {
            this.PosStr.IntToFormat((long) this.ClickChatData.King);
            this.PosStr.IntToFormat((long) this.ClickChatData.LocX);
            this.PosStr.IntToFormat((long) this.ClickChatData.LocY);
            this.PosStr.AppendFormat("{0}:{1}:{2}");
          }
          else
          {
            this.PosStr.IntToFormat((long) this.ClickChatData.LocX);
            this.PosStr.IntToFormat((long) this.ClickChatData.LocY);
            this.PosStr.AppendFormat("{0}:{1}");
          }
          this.PosText2.text = this.PosStr.ToString();
          this.PosText2.SetAllDirty();
          this.PosText2.cachedTextGenerator.Invalidate();
          this.PosText2.cachedTextGeneratorForLayout.Invalidate();
          ((Graphic) this.PosText2).rectTransform.sizeDelta = new Vector2(this.PosText2.preferredWidth, ((Graphic) this.PosText2).rectTransform.sizeDelta.y);
          float x = (float) (194.5 - ((double) this.PosTextWidth + (double) this.PosText2.preferredWidth + 10.0) / 2.0);
          ((Graphic) this.PosText).rectTransform.anchoredPosition = new Vector2(x, ((Graphic) this.PosText).rectTransform.anchoredPosition.y);
          ((Graphic) this.PosText2).rectTransform.anchoredPosition = new Vector2((float) ((double) x + (double) this.PosTextWidth + 10.0), ((Graphic) this.PosText2).rectTransform.anchoredPosition.y);
          if (BattleController.IsGambleMode)
          {
            ((Graphic) this.PosText).color = Color.gray;
            ((Graphic) this.PosText2).color = Color.gray;
            ((Graphic) this.PosImage).color = Color.gray;
          }
          else
          {
            ((Graphic) this.PosText).color = Color.white;
            ((Graphic) this.PosText2).color = Color.blue;
            ((Graphic) this.PosImage).color = Color.blue;
          }
        }
        else
        {
          this.PosBtnObject.SetActive(false);
          this.PosImgObject.SetActive(false);
        }
        if (this.ClickChatData.PlayID != this.DM.RoleAttr.UserId)
        {
          this.BLBtnObject.SetActive(true);
          this.BLText.text = !this.DM.FindBlackList(this.ClickChatData.PlayerName) ? this.DM.mStringTable.GetStringByID(8212U) : this.DM.mStringTable.GetStringByID(8213U);
        }
        else
          this.BLBtnObject.SetActive(false);
        if (this.ClickChatData.PlayID != this.DM.RoleAttr.UserId)
          this.SendBLBtnObject.SetActive(true);
        else
          this.SendBLBtnObject.SetActive(false);
        this.ClickChatObject.SetActive(true);
      }
      else if (this.NowList[nowIndex].TalkKind == (byte) 5)
      {
        if (this.CheckIsGambleModeShowMsg())
          return;
        if ((int) this.NowList[nowIndex].PlayerPicID != (int) DataManager.MapDataController.kingdomData.kingdomID)
        {
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1478U), (ushort) byte.MaxValue);
        }
        else
        {
          this.SavePagePara();
          this.DM.SendKingdomBullitin_Info(true);
        }
      }
      else if (this.NowList[nowIndex].TalkKind == (byte) 6)
      {
        if (this.CheckIsGambleModeShowMsg() || this.NowList[nowIndex].NPCID == 0L)
          return;
        this.SavePagePara();
        this.GM.Send_REQUEST_NPC_RALLY_DETAIL_BYID(this.NowList[nowIndex].NPCID);
      }
      else if (this.NowList[nowIndex].TalkKind == (byte) 7)
      {
        if (ActivityManager.Instance.AllianceSummon_SummonData.MonsterEndTime > 0L)
        {
          this.SavePagePara();
          int kingdomId = (int) ActivityManager.Instance.AllianceSummon_SummonData.MonsterPos.KingdomID;
          int mapId = GameConstants.PointCodeToMapID(ActivityManager.Instance.AllianceSummon_SummonData.MonsterPos.CombatPoint.zoneID, ActivityManager.Instance.AllianceSummon_SummonData.MonsterPos.CombatPoint.pointID);
          (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).GoToMapID((ushort) kingdomId, mapId, (byte) 0, (byte) 1);
        }
        else
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8342U), (ushort) byte.MaxValue);
      }
      else
      {
        if (this.NowList[nowIndex].TalkKind != (byte) 9 || this.CheckIsGambleModeShowMsg())
          return;
        ActivityManager instance1 = ActivityManager.Instance;
        ActivityGiftManager instance2 = ActivityGiftManager.Instance;
        if (instance2.EnableRedPocketNum > (byte) 0 || instance2.ActivityGiftBeginTime != 0L && instance1.ServerEventTime >= instance2.ActivityGiftBeginTime && instance2.ActivityGiftEndTime != 0L && instance1.ServerEventTime <= instance2.ActivityGiftEndTime)
        {
          UIAlliance_ActivityGift menu1 = this.GM.FindMenu(EGUIWindow.UI_Alliance_ActivityGift) as UIAlliance_ActivityGift;
          Door menu2 = this.GM.FindMenu(EGUIWindow.Door) as Door;
          if (!((Object) menu2 != (Object) null))
            return;
          this.SavePagePara();
          if ((Object) menu1 == (Object) null)
          {
            ActivityGiftManager.Instance.mActivityGiftPage = (byte) 0;
            menu2.OpenMenu(EGUIWindow.UI_Alliance_ActivityGift);
          }
          else if (!menu1.gameObject.activeSelf)
          {
            menu2.CloseMenu();
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 5);
          }
          else
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_ActivityGift, 5);
        }
        else
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(16101U), (ushort) byte.MaxValue);
      }
    }
    else if (panelId != 2)
      ;
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      switch (sender.m_BtnID2)
      {
        case 1:
          if (this.NowChannel == (byte) 1 && DataManager.Instance.RoleAlliance.Id == 0U)
          {
            Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
            if (!((Object) menu != (Object) null))
              break;
            menu.AllianceOnClick();
            break;
          }
          if (this.cScrollRect.CheckBeLoad() || this.mInput.text.Length <= 0)
            break;
          string str;
          eTextCheck textState;
          this.mInput.GetText(out str, out textState);
          this.InputEnd(str, textState);
          break;
        case 2:
          if (this.NowChannel == (byte) 1 && DataManager.Instance.RoleAlliance.Id == 0U)
          {
            Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
            if (!((Object) menu != (Object) null))
              break;
            menu.AllianceOnClick();
            break;
          }
          if (this.DM.AskOldData == (byte) 0)
          {
            if (this.DM.SendAskKind != -1)
              break;
            this.DM.SendAskKind = 4;
            this.DM.AskOldData = (byte) 1;
            this.DM.SendAskData((byte) 1, (byte) 0, this.DM.SendAskKind, 0L, this.DM.LastTime);
            break;
          }
          if (this.DM.AskOldData == (byte) 1)
            break;
          if (this.DM.AskOldData == (byte) 2)
          {
            if ((this.AllianceChatState == (byte) 1 || this.AllianceChatState == (byte) 2) && this.DM.LastTimeIndex != -1 && this.Scroll.CheckInPanel(this.DM.LastTimeIndex - this.BeginIndex))
            {
              this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(709U), (ushort) byte.MaxValue);
              break;
            }
            if (this.AllianceChatState == (byte) 0)
            {
              this.SetAllianceState((byte) 1);
              this.RefreshScrollPanel();
            }
            this.Scroll.GoTo(this.DM.LastTimeIndex - this.BeginIndex);
            break;
          }
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(238U), (ushort) byte.MaxValue);
          break;
        case 3:
          this.SavePagePara();
          this.SetChannel((byte) 0);
          break;
        case 4:
          if (this.DM.RoleAlliance.Id == 0U)
          {
            if (this.CheckIsGambleModeShowMsg())
              break;
            if ((Object) this.GM.FindMenu(EGUIWindow.UI_AllianceHint) != (Object) null)
            {
              Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
              if (!((Object) menu != (Object) null))
                break;
              menu.CloseMenu();
              break;
            }
            if (this.GM.m_WindowStack.Count > 0 && this.GM.m_WindowStack[this.GM.m_WindowStack.Count - 1].m_eWindow == EGUIWindow.UI_Chat)
              this.GM.m_WindowStack.RemoveAt(this.GM.m_WindowStack.Count - 1);
            Door menu1 = this.GM.FindMenu(EGUIWindow.Door) as Door;
            if (!((Object) menu1 != (Object) null))
              break;
            menu1.AllianceOnClick();
            break;
          }
          this.SavePagePara();
          this.SetChannel((byte) 1);
          break;
        case 6:
          this.CloseSelf();
          break;
        case 7:
          this.AllianceRequestObject.SetActive(!this.AllianceRequestObject.activeInHierarchy);
          break;
        case 8:
          if (this.cScrollRect.CheckBeLoad())
            break;
          if (this.DM.unReadCount <= 0)
          {
            this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(239U), (ushort) byte.MaxValue);
            break;
          }
          if (this.DM.unReadIndex != -1 && this.Scroll.CheckInPanel(this.DM.unReadIndex - this.BeginIndex))
          {
            this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(710U), (ushort) byte.MaxValue);
            break;
          }
          if (this.AllianceChatState == (byte) 1)
          {
            this.SetAllianceState((byte) 0);
            this.RefreshScrollPanel();
          }
          this.Scroll.GoTo(this.DM.unReadIndex - this.BeginIndex);
          break;
        case 9:
          if (this.cScrollRect.CheckBeLoad())
            break;
          if (this.AllianceChatState != (byte) 1 && this.Scroll.CheckAtLast())
          {
            this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(247U), (ushort) byte.MaxValue);
            break;
          }
          if (this.AllianceChatState == (byte) 1)
          {
            this.SetAllianceState((byte) 0);
            this.RefreshScrollPanel();
          }
          this.Scroll.GoToLast();
          this.NewTalkCount = 0;
          break;
        case 10:
          this.GM.OpenMenu(EGUIWindow.UIEmojiSelect, 2, bSecWindow: true);
          break;
      }
    }
    else if (sender.m_BtnID1 == 3)
    {
      if (this.ClickChatData == null || this.ClickChatData.PlayID != this.ClickChatPlayID)
      {
        this.CloseClickChatObj();
      }
      else
      {
        if (sender.m_BtnID2 == 1)
        {
          if (this.CheckIsGambleModeShowMsg())
            return;
          if ((bool) (Object) this.GM.FindMenu(EGUIWindow.UI_LordInfo))
            this.GM.CloseMenu(EGUIWindow.UI_LordInfo);
          if (this.ClickChatData.PlayID == this.DM.RoleAttr.UserId)
          {
            Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
            if ((Object) menu == (Object) null)
              return;
            menu.OpenMenu(EGUIWindow.UI_LordInfo, 1, bCameraMode: true);
          }
          else
            DataManager.Instance.ShowLordProfile(this.ClickChatData.PlayerName.ToString());
        }
        else if (sender.m_BtnID2 == 2)
        {
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.Append(this.ClickChatData.OriginalText.ToString(), 0, this.ClickChatData.OriginalText.Length);
          this.SetInputText(stringBuilder.ToString());
        }
        else if (sender.m_BtnID2 == 3)
        {
          if (this.CheckIsGambleModeShowMsg())
            return;
          Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
          if ((Object) menu == (Object) null)
            return;
          if (this.ClickChatData.bHasLoc)
          {
            if (this.ClickChatData.King != -1)
              menu.GoToMapID((ushort) this.ClickChatData.King, GameConstants.TileMapPosToMapID(this.ClickChatData.LocX, this.ClickChatData.LocY), (byte) 0, (byte) 1);
            else
              menu.GoToMapID(DataManager.MapDataController.OtherKingdomData.kingdomID, GameConstants.TileMapPosToMapID(this.ClickChatData.LocX, this.ClickChatData.LocY), (byte) 0, (byte) 1);
          }
        }
        else if (sender.m_BtnID2 == 4)
        {
          if (this.DM.FindBlackList(this.ClickChatData.PlayerName))
            this.DM.RemoveBlackList(this.ClickChatData.PlayerName);
          else
            this.DM.AddBlackList(this.ClickChatData.PlayerName, this.ClickChatData.PlayerPicID);
        }
        else if (sender.m_BtnID2 != 5 && sender.m_BtnID2 == 6)
        {
          this.GM.MsgStr.Length = 0;
          this.GM.MsgStr.StringToFormat(this.ClickChatData.PlayerName);
          this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(8535U));
          this.GM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(8534U), this.GM.MsgStr.ToString(), YesText: this.DM.mStringTable.GetStringByID(3925U), NoText: this.DM.mStringTable.GetStringByID(3926U));
        }
        this.SavePagePara();
        this.CloseClickChatObj();
      }
    }
    else if (sender.m_BtnID1 == 4)
    {
      if (sender.m_BtnID2 == 1)
      {
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_SENDCHAT;
        byte[] bytes = Encoding.UTF8.GetBytes(this.mInput.text.ToCharArray(), 0, this.mInput.text.Length);
        messagePacket.AddSeqId();
        messagePacket.Add(this.NowChannel);
        messagePacket.Add((byte) 3);
        messagePacket.Add((ushort) bytes.Length);
        messagePacket.Add(bytes);
        messagePacket.Send();
      }
      else if (sender.m_BtnID2 == 2)
      {
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_SENDCHAT;
        byte[] bytes = Encoding.UTF8.GetBytes(this.mInput.text.ToCharArray(), 0, this.mInput.text.Length);
        messagePacket.AddSeqId();
        messagePacket.Add(this.NowChannel);
        messagePacket.Add((byte) 4);
        messagePacket.Add((ushort) bytes.Length);
        messagePacket.Add(bytes);
        messagePacket.Send();
      }
      this.AllianceRequestObject.SetActive(false);
    }
    else if (sender.m_BtnID1 == 5)
    {
      if (sender.m_BtnID2 != 1)
        ;
    }
    else
    {
      if (sender.m_BtnID1 != 6 || !this.bFindScrollComp[sender.m_BtnID2])
        return;
      int talkDataIndex = this.Scroll_1_Comp[sender.m_BtnID2].TalkDataIndex;
      if (talkDataIndex >= this.NowList.Count)
        return;
      if (this.NowList[talkDataIndex].TranslateState == eTranslateState.completed)
      {
        this.NowList[talkDataIndex].TranslateShow = this.NowList[talkDataIndex].TranslateShow != (byte) 0 ? (byte) 0 : (byte) 1;
        this.RefreshScrollPanel(false, false);
      }
      else
      {
        if (this.NowList[talkDataIndex].TranslateState == eTranslateState.Translation || this.NowList[talkDataIndex].TranslateState != eTranslateState.Untranslated && this.NowList[talkDataIndex].TranslateState != eTranslateState.TranslateFail || this.GM.bWaitTranslate || !this.GM.TransLatebyIndex(this.NowList[talkDataIndex]))
          return;
        this.Scroll_1_Comp[sender.m_BtnID2].TranslateImgGO.SetActive(true);
        this.Scroll_1_Comp[sender.m_BtnID2].TranslateBtnGO.SetActive(false);
      }
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8536U), (ushort) byte.MaxValue);
  }

  private void SetSBTime(long time, CString tmpS)
  {
    tmpS.ClearString();
    if (this.GM.IsArabic)
    {
      if (time >= 0L && time < 60L)
      {
        tmpS.IntToFormat(time);
        if (time > 1L)
          tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(446U));
        else
          tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(442U));
      }
      else if (time >= 60L && time < 3600L)
      {
        long x = time / 60L;
        tmpS.IntToFormat(x);
        if (x > 1L)
          tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(447U));
        else
          tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(443U));
      }
      else if (time >= 3600L && time < 86400L)
      {
        long x = time / 3600L;
        tmpS.IntToFormat(x);
        if (x > 1L)
          tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(448U));
        else
          tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(444U));
      }
      else if (time >= 86400L)
      {
        long x = time / 86400L;
        tmpS.IntToFormat(x);
        if (x > 1L)
          tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(449U));
        else
          tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(445U));
      }
      else
      {
        tmpS.IntToFormat(0L);
        tmpS.StringToFormat(this.DM.mStringTable.GetStringByID(442U));
      }
      tmpS.AppendFormat("{0} {1}");
    }
    else if (time >= 0L && time < 60L)
    {
      tmpS.IntToFormat(time);
      if (time > 1L)
        tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(446U));
      else
        tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(442U));
    }
    else if (time >= 60L && time < 3600L)
    {
      long x = time / 60L;
      tmpS.IntToFormat(x);
      if (x > 1L)
        tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(447U));
      else
        tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(443U));
    }
    else if (time >= 3600L && time < 86400L)
    {
      long x = time / 3600L;
      tmpS.IntToFormat(x);
      if (x > 1L)
        tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(448U));
      else
        tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(444U));
    }
    else if (time >= 86400L)
    {
      long x = time / 86400L;
      tmpS.IntToFormat(x);
      if (x > 1L)
        tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(449U));
      else
        tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(445U));
    }
    else
    {
      tmpS.IntToFormat(0L);
      tmpS.AppendFormat(this.DM.mStringTable.GetStringByID(442U));
    }
  }

  private void CheckBeginEndIndex()
  {
    if (this.AllianceChatState == (byte) 2)
    {
      this.BeginIndex = 0;
      this.EndIndex = this.NowList.Count - 1;
    }
    else if (this.AllianceChatState == (byte) 1)
    {
      this.BeginIndex = this.DM.TopIndex;
      this.EndIndex = this.DM.MiddleTopIndex;
    }
    else
    {
      if (this.AllianceChatState != (byte) 0)
        return;
      this.BeginIndex = this.DM.MiddleBottomIndex;
      this.EndIndex = this.NowList.Count - 1;
    }
  }

  private void SetAllianceState(byte State)
  {
    if (this.DM.MiddleBottomIndex != -1 && this.DM.MiddleTopIndex == this.DM.MiddleBottomIndex)
      State = (byte) 2;
    this.AllianceChatState = State;
    this.CheckStopViewState();
  }

  public override bool OnBackButtonClick()
  {
    if (this.ClickChatObject.activeInHierarchy)
    {
      this.CloseClickChatObj();
      return true;
    }
    if (this.AllianceRequestObject.activeInHierarchy)
    {
      this.AllianceRequestObject.SetActive(false);
      return true;
    }
    if (BattleController.IsGambleMode && (bool) (Object) this.GM.FindMenu(EGUIWindow.UIEmojiSelect))
    {
      this.GM.CloseMenu(EGUIWindow.UIEmojiSelect);
      return true;
    }
    this.CloseSelf();
    return true;
  }

  public void CloseSelf()
  {
    if (BattleController.IsGambleMode)
    {
      GamblingManager.Instance.CloseMenu();
      ((Component) this.GM.m_ChatBox).gameObject.SetActive(true);
    }
    else
    {
      if (this.cScrollRect.ViewState == ListViewState.LVS_WAITLOADING || this.cScrollRect.ViewState == ListViewState.LVS_WAITLOADING_UP)
        this.cScrollRect.SwitchViewState(ListViewState.LVS_NORMAL);
      this.SavePagePara();
      Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
      if ((Object) menu != (Object) null)
      {
        if (menu.m_WindowStack.Count == 0 || menu.m_WindowStack[menu.m_WindowStack.Count - 1].m_eWindow != EGUIWindow.UI_Chat)
        {
          GUIWindowStackData guiWindowStackData;
          guiWindowStackData.m_eWindow = EGUIWindow.UI_Chat;
          guiWindowStackData.m_Arg1 = 0;
          guiWindowStackData.m_Arg2 = 0;
          guiWindowStackData.bCameraMode = false;
          menu.m_WindowStack.Add(guiWindowStackData);
          menu.CloseMenu(true);
          if (!((Object) this.GM.m_Window2 != (Object) null))
            return;
          this.GM.CloseMenu(this.GM.m_Window2.m_eWindow);
        }
        else
          menu.CloseMenu();
      }
      else
        this.GM.CloseMenu(EGUIWindow.UI_Chat);
    }
  }

  public void SetInputText(string str)
  {
    this.mInput.text = str;
    this.mInput.textComponent.SetAllDirty();
    this.mInput.textComponent.cachedTextGenerator.Invalidate();
  }

  public void CheckUnRead(bool bShow)
  {
    if (bShow)
    {
      ((Component) this.UnReadCountRC).gameObject.SetActive(true);
      this.UpdateUnRead();
      this.DM.bShowUnreadCount = true;
    }
    else
    {
      ((Component) this.UnReadCountRC).gameObject.SetActive(false);
      this.DM.bShowUnreadCount = false;
    }
    GUIManager.Instance.UpdateChatBox(8);
  }

  private void UpdateUnRead()
  {
    if (!((Component) this.UnReadCountRC).gameObject.activeSelf)
      return;
    this.UnreadStr.ClearString();
    this.UnreadStr.IntToFormat((long) this.DM.unReadCount);
    this.UnreadStr.AppendFormat("{0}");
    this.UnReadCountText.text = this.UnreadStr.ToString();
    this.UnReadCountText.SetAllDirty();
    this.UnReadCountText.cachedTextGenerator.Invalidate();
    this.UnReadCountText.cachedTextGeneratorForLayout.Invalidate();
    this.UnReadCountRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.UnReadCountText.preferredWidth), 51f);
  }

  public void SavePagePara()
  {
    if (this.DM.NowChannel == (byte) 0)
    {
      this.DM.NowKingdomIndex = this.Scroll.GetTopIdx();
      this.DM.NowKingdomPos = this.cScrollRect.content.anchoredPosition.y;
      if (this.DM.NowKingdomIndex != -1 || this.NowList.Count <= 0)
        return;
      this.DM.NowKingdomIndex = 0;
      this.DM.NowKingdomPos = 0.0f;
    }
    else
    {
      this.DM.NowAlliancePage = (int) this.AllianceChatState;
      if (this.AllianceChatState == (byte) 1)
      {
        this.DM.NowAllianceIndex2 = this.Scroll.GetTopIdx();
        this.DM.NowAlliancePos2 = this.cScrollRect.content.anchoredPosition.y;
        if (this.DM.NowAllianceIndex2 != -1 || this.NowList.Count <= 0)
          return;
        this.DM.NowAllianceIndex2 = 0;
        this.DM.NowAlliancePos2 = 0.0f;
      }
      else
      {
        this.DM.NowAllianceIndex1 = this.Scroll.GetTopIdx();
        this.DM.NowAlliancePos1 = this.cScrollRect.content.anchoredPosition.y;
        if (this.DM.NowAllianceIndex1 != -1 || this.NowList.Count <= 0)
          return;
        this.DM.NowAllianceIndex1 = 0;
        this.DM.NowAlliancePos1 = 0.0f;
      }
    }
  }

  public void SetBottom(float bottom)
  {
    bottom = bottom * 2f / ((Component) GUIManager.Instance.m_UICanvas).transform.localScale.y;
    this.m_transform.GetComponent<RectTransform>().offsetMin = new Vector2(0.0f, bottom);
  }

  public void Adjust(int Height) => this.SetBottom((float) Height);

  public bool CheckIsGambleModeShowMsg()
  {
    if (!BattleController.IsGambleMode)
      return false;
    this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9184U), (ushort) byte.MaxValue);
    return true;
  }

  private void CloseClickChatObj()
  {
    this.ClickChatObject.SetActive(false);
    this.ClickChatData = (TalkDataType) null;
    this.ClickChatPlayID = 0L;
  }
}
