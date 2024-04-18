// Decompiled with JetBrains decompiler
// Type: UIHero_Info
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIHero_Info : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUTimeBarOnTimer
{
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Tmp2;
  private Transform PageT;
  private Transform[] Pagedata = new Transform[3];
  private Transform P3_p1;
  private Transform P3_p2;
  private Transform Hero_3D;
  private Transform Hero_Pos;
  private Transform Equip_ImgT;
  private Transform Star_ImgT;
  private Transform Rank_ImgT;
  private Transform Skill_ImgT;
  private Transform btn_NextT;
  private Transform btn_BackT;
  private Transform RankLightT;
  private Transform StarLightT;
  private Transform Hero_Model;
  private Transform[] ScrollItemT = new Transform[10];
  private Transform[] SkillPageT = new Transform[2];
  private RectTransform ContentRT;
  private RectTransform Hero_PosRT;
  private RectTransform[] PropertyInfo_HintRT = new RectTransform[2];
  private RectTransform[] btn_EquipRT = new RectTransform[6];
  private RectTransform[] Img_EquipRT = new RectTransform[6];
  private RectTransform[] Img_HaveRT = new RectTransform[6];
  private RectTransform[] text_RT = new RectTransform[6];
  private RectTransform btn_EvolutionRT;
  private RectTransform Img_EvolutionUpRT;
  private RectTransform btn_StarEvolutionRT;
  private RectTransform btn_NextRankRT;
  private RectTransform btn_StarDetailRT;
  private RectTransform Img_StarStratumLightRT;
  private RectTransform uTool_RankPosRT;
  private RectTransform[] Img_EquipLightRT = new RectTransform[6];
  private RectTransform EvolutionRT;
  private RectTransform StarEvolutionRT;
  private RectTransform tmpRC;
  public UIButton btn_EXIT;
  private UIButton[] btnPage = new UIButton[3];
  public UIButton btn_Evolution;
  public UIHIBtn[] btn_Equip = new UIHIBtn[6];
  private UIButton btn_EquipStratum;
  private UIButton btn_StarEvolution;
  private UIButton btn_DETAIL;
  private UIButton[] btn_SkillPage = new UIButton[2];
  private UIButton[] btn_Skill = new UIButton[8];
  private UIButton btn_Next;
  private UIButton btn_Back;
  private UIButton btn_HeroAction;
  private UIButton btn_Rank_Exit;
  private UIHIBtn[] btn_RankEquip = new UIHIBtn[6];
  private UIButton btn_P3Info;
  private UIButton btn_Property;
  private UIButton btn_Fragment;
  private UIButton btn_HeroState;
  private UIButton[] btn_P3_Property = new UIButton[3];
  private UIButton tmpbtn;
  private UIButton[] mbtn_Item = new UIButton[10];
  private UIButton btn_HeroPowerHint;
  private UIButtonHint tmpbtnHint;
  private UIButtonHint[] mbtnH_Item = new UIButtonHint[10];
  private UIBtnDrag btn_HeroActionD;
  private Image Property_Hint;
  private Image img_HeroExp;
  private Image Fragment_Hint;
  private Image imgRank_Rank;
  private Image RankLightBG;
  private Image StarStratumLightBG;
  private Image PropertyInfo_Hint;
  private Image Img_EvolutionUp;
  private Image Img_StarEvolution;
  private Image[] img_EquipLight = new Image[6];
  private Image[] img_EquipHave = new Image[6];
  private Image[] img_EquipHave_Light = new Image[6];
  private Image[] img_SkillPage = new Image[2];
  private Image[] img_Skill = new Image[8];
  private Image[] img_SkillFrame = new Image[8];
  private Image[] img_Lock = new Image[6];
  private Image[] img_Pageicon = new Image[3];
  private Image[] img_PageBG = new Image[3];
  private Image[] img_SkillBook = new Image[3];
  private Image[] img_Skill_Lv = new Image[3];
  private Image img_HeroState;
  private Image HeroState_Hint;
  private Image HeroPower_Hint;
  private Image img_Lv;
  private Image img_PreviewBG;
  private UIText text_Rank;
  private UIText text_HeroEXP;
  private UIText text_HeroPower;
  private UIText text_Lv;
  private UIText text_HeroName;
  private UIText text_HeroTitle;
  private UIText text_NextRankTiTle;
  private UIText text_NextRank;
  private UIText text_HeroInfo;
  private UIText text_Medal;
  private UIText text_HeroStarLv;
  private UIText text_P3Title;
  private UIText text_Skill_Name;
  private UIText text_Next_RankSoldier;
  private UIText[] text_Leader = new UIText[2];
  private UIText[] text_Equip = new UIText[6];
  private UIText[] text_Property = new UIText[6];
  private UIText[] text_Skill2_ = new UIText[8];
  private UIText[] text_Skill_Lv = new UIText[4];
  private UIText[] text_Skill_Lock = new UIText[3];
  private UIText[] text_P3p2_Property = new UIText[10];
  private UIText[] text_P3p2_PropertyValue = new UIText[10];
  private UIText[] text_SkillPage = new UIText[2];
  private UIText[] text_Hint = new UIText[3];
  private UIText text_HeroStateHint;
  private UIText text_HeroPowerHint;
  private UIText[] text_tmpStr = new UIText[10];
  private UIText[] text_timeBarRank = new UIText[2];
  private UIText[] text_timeBarStar = new UIText[2];
  private UIText[] text_ShowEffect = new UIText[6];
  private UIText text_PreviewHero;
  private UIText tmptext;
  private Font TTFont;
  private CString Cstr_RankTimeBar;
  private CString Cstr_Rank;
  private CString Cstr_NextRank;
  private CString Cstr_HeroStarLv;
  private CString Cstr_HeroEXP;
  private CString Cstr_HeroPower;
  private CString Cstr_Leader;
  private CString[] Cstr_Skill_Lv = new CString[4];
  private CString[] Cstr_Skill_Cost = new CString[4];
  private CString[] Cstr_Skill_Info = new CString[4];
  private CString Cstr_Hint;
  private CString Cstr_NextRS;
  private CString[] Cstr_ShowEffect = new CString[6];
  private CString[] Cstr_Property = new CString[3];
  private CString[] Cstr_ItemPropertyValue = new CString[10];
  public UITimeBar timeBarRank;
  private UITimeBar timeBarStar;
  private Vector2 TmpV;
  private Vector3 Vec3Instance;
  private Color Text_Color = new Color(1f, 1f, 0.0f, 1f);
  private Color Color_White = Color.white;
  private Color Color_Gray = Color.gray;
  private Color Color_Green = Color.green;
  private Color Color_Target = new Color(1f, 0.988f, 0.8196f, 1f);
  private Color Color_NoTarget = new Color(0.5255f, 0.8235f, 0.902f, 1f);
  private Color Color_Equip = new Color(0.2471f, 0.4784f, 0.9333f, 1f);
  private DataManager DM;
  private GUIManager GUIM;
  private Hero sHero;
  private Enhance mEnhance;
  private Equip mEquip;
  private Skill mSkill;
  private CurHeroData mHeroData;
  private Effect meffect;
  private byte[] SkillLv = new byte[4];
  private byte[] SendSkillLv = new byte[4];
  private ushort mHeroId;
  private ushort[] pAttr = new ushort[28];
  private ushort[] pAttrIdx = new ushort[23];
  private ushort[] EquipEffect_pAttr = new ushort[28];
  private ushort[] EquipEffect_pAttrIdx = new ushort[23];
  private int mNowpage;
  private int mSkillpage;
  private int TmpChildCount;
  private int mHeroStratum;
  private int mHeroEquip;
  private int AssetKey;
  private int mHeroDataIndex = -1;
  private int[] SkillLimit = new int[4];
  private float[] StarValue = new float[6];
  private float mExpLength;
  private bool bHeroInfo = true;
  private bool bEnchantments;
  private bool bStarEvolution;
  private bool bEquip;
  private bool bSkill;
  private bool bInfo;
  private bool bFSetRankTimeBar = true;
  private bool bFSetStarTimeBar = true;
  private bool OpenUISynthesis;
  private float TmpTime;
  private float ActionTime;
  private float ActionTimeRandom;
  private float MovingTimer;
  private float MaxStar;
  private float MoveTime1;
  private float MoveTime2;
  private float SkillPageTime;
  private float ShowStarEvolution;
  private float tempL;
  private float[] EquipShow = new float[6];
  private float[] EquipShowSCale = new float[6];
  private float ShowEquipLight;
  private float PageBGTime;
  private bool bShowEquipLight;
  private bool[] Btn_Eq = new bool[6];
  private uint HP;
  private uint EquipEffect_HP;
  private uint Power;
  private long begin;
  private long target;
  private long notify;
  private byte OpenPage;
  private int TopRank = 8;
  private uint needDiamond;
  private ushort[] key = new ushort[4];
  private float PreviewTime;
  private CalcAttrDataType mCalcAttrData = new CalcAttrDataType();
  private BSInvokeUtil mBs = BSInvokeUtil.getInstance;
  private GameObject go;
  private GameObject go2;
  private GameObject mParticleRank;
  private GameObject mParticleStar;
  private GameObject mParticleEffectpAttr;
  private UISpritesArray SArray;
  private string[] TopText = new string[2];
  private ScrollPanel m_itemView;
  private CScrollRect m_ScrollRect;
  private ScrollRect m_Mask;
  private List<float> tmplist = new List<float>();
  private Material IconMaterial;
  private Material FrameMaterial;
  private Material SkillMaterial;
  private Door door;
  private AssetBundle AB;
  private AssetBundleRequest AR;
  private bool ABIsDone;
  public byte[] LegionRankMagnifation = new byte[5]
  {
    (byte) 1,
    (byte) 2,
    (byte) 4,
    (byte) 8,
    (byte) 20
  };
  private uTweenScale uToolStar;
  private uTweenScale uToolRank;
  private uTweenPosition uToolRankPos;
  private string HeroAct;
  private Animation tmpAN;
  public string[] mHeroAct = new string[7];
  private eHeroState mHeroState;
  public float mShowEffectTime;
  public int mShowEffectNum;
  private ushort[] ShowEffectpAttr = new ushort[3];
  public byte mOpenType;
  public byte mOpenKind;

  public override void OnOpen(int arg1, int arg2)
  {
    this.mOpenKind = (byte) arg1;
    this.mOpenType = (byte) arg2;
    this.Cstr_RankTimeBar = StringManager.Instance.SpawnString();
    this.Cstr_Rank = StringManager.Instance.SpawnString();
    this.Cstr_NextRank = StringManager.Instance.SpawnString();
    this.Cstr_HeroStarLv = StringManager.Instance.SpawnString();
    this.Cstr_HeroEXP = StringManager.Instance.SpawnString();
    this.Cstr_HeroPower = StringManager.Instance.SpawnString();
    this.Cstr_Leader = StringManager.Instance.SpawnString();
    for (int index = 0; index < 4; ++index)
    {
      this.Cstr_Skill_Lv[index] = StringManager.Instance.SpawnString();
      this.Cstr_Skill_Cost[index] = StringManager.Instance.SpawnString();
      this.Cstr_Skill_Info[index] = StringManager.Instance.SpawnString(100);
    }
    for (int index = 0; index < 6; ++index)
      this.Cstr_ShowEffect[index] = StringManager.Instance.SpawnString();
    this.Cstr_Hint = StringManager.Instance.SpawnString(300);
    this.Cstr_NextRS = StringManager.Instance.SpawnString();
    for (int index = 0; index < 3; ++index)
      this.Cstr_Property[index] = StringManager.Instance.SpawnString();
    for (int index = 0; index < 10; ++index)
      this.Cstr_ItemPropertyValue[index] = StringManager.Instance.SpawnString();
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.GameT = this.gameObject.transform;
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.TopText[0] = this.DM.mStringTable.GetStringByID(370U);
    this.TopText[1] = this.DM.mStringTable.GetStringByID(372U);
    if (!NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP))
    {
      uint num = this.DM.sortHeroData[(int) this.mOpenKind];
      if (this.mOpenType != (byte) 1)
      {
        DataManager.SortHeroData();
        if ((int) num == (int) this.DM.sortHeroData[(int) this.mOpenKind] && !this.GUIM.m_IsOpenedUISynthesis)
          this.GUIM.UIHero_Index = -1;
      }
      else
      {
        DataManager.SortConditionHeroData();
        if ((int) num == (int) this.DM.sortHeroData[(int) this.mOpenKind])
          this.GUIM.UIHero_Index = -1;
        else
          this.GUIM.UIPreviewHero_Index = -1;
      }
    }
    else
      this.GUIM.UIHero_Index = -1;
    this.mHeroEquip = 0;
    this.bEnchantments = false;
    this.bStarEvolution = false;
    this.mNowpage = !NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP) ? this.DM.Hero_Info_Page : 0;
    if (this.mOpenType != (byte) 1)
    {
      this.mSkillpage = this.mNowpage != 1 || !this.DM.Hero_Info_bHeroSkill ? 0 : 1;
      if (this.mNowpage == 2 && !this.DM.Hero_Info_bHeroInfo)
        this.bHeroInfo = false;
    }
    else
    {
      this.mNowpage = 1;
      this.mSkillpage = 1;
    }
    this.TmpChildCount = 0;
    this.SkillLimit[0] = 0;
    this.SkillLimit[1] = 0;
    this.SkillLimit[2] = 20;
    this.SkillLimit[3] = 40;
    this.StarValue[0] = 0.0f;
    this.StarValue[1] = 1f;
    this.StarValue[2] = 1.5f;
    this.StarValue[3] = 2f;
    this.StarValue[4] = 2.5f;
    this.StarValue[5] = 3f;
    this.TmpTime = 0.0f;
    this.HP = 0U;
    this.EquipEffect_HP = 0U;
    this.Power = 0U;
    this.mHeroAct[0] = "idle";
    this.mHeroAct[1] = "moving";
    this.mHeroAct[2] = "attack";
    this.mHeroAct[3] = "skill_1";
    this.mHeroAct[4] = "skill_2";
    this.mHeroAct[5] = "skill_3";
    this.mHeroAct[6] = "victory";
    this.Vec3Instance = Vector3.zero;
    this.TTFont = this.GUIM.GetTTFFont();
    this.FrameMaterial = this.GUIM.GetFrameMaterial();
    this.IconMaterial = this.GUIM.m_IconSpriteAsset.GetMaterial();
    this.SkillMaterial = this.GUIM.GetSkillMaterial();
    Image component = this.GameT.GetChild(0).GetComponent<Image>();
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) component).enabled = false;
    this.Tmp = this.GameT.GetChild(0).GetChild(0);
    this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 1;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.Tmp = this.GameT.GetChild(2);
    this.btnPage[0] = this.Tmp.GetComponent<UIButton>();
    this.btnPage[0].m_Handler = (IUIButtonClickHandler) this;
    this.btnPage[0].m_BtnID1 = 2;
    this.btnPage[0].SoundIndex = (byte) 3;
    this.Tmp2 = this.Tmp.GetChild(0);
    this.img_PageBG[0] = this.Tmp2.GetComponent<Image>();
    this.Tmp2 = this.Tmp.GetChild(1);
    this.img_Pageicon[0] = this.Tmp2.GetComponent<Image>();
    this.Tmp = this.GameT.GetChild(3);
    this.btnPage[1] = this.Tmp.GetComponent<UIButton>();
    this.btnPage[1].m_Handler = (IUIButtonClickHandler) this;
    this.btnPage[1].m_BtnID1 = 3;
    this.btnPage[1].SoundIndex = (byte) 3;
    this.Tmp2 = this.Tmp.GetChild(0);
    this.img_PageBG[1] = this.Tmp2.GetComponent<Image>();
    this.Tmp2 = this.Tmp.GetChild(1);
    this.img_Pageicon[1] = this.Tmp2.GetComponent<Image>();
    this.Tmp = this.GameT.GetChild(4);
    this.btnPage[2] = this.Tmp.GetComponent<UIButton>();
    this.btnPage[2].m_Handler = (IUIButtonClickHandler) this;
    this.btnPage[2].m_BtnID1 = 4;
    this.btnPage[2].SoundIndex = (byte) 3;
    this.Tmp2 = this.Tmp.GetChild(0);
    this.img_PageBG[2] = this.Tmp2.GetComponent<Image>();
    this.Tmp2 = this.Tmp.GetChild(1);
    this.img_Pageicon[2] = this.Tmp2.GetComponent<Image>();
    this.PageT = this.GameT.GetChild(5);
    this.Tmp = this.GameT.GetChild(6);
    this.Hero_3D = this.GameT.GetChild(7);
    this.Tmp = this.Hero_3D.GetChild(0);
    this.btn_HeroPowerHint = this.Tmp.GetComponent<UIButton>();
    this.btn_HeroPowerHint.m_Handler = (IUIButtonClickHandler) this;
    this.btn_HeroPowerHint.m_BtnID1 = 45;
    this.tmpbtnHint = ((Component) this.btn_HeroPowerHint).gameObject.AddComponent<UIButtonHint>();
    this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
    this.Tmp = this.Hero_3D.GetChild(0).GetChild(1);
    this.text_HeroPower = this.Tmp.GetComponent<UIText>();
    this.text_HeroPower.font = this.TTFont;
    this.text_HeroPower.text = this.DM.mStringTable.GetStringByID(11U);
    this.Tmp = this.Hero_3D.GetChild(1).GetChild(0);
    this.img_Lv = this.Tmp.GetComponent<Image>();
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
      this.img_Lv.sprite = this.SArray.m_Sprites[35];
    if (this.GUIM.IsArabic)
      ((Component) this.img_Lv).transform.localScale = new Vector3(-1f, ((Component) this.img_Lv).transform.localScale.y, ((Component) this.img_Lv).transform.localScale.z);
    this.Tmp = this.Hero_3D.GetChild(1).GetChild(1);
    this.text_Lv = this.Tmp.GetComponent<UIText>();
    this.text_Lv.font = this.TTFont;
    this.TmpChildCount = 2;
    this.Tmp = this.Hero_3D.GetChild(this.TmpChildCount);
    this.btn_Property = this.Tmp.GetComponent<UIButton>();
    this.btn_Property.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Property.m_BtnID1 = 38;
    this.tmpbtnHint = ((Component) this.btn_Property).gameObject.AddComponent<UIButtonHint>();
    this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
    this.Tmp1 = this.Tmp.GetChild(0);
    this.Property_Hint = this.Tmp1.GetComponent<Image>();
    this.Property_Hint.sprite = this.door.LoadSprite("UI_main_box_012");
    ((MaskableGraphic) this.Property_Hint).material = this.door.LoadMaterial();
    this.text_Hint[1] = this.Tmp1.GetChild(0).GetComponent<UIText>();
    this.text_Hint[1].font = this.TTFont;
    this.tmpbtnHint.ControlFadeOut = ((Component) this.Property_Hint).gameObject;
    this.Tmp = this.Hero_3D.GetChild(this.TmpChildCount + 1).GetChild(0);
    this.img_HeroExp = this.Tmp.GetComponent<Image>();
    this.mExpLength = this.Tmp.GetComponent<RectTransform>().sizeDelta.x;
    this.Tmp = this.Hero_3D.GetChild(this.TmpChildCount + 1).GetChild(1);
    this.text_HeroEXP = this.Tmp.GetComponent<UIText>();
    this.text_HeroEXP.font = this.TTFont;
    this.Tmp = this.Hero_3D.GetChild(this.TmpChildCount + 2).GetChild(0);
    this.text_HeroTitle = this.Tmp.GetComponent<UIText>();
    this.text_HeroTitle.font = this.TTFont;
    this.Tmp = this.Hero_3D.GetChild(this.TmpChildCount + 2).GetChild(1);
    this.text_HeroName = this.Tmp.GetComponent<UIText>();
    this.text_HeroName.font = this.TTFont;
    this.Tmp = this.Hero_3D.GetChild(this.TmpChildCount + 3);
    this.btn_Fragment = this.Tmp.GetComponent<UIButton>();
    this.btn_Fragment.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Fragment.m_BtnID1 = 39;
    this.tmpbtnHint = ((Component) this.btn_Fragment).gameObject.AddComponent<UIButtonHint>();
    this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
    this.Tmp1 = this.Tmp.GetChild(0);
    this.Fragment_Hint = this.Tmp1.GetComponent<Image>();
    this.Fragment_Hint.sprite = this.door.LoadSprite("UI_main_box_012");
    ((MaskableGraphic) this.Fragment_Hint).material = this.door.LoadMaterial();
    this.text_Hint[0] = this.Tmp1.GetChild(0).GetComponent<UIText>();
    this.text_Hint[0].font = this.TTFont;
    this.tmpbtnHint.ControlFadeOut = ((Component) this.Fragment_Hint).gameObject;
    this.Hero_Pos = this.GameT.GetChild(8);
    this.Hero_PosRT = this.Hero_Pos.GetComponent<RectTransform>();
    float x = ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x;
    this.tempL = (float) (((double) ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x - 853.0) / 2.0);
    this.btn_NextT = this.GameT.GetChild(9);
    this.btn_Next = this.btn_NextT.GetComponent<UIButton>();
    this.btn_Next.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Next.m_BtnID1 = 19;
    this.btn_Next.SoundIndex = (byte) 1;
    this.btn_Next.m_EffectType = e_EffectType.e_Scale;
    this.btn_Next.transition = (Selectable.Transition) 0;
    if ((double) this.tempL > 0.0 && (double) this.btn_NextT.localPosition.x + (double) this.tempL > (double) x / 2.0)
      this.tempL = x / 2f - this.btn_NextT.localPosition.x;
    this.MoveTime1 = this.btn_NextT.localPosition.x + this.tempL;
    if (this.GUIM.bOpenOnIPhoneX)
      this.MoveTime1 -= this.GUIM.IPhoneX_DeltaX;
    this.btn_BackT = this.GameT.GetChild(10);
    this.btn_Back = this.btn_BackT.GetComponent<UIButton>();
    this.btn_Back.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Back.m_BtnID1 = 20;
    this.btn_Back.SoundIndex = (byte) 1;
    this.btn_Back.m_EffectType = e_EffectType.e_Scale;
    this.btn_Back.transition = (Selectable.Transition) 0;
    this.MoveTime2 = this.btn_BackT.localPosition.x - this.tempL;
    if (this.GUIM.bOpenOnIPhoneX)
      this.MoveTime2 += this.GUIM.IPhoneX_DeltaX;
    if (this.mOpenType == (byte) 1 && this.mOpenKind == (byte) 0)
    {
      ((Component) this.btn_Next).gameObject.SetActive(false);
      ((Component) this.btn_Back).gameObject.SetActive(false);
      this.OpenUISynthesis = false;
    }
    else
    {
      ((Component) this.btn_Next).gameObject.SetActive(true);
      ((Component) this.btn_Back).gameObject.SetActive(true);
    }
    this.Tmp = this.GameT.GetChild(11);
    this.btn_HeroAction = this.Tmp.GetComponent<UIButton>();
    this.btn_HeroAction.m_Handler = (IUIButtonClickHandler) this;
    this.btn_HeroAction.m_BtnID1 = 21;
    this.btn_HeroAction.m_BtnID2 = 30006;
    this.btn_HeroActionD = this.Tmp.gameObject.AddComponent<UIBtnDrag>();
    this.btn_HeroActionD.mHero = this.Hero_PosRT;
    this.img_HeroState = this.Tmp.GetChild(0).GetComponent<Image>();
    ((Graphic) this.img_HeroState).rectTransform.anchoredPosition3D = new Vector3(((Graphic) this.img_HeroState).rectTransform.anchoredPosition3D.x, ((Graphic) this.img_HeroState).rectTransform.anchoredPosition3D.y, -1000f);
    this.btn_HeroState = this.Tmp.GetChild(0).GetComponent<UIButton>();
    this.btn_HeroState.m_Handler = (IUIButtonClickHandler) this;
    this.btn_HeroState.m_BtnID1 = 44;
    this.tmpbtnHint = ((Component) this.btn_HeroState).gameObject.AddComponent<UIButtonHint>();
    this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
    this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
    this.HeroState_Hint = this.Tmp1.GetComponent<Image>();
    this.HeroState_Hint.sprite = this.door.LoadSprite("UI_main_box_012");
    ((MaskableGraphic) this.HeroState_Hint).material = this.door.LoadMaterial();
    ((Graphic) this.HeroState_Hint).rectTransform.anchoredPosition3D = new Vector3(((Graphic) this.HeroState_Hint).rectTransform.anchoredPosition3D.x, ((Graphic) this.HeroState_Hint).rectTransform.anchoredPosition3D.y, 0.0f);
    this.text_HeroStateHint = this.Tmp1.GetChild(0).GetComponent<UIText>();
    this.text_HeroStateHint.font = this.TTFont;
    this.text_HeroStateHint.text = string.Empty;
    this.tmpbtnHint.ControlFadeOut = ((Component) this.Fragment_Hint).gameObject;
    this.Tmp = this.GameT.GetChild(12);
    this.btn_Rank_Exit = this.Tmp.GetComponent<UIButton>();
    this.btn_Rank_Exit.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Rank_Exit.m_BtnID1 = 28;
    this.btn_Rank_Exit.image.sprite = this.door.LoadSprite("UI_main_black");
    ((MaskableGraphic) this.btn_Rank_Exit.image).material = this.door.LoadMaterial();
    if (this.GUIM.bOpenOnIPhoneX)
    {
      this.Tmp.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
      this.Tmp.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    this.Tmp1 = this.Tmp.GetChild(0).GetChild(0).GetChild(0);
    this.text_NextRankTiTle = this.Tmp1.GetComponent<UIText>();
    this.text_NextRankTiTle.font = this.TTFont;
    this.text_NextRankTiTle.text = this.DM.mStringTable.GetStringByID(365U);
    this.Tmp1 = this.Tmp.GetChild(1).GetChild(0);
    this.text_NextRank = this.Tmp1.GetComponent<UIText>();
    this.text_NextRank.font = this.TTFont;
    this.Rank_ImgT = this.Tmp.GetChild(2);
    this.Tmp1 = this.Tmp.GetChild(3);
    this.imgRank_Rank = this.Tmp1.GetComponent<Image>();
    for (int index = 0; index < 6; ++index)
    {
      this.Tmp1 = this.Tmp.GetChild(10 + index);
      this.btn_RankEquip[index] = this.Tmp1.GetComponent<UIHIBtn>();
      this.btn_RankEquip[index].m_Handler = (IUIHIBtnClickHandler) this;
      this.btn_RankEquip[index].m_BtnID1 = 22 + index;
      ((MaskableGraphic) this.btn_RankEquip[index].image).material = this.IconMaterial;
      this.GUIM.InitianHeroItemImg(((Component) this.btn_RankEquip[index]).transform, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0);
    }
    this.text_Next_RankSoldier = this.Tmp.GetChild(16).GetComponent<UIText>();
    this.text_Next_RankSoldier.font = this.TTFont;
    this.Tmp = this.GameT.GetChild(13).GetChild(0);
    this.PropertyInfo_Hint = this.Tmp.GetComponent<Image>();
    this.PropertyInfo_Hint.sprite = this.door.LoadSprite("UI_main_box_012");
    ((MaskableGraphic) this.PropertyInfo_Hint).material = this.door.LoadMaterial();
    this.PropertyInfo_HintRT[0] = this.Tmp.GetComponent<RectTransform>();
    this.text_Hint[2] = this.Tmp.GetChild(0).GetComponent<UIText>();
    this.text_Hint[2].font = this.TTFont;
    this.PropertyInfo_HintRT[1] = this.Tmp.GetChild(0).GetComponent<RectTransform>();
    this.Tmp = this.GameT.GetChild(13).GetChild(1);
    this.HeroPower_Hint = this.Tmp.GetComponent<Image>();
    this.Tmp = this.GameT.GetChild(13).GetChild(1).GetChild(0);
    this.text_HeroPowerHint = this.Tmp.GetComponent<UIText>();
    this.text_HeroPowerHint.font = this.TTFont;
    this.text_HeroPowerHint.text = this.DM.mStringTable.GetStringByID(19U);
    ((Graphic) this.text_HeroPowerHint).rectTransform.sizeDelta = new Vector2(303f, ((Graphic) this.text_HeroPowerHint).rectTransform.sizeDelta.y);
    ((Graphic) this.HeroPower_Hint).rectTransform.sizeDelta = new Vector2(323f, ((Graphic) this.HeroPower_Hint).rectTransform.sizeDelta.y);
    this.text_HeroPowerHint.SetAllDirty();
    this.text_HeroPowerHint.cachedTextGenerator.Invalidate();
    this.text_HeroPowerHint.cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_HeroPowerHint.preferredWidth > 303.0)
    {
      ((Graphic) this.text_HeroPowerHint).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_HeroPowerHint).rectTransform.sizeDelta.x, this.text_HeroPowerHint.preferredHeight + 1f);
      ((Graphic) this.HeroPower_Hint).rectTransform.sizeDelta = new Vector2(((Graphic) this.HeroPower_Hint).rectTransform.sizeDelta.x, this.text_HeroPowerHint.preferredHeight + 5f);
    }
    ((Component) this.btn_HeroPowerHint).GetComponent<UIButtonHint>().ControlFadeOut = ((Component) this.HeroPower_Hint).gameObject;
    for (int index = 0; index < 6; ++index)
    {
      this.text_ShowEffect[index] = this.GameT.GetChild(13).GetChild(2 + index).GetComponent<UIText>();
      this.text_ShowEffect[index].font = this.TTFont;
    }
    this.Tmp = this.GameT.GetChild(14);
    this.img_PreviewBG = this.Tmp.GetComponent<Image>();
    this.Tmp = this.GameT.GetChild(14).GetChild(0);
    this.text_PreviewHero = this.Tmp.GetComponent<UIText>();
    this.text_PreviewHero.font = this.TTFont;
    if (this.mOpenType == (byte) 1)
    {
      this.text_PreviewHero.text = this.mOpenKind != (byte) 0 ? this.DM.mStringTable.GetStringByID(10045U) : this.DM.mStringTable.GetStringByID(10046U);
      ((Component) this.img_PreviewBG).gameObject.SetActive(true);
      this.Hero_3D.GetChild(this.TmpChildCount + 1).gameObject.SetActive(false);
      ((Component) this.btn_HeroPowerHint).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.img_PreviewBG).gameObject.SetActive(false);
      this.Hero_3D.GetChild(this.TmpChildCount + 1).gameObject.SetActive(true);
      ((Component) this.btn_HeroPowerHint).gameObject.SetActive(true);
    }
    this.SetHeroData((int) this.mOpenKind);
    NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, (object) this);
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void LoadPage(int nowpage)
  {
    if (nowpage == 0)
    {
      this.go = (GameObject) UnityEngine.Object.Instantiate(this.m_AssetBundle.Load("Page1data"));
      this.Pagedata[0] = this.go.GetComponent<Transform>();
      this.Pagedata[0].SetParent(this.PageT, false);
      this.TmpChildCount = 0;
      this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount);
      this.btn_EquipStratum = this.Tmp.GetComponent<UIButton>();
      this.btn_EquipStratum.m_Handler = (IUIButtonClickHandler) this;
      this.btn_EquipStratum.m_BtnID1 = 12;
      this.btn_EquipStratum.m_EffectType = e_EffectType.e_Scale;
      this.btn_EquipStratum.transition = (Selectable.Transition) 0;
      this.btn_NextRankRT = this.Tmp.GetComponent<RectTransform>();
      this.text_tmpStr[0] = this.Pagedata[0].GetChild(this.TmpChildCount + 1).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[0].font = this.TTFont;
      this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7U);
      this.TmpChildCount += 2;
      for (int index = 0; index < 6; ++index)
      {
        this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount + index);
        this.Img_EquipRT[index] = this.Tmp.GetComponent<RectTransform>();
      }
      this.TmpChildCount += 6;
      this.Equip_ImgT = this.Pagedata[0].GetChild(this.TmpChildCount);
      this.RankLightBG = this.Equip_ImgT.GetComponent<Image>();
      ++this.TmpChildCount;
      this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount);
      this.Tmp1 = this.Tmp.GetChild(2).GetChild(0);
      this.text_Medal = this.Tmp1.GetComponent<UIText>();
      this.text_Medal.font = this.TTFont;
      this.text_Medal.text = this.DM.mStringTable.GetStringByID(8U);
      this.Star_ImgT = this.Tmp.GetChild(3);
      this.StarStratumLightBG = this.Star_ImgT.GetComponent<Image>();
      this.Img_StarStratumLightRT = this.Star_ImgT.GetComponent<RectTransform>();
      this.Tmp1 = this.Tmp.GetChild(4);
      this.btn_DETAIL = this.Tmp1.GetComponent<UIButton>();
      this.btn_DETAIL.m_Handler = (IUIButtonClickHandler) this;
      this.btn_DETAIL.m_BtnID1 = 14;
      this.btn_DETAIL.m_EffectType = e_EffectType.e_Scale;
      this.btn_DETAIL.transition = (Selectable.Transition) 0;
      if (this.mOpenType == (byte) 1)
        ((Component) this.btn_DETAIL).gameObject.SetActive(false);
      else
        ((Component) this.btn_DETAIL).gameObject.SetActive(true);
      this.btn_StarDetailRT = this.Tmp1.GetComponent<RectTransform>();
      this.Tmp1 = this.Tmp.GetChild(5);
      this.btn_StarEvolution = this.Tmp1.GetComponent<UIButton>();
      this.btn_StarEvolution.m_Handler = (IUIButtonClickHandler) this;
      this.btn_StarEvolution.m_BtnID1 = 13;
      this.btn_StarEvolutionRT = this.Tmp1.GetComponent<RectTransform>();
      this.btn_StarEvolution.m_EffectType = e_EffectType.e_Scale;
      this.btn_StarEvolution.transition = (Selectable.Transition) 0;
      this.uToolStar = this.Tmp1.GetComponent<uTweenScale>();
      this.uToolStar.enabled = false;
      this.Img_StarEvolution = this.Tmp1.GetChild(0).GetComponent<Image>();
      this.text_HeroStarLv = this.Tmp1.GetChild(1).GetComponent<UIText>();
      this.text_HeroStarLv.font = this.TTFont;
      this.text_HeroStarLv.text = this.DM.mStringTable.GetStringByID(21U);
      this.StarLightT = this.Tmp.GetChild(6);
      this.mParticleStar = ParticleManager.Instance.Spawn((ushort) 7, this.StarLightT, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
      this.GUIM.SetLayer(this.mParticleStar, 5);
      this.StarLightT.gameObject.SetActive(false);
      this.mParticleStar.transform.localEulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      this.Tmp1 = this.Tmp.GetChild(7);
      this.timeBarStar = this.Tmp1.GetComponent<UITimeBar>();
      this.GUIM.CreateTimerBar(this.timeBarStar, 0L, 0L, 0L, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(408U), this.DM.mStringTable.GetStringByID((uint) this.sHero.HeroTitle));
      this.GUIM.SetTimerSpriteType(this.timeBarStar, eTimerSpriteType.Speed);
      this.timeBarStar.m_Handler = (IUTimeBarOnTimer) this;
      this.timeBarStar.m_TimeBarID = 2;
      this.text_timeBarStar[0] = this.Tmp1.GetChild(2).GetComponent<UIText>();
      this.text_timeBarStar[1] = this.Tmp1.GetChild(3).GetComponent<UIText>();
      this.Tmp1 = this.Tmp.GetChild(8);
      this.StarEvolutionRT = this.Tmp1.GetComponent<RectTransform>();
      this.CheckStarTimeBar();
      ++this.TmpChildCount;
      this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount);
      this.btn_Evolution = this.Tmp.GetComponent<UIButton>();
      this.btn_Evolution.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Evolution.m_BtnID1 = 5;
      this.btn_EvolutionRT = this.Tmp.GetComponent<RectTransform>();
      this.btn_Evolution.m_EffectType = e_EffectType.e_Scale;
      this.btn_Evolution.transition = (Selectable.Transition) 0;
      this.uToolRank = this.Tmp.GetComponent<uTweenScale>();
      this.uToolRank.enabled = false;
      this.Tmp1 = this.Tmp.GetChild(1);
      this.text_Rank = this.Tmp1.GetComponent<UIText>();
      this.text_Rank.font = this.TTFont;
      this.mParticleRank = ParticleManager.Instance.Spawn((ushort) 6, this.Tmp, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
      this.GUIM.SetLayer(this.mParticleRank, 5);
      this.RankLightT = this.mParticleRank.transform;
      this.RankLightT.gameObject.SetActive(false);
      ++this.TmpChildCount;
      this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount);
      this.Img_EvolutionUp = this.Tmp.GetComponent<Image>();
      this.Img_EvolutionUpRT = this.Tmp.GetComponent<RectTransform>();
      this.EvolutionRT = this.Tmp.GetChild(0).GetComponent<RectTransform>();
      ++this.TmpChildCount;
      this.uToolRankPos = this.Pagedata[0].GetChild(this.TmpChildCount).GetComponent<uTweenPosition>();
      this.uTool_RankPosRT = this.Pagedata[0].GetChild(this.TmpChildCount).GetComponent<RectTransform>();
      ++this.TmpChildCount;
      this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount);
      this.timeBarRank = this.Tmp.GetComponent<UITimeBar>();
      this.Cstr_RankTimeBar.ClearString();
      this.Cstr_RankTimeBar.IntToFormat((long) ((int) this.mHeroData.Enhance + 1));
      this.Cstr_RankTimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(409U));
      this.GUIM.CreateTimerBar(this.timeBarRank, 0L, 0L, 0L, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(407U), this.Cstr_RankTimeBar.ToString());
      this.GUIM.SetTimerSpriteType(this.timeBarRank, eTimerSpriteType.Speed);
      this.timeBarRank.m_Handler = (IUTimeBarOnTimer) this;
      this.timeBarRank.m_TimeBarID = 1;
      this.text_timeBarRank[0] = this.Tmp.GetChild(2).GetComponent<UIText>();
      this.text_timeBarRank[1] = this.Tmp.GetChild(3).GetComponent<UIText>();
      ++this.TmpChildCount;
      for (int index = 0; index < 6; ++index)
      {
        this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount + index);
        this.btn_Equip[index] = this.Tmp.GetComponent<UIHIBtn>();
        this.btn_Equip[index].m_Handler = (IUIHIBtnClickHandler) this;
        this.btn_Equip[index].m_BtnID1 = 6 + index;
        ((MaskableGraphic) this.btn_Equip[index].image).material = this.IconMaterial;
        this.btn_EquipRT[index] = this.Tmp.GetComponent<RectTransform>();
        this.GUIM.InitianHeroItemImg(((Component) this.btn_Equip[index]).transform, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false, bScaleBtn: true);
        this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount + index + 6);
        this.img_EquipHave_Light[index] = this.Tmp.GetComponent<Image>();
        this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount + index + 12);
        this.img_EquipLight[index] = this.Tmp.GetComponent<Image>();
        this.Img_EquipLightRT[index] = this.Tmp.GetComponent<RectTransform>();
        this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount + index + 18);
        this.img_EquipHave[index] = this.Tmp.GetComponent<Image>();
        this.Img_HaveRT[index] = this.Tmp.GetComponent<RectTransform>();
        this.Tmp = this.Pagedata[0].GetChild(this.TmpChildCount + index + 24);
        this.text_Equip[index] = this.Tmp.GetComponent<UIText>();
        this.text_Equip[index].font = this.TTFont;
        this.text_RT[index] = this.Tmp.GetComponent<RectTransform>();
      }
      this.CheckRankTimeBar();
      if (this.OpenPage == (byte) 0)
      {
        this.SetStratum(this.mHeroStratum);
        this.ReSetBtnState();
        if (this.mHeroData.Star < (byte) 5)
          this.MaxStar = (float) this.DM.Medal[(int) this.mHeroData.Star];
        this.SetStarStratum((int) this.DM.GetCurItemQuantity(this.sHero.SoulStone, (byte) 0), (int) this.mHeroData.Star);
      }
    }
    if (nowpage == 1)
    {
      this.go = (GameObject) UnityEngine.Object.Instantiate(this.m_AssetBundle.Load("Page2data"));
      this.go.transform.SetParent(this.PageT, false);
      this.Pagedata[1] = this.go.GetComponent<Transform>();
      this.TmpChildCount = 0;
      this.btn_SkillPage[0] = this.Pagedata[1].GetChild(1).GetComponent<UIButton>();
      this.btn_SkillPage[0].m_Handler = (IUIButtonClickHandler) this;
      this.btn_SkillPage[0].m_BtnID1 = 32;
      this.img_SkillPage[0] = this.Pagedata[1].GetChild(1).GetChild(0).GetComponent<Image>();
      this.text_SkillPage[0] = this.Pagedata[1].GetChild(1).GetChild(1).GetComponent<UIText>();
      this.text_SkillPage[0].font = this.TTFont;
      this.text_SkillPage[0].text = this.DM.mStringTable.GetStringByID(369U);
      this.btn_SkillPage[1] = this.Pagedata[1].GetChild(2).GetComponent<UIButton>();
      this.btn_SkillPage[1].m_Handler = (IUIButtonClickHandler) this;
      this.btn_SkillPage[1].m_BtnID1 = 33;
      this.img_SkillPage[1] = this.Pagedata[1].GetChild(2).GetChild(0).GetComponent<Image>();
      this.text_SkillPage[1] = this.Pagedata[1].GetChild(2).GetChild(1).GetComponent<UIText>();
      this.text_SkillPage[1].font = this.TTFont;
      this.text_SkillPage[1].text = this.DM.mStringTable.GetStringByID(33U);
      this.SkillPageT[0] = this.Pagedata[1].GetChild(3);
      this.Tmp = this.SkillPageT[0].GetChild(0);
      this.Tmp1 = this.Tmp.GetChild(2).GetChild(0);
      this.text_tmpStr[1] = this.Tmp1.GetComponent<UIText>();
      this.text_tmpStr[1].font = this.TTFont;
      this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(364U);
      this.Tmp1 = this.Tmp.GetChild(3);
      this.text_tmpStr[2] = this.Tmp1.GetChild(1).GetComponent<UIText>();
      this.text_tmpStr[2].font = this.TTFont;
      this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(343U);
      this.Tmp2 = this.Tmp1.GetChild(2);
      this.text_Leader[0] = this.Tmp2.GetComponent<UIText>();
      this.text_Leader[0].font = this.TTFont;
      this.Tmp1 = this.Tmp.GetChild(4);
      this.text_tmpStr[3] = this.Tmp1.GetChild(1).GetComponent<UIText>();
      this.text_tmpStr[3].font = this.TTFont;
      this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(367U);
      this.Tmp2 = this.Tmp1.GetChild(2);
      this.text_Leader[1] = this.Tmp2.GetComponent<UIText>();
      this.text_Leader[1].font = this.TTFont;
      for (int index = 0; index < 8; ++index)
      {
        this.Tmp = this.SkillPageT[0].GetChild(1).GetChild(index);
        this.text_Skill2_[index] = this.Tmp.GetComponent<UIText>();
        this.text_Skill2_[index].font = this.TTFont;
      }
      for (int index = 0; index < 4; ++index)
      {
        this.Tmp = this.SkillPageT[0].GetChild(4 + index);
        this.btn_Skill[index + 4] = this.Tmp.GetComponent<UIButton>();
        this.btn_Skill[index + 4].m_Handler = (IUIButtonClickHandler) this;
        this.btn_Skill[index + 4].image.sprite = this.GUIM.LoadFrameSprite("sk");
        ((MaskableGraphic) this.btn_Skill[index + 4].image).material = this.FrameMaterial;
        this.Tmp1 = this.Tmp.GetChild(2);
        this.tmpbtn = this.Tmp1.GetComponent<UIButton>();
        this.tmpbtn.m_Handler = (IUIButtonClickHandler) this;
        this.tmpbtn.m_BtnID1 = 34 + index;
        this.tmpbtnHint = this.Tmp1.gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.ControlFadeOut = ((Component) this.GUIM.m_SkillInfo.m_RectTransform).gameObject;
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.img_Skill[index + 4] = this.Tmp.GetChild(0).GetComponent<Image>();
        ((MaskableGraphic) this.img_Skill[index + 4]).material = this.SkillMaterial;
        this.tmpRC = this.Tmp.GetChild(0).GetComponent<RectTransform>();
        this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
        this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
        this.tmpRC.offsetMin = Vector2.zero;
        this.tmpRC.offsetMax = Vector2.zero;
        this.Tmp = this.SkillPageT[0].GetChild(4 + index).GetChild(1);
        this.img_SkillFrame[index + 4] = this.Tmp.GetComponent<Image>();
        this.img_SkillFrame[index + 4].sprite = this.GUIM.LoadFrameSprite("sk");
        ((MaskableGraphic) this.img_SkillFrame[index + 4]).material = this.FrameMaterial;
        this.tmpRC = this.Tmp.GetComponent<RectTransform>();
        this.tmpRC.anchorMin = Vector2.zero;
        this.tmpRC.anchorMax = new Vector2(1f, 1f);
        this.tmpRC.offsetMin = Vector2.zero;
        this.tmpRC.offsetMax = Vector2.zero;
      }
      for (int index = 0; index < 3; ++index)
      {
        this.Tmp = this.SkillPageT[0].GetChild(8 + index);
        this.img_Lock[index + 3] = this.Tmp.GetComponent<Image>();
      }
      this.Cstr_Leader.ClearString();
      this.Cstr_Leader.IntToFormat((long) this.DM.RankSoldiers[(int) this.mHeroData.Enhance]);
      if (this.GUIM.IsArabic)
        this.Cstr_Leader.AppendFormat("{0}+");
      else
        this.Cstr_Leader.AppendFormat("+{0}");
      this.text_Leader[0].text = this.Cstr_Leader.ToString();
      this.text_Leader[0].SetAllDirty();
      this.text_Leader[0].cachedTextGenerator.Invalidate();
      this.text_Leader[1].text = this.DM.mStringTable.GetStringByID(3841U + (uint) this.sHero.SoldierKind);
      this.SkillPageT[1] = this.Pagedata[1].GetChild(4);
      this.Tmp = this.SkillPageT[1].GetChild(0);
      this.Skill_ImgT = this.Tmp.GetChild(0);
      this.Tmp1 = this.Tmp.GetChild(2).GetChild(0);
      this.text_Skill_Lv[0] = this.Tmp1.GetComponent<UIText>();
      this.text_Skill_Lv[0].font = this.TTFont;
      this.Tmp1 = this.Tmp.GetChild(3);
      this.text_Skill_Name = this.Tmp1.GetComponent<UIText>();
      this.text_Skill_Name.font = this.TTFont;
      this.Tmp = this.SkillPageT[1].GetChild(1);
      this.img_SkillBook[0] = this.Tmp.GetComponent<Image>();
      this.Tmp1 = this.Tmp.GetChild(0);
      this.img_Skill_Lv[0] = this.Tmp1.GetComponent<Image>();
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
      this.text_Skill_Lv[1] = this.Tmp1.GetComponent<UIText>();
      this.text_Skill_Lv[1].font = this.TTFont;
      this.Tmp = this.SkillPageT[1].GetChild(2);
      this.img_SkillBook[1] = this.Tmp.GetComponent<Image>();
      this.Tmp1 = this.Tmp.GetChild(0);
      this.img_Skill_Lv[1] = this.Tmp1.GetComponent<Image>();
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
      this.text_Skill_Lv[2] = this.Tmp1.GetComponent<UIText>();
      this.text_Skill_Lv[2].font = this.TTFont;
      this.Tmp = this.SkillPageT[1].GetChild(3);
      this.img_SkillBook[2] = this.Tmp.GetComponent<Image>();
      this.Tmp1 = this.Tmp.GetChild(0);
      this.img_Skill_Lv[2] = this.Tmp1.GetComponent<Image>();
      this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
      this.text_Skill_Lv[3] = this.Tmp1.GetComponent<UIText>();
      this.text_Skill_Lv[3].font = this.TTFont;
      for (int index = 0; index < 4; ++index)
      {
        this.Tmp = this.SkillPageT[1].GetChild(4 + index);
        this.btn_Skill[index] = this.Tmp.GetComponent<UIButton>();
        this.tmpbtnHint = ((Component) this.btn_Skill[index]).gameObject.AddComponent<UIButtonHint>();
        this.tmpbtnHint.ControlFadeOut = ((Component) this.GUIM.m_SkillInfo.m_RectTransform).gameObject;
        this.btn_Skill[index].m_Handler = (IUIButtonClickHandler) this;
        this.btn_Skill[index].m_BtnID1 = 15 + index;
        this.btn_Skill[index].image.sprite = this.GUIM.LoadFrameSprite("sk");
        ((MaskableGraphic) this.btn_Skill[index].image).material = this.FrameMaterial;
        this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
        this.img_Skill[index] = this.Tmp.GetChild(0).GetComponent<Image>();
        ((MaskableGraphic) this.img_Skill[index]).material = this.SkillMaterial;
        this.tmpRC = this.Tmp.GetChild(0).GetComponent<RectTransform>();
        this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
        this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
        this.tmpRC.offsetMin = Vector2.zero;
        this.tmpRC.offsetMax = Vector2.zero;
        this.Tmp = this.SkillPageT[1].GetChild(4 + index).GetChild(1);
        this.img_SkillFrame[index] = this.Tmp.GetComponent<Image>();
        this.img_SkillFrame[index].sprite = this.GUIM.LoadFrameSprite("sk");
        ((MaskableGraphic) this.img_SkillFrame[index]).material = this.FrameMaterial;
        this.tmpRC = this.Tmp.GetComponent<RectTransform>();
        this.tmpRC.anchorMin = Vector2.zero;
        this.tmpRC.anchorMax = new Vector2(1f, 1f);
        this.tmpRC.offsetMin = Vector2.zero;
        this.tmpRC.offsetMax = Vector2.zero;
      }
      for (int index = 0; index < 3; ++index)
      {
        this.Tmp = this.SkillPageT[1].GetChild(8 + index);
        this.img_Lock[index] = this.Tmp.GetComponent<Image>();
        this.Tmp1 = this.Tmp.GetChild(0);
        this.text_Skill_Lock[index] = this.Tmp1.GetComponent<UIText>();
        this.text_Skill_Lock[index].font = this.TTFont;
        this.text_Skill_Lock[index].text = this.DM.mStringTable.GetStringByID((uint) (26 + index));
      }
      if (this.OpenPage == (byte) 0)
      {
        this.ReSetSkill();
        if (this.mOpenType == (byte) 1)
          this.SetSkillPage(true);
        else
          this.SetSkillPage(this.DM.Hero_Info_bHeroSkill);
        Array.Clear((Array) this.SendSkillLv, 0, this.SendSkillLv.Length);
      }
    }
    if (nowpage != 2)
      return;
    this.go = (GameObject) UnityEngine.Object.Instantiate(this.m_AssetBundle.Load("Page3data"));
    this.go.transform.SetParent(this.PageT, false);
    this.Pagedata[2] = this.go.GetComponent<Transform>();
    this.Tmp = this.Pagedata[2].GetChild(0);
    this.btn_P3Info = this.Tmp.GetChild(0).GetComponent<UIButton>();
    this.btn_P3Info.m_Handler = (IUIButtonClickHandler) this;
    this.btn_P3Info.m_BtnID1 = 31;
    this.btn_P3Info.m_EffectType = e_EffectType.e_Scale;
    this.btn_P3Info.transition = (Selectable.Transition) 0;
    this.text_P3Title = this.Tmp.GetChild(1).GetComponent<UIText>();
    this.text_P3Title.font = this.TTFont;
    this.text_P3Title.text = this.TopText[0];
    this.P3_p1 = this.Pagedata[2].GetChild(1);
    this.P3_p2 = this.Pagedata[2].GetChild(2);
    this.P3_p2.gameObject.SetActive(false);
    this.Tmp = this.P3_p1.GetChild(0).GetChild(0);
    this.text_tmpStr[4] = this.Tmp.GetComponent<UIText>();
    this.text_tmpStr[4].font = this.TTFont;
    this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(373U);
    this.Tmp = this.P3_p1.GetChild(1).GetChild(0);
    this.text_tmpStr[5] = this.Tmp.GetComponent<UIText>();
    this.text_tmpStr[5].font = this.TTFont;
    this.text_tmpStr[5].text = this.DM.mStringTable.GetStringByID(374U);
    for (int index = 0; index < 3; ++index)
    {
      this.btn_P3_Property[index] = this.P3_p1.GetChild(2 + index).GetComponent<UIButton>();
      this.btn_P3_Property[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_P3_Property[index].m_BtnID1 = 40 + index;
      this.tmpbtnHint = ((Component) this.btn_P3_Property[index]).gameObject.AddComponent<UIButtonHint>();
      this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
      this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
      this.tmpbtnHint.ControlFadeOut = ((Component) this.PropertyInfo_Hint).gameObject;
    }
    this.Tmp = this.P3_p1.GetChild(2).GetChild(1);
    this.text_tmpStr[6] = this.Tmp.GetComponent<UIText>();
    this.text_tmpStr[6].font = this.TTFont;
    this.text_tmpStr[6].text = this.DM.mStringTable.GetStringByID(122U);
    this.Tmp = this.P3_p1.GetChild(2).GetChild(2);
    this.text_Property[0] = this.Tmp.GetComponent<UIText>();
    this.text_Property[0].font = this.TTFont;
    this.Tmp = this.P3_p1.GetChild(2).GetChild(3);
    this.text_Property[1] = this.Tmp.GetComponent<UIText>();
    this.text_Property[1].font = this.TTFont;
    this.Tmp = this.P3_p1.GetChild(3).GetChild(1);
    this.text_tmpStr[7] = this.Tmp.GetComponent<UIText>();
    this.text_tmpStr[7].font = this.TTFont;
    this.text_tmpStr[7].text = this.DM.mStringTable.GetStringByID(123U);
    this.Tmp = this.P3_p1.GetChild(3).GetChild(2);
    this.text_Property[2] = this.Tmp.GetComponent<UIText>();
    this.text_Property[2].font = this.TTFont;
    this.Tmp = this.P3_p1.GetChild(3).GetChild(3);
    this.text_Property[3] = this.Tmp.GetComponent<UIText>();
    this.text_Property[3].font = this.TTFont;
    this.Tmp = this.P3_p1.GetChild(4).GetChild(1);
    this.text_tmpStr[8] = this.Tmp.GetComponent<UIText>();
    this.text_tmpStr[8].font = this.TTFont;
    this.text_tmpStr[8].text = this.DM.mStringTable.GetStringByID(124U);
    this.Tmp = this.P3_p1.GetChild(4).GetChild(2);
    this.text_Property[4] = this.Tmp.GetComponent<UIText>();
    this.text_Property[4].font = this.TTFont;
    this.Tmp = this.P3_p1.GetChild(4).GetChild(3);
    this.text_Property[5] = this.Tmp.GetComponent<UIText>();
    this.text_Property[5].font = this.TTFont;
    this.Tmp = this.P3_p1.GetChild(5).GetChild(0).GetChild(0);
    this.text_tmpStr[9] = this.Tmp.GetComponent<UIText>();
    this.text_tmpStr[9].font = this.TTFont;
    this.text_tmpStr[9].text = this.DM.mStringTable.GetStringByID(371U);
    this.m_Mask = this.P3_p1.GetChild(5).GetChild(1).GetComponent<ScrollRect>();
    this.Tmp = this.P3_p1.GetChild(5).GetChild(1).GetChild(0);
    this.ContentRT = this.Tmp.GetComponent<RectTransform>();
    this.Tmp1 = this.Tmp.GetChild(0);
    this.text_HeroInfo = this.Tmp1.GetComponent<UIText>();
    this.text_HeroInfo.font = this.TTFont;
    this.Tmp = this.P3_p2.GetChild(0);
    this.m_itemView = this.Tmp.GetComponent<ScrollPanel>();
    this.Tmp = this.P3_p2.GetChild(1).GetChild(0).GetChild(0);
    this.tmptext = this.Tmp.GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.Tmp = this.P3_p2.GetChild(1).GetChild(1).GetChild(0);
    this.tmptext = this.Tmp.GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmpbtn = this.P3_p2.GetChild(1).GetChild(3).GetComponent<UIButton>();
    this.tmpbtn.m_Handler = (IUIButtonClickHandler) this;
    this.tmpbtn.m_BtnID1 = 0;
    this.tmpbtnHint = ((Component) this.tmpbtn).gameObject.AddComponent<UIButtonHint>();
    this.tmpbtnHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.tmpbtnHint.m_Handler = (MonoBehaviour) this;
    this.tmpbtnHint.ControlFadeOut = ((Component) this.PropertyInfo_Hint).gameObject;
    int _PanelObjectsCount = 10;
    for (int index = 0; index < _PanelObjectsCount; ++index)
      this.tmplist.Add(45f);
    this.m_itemView.IntiScrollPanel(385f, 3f, 0.0f, this.tmplist, _PanelObjectsCount, (IUpDateScrollPanel) this);
    this.m_ScrollRect = this.m_itemView.GetComponent<CScrollRect>();
    UIButtonHint.scrollRect = this.m_ScrollRect;
    if (this.OpenPage != (byte) 0)
      return;
    this.SetPage3InfoData();
    if (this.mOpenType == (byte) 1)
      this.SetPage3Info(true);
    else
      this.SetPage3Info(this.DM.Hero_Info_bHeroInfo);
  }

  public void SetPage(int nowpage)
  {
    if ((UnityEngine.Object) this.Pagedata[nowpage] == (UnityEngine.Object) null && this.OpenPage != (byte) 0)
      this.LoadPage(nowpage);
    for (int index = 0; index < 3; ++index)
    {
      this.btnPage[index].image.sprite = this.SArray.m_Sprites[1];
      ((Graphic) this.img_PageBG[index]).color = new Color(1f, 1f, 1f, 0.0f);
      if ((bool) (UnityEngine.Object) this.Pagedata[index])
      {
        this.Pagedata[index].gameObject.SetActive(false);
        if (index == 2 && ((UIBehaviour) this.PropertyInfo_Hint).IsActive())
          ((Component) this.PropertyInfo_Hint).gameObject.SetActive(false);
      }
    }
    this.mNowpage = nowpage;
    if (this.mOpenType != (byte) 1)
      this.DM.Hero_Info_Page = this.mNowpage;
    ((Graphic) this.img_PageBG[nowpage]).color = new Color(1f, 1f, 1f, 1f);
    this.PageBGTime = 0.0f;
    if ((bool) (UnityEngine.Object) this.Pagedata[this.mNowpage])
      this.Pagedata[this.mNowpage].gameObject.SetActive(true);
    this.btn_Fragment.image.sprite = this.SArray.m_Sprites[9 + this.mHeroStratum];
    if (this.mNowpage == 0 && (UnityEngine.Object) this.Pagedata[0] != (UnityEngine.Object) null)
    {
      if (!this.bEquip)
      {
        this.bEquip = true;
        this.SetStratum(this.mHeroStratum);
        this.ReSetBtnState();
      }
      this.CheckRankTimeBar();
      if (this.mHeroData.Star < (byte) 5)
        this.MaxStar = (float) this.DM.Medal[(int) this.mHeroData.Star];
      this.SetStarStratum((int) this.DM.GetCurItemQuantity(this.sHero.SoulStone, (byte) 0), (int) this.mHeroData.Star);
      this.CheckStarTimeBar();
      for (int index = 0; index < 6; ++index)
        ((Component) this.img_EquipLight[index]).gameObject.SetActive(false);
    }
    if (this.mNowpage == 1 && !this.bSkill && (UnityEngine.Object) this.Pagedata[1] != (UnityEngine.Object) null)
    {
      this.bSkill = true;
      this.ReSetSkill();
      Array.Clear((Array) this.SendSkillLv, 0, this.SendSkillLv.Length);
      this.Cstr_Leader.ClearString();
      this.Cstr_Leader.IntToFormat((long) this.DM.RankSoldiers[(int) this.mHeroData.Enhance]);
      if (this.GUIM.IsArabic)
        this.Cstr_Leader.AppendFormat("{0}+");
      else
        this.Cstr_Leader.AppendFormat("+{0}");
      this.text_Leader[0].text = this.Cstr_Leader.ToString();
      this.text_Leader[0].SetAllDirty();
      this.text_Leader[0].cachedTextGenerator.Invalidate();
      this.text_Leader[1].text = this.DM.mStringTable.GetStringByID(3841U + (uint) this.sHero.SoldierKind);
    }
    if (this.mNowpage != 2 || this.bInfo || !((UnityEngine.Object) this.Pagedata[2] != (UnityEngine.Object) null))
      return;
    this.bInfo = true;
    this.SetPage3InfoData();
  }

  public void CheckRankTimeBar()
  {
    if ((int) this.mHeroData.ID == (int) this.DM.RoleAttr.EnhanceEventHeroID && this.DM.queueBarData[11].bActive && this.mOpenType != (byte) 1)
    {
      if (this.bFSetRankTimeBar)
      {
        this.begin = this.DM.queueBarData[11].StartTime;
        this.target = this.begin + (long) this.DM.queueBarData[11].TotalTime;
        eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.HeroEnhance);
        this.notify = queueBarSpriteType != eTimerSpriteType.Free ? this.target - (long) this.DM.FreeCompletePeriod : 0L;
        this.Cstr_RankTimeBar.ClearString();
        this.Cstr_RankTimeBar.IntToFormat((long) ((int) this.mHeroData.Enhance + 1));
        this.Cstr_RankTimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(409U));
        this.GUIM.SetTimerBar(this.timeBarRank, this.begin, this.target, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(407U), this.Cstr_RankTimeBar.ToString());
        this.GUIM.SetTimerSpriteType(this.timeBarRank, queueBarSpriteType);
        this.bFSetRankTimeBar = false;
      }
      this.RankLightT.gameObject.SetActive(true);
      this.btn_EvolutionRT.anchoredPosition = new Vector2(this.btn_EvolutionRT.anchoredPosition.x, -245f);
      this.Img_EvolutionUpRT.anchoredPosition = new Vector2(this.Img_EvolutionUpRT.anchoredPosition.x, -266f);
      this.btn_NextRankRT.anchoredPosition = new Vector2(this.btn_NextRankRT.anchoredPosition.x, -149f);
      this.uTool_RankPosRT.anchoredPosition = new Vector2(this.uTool_RankPosRT.anchoredPosition.x, -186f);
      this.btn_EquipRT[0].anchoredPosition = new Vector2(this.btn_EquipRT[0].anchoredPosition.x, -167f);
      this.btn_EquipRT[5].anchoredPosition = new Vector2(this.btn_EquipRT[5].anchoredPosition.x, -167f);
      this.btn_EquipRT[1].anchoredPosition = new Vector2(this.btn_EquipRT[1].anchoredPosition.x, -249f);
      this.btn_EquipRT[4].anchoredPosition = new Vector2(this.btn_EquipRT[4].anchoredPosition.x, -249f);
      this.btn_EquipRT[2].anchoredPosition = new Vector2(this.btn_EquipRT[2].anchoredPosition.x, -331f);
      this.btn_EquipRT[3].anchoredPosition = new Vector2(this.btn_EquipRT[3].anchoredPosition.x, -331f);
      this.Img_EquipRT[0].anchoredPosition = new Vector2(this.Img_EquipRT[0].anchoredPosition.x, -167f);
      this.Img_EquipRT[5].anchoredPosition = new Vector2(this.Img_EquipRT[5].anchoredPosition.x, -167f);
      this.Img_EquipRT[1].anchoredPosition = new Vector2(this.Img_EquipRT[1].anchoredPosition.x, -249f);
      this.Img_EquipRT[4].anchoredPosition = new Vector2(this.Img_EquipRT[4].anchoredPosition.x, -249f);
      this.Img_EquipRT[2].anchoredPosition = new Vector2(this.Img_EquipRT[2].anchoredPosition.x, -331f);
      this.Img_EquipRT[3].anchoredPosition = new Vector2(this.Img_EquipRT[3].anchoredPosition.x, -331f);
      this.Img_HaveRT[0].anchoredPosition = new Vector2(this.Img_HaveRT[0].anchoredPosition.x, -149f);
      this.Img_HaveRT[5].anchoredPosition = new Vector2(this.Img_HaveRT[5].anchoredPosition.x, -149f);
      this.Img_HaveRT[1].anchoredPosition = new Vector2(this.Img_HaveRT[1].anchoredPosition.x, -231f);
      this.Img_HaveRT[4].anchoredPosition = new Vector2(this.Img_HaveRT[4].anchoredPosition.x, -231f);
      this.Img_HaveRT[2].anchoredPosition = new Vector2(this.Img_HaveRT[2].anchoredPosition.x, -313f);
      this.Img_HaveRT[3].anchoredPosition = new Vector2(this.Img_HaveRT[3].anchoredPosition.x, -313f);
      this.text_RT[0].anchoredPosition = new Vector2(this.text_RT[0].anchoredPosition.x, -188f);
      this.text_RT[5].anchoredPosition = new Vector2(this.text_RT[5].anchoredPosition.x, -188f);
      this.text_RT[1].anchoredPosition = new Vector2(this.text_RT[1].anchoredPosition.x, -270f);
      this.text_RT[4].anchoredPosition = new Vector2(this.text_RT[4].anchoredPosition.x, -270f);
      this.text_RT[2].anchoredPosition = new Vector2(this.text_RT[2].anchoredPosition.x, -352f);
      this.text_RT[3].anchoredPosition = new Vector2(this.text_RT[3].anchoredPosition.x, -352f);
      this.timeBarRank.gameObject.SetActive(true);
      ((Component) this.EvolutionRT).gameObject.SetActive(false);
    }
    else
    {
      this.RankLightT.gameObject.SetActive(false);
      this.btn_EvolutionRT.anchoredPosition = new Vector2(this.btn_EvolutionRT.anchoredPosition.x, -275f);
      this.Img_EvolutionUpRT.anchoredPosition = new Vector2(this.Img_EvolutionUpRT.anchoredPosition.x, -296f);
      this.btn_NextRankRT.anchoredPosition = new Vector2(this.btn_NextRankRT.anchoredPosition.x, -175f);
      this.uTool_RankPosRT.anchoredPosition = new Vector2(this.uTool_RankPosRT.anchoredPosition.x, -213f);
      this.btn_EquipRT[0].anchoredPosition = new Vector2(this.btn_EquipRT[0].anchoredPosition.x, -182f);
      this.btn_EquipRT[5].anchoredPosition = new Vector2(this.btn_EquipRT[5].anchoredPosition.x, -182f);
      this.btn_EquipRT[1].anchoredPosition = new Vector2(this.btn_EquipRT[1].anchoredPosition.x, -279f);
      this.btn_EquipRT[4].anchoredPosition = new Vector2(this.btn_EquipRT[4].anchoredPosition.x, -279f);
      this.btn_EquipRT[2].anchoredPosition = new Vector2(this.btn_EquipRT[2].anchoredPosition.x, -370f);
      this.btn_EquipRT[3].anchoredPosition = new Vector2(this.btn_EquipRT[3].anchoredPosition.x, -370f);
      this.Img_EquipRT[0].anchoredPosition = new Vector2(this.Img_EquipRT[0].anchoredPosition.x, -182f);
      this.Img_EquipRT[5].anchoredPosition = new Vector2(this.Img_EquipRT[5].anchoredPosition.x, -182f);
      this.Img_EquipRT[1].anchoredPosition = new Vector2(this.Img_EquipRT[1].anchoredPosition.x, -279f);
      this.Img_EquipRT[4].anchoredPosition = new Vector2(this.Img_EquipRT[4].anchoredPosition.x, -279f);
      this.Img_EquipRT[2].anchoredPosition = new Vector2(this.Img_EquipRT[2].anchoredPosition.x, -370f);
      this.Img_EquipRT[3].anchoredPosition = new Vector2(this.Img_EquipRT[3].anchoredPosition.x, -370f);
      this.Img_HaveRT[0].anchoredPosition = new Vector2(this.Img_HaveRT[0].anchoredPosition.x, -164f);
      this.Img_HaveRT[5].anchoredPosition = new Vector2(this.Img_HaveRT[5].anchoredPosition.x, -164f);
      this.Img_HaveRT[1].anchoredPosition = new Vector2(this.Img_HaveRT[1].anchoredPosition.x, -261f);
      this.Img_HaveRT[4].anchoredPosition = new Vector2(this.Img_HaveRT[4].anchoredPosition.x, -261f);
      this.Img_HaveRT[2].anchoredPosition = new Vector2(this.Img_HaveRT[2].anchoredPosition.x, -352f);
      this.Img_HaveRT[3].anchoredPosition = new Vector2(this.Img_HaveRT[3].anchoredPosition.x, -352f);
      this.text_RT[0].anchoredPosition = new Vector2(this.text_RT[0].anchoredPosition.x, -203f);
      this.text_RT[5].anchoredPosition = new Vector2(this.text_RT[5].anchoredPosition.x, -203f);
      this.text_RT[1].anchoredPosition = new Vector2(this.text_RT[1].anchoredPosition.x, -300f);
      this.text_RT[4].anchoredPosition = new Vector2(this.text_RT[4].anchoredPosition.x, -300f);
      this.text_RT[2].anchoredPosition = new Vector2(this.text_RT[2].anchoredPosition.x, -391f);
      this.text_RT[3].anchoredPosition = new Vector2(this.text_RT[3].anchoredPosition.x, -391f);
      this.timeBarRank.gameObject.SetActive(false);
      this.bFSetRankTimeBar = true;
      ((Component) this.EvolutionRT).gameObject.SetActive(true);
    }
    this.uToolRankPos.from = new Vector3(this.uTool_RankPosRT.anchoredPosition.x, this.uTool_RankPosRT.anchoredPosition.y - 3f, 0.0f);
    this.uToolRankPos.to = new Vector3(this.uTool_RankPosRT.anchoredPosition.x, this.uTool_RankPosRT.anchoredPosition.y + 3f, 0.0f);
  }

  public void CheckStarTimeBar()
  {
    if ((int) this.mHeroData.ID == (int) this.DM.RoleAttr.StarUpEventHeroID && this.DM.queueBarData[12].bActive && this.mOpenType != (byte) 1)
    {
      if (this.bFSetStarTimeBar)
      {
        this.begin = this.DM.queueBarData[12].StartTime;
        this.target = this.begin + (long) this.DM.queueBarData[12].TotalTime;
        eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.HeroEvolution);
        this.notify = queueBarSpriteType != eTimerSpriteType.Free ? this.target - (long) this.DM.FreeCompletePeriod : 0L;
        this.GUIM.SetTimerBar(this.timeBarStar, this.begin, this.target, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(408U), this.DM.mStringTable.GetStringByID((uint) this.sHero.HeroTitle));
        this.GUIM.SetTimerSpriteType(this.timeBarStar, queueBarSpriteType);
        this.bFSetStarTimeBar = false;
      }
      this.StarLightT.gameObject.SetActive(true);
      this.Img_StarStratumLightRT.anchoredPosition = new Vector2(this.Img_StarStratumLightRT.anchoredPosition.x, -95.5f);
      this.btn_StarDetailRT.anchoredPosition = new Vector2(this.btn_StarDetailRT.anchoredPosition.x, -95.5f);
      this.btn_StarEvolutionRT.anchoredPosition = new Vector2(this.btn_StarEvolutionRT.anchoredPosition.x, -95.5f);
      this.timeBarStar.gameObject.SetActive(true);
      ((Component) this.StarEvolutionRT).gameObject.SetActive(false);
      this.StarEvolutionRT.anchoredPosition = new Vector2(this.StarEvolutionRT.anchoredPosition.x, -60f);
    }
    else
    {
      this.StarLightT.gameObject.SetActive(false);
      this.Img_StarStratumLightRT.anchoredPosition = new Vector2(this.Img_StarStratumLightRT.anchoredPosition.x, -119.5f);
      this.btn_StarDetailRT.anchoredPosition = new Vector2(this.btn_StarDetailRT.anchoredPosition.x, -119.5f);
      this.btn_StarEvolutionRT.anchoredPosition = new Vector2(this.btn_StarEvolutionRT.anchoredPosition.x, -119.5f);
      this.GUIM.SetTimerBar(this.timeBarStar, 0L, 0L, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(408U), this.DM.mStringTable.GetStringByID((uint) this.sHero.HeroTitle));
      this.GUIM.SetTimerSpriteType(this.timeBarStar, eTimerSpriteType.Speed);
      this.timeBarStar.gameObject.SetActive(false);
      this.StarEvolutionRT.anchoredPosition = new Vector2(this.StarEvolutionRT.anchoredPosition.x, -80f);
    }
  }

  public void SetPage3Info(bool bInfo)
  {
    ((Component) this.PropertyInfo_Hint).gameObject.SetActive(false);
    this.bHeroInfo = bInfo;
    if (this.mOpenType != (byte) 1)
      this.DM.Hero_Info_bHeroInfo = this.bHeroInfo;
    if (this.bHeroInfo)
    {
      this.P3_p1.gameObject.SetActive(true);
      this.P3_p2.gameObject.SetActive(false);
      this.text_P3Title.text = this.TopText[0];
    }
    else
    {
      this.P3_p1.gameObject.SetActive(false);
      this.P3_p2.gameObject.SetActive(true);
      this.text_P3Title.text = this.TopText[1];
    }
  }

  public void SetHeroData(int sortIndex = 0, bool Load3d = true, bool bOpen = true)
  {
    if (this.mOpenType == (byte) 1 && this.mOpenKind == (byte) 1 && this.GUIM.UIPreviewHero_Index != -1)
    {
      sortIndex = this.GUIM.UIPreviewHero_Index;
      this.GUIM.UIPreviewHero_Index = -1;
    }
    if (this.GUIM.UIHero_Index > -1)
    {
      for (int index = 0; index < this.DM.sortHeroData.Length; ++index)
      {
        if ((long) this.GUIM.UIHero_Index == (long) this.DM.sortHeroData[index])
        {
          this.mHeroDataIndex = index;
          this.GUIM.UIHero_Index = -1;
          break;
        }
      }
    }
    else
      this.mHeroDataIndex = sortIndex;
    if (this.mHeroDataIndex == -1)
      this.mHeroDataIndex = 0;
    if (this.mOpenType == (byte) 1 && this.mOpenKind == (byte) 0)
    {
      this.mHeroData = this.DM.PreviewHeroData;
    }
    else
    {
      uint key = this.DM.sortHeroData[this.mHeroDataIndex];
      if (this.DM.curHeroData.ContainsKey(key))
        this.mHeroData = this.DM.curHeroData[key];
      this.mHeroData = this.DM.curHeroData[key];
      if (this.mOpenType == (byte) 1)
      {
        this.DM.PreviewHeroData.ID = this.mHeroData.ID;
        this.mHeroData = this.DM.PreviewHeroData;
      }
    }
    this.sHero = this.DM.HeroTable.GetRecordByKey(this.mHeroData.ID);
    this.mEnhance = this.DM.EnhanceTable.GetRecordByKey(this.sHero.HeroKey);
    this.mHeroState = this.DM.GetHeroState(this.mHeroData.ID);
    if (this.mHeroState == eHeroState.None)
    {
      ((Component) this.img_HeroState).gameObject.SetActive(false);
    }
    else
    {
      if (this.mOpenType == (byte) 1)
        ((Graphic) this.img_HeroState).rectTransform.anchoredPosition = new Vector2(((Graphic) this.img_HeroState).rectTransform.anchoredPosition.x, -50f);
      else
        ((Graphic) this.img_HeroState).rectTransform.anchoredPosition = new Vector2(((Graphic) this.img_HeroState).rectTransform.anchoredPosition.x, -121f);
      ((Component) this.img_HeroState).gameObject.SetActive(true);
      switch (this.mHeroState)
      {
        case eHeroState.IsFighting:
          this.img_HeroState.sprite = this.SArray.m_Sprites[32];
          this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(901U);
          break;
        case eHeroState.Captured:
          this.img_HeroState.sprite = this.SArray.m_Sprites[33];
          this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(902U);
          break;
        case eHeroState.Dead:
          this.img_HeroState.sprite = this.SArray.m_Sprites[34];
          this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(903U);
          break;
      }
    }
    this.text_HeroName.text = this.DM.mStringTable.GetStringByID((uint) this.sHero.HeroName);
    this.text_HeroTitle.text = this.DM.mStringTable.GetStringByID((uint) this.sHero.HeroTitle);
    this.text_Lv.text = this.mHeroData.Level.ToString();
    if (this.sHero.HeroType == (byte) 1)
      this.btn_Property.image.sprite = this.SArray.m_Sprites[24];
    else if (this.sHero.HeroType == (byte) 2)
      this.btn_Property.image.sprite = this.SArray.m_Sprites[23];
    else
      this.btn_Property.image.sprite = this.SArray.m_Sprites[22];
    this.SetHeroEXP(this.mHeroData.Exp);
    this.mHeroStratum = (int) this.mHeroData.Enhance;
    this.Cstr_Rank.ClearString();
    this.Cstr_Rank.Append(this.DM.mStringTable.GetStringByID(15U));
    this.Cstr_Rank.IntToFormat((long) this.mHeroStratum);
    this.Cstr_Rank.AppendFormat("{0}");
    this.text_Hint[0].text = this.Cstr_Rank.ToString();
    this.text_Hint[0].SetAllDirty();
    this.text_Hint[0].cachedTextGenerator.Invalidate();
    this.text_Hint[1].text = this.DM.mStringTable.GetStringByID((uint) (ushort) ((uint) this.sHero.HeroType + 377U));
    if (this.OpenPage == (byte) 0)
    {
      RectTransform component1 = ((Component) this.Property_Hint).transform.GetComponent<RectTransform>();
      float num1 = Mathf.Clamp(this.text_Hint[1].preferredWidth, 0.0f, ((Component) this.text_Hint[1]).transform.GetComponent<RectTransform>().sizeDelta.x);
      component1.sizeDelta = new Vector2(num1 + 20f, component1.sizeDelta.y);
      RectTransform component2 = ((Component) this.text_Hint[1]).transform.GetComponent<RectTransform>();
      component2.sizeDelta = new Vector2(num1 + 20f, component2.sizeDelta.y);
      RectTransform component3 = ((Component) this.Fragment_Hint).transform.GetComponent<RectTransform>();
      float num2 = Mathf.Clamp(this.text_Hint[0].preferredWidth, 0.0f, ((Component) this.text_Hint[0]).transform.GetComponent<RectTransform>().sizeDelta.x);
      component3.sizeDelta = new Vector2(num2 + 20f, component3.sizeDelta.y);
      RectTransform component4 = ((Component) this.text_Hint[0]).transform.GetComponent<RectTransform>();
      component4.sizeDelta = new Vector2(num2 + 20f, component4.sizeDelta.y);
    }
    this.Cstr_NextRS.ClearString();
    if ((int) this.mHeroData.Enhance < this.TopRank)
    {
      this.Cstr_NextRS.IntToFormat((long) this.DM.RankSoldiers[(int) this.mHeroData.Enhance + 1]);
      this.Cstr_NextRS.AppendFormat(this.DM.mStringTable.GetStringByID(581U));
      this.text_Next_RankSoldier.text = this.Cstr_NextRS.ToString();
    }
    if (Load3d)
    {
      this.bEquip = false;
      this.bSkill = false;
      this.bInfo = false;
      this.SetPage(this.mNowpage);
      this.Hero3D_Destroy();
      this.LoadHero3D();
    }
    if (!this.GUIM.m_IsOpenedUISynthesis || this.mOpenType == (byte) 1)
      return;
    this.GUIM.OpenUISynthesis((int) this.sHero.SoulStone);
    this.GUIM.m_IsOpenedUISynthesis = false;
  }

  public void SetBtnState(int index)
  {
    ushort num = 0;
    ((Component) this.img_EquipHave[index]).gameObject.SetActive(false);
    ((Component) this.text_Equip[index]).gameObject.SetActive(false);
    ((Component) this.img_EquipHave_Light[index]).gameObject.SetActive(false);
    if (this.mEnhance.EnhanceNumber != null)
      num = this.mEnhance.EnhanceNumber[(this.mHeroStratum - 1) * 6 + index];
    this.mEquip = this.DM.EquipTable.GetRecordByKey(num);
    this.GUIM.ChangeHeroItemImg(((Component) this.btn_Equip[index]).transform, eHeroOrItem.Item, num, (byte) 0, (byte) 0);
    this.mHeroEquip = (int) this.mHeroData.Equip;
    if (((int) this.mHeroData.Equip >> index & 1) == 1)
    {
      ((Graphic) this.btn_Equip[index].HIImage).color = this.Color_White;
    }
    else
    {
      ((Graphic) this.btn_Equip[index].HIImage).color = this.Color_Equip;
      this.btn_Equip[index].CircleImage.sprite = this.GUIM.LoadFrameSprite(EFrameSprite.Item, (byte) 1);
      if (this.DM.GetCurItemQuantity(num, (byte) 0) < (ushort) 1)
      {
        ((Component) this.text_Equip[index]).gameObject.SetActive(true);
        if (this.DM.FindItemComposite(num))
        {
          if ((int) this.mEquip.NeedLv > (int) this.mHeroData.Level)
          {
            ((Component) this.text_Equip[index]).gameObject.SetActive(true);
            ((Component) this.img_EquipHave[index]).gameObject.SetActive(true);
            this.img_EquipHave[index].sprite = this.SArray.m_Sprites[9];
            this.text_Equip[index].text = this.DM.mStringTable.GetStringByID(12U);
            ((Graphic) this.text_Equip[index]).color = this.Text_Color;
          }
          else
          {
            ((Component) this.img_EquipHave[index]).gameObject.SetActive(true);
            this.img_EquipHave[index].sprite = this.SArray.m_Sprites[8];
            this.text_Equip[index].text = this.DM.mStringTable.GetStringByID(13U);
            ((Graphic) this.text_Equip[index]).color = this.Color_Green;
            ((Component) this.img_EquipHave_Light[index]).gameObject.SetActive(true);
          }
        }
        else
        {
          this.text_Equip[index].text = this.DM.mStringTable.GetStringByID(14U);
          ((Graphic) this.text_Equip[index]).color = this.Text_Color;
        }
      }
      else if ((int) this.mEquip.NeedLv > (int) this.mHeroData.Level)
      {
        ((Component) this.text_Equip[index]).gameObject.SetActive(true);
        ((Component) this.img_EquipHave[index]).gameObject.SetActive(true);
        this.img_EquipHave[index].sprite = this.SArray.m_Sprites[9];
        this.text_Equip[index].text = this.DM.mStringTable.GetStringByID(12U);
        ((Graphic) this.text_Equip[index]).color = this.Text_Color;
      }
      else
      {
        ((Component) this.text_Equip[index]).gameObject.SetActive(true);
        ((Component) this.img_EquipHave[index]).gameObject.SetActive(true);
        this.img_EquipHave[index].sprite = this.SArray.m_Sprites[8];
        this.text_Equip[index].text = this.DM.mStringTable.GetStringByID(13U);
        ((Graphic) this.text_Equip[index]).color = this.Color_Green;
        ((Component) this.img_EquipHave_Light[index]).gameObject.SetActive(true);
      }
    }
    if (this.bEnchantments)
      ;
  }

  public void ReSetBtnState()
  {
    this.bEnchantments = false;
    ((Component) this.EvolutionRT).gameObject.SetActive(false);
    if (this.mHeroStratum < 13)
    {
      for (int index = 0; index < 6; ++index)
      {
        this.SetBtnState(index);
        if (!this.bShowEquipLight && ((UIBehaviour) this.img_EquipHave_Light[index]).IsActive())
          this.bShowEquipLight = true;
      }
    }
    if (this.mOpenType != (byte) 1)
    {
      if (this.mHeroEquip < 63)
      {
        ((Component) this.RankLightBG).gameObject.SetActive(false);
        ((Component) this.Img_EvolutionUp).gameObject.SetActive(false);
        this.uToolRankPos.enabled = false;
        this.uToolRank.enabled = false;
      }
      else
      {
        if (!this.DM.queueBarData[11].bActive)
          ((Component) this.RankLightBG).gameObject.SetActive(true);
        if (this.mHeroStratum == this.TopRank)
        {
          ((Component) this.Img_EvolutionUp).gameObject.SetActive(false);
          this.uToolRankPos.enabled = false;
          this.uToolRank.enabled = false;
        }
        else
        {
          ((Component) this.Img_EvolutionUp).gameObject.SetActive(true);
          this.uToolRankPos.enabled = true;
          this.uToolRank.enabled = true;
          if (this.DM.queueBarData[11].bActive && (int) this.mHeroId == (int) this.DM.RoleAttr.EnhanceEventHeroID)
            return;
          ((Component) this.EvolutionRT).gameObject.SetActive(true);
        }
      }
    }
    else
    {
      ((Component) this.RankLightBG).gameObject.SetActive(false);
      ((Component) this.Img_EvolutionUp).gameObject.SetActive(false);
      this.uToolRankPos.enabled = false;
      this.uToolRank.enabled = false;
    }
  }

  public void SetStratum(int mStratum)
  {
    if (this.mHeroStratum != mStratum)
      this.mHeroStratum = mStratum;
    if (this.mHeroStratum == this.TopRank)
    {
      ((Component) this.btn_EquipStratum).gameObject.SetActive(false);
      this.uToolRankPos.gameObject.SetActive(false);
    }
    else if (!((UIBehaviour) this.btn_EquipStratum).IsActive())
    {
      ((Component) this.btn_EquipStratum).gameObject.SetActive(true);
      this.uToolRankPos.gameObject.SetActive(true);
    }
    this.btn_Evolution.image.sprite = this.SArray.m_Sprites[9 + this.mHeroStratum];
    this.btn_EquipStratum.image.sprite = this.SArray.m_Sprites[10 + this.mHeroStratum];
    this.Cstr_Rank.ClearString();
    this.Cstr_Rank.Append(this.DM.mStringTable.GetStringByID(15U));
    this.Cstr_Rank.IntToFormat((long) this.mHeroStratum);
    this.Cstr_Rank.AppendFormat("{0}");
    this.text_Rank.text = this.Cstr_Rank.ToString();
    this.text_Rank.SetAllDirty();
    this.text_Rank.cachedTextGenerator.Invalidate();
    this.text_Hint[0].text = this.Cstr_Rank.ToString();
    this.text_Hint[0].SetAllDirty();
    this.text_Hint[0].cachedTextGenerator.Invalidate();
  }

  public void SetStarStratum(int mValue, int StarLv = 0)
  {
    this.bStarEvolution = (double) mValue >= (double) this.MaxStar;
    ((Component) this.StarEvolutionRT).gameObject.SetActive(false);
    if (StarLv == 5)
    {
      this.text_HeroStarLv.text = this.DM.mStringTable.GetStringByID(21U);
      this.btn_StarEvolution.interactable = false;
      this.uToolStar.enabled = true;
      ((Component) this.StarStratumLightBG).gameObject.SetActive(true);
    }
    else
    {
      this.Cstr_HeroStarLv.ClearString();
      if (this.GUIM.IsArabic)
      {
        this.Cstr_HeroStarLv.FloatToFormat(this.MaxStar);
        this.Cstr_HeroStarLv.IntToFormat((long) mValue);
      }
      else
      {
        this.Cstr_HeroStarLv.IntToFormat((long) mValue);
        this.Cstr_HeroStarLv.FloatToFormat(this.MaxStar);
      }
      this.Cstr_HeroStarLv.AppendFormat("{0} / {1}");
      this.text_HeroStarLv.text = this.Cstr_HeroStarLv.ToString();
      this.text_HeroStarLv.SetAllDirty();
      this.text_HeroStarLv.cachedTextGenerator.Invalidate();
      this.btn_StarEvolution.interactable = true;
      if (this.bStarEvolution)
      {
        ((Component) this.Img_StarEvolution).gameObject.SetActive(true);
        if (!this.DM.queueBarData[12].bActive)
        {
          ((Component) this.StarStratumLightBG).gameObject.SetActive(true);
          ((Component) this.StarEvolutionRT).gameObject.SetActive(true);
        }
        else if ((int) this.mHeroId != (int) this.DM.RoleAttr.StarUpEventHeroID)
          ((Component) this.StarEvolutionRT).gameObject.SetActive(true);
        this.uToolStar.enabled = true;
      }
      else
      {
        ((Component) this.Img_StarEvolution).gameObject.SetActive(false);
        ((Component) this.StarStratumLightBG).gameObject.SetActive(false);
        this.uToolStar.enabled = false;
      }
    }
    this.btn_StarEvolution.image.sprite = this.SArray.m_Sprites[24 + StarLv];
  }

  public void SetHeroEXP(uint Exp)
  {
    uint heroExp = this.DM.LevelUpTable.GetRecordByKey((ushort) this.mHeroData.Level).HeroExp;
    RectTransform component = ((Component) this.img_HeroExp).GetComponent<RectTransform>();
    float num = (float) Exp / (float) heroExp;
    if ((double) num >= 1.0)
      num = 1f;
    this.TmpV.Set(this.mExpLength * num, component.sizeDelta.y);
    component.sizeDelta = this.TmpV;
    this.Cstr_HeroEXP.ClearString();
    if (this.GUIM.IsArabic)
    {
      this.Cstr_HeroEXP.IntToFormat((long) heroExp, bNumber: true);
      this.Cstr_HeroEXP.IntToFormat((long) Exp, bNumber: true);
    }
    else
    {
      this.Cstr_HeroEXP.IntToFormat((long) Exp, bNumber: true);
      this.Cstr_HeroEXP.IntToFormat((long) heroExp, bNumber: true);
    }
    this.Cstr_HeroEXP.AppendFormat("{0} / {1} ");
    this.Cstr_HeroEXP.Append(this.DM.mStringTable.GetStringByID(9U));
    this.text_HeroEXP.text = this.Cstr_HeroEXP.ToString();
    this.text_HeroEXP.SetAllDirty();
    this.text_HeroEXP.cachedTextGenerator.Invalidate();
    this.UpdatePower();
    this.text_Lv.text = this.mHeroData.Level.ToString();
  }

  public void UpdatePower()
  {
    this.mHeroId = this.mHeroData.ID;
    this.mCalcAttrData.SkillLV1 = this.mHeroData.SkillLV[0];
    this.mCalcAttrData.SkillLV2 = this.mHeroData.SkillLV[1];
    this.mCalcAttrData.SkillLV3 = this.mHeroData.SkillLV[2];
    this.mCalcAttrData.SkillLV4 = this.mHeroData.SkillLV[3];
    for (int index = 0; index < 4; ++index)
      this.SkillLv[index] = this.mHeroData.SkillLV[index];
    this.mCalcAttrData.LV = this.mHeroData.Level;
    this.mCalcAttrData.Star = this.mHeroData.Star;
    this.mCalcAttrData.Enhance = this.mHeroData.Enhance;
    this.mCalcAttrData.Equip = this.mHeroData.Equip;
    this.EquipEffect_HP = 0U;
    Array.Clear((Array) this.EquipEffect_pAttr, 0, this.EquipEffect_pAttr.Length);
    this.mBs.setCalculateHeroEquipEffect(this.mHeroId, this.mHeroData.Enhance, this.mHeroData.Equip, ref this.EquipEffect_HP, this.EquipEffect_pAttr);
    this.HP = 0U;
    Array.Clear((Array) this.pAttr, 0, this.pAttr.Length);
    this.mBs.setCalculateAttribute(this.mHeroId, ref this.mCalcAttrData, ref this.HP, this.pAttr);
    this.Power = this.mBs.updateFightScore(this.mHeroId, this.HP, this.pAttr, this.SkillLv);
    this.Cstr_HeroPower.ClearString();
    this.Cstr_HeroPower.Append(this.DM.mStringTable.GetStringByID(11U));
    this.Cstr_HeroPower.IntToFormat((long) this.Power, bNumber: true);
    this.Cstr_HeroPower.AppendFormat(" : {0}");
    this.text_HeroPower.text = this.Cstr_HeroPower.ToString();
    this.text_HeroPower.SetAllDirty();
    this.text_HeroPower.cachedTextGenerator.Invalidate();
    this.bInfo = false;
  }

  public void SetSkilldata(byte idx)
  {
    if (this.sHero.AttackPower != null)
      this.mSkill = this.DM.SkillTable.GetRecordByKey(this.sHero.AttackPower[(int) idx + 1]);
    CString SpriteName1 = StringManager.Instance.StaticString1024();
    SpriteName1.ClearString();
    SpriteName1.IntToFormat((long) this.mSkill.SkillIcon, 5);
    SpriteName1.AppendFormat("s{0}");
    this.img_Skill[(int) idx].sprite = this.GUIM.LoadSkillSprite(SpriteName1);
    if (idx == (byte) 0)
      this.text_Skill_Name.text = this.DM.mStringTable.GetStringByID((uint) this.mSkill.SkillName);
    this.mSkill = this.DM.SkillTable.GetRecordByKey((ushort) ((uint) this.sHero.GroupSkill1 + (uint) idx));
    CString SpriteName2 = StringManager.Instance.StaticString1024();
    SpriteName2.ClearString();
    SpriteName2.IntToFormat((long) this.mSkill.SkillIcon, 5);
    SpriteName2.AppendFormat("s{0}");
    this.img_Skill[(int) idx + 4].sprite = this.GUIM.LoadSkillSprite(SpriteName2);
    if (this.SkillLv[(int) idx] == (byte) 0)
    {
      ((Graphic) this.img_Skill[(int) idx]).color = this.Color_Gray;
      ((Graphic) this.img_Skill[4 + (int) idx]).color = this.Color_Gray;
      ((Graphic) this.img_SkillFrame[(int) idx]).color = this.Color_Gray;
      ((Graphic) this.img_SkillFrame[4 + (int) idx]).color = this.Color_Gray;
      ((Component) this.img_Lock[(int) idx - 1]).gameObject.SetActive(true);
      ((Component) this.img_Lock[(int) idx + 2]).gameObject.SetActive(true);
      ((Graphic) this.img_SkillBook[(int) idx - 1]).color = this.Color_Gray;
      ((Component) this.img_Skill_Lv[(int) idx - 1]).gameObject.SetActive(false);
      if (idx == (byte) 0)
        return;
      ((Graphic) this.text_Skill2_[(int) idx * 2]).color = this.Color_Gray;
      ((Graphic) this.text_Skill2_[(int) idx * 2 + 1]).color = this.Color_Gray;
    }
    else
    {
      ((Graphic) this.img_Skill[(int) idx]).color = this.Color_White;
      ((Graphic) this.img_Skill[4 + (int) idx]).color = this.Color_White;
      ((Graphic) this.img_SkillFrame[(int) idx]).color = this.Color_White;
      ((Graphic) this.img_SkillFrame[4 + (int) idx]).color = this.Color_White;
      if (idx != (byte) 0)
      {
        ((Graphic) this.text_Skill2_[(int) idx * 2]).color = this.Color_White;
        ((Graphic) this.text_Skill2_[(int) idx * 2 + 1]).color = this.Color_White;
      }
      if (idx > (byte) 0)
      {
        ((Component) this.img_Lock[(int) idx - 1]).gameObject.SetActive(false);
        ((Component) this.img_Lock[(int) idx + 2]).gameObject.SetActive(false);
        ((Graphic) this.img_SkillBook[(int) idx - 1]).color = this.Color_White;
        ((Component) this.img_Skill_Lv[(int) idx - 1]).gameObject.SetActive(true);
      }
      this.Cstr_Skill_Lv[(int) idx].ClearString();
      this.Cstr_Skill_Lv[(int) idx].IntToFormat((long) this.SkillLv[(int) idx]);
      this.Cstr_Skill_Lv[(int) idx].AppendFormat(this.DM.mStringTable.GetStringByID(52U));
      this.text_Skill_Lv[(int) idx].text = this.Cstr_Skill_Lv[(int) idx].ToString();
      this.text_Skill_Lv[(int) idx].SetAllDirty();
      this.text_Skill_Lv[(int) idx].cachedTextGenerator.Invalidate();
      ((Graphic) this.text_Skill_Lv[(int) idx]).color = this.Color_White;
    }
  }

  public void ReSetSkill()
  {
    for (int idx = 0; idx < 4; ++idx)
    {
      this.SkillLv[idx] = this.mHeroData.SkillLV[idx];
      this.SetSkilldata((byte) idx);
      this.Cstr_Skill_Info[idx].ClearString();
      this.key[0] = this.sHero.GroupSkill1;
      this.key[1] = this.sHero.GroupSkill2;
      this.key[2] = this.sHero.GroupSkill3;
      this.key[3] = this.sHero.GroupSkill4;
      this.mSkill = this.DM.SkillTable.GetRecordByKey(this.key[idx]);
      float mValue = (float) this.mSkill.HurtValue + (float) ((int) this.LegionRankMagnifation[(int) this.mHeroData.Star - 1] * (int) this.mSkill.HurtIncreaseValue) / 1000f;
      if (this.mSkill.SkillType == (byte) 10)
        GameConstants.GetEffectValue(this.Cstr_Skill_Info[idx], this.mSkill.HurtAddition, (uint) mValue, (byte) 1, 0.0f);
      else if (this.mSkill.HurtKind == (byte) 1)
        GameConstants.GetEffectValue(this.Cstr_Skill_Info[idx], this.mSkill.HurtAddition, (uint) this.mSkill.HurtValue + (uint) this.mSkill.HurtIncreaseValue * (uint) this.LegionRankMagnifation[(int) this.mHeroData.Star - 1], (byte) 9, 0.0f);
      else
        GameConstants.GetEffectValue(this.Cstr_Skill_Info[idx], this.mSkill.HurtAddition, 0U, (byte) 6, mValue * 100f);
    }
    this.mSkill = this.DM.SkillTable.GetRecordByKey(this.sHero.GroupSkill1);
    this.text_Skill2_[0].text = this.DM.mStringTable.GetStringByID((uint) this.mSkill.SkillName);
    this.text_Skill2_[1].text = this.Cstr_Skill_Info[0].ToString();
    this.text_Skill2_[1].SetAllDirty();
    this.text_Skill2_[1].cachedTextGenerator.Invalidate();
    this.mSkill = this.DM.SkillTable.GetRecordByKey(this.sHero.GroupSkill2);
    this.text_Skill2_[2].text = this.DM.mStringTable.GetStringByID((uint) this.mSkill.SkillName);
    this.text_Skill2_[3].text = this.Cstr_Skill_Info[1].ToString();
    this.text_Skill2_[3].SetAllDirty();
    this.text_Skill2_[3].cachedTextGenerator.Invalidate();
    this.mSkill = this.DM.SkillTable.GetRecordByKey(this.sHero.GroupSkill3);
    this.text_Skill2_[4].text = this.DM.mStringTable.GetStringByID((uint) this.mSkill.SkillName);
    this.text_Skill2_[5].text = this.Cstr_Skill_Info[2].ToString();
    this.text_Skill2_[5].SetAllDirty();
    this.text_Skill2_[5].cachedTextGenerator.Invalidate();
    this.mSkill = this.DM.SkillTable.GetRecordByKey(this.sHero.GroupSkill4);
    this.text_Skill2_[6].text = this.DM.mStringTable.GetStringByID((uint) this.mSkill.SkillName);
    this.text_Skill2_[7].text = this.Cstr_Skill_Info[3].ToString();
    this.text_Skill2_[7].SetAllDirty();
    this.text_Skill2_[7].cachedTextGenerator.Invalidate();
  }

  public void SetPage3InfoData()
  {
    this.m_Mask.StopMovement();
    this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, 0.0f);
    this.text_HeroInfo.text = this.DM.mStringTable.GetStringByID((uint) this.sHero.Description);
    if ((double) this.text_HeroInfo.preferredHeight > 190.0)
    {
      this.TmpV.Set(this.ContentRT.sizeDelta.x, this.text_HeroInfo.preferredHeight);
      this.ContentRT.sizeDelta = this.TmpV;
    }
    for (int index = 0; index < 3; ++index)
    {
      this.Cstr_Property[index].ClearString();
      StringManager.IntToStr(this.Cstr_Property[index], (long) this.pAttr[index], bNumber: true);
      this.text_Property[index * 2].text = this.Cstr_Property[index].ToString();
      this.text_Property[index * 2].SetAllDirty();
      this.text_Property[index * 2].cachedTextGenerator.Invalidate();
    }
    this.text_Property[1].text = ((float) this.sHero.StarUp.Strength / 100f * this.StarValue[(int) this.mHeroData.Star]).ToString();
    this.text_Property[3].text = ((float) this.sHero.StarUp.Dexterity / 100f * this.StarValue[(int) this.mHeroData.Star]).ToString();
    this.text_Property[5].text = ((float) this.sHero.StarUp.Intelligence / 100f * this.StarValue[(int) this.mHeroData.Star]).ToString();
    this.tmplist.Clear();
    int index1 = 1;
    for (int index2 = 3; index2 < 20; ++index2)
    {
      if (this.pAttr[index2] != (ushort) 0)
      {
        this.pAttrIdx[index1] = (ushort) index2;
        this.EquipEffect_pAttrIdx[index1] = (ushort) index2;
        ++index1;
      }
    }
    for (int index3 = 23; index3 < 28; ++index3)
    {
      if (this.pAttr[index3] != (ushort) 0)
      {
        this.pAttrIdx[index1] = (ushort) index3;
        this.EquipEffect_pAttrIdx[index1] = (ushort) index3;
        ++index1;
      }
    }
    for (int index4 = 0; index4 < index1; ++index4)
      this.tmplist.Add(45f);
    this.m_itemView.AddNewDataHeight(this.tmplist);
  }

  public void Hero3D_Destroy()
  {
    if ((UnityEngine.Object) this.go2 != (UnityEngine.Object) null)
    {
      this.go2.transform.SetParent(this.Hero_Pos.parent, false);
      UnityEngine.Object.Destroy((UnityEngine.Object) this.go2);
    }
    if ((UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null)
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Hero_Model);
    this.Hero_Model = (Transform) null;
    this.go2 = (GameObject) null;
    AssetManager.UnloadAssetBundle(this.AssetKey, false);
  }

  public void LoadHero3D()
  {
    this.ActionTime = 0.0f;
    this.ActionTimeRandom = 2f;
    this.btn_HeroActionD.ReSetHero();
    CString Name = StringManager.Instance.StaticString1024();
    Name.IntToFormat((long) this.sHero.Modle, 5);
    Name.AppendFormat("Role/hero_{0}");
    if (this.sHero.Modle > (ushort) 0 && AssetManager.GetAssetBundleDownload(Name, AssetPath.Role, AssetType.Hero, this.sHero.Modle))
    {
      this.AB = AssetManager.GetAssetBundle(Name, out this.AssetKey);
      if (!((UnityEngine.Object) this.AB != (UnityEngine.Object) null))
        return;
      this.AR = this.AB.LoadAsync("m", typeof (GameObject));
      this.ABIsDone = false;
    }
    else
      this.AR = (AssetBundleRequest) null;
  }

  public void HeroActionChang(bool bAddShowEffect = false)
  {
    if (!this.ABIsDone || !((UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null))
      return;
    this.tmpAN = this.Hero_Model.GetComponent<Animation>();
    this.tmpAN.wrapMode = WrapMode.Loop;
    if (this.HeroAct == this.mHeroAct[1])
      this.tmpAN.CrossFade("idle");
    if ((UnityEngine.Object) this.tmpAN.GetClip(this.mHeroAct[2]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[2];
      this.tmpAN[this.mHeroAct[2]].layer = 1;
      this.tmpAN[this.mHeroAct[2]].wrapMode = WrapMode.Once;
    }
    if ((UnityEngine.Object) this.tmpAN.GetClip(this.mHeroAct[3]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[3];
      this.tmpAN[this.mHeroAct[3]].layer = 1;
      this.tmpAN[this.mHeroAct[3]].wrapMode = WrapMode.Once;
    }
    if ((UnityEngine.Object) this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[4]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[4];
      this.tmpAN[this.mHeroAct[4]].layer = 1;
      this.tmpAN[this.mHeroAct[4]].wrapMode = WrapMode.Once;
    }
    if ((UnityEngine.Object) this.tmpAN.GetClip(this.mHeroAct[5]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[5];
      this.tmpAN[this.mHeroAct[5]].layer = 1;
      this.tmpAN[this.mHeroAct[5]].wrapMode = WrapMode.Once;
    }
    if ((UnityEngine.Object) this.tmpAN.GetClip(this.mHeroAct[6]) != (UnityEngine.Object) null)
    {
      this.HeroAct = this.mHeroAct[6];
      this.tmpAN[this.mHeroAct[6]].layer = 1;
      this.tmpAN[this.mHeroAct[6]].wrapMode = WrapMode.Once;
    }
    int index = bAddShowEffect ? 6 : UnityEngine.Random.Range(1, 7);
    AnimationClip animationClip = this.tmpAN.GetClip(this.mHeroAct[(int) (byte) index]);
    this.HeroAct = this.mHeroAct[(int) (byte) index];
    if (index == 3 && (UnityEngine.Object) this.tmpAN.GetClip(this.HeroAct + "_ch") != (UnityEngine.Object) null)
      animationClip = (AnimationClip) null;
    if ((UnityEngine.Object) animationClip != (UnityEngine.Object) null)
    {
      this.tmpAN.CrossFade(animationClip.name);
      this.MovingTimer = 0.0f;
      if (index == 1)
        this.MovingTimer = 2f;
    }
    this.ActionTimeRandom = 0.0f;
    this.ActionTime = 0.0f;
  }

  public void OpenRankEquip(bool bOpen)
  {
    if (bOpen)
    {
      ushort HIID = 0;
      for (int index = 0; index < 6; ++index)
      {
        if (this.mEnhance.EnhanceNumber != null && this.mHeroStratum * 6 + index < this.mEnhance.EnhanceNumber.Length)
          HIID = this.mEnhance.EnhanceNumber[this.mHeroStratum * 6 + index];
        this.GUIM.ChangeHeroItemImg(((Component) this.btn_RankEquip[index]).transform, eHeroOrItem.Item, HIID, (byte) 0, (byte) 0);
      }
      this.imgRank_Rank.sprite = this.SArray.m_Sprites[10 + this.mHeroStratum];
      this.Cstr_NextRank.ClearString();
      this.Cstr_NextRank.Append(this.DM.mStringTable.GetStringByID(15U));
      this.Cstr_NextRank.IntToFormat((long) (this.mHeroStratum + 1));
      this.Cstr_NextRank.AppendFormat("{0}");
      this.text_NextRank.text = this.Cstr_NextRank.ToString();
      this.text_NextRank.SetAllDirty();
      this.text_NextRank.cachedTextGenerator.Invalidate();
      ((Component) this.btn_Rank_Exit).transform.SetParent((Transform) this.GUIM.m_SecWindowLayer, false);
      ((Component) this.btn_Rank_Exit).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.btn_Rank_Exit).transform.SetParent(this.GameT, false);
      ((Component) this.btn_Rank_Exit).transform.SetSiblingIndex(12);
      ((Component) this.btn_Rank_Exit).gameObject.SetActive(false);
    }
  }

  public override void OnClose()
  {
    if ((bool) (UnityEngine.Object) this.timeBarRank)
      this.GUIM.RemoverTimeBaarToList(this.timeBarRank);
    if ((bool) (UnityEngine.Object) this.timeBarStar)
      this.GUIM.RemoverTimeBaarToList(this.timeBarStar);
    this.tmplist = (List<float>) null;
    this.GUIM.UIPreviewHero_Index = -1;
    this.GUIM.UIHero_Index = -1;
    if (this.mHeroDataIndex != -1)
    {
      if (this.mOpenType != (byte) 1)
      {
        if (this.GUIM.m_WindowStack.Count > 0 && this.GUIM.m_WindowStack[this.GUIM.m_WindowStack.Count - 1].m_eWindow == EGUIWindow.UI_Hero_Info)
          this.GUIM.m_WindowStack[this.GUIM.m_WindowStack.Count - 1] = this.GUIM.m_WindowStack[this.GUIM.m_WindowStack.Count - 1] with
          {
            m_Arg1 = this.mHeroDataIndex
          };
      }
      else
        this.GUIM.UIPreviewHero_Index = this.mHeroDataIndex;
      this.GUIM.UIHero_Index = (int) this.mHeroId;
    }
    this.Hero3D_Destroy();
    if (this.Cstr_RankTimeBar != null)
      StringManager.Instance.DeSpawnString(this.Cstr_RankTimeBar);
    if (this.Cstr_Rank != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Rank);
    if (this.Cstr_NextRank != null)
      StringManager.Instance.DeSpawnString(this.Cstr_NextRank);
    if (this.Cstr_HeroStarLv != null)
      StringManager.Instance.DeSpawnString(this.Cstr_HeroStarLv);
    if (this.Cstr_HeroEXP != null)
      StringManager.Instance.DeSpawnString(this.Cstr_HeroEXP);
    if (this.Cstr_HeroPower != null)
      StringManager.Instance.DeSpawnString(this.Cstr_HeroPower);
    if (this.Cstr_Leader != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Leader);
    for (int index = 0; index < 4; ++index)
    {
      if (this.Cstr_Skill_Lv[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Skill_Lv[index]);
      if (this.Cstr_Skill_Cost[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Skill_Cost[index]);
      if (this.Cstr_Skill_Info[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Skill_Info[index]);
    }
    for (int index = 0; index < 6; ++index)
    {
      if (this.Cstr_ShowEffect[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ShowEffect[index]);
    }
    for (int index = 0; index < 3; ++index)
    {
      if (this.Cstr_Property[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Property[index]);
    }
    for (int index = 0; index < 10; ++index)
    {
      if (this.Cstr_ItemPropertyValue[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemPropertyValue[index]);
    }
    if (this.Cstr_Hint != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Hint);
    if (this.Cstr_NextRS != null)
      StringManager.Instance.DeSpawnString(this.Cstr_NextRS);
    if ((UnityEngine.Object) this.mParticleRank != (UnityEngine.Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.mParticleRank);
      this.mParticleRank = (GameObject) null;
    }
    if ((UnityEngine.Object) this.mParticleStar != (UnityEngine.Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.mParticleStar);
      this.mParticleStar = (GameObject) null;
    }
    if (!((UnityEngine.Object) this.mParticleEffectpAttr != (UnityEngine.Object) null) || !this.mParticleEffectpAttr.activeSelf || !((UnityEngine.Object) ParticleManager.Instance.AllEffectObject != (UnityEngine.Object) null))
      return;
    this.mParticleEffectpAttr.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
  }

  public void SetSkillPage(bool bHeroSkill)
  {
    if (!bHeroSkill)
    {
      if (this.mOpenType != (byte) 1)
        this.DM.Hero_Info_bHeroSkill = false;
      this.mSkillpage = 0;
      this.SkillPageTime = 0.0f;
      this.btn_SkillPage[0].image.sprite = this.SArray.m_Sprites[30];
      this.btn_SkillPage[1].image.sprite = this.SArray.m_Sprites[31];
      ((Graphic) this.img_SkillPage[0]).color = new Color(1f, 1f, 1f, 0.0f);
      ((Graphic) this.img_SkillPage[1]).color = new Color(1f, 1f, 1f, 0.0f);
      this.SkillPageT[0].gameObject.SetActive(true);
      this.SkillPageT[1].gameObject.SetActive(false);
      ((Graphic) this.text_SkillPage[0]).color = this.Color_Target;
      ((Graphic) this.text_SkillPage[1]).color = this.Color_NoTarget;
    }
    else
    {
      if (this.mOpenType != (byte) 1)
        this.DM.Hero_Info_bHeroSkill = true;
      this.mSkillpage = 1;
      this.SkillPageTime = 0.0f;
      this.btn_SkillPage[0].image.sprite = this.SArray.m_Sprites[31];
      this.btn_SkillPage[1].image.sprite = this.SArray.m_Sprites[30];
      ((Graphic) this.img_SkillPage[0]).color = new Color(1f, 1f, 1f, 0.0f);
      ((Graphic) this.img_SkillPage[1]).color = new Color(1f, 1f, 1f, 0.0f);
      this.SkillPageT[0].gameObject.SetActive(false);
      this.SkillPageT[1].gameObject.SetActive(true);
      ((Graphic) this.text_SkillPage[0]).color = this.Color_NoTarget;
      ((Graphic) this.text_SkillPage[1]).color = this.Color_Target;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    Btn_Count btnId1 = (Btn_Count) sender.m_BtnID1;
    switch (btnId1)
    {
      case Btn_Count.btn_EXIT:
        this.mHeroDataIndex = -1;
        this.OpenUISynthesis = false;
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.CloseMenu();
        break;
      case Btn_Count.btn_Page1:
      case Btn_Count.btn_Page2:
      case Btn_Count.btn_Page3:
        this.SetPage(sender.m_BtnID1 - 2);
        break;
      case Btn_Count.btn_Evolution:
        if (this.mOpenType == (byte) 1)
          break;
        if (this.mHeroStratum == this.TopRank)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(16U), (ushort) byte.MaxValue);
          break;
        }
        if (this.mHeroEquip < 63)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(18U), (ushort) byte.MaxValue);
          break;
        }
        if (this.DM.queueBarData[11].bActive)
        {
          if ((int) this.mHeroData.ID == (int) this.DM.RoleAttr.EnhanceEventHeroID)
          {
            this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(659U), (ushort) byte.MaxValue);
            break;
          }
          this.GUIM.OpenOKCancelBox((GUIWindow) this, (string) null, this.DM.mStringTable.GetStringByID(490U), 3);
          break;
        }
        if ((int) this.DM.GetLeaderID() == (int) this.mHeroData.ID && (this.mHeroState == eHeroState.Dead || this.mHeroState == eHeroState.Captured))
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(890U), (ushort) byte.MaxValue);
          break;
        }
        uint Num1 = (uint) this.DM.Hero_RankCost[this.mHeroStratum] * 60U;
        float num1 = 0.0f;
        float hour1 = (float) (Num1 / 3600U);
        float num2 = num1 + hour1 * 3600f;
        float min1 = (float) (((double) Num1 - (double) num2) / 60.0);
        float num3 = num2 + min1 * 60f;
        float sec1 = (float) Num1 - num3;
        float day1 = 0.0f;
        if ((double) hour1 >= 24.0)
        {
          day1 = hour1 / 24f;
          hour1 -= (float) ((int) day1 * 24);
        }
        this.needDiamond = this.DM.GetResourceExchange(PriceListType.Time, Num1);
        this.GUIM.OpenSpendWindow_ItemID2((GUIWindow) this, this.DM.mStringTable.GetStringByID(20U), (ushort) 1077, (ushort) 1078, this.needDiamond, (ushort) (byte) day1, (byte) hour1, (byte) min1, (byte) sec1, false, 1, HaveItemText: this.DM.mStringTable.GetStringByID(2910U), NoItemText: this.DM.mStringTable.GetStringByID(2910U), BottomText: this.DM.mStringTable.GetStringByID(2911U));
        NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, (object) this);
        break;
      case Btn_Count.btn_EquipStratum:
        if (this.mHeroStratum == this.TopRank)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(16U), (ushort) byte.MaxValue);
          break;
        }
        this.OpenRankEquip(true);
        break;
      case Btn_Count.btn_StarEvolution:
        if (this.mOpenType == (byte) 1)
          break;
        if ((double) this.DM.GetCurItemQuantity(this.sHero.SoulStone, (byte) 0) < (double) this.MaxStar)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(24U), (ushort) byte.MaxValue);
          break;
        }
        if (this.DM.queueBarData[12].bActive)
        {
          if ((int) this.mHeroData.ID == (int) this.DM.RoleAttr.StarUpEventHeroID)
          {
            this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(660U), (ushort) byte.MaxValue);
            break;
          }
          this.GUIM.OpenOKCancelBox((GUIWindow) this, (string) null, this.DM.mStringTable.GetStringByID(491U), 4);
          break;
        }
        if ((int) this.DM.GetLeaderID() == (int) this.mHeroData.ID && (this.mHeroState == eHeroState.Dead || this.mHeroState == eHeroState.Captured))
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(891U), (ushort) byte.MaxValue);
          break;
        }
        byte star = this.mHeroData.Star;
        uint Num2 = (uint) this.DM.Hero_StarCost[(int) this.mHeroData.Star] * 60U;
        float num4 = 0.0f;
        float hour2 = (float) (Num2 / 3600U);
        float num5 = num4 + hour2 * 3600f;
        float min2 = (float) (((double) Num2 - (double) num5) / 60.0);
        float num6 = num5 + min2 * 60f;
        float sec2 = (float) Num2 - num6;
        float day2 = 0.0f;
        if ((double) hour2 >= 24.0)
        {
          day2 = hour2 / 24f;
          hour2 -= (float) ((int) day2 * 24);
        }
        this.needDiamond = this.DM.GetResourceExchange(PriceListType.Time, Num2);
        this.GUIM.OpenSpendWindow_ItemID2((GUIWindow) this, this.DM.mStringTable.GetStringByID(25U), (ushort) 1079, (ushort) 1080, this.needDiamond, (ushort) (byte) day2, (byte) hour2, (byte) min2, (byte) sec2, false, 5, HaveItemText: this.DM.mStringTable.GetStringByID(2912U), NoItemText: this.DM.mStringTable.GetStringByID(2912U), BottomText: this.DM.mStringTable.GetStringByID(2913U));
        break;
      case Btn_Count.btn_DETAIL:
        if (this.mOpenType == (byte) 1)
          break;
        this.GUIM.OpenUISynthesis((int) this.sHero.SoulStone);
        break;
      case Btn_Count.NextBtn:
        if (this.mOpenType == (byte) 1 && this.mOpenKind == (byte) 0)
          break;
        if ((long) this.mHeroDataIndex < (long) (this.DM.CurHeroDataCount - 1U))
        {
          ++this.mHeroDataIndex;
          this.mHeroDataIndex = this.CheckHeroIndex(false, this.mHeroDataIndex);
        }
        else
          this.mHeroDataIndex = 0;
        this.SetHeroData(this.mHeroDataIndex, bOpen: false);
        break;
      case Btn_Count.BackBtn:
        if (this.mOpenType == (byte) 1 && this.mOpenKind == (byte) 0)
          break;
        if (this.mHeroDataIndex == 0)
        {
          this.mHeroDataIndex = (int) this.DM.CurHeroDataCount - 1;
          this.mHeroDataIndex = this.CheckHeroIndex(true, this.mHeroDataIndex);
        }
        else
          --this.mHeroDataIndex;
        this.SetHeroData(this.mHeroDataIndex, bOpen: false);
        break;
      case Btn_Count.btn_HeroAction:
        if ((!((UnityEngine.Object) this.tmpAN != (UnityEngine.Object) null) || this.tmpAN.IsPlaying(this.HeroAct)) && !(this.HeroAct == "idle"))
          break;
        this.HeroActionChang();
        break;
      default:
        switch (btnId1 - 28)
        {
          case Btn_Count.btn_Count:
            this.OpenRankEquip(false);
            return;
          case Btn_Count.btn_EXIT:
            return;
          case Btn_Count.btn_Page1:
            return;
          case Btn_Count.btn_Page2:
            this.SetPage3Info(!this.bHeroInfo);
            return;
          case Btn_Count.btn_Page3:
            this.SetSkillPage(false);
            return;
          case Btn_Count.btn_Evolution:
            this.SetSkillPage(true);
            return;
          default:
            return;
        }
    }
  }

  public int CheckHeroIndex(bool bBack, int mHeroIdx)
  {
    if (mHeroIdx < 0 || (long) mHeroIdx > (long) (this.DM.CurHeroDataCount - 1U))
      mHeroIdx = 0;
    int index = mHeroIdx;
    if (this.mOpenType == (byte) 1 && this.mOpenKind == (byte) 1)
    {
      uint key = this.DM.sortHeroData[index];
      if (this.DM.curHeroData.ContainsKey(key) && !this.CheckTopicHero(this.DM.curHeroData[key].ID))
        index = !bBack ? this.CheckHeroIndex(false, index + 1) : this.CheckHeroIndex(true, index - 1);
    }
    return index;
  }

  public bool CheckTopicHero(ushort HeroID)
  {
    bool flag = false;
    byte num1 = 0;
    byte num2 = 0;
    LevelEX bycurrentPointId = DataManager.StageDataController.GetLevelEXBycurrentPointID((ushort) 0);
    StageConditionData stageConditionData = DataManager.StageDataController.StageDareMode(DataManager.StageDataController.currentPointID) != StageMode.Lean ? DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(bycurrentPointId.NodusTwoID) : DataManager.StageDataController.StageConditionDataTable.GetRecordByKey((ushort) ((int) bycurrentPointId.NodusOneID + (int) DataManager.StageDataController.currentNodus - 1));
    for (int index = 0; index < stageConditionData.ConditionArray.Length; ++index)
    {
      if (stageConditionData.ConditionArray[index].ConditionID == (byte) 1)
      {
        if (stageConditionData.ConditionArray[index].FactorA == (ushort) 0 && !ArenaManager.Instance.CheckHeroAstrology(HeroID, stageConditionData.ConditionArray[index].FactorB) || stageConditionData.ConditionArray[index].FactorA == (ushort) 1 && ArenaManager.Instance.CheckHeroAstrology(HeroID, stageConditionData.ConditionArray[index].FactorB))
          ++num2;
        ++num1;
      }
    }
    if ((int) num1 == (int) num2)
      flag = true;
    return flag;
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    switch (sender.m_BtnID1)
    {
      case 6:
      case 7:
      case 8:
      case 9:
      case 10:
      case 11:
        if (this.mOpenType == (byte) 1 || this.mEnhance.EnhanceNumber == null)
          break;
        this.GUIM.m_ItemInfo.Show(EUIItemInfo.HeroEquip, this.mEnhance.EnhanceNumber[(this.mHeroStratum - 1) * 6 + sender.m_BtnID1 - 6], this.mHeroData.ID, (byte) (sender.m_BtnID1 - 6 + 1));
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (bOK)
    {
      switch (arg1)
      {
        case 1:
          if (this.DM.RoleAttr.Diamond < this.needDiamond)
          {
            this.needDiamond = 0U;
            this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(3966U), (ushort) byte.MaxValue);
            break;
          }
          MessagePacket messagePacket1 = new MessagePacket((ushort) 1024);
          messagePacket1.Protocol = Protocol._MSG_REQUEST_HEROENHANCE_INSTANT;
          messagePacket1.AddSeqId();
          messagePacket1.Add(this.mHeroData.ID);
          messagePacket1.Send();
          this.GUIM.ShowUILock(EUILock.Hero_Info);
          break;
        case 3:
          this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 11);
          break;
        case 4:
          this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 12);
          break;
        case 5:
          if (this.DM.RoleAttr.Diamond < this.needDiamond)
          {
            this.needDiamond = 0U;
            this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(3966U), (ushort) byte.MaxValue);
            break;
          }
          MessagePacket messagePacket2 = new MessagePacket((ushort) 1024);
          messagePacket2.Protocol = Protocol._MSG_REQUEST_HEROSTARUP_INSTANT;
          messagePacket2.AddSeqId();
          messagePacket2.Add(this.mHeroData.ID);
          messagePacket2.Send();
          this.GUIM.ShowUILock(EUILock.Hero_Info);
          break;
        case 6:
          this.door.OpenMenu(EGUIWindow.UI_VIP);
          break;
      }
    }
    else
    {
      switch (arg1)
      {
        case 1:
          MessagePacket messagePacket3 = new MessagePacket((ushort) 1024);
          messagePacket3.Protocol = Protocol._MSG_REQUEST_HEROENHANCE;
          messagePacket3.AddSeqId();
          messagePacket3.Add(this.mHeroData.ID);
          messagePacket3.Send();
          this.GUIM.ShowUILock(EUILock.Hero_Info);
          break;
        case 5:
          MessagePacket messagePacket4 = new MessagePacket((ushort) 1024);
          messagePacket4.Protocol = Protocol._MSG_REQUEST_HEROSTARUP;
          messagePacket4.AddSeqId();
          messagePacket4.Add(this.mHeroData.ID);
          messagePacket4.Send();
          this.GUIM.ShowUILock(EUILock.Hero_Info);
          break;
      }
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        if (NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP))
          break;
        if (this.mOpenType != (byte) 1)
        {
          this.GUIM.UIHero_Index = (int) this.mHeroData.ID;
          DataManager.SortHeroData();
        }
        else if (this.mOpenKind == (byte) 1)
        {
          DataManager.SortConditionHeroData();
          if ((int) this.mHeroData.ID == (int) this.DM.sortHeroData[this.mHeroDataIndex])
            this.GUIM.UIPreviewHero_Index = this.mHeroDataIndex;
          else
            this.GUIM.UIHero_Index = (int) this.mHeroData.ID;
        }
        this.SetHeroData(this.mHeroDataIndex);
        this.mHeroState = this.DM.GetHeroState(this.mHeroData.ID);
        if (this.mHeroState == eHeroState.None)
        {
          ((Component) this.img_HeroState).gameObject.SetActive(false);
          break;
        }
        if (this.mOpenType == (byte) 1)
          ((Graphic) this.img_HeroState).rectTransform.anchoredPosition = new Vector2(((Graphic) this.img_HeroState).rectTransform.anchoredPosition.x, -50f);
        else
          ((Graphic) this.img_HeroState).rectTransform.anchoredPosition = new Vector2(((Graphic) this.img_HeroState).rectTransform.anchoredPosition.x, -121f);
        ((Component) this.img_HeroState).gameObject.SetActive(true);
        switch (this.mHeroState)
        {
          case eHeroState.IsFighting:
            this.img_HeroState.sprite = this.SArray.m_Sprites[32];
            this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(901U);
            return;
          case eHeroState.Captured:
            this.img_HeroState.sprite = this.SArray.m_Sprites[33];
            this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(902U);
            return;
          case eHeroState.Dead:
            this.img_HeroState.sprite = this.SArray.m_Sprites[34];
            this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(903U);
            return;
          default:
            return;
        }
      case NetworkNews.Refresh_Asset:
        if (meg[1] != (byte) 1 || meg[2] != (byte) 2 || (int) GameConstants.ConvertBytesToUShort(meg, 3) != (int) this.sHero.Modle)
          break;
        this.Hero3D_Destroy();
        this.LoadHero3D();
        break;
      case NetworkNews.Refresh_Hero:
        if (NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP))
          break;
        this.mHeroState = this.DM.GetHeroState(this.mHeroData.ID);
        if (this.mHeroState == eHeroState.None)
        {
          ((Component) this.img_HeroState).gameObject.SetActive(false);
          break;
        }
        if (this.mOpenType == (byte) 1)
          ((Graphic) this.img_HeroState).rectTransform.anchoredPosition = new Vector2(((Graphic) this.img_HeroState).rectTransform.anchoredPosition.x, -50f);
        else
          ((Graphic) this.img_HeroState).rectTransform.anchoredPosition = new Vector2(((Graphic) this.img_HeroState).rectTransform.anchoredPosition.x, -121f);
        ((Component) this.img_HeroState).gameObject.SetActive(true);
        switch (this.mHeroState)
        {
          case eHeroState.IsFighting:
            this.img_HeroState.sprite = this.SArray.m_Sprites[32];
            this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(901U);
            return;
          case eHeroState.Captured:
            this.img_HeroState.sprite = this.SArray.m_Sprites[33];
            this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(902U);
            return;
          case eHeroState.Dead:
            this.img_HeroState.sprite = this.SArray.m_Sprites[34];
            this.text_HeroStateHint.text = this.DM.mStringTable.GetStringByID(903U);
            return;
          default:
            return;
        }
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        this.Refresh_FontTexture();
        if ((UnityEngine.Object) this.timeBarRank != (UnityEngine.Object) null && this.timeBarRank.enabled)
          this.timeBarRank.Refresh_FontTexture();
        if (!((UnityEngine.Object) this.timeBarStar != (UnityEngine.Object) null) || !this.timeBarStar.enabled)
          break;
        this.timeBarStar.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.text_Rank != (UnityEngine.Object) null && ((Behaviour) this.text_Rank).enabled)
    {
      ((Behaviour) this.text_Rank).enabled = false;
      ((Behaviour) this.text_Rank).enabled = true;
    }
    if ((UnityEngine.Object) this.text_HeroEXP != (UnityEngine.Object) null && ((Behaviour) this.text_HeroEXP).enabled)
    {
      ((Behaviour) this.text_HeroEXP).enabled = false;
      ((Behaviour) this.text_HeroEXP).enabled = true;
    }
    if ((UnityEngine.Object) this.text_HeroPower != (UnityEngine.Object) null && ((Behaviour) this.text_HeroPower).enabled)
    {
      ((Behaviour) this.text_HeroPower).enabled = false;
      ((Behaviour) this.text_HeroPower).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Lv != (UnityEngine.Object) null && ((Behaviour) this.text_Lv).enabled)
    {
      ((Behaviour) this.text_Lv).enabled = false;
      ((Behaviour) this.text_Lv).enabled = true;
    }
    if ((UnityEngine.Object) this.text_HeroName != (UnityEngine.Object) null && ((Behaviour) this.text_HeroName).enabled)
    {
      ((Behaviour) this.text_HeroName).enabled = false;
      ((Behaviour) this.text_HeroName).enabled = true;
    }
    if ((UnityEngine.Object) this.text_HeroTitle != (UnityEngine.Object) null && ((Behaviour) this.text_HeroTitle).enabled)
    {
      ((Behaviour) this.text_HeroTitle).enabled = false;
      ((Behaviour) this.text_HeroTitle).enabled = true;
    }
    if ((UnityEngine.Object) this.text_NextRankTiTle != (UnityEngine.Object) null && ((Behaviour) this.text_NextRankTiTle).enabled)
    {
      ((Behaviour) this.text_NextRankTiTle).enabled = false;
      ((Behaviour) this.text_NextRankTiTle).enabled = true;
    }
    if ((UnityEngine.Object) this.text_NextRank != (UnityEngine.Object) null && ((Behaviour) this.text_NextRank).enabled)
    {
      ((Behaviour) this.text_NextRank).enabled = false;
      ((Behaviour) this.text_NextRank).enabled = true;
    }
    if ((UnityEngine.Object) this.text_HeroInfo != (UnityEngine.Object) null && ((Behaviour) this.text_HeroInfo).enabled)
    {
      ((Behaviour) this.text_HeroInfo).enabled = false;
      ((Behaviour) this.text_HeroInfo).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Medal != (UnityEngine.Object) null && ((Behaviour) this.text_Medal).enabled)
    {
      ((Behaviour) this.text_Medal).enabled = false;
      ((Behaviour) this.text_Medal).enabled = true;
    }
    if ((UnityEngine.Object) this.text_HeroStarLv != (UnityEngine.Object) null && ((Behaviour) this.text_HeroStarLv).enabled)
    {
      ((Behaviour) this.text_HeroStarLv).enabled = false;
      ((Behaviour) this.text_HeroStarLv).enabled = true;
    }
    if ((UnityEngine.Object) this.text_P3Title != (UnityEngine.Object) null && ((Behaviour) this.text_P3Title).enabled)
    {
      ((Behaviour) this.text_P3Title).enabled = false;
      ((Behaviour) this.text_P3Title).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Skill_Name != (UnityEngine.Object) null && ((Behaviour) this.text_Skill_Name).enabled)
    {
      ((Behaviour) this.text_Skill_Name).enabled = false;
      ((Behaviour) this.text_Skill_Name).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Next_RankSoldier != (UnityEngine.Object) null && ((Behaviour) this.text_Next_RankSoldier).enabled)
    {
      ((Behaviour) this.text_Next_RankSoldier).enabled = false;
      ((Behaviour) this.text_Next_RankSoldier).enabled = true;
    }
    if ((UnityEngine.Object) this.text_HeroStateHint != (UnityEngine.Object) null && ((Behaviour) this.text_HeroStateHint).enabled)
    {
      ((Behaviour) this.text_HeroStateHint).enabled = false;
      ((Behaviour) this.text_HeroStateHint).enabled = true;
    }
    if ((UnityEngine.Object) this.text_HeroPowerHint != (UnityEngine.Object) null && ((Behaviour) this.text_HeroPowerHint).enabled)
    {
      ((Behaviour) this.text_HeroPowerHint).enabled = false;
      ((Behaviour) this.text_HeroPowerHint).enabled = true;
    }
    if ((UnityEngine.Object) this.text_PreviewHero != (UnityEngine.Object) null && ((Behaviour) this.text_PreviewHero).enabled)
    {
      ((Behaviour) this.text_PreviewHero).enabled = false;
      ((Behaviour) this.text_PreviewHero).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((UnityEngine.Object) this.text_Leader[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Leader[index]).enabled)
      {
        ((Behaviour) this.text_Leader[index]).enabled = false;
        ((Behaviour) this.text_Leader[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_SkillPage[index] != (UnityEngine.Object) null && ((Behaviour) this.text_SkillPage[index]).enabled)
      {
        ((Behaviour) this.text_SkillPage[index]).enabled = false;
        ((Behaviour) this.text_SkillPage[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_timeBarRank[index] != (UnityEngine.Object) null && ((Behaviour) this.text_timeBarRank[index]).enabled)
      {
        ((Behaviour) this.text_timeBarRank[index]).enabled = false;
        ((Behaviour) this.text_timeBarRank[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_timeBarStar[index] != (UnityEngine.Object) null && ((Behaviour) this.text_timeBarStar[index]).enabled)
      {
        ((Behaviour) this.text_timeBarStar[index]).enabled = false;
        ((Behaviour) this.text_timeBarStar[index]).enabled = true;
      }
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((UnityEngine.Object) this.text_Skill_Lock[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Skill_Lock[index]).enabled)
      {
        ((Behaviour) this.text_Skill_Lock[index]).enabled = false;
        ((Behaviour) this.text_Skill_Lock[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Hint[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Hint[index]).enabled)
      {
        ((Behaviour) this.text_Hint[index]).enabled = false;
        ((Behaviour) this.text_Hint[index]).enabled = true;
      }
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((UnityEngine.Object) this.text_Skill_Lv[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Skill_Lv[index]).enabled)
      {
        ((Behaviour) this.text_Skill_Lv[index]).enabled = false;
        ((Behaviour) this.text_Skill_Lv[index]).enabled = true;
      }
    }
    for (int index = 0; index < 6; ++index)
    {
      if ((UnityEngine.Object) this.text_Equip[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Equip[index]).enabled)
      {
        ((Behaviour) this.text_Equip[index]).enabled = false;
        ((Behaviour) this.text_Equip[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Property[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Property[index]).enabled)
      {
        ((Behaviour) this.text_Property[index]).enabled = false;
        ((Behaviour) this.text_Property[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ShowEffect[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ShowEffect[index]).enabled)
      {
        ((Behaviour) this.text_ShowEffect[index]).enabled = false;
        ((Behaviour) this.text_ShowEffect[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.btn_Equip[index] != (UnityEngine.Object) null && ((Behaviour) this.btn_Equip[index]).enabled)
        this.btn_Equip[index].Refresh_FontTexture();
    }
    for (int index = 0; index < 8; ++index)
    {
      if ((UnityEngine.Object) this.text_Skill2_[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Skill2_[index]).enabled)
      {
        ((Behaviour) this.text_Skill2_[index]).enabled = false;
        ((Behaviour) this.text_Skill2_[index]).enabled = true;
      }
    }
    for (int index = 0; index < 10; ++index)
    {
      if ((UnityEngine.Object) this.text_P3p2_Property[index] != (UnityEngine.Object) null && ((Behaviour) this.text_P3p2_Property[index]).enabled)
      {
        ((Behaviour) this.text_P3p2_Property[index]).enabled = false;
        ((Behaviour) this.text_P3p2_Property[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_P3p2_PropertyValue[index] != (UnityEngine.Object) null && ((Behaviour) this.text_P3p2_PropertyValue[index]).enabled)
      {
        ((Behaviour) this.text_P3p2_PropertyValue[index]).enabled = false;
        ((Behaviour) this.text_P3p2_PropertyValue[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_tmpStr[index] != (UnityEngine.Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
  }

  public float SelectTween(float t, float b, float c, float d)
  {
    t /= d;
    return b + c * t;
  }

  private void Update()
  {
    if (this.OpenPage == (byte) 0)
    {
      if ((UnityEngine.Object) this.Pagedata[this.mNowpage] == (UnityEngine.Object) null)
      {
        this.LoadPage(this.mNowpage);
        this.Pagedata[this.mNowpage].gameObject.SetActive(true);
      }
      this.OpenPage = (byte) 1;
    }
    this.PageBGTime += Time.smoothDeltaTime;
    if ((double) this.PageBGTime >= 0.0)
    {
      if ((double) this.PageBGTime >= 2.0)
        this.PageBGTime = 0.0f;
      ((Graphic) this.img_PageBG[this.mNowpage]).color = new Color(1f, 1f, 1f, (double) this.PageBGTime <= 1.0 ? this.PageBGTime : 2f - this.PageBGTime);
    }
    if (!this.ABIsDone && this.AR != null && this.AR.isDone)
    {
      this.go2 = (GameObject) UnityEngine.Object.Instantiate(this.AR.asset);
      this.go2.transform.SetParent(this.Hero_Pos, false);
      this.go2.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
      {
        eulerAngles = new Vector3(0.0f, (float) this.sHero.Camera_Horizontal, 0.0f)
      };
      this.go2.transform.localScale = new Vector3((float) this.sHero.CameraScaleRate, (float) this.sHero.CameraScaleRate, (float) this.sHero.CameraScaleRate);
      this.go2.transform.localPosition = Vector3.zero;
      this.GUIM.SetLayer(this.go2, 5);
      this.Hero_PosRT.anchoredPosition = new Vector2(this.Hero_PosRT.anchoredPosition.x, (float) (-180 - (1000 - (int) this.sHero.CameraDistance)));
      this.Tmp = this.Hero_Pos.GetChild(0);
      this.Hero_Model = this.Tmp.GetComponent<Transform>();
      if ((UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null)
      {
        this.tmpAN = this.Hero_Model.GetComponent<Animation>();
        this.tmpAN.wrapMode = WrapMode.Loop;
        this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
        this.tmpAN.Play(this.mHeroAct[0]);
        this.tmpAN.clip = this.tmpAN.GetClip(this.mHeroAct[0]);
        if (this.Hero_Pos.gameObject.activeSelf)
        {
          SkinnedMeshRenderer componentInChildren = this.Hero_Model.GetComponentInChildren<SkinnedMeshRenderer>();
          componentInChildren.useLightProbes = false;
          componentInChildren.updateWhenOffscreen = true;
        }
      }
      this.ABIsDone = true;
    }
    if (this.ABIsDone && (UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null && (!this.tmpAN.IsPlaying(this.HeroAct) || this.HeroAct == "idle") && (double) this.ActionTimeRandom < 0.0001)
    {
      this.ActionTimeRandom = (float) UnityEngine.Random.Range(3, 7);
      this.ActionTime = 0.0f;
    }
    if ((double) this.ActionTimeRandom > 0.0001)
    {
      this.ActionTime += Time.smoothDeltaTime;
      if ((double) this.ActionTime >= (double) this.ActionTimeRandom)
        this.HeroActionChang();
    }
    if (this.ABIsDone && (UnityEngine.Object) this.Hero_Model != (UnityEngine.Object) null && (double) this.MovingTimer > 0.0)
    {
      this.MovingTimer -= Time.deltaTime;
      if ((double) this.MovingTimer <= 0.0)
      {
        this.tmpAN.CrossFade("idle");
        this.HeroAct = "idle";
      }
    }
    if (this.mNowpage == 0 && (bool) (UnityEngine.Object) this.Pagedata[0])
    {
      if (((UIBehaviour) this.btn_Rank_Exit).IsActive())
        this.Rank_ImgT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
      if (((UIBehaviour) this.RankLightBG).IsActive())
        this.Equip_ImgT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
      if (((UIBehaviour) this.StarStratumLightBG).IsActive())
        this.Star_ImgT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
      if (((UIBehaviour) this.Img_StarEvolution).IsActive())
      {
        this.ShowStarEvolution += Time.smoothDeltaTime;
        if ((double) this.ShowStarEvolution >= 0.0)
        {
          if ((double) this.ShowStarEvolution >= 2.0)
            this.ShowStarEvolution = 0.0f;
          ((Graphic) this.Img_StarEvolution).color = new Color(1f, 1f, 1f, (double) this.ShowStarEvolution <= 1.0 ? this.ShowStarEvolution : 2f - this.ShowStarEvolution);
        }
      }
      if (this.bShowEquipLight)
        this.ShowEquipLight += Time.smoothDeltaTime;
      for (int index = 0; index < 6; ++index)
      {
        if (((UIBehaviour) this.img_EquipHave_Light[index]).IsActive() && (double) this.ShowEquipLight >= 0.0)
        {
          if ((double) this.ShowEquipLight >= 2.0)
            this.ShowEquipLight = 0.0f;
          float a = (double) this.ShowEquipLight <= 1.0 ? this.ShowEquipLight : 2f - this.ShowEquipLight;
          ((Graphic) this.img_EquipHave_Light[index]).color = new Color(1f, 1f, 1f, a);
        }
        if (((UIBehaviour) this.img_EquipLight[index]).IsActive())
        {
          this.EquipShow[index] += Time.smoothDeltaTime;
          if (this.Btn_Eq[index])
          {
            if ((double) this.EquipShow[index] > 0.20000000298023224)
            {
              this.btn_EquipRT[index].sizeDelta = new Vector2(70f, 70f);
              this.Btn_Eq[index] = false;
            }
            else
            {
              this.EquipShowSCale[index] = this.SelectTween(this.EquipShow[index], 70f, 14f, 0.2f);
              this.btn_EquipRT[index].sizeDelta = new Vector2(this.EquipShowSCale[index], this.EquipShowSCale[index]);
            }
          }
          if ((double) this.EquipShow[index] > 0.40000000596046448)
          {
            ((Component) this.img_EquipLight[index]).gameObject.SetActive(false);
            ((Graphic) this.img_EquipLight[index]).color = new Color(1f, 1f, 1f, 1f);
            this.Img_EquipLightRT[index].sizeDelta = new Vector2(106f, 106f);
          }
          else
          {
            this.EquipShowSCale[index] = this.SelectTween(this.EquipShow[index], 106f, 106f, 0.4f);
            this.Img_EquipLightRT[index].sizeDelta = new Vector2(this.EquipShowSCale[index], this.EquipShowSCale[index]);
            this.EquipShowSCale[index] = this.SelectTween(this.EquipShow[index], 1f, -1f, 0.4f);
            ((Graphic) this.img_EquipLight[index]).color = new Color(1f, 1f, 1f, this.EquipShowSCale[index]);
          }
        }
      }
    }
    if (this.mNowpage == 1 && (bool) (UnityEngine.Object) this.Pagedata[1])
    {
      this.Skill_ImgT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
      this.SkillPageTime += Time.smoothDeltaTime;
      if ((double) this.SkillPageTime >= 0.0)
      {
        if ((double) this.SkillPageTime >= 2.0)
          this.SkillPageTime = 0.0f;
        ((Graphic) this.img_SkillPage[this.mSkillpage]).color = new Color(1f, 1f, 1f, (double) this.SkillPageTime <= 1.0 ? this.SkillPageTime : 2f - this.SkillPageTime);
      }
    }
    this.TmpTime += Time.smoothDeltaTime * 40f;
    if ((double) this.TmpTime >= 40.0)
      this.TmpTime = 0.0f;
    float num1 = (double) this.TmpTime <= 20.0 ? this.TmpTime : 40f - this.TmpTime;
    if ((double) num1 < 0.0)
      num1 = 0.0f;
    this.Vec3Instance.Set(this.MoveTime1 - num1, this.btn_NextT.localPosition.y, this.btn_NextT.localPosition.z);
    this.btn_NextT.localPosition = this.Vec3Instance;
    this.Vec3Instance.Set(this.MoveTime2 + num1, this.btn_BackT.localPosition.y, this.btn_BackT.localPosition.z);
    this.btn_BackT.localPosition = this.Vec3Instance;
    if (this.mShowEffectNum > 0)
    {
      this.mShowEffectTime += Time.smoothDeltaTime;
      for (int index = 0; index < 6; ++index)
      {
        if (((UIBehaviour) this.text_ShowEffect[index]).IsActive())
        {
          if ((double) ((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition.y >= -50.0 && (double) ((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition.y < -20.0)
            ((Graphic) this.text_ShowEffect[index]).color = new Color(0.4f, 0.83f, 0.4f, (float) ((-20.0 - (double) ((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition.y) / 30.0));
          else if ((double) ((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition.y >= -20.0)
          {
            ((Component) this.text_ShowEffect[index]).gameObject.SetActive(false);
            --this.mShowEffectNum;
          }
          ((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition.x, (float) (((double) this.mShowEffectTime - (double) index * 0.20000000298023224) * 200.0 - 200.0));
        }
        else if ((double) this.mShowEffectTime >= (double) index * 0.20000000298023224 && (double) ((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition.y == -200.0)
          ((Component) this.text_ShowEffect[index]).gameObject.SetActive(true);
      }
    }
    if (!((UnityEngine.Object) this.text_PreviewHero != (UnityEngine.Object) null) || !((UnityEngine.Object) this.img_PreviewBG != (UnityEngine.Object) null) || !((Component) this.img_PreviewBG).gameObject.activeSelf)
      return;
    this.PreviewTime += Time.smoothDeltaTime;
    if ((double) this.PreviewTime < 0.0)
      return;
    if ((double) this.PreviewTime >= 3.0999999046325684)
      this.PreviewTime = 0.0f;
    float num2 = 1f;
    if ((double) this.PreviewTime > 0.5)
      num2 = (double) this.PreviewTime <= 1.7999999523162842 ? (float) (0.25 + (1.2999999523162842 - ((double) this.PreviewTime - 0.5)) / 1.2999999523162842 * 0.75) : (float) (0.25 + ((double) this.PreviewTime - 0.5 - 1.2999999523162842) / 1.2999999523162842 * 0.75);
    float a1 = Mathf.Clamp(num2, 0.25f, 1f);
    ((Graphic) this.img_PreviewBG).color = new Color(1f, 1f, 0.518f, a1);
    ((Graphic) this.text_PreviewHero).color = new Color(1f, 1f, 0.518f, a1);
  }

  public void OnTimer(UITimeBar sender)
  {
    if (sender.m_TimeBarID == 1)
    {
      this.bFSetRankTimeBar = true;
      this.timeBarRank.gameObject.SetActive(false);
    }
    else
    {
      this.bFSetStarTimeBar = true;
      this.timeBarStar.gameObject.SetActive(false);
    }
  }

  public void OnNotify(UITimeBar sender)
  {
    if (sender.m_TimeBarID == 1)
      this.GUIM.SetTimerSpriteType(this.timeBarRank, DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.HeroEnhance));
    else
      this.GUIM.SetTimerSpriteType(this.timeBarStar, DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.HeroEvolution));
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((UnityEngine.Object) this.ScrollItemT[panelObjectIdx] == (UnityEngine.Object) null)
    {
      this.ScrollItemT[panelObjectIdx] = item.GetComponent<Transform>();
      this.text_P3p2_Property[panelObjectIdx] = this.ScrollItemT[panelObjectIdx].GetChild(0).GetChild(0).GetComponent<UIText>();
      this.text_P3p2_Property[panelObjectIdx].font = this.TTFont;
      this.text_P3p2_PropertyValue[panelObjectIdx] = this.ScrollItemT[panelObjectIdx].GetChild(1).GetChild(0).GetComponent<UIText>();
      this.text_P3p2_PropertyValue[panelObjectIdx].font = this.TTFont;
      this.mbtn_Item[panelObjectIdx] = this.ScrollItemT[panelObjectIdx].GetChild(3).GetComponent<UIButton>();
      this.mbtn_Item[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.mbtn_Item[panelObjectIdx].m_BtnID1 = 43;
      this.mbtn_Item[panelObjectIdx].m_BtnID2 = 43 + dataIdx;
      this.mbtnH_Item[panelObjectIdx] = this.ScrollItemT[panelObjectIdx].GetChild(3).GetComponent<UIButtonHint>();
      this.mbtnH_Item[panelObjectIdx].m_Handler = (MonoBehaviour) this;
      this.mbtnH_Item[panelObjectIdx].ControlFadeOut = ((Component) this.PropertyInfo_Hint).gameObject;
    }
    if (!((UnityEngine.Object) this.text_P3p2_Property[panelObjectIdx] != (UnityEngine.Object) null))
      return;
    this.Cstr_ItemPropertyValue[panelObjectIdx].ClearString();
    this.mbtn_Item[panelObjectIdx].m_BtnID2 = 43 + dataIdx;
    if (dataIdx == 0)
    {
      this.text_P3p2_Property[panelObjectIdx].text = this.DM.mStringTable.GetStringByID(125U);
      StringManager.IntToStr(this.Cstr_ItemPropertyValue[panelObjectIdx], (long) this.HP, bNumber: true);
      this.text_P3p2_PropertyValue[panelObjectIdx].text = this.Cstr_ItemPropertyValue[panelObjectIdx].ToString();
    }
    else
    {
      ushort num = this.pAttrIdx[dataIdx];
      if (this.pAttrIdx[dataIdx] >= (ushort) 23)
        num -= (ushort) 3;
      this.text_P3p2_Property[panelObjectIdx].text = this.DM.mStringTable.GetStringByID((uint) (ushort) (123U + (uint) num));
      StringManager.IntToStr(this.Cstr_ItemPropertyValue[panelObjectIdx], (long) this.pAttr[(int) this.pAttrIdx[dataIdx]], bNumber: true);
      this.text_P3p2_PropertyValue[panelObjectIdx].text = this.Cstr_ItemPropertyValue[panelObjectIdx].ToString();
    }
    this.text_P3p2_PropertyValue[panelObjectIdx].SetAllDirty();
    this.text_P3p2_PropertyValue[panelObjectIdx].cachedTextGenerator.Invalidate();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void ClearShowEffect()
  {
    this.mShowEffectTime = 0.0f;
    this.mShowEffectNum = 0;
    for (int index = 0; index < 6; ++index)
    {
      this.text_ShowEffect[index].text = string.Empty;
      this.text_ShowEffect[index].SetAllDirty();
      this.text_ShowEffect[index].cachedTextGenerator.Invalidate();
      ((Component) this.text_ShowEffect[index]).gameObject.SetActive(false);
      ((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition.x, -200f);
      ((Graphic) this.text_ShowEffect[index]).color = new Color(0.4f, 0.83f, 0.4f, 1f);
    }
  }

  public void AddShowEffect(byte Kind, int ItemIdx = 0)
  {
    this.ClearShowEffect();
    this.HeroActionChang(true);
    switch (Kind)
    {
      case 0:
        this.mEquip = this.DM.EquipTable.GetRecordByKey(this.mEnhance.EnhanceNumber[(this.mHeroStratum - 1) * 6 + ItemIdx]);
        int index1 = 0;
        for (int index2 = 0; index2 < this.mEquip.PropertiesInfo.Length; ++index2)
        {
          if (this.mEquip.PropertiesInfo[index2].Propertieskey != (ushort) 0)
          {
            int propertiesValue = (int) this.mEquip.PropertiesInfo[index2].PropertiesValue;
            this.Cstr_ShowEffect[index2].ClearString();
            this.meffect = this.DM.EffectData.GetRecordByKey(this.mEquip.PropertiesInfo[index2].Propertieskey);
            this.Cstr_ShowEffect[index2].IntToFormat((long) propertiesValue);
            this.Cstr_ShowEffect[index2].AppendFormat(this.DM.mStringTable.GetStringByID((uint) this.meffect.String_infoID));
            this.text_ShowEffect[index1].text = this.Cstr_ShowEffect[index2].ToString();
            this.text_ShowEffect[index1].SetAllDirty();
            this.text_ShowEffect[index1].cachedTextGenerator.Invalidate();
            ++index1;
            ++this.mShowEffectNum;
          }
        }
        break;
      case 1:
        for (int index3 = 0; index3 < 3; ++index3)
        {
          this.Cstr_ShowEffect[index3].ClearString();
          this.Cstr_ShowEffect[index3].Append(this.DM.mStringTable.GetStringByID((uint) (122 + index3)));
          this.Cstr_ShowEffect[index3].IntToFormat(2L);
          this.Cstr_ShowEffect[index3].AppendFormat("+{0}");
          this.text_ShowEffect[index3].text = this.Cstr_ShowEffect[index3].ToString();
          this.text_ShowEffect[index3].SetAllDirty();
          this.text_ShowEffect[index3].cachedTextGenerator.Invalidate();
          ++this.mShowEffectNum;
        }
        this.Cstr_ShowEffect[3].ClearString();
        this.Cstr_ShowEffect[3].Append(this.DM.mStringTable.GetStringByID(343U));
        this.Cstr_ShowEffect[3].IntToFormat((long) ((int) this.DM.RankSoldiers[(int) this.mHeroData.Enhance] - (int) this.DM.RankSoldiers[(int) this.mHeroData.Enhance - 1]));
        if (this.GUIM.IsArabic)
          this.Cstr_ShowEffect[3].AppendFormat("{0}+");
        else
          this.Cstr_ShowEffect[3].AppendFormat("+{0}");
        this.text_ShowEffect[3].text = this.Cstr_ShowEffect[3].ToString();
        this.text_ShowEffect[3].SetAllDirty();
        this.text_ShowEffect[3].cachedTextGenerator.Invalidate();
        ++this.mShowEffectNum;
        break;
      case 2:
        for (int index4 = 0; index4 < 3; ++index4)
        {
          if ((int) this.pAttr[index4] - (int) this.ShowEffectpAttr[index4] != 0)
          {
            this.Cstr_ShowEffect[this.mShowEffectNum].ClearString();
            this.Cstr_ShowEffect[this.mShowEffectNum].Append(this.DM.mStringTable.GetStringByID((uint) (122 + index4)));
            this.Cstr_ShowEffect[this.mShowEffectNum].IntToFormat((long) ((int) this.pAttr[index4] - (int) this.ShowEffectpAttr[index4]));
            this.Cstr_ShowEffect[this.mShowEffectNum].AppendFormat("+{0}");
            this.text_ShowEffect[this.mShowEffectNum].text = this.Cstr_ShowEffect[this.mShowEffectNum].ToString();
            this.text_ShowEffect[this.mShowEffectNum].SetAllDirty();
            this.text_ShowEffect[this.mShowEffectNum].cachedTextGenerator.Invalidate();
            ++this.mShowEffectNum;
          }
        }
        break;
    }
    this.mParticleEffectpAttr = ParticleManager.Instance.Spawn((ushort) 372, this.GameT.GetChild(13), new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
    this.GUIM.SetLayer(this.mParticleEffectpAttr, 5);
    this.mParticleEffectpAttr.transform.localPosition = new Vector3(0.0f, -230f, 1000f);
    this.mParticleEffectpAttr.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
    {
      eulerAngles = new Vector3(0.0f, 0.0f, 0.0f)
    };
    this.mParticleEffectpAttr.gameObject.SetActive(true);
    AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.mHeroData = this.DM.curHeroData[this.DM.sortHeroData[this.mHeroDataIndex]];
        if (this.mOpenType == (byte) 1)
        {
          this.mHeroData.Level = this.DM.PreviewHeroData.Level;
          this.mHeroData.Enhance = this.DM.PreviewHeroData.Enhance;
          this.mHeroData.Star = this.DM.PreviewHeroData.Star;
          this.mHeroData.Equip = this.DM.PreviewHeroData.Equip;
          this.mHeroData.SkillLV[0] = this.DM.PreviewHeroData.SkillLV[0];
          this.mHeroData.SkillLV[1] = this.DM.PreviewHeroData.SkillLV[1];
          this.mHeroData.SkillLV[2] = this.DM.PreviewHeroData.SkillLV[2];
          this.mHeroData.SkillLV[3] = this.DM.PreviewHeroData.SkillLV[3];
        }
        this.mHeroStratum = (int) this.mHeroData.Enhance;
        this.AddShowEffect((byte) 0, arg2);
        this.SetStratum(this.mHeroStratum);
        this.ReSetBtnState();
        this.UpdatePower();
        ((Component) this.img_EquipLight[arg2]).gameObject.SetActive(true);
        this.EquipShow[arg2] = 0.0f;
        this.Btn_Eq[arg2] = true;
        AudioManager.Instance.PlayUISFX(UIKind.EquipTake);
        NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, (object) this);
        break;
      case 2:
        this.CheckRankTimeBar();
        ((Component) this.RankLightBG).gameObject.SetActive(false);
        NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, (object) this);
        break;
      case 3:
        if (this.mOpenType == (byte) 1)
          break;
        this.mHeroData = this.DM.curHeroData[(uint) this.mHeroData.ID];
        this.mHeroStratum = (int) this.mHeroData.Enhance;
        this.btn_Fragment.image.sprite = this.SArray.m_Sprites[9 + this.mHeroStratum];
        if ((int) this.mHeroData.ID != (int) this.DM.RoleAttr.EnhanceEventHeroID && (int) this.mHeroData.ID != arg2)
          break;
        this.AddShowEffect((byte) 1);
        if ((UnityEngine.Object) this.Pagedata[0] != (UnityEngine.Object) null)
        {
          this.SetStratum(this.mHeroStratum);
          this.ReSetBtnState();
          this.CheckRankTimeBar();
        }
        this.UpdatePower();
        if (!((UnityEngine.Object) this.Pagedata[1] != (UnityEngine.Object) null))
          break;
        this.ReSetSkill();
        this.Cstr_Leader.ClearString();
        this.Cstr_Leader.IntToFormat((long) this.DM.RankSoldiers[(int) this.mHeroData.Enhance]);
        if (this.GUIM.IsArabic)
          this.Cstr_Leader.AppendFormat("{0}+");
        else
          this.Cstr_Leader.AppendFormat("+{0}");
        this.text_Leader[0].text = this.Cstr_Leader.ToString();
        this.text_Leader[0].SetAllDirty();
        this.text_Leader[0].cachedTextGenerator.Invalidate();
        break;
      case 4:
        this.CheckStarTimeBar();
        ((Component) this.StarStratumLightBG).gameObject.SetActive(false);
        this.Cstr_HeroStarLv.ClearString();
        if (this.GUIM.IsArabic)
        {
          this.Cstr_HeroStarLv.FloatToFormat(this.MaxStar);
          this.Cstr_HeroStarLv.IntToFormat((long) this.DM.GetCurItemQuantity(this.sHero.SoulStone, (byte) 0));
        }
        else
        {
          this.Cstr_HeroStarLv.IntToFormat((long) this.DM.GetCurItemQuantity(this.sHero.SoulStone, (byte) 0));
          this.Cstr_HeroStarLv.FloatToFormat(this.MaxStar);
        }
        this.Cstr_HeroStarLv.AppendFormat("{0} / {1}");
        this.text_HeroStarLv.text = this.Cstr_HeroStarLv.ToString();
        this.text_HeroStarLv.SetAllDirty();
        this.text_HeroStarLv.cachedTextGenerator.Invalidate();
        break;
      case 5:
        if (this.mOpenType == (byte) 1)
          break;
        this.mHeroData = this.DM.curHeroData[(uint) this.mHeroData.ID];
        this.mHeroStratum = (int) this.mHeroData.Enhance;
        if ((int) this.mHeroData.ID != (int) this.DM.RoleAttr.StarUpEventHeroID && (int) this.mHeroData.ID != arg2)
          break;
        if ((UnityEngine.Object) this.Pagedata[0] != (UnityEngine.Object) null)
        {
          if (this.mHeroData.Star < (byte) 5)
            this.MaxStar = (float) this.DM.Medal[(int) this.mHeroData.Star];
          this.SetStarStratum((int) this.DM.GetCurItemQuantity(this.sHero.SoulStone, (byte) 0), (int) this.mHeroData.Star);
          this.CheckStarTimeBar();
        }
        this.mHeroId = this.mHeroData.ID;
        this.mCalcAttrData.SkillLV1 = this.mHeroData.SkillLV[0];
        this.mCalcAttrData.SkillLV2 = this.mHeroData.SkillLV[1];
        this.mCalcAttrData.SkillLV3 = this.mHeroData.SkillLV[2];
        this.mCalcAttrData.SkillLV4 = this.mHeroData.SkillLV[3];
        for (int index = 0; index < 4; ++index)
          this.SkillLv[index] = this.mHeroData.SkillLV[index];
        this.mCalcAttrData.LV = this.mHeroData.Level;
        this.mCalcAttrData.Star = (byte) ((uint) this.mHeroData.Star - 1U);
        this.mCalcAttrData.Enhance = this.mHeroData.Enhance;
        this.mCalcAttrData.Equip = this.mHeroData.Equip;
        uint HP1 = 0;
        Array.Clear((Array) this.EquipEffect_pAttr, 0, this.EquipEffect_pAttr.Length);
        this.mBs.setCalculateHeroEquipEffect(this.mHeroId, this.mHeroData.Enhance, this.mHeroData.Equip, ref HP1, this.EquipEffect_pAttr);
        uint HP2 = 0;
        Array.Clear((Array) this.pAttr, 0, this.pAttr.Length);
        this.mBs.setCalculateAttribute(this.mHeroId, ref this.mCalcAttrData, ref HP2, this.pAttr);
        for (int index = 0; index < 3; ++index)
          this.ShowEffectpAttr[index] = this.pAttr[index];
        this.UpdatePower();
        this.AddShowEffect((byte) 2);
        break;
      case 6:
        if ((int) this.mHeroData.ID != arg2)
          break;
        this.mHeroData = this.DM.curHeroData[(uint) arg2];
        if (this.mOpenType == (byte) 1)
        {
          this.mHeroData.Level = this.DM.PreviewHeroData.Level;
          this.mHeroData.Enhance = this.DM.PreviewHeroData.Enhance;
          this.mHeroData.Star = this.DM.PreviewHeroData.Star;
          this.mHeroData.Equip = this.DM.PreviewHeroData.Equip;
          this.mHeroData.SkillLV[0] = this.DM.PreviewHeroData.SkillLV[0];
          this.mHeroData.SkillLV[1] = this.DM.PreviewHeroData.SkillLV[1];
          this.mHeroData.SkillLV[2] = this.DM.PreviewHeroData.SkillLV[2];
          this.mHeroData.SkillLV[3] = this.DM.PreviewHeroData.SkillLV[3];
        }
        this.SetHeroEXP(this.mHeroData.Exp);
        this.UpdatePower();
        if (!((UnityEngine.Object) this.Pagedata[1] != (UnityEngine.Object) null))
          break;
        this.ReSetSkill();
        break;
      case 7:
        if (arg2 != (int) this.mHeroId)
          break;
        this.bFSetRankTimeBar = true;
        this.GUIM.RemoverTimeBaarToList(this.timeBarRank);
        this.CheckRankTimeBar();
        ((Component) this.RankLightBG).gameObject.SetActive(true);
        this.timeBarRank.gameObject.SetActive(false);
        break;
      case 8:
        if (arg2 != (int) this.mHeroId)
          break;
        this.bFSetStarTimeBar = true;
        this.GUIM.RemoverTimeBaarToList(this.timeBarStar);
        this.CheckStarTimeBar();
        ((Component) this.StarStratumLightBG).gameObject.SetActive(true);
        ((Component) this.StarEvolutionRT).gameObject.SetActive(true);
        this.Cstr_HeroStarLv.ClearString();
        if (this.GUIM.IsArabic)
        {
          this.Cstr_HeroStarLv.FloatToFormat(this.MaxStar);
          this.Cstr_HeroStarLv.IntToFormat((long) this.DM.GetCurItemQuantity(this.sHero.SoulStone, (byte) 0));
        }
        else
        {
          this.Cstr_HeroStarLv.IntToFormat((long) this.DM.GetCurItemQuantity(this.sHero.SoulStone, (byte) 0));
          this.Cstr_HeroStarLv.FloatToFormat(this.MaxStar);
        }
        this.Cstr_HeroStarLv.AppendFormat("{0} / {1}");
        this.text_HeroStarLv.text = this.Cstr_HeroStarLv.ToString();
        this.text_HeroStarLv.SetAllDirty();
        this.text_HeroStarLv.cachedTextGenerator.Invalidate();
        break;
      case 9:
        this.OpenUISynthesis = true;
        break;
    }
  }

  public override bool OnBackButtonClick()
  {
    if (((UIBehaviour) this.btn_Rank_Exit).IsActive())
      this.OpenRankEquip(false);
    this.OpenUISynthesis = false;
    this.mHeroDataIndex = -1;
    return false;
  }

  public void Onfunc(UITimeBar sender)
  {
    if (sender.m_TimeBarID == 1)
    {
      if (sender.m_TimerSpriteType == eTimerSpriteType.Speed)
      {
        this.OpenUISynthesis = true;
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 11);
      }
      else
      {
        if (sender.m_TimerSpriteType != eTimerSpriteType.Free)
          return;
        this.DM.SendHeroEnhance_Free();
      }
    }
    else if (sender.m_TimerSpriteType == eTimerSpriteType.Speed)
    {
      this.OpenUISynthesis = true;
      this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 12);
    }
    else
    {
      if (sender.m_TimerSpriteType != eTimerSpriteType.Free)
        return;
      this.DM.SendHeroStarUp_Free();
    }
  }

  public void OnCancel(UITimeBar sender)
  {
    if (sender.m_TimeBarID == 1)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_HEROENHANCE_CANCEL;
      messagePacket.AddSeqId();
      messagePacket.Add(this.mHeroData.ID);
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Hero_Info);
    }
    else
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_HEROSTARUP_CANCEL;
      messagePacket.AddSeqId();
      messagePacket.Add(this.mHeroData.ID);
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Hero_Info);
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    switch (button.m_BtnID1)
    {
      case 15:
      case 16:
      case 17:
      case 18:
        if (this.sHero.AttackPower != null)
          this.mSkill = this.DM.SkillTable.GetRecordByKey(this.sHero.AttackPower[button.m_BtnID1 - 15 + 1]);
        ushort HeroAttrValA = GameConstants.SetHintValue(this.pAttr, this.mSkill.HurtKind, true);
        ushort HeroAttrValB = GameConstants.SetHintValue(this.pAttr, this.mSkill.HurtKind, false);
        if (this.mOpenType == (byte) 1)
        {
          this.GUIM.m_SkillInfo.Show(sender, (uint) this.mHeroData.ID, (byte) (button.m_BtnID1 - 15), HeroAttrValA, HeroAttrValB, true);
          break;
        }
        this.GUIM.m_SkillInfo.Show(sender, (uint) this.mHeroData.ID, (byte) (button.m_BtnID1 - 15), HeroAttrValA, HeroAttrValB);
        break;
      case 34:
      case 35:
      case 36:
      case 37:
        if (this.mOpenType == (byte) 1)
        {
          this.GUIM.m_SkillInfo.Show(sender, (uint) this.mHeroData.ID, (byte) (button.m_BtnID1 - 34 + 4), (ushort) 0, (ushort) 0, true);
          break;
        }
        this.GUIM.m_SkillInfo.Show(sender, (uint) this.mHeroData.ID, (byte) (button.m_BtnID1 - 34 + 4), (ushort) 0, (ushort) 0);
        break;
      case 38:
        if (((UIBehaviour) this.Property_Hint).IsActive())
          break;
        ((Component) this.Property_Hint).gameObject.SetActive(true);
        if (((UIBehaviour) this.Fragment_Hint).IsActive())
          ((Component) this.Fragment_Hint).gameObject.SetActive(false);
        if (((UIBehaviour) this.HeroState_Hint).IsActive())
          ((Component) this.HeroState_Hint).gameObject.SetActive(false);
        if (!((UIBehaviour) this.HeroPower_Hint).IsActive())
          break;
        ((Component) this.HeroPower_Hint).gameObject.SetActive(false);
        break;
      case 39:
        if (((UIBehaviour) this.Fragment_Hint).IsActive())
          break;
        ((Component) this.Fragment_Hint).gameObject.SetActive(true);
        if (((UIBehaviour) this.Property_Hint).IsActive())
          ((Component) this.Property_Hint).gameObject.SetActive(false);
        if (((UIBehaviour) this.HeroState_Hint).IsActive())
          ((Component) this.HeroState_Hint).gameObject.SetActive(false);
        if (!((UIBehaviour) this.HeroPower_Hint).IsActive())
          break;
        ((Component) this.HeroPower_Hint).gameObject.SetActive(false);
        break;
      case 40:
      case 41:
      case 42:
        if (!((UIBehaviour) this.PropertyInfo_Hint).IsActive())
          ((Component) this.PropertyInfo_Hint).gameObject.SetActive(true);
        this.Cstr_Hint.ClearString();
        this.Cstr_Hint.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (ushort) (122 + button.m_BtnID1 - 40)));
        this.Cstr_Hint.IntToFormat((long) ((int) this.pAttr[button.m_BtnID1 - 40] - (int) this.EquipEffect_pAttr[button.m_BtnID1 - 40]), bNumber: true);
        if (this.EquipEffect_pAttr[button.m_BtnID1 - 40] > (ushort) 0)
        {
          this.Cstr_Hint.IntToFormat((long) this.EquipEffect_pAttr[button.m_BtnID1 - 40]);
          this.Cstr_Hint.AppendFormat("<color=#FFF799>{0}</color> {1}<color=#33EB67>+{2}</color>\n");
        }
        else
          this.Cstr_Hint.AppendFormat("<color=#FFF799>{0}</color> {1}\n");
        this.Cstr_Hint.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (ushort) (381 + button.m_BtnID1 - 40)));
        this.Cstr_Hint.AppendFormat("{0}");
        this.text_Hint[2].text = this.Cstr_Hint.ToString();
        this.text_Hint[2].SetAllDirty();
        this.text_Hint[2].cachedTextGenerator.Invalidate();
        this.text_Hint[2].cachedTextGeneratorForLayout.Invalidate();
        this.PropertyInfo_HintRT[1].sizeDelta = new Vector2(this.PropertyInfo_HintRT[1].sizeDelta.x, this.text_Hint[2].preferredHeight);
        this.PropertyInfo_HintRT[0].sizeDelta = new Vector2(this.PropertyInfo_HintRT[0].sizeDelta.x, (float) ((double) this.text_Hint[2].preferredHeight / 25.0 * 30.0));
        break;
      case 43:
        if (!((UIBehaviour) this.PropertyInfo_Hint).IsActive())
          ((Component) this.PropertyInfo_Hint).gameObject.SetActive(true);
        ushort num = this.pAttrIdx[button.m_BtnID2 - 43];
        if (this.pAttrIdx[button.m_BtnID2 - 43] >= (ushort) 23)
          num -= (ushort) 3;
        if (button.m_BtnID2 - 43 == 0)
          num = (ushort) 2;
        this.Cstr_Hint.ClearString();
        this.Cstr_Hint.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (ushort) (123U + (uint) num)));
        bool flag = false;
        if (num == (ushort) 2)
        {
          this.Cstr_Hint.IntToFormat((long) (this.HP - this.EquipEffect_HP), bNumber: true);
          if (this.EquipEffect_HP > 0U)
          {
            this.Cstr_Hint.IntToFormat((long) this.EquipEffect_HP, bNumber: true);
            flag = true;
          }
        }
        else
        {
          this.Cstr_Hint.IntToFormat((long) ((int) this.pAttr[(int) this.pAttrIdx[button.m_BtnID2 - 43]] - (int) this.EquipEffect_pAttr[(int) this.EquipEffect_pAttrIdx[button.m_BtnID2 - 43]]), bNumber: true);
          if (this.EquipEffect_pAttr[(int) this.EquipEffect_pAttrIdx[button.m_BtnID2 - 43]] > (ushort) 0)
          {
            this.Cstr_Hint.IntToFormat((long) this.EquipEffect_pAttr[(int) this.EquipEffect_pAttrIdx[button.m_BtnID2 - 43]], bNumber: true);
            flag = true;
          }
        }
        if (flag)
          this.Cstr_Hint.AppendFormat("<color=#FFF799>{0}</color> {1}<color=#33EB67>+{2}</color>\n");
        else
          this.Cstr_Hint.AppendFormat("<color=#FFF799>{0}</color> {1}\n");
        this.Cstr_Hint.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (ushort) (382U + (uint) num)));
        this.Cstr_Hint.AppendFormat("{0}");
        this.text_Hint[2].text = this.Cstr_Hint.ToString();
        this.text_Hint[2].SetAllDirty();
        this.text_Hint[2].cachedTextGenerator.Invalidate();
        this.text_Hint[2].cachedTextGeneratorForLayout.Invalidate();
        this.PropertyInfo_HintRT[1].sizeDelta = new Vector2(this.PropertyInfo_HintRT[1].sizeDelta.x, this.text_Hint[2].preferredHeight);
        this.PropertyInfo_HintRT[0].sizeDelta = new Vector2(this.PropertyInfo_HintRT[0].sizeDelta.x, (float) ((double) this.text_Hint[2].preferredHeight / 25.0 * 30.0));
        break;
      case 44:
        if (((UIBehaviour) this.HeroState_Hint).IsActive())
          break;
        ((Component) this.HeroState_Hint).gameObject.SetActive(true);
        if (((UIBehaviour) this.Property_Hint).IsActive())
          ((Component) this.Property_Hint).gameObject.SetActive(false);
        if (((UIBehaviour) this.Fragment_Hint).IsActive())
          ((Component) this.Fragment_Hint).gameObject.SetActive(false);
        if (!((UIBehaviour) this.HeroPower_Hint).IsActive())
          break;
        ((Component) this.HeroPower_Hint).gameObject.SetActive(false);
        break;
      case 45:
        if (((UIBehaviour) this.HeroPower_Hint).IsActive())
          break;
        ((Component) this.HeroPower_Hint).gameObject.SetActive(true);
        if (((UIBehaviour) this.Property_Hint).IsActive())
          ((Component) this.Property_Hint).gameObject.SetActive(false);
        if (((UIBehaviour) this.Fragment_Hint).IsActive())
          ((Component) this.Fragment_Hint).gameObject.SetActive(false);
        if (!((UIBehaviour) this.HeroState_Hint).IsActive())
          break;
        ((Component) this.HeroState_Hint).gameObject.SetActive(false);
        break;
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    switch ((sender.m_Button as UIButton).m_BtnID1)
    {
      case 15:
      case 16:
      case 17:
      case 18:
      case 34:
      case 35:
      case 36:
      case 37:
        this.GUIM.m_SkillInfo.Hide(sender);
        break;
      case 38:
        if (!((UIBehaviour) this.Property_Hint).IsActive())
          break;
        ((Component) this.Property_Hint).gameObject.SetActive(false);
        break;
      case 39:
        if (!((UIBehaviour) this.Fragment_Hint).IsActive())
          break;
        ((Component) this.Fragment_Hint).gameObject.SetActive(false);
        break;
      case 40:
      case 41:
      case 42:
        if (!((UIBehaviour) this.PropertyInfo_Hint).IsActive())
          break;
        ((Component) this.PropertyInfo_Hint).gameObject.SetActive(false);
        break;
      case 43:
        if (!((UIBehaviour) this.PropertyInfo_Hint).IsActive())
          break;
        if (this.m_ScrollRect.Get_Dragging())
        {
          ((Component) this.PropertyInfo_Hint).gameObject.SetActive(false);
          break;
        }
        ((Component) this.PropertyInfo_Hint).gameObject.SetActive(false);
        break;
      case 44:
        if (!((UIBehaviour) this.HeroState_Hint).IsActive())
          break;
        ((Component) this.HeroState_Hint).gameObject.SetActive(false);
        break;
      case 45:
        if (!((UIBehaviour) this.HeroPower_Hint).IsActive())
          break;
        ((Component) this.HeroPower_Hint).gameObject.SetActive(false);
        break;
    }
  }
}
