// Decompiled with JetBrains decompiler
// Type: UIAlliance_FS
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIAlliance_FS : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler
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
  private UIHIBtn[] btn_Itme = new UIHIBtn[30];
  private UILEBtn[] btn_Item_L = new UILEBtn[30];
  private UIHIBtn[] btn_Hero = new UIHIBtn[5];
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
  private Image Img_Quanmie;
  private Image Img_Exp;
  private Image Img_LF;
  private Image Img_RF;
  private Image Img_FormationHint;
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
  private CString[] Cstr_Coordinate = new CString[2];
  private CString Cstr_TitleName;
  private CString Cstr_FightingKind;
  private CString Cstr_L_Exp;
  private CString[] Cstr_ItemQty = new CString[30];
  private CString[] Cstr_Offensive = new CString[2];
  private CString[] Cstr_LossValue = new CString[2];
  private CString[] Cstr_Strength = new CString[2];
  private CString[] Cstr_Country = new CString[2];
  private CString[] Cstr_Dominance = new CString[2];
  private CString[] Cstr_CoordinateMainHero = new CString[2];
  private CString[] Cstr_Name = new CString[2];
  private CString[] Cstr_LA = new CString[4];
  private CString[] Cstr_RA = new CString[8];
  private CString[] Cstr_DW = new CString[3];
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
  private AllianceWarManager AWM;
  private Font TTFont;
  private Door door;
  private UISpritesArray SArray;
  private Material mMaT;
  private Material IconMaterial;
  private Material FrameMaterial;
  private float tmpH;
  private float tmpH2 = 120f;
  private bool bQuanmier;
  private bool IsAttack = true;
  private float ShowMainHeroTime1;
  private float ShowMainHeroTime2;
  private float ShowVsTime;
  private float ShowReplay;
  private float tempL;
  private Hero tmpHero;
  private uint[] tmpHeroExp = new uint[5];
  private ushort[] tmpHeroID = new ushort[5];
  private byte[] tmpHeroStar = new byte[5];
  private ushort[] ItemID = new ushort[30];
  private ushort[] ItemNum = new ushort[30];
  private byte[] ItemRank = new byte[30];
  private int AssetKey;
  private bool bInitFS;
  private bool bSetFSShow;
  private bool[] bSetHero = new bool[5];
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
  private RectTransform AllianceBossItemRT;
  private UIText text_AllianceBossStr;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.AWM = ActivityManager.Instance.AllianceWarMgr;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.mMaT = this.door.LoadMaterial();
    this.IconMaterial = this.GUIM.m_IconSpriteAsset.GetMaterial();
    this.FrameMaterial = this.GUIM.GetFrameMaterial();
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    CString SpriteName = StringManager.Instance.StaticString1024();
    this.Cstr_TitleName = StringManager.Instance.SpawnString();
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
    for (int index = 0; index < 8; ++index)
      this.Cstr_RA[index] = StringManager.Instance.SpawnString();
    for (int index = 0; index < 4; ++index)
      this.Cstr_LA[index] = StringManager.Instance.SpawnString();
    for (int index = 0; index < 3; ++index)
      this.Cstr_DW[index] = StringManager.Instance.SpawnString();
    this.Tmp = this.GameT.GetChild(0);
    this.Tmp1 = this.Tmp.GetChild(1);
    this.text_TitleName = this.Tmp1.GetChild(0).GetComponent<UIText>();
    this.text_TitleName.font = this.TTFont;
    this.text_Page = this.Tmp1.GetChild(1).GetComponent<UIText>();
    this.text_Page.font = this.TTFont;
    ((Component) this.text_Page).gameObject.SetActive(false);
    this.Tmp = this.GameT.GetChild(1);
    this.Mask_T = this.GameT.GetChild(1);
    this.m_Mask = this.Tmp.GetComponent<CScrollRect>();
    this.ContentRT = this.Tmp.GetChild(0).GetComponent<RectTransform>();
    this.Tmp1 = this.Tmp.GetChild(0).GetChild(0);
    this.Img_Titlebg = this.Tmp1.GetComponent<Image>();
    this.ReplayerRT = this.Tmp1.GetComponent<RectTransform>();
    this.btn_Replay = this.Tmp1.GetChild(0).GetComponent<UIButton>();
    this.btn_Replay.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Replay.m_BtnID1 = 1;
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
    ((Component) this.Img_MainHerobg).gameObject.SetActive(false);
    this.text_MainHero = this.Tmp1.GetChild(0).GetComponent<UIText>();
    this.text_MainHero.font = this.TTFont;
    this.Tmp1 = this.Tmp.GetChild(0).GetChild(2);
    this.ItemRT = this.Tmp1.GetComponent<RectTransform>();
    ((Component) this.ItemRT).gameObject.SetActive(false);
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
      ((MaskableGraphic) this.tmpImg).material = this.mMaT;
      this.text_Resources[index] = this.Tmp2.GetChild(index).GetChild(0).GetComponent<UIText>();
      this.text_Resources[index].font = this.TTFont;
    }
    this.Tmp1 = this.Tmp.GetChild(0).GetChild(3);
    this.HeroRT = this.Tmp1.GetComponent<RectTransform>();
    ((Component) this.HeroRT).gameObject.SetActive(false);
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
    if (!this.bInitFS)
      this.bInitFS = true;
    this.InitFSComponent();
    this.Tmp = this.GameT.GetChild(2);
    this.Tmp1 = this.Tmp.GetChild(0);
    this.btn_Title = this.Tmp1.GetComponent<UIButton>();
    ((Component) this.btn_Title).gameObject.SetActive(false);
    this.text_Coordinate = this.Tmp1.GetChild(1).GetComponent<UIText>();
    this.text_Coordinate.font = this.TTFont;
    this.Tmp1 = this.Tmp.GetChild(1);
    this.text_Time[0] = this.Tmp1.GetComponent<UIText>();
    this.text_Time[0].font = this.TTFont;
    ((Component) this.text_Time[0]).gameObject.SetActive(false);
    this.Tmp1 = this.Tmp.GetChild(2);
    this.text_Time[1] = this.Tmp1.GetComponent<UIText>();
    this.text_Time[1].font = this.TTFont;
    ((Component) this.text_Time[1]).gameObject.SetActive(false);
    this.Tmp1 = this.GameT.GetChild(3);
    this.btn_Delete = this.Tmp1.GetComponent<UIButton>();
    ((Component) this.btn_Delete).gameObject.SetActive(false);
    this.Tmp1 = this.GameT.GetChild(4);
    this.btn_Collect = this.Tmp1.GetComponent<UIButton>();
    ((Component) this.btn_Collect).gameObject.SetActive(false);
    float x = ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x;
    this.tempL = (float) (((double) ((Component) this.GUIM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x - 853.0) / 2.0);
    this.PreviousT = this.GameT.GetChild(5);
    this.btn_Previous = this.PreviousT.GetComponent<UIButton>();
    ((Component) this.btn_Previous).gameObject.SetActive(false);
    this.NextT = this.GameT.GetChild(6);
    this.btn_Next = this.NextT.GetComponent<UIButton>();
    ((Component) this.btn_Next).gameObject.SetActive(false);
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
      this.ContentRT.anchoredPosition = new Vector2(this.ContentRT.anchoredPosition.x, 621f);
    this.DM.mSaveInfo = (byte) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
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
    ((Component) this.btn_Coordinate[0]).gameObject.SetActive(false);
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
    ((Component) this.btn_Coordinate[1]).gameObject.SetActive(false);
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
    this.btn_LF.m_BtnID1 = 5;
    UIButtonHint uiButtonHint1 = ((Component) this.btn_LF).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.CountDown;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    uiButtonHint1.DelayTime = 0.3f;
    uiButtonHint1.ControlFadeOut = ((Component) this.Img_FormationHint).gameObject;
    this.Tmp = this.Tmp2.GetChild(0).GetChild(10).GetChild(0);
    this.Img_LF = this.Tmp.GetComponent<Image>();
    this.text_LF = this.Tmp2.GetChild(0).GetChild(10).GetChild(1).GetComponent<UIText>();
    this.text_LF.font = this.TTFont;
    this.Tmp = this.Tmp2.GetChild(0).GetChild(11);
    this.text_NpcInfo = this.Tmp.GetComponent<UIText>();
    this.text_NpcInfo.font = this.TTFont;
    this.Cstr_Text.ClearString();
    this.Cstr_Text.StringToFormat(this.DM.mStringTable.GetStringByID(17029U));
    this.Cstr_Text.AppendFormat(this.DM.mStringTable.GetStringByID(11165U));
    this.text_NpcInfo.text = this.Cstr_Text.ToString();
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
    this.btn_RF.m_BtnID1 = 5;
    UIButtonHint uiButtonHint2 = ((Component) this.btn_RF).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.m_eHint = EUIButtonHint.CountDown;
    uiButtonHint2.DelayTime = 0.3f;
    uiButtonHint2.m_Handler = (MonoBehaviour) this;
    uiButtonHint2.ControlFadeOut = ((Component) this.Img_FormationHint).gameObject;
    this.Tmp = this.Tmp2.GetChild(0).GetChild(18).GetChild(0);
    this.Img_RF = this.Tmp.GetComponent<Image>();
    this.text_RF = this.Tmp2.GetChild(0).GetChild(18).GetChild(1).GetComponent<UIText>();
    this.text_RF.font = this.TTFont;
    UIButtonHint.scrollRect = this.m_Mask;
    if (this.AWM.MyAllySide == (byte) 2)
    {
      ((Graphic) this.text_NpcInfo).rectTransform.anchoredPosition = new Vector2(0.0f, ((Graphic) this.text_NpcInfo).rectTransform.anchoredPosition.y);
      ((Component) this.text_NpcInfo).transform.SetParent(((Component) this.Img_Army2[1]).transform, false);
    }
    ((Component) this.text_NpcInfo).gameObject.SetActive(true);
    this.tmpH -= 498f;
    this.Tmp2 = this.Tmp1.GetChild(14);
    this.Img_CWall_P[0] = this.Tmp2.GetComponent<Image>();
    ((Component) this.Img_CWall_P[0]).gameObject.SetActive(false);
    this.Img_CWall[0] = this.Tmp2.GetChild(0).GetComponent<Image>();
    this.text_tmpStr[17] = this.Tmp2.GetChild(1).GetComponent<UIText>();
    this.text_tmpStr[17].font = this.TTFont;
    this.text_tmpStr[17].text = this.DM.mStringTable.GetStringByID(5333U);
    this.text_tmpStr[18] = this.Tmp2.GetChild(2).GetComponent<UIText>();
    this.text_tmpStr[18].font = this.TTFont;
    this.text_tmpStr[18].text = this.DM.mStringTable.GetStringByID(5334U);
    this.Tmp2 = this.Tmp1.GetChild(15);
    this.Img_CWall_P[1] = this.Tmp2.GetComponent<Image>();
    ((Component) this.Img_CWall_P[1]).gameObject.SetActive(false);
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
    this.btn_Details.m_BtnID1 = 2;
    this.btn_Details.SoundIndex = (byte) 64;
    this.btn_Details.m_EffectType = e_EffectType.e_Scale;
    this.btn_Details.transition = (Selectable.Transition) 0;
    this.text_tmpStr[23] = this.Tmp2.GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[23].font = this.TTFont;
    this.text_tmpStr[23].text = this.DM.mStringTable.GetStringByID(5396U);
    this.tmpH -= 281f;
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
    for (int index = 0; index < 4; ++index)
      this.Cstr_Quanmie[index].ClearString();
    this.text_Quanmie[1].text = this.Cstr_Quanmie[0].ToString();
    this.text_Quanmie[2].text = this.DM.mStringTable.GetStringByID(5325U);
    this.text_Quanmie[3].text = this.DM.mStringTable.GetStringByID(5326U);
    this.text_Quanmie[4].text = this.DM.mStringTable.GetStringByID(5327U);
    this.text_FightingKind = this.Tmp1.GetChild(3).GetComponent<UIText>();
    this.text_FightingKind.font = this.TTFont;
    this.text_FightingKind.text = this.DM.mStringTable.GetStringByID(5385U);
    this.SetPorfileBtn();
  }

  public override void OnClose()
  {
    if (this.Cstr_TitleName != null)
      StringManager.Instance.DeSpawnString(this.Cstr_TitleName);
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
    if (this.DM.mSaveInfo == (byte) 1)
      ++this.DM.mSaveInfo;
    if (this.AssetKey != 0)
      AssetManager.UnloadAssetBundle(this.AssetKey, false);
    this.AssetKey = 0;
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
        GUIManager.Instance.bClearWindowStack = false;
        AllianceWarManager allianceWarMgr = ActivityManager.Instance.AllianceWarMgr;
        WarManager.StartWar(allianceWarMgr.mReportResult, allianceWarMgr.MyAllySide == (byte) 1, allianceWarMgr.mReportRandSeed, allianceWarMgr.mReportRandGap, ref allianceWarMgr.m_CombatPlayerData[0], ref allianceWarMgr.m_CombatPlayerData[1]);
        break;
      case 2:
        if (!((Object) this.door != (Object) null))
          break;
        this.DM.mSaveInfo = (byte) 1;
        this.door.OpenMenu(EGUIWindow.UI_Alliance_FS_Info);
        break;
      case 3:
      case 4:
        this.ShowLordProfile((Alliance_FS_btn) sender.m_BtnID1);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if ((sender.m_Button as UIButton).m_BtnID1 != 5)
      return;
    sender.GetTipPosition(((Graphic) this.Img_FormationHint).rectTransform);
    ((Component) this.Img_FormationHint).gameObject.SetActive(true);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if ((sender.m_Button as UIButton).m_BtnID1 != 5)
      return;
    ((Component) this.Img_FormationHint).gameObject.SetActive(false);
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
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        this.Refresh_FontTexture();
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
    if ((Object) this.text_MainHero != (Object) null && ((Behaviour) this.text_MainHero).enabled)
    {
      ((Behaviour) this.text_MainHero).enabled = false;
      ((Behaviour) this.text_MainHero).enabled = true;
    }
    if ((Object) this.text_TitleItem != (Object) null && ((Behaviour) this.text_TitleItem).enabled)
    {
      ((Behaviour) this.text_TitleItem).enabled = false;
      ((Behaviour) this.text_TitleItem).enabled = true;
    }
    if ((Object) this.text_FightingKind != (Object) null && ((Behaviour) this.text_FightingKind).enabled)
    {
      ((Behaviour) this.text_FightingKind).enabled = false;
      ((Behaviour) this.text_FightingKind).enabled = true;
    }
    if ((Object) this.text_L_Exp != (Object) null && ((Behaviour) this.text_L_Exp).enabled)
    {
      ((Behaviour) this.text_L_Exp).enabled = false;
      ((Behaviour) this.text_L_Exp).enabled = true;
    }
    if ((Object) this.text_Formation != (Object) null && ((Behaviour) this.text_Formation).enabled)
    {
      ((Behaviour) this.text_Formation).enabled = false;
      ((Behaviour) this.text_Formation).enabled = true;
    }
    if ((Object) this.text_NpcInfo != (Object) null && ((Behaviour) this.text_NpcInfo).enabled)
    {
      ((Behaviour) this.text_NpcInfo).enabled = false;
      ((Behaviour) this.text_NpcInfo).enabled = true;
    }
    if ((Object) this.text_QuanmierNpcInfo != (Object) null && ((Behaviour) this.text_QuanmierNpcInfo).enabled)
    {
      ((Behaviour) this.text_QuanmierNpcInfo).enabled = false;
      ((Behaviour) this.text_QuanmierNpcInfo).enabled = true;
    }
    if ((Object) this.text_NpcCoordinate != (Object) null && ((Behaviour) this.text_NpcCoordinate).enabled)
    {
      ((Behaviour) this.text_NpcCoordinate).enabled = false;
      ((Behaviour) this.text_NpcCoordinate).enabled = true;
    }
    if ((Object) this.text_NpcName != (Object) null && ((Behaviour) this.text_NpcName).enabled)
    {
      ((Behaviour) this.text_NpcName).enabled = false;
      ((Behaviour) this.text_NpcName).enabled = true;
    }
    if ((Object) this.text_NpcItemName != (Object) null && ((Behaviour) this.text_NpcItemName).enabled)
    {
      ((Behaviour) this.text_NpcItemName).enabled = false;
      ((Behaviour) this.text_NpcItemName).enabled = true;
    }
    if ((Object) this.text_NpcItemfull != (Object) null && ((Behaviour) this.text_NpcItemfull).enabled)
    {
      ((Behaviour) this.text_NpcItemfull).enabled = false;
      ((Behaviour) this.text_NpcItemfull).enabled = true;
    }
    if ((Object) this.text_NpcItemHint != (Object) null && ((Behaviour) this.text_NpcItemHint).enabled)
    {
      ((Behaviour) this.text_NpcItemHint).enabled = false;
      ((Behaviour) this.text_NpcItemHint).enabled = true;
    }
    if ((Object) this.text_AllianceBossStr != (Object) null && ((Behaviour) this.text_AllianceBossStr).enabled)
    {
      ((Behaviour) this.text_AllianceBossStr).enabled = false;
      ((Behaviour) this.text_AllianceBossStr).enabled = true;
    }
    if ((Object) this.text_LF != (Object) null && ((Behaviour) this.text_LF).enabled)
    {
      ((Behaviour) this.text_LF).enabled = false;
      ((Behaviour) this.text_LF).enabled = true;
    }
    if ((Object) this.text_RF != (Object) null && ((Behaviour) this.text_RF).enabled)
    {
      ((Behaviour) this.text_RF).enabled = false;
      ((Behaviour) this.text_RF).enabled = true;
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
      if ((Object) this.text_LossValue[index] != (Object) null && ((Behaviour) this.text_LossValue[index]).enabled)
      {
        ((Behaviour) this.text_LossValue[index]).enabled = false;
        ((Behaviour) this.text_LossValue[index]).enabled = true;
      }
      if ((Object) this.text_ArmyTitle[index] != (Object) null && ((Behaviour) this.text_ArmyTitle[index]).enabled)
      {
        ((Behaviour) this.text_ArmyTitle[index]).enabled = false;
        ((Behaviour) this.text_ArmyTitle[index]).enabled = true;
      }
      if ((Object) this.text_Strength[index] != (Object) null && ((Behaviour) this.text_Strength[index]).enabled)
      {
        ((Behaviour) this.text_Strength[index]).enabled = false;
        ((Behaviour) this.text_Strength[index]).enabled = true;
      }
      if ((Object) this.text_Country[index] != (Object) null && ((Behaviour) this.text_Country[index]).enabled)
      {
        ((Behaviour) this.text_Country[index]).enabled = false;
        ((Behaviour) this.text_Country[index]).enabled = true;
      }
      if ((Object) this.text_Dominance[index] != (Object) null && ((Behaviour) this.text_Dominance[index]).enabled)
      {
        ((Behaviour) this.text_Dominance[index]).enabled = false;
        ((Behaviour) this.text_Dominance[index]).enabled = true;
      }
      if ((Object) this.text_Name[index] != (Object) null && ((Behaviour) this.text_Name[index]).enabled)
      {
        ((Behaviour) this.text_Name[index]).enabled = false;
        ((Behaviour) this.text_Name[index]).enabled = true;
      }
      if ((Object) this.text_MainHero_F[index] != (Object) null && ((Behaviour) this.text_MainHero_F[index]).enabled)
      {
        ((Behaviour) this.text_MainHero_F[index]).enabled = false;
        ((Behaviour) this.text_MainHero_F[index]).enabled = true;
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
      if ((Object) this.text_BossTitle[index] != (Object) null && ((Behaviour) this.text_BossTitle[index]).enabled)
      {
        ((Behaviour) this.text_BossTitle[index]).enabled = false;
        ((Behaviour) this.text_BossTitle[index]).enabled = true;
      }
      if ((Object) this.text_BossL[index] != (Object) null && ((Behaviour) this.text_BossL[index]).enabled)
      {
        ((Behaviour) this.text_BossL[index]).enabled = false;
        ((Behaviour) this.text_BossL[index]).enabled = true;
      }
      if ((Object) this.text_NpcTroops[index] != (Object) null && ((Behaviour) this.text_NpcTroops[index]).enabled)
      {
        ((Behaviour) this.text_NpcTroops[index]).enabled = false;
        ((Behaviour) this.text_NpcTroops[index]).enabled = true;
      }
      if ((Object) this.text_QuanmierNpcTroops[index] != (Object) null && ((Behaviour) this.text_QuanmierNpcTroops[index]).enabled)
      {
        ((Behaviour) this.text_QuanmierNpcTroops[index]).enabled = false;
        ((Behaviour) this.text_QuanmierNpcTroops[index]).enabled = true;
      }
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.text_DW[index] != (Object) null && ((Behaviour) this.text_DW[index]).enabled)
      {
        ((Behaviour) this.text_DW[index]).enabled = false;
        ((Behaviour) this.text_DW[index]).enabled = true;
      }
      if ((Object) this.text_BossR[index] != (Object) null && ((Behaviour) this.text_BossR[index]).enabled)
      {
        ((Behaviour) this.text_BossR[index]).enabled = false;
        ((Behaviour) this.text_BossR[index]).enabled = true;
      }
      if ((Object) this.text_BossFight[index] != (Object) null && ((Behaviour) this.text_BossFight[index]).enabled)
      {
        ((Behaviour) this.text_BossFight[index]).enabled = false;
        ((Behaviour) this.text_BossFight[index]).enabled = true;
      }
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((Object) this.text_LA[index] != (Object) null && ((Behaviour) this.text_LA[index]).enabled)
      {
        ((Behaviour) this.text_LA[index]).enabled = false;
        ((Behaviour) this.text_LA[index]).enabled = true;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.text_Resources[index] != (Object) null && ((Behaviour) this.text_Resources[index]).enabled)
      {
        ((Behaviour) this.text_Resources[index]).enabled = false;
        ((Behaviour) this.text_Resources[index]).enabled = true;
      }
      if ((Object) this.text_HeroExp[index] != (Object) null && ((Behaviour) this.text_HeroExp[index]).enabled)
      {
        ((Behaviour) this.text_HeroExp[index]).enabled = false;
        ((Behaviour) this.text_HeroExp[index]).enabled = true;
      }
      if ((Object) this.text_HeroExp2[index] != (Object) null && ((Behaviour) this.text_HeroExp2[index]).enabled)
      {
        ((Behaviour) this.text_HeroExp2[index]).enabled = false;
        ((Behaviour) this.text_HeroExp2[index]).enabled = true;
      }
      if ((Object) this.btn_Hero[index] != (Object) null && ((Behaviour) this.btn_Hero[index]).enabled)
        this.btn_Hero[index].Refresh_FontTexture();
    }
    for (int index = 0; index < 8; ++index)
    {
      if ((Object) this.text_RA[index] != (Object) null && ((Behaviour) this.text_RA[index]).enabled)
      {
        ((Behaviour) this.text_RA[index]).enabled = false;
        ((Behaviour) this.text_RA[index]).enabled = true;
      }
      if ((Object) this.text_Quanmie[index] != (Object) null && ((Behaviour) this.text_Quanmie[index]).enabled)
      {
        ((Behaviour) this.text_Quanmie[index]).enabled = false;
        ((Behaviour) this.text_Quanmie[index]).enabled = true;
      }
    }
    for (int index = 0; index < 25; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
    for (int index = 0; index < 30; ++index)
    {
      if ((Object) this.text_ItemQty[index] != (Object) null && ((Behaviour) this.text_ItemQty[index]).enabled)
      {
        ((Behaviour) this.text_ItemQty[index]).enabled = false;
        ((Behaviour) this.text_ItemQty[index]).enabled = true;
      }
      if ((Object) this.btn_Itme[index] != (Object) null && ((Behaviour) this.btn_Itme[index]).enabled)
        this.btn_Itme[index].Refresh_FontTexture();
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
  }

  public void SetPageData()
  {
    if (this.AssetKey != 0)
      AssetManager.UnloadAssetBundle(this.AssetKey, false);
    if ((Object) this.mHead != (Object) null)
      Object.Destroy((Object) this.mHead);
    this.Cstr_TitleName.ClearString();
    CString cstring1 = StringManager.Instance.StaticString1024();
    CString cstring2 = StringManager.Instance.StaticString1024();
    CString cstring3 = StringManager.Instance.StaticString1024();
    CString cstring4 = StringManager.Instance.StaticString1024();
    cstring1.ClearString();
    cstring2.ClearString();
    cstring3.ClearString();
    cstring4.ClearString();
    byte num1 = 0;
    cstring1.Append(this.AWM.m_CombatPlayerData[0].Name);
    if (DataManager.CompareStr(cstring1, this.DM.RoleAttr.Name) != 0)
    {
      num1 = (byte) 1;
      if (this.AWM.m_CombatPlayerData[0].AllianceTag != string.Empty)
      {
        cstring2.Append(this.AWM.m_CombatPlayerData[0].AllianceTag);
        if (this.DM.IsSameAlliance(cstring2))
          this.GUIM.FormatRoleNameForChat(cstring4, cstring1, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring4, cstring1, cstring2, (ushort) 0, this.GUIM.IsArabic);
      }
      else
        this.GUIM.FormatRoleNameForChat(cstring4, cstring1, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
    }
    cstring1.ClearString();
    cstring2.ClearString();
    cstring3.ClearString();
    cstring1.Append(this.AWM.m_CombatPlayerData[1].Name);
    if (DataManager.CompareStr(cstring1, this.DM.RoleAttr.Name) != 0)
    {
      num1 = num1 != (byte) 0 ? (byte) 2 : (byte) 3;
      if (this.AWM.m_CombatPlayerData[1].AllianceTag != string.Empty)
      {
        cstring2.Append(this.AWM.m_CombatPlayerData[1].AllianceTag);
        if (this.DM.IsSameAlliance(cstring2))
          this.GUIM.FormatRoleNameForChat(cstring3, cstring1, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
        else
          this.GUIM.FormatRoleNameForChat(cstring3, cstring1, cstring2, (ushort) 0, this.GUIM.IsArabic);
      }
      else
        this.GUIM.FormatRoleNameForChat(cstring3, cstring1, KingdomID: (ushort) 0, ForceArabic: this.GUIM.IsArabic);
    }
    switch (num1)
    {
      case 1:
        this.Cstr_TitleName.StringToFormat(cstring4);
        break;
      case 2:
        this.Cstr_TitleName.StringToFormat(cstring4);
        this.Cstr_TitleName.StringToFormat(cstring3);
        this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(11162U));
        goto label_21;
      default:
        this.Cstr_TitleName.StringToFormat(cstring3);
        break;
    }
    this.Cstr_TitleName.AppendFormat(this.DM.mStringTable.GetStringByID(11168U));
label_21:
    this.text_TitleName.text = this.Cstr_TitleName.ToString();
    this.text_TitleName.SetAllDirty();
    this.text_TitleName.cachedTextGenerator.Invalidate();
    this.tmpH = -136f;
    int num2 = 0;
    if ((int) this.AWM.mReportResult == (int) this.AWM.MyAllySide)
    {
      this.Img_Titlebg.sprite = this.SArray.m_Sprites[0];
      ((Graphic) this.text_Summary).color = new Color(1f, 0.9255f, 0.5294f);
      ((Shadow) ((Component) this.text_Summary).transform.GetComponent<Outline>()).effectColor = new Color(0.8431f, 0.0f, 0.0f);
      ((Component) this.text_Summary).transform.GetComponent<Shadow>().effectColor = new Color(0.2824f, 0.0f, 0.0f);
    }
    else
    {
      num2 = 1;
      this.Img_Titlebg.sprite = this.SArray.m_Sprites[1];
      ((Graphic) this.text_Summary).color = new Color(0.6941f, 0.9137f, 1f);
      ((Shadow) ((Component) this.text_Summary).transform.GetComponent<Outline>()).effectColor = new Color(0.2471f, 0.451f, 0.7294f);
      ((Component) this.text_Summary).transform.GetComponent<Shadow>().effectColor = new Color(0.0f, 0.0471f, 0.2824f);
    }
    this.text_Summary.text = this.DM.mStringTable.GetStringByID((uint) (ushort) (5307 + num2));
    this.text_Summary.SetAllDirty();
    this.text_Summary.cachedTextGenerator.Invalidate();
    this.ItemRT.anchoredPosition = new Vector2(this.ItemRT.anchoredPosition.x, this.tmpH);
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.ItemT[index] != (Object) null)
        this.ItemT[index].gameObject.SetActive(false);
    }
    this.text_TitleItem.SetAllDirty();
    this.text_TitleItem.cachedTextGenerator.Invalidate();
    this.HeroRT.anchoredPosition = new Vector2(this.HeroRT.anchoredPosition.x, this.tmpH);
    this.SummaryRT.anchoredPosition = new Vector2(this.SummaryRT.anchoredPosition.x, this.tmpH);
    this.tmpH -= 51f;
    this.tmpH -= 312f;
    this.SetFightData();
  }

  public void SetFightData()
  {
    this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.AWM.m_CombatPlayerData[0].Head);
    this.Img_MainHero[1].sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
    ((Component) this.Img_Muster[0]).gameObject.SetActive(false);
    this.Cstr_Dominance[0].ClearString();
    this.Cstr_Dominance[0].IntToFormat((long) this.AWM.m_CombatPlayerData[0].Level);
    this.Cstr_Dominance[0].AppendFormat(this.DM.mStringTable.GetStringByID(5320U));
    this.text_Dominance[0].text = this.Cstr_Dominance[0].ToString();
    this.text_Dominance[0].SetAllDirty();
    this.text_Dominance[0].cachedTextGenerator.Invalidate();
    this.Cstr_Country[0].ClearString();
    this.Cstr_Country[0].IntToFormat((long) this.AWM.m_CombatPlayerData[0].KingdomID);
    if (this.GUIM.IsArabic)
      this.Cstr_Country[0].AppendFormat("{0}#");
    else
      this.Cstr_Country[0].AppendFormat("#{0}");
    this.text_Country[0].text = this.Cstr_Country[0].ToString();
    this.text_Country[0].SetAllDirty();
    this.text_Country[0].cachedTextGenerator.Invalidate();
    ((Component) this.Img_Country[0]).gameObject.SetActive(false);
    int allianceRank1 = (int) this.AWM.m_CombatPlayerData[0].AllianceRank;
    this.Img_Rank[0].sprite = this.SArray.m_Sprites[7 + allianceRank1];
    if (allianceRank1 < 1)
      ((Component) this.Img_Rank[0]).gameObject.SetActive(false);
    else
      ((Component) this.Img_Rank[0]).gameObject.SetActive(true);
    this.text_Vip[0].text = ((int) this.AWM.m_CombatPlayerData[0].VIPLevel).ToString();
    this.Cstr_Name[0].ClearString();
    CString Name = StringManager.Instance.StaticString1024();
    CString Tag = StringManager.Instance.StaticString1024();
    Name.ClearString();
    Tag.ClearString();
    Name.Append(this.AWM.m_CombatPlayerData[0].Name);
    if (this.AWM.m_CombatPlayerData[0].AllianceTag != string.Empty)
    {
      Tag.Append(this.AWM.m_CombatPlayerData[0].AllianceTag);
      GameConstants.FormatRoleName(this.Cstr_Name[0], Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    }
    else
      GameConstants.FormatRoleName(this.Cstr_Name[0], Name, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    this.text_Name[0].text = this.Cstr_Name[0].ToString();
    this.text_Name[0].SetAllDirty();
    this.text_Name[0].cachedTextGenerator.Invalidate();
    this.tmpHero = DataManager.Instance.HeroTable.GetRecordByKey(this.AWM.m_CombatPlayerData[1].Head);
    this.Img_MainHero[4].sprite = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpHero.Graph);
    ((Component) this.Img_Muster[1]).gameObject.SetActive(false);
    this.Cstr_Dominance[1].ClearString();
    this.Cstr_Dominance[1].IntToFormat((long) this.AWM.m_CombatPlayerData[1].Level);
    this.Cstr_Dominance[1].AppendFormat(this.DM.mStringTable.GetStringByID(5320U));
    this.text_Dominance[1].text = this.Cstr_Dominance[1].ToString();
    this.text_Dominance[1].SetAllDirty();
    this.text_Dominance[1].cachedTextGenerator.Invalidate();
    this.Cstr_Country[1].ClearString();
    this.Cstr_Country[1].IntToFormat((long) this.AWM.m_CombatPlayerData[1].KingdomID);
    if (this.GUIM.IsArabic)
      this.Cstr_Country[1].AppendFormat("{0}#");
    else
      this.Cstr_Country[1].AppendFormat("#{0}");
    this.text_Country[1].text = this.Cstr_Country[1].ToString();
    this.text_Country[1].SetAllDirty();
    this.text_Country[1].cachedTextGenerator.Invalidate();
    ((Component) this.Img_Country[1]).gameObject.SetActive(false);
    int allianceRank2 = (int) this.AWM.m_CombatPlayerData[1].AllianceRank;
    this.Img_Rank[1].sprite = this.SArray.m_Sprites[7 + allianceRank2];
    if (allianceRank2 < 1)
      ((Component) this.Img_Rank[1]).gameObject.SetActive(false);
    else
      ((Component) this.Img_Rank[1]).gameObject.SetActive(true);
    this.text_Vip[1].text = ((int) this.AWM.m_CombatPlayerData[1].VIPLevel).ToString();
    this.Cstr_Name[1].ClearString();
    Name.ClearString();
    Tag.ClearString();
    Name.Append(this.AWM.m_CombatPlayerData[1].Name);
    if (this.AWM.m_CombatPlayerData[1].AllianceTag != string.Empty)
    {
      Tag.Append(this.AWM.m_CombatPlayerData[1].AllianceTag);
      GameConstants.FormatRoleName(this.Cstr_Name[1], Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    }
    else
      GameConstants.FormatRoleName(this.Cstr_Name[1], Name, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    this.text_Name[1].text = this.Cstr_Name[1].ToString();
    this.text_Name[1].SetAllDirty();
    this.text_Name[1].cachedTextGenerator.Invalidate();
    if ((int) this.AWM.m_CombatPlayerData[0].KingdomID != (int) this.AWM.m_CombatPlayerData[1].KingdomID)
    {
      ((Component) this.Img_Country[0]).gameObject.SetActive(true);
      ((Component) this.Img_Country[1]).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.Img_Country[0]).gameObject.SetActive(false);
      ((Component) this.Img_Country[1]).gameObject.SetActive(false);
    }
    if (this.AWM.m_CombatPlayerData[0].bMain)
    {
      ((Component) this.Img_Crown[0]).gameObject.SetActive(true);
      ((Component) this.Img_MainTitle[0]).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.Img_Crown[0]).gameObject.SetActive(false);
      ((Component) this.Img_MainTitle[0]).gameObject.SetActive(false);
    }
    if (this.AWM.m_CombatPlayerData[1].bMain)
    {
      ((Component) this.Img_Crown[2]).gameObject.SetActive(true);
      ((Component) this.Img_MainTitle[1]).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.Img_Crown[2]).gameObject.SetActive(false);
      ((Component) this.Img_MainTitle[1]).gameObject.SetActive(false);
    }
    this.text_MainHero_F[0].SetAllDirty();
    this.text_MainHero_F[0].cachedTextGenerator.Invalidate();
    this.text_MainHero_F[1].SetAllDirty();
    this.text_MainHero_F[1].cachedTextGenerator.Invalidate();
    this.tmpH -= 41f;
    uint num = 0;
    uint x1 = 0;
    uint x2 = 0;
    for (int index = 0; index < 16; ++index)
    {
      x1 += this.AWM.m_CombatPlayerData[0].DeadTroop[index];
      x2 += this.AWM.m_CombatPlayerData[0].SurviveTroop[index];
    }
    uint x3 = x2 + x1;
    this.Cstr_LossValue[0].ClearString();
    this.Cstr_LossValue[0].IntToFormat((long) x1, bNumber: true);
    this.Cstr_LossValue[0].AppendFormat("{0}");
    this.text_LossValue[0].text = this.Cstr_LossValue[0].ToString();
    this.text_LossValue[0].SetAllDirty();
    this.text_LossValue[0].cachedTextGenerator.Invalidate();
    this.Cstr_Strength[0].ClearString();
    this.Cstr_Strength[0].uLongToFormat(this.AWM.m_CombatPlayerData[0].LosePower, bNumber: true);
    this.Cstr_Strength[0].AppendFormat(this.DM.mStringTable.GetStringByID(5322U));
    this.text_Strength[0].text = this.Cstr_Strength[0].ToString();
    this.text_Strength[0].SetAllDirty();
    this.text_Strength[0].cachedTextGenerator.Invalidate();
    this.Cstr_LA[0].ClearString();
    this.Cstr_LA[0].IntToFormat((long) x3, bNumber: true);
    this.Cstr_LA[0].AppendFormat("{0}");
    this.text_LA[0].text = this.Cstr_LA[0].ToString();
    this.text_LA[0].SetAllDirty();
    this.text_LA[0].cachedTextGenerator.Invalidate();
    this.Cstr_LA[1].ClearString();
    this.Cstr_LA[1].IntToFormat(0L, bNumber: true);
    this.Cstr_LA[1].AppendFormat("{0}");
    this.text_LA[1].text = this.Cstr_LA[1].ToString();
    this.text_LA[1].SetAllDirty();
    this.text_LA[1].cachedTextGenerator.Invalidate();
    this.Cstr_LA[2].ClearString();
    this.Cstr_LA[2].IntToFormat((long) x1, bNumber: true);
    this.Cstr_LA[2].AppendFormat("{0}");
    this.text_LA[2].text = this.Cstr_LA[2].ToString();
    this.text_LA[2].SetAllDirty();
    this.text_LA[2].cachedTextGenerator.Invalidate();
    this.Cstr_LA[3].ClearString();
    this.Cstr_LA[3].IntToFormat((long) x2, bNumber: true);
    this.Cstr_LA[3].AppendFormat("{0}");
    this.text_LA[3].text = this.Cstr_LA[3].ToString();
    this.text_LA[3].SetAllDirty();
    this.text_LA[3].cachedTextGenerator.Invalidate();
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    if (this.AWM.m_CombatPlayerData[0].StrongholdLevel >= (byte) 17)
    {
      flag1 = true;
      flag3 = true;
      flag2 = true;
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
      this.Cstr_LF.Append(this.DM.mStringTable.GetStringByID((uint) (ushort) (9778U + (uint) this.AWM.m_CombatPlayerData[0].ArmyCoordIndex)));
      this.text_LF.text = this.Cstr_LF.ToString();
      this.text_LF.SetAllDirty();
      this.text_LF.cachedTextGenerator.Invalidate();
      this.text_LF.cachedTextGeneratorForLayout.Invalidate();
      float x4 = (double) this.text_LF.preferredWidth + 1.0 <= 390.0 ? this.text_LF.preferredWidth + 1f : 390f;
      ((Graphic) this.text_LF).rectTransform.sizeDelta = new Vector2(x4, ((Graphic) this.text_LF).rectTransform.sizeDelta.y);
      if (this.GUIM.IsArabic)
        this.text_LF.UpdateArabicPos();
      this.tmpRC = ((Component) this.btn_LF).transform.GetComponent<RectTransform>();
      this.tmpRC.sizeDelta = new Vector2(x4, this.tmpRC.sizeDelta.y);
      ((Graphic) this.Img_LF).rectTransform.sizeDelta = new Vector2(x4, ((Graphic) this.Img_LF).rectTransform.sizeDelta.y);
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
    }
    else
    {
      for (int index = 0; index < 4; ++index)
      {
        ((Graphic) this.text_tmpStr[5 + index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_tmpStr[5 + index]).rectTransform.anchoredPosition.x, (float) (-95.0 - (double) index * 33.0));
        ((Graphic) this.text_LA[index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_LA[index]).rectTransform.anchoredPosition.x, (float) (-95.0 - (double) index * 33.0));
      }
    }
    num = 0U;
    uint x5 = 0;
    uint x6 = 0;
    for (int index = 0; index < 16; ++index)
    {
      x5 += this.AWM.m_CombatPlayerData[1].DeadTroop[index];
      x6 += this.AWM.m_CombatPlayerData[1].SurviveTroop[index];
    }
    uint x7 = x6 + x5;
    this.Cstr_LossValue[1].ClearString();
    this.Cstr_LossValue[1].IntToFormat((long) x5, bNumber: true);
    this.Cstr_LossValue[1].AppendFormat("{0}");
    this.text_LossValue[1].text = this.Cstr_LossValue[1].ToString();
    this.text_LossValue[1].SetAllDirty();
    this.text_LossValue[1].cachedTextGenerator.Invalidate();
    this.Cstr_Strength[1].ClearString();
    this.Cstr_Strength[1].uLongToFormat(this.AWM.m_CombatPlayerData[1].LosePower, bNumber: true);
    this.Cstr_Strength[1].AppendFormat(this.DM.mStringTable.GetStringByID(5322U));
    this.text_Strength[1].text = this.Cstr_Strength[1].ToString();
    this.text_Strength[1].SetAllDirty();
    this.text_Strength[1].cachedTextGenerator.Invalidate();
    this.Cstr_RA[0].ClearString();
    this.Cstr_RA[0].IntToFormat((long) x7, bNumber: true);
    this.Cstr_RA[0].AppendFormat("{0}");
    this.text_RA[0].text = this.Cstr_RA[0].ToString();
    this.Cstr_RA[1].ClearString();
    this.Cstr_RA[1].IntToFormat(0L, bNumber: true);
    this.Cstr_RA[1].AppendFormat("{0}");
    this.text_RA[1].text = this.Cstr_RA[1].ToString();
    this.Cstr_RA[2].ClearString();
    this.Cstr_RA[2].IntToFormat((long) x5, bNumber: true);
    this.Cstr_RA[2].AppendFormat("{0}");
    this.text_RA[2].text = this.Cstr_RA[2].ToString();
    this.Cstr_RA[3].ClearString();
    this.Cstr_RA[3].IntToFormat((long) x6, bNumber: true);
    this.Cstr_RA[3].AppendFormat("{0}");
    this.text_RA[3].text = this.Cstr_RA[3].ToString();
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
      this.Cstr_RF.Append(this.DM.mStringTable.GetStringByID((uint) (ushort) (9778U + (uint) this.AWM.m_CombatPlayerData[1].ArmyCoordIndex)));
      this.text_RF.text = this.Cstr_RF.ToString();
      this.text_RF.SetAllDirty();
      this.text_RF.cachedTextGenerator.Invalidate();
      this.text_RF.cachedTextGeneratorForLayout.Invalidate();
      float x8 = (double) this.text_RF.preferredWidth + 1.0 <= 390.0 ? this.text_RF.preferredWidth + 1f : 390f;
      ((Graphic) this.text_RF).rectTransform.sizeDelta = new Vector2(x8, ((Graphic) this.text_RF).rectTransform.sizeDelta.y);
      if (this.GUIM.IsArabic)
        this.text_RF.UpdateArabicPos();
      this.tmpRC = ((Component) this.btn_RF).transform.GetComponent<RectTransform>();
      this.tmpRC.sizeDelta = new Vector2(x8, this.tmpRC.sizeDelta.y);
      ((Graphic) this.Img_RF).rectTransform.sizeDelta = new Vector2(x8, ((Graphic) this.Img_RF).rectTransform.sizeDelta.y);
      ((Component) this.btn_RF).gameObject.SetActive(true);
    }
    else
      ((Component) this.btn_RF).gameObject.SetActive(false);
    if (flag3)
      this.tmpH -= 33f;
    this.tmpH -= 498f;
    this.tmpH -= 281f;
    this.Cstr_Offensive[0].ClearString();
    this.Cstr_Offensive[1].ClearString();
    if (this.AWM.MyAllySide == (byte) 1)
    {
      this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(11163U));
      this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(11164U));
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
    }
    else if (this.AWM.MyAllySide == (byte) 2)
    {
      this.Cstr_Offensive[0].Append(this.DM.mStringTable.GetStringByID(11164U));
      this.Cstr_Offensive[1].Append(this.DM.mStringTable.GetStringByID(11163U));
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
    ((Component) this.QuanmieRT).gameObject.SetActive(false);
    this.tmpRC = ((Component) this.btn_Details).transform.GetComponent<RectTransform>();
    this.tmpH += 100f;
    this.tmpH += 281f;
    this.tmpH -= this.tmpH2;
    this.tmpRC.anchoredPosition = !flag3 ? new Vector2(this.tmpRC.anchoredPosition.x, -750.5f - this.tmpH2) : new Vector2(this.tmpRC.anchoredPosition.x, -783.5f - this.tmpH2);
    if (flag3)
    {
      ((Graphic) this.Img_Army[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Army[0]).rectTransform.sizeDelta.x, 431f + this.tmpH2);
      ((Graphic) this.Img_Army[1]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Army[1]).rectTransform.sizeDelta.x, 431f + this.tmpH2);
      ((Graphic) this.text_NpcInfo).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_NpcInfo).rectTransform.anchoredPosition.x, -310f);
    }
    else
    {
      ((Graphic) this.Img_Army[0]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Army[0]).rectTransform.sizeDelta.x, 398f + this.tmpH2);
      ((Graphic) this.Img_Army[1]).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Army[1]).rectTransform.sizeDelta.x, 398f + this.tmpH2);
      ((Graphic) this.text_NpcInfo).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_NpcInfo).rectTransform.anchoredPosition.x, -277f);
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
    this.ContentRT.sizeDelta = new Vector2(this.ContentRT.sizeDelta.x, -this.tmpH);
    ((Component) this.btn_Replay).gameObject.SetActive(true);
    this.bSetFSShow = false;
    this.LightT1.gameObject.SetActive(true);
    ((Component) this.text_Summary).gameObject.SetActive(true);
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!this.bSetFSShow && this.bInitFS && !this.bQuanmier && (Object) this.SummaryRT != (Object) null && !((Component) this.SummaryRT).gameObject.activeSelf)
    {
      ((Component) this.SummaryRT).gameObject.SetActive(true);
      this.bSetFSShow = true;
    }
    if ((Object) this.btn_Replay != (Object) null && ((UIBehaviour) this.btn_Replay).IsActive())
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
      if ((Object) this.Img_Crown[1] != (Object) null)
        ((Graphic) this.Img_Crown[1]).color = new Color(1f, 1f, 1f, a);
      if ((Object) this.Img_BossHeroCrown[0] != (Object) null && ((UIBehaviour) this.Img_BossHeroCrown[0]).IsActive())
        ((Graphic) this.Img_BossHeroCrown[1]).color = new Color(1f, 1f, 1f, a);
    }
    this.ShowMainHeroTime2 += Time.smoothDeltaTime;
    if ((double) this.ShowMainHeroTime2 >= 0.0)
    {
      if ((double) this.ShowMainHeroTime2 >= 2.0)
        this.ShowMainHeroTime2 = 0.0f;
      float a = (double) this.ShowMainHeroTime2 <= 1.0 ? this.ShowMainHeroTime2 : 2f - this.ShowMainHeroTime2;
      if ((Object) this.Img_Crown[3] != (Object) null)
        ((Graphic) this.Img_Crown[3]).color = new Color(1f, 1f, 1f, a);
    }
    if ((Object) this.LightT1 != (Object) null)
      this.LightT1.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    this.ShowVsTime += Time.smoothDeltaTime;
    if ((double) this.ShowVsTime >= 0.0)
    {
      if ((double) this.ShowVsTime >= 2.0)
        this.ShowVsTime = 0.0f;
      float a = (double) this.ShowVsTime <= 1.0 ? this.ShowVsTime : 2f - this.ShowVsTime;
      if ((Object) this.Img_Vs != (Object) null)
        ((Graphic) this.Img_Vs).color = new Color(1f, 1f, 1f, a);
    }
    if (!((Object) this.LightT2 != (Object) null))
      return;
    this.LightT2.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
  }

  private void SetPorfileBtn()
  {
    int index1 = 0;
    int index2 = 3;
    if (this.Img_MainHero != null && (Object) this.Img_MainHero[index1] != (Object) null && (Object) ((Component) this.Img_MainHero[index1]).transform.GetChild(0) != (Object) null)
    {
      UIButton component = ((Component) this.Img_MainHero[index1]).transform.GetChild(0).gameObject.GetComponent<UIButton>();
      if ((Object) component != (Object) null)
      {
        component.m_Handler = (IUIButtonClickHandler) this;
        component.m_BtnID1 = index1 != 0 ? 4 : 3;
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
    component1.m_BtnID1 = index2 != 0 ? 4 : 3;
    component1.m_EffectType = e_EffectType.e_Scale;
    component1.transition = (Selectable.Transition) 0;
  }

  private void ShowLordProfile(Alliance_FS_btn type)
  {
    this.DM.PlayerName_War[0].Append(this.AWM.m_CombatPlayerData[0].Name);
    this.DM.PlayerName_War[1].Append(this.AWM.m_CombatPlayerData[1].Name);
    switch (type)
    {
      case Alliance_FS_btn.btn_Porfile_Atk:
        if (!(this.AWM.m_CombatPlayerData[0].Name != string.Empty))
          break;
        DataManager.Instance.ShowLordProfile(this.AWM.m_CombatPlayerData[0].Name);
        break;
      case Alliance_FS_btn.btn_Porfile_Def:
        if (!(this.AWM.m_CombatPlayerData[1].Name != string.Empty))
          break;
        DataManager.Instance.ShowLordProfile(this.AWM.m_CombatPlayerData[1].Name);
        break;
    }
  }
}
