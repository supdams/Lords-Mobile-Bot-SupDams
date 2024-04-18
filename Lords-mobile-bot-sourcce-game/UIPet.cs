// Decompiled with JetBrains decompiler
// Type: UIPet
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIPet : 
  GUIWindow,
  UILoadImageHander,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUTimeBarOnTimer
{
  private const int SkillCount = 3;
  private Transform m_transform;
  private RectTransform EmojiRC;
  private DataManager DM;
  private GUIManager GM;
  private PetManager PM;
  private Door m_door;
  private UIText PetNameText;
  private UIText ExpText;
  private UIText StoneText;
  private UIText LevelText_L;
  private UIText RareText;
  private UIText LevelText;
  private UIText RankText;
  private UIText RankText2;
  private UIText UpText;
  private UIText PanelTitleText1;
  private UIText PanelTitleText2;
  private UIText MaxShowText;
  private CString ExpStr;
  private CString StoneStr;
  private CString LevelStr_L;
  private CString RareStr;
  private CString LevelStr;
  private CString RankStr;
  private CString UpStr;
  private Transform[] SkillT = new Transform[3];
  private Transform[] SkillBtnT = new Transform[3];
  private UIButton[] SkillBtn = new UIButton[3];
  private Transform[] SkillBtnAlertT = new Transform[3];
  private UIText[] SkillNameText = new UIText[3];
  private CString[] SkillNameStr = new CString[3];
  private UIText[] SkillExpText = new UIText[3];
  private CString[] SkillExpStr = new CString[3];
  private Transform[] SkillExpImageT = new Transform[3];
  private Image[] SkillExpImage = new Image[3];
  private UISpritesArray[] SkillExpImageSP = new UISpritesArray[3];
  private Image[] SkillImage1 = new Image[3];
  private Image[] SkillImage2 = new Image[3];
  private UISpritesArray[] SkillImage2SP = new UISpritesArray[3];
  private GameObject[] SkillLockGO = new GameObject[3];
  private UIText[] SkillLockText = new UIText[3];
  private Image[] SkillkindImage = new Image[3];
  private UISpritesArray[] SkillkindSP = new UISpritesArray[3];
  private UIButtonHint[] SkillKindHint = new UIButtonHint[3];
  private UIButtonHint[] SkillPicHint = new UIButtonHint[3];
  private Image ExpImage;
  private Image MaxShowBack;
  private UISpritesArray ExpSP;
  private UISpritesArray BloodSP;
  private Transform StoneIcon;
  private Transform PetIcon;
  private Transform PetStateImage;
  private Transform StoneT;
  private Transform MaxShowT;
  private Transform RankT;
  private Transform TimeBarBackT;
  private Transform Left_T;
  private Transform Right_T;
  private Transform BloodBtnT;
  private Transform PanelRLightT;
  private Transform PanelBlockT;
  private Transform TimeBarEffectT;
  private UITimeBar TimeBar;
  private CString HinString;
  private EmojiUnit EmojiBack;
  private EmojiUnit Emoji;
  private float MaxShowFalshTime;
  private bool bMaxShow;
  private PetData NowPet;
  private PetTbl sPet;
  private Hero sHero;
  private GameObject PetGO;
  private AssetBundle AB;
  private AssetBundleRequest AR;
  private int AssetKey;
  private bool bABInitial;
  private Transform PetModel;
  private RectTransform PetPosRT;
  private float ActionTime;
  private float ActionTimeRandom;
  private float MovingTimer;
  private string PetAct;
  private Animation tmpAN;
  public string[] mPetAct = new string[7];
  private UIBtnDrag btn_PetActionD;
  private byte RandomEnd = 1;
  private float MoveX;
  private float LeftPosX;
  private float RightPosX;
  private Vector3 BtnPos;
  private int SelectSkillIndex = -1;
  private Transform ASExp_PanelT;
  private Transform ASExp_MaxImageT;
  private Transform ASExp_SkillLockT;
  private Transform ASExp_StoneIconT1;
  private Transform ASExp_StoneIconT2;
  private Transform ASExp_AddBtnT1;
  private Transform ASExp_AddBtnT2;
  private Transform ASExp_MaxRImageT;
  private Transform ASExp_SelectTextBackT;
  private Image ASExp_SkillImage1;
  private Image ASExp_SkillImage2;
  private Image ASExp_ExpBar;
  private Image ASExp_ExpBarImage;
  private Image ASExp_InfoNowCDImage;
  private Image ASExp_InfoNextCDImage;
  private Image ASExp_EffIconBlockImage;
  private Image ASExp_EffIconMoveImage;
  private Image ASExp_EffBarBlockImage;
  private Image ASExp_EffBarInnerImage;
  private Image ASExp_EffExpBackImage;
  private Image ASExp_SkillLockImage;
  private UIText ASExp_InfoNowtext;
  private UIText ASExp_InfoNextText;
  private UIText ASExp_SkillNameText;
  private UIText ASExp_SkillLvText;
  private UIText ASExp_SkillExpText;
  private UIText ASExp_SelectText;
  private UIText ASExp_BottomTipText;
  private UIText ASExp_NeedCountText1;
  private UIText ASExp_NeedCountText2;
  private UIText ASExp_HaveCountText1;
  private UIText ASExp_HaveCountText2;
  private UIText ASExp_UpText1;
  private UIText ASExp_UpText2;
  private UIText ASExp_MaxText;
  private UIText ASExp_TitleText;
  private UIText ASExp_InfoNowTitletext;
  private UIText ASExp_InfoNextTitleText;
  private UIText ASExp_InfoNowCDtext;
  private UIText ASExp_InfoNextCDText;
  private UIText ASExp_EffExpText;
  private UIText ASExp_EffX2Text;
  private CString ASExp_InfoNowStr;
  private CString ASExp_InfoNextStr;
  private CString ASExp_SkillLvStr;
  private CString ASExp_SkillExpStr;
  private CString ASExp_InfoNowCDStr;
  private CString ASExp_InfoNextCDStr;
  private CString ASExp_InfoStr;
  private CString ASExp_NeedCountStr1;
  private CString ASExp_NeedCountStr2;
  private CString ASExp_HaveCountStr1;
  private CString ASExp_HaveCountStr2;
  private CString ASExp_EffExpStr;
  private CString ASExp_EffX2Str;
  private UIButton ASExp_AddBtn1;
  private UIButton ASExp_AddBtn2;
  private GameObject ASExp_AddBtn1Click;
  private GameObject ASExp_AddBtn2Click;
  private UISpritesArray ASExp_ExpSP;
  private UISpritesArray ASExp_LockSP;
  private UIButtonHint ASExp_SkillMaxHint;
  private UIButtonHint ASExp_SrcHint;
  private UIButtonHint ASExp_LockHint;
  private bool bCount1;
  private bool bCount2;
  private bool bLevel;
  private ushort ASExp_ExpItemID = 3701;
  private eUIPet_Eff ASExp_EffectKind;
  private float ASExp_EffDTime;
  private float ASExp_EffTatalTime;
  private bool ASExp_EffbLVUp;
  private bool ASExp_bPlaySound;
  private Vector2 IconMove_OriginalPos = Vector2.zero;
  private Vector2[] IconMove_PosValue = new Vector2[3]
  {
    new Vector2(0.0f, 0.0f),
    new Vector2(0.0f, 257f),
    new Vector2(0.0f, 0.0f)
  };
  private float[] IconMove_PosKey = new float[3]
  {
    0.0f,
    0.6f,
    1f
  };
  private float[] IconMove_AlphaValue = new float[5]
  {
    0.0f,
    1f,
    1f,
    0.0f,
    0.0f
  };
  private float[] IconMove_AlphaKey = new float[5]
  {
    0.0f,
    0.166666672f,
    0.266666681f,
    0.433333337f,
    1f
  };
  private Vector2[] IconBlock_ScaleValue = new Vector2[6]
  {
    new Vector2(1f, 1f),
    new Vector2(1.05f, 1.05f),
    new Vector2(1.1f, 1.1f),
    new Vector2(1.05f, 1.05f),
    new Vector2(1.15f, 1.15f),
    new Vector2(1f, 1f)
  };
  private float[] IconBlock_ScaleKey = new float[6]
  {
    0.0f,
    0.13333334f,
    0.166666672f,
    0.433333337f,
    0.6666667f,
    1f
  };
  private float[] IconBlock_AlphaValue = new float[5]
  {
    0.0f,
    1f,
    1f,
    0.0f,
    0.0f
  };
  private float[] IconBlock_AlphaKey = new float[5]
  {
    0.0f,
    0.166666672f,
    0.433333337f,
    0.6666667f,
    1f
  };
  private float[] BarBlockImageAlphaValue = new float[3]
  {
    0.0f,
    1f,
    0.0f
  };
  private float[] BarBlockImageAlphaKey = new float[3]
  {
    0.366666675f,
    0.433333337f,
    0.966666639f
  };
  private Vector2[] BarBlockImageScaleValue_Up = new Vector2[3]
  {
    new Vector2(1f, 1f),
    new Vector2(1.02f, 1.25f),
    new Vector2(1f, 1f)
  };
  private float[] BarBlockImageScaleKey_Up = new float[3]
  {
    0.533333361f,
    0.6f,
    0.7f
  };
  private float[] BarBlockImageAlphaValue_Up = new float[5]
  {
    0.0f,
    0.0f,
    1f,
    0.8f,
    0.0f
  };
  private float[] BarBlockImageAlphaKey_Up = new float[5]
  {
    0.0f,
    0.366666675f,
    0.433333337f,
    0.766666651f,
    0.933333337f
  };
  private Vector2[] BarInnerImageScaleValue = new Vector2[2]
  {
    new Vector2(0.0f, 0.0f),
    new Vector2(1f, 1f)
  };
  private float[] BarInnerImageScaleKey = new float[2]
  {
    0.533333361f,
    0.6f
  };
  private float[] BarInnerImageAlphaValue = new float[3]
  {
    0.0f,
    1f,
    0.0f
  };
  private float[] BarInnerImageAlphaKey = new float[3]
  {
    0.533333361f,
    0.6f,
    0.966666639f
  };
  private Vector2 ExpText_OriginalPos = Vector2.zero;
  private Vector2[] ExpText_PositionValue = new Vector2[2]
  {
    new Vector2(0.0f, 0.0f),
    new Vector2(0.0f, 66f)
  };
  private float[] ExpText_PositionKey = new float[2]
  {
    0.1f,
    0.4f
  };
  private Vector2[] ExpText_ScaleValue = new Vector2[2]
  {
    new Vector2(0.8f, 0.8f),
    new Vector2(1f, 1f)
  };
  private float[] ExpText_ScaleKey = new float[2]
  {
    0.266666681f,
    0.4f
  };
  private float[] ExpText_AlphaValue = new float[4]
  {
    0.0f,
    1f,
    1f,
    0.0f
  };
  private float[] ExpText_AlphaKey = new float[4]
  {
    0.2f,
    0.266666681f,
    0.966666639f,
    1.06666672f
  };
  private float ImageFAFrom;
  private float ImageFATo;
  private uint ImageExpNeed;
  private float[] ExpBarFA_ScaleKey = new float[2]
  {
    0.366666675f,
    0.533333361f
  };
  private Vector2[] ExpTextX2_PositionValue = new Vector2[2]
  {
    new Vector2(0.0f, 0.0f),
    new Vector2(0.0f, 66f)
  };
  private float[] ExpTextX2_PositionKey = new float[2]
  {
    0.366666675f,
    0.6666667f
  };
  private Vector2[] ExpTextX2_ScaleValue = new Vector2[2]
  {
    new Vector2(0.6f, 0.6f),
    new Vector2(1f, 1f)
  };
  private float[] ExpTextX2_ScaleKey = new float[2]
  {
    0.333333343f,
    0.566666663f
  };
  private float[] ExpTextX2_AlphaValue = new float[4]
  {
    0.0f,
    1f,
    1f,
    0.0f
  };
  private float[] ExpTextX2_AlphaKey = new float[4]
  {
    0.36f,
    0.53f,
    1.6f,
    1.83f
  };
  private Vector2[] X2Text_ScaleValue = new Vector2[3]
  {
    new Vector2(0.0f, 0.0f),
    new Vector2(0.6666667f, 0.6666667f),
    new Vector2(1.2f, 1.2f)
  };
  private float[] X2Text_ScaleKey = new float[3]
  {
    0.333333343f,
    0.4f,
    0.6666667f
  };
  private float[] X2Text_AlphaValue = new float[4]
  {
    0.0f,
    1f,
    1f,
    0.0f
  };
  private float[] X2Text_AlphaKey = new float[4]
  {
    0.33f,
    0.4f,
    1.56f,
    1.63f
  };
  private Vector2[] ExpBar_ScaleValue = new Vector2[7]
  {
    new Vector2(1f, 1f),
    new Vector2(1.1f, 1.5f),
    new Vector2(1.3f, 2.5f),
    new Vector2(1f, 1f),
    new Vector2(1f, 1f),
    new Vector2(1f, 1f),
    new Vector2(1f, 1f)
  };
  private float[] ExpBar_ScaleKey = new float[7]
  {
    0.53f,
    0.66f,
    0.76f,
    0.83f,
    0.9f,
    0.96f,
    1.03f
  };
  private Vector2[] ExpBarText_ScaleValue = new Vector2[5]
  {
    new Vector2(1f, 1f),
    new Vector2(2f, 2f),
    new Vector2(3f, 4.7f),
    new Vector2(2f, 2f),
    new Vector2(1f, 1f)
  };
  private float[] ExpBarText_ScaleKey = new float[5]
  {
    0.53f,
    0.66f,
    0.76f,
    0.86f,
    0.96f
  };
  private float[] ExpBarText_AlphaValue = new float[2]
  {
    1f,
    1f
  };
  private float[] ExpBarText_AlphaKey = new float[2]
  {
    0.53f,
    0.66f
  };
  private Vector2[] BarBlockImageX2ScaleValue = new Vector2[7]
  {
    new Vector2(0.0f, 0.0f),
    new Vector2(1.1f, 2f),
    new Vector2(1.45f, 3f),
    new Vector2(1.05f, 1.1f),
    new Vector2(1.05f, 1.5f),
    new Vector2(1.1f, 1f),
    new Vector2(1f, 1f)
  };
  private float[] BarBlockImageX2ScaleKey = new float[7]
  {
    0.53f,
    0.66f,
    0.76f,
    0.83f,
    0.9f,
    0.96f,
    1.03f
  };
  private float[] BarBlockImageX2AlphaValue = new float[3]
  {
    0.0f,
    1f,
    0.0f
  };
  private float[] BarBlockImageX2AlphaKey = new float[3]
  {
    0.53f,
    0.66f,
    1.03f
  };
  private Vector2[] BarInnerImageX2ScaleValue = new Vector2[7]
  {
    new Vector2(1f, 1f),
    new Vector2(1.1f, 1.5f),
    new Vector2(1.3f, 2.5f),
    new Vector2(1f, 1f),
    new Vector2(1f, 1f),
    new Vector2(1f, 1f),
    new Vector2(1f, 1f)
  };
  private float[] BarInnerImageX2ScaleKey = new float[7]
  {
    0.53f,
    0.66f,
    0.76f,
    0.83f,
    0.9f,
    0.96f,
    1.03f
  };
  private float[] BarInnerImageX2AlphaValue = new float[3]
  {
    0.0f,
    0.5f,
    0.0f
  };
  private float[] BarInnerImageX2AlphaKey = new float[3]
  {
    0.53f,
    0.66f,
    1.03f
  };
  private GameObject X2ParticleGO;
  private float[] X2LockImage_AlphaValue = new float[4]
  {
    1f,
    0.0f,
    0.0f,
    1f
  };
  private float[] X2LockImage_AlphaKey = new float[4]
  {
    0.33f,
    0.4f,
    1.36f,
    1.6f
  };
  private int NowEvoID = -1;
  private Transform EVO_panelT;
  private Transform EVO_StoneIconT;
  private UIText EVO_TitleText;
  private UIText EVO_InfoText;
  private UIText EVO_UpText;
  private UIText EVO_NeedLvText;
  private UIText EVO_LPriceText;
  private UIText EVO_LBtnText;
  private UIText EVO_RTimeText;
  private UIText EVO_RBtnText;
  private CString EVO_UpStr;
  private CString EVO_NeedStr;
  private CString EVO_PriceStr;
  private CString EVO_TimeStr;
  private UIButtonHint EVO_SrcHint;
  private float EmijiShowTime1 = 0.1f;
  private float EmijiShowTime2 = 0.08f;
  private float EmojiShowMaxScale = 1.15f;
  private float EmijiShowCountTime = -1f;
  private ushort[] ParticleID = new ushort[3]
  {
    (ushort) 441,
    (ushort) 442,
    (ushort) 443
  };
  private GameObject ParticleObj;
  private GameObject ParticleObj_Bar;
  private ushort ShowUpEffectPetID;
  private GameObject UpParticleGO;
  private float ClickAddSkillTime = -1f;
  private RectTransform LightRC;
  private Light myLight1;
  private Light myLight2;
  private Light myLight3;
  private Color MaxTextColor = (Color) new Color32(byte.MaxValue, (byte) 247, (byte) 153, byte.MaxValue);

  public Door door
  {
    get
    {
      if ((Object) this.m_door == (Object) null)
        this.m_door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      return this.m_door;
    }
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.PM = PetManager.Instance;
    this.m_transform = this.transform;
    Font ttfFont = this.GM.GetTTFFont();
    if (arg1 == 1)
      this.bMaxShow = true;
    this.LightRC = this.m_transform.GetChild(12).GetComponent<RectTransform>();
    this.myLight1 = this.m_transform.GetChild(12).GetChild(0).GetComponent<Light>();
    this.myLight2 = this.m_transform.GetChild(12).GetChild(1).GetComponent<Light>();
    this.myLight3 = this.m_transform.GetChild(12).GetChild(2).GetComponent<Light>();
    this.HinString = StringManager.Instance.SpawnString(1024);
    this.m_transform.GetChild(0).GetChild(4).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(1).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(2).GetChild(3).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(4).GetChild(11).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(6).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(8).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(9).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(7).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(13).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(14).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    if (this.GM.IsArabic)
      this.m_transform.GetChild(6).gameObject.AddComponent<ArabicItemTextureRot>();
    this.m_transform.GetChild(7).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(7).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(7).GetComponent<CustomImage>()).enabled = false;
    UIButtonHint uiButtonHint1 = this.m_transform.GetChild(0).GetChild(1).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    uiButtonHint1.Parm1 = (ushort) 16047;
    uiButtonHint1.Parm2 = (byte) 6;
    this.PetPosRT = this.m_transform.GetChild(10).GetComponent<RectTransform>();
    this.btn_PetActionD = this.m_transform.GetChild(1).gameObject.AddComponent<UIBtnDrag>();
    this.btn_PetActionD.mHero = this.PetPosRT;
    this.PetPosRT.anchoredPosition3D = new Vector3(-239f, -200f, 100f);
    this.LightRC.anchoredPosition3D = new Vector3(0.0f, 0.0f, 300f);
    this.BloodBtnT = this.m_transform.GetChild(0).GetChild(4);
    this.BloodSP = this.m_transform.GetChild(0).GetChild(4).GetComponent<UISpritesArray>();
    this.StoneT = this.m_transform.GetChild(2);
    this.MaxShowT = this.m_transform.GetChild(3);
    this.RankT = this.m_transform.GetChild(4).GetChild(11);
    this.RankText2 = this.m_transform.GetChild(4).GetChild(11).GetChild(0).GetComponent<UIText>();
    this.RankText2.font = ttfFont;
    this.RankText2.text = this.DM.mStringTable.GetStringByID(7475U);
    this.TimeBarBackT = this.m_transform.GetChild(4).GetChild(12);
    this.Left_T = this.m_transform.GetChild(8);
    this.Right_T = this.m_transform.GetChild(9);
    this.LeftPosX = this.Left_T.localPosition.x + 20f;
    this.RightPosX = this.Right_T.localPosition.x - 20f;
    this.MoveX = 0.0f;
    this.CheckShowLRBtn();
    this.PanelRLightT = this.m_transform.GetChild(4).GetChild(1);
    this.PanelBlockT = this.m_transform.GetChild(4).GetChild(2);
    this.PetIcon = this.m_transform.GetChild(4).GetChild(3);
    this.GM.InitianHeroItemImg(this.PetIcon, eHeroOrItem.Pet, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
    UIButtonHint uiButtonHint2 = this.m_transform.GetChild(4).GetChild(4).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint2.m_Handler = (MonoBehaviour) this;
    uiButtonHint2.Parm2 = (byte) 8;
    this.PetStateImage = this.m_transform.GetChild(4).GetChild(5);
    UIButtonHint uiButtonHint3 = this.PetStateImage.gameObject.AddComponent<UIButtonHint>();
    uiButtonHint3.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint3.m_Handler = (MonoBehaviour) this;
    uiButtonHint3.Parm1 = (ushort) 16065;
    this.StoneIcon = this.m_transform.GetChild(2).GetChild(1);
    this.GM.InitianHeroItemImg(this.StoneIcon, eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
    this.PetNameText = this.m_transform.GetChild(0).GetChild(2).GetComponent<UIText>();
    this.PetNameText.font = ttfFont;
    this.PetNameText.fontSize = 24;
    this.PetNameText.resizeTextMaxSize = 24;
    this.ExpText = this.m_transform.GetChild(0).GetChild(3).GetChild(1).GetComponent<UIText>();
    this.ExpText.font = ttfFont;
    this.ExpStr = StringManager.Instance.SpawnString();
    this.StoneText = this.m_transform.GetChild(2).GetChild(2).GetComponent<UIText>();
    this.StoneText.font = ttfFont;
    this.StoneStr = StringManager.Instance.SpawnString();
    this.MaxShowBack = this.m_transform.GetChild(3).GetComponent<Image>();
    this.MaxShowText = this.m_transform.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.MaxShowText.font = ttfFont;
    this.MaxShowText.text = this.DM.mStringTable.GetStringByID(10046U);
    this.LevelText_L = this.m_transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.LevelText_L.font = ttfFont;
    this.LevelStr_L = StringManager.Instance.SpawnString();
    this.RareText = this.m_transform.GetChild(4).GetChild(6).GetChild(0).GetComponent<UIText>();
    this.RareText.font = ttfFont;
    this.RareStr = StringManager.Instance.SpawnString();
    UIButtonHint uiButtonHint4 = this.m_transform.GetChild(4).GetChild(6).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint4.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint4.m_Handler = (MonoBehaviour) this;
    uiButtonHint4.Parm1 = (ushort) 16080;
    uiButtonHint4.Parm2 = (byte) 5;
    this.LevelText = this.m_transform.GetChild(4).GetChild(8).GetComponent<UIText>();
    this.LevelText.font = ttfFont;
    this.LevelStr = StringManager.Instance.SpawnString();
    this.RankText = this.m_transform.GetChild(4).GetChild(7).GetComponent<UIText>();
    this.RankText.font = ttfFont;
    this.RankStr = StringManager.Instance.SpawnString();
    this.UpText = this.m_transform.GetChild(4).GetChild(10).GetComponent<UIText>();
    this.UpText.font = ttfFont;
    this.UpStr = StringManager.Instance.SpawnString();
    this.PanelTitleText1 = this.m_transform.GetChild(4).GetChild(0).GetComponent<UIText>();
    this.PanelTitleText1.font = ttfFont;
    this.PanelTitleText1.text = this.DM.mStringTable.GetStringByID(370U);
    this.PanelTitleText2 = this.m_transform.GetChild(5).GetChild(5).GetComponent<UIText>();
    this.PanelTitleText2.font = ttfFont;
    this.PanelTitleText2.text = this.DM.mStringTable.GetStringByID(16060U);
    for (int index = 0; index < 3; ++index)
    {
      this.SkillT[index] = this.m_transform.GetChild(5).GetChild(index + 2);
      this.SkillNameText[index] = this.SkillT[index].GetChild(1).GetComponent<UIText>();
      this.SkillNameText[index].font = ttfFont;
      this.SkillNameStr[index] = StringManager.Instance.SpawnString();
      this.SkillExpText[index] = this.SkillT[index].GetChild(3).GetComponent<UIText>();
      this.SkillExpText[index].font = ttfFont;
      this.SkillExpStr[index] = StringManager.Instance.SpawnString();
      this.SkillLockGO[index] = this.SkillT[index].GetChild(6).gameObject;
      this.SkillLockText[index] = this.SkillLockGO[index].transform.GetChild(0).GetComponent<UIText>();
      this.SkillLockText[index].font = ttfFont;
      this.SkillExpImageT[index] = this.SkillT[index].GetChild(2);
      this.SkillExpImage[index] = this.SkillT[index].GetChild(2).GetChild(0).GetComponent<Image>();
      this.SkillExpImageSP[index] = this.SkillT[index].GetChild(2).GetChild(0).GetComponent<UISpritesArray>();
      this.SkillImage1[index] = this.SkillT[index].GetChild(0).GetComponent<Image>();
      this.SkillPicHint[index] = this.SkillT[index].GetChild(0).gameObject.AddComponent<UIButtonHint>();
      this.SkillPicHint[index].m_eHint = EUIButtonHint.DownUpHandler;
      this.SkillPicHint[index].m_Handler = (MonoBehaviour) this;
      this.SkillPicHint[index].Parm2 = (byte) 3;
      this.SkillImage2[index] = this.SkillT[index].GetChild(0).GetChild(0).GetComponent<Image>();
      this.SkillImage2[index].sprite = this.GM.LoadFrameSprite("sk");
      ((MaskableGraphic) this.SkillImage2[index]).material = this.GM.GetFrameMaterial();
      this.SkillImage2SP[index] = this.SkillT[index].GetChild(0).GetChild(0).GetComponent<UISpritesArray>();
      this.SkillBtnT[index] = this.SkillT[index].GetChild(5);
      this.SkillBtnAlertT[index] = this.SkillT[index].GetChild(5).GetChild(0);
      this.SkillBtn[index] = this.SkillT[index].GetChild(5).GetComponent<UIButton>();
      this.SkillBtn[index].m_Handler = (IUIButtonClickHandler) this;
      this.SkillkindImage[index] = this.SkillT[index].GetChild(4).GetComponent<Image>();
      this.SkillkindSP[index] = this.SkillT[index].GetChild(4).GetComponent<UISpritesArray>();
      this.SkillKindHint[index] = this.SkillT[index].GetChild(4).gameObject.AddComponent<UIButtonHint>();
      this.SkillKindHint[index].m_eHint = EUIButtonHint.DownUpHandler;
      this.SkillKindHint[index].m_Handler = (MonoBehaviour) this;
      this.SkillKindHint[index].Parm2 = (byte) 7;
    }
    this.ExpImage = this.m_transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<Image>();
    this.ExpSP = this.m_transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<UISpritesArray>();
    this.TimeBarEffectT = this.m_transform.GetChild(4).GetChild(13);
    ((RectTransform) this.TimeBarEffectT).anchoredPosition = new Vector2(-1.6f, -34.7f);
    this.TimeBar = this.m_transform.GetChild(4).GetChild(14).GetComponent<UITimeBar>();
    this.TimeBar.m_Handler = (IUTimeBarOnTimer) this;
    ((RectTransform) this.TimeBar.transform).sizeDelta = new Vector2(261.8f, 29f);
    this.GM.CreateTimerBar(this.TimeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
    this.EmojiRC = (RectTransform) this.m_transform.GetChild(11);
    this.EmojiBack = this.GM.pullEmojiIcon(ushort.MaxValue, (byte) 0);
    this.EmojiBack.EmojiTransform.SetParent((Transform) this.EmojiRC, false);
    if (!this.bMaxShow)
    {
      this.ASExp_PanelT = this.m_transform.GetChild(13);
      if (this.GM.bOpenOnIPhoneX)
      {
        ((RectTransform) this.ASExp_PanelT).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0.0f);
        ((RectTransform) this.ASExp_PanelT).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0.0f);
      }
      this.ASExp_PanelT.GetChild(24).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.ASExp_PanelT.GetChild(24).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      this.ASExp_TitleText = this.ASExp_PanelT.GetChild(2).GetComponent<UIText>();
      this.ASExp_TitleText.font = ttfFont;
      this.ASExp_TitleText.text = this.DM.mStringTable.GetStringByID(12121U);
      this.ASExp_PanelT.GetChild(24).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.ASExp_PanelT.GetChild(25).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.ASExp_PanelT.GetChild(26).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.ASExp_PanelT.GetChild(31).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.ASExp_PanelT.GetChild(37).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.ASExp_AddBtn1 = this.ASExp_PanelT.GetChild(28).GetComponent<UIButton>();
      this.ASExp_AddBtn1.m_Handler = (IUIButtonClickHandler) this;
      this.ASExp_AddBtn1.transition = (Selectable.Transition) 1;
      this.ASExp_AddBtn2 = this.ASExp_PanelT.GetChild(27).GetComponent<UIButton>();
      this.ASExp_AddBtn2.m_Handler = (IUIButtonClickHandler) this;
      this.ASExp_AddBtn2.transition = (Selectable.Transition) 1;
      if (this.GM.IsArabic)
        this.ASExp_PanelT.GetChild(25).gameObject.AddComponent<ArabicItemTextureRot>();
      this.ASExp_SkillMaxHint = this.ASExp_PanelT.GetChild(26).gameObject.AddComponent<UIButtonHint>();
      this.ASExp_SkillMaxHint.m_eHint = EUIButtonHint.DownUpHandler;
      this.ASExp_SkillMaxHint.m_Handler = (MonoBehaviour) this;
      this.ASExp_SkillMaxHint.Parm2 = (byte) 4;
      this.ASExp_SrcHint = this.ASExp_PanelT.GetChild(31).gameObject.AddComponent<UIButtonHint>();
      this.ASExp_SrcHint.m_eHint = EUIButtonHint.DownUpHandler;
      this.ASExp_SrcHint.m_Handler = (MonoBehaviour) this;
      this.ASExp_SrcHint.Parm2 = (byte) 4;
      this.ASExp_SkillImage1 = this.ASExp_PanelT.GetChild(26).GetChild(0).GetComponent<Image>();
      this.ASExp_SkillImage2 = this.ASExp_PanelT.GetChild(26).GetChild(0).GetChild(0).GetComponent<Image>();
      this.ASExp_SkillImage2.sprite = this.GM.LoadFrameSprite("sk");
      ((MaskableGraphic) this.ASExp_SkillImage2).material = this.GM.GetFrameMaterial();
      this.ASExp_InfoNowTitletext = this.ASExp_PanelT.GetChild(4).GetComponent<UIText>();
      this.ASExp_InfoNowTitletext.font = ttfFont;
      this.ASExp_InfoNowTitletext.text = this.DM.mStringTable.GetStringByID(12122U);
      this.ASExp_InfoNowtext = this.ASExp_PanelT.GetChild(5).GetComponent<UIText>();
      this.ASExp_InfoNowtext.font = ttfFont;
      this.ASExp_InfoNowStr = StringManager.Instance.SpawnString(300);
      this.ASExp_InfoNowCDImage = this.ASExp_PanelT.GetChild(6).GetComponent<Image>();
      UIButtonHint uiButtonHint5 = ((Component) this.ASExp_InfoNowCDImage).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint5.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint5.m_Handler = (MonoBehaviour) this;
      uiButtonHint5.Parm1 = (ushort) 12561;
      this.ASExp_InfoNowCDtext = this.ASExp_PanelT.GetChild(7).GetComponent<UIText>();
      this.ASExp_InfoNowCDtext.font = ttfFont;
      this.ASExp_InfoNowCDStr = StringManager.Instance.SpawnString();
      UIButtonHint uiButtonHint6 = ((Component) this.ASExp_InfoNowCDtext).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint6.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint6.m_Handler = (MonoBehaviour) this;
      uiButtonHint6.Parm1 = (ushort) 12561;
      this.ASExp_InfoNextTitleText = this.ASExp_PanelT.GetChild(8).GetComponent<UIText>();
      this.ASExp_InfoNextTitleText.font = ttfFont;
      this.ASExp_InfoNextTitleText.text = this.DM.mStringTable.GetStringByID(12123U);
      this.ASExp_InfoNextText = this.ASExp_PanelT.GetChild(9).GetComponent<UIText>();
      this.ASExp_InfoNextText.font = ttfFont;
      this.ASExp_InfoNextStr = StringManager.Instance.SpawnString(300);
      this.ASExp_InfoNextCDImage = this.ASExp_PanelT.GetChild(10).GetComponent<Image>();
      UIButtonHint uiButtonHint7 = ((Component) this.ASExp_InfoNextCDImage).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint7.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint7.m_Handler = (MonoBehaviour) this;
      uiButtonHint7.Parm1 = (ushort) 12561;
      this.ASExp_InfoNextCDText = this.ASExp_PanelT.GetChild(11).GetComponent<UIText>();
      this.ASExp_InfoNextCDText.font = ttfFont;
      this.ASExp_InfoNextCDStr = StringManager.Instance.SpawnString();
      UIButtonHint uiButtonHint8 = ((Component) this.ASExp_InfoNextCDText).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint8.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint8.m_Handler = (MonoBehaviour) this;
      uiButtonHint8.Parm1 = (ushort) 12561;
      this.ASExp_MaxImageT = this.ASExp_PanelT.GetChild(12);
      this.ASExp_MaxRImageT = this.ASExp_PanelT.GetChild(12).GetChild(0);
      this.ASExp_MaxText = this.ASExp_PanelT.GetChild(12).GetChild(2).GetComponent<UIText>();
      this.ASExp_MaxText.font = ttfFont;
      this.ASExp_MaxText.text = this.DM.mStringTable.GetStringByID(898U);
      this.ASExp_SkillNameText = this.ASExp_PanelT.GetChild(13).GetComponent<UIText>();
      this.ASExp_SkillNameText.font = ttfFont;
      this.ASExp_SkillLvText = this.ASExp_PanelT.GetChild(14).GetComponent<UIText>();
      this.ASExp_SkillLvText.font = ttfFont;
      this.ASExp_SkillLvStr = StringManager.Instance.SpawnString();
      this.ASExp_ExpBar = this.ASExp_PanelT.GetChild(15).GetComponent<Image>();
      this.ASExp_ExpBarImage = this.ASExp_PanelT.GetChild(15).GetChild(0).GetComponent<Image>();
      this.ASExp_ExpSP = this.ASExp_PanelT.GetChild(15).GetChild(0).GetComponent<UISpritesArray>();
      this.ASExp_SkillExpText = this.ASExp_PanelT.GetChild(16).GetComponent<UIText>();
      this.ASExp_SkillExpText.font = ttfFont;
      this.ASExp_SkillExpStr = StringManager.Instance.SpawnString();
      this.ASExp_SkillLockT = this.ASExp_PanelT.GetChild(37);
      this.ASExp_LockSP = this.ASExp_PanelT.GetChild(37).GetComponent<UISpritesArray>();
      this.ASExp_SkillLockImage = this.ASExp_SkillLockT.GetComponent<Image>();
      this.ASExp_LockHint = this.ASExp_SkillLockT.gameObject.AddComponent<UIButtonHint>();
      this.ASExp_LockHint.m_eHint = EUIButtonHint.DownUpHandler;
      this.ASExp_LockHint.m_Handler = (MonoBehaviour) this;
      this.ASExp_LockHint.Parm2 = (byte) 4;
      this.ASExp_AddBtnT1 = this.ASExp_PanelT.GetChild(28);
      this.ASExp_AddBtnT2 = this.ASExp_PanelT.GetChild(27);
      this.ASExp_AddBtn1Click = this.ASExp_PanelT.GetChild(30).gameObject;
      this.ASExp_AddBtn1Click.AddComponent<UIButton>().SoundIndex = byte.MaxValue;
      this.ASExp_AddBtn2Click = this.ASExp_PanelT.GetChild(29).gameObject;
      this.ASExp_AddBtn2Click.AddComponent<UIButton>().SoundIndex = byte.MaxValue;
      this.ASExp_StoneIconT1 = this.ASExp_PanelT.GetChild(21);
      this.GM.InitianHeroItemImg(this.ASExp_StoneIconT1, eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
      this.ASExp_StoneIconT2 = this.ASExp_PanelT.GetChild(19);
      this.GM.InitianHeroItemImg(this.ASExp_StoneIconT2, eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
      this.ASExp_HaveCountText1 = this.ASExp_PanelT.GetChild(22).GetComponent<UIText>();
      this.ASExp_HaveCountText1.font = ttfFont;
      this.ASExp_HaveCountStr1 = StringManager.Instance.SpawnString();
      this.ASExp_HaveCountText2 = this.ASExp_PanelT.GetChild(20).GetComponent<UIText>();
      this.ASExp_HaveCountText2.font = ttfFont;
      this.ASExp_HaveCountStr2 = StringManager.Instance.SpawnString();
      this.ASExp_BottomTipText = this.ASExp_PanelT.GetChild(23).GetComponent<UIText>();
      this.ASExp_BottomTipText.font = ttfFont;
      this.ASExp_BottomTipText.text = this.DM.mStringTable.GetStringByID(12125U);
      this.ASExp_SelectTextBackT = this.ASExp_PanelT.GetChild(17);
      this.ASExp_SelectText = this.ASExp_PanelT.GetChild(18).GetComponent<UIText>();
      this.ASExp_SelectText.font = ttfFont;
      this.ASExp_SelectText.text = this.DM.mStringTable.GetStringByID(12131U);
      this.ASExp_NeedCountText1 = this.ASExp_PanelT.GetChild(28).GetChild(0).GetComponent<UIText>();
      this.ASExp_NeedCountText1.font = ttfFont;
      this.ASExp_NeedCountStr1 = StringManager.Instance.SpawnString();
      this.ASExp_NeedCountText2 = this.ASExp_PanelT.GetChild(27).GetChild(0).GetComponent<UIText>();
      this.ASExp_NeedCountText2.font = ttfFont;
      this.ASExp_NeedCountStr2 = StringManager.Instance.SpawnString();
      this.ASExp_UpText1 = this.ASExp_PanelT.GetChild(28).GetChild(1).GetComponent<UIText>();
      this.ASExp_UpText1.font = ttfFont;
      this.ASExp_UpText1.text = this.DM.mStringTable.GetStringByID(12126U);
      this.ASExp_UpText2 = this.ASExp_PanelT.GetChild(27).GetChild(1).GetComponent<UIText>();
      this.ASExp_UpText2.font = ttfFont;
      this.ASExp_UpText2.text = this.DM.mStringTable.GetStringByID(12126U);
      this.ASExp_EffIconBlockImage = this.ASExp_PanelT.GetChild(34).GetComponent<Image>();
      this.ASExp_EffIconMoveImage = this.ASExp_PanelT.GetChild(35).GetComponent<Image>();
      this.IconMove_OriginalPos = ((Graphic) this.ASExp_EffIconMoveImage).rectTransform.anchoredPosition;
      this.ASExp_EffBarBlockImage = this.ASExp_PanelT.GetChild(36).GetComponent<Image>();
      this.ASExp_EffBarInnerImage = this.ASExp_PanelT.GetChild(38).GetComponent<Image>();
      this.ASExp_EffExpBackImage = this.ASExp_PanelT.GetChild(39).GetComponent<Image>();
      this.ASExp_EffExpText = this.ASExp_PanelT.GetChild(40).GetComponent<UIText>();
      this.ASExp_EffExpText.font = ttfFont;
      this.ASExp_EffExpStr = StringManager.Instance.SpawnString();
      this.ExpText_OriginalPos = ((Graphic) this.ASExp_EffExpText).rectTransform.anchoredPosition;
      this.ASExp_EffX2Text = this.ASExp_PanelT.GetChild(41).GetComponent<UIText>();
      this.ASExp_EffX2Text.font = ttfFont;
      this.ASExp_EffX2Str = StringManager.Instance.SpawnString();
      this.PM.CheckPetSortIndexAndSort();
    }
    this.EVO_panelT = this.m_transform.GetChild(14);
    this.EVO_panelT.GetChild(9).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.EVO_panelT.GetChild(10).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.EVO_panelT.GetChild(11).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.EVO_panelT.GetChild(12).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.EVO_panelT.GetChild(12).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (this.GM.bOpenOnIPhoneX)
    {
      ((RectTransform) this.EVO_panelT).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.EVO_panelT).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0.0f);
    }
    this.EVO_StoneIconT = this.EVO_panelT.GetChild(5);
    this.GM.InitianHeroItemImg(this.EVO_StoneIconT, eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
    this.EVO_TitleText = this.EVO_panelT.GetChild(2).GetComponent<UIText>();
    this.EVO_TitleText.font = ttfFont;
    this.EVO_TitleText.text = this.DM.mStringTable.GetStringByID(16083U);
    this.EVO_InfoText = this.EVO_panelT.GetChild(4).GetComponent<UIText>();
    this.EVO_InfoText.font = ttfFont;
    this.EVO_InfoText.text = this.DM.mStringTable.GetStringByID(16053U);
    this.EVO_UpText = this.EVO_panelT.GetChild(7).GetComponent<UIText>();
    this.EVO_UpText.font = ttfFont;
    this.EVO_UpStr = StringManager.Instance.SpawnString();
    this.EVO_NeedLvText = this.EVO_panelT.GetChild(8).GetComponent<UIText>();
    this.EVO_NeedLvText.font = ttfFont;
    this.EVO_NeedStr = StringManager.Instance.SpawnString(150);
    this.EVO_LPriceText = this.EVO_panelT.GetChild(9).GetChild(1).GetComponent<UIText>();
    this.EVO_LPriceText.font = ttfFont;
    this.EVO_PriceStr = StringManager.Instance.SpawnString();
    this.EVO_LBtnText = this.EVO_panelT.GetChild(9).GetChild(2).GetComponent<UIText>();
    this.EVO_LBtnText.font = ttfFont;
    this.EVO_LBtnText.text = this.DM.mStringTable.GetStringByID(2912U);
    this.EVO_RTimeText = this.EVO_panelT.GetChild(10).GetChild(1).GetComponent<UIText>();
    this.EVO_RTimeText.font = ttfFont;
    this.EVO_TimeStr = StringManager.Instance.SpawnString();
    this.EVO_RBtnText = this.EVO_panelT.GetChild(10).GetChild(2).GetComponent<UIText>();
    this.EVO_RBtnText.font = ttfFont;
    this.EVO_RBtnText.text = this.DM.mStringTable.GetStringByID(16052U);
    this.EVO_SrcHint = this.EVO_panelT.GetChild(11).gameObject.AddComponent<UIButtonHint>();
    this.EVO_SrcHint.m_eHint = EUIButtonHint.DownUpHandler;
    this.EVO_SrcHint.m_Handler = (MonoBehaviour) this;
    this.EVO_SrcHint.Parm2 = (byte) 4;
    this.mPetAct[0] = "idle";
    this.mPetAct[1] = "moving";
    this.mPetAct[2] = "attack";
    this.mPetAct[3] = "skill_1";
    this.mPetAct[4] = "skill_2";
    this.mPetAct[5] = "skill_3";
    this.mPetAct[6] = "victory";
    this.SetNowPet();
    this.door.SetBackGroundPosZ(1000f);
    this.GM.UpdateUI(EGUIWindow.Door, 1, 7);
    if (this.bMaxShow)
      return;
    NewbieManager.CheckPetInfo();
  }

  public override void OnClose()
  {
    this.HideAddSkillExpPanel();
    this.HideEvoPanel();
    this.GM.RemoverTimeBaarToList(this.TimeBar);
    this.DeSpawnParticle_Up();
    this.DeSpawnParticle_X2();
    this.DeSpawnParticle_Body();
    this.DestroyPet3D();
    this.DestroyEmoji();
    for (int index = 0; index < 3; ++index)
    {
      StringManager.Instance.DeSpawnString(this.SkillNameStr[index]);
      StringManager.Instance.DeSpawnString(this.SkillExpStr[index]);
    }
    StringManager.Instance.DeSpawnString(this.ExpStr);
    StringManager.Instance.DeSpawnString(this.StoneStr);
    StringManager.Instance.DeSpawnString(this.LevelStr_L);
    StringManager.Instance.DeSpawnString(this.LevelStr);
    StringManager.Instance.DeSpawnString(this.RankStr);
    StringManager.Instance.DeSpawnString(this.UpStr);
    StringManager.Instance.DeSpawnString(this.HinString);
    StringManager.Instance.DeSpawnString(this.RareStr);
    if (!this.bMaxShow)
    {
      StringManager.Instance.DeSpawnString(this.ASExp_InfoNowStr);
      StringManager.Instance.DeSpawnString(this.ASExp_InfoNextStr);
      StringManager.Instance.DeSpawnString(this.ASExp_SkillLvStr);
      StringManager.Instance.DeSpawnString(this.ASExp_SkillExpStr);
      StringManager.Instance.DeSpawnString(this.ASExp_HaveCountStr1);
      StringManager.Instance.DeSpawnString(this.ASExp_NeedCountStr1);
      StringManager.Instance.DeSpawnString(this.ASExp_HaveCountStr2);
      StringManager.Instance.DeSpawnString(this.ASExp_NeedCountStr2);
      StringManager.Instance.DeSpawnString(this.ASExp_InfoNowCDStr);
      StringManager.Instance.DeSpawnString(this.ASExp_InfoNextCDStr);
      StringManager.Instance.DeSpawnString(this.ASExp_InfoStr);
      StringManager.Instance.DeSpawnString(this.ASExp_EffExpStr);
      StringManager.Instance.DeSpawnString(this.ASExp_EffX2Str);
    }
    StringManager.Instance.DeSpawnString(this.EVO_UpStr);
    StringManager.Instance.DeSpawnString(this.EVO_NeedStr);
    StringManager.Instance.DeSpawnString(this.EVO_PriceStr);
    StringManager.Instance.DeSpawnString(this.EVO_TimeStr);
    this.door.SetBackGroundPosZ(0.0f);
  }

  public void LoadPet3D()
  {
    this.ActionTime = 0.0f;
    this.ActionTimeRandom = 2f;
    this.btn_PetActionD.ReSetHero();
    CString Name = StringManager.Instance.StaticString1024();
    Name.IntToFormat((long) this.sHero.Modle, 5);
    Name.AppendFormat("Role/hero_{0}");
    if (this.sHero.Modle > (ushort) 0 && AssetManager.GetAssetBundleDownload(Name, AssetPath.Role, AssetType.Hero, this.sHero.Modle))
    {
      this.AB = AssetManager.GetAssetBundle(Name, out this.AssetKey);
      if (!((Object) this.AB != (Object) null))
        return;
      this.AR = this.AB.LoadAsync("m", typeof (GameObject));
      this.bABInitial = false;
    }
    else
      this.AR = (AssetBundleRequest) null;
  }

  public void DestroyPet3D()
  {
    if ((Object) this.PetGO != (Object) null)
    {
      this.PetGO.transform.SetParent(((Transform) this.PetPosRT).parent, false);
      ModelLoader.Instance.Unload((Object) this.PetGO);
      this.PetGO = (GameObject) null;
    }
    if ((Object) this.PetModel != (Object) null)
    {
      Object.Destroy((Object) this.PetModel);
      this.PetModel = (Transform) null;
    }
    if (this.AssetKey != 0)
      AssetManager.UnloadAssetBundle(this.AssetKey, false);
    this.HideEmoji();
  }

  public void HeroActionChang(bool bForceShowEmoji = false)
  {
    if (!this.bABInitial || !((Object) this.PetModel != (Object) null))
      return;
    this.tmpAN = this.PetModel.GetComponent<Animation>();
    this.tmpAN.wrapMode = WrapMode.Loop;
    if (this.PetAct == this.mPetAct[1])
      this.tmpAN.CrossFade("idle");
    if ((Object) this.tmpAN.GetClip(this.mPetAct[2]) != (Object) null)
    {
      this.PetAct = this.mPetAct[2];
      this.tmpAN[this.mPetAct[2]].layer = 1;
      this.tmpAN[this.mPetAct[2]].wrapMode = WrapMode.Once;
    }
    if ((Object) this.tmpAN.GetClip(this.mPetAct[3]) != (Object) null)
    {
      this.PetAct = this.mPetAct[3];
      this.tmpAN[this.mPetAct[3]].layer = 1;
      this.tmpAN[this.mPetAct[3]].wrapMode = WrapMode.Once;
    }
    if ((Object) this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[4]) != (Object) null)
    {
      this.tmpAN[this.mPetAct[4]].layer = 1;
      this.tmpAN[this.mPetAct[4]].wrapMode = WrapMode.Once;
    }
    if ((Object) this.tmpAN.GetClip(this.mPetAct[5]) != (Object) null)
    {
      this.PetAct = this.mPetAct[5];
      this.tmpAN[this.mPetAct[5]].layer = 1;
      this.tmpAN[this.mPetAct[5]].wrapMode = WrapMode.Once;
    }
    if ((Object) this.tmpAN.GetClip(this.mPetAct[6]) != (Object) null)
    {
      this.PetAct = this.mPetAct[6];
      this.tmpAN[this.mPetAct[6]].layer = 1;
      this.tmpAN[this.mPetAct[6]].wrapMode = WrapMode.Once;
    }
    int index = Random.Range(1, (int) this.RandomEnd);
    AnimationClip animationClip = this.tmpAN.GetClip(this.mPetAct[(int) (byte) index]);
    this.PetAct = this.mPetAct[(int) (byte) index];
    if (index == 3 && (Object) this.tmpAN.GetClip(this.PetAct + "_ch") != (Object) null)
      animationClip = (AnimationClip) null;
    if ((Object) animationClip != (Object) null)
    {
      this.tmpAN.CrossFade(animationClip.name);
      this.MovingTimer = 0.0f;
      if (index == 1)
        this.MovingTimer = 2f;
    }
    this.ActionTimeRandom = 0.0f;
    this.ActionTime = 0.0f;
    if (index != 0)
    {
      if (!bForceShowEmoji && Random.Range(1, 100) <= 75)
        return;
      this.ShowEmoji();
    }
    else
      this.HideEmoji();
  }

  private void SpawnParticle_Body()
  {
    this.DeSpawnParticle_Body();
    if ((Object) this.PetGO == (Object) null)
      return;
    Transform skeletalTrans = AnimationUnit.GetSkeletalTrans(this.PetGO, AnimationUnit.HIT_POINT_ROOTBONE);
    if (!((Object) skeletalTrans != (Object) null))
      return;
    float scale;
    ushort EffID;
    if (this.bMaxShow)
    {
      scale = (float) this.sPet.EffectRatio[2] / 1000f;
      EffID = this.ParticleID[2];
    }
    else
    {
      scale = ((int) this.NowPet.Enhance >= this.sPet.EffectRatio.Length ? (float) this.sPet.EffectRatio[0] : (float) this.sPet.EffectRatio[(int) this.NowPet.Enhance]) / 1000f;
      EffID = (int) this.NowPet.Enhance >= this.ParticleID.Length ? this.ParticleID[0] : this.ParticleID[(int) this.NowPet.Enhance];
    }
    this.ParticleObj = ParticleManager.Instance.Spawn(EffID, skeletalTrans, Vector3.zero, scale, true);
    if (!((Object) this.ParticleObj != (Object) null))
      return;
    GUIManager.Instance.SetLayer(this.ParticleObj, 5);
    this.ParticleObj.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    this.ParticleObj.transform.localPosition = Vector3.zero;
    if (!this.CheckHideParticle())
      return;
    this.ParticleObj.gameObject.SetActive(false);
  }

  private void DeSpawnParticle_Body()
  {
    if (!((Object) this.ParticleObj != (Object) null))
      return;
    ParticleManager.Instance.DeSpawn(this.ParticleObj);
    this.ParticleObj = (GameObject) null;
  }

  private void SpawnParticle_Bar()
  {
    this.DeSpawnParticle_Bar();
    this.ParticleObj_Bar = ParticleManager.Instance.Spawn((ushort) 444, this.TimeBarEffectT, Vector3.zero, 0.8f, true);
    if (!((Object) this.ParticleObj_Bar != (Object) null))
      return;
    GUIManager.Instance.SetLayer(this.ParticleObj_Bar, 5);
    this.ParticleObj_Bar.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    this.ParticleObj_Bar.transform.localPosition = Vector3.zero;
  }

  private void DeSpawnParticle_Bar()
  {
    if (!((Object) this.ParticleObj_Bar != (Object) null))
      return;
    ParticleManager.Instance.DeSpawn(this.ParticleObj_Bar);
    this.ParticleObj_Bar = (GameObject) null;
  }

  private bool CheckHideParticle()
  {
    return this.NowEvoID != -1 || this.SelectSkillIndex != -1 || (bool) (Object) this.GM.FindMenu(EGUIWindow.UI_PetStoneTrans);
  }

  private void SetParticle_Show(bool bShow, bool ForceShow = false)
  {
    if (bShow && !ForceShow && this.CheckHideParticle())
      return;
    if ((Object) this.ParticleObj != (Object) null)
      this.ParticleObj.gameObject.SetActive(bShow);
    if (!((Object) this.TimeBarEffectT != (Object) null))
      return;
    this.TimeBarEffectT.gameObject.SetActive(bShow);
  }

  private void SpawnParticle_Up()
  {
    if (this.ShowUpEffectPetID == (ushort) 0)
      return;
    this.ShowUpEffectPetID = (ushort) 0;
    if ((Object) this.PetGO == (Object) null)
      return;
    this.UpParticleGO = ParticleManager.Instance.Spawn((ushort) 440, (Transform) this.PetPosRT, Vector3.zero, 1f, true);
    if (!((Object) this.UpParticleGO != (Object) null))
      return;
    GUIManager.Instance.SetLayer(this.UpParticleGO, 5);
    this.UpParticleGO.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    this.UpParticleGO.transform.localPosition = Vector3.zero;
    AudioManager.Instance.PlayUISFX(UIKind.PetEnhance);
  }

  private void DeSpawnParticle_Up()
  {
    this.ShowUpEffectPetID = (ushort) 0;
    if (!((Object) this.UpParticleGO != (Object) null))
      return;
    if (this.UpParticleGO.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
    {
      this.UpParticleGO.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
      this.UpParticleGO.SetActive(false);
      this.UpParticleGO.SetActive(true);
    }
    this.UpParticleGO = (GameObject) null;
  }

  private void SpawnParticle_X2()
  {
    if ((Object) this.X2ParticleGO != (Object) null)
      return;
    this.X2ParticleGO = ParticleManager.Instance.Spawn((ushort) 445, (Transform) ((Graphic) this.ASExp_ExpBar).rectTransform, Vector3.zero, 1f, true);
    if (!((Object) this.X2ParticleGO != (Object) null))
      return;
    GUIManager.Instance.SetLayer(this.X2ParticleGO, 5);
    this.X2ParticleGO.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
    this.X2ParticleGO.transform.localPosition = Vector3.zero;
  }

  private void DeSpawnParticle_X2()
  {
    if (!((Object) this.X2ParticleGO != (Object) null))
      return;
    if (this.X2ParticleGO.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
    {
      this.X2ParticleGO.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
      this.X2ParticleGO.SetActive(false);
      this.X2ParticleGO.SetActive(true);
    }
    this.X2ParticleGO = (GameObject) null;
  }

  private void ShowEmoji()
  {
    if (!(bool) (Object) this.EmojiRC)
      return;
    if (this.Emoji != null)
    {
      this.GM.pushEmojiIcon(this.Emoji);
      this.Emoji = (EmojiUnit) null;
    }
    EmojiData recordByIndex = DataManager.MapDataController.EmojiDataTable.GetRecordByIndex((int) (ushort) Random.Range(3, DataManager.MapDataController.EmojiDataTable.TableCount));
    float num1 = (int) recordByIndex.sizeX <= (int) recordByIndex.sizeY ? (float) recordByIndex.sizeY : (float) recordByIndex.sizeX;
    float num2 = ((double) num1 != 0.0 ? num1 * 0.9f + (this.GM.EmojiManager != null ? this.GM.EmojiManager.basebackoffset : 25f) : (this.GM.EmojiManager != null ? this.GM.EmojiManager.basebacksize : 73f)) / (this.GM.EmojiManager != null ? this.GM.EmojiManager.basebacksize : 73f);
    if (this.EmojiBack != null)
      this.EmojiBack.EmojiTransform.localScale = Vector3.one * num2;
    this.Emoji = this.GM.pullEmojiIcon(recordByIndex.IconID, recordByIndex.KeyFrame);
    if (this.Emoji != null)
    {
      this.Emoji.EmojiTransform.localPosition = new Vector3(0.0f, 5f, 0.0f);
      this.Emoji.EmojiTransform.localScale = Vector3.one * 0.9f;
      this.Emoji.EmojiTransform.SetParent((Transform) this.EmojiRC, false);
      if (this.bMaxShow || (int) this.NowPet.Enhance == (int) this.PM.GetMaxEnhance())
        this.EmojiRC.anchoredPosition = new Vector2((float) Random.Range(-340, -380), (float) Random.Range(90, 125));
      else if (this.NowPet.Enhance == (byte) 1)
        this.EmojiRC.anchoredPosition = new Vector2((float) Random.Range(-300, -340), (float) Random.Range(55, 90));
      else if (this.NowPet.Enhance == (byte) 0)
        this.EmojiRC.anchoredPosition = new Vector2((float) Random.Range(-260, -300), (float) Random.Range(20, 55));
      this.StartEmojiMove();
    }
    else
      ((Component) this.EmojiRC).gameObject.SetActive(false);
  }

  private void HideEmoji()
  {
    if (!((Object) this.EmojiRC != (Object) null))
      return;
    ((Component) this.EmojiRC).gameObject.SetActive(false);
  }

  private void DestroyEmoji()
  {
    if (this.Emoji != null)
    {
      this.GM.pushEmojiIcon(this.Emoji);
      this.Emoji = (EmojiUnit) null;
    }
    if (this.EmojiBack == null)
      return;
    this.GM.pushEmojiIcon(this.EmojiBack);
    this.EmojiBack = (EmojiUnit) null;
  }

  private void StartEmojiMove()
  {
    if ((Object) this.EmojiRC == (Object) null)
      return;
    this.EmijiShowCountTime = 0.0f;
    ((Transform) this.EmojiRC).localScale = Vector3.zero;
    ((Component) this.EmojiRC).gameObject.SetActive(true);
  }

  private void EndEmojiMove()
  {
    if ((Object) this.EmojiRC == (Object) null)
      return;
    this.EmijiShowCountTime = -1f;
    ((Transform) this.EmojiRC).localScale = Vector3.one;
  }

  private void SetNowPet()
  {
    ushort num = !this.bMaxShow ? (ushort) this.PM.PetUI_PetID : (ushort) this.PM.PetUI_PetMaxShowID;
    this.NowPet = this.PM.FindPetData(num);
    this.sPet = this.PM.PetTable.GetRecordByKey(num);
    this.sHero = this.DM.HeroTable.GetRecordByKey(this.sPet.HeroID);
    if (this.NowPet != null)
      this.NowPet.Remove(PetManager.EPetState.NewPet);
    this.DeSpawnParticle_Up();
    this.DestroyPet3D();
    this.LoadPet3D();
    this.SetBlood();
    this.SetStone();
    this.SetPetInfo();
    this.SetSkill();
  }

  private void SetLight()
  {
    if ((Object) this.myLight1 == (Object) null)
      return;
    if (this.bMaxShow)
    {
      this.myLight1.range = 22.5f;
    }
    else
    {
      if (this.NowPet == null)
        return;
      if (this.NowPet.Enhance == (byte) 0)
        this.myLight1.range = 23.4f;
      if (this.NowPet.Enhance == (byte) 1)
        this.myLight1.range = 22.9f;
      if (this.NowPet.Enhance != (byte) 2)
        return;
      this.myLight1.range = 22.5f;
    }
  }

  private void SetBlood()
  {
    if ((Object) this.PetNameText == (Object) null)
      return;
    this.PetNameText.text = this.DM.mStringTable.GetStringByID((uint) this.sPet.Name);
    if (this.bMaxShow)
    {
      this.LevelStr_L.Length = 0;
      this.LevelStr_L.IntToFormat((long) this.GetMaxLv(this.PM.GetMaxEnhance()));
      this.LevelStr_L.AppendFormat(this.DM.mStringTable.GetStringByID(52U));
      this.ExpStr.Length = 0;
      this.ExpStr.Append(this.DM.mStringTable.GetStringByID(898U));
      this.ExpSP.SetSpriteIndex(1);
      this.BloodBtnT.gameObject.SetActive(false);
    }
    else
    {
      if (this.NowPet == null)
        return;
      this.LevelStr_L.Length = 0;
      this.LevelStr_L.IntToFormat((long) this.NowPet.Level);
      this.LevelStr_L.AppendFormat(this.DM.mStringTable.GetStringByID(52U));
      uint needExp = this.PM.GetNeedExp(this.NowPet.Level, this.sPet.Rare);
      this.BloodBtnT.gameObject.SetActive(true);
      this.ExpSP.SetSpriteIndex(0);
      this.ExpStr.Length = 0;
      if (this.NowPet.CheckState(PetManager.EPetState.Evolution))
      {
        this.ExpStr.Append(this.DM.mStringTable.GetStringByID(376U));
        this.ExpImage.fillAmount = 1f;
        this.BloodSP.SetSpriteIndex(1);
        ((Graphic) this.BloodSP.m_Image).rectTransform.anchoredPosition = new Vector2(-83.5f, 202.5f);
        this.BloodSP.m_Image.SetNativeSize();
      }
      else if (this.CheckMaxLv() && ((int) this.NowPet.Exp == (int) needExp - 1 || (int) this.NowPet.Enhance == (int) this.PM.GetMaxEnhance()))
      {
        if ((int) this.NowPet.Enhance == (int) this.PM.GetMaxEnhance())
        {
          this.ExpStr.Append(this.DM.mStringTable.GetStringByID(898U));
          this.ExpSP.SetSpriteIndex(1);
          this.ExpImage.fillAmount = 1f;
          this.BloodBtnT.gameObject.SetActive(false);
        }
        else
        {
          this.ExpStr.Append(this.DM.mStringTable.GetStringByID(16051U));
          this.ExpImage.fillAmount = 1f;
          this.BloodSP.SetSpriteIndex(1);
          ((Graphic) this.BloodSP.m_Image).rectTransform.anchoredPosition = new Vector2(-83.5f, 202.5f);
          this.BloodSP.m_Image.SetNativeSize();
        }
      }
      else
      {
        this.ExpStr.IntToFormat((long) this.NowPet.Exp, bNumber: true);
        this.ExpStr.IntToFormat((long) needExp, bNumber: true);
        if (this.GM.IsArabic)
          this.ExpStr.AppendFormat("{1} / {0} ");
        else
          this.ExpStr.AppendFormat("{0} / {1} ");
        this.ExpStr.Append(this.DM.mStringTable.GetStringByID(9U));
        this.ExpImage.fillAmount = needExp == 0U ? 0.0f : (float) this.NowPet.Exp / (float) needExp;
        this.BloodSP.SetSpriteIndex(0);
        ((Graphic) this.BloodSP.m_Image).rectTransform.anchoredPosition = new Vector2(-77.5f, 195.5f);
        this.BloodSP.m_Image.SetNativeSize();
      }
    }
    this.LevelText_L.text = this.LevelStr_L.ToString();
    this.LevelText_L.SetAllDirty();
    this.LevelText_L.cachedTextGenerator.Invalidate();
    this.ExpText.text = this.ExpStr.ToString();
    this.ExpText.SetAllDirty();
    this.ExpText.cachedTextGenerator.Invalidate();
  }

  private void SetStone()
  {
    if ((Object) this.StoneT == (Object) null)
      return;
    if (this.bMaxShow)
    {
      this.MaxShowT.gameObject.SetActive(true);
      this.StoneT.gameObject.SetActive(false);
    }
    else
    {
      this.MaxShowT.gameObject.SetActive(false);
      this.StoneT.gameObject.SetActive(true);
      this.GM.ChangeHeroItemImg(this.StoneIcon, eHeroOrItem.Item, this.sPet.SoulID, (byte) 0, (byte) 0);
      this.StoneStr.Length = 0;
      this.StoneStr.StringToFormat(this.DM.mStringTable.GetStringByID(16050U));
      this.StoneStr.IntToFormat((long) this.DM.GetCurItemQuantity(this.sPet.SoulID, (byte) 0), bNumber: true);
      this.StoneStr.AppendFormat("{0}：{1}");
      this.StoneText.text = this.StoneStr.ToString();
      this.StoneText.SetAllDirty();
      this.StoneText.cachedTextGenerator.Invalidate();
    }
  }

  private void SetPetInfo()
  {
    if ((Object) this.LevelText == (Object) null)
      return;
    if (this.bMaxShow)
    {
      this.GM.ChangeHeroItemImg(this.PetIcon, eHeroOrItem.Pet, this.sPet.ID, this.PM.GetMaxEnhance(), (byte) 0);
      this.RareStr.Length = 0;
      StringManager.IntToStr(this.RareStr, (long) this.sPet.Rare);
      this.LevelStr.Length = 0;
      this.LevelStr.IntToFormat((long) this.GetMaxLv(this.PM.GetMaxEnhance()));
      this.LevelStr.AppendFormat(this.DM.mStringTable.GetStringByID(16049U));
      this.RankStr.Length = 0;
      this.RankStr.StringToFormat(this.DM.mStringTable.GetStringByID(16068U));
      this.RankStr.AppendFormat(this.DM.mStringTable.GetStringByID(16048U));
      this.UpStr.Length = 0;
      this.UpStr.Append(this.DM.mStringTable.GetStringByID(21U));
      ((Graphic) this.UpText).color = this.MaxTextColor;
      this.RankT.gameObject.SetActive(false);
      this.PanelRLightT.gameObject.SetActive(true);
      this.PanelBlockT.gameObject.SetActive(true);
      this.RandomEnd = (byte) 7;
    }
    else
    {
      if (this.NowPet == null)
        return;
      this.GM.ChangeHeroItemImg(this.PetIcon, eHeroOrItem.Pet, this.sPet.ID, this.NowPet.Enhance, (byte) 0);
      this.RareStr.Length = 0;
      StringManager.IntToStr(this.RareStr, (long) this.sPet.Rare);
      this.LevelStr.Length = 0;
      this.LevelStr.IntToFormat((long) this.GetMaxLv(this.NowPet.Enhance));
      this.LevelStr.AppendFormat(this.DM.mStringTable.GetStringByID(16049U));
      this.RankStr.Length = 0;
      this.RankStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.NowPet.Enhance + 16066U));
      this.RankStr.AppendFormat(this.DM.mStringTable.GetStringByID(16048U));
      this.UpStr.Length = 0;
      if (this.NowPet.Enhance == (byte) 2)
      {
        this.UpStr.Append(this.DM.mStringTable.GetStringByID(21U));
        ((Graphic) this.UpText).color = this.MaxTextColor;
        this.PanelRLightT.gameObject.SetActive(true);
        this.PanelBlockT.gameObject.SetActive(true);
      }
      else
      {
        this.UpStr.IntToFormat((long) this.DM.GetCurItemQuantity(this.sPet.SoulID, (byte) 0), bNumber: true);
        this.UpStr.IntToFormat((long) this.PM.GetEvoNeed_Stone(this.NowPet.Enhance, this.sPet.Rare), bNumber: true);
        if (this.GM.IsArabic)
          this.UpStr.AppendFormat("{1} / {0}");
        else
          this.UpStr.AppendFormat("{0} / {1}");
        ((Graphic) this.UpText).color = Color.white;
        this.PanelRLightT.gameObject.SetActive(false);
        this.PanelBlockT.gameObject.SetActive(false);
      }
      if (this.NowPet.Enhance == (byte) 2)
      {
        this.RankT.gameObject.SetActive(false);
      }
      else
      {
        this.RankT.gameObject.SetActive(true);
        this.RankT.GetChild(1).gameObject.SetActive(false);
        this.RankT.GetChild(2).gameObject.SetActive(false);
        if (this.CheckEvoItem() && (int) this.PM.PetUI_EvoID != (int) this.NowPet.ID)
        {
          if (this.CheckMaxLv())
            this.RankT.GetChild(1).gameObject.SetActive(true);
          else
            this.RankT.GetChild(2).gameObject.SetActive(true);
        }
      }
      if (this.NowPet.CheckState(PetManager.EPetState.Training))
        this.PetStateImage.gameObject.SetActive(true);
      else
        this.PetStateImage.gameObject.SetActive(false);
      if ((int) this.PM.PetUI_EvoID == (int) this.NowPet.ID)
      {
        int index = 35;
        long notifyTime = 0;
        long startTime = this.DM.queueBarData[index].StartTime;
        long target = startTime + (long) this.DM.queueBarData[index].TotalTime;
        eTimerSpriteType queueBarSpriteType = this.DM.GetQueueBarSpriteType(EQueueBarIndex.PetEvolution);
        if (queueBarSpriteType != eTimerSpriteType.Free)
          notifyTime = target - (long) this.DM.FreeCompletePeriod;
        this.GM.SetTimerBar(this.TimeBar, startTime, target, notifyTime, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(376U), this.DM.mStringTable.GetStringByID((uint) this.sPet.Name));
        this.GM.SetTimerSpriteType(this.TimeBar, queueBarSpriteType);
        this.TimeBar.gameObject.SetActive(true);
        this.TimeBarBackT.gameObject.SetActive(true);
        this.HideEvoPanel();
        this.SpawnParticle_Bar();
      }
      else
      {
        this.TimeBar.gameObject.SetActive(false);
        this.TimeBarBackT.gameObject.SetActive(false);
        this.DeSpawnParticle_Bar();
      }
      this.RandomEnd = (byte) 7;
    }
    this.RareText.text = this.RareStr.ToString();
    this.RareText.SetAllDirty();
    this.RareText.cachedTextGenerator.Invalidate();
    this.LevelText.text = this.LevelStr.ToString();
    this.LevelText.SetAllDirty();
    this.LevelText.cachedTextGenerator.Invalidate();
    this.RankText.text = this.RankStr.ToString();
    this.RankText.SetAllDirty();
    this.RankText.cachedTextGenerator.Invalidate();
    this.UpText.text = this.UpStr.ToString();
    this.UpText.SetAllDirty();
    this.UpText.cachedTextGenerator.Invalidate();
  }

  private void SetSkill()
  {
    if ((Object) this.SkillT[0] == (Object) null)
      return;
    for (int index = 0; index < 3; ++index)
      this.SkillT[index].gameObject.SetActive(false);
    byte index1 = 0;
    for (int index2 = 0; index2 < 3; ++index2)
    {
      if (this.sPet.PetSkill[index2] != (ushort) 0)
      {
        PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[index2]);
        this.SkillNameStr[(int) index1].Length = 0;
        if (this.bMaxShow)
        {
          this.SkillNameStr[(int) index1].IntToFormat((long) recordByKey.UpLevel);
          ((Graphic) this.SkillNameText[(int) index1]).color = this.MaxTextColor;
        }
        else
        {
          this.SkillNameStr[(int) index1].IntToFormat((long) this.NowPet.SkillLv[index2]);
          if ((int) this.NowPet.SkillLv[index2] >= (int) recordByKey.UpLevel)
            ((Graphic) this.SkillNameText[(int) index1]).color = this.MaxTextColor;
          else
            ((Graphic) this.SkillNameText[(int) index1]).color = Color.white;
        }
        this.SkillNameStr[(int) index1].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey.Name));
        this.SkillNameStr[(int) index1].AppendFormat(this.DM.mStringTable.GetStringByID(268U));
        this.SkillNameText[(int) index1].text = this.SkillNameStr[(int) index1].ToString();
        this.SkillNameText[(int) index1].SetAllDirty();
        this.SkillNameText[(int) index1].cachedTextGenerator.Invalidate();
        CString SpriteName = StringManager.Instance.StaticString1024();
        SpriteName.Append('s');
        SpriteName.IntToFormat((long) recordByKey.Icon, 5);
        SpriteName.AppendFormat("{0}");
        this.SkillImage1[(int) index1].sprite = this.GM.LoadSkillSprite(SpriteName);
        ((MaskableGraphic) this.SkillImage1[(int) index1]).material = this.GM.GetSkillMaterial();
        this.SkillPicHint[(int) index1].Parm1 = (ushort) index2;
        if (!this.bMaxShow && (int) this.NowPet.Enhance < index2)
        {
          this.SkillLockGO[(int) index1].gameObject.SetActive(true);
          this.SkillExpImageT[(int) index1].gameObject.SetActive(false);
          ((Component) this.SkillExpText[(int) index1]).gameObject.SetActive(false);
          this.SkillBtnT[(int) index1].gameObject.SetActive(false);
          this.SkillLockText[(int) index1].text = this.DM.mStringTable.GetStringByID((uint) (16060 + index2));
        }
        else
        {
          this.SkillLockGO[(int) index1].gameObject.SetActive(false);
          this.SkillExpImageT[(int) index1].gameObject.SetActive(true);
          ((Component) this.SkillExpText[(int) index1]).gameObject.SetActive(true);
          if (this.bMaxShow)
          {
            this.SkillBtnT[(int) index1].gameObject.SetActive(false);
            this.SkillExpStr[(int) index1].Length = 0;
            this.SkillExpStr[(int) index1].Append(this.DM.mStringTable.GetStringByID(898U));
            this.SkillExpImage[(int) index1].fillAmount = 1f;
            this.SkillExpImageSP[(int) index1].SetSpriteIndex(1);
          }
          else
          {
            this.SkillExpStr[(int) index1].Length = 0;
            if ((int) this.NowPet.SkillLv[index2] >= (int) recordByKey.UpLevel)
            {
              this.SkillBtnT[(int) index1].gameObject.SetActive(false);
              this.SkillExpStr[(int) index1].Append(this.DM.mStringTable.GetStringByID(898U));
              this.SkillExpImage[(int) index1].fillAmount = 1f;
              this.SkillExpImageSP[(int) index1].SetSpriteIndex(1);
            }
            else
            {
              this.SkillBtnT[(int) index1].gameObject.SetActive(true);
              this.SkillBtn[(int) index1].m_BtnID3 = index2;
              uint needSkillExp = this.GetNeedSkillExp(recordByKey.Experience, this.NowPet.SkillLv[index2]);
              this.SkillExpStr[(int) index1].IntToFormat((long) this.NowPet.SkillExp[index2], bNumber: true);
              this.SkillExpStr[(int) index1].IntToFormat((long) needSkillExp, bNumber: true);
              if (this.GM.IsArabic)
                this.SkillExpStr[(int) index1].AppendFormat("{1} / {0} ");
              else
                this.SkillExpStr[(int) index1].AppendFormat("{0} / {1} ");
              this.SkillExpStr[(int) index1].Append(this.DM.mStringTable.GetStringByID(9U));
              double num = needSkillExp == 0U ? 0.0 : (double) this.NowPet.SkillExp[index2] / (double) needSkillExp;
              this.SkillExpImage[(int) index1].fillAmount = (float) num;
              this.SkillExpImageSP[(int) index1].SetSpriteIndex(0);
              if ((this.NowPet.SkillLv[index2] <= (byte) 0 || (int) this.NowPet.SkillLv[index2] > recordByKey.OpenLevel.Length || (int) this.NowPet.Level >= (int) recordByKey.OpenLevel[(int) this.NowPet.SkillLv[index2] - 1] || (int) this.NowPet.SkillExp[index2] != (int) needSkillExp - 1) && (int) this.DM.GetCurItemQuantity(this.sPet.SoulID, (byte) 0) >= (int) this.PM.PetUI_UpNeedStoneCount)
                this.SkillBtnAlertT[(int) index1].gameObject.SetActive(true);
              else
                this.SkillBtnAlertT[(int) index1].gameObject.SetActive(false);
            }
          }
          this.SkillExpText[(int) index1].text = this.SkillExpStr[(int) index1].ToString();
          this.SkillExpText[(int) index1].SetAllDirty();
          this.SkillExpText[(int) index1].cachedTextGenerator.Invalidate();
        }
        if (recordByKey.Type == (byte) 1)
        {
          ((Behaviour) this.SkillkindImage[(int) index1]).enabled = true;
          this.SkillkindSP[(int) index1].SetSpriteIndex(recordByKey.Subject != (byte) 1 ? 0 : 1);
          this.SkillKindHint[(int) index1].Parm1 = recordByKey.Subject != (byte) 1 ? (ushort) 16064 : (ushort) 16063;
        }
        else
          ((Behaviour) this.SkillkindImage[(int) index1]).enabled = false;
        this.SkillT[(int) index1].gameObject.SetActive(true);
        ++index1;
      }
    }
  }

  private void SetAddSkill_Item()
  {
    if (this.NowPet == null || this.SelectSkillIndex < 0 || this.SelectSkillIndex >= 4)
      return;
    DataManager.Instance.EquipTable.GetRecordByKey(this.sPet.SoulID);
    this.GM.ChangeHeroItemImg(this.ASExp_StoneIconT1, eHeroOrItem.Item, this.sPet.SoulID, (byte) 0, (byte) 0);
    this.GM.ChangeHeroItemImg(this.ASExp_StoneIconT2, eHeroOrItem.Item, this.ASExp_ExpItemID, (byte) 0, (byte) 0);
    this.ASExp_HaveCountStr1.Length = 0;
    this.ASExp_HaveCountStr1.IntToFormat((long) this.DM.GetCurItemQuantity(this.sPet.SoulID, (byte) 0), bNumber: true);
    this.ASExp_HaveCountStr1.AppendFormat(this.DM.mStringTable.GetStringByID(79U));
    this.ASExp_HaveCountText1.text = this.ASExp_HaveCountStr1.ToString();
    this.ASExp_HaveCountText1.SetAllDirty();
    this.ASExp_HaveCountText1.cachedTextGenerator.Invalidate();
    this.ASExp_HaveCountStr2.Length = 0;
    this.ASExp_HaveCountStr2.IntToFormat((long) this.DM.GetCurItemQuantity(this.ASExp_ExpItemID, (byte) 0), bNumber: true);
    this.ASExp_HaveCountStr2.AppendFormat(this.DM.mStringTable.GetStringByID(79U));
    this.ASExp_HaveCountText2.text = this.ASExp_HaveCountStr2.ToString();
    this.ASExp_HaveCountText2.SetAllDirty();
    this.ASExp_HaveCountText2.cachedTextGenerator.Invalidate();
    this.ASExp_NeedCountStr1.Length = 0;
    this.ASExp_NeedCountStr1.IntToFormat((long) this.PM.PetUI_UpNeedStoneCount, bNumber: true);
    this.ASExp_NeedCountStr1.AppendFormat(this.DM.mStringTable.GetStringByID(15005U));
    this.ASExp_NeedCountText1.text = this.ASExp_NeedCountStr1.ToString();
    this.ASExp_NeedCountText1.SetAllDirty();
    this.ASExp_NeedCountText1.cachedTextGenerator.Invalidate();
    this.ASExp_NeedCountStr2.Length = 0;
    if (this.sPet.Rare >= (byte) 1 && (int) this.sPet.Rare <= this.PM.PetUI_UpNeedSoulCount.Length)
      this.ASExp_NeedCountStr2.IntToFormat((long) this.PM.PetUI_UpNeedSoulCount[(int) this.sPet.Rare - 1], bNumber: true);
    else
      this.ASExp_NeedCountStr2.IntToFormat(0L, bNumber: true);
    this.ASExp_NeedCountStr2.AppendFormat(this.DM.mStringTable.GetStringByID(15005U));
    this.ASExp_NeedCountText2.text = this.ASExp_NeedCountStr2.ToString();
    this.ASExp_NeedCountText2.SetAllDirty();
    this.ASExp_NeedCountText2.cachedTextGenerator.Invalidate();
  }

  private void SetAddSkill_Info()
  {
    if (this.NowPet == null || this.SelectSkillIndex < 0 || this.SelectSkillIndex >= 4)
      return;
    PetSkillTbl recordByKey1 = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[this.SelectSkillIndex]);
    byte index = this.NowPet.SkillLv[this.SelectSkillIndex];
    CString SpriteName = StringManager.Instance.StaticString1024();
    SpriteName.Append('s');
    SpriteName.IntToFormat((long) recordByKey1.Icon, 5);
    SpriteName.AppendFormat("{0}");
    this.ASExp_SkillImage1.sprite = this.GM.LoadSkillSprite(SpriteName);
    ((MaskableGraphic) this.ASExp_SkillImage1).material = this.GM.GetSkillMaterial();
    this.ASExp_SkillNameText.text = this.DM.mStringTable.GetStringByID((uint) recordByKey1.Name);
    bool flag1 = (int) index >= (int) recordByKey1.UpLevel;
    this.ASExp_SkillLvStr.Length = 0;
    this.ASExp_SkillLvStr.IntToFormat((long) index);
    this.ASExp_SkillLvStr.AppendFormat(this.DM.mStringTable.GetStringByID(52U));
    this.ASExp_SkillLvText.text = this.ASExp_SkillLvStr.ToString();
    this.ASExp_SkillLvText.SetAllDirty();
    this.ASExp_SkillLvText.cachedTextGenerator.Invalidate();
    uint needSkillExp = this.GetNeedSkillExp(recordByKey1.Experience, index);
    this.ASExp_SkillExpStr.Length = 0;
    if (flag1)
    {
      this.ASExp_SkillExpStr.Append(this.DM.mStringTable.GetStringByID(898U));
      this.ASExp_ExpBarImage.fillAmount = 1f;
      this.ASExp_ExpSP.SetSpriteIndex(1);
    }
    else
    {
      this.ASExp_SkillExpStr.IntToFormat((long) this.NowPet.SkillExp[this.SelectSkillIndex], bNumber: true);
      this.ASExp_SkillExpStr.IntToFormat((long) needSkillExp, bNumber: true);
      if (this.GM.IsArabic)
        this.ASExp_SkillExpStr.AppendFormat("{1} / {0} ");
      else
        this.ASExp_SkillExpStr.AppendFormat("{0} / {1} ");
      this.ASExp_SkillExpStr.Append(this.DM.mStringTable.GetStringByID(9U));
      this.ASExp_ExpBarImage.fillAmount = needSkillExp == 0U ? 0.0f : (float) this.NowPet.SkillExp[this.SelectSkillIndex] / (float) needSkillExp;
      this.ASExp_ExpSP.SetSpriteIndex(0);
    }
    this.ASExp_SkillExpText.text = this.ASExp_SkillExpStr.ToString();
    this.ASExp_SkillExpText.SetAllDirty();
    this.ASExp_SkillExpText.cachedTextGenerator.Invalidate();
    bool flag2 = index > (byte) 0 && (int) index <= recordByKey1.OpenLevel.Length && (int) this.NowPet.Level < (int) recordByKey1.OpenLevel[(int) index - 1];
    if (!flag1 && flag2)
    {
      this.ASExp_SkillLockT.gameObject.SetActive(true);
      if ((int) this.NowPet.SkillExp[this.SelectSkillIndex] == (int) needSkillExp - 1)
        this.ASExp_LockSP.SetSpriteIndex(0);
      else
        this.ASExp_LockSP.SetSpriteIndex(1);
    }
    else
      this.ASExp_SkillLockT.gameObject.SetActive(false);
    this.ASExp_InfoNowStr.Length = 0;
    this.PM.FormatSkillContent(recordByKey1.ID, index, this.ASExp_InfoNowStr, (byte) 0);
    this.ASExp_InfoNowtext.text = this.ASExp_InfoNowStr.ToString();
    this.ASExp_InfoNowtext.SetAllDirty();
    this.ASExp_InfoNowtext.cachedTextGenerator.Invalidate();
    if (recordByKey1.CoolDown == (ushort) 0)
    {
      ((Component) this.ASExp_InfoNowCDImage).gameObject.SetActive(false);
      ((Component) this.ASExp_InfoNowCDtext).gameObject.SetActive(false);
    }
    else
    {
      this.ASExp_InfoNowCDStr.Length = 0;
      PetSkillCoolTbl recordByKey2 = this.PM.PetSkillCoolTable.GetRecordByKey(recordByKey1.CoolDown);
      if (index >= (byte) 0 && (int) index <= recordByKey2.CoolBySkillLv.Length)
        this.PM.FormatCoolTime(recordByKey2.CoolBySkillLv[(int) index - 1], this.ASExp_InfoNowCDStr, (byte) 0);
      this.ASExp_InfoNowCDtext.text = this.ASExp_InfoNowCDStr.ToString();
      this.ASExp_InfoNowCDtext.SetAllDirty();
      this.ASExp_InfoNowCDtext.cachedTextGenerator.Invalidate();
      ((Component) this.ASExp_InfoNowCDImage).gameObject.SetActive(true);
      ((Component) this.ASExp_InfoNowCDtext).gameObject.SetActive(true);
    }
    if (flag1)
    {
      this.ASExp_MaxImageT.gameObject.SetActive(true);
      ((Component) this.ASExp_InfoNextTitleText).gameObject.SetActive(false);
      ((Component) this.ASExp_InfoNextText).gameObject.SetActive(false);
      ((Component) this.ASExp_InfoNextCDImage).gameObject.SetActive(false);
      ((Component) this.ASExp_InfoNextCDText).gameObject.SetActive(false);
      this.ASExp_AddBtnT1.gameObject.SetActive(false);
      this.ASExp_AddBtnT2.gameObject.SetActive(false);
      this.ASExp_SrcHint.gameObject.SetActive(false);
      this.ASExp_StoneIconT1.gameObject.SetActive(false);
      this.ASExp_StoneIconT2.gameObject.SetActive(false);
      ((Component) this.ASExp_HaveCountText1).gameObject.SetActive(false);
      ((Component) this.ASExp_HaveCountText2).gameObject.SetActive(false);
      this.ASExp_SelectTextBackT.gameObject.SetActive(false);
      ((Component) this.ASExp_SelectText).gameObject.SetActive(false);
    }
    else
    {
      this.ASExp_InfoNextStr.Length = 0;
      this.PM.FormatSkillContent(recordByKey1.ID, (byte) ((uint) index + 1U), this.ASExp_InfoNextStr, (byte) 0);
      this.ASExp_InfoNextText.text = this.ASExp_InfoNextStr.ToString();
      this.ASExp_InfoNextText.SetAllDirty();
      this.ASExp_InfoNextText.cachedTextGenerator.Invalidate();
      if (recordByKey1.CoolDown == (ushort) 0)
      {
        ((Component) this.ASExp_InfoNextCDImage).gameObject.SetActive(false);
        ((Component) this.ASExp_InfoNextCDText).gameObject.SetActive(false);
      }
      else
      {
        this.ASExp_InfoNextCDStr.Length = 0;
        PetSkillCoolTbl recordByKey3 = this.PM.PetSkillCoolTable.GetRecordByKey(recordByKey1.CoolDown);
        if (index > (byte) 0 && (int) index < recordByKey3.CoolBySkillLv.Length)
          this.PM.FormatCoolTime(recordByKey3.CoolBySkillLv[(int) index], this.ASExp_InfoNextCDStr, (byte) 0);
        this.ASExp_InfoNextCDText.text = this.ASExp_InfoNextCDStr.ToString();
        this.ASExp_InfoNextCDText.SetAllDirty();
        this.ASExp_InfoNextCDText.cachedTextGenerator.Invalidate();
        ((Component) this.ASExp_InfoNextCDImage).gameObject.SetActive(true);
        ((Component) this.ASExp_InfoNextCDText).gameObject.SetActive(true);
      }
      this.ASExp_MaxImageT.gameObject.SetActive(false);
      ((Component) this.ASExp_InfoNextTitleText).gameObject.SetActive(true);
      ((Component) this.ASExp_InfoNextText).gameObject.SetActive(true);
      this.ASExp_AddBtnT1.gameObject.SetActive(true);
      this.ASExp_AddBtnT2.gameObject.SetActive(true);
      this.ASExp_SrcHint.gameObject.SetActive(true);
      this.ASExp_StoneIconT1.gameObject.SetActive(true);
      this.ASExp_StoneIconT2.gameObject.SetActive(true);
      ((Component) this.ASExp_HaveCountText1).gameObject.SetActive(true);
      ((Component) this.ASExp_HaveCountText2).gameObject.SetActive(true);
      this.ASExp_SelectTextBackT.gameObject.SetActive(true);
      ((Component) this.ASExp_SelectText).gameObject.SetActive(true);
    }
  }

  private void CheckAddBtnState()
  {
    if (this.NowPet == null || this.SelectSkillIndex < 0 || this.SelectSkillIndex >= 4)
      return;
    PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[this.SelectSkillIndex]);
    uint needSkillExp = this.GetNeedSkillExp(recordByKey.Experience, this.NowPet.SkillLv[this.SelectSkillIndex]);
    this.bCount1 = this.PM.PetUI_UpNeedStoneCount != (ushort) 0 && (int) this.DM.GetCurItemQuantity(this.sPet.SoulID, (byte) 0) < (int) this.PM.PetUI_UpNeedStoneCount;
    this.bCount2 = this.sPet.Rare >= (byte) 1 && (int) this.sPet.Rare <= this.PM.PetUI_UpNeedSoulCount.Length && this.PM.PetUI_UpNeedSoulCount[(int) this.sPet.Rare - 1] != (ushort) 0 && (int) this.DM.GetCurItemQuantity(this.ASExp_ExpItemID, (byte) 0) < (int) this.PM.PetUI_UpNeedSoulCount[(int) this.sPet.Rare - 1];
    this.bLevel = this.NowPet.SkillLv[this.SelectSkillIndex] > (byte) 0 && (int) this.NowPet.SkillLv[this.SelectSkillIndex] <= recordByKey.OpenLevel.Length && (int) this.NowPet.Level < (int) recordByKey.OpenLevel[(int) this.NowPet.SkillLv[this.SelectSkillIndex] - 1] && (int) this.NowPet.SkillExp[this.SelectSkillIndex] == (int) needSkillExp - 1;
    if (this.bLevel)
    {
      this.ASExp_AddBtn1.ForTextChange(e_BtnType.e_ChangeText);
      this.ASExp_AddBtn2.ForTextChange(e_BtnType.e_ChangeText);
    }
    else
    {
      this.ASExp_AddBtn1.ForTextChange(e_BtnType.e_Normal);
      this.ASExp_AddBtn2.ForTextChange(e_BtnType.e_Normal);
    }
    if (this.bCount1 || this.bLevel)
      ((Graphic) this.ASExp_UpText1).color = Color.red;
    else
      ((Graphic) this.ASExp_UpText1).color = Color.white;
    if (this.bCount2 || this.bLevel)
      ((Graphic) this.ASExp_UpText2).color = Color.red;
    else
      ((Graphic) this.ASExp_UpText2).color = Color.white;
    if (this.bCount1)
      ((Graphic) this.ASExp_NeedCountText1).color = Color.red;
    else
      ((Graphic) this.ASExp_NeedCountText1).color = Color.white;
    if (this.bCount2)
      ((Graphic) this.ASExp_NeedCountText2).color = Color.red;
    else
      ((Graphic) this.ASExp_NeedCountText2).color = Color.white;
  }

  private void ShowAddSkillExpPanel(int SkillIndex)
  {
    if ((Object) this.ASExp_PanelT == (Object) null)
      return;
    this.SelectSkillIndex = SkillIndex;
    this.SetAddSkill_Info();
    this.SetAddSkill_Item();
    this.CheckAddBtnState();
    this.ASExp_PanelT.SetParent((Transform) this.GM.m_SecWindowLayer);
    this.ASExp_PanelT.gameObject.SetActive(true);
    this.SetParticle_Show(false);
  }

  private void HideAddSkillExpPanel()
  {
    if ((Object) this.ASExp_PanelT == (Object) null || this.SelectSkillIndex == -1)
      return;
    this.EndEffect();
    this.ASExp_AddBtn1Click.SetActive(false);
    this.ASExp_AddBtn2Click.SetActive(false);
    this.SelectSkillIndex = -1;
    this.ASExp_PanelT.gameObject.SetActive(false);
    this.ASExp_PanelT.SetParent(this.m_transform);
    this.SetParticle_Show(true);
  }

  private void SetEvoPanel()
  {
    if ((Object) this.EVO_panelT == (Object) null || this.NowPet == null)
      return;
    this.GM.ChangeHeroItemImg(this.EVO_StoneIconT, eHeroOrItem.Item, this.sPet.SoulID, (byte) 0, (byte) 0);
    bool flag = true;
    this.EVO_UpStr.Length = 0;
    this.EVO_UpStr.IntToFormat((long) this.DM.GetCurItemQuantity(this.sPet.SoulID, (byte) 0), bNumber: true);
    this.EVO_UpStr.IntToFormat((long) this.PM.GetEvoNeed_Stone(this.NowPet.Enhance, this.sPet.Rare), bNumber: true);
    if (this.GM.IsArabic)
      this.EVO_UpStr.AppendFormat("{1} / {0}");
    else
      this.EVO_UpStr.AppendFormat("{0} / {1}");
    this.EVO_UpText.text = this.EVO_UpStr.ToString();
    this.EVO_UpText.SetAllDirty();
    this.EVO_UpText.cachedTextGenerator.Invalidate();
    if (this.CheckEvoItem())
    {
      ((Graphic) this.EVO_UpText).color = Color.white;
    }
    else
    {
      ((Graphic) this.EVO_UpText).color = (Color) new Color32(byte.MaxValue, (byte) 115, (byte) 131, byte.MaxValue);
      flag = false;
    }
    this.EVO_NeedStr.Length = 0;
    this.EVO_NeedStr.IntToFormat((long) this.PM.GetEvoNeed_Lv(this.NowPet.Enhance));
    this.EVO_NeedStr.AppendFormat(this.DM.mStringTable.GetStringByID(16055U));
    this.EVO_NeedLvText.text = this.EVO_NeedStr.ToString();
    this.EVO_NeedLvText.SetAllDirty();
    this.EVO_NeedLvText.cachedTextGenerator.Invalidate();
    if (this.CheckEvoLv())
    {
      ((Graphic) this.EVO_NeedLvText).color = Color.white;
    }
    else
    {
      ((Graphic) this.EVO_NeedLvText).color = (Color) new Color32(byte.MaxValue, (byte) 94, (byte) 112, byte.MaxValue);
      flag = false;
    }
    this.EVO_PriceStr.Length = 0;
    this.EVO_PriceStr.IntToFormat((long) this.DM.GetResourceExchange(PriceListType.Time, this.PM.GetEvoNeed_Time(this.NowPet.Enhance)), bNumber: true);
    this.EVO_PriceStr.AppendFormat("{0}");
    this.EVO_LPriceText.text = this.EVO_PriceStr.ToString();
    this.EVO_LPriceText.SetAllDirty();
    this.EVO_LPriceText.cachedTextGenerator.Invalidate();
    this.EVO_TimeStr.Length = 0;
    GameConstants.GetTimeString(this.EVO_TimeStr, this.PM.GetEvoNeed_Time(this.NowPet.Enhance));
    this.EVO_RTimeText.text = this.EVO_TimeStr.ToString();
    this.EVO_RTimeText.SetAllDirty();
    this.EVO_RTimeText.cachedTextGenerator.Invalidate();
    if (flag)
    {
      ((Graphic) this.EVO_LBtnText).color = Color.white;
      ((Graphic) this.EVO_RBtnText).color = Color.white;
    }
    else
    {
      ((Graphic) this.EVO_LBtnText).color = Color.red;
      ((Graphic) this.EVO_RBtnText).color = Color.red;
    }
  }

  private void ShowEvoPanel()
  {
    if (this.NowPet == null || (Object) this.EVO_panelT == (Object) null)
      return;
    this.NowEvoID = (int) this.NowPet.ID;
    this.SetEvoPanel();
    this.EVO_panelT.SetParent((Transform) this.GM.m_SecWindowLayer);
    this.EVO_panelT.gameObject.SetActive(true);
    this.SetParticle_Show(false);
  }

  private void HideEvoPanel()
  {
    if ((Object) this.EVO_panelT == (Object) null || this.NowEvoID == -1)
      return;
    this.NowEvoID = -1;
    this.EVO_panelT.gameObject.SetActive(false);
    this.EVO_panelT.SetParent(this.m_transform);
    this.SetParticle_Show(true);
  }

  private uint GetNeedSkillExp(ushort Experience, byte Lv)
  {
    PetSkillExpTbl recordByKey = this.PM.PetSkillExpTable.GetRecordByKey(Experience);
    return Lv >= (byte) 1 && (int) Lv <= recordByKey.ExpValue.Length ? recordByKey.ExpValue[(int) Lv - 1] : 0U;
  }

  private byte GetMaxLv(byte Enhance)
  {
    if (Enhance == (byte) 0)
      return 20;
    return Enhance == (byte) 1 ? (byte) 50 : (byte) 60;
  }

  private bool CheckMaxLv()
  {
    return this.NowPet != null && (int) this.NowPet.Level == (int) this.GetMaxLv(this.NowPet.Enhance);
  }

  private bool CheckEvoItem()
  {
    if (this.NowPet != null)
    {
      ushort curItemQuantity = this.DM.GetCurItemQuantity(this.sPet.SoulID, (byte) 0);
      ushort evoNeedStone = this.PM.GetEvoNeed_Stone(this.NowPet.Enhance, this.sPet.Rare);
      if (evoNeedStone != (ushort) 0 && (int) curItemQuantity >= (int) evoNeedStone)
        return true;
    }
    return false;
  }

  private bool CheckEvoLv()
  {
    return this.NowPet != null && this.PM.GetEvoNeed_Lv(this.NowPet.Enhance) != (byte) 0 && (int) this.NowPet.Level >= (int) this.PM.GetEvoNeed_Lv(this.NowPet.Enhance);
  }

  private void CheckShowLRBtn()
  {
    if ((Object) this.Left_T == (Object) null || (Object) this.Right_T == (Object) null)
      return;
    if (this.bMaxShow || this.PM.PetDataCount <= (ushort) 1)
    {
      this.Left_T.gameObject.SetActive(false);
      this.Right_T.gameObject.SetActive(false);
    }
    else
    {
      this.Left_T.gameObject.SetActive(true);
      this.Right_T.gameObject.SetActive(true);
    }
  }

  private void SetEffect(eUIPet_Eff EffectKind)
  {
    if (this.NowPet == null || this.SelectSkillIndex < 0 || this.SelectSkillIndex >= 4 || this.ASExp_EffectKind == EffectKind)
      return;
    this.ASExp_EffectKind = EffectKind;
    PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[this.SelectSkillIndex]);
    if (this.ASExp_EffectKind == eUIPet_Eff.eEff_ExpAdd)
    {
      this.ASExp_EffDTime = 0.0f;
      this.ASExp_EffTatalTime = 1.06f;
      ((Component) this.ASExp_EffIconBlockImage).gameObject.SetActive(true);
      ((Component) this.ASExp_EffIconMoveImage).gameObject.SetActive(true);
      ((Component) this.ASExp_EffBarBlockImage).gameObject.SetActive(true);
      if (this.ASExp_EffbLVUp)
        ((Component) this.ASExp_EffBarInnerImage).gameObject.SetActive(true);
      ((Component) this.ASExp_EffExpBackImage).gameObject.SetActive(true);
      ((Graphic) this.ASExp_EffExpBackImage).rectTransform.sizeDelta = new Vector2(335f, 100f);
      ((Graphic) this.ASExp_EffExpBackImage).rectTransform.anchoredPosition = new Vector2(6.5f, -20f);
      this.ASExp_EffExpStr.Length = 0;
      this.ASExp_EffExpStr.IntToFormat((long) this.PM.PetUI_GetExp, bNumber: true);
      if (this.GM.IsArabic)
        this.ASExp_EffExpStr.AppendFormat("Exp {0}+");
      else
        this.ASExp_EffExpStr.AppendFormat("Exp+{0}");
      this.ASExp_EffExpText.text = this.ASExp_EffExpStr.ToString();
      ((Component) this.ASExp_EffExpText).gameObject.SetActive(true);
      if (this.ASExp_EffbLVUp)
      {
        this.ImageFAFrom = this.ASExp_ExpBarImage.fillAmount;
        this.ImageFATo = 1f;
        this.ImageExpNeed = this.GetNeedSkillExp(recordByKey.Experience, this.PM.PetUI_OldLV);
      }
      else
      {
        this.ImageFAFrom = this.ASExp_ExpBarImage.fillAmount;
        this.ImageExpNeed = this.GetNeedSkillExp(recordByKey.Experience, this.PM.PetUI_OldLV);
        this.ImageFATo = this.ImageExpNeed == 0U ? 0.0f : (float) this.NowPet.SkillExp[this.SelectSkillIndex] / (float) this.ImageExpNeed;
      }
    }
    else if (this.ASExp_EffectKind == eUIPet_Eff.eEff_ExpX2)
    {
      this.ASExp_EffDTime = 0.0f;
      this.ASExp_EffTatalTime = 1.6f;
      ((Component) this.ASExp_EffIconBlockImage).gameObject.SetActive(true);
      ((Component) this.ASExp_EffIconMoveImage).gameObject.SetActive(true);
      ((Component) this.ASExp_EffBarBlockImage).gameObject.SetActive(true);
      ((Component) this.ASExp_EffBarInnerImage).gameObject.SetActive(true);
      ((Component) this.ASExp_EffExpBackImage).gameObject.SetActive(true);
      ((Graphic) this.ASExp_EffExpBackImage).rectTransform.sizeDelta = new Vector2(335f, 185f);
      ((Graphic) this.ASExp_EffExpBackImage).rectTransform.anchoredPosition = new Vector2(6.5f, 29.5f);
      this.ASExp_EffExpStr.Length = 0;
      this.ASExp_EffExpStr.IntToFormat((long) this.PM.PetUI_GetExp, bNumber: true);
      if (this.GM.IsArabic)
        this.ASExp_EffExpStr.AppendFormat("Exp {0}+");
      else
        this.ASExp_EffExpStr.AppendFormat("Exp+{0}");
      this.ASExp_EffExpText.text = this.ASExp_EffExpStr.ToString();
      ((Component) this.ASExp_EffExpText).gameObject.SetActive(true);
      this.ASExp_EffX2Str.Length = 0;
      this.ASExp_EffX2Str.IntToFormat((long) ((int) this.PM.PetUI_GetRate / 1000), bNumber: true);
      if (this.GM.IsArabic)
        this.ASExp_EffX2Str.AppendFormat("{0}x");
      else
        this.ASExp_EffX2Str.AppendFormat("x{0}");
      this.ASExp_EffX2Text.text = this.ASExp_EffX2Str.ToString();
      ((Component) this.ASExp_EffX2Text).gameObject.SetActive(true);
      if (this.ASExp_EffbLVUp)
      {
        this.ImageFAFrom = this.ASExp_ExpBarImage.fillAmount;
        this.ImageFATo = 1f;
        this.ImageExpNeed = this.GetNeedSkillExp(recordByKey.Experience, this.PM.PetUI_OldLV);
      }
      else
      {
        this.ImageFAFrom = this.ASExp_ExpBarImage.fillAmount;
        this.ImageExpNeed = this.GetNeedSkillExp(recordByKey.Experience, this.PM.PetUI_OldLV);
        this.ImageFATo = this.ImageExpNeed == 0U ? 0.0f : (float) this.NowPet.SkillExp[this.SelectSkillIndex] / (float) this.ImageExpNeed;
      }
    }
    this.SetEffAll();
  }

  private bool EndEffect()
  {
    if (this.ASExp_EffectKind == eUIPet_Eff.eEff_None)
      return false;
    bool flag = false;
    this.ASExp_bPlaySound = false;
    this.DeSpawnParticle_X2();
    this.ASExp_AddBtn1Click.SetActive(false);
    this.ASExp_AddBtn2Click.SetActive(false);
    this.ASExp_EffectKind = eUIPet_Eff.eEff_None;
    ((Component) this.ASExp_EffIconBlockImage).gameObject.SetActive(false);
    ((Component) this.ASExp_EffIconMoveImage).gameObject.SetActive(false);
    ((Component) this.ASExp_EffBarBlockImage).gameObject.SetActive(false);
    ((Component) this.ASExp_EffBarInnerImage).gameObject.SetActive(false);
    ((Component) this.ASExp_EffExpBackImage).gameObject.SetActive(false);
    ((Component) this.ASExp_EffExpText).gameObject.SetActive(false);
    ((Component) this.ASExp_EffX2Text).gameObject.SetActive(false);
    ((Transform) ((Graphic) this.ASExp_ExpBar).rectTransform).localScale = Vector3.one;
    if (this.GM.IsArabic)
      ((Transform) ((Graphic) this.ASExp_SkillExpText).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    else
      ((Transform) ((Graphic) this.ASExp_SkillExpText).rectTransform).localScale = Vector3.one;
    ((Transform) ((Graphic) this.ASExp_EffBarBlockImage).rectTransform).localScale = Vector3.one;
    if (this.ASExp_EffbLVUp)
    {
      this.ASExp_EffbLVUp = false;
      this.PM.OpenPetLevelUp(this.NowPet.ID, this.PM.PetUI_OldLV, this.NowPet.SkillLv[this.SelectSkillIndex], this.PM.PetUI_OldExp, this.NowPet.SkillExp[this.SelectSkillIndex], 1, this.sPet.PetSkill[this.SelectSkillIndex]);
      flag = true;
    }
    this.SetSkill();
    this.SetAddSkill_Item();
    this.SetAddSkill_Info();
    this.CheckAddBtnState();
    return flag;
  }

  private void SetEffAll()
  {
    if (this.ASExp_EffectKind == eUIPet_Eff.eEff_ExpAdd)
    {
      this.UpDateImageAlpha(this.ASExp_EffIconMoveImage, this.IconMove_AlphaKey, this.IconMove_AlphaValue);
      this.UpDateImagePos(this.ASExp_EffIconMoveImage, this.IconMove_PosKey, this.IconMove_PosValue, this.IconMove_OriginalPos);
      this.UpDateImageAlpha(this.ASExp_EffIconBlockImage, this.IconBlock_AlphaKey, this.IconBlock_AlphaValue);
      this.UpDateImageScale(this.ASExp_EffIconBlockImage, this.IconBlock_ScaleKey, this.IconBlock_ScaleValue);
      this.UpDateImageAlpha(this.ASExp_EffExpBackImage, this.ExpText_AlphaKey, this.ExpText_AlphaValue);
      if (this.ASExp_EffbLVUp)
      {
        this.UpDateImageAlpha(this.ASExp_EffBarBlockImage, this.BarBlockImageAlphaKey_Up, this.BarBlockImageAlphaValue_Up);
        this.UpDateImageScale(this.ASExp_EffBarBlockImage, this.BarBlockImageScaleKey_Up, this.BarBlockImageScaleValue_Up);
        this.UpDateImageAlpha(this.ASExp_EffBarInnerImage, this.BarInnerImageAlphaKey, this.BarInnerImageAlphaValue);
        this.UpDateImageScale(this.ASExp_EffBarInnerImage, this.BarInnerImageScaleKey, this.BarInnerImageScaleValue);
      }
      else
        this.UpDateImageAlpha(this.ASExp_EffBarBlockImage, this.BarBlockImageAlphaKey, this.BarBlockImageAlphaValue);
      this.UpDateTextAlpha(this.ASExp_EffExpText, this.ExpText_AlphaKey, this.ExpText_AlphaValue);
      this.UpDateTextScale(this.ASExp_EffExpText, this.ExpText_ScaleKey, this.ExpText_ScaleValue);
      this.UpDateTextPos(this.ASExp_EffExpText, this.ExpText_PositionKey, this.ExpText_PositionValue, this.ExpText_OriginalPos);
      this.UpDateImageFillAmount(this.ASExp_ExpBarImage, this.ExpBarFA_ScaleKey);
      if (this.ASExp_bPlaySound || (double) this.ASExp_EffDTime < 0.30000001192092896)
        return;
      this.ASExp_bPlaySound = true;
      AudioManager.Instance.PlayUISFX(UIKind.PetAddExp);
    }
    else
    {
      if (this.ASExp_EffectKind != eUIPet_Eff.eEff_ExpX2)
        return;
      this.UpDateImageAlpha(this.ASExp_EffIconMoveImage, this.IconMove_AlphaKey, this.IconMove_AlphaValue);
      this.UpDateImagePos(this.ASExp_EffIconMoveImage, this.IconMove_PosKey, this.IconMove_PosValue, this.IconMove_OriginalPos);
      this.UpDateImageAlpha(this.ASExp_EffIconBlockImage, this.IconBlock_AlphaKey, this.IconBlock_AlphaValue);
      this.UpDateImageScale(this.ASExp_EffIconBlockImage, this.IconBlock_ScaleKey, this.IconBlock_ScaleValue);
      this.UpDateImageAlpha(this.ASExp_EffExpBackImage, this.X2Text_AlphaKey, this.X2Text_AlphaValue);
      this.UpDateTextAlpha(this.ASExp_EffExpText, this.ExpTextX2_AlphaKey, this.ExpTextX2_AlphaValue);
      this.UpDateTextScale(this.ASExp_EffExpText, this.ExpTextX2_ScaleKey, this.ExpTextX2_ScaleValue);
      this.UpDateTextPos(this.ASExp_EffExpText, this.ExpTextX2_PositionKey, this.ExpTextX2_PositionValue, this.ExpText_OriginalPos);
      this.UpDateTextAlpha(this.ASExp_EffX2Text, this.X2Text_AlphaKey, this.X2Text_AlphaValue);
      this.UpDateTextScale(this.ASExp_EffX2Text, this.X2Text_ScaleKey, this.X2Text_ScaleValue);
      this.UpDateImageScale(this.ASExp_ExpBar, this.ExpBar_ScaleKey, this.ExpBar_ScaleValue);
      this.UpDateTextAlpha(this.ASExp_SkillExpText, this.ExpBarText_AlphaKey, this.ExpBarText_AlphaValue);
      this.UpDateTextScale(this.ASExp_SkillExpText, this.ExpBarText_ScaleKey, this.ExpBarText_ScaleValue);
      this.UpDateImageAlpha(this.ASExp_EffBarBlockImage, this.BarBlockImageX2AlphaKey, this.BarBlockImageX2AlphaValue);
      this.UpDateImageScale(this.ASExp_EffBarBlockImage, this.BarBlockImageX2ScaleKey, this.BarBlockImageX2ScaleValue);
      this.UpDateImageAlpha(this.ASExp_EffBarInnerImage, this.BarInnerImageX2AlphaKey, this.BarInnerImageX2AlphaValue);
      this.UpDateImageScale(this.ASExp_EffBarInnerImage, this.BarInnerImageX2ScaleKey, this.BarInnerImageX2ScaleValue);
      this.UpDateImageFillAmount(this.ASExp_ExpBarImage, this.ExpBarFA_ScaleKey);
      if ((double) this.ASExp_EffDTime >= 0.5)
        this.SpawnParticle_X2();
      if (this.ASExp_bPlaySound || (double) this.ASExp_EffDTime < 0.5)
        return;
      this.ASExp_bPlaySound = true;
      AudioManager.Instance.PlayUISFX(UIKind.PetAddExpX2);
    }
  }

  private void OpenSrcHint(byte Kind)
  {
    if (this.NowPet == null)
      return;
    UIButtonHint hint = (UIButtonHint) null;
    switch (Kind)
    {
      case 1:
        hint = this.EVO_SrcHint;
        break;
      case 2:
        hint = this.ASExp_SrcHint;
        break;
    }
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(this.sPet.SoulID);
    CString Content = StringManager.Instance.StaticString1024();
    if (recordByKey.SyntheticParts[3].SyntheticItem == ushort.MaxValue)
    {
      Content.Append(this.DM.mStringTable.GetStringByID(16089U));
    }
    else
    {
      Content.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey.SyntheticParts[3].SyntheticItem));
      Content.AppendFormat(this.DM.mStringTable.GetStringByID(16090U));
    }
    this.GM.m_Hint.Show(hint, UIHintStyle.eHintSimple, (byte) 0, 305f, 20, Content, Vector2.zero);
  }

  private void CheckUpgradeSkill(byte Kind)
  {
    if (this.NowPet == null || this.SelectSkillIndex < 0 || this.SelectSkillIndex >= 4)
      return;
    bool flag = false;
    PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[this.SelectSkillIndex]);
    byte Lv = this.NowPet.SkillLv[this.SelectSkillIndex];
    uint num1 = this.NowPet.SkillExp[this.SelectSkillIndex] + this.PM.PetUI_BaseExp;
    byte num2 = 0;
    do
    {
      uint needSkillExp = this.GetNeedSkillExp(recordByKey.Experience, Lv);
      if (num1 >= needSkillExp)
      {
        if ((int) Lv >= (int) recordByKey.UpLevel || Lv == (byte) 0 || (int) Lv > recordByKey.OpenLevel.Length || (int) recordByKey.OpenLevel[(int) Lv - 1] > (int) this.NowPet.Level)
        {
          flag = true;
          break;
        }
        num1 -= needSkillExp;
        ++Lv;
        ++num2;
      }
      else
        break;
    }
    while (num2 <= (byte) 15);
    if (flag)
      this.GM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(685U), this.DM.mStringTable.GetStringByID(12139U), 4, (int) Kind);
    else
      this.SendUpgradeSkill(Kind);
  }

  private void SendUpgradeSkill(byte Kind)
  {
    this.PM.Send_PETSKILL_UPGRADESKILL(this.NowPet.ID, (byte) this.SelectSkillIndex, Kind);
  }

  private void ShowSkillUpbLevel()
  {
    if (this.NowPet == null)
      return;
    if (this.NowPet.CheckState(PetManager.EPetState.Evolution))
      this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12142U), (ushort) 35);
    else if (this.NowPet.CheckState(PetManager.EPetState.LockLimit))
      GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(16082U), this.DM.mStringTable.GetStringByID(16069U), this.DM.mStringTable.GetStringByID(156U), (GUIWindow) this, 5, (int) this.NowPet.ID, true);
    else
      GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(12143U), this.DM.mStringTable.GetStringByID(12144U), this.DM.mStringTable.GetStringByID(156U), (GUIWindow) this, 6, (int) this.NowPet.ID, true);
  }

  private void UpDateImageAlpha(Image tmpImg, float[] Key, float[] Value)
  {
    if ((Object) tmpImg == (Object) null || Key == null || Value == null || Key.Length != Value.Length)
      return;
    int index1 = Key.Length - 1;
    float a = 0.0f;
    if ((double) this.ASExp_EffDTime >= (double) Key[index1])
      a = Value[index1];
    else if ((double) this.ASExp_EffDTime < (double) Key[0])
    {
      a = Value[0];
    }
    else
    {
      for (int index2 = 0; index2 < index1; ++index2)
      {
        if ((double) this.ASExp_EffDTime >= (double) Key[index2] && (double) this.ASExp_EffDTime < (double) Key[index2 + 1])
        {
          a = Mathf.Lerp(Value[index2], Value[index2 + 1], (float) (((double) this.ASExp_EffDTime - (double) Key[index2]) / ((double) Key[index2 + 1] - (double) Key[index2])));
          break;
        }
      }
    }
    ((Graphic) tmpImg).color = new Color(((Graphic) tmpImg).color.r, ((Graphic) tmpImg).color.g, ((Graphic) tmpImg).color.b, a);
  }

  private void UpDateImageScale(Image tmpImg, float[] Key, Vector2[] Value)
  {
    if ((Object) tmpImg == (Object) null || Key == null || Value == null || Key.Length != Value.Length)
      return;
    int index1 = Key.Length - 1;
    Vector2 one = Vector2.one;
    if ((double) this.ASExp_EffDTime >= (double) Key[index1])
      one = Value[index1];
    else if ((double) this.ASExp_EffDTime < (double) Key[0])
    {
      one = Value[0];
    }
    else
    {
      for (int index2 = 0; index2 < index1; ++index2)
      {
        if ((double) this.ASExp_EffDTime >= (double) Key[index2] && (double) this.ASExp_EffDTime < (double) Key[index2 + 1])
        {
          float t = (float) (((double) this.ASExp_EffDTime - (double) Key[index2]) / ((double) Key[index2 + 1] - (double) Key[index2]));
          one.x = Mathf.Lerp(Value[index2].x, Value[index2 + 1].x, t);
          one.y = Mathf.Lerp(Value[index2].y, Value[index2 + 1].y, t);
          break;
        }
      }
    }
    ((Transform) ((Graphic) tmpImg).rectTransform).localScale = (Vector3) one;
  }

  private void UpDateImagePos(Image tmpImg, float[] Key, Vector2[] Value, Vector2 originalPos)
  {
    if ((Object) tmpImg == (Object) null || Key == null || Value == null || Key.Length != Value.Length)
      return;
    int index1 = Key.Length - 1;
    Vector2 one = Vector2.one;
    if ((double) this.ASExp_EffDTime >= (double) Key[index1])
      one = Value[index1];
    else if ((double) this.ASExp_EffDTime < (double) Key[0])
    {
      one = Value[0];
    }
    else
    {
      for (int index2 = 0; index2 < index1; ++index2)
      {
        if ((double) this.ASExp_EffDTime >= (double) Key[index2] && (double) this.ASExp_EffDTime < (double) Key[index2 + 1])
        {
          float t = (float) (((double) this.ASExp_EffDTime - (double) Key[index2]) / ((double) Key[index2 + 1] - (double) Key[index2]));
          one.x = Mathf.Lerp(Value[index2].x, Value[index2 + 1].x, t);
          one.y = Mathf.Lerp(Value[index2].y, Value[index2 + 1].y, t);
          break;
        }
      }
    }
    ((Graphic) tmpImg).rectTransform.anchoredPosition = originalPos + one;
  }

  private void UpDateTextAlpha(UIText tmpText, float[] Key, float[] Value)
  {
    if ((Object) tmpText == (Object) null || Key == null || Value == null || Key.Length != Value.Length)
      return;
    int index1 = Key.Length - 1;
    float a = 0.0f;
    if ((double) this.ASExp_EffDTime >= (double) Key[index1])
      a = Value[index1];
    else if ((double) this.ASExp_EffDTime < (double) Key[0])
    {
      a = Value[0];
    }
    else
    {
      for (int index2 = 0; index2 < index1; ++index2)
      {
        if ((double) this.ASExp_EffDTime >= (double) Key[index2] && (double) this.ASExp_EffDTime < (double) Key[index2 + 1])
        {
          a = Mathf.Lerp(Value[index2], Value[index2 + 1], (float) (((double) this.ASExp_EffDTime - (double) Key[index2]) / ((double) Key[index2 + 1] - (double) Key[index2])));
          break;
        }
      }
    }
    ((Graphic) tmpText).color = new Color(((Graphic) tmpText).color.r, ((Graphic) tmpText).color.g, ((Graphic) tmpText).color.b, a);
  }

  private void UpDateTextScale(UIText tmpText, float[] Key, Vector2[] Value)
  {
    if ((Object) tmpText == (Object) null || Key == null || Value == null || Key.Length != Value.Length)
      return;
    int index1 = Key.Length - 1;
    Vector2 one = Vector2.one;
    if ((double) this.ASExp_EffDTime >= (double) Key[index1])
      one = Value[index1];
    else if ((double) this.ASExp_EffDTime < (double) Key[0])
    {
      one = Value[0];
    }
    else
    {
      for (int index2 = 0; index2 < index1; ++index2)
      {
        if ((double) this.ASExp_EffDTime >= (double) Key[index2] && (double) this.ASExp_EffDTime < (double) Key[index2 + 1])
        {
          float t = (float) (((double) this.ASExp_EffDTime - (double) Key[index2]) / ((double) Key[index2 + 1] - (double) Key[index2]));
          one.x = Mathf.Lerp(Value[index2].x, Value[index2 + 1].x, t);
          one.y = Mathf.Lerp(Value[index2].y, Value[index2 + 1].y, t);
          break;
        }
      }
    }
    if (this.GM.IsArabic)
      ((Transform) ((Graphic) tmpText).rectTransform).localScale = (Vector3) new Vector2(-one.x, one.y);
    else
      ((Transform) ((Graphic) tmpText).rectTransform).localScale = (Vector3) one;
  }

  private void UpDateTextPos(UIText tmpText, float[] Key, Vector2[] Value, Vector2 originalPos)
  {
    if ((Object) tmpText == (Object) null || Key == null || Value == null || Key.Length != Value.Length)
      return;
    int index1 = Key.Length - 1;
    Vector2 one = Vector2.one;
    if ((double) this.ASExp_EffDTime >= (double) Key[index1])
      one = Value[index1];
    else if ((double) this.ASExp_EffDTime < (double) Key[0])
    {
      one = Value[0];
    }
    else
    {
      for (int index2 = 0; index2 < index1; ++index2)
      {
        if ((double) this.ASExp_EffDTime >= (double) Key[index2] && (double) this.ASExp_EffDTime < (double) Key[index2 + 1])
        {
          float t = (float) (((double) this.ASExp_EffDTime - (double) Key[index2]) / ((double) Key[index2 + 1] - (double) Key[index2]));
          one.x = Mathf.Lerp(Value[index2].x, Value[index2 + 1].x, t);
          one.y = Mathf.Lerp(Value[index2].y, Value[index2 + 1].y, t);
          break;
        }
      }
    }
    ((Graphic) tmpText).rectTransform.anchoredPosition = originalPos + one;
  }

  private void UpDateImageFillAmount(Image tmpImg, float[] Key)
  {
    if ((Object) tmpImg == (Object) null || Key == null)
      return;
    int index1 = Key.Length - 1;
    float num1 = this.ImageFAFrom;
    if ((double) this.ASExp_EffDTime >= (double) Key[index1])
      num1 = this.ImageFATo;
    else if ((double) this.ASExp_EffDTime < (double) Key[0])
    {
      num1 = this.ImageFAFrom;
    }
    else
    {
      for (int index2 = 0; index2 < index1; ++index2)
      {
        if ((double) this.ASExp_EffDTime >= (double) Key[index2] && (double) this.ASExp_EffDTime < (double) Key[index2 + 1])
        {
          num1 = Mathf.Lerp(this.ImageFAFrom, this.ImageFATo, (float) (((double) this.ASExp_EffDTime - (double) Key[index2]) / ((double) Key[index2 + 1] - (double) Key[index2])));
          break;
        }
      }
    }
    this.ASExp_SkillExpStr.Length = 0;
    long num2 = !this.ASExp_EffbLVUp ? ((double) this.ASExp_EffDTime < (double) Key[index1] ? (long) ((double) num1 * (double) this.ImageExpNeed) : (long) this.NowPet.SkillExp[this.SelectSkillIndex]) : ((double) this.ASExp_EffDTime < (double) Key[index1] ? (long) ((double) num1 * (double) this.ImageExpNeed) : (long) this.ImageExpNeed);
    this.ASExp_SkillExpStr.IntToFormat(num2 >= (long) this.PM.PetUI_OldExp ? num2 : (long) this.PM.PetUI_OldExp, bNumber: true);
    this.ASExp_SkillExpStr.IntToFormat((long) this.ImageExpNeed, bNumber: true);
    if (this.GM.IsArabic)
      this.ASExp_SkillExpStr.AppendFormat("{1} / {0} ");
    else
      this.ASExp_SkillExpStr.AppendFormat("{0} / {1} ");
    this.ASExp_SkillExpStr.Append(this.DM.mStringTable.GetStringByID(9U));
    this.ASExp_SkillExpText.text = this.ASExp_SkillExpStr.ToString();
    this.ASExp_SkillExpText.SetAllDirty();
    this.ASExp_SkillExpText.cachedTextGenerator.Invalidate();
    tmpImg.fillAmount = num1;
  }

  private void Update()
  {
    if (!this.bABInitial && this.AR != null && this.AR.isDone)
    {
      this.PetGO = ModelLoader.Instance.Load(this.sHero.Modle, this.AB, (ushort) this.sHero.TextureNo);
      this.PetGO.transform.SetParent((Transform) this.PetPosRT, false);
      this.PetGO.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
      {
        eulerAngles = new Vector3(0.0f, (float) this.sHero.Camera_Horizontal, 0.0f)
      };
      this.PetGO.transform.localScale = this.bMaxShow || (int) this.NowPet.Enhance >= this.sPet.PetRatio.Length ? new Vector3((float) this.sPet.PetRatio[2].Ratio, (float) this.sPet.PetRatio[2].Ratio, (float) this.sPet.PetRatio[2].Ratio) : new Vector3((float) this.sPet.PetRatio[(int) this.NowPet.Enhance].Ratio, (float) this.sPet.PetRatio[(int) this.NowPet.Enhance].Ratio, (float) this.sPet.PetRatio[(int) this.NowPet.Enhance].Ratio);
      this.PetGO.transform.localPosition = Vector3.zero;
      this.GM.SetLayer(this.PetGO, 5);
      this.PetPosRT.anchoredPosition = this.bMaxShow || (int) this.NowPet.Enhance >= this.sPet.PetRatio.Length ? new Vector2(this.PetPosRT.anchoredPosition.x, (float) (-180 - (1000 - (int) this.sPet.PetRatio[2].UpDownDist))) : new Vector2(this.PetPosRT.anchoredPosition.x, (float) (-180 - (1000 - (int) this.sPet.PetRatio[(int) this.NowPet.Enhance].UpDownDist)));
      this.PetModel = ((Transform) this.PetPosRT).GetChild(0).GetComponent<Transform>();
      if ((Object) this.PetModel != (Object) null)
      {
        this.tmpAN = this.PetModel.GetComponent<Animation>();
        this.tmpAN.wrapMode = WrapMode.Loop;
        this.tmpAN.cullingType = AnimationCullingType.AlwaysAnimate;
        this.tmpAN.Play(this.mPetAct[0]);
        this.tmpAN.clip = this.tmpAN.GetClip(this.mPetAct[0]);
        if (((Component) this.PetPosRT).gameObject.activeSelf)
        {
          SkinnedMeshRenderer componentInChildren = this.PetModel.GetComponentInChildren<SkinnedMeshRenderer>();
          componentInChildren.useLightProbes = false;
          componentInChildren.updateWhenOffscreen = true;
        }
      }
      this.bABInitial = true;
      this.SpawnParticle_Body();
      this.SpawnParticle_Up();
    }
    if (this.bABInitial && (Object) this.PetModel != (Object) null)
    {
      if ((!this.tmpAN.IsPlaying(this.PetAct) || this.PetAct == "idle") && (double) this.ActionTimeRandom < 0.0001)
      {
        this.ActionTimeRandom = (float) Random.Range(3, 7);
        this.ActionTime = 0.0f;
        this.HideEmoji();
      }
      if ((double) this.ActionTimeRandom > 0.0001)
      {
        this.ActionTime += Time.smoothDeltaTime;
        if ((double) this.ActionTime >= (double) this.ActionTimeRandom)
          this.HeroActionChang();
      }
      if ((double) this.MovingTimer > 0.0)
      {
        this.MovingTimer -= Time.deltaTime;
        if ((double) this.MovingTimer <= 0.0)
        {
          this.tmpAN.CrossFade("idle");
          this.PetAct = "idle";
        }
      }
    }
    if (!this.bMaxShow && (Object) this.Left_T != (Object) null && (Object) this.Right_T != (Object) null && (this.Left_T.gameObject.activeInHierarchy || this.Right_T.gameObject.activeInHierarchy))
    {
      this.MoveX += Time.smoothDeltaTime * 40f;
      if ((double) this.MoveX >= 40.0)
        this.MoveX = 0.0f;
      float num = (double) this.MoveX <= 20.0 ? this.MoveX : 40f - this.MoveX;
      if ((double) num < 0.0)
        num = 0.0f;
      this.BtnPos.Set(this.LeftPosX - num, this.Left_T.localPosition.y, this.Left_T.localPosition.z);
      this.Left_T.localPosition = this.BtnPos;
      this.BtnPos.Set(this.RightPosX + num, this.Right_T.localPosition.y, this.Right_T.localPosition.z);
      this.Right_T.localPosition = this.BtnPos;
    }
    if (this.SelectSkillIndex != -1 && (Object) this.ASExp_MaxRImageT != (Object) null)
      this.ASExp_MaxRImageT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    if ((Object) this.PanelRLightT != (Object) null)
      this.PanelRLightT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    if ((double) this.EmijiShowCountTime >= 0.0 && (Object) this.EmojiRC != (Object) null)
    {
      this.EmijiShowCountTime += Time.smoothDeltaTime;
      if ((double) this.EmijiShowCountTime > (double) this.EmijiShowTime1 + (double) this.EmijiShowTime2)
      {
        this.EndEmojiMove();
      }
      else
      {
        float num = 0.0f;
        if ((double) this.EmijiShowCountTime <= (double) this.EmijiShowTime1)
          num = Mathf.Lerp(0.0f, this.EmojiShowMaxScale, this.EmijiShowCountTime / this.EmijiShowTime1);
        else if ((double) this.EmijiShowCountTime > (double) this.EmijiShowTime1)
          num = Mathf.Lerp(this.EmojiShowMaxScale, 1f, (float) (1.0 - ((double) this.EmijiShowCountTime - (double) this.EmijiShowTime1) / (double) this.EmijiShowTime2));
        ((Transform) this.EmojiRC).localScale = new Vector3(num, num, num);
      }
    }
    if ((double) this.ClickAddSkillTime >= 0.0)
    {
      this.ClickAddSkillTime += Time.deltaTime;
      if ((double) this.ClickAddSkillTime >= 0.30000001192092896)
        this.ClickAddSkillTime = -1f;
    }
    if (this.ASExp_EffectKind != eUIPet_Eff.eEff_None)
    {
      this.ASExp_EffDTime += Time.deltaTime;
      if ((double) this.ASExp_EffDTime >= (double) this.ASExp_EffTatalTime)
        this.EndEffect();
      else
        this.SetEffAll();
    }
    if (!this.bMaxShow || !((Object) this.MaxShowBack != (Object) null) || !((Object) this.MaxShowText != (Object) null))
      return;
    this.MaxShowFalshTime += Time.smoothDeltaTime;
    if ((double) this.MaxShowFalshTime < 0.0)
      return;
    if ((double) this.MaxShowFalshTime >= 3.0999999046325684)
      this.MaxShowFalshTime = 0.0f;
    float num1 = 1f;
    if ((double) this.MaxShowFalshTime > 0.5)
      num1 = (double) this.MaxShowFalshTime <= 1.7999999523162842 ? (float) (0.25 + (1.2999999523162842 - ((double) this.MaxShowFalshTime - 0.5)) / 1.2999999523162842 * 0.75) : (float) (0.25 + ((double) this.MaxShowFalshTime - 0.5 - 1.2999999523162842) / 1.2999999523162842 * 0.75);
    float a = Mathf.Clamp(num1, 0.25f, 1f);
    ((Graphic) this.MaxShowBack).color = new Color(1f, 1f, 0.518f, a);
    ((Graphic) this.MaxShowText).color = new Color(1f, 1f, 0.518f, a);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        if (!this.bMaxShow)
        {
          this.PM.SortPetData();
          this.SetParticle_Show(true);
        }
        this.CheckShowLRBtn();
        break;
      case NetworkNews.Fallout:
        if (this.bMaxShow)
          break;
        this.SetParticle_Show(false);
        break;
      case NetworkNews.Refresh_Asset:
        if (meg[1] != (byte) 1 || meg[2] != (byte) 2 || (int) GameConstants.ConvertBytesToUShort(meg, 3) != (int) this.sHero.Modle)
          break;
        this.DestroyPet3D();
        this.LoadPet3D();
        break;
      case NetworkNews.Refresh_Item:
        if (this.bMaxShow)
          break;
        this.SetStone();
        this.SetPetInfo();
        this.SetSkill();
        this.SetAddSkill_Item();
        this.CheckAddBtnState();
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
        {
          if (networkNews != NetworkNews.Refresh_Pet || this.bMaxShow || this.PM.PetUI_PetSortIndex < 0 || this.PM.PetUI_PetSortIndex >= (int) this.PM.PetDataCount)
            break;
          PetData petData = this.PM.GetPetData((int) this.PM.sortPetData[this.PM.PetUI_PetSortIndex]);
          if (petData == null || (int) petData.ID != this.PM.PetUI_PetID)
          {
            this.PM.CheckPetSortIndexAndSort();
            this.SetNowPet();
            break;
          }
          this.SetBlood();
          this.SetPetInfo();
          this.SetSkill();
          break;
        }
        for (int index = 0; index < 3; ++index)
        {
          if ((Object) this.SkillNameText[index] != (Object) null && ((Behaviour) this.SkillNameText[index]).enabled)
          {
            ((Behaviour) this.SkillNameText[index]).enabled = false;
            ((Behaviour) this.SkillNameText[index]).enabled = true;
          }
          if ((Object) this.SkillExpText[index] != (Object) null && ((Behaviour) this.SkillExpText[index]).enabled)
          {
            ((Behaviour) this.SkillExpText[index]).enabled = false;
            ((Behaviour) this.SkillExpText[index]).enabled = true;
          }
          if ((Object) this.SkillLockText[index] != (Object) null && ((Behaviour) this.SkillLockText[index]).enabled)
          {
            ((Behaviour) this.SkillLockText[index]).enabled = false;
            ((Behaviour) this.SkillLockText[index]).enabled = true;
          }
        }
        if ((Object) this.PetNameText != (Object) null && ((Behaviour) this.PetNameText).enabled)
        {
          ((Behaviour) this.PetNameText).enabled = false;
          ((Behaviour) this.PetNameText).enabled = true;
        }
        if ((Object) this.ExpText != (Object) null && ((Behaviour) this.ExpText).enabled)
        {
          ((Behaviour) this.ExpText).enabled = false;
          ((Behaviour) this.ExpText).enabled = true;
        }
        if ((Object) this.StoneText != (Object) null && ((Behaviour) this.StoneText).enabled)
        {
          ((Behaviour) this.StoneText).enabled = false;
          ((Behaviour) this.StoneText).enabled = true;
        }
        if ((Object) this.LevelText_L != (Object) null && ((Behaviour) this.LevelText_L).enabled)
        {
          ((Behaviour) this.LevelText_L).enabled = false;
          ((Behaviour) this.LevelText_L).enabled = true;
        }
        if ((Object) this.RareText != (Object) null && ((Behaviour) this.RareText).enabled)
        {
          ((Behaviour) this.RareText).enabled = false;
          ((Behaviour) this.RareText).enabled = true;
        }
        if ((Object) this.LevelText != (Object) null && ((Behaviour) this.LevelText).enabled)
        {
          ((Behaviour) this.LevelText).enabled = false;
          ((Behaviour) this.LevelText).enabled = true;
        }
        if ((Object) this.RankText != (Object) null && ((Behaviour) this.RankText).enabled)
        {
          ((Behaviour) this.RankText).enabled = false;
          ((Behaviour) this.RankText).enabled = true;
        }
        if ((Object) this.RankText2 != (Object) null && ((Behaviour) this.RankText2).enabled)
        {
          ((Behaviour) this.RankText2).enabled = false;
          ((Behaviour) this.RankText2).enabled = true;
        }
        if ((Object) this.UpText != (Object) null && ((Behaviour) this.UpText).enabled)
        {
          ((Behaviour) this.UpText).enabled = false;
          ((Behaviour) this.UpText).enabled = true;
        }
        if ((Object) this.PanelTitleText1 != (Object) null && ((Behaviour) this.PanelTitleText1).enabled)
        {
          ((Behaviour) this.PanelTitleText1).enabled = false;
          ((Behaviour) this.PanelTitleText1).enabled = true;
        }
        if ((Object) this.PanelTitleText2 != (Object) null && ((Behaviour) this.PanelTitleText2).enabled)
        {
          ((Behaviour) this.PanelTitleText2).enabled = false;
          ((Behaviour) this.PanelTitleText2).enabled = true;
        }
        if ((Object) this.MaxShowText != (Object) null && ((Behaviour) this.MaxShowText).enabled)
        {
          ((Behaviour) this.MaxShowText).enabled = false;
          ((Behaviour) this.MaxShowText).enabled = true;
        }
        if ((Object) this.EVO_TitleText != (Object) null && ((Behaviour) this.EVO_TitleText).enabled)
        {
          ((Behaviour) this.EVO_TitleText).enabled = false;
          ((Behaviour) this.EVO_TitleText).enabled = true;
        }
        if ((Object) this.EVO_InfoText != (Object) null && ((Behaviour) this.EVO_InfoText).enabled)
        {
          ((Behaviour) this.EVO_InfoText).enabled = false;
          ((Behaviour) this.EVO_InfoText).enabled = true;
        }
        if ((Object) this.EVO_UpText != (Object) null && ((Behaviour) this.EVO_UpText).enabled)
        {
          ((Behaviour) this.EVO_UpText).enabled = false;
          ((Behaviour) this.EVO_UpText).enabled = true;
        }
        if ((Object) this.EVO_NeedLvText != (Object) null && ((Behaviour) this.EVO_NeedLvText).enabled)
        {
          ((Behaviour) this.EVO_NeedLvText).enabled = false;
          ((Behaviour) this.EVO_NeedLvText).enabled = true;
        }
        if ((Object) this.EVO_LPriceText != (Object) null && ((Behaviour) this.EVO_LPriceText).enabled)
        {
          ((Behaviour) this.EVO_LPriceText).enabled = false;
          ((Behaviour) this.EVO_LPriceText).enabled = true;
        }
        if ((Object) this.EVO_LBtnText != (Object) null && ((Behaviour) this.EVO_LBtnText).enabled)
        {
          ((Behaviour) this.EVO_LBtnText).enabled = false;
          ((Behaviour) this.EVO_LBtnText).enabled = true;
        }
        if ((Object) this.EVO_RTimeText != (Object) null && ((Behaviour) this.EVO_RTimeText).enabled)
        {
          ((Behaviour) this.EVO_RTimeText).enabled = false;
          ((Behaviour) this.EVO_RTimeText).enabled = true;
        }
        if ((Object) this.EVO_RBtnText != (Object) null && ((Behaviour) this.EVO_RBtnText).enabled)
        {
          ((Behaviour) this.EVO_RBtnText).enabled = false;
          ((Behaviour) this.EVO_RBtnText).enabled = true;
        }
        if ((Object) this.TimeBar != (Object) null && this.TimeBar.enabled)
          this.TimeBar.Refresh_FontTexture();
        if (this.bMaxShow)
          break;
        if ((Object) this.ASExp_InfoNowtext != (Object) null && ((Behaviour) this.ASExp_InfoNowtext).enabled)
        {
          ((Behaviour) this.ASExp_InfoNowtext).enabled = false;
          ((Behaviour) this.ASExp_InfoNowtext).enabled = true;
        }
        if ((Object) this.ASExp_InfoNextText != (Object) null && ((Behaviour) this.ASExp_InfoNextText).enabled)
        {
          ((Behaviour) this.ASExp_InfoNextText).enabled = false;
          ((Behaviour) this.ASExp_InfoNextText).enabled = true;
        }
        if ((Object) this.ASExp_SkillNameText != (Object) null && ((Behaviour) this.ASExp_SkillNameText).enabled)
        {
          ((Behaviour) this.ASExp_SkillNameText).enabled = false;
          ((Behaviour) this.ASExp_SkillNameText).enabled = true;
        }
        if ((Object) this.ASExp_SkillLvText != (Object) null && ((Behaviour) this.ASExp_SkillLvText).enabled)
        {
          ((Behaviour) this.ASExp_SkillLvText).enabled = false;
          ((Behaviour) this.ASExp_SkillLvText).enabled = true;
        }
        if ((Object) this.ASExp_SkillExpText != (Object) null && ((Behaviour) this.ASExp_SkillExpText).enabled)
        {
          ((Behaviour) this.ASExp_SkillExpText).enabled = false;
          ((Behaviour) this.ASExp_SkillExpText).enabled = true;
        }
        if ((Object) this.ASExp_HaveCountText1 != (Object) null && ((Behaviour) this.ASExp_HaveCountText1).enabled)
        {
          ((Behaviour) this.ASExp_HaveCountText1).enabled = false;
          ((Behaviour) this.ASExp_HaveCountText1).enabled = true;
        }
        if ((Object) this.ASExp_HaveCountText2 != (Object) null && ((Behaviour) this.ASExp_HaveCountText2).enabled)
        {
          ((Behaviour) this.ASExp_HaveCountText2).enabled = false;
          ((Behaviour) this.ASExp_HaveCountText2).enabled = true;
        }
        if ((Object) this.ASExp_BottomTipText != (Object) null && ((Behaviour) this.ASExp_BottomTipText).enabled)
        {
          ((Behaviour) this.ASExp_BottomTipText).enabled = false;
          ((Behaviour) this.ASExp_BottomTipText).enabled = true;
        }
        if ((Object) this.ASExp_SelectText != (Object) null && ((Behaviour) this.ASExp_SelectText).enabled)
        {
          ((Behaviour) this.ASExp_SelectText).enabled = false;
          ((Behaviour) this.ASExp_SelectText).enabled = true;
        }
        if ((Object) this.ASExp_NeedCountText1 != (Object) null && ((Behaviour) this.ASExp_NeedCountText1).enabled)
        {
          ((Behaviour) this.ASExp_NeedCountText1).enabled = false;
          ((Behaviour) this.ASExp_NeedCountText1).enabled = true;
        }
        if ((Object) this.ASExp_NeedCountText2 != (Object) null && ((Behaviour) this.ASExp_NeedCountText2).enabled)
        {
          ((Behaviour) this.ASExp_NeedCountText2).enabled = false;
          ((Behaviour) this.ASExp_NeedCountText2).enabled = true;
        }
        if ((Object) this.ASExp_UpText1 != (Object) null && ((Behaviour) this.ASExp_UpText1).enabled)
        {
          ((Behaviour) this.ASExp_UpText1).enabled = false;
          ((Behaviour) this.ASExp_UpText1).enabled = true;
        }
        if ((Object) this.ASExp_UpText2 != (Object) null && ((Behaviour) this.ASExp_UpText2).enabled)
        {
          ((Behaviour) this.ASExp_UpText2).enabled = false;
          ((Behaviour) this.ASExp_UpText2).enabled = true;
        }
        if ((Object) this.ASExp_MaxText != (Object) null && ((Behaviour) this.ASExp_MaxText).enabled)
        {
          ((Behaviour) this.ASExp_MaxText).enabled = false;
          ((Behaviour) this.ASExp_MaxText).enabled = true;
        }
        if ((Object) this.ASExp_TitleText != (Object) null && ((Behaviour) this.ASExp_TitleText).enabled)
        {
          ((Behaviour) this.ASExp_TitleText).enabled = false;
          ((Behaviour) this.ASExp_TitleText).enabled = true;
        }
        if ((Object) this.ASExp_InfoNowTitletext != (Object) null && ((Behaviour) this.ASExp_InfoNowTitletext).enabled)
        {
          ((Behaviour) this.ASExp_InfoNowTitletext).enabled = false;
          ((Behaviour) this.ASExp_InfoNowTitletext).enabled = true;
        }
        if ((Object) this.ASExp_InfoNextTitleText != (Object) null && ((Behaviour) this.ASExp_InfoNextTitleText).enabled)
        {
          ((Behaviour) this.ASExp_InfoNextTitleText).enabled = false;
          ((Behaviour) this.ASExp_InfoNextTitleText).enabled = true;
        }
        if ((Object) this.ASExp_InfoNowCDtext != (Object) null && ((Behaviour) this.ASExp_InfoNowCDtext).enabled)
        {
          ((Behaviour) this.ASExp_InfoNowCDtext).enabled = false;
          ((Behaviour) this.ASExp_InfoNowCDtext).enabled = true;
        }
        if ((Object) this.ASExp_InfoNextCDText != (Object) null && ((Behaviour) this.ASExp_InfoNextCDText).enabled)
        {
          ((Behaviour) this.ASExp_InfoNextCDText).enabled = false;
          ((Behaviour) this.ASExp_InfoNextCDText).enabled = true;
        }
        if ((Object) this.ASExp_EffExpText != (Object) null && ((Behaviour) this.ASExp_EffExpText).enabled)
        {
          ((Behaviour) this.ASExp_EffExpText).enabled = false;
          ((Behaviour) this.ASExp_EffExpText).enabled = true;
        }
        if (!((Object) this.ASExp_EffX2Text != (Object) null) || !((Behaviour) this.ASExp_EffX2Text).enabled)
          break;
        ((Behaviour) this.ASExp_EffX2Text).enabled = false;
        ((Behaviour) this.ASExp_EffX2Text).enabled = true;
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (this.bMaxShow)
      return;
    switch (arg1)
    {
      case 1:
        this.SetSkill();
        this.SetAddSkill_Item();
        this.CheckAddBtnState();
        break;
      case 2:
        this.SetSkill();
        this.SetAddSkill_Item();
        this.SetAddSkill_Info();
        this.CheckAddBtnState();
        break;
      case 5:
        this.SetBlood();
        this.SetPetInfo();
        break;
      case 6:
        if ((int) this.NowPet.ID != arg2)
          break;
        this.DestroyPet3D();
        this.LoadPet3D();
        this.SetBlood();
        this.SetPetInfo();
        this.SetSkill();
        this.ShowUpEffectPetID = this.NowPet.ID;
        break;
      case 7:
        this.SetParticle_Show(true, true);
        break;
      case 8:
        this.SetParticle_Show(false);
        break;
      case 9:
        this.ASExp_EffbLVUp = arg2 > 0;
        this.SetEffect(this.PM.PetUI_GetRate < (ushort) 2000 ? eUIPet_Eff.eEff_ExpAdd : eUIPet_Eff.eEff_ExpX2);
        this.SetAddSkill_Item();
        break;
      case 10:
        this.PM.Send_PET_STARUP_INSTANT((ushort) this.NowEvoID);
        this.HideEvoPanel();
        break;
      case 11:
        this.ShowEvoPanel();
        break;
    }
  }

  public override bool OnBackButtonClick()
  {
    if (this.SelectSkillIndex != -1)
    {
      this.HideAddSkillExpPanel();
      return true;
    }
    if (this.NowEvoID == -1)
      return false;
    this.HideEvoPanel();
    return true;
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      if (sender.m_BtnID2 == 1)
      {
        this.door.CloseMenu();
      }
      else
      {
        if (sender.m_BtnID2 != 2)
          return;
        this.door.OpenMenu(EGUIWindow.UI_Monster_Crypt_3, 1);
      }
    }
    else if (sender.m_BtnID1 == 2)
    {
      if (sender.m_BtnID2 == 1)
      {
        if (this.NowPet == null)
          return;
        uint needExp = this.PM.GetNeedExp(this.NowPet.Level, this.sPet.Rare);
        if (this.NowPet.CheckState(PetManager.EPetState.Evolution))
        {
          CString cstring = StringManager.Instance.StaticString1024();
          cstring.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.sPet.Name));
          cstring.AppendFormat(this.DM.mStringTable.GetStringByID(16040U));
          this.GM.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
        }
        else if (this.CheckMaxLv() && (int) this.NowPet.Exp == (int) needExp - 1)
        {
          this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(16082U), this.DM.mStringTable.GetStringByID(16069U), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 2, bCloseIDSet: true);
        }
        else
        {
          this.PM.PetUI_UseItemPetID = this.NowPet.ID;
          this.door.OpenMenu(EGUIWindow.UI_BagFilter, 4, 2);
        }
      }
      else if (sender.m_BtnID2 == 2)
      {
        this.GM.OpenMenu(EGUIWindow.UI_PetStoneTrans, (int) this.sPet.SoulID, bSecWindow: true);
      }
      else
      {
        if (sender.m_BtnID2 != 3)
          return;
        this.ShowEvoPanel();
      }
    }
    else if (sender.m_BtnID1 == 3)
      this.ShowAddSkillExpPanel(sender.m_BtnID3);
    else if (sender.m_BtnID1 == 4)
    {
      if (sender.m_BtnID2 == 1)
      {
        --this.PM.PetUI_PetSortIndex;
        if (this.PM.PetUI_PetSortIndex < 0)
          this.PM.PetUI_PetSortIndex = (int) this.PM.PetDataCount - 1;
      }
      else if (sender.m_BtnID2 == 2)
      {
        ++this.PM.PetUI_PetSortIndex;
        if (this.PM.PetUI_PetSortIndex >= (int) this.PM.PetDataCount)
          this.PM.PetUI_PetSortIndex = 0;
      }
      PetData petData = this.PM.GetPetData((int) this.PM.sortPetData[this.PM.PetUI_PetSortIndex]);
      if (petData == null)
        return;
      this.PM.PetUI_PetID = (int) petData.ID;
      this.SetNowPet();
    }
    else if (sender.m_BtnID1 == 5)
    {
      if ((!((Object) this.tmpAN != (Object) null) || this.tmpAN.IsPlaying(this.PetAct)) && !(this.PetAct == "idle"))
        return;
      this.HeroActionChang(true);
    }
    else if (sender.m_BtnID1 == 6)
    {
      if (sender.m_BtnID2 == 1)
        this.HideAddSkillExpPanel();
      else if (sender.m_BtnID2 == 2)
      {
        if (this.ASExp_InfoStr == null)
          this.ASExp_InfoStr = StringManager.Instance.SpawnString(1024);
        this.ASExp_InfoStr.Length = 0;
        CString tmpS = StringManager.Instance.StaticString1024();
        tmpS.IntToFormat((long) GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Hour, 2);
        tmpS.IntToFormat((long) GameConstants.GetDateTime(this.DM.RoleAttr.FirstTimer).Minute, 2);
        tmpS.AppendFormat("{0}:{1}");
        this.ASExp_InfoStr.StringToFormat(tmpS);
        this.ASExp_InfoStr.AppendFormat(this.DM.mStringTable.GetStringByID(12128U));
        this.GM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(12127U), this.ASExp_InfoStr.ToString(), bInfo: true, BackExit: true);
      }
      else if (sender.m_BtnID2 == 3)
      {
        if (this.NowPet == null || this.SelectSkillIndex < 0 || this.SelectSkillIndex >= 4)
          return;
        PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[this.SelectSkillIndex]);
        PetSkillHint.eKind kind = PetSkillHint.eKind.MaxLv;
        if ((int) this.NowPet.SkillLv[this.SelectSkillIndex] >= (int) recordByKey.UpLevel)
          kind = PetSkillHint.eKind.Normal;
        this.GM.m_Hint.ShowPetHint(this.ASExp_SkillMaxHint, kind, this.sPet.ID, this.sPet.PetSkill[this.SelectSkillIndex], this.NowPet.SkillLv[this.SelectSkillIndex], Vector2.zero);
      }
      else if (sender.m_BtnID2 == 5)
      {
        if ((double) this.ClickAddSkillTime >= 0.0)
          return;
        this.ClickAddSkillTime = 0.0f;
        if (this.bLevel)
          this.ShowSkillUpbLevel();
        else if (this.bCount1)
        {
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12132U), (ushort) 35);
        }
        else
        {
          if (this.ASExp_EffectKind != eUIPet_Eff.eEff_None)
          {
            if (this.EndEffect())
              return;
            if (this.bLevel)
              this.ShowSkillUpbLevel();
            else if (this.bCount1)
              this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12132U), (ushort) 35);
          }
          if (this.bLevel || this.bCount1)
            return;
          this.CheckUpgradeSkill((byte) 0);
        }
      }
      else if (sender.m_BtnID2 == 4)
      {
        if ((double) this.ClickAddSkillTime >= 0.0)
          return;
        this.ClickAddSkillTime = 0.0f;
        if (this.bLevel)
          this.ShowSkillUpbLevel();
        else if (this.bCount2)
        {
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12138U), (ushort) 35);
        }
        else
        {
          if (this.ASExp_EffectKind != eUIPet_Eff.eEff_None)
          {
            if (this.EndEffect())
              return;
            if (this.bLevel)
              this.ShowSkillUpbLevel();
            else if (this.bCount2)
              this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12138U), (ushort) 35);
          }
          if (this.bLevel || this.bCount2)
            return;
          this.CheckUpgradeSkill((byte) 1);
        }
      }
      else if (sender.m_BtnID2 == 6)
      {
        this.OpenSrcHint((byte) 2);
      }
      else
      {
        if (sender.m_BtnID2 != 7)
          return;
        if (this.ASExp_LockSP.m_SpriteIndex == 1)
        {
          CString Content = StringManager.Instance.StaticString1024();
          PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[this.SelectSkillIndex]);
          if (this.SelectSkillIndex != -1 && this.NowPet.SkillLv[this.SelectSkillIndex] > (byte) 0 && (int) this.NowPet.SkillLv[this.SelectSkillIndex] <= recordByKey.OpenLevel.Length)
            Content.IntToFormat((long) recordByKey.OpenLevel[(int) this.NowPet.SkillLv[this.SelectSkillIndex] - 1]);
          else
            Content.IntToFormat(0L);
          Content.AppendFormat(this.DM.mStringTable.GetStringByID(12124U));
          this.GM.m_Hint.Show(this.ASExp_LockHint, UIHintStyle.eHintSimple, (byte) 0, 350f, 20, Content, Vector2.zero);
        }
        else
          this.ShowSkillUpbLevel();
      }
    }
    else
    {
      if (sender.m_BtnID1 != 7)
        return;
      if (sender.m_BtnID2 == 1)
        this.HideEvoPanel();
      else if (sender.m_BtnID2 == 2 || sender.m_BtnID2 == 3)
      {
        if (!this.CheckEvoItem())
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(16034U), (ushort) 35);
        else if (!this.CheckEvoLv())
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(16054U), (ushort) 35);
        else if (this.PM.PetUI_EvoID != (ushort) 0)
        {
          this.GM.OpenOKCancelBox((GUIWindow) this, (string) null, this.DM.mStringTable.GetStringByID(16057U), 1);
        }
        else
        {
          if (sender.m_BtnID2 == 2)
          {
            uint resourceExchange = this.DM.GetResourceExchange(PriceListType.Time, this.PM.GetEvoNeed_Time(this.NowPet.Enhance));
            if (this.NowPet != null && this.DM.RoleAttr.Diamond < resourceExchange)
            {
              this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966U), this.DM.mStringTable.GetStringByID(646U), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 3, bCloseIDSet: true);
              return;
            }
            if (GUIManager.Instance.OpenCheckCrystal(resourceExchange, (byte) 10))
              return;
            this.PM.Send_PET_STARUP_INSTANT((ushort) this.NowEvoID);
          }
          else
            this.PM.Send_PET_STARUP((ushort) this.NowEvoID);
          this.HideEvoPanel();
        }
      }
      else
      {
        if (sender.m_BtnID2 != 4)
          return;
        this.OpenSrcHint((byte) 1);
      }
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    bool flag = true;
    if (sender.Parm2 != (byte) 2)
    {
      if (sender.Parm2 == (byte) 3)
      {
        if (this.bMaxShow)
        {
          PetSkillTbl recordByKey = this.PM.PetSkillTable.GetRecordByKey(this.sPet.PetSkill[(int) sender.Parm1]);
          this.GM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Lv1AndMax, this.sPet.ID, this.sPet.PetSkill[(int) sender.Parm1], recordByKey.UpLevel, new Vector2(-360f, 0.0f));
        }
        else
          this.GM.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Normal, this.sPet.ID, this.sPet.PetSkill[(int) sender.Parm1], this.NowPet.SkillLv[(int) sender.Parm1], new Vector2(-360f, 0.0f));
      }
      else if (sender.Parm2 == (byte) 4)
        flag = false;
      else if (sender.Parm2 == (byte) 5)
        this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 250f, 20, (int) sender.Parm1, 0, Vector2.zero);
      else if (sender.Parm2 == (byte) 6)
        this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 400f, 20, (int) sender.Parm1, 0, Vector2.zero);
      else if (sender.Parm2 == (byte) 7)
        this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 350f, 20, (int) sender.Parm1, 0, new Vector2(-60f, -80f));
      else if (sender.Parm2 == (byte) 8)
      {
        if (this.bMaxShow || this.NowPet != null && this.NowPet.Enhance == (byte) 2)
        {
          this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 350f, 20, 16088, 0, Vector2.zero);
        }
        else
        {
          CString Content = StringManager.Instance.StaticString1024();
          Content.IntToFormat((long) this.PM.GetEvoNeed_Stone(this.NowPet.Enhance, this.sPet.Rare));
          Content.AppendFormat(this.DM.mStringTable.GetStringByID(16087U));
          this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 350f, 20, Content, Vector2.zero);
        }
      }
      else
        this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 350f, 20, (int) sender.Parm1, 0, Vector2.zero);
    }
    if (!flag)
      return;
    AudioManager.Instance.PlayUISFX();
  }

  public void OnButtonUp(UIButtonHint sender) => this.GM.m_Hint.Hide(true);

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    if (!(bool) (Object) this.door)
      return;
    img.sprite = this.door.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = this.door.LoadMaterial();
  }

  public void OnTimer(UITimeBar sender)
  {
  }

  public void OnNotify(UITimeBar sender)
  {
    this.GM.SetTimerSpriteType(sender, this.DM.GetQueueBarSpriteType(EQueueBarIndex.PetEvolution));
  }

  public void Onfunc(UITimeBar sender)
  {
    switch (DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.PetEvolution))
    {
      case eTimerSpriteType.Speed:
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 35);
        break;
      case eTimerSpriteType.Free:
        this.PM.Send_PET_STARUP_FREECOMPLETE();
        break;
    }
  }

  public void OnCancel(UITimeBar sender) => this.PM.Send_PET_STARUP_CANCEL();

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 1:
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 35);
        break;
      case 2:
        this.ShowEvoPanel();
        break;
      case 3:
        MallManager.Instance.Send_Mall_Info();
        break;
      case 4:
        this.SendUpgradeSkill((byte) arg2);
        break;
      case 5:
        this.HideAddSkillExpPanel();
        this.ShowEvoPanel();
        break;
      case 6:
        this.HideAddSkillExpPanel();
        this.PM.PetUI_UseItemPetID = this.NowPet.ID;
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, 4, 2);
        break;
    }
  }
}
