// Decompiled with JetBrains decompiler
// Type: UILetter_Resources
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UILetter_Resources : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private Font TTFont;
  private Door door;
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Tmp2;
  private Transform PreviousT;
  private Transform NextT;
  private Transform[] ItemT = new Transform[7];
  private Transform[] Itme_PT1 = new Transform[7];
  private Transform[] Itme_PT2 = new Transform[7];
  private Transform[] ItemResT = new Transform[7];
  private RectTransform[] Item_textTitleT = new RectTransform[7];
  private RectTransform[] Item_btnPorfileT = new RectTransform[7];
  private UIButton btn_EXIT;
  private UIButton btn_Delete;
  private UIButton btn_Previous;
  private UIButton btn_Next;
  private UIButton[] btn_Hero_Porfile = new UIButton[7];
  private Image tmpImg;
  private Image[] Img_ItemNew = new Image[7];
  private Image[] Img_ItemTitle = new Image[7];
  private Image[] Img_ItemBG = new Image[7];
  private Image[] Img_ItemIcon1 = new Image[7];
  private Image[] Img_ItemIcon2 = new Image[7];
  private Image[] Img_ItemIcon3 = new Image[7];
  private Image[] Img_ItemPorfile = new Image[7];
  private UIText tmptext;
  private UIText text_TitleName;
  private UIText text_Page;
  private UIText[] text_Time = new UIText[2];
  private UIText[] text_ItemTitle = new UIText[7];
  private UIText[] text_ItemTime = new UIText[7];
  private UIText[] text_ItemRes_1 = new UIText[7];
  private UIText[] text_ItemRes_2 = new UIText[7];
  private UIText[] text_ItemRes_3 = new UIText[7];
  private UIText[] text_ItemRes_4 = new UIText[7];
  private UIText[] text_ItemRes_5 = new UIText[7];
  private UIText[] text_Item = new UIText[7];
  private UIText[] text_ItemNew = new UIText[7];
  private UIText[] text_ItemPorfile = new UIText[7];
  private UIText[] text_ItemTitle2 = new UIText[7];
  private CString Cstr_Page;
  private CString[] Cstr_ItemTitle = new CString[7];
  private CString[] Cstr_ItemName = new CString[7];
  private CString[] Cstr_ItemRes_1 = new CString[7];
  private CString[] Cstr_ItemRes_2 = new CString[7];
  private CString[] Cstr_ItemRes_3 = new CString[7];
  private CString[] Cstr_ItemRes_4 = new CString[7];
  private CString[] Cstr_ItemRes_5 = new CString[7];
  private Material mMaT;
  private UISpritesArray SArray;
  private ScrollPanel m_ScrollPanel;
  private ScrollPanelItem[] mScrollItem = new ScrollPanelItem[7];
  private float tempL;
  private float MoveTime1;
  private float MoveTime2;
  private float TmpTime;
  private int MaxLetterNum;
  private int mResourcesMax;
  private int UnReadNum;
  private CombatReport Report;
  private CombatReport tmpCR;
  private MyFavorite Favor = new MyFavorite(Id: 0U);
  private Vector3 Vec3Instance;
  private List<float> tmplist = new List<float>();

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    CString SpriteName = StringManager.Instance.StaticString1024();
    this.Cstr_Page = StringManager.Instance.SpawnString();
    for (int index = 0; index < 7; ++index)
    {
      this.Cstr_ItemTitle[index] = StringManager.Instance.SpawnString(60);
      this.Cstr_ItemName[index] = StringManager.Instance.SpawnString();
      this.Cstr_ItemRes_1[index] = StringManager.Instance.SpawnString();
      this.Cstr_ItemRes_2[index] = StringManager.Instance.SpawnString();
      this.Cstr_ItemRes_3[index] = StringManager.Instance.SpawnString();
      this.Cstr_ItemRes_4[index] = StringManager.Instance.SpawnString();
      this.Cstr_ItemRes_5[index] = StringManager.Instance.SpawnString();
    }
    this.mMaT = this.door.LoadMaterial();
    this.Favor.Serial = this.DM.OpenMail.Serial;
    this.Favor.Type = this.DM.OpenMail.Type;
    this.Favor.Kind = this.DM.OpenMail.Kind;
    if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
    {
      this.Report = this.Favor.Combat;
      if (this.Report.UnSeen > (byte) 0)
        this.DM.BattleReportRead(this.Report.SerialID, false);
      this.mResourcesMax = (int) this.Report.More;
      for (int index = 0; index < this.mResourcesMax; ++index)
      {
        this.tmpCR = this.DM.ResourceReportGet(this.mResourcesMax - (1 + index));
        if (this.tmpCR != null && !this.tmpCR.BeRead)
          ++this.UnReadNum;
      }
      this.Tmp = this.GameT.GetChild(0).GetChild(1).GetChild(0);
      this.text_TitleName = this.Tmp.GetComponent<UIText>();
      this.text_TitleName.font = this.TTFont;
      this.text_TitleName.text = this.DM.mStringTable.GetStringByID(6042U);
      this.Tmp = this.GameT.GetChild(0).GetChild(1).GetChild(1);
      this.text_Page = this.Tmp.GetComponent<UIText>();
      this.text_Page.font = this.TTFont;
      this.Cstr_Page.ClearString();
      this.MaxLetterNum = (int) this.DM.GetMailboxSize();
      if (this.DM.OpenMail.Kind == MailType.EMAIL_BATTLE)
      {
        this.Cstr_Page.IntToFormat((long) ((int) this.Report.Index + 1));
        this.Cstr_Page.IntToFormat((long) this.MaxLetterNum);
      }
      if (this.GUIM.IsArabic)
        this.Cstr_Page.AppendFormat("{1}/{0}");
      else
        this.Cstr_Page.AppendFormat("{0}/{1}");
      this.text_Page.text = this.Cstr_Page.ToString();
      this.Tmp = this.GameT.GetChild(1).GetChild(0);
      this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
      this.Tmp1 = this.GameT.GetChild(1).GetChild(1).GetChild(1);
      this.Tmp2 = this.Tmp1.GetChild(0).GetChild(0).GetChild(0);
      this.tmptext = this.Tmp2.GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
      this.tmptext.text = this.DM.mStringTable.GetStringByID(6048U);
      this.Tmp2 = this.Tmp1.GetChild(0).GetChild(1);
      this.tmptext = this.Tmp2.GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
      this.Tmp2 = this.Tmp1.GetChild(0).GetChild(2);
      this.tmptext = this.Tmp2.GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
      this.Tmp2 = this.Tmp1.GetChild(0).GetChild(3);
      this.tmptext = this.Tmp2.GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
      this.Tmp2 = this.Tmp1.GetChild(0).GetChild(4);
      UIButton component = this.Tmp2.GetComponent<UIButton>();
      component.m_BtnID1 = 4;
      component.m_Handler = (IUIButtonClickHandler) this;
      this.Tmp2 = this.Tmp1.GetChild(0).GetChild(4).GetChild(1);
      this.tmptext = this.Tmp2.GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
      for (int index = 0; index < 5; ++index)
      {
        this.Tmp2 = this.Tmp1.GetChild(1).GetChild(0).GetChild(index).GetChild(0);
        this.tmptext = this.Tmp2.GetComponent<UIText>();
        this.tmptext.font = this.TTFont;
      }
      this.Tmp2 = this.Tmp1.GetChild(1).GetChild(1);
      this.tmptext = this.Tmp2.GetComponent<UIText>();
      this.tmptext.font = this.TTFont;
      this.tmptext.text = this.DM.mStringTable.GetStringByID(6046U);
      for (int index = 0; index < this.mResourcesMax + 1; ++index)
        this.tmplist.Add(101f);
      this.m_ScrollPanel.IntiScrollPanel(437f, 0.0f, 0.0f, this.tmplist, 7, (IUpDateScrollPanel) this);
      this.Tmp = this.GameT.GetChild(2).GetChild(0);
      this.btn_Delete = this.Tmp.GetComponent<UIButton>();
      this.btn_Delete.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Delete.m_BtnID1 = 1;
      this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
      this.btn_Delete.transition = (Selectable.Transition) 0;
      this.Tmp = this.GameT.GetChild(2).GetChild(1);
      this.text_Time[0] = this.Tmp.GetComponent<UIText>();
      this.text_Time[0].font = this.TTFont;
      this.Tmp = this.GameT.GetChild(2).GetChild(2);
      this.text_Time[1] = this.Tmp.GetComponent<UIText>();
      this.text_Time[1].font = this.TTFont;
      this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
      this.text_Time[0].SetAllDirty();
      this.text_Time[0].cachedTextGenerator.Invalidate();
      this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
      this.text_Time[1].SetAllDirty();
      this.text_Time[1].cachedTextGenerator.Invalidate();
      float x = ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x;
      this.tempL = (float) (((double) ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x - 853.0) / 2.0);
      this.PreviousT = this.GameT.GetChild(3);
      this.btn_Previous = this.PreviousT.GetComponent<UIButton>();
      this.btn_Previous.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Previous.m_BtnID1 = 2;
      this.btn_Previous.m_EffectType = e_EffectType.e_Scale;
      this.btn_Previous.transition = (Selectable.Transition) 0;
      this.NextT = this.GameT.GetChild(4);
      this.btn_Next = this.NextT.GetComponent<UIButton>();
      this.btn_Next.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Next.m_BtnID1 = 3;
      this.btn_Next.m_EffectType = e_EffectType.e_Scale;
      this.btn_Next.transition = (Selectable.Transition) 0;
      if ((double) this.tempL > 0.0 && (double) this.NextT.localPosition.x + (double) this.tempL > (double) x / 2.0)
        this.tempL = x / 2f - this.NextT.localPosition.x;
      this.MoveTime1 = this.NextT.localPosition.x + this.tempL;
      this.MoveTime2 = this.PreviousT.localPosition.x - this.tempL;
      if (this.GUIM.bOpenOnIPhoneX)
      {
        this.MoveTime1 -= this.GUIM.IPhoneX_DeltaX;
        this.MoveTime2 += this.GUIM.IPhoneX_DeltaX;
      }
      this.Vec3Instance.Set(this.MoveTime1, this.NextT.localPosition.y, this.NextT.localPosition.z);
      this.NextT.localPosition = this.Vec3Instance;
      this.Vec3Instance.Set(this.MoveTime2, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
      this.PreviousT.localPosition = this.Vec3Instance;
      if (this.MaxLetterNum > 1)
      {
        if ((int) this.Report.Index + 1 == 1)
        {
          ((Component) this.btn_Previous).gameObject.SetActive(false);
          if (!((UIBehaviour) this.btn_Next).IsActive())
            ((Component) this.btn_Next).gameObject.SetActive(true);
        }
        if ((int) this.Report.Index + 1 == this.MaxLetterNum)
        {
          ((Component) this.btn_Next).gameObject.SetActive(false);
          if (!((UIBehaviour) this.btn_Previous).IsActive())
            ((Component) this.btn_Previous).gameObject.SetActive(true);
        }
      }
      else
      {
        ((Component) this.btn_Previous).gameObject.SetActive(false);
        ((Component) this.btn_Next).gameObject.SetActive(false);
      }
      this.Tmp = this.GameT.GetChild(5);
      this.tmpImg = this.Tmp.GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_close_base");
      this.tmpImg.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.mMaT;
      if (this.GUIM.bOpenOnIPhoneX)
        ((Behaviour) this.tmpImg).enabled = false;
      this.Tmp = this.GameT.GetChild(5).GetChild(0);
      this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_close");
      this.btn_EXIT.image.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.btn_EXIT.image).material = this.mMaT;
      this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
      this.btn_EXIT.m_BtnID1 = 0;
      this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
      this.btn_EXIT.transition = (Selectable.Transition) 0;
      this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    }
    else
      this.door.CloseMenu();
  }

  public override void OnClose()
  {
    if (this.Cstr_Page != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Page);
    for (int index = 0; index < 7; ++index)
    {
      if (this.Cstr_ItemTitle[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemTitle[index]);
      if (this.Cstr_ItemName[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemName[index]);
      if (this.Cstr_ItemRes_1[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemRes_1[index]);
      if (this.Cstr_ItemRes_2[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemRes_2[index]);
      if (this.Cstr_ItemRes_3[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemRes_3[index]);
      if (this.Cstr_ItemRes_4[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemRes_4[index]);
      if (this.Cstr_ItemRes_5[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemRes_5[index]);
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 1:
        if (!this.DM.BattleReportDelete(this.Report.SerialID))
          break;
        this.door.CloseMenu();
        break;
      case 2:
        this.Open_NP_Mail(false);
        break;
      case 3:
        this.Open_NP_Mail(true);
        break;
      case 4:
        this.tmpCR = this.DM.ResourceReportGet(sender.m_BtnID2);
        if (this.tmpCR == null)
          break;
        DataManager.Instance.ShowLordProfile(this.tmpCR.Resource.Name);
        break;
    }
  }

  public void Open_NP_Mail(bool bNext)
  {
    if (!this.DM.MailReportGet(ref this.Favor, bNext) || this.Favor.Type != MailType.EMAIL_BATTLE)
      return;
    this.DM.OpenMail.Serial = this.Favor.Serial;
    this.DM.OpenMail.Type = this.Favor.Type;
    this.DM.OpenMail.Kind = this.Favor.Kind;
    switch (this.Favor.Combat.Type)
    {
      case CombatCollectReport.CCR_BATTLE:
      case CombatCollectReport.CCR_NPCCOMBAT:
        this.door.OpenMenu(EGUIWindow.UI_FightingSummary);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Resources);
        break;
      case CombatCollectReport.CCR_COLLECT:
        this.door.OpenMenu(EGUIWindow.UI_Letter_Collection);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Resources);
        break;
      case CombatCollectReport.CCR_SCOUT:
        if (this.Favor.Combat.Scout.ScoutLevel != (byte) 0)
          this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower);
        else
          this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 1);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Resources);
        break;
      case CombatCollectReport.CCR_RECON:
        this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Resources);
        break;
      case CombatCollectReport.CCR_MONSTER:
        if (this.Favor.Combat.Monster.Result < (byte) 2 || this.Favor.Combat.Monster.Result > (byte) 3)
          this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 1);
        else
          this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Resources);
        break;
      case CombatCollectReport.CCR_NPCSCOUT:
        this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Resources);
        break;
      case CombatCollectReport.CCR_PETREPORT:
        this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Resources);
        break;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (dataIdx > 0)
      this.tmpCR = this.DM.ResourceReportGet(this.mResourcesMax - dataIdx);
    if ((Object) this.ItemT[panelObjectIdx] == (Object) null)
    {
      this.ItemT[panelObjectIdx] = item.GetComponent<Transform>();
      this.mScrollItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      this.Itme_PT1[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(0);
      this.Itme_PT2[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(1);
      this.Img_ItemTitle[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetComponent<Image>();
      this.Img_ItemNew[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetComponent<Image>();
      this.text_ItemNew[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
      this.text_ItemTitle[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetComponent<UIText>();
      this.Item_textTitleT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetComponent<RectTransform>();
      this.text_ItemTime[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(2).GetComponent<UIText>();
      this.text_ItemTitle2[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(3).GetComponent<UIText>();
      this.btn_Hero_Porfile[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(4).GetComponent<UIButton>();
      this.btn_Hero_Porfile[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Hero_Porfile[panelObjectIdx].m_BtnID2 = this.mResourcesMax - dataIdx;
      this.Item_btnPorfileT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(4).GetComponent<RectTransform>();
      this.Img_ItemPorfile[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(4).GetChild(0).GetComponent<Image>();
      this.text_ItemPorfile[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(4).GetChild(1).GetComponent<UIText>();
      this.Img_ItemBG[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetComponent<Image>();
      this.ItemResT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0);
      this.text_ItemRes_1[panelObjectIdx] = this.ItemResT[panelObjectIdx].GetChild(0).GetChild(0).GetComponent<UIText>();
      this.text_ItemRes_2[panelObjectIdx] = this.ItemResT[panelObjectIdx].GetChild(1).GetChild(0).GetComponent<UIText>();
      this.text_ItemRes_3[panelObjectIdx] = this.ItemResT[panelObjectIdx].GetChild(2).GetChild(0).GetComponent<UIText>();
      this.text_ItemRes_4[panelObjectIdx] = this.ItemResT[panelObjectIdx].GetChild(3).GetChild(0).GetComponent<UIText>();
      this.text_ItemRes_5[panelObjectIdx] = this.ItemResT[panelObjectIdx].GetChild(4).GetChild(0).GetComponent<UIText>();
      this.text_Item[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetComponent<UIText>();
      this.Img_ItemIcon1[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(2).GetChild(0).GetComponent<Image>();
      this.Img_ItemIcon2[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(2).GetChild(1).GetComponent<Image>();
      this.Img_ItemIcon3[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(2).GetChild(2).GetComponent<Image>();
      if (dataIdx == 0)
      {
        this.Itme_PT1[panelObjectIdx].gameObject.SetActive(true);
      }
      else
      {
        this.Itme_PT2[panelObjectIdx].gameObject.SetActive(true);
        if (this.tmpCR != null)
          this.SetItemIcon(panelObjectIdx, (int) this.tmpCR.Resource.Result, true);
        if (this.UnReadNum >= dataIdx)
          ((Component) this.Img_ItemNew[panelObjectIdx]).gameObject.SetActive(true);
      }
    }
    else
    {
      this.btn_Hero_Porfile[panelObjectIdx].m_BtnID2 = this.mResourcesMax - dataIdx;
      if (dataIdx == 0)
      {
        this.Itme_PT1[panelObjectIdx].gameObject.SetActive(true);
        this.Itme_PT2[panelObjectIdx].gameObject.SetActive(false);
      }
      else
      {
        this.Itme_PT1[panelObjectIdx].gameObject.SetActive(false);
        this.Itme_PT2[panelObjectIdx].gameObject.SetActive(true);
        this.SetItemIcon(panelObjectIdx, this.mScrollItem[panelObjectIdx].m_BtnID2, false);
        if (this.tmpCR != null)
          this.SetItemIcon(panelObjectIdx, (int) this.tmpCR.Resource.Result, true);
      }
    }
    if (dataIdx <= 0)
      return;
    if (this.UnReadNum >= dataIdx)
    {
      this.Item_textTitleT[panelObjectIdx].anchoredPosition = this.text_ItemTitle[panelObjectIdx].ArabicFixPos(new Vector2(121f, this.Item_textTitleT[panelObjectIdx].anchoredPosition.y));
      ((Component) this.Img_ItemNew[panelObjectIdx]).gameObject.SetActive(true);
    }
    else
    {
      this.Item_textTitleT[panelObjectIdx].anchoredPosition = this.text_ItemTitle[panelObjectIdx].ArabicFixPos(new Vector2(39f, this.Item_textTitleT[panelObjectIdx].anchoredPosition.y));
      ((Component) this.Img_ItemNew[panelObjectIdx]).gameObject.SetActive(false);
    }
    if (this.tmpCR == null)
      return;
    this.Cstr_ItemName[panelObjectIdx].ClearString();
    this.Cstr_ItemName[panelObjectIdx].Append(this.tmpCR.Resource.Name);
    this.Cstr_ItemTitle[panelObjectIdx].ClearString();
    ((Component) this.text_ItemTitle2[panelObjectIdx]).gameObject.SetActive(false);
    switch (this.tmpCR.Resource.Result)
    {
      case 0:
        this.Cstr_ItemTitle[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(12084U));
        break;
      case 1:
        this.Cstr_ItemTitle[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(12085U));
        break;
      case 2:
        this.Cstr_ItemTitle[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID(12082U));
        break;
    }
    this.text_ItemTitle[panelObjectIdx].text = this.Cstr_ItemTitle[panelObjectIdx].ToString();
    this.text_ItemTitle[panelObjectIdx].SetAllDirty();
    this.text_ItemTitle[panelObjectIdx].cachedTextGenerator.Invalidate();
    this.text_ItemTitle[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
    this.text_ItemPorfile[panelObjectIdx].text = this.Cstr_ItemName[panelObjectIdx].ToString();
    this.text_ItemPorfile[panelObjectIdx].SetAllDirty();
    this.text_ItemPorfile[panelObjectIdx].cachedTextGenerator.Invalidate();
    this.text_ItemPorfile[panelObjectIdx].cachedTextGeneratorForLayout.Invalidate();
    ((Graphic) this.text_ItemPorfile[panelObjectIdx]).rectTransform.sizeDelta = new Vector2(this.text_ItemPorfile[panelObjectIdx].preferredWidth + 1f, ((Graphic) this.text_ItemPorfile[panelObjectIdx]).rectTransform.sizeDelta.y);
    if (this.GUIM.IsArabic)
      this.text_ItemPorfile[panelObjectIdx].UpdateArabicPos();
    this.Item_btnPorfileT[panelObjectIdx].sizeDelta = new Vector2(this.text_ItemPorfile[panelObjectIdx].preferredWidth + 1f, this.Item_btnPorfileT[panelObjectIdx].sizeDelta.y);
    ((Graphic) this.Img_ItemPorfile[panelObjectIdx]).rectTransform.sizeDelta = new Vector2(this.text_ItemPorfile[panelObjectIdx].preferredWidth + 1f, ((Graphic) this.Img_ItemPorfile[panelObjectIdx]).rectTransform.sizeDelta.y);
    this.Item_btnPorfileT[panelObjectIdx].anchoredPosition = !this.GUIM.IsArabic || (double) ((Transform) ((Graphic) this.text_ItemTitle[panelObjectIdx]).rectTransform).localScale.x != -1.0 ? new Vector2((float) ((double) ((Graphic) this.text_ItemTitle[panelObjectIdx]).rectTransform.anchoredPosition.x + (double) this.text_ItemTitle[panelObjectIdx].preferredWidth + 1.0), this.Item_btnPorfileT[panelObjectIdx].anchoredPosition.y) : new Vector2((float) ((double) ((Graphic) this.text_ItemTitle[panelObjectIdx]).rectTransform.anchoredPosition.x - (double) ((Graphic) this.text_ItemTitle[panelObjectIdx]).rectTransform.sizeDelta.x + (double) this.text_ItemTitle[panelObjectIdx].preferredWidth + 1.0), this.Item_btnPorfileT[panelObjectIdx].anchoredPosition.y);
    this.text_ItemTime[panelObjectIdx].text = GameConstants.GetDateTime(this.tmpCR.Times).ToString("MM/dd/yy HH:mm:ss");
    this.text_ItemTime[panelObjectIdx].SetAllDirty();
    this.text_ItemTime[panelObjectIdx].cachedTextGenerator.Invalidate();
    if (this.tmpCR.Resource.Result < (byte) 2)
    {
      this.Cstr_ItemRes_1[panelObjectIdx].ClearString();
      GameConstants.FormatResourceValue(this.Cstr_ItemRes_1[panelObjectIdx], this.tmpCR.Resource.Resource[0]);
      this.text_ItemRes_1[panelObjectIdx].text = this.Cstr_ItemRes_1[panelObjectIdx].ToString();
      this.text_ItemRes_1[panelObjectIdx].SetAllDirty();
      this.text_ItemRes_1[panelObjectIdx].cachedTextGenerator.Invalidate();
      this.Cstr_ItemRes_2[panelObjectIdx].ClearString();
      GameConstants.FormatResourceValue(this.Cstr_ItemRes_2[panelObjectIdx], this.tmpCR.Resource.Resource[1]);
      this.text_ItemRes_2[panelObjectIdx].text = this.Cstr_ItemRes_2[panelObjectIdx].ToString();
      this.text_ItemRes_2[panelObjectIdx].SetAllDirty();
      this.text_ItemRes_2[panelObjectIdx].cachedTextGenerator.Invalidate();
      this.Cstr_ItemRes_3[panelObjectIdx].ClearString();
      GameConstants.FormatResourceValue(this.Cstr_ItemRes_3[panelObjectIdx], this.tmpCR.Resource.Resource[2]);
      this.text_ItemRes_3[panelObjectIdx].text = this.Cstr_ItemRes_3[panelObjectIdx].ToString();
      this.text_ItemRes_3[panelObjectIdx].SetAllDirty();
      this.text_ItemRes_3[panelObjectIdx].cachedTextGenerator.Invalidate();
      this.Cstr_ItemRes_4[panelObjectIdx].ClearString();
      GameConstants.FormatResourceValue(this.Cstr_ItemRes_4[panelObjectIdx], this.tmpCR.Resource.Resource[3]);
      this.text_ItemRes_4[panelObjectIdx].text = this.Cstr_ItemRes_4[panelObjectIdx].ToString();
      this.text_ItemRes_4[panelObjectIdx].SetAllDirty();
      this.text_ItemRes_4[panelObjectIdx].cachedTextGenerator.Invalidate();
      this.Cstr_ItemRes_5[panelObjectIdx].ClearString();
      GameConstants.FormatResourceValue(this.Cstr_ItemRes_5[panelObjectIdx], this.tmpCR.Resource.Resource[4]);
      this.text_ItemRes_5[panelObjectIdx].text = this.Cstr_ItemRes_5[panelObjectIdx].ToString();
      this.text_ItemRes_5[panelObjectIdx].SetAllDirty();
      this.text_ItemRes_5[panelObjectIdx].cachedTextGenerator.Invalidate();
      this.ItemResT[panelObjectIdx].gameObject.SetActive(true);
      ((Component) this.text_Item[panelObjectIdx]).gameObject.SetActive(false);
    }
    else
    {
      this.ItemResT[panelObjectIdx].gameObject.SetActive(false);
      ((Component) this.text_Item[panelObjectIdx]).gameObject.SetActive(true);
    }
  }

  public void SetItemIcon(int ListIdx, int Result, bool bShow)
  {
    switch (Result)
    {
      case 0:
        this.Img_ItemTitle[ListIdx].sprite = this.SArray.m_Sprites[1];
        ((Component) this.Img_ItemIcon2[ListIdx]).gameObject.SetActive(bShow);
        break;
      case 1:
        this.Img_ItemTitle[ListIdx].sprite = this.SArray.m_Sprites[0];
        ((Component) this.Img_ItemIcon1[ListIdx]).gameObject.SetActive(bShow);
        break;
      case 2:
        this.Img_ItemTitle[ListIdx].sprite = this.SArray.m_Sprites[2];
        ((Component) this.Img_ItemIcon3[ListIdx]).gameObject.SetActive(bShow);
        break;
    }
    if (!bShow)
      return;
    this.mScrollItem[ListIdx].m_BtnID2 = Result;
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void SetPageData(bool bopen = false)
  {
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 1)
      return;
    this.tmplist.Clear();
    this.mResourcesMax = this.DM.GetMailboxResourceSize();
    for (int index = 0; index < this.mResourcesMax + 1; ++index)
      this.tmplist.Add(101f);
    this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        break;
      case NetworkNews.Refresh:
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Mailing)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.Refresh_FontTexture();
          break;
        }
        if (meg[1] == (byte) 1 && meg[2] == (byte) 2)
        {
          this.Favor.Serial = this.DM.GetMailboxReportSerial(ReportSubSet.REPORTSet_HELP);
          this.Favor.Type = this.DM.OpenMail.Type;
          this.Favor.Kind = this.DM.OpenMail.Kind;
          if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
          {
            this.Report = this.Favor.Combat;
            if (this.Report.UnSeen > (byte) 0)
              this.DM.BattleReportRead(this.Report.SerialID, false);
            this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
            this.text_Time[0].SetAllDirty();
            this.text_Time[0].cachedTextGenerator.Invalidate();
            this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
            this.text_Time[1].SetAllDirty();
            this.text_Time[1].cachedTextGenerator.Invalidate();
            this.tmplist.Clear();
            this.tmplist.Add(101f);
            this.mResourcesMax = this.DM.GetMailboxResourceSize();
            for (int index = 0; index < this.mResourcesMax; ++index)
            {
              this.tmplist.Add(101f);
              this.tmpCR = this.DM.ResourceReportGet(this.mResourcesMax - (1 + index));
              if (this.tmpCR != null && !this.tmpCR.BeRead)
                ++this.UnReadNum;
            }
            this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
          }
          else
          {
            this.door.CloseMenu();
            break;
          }
        }
        this.MaxLetterNum = (int) this.DM.GetMailboxSize();
        if (this.MaxLetterNum > 1)
        {
          if ((int) this.Report.Index + 1 == 1)
            ((Component) this.btn_Previous).gameObject.SetActive(false);
          else
            ((Component) this.btn_Previous).gameObject.SetActive(true);
          if ((int) this.Report.Index + 1 == this.MaxLetterNum)
            ((Component) this.btn_Next).gameObject.SetActive(false);
          else
            ((Component) this.btn_Next).gameObject.SetActive(true);
        }
        else
        {
          ((Component) this.btn_Previous).gameObject.SetActive(false);
          ((Component) this.btn_Next).gameObject.SetActive(false);
        }
        this.Cstr_Page.ClearString();
        if (this.DM.OpenMail.Kind == MailType.EMAIL_BATTLE)
        {
          this.Cstr_Page.IntToFormat((long) ((int) this.Report.Index + 1));
          this.Cstr_Page.IntToFormat((long) this.MaxLetterNum);
        }
        if (this.GUIM.IsArabic)
          this.Cstr_Page.AppendFormat("{1}/{0}");
        else
          this.Cstr_Page.AppendFormat("{0}/{1}");
        this.text_Page.text = this.Cstr_Page.ToString();
        this.text_Page.SetAllDirty();
        this.text_Page.cachedTextGenerator.Invalidate();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_TitleName != (Object) null && ((Behaviour) this.text_TitleName).enabled)
    {
      ((Behaviour) this.text_TitleName).enabled = false;
      ((Behaviour) this.text_TitleName).enabled = true;
    }
    if ((Object) this.text_Page != (Object) null && ((Behaviour) this.text_Page).enabled)
    {
      ((Behaviour) this.text_Page).enabled = false;
      ((Behaviour) this.text_Page).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_Time[index] != (Object) null && ((Behaviour) this.text_Time[index]).enabled)
      {
        ((Behaviour) this.text_Time[index]).enabled = false;
        ((Behaviour) this.text_Time[index]).enabled = true;
      }
    }
    for (int index = 0; index < 7; ++index)
    {
      if ((Object) this.text_ItemTitle[index] != (Object) null && ((Behaviour) this.text_ItemTitle[index]).enabled)
      {
        ((Behaviour) this.text_ItemTitle[index]).enabled = false;
        ((Behaviour) this.text_ItemTitle[index]).enabled = true;
      }
      if ((Object) this.text_ItemTime[index] != (Object) null && ((Behaviour) this.text_ItemTime[index]).enabled)
      {
        ((Behaviour) this.text_ItemTime[index]).enabled = false;
        ((Behaviour) this.text_ItemTime[index]).enabled = true;
      }
      if ((Object) this.text_ItemRes_1[index] != (Object) null && ((Behaviour) this.text_ItemRes_1[index]).enabled)
      {
        ((Behaviour) this.text_ItemRes_1[index]).enabled = false;
        ((Behaviour) this.text_ItemRes_1[index]).enabled = true;
      }
      if ((Object) this.text_ItemRes_2[index] != (Object) null && ((Behaviour) this.text_ItemRes_2[index]).enabled)
      {
        ((Behaviour) this.text_ItemRes_2[index]).enabled = false;
        ((Behaviour) this.text_ItemRes_2[index]).enabled = true;
      }
      if ((Object) this.text_ItemRes_3[index] != (Object) null && ((Behaviour) this.text_ItemRes_3[index]).enabled)
      {
        ((Behaviour) this.text_ItemRes_3[index]).enabled = false;
        ((Behaviour) this.text_ItemRes_3[index]).enabled = true;
      }
      if ((Object) this.text_ItemRes_4[index] != (Object) null && ((Behaviour) this.text_ItemRes_4[index]).enabled)
      {
        ((Behaviour) this.text_ItemRes_4[index]).enabled = false;
        ((Behaviour) this.text_ItemRes_4[index]).enabled = true;
      }
      if ((Object) this.text_ItemRes_5[index] != (Object) null && ((Behaviour) this.text_ItemRes_5[index]).enabled)
      {
        ((Behaviour) this.text_ItemRes_5[index]).enabled = false;
        ((Behaviour) this.text_ItemRes_5[index]).enabled = true;
      }
      if ((Object) this.text_Item[index] != (Object) null && ((Behaviour) this.text_Item[index]).enabled)
      {
        ((Behaviour) this.text_Item[index]).enabled = false;
        ((Behaviour) this.text_Item[index]).enabled = true;
      }
      if ((Object) this.text_ItemNew[index] != (Object) null && ((Behaviour) this.text_ItemNew[index]).enabled)
      {
        ((Behaviour) this.text_ItemNew[index]).enabled = false;
        ((Behaviour) this.text_ItemNew[index]).enabled = true;
      }
      if ((Object) this.text_ItemPorfile[index] != (Object) null && ((Behaviour) this.text_ItemPorfile[index]).enabled)
      {
        ((Behaviour) this.text_ItemPorfile[index]).enabled = false;
        ((Behaviour) this.text_ItemPorfile[index]).enabled = true;
      }
      if ((Object) this.text_ItemTitle2[index] != (Object) null && ((Behaviour) this.text_ItemTitle2[index]).enabled)
      {
        ((Behaviour) this.text_ItemTitle2[index]).enabled = false;
        ((Behaviour) this.text_ItemTitle2[index]).enabled = true;
      }
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
    this.TmpTime += Time.smoothDeltaTime * 40f;
    if ((double) this.TmpTime >= 40.0)
      this.TmpTime = 0.0f;
    float num = (double) this.TmpTime <= 20.0 ? this.TmpTime : 40f - this.TmpTime;
    if ((double) num < 0.0)
      num = 0.0f;
    if ((Object) this.NextT != (Object) null)
    {
      this.Vec3Instance.Set(this.MoveTime1 - num, this.NextT.localPosition.y, this.NextT.localPosition.z);
      this.NextT.localPosition = this.Vec3Instance;
    }
    if (!((Object) this.PreviousT != (Object) null))
      return;
    this.Vec3Instance.Set(this.MoveTime2 + num, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
    this.PreviousT.localPosition = this.Vec3Instance;
  }
}
