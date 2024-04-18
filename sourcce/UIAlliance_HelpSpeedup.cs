// Decompiled with JetBrains decompiler
// Type: UIAlliance_HelpSpeedup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAlliance_HelpSpeedup : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIHIBtnClickHandler
{
  private Transform GameT;
  private Transform Tmp;
  private Transform ItemT;
  private Transform Socrll_T;
  private RectTransform ImgUp_RT;
  private RectTransform ImgScroll_RT;
  private RectTransform ImgScrollPanel_RT;
  private RectTransform NoHelp_RT;
  private RectTransform AllianceMoney_RT;
  private RectTransform CDTime_text_RT;
  private RectTransform CDTime_Img_RT;
  private RectTransform[] Help_RT = new RectTransform[2];
  private RectTransform[] MemberHelp_RT = new RectTransform[6];
  private UIButton btn_EXIT;
  private UIButton btn_Info;
  private UIButton btn_AllHelp;
  private UIButton[] btn_MemberHelp = new UIButton[6];
  private UIButton tmpbtn;
  private UIHIBtn Hbtn_Player;
  private UIHIBtn[] Hbtn_Member = new UIHIBtn[6];
  private UIHIBtn tmpHbtn;
  private Image Img_PlayerRank;
  private Image[] Img_HelpFull = new Image[2];
  private Image[] Img_Help = new Image[6];
  private Image[] Img_ItemRank = new Image[6];
  private Image[] Img_BonusRate = new Image[5];
  private Image tmpImg;
  private UIText text_PlayerName;
  private UIText text_AllianceMoney;
  private UIText text_ReSetTime;
  private UIText[] text_Help1 = new UIText[3];
  private UIText[] text_Help2 = new UIText[3];
  private UIText[] text_ItemName = new UIText[6];
  private UIText[] text_ItemHelpTitle = new UIText[6];
  private UIText[] text_ItemHelpKind = new UIText[6];
  private UIText[] text_ItemHelpValue = new UIText[6];
  private UIText[] text_tmpStr = new UIText[5];
  private UIText[] text_StrValue = new UIText[2];
  private UIText tmptext;
  private CString Cstr_AllianceMoney;
  private CString Cstr_ReSetTime;
  private CString[] Cstr_HelpTitle = new CString[2];
  private CString[] Cstr_HelpValue = new CString[2];
  private CString[] Cstr_StrValue = new CString[2];
  private CString[] Cstr_ItemHelpTitle = new CString[6];
  private CString[] Cstr_ItemHelpValue = new CString[6];
  private ScrollPanel m_ScrollPanel;
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[6];
  private DataManager DM;
  private GUIManager GUIM;
  private UISpritesArray SArray;
  private Font TTFont;
  private Door door;
  private Material IconMaterial;
  private List<float> tmplist = new List<float>();
  private ushort tmpBuildID;
  private RoleBuildingData tmpBuildData;
  private TechDataTbl tmpTechD;
  private BuildTypeData tmpBuildD;
  private int mType;
  private bool bShowText;
  private float mShowTime;
  private int mShowStatus;
  private float scaleCount;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.IconMaterial = this.GUIM.m_IconSpriteAsset.GetMaterial();
    this.Cstr_AllianceMoney = StringManager.Instance.SpawnString(100);
    this.Cstr_ReSetTime = StringManager.Instance.SpawnString();
    for (int index = 0; index < 2; ++index)
    {
      this.Cstr_HelpTitle[index] = StringManager.Instance.SpawnString();
      this.Cstr_HelpValue[index] = StringManager.Instance.SpawnString();
      this.Cstr_StrValue[index] = StringManager.Instance.SpawnString();
    }
    for (int index = 0; index < 6; ++index)
    {
      this.Cstr_ItemHelpTitle[index] = StringManager.Instance.SpawnString(100);
      this.Cstr_ItemHelpValue[index] = StringManager.Instance.SpawnString(100);
    }
    this.Tmp = this.GameT.GetChild(1);
    this.ImgUp_RT = this.Tmp.GetChild(0).GetComponent<RectTransform>();
    this.CDTime_Img_RT = this.Tmp.GetChild(1).GetComponent<RectTransform>();
    this.btn_Info = this.Tmp.GetChild(2).GetComponent<UIButton>();
    if (this.GUIM.IsArabic)
      ((Component) this.btn_Info).gameObject.AddComponent<ArabicItemTextureRot>();
    this.btn_Info.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Info.m_BtnID1 = 1;
    this.btn_Info.m_EffectType = e_EffectType.e_Scale;
    this.btn_Info.transition = (Selectable.Transition) 0;
    this.Hbtn_Player = this.Tmp.GetChild(3).GetComponent<UIHIBtn>();
    this.GUIM.InitianHeroItemImg(((Component) this.Hbtn_Player).transform, eHeroOrItem.Hero, this.DM.RoleAttr.Head, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.Img_PlayerRank = this.Tmp.GetChild(4).GetComponent<Image>();
    this.Img_PlayerRank.sprite = this.DM.RoleAlliance.Rank < AllianceRank.RANK1 ? this.SArray.m_Sprites[0] : this.SArray.m_Sprites[(int) (this.DM.RoleAlliance.Rank - (byte) 1)];
    if (this.GUIM.IsArabic)
      ((Component) this.Img_PlayerRank).transform.localScale = new Vector3(-1f, ((Component) this.Img_PlayerRank).transform.localScale.y, ((Component) this.Img_PlayerRank).transform.localScale.z);
    this.AllianceMoney_RT = this.Tmp.GetChild(5).GetChild(0).GetComponent<RectTransform>();
    this.text_tmpStr[0] = this.Tmp.GetChild(5).GetChild(1).GetComponent<UIText>();
    this.text_tmpStr[0].font = this.TTFont;
    this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(751U);
    ((Graphic) this.text_tmpStr[0]).rectTransform.anchoredPosition = new Vector2(-63.5f, ((Graphic) this.text_tmpStr[0]).rectTransform.anchoredPosition.y);
    ((Graphic) this.text_tmpStr[0]).rectTransform.sizeDelta = new Vector2(200f, ((Graphic) this.text_tmpStr[0]).rectTransform.sizeDelta.y);
    this.text_AllianceMoney = this.Tmp.GetChild(5).GetChild(2).GetComponent<UIText>();
    this.text_AllianceMoney.font = this.TTFont;
    this.text_AllianceMoney.resizeTextForBestFit = true;
    this.Cstr_AllianceMoney.ClearString();
    this.DM.DailyHelpGetAllianceMoney = (uint) Mathf.Clamp((float) this.DM.DailyHelpGetAllianceMoney, 0.0f, (float) (40000 * ((int) this.DM.AllianceMoneyBonusRate / 100)));
    this.Cstr_AllianceMoney.IntToFormat((long) this.DM.DailyHelpGetAllianceMoney, bNumber: true);
    this.Cstr_AllianceMoney.IntToFormat((long) (40000 * ((int) this.DM.AllianceMoneyBonusRate / 100)), bNumber: true);
    if (this.GUIM.IsArabic)
    {
      if (this.DM.AllianceMoneyBonusRate > (ushort) 100)
        this.Cstr_AllianceMoney.AppendFormat("<color=#ffff00>{1}</color> / {0}");
      else
        this.Cstr_AllianceMoney.AppendFormat("{1} / {0}");
    }
    else if (this.DM.AllianceMoneyBonusRate > (ushort) 100)
      this.Cstr_AllianceMoney.AppendFormat("{0} / <color=#ffff00>{1}</color>");
    else
      this.Cstr_AllianceMoney.AppendFormat("{0} / {1}");
    this.text_AllianceMoney.text = this.Cstr_AllianceMoney.ToString();
    ((Graphic) this.text_AllianceMoney).rectTransform.anchoredPosition = new Vector2(104f, ((Graphic) this.text_AllianceMoney).rectTransform.anchoredPosition.y);
    ((Graphic) this.text_AllianceMoney).rectTransform.sizeDelta = new Vector2(140f, ((Graphic) this.text_AllianceMoney).rectTransform.sizeDelta.y);
    this.AllianceMoney_RT.sizeDelta = new Vector2((float) (340U * this.DM.DailyHelpGetAllianceMoney) / (float) (40000 * ((int) this.DM.AllianceMoneyBonusRate / 100)), this.AllianceMoney_RT.sizeDelta.y);
    this.Img_BonusRate[0] = this.Tmp.GetChild(6).GetChild(0).GetComponent<Image>();
    ((MaskableGraphic) this.Img_BonusRate[0]).material = this.door.LoadMaterial();
    this.Img_BonusRate[1] = this.Tmp.GetChild(6).GetChild(1).GetComponent<Image>();
    ((MaskableGraphic) this.Img_BonusRate[1]).material = this.door.LoadMaterial();
    if (this.GUIM.IsArabic)
    {
      ((Component) this.Img_BonusRate[0]).gameObject.AddComponent<ArabicItemTextureRot>();
      ((Component) this.Img_BonusRate[1]).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    this.Img_Help[0] = this.Tmp.GetChild(7).GetComponent<Image>();
    this.Img_HelpFull[0] = this.Tmp.GetChild(7).GetChild(0).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.Img_HelpFull[0]).transform.localScale = new Vector3(-1f, ((Component) this.Img_HelpFull[0]).transform.localScale.y, ((Component) this.Img_HelpFull[0]).transform.localScale.z);
    this.text_Help1[0] = this.Tmp.GetChild(7).GetChild(4).GetComponent<UIText>();
    this.text_Help1[0].font = this.TTFont;
    this.Help_RT[0] = this.Tmp.GetChild(7).GetChild(1).GetComponent<RectTransform>();
    this.text_Help1[1] = this.Tmp.GetChild(7).GetChild(2).GetComponent<UIText>();
    this.text_Help1[1].font = this.TTFont;
    this.text_Help1[2] = this.Tmp.GetChild(7).GetChild(3).GetComponent<UIText>();
    this.text_Help1[2].font = this.TTFont;
    this.Img_Help[1] = this.Tmp.GetChild(8).GetComponent<Image>();
    this.Img_HelpFull[1] = this.Tmp.GetChild(8).GetChild(0).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.Img_HelpFull[1]).transform.localScale = new Vector3(-1f, ((Component) this.Img_HelpFull[1]).transform.localScale.y, ((Component) this.Img_HelpFull[1]).transform.localScale.z);
    this.text_Help2[0] = this.Tmp.GetChild(8).GetChild(4).GetComponent<UIText>();
    this.text_Help2[0].font = this.TTFont;
    this.Help_RT[1] = this.Tmp.GetChild(8).GetChild(1).GetComponent<RectTransform>();
    this.text_Help2[1] = this.Tmp.GetChild(8).GetChild(2).GetComponent<UIText>();
    this.text_Help2[1].font = this.TTFont;
    this.text_Help2[2] = this.Tmp.GetChild(8).GetChild(3).GetComponent<UIText>();
    this.text_Help2[2].font = this.TTFont;
    this.NoHelp_RT = this.Tmp.GetChild(9).GetComponent<RectTransform>();
    this.text_tmpStr[1] = this.Tmp.GetChild(9).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[1].font = this.TTFont;
    this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(761U);
    if ((double) this.text_tmpStr[1].preferredWidth > (double) ((Graphic) this.text_tmpStr[1]).rectTransform.sizeDelta.x)
    {
      ((Graphic) this.text_tmpStr[1]).rectTransform.sizeDelta = new Vector2(this.text_tmpStr[1].preferredWidth, ((Graphic) this.text_tmpStr[1]).rectTransform.sizeDelta.y);
      RectTransform component = this.Tmp.GetChild(9).GetChild(0).GetComponent<RectTransform>();
      component.sizeDelta = new Vector2(16f + this.text_tmpStr[1].preferredWidth, component.sizeDelta.y);
    }
    this.text_PlayerName = this.Tmp.GetChild(10).GetComponent<UIText>();
    this.text_PlayerName.font = this.TTFont;
    this.text_PlayerName.text = this.DM.RoleAttr.Name.ToString();
    this.text_ReSetTime = this.Tmp.GetChild(11).GetComponent<UIText>();
    this.text_ReSetTime.font = this.TTFont;
    this.CDTime_text_RT = this.Tmp.GetChild(11).GetComponent<RectTransform>();
    this.Cstr_ReSetTime.ClearString();
    this.Cstr_ReSetTime.IntToFormat((long) GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Hour, 2);
    this.Cstr_ReSetTime.IntToFormat((long) GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Minute, 2);
    this.Cstr_ReSetTime.AppendFormat(this.DM.mStringTable.GetStringByID(753U));
    this.text_ReSetTime.text = this.Cstr_ReSetTime.ToString();
    this.text_ReSetTime.SetAllDirty();
    this.text_ReSetTime.cachedTextGenerator.Invalidate();
    this.text_ReSetTime.cachedTextGeneratorForLayout.Invalidate();
    this.CDTime_text_RT.sizeDelta = new Vector2(this.text_ReSetTime.preferredWidth, this.CDTime_text_RT.sizeDelta.y);
    this.CDTime_Img_RT.anchoredPosition = new Vector2((float) ((double) this.CDTime_text_RT.anchoredPosition.x - (double) this.text_ReSetTime.preferredWidth - 8.0), this.CDTime_Img_RT.anchoredPosition.y);
    this.text_tmpStr[2] = this.Tmp.GetChild(12).GetComponent<UIText>();
    this.text_tmpStr[2].font = this.TTFont;
    this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(750U);
    this.Socrll_T = this.GameT.GetChild(2);
    this.ImgScroll_RT = this.GameT.GetChild(2).GetComponent<RectTransform>();
    this.m_ScrollPanel = this.GameT.GetChild(2).GetChild(0).GetComponent<ScrollPanel>();
    this.ImgScrollPanel_RT = this.GameT.GetChild(2).GetChild(0).GetComponent<RectTransform>();
    this.Tmp = this.GameT.GetChild(2).GetChild(1);
    this.tmptext = this.Tmp.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = this.Tmp.GetChild(0).GetChild(1).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmpImg = this.Tmp.GetChild(1).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.tmpImg).transform.localScale = new Vector3(-1f, ((Component) this.tmpImg).transform.localScale.y, ((Component) this.tmpImg).transform.localScale.z);
    this.tmptext = this.Tmp.GetChild(2).GetChild(1).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmptext = this.Tmp.GetChild(2).GetChild(2).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmpbtn = this.Tmp.GetChild(3).GetComponent<UIButton>();
    this.tmpbtn.m_Handler = (IUIButtonClickHandler) this;
    this.tmpbtn.m_BtnID1 = 3;
    this.tmpbtn.SoundIndex = (byte) 64;
    this.tmpbtn.m_EffectType = e_EffectType.e_Scale;
    this.tmpbtn.transition = (Selectable.Transition) 0;
    this.text_tmpStr[3] = this.Tmp.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[3].font = this.TTFont;
    this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(759U);
    this.tmpHbtn = this.Tmp.GetChild(4).GetComponent<UIHIBtn>();
    this.tmpHbtn.m_Handler = (IUIHIBtnClickHandler) this;
    ((MaskableGraphic) this.tmpHbtn.image).material = this.IconMaterial;
    this.GUIM.InitianHeroItemImg(((Component) this.tmpHbtn).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.btn_AllHelp = this.GameT.GetChild(3).GetComponent<UIButton>();
    this.btn_AllHelp.m_Handler = (IUIButtonClickHandler) this;
    this.btn_AllHelp.m_BtnID1 = 2;
    this.btn_AllHelp.m_EffectType = e_EffectType.e_Scale;
    this.btn_AllHelp.transition = (Selectable.Transition) 0;
    this.text_tmpStr[4] = this.GameT.GetChild(3).GetChild(1).GetComponent<UIText>();
    this.text_tmpStr[4].font = this.TTFont;
    this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(760U);
    this.Img_BonusRate[2] = this.GameT.GetChild(5).GetComponent<Image>();
    this.Img_BonusRate[2].sprite = this.door.LoadSprite("UI_mall_x_001");
    ((MaskableGraphic) this.Img_BonusRate[2]).material = this.door.LoadMaterial();
    this.Img_BonusRate[3] = this.GameT.GetChild(5).GetChild(0).GetComponent<Image>();
    ((MaskableGraphic) this.Img_BonusRate[3]).material = this.door.LoadMaterial();
    this.Img_BonusRate[4] = this.GameT.GetChild(5).GetChild(1).GetComponent<Image>();
    ((MaskableGraphic) this.Img_BonusRate[4]).material = this.door.LoadMaterial();
    if (this.DM.AllianceMoneyBonusRate > (ushort) 100 && this.DM.AllianceMoneyBonusRate <= (ushort) 400)
    {
      this.Cstr_StrValue[0].ClearString();
      this.Cstr_StrValue[0].IntToFormat((long) ((int) this.DM.AllianceMoneyBonusRate / 100));
      this.Cstr_StrValue[0].AppendFormat("UI_mall_{0}_001");
      if (this.GUIM.IsArabic)
      {
        this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_x_001");
        this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_x_001");
        this.Img_BonusRate[1].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
        this.Img_BonusRate[4].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
      }
      else
      {
        this.Img_BonusRate[0].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
        this.Img_BonusRate[3].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
        this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_x_001");
        this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_x_001");
      }
    }
    else if (this.GUIM.IsArabic)
    {
      this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_x_001");
      this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_x_001");
      this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_2_001");
      this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_2_001");
    }
    else
    {
      this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_2_001");
      this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_2_001");
      this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_x_001");
      this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_x_001");
    }
    if (this.GUIM.IsArabic)
    {
      ((Component) this.Img_BonusRate[3]).gameObject.AddComponent<ArabicItemTextureRot>();
      ((Component) this.Img_BonusRate[4]).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    this.CheckHelpChang();
    this.UpdatePanel(true);
    this.tmpImg = this.GameT.GetChild(6).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(6).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.door.LoadMaterial();
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void CheckHelpChang()
  {
    this.mType = 0;
    int index1 = 0;
    for (int index2 = 0; index2 < 2; ++index2)
    {
      switch (this.DM.mPlayHelpDataType[index2].Kind)
      {
        case 1:
          if (this.DM.mPlayHelpDataType[index2].HelpMax != (byte) 0 && (int) this.DM.mPlayHelpDataType[index2].AlreadyHelperNum == (int) this.DM.mPlayHelpDataType[index2].HelpMax)
          {
            ++this.mType;
            ((Component) this.Help_RT[index1]).gameObject.SetActive(true);
            ++index1;
            break;
          }
          break;
        case 2:
          ++this.mType;
          ((Component) this.Help_RT[index1]).gameObject.SetActive(true);
          ++index1;
          break;
      }
      if (index2 == 0 && this.mType == 1)
      {
        this.Cstr_HelpTitle[0].ClearString();
        this.tmpTechD = this.DM.TechData.GetRecordByKey(this.DM.ResearchTech);
        this.Cstr_HelpTitle[0].IntToFormat((long) ((int) this.DM.GetTechLevel(this.DM.ResearchTech) + 1));
        this.Cstr_HelpTitle[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpTechD.TechName));
        this.Cstr_HelpTitle[0].AppendFormat(this.DM.mStringTable.GetStringByID(4044U));
        this.text_Help1[0].text = this.Cstr_HelpTitle[0].ToString();
        this.text_Help1[1].text = this.DM.mStringTable.GetStringByID(755U);
        this.text_Help1[1].SetAllDirty();
        this.text_Help1[1].cachedTextGenerator.Invalidate();
        this.Cstr_HelpValue[0].ClearString();
        if (this.GUIM.IsArabic)
        {
          this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].HelpMax);
          this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].AlreadyHelperNum);
        }
        else
        {
          this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].AlreadyHelperNum);
          this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].HelpMax);
        }
        this.Cstr_HelpValue[0].AppendFormat("{0} / {1}");
        this.text_Help1[2].text = this.Cstr_HelpValue[0].ToString();
        this.text_Help1[2].SetAllDirty();
        this.text_Help1[2].cachedTextGenerator.Invalidate();
        this.Help_RT[0].sizeDelta = new Vector2((float) (259 * (int) this.DM.mPlayHelpDataType[0].AlreadyHelperNum) / (float) this.DM.mPlayHelpDataType[0].HelpMax, this.Help_RT[0].sizeDelta.y);
        if ((int) this.DM.mPlayHelpDataType[0].AlreadyHelperNum == (int) this.DM.mPlayHelpDataType[0].HelpMax)
          ((Component) this.Img_HelpFull[0]).gameObject.SetActive(true);
        else
          ((Component) this.Img_HelpFull[0]).gameObject.SetActive(false);
      }
      if (index2 == 1)
      {
        if (this.mType == 1 && this.DM.mPlayHelpDataType[0].Kind <= (byte) 1 && this.DM.mPlayHelpDataType[0].HelpMax == (byte) 0)
        {
          this.Cstr_HelpTitle[0].ClearString();
          this.tmpBuildData = this.GUIM.BuildingData.AllBuildsData[(int) this.GUIM.BuildingData.BuildingManorID];
          this.tmpBuildID = this.tmpBuildData.BuildID;
          this.tmpBuildD = this.DM.BuildsTypeData.GetRecordByKey(this.tmpBuildID);
          this.Cstr_HelpTitle[0].IntToFormat((long) ((int) this.tmpBuildData.Level + 1));
          this.Cstr_HelpTitle[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpBuildD.NameID));
          this.Cstr_HelpTitle[0].AppendFormat(this.DM.mStringTable.GetStringByID(4044U));
          this.text_Help1[0].text = this.Cstr_HelpTitle[0].ToString();
          this.text_Help1[1].text = this.DM.mStringTable.GetStringByID(754U);
          this.text_Help1[1].SetAllDirty();
          this.text_Help1[1].cachedTextGenerator.Invalidate();
          this.Cstr_HelpValue[0].ClearString();
          if (this.GUIM.IsArabic)
          {
            this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[1].HelpMax);
            this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[1].AlreadyHelperNum);
          }
          else
          {
            this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[1].AlreadyHelperNum);
            this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[1].HelpMax);
          }
          this.Cstr_HelpValue[0].AppendFormat("{0} / {1}");
          this.text_Help1[2].text = this.Cstr_HelpValue[0].ToString();
          this.text_Help1[2].SetAllDirty();
          this.text_Help1[2].cachedTextGenerator.Invalidate();
          this.Help_RT[0].sizeDelta = new Vector2((float) (259 * (int) this.DM.mPlayHelpDataType[1].AlreadyHelperNum) / (float) this.DM.mPlayHelpDataType[1].HelpMax, this.Help_RT[0].sizeDelta.y);
          if ((int) this.DM.mPlayHelpDataType[1].AlreadyHelperNum == (int) this.DM.mPlayHelpDataType[1].HelpMax)
            ((Component) this.Img_HelpFull[0]).gameObject.SetActive(true);
          else
            ((Component) this.Img_HelpFull[0]).gameObject.SetActive(false);
        }
        else
        {
          this.Cstr_HelpTitle[1].ClearString();
          if ((int) this.GUIM.BuildingData.BuildingManorID < this.GUIM.BuildingData.AllBuildsData.Length)
            this.tmpBuildData = this.GUIM.BuildingData.AllBuildsData[(int) this.GUIM.BuildingData.BuildingManorID];
          this.tmpBuildID = this.tmpBuildData.BuildID;
          this.tmpBuildD = this.DM.BuildsTypeData.GetRecordByKey(this.tmpBuildID);
          this.Cstr_HelpTitle[1].IntToFormat((long) ((int) this.tmpBuildData.Level + 1));
          this.Cstr_HelpTitle[1].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpBuildD.NameID));
          this.Cstr_HelpTitle[1].AppendFormat(this.DM.mStringTable.GetStringByID(4044U));
          this.text_Help2[0].text = this.Cstr_HelpTitle[1].ToString();
          this.text_Help2[1].text = this.DM.mStringTable.GetStringByID(754U);
          this.text_Help2[1].SetAllDirty();
          this.text_Help2[1].cachedTextGenerator.Invalidate();
          this.Cstr_HelpValue[1].ClearString();
          if (this.GUIM.IsArabic)
          {
            this.Cstr_HelpValue[1].IntToFormat((long) this.DM.mPlayHelpDataType[1].HelpMax);
            this.Cstr_HelpValue[1].IntToFormat((long) this.DM.mPlayHelpDataType[1].AlreadyHelperNum);
          }
          else
          {
            this.Cstr_HelpValue[1].IntToFormat((long) this.DM.mPlayHelpDataType[1].AlreadyHelperNum);
            this.Cstr_HelpValue[1].IntToFormat((long) this.DM.mPlayHelpDataType[1].HelpMax);
          }
          this.Cstr_HelpValue[1].AppendFormat("{0} / {1}");
          this.text_Help2[2].text = this.Cstr_HelpValue[1].ToString();
          this.text_Help2[2].SetAllDirty();
          this.text_Help2[2].cachedTextGenerator.Invalidate();
          this.Help_RT[1].sizeDelta = new Vector2((float) (259 * (int) this.DM.mPlayHelpDataType[1].AlreadyHelperNum) / (float) this.DM.mPlayHelpDataType[1].HelpMax, this.Help_RT[1].sizeDelta.y);
          if ((int) this.DM.mPlayHelpDataType[1].AlreadyHelperNum == (int) this.DM.mPlayHelpDataType[1].HelpMax)
            ((Component) this.Img_HelpFull[1]).gameObject.SetActive(true);
          else
            ((Component) this.Img_HelpFull[1]).gameObject.SetActive(false);
        }
      }
    }
    if (this.mType == 0)
    {
      for (int index3 = 0; index3 < 2; ++index3)
        ((Component) this.Img_Help[index3]).gameObject.SetActive(false);
    }
    else
    {
      if (this.mType != 1)
        return;
      ((Component) this.Img_Help[1]).gameObject.SetActive(false);
    }
  }

  public void UpdatePanel(bool bFirst = false)
  {
    this.tmplist.Clear();
    for (int index = 0; index < this.DM.mHelpDataList.Count; ++index)
      this.tmplist.Add(74f);
    this.ImgScroll_RT.anchoredPosition = new Vector2(this.ImgScroll_RT.anchoredPosition.x, (float) (120 - this.mType * 34));
    this.ImgScrollPanel_RT.sizeDelta = new Vector2(this.ImgScrollPanel_RT.sizeDelta.x, (float) (347 - this.mType * 34));
    this.ImgUp_RT.sizeDelta = new Vector2(this.ImgUp_RT.sizeDelta.x, (float) (88 + this.mType * 34));
    this.NoHelp_RT.anchoredPosition = new Vector2(this.NoHelp_RT.anchoredPosition.x, -143.5f - (float) (this.mType * 34));
    this.NoHelp_RT.sizeDelta = new Vector2(this.NoHelp_RT.sizeDelta.x, (float) (347 - this.mType * 34));
    if (bFirst)
      this.m_ScrollPanel.IntiScrollPanel((float) (347 - this.mType * 34), 0.0f, 0.0f, this.tmplist, 6, (IUpDateScrollPanel) this);
    else
      this.m_ScrollPanel.AddNewDataHeight(this.tmplist, (float) (347 - this.mType * 34));
    if (this.DM.AllianceMoneyBonusRate > (ushort) 100)
    {
      ((Component) this.Img_BonusRate[0]).gameObject.SetActive(true);
      ((Component) this.Img_BonusRate[1]).gameObject.SetActive(true);
    }
    if (this.DM.AllianceMoneyBonusRate > (ushort) 100 && this.DM.AllianceMoneyBonusRate <= (ushort) 400)
    {
      this.Cstr_StrValue[0].ClearString();
      this.Cstr_StrValue[0].IntToFormat((long) ((int) this.DM.AllianceMoneyBonusRate / 100));
      this.Cstr_StrValue[0].AppendFormat("UI_mall_{0}_001");
      if (this.GUIM.IsArabic)
      {
        this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_x_001");
        this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_x_001");
        this.Img_BonusRate[1].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
        this.Img_BonusRate[4].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
      }
      else
      {
        this.Img_BonusRate[0].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
        this.Img_BonusRate[3].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
        this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_x_001");
        this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_x_001");
      }
    }
    else if (this.GUIM.IsArabic)
    {
      this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_x_001");
      this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_x_001");
      this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_2_001");
      this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_2_001");
    }
    else
    {
      this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_2_001");
      this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_2_001");
      this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_x_001");
      this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_x_001");
    }
    if (this.DM.mHelpDataList.Count == 0)
    {
      ((Component) this.NoHelp_RT).gameObject.SetActive(true);
      this.Socrll_T.gameObject.SetActive(false);
      ((Behaviour) this.btn_AllHelp).enabled = false;
      if (this.bShowText || !((Component) this.Img_BonusRate[2]).gameObject.activeSelf)
        return;
      ((Component) this.Img_BonusRate[2]).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.NoHelp_RT).gameObject.SetActive(false);
      this.Socrll_T.gameObject.SetActive(true);
      ((Behaviour) this.btn_AllHelp).enabled = true;
    }
  }

  public override void OnClose()
  {
    if (this.Cstr_AllianceMoney != null)
      StringManager.Instance.DeSpawnString(this.Cstr_AllianceMoney);
    if (this.Cstr_ReSetTime != null)
      StringManager.Instance.DeSpawnString(this.Cstr_ReSetTime);
    for (int index = 0; index < 2; ++index)
    {
      if (this.Cstr_HelpTitle[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_HelpTitle[index]);
      if (this.Cstr_HelpValue[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_HelpValue[index]);
      if (this.Cstr_StrValue[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_StrValue[index]);
    }
    for (int index = 0; index < 6; ++index)
    {
      if (this.Cstr_ItemHelpTitle[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemHelpTitle[index]);
      if (this.Cstr_ItemHelpValue[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemHelpValue[index]);
    }
    this.GUIM.m_SpeciallyEffect.mUITransform = (Transform) null;
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
        this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(750U), this.DM.mStringTable.GetStringByID(799U), bInfo: true, BackExit: true);
        break;
      case 2:
        if (!this.GUIM.ShowUILock(EUILock.Alliance_Help))
          break;
        int num1 = this.DM.mHelpDataList.Count / 30;
        if (this.DM.mHelpDataList.Count % 30 != 0)
          ++num1;
        int count = this.DM.mHelpDataList.Count;
        for (int index1 = 0; index1 < num1; ++index1)
        {
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_HELP_SOMEBODY;
          messagePacket.AddSeqId();
          int data;
          if (count - 30 > 0)
          {
            data = 30;
            count -= 30;
          }
          else
            data = count;
          messagePacket.Add((ushort) data);
          for (int index2 = 0; index2 < data; ++index2)
            messagePacket.Add(this.DM.mHelpDataList[index1 * 30 + index2].AllianceHelpRecordSN);
          messagePacket.Send();
        }
        this.DM.mHelpDataList.Clear();
        this.UpdatePanel();
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 11);
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 17);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Info, 3);
        RectTransform component1 = ((Component) sender).transform.GetComponent<RectTransform>();
        this.GUIM.mStartV2 = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + component1.anchoredPosition.x, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - component1.anchoredPosition.y);
        RectTransform component2 = ((Component) this.btn_Info).transform.parent.GetComponent<RectTransform>();
        RectTransform component3 = ((Component) this.AllianceMoney_RT).transform.parent.GetComponent<RectTransform>();
        float num2 = 0.0f;
        if (this.GUIM.bOpenOnIPhoneX)
          num2 = this.GUIM.IPhoneX_DeltaX;
        this.GUIM.m_SpeciallyEffect.UI_bezieEnd = new Vector2((float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 + 2.5) - num2, (float) -((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 - (double) component2.anchoredPosition.y - (double) component3.anchoredPosition.y));
        this.GUIM.m_SpeciallyEffect.mUITransform = this.GameT.GetChild(1).GetChild(6);
        break;
      case 3:
        this.CheckOnClick(sender.m_BtnID2);
        RectTransform component4 = ((Component) sender).transform.parent.parent.parent.parent.GetComponent<RectTransform>();
        RectTransform component5 = ((Component) sender).transform.parent.GetComponent<RectTransform>();
        RectTransform component6 = ((Component) sender).transform.GetComponent<RectTransform>();
        this.GUIM.mStartV2 = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f + component4.anchoredPosition.x + component6.anchoredPosition.x, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f - component4.anchoredPosition.y - component5.anchoredPosition.y - component6.anchoredPosition.y);
        RectTransform component7 = ((Component) this.btn_Info).transform.parent.GetComponent<RectTransform>();
        RectTransform component8 = ((Component) this.AllianceMoney_RT).transform.parent.GetComponent<RectTransform>();
        float num3 = 0.0f;
        if (this.GUIM.bOpenOnIPhoneX)
          num3 = this.GUIM.IPhoneX_DeltaX;
        this.GUIM.m_SpeciallyEffect.UI_bezieEnd = new Vector2((float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 + 2.5) - num3, (float) -((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 - (double) component7.anchoredPosition.y - (double) component8.anchoredPosition.y));
        this.GUIM.m_SpeciallyEffect.mUITransform = this.GameT.GetChild(1).GetChild(6);
        break;
    }
  }

  public void CheckOnClick(int Idx)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Alliance_Help))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_HELP_SOMEBODY;
    messagePacket.AddSeqId();
    messagePacket.Add((ushort) 1);
    messagePacket.Add(this.DM.mHelpDataList[Idx].AllianceHelpRecordSN);
    messagePacket.Send();
    this.DM.mHelpDataList.RemoveAt(Idx);
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    this.ItemT = item.GetComponent<Transform>();
    if ((Object) this.tmpItem[panelObjectIdx] == (Object) null)
    {
      this.tmpItem[panelObjectIdx] = this.ItemT.GetComponent<ScrollPanelItem>();
      this.Img_ItemRank[panelObjectIdx] = this.ItemT.GetChild(1).GetComponent<Image>();
      this.text_ItemName[panelObjectIdx] = this.ItemT.GetChild(0).GetChild(0).GetComponent<UIText>();
      this.text_ItemHelpTitle[panelObjectIdx] = this.ItemT.GetChild(0).GetChild(1).GetComponent<UIText>();
      this.MemberHelp_RT[panelObjectIdx] = this.ItemT.GetChild(2).GetChild(0).GetComponent<RectTransform>();
      this.text_ItemHelpKind[panelObjectIdx] = this.ItemT.GetChild(2).GetChild(1).GetComponent<UIText>();
      this.text_ItemHelpValue[panelObjectIdx] = this.ItemT.GetChild(2).GetChild(2).GetComponent<UIText>();
      this.btn_MemberHelp[panelObjectIdx] = this.ItemT.GetChild(3).GetComponent<UIButton>();
      this.btn_MemberHelp[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.Hbtn_Member[panelObjectIdx] = this.ItemT.GetChild(4).GetComponent<UIHIBtn>();
    }
    this.Img_ItemRank[panelObjectIdx].sprite = this.SArray.m_Sprites[(int) (this.DM.mHelpDataList[dataIdx].Rank - (byte) 1)];
    this.text_ItemName[panelObjectIdx].text = this.DM.mHelpDataList[dataIdx].PlayerName;
    this.text_ItemName[panelObjectIdx].SetAllDirty();
    this.text_ItemName[panelObjectIdx].cachedTextGenerator.Invalidate();
    this.btn_MemberHelp[panelObjectIdx].m_BtnID2 = dataIdx;
    this.Cstr_ItemHelpTitle[panelObjectIdx].ClearString();
    if (this.DM.mHelpDataList[dataIdx].HelpKind == EAllianceHelpKind.EAHK_Research)
    {
      this.text_ItemHelpKind[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(755U);
      this.tmpTechD = this.DM.TechData.GetRecordByKey(this.DM.mHelpDataList[dataIdx].EventID);
      this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID(757U));
      this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID(755U));
      this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID(4549U));
      this.Cstr_ItemHelpTitle[panelObjectIdx].IntToFormat((long) this.DM.mHelpDataList[dataIdx].EventDataLv);
      this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpTechD.TechName));
      this.Cstr_ItemHelpTitle[panelObjectIdx].AppendFormat("{0}<color=#FFEE9E>{1} {2}{3} {4}</color>");
    }
    else
    {
      this.text_ItemHelpKind[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(754U);
      this.tmpBuildD = this.DM.BuildsTypeData.GetRecordByKey(this.DM.mHelpDataList[dataIdx].EventID);
      this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID(757U));
      this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID(754U));
      this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID(4549U));
      this.Cstr_ItemHelpTitle[panelObjectIdx].IntToFormat((long) this.DM.mHelpDataList[dataIdx].EventDataLv);
      this.Cstr_ItemHelpTitle[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpBuildD.NameID));
      this.Cstr_ItemHelpTitle[panelObjectIdx].AppendFormat("{0}<color=#FFEE9E>{1} {2}{3} {4}</color>");
    }
    this.text_ItemHelpTitle[panelObjectIdx].text = this.Cstr_ItemHelpTitle[panelObjectIdx].ToString();
    this.text_ItemHelpTitle[panelObjectIdx].SetAllDirty();
    this.text_ItemHelpTitle[panelObjectIdx].cachedTextGenerator.Invalidate();
    this.MemberHelp_RT[panelObjectIdx].sizeDelta = new Vector2((float) (259 * (int) this.DM.mHelpDataList[dataIdx].AlreadyHelperNum / (int) this.DM.mHelpDataList[dataIdx].HelpMax), this.MemberHelp_RT[panelObjectIdx].sizeDelta.y);
    this.Cstr_ItemHelpValue[panelObjectIdx].ClearString();
    if (this.GUIM.IsArabic)
    {
      this.Cstr_ItemHelpValue[panelObjectIdx].IntToFormat((long) this.DM.mHelpDataList[dataIdx].HelpMax);
      this.Cstr_ItemHelpValue[panelObjectIdx].IntToFormat((long) this.DM.mHelpDataList[dataIdx].AlreadyHelperNum);
    }
    else
    {
      this.Cstr_ItemHelpValue[panelObjectIdx].IntToFormat((long) this.DM.mHelpDataList[dataIdx].AlreadyHelperNum);
      this.Cstr_ItemHelpValue[panelObjectIdx].IntToFormat((long) this.DM.mHelpDataList[dataIdx].HelpMax);
    }
    this.Cstr_ItemHelpValue[panelObjectIdx].AppendFormat("{0} / {1}");
    this.text_ItemHelpValue[panelObjectIdx].text = this.Cstr_ItemHelpValue[panelObjectIdx].ToString();
    this.text_ItemHelpValue[panelObjectIdx].SetAllDirty();
    this.text_ItemHelpValue[panelObjectIdx].cachedTextGenerator.Invalidate();
    this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_Member[panelObjectIdx]).transform, eHeroOrItem.Hero, this.DM.mHelpDataList[dataIdx].Head, (byte) 11, (byte) 0);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if (this.DM.RoleAlliance.Id == 0U)
        {
          this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_HelpSpeedup);
          break;
        }
        if (this.mType == 1)
        {
          this.Cstr_HelpValue[0].ClearString();
          if (this.DM.mPlayHelpDataType[0].Kind != (byte) 0)
          {
            if (this.GUIM.IsArabic)
            {
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].HelpMax);
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].AlreadyHelperNum);
            }
            else
            {
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].AlreadyHelperNum);
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].HelpMax);
            }
            this.Help_RT[0].sizeDelta = new Vector2((float) (259 * (int) this.DM.mPlayHelpDataType[0].AlreadyHelperNum) / (float) this.DM.mPlayHelpDataType[0].HelpMax, this.Help_RT[0].sizeDelta.y);
            if ((int) this.DM.mPlayHelpDataType[0].AlreadyHelperNum == (int) this.DM.mPlayHelpDataType[0].HelpMax)
              ((Component) this.Img_HelpFull[0]).gameObject.SetActive(true);
            else
              ((Component) this.Img_HelpFull[0]).gameObject.SetActive(false);
          }
          else
          {
            if (this.GUIM.IsArabic)
            {
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[1].HelpMax);
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[1].AlreadyHelperNum);
            }
            else
            {
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[1].AlreadyHelperNum);
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[1].HelpMax);
            }
            this.Help_RT[0].sizeDelta = new Vector2((float) (259 * (int) this.DM.mPlayHelpDataType[1].AlreadyHelperNum) / (float) this.DM.mPlayHelpDataType[1].HelpMax, this.Help_RT[0].sizeDelta.y);
            if ((int) this.DM.mPlayHelpDataType[1].AlreadyHelperNum == (int) this.DM.mPlayHelpDataType[1].HelpMax)
              ((Component) this.Img_HelpFull[0]).gameObject.SetActive(true);
            else
              ((Component) this.Img_HelpFull[0]).gameObject.SetActive(false);
          }
          this.Cstr_HelpValue[0].AppendFormat("{0} / {1}");
          this.text_Help1[2].text = this.Cstr_HelpValue[0].ToString();
          this.text_Help1[2].SetAllDirty();
          this.text_Help1[2].cachedTextGenerator.Invalidate();
          break;
        }
        this.Cstr_HelpValue[0].ClearString();
        if (this.GUIM.IsArabic)
        {
          this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].HelpMax);
          this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].AlreadyHelperNum);
        }
        else
        {
          this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].AlreadyHelperNum);
          this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].HelpMax);
        }
        this.Cstr_HelpValue[0].AppendFormat("{0} / {1}");
        this.text_Help1[2].text = this.Cstr_HelpValue[0].ToString();
        this.text_Help1[2].SetAllDirty();
        this.text_Help1[2].cachedTextGenerator.Invalidate();
        if ((int) this.DM.mPlayHelpDataType[0].AlreadyHelperNum == (int) this.DM.mPlayHelpDataType[0].HelpMax)
          ((Component) this.Img_HelpFull[0]).gameObject.SetActive(true);
        else
          ((Component) this.Img_HelpFull[0]).gameObject.SetActive(false);
        this.Cstr_HelpValue[1].ClearString();
        if (this.GUIM.IsArabic)
        {
          this.Cstr_HelpValue[1].IntToFormat((long) this.DM.mPlayHelpDataType[1].HelpMax);
          this.Cstr_HelpValue[1].IntToFormat((long) this.DM.mPlayHelpDataType[1].AlreadyHelperNum);
        }
        else
        {
          this.Cstr_HelpValue[1].IntToFormat((long) this.DM.mPlayHelpDataType[1].AlreadyHelperNum);
          this.Cstr_HelpValue[1].IntToFormat((long) this.DM.mPlayHelpDataType[1].HelpMax);
        }
        this.Cstr_HelpValue[1].AppendFormat("{0} / {1}");
        this.text_Help2[2].text = this.Cstr_HelpValue[1].ToString();
        this.text_Help2[2].SetAllDirty();
        this.text_Help2[2].cachedTextGenerator.Invalidate();
        if ((int) this.DM.mPlayHelpDataType[1].AlreadyHelperNum == (int) this.DM.mPlayHelpDataType[1].HelpMax)
          ((Component) this.Img_HelpFull[1]).gameObject.SetActive(true);
        else
          ((Component) this.Img_HelpFull[1]).gameObject.SetActive(false);
        this.Help_RT[0].sizeDelta = new Vector2((float) (259 * (int) this.DM.mPlayHelpDataType[0].AlreadyHelperNum) / (float) this.DM.mPlayHelpDataType[0].HelpMax, this.Help_RT[0].sizeDelta.y);
        this.Help_RT[1].sizeDelta = new Vector2((float) (259 * (int) this.DM.mPlayHelpDataType[1].AlreadyHelperNum) / (float) this.DM.mPlayHelpDataType[1].HelpMax, this.Help_RT[0].sizeDelta.y);
        break;
      case NetworkNews.Refresh_Alliance:
        if (this.DM.RoleAlliance.Id == 0U)
        {
          this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_HelpSpeedup);
          break;
        }
        this.UpdatePanel();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_PlayerName != (Object) null && ((Behaviour) this.text_PlayerName).enabled)
    {
      ((Behaviour) this.text_PlayerName).enabled = false;
      ((Behaviour) this.text_PlayerName).enabled = true;
    }
    if ((Object) this.text_AllianceMoney != (Object) null && ((Behaviour) this.text_AllianceMoney).enabled)
    {
      ((Behaviour) this.text_AllianceMoney).enabled = false;
      ((Behaviour) this.text_AllianceMoney).enabled = true;
    }
    if ((Object) this.text_ReSetTime != (Object) null && ((Behaviour) this.text_ReSetTime).enabled)
    {
      ((Behaviour) this.text_ReSetTime).enabled = false;
      ((Behaviour) this.text_ReSetTime).enabled = true;
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.text_Help1[index] != (Object) null && ((Behaviour) this.text_Help1[index]).enabled)
      {
        ((Behaviour) this.text_Help1[index]).enabled = false;
        ((Behaviour) this.text_Help1[index]).enabled = true;
      }
      if ((Object) this.text_Help2[index] != (Object) null && ((Behaviour) this.text_Help2[index]).enabled)
      {
        ((Behaviour) this.text_Help2[index]).enabled = false;
        ((Behaviour) this.text_Help2[index]).enabled = true;
      }
    }
    for (int index = 0; index < 6; ++index)
    {
      if ((Object) this.text_ItemName[index] != (Object) null && ((Behaviour) this.text_ItemName[index]).enabled)
      {
        ((Behaviour) this.text_ItemName[index]).enabled = false;
        ((Behaviour) this.text_ItemName[index]).enabled = true;
      }
      if ((Object) this.text_ItemHelpTitle[index] != (Object) null && ((Behaviour) this.text_ItemHelpTitle[index]).enabled)
      {
        ((Behaviour) this.text_ItemHelpTitle[index]).enabled = false;
        ((Behaviour) this.text_ItemHelpTitle[index]).enabled = true;
      }
      if ((Object) this.text_ItemHelpKind[index] != (Object) null && ((Behaviour) this.text_ItemHelpKind[index]).enabled)
      {
        ((Behaviour) this.text_ItemHelpKind[index]).enabled = false;
        ((Behaviour) this.text_ItemHelpKind[index]).enabled = true;
      }
      if ((Object) this.text_ItemHelpValue[index] != (Object) null && ((Behaviour) this.text_ItemHelpValue[index]).enabled)
      {
        ((Behaviour) this.text_ItemHelpValue[index]).enabled = false;
        ((Behaviour) this.text_ItemHelpValue[index]).enabled = true;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
    if ((Object) this.Hbtn_Player != (Object) null && ((Behaviour) this.Hbtn_Player).enabled)
    {
      ((Behaviour) this.Hbtn_Player).enabled = false;
      ((Behaviour) this.Hbtn_Player).enabled = true;
    }
    if ((Object) this.tmpHbtn != (Object) null && ((Behaviour) this.tmpHbtn).enabled)
    {
      ((Behaviour) this.tmpHbtn).enabled = false;
      ((Behaviour) this.tmpHbtn).enabled = true;
    }
    for (int index = 0; index < 6; ++index)
    {
      if ((Object) this.Hbtn_Member[index] != (Object) null && ((Behaviour) this.Hbtn_Member[index]).enabled)
        this.Hbtn_Member[index].Refresh_FontTexture();
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.CheckHelpChang();
        this.UpdatePanel();
        break;
      case 2:
        if (this.mType == 1)
        {
          this.Cstr_HelpValue[0].ClearString();
          if (this.DM.mPlayHelpDataType[0].Kind > (byte) 1)
          {
            if (this.GUIM.IsArabic)
            {
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].HelpMax);
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].AlreadyHelperNum);
            }
            else
            {
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].AlreadyHelperNum);
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].HelpMax);
            }
            this.Help_RT[0].sizeDelta = new Vector2((float) (259 * (int) this.DM.mPlayHelpDataType[0].AlreadyHelperNum) / (float) this.DM.mPlayHelpDataType[0].HelpMax, this.Help_RT[0].sizeDelta.y);
            if ((int) this.DM.mPlayHelpDataType[0].AlreadyHelperNum == (int) this.DM.mPlayHelpDataType[0].HelpMax)
              ((Component) this.Img_HelpFull[0]).gameObject.SetActive(true);
            else
              ((Component) this.Img_HelpFull[0]).gameObject.SetActive(false);
          }
          else
          {
            if (this.GUIM.IsArabic)
            {
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[1].HelpMax);
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[1].AlreadyHelperNum);
            }
            else
            {
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[1].AlreadyHelperNum);
              this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[1].HelpMax);
            }
            this.Help_RT[0].sizeDelta = new Vector2((float) (259 * (int) this.DM.mPlayHelpDataType[1].AlreadyHelperNum) / (float) this.DM.mPlayHelpDataType[1].HelpMax, this.Help_RT[0].sizeDelta.y);
            if ((int) this.DM.mPlayHelpDataType[1].AlreadyHelperNum == (int) this.DM.mPlayHelpDataType[1].HelpMax)
              ((Component) this.Img_HelpFull[0]).gameObject.SetActive(true);
            else
              ((Component) this.Img_HelpFull[0]).gameObject.SetActive(false);
          }
          this.Cstr_HelpValue[0].AppendFormat("{0} / {1}");
          this.text_Help1[2].text = this.Cstr_HelpValue[0].ToString();
          this.text_Help1[2].SetAllDirty();
          this.text_Help1[2].cachedTextGenerator.Invalidate();
          break;
        }
        this.Cstr_HelpValue[0].ClearString();
        if (this.GUIM.IsArabic)
        {
          this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].HelpMax);
          this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].AlreadyHelperNum);
        }
        else
        {
          this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].AlreadyHelperNum);
          this.Cstr_HelpValue[0].IntToFormat((long) this.DM.mPlayHelpDataType[0].HelpMax);
        }
        this.Cstr_HelpValue[0].AppendFormat("{0} / {1}");
        this.text_Help1[2].text = this.Cstr_HelpValue[0].ToString();
        this.text_Help1[2].SetAllDirty();
        this.text_Help1[2].cachedTextGenerator.Invalidate();
        if ((int) this.DM.mPlayHelpDataType[0].AlreadyHelperNum == (int) this.DM.mPlayHelpDataType[0].HelpMax)
          ((Component) this.Img_HelpFull[0]).gameObject.SetActive(true);
        else
          ((Component) this.Img_HelpFull[0]).gameObject.SetActive(false);
        this.Cstr_HelpValue[1].ClearString();
        if (this.GUIM.IsArabic)
        {
          this.Cstr_HelpValue[1].IntToFormat((long) this.DM.mPlayHelpDataType[1].HelpMax);
          this.Cstr_HelpValue[1].IntToFormat((long) this.DM.mPlayHelpDataType[1].AlreadyHelperNum);
        }
        else
        {
          this.Cstr_HelpValue[1].IntToFormat((long) this.DM.mPlayHelpDataType[1].AlreadyHelperNum);
          this.Cstr_HelpValue[1].IntToFormat((long) this.DM.mPlayHelpDataType[1].HelpMax);
        }
        this.Cstr_HelpValue[1].AppendFormat("{0} / {1}");
        this.text_Help2[2].text = this.Cstr_HelpValue[1].ToString();
        this.text_Help2[2].SetAllDirty();
        this.text_Help2[2].cachedTextGenerator.Invalidate();
        if ((int) this.DM.mPlayHelpDataType[1].AlreadyHelperNum == (int) this.DM.mPlayHelpDataType[1].HelpMax)
          ((Component) this.Img_HelpFull[1]).gameObject.SetActive(true);
        else
          ((Component) this.Img_HelpFull[1]).gameObject.SetActive(false);
        this.Help_RT[0].sizeDelta = new Vector2((float) (259 * (int) this.DM.mPlayHelpDataType[0].AlreadyHelperNum) / (float) this.DM.mPlayHelpDataType[0].HelpMax, this.Help_RT[0].sizeDelta.y);
        this.Help_RT[1].sizeDelta = new Vector2((float) (259 * (int) this.DM.mPlayHelpDataType[1].AlreadyHelperNum) / (float) this.DM.mPlayHelpDataType[1].HelpMax, this.Help_RT[0].sizeDelta.y);
        break;
      case 3:
        this.Cstr_AllianceMoney.ClearString();
        this.DM.DailyHelpGetAllianceMoney = (uint) Mathf.Clamp((float) this.DM.DailyHelpGetAllianceMoney, 0.0f, (float) (40000 * ((int) this.DM.AllianceMoneyBonusRate / 100)));
        this.Cstr_AllianceMoney.IntToFormat((long) this.DM.DailyHelpGetAllianceMoney, bNumber: true);
        this.Cstr_AllianceMoney.IntToFormat((long) (40000 * ((int) this.DM.AllianceMoneyBonusRate / 100)), bNumber: true);
        if (this.GUIM.IsArabic)
        {
          if (this.DM.AllianceMoneyBonusRate > (ushort) 100)
            this.Cstr_AllianceMoney.AppendFormat("<color=#ffff00>{1}</color> / {0}");
          else
            this.Cstr_AllianceMoney.AppendFormat("{1} / {0}");
        }
        else if (this.DM.AllianceMoneyBonusRate > (ushort) 100)
          this.Cstr_AllianceMoney.AppendFormat("{0} / <color=#ffff00>{1}</color>");
        else
          this.Cstr_AllianceMoney.AppendFormat("{0} / {1}");
        this.text_AllianceMoney.text = this.Cstr_AllianceMoney.ToString();
        this.text_AllianceMoney.SetAllDirty();
        this.text_AllianceMoney.cachedTextGenerator.Invalidate();
        this.AllianceMoney_RT.sizeDelta = new Vector2((float) (340U * this.DM.DailyHelpGetAllianceMoney) / (float) (40000 * ((int) this.DM.AllianceMoneyBonusRate / 100)), this.AllianceMoney_RT.sizeDelta.y);
        this.UpdatePanel();
        break;
      case 4:
        this.Cstr_AllianceMoney.ClearString();
        this.Cstr_AllianceMoney.IntToFormat((long) this.DM.DailyHelpGetAllianceMoney, bNumber: true);
        this.Cstr_AllianceMoney.IntToFormat((long) (40000 * ((int) this.DM.AllianceMoneyBonusRate / 100)), bNumber: true);
        if (this.GUIM.IsArabic)
        {
          if (this.DM.AllianceMoneyBonusRate > (ushort) 100)
            this.Cstr_AllianceMoney.AppendFormat("<color=#ffff00>{1}</color> / {0}");
          else
            this.Cstr_AllianceMoney.AppendFormat("{1} / {0}");
        }
        else if (this.DM.AllianceMoneyBonusRate > (ushort) 100)
          this.Cstr_AllianceMoney.AppendFormat("{0} / <color=#ffff00>{1}</color>");
        else
          this.Cstr_AllianceMoney.AppendFormat("{0} / {1}");
        this.text_AllianceMoney.text = this.Cstr_AllianceMoney.ToString();
        this.text_AllianceMoney.SetAllDirty();
        this.text_AllianceMoney.cachedTextGenerator.Invalidate();
        this.AllianceMoney_RT.sizeDelta = new Vector2((float) (340U * this.DM.DailyHelpGetAllianceMoney) / (float) (40000 * ((int) this.DM.AllianceMoneyBonusRate / 100)), this.AllianceMoney_RT.sizeDelta.y);
        break;
      case 5:
        this.Cstr_AllianceMoney.ClearString();
        this.DM.DailyHelpGetAllianceMoney = (uint) Mathf.Clamp((float) this.DM.DailyHelpGetAllianceMoney, 0.0f, (float) (40000 * ((int) this.DM.AllianceMoneyBonusRate / 100)));
        this.Cstr_AllianceMoney.IntToFormat((long) this.DM.DailyHelpGetAllianceMoney, bNumber: true);
        this.Cstr_AllianceMoney.IntToFormat((long) (40000 * ((int) this.DM.AllianceMoneyBonusRate / 100)), bNumber: true);
        if (this.GUIM.IsArabic)
        {
          if (this.DM.AllianceMoneyBonusRate > (ushort) 100)
            this.Cstr_AllianceMoney.AppendFormat("<color=#ffff00>{1}</color> / {0}");
          else
            this.Cstr_AllianceMoney.AppendFormat("{1} / {0}");
        }
        else if (this.DM.AllianceMoneyBonusRate > (ushort) 100)
          this.Cstr_AllianceMoney.AppendFormat("{0} / <color=#ffff00>{1}</color>");
        else
          this.Cstr_AllianceMoney.AppendFormat("{0} / {1}");
        this.text_AllianceMoney.text = this.Cstr_AllianceMoney.ToString();
        this.text_AllianceMoney.SetAllDirty();
        this.text_AllianceMoney.cachedTextGenerator.Invalidate();
        this.AllianceMoney_RT.sizeDelta = new Vector2((float) (340U * this.DM.DailyHelpGetAllianceMoney) / (float) (40000 * ((int) this.DM.AllianceMoneyBonusRate / 100)), this.AllianceMoney_RT.sizeDelta.y);
        if (this.DM.AllianceMoneyBonusRate > (ushort) 100)
        {
          ((Component) this.Img_BonusRate[0]).gameObject.SetActive(true);
          ((Component) this.Img_BonusRate[1]).gameObject.SetActive(true);
        }
        else
        {
          ((Component) this.Img_BonusRate[0]).gameObject.SetActive(false);
          ((Component) this.Img_BonusRate[1]).gameObject.SetActive(false);
        }
        if (this.DM.AllianceMoneyBonusRate > (ushort) 100 && this.DM.AllianceMoneyBonusRate <= (ushort) 400)
        {
          this.Cstr_StrValue[0].ClearString();
          this.Cstr_StrValue[0].IntToFormat((long) ((int) this.DM.AllianceMoneyBonusRate / 100));
          this.Cstr_StrValue[0].AppendFormat("UI_mall_{0}_001");
          if (this.GUIM.IsArabic)
          {
            this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_x_001");
            this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_x_001");
            this.Img_BonusRate[1].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
            this.Img_BonusRate[4].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
            break;
          }
          this.Img_BonusRate[0].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
          this.Img_BonusRate[3].sprite = this.door.LoadSprite(this.Cstr_StrValue[0]);
          this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_x_001");
          this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_x_001");
          break;
        }
        if (this.GUIM.IsArabic)
        {
          this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_x_001");
          this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_x_001");
          this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_2_001");
          this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_2_001");
          break;
        }
        this.Img_BonusRate[0].sprite = this.door.LoadSprite("UI_mall_2_001");
        this.Img_BonusRate[3].sprite = this.door.LoadSprite("UI_mall_2_001");
        this.Img_BonusRate[1].sprite = this.door.LoadSprite("UI_mall_x_001");
        this.Img_BonusRate[4].sprite = this.door.LoadSprite("UI_mall_x_001");
        break;
      case 6:
        if (this.bShowText)
        {
          if (this.mShowStatus != 2)
            break;
          this.mShowTime = 2f;
          break;
        }
        if (this.DM.AllianceMoneyBonusRate <= (ushort) 100)
          break;
        this.mShowStatus = 1;
        this.mShowTime = 0.0f;
        this.bShowText = true;
        this.scaleCount = 0.5f;
        ((Component) this.Img_BonusRate[2]).gameObject.SetActive(true);
        ((Transform) ((Graphic) this.Img_BonusRate[2]).rectTransform).localScale = new Vector3(0.5f, 0.5f, 0.5f);
        ((Graphic) this.Img_BonusRate[3]).color = new Color(1f, 1f, 1f, 1f);
        ((Graphic) this.Img_BonusRate[4]).color = new Color(1f, 1f, 1f, 1f);
        break;
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
    if (!this.bShowText || !((Object) this.Img_BonusRate[2] != (Object) null) || !((Component) this.Img_BonusRate[2]).gameObject.activeSelf)
      return;
    if (this.mShowStatus == 1)
    {
      if ((double) this.mShowTime < 0.10000000149011612)
      {
        this.mShowTime += Time.smoothDeltaTime;
        this.scaleCount = Mathf.Lerp(0.5f, 1.3f, (float) (0.5 + 8.0 * (double) this.mShowTime));
        ((Transform) ((Graphic) this.Img_BonusRate[2]).rectTransform).localScale = new Vector3(this.scaleCount, this.scaleCount, this.scaleCount);
      }
      else
      {
        this.mShowStatus = 2;
        this.mShowTime = 1f;
      }
    }
    else if (this.mShowStatus == 2)
    {
      if ((double) this.mShowTime > 0.0)
      {
        this.mShowTime -= Time.smoothDeltaTime;
      }
      else
      {
        this.mShowStatus = 3;
        this.mShowTime = 0.5f;
      }
    }
    else
    {
      if (this.mShowStatus != 3)
        return;
      if ((double) this.mShowTime > 0.0)
      {
        this.mShowTime -= Time.smoothDeltaTime;
        ((Graphic) this.Img_BonusRate[3]).color = new Color(1f, 1f, 1f, this.mShowTime);
        ((Graphic) this.Img_BonusRate[4]).color = new Color(1f, 1f, 1f, this.mShowTime);
      }
      else
      {
        this.bShowText = false;
        this.mShowStatus = 0;
        this.mShowTime = 0.0f;
        ((Component) this.Img_BonusRate[2]).gameObject.SetActive(false);
      }
    }
  }
}
