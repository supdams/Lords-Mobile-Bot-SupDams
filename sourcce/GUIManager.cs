// Decompiled with JetBrains decompiler
// Type: GUIManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using uTools;

#nullable disable
public class GUIManager : IPagemove, UILoadImageHander, IUIButtonClickHandler
{
  public const float UILockMaxTime = 1f;
  public const float UILockHalftime = 0.5f;
  private const byte ChannelCount = 2;
  private const int LanguageMax = 2;
  private const int BackMGCount = 5;
  private const int BackMG_TitleLen = 241;
  private const int BackMG_MessageLen = 1025;
  private const float m_BBTotalTime = 0.1f;
  private const float m_BBWaitTotalTime = 1f;
  private const float m_BBFadeOutTotalTime = 1f;
  public const int NPCMessageID = 9591;
  public const int NPCErrorMessageID = 9592;
  public const byte MAX_NPCCITY_REWARD = 3;
  public const byte SaveEmojiKeyCount = 8;
  public static Vector2 ResolutionSize = new Vector2(853f, 640f);
  private static GUIManager instance;
  private long m_LastServerTime;
  private int Key;
  private bool m_bLoadAsset;
  private bool bRebuildFont;
  private Font m_TTFFont;
  private AssetBundle m_TTFFontBundle;
  private Dictionary<int, SpriteAsset> m_SpriteAssetDict;
  public IconSpriteAsset m_IconSpriteAsset;
  public IconSpriteAsset m_ItemIconSpriteAsset;
  public IconSpriteAsset m_LeadItemIconSpriteAsset;
  public IconSpriteAsset m_LeadMatIconSpriteAsset;
  public IconSpriteAsset m_ConditiontIconSpriteAsset;
  private int currentIconCount;
  private IconSpriteAsset[] m_FastivalIconSpriteAssets = new IconSpriteAsset[5];
  private Dictionary<byte, int> m_FastivalIconSet;
  private Sprite[] m_WondersiconSprite;
  private int WondericonAssKey;
  private Sprite _NpcHead;
  private Material _m_WonderMaterial;
  public SpriteAsset m_BadgeSpriteAsset;
  public SpriteAsset m_TotemSpriteAsset;
  public SpriteAsset m_SkillSpriteAsset;
  public SpriteAsset m_AllianceBoxAsset;
  public SpriteAsset m_LeagueGO_iconAsset;
  public SpriteAsset m_EmojiSpriteAsset;
  public SpriteAsset m_TitleSpriteAsset;
  private SpriteAsset m_FrameSpriteAsset;
  public AssetBundle m_ManagerAssetBundle;
  public AssetBundle m_ManagerAssetBundle2;
  private int m_ManagerAssetBundleKey;
  private int m_ManagerAssetBundleKey2;
  public AssetBundle m_EffectAssetBundle;
  private int m_EffectAssetBundleKey;
  public CString LoadSpriteStr = new CString(512);
  public Canvas m_UICanvas;
  public bool m_Orthographic;
  public byte m_OrthographicCount;
  private GUIWindow[] m_WindowList;
  public GUIWindow m_Window1;
  public GUIWindow m_Window2;
  public GUIWindow m_SecWindow;
  public GUIWindow m_OtheCanvas;
  private GameObject GoSubCam;
  private GameObject GoSubCanvas;
  public GUIWindow Chatwin;
  private int ChatabKey;
  private AssetBundle Chatab;
  public GameObject m_Chat;
  private EUIOriginMode window2mode;
  public RectTransform m_BottomLayer;
  public RectTransform m_WindowsTransform;
  public RectTransform m_ChatLayer;
  public RectTransform m_TopLayer;
  public RectTransform m_WindowTopLayer;
  public RectTransform m_ItemInfoLayer;
  public RectTransform m_BattleMessageLayer;
  public RectTransform m_SecWindowLayer;
  public RectTransform m_FourthWindowLayer;
  public RectTransform m_NewbieLayer;
  public RectTransform m_MessageBoxLayer;
  public RectTransform m_OtherCanvasLayer;
  public RectTransform m_OtherCanvasTransform;
  private GameObject m_OKCancelBox;
  private UIButton m_OKCancelCloseButton;
  private GUIWindow m_OKCancelBoxHandler;
  private CString m_OKString;
  private CString m_OKString2;
  private CString m_OKString_ItemCount;
  private CString m_OKString_Info;
  private int m_OKCancelBoxArg1;
  private int m_OKCancelBoxArg2;
  private int m_OKCancelClickIndex = -1;
  private UseOrSpendType useOrSpendType = UseOrSpendType.UST_MAX;
  public UIItemInfo m_ItemInfo = new UIItemInfo();
  public UISimpleItemInfo m_SimpleItemInfo = new UISimpleItemInfo();
  public UISkillInfo m_SkillInfo = new UISkillInfo();
  public UILordItemInfo m_LordInfo = new UILordItemInfo();
  public UIHintMask HintMaskObj = new UIHintMask();
  public AssetBundle m_Arena_HintAssetBundle;
  private int m_Arena_HintAssetBundleKey;
  public UIArena_Hint m_Arena_Hint = new UIArena_Hint();
  public UIHint m_Hint = new UIHint();
  public SpeciallyEffect m_SpeciallyEffect = new SpeciallyEffect();
  public int TmpCount;
  public Vector2 mStartV2 = Vector2.zero;
  public SpeciallyEffect_Kind[] SE_Kind = new SpeciallyEffect_Kind[7];
  public uint[] SE_Stock = new uint[5];
  public ushort[] SE_ItemID = new ushort[3];
  public byte[] SE_Item_L_Color = new byte[3];
  public AssetBundle m_CalculatorAssetBundle;
  private int m_CalculatorAssetBundleKey;
  public UICalculator m_UICalculator = new UICalculator();
  public GameObject Obj_UICalculator;
  public CString m_CalculatorStr;
  public RectTransform m_LockPanelLayer;
  private RectTransform m_LockPanel;
  private EUILock m_eUILock;
  private byte m_UILockCount;
  private float m_UILockTime;
  public RectTransform m_HUDsTransform;
  public HUDMessageMgr m_HUDMessage;
  public DamageValueManager pDVMgr;
  private Color ABColor = Color.white;
  private Color MyColor = new Color(0.2f, 0.2f, 0.2f, 1f);
  private float TimeBarTitleWidth;
  public bool bCheckDeleteMsg = true;
  public bool bCheckStoneTrans = true;
  public bool bOpenOnIPhoneX;
  public float IPhoneX_DeltaX = 53f;
  public int OpenBoxCount;
  public uint CommonGetCrystal;
  public uint CommonGetAllianceCoin;
  public List<CommonItemDataType> CommonItemData = new List<CommonItemDataType>();
  public bool m_OpenResourceMenu;
  public uint[] m_SendResource = new uint[5];
  public uint[] m_SaveResource = new uint[5];
  public GameObject m_BMGO;
  public Transform m_BMContentT;
  public Transform m_BMButtonT;
  private UIText m_BMBtnText;
  private UIText m_BMText1;
  private UIText m_BMText2;
  public int m_BMAssetBundleKey;
  public uint BattleSerialNo;
  public uint SerialNo;
  private CString m_BMATStr;
  private CString m_BMNStr;
  private CString m_BMMessage1;
  private GUIManager.ECombatLiveType m_BMNowLiveType;
  private POINT_KIND m_BMNowPointKind;
  private ushort m_BMNowKingdomID;
  private float m_BMTime = -1f;
  private bool bSendShow;
  private bool bGPShow = true;
  private bool bWarAttacker;
  private bool bInFightHideChat;
  private Image m_BMLight;
  private float m_BMLightTime;
  private float m_BMLightMaxTime = 1f;
  public ushort WM_RandomSeed;
  public byte WM_RandomGap;
  public byte WM_Combo;
  public HeroBattleData[] WM_HeroData = new HeroBattleData[5];
  public byte WM_HeroCount;
  public ushort WM_MonsterID;
  public byte WM_MonsterLv;
  public uint WM_MonsterNowHP;
  public uint WM_MonsterMaxHP;
  public MonsterAttrDataType WM_MonsterAttr = new MonsterAttrDataType();
  public CString WM_MonsterTagStr = new CString(4);
  public byte WM_NPCLevel;
  public int RandomIndex = -1;
  public RectTransform m_ChatBox;
  public RectTransform m_ChatScrollRectRC;
  public CScrollRect m_ChatScrollRect;
  private Transform m_ChatContentT;
  private Mask m_ChatMask;
  public Image m_ChatImage;
  private Sprite ChannelSpriteOn;
  private Sprite ChannelSpriteOff;
  public Image m_ChatChannelLight;
  public Image m_ChatChannelLight1;
  public Image m_ChatChannelLight2;
  private GameObject m_ChannelLightFlashGO;
  public byte ChannelIndex;
  private ChatChannel[] m_ChatChannel = new ChatChannel[2];
  private UIText NoAllianceText;
  public GameObject m_ChatBoxGO;
  private int m_ChatBoxAssetKey;
  public int PreLeadLevel = -1;
  public bool bOpenHeroBtn;
  public bool bOpenAllianceBtn;
  public bool bNeedForceOpenFuncBtn;
  private GameObject m_LvUpGO;
  private int m_LvUpAssetBundleKey;
  private GameObject m_BackMGGO;
  private int m_BackMGAssetBundleKey;
  private long m_BackMGBeginTime;
  private long m_BackMGEndTime;
  private uint m_BackMGDeltaTime;
  private CString m_BackMGTitle = new CString(242);
  private CString m_BackMGMessage = new CString(1026);
  private bool m_BackMGWaitOpen;
  private byte m_SystemInChatIndex;
  private BackMG[] m_SystemInChat = new BackMG[5];
  private byte m_RunningTextIndex;
  private BackMG[] m_RunningText = new BackMG[5];
  public List<CString> m_RunningTextList = new List<CString>();
  public CExternalTableWithWordKey<LoadingTalk> LoadingTalkTable;
  public GUIWindow LTWin;
  public GUIWindow TBoxWin;
  private GameObject m_BattleBeginGO;
  private RectTransform m_LeftRC;
  private RectTransform m_RightRC;
  private CanvasGroup m_BBCanvasGroup;
  private UIText[] m_bbText = new UIText[6];
  private CString[] m_bbCString = new CString[3];
  private int m_BattleBeginAssetBundleKey;
  private float m_BBDeltaTime;
  private GUIManager.eBBSetp m_BBStep = GUIManager.eBBSetp.eMax;
  private bool bShowWonder;
  private long NowBeginTime;
  private long ShowRunningTime;
  public TimeEventDataType WonderCountTime;
  public List<CString> WonderCountStr = new List<CString>();
  private long KOW_ShowRunningTime;
  public List<CString> KOWCountStr = new List<CString>();
  private long NW_ShowRunningTime;
  public long TranslateID = -1;
  public string TranslateStr;
  public TalkDataType TranslateData;
  public List<long> TranslateStrListID = new List<long>();
  public List<TalkDataType> TranslateDataList = new List<TalkDataType>();
  public List<CString> TranslateCStrList = new List<CString>();
  public List<long> MB_TranslateStrListID = new List<long>();
  public List<MessageBoard> MB_TranslateDataList = new List<MessageBoard>();
  public List<CString> MB_TranslateCStrList = new List<CString>();
  public bool bWaitTranslate;
  public bool bWaitTranslate_MB;
  public bool bBackTranslate;
  public bool bBackTranslateBatch;
  public bool bBackTranslateBatch_MB;
  public byte bBackTranslateFail;
  public byte bBackTranslateFail_MB;
  private GameObject m_CheckCrystalBox;
  private UIButton m_CheckCrystalButton;
  private UIButton m_CheckCrystalCloseButton;
  private bool bCheckCrystal;
  private uint tmpCheckCrystal;
  private UIText[] CheckCrystalText = new UIText[5];
  private CustomImage CheckCrystalImg;
  private CString CheckCrystalStr;
  private byte CheckCrystalKind;
  public int CheckCrystalPara1 = -1;
  public int CheckCrystalPara2 = -1;
  public ushort[] BoxID = new ushort[3];
  public long[] BoxTime = new long[3];
  public ushort[] BoxRequire = new ushort[3];
  public uint TrueBoxRequire;
  public bool[] BoxBShowMessage = new bool[3];
  public ushort BoxRewardID;
  public ushort BoxRewardItemID;
  public byte BoxRewardItemRank;
  public ushort BoxRewardNum;
  public uint BoxRewardCrystal;
  public uint BoxRewardAlliance;
  public long NPCCityBonusTime;
  public ushort UIPointID;
  public byte UINodus;
  public ushort EmojiNowPackageIndex = ushort.MaxValue;
  public ushort EmojiNowPicIndex;
  public int EmojiNowScrollIndex = -1;
  public float EmojiNowContentPos;
  private Dictionary<ushort, byte> MapEmojiCount;
  public long[] EmojiFlag = new long[8];
  public byte EmojiOpenType;
  public SortEmojiComparer EmojiDataComparer = new SortEmojiComparer();
  public List<ushort> EmojiIndex = new List<ushort>();
  public bool bLoadEmojiSaveKey;
  public List<ushort> SaveEmojiKey = new List<ushort>(8);
  public string[] SaveEmojiName = new string[8]
  {
    "SaveEmojiKey_1",
    "SaveEmojiKey_2",
    "SaveEmojiKey_3",
    "SaveEmojiKey_4",
    "SaveEmojiKey_5",
    "SaveEmojiKey_6",
    "SaveEmojiKey_7",
    "SaveEmojiKey_8"
  };
  public ActivityWindow m_ActivityWindow;
  public Dictionary<int, Sprite> MapIconDict = new Dictionary<int, Sprite>();
  public Material MapSpriteMaterial;
  public Material MapSpriteUIMaterial;
  private int MapSpriteKey;
  public BuildsData BuildingData;
  public ushort BuildGuildQueue;
  public byte[] BagTagSaved = new byte[10];
  public byte[] ResourceFilterSaved = new byte[37];
  public byte HeroListSaved;
  public byte[] TechKindSaved = new byte[5];
  public byte[] TechSaved = new byte[8];
  public byte[] BookMarkSaved = new byte[8];
  public byte[] TalentSaved = new byte[7];
  public byte[] RallySaved = new byte[5];
  public byte MissionSaved;
  public byte[] TalentSaveSaved = new byte[5];
  public byte[] CastleSkinSaved = new byte[6];
  public CString SendTag;
  public CString SendName;
  public bool bContinuousUse;
  public byte MarshalSaved;
  public byte GuideParm1;
  public ushort GuideParm2;
  private RectTransform ArrowRect;
  private RectTransform ArrowParentRect;
  private uTweenPosition ArrowPos;
  private byte UpdateArrow;
  public List<UITimeBar> m_TimeBarList;
  public int m_UISynthesisAbKey;
  public UISynthesis m_UISynthesis;
  public bool m_IsOpenedUISynthesis;
  public ushort m_UISynthesisID;
  public List<ushort> m_SynthesisItemData;
  public e_SynPageType m_SynthesisPageType;
  public ushort m_SynthesisItemIdx;
  public float m_SynthesisScrollRectY;
  public int m_SynthesisScrollIdx;
  public LevelTableKind m_SynthesisBtnType = LevelTableKind.NormalStage;
  public ushort[] m_RequirementNum = new ushort[5];
  public ushort[] m_SynthesisItemNum = new ushort[5];
  public int[] m_AttackedAlertCount;
  public int m_AttackedAlertTCount;
  public int m_AlertImageIndex = 2;
  public UISpritesArray AlertImageSA;
  private bool bAddAlertImageAlpha;
  public int m_TroopsCount;
  public int UIHero_Index = -1;
  public float UIBarrack_Y = -1f;
  public float UIBarrack_TrapY = -1f;
  public int UIPreviewHero_Index = -1;
  public StringBuilder tmpString = new StringBuilder();
  public List<UIText> m_MsgText = new List<UIText>(10);
  public CString MsgStr;
  public CString MsgTitleStr;
  public CString MsgBtnStr;
  public CString MsgBarStr = new CString(10);
  public UIText MsgBarTimeText;
  public CustomImage MsgBarImage;
  public float MsgBarTimeSec;
  public float MaxBarTimeSec;
  public List<GUIWindowStackData> m_WindowStack = new List<GUIWindowStackData>(10);
  public bool bClearWindowStack = true;
  public bool bOpenNeedClose;
  public ObjectPool<BuildInfoObject> upgradePanelDataPool;
  public ObjectPool<BuildInfoObject2> upgradeEffectDataPool;
  public ObjectPool<HeroList_Soldier_Item> m_HeroList_Soldier_ItemDataPool;
  public ObjectPool<SoldierScrollItem> m_HeroList_Soldier_ItemDataPool2;
  public bool bButnUpReturn;
  private List<GUIQueueOpen> GUIQueue = new List<GUIQueueOpen>(4);
  private int mUIQueueLock;
  public CString m_ResourceTransportStr;
  public List<sHeroLvUp> m_HerodLvUpData = new List<sHeroLvUp>();
  public bool bOpenHeroLvUp;
  private string[] SpentCreditsStr = new string[15]
  {
    "Item",
    "Technology",
    "FixWallImmediate",
    "BuildImmediate",
    "BuildFinish",
    "DismentleImmediate",
    "eDismentleFinish",
    "eMission",
    "HeroEnhance",
    "HeroStarUp",
    "Immediately",
    "AllianceModifyEmblem",
    "Instanthealing",
    "InstantCraftLordEquip",
    "eCraftLordEquipInstantFinish"
  };
  public int AllianceListTopIdx;
  public float AllienceListContentY;
  public bool[] AllienceListGroupOpen = new bool[5]
  {
    true,
    true,
    true,
    true,
    true
  };
  public float m_BeginChangeTime = 3f;
  public float m_ChangeTime;
  public float m_FlashCount;
  public int m_TextIdx;
  public int Barrack_Soldier_Lock = 2;
  public long Barrack_Soldier_SliderValue;
  public CString CanonizedName;
  public bool bBackInPreviewModel;
  public float BackInPreviewHight;
  public bool bCheckAWSSchedule = true;
  public int m_BuildingTopIdx;
  public float m_BuildingPosY;
  public EmojiCenter EmojiManager;
  public Vector2 mNewCenterPos = Vector2.zero;
  public bool bShowLive;
  public byte StopShowLiveScale;
  public float m_LEBtn_SharedAlpha = 1f;
  public List<UILEBtn> m_LEBTN_updateList = new List<UILEBtn>();
  private UISpritesArray TechIconArray;
  private UISpritesArray TechIconArrayCN;
  private Material _TechMaterial;
  private AssetBundleRequest TechABRequest;
  private EGUIWindow _TechUpdateUI;
  private int TechIconKey;

  private GUIManager()
  {
    GameObject target1 = new GameObject("EventSystem");
    UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object) target1);
    target1.AddComponent<EventSystem>();
    target1.AddComponent<CusStandaloneInputModule>();
    target1.AddComponent<CusTouchInputModule>();
    GameObject target2 = new GameObject("Canvas");
    UnityEngine.Object.DontDestroyOnLoad((UnityEngine.Object) target2);
    target2.layer = 5;
    this.m_UICanvas = target2.AddComponent<Canvas>();
    this.m_UICanvas.renderMode = (RenderMode) 0;
    target2.AddComponent<GraphicRaycaster>();
    CanvasScaler canvasScaler = target2.AddComponent<CanvasScaler>();
    canvasScaler.uiScaleMode = (CanvasScaler.ScaleMode) 1;
    canvasScaler.referenceResolution = GUIManager.ResolutionSize;
    canvasScaler.matchWidthOrHeight = 1f;
    this.m_UICanvas.worldCamera = Camera.main;
    this.m_UICanvas.planeDistance = 16f;
    this.m_BottomLayer = new GameObject("BottomLayer")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.m_BottomLayer).SetParent(((Component) this.m_UICanvas).transform, false);
    this.StretchTransform(this.m_BottomLayer);
    this.pDVMgr = new DamageValueManager((Transform) this.m_BottomLayer);
    this.m_WindowsTransform = new GameObject("Windows")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.m_WindowsTransform).SetParent(((Component) this.m_UICanvas).transform, false);
    this.StretchTransform(this.m_WindowsTransform);
    this.m_WindowList = new GUIWindow[187];
    if (this.IsArabic)
      ((Transform) this.m_WindowsTransform).localScale = new Vector3(-((Transform) this.m_WindowsTransform).localScale.x, ((Transform) this.m_WindowsTransform).localScale.y, ((Transform) this.m_WindowsTransform).localScale.z);
    this.m_ChatLayer = new GameObject("ChatLayer")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.m_ChatLayer).SetParent(((Component) this.m_UICanvas).transform, false);
    this.StretchTransform(this.m_ChatLayer);
    if (this.IsArabic)
      ((Transform) this.m_ChatLayer).localScale = new Vector3(-((Transform) this.m_ChatLayer).localScale.x, ((Transform) this.m_ChatLayer).localScale.y, ((Transform) this.m_ChatLayer).localScale.z);
    this.m_TopLayer = new GameObject("TopLayer")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.m_TopLayer).SetParent(((Component) this.m_UICanvas).transform, false);
    this.StretchTransform(this.m_TopLayer);
    if (this.IsArabic)
      ((Transform) this.m_TopLayer).localScale = new Vector3(-((Transform) this.m_TopLayer).localScale.x, ((Transform) this.m_TopLayer).localScale.y, ((Transform) this.m_TopLayer).localScale.z);
    this.m_WindowTopLayer = new GameObject("WindowTopLayer")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.m_WindowTopLayer).SetParent((Transform) this.m_TopLayer, false);
    this.StretchTransform(this.m_WindowTopLayer);
    this.m_ItemInfoLayer = new GameObject("ItemInfoLayer")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.m_ItemInfoLayer).SetParent((Transform) this.m_TopLayer, false);
    this.StretchTransform(this.m_ItemInfoLayer);
    this.m_BattleMessageLayer = new GameObject("BattleMessageLayer")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.m_BattleMessageLayer).SetParent((Transform) this.m_WindowTopLayer, false);
    this.StretchTransform(this.m_BattleMessageLayer);
    this.m_SecWindowLayer = new GameObject("SecWindowLayer")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.m_SecWindowLayer).SetParent((Transform) this.m_WindowTopLayer, false);
    this.StretchTransform(this.m_SecWindowLayer);
    this.m_FourthWindowLayer = new GameObject("FourthWindowLayer")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.m_FourthWindowLayer).SetParent((Transform) this.m_TopLayer, false);
    this.StretchTransform(this.m_FourthWindowLayer);
    this.m_NewbieLayer = new GameObject("NewbieLayer")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.m_NewbieLayer).SetParent((Transform) this.m_TopLayer, false);
    this.StretchTransform(this.m_NewbieLayer);
    this.m_MessageBoxLayer = new GameObject("MessageBoxLayer")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.m_MessageBoxLayer).SetParent((Transform) this.m_TopLayer, false);
    this.StretchTransform(this.m_MessageBoxLayer);
    this.m_HUDsTransform = new GameObject("HUDs")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.m_HUDsTransform).SetParent((Transform) this.m_TopLayer, false);
    this.StretchTransform(this.m_HUDsTransform);
    this.pDVMgr.SetTransitionLayer((Transform) this.m_TopLayer);
    this.m_LockPanelLayer = new GameObject("LockPanelLayer")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.m_LockPanelLayer).SetParent((Transform) this.m_TopLayer, false);
    this.StretchTransform(this.m_LockPanelLayer);
    this.m_HUDMessage = new HUDMessageMgr();
    this.BuildingData = new BuildsData();
    this.m_TimeBarList = new List<UITimeBar>();
    this.m_AttackedAlertCount = new int[15];
    this.m_AttackedAlertTCount = 0;
    this.MsgStr = new CString(1024);
    this.MsgTitleStr = StringManager.Instance.SpawnString(300);
    this.MsgBtnStr = StringManager.Instance.SpawnString(150);
    this.InitSynthesisUISaveData();
    this.upgradePanelDataPool = new ObjectPool<BuildInfoObject>(new BuildInfoObject(), 20);
    this.upgradeEffectDataPool = new ObjectPool<BuildInfoObject2>(new BuildInfoObject2(), 6);
    this.m_HeroList_Soldier_ItemDataPool = new ObjectPool<HeroList_Soldier_Item>(new HeroList_Soldier_Item(), (DataManager.Instance.MaxCurHeroData + 2) * 5);
    this.m_HeroList_Soldier_ItemDataPool2 = new ObjectPool<SoldierScrollItem>(new SoldierScrollItem(), 102);
    for (int index = 0; index < 5; ++index)
      this.WM_HeroData[index] = new HeroBattleData();
    this.InitialBackMessageBox();
    this.SendTag = new CString(3);
    this.SendName = new CString(13);
    this.CanonizedName = StringManager.Instance.SpawnString();
    this.m_BuildingTopIdx = 0;
    this.m_BuildingPosY = 0.0f;
    this.EmojiManager = new EmojiCenter();
  }

  public static GUIManager Instance
  {
    get
    {
      if (GUIManager.instance == null)
        GUIManager.instance = new GUIManager();
      return GUIManager.instance;
    }
  }

  public Sprite NpcHead
  {
    get
    {
      if (this.WondericonAssKey == 0)
        this.InitWondersSprite();
      return this._NpcHead;
    }
  }

  public Material m_WonderMaterial
  {
    get
    {
      if (this.WondericonAssKey == 0)
        this.InitWondersSprite();
      return this._m_WonderMaterial;
    }
  }

  public bool bAutoTranslate
  {
    get
    {
      return IGGGameSDK.Instance.GetTranslateStatus() && DataManager.Instance.MySysSetting.bAutoTranslate;
    }
  }

  public bool IsArabic => DataManager.Instance.UserLanguage == GameLanguage.GL_Arb;

  public void Update()
  {
    if (this.bRebuildFont)
    {
      this.bRebuildFont = false;
      GameManager.OnRefresh(NetworkNews.Refresh_FontTextureRebuilt);
      if ((UnityEngine.Object) this.LTWin != (UnityEngine.Object) null)
        this.LTWin.UpdateUI(10, 0);
    }
    this.UpDateCanvas();
    this.m_HUDMessage.Update();
    if (!this.m_bLoadAsset)
      return;
    if (this.m_eUILock != EUILock.Normal)
    {
      float uiLockTime = this.m_UILockTime;
      this.m_UILockTime += Time.deltaTime;
      if ((double) this.m_UILockTime >= 0.5)
      {
        int num1 = (int) (((double) uiLockTime - 0.5) * 10.0);
        int num2 = (int) (((double) this.m_UILockTime - 0.5) * 10.0);
        if ((double) uiLockTime < 0.5)
        {
          for (int index = 0; index < ((Transform) this.m_LockPanel).childCount; ++index)
            ((Transform) this.m_LockPanel).GetChild(index).gameObject.SetActive(true);
        }
        else if (num1 != num2)
        {
          RectTransform child1 = (RectTransform) ((Transform) this.m_LockPanel).GetChild(((Component) this.m_LockPanel).transform.childCount - 1);
          Vector2 vector2 = child1.anchoredPosition;
          Quaternion quaternion = ((Transform) child1).localRotation;
          for (int index = 0; index < ((Transform) this.m_LockPanel).childCount; ++index)
          {
            RectTransform child2 = (RectTransform) ((Transform) this.m_LockPanel).GetChild(index);
            Vector2 anchoredPosition = child2.anchoredPosition;
            child2.anchoredPosition = vector2;
            vector2 = anchoredPosition;
            Quaternion localRotation = ((Transform) child2).localRotation;
            ((Transform) child2).localRotation = quaternion;
            quaternion = localRotation;
          }
        }
      }
      if ((double) this.m_UILockTime >= 2.0)
        this.m_UILockTime = 1f;
    }
    this.pDVMgr.UpdateRun();
    this.UpDatePvPUI();
    this.UpDateWonderCountTime();
    if (this.bBackTranslate)
      this.BackTranslate();
    if (this.bBackTranslateBatch)
      this.BackTranslateBatch();
    if (this.bBackTranslateFail != (byte) 0)
      this.BackTranslateFail();
    if (this.bBackTranslateBatch_MB)
      this.MB_BackTranslateBatch();
    if (this.bBackTranslateFail_MB != (byte) 0)
      this.MB_BackTranslateFail();
    Indemnify.UpdateRun();
    LightmapManager.Instance.Update();
    MotionEffect.Update();
    bool flag = DataManager.Instance.ServerTime != this.m_LastServerTime;
    for (int index = 0; index < this.m_TimeBarList.Count; ++index)
    {
      if ((UnityEngine.Object) this.m_TimeBarList[index] != (UnityEngine.Object) null)
      {
        if (flag)
          this.m_TimeBarList[index].UpdateTimeText(DataManager.Instance.ServerTime);
        if (this.m_TimeBarList[index].UpdateTime(NetworkManager.ServerTime))
          this.RemoverTimeBaarToList(this.m_TimeBarList[index]);
      }
    }
    this.UpdateLordEquip(flag);
    if ((UnityEngine.Object) this.m_Window1 != (UnityEngine.Object) null)
      this.m_Window1.UpdateTime(flag);
    if ((UnityEngine.Object) this.m_Window2 != (UnityEngine.Object) null)
      this.m_Window2.UpdateTime(flag);
    if ((UnityEngine.Object) this.m_SecWindow != (UnityEngine.Object) null)
      this.m_SecWindow.UpdateTime(flag);
    if ((UnityEngine.Object) this.m_OtheCanvas != (UnityEngine.Object) null)
      this.m_OtheCanvas.UpdateTime(flag);
    if (flag)
    {
      this.CheckBackMessage();
      this.CheckNPCRewardHUD();
      this.m_LastServerTime = DataManager.Instance.ServerTime;
    }
    if ((double) this.m_BMTime > 0.0 && this.m_OKCancelClickIndex != 1)
    {
      this.m_BMTime -= Time.unscaledDeltaTime;
      if (!this.bSendShow && (double) this.m_BMTime <= 0.0)
        this.CloseBattleMessage();
      else if ((UnityEngine.Object) this.m_BMLight != (UnityEngine.Object) null)
      {
        float num = Mathf.Clamp(this.m_BMLightTime / this.m_BMLightMaxTime, 0.0f, 1f);
        Color color = ((Graphic) this.m_BMLight).color;
        ((Transform) ((Graphic) this.m_BMLight).rectTransform).localScale = Vector3.one * 0.9f + Vector3.one * (0.5f * num);
        color.a = (double) num >= 0.5 ? (float) (1.0 - ((double) num - 0.5) / 0.5) : num * 2f;
        ((Graphic) this.m_BMLight).color = color;
        this.m_BMLightTime += Time.unscaledDeltaTime;
        if ((double) this.m_BMLightTime > (double) this.m_BMLightMaxTime)
          this.m_BMLightTime = 0.0f;
      }
    }
    if (this.m_AttackedAlertTCount > 0)
    {
      if (this.bAddAlertImageAlpha)
      {
        Image image = this.AlertImageSA.m_Image;
        ((Graphic) image).color = ((Graphic) image).color + new Color(0.0f, 0.0f, 0.0f, Time.deltaTime);
      }
      else
      {
        Image image = this.AlertImageSA.m_Image;
        ((Graphic) image).color = ((Graphic) image).color - new Color(0.0f, 0.0f, 0.0f, Time.deltaTime);
      }
      if ((double) ((Graphic) this.AlertImageSA.m_Image).color.a <= 0.30000001192092896)
        this.bAddAlertImageAlpha = true;
      if ((double) ((Graphic) this.AlertImageSA.m_Image).color.a >= 1.0)
        this.bAddAlertImageAlpha = false;
      Door menu1 = this.FindMenu(EGUIWindow.Door) as Door;
      if ((UnityEngine.Object) menu1 != (UnityEngine.Object) null)
        menu1.SetAlertImageAlpha(((Graphic) this.AlertImageSA.m_Image).color.a);
      UIBattle menu2 = this.FindMenu(EGUIWindow.UI_Battle) as UIBattle;
      if ((UnityEngine.Object) menu2 != (UnityEngine.Object) null)
        menu2.SetAlertImageAlpha(((Graphic) this.AlertImageSA.m_Image).color.a);
      UILegBattle menu3 = this.FindMenu(EGUIWindow.UI_LegBattle) as UILegBattle;
      if ((UnityEngine.Object) menu3 != (UnityEngine.Object) null)
        menu3.SetAlertImageAlpha(((Graphic) this.AlertImageSA.m_Image).color.a);
      UIBattle_Gambling menu4 = this.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
      if ((UnityEngine.Object) menu4 != (UnityEngine.Object) null)
        menu4.SetAlertImageAlpha(((Graphic) this.AlertImageSA.m_Image).color.a);
    }
    if (Input.GetKeyDown(KeyCode.Escape) && this.m_UILockCount == (byte) 0 && this.m_eUILock == EUILock.Normal)
    {
      if (UIInput.IsOpen() || NewbieManager.IsWorking() || AntiAddictive.Instance.GetAnitAddicitvDlgStage() == NotificationStage.Stage5)
        return;
      if ((UnityEngine.Object) this.m_BackMGGO != (UnityEngine.Object) null)
      {
        this.ReleaseBackMessageBox();
        return;
      }
      if ((UnityEngine.Object) this.m_CheckCrystalBox != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) this.m_CheckCrystalCloseButton != (UnityEngine.Object) null)
        {
          this.OnButtonClick(this.m_CheckCrystalCloseButton);
          return;
        }
        this.CloseCheckCrystalBox();
        return;
      }
      if ((UnityEngine.Object) this.m_OKCancelBox != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) this.m_OKCancelCloseButton != (UnityEngine.Object) null)
        {
          this.OnButtonClick(this.m_OKCancelCloseButton);
          return;
        }
        this.CloseOKCancelBox();
        return;
      }
      if ((UnityEngine.Object) this.Obj_UICalculator != (UnityEngine.Object) null)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.Obj_UICalculator);
        this.Obj_UICalculator = (GameObject) null;
        this.m_UICalculator.mUnitRslider = (UnitResourcesSlider) null;
        return;
      }
      if (((Component) this.m_ItemInfo.m_RectTransform).gameObject.activeSelf)
        this.m_ItemInfo.Hide();
      if (BattleController.IsGambleMode)
      {
        GamblingManager.Instance.OnBackButtonClick();
        return;
      }
      if ((UnityEngine.Object) this.m_SecWindow != (UnityEngine.Object) null)
      {
        if (this.m_SecWindow.m_eWindow == EGUIWindow.UI_NewTerritory)
        {
          DataManager.msgBuffer[0] = (byte) 20;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          return;
        }
        if ((UnityEngine.Object) this.FindMenu(EGUIWindow.UI_Synthesis) != (UnityEngine.Object) null)
          GUIManager.Instance.m_IsOpenedUISynthesis = false;
        this.CloseMenu(this.m_SecWindow.m_eWindow);
        this.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        return;
      }
      if ((UnityEngine.Object) this.m_OtheCanvas != (UnityEngine.Object) null)
      {
        if ((UnityEngine.Object) this.FindMenu(EGUIWindow.UI_HeroTalk) != (UnityEngine.Object) null)
        {
          GUIManager.instance.CloseMenu(EGUIWindow.UI_HeroTalk);
          DataManager.msgBuffer[0] = (byte) 2;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
        GUIWindow menu5 = this.FindMenu(EGUIWindow.UI_TreasureBox);
        if ((UnityEngine.Object) menu5 != (UnityEngine.Object) null && !menu5.OnBackButtonClick())
        {
          GUIManager.instance.CloseMenu(EGUIWindow.UI_TreasureBox);
          this.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        }
        GUIWindow menu6 = this.FindMenu(EGUIWindow.UI_PetLevelUp);
        if (!((UnityEngine.Object) menu6 != (UnityEngine.Object) null) || menu6.OnBackButtonClick())
          return;
        GUIManager.instance.CloseMenu(EGUIWindow.UI_PetLevelUp);
        this.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        return;
      }
      GUIWindow guiWindow = this.FindMenu(EGUIWindow.Door);
      if ((UnityEngine.Object) guiWindow == (UnityEngine.Object) null)
        guiWindow = !((UnityEngine.Object) this.m_Window2 != (UnityEngine.Object) null) ? this.m_Window1 : this.m_Window2;
      if ((UnityEngine.Object) guiWindow != (UnityEngine.Object) null)
        guiWindow.OnBackButtonClick();
    }
    if (this.m_SpeciallyEffect != null)
      this.m_SpeciallyEffect.UpdateRun();
    if (this.UpdateArrow > (byte) 1)
      --this.UpdateArrow;
    else if (this.UpdateArrow == (byte) 1)
    {
      this.UpdateArrow = (byte) 0;
      if ((UnityEngine.Object) this.ArrowParentRect != (UnityEngine.Object) null && (UnityEngine.Object) this.ArrowRect != (UnityEngine.Object) null)
      {
        ((Transform) this.ArrowRect).SetParent((Transform) this.ArrowParentRect);
        ((Transform) this.ArrowRect).localScale = Vector3.one;
      }
    }
    this.m_Hint.Update();
    if (this.TechABRequest != null && this.TechABRequest.isDone)
    {
      GameObject asset = this.TechABRequest.asset as GameObject;
      this.TechIconArray = asset.transform.GetComponent<UISpritesArray>();
      this.TechIconArrayCN = asset.transform.GetChild(0).GetComponent<UISpritesArray>();
      this._TechMaterial = ((MaskableGraphic) asset.transform.GetComponent<Image>()).material;
      this.TechABRequest = (AssetBundleRequest) null;
      this.UpdateUI(this._TechUpdateUI, -1);
    }
    this.m_BeginChangeTime += Time.deltaTime;
    if ((double) this.m_BeginChangeTime >= 3.0)
    {
      this.m_ChangeTime += Time.deltaTime;
      if ((double) this.m_ChangeTime >= 0.05000000074505806)
      {
        byte queueBarDataCount = DataManager.Instance.curQueueBarDataCount;
        Door menu = this.FindMenu(EGUIWindow.Door) as Door;
        this.m_FlashCount -= 0.05f;
        if ((double) this.m_FlashCount <= 0.0)
        {
          this.m_TextIdx = this.m_TextIdx != 0 ? 0 : 1;
          for (int index = 0; index < this.m_TimeBarList.Count; ++index)
          {
            if ((UnityEngine.Object) this.m_TimeBarList[index] != (UnityEngine.Object) null)
              this.m_TimeBarList[index].SetTitleText();
          }
          if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
          {
            for (int index = 0; index < (int) queueBarDataCount && index < menu.m_QueueTimeBar.Length; ++index)
            {
              if (menu.m_QueueTimeBar[index].m_TimerSpriteType == eTimerSpriteType.RallyCountDown || menu.m_QueueTimeBar[index].m_TimerSpriteType == eTimerSpriteType.Mobilization_Report || menu.m_QueueTimeBar[index].m_TimerSpriteType == eTimerSpriteType.Mobilization_fail || menu.m_QueueTimeBar[index].m_TimerSpriteType == eTimerSpriteType.NPCRewardEnd)
                menu.m_QueueTimeBar[index].SetTitleText();
            }
          }
          this.m_FlashCount = 1f;
          this.m_ChangeTime = 0.0f;
          this.m_BeginChangeTime = 0.0f;
        }
        for (int index = 0; index < this.m_TimeBarList.Count; ++index)
        {
          if ((UnityEngine.Object) this.m_TimeBarList[index] != (UnityEngine.Object) null)
            this.m_TimeBarList[index].SetTitleTextColor();
        }
        if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
        {
          for (int index = 0; index < (int) queueBarDataCount && index < menu.m_QueueTimeBar.Length; ++index)
          {
            if (index == 0 || menu.m_QueueTimeBar[index].m_TimerSpriteType == eTimerSpriteType.RallyCountDown || menu.m_QueueTimeBar[index].m_TimerSpriteType == eTimerSpriteType.Mobilization_Report || menu.m_QueueTimeBar[index].m_TimerSpriteType == eTimerSpriteType.Mobilization_fail || menu.m_QueueTimeBar[index].m_TimerSpriteType == eTimerSpriteType.NPCRewardEnd)
              menu.m_QueueTimeBar[index].SetTitleTextColor();
          }
        }
        this.m_ChangeTime = 0.0f;
      }
    }
    if ((UnityEngine.Object) this.m_OKCancelBox != (UnityEngine.Object) null && (UnityEngine.Object) this.MsgBarTimeText != (UnityEngine.Object) null && (UnityEngine.Object) this.MsgBarImage != (UnityEngine.Object) null)
    {
      float msgBarTimeSec = this.MsgBarTimeSec;
      this.MsgBarTimeSec -= Time.deltaTime;
      if ((double) this.MsgBarTimeSec < 0.0)
        this.MsgBarTimeSec = 0.0f;
      if ((uint) msgBarTimeSec - (uint) this.MsgBarTimeSec >= 1U)
        GUIManager.Instance.SetMsgBarTimeAndFill(this.MsgBarTimeSec, this.MaxBarTimeSec);
      else if ((double) msgBarTimeSec == 0.0)
        this.CloseOKCancelBox();
    }
    this.EmojiManager.Run();
  }

  public void UpdateNext()
  {
    if ((UnityEngine.Object) this.m_SecWindow != (UnityEngine.Object) null)
      this.CloseMenu(this.m_SecWindow.m_eWindow);
    if ((UnityEngine.Object) this.m_OtheCanvas != (UnityEngine.Object) null)
      this.CloseMenu(this.m_OtheCanvas.m_eWindow);
    if ((UnityEngine.Object) this.m_Chat != (UnityEngine.Object) null && this.m_Chat.activeInHierarchy)
    {
      this.m_Chat.SetActive(false);
      this.m_WindowList[14] = (GUIWindow) null;
    }
    for (int index = 0; index < ((Transform) this.m_WindowsTransform).childCount; ++index)
    {
      Transform child = ((Transform) this.m_WindowsTransform).GetChild(index);
      GUIWindow component = child.GetComponent<GUIWindow>();
      if ((UnityEngine.Object) component != (UnityEngine.Object) null)
      {
        if (!component.m_bDontDestroyOnSwitch && !((UnityEngine.Object) this.m_WindowList[(int) component.m_eWindow] == (UnityEngine.Object) null))
        {
          component.OnClose();
          this.m_WindowList[(int) component.m_eWindow] = (GUIWindow) null;
          AssetManager.UnloadAssetBundle(component.m_AssetBundleKey);
          component.m_AssetBundle = (AssetBundle) null;
          component.m_AssetBundleKey = 0;
        }
        else
          continue;
      }
      UnityEngine.Object.Destroy((UnityEngine.Object) child.gameObject);
    }
    if (!this.bClearWindowStack)
      return;
    this.m_WindowStack.Clear();
  }

  public void UpdateNetwork(byte[] meg)
  {
    if ((UnityEngine.Object) this.m_Window1 != (UnityEngine.Object) null)
      this.m_Window1.UpdateNetwork(meg);
    if ((UnityEngine.Object) this.m_Window2 != (UnityEngine.Object) null)
      this.m_Window2.UpdateNetwork(meg);
    if ((UnityEngine.Object) this.m_SecWindow != (UnityEngine.Object) null)
      this.m_SecWindow.UpdateNetwork(meg);
    if ((UnityEngine.Object) this.m_OtheCanvas != (UnityEngine.Object) null)
      this.m_OtheCanvas.UpdateNetwork(meg);
    if ((UnityEngine.Object) this.Chatwin != (UnityEngine.Object) null && (UnityEngine.Object) this.m_Chat != (UnityEngine.Object) null && this.m_Chat.activeInHierarchy)
      this.Chatwin.UpdateNetwork(meg);
    if ((UnityEngine.Object) this.m_ActivityWindow != (UnityEngine.Object) null)
      this.m_ActivityWindow.UpdateNetwork(meg);
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        this.UpdateChatBox(9);
        this.CloseCheckCrystalBox();
        break;
      case NetworkNews.Refresh_Asset:
        if (meg[1] == (byte) 2)
        {
          MallManager.Instance.UpDateDownLoad(meg);
          break;
        }
        if (meg[1] == (byte) 4)
        {
          ActivityManager.Instance.UpDateDownLoad(meg);
          break;
        }
        break;
      default:
        if (networkNews == NetworkNews.Refresh_FontTextureRebuilt)
        {
          if ((UnityEngine.Object) this.m_ChatBox != (UnityEngine.Object) null)
          {
            for (int index = 0; index < 2; ++index)
            {
              if (this.m_ChatChannel[index] != null)
              {
                ((Behaviour) this.m_ChatChannel[index].m_ChatText[0]).enabled = false;
                ((Behaviour) this.m_ChatChannel[index].m_ChatText[0]).enabled = true;
                ((Behaviour) this.m_ChatChannel[index].m_ChatText[1]).enabled = false;
                ((Behaviour) this.m_ChatChannel[index].m_ChatText[1]).enabled = true;
              }
            }
            if ((UnityEngine.Object) this.NoAllianceText != (UnityEngine.Object) null && ((Behaviour) this.NoAllianceText).enabled)
            {
              ((Behaviour) this.NoAllianceText).enabled = false;
              ((Behaviour) this.NoAllianceText).enabled = true;
            }
          }
          if ((UnityEngine.Object) this.m_BMGO != (UnityEngine.Object) null)
          {
            if ((UnityEngine.Object) this.m_BMBtnText != (UnityEngine.Object) null && ((Behaviour) this.m_BMBtnText).enabled)
            {
              ((Behaviour) this.m_BMBtnText).enabled = false;
              ((Behaviour) this.m_BMBtnText).enabled = true;
            }
            if ((UnityEngine.Object) this.m_BMText1 != (UnityEngine.Object) null && ((Behaviour) this.m_BMText1).enabled)
            {
              ((Behaviour) this.m_BMText1).enabled = false;
              ((Behaviour) this.m_BMText1).enabled = true;
            }
            if ((UnityEngine.Object) this.m_BMText2 != (UnityEngine.Object) null && ((Behaviour) this.m_BMText2).enabled)
            {
              ((Behaviour) this.m_BMText2).enabled = false;
              ((Behaviour) this.m_BMText2).enabled = true;
            }
          }
          if ((UnityEngine.Object) this.m_CheckCrystalBox != (UnityEngine.Object) null)
          {
            for (int index = 0; index < this.CheckCrystalText.Length; ++index)
            {
              if ((UnityEngine.Object) this.CheckCrystalText[index] != (UnityEngine.Object) null && ((Behaviour) this.CheckCrystalText[index]).enabled)
              {
                ((Behaviour) this.CheckCrystalText[index]).enabled = false;
                ((Behaviour) this.CheckCrystalText[index]).enabled = true;
              }
            }
          }
          if ((UnityEngine.Object) this.m_OKCancelBox != (UnityEngine.Object) null)
          {
            for (int index = 0; index < this.m_MsgText.Count; ++index)
            {
              if ((UnityEngine.Object) this.m_MsgText[index] != (UnityEngine.Object) null && ((Behaviour) this.m_MsgText[index]).enabled)
              {
                ((Behaviour) this.m_MsgText[index]).enabled = false;
                ((Behaviour) this.m_MsgText[index]).enabled = true;
              }
            }
          }
          if ((UnityEngine.Object) this.m_BattleBeginGO != (UnityEngine.Object) null)
          {
            for (int index = 0; index < this.m_bbText.Length; ++index)
            {
              if (!((UnityEngine.Object) this.m_bbText[index] == (UnityEngine.Object) null))
              {
                ((Behaviour) this.m_bbText[index]).enabled = false;
                ((Behaviour) this.m_bbText[index]).enabled = true;
              }
            }
          }
          if (this.m_ItemInfo != null)
            this.m_ItemInfo.TextRefresh();
          if (this.m_SimpleItemInfo != null)
            this.m_SimpleItemInfo.TextRefresh();
          if (this.m_SkillInfo != null)
            this.m_SkillInfo.TextRefresh();
          if (this.m_LordInfo != null)
            this.m_LordInfo.TextRefresh();
          if (this.m_Arena_Hint != null)
            this.m_Arena_Hint.TextRefresh();
          this.m_HUDMessage.TextRefresh();
          if (this.BuildingData.mapspriteManager != null)
            this.BuildingData.mapspriteManager.TextRefresh();
          if (this.m_UICalculator != null)
            this.m_UICalculator.TextRefresh();
          if (this.m_SpeciallyEffect != null)
            this.m_SpeciallyEffect.Refresh_FontTexture();
          if (this.m_Hint != null)
            this.m_Hint.TextRefresh();
          if (this.pDVMgr != null)
          {
            this.pDVMgr.RebuiltFont();
            break;
          }
          break;
        }
        break;
    }
    NewbieManager.UpdateNetwork(meg);
  }

  private void OnFontTextureRebuilt(Font changedFont)
  {
    if ((UnityEngine.Object) changedFont != (UnityEngine.Object) this.m_TTFFont)
      return;
    this.bRebuildFont = true;
  }

  public void LoadFont()
  {
    if (!((UnityEngine.Object) this.m_TTFFont == (UnityEngine.Object) null))
      return;
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn)
    {
      this.m_TTFFont = Resources.GetBuiltinResource<Font>("Arial.ttf");
      Font.textureRebuilt += new Action<Font>(this.OnFontTextureRebuilt);
    }
    else
    {
      this.m_TTFFontBundle = AssetManager.GetAssetBundle("UI/TTFFont", out int _);
      if ((UnityEngine.Object) this.m_TTFFontBundle != (UnityEngine.Object) null)
      {
        this.m_TTFFont = (Font) this.m_TTFFontBundle.mainAsset;
        Font.textureRebuilt += new Action<Font>(this.OnFontTextureRebuilt);
      }
    }
    Texture mainTexture = this.m_TTFFont.material.mainTexture;
    DataManager instance = DataManager.Instance;
    uint num1 = 0;
    uint num2 = 10;
    int num3 = instance.mStringTable.RecordAmount / 2;
    int size = 72;
    while ((long) num1 < (long) num3 && (mainTexture.width < 2048 || mainTexture.height < 2048))
    {
      for (uint index = 1; index <= num2; ++index)
      {
        string stringById = instance.mStringTable.GetStringByID(index + num1);
        if (stringById != null)
          this.m_TTFFont.RequestCharactersInTexture(stringById, size);
      }
      num1 += num2;
      if (size == 72 && (mainTexture.width > 1024 || mainTexture.height > 1024))
        size = 26;
    }
  }

  public void InitialMessageBox()
  {
    this.m_FrameSpriteAsset.InitialAsset("UI_frame");
    this.m_ManagerAssetBundle2 = AssetManager.GetAssetBundle("UI/ManagerAsset2", out this.m_ManagerAssetBundleKey2);
  }

  public void UnloadMessageBox()
  {
    this.m_FrameSpriteAsset.UnloadAsset();
    if (this.m_ManagerAssetBundleKey2 == 0)
      return;
    AssetManager.UnloadAssetBundle(this.m_ManagerAssetBundleKey2);
    this.m_ManagerAssetBundle2 = (AssetBundle) null;
    this.m_ManagerAssetBundleKey2 = 0;
  }

  public void InitialAssets()
  {
    this.LoadFont();
    this.m_bLoadAsset = true;
    this.m_SpriteAssetDict = new Dictionary<int, SpriteAsset>();
    this.m_IconSpriteAsset.InitialAsset("UI_icon");
    this.m_ItemIconSpriteAsset.InitialAsset("UI_itemicon");
    this.m_LeadItemIconSpriteAsset.InitialAsset("UI_leadicon");
    this.m_LeadMatIconSpriteAsset.InitialAsset("UI_leadmaticon");
    this.m_FrameSpriteAsset.InitialAsset("UI_frame");
    this.m_BadgeSpriteAsset.InitialAsset("UI_league_badge");
    this.m_TotemSpriteAsset.InitialAsset("UI_league_totem");
    this.m_SkillSpriteAsset.InitialAsset("UI_skill");
    this.m_AllianceBoxAsset.InitialAsset("UIAllianceBox");
    this.m_LeagueGO_iconAsset.InitialAsset("LeagueGO_icon");
    this.m_ConditiontIconSpriteAsset.InitialAsset("UI_ConditionIcon");
    this.m_TitleSpriteAsset.InitialAsset("UI_Titleicon");
    this.m_ManagerAssetBundle = AssetManager.GetAssetBundle("UI/ManagerAsset", out this.m_ManagerAssetBundleKey);
    if ((UnityEngine.Object) this.m_ManagerAssetBundle != (UnityEngine.Object) null)
    {
      this.m_ItemInfo.Load();
      this.m_SimpleItemInfo.Load();
      this.m_SkillInfo.Load();
      this.m_LordInfo.Load();
      this.HintMaskObj.Load();
      this.m_Hint.Load();
    }
    this.m_Arena_HintAssetBundle = AssetManager.GetAssetBundle("UI/UIArena_Hint", out this.m_Arena_HintAssetBundleKey);
    this.m_Arena_Hint.Load();
    this.m_ManagerAssetBundle2 = AssetManager.GetAssetBundle("UI/ManagerAsset2", out this.m_ManagerAssetBundleKey2);
    this.m_EffectAssetBundle = AssetManager.GetAssetBundle("UI/SpeciallyEffect", out this.m_EffectAssetBundleKey);
    this.m_SpeciallyEffect.Load();
    this.m_CalculatorAssetBundle = AssetManager.GetAssetBundle("UI/UICalculator", out this.m_CalculatorAssetBundleKey);
    this.CreateAttackStateImg();
    this.m_HUDMessage.Init();
    this.m_FastivalIconSet = new Dictionary<byte, int>();
    this.bGPShow = true;
  }

  public void InitMapSprite()
  {
    if (this.MapSpriteKey != 0)
      return;
    UnityEngine.Object[] objectArray = AssetManager.GetAssetBundle("UI/Building", out this.MapSpriteKey).LoadAll();
    for (ushort index = 0; (int) index < objectArray.Length; ++index)
    {
      Sprite sprite = objectArray[(int) index] as Sprite;
      if ((UnityEngine.Object) sprite != (UnityEngine.Object) null)
        this.MapIconDict.Add(sprite.name.GetHashCode(), sprite);
      else if ((bool) (UnityEngine.Object) (objectArray[(int) index] as Material))
      {
        if (objectArray[(int) index].name == "building")
          this.MapSpriteMaterial = objectArray[(int) index] as Material;
        else
          this.MapSpriteUIMaterial = objectArray[(int) index] as Material;
      }
    }
  }

  public void InitTowerSprite()
  {
    if (this.MapSpriteKey != 0)
      return;
    UnityEngine.Object[] objectArray = AssetManager.GetAssetBundle("UI/Tower", out this.MapSpriteKey).LoadAll();
    for (ushort index = 0; (int) index < objectArray.Length; ++index)
    {
      Sprite sprite = objectArray[(int) index] as Sprite;
      if ((UnityEngine.Object) sprite != (UnityEngine.Object) null)
        this.MapIconDict.Add(sprite.name.GetHashCode(), sprite);
      else if ((bool) (UnityEngine.Object) (objectArray[(int) index] as Material))
        this.MapSpriteUIMaterial = objectArray[(int) index] as Material;
    }
  }

  public unsafe void InitWondersSprite()
  {
    CString Name = StringManager.Instance.StaticString1024();
    Name.StringToFormat("UI_Wonders_icon");
    Name.AppendFormat("UI/{0}");
    AssetBundle assetBundle = AssetManager.GetAssetBundle(Name, out this.WondericonAssKey);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return;
    UnityEngine.Object[] objectArray = assetBundle.LoadAll(typeof (Sprite));
    Name.ClearString();
    Name.StringToFormat("UI_Wonders_icon");
    Name.AppendFormat("{0}_m");
    this._m_WonderMaterial = assetBundle.Load(Name.ToString(), typeof (Material)) as Material;
    if (this.m_WondersiconSprite == null || this.m_WondersiconSprite.Length < objectArray.Length)
      this.m_WondersiconSprite = new Sprite[objectArray.Length];
    for (int index = 0; index < objectArray.Length; ++index)
    {
      Sprite sprite = objectArray[index] as Sprite;
      if (!((UnityEngine.Object) sprite == (UnityEngine.Object) null))
      {
        Name.ClearString();
        string str = sprite.name;
        char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
        int length = sprite.name.Length;
        while (length >= 0 && chPtr[length] != '_')
          --length;
        str = (string) null;
        this.m_WondersiconSprite[int.Parse(sprite.name.Substring(length + 1))] = sprite;
      }
    }
    if (9 < this.m_WondersiconSprite.Length)
      this._NpcHead = this.m_WondersiconSprite[9];
    else
      this._NpcHead = this.m_WondersiconSprite[0];
  }

  public Sprite GetWonderSprite(byte wonderID, ushort kingdomID = 0, byte forcdeKvK = 0)
  {
    if (this.WondericonAssKey == 0)
      this.InitWondersSprite();
    bool flag = false;
    if (forcdeKvK > (byte) 0)
    {
      flag = true;
    }
    else
    {
      EActivityState eventState = ActivityManager.Instance.KvKActivityData[4].EventState;
      if (ActivityManager.Instance.IsInKvK((ushort) 0) && eventState != EActivityState.EAS_Prepare && kingdomID > (ushort) 0 && (int) DataManager.MapDataController.kingdomData.kingdomID != (int) kingdomID)
        flag = true;
      ushort kingdomID1 = kingdomID != (ushort) 0 ? kingdomID : DataManager.MapDataController.OtherKingdomData.kingdomID;
      if (!ActivityManager.Instance.IsInKvK((ushort) 0) || (int) kingdomID1 == (int) ActivityManager.Instance.KOWKingdomID || !DataManager.MapDataController.IsEnemy(kingdomID1))
        flag = false;
    }
    Sprite wonderSprite;
    if (wonderID == (byte) 0)
    {
      if (kingdomID == (ushort) 0)
      {
        if (flag)
        {
          wonderSprite = this.m_WondersiconSprite[2];
        }
        else
        {
          int index = (int) DataManager.MapDataController.OtherKingdomData.kingdomID != (int) ActivityManager.Instance.KOWKingdomID ? (int) DataManager.MapDataController.KingdomMapTable.GetRecordByKey(DataManager.MapDataController.kingdomData.kingdomID).mapID + 2 : 8;
          wonderSprite = this.m_WondersiconSprite.Length <= index ? this.m_WondersiconSprite[3] : this.m_WondersiconSprite[index];
        }
      }
      else if (flag)
      {
        wonderSprite = this.m_WondersiconSprite[2];
      }
      else
      {
        int index = (int) kingdomID != (int) ActivityManager.Instance.KOWKingdomID ? (int) DataManager.MapDataController.KingdomMapTable.GetRecordByKey(kingdomID).mapID + 2 : 8;
        wonderSprite = this.m_WondersiconSprite.Length <= index ? this.m_WondersiconSprite[3] : this.m_WondersiconSprite[index];
      }
    }
    else if (flag)
    {
      wonderSprite = this.m_WondersiconSprite[1];
    }
    else
    {
      KingdomYolkDeploy recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(0);
      int Index;
      for (Index = 1; Index < DataManager.MapDataController.KingdomYolkDeployTable.TableCount; ++Index)
      {
        recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(Index);
        if ((int) recordByIndex.kingdomID == (int) kingdomID)
          break;
      }
      if (Index >= DataManager.MapDataController.KingdomYolkDeployTable.TableCount)
        recordByIndex = DataManager.MapDataController.KingdomYolkDeployTable.GetRecordByIndex(0);
      if ((int) wonderID >= recordByIndex.yolkDeployIDs.Length)
        wonderID = (byte) 0;
      YolkDeploy recordByKey = DataManager.MapDataController.YolkDeployTable.GetRecordByKey(recordByIndex.yolkDeployIDs[(int) wonderID]);
      wonderSprite = (int) recordByKey.iconID >= this.m_WondersiconSprite.Length ? this.m_WondersiconSprite[0] : this.m_WondersiconSprite[(int) recordByKey.iconID];
    }
    return wonderSprite;
  }

  public void UnloadWonderSprite()
  {
    if (this.WondericonAssKey == 0)
      return;
    AssetManager.UnloadAssetBundle(this.WondericonAssKey);
    this.WondericonAssKey = 0;
  }

  public void ClearMapSprite()
  {
    AssetManager.UnloadAssetBundle(this.MapSpriteKey);
    this.MapSpriteKey = 0;
    this.MapIconDict.Clear();
  }

  public void UnloadAssets()
  {
    this.m_bLoadAsset = false;
    if (this.m_SpriteAssetDict != null)
      this.m_SpriteAssetDict.Clear();
    if (this.m_SpriteAssetDict != null)
      this.m_FastivalIconSet.Clear();
    this.m_IconSpriteAsset.UnloadAsset();
    this.m_ItemIconSpriteAsset.UnloadAsset();
    this.m_LeadItemIconSpriteAsset.UnloadAsset();
    this.m_LeadMatIconSpriteAsset.UnloadAsset();
    this.m_FrameSpriteAsset.UnloadAsset();
    this.m_BadgeSpriteAsset.UnloadAsset();
    this.m_TotemSpriteAsset.UnloadAsset();
    this.m_SkillSpriteAsset.UnloadAsset();
    this.m_AllianceBoxAsset.UnloadAsset();
    this.m_LeagueGO_iconAsset.UnloadAsset();
    this.m_ConditiontIconSpriteAsset.UnloadAsset();
    this.m_TitleSpriteAsset.UnloadAsset();
    this.m_EmojiSpriteAsset.UnloadAsset();
    this.UnloadWonderSprite();
    this.CloseCheckCrystalBox();
    if ((UnityEngine.Object) this.m_OKCancelBox != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.m_OKCancelBox);
      this.m_OKCancelBox = (GameObject) null;
      this.m_OKCancelCloseButton = (UIButton) null;
      this.m_OKCancelBoxHandler = (GUIWindow) null;
    }
    this.m_MsgText.Clear();
    if ((UnityEngine.Object) this.m_LockPanel != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) ((Component) this.m_LockPanel).gameObject);
      this.m_LockPanel = (RectTransform) null;
      this.m_eUILock = EUILock.Normal;
      this.m_UILockCount = (byte) 0;
    }
    if (this.m_ManagerAssetBundleKey != 0)
    {
      this.m_ItemInfo.Unload();
      this.m_SimpleItemInfo.Unload();
      this.m_SkillInfo.UnLoad();
      this.m_LordInfo.UnLoad();
      this.HintMaskObj.UnLoad();
      this.m_Hint.UnLoad();
      AssetManager.UnloadAssetBundle(this.m_ManagerAssetBundleKey);
      this.m_ManagerAssetBundle = (AssetBundle) null;
      this.m_ManagerAssetBundleKey = 0;
    }
    if (this.m_Arena_HintAssetBundleKey != 0)
    {
      this.m_Arena_Hint.UnLoad();
      AssetManager.UnloadAssetBundle(this.m_Arena_HintAssetBundleKey);
      this.m_Arena_HintAssetBundle = (AssetBundle) null;
      this.m_Arena_HintAssetBundleKey = 0;
    }
    if (this.m_ManagerAssetBundleKey2 != 0)
    {
      AssetManager.UnloadAssetBundle(this.m_ManagerAssetBundleKey2);
      this.m_ManagerAssetBundle2 = (AssetBundle) null;
      this.m_ManagerAssetBundleKey2 = 0;
    }
    if (this.m_EffectAssetBundleKey != 0)
    {
      this.m_SpeciallyEffect.UnLoad();
      AssetManager.UnloadAssetBundle(this.m_EffectAssetBundleKey);
      this.m_EffectAssetBundle = (AssetBundle) null;
      this.m_EffectAssetBundleKey = 0;
    }
    if (this.m_CalculatorAssetBundleKey != 0)
    {
      AssetManager.UnloadAssetBundle(this.m_CalculatorAssetBundleKey);
      this.m_CalculatorAssetBundle = (AssetBundle) null;
      this.m_CalculatorAssetBundleKey = 0;
    }
    if ((UnityEngine.Object) this.m_BMGO != (UnityEngine.Object) null)
      this.CloseBattleMessage();
    if ((UnityEngine.Object) this.m_Chat != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.m_Chat);
      this.m_Chat = (GameObject) null;
      this.m_WindowList[14] = (GUIWindow) null;
      this.Chatwin = (GUIWindow) null;
      AssetManager.UnloadAssetBundle(this.ChatabKey);
      this.Chatab = (AssetBundle) null;
      this.ChatabKey = 0;
      this.window2mode = EUIOriginMode.Show;
    }
    this.ClearBackMessageBox(byte.MaxValue);
    if (this.m_WindowStack != null)
      this.m_WindowStack.Clear();
    this.bClearWindowStack = true;
    this.m_HUDMessage.Destroy();
    this.UIHero_Index = -1;
    this.UIBarrack_Y = -1f;
    this.UIBarrack_TrapY = -1f;
    this.RemoveAllAttackState();
    this.mUIQueueLock = 0;
    this.GUIQueue.Clear();
    if (this.MapEmojiCount == null)
      return;
    this.MapEmojiCount.Clear();
    this.MapEmojiCount = (Dictionary<ushort, byte>) null;
  }

  public Font GetTTFFont() => this.m_TTFFont;

  public Material AddSpriteAsset(string AssetName)
  {
    this.Key = AssetName.GetHashCode();
    SpriteAsset spriteAsset;
    if (!this.m_SpriteAssetDict.TryGetValue(this.Key, out spriteAsset))
    {
      spriteAsset.InitialAsset(AssetName);
      if ((UnityEngine.Object) spriteAsset.m_AssetBundle == (UnityEngine.Object) null)
        return (Material) null;
      this.m_SpriteAssetDict.Add(this.Key, spriteAsset);
    }
    else
    {
      ++spriteAsset.m_RefCount;
      this.m_SpriteAssetDict[this.Key] = spriteAsset;
    }
    return spriteAsset.m_Material;
  }

  public void RemoveSpriteAsset(string AssetName)
  {
    this.Key = AssetName.GetHashCode();
    SpriteAsset spriteAsset;
    if (!this.m_SpriteAssetDict.TryGetValue(this.Key, out spriteAsset))
      return;
    --spriteAsset.m_RefCount;
    this.m_SpriteAssetDict[this.Key] = spriteAsset;
    if (spriteAsset.m_RefCount > 0)
      return;
    this.m_SpriteAssetDict.Remove(this.Key);
    spriteAsset.UnloadAsset();
  }

  public Sprite LoadSprite(string AssetName, string SpriteName)
  {
    SpriteAsset spriteAsset;
    if (!this.m_SpriteAssetDict.TryGetValue(AssetName.GetHashCode(), out spriteAsset))
      return (Sprite) null;
    Sprite sprite;
    spriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(), out sprite);
    return sprite;
  }

  public Sprite LoadSprite(string AssetName, CString SpriteName)
  {
    SpriteAsset spriteAsset;
    if (!this.m_SpriteAssetDict.TryGetValue(AssetName.GetHashCode(), out spriteAsset))
      return (Sprite) null;
    Sprite sprite;
    spriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(false), out sprite);
    return sprite;
  }

  public Material LoadMaterial(string AssetName, string MaterialName)
  {
    SpriteAsset spriteAsset;
    return this.m_SpriteAssetDict.TryGetValue(AssetName.GetHashCode(), out spriteAsset) ? spriteAsset.m_AssetBundle.Load(MaterialName, typeof (Material)) as Material : (Material) null;
  }

  public Sprite LoadFrameSprite(EFrameSprite eFrame, byte id)
  {
    this.LoadSpriteStr.Length = 0;
    switch (eFrame)
    {
      case EFrameSprite.Hero:
        this.LoadSpriteStr.IntToFormat((long) id, 3);
        this.LoadSpriteStr.AppendFormat("hf{0:000}");
        break;
      case EFrameSprite.Item:
        this.LoadSpriteStr.IntToFormat((long) id, 3);
        this.LoadSpriteStr.AppendFormat("if{0:000}");
        break;
      case EFrameSprite.Lead:
        this.LoadSpriteStr.IntToFormat((long) id, 3);
        this.LoadSpriteStr.AppendFormat("lf{0:000}");
        break;
      case EFrameSprite.Jewelry:
        this.LoadSpriteStr.IntToFormat((long) id, 3);
        this.LoadSpriteStr.AppendFormat("jf{0:000}");
        break;
      case EFrameSprite.Pet:
        this.LoadSpriteStr.IntToFormat((long) ((int) id + 2), 3);
        this.LoadSpriteStr.AppendFormat("hf{0:000}");
        break;
    }
    return this.LoadFrameSprite(this.LoadSpriteStr);
  }

  public Sprite LoadFrameSprite(string SpriteName)
  {
    Sprite sprite;
    this.m_FrameSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(), out sprite);
    return sprite;
  }

  public Sprite LoadFrameSprite(CString SpriteName)
  {
    Sprite sprite;
    this.m_FrameSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(false), out sprite);
    return sprite;
  }

  public Material GetFrameMaterial() => this.m_FrameSpriteAsset.m_Material;

  public void SetPointTexture(byte point, Image numImg)
  {
    if (point == byte.MaxValue)
    {
      numImg.sprite = this.LoadFrameSprite("UI_mall_x_001");
    }
    else
    {
      this.LoadSpriteStr.Length = 0;
      this.LoadSpriteStr.IntToFormat((long) point);
      this.LoadSpriteStr.AppendFormat("UI_mall_{0}_001");
      numImg.sprite = this.LoadFrameSprite(this.LoadSpriteStr);
    }
    ((MaskableGraphic) numImg).material = this.GetFrameMaterial();
  }

  public Sprite LoadBadgeSprite(bool bBadge, string SpriteName)
  {
    Sprite sprite;
    if (bBadge)
      this.m_BadgeSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(), out sprite);
    else
      this.m_TotemSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(), out sprite);
    return sprite;
  }

  public Sprite LoadBadgeSprite(bool bBadge, CString SpriteName)
  {
    Sprite sprite;
    if (bBadge)
      this.m_BadgeSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(false), out sprite);
    else
      this.m_TotemSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(false), out sprite);
    return sprite;
  }

  public Material GetBadgeMaterial(bool bBadge)
  {
    return bBadge ? this.m_BadgeSpriteAsset.m_Material : this.m_TotemSpriteAsset.m_Material;
  }

  public Sprite LoadSkillSprite(string SpriteName)
  {
    Sprite sprite;
    this.m_SkillSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(), out sprite);
    return sprite;
  }

  public Sprite LoadSkillSprite(CString SpriteName)
  {
    Sprite sprite;
    this.m_SkillSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(false), out sprite);
    return sprite;
  }

  public Material GetSkillMaterial() => this.m_SkillSpriteAsset.m_Material;

  public Sprite LoadTitleSprite(byte IconID, eTitleKind kind = eTitleKind.KvkTitle)
  {
    this.LoadSpriteStr.Length = 0;
    this.LoadSpriteStr.IntToFormat((long) IconID, 3);
    switch (kind)
    {
      case eTitleKind.KvkTitle:
        this.LoadSpriteStr.AppendFormat("TI{0:000}");
        break;
      case eTitleKind.WorldTitle:
        this.LoadSpriteStr.AppendFormat("WT{0:000}");
        break;
      case eTitleKind.KingdomTitle:
        this.LoadSpriteStr.AppendFormat("KT{0:000}");
        break;
      case eTitleKind.NobilityTitle:
        this.LoadSpriteStr.AppendFormat("DT{0:000}");
        break;
      default:
        this.LoadSpriteStr.AppendFormat("TI{0:000}");
        break;
    }
    Sprite sprite = (Sprite) null;
    this.m_TitleSpriteAsset.m_Dict.TryGetValue(this.LoadSpriteStr.GetHashCode(false), out sprite);
    if ((UnityEngine.Object) sprite != (UnityEngine.Object) null)
      return sprite;
    this.LoadSpriteStr.Length = 0;
    this.LoadSpriteStr.Append("TI000");
    this.m_TitleSpriteAsset.m_Dict.TryGetValue(this.LoadSpriteStr.GetHashCode(false), out sprite);
    return sprite;
  }

  public Material GetTitleMaterial() => this.m_TitleSpriteAsset.m_Material;

  public Sprite LoadLeagueGO_iconSprite(CString SpriteName)
  {
    Sprite sprite;
    if (this.m_LeagueGO_iconAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(false), out sprite))
      return sprite;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.Append("000");
    this.m_LeagueGO_iconAsset.m_Dict.TryGetValue(cstring.GetHashCode(false), out sprite);
    return sprite;
  }

  public Material GetLeagueGO_iconMaterial() => this.m_LeagueGO_iconAsset.m_Material;

  public Sprite LoadEmojiSprite(string SpriteName)
  {
    Sprite sprite;
    this.m_EmojiSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(), out sprite);
    return sprite;
  }

  public Sprite LoadEmojiSprite(CString SpriteName)
  {
    Sprite sprite;
    this.m_EmojiSpriteAsset.m_Dict.TryGetValue(SpriteName.GetHashCode(false), out sprite);
    return sprite;
  }

  public Material GetEmojiMaterial() => this.m_EmojiSpriteAsset.m_Material;

  public void SetAllyRankImage(Image img, byte Rank)
  {
    Door menu = this.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (UnityEngine.Object) menu)
    {
      switch (Rank)
      {
        case 1:
          img.sprite = menu.LoadSprite("L_vs_badge_02");
          break;
        case 2:
          img.sprite = menu.LoadSprite("L_vs_badge_03");
          break;
        case 3:
          img.sprite = menu.LoadSprite("L_vs_badge_04");
          break;
        case 4:
          img.sprite = menu.LoadSprite("L_vs_badge_05");
          break;
        default:
          img.sprite = menu.LoadSprite("L_vs_badge_01");
          break;
      }
      ((MaskableGraphic) img).material = menu.LoadMaterial();
    }
    else
      ((MaskableGraphic) img).material = this.m_FrameSpriteAsset.m_Material;
  }

  public void SetAllyWarRankImage(Image img, byte Rank)
  {
    Door menu = this.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (UnityEngine.Object) menu)
    {
      Rank = Rank <= (byte) 0 ? (byte) 0 : (byte) (((int) Rank - 1) / 5);
      switch (Rank)
      {
        case 0:
          img.sprite = menu.LoadSprite("SC_L_vs_badge_01");
          break;
        case 1:
          img.sprite = menu.LoadSprite("SC_L_vs_badge_02");
          break;
        case 2:
          img.sprite = menu.LoadSprite("SC_L_vs_badge_03");
          break;
        case 3:
          img.sprite = menu.LoadSprite("SC_L_vs_badge_04");
          break;
        case 4:
          img.sprite = menu.LoadSprite("SC_L_vs_badge_05");
          break;
        default:
          img.sprite = menu.LoadSprite("SC_L_vs_badge_01");
          break;
      }
      ((MaskableGraphic) img).material = menu.LoadMaterial();
    }
    else
      ((MaskableGraphic) img).material = this.m_FrameSpriteAsset.m_Material;
  }

  public void StretchTransform(RectTransform tran)
  {
    tran.sizeDelta = Vector2.zero;
    tran.anchorMin = Vector2.zero;
    tran.anchorMax = Vector2.one;
  }

  public void UpDateCanvas()
  {
    if (this.m_OrthographicCount == (byte) 0)
      return;
    ++this.m_OrthographicCount;
    if ((int) ((double) ((Component) this.m_UICanvas).transform.lossyScale.x * 1000000.0) != 15625)
      return;
    ((Transform) this.pDVMgr.TransitionLayer).localScale = Vector3.one;
    this.m_OrthographicCount = (byte) 0;
    this.SetCanvasChanged();
  }

  public void SetCameraorthOgraphic(bool orthographic)
  {
    Camera.main.orthographic = orthographic;
    if (orthographic)
    {
      this.m_OrthographicCount = (byte) 1;
      ((Transform) this.m_TopLayer).localPosition = Vector3.zero;
      ((Transform) this.m_TopLayer).localScale = Vector3.one;
      ((Transform) this.pDVMgr.TransitionLayer).localScale = new Vector3(1.7f, 1.7f, 1.7f);
      if (!this.IsArabic)
        return;
      ((Transform) this.m_TopLayer).localScale = new Vector3(-((Transform) this.m_TopLayer).localScale.x, ((Transform) this.m_TopLayer).localScale.y, ((Transform) this.m_TopLayer).localScale.z);
    }
    else
    {
      this.m_OrthographicCount = (byte) 0;
      this.SetCanvasChanged();
    }
  }

  public void SetCanvasChanged()
  {
    Vector3 localPosition = ((Transform) this.m_TopLayer).localPosition;
    if (this.m_UICanvas.renderMode == null)
    {
      localPosition.z = 0.0f;
      ((Transform) this.m_TopLayer).localPosition = localPosition;
      localPosition.x = 1f;
    }
    else if (Camera.main.orthographic)
    {
      localPosition.z = (float) ((1.0 - (double) this.m_UICanvas.planeDistance) / (1.0 / 64.0));
      ((Transform) this.m_TopLayer).localPosition = localPosition;
      localPosition.x = 1f;
    }
    else
    {
      localPosition.z = (float) ((11.0 - (double) this.m_UICanvas.planeDistance) / ((double) Camera.main.fieldOfView != 25.0 ? 0.028867499902844429 : 0.011084700003266335));
      ((Transform) this.m_TopLayer).localPosition = localPosition;
      localPosition.x = 11f / this.m_UICanvas.planeDistance;
    }
    localPosition.y = localPosition.x;
    localPosition.z = localPosition.x;
    ((Transform) this.m_TopLayer).localScale = localPosition;
    if (!this.IsArabic)
      return;
    ((Transform) this.m_TopLayer).localScale = new Vector3(-((Transform) this.m_TopLayer).localScale.x, ((Transform) this.m_TopLayer).localScale.y, ((Transform) this.m_TopLayer).localScale.z);
  }

  public GUIWindow OpenMenu(
    EGUIWindow eWin,
    int arg1 = 0,
    int arg2 = 0,
    bool bCameraMode = false,
    bool bSecWindow = false,
    bool bFromDoor = false)
  {
    GUIManager.Instance.m_SpeciallyEffect.ClearAllEffect();
    if ((UnityEngine.Object) ActivityGiftManager.Instance.mActGiftEffectParticle != (UnityEngine.Object) null)
      ActivityGiftManager.Instance.DespawnActivityGiftEffect(false);
    int index = (int) eWin;
    GUIWindow window = this.m_WindowList[index];
    this.HideArrow();
    if (eWin == EGUIWindow.UI_Chat)
    {
      if ((UnityEngine.Object) this.m_Chat == (UnityEngine.Object) null)
      {
        this.Chatab = AssetManager.GetAssetBundle("UI/UIChat", out this.ChatabKey);
        if ((UnityEngine.Object) this.Chatab == (UnityEngine.Object) null)
          return (GUIWindow) null;
        this.m_Chat = (GameObject) UnityEngine.Object.Instantiate(this.Chatab.mainAsset);
        if ((UnityEngine.Object) this.m_Chat == (UnityEngine.Object) null)
        {
          AssetManager.UnloadAssetBundle(this.ChatabKey);
          return (GUIWindow) null;
        }
        this.m_Chat.transform.SetParent((Transform) this.m_ChatLayer, false);
        this.Chatwin = (GUIWindow) this.m_Chat.AddComponent(WindowPrefabData.Data[index].m_WindowType);
        this.m_WindowList[index] = this.Chatwin;
        this.Chatwin.m_eWindow = eWin;
        this.Chatwin.m_AssetBundle = this.Chatab;
        this.Chatwin.m_AssetBundleKey = this.ChatabKey;
        this.Chatwin.OnOpen(arg1, arg2);
      }
      else
      {
        this.m_WindowList[index] = this.Chatwin;
        this.m_Chat.SetActive(true);
        this.UpdateUI(EGUIWindow.UI_Chat, 9, arg1);
      }
      if ((UnityEngine.Object) this.m_Window2 != (UnityEngine.Object) null)
      {
        this.m_Window2.gameObject.SetActive(false);
        Door menu = this.FindMenu(EGUIWindow.Door) as Door;
        if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
          this.window2mode = menu.m_eMode;
      }
      this.UpdateUI(EGUIWindow.Door, 1, 9);
      if (bFromDoor)
      {
        Door menu = this.FindMenu(EGUIWindow.Door) as Door;
        if ((bool) (UnityEngine.Object) menu)
          menu.HideFightButton();
      }
      return this.Chatwin;
    }
    if (!bSecWindow)
    {
      if ((UnityEngine.Object) this.m_Chat != (UnityEngine.Object) null && this.m_Chat.activeInHierarchy)
        this.CloseMenu(this.Chatwin.m_eWindow);
      if ((UnityEngine.Object) window != (UnityEngine.Object) null)
      {
        if (window.m_bDontDestroyOnSwitch)
          window.m_bDontDestroyOnSwitch = false;
        return window;
      }
      if ((UnityEngine.Object) this.m_Window2 != (UnityEngine.Object) null)
        this.CloseMenu(this.m_Window2.m_eWindow);
    }
    else if ((UnityEngine.Object) this.m_SecWindow != (UnityEngine.Object) null)
      this.CloseMenu(this.m_SecWindow.m_eWindow);
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendFormat("UI/{0}", (object) WindowPrefabData.Data[index].m_PrefabName);
    int Key = 0;
    GameObject gameObject = (GameObject) null;
    AssetBundle assetBundle = AssetManager.GetAssetBundle(stringBuilder.ToString(), out Key);
    if ((UnityEngine.Object) assetBundle != (UnityEngine.Object) null)
    {
      UnityEngine.Object original = WindowPrefabData.Data[index].m_OptName != null ? assetBundle.Load(WindowPrefabData.Data[index].m_OptName) : assetBundle.mainAsset;
      if ((bool) original)
        gameObject = (GameObject) UnityEngine.Object.Instantiate(original);
    }
    if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
    {
      AssetManager.UnloadAssetBundle(Key);
      return (GUIWindow) null;
    }
    if (bFromDoor)
    {
      Door menu = this.FindMenu(EGUIWindow.Door) as Door;
      if ((bool) (UnityEngine.Object) menu)
        menu.HideFightButton();
    }
    if (!bSecWindow)
      gameObject.transform.SetParent((Transform) this.m_WindowsTransform, false);
    else
      gameObject.transform.SetParent((Transform) this.m_SecWindowLayer, false);
    GUIWindow guiWindow = (GUIWindow) gameObject.AddComponent(WindowPrefabData.Data[index].m_WindowType);
    this.m_WindowList[index] = guiWindow;
    if (!bSecWindow)
    {
      if ((UnityEngine.Object) this.m_Window1 == (UnityEngine.Object) null)
        this.m_Window1 = guiWindow;
      else
        this.m_Window2 = guiWindow;
    }
    else
      this.m_SecWindow = guiWindow;
    guiWindow.m_eWindow = eWin;
    guiWindow.m_AssetBundle = assetBundle;
    guiWindow.m_AssetBundleKey = Key;
    guiWindow.OnOpen(arg1, arg2);
    if (!bSecWindow && bCameraMode)
    {
      this.m_UICanvas.renderMode = (RenderMode) 1;
      this.SetCanvasChanged();
    }
    return guiWindow;
  }

  public void CloseMenu(EGUIWindow eWin)
  {
    int index = (int) eWin;
    GUIWindow window = this.m_WindowList[index];
    if ((UnityEngine.Object) window == (UnityEngine.Object) null || window.m_bDontDestroyOnSwitch)
      return;
    this.HideArrow();
    switch (eWin)
    {
      case EGUIWindow.UI_Chat:
        this.m_WindowList[index] = (GUIWindow) null;
        this.m_Chat.SetActive(false);
        if (!((UnityEngine.Object) this.m_Window2 != (UnityEngine.Object) null))
          return;
        this.m_Window2.gameObject.SetActive(true);
        this.UpdateUI(EGUIWindow.Door, 1, (int) this.window2mode);
        return;
      case EGUIWindow.UI_leadup:
        DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) 6, (ushort) DataManager.Instance.RoleAttr.Level);
        break;
      case EGUIWindow.UI_TreasureBox:
        DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) 20, (ushort) DataManager.Instance.CurHeroDataCount);
        if (DataManager.StageDataController._stageMode == StageMode.Full || DataManager.StageDataController._stageMode == StageMode.Lean)
        {
          DataManager.MissionDataManager.CheckChanged((eMissionKind) ((byte) 3 + DataManager.StageDataController._stageMode), (ushort) 1, DataManager.StageDataController.StageRecord[(int) DataManager.StageDataController._stageMode]);
          break;
        }
        break;
    }
    window.OnClose();
    this.m_WindowList[index] = (GUIWindow) null;
    bool flag = false;
    if ((UnityEngine.Object) window == (UnityEngine.Object) this.m_Window1)
      this.m_Window1 = (GUIWindow) null;
    else if ((UnityEngine.Object) window == (UnityEngine.Object) this.m_Window2)
      this.m_Window2 = (GUIWindow) null;
    else if ((UnityEngine.Object) window == (UnityEngine.Object) this.m_SecWindow)
    {
      this.m_SecWindow = (GUIWindow) null;
      flag = true;
    }
    else if ((UnityEngine.Object) window == (UnityEngine.Object) this.m_OtheCanvas)
    {
      if (NewbieManager.IsNewbie)
        this.UpdateUI(EGUIWindow.UI_Front, 3);
      this.m_OtheCanvas = (GUIWindow) null;
      this.DestoryOtherCanvas();
      flag = true;
    }
    if (!flag && this.m_UICanvas.renderMode != null)
    {
      this.m_UICanvas.renderMode = (RenderMode) 0;
      this.SetCanvasChanged();
    }
    AssetManager.UnloadAssetBundle(window.m_AssetBundleKey);
    window.m_AssetBundle = (AssetBundle) null;
    window.m_AssetBundleKey = 0;
    UnityEngine.Object.Destroy((UnityEngine.Object) window.gameObject);
    GC.Collect();
  }

  public GUIWindow FindMenu(EGUIWindow eWin) => this.m_WindowList[(int) eWin];

  public void UpdateUI(EGUIWindow eWin, int arg1, int arg2 = 0)
  {
    if (eWin == EGUIWindow.UI_Chat)
    {
      if (!((UnityEngine.Object) this.m_Chat != (UnityEngine.Object) null) || !this.m_Chat.activeInHierarchy)
        return;
      this.Chatwin.UpdateUI(arg1, arg2);
    }
    else
    {
      GUIWindow menu = this.FindMenu(eWin);
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
        return;
      menu.UpdateUI(arg1, arg2);
    }
  }

  public void SetMsgBarTimeAndFill(float TimeSec, float MaxTimeSec)
  {
    if ((UnityEngine.Object) this.MsgBarTimeText != (UnityEngine.Object) null)
    {
      this.MsgBarStr.Length = 0;
      GameConstants.GetTimeString(this.MsgBarStr, (uint) TimeSec, hideTimeIfDays: true, showZeroHour: false);
      this.MsgBarTimeText.text = this.MsgBarStr.ToString();
      this.MsgBarTimeText.SetAllDirty();
      this.MsgBarTimeText.cachedTextGenerator.Invalidate();
      this.MsgBarTimeText.cachedTextGeneratorForLayout.Invalidate();
      this.MsgBarTimeSec = TimeSec;
    }
    if (!((UnityEngine.Object) this.MsgBarImage != (UnityEngine.Object) null) || (double) MaxTimeSec == 0.0)
      return;
    this.MaxBarTimeSec = MaxTimeSec;
    this.MsgBarImage.fillAmount = (float) ((double) this.MaxBarTimeSec - (double) TimeSec + 1.0) / this.MaxBarTimeSec;
  }

  private bool OKCancelNoWindow(bool bOK, int arg1, int arg2)
  {
    switch (this.m_OKCancelClickIndex)
    {
      case 0:
        this.useOrSpendType = UseOrSpendType.UST_MAX;
        break;
      case 1:
        if (bOK)
        {
          DataManager instance = DataManager.Instance;
          if (!WarManager.CheckVersion())
          {
            this.bSendShow = false;
            return true;
          }
          if (this.m_BMNowLiveType == GUIManager.ECombatLiveType.ECLTR_ATTACK || this.m_BMNowLiveType == GUIManager.ECombatLiveType.ECLTR_RALLYATTACK)
          {
            instance.KindomID_War[1] = this.m_BMNowKingdomID;
            instance.AllianceTag_War[1].ClearString();
            instance.AllianceTag_War[1].Append(this.m_BMATStr);
            instance.PlayerName_War[1].ClearString();
            instance.PlayerName_War[1].Append(this.m_BMNStr);
            instance.KindomID_War[0] = instance.MyKingdomID;
            instance.AllianceTag_War[0].ClearString();
            if (instance.RoleAlliance.Id > 0U)
              instance.AllianceTag_War[0].Append(instance.RoleAlliance.Tag);
            instance.PlayerName_War[0].ClearString();
            instance.PlayerName_War[0].Append(instance.RoleAttr.Name);
            WarManager.CurrentPointKind = this.m_BMNowPointKind;
            WarManager.UpdateLocalTimeToTheme(0L);
          }
          else if (this.m_BMNowLiveType == GUIManager.ECombatLiveType.ECLTR_WILDMONSTER)
          {
            MessagePacket messagePacket = new MessagePacket((ushort) 1024);
            messagePacket.Protocol = Protocol._MSG_REQUEST_REPORTINFO;
            messagePacket.AddSeqId();
            messagePacket.Add(DataManager.Instance.Mailing.ReportSerial.New);
            messagePacket.Send();
            BattleController.BattleMode = EBattleMode.Monster;
            this.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MonsterBattle);
          }
          else if (this.m_BMNowLiveType == GUIManager.ECombatLiveType.ECLTR_NPCCITY)
          {
            instance.bWarAttacker = true;
            instance.KindomID_War[0] = DataManager.MapDataController.kingdomData.kingdomID;
            instance.AllianceTag_War[0].ClearString();
            if (instance.RoleAlliance.Id > 0U)
              instance.AllianceTag_War[0].Append(instance.RoleAlliance.Tag);
            instance.PlayerName_War[0].ClearString();
            instance.PlayerName_War[0].Append(instance.RoleAttr.Name);
            instance.KindomID_War[1] = DataManager.MapDataController.OtherKingdomData.kingdomID;
            instance.PlayerName_War[1].ClearString();
            instance.PlayerName_War[1].IntToFormat((long) this.WM_NPCLevel);
            instance.PlayerName_War[1].AppendFormat(instance.mStringTable.GetStringByID(12021U));
            instance.AllianceTag_War[1].ClearString();
          }
          else
          {
            instance.KindomID_War[0] = this.m_BMNowKingdomID;
            instance.AllianceTag_War[0].ClearString();
            instance.AllianceTag_War[0].Append(this.m_BMATStr);
            instance.PlayerName_War[0].ClearString();
            instance.PlayerName_War[0].Append(this.m_BMNStr);
            instance.KindomID_War[1] = instance.MyKingdomID;
            instance.AllianceTag_War[1].ClearString();
            if (instance.RoleAlliance.Id > 0U)
              instance.AllianceTag_War[1].Append(instance.RoleAlliance.Tag);
            instance.PlayerName_War[1].ClearString();
            instance.PlayerName_War[1].Append(instance.RoleAttr.Name);
            WarManager.CurrentPointKind = this.m_BMNowPointKind;
            WarManager.UpdateLocalTimeToTheme(0L);
          }
          if (this.m_BMNowLiveType != GUIManager.ECombatLiveType.ECLTR_WILDMONSTER)
            this.SendBattleMessageRP();
          this.BattleSerialNo = this.SerialNo;
          this.bClearWindowStack = false;
          this.CloseBattleMessage();
        }
        this.bSendShow = false;
        break;
      case 2:
        NetworkManager.Resume(bOK);
        break;
      case 3:
        DataManager instance1 = DataManager.Instance;
        GUIManager instance2 = GUIManager.Instance;
        ushort num1 = (ushort) (arg1 >> 16);
        ushort num2 = (ushort) (arg1 & (int) ushort.MaxValue);
        ushort Parameter1_1 = (ushort) (arg2 >> 16);
        ushort Parameter2_1 = (ushort) (arg2 & (int) ushort.MaxValue);
        if (this.useOrSpendType == UseOrSpendType.UST_ALLIANCE_MONEY_DOUBLE_CHECK || this.useOrSpendType == UseOrSpendType.UST_DIAMOND_DOUBLE_CHECK || this.useOrSpendType == UseOrSpendType.UST_WORLDTELEPORT)
        {
          this.useOrSpendType = this.useOrSpendType != UseOrSpendType.UST_WORLDTELEPORT ? this.useOrSpendType - (byte) 1 : UseOrSpendType.UST_DIAMOND_NORMAL;
          if (((int) num1 == (int) GameConstants.WorldWarTeleportItemID || (int) num1 == (int) GameConstants.AdvanceTeleportItemID && (int) num2 == (int) ActivityManager.Instance.KOWKingdomID && ActivityManager.Instance.NobilityActivityData.EventState == EActivityState.EAS_Run) && (DataManager.Instance.RoleAttr.PetSkillFatigue > (ushort) 0 || PetManager.Instance.BuffImmune.BeginTime > 0L))
          {
            instance2.OpenOKCancelBox(17, instance1.mStringTable.GetStringByID(12140U), instance1.mStringTable.GetStringByID(12141U), arg1, arg2);
            return false;
          }
          if (DataManager.Instance.UseItemNote(num1, num2, Parameter1_1, Parameter2_1))
            return false;
          this.useOrSpendType = UseOrSpendType.UST_MAX;
          break;
        }
        if (bOK)
        {
          if (num1 == (ushort) 1115)
          {
            byte useMoraleItemTimes = instance1.RoleAttr.TodayUseMoraleItemTimes;
            byte moraleBanner = instance1.VIPLevelTable.GetRecordByKey((ushort) instance1.RoleAttr.VIPLevel).moraleBanner;
            if ((int) useMoraleItemTimes >= (int) moraleBanner)
            {
              instance2.MsgStr.Length = 0;
              instance2.MsgStr.IntToFormat((long) moraleBanner);
              instance2.MsgStr.IntToFormat((long) moraleBanner);
              instance2.MsgStr.AppendFormat(instance1.mStringTable.GetStringByID(8584U));
              instance2.OpenOKCancelBox(8, instance1.mStringTable.GetStringByID(5811U), instance2.MsgStr.ToString(), arg1, arg2, instance1.mStringTable.GetStringByID(4507U), instance1.mStringTable.GetStringByID(617U));
              this.useOrSpendType = UseOrSpendType.UST_MAX;
              return false;
            }
            Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(num1);
            if ((int) instance1.RoleAttr.Morale + (int) recordByKey.PropertiesInfo[0].PropertiesValue > 999)
            {
              instance2.AddHUDMessage(instance1.mStringTable.GetStringByID(809U), (ushort) byte.MaxValue);
              return true;
            }
          }
          if (instance1.GetCurItemQuantity(num1, (byte) 0) > (ushort) 0)
          {
            if ((int) num1 == (int) GameConstants.WorldTeleportItemID)
            {
              instance1.UseItem(num1, instance1.WorldTeleportItemCount, num2, Parameter1_1, Parameter2_1, 0U, string.Empty);
              instance1.WorldTeleportItemCount = (ushort) 0;
            }
            else
              instance1.UseItem(num1, (ushort) 1, num2, Parameter1_1, Parameter2_1, 0U, string.Empty);
            this.useOrSpendType = UseOrSpendType.UST_MAX;
            break;
          }
          bool flag = instance1.sendBuyItem((byte) (this.useOrSpendType + (byte) 1), instance1.TotalShopItemData.Find(num1), num1, true, arg1: arg1, arg2: arg2, Parameter3: 0U, name: string.Empty, Qty: (ushort) 1);
          this.useOrSpendType = UseOrSpendType.UST_MAX;
          return flag;
        }
        this.useOrSpendType = UseOrSpendType.UST_MAX;
        break;
      case 4:
        if (bOK)
        {
          if (BattleController.IsGambleMode)
          {
            GamblingManager.Instance.bOpenTreasure = (byte) 1;
            GamblingManager.Instance.CloseMenu();
            this.UpdateUI(EGUIWindow.UI_Battle_Gambling, 13);
            break;
          }
          MallManager.Instance.Send_Mall_Info();
          break;
        }
        break;
      case 5:
        if (bOK)
        {
          DataManager.Instance.RoleBookMark.CheckModify();
          break;
        }
        break;
      case 6:
        if (bOK)
        {
          Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
          if ((bool) (UnityEngine.Object) menu)
          {
            menu.OpenMenu(EGUIWindow.UI_BagFilter, 262145);
            break;
          }
          break;
        }
        break;
      case 7:
        Door menu1 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (bOK && (bool) (UnityEngine.Object) menu1)
        {
          if (!menu1.m_GroundInfo.ScoutCheckBox(eScoutCheckBox.Shield_Self))
            return false;
          DataManager.Instance.ScoutDesPoint.pointID = (byte) 0;
          DataManager.Instance.ScoutDesPoint.zoneID = (ushort) 0;
          GameConstants.MapIDToPointCode(arg1, out DataManager.Instance.ScoutDesPoint.zoneID, out DataManager.Instance.ScoutDesPoint.pointID);
          DataManager.Instance.SendScout(DataManager.Instance.ScoutDesPoint);
          break;
        }
        break;
      case 8:
        Door menu2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (bOK && (bool) (UnityEngine.Object) menu2)
        {
          menu2.OpenMenu(EGUIWindow.UI_VIP);
          break;
        }
        break;
      case 9:
        if (bOK)
        {
          GUIManager.instance.OpenTechTree((ushort) 43, true);
          break;
        }
        break;
      case 11:
        if (bOK)
        {
          ushort ItemID = (ushort) (arg1 >> 16);
          if ((int) ItemID == (int) GameConstants.WorldTeleportItemID)
          {
            DataManager.Instance.RequsetWorldTeleportItemCount();
          }
          else
          {
            ushort num3 = (ushort) (arg1 & (int) ushort.MaxValue);
            ushort zoneID = 0;
            byte pointID = 0;
            GameConstants.MapIDToPointCode(arg2, out zoneID, out pointID);
            Vector2 tileMapPosbyMapId = GameConstants.getTileMapPosbyMapID(arg2);
            CString cstring = StringManager.Instance.StaticString1024();
            cstring.ClearString();
            cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4504U));
            cstring.IntToFormat((long) num3);
            cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4505U));
            cstring.IntToFormat((long) tileMapPosbyMapId.x);
            cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4506U));
            cstring.IntToFormat((long) tileMapPosbyMapId.y);
            cstring.AppendFormat("{0}{1} {2}{3} {4}{5}");
            this.UseOrSpend(ItemID, DataManager.Instance.mStringTable.GetStringByID(4512U), num3, zoneID, (ushort) pointID, UseOrSpendType.UST_DIAMOND_DOUBLE_CHECK, SpecialStr: cstring.ToString(), maxcount: (ushort) 0);
          }
          return false;
        }
        break;
      case 12:
        if (bOK)
        {
          this.useOrSpendType = UseOrSpendType.UST_MAX;
          GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3782U), DataManager.Instance.mStringTable.GetStringByID(955U), 0);
          break;
        }
        break;
      case 13:
        if (bOK)
        {
          ushort num4 = (ushort) (arg1 & (int) ushort.MaxValue);
          ushort zoneID = 0;
          byte pointID = 0;
          GameConstants.MapIDToPointCode(arg2, out zoneID, out pointID);
          int num5 = (int) GameConstants.WorldTeleportItemID << 16 | (int) num4;
          int num6 = (int) zoneID << 16 | (int) pointID;
          this.m_OKCancelClickIndex = 3;
          this.OKCancelNoWindow(true, num5, num6);
          GUIManager.instance.CloseMenu(EGUIWindow.UI_Immigration);
          break;
        }
        break;
      case 14:
        if (bOK)
        {
          Application.Quit();
          break;
        }
        break;
      case 17:
        if (bOK)
        {
          DataManager instance3 = DataManager.Instance;
          GUIManager instance4 = GUIManager.Instance;
          ushort num7 = (ushort) (arg1 >> 16);
          ushort num8 = (ushort) (arg1 & (int) ushort.MaxValue);
          ushort Parameter1_2 = (ushort) (arg2 >> 16);
          ushort Parameter2_2 = (ushort) (arg2 & (int) ushort.MaxValue);
          if (DataManager.Instance.UseItemNote(num7, num8, Parameter1_2, Parameter2_2))
            return false;
          if (instance3.GetCurItemQuantity(num7, (byte) 0) > (ushort) 0)
          {
            if ((int) num7 == (int) GameConstants.WorldTeleportItemID)
            {
              instance3.UseItem(num7, instance3.WorldTeleportItemCount, num8, Parameter1_2, Parameter2_2, 0U, string.Empty);
              instance3.WorldTeleportItemCount = (ushort) 0;
            }
            else
              instance3.UseItem(num7, (ushort) 1, num8, Parameter1_2, Parameter2_2, 0U, string.Empty);
            this.useOrSpendType = UseOrSpendType.UST_MAX;
            break;
          }
          bool flag = instance3.sendBuyItem((byte) (this.useOrSpendType + (byte) 1), instance3.TotalShopItemData.Find(num7), num7, true, arg1: arg1, arg2: arg2, Parameter3: 0U, name: string.Empty, Qty: (ushort) 1);
          this.useOrSpendType = UseOrSpendType.UST_MAX;
          return flag;
        }
        this.useOrSpendType = UseOrSpendType.UST_MAX;
        break;
    }
    return true;
  }

  public void OK(int arg1, int arg2)
  {
    this.m_OKCancelBoxArg1 = arg1;
    this.m_OKCancelBoxArg2 = arg2;
    this.OKCancelNoWindow(true, this.m_OKCancelBoxArg1, this.m_OKCancelBoxArg2);
  }

  public void OnButtonClick(UIButton sender)
  {
    DataManager.MapDataController.StopMapWeapon();
    switch (sender.m_BtnID1)
    {
      case 1:
      case 2:
        this.m_MsgText.Clear();
        UnityEngine.Object.Destroy((UnityEngine.Object) this.m_OKCancelBox);
        this.m_OKCancelBox = (GameObject) null;
        if (sender.m_BtnID1 == 1)
        {
          if ((UnityEngine.Object) this.m_OKCancelBoxHandler != (UnityEngine.Object) null)
          {
            this.m_OKCancelBoxHandler.OnOKCancelBoxClick(sender.m_BtnID2 == 1, this.m_OKCancelBoxArg1, this.m_OKCancelBoxArg2);
            this.m_OKCancelClickIndex = -1;
            break;
          }
          if (!this.OKCancelNoWindow(sender.m_BtnID2 == 1, this.m_OKCancelBoxArg1, this.m_OKCancelBoxArg2))
            break;
          this.m_OKCancelClickIndex = -1;
          break;
        }
        this.useOrSpendType = UseOrSpendType.UST_MAX;
        break;
      case 3:
        DataManager instance = DataManager.Instance;
        if (this.m_BMNowLiveType == GUIManager.ECombatLiveType.ECLTR_WILDMONSTER && !instance.CheckMonsterResourceReady(this.WM_MonsterID))
        {
          this.AddHUDMessage(instance.mStringTable.GetStringByID(8350U), (ushort) byte.MaxValue);
          break;
        }
        this.OpenOKCancelBox(1, instance.mStringTable.GetStringByID(585U), instance.mStringTable.GetStringByID(586U), YesText: instance.mStringTable.GetStringByID(587U), NoText: instance.mStringTable.GetStringByID(588U));
        this.bSendShow = true;
        break;
      case 12:
        if (BattleController.IsGambleMode)
        {
          if (sender.m_BtnID2 == 1 && DataManager.Instance.RoleAlliance.Id == 0U)
          {
            this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9184U), (ushort) byte.MaxValue);
            break;
          }
          GamblingManager.Instance.OpenMenu(EGUIWindow.UI_Chat);
          break;
        }
        Door menu = this.FindMenu(EGUIWindow.Door) as Door;
        if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
        {
          if (sender.m_BtnID2 == 1 && DataManager.Instance.RoleAlliance.Id == 0U)
          {
            menu.AllianceOnClick();
            break;
          }
          if (NewbieManager.CheckRename())
            break;
          menu.OpenMenu(EGUIWindow.UI_Chat, sender.m_BtnID2 + 1);
          break;
        }
        this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(789U), (ushort) byte.MaxValue);
        break;
      case 13:
        this.ReleaseBackMessageBox();
        break;
      case 14:
        if (sender.m_BtnID2 == 1)
        {
          UnityEngine.Object.Destroy((UnityEngine.Object) this.m_CheckCrystalBox);
          this.m_CheckCrystalBox = (GameObject) null;
          switch (this.CheckCrystalKind)
          {
            case 0:
              this.m_CheckCrystalButton.m_BtnID1 = 1;
              this.m_CheckCrystalButton.m_BtnID2 = 1;
              this.OnButtonClick(this.m_CheckCrystalButton);
              return;
            case 1:
              this.UpdateUI(EGUIWindow.UI_BagFilter, this.CheckCrystalPara1);
              return;
            case 2:
              ArenaManager.Instance.SendArena_ReSet_TodayChallenge();
              return;
            case 3:
              DataManager.Instance.sendTechnologyResearchCompleteImmediate((ushort) this.CheckCrystalPara1);
              return;
            case 4:
              this.BuildingData.sendBuildCompleteImmediate((ushort) this.CheckCrystalPara1, (ushort) this.CheckCrystalPara2);
              return;
            case 5:
              this.UpdateUI((EGUIWindow) (this.CheckCrystalPara1 >> 16), this.CheckCrystalPara1 & (int) ushort.MaxValue, this.CheckCrystalPara2);
              return;
            case 6:
              DataManager.Instance.mLordEquip.QuickCombine((ushort) this.CheckCrystalPara1, (uint) this.CheckCrystalPara2);
              return;
            case 7:
              DataManager.Instance.SendAllanceDismissLeader(DataManager.Instance.AllianceMember[this.CheckCrystalPara1].UserId);
              return;
            case 8:
              MobilizationManager.Instance.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_BUY();
              return;
            case 9:
              this.UpdateUI(EGUIWindow.UIEmojiSelect, 2);
              return;
            case 10:
              this.UpdateUI(EGUIWindow.UI_Pet, 10);
              return;
            default:
              return;
          }
        }
        else
        {
          if (sender.m_BtnID2 == 2)
          {
            UnityEngine.Object.Destroy((UnityEngine.Object) this.m_CheckCrystalBox);
            this.m_CheckCrystalBox = (GameObject) null;
            this.bCheckCrystal = false;
            break;
          }
          if (sender.m_BtnID2 != 3)
            break;
          this.bCheckCrystal = !this.bCheckCrystal;
          if (!((UnityEngine.Object) this.CheckCrystalImg != (UnityEngine.Object) null))
            break;
          ((Component) this.CheckCrystalImg).gameObject.SetActive(this.bCheckCrystal);
          break;
        }
      case 15:
        if ((UnityEngine.Object) this.m_CheckCrystalButton == (UnityEngine.Object) null)
        {
          this.m_CheckCrystalButton = sender;
          this.tmpCheckCrystal = (uint) sender.m_BtnID4;
        }
        if (this.OpenCheckCrystal(this.tmpCheckCrystal, (byte) 0))
          break;
        sender.m_BtnID1 = 1;
        sender.m_BtnID2 = 1;
        this.OnButtonClick(sender);
        break;
      case 16:
        if (sender.m_BtnID2 == 1)
        {
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 12);
          UnityEngine.Object.Destroy((UnityEngine.Object) this.m_CheckCrystalBox);
          this.m_CheckCrystalBox = (GameObject) null;
          break;
        }
        if (sender.m_BtnID2 == 2)
        {
          UnityEngine.Object.Destroy((UnityEngine.Object) this.m_CheckCrystalBox);
          this.m_CheckCrystalBox = (GameObject) null;
          GamblingManager.Instance.bIsFirstOpen = false;
          break;
        }
        if (sender.m_BtnID2 != 3)
          break;
        GamblingManager.Instance.bIsFirstOpen = !GamblingManager.Instance.bIsFirstOpen;
        if (!((UnityEngine.Object) this.CheckCrystalImg != (UnityEngine.Object) null))
          break;
        ((Component) this.CheckCrystalImg).gameObject.SetActive(GamblingManager.Instance.bIsFirstOpen);
        break;
      case 17:
        this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(744U), (ushort) byte.MaxValue);
        break;
      case 18:
        if (sender.m_BtnID2 == 1)
        {
          this.UpdateUI(EGUIWindow.UI_AlliWarSchedule, 1, sender.m_BtnID3);
          UnityEngine.Object.Destroy((UnityEngine.Object) this.m_CheckCrystalBox);
          this.m_CheckCrystalBox = (GameObject) null;
          break;
        }
        if (sender.m_BtnID2 == 2)
        {
          UnityEngine.Object.Destroy((UnityEngine.Object) this.m_CheckCrystalBox);
          this.m_CheckCrystalBox = (GameObject) null;
          this.bCheckAWSSchedule = true;
          break;
        }
        if (sender.m_BtnID2 != 3)
          break;
        this.bCheckAWSSchedule = !this.bCheckAWSSchedule;
        if (!((UnityEngine.Object) this.CheckCrystalImg != (UnityEngine.Object) null))
          break;
        ((Component) this.CheckCrystalImg).gameObject.SetActive(!this.bCheckAWSSchedule);
        break;
      case 19:
        if (sender.m_BtnID2 == 1)
        {
          this.UpdateUI(EGUIWindow.UI_MessageBoard, 6);
          UnityEngine.Object.Destroy((UnityEngine.Object) this.m_CheckCrystalBox);
          this.m_CheckCrystalBox = (GameObject) null;
          break;
        }
        if (sender.m_BtnID2 == 2)
        {
          UnityEngine.Object.Destroy((UnityEngine.Object) this.m_CheckCrystalBox);
          this.m_CheckCrystalBox = (GameObject) null;
          this.bCheckDeleteMsg = true;
          break;
        }
        if (sender.m_BtnID2 != 3)
          break;
        this.bCheckDeleteMsg = !this.bCheckDeleteMsg;
        if (!((UnityEngine.Object) this.CheckCrystalImg != (UnityEngine.Object) null))
          break;
        ((Component) this.CheckCrystalImg).gameObject.SetActive(!this.bCheckDeleteMsg);
        break;
      case 20:
        if (sender.m_BtnID2 == 1)
        {
          this.UpdateUI(EGUIWindow.UI_PetStoneTrans, 1);
          UnityEngine.Object.Destroy((UnityEngine.Object) this.m_CheckCrystalBox);
          this.m_CheckCrystalBox = (GameObject) null;
          break;
        }
        if (sender.m_BtnID2 == 2)
        {
          UnityEngine.Object.Destroy((UnityEngine.Object) this.m_CheckCrystalBox);
          this.m_CheckCrystalBox = (GameObject) null;
          this.bCheckStoneTrans = true;
          break;
        }
        if (sender.m_BtnID2 != 3)
          break;
        this.bCheckStoneTrans = !this.bCheckStoneTrans;
        if (!((UnityEngine.Object) this.CheckCrystalImg != (UnityEngine.Object) null))
          break;
        ((Component) this.CheckCrystalImg).gameObject.SetActive(!this.bCheckStoneTrans);
        break;
      case 21:
        if (sender.m_BtnID2 != 1)
        {
          if (sender.m_BtnID2 == 2)
            RealNameHelp.Instance.OpenQuitGameRealNameByWebView();
          else if (sender.m_BtnID2 == 3)
            Application.Quit();
        }
        this.m_MsgText.Clear();
        UnityEngine.Object.Destroy((UnityEngine.Object) this.m_OKCancelBox);
        this.m_OKCancelBox = (GameObject) null;
        if ((UnityEngine.Object) this.m_OKCancelBoxHandler != (UnityEngine.Object) null)
        {
          this.m_OKCancelBoxHandler.OnOKCancelBoxClick(sender.m_BtnID2 == 1, this.m_OKCancelBoxArg1, this.m_OKCancelBoxArg2);
          this.m_OKCancelClickIndex = -1;
        }
        else if (this.OKCancelNoWindow(sender.m_BtnID2 == 1, this.m_OKCancelBoxArg1, this.m_OKCancelBoxArg2))
          this.m_OKCancelClickIndex = -1;
        AntiAddictive.Instance.SetAnitAddicitvDlgStage(NotificationStage.None);
        break;
      case 22:
        RealNameHelp.Instance.ClearUpdateCheckState();
        if (sender.m_BtnID2 == 0)
          RealNameHelp.Instance.OpenRealNameByWebView();
        else if (sender.m_BtnID2 == 1)
          RealNameHelp.Instance.OpenRealNameByWebView();
        else if (sender.m_BtnID2 == 2 || sender.m_BtnID2 == 3 || sender.m_BtnID2 != 4)
          ;
        this.m_MsgText.Clear();
        UnityEngine.Object.Destroy((UnityEngine.Object) this.m_OKCancelBox);
        this.m_OKCancelBox = (GameObject) null;
        if ((UnityEngine.Object) this.m_OKCancelBoxHandler != (UnityEngine.Object) null)
        {
          this.m_OKCancelBoxHandler.OnOKCancelBoxClick(sender.m_BtnID2 == 1, this.m_OKCancelBoxArg1, this.m_OKCancelBoxArg2);
          this.m_OKCancelClickIndex = -1;
        }
        else if (this.OKCancelNoWindow(sender.m_BtnID2 == 1, this.m_OKCancelBoxArg1, this.m_OKCancelBoxArg2))
          this.m_OKCancelClickIndex = -1;
        if (sender.m_BtnID2 == 0 || sender.m_BtnID2 == 1 || AntiAddictive.Instance.m_SaveStage != NotificationStage.Stage5)
          break;
        RealNameHelp.Instance.CheckFromQuitGameDlgFlag();
        break;
      case 23:
        if (sender.m_BtnID2 == 1)
        {
          UnityEngine.Object.Destroy((UnityEngine.Object) this.m_CheckCrystalBox);
          this.m_CheckCrystalBox = (GameObject) null;
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Expedition, 6);
          break;
        }
        if (sender.m_BtnID2 == 2)
        {
          UnityEngine.Object.Destroy((UnityEngine.Object) this.m_CheckCrystalBox);
          this.m_CheckCrystalBox = (GameObject) null;
          DataManager.Instance.bFirstOpenWarlobbyTroopSelect = false;
          break;
        }
        if (sender.m_BtnID2 != 3)
          break;
        DataManager.Instance.bFirstOpenWarlobbyTroopSelect = !DataManager.Instance.bFirstOpenWarlobbyTroopSelect;
        if (!((UnityEngine.Object) this.CheckCrystalImg != (UnityEngine.Object) null))
          break;
        ((Component) this.CheckCrystalImg).gameObject.SetActive(DataManager.Instance.bFirstOpenWarlobbyTroopSelect);
        break;
    }
  }

  public void OpenOKCancelBox(
    int ClickIndex,
    string TitleText,
    string QuestionText,
    int arg1 = 0,
    int arg2 = 0,
    string YesText = null,
    string NoText = null)
  {
    this.m_OKCancelClickIndex = ClickIndex;
    this.OpenOKCancelBox((GUIWindow) null, TitleText, QuestionText, arg1, arg2, YesText, NoText);
  }

  public void OpenOKCancelBox(
    GUIWindow win,
    string TitleText,
    string QuestionText,
    int arg1 = 0,
    int arg2 = 0,
    string YesText = null,
    string NoText = null)
  {
    // ISSUE: unable to decompile the method.
  }

  public void OpenMessageBox(
    string TitleText,
    string MessageText,
    int ClickIndex,
    string ButtonText = null,
    int arg1 = 0,
    int arg2 = 0,
    bool bCloseIDSet = false,
    bool ShowBar = false,
    bool BackExit = false,
    bool bHideCloseBtn = false,
    bool bHideYesBtn = false)
  {
    this.m_OKCancelClickIndex = ClickIndex;
    this.OpenMessageBox(TitleText, MessageText, ButtonText, arg1: arg1, arg2: arg2, bCloseIDSet: bCloseIDSet, ShowBar: ShowBar, BackExit: BackExit, bHideCloseBtn: bHideCloseBtn, bHideYesBtn: bHideYesBtn);
  }

  public void OpenMessageBox(
    string TitleText,
    string MessageText,
    string ButtonText = null,
    GUIWindow win = null,
    int arg1 = 0,
    int arg2 = 0,
    bool bCloseIDSet = false,
    bool ShowBar = false,
    bool BackExit = false,
    bool bHideCloseBtn = false,
    bool bHideYesBtn = false)
  {
    // ISSUE: unable to decompile the method.
  }

  public void OpenMessageBoxEX(
    string TitleText,
    string MessageText,
    int ClickIndex,
    string ButtonText = null,
    int arg1 = 0,
    int arg2 = 0,
    bool bInfo = false,
    bool BackExit = false)
  {
    this.m_OKCancelClickIndex = ClickIndex;
    this.OpenMessageBoxEX(TitleText, MessageText, ButtonText, arg1: arg1, arg2: arg2, bInfo: bInfo, BackExit: BackExit);
  }

  public void OpenMessageBoxEX(
    string TitleText,
    string MessageText,
    string ButtonText = null,
    GUIWindow win = null,
    int arg1 = 0,
    int arg2 = 0,
    bool bInfo = false,
    bool BackExit = false)
  {
    // ISSUE: unable to decompile the method.
  }

  public void OpenSpendWindow_Normal(
    int ClickIndex,
    string TitleText,
    string QuestionText,
    int Cost,
    int arg1 = 0,
    int arg2 = 0,
    string Buttontext = null)
  {
    this.m_OKCancelClickIndex = ClickIndex;
    this.OpenSpendWindow_Normal((GUIWindow) null, TitleText, QuestionText, Cost, arg1, arg2, Buttontext);
  }

  public void OpenSpendWindow_Normal(
    GUIWindow win,
    string TitleText,
    string QuestionText,
    int Cost,
    int arg1 = 0,
    int arg2 = 0,
    string Buttontext = null,
    bool bGold = false)
  {
    // ISSUE: unable to decompile the method.
  }

  public void OpenSpendWindow_ItemID(
    int ClickIndex,
    string TitleText,
    ushort ItemID,
    int arg1 = 0,
    int arg2 = 0,
    string HaveItemText = null,
    string NoItemText = null,
    string SpecialStr = null)
  {
    this.m_OKCancelClickIndex = ClickIndex;
    this.OpenSpendWindow_ItemID((GUIWindow) null, TitleText, ItemID, arg1, arg2, HaveItemText, NoItemText, SpecialStr);
  }

  public void OpenSpendWindow_ItemID(
    GUIWindow win,
    string TitleText,
    ushort ItemID,
    int arg1 = 0,
    int arg2 = 0,
    string HaveItemText = null,
    string NoItemText = null,
    string SpecialStr = null)
  {
    // ISSUE: unable to decompile the method.
  }

  public bool UseOrSpend(
    ushort ItemID,
    string TitleText,
    ushort TargetID = 0,
    ushort Parameter1 = 0,
    ushort Parameter2 = 0,
    UseOrSpendType Type = UseOrSpendType.UST_DIAMOND_NORMAL,
    string HaveItemText = null,
    string NoItemText = null,
    string SpecialStr = null,
    ushort maxcount = 0)
  {
    if (this.useOrSpendType != UseOrSpendType.UST_MAX)
      return false;
    this.useOrSpendType = Type;
    this.OpenSpendWindow_ItemID(3, TitleText, ItemID, (int) TargetID | (int) maxcount << 16, (int) Parameter1 << 16 | (int) Parameter2, HaveItemText, NoItemText, SpecialStr);
    return true;
  }

  public void OpenSpendWindow_ItemID2(
    int ClickIndex,
    string TitleText,
    ushort ItemID1,
    ushort ItemID2,
    uint price,
    ushort day,
    byte hour,
    byte min,
    byte sec,
    bool bShowCount = true,
    int arg1 = 0,
    int arg2 = 0,
    string HaveItemText = null,
    string NoItemText = null,
    string BottomText = null)
  {
    this.m_OKCancelClickIndex = ClickIndex;
    this.OpenSpendWindow_ItemID2((GUIWindow) null, TitleText, ItemID1, ItemID2, price, day, hour, min, sec, bShowCount, arg1, arg2, HaveItemText, NoItemText, BottomText);
  }

  public void OpenSpendWindow_ItemID2(
    GUIWindow win,
    string TitleText,
    ushort ItemID1,
    ushort ItemID2,
    uint price,
    ushort day,
    byte hour,
    byte min,
    byte sec,
    bool bShowCount = true,
    int arg1 = 0,
    int arg2 = 0,
    string HaveItemText = null,
    string NoItemText = null,
    string BottomText = null)
  {
    // ISSUE: unable to decompile the method.
  }

  public void OpenAntiAddictiveMessageBox(
    NotificationStage stage,
    string TitleText,
    string MessageText,
    string ButtonText,
    bool bShowRealNameBtn,
    bool bShowCloseBtn,
    int arg1,
    int arg2)
  {
    // ISSUE: unable to decompile the method.
  }

  public void OpenRealNameMessageBox(RealNameState state)
  {
    // ISSUE: unable to decompile the method.
  }

  public void CloseAntiAddictiveMessageBox()
  {
    this.CloseOKCancelBox();
    AntiAddictive.Instance.SetAnitAddicitvDlgStage(NotificationStage.None);
  }

  public void CloseOKCancelBox()
  {
    if ((UnityEngine.Object) this.m_OKCancelBox == (UnityEngine.Object) null)
      return;
    this.m_MsgText.Clear();
    UnityEngine.Object.Destroy((UnityEngine.Object) this.m_OKCancelBox);
    this.m_OKCancelBox = (GameObject) null;
    this.m_OKCancelClickIndex = -1;
    this.MsgBarTimeText = (UIText) null;
    this.MsgBarImage = (CustomImage) null;
    this.MsgBarTimeSec = this.MaxBarTimeSec = 0.0f;
  }

  public bool OpenCheckCrystal(uint price, byte Kind = 0, int Para1 = -1, int Para2 = -1)
  {
    // ISSUE: unable to decompile the method.
  }

  public bool OpenCheckGamble()
  {
    // ISSUE: unable to decompile the method.
  }

  public bool OpenCheckAWSSchedule(string str, byte matchid)
  {
    // ISSUE: unable to decompile the method.
  }

  public bool OpenCheckWarlobbyTroopSelect()
  {
    // ISSUE: unable to decompile the method.
  }

  public bool OpenCheckDeleteMsg()
  {
    // ISSUE: unable to decompile the method.
  }

  public bool OpenCheckStoneTrans(CString MessageStr)
  {
    // ISSUE: unable to decompile the method.
  }

  public void CloseCheckCrystalBox()
  {
    if ((UnityEngine.Object) this.m_CheckCrystalBox == (UnityEngine.Object) null)
      return;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.m_CheckCrystalBox);
    this.m_CheckCrystalBox = (GameObject) null;
    this.m_CheckCrystalCloseButton = (UIButton) null;
    this.m_CheckCrystalButton = (UIButton) null;
    this.CheckCrystalImg = (CustomImage) null;
    this.tmpCheckCrystal = 0U;
    StringManager.Instance.DeSpawnString(this.CheckCrystalStr);
    for (int index = 0; index < this.CheckCrystalText.Length; ++index)
      this.CheckCrystalText[index] = (UIText) null;
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    if (TextureName == "UI_main")
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!(bool) (UnityEngine.Object) menu)
        return;
      img.sprite = menu.LoadSprite(ImageName);
      ((MaskableGraphic) img).material = menu.LoadMaterial();
    }
    else
    {
      img.sprite = this.LoadFrameSprite(ImageName);
      ((MaskableGraphic) img).material = this.GetFrameMaterial();
    }
  }

  public bool ShowUILock(EUILock eLock)
  {
    if (!NetworkManager.Connected() && eLock != EUILock.Network)
      return false;
    if ((UnityEngine.Object) this.m_LockPanel == (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.m_ManagerAssetBundle2 == (UnityEngine.Object) null)
        this.m_ManagerAssetBundle2 = AssetManager.GetAssetBundle("UI/ManagerAsset2", out this.m_ManagerAssetBundleKey2);
      UnityEngine.Object original = this.m_ManagerAssetBundle2.Load("UILockPanel");
      if (original == (UnityEngine.Object) null)
        return false;
      GameObject gameObject = (GameObject) UnityEngine.Object.Instantiate(original);
      gameObject.transform.SetParent((Transform) this.m_LockPanelLayer, false);
      this.m_LockPanel = gameObject.GetComponent<RectTransform>();
      gameObject.transform.GetComponent<UIButton>().SoundIndex = byte.MaxValue;
      gameObject.SetActive(false);
    }
    switch (eLock)
    {
      case EUILock.Normal:
        ++this.m_UILockCount;
        ((Component) this.m_LockPanel).gameObject.SetActive(true);
        if (this.m_eUILock == EUILock.Normal)
        {
          for (int index = 0; index < ((Transform) this.m_LockPanel).childCount; ++index)
            ((Transform) this.m_LockPanel).GetChild(index).gameObject.SetActive(false);
          break;
        }
        break;
      case EUILock.All:
        this.m_eUILock = eLock;
        this.m_UILockTime = 0.0f;
        NetworkManager.Freeze(true);
        ((Component) this.m_LockPanel).gameObject.SetActive(true);
        for (int index = 0; index < ((Transform) this.m_LockPanel).childCount; ++index)
          ((Transform) this.m_LockPanel).GetChild(index).gameObject.SetActive(false);
        break;
      default:
        if (this.m_eUILock != EUILock.Normal)
          return false;
        goto case EUILock.All;
    }
    return true;
  }

  public bool HideUILock(EUILock eLock)
  {
    if ((UnityEngine.Object) this.m_LockPanel == (UnityEngine.Object) null)
      return false;
    switch (eLock)
    {
      case EUILock.Normal:
        if (this.m_UILockCount == (byte) 0)
          return false;
        --this.m_UILockCount;
        if (this.m_UILockCount == (byte) 0 && this.m_eUILock == EUILock.Normal)
        {
          ((Component) this.m_LockPanel).gameObject.SetActive(false);
          break;
        }
        break;
      case EUILock.All:
        this.m_UILockCount = (byte) 0;
        this.m_eUILock = EUILock.Normal;
        NetworkManager.Freeze(false);
        ((Component) this.m_LockPanel).gameObject.SetActive(false);
        for (int index = 0; index < ((Transform) this.m_LockPanel).childCount; ++index)
          ((Transform) this.m_LockPanel).GetChild(index).gameObject.SetActive(false);
        break;
      default:
        if (eLock != EUILock.All && eLock != EUILock.Network && eLock != this.m_eUILock)
          return false;
        this.m_eUILock = EUILock.Normal;
        NetworkManager.Freeze(false);
        if (this.m_UILockCount == (byte) 0)
        {
          ((Component) this.m_LockPanel).gameObject.SetActive(false);
          break;
        }
        for (int index = 0; index < ((Transform) this.m_LockPanel).childCount; ++index)
          ((Transform) this.m_LockPanel).GetChild(index).gameObject.SetActive(false);
        break;
    }
    return true;
  }

  public EUILock GetUILock() => this.m_eUILock;

  public void AddHUDMessage(string msg, ushort MsgID = 255, bool bCheckSame = true)
  {
    this.m_HUDMessage.AddMessage(msg, MsgID, bCheckSame);
  }

  public void AddHUDQueue(string msg, ushort MsgID = 255, bool bCheckSame = true)
  {
    this.m_HUDMessage.AddMessageQueqe(msg, MsgID, bCheckSame);
  }

  public bool IsLeadItem(byte EquipKind) => EquipKind >= (byte) 20 && EquipKind <= (byte) 27;

  public void SetLayer(GameObject go, int layer)
  {
    go.layer = layer;
    Transform transform = go.transform;
    int index = 0;
    for (int childCount = transform.childCount; index < childCount; ++index)
      this.SetLayer(transform.GetChild(index).gameObject, layer);
  }

  public void SetIPhoneX()
  {
    this.bOpenOnIPhoneX = true;
    this.m_WindowsTransform.offsetMin = new Vector2(this.IPhoneX_DeltaX, 0.0f);
    this.m_WindowsTransform.offsetMax = new Vector2(-this.IPhoneX_DeltaX, 0.0f);
    this.m_ChatLayer.offsetMin = new Vector2(this.IPhoneX_DeltaX, 0.0f);
    this.m_ChatLayer.offsetMax = new Vector2(-this.IPhoneX_DeltaX, 0.0f);
    this.m_TopLayer.offsetMin = new Vector2(this.IPhoneX_DeltaX, 0.0f);
    this.m_TopLayer.offsetMax = new Vector2(-this.IPhoneX_DeltaX, 0.0f);
    this.m_MessageBoxLayer.offsetMin = new Vector2(-this.IPhoneX_DeltaX, 0.0f);
    this.m_MessageBoxLayer.offsetMax = new Vector2(this.IPhoneX_DeltaX, 0.0f);
    this.m_NewbieLayer.offsetMin = new Vector2(-this.IPhoneX_DeltaX, 0.0f);
    this.m_NewbieLayer.offsetMax = new Vector2(this.IPhoneX_DeltaX, 0.0f);
  }

  public bool InitianHeroItemImg(
    Transform BtnT,
    eHeroOrItem HeroOrItem,
    ushort HIID,
    byte Circle = 0,
    byte Rank = 0,
    int LvOrNum = 0,
    bool bShowText = true,
    bool bAutoShowHint = true,
    bool bClickSound = true,
    bool bScaleBtn = false)
  {
    UIHIBtn component1 = BtnT.GetComponent<UIHIBtn>();
    if ((UnityEngine.Object) component1 == (UnityEngine.Object) null)
      return false;
    Image component2 = BtnT.GetComponent<Image>();
    ((Behaviour) component2).enabled = true;
    ((Graphic) component2).color = new Color(1f, 1f, 1f, 0.0f);
    component2.sprite = (Sprite) null;
    ((MaskableGraphic) component2).material = this.m_IconSpriteAsset.GetMaterial();
    component1.HeroOrItem = (byte) HeroOrItem;
    component1.HIID = HIID;
    switch (HeroOrItem)
    {
      case eHeroOrItem.Hero:
        Vector2 vector2_1 = new Vector2(0.0f, 0.0f);
        Vector2 vector2_2 = new Vector2(1f, 1f);
        if (bAutoShowHint)
          BtnT.gameObject.AddComponent<UIButtonHint>();
        GameObject gameObject1 = new GameObject("HIImg");
        gameObject1.layer = 5;
        RectTransform rectTransform1 = gameObject1.AddComponent<RectTransform>();
        vector2_1.Set(9f / 128f, 9f / 128f);
        rectTransform1.anchorMin = vector2_1;
        vector2_2.Set(119f / 128f, 119f / 128f);
        rectTransform1.anchorMax = vector2_2;
        rectTransform1.offsetMin = Vector2.zero;
        rectTransform1.offsetMax = Vector2.zero;
        gameObject1.AddComponent<IgnoreRaycast>();
        component1.HIImage = gameObject1.AddComponent<Image>();
        gameObject1.transform.SetParent(BtnT, false);
        Hero recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(HIID);
        component1.HIImage.sprite = this.m_IconSpriteAsset.LoadSprite(recordByKey1.Graph);
        ((MaskableGraphic) component1.HIImage).material = this.m_IconSpriteAsset.GetMaterial();
        if ((UnityEngine.Object) component1.HIImage.sprite == (UnityEngine.Object) null)
        {
          component1.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite((ushort) 1130);
          ((MaskableGraphic) component1.HIImage).material = this.m_ItemIconSpriteAsset.GetMaterial();
        }
        component1.targetGraphic = (Graphic) component1.HIImage;
        component2.sprite = component1.HIImage.sprite;
        if (bShowText)
        {
          GameObject gameObject2 = new GameObject("TextImg");
          gameObject2.layer = 5;
          RectTransform rectTransform2 = gameObject2.AddComponent<RectTransform>();
          vector2_1.Set(0.4218f, 5f / 64f);
          rectTransform2.anchorMin = vector2_1;
          vector2_2.Set(0.93f, 0.31f);
          rectTransform2.anchorMax = vector2_2;
          rectTransform2.offsetMin = Vector2.zero;
          rectTransform2.offsetMax = Vector2.zero;
          gameObject2.AddComponent<IgnoreRaycast>();
          component1.TextImage = gameObject2.AddComponent<Image>();
          component1.TextImage.sprite = this.LoadFrameSprite("UI_black_top");
          ((MaskableGraphic) component1.TextImage).material = this.GetFrameMaterial();
          Color color = ((Graphic) component1.TextImage).color with
          {
            a = 0.67f
          };
          ((Graphic) component1.TextImage).color = color;
          gameObject2.transform.SetParent(BtnT, false);
          if (LvOrNum != 0)
            gameObject2.SetActive(true);
          else
            gameObject2.SetActive(false);
        }
        GameObject gameObject3 = new GameObject("CircleImg");
        gameObject3.layer = 5;
        RectTransform rectTransform3 = gameObject3.AddComponent<RectTransform>();
        vector2_1.Set(0.0f, 0.0f);
        rectTransform3.anchorMin = vector2_1;
        vector2_2.Set(1f, 1f);
        rectTransform3.anchorMax = vector2_2;
        rectTransform3.offsetMin = Vector2.zero;
        rectTransform3.offsetMax = Vector2.zero;
        gameObject3.AddComponent<IgnoreRaycast>();
        component1.CircleImage = gameObject3.AddComponent<Image>();
        gameObject3.transform.SetParent(BtnT, false);
        ((MaskableGraphic) component1.CircleImage).material = this.GetFrameMaterial();
        if (Circle != (byte) 0)
        {
          component1.CircleImage.sprite = this.LoadFrameSprite(EFrameSprite.Hero, Circle);
          gameObject3.SetActive(true);
        }
        else
          gameObject3.SetActive(false);
        GameObject gameObject4 = new GameObject("HeroRankImg");
        gameObject4.layer = 5;
        RectTransform rectTransform4 = gameObject4.AddComponent<RectTransform>();
        vector2_1.Set(-0.06f, 0.0f);
        rectTransform4.anchorMin = vector2_1;
        vector2_2.Set(0.368125f, 0.428125f);
        rectTransform4.anchorMax = vector2_2;
        rectTransform4.offsetMin = Vector2.zero;
        rectTransform4.offsetMax = Vector2.zero;
        gameObject4.AddComponent<IgnoreRaycast>();
        component1.HeroRankImage = gameObject4.AddComponent<Image>();
        gameObject4.transform.SetParent(BtnT, false);
        ((MaskableGraphic) component1.HeroRankImage).material = this.GetFrameMaterial();
        if (Rank != (byte) 0)
        {
          component1.HeroRankImage.sprite = this.LoadFrameSprite(EFrameSprite.Hero, (byte) ((uint) Rank + 100U));
          gameObject4.SetActive(true);
        }
        else
          gameObject4.SetActive(false);
        if (bShowText)
        {
          GameObject gameObject5 = new GameObject("LvOrNumText");
          gameObject5.layer = 5;
          RectTransform rectTransform5 = gameObject5.AddComponent<RectTransform>();
          vector2_1.Set(0.5f, 0.069f);
          rectTransform5.anchorMin = vector2_1;
          vector2_2.Set(0.9f, 0.328f);
          rectTransform5.anchorMax = vector2_2;
          rectTransform5.offsetMin = Vector2.zero;
          rectTransform5.offsetMax = Vector2.zero;
          gameObject5.AddComponent<IgnoreRaycast>();
          component1.LvOrNum = gameObject5.AddComponent<UIText>();
          ((Shadow) gameObject5.AddComponent<Outline>()).effectColor = new Color(0.0f, 0.0f, 0.0f, 1f);
          gameObject5.transform.SetParent(BtnT, false);
          component1.LvOrNum.alignment = TextAnchor.MiddleRight;
          component1.LvOrNum.supportRichText = true;
          component1.LvOrNum.resizeTextForBestFit = true;
          component1.LvOrNum.font = this.m_TTFFont;
          if (LvOrNum != 0)
          {
            component1.LvOrNum.text = LvOrNum.ToString();
            gameObject5.SetActive(true);
            break;
          }
          gameObject5.SetActive(false);
          break;
        }
        break;
      case eHeroOrItem.Item:
        this.SetItemScaleClickSound(component1, bScaleBtn, bClickSound);
        Vector2 vector2_3 = new Vector2(0.0f, 0.0f);
        Vector2 vector2_4 = new Vector2(1f, 1f);
        if (bAutoShowHint)
          BtnT.gameObject.AddComponent<UIButtonHint>();
        Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(HIID);
        GameObject gameObject6 = new GameObject("HIImg");
        gameObject6.layer = 5;
        RectTransform rectTransform6 = gameObject6.AddComponent<RectTransform>();
        byte num1 = (byte) ((uint) recordByKey2.EquipKind - 1U);
        if (num1 == (byte) 2 || num1 == (byte) 3 && recordByKey2.SyntheticParts[1].SyntheticItemNum == (byte) 1)
        {
          vector2_3.Set(0.25f, 0.3f);
          vector2_4.Set(0.7625f, 13f / 16f);
        }
        else if (num1 == (byte) 4 || num1 == (byte) 28 || num1 == (byte) 9 && recordByKey2.PropertiesInfo[0].Propertieskey == (ushort) 45)
        {
          vector2_3.Set(1f / 16f, 0.1125f);
          vector2_4.Set(15f / 16f, 0.9875f);
        }
        else
        {
          vector2_3.Set(1f / 16f, 1f / 16f);
          vector2_4.Set(15f / 16f, 15f / 16f);
        }
        rectTransform6.anchorMin = vector2_3;
        rectTransform6.anchorMax = vector2_4;
        rectTransform6.offsetMin = Vector2.zero;
        rectTransform6.offsetMax = Vector2.zero;
        gameObject6.AddComponent<IgnoreRaycast>();
        component1.HIImage = gameObject6.AddComponent<Image>();
        gameObject6.transform.SetParent(BtnT, false);
        switch (num1)
        {
          case 4:
          case 28:
          case 29:
            component1.HIImage.sprite = this.m_IconSpriteAsset.LoadSprite(recordByKey2.EquipPicture);
            ((MaskableGraphic) component1.HIImage).material = this.m_IconSpriteAsset.GetMaterial();
            break;
          case 9:
            if (recordByKey2.PropertiesInfo[0].Propertieskey != (ushort) 45)
              goto default;
            else
              goto case 4;
          default:
            component1.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite(recordByKey2.EquipPicture);
            ((MaskableGraphic) component1.HIImage).material = this.m_ItemIconSpriteAsset.GetMaterial();
            break;
        }
        if ((UnityEngine.Object) component1.HIImage.sprite == (UnityEngine.Object) null)
        {
          component1.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite((ushort) 1130);
          ((MaskableGraphic) component1.HIImage).material = this.m_ItemIconSpriteAsset.GetMaterial();
        }
        component1.targetGraphic = (Graphic) component1.HIImage;
        component2.sprite = component1.HIImage.sprite;
        ((MaskableGraphic) component2).material = this.m_ItemIconSpriteAsset.GetMaterial();
        if (this.IsArabic)
        {
          if (num1 == (byte) 4 || num1 == (byte) 29 || num1 == (byte) 9 && recordByKey2.PropertiesInfo[0].Propertieskey == (ushort) 45)
            ((Transform) ((Graphic) component1.HIImage).rectTransform).localScale = new Vector3(1f, 1f, 1f);
          else if (num1 == (byte) 28)
            ((Transform) rectTransform6).localScale = new Vector3(0.9f, 0.9f, 0.9f);
          else
            ((Transform) ((Graphic) component1.HIImage).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (num1 == (byte) 28)
          ((Transform) rectTransform6).localScale = new Vector3(0.9f, 0.9f, 0.9f);
        else
          ((Transform) rectTransform6).localScale = Vector3.one;
        GameObject gameObject7 = new GameObject("CircleImg");
        gameObject7.layer = 5;
        RectTransform rectTransform7 = gameObject7.AddComponent<RectTransform>();
        vector2_3.Set(0.0f, 0.0f);
        rectTransform7.anchorMin = vector2_3;
        vector2_4.Set(1f, 1f);
        rectTransform7.anchorMax = vector2_4;
        rectTransform7.offsetMin = Vector2.zero;
        rectTransform7.offsetMax = Vector2.zero;
        gameObject7.AddComponent<IgnoreRaycast>();
        component1.CircleImage = gameObject7.AddComponent<Image>();
        gameObject7.transform.SetParent(BtnT, false);
        ((MaskableGraphic) component1.CircleImage).material = this.GetFrameMaterial();
        if (recordByKey2.Color != (byte) 0)
        {
          component1.CircleImage.sprite = num1 != (byte) 4 ? (num1 != (byte) 28 ? (num1 != (byte) 9 || recordByKey2.PropertiesInfo[0].Propertieskey != (ushort) 45 ? (num1 != (byte) 29 ? this.LoadFrameSprite(EFrameSprite.Item, recordByKey2.Color) : this.LoadFrameSprite(EFrameSprite.Pet, Circle)) : this.LoadFrameSprite("if202")) : this.LoadFrameSprite("if201")) : this.LoadFrameSprite("if102");
          gameObject7.SetActive(true);
        }
        else
          gameObject7.SetActive(false);
        GameObject gameObject8 = new GameObject("ChipBookImg2");
        gameObject8.layer = 5;
        RectTransform rectTransform8 = gameObject8.AddComponent<RectTransform>();
        vector2_3.Set(0.0f, 0.0f);
        rectTransform8.anchorMin = vector2_3;
        vector2_4.Set(1f, 1f);
        rectTransform8.anchorMax = vector2_4;
        rectTransform8.offsetMin = Vector2.zero;
        rectTransform8.offsetMax = Vector2.zero;
        gameObject8.AddComponent<IgnoreRaycast>();
        component1.ChipBookImage = gameObject8.AddComponent<Image>();
        gameObject8.transform.SetParent(BtnT, false);
        ((MaskableGraphic) component1.ChipBookImage).material = this.GetFrameMaterial();
        switch (num1)
        {
          case 2:
            component1.ChipBookImage.sprite = this.LoadFrameSprite("if101");
            gameObject8.SetActive(true);
            break;
          case 3:
            component1.ChipBookImage.sprite = recordByKey2.SyntheticParts[1].SyntheticItemNum != (byte) 1 ? this.LoadFrameSprite("gf001") : this.LoadFrameSprite("gf002");
            gameObject8.SetActive(true);
            break;
          default:
            gameObject8.SetActive(false);
            break;
        }
        StringBuilder sb = new StringBuilder();
        bool specialNumText = this.GetSpecialNumText(sb, HIID);
        GameObject gameObject9 = new GameObject("TextImg");
        gameObject9.layer = 5;
        RectTransform rectTransform9 = gameObject9.AddComponent<RectTransform>();
        rectTransform9.offsetMin = Vector2.zero;
        rectTransform9.offsetMax = Vector2.zero;
        gameObject9.AddComponent<IgnoreRaycast>();
        component1.TextImage = gameObject9.AddComponent<Image>();
        component1.TextImage.sprite = this.LoadFrameSprite("UI_black_top");
        ((MaskableGraphic) component1.TextImage).material = this.GetFrameMaterial();
        Color color1 = ((Graphic) component1.TextImage).color with
        {
          a = 0.67f
        };
        ((Graphic) component1.TextImage).color = color1;
        if (specialNumText)
        {
          vector2_3.Set(-0.1f, 0.06f);
          rectTransform9.anchorMin = vector2_3;
          vector2_4.Set(0.93f, 0.4f);
          rectTransform9.anchorMax = vector2_4;
          gameObject9.SetActive(true);
        }
        else
        {
          vector2_3.Set(0.4218f, 5f / 64f);
          rectTransform9.anchorMin = vector2_3;
          vector2_4.Set(0.9f, 0.31f);
          rectTransform9.anchorMax = vector2_4;
          if (LvOrNum != 0 && num1 != (byte) 4)
            gameObject9.SetActive(true);
          else
            gameObject9.SetActive(false);
        }
        gameObject9.transform.SetParent(BtnT, false);
        GameObject gameObject10 = new GameObject("LvOrNumText");
        gameObject10.layer = 5;
        RectTransform rectTransform10 = gameObject10.AddComponent<RectTransform>();
        rectTransform10.offsetMin = Vector2.zero;
        rectTransform10.offsetMax = Vector2.zero;
        gameObject10.AddComponent<IgnoreRaycast>();
        component1.LvOrNum = gameObject10.AddComponent<UIText>();
        ((Shadow) gameObject10.AddComponent<Outline>()).effectColor = new Color(0.0f, 0.0f, 0.0f, 1f);
        if (specialNumText)
          component1.LvOrNum.alignment = TextAnchor.LowerCenter;
        else
          component1.LvOrNum.alignment = TextAnchor.MiddleRight;
        component1.LvOrNum.supportRichText = true;
        component1.LvOrNum.resizeTextForBestFit = true;
        component1.LvOrNum.font = this.m_TTFFont;
        if (specialNumText)
        {
          vector2_3.Set(0.1f, 0.03f);
          rectTransform10.anchorMin = vector2_3;
          vector2_4.Set(0.9f, 0.4f);
          rectTransform10.anchorMax = vector2_4;
          component1.LvOrNum.text = sb.ToString();
          gameObject10.SetActive(true);
        }
        else
        {
          vector2_3.Set(0.1f, 0.076f);
          rectTransform10.anchorMin = vector2_3;
          vector2_4.Set(0.9f, 0.335f);
          rectTransform10.anchorMax = vector2_4;
          if (LvOrNum != 0)
          {
            component1.LvOrNum.text = LvOrNum.ToString();
            gameObject10.SetActive(true);
          }
          else
            gameObject10.SetActive(false);
        }
        gameObject10.transform.SetParent(BtnT, false);
        break;
      case eHeroOrItem.Pet:
        Vector2 vector2_5 = new Vector2(0.0f, 0.0f);
        Vector2 vector2_6 = new Vector2(1f, 1f);
        if (bAutoShowHint)
          BtnT.gameObject.AddComponent<UIButtonHint>();
        GameObject gameObject11 = new GameObject("HIImg");
        gameObject11.layer = 5;
        RectTransform rectTransform11 = gameObject11.AddComponent<RectTransform>();
        vector2_5.Set(9f / 128f, 9f / 128f);
        rectTransform11.anchorMin = vector2_5;
        vector2_6.Set(119f / 128f, 119f / 128f);
        rectTransform11.anchorMax = vector2_6;
        rectTransform11.offsetMin = Vector2.zero;
        rectTransform11.offsetMax = Vector2.zero;
        gameObject11.AddComponent<IgnoreRaycast>();
        component1.HIImage = gameObject11.AddComponent<Image>();
        gameObject11.transform.SetParent(BtnT, false);
        Hero recordByKey3 = DataManager.Instance.HeroTable.GetRecordByKey(PetManager.Instance.PetTable.GetRecordByKey(HIID).HeroID);
        component1.HIImage.sprite = this.m_IconSpriteAsset.LoadSprite(recordByKey3.Graph);
        ((MaskableGraphic) component1.HIImage).material = this.m_IconSpriteAsset.GetMaterial();
        if ((UnityEngine.Object) component1.HIImage.sprite == (UnityEngine.Object) null)
        {
          component1.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite((ushort) 1130);
          ((MaskableGraphic) component1.HIImage).material = this.m_ItemIconSpriteAsset.GetMaterial();
        }
        component1.targetGraphic = (Graphic) component1.HIImage;
        component2.sprite = component1.HIImage.sprite;
        if (bShowText)
        {
          GameObject gameObject12 = new GameObject("TextImg");
          gameObject12.layer = 5;
          RectTransform rectTransform12 = gameObject12.AddComponent<RectTransform>();
          vector2_5.Set(0.4218f, 5f / 64f);
          rectTransform12.anchorMin = vector2_5;
          vector2_6.Set(0.93f, 0.31f);
          rectTransform12.anchorMax = vector2_6;
          rectTransform12.offsetMin = Vector2.zero;
          rectTransform12.offsetMax = Vector2.zero;
          gameObject12.AddComponent<IgnoreRaycast>();
          component1.TextImage = gameObject12.AddComponent<Image>();
          component1.TextImage.sprite = this.LoadFrameSprite("UI_black_top");
          ((MaskableGraphic) component1.TextImage).material = this.GetFrameMaterial();
          Color color2 = ((Graphic) component1.TextImage).color with
          {
            a = 0.67f
          };
          ((Graphic) component1.TextImage).color = color2;
          gameObject12.transform.SetParent(BtnT, false);
          if (LvOrNum != 0)
            gameObject12.SetActive(true);
          else
            gameObject12.SetActive(false);
        }
        GameObject gameObject13 = new GameObject("CircleImg");
        gameObject13.layer = 5;
        RectTransform rectTransform13 = gameObject13.AddComponent<RectTransform>();
        vector2_5.Set(0.0f, 0.0f);
        rectTransform13.anchorMin = vector2_5;
        vector2_6.Set(1f, 1f);
        rectTransform13.anchorMax = vector2_6;
        rectTransform13.offsetMin = Vector2.zero;
        rectTransform13.offsetMax = Vector2.zero;
        gameObject13.AddComponent<IgnoreRaycast>();
        component1.CircleImage = gameObject13.AddComponent<Image>();
        gameObject13.transform.SetParent(BtnT, false);
        ((MaskableGraphic) component1.CircleImage).material = this.GetFrameMaterial();
        component1.CircleImage.sprite = HIID != (ushort) 0 ? this.LoadFrameSprite(EFrameSprite.Pet, Circle) : this.LoadFrameSprite("hf000_b");
        gameObject13.SetActive(true);
        float num2 = ((Component) component1).GetComponent<RectTransform>().rect.width / component1.CircleImage.sprite.rect.width;
        GameObject gameObject14 = new GameObject("PetRareImg");
        gameObject14.layer = 5;
        RectTransform rectTransform14 = gameObject14.AddComponent<RectTransform>();
        vector2_5.Set(0.5f, 0.5f);
        rectTransform14.anchorMin = vector2_5;
        vector2_6.Set(0.5f, 0.5f);
        rectTransform14.anchorMax = vector2_6;
        rectTransform14.offsetMin = Vector2.zero;
        rectTransform14.offsetMax = Vector2.zero;
        rectTransform14.anchoredPosition = new Vector2(-49f * num2, -35f * num2);
        ((Transform) rectTransform14).localScale = new Vector3(num2 * 0.9f, num2 * 0.9f, num2 * 0.9f);
        gameObject14.AddComponent<IgnoreRaycast>();
        component1.HeroRankImage = gameObject14.AddComponent<Image>();
        gameObject14.transform.SetParent(BtnT, false);
        ((MaskableGraphic) component1.HeroRankImage).material = this.GetFrameMaterial();
        component1.HeroRankImage.sprite = this.LoadFrameSprite("UI_mp_rarity");
        component1.HeroRankImage.SetNativeSize();
        GameObject gameObject15 = new GameObject("PetRareText", new System.Type[1]
        {
          typeof (UIText)
        });
        gameObject15.AddComponent<Outline>();
        gameObject15.AddComponent<Shadow>();
        component1.PetRareText = gameObject15.transform.GetComponent<UIText>();
        component1.PetRareText.font = this.GetTTFFont();
        gameObject15.transform.SetParent((Transform) rectTransform14, false);
        RectTransform rectTransform15 = ((Graphic) component1.PetRareText).rectTransform;
        RectTransform rectTransform16 = rectTransform15;
        Vector2 vector2_7 = new Vector2(0.5f, 0.5f);
        rectTransform15.pivot = vector2_7;
        Vector2 vector2_8 = vector2_7;
        rectTransform15.anchorMin = vector2_8;
        Vector2 vector2_9 = vector2_8;
        rectTransform16.anchorMax = vector2_9;
        rectTransform15.sizeDelta = new Vector2(48f, 58f);
        rectTransform15.anchoredPosition = Vector2.zero;
        component1.PetRareText.supportRichText = false;
        component1.PetRareText.resizeTextForBestFit = false;
        component1.PetRareText.fontSize = 18;
        component1.PetRareText.alignment = TextAnchor.MiddleCenter;
        if (Rank != (byte) 0)
        {
          ((Component) component1.HeroRankImage).gameObject.SetActive(true);
          component1.SetPetRare(Rank);
        }
        else
          ((Component) component1.HeroRankImage).gameObject.SetActive(false);
        if (bShowText)
        {
          GameObject gameObject16 = new GameObject("LvOrNumText");
          gameObject16.layer = 5;
          RectTransform rectTransform17 = gameObject16.AddComponent<RectTransform>();
          vector2_5.Set(0.5f, 0.069f);
          rectTransform17.anchorMin = vector2_5;
          vector2_6.Set(0.9f, 0.328f);
          rectTransform17.anchorMax = vector2_6;
          rectTransform17.offsetMin = Vector2.zero;
          rectTransform17.offsetMax = Vector2.zero;
          gameObject16.AddComponent<IgnoreRaycast>();
          component1.LvOrNum = gameObject16.AddComponent<UIText>();
          ((Shadow) gameObject16.AddComponent<Outline>()).effectColor = new Color(0.0f, 0.0f, 0.0f, 1f);
          gameObject16.transform.SetParent(BtnT, false);
          component1.LvOrNum.alignment = TextAnchor.MiddleRight;
          component1.LvOrNum.supportRichText = true;
          component1.LvOrNum.resizeTextForBestFit = true;
          component1.LvOrNum.font = this.m_TTFFont;
          if (LvOrNum != 0)
          {
            component1.LvOrNum.text = LvOrNum.ToString();
            gameObject16.SetActive(true);
            break;
          }
          gameObject16.SetActive(false);
          break;
        }
        break;
      default:
        return false;
    }
    return true;
  }

  public void ChangeHeroItemImg(
    Transform BtnT,
    eHeroOrItem HeroOrItem,
    ushort HIID,
    byte Circle = 0,
    byte Rank = 0,
    int LvOrNum = 0)
  {
    UIHIBtn component = BtnT.GetComponent<UIHIBtn>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
      return;
    component.HeroOrItem = (byte) HeroOrItem;
    component.HIID = HIID;
    switch (HeroOrItem)
    {
      case eHeroOrItem.Hero:
        Hero recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(HIID);
        component.HIImage.sprite = this.m_IconSpriteAsset.LoadSprite(recordByKey1.Graph);
        ((MaskableGraphic) component.HIImage).material = this.m_IconSpriteAsset.GetMaterial();
        if ((UnityEngine.Object) component.HIImage.sprite == (UnityEngine.Object) null)
        {
          component.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite((ushort) 1130);
          ((MaskableGraphic) component.HIImage).material = this.m_ItemIconSpriteAsset.GetMaterial();
        }
        component.targetGraphic = (Graphic) component.HIImage;
        if (Circle != (byte) 0)
        {
          component.CircleImage.sprite = this.LoadFrameSprite(EFrameSprite.Hero, Circle);
          if (!((Component) component.CircleImage).gameObject.activeInHierarchy)
            ((Component) component.CircleImage).gameObject.SetActive(true);
        }
        else
          ((Component) component.CircleImage).gameObject.SetActive(false);
        if (Rank != (byte) 0)
        {
          component.HeroRankImage.sprite = this.LoadFrameSprite(EFrameSprite.Hero, (byte) ((uint) Rank + 100U));
          ((MaskableGraphic) component.HeroRankImage).material = this.GetFrameMaterial();
          if (!((Component) component.HeroRankImage).gameObject.activeInHierarchy)
            ((Component) component.HeroRankImage).gameObject.SetActive(true);
        }
        else
          ((Component) component.HeroRankImage).gameObject.SetActive(false);
        if (!((UnityEngine.Object) component.LvOrNum != (UnityEngine.Object) null))
          break;
        if (LvOrNum != 0)
        {
          component.LvOrNum.text = LvOrNum.ToString();
          if (!((Component) component.TextImage).gameObject.activeInHierarchy)
            ((Component) component.TextImage).gameObject.SetActive(true);
          if (((Component) component.LvOrNum).gameObject.activeInHierarchy)
            break;
          ((Component) component.LvOrNum).gameObject.SetActive(true);
          break;
        }
        ((Component) component.LvOrNum).gameObject.SetActive(false);
        ((Component) component.TextImage).gameObject.SetActive(false);
        break;
      case eHeroOrItem.Item:
        Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(HIID);
        Vector2 vector2_1 = new Vector2(0.0f, 0.0f);
        Vector2 vector2_2 = new Vector2(1f, 1f);
        byte num = (byte) ((uint) recordByKey2.EquipKind - 1U);
        switch (num)
        {
          case 4:
          case 28:
          case 29:
            component.HIImage.sprite = this.m_IconSpriteAsset.LoadSprite(recordByKey2.EquipPicture);
            ((MaskableGraphic) component.HIImage).material = this.m_IconSpriteAsset.GetMaterial();
            break;
          case 9:
            if (recordByKey2.PropertiesInfo[0].Propertieskey != (ushort) 45)
              goto default;
            else
              goto case 4;
          default:
            component.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite(recordByKey2.EquipPicture);
            ((MaskableGraphic) component.HIImage).material = this.m_ItemIconSpriteAsset.GetMaterial();
            break;
        }
        if ((UnityEngine.Object) component.HIImage.sprite == (UnityEngine.Object) null)
        {
          component.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite((ushort) 1130);
          ((MaskableGraphic) component.HIImage).material = this.m_ItemIconSpriteAsset.GetMaterial();
        }
        component.targetGraphic = (Graphic) component.HIImage;
        if (this.IsArabic)
        {
          if (num == (byte) 4 || num == (byte) 29 || num == (byte) 9 && recordByKey2.PropertiesInfo[0].Propertieskey == (ushort) 45)
            ((Transform) ((Graphic) component.HIImage).rectTransform).localScale = new Vector3(1f, 1f, 1f);
          else if (num == (byte) 28)
            ((Transform) ((Graphic) component.HIImage).rectTransform).localScale = new Vector3(0.9f, 0.9f, 0.9f);
          else
            ((Transform) ((Graphic) component.HIImage).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (num == (byte) 28)
          ((Transform) ((Graphic) component.HIImage).rectTransform).localScale = new Vector3(0.9f, 0.9f, 0.9f);
        else
          ((Transform) ((Graphic) component.HIImage).rectTransform).localScale = Vector3.one;
        RectTransform rectTransform1 = ((Graphic) component.HIImage).rectTransform;
        if (num == (byte) 2 || num == (byte) 3 && recordByKey2.SyntheticParts[1].SyntheticItemNum == (byte) 1)
        {
          vector2_1.Set(0.25f, 0.3f);
          vector2_2.Set(0.7625f, 13f / 16f);
        }
        else if (num == (byte) 4 || num == (byte) 28 || num == (byte) 9 && recordByKey2.PropertiesInfo[0].Propertieskey == (ushort) 45)
        {
          vector2_1.Set(1f / 16f, 0.1125f);
          vector2_2.Set(15f / 16f, 0.9875f);
        }
        else
        {
          vector2_1.Set(1f / 16f, 1f / 16f);
          vector2_2.Set(15f / 16f, 15f / 16f);
        }
        rectTransform1.anchorMin = vector2_1;
        rectTransform1.anchorMax = vector2_2;
        switch (num)
        {
          case 2:
            component.ChipBookImage.sprite = this.LoadFrameSprite("if101");
            ((MaskableGraphic) component.ChipBookImage).material = this.GetFrameMaterial();
            if (!((Component) component.ChipBookImage).gameObject.activeInHierarchy)
            {
              ((Component) component.ChipBookImage).gameObject.SetActive(true);
              break;
            }
            break;
          case 3:
            component.ChipBookImage.sprite = recordByKey2.SyntheticParts[1].SyntheticItemNum != (byte) 1 ? this.LoadFrameSprite("gf001") : this.LoadFrameSprite("gf002");
            ((MaskableGraphic) component.ChipBookImage).material = this.GetFrameMaterial();
            if (!((Component) component.ChipBookImage).gameObject.activeInHierarchy)
            {
              ((Component) component.ChipBookImage).gameObject.SetActive(true);
              break;
            }
            break;
          default:
            ((Component) component.ChipBookImage).gameObject.SetActive(false);
            break;
        }
        if (recordByKey2.Color != (byte) 0)
        {
          component.CircleImage.sprite = num != (byte) 4 ? (num != (byte) 28 ? (num != (byte) 9 || recordByKey2.PropertiesInfo[0].Propertieskey != (ushort) 45 ? (num != (byte) 29 ? this.LoadFrameSprite(EFrameSprite.Item, recordByKey2.Color) : this.LoadFrameSprite(EFrameSprite.Pet, Circle)) : this.LoadFrameSprite("if202")) : this.LoadFrameSprite("if201")) : this.LoadFrameSprite("if102");
          if (!((Component) component.CircleImage).gameObject.activeInHierarchy)
            ((Component) component.CircleImage).gameObject.SetActive(true);
        }
        else
          ((Component) component.CircleImage).gameObject.SetActive(false);
        StringBuilder sb = new StringBuilder();
        if (this.GetSpecialNumText(sb, HIID))
        {
          if ((UnityEngine.Object) component.TextImage != (UnityEngine.Object) null)
          {
            RectTransform rectTransform2 = ((Graphic) component.TextImage).rectTransform;
            vector2_1.Set(-0.1f, 0.06f);
            rectTransform2.anchorMin = vector2_1;
            vector2_2.Set(0.93f, 0.4f);
            rectTransform2.anchorMax = vector2_2;
          }
          if ((UnityEngine.Object) component.LvOrNum != (UnityEngine.Object) null)
          {
            RectTransform rectTransform3 = ((Graphic) component.LvOrNum).rectTransform;
            vector2_1.Set(0.1f, 0.03f);
            rectTransform3.anchorMin = vector2_1;
            vector2_2.Set(0.9f, 0.4f);
            rectTransform3.anchorMax = vector2_2;
            component.LvOrNum.text = sb.ToString();
          }
          component.LvOrNum.alignment = TextAnchor.LowerCenter;
          if (!((Component) component.TextImage).gameObject.activeInHierarchy)
            ((Component) component.TextImage).gameObject.SetActive(true);
          if (((Component) component.LvOrNum).gameObject.activeInHierarchy)
            break;
          ((Component) component.LvOrNum).gameObject.SetActive(true);
          break;
        }
        if ((UnityEngine.Object) component.TextImage != (UnityEngine.Object) null)
        {
          RectTransform rectTransform4 = ((Graphic) component.TextImage).rectTransform;
          vector2_1.Set(0.4218f, 5f / 64f);
          rectTransform4.anchorMin = vector2_1;
          vector2_2.Set(0.9f, 0.31f);
          rectTransform4.anchorMax = vector2_2;
        }
        if (!((UnityEngine.Object) component.LvOrNum != (UnityEngine.Object) null))
          break;
        RectTransform rectTransform5 = ((Graphic) component.LvOrNum).rectTransform;
        vector2_1.Set(0.1f, 0.076f);
        rectTransform5.anchorMin = vector2_1;
        vector2_2.Set(0.9f, 0.335f);
        rectTransform5.anchorMax = vector2_2;
        if (LvOrNum != 0)
        {
          component.LvOrNum.alignment = TextAnchor.MiddleRight;
          component.LvOrNum.text = LvOrNum.ToString("N0");
          if (!((Component) component.TextImage).gameObject.activeInHierarchy && recordByKey2.EquipKind != (byte) 5)
            ((Component) component.TextImage).gameObject.SetActive(true);
          if (((Component) component.LvOrNum).gameObject.activeInHierarchy)
            break;
          ((Component) component.LvOrNum).gameObject.SetActive(true);
          break;
        }
        ((Component) component.LvOrNum).gameObject.SetActive(false);
        ((Component) component.TextImage).gameObject.SetActive(false);
        break;
      case eHeroOrItem.Pet:
        Hero recordByKey3 = DataManager.Instance.HeroTable.GetRecordByKey(PetManager.Instance.PetTable.GetRecordByKey(HIID).HeroID);
        component.HIImage.sprite = this.m_IconSpriteAsset.LoadSprite(recordByKey3.Graph);
        ((MaskableGraphic) component.HIImage).material = this.m_IconSpriteAsset.GetMaterial();
        if ((UnityEngine.Object) component.HIImage.sprite == (UnityEngine.Object) null)
        {
          component.HIImage.sprite = this.m_ItemIconSpriteAsset.LoadSprite((ushort) 1130);
          ((MaskableGraphic) component.HIImage).material = this.m_ItemIconSpriteAsset.GetMaterial();
        }
        component.targetGraphic = (Graphic) component.HIImage;
        component.CircleImage.sprite = HIID != (ushort) 0 ? this.LoadFrameSprite(EFrameSprite.Pet, Circle) : this.LoadFrameSprite("hf000_b");
        if (!((Component) component.CircleImage).gameObject.activeInHierarchy)
          ((Component) component.CircleImage).gameObject.SetActive(true);
        if ((UnityEngine.Object) component.LvOrNum != (UnityEngine.Object) null)
        {
          if (LvOrNum != 0)
          {
            component.LvOrNum.text = LvOrNum.ToString();
            if (!((Component) component.TextImage).gameObject.activeInHierarchy)
              ((Component) component.TextImage).gameObject.SetActive(true);
            if (!((Component) component.LvOrNum).gameObject.activeInHierarchy)
              ((Component) component.LvOrNum).gameObject.SetActive(true);
          }
          else
          {
            ((Component) component.LvOrNum).gameObject.SetActive(false);
            ((Component) component.TextImage).gameObject.SetActive(false);
          }
        }
        if (Rank != (byte) 0)
        {
          ((Component) component.HeroRankImage).gameObject.SetActive(true);
          if ((UnityEngine.Object) component.PetRareText == (UnityEngine.Object) null)
            component.PetRareText = ((Component) component.HeroRankImage).transform.GetChild(0).GetComponent<UIText>();
          component.SetPetRare(Rank);
          break;
        }
        ((Component) component.HeroRankImage).gameObject.SetActive(false);
        break;
    }
  }

  public void ChangeWonderImg(Transform BtnT, byte WonderID, ushort KingdomID = 0)
  {
    UIHIBtn component = BtnT.GetComponent<UIHIBtn>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
      return;
    component.HeroOrItem = (byte) 2;
    component.HIID = (ushort) WonderID;
    component.HIImage.sprite = this.GetWonderSprite(WonderID, KingdomID, (byte) 0);
    ((MaskableGraphic) component.HIImage).material = this._m_WonderMaterial;
    component.CircleImage.sprite = this.LoadFrameSprite(EFrameSprite.Hero, (byte) 11);
    ((Component) component.HeroRankImage).gameObject.SetActive(false);
  }

  public void ChangeNPCImg(Transform BtnT)
  {
    UIHIBtn component = BtnT.GetComponent<UIHIBtn>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
      return;
    component.HeroOrItem = (byte) 3;
    component.HIImage.sprite = this.NpcHead;
    ((MaskableGraphic) component.HIImage).material = this._m_WonderMaterial;
    component.CircleImage.sprite = this.LoadFrameSprite(EFrameSprite.Hero, (byte) 11);
    ((Component) component.HeroRankImage).gameObject.SetActive(false);
  }

  public bool GetSpecialNumText(StringBuilder sb, ushort ItemID)
  {
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(ItemID);
    bool specialNumText = false;
    byte num1 = (byte) ((uint) recordByKey.EquipKind - 1U);
    if (num1 == (byte) 10 && recordByKey.PropertiesInfo[0].Propertieskey <= (ushort) 8 || num1 == (byte) 9 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 30 || num1 == (byte) 9 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 33 || num1 == (byte) 9 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 40 || num1 == (byte) 9 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 49)
    {
      specialNumText = true;
      uint num2 = (uint) recordByKey.PropertiesInfo[1].Propertieskey * (uint) recordByKey.PropertiesInfo[1].PropertiesValue;
      GameConstants.FormatResourceValue(sb, num2);
    }
    else if (num1 == (byte) 12 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 1)
    {
      specialNumText = true;
      GameConstants.FormatResourceValue(sb, (uint) recordByKey.PropertiesInfo[1].Propertieskey);
    }
    else if (num1 == (byte) 11 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 1 || num1 == (byte) 11 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 12 || num1 == (byte) 11 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 17 || num1 == (byte) 11 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 18 || num1 == (byte) 11 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 21 || num1 == (byte) 11 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 22 || num1 == (byte) 13 && recordByKey.PropertiesInfo[0].Propertieskey <= (ushort) 2)
    {
      specialNumText = true;
      ushort propertieskey = recordByKey.PropertiesInfo[1].Propertieskey;
      if (propertieskey <= (ushort) 60)
        sb.AppendFormat("{0}m", (object) propertieskey);
      else if (propertieskey > (ushort) 60 && propertieskey <= (ushort) 1440)
        sb.AppendFormat("{0}h", (object) (ushort) ((uint) propertieskey / 60U));
      else if (propertieskey > (ushort) 1440)
        sb.AppendFormat("{0}d", (object) (ushort) ((int) propertieskey / 60 / 24));
    }
    return specialNumText;
  }

  public void SetItemScaleClickSound(UIHIBtn tmpHI, bool bEnableScasle, bool bEnableSound)
  {
    if ((UnityEngine.Object) tmpHI == (UnityEngine.Object) null)
      return;
    uButtonScale uButtonScale = ((Component) tmpHI).gameObject.GetComponent<uButtonScale>();
    if ((UnityEngine.Object) uButtonScale == (UnityEngine.Object) null)
      uButtonScale = ((Component) tmpHI).gameObject.AddComponent<uButtonScale>();
    uButtonScale.m_Handler = (IUIButtonScaleHandler2) tmpHI;
    uButtonScale.enabled = bEnableScasle;
    if (bEnableScasle)
      tmpHI.SetEffectType(e_EffectType.e_Scale);
    else
      tmpHI.SetEffectType(e_EffectType.e_Normal);
    GameConstants.SetPivot((RectTransform) ((Component) tmpHI).transform, new Vector2(0.5f, 0.5f));
    if (bEnableSound)
      tmpHI.SoundIndex = (byte) 0;
    else
      tmpHI.SoundIndex = byte.MaxValue;
  }

  public void GetABColor() => this.MyColor = RenderSettings.ambientLight;

  public void OpenABColor() => RenderSettings.ambientLight = this.ABColor;

  public void CloseABColor()
  {
    this.ABColor = RenderSettings.ambientLight;
    RenderSettings.ambientLight = this.MyColor;
  }

  public void Recv_QuickBattle(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    byte Score = MP.ReadByte();
    if (Score != (byte) 0)
      return;
    this.UIQueueLock(EGUIQueueLock.UIQL_BattleReport);
    instance.KingOldLv = instance.RoleAttr.Level;
    instance.KingOldExp = instance.RoleAttr.Exp;
    DataManager.StageDataController.RoleAttrLevelUp(MP, 63);
    byte num1 = MP.ReadByte();
    int num2 = (int) MP.ReadUShort();
    ushort Freq = MP.ReadUShort();
    instance.QBTimes = MP.ReadByte();
    instance.ExpItemCount = (byte) 0;
    for (int index = 0; index < 6; ++index)
    {
      instance.QBExpItem[index].ItemID = MP.ReadUShort();
      instance.QBExpItem[index].Quantity = MP.ReadUShort();
      if (instance.QBExpItem[index].ItemID > (ushort) 0)
        ++instance.ExpItemCount;
    }
    MP.ReadBlock(instance.QBRewardLen, 0, 10);
    byte num3 = (byte) ((uint) num1 - 1U);
    DataManager.StageDataController.SetStagePoint(DataManager.StageDataController.currentPointID, Score, Freq);
    instance.QBRewardCount = 0;
    for (int index = 0; index < 10; ++index)
      instance.QBRewardCount += (int) instance.QBRewardLen[index];
    if (instance.QBRewardCount > instance.QBRewardData.Length)
      instance.QBRewardCount = instance.QBRewardData.Length;
    for (int index = 0; index < instance.QBRewardCount; ++index)
      instance.QBRewardData[index] = MP.ReadUShort();
    Level bycurrentPointId = DataManager.StageDataController.GetLevelBycurrentPointID((ushort) 0);
    instance.QBMoney = (uint) bycurrentPointId.Money;
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BattleReport, bCameraMode: true);
    for (int index = 0; index < instance.QBRewardCount && index < 220; ++index)
    {
      ushort ItemID = instance.QBRewardData[index];
      ushort curItemQuantity = instance.GetCurItemQuantity(ItemID, (byte) 0);
      if (curItemQuantity < ushort.MaxValue)
        instance.SetCurItemQuantity(ItemID, (ushort) ((uint) curItemQuantity + 1U), (byte) 0, 0L);
    }
    for (int index = 0; index < (int) instance.ExpItemCount && index < 6; ++index)
    {
      int Quantity = (int) instance.GetCurItemQuantity(instance.QBExpItem[index].ItemID, (byte) 0) + (int) instance.QBExpItem[index].Quantity;
      if (Quantity <= (int) ushort.MaxValue)
        instance.SetCurItemQuantity(instance.QBExpItem[index].ItemID, (ushort) Quantity, (byte) 0, 0L);
    }
    GameManager.OnRefresh();
    GameManager.OnRefresh(NetworkNews.Refresh_Item);
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
    if ((int) instance.KingOldLv != (int) instance.RoleAttr.Level)
      GameManager.OnRefresh(NetworkNews.Refresh_Attr);
    AFAdvanceManager.Instance.CheckHeroStageUnbroken();
  }

  public void SendQuickBattle(
    GUIManager.EQuickFightKind Kind,
    GUIManager.EStageKind Stagekind,
    ushort StageID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_QUICKBATTLE;
    messagePacket.AddSeqId();
    messagePacket.Add((byte) Kind);
    messagePacket.Add((byte) Stagekind);
    messagePacket.Add(StageID);
    messagePacket.Send();
  }

  private void CreateAttackStateImg()
  {
    GameObject gameObject = new GameObject("AlertImage");
    gameObject.layer = 5;
    RectTransform tran = gameObject.AddComponent<RectTransform>();
    ((Transform) tran).SetParent((Transform) this.m_FourthWindowLayer, false);
    this.StretchTransform(tran);
    Image image = gameObject.AddComponent<Image>();
    image.type = (Image.Type) 1;
    image.fillCenter = true;
    ((MaskableGraphic) image).material = this.GetFrameMaterial();
    gameObject.AddComponent<IgnoreRaycast>();
    this.AlertImageSA = gameObject.AddComponent<UISpritesArray>();
    this.AlertImageSA.m_Sprites = new Sprite[3];
    this.AlertImageSA.m_Sprites[0] = this.LoadFrameSprite("UI_full_light_red");
    this.AlertImageSA.m_Sprites[1] = this.LoadFrameSprite("UI_full_light_blue");
    this.AlertImageSA.m_Sprites[2] = this.LoadFrameSprite("UI_full_light_green");
    this.AlertImageSA.m_Image = image;
    this.AlertImageSA.SetSpriteIndex(0);
    this.AlertImageSA.gameObject.SetActive(false);
  }

  public void AddAttackState(EAttackKind Kind) => this.AttackState(Kind);

  public void RemoveAttackState(EAttackKind Kind) => this.AttackState(Kind, false);

  public void RemoveAllAttackState()
  {
    Array.Clear((Array) GUIManager.Instance.m_AttackedAlertCount, 0, GUIManager.Instance.m_AttackedAlertCount.Length);
    this.CheckAttackState();
  }

  private void AttackState(EAttackKind Kind, bool bAdd = true)
  {
    int[] attackedAlertCount = this.m_AttackedAlertCount;
    if (bAdd)
    {
      ++attackedAlertCount[(int) Kind];
    }
    else
    {
      if (attackedAlertCount[(int) Kind] <= 0)
        return;
      --attackedAlertCount[(int) Kind];
    }
    this.CheckAttackState();
  }

  private void CheckAttackState()
  {
    int[] attackedAlertCount = this.m_AttackedAlertCount;
    this.m_AttackedAlertTCount = 0;
    for (int index = 0; index < 15; ++index)
      this.m_AttackedAlertTCount += attackedAlertCount[index];
    if ((UnityEngine.Object) this.AlertImageSA != (UnityEngine.Object) null)
    {
      if (this.m_AttackedAlertTCount > 0)
      {
        this.m_AlertImageIndex = attackedAlertCount[0] > 0 || attackedAlertCount[1] > 0 || attackedAlertCount[6] > 0 || attackedAlertCount[7] > 0 || attackedAlertCount[2] > 0 || attackedAlertCount[3] > 0 || attackedAlertCount[8] > 0 || attackedAlertCount[4] > 0 || attackedAlertCount[9] > 0 || attackedAlertCount[5] > 0 ? 0 : (attackedAlertCount[10] > 0 || attackedAlertCount[11] > 0 || attackedAlertCount[12] > 0 || attackedAlertCount[13] > 0 ? 1 : 2);
        this.AlertImageSA.SetSpriteIndex(this.m_AlertImageIndex);
        this.AlertImageSA.gameObject.SetActive(true);
      }
      else
        this.AlertImageSA.gameObject.SetActive(false);
    }
    Door menu = this.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      menu.CheckAttackState();
    else
      this.CheckBattleAttackState();
  }

  public void CheckBattleAttackState()
  {
    bool bOpenAlertBlock = this.m_AttackedAlertTCount > 0 && this.m_AlertImageIndex == 0;
    UIBattle menu1 = this.FindMenu(EGUIWindow.UI_Battle) as UIBattle;
    if ((UnityEngine.Object) menu1 != (UnityEngine.Object) null && menu1.gameObject.activeSelf)
    {
      menu1.SetAlertBlock(bOpenAlertBlock);
    }
    else
    {
      UILegBattle menu2 = this.FindMenu(EGUIWindow.UI_LegBattle) as UILegBattle;
      if ((UnityEngine.Object) menu2 != (UnityEngine.Object) null)
      {
        menu2.SetAlertBlock(bOpenAlertBlock);
      }
      else
      {
        UIBattle_Gambling menu3 = this.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
        if (!((UnityEngine.Object) menu3 != (UnityEngine.Object) null))
          return;
        menu3.SetAlertBlock(bOpenAlertBlock);
      }
    }
  }

  public void SetTroopsCount(int count)
  {
    this.m_TroopsCount = count;
    Door menu = this.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.CheckTroopsState();
  }

  public void ClearBM()
  {
    this.m_BMGO = (GameObject) null;
    this.m_BMContentT = (Transform) null;
    this.m_BMButtonT = (Transform) null;
    this.m_BMBtnText = (UIText) null;
    this.m_BMText1 = (UIText) null;
    this.m_BMText2 = (UIText) null;
    this.m_BMAssetBundleKey = 0;
    this.SerialNo = 0U;
    this.m_BMTime = -1f;
    this.bSendShow = false;
  }

  public string GetPointName(POINT_KIND PointKind)
  {
    DataManager instance = DataManager.Instance;
    switch (PointKind)
    {
      case POINT_KIND.PK_FOOD:
        return instance.mStringTable.GetStringByID(635U);
      case POINT_KIND.PK_STONE:
        return instance.mStringTable.GetStringByID(634U);
      case POINT_KIND.PK_IRON:
        return instance.mStringTable.GetStringByID(633U);
      case POINT_KIND.PK_WOOD:
        return instance.mStringTable.GetStringByID(636U);
      case POINT_KIND.PK_GOLD:
        return instance.mStringTable.GetStringByID(638U);
      case POINT_KIND.PK_CRYSTAL:
        return instance.mStringTable.GetStringByID(637U);
      case POINT_KIND.PK_CITY:
        return instance.mStringTable.GetStringByID(631U);
      case POINT_KIND.PK_CAMP:
        return instance.mStringTable.GetStringByID(639U);
      default:
        return (string) null;
    }
  }

  public string GetPointName_Letter(POINT_KIND PointKind)
  {
    DataManager instance = DataManager.Instance;
    switch (PointKind)
    {
      case POINT_KIND.PK_FOOD:
        return instance.mStringTable.GetStringByID(6031U);
      case POINT_KIND.PK_STONE:
        return instance.mStringTable.GetStringByID(6028U);
      case POINT_KIND.PK_IRON:
        return instance.mStringTable.GetStringByID(6030U);
      case POINT_KIND.PK_WOOD:
        return instance.mStringTable.GetStringByID(6029U);
      case POINT_KIND.PK_GOLD:
        return instance.mStringTable.GetStringByID(6033U);
      case POINT_KIND.PK_CRYSTAL:
        return instance.mStringTable.GetStringByID(6032U);
      case POINT_KIND.PK_CITY:
        return instance.mStringTable.GetStringByID(631U);
      case POINT_KIND.PK_CAMP:
        return instance.mStringTable.GetStringByID(4540U);
      default:
        return (string) null;
    }
  }

  public void RecvBattleMessage(MessagePacket MP)
  {
    StringManager instance = StringManager.Instance;
    this.SerialNo = MP.ReadUInt();
    GUIManager.ECombatLiveType MessageKind = (GUIManager.ECombatLiveType) MP.ReadByte();
    POINT_KIND PointKind = (POINT_KIND) MP.ReadByte();
    ushort num = MP.ReadUShort();
    CString cstring = instance.StaticString1024();
    CString outString = instance.StaticString1024();
    CString PlayerName = instance.StaticString1024();
    CString Player2Name = instance.StaticString1024();
    MP.ReadStringPlus(3, cstring);
    MP.ReadStringPlus(13, outString);
    if (this.m_BMATStr == null)
      this.m_BMATStr = instance.SpawnString();
    if (this.m_BMNStr == null)
      this.m_BMNStr = instance.SpawnString();
    this.m_BMATStr.Length = 0;
    this.m_BMATStr.Append(cstring);
    this.m_BMNStr.Length = 0;
    this.m_BMNStr.Append(outString);
    this.m_BMNowLiveType = MessageKind;
    this.m_BMNowPointKind = PointKind;
    this.m_BMNowKingdomID = num;
    int length = cstring.Length;
    if (outString.Length > 0)
    {
      if (length > 0)
      {
        PlayerName.StringToFormat(cstring);
        PlayerName.AppendFormat("[{0}]");
      }
      PlayerName.Append(outString);
    }
    else
      PlayerName.Append("NoName");
    if (MessageKind == GUIManager.ECombatLiveType.ECLTR_REINFORCE_UNDERATTACK)
    {
      outString.Length = 0;
      MP.ReadStringPlus(13, outString);
      if (outString.Length > 0)
        Player2Name.Append(outString);
      else
        Player2Name.Append("NoName");
      this.OpenBattleMessage(MessageKind, PlayerName, PointKind, this.SerialNo > 0U, Player2Name, (byte) 0);
    }
    else
      this.OpenBattleMessage(MessageKind, PlayerName, PointKind, this.SerialNo > 0U, WonderID: (byte) 0);
    if (MessageKind == GUIManager.ECombatLiveType.ECLTR_ATTACK)
    {
      this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7727U), (ushort) 13);
    }
    else
    {
      if (MessageKind != GUIManager.ECombatLiveType.ECLTR_RALLYATTACK)
        return;
      this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(493U), (ushort) 13);
    }
  }

  public void RecvWMMessage(MessagePacket MP)
  {
    this.SerialNo = MP.ReadUInt();
    this.WM_RandomSeed = MP.ReadUShort();
    this.WM_RandomGap = MP.ReadByte();
    this.WM_HeroCount = (byte) 0;
    for (int index = 0; index < 5; ++index)
    {
      this.WM_HeroData[index].HeroID = MP.ReadUShort();
      if (this.WM_HeroData[index].HeroID != (ushort) 0)
        ++this.WM_HeroCount;
    }
    for (int index = 0; index < 5; ++index)
    {
      this.WM_HeroData[index].AttrData.SkillLV1 = MP.ReadByte();
      this.WM_HeroData[index].AttrData.SkillLV2 = MP.ReadByte();
      this.WM_HeroData[index].AttrData.SkillLV3 = MP.ReadByte();
      this.WM_HeroData[index].AttrData.SkillLV4 = MP.ReadByte();
      this.WM_HeroData[index].AttrData.LV = MP.ReadByte();
      this.WM_HeroData[index].AttrData.Star = MP.ReadByte();
      this.WM_HeroData[index].AttrData.Enhance = MP.ReadByte();
      this.WM_HeroData[index].AttrData.Equip = MP.ReadByte();
    }
    this.WM_MonsterID = MP.ReadUShort();
    this.WM_MonsterLv = MP.ReadByte();
    this.WM_MonsterNowHP = MP.ReadUInt();
    this.WM_MonsterMaxHP = MP.ReadUInt();
    this.WM_MonsterAttr.ActionTimes = MP.ReadByte();
    this.WM_MonsterAttr.SequentialDamageScale = MP.ReadUInt();
    this.WM_MonsterAttr.DamageScale = MP.ReadUInt();
    this.WM_MonsterAttr.MaxHPScale = MP.ReadUInt();
    this.WM_MonsterAttr.HealingScale = MP.ReadUInt();
    this.WM_MonsterAttr.InitMP = MP.ReadUShort();
    this.WM_MonsterTagStr.Length = 0;
    MP.ReadStringPlus(3, this.WM_MonsterTagStr);
    this.OpenBattleMessage(GUIManager.ECombatLiveType.ECLTR_WILDMONSTER, WonderID: (byte) 0);
  }

  public void RecvWonderMessage(MessagePacket MP)
  {
    StringManager instance = StringManager.Instance;
    this.SerialNo = MP.ReadUInt();
    GUIManager.ECombatLiveType MessageKind = (GUIManager.ECombatLiveType) MP.ReadByte();
    byte num1 = MP.ReadByte();
    ushort num2 = MP.ReadUShort();
    CString cstring = instance.StaticString1024();
    CString outString = instance.StaticString1024();
    CString PlayerName = instance.StaticString1024();
    CString Player2Name = instance.StaticString1024();
    MP.ReadStringPlus(3, cstring);
    MP.ReadStringPlus(13, outString);
    if (this.m_BMATStr == null)
      this.m_BMATStr = instance.SpawnString();
    if (this.m_BMNStr == null)
      this.m_BMNStr = instance.SpawnString();
    this.m_BMATStr.Length = 0;
    this.m_BMATStr.Append(cstring);
    this.m_BMNStr.Length = 0;
    this.m_BMNStr.Append(outString);
    this.m_BMNowLiveType = MessageKind;
    this.m_BMNowPointKind = POINT_KIND.PK_YOLK;
    this.m_BMNowKingdomID = num2;
    int length = cstring.Length;
    if (outString.Length > 0)
    {
      if (length > 0)
      {
        PlayerName.StringToFormat(cstring);
        PlayerName.AppendFormat("[{0}]");
      }
      PlayerName.Append(outString);
    }
    else
      PlayerName.Append("NoName");
    if (MessageKind == GUIManager.ECombatLiveType.ECLTR_REINFORCE_UNDERATTACK)
    {
      outString.Length = 0;
      MP.ReadStringPlus(13, outString);
      if (outString.Length > 0)
        Player2Name.Append(outString);
      else
        Player2Name.Append("NoName");
      this.OpenBattleMessage(MessageKind, PlayerName, POINT_KIND.PK_MAX, this.SerialNo > 0U, Player2Name, (byte) ((uint) num1 + 1U));
    }
    else
      this.OpenBattleMessage(MessageKind, PlayerName, POINT_KIND.PK_MAX, this.SerialNo > 0U, WonderID: (byte) ((uint) num1 + 1U));
    if (MessageKind == GUIManager.ECombatLiveType.ECLTR_ATTACK)
    {
      this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7727U), (ushort) 13);
    }
    else
    {
      if (MessageKind != GUIManager.ECombatLiveType.ECLTR_RALLYATTACK)
        return;
      this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(493U), (ushort) 13);
    }
  }

  public void RecvNPCCityMessage(MessagePacket MP)
  {
    this.SerialNo = MP.ReadUInt();
    this.WM_NPCLevel = MP.ReadByte();
    this.OpenBattleMessage(GUIManager.ECombatLiveType.ECLTR_NPCCITY, WonderID: this.WM_NPCLevel);
  }

  public void Recv_PET_LIVEINFO(MessagePacket MP)
  {
    StringManager instance = StringManager.Instance;
    GUIManager.EPetLiveType epetLiveType = (GUIManager.EPetLiveType) MP.ReadByte();
    POINT_KIND PointKind = (POINT_KIND) MP.ReadByte();
    MP.ReadUShort();
    CString cstring = instance.StaticString1024();
    CString outString = instance.StaticString1024();
    CString PlayerName = instance.StaticString1024();
    MP.ReadStringPlus(3, cstring);
    MP.ReadStringPlus(13, outString);
    int length = cstring.Length;
    if (outString.Length > 0)
    {
      if (length > 0)
      {
        PlayerName.StringToFormat(cstring);
        PlayerName.AppendFormat("[{0}]");
      }
      PlayerName.Append(outString);
    }
    else
      PlayerName.Append("NoName");
    if (epetLiveType == GUIManager.EPetLiveType.EPLTR_ATTACK)
    {
      this.OpenBattleMessage(GUIManager.ECombatLiveType.ECLTR_PETATTACK, PlayerName, PointKind, this.SerialNo > 0U, WonderID: (byte) 0);
    }
    else
    {
      if (epetLiveType != GUIManager.EPetLiveType.EPLTR_UNDERATTACK)
        return;
      this.OpenBattleMessage(GUIManager.ECombatLiveType.ECLTR_PETUNDERATTACK, PlayerName, PointKind, this.SerialNo > 0U, WonderID: (byte) 0);
    }
  }

  public void OpenBattleMessage(
    GUIManager.ECombatLiveType MessageKind,
    CString PlayerName = null,
    POINT_KIND PointKind = POINT_KIND.PK_NONE,
    bool bShowButton = true,
    CString Player2Name = null,
    byte WonderID = 0)
  {
    DataManager instance1 = DataManager.Instance;
    StringManager instance2 = StringManager.Instance;
    if (!instance1.MySysSetting.bShowChatFight)
      return;
    if ((UnityEngine.Object) this.m_BMGO == (UnityEngine.Object) null)
    {
      AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/BattleMessage", out this.m_BMAssetBundleKey);
      if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
        return;
      this.m_BMGO = (GameObject) UnityEngine.Object.Instantiate(assetBundle.mainAsset);
      if ((UnityEngine.Object) this.m_BMGO == (UnityEngine.Object) null)
      {
        AssetManager.UnloadAssetBundle(this.m_BMAssetBundleKey);
        return;
      }
      Transform transform = this.m_BMGO.transform;
      transform.GetChild(1).gameObject.SetActive(false);
      transform.GetChild(2).gameObject.SetActive(false);
      this.m_BMButtonT = transform.GetChild(3);
      UIButton component = this.m_BMButtonT.GetComponent<UIButton>();
      component.m_Handler = (IUIButtonClickHandler) this;
      component.m_BtnID1 = 3;
      this.m_BMBtnText = this.m_BMButtonT.GetChild(0).GetComponent<UIText>();
      this.m_BMBtnText.font = this.m_TTFFont;
      this.m_BMBtnText.text = instance1.mStringTable.GetStringByID(582U);
      this.m_BMLight = this.m_BMButtonT.GetChild(1).GetComponent<Image>();
      this.m_BMLightTime = 0.0f;
      this.m_BMContentT = this.m_BMGO.transform.GetChild(4).GetChild(0);
      this.m_BMText1 = this.m_BMContentT.GetChild(0).GetComponent<UIText>();
      this.m_BMText1.font = this.m_TTFFont;
      this.m_BMText2 = this.m_BMContentT.GetChild(1).GetComponent<UIText>();
      this.m_BMText2.font = this.m_TTFFont;
      this.m_BMGO.transform.SetParent((Transform) this.m_BattleMessageLayer, false);
    }
    else if (this.m_OKCancelClickIndex == 1)
    {
      this.CloseOKCancelBox();
      this.bSendShow = false;
    }
    if (this.SerialNo == 0U || !this.bGPShow)
    {
      this.m_BMButtonT.gameObject.SetActive(false);
      if (MessageKind == GUIManager.ECombatLiveType.ECLTR_PETATTACK || MessageKind == GUIManager.ECombatLiveType.ECLTR_PETUNDERATTACK)
        this.m_BMGO.transform.GetChild(4).GetComponent<RectTransform>().offsetMax = new Vector2(-5f, 0.0f);
    }
    else
      this.m_BMButtonT.gameObject.SetActive(true);
    this.m_BMTime = 15f;
    if (MessageKind == GUIManager.ECombatLiveType.ECLTR_UNDERATTACK || MessageKind == GUIManager.ECombatLiveType.ECLTR_REINFORCE_UNDERATTACK || MessageKind == GUIManager.ECombatLiveType.ECLTR_AMBUSH_UNDERATTACK || MessageKind == GUIManager.ECombatLiveType.ECLTR_PETUNDERATTACK)
    {
      this.bWarAttacker = false;
      UISpritesArray component = this.m_BMGO.transform.GetComponent<UISpritesArray>();
      component.SetSpriteIndex(2);
      this.m_BMGO.transform.GetChild(0).GetComponent<Image>().sprite = component.GetSprite(3);
      if (this.m_BMMessage1 == null)
        this.m_BMMessage1 = instance2.SpawnString(1024);
      this.m_BMMessage1.Length = 0;
      switch (MessageKind)
      {
        case GUIManager.ECombatLiveType.ECLTR_REINFORCE_UNDERATTACK:
          CString tmpS = instance2.StaticString1024();
          tmpS.StringToFormat(Player2Name);
          tmpS.AppendFormat(instance1.mStringTable.GetStringByID(632U));
          this.m_BMMessage1.StringToFormat(tmpS);
          break;
        case GUIManager.ECombatLiveType.ECLTR_AMBUSH_UNDERATTACK:
          this.m_BMMessage1.StringToFormat(instance1.mStringTable.GetStringByID(9734U));
          break;
        default:
          if (WonderID != (byte) 0)
          {
            this.m_BMMessage1.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) ((uint) WonderID - 1U), (ushort) 0));
            break;
          }
          this.m_BMMessage1.StringToFormat(this.GetPointName(PointKind));
          break;
      }
      this.m_BMMessage1.StringToFormat(PlayerName);
      this.m_BMMessage1.AppendFormat(instance1.mStringTable.GetStringByID(628U));
      this.m_BMText1.text = this.m_BMMessage1.ToString();
      this.m_BMText1.SetAllDirty();
      this.m_BMText1.cachedTextGenerator.Invalidate();
    }
    else
    {
      switch (MessageKind)
      {
        case GUIManager.ECombatLiveType.ECLTR_WILDMONSTER:
          this.m_BMNowLiveType = GUIManager.ECombatLiveType.ECLTR_WILDMONSTER;
          UISpritesArray component1 = this.m_BMGO.transform.GetComponent<UISpritesArray>();
          component1.SetSpriteIndex(0);
          this.m_BMGO.transform.GetChild(0).GetComponent<Image>().sprite = component1.GetSprite(1);
          if (this.m_BMMessage1 == null)
            this.m_BMMessage1 = instance2.SpawnString(1024);
          this.m_BMMessage1.Length = 0;
          ushort nameId = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.WM_MonsterID).NameID;
          CString tmpS1 = StringManager.Instance.StaticString1024();
          if (this.WM_MonsterTagStr[0] == char.MinValue)
          {
            tmpS1.Append(instance1.mStringTable.GetStringByID((uint) nameId));
          }
          else
          {
            tmpS1.StringToFormat(this.WM_MonsterTagStr);
            tmpS1.StringToFormat(instance1.mStringTable.GetStringByID((uint) nameId));
            tmpS1.AppendFormat("[{0}]{1}");
          }
          this.m_BMMessage1.StringToFormat(tmpS1);
          this.m_BMMessage1.IntToFormat((long) this.WM_MonsterLv);
          this.m_BMMessage1.AppendFormat(instance1.mStringTable.GetStringByID(8348U));
          this.m_BMText1.text = this.m_BMMessage1.ToString();
          this.m_BMText1.SetAllDirty();
          this.m_BMText1.cachedTextGenerator.Invalidate();
          break;
        case GUIManager.ECombatLiveType.ECLTR_NPCCITY:
          this.bWarAttacker = true;
          this.m_BMNowLiveType = GUIManager.ECombatLiveType.ECLTR_NPCCITY;
          UISpritesArray component2 = this.m_BMGO.transform.GetComponent<UISpritesArray>();
          component2.SetSpriteIndex(0);
          this.m_BMGO.transform.GetChild(0).GetComponent<Image>().sprite = component2.GetSprite(1);
          if (this.m_BMMessage1 == null)
            this.m_BMMessage1 = instance2.SpawnString(1024);
          this.m_BMMessage1.Length = 0;
          CString tmpS2 = StringManager.Instance.StaticString1024();
          tmpS2.IntToFormat((long) WonderID);
          tmpS2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021U));
          this.m_BMMessage1.StringToFormat(tmpS2);
          this.m_BMMessage1.AppendFormat(instance1.mStringTable.GetStringByID(12025U));
          this.m_BMText1.text = this.m_BMMessage1.ToString();
          this.m_BMText1.SetAllDirty();
          this.m_BMText1.cachedTextGenerator.Invalidate();
          break;
        default:
          this.bWarAttacker = true;
          UISpritesArray component3 = this.m_BMGO.transform.GetComponent<UISpritesArray>();
          component3.SetSpriteIndex(0);
          this.m_BMGO.transform.GetChild(0).GetComponent<Image>().sprite = component3.GetSprite(1);
          if (this.m_BMMessage1 == null)
            this.m_BMMessage1 = instance2.SpawnString(1024);
          this.m_BMMessage1.Length = 0;
          this.m_BMMessage1.StringToFormat(PlayerName);
          if (WonderID != (byte) 0)
            this.m_BMMessage1.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) ((uint) WonderID - 1U), (ushort) 0));
          else
            this.m_BMMessage1.StringToFormat(this.GetPointName(PointKind));
          if (MessageKind == GUIManager.ECombatLiveType.ECLTR_PETATTACK)
            this.m_BMMessage1.AppendFormat(instance1.mStringTable.GetStringByID(14589U));
          else
            this.m_BMMessage1.AppendFormat(instance1.mStringTable.GetStringByID(629U));
          this.m_BMText1.text = this.m_BMMessage1.ToString();
          this.m_BMText1.SetAllDirty();
          this.m_BMText1.cachedTextGenerator.Invalidate();
          break;
      }
    }
    Door menu = this.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      ((Component) menu.m_ChatBox).gameObject.SetActive(false);
      this.CheckBattleMessageSize(menu.m_eMode == EUIOriginMode.Show);
    }
    else
    {
      if ((UnityEngine.Object) this.m_ChatBox != (UnityEngine.Object) null)
        ((Component) this.m_ChatBox).gameObject.SetActive(false);
      if (this.bInFightHideChat)
        this.m_BMGO.gameObject.SetActive(false);
      this.CheckBattleMessageSize(true);
    }
    AudioManager.Instance.PlayUISFX(UIKind.News);
  }

  public void CloseBattleMessage()
  {
    UnityEngine.Object.Destroy((UnityEngine.Object) this.m_BMGO);
    AssetManager.UnloadAssetBundle(this.m_BMAssetBundleKey);
    this.ClearBM();
    Door menu = this.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      if (menu.m_eMode == EUIOriginMode.Show && menu.bHideMainMenu || menu.m_eMode == EUIOriginMode.Hide || menu.m_eMode == EUIOriginMode.FuncButtonWithoutChatBox)
        return;
      ((Component) menu.m_ChatBox).gameObject.SetActive(true);
    }
    else
    {
      if (!((UnityEngine.Object) this.m_ChatBox != (UnityEngine.Object) null) || this.bInFightHideChat)
        return;
      ((Component) this.m_ChatBox).gameObject.SetActive(true);
    }
  }

  public void CheckBattleMessageSize(bool bNormal)
  {
    if (!((UnityEngine.Object) this.m_BMGO != (UnityEngine.Object) null))
      return;
    RectTransform transform = this.m_BMGO.transform as RectTransform;
    if (!this.bGPShow)
    {
      transform.offsetMin = new Vector2(161f, transform.offsetMin.y);
      transform.offsetMax = new Vector2(-95f, transform.offsetMax.y);
    }
    else if (bNormal)
    {
      transform.offsetMin = new Vector2(267f, transform.offsetMin.y);
      transform.offsetMax = new Vector2(-152f, transform.offsetMax.y);
    }
    else
    {
      transform.offsetMin = new Vector2(144f, transform.offsetMin.y);
      transform.offsetMax = new Vector2(-95f, transform.offsetMax.y);
    }
  }

  public void SetBattleMessageButton(bool bShow)
  {
    if ((UnityEngine.Object) this.m_BMGO != (UnityEngine.Object) null && this.bGPShow != bShow)
    {
      if (this.SerialNo == 0U || !bShow)
        this.m_BMButtonT.gameObject.SetActive(false);
      else
        this.m_BMButtonT.gameObject.SetActive(true);
    }
    this.bGPShow = bShow;
    if ((UnityEngine.Object) this.m_BMGO != (UnityEngine.Object) null && this.bGPShow)
      this.m_BMGO.gameObject.SetActive(true);
    if (this.bGPShow)
      return;
    this.CheckBattleMessageSize(false);
  }

  public void SendBattleMessageRP()
  {
    if (this.SerialNo == 0U)
      return;
    DataManager.Instance.bWarAttacker = this.bWarAttacker;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_LIVECOMBATREPLAY;
    messagePacket.AddSeqId();
    messagePacket.Add(this.SerialNo);
    messagePacket.Add(DataManager.Instance.Mailing.ReportSerial.New);
    messagePacket.Send();
  }

  public void CheckSuggestion()
  {
    if (this.RandomIndex == -1)
      return;
    int randomIndex = this.RandomIndex;
    this.RandomIndex = -1;
    Door menu1 = this.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu1 == (UnityEngine.Object) null)
      return;
    switch (randomIndex)
    {
      case 0:
        menu1.OpenMenu(EGUIWindow.UI_Hero_Info, bCameraMode: true);
        UIHero_Info menu2 = this.FindMenu(EGUIWindow.UI_Hero_Info) as UIHero_Info;
        if (!((UnityEngine.Object) menu2 != (UnityEngine.Object) null))
          break;
        menu2.SetPage(1);
        break;
      case 1:
        menu1.OpenMenu(EGUIWindow.UI_BagFilter, 4);
        break;
      case 2:
      case 3:
        menu1.OpenMenu(EGUIWindow.UI_Hero_Info, bCameraMode: true);
        break;
      case 4:
        this.HeroListSaved = (byte) 1;
        menu1.OpenMenu(EGUIWindow.UI_HeroList);
        break;
    }
  }

  public void CheckLvUp(bool bInBattle = false)
  {
    if (this.PreLeadLevel > 0 && (int) DataManager.Instance.RoleAttr.Level >= this.PreLeadLevel + 1)
      this.OpenUI_Queued_Restricted(EGUIWindow.UI_leadup, this.PreLeadLevel, openMode: (byte) 0);
    this.PreLeadLevel = -1;
  }

  private void InitialChatBox(RectTransform ChatBox)
  {
    this.m_ChatBox = ChatBox;
    Transform transform = ((Component) this.m_ChatBox).transform;
    this.m_ChatChannelLight = transform.GetChild(2).GetComponent<Image>();
    this.m_ChatChannelLight1 = ((Component) this.m_ChatChannelLight).transform.GetChild(0).GetComponent<Image>();
    this.ChannelSpriteOn = this.m_ChatChannelLight1.sprite;
    this.m_ChatChannelLight2 = ((Component) this.m_ChatChannelLight).transform.GetChild(1).GetComponent<Image>();
    this.ChannelSpriteOff = this.m_ChatChannelLight2.sprite;
    this.m_ChannelLightFlashGO = ((Component) this.m_ChatChannelLight).transform.GetChild(1).GetChild(0).gameObject;
    Transform child1 = transform.GetChild(3);
    this.m_ChatImage = child1.GetComponent<Image>();
    ((Behaviour) this.m_ChatImage).enabled = false;
    this.m_ChatMask = child1.GetComponent<Mask>();
    ((Behaviour) this.m_ChatMask).enabled = false;
    this.m_ChatScrollRect = child1.gameObject.AddComponent<CScrollRect>();
    this.m_ChatScrollRect.horizontal = true;
    this.m_ChatScrollRect.vertical = false;
    this.m_ChatScrollRect.content = (RectTransform) child1.GetChild(0);
    this.m_ChatScrollRect.bPageMove = true;
    this.m_ChatScrollRect.m_PageMoveHandler = (IPagemove) this;
    this.m_ChatScrollRectRC = ((Component) this.m_ChatScrollRect).GetComponent<RectTransform>();
    this.m_ChatContentT = child1.GetChild(0);
    for (int index = 0; index < 2; ++index)
    {
      this.m_ChatChannel[index] = new ChatChannel();
      Transform child2 = this.m_ChatContentT.GetChild(index);
      this.m_ChatChannel[index].MainRC = (RectTransform) child2;
      this.m_ChatChannel[index].m_ChatText[0] = child2.GetChild(2).GetComponent<UIText>();
      this.m_ChatChannel[index].m_ChatText[0].font = this.GetTTFFont();
      this.m_ChatChannel[index].m_ChatTextRC[0] = ((Graphic) this.m_ChatChannel[index].m_ChatText[0]).rectTransform;
      this.m_ChatChannel[index].m_ChatText[1] = child2.GetChild(3).GetComponent<UIText>();
      this.m_ChatChannel[index].m_ChatText[1].font = this.GetTTFFont();
      this.m_ChatChannel[index].m_ChatTextRC[1] = ((Graphic) this.m_ChatChannel[index].m_ChatText[1]).rectTransform;
      this.m_ChatChannel[index].m_ChatText[0].SetCheckArabic(true);
      this.m_ChatChannel[index].m_ChatText[1].SetCheckArabic(true);
      this.m_ChatChannel[index].m_Button = child2.GetChild(4).GetComponent<UIButton>();
      this.m_ChatChannel[index].m_Button.m_Handler = (IUIButtonClickHandler) this;
      this.m_ChatChannel[index].m_ChatEmojiRC[0] = child2.GetChild(5 + index).GetComponent<RectTransform>();
      ((Component) this.m_ChatChannel[index].m_ChatEmojiRC[0]).gameObject.AddComponent<IgnoreRaycast>();
      this.m_ChatChannel[index].m_ChatEmojiRC[1] = child2.GetChild(6 + index).GetComponent<RectTransform>();
      ((Component) this.m_ChatChannel[index].m_ChatEmojiRC[1]).gameObject.AddComponent<IgnoreRaycast>();
      if (this.IsArabic)
      {
        ((Transform) this.m_ChatChannel[index].m_ChatEmojiRC[0]).localScale = new Vector3(-1f, 1f, 1f);
        ((Transform) this.m_ChatChannel[index].m_ChatEmojiRC[1]).localScale = new Vector3(-1f, 1f, 1f);
      }
      if (index == 1)
      {
        this.NoAllianceText = child2.GetChild(5).GetComponent<UIText>();
        this.NoAllianceText.font = this.GetTTFFont();
        this.NoAllianceText.text = DataManager.Instance.mStringTable.GetStringByID(689U);
      }
    }
    this.m_ChatScrollRect.ChangePageWidth(this.m_ChatScrollRectRC.rect.width);
    if (DataManager.Instance.NowChannel == (byte) 1)
    {
      this.m_ChatScrollRect.setCurrentIndex((byte) 1, true);
      this.m_ChatContentT.GetChild(0).gameObject.SetActive(false);
    }
    else
    {
      this.m_ChatScrollRect.setCurrentIndex((byte) 0, true);
      this.m_ChatContentT.GetChild(1).gameObject.SetActive(false);
    }
    this.CheckNoAllianceText();
    this.bInFightHideChat = false;
  }

  private void ClearChatBox() => this.m_ChatBox = (RectTransform) null;

  private void ClearEmoji()
  {
    if ((UnityEngine.Object) this.m_ChatBox == (UnityEngine.Object) null)
      return;
    for (int index1 = 0; index1 < 2; ++index1)
    {
      for (int index2 = 0; index2 < 2; ++index2)
      {
        if (this.m_ChatChannel[index1] != null && this.m_ChatChannel[index1].EUnit[index2] != null)
        {
          this.pushEmojiIcon(this.m_ChatChannel[index1].EUnit[index2]);
          this.m_ChatChannel[index1].EUnit[index2] = (EmojiUnit) null;
        }
      }
    }
  }

  public void DoorOpenChatBox(RectTransform ChatBox)
  {
    this.InitialChatBox(ChatBox);
    this.UpdateMainUIChat();
    this.CheckChannelLightFlash(0);
    if (!((UnityEngine.Object) this.m_BMGO != (UnityEngine.Object) null))
      return;
    this.m_BMGO.gameObject.SetActive(true);
    if (!((UnityEngine.Object) this.m_ChatBox != (UnityEngine.Object) null))
      return;
    ((Component) this.m_ChatBox).gameObject.SetActive(false);
  }

  public void DoorCloseChatBox()
  {
    this.ClearEmoji();
    this.ClearChatBox();
  }

  public void BattleOpenChatBox()
  {
    AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/ChatBox", out this.m_ChatBoxAssetKey);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return;
    this.m_ChatBoxGO = (GameObject) UnityEngine.Object.Instantiate(assetBundle.mainAsset);
    if ((UnityEngine.Object) this.m_ChatBoxGO == (UnityEngine.Object) null)
    {
      AssetManager.UnloadAssetBundle(this.m_ChatBoxAssetKey);
    }
    else
    {
      this.m_ChatBoxGO.transform.SetParent((Transform) this.m_WindowsTransform, false);
      this.m_ChatBoxGO.transform.SetAsFirstSibling();
      this.InitialChatBox(this.m_ChatBoxGO.GetComponent<RectTransform>());
      this.m_ChatBox.offsetMin = new Vector2(161f, this.m_ChatBox.offsetMin.y);
      this.m_ChatBox.offsetMax = new Vector2(-95f, this.m_ChatBox.offsetMax.y);
      this.m_ChatScrollRect.ChangePageWidth(this.m_ChatScrollRectRC.rect.width);
      this.UpdateMainUIChat();
      this.CheckChannelLightFlash(0);
      if (!((UnityEngine.Object) this.m_BMGO != (UnityEngine.Object) null))
        return;
      ((Component) this.m_ChatBox).gameObject.SetActive(false);
    }
  }

  public void BattleCloseChatBox()
  {
    this.ClearEmoji();
    UnityEngine.Object.Destroy((UnityEngine.Object) this.m_ChatBoxGO);
    AssetManager.UnloadAssetBundle(this.m_ChatBoxAssetKey);
    this.ClearChatBox();
  }

  public void ShowChatBox()
  {
    if ((UnityEngine.Object) this.m_BMGO != (UnityEngine.Object) null)
      this.m_BMGO.gameObject.SetActive(true);
    else if ((UnityEngine.Object) this.m_ChatBox != (UnityEngine.Object) null)
      ((Component) this.m_ChatBox).gameObject.SetActive(true);
    this.bInFightHideChat = false;
  }

  public void HideChatBox()
  {
    if ((UnityEngine.Object) this.m_BMGO != (UnityEngine.Object) null)
      this.m_BMGO.gameObject.SetActive(false);
    if ((UnityEngine.Object) this.m_ChatBox != (UnityEngine.Object) null)
      ((Component) this.m_ChatBox).gameObject.SetActive(false);
    this.bInFightHideChat = true;
  }

  private unsafe void UpdateMainUIChat()
  {
    DataManager instance = DataManager.Instance;
    Font font = this.m_ChatChannel[0].m_ChatText[0].font;
    CharacterInfo info = new CharacterInfo();
    byte check = 0;
    for (int index1 = 0; index1 < 2; ++index1)
    {
      List<TalkDataType> talkDataTypeList = index1 != 0 ? instance.TalkData_Alliance : instance.TalkData_Kingdom;
      CString[] cstringArray = index1 != 0 ? instance.ChatStrA : instance.ChatStr;
      int index2 = 0;
      int[] numArray = new int[2]{ -1, -1 };
      for (int index3 = talkDataTypeList.Count - 1; index3 >= 0 && index2 < 2; --index3)
      {
        if (talkDataTypeList[index3].TalkKind != (byte) 1 && (index1 != 1 || !instance.CheckHideTalk(talkDataTypeList[index3])))
        {
          numArray[index2] = index3;
          ++index2;
        }
      }
      for (int index4 = 0; index4 < 2; ++index4)
      {
        cstringArray[index4].ClearString();
        int index5 = index4 != 0 ? (numArray[1] != -1 ? numArray[0] : numArray[1]) : (numArray[1] != -1 ? numArray[1] : numArray[0]);
        ((Component) this.m_ChatChannel[index1].m_ChatEmojiRC[index4]).gameObject.SetActive(false);
        if (index5 >= 0 && index5 < talkDataTypeList.Count)
        {
          bool flag1 = talkDataTypeList[index5].FuncKind == (byte) 109;
          check = talkDataTypeList[index5].bHaveArabic;
          float num1 = 0.0f;
          if (flag1)
          {
            font.RequestCharactersInTexture(talkDataTypeList[index5].ShowName.ToString(), 17);
            for (int index6 = 0; index6 < talkDataTypeList[index5].ShowName.Length; ++index6)
            {
              if (font.GetCharacterInfo(talkDataTypeList[index5].ShowName[index6], out info, 17))
                num1 += info.width;
              else
                num1 += 15f;
            }
            font.RequestCharactersInTexture("：", 17);
            float num2 = !font.GetCharacterInfo('：', out info, 17) ? num1 + 15f : num1 + info.width;
            instance.ChatMainStr.Length = 0;
            ushort kingdomId = index1 != 0 || talkDataTypeList[index5].KingdomID <= (ushort) 0 || (int) talkDataTypeList[index5].KingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID ? (ushort) 0 : talkDataTypeList[index5].KingdomID;
            instance.ChatNameStr.Length = 0;
            this.FormatRoleNameForChat(instance.ChatNameStr, talkDataTypeList[index5].PlayerName, talkDataTypeList[index5].TitleName, kingdomId);
            if (this.IsArabic)
            {
              cstringArray[index4].Append("：");
              cstringArray[index4].Append(instance.ChatNameStr);
            }
            else
            {
              cstringArray[index4].Append(instance.ChatNameStr);
              cstringArray[index4].Append("：");
            }
            ((Component) this.m_ChatChannel[index1].m_ChatEmojiRC[index4]).gameObject.SetActive(true);
            if (this.m_ChatChannel[index1].EUnit[index4] != null)
            {
              this.pushEmojiIcon(this.m_ChatChannel[index1].EUnit[index4]);
              this.m_ChatChannel[index1].EUnit[index4] = (EmojiUnit) null;
            }
            EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(talkDataTypeList[index5].EmojiKey);
            this.m_ChatChannel[index1].EUnit[index4] = this.pullEmojiIcon(recordByKey.IconID, recordByKey.KeyFrame);
            this.m_ChatChannel[index1].EUnit[index4].EmojiTransform.SetParent((Transform) this.m_ChatChannel[index1].m_ChatEmojiRC[index4], false);
            ((RectTransform) this.m_ChatChannel[index1].EUnit[index4].EmojiTransform).anchoredPosition = Vector2.zero;
            RectTransform component = this.m_ChatChannel[index1].EUnit[index4].EmojiTransform.GetComponent<RectTransform>();
            float num3 = 24f / (float) recordByKey.sizeY;
            ((Transform) component).localScale = new Vector3(num3, num3, num3);
            this.m_ChatChannel[index1].m_ChatEmojiRC[index4].anchoredPosition = new Vector2(36.5f + num2, this.m_ChatChannel[index1].m_ChatEmojiRC[index4].anchoredPosition.y) + (!this.IsArabic ? Vector2.zero : new Vector2(24f, 0.0f));
          }
          else
          {
            bool flag2 = false;
            if (talkDataTypeList[index5].FuncKind <= (byte) 100)
            {
              font.RequestCharactersInTexture(talkDataTypeList[index5].ShowName.ToString(), 17);
              for (int index7 = 0; index7 < talkDataTypeList[index5].ShowName.Length; ++index7)
              {
                if (font.GetCharacterInfo(talkDataTypeList[index5].ShowName[index7], out info, 17))
                  num1 += info.width;
                else
                  num1 += 15f;
              }
              font.RequestCharactersInTexture("：", 17);
              if (font.GetCharacterInfo('：', out info, 17))
                num1 += info.width;
              else
                num1 += 15f;
            }
            float num4 = this.m_ChatChannel[0].m_ChatTextRC[0].rect.width - 45f - num1;
            instance.ChatMainStr.Length = 0;
            if (talkDataTypeList[index5].FuncKind > (byte) 100)
              instance.ChatMainStr.Append(talkDataTypeList[index5].MainText);
            else if (this.bAutoTranslate && talkDataTypeList[index5].PlayID != instance.RoleAttr.UserId && talkDataTypeList[index5].TranslateState == eTranslateState.completed && instance.CheckLanguageTranslateByIdx((int) talkDataTypeList[index5].TranslateLanguage) && (int) talkDataTypeList[index5].TranslateLanguage != (int) IGGGameSDK.Instance.UserLanguageMapToTranslateLanguageIdx)
            {
              instance.ChatMainStr.Append(talkDataTypeList[index5].TranslateText);
              flag2 = true;
            }
            else
              instance.ChatMainStr.Append(talkDataTypeList[index5].MainText);
            font.RequestCharactersInTexture(instance.ChatMainStr.ToString(), 17);
            int length1 = instance.ColorL.Length;
            int num5 = !talkDataTypeList[index5].bHasLoc ? -1 : talkDataTypeList[index5].BeginIndex;
            int length2 = instance.ColorR.Length;
            int num6 = !talkDataTypeList[index5].bHasLoc ? -1 : talkDataTypeList[index5].EndIndex + length1;
            int StartIndex = -1;
            if (flag2)
            {
              num5 = !talkDataTypeList[index5].bHasLocT ? -1 : talkDataTypeList[index5].BeginIndexT;
              num6 = !talkDataTypeList[index5].bHasLocT ? -1 : talkDataTypeList[index5].EndIndexT + length1;
            }
            bool ForceArabic = false;
            string str = instance.ChatMainStr.ToString();
            char* chPtr = (char*) ((IntPtr) str + RuntimeHelpers.OffsetToStringData);
            float num7 = 0.0f;
            int index8;
            for (index8 = 0; index8 < instance.ChatMainStr.Length; ++index8)
            {
              if (!ForceArabic && ArabicTransfer.Instance.IsArabic(instance.ChatMainStr[index8]))
                ForceArabic = true;
              if (num5 != -1 && index8 >= num5 && index8 < num5 + length1 - 1)
              {
                if (index8 == num5 + 8)
                  instance.ChatMainStr.SetChar(index8, '0');
                else if (index8 == num5 + 9)
                  instance.ChatMainStr.SetChar(index8, '0');
                else if (index8 == num5 + 10)
                  instance.ChatMainStr.SetChar(index8, 'C');
                else if (index8 == num5 + 11)
                  instance.ChatMainStr.SetChar(index8, '3');
                else if (index8 == num5 + 12)
                  instance.ChatMainStr.SetChar(index8, 'F');
                else if (index8 == num5 + 13)
                  instance.ChatMainStr.SetChar(index8, 'E');
              }
              else if (num6 == -1 || index8 <= num6 || index8 >= num6 + length2)
              {
                if (font.GetCharacterInfo(instance.ChatMainStr[index8], out info, 17))
                  num7 += info.width;
                else
                  num7 += 15f;
                if (instance.ChatMainStr[index8] == '\n' || (double) num7 > (double) num4)
                {
                  chPtr[index8] = '.';
                  chPtr[index8 + 1] = '.';
                  chPtr[index8 + 2] = '.';
                  chPtr[index8 + 3] = char.MinValue;
                  StartIndex = index8;
                  break;
                }
              }
            }
            if (StartIndex != -1 && talkDataTypeList[index5].bHasLoc && index8 >= num5 + length1 - 1 && index8 < num6 + length2)
              instance.ChatMainStr.Insert(StartIndex, "</color>");
            str = (string) null;
            if (talkDataTypeList[index5].FuncKind <= (byte) 100)
            {
              ushort kingdomId = index1 != 0 || talkDataTypeList[index5].KingdomID <= (ushort) 0 || (int) talkDataTypeList[index5].KingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID ? (ushort) 0 : talkDataTypeList[index5].KingdomID;
              instance.ChatNameStr.Length = 0;
              this.FormatRoleNameForChat(instance.ChatNameStr, talkDataTypeList[index5].PlayerName, talkDataTypeList[index5].TitleName, kingdomId, ForceArabic);
              cstringArray[index4].StringToFormat(instance.ChatNameStr);
              cstringArray[index4].StringToFormat(instance.ChatMainStr);
              if (this.IsArabic)
              {
                if (ForceArabic)
                  cstringArray[index4].AppendFormat(instance.chatusestr);
                else
                  cstringArray[index4].AppendFormat(instance.chatusestr2);
              }
              else if (ForceArabic)
                cstringArray[index4].AppendFormat(instance.chatusestr2);
              else
                cstringArray[index4].AppendFormat(instance.chatusestr);
            }
            else
              cstringArray[index4].Append(instance.ChatMainStr);
          }
          if (talkDataTypeList[index5].TalkKind >= (byte) 4 && talkDataTypeList[index5].TalkKind <= (byte) 7)
            ((Graphic) this.m_ChatChannel[index1].m_ChatText[index4]).color = Color.green;
          else if (talkDataTypeList[index5].TalkKind == (byte) 9)
            ((Graphic) this.m_ChatChannel[index1].m_ChatText[index4]).color = (Color) new Color32(byte.MaxValue, (byte) 235, (byte) 4, byte.MaxValue);
          else if (talkDataTypeList[index5].TalkKind == (byte) 10 || talkDataTypeList[index5].TalkKind == (byte) 11)
            ((Graphic) this.m_ChatChannel[index1].m_ChatText[index4]).color = (Color) new Color32(byte.MaxValue, (byte) 238, (byte) 158, byte.MaxValue);
          else
            ((Graphic) this.m_ChatChannel[index1].m_ChatText[index4]).color = Color.white;
        }
        this.m_ChatChannel[index1].m_ChatText[index4].SetText(cstringArray[index4].ToString(), (eTextCheck) check);
        this.m_ChatChannel[index1].m_ChatText[index4].SetAllDirty();
        this.m_ChatChannel[index1].m_ChatText[index4].cachedTextGenerator.Invalidate();
      }
    }
  }

  public void BeginPageMove()
  {
    if ((UnityEngine.Object) this.m_ChatMask != (UnityEngine.Object) null)
      ((Behaviour) this.m_ChatMask).enabled = true;
    if ((UnityEngine.Object) this.m_ChatImage != (UnityEngine.Object) null)
      ((Behaviour) this.m_ChatImage).enabled = true;
    for (int index = 0; index < 2; ++index)
    {
      if (index != (int) this.ChannelIndex)
        this.m_ChatContentT.GetChild(index).gameObject.SetActive(true);
    }
  }

  public void EndPageMove()
  {
    for (int index = 0; index < 2; ++index)
    {
      if (index != (int) this.ChannelIndex)
        this.m_ChatContentT.GetChild(index).gameObject.SetActive(false);
    }
    if ((UnityEngine.Object) this.m_ChatImage != (UnityEngine.Object) null)
      ((Behaviour) this.m_ChatImage).enabled = false;
    if (!((UnityEngine.Object) this.m_ChatMask != (UnityEngine.Object) null))
      return;
    ((Behaviour) this.m_ChatMask).enabled = false;
  }

  public void PageIndexChange(byte PageIndex)
  {
    if ((int) this.ChannelIndex != (int) PageIndex)
    {
      this.ChannelIndex = PageIndex;
      DataManager.Instance.NowChannel = this.ChannelIndex;
    }
    if (this.ChannelIndex == (byte) 0)
    {
      this.m_ChatChannelLight1.sprite = this.ChannelSpriteOn;
      this.m_ChatChannelLight2.sprite = this.ChannelSpriteOff;
      if (DataManager.Instance.bRecvKingdom == (byte) 0)
        DataManager.Instance.SendAskData((byte) 0, (byte) 0, DataID: 0L, DataTime: 0L);
    }
    else if (this.ChannelIndex == (byte) 1)
    {
      this.m_ChatChannelLight1.sprite = this.ChannelSpriteOff;
      this.m_ChatChannelLight2.sprite = this.ChannelSpriteOn;
    }
    this.CheckChannelLightFlash(0);
  }

  private void CheckChannelLightFlash(int open)
  {
    if ((open == 1 || DataManager.Instance.unReadCount > 0 && DataManager.Instance.bShowUnreadCount) && this.ChannelIndex == (byte) 0)
      this.m_ChannelLightFlashGO.SetActive(true);
    else
      this.m_ChannelLightFlashGO.SetActive(false);
  }

  private void CheckNoAllianceText()
  {
    if (DataManager.Instance.RoleAlliance.Id > 0U)
      ((Component) this.NoAllianceText).gameObject.SetActive(false);
    else
      ((Component) this.NoAllianceText).gameObject.SetActive(true);
  }

  public void UpdateChatBox(int arg1, int arg2 = 0)
  {
    if ((UnityEngine.Object) this.m_ChatBox == (UnityEngine.Object) null)
      return;
    switch ((byte) arg1)
    {
      case 0:
        this.UpdateMainUIChat();
        break;
      case 6:
        this.m_ChatScrollRect.setCurrentIndex((byte) 0, true);
        this.m_ChatContentT.GetChild(1).gameObject.SetActive(false);
        this.m_ChatContentT.GetChild(0).gameObject.SetActive(true);
        break;
      case 7:
        this.m_ChatScrollRect.setCurrentIndex((byte) 1, true);
        this.m_ChatContentT.GetChild(0).gameObject.SetActive(false);
        this.m_ChatContentT.GetChild(1).gameObject.SetActive(true);
        break;
      case 8:
        this.CheckChannelLightFlash(arg2);
        break;
      case 9:
        this.CheckNoAllianceText();
        break;
    }
  }

  public bool FormatRoleNameForChat(
    CString FromattedName,
    CString Name,
    CString Tag = null,
    ushort KingdomID = 0,
    bool ForceArabic = false)
  {
    bool flag = false;
    if (FromattedName == null)
      return flag;
    FromattedName.ClearString();
    if (ForceArabic)
      flag = true;
    if (flag)
    {
      if (this.IsArabic && KingdomID > (ushort) 0)
      {
        FromattedName.IntToFormat((long) KingdomID);
        FromattedName.AppendFormat("#{0} ");
      }
      FromattedName.Append(Name);
      if (Tag != null && Tag.Length > 0)
      {
        FromattedName.StringToFormat(Tag);
        FromattedName.AppendFormat("[{0}]");
      }
      if (!this.IsArabic && KingdomID > (ushort) 0)
      {
        FromattedName.IntToFormat((long) KingdomID);
        FromattedName.AppendFormat(" {0}#");
      }
    }
    else
    {
      if (!this.IsArabic && KingdomID > (ushort) 0)
      {
        FromattedName.IntToFormat((long) KingdomID);
        FromattedName.AppendFormat("#{0} ");
      }
      if (Tag != null && Tag.Length > 0)
      {
        FromattedName.StringToFormat(Tag);
        FromattedName.AppendFormat("[{0}]");
      }
      FromattedName.Append(Name);
      if (this.IsArabic && KingdomID > (ushort) 0)
      {
        FromattedName.IntToFormat((long) KingdomID);
        FromattedName.AppendFormat(" {0}#");
      }
    }
    return flag;
  }

  public void LoginCheckOpenBtn()
  {
    this.bOpenHeroBtn = this.CheckOpenHeroBtn();
    this.bOpenAllianceBtn = this.CheckOpenAllianceBtn();
    this.bNeedForceOpenFuncBtn = false;
  }

  public bool CheckOpenHeroBtn() => DataManager.StageDataController.StageRecord[2] >= (ushort) 2;

  public bool CheckOpenAllianceBtn()
  {
    return (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 3 || DataManager.Instance.RoleAlliance.Id > 0U ? 0 : (!DataManager.Instance.CheckPrizeFlag((byte) 0) ? 1 : 0)) == 0;
  }

  public void LoadLvUpLight(Transform ParentT)
  {
    if ((UnityEngine.Object) this.m_LvUpGO != (UnityEngine.Object) null)
      this.ReleaseLvUpLight();
    AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UILight", out this.m_LvUpAssetBundleKey);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return;
    this.m_LvUpGO = (GameObject) UnityEngine.Object.Instantiate(assetBundle.mainAsset);
    if ((UnityEngine.Object) this.m_LvUpGO == (UnityEngine.Object) null)
    {
      AssetManager.UnloadAssetBundle(this.m_LvUpAssetBundleKey);
    }
    else
    {
      this.m_LvUpGO.transform.SetParent(ParentT, false);
      this.m_LvUpGO.transform.SetAsFirstSibling();
    }
  }

  public void ReleaseLvUpLight()
  {
    if (this.m_LvUpAssetBundleKey == 0)
      return;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.m_LvUpGO);
    AssetManager.UnloadAssetBundle(this.m_LvUpAssetBundleKey);
    this.m_LvUpGO = (GameObject) null;
    this.m_LvUpAssetBundleKey = 0;
  }

  private void InitialBackMessageBox()
  {
    for (int index = 0; index < 5; ++index)
    {
      this.m_SystemInChat[index].m_Message = new CString(1026);
      this.m_RunningText[index].m_Message = new CString(1026);
    }
  }

  public void ClearBackMessageBox(byte Kind = 255)
  {
    if (Kind == byte.MaxValue || Kind == (byte) 0)
    {
      this.m_BackMGWaitOpen = false;
      this.m_BackMGBeginTime = 0L;
      this.m_BackMGEndTime = 0L;
      this.m_BackMGDeltaTime = 0U;
      this.ReleaseBackMessageBox();
    }
    if (Kind == byte.MaxValue || Kind == (byte) 1)
    {
      this.m_RunningTextIndex = (byte) 0;
      for (int index = 0; index < 5; ++index)
      {
        this.m_RunningText[index].m_BeginTime = 0L;
        this.m_RunningText[index].m_EndTime = 0L;
        this.m_RunningText[index].m_TimeInterval = 0U;
      }
    }
    if (Kind != byte.MaxValue && Kind != (byte) 2)
      return;
    this.m_SystemInChatIndex = (byte) 0;
    for (int index = 0; index < 5; ++index)
    {
      this.m_SystemInChat[index].m_BeginTime = 0L;
      this.m_SystemInChat[index].m_EndTime = 0L;
      this.m_SystemInChat[index].m_TimeInterval = 0U;
    }
  }

  public void RecvBackMessageDelete(MessagePacket MP) => this.ClearBackMessageBox(MP.ReadByte());

  public void RecvBackMessage(MessagePacket MP)
  {
    int num = (int) MP.ReadByte();
    switch (MP.ReadByte())
    {
      case 0:
        this.m_BackMGBeginTime = MP.ReadLong();
        this.m_BackMGEndTime = MP.ReadLong();
        this.m_BackMGDeltaTime = MP.ReadUInt();
        MP.ReadStringPlus(241, this.m_BackMGTitle);
        MP.ReadStringPlus(1025, this.m_BackMGMessage);
        this.m_BackMGWaitOpen = false;
        break;
      case 1:
        byte runningTextIndex = this.m_RunningTextIndex;
        this.m_RunningText[(int) runningTextIndex].m_BeginTime = MP.ReadLong();
        this.m_RunningText[(int) runningTextIndex].m_EndTime = MP.ReadLong();
        this.m_RunningText[(int) runningTextIndex].m_TimeInterval = MP.ReadUInt();
        MP.ReadStringPlus(1025, this.m_RunningText[(int) runningTextIndex].m_Message);
        ++this.m_RunningTextIndex;
        if (this.m_RunningTextIndex < (byte) 5)
          break;
        this.m_RunningTextIndex = (byte) 0;
        break;
      case 2:
        byte systemInChatIndex = this.m_SystemInChatIndex;
        this.m_SystemInChat[(int) systemInChatIndex].m_BeginTime = MP.ReadLong();
        this.m_SystemInChat[(int) systemInChatIndex].m_EndTime = MP.ReadLong();
        this.m_SystemInChat[(int) systemInChatIndex].m_TimeInterval = MP.ReadUInt();
        MP.ReadStringPlus(1025, this.m_SystemInChat[(int) systemInChatIndex].m_Message);
        ActivityManager.Instance.TransToLocalTime(this.m_SystemInChat[(int) systemInChatIndex].m_Message);
        ++this.m_SystemInChatIndex;
        if (this.m_SystemInChatIndex < (byte) 5)
          break;
        this.m_SystemInChatIndex = (byte) 0;
        break;
    }
  }

  private void CheckBackMessage()
  {
    long serverTime = DataManager.Instance.ServerTime;
    if (this.m_BackMGBeginTime > 0L && serverTime >= this.m_BackMGBeginTime)
    {
      if ((serverTime - this.m_BackMGBeginTime) % (long) this.m_BackMGDeltaTime == 0L || this.m_BackMGWaitOpen)
        this.LoadBackMessageBox();
      if (this.m_BackMGEndTime < serverTime)
      {
        this.m_BackMGBeginTime = 0L;
        this.m_BackMGEndTime = 0L;
        this.m_BackMGDeltaTime = 0U;
        this.m_BackMGWaitOpen = false;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if (this.m_SystemInChat[index].m_BeginTime > 0L && serverTime >= this.m_SystemInChat[index].m_BeginTime)
      {
        if ((serverTime - this.m_SystemInChat[index].m_BeginTime) % (long) this.m_SystemInChat[index].m_TimeInterval == 0L)
          DataManager.Instance.AddSystemMessage(this.m_SystemInChat[index].m_Message, (byte) 4, -1L);
        if (this.m_SystemInChat[index].m_EndTime < serverTime)
        {
          this.m_SystemInChat[index].m_BeginTime = 0L;
          this.m_SystemInChat[index].m_EndTime = 0L;
          this.m_SystemInChat[index].m_TimeInterval = 0U;
        }
      }
      if (this.m_RunningText[index].m_BeginTime > 0L && serverTime >= this.m_RunningText[index].m_BeginTime)
      {
        if ((serverTime - this.m_RunningText[index].m_BeginTime) % (long) this.m_RunningText[index].m_TimeInterval == 0L)
          this.SetRunningText(this.m_RunningText[index].m_Message);
        if (this.m_RunningText[index].m_EndTime < serverTime)
        {
          this.m_RunningText[index].m_BeginTime = 0L;
          this.m_RunningText[index].m_EndTime = 0L;
          this.m_RunningText[index].m_TimeInterval = 0U;
        }
      }
    }
  }

  private void LoadBackMessageBox()
  {
    if (this.mUIQueueLock != 0)
    {
      this.m_BackMGWaitOpen = true;
    }
    else
    {
      this.m_BackMGWaitOpen = false;
      if ((UnityEngine.Object) this.m_BackMGGO == (UnityEngine.Object) null)
      {
        AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UIBackMessage", out this.m_BackMGAssetBundleKey);
        if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
          return;
        this.m_BackMGGO = (GameObject) UnityEngine.Object.Instantiate(assetBundle.mainAsset);
        if ((UnityEngine.Object) this.m_BackMGGO == (UnityEngine.Object) null)
        {
          AssetManager.UnloadAssetBundle(this.m_BackMGAssetBundleKey);
          return;
        }
      }
      Transform transform = this.m_BackMGGO.transform;
      UIText component1 = transform.GetChild(1).GetComponent<UIText>();
      component1.font = this.m_TTFFont;
      component1.text = this.m_BackMGTitle.ToString();
      component1.SetAllDirty();
      component1.cachedTextGenerator.Invalidate();
      UIText component2 = transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
      component2.font = this.m_TTFFont;
      component2.text = this.m_BackMGMessage.ToString();
      component2.SetAllDirty();
      component2.cachedTextGenerator.Invalidate();
      component2.cachedTextGeneratorForLayout.Invalidate();
      RectTransform component3 = transform.GetChild(2).GetChild(0).GetComponent<RectTransform>();
      component3.sizeDelta = new Vector2(component3.sizeDelta.x, component2.preferredHeight + 10f);
      transform.GetChild(3).gameObject.SetActive(false);
      transform.GetChild(4).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      transform.GetChild(4).GetComponent<UIButton>().m_BtnID1 = 13;
      UIText component4 = transform.GetChild(4).GetChild(0).GetComponent<UIText>();
      component4.font = this.m_TTFFont;
      component4.text = DataManager.Instance.mStringTable.GetStringByID(7077U);
      this.m_BackMGGO.transform.SetParent((Transform) this.m_MessageBoxLayer, false);
      this.m_BackMGGO.transform.SetAsLastSibling();
    }
  }

  private void ReleaseBackMessageBox()
  {
    if (this.m_BackMGAssetBundleKey == 0)
      return;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.m_BackMGGO);
    AssetManager.UnloadAssetBundle(this.m_BackMGAssetBundleKey);
    this.m_BackMGGO = (GameObject) null;
    this.m_BackMGAssetBundleKey = 0;
  }

  public void OpenLoadingTalk()
  {
    this.LoadingTalkTable = new CExternalTableWithWordKey<LoadingTalk>();
    if (this.LoadingTalkTable == null)
      return;
    this.LoadingTalkTable.LoadTable("LoadingTalk");
    DataManager.Instance.UnloadTableAB();
    int Key = 0;
    AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UILoadingTalk", out Key);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return;
    GameObject gameObject = (GameObject) UnityEngine.Object.Instantiate(assetBundle.mainAsset);
    if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
    {
      AssetManager.UnloadAssetBundle(Key);
    }
    else
    {
      gameObject.transform.SetParent((Transform) this.m_WindowsTransform, false);
      this.LTWin = (GUIWindow) gameObject.AddComponent("UILoadingTalk");
      this.LTWin.m_AssetBundle = assetBundle;
      this.LTWin.m_AssetBundleKey = Key;
      this.LTWin.OnOpen(0, 0);
    }
  }

  public void CloseLoadingTalk()
  {
    if (!((UnityEngine.Object) this.LTWin != (UnityEngine.Object) null))
      return;
    this.LTWin.OnClose();
    AssetManager.UnloadAssetBundle(this.LTWin.m_AssetBundleKey);
    this.LTWin.m_AssetBundle = (AssetBundle) null;
    this.LTWin.m_AssetBundleKey = 0;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.LTWin.gameObject);
    this.LTWin = (GUIWindow) null;
    this.LoadingTalkTable = (CExternalTableWithWordKey<LoadingTalk>) null;
    GC.Collect();
  }

  public void OpenLoadingTalk_TBox(int arg1, int arg2)
  {
    int Key = 0;
    AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UITBWindow", out Key);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return;
    GameObject gameObject = (GameObject) UnityEngine.Object.Instantiate(assetBundle.Load("UITreasureBox"));
    if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
    {
      AssetManager.UnloadAssetBundle(Key);
    }
    else
    {
      gameObject.transform.SetParent((Transform) this.m_WindowsTransform, false);
      this.TBoxWin = (GUIWindow) gameObject.AddComponent("UITreasureBox");
      this.TBoxWin.m_AssetBundle = assetBundle;
      this.TBoxWin.m_AssetBundleKey = Key;
      this.TBoxWin.OnOpen(arg1, arg2);
    }
  }

  public void CloseLoadingTalk_TBox()
  {
    if (!((UnityEngine.Object) this.TBoxWin != (UnityEngine.Object) null))
      return;
    this.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    AssetManager.UnloadAssetBundle(this.TBoxWin.m_AssetBundleKey);
    this.TBoxWin.m_AssetBundle = (AssetBundle) null;
    this.TBoxWin.m_AssetBundleKey = 0;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.TBoxWin.gameObject);
    this.TBoxWin = (GUIWindow) null;
    GC.Collect();
  }

  public void OpenPvPUI()
  {
    if (!((UnityEngine.Object) this.m_BattleBeginGO == (UnityEngine.Object) null))
      return;
    AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UIBattleBegin", out this.m_BattleBeginAssetBundleKey);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return;
    this.m_BattleBeginGO = (GameObject) UnityEngine.Object.Instantiate(assetBundle.mainAsset);
    if ((UnityEngine.Object) this.m_BattleBeginGO == (UnityEngine.Object) null)
    {
      AssetManager.UnloadAssetBundle(this.m_BattleBeginAssetBundleKey);
    }
    else
    {
      DataManager instance1 = DataManager.Instance;
      ArenaManager instance2 = ArenaManager.Instance;
      Transform transform = this.m_BattleBeginGO.transform;
      Color[] colorArray = new Color[2]
      {
        new Color(0.1882f, 0.8196f, 1f),
        new Color(1f, 0.3529f, 0.4431f)
      };
      transform.SetParent((Transform) this.m_SecWindowLayer, false);
      this.m_BBCanvasGroup = transform.GetComponent<CanvasGroup>();
      this.m_BBCanvasGroup.alpha = 1f;
      Transform child1 = transform.GetChild(0);
      this.m_LeftRC = child1.GetChild(0).GetComponent<RectTransform>();
      this.m_RightRC = child1.GetChild(1).GetComponent<RectTransform>();
      if (this.bOpenOnIPhoneX)
      {
        this.m_LeftRC.anchoredPosition = new Vector2(-348f, 0.0f);
        this.m_RightRC.anchoredPosition = new Vector2(53f, 0.0f);
      }
      bool flag = ((int) instance2.ArenaPlayingData.Flag & 2) > 0;
      if (!flag)
      {
        child1.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(0);
        child1.GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(1);
      }
      this.m_bbText[0] = child1.GetChild(2).GetComponent<UIText>();
      this.m_bbText[0].font = this.m_TTFFont;
      this.m_bbText[0].text = string.Empty;
      this.m_bbText[1] = child1.GetChild(3).GetComponent<UIText>();
      this.m_bbText[1].font = this.m_TTFFont;
      this.m_bbText[1].text = string.Empty;
      this.m_bbText[2] = child1.GetChild(4).GetComponent<UIText>();
      this.m_bbText[2].font = this.m_TTFFont;
      this.m_bbText[2].text = string.Empty;
      this.m_bbText[3] = child1.GetChild(5).GetComponent<UIText>();
      this.m_bbText[3].font = this.m_TTFFont;
      this.m_bbText[3].text = string.Empty;
      this.m_bbCString[0] = StringManager.Instance.SpawnString(150);
      this.m_bbCString[1] = StringManager.Instance.SpawnString(150);
      int index1 = 0;
      for (int index2 = 0; index2 < 2; ++index2)
      {
        if (instance2.ArenaPlayingData.TopicID[index2] != (byte) 0)
        {
          this.m_bbText[index1].text = instance1.mStringTable.GetStringByID(9200U + (uint) instance2.ArenaPlayingData.TopicID[index2]);
          ++index1;
        }
      }
      int index3 = 2;
      for (int index4 = 0; index4 < 2; ++index4)
      {
        if (instance2.ArenaPlayingData.TopicEffect[index4].Effect != (ushort) 0)
        {
          GameConstants.GetEffectValue(this.m_bbCString[index4], instance2.ArenaPlayingData.TopicEffect[index4].Effect, (uint) instance2.ArenaPlayingData.TopicEffect[index4].Value, (byte) 10, 0.0f);
          this.m_bbText[index3].text = this.m_bbCString[index4].ToString();
          ++index3;
        }
      }
      byte count1 = 0;
      byte count2 = 0;
      ushort[] numArray1 = new ushort[5];
      byte[] numArray2 = new byte[5];
      ushort[] numArray3 = new ushort[5];
      byte[] numArray4 = new byte[5];
      for (int index5 = 0; index5 < 5; ++index5)
      {
        if (instance2.ArenaPlayingData.MyHeroData[index5].ID > (ushort) 0 && this.CheckHeroAstrology(instance2.ArenaPlayingData.MyHeroData[index5].ID))
        {
          numArray1[(int) count1] = instance2.ArenaPlayingData.MyHeroData[index5].ID;
          numArray2[(int) count1] = instance2.ArenaPlayingData.MyHeroData[index5].Star;
          ++count1;
        }
        if (instance2.ArenaPlayingData.EnemyHeroData[index5].ID > (ushort) 0 && this.CheckHeroAstrology(instance2.ArenaPlayingData.EnemyHeroData[index5].ID))
        {
          numArray3[(int) count2] = instance2.ArenaPlayingData.EnemyHeroData[index5].ID;
          numArray4[(int) count2] = instance2.ArenaPlayingData.EnemyHeroData[index5].Star;
          ++count2;
        }
      }
      int num1 = !flag ? 1 : 0;
      Transform child2 = transform.GetChild(0).GetChild(num1);
      for (byte index6 = 0; (int) index6 < (int) count1; ++index6)
      {
        Transform child3 = child2.GetChild((int) index6);
        this.InitianHeroItemImg(child3.GetChild(0), eHeroOrItem.Hero, numArray1[(int) index6], numArray2[(int) index6], (byte) 0);
        child3.gameObject.SetActive(true);
        if (count1 < (byte) 5)
          child2.GetChild((int) index6).GetComponent<RectTransform>().anchoredPosition = this.GetPvPIconPos((byte) num1, count1, index6);
        child3.GetChild(1).gameObject.SetActive(true);
      }
      this.m_bbText[4] = child2.GetChild(5).GetChild(0).GetComponent<UIText>();
      this.m_bbText[4].font = this.m_TTFFont;
      this.m_bbText[4].text = instance1.mStringTable.GetStringByID(8229U);
      ((Graphic) this.m_bbText[4]).color = colorArray[0];
      int num2 = !flag ? 0 : 1;
      Transform child4 = transform.GetChild(0).GetChild(num2);
      for (byte index7 = 0; (int) index7 < (int) count2; ++index7)
      {
        Transform child5 = child4.GetChild((int) index7);
        this.InitianHeroItemImg(child5.GetChild(0), eHeroOrItem.Hero, numArray3[(int) index7], numArray4[(int) index7], (byte) 0);
        child5.gameObject.SetActive(true);
        if (count2 < (byte) 5)
          child4.GetChild((int) index7).GetComponent<RectTransform>().anchoredPosition = this.GetPvPIconPos((byte) num2, count2, index7);
        child5.GetChild(1).gameObject.SetActive(true);
      }
      this.m_bbCString[2] = StringManager.Instance.SpawnString(150);
      this.m_bbText[5] = child4.GetChild(5).GetChild(0).GetComponent<UIText>();
      this.m_bbText[5].font = this.m_TTFFont;
      ((Graphic) this.m_bbText[5]).color = colorArray[1];
      if (instance2.ArenaPlayingData.EnemyName.Length > 0)
      {
        if (instance2.ArenaPlayingData.EnemyAllianceTag.Length > 0)
        {
          this.m_bbCString[2].StringToFormat(instance2.ArenaPlayingData.EnemyAllianceTag);
          this.m_bbCString[2].AppendFormat("[{0}]");
        }
        this.m_bbCString[2].Append(instance2.ArenaPlayingData.EnemyName);
      }
      this.m_bbText[5].text = this.m_bbCString[2].ToString();
      if (this.IsArabic)
      {
        UIText component = transform.GetChild(0).GetChild(1).GetChild(5).GetChild(0).GetComponent<UIText>();
        ((Transform) ((Graphic) component).rectTransform).localRotation = new Quaternion(0.0f, 180f, 0.0f, 0.0f);
        component.alignment = TextAnchor.MiddleLeft;
      }
      this.m_BBStep = GUIManager.eBBSetp.eMax;
      this.ShowUILock(EUILock.Normal);
    }
  }

  public void ClosePvPUI()
  {
    if (this.m_BattleBeginAssetBundleKey == 0)
      return;
    this.m_BBStep = GUIManager.eBBSetp.eMax;
    this.m_BBDeltaTime = 0.0f;
    this.m_LeftRC = (RectTransform) null;
    this.m_RightRC = (RectTransform) null;
    this.m_BBCanvasGroup = (CanvasGroup) null;
    for (int index = 0; index < this.m_bbText.Length; ++index)
      this.m_bbText[index] = (UIText) null;
    for (int index = 0; index < this.m_bbCString.Length; ++index)
      StringManager.Instance.DeSpawnString(this.m_bbCString[index]);
    UnityEngine.Object.Destroy((UnityEngine.Object) this.m_BattleBeginGO);
    AssetManager.UnloadAssetBundle(this.m_BattleBeginAssetBundleKey);
    this.m_BattleBeginGO = (GameObject) null;
    this.m_BattleBeginAssetBundleKey = 0;
    this.HideUILock(EUILock.Normal);
    DataManager.msgBuffer[0] = (byte) 123;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void BeginPvPOpening() => this.m_BBStep = GUIManager.eBBSetp.eMoveIn;

  private void UpDatePvPUI()
  {
    if ((UnityEngine.Object) this.m_BattleBeginGO == (UnityEngine.Object) null || this.m_BBStep == GUIManager.eBBSetp.eMax)
      return;
    this.m_BBDeltaTime += Time.smoothDeltaTime;
    if (this.m_BBStep == GUIManager.eBBSetp.eMoveIn)
    {
      if ((double) this.m_BBDeltaTime <= 0.10000000149011612)
      {
        this.m_LeftRC.anchoredPosition = new Vector2(Mathf.Lerp(-295f, 0.0f, this.m_BBDeltaTime / 0.1f), 0.0f);
        this.m_RightRC.anchoredPosition = new Vector2(Mathf.Lerp(0.0f, -295f, this.m_BBDeltaTime / 0.1f), 0.0f);
      }
      else
      {
        this.m_BBStep = GUIManager.eBBSetp.eWait;
        this.m_BBDeltaTime = 0.0f;
        this.m_LeftRC.anchoredPosition = new Vector2(0.0f, 0.0f);
        this.m_RightRC.anchoredPosition = new Vector2(-295f, 0.0f);
        AudioManager.Instance.PlayUISFX(UIKind.HeroSkill);
      }
    }
    else if (this.m_BBStep == GUIManager.eBBSetp.eWait)
    {
      if ((double) this.m_BBDeltaTime <= 1.0)
        return;
      this.m_BBStep = GUIManager.eBBSetp.eFadeOut;
      this.m_BBDeltaTime = 0.0f;
    }
    else
    {
      if (this.m_BBStep != GUIManager.eBBSetp.eFadeOut)
        return;
      if ((double) this.m_BBDeltaTime <= 1.0)
        this.m_BBCanvasGroup.alpha = Mathf.Lerp(1f, 0.0f, this.m_BBDeltaTime / 1f);
      else
        this.ClosePvPUI();
    }
  }

  private float easeOutBounce(float start, float end, float value)
  {
    value /= 1f;
    end -= start;
    if ((double) value < 0.36363637447357178)
      return end * (121f / 16f * value * value) + start;
    if ((double) value < 0.72727274894714355)
    {
      value -= 0.545454562f;
      return end * (float) (121.0 / 16.0 * (double) value * (double) value + 0.75) + start;
    }
    if ((double) value < 10.0 / 11.0)
    {
      value -= 0.8181818f;
      return end * (float) (121.0 / 16.0 * (double) value * (double) value + 15.0 / 16.0) + start;
    }
    value -= 0.954545438f;
    return end * (float) (121.0 / 16.0 * (double) value * (double) value + 63.0 / 64.0) + start;
  }

  private Vector2 GetPvPIconPos(byte side, byte count, byte Index)
  {
    Vector2 pvPiconPos = new Vector2();
    if (side == (byte) 0)
    {
      switch (count)
      {
        case 1:
          pvPiconPos.x = 90f;
          pvPiconPos.y = -60f;
          break;
        case 2:
          switch (Index)
          {
            case 0:
              pvPiconPos.x = 50f;
              pvPiconPos.y = -60f;
              break;
            case 1:
              pvPiconPos.x = 129f;
              pvPiconPos.y = -60f;
              break;
          }
          break;
        case 3:
          switch (Index)
          {
            case 0:
              pvPiconPos.x = 89f;
              pvPiconPos.y = -20f;
              break;
            case 1:
              pvPiconPos.x = 50f;
              pvPiconPos.y = -99f;
              break;
            case 2:
              pvPiconPos.x = 129f;
              pvPiconPos.y = -99f;
              break;
          }
          break;
        case 4:
          switch (Index)
          {
            case 0:
              pvPiconPos.x = 50f;
              pvPiconPos.y = -20f;
              break;
            case 1:
              pvPiconPos.x = 129f;
              pvPiconPos.y = -20f;
              break;
            case 2:
              pvPiconPos.x = 50f;
              pvPiconPos.y = -99f;
              break;
            case 3:
              pvPiconPos.x = 129f;
              pvPiconPos.y = -99f;
              break;
          }
          break;
      }
    }
    else
    {
      switch (count)
      {
        case 1:
          pvPiconPos.x = 160f;
          pvPiconPos.y = -60f;
          break;
        case 2:
          switch (Index)
          {
            case 0:
              pvPiconPos.x = 200f;
              pvPiconPos.y = -60f;
              break;
            case 1:
              pvPiconPos.x = 121f;
              pvPiconPos.y = -60f;
              break;
          }
          break;
        case 3:
          switch (Index)
          {
            case 0:
              pvPiconPos.x = 160f;
              pvPiconPos.y = -20f;
              break;
            case 1:
              pvPiconPos.x = 200f;
              pvPiconPos.y = -99f;
              break;
            case 2:
              pvPiconPos.x = 121f;
              pvPiconPos.y = -99f;
              break;
          }
          break;
        case 4:
          switch (Index)
          {
            case 0:
              pvPiconPos.x = 200f;
              pvPiconPos.y = -20f;
              break;
            case 1:
              pvPiconPos.x = 121f;
              pvPiconPos.y = -20f;
              break;
            case 2:
              pvPiconPos.x = 200f;
              pvPiconPos.y = -99f;
              break;
            case 3:
              pvPiconPos.x = 121f;
              pvPiconPos.y = -99f;
              break;
          }
          break;
      }
    }
    return pvPiconPos;
  }

  private bool CheckHeroAstrology(ushort HeroID)
  {
    ArenaManager instance = ArenaManager.Instance;
    ArenaHeroTopic recordByKey = DataManager.Instance.ArenaHeroTopicData.GetRecordByKey(HeroID);
    return instance.ArenaPlayingData.TopicID[0] != (byte) 0 && ((int) (recordByKey.Value >> (int) instance.ArenaPlayingData.TopicID[0] - 1) & 1) == 1 || instance.ArenaPlayingData.TopicID[1] != (byte) 0 && ((int) (recordByKey.Value >> (int) instance.ArenaPlayingData.TopicID[1] - 1) & 1) == 1;
  }

  public void Recv_WONDER_INIT_NOTICE(MessagePacket MP)
  {
    this.bShowWonder = false;
    this.WonderCountTime.BeginTime = MP.ReadLong();
    this.WonderCountTime.RequireTime = MP.ReadUInt();
    if (MP.ReadByte() == (byte) 1 && (this.NowBeginTime != this.WonderCountTime.BeginTime || DataManager.Instance.ServerTime - this.ShowRunningTime >= 1200L))
    {
      this.NowBeginTime = this.WonderCountTime.BeginTime;
      this.ShowRunningTime = DataManager.Instance.ServerTime;
      if (!ActivityManager.Instance.IsInKvK((ushort) 0))
      {
        CString str = StringManager.Instance.SpawnString(1024);
        str.Append(DataManager.Instance.mStringTable.GetStringByID(9311U));
        this.WonderCountStr.Add(str);
        this.SetRunningText(str);
      }
    }
    this.UpDateWonderCountTime();
  }

  public void Recv_WONDER_TAKEOVER_NOTICE(MessagePacket MP)
  {
    CString cstring1 = StringManager.Instance.StaticString1024();
    CString cstring2 = StringManager.Instance.StaticString1024();
    CString cstring3 = StringManager.Instance.StaticString1024();
    CString str = StringManager.Instance.SpawnString(1024);
    byte WonderID = MP.ReadByte();
    MP.ReadStringPlus(20, cstring1);
    MP.ReadStringPlus(13, cstring2);
    MP.ReadStringPlus(3, cstring3);
    str.StringToFormat(cstring3);
    str.StringToFormat(cstring1);
    str.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) WonderID, (ushort) 0));
    str.StringToFormat(cstring2);
    str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9379U));
    this.WonderCountStr.Add(str);
    this.SetRunningText(str);
  }

  public void Recv_WONDER_PEACE_NOTICE(MessagePacket MP)
  {
    CString cstring1 = StringManager.Instance.StaticString1024();
    CString cstring2 = StringManager.Instance.StaticString1024();
    CString str = StringManager.Instance.SpawnString(1024);
    byte WonderID = MP.ReadByte();
    MP.ReadStringPlus(20, cstring1);
    this.WonderCountTime.BeginTime = MP.ReadLong();
    this.WonderCountTime.RequireTime = MP.ReadUInt();
    MP.ReadStringPlus(3, cstring2);
    str.StringToFormat(cstring2);
    str.StringToFormat(cstring1);
    str.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) WonderID, (ushort) 0));
    str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9380U));
    this.WonderCountStr.Add(str);
    this.SetRunningText(str);
  }

  public void Recv_WONDER_PEACE_OVER(MessagePacket MP)
  {
    this.bShowWonder = false;
    this.WonderCountTime.BeginTime = 0L;
    this.WonderCountTime.RequireTime = 0U;
    if (!ActivityManager.Instance.IsInKvK((ushort) 0))
    {
      CString str = StringManager.Instance.SpawnString(1024);
      str.Append(DataManager.Instance.mStringTable.GetStringByID(9311U));
      this.WonderCountStr.Add(str);
      this.SetRunningText(str);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_DevelopmentDetails, 1);
  }

  private void UpDateWonderCountTime()
  {
    if (this.bShowWonder || this.WonderCountTime.BeginTime == 0L || this.WonderCountTime.BeginTime + (long) this.WonderCountTime.RequireTime - DataManager.Instance.ServerTime != 600L)
      return;
    this.bShowWonder = true;
    CString str = StringManager.Instance.SpawnString(1024);
    str.Append(DataManager.Instance.mStringTable.GetStringByID(9310U));
    this.WonderCountStr.Add(str);
    this.SetRunningText(str);
  }

  public void ClearWonderStr()
  {
    for (int index = 0; index < this.WonderCountStr.Count; ++index)
      StringManager.Instance.DeSpawnString(this.WonderCountStr[index]);
    this.WonderCountStr.Clear();
  }

  public void Recv_WORLDWONDER_OPEN(MessagePacket MP)
  {
    if (MP.ReadByte() == (byte) 0)
    {
      if (DataManager.Instance.ServerTime - this.KOW_ShowRunningTime < 1200L)
        return;
      this.KOW_ShowRunningTime = DataManager.Instance.ServerTime;
      CString str = StringManager.Instance.SpawnString(1024);
      str.Append(DataManager.Instance.mStringTable.GetStringByID(11016U));
      this.KOWCountStr.Add(str);
      this.SetRunningText(str);
    }
    else
    {
      if (DataManager.Instance.ServerTime - this.NW_ShowRunningTime < 1200L)
        return;
      this.NW_ShowRunningTime = DataManager.Instance.ServerTime;
      CString str = StringManager.Instance.SpawnString(1024);
      str.Append(DataManager.Instance.mStringTable.GetStringByID(11098U));
      this.KOWCountStr.Add(str);
      this.SetRunningText(str);
    }
  }

  public void Recv_WORLDWONDER_TAKEOVER(MessagePacket MP)
  {
    CString cstring1 = StringManager.Instance.StaticString1024();
    CString cstring2 = StringManager.Instance.StaticString1024();
    CString str = StringManager.Instance.SpawnString(1024);
    ushort x = MP.ReadUShort();
    MP.ReadStringPlus(13, cstring1);
    MP.ReadStringPlus(3, cstring2);
    byte WonderID = MP.ReadByte();
    if (WonderID == (byte) 0)
    {
      str.IntToFormat((long) x);
      str.StringToFormat(cstring2);
      str.StringToFormat(cstring1);
      str.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9990U));
      str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11017U));
    }
    else
    {
      str.IntToFormat((long) x);
      str.StringToFormat(cstring2);
      str.StringToFormat(cstring1);
      if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.FocusKingdomID)
        str.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) WonderID, DataManager.MapDataController.OtherKingdomData.kingdomID));
      else
        str.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) WonderID, DataManager.MapDataController.FocusKingdomID));
      str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11017U));
    }
    this.KOWCountStr.Add(str);
    this.SetRunningText(str);
  }

  public void Recv_WORLDWONDER_CLOSE(MessagePacket MP)
  {
    CString cstring1 = StringManager.Instance.StaticString1024();
    CString cstring2 = StringManager.Instance.StaticString1024();
    CString str = StringManager.Instance.SpawnString(1024);
    ushort x = MP.ReadUShort();
    MP.ReadStringPlus(13, cstring1);
    MP.ReadStringPlus(3, cstring2);
    byte WonderID = MP.ReadByte();
    if (WonderID == (byte) 0)
    {
      str.IntToFormat((long) x);
      str.StringToFormat(cstring2);
      str.StringToFormat(cstring1);
      str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11018U));
    }
    else
    {
      if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.FocusKingdomID)
        str.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) WonderID, DataManager.MapDataController.OtherKingdomData.kingdomID));
      else
        str.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) WonderID, DataManager.MapDataController.FocusKingdomID));
      str.IntToFormat((long) x);
      str.StringToFormat(cstring2);
      str.StringToFormat(cstring1);
      str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11100U));
    }
    this.KOWCountStr.Add(str);
    this.SetRunningText(str);
  }

  public void ClearKOWStr()
  {
    for (int index = 0; index < this.KOWCountStr.Count; ++index)
      StringManager.Instance.DeSpawnString(this.KOWCountStr[index]);
    this.KOWCountStr.Clear();
  }

  public void SetbNeedTranslate(TalkDataType tmpData)
  {
    if (tmpData == null || tmpData.FuncKind != (byte) 109 && this.CheckNeedTranslate(tmpData.MainText))
      return;
    tmpData.TranslateState = eTranslateState.NoNeedTranslate;
  }

  public bool TransLatebyIndex(TalkDataType tmpData)
  {
    if (tmpData == null)
      return false;
    if (this.bWaitTranslate)
    {
      this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8459U), (ushort) byte.MaxValue);
      return false;
    }
    this.TranslateData = tmpData;
    this.TranslateID = this.TranslateData.TalkID;
    this.TranslateData.OriginalText.SetLength(this.TranslateData.OriginalText.Length);
    IGGSDKPlugin.Translate(this.TranslateData.OriginalText.ToString());
    this.TranslateData.OriginalText.SetLength(this.TranslateData.OriginalText.MaxLength);
    this.TranslateData.TranslateState = eTranslateState.Translation;
    this.bWaitTranslate = true;
    return true;
  }

  public void TranslateBatch(TalkDataType tmpData)
  {
    if (!this.bAutoTranslate || tmpData == null || this.bWaitTranslate)
      return;
    DataManager instance = DataManager.Instance;
    if (tmpData.TalkKind != (byte) 0 || tmpData.PlayID == instance.RoleAttr.UserId)
      return;
    if (this.CheckNeedTranslate(tmpData.MainText))
    {
      this.TranslateStrListID.Add(tmpData.TalkID);
      this.TranslateDataList.Add(tmpData);
    }
    else
      tmpData.TranslateState = eTranslateState.NoNeedTranslate;
  }

  public void SendTranslateBatch()
  {
    if (!this.bAutoTranslate || this.bWaitTranslate)
      return;
    if (this.TranslateStrListID.Count > 0)
    {
      this.bWaitTranslate = true;
      this.TranslateCStrList.Clear();
      for (int index = 0; index < this.TranslateDataList.Count; ++index)
      {
        this.TranslateCStrList.Add(this.TranslateDataList[index].OriginalText);
        this.TranslateDataList[index].TranslateState = eTranslateState.Translation;
      }
      IGGGameSDK.Instance.TranslateBatchByList(this.TranslateCStrList);
    }
    else
    {
      this.TranslateStrListID.Clear();
      this.TranslateDataList.Clear();
    }
  }

  public void BackTranslate()
  {
    this.bBackTranslate = false;
    this.bWaitTranslate = false;
    if (this.TranslateData == null || this.TranslateID != this.TranslateData.TalkID)
      return;
    this.TranslateData.TranslateComplete(this.GetTranslateSplit(this.TranslateStr, this.TranslateData));
    this.TranslateData.TotalHeightT = 0.0f;
    this.TranslateData.TotalHeight = 0.0f;
    this.CheckText(this.TranslateData);
    this.UpdateUI(EGUIWindow.UI_Chat, 10);
    this.UpdateChatBox(0);
  }

  public void BackTranslateBatch()
  {
    this.bBackTranslateBatch = false;
    this.bWaitTranslate = false;
    IGGGameSDK instance = IGGGameSDK.Instance;
    for (int index = 0; index < this.TranslateDataList.Count; ++index)
    {
      if (this.TranslateDataList[index].TalkID == this.TranslateStrListID[index])
      {
        instance.TranslateString[index].SetLength(instance.TranslateString[index].Length);
        this.TranslateDataList[index].TranslateComplete(this.GetTranslateSplit(instance.TranslateString[index].ToString(), this.TranslateDataList[index]));
        instance.TranslateString[index].SetLength(instance.TranslateString[index].MaxLength);
        this.TranslateDataList[index].TotalHeightT = 0.0f;
        this.TranslateDataList[index].TotalHeight = 0.0f;
        this.CheckText(this.TranslateDataList[index]);
      }
    }
    this.TranslateStrListID.Clear();
    this.TranslateDataList.Clear();
    this.UpdateUI(EGUIWindow.UI_Chat, 12);
    this.UpdateChatBox(0);
  }

  public void BackTranslateFail()
  {
    this.bWaitTranslate = false;
    if (this.bBackTranslateFail == (byte) 1)
    {
      this.TranslateData.TranslateState = eTranslateState.TranslateFail;
      this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9077U), (ushort) byte.MaxValue);
      this.TranslateData = (TalkDataType) null;
      this.TranslateID = -1L;
    }
    else if (this.bBackTranslateFail == (byte) 2)
    {
      for (int index = 0; index < this.TranslateDataList.Count; ++index)
      {
        if (this.TranslateDataList[index] != null)
        {
          this.TranslateDataList[index].TranslateState = eTranslateState.TranslateFail;
          this.TranslateDataList[index].TotalHeightT = 0.0f;
          this.TranslateDataList[index].TotalHeight = 0.0f;
        }
      }
      this.TranslateStrListID.Clear();
      this.TranslateDataList.Clear();
    }
    this.UpdateUI(EGUIWindow.UI_Chat, 12);
    this.bBackTranslateFail = (byte) 0;
  }

  private void CheckText(TalkDataType tmpTalk)
  {
    CString translateText = tmpTalk.TranslateText;
    int StartIndex = -1;
    int num1 = -1;
    int length = translateText.Length;
    int index1 = 0;
    while (index1 < length && (StartIndex == -1 || num1 == -1))
    {
      char ch1 = translateText[index1];
      ++index1;
      if (index1 != length)
      {
        if (translateText[index1] == ':' || translateText[index1] == '：')
        {
          int num2 = index1;
          switch (ch1)
          {
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
              int index2 = index1 - 1;
              char ch2;
              do
              {
                --index2;
                if (index2 >= 0)
                  ch2 = translateText[index2];
                else
                  break;
              }
              while (ch2 >= '0' && ch2 <= '9');
              int index3 = index2 + 1;
              char ch3 = translateText[index3];
              StartIndex = index3;
              int num3 = 0;
              byte num4 = 1;
              do
              {
                num3 = num3 * 10 + (int) ch3 - 48;
                ++index3;
                if (index3 != length)
                  ch3 = translateText[index3];
                else
                  break;
              }
              while (ch3 >= '0' && ch3 <= '9' && num3 < (int) ushort.MaxValue);
              if (ch3 == ':' || ch3 == '：')
              {
                index1 = index3 + 1;
                while (index1 < length && (ch3 = translateText[index1]) == ' ')
                  ++index1;
                if (index1 < length)
                {
                  if (ch3 >= '0' && ch3 <= '9')
                  {
                    int num5 = 0;
                    byte num6 = (byte) ((uint) num4 + 1U);
                    do
                    {
                      num5 = num5 * 10 + (int) ch3 - 48;
                      ++index1;
                      if (index1 != length)
                        ch3 = translateText[index1];
                      else
                        break;
                    }
                    while (ch3 >= '0' && ch3 <= '9' && num5 < (int) ushort.MaxValue);
                    if (ch3 == ':' || ch3 == '：')
                    {
                      ++index1;
                      while (index1 < length && (ch3 = translateText[index1]) == ' ')
                        ++index1;
                      if (index1 < length)
                      {
                        if (ch3 >= '0' && ch3 <= '9')
                        {
                          int num7 = 0;
                          ++num6;
                          do
                          {
                            num7 = num7 * 10 + (int) ch3 - 48;
                            ++index1;
                            if (index1 != length)
                            {
                              ch3 = translateText[index1];
                              switch (ch3)
                              {
                                case '0':
                                case '1':
                                case '2':
                                case '3':
                                case '4':
                                case '5':
                                case '6':
                                case '7':
                                case '8':
                                case '9':
                                  continue;
                                default:
                                  goto label_65;
                              }
                            }
                            else
                              break;
                          }
                          while (num7 < (int) ushort.MaxValue);
                        }
                      }
                      else
                        goto label_70;
                    }
label_65:
                    if (num6 > (byte) 1)
                    {
                      num1 = index1;
                      continue;
                    }
                    continue;
                  }
                  continue;
                }
                goto label_70;
              }
              else
              {
                StartIndex = -1;
                index1 = num2;
                continue;
              }
            case 'K':
              StartIndex = index1 - 1;
              ++index1;
              while (index1 < length && (ch1 = translateText[index1]) == ' ')
                ++index1;
              if (index1 < length)
              {
                if (ch1 >= '0' && ch1 <= '9')
                {
                  int num8 = 0;
                  do
                  {
                    num8 = num8 * 10 + (int) ch1 - 48;
                    ++index1;
                    if (index1 != length)
                    {
                      ch1 = translateText[index1];
                      switch (ch1)
                      {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                        case '7':
                        case '8':
                        case '9':
                          continue;
                        default:
                          goto label_13;
                      }
                    }
                    else
                      break;
                  }
                  while (num8 < (int) ushort.MaxValue);
label_13:
                  ++index1;
                  if (index1 < length)
                  {
                    if (ch1 == ' ')
                    {
                      char ch4 = translateText[index1];
                      ++index1;
                      if (index1 < length)
                      {
                        if (ch4 == 'X' && (translateText[index1] == ':' || translateText[index1] == '：'))
                        {
                          ++index1;
                          while (index1 < length && (ch4 = translateText[index1]) == ' ')
                            ++index1;
                          if (index1 < length)
                          {
                            if (ch4 >= '0' && ch4 <= '9')
                            {
                              int num9 = 0;
                              do
                              {
                                num9 = num9 * 10 + (int) ch4 - 48;
                                ++index1;
                                if (index1 != length)
                                {
                                  ch4 = translateText[index1];
                                  switch (ch4)
                                  {
                                    case '0':
                                    case '1':
                                    case '2':
                                    case '3':
                                    case '4':
                                    case '5':
                                    case '6':
                                    case '7':
                                    case '8':
                                    case '9':
                                      continue;
                                    default:
                                      goto label_26;
                                  }
                                }
                                else
                                  break;
                              }
                              while (num9 < (int) ushort.MaxValue);
label_26:
                              ++index1;
                              if (index1 < length)
                              {
                                if (ch4 == ' ')
                                {
                                  char ch5 = translateText[index1];
                                  ++index1;
                                  if (index1 < length)
                                  {
                                    if (ch5 == 'Y' && (translateText[index1] == ':' || translateText[index1] == '：'))
                                    {
                                      ++index1;
                                      while (index1 < length && (ch5 = translateText[index1]) == ' ')
                                        ++index1;
                                      if (index1 < length)
                                      {
                                        if (ch5 >= '0' && ch5 <= '9')
                                        {
                                          int num10 = 0;
                                          do
                                          {
                                            num10 = num10 * 10 + (int) ch5 - 48;
                                            ++index1;
                                            if (index1 != length)
                                            {
                                              ch5 = translateText[index1];
                                              switch (ch5)
                                              {
                                                case '0':
                                                case '1':
                                                case '2':
                                                case '3':
                                                case '4':
                                                case '5':
                                                case '6':
                                                case '7':
                                                case '8':
                                                case '9':
                                                  continue;
                                                default:
                                                  goto label_39;
                                              }
                                            }
                                            else
                                              break;
                                          }
                                          while (num10 < (int) ushort.MaxValue);
label_39:
                                          num1 = index1;
                                          continue;
                                        }
                                        continue;
                                      }
                                      goto label_70;
                                    }
                                    else
                                      continue;
                                  }
                                  else
                                    goto label_70;
                                }
                                else
                                  continue;
                              }
                              else
                                goto label_70;
                            }
                            else
                              continue;
                          }
                          else
                            goto label_70;
                        }
                        else
                          continue;
                      }
                      else
                        goto label_70;
                    }
                    else
                      continue;
                  }
                  else
                    goto label_70;
                }
                else
                  continue;
              }
              else
                goto label_70;
            default:
              continue;
          }
        }
      }
      else
        break;
    }
label_70:
    if (StartIndex == -1 || num1 == -1 || tmpTalk.LocX >= 512 || tmpTalk.LocY >= 1024)
      return;
    tmpTalk.bHasLocT = true;
    tmpTalk.BeginIndexT = StartIndex;
    tmpTalk.EndIndexT = num1;
    translateText.Insert(StartIndex, DataManager.Instance.ColorL);
    translateText.Insert(num1 + DataManager.Instance.ColorL.Length, DataManager.Instance.ColorR);
  }

  public ushort GetTranslateSplit(string s, TalkDataType TData)
  {
    if (s == null)
      return 0;
    char ch = '\u007F';
    CString cstring = StringManager.Instance.StaticString1024();
    int index;
    for (index = 0; index < s.Length && (int) s[index] != (int) ch; ++index)
      cstring.Append(s[index]);
    cstring.SetLength(cstring.Length);
    ushort languageStringId = (ushort) IGGGameSDK.Instance.GetTranslateLanguageStringId(cstring.ToString());
    cstring.SetLength(cstring.MaxLength);
    TData.TranslateText.Length = 0;
    TData.TranslateText.Substring(s, index + 1);
    TData.TranslateText.CheckBannedWord();
    return languageStringId;
  }

  public void MB_SetbNeedTranslate(MessageBoard tmpData)
  {
    if (tmpData == null || this.CheckNeedTranslate(tmpData.MessageStr))
      return;
    tmpData.TranslateState = eTranslateState.NoNeedTranslate;
  }

  public void MB_TranslateBatch(MessageBoard tmpData)
  {
    if (!this.bAutoTranslate || tmpData == null || tmpData.bSelfMessage)
      return;
    if (this.CheckNeedTranslate(tmpData.MessageStr))
    {
      this.MB_TranslateDataList.Add(tmpData);
      this.MB_TranslateStrListID.Add(tmpData.MessageID);
    }
    else
      tmpData.TranslateState = eTranslateState.NoNeedTranslate;
  }

  public void MB_SendTranslateBatch()
  {
    if (!this.bAutoTranslate)
      return;
    if (this.bWaitTranslate_MB)
      this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8459U), (ushort) byte.MaxValue);
    else if (this.MB_TranslateStrListID.Count > 0)
    {
      this.bWaitTranslate_MB = true;
      this.MB_TranslateCStrList.Clear();
      for (int index = 0; index < this.MB_TranslateDataList.Count; ++index)
      {
        this.MB_TranslateCStrList.Add(this.MB_TranslateDataList[index].MessageStr);
        this.MB_TranslateDataList[index].TranslateState = eTranslateState.Translation;
      }
      IGGGameSDK.Instance.TranslateBatchByList_Diplomatic(this.MB_TranslateCStrList);
    }
    else
    {
      this.MB_TranslateStrListID.Clear();
      this.MB_TranslateDataList.Clear();
    }
  }

  public void MB_BackTranslateBatch()
  {
    this.bWaitTranslate_MB = false;
    this.bBackTranslateBatch_MB = false;
    IGGGameSDK instance = IGGGameSDK.Instance;
    for (int index = 0; index < this.MB_TranslateDataList.Count && index < instance.TranslateString_Diplomatic.Length; ++index)
    {
      if (this.MB_TranslateDataList[index].MessageID == this.MB_TranslateStrListID[index])
      {
        instance.TranslateString_Diplomatic[index].SetLength(instance.TranslateString_Diplomatic[index].Length);
        this.MB_TranslateDataList[index].TranslateComplete(this.MB_GetTranslateSplit(instance.TranslateString_Diplomatic[index].ToString(), this.MB_TranslateDataList[index]));
        instance.TranslateString_Diplomatic[index].SetLength(instance.TranslateString_Diplomatic[index].MaxLength);
        this.MB_TranslateDataList[index].TotalHeightT = 0.0f;
        this.MB_TranslateDataList[index].TotalHeight = 0.0f;
      }
    }
    this.MB_TranslateStrListID.Clear();
    this.MB_TranslateDataList.Clear();
    this.UpdateUI(EGUIWindow.UI_MessageBoard, 4);
  }

  public void MB_BackTranslateFail()
  {
    this.bWaitTranslate_MB = false;
    for (int index = 0; index < this.MB_TranslateDataList.Count; ++index)
    {
      if (this.MB_TranslateDataList[index] != null)
      {
        this.MB_TranslateDataList[index].TranslateState = eTranslateState.TranslateFail;
        this.MB_TranslateDataList[index].TotalHeightT = 0.0f;
        this.MB_TranslateDataList[index].TotalHeight = 0.0f;
      }
    }
    this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9077U), (ushort) byte.MaxValue);
    this.MB_TranslateStrListID.Clear();
    this.MB_TranslateDataList.Clear();
    this.bBackTranslateFail_MB = (byte) 0;
    this.UpdateUI(EGUIWindow.UI_MessageBoard, 4);
  }

  public ushort MB_GetTranslateSplit(string s, MessageBoard TData)
  {
    if (s == null)
      return 0;
    char ch = '\u007F';
    CString cstring = StringManager.Instance.StaticString1024();
    int index;
    for (index = 0; index < s.Length && (int) s[index] != (int) ch; ++index)
      cstring.Append(s[index]);
    cstring.SetLength(cstring.Length);
    ushort languageStringId = (ushort) IGGGameSDK.Instance.GetTranslateLanguageStringId(cstring.ToString());
    cstring.SetLength(cstring.MaxLength);
    TData.TranslateText.Length = 0;
    TData.TranslateText.Substring(s, index + 1);
    TData.TranslateText.CheckBannedWord();
    return languageStringId;
  }

  public bool CheckNeedTranslate(string tmpStr)
  {
    for (int index = 0; index < tmpStr.Length && tmpStr[index] != char.MinValue; ++index)
    {
      if (tmpStr[index] != ' ' && !char.IsNumber(tmpStr[index]))
        return true;
    }
    return false;
  }

  public bool CheckNeedTranslate(CString tmpStr) => this.CheckNeedTranslate(tmpStr.ToString());

  public void Recv_BROCAST_NPC_WAR_BEGIN(MessagePacket MP)
  {
    long DataIndex = MP.ReadLong();
    byte x = MP.ReadByte();
    CString cstring = StringManager.Instance.StaticString1024();
    MP.ReadStringPlus(13, cstring);
    CString tmpS = StringManager.Instance.StaticString1024();
    tmpS.IntToFormat((long) x);
    tmpS.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021U));
    CString tmp = StringManager.Instance.StaticString1024();
    tmp.StringToFormat(cstring);
    tmp.StringToFormat(tmpS);
    tmp.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9591U));
    DataManager.Instance.AddSystemMessage(tmp, (byte) 6, DataIndex);
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4904U), (ushort) 15);
  }

  public void Recv_NPC_RALLY_DETAIL_FAILED(MessagePacket MP)
  {
    MP.ReadLong();
    this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9592U), (ushort) byte.MaxValue);
    if (DataManager.Instance.WarhallProtocol != (ushort) 7313)
      return;
    DataManager.Instance.WarhallProtocol = (ushort) 0;
  }

  public void Send_REQUEST_NPC_RALLY_DETAIL_BYID(long NPCUserID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_NPC_RALLY_DETAIL_BYID;
    messagePacket.AddSeqId();
    messagePacket.Add(NPCUserID);
    messagePacket.Send();
    DataManager.Instance.WarhallProtocol = (ushort) messagePacket.Protocol;
    DataManager.Instance.EmptyRallyDetail();
    Array.Clear((Array) this.RallySaved, 0, this.RallySaved.Length);
  }

  public void ClearBox(int index)
  {
    if (this.BoxID[index] > (ushort) 0 && this.BoxTime[index] > 0L)
      this.TrueBoxRequire = 0U;
    this.BoxID[index] = (ushort) 0;
    this.BoxTime[index] = 0L;
    this.BoxRequire[index] = (ushort) 0;
    this.BoxBShowMessage[index] = false;
  }

  public void InitialAlchemy()
  {
    for (int index = 0; index < 3; ++index)
      this.ClearBox(index);
  }

  public void CheckTimeBar(bool bShowMessage = false)
  {
    int index1 = -1;
    for (int index2 = 0; index2 < 3; ++index2)
    {
      if (this.BoxID[index2] > (ushort) 0 && this.BoxTime[index2] > 0L)
      {
        index1 = index2;
        break;
      }
    }
    if (index1 == -1)
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.NpcReward, false, 0L, 0U);
    else
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.NpcReward, true, this.BoxTime[index1] - (long) this.TrueBoxRequire, this.TrueBoxRequire);
  }

  private void CheckNPCRewardHUD()
  {
    if (!DataManager.Instance.queueBarData[33].bActive)
      return;
    int index1 = -1;
    for (int index2 = 0; index2 < 3; ++index2)
    {
      if (this.BoxID[index2] > (ushort) 0 && this.BoxTime[index2] > 0L)
      {
        index1 = index2;
        break;
      }
    }
    if (index1 == -1)
      return;
    DataManager instance = DataManager.Instance;
    if (this.BoxBShowMessage[index1] || this.BoxTime[index1] >= instance.ServerTime)
      return;
    this.BoxBShowMessage[index1] = true;
    instance.SetQueueBarData(EQueueBarIndex.NpcReward, true, this.BoxTime[index1] - (long) this.TrueBoxRequire, this.TrueBoxRequire);
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.StringToFormat(instance.mStringTable.GetStringByID((uint) instance.NPCPrize.GetRecordByKey(this.BoxID[index1]).Element));
    cstring.AppendFormat(instance.mStringTable.GetStringByID(12041U));
    this.AddHUDMessage(cstring.ToString(), (ushort) 30);
    this.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
    this.UpdateUI(EGUIWindow.UIAlchemy, 6, index1);
  }

  public uint GetRequireTime(ushort RequireTime)
  {
    float effectBaseVal = (float) DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_NPCCITY_REWARD_SPEED);
    return (uint) ((double) RequireTime * 60.0 * (1.0 - (double) effectBaseVal / 10000.0));
  }

  public void Recv_NPC_REWARDSAVE(MessagePacket MP)
  {
    int index1 = -1;
    for (int index2 = 0; index2 < 3; ++index2)
    {
      this.BoxID[index2] = MP.ReadUShort();
      this.BoxTime[index2] = MP.ReadLong();
      this.BoxRequire[index2] = MP.ReadUShort();
      this.BoxBShowMessage[index2] = this.BoxID[index2] > (ushort) 0 && this.BoxTime[index2] > 0L && this.BoxTime[index2] <= DataManager.Instance.ServerTime;
      if (this.BoxID[index2] > (ushort) 0 && this.BoxTime[index2] > 0L)
        index1 = index2;
    }
    this.TrueBoxRequire = MP.ReadUInt();
    if (index1 != -1 && this.TrueBoxRequire == 0U)
      this.TrueBoxRequire = this.GetRequireTime(this.BoxRequire[index1]);
    this.CheckTimeBar();
    this.UpdateUI(EGUIWindow.UIAlchemy, 1);
    this.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public void Recv_NPC_START_REWARD(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Alchemy);
    if (MP.ReadByte() != (byte) 0)
      return;
    byte index = (byte) ((uint) MP.ReadByte() - 1U);
    if (index < (byte) 3)
      this.BoxTime[(int) index] = MP.ReadLong();
    this.TrueBoxRequire = MP.ReadUInt();
    this.CheckTimeBar();
    this.UpdateUI(EGUIWindow.UIAlchemy, 2, (int) index);
    this.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
    FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_TRANSMUTATION);
  }

  public void Recv_NPC_GET_REWARD(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Alchemy);
    if (MP.ReadByte() != (byte) 0)
      return;
    byte index = (byte) ((uint) MP.ReadByte() - 1U);
    if (index >= (byte) 3)
      return;
    this.BoxRewardItemID = MP.ReadUShort();
    this.BoxRewardNum = MP.ReadUShort();
    this.BoxRewardItemRank = MP.ReadByte();
    this.BoxRewardCrystal = MP.ReadUInt();
    this.BoxRewardAlliance = MP.ReadUInt();
    if (this.BoxRewardCrystal > 0U)
    {
      DataManager.Instance.RoleAttr.Diamond += this.BoxRewardCrystal;
      GameManager.OnRefresh();
    }
    else if (this.BoxRewardAlliance > 0U)
    {
      DataManager.Instance.RoleAlliance.Money += this.BoxRewardAlliance;
      GameManager.OnRefresh();
    }
    else
    {
      DataManager.Instance.SetCurItemQuantity(this.BoxRewardItemID, (ushort) ((uint) DataManager.Instance.GetCurItemQuantity(this.BoxRewardItemID, this.BoxRewardItemRank) + (uint) this.BoxRewardNum), this.BoxRewardItemRank, 0L);
      GameManager.OnRefresh(NetworkNews.Refresh_Item);
    }
    this.BoxRewardID = this.BoxID[(int) index];
    DataManager.MissionDataManager.CheckChanged(eMissionKind.Mark, (ushort) (159U + (uint) DataManager.Instance.NPCPrize.GetRecordByKey(this.BoxID[(int) index]).ID), (ushort) 1);
    this.ClearBox((int) index);
    this.CheckTimeBar();
    this.UpdateUI(EGUIWindow.UIAlchemy, 3, (int) index);
    this.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public void Recv_NPC_DELETE_REWARD(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Alchemy);
    if (MP.ReadByte() != (byte) 0)
      return;
    byte index = (byte) ((uint) MP.ReadByte() - 1U);
    if (index >= (byte) 3)
      return;
    this.ClearBox((int) index);
    DataManager.Instance.Resource[4].Stock = MP.ReadUInt();
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
    this.CheckTimeBar();
    this.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12047U), (ushort) byte.MaxValue);
    this.UpdateUI(EGUIWindow.UIAlchemy, 4, (int) index);
    this.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public void Recv_NPC_UPDATEREWARD(MessagePacket MP)
  {
    byte index = (byte) ((uint) MP.ReadByte() - 1U);
    if (index >= (byte) 3)
      return;
    this.BoxID[(int) index] = MP.ReadUShort();
    this.BoxTime[(int) index] = MP.ReadLong();
    this.BoxRequire[(int) index] = MP.ReadUShort();
    this.BoxBShowMessage[(int) index] = this.BoxID[(int) index] > (ushort) 0 && this.BoxTime[(int) index] > 0L && this.BoxTime[(int) index] <= DataManager.Instance.ServerTime;
    this.CheckTimeBar();
    this.UpdateUI(EGUIWindow.UIAlchemy, 5, (int) index);
    this.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
    NewbieManager.CheckMetallurgy();
  }

  public void Send_NPC_START_REWARD(byte Index)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_NPC_START_REWARD;
    messagePacket.AddSeqId();
    messagePacket.Add(Index);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Alchemy);
  }

  public void Send_NPC_GET_REWARD(byte Index)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_NPC_GET_REWARD;
    messagePacket.AddSeqId();
    messagePacket.Add(Index);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Alchemy);
  }

  public void Send_NPC_DELETE_REWARD(byte Index)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_NPC_DELETE_REWARD;
    messagePacket.AddSeqId();
    messagePacket.Add(Index);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.Alchemy);
  }

  public void LoadEmojiSelectSave()
  {
    if (this.bLoadEmojiSaveKey)
      return;
    this.bLoadEmojiSaveKey = true;
    this.SaveEmojiKey.Clear();
    ushort result = 0;
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < 8; ++index)
    {
      stringBuilder.AppendFormat("{0}_{1}", (object) this.SaveEmojiName[index], (object) DataManager.Instance.RoleAttr.UserId);
      this.SaveEmojiName[index] = stringBuilder.ToString();
      ushort.TryParse(PlayerPrefs.GetString(this.SaveEmojiName[index]), out result);
      if (result > (ushort) 0)
        this.SaveEmojiKey.Add(result);
    }
    if (this.SaveEmojiKey.Count != 0)
      return;
    this.EmojiNowPackageIndex = (ushort) 0;
  }

  public void SaveEmojiSelectSave()
  {
    for (int index = 0; index < 8; ++index)
    {
      if (index >= this.SaveEmojiKey.Count)
        PlayerPrefs.SetString(this.SaveEmojiName[index], "0");
      else
        PlayerPrefs.SetString(this.SaveEmojiName[index], this.SaveEmojiKey[index].ToString());
    }
  }

  public byte GetMapEmojiCount(ushort PackageIndex)
  {
    if (PackageIndex == ushort.MaxValue)
      return (byte) this.SaveEmojiKey.Count;
    byte num = 0;
    if (this.MapEmojiCount == null)
    {
      this.MapEmojiCount = new Dictionary<ushort, byte>();
      int tableCount = DataManager.MapDataController.EmojiDataTable.TableCount;
      for (int Index = 0; Index < tableCount; ++Index)
      {
        EmojiData recordByIndex = DataManager.MapDataController.EmojiDataTable.GetRecordByIndex(Index);
        if (this.MapEmojiCount.TryGetValue(recordByIndex.GroupIconID, out num))
          this.MapEmojiCount[recordByIndex.GroupIconID] = (byte) ((uint) num + 1U);
        else
          this.MapEmojiCount.Add(recordByIndex.GroupIconID, (byte) 1);
      }
    }
    return this.MapEmojiCount.TryGetValue(PackageIndex, out num) ? num : (byte) 0;
  }

  public void SortEmojiData()
  {
    if (this.EmojiIndex.Count <= 0)
    {
      this.EmojiIndex.Clear();
      int tableCount = DataManager.MapDataController.EmoteTable.TableCount;
      for (int Index = 0; Index < tableCount; ++Index)
        this.EmojiIndex.Add(DataManager.MapDataController.EmoteTable.GetRecordByIndex(Index).EmojiIndex);
    }
    this.EmojiIndex.Sort((IComparer<ushort>) this.EmojiDataComparer);
  }

  public bool HasEmotionPck(ushort eid)
  {
    if (eid == (ushort) 0 || eid > (ushort) 512)
      return false;
    int num1 = (int) eid - 1;
    long num2 = 1L << num1 % 64;
    return (this.EmojiFlag[num1 / 64] & num2) != 0L;
  }

  public bool InitLordEquipImg(
    Transform BtnT,
    ushort LEID = 0,
    byte color = 0,
    eLordEquipDisplayKind DisplayKind = eLordEquipDisplayKind.OnlyItem,
    bool setScale = false,
    bool setSound = true,
    ushort gem1 = 0,
    ushort gem2 = 0,
    ushort gem3 = 0,
    ushort gem4 = 0,
    ushort Quantity = 0,
    bool isEquip = false)
  {
    UILEBtn component = BtnT.GetComponent<UILEBtn>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
      return false;
    component.BackPanel = BtnT.GetComponent<Image>();
    if (setScale)
    {
      component.transition = (Selectable.Transition) 0;
      uButtonScale uButtonScale = BtnT.gameObject.AddComponent<uButtonScale>();
      uButtonScale.m_Handler = (IUIButtonScaleHandler2) component;
      uButtonScale.enabled = true;
      component.SetEffectType(e_EffectType.e_Scale);
      GameConstants.SetPivot(BtnT.GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
    }
    component.SoundIndex = !setSound ? byte.MaxValue : (byte) 0;
    GameObject gameObject1 = new GameObject("LEimg");
    gameObject1.layer = 5;
    gameObject1.AddComponent<RectTransform>();
    gameObject1.AddComponent<IgnoreRaycast>();
    component.LEImage = gameObject1.AddComponent<Image>();
    gameObject1.transform.SetParent(BtnT, false);
    GameObject gameObject2 = new GameObject("Equip");
    gameObject2.layer = 5;
    RectTransform rectTransform1 = gameObject2.AddComponent<RectTransform>();
    rectTransform1.anchorMin = new Vector2(0.68f, 0.22f);
    rectTransform1.anchorMax = new Vector2(1.05f, 0.59f);
    rectTransform1.offsetMin = Vector2.zero;
    rectTransform1.offsetMax = Vector2.zero;
    gameObject2.AddComponent<IgnoreRaycast>();
    component.OnEquip = gameObject2.AddComponent<Image>();
    gameObject2.transform.SetParent(BtnT, false);
    gameObject2.SetActive(false);
    GameObject gameObject3 = new GameObject("Level");
    gameObject3.layer = 5;
    RectTransform rectTransform2 = gameObject3.AddComponent<RectTransform>();
    rectTransform2.anchorMin = new Vector2(0.05f, 0.8f);
    rectTransform2.anchorMax = new Vector2(0.7f, 1f);
    rectTransform2.offsetMin = Vector2.zero;
    rectTransform2.offsetMax = Vector2.zero;
    gameObject3.AddComponent<IgnoreRaycast>();
    component.Level = gameObject3.AddComponent<UIText>();
    component.Level.supportRichText = true;
    component.Level.resizeTextForBestFit = true;
    component.Level.font = this.m_TTFFont;
    ((Shadow) gameObject3.AddComponent<Outline>()).effectColor = (Color) new Color32((byte) 36, (byte) 16, (byte) 0, byte.MaxValue);
    gameObject3.AddComponent<Shadow>().effectColor = new Color(0.0f, 0.0f, 0.0f, 0.5f);
    gameObject3.transform.SetParent(BtnT, false);
    GameObject gameObject4 = new GameObject(nameof (Quantity));
    gameObject4.layer = 5;
    RectTransform rectTransform3 = gameObject4.AddComponent<RectTransform>();
    rectTransform3.anchorMin = new Vector2(0.4f, 0.23f);
    rectTransform3.anchorMax = new Vector2(0.86f, 0.43f);
    rectTransform3.offsetMin = Vector2.zero;
    rectTransform3.offsetMax = Vector2.zero;
    gameObject4.AddComponent<IgnoreRaycast>();
    component.Quantity = gameObject4.AddComponent<UIText>();
    component.Quantity.supportRichText = true;
    component.Quantity.resizeTextForBestFit = true;
    component.Quantity.font = this.m_TTFFont;
    component.Quantity.alignment = TextAnchor.MiddleRight;
    ((Shadow) gameObject4.AddComponent<Outline>()).effectColor = (Color) new Color32((byte) 36, (byte) 16, (byte) 0, byte.MaxValue);
    gameObject4.AddComponent<Shadow>().effectColor = new Color(0.0f, 0.0f, 0.0f, 0.5f);
    gameObject4.transform.SetParent(BtnT, false);
    GameObject gameObject5 = new GameObject("Name");
    gameObject5.layer = 5;
    RectTransform rectTransform4 = gameObject5.AddComponent<RectTransform>();
    rectTransform4.anchorMin = new Vector2(0.0f, 0.0f);
    rectTransform4.anchorMax = new Vector2(1f, 0.25f);
    rectTransform4.offsetMin = Vector2.zero;
    rectTransform4.offsetMax = Vector2.zero;
    gameObject5.AddComponent<IgnoreRaycast>();
    component.Name = gameObject5.AddComponent<UIText>();
    component.Name.supportRichText = true;
    component.Name.resizeTextForBestFit = true;
    component.Name.font = this.m_TTFFont;
    component.Name.alignment = TextAnchor.MiddleCenter;
    if (GameConstants.IsBigStyle())
    {
      component.Name.resizeTextMinSize = 10;
      component.Name.resizeTextMaxSize = 18;
    }
    else
    {
      component.Name.resizeTextMinSize = 8;
      component.Name.resizeTextMaxSize = 12;
    }
    ((Shadow) gameObject5.AddComponent<Outline>()).effectColor = (Color) new Color32((byte) 36, (byte) 16, (byte) 0, byte.MaxValue);
    gameObject5.AddComponent<Shadow>().effectColor = new Color(0.0f, 0.0f, 0.0f, 0.5f);
    gameObject5.transform.SetParent(BtnT, false);
    this.ChangeLordEquipImg(BtnT, LEID, color, DisplayKind, gem1, gem2, gem3, gem4, Quantity, isEquip);
    return true;
  }

  public void ChangeLordEquipImg(
    Transform BtnT,
    LordEquipMaterial data,
    eLordEquipDisplayKind DisplayKind = eLordEquipDisplayKind.Gems_Name_Quantity)
  {
    if (data.ItemID == (ushort) 0)
      this.ChangeLordEquipImg(BtnT, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    else
      this.ChangeLordEquipImg(BtnT, data.ItemID, data.Color, DisplayKind, (ushort) 0, (ushort) 0, (ushort) 0, (ushort) 0, data.Quantity);
  }

  public void ChangeLordEquipImg(
    Transform BtnT,
    ItemLordEquip data,
    eLordEquipDisplayKind DisplayKind = eLordEquipDisplayKind.Item_Gems,
    bool isEquip = false)
  {
    if (data.ItemID == (ushort) 0)
      this.ChangeLordEquipImg(BtnT, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    else
      this.ChangeLordEquipImg(BtnT, data.ItemID, data.Color, DisplayKind, data.Gem[0], data.Gem[1], data.Gem[2], data.Gem[3], (ushort) 0, isEquip);
  }

  public void ChangeLordEquipImg(
    Transform BtnT,
    LordEquipSerialData data,
    eLordEquipDisplayKind DisplayKind = eLordEquipDisplayKind.Item_Gems,
    bool isEquip = false)
  {
    if (data.ItemID == (ushort) 0)
      this.ChangeLordEquipImg(BtnT, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    else
      this.ChangeLordEquipImg(BtnT, data.ItemID, data.Color, DisplayKind, data.Gem[0], data.Gem[1], data.Gem[2], data.Gem[3], (ushort) 0, isEquip);
  }

  public void ChangeLordEquipImg(
    Transform BtnT,
    ushort LEID,
    byte color,
    eLordEquipDisplayKind DisplayKind = eLordEquipDisplayKind.OnlyItem,
    ushort gem1 = 0,
    ushort gem2 = 0,
    ushort gem3 = 0,
    ushort gem4 = 0,
    ushort Quantity = 0,
    bool isEquip = false)
  {
    UILEBtn component1 = BtnT.GetComponent<UILEBtn>();
    UIButtonHint component2 = ((Component) component1).GetComponent<UIButtonHint>();
    Equip recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(LEID);
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
    {
      component2.m_DownUpHandler = (IUIButtonDownUpHandler) GUIManager.instance.m_LordInfo;
      component2.Parm1 = LEID;
      component2.Parm2 = color;
    }
    Vector2 vector2_1 = Vector2.zero;
    Vector2 vector2_2 = Vector2.one;
    if (DisplayKind != eLordEquipDisplayKind.OnlyItem)
    {
      vector2_1 = new Vector2(0.075f, 0.15f);
      vector2_2 = new Vector2(0.925f, 1f);
    }
    ((Graphic) component1.LEImage).rectTransform.anchorMin = vector2_1;
    ((Graphic) component1.LEImage).rectTransform.anchorMax = vector2_2;
    ((Graphic) component1.LEImage).rectTransform.offsetMin = Vector2.zero;
    ((Graphic) component1.LEImage).rectTransform.offsetMax = Vector2.zero;
    if (GameConstants.IsBetween((int) color, 0, 5))
      component1.BackPanel.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite((ushort) (65500U + (uint) color));
    ((MaskableGraphic) component1.BackPanel).material = this.m_LeadItemIconSpriteAsset.GetMaterial();
    switch (recordByKey1.EquipKind)
    {
      case 20:
      case 27:
        component1.LEImage.sprite = this.m_LeadMatIconSpriteAsset.LoadSprite(recordByKey1.EquipPicture);
        ((MaskableGraphic) component1.LEImage).material = this.m_LeadMatIconSpriteAsset.GetMaterial();
        break;
      default:
        component1.LEImage.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite(recordByKey1.EquipPicture);
        ((MaskableGraphic) component1.LEImage).material = this.m_LeadItemIconSpriteAsset.GetMaterial();
        break;
    }
    ((Component) component1.LEImage).gameObject.SetActive((UnityEngine.Object) component1.LEImage.sprite != (UnityEngine.Object) null);
    component1.OnEquip.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite((ushort) 65524);
    ((MaskableGraphic) component1.OnEquip).material = this.m_LeadItemIconSpriteAsset.GetMaterial();
    bool flag1 = DisplayKind == eLordEquipDisplayKind.Gems_Name_Quantity || DisplayKind == eLordEquipDisplayKind.Gems_Name;
    ((Component) component1.Name).gameObject.SetActive(flag1);
    if (flag1)
      component1.Name.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey1.EquipName);
    bool flag2 = DisplayKind == eLordEquipDisplayKind.Gems_Name_Quantity;
    ((Component) component1.Quantity).gameObject.SetActive(flag2);
    if (flag2)
      component1.Quantity.text = string.Format("{0:N0}", (object) Quantity);
    int needLv = (int) recordByKey1.NeedLv;
    bool flag3 = needLv != 0 && LEID != (ushort) 0 && DisplayKind == eLordEquipDisplayKind.Item_Gems;
    if (flag3)
    {
      component1.Level.text = string.Format(DataManager.Instance.mStringTable.GetStringByID(52U), (object) needLv);
      if (needLv > (int) DataManager.Instance.RoleAttr.Level)
        ((Graphic) component1.Level).color = Color.red;
      else
        ((Graphic) component1.Level).color = Color.white;
    }
    ((Component) component1.Level).gameObject.SetActive(flag3);
    ((Component) component1.OnEquip).gameObject.SetActive(isEquip);
    Equip recordByKey2;
    if (DisplayKind == eLordEquipDisplayKind.Item_Gems)
    {
      if ((UnityEngine.Object) component1.Gem1 == (UnityEngine.Object) null)
      {
        GameObject gameObject1 = new GameObject("Gem1Panel");
        gameObject1.layer = 5;
        RectTransform rectTransform1 = gameObject1.AddComponent<RectTransform>();
        rectTransform1.anchorMin = Vector2.zero;
        rectTransform1.anchorMax = new Vector2(0.25f, 0.25f);
        rectTransform1.offsetMin = Vector2.zero;
        rectTransform1.offsetMax = Vector2.zero;
        gameObject1.AddComponent<IgnoreRaycast>();
        component1.Gem1Panel = gameObject1.AddComponent<Image>();
        gameObject1.transform.SetParent(BtnT, false);
        GameObject gameObject2 = new GameObject("Gem2Panel");
        gameObject2.layer = 5;
        RectTransform rectTransform2 = gameObject2.AddComponent<RectTransform>();
        rectTransform2.anchorMin = new Vector2(0.25f, 0.0f);
        rectTransform2.anchorMax = new Vector2(0.5f, 0.25f);
        rectTransform2.offsetMin = Vector2.zero;
        rectTransform2.offsetMax = Vector2.zero;
        gameObject2.AddComponent<IgnoreRaycast>();
        component1.Gem2Panel = gameObject2.AddComponent<Image>();
        gameObject2.transform.SetParent(BtnT, false);
        GameObject gameObject3 = new GameObject("Gem3Panel");
        gameObject3.layer = 5;
        RectTransform rectTransform3 = gameObject3.AddComponent<RectTransform>();
        rectTransform3.anchorMin = new Vector2(0.5f, 0.0f);
        rectTransform3.anchorMax = new Vector2(0.75f, 0.25f);
        rectTransform3.offsetMin = Vector2.zero;
        rectTransform3.offsetMax = Vector2.zero;
        gameObject3.AddComponent<IgnoreRaycast>();
        component1.Gem3Panel = gameObject3.AddComponent<Image>();
        gameObject3.transform.SetParent(BtnT, false);
        GameObject gameObject4 = new GameObject("Gem4Panel");
        gameObject4.layer = 5;
        RectTransform rectTransform4 = gameObject4.AddComponent<RectTransform>();
        rectTransform4.anchorMin = new Vector2(0.75f, 0.0f);
        rectTransform4.anchorMax = new Vector2(1f, 0.25f);
        rectTransform4.offsetMin = Vector2.zero;
        rectTransform4.offsetMax = Vector2.zero;
        gameObject4.AddComponent<IgnoreRaycast>();
        component1.Gem4Panel = gameObject4.AddComponent<Image>();
        gameObject4.transform.SetParent(BtnT, false);
        GameObject gameObject5 = new GameObject("Gem1");
        gameObject5.layer = 5;
        RectTransform rectTransform5 = gameObject5.AddComponent<RectTransform>();
        rectTransform5.anchorMin = Vector2.zero;
        rectTransform5.anchorMax = new Vector2(0.25f, 0.25f);
        rectTransform5.offsetMin = Vector2.zero;
        rectTransform5.offsetMax = Vector2.zero;
        gameObject5.AddComponent<IgnoreRaycast>();
        component1.Gem1 = gameObject5.AddComponent<Image>();
        gameObject5.transform.SetParent(BtnT, false);
        GameObject gameObject6 = new GameObject("Gem2");
        gameObject6.layer = 5;
        RectTransform rectTransform6 = gameObject6.AddComponent<RectTransform>();
        rectTransform6.anchorMin = new Vector2(0.25f, 0.0f);
        rectTransform6.anchorMax = new Vector2(0.5f, 0.25f);
        rectTransform6.offsetMin = Vector2.zero;
        rectTransform6.offsetMax = Vector2.zero;
        gameObject6.AddComponent<IgnoreRaycast>();
        component1.Gem2 = gameObject6.AddComponent<Image>();
        gameObject6.transform.SetParent(BtnT, false);
        GameObject gameObject7 = new GameObject("Gem3");
        gameObject7.layer = 5;
        RectTransform rectTransform7 = gameObject7.AddComponent<RectTransform>();
        rectTransform7.anchorMin = new Vector2(0.5f, 0.0f);
        rectTransform7.anchorMax = new Vector2(0.75f, 0.25f);
        rectTransform7.offsetMin = Vector2.zero;
        rectTransform7.offsetMax = Vector2.zero;
        gameObject7.AddComponent<IgnoreRaycast>();
        component1.Gem3 = gameObject7.AddComponent<Image>();
        gameObject7.transform.SetParent(BtnT, false);
        GameObject gameObject8 = new GameObject("Gem4");
        gameObject8.layer = 5;
        RectTransform rectTransform8 = gameObject8.AddComponent<RectTransform>();
        rectTransform8.anchorMin = new Vector2(0.75f, 0.0f);
        rectTransform8.anchorMax = new Vector2(1f, 0.25f);
        rectTransform8.offsetMin = Vector2.zero;
        rectTransform8.offsetMax = Vector2.zero;
        gameObject8.AddComponent<IgnoreRaycast>();
        component1.Gem4 = gameObject8.AddComponent<Image>();
        gameObject8.transform.SetParent(BtnT, false);
      }
      component1.Gem1Panel.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite((ushort) 65510);
      ((MaskableGraphic) component1.Gem1Panel).material = this.m_LeadItemIconSpriteAsset.GetMaterial();
      component1.Gem2Panel.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite((ushort) 65510);
      ((MaskableGraphic) component1.Gem2Panel).material = this.m_LeadItemIconSpriteAsset.GetMaterial();
      component1.Gem3Panel.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite((ushort) 65510);
      ((MaskableGraphic) component1.Gem3Panel).material = this.m_LeadItemIconSpriteAsset.GetMaterial();
      component1.Gem4Panel.sprite = this.m_LeadItemIconSpriteAsset.LoadSprite((ushort) 65510);
      ((MaskableGraphic) component1.Gem4Panel).material = this.m_LeadItemIconSpriteAsset.GetMaterial();
      Equip recordByKey3 = DataManager.Instance.EquipTable.GetRecordByKey(gem1);
      component1.Gem1.sprite = this.m_LeadMatIconSpriteAsset.LoadSprite(recordByKey3.EquipPicture);
      ((MaskableGraphic) component1.Gem1).material = this.m_LeadMatIconSpriteAsset.GetMaterial();
      ((Component) component1.Gem1).gameObject.SetActive((UnityEngine.Object) component1.Gem1.sprite != (UnityEngine.Object) null);
      recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(gem2);
      component1.Gem2.sprite = this.m_LeadMatIconSpriteAsset.LoadSprite(recordByKey2.EquipPicture);
      ((MaskableGraphic) component1.Gem2).material = this.m_LeadMatIconSpriteAsset.GetMaterial();
      ((Component) component1.Gem2).gameObject.SetActive((UnityEngine.Object) component1.Gem2.sprite != (UnityEngine.Object) null);
      recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(gem3);
      component1.Gem3.sprite = this.m_LeadMatIconSpriteAsset.LoadSprite(recordByKey2.EquipPicture);
      ((MaskableGraphic) component1.Gem3).material = this.m_LeadMatIconSpriteAsset.GetMaterial();
      ((Component) component1.Gem3).gameObject.SetActive((UnityEngine.Object) component1.Gem3.sprite != (UnityEngine.Object) null);
      recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(gem4);
      component1.Gem4.sprite = this.m_LeadMatIconSpriteAsset.LoadSprite(recordByKey2.EquipPicture);
      ((MaskableGraphic) component1.Gem4).material = this.m_LeadMatIconSpriteAsset.GetMaterial();
      ((Component) component1.Gem4).gameObject.SetActive((UnityEngine.Object) component1.Gem4.sprite != (UnityEngine.Object) null);
      ((Component) component1.Gem1Panel).gameObject.SetActive(true);
      ((Component) component1.Gem2Panel).gameObject.SetActive(true);
      ((Component) component1.Gem3Panel).gameObject.SetActive(true);
      ((Component) component1.Gem4Panel).gameObject.SetActive(true);
    }
    else if ((UnityEngine.Object) component1.Gem1 != (UnityEngine.Object) null)
    {
      ((Component) component1.Gem1).gameObject.SetActive(false);
      ((Component) component1.Gem2).gameObject.SetActive(false);
      ((Component) component1.Gem3).gameObject.SetActive(false);
      ((Component) component1.Gem4).gameObject.SetActive(false);
      ((Component) component1.Gem1Panel).gameObject.SetActive(false);
      ((Component) component1.Gem2Panel).gameObject.SetActive(false);
      ((Component) component1.Gem3Panel).gameObject.SetActive(false);
      ((Component) component1.Gem4Panel).gameObject.SetActive(false);
    }
    recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(LEID);
    component1.SetTimedItem((long) recordByKey2.TimedTime, DisplayKind);
  }

  public void UpdateLordEquip(bool onSec)
  {
    double num = (double) Time.time % 1.6;
    this.m_LEBtn_SharedAlpha = num <= 0.8 ? (float) (num + 0.2) : (float) (1.8 - num);
    for (int index = this.m_LEBTN_updateList.Count - 1; index >= 0; --index)
    {
      if ((UnityEngine.Object) this.m_LEBTN_updateList[index] == (UnityEngine.Object) null)
        this.m_LEBTN_updateList.RemoveAt(index);
      else
        this.m_LEBTN_updateList[index].BtnUpdateTime(onSec);
    }
    if (!onSec || this.m_LEBTN_updateList.Count <= 0)
      return;
    LordEquipData.CheckEquipExpired();
  }

  public void AddTimeBarToList(UITimeBar timebar) => this.m_TimeBarList.Add(timebar);

  public void RemoverTimeBaarToList(UITimeBar timebar)
  {
    timebar.m_ListID = 0;
    this.m_TimeBarList.Remove(timebar);
  }

  public void SetTimerBar(
    UITimeBar timebar,
    long begin,
    long target,
    long notifyTime,
    eTimeBarType type,
    string title1,
    string title2)
  {
    timebar.m_Titles[0] = title1;
    timebar.m_Titles[1] = title2;
    timebar.SetTitleText();
    timebar.SetValue(begin, target);
    timebar.m_NotifyTime = notifyTime;
    timebar.m_Type = type;
    if (timebar.m_ListID == 0)
    {
      this.AddTimeBarToList(timebar);
      timebar.m_ListID = 1;
    }
    timebar.UpdateTimeText(DataManager.Instance.ServerTime);
    if ((UnityEngine.Object) timebar.m_TitleText != (UnityEngine.Object) null)
      timebar.m_TitleText.UpdateArabicPos();
    if (!((UnityEngine.Object) timebar.m_TimeText != (UnityEngine.Object) null))
      return;
    timebar.m_TimeText.UpdateArabicPos();
  }

  public void SetTimeBarIconStyle(UITimeBar timebar)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu == (UnityEngine.Object) null)
      return;
    float num1 = 0.0f;
    Material material = menu.LoadMaterial();
    Sprite sprite1 = menu.LoadSprite("UI_main_res_box");
    Sprite sprite2 = menu.LoadSprite("UI_main_res_box_a");
    float num2 = 268f;
    float y1 = 33f;
    float x1 = num2;
    float y2 = 31f;
    float x2 = num2 - 16f;
    float y3 = -1f;
    float x3 = 1f;
    timebar.TimeBarSizeY = 31f;
    timebar.TimeBarSizeX = x2;
    Image.Type type = (Image.Type) 3;
    Image.FillMethod fillMethod = (Image.FillMethod) 0;
    num1 = 10f;
    float num3 = num2 - 21f;
    timebar.GetComponent<RectTransform>().sizeDelta = new Vector2(x1, y1);
    GameObject gameObject1 = new GameObject("Background");
    Image image1 = gameObject1.AddComponent<Image>();
    ((MaskableGraphic) image1).material = material;
    image1.sprite = sprite1;
    image1.type = (Image.Type) 1;
    timebar.m_BackgroundImage = image1;
    RectTransform component1 = gameObject1.GetComponent<RectTransform>();
    component1.sizeDelta = new Vector2(x1, y1);
    component1.anchorMax = new Vector2(0.0f, 1f);
    component1.anchorMin = new Vector2(0.0f, 1f);
    component1.pivot = new Vector2(0.0f, 1f);
    gameObject1.transform.SetParent(timebar.transform, false);
    GameObject gameObject2 = new GameObject("Slider");
    Image image2 = gameObject2.AddComponent<Image>();
    ((MaskableGraphic) image2).material = material;
    image2.sprite = sprite2;
    image2.type = type;
    image2.fillMethod = fillMethod;
    image2.fillAmount = 0.0f;
    timebar.m_SliderImage = image2;
    RectTransform component2 = gameObject2.GetComponent<RectTransform>();
    component2.anchoredPosition = new Vector2(x3, y3);
    component2.sizeDelta = new Vector2(x2, y2);
    component2.anchorMax = new Vector2(0.0f, 1f);
    component2.anchorMin = new Vector2(0.0f, 1f);
    component2.pivot = new Vector2(0.0f, 1f);
    gameObject2.transform.SetParent(timebar.transform, false);
    timebar.m_SliderRectTransform = component2;
    Image image3 = new GameObject("Background").AddComponent<Image>();
    ((MaskableGraphic) image3).material = material;
    image3.sprite = menu.LoadSprite("UI_main_res_01");
    image3.SetNativeSize();
    ((Behaviour) image3).enabled = false;
    RectTransform component3 = ((Component) image3).GetComponent<RectTransform>();
    component3.anchorMax = new Vector2(0.0f, 1f);
    component3.anchorMin = new Vector2(0.0f, 1f);
    component3.pivot = new Vector2(0.0f, 1f);
    component3.anchoredPosition = new Vector2(-18f, 2f);
    ((Transform) component3).SetParent(timebar.transform, false);
    RectTransform rectTransform = new GameObject("Icon").AddComponent<RectTransform>();
    rectTransform.anchorMax = new Vector2(0.0f, 1f);
    rectTransform.anchorMin = new Vector2(0.0f, 1f);
    rectTransform.anchoredPosition = new Vector2(20f, -16f);
    ((Transform) rectTransform).SetParent(timebar.transform, false);
    GameObject gameObject3 = new GameObject("TitleText");
    UIText uiText1 = gameObject3.AddComponent<UIText>();
    uiText1.font = this.GetTTFFont();
    uiText1.alignment = TextAnchor.MiddleLeft;
    uiText1.fontSize = 18;
    uiText1.resizeTextForBestFit = false;
    uiText1.resizeTextMinSize = 10;
    uiText1.resizeTextMaxSize = 18;
    RectTransform component4 = gameObject3.GetComponent<RectTransform>();
    component4.anchorMax = new Vector2(0.0f, 1f);
    component4.anchorMin = new Vector2(0.0f, 1f);
    component4.pivot = new Vector2(0.0f, 1f);
    component4.sizeDelta = new Vector2(num2 - 40f, y1);
    component4.anchoredPosition = new Vector2(40f, 0.0f);
    gameObject3.transform.SetParent(timebar.transform, false);
    timebar.m_TitleText = uiText1;
    this.TimeBarTitleWidth = x1 - 50f;
    GameObject gameObject4 = new GameObject("TimeText");
    UIText uiText2 = gameObject4.AddComponent<UIText>();
    uiText2.font = this.GetTTFFont();
    uiText2.alignment = TextAnchor.MiddleRight;
    uiText2.fontSize = 18;
    uiText2.resizeTextForBestFit = false;
    uiText2.resizeTextMinSize = 10;
    uiText2.resizeTextMaxSize = 18;
    ((Graphic) uiText2).color = new Color(0.964705f, 0.937254f, 0.603921f);
    RectTransform component5 = gameObject4.GetComponent<RectTransform>();
    component5.sizeDelta = new Vector2(num2 - 21.5f, y1);
    component5.anchorMax = new Vector2(1f, 1f);
    component5.anchorMin = new Vector2(1f, 1f);
    component5.pivot = new Vector2(1f, 1f);
    component5.anchoredPosition = new Vector2(-24f, 0.0f);
    gameObject4.transform.SetParent(timebar.transform, false);
    timebar.m_TimeText = uiText2;
    GameObject gameObject5 = new GameObject("FunBtn");
    Image image4 = gameObject5.AddComponent<Image>();
    UIButton uiButton = gameObject5.AddComponent<UIButton>();
    RectTransform component6 = gameObject5.GetComponent<RectTransform>();
    component6.anchorMax = new Vector2(0.0f, 0.5f);
    component6.anchorMin = new Vector2(0.0f, 0.5f);
    component6.pivot = new Vector2(0.5f, 0.5f);
    component6.anchoredPosition = new Vector2(num3 + component6.sizeDelta.x / 2f, 0.0f);
    timebar.m_FuntionBtn = uiButton;
    ((MaskableGraphic) timebar.m_FuntionBtn.image).material = material;
    timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_queue_butt_up");
    timebar.m_FuntionBtn.SetButtonEffectType(e_EffectType.e_Scale);
    timebar.m_FuntionBtn.transition = (Selectable.Transition) 0;
    image4.SetNativeSize();
    gameObject5.transform.SetParent(timebar.transform, false);
    uiButton.m_BtnID4 = (int) num3;
    GameObject gameObject6 = new GameObject("BtnText");
    UIText uiText3 = gameObject6.AddComponent<UIText>();
    uiText3.font = this.GetTTFFont();
    uiText3.alignment = TextAnchor.MiddleCenter;
    uiText3.fontSize = 20;
    uiText3.resizeTextForBestFit = true;
    uiText3.resizeTextMinSize = 6;
    uiText3.resizeTextMaxSize = 20;
    RectTransform component7 = gameObject6.GetComponent<RectTransform>();
    component7.anchorMax = new Vector2(1f, 1f);
    component7.anchorMin = new Vector2(0.0f, 0.0f);
    component7.pivot = new Vector2(0.5f, 0.5f);
    component7.offsetMax = new Vector2(-10f, -15f);
    component7.offsetMin = new Vector2(10f, 15f);
    component7.anchoredPosition = new Vector2(0.0f, 0.0f);
    gameObject6.AddComponent<Outline>();
    gameObject6.transform.SetParent(gameObject5.transform, false);
    uiButton.m_BtnID1 = 2;
  }

  public void SetTimeBarNormalStyle(UITimeBar timebar)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu == (UnityEngine.Object) null)
      return;
    Image.Type type = (Image.Type) 1;
    Image.FillMethod fillMethod = (Image.FillMethod) 0;
    Material material = menu.LoadMaterial();
    Sprite sprite1 = menu.LoadSprite("UI_main_art_box");
    Sprite sprite2 = menu.LoadSprite("UI_main_art_blood_up");
    float y1 = 29f;
    float x1 = 268f;
    float y2 = 17f;
    float x2 = 244f;
    float y3 = -5f;
    float x3 = 9f;
    timebar.TimeBarSizeY = 19f;
    timebar.TimeBarSizeX = 250f;
    timebar.GetComponent<RectTransform>().sizeDelta = new Vector2(x1, y1);
    GameObject gameObject1 = new GameObject("Background");
    Image image1 = gameObject1.AddComponent<Image>();
    ((MaskableGraphic) image1).material = material;
    image1.sprite = sprite1;
    image1.type = (Image.Type) 1;
    timebar.m_BackgroundImage = image1;
    RectTransform component1 = gameObject1.GetComponent<RectTransform>();
    component1.sizeDelta = new Vector2(x1, y1);
    component1.anchorMax = new Vector2(0.0f, 1f);
    component1.anchorMin = new Vector2(0.0f, 1f);
    component1.pivot = new Vector2(0.0f, 1f);
    gameObject1.transform.SetParent(timebar.transform, false);
    GameObject gameObject2 = new GameObject("Slider");
    Image image2 = gameObject2.AddComponent<Image>();
    ((MaskableGraphic) image2).material = material;
    image2.sprite = sprite2;
    image2.type = type;
    image2.fillMethod = fillMethod;
    image2.fillAmount = 0.0f;
    timebar.m_SliderImage = image2;
    RectTransform component2 = gameObject2.GetComponent<RectTransform>();
    component2.anchoredPosition = new Vector2(x3, y3);
    component2.sizeDelta = new Vector2(x2, y2);
    component2.anchorMax = new Vector2(0.0f, 1f);
    component2.anchorMin = new Vector2(0.0f, 1f);
    component2.pivot = new Vector2(0.0f, 1f);
    gameObject2.transform.SetParent(timebar.transform, false);
    timebar.m_SliderRectTransform = component2;
    GameObject gameObject3 = new GameObject("TitleText");
    UIText uiText1 = gameObject3.AddComponent<UIText>();
    uiText1.font = this.GetTTFFont();
    uiText1.fontSize = 16;
    uiText1.resizeTextForBestFit = false;
    uiText1.resizeTextMaxSize = 16;
    uiText1.resizeTextMinSize = 10;
    uiText1.alignment = TextAnchor.MiddleLeft;
    RectTransform component3 = gameObject3.GetComponent<RectTransform>();
    component3.anchorMax = new Vector2(0.0f, 1f);
    component3.anchorMin = new Vector2(0.0f, 1f);
    component3.pivot = new Vector2(0.0f, 1f);
    component3.sizeDelta = new Vector2(157f, 29f);
    component3.anchoredPosition = new Vector2(14f, 0.0f);
    gameObject3.transform.SetParent(timebar.transform, false);
    timebar.m_TitleText = uiText1;
    GameObject gameObject4 = new GameObject("TimeText");
    UIText uiText2 = gameObject4.AddComponent<UIText>();
    uiText2.font = this.GetTTFFont();
    uiText2.fontSize = 16;
    uiText2.resizeTextForBestFit = false;
    uiText2.resizeTextMaxSize = 16;
    uiText2.resizeTextMinSize = 10;
    uiText2.alignment = TextAnchor.MiddleRight;
    RectTransform component4 = gameObject4.GetComponent<RectTransform>();
    component4.sizeDelta = new Vector2(83f, 29f);
    component4.anchorMax = new Vector2(1f, 1f);
    component4.anchorMin = new Vector2(1f, 1f);
    component4.pivot = new Vector2(1f, 1f);
    component4.anchoredPosition = new Vector2(-14f, 0.0f);
    gameObject4.transform.SetParent(timebar.transform, false);
    timebar.m_TimeText = uiText2;
  }

  public void SetTimeBarCancelStyle(UITimeBar timebar)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu == (UnityEngine.Object) null)
      return;
    Image.Type type = (Image.Type) 1;
    Image.FillMethod fillMethod = (Image.FillMethod) 0;
    Material material = menu.LoadMaterial();
    Sprite sprite1 = menu.LoadSprite("UI_main_art_box_up");
    Sprite sprite2 = menu.LoadSprite("UI_main_art_blood_up");
    timebar.TimeBarSizeY = 19f;
    timebar.TimeBarSizeX = 213f;
    GameObject gameObject1 = new GameObject("Background");
    Image image1 = gameObject1.AddComponent<Image>();
    ((MaskableGraphic) image1).material = material;
    image1.sprite = sprite1;
    image1.type = (Image.Type) 1;
    timebar.m_BackgroundImage = image1;
    RectTransform component1 = gameObject1.GetComponent<RectTransform>();
    component1.anchoredPosition = new Vector2(43.5f, 0.0f);
    component1.sizeDelta = new Vector2(250f, 47f);
    component1.anchorMax = new Vector2(0.0f, 1f);
    component1.anchorMin = new Vector2(0.0f, 1f);
    component1.pivot = new Vector2(0.0f, 1f);
    gameObject1.transform.SetParent(timebar.transform, false);
    GameObject gameObject2 = new GameObject("Slider");
    Image image2 = gameObject2.AddComponent<Image>();
    ((MaskableGraphic) image2).material = material;
    image2.sprite = sprite2;
    image2.type = type;
    image2.fillMethod = fillMethod;
    image2.fillAmount = 0.0f;
    timebar.m_SliderImage = image2;
    RectTransform component2 = gameObject2.GetComponent<RectTransform>();
    component2.anchoredPosition = new Vector2(61f, -14f);
    component2.sizeDelta = new Vector2(213f, 19f);
    component2.anchorMax = new Vector2(0.0f, 1f);
    component2.anchorMin = new Vector2(0.0f, 1f);
    component2.pivot = new Vector2(0.0f, 1f);
    gameObject2.transform.SetParent(timebar.transform, false);
    timebar.m_SliderRectTransform = component2;
    GameObject gameObject3 = new GameObject("TitleText");
    UIText uiText1 = gameObject3.AddComponent<UIText>();
    uiText1.font = this.GetTTFFont();
    uiText1.alignment = TextAnchor.MiddleLeft;
    uiText1.fontSize = 16;
    RectTransform component3 = gameObject3.GetComponent<RectTransform>();
    component3.anchorMax = new Vector2(0.0f, 1f);
    component3.anchorMin = new Vector2(0.0f, 1f);
    component3.pivot = new Vector2(0.0f, 1f);
    component3.sizeDelta = new Vector2(119f, 27f);
    component3.anchoredPosition = new Vector2(70f, -10f);
    gameObject3.transform.SetParent(timebar.transform, false);
    timebar.m_TitleText = uiText1;
    GameObject gameObject4 = new GameObject("TimeText");
    UIText uiText2 = gameObject4.AddComponent<UIText>();
    uiText2.font = this.GetTTFFont();
    uiText2.alignment = TextAnchor.MiddleRight;
    uiText2.fontSize = 20;
    uiText2.resizeTextForBestFit = true;
    uiText2.resizeTextMinSize = 10;
    uiText2.resizeTextMaxSize = 20;
    RectTransform component4 = gameObject4.GetComponent<RectTransform>();
    component4.sizeDelta = new Vector2(186f, 27f);
    component4.anchorMax = new Vector2(1f, 1f);
    component4.anchorMin = new Vector2(1f, 1f);
    component4.pivot = new Vector2(1f, 1f);
    component4.anchoredPosition = new Vector2(10f, -10f);
    gameObject4.transform.SetParent(timebar.transform, false);
    timebar.m_TimeText = uiText2;
    GameObject gameObject5 = new GameObject("FunBtn");
    gameObject5.AddComponent<Image>();
    UIButton uiButton1 = gameObject5.AddComponent<UIButton>();
    uiButton1.SetButtonEffectType(e_EffectType.e_Scale);
    RectTransform component5 = gameObject5.GetComponent<RectTransform>();
    component5.pivot = new Vector2(0.5f, 0.5f);
    component5.anchoredPosition = new Vector2(315f, -23.5f);
    component5.sizeDelta = new Vector2(47f, 47f);
    component5.anchorMax = new Vector2(0.0f, 1f);
    component5.anchorMin = new Vector2(0.0f, 1f);
    component5.pivot = new Vector2(0.5f, 0.5f);
    gameObject5.transform.SetParent(timebar.transform, false);
    timebar.m_FuntionBtn = uiButton1;
    ((MaskableGraphic) timebar.m_FuntionBtn.image).material = material;
    timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_art_butt_up");
    timebar.m_FuntionBtn.image.SetNativeSize();
    timebar.m_FuntionBtn.m_EffectType = e_EffectType.e_Scale;
    timebar.m_FuntionBtn.transition = (Selectable.Transition) 0;
    uiButton1.m_BtnID1 = 2;
    GameObject gameObject6 = new GameObject("CancelBtn");
    gameObject6.AddComponent<Image>();
    UIButton uiButton2 = gameObject6.AddComponent<UIButton>();
    uiButton2.SetButtonEffectType(e_EffectType.e_Scale);
    RectTransform component6 = gameObject6.GetComponent<RectTransform>();
    component6.anchoredPosition = new Vector2(23.5f, -23.5f);
    component6.sizeDelta = new Vector2(47f, 47f);
    component6.anchorMax = new Vector2(0.0f, 1f);
    component6.anchorMin = new Vector2(0.0f, 1f);
    component6.pivot = new Vector2(0.5f, 0.5f);
    gameObject6.transform.SetParent(timebar.transform, false);
    timebar.m_CancelBtn = uiButton2;
    ((MaskableGraphic) timebar.m_CancelBtn.image).material = material;
    timebar.m_CancelBtn.image.sprite = menu.LoadSprite("UI_main_art_butt_stop");
    timebar.m_CancelBtn.m_EffectType = e_EffectType.e_Scale;
    timebar.m_CancelBtn.transition = (Selectable.Transition) 0;
    uiButton2.m_BtnID1 = 1;
  }

  public void SetTimeBarSpeedupStyle(UITimeBar timebar)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu == (UnityEngine.Object) null)
      return;
    Image.Type type = (Image.Type) 1;
    Image.FillMethod fillMethod = (Image.FillMethod) 0;
    Material material = menu.LoadMaterial();
    Sprite sprite1 = menu.LoadSprite("UI_main_art_box");
    Sprite sprite2 = menu.LoadSprite("UI_main_art_blood_up");
    float y1 = 29f;
    float x1 = 600f;
    float y2 = 19f;
    float x2 = 577.8f;
    float y3 = -4.3f;
    float x3 = 8.89f;
    timebar.TimeBarSizeY = 20.39f;
    timebar.TimeBarSizeX = 581.9f;
    timebar.GetComponent<RectTransform>().sizeDelta = new Vector2(x1, y1);
    GameObject gameObject1 = new GameObject("Background");
    Image image1 = gameObject1.AddComponent<Image>();
    ((MaskableGraphic) image1).material = material;
    image1.sprite = sprite1;
    image1.type = (Image.Type) 1;
    timebar.m_BackgroundImage = image1;
    RectTransform component1 = gameObject1.GetComponent<RectTransform>();
    component1.sizeDelta = new Vector2(x1, y1);
    component1.anchorMax = new Vector2(0.0f, 1f);
    component1.anchorMin = new Vector2(0.0f, 1f);
    component1.pivot = new Vector2(0.0f, 1f);
    gameObject1.transform.SetParent(timebar.transform, false);
    GameObject gameObject2 = new GameObject("Slider");
    Image image2 = gameObject2.AddComponent<Image>();
    ((MaskableGraphic) image2).material = material;
    image2.sprite = sprite2;
    image2.type = type;
    image2.fillMethod = fillMethod;
    image2.fillAmount = 0.0f;
    timebar.m_SliderImage = image2;
    RectTransform component2 = gameObject2.GetComponent<RectTransform>();
    component2.anchoredPosition = new Vector2(x3, y3);
    component2.sizeDelta = new Vector2(x2, y2);
    component2.anchorMax = new Vector2(0.0f, 1f);
    component2.anchorMin = new Vector2(0.0f, 1f);
    component2.pivot = new Vector2(0.0f, 1f);
    gameObject2.transform.SetParent(timebar.transform, false);
    timebar.m_SliderRectTransform = component2;
    GameObject gameObject3 = new GameObject("TitleText");
    UIText uiText1 = gameObject3.AddComponent<UIText>();
    uiText1.font = this.GetTTFFont();
    uiText1.fontSize = 20;
    uiText1.resizeTextForBestFit = true;
    uiText1.resizeTextMaxSize = 20;
    uiText1.resizeTextMinSize = 10;
    uiText1.alignment = TextAnchor.MiddleLeft;
    RectTransform component3 = gameObject3.GetComponent<RectTransform>();
    component3.anchorMax = new Vector2(0.0f, 1f);
    component3.anchorMin = new Vector2(0.0f, 1f);
    component3.pivot = new Vector2(0.0f, 1f);
    component3.sizeDelta = new Vector2(x2, 26f);
    component3.anchoredPosition = new Vector2(14f, -2f);
    gameObject3.transform.SetParent(timebar.transform, false);
    timebar.m_TitleText = uiText1;
    GameObject gameObject4 = new GameObject("TimeText");
    UIText uiText2 = gameObject4.AddComponent<UIText>();
    uiText2.font = this.GetTTFFont();
    uiText2.fontSize = 20;
    uiText2.resizeTextForBestFit = true;
    uiText2.resizeTextMaxSize = 20;
    uiText2.resizeTextMinSize = 10;
    uiText2.alignment = TextAnchor.MiddleRight;
    RectTransform component4 = gameObject4.GetComponent<RectTransform>();
    component4.sizeDelta = new Vector2(x2, 26f);
    component4.anchorMax = new Vector2(0.0f, 1f);
    component4.anchorMin = new Vector2(0.0f, 1f);
    component4.pivot = new Vector2(0.0f, 1f);
    component4.anchoredPosition = new Vector2(0.0f, -2f);
    gameObject4.transform.SetParent(timebar.transform, false);
    timebar.m_TimeText = uiText2;
  }

  public void SetTimeBarMarshalStyle(UITimeBar timebar, byte bulebar = 0)
  {
    RectTransform component1 = timebar.transform.GetComponent<RectTransform>();
    Image component2 = ((Component) component1).GetComponent<Image>();
    Image component3 = ((Transform) component1).GetChild(0).GetComponent<Image>();
    Image component4 = ((Component) component1).GetComponent<Image>();
    timebar.m_BackgroundImage = component4;
    UIText component5 = ((Transform) component1).GetChild(4).GetComponent<UIText>();
    component5.font = this.GetTTFFont();
    timebar.m_TimeText = component5;
    UIText component6 = ((Transform) component1).GetChild(5).GetComponent<UIText>();
    timebar.m_TitleText = component6;
    ((Transform) component1).GetChild(3).GetComponent<UIText>().font = this.GetTTFFont();
    Image component7;
    RectTransform component8;
    if (bulebar == (byte) 0)
    {
      ((Behaviour) component2).enabled = true;
      ((Component) component3).gameObject.SetActive(false);
      ((Transform) component1).GetChild(1).gameObject.SetActive(false);
      component7 = ((Transform) component1).GetChild(2).GetComponent<Image>();
      component8 = ((Transform) component1).GetChild(2).GetComponent<RectTransform>();
      ((Component) component7).gameObject.SetActive(true);
    }
    else
    {
      ((Behaviour) component2).enabled = false;
      ((Component) component3).gameObject.SetActive(true);
      ((Transform) component1).GetChild(2).gameObject.SetActive(false);
      component7 = ((Transform) component1).GetChild(1).GetComponent<Image>();
      component8 = ((Transform) component1).GetChild(1).GetComponent<RectTransform>();
      ((Component) component7).gameObject.SetActive(true);
    }
    component7.fillAmount = 0.0f;
    timebar.m_SliderImage = component7;
    timebar.m_SliderRectTransform = component8;
  }

  public void SetTimeBarUIMissionStyle(UITimeBar timebar)
  {
    RectTransform component1 = timebar.transform.GetComponent<RectTransform>();
    Image component2 = ((Component) component1).GetComponent<Image>();
    timebar.m_BackgroundImage = component2;
    Image component3 = ((Transform) component1).GetChild(0).GetComponent<Image>();
    component3.fillAmount = 0.0f;
    timebar.m_SliderImage = component3;
    RectTransform component4 = ((Transform) component1).GetChild(0).GetComponent<RectTransform>();
    timebar.m_SliderRectTransform = component4;
    UIText component5 = ((Transform) component1).GetChild(1).GetComponent<UIText>();
    timebar.m_TitleText = component5;
    component5.font = this.GetTTFFont();
    UIText component6 = ((Transform) component1).GetChild(2).GetComponent<UIText>();
    timebar.m_TimeText = component6;
    component6.font = this.GetTTFFont();
  }

  public void CreateTimerBar(
    UITimeBar timebar,
    long begin,
    long target,
    long notifyTime,
    eTimeBarType type,
    string title1,
    string title2)
  {
    switch (type)
    {
      case eTimeBarType.NormalType:
        this.SetTimeBarNormalStyle(timebar);
        break;
      case eTimeBarType.IconType:
        this.SetTimeBarIconStyle(timebar);
        break;
      case eTimeBarType.CancelType:
        this.SetTimeBarCancelStyle(timebar);
        break;
      case eTimeBarType.SpeedupType:
        this.SetTimeBarSpeedupStyle(timebar);
        break;
      case eTimeBarType.Marshal:
        this.SetTimeBarMarshalStyle(timebar, (byte) 0);
        break;
      case eTimeBarType.UIMission:
        this.SetTimeBarUIMissionStyle(timebar);
        break;
    }
    timebar.InitTimeBar();
    timebar.SetFunctionBtn();
    this.SetTimerBar(timebar, begin, target, notifyTime, type, title1, title2);
  }

  public void SetTimerSpriteType(UITimeBar timebar, eTimerSpriteType type)
  {
    timebar.m_TimerSpriteType = type;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu == (UnityEngine.Object) null)
      return;
    if (timebar.m_Type == eTimeBarType.IconType)
    {
      UIText component1 = ((Component) timebar.m_FuntionBtn).transform.GetChild(0).GetComponent<UIText>();
      if (timebar.m_TimerSpriteType == eTimerSpriteType.Speed)
      {
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_res_box_a");
        timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_queue_butt_up");
        timebar.m_FuntionBtn.image.SetNativeSize();
        ((Behaviour) component1).enabled = false;
        RectTransform component2 = ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>();
        component2.anchoredPosition = new Vector2((float) ((double) timebar.m_FuntionBtn.m_BtnID4 + (double) component2.sizeDelta.x / 2.0 + 5.0), 0.0f);
        timebar.m_TitleText.resizeTextForBestFit = false;
      }
      else if (timebar.m_TimerSpriteType == eTimerSpriteType.Help)
      {
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_res_box_c");
        timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_queue_butt_help");
        timebar.m_FuntionBtn.image.SetNativeSize();
        component1.text = DataManager.Instance.mStringTable.GetStringByID(781U);
        RectTransform component3 = ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>();
        ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>().anchoredPosition = new Vector2((float) timebar.m_FuntionBtn.m_BtnID4 + component3.sizeDelta.x / 2f, 0.0f);
        ((Behaviour) component1).enabled = true;
        timebar.m_TitleText.resizeTextForBestFit = false;
      }
      else if (timebar.m_TimerSpriteType == eTimerSpriteType.Free)
      {
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_res_box_b");
        timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_queue_butt_end");
        timebar.m_FuntionBtn.image.SetNativeSize();
        component1.text = DataManager.Instance.mStringTable.GetStringByID(780U);
        ((Behaviour) component1).enabled = true;
        RectTransform component4 = ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>();
        ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>().anchoredPosition = new Vector2((float) timebar.m_FuntionBtn.m_BtnID4 + component4.sizeDelta.x / 2f, 0.0f);
        timebar.m_TitleText.resizeTextForBestFit = false;
      }
      else if (timebar.m_TimerSpriteType == eTimerSpriteType.RallyCountDown || timebar.m_TimerSpriteType == eTimerSpriteType.RallyStanby)
      {
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_res_box_a");
        timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_queue_butt_view");
        timebar.m_FuntionBtn.image.SetNativeSize();
        ((Behaviour) component1).enabled = false;
        RectTransform component5 = ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>();
        ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>().anchoredPosition = new Vector2((float) ((double) timebar.m_FuntionBtn.m_BtnID4 + (double) component5.sizeDelta.x / 2.0 + 4.0), 0.0f);
        timebar.m_TitleText.resizeTextForBestFit = false;
      }
      else if (timebar.m_TimerSpriteType == eTimerSpriteType.Mobilization)
      {
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_res_box_a");
        timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_queue_butt_view");
        timebar.m_FuntionBtn.image.SetNativeSize();
        ((Behaviour) component1).enabled = false;
        RectTransform component6 = ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>();
        ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>().anchoredPosition = new Vector2((float) ((double) timebar.m_FuntionBtn.m_BtnID4 + (double) component6.sizeDelta.x / 2.0 + 4.0), 0.0f);
        timebar.m_TitleText.resizeTextForBestFit = false;
      }
      else if (timebar.m_TimerSpriteType == eTimerSpriteType.Mobilization_Report)
      {
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_res_box_a");
        timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_queue_butt_OK");
        timebar.m_FuntionBtn.image.SetNativeSize();
        ((Behaviour) component1).enabled = false;
        RectTransform component7 = ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>();
        ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>().anchoredPosition = new Vector2((float) ((double) timebar.m_FuntionBtn.m_BtnID4 + (double) component7.sizeDelta.x / 2.0 + 5.0), 0.0f);
        timebar.m_TitleText.resizeTextForBestFit = false;
      }
      else if (timebar.m_TimerSpriteType == eTimerSpriteType.Mobilization_fail)
      {
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_res_box_a");
        timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_queue_butt_NO");
        timebar.m_FuntionBtn.image.SetNativeSize();
        ((Behaviour) component1).enabled = false;
        RectTransform component8 = ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>();
        ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>().anchoredPosition = new Vector2((float) ((double) timebar.m_FuntionBtn.m_BtnID4 + (double) component8.sizeDelta.x / 2.0 + 5.0), 0.0f);
        timebar.m_TitleText.resizeTextForBestFit = false;
      }
      else if (timebar.m_TimerSpriteType == eTimerSpriteType.NPCRewardEnd)
      {
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_res_box_a");
        timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_queue_butt_OK");
        timebar.m_FuntionBtn.image.SetNativeSize();
        ((Behaviour) component1).enabled = false;
        RectTransform component9 = ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>();
        ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>().anchoredPosition = new Vector2((float) ((double) timebar.m_FuntionBtn.m_BtnID4 + (double) component9.sizeDelta.x / 2.0 + 5.0), 0.0f);
        timebar.m_TitleText.resizeTextForBestFit = false;
      }
      else if (timebar.m_TimerSpriteType == eTimerSpriteType.NPCRewardTransIng)
      {
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_res_box_a");
        timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_queue_butt_view");
        timebar.m_FuntionBtn.image.SetNativeSize();
        ((Behaviour) component1).enabled = false;
        RectTransform component10 = ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>();
        ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>().anchoredPosition = new Vector2((float) ((double) timebar.m_FuntionBtn.m_BtnID4 + (double) component10.sizeDelta.x / 2.0 + 5.0), 0.0f);
        timebar.m_TitleText.resizeTextForBestFit = false;
      }
      else if (timebar.m_TimerSpriteType == eTimerSpriteType.PetMarch)
      {
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_res_box_a");
        timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_queue_butt_view");
        timebar.m_FuntionBtn.image.SetNativeSize();
        ((Behaviour) component1).enabled = false;
        RectTransform component11 = ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>();
        ((Component) timebar.m_FuntionBtn).GetComponent<RectTransform>().anchoredPosition = new Vector2((float) ((double) timebar.m_FuntionBtn.m_BtnID4 + (double) component11.sizeDelta.x / 2.0 + 5.0), 0.0f);
        timebar.m_TitleText.resizeTextForBestFit = false;
      }
      else
      {
        if (timebar.m_TimerSpriteType != eTimerSpriteType.Idle)
          return;
        timebar.m_FuntionBtn.image.SetNativeSize();
        RectTransform rectTransform = ((Graphic) timebar.m_TitleText).rectTransform;
        rectTransform.sizeDelta = new Vector2(this.TimeBarTitleWidth, rectTransform.sizeDelta.y);
        timebar.m_TitleText.resizeTextForBestFit = true;
      }
    }
    else if (timebar.m_Type == eTimeBarType.NormalType)
    {
      if (timebar.m_TimerSpriteType == eTimerSpriteType.Speed)
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_art_blood_up");
      else if (timebar.m_TimerSpriteType == eTimerSpriteType.Help)
      {
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_art_blood_help");
      }
      else
      {
        if (timebar.m_TimerSpriteType != eTimerSpriteType.Free)
          return;
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_art_blood_end");
      }
    }
    else if (timebar.m_Type == eTimeBarType.SpeedupType)
    {
      timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_art_blood_end");
    }
    else
    {
      if (timebar.m_Type != eTimeBarType.CancelType)
        return;
      if (timebar.m_TimerSpriteType == eTimerSpriteType.Speed)
      {
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_art_blood_up");
        if (this.IsArabic)
          timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_art_butt_up_Arab");
        else
          timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_art_butt_up");
        timebar.m_BackgroundImage.sprite = menu.LoadSprite("UI_main_art_box_up");
      }
      else if (timebar.m_TimerSpriteType == eTimerSpriteType.Help)
      {
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_art_blood_help");
        timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_art_butt_help");
        timebar.m_BackgroundImage.sprite = menu.LoadSprite("UI_main_art_box_help");
      }
      else
      {
        if (timebar.m_TimerSpriteType != eTimerSpriteType.Free)
          return;
        timebar.m_SliderImage.sprite = menu.LoadSprite("UI_main_art_blood_end");
        if (GUIManager.instance.IsArabic)
          timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_art_butt_end_Arab");
        else
          timebar.m_FuntionBtn.image.sprite = menu.LoadSprite("UI_main_art_butt_end");
        timebar.m_BackgroundImage.sprite = menu.LoadSprite("UI_main_art_box_end");
      }
    }
  }

  public void OpenUISynthesis(int itemID)
  {
    AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UISynthesis", out this.m_UISynthesisAbKey);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return;
    GameObject gameObject = (GameObject) UnityEngine.Object.Instantiate(assetBundle.mainAsset);
    if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
    {
      AssetManager.UnloadAssetBundle(this.m_UISynthesisAbKey);
    }
    else
    {
      this.m_UISynthesis = gameObject.AddComponent<UISynthesis>();
      int index = 24;
      this.m_WindowList[index] = (GUIWindow) this.m_UISynthesis;
      GUIWindow window = this.m_WindowList[index];
      this.m_SecWindow = window;
      window.m_eWindow = EGUIWindow.UI_Synthesis;
      window.m_AssetBundle = assetBundle;
      window.m_AssetBundleKey = this.m_UISynthesisAbKey;
      if ((UnityEngine.Object) this.m_UISynthesis != (UnityEngine.Object) null)
        this.m_UISynthesis.MyOnOpen(itemID, gameObject.transform);
      gameObject.transform.SetParent((Transform) GUIManager.Instance.m_SecWindowLayer, false);
    }
  }

  public void SetRunningText(CString str)
  {
    this.m_RunningTextList.Add(str);
    if (((int) DataManager.Instance.RoleAttr.PrizeFlag & 2) == 0)
      return;
    Door menu1 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu1 != (UnityEngine.Object) null)
    {
      menu1.RunningText.CheckAddStr();
    }
    else
    {
      UIBattle_Gambling menu2 = GUIManager.Instance.FindMenu(EGUIWindow.UI_Battle_Gambling) as UIBattle_Gambling;
      if (!((UnityEngine.Object) menu2 != (UnityEngine.Object) null) || !((UnityEngine.Object) menu2.RunningText != (UnityEngine.Object) null))
        return;
      menu2.RunningText.CheckAddStr();
    }
  }

  public bool InitDemandResources(Transform DRT, float Width = 0, float Spacing = 0, bool bSetL = false)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    DemandResources component = DRT.GetComponent<DemandResources>();
    if ((UnityEngine.Object) menu == (UnityEngine.Object) null && (UnityEngine.Object) component == (UnityEngine.Object) null)
      return false;
    Vector2 vector2 = new Vector2(0.5f, 0.5f);
    component.BtnResources = new Image[5];
    component.ImgResources = new Image[5];
    component.TextResources = new UIText[5];
    for (int index = 0; index < 5; ++index)
    {
      GameObject gameObject1 = new GameObject("Btn");
      gameObject1.layer = 5;
      RectTransform rectTransform1 = gameObject1.AddComponent<RectTransform>();
      vector2.Set(0.5f, 0.5f);
      rectTransform1.pivot = vector2;
      rectTransform1.anchorMin = vector2;
      rectTransform1.anchorMax = vector2;
      rectTransform1.offsetMin = Vector2.zero;
      rectTransform1.offsetMax = Vector2.zero;
      if (bSetL)
        vector2.Set((float) ((double) (index - 2) * (double) Spacing + 15.0), -15f);
      else
        vector2.Set((float) (index - 2) * Spacing, -15f);
      rectTransform1.anchoredPosition = vector2;
      vector2.Set(Spacing, 70f);
      rectTransform1.sizeDelta = vector2;
      UIButton uiButton = gameObject1.AddComponent<UIButton>();
      uiButton.SetButtonEffectType(e_EffectType.e_Scale);
      uiButton.image = gameObject1.AddComponent<Image>();
      uiButton.image.sprite = menu.LoadSprite("UI_con_icon_05");
      ((MaskableGraphic) uiButton.image).material = menu.LoadMaterial();
      ((Graphic) uiButton.image).color = new Color(1f, 1f, 1f, 0.0f);
      gameObject1.transform.SetParent((Transform) component.GetComponent<RectTransform>(), false);
      uiButton.m_Handler = (IUIButtonClickHandler) component;
      uiButton.m_BtnID1 = 1000 + index;
      GameObject gameObject2 = new GameObject("Img");
      gameObject2.layer = 5;
      RectTransform rectTransform2 = gameObject2.AddComponent<RectTransform>();
      vector2.Set(0.5f, 0.5f);
      rectTransform2.pivot = vector2;
      rectTransform2.anchorMin = vector2;
      rectTransform2.anchorMax = vector2;
      rectTransform2.offsetMin = Vector2.zero;
      rectTransform2.offsetMax = Vector2.zero;
      if (bSetL)
        vector2.Set(-15f, 5f);
      else
        vector2.Set(0.0f, 5f);
      rectTransform2.anchoredPosition = vector2;
      component.ImgResources[index] = gameObject2.AddComponent<Image>();
      gameObject2.transform.SetParent((Transform) ((Component) rectTransform1).GetComponent<RectTransform>(), false);
      GameObject gameObject3 = new GameObject("Img2");
      gameObject3.layer = 5;
      RectTransform rectTransform3 = gameObject3.AddComponent<RectTransform>();
      vector2.Set(0.5f, 0.5f);
      rectTransform3.pivot = vector2;
      rectTransform3.anchorMin = vector2;
      rectTransform3.anchorMax = vector2;
      rectTransform3.offsetMin = Vector2.zero;
      rectTransform3.offsetMax = Vector2.zero;
      vector2.Set(37.5f, 17f);
      rectTransform3.anchoredPosition = vector2;
      vector2.Set(44f, 44f);
      rectTransform3.sizeDelta = vector2;
      component.BtnResources[index] = gameObject3.AddComponent<Image>();
      component.BtnResources[index].sprite = menu.LoadSprite("UI_con_icon_05");
      ((MaskableGraphic) component.BtnResources[index]).material = menu.LoadMaterial();
      component.BtnResources[index].SetNativeSize();
      gameObject3.transform.SetParent((Transform) ((Component) component.ImgResources[index]).GetComponent<RectTransform>(), false);
      ((Component) component.BtnResources[index]).gameObject.SetActive(false);
      GameObject gameObject4 = new GameObject("text");
      gameObject4.layer = 5;
      RectTransform rectTransform4 = gameObject4.AddComponent<RectTransform>();
      vector2.Set(0.5f, 0.5f);
      rectTransform4.pivot = vector2;
      rectTransform4.anchorMin = vector2;
      rectTransform4.anchorMax = vector2;
      rectTransform4.offsetMin = Vector2.zero;
      rectTransform4.offsetMax = Vector2.zero;
      vector2.Set(0.0f, -25f);
      rectTransform4.anchoredPosition = vector2;
      vector2.Set(Spacing, 24f);
      rectTransform4.sizeDelta = vector2;
      component.TextResources[index] = gameObject4.AddComponent<UIText>();
      gameObject4.transform.SetParent((Transform) ((Component) component.ImgResources[index]).GetComponent<RectTransform>(), false);
      component.TextResources[index].font = this.m_TTFFont;
      component.TextResources[index].fontSize = 16;
      this.tmpString.Length = 0;
      component.TextResources[index].text = this.tmpString.AppendFormat("{0:00000}", (object) index).ToString();
      component.TextResources[index].alignment = TextAnchor.MiddleCenter;
      gameObject4.AddComponent<IgnoreRaycast>();
    }
    component.ImgResources[0].sprite = menu.LoadSprite("UI_main_res_food");
    ((MaskableGraphic) component.ImgResources[0]).material = menu.LoadMaterial();
    component.ImgResources[0].SetNativeSize();
    component.ImgResources[1].sprite = menu.LoadSprite("UI_main_res_stone");
    ((MaskableGraphic) component.ImgResources[1]).material = menu.LoadMaterial();
    component.ImgResources[1].SetNativeSize();
    component.ImgResources[2].sprite = menu.LoadSprite("UI_main_res_wood");
    ((MaskableGraphic) component.ImgResources[2]).material = menu.LoadMaterial();
    component.ImgResources[2].SetNativeSize();
    component.ImgResources[3].sprite = menu.LoadSprite("UI_main_res_iron");
    ((MaskableGraphic) component.ImgResources[3]).material = menu.LoadMaterial();
    component.ImgResources[3].SetNativeSize();
    component.ImgResources[4].sprite = menu.LoadSprite("UI_main_money_01");
    ((MaskableGraphic) component.ImgResources[4]).material = menu.LoadMaterial();
    component.ImgResources[4].SetNativeSize();
    return true;
  }

  public bool SetDemandResourcesText(Transform DRT, long[] Resources)
  {
    DemandResources component = DRT.GetComponent<DemandResources>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
      return false;
    DataManager instance = DataManager.Instance;
    for (int index = 0; index < 5; ++index)
    {
      uint stock = instance.Resource[index].Stock;
      ((Component) component.BtnResources[index]).gameObject.SetActive(false);
      this.tmpString.Length = 0;
      if ((long) stock < Resources[index])
      {
        if (this.IsArabic)
        {
          GameConstants.FormatResourceValue(this.tmpString, (uint) Resources[index]);
          this.tmpString.Append("/<color=#E5004F>");
          GameConstants.FormatResourceValue(this.tmpString, stock);
          this.tmpString.Append("</color>");
        }
        else
        {
          this.tmpString.Append("<color=#E5004F>");
          GameConstants.FormatResourceValue(this.tmpString, stock);
          this.tmpString.AppendFormat("</color>/");
          GameConstants.FormatResourceValue(this.tmpString, (uint) Resources[index]);
        }
        ((Component) component.BtnResources[index]).gameObject.SetActive(true);
      }
      else if (this.IsArabic)
      {
        GameConstants.FormatResourceValue(this.tmpString, (uint) Resources[index]);
        this.tmpString.AppendFormat("/");
        GameConstants.FormatResourceValue(this.tmpString, stock);
      }
      else
      {
        GameConstants.FormatResourceValue(this.tmpString, stock);
        this.tmpString.AppendFormat("/");
        GameConstants.FormatResourceValue(this.tmpString, (uint) Resources[index]);
      }
      component.tmpValue[index] = (uint) Resources[index];
      component.TextResources[index].text = this.tmpString.ToString();
    }
    return true;
  }

  public bool InitUnitResourcesSlider(
    Transform URST,
    eUnitSlider Kind,
    uint Min,
    uint Max,
    float Alpha = 1f)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    UnitResourcesSlider component = URST.GetComponent<UnitResourcesSlider>();
    if ((UnityEngine.Object) component == (UnityEngine.Object) null)
      return false;
    Vector2 vector2_1 = new Vector2(0.5f, 0.5f);
    component.Value = (long) Min;
    component.SetMinValue((long) Min);
    component.Type = (byte) Kind;
    Material material = this.LoadMaterial("BuildingWindow", "BuildingWindow_m");
    GameObject gameObject1 = new GameObject("BtnIncrease");
    gameObject1.layer = 5;
    RectTransform rectTransform1 = gameObject1.AddComponent<RectTransform>();
    vector2_1.Set(0.5f, 0.5f);
    rectTransform1.pivot = vector2_1;
    rectTransform1.anchorMin = vector2_1;
    rectTransform1.anchorMax = vector2_1;
    rectTransform1.offsetMin = Vector2.zero;
    rectTransform1.offsetMax = Vector2.zero;
    vector2_1.Set(170f, -20f);
    rectTransform1.anchoredPosition = vector2_1;
    vector2_1.Set(70f, 60f);
    rectTransform1.sizeDelta = vector2_1;
    component.BtnIncrease = gameObject1.AddComponent<UIButton>();
    component.BtnIncrease.SetButtonEffectType(e_EffectType.e_Scale);
    component.BtnIncrease.image = gameObject1.AddComponent<Image>();
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      component.BtnIncrease.image.sprite = menu.LoadSprite("UI_main_strip_01");
      ((MaskableGraphic) component.BtnIncrease.image).material = menu.LoadMaterial();
    }
    ((Graphic) component.BtnIncrease.image).color = new Color(1f, 1f, 1f, 0.0f);
    gameObject1.AddComponent<UISliderBeHavior>().m_Handler = (MonoBehaviour) component;
    gameObject1.transform.SetParent((Transform) component.GetComponent<RectTransform>(), false);
    GameObject gameObject2 = new GameObject("Img");
    gameObject2.layer = 5;
    RectTransform rectTransform2 = gameObject2.AddComponent<RectTransform>();
    vector2_1.Set(0.5f, 0.5f);
    rectTransform2.pivot = vector2_1;
    rectTransform2.anchorMin = vector2_1;
    rectTransform2.anchorMax = vector2_1;
    rectTransform2.offsetMin = Vector2.zero;
    rectTransform2.offsetMax = Vector2.zero;
    vector2_1.Set(0.0f, 0.0f);
    rectTransform2.anchoredPosition = vector2_1;
    vector2_1.Set(33f, 33f);
    rectTransform2.sizeDelta = vector2_1;
    Image image1 = gameObject2.AddComponent<Image>();
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      image1.sprite = menu.LoadSprite("UI_main_strip_01");
      ((MaskableGraphic) image1).material = menu.LoadMaterial();
    }
    image1.SetNativeSize();
    Color color1 = ((Graphic) image1).color with
    {
      a = Alpha
    };
    ((Graphic) image1).color = color1;
    gameObject2.transform.SetParent((Transform) ((Component) component.BtnIncrease).GetComponent<RectTransform>(), false);
    GameObject gameObject3 = new GameObject("BtnLessen");
    gameObject3.layer = 5;
    RectTransform rectTransform3 = gameObject3.AddComponent<RectTransform>();
    vector2_1.Set(0.5f, 0.5f);
    rectTransform3.pivot = vector2_1;
    rectTransform3.anchorMin = vector2_1;
    rectTransform3.anchorMax = vector2_1;
    rectTransform3.offsetMin = Vector2.zero;
    rectTransform3.offsetMax = Vector2.zero;
    vector2_1.Set(-180f, -20f);
    rectTransform3.anchoredPosition = vector2_1;
    vector2_1.Set(70f, 60f);
    rectTransform3.sizeDelta = vector2_1;
    component.BtnLessen = gameObject3.AddComponent<UIButton>();
    component.BtnLessen.SetButtonEffectType(e_EffectType.e_Scale);
    component.BtnLessen.image = gameObject3.AddComponent<Image>();
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      component.BtnLessen.image.sprite = menu.LoadSprite("UI_main_strip_02");
      ((MaskableGraphic) component.BtnLessen.image).material = menu.LoadMaterial();
    }
    ((Graphic) component.BtnLessen.image).color = new Color(1f, 1f, 1f, 0.0f);
    gameObject3.AddComponent<UISliderBeHavior>().m_Handler = (MonoBehaviour) component;
    gameObject3.transform.SetParent((Transform) component.GetComponent<RectTransform>(), false);
    GameObject gameObject4 = new GameObject("Img");
    gameObject4.layer = 5;
    RectTransform rectTransform4 = gameObject4.AddComponent<RectTransform>();
    vector2_1.Set(0.5f, 0.5f);
    rectTransform4.pivot = vector2_1;
    rectTransform4.anchorMin = vector2_1;
    rectTransform4.anchorMax = vector2_1;
    rectTransform4.offsetMin = Vector2.zero;
    rectTransform4.offsetMax = Vector2.zero;
    vector2_1.Set(0.0f, 0.0f);
    rectTransform4.anchoredPosition = vector2_1;
    vector2_1.Set(33f, 33f);
    rectTransform4.sizeDelta = vector2_1;
    Image image2 = gameObject4.AddComponent<Image>();
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      image2.sprite = menu.LoadSprite("UI_main_strip_02");
      ((MaskableGraphic) image2).material = menu.LoadMaterial();
    }
    image2.SetNativeSize();
    Color color2 = ((Graphic) image2).color with
    {
      a = Alpha
    };
    ((Graphic) image2).color = color2;
    gameObject4.transform.SetParent((Transform) ((Component) component.BtnLessen).GetComponent<RectTransform>(), false);
    GameObject gameObject5 = new GameObject("m_slider");
    gameObject5.layer = 5;
    RectTransform rectTransform5 = gameObject5.AddComponent<RectTransform>();
    vector2_1.Set(0.5f, 0.5f);
    rectTransform5.pivot = vector2_1;
    rectTransform5.anchorMin = vector2_1;
    rectTransform5.anchorMax = vector2_1;
    rectTransform5.offsetMin = Vector2.zero;
    rectTransform5.offsetMax = Vector2.zero;
    vector2_1.Set(0.0f, -20f);
    rectTransform5.anchoredPosition = vector2_1;
    vector2_1.Set(257f, 19f);
    rectTransform5.sizeDelta = vector2_1;
    component.m_slider = gameObject5.AddComponent<CSlider>();
    gameObject5.transform.SetParent((Transform) component.GetComponent<RectTransform>(), false);
    GameObject gameObject6 = new GameObject("Background");
    gameObject6.layer = 5;
    RectTransform rectTransform6 = gameObject6.AddComponent<RectTransform>();
    vector2_1.Set(0.5f, 0.5f);
    rectTransform6.pivot = vector2_1;
    vector2_1.Set(0.5f, 0.5f);
    rectTransform6.anchorMin = vector2_1;
    vector2_1.Set(0.5f, 0.5f);
    rectTransform6.anchorMax = vector2_1;
    rectTransform6.offsetMin = Vector2.zero;
    rectTransform6.offsetMax = Vector2.zero;
    vector2_1.Set(0.0f, 0.0f);
    rectTransform6.anchoredPosition = vector2_1;
    vector2_1.Set(257f, 19f);
    rectTransform6.sizeDelta = vector2_1;
    Image image3 = gameObject6.AddComponent<Image>();
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      image3.sprite = menu.LoadSprite("UI_main_strip_03");
      ((MaskableGraphic) image3).material = menu.LoadMaterial();
    }
    Color color3 = ((Graphic) image3).color with
    {
      a = Alpha
    };
    ((Graphic) image3).color = color3;
    image3.type = (Image.Type) 1;
    gameObject6.transform.SetParent(((Component) component.m_slider).transform, false);
    GameObject gameObject7 = new GameObject("FillArea");
    gameObject7.layer = 5;
    RectTransform rectTransform7 = gameObject7.AddComponent<RectTransform>();
    vector2_1.Set(0.5f, 0.5f);
    rectTransform7.pivot = vector2_1;
    vector2_1.Set(0.0f, 0.25f);
    rectTransform7.anchorMin = vector2_1;
    vector2_1.Set(1f, 0.75f);
    rectTransform7.anchorMax = vector2_1;
    rectTransform7.offsetMin = new Vector2(5f, 0.0f);
    rectTransform7.offsetMax = new Vector2(-15f, 0.0f);
    vector2_1.Set(rectTransform7.anchoredPosition.x, rectTransform7.anchoredPosition.y);
    rectTransform7.anchoredPosition = vector2_1;
    vector2_1.Set(rectTransform7.sizeDelta.x, rectTransform7.sizeDelta.y);
    rectTransform7.sizeDelta = vector2_1;
    gameObject7.transform.SetParent(((Component) component.m_slider).transform, false);
    GameObject gameObject8 = new GameObject("Fill");
    gameObject8.layer = 5;
    RectTransform rectTransform8 = gameObject8.AddComponent<RectTransform>();
    vector2_1.Set(0.5f, 0.5f);
    rectTransform8.pivot = vector2_1;
    vector2_1.Set(0.0f, 0.0f);
    rectTransform8.anchorMin = vector2_1;
    vector2_1.Set(0.0f, 1f);
    rectTransform8.anchorMax = vector2_1;
    rectTransform8.offsetMin = Vector2.zero;
    rectTransform8.offsetMax = Vector2.zero;
    vector2_1.Set(-5f, rectTransform8.anchoredPosition.y);
    rectTransform8.anchoredPosition = vector2_1;
    vector2_1.Set(5f, rectTransform8.sizeDelta.y);
    rectTransform8.sizeDelta = vector2_1;
    Image image4 = gameObject8.AddComponent<Image>();
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      image4.sprite = menu.LoadSprite("UI_main_strip_03");
      ((MaskableGraphic) image4).material = menu.LoadMaterial();
    }
    Color color4 = ((Graphic) image4).color with
    {
      a = Alpha
    };
    ((Graphic) image4).color = color4;
    ((Component) image4).gameObject.SetActive(false);
    gameObject8.transform.SetParent(gameObject7.transform, false);
    component.m_slider.fillRect = rectTransform8;
    GameObject gameObject9 = new GameObject("HandleSlideArea");
    gameObject9.layer = 5;
    RectTransform rectTransform9 = gameObject9.AddComponent<RectTransform>();
    vector2_1.Set(0.5f, 0.5f);
    rectTransform9.pivot = vector2_1;
    vector2_1.Set(0.0f, 0.0f);
    rectTransform9.anchorMin = vector2_1;
    vector2_1.Set(1f, 1f);
    rectTransform9.anchorMax = vector2_1;
    rectTransform9.offsetMin = new Vector2(8f, 0.0f);
    rectTransform9.offsetMax = new Vector2(-10f, 0.0f);
    gameObject9.transform.SetParent(((Component) component.m_slider).transform, false);
    GameObject gameObject10 = new GameObject("Handle");
    gameObject10.layer = 5;
    RectTransform rectTransform10 = gameObject10.AddComponent<RectTransform>();
    vector2_1.Set(0.5f, 0.5f);
    rectTransform10.pivot = vector2_1;
    vector2_1.Set(1f, 0.0f);
    rectTransform10.anchorMin = vector2_1;
    vector2_1.Set(1f, 1f);
    rectTransform10.anchorMax = vector2_1;
    rectTransform10.offsetMin = new Vector2(0.0f, -13.5f);
    rectTransform10.offsetMax = new Vector2(0.0f, 13.5f);
    vector2_1.Set(0.0f, rectTransform10.anchoredPosition.y);
    rectTransform10.anchoredPosition = vector2_1;
    vector2_1.Set(46f, rectTransform10.sizeDelta.y);
    rectTransform10.sizeDelta = vector2_1;
    Image image5 = gameObject10.AddComponent<Image>();
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      image5.sprite = menu.LoadSprite("UI_main_strip_04");
      ((MaskableGraphic) image5).material = menu.LoadMaterial();
    }
    gameObject10.transform.SetParent(gameObject9.transform, false);
    component.m_slider.targetGraphic = (Graphic) image5;
    component.m_slider.handleRect = rectTransform10;
    component.m_slider.wholeNumbers = true;
    component.MaxValue = (long) Max;
    component.m_slider.minValue = (double) Min;
    component.m_slider.maxValue = (double) Max;
    component.m_slider.value = (double) Min;
    component.Speed = Max / 100U;
    if (component.Speed < 3U)
      component.Speed = 3U;
    Vector2 vector2_2 = new Vector2(0.5f, 0.5f);
    Vector2 vector2_3 = new Vector2(84f, 24f);
    switch (Kind)
    {
      case eUnitSlider.Barrack:
        vector2_2.Set(-32.5f, 33f);
        break;
      case eUnitSlider.Hospital:
        if (!this.IsArabic)
        {
          vector2_2.Set(40f, 20f);
          break;
        }
        vector2_2.Set(0.0f, 20f);
        break;
      case eUnitSlider.Expedition:
        vector2_2.Set(100f, 26f);
        break;
      case eUnitSlider.AutoUse:
        vector2_2.Set(-51f, 30f);
        break;
      case eUnitSlider.MarketHelp:
        vector2_2.Set(100f, 26f);
        break;
      case eUnitSlider.Crypt:
        if (!this.IsArabic)
          vector2_2.Set(-20f, 29f);
        else
          vector2_2.Set(-30f, 29f);
        vector2_3.Set(80f, 24f);
        break;
      case eUnitSlider.CastleStrengthen:
        vector2_2.Set(50f, 26f);
        break;
      case eUnitSlider.Other:
        vector2_2.Set(-80f, 52.5f);
        vector2_3.Set(80f, 24f);
        break;
    }
    GameObject gameObject11 = new GameObject("BtnInputText");
    gameObject11.layer = 5;
    RectTransform rectTransform11 = gameObject11.AddComponent<RectTransform>();
    vector2_1.Set(0.5f, 0.5f);
    rectTransform11.pivot = vector2_1;
    rectTransform11.anchorMin = vector2_1;
    rectTransform11.anchorMax = vector2_1;
    rectTransform11.offsetMin = Vector2.zero;
    rectTransform11.offsetMax = Vector2.zero;
    rectTransform11.anchoredPosition = vector2_2;
    rectTransform11.sizeDelta = vector2_3;
    component.BtnInputText = gameObject11.AddComponent<UIButton>();
    component.BtnInputText.image = gameObject11.AddComponent<Image>();
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
    {
      component.BtnInputText.image.sprite = menu.LoadSprite("UI_main_strip_05");
      ((MaskableGraphic) component.BtnInputText.image).material = menu.LoadMaterial();
    }
    component.BtnInputText.image.type = (Image.Type) 1;
    gameObject11.transform.SetParent((Transform) component.GetComponent<RectTransform>(), false);
    GameObject gameObject12 = new GameObject("Text");
    gameObject12.layer = 5;
    RectTransform rectTransform12 = gameObject12.AddComponent<RectTransform>();
    vector2_1.Set(0.5f, 0.5f);
    rectTransform12.pivot = vector2_1;
    vector2_1.Set(0.0f, 0.0f);
    rectTransform12.anchorMin = vector2_1;
    vector2_1.Set(1f, 1f);
    rectTransform12.anchorMax = vector2_1;
    rectTransform12.offsetMin = Vector2.zero;
    vector2_1.Set(-8f, 0.0f);
    rectTransform12.offsetMax = vector2_1;
    vector2_1.Set(rectTransform12.anchoredPosition.x, rectTransform12.anchoredPosition.y);
    rectTransform12.anchoredPosition = vector2_1;
    vector2_1.Set(rectTransform12.sizeDelta.x, rectTransform12.sizeDelta.y);
    rectTransform12.sizeDelta = vector2_1;
    UIText uiText = gameObject12.AddComponent<UIText>();
    uiText.font = this.GetTTFFont();
    uiText.fontSize = 18;
    uiText.alignment = TextAnchor.MiddleRight;
    uiText.supportRichText = false;
    gameObject12.transform.SetParent(((Component) component.BtnInputText).transform, false);
    component.m_inputText = uiText;
    this.tmpString.Length = 0;
    this.tmpString.AppendFormat("{0}", (object) Min);
    component.m_inputText.text = this.tmpString.ToString();
    if (Kind == eUnitSlider.CastleStrengthen)
      ((Component) component.BtnInputText).gameObject.SetActive(false);
    if (Kind == eUnitSlider.Barrack || Kind == eUnitSlider.Hospital || Kind == eUnitSlider.Other || Kind == eUnitSlider.Crypt)
    {
      GameObject gameObject13 = new GameObject("Image");
      gameObject13.layer = 5;
      RectTransform rectTransform13 = gameObject13.AddComponent<RectTransform>();
      vector2_1.Set(0.5f, 0.5f);
      rectTransform13.pivot = vector2_1;
      rectTransform13.anchorMin = vector2_1;
      rectTransform13.anchorMax = vector2_1;
      rectTransform13.offsetMin = Vector2.zero;
      rectTransform13.offsetMax = Vector2.zero;
      vector2_1.Set(vector2_2.x + 54f, vector2_2.y);
      rectTransform13.anchoredPosition = vector2_1;
      Image image6 = gameObject13.AddComponent<Image>();
      if ((UnityEngine.Object) menu != (UnityEngine.Object) null)
      {
        image6.sprite = menu.LoadSprite("UI_main_strip_06");
        ((MaskableGraphic) image6).material = menu.LoadMaterial();
      }
      image6.SetNativeSize();
      gameObject13.transform.SetParent(component.transform, false);
      if (Kind != eUnitSlider.Crypt)
      {
        GameObject gameObject14 = new GameObject("Text");
        gameObject14.layer = 5;
        RectTransform rectTransform14 = gameObject14.AddComponent<RectTransform>();
        vector2_1.Set(0.0f, 0.5f);
        rectTransform14.pivot = vector2_1;
        rectTransform14.anchorMin = vector2_1;
        rectTransform14.anchorMax = vector2_1;
        rectTransform14.offsetMin = Vector2.zero;
        rectTransform14.offsetMax = Vector2.zero;
        vector2_1.Set(314.5f, vector2_2.y);
        rectTransform14.anchoredPosition = vector2_1;
        vector2_1.Set(72f, 30f);
        rectTransform14.sizeDelta = vector2_1;
        component.m_TotalText = gameObject14.AddComponent<UIText>();
        component.m_TotalText.font = this.GetTTFFont();
        component.m_TotalText.alignment = TextAnchor.MiddleLeft;
        component.m_TotalText.fontSize = 18;
        this.tmpString.Length = 0;
        this.tmpString.AppendFormat("{0:N0}", (object) Max);
        component.m_TotalText.text = this.tmpString.ToString();
        ((Graphic) component.m_TotalText).color = new Color(1f, 0.925f, 0.529f);
        gameObject14.transform.SetParent(component.transform, false);
        if (this.IsArabic)
          ((Component) image6).transform.localScale = new Vector3(-1f, ((Component) image6).transform.localScale.y, ((Component) image6).transform.localScale.z);
      }
      else
      {
        GameObject gameObject15 = new GameObject("Text");
        gameObject15.layer = 5;
        RectTransform rectTransform15 = gameObject15.AddComponent<RectTransform>();
        vector2_1.Set(0.0f, 0.5f);
        rectTransform15.pivot = vector2_1;
        rectTransform15.anchorMin = vector2_1;
        rectTransform15.anchorMax = vector2_1;
        rectTransform15.offsetMin = Vector2.zero;
        rectTransform15.offsetMax = Vector2.zero;
        if (!this.IsArabic)
          vector2_1.Set(98f, vector2_2.y);
        else
          vector2_1.Set(88f, vector2_2.y);
        rectTransform15.anchoredPosition = vector2_1;
        vector2_1.Set(70f, 30f);
        rectTransform15.sizeDelta = vector2_1;
        component.m_TotalText = gameObject15.AddComponent<UIText>();
        component.m_TotalText.font = this.GetTTFFont();
        component.m_TotalText.alignment = TextAnchor.MiddleLeft;
        component.m_TotalText.fontSize = 18;
        this.tmpString.Length = 0;
        this.tmpString.AppendFormat("{0:N0}", (object) Max);
        component.m_TotalText.text = this.tmpString.ToString();
        ((Graphic) component.m_TotalText).color = new Color(1f, 0.925f, 0.529f);
        gameObject15.transform.SetParent(component.transform, false);
        if (this.IsArabic)
          ((Component) image6).transform.localScale = new Vector3(-1f, ((Component) image6).transform.localScale.y, ((Component) image6).transform.localScale.z);
      }
      switch (Kind)
      {
        case eUnitSlider.Barrack:
          GameObject gameObject16 = new GameObject("Image");
          gameObject16.layer = 5;
          RectTransform rectTransform16 = gameObject16.AddComponent<RectTransform>();
          vector2_1.Set(0.5f, 0.5f);
          rectTransform16.pivot = vector2_1;
          rectTransform16.anchorMin = vector2_1;
          rectTransform16.anchorMax = vector2_1;
          rectTransform16.offsetMin = Vector2.zero;
          rectTransform16.offsetMax = Vector2.zero;
          vector2_1.Set(-90f, 33f);
          rectTransform16.anchoredPosition = vector2_1;
          vector2_1.Set(31f, 41f);
          rectTransform16.sizeDelta = vector2_1;
          Image image7 = gameObject16.AddComponent<Image>();
          image7.sprite = this.LoadSprite("BuildingWindow", "UI_con_icon_04");
          ((MaskableGraphic) image7).material = material;
          image7.SetNativeSize();
          gameObject16.transform.SetParent(component.transform, false);
          break;
        case eUnitSlider.Hospital:
          if (this.IsArabic)
            ((Graphic) component.m_TotalText).rectTransform.anchoredPosition = new Vector2(270f, ((Graphic) component.m_TotalText).rectTransform.anchoredPosition.y);
          GameObject gameObject17 = new GameObject("Image");
          gameObject17.layer = 5;
          RectTransform rectTransform17 = gameObject17.AddComponent<RectTransform>();
          vector2_1.Set(0.5f, 0.5f);
          rectTransform17.pivot = vector2_1;
          rectTransform17.anchorMin = vector2_1;
          rectTransform17.anchorMax = vector2_1;
          rectTransform17.offsetMin = Vector2.zero;
          rectTransform17.offsetMax = Vector2.zero;
          if (!this.IsArabic)
            vector2_1.Set(-25f, 20f);
          else
            vector2_1.Set(160f, 20f);
          rectTransform17.anchoredPosition = vector2_1;
          Image image8 = gameObject17.AddComponent<Image>();
          image8.sprite = this.LoadSprite("BuildingWindow", "UI_con_icon_01");
          ((MaskableGraphic) image8).material = material;
          image8.SetNativeSize();
          gameObject17.transform.SetParent(component.transform, false);
          break;
      }
    }
    else if (Kind == eUnitSlider.Expedition)
    {
      GameObject gameObject18 = new GameObject("Image");
      gameObject18.layer = 5;
      RectTransform rectTransform18 = gameObject18.AddComponent<RectTransform>();
      vector2_1.Set(0.5f, 0.5f);
      rectTransform18.pivot = vector2_1;
      rectTransform18.anchorMin = vector2_1;
      rectTransform18.anchorMax = vector2_1;
      rectTransform18.offsetMin = Vector2.zero;
      rectTransform18.offsetMax = Vector2.zero;
      vector2_1.Set(45f, 25f);
      rectTransform18.anchoredPosition = vector2_1;
      vector2_1.Set(31f, 41f);
      rectTransform18.sizeDelta = vector2_1;
      gameObject18.AddComponent<Image>();
      gameObject18.transform.SetParent(component.transform, false);
    }
    return true;
  }

  public bool SetUnitResourcesSliderImg(
    Transform URST,
    eUnitSliderSize Kind,
    Sprite mspeite = null,
    Material mmaterial = null)
  {
    UnitResourcesSlider component1 = URST.GetComponent<UnitResourcesSlider>();
    if ((UnityEngine.Object) component1 == (UnityEngine.Object) null)
      return false;
    if ((UnityEngine.Object) mspeite != (UnityEngine.Object) null && (UnityEngine.Object) mmaterial != (UnityEngine.Object) null)
    {
      switch (Kind)
      {
        case eUnitSliderSize.BtnIncrease:
          component1.BtnIncrease.image.sprite = mspeite;
          ((MaskableGraphic) component1.BtnIncrease.image).material = mmaterial;
          Image component2 = ((Component) component1.BtnIncrease).transform.GetChild(0).GetComponent<Image>();
          component2.sprite = mspeite;
          ((MaskableGraphic) component2).material = mmaterial;
          break;
        case eUnitSliderSize.BtnLessen:
          component1.BtnLessen.image.sprite = mspeite;
          ((MaskableGraphic) component1.BtnLessen.image).material = mmaterial;
          Image component3 = ((Component) component1.BtnLessen).transform.GetChild(0).GetComponent<Image>();
          component3.sprite = mspeite;
          ((MaskableGraphic) component3).material = mmaterial;
          break;
        case eUnitSliderSize.Input:
          component1.BtnInputText.image.sprite = mspeite;
          ((MaskableGraphic) component1.BtnInputText.image).material = mmaterial;
          break;
        case eUnitSliderSize.m_sliderBG1:
          Transform component4 = ((Component) component1.m_slider).GetComponent<Transform>();
          Image component5 = component4.GetChild(0).GetComponent<Image>();
          component5.sprite = mspeite;
          ((MaskableGraphic) component5).material = mmaterial;
          Image component6 = component4.GetChild(1).GetChild(0).GetComponent<Image>();
          component6.sprite = mspeite;
          ((MaskableGraphic) component6).material = mmaterial;
          break;
        case eUnitSliderSize.m_sliderBG2:
          Image component7 = ((Component) component1.m_slider).GetComponent<Transform>().GetChild(2).GetChild(0).GetComponent<Image>();
          component7.sprite = mspeite;
          ((MaskableGraphic) component7).material = mmaterial;
          break;
        case eUnitSliderSize.m_Img:
          Image component8 = URST.GetChild(4).GetComponent<Image>();
          component8.sprite = mspeite;
          ((MaskableGraphic) component8).material = mmaterial;
          component8.SetNativeSize();
          break;
        case eUnitSliderSize.m_micon:
          Image component9 = URST.GetChild(6).GetComponent<Image>();
          component9.sprite = mspeite;
          ((MaskableGraphic) component9).material = mmaterial;
          component9.SetNativeSize();
          break;
      }
    }
    return true;
  }

  public bool SetUnitResourcesSliderSize(
    Transform URST,
    eUnitSliderSize Kind,
    float L,
    float T,
    float W,
    float H,
    float min = 0,
    float Max = 0)
  {
    UnitResourcesSlider component1 = URST.GetComponent<UnitResourcesSlider>();
    if ((UnityEngine.Object) component1 == (UnityEngine.Object) null)
      return false;
    Vector2 vector2_1 = new Vector2(L, T);
    Vector2 vector2_2 = new Vector2(W, H);
    int index = (int) Kind;
    switch (Kind)
    {
      case eUnitSliderSize.m_Img:
        index = 4;
        break;
      case eUnitSliderSize.m_micon:
        index = 6;
        break;
      case eUnitSliderSize.m_Text:
        index = 5;
        break;
    }
    RectTransform rectTransform = Kind != eUnitSliderSize.m_sliderBG1 ? URST.GetChild(index).GetComponent<RectTransform>() : URST.GetChild(2).GetChild(0).GetComponent<RectTransform>();
    rectTransform.anchoredPosition = vector2_1;
    rectTransform.sizeDelta = vector2_2;
    if (index == 2)
    {
      component1.m_slider.minValue = (double) min;
      component1.m_slider.maxValue = (double) Max;
      component1.MaxValue = (long) Max;
      RectTransform component2 = ((Component) URST.GetChild(2).GetChild(0).GetComponent<Image>()).GetComponent<RectTransform>();
      component2.sizeDelta = new Vector2(W, component2.sizeDelta.y);
    }
    return true;
  }

  public void InitBadgeTotem(Transform mBadgeT, ushort mEmblem)
  {
    StringBuilder stringBuilder = new StringBuilder();
    Vector2 vector2 = new Vector2(0.5f, 0.5f);
    Image component = mBadgeT.GetComponent<Image>();
    int num1 = (int) mEmblem & 7;
    int num2 = ((int) mEmblem >> 3 & 7) * 8 + num1 + 1;
    if (num2 > 64)
      num2 = 64;
    int num3 = ((int) mEmblem >> 6 & 63) + 1;
    if (num3 > 64)
      num3 = 64;
    stringBuilder.Length = 0;
    stringBuilder.AppendFormat("UI_league_badge_{0:00}", (object) num2);
    component.sprite = this.LoadBadgeSprite(true, stringBuilder.ToString());
    ((MaskableGraphic) component).material = this.GetBadgeMaterial(true);
    GameObject gameObject = new GameObject("Image");
    gameObject.layer = 5;
    RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
    rectTransform.pivot = vector2;
    rectTransform.anchorMin = vector2;
    rectTransform.anchorMax = vector2;
    rectTransform.offsetMin = Vector2.zero;
    rectTransform.offsetMax = Vector2.zero;
    vector2.Set(0.0f, 0.0f);
    rectTransform.anchoredPosition = vector2;
    vector2.Set(64f, 64f);
    rectTransform.sizeDelta = vector2;
    Image image = gameObject.AddComponent<Image>();
    stringBuilder.Length = 0;
    stringBuilder.AppendFormat("UI_league_totem_{0:00}", (object) num3);
    image.sprite = this.LoadBadgeSprite(false, stringBuilder.ToString());
    ((MaskableGraphic) image).material = this.GetBadgeMaterial(false);
    image.SetNativeSize();
    gameObject.transform.SetParent(mBadgeT, false);
    if (num2 <= 0)
      return;
    mBadgeT.gameObject.SetActive(true);
  }

  public void SetBadgeTotemImg(Transform mBadgeT, ushort mEmblem)
  {
    int num = (int) mEmblem & 7;
    int mBadge = ((int) mEmblem >> 3 & 7) * 8 + num + 1;
    if (mBadge > 64)
      mBadge = 64;
    int mTotem = ((int) mEmblem >> 6 & 63) + 1;
    if (mTotem > 64)
      mTotem = 64;
    this.SetBadgeTotemImg(mBadgeT, mBadge, mTotem);
  }

  public void SetBadgeTotemImg(Transform mBadgeT, int mBadge, int mTotem)
  {
    StringBuilder stringBuilder = new StringBuilder();
    Image component1 = mBadgeT.GetComponent<Image>();
    stringBuilder.Length = 0;
    stringBuilder.AppendFormat("UI_league_badge_{0:00}", (object) mBadge);
    component1.sprite = this.LoadBadgeSprite(true, stringBuilder.ToString());
    ((MaskableGraphic) component1).material = this.GetBadgeMaterial(true);
    Image component2 = mBadgeT.GetChild(0).GetComponent<Image>();
    stringBuilder.Length = 0;
    stringBuilder.AppendFormat("UI_league_totem_{0:00}", (object) mTotem);
    component2.sprite = this.LoadBadgeSprite(false, stringBuilder.ToString());
    ((MaskableGraphic) component2).material = this.GetBadgeMaterial(false);
  }

  public void HideAllHint()
  {
    if ((bool) (UnityEngine.Object) this.m_ItemInfo.m_RectTransform)
      this.m_ItemInfo.Hide();
    if ((bool) (UnityEngine.Object) this.m_SimpleItemInfo.m_RectTransform)
      this.m_SimpleItemInfo.Hide(this.m_SimpleItemInfo.m_ButtonHint);
    if ((bool) (UnityEngine.Object) this.m_SkillInfo.m_RectTransform)
      this.m_SkillInfo.Hide(this.m_SkillInfo.m_ButtonHint);
    if ((bool) (UnityEngine.Object) this.m_LordInfo.m_RectTransform)
      this.m_LordInfo.Hide(this.m_LordInfo.m_ButtonHint);
    if (!(bool) (UnityEngine.Object) this.m_Arena_Hint.m_RectTransform)
      return;
    this.m_Arena_Hint.Hide(this.m_Arena_Hint.m_ButtonHint);
  }

  public void OpenContinuousUI(ushort ItemID, int HeroID = -1)
  {
    this.OpenMenu(EGUIWindow.UI_BagFilter, 3 + ((int) ItemID << 16), HeroID, bSecWindow: true);
  }

  public void OpenItemFilterUI(ushort ItemID, ushort Num)
  {
    int num = 4;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.OpenMenu(EGUIWindow.UI_BagFilter, num + ((int) ItemID << 16), (int) Num);
  }

  public void OpenItemKindFilterUI(ushort ItemKind, byte Property, byte SuitID = 0)
  {
    int num = 6;
    if (BattleController.IsGambleMode)
    {
      GamblingManager.Instance.OpenMenu(EGUIWindow.UI_BagFilter, num + ((int) ItemKind << 16), (int) Property + ((int) SuitID << 16));
    }
    else
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
        return;
      menu.OpenMenu(EGUIWindow.UI_BagFilter, num + ((int) ItemKind << 16), (int) Property + ((int) SuitID << 16));
    }
  }

  public void OpenGemRemoveUI(ushort ItemPos, byte GemPos)
  {
    int num = 7;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.OpenMenu(EGUIWindow.UI_BagFilter, num + ((int) ItemPos << 16), (int) GemPos);
  }

  public void OpenSendGiftUI(CString Tag, CString Name)
  {
    if (!DataManager.Instance.CheckPrizeFlag((byte) 9))
      return;
    this.SendTag.ClearString();
    this.SendTag.Append(Tag);
    this.SendName.ClearString();
    this.SendName.Append(Name);
    (this.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BagFilter, 8);
  }

  public Material TechMaterial => this._TechMaterial;

  public void SetTalentIconSprite(string name, EGUIWindow updateui)
  {
    if ((UnityEngine.Object) this.TechIconArray != (UnityEngine.Object) null)
      return;
    CString Name = StringManager.Instance.StaticString1024();
    Name.StringToFormat("UITechIcon");
    Name.AppendFormat("UI/{0}");
    this.TechABRequest = AssetManager.GetAssetBundle(Name, out this.TechIconKey).LoadAsync(name, typeof (GameObject));
    this._TechUpdateUI = updateui;
  }

  public void DestroyTechIconSprite()
  {
    this.TechABRequest = (AssetBundleRequest) null;
    if (this.TechIconKey != 0)
    {
      AssetManager.UnloadAssetBundle(this.TechIconKey);
      this.TechIconKey = 0;
    }
    if ((UnityEngine.Object) this.TechIconArray == (UnityEngine.Object) null)
      return;
    UnityEngine.Object.DestroyImmediate((UnityEngine.Object) this.TechIconArray.gameObject, true);
    this.TechIconArray = (UISpritesArray) null;
    this.TechIconArrayCN = (UISpritesArray) null;
    this._TechMaterial = (Material) null;
  }

  public Sprite GetTechSprite(ushort id)
  {
    if ((UnityEngine.Object) this.TechIconArray == (UnityEngine.Object) null)
      return (Sprite) null;
    if (id == (ushort) 0)
      return this.TechIconArray.GetSprite(0);
    Sprite sprite;
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
    {
      sprite = this.TechIconArrayCN.GetSprite((int) id - 1);
      if ((UnityEngine.Object) sprite == (UnityEngine.Object) null)
        sprite = this.TechIconArray.GetSprite((int) id - 1);
    }
    else
      sprite = this.TechIconArray.GetSprite((int) id - 1);
    return (UnityEngine.Object) sprite == (UnityEngine.Object) null ? this.TechIconArray.GetSprite(0) : sprite;
  }

  public void InitSynthesisUISaveData()
  {
    this.m_SynthesisItemData = new List<ushort>();
    this.m_SynthesisPageType = e_SynPageType.Synthesis;
  }

  public void ClearSynthesisUIData()
  {
    this.m_SynthesisItemData.Clear();
    this.m_SynthesisPageType = e_SynPageType.Synthesis;
    this.m_SynthesisScrollIdx = 0;
    this.m_SynthesisScrollRectY = 0.0f;
    this.m_SynthesisBtnType = LevelTableKind.NormalStage;
    for (int index = 0; index < this.m_RequirementNum.Length; ++index)
    {
      this.m_RequirementNum[index] = (ushort) 0;
      this.m_SynthesisItemNum[index] = (ushort) 0;
    }
  }

  public void DestroySynthesisUISaveData()
  {
    this.ClearSynthesisUIData();
    this.m_SynthesisItemData = (List<ushort>) null;
  }

  public void CheckSynIsOpned()
  {
    int count = GUIManager.Instance.m_WindowStack.Count;
    bool flag1 = false;
    bool flag2 = false;
    for (int index = 0; index < count; ++index)
    {
      if (GUIManager.Instance.m_WindowStack[index].m_eWindow == EGUIWindow.UI_Synthesis)
        flag1 = true;
      if (GUIManager.Instance.m_WindowStack[index].m_eWindow == EGUIWindow.UI_BattleHeroSelect)
        flag2 = true;
    }
    if (!flag2 || !flag1 && !GUIManager.Instance.m_IsOpenedUISynthesis)
      return;
    GUIManager.Instance.m_WindowStack.RemoveAt(GUIManager.Instance.m_WindowStack.Count - 1);
    GUIManager.Instance.m_WindowStack.RemoveAt(GUIManager.Instance.m_WindowStack.Count - 1);
  }

  public void OpenTechTree(ushort TechID, bool GuideArrow = false)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    DataManager instance = DataManager.Instance;
    if (this.BuildingData.GetBuildNumByID((ushort) 10) == (byte) 0)
    {
      this.BuildingData.ManorGuild((ushort) 10, GuideArrow);
      menu.CloseMenu(true);
    }
    else
    {
      if (GuideArrow)
      {
        this.GuideParm1 = (byte) 3;
        this.GuideParm2 = TechID;
      }
      TechDataTbl recordByKey1 = instance.TechData.GetRecordByKey(TechID);
      TechKindTbl recordByKey2 = instance.TechKindData.GetRecordByKey((ushort) recordByKey1.Kind);
      int num1 = (int) recordByKey1.Kind | 32768;
      if (recordByKey1.Locked == (byte) 1)
      {
        this.AddHUDMessage(instance.mStringTable.GetStringByID(7520U), (ushort) 12);
      }
      else
      {
        GameConstants.GetBytes((ushort) 0, GUIManager.Instance.TechSaved, 6);
        menu.ClearWindowStack();
        if (menu.m_eMapMode != EUIOriginMapMode.KingdomMap)
        {
          GUIWindowStackData guiWindowStackData;
          guiWindowStackData.m_eWindow = EGUIWindow.UI_TechInstitute;
          guiWindowStackData.m_Arg1 = (int) this.BuildingData.GetBuildData((ushort) 10, (ushort) 0).ManorID;
          guiWindowStackData.m_Arg2 = 0;
          guiWindowStackData.bCameraMode = false;
          menu.m_WindowStack.Add(guiWindowStackData);
        }
        menu.OpenMenu(EGUIWindow.UI_TechTree, num1, (int) recordByKey2.KindName);
        for (int index = 0; index < instance.sortTechKindIndex.Length; ++index)
        {
          if ((int) instance.TechKindData.GetRecordByIndex((int) instance.sortTechKindIndex[index]).TechKind == (int) recordByKey1.Kind)
          {
            this.TechKindSaved[0] = (byte) (index / 4);
            GameConstants.GetBytes((float) this.TechKindSaved[0] * 227f, this.TechKindSaved, 1);
            break;
          }
        }
        ushort num2 = 0;
        ushort Start;
        ushort Count;
        instance.GetTechTreeDataRange(recordByKey1.Kind, out Start, out Count);
        for (ushort index = 0; (int) index < (int) Count; ++index)
        {
          TechTreeLayoutTbl recordByIndex = instance.TechTreeLayout.GetRecordByIndex((int) Start + (int) index);
          if ((int) recordByIndex.TechID1 == (int) TechID || (int) recordByIndex.TechID2 == (int) TechID || (int) recordByIndex.TechID3 == (int) TechID || (int) recordByIndex.TechID4 == (int) TechID)
          {
            num2 = index;
            break;
          }
        }
        this.UpdateUI(EGUIWindow.UI_TechTree, (int) num2, (int) TechID);
      }
    }
  }

  public void UIQueueLock(EGUIQueueLock bits)
  {
    this.mUIQueueLock = (int) ((EGUIQueueLock) this.mUIQueueLock | bits);
  }

  public void UIQueueLockRelease(EGUIQueueLock bits)
  {
    if (this.CheckUIQueueLock(bits))
      this.mUIQueueLock = (int) ((EGUIQueueLock) this.mUIQueueLock ^ bits);
    if (this.mUIQueueLock != 0)
      return;
    this.RestoreQueuedUI();
  }

  private bool CheckUIQueueLock(EGUIQueueLock bits)
  {
    return ((EGUIQueueLock) this.mUIQueueLock & bits) != (EGUIQueueLock) 0;
  }

  private bool OpenUIRestrict() => this.mUIQueueLock == 0;

  public void OpenUI_Queued_Restricted(
    EGUIWindow eWin,
    int arg1 = 0,
    int arg2 = 0,
    bool bCameraMode = false,
    byte openMode = 0)
  {
    if (this.OpenUIRestrict())
    {
      switch (openMode)
      {
        case 0:
          this.OpenMenu(eWin, arg1, arg2, bCameraMode, true);
          break;
        case 1:
          this.OpenOtherCanvasMenu(eWin, arg1, arg2);
          break;
        case 2:
          (this.FindMenu(EGUIWindow.Door) as Door).OpenMenu(eWin, arg1, arg2, bCameraMode);
          break;
      }
    }
    else
    {
      GUIQueueOpen guiQueueOpen;
      guiQueueOpen.eWin = eWin;
      guiQueueOpen.arg1 = arg1;
      guiQueueOpen.arg2 = arg2;
      guiQueueOpen.bCameraMode = bCameraMode;
      guiQueueOpen.mOpenMode = openMode;
      this.GUIQueue.Add(guiQueueOpen);
    }
  }

  public void OpenUI_Queued_Restricted_Top(
    EGUIWindow eWin,
    int arg1 = 0,
    int arg2 = 0,
    bool bCameraMode = false,
    byte openMode = 0)
  {
    if (this.OpenUIRestrict())
    {
      switch (openMode)
      {
        case 0:
          this.OpenMenu(eWin, arg1, arg2, bCameraMode, true);
          break;
        case 1:
          this.OpenOtherCanvasMenu(eWin, arg1, arg2);
          break;
        case 2:
          (this.FindMenu(EGUIWindow.Door) as Door).OpenMenu(eWin, arg1, arg2, bCameraMode);
          break;
      }
    }
    else
    {
      GUIQueueOpen guiQueueOpen;
      guiQueueOpen.eWin = eWin;
      guiQueueOpen.arg1 = arg1;
      guiQueueOpen.arg2 = arg2;
      guiQueueOpen.bCameraMode = bCameraMode;
      guiQueueOpen.mOpenMode = openMode;
      this.GUIQueue.Insert(0, guiQueueOpen);
    }
  }

  public void QueuedUI_Restricted(
    EGUIWindow eWin,
    int arg1 = 0,
    int arg2 = 0,
    bool bCameraMode = false,
    byte openMode = 0)
  {
    GUIQueueOpen guiQueueOpen;
    guiQueueOpen.eWin = eWin;
    guiQueueOpen.arg1 = arg1;
    guiQueueOpen.arg2 = arg2;
    guiQueueOpen.bCameraMode = bCameraMode;
    guiQueueOpen.mOpenMode = openMode;
    this.GUIQueue.Add(guiQueueOpen);
  }

  public void RestoreQueuedUI()
  {
    if (this.GUIQueue.Count == 0 || !this.OpenUIRestrict())
      return;
    switch (this.GUIQueue[0].mOpenMode)
    {
      case 0:
        this.OpenMenu(this.GUIQueue[0].eWin, this.GUIQueue[0].arg1, this.GUIQueue[0].arg2, this.GUIQueue[0].bCameraMode, true);
        break;
      case 1:
        this.OpenOtherCanvasMenu(this.GUIQueue[0].eWin, this.GUIQueue[0].arg1, this.GUIQueue[0].arg2);
        break;
      case 2:
        (this.FindMenu(EGUIWindow.Door) as Door).OpenMenu(this.GUIQueue[0].eWin, this.GUIQueue[0].arg1, this.GUIQueue[0].arg2, this.GUIQueue[0].bCameraMode);
        this.GUIQueue.RemoveAt(0);
        this.RestoreQueuedUI();
        return;
    }
    this.GUIQueue.RemoveAt(0);
  }

  public bool CheckInQueue(EGUIWindow eWin)
  {
    for (int index = 0; index < this.GUIQueue.Count; ++index)
    {
      if (this.GUIQueue[index].eWin == eWin)
        return true;
    }
    return false;
  }

  public bool CanResourceTransport()
  {
    bool flag = false;
    if (this.m_ResourceTransportStr == null)
      this.m_ResourceTransportStr = StringManager.Instance.SpawnString(300);
    GUIManager instance = GUIManager.Instance;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData((ushort) 17, (ushort) 0);
    uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    int num = 0;
    for (int index = 0; index < 8; ++index)
    {
      if (DataManager.Instance.MarchEventData[index].Type != EMarchEventType.EMET_Standby)
        ++num;
    }
    if ((long) num >= (long) effectBaseVal)
    {
      this.m_ResourceTransportStr.ClearString();
      this.m_ResourceTransportStr.IntToFormat((long) effectBaseVal);
      this.m_ResourceTransportStr.AppendFormat(mStringTable.GetStringByID(3959U));
      instance.OpenMessageBox(mStringTable.GetStringByID(3967U), this.m_ResourceTransportStr.ToString());
    }
    else if (buildData.Level <= (byte) 0)
    {
      instance.OpenMessageBox(mStringTable.GetStringByID(4834U), mStringTable.GetStringByID(4088U));
      flag = false;
    }
    else
      flag = true;
    return flag;
  }

  public bool CanReinforce()
  {
    bool flag = false;
    if (this.m_ResourceTransportStr == null)
      this.m_ResourceTransportStr = StringManager.Instance.SpawnString();
    GUIManager instance = GUIManager.Instance;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData((ushort) 14, (ushort) 0);
    uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    int num = 0;
    for (int index = 0; index < 8; ++index)
    {
      if (DataManager.Instance.MarchEventData[index].Type != EMarchEventType.EMET_Standby)
        ++num;
    }
    if (buildData.Level <= (byte) 0)
    {
      instance.OpenMessageBox(mStringTable.GetStringByID(4834U), mStringTable.GetStringByID(4835U));
      flag = false;
    }
    else if ((long) num >= (long) effectBaseVal)
    {
      this.m_ResourceTransportStr.ClearString();
      this.m_ResourceTransportStr.IntToFormat((long) effectBaseVal);
      this.m_ResourceTransportStr.AppendFormat(mStringTable.GetStringByID(3959U));
      instance.OpenMessageBox(mStringTable.GetStringByID(3967U), this.m_ResourceTransportStr.ToString());
    }
    else
      flag = true;
    return flag;
  }

  public GUIWindow OpenOtherCanvasMenu(EGUIWindow eWin, int arg1 = 0, int arg2 = 0)
  {
    int index = (int) eWin;
    if ((UnityEngine.Object) this.m_WindowList[index] != (UnityEngine.Object) null)
      return (GUIWindow) null;
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendFormat("UI/{0}", (object) WindowPrefabData.Data[index].m_PrefabName);
    int Key = 0;
    AssetBundle assetBundle = AssetManager.GetAssetBundle(stringBuilder.ToString(), out Key);
    if ((UnityEngine.Object) assetBundle == (UnityEngine.Object) null)
      return (GUIWindow) null;
    GameObject gameObject = WindowPrefabData.Data[index].m_OptName != null ? (GameObject) UnityEngine.Object.Instantiate(assetBundle.Load(WindowPrefabData.Data[index].m_OptName)) : (GameObject) UnityEngine.Object.Instantiate(assetBundle.mainAsset);
    if ((UnityEngine.Object) gameObject == (UnityEngine.Object) null)
    {
      AssetManager.UnloadAssetBundle(Key);
      return (GUIWindow) null;
    }
    if ((UnityEngine.Object) this.m_OtherCanvasLayer == (UnityEngine.Object) null)
      this.initOtherCanvas();
    gameObject.transform.SetParent((Transform) this.m_OtherCanvasTransform, false);
    if (NewbieManager.IsNewbie)
      this.UpdateUI(EGUIWindow.UI_Front, 2);
    GUIWindow guiWindow = (GUIWindow) gameObject.AddComponent(WindowPrefabData.Data[index].m_WindowType);
    this.m_WindowList[index] = guiWindow;
    this.m_OtheCanvas = guiWindow;
    guiWindow.m_eWindow = eWin;
    guiWindow.m_AssetBundle = assetBundle;
    guiWindow.m_AssetBundleKey = Key;
    guiWindow.OnOpen(arg1, arg2);
    return guiWindow;
  }

  private void initOtherCanvas()
  {
    this.GoSubCam = new GameObject("subCamera");
    this.GoSubCam.transform.localPosition = new Vector3(0.0f, 500f, 0.0f);
    Camera camera = this.GoSubCam.AddComponent<Camera>();
    camera.clearFlags = CameraClearFlags.Depth;
    camera.isOrthoGraphic = true;
    camera.cullingMask = 32;
    this.GoSubCanvas = new GameObject("subCanvas");
    this.GoSubCanvas.layer = 5;
    this.m_OtherCanvasLayer = this.GoSubCanvas.AddComponent<RectTransform>();
    Canvas canvas = this.GoSubCanvas.AddComponent<Canvas>();
    canvas.renderMode = (RenderMode) 1;
    canvas.worldCamera = camera;
    this.GoSubCanvas.AddComponent<GraphicRaycaster>();
    CanvasScaler canvasScaler = this.GoSubCanvas.AddComponent<CanvasScaler>();
    canvasScaler.uiScaleMode = (CanvasScaler.ScaleMode) 1;
    canvasScaler.referenceResolution = GUIManager.ResolutionSize;
    canvasScaler.matchWidthOrHeight = 1f;
    this.m_OtherCanvasTransform = new GameObject("Windows")
    {
      layer = 5
    }.AddComponent<RectTransform>();
    ((Transform) this.m_OtherCanvasTransform).SetParent(((Component) this.m_OtherCanvasLayer).transform, false);
    this.StretchTransform(this.m_OtherCanvasTransform);
    if (!this.IsArabic)
      return;
    ((Transform) this.m_OtherCanvasTransform).localScale = new Vector3(-((Transform) this.m_OtherCanvasTransform).localScale.x, ((Transform) this.m_OtherCanvasTransform).localScale.y, ((Transform) this.m_OtherCanvasTransform).localScale.z);
  }

  private void DestoryOtherCanvas()
  {
    this.m_OtherCanvasLayer = (RectTransform) null;
    if ((UnityEngine.Object) this.GoSubCam != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.GoSubCam);
      this.GoSubCam = (GameObject) null;
    }
    if (!((UnityEngine.Object) this.GoSubCanvas != (UnityEngine.Object) null))
      return;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.GoSubCanvas);
    this.GoSubCanvas = (GameObject) null;
  }

  public void GuideArrow(RectTransform Target, ArrowDirect ArWay, float offset = 0.0f)
  {
    if (NewbieManager.IsWorking())
    {
      this.GuideParm1 = (byte) 0;
      this.GuideParm2 = (ushort) 0;
    }
    else
    {
      if ((UnityEngine.Object) this.ArrowRect == (UnityEngine.Object) null)
      {
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        this.ArrowRect = menu.m_ArrowRC;
        this.ArrowPos = menu.m_ArrowPos;
        this.ArrowPos.duration = 0.95f;
        this.ArrowParentRect = (RectTransform) ((Transform) this.ArrowRect).parent;
      }
      if ((UnityEngine.Object) this.ArrowRect == (UnityEngine.Object) null || ((Component) this.ArrowRect).gameObject.activeSelf)
        return;
      Vector2 sizeDelta = ((Component) this.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta;
      float num = 0.0f;
      ((Transform) this.ArrowRect).SetParent(((Transform) Target).parent);
      this.ArrowRect.anchoredPosition3D = Target.anchoredPosition3D;
      Vector3 anchoredPosition3D = this.ArrowRect.anchoredPosition3D;
      anchoredPosition3D.x = (float) ((double) anchoredPosition3D.x + (double) this.ArrowRect.sizeDelta.y * (1.0 - (double) this.ArrowRect.pivot.x) - (double) this.ArrowRect.sizeDelta.y * 0.5);
      anchoredPosition3D.y = (float) ((double) anchoredPosition3D.y + (double) this.ArrowRect.sizeDelta.x * (1.0 - (double) this.ArrowRect.pivot.y) - (double) this.ArrowRect.sizeDelta.x * 0.5);
      if ((double) Target.anchorMin.x < 0.5 && (double) Target.anchorMax.x < 0.5)
        anchoredPosition3D.x = sizeDelta.x * -0.5f + anchoredPosition3D.x;
      else if ((double) Target.anchorMin.x > 0.5 && (double) Target.anchorMax.x > 0.5)
        anchoredPosition3D.x = sizeDelta.x * 0.5f + anchoredPosition3D.x;
      if ((double) Target.anchorMin.y < 0.5 && (double) Target.anchorMax.y < 0.5)
        anchoredPosition3D.y = sizeDelta.y * -0.5f + anchoredPosition3D.y;
      else if ((double) Target.anchorMin.y > 0.5 && (double) Target.anchorMax.y > 0.5)
        anchoredPosition3D.y = sizeDelta.y * 0.5f - anchoredPosition3D.y;
      Quaternion localRotation = ((Transform) this.ArrowRect).localRotation;
      switch (ArWay)
      {
        case ArrowDirect.Ar_Up:
          localRotation.eulerAngles = new Vector3(0.0f, 0.0f, 270f);
          if ((double) Target.pivot.x < 0.5)
            anchoredPosition3D.x += Target.sizeDelta.x * 0.5f;
          if ((double) Target.pivot.y < 0.5)
            anchoredPosition3D.y += Target.sizeDelta.y * 0.5f;
          anchoredPosition3D.y += (float) ((double) Target.sizeDelta.y * 0.5 + (double) this.ArrowRect.sizeDelta.y * 0.5);
          num = 40f;
          break;
        case ArrowDirect.Ar_Down:
          localRotation.eulerAngles = new Vector3(0.0f, 0.0f, 90f);
          if ((double) Target.pivot.x < 0.5)
            anchoredPosition3D.x -= Target.sizeDelta.x * 0.5f;
          if ((double) Target.pivot.x < 0.5)
            anchoredPosition3D.y -= Target.sizeDelta.y * 0.5f;
          anchoredPosition3D.y -= (float) ((double) Target.sizeDelta.y * 0.5 + (double) this.ArrowRect.sizeDelta.y * 0.5);
          num = -40f;
          break;
        case ArrowDirect.Ar_Left:
          localRotation.eulerAngles = Vector3.zero;
          if ((double) Target.pivot.x < 0.5)
            anchoredPosition3D.x -= Target.sizeDelta.x * 0.5f;
          if ((double) Target.pivot.y < 0.5)
            anchoredPosition3D.y -= Target.sizeDelta.y * 0.5f;
          anchoredPosition3D.x -= (float) ((double) Target.sizeDelta.x * 0.5 + (double) this.ArrowRect.sizeDelta.x * 0.5);
          num = -40f;
          break;
        case ArrowDirect.Ar_Right:
          localRotation.eulerAngles = new Vector3(0.0f, 0.0f, 180f);
          if ((double) Target.pivot.x < 0.5)
            anchoredPosition3D.x += Target.sizeDelta.x * 0.5f;
          if ((double) Target.pivot.y < 0.5)
            anchoredPosition3D.y += Target.sizeDelta.y * 0.5f;
          anchoredPosition3D.x += (float) ((double) Target.sizeDelta.x * 0.5 + (double) this.ArrowRect.sizeDelta.x * 0.5);
          num = 40f;
          break;
      }
      ((Transform) this.ArrowRect).localRotation = localRotation;
      this.ArrowRect.anchoredPosition3D = anchoredPosition3D;
      if (ArWay == ArrowDirect.Ar_Up || ArWay == ArrowDirect.Ar_Down)
      {
        this.ArrowPos.from = new Vector3(anchoredPosition3D.x, anchoredPosition3D.y + offset, anchoredPosition3D.z);
        this.ArrowPos.to = new Vector3(anchoredPosition3D.x, anchoredPosition3D.y + num + offset, anchoredPosition3D.z);
      }
      else
      {
        this.ArrowPos.from = new Vector3(anchoredPosition3D.x + offset, anchoredPosition3D.y, anchoredPosition3D.z);
        this.ArrowPos.to = new Vector3(anchoredPosition3D.x + num + offset, anchoredPosition3D.y, anchoredPosition3D.z);
      }
      ((Component) this.ArrowRect).gameObject.SetActive(true);
      this.UpdateArrow = (byte) 2;
    }
  }

  public void GuideArrow_Position(Vector3 Pos, ArrowDirect ArWay)
  {
    if (NewbieManager.IsWorking())
    {
      this.GuideParm1 = (byte) 0;
      this.GuideParm2 = (ushort) 0;
    }
    else
    {
      if ((UnityEngine.Object) this.ArrowRect == (UnityEngine.Object) null)
      {
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        this.ArrowRect = menu.m_ArrowRC;
        this.ArrowPos = menu.m_ArrowPos;
        this.ArrowPos.duration = 0.95f;
        this.ArrowParentRect = (RectTransform) ((Transform) this.ArrowRect).parent;
      }
      if ((UnityEngine.Object) this.ArrowRect == (UnityEngine.Object) null || ((Component) this.ArrowRect).gameObject.activeSelf)
        return;
      ((Transform) this.ArrowRect).localScale = (Vector3) Vector2.one;
      Vector2 sizeDelta = ((Component) this.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta;
      float num = 0.0f;
      Quaternion localRotation = ((Transform) this.ArrowRect).localRotation;
      switch (ArWay)
      {
        case ArrowDirect.Ar_Up:
          localRotation.eulerAngles = new Vector3(0.0f, 0.0f, 270f);
          num = 40f;
          break;
        case ArrowDirect.Ar_Down:
          localRotation.eulerAngles = new Vector3(0.0f, 0.0f, 90f);
          num = -40f;
          break;
        case ArrowDirect.Ar_Left:
          localRotation.eulerAngles = Vector3.zero;
          num = -40f;
          break;
        case ArrowDirect.Ar_Right:
          localRotation.eulerAngles = new Vector3(0.0f, 0.0f, 180f);
          num = 40f;
          break;
      }
      ((Transform) this.ArrowRect).localRotation = localRotation;
      this.ArrowRect.anchoredPosition3D = Pos;
      if (ArWay == ArrowDirect.Ar_Up || ArWay == ArrowDirect.Ar_Down)
      {
        this.ArrowPos.from = new Vector3(Pos.x, Pos.y, Pos.z);
        this.ArrowPos.to = new Vector3(Pos.x, Pos.y + num, Pos.z);
      }
      else
      {
        this.ArrowPos.from = new Vector3(Pos.x, Pos.y, Pos.z);
        this.ArrowPos.to = new Vector3(Pos.x + num, Pos.y, Pos.z);
      }
      ((Component) this.ArrowRect).gameObject.SetActive(true);
      this.UpdateArrow = (byte) 2;
    }
  }

  public void HideArrow(bool bClearParm = false)
  {
    if ((UnityEngine.Object) this.ArrowRect != (UnityEngine.Object) null && ((Component) this.ArrowRect).gameObject.activeSelf)
    {
      ((Component) this.ArrowRect).gameObject.SetActive(false);
      this.GuideParm1 = (byte) 0;
      this.GuideParm2 = (ushort) 0;
    }
    else
    {
      if (!bClearParm)
        return;
      this.GuideParm1 = (byte) 0;
      this.GuideParm2 = (ushort) 0;
    }
  }

  public void SetFrontMark(byte Val) => PlayerPrefs.SetString("Front_Guide", Val.ToString());

  public void AddHerodLvUpData(ushort heroID, byte beginLv, byte targetLv)
  {
    bool flag = false;
    sHeroLvUp sHeroLvUp;
    if (this.m_HerodLvUpData != null)
    {
      for (int index = 0; index < this.m_HerodLvUpData.Count; ++index)
      {
        if ((int) this.m_HerodLvUpData[index].HeroID == (int) heroID)
        {
          flag = true;
          sHeroLvUp = this.m_HerodLvUpData[index] with
          {
            HeroID = heroID,
            BeginLv = beginLv,
            TargetLv = targetLv
          };
          this.m_HerodLvUpData[index] = sHeroLvUp;
        }
      }
    }
    if (flag)
      return;
    sHeroLvUp = new sHeroLvUp();
    sHeroLvUp.HeroID = heroID;
    sHeroLvUp.BeginLv = beginLv;
    sHeroLvUp.TargetLv = targetLv;
    this.m_HerodLvUpData.Add(sHeroLvUp);
  }

  public void SetRoleAttrDiamond(uint diamond, ushort itemID = 0, eSpentCredits type = eSpentCredits.eMax)
  {
    if (diamond < DataManager.Instance.RoleAttr.Diamond)
    {
      string empty = string.Empty;
      string str = string.Empty;
      int num = (int) DataManager.Instance.RoleAttr.Diamond - (int) diamond;
      if (itemID != (ushort) 0)
      {
        Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(itemID);
        empty = ((EItemType) ((uint) recordByKey.EquipKind - 1U)).ToString();
        str = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.EquipName);
      }
      else if (type < (eSpentCredits) this.SpentCreditsStr.Length)
        empty = this.SpentCreditsStr[(int) type];
      IGGSDKPlugin.SetFacebookEventSpentCredits((double) num, empty, str);
    }
    if (diamond > 100000000U)
      diamond = 100000000U;
    DataManager.Instance.RoleAttr.Diamond = diamond;
  }

  public void ClearCalculator()
  {
    if (!((UnityEngine.Object) this.Obj_UICalculator != (UnityEngine.Object) null))
      return;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.Obj_UICalculator);
    this.Obj_UICalculator = (GameObject) null;
    this.m_UICalculator.mUnitRslider = (UnitResourcesSlider) null;
  }

  public void OnUIBattlePause(bool pause)
  {
    if (!pause)
      return;
    UILegBattle menu1 = (UILegBattle) this.FindMenu(EGUIWindow.UI_LegBattle);
    if ((UnityEngine.Object) menu1 != (UnityEngine.Object) null)
      menu1.OnBattlePause();
    UIBattle menu2 = (UIBattle) this.FindMenu(EGUIWindow.UI_Battle);
    if (!((UnityEngine.Object) menu2 != (UnityEngine.Object) null))
      return;
    menu2.OnBattlePause();
  }

  public void OpenCanonizedPanel(CString name, byte backgroundType, int btnType)
  {
    if (name == null || this.CanonizedName == null)
      return;
    this.CanonizedName.ClearString();
    this.CanonizedName.Append(name);
    this.OpenMenu(EGUIWindow.UI_CanonizedPanel, (int) backgroundType, btnType, true, true);
  }

  public void OpenPreviewHeroInfo(
    ushort HeroID,
    bool Curhero = true,
    byte Lv = 60,
    byte Enhance = 8,
    byte Star = 5,
    byte Equip = 63,
    int mIdx = 0)
  {
    DataManager instance = DataManager.Instance;
    instance.PreviewHeroData.ID = HeroID;
    instance.PreviewHeroData.Level = Lv;
    instance.PreviewHeroData.SkillLV = new byte[4];
    instance.PreviewHeroData.Enhance = Enhance;
    instance.PreviewHeroData.Star = Star;
    instance.PreviewHeroData.Equip = Equip;
    instance.PreviewHeroData.SkillLV[0] = Lv;
    instance.PreviewHeroData.SkillLV[1] = instance.PreviewHeroData.Enhance < (byte) 2 ? (byte) 0 : Lv;
    instance.PreviewHeroData.SkillLV[2] = instance.PreviewHeroData.Enhance < (byte) 4 || (int) Lv - 20 <= 0 ? (byte) 0 : (byte) ((uint) Lv - 20U);
    instance.PreviewHeroData.SkillLV[3] = instance.PreviewHeroData.Enhance < (byte) 7 || (int) Lv - 40 <= 0 ? (byte) 0 : (byte) ((uint) Lv - 40U);
    int num = 0;
    if (!Curhero)
    {
      num = 1;
      this.UIPreviewHero_Index = mIdx;
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Synthesis, 1);
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (UnityEngine.Object) menu)
      return;
    if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Hero_Info))
      menu.CloseMenu();
    menu.OpenMenu(EGUIWindow.UI_Hero_Info, num, 1, true);
  }

  public void SetChallegeRewardUI(int CrystalNum, ushort stageID, byte difficult)
  {
    if (CrystalNum <= 0)
      return;
    GUIManager.Instance.OpenMenu(EGUIWindow.UI_ChallegeTreasure, CrystalNum, (int) stageID << 8 | (int) difficult, bSecWindow: true);
  }

  public void OpenChallegeRewardUI()
  {
    GUIManager.instance.UpdateUI(EGUIWindow.UI_ChallegeTreasure, 1000);
  }

  public EmojiUnit pullEmojiIcon(ushort iconid, byte defaultSpriteID = 0, bool isSpriteRenderer = false)
  {
    return this.EmojiManager != null ? this.EmojiManager.pullIcon(iconid, defaultSpriteID, isSpriteRenderer) : (EmojiUnit) null;
  }

  public void pushEmojiIcon(EmojiUnit inIcon)
  {
    if (this.EmojiManager == null)
      return;
    this.EmojiManager.pushIcon(inIcon);
  }

  public bool SetFastivalImage(byte packID, ushort imageID, Image TargetImage)
  {
    if (packID == (byte) 0)
      return false;
    if (!this.m_FastivalIconSet.ContainsKey(packID) && this.currentIconCount < this.m_FastivalIconSpriteAssets.Length)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.AppendFormat("Festival_icon_{0:000}", (object) packID);
      this.m_FastivalIconSpriteAssets[this.currentIconCount].InitialAsset(stringBuilder.ToString());
      if ((UnityEngine.Object) this.m_FastivalIconSpriteAssets[this.currentIconCount].GetMaterial() == (UnityEngine.Object) null)
        return false;
      this.m_FastivalIconSet.Add(packID, this.currentIconCount++);
    }
    int index;
    if (!this.m_FastivalIconSet.TryGetValue(packID, out index) || (UnityEngine.Object) TargetImage == (UnityEngine.Object) null)
      return false;
    ((MaskableGraphic) TargetImage).material = this.m_FastivalIconSpriteAssets[index].GetMaterial();
    TargetImage.sprite = this.m_FastivalIconSpriteAssets[index].LoadSprite(imageID);
    return true;
  }

  public void Free()
  {
    if (this.EmojiManager != null)
      this.EmojiManager.OnDestroy();
    this.EmojiManager = (EmojiCenter) null;
  }

  private enum eBBSetp
  {
    eMoveIn,
    eWait,
    eFadeOut,
    eMax,
  }

  public enum EQuickFightKind
  {
    EQFK_Normal = 1,
    EQFK_VIP = 2,
  }

  public enum EStageKind
  {
    ESK_Normal = 1,
    ESK_Advance = 2,
  }

  public enum ECombatLiveType : byte
  {
    ECLTR_ATTACK,
    ECLTR_UNDERATTACK,
    ECLTR_REINFORCE_UNDERATTACK,
    ECLTR_RALLYATTACK,
    ECLTR_AMBUSH_UNDERATTACK,
    ECLTR_WILDMONSTER,
    ECLTR_NPCCITY,
    ECLTR_PETATTACK,
    ECLTR_PETUNDERATTACK,
  }

  private enum EPetLiveType : byte
  {
    EPLTR_ATTACK,
    EPLTR_UNDERATTACK,
  }
}
