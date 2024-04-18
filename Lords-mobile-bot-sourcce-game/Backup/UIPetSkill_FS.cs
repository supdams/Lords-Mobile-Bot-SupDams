// Decompiled with JetBrains decompiler
// Type: UIPetSkill_FS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIPetSkill_FS : 
  GUIWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Tmp2;
  private Transform LightT1;
  private Transform LightT2;
  private Transform PreviousT;
  private Transform NextT;
  private Transform Mask_T;
  private Transform[] Soldier_T = new Transform[16];
  private RectTransform tmpRC;
  private RectTransform ContentRT;
  private RectTransform SummaryRT;
  private RectTransform FailureRT;
  private RectTransform Pet_BGRT;
  private RectTransform Pet_InfoRT;
  private RectTransform Pet_WallRT;
  private RectTransform Pet_AttackRT;
  private RectTransform Pet_BeAttackedRT;
  private RectTransform Pet_ResourcesRT;
  private RectTransform[] Pet_btnSoldierRT = new RectTransform[16];
  private UIButton btn_EXIT;
  private UIButton btn_Previous;
  private UIButton btn_Next;
  private UIButton btn_Title;
  private UIButton btn_Delete;
  private UIButton btn_Collect;
  private UIButton[] btn_Coordinate = new UIButton[2];
  private UIButtonHint[] Hbtn_Hint = new UIButtonHint[16];
  private UIHIBtn btn_Pet;
  private UIHIBtn btn_Pet_Failure;
  private Image Img_Quanmie;
  private Image Img_Vs;
  private Image[] Img_MainHero = new Image[6];
  private Image[] Img_Summarybg = new Image[2];
  private Image[] Img_MainTitle = new Image[2];
  private Image[] Img_Country = new Image[2];
  private Image[] Img_Rank = new Image[2];
  private Image[] Img_Vip = new Image[2];
  private Image[] Img_Soldier = new Image[16];
  private UIText text_Coordinate;
  private UIText text_TitleName;
  private UIText text_Page;
  private UIText text_Summary;
  private UIText text_PetSkillTitle;
  private UIText text_PetName;
  private UIText text_PetSkillLv;
  private UIText text_PetSkillInfo;
  private UIText text_PetLoss;
  private UIText text_FailurePetName;
  private UIText text_FailurePetSkillLv;
  private UIText text_FailurePetSkillInfo;
  private UIText[] text_Time = new UIText[2];
  private UIText[] text_Offensive = new UIText[2];
  private UIText[] text_MainHero_F = new UIText[2];
  private UIText[] text_Dominance = new UIText[2];
  private UIText[] text_Country = new UIText[2];
  private UIText[] text_Vip = new UIText[2];
  private UIText[] text_CoordinateMainHero = new UIText[2];
  private UIText[] text_Name = new UIText[2];
  private UIText[] text_PetWall = new UIText[2];
  private UIText[] text_PetAttack = new UIText[5];
  private UIText[] text_PetBeAttacked = new UIText[4];
  private UIText[] text_PetResources = new UIText[5];
  private UIText[] text_Soldier_Rank = new UIText[16];
  private UIText[] text_Soldier_Name = new UIText[16];
  private UIText[] text_Soldier_Hurt = new UIText[16];
  private UIText[] text_Soldier_Death = new UIText[16];
  private UIText text_tmpStr;
  private CScrollRect m_Mask;
  private CString[] Cstr_Coordinate = new CString[2];
  private CString Cstr_TitleName;
  private CString Cstr_Page;
  private CString Cstr_Text;
  private CString[] Cstr_Offensive = new CString[2];
  private CString[] Cstr_Dominance = new CString[2];
  private CString[] Cstr_Country = new CString[2];
  private CString[] Cstr_CoordinateMainHero = new CString[2];
  private CString[] Cstr_Name = new CString[2];
  private CString Cstr_PetSkillLv;
  private CString Cstr_PetSkillInfo;
  private CString Cstr_PetWall;
  private CString[] Cstr_PetAttack = new CString[3];
  private CString[] Cstr_PetBeAttacked = new CString[17];
  private CString[] Cstr_PetResources = new CString[5];
  private CString[] Cstr_Soldier_Hurt = new CString[16];
  private CString[] Cstr_Soldier_Death = new CString[16];
  private DataManager DM;
  private GUIManager GUIM;
  private PetManager PM;
  private Font TTFont;
  private Door door;
  private UISpritesArray SArray;
  private Material mMaT;
  private Material IconMaterial;
  private Material FrameMaterial;
  private CombatReport Report;
  private MyFavorite Favor = new MyFavorite(Id: 0U);
  private bool bWin = true;
  private bool IsAttack = true;
  private int MaxLetterNum;
  private float tempL;
  private float MoveTime1;
  private float MoveTime2;
  private float TmpTime;
  private float ShowVsTime;
  private Vector3 Vec3Instance = Vector3.zero;
  private bool bSaveY;
  private float tmpH;
  private Hero tmpHero;
  private Vector2 tmpV;
  private PetTbl tmpPT;
  private PetSkillTbl skill;

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
        this.IsAttack = this.Report.Pet.Side == (byte) 0;
        this.MaxLetterNum = (int) this.DM.GetMailboxSize();
        CString SpriteName = StringManager.Instance.StaticString1024();
        this.Cstr_TitleName = StringManager.Instance.SpawnString();
        this.Cstr_Page = StringManager.Instance.SpawnString();
        this.Cstr_Text = StringManager.Instance.SpawnString();
        for (int index = 0; index < 2; ++index)
        {
          this.Cstr_Coordinate[index] = StringManager.Instance.SpawnString(100);
          this.Cstr_Offensive[index] = StringManager.Instance.SpawnString();
          this.Cstr_Dominance[index] = StringManager.Instance.SpawnString();
          this.Cstr_Country[index] = StringManager.Instance.SpawnString();
          this.Cstr_CoordinateMainHero[index] = StringManager.Instance.SpawnString();
          this.Cstr_Name[index] = StringManager.Instance.SpawnString();
        }
        this.Cstr_PetSkillLv = StringManager.Instance.SpawnString();
        this.Cstr_PetSkillInfo = StringManager.Instance.SpawnString(1024);
        this.Cstr_PetWall = StringManager.Instance.SpawnString();
        for (int index = 0; index < 3; ++index)
          this.Cstr_PetAttack[index] = index != 0 ? StringManager.Instance.SpawnString() : StringManager.Instance.SpawnString(100);
        for (int index = 0; index < 17; ++index)
          this.Cstr_PetBeAttacked[index] = index != 0 ? StringManager.Instance.SpawnString() : StringManager.Instance.SpawnString(100);
        for (int index = 0; index < 5; ++index)
          this.Cstr_PetResources[index] = StringManager.Instance.SpawnString();
        for (int index = 0; index < 16; ++index)
        {
          this.Cstr_Soldier_Hurt[index] = StringManager.Instance.SpawnString();
          this.Cstr_Soldier_Death[index] = StringManager.Instance.SpawnString();
        }
        this.Tmp = this.GameT.GetChild(0);
        this.Tmp1 = this.Tmp.GetChild(1);
        this.text_TitleName = this.Tmp1.GetChild(0).GetComponent<UIText>();
        this.text_TitleName.font = this.TTFont;
        this.text_Page = this.Tmp1.GetChild(1).GetComponent<UIText>();
        this.text_Page.font = this.TTFont;
        this.Mask_T = this.GameT.GetChild(1);
        this.m_Mask = this.Mask_T.GetComponent<CScrollRect>();
        this.ContentRT = this.Mask_T.GetChild(0).GetComponent<RectTransform>();
        this.Tmp1 = this.Mask_T.GetChild(0).GetChild(0);
        this.text_tmpStr = this.Tmp1.GetChild(1).GetComponent<UIText>();
        this.text_tmpStr.font = this.TTFont;
        this.LightT1 = this.Tmp1.GetChild(0);
        this.text_Summary = this.Tmp1.GetChild(1).GetComponent<UIText>();
        this.text_Summary.font = this.TTFont;
        this.tmpH -= 136f;
        this.Tmp1 = this.Mask_T.GetChild(0).GetChild(1);
        this.SummaryRT = this.Tmp1.GetComponent<RectTransform>();
        this.SummaryRT.anchoredPosition = new Vector2(this.SummaryRT.anchoredPosition.x, this.tmpH);
        this.Tmp2 = this.Tmp1.GetChild(2);
        this.Img_Summarybg[0] = this.Tmp2.GetComponent<Image>();
        this.Tmp2 = this.Tmp1.GetChild(3);
        this.Img_Summarybg[1] = this.Tmp2.GetComponent<Image>();
        this.Tmp2 = this.Tmp1.GetChild(0).GetChild(0);
        this.text_Offensive[0] = this.Tmp2.GetComponent<UIText>();
        this.text_Offensive[0].font = this.TTFont;
        this.Cstr_Offensive[0].ClearString();
        this.Tmp2 = this.Tmp1.GetChild(1).GetChild(0);
        this.text_Offensive[1] = this.Tmp2.GetComponent<UIText>();
        this.text_Offensive[1].font = this.TTFont;
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
        this.text_Dominance[0] = this.Tmp2.GetChild(2).GetChild(0).GetComponent<UIText>();
        this.text_Dominance[0].font = this.TTFont;
        this.Cstr_Dominance[0].ClearString();
        this.Img_Country[0] = this.Tmp2.GetChild(3).GetComponent<Image>();
        this.text_Country[0] = this.Tmp2.GetChild(3).GetChild(0).GetComponent<UIText>();
        this.text_Country[0].font = this.TTFont;
        this.Cstr_Country[0].ClearString();
        this.text_Country[0].text = this.Cstr_Country[0].ToString();
        this.Img_Rank[0] = this.Tmp2.GetChild(4).GetComponent<Image>();
        if (this.GUIM.IsArabic)
          ((Component) this.Img_Rank[0]).transform.localScale = new Vector3(-1f, ((Component) this.Img_Rank[0]).transform.localScale.y, ((Component) this.Img_Rank[0]).transform.localScale.z);
        int num1 = 0;
        this.Img_Vip[0] = this.Tmp2.GetChild(5).GetComponent<Image>();
        if (this.GUIM.IsArabic)
          ((Component) this.Img_Vip[0]).transform.localScale = new Vector3(-1f, ((Component) this.Img_Vip[0]).transform.localScale.y, ((Component) this.Img_Vip[0]).transform.localScale.z);
        this.btn_Coordinate[0] = this.Tmp2.GetChild(6).GetComponent<UIButton>();
        this.btn_Coordinate[0].m_Handler = (IUIButtonClickHandler) this;
        this.btn_Coordinate[0].m_BtnID1 = 6;
        this.text_CoordinateMainHero[0] = this.Tmp2.GetChild(6).GetChild(1).GetComponent<UIText>();
        this.text_CoordinateMainHero[0].font = this.TTFont;
        this.text_Vip[0] = this.Tmp2.GetChild(7).GetComponent<UIText>();
        this.text_Vip[0].font = this.TTFont;
        this.text_Vip[0].text = num1.ToString();
        this.text_Name[0] = this.Tmp2.GetChild(8).GetComponent<UIText>();
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
        this.text_Dominance[1] = this.Tmp2.GetChild(2).GetChild(0).GetComponent<UIText>();
        this.text_Dominance[1].font = this.TTFont;
        this.Cstr_Dominance[1].ClearString();
        this.text_Dominance[1].text = this.Cstr_Dominance[1].ToString();
        this.Img_Country[1] = this.Tmp2.GetChild(3).GetComponent<Image>();
        this.text_Country[1] = this.Tmp2.GetChild(3).GetChild(0).GetComponent<UIText>();
        this.text_Country[1].font = this.TTFont;
        this.Cstr_Country[1].ClearString();
        this.Cstr_Dominance[1].ClearString();
        this.Img_Rank[1] = this.Tmp2.GetChild(4).GetComponent<Image>();
        if (this.GUIM.IsArabic)
          ((Component) this.Img_Rank[1]).transform.localScale = new Vector3(-1f, ((Component) this.Img_Rank[1]).transform.localScale.y, ((Component) this.Img_Rank[1]).transform.localScale.z);
        int num2 = 0;
        this.Img_Vip[1] = this.Tmp2.GetChild(5).GetComponent<Image>();
        if (this.GUIM.IsArabic)
          ((Component) this.Img_Vip[1]).transform.localScale = new Vector3(-1f, ((Component) this.Img_Vip[1]).transform.localScale.y, ((Component) this.Img_Vip[1]).transform.localScale.z);
        this.btn_Coordinate[1] = this.Tmp2.GetChild(6).GetComponent<UIButton>();
        this.btn_Coordinate[1].m_Handler = (IUIButtonClickHandler) this;
        this.btn_Coordinate[1].m_BtnID1 = 7;
        this.text_CoordinateMainHero[1] = this.Tmp2.GetChild(6).GetChild(1).GetComponent<UIText>();
        this.text_CoordinateMainHero[1].font = this.TTFont;
        this.text_Vip[1] = this.Tmp2.GetChild(7).GetComponent<UIText>();
        this.text_Vip[1].font = this.TTFont;
        this.text_Vip[1].text = num2.ToString();
        this.text_Name[1] = this.Tmp2.GetChild(8).GetComponent<UIText>();
        this.text_Name[1].font = this.TTFont;
        this.LightT2 = this.Tmp1.GetChild(6);
        this.Img_Vs = this.Tmp1.GetChild(7).GetChild(0).GetComponent<Image>();
        Image component1 = this.Tmp1.GetChild(7).GetComponent<Image>();
        if (this.GUIM.IsArabic)
          ((Component) component1).transform.localScale = new Vector3(-1f, ((Component) component1).transform.localScale.y, ((Component) component1).transform.localScale.z);
        this.Tmp2 = this.Tmp1.GetChild(8);
        this.Pet_BGRT = this.Tmp2.GetChild(0).GetComponent<RectTransform>();
        this.btn_Pet = this.Tmp2.GetChild(2).GetComponent<UIHIBtn>();
        this.GUIM.InitianHeroItemImg(((Component) this.btn_Pet).transform, eHeroOrItem.Pet, (ushort) 1, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false, bClickSound: false);
        this.text_PetSkillTitle = this.Tmp2.GetChild(3).GetComponent<UIText>();
        this.text_PetSkillTitle.font = this.TTFont;
        this.text_PetSkillTitle.text = this.DM.mStringTable.GetStringByID(10113U);
        this.text_PetSkillInfo = this.Tmp2.GetChild(4).GetComponent<UIText>();
        this.text_PetSkillInfo.font = this.TTFont;
        ((Graphic) this.text_PetSkillInfo).color = Color.white;
        this.text_PetName = this.Tmp2.GetChild(5).GetComponent<UIText>();
        this.text_PetName.font = this.TTFont;
        this.text_PetSkillLv = this.Tmp2.GetChild(6).GetComponent<UIText>();
        this.text_PetSkillLv.font = this.TTFont;
        this.Tmp2 = this.Tmp1.GetChild(8).GetChild(7);
        this.Pet_InfoRT = this.Tmp2.GetComponent<RectTransform>();
        this.Pet_WallRT = this.Tmp2.GetChild(0).GetComponent<RectTransform>();
        this.text_PetWall[0] = this.Tmp2.GetChild(0).GetChild(0).GetComponent<UIText>();
        this.text_PetWall[0].font = this.TTFont;
        this.text_PetWall[1] = this.Tmp2.GetChild(0).GetChild(1).GetComponent<UIText>();
        this.text_PetWall[1].font = this.TTFont;
        this.Pet_AttackRT = this.Tmp2.GetChild(1).GetComponent<RectTransform>();
        for (int index = 0; index < 5; ++index)
        {
          this.text_PetAttack[index] = this.Tmp2.GetChild(1).GetChild(index).GetComponent<UIText>();
          this.text_PetAttack[index].font = this.TTFont;
        }
        this.text_PetAttack[1].text = this.DM.mStringTable.GetStringByID(5326U);
        this.text_PetAttack[3].text = this.DM.mStringTable.GetStringByID(5327U);
        this.Pet_BeAttackedRT = this.Tmp2.GetChild(2).GetComponent<RectTransform>();
        this.text_PetBeAttacked[0] = this.Tmp2.GetChild(2).GetChild(0).GetComponent<UIText>();
        this.text_PetBeAttacked[0].font = this.TTFont;
        this.text_PetBeAttacked[1] = this.Tmp2.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
        this.text_PetBeAttacked[1].font = this.TTFont;
        this.text_PetBeAttacked[1].text = this.DM.mStringTable.GetStringByID(5341U);
        this.text_PetBeAttacked[2] = this.Tmp2.GetChild(2).GetChild(1).GetChild(1).GetComponent<UIText>();
        this.text_PetBeAttacked[2].font = this.TTFont;
        this.text_PetBeAttacked[2].text = this.DM.mStringTable.GetStringByID(5343U);
        this.text_PetBeAttacked[3] = this.Tmp2.GetChild(2).GetChild(1).GetChild(2).GetComponent<UIText>();
        this.text_PetBeAttacked[3].font = this.TTFont;
        this.text_PetBeAttacked[3].text = this.DM.mStringTable.GetStringByID(5344U);
        for (int index = 0; index < 16; ++index)
        {
          this.Soldier_T[index] = this.Tmp2.GetChild(2).GetChild(2 + index);
          this.Pet_btnSoldierRT[index] = this.Soldier_T[index].GetChild(0).GetComponent<RectTransform>();
          this.Hbtn_Hint[index] = this.Soldier_T[index].GetChild(0).gameObject.AddComponent<UIButtonHint>();
          this.Hbtn_Hint[index].m_eHint = EUIButtonHint.CountDown;
          this.Hbtn_Hint[index].DelayTime = 0.2f;
          this.Hbtn_Hint[index].m_Handler = (MonoBehaviour) this;
          this.Hbtn_Hint[index].Parm1 = (ushort) 1;
          this.Img_Soldier[index] = this.Soldier_T[index].GetChild(0).GetChild(0).GetComponent<Image>();
          this.text_Soldier_Rank[index] = this.Soldier_T[index].GetChild(0).GetChild(1).GetComponent<UIText>();
          this.text_Soldier_Rank[index].font = this.TTFont;
          this.text_Soldier_Name[index] = this.Soldier_T[index].GetChild(0).GetChild(2).GetComponent<UIText>();
          this.text_Soldier_Name[index].font = this.TTFont;
          this.text_Soldier_Hurt[index] = this.Soldier_T[index].GetChild(1).GetComponent<UIText>();
          this.text_Soldier_Hurt[index].font = this.TTFont;
          this.text_Soldier_Death[index] = this.Soldier_T[index].GetChild(2).GetComponent<UIText>();
          this.text_Soldier_Death[index].font = this.TTFont;
        }
        UIButtonHint.scrollRect = this.m_Mask;
        this.Pet_ResourcesRT = this.Tmp2.GetChild(3).GetComponent<RectTransform>();
        for (int index = 0; index < 5; ++index)
        {
          this.text_PetResources[index] = this.Tmp2.GetChild(3).GetChild(index).GetChild(0).GetComponent<UIText>();
          this.text_PetResources[index].font = this.TTFont;
        }
        this.text_PetLoss = this.Tmp2.GetChild(4).GetComponent<UIText>();
        this.text_PetLoss.font = this.TTFont;
        this.text_PetLoss.text = this.DM.mStringTable.GetStringByID(5321U);
        this.Tmp1 = this.Mask_T.GetChild(0).GetChild(2);
        this.FailureRT = this.Tmp1.GetComponent<RectTransform>();
        this.FailureRT.anchoredPosition = new Vector2(this.SummaryRT.anchoredPosition.x, this.tmpH);
        this.btn_Pet_Failure = this.Tmp1.GetChild(1).GetComponent<UIHIBtn>();
        this.GUIM.InitianHeroItemImg(((Component) this.btn_Pet_Failure).transform, eHeroOrItem.Pet, (ushort) 1, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false, bClickSound: false);
        this.text_FailurePetSkillInfo = this.Tmp1.GetChild(2).GetComponent<UIText>();
        this.text_FailurePetSkillInfo.font = this.TTFont;
        this.text_FailurePetName = this.Tmp1.GetChild(3).GetComponent<UIText>();
        this.text_FailurePetName.font = this.TTFont;
        this.text_FailurePetSkillLv = this.Tmp1.GetChild(4).GetComponent<UIText>();
        this.text_FailurePetSkillLv.font = this.TTFont;
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
        this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Pet.Times).ToShortDateString();
        this.Tmp1 = this.Tmp.GetChild(2);
        this.text_Time[1] = this.Tmp1.GetComponent<UIText>();
        this.text_Time[1].font = this.TTFont;
        this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Pet.Times).ToString("HH:mm:ss");
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
        this.Tmp = this.GameT.GetChild(7);
        Image component2 = this.Tmp.GetComponent<Image>();
        SpriteName.ClearString();
        SpriteName.AppendFormat("UI_main_close_base");
        component2.sprite = this.door.LoadSprite(SpriteName);
        ((MaskableGraphic) component2).material = this.mMaT;
        if (this.GUIM.bOpenOnIPhoneX)
          ((Behaviour) component2).enabled = false;
        this.Tmp = this.GameT.GetChild(7).GetChild(0);
        this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
        SpriteName.ClearString();
        SpriteName.AppendFormat("UI_main_close");
        this.btn_EXIT.image.sprite = this.door.LoadSprite(SpriteName);
        ((MaskableGraphic) this.btn_EXIT.image).material = this.mMaT;
        this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
        this.btn_EXIT.m_BtnID1 = 0;
        this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
        this.btn_EXIT.transition = (Selectable.Transition) 0;
        this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, -this.tmpH);
        this.SetFSInfo();
        this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
        if ((int) this.DM.mFs_Serial == (int) this.Favor.Serial && (double) this.DM.LetterFs_Y > -1.0)
          this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, this.DM.LetterFs_Y);
        else
          this.DM.LetterFs_Y = -1f;
        this.SetPorfileBtn();
      }
      else
        this.door.CloseMenu();
    }
  }

  public void SetFSInfo()
  {
    this.tmpH = -136f;
    this.text_Time[0].text = GameConstants.GetDateTime(this.Report.Times).ToString("MM/dd/yy");
    this.text_Time[0].SetAllDirty();
    this.text_Time[0].cachedTextGenerator.Invalidate();
    this.text_Time[1].text = GameConstants.GetDateTime(this.Report.Times).ToString("HH:mm:ss");
    this.text_Time[1].SetAllDirty();
    this.text_Time[1].cachedTextGenerator.Invalidate();
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
        ((Component) this.btn_Next).gameObject.SetActive(false);
      else
        ((Component) this.btn_Next).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.btn_Previous).gameObject.SetActive(false);
      ((Component) this.btn_Next).gameObject.SetActive(false);
    }
    CString cstring = StringManager.Instance.StaticString1024();
    CString Name1 = StringManager.Instance.StaticString1024();
    CString Tag1 = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    Name1.ClearString();
    Tag1.ClearString();
    this.Cstr_TitleName.ClearString();
    if (this.Report.Pet.Side == (byte) 0)
    {
      Name1.Append(this.Report.Pet.DefenceName);
      if (this.Report.Pet.DefenceAllianceTag != string.Empty)
      {
        Tag1.Append(this.Report.Pet.DefenceAllianceTag);
        if ((int) this.Report.Pet.AssaultKingdomID != (int) this.Report.Pet.DefenceKingdomID)
          this.GUIM.FormatRoleNameForChat(cstring, Name1, Tag1, this.Report.Pet.DefenceKingdomID, this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring, Name1, Tag1, (ushort) 0, this.GUIM.IsArabic);
      }
      else if ((int) this.Report.Pet.AssaultKingdomID != (int) this.Report.Pet.DefenceKingdomID)
        this.GUIM.FormatRoleNameForChat(cstring, Name1, KingdomID: this.Report.Pet.DefenceKingdomID, ForceArabic: this.GUIM.IsArabic);
      else
        this.GUIM.FormatRoleNameForChat(cstring, Name1, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
      this.Cstr_TitleName.StringToFormat(cstring);
      this.Cstr_TitleName.StringToFormat(this.GUIM.GetPointName_Letter((POINT_KIND) this.Report.Pet.Kind));
      this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(10093U));
    }
    else
    {
      Name1.Append(this.Report.Pet.AssaultName);
      if (this.Report.Pet.AssaultAllianceTag != string.Empty)
      {
        Tag1.Append(this.Report.Pet.AssaultAllianceTag);
        if ((int) this.Report.Pet.AssaultKingdomID != (int) this.Report.Pet.DefenceKingdomID)
          this.GUIM.FormatRoleNameForChat(cstring, Name1, Tag1, this.Report.Pet.AssaultKingdomID, this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring, Name1, Tag1, (ushort) 0, this.GUIM.IsArabic);
      }
      else if ((int) this.Report.Pet.AssaultKingdomID != (int) this.Report.Pet.DefenceKingdomID)
        this.GUIM.FormatRoleNameForChat(cstring, Name1, KingdomID: this.Report.Pet.AssaultKingdomID, ForceArabic: this.GUIM.IsArabic);
      else
        this.GUIM.FormatRoleNameForChat(cstring, Name1, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
      this.Cstr_TitleName.StringToFormat(cstring);
      this.Cstr_TitleName.StringToFormat(this.GUIM.GetPointName_Letter((POINT_KIND) this.Report.Pet.Kind));
      this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(10094U));
    }
    this.text_TitleName.text = this.Cstr_TitleName.ToString();
    this.text_TitleName.SetAllDirty();
    this.text_TitleName.cachedTextGenerator.Invalidate();
    this.Cstr_Coordinate[0].ClearString();
    this.Cstr_Coordinate[1].ClearString();
    this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Pet.Zone, this.Report.Pet.Point));
    this.Cstr_Coordinate[0].IntToFormat((long) this.Report.Pet.KindgomID);
    this.Cstr_Coordinate[0].IntToFormat((long) (int) this.tmpV.x);
    this.Cstr_Coordinate[0].IntToFormat((long) (int) this.tmpV.y);
    if (this.GUIM.IsArabic)
      this.Cstr_Coordinate[0].AppendFormat("{0}:K {1}:X {2}:Y");
    else
      this.Cstr_Coordinate[0].AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
    this.Cstr_Coordinate[1].StringToFormat(this.Cstr_Coordinate[0]);
    this.Cstr_Coordinate[1].AppendFormat(this.DM.mStringTable.GetStringByID(10092U));
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
    this.tmpPT = this.PM.PetTable.GetRecordByKey(this.Report.Pet.PetID);
    this.skill = this.PM.PetSkillTable.GetRecordByKey(this.Report.Pet.SkillID);
    if (this.Report.Pet.Result == PetReportResultType.EPRR_ATTACKFAILED)
    {
      ((Component) this.SummaryRT).gameObject.SetActive(false);
      ((Component) this.FailureRT).gameObject.SetActive(true);
      this.tmpH -= 305f;
      this.GUIM.ChangeHeroItemImg(((Component) this.btn_Pet_Failure).transform, eHeroOrItem.Pet, this.Report.Pet.PetID, (byte) 0, (byte) 0);
      this.text_FailurePetName.text = this.DM.mStringTable.GetStringByID((uint) this.tmpPT.Name);
      this.text_FailurePetName.SetAllDirty();
      this.text_FailurePetName.cachedTextGenerator.Invalidate();
      this.Cstr_PetSkillLv.ClearString();
      this.Cstr_PetSkillLv.IntToFormat((long) this.Report.Pet.SkillLevel);
      this.Cstr_PetSkillLv.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.skill.Name));
      this.Cstr_PetSkillLv.AppendFormat(this.DM.mStringTable.GetStringByID(268U));
      this.text_FailurePetSkillLv.text = this.Cstr_PetSkillLv.ToString();
      this.text_FailurePetSkillLv.SetAllDirty();
      this.text_FailurePetSkillLv.cachedTextGenerator.Invalidate();
      this.Cstr_PetSkillInfo.ClearString();
      this.text_tmpStr.text = this.DM.mStringTable.GetStringByID(10097U);
      this.text_tmpStr.SetAllDirty();
      this.text_tmpStr.cachedTextGenerator.Invalidate();
      this.Cstr_PetSkillInfo.Append(this.DM.mStringTable.GetStringByID(10098U));
      ((Graphic) this.text_FailurePetSkillInfo).color = new Color(1f, 0.353f, 0.443f);
      this.text_FailurePetSkillInfo.text = this.Cstr_PetSkillInfo.ToString();
      this.text_FailurePetSkillInfo.SetAllDirty();
      this.text_FailurePetSkillInfo.cachedTextGenerator.Invalidate();
      this.text_FailurePetSkillInfo.cachedTextGeneratorForLayout.Invalidate();
      float y = this.text_FailurePetSkillInfo.preferredHeight + 1f;
      if ((double) this.text_FailurePetSkillInfo.preferredHeight > 150.0)
        y = 150f;
      ((Graphic) this.text_FailurePetSkillInfo).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_FailurePetSkillInfo).rectTransform.sizeDelta.x, y);
    }
    else
    {
      ((Component) this.SummaryRT).gameObject.SetActive(true);
      ((Component) this.FailureRT).gameObject.SetActive(false);
      this.tmpH -= 363f;
      this.tmpH -= 226f;
      this.Cstr_Offensive[0].ClearString();
      this.Cstr_Offensive[1].ClearString();
      if (this.IsAttack)
      {
        this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(5315U));
        this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(5317U));
        this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(10096U));
        this.Img_Summarybg[0].sprite = this.SArray.m_Sprites[0];
        this.Img_Summarybg[1].sprite = this.SArray.m_Sprites[1];
        this.text_tmpStr.text = this.DM.mStringTable.GetStringByID(10095U);
      }
      else
      {
        this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(5315U));
        this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(10096U));
        this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(5317U));
        this.Img_Summarybg[0].sprite = this.SArray.m_Sprites[1];
        this.Img_Summarybg[1].sprite = this.SArray.m_Sprites[0];
        this.text_tmpStr.text = this.DM.mStringTable.GetStringByID(10110U);
      }
      this.text_tmpStr.SetAllDirty();
      this.text_tmpStr.cachedTextGenerator.Invalidate();
      this.text_Offensive[0].text = this.Cstr_Offensive[0].ToString();
      this.text_Offensive[0].SetAllDirty();
      this.text_Offensive[0].cachedTextGenerator.Invalidate();
      this.text_Offensive[1].text = this.Cstr_Offensive[1].ToString();
      this.text_Offensive[1].SetAllDirty();
      this.text_Offensive[1].cachedTextGenerator.Invalidate();
      this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.Report.Pet.AssaultHead);
      this.Img_MainHero[1].sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
      this.Cstr_Dominance[0].ClearString();
      this.Cstr_Dominance[0].IntToFormat((long) this.Report.Pet.AssaultLevel);
      this.Cstr_Dominance[0].AppendFormat(this.DM.mStringTable.GetStringByID(5320U));
      this.text_Dominance[0].text = this.Cstr_Dominance[0].ToString();
      this.text_Dominance[0].SetAllDirty();
      this.text_Dominance[0].cachedTextGenerator.Invalidate();
      this.Cstr_Country[0].ClearString();
      this.Cstr_Country[0].IntToFormat((long) this.Report.Pet.AssaultKingdomID);
      if (this.GUIM.IsArabic)
        this.Cstr_Country[0].AppendFormat("{0}#");
      else
        this.Cstr_Country[0].AppendFormat("#{0}");
      this.text_Country[0].text = this.Cstr_Country[0].ToString();
      this.text_Country[0].SetAllDirty();
      this.text_Country[0].cachedTextGenerator.Invalidate();
      int assaultAllianceRank = (int) this.Report.Pet.AssaultAllianceRank;
      this.Img_Rank[0].sprite = this.SArray.m_Sprites[1 + assaultAllianceRank];
      if (assaultAllianceRank < 1)
        ((Component) this.Img_Rank[0]).gameObject.SetActive(false);
      else
        ((Component) this.Img_Rank[0]).gameObject.SetActive(true);
      this.text_Vip[0].text = ((int) this.Report.Pet.AssaultVIPLevel).ToString();
      this.Cstr_CoordinateMainHero[0].ClearString();
      this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Pet.AssaultCapitalZone, this.Report.Pet.AssaultCapitalPoint));
      this.Cstr_CoordinateMainHero[0].IntToFormat((long) this.Report.Pet.KindgomID);
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
      CString Name2 = StringManager.Instance.StaticString1024();
      CString Tag2 = StringManager.Instance.StaticString1024();
      Name2.ClearString();
      Tag2.ClearString();
      Name2.Append(this.Report.Pet.AssaultName);
      if (this.Report.Pet.AssaultAllianceTag != string.Empty)
      {
        Tag2.Append(this.Report.Pet.AssaultAllianceTag);
        GameConstants.FormatRoleName(this.Cstr_Name[0], Name2, Tag2, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      }
      else
        GameConstants.FormatRoleName(this.Cstr_Name[0], Name2, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      this.text_Name[0].text = this.Cstr_Name[0].ToString();
      this.text_Name[0].SetAllDirty();
      this.text_Name[0].cachedTextGenerator.Invalidate();
      this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.Report.Pet.DefenceHead);
      this.Img_MainHero[4].sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
      this.Cstr_Dominance[1].ClearString();
      this.Cstr_Dominance[1].IntToFormat((long) this.Report.Pet.DefenceLevel);
      this.Cstr_Dominance[1].AppendFormat(this.DM.mStringTable.GetStringByID(5320U));
      this.text_Dominance[1].text = this.Cstr_Dominance[1].ToString();
      this.text_Dominance[1].SetAllDirty();
      this.text_Dominance[1].cachedTextGenerator.Invalidate();
      this.Cstr_Country[1].ClearString();
      this.Cstr_Country[1].IntToFormat((long) this.Report.Pet.DefenceKingdomID);
      if (this.GUIM.IsArabic)
        this.Cstr_Country[1].AppendFormat("{0}#");
      else
        this.Cstr_Country[1].AppendFormat("#{0}");
      this.text_Country[1].text = this.Cstr_Country[1].ToString();
      this.text_Country[1].SetAllDirty();
      this.text_Country[1].cachedTextGenerator.Invalidate();
      int defenceAllianceRank = (int) this.Report.Pet.DefenceAllianceRank;
      this.Img_Rank[1].sprite = this.SArray.m_Sprites[1 + defenceAllianceRank];
      if (defenceAllianceRank < 1)
        ((Component) this.Img_Rank[1]).gameObject.SetActive(false);
      else
        ((Component) this.Img_Rank[1]).gameObject.SetActive(true);
      this.text_Vip[1].text = ((int) this.Report.Pet.DefenceVIPLevel).ToString();
      this.Cstr_CoordinateMainHero[1].ClearString();
      this.tmpV = GameConstants.getTileMapPosbyMapID(GameConstants.PointCodeToMapID(this.Report.Pet.DefenceCapitalZone, this.Report.Pet.DefenceCapitalPoint));
      this.Cstr_CoordinateMainHero[1].IntToFormat((long) this.Report.Pet.KindgomID);
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
      Name2.ClearString();
      Tag2.ClearString();
      Name2.Append(this.Report.Pet.DefenceName);
      if (this.Report.Pet.DefenceAllianceTag != string.Empty)
      {
        Tag2.Append(this.Report.Pet.DefenceAllianceTag);
        GameConstants.FormatRoleName(this.Cstr_Name[1], Name2, Tag2, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      }
      else
        GameConstants.FormatRoleName(this.Cstr_Name[1], Name2, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      this.text_Name[1].text = this.Cstr_Name[1].ToString();
      this.text_Name[1].SetAllDirty();
      this.text_Name[1].cachedTextGenerator.Invalidate();
      this.GUIM.ChangeHeroItemImg(((Component) this.btn_Pet).transform, eHeroOrItem.Pet, this.Report.Pet.PetID, this.Report.Pet.PetStar, (byte) 0);
      this.text_PetName.text = this.DM.mStringTable.GetStringByID((uint) this.tmpPT.Name);
      this.text_PetName.SetAllDirty();
      this.text_PetName.cachedTextGenerator.Invalidate();
      this.Cstr_PetSkillLv.ClearString();
      this.Cstr_PetSkillLv.IntToFormat((long) this.Report.Pet.SkillLevel);
      this.Cstr_PetSkillLv.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.skill.Name));
      this.Cstr_PetSkillLv.AppendFormat(this.DM.mStringTable.GetStringByID(268U));
      this.text_PetSkillLv.text = this.Cstr_PetSkillLv.ToString();
      this.text_PetSkillLv.SetAllDirty();
      this.text_PetSkillLv.cachedTextGenerator.Invalidate();
      this.Cstr_PetSkillInfo.ClearString();
      if ((int) this.DM.PetVersionNo != (int) this.Report.Pet.PatchNo)
        this.Cstr_PetSkillInfo.Append(this.DM.mStringTable.GetStringByID(10100U));
      else
        this.PM.FormatSkillContent(this.Report.Pet.SkillID, this.Report.Pet.SkillLevel, this.Cstr_PetSkillInfo, (byte) 0);
      this.text_PetSkillInfo.text = this.Cstr_PetSkillInfo.ToString();
      this.text_PetSkillInfo.SetAllDirty();
      this.text_PetSkillInfo.cachedTextGenerator.Invalidate();
      this.text_PetSkillInfo.cachedTextGeneratorForLayout.Invalidate();
      ((Graphic) this.text_PetSkillInfo).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_PetSkillInfo).rectTransform.sizeDelta.x, this.text_PetSkillInfo.preferredHeight + 1f);
      this.tmpH -= (float) ((double) this.text_PetSkillInfo.preferredHeight + 1.0 - 30.0);
      this.Pet_BGRT.sizeDelta = new Vector2(this.Pet_BGRT.sizeDelta.x, (float) (185.0 + ((double) this.text_PetSkillInfo.preferredHeight + 1.0 - 30.0)));
      this.Pet_InfoRT.anchoredPosition = new Vector2(this.Pet_InfoRT.anchoredPosition.x, (float) (-226.0 - ((double) this.text_PetSkillInfo.preferredHeight + 1.0 - 30.0)));
      ((Component) this.Pet_InfoRT).gameObject.SetActive(false);
      ((Component) this.Pet_WallRT).gameObject.SetActive(false);
      ((Component) this.Pet_AttackRT).gameObject.SetActive(false);
      ((Component) this.Pet_BeAttackedRT).gameObject.SetActive(false);
      ((Component) this.Pet_ResourcesRT).gameObject.SetActive(false);
      if ((int) this.DM.PetVersionNo == (int) this.Report.Pet.PatchNo)
      {
        ((Component) this.Pet_InfoRT).gameObject.SetActive(true);
        switch (this.Report.Pet.Result)
        {
          case PetReportResultType.EPRR_ATTACK_NONE:
          case PetReportResultType.EPRR_UNDERATTACKED_NONE:
            ((Component) this.Pet_InfoRT).gameObject.SetActive(false);
            break;
          case PetReportResultType.EPRR_ATTACK_RSS:
          case PetReportResultType.EPRR_UNDERATTACKED_RSS:
            ((Component) this.Pet_ResourcesRT).gameObject.SetActive(true);
            break;
          case PetReportResultType.EPRR_ATTACK_TROOP:
            ((Component) this.Pet_AttackRT).gameObject.SetActive(true);
            break;
          case PetReportResultType.EPRR_UNDERATTACKED_TROOP:
            ((Component) this.Pet_BeAttackedRT).gameObject.SetActive(true);
            break;
          case PetReportResultType.EPRR_ATTACK_WALL:
          case PetReportResultType.EPRR_UNDERATTACKED_WALL:
            ((Component) this.Pet_WallRT).gameObject.SetActive(true);
            break;
        }
      }
      if (((Component) this.Pet_WallRT).gameObject.activeSelf)
      {
        this.tmpH -= 53f;
        this.Cstr_PetWall.ClearString();
        this.Cstr_PetWall.IntToFormat((long) this.Report.Pet.WallDamage, bNumber: true);
        this.Cstr_PetWall.AppendFormat("{0}");
        this.text_PetWall[1].text = this.Cstr_PetWall.ToString();
        this.text_PetWall[1].SetAllDirty();
        this.text_PetWall[1].cachedTextGenerator.Invalidate();
        this.tmpH -= 100f;
      }
      if (((Component) this.Pet_AttackRT).gameObject.activeSelf)
      {
        this.tmpH -= 53f;
        this.Cstr_PetAttack[0].ClearString();
        this.Cstr_PetAttack[0].uLongToFormat(this.Report.Pet.LostPower, bNumber: true);
        this.Cstr_PetAttack[0].AppendFormat(this.DM.mStringTable.GetStringByID(5322U));
        this.text_PetAttack[0].text = this.Cstr_PetAttack[0].ToString();
        this.text_PetAttack[0].SetAllDirty();
        this.text_PetAttack[0].cachedTextGenerator.Invalidate();
        this.Cstr_PetAttack[1].ClearString();
        this.Cstr_PetAttack[1].IntToFormat((long) this.Report.Pet.TotalInjure, bNumber: true);
        this.Cstr_PetAttack[1].AppendFormat("{0}");
        this.text_PetAttack[2].text = this.Cstr_PetAttack[1].ToString();
        this.text_PetAttack[2].SetAllDirty();
        this.text_PetAttack[2].cachedTextGenerator.Invalidate();
        this.Cstr_PetAttack[2].ClearString();
        this.Cstr_PetAttack[2].IntToFormat((long) this.Report.Pet.TotalDead, bNumber: true);
        this.Cstr_PetAttack[2].AppendFormat("{0}");
        this.text_PetAttack[4].text = this.Cstr_PetAttack[2].ToString();
        this.text_PetAttack[4].SetAllDirty();
        this.text_PetAttack[4].cachedTextGenerator.Invalidate();
        this.tmpH -= 145f;
      }
      if (((Component) this.Pet_BeAttackedRT).gameObject.activeSelf)
      {
        this.tmpH -= 53f;
        this.Cstr_PetBeAttacked[0].ClearString();
        this.Cstr_PetBeAttacked[0].uLongToFormat(this.Report.Pet.LostPower, bNumber: true);
        this.Cstr_PetBeAttacked[0].AppendFormat(this.DM.mStringTable.GetStringByID(5322U));
        this.text_PetBeAttacked[0].text = this.Cstr_PetBeAttacked[0].ToString();
        this.text_PetBeAttacked[0].SetAllDirty();
        this.text_PetBeAttacked[0].cachedTextGenerator.Invalidate();
        int index1 = 0;
        for (int index2 = 0; index2 < 16; ++index2)
        {
          int index3 = 3 - index2 / 4 + index2 % 4 * 4;
          if (this.Report.Pet.InjureTroops[index3] != 0U || this.Report.Pet.DeadTroops[index3] != 0U)
          {
            this.Soldier_T[index1].gameObject.SetActive(true);
            this.Hbtn_Hint[index1].Parm2 = (byte) index3;
            this.Hbtn_Hint[index1].enabled = true;
            SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (index3 + 1));
            this.Img_Soldier[index1].sprite = this.SArray.m_Sprites[7 + (int) recordByKey.SoldierKind];
            ((Component) this.Img_Soldier[index1]).gameObject.SetActive(true);
            this.text_Soldier_Rank[index1].text = recordByKey.Tier.ToString();
            this.text_Soldier_Rank[index1].SetAllDirty();
            this.text_Soldier_Rank[index1].cachedTextGenerator.Invalidate();
            this.text_Soldier_Name[index1].text = this.DM.mStringTable.GetStringByID((uint) recordByKey.Name);
            this.text_Soldier_Name[index1].SetAllDirty();
            this.text_Soldier_Name[index1].cachedTextGenerator.Invalidate();
            this.text_Soldier_Name[index1].cachedTextGeneratorForLayout.Invalidate();
            this.Cstr_Soldier_Hurt[index1].ClearString();
            this.Cstr_Soldier_Hurt[index1].IntToFormat((long) this.Report.Pet.InjureTroops[index3], bNumber: true);
            this.Cstr_Soldier_Hurt[index1].AppendFormat("{0}");
            this.text_Soldier_Hurt[index1].text = this.Cstr_Soldier_Hurt[index1].ToString();
            this.text_Soldier_Hurt[index1].SetAllDirty();
            this.text_Soldier_Hurt[index1].cachedTextGenerator.Invalidate();
            this.Cstr_Soldier_Death[index1].ClearString();
            this.Cstr_Soldier_Death[index1].IntToFormat((long) this.Report.Pet.DeadTroops[index3], bNumber: true);
            this.Cstr_Soldier_Death[index1].AppendFormat("{0}");
            this.text_Soldier_Death[index1].text = this.Cstr_Soldier_Death[index1].ToString();
            this.text_Soldier_Death[index1].SetAllDirty();
            this.text_Soldier_Death[index1].cachedTextGenerator.Invalidate();
            this.Pet_btnSoldierRT[index1].sizeDelta = new Vector2(47f + this.text_Soldier_Name[index1].preferredWidth, this.Pet_btnSoldierRT[index1].sizeDelta.y);
            ++index1;
          }
        }
        if (index1 == 0)
        {
          ((Component) this.Img_Soldier[index1]).gameObject.SetActive(false);
          this.Hbtn_Hint[index1].enabled = false;
          this.text_Soldier_Name[index1].text = "-";
          this.text_Soldier_Name[index1].SetAllDirty();
          this.text_Soldier_Name[index1].cachedTextGenerator.Invalidate();
          this.text_Soldier_Name[index1].cachedTextGeneratorForLayout.Invalidate();
          this.Cstr_Soldier_Hurt[index1].ClearString();
          this.Cstr_Soldier_Hurt[index1].IntToFormat(0L, bNumber: true);
          this.Cstr_Soldier_Hurt[index1].AppendFormat("{0}");
          this.text_Soldier_Hurt[index1].text = this.Cstr_Soldier_Hurt[index1].ToString();
          this.text_Soldier_Hurt[index1].SetAllDirty();
          this.text_Soldier_Hurt[index1].cachedTextGenerator.Invalidate();
          this.Cstr_Soldier_Death[index1].ClearString();
          this.Cstr_Soldier_Death[index1].IntToFormat(0L, bNumber: true);
          this.Cstr_Soldier_Death[index1].AppendFormat("{0}");
          this.text_Soldier_Death[index1].text = this.Cstr_Soldier_Death[index1].ToString();
          this.text_Soldier_Death[index1].SetAllDirty();
          this.text_Soldier_Death[index1].cachedTextGenerator.Invalidate();
          this.Soldier_T[index1].gameObject.SetActive(true);
          ++index1;
        }
        for (int index4 = index1; index4 < 16; ++index4)
          this.Soldier_T[index4].gameObject.SetActive(false);
        this.Pet_BeAttackedRT.sizeDelta = new Vector2(this.Pet_BeAttackedRT.sizeDelta.x, (float) (120 + index1 * 35));
        this.tmpH -= this.Pet_BeAttackedRT.sizeDelta.y;
      }
      if (((Component) this.Pet_ResourcesRT).gameObject.activeSelf)
      {
        this.tmpH -= 53f;
        for (int index = 0; index < 5; ++index)
        {
          this.Cstr_PetResources[index].ClearString();
          this.Cstr_PetResources[index].Append("-");
          if (this.Report.Pet.Resource[index] > 0U)
            GameConstants.FormatResourceValue(this.Cstr_PetResources[index], this.Report.Pet.Resource[index]);
          this.text_PetResources[index].text = this.Cstr_PetResources[index].ToString();
          this.text_PetResources[index].SetAllDirty();
          this.text_PetResources[index].cachedTextGenerator.Invalidate();
        }
        this.tmpH -= 95f;
      }
      if ((int) this.Report.Pet.AssaultKingdomID != (int) this.Report.Pet.DefenceKingdomID)
      {
        ((Component) this.Img_Country[0]).gameObject.SetActive(true);
        ((Component) this.Img_Country[1]).gameObject.SetActive(true);
      }
      else
      {
        ((Component) this.Img_Country[0]).gameObject.SetActive(false);
        ((Component) this.Img_Country[1]).gameObject.SetActive(false);
      }
    }
    this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, -this.tmpH);
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
        this.Open_NP_Mail(false);
        break;
      case 2:
        this.Open_NP_Mail(true);
        break;
      case 3:
        this.door.GoToPointCode(this.Report.Pet.KindgomID, this.Report.Pet.Zone, this.Report.Pet.Point, (byte) 0);
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
        this.door.GoToPointCode(this.Report.Pet.KindgomID, this.Report.Pet.AssaultCapitalZone, this.Report.Pet.AssaultCapitalPoint, (byte) 0);
        break;
      case 7:
        this.door.GoToPointCode(this.Report.Pet.KindgomID, this.Report.Pet.DefenceCapitalZone, this.Report.Pet.DefenceCapitalPoint, (byte) 0);
        break;
      case 8:
      case 9:
        this.ShowLordProfile((PetSkill_FS_btn) sender.m_BtnID1);
        break;
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 3, 277f, 20, (int) sender.Parm2, 0, new Vector2(70f, 0.0f));
  }

  public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide(true);

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
            this.door.OpenMenu(EGUIWindow.UI_FightingSummary);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
            return;
          case CombatCollectReport.CCR_RESOURCE:
            this.door.OpenMenu(EGUIWindow.UI_Letter_Resources);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
            return;
          case CombatCollectReport.CCR_COLLECT:
            this.door.OpenMenu(EGUIWindow.UI_Letter_Collection);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
            return;
          case CombatCollectReport.CCR_SCOUT:
            if (this.Favor.Combat.Scout.ScoutLevel != (byte) 0)
              this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower);
            else
              this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower, 1);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
            return;
          case CombatCollectReport.CCR_RECON:
            this.door.OpenMenu(EGUIWindow.UI_Letter_Watchtower_Recon);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
            return;
          case CombatCollectReport.CCR_MONSTER:
            if (this.Favor.Combat.Monster.Result < (byte) 2 || this.Favor.Combat.Monster.Result > (byte) 3)
            {
              this.door.OpenMenu(EGUIWindow.UI_FightingSummary);
              this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
              return;
            }
            this.door.OpenMenu(EGUIWindow.UI_LetterDetail);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
            return;
          case CombatCollectReport.CCR_NPCSCOUT:
            this.door.OpenMenu(EGUIWindow.UI_Letter_NPCScout);
            this.DM.RemoveDoorUIStack(EGUIWindow.UI_PetSkill_FS);
            return;
          case CombatCollectReport.CCR_PETREPORT:
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
                  this.DM.BattleReportRead(this.Report.SerialID, false);
                else
                  this.DM.FavorReportRead(this.Report.SerialID, false);
              }
              this.IsAttack = this.Report.Pet.Side == (byte) 0;
              this.SetFSInfo();
              return;
            }
            this.door.CloseMenu();
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
        if (networkNews != NetworkNews.Refresh_Mailbox)
        {
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
        if (this.DM.MailReportGet(ref this.Favor))
          break;
        this.door.CloseMenu();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Coordinate != (Object) null && ((Behaviour) this.text_Coordinate).enabled)
    {
      ((Behaviour) this.text_Coordinate).enabled = false;
      ((Behaviour) this.text_Coordinate).enabled = true;
    }
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
    if ((Object) this.text_Summary != (Object) null && ((Behaviour) this.text_Summary).enabled)
    {
      ((Behaviour) this.text_Summary).enabled = false;
      ((Behaviour) this.text_Summary).enabled = true;
    }
    if ((Object) this.text_PetSkillTitle != (Object) null && ((Behaviour) this.text_PetSkillTitle).enabled)
    {
      ((Behaviour) this.text_PetSkillTitle).enabled = false;
      ((Behaviour) this.text_PetSkillTitle).enabled = true;
    }
    if ((Object) this.text_PetName != (Object) null && ((Behaviour) this.text_PetName).enabled)
    {
      ((Behaviour) this.text_PetName).enabled = false;
      ((Behaviour) this.text_PetName).enabled = true;
    }
    if ((Object) this.text_PetSkillLv != (Object) null && ((Behaviour) this.text_PetSkillLv).enabled)
    {
      ((Behaviour) this.text_PetSkillLv).enabled = false;
      ((Behaviour) this.text_PetSkillLv).enabled = true;
    }
    if ((Object) this.text_PetSkillInfo != (Object) null && ((Behaviour) this.text_PetSkillInfo).enabled)
    {
      ((Behaviour) this.text_PetSkillInfo).enabled = false;
      ((Behaviour) this.text_PetSkillInfo).enabled = true;
    }
    if ((Object) this.text_PetLoss != (Object) null && ((Behaviour) this.text_PetLoss).enabled)
    {
      ((Behaviour) this.text_PetLoss).enabled = false;
      ((Behaviour) this.text_PetLoss).enabled = true;
    }
    if ((Object) this.text_FailurePetName != (Object) null && ((Behaviour) this.text_FailurePetName).enabled)
    {
      ((Behaviour) this.text_FailurePetName).enabled = false;
      ((Behaviour) this.text_FailurePetName).enabled = true;
    }
    if ((Object) this.text_FailurePetSkillLv != (Object) null && ((Behaviour) this.text_FailurePetSkillLv).enabled)
    {
      ((Behaviour) this.text_FailurePetSkillLv).enabled = false;
      ((Behaviour) this.text_FailurePetSkillLv).enabled = true;
    }
    if ((Object) this.text_FailurePetSkillInfo != (Object) null && ((Behaviour) this.text_FailurePetSkillInfo).enabled)
    {
      ((Behaviour) this.text_FailurePetSkillInfo).enabled = false;
      ((Behaviour) this.text_FailurePetSkillInfo).enabled = true;
    }
    if ((Object) this.text_tmpStr != (Object) null && ((Behaviour) this.text_tmpStr).enabled)
    {
      ((Behaviour) this.text_tmpStr).enabled = false;
      ((Behaviour) this.text_tmpStr).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_Time[index] != (Object) null && ((Behaviour) this.text_Time[index]).enabled)
      {
        ((Behaviour) this.text_Time[index]).enabled = false;
        ((Behaviour) this.text_Time[index]).enabled = true;
      }
      if ((Object) this.text_Offensive[index] != (Object) null && ((Behaviour) this.text_Offensive[index]).enabled)
      {
        ((Behaviour) this.text_Offensive[index]).enabled = false;
        ((Behaviour) this.text_Offensive[index]).enabled = true;
      }
      if ((Object) this.text_MainHero_F[index] != (Object) null && ((Behaviour) this.text_MainHero_F[index]).enabled)
      {
        ((Behaviour) this.text_MainHero_F[index]).enabled = false;
        ((Behaviour) this.text_MainHero_F[index]).enabled = true;
      }
      if ((Object) this.text_Dominance[index] != (Object) null && ((Behaviour) this.text_Dominance[index]).enabled)
      {
        ((Behaviour) this.text_Dominance[index]).enabled = false;
        ((Behaviour) this.text_Dominance[index]).enabled = true;
      }
      if ((Object) this.text_Country[index] != (Object) null && ((Behaviour) this.text_Country[index]).enabled)
      {
        ((Behaviour) this.text_Country[index]).enabled = false;
        ((Behaviour) this.text_Country[index]).enabled = true;
      }
      if ((Object) this.text_Vip[index] != (Object) null && ((Behaviour) this.text_Vip[index]).enabled)
      {
        ((Behaviour) this.text_Vip[index]).enabled = false;
        ((Behaviour) this.text_Vip[index]).enabled = true;
      }
      if ((Object) this.text_CoordinateMainHero[index] != (Object) null && ((Behaviour) this.text_CoordinateMainHero[index]).enabled)
      {
        ((Behaviour) this.text_CoordinateMainHero[index]).enabled = false;
        ((Behaviour) this.text_CoordinateMainHero[index]).enabled = true;
      }
      if ((Object) this.text_Name[index] != (Object) null && ((Behaviour) this.text_Name[index]).enabled)
      {
        ((Behaviour) this.text_Name[index]).enabled = false;
        ((Behaviour) this.text_Name[index]).enabled = true;
      }
      if ((Object) this.text_PetWall[index] != (Object) null && ((Behaviour) this.text_PetWall[index]).enabled)
      {
        ((Behaviour) this.text_PetWall[index]).enabled = false;
        ((Behaviour) this.text_PetWall[index]).enabled = true;
      }
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((Object) this.text_PetBeAttacked[index] != (Object) null && ((Behaviour) this.text_PetBeAttacked[index]).enabled)
      {
        ((Behaviour) this.text_PetBeAttacked[index]).enabled = false;
        ((Behaviour) this.text_PetBeAttacked[index]).enabled = true;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.text_PetAttack[index] != (Object) null && ((Behaviour) this.text_PetAttack[index]).enabled)
      {
        ((Behaviour) this.text_PetAttack[index]).enabled = false;
        ((Behaviour) this.text_PetAttack[index]).enabled = true;
      }
      if ((Object) this.text_PetResources[index] != (Object) null && ((Behaviour) this.text_PetResources[index]).enabled)
      {
        ((Behaviour) this.text_PetResources[index]).enabled = false;
        ((Behaviour) this.text_PetResources[index]).enabled = true;
      }
    }
    for (int index = 0; index < 16; ++index)
    {
      if ((Object) this.text_Soldier_Rank[index] != (Object) null && ((Behaviour) this.text_Soldier_Rank[index]).enabled)
      {
        ((Behaviour) this.text_Soldier_Rank[index]).enabled = false;
        ((Behaviour) this.text_Soldier_Rank[index]).enabled = true;
      }
      if ((Object) this.text_Soldier_Name[index] != (Object) null && ((Behaviour) this.text_Soldier_Name[index]).enabled)
      {
        ((Behaviour) this.text_Soldier_Name[index]).enabled = false;
        ((Behaviour) this.text_Soldier_Name[index]).enabled = true;
      }
      if ((Object) this.text_Soldier_Hurt[index] != (Object) null && ((Behaviour) this.text_Soldier_Hurt[index]).enabled)
      {
        ((Behaviour) this.text_Soldier_Hurt[index]).enabled = false;
        ((Behaviour) this.text_Soldier_Hurt[index]).enabled = true;
      }
      if ((Object) this.text_Soldier_Death[index] != (Object) null && ((Behaviour) this.text_Soldier_Death[index]).enabled)
      {
        ((Behaviour) this.text_Soldier_Death[index]).enabled = false;
        ((Behaviour) this.text_Soldier_Death[index]).enabled = true;
      }
    }
    if (!((Object) this.btn_Pet != (Object) null) || !((Behaviour) this.btn_Pet).enabled)
      return;
    this.btn_Pet.Refresh_FontTexture();
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
    }
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
    if ((Object) this.PreviousT != (Object) null)
    {
      this.Vec3Instance.Set(this.MoveTime2 + num, this.PreviousT.localPosition.y, this.PreviousT.localPosition.z);
      this.PreviousT.localPosition = this.Vec3Instance;
    }
    if ((Object) this.LightT1 != (Object) null)
      this.LightT1.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    if ((Object) this.LightT2 != (Object) null)
      this.LightT2.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    this.ShowVsTime += Time.smoothDeltaTime;
    if ((double) this.ShowVsTime < 0.0)
      return;
    if ((double) this.ShowVsTime >= 2.0)
      this.ShowVsTime = 0.0f;
    float a = (double) this.ShowVsTime <= 1.0 ? this.ShowVsTime : 2f - this.ShowVsTime;
    if (!((Object) this.Img_Vs != (Object) null))
      return;
    ((Graphic) this.Img_Vs).color = new Color(1f, 1f, 1f, a);
  }

  public override void OnClose()
  {
    if (this.Cstr_TitleName != null)
      StringManager.Instance.DeSpawnString(this.Cstr_TitleName);
    if (this.Cstr_Page != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Page);
    if (this.Cstr_Text != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Text);
    for (int index = 0; index < 2; ++index)
    {
      if (this.Cstr_Coordinate[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Coordinate[index]);
      if (this.Cstr_Offensive[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Offensive[index]);
      if (this.Cstr_Dominance[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Dominance[index]);
      if (this.Cstr_Country[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Country[index]);
      if (this.Cstr_CoordinateMainHero[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_CoordinateMainHero[index]);
      if (this.Cstr_Name[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Name[index]);
    }
    if (this.Cstr_PetSkillLv != null)
      StringManager.Instance.DeSpawnString(this.Cstr_PetSkillLv);
    if (this.Cstr_PetSkillInfo != null)
      StringManager.Instance.DeSpawnString(this.Cstr_PetSkillInfo);
    if (this.Cstr_PetWall != null)
      StringManager.Instance.DeSpawnString(this.Cstr_PetWall);
    for (int index = 0; index < 3; ++index)
    {
      if (this.Cstr_PetAttack[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_PetAttack[index]);
    }
    for (int index = 0; index < 17; ++index)
    {
      if (this.Cstr_PetBeAttacked[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_PetBeAttacked[index]);
    }
    for (int index = 0; index < 5; ++index)
    {
      if (this.Cstr_PetResources[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_PetResources[index]);
    }
    for (int index = 0; index < 16; ++index)
    {
      if (this.Cstr_Soldier_Hurt[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Soldier_Hurt[index]);
      if (this.Cstr_Soldier_Death[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Soldier_Death[index]);
    }
    if (this.bSaveY)
    {
      this.DM.LetterFs_Y = this.ContentRT.anchoredPosition.y;
      this.DM.mFs_Serial = this.Favor.Serial;
    }
    else
      this.DM.LetterFs_Y = -1f;
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
    if (this.Img_MainHero != null && (Object) this.Img_MainHero[index1] != (Object) null && (Object) ((Component) this.Img_MainHero[index1]).transform.GetChild(0) != (Object) null)
    {
      UIButton component = ((Component) this.Img_MainHero[index1]).transform.GetChild(0).gameObject.GetComponent<UIButton>();
      if ((Object) component != (Object) null)
      {
        component.m_Handler = (IUIButtonClickHandler) this;
        component.m_BtnID1 = index1 != 0 ? 9 : 8;
        component.m_EffectType = e_EffectType.e_Scale;
        component.transition = (Selectable.Transition) 0;
      }
    }
    if (this.Img_MainHero == null || !((Object) this.Img_MainHero[index2] != (Object) null) || !((Object) ((Component) this.Img_MainHero[index2]).transform.GetChild(0) != (Object) null))
      return;
    UIButton component1 = ((Component) this.Img_MainHero[index2]).transform.GetChild(0).gameObject.GetComponent<UIButton>();
    if (!((Object) component1 != (Object) null))
      return;
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = index2 != 0 ? 9 : 8;
    component1.m_EffectType = e_EffectType.e_Scale;
    component1.transition = (Selectable.Transition) 0;
  }

  private void ShowLordProfile(PetSkill_FS_btn type)
  {
    this.DM.PlayerName_War[0].Append(this.Report.Pet.AssaultName);
    this.DM.PlayerName_War[1].Append(this.Report.Pet.DefenceName);
    switch (type)
    {
      case PetSkill_FS_btn.btn_Porfile_Atk:
        if (this.Report == null || this.Report.Pet == null || this.Report.Pet.AssaultName == null || !(this.Report.Pet.AssaultName != string.Empty))
          break;
        this.bSaveY = true;
        DataManager.Instance.ShowLordProfile(this.Report.Pet.AssaultName);
        break;
      case PetSkill_FS_btn.btn_Porfile_Def:
        if (this.Report == null || this.Report.Pet == null || this.Report.Pet.DefenceName == null || !(this.Report.Pet.DefenceName != string.Empty))
          break;
        this.bSaveY = true;
        DataManager.Instance.ShowLordProfile(this.Report.Pet.DefenceName);
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
