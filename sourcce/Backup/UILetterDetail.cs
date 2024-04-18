// Decompiled with JetBrains decompiler
// Type: UILetterDetail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UILetterDetail : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUILEBtnClickHandler
{
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform PreviousT;
  private Transform NextT;
  private Transform Mask_T;
  private Transform Mask_T2;
  private Transform Letter_T;
  private Transform Letter_S_T;
  private Transform BookMarkT;
  private Transform[] BookMarkList = new Transform[10];
  private Transform[] ItemT = new Transform[6];
  private Transform[] Item_P1 = new Transform[6];
  private Transform[] Item_P2 = new Transform[6];
  private Transform[] Item_P3 = new Transform[6];
  private Transform MonsterXY_T;
  private Transform HeroStarUp_T;
  private Transform Gifts_T;
  private Transform baseline;
  private RectTransform rectBaseLineBtn;
  private RectTransform rectBaseLine;
  private CScrollRect Mask_S_SR;
  private RectTransform[] BookMark_TextRT = new RectTransform[10];
  private RectTransform[] BookMark_XYRT = new RectTransform[10];
  private RectTransform ContentRT;
  private RectTransform BuyIconRT;
  private RectTransform DeleteRT;
  private RectTransform CollectRT;
  private RectTransform ReplyRT;
  private RectTransform Content_RT2;
  private RectTransform TranslationRT;
  private RectTransform tmpRC;
  private UIButton btn_EXIT;
  private UIButton btn_Previous;
  private UIButton btn_Next;
  private UIButton btn_Delete;
  private UIButton btn_Collect;
  private UIButton btn_Reply;
  private UIButton btn_Delete_S;
  private UIButton btn_Collect_S;
  private UIButton btn_AllianceInvite_S;
  private UIButton[] btn_BookMarkList = new UIButton[10];
  private UIButton[] btn_BookMarkListXY = new UIButton[10];
  private UIButton btn_MonsterXY;
  private UIButton btn_Translation;
  private UIButton btn_Name;
  private UIButton btn_JoinAlliance;
  private UIHIBtn[][] Hbtn_Item = new UIHIBtn[6][];
  private UIHIBtn GiftsHbtn_Item;
  private UILEBtn mLebtn;
  private UILEBtn[][] Lebtn_Item = new UILEBtn[6][];
  private ScrollPanel m_ScrollPanel;
  private ScrollPanelItem[] mScrollItem = new ScrollPanelItem[6];
  private ScrollPanel m_ScrollPanel_Buy;
  private Image Img_TitleIcon;
  private Image Img_Hero;
  private Image Img_HeroF;
  private Image Img_Hero_S;
  private Image Img_HeroF_S;
  private Image Img_S_Activity_BG;
  private Image Img_S_Title;
  private Image Img_S_Crystal;
  private Image[] Img_HeroSkill = new Image[2];
  private Image[] Img_HeroSkill_1 = new Image[2];
  private Image[] Img_HeroSkill_2 = new Image[2];
  private Image[] Img_StarUpSkill = new Image[4];
  private Image[] Img_StarUpSkill_2 = new Image[4];
  private Image[] Img_StarUpSkill_L = new Image[4];
  private Image[] Img_BookMarkList = new Image[10];
  private Image Img_LordEquip_BG;
  private Image Img_CryptFinish_BG;
  private Image Img_BuyTreasure_BG;
  private Image Img_Translate;
  private Image tmpImg;
  private UIText text_Page;
  private UIText text_Name;
  private UIText text_Title;
  private UIText text_Contents;
  private UIText text_Contents_S;
  private UIText[] text_Time = new UIText[2];
  private UIText[] text_Skill_1 = new UIText[2];
  private UIText[] text_Skill_2 = new UIText[2];
  private UIText[] text_BookMarkList = new UIText[10];
  private UIText[] text_BookMarkList2 = new UIText[10];
  private UIText text_S_Title;
  private UIText[] text_S_Top = new UIText[3];
  private UIText[][] text_S_ItemNum = new UIText[6][];
  private UIText text_LordEquip_Lv;
  private UIText[] text_LordEquip = new UIText[2];
  private UIText[][] text_LordEquip_Effect = new UIText[6][];
  private UIText text_CryptFinish;
  private UIText text_MonsterXY;
  private UIText[] text_StarUp_1 = new UIText[4];
  private UIText[] text_StarUp_2 = new UIText[4];
  private UIText[] text_tmpStr = new UIText[7];
  private UIText text_Translation;
  private UIText tmptext;
  private UIText[] text_Gifts = new UIText[2];
  private CString Cstr_Name;
  private CString Cstr_Page;
  private CString Cstr_Skill;
  private CString Cstr_Title;
  private CString Cstr_Contents_S;
  private CString[] Cstr_SkillIcon = new CString[2];
  private CString[] Cstr_Time = new CString[2];
  private CString Cstr_S_Title;
  private CString[] Cstr_S_Top = new CString[3];
  private CString[][] Cstr_S_ItemNum = new CString[6][];
  private CString[] Cstr_BookMarkList2 = new CString[10];
  private CString Cstr_LordEquip_Lv;
  private CString[] Cstr_LordEquip = new CString[2];
  private CString[][] Cstr_LordEquip_Effect = new CString[6][];
  private CString[] Cstr_StarUpValue = new CString[4];
  private CString Cstr_Translation;
  private CString[] Cstr_Gifts = new CString[2];
  private DataManager DM;
  private GUIManager GUIM;
  private UISpritesArray SArray;
  private Font TTFont;
  private Door door;
  private Material m_Mat;
  private MallManager MM;
  private MailContent MC;
  private NoticeContent SC;
  private CombatReport CR;
  private int mStatus;
  private int MaxLetterNum;
  private float tmpHeight;
  private float tempL;
  private float MoveTime1;
  private float MoveTime2;
  private float TmpTime;
  private Vector3 Vec3Instance;
  private MyFavorite Favor = new MyFavorite(Id: 0U);
  public byte[] LegionRankMagnifation = new byte[5]
  {
    (byte) 1,
    (byte) 2,
    (byte) 4,
    (byte) 8,
    (byte) 20
  };
  public byte[] LordExp = new byte[6]
  {
    (byte) 0,
    (byte) 10,
    (byte) 15,
    (byte) 30,
    (byte) 60,
    (byte) 150
  };
  private int mLetterKind;
  private int tmpPageNum;
  private Hero tmpHero;
  private Skill mSkill;
  private ushort[] mHeroSkill = new ushort[4];
  private string[] Str_HeroColor = new string[4];
  private List<float> tmplist = new List<float>();
  private List<ushort> tmplistItem = new List<ushort>();
  private uint mDiamond;
  private uint mValue;
  private byte mNoValueCount;
  private bool bAddList = true;
  private ushort ShopID;
  private Equip tmpEQ;
  private List<LordEquipEffectSet> effectList = new List<LordEquipEffectSet>();
  private Vector2 tmpV;
  private bool[] bFindScrollComp = new bool[7];
  private UnitComp_MallDetail[] ScrollComp = new UnitComp_MallDetail[7];
  private CString[] CountStr = new CString[7];
  private CString[] NameStr = new CString[7];
  private byte ItemCount;
  private bool bTrans;
  private bool bTransBtnStatus = true;
  private byte GiftTopCount;
  private Detail_Prize mPrizeType;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.MM = MallManager.Instance;
    this.GameT = this.gameObject.transform;
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.m_Mat = this.door.LoadMaterial();
    if (IGGGameSDK.Instance.GetTranslateStatus() && this.DM.MySysSetting.bAutoTranslate)
      this.bTrans = true;
    this.Favor.Serial = this.DM.OpenMail.Serial;
    this.Favor.Type = this.DM.OpenMail.Type;
    this.Favor.Kind = this.DM.OpenMail.Kind;
    if (this.DM.MailReportGet(ref this.Favor))
    {
      switch (this.Favor.Type)
      {
        case MailType.EMAIL_SYSTEM:
          this.SC = this.Favor.System;
          if (!this.SC.BeRead)
          {
            if (this.Favor.Kind == MailType.EMAIL_SYSTEM)
              this.DM.SystemReportRead(this.SC.SerialID, false);
            else
              this.DM.FavorReportRead(this.SC.SerialID, false);
          }
          this.mLetterKind = 1;
          break;
        case MailType.EMAIL_BATTLE:
          this.CR = this.Favor.Combat;
          if (!this.CR.BeRead)
          {
            if (this.Favor.Kind == MailType.EMAIL_BATTLE)
              this.DM.BattleReportRead(this.CR.SerialID, false);
            else
              this.DM.FavorReportRead(this.CR.SerialID, false);
          }
          this.mLetterKind = 2;
          break;
        case MailType.EMAIL_LETTER:
          this.MC = this.Favor.Mail;
          if (!this.MC.BeRead)
          {
            if (this.Favor.Kind == MailType.EMAIL_LETTER)
              this.DM.MailReportRead(this.MC.SerialID, false);
            else
              this.DM.FavorReportRead(this.MC.SerialID, false);
          }
          this.mLetterKind = 0;
          break;
      }
      this.Cstr_Name = StringManager.Instance.SpawnString();
      this.Cstr_Page = StringManager.Instance.SpawnString();
      this.Cstr_Skill = StringManager.Instance.SpawnString();
      this.Cstr_Title = StringManager.Instance.SpawnString(500);
      this.Cstr_S_Title = StringManager.Instance.SpawnString();
      this.Cstr_LordEquip_Lv = StringManager.Instance.SpawnString(100);
      this.Cstr_Translation = StringManager.Instance.SpawnString(100);
      for (int index = 0; index < 2; ++index)
      {
        this.Cstr_Time[index] = StringManager.Instance.SpawnString();
        this.Cstr_SkillIcon[index] = StringManager.Instance.SpawnString();
        this.Cstr_LordEquip[index] = StringManager.Instance.SpawnString(100);
        this.Cstr_Gifts[index] = StringManager.Instance.SpawnString(100);
      }
      for (int index = 0; index < 4; ++index)
        this.Cstr_StarUpValue[index] = StringManager.Instance.SpawnString();
      for (int index = 0; index < 3; ++index)
        this.Cstr_S_Top[index] = StringManager.Instance.SpawnString();
      for (int index1 = 0; index1 < 6; ++index1)
      {
        this.Hbtn_Item[index1] = new UIHIBtn[5];
        this.Lebtn_Item[index1] = new UILEBtn[5];
        this.text_S_ItemNum[index1] = new UIText[5];
        this.Cstr_S_ItemNum[index1] = new CString[5];
        for (int index2 = 0; index2 < 5; ++index2)
          this.Cstr_S_ItemNum[index1][index2] = StringManager.Instance.SpawnString(10);
        this.Cstr_LordEquip_Effect[index1] = new CString[2];
        this.text_LordEquip_Effect[index1] = new UIText[2];
        for (int index3 = 0; index3 < 2; ++index3)
          this.Cstr_LordEquip_Effect[index1][index3] = StringManager.Instance.SpawnString();
      }
      for (int index = 0; index < 10; ++index)
        this.Cstr_BookMarkList2[index] = StringManager.Instance.SpawnString();
      this.Cstr_Contents_S = StringManager.Instance.SpawnString(300);
      for (int index = 0; index < 4; ++index)
        this.Str_HeroColor[index] = this.DM.mStringTable.GetStringByID((uint) (ushort) (7651 + index));
      this.Tmp = this.GameT.GetChild(0).GetChild(0);
      this.Img_TitleIcon = this.Tmp.GetComponent<Image>();
      this.mStatus = arg1;
      this.Img_TitleIcon.sprite = this.SArray.m_Sprites[5 + this.mStatus];
      this.Img_TitleIcon.SetNativeSize();
      this.Tmp = this.GameT.GetChild(0).GetChild(3);
      this.text_Title = this.Tmp.GetComponent<UIText>();
      this.text_Title.font = this.TTFont;
      this.text_Title.SetCheckArabic(true);
      this.Tmp = this.GameT.GetChild(0).GetChild(4);
      this.text_Page = this.Tmp.GetComponent<UIText>();
      this.text_Page.font = this.TTFont;
      this.Tmp = this.GameT.GetChild(0).GetChild(5);
      this.text_Time[0] = this.Tmp.GetComponent<UIText>();
      this.text_Time[0].font = this.TTFont;
      this.Cstr_Time[0].ClearString();
      this.Tmp = this.GameT.GetChild(0).GetChild(6);
      this.text_Time[1] = this.Tmp.GetComponent<UIText>();
      this.text_Time[1].font = this.TTFont;
      this.Cstr_Time[1].ClearString();
      this.Tmp = this.GameT.GetChild(0).GetChild(7);
      this.text_Name = this.Tmp.GetComponent<UIText>();
      this.text_Name.font = this.TTFont;
      this.Mask_T = this.GameT.GetChild(1);
      this.Tmp = this.Mask_T.GetChild(0);
      this.ContentRT = this.Tmp.GetComponent<RectTransform>();
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
      this.Img_Hero = this.Tmp1.gameObject.GetComponent<Image>();
      ((MaskableGraphic) this.Img_Hero).material = this.GUIM.m_IconSpriteAsset.GetMaterial();
      this.baseline = this.GameT.GetChild(0).GetChild(8);
      this.rectBaseLine = this.GameT.GetChild(0).GetChild(8).GetChild(0).gameObject.GetComponent<RectTransform>();
      this.rectBaseLineBtn = this.GameT.GetChild(0).GetChild(8).gameObject.GetComponent<RectTransform>();
      this.btn_Name = this.GameT.GetChild(0).GetChild(8).gameObject.GetComponent<UIButton>();
      this.btn_Name.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Name.m_BtnID1 = 18;
      this.btn_Name.m_BtnID2 = 1;
      UIButton component1 = this.Tmp.GetChild(0).GetComponent<UIButton>();
      component1.m_Handler = (IUIButtonClickHandler) this;
      component1.m_BtnID1 = 18;
      component1.m_BtnID2 = 2;
      component1.m_EffectType = e_EffectType.e_Scale;
      component1.transition = (Selectable.Transition) 0;
      this.tmpRC = this.Tmp1.GetComponent<RectTransform>();
      this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
      this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
      this.tmpRC.offsetMin = Vector2.zero;
      this.tmpRC.offsetMax = Vector2.zero;
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(1);
      this.Img_HeroF = this.Tmp1.gameObject.GetComponent<Image>();
      this.Img_HeroF.sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, (byte) 11);
      ((MaskableGraphic) this.Img_HeroF).material = this.GUIM.GetFrameMaterial();
      this.tmpRC = this.Tmp1.GetComponent<RectTransform>();
      this.tmpRC.anchorMin = Vector2.zero;
      this.tmpRC.anchorMax = new Vector2(1f, 1f);
      this.tmpRC.offsetMin = Vector2.zero;
      this.tmpRC.offsetMax = Vector2.zero;
      this.Tmp1 = this.Tmp.GetChild(6);
      this.tmpRC = this.Tmp1.GetComponent<RectTransform>();
      this.text_Contents = this.Tmp1.GetComponent<UIText>();
      this.text_Contents.font = this.TTFont;
      this.text_Contents.SetCheckArabic(true);
      this.tmpHeight = (float) (22.0 + (double) this.text_Contents.preferredHeight + 1.0 + 24.0);
      this.Tmp1 = this.Tmp.GetChild(1);
      this.tmpRC = this.Tmp1.GetComponent<RectTransform>();
      this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x, -this.tmpHeight);
      this.tmpHeight += 41f;
      this.BookMarkT = this.Tmp.GetChild(2);
      this.tmpRC = this.BookMarkT.GetComponent<RectTransform>();
      this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x, -this.tmpHeight);
      this.Img_BookMarkList[0] = this.BookMarkT.GetChild(0).GetComponent<Image>();
      this.Img_BookMarkList[0].sprite = this.SArray.m_Sprites[5];
      this.btn_BookMarkList[0] = this.BookMarkT.GetChild(1).GetComponent<UIButton>();
      this.btn_BookMarkList[0].m_Handler = (IUIButtonClickHandler) this;
      this.btn_BookMarkList[0].m_BtnID1 = 7;
      this.btn_BookMarkList[0].m_BtnID2 = 1;
      this.BookMark_XYRT[0] = this.BookMarkT.GetChild(0).GetChild(0).GetComponent<RectTransform>();
      this.btn_BookMarkListXY[0] = this.BookMarkT.GetChild(0).GetChild(0).GetComponent<UIButton>();
      this.btn_BookMarkListXY[0].m_Handler = (IUIButtonClickHandler) this;
      this.btn_BookMarkListXY[0].m_BtnID1 = 13;
      this.btn_BookMarkListXY[0].m_BtnID2 = 1;
      this.BookMark_TextRT[0] = this.BookMarkT.GetChild(0).GetChild(1).GetComponent<RectTransform>();
      this.text_BookMarkList[0] = this.BookMarkT.GetChild(0).GetChild(1).GetComponent<UIText>();
      this.text_BookMarkList[0].font = this.TTFont;
      this.text_BookMarkList2[0] = this.BookMarkT.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
      this.text_BookMarkList2[0].font = this.TTFont;
      this.BookMarkList[0] = this.BookMarkT;
      this.tmpHeight += 57f;
      this.Tmp1 = this.Tmp.GetChild(3);
      this.btn_Translation = this.Tmp1.GetComponent<UIButton>();
      this.btn_Translation.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Translation.m_BtnID1 = 17;
      this.TranslationRT = this.Tmp1.GetComponent<RectTransform>();
      this.Tmp1 = this.Tmp.GetChild(4);
      this.Img_Translate = this.Tmp1.GetComponent<Image>();
      this.Tmp1 = this.Tmp.GetChild(5);
      this.text_Translation = this.Tmp1.GetComponent<UIText>();
      this.text_Translation.font = this.TTFont;
      this.Letter_T = this.GameT.GetChild(2);
      this.Tmp = this.Letter_T.GetChild(0);
      this.btn_Delete = this.Tmp.GetComponent<UIButton>();
      this.btn_Delete.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Delete.m_BtnID1 = 3;
      this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
      this.btn_Delete.transition = (Selectable.Transition) 0;
      this.DeleteRT = this.Tmp.GetComponent<RectTransform>();
      this.Tmp = this.Letter_T.GetChild(1);
      this.btn_Collect = this.Tmp.GetComponent<UIButton>();
      this.btn_Collect.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Collect.m_BtnID1 = 5;
      this.btn_Collect.m_EffectType = e_EffectType.e_Scale;
      this.btn_Collect.transition = (Selectable.Transition) 0;
      this.CollectRT = this.Tmp.GetComponent<RectTransform>();
      this.Tmp = this.Letter_T.GetChild(2);
      this.btn_Reply = this.Tmp.GetComponent<UIButton>();
      this.btn_Reply.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Reply.m_BtnID1 = 6;
      this.btn_Reply.m_EffectType = e_EffectType.e_Scale;
      this.btn_Reply.transition = (Selectable.Transition) 0;
      this.ReplyRT = this.Tmp.GetComponent<RectTransform>();
      this.Letter_S_T = this.GameT.GetChild(3);
      this.Mask_T2 = this.Letter_S_T.GetChild(0);
      this.Mask_S_SR = this.Mask_T2.GetComponent<CScrollRect>();
      this.Tmp = this.Mask_T2.GetChild(0);
      this.Content_RT2 = this.Tmp.GetComponent<RectTransform>();
      this.Tmp = this.Mask_T2.GetChild(0).GetChild(0);
      this.Img_Hero_S = this.Tmp.GetChild(0).GetComponent<Image>();
      ((MaskableGraphic) this.Img_Hero_S).material = this.GUIM.m_IconSpriteAsset.GetMaterial();
      this.tmpRC = this.Tmp.GetChild(0).GetComponent<RectTransform>();
      this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
      this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
      this.tmpRC.offsetMin = Vector2.zero;
      this.tmpRC.offsetMax = Vector2.zero;
      this.Img_HeroF_S = this.Tmp.GetChild(1).GetComponent<Image>();
      this.Img_HeroF_S.sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, (byte) 11);
      ((MaskableGraphic) this.Img_HeroF_S).material = this.GUIM.GetFrameMaterial();
      this.tmpRC = this.Tmp.GetChild(1).GetComponent<RectTransform>();
      this.tmpRC.anchorMin = Vector2.zero;
      this.tmpRC.anchorMax = new Vector2(1f, 1f);
      this.tmpRC.offsetMin = Vector2.zero;
      this.tmpRC.offsetMax = Vector2.zero;
      this.text_Contents_S = this.Tmp.GetChild(2).GetComponent<UIText>();
      this.text_Contents_S.font = this.TTFont;
      this.text_Contents_S.SetCheckArabic(true);
      this.Tmp = this.Letter_S_T.GetChild(1);
      this.Img_HeroSkill[0] = this.Tmp.GetComponent<Image>();
      this.Img_HeroSkill_1[0] = this.Tmp.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();
      ((MaskableGraphic) this.Img_HeroSkill_1[0]).material = this.GUIM.GetSkillMaterial();
      UIButton component2 = this.Tmp.GetChild(1).GetComponent<UIButton>();
      component2.m_Handler = (IUIButtonClickHandler) this;
      component2.m_BtnID1 = 11;
      UIButtonHint uiButtonHint1 = this.Tmp.GetChild(1).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint1.ControlFadeOut = ((Component) this.GUIM.m_SkillInfo.m_RectTransform).gameObject;
      uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint1.m_Handler = (MonoBehaviour) this;
      this.tmpRC = this.Tmp.GetChild(1).GetChild(0).GetChild(0).GetComponent<RectTransform>();
      this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
      this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
      this.tmpRC.offsetMin = Vector2.zero;
      this.tmpRC.offsetMax = Vector2.zero;
      this.Img_HeroSkill_1[1] = this.Tmp.GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>();
      this.Img_HeroSkill_1[1].sprite = this.GUIM.LoadFrameSprite("sk");
      ((MaskableGraphic) this.Img_HeroSkill_1[1]).material = this.GUIM.GetFrameMaterial();
      this.tmpRC = this.Tmp.GetChild(1).GetChild(0).GetChild(1).GetComponent<RectTransform>();
      this.tmpRC.anchorMin = Vector2.zero;
      this.tmpRC.anchorMax = new Vector2(1f, 1f);
      this.tmpRC.offsetMin = Vector2.zero;
      this.tmpRC.offsetMax = Vector2.zero;
      this.text_tmpStr[0] = this.Tmp.GetChild(2).GetComponent<UIText>();
      this.text_tmpStr[0].font = this.TTFont;
      this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(369U);
      this.text_Skill_1[0] = this.Tmp.GetChild(3).GetComponent<UIText>();
      this.text_Skill_1[0].font = this.TTFont;
      this.text_Skill_1[1] = this.Tmp.GetChild(4).GetComponent<UIText>();
      this.text_Skill_1[1].font = this.TTFont;
      this.Tmp = this.Letter_S_T.GetChild(2);
      this.Img_HeroSkill[1] = this.Tmp.GetComponent<Image>();
      this.Img_HeroSkill_2[0] = this.Tmp.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();
      ((MaskableGraphic) this.Img_HeroSkill_2[0]).material = this.GUIM.GetSkillMaterial();
      UIButton component3 = this.Tmp.GetChild(1).GetComponent<UIButton>();
      component3.m_Handler = (IUIButtonClickHandler) this;
      component3.m_BtnID1 = 12;
      UIButtonHint uiButtonHint2 = this.Tmp.GetChild(1).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint2.ControlFadeOut = ((Component) this.GUIM.m_SkillInfo.m_RectTransform).gameObject;
      uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint2.m_Handler = (MonoBehaviour) this;
      this.tmpRC = this.Tmp.GetChild(1).GetChild(0).GetChild(0).GetComponent<RectTransform>();
      this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
      this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
      this.tmpRC.offsetMin = Vector2.zero;
      this.tmpRC.offsetMax = Vector2.zero;
      this.Img_HeroSkill_2[1] = this.Tmp.GetChild(1).GetChild(0).GetChild(1).GetComponent<Image>();
      this.Img_HeroSkill_2[1].sprite = this.GUIM.LoadFrameSprite("sk");
      ((MaskableGraphic) this.Img_HeroSkill_2[1]).material = this.GUIM.GetFrameMaterial();
      this.tmpRC = this.Tmp.GetChild(1).GetChild(0).GetChild(1).GetComponent<RectTransform>();
      this.tmpRC.anchorMin = Vector2.zero;
      this.tmpRC.anchorMax = new Vector2(1f, 1f);
      this.tmpRC.offsetMin = Vector2.zero;
      this.tmpRC.offsetMax = Vector2.zero;
      this.text_tmpStr[1] = this.Tmp.GetChild(2).GetComponent<UIText>();
      this.text_tmpStr[1].font = this.TTFont;
      this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(33U);
      this.text_Skill_2[0] = this.Tmp.GetChild(3).GetComponent<UIText>();
      this.text_Skill_2[0].font = this.TTFont;
      this.text_Skill_2[1] = this.Tmp.GetChild(4).GetComponent<UIText>();
      this.text_Skill_2[1].font = this.TTFont;
      this.btn_AllianceInvite_S = this.Letter_S_T.GetChild(3).GetComponent<UIButton>();
      this.btn_AllianceInvite_S.m_Handler = (IUIButtonClickHandler) this;
      this.btn_AllianceInvite_S.m_BtnID1 = 10;
      this.btn_AllianceInvite_S.m_EffectType = e_EffectType.e_Scale;
      this.btn_AllianceInvite_S.transition = (Selectable.Transition) 0;
      this.text_tmpStr[2] = this.Letter_S_T.GetChild(3).GetChild(1).GetComponent<UIText>();
      this.text_tmpStr[2].font = this.TTFont;
      this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(6087U);
      this.btn_Delete_S = this.Letter_S_T.GetChild(4).GetComponent<UIButton>();
      this.btn_Delete_S.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Delete_S.m_BtnID1 = 8;
      this.btn_Delete_S.m_EffectType = e_EffectType.e_Scale;
      this.btn_Delete_S.transition = (Selectable.Transition) 0;
      this.btn_Collect_S = this.Letter_S_T.GetChild(5).GetComponent<UIButton>();
      this.btn_Collect_S.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Collect_S.m_BtnID1 = 9;
      this.btn_Collect_S.m_EffectType = e_EffectType.e_Scale;
      this.btn_Collect_S.transition = (Selectable.Transition) 0;
      if (this.mLetterKind == 1 && (this.SC.Type == NoticeReport.Enotice_ActivityDegreePrize || this.SC.Type == NoticeReport.Enotice_ActivityRankPrize || this.SC.Type == NoticeReport.Enotice_ActivityKVKDegreePrize || this.SC.Type == NoticeReport.Enotice_ActivityKVKRankPrize || this.SC.Type == NoticeReport.Enotice_AMRankPrize || this.SC.Type == NoticeReport.Enotice_WorldKingPrize || this.SC.Type == NoticeReport.Enotice_WorldNotKingPrize || this.SC.Type == NoticeReport.Enotice_FederalRankPrize))
      {
        this.Tmp = this.Letter_S_T.GetChild(6);
        this.Img_S_Activity_BG = this.Tmp.GetComponent<Image>();
        this.m_ScrollPanel = this.Tmp.GetChild(1).GetComponent<ScrollPanel>();
        this.m_ScrollPanel.m_ScrollPanelID = 1;
        this.Tmp1 = this.Tmp.GetChild(2);
        this.Img_S_Title = this.Tmp1.GetChild(0).GetChild(0).GetComponent<Image>();
        this.Img_S_Crystal = this.Tmp1.GetChild(0).GetChild(1).GetComponent<Image>();
        this.Tmp = this.Tmp1.GetChild(0).GetChild(0).GetChild(0);
        this.text_S_Title = this.Tmp.GetComponent<UIText>();
        this.text_S_Title.font = this.TTFont;
        for (int index = 0; index < 3; ++index)
        {
          this.Tmp = this.Tmp1.GetChild(0).GetChild(2 + index);
          this.text_S_Top[index] = this.Tmp.GetComponent<UIText>();
          this.text_S_Top[index].font = this.TTFont;
        }
        this.Tmp = this.Tmp1.GetChild(1);
        for (int index = 0; index < 5; ++index)
        {
          this.GUIM.InitianHeroItemImg(((Component) this.Tmp.GetChild(index).GetComponent<UIHIBtn>()).transform, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0);
          UILEBtn component4 = this.Tmp.GetChild(index + 5).GetComponent<UILEBtn>();
          this.GUIM.InitLordEquipImg(((Component) component4).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
          ((Component) component4).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
          this.tmptext = this.Tmp.GetChild(index + 10).GetComponent<UIText>();
          this.tmptext.font = this.TTFont;
        }
        UIButton component5 = this.Tmp1.GetChild(2).GetChild(0).GetComponent<UIButton>();
        component5.m_Handler = (IUIButtonClickHandler) this;
        component5.m_BtnID1 = 15;
        this.text_tmpStr[3] = this.Tmp1.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
        this.text_tmpStr[3].font = this.TTFont;
        this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(8244U);
      }
      if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.Enotice_SynLordEquip)
      {
        this.Tmp = this.Letter_S_T.GetChild(7);
        this.Img_LordEquip_BG = this.Tmp.GetComponent<Image>();
        this.Tmp = this.Letter_S_T.GetChild(7).GetChild(0);
        for (int index = 0; index < 2; ++index)
        {
          this.text_LordEquip[index] = this.Tmp.GetChild(index).GetComponent<UIText>();
          this.text_LordEquip[index].font = this.TTFont;
        }
        this.Tmp = this.Letter_S_T.GetChild(7).GetChild(1);
        this.mLebtn = this.Tmp.GetComponent<UILEBtn>();
        this.mLebtn.m_Handler = (IUILEBtnClickHandler) this;
        this.Tmp = this.Letter_S_T.GetChild(7).GetChild(3);
        this.text_LordEquip_Lv = this.Tmp.GetComponent<UIText>();
        this.text_LordEquip_Lv.font = this.TTFont;
        for (int index = 0; index < 6; ++index)
        {
          this.Tmp = this.Letter_S_T.GetChild(7).GetChild(4 + index);
          this.text_LordEquip_Effect[index][0] = this.Tmp.GetComponent<UIText>();
          this.text_LordEquip_Effect[index][0].font = this.TTFont;
          this.Tmp = this.Letter_S_T.GetChild(7).GetChild(10 + index);
          this.text_LordEquip_Effect[index][1] = this.Tmp.GetComponent<UIText>();
          this.text_LordEquip_Effect[index][1].font = this.TTFont;
        }
      }
      if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.Enotice_CryptFinish)
      {
        this.Tmp = this.Letter_S_T.GetChild(8);
        this.Img_CryptFinish_BG = this.Tmp.GetComponent<Image>();
        this.Tmp1 = this.Tmp.GetChild(1).GetChild(0);
        this.text_CryptFinish = this.Tmp1.GetComponent<UIText>();
        this.text_CryptFinish.font = this.TTFont;
        ((Graphic) this.text_CryptFinish).rectTransform.sizeDelta = new Vector2(200f, ((Graphic) this.text_CryptFinish).rectTransform.sizeDelta.y);
        this.text_CryptFinish.resizeTextForBestFit = true;
        this.Tmp1 = this.Tmp.GetChild(2);
        this.text_tmpStr[4] = this.Tmp1.GetComponent<UIText>();
        this.text_tmpStr[4].font = this.TTFont;
        this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(8228U);
      }
      if (this.mLetterKind == 1 && (this.SC.Type == NoticeReport.Enotice_BuyTreasure || this.SC.Type == NoticeReport.Enotice_BuyBlackMarketTreasure || this.SC.Type == NoticeReport.Enotice_BackendActivity || this.SC.Type == NoticeReport.Enotice_TreasureBackPrize || this.SC.Type == NoticeReport.Enotice_MaintainCompensation || this.SC.Type == NoticeReport.Enotice_ReturnCeremony))
      {
        this.Tmp = this.Letter_S_T.GetChild(9);
        this.Img_BuyTreasure_BG = this.Tmp.GetComponent<Image>();
        this.m_ScrollPanel_Buy = this.Tmp.GetChild(0).GetComponent<ScrollPanel>();
        this.m_ScrollPanel_Buy.m_ScrollPanelID = 2;
        this.GUIM.InitianHeroItemImg(this.Tmp.GetChild(1).GetChild(2), eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
        this.GUIM.InitLordEquipImg(this.Tmp.GetChild(1).GetChild(3), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        this.Tmp.GetChild(1).GetChild(3).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
        this.Tmp1 = this.Tmp.GetChild(1).GetChild(4);
        this.tmptext = this.Tmp1.GetComponent<UIText>();
        this.tmptext.font = this.TTFont;
        this.Tmp1 = this.Tmp.GetChild(1).GetChild(5);
        this.tmptext = this.Tmp1.GetComponent<UIText>();
        this.tmptext.font = this.TTFont;
      }
      if (this.mLetterKind == 2)
      {
        this.MonsterXY_T = this.Letter_S_T.GetChild(10);
        this.btn_MonsterXY = this.MonsterXY_T.GetChild(0).GetComponent<UIButton>();
        this.btn_MonsterXY.m_Handler = (IUIButtonClickHandler) this;
        this.btn_MonsterXY.m_BtnID1 = 14;
        this.Tmp = this.MonsterXY_T.GetChild(0).GetChild(1);
        this.text_MonsterXY = this.Tmp.GetComponent<UIText>();
        this.text_MonsterXY.font = this.TTFont;
      }
      if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.ENotice_StarUp)
      {
        this.HeroStarUp_T = this.Letter_S_T.GetChild(11);
        this.text_tmpStr[5] = this.HeroStarUp_T.GetChild(0).GetChild(0).GetComponent<UIText>();
        this.text_tmpStr[5].font = this.TTFont;
        this.text_tmpStr[5].text = this.DM.mStringTable.GetStringByID(369U);
        for (int index = 0; index < 4; ++index)
        {
          UIButton component6 = this.HeroStarUp_T.GetChild(1 + index).GetComponent<UIButton>();
          component6.m_Handler = (IUIButtonClickHandler) this;
          component6.m_BtnID1 = 16;
          component6.m_BtnID2 = index;
          UIButtonHint uiButtonHint3 = this.HeroStarUp_T.GetChild(1 + index).gameObject.AddComponent<UIButtonHint>();
          uiButtonHint3.ControlFadeOut = ((Component) this.GUIM.m_SkillInfo.m_RectTransform).gameObject;
          uiButtonHint3.m_eHint = EUIButtonHint.DownUpHandler;
          uiButtonHint3.m_Handler = (MonoBehaviour) this;
          this.tmpRC = this.HeroStarUp_T.GetChild(1 + index).GetChild(0).GetChild(0).GetComponent<RectTransform>();
          this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
          this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
          this.tmpRC.offsetMin = Vector2.zero;
          this.tmpRC.offsetMax = Vector2.zero;
          this.Img_StarUpSkill[index] = this.HeroStarUp_T.GetChild(1 + index).GetChild(0).GetChild(0).GetComponent<Image>();
          ((MaskableGraphic) this.Img_StarUpSkill[index]).material = this.GUIM.GetSkillMaterial();
          this.tmpImg = this.HeroStarUp_T.GetChild(1 + index).GetChild(0).GetChild(1).GetComponent<Image>();
          this.tmpImg.sprite = this.GUIM.LoadFrameSprite("sk");
          ((MaskableGraphic) this.tmpImg).material = this.GUIM.GetFrameMaterial();
          this.tmpRC = this.HeroStarUp_T.GetChild(1 + index).GetChild(0).GetChild(1).GetComponent<RectTransform>();
          this.tmpRC.anchorMin = Vector2.zero;
          this.tmpRC.anchorMax = new Vector2(1f, 1f);
          this.tmpRC.offsetMin = Vector2.zero;
          this.tmpRC.offsetMax = Vector2.zero;
          this.Img_StarUpSkill_2[index] = this.HeroStarUp_T.GetChild(5 + index).GetComponent<Image>();
          this.Img_StarUpSkill_2[index].sprite = this.GUIM.LoadFrameSprite("UI_box_hero_dark_01");
          ((MaskableGraphic) this.Img_StarUpSkill_2[index]).material = this.GUIM.GetFrameMaterial();
          this.text_StarUp_1[index] = this.HeroStarUp_T.GetChild(5 + index).GetChild(0).GetComponent<UIText>();
          this.text_StarUp_1[index].font = this.TTFont;
          this.text_StarUp_2[index] = this.HeroStarUp_T.GetChild(5 + index).GetChild(1).GetComponent<UIText>();
          this.text_StarUp_2[index].font = this.TTFont;
          this.text_StarUp_2[index].text = this.DM.mStringTable.GetStringByID(115U);
          this.Img_StarUpSkill_L[index] = this.HeroStarUp_T.GetChild(9 + index).GetComponent<Image>();
        }
      }
      if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.Enotice_RecivedGift)
      {
        this.Gifts_T = this.Letter_S_T.GetChild(12);
        this.GiftsHbtn_Item = this.Gifts_T.GetChild(0).GetComponent<UIHIBtn>();
        this.GUIM.InitianHeroItemImg(((Component) this.GiftsHbtn_Item).transform, eHeroOrItem.Item, this.SC.Enotice_RecivedGift.Item.ItemID, (byte) 0, (byte) 0);
        this.text_Gifts[0] = this.Gifts_T.GetChild(1).GetComponent<UIText>();
        this.text_Gifts[0].font = this.TTFont;
        this.Cstr_Gifts[0].ClearString();
        this.Cstr_Gifts[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint) DataManager.Instance.EquipTable.GetRecordByKey(this.SC.Enotice_RecivedGift.Item.ItemID).EquipName));
        this.Cstr_Gifts[0].AppendFormat("{0}");
        this.text_Gifts[0].text = this.Cstr_Gifts[0].ToString();
        this.text_Gifts[1] = this.Gifts_T.GetChild(2).GetComponent<UIText>();
        this.text_Gifts[1].font = this.TTFont;
        StringManager.IntToStr(this.Cstr_Gifts[1], (long) this.SC.Enotice_RecivedGift.Item.ItemNum, bNumber: true);
        this.text_Gifts[1].text = this.Cstr_Gifts[1].ToString();
      }
      if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.Enotice_RulerGift)
      {
        this.Gifts_T = this.Letter_S_T.GetChild(12);
        this.GiftsHbtn_Item = this.Gifts_T.GetChild(0).GetComponent<UIHIBtn>();
        this.GUIM.InitianHeroItemImg(((Component) this.GiftsHbtn_Item).transform, eHeroOrItem.Item, this.SC.Enotice_RulerGift.Gifts[0].ItemID, (byte) 0, (byte) 0);
        this.text_Gifts[0] = this.Gifts_T.GetChild(1).GetComponent<UIText>();
        this.text_Gifts[0].font = this.TTFont;
        this.Cstr_Gifts[0].ClearString();
        this.Cstr_Gifts[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint) DataManager.Instance.EquipTable.GetRecordByKey(this.SC.Enotice_RulerGift.Gifts[0].ItemID).EquipName));
        this.Cstr_Gifts[0].AppendFormat("{0}");
        this.text_Gifts[0].text = this.Cstr_Gifts[0].ToString();
        this.text_Gifts[1] = this.Gifts_T.GetChild(2).GetComponent<UIText>();
        this.text_Gifts[1].font = this.TTFont;
        StringManager.IntToStr(this.Cstr_Gifts[1], (long) this.SC.Enotice_RulerGift.Gifts[0].ItemNum, bNumber: true);
        this.text_Gifts[1].text = this.Cstr_Gifts[1].ToString();
      }
      if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.Enotice_BuyEmoteTreasure)
      {
        this.Gifts_T = this.Letter_S_T.GetChild(12);
        this.GiftsHbtn_Item = this.Gifts_T.GetChild(0).GetComponent<UIHIBtn>();
        this.GUIM.InitianHeroItemImg(((Component) this.GiftsHbtn_Item).transform, eHeroOrItem.Item, this.SC.Enotice_BuyEmoteTreasure.ItemID, (byte) 0, (byte) 0);
        this.text_Gifts[0] = this.Gifts_T.GetChild(1).GetComponent<UIText>();
        this.text_Gifts[0].font = this.TTFont;
        this.Cstr_Gifts[0].ClearString();
        this.Cstr_Gifts[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint) DataManager.Instance.EquipTable.GetRecordByKey(this.SC.Enotice_BuyEmoteTreasure.ItemID).EquipName));
        this.Cstr_Gifts[0].AppendFormat("{0}");
        this.text_Gifts[0].text = this.Cstr_Gifts[0].ToString();
        this.text_Gifts[1] = this.Gifts_T.GetChild(2).GetComponent<UIText>();
        this.text_Gifts[1].font = this.TTFont;
        StringManager.IntToStr(this.Cstr_Gifts[1], (long) this.SC.Enotice_BuyEmoteTreasure.ItemNum, bNumber: true);
        this.text_Gifts[1].text = this.Cstr_Gifts[1].ToString();
      }
      if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.Enotice_BuyCastleSkinTreasure)
      {
        this.Gifts_T = this.Letter_S_T.GetChild(12);
        if (this.SC.Enotice_BuyCastleSkinTreasure.ItemID > (ushort) 0)
        {
          this.GiftsHbtn_Item = this.Gifts_T.GetChild(0).GetComponent<UIHIBtn>();
          this.GUIM.InitianHeroItemImg(((Component) this.GiftsHbtn_Item).transform, eHeroOrItem.Item, this.SC.Enotice_BuyCastleSkinTreasure.ItemID, (byte) 0, (byte) 0);
          this.text_Gifts[0] = this.Gifts_T.GetChild(1).GetComponent<UIText>();
          this.text_Gifts[0].font = this.TTFont;
          this.Cstr_Gifts[0].ClearString();
          this.Cstr_Gifts[0].StringToFormat(this.DM.mStringTable.GetStringByID((uint) DataManager.Instance.EquipTable.GetRecordByKey(this.SC.Enotice_BuyCastleSkinTreasure.ItemID).EquipName));
          this.Cstr_Gifts[0].AppendFormat("{0}");
          this.text_Gifts[0].text = this.Cstr_Gifts[0].ToString();
          this.text_Gifts[1] = this.Gifts_T.GetChild(2).GetComponent<UIText>();
          this.text_Gifts[1].font = this.TTFont;
          StringManager.IntToStr(this.Cstr_Gifts[1], (long) this.SC.Enotice_BuyCastleSkinTreasure.ItemNum, bNumber: true);
          this.text_Gifts[1].text = this.Cstr_Gifts[1].ToString();
          this.Gifts_T.gameObject.SetActive(true);
        }
      }
      if (this.mLetterKind == 1 && this.SC.Type == NoticeReport.Enotice_AutoDismiss)
      {
        this.btn_JoinAlliance = this.Letter_S_T.GetChild(13).GetComponent<UIButton>();
        this.btn_JoinAlliance.m_Handler = (IUIButtonClickHandler) this;
        this.btn_JoinAlliance.m_BtnID1 = 19;
        this.btn_JoinAlliance.m_EffectType = e_EffectType.e_Scale;
        this.btn_JoinAlliance.transition = (Selectable.Transition) 0;
        ((Component) this.btn_JoinAlliance).gameObject.SetActive(true);
        this.text_tmpStr[6] = this.Letter_S_T.GetChild(13).GetChild(1).GetComponent<UIText>();
        this.text_tmpStr[6].font = this.TTFont;
        this.text_tmpStr[6].text = this.DM.mStringTable.GetStringByID(4610U);
      }
      this.PreviousT = this.GameT.GetChild(4);
      this.btn_Previous = this.PreviousT.GetComponent<UIButton>();
      this.btn_Previous.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Previous.m_BtnID1 = 1;
      this.btn_Previous.m_EffectType = e_EffectType.e_Scale;
      this.btn_Previous.transition = (Selectable.Transition) 0;
      this.NextT = this.GameT.GetChild(5);
      this.btn_Next = this.NextT.GetComponent<UIButton>();
      this.btn_Next.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Next.m_BtnID1 = 2;
      this.btn_Next.m_EffectType = e_EffectType.e_Scale;
      this.btn_Next.transition = (Selectable.Transition) 0;
      float x = ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x;
      this.tempL = (float) (((double) ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x - 853.0) / 2.0);
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
      this.SetLetterData();
      if (this.mLetterKind == 1)
      {
        if (this.SC.Type == NoticeReport.Enotice_ActivityDegreePrize || this.SC.Type == NoticeReport.Enotice_ActivityRankPrize || this.SC.Type == NoticeReport.Enotice_ActivityKVKDegreePrize || this.SC.Type == NoticeReport.Enotice_ActivityKVKRankPrize || this.SC.Type == NoticeReport.Enotice_AMRankPrize || this.SC.Type == NoticeReport.Enotice_WorldKingPrize || this.SC.Type == NoticeReport.Enotice_WorldNotKingPrize || this.SC.Type == NoticeReport.Enotice_FederalRankPrize)
        {
          ((Component) this.Img_S_Activity_BG).gameObject.SetActive(true);
          int index4 = 0;
          switch (this.mPrizeType)
          {
            case Detail_Prize.Enotice_ActivityDegreePrize:
              index4 = 20 - (int) this.SC.Notice_ActivityDegreePrize.Degree;
              this.text_S_Title.text = this.DM.mStringTable.GetStringByID((uint) (ushort) (7689U + (uint) this.SC.Notice_ActivityDegreePrize.Degree));
              break;
            case Detail_Prize.Enotice_ActivityRankPrize:
              switch (this.SC.Notice_ActivityRankPrize.Place)
              {
                case 1:
                case 2:
                case 3:
                  index4 = 16 + (int) this.SC.Notice_ActivityRankPrize.Place;
                  break;
                default:
                  index4 = 20;
                  break;
              }
              this.Cstr_S_Title.IntToFormat((long) this.SC.Notice_ActivityRankPrize.Place, bNumber: true);
              this.Cstr_S_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7694U));
              this.text_S_Title.text = this.Cstr_S_Title.ToString();
              break;
            case Detail_Prize.Enotice_ActivityKVKDegreePrize:
              index4 = 20 - (int) this.SC.Enotice_ActivityKVKDegreePrize.Degree;
              this.text_S_Title.text = this.DM.mStringTable.GetStringByID((uint) (ushort) (7689U + (uint) this.SC.Enotice_ActivityKVKDegreePrize.Degree));
              break;
            case Detail_Prize.Enotice_ActivityKVKRankPrize:
              switch (this.SC.Enotice_ActivityKVKRankPrize.Place)
              {
                case 1:
                case 2:
                case 3:
                  index4 = 16 + (int) this.SC.Enotice_ActivityKVKRankPrize.Place;
                  break;
                default:
                  index4 = 20;
                  break;
              }
              this.Cstr_S_Title.IntToFormat((long) this.SC.Enotice_ActivityKVKRankPrize.Place, bNumber: true);
              this.Cstr_S_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7694U));
              this.text_S_Title.text = this.Cstr_S_Title.ToString();
              break;
            case Detail_Prize.Enotice_AMRankPrize:
              switch (this.SC.Enotice_AMRankPrize.Place)
              {
                case 1:
                case 2:
                case 3:
                  index4 = 16 + (int) this.SC.Enotice_AMRankPrize.Place;
                  break;
                default:
                  index4 = 20;
                  break;
              }
              this.Cstr_S_Title.IntToFormat((long) this.SC.Enotice_AMRankPrize.Place, bNumber: true);
              this.Cstr_S_Title.AppendFormat(this.DM.mStringTable.GetStringByID(7694U));
              this.text_S_Title.text = this.Cstr_S_Title.ToString();
              break;
            case Detail_Prize.Enotice_WorldKingPrize:
            case Detail_Prize.Enotice_WorldNotKingPrize:
              index4 = 17;
              this.Cstr_S_Title.Append(this.DM.mStringTable.GetStringByID(11023U));
              this.text_S_Title.text = this.Cstr_S_Title.ToString();
              break;
            case Detail_Prize.Enotice_FederalRankPrize:
              index4 = 17;
              this.Cstr_S_Title.Append(this.DM.mStringTable.GetStringByID(11091U));
              this.text_S_Title.text = this.Cstr_S_Title.ToString();
              break;
          }
          this.Img_S_Title.sprite = this.SArray.m_Sprites[index4];
          for (int index5 = 0; index5 < 3; ++index5)
            this.Cstr_S_Top[index5].ClearString();
          this.Cstr_S_Top[0].IntToFormat((long) this.mDiamond, bNumber: true);
          if (this.GUIM.IsArabic)
            this.Cstr_S_Top[0].AppendFormat("{0}x");
          else
            this.Cstr_S_Top[0].AppendFormat("x{0}");
          this.Cstr_S_Top[1].IntToFormat((long) this.mValue, bNumber: true);
          this.Cstr_S_Top[1].AppendFormat(this.DM.mStringTable.GetStringByID(8122U));
          this.Cstr_S_Top[2].IntToFormat((long) this.mNoValueCount, bNumber: true);
          this.Cstr_S_Top[2].AppendFormat(this.DM.mStringTable.GetStringByID(8123U));
          this.text_S_Title.SetAllDirty();
          this.text_S_Title.cachedTextGenerator.Invalidate();
          for (int index6 = 0; index6 < 3; ++index6)
          {
            this.text_S_Top[index6].text = this.Cstr_S_Top[index6].ToString();
            this.text_S_Top[index6].SetAllDirty();
            this.text_S_Top[index6].cachedTextGenerator.Invalidate();
          }
          if (this.mDiamond == 0U)
          {
            ((Component) this.Img_S_Crystal).gameObject.SetActive(false);
            ((Component) this.text_S_Top[0]).gameObject.SetActive(false);
          }
          else
          {
            ((Component) this.Img_S_Crystal).gameObject.SetActive(true);
            ((Component) this.text_S_Top[0]).gameObject.SetActive(true);
          }
          if (this.mNoValueCount == (byte) 0)
            ((Component) this.text_S_Top[2]).gameObject.SetActive(false);
          else
            ((Component) this.text_S_Top[2]).gameObject.SetActive(true);
          this.tmplist.Clear();
          this.tmplist.Add(131f);
          for (int index7 = 0; index7 < (this.tmplistItem.Count - 1) / 5 + 1; ++index7)
            this.tmplist.Add(62f);
          this.tmplist.Add(62f);
          this.m_ScrollPanel.IntiScrollPanel(490f, 0.0f, 0.0f, this.tmplist, 6, (IUpDateScrollPanel) this);
          UIButtonHint.scrollRect = this.m_ScrollPanel.transform.GetComponent<CScrollRect>();
        }
        if (this.SC.Type == NoticeReport.Enotice_BuyTreasure)
        {
          ((Component) this.Img_BuyTreasure_BG).gameObject.SetActive(true);
          this.ItemCount = (byte) 0;
          this.GiftTopCount = (byte) 0;
          this.tmplist.Clear();
          ++this.ItemCount;
          this.tmplist.Add(60f);
          if (this.SC.Notice_BuyTreasure.BonusCrystal > 0U)
          {
            ++this.ItemCount;
            this.tmplist.Add(60f);
          }
          for (int index = 0; index < (int) this.SC.Notice_BuyTreasure.ItemNum; ++index)
          {
            this.tmplist.Add(60f);
            ++this.ItemCount;
          }
          for (int index = 0; index < this.SC.Notice_BuyTreasure.Gift.Length; ++index)
          {
            if (this.SC.Notice_BuyTreasure.Gift[index].ItemID != (ushort) 0)
            {
              this.tmplist.Add(60f);
              ++this.ItemCount;
              ++this.GiftTopCount;
            }
          }
          this.m_ScrollPanel_Buy.IntiScrollPanel(315f, 1f, 0.0f, this.tmplist, 7, (IUpDateScrollPanel) this);
        }
        if (this.SC.Type == NoticeReport.Enotice_BuyBlackMarketTreasure)
        {
          ((Component) this.Img_BuyTreasure_BG).gameObject.SetActive(true);
          this.ItemCount = (byte) 0;
          this.tmplist.Clear();
          if (this.SC.Enotice_BuyBlackMarketTreasure.Crystal > 0U)
          {
            ++this.ItemCount;
            this.tmplist.Add(60f);
          }
          if (this.SC.Enotice_BuyBlackMarketTreasure.BonusCrystal > 0U)
          {
            ++this.ItemCount;
            this.tmplist.Add(60f);
          }
          for (int index = 0; index < (int) this.SC.Enotice_BuyBlackMarketTreasure.ItemNum; ++index)
          {
            this.tmplist.Add(60f);
            ++this.ItemCount;
          }
          for (int index = 0; index < this.SC.Enotice_BuyBlackMarketTreasure.Gift.Length; ++index)
          {
            if (this.SC.Enotice_BuyBlackMarketTreasure.Gift[index].ItemID != (ushort) 0)
            {
              this.tmplist.Add(60f);
              ++this.ItemCount;
            }
          }
          this.m_ScrollPanel_Buy.IntiScrollPanel(315f, 1f, 0.0f, this.tmplist, 7, (IUpDateScrollPanel) this);
        }
        if (this.SC.Type == NoticeReport.Enotice_BackendActivity)
        {
          ((Component) this.Img_BuyTreasure_BG).gameObject.SetActive(true);
          this.ItemCount = (byte) 0;
          this.tmplist.Clear();
          if (this.SC.Enotice_BackendActivity.Crystal > 0U)
          {
            ++this.ItemCount;
            this.tmplist.Add(60f);
          }
          for (int index = 0; index < (int) this.SC.Enotice_BackendActivity.ItemNum; ++index)
          {
            this.tmplist.Add(60f);
            ++this.ItemCount;
          }
          this.m_ScrollPanel_Buy.IntiScrollPanel(315f, 1f, 0.0f, this.tmplist, 7, (IUpDateScrollPanel) this);
        }
        if (this.SC.Type == NoticeReport.Enotice_TreasureBackPrize)
        {
          ((Component) this.Img_BuyTreasure_BG).gameObject.SetActive(true);
          this.ItemCount = (byte) 0;
          this.tmplist.Clear();
          if (this.SC.Enotice_TreasureBackPrize.Crystal > 0U)
          {
            ++this.ItemCount;
            this.tmplist.Add(60f);
          }
          if (this.SC.Enotice_TreasureBackPrize.BonusCrystal > 0U)
          {
            ++this.ItemCount;
            this.tmplist.Add(60f);
          }
          for (int index = 0; index < (int) this.SC.Enotice_TreasureBackPrize.ItemNum; ++index)
          {
            this.tmplist.Add(60f);
            ++this.ItemCount;
          }
          for (int index = 0; index < this.SC.Enotice_TreasureBackPrize.Gift.Length; ++index)
          {
            if (this.SC.Enotice_TreasureBackPrize.Gift[index].ItemID != (ushort) 0)
            {
              this.tmplist.Add(60f);
              ++this.ItemCount;
            }
          }
          this.m_ScrollPanel_Buy.IntiScrollPanel(315f, 1f, 0.0f, this.tmplist, 7, (IUpDateScrollPanel) this);
        }
        if (this.SC.Type == NoticeReport.Enotice_MaintainCompensation)
        {
          ((Component) this.Img_BuyTreasure_BG).gameObject.SetActive(true);
          this.ItemCount = (byte) 0;
          this.tmplist.Clear();
          if (this.SC.Enotice_MaintainCompensation.Crystal > 0U)
          {
            ++this.ItemCount;
            this.tmplist.Add(60f);
          }
          for (int index = 0; index < (int) this.SC.Enotice_MaintainCompensation.ItemNum; ++index)
          {
            this.tmplist.Add(60f);
            ++this.ItemCount;
          }
          this.m_ScrollPanel_Buy.IntiScrollPanel(315f, 1f, 0.0f, this.tmplist, 7, (IUpDateScrollPanel) this);
        }
        if (this.SC.Type == NoticeReport.Enotice_ReturnCeremony)
        {
          ((Component) this.Img_BuyTreasure_BG).gameObject.SetActive(true);
          this.ItemCount = (byte) 0;
          this.tmplist.Clear();
          if (this.SC.Enotice_ReturnCeremony.Crystal > 0U)
          {
            ++this.ItemCount;
            this.tmplist.Add(60f);
          }
          for (int index = 0; index < (int) this.SC.Enotice_ReturnCeremony.ItemNum; ++index)
          {
            this.tmplist.Add(60f);
            ++this.ItemCount;
          }
          this.m_ScrollPanel_Buy.IntiScrollPanel(315f, 1f, 0.0f, this.tmplist, 7, (IUpDateScrollPanel) this);
        }
      }
      this.Cstr_Page.ClearString();
      this.Cstr_Page.IntToFormat((long) this.tmpPageNum);
      this.Cstr_Page.IntToFormat((long) this.MaxLetterNum);
      if (this.GUIM.IsArabic)
        this.Cstr_Page.AppendFormat("{1}/{0}");
      else
        this.Cstr_Page.AppendFormat("{0}/{1}");
      this.text_Page.text = this.Cstr_Page.ToString();
      this.text_Page.SetAllDirty();
      this.text_Page.cachedTextGenerator.Invalidate();
      this.text_Name.SetAllDirty();
      this.text_Name.cachedTextGenerator.Invalidate();
      this.tmpImg = this.GameT.GetChild(6).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
      ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
      if (this.GUIM.bOpenOnIPhoneX)
        ((Behaviour) this.tmpImg).enabled = false;
      this.btn_EXIT = this.GameT.GetChild(6).GetChild(0).GetComponent<UIButton>();
      this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
      this.btn_EXIT.m_BtnID1 = 0;
      this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
      ((MaskableGraphic) this.btn_EXIT.image).material = this.m_Mat;
      this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
      this.btn_EXIT.transition = (Selectable.Transition) 0;
      this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    }
    else
      this.door.CloseMenu();
  }

  public void SetLetterData()
  {
    if (this.mLetterKind == 0)
    {
      if (this.MC.MailType == (byte) 1)
      {
        this.Cstr_Title.ClearString();
        this.Cstr_Title.StringToFormat(this.DM.mStringTable.GetStringByID(6014U));
        if (this.bTrans && this.MC.Translation && this.DM.CheckLanguageTranslateByIdx((int) this.MC.LanguageSource) && (GameLanguage) this.MC.LanguageTarget == this.DM.UserLanguage && this.GUIM.CheckNeedTranslate(this.MC.Title))
          this.Cstr_Title.StringToFormat(this.MC.TitleT);
        else
          this.Cstr_Title.StringToFormat(this.MC.Title);
        this.Cstr_Title.AppendFormat("{0}{1}");
        this.text_Title.text = this.Cstr_Title.ToString();
      }
      else
        this.text_Title.text = !this.bTrans || !this.MC.Translation || !this.DM.CheckLanguageTranslateByIdx((int) this.MC.LanguageSource) || (GameLanguage) this.MC.LanguageTarget != this.DM.UserLanguage || !this.GUIM.CheckNeedTranslate(this.MC.Title) ? this.MC.Title : this.MC.TitleT;
      if (this.DM.bPlural)
      {
        this.MaxLetterNum = this.DM.GetMailboxSize(this.MC.ReplyID, this.MC.SenderName);
        this.tmpPageNum = (int) this.MC.MoreIndex + 1;
        if (this.MaxLetterNum > 1)
        {
          if ((int) this.MC.MoreIndex + 1 == 1)
          {
            ((Component) this.btn_Previous).gameObject.SetActive(false);
            if (!((UIBehaviour) this.btn_Next).IsActive())
              ((Component) this.btn_Next).gameObject.SetActive(true);
          }
          if ((int) this.MC.MoreIndex + 1 == this.MaxLetterNum)
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
      }
      else
      {
        this.MaxLetterNum = (int) this.DM.GetMailboxSize();
        this.tmpPageNum = (int) this.MC.Index + 1;
        if (this.MaxLetterNum > 1)
        {
          if ((int) this.MC.Index + 1 == 1)
          {
            ((Component) this.btn_Previous).gameObject.SetActive(false);
            if (!((UIBehaviour) this.btn_Next).IsActive())
              ((Component) this.btn_Next).gameObject.SetActive(true);
          }
          if ((int) this.MC.Index + 1 == this.MaxLetterNum)
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
      }
      this.text_Time[0].text = GameConstants.GetDateTime(this.MC.Times).ToString("MM/dd/yy");
      this.text_Time[1].text = GameConstants.GetDateTime(this.MC.Times).ToString("HH:mm:ss");
      CString cstring1 = StringManager.Instance.StaticString1024();
      CString cstring2 = StringManager.Instance.StaticString1024();
      CString Tag = StringManager.Instance.StaticString1024();
      if (this.MC.SenderTag.Length != 0)
      {
        this.Cstr_Name.ClearString();
        if (this.MC.MailType != (byte) 3)
        {
          if (this.MC.MailType == (byte) 4)
          {
            cstring1.ClearString();
            cstring2.ClearString();
            cstring2.Append(this.MC.SenderName);
            Tag.Append(this.MC.SenderTag);
            GameConstants.FormatRoleName(cstring1, cstring2, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
            this.Cstr_Name.StringToFormat(cstring1);
            this.Cstr_Name.AppendFormat(this.DM.mStringTable.GetStringByID(11055U));
          }
          else
          {
            cstring1.ClearString();
            cstring2.ClearString();
            cstring1.Append(this.MC.SenderName);
            cstring2.Append(this.MC.SenderTag);
            GameConstants.FormatRoleName(this.Cstr_Name, cstring1, cstring2, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
          }
          this.text_Name.text = this.Cstr_Name.ToString();
        }
        else
        {
          cstring1.ClearString();
          cstring2.ClearString();
          Tag.ClearString();
          cstring2.Append(this.MC.SenderName);
          Tag.Append(this.MC.SenderTag);
          if ((int) this.MC.SenderKindom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring1, cstring2, Tag, this.MC.SenderKindom, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring1, cstring2, Tag, (ushort) 0, this.GUIM.IsArabic);
          this.Cstr_Name.StringToFormat(cstring1);
          this.Cstr_Name.AppendFormat(this.DM.mStringTable.GetStringByID(1473U));
          this.text_Name.text = this.Cstr_Name.ToString();
        }
      }
      else
      {
        if (this.MC.MailType == (byte) 4)
        {
          this.Cstr_Name.StringToFormat(this.MC.SenderName);
          this.Cstr_Name.AppendFormat(this.DM.mStringTable.GetStringByID(11055U));
        }
        else
          this.Cstr_Name.Append(this.MC.SenderName);
        this.text_Name.text = this.Cstr_Name.ToString();
      }
      if (this.MC.MailType == (byte) 2)
      {
        this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
        this.text_Name.text = this.DM.mStringTable.GetStringByID(8252U);
        this.DeleteRT.anchoredPosition = new Vector2(226f, this.DeleteRT.anchoredPosition.y);
        this.CollectRT.anchoredPosition = new Vector2(287f, this.CollectRT.anchoredPosition.y);
        ((Component) this.ReplyRT).gameObject.SetActive(false);
        this.Cstr_Title.ClearString();
        this.Cstr_Title.StringToFormat(this.DM.mStringTable.GetStringByID(8257U));
        this.Cstr_Title.StringToFormat(this.MC.Title);
        this.Cstr_Title.AppendFormat("{0}{1}");
        this.text_Title.text = this.Cstr_Title.ToString();
      }
      else
      {
        if (this.MC.MailType == (byte) 3)
          this.text_Title.text = this.DM.mStringTable.GetStringByID(1474U);
        if (this.MC.MailType == (byte) 4)
        {
          this.DeleteRT.anchoredPosition = new Vector2(226f, this.DeleteRT.anchoredPosition.y);
          this.CollectRT.anchoredPosition = new Vector2(287f, this.CollectRT.anchoredPosition.y);
          ((Component) this.ReplyRT).gameObject.SetActive(false);
        }
        else
        {
          this.DeleteRT.anchoredPosition = new Vector2(165f, this.DeleteRT.anchoredPosition.y);
          this.CollectRT.anchoredPosition = new Vector2(226f, this.CollectRT.anchoredPosition.y);
          ((Component) this.ReplyRT).gameObject.SetActive(true);
        }
        this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.MC.SenderHead);
      }
      this.Img_Hero.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
      this.text_Contents.text = this.MC.MailType == (byte) 2 || !this.bTrans || !this.MC.Translation || !this.DM.CheckLanguageTranslateByIdx((int) this.MC.LanguageSource) || (GameLanguage) this.MC.LanguageTarget != this.DM.UserLanguage ? this.MC.Content : this.MC.ContentT;
      this.text_Contents.SetAllDirty();
      this.text_Contents.cachedTextGeneratorForLayout.Invalidate();
      this.text_Contents.cachedTextGenerator.Invalidate();
      if ((double) this.text_Contents.preferredHeight > 158.0)
      {
        ((Graphic) this.text_Contents).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Contents).rectTransform.sizeDelta.x, this.text_Contents.preferredHeight + 1f);
        if (this.bTrans)
        {
          this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, (float) (-193.0 - ((double) this.text_Contents.preferredHeight + 1.0 - 158.0) - 33.0));
          ((Graphic) this.text_Translation).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_Translation).rectTransform.anchoredPosition.x, (float) (-179.0 - ((double) this.text_Contents.preferredHeight + 1.0 - 158.0) - 33.0));
        }
      }
      if (this.MC.MailType != (byte) 2 && this.bTrans && this.GUIM.CheckNeedTranslate(this.MC.Content) && (!this.MC.Translation || this.MC.Translation && this.DM.CheckLanguageTranslateByIdx((int) this.MC.LanguageSource)))
      {
        ((Component) this.TranslationRT).gameObject.SetActive(true);
        ((Component) this.text_Translation).gameObject.SetActive(true);
        if (this.MC.Translation && (GameLanguage) this.MC.LanguageTarget == this.DM.UserLanguage)
        {
          this.Cstr_Translation.ClearString();
          this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID(this.MC.LanguageSource));
          this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054U));
          this.text_Translation.text = this.Cstr_Translation.ToString();
        }
        else
          this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052U);
      }
      else
      {
        ((Component) this.TranslationRT).gameObject.SetActive(false);
        ((Component) this.text_Translation).gameObject.SetActive(false);
        this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052U);
      }
      this.text_Translation.SetAllDirty();
      this.text_Translation.cachedTextGenerator.Invalidate();
      this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
      if ((double) this.text_Translation.preferredWidth > (double) ((Graphic) this.text_Translation).rectTransform.sizeDelta.x)
        ((Graphic) this.text_Translation).rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, ((Graphic) this.text_Translation).rectTransform.sizeDelta.y);
      float num = 0.0f;
      if (((Component) this.TranslationRT).gameObject.activeSelf)
        num = 84f;
      this.ContentRT.sizeDelta = (double) this.text_Contents.preferredHeight + 18.0 + (double) num <= 425.0 ? new Vector2(this.ContentRT.sizeDelta.x, 425f) : new Vector2(this.ContentRT.sizeDelta.x, 18f + num + this.text_Contents.preferredHeight);
      this.Mask_T.gameObject.SetActive(true);
      this.Letter_T.gameObject.SetActive(true);
      this.text_Title.SetAllDirty();
      this.text_Title.cachedTextGenerator.Invalidate();
    }
    else if (this.mLetterKind == 1)
    {
      this.text_Name.text = this.SC.Type >= NoticeReport.Enotice_NewbieOver && this.SC.Type <= NoticeReport.Enotice_SHLevel5 || this.SC.Type == NoticeReport.Enotice_FirstUnderPetAttack ? this.DM.mStringTable.GetStringByID(3717U) : this.DM.mStringTable.GetStringByID(6079U);
      this.MaxLetterNum = (int) this.DM.GetMailboxSize();
      this.tmpPageNum = (int) this.SC.Index + 1;
      this.text_Time[0].text = GameConstants.GetDateTime(this.SC.Times).ToString("MM/dd/yy");
      this.text_Time[1].text = GameConstants.GetDateTime(this.SC.Times).ToString("HH:mm:ss");
      this.mStatus = 8;
      CString cstring3 = StringManager.Instance.StaticString1024();
      CString cstring4 = StringManager.Instance.StaticString1024();
      CString cstring5 = StringManager.Instance.StaticString1024();
      CString cstring6 = StringManager.Instance.StaticString1024();
      CString tmpS1 = StringManager.Instance.StaticString1024();
      cstring3.ClearString();
      cstring4.ClearString();
      cstring5.ClearString();
      cstring6.ClearString();
      tmpS1.ClearString();
      switch (this.SC.Type)
      {
        case NoticeReport.ENotice_Enhance:
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6080U);
          this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.SC.NoticeHeroEnhance.HeroID);
          this.mHeroSkill[0] = this.tmpHero.GroupSkill2;
          this.mHeroSkill[1] = this.tmpHero.GroupSkill3;
          this.mHeroSkill[2] = this.tmpHero.GroupSkill4;
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpHero.HeroTitle));
          this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpHero.HeroName));
          this.Cstr_Contents_S.IntToFormat((long) this.SC.NoticeHeroEnhance.Rank);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6081U));
          this.Cstr_Contents_S.Append("\n \n \n");
          this.Cstr_Contents_S.IntToFormat((long) this.DM.RankSoldiers[(int) this.SC.NoticeHeroEnhance.Rank]);
          int rank = (int) this.SC.NoticeHeroEnhance.Rank;
          switch (rank)
          {
            case 2:
            case 4:
            case 7:
              this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6083U));
              ((Component) this.Img_HeroSkill[0]).gameObject.SetActive(true);
              ((Component) this.Img_HeroSkill[1]).gameObject.SetActive(true);
              this.mSkill = this.DM.SkillTable.GetRecordByKey(this.mHeroSkill[rank / 2 - 1]);
              this.Cstr_SkillIcon[0].ClearString();
              this.Cstr_SkillIcon[0].IntToFormat((long) this.mSkill.SkillIcon, 5);
              this.Cstr_SkillIcon[0].AppendFormat("s{0}");
              this.Img_HeroSkill_1[0].sprite = this.GUIM.LoadSkillSprite(this.Cstr_SkillIcon[0]);
              this.text_Skill_1[0].text = this.DM.mStringTable.GetStringByID((uint) this.mSkill.SkillName);
              this.Cstr_Skill.ClearString();
              float mValue = (float) this.mSkill.HurtValue + (float) ((int) this.LegionRankMagnifation[(int) this.SC.NoticeHeroEnhance.Star - 1] * (int) this.mSkill.HurtIncreaseValue) / 1000f;
              if (this.mSkill.SkillType == (byte) 10)
                GameConstants.GetEffectValue(this.Cstr_Skill, this.mSkill.HurtAddition, (uint) mValue, (byte) 1, 0.0f);
              else if (this.mSkill.HurtKind == (byte) 1)
                GameConstants.GetEffectValue(this.Cstr_Skill, this.mSkill.HurtAddition, (uint) this.mSkill.HurtValue + (uint) this.mSkill.HurtIncreaseValue * (uint) this.LegionRankMagnifation[(int) this.SC.NoticeHeroEnhance.Star - 1], (byte) 9, 0.0f);
              else
                GameConstants.GetEffectValue(this.Cstr_Skill, this.mSkill.HurtAddition, 0U, (byte) 6, mValue * 100f);
              this.text_Skill_1[1].text = this.Cstr_Skill.ToString();
              this.text_Skill_1[1].SetAllDirty();
              this.text_Skill_1[1].cachedTextGenerator.Invalidate();
              this.mSkill = this.DM.SkillTable.GetRecordByKey(this.tmpHero.AttackPower[rank / 2 + 1]);
              this.Cstr_SkillIcon[1].ClearString();
              this.Cstr_SkillIcon[1].IntToFormat((long) this.mSkill.SkillIcon, 5);
              this.Cstr_SkillIcon[1].AppendFormat("s{0}");
              this.Img_HeroSkill_2[0].sprite = this.GUIM.LoadSkillSprite(this.Cstr_SkillIcon[1]);
              this.text_Skill_2[0].text = this.DM.mStringTable.GetStringByID((uint) this.mSkill.SkillName);
              uint ID1;
              switch (this.mSkill.SkillType)
              {
                case 1:
                  ID1 = 476U;
                  break;
                case 2:
                  ID1 = 477U;
                  break;
                case 3:
                case 4:
                case 5:
                  ID1 = 478U;
                  break;
                default:
                  ID1 = 479U;
                  break;
              }
              this.text_Skill_2[1].text = this.DM.mStringTable.GetStringByID(ID1);
              break;
            default:
              this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6082U));
              break;
          }
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.ENotice_StarUp:
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6084U);
          this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.SC.NoticeHeroStarUp.HeroID);
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpHero.HeroTitle));
          this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.tmpHero.HeroName));
          this.Cstr_Contents_S.StringToFormat(this.Str_HeroColor[(int) this.SC.NoticeHeroStarUp.Star - 2]);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6085U));
          this.Cstr_Contents_S.Append("\n \n \n");
          this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(6086U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          this.HeroStarUp_T.gameObject.SetActive(true);
          this.tmpHero = this.DM.HeroTable.GetRecordByKey(this.SC.NoticeHeroStarUp.HeroID);
          this.mHeroSkill[0] = this.tmpHero.GroupSkill1;
          this.mHeroSkill[1] = this.tmpHero.GroupSkill2;
          this.mHeroSkill[2] = this.tmpHero.GroupSkill3;
          this.mHeroSkill[3] = this.tmpHero.GroupSkill4;
          for (int index = 0; index < 4; ++index)
          {
            this.mSkill = this.DM.SkillTable.GetRecordByKey(this.mHeroSkill[index]);
            cstring3.ClearString();
            cstring3.IntToFormat((long) this.mSkill.SkillIcon, 5);
            cstring3.AppendFormat("s{0}");
            this.Img_StarUpSkill[index].sprite = this.GUIM.LoadSkillSprite(cstring3);
            this.Cstr_StarUpValue[index].ClearString();
            float num = (float) this.mSkill.HurtValue + (float) ((int) this.LegionRankMagnifation[(int) this.SC.NoticeHeroStarUp.Star - 1] * (int) this.mSkill.HurtIncreaseValue) / 1000f;
            if (this.mSkill.SkillType == (byte) 10)
            {
              this.Cstr_StarUpValue[index].IntToFormat((long) (uint) num, bNumber: true);
              if (this.GUIM.IsArabic)
                this.Cstr_StarUpValue[index].AppendFormat("%{0}");
              else
                this.Cstr_StarUpValue[index].AppendFormat("{0}%");
            }
            else if (this.mSkill.HurtKind == (byte) 1)
            {
              this.Cstr_StarUpValue[index].IntToFormat((long) ((uint) this.mSkill.HurtValue + (uint) this.mSkill.HurtIncreaseValue * (uint) this.LegionRankMagnifation[(int) this.SC.NoticeHeroStarUp.Star - 1]), bNumber: true);
              this.Cstr_StarUpValue[index].AppendFormat("{0}");
            }
            else
            {
              this.Cstr_StarUpValue[index].FloatToFormat(num);
              if (this.GUIM.IsArabic)
                this.Cstr_StarUpValue[index].AppendFormat("%{0}");
              else
                this.Cstr_StarUpValue[index].AppendFormat("{0}%");
            }
            this.text_StarUp_1[index].text = this.Cstr_StarUpValue[index].ToString();
            this.text_StarUp_1[index].SetAllDirty();
            this.text_StarUp_1[index].cachedTextGenerator.Invalidate();
          }
          cstring3.ClearString();
          cstring3.IntToFormat((long) this.SC.NoticeHeroStarUp.Star);
          cstring3.AppendFormat("UI_box_hero_light_0{0}");
          this.Img_StarUpSkill_2[0].sprite = this.GUIM.LoadFrameSprite(cstring3);
          ((Component) this.text_StarUp_2[0]).gameObject.SetActive(true);
          if (this.SC.NoticeHeroStarUp.Rank >= (byte) 2)
          {
            this.Img_StarUpSkill_2[1].sprite = this.GUIM.LoadFrameSprite(cstring3);
            ((Component) this.Img_StarUpSkill_L[1]).gameObject.SetActive(false);
            ((Component) this.text_StarUp_2[1]).gameObject.SetActive(true);
          }
          else
          {
            ((Component) this.Img_StarUpSkill_L[1]).gameObject.SetActive(true);
            ((Component) this.text_StarUp_2[1]).gameObject.SetActive(false);
          }
          if (this.SC.NoticeHeroStarUp.Rank >= (byte) 4)
          {
            this.Img_StarUpSkill_2[2].sprite = this.GUIM.LoadFrameSprite(cstring3);
            ((Component) this.Img_StarUpSkill_L[2]).gameObject.SetActive(false);
            ((Component) this.text_StarUp_2[2]).gameObject.SetActive(true);
          }
          else
          {
            ((Component) this.Img_StarUpSkill_L[2]).gameObject.SetActive(true);
            ((Component) this.text_StarUp_2[2]).gameObject.SetActive(false);
          }
          if (this.SC.NoticeHeroStarUp.Rank >= (byte) 7)
          {
            this.Img_StarUpSkill_2[3].sprite = this.GUIM.LoadFrameSprite(cstring3);
            ((Component) this.Img_StarUpSkill_L[3]).gameObject.SetActive(false);
            ((Component) this.text_StarUp_2[3]).gameObject.SetActive(true);
            break;
          }
          ((Component) this.Img_StarUpSkill_L[3]).gameObject.SetActive(true);
          ((Component) this.text_StarUp_2[3]).gameObject.SetActive(false);
          break;
        case NoticeReport.ENotice_JoinAlliance:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6051U);
          this.Cstr_Contents_S.ClearString();
          if (this.GUIM.IsArabic)
          {
            cstring5.Append(this.SC.Notice_JoinAlliance.Name);
            cstring6.Append(this.SC.Notice_JoinAlliance.Tag);
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
            this.Cstr_Contents_S.StringToFormat(cstring4);
            this.Cstr_Contents_S.StringToFormat(string.Empty);
          }
          else
          {
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_JoinAlliance.Tag);
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_JoinAlliance.Name);
          }
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6052U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_ApplyAlliance:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6053U);
          this.Cstr_Contents_S.ClearString();
          if (this.GUIM.IsArabic)
          {
            cstring5.Append(this.SC.Notice_ApplyAlliance.Name);
            cstring6.Append(this.SC.Notice_ApplyAlliance.Tag);
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
            this.Cstr_Contents_S.StringToFormat(cstring4);
            this.Cstr_Contents_S.StringToFormat(string.Empty);
          }
          else
          {
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_ApplyAlliance.Tag);
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_ApplyAlliance.Name);
          }
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6054U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_ApplyAllianceBeDenied:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6055U);
          this.Cstr_Contents_S.ClearString();
          if (this.GUIM.IsArabic)
          {
            cstring5.Append(this.SC.Notice_ApplyAllianceBeDenied.Name);
            cstring6.Append(this.SC.Notice_ApplyAllianceBeDenied.Tag);
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_ApplyAllianceBeDenied.Dealer);
            this.Cstr_Contents_S.StringToFormat(cstring4);
            this.Cstr_Contents_S.StringToFormat(string.Empty);
          }
          else
          {
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_ApplyAllianceBeDenied.Dealer);
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_ApplyAllianceBeDenied.Tag);
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_ApplyAllianceBeDenied.Name);
          }
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6056U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_AllianceDismiss:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6059U);
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.StringToFormat(this.SC.Notice_AllianceDismiss.Leader);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6060U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_AllianceLeaderStepDown:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6063U);
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.StringToFormat(this.SC.Notice_AllianceLeaderStepDown.OldLeader);
          this.Cstr_Contents_S.StringToFormat(this.SC.Notice_AllianceLeaderStepDown.NewLeader);
          this.Cstr_Contents_S.StringToFormat(this.SC.Notice_AllianceLeaderStepDown.NewLeader);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6064U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_ActivityDegreePrize:
        case NoticeReport.Enotice_ActivityKVKDegreePrize:
          this.Cstr_Contents_S.ClearString();
          int prizeNum1;
          if (this.SC.Type == NoticeReport.Enotice_ActivityDegreePrize)
          {
            this.mPrizeType = Detail_Prize.Enotice_ActivityDegreePrize;
            if (this.SC.Notice_ActivityDegreePrize.Type == NoticeContent.ActivityCircleEventType.EACET_SoloEvent)
            {
              this.text_Title.text = this.DM.mStringTable.GetStringByID(7686U);
              this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(7678U));
              this.mStatus = 13;
            }
            else if (this.SC.Notice_ActivityDegreePrize.Type == NoticeContent.ActivityCircleEventType.EACET_InfernalEvent)
            {
              this.text_Title.text = this.DM.mStringTable.GetStringByID(7688U);
              this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(7682U));
              this.mStatus = 15;
            }
            prizeNum1 = (int) this.SC.Notice_ActivityDegreePrize.PrizeNum;
          }
          else
          {
            this.mPrizeType = Detail_Prize.Enotice_ActivityKVKDegreePrize;
            if (this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomKillEvent || this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomMatchEvent)
              this.mStatus = 21;
            else if (this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomNormalEvent)
              this.mStatus = 16;
            if (this.SC.Enotice_ActivityKVKDegreePrize.EventType == EActivityKingdomEventType.EAKET_SoloEvent)
            {
              if (this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomKillEvent || this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomMatchEvent)
              {
                this.text_Title.text = this.DM.mStringTable.GetStringByID(9846U);
                this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(9842U));
              }
              else if (this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomNormalEvent)
              {
                this.text_Title.text = this.DM.mStringTable.GetStringByID(9844U);
                this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(9838U));
              }
            }
            else if (this.SC.Enotice_ActivityKVKDegreePrize.EventType == EActivityKingdomEventType.EAKET_AllianceEvent)
            {
              if (this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomKillEvent || this.SC.Enotice_ActivityKVKDegreePrize.ActType == EActivityType.EAT_KingdomMatchEvent)
              {
                this.text_Title.text = this.DM.mStringTable.GetStringByID(9845U);
                this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(9840U));
              }
            }
            else if (this.SC.Enotice_ActivityKVKDegreePrize.EventType != EActivityKingdomEventType.EAKET_KingdomEvent)
              ;
            prizeNum1 = (int) this.SC.Enotice_ActivityKVKDegreePrize.PrizeNum;
          }
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          this.mDiamond = 0U;
          this.mValue = 0U;
          this.mNoValueCount = (byte) 0;
          this.tmplistItem.Clear();
          for (int index = 0; index < prizeNum1; ++index)
          {
            this.bAddList = true;
            ushort itemId;
            byte num;
            if (this.mPrizeType == Detail_Prize.Enotice_ActivityDegreePrize)
            {
              itemId = this.SC.Notice_ActivityDegreePrize.PrizeData[index].ItemID;
              num = this.SC.Notice_ActivityDegreePrize.PrizeData[index].Num;
            }
            else
            {
              itemId = this.SC.Enotice_ActivityKVKDegreePrize.PrizeData[index].ItemID;
              num = this.SC.Enotice_ActivityKVKDegreePrize.PrizeData[index].Num;
            }
            this.tmpEQ = this.DM.EquipTable.GetRecordByKey(itemId);
            if (this.tmpEQ.EquipKind == (byte) 11 && this.tmpEQ.PropertiesInfo[0].Propertieskey == (ushort) 6)
            {
              this.bAddList = false;
              this.mDiamond += (uint) this.tmpEQ.PropertiesInfo[1].Propertieskey * (uint) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (uint) num;
              this.mValue += (uint) this.tmpEQ.PropertiesInfo[1].Propertieskey * (uint) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (uint) num;
            }
            else
            {
              this.ShopID = this.DM.TotalShopItemData.Find(itemId);
              if (this.ShopID != (ushort) 0 && this.DM.StoreData.GetRecordByKey(this.ShopID).Price > 0U)
                this.mValue += this.DM.StoreData.GetRecordByKey(this.ShopID).Price * (uint) num;
              else
                this.mNoValueCount += num;
            }
            if (this.bAddList)
              this.tmplistItem.Add((ushort) index);
          }
          break;
        case NoticeReport.Enotice_ActivityRankPrize:
        case NoticeReport.Enotice_ActivityKVKRankPrize:
          this.Cstr_Contents_S.ClearString();
          int prizeNum2;
          if (this.SC.Type == NoticeReport.Enotice_ActivityRankPrize)
          {
            this.mPrizeType = Detail_Prize.Enotice_ActivityRankPrize;
            this.Cstr_Contents_S.IntToFormat((long) this.SC.Notice_ActivityRankPrize.Place);
            if (this.SC.Notice_ActivityRankPrize.Type == NoticeContent.ActivityCircleEventType.EACET_SoloEvent)
            {
              this.text_Title.text = this.DM.mStringTable.GetStringByID(7686U);
              this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(7679U));
              this.mStatus = 13;
            }
            else if (this.SC.Notice_ActivityRankPrize.Type == NoticeContent.ActivityCircleEventType.EACET_InfernalEvent)
            {
              this.text_Title.text = this.DM.mStringTable.GetStringByID(7688U);
              this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(7683U));
              this.mStatus = 15;
            }
            prizeNum2 = (int) this.SC.Notice_ActivityRankPrize.PrizeNum;
          }
          else
          {
            this.mPrizeType = Detail_Prize.Enotice_ActivityKVKRankPrize;
            this.Cstr_Contents_S.IntToFormat((long) this.SC.Enotice_ActivityKVKRankPrize.Place);
            if (this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomKillEvent || this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomMatchEvent)
              this.mStatus = 21;
            else if (this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomNormalEvent)
              this.mStatus = 16;
            if (this.SC.Enotice_ActivityKVKRankPrize.EventType == EActivityKingdomEventType.EAKET_SoloEvent)
            {
              if (this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomKillEvent || this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomMatchEvent)
              {
                this.text_Title.text = this.DM.mStringTable.GetStringByID(9846U);
                this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9843U));
              }
              else if (this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomNormalEvent)
              {
                this.text_Title.text = this.DM.mStringTable.GetStringByID(9844U);
                this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9839U));
              }
            }
            else if (this.SC.Enotice_ActivityKVKRankPrize.EventType == EActivityKingdomEventType.EAKET_AllianceEvent)
            {
              if (this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomKillEvent || this.SC.Enotice_ActivityKVKRankPrize.ActType == EActivityType.EAT_KingdomMatchEvent)
              {
                this.text_Title.text = this.DM.mStringTable.GetStringByID(9845U);
                this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9841U));
              }
            }
            else if (this.SC.Enotice_ActivityKVKRankPrize.EventType != EActivityKingdomEventType.EAKET_KingdomEvent)
              ;
            prizeNum2 = (int) this.SC.Enotice_ActivityKVKRankPrize.PrizeNum;
          }
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          this.mDiamond = 0U;
          this.mValue = 0U;
          this.mNoValueCount = (byte) 0;
          this.tmplistItem.Clear();
          for (int index = 0; index < prizeNum2; ++index)
          {
            this.bAddList = true;
            ushort itemId;
            byte num;
            if (this.mPrizeType == Detail_Prize.Enotice_ActivityRankPrize)
            {
              itemId = this.SC.Notice_ActivityRankPrize.PrizeData[index].ItemID;
              num = this.SC.Notice_ActivityRankPrize.PrizeData[index].Num;
            }
            else
            {
              itemId = this.SC.Enotice_ActivityKVKRankPrize.PrizeData[index].ItemID;
              num = this.SC.Enotice_ActivityKVKRankPrize.PrizeData[index].Num;
            }
            this.tmpEQ = this.DM.EquipTable.GetRecordByKey(itemId);
            if (this.tmpEQ.EquipKind == (byte) 11 && this.tmpEQ.PropertiesInfo[0].Propertieskey == (ushort) 6)
            {
              this.bAddList = false;
              this.mDiamond += (uint) this.tmpEQ.PropertiesInfo[1].Propertieskey * (uint) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (uint) num;
              this.mValue += (uint) this.tmpEQ.PropertiesInfo[1].Propertieskey * (uint) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (uint) num;
            }
            else
            {
              this.ShopID = this.DM.TotalShopItemData.Find(itemId);
              if (this.ShopID != (ushort) 0 && this.DM.StoreData.GetRecordByKey(this.ShopID).Price > 0U)
                this.mValue += this.DM.StoreData.GetRecordByKey(this.ShopID).Price * (uint) num;
              else
                this.mNoValueCount += num;
            }
            if (this.bAddList)
              this.tmplistItem.Add((ushort) index);
          }
          break;
        case NoticeReport.Enotice_InviteAlliance:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6057U);
          this.Cstr_Contents_S.ClearString();
          if (this.GUIM.IsArabic)
          {
            cstring5.Append(this.SC.Notice_InviteAlliance.Name);
            cstring6.Append(this.SC.Notice_InviteAlliance.Tag);
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_InviteAlliance.InviterName);
            this.Cstr_Contents_S.StringToFormat(cstring4);
            this.Cstr_Contents_S.StringToFormat(string.Empty);
          }
          else
          {
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_InviteAlliance.InviterName);
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_InviteAlliance.Tag);
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_InviteAlliance.Name);
          }
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6058U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          ((Component) this.btn_AllianceInvite_S).gameObject.SetActive(true);
          break;
        case NoticeReport.Enotice_SynLordEquip:
          this.text_Title.text = this.DM.mStringTable.GetStringByID(7700U);
          ((Component) this.Img_Hero_S).transform.parent.gameObject.SetActive(false);
          ((Component) this.Img_LordEquip_BG).gameObject.SetActive(true);
          this.Tmp = this.Letter_S_T.GetChild(7);
          this.Img_LordEquip_BG = this.Tmp.GetComponent<Image>();
          this.Tmp = this.Letter_S_T.GetChild(7).GetChild(0);
          Equip recordByKey1 = this.DM.EquipTable.GetRecordByKey(this.SC.Notice_SynLordEquip.ItemID);
          CString cstring7 = StringManager.Instance.StaticString1024();
          cstring7.ClearString();
          cstring7.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
          if (this.SC.Notice_SynLordEquip.Rank == (byte) 1)
            cstring7.AppendFormat("<color=#ffffffff>{0}</color>");
          else if (this.SC.Notice_SynLordEquip.Rank == (byte) 2)
            cstring7.AppendFormat("<color=#005a2fff>{0}</color>");
          else if (this.SC.Notice_SynLordEquip.Rank == (byte) 3)
            cstring7.AppendFormat("<color=#004fa7ff>{0}</color>");
          else if (this.SC.Notice_SynLordEquip.Rank == (byte) 4)
            cstring7.AppendFormat("<color=#5a1ca7ff>{0}</color>");
          else if (this.SC.Notice_SynLordEquip.Rank == (byte) 5)
            cstring7.AppendFormat("<color=#ffff00ff>{0}</color>");
          this.Cstr_LordEquip[0].ClearString();
          this.Cstr_LordEquip[0].StringToFormat(cstring7.ToString());
          this.Cstr_LordEquip[0].AppendFormat(this.DM.mStringTable.GetStringByID(7699U));
          this.Cstr_LordEquip[1].ClearString();
          this.Cstr_LordEquip[1].Append(this.DM.mStringTable.GetStringByID(7698U));
          this.Cstr_LordEquip[1].IntToFormat((long) this.SC.Notice_SynLordEquip.AddExp, bNumber: true);
          this.Cstr_LordEquip[1].AppendFormat("<color=#24ff13ff>+{0}</color>");
          for (int index = 0; index < 2; ++index)
          {
            this.text_LordEquip[index].text = this.Cstr_LordEquip[index].ToString();
            this.text_LordEquip[index].SetAllDirty();
            this.text_LordEquip[index].cachedTextGenerator.Invalidate();
          }
          this.GUIM.InitLordEquipImg(((Component) this.mLebtn).transform, this.SC.Notice_SynLordEquip.ItemID, this.SC.Notice_SynLordEquip.Rank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
          ((Component) this.mLebtn).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
          this.Cstr_LordEquip_Lv.ClearString();
          this.Cstr_LordEquip_Lv.IntToFormat((long) recordByKey1.NeedLv, bNumber: true);
          this.Cstr_LordEquip_Lv.AppendFormat(this.DM.mStringTable.GetStringByID(8201U));
          this.text_LordEquip_Lv.text = this.Cstr_LordEquip_Lv.ToString();
          this.text_LordEquip_Lv.SetAllDirty();
          this.text_LordEquip_Lv.cachedTextGenerator.Invalidate();
          this.effectList.Clear();
          LordEquipData.GetEffectList(recordByKey1.EquipKey, this.SC.Notice_SynLordEquip.Rank, this.effectList);
          for (int index = 0; index < this.effectList.Count; ++index)
          {
            this.Cstr_LordEquip_Effect[index][0].ClearString();
            GameConstants.GetEffectValue(this.Cstr_LordEquip_Effect[index][0], this.effectList[index].EffectID, 0U, (byte) 8, 0.0f);
            this.text_LordEquip_Effect[index][0].text = this.Cstr_LordEquip_Effect[index][0].ToString();
            this.text_LordEquip_Effect[index][0].SetAllDirty();
            this.text_LordEquip_Effect[index][0].cachedTextGenerator.Invalidate();
            this.Cstr_LordEquip_Effect[index][1].ClearString();
            GameConstants.GetEffectValue(this.Cstr_LordEquip_Effect[index][1], this.effectList[index].EffectID, (uint) this.effectList[index].EffectValue, (byte) 3, 0.0f);
            this.text_LordEquip_Effect[index][1].text = this.Cstr_LordEquip_Effect[index][1].ToString();
            this.text_LordEquip_Effect[index][1].SetAllDirty();
            this.text_LordEquip_Effect[index][1].cachedTextGenerator.Invalidate();
          }
          for (int count = this.effectList.Count; count < 6; ++count)
          {
            ((Component) this.text_LordEquip_Effect[count][0]).gameObject.SetActive(false);
            ((Component) this.text_LordEquip_Effect[count][1]).gameObject.SetActive(false);
          }
          break;
        case NoticeReport.Enotice_RallyCancel:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6067U);
          cstring5.Append(this.SC.Notice_RallyNotice.HostName);
          cstring6.Append(this.SC.Notice_RallyNotice.HostTag);
          this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          cstring3.StringToFormat(cstring4);
          cstring3.StringToFormat(string.Empty);
          cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(5389U));
          cstring4.ClearString();
          cstring5.ClearString();
          cstring6.ClearString();
          cstring5.Append(this.SC.Notice_RallyNotice.TargetName);
          cstring6.Append(this.SC.Notice_RallyNotice.TargetTag);
          this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          tmpS1.StringToFormat(cstring4);
          tmpS1.StringToFormat(string.Empty);
          tmpS1.AppendFormat(this.DM.mStringTable.GetStringByID(5390U));
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.StringToFormat(cstring3);
          this.Cstr_Contents_S.StringToFormat(tmpS1);
          this.Cstr_Contents_S.AppendFormat("{0}\n{1}");
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_CryptFinish:
          ((Component) this.Img_CryptFinish_BG).gameObject.SetActive(true);
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6077U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(6078U);
          BuildLevelRequest levelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort) 16, this.SC.Notice_CryptNotice.Level);
          uint x = (uint) Math.Floor((double) this.SC.Notice_CryptNotice.Money * (1.0 + GameConstants.cryptInterest[(int) this.SC.Notice_CryptNotice.Kind] + (double) levelRequestData.Value2 / 10000.0));
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.IntToFormat((long) x, bNumber: true);
          if (this.GUIM.IsArabic)
            this.Cstr_Contents_S.AppendFormat("{0} x");
          else
            this.Cstr_Contents_S.AppendFormat("x {0}");
          this.text_CryptFinish.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_OtherSavedLord:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6074U);
          this.Cstr_Contents_S.ClearString();
          cstring5.Append(this.SC.Notice_OtherSavedLord.Name);
          if (this.SC.Notice_OtherSavedLord.AllianceTag != string.Empty)
          {
            cstring6.Append(this.SC.Notice_OtherSavedLord.AllianceTag);
            if ((int) this.SC.Notice_OtherSavedLord.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, this.SC.Notice_OtherSavedLord.HomeKingdom, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          }
          else if ((int) this.SC.Notice_OtherSavedLord.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: this.SC.Notice_OtherSavedLord.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
          this.Cstr_Contents_S.StringToFormat(cstring4);
          this.Cstr_Contents_S.StringToFormat(string.Empty);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6071U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_SelfSavedLord:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(7656U);
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(6075U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_LordBeingReleased:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6072U);
          this.Cstr_Contents_S.ClearString();
          cstring5.Append(this.SC.Notice_LordBeingReleased.Name);
          if (this.SC.Notice_LordBeingReleased.AllianceTag != string.Empty)
          {
            cstring6.Append(this.SC.Notice_LordBeingReleased.AllianceTag);
            if ((int) this.SC.Notice_LordBeingReleased.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, this.SC.Notice_LordBeingReleased.HomeKingdom, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          }
          else if ((int) this.SC.Notice_LordBeingReleased.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: this.SC.Notice_LordBeingReleased.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
          this.Cstr_Contents_S.StringToFormat(cstring4);
          this.Cstr_Contents_S.StringToFormat(string.Empty);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(6073U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_LordBeingExecuted:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(7659U);
          this.Cstr_Contents_S.ClearString();
          cstring5.Append(this.SC.Notice_LordBeingExecuted.Name);
          if (this.SC.Notice_LordBeingExecuted.AllianceTag != string.Empty)
          {
            cstring6.Append(this.SC.Notice_LordBeingExecuted.AllianceTag);
            if ((int) this.SC.Notice_LordBeingExecuted.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, this.SC.Notice_LordBeingExecuted.HomeKingdom, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          }
          else if ((int) this.SC.Notice_LordBeingExecuted.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: this.SC.Notice_LordBeingExecuted.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
          this.Cstr_Contents_S.StringToFormat(cstring4);
          this.Cstr_Contents_S.StringToFormat(string.Empty);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(7660U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_LordEscaped:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6070U);
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(7655U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_OtherBreakPrison:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(7665U);
          this.Cstr_Contents_S.ClearString();
          cstring5.Append(this.SC.Notice_OtherBreakPrison.Name);
          if (this.SC.Notice_OtherBreakPrison.AllianceTag != string.Empty)
          {
            cstring6.Append(this.SC.Notice_OtherBreakPrison.AllianceTag);
            if ((int) this.SC.Notice_OtherBreakPrison.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, this.SC.Notice_OtherBreakPrison.HomeKingdom, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          }
          else if ((int) this.SC.Notice_OtherBreakPrison.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: this.SC.Notice_OtherBreakPrison.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
          this.Cstr_Contents_S.StringToFormat(cstring4);
          this.Cstr_Contents_S.StringToFormat(string.Empty);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(7666U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_RescuedPrisoner:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.Cstr_Contents_S.ClearString();
          cstring5.Append(this.SC.Notice_RescuedPrisoner.Name);
          if (this.SC.Notice_RescuedPrisoner.AllianceTag != string.Empty)
          {
            cstring6.Append(this.SC.Notice_RescuedPrisoner.AllianceTag);
            if ((int) this.SC.Notice_RescuedPrisoner.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, this.SC.Notice_RescuedPrisoner.HomeKingdom, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          }
          else if ((int) this.SC.Notice_RescuedPrisoner.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: this.SC.Notice_RescuedPrisoner.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
          this.Cstr_Contents_S.StringToFormat(cstring4);
          this.Cstr_Contents_S.StringToFormat(string.Empty);
          this.Cstr_Contents_S.IntToFormat((long) this.SC.Notice_RescuedPrisoner.PrisonerNum);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(7663U));
          if (this.SC.Notice_RescuedPrisoner.ClaimReward != 0U)
          {
            cstring3.ClearString();
            cstring3.Append("\n");
            cstring3.IntToFormat((long) this.SC.Notice_RescuedPrisoner.ClaimReward, bNumber: true);
            cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(7664U));
            this.Cstr_Contents_S.Append(cstring3);
            this.text_Title.text = this.DM.mStringTable.GetStringByID(6076U);
          }
          else
            this.text_Title.text = this.DM.mStringTable.GetStringByID(8235U);
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_RequestRansom:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(7658U);
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.IntToFormat((long) this.SC.Notice_RequestRansom.Ransom, bNumber: true);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(7657U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_ReceivedRansom:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8232U);
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.IntToFormat((long) this.SC.Notice_ReceivedRansom.Ransom, bNumber: true);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(7661U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_PrisonFull:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8234U);
          this.Cstr_Contents_S.ClearString();
          cstring5.Append(this.SC.Notice_PrisonFull.Name);
          if (this.SC.Notice_PrisonFull.AllianceTag != string.Empty)
          {
            cstring6.Append(this.SC.Notice_PrisonFull.AllianceTag);
            if ((int) this.SC.Notice_PrisonFull.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, this.SC.Notice_PrisonFull.HomeKingdom, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          }
          else if ((int) this.SC.Notice_PrisonFull.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: this.SC.Notice_PrisonFull.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
          this.Cstr_Contents_S.StringToFormat(cstring4);
          this.Cstr_Contents_S.StringToFormat(string.Empty);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(8233U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_RallyCancel_AsTargetAlly:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6067U);
          cstring5.Append(this.SC.Notice_AsTargetAlly.HostName);
          cstring6.Append(this.SC.Notice_AsTargetAlly.HostTag);
          this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          cstring3.StringToFormat(cstring4);
          cstring3.StringToFormat(string.Empty);
          cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(5389U));
          cstring5.ClearString();
          cstring6.ClearString();
          cstring5.Append(this.SC.Notice_AsTargetAlly.TargetName);
          cstring6.Append(this.SC.Notice_AsTargetAlly.HostTag);
          this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          tmpS1.StringToFormat(cstring4);
          tmpS1.StringToFormat(string.Empty);
          tmpS1.AppendFormat(this.DM.mStringTable.GetStringByID(5390U));
          cstring6.ClearString();
          cstring6.StringToFormat(this.SC.Notice_AsTargetAlly.TargetName);
          cstring6.AppendFormat(this.DM.mStringTable.GetStringByID(8216U));
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.StringToFormat(cstring3);
          this.Cstr_Contents_S.StringToFormat(tmpS1);
          this.Cstr_Contents_S.StringToFormat(cstring6);
          this.Cstr_Contents_S.AppendFormat("{0}\n{1}\n{2}");
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_BeQuitAlliance:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8215U);
          this.Cstr_Contents_S.ClearString();
          if (this.GUIM.IsArabic)
          {
            cstring5.Append(this.SC.Notice_BeQuitAlliance.Alliance);
            cstring6.Append(this.SC.Notice_BeQuitAlliance.AllianceTag);
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_BeQuitAlliance.Dealer);
            this.Cstr_Contents_S.StringToFormat(cstring4);
            this.Cstr_Contents_S.StringToFormat(string.Empty);
          }
          else
          {
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_BeQuitAlliance.Dealer);
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_BeQuitAlliance.AllianceTag);
            this.Cstr_Contents_S.StringToFormat(this.SC.Notice_BeQuitAlliance.Alliance);
          }
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(8214U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_BuyTreasure:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8236U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(8237U);
          break;
        case NoticeReport.Enotice_RallyCancel_Moving:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6067U);
          cstring5.Append(this.SC.Notice_RallyNotice_Moving.HostName);
          cstring6.Append(this.SC.Notice_RallyNotice_Moving.HostTag);
          this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          cstring3.StringToFormat(cstring4);
          cstring3.StringToFormat(string.Empty);
          cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(5389U));
          cstring5.ClearString();
          cstring6.ClearString();
          cstring5.Append(this.SC.Notice_RallyNotice_Moving.TargetName);
          cstring6.Append(this.SC.Notice_RallyNotice_Moving.TargetTag);
          this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          tmpS1.StringToFormat(cstring4);
          tmpS1.StringToFormat(string.Empty);
          tmpS1.AppendFormat(this.DM.mStringTable.GetStringByID(5390U));
          cstring6.ClearString();
          cstring6.StringToFormat(cstring4);
          cstring6.StringToFormat(string.Empty);
          cstring6.AppendFormat(this.DM.mStringTable.GetStringByID(8245U));
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.StringToFormat(cstring3);
          this.Cstr_Contents_S.StringToFormat(tmpS1);
          this.Cstr_Contents_S.StringToFormat(cstring6);
          this.Cstr_Contents_S.AppendFormat("{0}\n{1}\n{2}");
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_AtkFailedSelfShield:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          CString tmpS2 = StringManager.Instance.StaticString1024();
          tmpS2.ClearString();
          CString tmpS3 = StringManager.Instance.StaticString1024();
          tmpS3.ClearString();
          if (this.SC.Enotice_AtkFailedSelfShield.FailedType == (byte) 1)
          {
            this.text_Title.text = this.DM.mStringTable.GetStringByID(8250U);
            tmpS3.Append(this.DM.mStringTable.GetStringByID(7668U));
          }
          else
          {
            this.text_Title.text = this.DM.mStringTable.GetStringByID(8251U);
            tmpS3.Append(this.DM.mStringTable.GetStringByID(7667U));
          }
          this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.SC.Enotice_AtkFailedSelfShield.zoneID, this.SC.Enotice_AtkFailedSelfShield.pointID));
          tmpS2.IntToFormat((long) this.SC.Enotice_AtkFailedSelfShield.KingdomID);
          tmpS2.IntToFormat((long) (int) this.tmpV.x);
          tmpS2.IntToFormat((long) (int) this.tmpV.y);
          tmpS2.AppendFormat("K:{0}X:{1}Y:{2}");
          this.Cstr_Contents_S.StringToFormat(tmpS2);
          this.Cstr_Contents_S.StringToFormat(tmpS3);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(657U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_InactiveState:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8249U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(8248U);
          break;
        case NoticeReport.Enotice_NewbieOver:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(3718U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3719U);
          break;
        case NoticeReport.Enotice_SHLevel6:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(3720U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3721U);
          break;
        case NoticeReport.Enotice_SHLevel10:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(3722U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3723U);
          break;
        case NoticeReport.Enotice_SHLevel15:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(3724U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3725U);
          break;
        case NoticeReport.Enotice_SHLevel17:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(3726U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3727U);
          break;
        case NoticeReport.Enotice_FirstUnderAttack:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(3728U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3729U);
          break;
        case NoticeReport.Enotice_FirstJoinAlliance:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(3730U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3731U);
          break;
        case NoticeReport.Enotice_SHLevel5:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(3732U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(3733U);
          break;
        case NoticeReport.Enotice_BuyMonthTreature:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8236U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(920U);
          break;
        case NoticeReport.Enotice_RecivedGift:
          this.Gifts_T.gameObject.SetActive(true);
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(9095U);
          if (this.GUIM.IsArabic)
          {
            cstring5.Append(this.SC.Enotice_RecivedGift.GiftsName);
            cstring6.Append(this.SC.Enotice_RecivedGift.GiftsTag);
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
            this.Cstr_Contents_S.StringToFormat(cstring4);
            this.Cstr_Contents_S.StringToFormat(string.Empty);
          }
          else
          {
            this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_RecivedGift.GiftsTag);
            this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_RecivedGift.GiftsName);
          }
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9093U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_PrisonAmnestied:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          cstring5.Append(this.SC.Enotice_PrisonAmnestied.KingdomName);
          cstring6.Append(this.SC.Enotice_PrisonAmnestied.KingdomTag);
          this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          this.Cstr_Name.StringToFormat(cstring4);
          this.Cstr_Name.AppendFormat(this.DM.mStringTable.GetStringByID(1473U));
          this.text_Name.text = this.Cstr_Name.ToString();
          this.text_Title.text = this.DM.mStringTable.GetStringByID(1475U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(1463U);
          break;
        case NoticeReport.Enotice_LordBeingAmnestied:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          cstring5.Append(this.SC.Enotice_LordBeingAmnestied.KingdomName);
          cstring6.Append(this.SC.Enotice_LordBeingAmnestied.KingdomTag);
          this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          this.Cstr_Name.StringToFormat(cstring4);
          this.Cstr_Name.AppendFormat(this.DM.mStringTable.GetStringByID(1473U));
          this.text_Name.text = this.Cstr_Name.ToString();
          this.text_Title.text = this.DM.mStringTable.GetStringByID(1475U);
          cstring5.ClearString();
          cstring6.ClearString();
          cstring5.Append(this.SC.Enotice_LordBeingAmnestied.Name);
          cstring6.Append(this.SC.Enotice_LordBeingAmnestied.Tag);
          this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          this.Cstr_Contents_S.StringToFormat(cstring4);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(1462U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_RulerGift:
          this.Gifts_T.gameObject.SetActive(true);
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(9714U);
          cstring5.Append(this.SC.Enotice_RulerGift.Name);
          cstring6.Append(this.SC.Enotice_RulerGift.Tag);
          this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          this.Cstr_Contents_S.StringToFormat(cstring4);
          if (this.SC.Enotice_RulerGift.RulerKind == (byte) 1)
          {
            this.text_Title.text = this.DM.mStringTable.GetStringByID(9714U);
            this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9715U));
          }
          else if (this.SC.Enotice_RulerGift.RulerKind == (byte) 2)
          {
            this.text_Title.text = this.DM.mStringTable.GetStringByID(9799U);
            this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9800U));
          }
          else if (this.SC.Enotice_RulerGift.RulerKind == (byte) 3)
          {
            this.text_Title.text = this.DM.mStringTable.GetStringByID(11086U);
            this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(11087U));
          }
          else
          {
            this.text_Title.text = this.DM.mStringTable.GetStringByID(1049U);
            this.Cstr_Contents_S.AppendFormat("{0}");
            this.Cstr_Contents_S.ClearString();
            this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(1049U));
          }
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_DismissAllianceLeader:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(9529U);
          this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_DismissAllianceLeader.OldLeader);
          this.Cstr_Contents_S.IntToFormat((long) this.SC.Enotice_DismissAllianceLeader.OffLineDay);
          this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_DismissAllianceLeader.NewLeader);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9535U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_AmbushDefSuccess:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(9754U);
          cstring5.Append(this.SC.Enotice_AmbushDefSuccess.AtkPlayerName);
          if (this.SC.Enotice_AmbushDefSuccess.AtkPlayerAllianceTag != string.Empty)
          {
            cstring6.Append(this.SC.Enotice_AmbushDefSuccess.AtkPlayerAllianceTag);
            if ((int) this.SC.Enotice_AmbushDefSuccess.AtkPlayerHomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, this.SC.Enotice_AmbushDefSuccess.AtkPlayerHomeKingdom, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          }
          else if ((int) this.SC.Enotice_AmbushDefSuccess.AtkPlayerHomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: this.SC.Enotice_AmbushDefSuccess.AtkPlayerHomeKingdom, ForceArabic: this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
          this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_AmbushDefSuccess.AmbushName);
          this.Cstr_Contents_S.StringToFormat(cstring4);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9755U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_AmbushDefFailed:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(9756U);
          cstring5.Append(this.SC.Enotice_AmbushDefFailed.AtkPlayerName);
          if (this.SC.Enotice_AmbushDefFailed.AtkPlayerAllianceTag != string.Empty)
          {
            cstring6.Append(this.SC.Enotice_AmbushDefFailed.AtkPlayerAllianceTag);
            if ((int) this.SC.Enotice_AmbushDefFailed.AtkPlayerHomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, this.SC.Enotice_AmbushDefFailed.AtkPlayerHomeKingdom, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          }
          else if ((int) this.SC.Enotice_AmbushDefFailed.AtkPlayerHomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: this.SC.Enotice_AmbushDefFailed.AtkPlayerHomeKingdom, ForceArabic: this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
          this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_AmbushDefFailed.AmbushName);
          this.Cstr_Contents_S.StringToFormat(cstring4);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9757U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_BuyBlackMarketTreasure:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8236U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(9776U);
          break;
        case NoticeReport.Enotice_KickOffTeam:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(9914U);
          if (this.GUIM.IsArabic)
          {
            cstring5.Append(this.SC.Enotice_KickOffTeam.HostName);
            cstring6.Append(this.SC.Enotice_KickOffTeam.AllianceTag);
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
            this.Cstr_Contents_S.StringToFormat(cstring4);
            this.Cstr_Contents_S.StringToFormat(string.Empty);
          }
          else
          {
            this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_KickOffTeam.AllianceTag);
            this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_KickOffTeam.HostName);
          }
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9915U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_AutoDismissWarning:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(9557U);
          this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(9558U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_AutoDismiss:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(9559U);
          this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(9560U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_AMRankPrize:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(1339U);
          this.Cstr_Contents_S.IntToFormat((long) this.SC.Enotice_AMRankPrize.Place);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(1366U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          this.mPrizeType = Detail_Prize.Enotice_AMRankPrize;
          byte prizeNum3 = this.SC.Enotice_AMRankPrize.PrizeNum;
          this.mDiamond = 0U;
          this.mValue = 0U;
          this.mNoValueCount = (byte) 0;
          this.tmplistItem.Clear();
          for (int index = 0; index < (int) prizeNum3; ++index)
          {
            this.bAddList = true;
            ushort itemId = this.SC.Enotice_AMRankPrize.PrizeData[index].ItemID;
            byte num = this.SC.Enotice_AMRankPrize.PrizeData[index].Num;
            this.tmpEQ = this.DM.EquipTable.GetRecordByKey(itemId);
            if (this.tmpEQ.EquipKind == (byte) 11 && this.tmpEQ.PropertiesInfo[0].Propertieskey == (ushort) 6)
            {
              this.bAddList = false;
              this.mDiamond += (uint) this.tmpEQ.PropertiesInfo[1].Propertieskey * (uint) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (uint) num;
              this.mValue += (uint) this.tmpEQ.PropertiesInfo[1].Propertieskey * (uint) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (uint) num;
            }
            else
            {
              this.ShopID = this.DM.TotalShopItemData.Find(itemId);
              if (this.ShopID != (ushort) 0 && this.DM.StoreData.GetRecordByKey(this.ShopID).Price > 0U)
                this.mValue += this.DM.StoreData.GetRecordByKey(this.ShopID).Price * (uint) num;
              else
                this.mNoValueCount += num;
            }
            if (this.bAddList)
              this.tmplistItem.Add((ushort) index);
          }
          break;
        case NoticeReport.Enotice_AllianceHomeKingdom:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(9567U);
          cstring5.Append(this.SC.Enotice_AllianceHomeKingdom.Leader);
          cstring6.Append(this.SC.Enotice_AllianceHomeKingdom.AllianceTag);
          this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          this.Cstr_Contents_S.StringToFormat(cstring4);
          this.Cstr_Contents_S.IntToFormat((long) this.SC.Enotice_AllianceHomeKingdom.HomeKingdom);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9572U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_WorldKingPrize:
          this.mPrizeType = Detail_Prize.Enotice_WorldKingPrize;
          this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11024U));
          this.text_Title.text = this.DM.mStringTable.GetStringByID(11023U);
          this.mStatus = 21;
          byte prizeNum4 = this.SC.Enotice_WorldKingPrize.PrizeNum;
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          this.mDiamond = 0U;
          this.mValue = 0U;
          this.mNoValueCount = (byte) 0;
          this.tmplistItem.Clear();
          for (int index = 0; index < (int) prizeNum4; ++index)
          {
            this.bAddList = true;
            ushort itemId = this.SC.Enotice_WorldKingPrize.PrizeData[index].ItemID;
            byte num = this.SC.Enotice_WorldKingPrize.PrizeData[index].Num;
            this.tmpEQ = this.DM.EquipTable.GetRecordByKey(itemId);
            if (this.tmpEQ.EquipKind == (byte) 11 && this.tmpEQ.PropertiesInfo[0].Propertieskey == (ushort) 6)
            {
              this.bAddList = false;
              this.mDiamond += (uint) this.tmpEQ.PropertiesInfo[1].Propertieskey * (uint) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (uint) num;
              this.mValue += (uint) this.tmpEQ.PropertiesInfo[1].Propertieskey * (uint) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (uint) num;
            }
            else
            {
              this.ShopID = this.DM.TotalShopItemData.Find(itemId);
              if (this.ShopID != (ushort) 0 && this.DM.StoreData.GetRecordByKey(this.ShopID).Price > 0U)
                this.mValue += this.DM.StoreData.GetRecordByKey(this.ShopID).Price * (uint) num;
              else
                this.mNoValueCount += num;
            }
            if (this.bAddList)
              this.tmplistItem.Add((ushort) index);
          }
          break;
        case NoticeReport.Enotice_BackendAddCrystal:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8173U);
          this.Cstr_Contents_S.IntToFormat((long) this.SC.Enotice_BackendAddCrystal.Crystal, bNumber: true);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(8174U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_KOWTelItem:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8472U);
          this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11040U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_LoginConpensate:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8173U);
          this.Cstr_Contents_S.IntToFormat((long) this.SC.Enotice_LoginConpensate.Crystal, bNumber: true);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(11041U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_PurchaseConpensate:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8173U);
          this.Cstr_Contents_S.IntToFormat((long) this.SC.Enotice_PurchaseConpensate.Crystal, bNumber: true);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(11042U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_RallyNPCCancel:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6067U);
          cstring5.Append(this.SC.Enotice_RallyNPCCancel.HostName);
          cstring6.Append(this.SC.Enotice_RallyNPCCancel.AllianceTag);
          this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          cstring3.StringToFormat(cstring4);
          cstring3.StringToFormat(string.Empty);
          cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(5389U));
          cstring4.ClearString();
          cstring5.ClearString();
          cstring6.ClearString();
          cstring4.IntToFormat((long) this.SC.Enotice_RallyNPCCancel.NPCLevel);
          cstring4.AppendFormat(this.DM.mStringTable.GetStringByID(12021U));
          tmpS1.StringToFormat(cstring4);
          tmpS1.StringToFormat(string.Empty);
          tmpS1.AppendFormat(this.DM.mStringTable.GetStringByID(5390U));
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.StringToFormat(cstring3);
          this.Cstr_Contents_S.StringToFormat(tmpS1);
          this.Cstr_Contents_S.AppendFormat("{0}\n{1}");
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_RallyNPCCancelInvalid:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6067U);
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.IntToFormat((long) this.SC.Enotice_RallyNPCCancelInvalid.NPCLevel);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(12024U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_ForceTeleport:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(12053U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(12054U);
          break;
        case NoticeReport.Enotice_LordEquipExpire:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(9665U);
          Equip recordByKey2 = this.DM.EquipTable.GetRecordByKey(this.SC.Enotice_LordEquipExpire.ItemID);
          CString cstring8 = StringManager.Instance.StaticString1024();
          cstring8.ClearString();
          cstring8.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey2.EquipName));
          if (this.SC.Enotice_LordEquipExpire.Rank == (byte) 1)
            cstring8.AppendFormat("<color=#ffffffff>{0}</color>");
          else if (this.SC.Enotice_LordEquipExpire.Rank == (byte) 2)
            cstring8.AppendFormat("<color=#005a2fff>{0}</color>");
          else if (this.SC.Enotice_LordEquipExpire.Rank == (byte) 3)
            cstring8.AppendFormat("<color=#004fa7ff>{0}</color>");
          else if (this.SC.Enotice_LordEquipExpire.Rank == (byte) 4)
            cstring8.AppendFormat("<color=#5a1ca7ff>{0}</color>");
          else if (this.SC.Enotice_LordEquipExpire.Rank == (byte) 5)
            cstring8.AppendFormat("<color=#ffff00ff>{0}</color>");
          this.Cstr_Contents_S.ClearString();
          this.Cstr_Contents_S.StringToFormat(cstring8.ToString());
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9666U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_WorldNotKingPrize:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(11023U);
          this.mPrizeType = Detail_Prize.Enotice_WorldNotKingPrize;
          this.Cstr_Contents_S.ClearString();
          if (this.SC.Enotice_WorldNotKingPrize.Place == (byte) 2)
            this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11051U));
          else if (this.SC.Enotice_WorldNotKingPrize.Place == (byte) 3)
            this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11052U));
          this.mStatus = 21;
          byte prizeNum5 = this.SC.Enotice_WorldNotKingPrize.PrizeNum;
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          this.mDiamond = 0U;
          this.mValue = 0U;
          this.mNoValueCount = (byte) 0;
          this.tmplistItem.Clear();
          for (int index = 0; index < (int) prizeNum5; ++index)
          {
            this.bAddList = true;
            ushort itemId = this.SC.Enotice_WorldNotKingPrize.PrizeData[index].ItemID;
            byte num = this.SC.Enotice_WorldNotKingPrize.PrizeData[index].Num;
            this.tmpEQ = this.DM.EquipTable.GetRecordByKey(itemId);
            if (this.tmpEQ.EquipKind == (byte) 11 && this.tmpEQ.PropertiesInfo[0].Propertieskey == (ushort) 6)
            {
              this.bAddList = false;
              this.mDiamond += (uint) this.tmpEQ.PropertiesInfo[1].Propertieskey * (uint) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (uint) num;
              this.mValue += (uint) this.tmpEQ.PropertiesInfo[1].Propertieskey * (uint) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (uint) num;
            }
            else
            {
              this.ShopID = this.DM.TotalShopItemData.Find(itemId);
              if (this.ShopID != (ushort) 0 && this.DM.StoreData.GetRecordByKey(this.ShopID).Price > 0U)
                this.mValue += this.DM.StoreData.GetRecordByKey(this.ShopID).Price * (uint) num;
              else
                this.mNoValueCount += num;
            }
            if (this.bAddList)
              this.tmplistItem.Add((ushort) index);
          }
          break;
        case NoticeReport.Enotice_BuyEmoteTreasure:
          this.Gifts_T.gameObject.SetActive(true);
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8236U);
          this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey(this.SC.Enotice_BuyEmoteTreasure.ItemID).EquipName));
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(12070U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_LordPoisonEffect:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(15009U);
          this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(15010U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_PrisnerUsePoison:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(15011U);
          cstring5.Append(this.SC.Enotice_PrisnerUsePoison.Name);
          cstring6.Append(this.SC.Enotice_PrisnerUsePoison.AllianceTag);
          if ((int) this.SC.Enotice_PrisnerUsePoison.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, this.SC.Enotice_PrisnerUsePoison.HomeKingdom, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          this.Cstr_Contents_S.StringToFormat(cstring4);
          this.Cstr_Contents_S.IntToFormat((long) (this.SC.Enotice_PrisnerUsePoison.EffectTime / 3600U));
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(15012U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_PrisnerPoisonEffect:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(15011U);
          cstring5.Append(this.SC.Enotice_PrisnerPoisonEffect.Name);
          cstring6.Append(this.SC.Enotice_PrisnerPoisonEffect.AllianceTag);
          if ((int) this.SC.Enotice_PrisnerPoisonEffect.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, this.SC.Enotice_PrisnerPoisonEffect.HomeKingdom, this.GUIM.IsArabic);
          else
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
          this.Cstr_Contents_S.StringToFormat(cstring4);
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(15013U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_BackendActivity:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(11053U);
          this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11054U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_BuyCastleSkinTreasure:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8236U);
          this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.GUIM.BuildingData.castleSkin.CastleSkinTable.GetRecordByKey(this.SC.Enotice_BuyCastleSkinTreasure.CastleSkinID).Name));
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(9685U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_FederalRankPrize:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(11091U);
          this.mPrizeType = Detail_Prize.Enotice_FederalRankPrize;
          this.Cstr_Contents_S.ClearString();
          if (this.SC.Enotice_FederalRankPrize.Place == (byte) 1)
            this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11092U));
          else if (this.SC.Enotice_FederalRankPrize.Place == (byte) 2)
            this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11108U));
          else if (this.SC.Enotice_FederalRankPrize.Place == (byte) 3)
            this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11109U));
          this.mStatus = 21;
          byte prizeNum6 = this.SC.Enotice_FederalRankPrize.PrizeNum;
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          this.mDiamond = 0U;
          this.mValue = 0U;
          this.mNoValueCount = (byte) 0;
          this.tmplistItem.Clear();
          for (int index = 0; index < (int) prizeNum6; ++index)
          {
            this.bAddList = true;
            ushort itemId = this.SC.Enotice_FederalRankPrize.PrizeData[index].ItemID;
            byte num = this.SC.Enotice_FederalRankPrize.PrizeData[index].Num;
            this.tmpEQ = this.DM.EquipTable.GetRecordByKey(itemId);
            if (this.tmpEQ.EquipKind == (byte) 11 && this.tmpEQ.PropertiesInfo[0].Propertieskey == (ushort) 6)
            {
              this.bAddList = false;
              this.mDiamond += (uint) this.tmpEQ.PropertiesInfo[1].Propertieskey * (uint) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (uint) num;
              this.mValue += (uint) this.tmpEQ.PropertiesInfo[1].Propertieskey * (uint) this.tmpEQ.PropertiesInfo[1].PropertiesValue * (uint) num;
            }
            else
            {
              this.ShopID = this.DM.TotalShopItemData.Find(itemId);
              if (this.ShopID != (ushort) 0 && this.DM.StoreData.GetRecordByKey(this.ShopID).Price > 0U)
                this.mValue += this.DM.StoreData.GetRecordByKey(this.ShopID).Price * (uint) num;
              else
                this.mNoValueCount += num;
            }
            if (this.bAddList)
              this.tmplistItem.Add((ushort) index);
          }
          break;
        case NoticeReport.Enotice_FederalTelBack:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(11093U);
          this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(11094U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_RcvGiftRestrict:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(16028U);
          this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(16029U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_CancelRcvGiftRestrict:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(16030U);
          this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID(16031U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_TreasureBackPrize:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8236U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(10077U);
          break;
        case NoticeReport.Enotice_LookingForStringTable:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(this.SC.Enotice_LookingForStringTable.Title);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(this.SC.Enotice_LookingForStringTable.Content);
          break;
        case NoticeReport.Enotice_MarchingPet_Cancel:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(10106U);
          this.Cstr_Contents_S.ClearString();
          if (this.SC.Enotice_MarchingPet_Cancel.HasTarget > (byte) 0)
          {
            cstring5.Append(this.SC.Enotice_MarchingPet_Cancel.Name);
            if (this.SC.Enotice_MarchingPet_Cancel.AllianceTag != string.Empty)
            {
              cstring6.Append(this.SC.Enotice_MarchingPet_Cancel.AllianceTag);
              if ((int) this.SC.Enotice_MarchingPet_Cancel.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
                this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, this.SC.Enotice_MarchingPet_Cancel.HomeKingdom, this.GUIM.IsArabic);
              else
                this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
            }
            else if ((int) this.SC.Enotice_MarchingPet_Cancel.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: this.SC.Enotice_MarchingPet_Cancel.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
          }
          PetTbl recordByKey3 = PetManager.Instance.PetTable.GetRecordByKey(this.SC.Enotice_MarchingPet_Cancel.PetID);
          PetSkillTbl recordByKey4 = PetManager.Instance.PetSkillTable.GetRecordByKey(this.SC.Enotice_MarchingPet_Cancel.Skill_ID);
          cstring5.ClearString();
          cstring5.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey3.Name));
          cstring5.IntToFormat((long) this.SC.Enotice_MarchingPet_Cancel.Skill_LV);
          cstring5.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey4.Name));
          cstring5.AppendFormat(this.DM.mStringTable.GetStringByID(10107U));
          if (this.SC.Enotice_MarchingPet_Cancel.HasTarget > (byte) 0)
            cstring5.Append(cstring4);
          this.Cstr_Contents_S.StringToFormat(cstring5);
          this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID(10099U));
          this.Cstr_Contents_S.AppendFormat("{0}\n{1}");
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.ENotice_PetStarUp:
          PetTbl recordByKey5 = PetManager.Instance.PetTable.GetRecordByKey(this.SC.ENotice_PetStarUp.PetID);
          this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(recordByKey5.HeroID);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(10121U);
          this.SC.ENotice_PetStarUp.PetStar = (byte) Mathf.Clamp((int) this.SC.ENotice_PetStarUp.PetStar, 0, recordByKey5.PetSkill.Length - 1);
          PetSkillTbl recordByKey6 = PetManager.Instance.PetSkillTable.GetRecordByKey(recordByKey5.PetSkill[(int) this.SC.ENotice_PetStarUp.PetStar]);
          this.Cstr_Contents_S.ClearString();
          cstring4.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey5.Name));
          if (this.SC.ENotice_PetStarUp.PetStar == (byte) 1)
            cstring4.StringToFormat(this.DM.mStringTable.GetStringByID(16067U));
          else
            cstring4.StringToFormat(this.DM.mStringTable.GetStringByID(16068U));
          cstring4.AppendFormat(this.DM.mStringTable.GetStringByID(10122U));
          cstring4.Append("\n \n \n");
          if (this.SC.ENotice_PetStarUp.PetStar == (byte) 1)
            cstring5.IntToFormat(50L);
          else
            cstring5.IntToFormat(60L);
          if ((int) this.SC.ENotice_PetStarUp.PetStar < recordByKey5.PetSkill.Length && recordByKey5.PetSkill[(int) this.SC.ENotice_PetStarUp.PetStar] > (ushort) 0)
          {
            cstring5.AppendFormat(this.DM.mStringTable.GetStringByID(10124U));
            ((Component) this.Img_HeroSkill[0]).gameObject.SetActive(true);
            this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(10118U);
            this.text_Skill_1[0].text = this.DM.mStringTable.GetStringByID((uint) recordByKey6.Name);
            this.text_Skill_1[1].text = recordByKey6.Type != (byte) 1 ? (recordByKey6.Type != (byte) 2 ? string.Empty : this.DM.mStringTable.GetStringByID(10091U)) : (recordByKey6.Subject != (byte) 1 ? (recordByKey6.Subject != (byte) 2 ? (recordByKey6.Subject != (byte) 3 ? string.Empty : this.DM.mStringTable.GetStringByID(10085U)) : this.DM.mStringTable.GetStringByID(10084U)) : this.DM.mStringTable.GetStringByID(10083U));
            ((Graphic) this.Img_HeroSkill[0]).rectTransform.anchoredPosition = new Vector2(0.0f, ((Graphic) this.Img_HeroSkill[0]).rectTransform.anchoredPosition.y);
            this.Cstr_SkillIcon[0].ClearString();
            this.Cstr_SkillIcon[0].IntToFormat((long) recordByKey6.Icon, 5);
            this.Cstr_SkillIcon[0].AppendFormat("s{0}");
            this.Img_HeroSkill_1[0].sprite = this.GUIM.LoadSkillSprite(this.Cstr_SkillIcon[0]);
          }
          else
          {
            cstring5.AppendFormat(this.DM.mStringTable.GetStringByID(10123U));
            ((Component) this.Img_HeroSkill[0]).gameObject.SetActive(false);
          }
          this.Cstr_Contents_S.StringToFormat(cstring4);
          this.Cstr_Contents_S.StringToFormat(cstring5);
          this.Cstr_Contents_S.AppendFormat("{0}{1}");
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.ENotice_PrisonerPetSkillEscaped:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6070U);
          this.Cstr_Contents_S.ClearString();
          PetTbl recordByKey7 = PetManager.Instance.PetTable.GetRecordByKey(this.SC.ENotice_PrisonerPetSkillEscaped.PetID);
          PetSkillTbl recordByKey8 = PetManager.Instance.PetSkillTable.GetRecordByKey(this.SC.ENotice_PrisonerPetSkillEscaped.Skill_ID);
          this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey7.Name));
          this.Cstr_Contents_S.IntToFormat((long) this.SC.ENotice_PrisonerPetSkillEscaped.Skill_LV);
          this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey8.Name));
          if (recordByKey8.Type == (byte) 1)
            this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(10114U));
          else
            this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(10116U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.ENotice_LordPetSkillEscaped:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(6070U);
          this.Cstr_Contents_S.ClearString();
          PetTbl recordByKey9 = PetManager.Instance.PetTable.GetRecordByKey(this.SC.ENotice_LordPetSkillEscaped.PetID);
          PetSkillTbl recordByKey10 = PetManager.Instance.PetSkillTable.GetRecordByKey(this.SC.ENotice_LordPetSkillEscaped.Skill_ID);
          this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey9.Name));
          this.Cstr_Contents_S.IntToFormat((long) this.SC.ENotice_LordPetSkillEscaped.Skill_LV);
          this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey10.Name));
          if (recordByKey10.Type == (byte) 1)
            this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(10115U));
          else
            this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(10117U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_FirstUnderPetAttack:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(10101U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(10111U);
          break;
        case NoticeReport.Enotice_ScoutTargetLeave:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(10109U);
          this.Cstr_Contents_S.ClearString();
          if (this.SC.Enotice_ScoutTargetLeave.OffsetLen > 0U)
          {
            cstring5.Append(this.SC.Enotice_ScoutTargetLeave.Name);
            if (this.SC.Enotice_ScoutTargetLeave.AllianceTag != string.Empty)
            {
              cstring6.Append(this.SC.Enotice_ScoutTargetLeave.AllianceTag);
              if ((int) this.SC.Enotice_ScoutTargetLeave.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
                this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, this.SC.Enotice_ScoutTargetLeave.HomeKingdom, this.GUIM.IsArabic);
              else
                this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
            }
            else if ((int) this.SC.Enotice_ScoutTargetLeave.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: this.SC.Enotice_ScoutTargetLeave.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
            cstring5.ClearString();
            cstring5.StringToFormat(cstring4);
            cstring5.AppendFormat(this.DM.mStringTable.GetStringByID(10126U));
          }
          else
            cstring5.Append(this.DM.mStringTable.GetStringByID(10131U));
          this.Cstr_Contents_S.StringToFormat(cstring5);
          this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID(10099U));
          this.Cstr_Contents_S.AppendFormat("{0}\n{1}");
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_AttackTargetLeave:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(10108U);
          this.Cstr_Contents_S.ClearString();
          if (this.SC.Enotice_AttackTargetLeave.OffsetLen > 0U)
          {
            cstring5.Append(this.SC.Enotice_AttackTargetLeave.Name);
            if (this.SC.Enotice_AttackTargetLeave.AllianceTag != string.Empty)
            {
              cstring6.Append(this.SC.Enotice_AttackTargetLeave.AllianceTag);
              if ((int) this.SC.Enotice_AttackTargetLeave.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
                this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, this.SC.Enotice_AttackTargetLeave.HomeKingdom, this.GUIM.IsArabic);
              else
                this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
            }
            else if ((int) this.SC.Enotice_AttackTargetLeave.HomeKingdom != (int) DataManager.MapDataController.kingdomData.kingdomID)
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: this.SC.Enotice_AttackTargetLeave.HomeKingdom, ForceArabic: this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring4, cstring5, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
            cstring5.ClearString();
            cstring5.StringToFormat(cstring4);
            cstring5.AppendFormat(this.DM.mStringTable.GetStringByID(10125U));
          }
          else
            cstring5.Append(this.DM.mStringTable.GetStringByID(10130U));
          this.Cstr_Contents_S.StringToFormat(cstring5);
          this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID(10099U));
          this.Cstr_Contents_S.AppendFormat("{0}\n{1}");
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_MaintainCompensation:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID((uint) this.SC.Enotice_MaintainCompensation.MailTitleStrID);
          this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID((uint) this.SC.Enotice_MaintainCompensation.MailContentStrID));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_BuyRedPocketTreasure:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(8236U);
          this.Cstr_Contents_S.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.SC.Enotice_BuyRedPocketTreasure.StringID));
          this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(11198U));
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_SocialFriendModify:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(12177U);
          ushort ID2 = 12174;
          if (this.SC.Enotice_SocialFriendModify.PlayerName.Length == 0 && this.SC.Enotice_SocialFriendModify.TargetName.Length == 0)
          {
            if (this.SC.Enotice_SocialFriendModify.RemoveType == (byte) 0)
              ID2 = (ushort) 12196;
            else if (this.SC.Enotice_SocialFriendModify.RemoveType == (byte) 1)
              ID2 = (ushort) 12197;
            if (this.SC.Enotice_SocialFriendModify.RemoveType < (byte) 2)
              this.Cstr_Contents_S.Append(this.DM.mStringTable.GetStringByID((uint) ID2));
          }
          else
          {
            if (this.SC.Enotice_SocialFriendModify.RemoveType == (byte) 1)
              ID2 = (ushort) 12175;
            else if (this.SC.Enotice_SocialFriendModify.RemoveType == (byte) 2)
              ID2 = (ushort) 12176;
            else if (this.SC.Enotice_SocialFriendModify.RemoveType == (byte) 3)
              ID2 = (ushort) 12198;
            cstring5.Append(this.SC.Enotice_SocialFriendModify.PlayerName);
            cstring6.Append(this.SC.Enotice_SocialFriendModify.PlayerTag);
            this.GUIM.FormatRoleNameForChat(cstring4, cstring5, cstring6, (ushort) 0, this.GUIM.IsArabic);
            this.Cstr_Contents_S.StringToFormat(this.SC.Enotice_SocialFriendModify.TargetName);
            this.Cstr_Contents_S.StringToFormat(cstring4);
            this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID((uint) ID2));
          }
          this.text_Contents_S.text = this.Cstr_Contents_S.ToString();
          break;
        case NoticeReport.Enotice_ReturnCeremony:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(10175U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(10176U);
          break;
        default:
          this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
          this.text_Title.text = this.DM.mStringTable.GetStringByID(1049U);
          this.text_Contents_S.text = this.DM.mStringTable.GetStringByID(1049U);
          break;
      }
      this.text_Contents_S.SetAllDirty();
      this.text_Contents_S.cachedTextGenerator.Invalidate();
      this.text_Contents_S.cachedTextGeneratorForLayout.Invalidate();
      if (this.SC.Type != NoticeReport.Enotice_WorldNotKingPrize && this.SC.Type != NoticeReport.Enotice_BuyEmoteTreasure)
      {
        if ((double) this.text_Contents_S.preferredHeight > 216.0)
          ((Graphic) this.text_Contents_S).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Contents_S).rectTransform.sizeDelta.x, this.text_Contents_S.preferredHeight + 1f);
        if ((double) this.text_Contents_S.preferredHeight + 18.0 > 425.0)
        {
          ((Behaviour) this.Mask_S_SR).enabled = true;
          this.Content_RT2.sizeDelta = new Vector2(this.Content_RT2.sizeDelta.x, 18f + this.text_Contents_S.preferredHeight);
        }
        else
        {
          ((Behaviour) this.Mask_S_SR).enabled = false;
          this.Content_RT2.sizeDelta = new Vector2(this.Content_RT2.sizeDelta.x, 425f);
        }
      }
      else
      {
        ((Behaviour) this.Mask_S_SR).enabled = false;
        this.text_Contents_S.resizeTextForBestFit = true;
        this.text_Contents_S.resizeTextMaxSize = 20;
        if ((double) this.text_Contents_S.preferredHeight > 100.0)
          ((Graphic) this.text_Contents_S).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Contents_S).rectTransform.sizeDelta.x, 100f);
      }
      this.Img_TitleIcon.sprite = this.SArray.m_Sprites[this.mStatus];
      this.Img_TitleIcon.SetNativeSize();
      this.Img_Hero_S.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
      this.Letter_S_T.gameObject.SetActive(true);
      if (this.MaxLetterNum > 1)
      {
        if ((int) this.SC.Index + 1 == 1)
        {
          ((Component) this.btn_Previous).gameObject.SetActive(false);
          if (!((UIBehaviour) this.btn_Next).IsActive())
            ((Component) this.btn_Next).gameObject.SetActive(true);
        }
        if ((int) this.SC.Index + 1 == this.MaxLetterNum)
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
    }
    else if (this.mLetterKind == 2)
    {
      this.text_Title.text = this.DM.mStringTable.GetStringByID(8217U);
      this.text_Time[0].text = GameConstants.GetDateTime(this.CR.Times).ToString("MM/dd/yy");
      this.text_Time[1].text = GameConstants.GetDateTime(this.CR.Times).ToString("HH:mm:ss");
      this.tmpHero = this.DM.HeroTable.GetRecordByKey((ushort) 101);
      this.Img_Hero_S.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
      this.text_Contents_S.text = this.CR.Monster.Result >= (byte) 3 ? this.DM.mStringTable.GetStringByID(8219U) : this.DM.mStringTable.GetStringByID(8220U);
      this.text_Contents_S.SetAllDirty();
      this.text_Contents_S.cachedTextGenerator.Invalidate();
      ((Component) this.text_Name).gameObject.SetActive(false);
      this.MonsterXY_T.gameObject.SetActive(true);
      ((Component) this.btn_MonsterXY).gameObject.SetActive(true);
      this.Cstr_Name.ClearString();
      this.Cstr_Contents_S.ClearString();
      this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.CR.Monster.Zone, this.CR.Monster.Point));
      this.Cstr_Contents_S.IntToFormat((long) this.CR.Monster.KindgomID);
      this.Cstr_Contents_S.IntToFormat((long) (int) this.tmpV.x);
      this.Cstr_Contents_S.IntToFormat((long) (int) this.tmpV.y);
      if (this.GUIM.IsArabic)
        this.Cstr_Contents_S.AppendFormat("{0}:K {1}:X {2}:Y");
      else
        this.Cstr_Contents_S.AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
      this.Cstr_Name.StringToFormat(this.Cstr_Contents_S);
      this.Cstr_Name.AppendFormat(this.DM.mStringTable.GetStringByID(8218U));
      this.text_MonsterXY.text = this.Cstr_Name.ToString();
      this.text_MonsterXY.SetAllDirty();
      this.text_MonsterXY.cachedTextGenerator.Invalidate();
      this.text_MonsterXY.cachedTextGeneratorForLayout.Invalidate();
      this.tmpRC = ((Component) this.btn_MonsterXY).transform.GetComponent<RectTransform>();
      this.tmpRC.sizeDelta = new Vector2(this.text_MonsterXY.preferredWidth, this.tmpRC.sizeDelta.y);
      this.tmpRC = ((Component) this.btn_MonsterXY).transform.GetChild(0).GetComponent<RectTransform>();
      this.tmpRC.sizeDelta = new Vector2(this.text_MonsterXY.preferredWidth, this.tmpRC.sizeDelta.y);
      this.tmpRC = ((Component) this.btn_MonsterXY).transform.GetChild(1).GetComponent<RectTransform>();
      this.tmpRC.sizeDelta = new Vector2(this.text_MonsterXY.preferredWidth, this.tmpRC.sizeDelta.y);
      this.Letter_S_T.gameObject.SetActive(true);
      this.MaxLetterNum = (int) this.DM.GetMailboxSize();
      this.tmpPageNum = (int) this.CR.Index + 1;
      if (this.MaxLetterNum > 1)
      {
        if ((int) this.CR.Index + 1 == 1)
        {
          ((Component) this.btn_Previous).gameObject.SetActive(false);
          if (!((UIBehaviour) this.btn_Next).IsActive())
            ((Component) this.btn_Next).gameObject.SetActive(true);
        }
        if ((int) this.CR.Index + 1 == this.MaxLetterNum)
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
    }
    this.UpdateBaseline();
  }

  public override void OnClose()
  {
    if (this.Cstr_Name != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Name);
    if (this.Cstr_Page != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Page);
    if (this.Cstr_Skill != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Skill);
    if (this.Cstr_Title != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Title);
    if (this.Cstr_Contents_S != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Contents_S);
    if (this.Cstr_S_Title != null)
      StringManager.Instance.DeSpawnString(this.Cstr_S_Title);
    if (this.Cstr_LordEquip_Lv != null)
      StringManager.Instance.DeSpawnString(this.Cstr_LordEquip_Lv);
    if (this.Cstr_Translation != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Translation);
    for (int index = 0; index < 2; ++index)
    {
      if (this.Cstr_Time[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Time[index]);
      if (this.Cstr_SkillIcon[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_SkillIcon[index]);
      if (this.Cstr_LordEquip[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_LordEquip[index]);
      if (this.Cstr_Gifts[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Gifts[index]);
    }
    for (int index = 0; index < 3; ++index)
    {
      if (this.Cstr_S_Top[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_S_Top[index]);
    }
    for (int index = 0; index < 4; ++index)
    {
      if (this.Cstr_StarUpValue[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_StarUpValue[index]);
    }
    for (int index1 = 0; index1 < 6; ++index1)
    {
      for (int index2 = 0; index2 < 5; ++index2)
      {
        if (this.Cstr_S_ItemNum[index1] != null && this.Cstr_S_ItemNum[index1][index2] != null)
          StringManager.Instance.DeSpawnString(this.Cstr_S_ItemNum[index1][index2]);
      }
      for (int index3 = 0; index3 < 2; ++index3)
      {
        if (this.Cstr_LordEquip_Effect[index1] != null && this.Cstr_LordEquip_Effect[index1][index3] != null)
          StringManager.Instance.DeSpawnString(this.Cstr_LordEquip_Effect[index1][index3]);
      }
    }
    for (int index = 0; index < 6; ++index)
    {
      if (this.Cstr_BookMarkList2[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_BookMarkList2[index]);
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 1:
        this.Open_NP_Mail(false);
        break;
      case 2:
        this.Open_NP_Mail(true);
        break;
      case 3:
        this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(6038U), this.DM.mStringTable.GetStringByID(6039U), 1, YesText: this.DM.mStringTable.GetStringByID(6036U), NoText: this.DM.mStringTable.GetStringByID(6037U));
        break;
      case 5:
        if (this.Favor.Kind == MailType.EMAIL_FAVORY)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6100U), (ushort) byte.MaxValue);
          break;
        }
        this.DM.MailReportSave(this.MC.SerialID);
        break;
      case 6:
        CString PlayerName = StringManager.Instance.StaticString1024();
        PlayerName.ClearString();
        PlayerName.Append(this.text_Name.text);
        if (this.DM.FindBlackList(PlayerName))
        {
          PlayerName.ClearString();
          PlayerName.StringToFormat(this.text_Name.text);
          PlayerName.AppendFormat(this.DM.mStringTable.GetStringByID(5382U));
          this.GUIM.AddHUDMessage(PlayerName.ToString(), (ushort) byte.MaxValue);
          break;
        }
        this.DM.Letter_ReplyName = this.MC.SenderName;
        this.DM.Letter_ReplyTitle = this.MC.Title;
        this.DM.Letter_ReplyName_KTN.Length = 0;
        this.DM.Letter_ReplyName_KTN.Append(this.MC.SenderName);
        int num = 0;
        if (this.MC.MailType == (byte) 1)
        {
          this.DM.Letter_ReplyTitle_Alliance.Length = 0;
          this.DM.Letter_ReplyTitle_Alliance.Append(this.text_Title.text);
          num = 1;
        }
        else
        {
          this.DM.Letter_ReplyTitle_Alliance.Length = 0;
          this.DM.Letter_ReplyTitle_Alliance.Append(this.MC.Title);
        }
        this.DM.Letter_ReplyID = this.MC.ReplyID != 0U ? this.MC.ReplyID : this.MC.SerialID;
        this.door.CloseMenu();
        this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 1, num);
        break;
      case 8:
        this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(6038U), this.DM.mStringTable.GetStringByID(6039U), 2, YesText: this.DM.mStringTable.GetStringByID(6036U), NoText: this.DM.mStringTable.GetStringByID(6037U));
        break;
      case 9:
        if (this.Favor.Kind == MailType.EMAIL_FAVORY)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6100U), (ushort) byte.MaxValue);
          break;
        }
        if (this.mLetterKind != 2)
        {
          this.DM.SystemReportSave(this.SC.SerialID);
          break;
        }
        this.DM.BattleReportSave(this.CR.SerialID);
        break;
      case 10:
        this.DM.AllianceView.Id = this.SC.Notice_InviteAlliance.AllianceID;
        this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5);
        for (int index = this.door.m_WindowStack.Count - 1; index >= 0; --index)
        {
          if (this.door.m_WindowStack[index].m_eWindow == EGUIWindow.UI_LetterDetail || this.door.m_WindowStack[index].m_eWindow == EGUIWindow.UI_Letter)
            this.door.m_WindowStack.RemoveAt(index);
        }
        break;
      case 14:
        this.door.GoToPointCode(this.CR.Monster.KindgomID, this.CR.Monster.Zone, this.CR.Monster.Point, (byte) 0);
        break;
      case 15:
        ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST();
        break;
      case 17:
        if (this.MC.Translation && this.bTrans && this.DM.CheckLanguageTranslateByIdx((int) this.MC.LanguageSource) && (GameLanguage) this.MC.LanguageTarget == this.DM.UserLanguage)
        {
          this.bTransBtnStatus = !this.bTransBtnStatus;
          if (this.mLetterKind != 0 || this.MC.MailType == (byte) 2)
            break;
          if (this.bTransBtnStatus)
          {
            this.Cstr_Translation.ClearString();
            this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID(this.MC.LanguageSource));
            this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054U));
            this.text_Translation.text = this.Cstr_Translation.ToString();
          }
          else
            this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052U);
          this.text_Translation.SetAllDirty();
          this.text_Translation.cachedTextGenerator.Invalidate();
          this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
          if ((double) this.text_Translation.preferredWidth > (double) ((Graphic) this.text_Translation).rectTransform.sizeDelta.x)
            ((Graphic) this.text_Translation).rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, ((Graphic) this.text_Translation).rectTransform.sizeDelta.y);
          if (this.GUIM.IsArabic)
            this.text_Translation.UpdateArabicPos();
          if (this.MC.MailType == (byte) 1)
          {
            this.Cstr_Title.ClearString();
            this.Cstr_Title.StringToFormat(this.DM.mStringTable.GetStringByID(6014U));
            if (this.bTransBtnStatus && this.GUIM.CheckNeedTranslate(this.MC.Title))
              this.Cstr_Title.StringToFormat(this.MC.TitleT);
            else
              this.Cstr_Title.StringToFormat(this.MC.Title);
            this.Cstr_Title.AppendFormat("{0}{1}");
            this.text_Title.text = this.Cstr_Title.ToString();
          }
          else
            this.text_Title.text = this.MC.MailType != (byte) 3 ? (!this.bTransBtnStatus || !this.GUIM.CheckNeedTranslate(this.MC.Title) ? this.MC.Title : this.MC.TitleT) : this.DM.mStringTable.GetStringByID(1474U);
          this.text_Title.SetAllDirty();
          this.text_Title.cachedTextGenerator.Invalidate();
          this.text_Contents.text = !this.bTransBtnStatus ? this.MC.Content : this.MC.ContentT;
          this.text_Contents.SetAllDirty();
          this.text_Contents.cachedTextGeneratorForLayout.Invalidate();
          this.text_Contents.cachedTextGenerator.Invalidate();
          if ((double) this.text_Contents.preferredHeight > 158.0)
          {
            ((Graphic) this.text_Contents).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Contents).rectTransform.sizeDelta.x, this.text_Contents.preferredHeight + 1f);
            this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, (float) (-193.0 - ((double) this.text_Contents.preferredHeight + 1.0 - 158.0) - 33.0));
            ((Graphic) this.text_Translation).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_Translation).rectTransform.anchoredPosition.x, (float) (-179.0 - ((double) this.text_Contents.preferredHeight + 1.0 - 158.0) - 33.0));
          }
          if ((double) this.text_Contents.preferredHeight + 18.0 + 84.0 > 425.0)
          {
            this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 102f + this.text_Contents.preferredHeight);
            break;
          }
          this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 425f);
          break;
        }
        if (this.DM.MailTranslate(this.Favor.Serial, this.Favor.Kind))
        {
          ((Component) this.Img_Translate).gameObject.SetActive(true);
          ((Component) this.btn_Translation).gameObject.SetActive(false);
          ((Component) this.text_Translation).gameObject.SetActive(false);
          break;
        }
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8459U), (ushort) byte.MaxValue);
        break;
      case 18:
        if (this.MC == null || this.MC.SenderName == null || !(this.MC.SenderName != string.Empty))
          break;
        if (this.MC.MailType == (byte) 4 && sender.m_BtnID2 == 2)
        {
          DataManager.Instance.ShowLordProfile(this.DM.RoleAttr.Name.ToString());
          break;
        }
        DataManager.Instance.ShowLordProfile(this.MC.SenderName);
        break;
      case 19:
        if (this.DM.RoleAlliance.Id == 0U)
        {
          DataManager.Instance.SetSelectRequest = 0;
          this.door.OpenMenu(EGUIWindow.UI_AllianceHint, 11);
          break;
        }
        this.GUIM.MsgStr.ClearString();
        this.GUIM.MsgStr.StringToFormat(this.DM.RoleAlliance.Name);
        this.GUIM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(598U));
        this.GUIM.AddHUDMessage(this.GUIM.MsgStr.ToString(), (ushort) byte.MaxValue);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    switch (button.m_BtnID1)
    {
      case 11:
        if (this.SC.Type == NoticeReport.ENotice_Enhance)
        {
          this.GUIM.m_SkillInfo.Show(sender, (uint) this.SC.NoticeHeroEnhance.HeroID, (byte) ((int) this.SC.NoticeHeroEnhance.Rank / 2 + 4), (ushort) 0, (ushort) 0);
          break;
        }
        if (this.SC.Type != NoticeReport.ENotice_PetStarUp)
          break;
        PetTbl recordByKey = PetManager.Instance.PetTable.GetRecordByKey(this.SC.ENotice_PetStarUp.PetID);
        this.SC.ENotice_PetStarUp.PetStar = (byte) Mathf.Clamp((int) this.SC.ENotice_PetStarUp.PetStar, 0, recordByKey.PetSkill.Length - 1);
        PetManager.Instance.PetSkillTable.GetRecordByKey(recordByKey.PetSkill[(int) this.SC.ENotice_PetStarUp.PetStar]);
        this.SC.ENotice_PetStarUp.PetStar = (byte) Mathf.Clamp((int) this.SC.ENotice_PetStarUp.PetStar, 0, recordByKey.PetSkill.Length - 1);
        this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Normal, (ushort) 0, recordByKey.PetSkill[(int) this.SC.ENotice_PetStarUp.PetStar], (byte) 1, Vector2.zero);
        break;
      case 12:
        CalcAttrDataType CalcAttrData = new CalcAttrDataType();
        byte[] numArray = new byte[4];
        CurHeroData curHeroData1 = this.DM.curHeroData[(uint) this.SC.NoticeHeroEnhance.HeroID];
        CalcAttrData.SkillLV1 = curHeroData1.SkillLV[0];
        CalcAttrData.SkillLV2 = curHeroData1.SkillLV[1];
        CalcAttrData.SkillLV3 = curHeroData1.SkillLV[2];
        CalcAttrData.SkillLV4 = curHeroData1.SkillLV[3];
        for (int index = 0; index < 4; ++index)
          numArray[index] = curHeroData1.SkillLV[index];
        CalcAttrData.LV = curHeroData1.Level;
        CalcAttrData.Star = curHeroData1.Star;
        CalcAttrData.Enhance = curHeroData1.Enhance;
        CalcAttrData.Equip = curHeroData1.Equip;
        uint HP = 0;
        ushort[] pAttr = new ushort[28];
        BSInvokeUtil getInstance = BSInvokeUtil.getInstance;
        Array.Clear((Array) pAttr, 0, pAttr.Length);
        getInstance.setCalculateAttribute(curHeroData1.ID, ref CalcAttrData, ref HP, pAttr);
        this.mSkill = this.DM.SkillTable.GetRecordByKey(this.tmpHero.AttackPower[(int) this.SC.NoticeHeroEnhance.Rank / 2 + 1]);
        ushort HeroAttrValA = GameConstants.SetHintValue(pAttr, this.mSkill.HurtKind, true);
        ushort HeroAttrValB = GameConstants.SetHintValue(pAttr, this.mSkill.HurtKind, false);
        CurHeroData curHeroData2 = this.DM.curHeroData.Find((uint) this.SC.NoticeHeroEnhance.HeroID);
        if (!this.DM.curHeroData.ContainsKey((uint) curHeroData2.ID))
          break;
        this.GUIM.m_SkillInfo.Show(sender, (uint) curHeroData2.ID, (byte) ((uint) this.SC.NoticeHeroEnhance.Rank / 2U), HeroAttrValA, HeroAttrValB);
        break;
      case 16:
        this.GUIM.m_SkillInfo.Show(sender, (uint) this.SC.NoticeHeroStarUp.HeroID, (byte) (button.m_BtnID2 + 4), (ushort) 0, (ushort) 0);
        break;
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    switch ((sender.m_Button as UIButton).m_BtnID1)
    {
      case 11:
      case 12:
      case 16:
        this.GUIM.m_SkillInfo.Hide(sender);
        break;
    }
    this.GUIM.m_Hint.Hide(true);
  }

  public void OnHIButtonClick(UIHIBtn sender) => this.MM.OpenDetail(sender.HIID);

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelId == 1)
    {
      if ((UnityEngine.Object) this.ItemT[panelObjectIdx] == (UnityEngine.Object) null)
      {
        this.ItemT[panelObjectIdx] = item.GetComponent<Transform>();
        this.mScrollItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
        this.Item_P1[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(0);
        this.Item_P2[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(1);
        for (int index = 0; index < 5; ++index)
        {
          this.Hbtn_Item[panelObjectIdx][index] = this.ItemT[panelObjectIdx].GetChild(1).GetChild(index).GetComponent<UIHIBtn>();
          this.Hbtn_Item[panelObjectIdx][index].m_Handler = (IUIHIBtnClickHandler) this;
          this.Lebtn_Item[panelObjectIdx][index] = this.ItemT[panelObjectIdx].GetChild(1).GetChild(index + 5).GetComponent<UILEBtn>();
          this.Lebtn_Item[panelObjectIdx][index].m_Handler = (IUILEBtnClickHandler) this;
          this.text_S_ItemNum[panelObjectIdx][index] = this.ItemT[panelObjectIdx].GetChild(1).GetChild(index + 10).GetComponent<UIText>();
        }
        this.Item_P3[panelObjectIdx] = this.ItemT[panelObjectIdx].GetChild(2);
        this.ItemT[panelObjectIdx].GetChild(2).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      }
      if (dataIdx == 0)
      {
        this.Item_P1[panelObjectIdx].gameObject.SetActive(true);
        this.Item_P2[panelObjectIdx].gameObject.SetActive(false);
        this.Item_P3[panelObjectIdx].gameObject.SetActive(false);
      }
      else if (dataIdx < (this.tmplistItem.Count - 1) / 5 + 2)
      {
        this.Item_P1[panelObjectIdx].gameObject.SetActive(false);
        this.Item_P2[panelObjectIdx].gameObject.SetActive(true);
        this.Item_P3[panelObjectIdx].gameObject.SetActive(false);
        this.mScrollItem[panelObjectIdx].m_BtnID2 = 1;
        ushort num1 = 0;
        byte num2 = 0;
        byte x = 0;
        for (int index = 0; index < this.tmplistItem.Count - (dataIdx - 1) * 5 && index < 5 && this.tmplistItem.Count >= (dataIdx - 1) * 5 + index; ++index)
        {
          this.Cstr_S_ItemNum[panelObjectIdx][index].ClearString();
          switch (this.mPrizeType)
          {
            case Detail_Prize.Enotice_ActivityDegreePrize:
              num1 = this.SC.Notice_ActivityDegreePrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].ItemID;
              num2 = this.SC.Notice_ActivityDegreePrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Rank;
              x = this.SC.Notice_ActivityDegreePrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Num;
              break;
            case Detail_Prize.Enotice_ActivityRankPrize:
              num1 = this.SC.Notice_ActivityRankPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].ItemID;
              num2 = this.SC.Notice_ActivityRankPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Rank;
              x = this.SC.Notice_ActivityRankPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Num;
              break;
            case Detail_Prize.Enotice_ActivityKVKDegreePrize:
              num1 = this.SC.Enotice_ActivityKVKDegreePrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].ItemID;
              num2 = this.SC.Enotice_ActivityKVKDegreePrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Rank;
              x = this.SC.Enotice_ActivityKVKDegreePrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Num;
              break;
            case Detail_Prize.Enotice_ActivityKVKRankPrize:
              num1 = this.SC.Enotice_ActivityKVKRankPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].ItemID;
              num2 = this.SC.Enotice_ActivityKVKRankPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Rank;
              x = this.SC.Enotice_ActivityKVKRankPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Num;
              break;
            case Detail_Prize.Enotice_AMRankPrize:
              num1 = this.SC.Enotice_AMRankPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].ItemID;
              num2 = this.SC.Enotice_AMRankPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Rank;
              x = this.SC.Enotice_AMRankPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Num;
              break;
            case Detail_Prize.Enotice_WorldKingPrize:
              num1 = this.SC.Enotice_WorldKingPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].ItemID;
              num2 = this.SC.Enotice_WorldKingPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Rank;
              x = this.SC.Enotice_WorldKingPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Num;
              break;
            case Detail_Prize.Enotice_WorldNotKingPrize:
              num1 = this.SC.Enotice_WorldNotKingPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].ItemID;
              num2 = this.SC.Enotice_WorldNotKingPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Rank;
              x = this.SC.Enotice_WorldNotKingPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Num;
              break;
            case Detail_Prize.Enotice_FederalRankPrize:
              num1 = this.SC.Enotice_FederalRankPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].ItemID;
              num2 = this.SC.Enotice_FederalRankPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Rank;
              x = this.SC.Enotice_FederalRankPrize.PrizeData[(int) this.tmplistItem[(dataIdx - 1) * 5 + index]].Num;
              break;
          }
          bool flag = this.GUIM.IsLeadItem(DataManager.Instance.EquipTable.GetRecordByKey(num1).EquipKind);
          if (flag)
          {
            this.GUIM.ChangeLordEquipImg(((Component) this.Lebtn_Item[panelObjectIdx][index]).transform, num1, num2, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
          }
          else
          {
            if (this.MM.CheckCanOpenDetail(num1))
              ((Component) this.Hbtn_Item[panelObjectIdx][index]).transform.GetComponent<UIButtonHint>().enabled = false;
            else
              ((Component) this.Hbtn_Item[panelObjectIdx][index]).transform.GetComponent<UIButtonHint>().enabled = true;
            this.GUIM.ChangeHeroItemImg(((Component) this.Hbtn_Item[panelObjectIdx][index]).transform, eHeroOrItem.Item, num1, (byte) 0, num2);
          }
          ((Component) this.Lebtn_Item[panelObjectIdx][index]).gameObject.SetActive(flag);
          ((Component) this.Hbtn_Item[panelObjectIdx][index]).gameObject.SetActive(!flag);
          this.Cstr_S_ItemNum[panelObjectIdx][index].IntToFormat((long) x, bNumber: true);
          if (x > (byte) 1)
            ((Component) this.text_S_ItemNum[panelObjectIdx][index]).gameObject.SetActive(true);
          else
            ((Component) this.text_S_ItemNum[panelObjectIdx][index]).gameObject.SetActive(false);
          if (this.GUIM.IsArabic)
            this.Cstr_S_ItemNum[panelObjectIdx][index].AppendFormat("{0}x");
          else
            this.Cstr_S_ItemNum[panelObjectIdx][index].AppendFormat("x{0}");
          this.text_S_ItemNum[panelObjectIdx][index].text = this.Cstr_S_ItemNum[panelObjectIdx][index].ToString();
          this.text_S_ItemNum[panelObjectIdx][index].SetAllDirty();
          this.text_S_ItemNum[panelObjectIdx][index].cachedTextGenerator.Invalidate();
          ((Component) this.Hbtn_Item[panelObjectIdx][index]).gameObject.SetActive(true);
        }
        for (int index = this.tmplistItem.Count - (dataIdx - 1) * 5; index < 5; ++index)
        {
          ((Component) this.Hbtn_Item[panelObjectIdx][index]).gameObject.SetActive(false);
          ((Component) this.text_S_ItemNum[panelObjectIdx][index]).gameObject.SetActive(false);
        }
      }
      else
      {
        this.Item_P1[panelObjectIdx].gameObject.SetActive(false);
        this.Item_P2[panelObjectIdx].gameObject.SetActive(false);
        if (this.mPrizeType == Detail_Prize.Enotice_WorldKingPrize || this.mPrizeType == Detail_Prize.Enotice_WorldNotKingPrize || this.mPrizeType == Detail_Prize.Enotice_FederalRankPrize)
          return;
        this.Item_P3[panelObjectIdx].gameObject.SetActive(true);
      }
    }
    else
    {
      if (panelObjectIdx >= 7)
        return;
      if (!this.bFindScrollComp[panelObjectIdx])
      {
        this.bFindScrollComp[panelObjectIdx] = true;
        this.ScrollComp[panelObjectIdx].CrystalImg = item.transform.GetChild(1).GetComponent<Image>();
        this.ScrollComp[panelObjectIdx].HIBtn = item.transform.GetChild(2).GetComponent<UIHIBtn>();
        this.ScrollComp[panelObjectIdx].HIBtn.m_Handler = (IUIHIBtnClickHandler) this;
        this.ScrollComp[panelObjectIdx].Hint = item.transform.GetChild(2).GetComponent<UIButtonHint>();
        this.ScrollComp[panelObjectIdx].LEBtn = item.transform.GetChild(3).GetComponent<UILEBtn>();
        this.ScrollComp[panelObjectIdx].LEBtn.m_Handler = (IUILEBtnClickHandler) this;
        this.ScrollComp[panelObjectIdx].ItemName = item.transform.GetChild(4).GetComponent<UIText>();
        this.ScrollComp[panelObjectIdx].ItemCountText = item.transform.GetChild(5).GetComponent<UIText>();
        if (this.GUIM.IsArabic)
          this.ScrollComp[panelObjectIdx].ItemCountText.AdjuestUI();
        this.CountStr[panelObjectIdx] = StringManager.Instance.SpawnString();
        this.NameStr[panelObjectIdx] = StringManager.Instance.SpawnString(150);
        if (panelObjectIdx == 0)
          this.BuyIconRT = item.transform.GetChild(1).GetComponent<RectTransform>();
      }
      if (dataIdx < 0 || dataIdx > (int) this.ItemCount)
        return;
      ushort num3 = 1;
      uint x = 1;
      byte color = 0;
      int num4 = 0;
      if (this.SC.Type == NoticeReport.Enotice_BuyTreasure || this.SC.Type == NoticeReport.Enotice_BuyBlackMarketTreasure || this.SC.Type == NoticeReport.Enotice_TreasureBackPrize)
      {
        NoticeContent.BuyTreasure buyTreasure = new NoticeContent.BuyTreasure();
        if (this.SC.Type == NoticeReport.Enotice_BuyTreasure)
          buyTreasure = this.SC.Notice_BuyTreasure;
        else if (this.SC.Type == NoticeReport.Enotice_BuyBlackMarketTreasure)
          buyTreasure = this.SC.Enotice_BuyBlackMarketTreasure;
        else if (this.SC.Type == NoticeReport.Enotice_TreasureBackPrize)
          buyTreasure = this.SC.Enotice_TreasureBackPrize;
        num4 = buyTreasure.BonusCrystal <= 0U ? 0 : 1;
        int index1 = dataIdx - (1 + num4);
        if (this.SC.Type == NoticeReport.Enotice_BuyBlackMarketTreasure || this.SC.Type == NoticeReport.Enotice_TreasureBackPrize)
          index1 = dataIdx;
        if (panelObjectIdx == 0)
        {
          if (dataIdx == 0 && buyTreasure.Crystal > 0U)
          {
            this.BuyIconRT.anchoredPosition = new Vector2(258f, this.BuyIconRT.anchoredPosition.y);
            this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleCenter;
            this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
            ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = new Color(1f, 0.9333f, 0.6196f);
          }
          else
          {
            this.BuyIconRT.anchoredPosition = new Vector2(29f, this.BuyIconRT.anchoredPosition.y);
            if (this.GUIM.IsArabic)
              this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleLeft;
            else
              this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleRight;
            this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 26;
            ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = new Color(1f, 1f, 1f);
          }
        }
        if (dataIdx == 0 && buyTreasure.Crystal > 0U)
        {
          num3 = (ushort) 1001;
          x = buyTreasure.Crystal;
          this.ScrollComp[panelObjectIdx].ItemName.text = string.Empty;
          ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = true;
          ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(false);
          ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(false);
        }
        else if (this.SC.Type == NoticeReport.Enotice_BuyTreasure && buyTreasure.ItemNum > (byte) 0 && buyTreasure.GiftTop == (byte) 1)
        {
          if (buyTreasure.BonusCrystal > 0U && dataIdx == 1)
          {
            num3 = (ushort) 1001;
            x = buyTreasure.BonusCrystal;
            ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = true;
            ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(false);
            ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(false);
            this.ScrollComp[panelObjectIdx].ItemName.fontSize = 28;
            ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = new Color(1f, 0.9333f, 0.6196f);
            ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = new Color(1f, 1f, 1f);
          }
          else if (dataIdx <= num4 + (int) this.GiftTopCount)
          {
            if (index1 >= 0 && index1 < buyTreasure.Gift.Length)
            {
              num3 = buyTreasure.Gift[index1].ItemID;
              x = (uint) buyTreasure.Gift[index1].ItemNum;
            }
            color = (byte) 0;
            ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = false;
            this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
            ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = new Color(1f, 1f, 1f);
          }
          else
          {
            int index2 = index1 - (int) this.GiftTopCount;
            if (index2 >= 0 && index2 < buyTreasure.Item.Length)
            {
              num3 = buyTreasure.Item[index2].ItemID;
              x = (uint) buyTreasure.Item[index2].ItemNum;
              color = buyTreasure.Item[index2].ItemRank;
            }
            ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = false;
            this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
            ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = new Color(1f, 1f, 1f);
          }
        }
        else if (buyTreasure.BonusCrystal > 0U && dataIdx == 1)
        {
          num3 = (ushort) 1001;
          x = buyTreasure.BonusCrystal;
          ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = true;
          ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(false);
          ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(false);
          this.ScrollComp[panelObjectIdx].ItemName.fontSize = 28;
          ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = new Color(1f, 0.9333f, 0.6196f);
          ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = new Color(1f, 1f, 1f);
        }
        else if (dataIdx <= num4 + buyTreasure.Item.Length)
        {
          if (index1 >= 0 && index1 < buyTreasure.Item.Length)
          {
            num3 = buyTreasure.Item[index1].ItemID;
            x = (uint) buyTreasure.Item[index1].ItemNum;
            color = buyTreasure.Item[index1].ItemRank;
          }
          ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = false;
          this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
          ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = new Color(1f, 1f, 1f);
        }
        else
        {
          int index3 = index1 - buyTreasure.Item.Length;
          if (index3 >= 0 && index3 < buyTreasure.Gift.Length)
          {
            num3 = buyTreasure.Gift[index3].ItemID;
            x = (uint) buyTreasure.Gift[index3].ItemNum;
          }
          color = (byte) 0;
          ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = false;
          this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
          ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = new Color(1f, 1f, 1f);
        }
      }
      else if (this.SC.Type == NoticeReport.Enotice_BackendActivity)
      {
        NoticeContent.BackendActivity backendActivity = new NoticeContent.BackendActivity();
        NoticeContent.BackendActivity enoticeBackendActivity = this.SC.Enotice_BackendActivity;
        if (enoticeBackendActivity.Crystal > 0U)
          num4 = 1;
        int index = dataIdx - num4;
        if (panelObjectIdx == 0)
        {
          if (dataIdx == 0 && enoticeBackendActivity.Crystal > 0U)
          {
            this.BuyIconRT.anchoredPosition = new Vector2(258f, this.BuyIconRT.anchoredPosition.y);
            this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleCenter;
            this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
            ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = new Color(1f, 0.9333f, 0.6196f);
          }
          else
          {
            this.BuyIconRT.anchoredPosition = new Vector2(29f, this.BuyIconRT.anchoredPosition.y);
            if (this.GUIM.IsArabic)
              this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleLeft;
            else
              this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleRight;
            this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 26;
            ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = new Color(1f, 1f, 1f);
          }
        }
        if (dataIdx == 0 && enoticeBackendActivity.Crystal > 0U)
        {
          num3 = (ushort) 1001;
          x = enoticeBackendActivity.Crystal;
          this.ScrollComp[panelObjectIdx].ItemName.text = string.Empty;
          ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = true;
          ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(false);
          ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(false);
        }
        else if (dataIdx < num4 + enoticeBackendActivity.Item.Length)
        {
          if (index >= 0 && index < enoticeBackendActivity.Item.Length)
          {
            num3 = enoticeBackendActivity.Item[index].ItemID;
            x = (uint) enoticeBackendActivity.Item[index].ItemNum;
            color = enoticeBackendActivity.Item[index].ItemRank;
          }
          ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = false;
          this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
          ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = new Color(1f, 1f, 1f);
        }
      }
      else if (this.SC.Type == NoticeReport.Enotice_MaintainCompensation)
      {
        NoticeContent.MaintainCompensation maintainCompensation1 = new NoticeContent.MaintainCompensation();
        NoticeContent.MaintainCompensation maintainCompensation2 = this.SC.Enotice_MaintainCompensation;
        if (maintainCompensation2.Crystal > 0U)
          num4 = 1;
        int index = dataIdx - num4;
        if (panelObjectIdx == 0)
        {
          if (dataIdx == 0 && maintainCompensation2.Crystal > 0U)
          {
            this.BuyIconRT.anchoredPosition = new Vector2(258f, this.BuyIconRT.anchoredPosition.y);
            this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleCenter;
            this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
            ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = new Color(1f, 0.9333f, 0.6196f);
          }
          else
          {
            this.BuyIconRT.anchoredPosition = new Vector2(29f, this.BuyIconRT.anchoredPosition.y);
            if (this.GUIM.IsArabic)
              this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleLeft;
            else
              this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleRight;
            this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 26;
            ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = new Color(1f, 1f, 1f);
          }
        }
        if (dataIdx == 0 && maintainCompensation2.Crystal > 0U)
        {
          num3 = (ushort) 1001;
          x = maintainCompensation2.Crystal;
          this.ScrollComp[panelObjectIdx].ItemName.text = string.Empty;
          ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = true;
          ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(false);
          ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(false);
        }
        else if (dataIdx < num4 + maintainCompensation2.Item.Length)
        {
          if (index >= 0 && index < maintainCompensation2.Item.Length)
          {
            num3 = maintainCompensation2.Item[index].ItemID;
            x = (uint) maintainCompensation2.Item[index].ItemNum;
            color = maintainCompensation2.Item[index].ItemRank;
          }
          ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = false;
          this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
          ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = new Color(1f, 1f, 1f);
        }
      }
      else if (this.SC.Type == NoticeReport.Enotice_ReturnCeremony)
      {
        NoticeContent.ReturnCeremony returnCeremony = new NoticeContent.ReturnCeremony();
        NoticeContent.ReturnCeremony enoticeReturnCeremony = this.SC.Enotice_ReturnCeremony;
        if (enoticeReturnCeremony.Crystal > 0U)
          num4 = 1;
        int index = dataIdx - num4;
        if (panelObjectIdx == 0)
        {
          if (dataIdx == 0 && enoticeReturnCeremony.Crystal > 0U)
          {
            this.BuyIconRT.anchoredPosition = new Vector2(258f, this.BuyIconRT.anchoredPosition.y);
            this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleCenter;
            this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
            ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = new Color(1f, 0.9333f, 0.6196f);
          }
          else
          {
            this.BuyIconRT.anchoredPosition = new Vector2(29f, this.BuyIconRT.anchoredPosition.y);
            if (this.GUIM.IsArabic)
              this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleLeft;
            else
              this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleRight;
            this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 26;
            ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = new Color(1f, 1f, 1f);
          }
        }
        if (dataIdx == 0 && enoticeReturnCeremony.Crystal > 0U)
        {
          num3 = (ushort) 1001;
          x = enoticeReturnCeremony.Crystal;
          this.ScrollComp[panelObjectIdx].ItemName.text = string.Empty;
          ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = true;
          ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(false);
          ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(false);
        }
        else if (dataIdx < num4 + enoticeReturnCeremony.Item.Length)
        {
          if (index >= 0 && index < enoticeReturnCeremony.Item.Length)
          {
            num3 = enoticeReturnCeremony.Item[index].ItemID;
            x = (uint) enoticeReturnCeremony.Item[index].ItemNum;
            color = enoticeReturnCeremony.Item[index].ItemRank;
          }
          ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = false;
          this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
          ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = new Color(1f, 1f, 1f);
        }
      }
      if (dataIdx > 0 && dataIdx > num4 && this.SC.Type == NoticeReport.Enotice_BuyTreasure || this.SC.Type == NoticeReport.Enotice_BuyBlackMarketTreasure || (this.SC.Type == NoticeReport.Enotice_BackendActivity || this.SC.Type == NoticeReport.Enotice_MaintainCompensation || this.SC.Type == NoticeReport.Enotice_ReturnCeremony) && dataIdx >= num4 || this.SC.Type == NoticeReport.Enotice_TreasureBackPrize)
      {
        Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(num3);
        bool flag = this.GUIM.IsLeadItem(recordByKey.EquipKind);
        if (flag)
        {
          this.GUIM.ChangeLordEquipImg(((Component) this.ScrollComp[panelObjectIdx].LEBtn).transform, num3, color, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        }
        else
        {
          if (this.MM.CheckCanOpenDetail(num3))
            this.ScrollComp[panelObjectIdx].Hint.enabled = false;
          else
            this.ScrollComp[panelObjectIdx].Hint.enabled = true;
          this.GUIM.ChangeHeroItemImg(((Component) this.ScrollComp[panelObjectIdx].HIBtn).transform, eHeroOrItem.Item, num3, (byte) 0, (byte) 0);
        }
        ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(flag);
        ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(!flag);
        this.NameStr[panelObjectIdx].Length = 0;
        this.NameStr[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipName));
        this.NameStr[panelObjectIdx].AppendFormat("{0}");
        this.ScrollComp[panelObjectIdx].ItemName.text = this.NameStr[panelObjectIdx].ToString();
        this.ScrollComp[panelObjectIdx].ItemName.SetAllDirty();
        this.ScrollComp[panelObjectIdx].ItemName.cachedTextGenerator.Invalidate();
      }
      if (dataIdx == 1 && num3 == (ushort) 1001)
      {
        this.NameStr[panelObjectIdx].Length = 0;
        StringManager.IntToStr(this.NameStr[panelObjectIdx], (long) x, bNumber: true);
        this.ScrollComp[panelObjectIdx].ItemName.text = this.NameStr[panelObjectIdx].ToString();
        this.ScrollComp[panelObjectIdx].ItemName.SetAllDirty();
        this.ScrollComp[panelObjectIdx].ItemName.cachedTextGenerator.Invalidate();
        this.CountStr[panelObjectIdx].Length = 0;
        this.ScrollComp[panelObjectIdx].ItemCountText.text = this.DM.mStringTable.GetStringByID(876U).ToString();
        ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = new Color(0.2f, 1f, 0.404f);
        this.ScrollComp[panelObjectIdx].ItemCountText.SetAllDirty();
        this.ScrollComp[panelObjectIdx].ItemCountText.cachedTextGenerator.Invalidate();
      }
      else
      {
        this.CountStr[panelObjectIdx].Length = 0;
        StringManager.IntToStr(this.CountStr[panelObjectIdx], (long) x, bNumber: true);
        this.ScrollComp[panelObjectIdx].ItemCountText.text = this.CountStr[panelObjectIdx].ToString();
        this.ScrollComp[panelObjectIdx].ItemCountText.SetAllDirty();
        this.ScrollComp[panelObjectIdx].ItemCountText.cachedTextGenerator.Invalidate();
        ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = new Color(1f, 1f, 1f);
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
  }

  public void Open_NP_Mail(bool bNext)
  {
    if (!(!this.DM.bPlural ? this.DM.MailReportGet(ref this.Favor, bNext) : this.DM.MailReportGet(ref this.Favor, bNext, this.DM.Letter_PluralReplyID, this.DM.Letter_PluralSenderName)))
      return;
    switch (this.Favor.Type)
    {
      case MailType.EMAIL_SYSTEM:
        this.DM.OpenMail.Serial = this.Favor.Serial;
        this.DM.OpenMail.Type = this.Favor.Type;
        this.DM.OpenMail.Kind = this.Favor.Kind;
        this.door.CloseMenu();
        this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
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
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
            return;
          case CombatCollectReport.CCR_RESOURCE:
            this.door.OpenMenu(EGUIWindow.UI_Letter_Resources);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
            return;
          case CombatCollectReport.CCR_COLLECT:
            this.door.OpenMenu(EGUIWindow.UI_Letter_Collection);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
            return;
          case CombatCollectReport.CCR_SCOUT:
            if (this.Favor.Combat.Scout.ScoutLevel != (byte) 0)
              this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower);
            else
              this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 1);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
            return;
          case CombatCollectReport.CCR_RECON:
            this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
            return;
          case CombatCollectReport.CCR_MONSTER:
            if (this.Favor.Combat.Monster.Result < (byte) 2 || this.Favor.Combat.Monster.Result > (byte) 3)
            {
              this.door.OpenMenu(EGUIWindow.UI_FightingSummary, 1);
              this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
              return;
            }
            this.door.CloseMenu();
            this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
            return;
          case CombatCollectReport.CCR_NPCSCOUT:
            this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
            return;
          case CombatCollectReport.CCR_PETREPORT:
            this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_LetterDetail);
            return;
          default:
            return;
        }
      case MailType.EMAIL_LETTER:
        this.DM.OpenMail.Serial = this.Favor.Serial;
        this.DM.OpenMail.Type = this.Favor.Type;
        this.DM.OpenMail.Kind = this.Favor.Kind;
        this.door.CloseMenu();
        this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
        this.DM.bNoPlural = !this.DM.bPlural;
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 1:
        if (!this.DM.MailReportDelete(this.MC.SerialID))
          break;
        this.door.CloseMenu();
        break;
      case 2:
        if (this.mLetterKind != 2)
        {
          this.DM.SystemReportDelete(this.SC.SerialID);
          this.door.CloseMenu();
          break;
        }
        this.DM.BattleReportDelete(this.CR.SerialID);
        this.door.CloseMenu();
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 2:
        if (this.DM.MailReportGet(ref this.Favor))
          break;
        this.door.CloseMenu();
        break;
      case 3:
        this.text_Contents.text = this.MC.Content;
        this.text_Contents.SetAllDirty();
        this.text_Contents.cachedTextGeneratorForLayout.Invalidate();
        this.text_Contents.cachedTextGenerator.Invalidate();
        if ((double) this.text_Contents.preferredHeight > 158.0)
          ((Graphic) this.text_Contents).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Contents).rectTransform.sizeDelta.x, this.text_Contents.preferredHeight + 1f);
        if ((double) this.text_Contents.preferredHeight + 18.0 > 425.0)
        {
          this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 18f + this.text_Contents.preferredHeight);
          break;
        }
        this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 425f);
        break;
    }
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
          if (networkNews != NetworkNews.Refresh_Letter)
          {
            if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
              break;
            this.Refresh_FontTexture();
            break;
          }
          if (meg[1] == (byte) 1 && meg[2] == (byte) 1)
          {
            this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9077U), (ushort) byte.MaxValue);
            ((Component) this.Img_Translate).gameObject.SetActive(false);
            ((Component) this.btn_Translation).gameObject.SetActive(true);
            ((Component) this.text_Translation).gameObject.SetActive(true);
            break;
          }
          if (meg[2] == (byte) 0 && (int) GameConstants.ConvertBytesToUInt(meg, 4) == (int) this.Favor.Serial && (MailType) meg[3] == this.Favor.Kind && this.bTrans && this.MC.Translation && this.DM.CheckLanguageTranslateByIdx((int) this.MC.LanguageSource))
          {
            ((Component) this.Img_Translate).gameObject.SetActive(false);
            ((Component) this.btn_Translation).gameObject.SetActive(true);
            ((Component) this.text_Translation).gameObject.SetActive(true);
            if (this.MC.MailType != (byte) 2 && this.bTrans && this.GUIM.CheckNeedTranslate(this.MC.Content))
            {
              ((Component) this.TranslationRT).gameObject.SetActive(true);
              ((Component) this.text_Translation).gameObject.SetActive(true);
              if (this.bTransBtnStatus && (GameLanguage) this.MC.LanguageTarget == this.DM.UserLanguage)
              {
                this.Cstr_Translation.ClearString();
                this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID(this.MC.LanguageSource));
                this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054U));
                this.text_Translation.text = this.Cstr_Translation.ToString();
              }
              else
                this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052U);
            }
            else
            {
              ((Component) this.TranslationRT).gameObject.SetActive(false);
              ((Component) this.text_Translation).gameObject.SetActive(false);
              this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052U);
            }
            this.text_Translation.SetAllDirty();
            this.text_Translation.cachedTextGenerator.Invalidate();
            this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
            if ((double) this.text_Translation.preferredWidth > (double) ((Graphic) this.text_Translation).rectTransform.sizeDelta.x)
              ((Graphic) this.text_Translation).rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, ((Graphic) this.text_Translation).rectTransform.sizeDelta.y);
            if (this.GUIM.IsArabic)
              this.text_Translation.UpdateArabicPos();
            if (this.mLetterKind != 0 || this.MC.MailType == (byte) 2)
              break;
            if (this.MC.MailType == (byte) 1)
            {
              this.Cstr_Title.ClearString();
              this.Cstr_Title.StringToFormat(this.DM.mStringTable.GetStringByID(6014U));
              if (this.bTransBtnStatus && (GameLanguage) this.MC.LanguageTarget == this.DM.UserLanguage && this.GUIM.CheckNeedTranslate(this.MC.Title))
                this.Cstr_Title.StringToFormat(this.MC.TitleT);
              else
                this.Cstr_Title.StringToFormat(this.MC.Title);
              this.Cstr_Title.AppendFormat("{0}{1}");
              this.text_Title.text = this.Cstr_Title.ToString();
            }
            else
              this.text_Title.text = this.MC.MailType != (byte) 3 ? (!this.bTransBtnStatus || (GameLanguage) this.MC.LanguageTarget != this.DM.UserLanguage || !this.GUIM.CheckNeedTranslate(this.MC.Title) ? this.MC.Title : this.MC.TitleT) : this.DM.mStringTable.GetStringByID(1474U);
            this.text_Title.SetAllDirty();
            this.text_Title.cachedTextGenerator.Invalidate();
            this.text_Contents.text = !this.bTransBtnStatus ? this.MC.Content : this.MC.ContentT;
            this.text_Contents.SetAllDirty();
            this.text_Contents.cachedTextGeneratorForLayout.Invalidate();
            this.text_Contents.cachedTextGenerator.Invalidate();
            if ((double) this.text_Contents.preferredHeight > 158.0)
            {
              ((Graphic) this.text_Contents).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Contents).rectTransform.sizeDelta.x, this.text_Contents.preferredHeight + 1f);
              this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, (float) (-193.0 - ((double) this.text_Contents.preferredHeight + 1.0 - 158.0) - 33.0));
              ((Graphic) this.text_Translation).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_Translation).rectTransform.anchoredPosition.x, (float) (-179.0 - ((double) this.text_Contents.preferredHeight + 1.0 - 158.0) - 33.0));
            }
            float num = 0.0f;
            if (((Component) this.TranslationRT).gameObject.activeSelf)
              num = 84f;
            if ((double) this.text_Contents.preferredHeight + 18.0 + (double) num > 425.0)
            {
              this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 18f + num + this.text_Contents.preferredHeight);
              break;
            }
            this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 425f);
            break;
          }
          if (!((Component) this.Img_Translate).gameObject.activeSelf)
            break;
          ((Component) this.Img_Translate).gameObject.SetActive(false);
          ((Component) this.btn_Translation).gameObject.SetActive(true);
          ((Component) this.text_Translation).gameObject.SetActive(true);
          break;
        }
        if (!this.DM.MailReportGet(ref this.Favor))
        {
          this.door.CloseMenu();
          break;
        }
        if (this.mLetterKind == 0)
        {
          if (!this.DM.bNoPlural)
          {
            if (this.MC.More > (byte) 1 && !this.DM.bPlural)
            {
              this.DM.bPlural = true;
              this.DM.OpenMail.Serial = this.Favor.Serial;
              this.DM.OpenMail.Type = this.Favor.Type;
              this.DM.OpenMail.Kind = this.Favor.Kind;
              this.door.CloseMenu();
              this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
              break;
            }
            if (this.MC.More <= (byte) 1 && this.DM.bPlural)
            {
              this.DM.bPlural = false;
              this.DM.OpenMail.Serial = this.Favor.Serial;
              this.DM.OpenMail.Type = this.Favor.Type;
              this.DM.OpenMail.Kind = this.Favor.Kind;
              this.door.CloseMenu();
              this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
              break;
            }
          }
          if (this.DM.bPlural)
          {
            this.MaxLetterNum = this.DM.GetMailboxSize(this.MC.ReplyID, this.MC.SenderName);
            this.tmpPageNum = (int) this.MC.MoreIndex + 1;
            if (this.MaxLetterNum > 1)
            {
              if ((int) this.MC.MoreIndex + 1 == 1)
                ((Component) this.btn_Previous).gameObject.SetActive(false);
              else
                ((Component) this.btn_Previous).gameObject.SetActive(true);
              if ((int) this.MC.MoreIndex + 1 == this.MaxLetterNum)
                ((Component) this.btn_Next).gameObject.SetActive(false);
              else
                ((Component) this.btn_Next).gameObject.SetActive(true);
            }
            else
            {
              ((Component) this.btn_Previous).gameObject.SetActive(false);
              ((Component) this.btn_Next).gameObject.SetActive(false);
            }
          }
          else
          {
            this.MaxLetterNum = (int) this.DM.GetMailboxSize();
            this.tmpPageNum = (int) this.MC.Index + 1;
            if (this.MaxLetterNum > 1)
            {
              if ((int) this.MC.Index + 1 == 1)
                ((Component) this.btn_Previous).gameObject.SetActive(false);
              else
                ((Component) this.btn_Previous).gameObject.SetActive(true);
              if ((int) this.MC.Index + 1 == this.MaxLetterNum)
                ((Component) this.btn_Next).gameObject.SetActive(false);
              else
                ((Component) this.btn_Next).gameObject.SetActive(true);
            }
            else
            {
              ((Component) this.btn_Previous).gameObject.SetActive(false);
              ((Component) this.btn_Next).gameObject.SetActive(false);
            }
          }
        }
        else if (this.mLetterKind == 1)
        {
          this.text_Name.text = this.SC.Type >= NoticeReport.Enotice_NewbieOver && this.SC.Type <= NoticeReport.Enotice_SHLevel5 || this.SC.Type == NoticeReport.Enotice_FirstUnderPetAttack ? this.DM.mStringTable.GetStringByID(3717U) : this.DM.mStringTable.GetStringByID(6079U);
          this.MaxLetterNum = (int) this.DM.GetMailboxSize();
          this.tmpPageNum = (int) this.SC.Index + 1;
          if (this.MaxLetterNum > 1)
          {
            if ((int) this.SC.Index + 1 == 1)
              ((Component) this.btn_Previous).gameObject.SetActive(false);
            else
              ((Component) this.btn_Previous).gameObject.SetActive(true);
            if ((int) this.SC.Index + 1 == this.MaxLetterNum)
              ((Component) this.btn_Next).gameObject.SetActive(false);
            else
              ((Component) this.btn_Next).gameObject.SetActive(true);
          }
          else
          {
            ((Component) this.btn_Previous).gameObject.SetActive(false);
            ((Component) this.btn_Next).gameObject.SetActive(false);
          }
        }
        else if (this.mLetterKind == 2)
        {
          this.MaxLetterNum = (int) this.DM.GetMailboxSize();
          this.tmpPageNum = (int) this.CR.Index + 1;
          if (this.MaxLetterNum > 1)
          {
            if ((int) this.CR.Index + 1 == 1)
              ((Component) this.btn_Previous).gameObject.SetActive(false);
            else
              ((Component) this.btn_Previous).gameObject.SetActive(true);
            if ((int) this.CR.Index + 1 == this.MaxLetterNum)
              ((Component) this.btn_Next).gameObject.SetActive(false);
            else
              ((Component) this.btn_Next).gameObject.SetActive(true);
          }
          else
          {
            ((Component) this.btn_Previous).gameObject.SetActive(false);
            ((Component) this.btn_Next).gameObject.SetActive(false);
          }
        }
        this.Cstr_Page.ClearString();
        this.Cstr_Page.IntToFormat((long) this.tmpPageNum);
        this.Cstr_Page.IntToFormat((long) this.MaxLetterNum);
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
    if ((UnityEngine.Object) this.text_Page != (UnityEngine.Object) null && ((Behaviour) this.text_Page).enabled)
    {
      ((Behaviour) this.text_Page).enabled = false;
      ((Behaviour) this.text_Page).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Name != (UnityEngine.Object) null && ((Behaviour) this.text_Name).enabled)
    {
      ((Behaviour) this.text_Name).enabled = false;
      ((Behaviour) this.text_Name).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Title != (UnityEngine.Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Contents != (UnityEngine.Object) null && ((Behaviour) this.text_Contents).enabled)
    {
      ((Behaviour) this.text_Contents).enabled = false;
      ((Behaviour) this.text_Contents).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Contents_S != (UnityEngine.Object) null && ((Behaviour) this.text_Contents_S).enabled)
    {
      ((Behaviour) this.text_Contents_S).enabled = false;
      ((Behaviour) this.text_Contents_S).enabled = true;
    }
    if ((UnityEngine.Object) this.text_S_Title != (UnityEngine.Object) null && ((Behaviour) this.text_S_Title).enabled)
    {
      ((Behaviour) this.text_S_Title).enabled = false;
      ((Behaviour) this.text_S_Title).enabled = true;
    }
    if ((UnityEngine.Object) this.text_LordEquip_Lv != (UnityEngine.Object) null && ((Behaviour) this.text_LordEquip_Lv).enabled)
    {
      ((Behaviour) this.text_LordEquip_Lv).enabled = false;
      ((Behaviour) this.text_LordEquip_Lv).enabled = true;
    }
    if ((UnityEngine.Object) this.text_CryptFinish != (UnityEngine.Object) null && ((Behaviour) this.text_CryptFinish).enabled)
    {
      ((Behaviour) this.text_CryptFinish).enabled = false;
      ((Behaviour) this.text_CryptFinish).enabled = true;
    }
    if ((UnityEngine.Object) this.text_MonsterXY != (UnityEngine.Object) null && ((Behaviour) this.text_MonsterXY).enabled)
    {
      ((Behaviour) this.text_MonsterXY).enabled = false;
      ((Behaviour) this.text_MonsterXY).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Translation != (UnityEngine.Object) null && ((Behaviour) this.text_Translation).enabled)
    {
      ((Behaviour) this.text_Translation).enabled = false;
      ((Behaviour) this.text_Translation).enabled = true;
    }
    if ((UnityEngine.Object) this.GiftsHbtn_Item != (UnityEngine.Object) null && ((Behaviour) this.GiftsHbtn_Item).enabled)
      this.GiftsHbtn_Item.Refresh_FontTexture();
    for (int index = 0; index < 2; ++index)
    {
      if ((UnityEngine.Object) this.text_Time[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Time[index]).enabled)
      {
        ((Behaviour) this.text_Time[index]).enabled = false;
        ((Behaviour) this.text_Time[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Skill_1[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Skill_1[index]).enabled)
      {
        ((Behaviour) this.text_Skill_1[index]).enabled = false;
        ((Behaviour) this.text_Skill_1[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Skill_2[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Skill_2[index]).enabled)
      {
        ((Behaviour) this.text_Skill_2[index]).enabled = false;
        ((Behaviour) this.text_Skill_2[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_LordEquip[index] != (UnityEngine.Object) null && ((Behaviour) this.text_LordEquip[index]).enabled)
      {
        ((Behaviour) this.text_LordEquip[index]).enabled = false;
        ((Behaviour) this.text_LordEquip[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Gifts[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Gifts[index]).enabled)
      {
        ((Behaviour) this.text_Gifts[index]).enabled = false;
        ((Behaviour) this.text_Gifts[index]).enabled = true;
      }
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((UnityEngine.Object) this.text_S_Top[index] != (UnityEngine.Object) null && ((Behaviour) this.text_S_Top[index]).enabled)
      {
        ((Behaviour) this.text_S_Top[index]).enabled = false;
        ((Behaviour) this.text_S_Top[index]).enabled = true;
      }
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((UnityEngine.Object) this.text_StarUp_1[index] != (UnityEngine.Object) null && ((Behaviour) this.text_StarUp_1[index]).enabled)
      {
        ((Behaviour) this.text_StarUp_1[index]).enabled = false;
        ((Behaviour) this.text_StarUp_1[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_StarUp_2[index] != (UnityEngine.Object) null && ((Behaviour) this.text_StarUp_2[index]).enabled)
      {
        ((Behaviour) this.text_StarUp_2[index]).enabled = false;
        ((Behaviour) this.text_StarUp_2[index]).enabled = true;
      }
    }
    for (int index = 0; index < 7; ++index)
    {
      if ((UnityEngine.Object) this.text_tmpStr[index] != (UnityEngine.Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
    for (int index1 = 0; index1 < 6; ++index1)
    {
      for (int index2 = 0; index2 < 2; ++index2)
      {
        if ((UnityEngine.Object) this.text_LordEquip_Effect[index1][index2] != (UnityEngine.Object) null && ((Behaviour) this.text_LordEquip_Effect[index1][index2]).enabled)
        {
          ((Behaviour) this.text_LordEquip_Effect[index1][index2]).enabled = false;
          ((Behaviour) this.text_LordEquip_Effect[index1][index2]).enabled = true;
        }
      }
      for (int index3 = 0; index3 < 5; ++index3)
      {
        if ((UnityEngine.Object) this.text_S_ItemNum[index1][index3] != (UnityEngine.Object) null && ((Behaviour) this.text_S_ItemNum[index1][index3]).enabled)
        {
          ((Behaviour) this.text_S_ItemNum[index1][index3]).enabled = false;
          ((Behaviour) this.text_S_ItemNum[index1][index3]).enabled = true;
        }
        if ((UnityEngine.Object) this.Hbtn_Item[index1][index3] != (UnityEngine.Object) null && ((Behaviour) this.Hbtn_Item[index1][index3]).enabled)
          this.Hbtn_Item[index1][index3].Refresh_FontTexture();
      }
    }
    for (int index = 0; index < 10; ++index)
    {
      if ((UnityEngine.Object) this.text_BookMarkList[index] != (UnityEngine.Object) null && ((Behaviour) this.text_BookMarkList[index]).enabled)
      {
        ((Behaviour) this.text_BookMarkList[index]).enabled = false;
        ((Behaviour) this.text_BookMarkList[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_BookMarkList2[index] != (UnityEngine.Object) null && ((Behaviour) this.text_BookMarkList2[index]).enabled)
      {
        ((Behaviour) this.text_BookMarkList2[index]).enabled = false;
        ((Behaviour) this.text_BookMarkList2[index]).enabled = true;
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
    if ((UnityEngine.Object) this.NextT != (UnityEngine.Object) null)
    {
      this.Vec3Instance.Set(this.MoveTime1 - num, this.NextT.localPosition.y, this.NextT.localPosition.z);
      this.NextT.localPosition = this.Vec3Instance;
    }
    if (!((UnityEngine.Object) this.PreviousT != (UnityEngine.Object) null))
      return;
    this.Vec3Instance.Set(this.MoveTime2 + num, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
    this.PreviousT.localPosition = this.Vec3Instance;
  }

  private void UpdateBaseline()
  {
    if (!((UnityEngine.Object) this.rectBaseLineBtn != (UnityEngine.Object) null) || !((UnityEngine.Object) this.rectBaseLine != (UnityEngine.Object) null) || !((UnityEngine.Object) this.text_Name != (UnityEngine.Object) null))
      return;
    Vector2 sizeDelta = this.rectBaseLineBtn.sizeDelta with
    {
      x = this.text_Name.preferredWidth
    };
    this.rectBaseLineBtn.sizeDelta = sizeDelta;
    sizeDelta = this.rectBaseLine.sizeDelta with
    {
      x = this.text_Name.preferredWidth
    };
    this.rectBaseLine.sizeDelta = sizeDelta;
    if (this.MC != null && (this.MC.MailType == (byte) 0 || this.MC.MailType == (byte) 1 || this.MC.MailType == (byte) 3 || this.MC.MailType == (byte) 4))
    {
      if (!(bool) (UnityEngine.Object) this.baseline || this.baseline.gameObject.activeSelf)
        return;
      this.baseline.gameObject.SetActive(true);
    }
    else
    {
      if (!(bool) (UnityEngine.Object) this.baseline || !this.baseline.gameObject.activeSelf)
        return;
      this.baseline.gameObject.SetActive(false);
    }
  }
}
