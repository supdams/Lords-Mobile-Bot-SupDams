// Decompiled with JetBrains decompiler
// Type: UILetter_Watchtower_Recon
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UILetter_Watchtower_Recon : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
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
  private Transform[] ItemT = new Transform[6];
  private Transform[] Itme_PT1 = new Transform[6];
  private Transform[] Itme_PT2 = new Transform[6];
  private RectTransform tmpRCT;
  private RectTransform[] BtnKXY_ItemRT = new RectTransform[6];
  private RectTransform[] BtnNameKXY_ItemRT = new RectTransform[6];
  private UIButton btn_EXIT;
  private UIButton btn_Delete;
  private UIButton btn_Previous;
  private UIButton btn_Next;
  private UIButton[] btn_KXY = new UIButton[6];
  private UIButton[] btn_NameKXY = new UIButton[6];
  private UIButton[] btn_Hero_Porfile = new UIButton[6];
  private Image tmpImg;
  private Image[] Img_Hero = new Image[6];
  private Image[] Img_HeroHead = new Image[6];
  private Image[] Img_NoHero = new Image[6];
  private Image[] Img_KXY = new Image[6];
  private Image[] Img_NameKXY = new Image[6];
  private Image[] Img_New = new Image[6];
  private UIText text_TitleName;
  private UIText text_Page;
  private UIText text_LastTitle;
  private UIText[] text_Time = new UIText[2];
  private UIText[] text_ItemTitle = new UIText[6];
  private UIText[] text_ItemTime = new UIText[6];
  private UIText[] text_ItemInfo = new UIText[6];
  private UIText[] text_ItemKXY = new UIText[6];
  private UIText[] text_ItemNew = new UIText[6];
  private UIText[] text_ItemNameKXY = new UIText[6];
  private UIText[] text_ItemName = new UIText[6];
  private UIText[] text_ItemKingdom = new UIText[6];
  private UIText[] text_ItemRecon = new UIText[6];
  private UIText[] text_ItemLv = new UIText[6];
  private CString Cstr_Title;
  private CString Cstr_Page;
  private CString[] Cstr_ItemTitle = new CString[6];
  private CString[] Cstr_ItemInfo = new CString[6];
  private CString[] Cstr_ItemKXY = new CString[6];
  private CString[] Cstr_ItemNameKXY = new CString[6];
  private CString[] Cstr_ItemKingdom = new CString[6];
  private ScrollPanel m_ScrollPanel;
  private ScrollPanelItem[] mScrollItem = new ScrollPanelItem[6];
  private Material mMaT;
  private Material IconMaterial;
  private Material FrameMaterial;
  private CombatReport Report;
  private CombatReport tmpCR;
  private MyFavorite Favor = new MyFavorite(Id: 0U);
  private float tempL;
  private float MoveTime1;
  private float MoveTime2;
  private float TmpTime;
  private float ShowMainHeroTime1;
  private int MaxLetterNum;
  private int mReconMax;
  private int UnReadNum;
  private int mWatchLv;
  private int mStatus;
  private Vector3 Vec3Instance;
  private Vector2 tmpV;
  private Hero tmpHero;
  private List<float> tmplist = new List<float>();

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    CString SpriteName = StringManager.Instance.StaticString1024();
    this.Cstr_Title = StringManager.Instance.SpawnString();
    this.Cstr_Page = StringManager.Instance.SpawnString();
    for (int index = 0; index < 6; ++index)
    {
      this.Cstr_ItemTitle[index] = StringManager.Instance.SpawnString(300);
      this.Cstr_ItemInfo[index] = StringManager.Instance.SpawnString(300);
      this.Cstr_ItemKXY[index] = StringManager.Instance.SpawnString();
      this.Cstr_ItemNameKXY[index] = StringManager.Instance.SpawnString();
      this.Cstr_ItemKingdom[index] = StringManager.Instance.SpawnString();
    }
    this.mMaT = this.door.LoadMaterial();
    this.IconMaterial = this.GUIM.m_IconSpriteAsset.GetMaterial();
    this.FrameMaterial = this.GUIM.GetFrameMaterial();
    this.Favor.Serial = this.DM.OpenMail.Serial;
    this.Favor.Type = this.DM.OpenMail.Type;
    this.Favor.Kind = this.DM.OpenMail.Kind;
    if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
    {
      this.Report = this.Favor.Combat;
      if (this.Report.UnSeen > (byte) 0)
        this.DM.BattleReportRead(this.Report.SerialID, false);
      this.Tmp = this.GameT.GetChild(0).GetChild(1).GetChild(0);
      this.text_TitleName = this.Tmp.GetComponent<UIText>();
      this.text_TitleName.font = this.TTFont;
      this.Cstr_Title.ClearString();
      if (this.Report.Recon.bAmbush == (byte) 1)
        this.Cstr_Title.Append(this.DM.mStringTable.GetStringByID(9748U));
      else if (this.Report.Recon.CombatPointKind == POINT_KIND.PK_YOLK)
      {
        this.Cstr_Title.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.Report.Recon.CombatPoint, this.Report.Recon.KingdomID));
        this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7263U));
      }
      else
      {
        this.Cstr_Title.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Recon.CombatPointKind));
        this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(5355U));
      }
      this.text_TitleName.text = this.Cstr_Title.ToString();
      this.text_TitleName.SetAllDirty();
      this.text_TitleName.cachedTextGenerator.Invalidate();
      this.Tmp = this.GameT.GetChild(0).GetChild(1).GetChild(1);
      this.text_Page = this.Tmp.GetComponent<UIText>();
      this.text_Page.font = this.TTFont;
      this.m_ScrollPanel = this.GameT.GetChild(1).GetComponent<ScrollPanel>();
      this.Tmp = this.GameT.GetChild(2).GetChild(1);
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(0).GetChild(0);
      UIText component1 = this.Tmp1.GetComponent<UIText>();
      component1.font = this.TTFont;
      component1.text = this.DM.mStringTable.GetStringByID(6048U);
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(1);
      UIButton component2 = this.Tmp1.GetComponent<UIButton>();
      component2.m_Handler = (IUIButtonClickHandler) this;
      component2.m_BtnID1 = 4;
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(1).GetChild(1);
      this.Tmp1.GetComponent<UIText>().font = this.TTFont;
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(2);
      this.Tmp1.GetComponent<UIText>().font = this.TTFont;
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(3);
      this.Tmp1.GetComponent<UIText>().font = this.TTFont;
      this.Tmp = this.GameT.GetChild(2).GetChild(1).GetChild(1).GetChild(0);
      this.Tmp1 = this.Tmp.GetChild(0);
      this.tmpImg = this.Tmp1.GetComponent<Image>();
      IgnoreRaycast component3 = ((Component) this.tmpImg).GetComponent<IgnoreRaycast>();
      if ((Object) component3 != (Object) null)
        Object.DestroyImmediate((Object) component3);
      UIButton uiButton = ((Component) this.tmpImg).gameObject.AddComponent<UIButton>();
      uiButton.m_EffectType = e_EffectType.e_Scale;
      uiButton.transition = (Selectable.Transition) 0;
      uiButton.m_BtnID1 = 5;
      uiButton.m_Handler = (IUIButtonClickHandler) this;
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
      this.tmpImg = this.Tmp1.GetComponent<Image>();
      ((MaskableGraphic) this.tmpImg).material = this.IconMaterial;
      this.tmpRCT = ((Component) this.tmpImg).GetComponent<RectTransform>();
      this.tmpRCT.anchorMin = new Vector2(9f / 128f, 9f / 128f);
      this.tmpRCT.anchorMax = new Vector2(119f / 128f, 119f / 128f);
      this.tmpRCT.offsetMin = Vector2.zero;
      this.tmpRCT.offsetMax = Vector2.zero;
      this.tmpRCT.pivot = new Vector2(0.5f, 0.5f);
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(1);
      this.tmpImg = this.Tmp1.GetComponent<Image>();
      ((MaskableGraphic) this.tmpImg).material = this.FrameMaterial;
      this.tmpImg.sprite = this.GUIM.LoadFrameSprite("hf011");
      this.tmpRCT = ((Component) this.tmpImg).GetComponent<RectTransform>();
      this.tmpRCT.anchorMin = Vector2.zero;
      this.tmpRCT.anchorMax = new Vector2(1f, 1f);
      this.tmpRCT.offsetMin = Vector2.zero;
      this.tmpRCT.offsetMax = Vector2.zero;
      this.Tmp1 = this.Tmp.GetChild(1).GetChild(0);
      this.tmpImg = this.Tmp1.GetComponent<Image>();
      if (this.GUIM.IsArabic)
        ((Component) this.tmpImg).gameObject.AddComponent<ArabicItemTextureRot>();
      this.Tmp = this.GameT.GetChild(2).GetChild(1).GetChild(1);
      this.Tmp1 = this.Tmp.GetChild(1);
      UIButton component4 = this.Tmp1.GetComponent<UIButton>();
      component4.m_BtnID1 = 5;
      component4.m_Handler = (IUIButtonClickHandler) this;
      this.Tmp1 = this.Tmp.GetChild(1).GetChild(1);
      this.Tmp1.GetComponent<UIText>().font = this.TTFont;
      this.Tmp1 = this.Tmp.GetChild(2);
      UIText component5 = this.Tmp1.GetComponent<UIText>();
      component5.font = this.TTFont;
      ((Graphic) component5).rectTransform.sizeDelta = new Vector2(581f, ((Graphic) component5).rectTransform.sizeDelta.y);
      component5.resizeTextMinSize = 9;
      this.Tmp1 = this.Tmp.GetChild(3);
      UIText component6 = this.Tmp1.GetComponent<UIText>();
      component6.font = this.TTFont;
      component6.text = this.DM.mStringTable.GetStringByID(5354U);
      this.Tmp1 = this.Tmp.GetChild(4);
      UIText component7 = this.Tmp1.GetComponent<UIText>();
      component7.font = this.TTFont;
      component7.text = this.DM.mStringTable.GetStringByID(6015U);
      this.Tmp1 = this.Tmp.GetChild(5);
      this.Tmp1.GetComponent<UIText>().font = this.TTFont;
      this.Tmp1 = this.Tmp.GetChild(6);
      this.Tmp1.GetComponent<UIText>().font = this.TTFont;
      this.mReconMax = (int) this.Report.More;
      for (int index = 0; index < this.mReconMax; ++index)
      {
        this.tmpCR = this.DM.ReconReportGet(this.mReconMax - (1 + index));
        if (this.tmpCR != null && !this.tmpCR.BeRead)
          ++this.UnReadNum;
      }
      for (int index = 0; index < this.mReconMax + 1; ++index)
        this.tmplist.Add(101f);
      this.m_ScrollPanel.IntiScrollPanel(437f, 0.0f, 0.0f, this.tmplist, 6, (IUpDateScrollPanel) this);
      this.Tmp = this.GameT.GetChild(3).GetChild(0);
      this.btn_Delete = this.Tmp.GetComponent<UIButton>();
      this.btn_Delete.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Delete.m_BtnID1 = 1;
      this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
      this.btn_Delete.transition = (Selectable.Transition) 0;
      this.Tmp = this.GameT.GetChild(3).GetChild(1);
      this.text_LastTitle = this.Tmp.GetComponent<UIText>();
      this.text_LastTitle.font = this.TTFont;
      this.text_LastTitle.text = this.DM.mStringTable.GetStringByID(5350U);
      this.Tmp = this.GameT.GetChild(3).GetChild(2);
      this.text_Time[0] = this.Tmp.GetComponent<UIText>();
      this.text_Time[0].font = this.TTFont;
      this.Tmp = this.GameT.GetChild(3).GetChild(3);
      this.text_Time[1] = this.Tmp.GetComponent<UIText>();
      this.text_Time[1].font = this.TTFont;
      float x = ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x;
      this.tempL = (float) (((double) ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x - 853.0) / 2.0);
      this.PreviousT = this.GameT.GetChild(4);
      this.btn_Previous = this.PreviousT.GetComponent<UIButton>();
      this.btn_Previous.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Previous.m_BtnID1 = 2;
      this.btn_Previous.m_EffectType = e_EffectType.e_Scale;
      this.btn_Previous.transition = (Selectable.Transition) 0;
      this.NextT = this.GameT.GetChild(5);
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
      this.Tmp = this.GameT.GetChild(6);
      this.tmpImg = this.Tmp.GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_close_base");
      this.tmpImg.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.mMaT;
      if (this.GUIM.bOpenOnIPhoneX)
        ((Behaviour) this.tmpImg).enabled = false;
      this.Tmp = this.GameT.GetChild(6).GetChild(0);
      this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_close");
      this.btn_EXIT.image.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.btn_EXIT.image).material = this.mMaT;
      this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
      this.btn_EXIT.m_BtnID1 = 0;
      this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
      this.btn_EXIT.transition = (Selectable.Transition) 0;
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
      this.text_Page.SetAllDirty();
      this.text_Page.cachedTextGenerator.Invalidate();
      this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
      this.text_Time[0].SetAllDirty();
      this.text_Time[0].cachedTextGenerator.Invalidate();
      this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
      this.text_Time[1].SetAllDirty();
      this.text_Time[1].cachedTextGenerator.Invalidate();
      ((Component) this.btn_Previous).gameObject.SetActive(true);
      ((Component) this.btn_Next).gameObject.SetActive(true);
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
      this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    }
    else
    {
      this.Report = (CombatReport) null;
      this.door.CloseMenu();
    }
  }

  public override void OnClose()
  {
    if (this.Cstr_Title != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Title);
    if (this.Cstr_Page != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Page);
    for (int index = 0; index < 6; ++index)
    {
      if (this.Cstr_ItemTitle[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemTitle[index]);
      if (this.Cstr_ItemInfo[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemInfo[index]);
      if (this.Cstr_ItemKXY[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemKXY[index]);
      if (this.Cstr_ItemNameKXY[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemNameKXY[index]);
      if (this.Cstr_ItemKingdom[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemKingdom[index]);
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
        this.tmpCR = this.DM.ReconReportGet(sender.m_BtnID2);
        if (this.tmpCR == null)
          break;
        if (this.tmpCR.Recon.CombatPointKind != POINT_KIND.PK_YOLK)
        {
          this.door.GoToPointCode(this.tmpCR.Recon.KingdomID, this.tmpCR.Recon.CombatlZone, this.tmpCR.Recon.CombatPoint, (byte) 0);
          break;
        }
        this.door.GoToWonder(this.tmpCR.Recon.KingdomID, this.tmpCR.Recon.CombatPoint);
        break;
      case 5:
        this.tmpCR = this.DM.ReconReportGet(sender.m_BtnID2);
        if (this.tmpCR == null || this.tmpCR.Recon == null || this.tmpCR.Recon.SrcName == null || !(this.tmpCR.Recon.SrcName != string.Empty))
          break;
        DataManager.Instance.ShowLordProfile(this.tmpCR.Recon.SrcName);
        break;
    }
  }

  public void Open_NP_Mail(bool bNext)
  {
    if (!this.DM.MailReportGet(ref this.Favor, bNext))
      return;
    switch (this.Favor.Type)
    {
      case MailType.EMAIL_SYSTEM:
        this.DM.OpenMail.Serial = this.Favor.Serial;
        this.DM.OpenMail.Type = this.Favor.Type;
        this.DM.OpenMail.Kind = this.Favor.Kind;
        this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
        break;
      case MailType.EMAIL_BATTLE:
        this.DM.OpenMail.Serial = this.Favor.Serial;
        this.DM.OpenMail.Type = this.Favor.Type;
        this.DM.OpenMail.Kind = this.Favor.Kind;
        switch (this.Favor.Combat.Type)
        {
          case CombatCollectReport.CCR_BATTLE:
          case CombatCollectReport.CCR_NPCCOMBAT:
            this.door.OpenMenu(EGUIWindow.UI_FightingSummary);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
            return;
          case CombatCollectReport.CCR_RESOURCE:
            this.door.OpenMenu(EGUIWindow.UI_Letter_Resources);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
            return;
          case CombatCollectReport.CCR_COLLECT:
            this.door.OpenMenu(EGUIWindow.UI_Letter_Collection);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
            return;
          case CombatCollectReport.CCR_SCOUT:
            this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
            return;
          case CombatCollectReport.CCR_RECON:
            return;
          case CombatCollectReport.CCR_MONSTER:
            if (this.Favor.Combat.Monster.Result < (byte) 2 || this.Favor.Combat.Monster.Result > (byte) 3)
              this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 1);
            else
              this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
            return;
          case CombatCollectReport.CCR_NPCSCOUT:
            this.door.CloseMenu();
            this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout);
            return;
          case CombatCollectReport.CCR_PETREPORT:
            this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
            return;
          default:
            return;
        }
      case MailType.EMAIL_LETTER:
        this.DM.OpenMail.Serial = this.Favor.Serial;
        this.DM.OpenMail.Type = this.Favor.Type;
        this.DM.OpenMail.Kind = this.Favor.Kind;
        this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_Letter_Watchtower_Recon);
        break;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) this.ItemT[panelObjectIdx] == (Object) null)
    {
      this.ItemT[panelObjectIdx] = item.GetComponent<Transform>();
      this.mScrollItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      this.Itme_PT1[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(0);
      this.Itme_PT2[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(1);
      this.Img_New[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetComponent<Image>();
      this.text_ItemNew[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
      this.btn_KXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetComponent<UIButton>();
      this.btn_KXY[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.BtnKXY_ItemRT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetComponent<RectTransform>();
      this.Img_KXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
      this.text_ItemKXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(1).GetChild(1).GetComponent<UIText>();
      this.text_ItemTitle[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(2).GetComponent<UIText>();
      this.text_ItemTime[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(0).GetChild(3).GetComponent<UIText>();
      this.Img_Hero[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();
      this.btn_Hero_Porfile[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0).GetChild(0).GetComponent<UIButton>();
      this.btn_Hero_Porfile[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.Img_HeroHead[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
      this.Img_NoHero[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>();
      this.btn_NameKXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetComponent<UIButton>();
      this.btn_NameKXY[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.BtnNameKXY_ItemRT[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetComponent<RectTransform>();
      this.Img_NameKXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>();
      this.text_ItemNameKXY[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(1).GetChild(1).GetComponent<UIText>();
      this.text_ItemInfo[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(2).GetComponent<UIText>();
      this.text_ItemLv[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(3).GetComponent<UIText>();
      this.text_ItemRecon[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(4).GetComponent<UIText>();
      this.text_ItemName[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(5).GetComponent<UIText>();
      this.text_ItemKingdom[panelObjectIdx] = this.Itme_PT2[panelObjectIdx].GetChild(1).GetChild(6).GetComponent<UIText>();
      if (this.UnReadNum >= dataIdx)
        ((Component) this.Img_New[panelObjectIdx]).gameObject.SetActive(true);
    }
    if (dataIdx == 0)
    {
      this.Itme_PT1[panelObjectIdx].gameObject.SetActive(true);
      this.Itme_PT2[panelObjectIdx].gameObject.SetActive(false);
    }
    else
    {
      this.Itme_PT1[panelObjectIdx].gameObject.SetActive(false);
      this.Itme_PT2[panelObjectIdx].gameObject.SetActive(true);
      this.SetItemData(dataIdx, panelObjectIdx);
    }
  }

  public void SetItemData(int Idx, int ItemIdx)
  {
    this.tmpCR = this.DM.ReconReportGet(this.mReconMax - Idx);
    if (this.tmpCR == null)
      return;
    if (this.UnReadNum >= Idx)
    {
      ((Graphic) this.text_ItemTitle[ItemIdx]).rectTransform.anchoredPosition = this.text_ItemTitle[ItemIdx].ArabicFixPos(new Vector2(121f, ((Graphic) this.text_ItemTitle[ItemIdx]).rectTransform.anchoredPosition.y));
      ((Component) this.Img_New[ItemIdx]).gameObject.SetActive(true);
    }
    else
    {
      ((Graphic) this.text_ItemTitle[ItemIdx]).rectTransform.anchoredPosition = this.text_ItemTitle[ItemIdx].ArabicFixPos(new Vector2(22f, ((Graphic) this.text_ItemTitle[ItemIdx]).rectTransform.anchoredPosition.y));
      ((Component) this.Img_New[ItemIdx]).gameObject.SetActive(false);
    }
    this.text_ItemTime[ItemIdx].text = GameConstants.GetDateTime(this.tmpCR.Times).ToString("MM/dd/yy HH:mm:ss");
    this.text_ItemTime[ItemIdx].SetAllDirty();
    this.text_ItemTime[ItemIdx].cachedTextGenerator.Invalidate();
    this.Cstr_ItemTitle[ItemIdx].ClearString();
    if (this.tmpCR.Recon.bAmbush == (byte) 1)
      this.Cstr_ItemTitle[ItemIdx].Append(this.DM.mStringTable.GetStringByID(9726U));
    else if (this.tmpCR.Recon.CombatPointKind == POINT_KIND.PK_YOLK)
      this.Cstr_ItemTitle[ItemIdx].Append(DataManager.MapDataController.GetYolkName((ushort) this.tmpCR.Recon.CombatPoint, this.tmpCR.Recon.KingdomID));
    else
      this.Cstr_ItemTitle[ItemIdx].Append(this.GUIM.GetPointName_Letter(this.tmpCR.Recon.CombatPointKind));
    this.text_ItemTitle[ItemIdx].text = this.Cstr_ItemTitle[ItemIdx].ToString();
    this.text_ItemTitle[ItemIdx].SetAllDirty();
    this.text_ItemTitle[ItemIdx].cachedTextGenerator.Invalidate();
    this.text_ItemTitle[ItemIdx].cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_ItemTitle[ItemIdx].preferredWidth + 1.0 > (double) ((Graphic) this.text_ItemTitle[ItemIdx]).rectTransform.sizeDelta.x)
      ((Graphic) this.text_ItemTitle[ItemIdx]).rectTransform.sizeDelta = new Vector2(this.text_ItemTitle[ItemIdx].preferredWidth + 1f, ((Graphic) this.text_ItemTitle[ItemIdx]).rectTransform.sizeDelta.y);
    this.Cstr_ItemNameKXY[ItemIdx].ClearString();
    this.mWatchLv = (int) this.tmpCR.Recon.WatchLevel;
    ((Component) this.text_ItemKingdom[ItemIdx]).gameObject.SetActive(false);
    if (this.mWatchLv >= 4)
    {
      CString Name = StringManager.Instance.StaticString1024();
      Name.ClearString();
      if (this.mWatchLv >= 10)
      {
        CString Tag = StringManager.Instance.StaticString1024();
        Tag.ClearString();
        Name.Append(this.tmpCR.Recon.SrcName);
        if (this.tmpCR.Recon.SrcAllianceTag != null && this.tmpCR.Recon.SrcAllianceTag.Length != 0)
        {
          Tag.Append(this.tmpCR.Recon.SrcAllianceTag);
          GameConstants.FormatRoleName(this.Cstr_ItemNameKXY[ItemIdx], Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
        }
        else
          GameConstants.FormatRoleName(this.Cstr_ItemNameKXY[ItemIdx], Name, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
        this.Cstr_ItemKingdom[ItemIdx].ClearString();
        if ((int) this.tmpCR.Recon.SrcKingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID)
        {
          this.Cstr_ItemKingdom[ItemIdx].IntToFormat((long) this.tmpCR.Recon.SrcKingdomID);
          if (this.GUIM.IsArabic)
            this.Cstr_ItemKingdom[ItemIdx].AppendFormat("{0}#");
          else
            this.Cstr_ItemKingdom[ItemIdx].AppendFormat("#{0}");
          ((Component) this.text_ItemKingdom[ItemIdx]).gameObject.SetActive(true);
        }
        this.text_ItemKingdom[ItemIdx].text = this.Cstr_ItemKingdom[ItemIdx].ToString();
        this.text_ItemKingdom[ItemIdx].SetAllDirty();
        this.text_ItemKingdom[ItemIdx].cachedTextGenerator.Invalidate();
        this.text_ItemKingdom[ItemIdx].cachedTextGeneratorForLayout.Invalidate();
      }
      else
      {
        Name.Append(this.tmpCR.Recon.SrcName);
        GameConstants.FormatRoleName(this.Cstr_ItemNameKXY[ItemIdx], Name, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      }
      this.text_ItemName[ItemIdx].text = this.Cstr_ItemNameKXY[ItemIdx].ToString();
      this.text_ItemNameKXY[ItemIdx].text = this.Cstr_ItemNameKXY[ItemIdx].ToString();
      this.text_ItemNameKXY[ItemIdx].SetAllDirty();
      this.text_ItemNameKXY[ItemIdx].cachedTextGenerator.Invalidate();
      this.text_ItemNameKXY[ItemIdx].cachedTextGeneratorForLayout.Invalidate();
      this.BtnNameKXY_ItemRT[ItemIdx].sizeDelta = new Vector2(this.text_ItemNameKXY[ItemIdx].preferredWidth + 1f, this.BtnNameKXY_ItemRT[ItemIdx].sizeDelta.y);
      ((Graphic) this.Img_NameKXY[ItemIdx]).rectTransform.sizeDelta = new Vector2(this.text_ItemNameKXY[ItemIdx].preferredWidth + 1f, ((Graphic) this.Img_NameKXY[ItemIdx]).rectTransform.sizeDelta.y);
      ((Graphic) this.text_ItemNameKXY[ItemIdx]).rectTransform.sizeDelta = new Vector2(this.text_ItemNameKXY[ItemIdx].preferredWidth + 1f, ((Graphic) this.text_ItemNameKXY[ItemIdx]).rectTransform.sizeDelta.y);
      if (((Component) this.text_ItemKingdom[ItemIdx]).gameObject.activeSelf)
      {
        ((Graphic) this.text_ItemKingdom[ItemIdx]).rectTransform.sizeDelta = new Vector2(this.text_ItemKingdom[ItemIdx].preferredWidth, ((Graphic) this.text_ItemKingdom[ItemIdx]).rectTransform.sizeDelta.y);
        this.BtnNameKXY_ItemRT[ItemIdx].anchoredPosition = new Vector2((float) ((double) ((Graphic) this.text_ItemNameKXY[ItemIdx]).rectTransform.sizeDelta.x / 2.0 + (double) this.text_ItemKingdom[ItemIdx].preferredWidth + 2.0 - 321.0), this.BtnNameKXY_ItemRT[ItemIdx].anchoredPosition.y);
        ((Graphic) this.text_ItemName[ItemIdx]).rectTransform.anchoredPosition = new Vector2((float) ((double) ((Graphic) this.text_ItemKingdom[ItemIdx]).rectTransform.anchoredPosition.x + (double) this.text_ItemKingdom[ItemIdx].preferredWidth + 3.0), ((Graphic) this.text_ItemName[ItemIdx]).rectTransform.anchoredPosition.y);
      }
      else
      {
        this.BtnNameKXY_ItemRT[ItemIdx].anchoredPosition = new Vector2((float) ((double) ((Graphic) this.text_ItemNameKXY[ItemIdx]).rectTransform.sizeDelta.x / 2.0 - 321.0), this.BtnNameKXY_ItemRT[ItemIdx].anchoredPosition.y);
        ((Graphic) this.text_ItemName[ItemIdx]).rectTransform.anchoredPosition = new Vector2(76f, ((Graphic) this.text_ItemName[ItemIdx]).rectTransform.anchoredPosition.y);
      }
    }
    else
    {
      this.text_ItemName[ItemIdx].text = this.DM.mStringTable.GetStringByID(12072U);
      ((Graphic) this.text_ItemName[ItemIdx]).rectTransform.anchoredPosition = new Vector2(76f, ((Graphic) this.text_ItemName[ItemIdx]).rectTransform.anchoredPosition.y);
    }
    this.text_ItemName[ItemIdx].SetAllDirty();
    this.text_ItemName[ItemIdx].cachedTextGenerator.Invalidate();
    this.text_ItemName[ItemIdx].cachedTextGeneratorForLayout.Invalidate();
    ((Graphic) this.text_ItemName[ItemIdx]).rectTransform.sizeDelta = new Vector2(this.text_ItemName[ItemIdx].preferredWidth + 1f, ((Graphic) this.text_ItemName[ItemIdx]).rectTransform.sizeDelta.y);
    if (this.GUIM.IsArabic)
      this.text_ItemName[ItemIdx].UpdateArabicPos();
    if (this.mWatchLv >= 15 && this.tmpCR.Recon.SrcHead != (ushort) 0)
    {
      ((Component) this.Img_Hero[ItemIdx]).gameObject.SetActive(true);
      ((Component) this.Img_NoHero[ItemIdx]).gameObject.SetActive(false);
      this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.tmpCR.Recon.SrcHead);
      this.Img_HeroHead[ItemIdx].sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
    }
    else
    {
      ((Component) this.Img_Hero[ItemIdx]).gameObject.SetActive(false);
      ((Component) this.Img_NoHero[ItemIdx]).gameObject.SetActive(true);
    }
    this.btn_Hero_Porfile[ItemIdx].m_BtnID2 = this.mReconMax - Idx;
    this.btn_NameKXY[ItemIdx].m_BtnID2 = this.mReconMax - Idx;
    if (this.mWatchLv < 15)
    {
      ((Component) this.text_ItemLv[ItemIdx]).gameObject.SetActive(true);
      ((Component) this.text_ItemName[ItemIdx]).gameObject.SetActive(true);
      ((Component) this.btn_NameKXY[ItemIdx]).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.text_ItemLv[ItemIdx]).gameObject.SetActive(false);
      ((Component) this.btn_NameKXY[ItemIdx]).gameObject.SetActive(true);
      ((Component) this.text_ItemName[ItemIdx]).gameObject.SetActive(false);
    }
    this.mStatus = this.tmpCR.Recon.AntiScout != (byte) 1 ? (this.tmpCR.Recon.CombatPointKind != POINT_KIND.PK_CITY || this.tmpCR.Recon.bAmbush != (byte) 0 ? 3 : 2) : 4;
    ((Component) this.btn_KXY[ItemIdx]).gameObject.SetActive(false);
    this.btn_KXY[ItemIdx].m_BtnID2 = this.mReconMax - Idx;
    this.Cstr_ItemInfo[ItemIdx].ClearString();
    switch (this.mStatus)
    {
      case 2:
        this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.tmpCR.Recon.CombatlZone, this.tmpCR.Recon.CombatPoint));
        this.Cstr_ItemInfo[ItemIdx].StringToFormat(this.GUIM.GetPointName_Letter(this.tmpCR.Recon.CombatPointKind));
        this.Cstr_ItemInfo[ItemIdx].AppendFormat(this.DM.mStringTable.GetStringByID(5355U));
        break;
      case 3:
        if (this.tmpCR.Recon.bAmbush == (byte) 1)
        {
          this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.tmpCR.Recon.CombatlZone, this.tmpCR.Recon.CombatPoint));
          this.Cstr_ItemInfo[ItemIdx].Append(this.DM.mStringTable.GetStringByID(9748U));
          break;
        }
        if (this.tmpCR.Recon.CombatPointKind == POINT_KIND.PK_YOLK)
        {
          this.tmpV = DataManager.MapDataController.GetYolkPos((ushort) this.tmpCR.Recon.CombatPoint, this.tmpCR.Recon.KingdomID);
          this.Cstr_ItemInfo[ItemIdx].StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.tmpCR.Recon.CombatPoint, this.tmpCR.Recon.KingdomID));
          this.Cstr_ItemInfo[ItemIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7263U));
          break;
        }
        this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.tmpCR.Recon.CombatlZone, this.tmpCR.Recon.CombatPoint));
        this.Cstr_ItemInfo[ItemIdx].StringToFormat(this.GUIM.GetPointName_Letter(this.tmpCR.Recon.CombatPointKind));
        this.Cstr_ItemInfo[ItemIdx].AppendFormat(this.DM.mStringTable.GetStringByID(5355U));
        break;
      case 4:
        this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.tmpCR.Recon.CombatlZone, this.tmpCR.Recon.CombatPoint));
        if (this.tmpCR.Recon.bAmbush == (byte) 1)
          this.Cstr_ItemInfo[ItemIdx].Append(this.DM.mStringTable.GetStringByID(9748U));
        this.Cstr_ItemInfo[ItemIdx].StringToFormat(this.GUIM.GetPointName_Letter(this.tmpCR.Recon.CombatPointKind));
        this.Cstr_ItemInfo[ItemIdx].AppendFormat(this.DM.mStringTable.GetStringByID(12077U));
        break;
    }
    this.text_ItemInfo[ItemIdx].text = this.Cstr_ItemInfo[ItemIdx].ToString();
    this.text_ItemInfo[ItemIdx].SetAllDirty();
    this.text_ItemInfo[ItemIdx].cachedTextGenerator.Invalidate();
    this.text_ItemInfo[ItemIdx].cachedTextGeneratorForLayout.Invalidate();
    this.Cstr_ItemKXY[ItemIdx].ClearString();
    this.Cstr_ItemKXY[ItemIdx].IntToFormat((long) this.tmpCR.Recon.KingdomID);
    this.Cstr_ItemKXY[ItemIdx].IntToFormat((long) (int) this.tmpV.x);
    this.Cstr_ItemKXY[ItemIdx].IntToFormat((long) (int) this.tmpV.y);
    if (this.GUIM.IsArabic)
      this.Cstr_ItemKXY[ItemIdx].AppendFormat("{2}:Y {1}:X {0}:K");
    else
      this.Cstr_ItemKXY[ItemIdx].AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
    this.text_ItemKXY[ItemIdx].text = this.Cstr_ItemKXY[ItemIdx].ToString();
    this.text_ItemKXY[ItemIdx].SetAllDirty();
    this.text_ItemKXY[ItemIdx].cachedTextGenerator.Invalidate();
    this.text_ItemKXY[ItemIdx].cachedTextGeneratorForLayout.Invalidate();
    ((Component) this.btn_KXY[ItemIdx]).gameObject.SetActive(true);
    this.BtnKXY_ItemRT[ItemIdx].sizeDelta = new Vector2(this.text_ItemKXY[ItemIdx].preferredWidth + 1f, this.BtnKXY_ItemRT[ItemIdx].sizeDelta.y);
    ((Graphic) this.Img_KXY[ItemIdx]).rectTransform.sizeDelta = new Vector2(this.text_ItemKXY[ItemIdx].preferredWidth + 1f, ((Graphic) this.Img_KXY[ItemIdx]).rectTransform.sizeDelta.y);
    ((Graphic) this.text_ItemKXY[ItemIdx]).rectTransform.sizeDelta = new Vector2(this.text_ItemKXY[ItemIdx].preferredWidth + 1f, ((Graphic) this.text_ItemKXY[ItemIdx]).rectTransform.sizeDelta.y);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 1)
      return;
    this.tmplist.Clear();
    this.mReconMax = this.DM.GetMailboxReconSize();
    for (int index = 0; index < this.mReconMax + 1; ++index)
      this.tmplist.Add(101f);
    this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
  }

  public override void UpdateTime(bool bOnSecond)
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

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_Mailing:
        if (meg[1] == (byte) 1 && meg[2] == (byte) 3)
        {
          this.Favor.Serial = this.DM.GetMailboxReportSerial(ReportSubSet.REPORTSet_RECON);
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
            this.Cstr_Title.ClearString();
            if (this.Report.Recon.bAmbush == (byte) 1)
              this.Cstr_Title.Append(this.DM.mStringTable.GetStringByID(9748U));
            else if (this.Report.Recon.CombatPointKind == POINT_KIND.PK_YOLK)
            {
              this.Cstr_Title.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.Report.Recon.CombatPoint, this.Report.Recon.KingdomID));
              this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7263U));
            }
            else
            {
              this.Cstr_Title.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Recon.CombatPointKind));
              this.Cstr_Title.AppendFormat(this.DM.mStringTable.GetStringByID(5355U));
            }
            this.text_TitleName.text = this.Cstr_Title.ToString();
            this.text_TitleName.SetAllDirty();
            this.text_TitleName.cachedTextGenerator.Invalidate();
            this.tmplist.Clear();
            this.tmplist.Add(101f);
            this.mReconMax = this.DM.GetMailboxReconSize();
            for (int index = 0; index < this.mReconMax; ++index)
            {
              this.tmplist.Add(101f);
              this.tmpCR = this.DM.ReconReportGet(this.mReconMax - (1 + index));
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
        this.text_Page.SetAllDirty();
        this.text_Page.cachedTextGenerator.Invalidate();
        if (this.MaxLetterNum > 1)
        {
          if ((int) this.Report.Index + 1 == 1)
            ((Component) this.btn_Previous).gameObject.SetActive(false);
          else
            ((Component) this.btn_Previous).gameObject.SetActive(true);
          if ((int) this.Report.Index + 1 == this.MaxLetterNum)
          {
            ((Component) this.btn_Next).gameObject.SetActive(false);
            break;
          }
          ((Component) this.btn_Next).gameObject.SetActive(true);
          break;
        }
        ((Component) this.btn_Previous).gameObject.SetActive(false);
        ((Component) this.btn_Next).gameObject.SetActive(false);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
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
    if ((Object) this.text_LastTitle != (Object) null && ((Behaviour) this.text_LastTitle).enabled)
    {
      ((Behaviour) this.text_LastTitle).enabled = false;
      ((Behaviour) this.text_LastTitle).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_Time[index] != (Object) null && ((Behaviour) this.text_Time[index]).enabled)
      {
        ((Behaviour) this.text_Time[index]).enabled = false;
        ((Behaviour) this.text_Time[index]).enabled = true;
      }
    }
    for (int index = 0; index < 6; ++index)
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
      if ((Object) this.text_ItemInfo[index] != (Object) null && ((Behaviour) this.text_ItemInfo[index]).enabled)
      {
        ((Behaviour) this.text_ItemInfo[index]).enabled = false;
        ((Behaviour) this.text_ItemInfo[index]).enabled = true;
      }
      if ((Object) this.text_ItemKXY[index] != (Object) null && ((Behaviour) this.text_ItemKXY[index]).enabled)
      {
        ((Behaviour) this.text_ItemKXY[index]).enabled = false;
        ((Behaviour) this.text_ItemKXY[index]).enabled = true;
      }
      if ((Object) this.text_ItemNew[index] != (Object) null && ((Behaviour) this.text_ItemNew[index]).enabled)
      {
        ((Behaviour) this.text_ItemNew[index]).enabled = false;
        ((Behaviour) this.text_ItemNew[index]).enabled = true;
      }
      if ((Object) this.text_ItemNameKXY[index] != (Object) null && ((Behaviour) this.text_ItemNameKXY[index]).enabled)
      {
        ((Behaviour) this.text_ItemNameKXY[index]).enabled = false;
        ((Behaviour) this.text_ItemNameKXY[index]).enabled = true;
      }
      if ((Object) this.text_ItemName[index] != (Object) null && ((Behaviour) this.text_ItemName[index]).enabled)
      {
        ((Behaviour) this.text_ItemName[index]).enabled = false;
        ((Behaviour) this.text_ItemName[index]).enabled = true;
      }
      if ((Object) this.text_ItemKingdom[index] != (Object) null && ((Behaviour) this.text_ItemKingdom[index]).enabled)
      {
        ((Behaviour) this.text_ItemKingdom[index]).enabled = false;
        ((Behaviour) this.text_ItemKingdom[index]).enabled = true;
      }
      if ((Object) this.text_ItemRecon[index] != (Object) null && ((Behaviour) this.text_ItemRecon[index]).enabled)
      {
        ((Behaviour) this.text_ItemRecon[index]).enabled = false;
        ((Behaviour) this.text_ItemRecon[index]).enabled = true;
      }
      if ((Object) this.text_ItemLv[index] != (Object) null && ((Behaviour) this.text_ItemLv[index]).enabled)
      {
        ((Behaviour) this.text_ItemLv[index]).enabled = false;
        ((Behaviour) this.text_ItemLv[index]).enabled = true;
      }
    }
  }
}
