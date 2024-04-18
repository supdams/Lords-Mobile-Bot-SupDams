// Decompiled with JetBrains decompiler
// Type: UILetter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UILetter : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform ItemT;
  private RectTransform tmpcontentRcT;
  private RectTransform[] PageImg_RT = new RectTransform[4];
  private RectTransform[] PageText_RT = new RectTransform[4];
  private RectTransform[] Plural_RT = new RectTransform[6];
  private UIButton btn_EXIT;
  private UIButton btn_Select;
  private UIButton btn_WL;
  private UIButton btn_Delete;
  private UIButton btn_Read;
  private UIButton btn_Cancel;
  private UIButton[] btn_Page = new UIButton[4];
  private UIButton[] btn_ItemDetail = new UIButton[6];
  private UIButton[] btn_ItemSelect = new UIButton[6];
  private UIButton[] btn_ItemCollect = new UIButton[6];
  private UIButton tmpbtn;
  private Image tmpImg;
  private Image ImgFunction;
  private Image ImgEditor;
  private Image ImgNoLetter;
  private Image[] Img_PageShow = new Image[4];
  private Image[] Img_PageIcon = new Image[4];
  private Image[] Img_PageUnRead = new Image[4];
  private Image[] ImgSelect = new Image[6];
  private Image[] ImgNoRead = new Image[6];
  private Image[] ImgRead = new Image[6];
  private Image[] ImgIcon = new Image[6];
  private Image[] ImgBookMark = new Image[6];
  private Image[] ImgPlural = new Image[6];
  private Image[] ImgNoRead2 = new Image[6];
  private UIText tmptext;
  private UIText Title;
  private UIText NoLetterMsg;
  private UIText[] text_Time = new UIText[6];
  private UIText[] text_1 = new UIText[6];
  private UIText[] text_2 = new UIText[6];
  private UIText[] text_3 = new UIText[6];
  private UIText[] text_PluralNoRead = new UIText[6];
  private UIText[] text_PluralTotal = new UIText[6];
  private UIText[] text_UnRead = new UIText[4];
  private CString[] Cstr_PluralTotal = new CString[6];
  private CString[] Cstrtext_1 = new CString[6];
  private CString[] Cstrtext_2 = new CString[6];
  private CString[] Cstrtext_3 = new CString[6];
  private Outline[] mtextOutline = new Outline[6];
  private Shadow[] mtextShadow = new Shadow[6];
  private ScrollPanel m_ScrollPanel;
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[6];
  private DataManager DM;
  private GUIManager GUIM;
  private UISpritesArray SArray;
  private Font TTFont;
  private Door door;
  private Material m_Mat;
  private List<float> tmplist = new List<float>();
  private List<float> Datalist = new List<float>();
  private List<bool> btmpList = new List<bool>();
  private List<bool> bReadList = new List<bool>();
  private List<uint> bCheckList = new List<uint>();
  private bool bOpenImg;
  private bool Pending;
  private int AllSelect;
  private int MaxLetterNum;
  private MyFavorite BattleReport = new MyFavorite(Id: 0U);
  private int NowPage;
  private int NowPageKind;
  private int mIcon;
  private float EditorShowTime;
  private float PageShowTime;
  private Vector2 tmpV;
  private int temp;
  private int mPluralTotal;
  private uint mPluralReplyID;
  private string mPluralSenderName;
  private string[] Str_HeroColor = new string[4];
  private int[] tmpPage = new int[4];
  private bool bTrans;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    if (IGGGameSDK.Instance.GetTranslateStatus() && this.DM.MySysSetting.bAutoTranslate)
      this.bTrans = true;
    this.m_Mat = this.door.LoadMaterial();
    for (int index = 0; index < 6; ++index)
    {
      this.Cstr_PluralTotal[index] = StringManager.Instance.SpawnString();
      this.Cstrtext_1[index] = StringManager.Instance.SpawnString();
      this.Cstrtext_2[index] = StringManager.Instance.SpawnString();
      this.Cstrtext_3[index] = StringManager.Instance.SpawnString(1024);
    }
    this.AllSelect = 0;
    if (this.GUIM.BattleSerialNo > 0U)
    {
      this.BattleReport.Serial = this.DM.OpenMail.Serial = this.GUIM.BattleSerialNo;
      this.BattleReport.Type = this.BattleReport.Kind = MailType.EMAIL_BATTLE;
      this.DM.Letter_Y = -1f;
      this.Pending = true;
      this.NowPage = 1;
    }
    else
      this.NowPage = (int) this.DM.OpenMail.Kind;
    this.DM.Outlooking = true;
    this.DM.bNoPlural = false;
    this.DM.MIB.Flag = (byte) 1;
    this.tmpPage[0] = 3;
    this.tmpPage[1] = 1;
    this.tmpPage[2] = 0;
    this.tmpPage[3] = 2;
    for (int index = 0; index < 4; ++index)
      this.Str_HeroColor[index] = this.DM.mStringTable.GetStringByID((uint) (ushort) (7651 + index));
    this.Title = this.GameT.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.Title.font = this.TTFont;
    this.Title.text = this.DM.mStringTable.GetStringByID((uint) (ushort) (this.tmpPage[this.NowPage] + 5391));
    for (int index = 0; index < 4; ++index)
    {
      this.btn_Page[index] = this.GameT.GetChild(1 + index).GetComponent<UIButton>();
      this.btn_Page[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Page[index].m_BtnID1 = 9 + index;
      this.Img_PageShow[index] = this.GameT.GetChild(1 + index).GetChild(0).GetComponent<Image>();
      this.Img_PageIcon[index] = this.GameT.GetChild(1 + index).GetChild(1).GetComponent<Image>();
      this.Img_PageIcon[index].sprite = this.SArray.m_Sprites[index * 2 + 1];
      this.Img_PageUnRead[index] = this.GameT.GetChild(1 + index).GetChild(2).GetComponent<Image>();
      this.Img_PageUnRead[index].sprite = this.door.LoadSprite("UI_main_redbox_01");
      ((MaskableGraphic) this.Img_PageUnRead[index]).material = this.door.LoadMaterial();
      this.PageImg_RT[index] = this.GameT.GetChild(1 + index).GetChild(2).GetComponent<RectTransform>();
      this.text_UnRead[index] = this.GameT.GetChild(1 + index).GetChild(2).GetChild(0).GetComponent<UIText>();
      this.PageText_RT[index] = this.GameT.GetChild(1 + index).GetChild(2).GetChild(0).GetComponent<RectTransform>();
      this.text_UnRead[index].font = this.TTFont;
    }
    this.UpdataUnRead();
    this.btn_Select = this.GameT.GetChild(5).GetComponent<UIButton>();
    this.btn_Select.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Select.m_BtnID1 = 1;
    this.btn_Select.m_EffectType = e_EffectType.e_Scale;
    this.btn_Select.transition = (Selectable.Transition) 0;
    if (this.GUIM.IsArabic)
      ((Component) this.btn_Select).gameObject.AddComponent<ArabicItemTextureRot>();
    this.btn_WL = this.GameT.GetChild(6).GetComponent<UIButton>();
    this.btn_WL.m_Handler = (IUIButtonClickHandler) this;
    this.btn_WL.m_BtnID1 = 2;
    this.btn_WL.m_EffectType = e_EffectType.e_Scale;
    this.btn_WL.transition = (Selectable.Transition) 0;
    this.ImgEditor = this.GameT.GetChild(6).GetChild(0).GetComponent<Image>();
    this.Tmp = this.GameT.GetChild(7);
    this.m_ScrollPanel = this.Tmp.GetChild(0).GetComponent<ScrollPanel>();
    this.Tmp1 = this.Tmp.GetChild(1);
    this.tmpbtn = this.Tmp1.GetChild(1).GetComponent<UIButton>();
    this.tmpbtn.m_Handler = (IUIButtonClickHandler) this;
    this.tmpbtn.m_BtnID1 = 3;
    this.tmpbtn.SoundIndex = (byte) 64;
    this.tmpbtn = this.Tmp1.GetChild(2).GetComponent<UIButton>();
    this.tmpbtn.m_Handler = (IUIButtonClickHandler) this;
    this.tmpImg = this.Tmp1.GetChild(3).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.tmpImg).transform.localScale = new Vector3(-1f, ((Component) this.tmpImg).transform.localScale.y, ((Component) this.tmpImg).transform.localScale.z);
    this.tmpbtn.m_BtnID1 = 4;
    this.tmpbtn.SoundIndex = (byte) 64;
    this.tmpbtn = this.Tmp1.GetChild(8).GetComponent<UIButton>();
    this.tmpbtn.m_Handler = (IUIButtonClickHandler) this;
    this.tmpbtn.m_BtnID1 = 5;
    this.tmpbtn.SoundIndex = (byte) 64;
    this.tmpImg = this.Tmp1.GetChild(9).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_redbox_01");
    ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
    this.tmptext = this.Tmp1.GetChild(9).GetChild(0).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = this.Tmp1.GetChild(11).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = this.Tmp1.GetChild(12).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = this.Tmp1.GetChild(13).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext.SetCheckArabic(true);
    this.tmptext = this.Tmp1.GetChild(14).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext.SetCheckArabic(true);
    this.tmptext = this.Tmp1.GetChild(15).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmplist.Clear();
    this.Datalist.Clear();
    this.btmpList.Clear();
    this.bReadList.Clear();
    this.m_ScrollPanel.IntiScrollPanel(501f, 0.0f, 0.0f, this.tmplist, 6, (IUpDateScrollPanel) this);
    this.tmpcontentRcT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
    this.ImgFunction = this.GameT.GetChild(8).GetComponent<Image>();
    this.btn_Delete = this.GameT.GetChild(8).GetChild(0).GetComponent<UIButton>();
    this.btn_Delete.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Delete.m_BtnID1 = 6;
    this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
    this.btn_Delete.transition = (Selectable.Transition) 0;
    this.btn_Read = this.GameT.GetChild(8).GetChild(1).GetComponent<UIButton>();
    this.btn_Read.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Read.m_BtnID1 = 7;
    this.btn_Read.m_EffectType = e_EffectType.e_Scale;
    this.btn_Read.transition = (Selectable.Transition) 0;
    this.btn_Cancel = this.GameT.GetChild(8).GetChild(2).GetComponent<UIButton>();
    this.btn_Cancel.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Cancel.m_BtnID1 = 8;
    this.btn_Cancel.m_EffectType = e_EffectType.e_Scale;
    this.btn_Cancel.transition = (Selectable.Transition) 0;
    this.ImgNoLetter = this.GameT.GetChild(9).GetComponent<Image>();
    this.NoLetterMsg = this.GameT.GetChild(9).GetChild(0).GetComponent<UIText>();
    this.NoLetterMsg.font = this.TTFont;
    this.NoLetterMsg.text = this.DM.mStringTable.GetStringByID(6016U);
    this.tmpImg = this.GameT.GetChild(10).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(10).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.m_Mat;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    if (this.DM.bPlural)
    {
      this.NowPageKind = 1;
      this.mPluralReplyID = this.DM.Letter_PluralReplyID;
      this.mPluralSenderName = this.DM.Letter_PluralSenderName;
      if (this.DM.GetMailboxSize(this.mPluralReplyID, this.mPluralSenderName) == 1)
      {
        this.DM.bPlural = false;
        this.NowPageKind = 0;
      }
    }
    this.SetPageData();
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void UpdataUnRead()
  {
    for (int MT = 0; MT < 4; ++MT)
    {
      int mailboxUnread = (int) this.DM.GetMailboxUnread((MailType) MT);
      if (mailboxUnread != 0)
        ((Component) this.Img_PageUnRead[MT]).gameObject.SetActive(true);
      else
        ((Component) this.Img_PageUnRead[MT]).gameObject.SetActive(false);
      this.text_UnRead[MT].text = mailboxUnread.ToString();
      this.PageImg_RT[MT].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_UnRead[MT].preferredWidth), this.PageImg_RT[MT].sizeDelta.y);
    }
  }

  public override void OnClose()
  {
    this.DM.Outlooking = false;
    this.SetAllSelect(false, false);
    if (this.Pending)
      this.GUIM.BattleSerialNo = 0U;
    else if (this.NowPageKind == 0)
    {
      this.DM.Letter_Y = this.tmpcontentRcT.anchoredPosition.y;
      this.DM.Letter_Idx = this.m_ScrollPanel.GetTopIdx();
    }
    else
    {
      this.DM.Letter_PluralY = this.tmpcontentRcT.anchoredPosition.y;
      this.DM.Letter_PluralIdx = this.m_ScrollPanel.GetTopIdx();
    }
    for (int index = 0; index < 6; ++index)
    {
      if (this.Cstr_PluralTotal[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_PluralTotal[index]);
      if (this.Cstrtext_1[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstrtext_1[index]);
      if (this.Cstrtext_2[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstrtext_2[index]);
      if (this.Cstrtext_3[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstrtext_3[index]);
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        this.CloseSelf();
        break;
      case 1:
        this.SetAllSelect(true);
        break;
      case 2:
        this.SetAllSelect(false);
        if (this.NowPageKind == 1)
        {
          this.DM.bPlural = true;
          this.DM.Letter_PluralReplyID = this.mPluralReplyID;
          this.DM.Letter_PluralSenderName = this.mPluralSenderName;
        }
        this.door.OpenMenu(EGUIWindow.UI_LetterEditor);
        break;
      case 3:
        if (!this.bOpenImg)
        {
          if (this.NowPageKind != 1)
          {
            this.DM.Letter_Y = this.tmpcontentRcT.anchoredPosition.y;
            this.DM.Letter_Idx = this.m_ScrollPanel.GetTopIdx();
          }
          Transform parent = ((Component) sender).gameObject.transform.parent;
          if (this.NowPage == 2)
          {
            MailContent mailContent;
            if (this.NowPageKind == 0)
            {
              mailContent = this.DM.MailReportGet(parent.GetComponent<ScrollPanelItem>().m_BtnID1);
            }
            else
            {
              mailContent = this.DM.MailReportGet(parent.GetComponent<ScrollPanelItem>().m_BtnID1, this.mPluralReplyID, this.mPluralSenderName);
              this.DM.bPlural = true;
              this.DM.Letter_PluralReplyID = this.mPluralReplyID;
              this.DM.Letter_PluralSenderName = this.mPluralSenderName;
            }
            if (((UIBehaviour) this.text_PluralTotal[parent.GetComponent<ScrollPanelItem>().m_BtnID2]).IsActive())
            {
              this.NowPageKind = 1;
              if (mailContent != null)
              {
                this.mPluralTotal = (int) mailContent.More;
                this.mPluralReplyID = mailContent.ReplyID;
                this.mPluralSenderName = mailContent.SenderName;
              }
              this.SetPageData();
              break;
            }
            if (mailContent == null)
              break;
            this.DM.OpenMail.Serial = mailContent.SerialID;
            this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
            break;
          }
          if (this.NowPage == 1)
          {
            CombatReport combatReport = this.DM.CombatReportGet(parent.GetComponent<ScrollPanelItem>().m_BtnID1);
            if (combatReport == null)
              break;
            this.DM.OpenMail.Serial = combatReport.SerialID;
            switch (combatReport.Type)
            {
              case CombatCollectReport.CCR_BATTLE:
              case CombatCollectReport.CCR_NPCCOMBAT:
                this.door.OpenMenu(EGUIWindow.UI_FightingSummary);
                return;
              case CombatCollectReport.CCR_RESOURCE:
                this.door.OpenMenu(EGUIWindow.UI_Letter_Resources);
                return;
              case CombatCollectReport.CCR_COLLECT:
                this.door.OpenMenu(EGUIWindow.UI_Letter_Collection);
                return;
              case CombatCollectReport.CCR_SCOUT:
                if (combatReport.Scout.ScoutLevel != (byte) 0)
                {
                  this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower);
                  return;
                }
                this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 1);
                return;
              case CombatCollectReport.CCR_RECON:
                this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon);
                return;
              case CombatCollectReport.CCR_MONSTER:
                if (combatReport.Monster.Result < (byte) 2 || combatReport.Monster.Result > (byte) 3)
                {
                  this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 1);
                  return;
                }
                this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
                return;
              case CombatCollectReport.CCR_NPCSCOUT:
                if (combatReport.NPCScout.ScoutLevel != (byte) 0)
                {
                  this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout);
                  return;
                }
                this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout, 1);
                return;
              case CombatCollectReport.CCR_PETREPORT:
                this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS);
                return;
              default:
                return;
            }
          }
          else if (this.NowPage == 3)
          {
            MyFavorite myFavorite = this.DM.FavorReportGet(parent.GetComponent<ScrollPanelItem>().m_BtnID1);
            if (myFavorite == null)
              break;
            switch (myFavorite.Type)
            {
              case MailType.EMAIL_SYSTEM:
                this.DM.OpenMail.Type = myFavorite.Type;
                this.DM.OpenMail.Serial = myFavorite.System.SerialID;
                this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
                return;
              case MailType.EMAIL_BATTLE:
                this.DM.OpenMail.Type = myFavorite.Type;
                this.DM.OpenMail.Serial = myFavorite.Combat.SerialID;
                switch (myFavorite.Combat.Type)
                {
                  case CombatCollectReport.CCR_BATTLE:
                  case CombatCollectReport.CCR_NPCCOMBAT:
                    this.door.OpenMenu(EGUIWindow.UI_FightingSummary);
                    return;
                  case CombatCollectReport.CCR_RESOURCE:
                    return;
                  case CombatCollectReport.CCR_COLLECT:
                    return;
                  case CombatCollectReport.CCR_SCOUT:
                    if (myFavorite.Combat.Scout.ScoutLevel != (byte) 0)
                    {
                      this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower);
                      return;
                    }
                    this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 1);
                    return;
                  case CombatCollectReport.CCR_RECON:
                    this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon);
                    return;
                  case CombatCollectReport.CCR_MONSTER:
                    if (myFavorite.Combat.Monster.Result < (byte) 2 || myFavorite.Combat.Monster.Result > (byte) 3)
                    {
                      this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 1);
                      return;
                    }
                    this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
                    return;
                  case CombatCollectReport.CCR_NPCSCOUT:
                    if (myFavorite.Combat.NPCScout.ScoutLevel != (byte) 0)
                    {
                      this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout);
                      return;
                    }
                    this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout, 1);
                    return;
                  case CombatCollectReport.CCR_PETREPORT:
                    this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS);
                    return;
                  default:
                    return;
                }
              case MailType.EMAIL_LETTER:
                this.DM.OpenMail.Type = myFavorite.Type;
                this.DM.OpenMail.Serial = myFavorite.Mail.SerialID;
                this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
                return;
              default:
                return;
            }
          }
          else
          {
            if (this.NowPage != 0)
              break;
            NoticeContent noticeContent = this.DM.SystemReportGet(parent.GetComponent<ScrollPanelItem>().m_BtnID1);
            if (noticeContent == null)
              break;
            this.DM.OpenMail.Type = MailType.EMAIL_SYSTEM;
            this.DM.OpenMail.Serial = noticeContent.SerialID;
            this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
            break;
          }
        }
        else
        {
          this.CheckSelect(sender);
          break;
        }
      case 4:
        this.CheckSelect(sender);
        break;
      case 5:
        if (this.bOpenImg || this.NowPage == 3)
          break;
        Transform parent1 = ((Component) sender).gameObject.transform.parent;
        if (this.NowPage == 2)
        {
          if (this.NowPageKind == 1)
          {
            this.DM.MailReportSave(parent1.GetComponent<ScrollPanelItem>().m_BtnID1, this.mPluralReplyID, this.mPluralSenderName);
            break;
          }
          this.DM.MailReportSave(parent1.GetComponent<ScrollPanelItem>().m_BtnID1);
          break;
        }
        if (this.NowPage == 1)
        {
          this.DM.BattleReportSave(parent1.GetComponent<ScrollPanelItem>().m_BtnID1);
          break;
        }
        if (this.NowPage == 0)
        {
          this.DM.SystemReportSave(parent1.GetComponent<ScrollPanelItem>().m_BtnID1);
          break;
        }
        if (this.btmpList.Count < parent1.GetComponent<ScrollPanelItem>().m_BtnID1)
          break;
        for (int btnId1 = parent1.GetComponent<ScrollPanelItem>().m_BtnID1; btnId1 < this.Datalist.Count - 1; ++btnId1)
          this.Datalist[btnId1] = this.Datalist[btnId1 + 1];
        this.btmpList.RemoveAt(this.btmpList.Count - 1);
        this.bReadList.RemoveAt(this.btmpList.Count - 1);
        this.Datalist.RemoveAt(this.Datalist.Count - 1);
        this.tmplist.RemoveAt(this.tmplist.Count - 1);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        break;
      case 6:
        if (this.NowPage == 2)
        {
          if (this.NowPageKind == 1)
            this.DM.MailReportDelete(0U, this.mPluralReplyID, this.mPluralSenderName);
          else
            this.DM.MailReportDelete(0U);
        }
        else if (this.NowPage == 1)
          this.DM.BattleReportDelete(0U);
        else if (this.NowPage == 3)
          this.DM.FavorReportDelete(0U);
        else if (this.NowPage == 0)
          this.DM.SystemReportDelete(0U);
        this.SetAllSelect(false);
        ((Component) this.ImgFunction).gameObject.SetActive(false);
        break;
      case 7:
        if (this.NowPage == 2)
        {
          if (this.NowPageKind == 1)
            this.DM.MailReportRead(0U, this.mPluralReplyID, this.mPluralSenderName);
          else
            this.DM.MailReportRead(0U);
        }
        else if (this.NowPage == 1)
          this.DM.BattleReportRead(0U);
        else if (this.NowPage == 3)
          this.DM.FavorReportRead(0U);
        else if (this.NowPage == 0)
          this.DM.SystemReportRead(0U);
        this.SetAllSelect(false);
        ((Component) this.ImgFunction).gameObject.SetActive(false);
        break;
      case 8:
        this.SetAllSelect(false);
        this.bOpenImg = false;
        break;
      case 9:
      case 10:
      case 11:
      case 12:
        this.SetAllSelect(false);
        if (this.NowPage == sender.m_BtnID1 - 9)
          break;
        this.tmplist.Clear();
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist);
        ((Graphic) this.Img_PageShow[this.NowPage]).color = new Color(1f, 1f, 1f, 0.0f);
        this.NowPage = sender.m_BtnID1 - 9;
        this.PageShowTime = 0.0f;
        this.DM.Letter_Y = -1f;
        this.NowPageKind = 0;
        this.DM.bPlural = false;
        this.SetPageData();
        break;
    }
  }

  private void CloseSelf()
  {
    if (this.NowPageKind == 1)
    {
      this.SetAllSelect(false);
      this.bOpenImg = false;
      this.NowPageKind = 0;
      this.DM.bPlural = false;
      this.DM.Letter_PluralY = -1f;
      this.DM.Letter_PluralIdx = -1;
      this.SetPageData();
    }
    else
    {
      if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
        return;
      this.door.CloseMenu();
    }
  }

  public override bool OnBackButtonClick()
  {
    this.CloseSelf();
    return true;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.UpdateMailData();
        break;
      case NetworkNews.Refresh_Mailbox:
        this.UpdataUnRead();
        break;
      case NetworkNews.Refresh_Mailing:
        if (!this.Pending && this.NowPageKind == 0)
        {
          this.DM.Letter_Y = this.tmpcontentRcT.anchoredPosition.y;
          this.DM.Letter_Idx = this.m_ScrollPanel.GetTopIdx();
        }
        if (this.NowPageKind == 1 && this.DM.GetMailboxSize(this.mPluralReplyID, this.mPluralSenderName) <= 1)
          this.NowPageKind = 0;
        this.SetPageData();
        break;
      case NetworkNews.Refresh_Letter:
        if (!this.bTrans)
          break;
        if (this.NowPage == 2)
        {
          for (int index = 0; index < 6; ++index)
          {
            if ((UnityEngine.Object) this.tmpItem[index] != (UnityEngine.Object) null && (UnityEngine.Object) this.text_2[index] != (UnityEngine.Object) null && (UnityEngine.Object) this.text_3[index] != (UnityEngine.Object) null)
            {
              this.Cstrtext_2[index].ClearString();
              this.Cstrtext_3[index].ClearString();
              MailContent mailContent = this.NowPageKind != 0 ? this.DM.MailReportGet(this.tmpItem[index].m_BtnID1, this.mPluralReplyID, this.mPluralSenderName) : this.DM.MailReportGet(this.tmpItem[index].m_BtnID1);
              if (mailContent != null)
              {
                if (mailContent.MailType == (byte) 1)
                  this.Cstrtext_2[index].Append(this.DM.mStringTable.GetStringByID(6014U));
                if (mailContent.Translation && mailContent.MailType != (byte) 2 && this.DM.CheckLanguageTranslateByIdx((int) mailContent.LanguageSource) && (GameLanguage) mailContent.LanguageTarget == this.DM.UserLanguage && this.GUIM.CheckNeedTranslate(mailContent.Title))
                  this.Cstrtext_2[index].Append(mailContent.TitleT);
                else
                  this.Cstrtext_2[index].Append(mailContent.Title);
                this.text_2[index].text = this.Cstrtext_2[index].ToString();
                this.text_2[index].SetAllDirty();
                this.text_2[index].cachedTextGenerator.Invalidate();
                if (mailContent.Translation && mailContent.MailType != (byte) 2 && this.DM.CheckLanguageTranslateByIdx((int) mailContent.LanguageSource) && (GameLanguage) mailContent.LanguageTarget == this.DM.UserLanguage)
                  this.Cstrtext_3[index].Append(mailContent.ContentT);
                else
                  this.Cstrtext_3[index].Append(mailContent.Content);
                this.text_3[index].text = this.Cstrtext_3[index].ToString();
                this.text_3[index].SetAllDirty();
                this.text_3[index].cachedTextGenerator.Invalidate();
              }
            }
          }
          break;
        }
        if (this.NowPage != 3)
          break;
        for (int index = 0; index < 6; ++index)
        {
          if ((UnityEngine.Object) this.tmpItem[index] != (UnityEngine.Object) null && (UnityEngine.Object) this.text_2[index] != (UnityEngine.Object) null && (UnityEngine.Object) this.text_3[index] != (UnityEngine.Object) null)
          {
            this.Cstrtext_2[index].ClearString();
            this.Cstrtext_3[index].ClearString();
            MyFavorite myFavorite = this.DM.FavorReportGet(this.tmpItem[index].m_BtnID1);
            if (myFavorite != null && myFavorite.Type == MailType.EMAIL_LETTER)
            {
              MailContent mail = myFavorite.Mail;
              if (mail.MailType == (byte) 1)
                this.Cstrtext_2[index].Append(this.DM.mStringTable.GetStringByID(6014U));
              if (mail.Translation && mail.MailType != (byte) 2 && this.DM.CheckLanguageTranslateByIdx((int) mail.LanguageSource) && (GameLanguage) mail.LanguageTarget == this.DM.UserLanguage && this.GUIM.CheckNeedTranslate(mail.Title))
                this.Cstrtext_2[index].Append(mail.TitleT);
              else
                this.Cstrtext_2[index].Append(mail.Title);
              this.text_2[index].text = this.Cstrtext_2[index].ToString();
              this.text_2[index].SetAllDirty();
              this.text_2[index].cachedTextGenerator.Invalidate();
              if (mail.Translation && mail.MailType != (byte) 2 && this.DM.CheckLanguageTranslateByIdx((int) mail.LanguageSource) && (GameLanguage) mail.LanguageTarget == this.DM.UserLanguage)
                this.Cstrtext_3[index].Append(mail.ContentT);
              else
                this.Cstrtext_3[index].Append(mail.Content);
              this.text_3[index].text = this.Cstrtext_3[index].ToString();
              this.text_3[index].SetAllDirty();
              this.text_3[index].cachedTextGenerator.Invalidate();
            }
          }
        }
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.Title != (UnityEngine.Object) null && ((Behaviour) this.Title).enabled)
    {
      ((Behaviour) this.Title).enabled = false;
      ((Behaviour) this.Title).enabled = true;
    }
    if ((UnityEngine.Object) this.NoLetterMsg != (UnityEngine.Object) null && ((Behaviour) this.NoLetterMsg).enabled)
    {
      ((Behaviour) this.NoLetterMsg).enabled = false;
      ((Behaviour) this.NoLetterMsg).enabled = true;
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((UnityEngine.Object) this.text_UnRead[index] != (UnityEngine.Object) null && ((Behaviour) this.text_UnRead[index]).enabled)
      {
        ((Behaviour) this.text_UnRead[index]).enabled = false;
        ((Behaviour) this.text_UnRead[index]).enabled = true;
      }
    }
    for (int index = 0; index < 6; ++index)
    {
      if ((UnityEngine.Object) this.text_Time[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Time[index]).enabled)
      {
        ((Behaviour) this.text_Time[index]).enabled = false;
        ((Behaviour) this.text_Time[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_1[index] != (UnityEngine.Object) null && ((Behaviour) this.text_1[index]).enabled)
      {
        ((Behaviour) this.text_1[index]).enabled = false;
        ((Behaviour) this.text_1[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_2[index] != (UnityEngine.Object) null && ((Behaviour) this.text_2[index]).enabled)
      {
        ((Behaviour) this.text_2[index]).enabled = false;
        ((Behaviour) this.text_2[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_3[index] != (UnityEngine.Object) null && ((Behaviour) this.text_3[index]).enabled)
      {
        ((Behaviour) this.text_3[index]).enabled = false;
        ((Behaviour) this.text_3[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_PluralNoRead[index] != (UnityEngine.Object) null && ((Behaviour) this.text_PluralNoRead[index]).enabled)
      {
        ((Behaviour) this.text_PluralNoRead[index]).enabled = false;
        ((Behaviour) this.text_PluralNoRead[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_PluralTotal[index] != (UnityEngine.Object) null && ((Behaviour) this.text_PluralTotal[index]).enabled)
      {
        ((Behaviour) this.text_PluralTotal[index]).enabled = false;
        ((Behaviour) this.text_PluralTotal[index]).enabled = true;
      }
    }
  }

  public bool UpdateMailData()
  {
    switch (this.NowPage)
    {
      case 0:
        this.DM.OpenMail.Kind = this.DM.OpenMail.Type = (MailType) this.NowPage;
        return this.DM.CheckMail(Protocol._MSG_REQUEST_NOTICEINFO) && this.DM.Mailing.SystemSerial.New == 0U;
      case 1:
        this.DM.OpenMail.Kind = this.DM.OpenMail.Type = (MailType) this.NowPage;
        return this.DM.CheckMail(Protocol._MSG_REQUEST_REPORTINFO) && this.DM.Mailing.ReportSerial.New == 0U;
      case 2:
        this.DM.OpenMail.Kind = this.DM.OpenMail.Type = (MailType) this.NowPage;
        return this.DM.CheckMail() && this.DM.Mailing.MailSerial.New == 0U;
      case 3:
        this.DM.OpenMail.Kind = (MailType) this.NowPage;
        this.DM.Mailing.FavorSerial.Pulling = true;
        this.DM.CheckMail(Protocol._MSG_REQUEST_REPORTINFO);
        this.DM.CheckMail(Protocol._MSG_REQUEST_NOTICEINFO);
        this.DM.CheckMail();
        break;
    }
    return false;
  }

  public void SetPageData()
  {
    if (this.UpdateMailData() || this.GUIM.BattleSerialNo > 0U)
      return;
    this.Title.text = this.NowPage >= 4 ? this.DM.mStringTable.GetStringByID((uint) (ushort) (this.tmpPage[3] + 5391)) : this.DM.mStringTable.GetStringByID((uint) (ushort) (this.tmpPage[this.NowPage] + 5391));
    bool flag = false;
    switch (this.NowPage)
    {
      case 0:
        this.tmplist.Clear();
        this.Datalist.Clear();
        this.btmpList.Clear();
        this.bReadList.Clear();
        this.bCheckList.Clear();
        this.DM.MailDataRefresh((MailType) this.NowPage);
        for (int id = 0; (long) id < (long) this.DM.Mailing.SystemSerial.Count; ++id)
        {
          if (((UIBehaviour) this.ImgFunction).IsActive() && !flag)
          {
            NoticeContent noticeContent = this.DM.SystemReportGet(id);
            if (noticeContent != null && noticeContent.BeChecked)
              flag = true;
          }
          this.tmplist.Add(97f);
          this.Datalist.Add((float) id);
          this.btmpList.Add(false);
          this.bReadList.Add(false);
        }
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        if ((double) this.DM.Letter_Y > -1.0)
          this.m_ScrollPanel.GoTo(this.DM.Letter_Idx, this.DM.Letter_Y);
        this.MaxLetterNum = (int) this.DM.GetMailboxSize(MailType.EMAIL_SYSTEM);
        break;
      case 1:
        this.tmplist.Clear();
        this.Datalist.Clear();
        this.btmpList.Clear();
        this.bReadList.Clear();
        this.bCheckList.Clear();
        this.DM.MailDataRefresh((MailType) this.NowPage);
        for (int id = 0; (long) id < (long) this.DM.Mailing.ReportSerial.Count; ++id)
        {
          if (((UIBehaviour) this.ImgFunction).IsActive() && !flag)
          {
            CombatReport combatReport = this.DM.CombatReportGet(id);
            if (combatReport != null && combatReport.BeChecked)
              flag = true;
          }
          this.tmplist.Add(97f);
          this.Datalist.Add((float) id);
          this.btmpList.Add(false);
          this.bReadList.Add(false);
        }
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        if ((double) this.DM.Letter_Y > -1.0)
          this.m_ScrollPanel.GoTo(this.DM.Letter_Idx, this.DM.Letter_Y);
        this.MaxLetterNum = (int) this.DM.GetMailboxSize(MailType.EMAIL_BATTLE);
        break;
      case 2:
        this.tmplist.Clear();
        this.Datalist.Clear();
        this.btmpList.Clear();
        this.bReadList.Clear();
        this.bCheckList.Clear();
        if (this.NowPageKind == 0)
        {
          for (int id = 0; (long) id < (long) this.DM.Mailing.MailSerial.Count; ++id)
          {
            if (((UIBehaviour) this.ImgFunction).IsActive() && !flag)
            {
              MailContent mailContent = this.DM.MailReportGet(id);
              if (mailContent != null && mailContent.BeChecked)
                flag = true;
            }
            this.tmplist.Add(97f);
            this.Datalist.Add((float) id);
            this.btmpList.Add(false);
            this.bReadList.Add(false);
          }
          this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
          if ((double) this.DM.Letter_Y > -1.0)
            this.m_ScrollPanel.GoTo(this.DM.Letter_Idx, this.DM.Letter_Y);
          this.MaxLetterNum = (int) this.DM.GetMailboxSize(MailType.EMAIL_LETTER);
          break;
        }
        for (int id = 0; id < this.DM.GetMailboxSize(this.mPluralReplyID, this.mPluralSenderName); ++id)
        {
          if (((UIBehaviour) this.ImgFunction).IsActive() && !flag)
          {
            MailContent mailContent = this.DM.MailReportGet(id, this.mPluralReplyID, this.mPluralSenderName);
            if (mailContent != null && mailContent.BeChecked)
              flag = true;
          }
          this.tmplist.Add(97f);
          this.Datalist.Add((float) id);
          this.btmpList.Add(false);
          this.bReadList.Add(false);
        }
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        if ((double) this.DM.Letter_PluralY > -1.0)
          this.m_ScrollPanel.GoTo(this.DM.Letter_PluralIdx, this.DM.Letter_PluralY);
        this.MaxLetterNum = this.DM.GetMailboxSize(this.mPluralReplyID, this.mPluralSenderName);
        break;
      case 3:
        this.tmplist.Clear();
        this.Datalist.Clear();
        this.btmpList.Clear();
        this.bReadList.Clear();
        this.bCheckList.Clear();
        this.DM.MailDataRefresh((MailType) this.NowPage);
        for (int id = 0; (long) id < (long) this.DM.Mailing.FavorSerial.Count; ++id)
        {
          MyFavorite myFavorite = this.DM.FavorReportGet(id);
          if (myFavorite != null)
          {
            if (myFavorite.Type == MailType.EMAIL_LETTER)
            {
              if (((UIBehaviour) this.ImgFunction).IsActive() && !flag && myFavorite.Mail.BeChecked)
                flag = true;
            }
            else if (myFavorite.Type == MailType.EMAIL_BATTLE)
            {
              if (((UIBehaviour) this.ImgFunction).IsActive() && !flag && myFavorite.Combat.BeChecked)
                flag = true;
            }
            else if (myFavorite.Type == MailType.EMAIL_SYSTEM && ((UIBehaviour) this.ImgFunction).IsActive() && !flag && myFavorite.System.BeChecked)
              flag = true;
          }
          this.tmplist.Add(97f);
          this.Datalist.Add((float) id);
          this.btmpList.Add(false);
          this.bReadList.Add(false);
        }
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        if ((double) this.DM.Letter_Y > -1.0)
          this.m_ScrollPanel.GoTo(this.DM.Letter_Idx, this.DM.Letter_Y);
        this.MaxLetterNum = (int) this.DM.GetMailboxSize(MailType.EMAIL_FAVORY);
        break;
      case 5:
        this.MaxLetterNum = this.mPluralTotal;
        this.tmplist.Clear();
        this.Datalist.Clear();
        this.btmpList.Clear();
        this.bReadList.Clear();
        this.bCheckList.Clear();
        for (int id = 0; id < this.MaxLetterNum; ++id)
        {
          if (((UIBehaviour) this.ImgFunction).IsActive() && !flag && this.DM.MailReportGet(id, this.mPluralReplyID, this.mPluralSenderName).BeChecked)
            flag = true;
          this.tmplist.Add(97f);
          this.Datalist.Add((float) id);
          this.btmpList.Add(false);
          this.bReadList.Add(false);
        }
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        break;
    }
    if (!flag && ((UIBehaviour) this.ImgFunction).IsActive())
    {
      ((Component) this.ImgFunction).gameObject.SetActive(false);
      this.bOpenImg = false;
    }
    if (this.tmplist.Count == 0 && !((UIBehaviour) this.ImgNoLetter).IsActive())
      ((Component) this.ImgNoLetter).gameObject.SetActive(true);
    else if (this.tmplist.Count > 0 && ((UIBehaviour) this.ImgNoLetter).IsActive())
      ((Component) this.ImgNoLetter).gameObject.SetActive(false);
    this.UpdataUnRead();
  }

  public void SetAllSelect(bool bAllSelect, bool Refresh = true)
  {
    if (this.AllSelect < this.MaxLetterNum && bAllSelect)
    {
      this.AllSelect = this.MaxLetterNum;
    }
    else
    {
      this.AllSelect = 0;
      bAllSelect = false;
    }
    if (this.NowPage == 2)
    {
      if (this.NowPageKind == 1)
      {
        this.DM.MailReportSelect(!bAllSelect ? 0 : -1, this.mPluralReplyID, this.mPluralSenderName, Refresh);
        this.bOpenImg = this.DM.Mailing.MailSerial.Select > 0U;
      }
      else
      {
        this.DM.MailReportSelect(!bAllSelect ? 0 : -1, Refresh);
        this.bOpenImg = this.DM.Mailing.MailSerial.Select > 0U;
      }
    }
    else if (this.NowPage == 1)
    {
      this.DM.CombatReportSelect(!bAllSelect ? 0 : -1, Refresh);
      this.bOpenImg = this.DM.Mailing.ReportSerial.Select > 0U;
    }
    else if (this.NowPage == 3)
    {
      this.DM.FavorReportSelect(-1, bAllSelect, Refresh);
      this.bOpenImg = this.DM.Mailing.FavorSerial.Select > 0U;
    }
    else if (this.NowPage == 0)
    {
      this.DM.SystemReportSelect(!bAllSelect ? 0 : -1, Refresh);
      this.bOpenImg = this.DM.Mailing.SystemSerial.Select > 0U;
    }
    if (this.bOpenImg)
      ((Component) this.ImgFunction).gameObject.SetActive(true);
    else
      ((Component) this.ImgFunction).gameObject.SetActive(false);
  }

  public void CheckSelect(UIButton sender)
  {
    Transform parent = ((Component) sender).gameObject.transform.parent;
    int btnId1 = parent.GetComponent<ScrollPanelItem>().m_BtnID1;
    int btnId2 = parent.GetComponent<ScrollPanelItem>().m_BtnID2;
    if (this.NowPage == 2)
    {
      MailContent mailContent = this.NowPageKind != 1 ? this.DM.MailReportGet(btnId1) : this.DM.MailReportGet(btnId1, this.mPluralReplyID, this.mPluralSenderName);
      if (mailContent != null)
      {
        if (this.NowPageKind == 1)
          this.DM.MailReportSelect((int) mailContent.SerialID, mailContent.ReplyID, mailContent.SenderName);
        else
          this.DM.MailReportSelect((int) mailContent.SerialID);
        if (mailContent.BeChecked)
        {
          this.bCheckList.Add(mailContent.SerialID);
          ((Component) this.ImgSelect[btnId2]).gameObject.SetActive(true);
          ++this.AllSelect;
        }
        else
        {
          this.bCheckList.Remove(mailContent.SerialID);
          ((Component) this.ImgSelect[btnId2]).gameObject.SetActive(false);
          --this.AllSelect;
        }
        this.bOpenImg = this.DM.Mailing.MailSerial.Select > 0U;
      }
    }
    else if (this.NowPage == 1)
    {
      CombatReport combatReport = this.DM.CombatReportGet(btnId1);
      if (combatReport != null)
      {
        this.DM.CombatReportSelect((int) combatReport.SerialID);
        if (combatReport.BeChecked)
        {
          this.bCheckList.Add(combatReport.SerialID);
          ((Component) this.ImgSelect[btnId2]).gameObject.SetActive(true);
          ++this.AllSelect;
        }
        else
        {
          this.bCheckList.Remove(combatReport.SerialID);
          ((Component) this.ImgSelect[btnId2]).gameObject.SetActive(false);
          --this.AllSelect;
        }
        this.bOpenImg = this.DM.Mailing.ReportSerial.Select > 0U;
      }
    }
    else if (this.NowPage == 3)
    {
      ((Component) this.ImgSelect[btnId2]).gameObject.SetActive(this.DM.FavorReportSelect(btnId1));
      this.bOpenImg = this.DM.Mailing.FavorSerial.Select > 0U;
    }
    else if (this.NowPage == 0)
    {
      NoticeContent noticeContent = this.DM.SystemReportGet(btnId1);
      if (noticeContent != null)
      {
        this.DM.SystemReportSelect((int) noticeContent.SerialID);
        if (noticeContent.BeChecked)
        {
          this.bCheckList.Add(noticeContent.SerialID);
          ((Component) this.ImgSelect[btnId2]).gameObject.SetActive(true);
          ++this.AllSelect;
        }
        else
        {
          this.bCheckList.Remove(noticeContent.SerialID);
          ((Component) this.ImgSelect[btnId2]).gameObject.SetActive(false);
          --this.AllSelect;
        }
        this.bOpenImg = this.DM.Mailing.SystemSerial.Select > 0U;
      }
    }
    else if (this.btmpList.Count >= btnId1)
    {
      if (!this.btmpList[btnId1])
      {
        this.btmpList[btnId1] = true;
        ((Component) this.ImgSelect[btnId2]).gameObject.SetActive(true);
        ++this.AllSelect;
        if (!this.bOpenImg)
          this.bOpenImg = true;
      }
      else
      {
        this.btmpList[btnId1] = false;
        ((Component) this.ImgSelect[btnId2]).gameObject.SetActive(false);
        --this.AllSelect;
        bool flag = false;
        for (int index = 0; index < 30; ++index)
        {
          if (this.btmpList[index])
          {
            flag = true;
            break;
          }
        }
        if (!flag)
          this.bOpenImg = false;
      }
    }
    if (this.bOpenImg)
    {
      if (((UIBehaviour) this.ImgFunction).IsActive())
        return;
      ((Component) this.ImgFunction).gameObject.SetActive(true);
    }
    else
      ((Component) this.ImgFunction).gameObject.SetActive(false);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    this.ItemT = item.GetComponent<Transform>();
    if ((UnityEngine.Object) this.tmpItem[panelObjectIdx] == (UnityEngine.Object) null)
    {
      this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
      if (this.Datalist.Count > 0 && this.Datalist.Count >= dataIdx)
      {
        this.ImgNoRead2[panelObjectIdx] = this.ItemT.GetChild(0).GetComponent<Image>();
        this.btn_ItemDetail[panelObjectIdx] = this.ItemT.GetChild(1).GetComponent<UIButton>();
        this.btn_ItemDetail[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
        this.btn_ItemSelect[panelObjectIdx] = this.ItemT.GetChild(2).GetComponent<UIButton>();
        this.btn_ItemSelect[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
        this.ImgSelect[panelObjectIdx] = this.ItemT.GetChild(3).GetComponent<Image>();
        if (this.btmpList[dataIdx])
          ((Component) this.ImgSelect[panelObjectIdx]).gameObject.SetActive(true);
        else
          ((Component) this.ImgSelect[panelObjectIdx]).gameObject.SetActive(false);
        this.ImgNoRead[panelObjectIdx] = this.ItemT.GetChild(4).GetComponent<Image>();
        this.ImgRead[panelObjectIdx] = this.ItemT.GetChild(5).GetComponent<Image>();
        this.ImgIcon[panelObjectIdx] = this.ItemT.GetChild(6).GetComponent<Image>();
        this.ImgIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[10 + this.mIcon];
        this.ImgBookMark[panelObjectIdx] = this.ItemT.GetChild(7).GetComponent<Image>();
        this.btn_ItemCollect[panelObjectIdx] = this.ItemT.GetChild(8).GetComponent<UIButton>();
        this.btn_ItemCollect[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
        this.btn_ItemCollect[panelObjectIdx].image.sprite = this.SArray.m_Sprites[20];
        this.ImgPlural[panelObjectIdx] = this.ItemT.GetChild(9).GetComponent<Image>();
        this.Plural_RT[panelObjectIdx] = this.ItemT.GetChild(9).GetComponent<RectTransform>();
        this.text_PluralNoRead[panelObjectIdx] = this.ItemT.GetChild(9).GetChild(0).GetComponent<UIText>();
        this.text_Time[panelObjectIdx] = this.ItemT.GetChild(11).GetComponent<UIText>();
        this.text_1[panelObjectIdx] = this.ItemT.GetChild(12).GetComponent<UIText>();
        this.mtextOutline[panelObjectIdx] = this.ItemT.GetChild(12).GetComponent<Outline>();
        this.mtextShadow[panelObjectIdx] = this.ItemT.GetChild(12).GetComponent<Shadow>();
        this.text_2[panelObjectIdx] = this.ItemT.GetChild(13).GetComponent<UIText>();
        this.text_2[panelObjectIdx].SetCheckArabic(true);
        this.text_3[panelObjectIdx] = this.ItemT.GetChild(14).GetComponent<UIText>();
        this.text_3[panelObjectIdx].SetCheckArabic(true);
        this.text_PluralTotal[panelObjectIdx] = this.ItemT.GetChild(15).GetComponent<UIText>();
      }
    }
    else
    {
      this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
      if (this.Datalist.Count > 0 && this.Datalist.Count >= dataIdx)
        this.btn_ItemCollect[panelObjectIdx].image.sprite = this.SArray.m_Sprites[20];
    }
    this.ImgIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[10 + this.mIcon];
    this.Cstrtext_1[panelObjectIdx].ClearString();
    this.Cstrtext_2[panelObjectIdx].ClearString();
    this.Cstrtext_3[panelObjectIdx].ClearString();
    CString cstring = StringManager.Instance.StaticString1024();
    CString Name = StringManager.Instance.StaticString1024();
    CString Tag = StringManager.Instance.StaticString1024();
    if (this.NowPage == 2)
    {
      MailContent mailContent = this.NowPageKind != 0 ? this.DM.MailReportGet(dataIdx, this.mPluralReplyID, this.mPluralSenderName) : this.DM.MailReportGet(dataIdx);
      if (mailContent != null)
      {
        if (mailContent.SenderTag.Length != 0)
        {
          cstring.ClearString();
          Name.ClearString();
          Tag.ClearString();
          if (mailContent.MailType != (byte) 3)
          {
            if (mailContent.MailType == (byte) 4)
            {
              Name.Append(mailContent.SenderName);
              Tag.Append(mailContent.SenderTag);
              this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
              this.Cstrtext_1[panelObjectIdx].StringToFormat(cstring);
              this.Cstrtext_1[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(11055U));
            }
            else
            {
              Name.Append(mailContent.SenderName);
              Tag.Append(mailContent.SenderTag);
              GameConstants.FormatRoleName(this.Cstrtext_1[panelObjectIdx], Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
            }
          }
          else
          {
            Name.Append(mailContent.SenderName);
            Tag.Append(mailContent.SenderTag);
            if ((int) mailContent.SenderKindom != (int) DataManager.MapDataController.kingdomData.kingdomID)
              this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, mailContent.SenderKindom, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
            this.Cstrtext_1[panelObjectIdx].StringToFormat(cstring);
            this.Cstrtext_1[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(1473U));
          }
        }
        else if (mailContent.MailType == (byte) 2)
        {
          this.Cstrtext_1[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(8252U));
          this.Cstrtext_2[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(8257U));
        }
        else if (mailContent.MailType == (byte) 4)
        {
          this.Cstrtext_1[panelObjectIdx].StringToFormat(mailContent.SenderName);
          this.Cstrtext_1[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(11055U));
        }
        else
          this.Cstrtext_1[panelObjectIdx].Append(mailContent.SenderName);
        this.text_1[panelObjectIdx].text = this.Cstrtext_1[panelObjectIdx].ToString();
        if (mailContent.MailType == (byte) 1)
          this.Cstrtext_2[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(6014U));
        else if (mailContent.MailType == (byte) 3)
          this.Cstrtext_2[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(1474U));
        if (this.bTrans && mailContent.Translation && mailContent.MailType != (byte) 2 && this.DM.CheckLanguageTranslateByIdx((int) mailContent.LanguageSource) && (GameLanguage) mailContent.LanguageTarget == this.DM.UserLanguage && this.GUIM.CheckNeedTranslate(mailContent.Title))
          this.Cstrtext_2[panelObjectIdx].Append(mailContent.TitleT);
        else
          this.Cstrtext_2[panelObjectIdx].Append(mailContent.Title);
        this.text_2[panelObjectIdx].text = this.Cstrtext_2[panelObjectIdx].ToString();
        if (this.bTrans && mailContent.Translation && mailContent.MailType != (byte) 2 && this.DM.CheckLanguageTranslateByIdx((int) mailContent.LanguageSource) && (GameLanguage) mailContent.LanguageTarget == this.DM.UserLanguage)
          this.Cstrtext_3[panelObjectIdx].Append(mailContent.ContentT);
        else
          this.Cstrtext_3[panelObjectIdx].Append(mailContent.Content);
        this.text_3[panelObjectIdx].text = this.Cstrtext_3[panelObjectIdx].ToString();
        this.text_Time[panelObjectIdx].text = mailContent.DateTime;
        if (mailContent.BeChecked)
          ((Component) this.ImgSelect[panelObjectIdx]).gameObject.SetActive(true);
        else
          ((Component) this.ImgSelect[panelObjectIdx]).gameObject.SetActive(false);
        if (mailContent.BeRead)
        {
          ((Component) this.ImgNoRead2[panelObjectIdx]).gameObject.SetActive(false);
          ((Behaviour) this.mtextOutline[panelObjectIdx]).enabled = false;
          ((Behaviour) this.mtextShadow[panelObjectIdx]).enabled = false;
        }
        else
        {
          ((Component) this.ImgNoRead2[panelObjectIdx]).gameObject.SetActive(true);
          ((Behaviour) this.mtextOutline[panelObjectIdx]).enabled = true;
          ((Behaviour) this.mtextShadow[panelObjectIdx]).enabled = true;
        }
        if (mailContent.More > (byte) 1 && this.NowPageKind == 0)
        {
          ((Component) this.btn_ItemCollect[panelObjectIdx]).gameObject.SetActive(false);
          ((Component) this.text_PluralTotal[panelObjectIdx]).gameObject.SetActive(true);
          this.Cstr_PluralTotal[panelObjectIdx].ClearString();
          this.Cstr_PluralTotal[panelObjectIdx].IntToFormat((long) mailContent.More);
          this.Cstr_PluralTotal[panelObjectIdx].AppendFormat("({0})");
          this.text_PluralTotal[panelObjectIdx].text = this.Cstr_PluralTotal[panelObjectIdx].ToString();
          this.text_PluralTotal[panelObjectIdx].SetAllDirty();
          this.text_PluralTotal[panelObjectIdx].cachedTextGenerator.Invalidate();
          this.text_PluralNoRead[panelObjectIdx].text = mailContent.UnSeen.ToString();
          if (mailContent.UnSeen > (byte) 0)
            ((Component) this.ImgPlural[panelObjectIdx]).gameObject.SetActive(true);
          else
            ((Component) this.ImgPlural[panelObjectIdx]).gameObject.SetActive(false);
          this.Plural_RT[panelObjectIdx].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PluralNoRead[panelObjectIdx].preferredWidth), this.Plural_RT[panelObjectIdx].sizeDelta.y);
        }
        else
        {
          ((Component) this.btn_ItemCollect[panelObjectIdx]).gameObject.SetActive(true);
          ((Component) this.ImgPlural[panelObjectIdx]).gameObject.SetActive(false);
          ((Component) this.text_PluralTotal[panelObjectIdx]).gameObject.SetActive(false);
        }
        ((Component) this.ImgNoRead[panelObjectIdx]).gameObject.SetActive(!mailContent.BeRead);
        ((Component) this.ImgRead[panelObjectIdx]).gameObject.SetActive(mailContent.BeRead);
      }
    }
    else if (this.NowPage == 1)
    {
      CombatReport mReport = this.DM.CombatReportGet(dataIdx);
      if (mReport != null)
      {
        this.SetCombatReport(mReport, panelObjectIdx);
        if (mReport.More != (byte) 0)
          ((Component) this.btn_ItemCollect[panelObjectIdx]).gameObject.SetActive(false);
        else
          ((Component) this.btn_ItemCollect[panelObjectIdx]).gameObject.SetActive(true);
        if (mReport.More > (byte) 1)
        {
          if (mReport.UnSeen > (byte) 0)
            ((Component) this.ImgPlural[panelObjectIdx]).gameObject.SetActive(true);
          else
            ((Component) this.ImgPlural[panelObjectIdx]).gameObject.SetActive(false);
          ((Component) this.text_PluralTotal[panelObjectIdx]).gameObject.SetActive(true);
          this.Cstr_PluralTotal[panelObjectIdx].ClearString();
          this.Cstr_PluralTotal[panelObjectIdx].IntToFormat((long) mReport.More);
          this.Cstr_PluralTotal[panelObjectIdx].AppendFormat("({0})");
          this.text_PluralTotal[panelObjectIdx].text = this.Cstr_PluralTotal[panelObjectIdx].ToString();
          this.text_PluralTotal[panelObjectIdx].SetAllDirty();
          this.text_PluralTotal[panelObjectIdx].cachedTextGenerator.Invalidate();
          this.text_PluralNoRead[panelObjectIdx].text = mReport.UnSeen.ToString();
          this.Plural_RT[panelObjectIdx].sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_PluralNoRead[panelObjectIdx].preferredWidth), this.Plural_RT[panelObjectIdx].sizeDelta.y);
        }
        else
        {
          ((Component) this.ImgPlural[panelObjectIdx]).gameObject.SetActive(false);
          ((Component) this.text_PluralTotal[panelObjectIdx]).gameObject.SetActive(false);
        }
      }
      else
      {
        this.text_1[panelObjectIdx].text = string.Empty;
        this.text_2[panelObjectIdx].text = string.Empty;
        this.text_3[panelObjectIdx].text = string.Empty;
        this.text_Time[panelObjectIdx].text = string.Empty;
      }
    }
    else if (this.NowPage == 3)
    {
      ((Component) this.ImgPlural[panelObjectIdx]).gameObject.SetActive(false);
      ((Component) this.text_PluralTotal[panelObjectIdx]).gameObject.SetActive(false);
      MyFavorite myFavorite = this.DM.FavorReportGet(dataIdx);
      if (myFavorite != null)
      {
        ((Component) this.btn_ItemCollect[panelObjectIdx]).gameObject.SetActive(true);
        this.btn_ItemCollect[panelObjectIdx].image.sprite = this.SArray.m_Sprites[21];
        if (myFavorite.Type == MailType.EMAIL_LETTER)
        {
          MailContent mail = myFavorite.Mail;
          if (mail.SenderTag.Length != 0)
          {
            cstring.ClearString();
            Name.ClearString();
            Tag.ClearString();
            if (mail.MailType != (byte) 3)
            {
              if (mail.MailType == (byte) 4)
              {
                Name.Append(mail.SenderName);
                Tag.Append(mail.SenderTag);
                this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
                this.Cstrtext_1[panelObjectIdx].StringToFormat(cstring);
                this.Cstrtext_1[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(11055U));
              }
              else
              {
                Name.Append(mail.SenderName);
                Tag.Append(mail.SenderTag);
                GameConstants.FormatRoleName(this.Cstrtext_1[panelObjectIdx], Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
              }
            }
            else
            {
              Name.Append(mail.SenderName);
              Tag.Append(mail.SenderTag);
              if ((int) mail.SenderKindom != (int) DataManager.MapDataController.kingdomData.kingdomID)
                this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, mail.SenderKindom, this.GUIM.IsArabic);
              else
                this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
              this.Cstrtext_1[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(1473U));
              this.text_1[panelObjectIdx].text = this.Cstrtext_1[panelObjectIdx].ToString();
            }
          }
          else if (mail.MailType == (byte) 2)
          {
            this.Cstrtext_1[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(8252U));
            this.Cstrtext_2[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(8257U));
          }
          else if (mail.MailType == (byte) 4)
          {
            this.Cstrtext_1[panelObjectIdx].StringToFormat(mail.SenderName);
            this.Cstrtext_1[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(11055U));
          }
          else
            this.Cstrtext_1[panelObjectIdx].Append(mail.SenderName);
          this.text_1[panelObjectIdx].text = this.Cstrtext_1[panelObjectIdx].ToString();
          if (mail.MailType == (byte) 1)
            this.Cstrtext_2[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(6014U));
          else if (mail.MailType == (byte) 3)
            this.Cstrtext_2[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(1474U));
          if (this.bTrans && mail.Translation && mail.MailType != (byte) 2 && this.DM.CheckLanguageTranslateByIdx((int) mail.LanguageSource) && (GameLanguage) mail.LanguageTarget == this.DM.UserLanguage && this.GUIM.CheckNeedTranslate(mail.Title))
            this.Cstrtext_2[panelObjectIdx].Append(mail.TitleT);
          else
            this.Cstrtext_2[panelObjectIdx].Append(mail.Title);
          this.text_2[panelObjectIdx].text = this.Cstrtext_2[panelObjectIdx].ToString();
          if (this.bTrans && mail.Translation && mail.MailType != (byte) 2 && this.DM.CheckLanguageTranslateByIdx((int) mail.LanguageSource) && (GameLanguage) mail.LanguageTarget == this.DM.UserLanguage)
            this.Cstrtext_3[panelObjectIdx].Append(mail.ContentT);
          else
            this.Cstrtext_3[panelObjectIdx].Append(mail.Content);
          this.text_3[panelObjectIdx].text = this.Cstrtext_3[panelObjectIdx].ToString();
          this.text_Time[panelObjectIdx].text = mail.DateTime;
          if (mail.BeChecked)
            ((Component) this.ImgSelect[panelObjectIdx]).gameObject.SetActive(true);
          else
            ((Component) this.ImgSelect[panelObjectIdx]).gameObject.SetActive(false);
          if (mail.BeRead)
          {
            ((Component) this.ImgNoRead2[panelObjectIdx]).gameObject.SetActive(false);
            ((Behaviour) this.mtextOutline[panelObjectIdx]).enabled = false;
            ((Behaviour) this.mtextShadow[panelObjectIdx]).enabled = false;
          }
          else
          {
            ((Component) this.ImgNoRead2[panelObjectIdx]).gameObject.SetActive(true);
            ((Behaviour) this.mtextOutline[panelObjectIdx]).enabled = true;
            ((Behaviour) this.mtextShadow[panelObjectIdx]).enabled = true;
          }
          ((Component) this.btn_ItemCollect[panelObjectIdx]).gameObject.SetActive(true);
          ((Component) this.ImgPlural[panelObjectIdx]).gameObject.SetActive(false);
          ((Component) this.ImgNoRead[panelObjectIdx]).gameObject.SetActive(!mail.BeRead);
          ((Component) this.ImgRead[panelObjectIdx]).gameObject.SetActive(mail.BeRead);
        }
        else if (myFavorite.Type == MailType.EMAIL_BATTLE)
          this.SetCombatReport(myFavorite.Combat, panelObjectIdx);
        else if (myFavorite.Type == MailType.EMAIL_SYSTEM)
        {
          NoticeContent system = myFavorite.System;
          if (system != null)
          {
            this.text_1[panelObjectIdx].text = system.Type >= NoticeReport.Enotice_NewbieOver && system.Type <= NoticeReport.Enotice_SHLevel5 || system.Type == NoticeReport.Enotice_FirstUnderPetAttack ? this.DM.mStringTable.GetStringByID(3717U) : this.DM.mStringTable.GetStringByID(6079U);
            this.ImgIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[13];
            this.SetNoticeContent(system, panelObjectIdx);
          }
        }
      }
      else
      {
        this.text_1[panelObjectIdx].text = string.Empty;
        this.text_2[panelObjectIdx].text = string.Empty;
        this.text_3[panelObjectIdx].text = string.Empty;
        this.text_Time[panelObjectIdx].text = string.Empty;
      }
    }
    else if (this.NowPage == 0)
    {
      ((Component) this.btn_ItemCollect[panelObjectIdx]).gameObject.SetActive(true);
      ((Component) this.ImgPlural[panelObjectIdx]).gameObject.SetActive(false);
      ((Component) this.text_PluralTotal[panelObjectIdx]).gameObject.SetActive(false);
      NoticeContent mNoticeRp = this.DM.SystemReportGet(dataIdx);
      if (mNoticeRp != null)
      {
        this.text_1[panelObjectIdx].text = mNoticeRp.Type >= NoticeReport.Enotice_NewbieOver && mNoticeRp.Type <= NoticeReport.Enotice_SHLevel5 || mNoticeRp.Type == NoticeReport.Enotice_FirstUnderPetAttack ? this.DM.mStringTable.GetStringByID(3717U) : this.DM.mStringTable.GetStringByID(6079U);
        this.ImgIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[13];
        this.SetNoticeContent(mNoticeRp, panelObjectIdx);
      }
      else
      {
        this.text_1[panelObjectIdx].text = string.Empty;
        this.text_2[panelObjectIdx].text = string.Empty;
        this.text_3[panelObjectIdx].text = string.Empty;
        this.text_Time[panelObjectIdx].text = string.Empty;
      }
    }
    this.text_1[panelObjectIdx].SetAllDirty();
    this.text_1[panelObjectIdx].cachedTextGenerator.Invalidate();
    if (this.Cstrtext_2[panelObjectIdx].Length != 0)
      this.CheckTextWidth(this.text_2[panelObjectIdx], this.Cstrtext_2[panelObjectIdx]);
    this.text_2[panelObjectIdx].SetAllDirty();
    this.text_2[panelObjectIdx].cachedTextGenerator.Invalidate();
    this.text_2[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
    if (this.Cstrtext_3[panelObjectIdx].Length != 0)
      this.CheckTextWidth(this.text_3[panelObjectIdx], this.Cstrtext_3[panelObjectIdx]);
    this.text_3[panelObjectIdx].SetAllDirty();
    this.text_3[panelObjectIdx].cachedTextGenerator.Invalidate();
    this.text_3[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
    this.ImgIcon[panelObjectIdx].SetNativeSize();
  }

  public void SetCombatReport(CombatReport mReport, int Idx)
  {
    CString cstring1 = StringManager.Instance.StaticString1024();
    cstring1.ClearString();
    switch (mReport.Type)
    {
      case CombatCollectReport.CCR_BATTLE:
        this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[16];
        this.tmpV = mReport.Combat.CombatPointKind != POINT_KIND.PK_YOLK ? GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(mReport.Combat.CombatlZone, mReport.Combat.CombatPoint)) : DataManager.MapDataController.GetYolkPos((ushort) mReport.Combat.CombatPoint, mReport.Combat.KingdomID);
        cstring1.IntToFormat((long) mReport.Combat.KingdomID);
        cstring1.IntToFormat((long) (int) this.tmpV.x);
        cstring1.IntToFormat((long) (int) this.tmpV.y);
        if (this.GUIM.IsArabic)
          cstring1.AppendFormat("{0}:K {1}:X {2}:Y");
        else
          cstring1.AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
        this.Cstrtext_1[Idx].StringToFormat(cstring1);
        this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(5305U));
        this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
        this.GetTextCombatbySide(mReport.Combat, this.Cstrtext_2[Idx]);
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        if (mReport.Combat.Result >= CombatReportResultType.ECRR_COMBATVICTORY && mReport.Combat.Result < CombatReportResultType.ECRR_COMBATMASSIVEDEFEAT)
        {
          this.temp = (int) mReport.Combat.Result;
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID((uint) (ushort) (5307 + this.temp)));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
          break;
        }
        if (mReport.Combat.Result == CombatReportResultType.ECRR_COMBATMASSIVEDEFEAT)
        {
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5308U));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
          break;
        }
        if (mReport.Combat.Result == CombatReportResultType.ECRR_DEFENDERSHIELDUP || mReport.Combat.Result == CombatReportResultType.ECRR_ALLYDEFENDER)
        {
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(625U));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
          break;
        }
        if (mReport.Combat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER || mReport.Combat.Result == CombatReportResultType.ECRR_WONDERVICTORY)
        {
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5307U));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
          break;
        }
        break;
      case CombatCollectReport.CCR_RESOURCE:
        this.text_1[Idx].text = string.Empty;
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6042U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].StringToFormat(mReport.Resource.Name);
        if (mReport.Resource.Result == (byte) 0)
          this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6044U));
        else if (mReport.Resource.Result == (byte) 1)
          this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6043U));
        else
          this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6045U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[18];
        break;
      case CombatCollectReport.CCR_COLLECT:
        this.Cstrtext_1[Idx].IntToFormat((long) mReport.Gather.GatherPointLevel);
        this.Cstrtext_1[Idx].StringToFormat(this.GUIM.GetPointName_Letter(mReport.Gather.GatherPointKind));
        this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6050U));
        this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6047U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[19];
        break;
      case CombatCollectReport.CCR_SCOUT:
        this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[15];
        if (mReport.Scout.CombatPointKind != POINT_KIND.PK_YOLK)
        {
          this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(mReport.Scout.CombatlZone, mReport.Scout.CombatPoint));
          this.Cstrtext_1[Idx].IntToFormat((long) mReport.Scout.KingdomID);
          this.Cstrtext_1[Idx].IntToFormat((long) (int) this.tmpV.x);
          this.Cstrtext_1[Idx].IntToFormat((long) (int) this.tmpV.y);
          if (this.GUIM.IsArabic)
            this.Cstrtext_1[Idx].AppendFormat("{0}:K {1}:X {2}:Y");
          else
            this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
          this.Cstrtext_1[Idx].Append(this.GUIM.GetPointName_Letter(mReport.Scout.CombatPointKind));
        }
        else
        {
          this.tmpV = DataManager.MapDataController.GetYolkPos((ushort) mReport.Scout.CombatPoint, mReport.Scout.KingdomID);
          this.Cstrtext_1[Idx].IntToFormat((long) mReport.Scout.KingdomID);
          this.Cstrtext_1[Idx].IntToFormat((long) (int) this.tmpV.x);
          this.Cstrtext_1[Idx].IntToFormat((long) (int) this.tmpV.y);
          if (this.GUIM.IsArabic)
            this.Cstrtext_1[Idx].AppendFormat("{0}:K {1}:X {2}:Y");
          else
            this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
          if (mReport.Scout.CombatPoint == (byte) 0 || (int) mReport.Scout.KingdomID == (int) ActivityManager.Instance.KOWKingdomID)
            this.Cstrtext_1[Idx].Append(this.DM.mStringTable.GetStringByID(9308U));
          else
            this.Cstrtext_1[Idx].Append(this.DM.mStringTable.GetStringByID(9309U));
        }
        this.Cstrtext_1[Idx].Append(this.DM.mStringTable.GetStringByID(5347U));
        this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
        CString Name1 = StringManager.Instance.StaticString1024();
        CString Tag1 = StringManager.Instance.StaticString1024();
        Name1.ClearString();
        Tag1.ClearString();
        cstring1.ClearString();
        if (mReport.Scout.ScoutResult == (byte) 0)
        {
          if (mReport.Scout.CombatPointKind != POINT_KIND.PK_YOLK)
          {
            cstring1.ClearString();
            Name1.Append(mReport.Scout.ObjName);
            if (mReport.Scout.ObjAllianceTag.Length != 0)
            {
              Tag1.Append(mReport.Scout.ObjAllianceTag);
              if ((int) mReport.Scout.ObjKingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID)
                this.GUIM.FormatRoleNameForChat(cstring1, Name1, Tag1, mReport.Scout.ObjKingdomID, this.GUIM.IsArabic);
              else
                this.GUIM.FormatRoleNameForChat(cstring1, Name1, Tag1, (ushort) 0, this.GUIM.IsArabic);
            }
            else if ((int) mReport.Scout.ObjKingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID)
              this.GUIM.FormatRoleNameForChat(cstring1, Name1, KingdomID: mReport.Scout.ObjKingdomID, ForceArabic: this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring1, Name1, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
          }
          else
          {
            cstring1.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) mReport.Scout.CombatPoint, mReport.Scout.KingdomID));
            cstring1.AppendFormat("{0}");
          }
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5348U));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        }
        else
        {
          if (mReport.Scout.ScoutResult == (byte) 3 && mReport.Scout.CombatPointKind == POINT_KIND.PK_YOLK)
          {
            this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5348U));
            cstring1.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) mReport.Scout.CombatPoint, mReport.Scout.KingdomID));
            cstring1.AppendFormat("{0}");
          }
          else
            this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5349U));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        }
        this.Cstrtext_2[Idx].StringToFormat(cstring1);
        this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7259U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        break;
      case CombatCollectReport.CCR_RECON:
        this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[17];
        this.Cstrtext_1[Idx].Append(this.DM.mStringTable.GetStringByID(5350U));
        this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
        if (mReport.Recon.CombatPointKind == POINT_KIND.PK_YOLK)
          this.Cstrtext_2[Idx].StringToFormat(DataManager.MapDataController.GetYolkName((ushort) mReport.Recon.CombatPoint, mReport.Recon.KingdomID));
        else
          this.Cstrtext_2[Idx].StringToFormat(this.GUIM.GetPointName_Letter(mReport.Recon.CombatPointKind));
        if (mReport.Recon.AntiScout == (byte) 0)
        {
          if (mReport.Recon.CombatPointKind == POINT_KIND.PK_YOLK)
            this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7263U));
          else
            this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(5355U));
        }
        else
          this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(5355U));
        if (mReport.Recon.bAmbush == (byte) 1)
        {
          this.Cstrtext_2[Idx].ClearString();
          this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9748U));
        }
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case CombatCollectReport.CCR_MONSTER:
        this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(mReport.Monster.Zone, mReport.Monster.Point));
        cstring1.IntToFormat((long) mReport.Monster.KindgomID);
        cstring1.IntToFormat((long) (int) this.tmpV.x);
        cstring1.IntToFormat((long) (int) this.tmpV.y);
        if (this.GUIM.IsArabic)
          cstring1.AppendFormat("{0}:K {1}:X {2}:Y");
        else
          cstring1.AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
        this.Cstrtext_1[Idx].StringToFormat(cstring1);
        this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8218U));
        this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
        if (mReport.Monster.Result > (byte) 1 && mReport.Monster.Result < (byte) 4)
          this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8217U));
        else if (mReport.Monster.Result < (byte) 2)
        {
          this.Cstrtext_2[Idx].IntToFormat((long) mReport.Monster.MonsterLv);
          this.Cstrtext_2[Idx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) DataManager.MapDataController.MapMonsterTable.GetRecordByKey(mReport.Monster.MonsterID).NameID));
          if (mReport.Monster.Result == (byte) 0)
            this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8221U));
          else
            this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8223U));
        }
        else
        {
          CString tmpS = StringManager.Instance.StaticString1024();
          tmpS.StringToFormat(mReport.Monster.AllianceTag);
          tmpS.StringToFormat(this.DM.mStringTable.GetStringByID((uint) DataManager.MapDataController.MapMonsterTable.GetRecordByKey(mReport.Monster.MonsterID).NameID));
          tmpS.AppendFormat("[{0}]{1}");
          this.Cstrtext_2[Idx].IntToFormat((long) mReport.Monster.MonsterLv);
          this.Cstrtext_2[Idx].StringToFormat(tmpS);
          if (mReport.Monster.Result == (byte) 4)
            this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8221U));
          else
            this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8223U));
        }
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case CombatCollectReport.CCR_NPCSCOUT:
        this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[15];
        this.Cstrtext_1[Idx].Append(this.DM.mStringTable.GetStringByID(5347U));
        this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
        cstring1.ClearString();
        cstring1.IntToFormat((long) mReport.NPCScout.NPCLevel);
        cstring1.AppendFormat(this.DM.mStringTable.GetStringByID(12021U));
        this.Cstrtext_2[Idx].StringToFormat(cstring1);
        this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7259U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        if (mReport.NPCScout.ScoutResult == (byte) 0)
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5348U));
        else
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5349U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case CombatCollectReport.CCR_NPCCOMBAT:
        this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[16];
        this.tmpV = mReport.NPCCombat.CombatPointKind != POINT_KIND.PK_YOLK ? GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(mReport.NPCCombat.CombatlZone, mReport.NPCCombat.CombatPoint)) : DataManager.MapDataController.GetYolkPos((ushort) mReport.NPCCombat.CombatPoint, mReport.NPCCombat.KingdomID);
        cstring1.IntToFormat((long) mReport.NPCCombat.KingdomID);
        cstring1.IntToFormat((long) (int) this.tmpV.x);
        cstring1.IntToFormat((long) (int) this.tmpV.y);
        if (this.GUIM.IsArabic)
          cstring1.AppendFormat("{0}:K {1}:X {2}:Y");
        else
          cstring1.AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
        this.Cstrtext_1[Idx].StringToFormat(cstring1);
        this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(5305U));
        this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
        this.GetTextCombatbySide(mReport.NPCCombat, this.Cstrtext_2[Idx]);
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        if (mReport.NPCCombat.Result >= CombatReportResultType.ECRR_COMBATVICTORY && mReport.NPCCombat.Result < CombatReportResultType.ECRR_COMBATMASSIVEDEFEAT)
        {
          this.temp = (int) mReport.NPCCombat.Result;
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID((uint) (ushort) (5307 + this.temp)));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
          break;
        }
        if (mReport.NPCCombat.Result == CombatReportResultType.ECRR_COMBATMASSIVEDEFEAT)
        {
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5308U));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
          break;
        }
        if (mReport.NPCCombat.Result == CombatReportResultType.ECRR_DEFENDERSHIELDUP || mReport.NPCCombat.Result == CombatReportResultType.ECRR_ALLYDEFENDER)
        {
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(625U));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
          break;
        }
        if (mReport.NPCCombat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER || mReport.NPCCombat.Result == CombatReportResultType.ECRR_WONDERVICTORY)
        {
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(5307U));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
          break;
        }
        break;
      case CombatCollectReport.CCR_PETREPORT:
        this.ImgIcon[Idx].sprite = this.SArray.m_Sprites[8];
        this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(mReport.Pet.Zone, mReport.Pet.Point));
        cstring1.IntToFormat((long) mReport.Pet.KindgomID);
        cstring1.IntToFormat((long) (int) this.tmpV.x);
        cstring1.IntToFormat((long) (int) this.tmpV.y);
        if (this.GUIM.IsArabic)
          cstring1.AppendFormat("{0}:K {1}:X {2}:Y");
        else
          cstring1.AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
        this.Cstrtext_1[Idx].StringToFormat(cstring1);
        this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(10092U));
        this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
        CString cstring2 = StringManager.Instance.StaticString1024();
        CString Name2 = StringManager.Instance.StaticString1024();
        CString Tag2 = StringManager.Instance.StaticString1024();
        cstring2.ClearString();
        Name2.ClearString();
        Tag2.ClearString();
        if (mReport.Pet.Side == (byte) 0)
        {
          Name2.Append(mReport.Pet.DefenceName);
          if (mReport.Pet.DefenceAllianceTag != string.Empty)
          {
            Tag2.Append(mReport.Pet.DefenceAllianceTag);
            if ((int) mReport.Pet.AssaultKingdomID != (int) mReport.Pet.DefenceKingdomID)
              this.GUIM.FormatRoleNameForChat(cstring2, Name2, Tag2, mReport.Pet.DefenceKingdomID, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring2, Name2, Tag2, (ushort) 0, this.GUIM.IsArabic);
          }
          else if ((int) mReport.Pet.AssaultKingdomID != (int) mReport.Pet.DefenceKingdomID)
            this.GUIM.FormatRoleNameForChat(cstring2, Name2, KingdomID: mReport.Pet.DefenceKingdomID, ForceArabic: this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring2, Name2, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
          this.Cstrtext_2[Idx].StringToFormat(cstring2);
          this.Cstrtext_2[Idx].StringToFormat(this.GUIM.GetPointName_Letter((POINT_KIND) mReport.Pet.Kind));
          this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(10093U));
          this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
          if (mReport.Pet.Result == PetReportResultType.EPRR_ATTACKFAILED)
            this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(10097U));
          else
            this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(10095U));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
          break;
        }
        Name2.Append(mReport.Pet.AssaultName);
        if (mReport.Pet.AssaultAllianceTag != string.Empty)
        {
          Tag2.Append(mReport.Pet.AssaultAllianceTag);
          if ((int) mReport.Pet.AssaultKingdomID != (int) mReport.Pet.DefenceKingdomID)
            this.GUIM.FormatRoleNameForChat(cstring2, Name2, Tag2, mReport.Pet.AssaultKingdomID, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring2, Name2, Tag2, (ushort) 0, this.GUIM.IsArabic);
        }
        else if ((int) mReport.Pet.AssaultKingdomID != (int) mReport.Pet.DefenceKingdomID)
          this.GUIM.FormatRoleNameForChat(cstring2, Name2, KingdomID: mReport.Pet.AssaultKingdomID, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring2, Name2, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        this.Cstrtext_2[Idx].StringToFormat(cstring2);
        this.Cstrtext_2[Idx].StringToFormat(this.GUIM.GetPointName_Letter((POINT_KIND) mReport.Pet.Kind));
        this.Cstrtext_2[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(10094U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(10110U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
    }
    this.text_Time[Idx].text = mReport.DateTime;
    if (mReport.BeChecked)
      ((Component) this.ImgSelect[Idx]).gameObject.SetActive(true);
    else
      ((Component) this.ImgSelect[Idx]).gameObject.SetActive(false);
    if (mReport.BeRead)
    {
      ((Component) this.ImgNoRead2[Idx]).gameObject.SetActive(false);
      ((Behaviour) this.mtextOutline[Idx]).enabled = false;
      ((Behaviour) this.mtextShadow[Idx]).enabled = false;
    }
    else
    {
      ((Component) this.ImgNoRead2[Idx]).gameObject.SetActive(true);
      ((Behaviour) this.mtextOutline[Idx]).enabled = true;
      ((Behaviour) this.mtextShadow[Idx]).enabled = true;
    }
    ((Component) this.ImgNoRead[Idx]).gameObject.SetActive(!mReport.BeRead);
    ((Component) this.ImgRead[Idx]).gameObject.SetActive(mReport.BeRead);
  }

  public void SetNoticeContent(NoticeContent mNoticeRp, int Idx)
  {
    CString cstring = StringManager.Instance.StaticString1024();
    CString Name = StringManager.Instance.StaticString1024();
    CString Tag = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    Name.ClearString();
    Tag.ClearString();
    switch (mNoticeRp.Type)
    {
      case NoticeReport.ENotice_Enhance:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6080U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case NoticeReport.ENotice_StarUp:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6084U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case NoticeReport.ENotice_JoinAlliance:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6051U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        if (this.GUIM.IsArabic)
        {
          Name.Append(mNoticeRp.Notice_JoinAlliance.Name);
          Tag.Append(mNoticeRp.Notice_JoinAlliance.Tag);
          this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
          this.Cstrtext_3[Idx].StringToFormat(cstring);
          this.Cstrtext_3[Idx].StringToFormat(string.Empty);
        }
        else
        {
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_JoinAlliance.Tag);
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_JoinAlliance.Name);
        }
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6052U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_ApplyAlliance:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6053U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        if (this.GUIM.IsArabic)
        {
          Name.Append(mNoticeRp.Notice_ApplyAlliance.Name);
          Tag.Append(mNoticeRp.Notice_ApplyAlliance.Tag);
          this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
          this.Cstrtext_3[Idx].StringToFormat(cstring);
          this.Cstrtext_3[Idx].StringToFormat(string.Empty);
        }
        else
        {
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_ApplyAlliance.Tag);
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_ApplyAlliance.Name);
        }
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6054U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_ApplyAllianceBeDenied:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6055U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        if (this.GUIM.IsArabic)
        {
          Name.Append(mNoticeRp.Notice_ApplyAllianceBeDenied.Name);
          Tag.Append(mNoticeRp.Notice_ApplyAllianceBeDenied.Tag);
          this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_ApplyAllianceBeDenied.Dealer);
          this.Cstrtext_3[Idx].StringToFormat(cstring);
          this.Cstrtext_3[Idx].StringToFormat(string.Empty);
        }
        else
        {
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_ApplyAllianceBeDenied.Dealer);
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_ApplyAllianceBeDenied.Tag);
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_ApplyAllianceBeDenied.Name);
        }
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6056U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_AllianceDismiss:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6059U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_AllianceDismiss.Leader);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6060U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_AllianceLeaderStepDown:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6063U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_AllianceLeaderStepDown.OldLeader);
        this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_AllianceLeaderStepDown.NewLeader);
        this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_AllianceLeaderStepDown.NewLeader);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6064U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_ActivityDegreePrize:
        if (mNoticeRp.Notice_ActivityDegreePrize.Type == NoticeContent.ActivityCircleEventType.EACET_SoloEvent)
        {
          this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7686U));
          this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(7678U));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
          break;
        }
        if (mNoticeRp.Notice_ActivityDegreePrize.Type == NoticeContent.ActivityCircleEventType.EACET_InfernalEvent)
        {
          this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7688U));
          this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(7682U));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
          break;
        }
        break;
      case NoticeReport.Enotice_ActivityRankPrize:
        if (mNoticeRp.Notice_ActivityRankPrize.Type == NoticeContent.ActivityCircleEventType.EACET_SoloEvent)
        {
          this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7686U));
          this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
          this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.Notice_ActivityRankPrize.Place);
          this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7679U));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
          break;
        }
        if (mNoticeRp.Notice_ActivityRankPrize.Type == NoticeContent.ActivityCircleEventType.EACET_InfernalEvent)
        {
          this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7688U));
          this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
          this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.Notice_ActivityRankPrize.Place);
          this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7683U));
          this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
          break;
        }
        break;
      case NoticeReport.Enotice_InviteAlliance:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6057U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        if (this.GUIM.IsArabic)
        {
          Name.Append(mNoticeRp.Notice_InviteAlliance.Name);
          Tag.Append(mNoticeRp.Notice_InviteAlliance.Tag);
          this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_InviteAlliance.InviterName);
          this.Cstrtext_3[Idx].StringToFormat(cstring);
          this.Cstrtext_3[Idx].StringToFormat(string.Empty);
        }
        else
        {
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_InviteAlliance.InviterName);
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_InviteAlliance.Tag);
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_InviteAlliance.Name);
        }
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6058U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_SynLordEquip:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7700U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(mNoticeRp.Notice_SynLordEquip.ItemID).EquipName));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_RallyCancel:
      case NoticeReport.Enotice_RallyCancel_AsTargetAlly:
      case NoticeReport.Enotice_RallyCancel_Moving:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6067U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case NoticeReport.Enotice_CryptFinish:
        this.text_2[Idx].text = this.DM.mStringTable.GetStringByID(6077U);
        this.text_3[Idx].text = this.DM.mStringTable.GetStringByID(6078U);
        break;
      case NoticeReport.Enotice_OtherSavedLord:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6074U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        StringManager.Instance.StaticString1024().ClearString();
        Name.Append(mNoticeRp.Notice_OtherSavedLord.Name);
        if (mNoticeRp.Notice_OtherSavedLord.AllianceTag != string.Empty)
        {
          Tag.Append(mNoticeRp.Notice_OtherSavedLord.AllianceTag);
          if ((int) mNoticeRp.Notice_OtherSavedLord.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, mNoticeRp.Notice_OtherSavedLord.HomeKingdom, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        }
        else if ((int) mNoticeRp.Notice_OtherSavedLord.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
          this.GUIM.FormatRoleNameForChat(cstring, Name, KingdomID: mNoticeRp.Notice_OtherSavedLord.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        this.Cstrtext_3[Idx].StringToFormat(cstring);
        this.Cstrtext_3[Idx].StringToFormat(string.Empty);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6071U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_SelfSavedLord:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7656U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(6075U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_LordBeingReleased:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6072U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        Name.Append(mNoticeRp.Notice_LordBeingReleased.Name);
        if (mNoticeRp.Notice_LordBeingReleased.AllianceTag != string.Empty)
        {
          Tag.Append(mNoticeRp.Notice_LordBeingReleased.AllianceTag);
          if ((int) mNoticeRp.Notice_LordBeingReleased.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, mNoticeRp.Notice_LordBeingReleased.HomeKingdom, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        }
        else if ((int) mNoticeRp.Notice_LordBeingReleased.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
          this.GUIM.FormatRoleNameForChat(cstring, Name, KingdomID: mNoticeRp.Notice_LordBeingReleased.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        this.Cstrtext_3[Idx].StringToFormat(cstring);
        this.Cstrtext_3[Idx].StringToFormat(string.Empty);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(6073U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_LordBeingExecuted:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7659U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        Name.Append(mNoticeRp.Notice_LordBeingExecuted.Name);
        if (mNoticeRp.Notice_LordBeingExecuted.AllianceTag != string.Empty)
        {
          Tag.Append(mNoticeRp.Notice_LordBeingExecuted.AllianceTag);
          if ((int) mNoticeRp.Notice_LordBeingExecuted.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, mNoticeRp.Notice_LordBeingExecuted.HomeKingdom, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        }
        else if ((int) mNoticeRp.Notice_LordBeingExecuted.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
          this.GUIM.FormatRoleNameForChat(cstring, Name, KingdomID: mNoticeRp.Notice_LordBeingExecuted.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        this.Cstrtext_3[Idx].StringToFormat(cstring);
        this.Cstrtext_3[Idx].StringToFormat(string.Empty);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7660U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_LordEscaped:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6070U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(7655U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_OtherBreakPrison:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7665U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        Name.Append(mNoticeRp.Notice_OtherBreakPrison.Name);
        if (mNoticeRp.Notice_OtherBreakPrison.AllianceTag != string.Empty)
        {
          Tag.Append(mNoticeRp.Notice_OtherBreakPrison.AllianceTag);
          if ((int) mNoticeRp.Notice_OtherBreakPrison.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, mNoticeRp.Notice_OtherBreakPrison.HomeKingdom, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        }
        else if ((int) mNoticeRp.Notice_OtherBreakPrison.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
          this.GUIM.FormatRoleNameForChat(cstring, Name, KingdomID: mNoticeRp.Notice_OtherBreakPrison.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        this.Cstrtext_3[Idx].StringToFormat(cstring);
        this.Cstrtext_3[Idx].StringToFormat(string.Empty);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7666U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_RescuedPrisoner:
        Name.Append(mNoticeRp.Notice_RescuedPrisoner.Name);
        if (mNoticeRp.Notice_RescuedPrisoner.AllianceTag != string.Empty)
        {
          Tag.Append(mNoticeRp.Notice_RescuedPrisoner.AllianceTag);
          if ((int) mNoticeRp.Notice_RescuedPrisoner.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, mNoticeRp.Notice_RescuedPrisoner.HomeKingdom, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        }
        else if ((int) mNoticeRp.Notice_RescuedPrisoner.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
          this.GUIM.FormatRoleNameForChat(cstring, Name, KingdomID: mNoticeRp.Notice_RescuedPrisoner.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        this.Cstrtext_3[Idx].StringToFormat(cstring);
        this.Cstrtext_3[Idx].StringToFormat(string.Empty);
        this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.Notice_RescuedPrisoner.PrisonerNum);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7663U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        if (mNoticeRp.Notice_RescuedPrisoner.ClaimReward > 0U)
          this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6076U));
        else
          this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8235U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        break;
      case NoticeReport.Enotice_RequestRansom:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(7658U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.Notice_RequestRansom.Ransom, bNumber: true);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7657U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_ReceivedRansom:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8232U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.Notice_ReceivedRansom.Ransom, bNumber: true);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(7661U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_PrisonFull:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8234U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        Name.Append(mNoticeRp.Notice_PrisonFull.Name);
        if (mNoticeRp.Notice_PrisonFull.AllianceTag != string.Empty)
        {
          Tag.Append(mNoticeRp.Notice_PrisonFull.AllianceTag);
          if ((int) mNoticeRp.Notice_PrisonFull.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, mNoticeRp.Notice_PrisonFull.HomeKingdom, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        }
        else if ((int) mNoticeRp.Notice_PrisonFull.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
          this.GUIM.FormatRoleNameForChat(cstring, Name, KingdomID: mNoticeRp.Notice_PrisonFull.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        this.Cstrtext_3[Idx].StringToFormat(cstring);
        this.Cstrtext_3[Idx].StringToFormat(string.Empty);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8233U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_BeQuitAlliance:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8215U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        if (this.GUIM.IsArabic)
        {
          Name.Append(mNoticeRp.Notice_BeQuitAlliance.Alliance);
          Tag.Append(mNoticeRp.Notice_BeQuitAlliance.AllianceTag);
          this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_BeQuitAlliance.Dealer);
          this.Cstrtext_3[Idx].StringToFormat(cstring);
          this.Cstrtext_3[Idx].StringToFormat(string.Empty);
        }
        else
        {
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_BeQuitAlliance.Dealer);
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_BeQuitAlliance.AllianceTag);
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Notice_BeQuitAlliance.Alliance);
        }
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8214U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_BuyTreasure:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(8237U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_AtkFailedSelfShield:
        if (mNoticeRp.Enotice_AtkFailedSelfShield.FailedType == (byte) 1)
          this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8250U));
        else
          this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8251U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case NoticeReport.Enotice_InactiveState:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8249U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(8248U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_NewbieOver:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3718U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3719U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_SHLevel6:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3720U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3721U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_SHLevel10:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3722U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3723U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_SHLevel15:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3724U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3725U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_SHLevel17:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3726U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3727U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_FirstUnderAttack:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3728U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3729U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_FirstJoinAlliance:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3730U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3731U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_SHLevel5:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(3732U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(3733U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_BuyMonthTreature:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(920U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_RecivedGift:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9095U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        if (this.GUIM.IsArabic)
        {
          Name.Append(mNoticeRp.Enotice_RecivedGift.GiftsName);
          Tag.Append(mNoticeRp.Enotice_RecivedGift.GiftsTag);
          this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
          this.Cstrtext_3[Idx].StringToFormat(cstring);
          this.Cstrtext_3[Idx].StringToFormat(string.Empty);
        }
        else
        {
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Enotice_RecivedGift.GiftsTag);
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Enotice_RecivedGift.GiftsName);
        }
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9093U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_PrisonAmnestied:
        Name.Append(mNoticeRp.Enotice_PrisonAmnestied.KingdomName);
        Tag.Append(mNoticeRp.Enotice_PrisonAmnestied.KingdomTag);
        this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        this.Cstrtext_1[Idx].StringToFormat(cstring);
        this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(1473U));
        this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(1475U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(1463U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_LordBeingAmnestied:
        Name.Append(mNoticeRp.Enotice_LordBeingAmnestied.KingdomName);
        Tag.Append(mNoticeRp.Enotice_LordBeingAmnestied.KingdomTag);
        this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        this.Cstrtext_1[Idx].StringToFormat(cstring);
        this.Cstrtext_1[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(1473U));
        this.text_1[Idx].text = this.Cstrtext_1[Idx].ToString();
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(1475U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        Name.ClearString();
        Tag.ClearString();
        Name.Append(mNoticeRp.Enotice_LordBeingAmnestied.Name);
        Tag.Append(mNoticeRp.Enotice_LordBeingAmnestied.Tag);
        this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        this.Cstrtext_3[Idx].StringToFormat(cstring);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(1462U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_RulerGift:
        if (mNoticeRp.Enotice_RulerGift.RulerKind == (byte) 1)
          this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9714U));
        else if (mNoticeRp.Enotice_RulerGift.RulerKind == (byte) 2)
          this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9799U));
        else if (mNoticeRp.Enotice_RulerGift.RulerKind == (byte) 3)
          this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(11086U));
        else
          this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(1049U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        Name.Append(mNoticeRp.Enotice_RulerGift.Name);
        Tag.Append(mNoticeRp.Enotice_RulerGift.Tag);
        this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        this.Cstrtext_3[Idx].StringToFormat(cstring);
        if (mNoticeRp.Enotice_RulerGift.RulerKind == (byte) 1)
          this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9715U));
        else if (mNoticeRp.Enotice_RulerGift.RulerKind == (byte) 2)
          this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9800U));
        else if (mNoticeRp.Enotice_RulerGift.RulerKind == (byte) 3)
        {
          this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(11087U));
        }
        else
        {
          this.Cstrtext_3[Idx].AppendFormat("{0}");
          this.Cstrtext_3[Idx].ClearString();
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(1049U));
        }
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_DismissAllianceLeader:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9529U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Enotice_DismissAllianceLeader.OldLeader);
        this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.Enotice_DismissAllianceLeader.OffLineDay);
        this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Enotice_DismissAllianceLeader.NewLeader);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9535U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_AmbushDefSuccess:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9754U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case NoticeReport.Enotice_AmbushDefFailed:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9756U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case NoticeReport.Enotice_ActivityKVKDegreePrize:
        switch (mNoticeRp.Enotice_ActivityKVKDegreePrize.EventType)
        {
          case EActivityKingdomEventType.EAKET_SoloEvent:
            if (mNoticeRp.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomKillEvent || mNoticeRp.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomMatchEvent)
            {
              this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9846U));
              this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(9842U));
              break;
            }
            if (mNoticeRp.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomNormalEvent)
            {
              this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9844U));
              this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(9838U));
              break;
            }
            break;
          case EActivityKingdomEventType.EAKET_AllianceEvent:
            if (mNoticeRp.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomKillEvent || mNoticeRp.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomMatchEvent)
            {
              this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9845U));
              this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(9840U));
              break;
            }
            break;
        }
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_ActivityKVKRankPrize:
        switch (mNoticeRp.Enotice_ActivityKVKRankPrize.EventType)
        {
          case EActivityKingdomEventType.EAKET_SoloEvent:
            if (mNoticeRp.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomKillEvent || mNoticeRp.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomMatchEvent)
            {
              this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9846U));
              this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.Enotice_ActivityKVKRankPrize.Place);
              this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9843U));
              break;
            }
            if (mNoticeRp.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomNormalEvent)
            {
              this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9844U));
              this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.Enotice_ActivityKVKRankPrize.Place);
              this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9839U));
              break;
            }
            break;
          case EActivityKingdomEventType.EAKET_AllianceEvent:
            if (mNoticeRp.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomKillEvent || mNoticeRp.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomMatchEvent)
            {
              this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9845U));
              this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.Enotice_ActivityKVKRankPrize.Place);
              this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9841U));
              break;
            }
            break;
        }
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_BuyBlackMarketTreasure:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(9776U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_KickOffTeam:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9914U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case NoticeReport.Enotice_AutoDismissWarning:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9557U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(9558U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_AutoDismiss:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9559U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(9560U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_AMRankPrize:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(1339U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.Enotice_AMRankPrize.Place);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(1366U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_AllianceHomeKingdom:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9567U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        Name.Append(mNoticeRp.Enotice_AllianceHomeKingdom.Leader);
        Tag.Append(mNoticeRp.Enotice_AllianceHomeKingdom.AllianceTag);
        this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        this.Cstrtext_3[Idx].StringToFormat(cstring);
        this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.Enotice_AllianceHomeKingdom.HomeKingdom);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(9572U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_WorldKingPrize:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(11023U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11024U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_BackendAddCrystal:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8173U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.Enotice_BackendAddCrystal.Crystal, bNumber: true);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(8174U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_KOWTelItem:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8472U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11040U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_LoginConpensate:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8173U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.Enotice_LoginConpensate.Crystal, bNumber: true);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(11041U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_PurchaseConpensate:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8173U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.Enotice_PurchaseConpensate.Crystal, bNumber: true);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(11042U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_RallyNPCCancel:
      case NoticeReport.Enotice_RallyNPCCancelInvalid:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6067U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case NoticeReport.Enotice_ForceTeleport:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(12053U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case NoticeReport.Enotice_LordEquipExpire:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(9665U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(mNoticeRp.Enotice_LordEquipExpire.ItemID).EquipName));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_WorldNotKingPrize:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(11023U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        if (mNoticeRp.Enotice_WorldNotKingPrize.Place == (byte) 2)
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11051U));
        else if (mNoticeRp.Enotice_WorldNotKingPrize.Place == (byte) 3)
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11052U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_BuyEmoteTreasure:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(mNoticeRp.Enotice_BuyEmoteTreasure.ItemID).EquipName));
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(12070U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_LordPoisonEffect:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(15009U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(15010U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_PrisnerUsePoison:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(15011U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        Name.Append(mNoticeRp.Enotice_PrisnerUsePoison.Name);
        Tag.Append(mNoticeRp.Enotice_PrisnerUsePoison.AllianceTag);
        if ((int) mNoticeRp.Enotice_PrisnerUsePoison.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
          this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, mNoticeRp.Enotice_PrisnerUsePoison.HomeKingdom, this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        this.Cstrtext_3[Idx].StringToFormat(cstring);
        this.Cstrtext_3[Idx].IntToFormat((long) (mNoticeRp.Enotice_PrisnerUsePoison.EffectTime / 3600U));
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(15012U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_PrisnerPoisonEffect:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(15011U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        Name.Append(mNoticeRp.Enotice_PrisnerPoisonEffect.Name);
        Tag.Append(mNoticeRp.Enotice_PrisnerPoisonEffect.AllianceTag);
        if ((int) mNoticeRp.Enotice_PrisnerPoisonEffect.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
          this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, mNoticeRp.Enotice_PrisnerPoisonEffect.HomeKingdom, this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        this.Cstrtext_3[Idx].StringToFormat(cstring);
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(15013U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_BackendActivity:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(11053U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11054U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_BuyCastleSkinTreasure:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(9684U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_FederalRankPrize:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(11091U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        if (mNoticeRp.Enotice_FederalRankPrize.Place == (byte) 1)
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11092U));
        if (mNoticeRp.Enotice_FederalRankPrize.Place == (byte) 2)
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11108U));
        else if (mNoticeRp.Enotice_FederalRankPrize.Place == (byte) 3)
          this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11109U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_FederalTelBack:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(11093U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(11094U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_RcvGiftRestrict:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(16028U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(16029U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_CancelRcvGiftRestrict:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(16030U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(16031U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_TreasureBackPrize:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(10077U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_LookingForStringTable:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(mNoticeRp.Enotice_LookingForStringTable.Title));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(mNoticeRp.Enotice_LookingForStringTable.Content));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_MarchingPet_Cancel:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(10106U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case NoticeReport.ENotice_PetStarUp:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(10121U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case NoticeReport.ENotice_PrisonerPetSkillEscaped:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6070U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        PetTbl recordByKey1 = PetManager.Instance.PetTable.GetRecordByKey(mNoticeRp.ENotice_PrisonerPetSkillEscaped.PetID);
        PetSkillTbl recordByKey2 = PetManager.Instance.PetSkillTable.GetRecordByKey(mNoticeRp.ENotice_PrisonerPetSkillEscaped.Skill_ID);
        this.Cstrtext_3[Idx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey1.Name));
        this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.ENotice_PrisonerPetSkillEscaped.Skill_LV);
        this.Cstrtext_3[Idx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey2.Name));
        if (recordByKey2.Type == (byte) 1)
          this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(10114U));
        else
          this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(10116U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.ENotice_LordPetSkillEscaped:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(6070U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        PetTbl recordByKey3 = PetManager.Instance.PetTable.GetRecordByKey(mNoticeRp.ENotice_LordPetSkillEscaped.PetID);
        PetSkillTbl recordByKey4 = PetManager.Instance.PetSkillTable.GetRecordByKey(mNoticeRp.ENotice_LordPetSkillEscaped.Skill_ID);
        this.Cstrtext_3[Idx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey3.Name));
        this.Cstrtext_3[Idx].IntToFormat((long) mNoticeRp.ENotice_LordPetSkillEscaped.Skill_LV);
        this.Cstrtext_3[Idx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey4.Name));
        if (recordByKey4.Type == (byte) 1)
          this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(10115U));
        else
          this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(10117U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_FirstUnderPetAttack:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(10101U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(10111U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_ScoutTargetLeave:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(10109U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case NoticeReport.Enotice_AttackTargetLeave:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(10108U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.text_3[Idx].text = string.Empty;
        break;
      case NoticeReport.Enotice_MaintainCompensation:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID((uint) mNoticeRp.Enotice_MaintainCompensation.MailTitleStrID));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID((uint) mNoticeRp.Enotice_MaintainCompensation.MailContentStrID));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_BuyRedPocketTreasure:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(8236U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) mNoticeRp.Enotice_BuyRedPocketTreasure.StringID));
        this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID(11198U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_SocialFriendModify:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(12177U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        ushort ID = 12174;
        if (mNoticeRp.Enotice_SocialFriendModify.PlayerName.Length == 0 && mNoticeRp.Enotice_SocialFriendModify.TargetName.Length == 0)
        {
          if (mNoticeRp.Enotice_SocialFriendModify.RemoveType == (byte) 0)
            ID = (ushort) 12196;
          else if (mNoticeRp.Enotice_SocialFriendModify.RemoveType == (byte) 1)
            ID = (ushort) 12197;
          if (mNoticeRp.Enotice_SocialFriendModify.RemoveType < (byte) 2)
            this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID((uint) ID));
        }
        else
        {
          if (mNoticeRp.Enotice_SocialFriendModify.RemoveType == (byte) 1)
            ID = (ushort) 12175;
          else if (mNoticeRp.Enotice_SocialFriendModify.RemoveType == (byte) 2)
            ID = (ushort) 12176;
          else if (mNoticeRp.Enotice_SocialFriendModify.RemoveType == (byte) 3)
            ID = (ushort) 12198;
          Name.Append(mNoticeRp.Enotice_SocialFriendModify.PlayerName);
          Tag.Append(mNoticeRp.Enotice_SocialFriendModify.PlayerTag);
          this.GUIM.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
          this.Cstrtext_3[Idx].StringToFormat(mNoticeRp.Enotice_SocialFriendModify.TargetName);
          this.Cstrtext_3[Idx].StringToFormat(cstring);
          this.Cstrtext_3[Idx].AppendFormat(this.DM.mStringTable.GetStringByID((uint) ID));
        }
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      case NoticeReport.Enotice_ReturnCeremony:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(10175U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(10176U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
      default:
        this.Cstrtext_2[Idx].Append(this.DM.mStringTable.GetStringByID(1049U));
        this.text_2[Idx].text = this.Cstrtext_2[Idx].ToString();
        this.Cstrtext_3[Idx].Append(this.DM.mStringTable.GetStringByID(1049U));
        this.text_3[Idx].text = this.Cstrtext_3[Idx].ToString();
        break;
    }
    this.text_Time[Idx].text = mNoticeRp.DateTime;
    if (mNoticeRp.BeChecked)
      ((Component) this.ImgSelect[Idx]).gameObject.SetActive(true);
    else
      ((Component) this.ImgSelect[Idx]).gameObject.SetActive(false);
    if (mNoticeRp.BeRead)
    {
      ((Component) this.ImgNoRead2[Idx]).gameObject.SetActive(false);
      ((Behaviour) this.mtextOutline[Idx]).enabled = false;
      ((Behaviour) this.mtextShadow[Idx]).enabled = false;
    }
    else
    {
      ((Component) this.ImgNoRead2[Idx]).gameObject.SetActive(true);
      ((Behaviour) this.mtextOutline[Idx]).enabled = true;
      ((Behaviour) this.mtextShadow[Idx]).enabled = true;
    }
    ((Component) this.ImgNoRead[Idx]).gameObject.SetActive(!mNoticeRp.BeRead);
    ((Component) this.ImgRead[Idx]).gameObject.SetActive(mNoticeRp.BeRead);
  }

  public unsafe void CheckTextWidth(UIText mtext, CString Str)
  {
    Font font = mtext.font;
    CharacterInfo info = new CharacterInfo();
    float num1 = 365f;
    font.RequestCharactersInTexture(Str.ToString(), mtext.fontSize);
    int StartIndex = -1;
    string str = Str.ToString();
    char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
    float num2 = 0.0f;
    int index = 0;
    byte num3 = 0;
    for (; index < Str.Length; ++index)
    {
      if (Str[index] == '<' && (Str[index + 1] == 'c' || Str[index + 1] == '/'))
      {
        if (Str[index + 1] == 'c')
          num3 = (byte) 1;
        else if (num3 == (byte) 1)
          num3 = (byte) 0;
        int num4 = 2;
        while (Str[index + num4] != '>' && index + num4 < Str.Length)
          ++num4;
        index += num4;
      }
      else
      {
        if (font.GetCharacterInfo(Str[index], out info, mtext.fontSize))
          num2 += info.width;
        else
          num2 += 15f;
        if ((double) num2 > (double) num1)
        {
          chPtr[index] = '.';
          chPtr[index + 1] = '.';
          chPtr[index + 2] = '.';
          chPtr[index + 3] = char.MinValue;
          StartIndex = index;
          break;
        }
      }
    }
    if (StartIndex != -1 && num3 == (byte) 1)
      Str.Insert(StartIndex, "</color>");
    mtext.text = Str.ToString();
    str = (string) null;
  }

  public void GetTextCombatbySide(CombatReportContent mConbat, CString mCstr)
  {
    CString cstring1 = StringManager.Instance.StaticString1024();
    cstring1.ClearString();
    CString Name = StringManager.Instance.StaticString1024();
    Name.ClearString();
    CString Tag = StringManager.Instance.StaticString1024();
    Tag.ClearString();
    switch (mConbat.Side)
    {
      case 0:
        if (mConbat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER)
        {
          mCstr.Append(this.DM.mStringTable.GetStringByID(6021U));
          mCstr.Append(DataManager.MapDataController.GetYolkName((ushort) mConbat.CombatPoint, mConbat.KingdomID));
          break;
        }
        if (mConbat.Result == CombatReportResultType.ECRR_WONDERVICTORY)
        {
          mCstr.Append(this.DM.mStringTable.GetStringByID(6021U));
          Name.Append(mConbat.DefenceName);
          if (mConbat.DefenceAllianceTag != string.Empty)
          {
            Tag.Append(mConbat.DefenceAllianceTag);
            if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
              this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
          }
          else if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
            this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: mConbat.DefenceKingdomID, ForceArabic: this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
          mCstr.Append(cstring1);
          mCstr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) mConbat.CombatPoint, mConbat.KingdomID));
          mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(9304U));
          break;
        }
        mCstr.Append(this.DM.mStringTable.GetStringByID(6021U));
        Name.Append(mConbat.DefenceName);
        if (mConbat.DefenceAllianceTag != string.Empty)
        {
          Tag.Append(mConbat.DefenceAllianceTag);
          if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
            this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        }
        else if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
          this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: mConbat.DefenceKingdomID, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        if (mConbat.CombatPointKind == POINT_KIND.PK_YOLK)
        {
          mCstr.Append(cstring1);
          mCstr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) mConbat.CombatPoint, mConbat.KingdomID));
          mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(9304U));
          break;
        }
        if (this.DM.UserLanguage != GameLanguage.GL_Jpn)
        {
          if (this.GUIM.IsArabic)
          {
            mCstr.StringToFormat(this.GUIM.GetPointName_Letter(mConbat.CombatPointKind));
            mCstr.StringToFormat(cstring1);
          }
          else
          {
            mCstr.StringToFormat(cstring1);
            mCstr.StringToFormat(this.GUIM.GetPointName_Letter(mConbat.CombatPointKind));
          }
          mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(6022U));
          break;
        }
        mCstr.ClearString();
        mCstr.StringToFormat(cstring1);
        mCstr.StringToFormat(this.GUIM.GetPointName_Letter(mConbat.CombatPointKind));
        mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(6022U));
        mCstr.Append(this.DM.mStringTable.GetStringByID(6021U));
        break;
      case 1:
        Name.Append(mConbat.AssaultName);
        if (mConbat.AssaultAllianceTag != string.Empty)
        {
          Tag.Append(mConbat.AssaultAllianceTag);
          if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
            this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        }
        else if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
          this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: mConbat.AssaultKingdomID, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        if (this.GUIM.IsArabic)
        {
          if (mConbat.CombatPointKind == POINT_KIND.PK_YOLK)
            mCstr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) mConbat.CombatPoint, mConbat.KingdomID));
          else
            mCstr.StringToFormat(this.GUIM.GetPointName_Letter(mConbat.CombatPointKind));
          mCstr.StringToFormat(cstring1);
        }
        else
        {
          mCstr.StringToFormat(cstring1);
          if (mConbat.CombatPointKind == POINT_KIND.PK_YOLK)
            mCstr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) mConbat.CombatPoint, mConbat.KingdomID));
          else
            mCstr.StringToFormat(this.GUIM.GetPointName_Letter(mConbat.CombatPointKind));
        }
        mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(6020U));
        break;
      case 2:
        if (mConbat.Result != CombatReportResultType.ECRR_TAKEOVERWONDER)
        {
          Name.Append(mConbat.AssaultName);
          if (mConbat.AssaultAllianceTag != string.Empty)
          {
            Tag.Append(mConbat.AssaultAllianceTag);
            if ((int) mConbat.AssaultKingdomID != (int) mConbat.KingdomID)
              this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
          }
          else if ((int) mConbat.AssaultKingdomID != (int) mConbat.KingdomID)
            this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: mConbat.AssaultKingdomID, ForceArabic: this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
          CString cstring2 = StringManager.Instance.StaticString1024();
          cstring2.ClearString();
          cstring2.Append(this.DM.mStringTable.GetStringByID(6023U));
          cstring2.StringToFormat(cstring1);
          cstring2.AppendFormat(this.DM.mStringTable.GetStringByID(6024U));
          cstring1.ClearString();
          Name.ClearString();
          Tag.ClearString();
          Name.Append(mConbat.DefenceName);
          if (mConbat.DefenceAllianceTag != string.Empty)
          {
            Tag.Append(mConbat.DefenceAllianceTag);
            if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
              this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
          }
          else if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
            this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: mConbat.DefenceKingdomID, ForceArabic: this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
          mCstr.Append(cstring2);
          if (this.GUIM.IsArabic)
          {
            if (mConbat.CombatPointKind == POINT_KIND.PK_YOLK)
              mCstr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) mConbat.CombatPoint, mConbat.KingdomID));
            else
              mCstr.StringToFormat(this.GUIM.GetPointName_Letter(mConbat.CombatPointKind));
            mCstr.StringToFormat(cstring1);
          }
          else
          {
            mCstr.StringToFormat(cstring1);
            if (mConbat.CombatPointKind == POINT_KIND.PK_YOLK)
              mCstr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) mConbat.CombatPoint, mConbat.KingdomID));
            else
              mCstr.StringToFormat(this.GUIM.GetPointName_Letter(mConbat.CombatPointKind));
          }
          mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(6022U));
          break;
        }
        mCstr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) mConbat.CombatPoint, mConbat.KingdomID));
        mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(4987U));
        break;
      case 3:
        Name.Append(mConbat.AssaultName);
        if (mConbat.AssaultAllianceTag != string.Empty)
        {
          Tag.Append(mConbat.AssaultAllianceTag);
          if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
            this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        }
        else if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
          this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: mConbat.AssaultKingdomID, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        CString cstring3 = StringManager.Instance.StaticString1024();
        cstring3.StringToFormat(cstring1);
        cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(6025U));
        cstring1.ClearString();
        Name.ClearString();
        Tag.ClearString();
        Name.Append(mConbat.DefenceName);
        if (mConbat.DefenceAllianceTag != string.Empty)
        {
          Tag.Append(mConbat.DefenceAllianceTag);
          if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
            this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        }
        else if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
          this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: mConbat.DefenceKingdomID, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        mCstr.Append(cstring3);
        mCstr.StringToFormat(cstring1);
        mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(6026U));
        break;
      case 4:
      case 6:
        Name.Append(mConbat.DefenceName);
        if (mConbat.DefenceAllianceTag != string.Empty)
        {
          Tag.Append(mConbat.DefenceAllianceTag);
          if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
            this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, mConbat.DefenceKingdomID, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        }
        else if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
          this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: mConbat.DefenceKingdomID, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        mCstr.StringToFormat(cstring1);
        mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(9751U));
        break;
      case 5:
        Name.Append(mConbat.AssaultName);
        if (mConbat.DefenceAllianceTag != string.Empty)
        {
          Tag.Append(mConbat.AssaultAllianceTag);
          if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
            this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        }
        else if ((int) mConbat.AssaultKingdomID != (int) mConbat.DefenceKingdomID)
          this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: mConbat.AssaultKingdomID, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        mCstr.StringToFormat(cstring1);
        mCstr.AppendFormat(this.DM.mStringTable.GetStringByID(9752U));
        break;
    }
  }

  public void GetTextCombatbySide(NPCCombatReportContent mConbat, CString mCstr)
  {
    CString cstring1 = StringManager.Instance.StaticString1024();
    cstring1.ClearString();
    CString Name = StringManager.Instance.StaticString1024();
    Name.ClearString();
    CString Tag = StringManager.Instance.StaticString1024();
    Tag.ClearString();
    Name.Append(mConbat.AssaultName);
    if (mConbat.AssaultAllianceTag != string.Empty)
    {
      Tag.Append(mConbat.AssaultAllianceTag);
      if ((int) mConbat.AssaultKingdomID != (int) mConbat.KingdomID)
        this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, mConbat.AssaultKingdomID, this.GUIM.IsArabic);
      else
        this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
    }
    else if ((int) mConbat.AssaultKingdomID != (int) mConbat.KingdomID)
      this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: mConbat.AssaultKingdomID, ForceArabic: this.GUIM.IsArabic);
    else
      this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
    CString cstring2 = StringManager.Instance.StaticString1024();
    cstring2.ClearString();
    cstring2.Append(this.DM.mStringTable.GetStringByID(6023U));
    cstring2.StringToFormat(cstring1);
    cstring2.AppendFormat(this.DM.mStringTable.GetStringByID(6024U));
    cstring1.ClearString();
    Name.ClearString();
    Tag.ClearString();
    Name.Append(mConbat.NPCLevel.ToString());
    this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
    mCstr.Append(cstring2);
    cstring1.ClearString();
    Name.ClearString();
    Name.IntToFormat((long) mConbat.NPCLevel);
    Name.AppendFormat(this.DM.mStringTable.GetStringByID(12021U));
    mCstr.Append(cstring1);
    mCstr.Append(Name);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  private void Start()
  {
  }

  private void Update()
  {
    if (this.Pending && this.DM.MailReportGet(ref this.BattleReport))
    {
      if (this.BattleReport.Combat != null && this.BattleReport.Combat.Type == CombatCollectReport.CCR_MONSTER)
        this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 1);
      else
        this.door.OpenMenu(EGUIWindow.UI_FightingSummary);
    }
    this.EditorShowTime += Time.smoothDeltaTime;
    if ((double) this.EditorShowTime >= 0.0)
    {
      if ((double) this.EditorShowTime >= 2.0)
        this.EditorShowTime = 0.0f;
      ((Graphic) this.ImgEditor).color = new Color(1f, 1f, 1f, (double) this.EditorShowTime <= 1.0 ? this.EditorShowTime : 2f - this.EditorShowTime);
    }
    this.PageShowTime += Time.smoothDeltaTime;
    if ((double) this.PageShowTime >= 2.0)
      this.PageShowTime = 0.0f;
    ((Graphic) this.Img_PageShow[this.NowPage]).color = new Color(1f, 1f, 1f, (double) this.PageShowTime <= 1.0 ? this.PageShowTime : 2f - this.PageShowTime);
  }
}
