// Decompiled with JetBrains decompiler
// Type: UIOther
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIOther : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  public const int OtherItemCount = 15;
  private DataManager DM;
  private GUIManager GUIM;
  private ScrollPanel m_ScrollPanel;
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private Door door;
  private Transform GameT;
  private Transform GiftT;
  private Transform LiveT;
  private Transform H5LiveCheckMarkT;
  private RectTransform CDTime_text_RT;
  private UIButton btn_EXIT;
  public UIButton[] btnItem = new UIButton[15];
  private Image[] ImgItem = new Image[15];
  private Image tmpImg;
  private Image Img_FBNum;
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[5];
  private UIText tmptext;
  private UIText text_Number;
  private UIText text_CDTime;
  private UIText text_Mail;
  private UIText text_FBNum;
  private UIText[] text_tmpStr = new UIText[2];
  private CString Cstr_Number;
  private CString Cstr_CDTime;
  private UIText[] textItem = new UIText[15];
  private Material m_Mat;
  private List<float> tmplist = new List<float>();
  private List<string> tmpStrlist = new List<string>();
  private byte[] mIdx = new byte[15];
  private UISpritesArray SArray;
  private Sprite[] mListSp;
  private int ListCount;
  private byte mMoveNum;
  private uTweenScale uToolBG_S;
  private uTweenScale uToolBGF_S;
  private uTweenAlpha uToolBGF_A;
  private bool bShowFB_Btn;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.m_Mat = this.door.LoadMaterial();
    for (int index = 0; index < 9; ++index)
      this.tmpStrlist.Add(this.DM.mStringTable.GetStringByID((uint) (ushort) (7023 + index)));
    this.tmpStrlist.Add(this.DM.mStringTable.GetStringByID(9016U));
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
      this.tmpStrlist.Add(this.DM.mStringTable.GetStringByID(9521U));
    else if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
      this.tmpStrlist.Add(this.DM.mStringTable.GetStringByID(16019U));
    else
      this.tmpStrlist.Add(this.DM.mStringTable.GetStringByID(7043U));
    this.tmpStrlist.Add(string.Empty);
    this.tmpStrlist.Add(this.DM.mStringTable.GetStringByID(12178U));
    this.tmpStrlist.Add(this.DM.mStringTable.GetStringByID(10148U));
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.mListSp = new Sprite[this.SArray.m_Sprites.Length];
    for (int index = 0; index < this.SArray.m_Sprites.Length; ++index)
      this.mListSp[index] = this.SArray.m_Sprites[index];
    this.mIdx[0] = (byte) 1;
    this.mIdx[1] = (byte) 5;
    this.mIdx[2] = (byte) 6;
    this.mIdx[3] = (byte) 2;
    this.mIdx[4] = (byte) 3;
    this.mIdx[5] = (byte) 4;
    this.mIdx[6] = (byte) 10;
    this.CheckListData();
    this.Cstr_Number = StringManager.Instance.SpawnString();
    this.Cstr_CDTime = StringManager.Instance.SpawnString();
    this.text_tmpStr[0] = this.GameT.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[0].font = this.TTFont;
    this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7022U);
    this.LiveT = this.GameT.GetChild(0).GetChild(2);
    if (this.GUIM.IsArabic)
    {
      this.tmpImg = this.LiveT.GetChild(0).GetComponent<Image>();
      ((Component) this.tmpImg).gameObject.AddComponent<ArabicItemTextureRot>();
      this.tmpImg = this.LiveT.GetChild(1).GetComponent<Image>();
      ((Component) this.tmpImg).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    this.uToolBG_S = this.LiveT.GetChild(0).GetComponent<uTweenScale>();
    this.uToolBGF_S = this.LiveT.GetChild(1).GetComponent<uTweenScale>();
    this.uToolBGF_A = this.LiveT.GetChild(1).GetComponent<uTweenAlpha>();
    this.H5LiveCheckMarkT = this.GameT.GetChild(0).GetChild(3);
    this.Img_FBNum = this.GameT.GetChild(0).GetChild(4).GetComponent<Image>();
    this.text_FBNum = this.GameT.GetChild(0).GetChild(4).GetChild(0).GetComponent<UIText>();
    this.text_FBNum.font = this.TTFont;
    this.text_FBNum.text = DataManager.FBMissionDataManager.GetRewardCount().ToString();
    ((Graphic) this.Img_FBNum).rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_FBNum.preferredWidth), ((Graphic) this.Img_FBNum).rectTransform.sizeDelta.y);
    this.m_ScrollPanel = this.GameT.GetChild(1).GetComponent<ScrollPanel>();
    this.tmplist.Clear();
    Transform child1 = this.GameT.GetChild(2);
    for (int index = 0; index < 3; ++index)
    {
      UIButton component = child1.GetChild(index).GetComponent<UIButton>();
      component.m_Handler = (IUIButtonClickHandler) this;
      this.tmptext = child1.GetChild(index).GetChild(1).GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
      component.m_EffectType = e_EffectType.e_Scale;
      component.transition = (Selectable.Transition) 0;
    }
    for (int index = 0; index < this.ListCount / 3; ++index)
      this.tmplist.Add(120f);
    if (this.ListCount % 3 > 0)
      this.tmplist.Add(120f);
    this.m_ScrollPanel.IntiScrollPanel(437f, 10f, 0.0f, this.tmplist, 5, (IUpDateScrollPanel) this);
    if ((Object) this.tmpItem[2] != (Object) null)
    {
      this.LiveT.SetParent(((Component) this.tmpItem[2]).transform.GetChild((int) this.mMoveNum), false);
      this.H5LiveCheckMarkT.SetParent(((Component) this.tmpItem[2]).transform.GetChild((int) this.mMoveNum), false);
      ((Component) this.Img_FBNum).transform.SetParent(((Component) this.tmpItem[2]).transform.GetChild(1), false);
      ((Component) this.Img_FBNum).gameObject.SetActive(this.bShowFB_Btn && DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0);
    }
    if (this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 12)
      this.LiveT.gameObject.SetActive(this.GUIM.bShowLive);
    if (this.LiveT.gameObject.activeInHierarchy && this.GUIM.StopShowLiveScale < (byte) 2)
    {
      this.uToolBG_S.enabled = true;
      this.uToolBGF_S.enabled = true;
      this.uToolBGF_A.enabled = true;
    }
    else
    {
      this.uToolBG_S.enabled = false;
      this.uToolBG_S.SetCurrentValueToStart();
      this.uToolBGF_S.enabled = false;
      this.uToolBGF_S.SetCurrentValueToStart();
      this.uToolBGF_A.enabled = false;
      this.uToolBGF_A.SetCurrentValueToStart();
    }
    if (this.GUIM.IsArabic)
    {
      this.tmpImg = this.GameT.GetChild(3).GetComponent<Image>();
      ((Component) this.tmpImg).gameObject.AddComponent<ArabicItemTextureRot>();
      ((Graphic) this.tmpImg).rectTransform.anchoredPosition = new Vector2(((Graphic) this.tmpImg).rectTransform.anchoredPosition.x + 275f, ((Graphic) this.tmpImg).rectTransform.anchoredPosition.y);
    }
    Transform child2 = this.GameT.GetChild(4).GetChild(1);
    this.text_CDTime = child2.GetComponent<UIText>();
    this.CDTime_text_RT = child2.GetComponent<RectTransform>();
    this.text_CDTime.font = this.TTFont;
    this.Cstr_CDTime.ClearString();
    this.Cstr_CDTime.IntToFormat((long) GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Hour, 2);
    this.Cstr_CDTime.IntToFormat((long) GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Minute, 2);
    this.Cstr_CDTime.AppendFormat(this.DM.mStringTable.GetStringByID(753U));
    this.text_CDTime.text = this.Cstr_CDTime.ToString();
    this.text_CDTime.SetAllDirty();
    this.text_CDTime.cachedTextGenerator.Invalidate();
    this.text_CDTime.cachedTextGeneratorForLayout.Invalidate();
    this.CDTime_text_RT.sizeDelta = new Vector2(this.text_CDTime.preferredWidth, this.CDTime_text_RT.sizeDelta.y);
    this.GiftT = this.GameT.GetChild(5);
    if ((Object) this.tmpItem[0] != (Object) null)
      this.GiftT.SetParent(((Component) this.tmpItem[0]).transform.GetChild(0), false);
    if (!DataManager.Instance.CheckPrizeFlag((byte) 2) && IGGGameSDK.Instance.m_IGGLoginType != IGGLoginType.Facebook)
      this.GiftT.gameObject.SetActive(true);
    this.text_tmpStr[1] = this.GameT.GetChild(5).GetComponent<UIText>();
    this.text_tmpStr[1].font = this.TTFont;
    this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(7048U);
    this.text_Number = this.GameT.GetChild(6).GetComponent<UIText>();
    this.text_Number.font = this.TTFont;
    this.Cstr_Number.ClearString();
    this.Cstr_Number.IntToFormat((long) GameConstants.Version[0]);
    this.Cstr_Number.IntToFormat((long) GameConstants.Version[1]);
    this.Cstr_Number.IntToFormat((long) GameConstants.Version[2]);
    this.Cstr_Number.AppendFormat(this.DM.mStringTable.GetStringByID(7049U));
    this.text_Number.text = this.Cstr_Number.ToString();
    this.text_Mail = this.GameT.GetChild(7).GetComponent<UIText>();
    this.text_Mail.font = this.TTFont;
    this.text_Mail.text = GameConstants.m_Mail[(int) this.DM.UserLanguage];
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Ukr || DataManager.Instance.UserLanguage == GameLanguage.GL_Mys)
      ((Component) this.text_Mail).gameObject.SetActive(false);
    this.tmpImg = this.GameT.GetChild(8).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(8).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.m_Mat;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    if (this.GUIM.StopShowLiveScale != (byte) 0)
      return;
    ++this.GUIM.StopShowLiveScale;
    this.GUIM.UpdateUI(EGUIWindow.Door, 20);
  }

  public void CheckListData()
  {
    this.ListCount = 7;
    this.mMoveNum = (byte) 0;
    if (this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 7)
    {
      this.mIdx[this.ListCount] = (byte) 13;
      this.mListSp[this.ListCount] = this.SArray.m_Sprites[16];
      ++this.ListCount;
      ++this.mMoveNum;
      this.bShowFB_Btn = true;
    }
    this.mIdx[this.ListCount] = (byte) 14;
    this.mListSp[this.ListCount] = this.SArray.m_Sprites[17];
    ++this.ListCount;
    ++this.mMoveNum;
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Ukr || DataManager.Instance.UserLanguage == GameLanguage.GL_Mys)
    {
      this.mIdx[this.ListCount] = (byte) 11;
      this.mListSp[this.ListCount] = this.SArray.m_Sprites[8];
      ++this.ListCount;
      this.mIdx[this.ListCount] = (byte) 9;
      this.mListSp[this.ListCount] = this.SArray.m_Sprites[9];
      ++this.ListCount;
      this.mIdx[this.ListCount] = (byte) 7;
      this.mListSp[this.ListCount] = this.SArray.m_Sprites[10];
      ++this.ListCount;
      this.mIdx[this.ListCount] = (byte) 12;
      this.mListSp[this.ListCount] = this.SArray.m_Sprites[14];
      ++this.ListCount;
    }
    else
    {
      this.mIdx[this.ListCount] = (byte) 8;
      this.mListSp[this.ListCount] = this.SArray.m_Sprites[7];
      ++this.ListCount;
      this.mIdx[this.ListCount] = (byte) 11;
      this.mListSp[this.ListCount] = this.SArray.m_Sprites[8];
      ++this.ListCount;
      this.mIdx[this.ListCount] = (byte) 9;
      this.mListSp[this.ListCount] = this.SArray.m_Sprites[9];
      ++this.ListCount;
      this.mIdx[this.ListCount] = (byte) 7;
      this.mListSp[this.ListCount] = this.SArray.m_Sprites[10];
      ++this.ListCount;
      this.mIdx[this.ListCount] = (byte) 12;
      this.mListSp[this.ListCount] = this.SArray.m_Sprites[14];
      ++this.ListCount;
    }
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
      this.mListSp[8 + (int) this.mMoveNum] = this.SArray.m_Sprites[11];
    if (DataManager.Instance.UserLanguage != GameLanguage.GL_Chs)
      return;
    this.mListSp[8 + (int) this.mMoveNum] = this.SArray.m_Sprites[15];
  }

  public void OnButtonClick(UIButton sender)
  {
    switch ((GUIOther_btn) sender.m_BtnID1)
    {
      case GUIOther_btn.btn_EXIT:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case GUIOther_btn.btn_Item:
        this.OnClickBtn(sender.m_BtnID2);
        break;
    }
  }

  public void OnClickBtn(int mkind)
  {
    switch (mkind)
    {
      case 1:
        GUIManager.Instance.OpenUI_Queued_Restricted_Top(EGUIWindow.UI_Other_Account, openMode: (byte) 0);
        break;
      case 2:
        this.door.OpenMenu(EGUIWindow.UI_Other_Set);
        break;
      case 3:
        this.door.OpenMenu(EGUIWindow.UI_Other_FunctionSwitch);
        break;
      case 4:
        this.door.OpenMenu(EGUIWindow.UI_Other_FunctionSwitch, 1);
        break;
      case 5:
        this.door.OpenMenu(EGUIWindow.UI_SearchList);
        break;
      case 6:
        if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 8)
        {
          GUIManager.Instance.MsgStr.ClearString();
          GUIManager.Instance.MsgStr.StringToFormat(this.DM.mStringTable.GetStringByID(7028U));
          GUIManager.Instance.MsgStr.IntToFormat(8L);
          GUIManager.Instance.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(9749U));
          GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), (ushort) byte.MaxValue);
          break;
        }
        UILeaderBoard.NewOpen = true;
        this.door.OpenMenu(EGUIWindow.UI_LeaderBoard, 2);
        break;
      case 7:
        this.door.OpenMenu(EGUIWindow.UI_BlackList);
        break;
      case 8:
        this.door.OpenMenu(EGUIWindow.UI_Other_Forum);
        break;
      case 9:
        this.door.OpenMenu(EGUIWindow.UI_Other_Forum, 1);
        break;
      case 10:
        this.door.OpenMenu(EGUIWindow.UI_LanguageSelect, 2);
        break;
      case 11:
        if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
        {
          IGGSDKPlugin.OpenFbByUrl("https://web.lobi.co/game/lords_mobile/group");
          break;
        }
        if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
        {
          IGGSDKPlugin.OpenFbByUrl("http://weibo.com/lordsmobilecn");
          break;
        }
        IGGSDKPlugin.OpenFbByUrl(GameConstants.GlobalEditionFUrl);
        break;
      case 12:
        DataManager.MissionDataManager.AchievementMgr.OpenAchievementUI();
        break;
      case 13:
        DataManager.FBMissionDataManager.m_FBBindEnd = false;
        this.door.OpenMenu(EGUIWindow.UI_MissionFB, bCameraMode: true);
        if (!DataManager.FBMissionDataManager.bFB_CDTime && DataManager.FBMissionDataManager.GetRemainTime() != 0U)
          break;
        DataManager.FBMissionDataManager.bFB_btnShow = false;
        DataManager.FBMissionDataManager.ReSetFB_CDTime();
        break;
      case 14:
        bool flag = false;
        if (!this.DM.CheckPrizeFlag((byte) 28))
        {
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_WEGAMER_RESP_OFFICIAL_LIVE;
          messagePacket.AddSeqId();
          messagePacket.Send();
          this.DM.RoleAttr.PrizeFlag |= 268435456U;
          flag = true;
        }
        this.GUIM.StopShowLiveScale = (byte) 2;
        if ((bool) (Object) this.uToolBG_S)
        {
          this.uToolBG_S.enabled = false;
          this.uToolBG_S.SetCurrentValueToStart();
        }
        if ((bool) (Object) this.uToolBGF_S)
        {
          this.uToolBGF_S.enabled = false;
          this.uToolBGF_S.SetCurrentValueToStart();
        }
        if ((bool) (Object) this.uToolBGF_A)
        {
          this.uToolBGF_A.enabled = false;
          this.uToolBGF_A.SetCurrentValueToStart();
        }
        this.GUIM.UpdateUI(EGUIWindow.Door, 20);
        if (flag)
          break;
        this.OpenH5();
        break;
    }
  }

  private void OpenH5()
  {
    H5SDKPlugin.StartH5ByWebView(IGGGameSDK.Instance.m_IGGID, DataManager.Instance.UserLanguage.ToString(), "1", DataManager.Instance.RoleAttr.Name.ToString());
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) this.tmpItem[panelObjectIdx] == (Object) null)
    {
      this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
      for (int index = 0; index < 3; ++index)
      {
        this.btnItem[panelObjectIdx * 3 + index] = ((Component) this.tmpItem[panelObjectIdx]).transform.GetChild(index).GetComponent<UIButton>();
        this.btnItem[panelObjectIdx * 3 + index].m_Handler = (IUIButtonClickHandler) this;
        this.btnItem[panelObjectIdx * 3 + index].m_BtnID1 = 1;
        this.btnItem[panelObjectIdx * 3 + index].m_BtnID2 = 0;
        this.ImgItem[panelObjectIdx * 3 + index] = ((Component) this.tmpItem[panelObjectIdx]).transform.GetChild(index).GetChild(0).GetComponent<Image>();
        this.textItem[panelObjectIdx * 3 + index] = ((Component) this.tmpItem[panelObjectIdx]).transform.GetChild(index).GetChild(1).GetComponent<UIText>();
        this.textItem[panelObjectIdx * 3 + index].font = this.TTFont;
        if (dataIdx * 3 + index < this.ListCount)
        {
          this.ImgItem[panelObjectIdx * 3 + index].sprite = dataIdx * 3 + index >= this.mListSp.Length ? this.mListSp[0] : this.mListSp[dataIdx * 3 + index];
          this.textItem[panelObjectIdx * 3 + index].text = dataIdx * 3 + index >= this.mIdx.Length || (int) this.mIdx[dataIdx * 3 + index] - 1 >= this.tmpStrlist.Count ? string.Empty : this.tmpStrlist[(int) this.mIdx[dataIdx * 3 + index] - 1];
          if (!((UIBehaviour) this.btnItem[panelObjectIdx * 3 + index]).IsActive())
            ((Component) this.btnItem[panelObjectIdx * 3 + index]).gameObject.SetActive(true);
          this.btnItem[panelObjectIdx * 3 + index].m_BtnID2 = (int) this.mIdx[dataIdx * 3 + index];
          if (this.GUIM.IsArabic)
          {
            if (this.mIdx[dataIdx * 3 + index] == (byte) 6 || this.mIdx[dataIdx * 3 + index] == (byte) 11)
              ((Component) this.ImgItem[panelObjectIdx * 3 + index]).transform.localScale = new Vector3(-1f, 1f, 1f);
            if (this.mIdx[dataIdx * 3 + index] == (byte) 12)
              ((Component) this.ImgItem[panelObjectIdx * 3 + index]).transform.localScale = new Vector3(-1f, 1f, 1f);
          }
        }
        else
          ((Component) this.btnItem[panelObjectIdx * 3 + index]).gameObject.SetActive(false);
      }
    }
    else
    {
      if (this.tmpItem[panelObjectIdx].m_BtnID2 == 0)
      {
        if (dataIdx == 0 && !DataManager.Instance.CheckPrizeFlag((byte) 2) && IGGGameSDK.Instance.m_IGGLoginType != IGGLoginType.Facebook)
          this.GiftT.gameObject.SetActive(true);
        else
          this.GiftT.gameObject.SetActive(false);
      }
      for (int index = 0; index < 3; ++index)
      {
        if (dataIdx * 3 + index < this.ListCount)
        {
          if (!((UIBehaviour) this.btnItem[panelObjectIdx * 3 + index]).IsActive())
            ((Component) this.btnItem[panelObjectIdx * 3 + index]).gameObject.SetActive(true);
          this.ImgItem[panelObjectIdx * 3 + index].sprite = dataIdx * 3 + index >= this.mListSp.Length ? this.mListSp[0] : this.mListSp[dataIdx * 3 + index];
          this.textItem[panelObjectIdx * 3 + index].text = dataIdx * 3 + index >= this.mIdx.Length || (int) this.mIdx[dataIdx * 3 + index] - 1 >= this.tmpStrlist.Count ? string.Empty : this.tmpStrlist[(int) this.mIdx[dataIdx * 3 + index] - 1];
          this.textItem[panelObjectIdx * 3 + index].SetAllDirty();
          this.textItem[panelObjectIdx * 3 + index].cachedTextGenerator.Invalidate();
          this.btnItem[panelObjectIdx * 3 + index].m_BtnID2 = (int) this.mIdx[dataIdx * 3 + index];
          if (this.GUIM.IsArabic)
          {
            if (this.mIdx[dataIdx * 3 + index] == (byte) 6 || this.mIdx[dataIdx * 3 + index] == (byte) 11)
              ((Component) this.ImgItem[panelObjectIdx * 3 + index]).transform.localScale = new Vector3(-1f, 1f, 1f);
            if (this.mIdx[dataIdx * 3 + index] == (byte) 12)
              ((Component) this.ImgItem[panelObjectIdx * 3 + index]).transform.localScale = new Vector3(-1f, 1f, 1f);
          }
        }
        else
          ((Component) this.btnItem[panelObjectIdx * 3 + index]).gameObject.SetActive(false);
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnClose()
  {
    if (this.Cstr_Number != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Number);
    if (this.Cstr_CDTime == null)
      return;
    StringManager.Instance.DeSpawnString(this.Cstr_CDTime);
  }

  private void CheckKiveShow()
  {
    if ((Object) this.LiveT != (Object) null)
      this.LiveT.gameObject.SetActive(this.GUIM.bShowLive);
    if ((Object) this.LiveT != (Object) null && this.LiveT.gameObject.activeInHierarchy && this.GUIM.StopShowLiveScale < (byte) 2)
    {
      if ((bool) (Object) this.uToolBG_S)
        this.uToolBG_S.enabled = true;
      if ((bool) (Object) this.uToolBGF_S)
        this.uToolBGF_S.enabled = true;
      if (!(bool) (Object) this.uToolBGF_A)
        return;
      this.uToolBGF_A.enabled = true;
    }
    else
    {
      if ((bool) (Object) this.uToolBG_S)
      {
        this.uToolBG_S.enabled = false;
        this.uToolBG_S.SetCurrentValueToStart();
      }
      if ((bool) (Object) this.uToolBGF_S)
      {
        this.uToolBGF_S.enabled = false;
        this.uToolBGF_S.SetCurrentValueToStart();
      }
      if (!(bool) (Object) this.uToolBGF_A)
        return;
      this.uToolBGF_A.enabled = false;
      this.uToolBGF_A.SetCurrentValueToStart();
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        if (this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 12)
          this.CheckKiveShow();
        if (this.bShowFB_Btn || this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 7)
          break;
        this.door.CloseMenu();
        this.door.OpenMenu(EGUIWindow.UI_Other);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Number != (Object) null && ((Behaviour) this.text_Number).enabled)
    {
      ((Behaviour) this.text_Number).enabled = false;
      ((Behaviour) this.text_Number).enabled = true;
    }
    if ((Object) this.text_CDTime != (Object) null && ((Behaviour) this.text_CDTime).enabled)
    {
      ((Behaviour) this.text_CDTime).enabled = false;
      ((Behaviour) this.text_CDTime).enabled = true;
    }
    if ((Object) this.text_Mail != (Object) null && ((Behaviour) this.text_Mail).enabled)
    {
      ((Behaviour) this.text_Mail).enabled = false;
      ((Behaviour) this.text_Mail).enabled = true;
    }
    if ((Object) this.text_FBNum != (Object) null && ((Behaviour) this.text_FBNum).enabled)
    {
      ((Behaviour) this.text_FBNum).enabled = false;
      ((Behaviour) this.text_FBNum).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
    for (int index = 0; index < 15; ++index)
    {
      if ((Object) this.textItem[index] != (Object) null && ((Behaviour) this.textItem[index]).enabled)
      {
        ((Behaviour) this.textItem[index]).enabled = false;
        ((Behaviour) this.textItem[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        if (!DataManager.Instance.CheckPrizeFlag((byte) 2))
          break;
        this.GiftT.gameObject.SetActive(false);
        break;
      case 2:
        if (this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 12)
          break;
        this.CheckKiveShow();
        break;
      case 3:
        this.OpenH5();
        break;
      case 4:
        if (this.bShowFB_Btn || this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 7)
          break;
        this.door.CloseMenu();
        this.door.OpenMenu(EGUIWindow.UI_Other);
        break;
      case 5:
        ((Component) this.Img_FBNum).gameObject.SetActive(this.bShowFB_Btn && DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0);
        if (!((Component) this.Img_FBNum).gameObject.activeSelf)
          break;
        this.text_FBNum.text = DataManager.FBMissionDataManager.GetRewardCount().ToString();
        this.text_FBNum.SetAllDirty();
        this.text_FBNum.cachedTextGenerator.Invalidate();
        this.text_FBNum.cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.Img_FBNum).rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_FBNum.preferredWidth), ((Graphic) this.Img_FBNum).rectTransform.sizeDelta.y);
        break;
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
