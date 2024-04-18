// Decompiled with JetBrains decompiler
// Type: UIFightingSummary
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIFightingSummary : 
  GUIWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUILEBtnClickHandler
{
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Tmp2;
  private Transform LightT1;
  private Transform LightT2;
  private Transform[] ItemT = new Transform[5];
  private Transform PreviousT;
  private Transform NextT;
  private Transform LightBossT;
  private Transform BossIconT;
  private Transform ItemBase;
  private Transform Mask_T;
  private GameObject mHead;
  private RectTransform tmpRC;
  private RectTransform ContentRT;
  private RectTransform ReplayerRT;
  private RectTransform ItemRT;
  private RectTransform ItemRT2;
  private RectTransform HeroRT;
  private RectTransform HeroBGRT;
  private RectTransform ResourcesRT;
  private RectTransform SummaryRT;
  private RectTransform QuanmieRT;
  private RectTransform BossRT;
  private RectTransform BossBloodRT;
  private RectTransform PetSkillRT_L;
  private RectTransform PetSkillRT_R;
  private RectTransform[] PetSkill_BfIcon_RT_L = new RectTransform[2];
  private RectTransform[] PetSkill_BfIcon_RT_R = new RectTransform[2];
  private RectTransform[] DeBuff_BfIcon_RT_L = new RectTransform[2];
  private RectTransform[] DeBuff_BfIcon_RT_R = new RectTransform[2];
  private RectTransform[] Failure_Buff_RT = new RectTransform[2];
  private RectTransform[] Failure_Skill_RT = new RectTransform[2];
  private RectTransform[] Failure_DeBuff_RT = new RectTransform[2];
  private UIButton btn_EXIT;
  private UIButton btn_Previous;
  private UIButton btn_Next;
  private UIButton btn_Title;
  private UIButton btn_Delete;
  private UIButton btn_Collect;
  private UIButton btn_Replay;
  private UIButton btn_Details;
  private UIButton[] btn_Coordinate = new UIButton[2];
  private UIButton btn_LF;
  private UIButton btn_RF;
  private UIButton[] btn_PetSkill_L = new UIButton[10];
  private UIButton[] btn_PetSkill_R = new UIButton[10];
  private UIButton[] btn_DeBuff_L = new UIButton[10];
  private UIButton[] btn_DeBuff_R = new UIButton[10];
  private UIButton[] btn_Failure_Skill = new UIButton[10];
  private UIButton[] btn_Failure_DeBuff = new UIButton[10];
  private UIHIBtn[] btn_Itme = new UIHIBtn[30];
  private UILEBtn[] btn_Item_L = new UILEBtn[30];
  private UIHIBtn[] btn_Hero = new UIHIBtn[5];
  private UIHIBtn btn_Boss_Hero;
  private Image tmpImg;
  private Image Img_Titlebg;
  private Image Img_MainHerobg;
  private Image Img_RePlay;
  private Image Img_Vs;
  private Image[] Img_Summarybg = new Image[2];
  private Image[] Img_Crown = new Image[4];
  private Image[] Img_MainHero = new Image[6];
  private Image[] Img_MainTitle = new Image[2];
  private Image[] Img_Muster = new Image[2];
  private Image[] Img_Country = new Image[2];
  private Image[] Img_Rank = new Image[2];
  private Image[] Img_Army = new Image[2];
  private Image[] Img_Army2 = new Image[2];
  private Image[] Img_CWall = new Image[2];
  private Image[] Img_CWall_P = new Image[2];
  private Image[] Img_Vip = new Image[2];
  private Image[] Img_BossHeroCrown = new Image[2];
  private Image[] Img_BossIcon = new Image[2];
  private Image Img_BossVs;
  private Image Img_Quanmie;
  private Image Img_Exp;
  private Image Img_LF;
  private Image Img_RF;
  private Image Img_FormationHint;
  private Image[] Img_Bf_BG_L = new Image[3];
  private Image[] Img_Bf_BG_R = new Image[3];
  private Image[] Img_PetSkill_L = new Image[10];
  private Image[] Img_PetSkill_R = new Image[10];
  private Image[] Img_DeBuff_L = new Image[10];
  private Image[] Img_DeBuff_R = new Image[10];
  private Image[] Img_Failure_Skill = new Image[10];
  private Image[] Img_Failure_DeBuff = new Image[10];
  private CScrollRect m_Mask;
  private UIText tmptext;
  private UIText text_Coordinate;
  private UIText text_TitleName;
  private UIText text_Page;
  private UIText text_Summary;
  private UIText text_MainHero;
  private UIText text_TitleItem;
  private UIText text_FightingKind;
  private UIText text_L_Exp;
  private UIText[] text_Time = new UIText[2];
  private UIText[] text_ItemQty = new UIText[30];
  private UIText[] text_Offensive = new UIText[2];
  private UIText[] text_LossValue = new UIText[2];
  private UIText[] text_ArmyTitle = new UIText[2];
  private UIText[] text_Strength = new UIText[2];
  private UIText[] text_Country = new UIText[2];
  private UIText[] text_Dominance = new UIText[2];
  private UIText[] text_Name = new UIText[2];
  private UIText[] text_MainHero_F = new UIText[2];
  private UIText[] text_Vip = new UIText[2];
  private UIText[] text_LA = new UIText[4];
  private UIText[] text_RA = new UIText[8];
  private UIText[] text_DW = new UIText[3];
  private UIText[] text_Resources = new UIText[5];
  private UIText[] text_HeroExp = new UIText[5];
  private UIText[] text_HeroExp2 = new UIText[5];
  private UIText[] text_CoordinateMainHero = new UIText[2];
  private UIText[] text_tmpStr = new UIText[25];
  private UIText[] text_Quanmie = new UIText[8];
  private UIText[] text_BossTitle = new UIText[2];
  private UIText[] text_BossL = new UIText[2];
  private UIText[] text_BossR = new UIText[3];
  private UIText[] text_BossFight = new UIText[3];
  private UIText text_LF;
  private UIText text_RF;
  private UIText text_Formation;
  private UIText[] text_Buff = new UIText[9];
  private UIText[] text_FailureBuff = new UIText[3];
  private CString[] Cstr_Coordinate = new CString[2];
  private CString Cstr_TitleName;
  private CString Cstr_Page;
  private CString Cstr_FightingKind;
  private CString Cstr_L_Exp;
  private CString[] Cstr_ItemQty = new CString[30];
  private CString[] Cstr_Offensive = new CString[2];
  private CString[] Cstr_LossValue = new CString[2];
  private CString[] Cstr_Strength = new CString[2];
  private CString[] Cstr_Resources = new CString[5];
  private CString[] Cstr_Country = new CString[2];
  private CString[] Cstr_Dominance = new CString[2];
  private CString[] Cstr_CoordinateMainHero = new CString[2];
  private CString[] Cstr_Name = new CString[2];
  private CString[] Cstr_LA = new CString[4];
  private CString[] Cstr_RA = new CString[8];
  private CString[] Cstr_DW = new CString[3];
  private CString[] Cstr_HeroExp = new CString[5];
  private CString[] Cstr_BossR = new CString[2];
  private CString[] Cstr_BossFight = new CString[2];
  private CString[] Cstr_BossL = new CString[2];
  private CString Cstr_BoosHead;
  private CString Cstr_Text;
  private CString[] Cstr_Quanmie = new CString[4];
  private CString Cstr_NpcTroops;
  private CString Cstr_QuanmieNpcTroops;
  private CString Cstr_LF;
  private CString Cstr_RF;
  private DataManager DM;
  private GUIManager GUIM;
  private PetManager PM;
  private Font TTFont;
  private Door door;
  private UISpritesArray SArray;
  private Material mMaT;
  private Material IconMaterial;
  private Material FrameMaterial;
  private float tmpH;
  private int mItemCount;
  private int tmpNum;
  private bool bQuanmier;
  private bool bWin = true;
  private bool IsAttack = true;
  private int mType;
  private float ShowMainHeroTime1;
  private float ShowMainHeroTime2;
  private float ShowVsTime;
  private float ShowReplay;
  private float tempL;
  private float MoveTime1;
  private float MoveTime2;
  private float TmpTime;
  private CString[] StrResources = new CString[5];
  private CombatReport Report;
  private MyFavorite Favor = new MyFavorite(Id: 0U);
  private int MaxLetterNum;
  private Hero tmpHero;
  private Vector3 Vec3Instance;
  private uint tmpValue;
  private Vector2 tmpV;
  private int mOpenKind;
  private uint[] tmpHeroExp = new uint[5];
  private ushort[] tmpHeroID = new ushort[5];
  private byte[] tmpHeroStar = new byte[5];
  private ushort[] ItemID = new ushort[30];
  private ushort[] ItemNum = new ushort[30];
  private byte[] ItemRank = new byte[30];
  private int AssetKey;
  private ushort mBossHead;
  private bool bInitFS;
  private bool bInitBoss;
  private bool bSetFSShow;
  private bool[] bSetHero = new bool[5];
  private bool bCreateItem;
  private bool bInitItemBase;
  private byte bSetItemData;
  private RectTransform NpcItemRT;
  private UIButton btn_NpcItemIcon;
  private UIButton btn_NpcItemName;
  private UIButton btn_NpcCoordinate;
  private Image[] Img_NpcMainHero = new Image[3];
  private Image Img_NpcItemHint;
  private UIText text_NpcInfo;
  private UIText text_QuanmierNpcInfo;
  private UIText text_NpcCoordinate;
  private UIText text_NpcName;
  private UIText text_NpcItemName;
  private UIText text_NpcItemfull;
  private UIText text_NpcItemHint;
  private UIText[] text_NpcTroops = new UIText[2];
  private UIText[] text_QuanmierNpcTroops = new UIText[2];
  private bool bNpcMode;
  private RectTransform AllianceBossItemRT;
  private UIText text_AllianceBossStr;
  private bool bAllianceBossMode;
  private int tmpAllianceBosstest;
  private bool bSaveY;
  public ushort[] m_A_Skill_ID = new ushort[10];
  public ushort[] m_A_DeBf_Skill_ID = new ushort[10];
  public byte[] m_A_Skill_LV = new byte[10];
  public byte[] m_A_DeBf_Skill_LV = new byte[10];
  public ushort[] m_D_Skill_ID = new ushort[10];
  public ushort[] m_D_DeBf_Skill_ID = new ushort[10];
  public byte[] m_D_Skill_LV = new byte[10];
  public byte[] m_D_DeBf_Skill_LV = new byte[10];
  private int mA_Skill_L;
  private int mD_Skill_R;
  private int mDeBf_A_L;
  private int mDeBf_D_R;
  private bool bDoNotShow;
  private UIButtonHint tmpbtnHint;
  private CString S1024 = StringManager.Instance.StaticString1024();
  private PetSkillTbl skill;
  private float tmpH1;
  private float tmpH2;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.PM = PetManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.mMaT = this.door.LoadMaterial();
    this.IconMaterial = this.GUIM.m_IconSpriteAsset.GetMaterial();
    this.FrameMaterial = this.GUIM.GetFrameMaterial();
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    if (this.GUIM.BattleSerialNo > 0U)
    {
      this.door.CloseMenu();
    }
    else
    {
      this.mOpenKind = this.DM.mSaveInfo != (byte) 3 ? arg1 : 0;
      this.Favor.Serial = this.DM.OpenMail.Serial;
      this.Favor.Type = this.DM.OpenMail.Type;
      this.Favor.Kind = this.DM.OpenMail.Kind;
      if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
      {
        this.Report = this.Favor.Combat;
        if (!this.Report.BeRead)
        {
          if (this.Favor.Kind == MailType.EMAIL_BATTLE)
            this.DM.BattleReportRead(this.Report.SerialID, false);
          else
            this.DM.FavorReportRead(this.Report.SerialID, false);
        }
        if (this.Report.Type == CombatCollectReport.CCR_NPCCOMBAT)
          this.bNpcMode = true;
        this.mOpenKind = this.Report.Type != CombatCollectReport.CCR_MONSTER ? 0 : 1;
        if (this.mOpenKind == 0)
        {
          Array.Clear((Array) this.m_A_Skill_ID, 0, this.m_A_Skill_ID.Length);
          Array.Clear((Array) this.m_A_Skill_LV, 0, this.m_A_Skill_LV.Length);
          Array.Clear((Array) this.m_A_DeBf_Skill_ID, 0, this.m_A_DeBf_Skill_ID.Length);
          Array.Clear((Array) this.m_A_DeBf_Skill_LV, 0, this.m_A_DeBf_Skill_LV.Length);
          Array.Clear((Array) this.m_D_Skill_ID, 0, this.m_D_Skill_ID.Length);
          Array.Clear((Array) this.m_D_Skill_LV, 0, this.m_A_Skill_ID.Length);
          Array.Clear((Array) this.m_D_DeBf_Skill_ID, 0, this.m_D_DeBf_Skill_ID.Length);
          Array.Clear((Array) this.m_D_DeBf_Skill_LV, 0, this.m_D_DeBf_Skill_LV.Length);
          this.mA_Skill_L = 0;
          this.mDeBf_A_L = 0;
          this.mD_Skill_R = 0;
          this.mDeBf_D_R = 0;
          if (!this.bNpcMode)
          {
            this.bWin = this.Report.Combat.Result == CombatReportResultType.ECRR_COMBATVICTORY || this.Report.Combat.Result == CombatReportResultType.ECRR_DEFENDVICTORY || this.Report.Combat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER || this.Report.Combat.Result == CombatReportResultType.ECRR_WONDERVICTORY;
            this.IsAttack = this.Report.Combat.Side == (byte) 0 || this.Report.Combat.Side == (byte) 2 || this.Report.Combat.Side == (byte) 4 || this.Report.Combat.Side == (byte) 6;
            this.mType = (int) this.Report.Combat.Result;
            if (this.mType >= 4 && this.mType <= 7)
              this.bQuanmier = true;
            if ((int) this.Report.Combat.PetSkillPatchNo != (int) this.DM.PetVersionNo)
              this.bDoNotShow = true;
            for (int index = 0; index < 20; ++index)
            {
              if (this.Report.Combat.m_AssaultPetSkill_ID[index] > (ushort) 0)
              {
                if (this.mA_Skill_L < this.m_A_Skill_ID.Length && this.PM.PetSkillTable.GetRecordByKey(this.Report.Combat.m_AssaultPetSkill_ID[index]).Subject == (byte) 1)
                {
                  this.m_A_Skill_ID[this.mA_Skill_L] = this.Report.Combat.m_AssaultPetSkill_ID[index];
                  this.m_A_Skill_LV[this.mA_Skill_L] = this.Report.Combat.m_AssaultPetSkill_LV[index];
                  ++this.mA_Skill_L;
                }
                else if (this.mDeBf_A_L < this.m_A_DeBf_Skill_ID.Length)
                {
                  this.m_A_DeBf_Skill_ID[this.mDeBf_A_L] = this.Report.Combat.m_AssaultPetSkill_ID[index];
                  this.m_A_DeBf_Skill_LV[this.mDeBf_A_L] = this.Report.Combat.m_AssaultPetSkill_LV[index];
                  ++this.mDeBf_A_L;
                }
              }
              if (this.Report.Combat.m_DefencePetSkill_ID[index] > (ushort) 0)
              {
                if (this.mD_Skill_R < this.m_D_Skill_ID.Length && this.PM.PetSkillTable.GetRecordByKey(this.Report.Combat.m_DefencePetSkill_ID[index]).Subject == (byte) 1)
                {
                  this.m_D_Skill_ID[this.mD_Skill_R] = this.Report.Combat.m_DefencePetSkill_ID[index];
                  this.m_D_Skill_LV[this.mD_Skill_R] = this.Report.Combat.m_DefencePetSkill_LV[index];
                  ++this.mD_Skill_R;
                }
                else if (this.mDeBf_D_R < this.m_D_DeBf_Skill_ID.Length)
                {
                  this.m_D_DeBf_Skill_ID[this.mDeBf_D_R] = this.Report.Combat.m_DefencePetSkill_ID[index];
                  this.m_D_DeBf_Skill_LV[this.mDeBf_D_R] = this.Report.Combat.m_DefencePetSkill_LV[index];
                  ++this.mDeBf_D_R;
                }
              }
            }
          }
          else
          {
            this.bWin = this.Report.NPCCombat.Result == CombatReportResultType.ECRR_COMBATVICTORY || this.Report.NPCCombat.Result == CombatReportResultType.ECRR_DEFENDVICTORY || this.Report.NPCCombat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER || this.Report.NPCCombat.Result == CombatReportResultType.ECRR_WONDERVICTORY;
            this.IsAttack = this.Report.NPCCombat.Side == (byte) 0 || this.Report.NPCCombat.Side == (byte) 2 || this.Report.NPCCombat.Side == (byte) 4 || this.Report.NPCCombat.Side == (byte) 6;
            this.mType = (int) this.Report.NPCCombat.Result;
            if (this.mType >= 4 && this.mType <= 7)
              this.bQuanmier = true;
            if ((int) this.Report.NPCCombat.PetSkillPatchNo != (int) this.DM.PetVersionNo)
              this.bDoNotShow = true;
            for (int index = 0; index < 20; ++index)
            {
              if (this.Report.NPCCombat.m_AssaultPetSkill_ID[index] > (ushort) 0)
              {
                if (this.mA_Skill_L < this.m_A_Skill_ID.Length && this.PM.PetSkillTable.GetRecordByKey(this.Report.NPCCombat.m_AssaultPetSkill_ID[index]).Subject == (byte) 1)
                {
                  this.m_A_Skill_ID[this.mA_Skill_L] = this.Report.NPCCombat.m_AssaultPetSkill_ID[index];
                  this.m_A_Skill_LV[this.mA_Skill_L] = this.Report.NPCCombat.m_AssaultPetSkill_LV[index];
                  ++this.mA_Skill_L;
                }
                else if (this.mDeBf_A_L < this.m_A_DeBf_Skill_ID.Length)
                {
                  this.m_A_DeBf_Skill_ID[this.mDeBf_A_L] = this.Report.NPCCombat.m_AssaultPetSkill_ID[index];
                  this.m_A_DeBf_Skill_LV[this.mDeBf_A_L] = this.Report.NPCCombat.m_AssaultPetSkill_LV[index];
                  ++this.mDeBf_A_L;
                }
              }
            }
          }
        }
        else if (this.mOpenKind != 1)
          ;
        this.MaxLetterNum = (int) this.DM.GetMailboxSize();
        CString SpriteName = StringManager.Instance.StaticString1024();
        this.Cstr_TitleName = StringManager.Instance.SpawnString(200);
        this.Cstr_Page = StringManager.Instance.SpawnString();
        this.Cstr_FightingKind = StringManager.Instance.SpawnString(100);
        this.Cstr_L_Exp = StringManager.Instance.SpawnString();
        this.Cstr_BoosHead = StringManager.Instance.SpawnString();
        this.Cstr_Text = StringManager.Instance.SpawnString();
        this.Cstr_Quanmie[0] = StringManager.Instance.SpawnString(100);
        this.Cstr_NpcTroops = StringManager.Instance.SpawnString();
        this.Cstr_QuanmieNpcTroops = StringManager.Instance.SpawnString();
        this.Cstr_LF = StringManager.Instance.SpawnString(200);
        this.Cstr_RF = StringManager.Instance.SpawnString(200);
        for (int index = 1; index < 4; ++index)
          this.Cstr_Quanmie[index] = StringManager.Instance.SpawnString();
        for (int index = 0; index < 30; ++index)
          this.Cstr_ItemQty[index] = StringManager.Instance.SpawnString(10);
        for (int index = 0; index < 2; ++index)
        {
          this.Cstr_Coordinate[index] = StringManager.Instance.SpawnString();
          this.Cstr_Offensive[index] = StringManager.Instance.SpawnString();
          this.Cstr_LossValue[index] = StringManager.Instance.SpawnString();
          this.Cstr_Strength[index] = StringManager.Instance.SpawnString();
          this.Cstr_Country[index] = StringManager.Instance.SpawnString();
          this.Cstr_Dominance[index] = StringManager.Instance.SpawnString();
          this.Cstr_CoordinateMainHero[index] = StringManager.Instance.SpawnString();
          this.Cstr_Name[index] = StringManager.Instance.SpawnString();
          this.Cstr_BossR[index] = StringManager.Instance.SpawnString();
          this.Cstr_BossFight[index] = StringManager.Instance.SpawnString(100);
          this.Cstr_BossL[index] = StringManager.Instance.SpawnString();
        }
        for (int index = 0; index < 5; ++index)
        {
          this.Cstr_Resources[index] = StringManager.Instance.SpawnString();
          this.StrResources[index] = StringManager.Instance.SpawnString();
          this.StrResources[index].ClearString();
          this.Cstr_HeroExp[index] = StringManager.Instance.SpawnString();
        }
        for (int index = 0; index < 8; ++index)
          this.Cstr_RA[index] = StringManager.Instance.SpawnString();
        for (int index = 0; index < 4; ++index)
          this.Cstr_LA[index] = StringManager.Instance.SpawnString();
        for (int index = 0; index < 3; ++index)
          this.Cstr_DW[index] = StringManager.Instance.SpawnString();
        this.StrResources[0].Append("UI_main_res_food");
        this.StrResources[1].Append("UI_main_res_stone");
        this.StrResources[2].Append("UI_main_res_wood");
        this.StrResources[3].Append("UI_main_res_iron");
        this.StrResources[4].Append("UI_main_money_01");
        this.Tmp = this.GameT.GetChild(0);
        this.Tmp1 = this.Tmp.GetChild(1);
        this.text_TitleName = this.Tmp1.GetChild(0).GetComponent<UIText>();
        this.text_TitleName.font = this.TTFont;
        this.text_Page = this.Tmp1.GetChild(1).GetComponent<UIText>();
        this.text_Page.font = this.TTFont;
        this.Tmp = this.GameT.GetChild(1);
        this.Mask_T = this.GameT.GetChild(1);
        this.m_Mask = this.Tmp.GetComponent<CScrollRect>();
        this.ContentRT = this.Tmp.GetChild(0).GetComponent<RectTransform>();
        this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
        this.Img_Titlebg = this.Tmp1.GetComponent<Image>();
        this.ReplayerRT = this.Tmp1.GetComponent<RectTransform>();
        this.btn_Replay = this.Tmp1.GetChild(0).GetComponent<UIButton>();
        this.btn_Replay.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Replay.m_BtnID1 = 6;
        this.btn_Replay.SoundIndex = byte.MaxValue;
        this.btn_Replay.m_EffectType = e_EffectType.e_Scale;
        this.btn_Replay.transition = (Selectable.Transition) 0;
        this.Img_RePlay = this.Tmp1.GetChild(0).GetChild(0).GetComponent<Image>();
        this.text_tmpStr[0] = this.Tmp1.GetChild(0).GetChild(1).GetComponent<UIText>();
        this.text_tmpStr[0].font = this.TTFont;
        this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(5306U);
        this.LightT1 = this.Tmp1.GetChild(1);
        this.tmpImg = this.Tmp1.GetChild(1).GetComponent<Image>();
        this.text_Summary = this.Tmp1.GetChild(2).GetComponent<UIText>();
        this.text_Summary.font = this.TTFont;
        this.tmpH -= 136f;
        this.Tmp1 = this.Tmp.GetChild(0).GetChild(1);
        this.Img_MainHerobg = this.Tmp1.GetComponent<Image>();
        this.text_MainHero = this.Tmp1.GetChild(0).GetComponent<UIText>();
        this.text_MainHero.font = this.TTFont;
        this.Tmp1 = this.Tmp.GetChild(0).GetChild(2);
        this.ItemRT = this.Tmp1.GetComponent<RectTransform>();
        this.ItemRT.anchoredPosition = new Vector2(this.ItemRT.anchoredPosition.x, this.tmpH);
        this.ItemRT2 = this.Tmp1.GetChild(0).GetComponent<RectTransform>();
        this.text_TitleItem = this.Tmp1.GetChild(1).GetComponent<UIText>();
        this.text_TitleItem.font = this.TTFont;
        this.ItemT[0] = this.Tmp1.GetChild(0).GetChild(0);
        this.ItemBase = this.Tmp1.GetChild(0).GetChild(0);
        this.Tmp2 = this.Tmp1.GetChild(0).GetChild(1);
        this.ResourcesRT = this.Tmp2.GetComponent<RectTransform>();
        for (int index = 0; index < 5; ++index)
        {
          this.tmpImg = this.Tmp2.GetChild(index).GetComponent<Image>();
          this.tmpImg.sprite = this.door.LoadSprite(this.StrResources[index]);
          ((MaskableGraphic) this.tmpImg).material = this.mMaT;
          this.text_Resources[index] = this.Tmp2.GetChild(index).GetChild(0).GetComponent<UIText>();
          this.text_Resources[index].font = this.TTFont;
        }
        this.Tmp2 = this.Tmp1.GetChild(0).GetChild(2);
        this.NpcItemRT = this.Tmp2.GetComponent<RectTransform>();
        this.Img_NpcItemHint = this.Tmp1.GetChild(0).GetChild(3).GetComponent<Image>();
        this.text_NpcItemHint = this.Tmp1.GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>();
        this.text_NpcItemHint.font = this.TTFont;
        this.text_NpcItemHint.text = this.DM.mStringTable.GetStringByID(9633U);
        this.text_NpcItemHint.fontSize = 22;
        this.text_NpcItemHint.resizeTextMaxSize = 22;
        this.text_NpcItemHint.alignment = TextAnchor.MiddleLeft;
        if ((double) this.text_NpcItemHint.preferredWidth < 380.0)
        {
          ((Graphic) this.Img_NpcItemHint).rectTransform.sizeDelta = new Vector2(this.text_NpcItemHint.preferredWidth + 21f, ((Graphic) this.Img_NpcItemHint).rectTransform.sizeDelta.y);
          ((Graphic) this.text_NpcItemHint).rectTransform.sizeDelta = new Vector2(this.text_NpcItemHint.preferredWidth + 1f, ((Graphic) this.text_NpcItemHint).rectTransform.sizeDelta.y);
        }
        else if ((double) this.text_NpcItemHint.preferredHeight > 40.0)
        {
          ((Graphic) this.text_NpcItemHint).rectTransform.sizeDelta = new Vector2(380f, this.text_NpcItemHint.preferredHeight + 1f);
          ((Graphic) this.Img_NpcItemHint).rectTransform.sizeDelta = new Vector2(400f, this.text_NpcItemHint.preferredHeight + 11f);
        }
        this.btn_NpcItemIcon = this.Tmp2.GetChild(0).GetComponent<UIButton>();
        this.btn_NpcItemIcon.m_Handler = (IUIButtonClickHandler) this;
        this.btn_NpcItemIcon.m_BtnID1 = 14;
        this.tmpbtnHint = ((Component) this.btn_NpcItemIcon).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.DelayTime = 0.3f;
        this.tmpbtnHint.ControlFadeOut = ((Component) this.Img_NpcItemHint).gameObject;
        this.btn_NpcItemName = this.Tmp2.GetChild(1).GetComponent<UIButton>();
        this.btn_NpcItemName.m_Handler = (IUIButtonClickHandler) this;
        this.btn_NpcItemName.m_BtnID1 = 14;
        this.tmpbtnHint = ((Component) this.btn_NpcItemName).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.DelayTime = 0.3f;
        this.tmpbtnHint.ControlFadeOut = ((Component) this.Img_NpcItemHint).gameObject;
        this.text_NpcItemName = this.Tmp2.GetChild(1).GetChild(1).GetComponent<UIText>();
        this.text_NpcItemName.font = this.TTFont;
        this.text_NpcItemName.text = this.DM.mStringTable.GetStringByID((uint) this.DM.EquipTable.GetRecordByKey((ushort) 1001).EquipName);
        this.text_NpcItemName.SetAllDirty();
        this.text_NpcItemName.cachedTextGenerator.Invalidate();
        this.text_NpcItemName.cachedTextGeneratorForLayout.Invalidate();
        this.tmpRC = ((Component) this.btn_NpcItemName).transform.GetComponent<RectTransform>();
        this.tmpRC.sizeDelta = new Vector2(this.text_NpcItemName.preferredWidth, this.tmpRC.sizeDelta.y);
        this.tmpRC = ((Component) this.btn_NpcItemName).transform.GetChild(0).GetComponent<RectTransform>();
        this.tmpRC.sizeDelta = new Vector2(this.text_NpcItemName.preferredWidth, this.tmpRC.sizeDelta.y);
        this.tmpRC = ((Component) this.btn_NpcItemName).transform.GetChild(1).GetComponent<RectTransform>();
        this.tmpRC.sizeDelta = new Vector2(this.text_NpcItemName.preferredWidth, this.tmpRC.sizeDelta.y);
        this.text_NpcItemfull = this.Tmp2.GetChild(2).GetComponent<UIText>();
        this.text_NpcItemfull.font = this.TTFont;
        this.text_NpcItemfull.text = this.DM.mStringTable.GetStringByID(9593U);
        this.Tmp2 = this.Tmp1.GetChild(0).GetChild(4);
        this.AllianceBossItemRT = this.Tmp2.GetComponent<RectTransform>();
        this.text_AllianceBossStr = this.Tmp1.GetChild(0).GetChild(4).GetChild(0).GetComponent<UIText>();
        this.text_AllianceBossStr.font = this.TTFont;
        this.Tmp1 = this.Tmp.GetChild(0).GetChild(3);
        this.HeroRT = this.Tmp1.GetComponent<RectTransform>();
        this.HeroBGRT = this.Tmp1.GetChild(0).GetComponent<RectTransform>();
        this.Img_Exp = this.Tmp1.GetChild(0).GetChild(0).GetComponent<Image>();
        if (this.GUIM.IsArabic)
          ((Component) this.Img_Exp).transform.localScale = new Vector3(-1f, ((Component) this.Img_Exp).transform.localScale.y, ((Component) this.Img_Exp).transform.localScale.z);
        if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
          this.Img_Exp.sprite = this.SArray.m_Sprites[16];
        for (int index = 0; index < 5; ++index)
        {
          this.btn_Hero[index] = this.Tmp1.GetChild(0).GetChild(1).GetChild(index).GetComponent<UIHIBtn>();
          this.text_HeroExp[index] = this.Tmp1.GetChild(0).GetChild(1).GetChild(index + 5).GetComponent<UIText>();
          this.text_HeroExp[index].font = this.TTFont;
          this.text_HeroExp2[index] = this.Tmp1.GetChild(0).GetChild(1).GetChild(index + 10).GetComponent<UIText>();
          this.text_HeroExp2[index].font = this.TTFont;
          this.text_HeroExp2[index].text = this.DM.mStringTable.GetStringByID(7695U);
        }
        this.text_L_Exp = this.Tmp1.GetChild(0).GetChild(2).GetComponent<UIText>();
        this.text_L_Exp.font = this.TTFont;
        this.text_tmpStr[1] = this.Tmp1.GetChild(1).GetComponent<UIText>();
        this.text_tmpStr[1].font = this.TTFont;
        this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(7697U);
        this.tmpH -= 110f;
        this.Tmp1 = this.GameT.GetChild(7);
        this.Img_FormationHint = this.Tmp1.GetComponent<Image>();
        this.text_Formation = this.Tmp1.GetChild(0).GetComponent<UIText>();
        this.text_Formation.font = this.TTFont;
        this.Tmp1 = this.Mask_T.GetChild(0).GetChild(4);
        this.SummaryRT = this.Tmp1.GetComponent<RectTransform>();
        this.SummaryRT.anchoredPosition = new Vector2(this.SummaryRT.anchoredPosition.x, this.tmpH);
        if (this.mOpenKind == 0)
        {
          if (!this.bInitFS)
            this.bInitFS = true;
          this.InitFSComponent();
        }
        if (this.mOpenKind == 1)
        {
          if (!this.bInitBoss)
            this.bInitBoss = true;
          this.InitBossComponent();
        }
        this.Tmp = this.GameT.GetChild(2);
        this.Tmp1 = this.Tmp.GetChild(0);
        this.btn_Title = this.Tmp1.GetComponent<UIButton>();
        this.btn_Title.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Title.m_BtnID1 = 3;
        this.text_Coordinate = this.Tmp1.GetChild(1).GetComponent<UIText>();
        this.text_Coordinate.font = this.TTFont;
        this.Tmp1 = this.Tmp.GetChild(1);
        this.text_Time[0] = this.Tmp1.GetComponent<UIText>();
        this.text_Time[0].font = this.TTFont;
        this.Tmp1 = this.Tmp.GetChild(2);
        this.text_Time[1] = this.Tmp1.GetComponent<UIText>();
        this.text_Time[1].font = this.TTFont;
        this.Tmp1 = this.GameT.GetChild(3);
        this.btn_Delete = this.Tmp1.GetComponent<UIButton>();
        this.btn_Delete.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Delete.m_BtnID1 = 4;
        this.btn_Delete.m_EffectType = e_EffectType.e_Scale;
        this.btn_Delete.transition = (Selectable.Transition) 0;
        this.Tmp1 = this.GameT.GetChild(4);
        this.btn_Collect = this.Tmp1.GetComponent<UIButton>();
        this.btn_Collect.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Collect.m_BtnID1 = 5;
        this.btn_Collect.m_EffectType = e_EffectType.e_Scale;
        this.btn_Collect.transition = (Selectable.Transition) 0;
        float x = ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x;
        this.tempL = (float) (((double) ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x - 853.0) / 2.0);
        this.PreviousT = this.GameT.GetChild(5);
        this.btn_Previous = this.PreviousT.GetComponent<UIButton>();
        this.btn_Previous.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Previous.m_BtnID1 = 1;
        this.btn_Previous.m_EffectType = e_EffectType.e_Scale;
        this.btn_Previous.transition = (Selectable.Transition) 0;
        this.NextT = this.GameT.GetChild(6);
        this.btn_Next = this.NextT.GetComponent<UIButton>();
        this.btn_Next.m_Handler = (IUIButtonClickHandler) this;
        this.btn_Next.m_BtnID1 = 2;
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
        this.Tmp = this.GameT.GetChild(8);
        this.tmpImg = this.Tmp.GetComponent<Image>();
        SpriteName.ClearString();
        SpriteName.AppendFormat("UI_main_close_base");
        this.tmpImg.sprite = this.door.LoadSprite(SpriteName);
        ((MaskableGraphic) this.tmpImg).material = this.mMaT;
        if (this.GUIM.bOpenOnIPhoneX)
          ((Behaviour) this.tmpImg).enabled = false;
        this.Tmp = this.GameT.GetChild(8).GetChild(0);
        this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
        SpriteName.ClearString();
        SpriteName.AppendFormat("UI_main_close");
        this.btn_EXIT.image.sprite = this.door.LoadSprite(SpriteName);
        ((MaskableGraphic) this.btn_EXIT.image).material = this.mMaT;
        this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
        this.btn_EXIT.m_BtnID1 = 0;
        this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
        this.btn_EXIT.transition = (Selectable.Transition) 0;
        this.SetPageData();
        if (this.DM.mSaveInfo == (byte) 3)
          this.ContentRT.anchoredPosition = this.bNpcMode ? (this.Report.NPCCombat.CombatPointKind != POINT_KIND.PK_CITY || this.Report.NPCCombat.Side >= (byte) 4 ? new Vector2(this.ContentRT.anchoredPosition.x, 365f - this.SummaryRT.anchoredPosition.y) : new Vector2(this.ContentRT.anchoredPosition.x, 742f - this.SummaryRT.anchoredPosition.y)) : (this.Report.Combat.CombatPointKind != POINT_KIND.PK_CITY || this.Report.Combat.Side >= (byte) 4 ? new Vector2(this.ContentRT.anchoredPosition.x, 365f - this.SummaryRT.anchoredPosition.y) : new Vector2(this.ContentRT.anchoredPosition.x, 742f - this.SummaryRT.anchoredPosition.y));
        this.DM.mSaveInfo = (byte) 0;
        if ((double) this.DM.BossOpen_Y != 0.0 && (this.mOpenKind == 1 || this.bNpcMode))
          this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, this.DM.BossOpen_Y);
        this.DM.BossOpen_Y = 0.0f;
        this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
        if ((int) this.DM.mFs_Serial == (int) this.Favor.Serial && (double) this.DM.LetterFs_Y > -1.0)
          this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, this.DM.LetterFs_Y);
        else
          this.DM.LetterFs_Y = -1f;
      }
      else
        this.door.CloseMenu();
    }
  }

  public void InitFSComponent()
  {
    this.Tmp1 = this.Mask_T.GetChild(0).GetChild(4);
    this.text_Offensive[0] = this.Tmp1.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_Offensive[0].font = this.TTFont;
    this.Cstr_Offensive[0].ClearString();
    this.text_Offensive[1] = this.Tmp1.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_Offensive[1].font = this.TTFont;
    this.Cstr_Offensive[1].ClearString();
    this.tmpH -= 51f;
    this.Tmp2 = this.Tmp1.GetChild(2);
    this.Img_Summarybg[0] = this.Tmp2.GetComponent<Image>();
    this.Tmp2 = this.Tmp1.GetChild(3);
    this.Img_Summarybg[1] = this.Tmp2.GetComponent<Image>();
    this.tmpH -= 312f;
    this.Tmp2 = this.Tmp1.GetChild(4);
    this.Img_MainHero[0] = this.Tmp2.GetComponent<Image>();
    this.Img_MainHero[1] = this.Tmp2.GetChild(0).GetChild(0).GetComponent<Image>();
    ((MaskableGraphic) this.Img_MainHero[1]).material = this.IconMaterial;
    this.tmpRC = this.Tmp2.GetChild(0).GetChild(0).GetComponent<RectTransform>();
    this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
    this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
    this.tmpRC.offsetMin = Vector2.zero;
    this.tmpRC.offsetMax = Vector2.zero;
    this.Img_MainHero[2] = this.Tmp2.GetChild(0).GetChild(1).GetComponent<Image>();
    this.Img_MainHero[2].sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, (byte) 11);
    ((MaskableGraphic) this.Img_MainHero[2]).material = this.FrameMaterial;
    this.tmpRC = this.Tmp2.GetChild(0).GetChild(1).GetComponent<RectTransform>();
    this.tmpRC.anchorMin = Vector2.zero;
    this.tmpRC.anchorMax = new Vector2(1f, 1f);
    this.tmpRC.offsetMin = Vector2.zero;
    this.tmpRC.offsetMax = Vector2.zero;
    this.Img_MainTitle[0] = this.Tmp2.GetChild(1).GetComponent<Image>();
    this.text_MainHero_F[0] = this.Tmp2.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_MainHero_F[0].font = this.TTFont;
    this.Img_Muster[0] = this.Tmp2.GetChild(2).GetComponent<Image>();
    this.text_tmpStr[2] = this.Tmp2.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[2].font = this.TTFont;
    this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(5395U);
    this.text_Dominance[0] = this.Tmp2.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.text_Dominance[0].font = this.TTFont;
    this.Cstr_Dominance[0].ClearString();
    this.text_Dominance[0].text = this.DM.mStringTable.GetStringByID(5320U).ToString();
    this.Img_Country[0] = this.Tmp2.GetChild(4).GetComponent<Image>();
    this.text_Country[0] = this.Tmp2.GetChild(4).GetChild(0).GetComponent<UIText>();
    this.text_Country[0].font = this.TTFont;
    this.Cstr_Country[0].ClearString();
    this.text_Country[0].text = this.Cstr_Country[0].ToString();
    this.Img_Rank[0] = this.Tmp2.GetChild(5).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.Img_Rank[0]).transform.localScale = new Vector3(-1f, ((Component) this.Img_Rank[0]).transform.localScale.y, ((Component) this.Img_Rank[0]).transform.localScale.z);
    int num1 = 0;
    this.Img_Vip[0] = this.Tmp2.GetChild(6).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.Img_Vip[0]).transform.localScale = new Vector3(-1f, ((Component) this.Img_Vip[0]).transform.localScale.y, ((Component) this.Img_Vip[0]).transform.localScale.z);
    this.btn_Coordinate[0] = this.Tmp2.GetChild(7).GetComponent<UIButton>();
    this.btn_Coordinate[0].m_Handler = (IUIButtonClickHandler) this;
    this.btn_Coordinate[0].m_BtnID1 = 8;
    this.text_CoordinateMainHero[0] = this.Tmp2.GetChild(7).GetChild(1).GetComponent<UIText>();
    this.text_CoordinateMainHero[0].font = this.TTFont;
    this.text_Vip[0] = this.Tmp2.GetChild(8).GetComponent<UIText>();
    this.text_Vip[0].font = this.TTFont;
    this.text_Vip[0].text = num1.ToString();
    this.text_Name[0] = this.Tmp2.GetChild(9).GetComponent<UIText>();
    this.text_Name[0].font = this.TTFont;
    this.Cstr_Name[0].ClearString();
    this.Tmp2 = this.Tmp1.GetChild(5);
    this.Img_MainHero[3] = this.Tmp2.GetComponent<Image>();
    this.Img_MainHero[4] = this.Tmp2.GetChild(0).GetChild(0).GetComponent<Image>();
    ((MaskableGraphic) this.Img_MainHero[4]).material = this.IconMaterial;
    this.tmpRC = this.Tmp2.GetChild(0).GetChild(0).GetComponent<RectTransform>();
    this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
    this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
    this.tmpRC.offsetMin = Vector2.zero;
    this.tmpRC.offsetMax = Vector2.zero;
    this.Img_MainHero[5] = this.Tmp2.GetChild(0).GetChild(1).GetComponent<Image>();
    this.Img_MainHero[5].sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, (byte) 11);
    ((MaskableGraphic) this.Img_MainHero[5]).material = this.FrameMaterial;
    this.tmpRC = this.Tmp2.GetChild(0).GetChild(1).GetComponent<RectTransform>();
    this.tmpRC.anchorMin = Vector2.zero;
    this.tmpRC.anchorMax = new Vector2(1f, 1f);
    this.tmpRC.offsetMin = Vector2.zero;
    this.tmpRC.offsetMax = Vector2.zero;
    this.Img_MainTitle[1] = this.Tmp2.GetChild(1).GetComponent<Image>();
    this.text_MainHero_F[1] = this.Tmp2.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_MainHero_F[1].font = this.TTFont;
    this.Img_Muster[1] = this.Tmp2.GetChild(2).GetComponent<Image>();
    this.tmptext = this.Tmp2.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.text_Dominance[1] = this.Tmp2.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.text_Dominance[1].font = this.TTFont;
    this.Cstr_Dominance[1].ClearString();
    this.text_Dominance[1].text = this.Cstr_Dominance[1].ToString();
    this.Img_Country[1] = this.Tmp2.GetChild(4).GetComponent<Image>();
    this.text_Country[1] = this.Tmp2.GetChild(4).GetChild(0).GetComponent<UIText>();
    this.text_Country[1].font = this.TTFont;
    this.Cstr_Country[1].ClearString();
    this.Cstr_Dominance[1].ClearString();
    this.Img_Rank[1] = this.Tmp2.GetChild(5).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.Img_Rank[1]).transform.localScale = new Vector3(-1f, ((Component) this.Img_Rank[1]).transform.localScale.y, ((Component) this.Img_Rank[1]).transform.localScale.z);
    int num2 = 0;
    this.Img_Vip[1] = this.Tmp2.GetChild(6).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.Img_Vip[1]).transform.localScale = new Vector3(-1f, ((Component) this.Img_Vip[1]).transform.localScale.y, ((Component) this.Img_Vip[1]).transform.localScale.z);
    this.btn_Coordinate[1] = this.Tmp2.GetChild(7).GetComponent<UIButton>();
    this.btn_Coordinate[1].m_Handler = (IUIButtonClickHandler) this;
    this.btn_Coordinate[1].m_BtnID1 = 9;
    this.text_CoordinateMainHero[1] = this.Tmp2.GetChild(7).GetChild(1).GetComponent<UIText>();
    this.text_CoordinateMainHero[1].font = this.TTFont;
    this.text_Vip[1] = this.Tmp2.GetChild(8).GetComponent<UIText>();
    this.text_Vip[1].font = this.TTFont;
    this.text_Vip[1].text = num2.ToString();
    this.text_Name[1] = this.Tmp2.GetChild(9).GetComponent<UIText>();
    this.text_Name[1].font = this.TTFont;
    this.Img_Crown[0] = this.Tmp1.GetChild(6).GetComponent<Image>();
    this.Img_Crown[1] = this.Tmp1.GetChild(6).GetChild(0).GetComponent<Image>();
    this.Img_Crown[2] = this.Tmp1.GetChild(7).GetComponent<Image>();
    this.Img_Crown[3] = this.Tmp1.GetChild(7).GetChild(0).GetComponent<Image>();
    this.LightT2 = this.Tmp1.GetChild(8);
    this.Img_Vs = this.Tmp1.GetChild(9).GetChild(0).GetComponent<Image>();
    this.tmpImg = this.Tmp1.GetChild(9).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.tmpImg).transform.localScale = new Vector3(-1f, ((Component) this.tmpImg).transform.localScale.y, ((Component) this.tmpImg).transform.localScale.z);
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
    {
      this.tmpImg.sprite = this.SArray.m_Sprites[17];
      this.Img_Vs.sprite = this.SArray.m_Sprites[18];
    }
    this.text_tmpStr[3] = this.Tmp1.GetChild(10).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[3].font = this.TTFont;
    this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(5321U);
    this.text_tmpStr[4] = this.Tmp1.GetChild(11).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[4].font = this.TTFont;
    this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(5321U);
    this.tmpH -= 41f;
    this.Tmp2 = this.Tmp1.GetChild(16);
    this.Img_NpcMainHero[0] = this.Tmp2.GetComponent<Image>();
    this.Img_NpcMainHero[1] = this.Tmp2.GetChild(0).GetChild(0).GetComponent<Image>();
    ((MaskableGraphic) this.Img_NpcMainHero[1]).material = this.IconMaterial;
    this.tmpRC = this.Tmp2.GetChild(0).GetChild(0).GetComponent<RectTransform>();
    this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
    this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
    this.tmpRC.offsetMin = Vector2.zero;
    this.tmpRC.offsetMax = Vector2.zero;
    this.Img_NpcMainHero[2] = this.Tmp2.GetChild(0).GetChild(1).GetComponent<Image>();
    this.Img_NpcMainHero[2].sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, (byte) 11);
    ((MaskableGraphic) this.Img_NpcMainHero[2]).material = this.FrameMaterial;
    this.tmpRC = this.Tmp2.GetChild(0).GetChild(1).GetComponent<RectTransform>();
    this.tmpRC.anchorMin = Vector2.zero;
    this.tmpRC.anchorMax = new Vector2(1f, 1f);
    this.tmpRC.offsetMin = Vector2.zero;
    this.tmpRC.offsetMax = Vector2.zero;
    this.btn_NpcCoordinate = this.Tmp2.GetChild(1).GetComponent<UIButton>();
    this.btn_NpcCoordinate.m_Handler = (IUIButtonClickHandler) this;
    this.btn_NpcCoordinate.m_BtnID1 = 13;
    this.text_NpcCoordinate = this.Tmp2.GetChild(1).GetChild(1).GetComponent<UIText>();
    this.text_NpcCoordinate.font = this.TTFont;
    this.text_NpcName = this.Tmp2.GetChild(2).GetComponent<UIText>();
    this.text_NpcName.font = this.TTFont;
    this.text_NpcName.fontSize = 30;
    this.text_NpcName.resizeTextMaxSize = 30;
    ((Graphic) this.text_NpcName).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_NpcName).rectTransform.anchoredPosition.x, -143.5f);
    this.Tmp2 = this.Tmp1.GetChild(12);
    this.Img_Army[0] = this.Tmp2.GetComponent<Image>();
    this.Img_Army2[0] = this.Tmp2.GetChild(0).GetComponent<Image>();
    this.text_LossValue[0] = this.Tmp2.GetChild(1).GetComponent<UIText>();
    this.text_LossValue[0].font = this.TTFont;
    this.text_ArmyTitle[0] = this.Tmp2.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_ArmyTitle[0].font = this.TTFont;
    this.text_Strength[0] = this.Tmp2.GetChild(0).GetChild(1).GetComponent<UIText>();
    this.text_Strength[0].font = this.TTFont;
    for (int index = 0; index < 4; ++index)
    {
      this.text_tmpStr[5 + index] = this.Tmp2.GetChild(0).GetChild(2 + index).GetComponent<UIText>();
      this.text_tmpStr[5 + index].font = this.TTFont;
      this.text_tmpStr[5 + index].text = this.DM.mStringTable.GetStringByID((uint) (ushort) (5325 + index));
      this.text_LA[index] = this.Tmp2.GetChild(0).GetChild(6 + index).GetComponent<UIText>();
      this.text_LA[index].font = this.TTFont;
    }
    this.Tmp = this.Tmp2.GetChild(0).GetChild(10);
    this.btn_LF = this.Tmp.GetComponent<UIButton>();
    this.btn_LF.m_Handler = (IUIButtonClickHandler) this;
    this.btn_LF.m_BtnID1 = 12;
    this.tmpbtnHint = ((Component) this.btn_LF).gameObject.AddComponent<UIButtonHint>();
    this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
    this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
    this.tmpbtnHint.DelayTime = 0.3f;
    this.tmpbtnHint.ControlFadeOut = ((Component) this.Img_FormationHint).gameObject;
    this.Tmp = this.Tmp2.GetChild(0).GetChild(10).GetChild(0);
    this.Img_LF = this.Tmp.GetComponent<Image>();
    this.text_LF = this.Tmp2.GetChild(0).GetChild(10).GetChild(1).GetComponent<UIText>();
    this.text_LF.font = this.TTFont;
    this.Tmp = this.Tmp2.GetChild(0).GetChild(11);
    this.text_NpcInfo = this.Tmp.GetComponent<UIText>();
    this.text_NpcInfo.font = this.TTFont;
    this.text_NpcInfo.text = this.DM.mStringTable.GetStringByID(9594U);
    this.Tmp = this.Tmp2.GetChild(0).GetChild(12);
    this.text_NpcTroops[0] = this.Tmp.GetComponent<UIText>();
    this.text_NpcTroops[0].font = this.TTFont;
    this.text_NpcTroops[0].text = this.DM.mStringTable.GetStringByID(9643U);
    this.Tmp = this.Tmp2.GetChild(0).GetChild(13);
    this.text_NpcTroops[1] = this.Tmp.GetComponent<UIText>();
    this.text_NpcTroops[1].font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(13);
    this.Img_Army[1] = this.Tmp2.GetComponent<Image>();
    this.Img_Army2[1] = this.Tmp2.GetChild(0).GetComponent<Image>();
    this.text_LossValue[1] = this.Tmp2.GetChild(1).GetComponent<UIText>();
    this.text_LossValue[1].font = this.TTFont;
    this.text_ArmyTitle[1] = this.Tmp2.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_ArmyTitle[1].font = this.TTFont;
    this.text_Strength[1] = this.Tmp2.GetChild(0).GetChild(1).GetComponent<UIText>();
    this.text_Strength[1].font = this.TTFont;
    for (int index = 0; index < 4; ++index)
    {
      this.text_tmpStr[9 + index] = this.Tmp2.GetChild(0).GetChild(2 + index).GetComponent<UIText>();
      this.text_tmpStr[9 + index].font = this.TTFont;
      this.text_tmpStr[9 + index].text = this.DM.mStringTable.GetStringByID((uint) (ushort) (5325 + index));
      this.text_RA[index] = this.Tmp2.GetChild(0).GetChild(6 + index).GetComponent<UIText>();
      this.text_RA[index].font = this.TTFont;
      this.text_tmpStr[13 + index] = this.Tmp2.GetChild(0).GetChild(10 + index).GetComponent<UIText>();
      this.text_tmpStr[13 + index].font = this.TTFont;
      this.text_tmpStr[13 + index].text = this.DM.mStringTable.GetStringByID((uint) (ushort) (5329 + index));
      this.text_RA[4 + index] = this.Tmp2.GetChild(0).GetChild(14 + index).GetComponent<UIText>();
      this.text_RA[4 + index].font = this.TTFont;
    }
    this.Tmp = this.Tmp2.GetChild(0).GetChild(18);
    this.btn_RF = this.Tmp.GetComponent<UIButton>();
    this.btn_RF.m_Handler = (IUIButtonClickHandler) this;
    this.btn_RF.m_BtnID1 = 12;
    this.tmpbtnHint = ((Component) this.btn_RF).gameObject.AddComponent<UIButtonHint>();
    this.tmpbtnHint.m_eHint = EUIButtonHint.CountDown;
    this.tmpbtnHint.DelayTime = 0.3f;
    this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
    this.tmpbtnHint.ControlFadeOut = ((Component) this.Img_FormationHint).gameObject;
    this.Tmp = this.Tmp2.GetChild(0).GetChild(18).GetChild(0);
    this.Img_RF = this.Tmp.GetComponent<Image>();
    this.text_RF = this.Tmp2.GetChild(0).GetChild(18).GetChild(1).GetComponent<UIText>();
    this.text_RF.font = this.TTFont;
    UIButtonHint.scrollRect = this.m_Mask;
    this.tmpH -= 498f;
    this.Tmp2 = this.Tmp1.GetChild(14);
    this.Img_CWall_P[0] = this.Tmp2.GetComponent<Image>();
    this.Img_CWall[0] = this.Tmp2.GetChild(0).GetComponent<Image>();
    this.text_tmpStr[17] = this.Tmp2.GetChild(1).GetComponent<UIText>();
    this.text_tmpStr[17].font = this.TTFont;
    this.text_tmpStr[17].text = this.DM.mStringTable.GetStringByID(5333U);
    this.text_tmpStr[18] = this.Tmp2.GetChild(2).GetComponent<UIText>();
    this.text_tmpStr[18].font = this.TTFont;
    this.text_tmpStr[18].text = this.DM.mStringTable.GetStringByID(5334U);
    this.Tmp2 = this.Tmp1.GetChild(15);
    this.Img_CWall_P[1] = this.Tmp2.GetComponent<Image>();
    this.Img_CWall[1] = this.Tmp2.GetChild(0).GetComponent<Image>();
    this.text_tmpStr[19] = this.Tmp2.GetChild(1).GetComponent<UIText>();
    this.text_tmpStr[19].font = this.TTFont;
    this.text_tmpStr[19].text = this.DM.mStringTable.GetStringByID(5333U);
    for (int index = 0; index < 3; ++index)
    {
      this.text_tmpStr[20 + index] = this.Tmp2.GetChild(2 + index).GetComponent<UIText>();
      this.text_tmpStr[20 + index].font = this.TTFont;
      this.text_tmpStr[20 + index].text = this.DM.mStringTable.GetStringByID((uint) (ushort) (5335 + index));
      this.text_DW[index] = this.Tmp2.GetChild(5 + index).GetComponent<UIText>();
      this.text_DW[index].font = this.TTFont;
    }
    this.Tmp2 = this.Tmp1.GetChild(19);
    this.btn_Details = this.Tmp2.GetComponent<UIButton>();
    this.btn_Details.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Details.m_BtnID1 = 7;
    this.btn_Details.SoundIndex = (byte) 64;
    this.btn_Details.m_EffectType = e_EffectType.e_Scale;
    this.btn_Details.transition = (Selectable.Transition) 0;
    this.text_tmpStr[23] = this.Tmp2.GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[23].font = this.TTFont;
    this.text_tmpStr[23].text = this.DM.mStringTable.GetStringByID(5396U);
    this.tmpH -= 281f;
    this.Tmp2 = this.Tmp1.GetChild(17);
    this.PetSkillRT_L = this.Tmp2.GetComponent<RectTransform>();
    this.Img_Bf_BG_L[0] = this.Tmp2.GetChild(0).GetComponent<Image>();
    this.Img_Bf_BG_L[1] = this.Tmp2.GetChild(1).GetComponent<Image>();
    this.Img_Bf_BG_L[2] = this.Tmp2.GetChild(1).GetChild(0).GetComponent<Image>();
    for (int index1 = 0; index1 < 2; ++index1)
    {
      Transform child1 = this.Tmp2.GetChild(0).GetChild(index1);
      this.PetSkill_BfIcon_RT_L[index1] = child1.GetComponent<RectTransform>();
      for (int index2 = 0; index2 < 5; ++index2)
      {
        Transform child2 = this.Tmp2.GetChild(0).GetChild(index1).GetChild(index2);
        this.btn_PetSkill_L[index1 * 5 + index2] = child2.GetComponent<UIButton>();
        this.btn_PetSkill_L[index1 * 5 + index2].m_BtnID1 = 15;
        this.btn_PetSkill_L[index1 * 5 + index2].m_BtnID2 = index1 * 5 + index2;
        this.btn_PetSkill_L[index1 * 5 + index2].m_Handler = (IUIButtonClickHandler) this;
        this.tmpbtnHint = ((Component) this.btn_PetSkill_L[index1 * 5 + index2]).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 3;
        Transform child3 = this.Tmp2.GetChild(0).GetChild(index1).GetChild(index2).GetChild(0);
        this.Img_PetSkill_L[index1 * 5 + index2] = child3.GetComponent<Image>();
        ((MaskableGraphic) this.Img_PetSkill_L[index1 * 5 + index2]).material = this.GUIM.GetSkillMaterial();
        this.tmpImg = this.Tmp2.GetChild(0).GetChild(index1).GetChild(index2).GetChild(1).GetComponent<Image>();
        this.tmpImg.sprite = this.GUIM.LoadFrameSprite("sk");
        ((MaskableGraphic) this.tmpImg).material = this.GUIM.GetFrameMaterial();
      }
    }
    for (int index3 = 0; index3 < 2; ++index3)
    {
      Transform child4 = this.Tmp2.GetChild(1).GetChild(1 + index3);
      this.DeBuff_BfIcon_RT_L[index3] = child4.GetComponent<RectTransform>();
      for (int index4 = 0; index4 < 5; ++index4)
      {
        Transform child5 = this.Tmp2.GetChild(1).GetChild(1 + index3).GetChild(index4);
        this.btn_DeBuff_L[index3 * 5 + index4] = child5.GetComponent<UIButton>();
        this.btn_DeBuff_L[index3 * 5 + index4].m_BtnID1 = 15;
        this.btn_DeBuff_L[index3 * 5 + index4].m_BtnID2 = index3 * 5 + index4 + 10;
        this.btn_DeBuff_L[index3 * 5 + index4].m_Handler = (IUIButtonClickHandler) this;
        this.tmpbtnHint = ((Component) this.btn_DeBuff_L[index3 * 5 + index4]).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 3;
        Transform child6 = this.Tmp2.GetChild(1).GetChild(1 + index3).GetChild(index4).GetChild(0);
        this.Img_DeBuff_L[index3 * 5 + index4] = child6.GetComponent<Image>();
        ((MaskableGraphic) this.Img_DeBuff_L[index3 * 5 + index4]).material = this.GUIM.GetSkillMaterial();
        this.tmpImg = this.Tmp2.GetChild(1).GetChild(1 + index3).GetChild(index4).GetChild(1).GetComponent<Image>();
        this.tmpImg.sprite = this.GUIM.LoadFrameSprite("sk");
        ((MaskableGraphic) this.tmpImg).material = this.GUIM.GetFrameMaterial();
      }
    }
    this.text_Buff[0] = this.Tmp2.GetChild(1).GetChild(3).GetComponent<UIText>();
    this.text_Buff[0].font = this.TTFont;
    this.text_Buff[0].text = this.DM.mStringTable.GetStringByID(12553U);
    this.text_Buff[1] = this.Tmp2.GetChild(1).GetChild(4).GetComponent<UIText>();
    this.text_Buff[1].font = this.TTFont;
    this.text_Buff[1].text = this.DM.mStringTable.GetStringByID(5334U);
    this.text_Buff[2] = this.Tmp2.GetChild(2).GetComponent<UIText>();
    this.text_Buff[2].font = this.TTFont;
    this.text_Buff[2].text = this.DM.mStringTable.GetStringByID(10118U);
    this.text_Buff[3] = this.Tmp2.GetChild(3).GetComponent<UIText>();
    this.text_Buff[3].font = this.TTFont;
    this.text_Buff[3].text = this.DM.mStringTable.GetStringByID(5334U);
    this.Tmp2 = this.Tmp1.GetChild(18);
    this.PetSkillRT_R = this.Tmp2.GetComponent<RectTransform>();
    this.Img_Bf_BG_R[0] = this.Tmp2.GetChild(0).GetComponent<Image>();
    this.Img_Bf_BG_R[1] = this.Tmp2.GetChild(1).GetComponent<Image>();
    this.Img_Bf_BG_R[2] = this.Tmp2.GetChild(1).GetChild(0).GetComponent<Image>();
    for (int index5 = 0; index5 < 2; ++index5)
    {
      Transform child7 = this.Tmp2.GetChild(0).GetChild(index5);
      this.PetSkill_BfIcon_RT_R[index5] = child7.GetComponent<RectTransform>();
      for (int index6 = 0; index6 < 5; ++index6)
      {
        Transform child8 = this.Tmp2.GetChild(0).GetChild(index5).GetChild(index6);
        this.btn_PetSkill_R[index5 * 5 + index6] = child8.GetComponent<UIButton>();
        this.btn_PetSkill_R[index5 * 5 + index6].m_BtnID1 = 16;
        this.btn_PetSkill_R[index5 * 5 + index6].m_BtnID2 = index5 * 5 + index6;
        this.btn_PetSkill_R[index5 * 5 + index6].m_Handler = (IUIButtonClickHandler) this;
        this.tmpbtnHint = ((Component) this.btn_PetSkill_R[index5 * 5 + index6]).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 4;
        Transform child9 = this.Tmp2.GetChild(0).GetChild(index5).GetChild(index6).GetChild(0);
        this.Img_PetSkill_R[index5 * 5 + index6] = child9.GetComponent<Image>();
        ((MaskableGraphic) this.Img_PetSkill_R[index5 * 5 + index6]).material = this.GUIM.GetSkillMaterial();
        this.tmpImg = this.Tmp2.GetChild(0).GetChild(index5).GetChild(index6).GetChild(1).GetComponent<Image>();
        this.tmpImg.sprite = this.GUIM.LoadFrameSprite("sk");
        ((MaskableGraphic) this.tmpImg).material = this.GUIM.GetFrameMaterial();
      }
    }
    for (int index7 = 0; index7 < 2; ++index7)
    {
      Transform child10 = this.Tmp2.GetChild(1).GetChild(1 + index7);
      this.DeBuff_BfIcon_RT_R[index7] = child10.GetComponent<RectTransform>();
      for (int index8 = 0; index8 < 5; ++index8)
      {
        Transform child11 = this.Tmp2.GetChild(1).GetChild(1 + index7).GetChild(index8);
        this.btn_DeBuff_R[index7 * 5 + index8] = child11.GetComponent<UIButton>();
        this.btn_DeBuff_R[index7 * 5 + index8].m_BtnID1 = 16;
        this.btn_DeBuff_R[index7 * 5 + index8].m_BtnID2 = index7 * 5 + index8 + 10;
        this.btn_DeBuff_R[index7 * 5 + index8].m_Handler = (IUIButtonClickHandler) this;
        this.tmpbtnHint = ((Component) this.btn_DeBuff_R[index7 * 5 + index8]).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 4;
        Transform child12 = this.Tmp2.GetChild(1).GetChild(1 + index7).GetChild(index8).GetChild(0);
        this.Img_DeBuff_R[index7 * 5 + index8] = child12.GetComponent<Image>();
        ((MaskableGraphic) this.Img_DeBuff_R[index7 * 5 + index8]).material = this.GUIM.GetSkillMaterial();
        this.tmpImg = this.Tmp2.GetChild(1).GetChild(1 + index7).GetChild(index8).GetChild(1).GetComponent<Image>();
        this.tmpImg.sprite = this.GUIM.LoadFrameSprite("sk");
        ((MaskableGraphic) this.tmpImg).material = this.GUIM.GetFrameMaterial();
      }
    }
    this.text_Buff[4] = this.Tmp2.GetChild(1).GetChild(3).GetComponent<UIText>();
    this.text_Buff[4].font = this.TTFont;
    this.text_Buff[4].text = this.DM.mStringTable.GetStringByID(12553U);
    this.text_Buff[5] = this.Tmp2.GetChild(1).GetChild(4).GetComponent<UIText>();
    this.text_Buff[5].font = this.TTFont;
    this.text_Buff[5].text = this.DM.mStringTable.GetStringByID(5334U);
    this.text_Buff[6] = this.Tmp2.GetChild(2).GetComponent<UIText>();
    this.text_Buff[6].font = this.TTFont;
    this.text_Buff[6].text = this.DM.mStringTable.GetStringByID(10118U);
    this.text_Buff[7] = this.Tmp2.GetChild(3).GetComponent<UIText>();
    this.text_Buff[7].font = this.TTFont;
    this.text_Buff[7].text = this.DM.mStringTable.GetStringByID(5334U);
    this.text_Buff[8] = this.Tmp2.GetChild(4).GetComponent<UIText>();
    this.text_Buff[8].font = this.TTFont;
    this.text_Buff[8].text = this.DM.mStringTable.GetStringByID(10100U);
    this.Tmp1 = this.Mask_T.GetChild(0).GetChild(5);
    this.QuanmieRT = this.Tmp1.GetComponent<RectTransform>();
    this.QuanmieRT.anchoredPosition = new Vector2(this.QuanmieRT.anchoredPosition.x, this.tmpH);
    this.Img_Quanmie = this.Tmp1.GetChild(0).GetComponent<Image>();
    for (int index = 0; index < 8; ++index)
    {
      this.text_Quanmie[index] = this.Tmp1.GetChild(0).GetChild(index).GetComponent<UIText>();
      this.text_Quanmie[index].font = this.TTFont;
    }
    this.text_Quanmie[0].text = this.DM.mStringTable.GetStringByID(5323U);
    this.text_QuanmierNpcInfo = this.Tmp1.GetChild(0).GetChild(8).GetComponent<UIText>();
    this.text_QuanmierNpcInfo.font = this.TTFont;
    this.text_QuanmierNpcInfo.text = this.DM.mStringTable.GetStringByID(9594U);
    this.text_QuanmierNpcTroops[0] = this.Tmp1.GetChild(0).GetChild(9).GetComponent<UIText>();
    this.text_QuanmierNpcTroops[0].font = this.TTFont;
    this.text_QuanmierNpcTroops[0].text = this.DM.mStringTable.GetStringByID(9643U);
    this.text_QuanmierNpcTroops[1] = this.Tmp1.GetChild(0).GetChild(10).GetComponent<UIText>();
    this.text_QuanmierNpcTroops[1].font = this.TTFont;
    for (int index = 0; index < 4; ++index)
      this.Cstr_Quanmie[index].ClearString();
    if (this.IsAttack)
    {
      if (!this.bNpcMode)
      {
        this.Cstr_Quanmie[0].uLongToFormat(this.Report.Combat.Summary.AssaultLosePower, bNumber: true);
        StringManager.IntToStr(this.Cstr_Quanmie[1], (long) this.Report.Combat.Summary.AssaultTroopForce, bNumber: true);
        this.text_Quanmie[5].text = this.Cstr_Quanmie[1].ToString();
        StringManager.IntToStr(this.Cstr_Quanmie[2], (long) this.Report.Combat.Summary.AssaultTroopInjure, bNumber: true);
        this.text_Quanmie[6].text = this.Cstr_Quanmie[2].ToString();
        StringManager.IntToStr(this.Cstr_Quanmie[3], (long) this.Report.Combat.Summary.AssaultTroopDeath, bNumber: true);
        this.text_Quanmie[7].text = this.Cstr_Quanmie[3].ToString();
      }
      else
      {
        this.Cstr_Quanmie[0].uLongToFormat(this.Report.NPCCombat.SummaryHead.AssaultLosePower, bNumber: true);
        StringManager.IntToStr(this.Cstr_Quanmie[1], (long) this.Report.NPCCombat.SummaryHead.AssaultTroopForce, bNumber: true);
        this.text_Quanmie[5].text = this.Cstr_Quanmie[1].ToString();
        StringManager.IntToStr(this.Cstr_Quanmie[2], (long) this.Report.NPCCombat.SummaryHead.AssaultTroopInjure, bNumber: true);
        this.text_Quanmie[6].text = this.Cstr_Quanmie[2].ToString();
        StringManager.IntToStr(this.Cstr_Quanmie[3], (long) this.Report.NPCCombat.SummaryHead.AssaultTroopDeath, bNumber: true);
        this.text_Quanmie[7].text = this.Cstr_Quanmie[3].ToString();
      }
    }
    else if (!this.bNpcMode)
    {
      this.Cstr_Quanmie[0].uLongToFormat(this.Report.Combat.Summary.DefenceLosePower, bNumber: true);
      StringManager.IntToStr(this.Cstr_Quanmie[1], (long) this.Report.Combat.Summary.DefenceTroopForce, bNumber: true);
      this.text_Quanmie[5].text = this.Cstr_Quanmie[1].ToString();
      StringManager.IntToStr(this.Cstr_Quanmie[2], (long) this.Report.Combat.Summary.DefenceTroopInjure, bNumber: true);
      this.text_Quanmie[6].text = this.Cstr_Quanmie[2].ToString();
      StringManager.IntToStr(this.Cstr_Quanmie[3], (long) this.Report.Combat.Summary.DefenceTroopDeath, bNumber: true);
      this.text_Quanmie[7].text = this.Cstr_Quanmie[3].ToString();
    }
    this.Cstr_Quanmie[0].AppendFormat(this.DM.mStringTable.GetStringByID(5322U));
    this.text_Quanmie[1].text = this.Cstr_Quanmie[0].ToString();
    this.text_Quanmie[2].text = this.DM.mStringTable.GetStringByID(5325U);
    this.text_Quanmie[3].text = this.DM.mStringTable.GetStringByID(5326U);
    this.text_Quanmie[4].text = this.DM.mStringTable.GetStringByID(5327U);
    for (int index = 0; index < 2; ++index)
      this.Failure_Buff_RT[index] = this.Tmp1.GetChild(index + 1).GetComponent<RectTransform>();
    for (int index9 = 0; index9 < 2; ++index9)
    {
      this.Failure_Skill_RT[index9] = this.Tmp1.GetChild(1).GetChild(index9).GetComponent<RectTransform>();
      for (int index10 = 0; index10 < 5; ++index10)
      {
        this.btn_Failure_Skill[index9 * 5 + index10] = this.Tmp1.GetChild(1).GetChild(index9).GetChild(index10).GetComponent<UIButton>();
        this.btn_Failure_Skill[index9 * 5 + index10].m_BtnID1 = 17;
        this.btn_Failure_Skill[index9 * 5 + index10].m_BtnID2 = index9 * 5 + index10;
        this.btn_Failure_Skill[index9 * 5 + index10].m_Handler = (IUIButtonClickHandler) this;
        this.tmpbtnHint = ((Component) this.btn_Failure_Skill[index9 * 5 + index10]).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 5;
        Transform child = this.Tmp1.GetChild(1).GetChild(index9).GetChild(index10).GetChild(0);
        this.Img_Failure_Skill[index9 * 5 + index10] = child.GetComponent<Image>();
        ((MaskableGraphic) this.Img_Failure_Skill[index9 * 5 + index10]).material = this.GUIM.GetSkillMaterial();
        this.tmpImg = this.Tmp1.GetChild(1).GetChild(index9).GetChild(index10).GetChild(1).GetComponent<Image>();
        this.tmpImg.sprite = this.GUIM.LoadFrameSprite("sk");
        ((MaskableGraphic) this.tmpImg).material = this.GUIM.GetFrameMaterial();
      }
      this.text_FailureBuff[index9] = this.Tmp1.GetChild(1).GetChild(2 + index9).GetComponent<UIText>();
      this.text_FailureBuff[index9].font = this.TTFont;
    }
    this.text_FailureBuff[1].text = this.DM.mStringTable.GetStringByID(10118U);
    for (int index11 = 0; index11 < 2; ++index11)
    {
      this.Failure_DeBuff_RT[index11] = this.Tmp1.GetChild(2).GetChild(index11).GetComponent<RectTransform>();
      for (int index12 = 0; index12 < 5; ++index12)
      {
        this.btn_Failure_DeBuff[index11 * 5 + index12] = this.Tmp1.GetChild(2).GetChild(index11).GetChild(index12).GetComponent<UIButton>();
        this.btn_Failure_DeBuff[index11 * 5 + index12].m_BtnID1 = 17;
        this.btn_Failure_DeBuff[index11 * 5 + index12].m_BtnID2 = index11 * 5 + index12 + 10;
        this.btn_Failure_DeBuff[index11 * 5 + index12].m_Handler = (IUIButtonClickHandler) this;
        this.tmpbtnHint = ((Component) this.btn_Failure_DeBuff[index11 * 5 + index12]).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.tmpbtnHint.Parm1 = (ushort) 5;
        Transform child = this.Tmp1.GetChild(2).GetChild(index11).GetChild(index12).GetChild(0);
        this.Img_Failure_DeBuff[index11 * 5 + index12] = child.GetComponent<Image>();
        ((MaskableGraphic) this.Img_Failure_DeBuff[index11 * 5 + index12]).material = this.GUIM.GetSkillMaterial();
        this.tmpImg = this.Tmp1.GetChild(2).GetChild(index11).GetChild(index12).GetChild(1).GetComponent<Image>();
        this.tmpImg.sprite = this.GUIM.LoadFrameSprite("sk");
        ((MaskableGraphic) this.tmpImg).material = this.GUIM.GetFrameMaterial();
      }
    }
    this.text_FailureBuff[2] = this.Tmp1.GetChild(2).GetChild(2).GetComponent<UIText>();
    this.text_FailureBuff[2].font = this.TTFont;
    this.text_FailureBuff[2].text = this.DM.mStringTable.GetStringByID(12553U);
    this.text_FightingKind = this.Tmp1.GetChild(3).GetComponent<UIText>();
    this.text_FightingKind.font = this.TTFont;
    this.text_FightingKind.text = this.DM.mStringTable.GetStringByID(5385U);
    this.SetPorfileBtn();
  }

  public void InitBossComponent()
  {
    UIButtonHint.scrollRect = this.m_Mask;
    this.Tmp1 = this.Mask_T.GetChild(0).GetChild(6);
    this.BossRT = this.Tmp1.GetComponent<RectTransform>();
    this.Tmp2 = this.Tmp1.GetChild(0).GetChild(0);
    this.text_BossTitle[0] = this.Tmp2.GetComponent<UIText>();
    this.text_BossTitle[0].font = this.TTFont;
    this.text_BossTitle[0].text = this.DM.mStringTable.GetStringByID(8229U);
    this.Tmp2 = this.Tmp1.GetChild(1).GetChild(0);
    this.text_BossTitle[1] = this.Tmp2.GetComponent<UIText>();
    this.text_BossTitle[1].font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(2).GetChild(1);
    this.btn_Boss_Hero = this.Tmp2.GetComponent<UIHIBtn>();
    this.GUIM.InitianHeroItemImg(((Component) this.btn_Boss_Hero).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 11, (byte) 0);
    this.Tmp2 = this.Tmp1.GetChild(2).GetChild(2);
    this.Img_BossHeroCrown[0] = this.Tmp2.GetComponent<Image>();
    this.Tmp2 = this.Tmp1.GetChild(2).GetChild(2).GetChild(0);
    this.Img_BossHeroCrown[1] = this.Tmp2.GetComponent<Image>();
    this.Tmp2 = this.Tmp1.GetChild(2).GetChild(3);
    this.text_BossL[0] = this.Tmp2.GetComponent<UIText>();
    this.text_BossL[0].font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(2).GetChild(4);
    this.text_BossL[1] = this.Tmp2.GetComponent<UIText>();
    this.text_BossL[1].font = this.TTFont;
    this.BossIconT = this.Tmp1.GetChild(3).GetChild(1);
    this.BossIconT.gameObject.SetActive(true);
    this.Img_BossIcon[0] = this.BossIconT.GetChild(0).GetComponent<Image>();
    ((MaskableGraphic) this.Img_BossIcon[0]).material = this.FrameMaterial;
    this.tmpRC = this.BossIconT.GetChild(0).GetComponent<RectTransform>();
    this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
    this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
    this.tmpRC.offsetMin = Vector2.zero;
    this.tmpRC.offsetMax = Vector2.zero;
    this.Img_BossIcon[1] = this.BossIconT.GetChild(1).GetComponent<Image>();
    this.Img_BossIcon[1].sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, (byte) 11);
    ((MaskableGraphic) this.Img_BossIcon[1]).material = this.FrameMaterial;
    this.tmpRC = this.BossIconT.GetChild(1).GetComponent<RectTransform>();
    this.tmpRC.anchorMin = Vector2.zero;
    this.tmpRC.anchorMax = new Vector2(1f, 1f);
    this.tmpRC.offsetMin = Vector2.zero;
    this.tmpRC.offsetMax = Vector2.zero;
    this.Tmp2 = this.Tmp1.GetChild(3).GetChild(2).GetChild(0);
    this.text_BossR[0] = this.Tmp2.GetComponent<UIText>();
    this.text_BossR[0].font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(3).GetChild(3).GetChild(0);
    this.BossBloodRT = this.Tmp2.GetComponent<RectTransform>();
    this.Tmp2 = this.Tmp1.GetChild(3).GetChild(3).GetChild(1);
    this.text_BossR[1] = this.Tmp2.GetComponent<UIText>();
    this.text_BossR[1].font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(3).GetChild(4);
    this.text_BossR[2] = this.Tmp2.GetComponent<UIText>();
    this.text_BossR[2].font = this.TTFont;
    this.LightBossT = this.Tmp1.GetChild(4);
    this.Tmp2 = this.Tmp1.GetChild(5).GetChild(0);
    this.Img_BossVs = this.Tmp2.GetComponent<Image>();
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
    {
      this.tmpImg = this.Tmp1.GetChild(5).GetComponent<Image>();
      this.tmpImg.sprite = this.SArray.m_Sprites[17];
      this.Img_BossVs.sprite = this.SArray.m_Sprites[18];
    }
    if (this.GUIM.IsArabic)
    {
      this.tmpImg = this.Tmp1.GetChild(5).GetComponent<Image>();
      ((Transform) ((Graphic) this.tmpImg).rectTransform).localScale = new Vector3(-((Transform) ((Graphic) this.tmpImg).rectTransform).localScale.x, ((Transform) ((Graphic) this.tmpImg).rectTransform).localScale.y, ((Transform) ((Graphic) this.tmpImg).rectTransform).localScale.z);
    }
    this.Tmp2 = this.Tmp1.GetChild(6).GetChild(0);
    this.text_tmpStr[24] = this.Tmp2.GetComponent<UIText>();
    this.text_tmpStr[24].font = this.TTFont;
    this.text_tmpStr[24].text = this.DM.mStringTable.GetStringByID(8227U);
    this.Tmp2 = this.Tmp1.GetChild(7).GetChild(0);
    this.text_BossFight[0] = this.Tmp2.GetComponent<UIText>();
    this.text_BossFight[0].font = this.TTFont;
    this.text_BossFight[0].text = this.DM.mStringTable.GetStringByID(8222U);
    this.Tmp2 = this.Tmp1.GetChild(7).GetChild(1);
    this.text_BossFight[1] = this.Tmp2.GetComponent<UIText>();
    this.text_BossFight[1].font = this.TTFont;
    this.Tmp2 = this.Tmp1.GetChild(7).GetChild(2);
    this.text_BossFight[2] = this.Tmp2.GetComponent<UIText>();
    this.text_BossFight[2].font = this.TTFont;
  }

  public override void OnClose()
  {
    if (this.Cstr_TitleName != null)
      StringManager.Instance.DeSpawnString(this.Cstr_TitleName);
    if (this.Cstr_Page != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Page);
    if (this.Cstr_FightingKind != null)
      StringManager.Instance.DeSpawnString(this.Cstr_FightingKind);
    if (this.Cstr_L_Exp != null)
      StringManager.Instance.DeSpawnString(this.Cstr_L_Exp);
    if (this.Cstr_BoosHead != null)
      StringManager.Instance.DeSpawnString(this.Cstr_BoosHead);
    if (this.Cstr_Text != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Text);
    if (this.Cstr_NpcTroops != null)
      StringManager.Instance.DeSpawnString(this.Cstr_NpcTroops);
    if (this.Cstr_QuanmieNpcTroops != null)
      StringManager.Instance.DeSpawnString(this.Cstr_QuanmieNpcTroops);
    if (this.Cstr_LF != null)
      StringManager.Instance.DeSpawnString(this.Cstr_LF);
    if (this.Cstr_RF != null)
      StringManager.Instance.DeSpawnString(this.Cstr_RF);
    for (int index = 0; index < 4; ++index)
    {
      if (this.Cstr_Quanmie[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Quanmie[index]);
    }
    for (int index = 0; index < 30; ++index)
    {
      if (this.Cstr_ItemQty[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemQty[index]);
    }
    for (int index = 0; index < 2; ++index)
    {
      if (this.Cstr_Coordinate[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Coordinate[index]);
      if (this.Cstr_Offensive[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Offensive[index]);
      if (this.Cstr_LossValue[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_LossValue[index]);
      if (this.Cstr_Strength[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Strength[index]);
      if (this.Cstr_Country[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Country[index]);
      if (this.Cstr_Dominance[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Dominance[index]);
      if (this.Cstr_CoordinateMainHero[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_CoordinateMainHero[index]);
      if (this.Cstr_Name[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Name[index]);
      if (this.Cstr_BossR[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_BossR[index]);
      if (this.Cstr_BossFight[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_BossFight[index]);
      if (this.Cstr_BossL[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_BossL[index]);
    }
    for (int index = 0; index < 8; ++index)
    {
      if (this.Cstr_RA[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_RA[index]);
    }
    for (int index = 0; index < 4; ++index)
    {
      if (this.Cstr_LA[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_LA[index]);
    }
    for (int index = 0; index < 3; ++index)
    {
      if (this.Cstr_DW[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_DW[index]);
    }
    for (int index = 0; index < 5; ++index)
    {
      if (this.Cstr_Resources[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Resources[index]);
      if (this.StrResources[index] != null)
        StringManager.Instance.DeSpawnString(this.StrResources[index]);
      if (this.Cstr_HeroExp[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_HeroExp[index]);
    }
    if (this.DM.mSaveInfo == (byte) 1)
      ++this.DM.mSaveInfo;
    if (this.AssetKey != 0)
      AssetManager.UnloadAssetBundle(this.AssetKey, false);
    this.AssetKey = 0;
    if (this.bSaveY)
    {
      this.DM.LetterFs_Y = this.ContentRT.anchoredPosition.y;
      this.DM.mFs_Serial = this.Favor.Serial;
    }
    else
      this.DM.LetterFs_Y = -1f;
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
        if (this.mOpenKind == 0)
        {
          if (!this.bNpcMode)
          {
            if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
            {
              this.door.GoToPointCode(this.Report.Combat.KingdomID, this.Report.Combat.CombatlZone, this.Report.Combat.CombatPoint, (byte) 0);
              break;
            }
            this.door.GoToWonder(this.Report.Combat.KingdomID, this.Report.Combat.CombatPoint);
            break;
          }
          if (this.Report.NPCCombat.CombatPointKind != POINT_KIND.PK_YOLK)
          {
            this.door.GoToPointCode(this.Report.NPCCombat.KingdomID, this.Report.NPCCombat.CombatlZone, this.Report.NPCCombat.CombatPoint, (byte) 0);
            break;
          }
          this.door.GoToWonder(this.Report.NPCCombat.KingdomID, this.Report.NPCCombat.CombatPoint);
          break;
        }
        this.door.GoToPointCode(this.Report.Monster.KindgomID, this.Report.Monster.Zone, this.Report.Monster.Point, (byte) 0);
        break;
      case 4:
        if (!this.DM.BattleReportDelete(this.Report.SerialID))
          break;
        this.door.CloseMenu();
        break;
      case 5:
        if (this.Favor.Kind == MailType.EMAIL_FAVORY)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(6100U), (ushort) byte.MaxValue);
          break;
        }
        this.DM.BattleReportSave(this.Report.SerialID);
        break;
      case 6:
        if (this.bQuanmier)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5385U), (ushort) byte.MaxValue);
          break;
        }
        if (this.mOpenKind == 0)
        {
          if (!this.bNpcMode && !WarManager.CheckVersion(this.Report.Combat.Version, this.Report.Combat.PatchNo) || this.bNpcMode && !WarManager.CheckVersion(this.Report.NPCCombat.Version, this.Report.NPCCombat.PatchNo))
            break;
          if (!this.bNpcMode)
          {
            this.GUIM.bClearWindowStack = false;
            this.DM.bWarAttacker = this.IsAttack;
            this.DM.KindomID_War[0] = this.Report.Combat.AssaultKingdomID;
            this.DM.KindomID_War[1] = this.Report.Combat.DefenceKingdomID;
            this.DM.PlayerName_War[0].ClearString();
            this.DM.PlayerName_War[0].Append(this.Report.Combat.AssaultName);
            this.DM.PlayerName_War[1].ClearString();
            this.DM.PlayerName_War[1].Append(this.Report.Combat.DefenceName);
            this.DM.AllianceTag_War[0].ClearString();
            this.DM.AllianceTag_War[0].Append(this.Report.Combat.AssaultAllianceTag);
            this.DM.AllianceTag_War[1].ClearString();
            this.DM.AllianceTag_War[1].Append(this.Report.Combat.DefenceAllianceTag);
            WarManager.CurrentPointKind = this.Report.Combat.CombatPointKind;
            WarManager.UpdateLocalTimeToTheme(this.Report.Times);
            WarManager.CheckMorale(this.Report);
            this.DM.CombatReplay(this.Report.Combat.DetailAutoID, this.Report.Combat.DetailDbServerID, this.Report.Combat.AccessKey);
          }
          else
          {
            this.GUIM.bClearWindowStack = false;
            this.DM.bWarAttacker = this.IsAttack;
            this.DM.KindomID_War[0] = this.Report.NPCCombat.AssaultKingdomID;
            this.DM.KindomID_War[1] = this.Report.NPCCombat.KingdomID;
            this.DM.PlayerName_War[0].ClearString();
            this.DM.PlayerName_War[0].Append(this.Report.NPCCombat.AssaultName);
            this.DM.PlayerName_War[1].ClearString();
            this.DM.PlayerName_War[1].IntToFormat((long) this.Report.NPCCombat.NPCLevel);
            this.DM.PlayerName_War[1].AppendFormat(this.DM.mStringTable.GetStringByID(12021U));
            this.DM.AllianceTag_War[0].ClearString();
            this.DM.AllianceTag_War[0].Append(this.Report.NPCCombat.AssaultAllianceTag);
            this.DM.AllianceTag_War[1].ClearString();
            WarManager.CurrentPointKind = this.Report.NPCCombat.CombatPointKind;
            WarManager.UpdateLocalTimeToTheme(this.Report.Times);
            WarManager.CheckNPCMorale(this.Report);
            this.DM.CombatReplay(this.Report.NPCCombat.DetailAutoID, this.Report.NPCCombat.DetailDbServerID, this.Report.NPCCombat.AccessKey, true);
          }
        }
        else if (this.mOpenKind == 1)
        {
          if (!WarManager.CheckVersion(this.Report.Monster.Version, this.Report.Monster.PatchNo))
            break;
          if (!this.DM.CheckMonsterResourceReady(this.Report.Monster.MonsterID))
          {
            this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8350U), (ushort) byte.MaxValue);
            break;
          }
          if (!this.DM.CheckHeroBattleResourceReady(HeroFightType.MonsterBattle, this.Report.Monster.HeroID))
          {
            GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(8350U), (ushort) byte.MaxValue);
            break;
          }
          GUIManager instance = GUIManager.Instance;
          instance.bClearWindowStack = false;
          instance.WM_RandomSeed = this.Report.Monster.RandomSeed;
          instance.WM_RandomGap = this.Report.Monster.RandomGap;
          instance.WM_HeroCount = (byte) 0;
          for (int index = 0; index < 5; ++index)
          {
            instance.WM_HeroData[index].HeroID = this.Report.Monster.HeroID[index];
            if (instance.WM_HeroData[index].HeroID != (ushort) 0)
              ++instance.WM_HeroCount;
          }
          for (int index = 0; index < 5; ++index)
          {
            instance.WM_HeroData[index].AttrData.SkillLV1 = this.Report.Monster.HeroData[index].SkillLV1;
            instance.WM_HeroData[index].AttrData.SkillLV2 = this.Report.Monster.HeroData[index].SkillLV2;
            instance.WM_HeroData[index].AttrData.SkillLV3 = this.Report.Monster.HeroData[index].SkillLV3;
            instance.WM_HeroData[index].AttrData.SkillLV4 = this.Report.Monster.HeroData[index].SkillLV4;
            instance.WM_HeroData[index].AttrData.LV = this.Report.Monster.HeroData[index].LV;
            instance.WM_HeroData[index].AttrData.Star = this.Report.Monster.HeroData[index].Star;
            instance.WM_HeroData[index].AttrData.Enhance = this.Report.Monster.HeroData[index].Enhance;
            instance.WM_HeroData[index].AttrData.Equip = this.Report.Monster.HeroData[index].Equip;
          }
          instance.WM_MonsterID = this.Report.Monster.MonsterID;
          instance.WM_MonsterLv = this.Report.Monster.MonsterLv;
          instance.WM_MonsterNowHP = this.Report.Monster.BeginHPPercent;
          instance.WM_MonsterMaxHP = this.Report.Monster.MonsterMaxHP;
          instance.WM_MonsterAttr.ActionTimes = this.Report.Monster.AttrScale.ActionTimes;
          instance.WM_MonsterAttr.SequentialDamageScale = this.Report.Monster.AttrScale.SequentialDamageScale;
          instance.WM_MonsterAttr.DamageScale = this.Report.Monster.AttrScale.DamageScale;
          instance.WM_MonsterAttr.MaxHPScale = this.Report.Monster.AttrScale.MaxHPScale;
          instance.WM_MonsterAttr.HealingScale = this.Report.Monster.AttrScale.HealingScale;
          instance.WM_MonsterAttr.InitMP = this.Report.Monster.AttrScale.InitMP;
          BattleController.BattleMode = EBattleMode.Monster;
          instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MonsterBattle);
        }
        AudioManager.Instance.PlayMP3SFX((ushort) 41032);
        break;
      case 7:
        GUIManager.Instance.ShowUILock(EUILock.Mailing_Battle);
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        if (!this.bNpcMode)
        {
          messagePacket.Protocol = Protocol._MSG_REQUEST_COMBATDETAIL;
          messagePacket.AddSeqId();
          messagePacket.Add(this.Report.Combat.DetailAutoID);
          messagePacket.Add(this.Report.Combat.DetailDbServerID);
          messagePacket.Add(this.Report.Combat.AccessKey);
          messagePacket.Send();
          this.DM.mFs_Main[0] = this.Report.Combat.Summary.AssaultLordInCombat;
          this.DM.mFs_Main[1] = this.Report.Combat.Summary.DefenceLordInCombat;
          this.DM.mFs_Side = this.Report.Combat.Side;
        }
        else
        {
          messagePacket.Protocol = Protocol._MSG_REQUEST_COMBATDETAIL_NPCCITY;
          messagePacket.AddSeqId();
          messagePacket.Add(this.Report.NPCCombat.DetailAutoID);
          messagePacket.Add(this.Report.NPCCombat.DetailDbServerID);
          messagePacket.Add(this.Report.NPCCombat.AccessKey);
          messagePacket.Send();
          this.DM.mFs_Main[0] = this.Report.NPCCombat.Summary.AssaultLordInCombat;
          this.DM.mFs_Main[1] = (byte) 1;
          this.DM.mFs_D_MHIdx = (byte) 0;
          this.DM.mFs_Side = this.Report.NPCCombat.Side;
        }
        this.bSaveY = true;
        this.DM.mSaveInfo = (byte) 1;
        break;
      case 8:
        if (!this.bNpcMode)
        {
          this.door.GoToPointCode(this.Report.Combat.KingdomID, this.Report.Combat.Summary.AssaultCapitalZone, this.Report.Combat.Summary.AssaultCapitalPoint, (byte) 0);
          break;
        }
        this.door.GoToPointCode(this.Report.NPCCombat.KingdomID, this.Report.NPCCombat.SummaryHead.AssaultCapitalZone, this.Report.NPCCombat.SummaryHead.AssaultCapitalPoint, (byte) 0);
        break;
      case 9:
        if (!this.bNpcMode)
        {
          if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
          {
            this.door.GoToPointCode(this.Report.Combat.KingdomID, this.Report.Combat.Summary.DefenceCapitalZone, this.Report.Combat.Summary.DefenceCapitalPoint, (byte) 0);
            break;
          }
          this.door.GoToWonder(this.Report.Combat.KingdomID, this.Report.Combat.CombatPoint);
          break;
        }
        if (this.Report.NPCCombat.CombatPointKind != POINT_KIND.PK_YOLK)
        {
          this.door.GoToPointCode(this.Report.NPCCombat.KingdomID, this.Report.NPCCombat.SummaryHead.DefenceCapitalZone, this.Report.NPCCombat.SummaryHead.DefenceCapitalPoint, (byte) 0);
          break;
        }
        this.door.GoToWonder(this.Report.NPCCombat.KingdomID, this.Report.NPCCombat.CombatPoint);
        break;
      case 10:
      case 11:
        this.ShowLordProfile((FightingSummary_btn) sender.m_BtnID1);
        break;
      case 13:
        this.door.GoToPointCode(this.Report.NPCCombat.KingdomID, this.Report.NPCCombat.SummaryHead.DefenceCapitalZone, this.Report.NPCCombat.SummaryHead.DefenceCapitalPoint, (byte) 0);
        break;
    }
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
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
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
        break;
      case MailType.EMAIL_BATTLE:
        this.DM.OpenMail.Serial = this.Favor.Serial;
        this.DM.OpenMail.Type = this.Favor.Type;
        this.DM.OpenMail.Kind = this.Favor.Kind;
        switch (this.Favor.Combat.Type)
        {
          case CombatCollectReport.CCR_BATTLE:
          case CombatCollectReport.CCR_NPCCOMBAT:
            this.m_Mask.StopMovement();
            this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, 0.0f);
            this.Favor.Serial = this.DM.OpenMail.Serial;
            this.Favor.Type = this.DM.OpenMail.Type;
            this.Favor.Kind = this.DM.OpenMail.Kind;
            if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
            {
              this.Report = this.Favor.Combat;
              if (!this.Report.BeRead)
              {
                if (this.Favor.Kind == MailType.EMAIL_BATTLE)
                  this.DM.BattleReportRead(this.Report.SerialID);
                else
                  this.DM.FavorReportRead(this.Report.SerialID);
              }
              this.bNpcMode = this.Report.Type == CombatCollectReport.CCR_NPCCOMBAT;
              Array.Clear((Array) this.m_A_Skill_ID, 0, this.m_A_Skill_ID.Length);
              Array.Clear((Array) this.m_A_Skill_LV, 0, this.m_A_Skill_LV.Length);
              Array.Clear((Array) this.m_A_DeBf_Skill_ID, 0, this.m_A_DeBf_Skill_ID.Length);
              Array.Clear((Array) this.m_A_DeBf_Skill_LV, 0, this.m_A_DeBf_Skill_LV.Length);
              Array.Clear((Array) this.m_D_Skill_ID, 0, this.m_D_Skill_ID.Length);
              Array.Clear((Array) this.m_D_Skill_LV, 0, this.m_A_Skill_ID.Length);
              Array.Clear((Array) this.m_D_DeBf_Skill_ID, 0, this.m_D_DeBf_Skill_ID.Length);
              Array.Clear((Array) this.m_D_DeBf_Skill_LV, 0, this.m_D_DeBf_Skill_LV.Length);
              this.mA_Skill_L = 0;
              this.mDeBf_A_L = 0;
              this.mD_Skill_R = 0;
              this.mDeBf_D_R = 0;
              if (!this.bNpcMode)
              {
                this.bWin = this.Report.Combat.Result == CombatReportResultType.ECRR_COMBATVICTORY || this.Report.Combat.Result == CombatReportResultType.ECRR_DEFENDVICTORY || this.Report.Combat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER || this.Report.Combat.Result == CombatReportResultType.ECRR_WONDERVICTORY;
                this.IsAttack = this.Report.Combat.Side == (byte) 0 || this.Report.Combat.Side == (byte) 2 || this.Report.Combat.Side == (byte) 4 || this.Report.Combat.Side == (byte) 6;
                this.mType = (int) this.Report.Combat.Result;
                this.bQuanmier = this.mType >= 4 && this.mType <= 7;
                this.bDoNotShow = false;
                if ((int) this.Report.Combat.PetSkillPatchNo != (int) this.DM.PetVersionNo)
                  this.bDoNotShow = true;
                for (int index = 0; index < 20; ++index)
                {
                  if (this.Report.Combat.m_AssaultPetSkill_ID[index] > (ushort) 0)
                  {
                    if (this.mA_Skill_L < this.m_A_Skill_ID.Length && this.PM.PetSkillTable.GetRecordByKey(this.Report.Combat.m_AssaultPetSkill_ID[index]).Subject == (byte) 1)
                    {
                      this.m_A_Skill_ID[this.mA_Skill_L] = this.Report.Combat.m_AssaultPetSkill_ID[index];
                      this.m_A_Skill_LV[this.mA_Skill_L] = this.Report.Combat.m_AssaultPetSkill_LV[index];
                      ++this.mA_Skill_L;
                    }
                    else if (this.mDeBf_A_L < this.m_A_DeBf_Skill_ID.Length)
                    {
                      this.m_A_DeBf_Skill_ID[this.mDeBf_A_L] = this.Report.Combat.m_AssaultPetSkill_ID[index];
                      this.m_A_DeBf_Skill_LV[this.mDeBf_A_L] = this.Report.Combat.m_AssaultPetSkill_LV[index];
                      ++this.mDeBf_A_L;
                    }
                  }
                  if (this.Report.Combat.m_DefencePetSkill_ID[index] > (ushort) 0)
                  {
                    if (this.mD_Skill_R < this.m_D_Skill_ID.Length && this.PM.PetSkillTable.GetRecordByKey(this.Report.Combat.m_AssaultPetSkill_ID[index]).Subject == (byte) 1)
                    {
                      this.m_D_Skill_ID[this.mD_Skill_R] = this.Report.Combat.m_DefencePetSkill_ID[index];
                      this.m_D_Skill_LV[this.mD_Skill_R] = this.Report.Combat.m_DefencePetSkill_LV[index];
                      ++this.mD_Skill_R;
                    }
                    else if (this.mDeBf_D_R < this.m_D_DeBf_Skill_ID.Length)
                    {
                      this.m_D_DeBf_Skill_ID[this.mDeBf_D_R] = this.Report.Combat.m_DefencePetSkill_ID[index];
                      this.m_D_DeBf_Skill_LV[this.mDeBf_D_R] = this.Report.Combat.m_DefencePetSkill_LV[index];
                      ++this.mDeBf_D_R;
                    }
                  }
                }
              }
              else
              {
                this.bWin = this.Report.NPCCombat.Result == CombatReportResultType.ECRR_COMBATVICTORY || this.Report.NPCCombat.Result == CombatReportResultType.ECRR_DEFENDVICTORY || this.Report.NPCCombat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER || this.Report.NPCCombat.Result == CombatReportResultType.ECRR_WONDERVICTORY;
                this.IsAttack = this.Report.NPCCombat.Side == (byte) 0 || this.Report.NPCCombat.Side == (byte) 2 || this.Report.NPCCombat.Side == (byte) 4 || this.Report.NPCCombat.Side == (byte) 6;
                this.mType = (int) this.Report.NPCCombat.Result;
                this.bQuanmier = this.mType >= 4 && this.mType <= 7;
                this.bDoNotShow = false;
                if ((int) this.Report.NPCCombat.PetSkillPatchNo != (int) this.DM.PetVersionNo)
                  this.bDoNotShow = true;
                for (int index = 0; index < 20; ++index)
                {
                  if (this.Report.NPCCombat.m_AssaultPetSkill_ID[index] > (ushort) 0)
                  {
                    if (this.mA_Skill_L < this.m_A_Skill_ID.Length && this.PM.PetSkillTable.GetRecordByKey(this.Report.NPCCombat.m_AssaultPetSkill_ID[index]).Subject == (byte) 1)
                    {
                      this.m_A_Skill_ID[this.mA_Skill_L] = this.Report.NPCCombat.m_AssaultPetSkill_ID[index];
                      this.m_A_Skill_LV[this.mA_Skill_L] = this.Report.NPCCombat.m_AssaultPetSkill_LV[index];
                      ++this.mA_Skill_L;
                    }
                    else if (this.mDeBf_A_L < this.m_A_DeBf_Skill_ID.Length)
                    {
                      this.m_A_DeBf_Skill_ID[this.mDeBf_A_L] = this.Report.NPCCombat.m_AssaultPetSkill_ID[index];
                      this.m_A_DeBf_Skill_LV[this.mDeBf_A_L] = this.Report.NPCCombat.m_AssaultPetSkill_LV[index];
                      ++this.mDeBf_A_L;
                    }
                  }
                }
              }
            }
            this.mOpenKind = 0;
            if (!this.bInitFS)
            {
              this.bInitFS = true;
              this.InitFSComponent();
            }
            this.DM.LetterFs_Y = -1f;
            this.SetPageData();
            return;
          case CombatCollectReport.CCR_RESOURCE:
            this.door.OpenMenu(EGUIWindow.UI_Letter_Resources);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
            return;
          case CombatCollectReport.CCR_COLLECT:
            this.door.OpenMenu(EGUIWindow.UI_Letter_Collection);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
            return;
          case CombatCollectReport.CCR_SCOUT:
            if (this.Favor.Combat.Scout.ScoutLevel != (byte) 0)
              this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower);
            else
              this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 1);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
            return;
          case CombatCollectReport.CCR_RECON:
            this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
            return;
          case CombatCollectReport.CCR_MONSTER:
            this.bNpcMode = false;
            if (this.Favor.Combat.Monster.Result < (byte) 2 || this.Favor.Combat.Monster.Result > (byte) 3)
            {
              this.m_Mask.StopMovement();
              this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, 0.0f);
              if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
              {
                this.Report = this.Favor.Combat;
                if (!this.Report.BeRead)
                {
                  if (this.Favor.Kind == MailType.EMAIL_BATTLE)
                    this.DM.BattleReportRead(this.Report.SerialID);
                  else
                    this.DM.FavorReportRead(this.Report.SerialID);
                }
              }
              this.Favor.Serial = this.DM.OpenMail.Serial;
              this.Favor.Type = this.DM.OpenMail.Type;
              this.Favor.Kind = this.DM.OpenMail.Kind;
              if (this.DM.MailReportGet(ref this.Favor) && this.Favor.Type == MailType.EMAIL_BATTLE)
                this.Report = this.Favor.Combat;
              this.mOpenKind = 1;
              this.bQuanmier = false;
              if (!this.bInitBoss)
              {
                this.bInitBoss = true;
                this.InitBossComponent();
              }
              this.SetPageData();
              return;
            }
            this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
            return;
          case CombatCollectReport.CCR_NPCSCOUT:
            this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
            return;
          case CombatCollectReport.CCR_PETREPORT:
            this.door.OpenMenu(EGUIWindow.UI_PetSkill_FS);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
            return;
          default:
            return;
        }
      case MailType.EMAIL_LETTER:
        this.DM.OpenMail.Serial = this.Favor.Serial;
        this.DM.OpenMail.Type = this.Favor.Type;
        this.DM.OpenMail.Kind = this.Favor.Kind;
        this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
        this.DM.RemoveDoorUIStack(EGUIWindow.UI_FightingSummary);
        break;
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
      return;
    bool flag = false;
    Equip recordByKey = this.DM.EquipTable.GetRecordByKey((ushort) sender.m_BtnID2);
    if (recordByKey.EquipKind == (byte) 19)
      flag = true;
    else if (recordByKey.EquipKind == (byte) 18 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 4)
      flag = true;
    else if (recordByKey.EquipKind == (byte) 18 && (recordByKey.PropertiesInfo[2].Propertieskey < (ushort) 1 || recordByKey.PropertiesInfo[2].Propertieskey > (ushort) 3))
      flag = true;
    if (!flag)
      return;
    this.DM.BossOpen_Y = this.ContentRT.anchoredPosition.y;
    this.door.OpenMenu(EGUIWindow.UI_OpenBox, 1, sender.m_BtnID2);
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    switch (button.m_BtnID1)
    {
      case 12:
        sender.GetTipPosition(((Graphic) this.Img_FormationHint).rectTransform);
        ((Component) this.Img_FormationHint).gameObject.SetActive(true);
        break;
      case 14:
        ((Component) this.Img_NpcItemHint).gameObject.SetActive(true);
        break;
    }
    if (sender.Parm1 == (ushort) 3)
    {
      if (button.m_BtnID2 < 10)
      {
        this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Mail, (ushort) 0, this.m_A_Skill_ID[button.m_BtnID2], this.m_A_Skill_LV[button.m_BtnID2], Vector2.zero);
      }
      else
      {
        if (button.m_BtnID2 - 10 < 0 || button.m_BtnID2 - 10 >= this.m_A_DeBf_Skill_ID.Length)
          return;
        this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Mail, (ushort) 0, this.m_A_DeBf_Skill_ID[button.m_BtnID2 - 10], this.m_A_DeBf_Skill_LV[button.m_BtnID2 - 10], Vector2.zero);
      }
    }
    else if (sender.Parm1 == (ushort) 4)
    {
      if (button.m_BtnID2 < 10)
      {
        this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Mail, (ushort) 0, this.m_D_Skill_ID[button.m_BtnID2], this.m_D_Skill_LV[button.m_BtnID2], Vector2.zero);
      }
      else
      {
        if (button.m_BtnID2 - 10 < 0 || button.m_BtnID2 - 10 >= this.m_D_DeBf_Skill_ID.Length)
          return;
        this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Mail, (ushort) 0, this.m_D_DeBf_Skill_ID[button.m_BtnID2 - 10], this.m_D_DeBf_Skill_LV[button.m_BtnID2 - 10], Vector2.zero);
      }
    }
    else
    {
      if (sender.Parm1 != (ushort) 5)
        return;
      if (this.IsAttack)
      {
        if (button.m_BtnID2 < 10)
        {
          this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Mail, (ushort) 0, this.m_A_Skill_ID[button.m_BtnID2], this.m_A_Skill_LV[button.m_BtnID2], Vector2.zero);
        }
        else
        {
          if (button.m_BtnID2 - 10 < 0 || button.m_BtnID2 - 10 >= this.m_A_DeBf_Skill_ID.Length)
            return;
          this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Mail, (ushort) 0, this.m_A_DeBf_Skill_ID[button.m_BtnID2 - 10], this.m_A_DeBf_Skill_LV[button.m_BtnID2 - 10], Vector2.zero);
        }
      }
      else if (button.m_BtnID2 < 10)
      {
        this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Normal, (ushort) 0, this.m_D_Skill_ID[button.m_BtnID2], this.m_D_Skill_LV[button.m_BtnID2], Vector2.zero);
      }
      else
      {
        if (button.m_BtnID2 - 10 < 0 || button.m_BtnID2 - 10 >= this.m_D_DeBf_Skill_ID.Length)
          return;
        this.GUIM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Normal, (ushort) 0, this.m_D_DeBf_Skill_ID[button.m_BtnID2 - 10], this.m_D_DeBf_Skill_LV[button.m_BtnID2 - 10], Vector2.zero);
      }
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    switch ((sender.m_Button as UIButton).m_BtnID1)
    {
      case 12:
        ((Component) this.Img_FormationHint).gameObject.SetActive(false);
        break;
      case 14:
        ((Component) this.Img_NpcItemHint).gameObject.SetActive(false);
        break;
    }
    this.GUIM.m_Hint.Hide(true);
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
      case NetworkNews.Refresh_Asset:
        if (meg[1] != (byte) 0 || meg[2] != (byte) 1 || (int) GameConstants.ConvertBytesToUShort(meg, 3) != (int) this.mBossHead)
          break;
        AssetBundle assetBundle = AssetManager.GetAssetBundle(this.Cstr_BoosHead, out this.AssetKey);
        if ((UnityEngine.Object) assetBundle != (UnityEngine.Object) null)
          this.mHead = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
        if (!((UnityEngine.Object) this.mHead != (UnityEngine.Object) null))
          break;
        this.mHead.transform.SetParent(((Component) this.Img_BossIcon[0]).transform);
        this.mHead.gameObject.SetActive(true);
        this.mHead.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.mHead.transform.localScale = new Vector3(1f, 1f, 1f);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Mailing)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.Refresh_FontTexture();
          break;
        }
        if (!this.DM.MailReportGet(ref this.Favor))
        {
          this.door.CloseMenu();
          break;
        }
        this.MaxLetterNum = (int) this.DM.GetMailboxSize();
        this.Cstr_Page.ClearString();
        switch (this.DM.OpenMail.Kind)
        {
          case MailType.EMAIL_BATTLE:
            this.Cstr_Page.IntToFormat((long) ((int) this.Report.Index + 1));
            this.Cstr_Page.IntToFormat((long) this.MaxLetterNum);
            break;
          case MailType.EMAIL_FAVORY:
            this.Cstr_Page.IntToFormat((long) ((int) this.Report.Index + 1));
            this.Cstr_Page.IntToFormat((long) this.MaxLetterNum);
            break;
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
    }
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.text_Coordinate != (UnityEngine.Object) null && ((Behaviour) this.text_Coordinate).enabled)
    {
      ((Behaviour) this.text_Coordinate).enabled = false;
      ((Behaviour) this.text_Coordinate).enabled = true;
    }
    if ((UnityEngine.Object) this.text_TitleName != (UnityEngine.Object) null && ((Behaviour) this.text_TitleName).enabled)
    {
      ((Behaviour) this.text_TitleName).enabled = false;
      ((Behaviour) this.text_TitleName).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Page != (UnityEngine.Object) null && ((Behaviour) this.text_Page).enabled)
    {
      ((Behaviour) this.text_Page).enabled = false;
      ((Behaviour) this.text_Page).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Summary != (UnityEngine.Object) null && ((Behaviour) this.text_Summary).enabled)
    {
      ((Behaviour) this.text_Summary).enabled = false;
      ((Behaviour) this.text_Summary).enabled = true;
    }
    if ((UnityEngine.Object) this.text_MainHero != (UnityEngine.Object) null && ((Behaviour) this.text_MainHero).enabled)
    {
      ((Behaviour) this.text_MainHero).enabled = false;
      ((Behaviour) this.text_MainHero).enabled = true;
    }
    if ((UnityEngine.Object) this.text_TitleItem != (UnityEngine.Object) null && ((Behaviour) this.text_TitleItem).enabled)
    {
      ((Behaviour) this.text_TitleItem).enabled = false;
      ((Behaviour) this.text_TitleItem).enabled = true;
    }
    if ((UnityEngine.Object) this.text_FightingKind != (UnityEngine.Object) null && ((Behaviour) this.text_FightingKind).enabled)
    {
      ((Behaviour) this.text_FightingKind).enabled = false;
      ((Behaviour) this.text_FightingKind).enabled = true;
    }
    if ((UnityEngine.Object) this.text_L_Exp != (UnityEngine.Object) null && ((Behaviour) this.text_L_Exp).enabled)
    {
      ((Behaviour) this.text_L_Exp).enabled = false;
      ((Behaviour) this.text_L_Exp).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Formation != (UnityEngine.Object) null && ((Behaviour) this.text_Formation).enabled)
    {
      ((Behaviour) this.text_Formation).enabled = false;
      ((Behaviour) this.text_Formation).enabled = true;
    }
    if ((UnityEngine.Object) this.text_NpcInfo != (UnityEngine.Object) null && ((Behaviour) this.text_NpcInfo).enabled)
    {
      ((Behaviour) this.text_NpcInfo).enabled = false;
      ((Behaviour) this.text_NpcInfo).enabled = true;
    }
    if ((UnityEngine.Object) this.text_QuanmierNpcInfo != (UnityEngine.Object) null && ((Behaviour) this.text_QuanmierNpcInfo).enabled)
    {
      ((Behaviour) this.text_QuanmierNpcInfo).enabled = false;
      ((Behaviour) this.text_QuanmierNpcInfo).enabled = true;
    }
    if ((UnityEngine.Object) this.text_NpcCoordinate != (UnityEngine.Object) null && ((Behaviour) this.text_NpcCoordinate).enabled)
    {
      ((Behaviour) this.text_NpcCoordinate).enabled = false;
      ((Behaviour) this.text_NpcCoordinate).enabled = true;
    }
    if ((UnityEngine.Object) this.text_NpcName != (UnityEngine.Object) null && ((Behaviour) this.text_NpcName).enabled)
    {
      ((Behaviour) this.text_NpcName).enabled = false;
      ((Behaviour) this.text_NpcName).enabled = true;
    }
    if ((UnityEngine.Object) this.text_NpcItemName != (UnityEngine.Object) null && ((Behaviour) this.text_NpcItemName).enabled)
    {
      ((Behaviour) this.text_NpcItemName).enabled = false;
      ((Behaviour) this.text_NpcItemName).enabled = true;
    }
    if ((UnityEngine.Object) this.text_NpcItemfull != (UnityEngine.Object) null && ((Behaviour) this.text_NpcItemfull).enabled)
    {
      ((Behaviour) this.text_NpcItemfull).enabled = false;
      ((Behaviour) this.text_NpcItemfull).enabled = true;
    }
    if ((UnityEngine.Object) this.text_NpcItemHint != (UnityEngine.Object) null && ((Behaviour) this.text_NpcItemHint).enabled)
    {
      ((Behaviour) this.text_NpcItemHint).enabled = false;
      ((Behaviour) this.text_NpcItemHint).enabled = true;
    }
    if ((UnityEngine.Object) this.text_AllianceBossStr != (UnityEngine.Object) null && ((Behaviour) this.text_AllianceBossStr).enabled)
    {
      ((Behaviour) this.text_AllianceBossStr).enabled = false;
      ((Behaviour) this.text_AllianceBossStr).enabled = true;
    }
    if ((UnityEngine.Object) this.text_LF != (UnityEngine.Object) null && ((Behaviour) this.text_LF).enabled)
    {
      ((Behaviour) this.text_LF).enabled = false;
      ((Behaviour) this.text_LF).enabled = true;
    }
    if ((UnityEngine.Object) this.text_RF != (UnityEngine.Object) null && ((Behaviour) this.text_RF).enabled)
    {
      ((Behaviour) this.text_RF).enabled = false;
      ((Behaviour) this.text_RF).enabled = true;
    }
    if ((UnityEngine.Object) this.btn_Boss_Hero != (UnityEngine.Object) null && ((Behaviour) this.btn_Boss_Hero).enabled)
      this.btn_Boss_Hero.Refresh_FontTexture();
    for (int index = 0; index < 2; ++index)
    {
      if ((UnityEngine.Object) this.text_Time[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Time[index]).enabled)
      {
        ((Behaviour) this.text_Time[index]).enabled = false;
        ((Behaviour) this.text_Time[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Offensive[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Offensive[index]).enabled)
      {
        ((Behaviour) this.text_Offensive[index]).enabled = false;
        ((Behaviour) this.text_Offensive[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_LossValue[index] != (UnityEngine.Object) null && ((Behaviour) this.text_LossValue[index]).enabled)
      {
        ((Behaviour) this.text_LossValue[index]).enabled = false;
        ((Behaviour) this.text_LossValue[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ArmyTitle[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ArmyTitle[index]).enabled)
      {
        ((Behaviour) this.text_ArmyTitle[index]).enabled = false;
        ((Behaviour) this.text_ArmyTitle[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Strength[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Strength[index]).enabled)
      {
        ((Behaviour) this.text_Strength[index]).enabled = false;
        ((Behaviour) this.text_Strength[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Country[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Country[index]).enabled)
      {
        ((Behaviour) this.text_Country[index]).enabled = false;
        ((Behaviour) this.text_Country[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Dominance[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Dominance[index]).enabled)
      {
        ((Behaviour) this.text_Dominance[index]).enabled = false;
        ((Behaviour) this.text_Dominance[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Name[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Name[index]).enabled)
      {
        ((Behaviour) this.text_Name[index]).enabled = false;
        ((Behaviour) this.text_Name[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_MainHero_F[index] != (UnityEngine.Object) null && ((Behaviour) this.text_MainHero_F[index]).enabled)
      {
        ((Behaviour) this.text_MainHero_F[index]).enabled = false;
        ((Behaviour) this.text_MainHero_F[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Vip[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Vip[index]).enabled)
      {
        ((Behaviour) this.text_Vip[index]).enabled = false;
        ((Behaviour) this.text_Vip[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_CoordinateMainHero[index] != (UnityEngine.Object) null && ((Behaviour) this.text_CoordinateMainHero[index]).enabled)
      {
        ((Behaviour) this.text_CoordinateMainHero[index]).enabled = false;
        ((Behaviour) this.text_CoordinateMainHero[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_BossTitle[index] != (UnityEngine.Object) null && ((Behaviour) this.text_BossTitle[index]).enabled)
      {
        ((Behaviour) this.text_BossTitle[index]).enabled = false;
        ((Behaviour) this.text_BossTitle[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_BossL[index] != (UnityEngine.Object) null && ((Behaviour) this.text_BossL[index]).enabled)
      {
        ((Behaviour) this.text_BossL[index]).enabled = false;
        ((Behaviour) this.text_BossL[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_NpcTroops[index] != (UnityEngine.Object) null && ((Behaviour) this.text_NpcTroops[index]).enabled)
      {
        ((Behaviour) this.text_NpcTroops[index]).enabled = false;
        ((Behaviour) this.text_NpcTroops[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_QuanmierNpcTroops[index] != (UnityEngine.Object) null && ((Behaviour) this.text_QuanmierNpcTroops[index]).enabled)
      {
        ((Behaviour) this.text_QuanmierNpcTroops[index]).enabled = false;
        ((Behaviour) this.text_QuanmierNpcTroops[index]).enabled = true;
      }
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((UnityEngine.Object) this.text_DW[index] != (UnityEngine.Object) null && ((Behaviour) this.text_DW[index]).enabled)
      {
        ((Behaviour) this.text_DW[index]).enabled = false;
        ((Behaviour) this.text_DW[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_BossR[index] != (UnityEngine.Object) null && ((Behaviour) this.text_BossR[index]).enabled)
      {
        ((Behaviour) this.text_BossR[index]).enabled = false;
        ((Behaviour) this.text_BossR[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_BossFight[index] != (UnityEngine.Object) null && ((Behaviour) this.text_BossFight[index]).enabled)
      {
        ((Behaviour) this.text_BossFight[index]).enabled = false;
        ((Behaviour) this.text_BossFight[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_FailureBuff[index] != (UnityEngine.Object) null && ((Behaviour) this.text_FailureBuff[index]).enabled)
      {
        ((Behaviour) this.text_FailureBuff[index]).enabled = false;
        ((Behaviour) this.text_FailureBuff[index]).enabled = true;
      }
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((UnityEngine.Object) this.text_LA[index] != (UnityEngine.Object) null && ((Behaviour) this.text_LA[index]).enabled)
      {
        ((Behaviour) this.text_LA[index]).enabled = false;
        ((Behaviour) this.text_LA[index]).enabled = true;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((UnityEngine.Object) this.text_Resources[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Resources[index]).enabled)
      {
        ((Behaviour) this.text_Resources[index]).enabled = false;
        ((Behaviour) this.text_Resources[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_HeroExp[index] != (UnityEngine.Object) null && ((Behaviour) this.text_HeroExp[index]).enabled)
      {
        ((Behaviour) this.text_HeroExp[index]).enabled = false;
        ((Behaviour) this.text_HeroExp[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_HeroExp2[index] != (UnityEngine.Object) null && ((Behaviour) this.text_HeroExp2[index]).enabled)
      {
        ((Behaviour) this.text_HeroExp2[index]).enabled = false;
        ((Behaviour) this.text_HeroExp2[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.btn_Hero[index] != (UnityEngine.Object) null && ((Behaviour) this.btn_Hero[index]).enabled)
        this.btn_Hero[index].Refresh_FontTexture();
    }
    for (int index = 0; index < 8; ++index)
    {
      if ((UnityEngine.Object) this.text_RA[index] != (UnityEngine.Object) null && ((Behaviour) this.text_RA[index]).enabled)
      {
        ((Behaviour) this.text_RA[index]).enabled = false;
        ((Behaviour) this.text_RA[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Quanmie[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Quanmie[index]).enabled)
      {
        ((Behaviour) this.text_Quanmie[index]).enabled = false;
        ((Behaviour) this.text_Quanmie[index]).enabled = true;
      }
    }
    for (int index = 0; index < 9; ++index)
    {
      if ((UnityEngine.Object) this.text_Buff[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Buff[index]).enabled)
      {
        ((Behaviour) this.text_Buff[index]).enabled = false;
        ((Behaviour) this.text_Buff[index]).enabled = true;
      }
    }
    for (int index = 0; index < 25; ++index)
    {
      if ((UnityEngine.Object) this.text_tmpStr[index] != (UnityEngine.Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
    for (int index = 0; index < 30; ++index)
    {
      if ((UnityEngine.Object) this.text_ItemQty[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemQty[index]).enabled)
      {
        ((Behaviour) this.text_ItemQty[index]).enabled = false;
        ((Behaviour) this.text_ItemQty[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.btn_Itme[index] != (UnityEngine.Object) null && ((Behaviour) this.btn_Itme[index]).enabled)
        this.btn_Itme[index].Refresh_FontTexture();
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.door.OpenMenu(EGUIWindow.UI_FightingSummary_Info);
        break;
      case 2:
        if (this.DM.MailReportGet(ref this.Favor))
          break;
        this.door.CloseMenu();
        break;
    }
  }

  private void Start()
  {
  }

  public void GetTitleNameStr()
  {
    this.Cstr_TitleName.ClearString();
    CString cstring1 = StringManager.Instance.StaticString1024();
    CString Name = StringManager.Instance.StaticString1024();
    CString Tag = StringManager.Instance.StaticString1024();
    if (this.mOpenKind == 0)
    {
      if (!this.bNpcMode)
      {
        switch (this.Report.Combat.Side)
        {
          case 0:
            this.Cstr_TitleName.Append(this.DM.mStringTable.GetStringByID(6021U));
            cstring1.ClearString();
            Name.ClearString();
            Tag.ClearString();
            Name.Append(this.Report.Combat.DefenceName);
            if (this.Report.Combat.DefenceAllianceTag != string.Empty)
            {
              Tag.Append(this.Report.Combat.DefenceAllianceTag);
              if ((int) this.Report.Combat.AssaultKingdomID != (int) this.Report.Combat.DefenceKingdomID)
                this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
              else
                this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
            }
            else if ((int) this.Report.Combat.AssaultKingdomID != (int) this.Report.Combat.DefenceKingdomID)
              this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: this.Report.Combat.DefenceKingdomID, ForceArabic: this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
            if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
            {
              if (this.DM.UserLanguage != GameLanguage.GL_Jpn)
              {
                if (this.GUIM.IsArabic)
                {
                  this.Cstr_TitleName.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Combat.CombatPointKind));
                  this.Cstr_TitleName.StringToFormat(cstring1);
                }
                else
                {
                  this.Cstr_TitleName.StringToFormat(cstring1);
                  this.Cstr_TitleName.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Combat.CombatPointKind));
                }
                this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(6022U));
                break;
              }
              this.Cstr_TitleName.ClearString();
              this.Cstr_TitleName.StringToFormat(cstring1);
              this.Cstr_TitleName.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Combat.CombatPointKind));
              this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(6022U));
              this.Cstr_TitleName.Append(this.DM.mStringTable.GetStringByID(6021U));
              break;
            }
            if (this.Report.Combat.Result == CombatReportResultType.ECRR_TAKEOVERWONDER)
            {
              this.Cstr_TitleName.Append(DataManager.MapDataController.GetYolkName((ushort) this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
              break;
            }
            this.Cstr_TitleName.Append(cstring1);
            this.Cstr_TitleName.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
            this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(9304U));
            break;
          case 1:
            cstring1.ClearString();
            Name.ClearString();
            Tag.ClearString();
            Name.Append(this.Report.Combat.AssaultName);
            if (this.Report.Combat.AssaultAllianceTag != string.Empty)
            {
              Tag.Append(this.Report.Combat.AssaultAllianceTag);
              if ((int) this.Report.Combat.AssaultKingdomID != (int) this.Report.Combat.DefenceKingdomID)
                this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, this.Report.Combat.AssaultKingdomID, this.GUIM.IsArabic);
              else
                this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
            }
            else if ((int) this.Report.Combat.AssaultKingdomID != (int) this.Report.Combat.DefenceKingdomID)
              this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: this.Report.Combat.AssaultKingdomID, ForceArabic: this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
            if (this.GUIM.IsArabic)
            {
              if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
                this.Cstr_TitleName.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Combat.CombatPointKind));
              else
                this.Cstr_TitleName.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
              this.Cstr_TitleName.StringToFormat(cstring1);
            }
            else
            {
              this.Cstr_TitleName.StringToFormat(cstring1);
              if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
                this.Cstr_TitleName.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Combat.CombatPointKind));
              else
                this.Cstr_TitleName.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
            }
            this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(6020U));
            break;
          case 2:
            if (this.Report.Combat.Result != CombatReportResultType.ECRR_TAKEOVERWONDER)
            {
              cstring1.ClearString();
              Name.ClearString();
              Tag.ClearString();
              CString cstring2 = StringManager.Instance.StaticString1024();
              CString cstring3 = StringManager.Instance.StaticString1024();
              cstring2.ClearString();
              cstring3.ClearString();
              cstring2.Append(this.DM.mStringTable.GetStringByID(6023U));
              Name.Append(this.Report.Combat.AssaultName);
              Tag.Append(this.Report.Combat.AssaultAllianceTag);
              if ((int) this.Report.Combat.AssaultKingdomID != (int) this.Report.Combat.DefenceKingdomID)
                this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, this.Report.Combat.AssaultKingdomID, this.GUIM.IsArabic);
              else
                this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
              cstring2.StringToFormat(cstring1);
              cstring2.AppendFormat(this.DM.mStringTable.GetStringByID(6024U));
              cstring1.ClearString();
              Name.ClearString();
              Tag.ClearString();
              Name.Append(this.Report.Combat.DefenceName);
              if (this.Report.Combat.DefenceAllianceTag != string.Empty)
              {
                Tag.Append(this.Report.Combat.DefenceAllianceTag);
                if ((int) this.Report.Combat.AssaultKingdomID != (int) this.Report.Combat.DefenceKingdomID)
                  this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
                else
                  this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
              }
              else if ((int) this.Report.Combat.AssaultKingdomID != (int) this.Report.Combat.DefenceKingdomID)
                this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: this.Report.Combat.DefenceKingdomID, ForceArabic: this.GUIM.IsArabic);
              else
                this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
              if (this.GUIM.IsArabic)
              {
                if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
                  cstring3.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Combat.CombatPointKind));
                else
                  cstring3.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
                cstring3.StringToFormat(cstring1);
              }
              else
              {
                cstring3.StringToFormat(cstring1);
                if (this.Report.Combat.CombatPointKind != POINT_KIND.PK_YOLK)
                  cstring3.StringToFormat(this.GUIM.GetPointName_Letter(this.Report.Combat.CombatPointKind));
                else
                  cstring3.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
              }
              cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(6022U));
              this.Cstr_TitleName.Append(cstring2);
              this.Cstr_TitleName.Append(cstring3);
              break;
            }
            this.Cstr_TitleName.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
            this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(4987U));
            break;
          case 3:
            cstring1.ClearString();
            Name.ClearString();
            Tag.ClearString();
            CString cstring4 = StringManager.Instance.StaticString1024();
            CString cstring5 = StringManager.Instance.StaticString1024();
            cstring4.ClearString();
            cstring5.ClearString();
            Name.Append(this.Report.Combat.AssaultName);
            Tag.Append(this.Report.Combat.AssaultAllianceTag);
            if ((int) this.Report.Combat.AssaultKingdomID != (int) this.Report.Combat.DefenceKingdomID)
              this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, this.Report.Combat.AssaultKingdomID, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
            cstring4.StringToFormat(cstring1);
            cstring4.AppendFormat(this.DM.mStringTable.GetStringByID(6025U));
            cstring1.ClearString();
            Name.ClearString();
            Tag.ClearString();
            Name.Append(this.Report.Combat.DefenceName);
            Tag.Append(this.Report.Combat.DefenceAllianceTag);
            if ((int) this.Report.Combat.AssaultKingdomID != (int) this.Report.Combat.DefenceKingdomID)
              this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
            cstring5.StringToFormat(cstring1);
            cstring5.AppendFormat(this.DM.mStringTable.GetStringByID(6026U));
            this.Cstr_TitleName.Append(cstring4);
            this.Cstr_TitleName.Append(cstring5);
            break;
          case 4:
          case 6:
            cstring1.ClearString();
            Name.ClearString();
            Tag.ClearString();
            Name.Append(this.Report.Combat.DefenceName);
            if (this.Report.Combat.DefenceAllianceTag != string.Empty)
            {
              Tag.Append(this.Report.Combat.DefenceAllianceTag);
              if ((int) this.Report.Combat.AssaultKingdomID != (int) this.Report.Combat.DefenceKingdomID)
                this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
              else
                this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
            }
            else if ((int) this.Report.Combat.AssaultKingdomID != (int) this.Report.Combat.DefenceKingdomID)
              this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: this.Report.Combat.DefenceKingdomID, ForceArabic: this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
            this.Cstr_TitleName.StringToFormat(cstring1);
            this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(9751U));
            break;
          case 5:
            cstring1.ClearString();
            Name.ClearString();
            Tag.ClearString();
            Name.Append(this.Report.Combat.AssaultName);
            if (this.Report.Combat.AssaultAllianceTag != string.Empty)
            {
              Tag.Append(this.Report.Combat.AssaultAllianceTag);
              if ((int) this.Report.Combat.AssaultKingdomID != (int) this.Report.Combat.DefenceKingdomID)
                this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, this.Report.Combat.AssaultKingdomID, this.GUIM.IsArabic);
              else
                this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
            }
            else if ((int) this.Report.Combat.AssaultKingdomID != (int) this.Report.Combat.DefenceKingdomID)
              this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: this.Report.Combat.DefenceKingdomID, ForceArabic: this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring1, Name, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
            this.Cstr_TitleName.StringToFormat(cstring1);
            this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(9752U));
            break;
        }
      }
      else
      {
        cstring1.ClearString();
        Name.ClearString();
        Tag.ClearString();
        CString cstring6 = StringManager.Instance.StaticString1024();
        CString cstring7 = StringManager.Instance.StaticString1024();
        cstring6.ClearString();
        cstring7.ClearString();
        cstring6.Append(this.DM.mStringTable.GetStringByID(6023U));
        Name.Append(this.Report.NPCCombat.AssaultName);
        Tag.Append(this.Report.NPCCombat.AssaultAllianceTag);
        if ((int) this.Report.NPCCombat.AssaultKingdomID != (int) this.Report.NPCCombat.KingdomID)
          this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, this.Report.NPCCombat.AssaultKingdomID, this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring1, Name, Tag, (ushort) 0, this.GUIM.IsArabic);
        cstring6.StringToFormat(cstring1);
        cstring6.AppendFormat(this.DM.mStringTable.GetStringByID(6024U));
        cstring1.ClearString();
        Name.ClearString();
        Tag.ClearString();
        Name.IntToFormat((long) this.Report.NPCCombat.NPCLevel);
        Name.AppendFormat(this.DM.mStringTable.GetStringByID(12021U));
        cstring7.Append(cstring1);
        cstring7.Append(Name);
        this.Cstr_TitleName.Append(cstring6);
        this.Cstr_TitleName.Append(cstring7);
      }
    }
    else
    {
      if (this.mOpenKind != 1)
        return;
      if (this.Report.Monster.Result < (byte) 2)
      {
        this.Cstr_TitleName.IntToFormat((long) this.Report.Monster.MonsterLv);
        this.Cstr_TitleName.StringToFormat(this.DM.mStringTable.GetStringByID((uint) DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.Report.Monster.MonsterID).NameID));
        if (this.Report.Monster.Result == (byte) 0)
          this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(8221U));
        else
          this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(8223U));
      }
      else
      {
        cstring1.StringToFormat(this.Report.Monster.AllianceTag);
        cstring1.StringToFormat(this.DM.mStringTable.GetStringByID((uint) DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.Report.Monster.MonsterID).NameID));
        cstring1.AppendFormat("[{0}]{1}");
        this.Cstr_TitleName.IntToFormat((long) this.Report.Monster.MonsterLv);
        this.Cstr_TitleName.StringToFormat(cstring1);
        if (this.Report.Monster.Result == (byte) 4)
          this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(8221U));
        else
          this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(8223U));
        this.bAllianceBossMode = true;
      }
    }
  }

  public void SetPageData()
  {
    if (this.AssetKey != 0)
      AssetManager.UnloadAssetBundle(this.AssetKey, false);
    if ((UnityEngine.Object) this.mHead != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.mHead);
    this.bAllianceBossMode = false;
    this.GetTitleNameStr();
    this.text_TitleName.text = this.Cstr_TitleName.ToString();
    this.text_TitleName.SetAllDirty();
    this.text_TitleName.cachedTextGenerator.Invalidate();
    this.Cstr_Page.ClearString();
    switch (this.DM.OpenMail.Kind)
    {
      case MailType.EMAIL_BATTLE:
        this.Cstr_Page.IntToFormat((long) ((int) this.Report.Index + 1));
        this.Cstr_Page.IntToFormat((long) this.MaxLetterNum);
        break;
      case MailType.EMAIL_FAVORY:
        this.Cstr_Page.IntToFormat((long) ((int) this.Report.Index + 1));
        this.Cstr_Page.IntToFormat((long) this.MaxLetterNum);
        break;
    }
    if (this.GUIM.IsArabic)
      this.Cstr_Page.AppendFormat("{1}/{0}");
    else
      this.Cstr_Page.AppendFormat("{0}/{1}");
    this.text_Page.text = this.Cstr_Page.ToString();
    this.text_Page.SetAllDirty();
    this.text_Page.cachedTextGenerator.Invalidate();
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
    this.tmpH = -136f;
    this.text_Summary.SetAllDirty();
    this.text_Summary.cachedTextGenerator.Invalidate();
    this.tmpH = -136f;
    if (this.bWin)
    {
      this.Img_Titlebg.sprite = this.SArray.m_Sprites[0];
      ((Graphic) this.text_Summary).color = new Color(1f, 0.9255f, 0.5294f);
      ((Shadow) ((Component) this.text_Summary).transform.GetComponent<Outline>()).effectColor = new Color(0.8431f, 0.0f, 0.0f);
      ((Component) this.text_Summary).transform.GetComponent<Shadow>().effectColor = new Color(0.2824f, 0.0f, 0.0f);
    }
    else
    {
      this.Img_Titlebg.sprite = this.SArray.m_Sprites[1];
      ((Graphic) this.text_Summary).color = new Color(0.6941f, 0.9137f, 1f);
      ((Shadow) ((Component) this.text_Summary).transform.GetComponent<Outline>()).effectColor = new Color(0.2471f, 0.451f, 0.7294f);
      ((Component) this.text_Summary).transform.GetComponent<Shadow>().effectColor = new Color(0.0f, 0.0471f, 0.2824f);
    }
    if (this.mOpenKind == 0)
    {
      int num = this.mType < 4 ? this.mType : 1;
      if (!this.bNpcMode)
      {
        if (this.Report.Combat.CombatPointKind == POINT_KIND.PK_YOLK)
        {
          if (this.bWin)
          {
            if (this.IsAttack)
            {
              this.Cstr_Text.ClearString();
              if (this.Report.Combat.CombatPoint == (byte) 0 || (int) this.Report.Combat.KingdomID == (int) ActivityManager.Instance.KOWKingdomID)
                this.Cstr_Text.StringToFormat(this.DM.mStringTable.GetStringByID(9308U));
              else
                this.Cstr_Text.StringToFormat(this.DM.mStringTable.GetStringByID(9309U));
              this.Cstr_Text.AppendFormat(this.DM.mStringTable.GetStringByID(7265U));
              this.text_Summary.text = this.Cstr_Text.ToString();
            }
            else
              this.text_Summary.text = this.DM.mStringTable.GetStringByID(5307U);
          }
          else
            this.text_Summary.text = this.DM.mStringTable.GetStringByID(5308U);
        }
        else
          this.text_Summary.text = this.DM.mStringTable.GetStringByID((uint) (ushort) (5307 + num));
        if (!this.bQuanmier && this.Report.Combat.CaptureResult != ECombatReportCaptureResultType.ECRCR_NONE)
        {
          this.text_MainHero.text = this.Report.Combat.CaptureResult != ECombatReportCaptureResultType.ECRCR_CAPTURE_LORD ? this.DM.mStringTable.GetStringByID(5311U) : this.DM.mStringTable.GetStringByID(5312U);
          this.tmpH -= 98f;
          ((Component) this.Img_MainHerobg).gameObject.SetActive(true);
        }
        else
          ((Component) this.Img_MainHerobg).gameObject.SetActive(false);
      }
      else
        this.text_Summary.text = !this.bWin ? this.DM.mStringTable.GetStringByID(5308U) : this.DM.mStringTable.GetStringByID(5307U);
    }
    this.ItemRT.anchoredPosition = new Vector2(this.ItemRT.anchoredPosition.x, this.tmpH);
    float y = 0.0f;
    this.mItemCount = 0;
    for (int index = 0; index < 5; ++index)
    {
      if ((UnityEngine.Object) this.ItemT[index] != (UnityEngine.Object) null)
        this.ItemT[index].gameObject.SetActive(false);
    }
    if (!this.bAllianceBossMode)
    {
      for (int index = 0; index < 30; ++index)
      {
        if (this.mOpenKind == 0)
        {
          if (this.bNpcMode && this.bWin)
          {
            this.mItemCount = 1;
            break;
          }
        }
        else if (this.mOpenKind == 1 && this.Report.Monster.Item[index] != null && this.Report.Monster.Item[index].ItemID != (ushort) 0)
        {
          this.ItemID[index] = this.Report.Monster.Item[index].ItemID;
          this.ItemNum[index] = this.Report.Monster.Item[index].Num;
          this.ItemRank[index] = this.Report.Monster.Item[index].ItemRank;
          ++this.mItemCount;
        }
      }
    }
    else
      this.mItemCount = 1;
    this.text_TitleItem.text = this.DM.mStringTable.GetStringByID(7696U);
    this.tmpNum = this.mItemCount / 6;
    if (this.mItemCount % 6 > 0)
      ++this.tmpNum;
    ((Component) this.NpcItemRT).gameObject.SetActive(false);
    ((Component) this.AllianceBossItemRT).gameObject.SetActive(false);
    if (this.mItemCount > 0)
    {
      this.tmpH -= 41f;
      this.tmpH -= (float) (89 * this.tmpNum);
      y -= (float) (89 * this.tmpNum);
      if (!this.bInitItemBase && !this.bNpcMode)
      {
        this.bInitItemBase = true;
        for (int index = 0; index < 6; ++index)
        {
          this.btn_Itme[index] = this.ItemT[0].GetChild(index).GetComponent<UIHIBtn>();
          this.btn_Itme[index].m_Handler = (IUIHIBtnClickHandler) this;
          this.GUIM.InitianHeroItemImg(((Component) this.btn_Itme[index]).transform, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0);
          this.btn_Item_L[index] = this.ItemT[0].GetChild(6 + index).GetComponent<UILEBtn>();
          this.GUIM.InitLordEquipImg(((Component) this.btn_Item_L[index]).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
          ((Component) this.btn_Item_L[index]).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
          this.text_ItemQty[index] = this.ItemT[0].GetChild(12 + index).GetComponent<UIText>();
          this.text_ItemQty[index].font = this.TTFont;
        }
      }
      if (this.bNpcMode)
      {
        ((Component) this.NpcItemRT).gameObject.SetActive(true);
        Image component = ((Component) this.btn_NpcItemIcon).GetComponent<Image>();
        component.sprite = GUIManager.Instance.m_LeadItemIconSpriteAsset.LoadSprite(this.DM.NPCPrize.GetRecordByKey(this.Report.NPCCombat.Reward).PicNo);
        ((MaskableGraphic) component).material = GUIManager.Instance.m_LeadItemIconSpriteAsset.GetMaterial();
        this.text_NpcItemName.text = this.DM.mStringTable.GetStringByID((uint) this.DM.NPCPrize.GetRecordByKey(this.Report.NPCCombat.Reward).Element);
        this.tmpRC = ((Component) this.btn_NpcItemName).transform.GetComponent<RectTransform>();
        this.tmpRC.sizeDelta = new Vector2(this.text_NpcItemName.preferredWidth, this.tmpRC.sizeDelta.y);
        this.tmpRC = ((Component) this.btn_NpcItemName).transform.GetChild(0).GetComponent<RectTransform>();
        this.tmpRC.sizeDelta = new Vector2(this.text_NpcItemName.preferredWidth, this.tmpRC.sizeDelta.y);
        this.tmpRC = ((Component) this.btn_NpcItemName).transform.GetChild(1).GetComponent<RectTransform>();
        this.tmpRC.sizeDelta = new Vector2(this.text_NpcItemName.preferredWidth, this.tmpRC.sizeDelta.y);
        if (this.Report.NPCCombat.Reward > (ushort) 0)
        {
          ((Component) this.btn_NpcItemIcon).gameObject.SetActive(true);
          ((Component) this.btn_NpcItemName).gameObject.SetActive(true);
          ((Component) this.text_NpcItemName).gameObject.SetActive(true);
          ((Component) this.text_NpcItemfull).gameObject.SetActive(false);
        }
        else
        {
          ((Component) this.btn_NpcItemIcon).gameObject.SetActive(false);
          ((Component) this.btn_NpcItemName).gameObject.SetActive(false);
          ((Component) this.text_NpcItemName).gameObject.SetActive(false);
          ((Component) this.text_NpcItemfull).gameObject.SetActive(true);
        }
      }
      if (this.bAllianceBossMode)
      {
        ((Component) this.AllianceBossItemRT).gameObject.SetActive(true);
        this.text_TitleItem.text = this.DM.mStringTable.GetStringByID(14516U);
      }
    }
    this.bSetItemData = (byte) 0;
    this.ResourcesRT.anchoredPosition = new Vector2(this.ResourcesRT.anchoredPosition.x, y);
    bool flag = false;
    if (this.mOpenKind == 0 && !this.bNpcMode)
    {
      for (int index = 0; index < 5; ++index)
      {
        this.Cstr_Resources[index].ClearString();
        if (this.Report.Combat.Resource[index] != 0)
        {
          GameConstants.FormatResourceValue_Int(this.Cstr_Resources[index], this.Report.Combat.Resource[index]);
          if (!flag)
            flag = true;
        }
        else
          this.Cstr_Resources[index].Append("-");
        this.text_Resources[index].text = this.Cstr_Resources[index].ToString();
        this.text_Resources[index].SetAllDirty();
        this.text_Resources[index].cachedTextGenerator.Invalidate();
      }
    }
    if (this.mItemCount < 1 && !flag)
    {
      ((Component) this.ItemRT).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.ItemRT).gameObject.SetActive(true);
      if (flag)
      {
        ((Component) this.ResourcesRT).gameObject.SetActive(true);
        if (this.mItemCount < 1)
          this.tmpH -= 110f;
        else
          this.tmpH -= 70f;
        this.ItemRT2.sizeDelta = new Vector2(this.ItemRT2.sizeDelta.x, (float) (-(double) y + 70.0));
      }
      else
      {
        ((Component) this.ResourcesRT).gameObject.SetActive(false);
        this.ItemRT2.sizeDelta = new Vector2(this.ItemRT2.sizeDelta.x, -y);
      }
    }
    this.text_TitleItem.SetAllDirty();
    this.text_TitleItem.cachedTextGenerator.Invalidate();
    this.HeroRT.anchoredPosition = new Vector2(this.HeroRT.anchoredPosition.x, this.tmpH);
    int num1 = 0;
    Array.Clear((Array) this.tmpHeroExp, 0, this.tmpHeroExp.Length);
    Array.Clear((Array) this.tmpHeroID, 0, this.tmpHeroID.Length);
    Array.Clear((Array) this.tmpHeroStar, 0, this.tmpHeroStar.Length);
    if (!this.bNpcMode)
    {
      for (int index = 0; index < 5; ++index)
      {
        if (this.mOpenKind == 0 && this.Report.Combat.HeroData[index].HeroID != (ushort) 0)
        {
          this.tmpHeroExp[index] = this.Report.Combat.EarnHeroExp;
          this.tmpHeroID[index] = this.Report.Combat.HeroData[index].HeroID;
          this.tmpHeroStar[index] = this.Report.Combat.HeroData[index].Star;
          ++num1;
        }
        else if (this.mOpenKind == 1 && this.Report.Monster.HeroID[index] != (ushort) 0)
        {
          this.tmpHeroExp[index] = this.Report.Monster.HeroExp[index];
          this.tmpHeroID[index] = this.Report.Monster.HeroID[index];
          this.tmpHeroStar[index] = this.Report.Monster.HeroData[index].Star;
          ++num1;
        }
      }
    }
    else
    {
      for (int index = 0; index < 5; ++index)
      {
        if (this.mOpenKind == 0 && this.Report.NPCCombat.HeroData[index].HeroID != (ushort) 0)
        {
          this.tmpHeroExp[index] = this.Report.NPCCombat.EarnHeroExp;
          this.tmpHeroID[index] = this.Report.NPCCombat.HeroData[index].HeroID;
          this.tmpHeroStar[index] = this.Report.NPCCombat.HeroData[index].Star;
          ++num1;
        }
      }
    }
    uint x = this.mOpenKind != 0 ? this.Report.Monster.Exp : (this.bNpcMode ? this.Report.NPCCombat.EarnLordExp : this.Report.Combat.EarnLordExp);
    if (!this.bNpcMode && (x > 0U || num1 > 0))
    {
      ((Component) this.HeroRT).gameObject.SetActive(true);
      this.tmpH -= 41f;
      this.Cstr_L_Exp.ClearString();
      this.Cstr_L_Exp.Append(this.DM.mStringTable.GetStringByID(7698U));
      this.Cstr_L_Exp.IntToFormat((long) x, bNumber: true);
      this.Cstr_L_Exp.AppendFormat("+{0}");
      this.text_L_Exp.text = this.Cstr_L_Exp.ToString();
      this.text_L_Exp.SetAllDirty();
      this.text_L_Exp.cachedTextGenerator.Invalidate();
      if (num1 > 0)
      {
        this.HeroBGRT.sizeDelta = new Vector2(this.HeroBGRT.sizeDelta.x, 196f);
        for (int index = 0; index < num1; ++index)
        {
          this.Cstr_HeroExp[index].ClearString();
          this.Cstr_HeroExp[index].IntToFormat((long) this.tmpHeroExp[index], bNumber: true);
          if (this.GUIM.IsArabic)
            this.Cstr_HeroExp[index].AppendFormat("{0}+");
          else
            this.Cstr_HeroExp[index].AppendFormat("+{0}");
          this.text_HeroExp[index].text = this.Cstr_HeroExp[index].ToString();
          this.text_HeroExp[index].SetAllDirty();
          this.text_HeroExp[index].cachedTextGenerator.Invalidate();
          ((Component) this.text_HeroExp[index]).gameObject.SetActive(true);
          ((Component) this.text_HeroExp2[index]).gameObject.SetActive(true);
          ((Component) this.btn_Hero[index]).gameObject.SetActive(true);
          if (!this.bSetHero[index])
          {
            this.GUIM.InitianHeroItemImg(((Component) this.btn_Hero[index]).transform, eHeroOrItem.Hero, this.tmpHeroID[index], this.tmpHeroStar[index], (byte) 0);
            this.bSetHero[index] = true;
          }
          else
            this.GUIM.ChangeHeroItemImg(((Component) this.btn_Hero[index]).transform, eHeroOrItem.Hero, this.tmpHeroID[index], this.tmpHeroStar[index], (byte) 0);
        }
        this.tmpH -= 196f;
      }
      else
      {
        this.HeroBGRT.sizeDelta = new Vector2(this.HeroBGRT.sizeDelta.x, 86f);
        this.tmpH -= 86f;
      }
      for (int index = num1; index < 5; ++index)
      {
        this.Cstr_HeroExp[index].ClearString();
        ((Component) this.text_HeroExp[index]).gameObject.SetActive(false);
        ((Component) this.text_HeroExp2[index]).gameObject.SetActive(false);
        ((Component) this.btn_Hero[index]).gameObject.SetActive(false);
      }
    }
    else
      ((Component) this.HeroRT).gameObject.SetActive(false);
    this.SummaryRT.anchoredPosition = new Vector2(this.SummaryRT.anchoredPosition.x, this.tmpH);
    this.tmpH -= 51f;
    this.tmpH -= 312f;
    if (this.mOpenKind == 0 && (UnityEngine.Object) this.Img_MainHero[1] != (UnityEngine.Object) null)
      this.SetFightData();
    else if (this.mOpenKind == 1)
      this.SetBossData();
    this.Cstr_Coordinate[0].ClearString();
    this.Cstr_Coordinate[1].ClearString();
    if (this.mOpenKind == 0)
    {
      if (!this.bNpcMode)
      {
        this.tmpV = this.Report.Combat.CombatPointKind == POINT_KIND.PK_YOLK ? DataManager.MapDataController.GetYolkPos((ushort) this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID) : GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Combat.CombatlZone, this.Report.Combat.CombatPoint));
        this.Cstr_Coordinate[0].IntToFormat((long) this.Report.Combat.KingdomID);
        this.Cstr_Coordinate[0].IntToFormat((long) (int) this.tmpV.x);
        this.Cstr_Coordinate[0].IntToFormat((long) (int) this.tmpV.y);
        if (this.GUIM.IsArabic)
          this.Cstr_Coordinate[0].AppendFormat("{0}:K {1}:X {2}:Y");
        else
          this.Cstr_Coordinate[0].AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
        this.Cstr_Coordinate[1].StringToFormat(this.Cstr_Coordinate[0]);
        this.Cstr_Coordinate[1].AppendFormat(this.DM.mStringTable.GetStringByID(5305U));
      }
      else
      {
        this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.NPCCombat.CombatlZone, this.Report.NPCCombat.CombatPoint));
        this.Cstr_Coordinate[0].IntToFormat((long) this.Report.NPCCombat.KingdomID);
        this.Cstr_Coordinate[0].IntToFormat((long) (int) this.tmpV.x);
        this.Cstr_Coordinate[0].IntToFormat((long) (int) this.tmpV.y);
        if (this.GUIM.IsArabic)
          this.Cstr_Coordinate[0].AppendFormat("{0}:K {1}:X {2}:Y");
        else
          this.Cstr_Coordinate[0].AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
        this.Cstr_Coordinate[1].StringToFormat(this.Cstr_Coordinate[0]);
        this.Cstr_Coordinate[1].AppendFormat(this.DM.mStringTable.GetStringByID(5305U));
      }
    }
    else
    {
      this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Monster.Zone, this.Report.Monster.Point));
      this.Cstr_Coordinate[0].IntToFormat((long) this.Report.Monster.KindgomID);
      this.Cstr_Coordinate[0].IntToFormat((long) (int) this.tmpV.x);
      this.Cstr_Coordinate[0].IntToFormat((long) (int) this.tmpV.y);
      if (this.GUIM.IsArabic)
        this.Cstr_Coordinate[0].AppendFormat("{0}:K {1}:X {2}:Y");
      else
        this.Cstr_Coordinate[0].AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
      this.Cstr_Coordinate[1].StringToFormat(this.Cstr_Coordinate[0]);
      this.Cstr_Coordinate[1].AppendFormat(this.DM.mStringTable.GetStringByID(8218U));
    }
    this.text_Coordinate.text = this.Cstr_Coordinate[1].ToString();
    this.text_Coordinate.SetAllDirty();
    this.text_Coordinate.cachedTextGenerator.Invalidate();
    this.text_Coordinate.cachedTextGeneratorForLayout.Invalidate();
    this.tmpRC = ((Component) this.btn_Title).transform.GetComponent<RectTransform>();
    this.tmpRC.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRC.sizeDelta.y);
    this.tmpRC = ((Component) this.btn_Title).transform.GetChild(0).GetComponent<RectTransform>();
    this.tmpRC.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRC.sizeDelta.y);
    this.tmpRC = ((Component) this.btn_Title).transform.GetChild(1).GetComponent<RectTransform>();
    this.tmpRC.sizeDelta = new Vector2(this.text_Coordinate.preferredWidth, this.tmpRC.sizeDelta.y);
    this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
    this.text_Time[0].SetAllDirty();
    this.text_Time[0].cachedTextGenerator.Invalidate();
    this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
    this.text_Time[1].SetAllDirty();
    this.text_Time[1].cachedTextGenerator.Invalidate();
  }

  public void SetFightData()
  {
    this.tmpHero = this.bNpcMode ? DataManager.Instance.HeroTable.GetRecordByKey(this.Report.NPCCombat.Summary.AssaultHead) : DataManager.Instance.HeroTable.GetRecordByKey(this.Report.Combat.Summary.AssaultHead);
    this.Img_MainHero[1].sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
    if (!this.bNpcMode && this.Report.Combat.Summary.IsLeader == (byte) 0 || this.bNpcMode && this.Report.NPCCombat.Summary.IsLeader == (byte) 0)
      ((Component) this.Img_Muster[0]).gameObject.SetActive(false);
    this.Cstr_Dominance[0].ClearString();
    if (!this.bNpcMode)
      this.Cstr_Dominance[0].IntToFormat((long) this.Report.Combat.Summary.AssaultLevel);
    else
      this.Cstr_Dominance[0].IntToFormat((long) this.Report.NPCCombat.Summary.AssaultLevel);
    this.Cstr_Dominance[0].AppendFormat(this.DM.mStringTable.GetStringByID(5320U));
    this.text_Dominance[0].text = this.Cstr_Dominance[0].ToString();
    this.text_Dominance[0].SetAllDirty();
    this.text_Dominance[0].cachedTextGenerator.Invalidate();
    this.Cstr_Country[0].ClearString();
    if (!this.bNpcMode)
      this.Cstr_Country[0].IntToFormat((long) this.Report.Combat.AssaultKingdomID);
    else
      this.Cstr_Country[0].IntToFormat((long) this.Report.NPCCombat.AssaultKingdomID);
    if (this.GUIM.IsArabic)
      this.Cstr_Country[0].AppendFormat("{0}#");
    else
      this.Cstr_Country[0].AppendFormat("#{0}");
    this.text_Country[0].text = this.Cstr_Country[0].ToString();
    this.text_Country[0].SetAllDirty();
    this.text_Country[0].cachedTextGenerator.Invalidate();
    if (true)
      ((Component) this.Img_Country[0]).gameObject.SetActive(false);
    int num1 = this.bNpcMode ? (int) this.Report.NPCCombat.Summary.AssaultAllianceRank : (int) this.Report.Combat.Summary.AssaultAllianceRank;
    this.Img_Rank[0].sprite = this.SArray.m_Sprites[7 + num1];
    if (num1 < 1)
      ((Component) this.Img_Rank[0]).gameObject.SetActive(false);
    else
      ((Component) this.Img_Rank[0]).gameObject.SetActive(true);
    this.text_Vip[0].text = (this.bNpcMode ? (int) this.Report.NPCCombat.Summary.AssaultVIPLevel : (int) this.Report.Combat.Summary.AssaultVIPLevel).ToString();
    this.Cstr_CoordinateMainHero[0].ClearString();
    if (!this.bNpcMode)
    {
      this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Combat.Summary.AssaultCapitalZone, this.Report.Combat.Summary.AssaultCapitalPoint));
      this.Cstr_CoordinateMainHero[0].IntToFormat((long) this.Report.Combat.KingdomID);
    }
    else
    {
      this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.NPCCombat.SummaryHead.AssaultCapitalZone, this.Report.NPCCombat.SummaryHead.AssaultCapitalPoint));
      this.Cstr_CoordinateMainHero[0].IntToFormat((long) this.Report.NPCCombat.KingdomID);
    }
    this.Cstr_CoordinateMainHero[0].IntToFormat((long) (int) this.tmpV.x);
    this.Cstr_CoordinateMainHero[0].IntToFormat((long) (int) this.tmpV.y);
    if (this.GUIM.IsArabic)
      this.Cstr_CoordinateMainHero[0].AppendFormat("{2}:Y {1}:X {0}:K");
    else
      this.Cstr_CoordinateMainHero[0].AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
    this.text_CoordinateMainHero[0].text = this.Cstr_CoordinateMainHero[0].ToString();
    this.text_CoordinateMainHero[0].SetAllDirty();
    this.text_CoordinateMainHero[0].cachedTextGenerator.Invalidate();
    this.text_CoordinateMainHero[0].cachedTextGeneratorForLayout.Invalidate();
    this.tmpRC = ((Component) this.btn_Coordinate[0]).transform.GetComponent<RectTransform>();
    this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[0].preferredWidth, this.tmpRC.sizeDelta.y);
    this.tmpRC = ((Component) this.btn_Coordinate[0]).transform.GetChild(0).GetComponent<RectTransform>();
    this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[0].preferredWidth, this.tmpRC.sizeDelta.y);
    this.tmpRC = ((Component) this.btn_Coordinate[0]).transform.GetChild(1).GetComponent<RectTransform>();
    this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[0].preferredWidth, this.tmpRC.sizeDelta.y);
    this.Cstr_Name[0].ClearString();
    CString cstring1 = StringManager.Instance.StaticString1024();
    CString cstring2 = StringManager.Instance.StaticString1024();
    cstring1.ClearString();
    cstring2.ClearString();
    if (!this.bNpcMode)
    {
      cstring1.Append(this.Report.Combat.AssaultName);
      if (this.Report.Combat.AssaultAllianceTag != string.Empty)
      {
        cstring2.Append(this.Report.Combat.AssaultAllianceTag);
        GameConstants.FormatRoleName(this.Cstr_Name[0], cstring1, cstring2, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      }
      else
        GameConstants.FormatRoleName(this.Cstr_Name[0], cstring1, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    }
    else
    {
      cstring1.Append(this.Report.NPCCombat.AssaultName);
      if (this.Report.NPCCombat.AssaultAllianceTag != string.Empty)
      {
        cstring2.Append(this.Report.NPCCombat.AssaultAllianceTag);
        GameConstants.FormatRoleName(this.Cstr_Name[0], cstring1, cstring2, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      }
      else
        GameConstants.FormatRoleName(this.Cstr_Name[0], cstring1, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    }
    this.text_Name[0].text = this.Cstr_Name[0].ToString();
    this.text_Name[0].SetAllDirty();
    this.text_Name[0].cachedTextGenerator.Invalidate();
    if (!this.bNpcMode)
      this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.Report.Combat.Summary.DefenceHead);
    this.Img_MainHero[4].sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
    if (true)
      ((Component) this.Img_Muster[1]).gameObject.SetActive(false);
    this.Cstr_Dominance[1].ClearString();
    if (!this.bNpcMode)
    {
      this.Cstr_Dominance[1].IntToFormat((long) this.Report.Combat.Summary.DefenceLevel);
      this.Cstr_Dominance[1].AppendFormat(this.DM.mStringTable.GetStringByID(5320U));
    }
    this.text_Dominance[1].text = this.Cstr_Dominance[1].ToString();
    this.text_Dominance[1].SetAllDirty();
    this.text_Dominance[1].cachedTextGenerator.Invalidate();
    this.Cstr_Country[1].ClearString();
    if (!this.bNpcMode)
    {
      this.Cstr_Country[1].IntToFormat((long) this.Report.Combat.DefenceKingdomID);
      if (this.GUIM.IsArabic)
        this.Cstr_Country[1].AppendFormat("{0}#");
      else
        this.Cstr_Country[1].AppendFormat("#{0}");
      this.text_Country[1].text = this.Cstr_Country[1].ToString();
    }
    this.text_Country[1].SetAllDirty();
    this.text_Country[1].cachedTextGenerator.Invalidate();
    if (true)
      ((Component) this.Img_Country[1]).gameObject.SetActive(false);
    int num2 = 0;
    if (!this.bNpcMode)
      num2 = (int) this.Report.Combat.Summary.DefenceAllianceRank;
    this.Img_Rank[1].sprite = this.SArray.m_Sprites[7 + num2];
    if (num2 < 1)
      ((Component) this.Img_Rank[1]).gameObject.SetActive(false);
    else
      ((Component) this.Img_Rank[1]).gameObject.SetActive(true);
    int num3 = 0;
    if (!this.bNpcMode)
      num3 = (int) this.Report.Combat.Summary.DefenceVIPLevel;
    this.text_Vip[1].text = num3.ToString();
    this.Cstr_CoordinateMainHero[1].ClearString();
    if (!this.bNpcMode)
    {
      this.tmpV = this.Report.Combat.CombatPointKind == POINT_KIND.PK_YOLK ? DataManager.MapDataController.GetYolkPos((ushort) this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID) : GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Combat.Summary.DefenceCapitalZone, this.Report.Combat.Summary.DefenceCapitalPoint));
      this.Cstr_CoordinateMainHero[1].IntToFormat((long) this.Report.Combat.KingdomID);
    }
    else
    {
      if (this.Report.NPCCombat.CombatPointKind != POINT_KIND.PK_YOLK)
        this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.NPCCombat.CombatlZone, this.Report.NPCCombat.CombatPoint));
      this.Cstr_CoordinateMainHero[1].IntToFormat((long) this.Report.NPCCombat.KingdomID);
    }
    this.Cstr_CoordinateMainHero[1].IntToFormat((long) (int) this.tmpV.x);
    this.Cstr_CoordinateMainHero[1].IntToFormat((long) (int) this.tmpV.y);
    if (this.GUIM.IsArabic)
      this.Cstr_CoordinateMainHero[1].AppendFormat("{2}:Y {1}:X {0}:K");
    else
      this.Cstr_CoordinateMainHero[1].AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
    this.text_CoordinateMainHero[1].text = this.Cstr_CoordinateMainHero[1].ToString();
    this.text_CoordinateMainHero[1].SetAllDirty();
    this.text_CoordinateMainHero[1].cachedTextGenerator.Invalidate();
    this.text_CoordinateMainHero[1].cachedTextGeneratorForLayout.Invalidate();
    this.tmpRC = ((Component) this.btn_Coordinate[1]).transform.GetComponent<RectTransform>();
    this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[1].preferredWidth, this.tmpRC.sizeDelta.y);
    this.tmpRC = ((Component) this.btn_Coordinate[1]).transform.GetChild(0).GetComponent<RectTransform>();
    this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[1].preferredWidth, this.tmpRC.sizeDelta.y);
    this.tmpRC = ((Component) this.btn_Coordinate[1]).transform.GetChild(1).GetComponent<RectTransform>();
    this.tmpRC.sizeDelta = new Vector2(this.text_CoordinateMainHero[1].preferredWidth, this.tmpRC.sizeDelta.y);
    this.Cstr_Name[1].ClearString();
    cstring1.ClearString();
    cstring2.ClearString();
    if (!this.bNpcMode)
    {
      cstring1.Append(this.Report.Combat.DefenceName);
      if (this.Report.Combat.DefenceAllianceTag != string.Empty)
      {
        cstring2.Append(this.Report.Combat.DefenceAllianceTag);
        GameConstants.FormatRoleName(this.Cstr_Name[1], cstring1, cstring2, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      }
      else
        GameConstants.FormatRoleName(this.Cstr_Name[1], cstring1, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    }
    else
    {
      this.Cstr_Name[1].IntToFormat((long) this.Report.NPCCombat.NPCLevel);
      this.Cstr_Name[1].AppendFormat(this.DM.mStringTable.GetStringByID(12021U));
    }
    this.text_Name[1].text = this.Cstr_Name[1].ToString();
    this.text_Name[1].SetAllDirty();
    this.text_Name[1].cachedTextGenerator.Invalidate();
    if (!this.bNpcMode)
    {
      if (this.Report.Combat.Summary.AssaultLordInCombat == (byte) 1)
      {
        ((Component) this.Img_Crown[0]).gameObject.SetActive(true);
        ((Component) this.Img_MainTitle[0]).gameObject.SetActive(true);
      }
      else
      {
        ((Component) this.Img_Crown[0]).gameObject.SetActive(false);
        ((Component) this.Img_MainTitle[0]).gameObject.SetActive(false);
      }
      if (this.Report.Combat.Summary.DefenceLordInCombat == (byte) 1)
      {
        if (this.Report.Combat.CombatPointKind == POINT_KIND.PK_CITY)
        {
          ((Component) this.Img_Crown[2]).gameObject.SetActive(true);
          ((Component) this.Img_MainTitle[1]).gameObject.SetActive(true);
        }
        else
        {
          ((Component) this.Img_Crown[2]).gameObject.SetActive(true);
          ((Component) this.Img_MainTitle[1]).gameObject.SetActive(true);
        }
      }
      else
      {
        ((Component) this.Img_Crown[2]).gameObject.SetActive(false);
        ((Component) this.Img_MainTitle[1]).gameObject.SetActive(false);
      }
    }
    else if (this.Report.NPCCombat.Summary.AssaultLordInCombat == (byte) 1)
    {
      ((Component) this.Img_Crown[0]).gameObject.SetActive(true);
      ((Component) this.Img_MainTitle[0]).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.Img_Crown[0]).gameObject.SetActive(false);
      ((Component) this.Img_MainTitle[0]).gameObject.SetActive(false);
    }
    if (this.bNpcMode)
    {
      ((Component) this.Img_NpcMainHero[0]).gameObject.SetActive(true);
      ((Component) this.text_NpcInfo).gameObject.SetActive(true);
      ((Component) this.text_NpcTroops[0]).gameObject.SetActive(true);
      ((Component) this.text_NpcTroops[1]).gameObject.SetActive(true);
      this.Cstr_NpcTroops.ClearString();
      this.Cstr_NpcTroops.IntToFormat((long) this.Report.NPCCombat.ResurrextTotal, bNumber: true);
      this.Cstr_NpcTroops.AppendFormat("{0}");
      this.text_NpcTroops[1].text = this.Cstr_NpcTroops.ToString();
      this.text_NpcTroops[1].SetAllDirty();
      this.text_NpcTroops[1].cachedTextGenerator.Invalidate();
      ((Component) this.Img_MainHero[3]).gameObject.SetActive(false);
      ((Component) this.Img_Crown[2]).gameObject.SetActive(false);
      ((Component) this.Img_MainTitle[1]).gameObject.SetActive(false);
      this.Img_NpcMainHero[1].sprite = this.GUIM.NpcHead;
      ((MaskableGraphic) this.Img_NpcMainHero[1]).material = this.GUIM.m_WonderMaterial;
      this.Cstr_CoordinateMainHero[1].ClearString();
      this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.NPCCombat.CombatlZone, this.Report.NPCCombat.CombatPoint));
      this.Cstr_CoordinateMainHero[1].IntToFormat((long) this.Report.NPCCombat.KingdomID);
      this.Cstr_CoordinateMainHero[1].IntToFormat((long) (int) this.tmpV.x);
      this.Cstr_CoordinateMainHero[1].IntToFormat((long) (int) this.tmpV.y);
      if (this.GUIM.IsArabic)
        this.Cstr_CoordinateMainHero[1].AppendFormat("{2}:Y {1}:X {0}:K");
      else
        this.Cstr_CoordinateMainHero[1].AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
      this.text_NpcCoordinate.text = this.Cstr_CoordinateMainHero[1].ToString();
      this.text_NpcCoordinate.SetAllDirty();
      this.text_NpcCoordinate.cachedTextGenerator.Invalidate();
      this.text_NpcCoordinate.cachedTextGeneratorForLayout.Invalidate();
      this.tmpRC = ((Component) this.btn_NpcCoordinate).transform.GetComponent<RectTransform>();
      this.tmpRC.sizeDelta = new Vector2(this.text_NpcCoordinate.preferredWidth, this.tmpRC.sizeDelta.y);
      this.tmpRC = ((Component) this.btn_NpcCoordinate).transform.GetChild(0).GetComponent<RectTransform>();
      this.tmpRC.sizeDelta = new Vector2(this.text_NpcCoordinate.preferredWidth, this.tmpRC.sizeDelta.y);
      this.tmpRC = ((Component) this.btn_NpcCoordinate).transform.GetChild(1).GetComponent<RectTransform>();
      this.tmpRC.sizeDelta = new Vector2(this.text_NpcCoordinate.preferredWidth, this.tmpRC.sizeDelta.y);
      this.Cstr_Name[1].ClearString();
      cstring1.ClearString();
      cstring2.ClearString();
      this.Cstr_Name[1].IntToFormat((long) this.Report.NPCCombat.NPCLevel);
      this.Cstr_Name[1].AppendFormat(this.DM.mStringTable.GetStringByID(12021U));
      this.text_NpcName.text = this.Cstr_Name[1].ToString();
      this.text_NpcName.SetAllDirty();
      this.text_NpcName.cachedTextGenerator.Invalidate();
    }
    else
    {
      ((Component) this.Img_NpcMainHero[0]).gameObject.SetActive(false);
      ((Component) this.text_NpcInfo).gameObject.SetActive(false);
      ((Component) this.text_NpcTroops[0]).gameObject.SetActive(false);
      ((Component) this.text_NpcTroops[1]).gameObject.SetActive(false);
      ((Component) this.Img_MainHero[3]).gameObject.SetActive(true);
      ((Component) this.Img_Crown[2]).gameObject.SetActive(true);
      ((Component) this.Img_MainTitle[1]).gameObject.SetActive(true);
    }
    this.text_MainHero_F[0].SetAllDirty();
    this.text_MainHero_F[0].cachedTextGenerator.Invalidate();
    this.text_MainHero_F[1].SetAllDirty();
    this.text_MainHero_F[1].cachedTextGenerator.Invalidate();
    this.tmpH -= 41f;
    this.Cstr_LossValue[0].ClearString();
    if (!this.bNpcMode)
      this.Cstr_LossValue[0].IntToFormat((long) (this.Report.Combat.Summary.AssaultTroopInjure + this.Report.Combat.Summary.AssaultTroopDeath), bNumber: true);
    else
      this.Cstr_LossValue[0].IntToFormat((long) (this.Report.NPCCombat.SummaryHead.AssaultTroopInjure + this.Report.NPCCombat.SummaryHead.AssaultTroopDeath), bNumber: true);
    this.Cstr_LossValue[0].AppendFormat("{0}");
    this.text_LossValue[0].text = this.Cstr_LossValue[0].ToString();
    this.text_LossValue[0].SetAllDirty();
    this.text_LossValue[0].cachedTextGenerator.Invalidate();
    this.Cstr_Strength[0].ClearString();
    if (!this.bNpcMode)
      this.Cstr_Strength[0].uLongToFormat(this.Report.Combat.Summary.AssaultLosePower, bNumber: true);
    else
      this.Cstr_Strength[0].uLongToFormat(this.Report.NPCCombat.SummaryHead.AssaultLosePower, bNumber: true);
    this.Cstr_Strength[0].AppendFormat(this.DM.mStringTable.GetStringByID(5322U));
    this.text_Strength[0].text = this.Cstr_Strength[0].ToString();
    this.text_Strength[0].SetAllDirty();
    this.text_Strength[0].cachedTextGenerator.Invalidate();
    this.Cstr_LA[0].ClearString();
    if (!this.bNpcMode)
    {
      this.Cstr_LA[0].IntToFormat((long) this.Report.Combat.Summary.AssaultTroopForce, bNumber: true);
      this.tmpValue = this.Report.Combat.Summary.AssaultTroopForce;
    }
    else
    {
      this.Cstr_LA[0].IntToFormat((long) this.Report.NPCCombat.SummaryHead.AssaultTroopForce, bNumber: true);
      this.tmpValue = this.Report.NPCCombat.SummaryHead.AssaultTroopForce;
    }
    this.Cstr_LA[0].AppendFormat("{0}");
    this.text_LA[0].text = this.Cstr_LA[0].ToString();
    this.text_LA[0].SetAllDirty();
    this.text_LA[0].cachedTextGenerator.Invalidate();
    this.Cstr_LA[1].ClearString();
    if (!this.bNpcMode)
    {
      this.Cstr_LA[1].IntToFormat((long) this.Report.Combat.Summary.AssaultTroopInjure, bNumber: true);
      this.tmpValue -= this.Report.Combat.Summary.AssaultTroopInjure;
    }
    else
    {
      this.Cstr_LA[1].IntToFormat((long) this.Report.NPCCombat.SummaryHead.AssaultTroopInjure, bNumber: true);
      this.tmpValue -= this.Report.NPCCombat.SummaryHead.AssaultTroopInjure;
    }
    this.Cstr_LA[1].AppendFormat("{0}");
    this.text_LA[1].text = this.Cstr_LA[1].ToString();
    this.text_LA[1].SetAllDirty();
    this.text_LA[1].cachedTextGenerator.Invalidate();
    this.Cstr_LA[2].ClearString();
    if (!this.bNpcMode)
    {
      this.Cstr_LA[2].IntToFormat((long) this.Report.Combat.Summary.AssaultTroopDeath, bNumber: true);
      this.tmpValue -= this.Report.Combat.Summary.AssaultTroopDeath;
    }
    else
    {
      this.Cstr_LA[2].IntToFormat((long) this.Report.NPCCombat.SummaryHead.AssaultTroopDeath, bNumber: true);
      this.tmpValue -= this.Report.NPCCombat.SummaryHead.AssaultTroopDeath;
    }
    this.Cstr_LA[2].AppendFormat("{0}");
    this.text_LA[2].text = this.Cstr_LA[2].ToString();
    this.text_LA[2].SetAllDirty();
    this.text_LA[2].cachedTextGenerator.Invalidate();
    this.Cstr_LA[3].ClearString();
    this.Cstr_LA[3].IntToFormat((long) this.tmpValue, bNumber: true);
    this.Cstr_LA[3].AppendFormat("{0}");
    this.text_LA[3].text = this.Cstr_LA[3].ToString();
    this.text_LA[3].SetAllDirty();
    this.text_LA[3].cachedTextGenerator.Invalidate();
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 17 || !this.bNpcMode && this.Report.Combat.Defcoord != (byte) 0 || this.bNpcMode && this.Report.NPCCombat.DefenceArmyCoord != (byte) 0)
    {
      flag3 = true;
      flag2 = true;
    }
    if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 17)
    {
      flag1 = true;
      this.text_Formation.text = this.DM.mStringTable.GetStringByID(9796U);
    }
    else
      this.text_Formation.text = this.DM.mStringTable.GetStringByID(9795U);
    this.text_Formation.SetAllDirty();
    this.text_Formation.cachedTextGenerator.Invalidate();
    this.text_Formation.cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_Formation.preferredWidth < 400.0)
    {
      ((Graphic) this.text_Formation).rectTransform.sizeDelta = new Vector2(this.text_Formation.preferredWidth, ((Graphic) this.text_Formation).rectTransform.sizeDelta.y);
      ((Graphic) this.Img_FormationHint).rectTransform.sizeDelta = new Vector2(this.text_Formation.preferredWidth + 10f, ((Graphic) this.Img_FormationHint).rectTransform.sizeDelta.y);
    }
    else
    {
      ((Graphic) this.text_Formation).rectTransform.sizeDelta = new Vector2(400f, ((Graphic) this.text_Formation).rectTransform.sizeDelta.y);
      ((Graphic) this.Img_FormationHint).rectTransform.sizeDelta = new Vector2(410f, ((Graphic) this.Img_FormationHint).rectTransform.sizeDelta.y);
    }
    if ((double) this.text_Formation.preferredHeight > (double) ((Graphic) this.text_Formation).rectTransform.sizeDelta.y)
    {
      ((Graphic) this.text_Formation).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Formation).rectTransform.sizeDelta.x, this.text_Formation.preferredHeight + 1f);
      ((Graphic) this.Img_FormationHint).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_FormationHint).rectTransform.sizeDelta.x, this.text_Formation.preferredHeight + 10f);
    }
    if (this.GUIM.IsArabic)
      this.text_Formation.UpdateArabicPos();
    if (flag1)
    {
      this.Cstr_LF.ClearString();
      this.Cstr_LF.Append(this.DM.mStringTable.GetStringByID(9788U));
      if (!this.bNpcMode)
        this.Cstr_LF.Append(this.DM.mStringTable.GetStringByID((uint) (ushort) (9778U + (uint) this.Report.Combat.Atkcoord)));
      else
        this.Cstr_LF.Append(this.DM.mStringTable.GetStringByID((uint) (ushort) (9778U + (uint) this.Report.NPCCombat.AssaultArmyCoord)));
      this.text_LF.text = this.Cstr_LF.ToString();
      this.text_LF.SetAllDirty();
      this.text_LF.cachedTextGenerator.Invalidate();
      this.text_LF.cachedTextGeneratorForLayout.Invalidate();
      float x = (double) this.text_LF.preferredWidth + 1.0 <= 390.0 ? this.text_LF.preferredWidth + 1f : 390f;
      ((Graphic) this.text_LF).rectTransform.sizeDelta = new Vector2(x, ((Graphic) this.text_LF).rectTransform.sizeDelta.y);
      if (this.GUIM.IsArabic)
        this.text_LF.UpdateArabicPos();
      this.tmpRC = ((Component) this.btn_LF).transform.GetComponent<RectTransform>();
      this.tmpRC.sizeDelta = new Vector2(x, this.tmpRC.sizeDelta.y);
      ((Graphic) this.Img_LF).rectTransform.sizeDelta = new Vector2(x, ((Graphic) this.Img_LF).rectTransform.sizeDelta.y);
      ((Component) this.btn_LF).gameObject.SetActive(true);
    }
    else
      ((Component) this.btn_LF).gameObject.SetActive(false);
    if (flag3)
    {
      for (int index = 0; index < 4; ++index)
      {
        ((Graphic) this.text_tmpStr[5 + index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_tmpStr[5 + index]).rectTransform.anchoredPosition.x, (float) (-95.0 - (double) index * 33.0 - 33.0));
        ((Graphic) this.text_LA[index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_LA[index]).rectTransform.anchoredPosition.x, (float) (-95.0 - (double) index * 33.0 - 33.0));
      }
      if (this.bNpcMode)
      {
        ((Graphic) this.text_NpcInfo).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_NpcInfo).rectTransform.anchoredPosition.x, -310f);
        ((Graphic) this.text_NpcTroops[0]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_NpcTroops[0]).rectTransform.anchoredPosition.x, -396f);
        ((Graphic) this.text_NpcTroops[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_NpcTroops[1]).rectTransform.anchoredPosition.x, -396f);
      }
    }
    else
    {
      for (int index = 0; index < 4; ++index)
      {
        ((Graphic) this.text_tmpStr[5 + index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_tmpStr[5 + index]).rectTransform.anchoredPosition.x, (float) (-95.0 - (double) index * 33.0));
        ((Graphic) this.text_LA[index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_LA[index]).rectTransform.anchoredPosition.x, (float) (-95.0 - (double) index * 33.0));
      }
      if (this.bNpcMode)
      {
        ((Graphic) this.text_NpcInfo).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_NpcInfo).rectTransform.anchoredPosition.x, -277f);
        ((Graphic) this.text_NpcTroops[0]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_NpcTroops[0]).rectTransform.anchoredPosition.x, -363f);
        ((Graphic) this.text_NpcTroops[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_NpcTroops[1]).rectTransform.anchoredPosition.x, -363f);
      }
    }
    this.Cstr_LossValue[1].ClearString();
    if (!this.bNpcMode)
      this.Cstr_LossValue[1].IntToFormat((long) (this.Report.Combat.Summary.DefenceTroopInjure + this.Report.Combat.Summary.DefenceTroopDeath + this.Report.Combat.Summary.LoseTrapNumber + this.Report.Combat.Summary.SaveTrapNumber), bNumber: true);
    else
      this.Cstr_LossValue[1].IntToFormat((long) (this.Report.NPCCombat.SummaryHead.DefenceTroopInjure + this.Report.NPCCombat.SummaryHead.DefenceTroopDeath + this.Report.NPCCombat.Summary.LoseTrapNumber + this.Report.NPCCombat.Summary.SaveTrapNumber), bNumber: true);
    this.Cstr_LossValue[1].AppendFormat("{0}");
    this.text_LossValue[1].text = this.Cstr_LossValue[1].ToString();
    this.text_LossValue[1].SetAllDirty();
    this.text_LossValue[1].cachedTextGenerator.Invalidate();
    this.Cstr_Strength[1].ClearString();
    if (!this.bNpcMode)
      this.Cstr_Strength[1].uLongToFormat(this.Report.Combat.Summary.DefenceLosePower, bNumber: true);
    else
      this.Cstr_Strength[1].uLongToFormat(this.Report.NPCCombat.SummaryHead.DefenceLosePower, bNumber: true);
    this.Cstr_Strength[1].AppendFormat(this.DM.mStringTable.GetStringByID(5322U));
    this.text_Strength[1].text = this.Cstr_Strength[1].ToString();
    this.text_Strength[1].SetAllDirty();
    this.text_Strength[1].cachedTextGenerator.Invalidate();
    this.Cstr_RA[0].ClearString();
    if (!this.bNpcMode)
    {
      this.Cstr_RA[0].IntToFormat((long) this.Report.Combat.Summary.DefenceTroopForce, bNumber: true);
      this.tmpValue = this.Report.Combat.Summary.DefenceTroopForce;
    }
    else
    {
      this.Cstr_RA[0].IntToFormat((long) this.Report.NPCCombat.SummaryHead.DefenceTroopForce, bNumber: true);
      this.tmpValue = this.Report.NPCCombat.SummaryHead.DefenceTroopForce;
    }
    this.Cstr_RA[0].AppendFormat("{0}");
    this.text_RA[0].text = this.Cstr_RA[0].ToString();
    this.Cstr_RA[1].ClearString();
    if (!this.bNpcMode)
    {
      this.Cstr_RA[1].IntToFormat((long) this.Report.Combat.Summary.DefenceTroopInjure, bNumber: true);
      this.tmpValue -= this.Report.Combat.Summary.DefenceTroopInjure;
    }
    else
    {
      this.Cstr_RA[1].IntToFormat((long) this.Report.NPCCombat.SummaryHead.DefenceTroopInjure, bNumber: true);
      this.tmpValue -= this.Report.NPCCombat.SummaryHead.DefenceTroopInjure;
    }
    this.Cstr_RA[1].AppendFormat("{0}");
    this.text_RA[1].text = this.Cstr_RA[1].ToString();
    this.Cstr_RA[2].ClearString();
    if (!this.bNpcMode)
    {
      this.Cstr_RA[2].IntToFormat((long) this.Report.Combat.Summary.DefenceTroopDeath, bNumber: true);
      this.tmpValue -= this.Report.Combat.Summary.DefenceTroopDeath;
    }
    else
    {
      this.Cstr_RA[2].IntToFormat((long) this.Report.NPCCombat.SummaryHead.DefenceTroopDeath, bNumber: true);
      this.tmpValue -= this.Report.NPCCombat.SummaryHead.DefenceTroopDeath;
    }
    this.Cstr_RA[2].AppendFormat("{0}");
    this.text_RA[2].text = this.Cstr_RA[2].ToString();
    this.Cstr_RA[3].ClearString();
    this.Cstr_RA[3].IntToFormat((long) this.tmpValue, bNumber: true);
    this.Cstr_RA[3].AppendFormat("{0}");
    this.text_RA[3].text = this.Cstr_RA[3].ToString();
    this.Cstr_RA[4].ClearString();
    if (!this.bNpcMode)
    {
      this.Cstr_RA[4].IntToFormat((long) this.Report.Combat.Summary.TrapNumber, bNumber: true);
      this.tmpValue = this.Report.Combat.Summary.TrapNumber;
    }
    else
    {
      this.Cstr_RA[4].IntToFormat((long) this.Report.NPCCombat.Summary.TrapNumber, bNumber: true);
      this.tmpValue = this.Report.NPCCombat.Summary.TrapNumber;
    }
    this.Cstr_RA[4].AppendFormat("{0}");
    this.text_RA[4].text = this.Cstr_RA[4].ToString();
    this.Cstr_RA[5].ClearString();
    if (!this.bNpcMode)
    {
      this.Cstr_RA[5].IntToFormat((long) this.Report.Combat.Summary.SaveTrapNumber, bNumber: true);
      this.tmpValue -= this.Report.Combat.Summary.SaveTrapNumber;
    }
    else
    {
      this.Cstr_RA[5].IntToFormat((long) this.Report.NPCCombat.Summary.SaveTrapNumber, bNumber: true);
      this.tmpValue -= this.Report.NPCCombat.Summary.SaveTrapNumber;
    }
    this.Cstr_RA[5].AppendFormat("{0}");
    this.text_RA[5].text = this.Cstr_RA[5].ToString();
    this.Cstr_RA[6].ClearString();
    if (!this.bNpcMode)
    {
      this.Cstr_RA[6].IntToFormat((long) this.Report.Combat.Summary.LoseTrapNumber, bNumber: true);
      this.tmpValue -= this.Report.Combat.Summary.LoseTrapNumber;
    }
    else
    {
      this.Cstr_RA[6].IntToFormat((long) this.Report.NPCCombat.Summary.LoseTrapNumber, bNumber: true);
      this.tmpValue -= this.Report.NPCCombat.Summary.LoseTrapNumber;
    }
    this.Cstr_RA[6].AppendFormat("{0}");
    this.text_RA[6].text = this.Cstr_RA[6].ToString();
    this.Cstr_RA[7].ClearString();
    this.Cstr_RA[7].IntToFormat((long) this.tmpValue, bNumber: true);
    this.Cstr_RA[7].AppendFormat("{0}");
    this.text_RA[7].text = this.Cstr_RA[7].ToString();
    if (this.bNpcMode)
    {
      this.Cstr_NpcTroops.ClearString();
      this.Cstr_NpcTroops.IntToFormat((long) this.Report.NPCCombat.ResurrextTotal, bNumber: true);
      this.Cstr_NpcTroops.AppendFormat("{0}");
      this.text_NpcTroops[1].text = this.Cstr_NpcTroops.ToString();
      this.text_NpcTroops[1].SetAllDirty();
      this.text_NpcTroops[1].cachedTextGenerator.Invalidate();
    }
    for (int index = 0; index < 8; ++index)
    {
      this.text_RA[index].SetAllDirty();
      this.text_RA[index].cachedTextGenerator.Invalidate();
    }
    if (flag3)
    {
      for (int index = 0; index < 4; ++index)
      {
        ((Graphic) this.text_tmpStr[9 + index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_tmpStr[9 + index]).rectTransform.anchoredPosition.x, (float) (-95.0 - (double) index * 33.0 - 33.0));
        ((Graphic) this.text_RA[index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_RA[index]).rectTransform.anchoredPosition.x, (float) (-95.0 - (double) index * 33.0 - 33.0));
        ((Graphic) this.text_tmpStr[13 + index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_tmpStr[13 + index]).rectTransform.anchoredPosition.x, (float) (-264.0 - (double) index * 33.0 - 33.0));
        ((Graphic) this.text_RA[index + 4]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_RA[index + 4]).rectTransform.anchoredPosition.x, (float) (-264.0 - (double) index * 33.0 - 33.0));
      }
    }
    else
    {
      for (int index = 0; index < 4; ++index)
      {
        ((Graphic) this.text_tmpStr[9 + index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_tmpStr[9 + index]).rectTransform.anchoredPosition.x, (float) (-95.0 - (double) index * 33.0));
        ((Graphic) this.text_RA[index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_RA[index]).rectTransform.anchoredPosition.x, (float) (-95.0 - (double) index * 33.0));
        ((Graphic) this.text_tmpStr[13 + index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_tmpStr[13 + index]).rectTransform.anchoredPosition.x, (float) (-264.0 - (double) index * 33.0));
        ((Graphic) this.text_RA[index + 4]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_RA[index + 4]).rectTransform.anchoredPosition.x, (float) (-264.0 - (double) index * 33.0));
      }
    }
    if (flag2)
    {
      this.Cstr_RF.ClearString();
      this.Cstr_RF.Append(this.DM.mStringTable.GetStringByID(9788U));
      if (!this.bNpcMode)
        this.Cstr_RF.Append(this.DM.mStringTable.GetStringByID((uint) (ushort) (9778U + (uint) this.Report.Combat.Defcoord)));
      else
        this.Cstr_RF.Append(this.DM.mStringTable.GetStringByID((uint) (ushort) (9778U + (uint) this.Report.NPCCombat.DefenceArmyCoord)));
      this.text_RF.text = this.Cstr_RF.ToString();
      this.text_RF.SetAllDirty();
      this.text_RF.cachedTextGenerator.Invalidate();
      this.text_RF.cachedTextGeneratorForLayout.Invalidate();
      float x = (double) this.text_RF.preferredWidth + 1.0 <= 390.0 ? this.text_RF.preferredWidth + 1f : 390f;
      ((Graphic) this.text_RF).rectTransform.sizeDelta = new Vector2(x, ((Graphic) this.text_RF).rectTransform.sizeDelta.y);
      if (this.GUIM.IsArabic)
        this.text_RF.UpdateArabicPos();
      this.tmpRC = ((Component) this.btn_RF).transform.GetComponent<RectTransform>();
      this.tmpRC.sizeDelta = new Vector2(x, this.tmpRC.sizeDelta.y);
      ((Graphic) this.Img_RF).rectTransform.sizeDelta = new Vector2(x, ((Graphic) this.Img_RF).rectTransform.sizeDelta.y);
      ((Component) this.btn_RF).gameObject.SetActive(true);
    }
    else
      ((Component) this.btn_RF).gameObject.SetActive(false);
    if (flag3)
      this.tmpH -= 33f;
    this.tmpH -= 498f;
    this.Cstr_DW[0].ClearString();
    if (!this.bNpcMode)
    {
      this.Cstr_DW[0].IntToFormat((long) this.Report.Combat.Summary.WallDefence, bNumber: true);
      this.tmpValue = this.Report.Combat.Summary.WallDefence;
    }
    else
    {
      this.Cstr_DW[0].IntToFormat((long) this.Report.NPCCombat.Summary.WallDefence, bNumber: true);
      this.tmpValue = this.Report.NPCCombat.Summary.WallDefence;
    }
    this.Cstr_DW[0].AppendFormat("{0}");
    this.text_DW[0].text = this.Cstr_DW[0].ToString();
    this.Cstr_DW[1].ClearString();
    if (!this.bNpcMode)
    {
      this.Cstr_DW[1].IntToFormat((long) this.Report.Combat.Summary.WallDamage, bNumber: true);
      this.tmpValue -= this.Report.Combat.Summary.WallDamage;
    }
    else
    {
      this.Cstr_DW[1].IntToFormat((long) this.Report.NPCCombat.Summary.WallDamage, bNumber: true);
      this.tmpValue -= this.Report.NPCCombat.Summary.WallDamage;
    }
    this.Cstr_DW[1].AppendFormat("{0}");
    this.text_DW[1].text = this.Cstr_DW[1].ToString();
    this.Cstr_DW[2].ClearString();
    this.Cstr_DW[2].IntToFormat((long) this.tmpValue, bNumber: true);
    this.Cstr_DW[2].AppendFormat("{0}");
    this.text_DW[2].text = this.Cstr_DW[2].ToString();
    for (int index = 0; index < 3; ++index)
    {
      this.text_DW[index].SetAllDirty();
      this.text_DW[index].cachedTextGenerator.Invalidate();
    }
    if (!this.bNpcMode && (int) this.Report.Combat.AssaultKingdomID != (int) this.Report.Combat.DefenceKingdomID)
    {
      ((Component) this.Img_Country[0]).gameObject.SetActive(true);
      ((Component) this.Img_Country[1]).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.Img_Country[0]).gameObject.SetActive(false);
      ((Component) this.Img_Country[1]).gameObject.SetActive(false);
    }
    this.tmpH -= 281f;
    this.Cstr_Offensive[0].ClearString();
    this.Cstr_Offensive[1].ClearString();
    if (this.IsAttack)
    {
      this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(5315U));
      this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(5317U));
      this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(5316U));
      this.text_ArmyTitle[0].text = this.DM.mStringTable.GetStringByID(5323U);
      this.text_ArmyTitle[1].text = this.DM.mStringTable.GetStringByID(5324U);
      this.Img_Summarybg[0].sprite = this.SArray.m_Sprites[2];
      this.Img_Summarybg[1].sprite = this.SArray.m_Sprites[3];
      this.Img_MainTitle[0].sprite = this.SArray.m_Sprites[6];
      this.Img_MainTitle[1].sprite = this.SArray.m_Sprites[7];
      this.Img_Army[0].sprite = this.SArray.m_Sprites[4];
      this.Img_Army2[0].sprite = this.SArray.m_Sprites[14];
      this.Img_Army[1].sprite = this.SArray.m_Sprites[5];
      this.Img_Army2[1].sprite = this.SArray.m_Sprites[15];
      this.Img_CWall[0].sprite = this.SArray.m_Sprites[4];
      this.Img_CWall[1].sprite = this.SArray.m_Sprites[5];
      if (!this.bNpcMode && this.Report.Combat.Summary.IsLeader == (byte) 1)
        ((Component) this.Img_Muster[0]).gameObject.SetActive(true);
      else if (this.bNpcMode && this.Report.NPCCombat.Summary.IsLeader == (byte) 1)
        ((Component) this.Img_Muster[0]).gameObject.SetActive(true);
      this.Img_Bf_BG_L[0].sprite = this.SArray.m_Sprites[19];
      this.Img_Bf_BG_L[1].sprite = this.SArray.m_Sprites[20];
      this.Img_Bf_BG_L[2].sprite = this.SArray.m_Sprites[19];
      this.Img_Bf_BG_R[0].sprite = this.SArray.m_Sprites[21];
      this.Img_Bf_BG_R[1].sprite = this.SArray.m_Sprites[22];
      this.Img_Bf_BG_R[2].sprite = this.SArray.m_Sprites[21];
    }
    else
    {
      this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(5315U));
      this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(5316U));
      this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(5317U));
      this.text_ArmyTitle[0].text = this.DM.mStringTable.GetStringByID(5324U);
      this.text_ArmyTitle[1].text = this.DM.mStringTable.GetStringByID(5323U);
      this.Img_Summarybg[0].sprite = this.SArray.m_Sprites[3];
      this.Img_Summarybg[1].sprite = this.SArray.m_Sprites[2];
      this.Img_MainTitle[0].sprite = this.SArray.m_Sprites[7];
      this.Img_MainTitle[1].sprite = this.SArray.m_Sprites[6];
      this.Img_Army[0].sprite = this.SArray.m_Sprites[5];
      this.Img_Army2[0].sprite = this.SArray.m_Sprites[15];
      this.Img_Army[1].sprite = this.SArray.m_Sprites[4];
      this.Img_Army2[1].sprite = this.SArray.m_Sprites[14];
      this.Img_CWall[0].sprite = this.SArray.m_Sprites[5];
      this.Img_CWall[1].sprite = this.SArray.m_Sprites[4];
      this.Img_Bf_BG_L[0].sprite = this.SArray.m_Sprites[21];
      this.Img_Bf_BG_L[1].sprite = this.SArray.m_Sprites[22];
      this.Img_Bf_BG_L[2].sprite = this.SArray.m_Sprites[21];
      this.Img_Bf_BG_R[0].sprite = this.SArray.m_Sprites[19];
      this.Img_Bf_BG_R[1].sprite = this.SArray.m_Sprites[20];
      this.Img_Bf_BG_R[2].sprite = this.SArray.m_Sprites[19];
    }
    this.text_Offensive[0].text = this.Cstr_Offensive[0].ToString();
    this.text_Offensive[0].SetAllDirty();
    this.text_Offensive[0].cachedTextGenerator.Invalidate();
    this.text_Offensive[1].text = this.Cstr_Offensive[1].ToString();
    this.text_Offensive[1].SetAllDirty();
    this.text_Offensive[1].cachedTextGenerator.Invalidate();
    this.text_ArmyTitle[0].SetAllDirty();
    this.text_ArmyTitle[0].cachedTextGenerator.Invalidate();
    this.text_ArmyTitle[1].SetAllDirty();
    this.text_ArmyTitle[1].cachedTextGenerator.Invalidate();
    if (this.bQuanmier)
    {
      this.tmpH = 0.0f;
      ((Component) this.text_QuanmierNpcInfo).gameObject.SetActive(false);
      ((Component) this.text_QuanmierNpcTroops[0]).gameObject.SetActive(false);
      ((Component) this.text_QuanmierNpcTroops[1]).gameObject.SetActive(false);
      this.Cstr_FightingKind.ClearString();
      if (!this.bNpcMode)
      {
        switch (this.Report.Combat.Result)
        {
          case CombatReportResultType.ECRR_COMBATMASSIVEDEFEAT:
            this.Cstr_FightingKind.Append(this.DM.mStringTable.GetStringByID(5385U));
            this.Cstr_Quanmie[0].ClearString();
            this.Cstr_Quanmie[1].ClearString();
            this.Cstr_Quanmie[2].ClearString();
            this.Cstr_Quanmie[3].ClearString();
            if (this.IsAttack)
            {
              this.Cstr_Quanmie[0].uLongToFormat(this.Report.Combat.Summary.AssaultLosePower, bNumber: true);
              StringManager.IntToStr(this.Cstr_Quanmie[1], (long) this.Report.Combat.Summary.AssaultTroopForce, bNumber: true);
              this.text_Quanmie[5].text = this.Cstr_Quanmie[1].ToString();
              StringManager.IntToStr(this.Cstr_Quanmie[2], (long) this.Report.Combat.Summary.AssaultTroopInjure, bNumber: true);
              this.text_Quanmie[6].text = this.Cstr_Quanmie[2].ToString();
              StringManager.IntToStr(this.Cstr_Quanmie[3], (long) this.Report.Combat.Summary.AssaultTroopDeath, bNumber: true);
              this.text_Quanmie[7].text = this.Cstr_Quanmie[3].ToString();
            }
            else
            {
              this.Cstr_Quanmie[0].uLongToFormat(this.Report.Combat.Summary.DefenceLosePower, bNumber: true);
              StringManager.IntToStr(this.Cstr_Quanmie[1], (long) this.Report.Combat.Summary.DefenceTroopForce, bNumber: true);
              this.text_Quanmie[5].text = this.Cstr_Quanmie[1].ToString();
              StringManager.IntToStr(this.Cstr_Quanmie[2], (long) this.Report.Combat.Summary.DefenceTroopInjure, bNumber: true);
              this.text_Quanmie[6].text = this.Cstr_Quanmie[2].ToString();
              StringManager.IntToStr(this.Cstr_Quanmie[3], (long) this.Report.Combat.Summary.DefenceTroopDeath, bNumber: true);
              this.text_Quanmie[7].text = this.Cstr_Quanmie[3].ToString();
            }
            this.Cstr_Quanmie[0].AppendFormat(this.DM.mStringTable.GetStringByID(5322U));
            this.text_Quanmie[1].text = this.Cstr_Quanmie[0].ToString();
            this.text_Quanmie[1].SetAllDirty();
            this.text_Quanmie[1].cachedTextGenerator.Invalidate();
            this.text_Quanmie[5].SetAllDirty();
            this.text_Quanmie[5].cachedTextGenerator.Invalidate();
            this.text_Quanmie[6].SetAllDirty();
            this.text_Quanmie[6].cachedTextGenerator.Invalidate();
            this.text_Quanmie[7].SetAllDirty();
            this.text_Quanmie[7].cachedTextGenerator.Invalidate();
            break;
          case CombatReportResultType.ECRR_DEFENDERSHIELDUP:
            CString Tag1 = StringManager.Instance.StaticString1024();
            cstring1.ClearString();
            cstring2.ClearString();
            Tag1.ClearString();
            cstring2.Append(this.Report.Combat.DefenceName);
            if (this.Report.Combat.DefenceAllianceTag.Length != 0)
            {
              Tag1.Append(this.Report.Combat.DefenceAllianceTag);
              if ((int) this.Report.Combat.KingdomID != (int) this.Report.Combat.DefenceKingdomID)
                this.GUIM.FormatRoleNameForChat(cstring1, cstring2, Tag1, this.Report.Combat.DefenceKingdomID, this.GUIM.IsArabic);
              else
                this.GUIM.FormatRoleNameForChat(cstring1, cstring2, Tag1, (ushort) 0, this.GUIM.IsArabic);
            }
            else if ((int) this.Report.Combat.KingdomID != (int) this.Report.Combat.DefenceKingdomID)
              this.GUIM.FormatRoleNameForChat(cstring1, cstring2, KingdomID: this.Report.Combat.DefenceKingdomID, ForceArabic: this.GUIM.IsArabic);
            else
              this.GUIM.FormatRoleNameForChat(cstring1, cstring2, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
            this.Cstr_FightingKind.Append(cstring1);
            this.Cstr_FightingKind.Append(this.DM.mStringTable.GetStringByID(626U));
            break;
          case CombatReportResultType.ECRR_ALLYDEFENDER:
            this.Cstr_FightingKind.Append(this.DM.mStringTable.GetStringByID(652U));
            break;
          case CombatReportResultType.ECRR_TAKEOVERWONDER:
            if (this.Report.Combat.Side == (byte) 0)
            {
              this.Cstr_FightingKind.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
              this.Cstr_FightingKind.AppendFormat(this.DM.mStringTable.GetStringByID(7264U));
              this.Cstr_Text.ClearString();
              if (this.Report.Combat.CombatPoint == (byte) 0 || (int) this.Report.Combat.KingdomID == (int) ActivityManager.Instance.KOWKingdomID)
                this.Cstr_Text.StringToFormat(this.DM.mStringTable.GetStringByID(9308U));
              else
                this.Cstr_Text.StringToFormat(this.DM.mStringTable.GetStringByID(9309U));
              this.Cstr_Text.AppendFormat(this.DM.mStringTable.GetStringByID(7265U));
              this.text_Summary.text = this.Cstr_Text.ToString();
              break;
            }
            CString Tag2 = StringManager.Instance.StaticString1024();
            cstring1.ClearString();
            cstring2.ClearString();
            Tag2.ClearString();
            Tag2.Append(this.Report.Combat.AssaultAllianceTag);
            cstring2.Append(this.Report.Combat.AssaultName);
            this.GUIM.FormatRoleNameForChat(cstring1, cstring2, Tag2, (ushort) 0, this.GUIM.IsArabic);
            if (this.GUIM.IsArabic)
            {
              this.Cstr_FightingKind.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
              this.Cstr_FightingKind.StringToFormat(cstring1);
            }
            else
            {
              this.Cstr_FightingKind.StringToFormat(cstring1);
              this.Cstr_FightingKind.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.Report.Combat.CombatPoint, this.Report.Combat.KingdomID));
            }
            this.Cstr_FightingKind.AppendFormat(this.DM.mStringTable.GetStringByID(7261U));
            this.Cstr_Text.ClearString();
            if (this.Report.Combat.CombatPoint == (byte) 0 || (int) this.Report.Combat.KingdomID == (int) ActivityManager.Instance.KOWKingdomID)
              this.Cstr_Text.StringToFormat(this.DM.mStringTable.GetStringByID(9308U));
            else
              this.Cstr_Text.StringToFormat(this.DM.mStringTable.GetStringByID(9309U));
            this.Cstr_Text.AppendFormat(this.DM.mStringTable.GetStringByID(7265U));
            this.text_Summary.text = this.Cstr_Text.ToString();
            break;
        }
      }
      else if (this.bNpcMode)
      {
        this.Cstr_Quanmie[0].ClearString();
        this.Cstr_Quanmie[1].ClearString();
        this.Cstr_Quanmie[2].ClearString();
        this.Cstr_Quanmie[3].ClearString();
        StringManager.IntToStr(this.Cstr_Quanmie[1], (long) this.Report.NPCCombat.SummaryHead.AssaultTroopForce, bNumber: true);
        this.text_Quanmie[5].text = this.Cstr_Quanmie[1].ToString();
        StringManager.IntToStr(this.Cstr_Quanmie[2], (long) this.Report.NPCCombat.SummaryHead.AssaultTroopInjure, bNumber: true);
        this.text_Quanmie[6].text = this.Cstr_Quanmie[2].ToString();
        StringManager.IntToStr(this.Cstr_Quanmie[3], (long) this.Report.NPCCombat.SummaryHead.AssaultTroopDeath, bNumber: true);
        this.text_Quanmie[7].text = this.Cstr_Quanmie[3].ToString();
        this.Cstr_Quanmie[0].uLongToFormat(this.Report.NPCCombat.SummaryHead.AssaultLosePower, bNumber: true);
        this.Cstr_Quanmie[0].AppendFormat(this.DM.mStringTable.GetStringByID(5322U));
        this.text_Quanmie[1].text = this.Cstr_Quanmie[0].ToString();
        this.text_Quanmie[1].SetAllDirty();
        this.text_Quanmie[1].cachedTextGenerator.Invalidate();
        this.text_Quanmie[5].SetAllDirty();
        this.text_Quanmie[5].cachedTextGenerator.Invalidate();
        this.text_Quanmie[6].SetAllDirty();
        this.text_Quanmie[6].cachedTextGenerator.Invalidate();
        this.text_Quanmie[7].SetAllDirty();
        this.text_Quanmie[7].cachedTextGenerator.Invalidate();
        ((Component) this.text_QuanmierNpcInfo).gameObject.SetActive(true);
        ((Component) this.text_QuanmierNpcTroops[0]).gameObject.SetActive(true);
        ((Component) this.text_QuanmierNpcTroops[1]).gameObject.SetActive(true);
        this.Cstr_FightingKind.Append(this.DM.mStringTable.GetStringByID(5385U));
        if (this.bNpcMode)
        {
          this.Cstr_QuanmieNpcTroops.ClearString();
          this.Cstr_QuanmieNpcTroops.IntToFormat((long) this.Report.NPCCombat.ResurrextTotal, bNumber: true);
          this.Cstr_QuanmieNpcTroops.AppendFormat("{0}");
          this.text_QuanmierNpcTroops[1].text = this.Cstr_QuanmieNpcTroops.ToString();
          this.text_QuanmierNpcTroops[1].SetAllDirty();
          this.text_QuanmierNpcTroops[1].cachedTextGenerator.Invalidate();
        }
      }
      this.text_Summary.SetAllDirty();
      this.text_Summary.cachedTextGenerator.Invalidate();
      this.text_FightingKind.text = this.Cstr_FightingKind.ToString();
      this.text_FightingKind.SetAllDirty();
      this.text_FightingKind.cachedTextGenerator.Invalidate();
      ((Component) this.Img_Quanmie).gameObject.SetActive(true);
      ((Graphic) this.text_FightingKind).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_FightingKind).rectTransform.anchoredPosition.x, -36f);
      if (!this.bNpcMode && (this.IsAttack && this.Report.Combat.Summary.AssaultLosePower == 0UL || !this.IsAttack && this.Report.Combat.Summary.DefenceLosePower == 0UL))
      {
        ((Graphic) this.text_FightingKind).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_FightingKind).rectTransform.anchoredPosition.x, -152f);
        ((Component) this.Img_Quanmie).gameObject.SetActive(false);
      }
      else if (this.bNpcMode)
      {
        if (((Component) this.text_QuanmierNpcInfo).gameObject.activeSelf)
          ((Graphic) this.text_FightingKind).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_FightingKind).rectTransform.anchoredPosition.x, -36f);
        else
          ((Graphic) this.text_FightingKind).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_FightingKind).rectTransform.anchoredPosition.x, -36f);
      }
      if ((double) this.text_FightingKind.preferredHeight > 68.0)
      {
        ((Graphic) this.text_FightingKind).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_FightingKind).rectTransform.sizeDelta.x, this.text_FightingKind.preferredHeight);
        this.text_FightingKind.alignment = TextAnchor.UpperCenter;
      }
      else
      {
        ((Graphic) this.text_FightingKind).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_FightingKind).rectTransform.sizeDelta.x, 68f);
        this.text_FightingKind.alignment = TextAnchor.MiddleCenter;
      }
      ((Component) this.HeroRT).gameObject.SetActive(false);
      ((Component) this.SummaryRT).transform.gameObject.SetActive(false);
      ((Component) this.QuanmieRT).gameObject.SetActive(true);
      this.tmpH1 = this.ReplayerRT.anchoredPosition.y - this.ReplayerRT.sizeDelta.y;
      this.QuanmieRT.anchoredPosition = new Vector2(this.QuanmieRT.anchoredPosition.x, this.tmpH1);
      this.tmpH1 = (float) (441.0 + ((double) this.ReplayerRT.anchoredPosition.y - (double) this.ReplayerRT.sizeDelta.y));
      this.CheckQuanmieBuff();
      if (((Component) this.text_QuanmierNpcInfo).gameObject.activeSelf)
      {
        this.QuanmieRT.sizeDelta = new Vector2(this.QuanmieRT.sizeDelta.x, this.tmpH1 + 65f);
        this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 506f + this.tmpH2);
      }
      else
      {
        this.QuanmieRT.sizeDelta = new Vector2(this.QuanmieRT.sizeDelta.x, this.tmpH1);
        this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, 441f + this.tmpH2);
      }
      ((Component) this.btn_Replay).gameObject.SetActive(false);
    }
    else
    {
      this.tmpH1 = 0.0f;
      ((Component) this.QuanmieRT).gameObject.SetActive(false);
      this.CheckPetSkillShow();
      this.tmpRC = ((Component) this.btn_Details).transform.GetComponent<RectTransform>();
      if (!this.bNpcMode && this.Report.Combat.CombatPointKind == POINT_KIND.PK_CITY && this.Report.Combat.Side < (byte) 4 || this.bNpcMode && this.Report.NPCCombat.CombatPointKind == POINT_KIND.PK_CITY && this.Report.NPCCombat.Side < (byte) 4)
      {
        if (flag3)
        {
          this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x, this.tmpH1 - 1154.5f);
          ((Graphic) this.Img_CWall_P[0]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Img_CWall_P[0]).rectTransform.anchoredPosition.x, -935f);
          ((Graphic) this.Img_CWall_P[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Img_CWall_P[1]).rectTransform.anchoredPosition.x, -935f);
          this.PetSkillRT_L.anchoredPosition = new Vector2(this.PetSkillRT_L.anchoredPosition.x, -1119f);
          this.PetSkillRT_R.anchoredPosition = new Vector2(this.PetSkillRT_R.anchoredPosition.x, -1119f);
        }
        else
        {
          this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x, this.tmpH1 - 1121.5f);
          ((Graphic) this.Img_CWall_P[0]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Img_CWall_P[0]).rectTransform.anchoredPosition.x, -902f);
          ((Graphic) this.Img_CWall_P[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Img_CWall_P[1]).rectTransform.anchoredPosition.x, -902f);
          this.PetSkillRT_L.anchoredPosition = new Vector2(this.PetSkillRT_L.anchoredPosition.x, -1086f);
          this.PetSkillRT_R.anchoredPosition = new Vector2(this.PetSkillRT_R.anchoredPosition.x, -1086f);
        }
        if (flag3)
        {
          ((Graphic) this.Img_Army[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Army[0]).rectTransform.sizeDelta.x, 531f);
          ((Graphic) this.Img_Army[1]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Army[1]).rectTransform.sizeDelta.x, 531f);
        }
        else
        {
          ((Graphic) this.Img_Army[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Army[0]).rectTransform.sizeDelta.x, 498f);
          ((Graphic) this.Img_Army[1]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Army[1]).rectTransform.sizeDelta.x, 498f);
        }
        for (int index = 0; index < 4; ++index)
        {
          ((Component) this.text_tmpStr[13 + index]).gameObject.SetActive(true);
          ((Component) this.text_RA[4 + index]).gameObject.SetActive(true);
        }
        ((Component) this.Img_CWall_P[0]).gameObject.SetActive(true);
        ((Component) this.Img_CWall_P[1]).gameObject.SetActive(true);
        for (int index = 0; index < 6; ++index)
          ((Component) this.text_tmpStr[17 + index]).gameObject.SetActive(true);
        ((Component) this.text_Dominance[1]).gameObject.SetActive(true);
        ((Component) this.Img_Vip[1]).gameObject.SetActive(true);
      }
      else
      {
        this.tmpH += 100f;
        this.tmpH += 281f;
        this.tmpH -= 33f;
        this.tmpRC.anchoredPosition = !flag3 ? new Vector2(this.tmpRC.anchoredPosition.x, this.tmpH1 - 773.5f) : new Vector2(this.tmpRC.anchoredPosition.x, this.tmpH1 - 806.5f);
        if (flag3)
        {
          ((Graphic) this.Img_Army[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Army[0]).rectTransform.sizeDelta.x, 431f);
          ((Graphic) this.Img_Army[1]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Army[1]).rectTransform.sizeDelta.x, 431f);
          this.PetSkillRT_L.anchoredPosition = new Vector2(this.PetSkillRT_L.anchoredPosition.x, -769f);
          this.PetSkillRT_R.anchoredPosition = new Vector2(this.PetSkillRT_R.anchoredPosition.x, -769f);
        }
        else
        {
          ((Graphic) this.Img_Army[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Army[0]).rectTransform.sizeDelta.x, 398f);
          ((Graphic) this.Img_Army[1]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Army[1]).rectTransform.sizeDelta.x, 398f);
          this.PetSkillRT_L.anchoredPosition = new Vector2(this.PetSkillRT_L.anchoredPosition.x, -736f);
          this.PetSkillRT_R.anchoredPosition = new Vector2(this.PetSkillRT_R.anchoredPosition.x, -736f);
        }
        for (int index = 0; index < 4; ++index)
        {
          ((Component) this.text_tmpStr[13 + index]).gameObject.SetActive(false);
          ((Component) this.text_RA[4 + index]).gameObject.SetActive(false);
        }
        ((Component) this.Img_CWall_P[0]).gameObject.SetActive(false);
        ((Component) this.Img_CWall_P[1]).gameObject.SetActive(false);
        for (int index = 0; index < 6; ++index)
          ((Component) this.text_tmpStr[17 + index]).gameObject.SetActive(false);
        if (!this.bNpcMode && this.Report.Combat.CombatPointKind == POINT_KIND.PK_YOLK && this.IsAttack && this.Report.Combat.DefenceAllianceTag.Length == 0)
        {
          ((Component) this.text_Dominance[1]).gameObject.SetActive(false);
          ((Component) this.Img_Vip[1]).gameObject.SetActive(false);
        }
        else
        {
          ((Component) this.text_Dominance[1]).gameObject.SetActive(true);
          ((Component) this.Img_Vip[1]).gameObject.SetActive(true);
        }
      }
      this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, -this.tmpH);
      ((Component) this.btn_Replay).gameObject.SetActive(true);
    }
    if ((UnityEngine.Object) this.BossRT != (UnityEngine.Object) null)
      ((Component) this.BossRT).gameObject.SetActive(false);
    this.bSetFSShow = false;
    this.LightT1.gameObject.SetActive(true);
    ((Component) this.text_Summary).gameObject.SetActive(true);
  }

  public void CheckPetSkillShow()
  {
    for (int index = 0; index < 10; ++index)
      ((Component) this.btn_PetSkill_L[index]).gameObject.SetActive(false);
    for (int index = 0; index < 10; ++index)
      ((Component) this.btn_PetSkill_R[index]).gameObject.SetActive(false);
    ((Component) this.text_Buff[8]).gameObject.SetActive(false);
    ((Component) this.text_Buff[3]).gameObject.SetActive(false);
    ((Component) this.text_Buff[7]).gameObject.SetActive(false);
    if (this.bDoNotShow)
    {
      if (this.mA_Skill_L > 0 || this.mD_Skill_R > 0 || this.mDeBf_A_L > 0 || this.mDeBf_D_R > 0)
      {
        ((Component) this.PetSkillRT_L).gameObject.SetActive(true);
        ((Component) this.PetSkillRT_R).gameObject.SetActive(true);
        this.tmpH += 97f;
        this.tmpH -= 41f;
        this.tmpH -= 166f;
        this.tmpH1 -= 106f;
        ((Component) this.text_Buff[8]).gameObject.SetActive(true);
        ((Graphic) this.Img_Bf_BG_L[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_L[0]).rectTransform.sizeDelta.x, 169f);
        ((Graphic) this.Img_Bf_BG_R[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_R[0]).rectTransform.sizeDelta.x, 169f);
        ((Component) this.Img_Bf_BG_L[1]).gameObject.SetActive(false);
        ((Component) this.Img_Bf_BG_R[1]).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.PetSkillRT_L).gameObject.SetActive(false);
        ((Component) this.PetSkillRT_R).gameObject.SetActive(false);
      }
    }
    else
    {
      CString SpriteName = StringManager.Instance.StaticString1024();
      for (int index = 0; index < this.mA_Skill_L; ++index)
      {
        ((Component) this.btn_PetSkill_L[index]).gameObject.SetActive(true);
        this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_A_Skill_ID[index]);
        SpriteName.ClearString();
        SpriteName.Append('s');
        SpriteName.IntToFormat((long) this.skill.Icon, 5);
        SpriteName.AppendFormat("{0}");
        this.Img_PetSkill_L[index].sprite = this.GUIM.LoadSkillSprite(SpriteName);
      }
      for (int index = 0; index < this.mD_Skill_R; ++index)
      {
        ((Component) this.btn_PetSkill_R[index]).gameObject.SetActive(true);
        this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_D_Skill_ID[index]);
        SpriteName.ClearString();
        SpriteName.Append('s');
        SpriteName.IntToFormat((long) this.skill.Icon, 5);
        SpriteName.AppendFormat("{0}");
        this.Img_PetSkill_R[index].sprite = this.GUIM.LoadSkillSprite(SpriteName);
      }
      if (this.mA_Skill_L == 0)
        ((Component) this.text_Buff[3]).gameObject.SetActive(true);
      else
        ((Component) this.text_Buff[3]).gameObject.SetActive(false);
      if (this.mDeBf_A_L == 0)
        ((Component) this.text_Buff[1]).gameObject.SetActive(true);
      else
        ((Component) this.text_Buff[1]).gameObject.SetActive(false);
      if (this.mD_Skill_R == 0)
        ((Component) this.text_Buff[7]).gameObject.SetActive(true);
      else
        ((Component) this.text_Buff[7]).gameObject.SetActive(false);
      if (this.mDeBf_D_R == 0)
        ((Component) this.text_Buff[5]).gameObject.SetActive(true);
      else
        ((Component) this.text_Buff[5]).gameObject.SetActive(false);
      ((Component) this.text_Buff[0]).gameObject.SetActive(false);
      ((Component) this.text_Buff[4]).gameObject.SetActive(false);
      if (this.mDeBf_A_L > 0 || this.mDeBf_D_R > 0)
      {
        ((Component) this.PetSkillRT_L).gameObject.SetActive(true);
        ((Component) this.PetSkillRT_R).gameObject.SetActive(true);
        ((Component) this.text_Buff[0]).gameObject.SetActive(true);
        ((Component) this.text_Buff[4]).gameObject.SetActive(true);
        this.tmpH += 97f;
        this.tmpH -= 41f;
        this.tmpH1 = 56f;
        ((Component) this.Img_Bf_BG_L[0]).gameObject.SetActive(true);
        if (this.mA_Skill_L > 5 || this.mD_Skill_R > 5)
        {
          this.tmpH -= 197f;
          this.tmpH1 -= 197f;
          ((Graphic) this.Img_Bf_BG_L[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_L[0]).rectTransform.sizeDelta.x, 197f);
          ((Graphic) this.Img_Bf_BG_R[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_R[0]).rectTransform.sizeDelta.x, 197f);
          ((Graphic) this.Img_Bf_BG_L[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Img_Bf_BG_L[1]).rectTransform.anchoredPosition.x, -238f);
          ((Graphic) this.Img_Bf_BG_R[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Img_Bf_BG_R[1]).rectTransform.anchoredPosition.x, -238f);
        }
        else if (this.mA_Skill_L > 0 || this.mD_Skill_R > 0)
        {
          this.tmpH -= 125f;
          this.tmpH1 -= 125f;
          ((Graphic) this.Img_Bf_BG_L[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_L[0]).rectTransform.sizeDelta.x, 125f);
          ((Graphic) this.Img_Bf_BG_R[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_R[0]).rectTransform.sizeDelta.x, 125f);
          ((Graphic) this.Img_Bf_BG_L[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Img_Bf_BG_L[1]).rectTransform.anchoredPosition.x, -166f);
          ((Graphic) this.Img_Bf_BG_R[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Img_Bf_BG_R[1]).rectTransform.anchoredPosition.x, -166f);
        }
        else
        {
          this.tmpH -= 50f;
          this.tmpH1 -= 50f;
          ((Graphic) this.Img_Bf_BG_L[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_L[0]).rectTransform.sizeDelta.x, 50f);
          ((Graphic) this.Img_Bf_BG_R[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_R[0]).rectTransform.sizeDelta.x, 50f);
          ((Graphic) this.Img_Bf_BG_L[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Img_Bf_BG_L[1]).rectTransform.anchoredPosition.x, -91f);
          ((Graphic) this.Img_Bf_BG_R[1]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Img_Bf_BG_R[1]).rectTransform.anchoredPosition.x, -91f);
        }
        ((Component) this.PetSkill_BfIcon_RT_L[0]).gameObject.SetActive(false);
        ((Component) this.PetSkill_BfIcon_RT_L[1]).gameObject.SetActive(false);
        if (this.mA_Skill_L < 5)
        {
          ((Component) this.PetSkill_BfIcon_RT_L[0]).gameObject.SetActive(true);
          ((Component) this.PetSkill_BfIcon_RT_L[1]).gameObject.SetActive(false);
          this.PetSkill_BfIcon_RT_L[0].anchoredPosition = new Vector2(35f, this.PetSkill_BfIcon_RT_L[0].anchoredPosition.y);
        }
        else
        {
          ((Component) this.PetSkill_BfIcon_RT_L[0]).gameObject.SetActive(true);
          ((Component) this.PetSkill_BfIcon_RT_L[1]).gameObject.SetActive(true);
          this.PetSkill_BfIcon_RT_L[0].anchoredPosition = new Vector2(0.0f, this.PetSkill_BfIcon_RT_L[0].anchoredPosition.y);
        }
        ((Component) this.Img_Bf_BG_R[0]).gameObject.SetActive(true);
        ((Component) this.PetSkill_BfIcon_RT_R[0]).gameObject.SetActive(false);
        ((Component) this.PetSkill_BfIcon_RT_R[1]).gameObject.SetActive(false);
        if (this.mD_Skill_R < 5)
        {
          ((Component) this.PetSkill_BfIcon_RT_R[0]).gameObject.SetActive(true);
          ((Component) this.PetSkill_BfIcon_RT_R[1]).gameObject.SetActive(false);
          this.PetSkill_BfIcon_RT_R[0].anchoredPosition = new Vector2(35f, this.PetSkill_BfIcon_RT_R[0].anchoredPosition.y);
        }
        else
        {
          ((Component) this.PetSkill_BfIcon_RT_R[0]).gameObject.SetActive(true);
          ((Component) this.PetSkill_BfIcon_RT_R[1]).gameObject.SetActive(true);
          this.PetSkill_BfIcon_RT_R[0].anchoredPosition = new Vector2(0.0f, this.PetSkill_BfIcon_RT_R[0].anchoredPosition.y);
        }
        ((Component) this.Img_Bf_BG_L[1]).gameObject.SetActive(true);
        ((Component) this.Img_Bf_BG_R[1]).gameObject.SetActive(true);
        this.tmpH -= 50f;
        this.tmpH1 -= 50f;
        ((Component) this.DeBuff_BfIcon_RT_L[0]).gameObject.SetActive(true);
        ((Component) this.DeBuff_BfIcon_RT_R[0]).gameObject.SetActive(true);
        if (this.mDeBf_A_L > 5 || this.mDeBf_D_R > 5)
        {
          this.tmpH -= 313f;
          this.tmpH1 -= 313f;
          ((Graphic) this.Img_Bf_BG_L[2]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_L[2]).rectTransform.sizeDelta.x, 313f);
          ((Graphic) this.Img_Bf_BG_R[2]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_L[2]).rectTransform.sizeDelta.x, 313f);
        }
        else
        {
          this.tmpH -= 241f;
          this.tmpH1 -= 241f;
          ((Graphic) this.Img_Bf_BG_L[2]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_L[2]).rectTransform.sizeDelta.x, 241f);
          ((Graphic) this.Img_Bf_BG_R[2]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_L[2]).rectTransform.sizeDelta.x, 241f);
        }
        for (int index = 0; index < 10; ++index)
          ((Component) this.btn_DeBuff_L[index]).gameObject.SetActive(false);
        if (this.mDeBf_A_L < 5)
        {
          ((Component) this.DeBuff_BfIcon_RT_L[0]).gameObject.SetActive(true);
          ((Component) this.DeBuff_BfIcon_RT_L[1]).gameObject.SetActive(false);
          this.DeBuff_BfIcon_RT_L[0].anchoredPosition = new Vector2(35f, this.DeBuff_BfIcon_RT_L[0].anchoredPosition.y);
        }
        else
        {
          ((Component) this.DeBuff_BfIcon_RT_L[0]).gameObject.SetActive(true);
          ((Component) this.DeBuff_BfIcon_RT_L[1]).gameObject.SetActive(true);
          this.DeBuff_BfIcon_RT_L[0].anchoredPosition = new Vector2(0.0f, this.DeBuff_BfIcon_RT_L[0].anchoredPosition.y);
        }
        for (int index = 0; index < this.mDeBf_A_L; ++index)
        {
          ((Component) this.btn_DeBuff_L[index]).gameObject.SetActive(true);
          this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_A_DeBf_Skill_ID[index]);
          SpriteName.ClearString();
          SpriteName.Append('s');
          SpriteName.IntToFormat((long) this.skill.Icon, 5);
          SpriteName.AppendFormat("{0}");
          this.Img_DeBuff_L[index].sprite = this.GUIM.LoadSkillSprite(SpriteName);
        }
        for (int index = 0; index < 10; ++index)
          ((Component) this.btn_DeBuff_R[index]).gameObject.SetActive(false);
        if (this.mDeBf_D_R < 5)
        {
          ((Component) this.DeBuff_BfIcon_RT_R[0]).gameObject.SetActive(true);
          ((Component) this.DeBuff_BfIcon_RT_R[1]).gameObject.SetActive(false);
          this.DeBuff_BfIcon_RT_R[0].anchoredPosition = new Vector2(35f, this.DeBuff_BfIcon_RT_R[0].anchoredPosition.y);
        }
        else
        {
          ((Component) this.DeBuff_BfIcon_RT_R[0]).gameObject.SetActive(true);
          ((Component) this.DeBuff_BfIcon_RT_R[1]).gameObject.SetActive(true);
          this.DeBuff_BfIcon_RT_R[0].anchoredPosition = new Vector2(0.0f, this.DeBuff_BfIcon_RT_R[0].anchoredPosition.y);
        }
        for (int index = 0; index < this.mDeBf_D_R; ++index)
        {
          ((Component) this.btn_DeBuff_R[index]).gameObject.SetActive(true);
          this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_D_DeBf_Skill_ID[index]);
          SpriteName.ClearString();
          SpriteName.Append('s');
          SpriteName.IntToFormat((long) this.skill.Icon, 5);
          SpriteName.AppendFormat("{0}");
          this.Img_DeBuff_R[index].sprite = this.GUIM.LoadSkillSprite(SpriteName);
        }
      }
      else
      {
        ((Component) this.Img_Bf_BG_L[1]).gameObject.SetActive(false);
        ((Component) this.Img_Bf_BG_R[1]).gameObject.SetActive(false);
        if (this.mA_Skill_L > 0 || this.mD_Skill_R > 0)
        {
          ((Component) this.PetSkillRT_L).gameObject.SetActive(true);
          ((Component) this.PetSkillRT_R).gameObject.SetActive(true);
          this.tmpH -= 41f;
          this.tmpH += 97f;
          this.tmpH1 += 56f;
          ((Component) this.Img_Bf_BG_L[0]).gameObject.SetActive(true);
          if (this.mA_Skill_L >= 5 || this.mD_Skill_R >= 5)
          {
            this.tmpH -= 313f;
            this.tmpH1 -= 313f;
            ((Graphic) this.Img_Bf_BG_L[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_L[0]).rectTransform.sizeDelta.x, 313f);
            ((Graphic) this.Img_Bf_BG_R[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_R[0]).rectTransform.sizeDelta.x, 313f);
          }
          else if (this.mA_Skill_L > 0 || this.mD_Skill_R > 0)
          {
            this.tmpH -= 241f;
            this.tmpH1 -= 241f;
            ((Graphic) this.Img_Bf_BG_L[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_L[0]).rectTransform.sizeDelta.x, 241f);
            ((Graphic) this.Img_Bf_BG_R[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_R[0]).rectTransform.sizeDelta.x, 241f);
          }
          else
          {
            this.tmpH -= 166f;
            this.tmpH1 -= 166f;
            ((Graphic) this.Img_Bf_BG_L[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_L[0]).rectTransform.sizeDelta.x, 166f);
            ((Graphic) this.Img_Bf_BG_R[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Bf_BG_R[0]).rectTransform.sizeDelta.x, 166f);
          }
          if (this.mA_Skill_L == 0)
          {
            ((Component) this.PetSkill_BfIcon_RT_L[0]).gameObject.SetActive(false);
            ((Component) this.PetSkill_BfIcon_RT_L[1]).gameObject.SetActive(false);
          }
          else if (this.mA_Skill_L < 5)
          {
            ((Component) this.PetSkill_BfIcon_RT_L[0]).gameObject.SetActive(true);
            ((Component) this.PetSkill_BfIcon_RT_L[1]).gameObject.SetActive(false);
            this.PetSkill_BfIcon_RT_L[0].anchoredPosition = new Vector2(35f, this.PetSkill_BfIcon_RT_L[0].anchoredPosition.y);
          }
          else
          {
            ((Component) this.PetSkill_BfIcon_RT_L[0]).gameObject.SetActive(true);
            ((Component) this.PetSkill_BfIcon_RT_L[1]).gameObject.SetActive(true);
            this.PetSkill_BfIcon_RT_L[0].anchoredPosition = new Vector2(0.0f, this.PetSkill_BfIcon_RT_L[0].anchoredPosition.y);
          }
          ((Component) this.Img_Bf_BG_R[0]).gameObject.SetActive(true);
          if (this.mD_Skill_R == 0)
          {
            ((Component) this.PetSkill_BfIcon_RT_R[0]).gameObject.SetActive(false);
            ((Component) this.PetSkill_BfIcon_RT_R[1]).gameObject.SetActive(false);
          }
          else if (this.mD_Skill_R < 5)
          {
            ((Component) this.PetSkill_BfIcon_RT_R[0]).gameObject.SetActive(true);
            ((Component) this.PetSkill_BfIcon_RT_R[1]).gameObject.SetActive(false);
            this.PetSkill_BfIcon_RT_R[0].anchoredPosition = new Vector2(35f, this.PetSkill_BfIcon_RT_R[0].anchoredPosition.y);
          }
          else
          {
            ((Component) this.PetSkill_BfIcon_RT_R[0]).gameObject.SetActive(true);
            ((Component) this.PetSkill_BfIcon_RT_R[1]).gameObject.SetActive(true);
            this.PetSkill_BfIcon_RT_R[0].anchoredPosition = new Vector2(0.0f, this.PetSkill_BfIcon_RT_R[0].anchoredPosition.y);
          }
        }
        else
        {
          ((Component) this.PetSkillRT_L).gameObject.SetActive(false);
          ((Component) this.PetSkillRT_R).gameObject.SetActive(false);
        }
      }
    }
  }

  public void CheckQuanmieBuff()
  {
    for (int index = 0; index < 10; ++index)
      ((Component) this.btn_Failure_Skill[index]).gameObject.SetActive(false);
    for (int index = 0; index < 10; ++index)
      ((Component) this.btn_Failure_DeBuff[index]).gameObject.SetActive(false);
    ((Component) this.Failure_Buff_RT[0]).gameObject.SetActive(false);
    ((Component) this.Failure_Buff_RT[1]).gameObject.SetActive(false);
    ((Component) this.Failure_DeBuff_RT[0]).gameObject.SetActive(false);
    ((Component) this.Failure_DeBuff_RT[1]).gameObject.SetActive(false);
    float num = 0.0f;
    if (this.bNpcMode)
      num = 65f;
    this.Failure_Buff_RT[0].anchoredPosition = new Vector2(this.Failure_Buff_RT[0].anchoredPosition.x, -282f - num);
    if (this.bDoNotShow)
    {
      if (this.mA_Skill_L <= 0 && this.mD_Skill_R <= 0 && this.mDeBf_A_L <= 0 && this.mDeBf_D_R <= 0)
        return;
      this.tmpH1 -= 23f;
      this.tmpH2 = -23f;
      ((Component) this.Failure_Buff_RT[0]).gameObject.SetActive(true);
      this.tmpH -= 49f;
      this.tmpH -= 50f;
      this.tmpH1 += 129f;
      this.tmpH2 += 129f;
      ((Component) this.text_FailureBuff[0]).gameObject.SetActive(true);
      this.text_FailureBuff[0].text = this.DM.mStringTable.GetStringByID(10100U);
      this.text_FailureBuff[0].SetAllDirty();
      this.text_FailureBuff[0].cachedTextGenerator.Invalidate();
    }
    else
    {
      CString SpriteName = StringManager.Instance.StaticString1024();
      if (this.IsAttack && this.mDeBf_A_L > 0 || !this.IsAttack && this.mDeBf_D_R > 0)
      {
        this.tmpH1 -= 23f;
        this.tmpH2 = -23f;
        ((Component) this.Failure_Buff_RT[0]).gameObject.SetActive(true);
        ((Component) this.Failure_Buff_RT[1]).gameObject.SetActive(true);
        if (this.IsAttack)
        {
          for (int index = 0; index < this.mA_Skill_L; ++index)
          {
            ((Component) this.btn_Failure_Skill[index]).gameObject.SetActive(true);
            this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_A_Skill_ID[index]);
            SpriteName.ClearString();
            SpriteName.Append('s');
            SpriteName.IntToFormat((long) this.skill.Icon, 5);
            SpriteName.AppendFormat("{0}");
            this.Img_Failure_Skill[index].sprite = this.GUIM.LoadSkillSprite(SpriteName);
          }
          this.tmpH -= 49f;
          this.tmpH1 += 49f;
          this.tmpH2 += 49f;
          ((Component) this.Failure_Skill_RT[0]).gameObject.SetActive(false);
          ((Component) this.Failure_Skill_RT[1]).gameObject.SetActive(false);
          if (this.mA_Skill_L > 5)
          {
            this.tmpH -= 192f;
            this.tmpH1 += 192f;
            this.tmpH2 += 192f;
            ((Component) this.Failure_Skill_RT[0]).gameObject.SetActive(true);
            ((Component) this.Failure_Skill_RT[1]).gameObject.SetActive(true);
            this.Failure_Buff_RT[1].anchoredPosition = new Vector2(this.Failure_Buff_RT[1].anchoredPosition.x, -523f - num);
          }
          else if (this.mA_Skill_L > 0)
          {
            this.tmpH -= 120f;
            this.tmpH1 += 120f;
            this.tmpH2 += 120f;
            ((Component) this.Failure_Skill_RT[0]).gameObject.SetActive(true);
            this.Failure_Buff_RT[1].anchoredPosition = new Vector2(this.Failure_Buff_RT[1].anchoredPosition.x, -451f - num);
          }
          else
          {
            this.tmpH -= 69f;
            this.tmpH1 += 69f;
            this.tmpH2 += 69f;
            this.Failure_Buff_RT[1].anchoredPosition = new Vector2(this.Failure_Buff_RT[1].anchoredPosition.x, -400f - num);
            ((Component) this.text_FailureBuff[0]).gameObject.SetActive(true);
            this.text_FailureBuff[0].text = this.DM.mStringTable.GetStringByID(5334U);
            this.text_FailureBuff[0].SetAllDirty();
            this.text_FailureBuff[0].cachedTextGenerator.Invalidate();
          }
          ((Component) this.Failure_DeBuff_RT[0]).gameObject.SetActive(true);
          ((Component) this.Failure_DeBuff_RT[1]).gameObject.SetActive(false);
          this.tmpH -= 42f;
          this.tmpH1 += 42f;
          this.tmpH2 += 42f;
          if (this.mDeBf_A_L > 5)
          {
            this.tmpH -= 192f;
            this.tmpH1 += 192f;
            this.tmpH2 += 192f;
            ((Component) this.Failure_DeBuff_RT[1]).gameObject.SetActive(true);
          }
          else
          {
            this.tmpH -= 120f;
            this.tmpH1 += 120f;
            this.tmpH2 += 120f;
          }
          for (int index = 0; index < 10; ++index)
            ((Component) this.btn_Failure_DeBuff[index]).gameObject.SetActive(false);
          for (int index = 0; index < this.mDeBf_A_L; ++index)
          {
            ((Component) this.btn_Failure_DeBuff[index]).gameObject.SetActive(true);
            this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_A_DeBf_Skill_ID[index]);
            SpriteName.ClearString();
            SpriteName.Append('s');
            SpriteName.IntToFormat((long) this.skill.Icon, 5);
            SpriteName.AppendFormat("{0}");
            this.Img_Failure_DeBuff[index].sprite = this.GUIM.LoadSkillSprite(SpriteName);
          }
        }
        else
        {
          for (int index = 0; index < this.mD_Skill_R; ++index)
          {
            ((Component) this.btn_Failure_Skill[index]).gameObject.SetActive(true);
            this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_D_Skill_ID[index]);
            SpriteName.ClearString();
            SpriteName.Append('s');
            SpriteName.IntToFormat((long) this.skill.Icon, 5);
            SpriteName.AppendFormat("{0}");
            this.Img_Failure_Skill[index].sprite = this.GUIM.LoadSkillSprite(SpriteName);
          }
          this.tmpH -= 49f;
          this.tmpH1 += 49f;
          this.tmpH2 += 49f;
          ((Component) this.Failure_Skill_RT[0]).gameObject.SetActive(false);
          ((Component) this.Failure_Skill_RT[1]).gameObject.SetActive(false);
          if (this.mD_Skill_R > 5)
          {
            this.tmpH -= 192f;
            this.tmpH1 += 192f;
            this.tmpH2 += 192f;
            ((Component) this.Failure_Skill_RT[0]).gameObject.SetActive(true);
            ((Component) this.Failure_Skill_RT[1]).gameObject.SetActive(true);
            this.Failure_Buff_RT[1].anchoredPosition = new Vector2(this.Failure_Buff_RT[1].anchoredPosition.x, -523f - num);
          }
          else if (this.mD_Skill_R > 0)
          {
            this.tmpH -= 120f;
            this.tmpH1 += 120f;
            this.tmpH2 += 120f;
            ((Component) this.Failure_Skill_RT[0]).gameObject.SetActive(true);
            this.Failure_Buff_RT[1].anchoredPosition = new Vector2(this.Failure_Buff_RT[1].anchoredPosition.x, -451f - num);
          }
          else
          {
            this.tmpH -= 69f;
            this.tmpH1 += 69f;
            this.tmpH2 += 69f;
            ((Component) this.text_FailureBuff[0]).gameObject.SetActive(true);
            this.text_FailureBuff[0].text = this.DM.mStringTable.GetStringByID(5334U);
            this.text_FailureBuff[0].SetAllDirty();
            this.text_FailureBuff[0].cachedTextGenerator.Invalidate();
            this.Failure_Buff_RT[1].anchoredPosition = new Vector2(this.Failure_Buff_RT[1].anchoredPosition.x, -400f - num);
          }
          ((Component) this.Failure_DeBuff_RT[0]).gameObject.SetActive(true);
          ((Component) this.Failure_DeBuff_RT[1]).gameObject.SetActive(false);
          this.tmpH -= 42f;
          this.tmpH1 += 42f;
          this.tmpH2 += 42f;
          if (this.mDeBf_D_R > 5)
          {
            this.tmpH -= 192f;
            this.tmpH1 += 192f;
            this.tmpH2 += 192f;
            ((Component) this.Failure_DeBuff_RT[1]).gameObject.SetActive(true);
          }
          else
          {
            this.tmpH -= 120f;
            this.tmpH1 += 120f;
            this.tmpH2 += 120f;
          }
          for (int index = 0; index < 10; ++index)
            ((Component) this.btn_Failure_DeBuff[index]).gameObject.SetActive(false);
          for (int index = 0; index < this.mDeBf_A_L; ++index)
          {
            ((Component) this.btn_Failure_DeBuff[index]).gameObject.SetActive(true);
            this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_D_DeBf_Skill_ID[index]);
            SpriteName.ClearString();
            SpriteName.Append('s');
            SpriteName.IntToFormat((long) this.skill.Icon, 5);
            SpriteName.AppendFormat("{0}");
            this.Img_Failure_DeBuff[index].sprite = this.GUIM.LoadSkillSprite(SpriteName);
          }
        }
      }
      else
      {
        if ((!this.IsAttack || this.mA_Skill_L <= 0) && (this.IsAttack || this.mD_Skill_R <= 0))
          return;
        this.tmpH1 -= 23f;
        this.tmpH2 = -23f;
        ((Component) this.Failure_Buff_RT[0]).gameObject.SetActive(true);
        if (this.IsAttack)
        {
          for (int index = 0; index < this.mA_Skill_L; ++index)
          {
            ((Component) this.btn_Failure_Skill[index]).gameObject.SetActive(true);
            this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_A_Skill_ID[index]);
            SpriteName.ClearString();
            SpriteName.Append('s');
            SpriteName.IntToFormat((long) this.skill.Icon, 5);
            SpriteName.AppendFormat("{0}");
            this.Img_Failure_Skill[index].sprite = this.GUIM.LoadSkillSprite(SpriteName);
          }
          this.tmpH -= 49f;
          this.tmpH1 += 49f;
          this.tmpH2 += 49f;
          ((Component) this.Failure_Skill_RT[0]).gameObject.SetActive(false);
          ((Component) this.Failure_Skill_RT[1]).gameObject.SetActive(false);
          if (this.mA_Skill_L > 5)
          {
            this.tmpH -= 192f;
            this.tmpH1 += 192f;
            this.tmpH2 += 192f;
            ((Component) this.Failure_Skill_RT[0]).gameObject.SetActive(true);
            ((Component) this.Failure_Skill_RT[1]).gameObject.SetActive(true);
          }
          else if (this.mA_Skill_L > 0)
          {
            this.tmpH -= 120f;
            this.tmpH1 += 120f;
            this.tmpH2 += 120f;
            ((Component) this.Failure_Skill_RT[0]).gameObject.SetActive(true);
          }
          else
          {
            this.tmpH -= 50f;
            this.tmpH1 += 50f;
            this.tmpH2 += 50f;
            ((Component) this.text_FailureBuff[0]).gameObject.SetActive(true);
            this.text_FailureBuff[0].text = this.DM.mStringTable.GetStringByID(5334U);
            this.text_FailureBuff[0].SetAllDirty();
            this.text_FailureBuff[0].cachedTextGenerator.Invalidate();
          }
        }
        else
        {
          for (int index = 0; index < this.mD_Skill_R; ++index)
          {
            ((Component) this.btn_Failure_Skill[index]).gameObject.SetActive(true);
            this.skill = this.PM.PetSkillTable.GetRecordByKey(this.m_D_Skill_ID[index]);
            SpriteName.ClearString();
            SpriteName.Append('s');
            SpriteName.IntToFormat((long) this.skill.Icon, 5);
            SpriteName.AppendFormat("{0}");
            this.Img_Failure_Skill[index].sprite = this.GUIM.LoadSkillSprite(SpriteName);
          }
          this.tmpH -= 49f;
          this.tmpH1 += 49f;
          this.tmpH2 += 49f;
          ((Component) this.Failure_Skill_RT[0]).gameObject.SetActive(false);
          ((Component) this.Failure_Skill_RT[1]).gameObject.SetActive(false);
          if (this.mD_Skill_R > 5)
          {
            this.tmpH -= 192f;
            this.tmpH1 += 192f;
            this.tmpH2 += 192f;
            ((Component) this.Failure_Skill_RT[0]).gameObject.SetActive(true);
            ((Component) this.Failure_Skill_RT[1]).gameObject.SetActive(true);
          }
          else if (this.mD_Skill_R > 0)
          {
            this.tmpH -= 120f;
            this.tmpH1 += 120f;
            this.tmpH2 += 120f;
            ((Component) this.Failure_Skill_RT[0]).gameObject.SetActive(true);
          }
          else
          {
            this.tmpH -= 50f;
            this.tmpH1 += 50f;
            this.tmpH2 += 50f;
            ((Component) this.text_FailureBuff[0]).gameObject.SetActive(true);
            this.text_FailureBuff[0].text = this.DM.mStringTable.GetStringByID(5334U);
            this.text_FailureBuff[0].SetAllDirty();
            this.text_FailureBuff[0].cachedTextGenerator.Invalidate();
          }
        }
      }
    }
  }

  public void SetBossData()
  {
    CString tmpS = StringManager.Instance.StaticString1024();
    tmpS.ClearString();
    this.Img_Titlebg.sprite = this.SArray.m_Sprites[13];
    if ((UnityEngine.Object) this.SummaryRT != (UnityEngine.Object) null)
    {
      ((Component) this.SummaryRT).gameObject.SetActive(false);
      this.bSetFSShow = true;
    }
    if ((UnityEngine.Object) this.QuanmieRT != (UnityEngine.Object) null)
      ((Component) this.QuanmieRT).gameObject.SetActive(false);
    if ((UnityEngine.Object) this.LightT1 != (UnityEngine.Object) null)
      this.LightT1.gameObject.SetActive(false);
    ((Component) this.BossRT).gameObject.SetActive(true);
    ((Component) this.btn_Replay).gameObject.SetActive(true);
    if (this.Report.Monster.Result == (byte) 1 || this.Report.Monster.Result == (byte) 5)
      ((Component) this.text_Summary).gameObject.SetActive(true);
    else
      ((Component) this.text_Summary).gameObject.SetActive(false);
    this.text_Summary.text = this.DM.mStringTable.GetStringByID(8224U);
    ((Graphic) this.text_Summary).color = new Color(1f, 0.9255f, 0.5294f);
    this.text_Summary.SetAllDirty();
    this.text_Summary.cachedTextGenerator.Invalidate();
    if (this.Report.Monster.Result == (byte) 4)
      this.text_AllianceBossStr.text = this.DM.mStringTable.GetStringByID(14517U);
    else if (this.Report.Monster.Result == (byte) 5)
      this.text_AllianceBossStr.text = this.DM.mStringTable.GetStringByID(14518U);
    this.text_AllianceBossStr.SetAllDirty();
    this.text_AllianceBossStr.cachedTextGenerator.Invalidate();
    this.BossRT.anchoredPosition = new Vector2(this.BossRT.anchoredPosition.x, this.SummaryRT.anchoredPosition.y);
    MapMonster recordByKey1 = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.Report.Monster.MonsterID);
    this.text_BossTitle[1].text = this.DM.mStringTable.GetStringByID((uint) recordByKey1.NameID);
    Hero recordByKey2 = this.DM.HeroTable.GetRecordByKey(recordByKey1.ModelID);
    this.mBossHead = recordByKey2.Graph;
    this.Cstr_BoosHead.ClearString();
    this.Cstr_BoosHead.IntToFormat((long) this.mBossHead);
    this.Cstr_BoosHead.AppendFormat("UI/MapNPCHead_{0}");
    if (AssetManager.GetAssetBundleDownload(this.Cstr_BoosHead, AssetPath.UI, AssetType.NPCHead, recordByKey2.Graph))
    {
      AssetBundle assetBundle = AssetManager.GetAssetBundle(this.Cstr_BoosHead, out this.AssetKey);
      if ((UnityEngine.Object) assetBundle != (UnityEngine.Object) null)
        this.mHead = UnityEngine.Object.Instantiate(assetBundle.mainAsset) as GameObject;
      if ((UnityEngine.Object) this.mHead != (UnityEngine.Object) null)
      {
        this.mHead.transform.SetParent(((Component) this.Img_BossIcon[0]).transform);
        this.mHead.gameObject.SetActive(true);
        this.mHead.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.mHead.transform.localScale = new Vector3(1f, 1f, 1f);
      }
    }
    this.Img_BossIcon[1].sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Hero, this.Report.Monster.MonsterLv);
    if (this.Report.Monster.SequentialDamageTimes > (byte) 0)
    {
      ((Component) this.text_BossFight[0]).gameObject.SetActive(false);
      ((Component) this.text_BossFight[1]).gameObject.SetActive(true);
      ((Component) this.text_BossFight[2]).gameObject.SetActive(true);
      this.Cstr_BossFight[0].ClearString();
      this.Cstr_BossFight[0].IntToFormat((long) this.Report.Monster.SequentialDamageTimes);
      this.Cstr_BossFight[0].AppendFormat(this.DM.mStringTable.GetStringByID(8225U));
      this.text_BossFight[1].text = this.Cstr_BossFight[0].ToString();
      this.text_BossFight[1].SetAllDirty();
      this.text_BossFight[1].cachedTextGenerator.Invalidate();
      tmpS.ClearString();
      tmpS.FloatToFormat((float) this.Report.Monster.AttrScale.SequentialDamageScale / 100f, 2, false);
      tmpS.AppendFormat("+{0}%");
      this.Cstr_BossFight[1].ClearString();
      this.Cstr_BossFight[1].StringToFormat(tmpS);
      this.Cstr_BossFight[1].AppendFormat(this.DM.mStringTable.GetStringByID(8226U));
      this.text_BossFight[2].text = this.Cstr_BossFight[1].ToString();
      this.text_BossFight[2].SetAllDirty();
      this.text_BossFight[2].cachedTextGenerator.Invalidate();
    }
    else
    {
      ((Component) this.text_BossFight[0]).gameObject.SetActive(true);
      ((Component) this.text_BossFight[1]).gameObject.SetActive(false);
      ((Component) this.text_BossFight[2]).gameObject.SetActive(false);
    }
    if (this.Report.Monster.AttrScale.ActionTimes > (byte) 1)
    {
      this.Cstr_BossL[0].ClearString();
      this.Cstr_BossL[0].IntToFormat((long) this.Report.Monster.AttrScale.ActionTimes);
      this.Cstr_BossL[0].AppendFormat(this.DM.mStringTable.GetStringByID(8231U));
      this.text_BossL[0].text = this.Cstr_BossL[0].ToString();
      this.text_BossL[0].SetAllDirty();
      this.text_BossL[0].cachedTextGenerator.Invalidate();
      ((Component) this.text_BossL[0]).gameObject.SetActive(true);
      this.Cstr_BossL[1].ClearString();
      this.Cstr_BossL[1].IntToFormat((long) this.Report.Monster.EffectiveDamageTimes);
      this.Cstr_BossL[1].AppendFormat(this.DM.mStringTable.GetStringByID(8349U));
      this.text_BossL[1].text = this.Cstr_BossL[1].ToString();
      this.text_BossL[1].SetAllDirty();
      this.text_BossL[1].cachedTextGenerator.Invalidate();
      ((Component) this.text_BossL[1]).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.text_BossL[0]).gameObject.SetActive(false);
      ((Component) this.text_BossL[1]).gameObject.SetActive(false);
    }
    if (this.tmpHeroID[0] != (ushort) 0)
      this.GUIM.ChangeHeroItemImg(((Component) this.btn_Boss_Hero).transform, eHeroOrItem.Hero, this.tmpHeroID[0], this.tmpHeroStar[0], (byte) 0);
    if (false)
      ((Component) this.Img_BossHeroCrown[0]).gameObject.SetActive(true);
    else
      ((Component) this.Img_BossHeroCrown[0]).gameObject.SetActive(false);
    float num = (float) this.Report.Monster.EndHPPercent / (float) this.Report.Monster.MonsterMaxHP;
    this.BossBloodRT.sizeDelta = new Vector2(274f * num, this.BossBloodRT.sizeDelta.y);
    this.text_BossR[0].text = this.Report.Monster.MonsterLv.ToString();
    this.Cstr_BossR[0].ClearString();
    if ((double) num > 0.0)
    {
      if ((double) num * 100.0 >= 0.0099999997764825821)
        this.Cstr_BossR[0].FloatToFormat(num * 100f, 2, false);
      else
        this.Cstr_BossR[0].FloatToFormat(0.01f);
    }
    else
      this.Cstr_BossR[0].FloatToFormat(0.0f);
    if (this.GUIM.IsArabic)
      this.Cstr_BossR[0].AppendFormat("%{0}");
    else
      this.Cstr_BossR[0].AppendFormat("{0}%");
    this.text_BossR[1].text = this.Cstr_BossR[0].ToString();
    this.text_BossR[1].SetAllDirty();
    this.text_BossR[1].cachedTextGenerator.Invalidate();
    this.Cstr_BossR[1].ClearString();
    this.Cstr_BossR[1].FloatToFormat((float) (this.Report.Monster.BeginHPPercent - this.Report.Monster.EndHPPercent) * 100f / (float) this.Report.Monster.MonsterMaxHP, 2, false);
    if (this.GUIM.IsArabic)
      this.Cstr_BossR[1].AppendFormat("%{0}-");
    else
      this.Cstr_BossR[1].AppendFormat("-{0}%");
    this.text_BossR[2].text = this.Cstr_BossR[1].ToString();
    this.text_BossR[2].SetAllDirty();
    this.text_BossR[2].cachedTextGenerator.Invalidate();
    this.tmpH -= 41f;
    this.tmpH -= 132f;
    this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, -this.tmpH);
  }

  public void SetItemData()
  {
    if (!this.bAllianceBossMode)
    {
      for (int index1 = 0; index1 < 5; ++index1)
      {
        if (this.tmpNum > index1)
          this.ItemT[index1].gameObject.SetActive(true);
        else
          this.ItemT[index1].gameObject.SetActive(false);
        for (int index2 = 0; index2 < 6; ++index2)
        {
          if (this.mItemCount > index1 * 6 + index2)
          {
            ((Component) this.text_ItemQty[index1 * 6 + index2]).gameObject.SetActive(true);
            this.Cstr_ItemQty[index1 * 6 + index2].ClearString();
            this.Cstr_ItemQty[index1 * 6 + index2].IntToFormat((long) this.ItemNum[index1 * 6 + index2], bNumber: true);
            if (this.GUIM.IsArabic)
              this.Cstr_ItemQty[index1 * 6 + index2].AppendFormat("{0}x");
            else
              this.Cstr_ItemQty[index1 * 6 + index2].AppendFormat("x{0}");
            this.text_ItemQty[index1 * 6 + index2].text = this.Cstr_ItemQty[index1 * 6 + index2].ToString();
            this.text_ItemQty[index1 * 6 + index2].SetAllDirty();
            this.text_ItemQty[index1 * 6 + index2].cachedTextGenerator.Invalidate();
            if (this.GUIM.IsLeadItem(this.DM.EquipTable.GetRecordByKey(this.ItemID[index1 * 6 + index2]).EquipKind))
            {
              this.GUIM.ChangeLordEquipImg(((Component) this.btn_Item_L[index1 * 6 + index2]).transform, this.ItemID[index1 * 6 + index2], this.ItemRank[index1 * 6 + index2], gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
              ((Component) this.btn_Item_L[index1 * 6 + index2]).gameObject.SetActive(true);
              ((Component) this.btn_Itme[index1 * 6 + index2]).gameObject.SetActive(false);
            }
            else
            {
              this.GUIM.ChangeHeroItemImg(((Component) this.btn_Itme[index1 * 6 + index2]).transform, eHeroOrItem.Item, this.ItemID[index1 * 6 + index2], (byte) 0, this.ItemRank[index1 * 6 + index2]);
              ((Component) this.btn_Item_L[index1 * 6 + index2]).gameObject.SetActive(false);
              ((Component) this.btn_Itme[index1 * 6 + index2]).gameObject.SetActive(true);
              this.btn_Itme[index1 * 6 + index2].m_BtnID2 = (int) this.ItemID[index1 * 6 + index2];
              bool flag = false;
              Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.ItemID[index1 * 6 + index2]);
              if (recordByKey.EquipKind == (byte) 19)
                flag = true;
              else if (recordByKey.EquipKind == (byte) 18 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 4)
                flag = true;
              else if (recordByKey.EquipKind == (byte) 18 && (recordByKey.PropertiesInfo[2].Propertieskey < (ushort) 1 || recordByKey.PropertiesInfo[2].Propertieskey > (ushort) 3))
                flag = true;
              if (flag)
              {
                ((Component) this.btn_Itme[index1 * 6 + index2]).transform.GetComponent<UIButtonHint>().enabled = false;
                if ((UnityEngine.Object) ((Component) this.btn_Itme[index1 * 6 + index2]).transform.GetComponent<EventPatchery>() == (UnityEngine.Object) null)
                  ((Component) this.btn_Itme[index1 * 6 + index2]).gameObject.AddComponent<EventPatchery>().SetEvnetObj(this.m_Mask);
              }
              else
                ((Component) this.btn_Itme[index1 * 6 + index2]).transform.GetComponent<UIButtonHint>().enabled = true;
            }
          }
          else
          {
            ((Component) this.btn_Item_L[index1 * 6 + index2]).gameObject.SetActive(false);
            ((Component) this.btn_Itme[index1 * 6 + index2]).gameObject.SetActive(false);
            ((Component) this.text_ItemQty[index1 * 6 + index2]).gameObject.SetActive(false);
          }
        }
      }
    }
    else
    {
      for (int index = 0; index < 5; ++index)
        this.ItemT[index].gameObject.SetActive(false);
    }
  }

  private void Update()
  {
    this.TmpTime += Time.smoothDeltaTime * 40f;
    if ((double) this.TmpTime >= 40.0)
      this.TmpTime = 0.0f;
    float num1 = (double) this.TmpTime <= 20.0 ? this.TmpTime : 40f - this.TmpTime;
    if ((double) num1 < 0.0)
      num1 = 0.0f;
    if ((UnityEngine.Object) this.NextT != (UnityEngine.Object) null)
    {
      this.Vec3Instance.Set(this.MoveTime1 - num1, this.NextT.localPosition.y, this.NextT.localPosition.z);
      this.NextT.localPosition = this.Vec3Instance;
    }
    if ((UnityEngine.Object) this.PreviousT != (UnityEngine.Object) null)
    {
      this.Vec3Instance.Set(this.MoveTime2 + num1, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
      this.PreviousT.localPosition = this.Vec3Instance;
    }
    if (!this.bSetFSShow && this.bInitFS && !this.bQuanmier && (UnityEngine.Object) this.SummaryRT != (UnityEngine.Object) null && !((Component) this.SummaryRT).gameObject.activeSelf)
    {
      ((Component) this.SummaryRT).gameObject.SetActive(true);
      this.bSetFSShow = true;
    }
    if (!this.bCreateItem && this.bInitItemBase && (UnityEngine.Object) this.ItemBase != (UnityEngine.Object) null && (UnityEngine.Object) this.ItemRT2 != (UnityEngine.Object) null && !this.bNpcMode)
    {
      this.bCreateItem = true;
      float num2 = 89f;
      for (int index1 = 1; index1 < 5; ++index1)
      {
        GameObject gameObject = (GameObject) UnityEngine.Object.Instantiate((UnityEngine.Object) this.ItemBase.gameObject);
        gameObject.transform.SetParent(((Component) this.ItemRT2).transform, false);
        gameObject.transform.SetSiblingIndex(index1);
        this.tmpRC = gameObject.GetComponent<RectTransform>();
        this.tmpRC.anchoredPosition = new Vector2(this.tmpRC.anchoredPosition.x, -num2);
        num2 += 89f;
        gameObject.SetActive(true);
        this.ItemT[index1] = gameObject.transform;
        for (int index2 = 0; index2 < 6; ++index2)
        {
          this.btn_Itme[index1 * 6 + index2] = this.ItemT[index1].GetChild(index2).GetComponent<UIHIBtn>();
          this.btn_Itme[index1 * 6 + index2].m_Handler = (IUIHIBtnClickHandler) this;
          this.btn_Item_L[index1 * 6 + index2] = this.ItemT[index1].GetChild(6 + index2).GetComponent<UILEBtn>();
          this.text_ItemQty[index1 * 6 + index2] = this.ItemT[index1].GetChild(12 + index2).GetComponent<UIText>();
          this.text_ItemQty[index1 * 6 + index2].font = this.TTFont;
        }
      }
    }
    if (!this.bNpcMode && this.bSetItemData < (byte) 2 && this.bCreateItem)
    {
      if (this.bSetItemData == (byte) 0)
      {
        this.bSetItemData = (byte) 1;
      }
      else
      {
        this.SetItemData();
        this.bSetItemData = (byte) 2;
      }
    }
    if ((UnityEngine.Object) this.btn_Replay != (UnityEngine.Object) null && ((UIBehaviour) this.btn_Replay).IsActive())
    {
      this.ShowReplay += Time.smoothDeltaTime;
      if ((double) this.ShowReplay >= 2.0)
        this.ShowReplay = 0.0f;
      ((Graphic) this.Img_RePlay).color = new Color(1f, 1f, 1f, (double) this.ShowReplay <= 1.0 ? this.ShowReplay : 2f - this.ShowReplay);
    }
    this.ShowMainHeroTime1 += Time.smoothDeltaTime;
    if ((double) this.ShowMainHeroTime1 >= 0.0)
    {
      if ((double) this.ShowMainHeroTime1 >= 2.0)
        this.ShowMainHeroTime1 = 0.0f;
      float a = (double) this.ShowMainHeroTime1 <= 1.0 ? this.ShowMainHeroTime1 : 2f - this.ShowMainHeroTime1;
      if ((UnityEngine.Object) this.Img_Crown[1] != (UnityEngine.Object) null)
        ((Graphic) this.Img_Crown[1]).color = new Color(1f, 1f, 1f, a);
      if ((UnityEngine.Object) this.Img_BossHeroCrown[0] != (UnityEngine.Object) null && ((UIBehaviour) this.Img_BossHeroCrown[0]).IsActive())
        ((Graphic) this.Img_BossHeroCrown[1]).color = new Color(1f, 1f, 1f, a);
    }
    this.ShowMainHeroTime2 += Time.smoothDeltaTime;
    if ((double) this.ShowMainHeroTime2 >= 0.0)
    {
      if ((double) this.ShowMainHeroTime2 >= 2.0)
        this.ShowMainHeroTime2 = 0.0f;
      float a = (double) this.ShowMainHeroTime2 <= 1.0 ? this.ShowMainHeroTime2 : 2f - this.ShowMainHeroTime2;
      if ((UnityEngine.Object) this.Img_Crown[3] != (UnityEngine.Object) null)
        ((Graphic) this.Img_Crown[3]).color = new Color(1f, 1f, 1f, a);
    }
    if ((UnityEngine.Object) this.LightT1 != (UnityEngine.Object) null)
      this.LightT1.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    if ((UnityEngine.Object) this.LightBossT != (UnityEngine.Object) null)
      this.LightBossT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    this.ShowVsTime += Time.smoothDeltaTime;
    if ((double) this.ShowVsTime >= 0.0)
    {
      if ((double) this.ShowVsTime >= 2.0)
        this.ShowVsTime = 0.0f;
      float a = (double) this.ShowVsTime <= 1.0 ? this.ShowVsTime : 2f - this.ShowVsTime;
      if ((UnityEngine.Object) this.Img_Vs != (UnityEngine.Object) null)
        ((Graphic) this.Img_Vs).color = new Color(1f, 1f, 1f, a);
    }
    if (!((UnityEngine.Object) this.LightT2 != (UnityEngine.Object) null))
      return;
    this.LightT2.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
  }

  private void SetPorfileBtn()
  {
    int index1;
    int index2;
    if (this.IsAttack)
    {
      index1 = 0;
      index2 = 3;
    }
    else
    {
      index1 = 3;
      index2 = 0;
    }
    if (this.Img_MainHero != null && (UnityEngine.Object) this.Img_MainHero[index1] != (UnityEngine.Object) null && (UnityEngine.Object) ((Component) this.Img_MainHero[index1]).transform.GetChild(0) != (UnityEngine.Object) null)
    {
      UIButton component = ((Component) this.Img_MainHero[index1]).transform.GetChild(0).gameObject.GetComponent<UIButton>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      {
        component.m_Handler = (IUIButtonClickHandler) this;
        component.m_BtnID1 = index1 != 0 ? 11 : 10;
        component.m_EffectType = e_EffectType.e_Scale;
        component.transition = (Selectable.Transition) 0;
      }
    }
    if (this.Img_MainHero == null || !((UnityEngine.Object) this.Img_MainHero[index2] != (UnityEngine.Object) null) || !((UnityEngine.Object) ((Component) this.Img_MainHero[index2]).transform.GetChild(0) != (UnityEngine.Object) null))
      return;
    UIButton component1 = ((Component) this.Img_MainHero[index2]).transform.GetChild(0).gameObject.GetComponent<UIButton>();
    if (!((UnityEngine.Object) component1 != (UnityEngine.Object) null))
      return;
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = index2 != 0 ? 11 : 10;
    component1.m_EffectType = e_EffectType.e_Scale;
    component1.transition = (Selectable.Transition) 0;
  }

  private void ShowLordProfile(FightingSummary_btn type)
  {
    if (!this.bNpcMode)
    {
      this.DM.PlayerName_War[0].Append(this.Report.Combat.AssaultName);
      this.DM.PlayerName_War[1].Append(this.Report.Combat.DefenceName);
      switch (type)
      {
        case FightingSummary_btn.btn_Porfile_Atk:
          if (this.Report == null || this.Report.Combat == null || this.Report.Combat.AssaultName == null || !(this.Report.Combat.AssaultName != string.Empty))
            break;
          this.bSaveY = true;
          DataManager.Instance.ShowLordProfile(this.Report.Combat.AssaultName);
          break;
        case FightingSummary_btn.btn_Porfile_Def:
          if (this.Report == null || this.Report.Combat == null || this.Report.Combat.DefenceName == null || !(this.Report.Combat.DefenceName != string.Empty))
            break;
          this.bSaveY = true;
          DataManager.Instance.ShowLordProfile(this.Report.Combat.DefenceName);
          break;
      }
    }
    else
    {
      this.DM.PlayerName_War[0].Append(this.Report.NPCCombat.AssaultName);
      if (type == FightingSummary_btn.btn_Porfile_Def || type != FightingSummary_btn.btn_Porfile_Atk || this.Report == null || this.Report.NPCCombat == null || this.Report.NPCCombat.AssaultName == null || !(this.Report.NPCCombat.AssaultName != string.Empty))
        return;
      this.bSaveY = true;
      DataManager.Instance.ShowLordProfile(this.Report.NPCCombat.AssaultName);
    }
  }
}
