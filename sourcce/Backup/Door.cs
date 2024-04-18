// Decompiled with JetBrains decompiler
// Type: Door
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class Door : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler, IUTimeBarOnTimer
{
  private const byte FuncBtnCount = 6;
  private const float m_DuringTime = 10f;
  private const float m_AnimBtnTime = 0.2f;
  private const byte QueueMinCount = 1;
  private const int MoveDistance = 40;
  private List<GUIWindowStackData> _m_WindowStack;
  public EUIOriginMode m_eMode;
  public EUIOriginMapMode m_eMapMode;
  private Dictionary<int, Sprite> m_SpriteDict = new Dictionary<int, Sprite>();
  public RectTransform m_Background;
  public RectTransform m_BackBlock;
  public RectTransform m_AlertBlock;
  public RectTransform m_ChatBox;
  public RectTransform m_ChatScrollRectRC;
  private CScrollRect m_ChatScrollRect;
  private Image m_ChatChannelLight;
  private UISpritesArray m_BackBlockSA;
  private Image m_BackBlock_L;
  private Image m_BackBlock_R;
  private Image m_BackBlock_B;
  private Image m_AlertBlock_T;
  private Image m_AlertBlock_B;
  private Image m_AlertBlock_R;
  private Image m_AlertBlock_L;
  private RectTransform m_TerritoryPanel;
  public UIButton m_BattleButton;
  private RectTransform m_MapFuncPanel;
  private Image m_MapFuncBG;
  private UISpritesArray m_FullMapButton;
  public bool bHideMainMenu;
  private UIButton m_LocationBox;
  private Image m_LocationBoxBG;
  private Image m_LocationBoxIcon;
  private UIText m_LocationXText;
  private UIText m_LocationYText;
  private CString LocXStr;
  private CString LocYStr;
  private UIButton m_HomeButton;
  private UIText m_HomeDistText;
  private CString HomeStr;
  public ushort m_CapitalLocationX;
  public ushort m_CapitalLocationY;
  public ushort m_HomeLocationX;
  public ushort m_HomeLocationY;
  private bool bShowHomeBtn;
  private Vector2 HomeBtnPos = Vector2.zero;
  private Transform m_HomeArrowT;
  private Quaternion HomeArrowtarget = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
  private GameObject PVPTimeObj;
  private Image PVPWonderImg;
  private Material PVPWonderImgMaterial;
  private UIText PVPTimeText;
  private ushort PVPWonderID = 40;
  private CString PVPStr;
  private CString PVPTimeStr;
  private GameObject KVKTimeObj;
  private UISpritesArray KVKTimeSA;
  private UIText KVKTimeText;
  private CString KVKStr;
  private CString KVKTimeStr;
  private RectTransform m_ResourcePanel;
  public Image[] m_ResourceIcon;
  private Image[] m_ResourceBar;
  private UIText[] m_ResourceText;
  private CString[] m_ResourceStr;
  private Color[] m_ResourceColor;
  private Color ResourceSColor = new Color(1f, 0.925f, 0.529f);
  private float ResourceRedTime;
  private bool bResourceRed;
  public RectTransform m_TopLayer;
  private RectTransform m_FuncPanel;
  private UIButton m_FuncPanelBG;
  private Image m_FuncBG;
  private Image m_ShowFuncIcon;
  public CanvasGroup m_MapSwitchButton;
  private UISpritesArray m_MapSwitchImage;
  private Image m_MapSwitchImage2;
  public byte m_bShowFuncButton = 1;
  private byte m_bOldShowFuncButton;
  private float m_ShowFuncTime;
  private float m_FuncBGWidth;
  private float m_SFuncBGWidth;
  private float m_ShowFuncPosX;
  private byte FunButtonShowCount;
  public RectTransform[] m_SFuncRC;
  public CanvasGroup[] m_SFuncCG;
  private float[] m_SFuncPosX;
  public RectTransform[] m_FuncRC;
  public CanvasGroup[] m_FuncCG;
  public GameObject[] m_FuncLight;
  private float[] m_FuncPosX;
  private RectTransform[] m_FuncBtnCountRC;
  private UIText[] m_FuncBtnText;
  public int[] m_FuncBtnCount;
  private CString[] m_FuncBtnCountStr;
  private GameObject m_ShowFuncButton;
  private GameObject m_ShowFuncButtonAlert;
  private GameObject m_MissionAlert;
  private GameObject m_AllianceGift;
  private GameObject m_RallyRecFlash;
  private GameObject m_OtherGift;
  private GameObject m_MissionFlash;
  private GameObject m_OtherAlert;
  private bool bCanEquip;
  private bool bCanEvolutionStar;
  private bool bCanEvolutionRank;
  private bool bCanShowSkillPoint;
  public bool bCanRecruit;
  private Image SPGiftImgMain;
  private Image SPGiftImgAlly;
  private Image LiveImgMain;
  private Image LiveImgOther;
  private uTweenScale LiveImgMainTW;
  private uTweenScale LiveImgOtherTW;
  private uTweenAlpha LiveImgMainTWF;
  private uTweenAlpha LiveImgOtherTWF;
  public RectTransform m_RolePanel;
  public Image m_HeadImage;
  private UIButton m_HeadIcon;
  public UIButton m_VIPIcon;
  private UIText m_VipText;
  private CString m_VIPStr;
  public UIButton m_PowerBtn;
  private UIText m_Power;
  private CString m_PowerStr;
  private UIText m_Level;
  private CString m_LevelStr;
  private GameObject m_HeadBoxFlash;
  private GameObject m_HeadBoxJail;
  private RectTransform m_MoneyPanel;
  private UIButton m_DiamondBox;
  public Image m_DiamondIcon;
  private Image m_DiamondPlus;
  private UIText m_DiamondText;
  public UIButton m_MoraleBox;
  public Image m_MoraleIcon;
  public Image m_MoraleForceBlood;
  public Image m_MoraleFlash;
  private UISpritesArray m_MoraleSA;
  private UISpritesArray m_MoraleSA2;
  private UIButtonHint m_MoraleIconHint;
  private UIText m_MoraleText;
  private Image m_MoraleHintBox;
  private UIText m_MoraleHintText;
  private CString MoraleString;
  private CString DiamondString;
  private bool bMoraleHintOpen;
  private CString MoraleHintString;
  private long MoraleHintTime;
  private long MonsterTime;
  private uint ForceTime;
  private RectTransform m_AlertPanel;
  private UIButton m_AttackedAlert;
  private UISpritesArray m_AttackedAlertSA;
  private UISpritesArray m_AttackedAlertSA2;
  private UISpritesArray m_AttackedAlertBackSA;
  private UISpritesArray m_AttackedAlertBackSA2;
  private RectTransform m_AttackedAlertRC;
  private UIText m_AttackedAlertText;
  private CString m_AttackedAlertStr;
  private UIButton m_HelpAlert;
  private RectTransform m_HelpAlertRC;
  private UIText m_HelpAlertext;
  private CString m_HelpAlertStr;
  private GameObject m_HelpAlertImageGO;
  private UIText m_HelpAlertext2;
  private CString m_HelpAlertStr2;
  private Image m_HelpAlertL;
  private Image m_HelpAlertR;
  public UISpritesArray m_HelpAlertSA;
  private UISpritesArray m_AllianceFreeSA1;
  private UISpritesArray m_AllianceFreeSA2;
  private UIButton m_AllianceFree;
  private UIText m_AllianceFreetext;
  private UIButton m_TroopsBtn;
  private RectTransform m_TroopsRC;
  private UIText m_TroopsText;
  private CString m_TroopsAlertStr;
  public UIButton m_BuffBtn;
  public RectTransform m_BuffRC;
  public RectTransform m_BuffRC2;
  private UIText m_BuffText;
  private UIText m_BuffText2;
  private CString m_BuffAlertStr;
  private CString m_BuffAlertStr2;
  private UISpritesArray m_BuffSA;
  private float BuffRedTime;
  private float BuffTextTime;
  private bool bBuffRed;
  public Transform m_ActivityBtnT;
  public CanvasGroup m_ActivityBtnCG;
  public Image m_ActivityBtnImg;
  public UISpritesArray m_ActivityBackSA;
  public UIText m_ActivityTitleText;
  public UIText m_ActivityTimeText;
  public Image m_FlashKVKImg;
  public GameObject m_ActivityAlert;
  private GameObject m_TreasureBoxObject;
  private UIButton m_TreasureBox;
  private GameObject m_TreasureBoxFlash;
  private GameObject m_TreasureBoxFlash_5x;
  private UISpritesArray m_TreasureBoxSA;
  private uTweenPosition m_TreasureBoxPos;
  private uTweenScale m_TreasureBoxScale;
  private UIText m_TreasureBoxtext;
  private CString m_TreasureBoxStr;
  public Transform m_MissionHintTrans;
  private RectTransform m_MissionHintRC;
  private RectTransform m_MissionHintRRC;
  private UISpritesArray m_MissionHintSA;
  public UIButton m_MissionBtn;
  public uButtonScale m_MissionScale;
  private UIText m_MissionHinttextL;
  private UIText m_MissionHinttextR;
  private CString m_MissionHintStrR;
  private Image NewMissionReward;
  private float RewardTime;
  private float MaxRewardTime = 1f;
  private uTweenScale m_MissionBtnTS;
  private RectTransform m_MissionBtnRect;
  private float m_TickBeginAnimBtnTime = 10f;
  private float m_TickEndAnimBtnTime = 0.2f;
  public GameObject m_MallGO;
  public SpriteAnimation SpriteA;
  public GameObject m_MallImageGO;
  public UIText m_MallText;
  public CString m_MallStr;
  public GameObject m_DaBauBtnGO;
  public GameObject m_PetSkillBtnGO;
  public GameObject m_PetSkillBtnFlashGO;
  private RectTransform m_PetSkillCountRC;
  private UIText m_PetSkillText;
  private CString m_PetSkillStr;
  public UIRunningTextEX RunningText;
  private GameObject m_FBBtnGO;
  private UISpritesArray m_FBBtnSA;
  private RectTransform m_FBBtnCountRC;
  private UIText m_FBBtnCountText;
  private CString m_FBBtnCountStr;
  private GameObject m_FBBtnTimeGO;
  private UIText m_FBBtnTimeText;
  private CString m_FBBtnTimeStr;
  private GameObject m_FBBtnAlertGO;
  public bool m_FBTimeEnd;
  public byte m_FBUIType;
  private RectTransform m_SpTopPanel;
  public RectTransform m_ArrowRC;
  public uTweenPosition m_ArrowPos;
  private RectTransform m_TimeBarPanel;
  private RectTransform m_QueuePanel;
  public UITimeBar[] m_QueueTimeBar;
  private Image[] m_QueueTimeBarIcon;
  private byte m_QueueCount;
  private UIButton m_QueueButton;
  private Image m_QueueIcon;
  private RectTransform m_QueueCountBox;
  private UIText m_QueueCountText;
  private CString m_QueueCountStr;
  private bool bShowLoadingImg;
  private Transform LoadingImgT;
  public UIGroundInfo m_GroundInfo;
  private Animation FightButton;
  private AnimationState FightButtonAS;
  private AnimationState FightButtonAS_Touch;
  private SkinnedMeshRenderer FightButtonSMR;
  private float PlayFightTime;
  private float PlayTouchTime;
  private Vector3 Vec3 = Vector3.zero;
  private string FightName = "fight";
  private string TouchName = "touch";
  private int FightassetKey;
  public int MailPage;
  public MapTile TileMapController;
  private GameObject KingdomMarkGameObject;
  private UIText KingdomMarkText;
  private CString KingdomMarkString;
  private GameObject KVKTransBtnGO;
  private UISpritesArray KVKTransBtnSA;
  private UIText[] RBText = new UIText[2];
  private GameObject EffectObj;
  private float FadeInTime = 0.25f;
  private float FadeOutTime = 0.5f;
  private float FadeNowTime;
  private float FadeBeginAlpha;
  private byte FadeInOrOut;
  private CanvasGroup CGDoor;
  private CanvasGroup CGTop;
  private RectTransform m_iPhonePanel;
  private static readonly int[] MapEffectCanvasLayer = new int[3]
  {
    5,
    5,
    5
  };
  private Vector3 BackGroundMoved = new Vector3(0.0f, 0.0f, 0.0f);
  private bool isTrackBackGround;

  public List<GUIWindowStackData> m_WindowStack
  {
    get
    {
      if (this._m_WindowStack == null)
        this._m_WindowStack = GUIManager.Instance.m_WindowStack;
      return this._m_WindowStack;
    }
  }

  public bool OpenMenu(EGUIWindow eWin, int arg1 = 0, int arg2 = 0, bool bCameraMode = false)
  {
    this.SetDefaultFadeAlpha();
    GUIManager.Instance.m_SpeciallyEffect.ClearAllEffect();
    GUIManager instance = GUIManager.Instance;
    this.ReSetPressPosition();
    if ((UnityEngine.Object) instance.FindMenu(eWin) != (UnityEngine.Object) null)
    {
      if (!((UnityEngine.Object) instance.m_Chat != (UnityEngine.Object) null) || !instance.m_Chat.activeInHierarchy)
        return false;
      instance.CloseMenu(instance.Chatwin.m_eWindow);
      GUIWindowStackData guiWindowStackData;
      guiWindowStackData.m_eWindow = eWin;
      guiWindowStackData.m_Arg1 = arg1;
      guiWindowStackData.m_Arg2 = arg2;
      guiWindowStackData.bCameraMode = bCameraMode;
      this.m_WindowStack.Add(guiWindowStackData);
      return true;
    }
    if ((UnityEngine.Object) GUIManager.Instance.OpenMenu(eWin, arg1, arg2, bCameraMode, bFromDoor: true) == (UnityEngine.Object) null)
      return false;
    GUIWindowStackData guiWindowStackData1;
    guiWindowStackData1.m_eWindow = eWin;
    if (eWin == EGUIWindow.UI_Chat || eWin == EGUIWindow.UI_MessageBoard)
      arg1 = 0;
    guiWindowStackData1.m_Arg1 = arg1;
    guiWindowStackData1.m_Arg2 = arg2;
    guiWindowStackData1.bCameraMode = bCameraMode;
    this.m_WindowStack.Add(guiWindowStackData1);
    if (GUIManager.Instance.bOpenNeedClose)
    {
      GUIManager.Instance.bOpenNeedClose = false;
      this.CloseMenu();
      return false;
    }
    if (this.m_eMapMode == EUIOriginMapMode.KingdomMap)
    {
      if (eWin != EGUIWindow.UI_MapMonster)
      {
        DataManager.msgBuffer[0] = (byte) 84;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      }
    }
    else if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
    {
      DataManager.msgBuffer[0] = (byte) 115;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
    return true;
  }

  public void CloseMenu(bool bClear = false)
  {
    GUIManager.Instance.m_SpeciallyEffect.ClearAllEffect();
    if (this.m_WindowStack.Count == 0)
      return;
    GUIManager.Instance.HideArrow();
    EGUIWindow eWindow = this.m_WindowStack[this.m_WindowStack.Count - 1].m_eWindow;
    if (bClear)
    {
      for (int index = this.m_WindowStack.Count - 1; index > -1; --index)
        GUIManager.Instance.CloseMenu(this.m_WindowStack[index].m_eWindow);
      this.m_WindowStack.Clear();
      GUIManager.Instance.bClearWindowStack = bClear;
    }
    else
    {
      GUIManager.Instance.CloseMenu(eWindow);
      this.m_WindowStack.RemoveAt(this.m_WindowStack.Count - 1);
    }
    if (this.m_WindowStack.Count == 0)
    {
      if (this.m_eMapMode == EUIOriginMapMode.KingdomMap)
      {
        DataManager.msgBuffer[0] = (byte) 85;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      }
      else if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
      {
        DataManager.msgBuffer[0] = (byte) 116;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      }
      this.SwitchMode(EUIOriginMode.Show);
    }
    else
    {
      this.HideFightButton();
      if ((UnityEngine.Object) GUIManager.Instance.m_Window2 == (UnityEngine.Object) null || eWindow != EGUIWindow.UI_Chat)
      {
        GUIManager.Instance.OpenMenu(this.m_WindowStack[this.m_WindowStack.Count - 1].m_eWindow, this.m_WindowStack[this.m_WindowStack.Count - 1].m_Arg1, this.m_WindowStack[this.m_WindowStack.Count - 1].m_Arg2, this.m_WindowStack[this.m_WindowStack.Count - 1].bCameraMode);
        if (!GUIManager.Instance.bOpenNeedClose)
          return;
        GUIManager.Instance.bOpenNeedClose = false;
        this.CloseMenu();
      }
      else
        GUIManager.Instance.m_Window2.ReOnOpen();
    }
  }

  public void ClearWindowStack()
  {
    GUIManager.Instance.m_SpeciallyEffect.ClearAllEffect();
    if (this.m_WindowStack.Count <= 0)
      return;
    bool flag = false;
    for (int index = 0; index < this.m_WindowStack.Count; ++index)
    {
      if (this.m_WindowStack[index].m_eWindow == EGUIWindow.UI_StageSelect || this.m_WindowStack[index].m_eWindow == EGUIWindow.UI_StageSelect2)
      {
        GUIWindowStackData guiWindowStackData;
        guiWindowStackData.m_eWindow = this.m_WindowStack[index].m_eWindow;
        guiWindowStackData.m_Arg1 = this.m_WindowStack[index].m_Arg1;
        guiWindowStackData.m_Arg2 = this.m_WindowStack[index].m_Arg2;
        guiWindowStackData.bCameraMode = this.m_WindowStack[index].bCameraMode;
        this.m_WindowStack.Clear();
        this.m_WindowStack.Add(guiWindowStackData);
        flag = true;
        break;
      }
    }
    if (flag)
      return;
    this.m_WindowStack.Clear();
  }

  public void ClearWindowStack(EGUIWindow SaveA, EGUIWindow SaveB = EGUIWindow.MAX)
  {
    GUIManager.Instance.m_SpeciallyEffect.ClearAllEffect();
    if (this.m_WindowStack.Count <= 0)
      return;
    GUIWindowStackData guiWindowStackData1 = new GUIWindowStackData();
    GUIWindowStackData guiWindowStackData2 = new GUIWindowStackData();
    GUIWindowStackData guiWindowStackData3 = new GUIWindowStackData();
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = false;
    for (int index = 0; index < this.m_WindowStack.Count; ++index)
    {
      if (!flag1 && (this.m_WindowStack[index].m_eWindow == EGUIWindow.UI_StageSelect || this.m_WindowStack[index].m_eWindow == EGUIWindow.UI_StageSelect2))
      {
        guiWindowStackData1 = this.m_WindowStack[index];
        flag1 = true;
      }
      else if (SaveA != EGUIWindow.MAX && !flag2 && this.m_WindowStack[index].m_eWindow == SaveA)
      {
        guiWindowStackData2 = this.m_WindowStack[index];
        flag2 = true;
      }
      else if (SaveB != EGUIWindow.MAX && !flag3 && this.m_WindowStack[index].m_eWindow == SaveB)
      {
        guiWindowStackData3 = this.m_WindowStack[index];
        flag3 = true;
      }
      if (flag1 && flag2 && flag3)
        break;
    }
    this.m_WindowStack.Clear();
    if (flag1)
      this.m_WindowStack.Add(guiWindowStackData1);
    if (flag2)
      this.m_WindowStack.Add(guiWindowStackData2);
    if (!flag3)
      return;
    this.m_WindowStack.Add(guiWindowStackData3);
  }

  public void CloseMenu_Alliance(EGUIWindow Target)
  {
    GUIManager instance = GUIManager.Instance;
    if ((bool) (UnityEngine.Object) instance.FindMenu(EGUIWindow.UI_Chat))
    {
      if (instance.m_WindowStack.Count >= 2)
        instance.m_WindowStack.RemoveAt(instance.m_WindowStack.Count - 2);
      instance.CloseMenu(Target);
    }
    else
      this.CloseMenu();
  }

  public void SwitchMode(EUIOriginMode eMode)
  {
    Vector2 pos = Vector2.zero;
    Vector3 zero = Vector3.zero;
    switch (this.m_eMode)
    {
      case EUIOriginMode.Show:
        Camera.main.cullingMask &= -2;
        GUIManager.Instance.m_UICanvas.renderMode = (RenderMode) 0;
        GUIManager.Instance.SetCameraorthOgraphic(true);
        ((Component) this.m_Background).gameObject.SetActive(true);
        if (this.bHideMainMenu)
          this.SwitchFullMap(true);
        if (this.m_GroundInfo != null)
          this.m_GroundInfo.Close();
        pos.Set(144f, this.m_ChatBox.offsetMin.y);
        this.m_ChatBox.offsetMin = pos;
        pos.Set(-95f, this.m_ChatBox.offsetMax.y);
        this.m_ChatBox.offsetMax = pos;
        this.m_ChatScrollRect.ChangePageWidth(this.m_ChatScrollRectRC.rect.width);
        pos.Set(-9f, 4f);
        ((Graphic) this.m_ChatChannelLight).rectTransform.anchoredPosition = pos;
        if (GUIManager.Instance.IsArabic)
        {
          for (int index = 0; index < ((Transform) this.m_ChatScrollRect.content).childCount; ++index)
          {
            ((Transform) this.m_ChatScrollRect.content).GetChild(index).GetChild(2).GetComponent<UIText>().UpdateArabicPos();
            ((Transform) this.m_ChatScrollRect.content).GetChild(index).GetChild(3).GetComponent<UIText>().UpdateArabicPos();
          }
        }
        RectTransform transform1 = (RectTransform) ((Component) this.m_DiamondBox).transform;
        pos.Set(63.5f, -16f);
        transform1.anchoredPosition = pos;
        pos.Set((float) sbyte.MaxValue, 32f);
        transform1.sizeDelta = pos;
        pos.Set(18f, -16f);
        ((Graphic) this.m_DiamondIcon).rectTransform.anchoredPosition = pos;
        zero.Set(0.84f, 0.84f, 0.84f);
        ((Transform) ((Graphic) this.m_DiamondIcon).rectTransform).localScale = zero;
        pos.Set(33.9f, 2f);
        pos = this.m_DiamondText.ArabicFixPos(pos);
        ((Graphic) this.m_DiamondText).rectTransform.anchoredPosition = pos;
        pos.Set(122.9f, -15.5f);
        ((Graphic) this.m_DiamondPlus).rectTransform.anchoredPosition = pos;
        zero.Set(0.8f, 0.8f, 1f);
        ((Transform) ((Graphic) this.m_DiamondPlus).rectTransform).localScale = zero;
        RectTransform transform2 = (RectTransform) ((Component) this.m_MoraleBox).transform;
        pos.Set(62.5f, -48f);
        transform2.anchoredPosition = pos;
        pos.Set(125f, 32f);
        transform2.sizeDelta = pos;
        pos.Set(18f, -14.1f);
        ((Graphic) this.m_MoraleIcon).rectTransform.anchoredPosition = pos;
        zero.Set(0.84f, 0.84f, 0.84f);
        ((Transform) ((Graphic) this.m_MoraleIcon).rectTransform).localScale = zero;
        pos.Set(34.5f, 2.5f);
        pos = this.m_MoraleText.ArabicFixPos(pos);
        ((Graphic) this.m_MoraleText).rectTransform.anchoredPosition = pos;
        break;
      case EUIOriginMode.Hide:
        ((Component) this.m_ChatBox).gameObject.SetActive(true);
        ((Component) this.m_FuncPanel).gameObject.SetActive(true);
        ((Component) this.m_MoneyPanel).gameObject.SetActive(true);
        ((Component) this.m_SpTopPanel).gameObject.SetActive(true);
        break;
      case EUIOriginMode.MoneyAndFuncButton:
      case EUIOriginMode.MoneyAndFuncButtonWM:
      case EUIOriginMode.MoneyAndFuncButtonF:
      case EUIOriginMode.MoneyAndFuncButtonAndScene:
        if (this.m_eMode == EUIOriginMode.MoneyAndFuncButtonAndScene)
        {
          Camera.main.cullingMask &= -2;
          GUIManager.Instance.SetCameraorthOgraphic(true);
          ((Component) this.m_Background).gameObject.SetActive(true);
        }
        this.ShowFuncButton(this.m_bOldShowFuncButton == (byte) 1);
        break;
      case EUIOriginMode.Money:
      case EUIOriginMode.MoneyF:
        ((Component) this.m_FuncPanel).gameObject.SetActive(true);
        break;
      case EUIOriginMode.FuncButton:
        this.ShowFuncButton(this.m_bOldShowFuncButton == (byte) 1);
        ((Component) this.m_MoneyPanel).gameObject.SetActive(true);
        ((Component) this.m_SpTopPanel).gameObject.SetActive(true);
        break;
      case EUIOriginMode.FuncButtonWithoutChatBox:
        this.ShowFuncButton(this.m_bOldShowFuncButton == (byte) 1);
        ((Component) this.m_ChatBox).gameObject.SetActive(true);
        ((Component) this.m_MoneyPanel).gameObject.SetActive(true);
        ((Component) this.m_SpTopPanel).gameObject.SetActive(true);
        break;
    }
    switch (eMode)
    {
      case EUIOriginMode.Show:
        Camera.main.cullingMask |= 1;
        GUIManager.Instance.m_UICanvas.renderMode = (RenderMode) 1;
        if (this.m_eMapMode == EUIOriginMapMode.KingdomMap)
        {
          DataManager.msgBuffer[0] = (byte) 71;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
        GUIManager.Instance.SetCameraorthOgraphic(false);
        ((Component) this.m_Background).gameObject.SetActive(false);
        pos.Set(267f, this.m_ChatBox.offsetMin.y);
        this.m_ChatBox.offsetMin = pos;
        pos.Set(-152f, this.m_ChatBox.offsetMax.y);
        this.m_ChatBox.offsetMax = pos;
        this.m_ChatScrollRect.ChangePageWidth(this.m_ChatScrollRectRC.rect.width);
        pos.Set(-11f, 4f);
        ((Graphic) this.m_ChatChannelLight).rectTransform.anchoredPosition = pos;
        if (GUIManager.Instance.IsArabic)
        {
          for (int index = 0; index < ((Transform) this.m_ChatScrollRect.content).childCount; ++index)
          {
            ((Transform) this.m_ChatScrollRect.content).GetChild(index).GetChild(2).GetComponent<UIText>().UpdateArabicPos();
            ((Transform) this.m_ChatScrollRect.content).GetChild(index).GetChild(3).GetComponent<UIText>().UpdateArabicPos();
          }
        }
        RectTransform transform3 = (RectTransform) ((Component) this.m_DiamondBox).transform;
        pos.Set(174f, -52.5f);
        transform3.anchoredPosition = pos;
        pos.Set(142f, 41f);
        transform3.sizeDelta = pos;
        pos.Set(20.3f, -21.7f);
        ((Graphic) this.m_DiamondIcon).rectTransform.anchoredPosition = pos;
        ((Transform) ((Graphic) this.m_DiamondIcon).rectTransform).localScale = Vector3.one;
        pos.Set(41.4f, -3.3f);
        pos = this.m_DiamondText.ArabicFixPos(pos);
        ((Graphic) this.m_DiamondText).rectTransform.anchoredPosition = pos;
        pos.Set(238.5f, -53f);
        ((Graphic) this.m_DiamondPlus).rectTransform.anchoredPosition = pos;
        ((Transform) ((Graphic) this.m_DiamondPlus).rectTransform).localScale = Vector3.one;
        RectTransform transform4 = (RectTransform) ((Component) this.m_MoraleBox).transform;
        pos.Set(170.5f, -91.5f);
        transform4.anchoredPosition = pos;
        pos.Set(135f, 37f);
        transform4.sizeDelta = pos;
        pos.Set(20.6f, -17f);
        ((Graphic) this.m_MoraleIcon).rectTransform.anchoredPosition = pos;
        ((Transform) ((Graphic) this.m_MoraleIcon).rectTransform).localScale = Vector3.one;
        pos.Set(41.6f, 0.0f);
        pos = this.m_MoraleText.ArabicFixPos(pos);
        ((Graphic) this.m_MoraleText).rectTransform.anchoredPosition = pos;
        break;
      case EUIOriginMode.Hide:
        ((Component) this.m_ChatBox).gameObject.SetActive(false);
        ((Component) this.m_FuncPanel).gameObject.SetActive(false);
        ((Component) this.m_MoneyPanel).gameObject.SetActive(false);
        ((Component) this.m_SpTopPanel).gameObject.SetActive(false);
        break;
      case EUIOriginMode.MoneyAndFuncButton:
      case EUIOriginMode.MoneyAndFuncButtonWM:
      case EUIOriginMode.MoneyAndFuncButtonF:
      case EUIOriginMode.MoneyAndFuncButtonAndScene:
        if (eMode == EUIOriginMode.MoneyAndFuncButtonAndScene)
        {
          Camera.main.cullingMask |= 1;
          GUIManager.Instance.SetCameraorthOgraphic(false);
          ((Component) this.m_Background).gameObject.SetActive(false);
        }
        this.m_bOldShowFuncButton = this.m_bShowFuncButton == (byte) 1 || this.m_bShowFuncButton == (byte) 2 ? (byte) 1 : (byte) 0;
        this.ShowFuncButton(false);
        break;
      case EUIOriginMode.Money:
      case EUIOriginMode.MoneyF:
        ((Component) this.m_FuncPanel).gameObject.SetActive(false);
        break;
      case EUIOriginMode.FuncButton:
        this.m_bOldShowFuncButton = this.m_bShowFuncButton == (byte) 1 || this.m_bShowFuncButton == (byte) 2 ? (byte) 1 : (byte) 0;
        this.ShowFuncButton(false);
        ((Component) this.m_MoneyPanel).gameObject.SetActive(false);
        ((Component) this.m_SpTopPanel).gameObject.SetActive(false);
        break;
      case EUIOriginMode.FuncButtonWithoutChatBox:
        this.m_bOldShowFuncButton = this.m_bShowFuncButton == (byte) 1 || this.m_bShowFuncButton == (byte) 2 ? (byte) 1 : (byte) 0;
        this.ShowFuncButton(false);
        ((Component) this.m_ChatBox).gameObject.SetActive(false);
        ((Component) this.m_MoneyPanel).gameObject.SetActive(false);
        ((Component) this.m_SpTopPanel).gameObject.SetActive(false);
        break;
    }
    GUIManager.Instance.UpdateChatBox(0);
    ((Component) this.m_FuncPanelBG).gameObject.SetActive(false);
    this.m_eMode = eMode;
    this.SwitchMapMode(this.m_eMapMode);
    GUIManager.Instance.CheckBattleMessageSize(eMode == EUIOriginMode.Show);
  }

  public void SwitchMapMode(EUIOriginMapMode eMode)
  {
    bool flag = this.m_eMode == EUIOriginMode.Show;
    Vector2 zero = Vector2.zero;
    if (eMode != EUIOriginMapMode.OriginMap)
    {
      Camera.main.transform.position = new Vector3(0.0f, 0.0f, -16f);
      Camera.main.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
      GUIManager.Instance.SetCameraorthOgraphic(true);
      ((Component) this.m_TerritoryPanel).gameObject.SetActive(false);
      ((Component) this.m_MapFuncPanel).gameObject.SetActive(flag);
      if (flag)
      {
        this.HideFightButton();
        if (eMode == EUIOriginMapMode.WorldMap)
          this.m_MapSwitchImage.SetSpriteIndex(1);
        else
          this.m_MapSwitchImage.SetSpriteIndex(0);
      }
      else
        this.m_MapSwitchImage.SetSpriteIndex(1);
      this.m_GroundInfo.bOpenPvePanel = false;
      this.m_MissionHintTrans.gameObject.SetActive(false);
      this.m_BackBlockSA.SetSpriteIndex(0);
      ((Component) this.m_BackBlock).gameObject.SetActive(flag);
    }
    else
    {
      if (this.m_eMapMode != EUIOriginMapMode.OriginMap)
        GUIManager.Instance.SetCameraorthOgraphic(false);
      ((Component) this.m_TerritoryPanel).gameObject.SetActive(flag);
      ((Component) this.m_MapFuncPanel).gameObject.SetActive(false);
      if (flag)
      {
        this.m_MapSwitchImage.SetSpriteIndex(1);
        DataManager.msgBuffer[0] = (byte) 48;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      }
      else
      {
        this.m_MapSwitchImage.SetSpriteIndex(0);
        if (this.m_eMode != EUIOriginMode.MoneyAndFuncButtonAndScene)
        {
          DataManager.msgBuffer[0] = (byte) 49;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
        else
        {
          DataManager.msgBuffer[0] = (byte) 48;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
      }
      this.m_MissionHintTrans.gameObject.SetActive(DataManager.Instance.MySysSetting.bShowMission);
      this.m_BackBlockSA.SetSpriteIndex(1);
      ((Component) this.m_BackBlock).gameObject.SetActive(flag);
    }
    ((Component) this.m_MapSwitchButton).gameObject.SetActive(flag);
    if (this.m_MapSwitchImage.m_SpriteIndex == 1)
    {
      zero.Set(18f, 6f);
      ((RectTransform) this.m_MapSwitchImage.transform).anchoredPosition = zero;
      this.m_MapSwitchImage.m_Image.SetNativeSize();
    }
    else
    {
      zero.Set(16f, 28f);
      ((RectTransform) this.m_MapSwitchImage.transform).anchoredPosition = zero;
      this.m_MapSwitchImage.m_Image.SetNativeSize();
    }
    ((Component) this.m_RolePanel).gameObject.SetActive(flag);
    ((Component) this.m_ResourcePanel).gameObject.SetActive(flag);
    ((Component) this.m_AlertPanel).gameObject.SetActive(flag);
    ((Component) this.m_TimeBarPanel).gameObject.SetActive(flag || this.m_eMode == EUIOriginMode.MoneyAndFuncButtonAndScene);
    if (this.m_eMode == EUIOriginMode.MoneyAndFuncButtonAndScene)
    {
      this.m_TimeBarPanel.offsetMax = new Vector2(0.0f, 65f);
      this.ForceQueueBarOpenClose(false);
    }
    else
      this.m_TimeBarPanel.offsetMax = Vector2.zero;
    this.m_eMapMode = eMode;
    this.UpdateMissionInfo();
    this.CheckSetShowActivityBtn();
    this.CheckShowMallBtn();
    this.UpdateMoney();
    this.CheckTreasureBoxState();
    this.ChecNeedForceOpenFuncBtn();
    this.CheckShowDaBauBtn();
    this.CheckFBBtn();
    if (eMode == EUIOriginMapMode.OriginMap || eMode == EUIOriginMapMode.WorldMap)
      this.ClearPVPWonderID();
    if (this.m_eMode == EUIOriginMode.Show)
      this.SwitchFullMap();
    NewbieManager.EntryTest();
    Indemnify.CheckShowIndemnify();
    ActivityGiftManager.Instance.CheckShowActivityGiftEffect();
  }

  private void SwitchFullMap(bool ForceShow = false)
  {
    bool flag = !this.bHideMainMenu || ForceShow;
    Vector2 zero = Vector2.zero;
    ((Component) this.m_FuncPanel).gameObject.SetActive(flag);
    ((Component) this.m_ChatBox).gameObject.SetActive(flag);
    ((Component) this.m_RolePanel).gameObject.SetActive(flag);
    ((Component) this.m_MoneyPanel).gameObject.SetActive(flag);
    ((Component) this.m_SpTopPanel).gameObject.SetActive(flag);
    ((Component) this.m_ResourcePanel).gameObject.SetActive(flag);
    ((Component) this.m_AlertPanel).gameObject.SetActive(flag);
    ((Component) this.m_TimeBarPanel).gameObject.SetActive(flag);
    if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
    {
      ((Transform) this.m_MapFuncPanel).GetChild(1).gameObject.SetActive(false);
      ((Transform) this.m_MapFuncPanel).GetChild(2).gameObject.SetActive(false);
      ((Transform) this.m_MapFuncPanel).GetChild(3).gameObject.SetActive(false);
      ((Behaviour) this.m_LocationBoxBG).enabled = false;
      ((Graphic) this.m_LocationBoxIcon).rectTransform.anchoredPosition = new Vector2(106f, 6f);
      ((Component) this.m_LocationBox).transform.GetChild(1).gameObject.SetActive(false);
      ((Component) this.m_LocationBox).transform.GetChild(2).gameObject.SetActive(false);
    }
    else
    {
      ((Transform) this.m_MapFuncPanel).GetChild(1).gameObject.SetActive(flag);
      ((Transform) this.m_MapFuncPanel).GetChild(2).gameObject.SetActive(true);
      ((Transform) this.m_MapFuncPanel).GetChild(3).gameObject.SetActive(flag);
      ((Behaviour) this.m_LocationBoxBG).enabled = true;
      ((Graphic) this.m_LocationBoxIcon).rectTransform.anchoredPosition = new Vector2(15f, 6f);
      ((Component) this.m_LocationBox).transform.GetChild(1).gameObject.SetActive(true);
      ((Component) this.m_LocationBox).transform.GetChild(2).gameObject.SetActive(true);
      if (!flag)
        this.ShowPVPTime();
      else
        this.HidePVPTime();
    }
    if (!flag)
      this.ShowKVKTime();
    else
      this.HideKVKTime();
    if (flag)
    {
      this.m_FullMapButton.SetSpriteIndex(0);
      if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
        zero.Set(51f, 53f);
      else
        zero.Set(51f, 210f);
      ((Graphic) this.m_MapFuncBG).rectTransform.sizeDelta = zero;
      RectTransform transform1 = (RectTransform) ((Component) this.m_LocationBox).transform;
      zero.Set(55f, -71f);
      transform1.anchoredPosition = zero;
      RectTransform child = (RectTransform) ((Transform) this.m_MapFuncPanel).GetChild(2);
      zero.Set(179.8f, -83.9f);
      child.anchoredPosition = zero;
      RectTransform transform2 = (RectTransform) ((Component) this.m_HomeButton).transform;
      zero.Set(-182f, -201.5f);
      transform2.anchoredPosition = zero;
      if (GUIManager.Instance.bOpenOnIPhoneX)
      {
        ((Component) this.m_iPhonePanel).gameObject.SetActive(true);
        ((Behaviour) this.m_BackBlock_L).enabled = false;
        ((Behaviour) this.m_BackBlock_R).enabled = false;
      }
      else
      {
        ((Behaviour) this.m_BackBlock_L).enabled = true;
        ((Behaviour) this.m_BackBlock_R).enabled = true;
      }
      ((Behaviour) this.m_BackBlock_B).enabled = true;
    }
    else
    {
      this.m_FullMapButton.SetSpriteIndex(1);
      zero.Set(51f, 53f);
      ((Graphic) this.m_MapFuncBG).rectTransform.sizeDelta = zero;
      RectTransform transform3 = (RectTransform) ((Component) this.m_LocationBox).transform;
      zero.Set(55f, -8f);
      transform3.anchoredPosition = zero;
      RectTransform child = (RectTransform) ((Transform) this.m_MapFuncPanel).GetChild(2);
      zero.Set(179.8f, -20.9f);
      child.anchoredPosition = zero;
      RectTransform transform4 = (RectTransform) ((Component) this.m_HomeButton).transform;
      zero.Set(-55f, -64f);
      transform4.anchoredPosition = zero;
      ((Behaviour) this.m_BackBlock_L).enabled = false;
      ((Behaviour) this.m_BackBlock_R).enabled = false;
      ((Behaviour) this.m_BackBlock_B).enabled = false;
      if (GUIManager.Instance.bOpenOnIPhoneX)
        ((Component) this.m_iPhonePanel).gameObject.SetActive(false);
    }
    if (this.m_eMapMode == EUIOriginMapMode.OriginMap)
      return;
    this.notifyHomeBtnPos();
  }

  public void CheckSetShowActivityBtn()
  {
    if (ActivityManager.Instance.bCastleLevel && this.m_eMapMode == EUIOriginMapMode.OriginMap)
      this.m_ActivityBtnT.gameObject.SetActive(true);
    else
      this.m_ActivityBtnT.gameObject.SetActive(false);
  }

  public void CheckShowMallBtn()
  {
    if (this.m_eMapMode == EUIOriginMapMode.OriginMap)
      this.m_MallGO.SetActive(true);
    else
      this.m_MallGO.SetActive(false);
  }

  public void CheckShowDaBauBtn()
  {
    if (this.m_eMode == EUIOriginMode.Show && this.m_eMapMode == EUIOriginMapMode.OriginMap && Indemnify.UIStatus == INDEMNIFY_STATE.ShowButton)
      this.m_DaBauBtnGO.SetActive(true);
    else
      this.m_DaBauBtnGO.SetActive(false);
  }

  public void CheckMonthBtn()
  {
  }

  public Sprite LoadSprite(string SpriteName)
  {
    Sprite sprite;
    this.m_SpriteDict.TryGetValue(SpriteName.GetHashCode(), out sprite);
    return sprite;
  }

  public Sprite LoadSprite(CString SpriteName)
  {
    Sprite sprite;
    this.m_SpriteDict.TryGetValue(SpriteName.GetHashCode(false), out sprite);
    return sprite;
  }

  public Material LoadMaterial()
  {
    return this.m_AssetBundle.Load("UI_main_m", typeof (Material)) as Material;
  }

  public void SetPointTexture(byte point, Image numImg)
  {
    if (point == byte.MaxValue)
    {
      numImg.sprite = this.LoadSprite("UI_mall_x_001");
    }
    else
    {
      CString SpriteName = StringManager.Instance.StaticString1024();
      SpriteName.IntToFormat((long) point);
      SpriteName.AppendFormat("UI_mall_{0}_001");
      numImg.sprite = this.LoadSprite(SpriteName);
    }
    ((MaskableGraphic) numImg).material = this.LoadMaterial();
  }

  public void LoadMainEff(EMapEffectKind kind)
  {
    bool flag = (ActivityManager.Instance.bSpecialMonsterTreasureEvent & 8UL) > 0UL;
    if (!flag && (UnityEngine.Object) this.EffectObj != (UnityEngine.Object) null && kind != EMapEffectKind.WORLDWAR)
    {
      ParticleManager.Instance.DeSpawn(this.EffectObj);
      this.EffectObj = (GameObject) null;
    }
    else
    {
      if ((UnityEngine.Object) this.EffectObj != (UnityEngine.Object) null)
        return;
      MapEffect recordByIndex = DataManager.Instance.MapEffectTB.GetRecordByIndex((int) kind);
      switch (kind)
      {
        case EMapEffectKind.ORIGIN:
          this.EffectObj = !flag ? (GameObject) null : ParticleManager.Instance.Spawn(recordByIndex.EffectID, (Transform) this.m_RolePanel, Vector3.zero, 11f / 16f, true);
          break;
        case EMapEffectKind.CHAOS:
          this.EffectObj = !flag ? (GameObject) null : ParticleManager.Instance.Spawn(recordByIndex.EffectID, (Transform) this.m_MapFuncPanel, Vector3.zero, 85.33334f, true);
          break;
        default:
          this.EffectObj = ParticleManager.Instance.Spawn(recordByIndex.EffectID, (Transform) this.m_MapFuncPanel, Vector3.zero, 85.33334f, true);
          break;
      }
      if ((UnityEngine.Object) this.EffectObj != (UnityEngine.Object) null)
      {
        GUIManager.Instance.SetLayer(this.EffectObj, Door.MapEffectCanvasLayer[(int) kind]);
        this.EffectObj.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        this.EffectObj.transform.localPosition = Vector3.zero with
        {
          x = (float) ((double) recordByIndex.PosX * 0.0099999997764825821 * (recordByIndex.PosX_Sign != (byte) 0 ? -1.0 : 1.0)),
          y = (float) ((double) recordByIndex.PosY * 0.0099999997764825821 * (recordByIndex.PosY_Sign != (byte) 0 ? -1.0 : 1.0)),
          z = (float) ((double) recordByIndex.PosZ * 0.0099999997764825821 * (recordByIndex.PosZ_Sign != (byte) 0 ? -1.0 : 1.0))
        };
      }
      if (!((UnityEngine.Object) this.EffectObj != (UnityEngine.Object) null))
        return;
      this.EffectObj.SetActive(false);
      this.EffectObj.SetActive(true);
    }
  }

  public void RefreshMainEff()
  {
    if (this.m_eMapMode == EUIOriginMapMode.OriginMap)
    {
      this.LoadMainEff(EMapEffectKind.ORIGIN);
    }
    else
    {
      if (this.m_eMapMode != EUIOriginMapMode.KingdomMap)
        return;
      if (DataManager.MapDataController.FocusKingdomPeriod != KINGDOM_PERIOD.KP_WORLD_WAR)
        this.LoadMainEff(EMapEffectKind.CHAOS);
      else
        this.LoadMainEff(EMapEffectKind.WORLDWAR);
    }
  }

  public void DeSpawnMainEff()
  {
    if (!((UnityEngine.Object) this.EffectObj != (UnityEngine.Object) null))
      return;
    ParticleManager.Instance.DeSpawn(this.EffectObj);
    this.EffectObj = (GameObject) null;
  }

  public override void OnOpen(int arg1, int arg2)
  {
    // ISSUE: unable to decompile the method.
  }

  public override void OnClose()
  {
    StringManager instance = StringManager.Instance;
    ((Transform) this.m_TopLayer).SetParent(this.transform, false);
    Camera.main.cullingMask |= 1;
    Camera.main.orthographic = false;
    if (this.m_GroundInfo != null)
    {
      this.m_GroundInfo.Unload();
      this.m_GroundInfo = (UIGroundInfo) null;
    }
    for (int index = 0; index < 5; ++index)
      instance.DeSpawnString(this.m_ResourceStr[index]);
    for (int index = 0; index < 6; ++index)
      instance.DeSpawnString(this.m_FuncBtnCountStr[index]);
    instance.DeSpawnString(this.MoraleString);
    instance.DeSpawnString(this.DiamondString);
    instance.DeSpawnString(this.m_TroopsAlertStr);
    instance.DeSpawnString(this.m_HelpAlertStr);
    instance.DeSpawnString(this.m_HelpAlertStr2);
    instance.DeSpawnString(this.MoraleHintString);
    instance.DeSpawnString(this.m_VIPStr);
    instance.DeSpawnString(this.m_PowerStr);
    instance.DeSpawnString(this.m_LevelStr);
    instance.DeSpawnString(this.m_QueueCountStr);
    instance.DeSpawnString(this.m_MissionHintStrR);
    instance.DeSpawnString(this.LocXStr);
    instance.DeSpawnString(this.LocYStr);
    instance.DeSpawnString(this.m_BuffAlertStr);
    instance.DeSpawnString(this.m_BuffAlertStr2);
    instance.DeSpawnString(this.KingdomMarkString);
    instance.DeSpawnString(this.PVPStr);
    instance.DeSpawnString(this.PVPTimeStr);
    instance.DeSpawnString(this.KVKTimeStr);
    instance.DeSpawnString(this.m_MallStr);
    instance.DeSpawnString(this.m_PetSkillStr);
    instance.DeSpawnString(this.m_FBBtnCountStr);
    instance.DeSpawnString(this.m_FBBtnTimeStr);
    for (int index = 0; index < (int) this.m_QueueCount && index < this.m_QueueTimeBar.Length; ++index)
    {
      if (this.m_QueueTimeBar[index].m_ListID != 0)
        GUIManager.Instance.RemoverTimeBaarToList(this.m_QueueTimeBar[index]);
    }
    GUIManager.Instance.DoorCloseChatBox();
    ActivityManager.Instance.door = (Door) null;
    GUIManager.Instance.m_ItemInfo.DestroySlider();
    if (!GUIManager.Instance.bOpenOnIPhoneX)
      return;
    ((Transform) this.m_BackBlock).SetParent(this.transform, false);
    ((Transform) this.m_BackBlock).SetAsFirstSibling();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch ((byte) arg1)
    {
      case 1:
        this.SwitchMode((EUIOriginMode) arg2);
        break;
      case 2:
        if (DataManager.MapDataController.gotoKingdomState == byte.MaxValue)
        {
          this.CloseMenu(this.m_WindowStack.Count > 0);
          DataManager.MapDataController.gotoKingdomState = (byte) 0;
          this.GoToKingdom(DataManager.MapDataController.FocusKingdomID, DataManager.MapDataController.FocusMapID);
          if ((int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
          {
            DataManager.msgBuffer[0] = (byte) 89;
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
            this.ShowKingdomMark();
            GUIManager.Instance.m_HUDMessage.MapHud.AddChangeKindomMapMsg();
            GUIManager.Instance.pDVMgr.NextTransitions(eTrans.END);
          }
        }
        else
        {
          Camera.main.cullingMask &= -2;
          this.CloseMenu(this.m_WindowStack.Count > 0);
          GUIManager.Instance.m_HUDMessage.MapHud.AddChangeKindomMapMsg();
          DataManager.msgBuffer[0] = (byte) 36;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          this.m_bDontDestroyOnSwitch = true;
          GameManager.SwitchGameplay(GameplayKind.CHAOS);
        }
        DataManager.MapDataController.RequsetYolkswitch();
        break;
      case 3:
        DataManager.msgBuffer[0] = (byte) 67;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        DataManager.StageDataController.currentWorldMode = WorldMode.Wild;
        DataManager.StageDataController._stageMode = StageMode.Count;
        if (this.bHideMainMenu)
        {
          this.bHideMainMenu = false;
          this.SwitchFullMap();
        }
        NewbieManager.bIgnoreGameplayCheck = true;
        this.SwitchMapMode(EUIOriginMapMode.OriginMap);
        this.m_bDontDestroyOnSwitch = true;
        GameManager.SwitchGameplay(GameplayKind.Origin);
        GUIManager.Instance.m_HUDMessage.MapHud.AddManorMsg();
        break;
      case 4:
        if (DataManager.MapDataController.gotoKingdomState == byte.MaxValue)
        {
          DataManager.MapDataController.gotoKingdomState = (byte) 0;
          this.CloseMenu(this.m_WindowStack.Count > 0);
          DataManager.msgBuffer[0] = (byte) 119;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          break;
        }
        Camera.main.cullingMask &= -2;
        this.CloseMenu(this.m_WindowStack.Count > 0);
        DataManager.msgBuffer[0] = (byte) 36;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        this.m_bDontDestroyOnSwitch = true;
        GameManager.SwitchGameplay(GameplayKind.Cosmos);
        GUIManager.Instance.m_HUDMessage.MapHud.AddWorldMsg();
        break;
      case 5:
        this.RefreshFuncBtnCount(0, arg2);
        break;
      case 9:
        this.CheckAllianceFreeState();
        break;
      case 10:
        this.RefreshFuncBtnCount(4);
        break;
      case 11:
        this.CheckHelpAlertState();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_StageSelect, 1);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_StageSelect2, 1);
        break;
      case 12:
        this.CheckBuffState();
        break;
      case 13:
        this.CheckTalentPoint();
        break;
      case 14:
        this.CheckSysSetting();
        break;
      case 15:
        this.RefreshFuncBtnCount(3);
        break;
      case 16:
        this.CheckTreasureBox();
        break;
      case 17:
        this.RefreshFuncBtnCount(5);
        break;
      case 18:
        this.UpDateLeadState();
        break;
      case 19:
        this.CheckFuncButtonState();
        break;
      case 20:
        this.RefreshFuncBtnCount(2);
        break;
      case 21:
        this.CheckShowDaBauBtn();
        break;
      case 23:
        this.SetTreasureBoxSprite();
        break;
      case 24:
        this.CheckShowMissionFlash();
        break;
      case 25:
        this.ShowKVKTime();
        this.ShowKingdomMark();
        break;
      case 26:
        this.CheckPetSkillBtn(arg2);
        break;
      case 27:
        this.CheckFBBtn(arg2);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_QBarTime:
        DataManager.Instance.bNeedSortQueueBarData = true;
        break;
      case NetworkNews.Refresh_AttribEffectVal:
      case NetworkNews.Refresh_Morale:
      case NetworkNews.Refresh_MonsterPoint:
        this.UpdateMoney();
        break;
      case NetworkNews.Refresh_HeroExclamation:
        this.RefreshFuncBtnCount(0, 0);
        break;
      case NetworkNews.Refresh_ChangeLord:
label_11:
        this.UpdateRoleInfo();
        break;
      case NetworkNews.Refresh_VIP:
        DataManager.Instance.bNeedSortQueueBarData = true;
        this.UpdateRoleInfo();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTextureRebuilt();
        if (this.m_GroundInfo == null)
          break;
        this.m_GroundInfo.Refresh_FontTexture();
        break;
      case NetworkNews.Refresh_PetResource:
        this.UpdateMoney();
        this.UpDateForceHint();
        break;
      default:
        switch (networkNews)
        {
          case NetworkNews.Login:
          case NetworkNews.Refresh:
            if (meg[0] == (byte) 0)
            {
              this.m_GroundInfo.m_RequsetTick = 2f;
              this.m_GroundInfo.bRequsetAdvanceMapdata = true;
            }
            GUIManager.Instance.HideUILock(EUILock.All);
            this.UpdateMoney();
            this.UpdateResource();
            this.UpDateLeadState();
            this.CheckShowMissionFlash();
            for (int tmpIndex = 0; tmpIndex < 6; ++tmpIndex)
              this.RefreshFuncBtnCount(tmpIndex);
            this.RefreshMainEff();
            if (meg[0] != (byte) 0)
              return;
            NewbieManager.NB_SpawnPetTimeCache = 0L;
            NewbieManager.EntryTest();
            return;
          case NetworkNews.Fallout:
            return;
          case NetworkNews.Refresh_Asset:
            if (meg[1] != (byte) 0 || meg[2] != (byte) 1 || (int) GameConstants.ConvertBytesToUShort(meg, 3) != this.m_GroundInfo.Get0NpcCastleHeadID())
              return;
            this.m_GroundInfo.UpdateCastleIcon();
            return;
          case NetworkNews.Refresh_Attr:
            goto label_11;
          case NetworkNews.Refresh_Hero:
            return;
          case NetworkNews.Refresh_Item:
            return;
          case NetworkNews.Refresh_Resource:
            this.UpdateResource();
            return;
          case NetworkNews.Refresh_Stage:
            return;
          case NetworkNews.Refresh_Alliance:
            return;
          case NetworkNews.Refresh_Inputbox:
            return;
          case NetworkNews.Refresh_Mailbox:
            this.RefreshFuncBtnCount(4);
            return;
          default:
            return;
        }
    }
  }

  private void Refresh_FontTextureRebuilt()
  {
    if (this.m_QueueTimeBar != null)
    {
      for (int index = 0; index < this.m_QueueTimeBar.Length; ++index)
      {
        if ((UnityEngine.Object) this.m_QueueTimeBar[index] != (UnityEngine.Object) null && this.m_QueueTimeBar[index].gameObject.activeSelf)
          this.m_QueueTimeBar[index].Refresh_FontTexture();
      }
    }
    for (int index = 0; index < this.m_ResourceText.Length; ++index)
    {
      if ((UnityEngine.Object) this.m_ResourceText[index] != (UnityEngine.Object) null && ((Behaviour) this.m_ResourceText[index]).enabled)
      {
        ((Behaviour) this.m_ResourceText[index]).enabled = false;
        ((Behaviour) this.m_ResourceText[index]).enabled = true;
      }
    }
    for (int index = 0; index < this.RBText.Length; ++index)
    {
      if ((UnityEngine.Object) this.RBText[index] != (UnityEngine.Object) null && ((Behaviour) this.RBText[index]).enabled)
      {
        ((Behaviour) this.RBText[index]).enabled = false;
        ((Behaviour) this.RBText[index]).enabled = true;
      }
    }
    for (int index = 0; index < this.m_FuncBtnText.Length; ++index)
    {
      if ((UnityEngine.Object) this.m_FuncBtnText[index] != (UnityEngine.Object) null && ((Behaviour) this.m_FuncBtnText[index]).enabled)
      {
        ((Behaviour) this.m_FuncBtnText[index]).enabled = false;
        ((Behaviour) this.m_FuncBtnText[index]).enabled = true;
      }
    }
    if ((UnityEngine.Object) this.m_LocationXText != (UnityEngine.Object) null && ((Behaviour) this.m_LocationXText).enabled)
    {
      ((Behaviour) this.m_LocationXText).enabled = false;
      ((Behaviour) this.m_LocationXText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_LocationYText != (UnityEngine.Object) null && ((Behaviour) this.m_LocationYText).enabled)
    {
      ((Behaviour) this.m_LocationYText).enabled = false;
      ((Behaviour) this.m_LocationYText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_HomeDistText != (UnityEngine.Object) null && ((Behaviour) this.m_HomeDistText).enabled)
    {
      ((Behaviour) this.m_HomeDistText).enabled = false;
      ((Behaviour) this.m_HomeDistText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_VipText != (UnityEngine.Object) null && ((Behaviour) this.m_VipText).enabled)
    {
      ((Behaviour) this.m_VipText).enabled = false;
      ((Behaviour) this.m_VipText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_Power != (UnityEngine.Object) null && ((Behaviour) this.m_Power).enabled)
    {
      ((Behaviour) this.m_Power).enabled = false;
      ((Behaviour) this.m_Power).enabled = true;
    }
    if ((UnityEngine.Object) this.m_Level != (UnityEngine.Object) null && ((Behaviour) this.m_Level).enabled)
    {
      ((Behaviour) this.m_Level).enabled = false;
      ((Behaviour) this.m_Level).enabled = true;
    }
    if ((UnityEngine.Object) this.m_DiamondText != (UnityEngine.Object) null && ((Behaviour) this.m_DiamondText).enabled)
    {
      ((Behaviour) this.m_DiamondText).enabled = false;
      ((Behaviour) this.m_DiamondText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_MoraleText != (UnityEngine.Object) null && ((Behaviour) this.m_MoraleText).enabled)
    {
      ((Behaviour) this.m_MoraleText).enabled = false;
      ((Behaviour) this.m_MoraleText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_MoraleHintText != (UnityEngine.Object) null && ((Behaviour) this.m_MoraleHintText).enabled)
    {
      ((Behaviour) this.m_MoraleHintText).enabled = false;
      ((Behaviour) this.m_MoraleHintText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_AttackedAlertText != (UnityEngine.Object) null && ((Behaviour) this.m_AttackedAlertText).enabled)
    {
      ((Behaviour) this.m_AttackedAlertText).enabled = false;
      ((Behaviour) this.m_AttackedAlertText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_HelpAlertext != (UnityEngine.Object) null && ((Behaviour) this.m_HelpAlertext).enabled)
    {
      ((Behaviour) this.m_HelpAlertext).enabled = false;
      ((Behaviour) this.m_HelpAlertext).enabled = true;
    }
    if ((UnityEngine.Object) this.m_HelpAlertext2 != (UnityEngine.Object) null && ((Behaviour) this.m_HelpAlertext2).enabled)
    {
      ((Behaviour) this.m_HelpAlertext2).enabled = false;
      ((Behaviour) this.m_HelpAlertext2).enabled = true;
    }
    if ((UnityEngine.Object) this.m_AllianceFreetext != (UnityEngine.Object) null && ((Behaviour) this.m_AllianceFreetext).enabled)
    {
      ((Behaviour) this.m_AllianceFreetext).enabled = false;
      ((Behaviour) this.m_AllianceFreetext).enabled = true;
    }
    if ((UnityEngine.Object) this.m_TroopsText != (UnityEngine.Object) null && ((Behaviour) this.m_TroopsText).enabled)
    {
      ((Behaviour) this.m_TroopsText).enabled = false;
      ((Behaviour) this.m_TroopsText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_BuffText != (UnityEngine.Object) null && ((Behaviour) this.m_BuffText).enabled)
    {
      ((Behaviour) this.m_BuffText).enabled = false;
      ((Behaviour) this.m_BuffText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_ActivityTitleText != (UnityEngine.Object) null && ((Behaviour) this.m_ActivityTitleText).enabled)
    {
      ((Behaviour) this.m_ActivityTitleText).enabled = false;
      ((Behaviour) this.m_ActivityTitleText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_ActivityTimeText != (UnityEngine.Object) null && ((Behaviour) this.m_ActivityTimeText).enabled)
    {
      ((Behaviour) this.m_ActivityTimeText).enabled = false;
      ((Behaviour) this.m_ActivityTimeText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_TreasureBoxtext != (UnityEngine.Object) null && ((Behaviour) this.m_TreasureBoxtext).enabled)
    {
      ((Behaviour) this.m_TreasureBoxtext).enabled = false;
      ((Behaviour) this.m_TreasureBoxtext).enabled = true;
    }
    if ((UnityEngine.Object) this.m_MissionHinttextL != (UnityEngine.Object) null && ((Behaviour) this.m_MissionHinttextL).enabled)
    {
      ((Behaviour) this.m_MissionHinttextL).enabled = false;
      ((Behaviour) this.m_MissionHinttextL).enabled = true;
    }
    if ((UnityEngine.Object) this.m_MissionHinttextR != (UnityEngine.Object) null && ((Behaviour) this.m_MissionHinttextR).enabled)
    {
      ((Behaviour) this.m_MissionHinttextR).enabled = false;
      ((Behaviour) this.m_MissionHinttextR).enabled = true;
    }
    if ((UnityEngine.Object) this.m_QueueCountText != (UnityEngine.Object) null && ((Behaviour) this.m_QueueCountText).enabled)
    {
      ((Behaviour) this.m_QueueCountText).enabled = false;
      ((Behaviour) this.m_QueueCountText).enabled = true;
    }
    if ((UnityEngine.Object) this.KingdomMarkText != (UnityEngine.Object) null && ((Behaviour) this.KingdomMarkText).enabled)
    {
      ((Behaviour) this.KingdomMarkText).enabled = false;
      ((Behaviour) this.KingdomMarkText).enabled = true;
    }
    if ((UnityEngine.Object) this.PVPTimeText != (UnityEngine.Object) null && ((Behaviour) this.PVPTimeText).enabled)
    {
      ((Behaviour) this.PVPTimeText).enabled = false;
      ((Behaviour) this.PVPTimeText).enabled = true;
    }
    if ((UnityEngine.Object) this.KVKTimeText != (UnityEngine.Object) null && ((Behaviour) this.KVKTimeText).enabled)
    {
      ((Behaviour) this.KVKTimeText).enabled = false;
      ((Behaviour) this.KVKTimeText).enabled = true;
    }
    if ((UnityEngine.Object) this.RunningText != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.RunningText.m_RunningText1 != (UnityEngine.Object) null && ((Behaviour) this.RunningText.m_RunningText1).enabled)
      {
        ((Behaviour) this.RunningText.m_RunningText1).enabled = false;
        ((Behaviour) this.RunningText.m_RunningText1).enabled = true;
      }
      if ((UnityEngine.Object) this.RunningText.m_RunningText2 != (UnityEngine.Object) null && ((Behaviour) this.RunningText.m_RunningText2).enabled)
      {
        ((Behaviour) this.RunningText.m_RunningText2).enabled = false;
        ((Behaviour) this.RunningText.m_RunningText2).enabled = true;
      }
    }
    if ((UnityEngine.Object) this.m_MallText != (UnityEngine.Object) null && ((Behaviour) this.m_MallText).enabled)
    {
      ((Behaviour) this.m_MallText).enabled = false;
      ((Behaviour) this.m_MallText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_PetSkillText != (UnityEngine.Object) null && ((Behaviour) this.m_PetSkillText).enabled)
    {
      ((Behaviour) this.m_PetSkillText).enabled = false;
      ((Behaviour) this.m_PetSkillText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_FBBtnCountText != (UnityEngine.Object) null && ((Behaviour) this.m_FBBtnCountText).enabled)
    {
      ((Behaviour) this.m_FBBtnCountText).enabled = false;
      ((Behaviour) this.m_FBBtnCountText).enabled = true;
    }
    if (!((UnityEngine.Object) this.m_FBBtnTimeText != (UnityEngine.Object) null) || !((Behaviour) this.m_FBBtnTimeText).enabled)
      return;
    ((Behaviour) this.m_FBBtnTimeText).enabled = false;
    ((Behaviour) this.m_FBBtnTimeText).enabled = true;
  }

  public override bool OnBackButtonClick()
  {
    if (this.m_GroundInfo.bGroundInfoOpen)
    {
      this.m_GroundInfo.Close();
      return true;
    }
    if (this.m_WindowStack.Count != 0)
    {
      GUIWindow menu = GUIManager.Instance.FindMenu(this.m_WindowStack[this.m_WindowStack.Count - 1].m_eWindow);
      if ((UnityEngine.Object) menu != (UnityEngine.Object) null && menu.OnBackButtonClick())
        return true;
      this.CloseMenu();
    }
    else
      GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(685U), DataManager.Instance.mStringTable.GetStringByID(242U));
    return true;
  }

  public void setFightButton(AssetBundle _FightButtonAB)
  {
    if ((UnityEngine.Object) _FightButtonAB == (UnityEngine.Object) null)
    {
      if (this.FightassetKey != 0)
      {
        AssetManager.UnloadAssetBundle(this.FightassetKey);
        this.FightassetKey = 0;
      }
      this.FightButtonAS = (AnimationState) null;
      this.FightButtonAS_Touch = (AnimationState) null;
      if (!((UnityEngine.Object) this.FightButton != (UnityEngine.Object) null))
        return;
      UnityEngine.Object.Destroy((UnityEngine.Object) this.FightButton.gameObject);
      this.FightButton = (Animation) null;
    }
    else
    {
      if (!((UnityEngine.Object) this.FightButton == (UnityEngine.Object) null))
        return;
      GameObject go = UnityEngine.Object.Instantiate(_FightButtonAB.mainAsset) as GameObject;
      this.FightButtonSMR = go.GetComponentInChildren<SkinnedMeshRenderer>();
      if (DataManager.Instance.GoToBattleOrWar == GameplayKind.CHAOS)
      {
        GameObject gameObject = new GameObject("point light");
        Light light = gameObject.AddComponent<Light>();
        light.type = LightType.Point;
        light.range = 10f;
        light.intensity = 7.5f;
        light.color = new Color(0.8667f, 0.8118f, 0.8078f);
        gameObject.transform.localPosition = new Vector3(0.0f, -506f / (481f * Math.E), 2.694f);
        gameObject.transform.eulerAngles = new Vector3(357.55f, 180f, 180f);
        gameObject.transform.SetParent(go.transform, false);
      }
      go.SetActive(false);
      go.transform.SetParent((Transform) GUIManager.Instance.m_WindowsTransform, false);
      this.FightButton = go.GetComponent<Animation>();
      this.FightButtonAS = this.FightButton[this.FightName];
      this.FightButtonAS_Touch = this.FightButton[this.TouchName];
      GUIManager.Instance.SetLayer(go, 5);
      this.FightButton.transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
    }
  }

  public void ShowFightButton(
    Vector3 position,
    float Scale,
    bool closeLightProbes = false,
    E3DButtonKind BtnKind = E3DButtonKind.BK_Main)
  {
    if ((UnityEngine.Object) this.FightButton == (UnityEngine.Object) null)
    {
      AssetBundle assetBundle = AssetManager.GetAssetBundle("Role/3dbutton01", out this.FightassetKey);
      if ((bool) (UnityEngine.Object) assetBundle)
        this.setFightButton(assetBundle);
      if ((UnityEngine.Object) this.FightButton == (UnityEngine.Object) null)
      {
        this.FightassetKey = 0;
        return;
      }
    }
    this.FightButton.transform.localPosition = position;
    this.FightButton.transform.localScale = new Vector3(Scale, Scale, Scale);
    this.FightButton.wrapMode = WrapMode.Loop;
    this.FightButton.Play("idle");
    this.FightButton.gameObject.SetActive(true);
    this.FightButton.transform.SetAsLastSibling();
    this.FightButton.transform.localRotation = Quaternion.Euler(0.0f, !Camera.main.orthographic ? (float) (180.0 - (double) Camera.main.fieldOfView * 0.5) : 180f, 0.0f);
    if (DataManager.Instance.GoToBattleOrWar == GameplayKind.CHAOS)
      this.FightButton.transform.GetChild(2).GetComponent<Light>().range = (double) Scale != 150.0 ? ((double) Scale != 250.0 ? 12f : 14f) : 10f;
    if (!closeLightProbes)
      return;
    this.FightButtonSMR.useLightProbes = false;
  }

  public void HideFightButton()
  {
    if ((UnityEngine.Object) this.FightButton == (UnityEngine.Object) null)
      return;
    this.FightButton.gameObject.SetActive(false);
    this.FightButtonSMR.useLightProbes = true;
    ((Component) this.m_BattleButton).gameObject.SetActive(false);
  }

  public float PlayFight(float PlayTime = 0.0f)
  {
    if (!((UnityEngine.Object) this.FightButton != (UnityEngine.Object) null))
      return 0.0f;
    if ((double) PlayTime != 0.0)
    {
      this.FightButtonAS.speed = this.FightButtonAS.length / PlayTime;
      this.PlayFightTime = PlayTime;
    }
    else
      this.PlayFightTime = this.FightButtonAS.length;
    this.PlayFightTime *= 0.6f;
    this.FightButton.wrapMode = WrapMode.Once;
    this.FightButton.Play(this.FightName);
    return this.PlayFightTime + 0.2f;
  }

  public float PlayTouch(float PlayTime = 0.0f)
  {
    if (!((UnityEngine.Object) this.FightButton != (UnityEngine.Object) null))
      return 0.0f;
    if ((double) PlayTime != 0.0)
    {
      this.FightButtonAS_Touch.speed = this.FightButtonAS_Touch.length / PlayTime;
      this.PlayTouchTime = PlayTime;
    }
    else
      this.PlayTouchTime = this.FightButtonAS_Touch.length;
    this.FightButton.wrapMode = WrapMode.Once;
    this.FightButton.Play(this.TouchName);
    return this.PlayTouchTime;
  }

  public void FightButtonUpdate()
  {
    if ((double) this.PlayFightTime <= 0.0)
      return;
    this.PlayFightTime -= Time.deltaTime;
    if ((double) this.PlayFightTime > 0.0)
      return;
    this.Vec3.Set(0.0f, 0.4f, 0.4f);
    GUIManager.Instance.SetLayer(ParticleManager.Instance.Spawn((ushort) 59, this.FightButton.transform, this.Vec3, 1f, true), 5);
    AudioManager.Instance.PlayUISFX(UIKind.AxSound);
    this.PlayFightTime = 0.0f;
  }

  public void ShowBattleButton()
  {
    this.ShowFightButton(((Component) this.m_BattleButton).transform.localPosition + new Vector3(95f, 18f, 0.0f), 150f);
    ((Component) this.m_BattleButton).gameObject.SetActive(true);
  }

  public void SetTileMapController(MapTile _mapTile) => this.TileMapController = _mapTile;

  public void SetBackGroundPosZ(float Z)
  {
    if ((UnityEngine.Object) this.m_Background == (UnityEngine.Object) null)
      return;
    this.m_Background.anchoredPosition3D = new Vector3(this.m_Background.anchoredPosition3D.x, this.m_Background.anchoredPosition3D.y, Z);
  }

  public void SetBackGroundColor(Color sColor)
  {
    if ((UnityEngine.Object) this.m_Background == (UnityEngine.Object) null)
      return;
    ((Graphic) ((Transform) this.m_Background).GetChild(0).GetComponent<Image>()).color = sColor;
    ((Graphic) ((Transform) this.m_Background).GetChild(1).GetComponent<Image>()).color = sColor;
  }

  private void Update()
  {
    DataManager instance = DataManager.Instance;
    if (this.isTrackBackGround)
      this.TrackBackGround();
    this.UpdateFuncButton();
    this.FightButtonUpdate();
    if (instance.SortQueueBarData())
      this.UpdateQueue();
    if (this.HomeArrowtarget != this.m_HomeArrowT.localRotation)
      this.m_HomeArrowT.localRotation = Quaternion.Slerp(this.m_HomeArrowT.localRotation, this.HomeArrowtarget, Time.smoothDeltaTime * 15f);
    if (instance.Resource[0].GetSpeed() < 0L)
    {
      this.ResourceRedTime += Time.deltaTime;
      if (this.bResourceRed)
      {
        if ((double) this.ResourceRedTime >= 0.5)
        {
          this.ResourceRedTime = 0.0f;
          ((Graphic) this.m_ResourceText[0]).color = this.m_ResourceColor[0];
          this.bResourceRed = false;
        }
      }
      else if ((double) this.ResourceRedTime >= 1.2999999523162842)
      {
        this.ResourceRedTime = 0.0f;
        ((Graphic) this.m_ResourceText[0]).color = Color.red;
        this.bResourceRed = true;
      }
    }
    else if (this.bResourceRed)
    {
      this.ResourceRedTime = 0.0f;
      this.bResourceRed = false;
      ((Graphic) this.m_ResourceText[0]).color = this.m_ResourceColor[0];
    }
    if (((Component) this.m_BuffRC2).gameObject.activeInHierarchy)
    {
      this.BuffRedTime += Time.deltaTime;
      this.BuffTextTime += Time.deltaTime;
      if (this.bBuffRed)
      {
        if ((double) this.BuffRedTime >= 0.5)
        {
          this.BuffRedTime = 0.0f;
          ((Graphic) this.m_BuffText2).color = Color.white;
          this.bBuffRed = false;
        }
      }
      else if ((double) this.BuffRedTime >= 1.2999999523162842)
      {
        this.BuffRedTime = 0.0f;
        ((Graphic) this.m_BuffText2).color = Color.red;
        this.bBuffRed = true;
      }
      if ((double) this.BuffTextTime >= 1.0)
      {
        this.m_BuffAlertStr2.Length = 0;
        if (instance.m_RecvItemBuffData[instance.m_RecvWarBuffIdx].TargetTime > instance.ServerTime)
          GameConstants.GetTimeString(this.m_BuffAlertStr2, (uint) (instance.m_RecvItemBuffData[instance.m_RecvWarBuffIdx].TargetTime - instance.ServerTime), showZeroHour: false);
        else
          GameConstants.GetTimeString(this.m_BuffAlertStr2, 0U, showZeroHour: false);
        this.m_BuffText2.text = this.m_BuffAlertStr2.ToString();
        this.m_BuffText2.SetAllDirty();
        this.m_BuffText2.cachedTextGenerator.Invalidate();
        this.m_BuffText2.cachedTextGeneratorForLayout.Invalidate();
        this.BuffTextTime = 0.0f;
      }
    }
    else if (this.bBuffRed)
    {
      this.BuffRedTime = 0.0f;
      this.bBuffRed = false;
      ((Graphic) this.m_BuffText2).color = this.m_ResourceColor[0];
    }
    if (this.bMoraleHintOpen)
      this.SetMolareHint();
    if (this.bShowLoadingImg)
      this.LoadingImgT.Rotate(Vector3.forward * Time.smoothDeltaTime * -200f);
    if (((Behaviour) this.NewMissionReward).enabled && this.m_MissionHintTrans.gameObject.activeSelf)
    {
      float num = Mathf.Clamp(this.RewardTime / this.MaxRewardTime, 0.0f, 1f);
      Color color = ((Graphic) this.NewMissionReward).color;
      ((Transform) ((Graphic) this.NewMissionReward).rectTransform).localScale = Vector3.one * 0.9f + Vector3.one * (0.5f * num);
      color.a = (double) num >= 0.5 ? (float) (1.0 - ((double) num - 0.5) / 0.5) : num * 2f;
      ((Graphic) this.NewMissionReward).color = color;
      this.RewardTime += Time.deltaTime;
      if ((double) this.RewardTime > (double) this.MaxRewardTime)
        this.RewardTime = 0.0f;
    }
    if ((double) this.m_TickBeginAnimBtnTime <= 10.0)
      this.m_TickBeginAnimBtnTime += Time.deltaTime;
    if ((double) this.m_TickBeginAnimBtnTime >= 10.0 && (double) this.m_TickEndAnimBtnTime <= 0.20000000298023224)
      this.m_TickEndAnimBtnTime += Time.deltaTime;
    if (((Behaviour) this.m_MissionBtn).enabled && !((Behaviour) this.NewMissionReward).enabled && (double) this.m_TickBeginAnimBtnTime >= 10.0)
    {
      if (!this.m_MissionBtnTS.enabled)
      {
        this.m_MissionBtnTS.enabled = true;
        this.m_MissionBtnTS.factor = 0.0f;
      }
      if ((double) this.m_TickEndAnimBtnTime < 0.20000000298023224)
        return;
      float num = Mathf.Abs(((Transform) this.m_MissionBtnRect).localScale.x);
      if ((double) num >= 1.1000000238418579 || (double) num <= 0.89999997615814209)
        return;
      this.m_TickEndAnimBtnTime = 0.0f;
      this.m_TickBeginAnimBtnTime = 0.0f;
    }
    else
    {
      if (!this.m_MissionBtnTS.enabled)
        return;
      ((Transform) this.m_MissionBtnRect).localScale = new Vector3(1f, 1f, 1f);
      this.m_MissionBtnTS.enabled = false;
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (bOnSecond)
    {
      this.UpdatePVPTime();
      this.UpdateKVKTime();
      this.SetFBBtnTime();
    }
    this.FadeInOutUpDate();
    this.GroundInfoUpdate();
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    Application.Quit();
  }

  public void ForceQueueBarOpenClose(bool bOpen)
  {
    if (DataManager.Instance.queueBarData[17].bActive && this.m_QueueCount <= (byte) 1 || this.m_QueueCount <= (byte) 0)
      return;
    this.SetQueueBar(bOpen);
    this.QueuePanelSetActive(bOpen);
    DataManager.Instance.bOpenQueue = bOpen;
  }

  public void ForceFuncBtnOpenClose(bool bOpen)
  {
    this.m_bShowFuncButton = !bOpen ? (byte) 3 : (byte) 2;
    this.m_ShowFuncTime = 0.0f;
    if (bOpen)
    {
      if (this.m_WindowStack.Count > 0)
      {
        ((Component) this.m_FuncPanelBG).gameObject.SetActive(true);
        ((Component) this.m_MapSwitchButton).gameObject.SetActive(true);
        this.m_MapSwitchButton.alpha = 0.0f;
      }
      ((Component) this.m_FuncBG).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.m_FuncPanelBG).gameObject.SetActive(false);
      this.m_MapSwitchButton.alpha = 1f;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    DataManager.MapDataController.StopMapWeapon();
    this.SetDefaultFadeAlpha();
    switch (sender.m_BtnID1)
    {
      case 1:
        this.FuncButtonOnClick(sender);
        break;
      case 2:
        if (sender.m_BtnID2 != 0)
          break;
        DataManager.StageDataController.resetStageMode(StageMode.Corps);
        DataManager.msgBuffer[0] = (byte) 3;
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        break;
      case 3:
        this.MapFuncButtonOnClick(sender);
        break;
      case 11:
        this.MoneyOnClick(sender);
        break;
      case 13:
      case 16:
        this.OpenMenu(EGUIWindow.UI_LordInfo, 1, bCameraMode: true);
        break;
      case 14:
        this.OpenMenu(EGUIWindow.UI_VIP);
        break;
      case 15:
        this.ForceQueueBarOpenClose(!((Component) this.m_QueuePanel).gameObject.activeSelf);
        break;
      case 22:
        RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData((ushort) 13, (ushort) 0);
        this.OpenMenu(EGUIWindow.UI_Watchtower, (int) buildData.ManorID, (int) buildData.BuildID);
        break;
      case 23:
        this.OpenMenu(EGUIWindow.UI_Alliance_HelpSpeedup);
        break;
      case 24:
        this.OpenMenu(EGUIWindow.UI_ArmyInfo);
        break;
      case 25:
        this.AllianceOnClick();
        break;
      case 26:
        ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST();
        if (!IGGGameSDK.Instance.GetStarStatus() || DataManager.Instance.CheckPrizeFlag((byte) 4))
          break;
        long result1 = 0;
        bool result2 = false;
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.ClearString();
        cstring.IntToFormat(NetworkManager.UserID);
        cstring.AppendFormat("{0}_Score_UseID");
        long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result1);
        cstring.ClearString();
        cstring.IntToFormat(result1);
        cstring.AppendFormat("{0}_Score_bScoreFirst");
        bool.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result2);
        if (result1 != 0L && result2)
          break;
        GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_TreasureBox, 4, openMode: (byte) 0);
        break;
      case 27:
        this.OpenMenu(EGUIWindow.UI_BuffList);
        break;
      case 28:
        DataManager instance1 = DataManager.Instance;
        GUIManager instance2 = GUIManager.Instance;
        if (MallManager.Instance.CheckBtnShow())
        {
          GUIManager.Instance.OpenMenu(EGUIWindow.UI_TreasureBox, 11, bSecWindow: true);
          break;
        }
        if (instance1.CheckDailyGift())
        {
          GUIManager.Instance.OpenUI_Queued_Restricted_Top(EGUIWindow.UI_TreasureBox, 12, 1, true, (byte) 1);
          break;
        }
        if (instance1.RoleAttr.NextOnlineGiftOpenTime - instance1.ServerTime >= 0L)
        {
          instance2.OpenMenu(EGUIWindow.UI_TreasureBox, bSecWindow: true);
          break;
        }
        instance2.OpenMenu(EGUIWindow.UI_TreasureBox, 1, bSecWindow: true);
        break;
      case 29:
        ushort btnId3 = (ushort) sender.m_BtnID3;
        if (sender.m_BtnID2 == 1)
        {
          ManorAimTbl recordByKey = DataManager.MissionDataManager.ManorAimTable.GetRecordByKey(btnId3);
          if ((int) recordByKey.MissionKind - 1 == 0)
            DataManager.MissionDataManager.sendMissionComplete(btnId3, GUIManager.Instance.BuildingData.GetBuildData(recordByKey.Parm1, (ushort) 0).ManorID);
          else
            DataManager.MissionDataManager.sendMissionComplete(btnId3, (ushort) 0);
          GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x + ((Component) sender).transform.GetComponent<RectTransform>().anchoredPosition.x, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y - ((Component) sender).transform.GetComponent<RectTransform>().anchoredPosition.y);
          break;
        }
        DataManager.MissionDataManager.GetManorAimGuide(btnId3);
        break;
      case 30:
        MallManager.Instance.Send_Mall_Info();
        break;
      case 31:
        GUIManager.Instance.OpenMenu(EGUIWindow.UI_TreasureBox, 10, bSecWindow: true);
        break;
      case 32:
        this.OpenMenu(EGUIWindow.UI_PetBuff);
        break;
      case 33:
        if (DataManager.Instance.bHaveWarBuff)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9943U), (ushort) byte.MaxValue);
          break;
        }
        DataManager.Instance.MoveTo(DataManager.MapDataController.FocusKingdomID);
        break;
      case 34:
        if (this.m_FBUIType > (byte) 0)
        {
          GUIManager.Instance.OpenMenu(EGUIWindow.UI_TreasureBox_FB, bSecWindow: true);
          break;
        }
        DataManager.FBMissionDataManager.m_FBBindEnd = false;
        this.OpenMenu(EGUIWindow.UI_MissionFB, bCameraMode: true);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (sender.Parm1 == (ushort) 0)
    {
      Vector2 anchoredPosition = ((RectTransform) ((Component) this.m_MoraleBox).transform).anchoredPosition;
      anchoredPosition.x += 125f;
      anchoredPosition.y -= 37f;
      ((Graphic) this.m_MoraleHintBox).rectTransform.anchoredPosition = anchoredPosition;
      ((Component) this.m_MoraleHintBox).gameObject.SetActive(true);
      this.bMoraleHintOpen = true;
      this.MonsterTime = -1L;
      this.MoraleHintTime = 2L;
      this.SetForceCount();
      this.SetMolareHint();
    }
    else if (sender.Parm1 == (ushort) 1)
    {
      this.PVPTimeStr.Length = 0;
      this.PVPTimeStr.StringToFormat(DataManager.MapDataController.GetYolkName(this.PVPWonderID, DataManager.MapDataController.FocusKingdomID));
      this.PVPTimeStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11078U));
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.PVPTimeStr, Vector2.zero);
    }
    else
    {
      if (sender.Parm1 != (ushort) 2)
        return;
      this.KVKTimeStr.Length = 0;
      this.KVKTimeStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12092U));
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.KVKTimeStr, Vector2.zero);
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if (sender.Parm1 == (ushort) 0)
    {
      ((Component) this.m_MoraleHintBox).gameObject.SetActive(false);
      this.bMoraleHintOpen = false;
      this.ForceTime = 0U;
    }
    else
    {
      if (sender.Parm1 != (ushort) 1 && sender.Parm1 != (ushort) 2)
        return;
      GUIManager.Instance.m_Hint.Hide(true);
    }
  }

  private void AddFuncStack(EGUIWindow eWin)
  {
    GUIWindowStackData guiWindowStackData;
    guiWindowStackData.m_eWindow = eWin;
    guiWindowStackData.m_Arg1 = 0;
    guiWindowStackData.m_Arg2 = 0;
    guiWindowStackData.bCameraMode = false;
    this.m_WindowStack.Add(guiWindowStackData);
  }

  private void FuncButtonOnClick(UIButton sender)
  {
    if (this.m_bShowFuncButton >= (byte) 2)
      return;
    if (sender.m_BtnID2 >= 10 && this.m_WindowStack.Count > 0)
    {
      ((Component) this.m_FuncPanelBG).gameObject.SetActive(false);
      ((Component) this.m_MapSwitchButton).gameObject.SetActive(false);
      this.ShowFuncButton(false);
    }
    switch (sender.m_BtnID2)
    {
      case 0:
      case 1:
        this.ForceFuncBtnOpenClose(this.m_bShowFuncButton == (byte) 0);
        break;
      case 2:
        if (this.m_WindowStack.Count > 0)
        {
          this.CloseMenu(true);
          DataManager.msgBuffer[0] = (byte) 4;
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          break;
        }
        if (this.m_eMapMode == EUIOriginMapMode.OriginMap)
        {
          if (!NewbieManager.CheckRename())
          {
            this.GoToGroup(-1, (byte) 0);
            break;
          }
          break;
        }
        if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
        {
          this.GoToGroup(-1, (byte) 0);
          break;
        }
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToMap);
        break;
      case 10:
        if (this.m_FuncLight[0].activeSelf)
          this.m_FuncLight[0].SetActive(false);
        this.ClearWindowStack();
        if (!this.OpenMenu(EGUIWindow.UI_HeroList))
        {
          this.AddFuncStack(EGUIWindow.UI_HeroList);
          break;
        }
        break;
      case 11:
        UIBagFilter menu = GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter) as UIBagFilter;
        if ((UnityEngine.Object) menu != (UnityEngine.Object) null && menu.Type != 0)
        {
          GUIManager instance = GUIManager.Instance;
          if ((UnityEngine.Object) instance.m_Chat != (UnityEngine.Object) null && instance.m_Chat.activeInHierarchy)
            this.CloseMenu();
          this.CloseMenu();
        }
        this.ClearWindowStack();
        if (!this.OpenMenu(EGUIWindow.UI_BagFilter))
        {
          this.AddFuncStack(EGUIWindow.UI_BagFilter);
          break;
        }
        break;
      case 12:
        this.ClearWindowStack();
        if (!this.OpenMenu(EGUIWindow.UI_Other))
        {
          this.AddFuncStack(EGUIWindow.UI_Other);
          break;
        }
        break;
      case 13:
        this.ClearWindowStack();
        if (!this.OpenMenu(EGUIWindow.UI_Mission))
        {
          this.AddFuncStack(EGUIWindow.UI_Mission);
          break;
        }
        break;
      case 14:
        this.ClearWindowStack();
        if (!this.OpenMenu(EGUIWindow.UI_Letter))
        {
          this.AddFuncStack(EGUIWindow.UI_Letter);
          break;
        }
        break;
      case 15:
        if (this.m_FuncLight[5].activeSelf)
          this.m_FuncLight[5].SetActive(false);
        this.ClearWindowStack();
        EGUIWindow eWin;
        if (DataManager.Instance.RoleAlliance.Id > 0U)
        {
          eWin = EGUIWindow.UI_Alliance_Info;
        }
        else
        {
          DataManager.Instance.SetSelectRequest = 0;
          eWin = EGUIWindow.UI_AllianceHint;
        }
        if (!this.OpenMenu(eWin))
        {
          this.AddFuncStack(eWin);
          break;
        }
        break;
    }
    GUIManager.Instance.HideArrow();
  }

  private void CheckFuncButtonState()
  {
    GUIManager instance = GUIManager.Instance;
    this.FunButtonShowCount = (byte) 0;
    float num1 = 0.0f;
    float num2 = 0.0f;
    for (int index = 0; index < 6; ++index)
    {
      bool flag = true;
      if (index == 0)
      {
        if (!instance.CheckOpenHeroBtn())
        {
          num1 = num2 = 83f;
          ((Component) this.m_FuncRC[0]).gameObject.SetActive(false);
          flag = false;
        }
        else if (!instance.bOpenHeroBtn)
        {
          instance.bOpenHeroBtn = true;
          instance.bNeedForceOpenFuncBtn = true;
          this.RefreshFuncBtnCount(0);
          this.m_FuncLight[0].SetActive(true);
        }
      }
      else if (index == 5)
      {
        if (!instance.CheckOpenAllianceBtn())
        {
          num2 += 93f;
          ((Component) this.m_FuncRC[5]).gameObject.SetActive(false);
          flag = false;
        }
        else if (!instance.bOpenAllianceBtn)
        {
          instance.bOpenAllianceBtn = true;
          instance.bNeedForceOpenFuncBtn = true;
          this.RefreshFuncBtnCount(5);
          this.m_FuncLight[5].SetActive(true);
        }
      }
      if (flag)
      {
        this.m_SFuncRC[(int) this.FunButtonShowCount] = this.m_FuncRC[index];
        this.m_SFuncCG[(int) this.FunButtonShowCount] = this.m_FuncCG[index];
        this.m_SFuncPosX[(int) this.FunButtonShowCount] = this.m_FuncPosX[index] + num1;
        ++this.FunButtonShowCount;
      }
    }
    this.m_SFuncBGWidth = this.m_FuncBGWidth - num2;
    if (this.ChecNeedForceOpenFuncBtn())
      return;
    this.ShowFuncButton(this.m_bShowFuncButton == (byte) 1);
  }

  private bool ChecNeedForceOpenFuncBtn()
  {
    if (!GUIManager.Instance.bNeedForceOpenFuncBtn || this.m_eMode != EUIOriginMode.Show)
      return false;
    GUIManager.Instance.bNeedForceOpenFuncBtn = false;
    this.ForceFuncBtnOpenClose(true);
    return true;
  }

  private void UpdateFuncButton()
  {
    if (this.m_bShowFuncButton < (byte) 2)
      return;
    Vector2 zero = Vector2.zero;
    this.m_ShowFuncTime += Time.unscaledDeltaTime;
    if ((double) this.m_ShowFuncTime < 0.10000000149011612)
    {
      if (this.m_bShowFuncButton == (byte) 2)
      {
        float num1 = 0.0100000007f;
        float num2 = (float) ((0.10000000149011612 - (double) num1) / 2.0);
        RectTransform rectTransform1 = ((Graphic) this.m_FuncBG).rectTransform;
        float num3;
        if ((double) this.m_ShowFuncTime < (double) num1)
        {
          num3 = this.m_ShowFuncTime / num1;
          zero.x = this.m_SFuncBGWidth * num3;
        }
        else
        {
          num3 = 1.1f - (float) ((double) (0.200000048f / num2) * ((double) this.m_ShowFuncTime - (double) num1 - (double) num2) / (double) num2 * ((double) this.m_ShowFuncTime - (double) num1 - (double) num2) / 2.0);
          zero.x = this.m_SFuncBGWidth * num3;
        }
        zero.y = rectTransform1.sizeDelta.y;
        rectTransform1.sizeDelta = zero;
        for (int index = 0; index < (int) this.FunButtonShowCount; ++index)
        {
          ((Component) this.m_SFuncRC[index]).gameObject.SetActive(true);
          RectTransform rectTransform2 = this.m_SFuncRC[index];
          Vector2 anchoredPosition = rectTransform2.anchoredPosition with
          {
            x = this.m_ShowFuncPosX + (this.m_SFuncPosX[index] - this.m_ShowFuncPosX) * num3
          };
          rectTransform2.anchoredPosition = anchoredPosition;
          this.m_SFuncCG[index].alpha = this.m_ShowFuncTime / 0.1f;
        }
        if (this.m_WindowStack.Count <= 0)
          return;
        this.m_MapSwitchButton.alpha = this.m_ShowFuncTime / 0.1f;
      }
      else
      {
        float num4 = this.m_ShowFuncTime / 0.1f;
        RectTransform rectTransform3 = ((Graphic) this.m_FuncBG).rectTransform;
        zero.x = this.m_SFuncBGWidth - this.m_SFuncBGWidth * num4;
        zero.y = rectTransform3.sizeDelta.y;
        rectTransform3.sizeDelta = zero;
        float num5 = (float) (((double) this.m_SFuncPosX[(int) this.FunButtonShowCount - 1] - (double) this.m_ShowFuncPosX) * (1.0 - (double) this.m_ShowFuncTime / 0.10000000149011612));
        for (int index = 0; index < (int) this.FunButtonShowCount; ++index)
        {
          if ((double) num5 >= (double) this.m_SFuncPosX[index] - (double) this.m_ShowFuncPosX)
          {
            if (index > 0 && (double) num5 > (double) this.m_SFuncPosX[index - 1] - (double) this.m_ShowFuncPosX)
            {
              ((Component) this.m_SFuncRC[index]).gameObject.SetActive(false);
            }
            else
            {
              RectTransform rectTransform4 = this.m_SFuncRC[index];
              zero.x = num5 + this.m_ShowFuncPosX;
              zero.y = rectTransform4.anchoredPosition.y;
              rectTransform4.anchoredPosition = zero;
              float num6 = index <= 0 ? 0.0f : this.m_SFuncPosX[index - 1] - this.m_ShowFuncPosX;
              this.m_SFuncCG[index].alpha = (float) (((double) num5 - (double) num6) / ((double) this.m_SFuncPosX[index] - (double) this.m_ShowFuncPosX - (double) num6));
            }
          }
        }
        if (this.m_WindowStack.Count <= 0)
          return;
        this.m_MapSwitchButton.alpha = (float) (1.0 - (double) this.m_ShowFuncTime / 0.10000000149011612);
      }
    }
    else if (this.m_bShowFuncButton == (byte) 2)
    {
      this.ShowFuncButton(true);
      if (this.m_WindowStack.Count <= 0)
        return;
      this.m_MapSwitchButton.alpha = 1f;
    }
    else
    {
      this.ShowFuncButton(false);
      if (this.m_WindowStack.Count <= 0)
        return;
      this.m_MapSwitchButton.alpha = 1f;
      ((Component) this.m_MapSwitchButton).gameObject.SetActive(false);
    }
  }

  public void ShowFuncButton(bool bShow)
  {
    Vector2 vector2 = Vector2.zero;
    RectTransform rectTransform1 = ((Graphic) this.m_FuncBG).rectTransform;
    ((Component) rectTransform1).gameObject.SetActive(bShow);
    vector2.x = !bShow ? 0.0f : this.m_SFuncBGWidth;
    vector2.y = rectTransform1.sizeDelta.y;
    rectTransform1.sizeDelta = vector2;
    for (int tmpIndex = 0; tmpIndex < (int) this.FunButtonShowCount; ++tmpIndex)
    {
      RectTransform rectTransform2 = this.m_SFuncRC[tmpIndex];
      ((Component) rectTransform2).gameObject.SetActive(bShow);
      float num;
      if (bShow)
      {
        vector2.x = this.m_SFuncPosX[tmpIndex];
        num = 1f;
      }
      else
      {
        vector2.x = tmpIndex <= 0 ? this.m_ShowFuncPosX : this.m_SFuncPosX[tmpIndex - 1];
        num = 0.0f;
      }
      vector2.y = rectTransform2.anchoredPosition.y;
      rectTransform2.anchoredPosition = vector2;
      this.m_SFuncCG[tmpIndex].alpha = num;
      this.CheckandShowFuncBtnCount(tmpIndex, bShow);
    }
    this.m_bShowFuncButton = !bShow ? (byte) 0 : (byte) 1;
    RectTransform transform = (RectTransform) ((Component) this.m_ShowFuncIcon).transform;
    ((Transform) transform).localRotation = Quaternion.Euler(0.0f, (float) (180 * (int) this.m_bShowFuncButton), 0.0f);
    vector2 = transform.anchoredPosition with
    {
      x = !bShow ? -30.5f : -19.5f
    };
    transform.anchoredPosition = vector2;
    this.CheckandShowFuncBtnCount(-1);
  }

  private void MapFuncButtonOnClick(UIButton sender)
  {
    switch (sender.m_BtnID2)
    {
      case 1:
        if (this.m_eMapMode != EUIOriginMapMode.KingdomMap)
          break;
        DataManager.MapDataController.gotokingdomID = DataManager.MapDataController.OtherKingdomData.kingdomID;
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToWorld);
        break;
      case 3:
        this.OpenMenu(EGUIWindow.UI_BookMark);
        break;
      case 4:
        this.bHideMainMenu = !this.bHideMainMenu;
        this.SwitchFullMap();
        break;
      case 5:
        if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
        {
          this.m_GroundInfo.OpenSearchPanel(true, true);
          break;
        }
        this.m_GroundInfo.OpenSearchPanel(true);
        break;
      case 6:
        if (this.m_eMapMode == EUIOriginMapMode.KingdomMap)
        {
          this.CheckFocusGroup();
          DataManager.MapDataController.FocusGroupID = (byte) 10;
          this.GoToMapID(DataManager.MapDataController.OtherKingdomData.kingdomID, DataManager.Instance.RoleAttr.CapitalPoint, (byte) 0, (byte) 1);
          break;
        }
        if (this.m_eMapMode != EUIOriginMapMode.WorldMap)
          break;
        this.GoToKingdom(DataManager.MapDataController.OtherKingdomData.kingdomID);
        break;
      case 7:
        this.OpenMenu(EGUIWindow.UI_MiniMap);
        break;
    }
  }

  public void notifyHomeBtnPos()
  {
    DataManager.msgBuffer[0] = this.m_eMapMode != EUIOriginMapMode.WorldMap ? (!this.bHideMainMenu ? (byte) 72 : (byte) 73) : (!this.bHideMainMenu ? (byte) 108 : (byte) 109);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void SetShowHomeBtn(bool bShow)
  {
    this.bShowHomeBtn = bShow;
    ((Component) this.m_HomeButton).gameObject.SetActive(this.bShowHomeBtn);
  }

  public void SetHomeBtnLocation(ushort posx, ushort posy)
  {
    this.m_HomeLocationX = posx;
    this.m_HomeLocationY = posy;
  }

  public void SetCapitalLocation(ushort posx, ushort posy)
  {
    this.m_CapitalLocationX = posx;
    this.m_CapitalLocationY = posy;
  }

  public void UpdateLocation(ushort posx, ushort posy, float DeltaX, float DeltaY)
  {
    Vector2 zero1 = Vector2.zero;
    Vector2 zero2 = Vector2.zero;
    Vector2 zero3 = Vector2.zero;
    Vector2 zero4 = Vector2.zero;
    zero1.Set((float) posx - DeltaX, (float) posy + DeltaY);
    zero2.Set((float) this.m_CapitalLocationX, (float) this.m_CapitalLocationY);
    GUIManager.Instance.mNewCenterPos.Set((float) posx, (float) posy);
    if (GUIManager.Instance.IsArabic)
    {
      zero3.Set(zero1.x - (float) this.m_HomeLocationX, zero1.y - (float) this.m_HomeLocationY);
      this.LocXStr.Length = 0;
      this.LocXStr.IntToFormat((long) posx);
      this.LocXStr.AppendFormat("{0}:X");
      this.m_LocationXText.text = this.LocXStr.ToString();
      this.m_LocationXText.SetAllDirty();
      this.m_LocationXText.cachedTextGenerator.Invalidate();
      this.LocYStr.Length = 0;
      this.LocYStr.IntToFormat((long) posy);
      this.LocYStr.AppendFormat("{0}:Y");
      this.m_LocationYText.text = this.LocYStr.ToString();
      this.m_LocationYText.SetAllDirty();
      this.m_LocationYText.cachedTextGenerator.Invalidate();
    }
    else
    {
      zero3.Set(zero1.x + (float) this.m_HomeLocationX, zero1.y - (float) this.m_HomeLocationY);
      this.LocXStr.Length = 0;
      this.LocXStr.IntToFormat((long) posx);
      this.LocXStr.AppendFormat("X:{0}");
      this.m_LocationXText.text = this.LocXStr.ToString();
      this.m_LocationXText.SetAllDirty();
      this.m_LocationXText.cachedTextGenerator.Invalidate();
      this.LocYStr.Length = 0;
      this.LocYStr.IntToFormat((long) posy);
      this.LocYStr.AppendFormat("Y:{0}");
      this.m_LocationYText.text = this.LocYStr.ToString();
      this.m_LocationYText.SetAllDirty();
      this.m_LocationYText.cachedTextGenerator.Invalidate();
    }
    Vector2 from = zero2 - zero3;
    from.x *= 2f;
    this.HomeArrowtarget = !GUIManager.Instance.IsArabic ? Quaternion.Euler(0.0f, 0.0f, Vector2.Angle(from, Vector2.up) * ((double) from.x >= 0.0 ? 1f : -1f)) : Quaternion.Euler(0.0f, 0.0f, Vector2.Angle(from, Vector2.up) * ((double) from.x >= 0.0 ? -1f : 1f));
    Vector2 a = zero2 - zero3;
    this.HomeStr.Length = 0;
    if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
    {
      this.HomeStr.IntToFormat((long) DataManager.MapDataController.OtherKingdomData.kingdomID);
      if (GUIManager.Instance.IsArabic)
        this.HomeStr.AppendFormat("{0}:K");
      else
        this.HomeStr.AppendFormat("K:{0}");
    }
    else
    {
      this.HomeStr.FloatToFormat(Vector2.Distance(a, Vector2.zero), 1);
      this.HomeStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(252U));
      this.HomeStr.AppendFormat("{0} {1}");
    }
    this.m_HomeDistText.text = this.HomeStr.ToString();
    this.m_HomeDistText.SetAllDirty();
    this.m_HomeDistText.cachedTextGenerator.Invalidate();
  }

  private void UpDateLeadState()
  {
    if (DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.Captured)
      this.m_HeadBoxJail.SetActive(true);
    else
      this.m_HeadBoxJail.SetActive(false);
    this.CheckTalentPoint();
    this.UpdateRoleInfo();
  }

  private void UpdateRoleInfo()
  {
    DataManager instance = DataManager.Instance;
    if (instance.beCaptured.nowCaptureStat == LoadCaptureState.Dead)
    {
      this.m_HeadIcon.image.sprite = this.LoadSprite("UI_GG_001");
      ((MaskableGraphic) this.m_HeadIcon.image).material = this.LoadMaterial();
    }
    else
    {
      Hero recordByKey = instance.HeroTable.GetRecordByKey(DataManager.Instance.RoleAttr.Head);
      if ((int) recordByKey.HeroKey == (int) instance.RoleAttr.Head)
        this.m_HeadIcon.image.sprite = GUIManager.Instance.m_IconSpriteAsset.LoadSprite(recordByKey.Graph);
      else
        this.m_HeadIcon.image.sprite = GUIManager.Instance.m_IconSpriteAsset.LoadSprite((ushort) 10);
      ((MaskableGraphic) this.m_HeadIcon.image).material = GUIManager.Instance.m_IconSpriteAsset.GetMaterial();
    }
    this.m_PowerStr.Length = 0;
    this.m_PowerStr.uLongToFormat(instance.RoleAttr.Power, bNumber: true);
    this.m_PowerStr.AppendFormat("{0}");
    this.m_Power.text = this.m_PowerStr.ToString();
    this.m_Power.SetAllDirty();
    this.m_Power.cachedTextGenerator.Invalidate();
    this.m_LevelStr.Length = 0;
    this.m_LevelStr.uLongToFormat((ulong) instance.RoleAttr.Level);
    this.m_LevelStr.AppendFormat("{0}");
    this.m_Level.text = this.m_LevelStr.ToString();
    this.m_Level.SetAllDirty();
    this.m_Level.cachedTextGenerator.Invalidate();
    byte vipLevel = instance.RoleAttr.VIPLevel;
    if (vipLevel == (byte) 0)
    {
      ((Component) this.m_VIPIcon).gameObject.SetActive(false);
    }
    else
    {
      this.m_VIPStr.Length = 0;
      this.m_VIPStr.IntToFormat((long) vipLevel);
      this.m_VIPStr.AppendFormat("{0}");
      this.m_VipText.text = this.m_VIPStr.ToString();
      this.m_VipText.SetAllDirty();
      this.m_VipText.cachedTextGenerator.Invalidate();
      ((Component) this.m_VIPIcon).gameObject.SetActive(true);
    }
  }

  public void AllianceInfo(uint ID)
  {
    DataManager.Instance.AllianceView.Id = ID;
    DataManager.Instance.AllianceView.Tag = string.Empty;
    this.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5);
  }

  public void AllianceInfo(string Tag)
  {
    DataManager.Instance.AllianceView.Id = 0U;
    DataManager.Instance.AllianceView.Tag = Tag;
    this.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5);
  }

  public void AllianceOnClick()
  {
    if (DataManager.Instance.RoleAlliance.Id > 0U)
    {
      if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceHint))
        this.CloseMenu();
      if (!((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Alliance_Info) == (UnityEngine.Object) null))
        return;
      this.OpenMenu(EGUIWindow.UI_Alliance_Info);
    }
    else if (DataManager.Instance.CheckPrizeFlag((byte) 0))
    {
      DataManager.Instance.SetSelectRequest = 0;
      this.OpenMenu(EGUIWindow.UI_AllianceHint, 11);
    }
    else
    {
      if (!((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceHint) == (UnityEngine.Object) null))
        return;
      DataManager.Instance.SetSelectRequest = 0;
      this.OpenMenu(EGUIWindow.UI_AllianceHint);
    }
  }

  public void AllianceOnJoin(uint ID, byte Direct)
  {
    GUIManager.Instance.ShowUILock(EUILock.AllianceCreate);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_APPLY;
    messagePacket.AddSeqId();
    messagePacket.Add((byte) 0);
    messagePacket.Add(ID);
    messagePacket.Send();
  }

  public void AllianceOnJoin(string Tag)
  {
    GUIManager.Instance.ShowUILock(EUILock.AllianceCreate);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_APPLY;
    messagePacket.AddSeqId();
    messagePacket.Add((byte) 1);
    messagePacket.Add(Encoding.UTF8.GetBytes(Tag), len: 3);
    messagePacket.Send();
  }

  private void MoneyOnClick(UIButton sender)
  {
    int num = 1;
    switch (sender.m_BtnID2)
    {
      case 0:
        MallManager.Instance.Send_Mall_Info();
        break;
      case 10:
        this.OpenMenu(EGUIWindow.UI_BagFilter, num);
        break;
      case 11:
        this.OpenMenu(EGUIWindow.UI_BagFilter, num + 65536);
        break;
      case 12:
        this.OpenMenu(EGUIWindow.UI_BagFilter, num + 131072);
        break;
      case 13:
        this.OpenMenu(EGUIWindow.UI_BagFilter, num + 196608);
        break;
      case 14:
        this.OpenMenu(EGUIWindow.UI_BagFilter, num + 262144);
        break;
    }
  }

  private void CheckMonsterPoint()
  {
    DataManager instance = DataManager.Instance;
    bool flag = instance.RoleAttr.MonsterPoint >= instance.GetMaxMonsterPoint();
    if ((this.m_eMode == EUIOriginMode.MoneyAndFuncButtonWM || this.m_eMode == EUIOriginMode.Show && this.m_eMapMode == EUIOriginMapMode.KingdomMap || this.m_eMode == EUIOriginMode.Show && this.m_eMapMode == EUIOriginMapMode.WorldMap) && flag)
    {
      ((Graphic) this.m_MoraleText).color = this.ResourceSColor;
      ((Component) this.m_MoraleFlash).gameObject.SetActive(instance.MySysSetting.bShowMonsterPointMax && instance.GetTechLevel((ushort) 76) > (byte) 0);
    }
    else
    {
      ((Graphic) this.m_MoraleText).color = Color.white;
      ((Component) this.m_MoraleFlash).gameObject.SetActive(false);
    }
    if (flag && this.m_eMapMode == EUIOriginMapMode.OriginMap)
      ((Component) this.m_MapSwitchImage2).gameObject.SetActive(instance.MySysSetting.bShowMonsterPointMax && instance.GetTechLevel((ushort) 76) > (byte) 0);
    else
      ((Component) this.m_MapSwitchImage2).gameObject.SetActive(false);
  }

  private void UpdateMoney()
  {
    DataManager instance = DataManager.Instance;
    this.DiamondString.ClearString();
    GameConstants.FormatResourceValue(this.DiamondString, DataManager.Instance.RoleAttr.Diamond);
    this.m_DiamondText.text = this.DiamondString.ToString();
    this.m_DiamondText.SetAllDirty();
    this.m_DiamondText.cachedTextGenerator.Invalidate();
    this.MoraleString.ClearString();
    ((Component) this.m_MoraleForceBlood).gameObject.SetActive(false);
    this.m_MoraleSA2.SetSpriteIndex(0);
    ((Graphic) this.m_MoraleText).color = Color.white;
    if (this.m_eMode == EUIOriginMode.MoneyAndFuncButtonF || this.m_eMode == EUIOriginMode.MoneyF)
    {
      ((Component) this.m_MoraleForceBlood).gameObject.SetActive(true);
      this.m_MoraleSA2.SetSpriteIndex(1);
      this.m_MoraleSA.SetSpriteIndex(2);
      this.m_MoraleIcon.SetNativeSize();
      uint stock = instance.PetResource.Stock;
      uint capacity = instance.PetResource.Capacity;
      this.m_MoraleForceBlood.fillAmount = (float) stock / (float) capacity;
      if (stock >= capacity)
        ((Graphic) this.m_MoraleText).color = this.ResourceSColor;
      else
        ((Graphic) this.m_MoraleText).color = Color.white;
      GameConstants.FormatResourceValue(this.MoraleString, stock);
    }
    else if (this.m_eMode == EUIOriginMode.MoneyAndFuncButtonWM || this.m_eMode == EUIOriginMode.Show && this.m_eMapMode == EUIOriginMapMode.KingdomMap || this.m_eMode == EUIOriginMode.Show && this.m_eMapMode == EUIOriginMapMode.WorldMap)
    {
      this.m_MoraleSA.SetSpriteIndex(1);
      this.m_MoraleIcon.SetNativeSize();
      GameConstants.FormatResourceValue(this.MoraleString, instance.RoleAttr.MonsterPoint);
    }
    else
    {
      this.m_MoraleSA.SetSpriteIndex(0);
      this.m_MoraleIcon.SetNativeSize();
      this.MoraleString.IntToFormat((long) instance.RoleAttr.Morale);
      this.MoraleString.IntToFormat((long) DataManager.Instance.HeroMaxMorale);
      if (GUIManager.Instance.IsArabic)
        this.MoraleString.AppendFormat("{1}/{0}");
      else
        this.MoraleString.AppendFormat("{0}/{1}");
    }
    this.m_MoraleText.text = this.MoraleString.ToString();
    this.m_MoraleText.SetAllDirty();
    this.m_MoraleText.cachedTextGenerator.Invalidate();
    this.CheckMonsterPoint();
  }

  private void UpdateResource()
  {
    uint num1 = 0;
    uint num2 = 4200000000;
    DataManager instance = DataManager.Instance;
    for (int index = 0; index < this.m_ResourceBar.Length; ++index)
    {
      switch (index)
      {
        case 0:
          num1 = instance.Resource[0].Stock;
          num2 = instance.Resource[0].Capacity;
          break;
        case 1:
          num1 = instance.Resource[1].Stock;
          num2 = instance.Resource[1].Capacity;
          break;
        case 2:
          num1 = instance.Resource[2].Stock;
          num2 = instance.Resource[2].Capacity;
          break;
        case 3:
          num1 = instance.Resource[3].Stock;
          num2 = instance.Resource[3].Capacity;
          break;
        case 4:
          num1 = instance.Resource[4].Stock;
          num2 = instance.Resource[4].Capacity;
          break;
      }
      this.m_ResourceBar[index].fillAmount = (float) num1 / (float) num2;
      this.m_ResourceColor[index] = num1 < num2 ? Color.white : this.ResourceSColor;
      if (index != 0 || instance.Resource[0].GetSpeed() >= 0L)
        ((Graphic) this.m_ResourceText[index]).color = this.m_ResourceColor[index];
      this.m_ResourceStr[index].Length = 0;
      GameConstants.FormatResourceValue(this.m_ResourceStr[index], num1);
      this.m_ResourceText[index].text = this.m_ResourceStr[index].ToString();
      this.m_ResourceText[index].SetAllDirty();
      this.m_ResourceText[index].cachedTextGenerator.Invalidate();
    }
  }

  private void UpdateQueue()
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    Vector2 zero = Vector2.zero;
    this.m_QueueCount = instance1.curQueueBarDataCount;
    for (int queueCount = (int) this.m_QueueCount; queueCount < this.m_QueueTimeBar.Length; ++queueCount)
    {
      if (this.m_QueueTimeBar[queueCount].gameObject.activeSelf)
        this.m_QueueTimeBar[queueCount].gameObject.SetActive(false);
      if (this.m_QueueTimeBar[queueCount].m_ListID != 0)
        instance2.RemoverTimeBaarToList(this.m_QueueTimeBar[queueCount]);
    }
    QueueBarData queueBarData1 = DataManager.Instance.queueBarData[17];
    if (this.m_QueueCount <= (byte) 1 && queueBarData1.bActive || this.m_QueueCount == (byte) 0)
    {
      this.QueuePanelSetActive(false);
      if (this.m_QueueCount > (byte) 0)
      {
        ((Component) this.m_QueueButton).gameObject.SetActive(true);
        ((Component) this.m_QueueIcon).gameObject.SetActive(true);
        ((Component) this.m_QueueIcon).transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        ((Graphic) this.m_QueueIcon).rectTransform.anchoredPosition = ((Graphic) this.m_QueueIcon).rectTransform.anchoredPosition with
        {
          x = 24f
        };
      }
      else
      {
        ((Component) this.m_QueueButton).gameObject.SetActive(false);
        ((Component) this.m_QueueIcon).gameObject.SetActive(false);
        ((Component) this.m_QueueIcon).transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
        ((Graphic) this.m_QueueIcon).rectTransform.anchoredPosition = ((Graphic) this.m_QueueIcon).rectTransform.anchoredPosition with
        {
          x = 36.6f
        };
      }
      ((Component) this.m_QueueCountBox).gameObject.SetActive(false);
    }
    else
    {
      StringManager.IntToStr(this.m_QueueCountStr, !queueBarData1.bActive ? (long) this.m_QueueCount : (long) ((int) this.m_QueueCount - 1));
      this.m_QueueCountText.text = this.m_QueueCountStr.ToString();
      this.m_QueueCountText.SetAllDirty();
      this.m_QueueCountText.cachedTextGenerator.Invalidate();
      zero.Set(Door.GetRedBackWidth(this.m_QueueCountText.preferredWidth), 51f);
      this.m_QueueCountBox.sizeDelta = zero;
      ((Component) this.m_QueueButton).gameObject.SetActive(true);
      ((Component) this.m_QueueIcon).gameObject.SetActive(true);
      if (!((Component) this.m_QueuePanel).gameObject.activeSelf)
        ((Component) this.m_QueueCountBox).gameObject.SetActive(true);
      else
        ((Component) this.m_QueueCountBox).gameObject.SetActive(false);
    }
    StringBuilder sb = new StringBuilder();
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    bool bOpen = false;
    for (int index1 = 0; index1 < (int) this.m_QueueCount && index1 < this.m_QueueTimeBar.Length; ++index1)
    {
      byte eIndex = instance1.sortedQueueBarData[index1];
      QueueBarData queueBarData2 = instance1.queueBarData[(int) eIndex];
      if (index1 == 0)
        this.CheckSpQueueBar();
      else
        this.m_QueueTimeBar[index1].gameObject.SetActive(true);
      if (queueBarData2.eKind == EQueueBarKind.Idle)
      {
        this.m_QueueTimeBar[index1].m_TimeBarID = (int) eIndex;
        ((Component) this.m_QueueTimeBar[index1].m_FuntionBtn).gameObject.SetActive(false);
        ((Behaviour) this.m_QueueTimeBar[index1].m_TimeText).enabled = false;
        this.m_QueueTimeBar[index1].SetValue(0L, 0L);
        this.m_QueueTimeBar[index1].m_SliderImage.fillAmount = 0.0f;
        ((Graphic) this.m_QueueTimeBar[index1].m_TitleText).color = Color.yellow;
        if (queueBarData2.StartTime == 1L)
        {
          this.m_QueueTimeBar[index1].m_Titles[0] = instance1.mStringTable.GetStringByID(782U);
          this.m_QueueTimeBar[index1].m_Titles[1] = instance1.mStringTable.GetStringByID(782U);
          this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon001");
        }
        else if (queueBarData2.StartTime == 2L)
        {
          this.m_QueueTimeBar[index1].m_Titles[0] = instance1.mStringTable.GetStringByID(783U);
          this.m_QueueTimeBar[index1].m_Titles[1] = instance1.mStringTable.GetStringByID(783U);
          this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon015");
        }
        else if (queueBarData2.StartTime == 3L)
        {
          this.m_QueueTimeBar[index1].m_Titles[0] = instance1.mStringTable.GetStringByID(784U);
          this.m_QueueTimeBar[index1].m_Titles[1] = instance1.mStringTable.GetStringByID(784U);
          this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon001");
        }
        else
          this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon001");
        this.m_QueueTimeBar[index1].SetTitleText();
        eTimerSpriteType queueBarSpriteType = instance1.GetQueueBarSpriteType((EQueueBarIndex) eIndex);
        instance2.SetTimerSpriteType(this.m_QueueTimeBar[index1], queueBarSpriteType);
      }
      else
      {
        ((Component) this.m_QueueTimeBar[index1].m_FuntionBtn).gameObject.SetActive(true);
        ((Behaviour) this.m_QueueTimeBar[index1].m_TimeText).enabled = true;
        ((Graphic) this.m_QueueTimeBar[index1].m_TitleText).color = Color.white;
        eTimerSpriteType queueBarSpriteType = instance1.GetQueueBarSpriteType((EQueueBarIndex) eIndex);
        instance1.GetQueueBarTitle((EQueueBarIndex) eIndex, sb, ref empty1, ref empty2);
        switch (queueBarSpriteType)
        {
          case eTimerSpriteType.Free:
            instance2.SetTimerBar(this.m_QueueTimeBar[index1], queueBarData2.StartTime, queueBarData2.StartTime + (long) queueBarData2.TotalTime, 0L, eTimeBarType.IconType, empty1, empty2);
            break;
          case eTimerSpriteType.RallyStanby:
          case eTimerSpriteType.RallyMarching:
          case eTimerSpriteType.RallyAttack:
            if (DataManager.Instance.ServerTime > queueBarData2.StartTime + (long) queueBarData2.TotalTime)
            {
              instance2.SetTimerBar(this.m_QueueTimeBar[index1], queueBarData2.StartTime, queueBarData2.StartTime + (long) queueBarData2.TotalTime, 0L, eTimeBarType.IconType, empty1, empty2);
              break;
            }
            instance2.SetTimerBar(this.m_QueueTimeBar[index1], queueBarData2.StartTime, queueBarData2.StartTime + (long) queueBarData2.TotalTime, queueBarData2.StartTime + (long) queueBarData2.TotalTime - 1L, eTimeBarType.IconType, empty1, empty2);
            break;
          case eTimerSpriteType.RallyCountDown:
            if (DataManager.Instance.ServerTime > queueBarData2.StartTime + (long) queueBarData2.TotalTime)
            {
              instance2.SetTimerBar(this.m_QueueTimeBar[index1], queueBarData2.StartTime, queueBarData2.StartTime + (long) queueBarData2.TotalTime, 0L, eTimeBarType.IconType, empty1, empty2);
              break;
            }
            instance2.SetTimerBar(this.m_QueueTimeBar[index1], queueBarData2.StartTime, queueBarData2.StartTime + (long) queueBarData2.TotalTime, queueBarData2.StartTime + (long) queueBarData2.TotalTime - 1L, eTimeBarType.IconType, empty1, empty2);
            break;
          default:
            if (DataManager.Instance.ServerTime <= queueBarData2.StartTime + (long) queueBarData2.TotalTime - (long) instance1.FreeCompletePeriod)
            {
              instance2.SetTimerBar(this.m_QueueTimeBar[index1], queueBarData2.StartTime, queueBarData2.StartTime + (long) queueBarData2.TotalTime, queueBarData2.StartTime + (long) queueBarData2.TotalTime - (long) instance1.FreeCompletePeriod, eTimeBarType.IconType, empty1, empty2);
              break;
            }
            goto case eTimerSpriteType.Free;
        }
        if (queueBarSpriteType == eTimerSpriteType.Mobilization_fail || queueBarSpriteType == eTimerSpriteType.Mobilization_Report)
        {
          ((Behaviour) this.m_QueueTimeBar[index1].m_TimeText).enabled = false;
          this.m_QueueTimeBar[index1].SetValue(0L, 0L);
          this.m_QueueTimeBar[index1].m_SliderImage.fillAmount = 0.0f;
        }
        if (queueBarSpriteType == eTimerSpriteType.NPCRewardEnd)
          ((Behaviour) this.m_QueueTimeBar[index1].m_TimeText).enabled = false;
        this.m_QueueTimeBar[index1].m_TimeBarID = (int) eIndex;
        bool flag = this.m_QueueTimeBar[index1].m_TimerSpriteType == eTimerSpriteType.Free;
        instance2.SetTimerSpriteType(this.m_QueueTimeBar[index1], queueBarSpriteType);
        if (instance1.MySysSetting.bShowTimeBar && !bOpen && !instance1.bBeginReLogin && (!flag && queueBarSpriteType == eTimerSpriteType.Free || instance1.bNewQueue))
        {
          bOpen = true;
          instance1.bNewQueue = false;
        }
        switch (queueBarData2.eKind)
        {
          case EQueueBarKind.Building:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon001");
            if (NewbieManager.IsTeachWorking(ETeachKind.TURBO))
            {
              NewbieManager.CheckTeach(ETeachKind.TURBO, (object) this.m_QueueTimeBar[index1]);
              break;
            }
            break;
          case EQueueBarKind.Researching:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon015");
            break;
          case EQueueBarKind.Marching:
            int index2 = (int) eIndex - 2;
            this.m_QueueTimeBarIcon[index1].sprite = index2 >= instance1.MarchEventData.Length || index2 < 0 ? this.LoadSprite("icon016") : (DataManager.Instance.MarchEventData[index2].Type != EMarchEventType.EMET_RallyStanby ? (instance1.MarchEventData[index2].Type < EMarchEventType.EMET_AttackMarching || instance1.MarchEventData[index2].Type > EMarchEventType.EMET_DeliverMarching ? (instance1.MarchEventData[index2].Type < EMarchEventType.EMET_AttackReturn || instance1.MarchEventData[index2].Type > EMarchEventType.EMET_HitMonsterRetreat ? this.LoadSprite("icon016") : this.LoadSprite("icon017")) : this.LoadSprite("icon016")) : this.LoadSprite("icon018"));
            break;
          case EQueueBarKind.Training:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon002");
            break;
          case EQueueBarKind.HeroEnhance:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon009");
            break;
          case EQueueBarKind.HeroEvolution:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon010");
            break;
          case EQueueBarKind.Treatmenting:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon003");
            break;
          case EQueueBarKind.Manufacturing:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon004");
            break;
          case EQueueBarKind.WallRepair:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon011");
            break;
          case EQueueBarKind.Mission:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon014");
            break;
          case EQueueBarKind.Forging:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon013");
            break;
          case EQueueBarKind.JoinedRally:
            int index3 = (int) eIndex - 22;
            this.m_QueueTimeBarIcon[index1].sprite = index3 >= instance1.MarchEventData.Length || index3 < 0 ? this.LoadSprite("icon016") : (DataManager.Instance.MarchEventData[index3].Type == EMarchEventType.EMET_RallyReturn || DataManager.Instance.MarchEventData[index3].Type == EMarchEventType.EMET_RallyRetreat || DataManager.Instance.MarchEventData[index3].Type == EMarchEventType.EMET_RallyAttack ? this.LoadSprite("icon016") : this.LoadSprite("icon018"));
            break;
          case EQueueBarKind.LordReturn:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon017");
            break;
          case EQueueBarKind.HideArmy:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon016");
            break;
          case EQueueBarKind.Mobilization:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("UI_mall_box_a_02");
            break;
          case EQueueBarKind.NpcReward:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon049");
            break;
          case EQueueBarKind.PetFusion:
            FusionData recordByKey = DataManager.Instance.FusionDataTable.GetRecordByKey(PetManager.Instance.ItemCraftID);
            this.m_QueueTimeBarIcon[index1].sprite = recordByKey.Fusion_Kind != (byte) 0 ? this.LoadSprite("icon057") : this.LoadSprite("icon051");
            break;
          case EQueueBarKind.PetEvolution:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon054");
            break;
          case EQueueBarKind.PetMarch:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("icon054");
            break;
          default:
            this.m_QueueTimeBarIcon[index1].sprite = this.LoadSprite("UI_main_res_house");
            break;
        }
      }
      this.m_QueueTimeBarIcon[index1].SetNativeSize();
      ((Transform) ((Graphic) this.m_QueueTimeBarIcon[index1]).rectTransform).localScale = new Vector3(0.8f, 0.8f, 0.8f);
      this.m_QueueTimeBar[index1].SetFlashCount(1f, this.m_QueueTimeBar[index1].GetTextIndex());
    }
    if (!bOpen)
      return;
    this.ForceQueueBarOpenClose(bOpen);
  }

  private void UpdateMissionInfo()
  {
    if ((UnityEngine.Object) this.m_MissionHintTrans == (UnityEngine.Object) null)
      return;
    this.m_MissionHintTrans.gameObject.SetActive(DataManager.Instance.MySysSetting.bShowMission);
    if (!this.m_MissionHintTrans.gameObject.activeSelf)
      return;
    MissionManager missionDataManager = DataManager.MissionDataManager;
    ushort commandMissionId = missionDataManager.GetReCommandMissionID();
    if (this.m_eMapMode != EUIOriginMapMode.OriginMap || missionDataManager.RewardList.Priority.Count == 0 && commandMissionId == ushort.MaxValue)
    {
      this.m_MissionHintTrans.gameObject.SetActive(false);
    }
    else
    {
      this.m_MissionHintTrans.gameObject.SetActive(true);
      ManorAimTbl recordByKey1 = missionDataManager.ManorAimTable.GetRecordByKey(commandMissionId);
      ushort InKey;
      ManorAimTbl recordByKey2;
      if (missionDataManager.GetRewardCount(1) > (byte) 0 && (commandMissionId == ushort.MaxValue || (int) recordByKey1.UIPriority > (int) missionDataManager.RewardList.Priority[0]))
      {
        this.m_MissionHintSA.SetSpriteIndex(1);
        InKey = missionDataManager.GetMissionID(missionDataManager.RewardList.Priority[0]);
        recordByKey2 = missionDataManager.ManorAimTable.GetRecordByKey(InKey);
        this.m_MissionHinttextL.text = DataManager.Instance.mStringTable.GetStringByID(1520U);
        this.m_MissionBtn.m_BtnID2 = 1;
        ((Behaviour) this.NewMissionReward).enabled = true;
        ((Behaviour) this.m_MissionBtn).enabled = true;
        this.RewardTime = 0.0f;
      }
      else
      {
        this.m_MissionBtn.m_BtnID2 = 0;
        ((Behaviour) this.NewMissionReward).enabled = false;
        InKey = missionDataManager.GetReCommandMissionID();
        recordByKey2 = missionDataManager.ManorAimTable.GetRecordByKey(InKey);
        switch ((eMissionKind) ((int) recordByKey2.MissionKind - 1))
        {
          case eMissionKind.Record:
            if (recordByKey2.Parm1 >= (ushort) 21 && recordByKey2.Parm1 <= (ushort) 27 || recordByKey2.Parm1 == (ushort) 7 || recordByKey2.Parm1 == (ushort) 19)
            {
              this.m_MissionHinttextL.text = DataManager.Instance.mStringTable.GetStringByID(834U);
              this.m_MissionHintSA.SetSpriteIndex(2);
              ((Behaviour) this.m_MissionBtn).enabled = true;
              break;
            }
            this.m_MissionHinttextL.text = DataManager.Instance.mStringTable.GetStringByID(1519U);
            this.m_MissionHintSA.SetSpriteIndex(0);
            ((Behaviour) this.m_MissionBtn).enabled = false;
            break;
          case eMissionKind.Mark:
            if (recordByKey2.Parm1 == (ushort) 131 || recordByKey2.Parm1 == (ushort) 132)
            {
              this.m_MissionHinttextL.text = DataManager.Instance.mStringTable.GetStringByID(834U);
              this.m_MissionHintSA.SetSpriteIndex(2);
              ((Behaviour) this.m_MissionBtn).enabled = true;
              break;
            }
            this.m_MissionHinttextL.text = DataManager.Instance.mStringTable.GetStringByID(1519U);
            this.m_MissionHintSA.SetSpriteIndex(0);
            ((Behaviour) this.m_MissionBtn).enabled = false;
            break;
          default:
            this.m_MissionHinttextL.text = DataManager.Instance.mStringTable.GetStringByID(834U);
            this.m_MissionHintSA.SetSpriteIndex(2);
            ((Behaviour) this.m_MissionBtn).enabled = true;
            break;
        }
      }
      this.m_MissionScale.enabled = ((Behaviour) this.m_MissionBtn).enabled;
      this.m_MissionBtn.m_BtnID3 = (int) InKey;
      missionDataManager.GetNarrative(this.m_MissionHintStrR, ref recordByKey2);
      this.m_MissionHinttextR.text = this.m_MissionHintStrR.ToString();
      this.m_MissionHinttextR.SetAllDirty();
      this.m_MissionHinttextR.cachedTextGenerator.Invalidate();
      this.m_MissionHinttextR.cachedTextGeneratorForLayout.Invalidate();
      Vector2 sizeDelta = this.m_MissionHintRRC.sizeDelta;
      bool flag = false;
      float preferredWidth = this.m_MissionHinttextR.preferredWidth;
      if (GUIManager.Instance.IsArabic)
      {
        for (; (double) preferredWidth > 385.0; preferredWidth = this.m_MissionHinttextR.preferredWidth)
        {
          flag = true;
          this.m_MissionHintStrR.Substring(this.m_MissionHintStrR.ToString(), 0, this.m_MissionHintStrR.Length - 2);
          this.m_MissionHinttextR.text = this.m_MissionHintStrR.ToString();
          this.m_MissionHinttextR.SetAllDirty();
          this.m_MissionHinttextR.cachedTextGenerator.Invalidate();
          this.m_MissionHinttextR.cachedTextGeneratorForLayout.Invalidate();
        }
      }
      else
      {
        int num = 0;
        while ((double) preferredWidth > 385.0)
        {
          this.m_MissionHintStrR.Substring(this.m_MissionHintStrR.ToString(), 0, this.m_MissionHintStrR.Length - 2);
          this.m_MissionHinttextR.text = this.m_MissionHintStrR.ToString();
          ((Graphic) this.m_MissionHinttextR).SetLayoutDirty();
          this.m_MissionHinttextR.cachedTextGeneratorForLayout.Invalidate();
          preferredWidth = this.m_MissionHinttextR.preferredWidth;
          flag = true;
          ++num;
        }
        Debug.Log((object) ("Loop = " + (object) num));
      }
      if (flag)
      {
        this.m_MissionHintStrR.Append("...");
        this.m_MissionHinttextR.text = this.m_MissionHintStrR.ToString();
        this.m_MissionHinttextR.SetAllDirty();
        this.m_MissionHinttextR.cachedTextGenerator.Invalidate();
      }
      sizeDelta.x = 140f + preferredWidth;
      this.m_MissionHintRRC.sizeDelta = sizeDelta;
      this.m_MissionHintRRC.anchoredPosition = this.m_MissionHintRRC.anchoredPosition with
      {
        x = this.m_MissionHintRRC.sizeDelta.x - 712f
      };
    }
  }

  public void OnTimer(UITimeBar sender)
  {
  }

  public void OnNotify(UITimeBar sender) => DataManager.Instance.bNeedSortQueueBarData = true;

  public void Onfunc(UITimeBar sender)
  {
    eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType((EQueueBarIndex) sender.m_TimeBarID);
    if (sender.m_TimeBarID == 0)
    {
      switch (queueBarSpriteType)
      {
        case eTimerSpriteType.Speed:
          this.OpenMenu(EGUIWindow.UI_BagFilter, 2);
          break;
        case eTimerSpriteType.Help:
          DataManager.Instance.SendAllianceHelp((byte) 1);
          break;
        case eTimerSpriteType.Free:
          GUIManager.Instance.BuildingData.sendBuildCompleteFree();
          break;
      }
    }
    else if (sender.m_TimeBarID == 1)
    {
      switch (queueBarSpriteType)
      {
        case eTimerSpriteType.Speed:
          this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 1);
          break;
        case eTimerSpriteType.Help:
          DataManager.Instance.SendAllianceHelp((byte) 0);
          break;
        case eTimerSpriteType.Free:
          DataManager.Instance.sendTechnologyCompleteFree();
          break;
      }
    }
    else if (sender.m_TimeBarID >= 2 && sender.m_TimeBarID <= 9)
    {
      int index = Mathf.Clamp(sender.m_TimeBarID - 2, 0, 7);
      if (DataManager.Instance.MarchEventData[index].Type == EMarchEventType.EMET_RallyStanby)
        this.OpenMenu(EGUIWindow.UI_Rally, 100, index);
      else
        this.OpenMenu(EGUIWindow.UI_BagFilter, 2, sender.m_TimeBarID);
    }
    else if (sender.m_TimeBarID >= 22 && sender.m_TimeBarID <= 29)
      this.OpenMenu(EGUIWindow.UI_Rally, 100, Mathf.Clamp(sender.m_TimeBarID - 22, 0, 7));
    else if (sender.m_TimeBarID == 10)
    {
      if (queueBarSpriteType != eTimerSpriteType.Speed)
        return;
      this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 10);
    }
    else if (sender.m_TimeBarID == 11)
    {
      if (queueBarSpriteType == eTimerSpriteType.Speed)
      {
        this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 11);
      }
      else
      {
        if (queueBarSpriteType != eTimerSpriteType.Free)
          return;
        DataManager.Instance.SendHeroEnhance_Free();
      }
    }
    else if (sender.m_TimeBarID == 12)
    {
      if (queueBarSpriteType == eTimerSpriteType.Speed)
      {
        this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 12);
      }
      else
      {
        if (queueBarSpriteType != eTimerSpriteType.Free)
          return;
        DataManager.Instance.SendHeroStarUp_Free();
      }
    }
    else if (sender.m_TimeBarID == 16)
    {
      if (queueBarSpriteType == eTimerSpriteType.Speed)
      {
        this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 16);
      }
      else
      {
        if (queueBarSpriteType != eTimerSpriteType.Free)
          return;
        DataManager.Instance.SendHeroStarUp_Free();
      }
    }
    else if (sender.m_TimeBarID == 14)
    {
      if (queueBarSpriteType != eTimerSpriteType.Speed)
        return;
      this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 14);
    }
    else if (sender.m_TimeBarID == 13)
    {
      if (queueBarSpriteType != eTimerSpriteType.Speed)
        return;
      this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 13);
    }
    else if (sender.m_TimeBarID == 15)
    {
      if (queueBarSpriteType != eTimerSpriteType.Speed)
        return;
      this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 15);
    }
    else if (sender.m_TimeBarID == 19)
    {
      if (queueBarSpriteType != eTimerSpriteType.Speed)
        return;
      this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 19);
    }
    else if (sender.m_TimeBarID == 20)
    {
      if (queueBarSpriteType != eTimerSpriteType.Speed)
        return;
      this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 20);
    }
    else if (sender.m_TimeBarID == 18)
    {
      if (queueBarSpriteType != eTimerSpriteType.Speed)
        return;
      this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 18);
    }
    else if (sender.m_TimeBarID == 30)
    {
      if (queueBarSpriteType != eTimerSpriteType.Speed)
        return;
      this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 30);
    }
    else if (sender.m_TimeBarID == 21)
    {
      if (queueBarSpriteType != eTimerSpriteType.Speed)
        return;
      this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 21);
    }
    else if (sender.m_TimeBarID == 31)
      HideArmyManager.Instance.OpenHideArmyUI();
    else if (sender.m_TimeBarID == 32)
      this.OpenMenu(EGUIWindow.UI_Alliance_Mobilization);
    else if (sender.m_TimeBarID == 33)
      this.OpenMenu(EGUIWindow.UIAlchemy, bCameraMode: true);
    else if (sender.m_TimeBarID == 34)
    {
      if (queueBarSpriteType != eTimerSpriteType.Speed)
        return;
      this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 34);
    }
    else if (sender.m_TimeBarID == 35)
    {
      if (queueBarSpriteType == eTimerSpriteType.Speed)
      {
        this.OpenMenu(EGUIWindow.UI_BagFilter, 2, 35);
      }
      else
      {
        if (queueBarSpriteType != eTimerSpriteType.Free)
          return;
        PetManager.Instance.Send_PET_STARUP_FREECOMPLETE();
      }
    }
    else
    {
      if (sender.m_TimeBarID != 36)
        return;
      this.GoToGroup(9, (byte) 0);
    }
  }

  public void OnCancel(UITimeBar sender)
  {
  }

  public void CheckandShowFuncBtnCount(int tmpIndex, bool bShow = false)
  {
    switch (tmpIndex)
    {
      case -1:
        bool flag = false;
        if (this.m_MissionAlert.activeSelf || this.CheckShowRedPocket() || this.CheckShowLiveImg() || this.CheckShowLiveAlert())
          flag = true;
        for (int index = 0; index < 6 && !flag; ++index)
        {
          if (this.m_FuncBtnCount[index] > 0)
            flag = true;
        }
        if (this.m_bShowFuncButton == (byte) 0 && flag)
        {
          if (!this.m_ShowFuncButton.activeInHierarchy || this.m_ShowFuncButtonAlert.activeInHierarchy && ((Component) this.SPGiftImgMain).gameObject.activeInHierarchy && ((Component) this.LiveImgMain).gameObject.activeInHierarchy)
            break;
          if (this.CheckShowRedPocket())
          {
            ((Component) this.LiveImgMain).gameObject.SetActive(false);
            this.m_ShowFuncButtonAlert.SetActive(false);
            this.SetSPGiftImgSprite(true);
            ((Component) this.SPGiftImgMain).gameObject.SetActive(true);
            break;
          }
          ((Component) this.SPGiftImgMain).gameObject.SetActive(false);
          if (this.CheckShowLiveImg())
          {
            this.m_ShowFuncButtonAlert.SetActive(false);
            if (GUIManager.Instance.StopShowLiveScale > (byte) 0)
            {
              this.LiveImgMainTW.enabled = false;
              this.LiveImgMainTW.SetCurrentValueToStart();
              this.LiveImgMainTWF.enabled = false;
              this.LiveImgMainTWF.SetCurrentValueToStart();
            }
            else
            {
              this.LiveImgMainTW.enabled = true;
              this.LiveImgMainTWF.enabled = true;
            }
            ((Component) this.LiveImgMain).gameObject.SetActive(true);
            break;
          }
          ((Component) this.LiveImgMain).gameObject.SetActive(false);
          this.m_ShowFuncButtonAlert.SetActive(true);
          break;
        }
        if (this.m_ShowFuncButtonAlert.activeInHierarchy)
          this.m_ShowFuncButtonAlert.SetActive(false);
        if (((Component) this.SPGiftImgMain).gameObject.activeInHierarchy)
          ((Component) this.SPGiftImgMain).gameObject.SetActive(false);
        if (!((Component) this.LiveImgMain).gameObject.activeInHierarchy)
          break;
        ((Component) this.LiveImgMain).gameObject.SetActive(false);
        break;
      case 0:
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
        bool activeInHierarchy = ((Component) this.m_FuncBtnCountRC[tmpIndex]).gameObject.activeInHierarchy;
        if (bShow)
        {
          if (this.m_FuncBtnCount[tmpIndex] <= 0 || activeInHierarchy)
            break;
          ((Component) this.m_FuncBtnCountRC[tmpIndex]).gameObject.SetActive(true);
          break;
        }
        if (!activeInHierarchy)
          break;
        ((Component) this.m_FuncBtnCountRC[tmpIndex]).gameObject.SetActive(true);
        break;
    }
  }

  public void CheckShowMissionFlash()
  {
    if (DataManager.MissionDataManager.AllianceMissionBonusRate > (ushort) 100)
      this.m_MissionFlash.SetActive(true);
    else
      this.m_MissionFlash.SetActive(false);
  }

  public void SetPVPWonderID(ushort WonderID)
  {
    if (WonderID < (ushort) 40 && DataManager.MapDataController.YolkPointTable[(int) WonderID].WonderState > (byte) 0 && DataManager.MapDataController.YolkPointTable[(int) WonderID].WonderState != byte.MaxValue)
    {
      this.PVPWonderID = WonderID;
      this.ShowPVPTime();
    }
    else
      this.ClearPVPWonderID();
  }

  public void ClearPVPWonderID()
  {
    this.PVPWonderID = (ushort) 40;
    this.HidePVPTime();
  }

  public void ShowPVPTime()
  {
    if (!this.bHideMainMenu || this.PVPWonderID == (ushort) 40)
      return;
    this.PVPTimeObj.SetActive(true);
    this.SetPVPObj();
    this.LoadPVPImage();
    this.UpdatePVPTime();
  }

  public void HidePVPTime()
  {
    if ((UnityEngine.Object) this.PVPTimeObj == (UnityEngine.Object) null)
      return;
    this.PVPTimeObj.SetActive(false);
  }

  public void LoadPVPImage()
  {
    if ((UnityEngine.Object) this.TileMapController != (UnityEngine.Object) null)
    {
      this.PVPWonderImg.sprite = this.TileMapController.yolk.getMapTileYolkSprite((byte) this.PVPWonderID);
      Material tileYolkMaterial = this.TileMapController.yolk.getMapTileYolkMaterial((byte) this.PVPWonderID);
      if ((UnityEngine.Object) tileYolkMaterial == (UnityEngine.Object) null || (UnityEngine.Object) this.PVPWonderImg.sprite == (UnityEngine.Object) null)
      {
        ((Behaviour) this.PVPWonderImg).enabled = false;
      }
      else
      {
        ((Graphic) this.PVPWonderImg).rectTransform.sizeDelta = new Vector2(this.PVPWonderImg.sprite.rect.width, this.PVPWonderImg.sprite.rect.height);
        if ((UnityEngine.Object) this.PVPWonderImgMaterial == (UnityEngine.Object) null)
        {
          this.PVPWonderImgMaterial = new Material(tileYolkMaterial);
          this.PVPWonderImgMaterial.renderQueue = 3000;
        }
        else
          this.PVPWonderImgMaterial.SetTexture("_AlphaTex", tileYolkMaterial.GetTexture("_AlphaTex"));
        ((MaskableGraphic) this.PVPWonderImg).material = this.PVPWonderImgMaterial;
        ((Behaviour) this.PVPWonderImg).enabled = true;
      }
    }
    else
      ((Behaviour) this.PVPWonderImg).enabled = false;
  }

  public void UpdatePVPTime()
  {
    if (this.PVPWonderID >= (ushort) 40)
      return;
    long sec = (long) DataManager.MapDataController.YolkPointTable[(int) this.PVPWonderID].StateBegin + (long) DataManager.MapDataController.YolkPointTable[(int) this.PVPWonderID].StateDuring - DataManager.Instance.ServerTime;
    if (sec < 0L)
    {
      this.ClearPVPWonderID();
    }
    else
    {
      if (!((Behaviour) this.PVPWonderImg).enabled)
        this.LoadPVPImage();
      this.PVPStr.Length = 0;
      GameConstants.GetTimeString(this.PVPStr, (uint) sec);
      this.PVPTimeText.text = this.PVPStr.ToString();
      this.PVPTimeText.SetAllDirty();
      this.PVPTimeText.cachedTextGenerator.Invalidate();
    }
  }

  public void SetPVPObj()
  {
    if ((UnityEngine.Object) this.PVPTimeObj == (UnityEngine.Object) null || (UnityEngine.Object) this.KVKTimeObj == (UnityEngine.Object) null)
      return;
    if (this.PVPTimeObj.activeInHierarchy && this.KVKTimeObj.activeInHierarchy)
      ((RectTransform) this.PVPTimeObj.transform).anchoredPosition = new Vector2(11f, -70f);
    else
      ((RectTransform) this.PVPTimeObj.transform).anchoredPosition = new Vector2(11f, -7f);
  }

  public void ShowKVKTime()
  {
    if ((UnityEngine.Object) this.KVKTimeObj == (UnityEngine.Object) null)
      return;
    ActivityManager instance = ActivityManager.Instance;
    MapManager mapDataController = DataManager.MapDataController;
    ActivityDataType activityDataType = instance.KvKActivityData[4];
    if (this.bHideMainMenu && instance.KVKHuntCircleMin != (ushort) 0 && instance.IsInKvK((ushort) 0, true) && instance.IsMatchKvk() && (this.m_eMapMode == EUIOriginMapMode.WorldMap || mapDataController.IsEnemy(mapDataController.FocusKingdomID) || (int) mapDataController.kingdomData.kingdomID == (int) mapDataController.FocusKingdomID) && instance.KVKReTime < activityDataType.EventBeginTime + (long) activityDataType.EventReqiureTIme)
    {
      this.KVKTimeObj.SetActive(true);
      this.SetPVPObj();
      this.UpdateKVKTime();
    }
    else
      this.HideKVKTime();
  }

  public void HideKVKTime()
  {
    if ((UnityEngine.Object) this.KVKTimeObj == (UnityEngine.Object) null)
      return;
    this.KVKTimeObj.SetActive(false);
    this.SetPVPObj();
  }

  public void UpdateKVKTime()
  {
    if ((UnityEngine.Object) this.KVKTimeObj == (UnityEngine.Object) null || !this.KVKTimeObj.activeInHierarchy)
      return;
    long sec = ActivityManager.Instance.KVKReTime - ActivityManager.Instance.ServerEventTime;
    if (sec < 0L)
      sec = 0L;
    this.KVKStr.Length = 0;
    GameConstants.GetTimeString(this.KVKStr, (uint) sec);
    this.KVKTimeText.text = this.KVKStr.ToString();
    this.KVKTimeText.SetAllDirty();
    this.KVKTimeText.cachedTextGenerator.Invalidate();
  }

  public void RefreshFuncBtnCount(int tmpIndex = -1, int tmpIndex2 = -1)
  {
    switch (tmpIndex)
    {
      case 0:
        this.m_FuncBtnCount[tmpIndex] = 0;
        DataManager instance = DataManager.Instance;
        if (tmpIndex2 == 0 || tmpIndex2 == -1)
        {
          this.bCanEquip = false;
          this.bCanEvolutionRank = false;
          this.bCanEvolutionStar = false;
          this.bCanRecruit = false;
          Hero recordByKey1;
          for (uint index1 = 0; index1 < instance.CurHeroDataCount && !this.bCanEquip && !this.bCanEvolutionRank && !this.bCanEvolutionStar; ++index1)
          {
            uint key = instance.sortHeroData[(IntPtr) index1];
            if (instance.curHeroData.ContainsKey(key))
            {
              CurHeroData curHeroData = instance.curHeroData[key];
              if (curHeroData.Equip == (byte) 63 && curHeroData.Enhance < (byte) 8 && (int) instance.RoleAttr.EnhanceEventHeroID != (int) curHeroData.ID)
              {
                this.bCanEvolutionRank = true;
                break;
              }
              ushort id = curHeroData.ID;
              recordByKey1 = instance.HeroTable.GetRecordByKey(id);
              ushort curItemQuantity = instance.GetCurItemQuantity(recordByKey1.SoulStone, (byte) 0);
              int index2 = Mathf.Clamp((int) curHeroData.Star, 0, instance.Medal.Length - 1);
              if (curHeroData.Star < (byte) 5 && (int) curItemQuantity >= (int) instance.Medal[index2] && (int) instance.RoleAttr.StarUpEventHeroID != (int) id)
              {
                this.bCanEvolutionStar = true;
                break;
              }
              ushort num1 = 0;
              for (int index3 = 0; index3 < 6 && !this.bCanEquip; ++index3)
              {
                int num2 = (int) curHeroData.Equip >> index3 & 1;
                Enhance recordByKey2 = instance.EnhanceTable.GetRecordByKey(curHeroData.ID);
                if (recordByKey2.EnhanceNumber != null)
                  num1 = recordByKey2.EnhanceNumber[((int) curHeroData.Enhance - 1) * 6 + index3];
                byte needLv = instance.EquipTable.GetRecordByKey(num1).NeedLv;
                if (num2 == 0 && instance.FindItemComposite(num1) && (int) curHeroData.Level >= (int) needLv)
                  this.bCanEquip = true;
              }
            }
          }
          ushort[] numArray = new ushort[5]
          {
            (ushort) 10,
            (ushort) 30,
            (ushort) 80,
            (ushort) 180,
            (ushort) 330
          };
          DataManager.Instance.SortCurItemData();
          ushort num3 = DataManager.Instance.sortItemDataStart[4];
          ushort num4 = DataManager.Instance.sortItemDataCount[4];
          for (int index = (int) num3; index < (int) num4 + (int) num3 && !this.bCanRecruit; ++index)
          {
            ushort num5 = DataManager.Instance.sortItemData[index];
            Equip recordByKey3 = DataManager.Instance.EquipTable.GetRecordByKey(num5);
            if (!DataManager.Instance.curHeroData.ContainsKey((uint) recordByKey3.SyntheticParts[0].SyntheticItem))
            {
              recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(recordByKey3.SyntheticParts[0].SyntheticItem);
              ushort num6 = numArray[(int) recordByKey1.defaultStar - 1];
              if ((int) DataManager.Instance.GetCurItemQuantity(num5, (byte) 0) >= (int) num6)
              {
                this.bCanRecruit = true;
                NewbieManager.CheckNewHero();
              }
            }
          }
        }
        if (tmpIndex2 == 1 || tmpIndex2 != -1)
          ;
        if (GUIManager.Instance.bOpenHeroBtn && (this.bCanEquip || this.bCanEvolutionStar || this.bCanEvolutionRank || this.bCanShowSkillPoint || this.bCanRecruit))
          this.m_FuncBtnCount[tmpIndex] = 1;
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_HeroList, 0);
        break;
      case 2:
        if (this.CheckShowLiveImg())
        {
          if (GUIManager.Instance.StopShowLiveScale > (byte) 0)
          {
            this.LiveImgOtherTW.enabled = false;
            this.LiveImgOtherTW.SetCurrentValueToStart();
            this.LiveImgOtherTWF.enabled = false;
            this.LiveImgOtherTWF.SetCurrentValueToStart();
          }
          else
          {
            this.LiveImgOtherTW.enabled = true;
            this.LiveImgOtherTWF.enabled = true;
          }
          ((Component) this.LiveImgOther).gameObject.SetActive(true);
          this.m_OtherGift.gameObject.SetActive(false);
        }
        else
        {
          ((Component) this.LiveImgOther).gameObject.SetActive(false);
          if (!DataManager.Instance.CheckPrizeFlag((byte) 2) && IGGGameSDK.Instance.m_IGGLoginType != IGGLoginType.Facebook)
            this.m_OtherGift.gameObject.SetActive(true);
          else
            this.m_OtherGift.gameObject.SetActive(false);
        }
        if (this.CheckShowLiveAlert())
          this.m_OtherAlert.SetActive(true);
        else
          this.m_OtherAlert.SetActive(false);
        this.m_FuncBtnCount[tmpIndex] = 0;
        if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 7)
        {
          this.m_FuncBtnCount[tmpIndex] += (int) DataManager.FBMissionDataManager.GetRewardCount();
          break;
        }
        break;
      case 3:
        if (DataManager.Instance.RoleAlliance.Id == 0U && DataManager.Instance.queueBarData[20].bActive)
          DataManager.Instance.SetQueueBarData(EQueueBarIndex.AllianceMission, false, 0L, 0U);
        this.m_FuncBtnCount[tmpIndex] = (int) DataManager.MissionDataManager.GetTotalAccessMissionCount();
        if (DataManager.MissionDataManager.MissionNotice > (byte) 0 || DataManager.MissionDataManager.GetRewardCount(1) > (byte) 0)
          this.m_MissionAlert.SetActive(true);
        else
          this.m_MissionAlert.SetActive(false);
        this.UpdateMissionInfo();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, 16);
        break;
      case 4:
        this.m_FuncBtnCount[tmpIndex] = (int) DataManager.Instance.GetMailboxUnread();
        break;
      case 5:
        this.m_FuncBtnCount[tmpIndex] = 0;
        if (DataManager.Instance.RoleAlliance.Id == 0U)
        {
          this.m_AllianceGift.gameObject.SetActive(false);
          this.m_RallyRecFlash.gameObject.SetActive(false);
          ((Component) this.SPGiftImgAlly).gameObject.SetActive(false);
          break;
        }
        if (GUIManager.Instance.bOpenAllianceBtn)
        {
          this.m_FuncBtnCount[tmpIndex] = (int) DataManager.Instance.RoleAlliance.GiftNum + DataManager.Instance.mHelpDataList.Count;
          if (DataManager.Instance.RoleAlliance.Rank >= AllianceRank.RANK4)
            this.m_FuncBtnCount[tmpIndex] += (int) DataManager.Instance.RoleAlliance.Applicant;
          if (this.CheckShowRedPocket())
          {
            this.SetSPGiftImgSprite(false);
            ((Component) this.SPGiftImgAlly).gameObject.SetActive(true);
            this.m_AllianceGift.gameObject.SetActive(false);
            this.m_FuncBtnCount[tmpIndex] += (int) ActivityGiftManager.Instance.EnableRedPocketNum;
          }
          else
          {
            ((Component) this.SPGiftImgAlly).gameObject.SetActive(false);
            if (DataManager.Instance.RoleAlliance.GiftNum > (ushort) 0)
              this.m_AllianceGift.gameObject.SetActive(true);
            else
              this.m_AllianceGift.gameObject.SetActive(false);
          }
          this.m_FuncBtnCount[tmpIndex] += (int) DataManager.Instance.ActiveRallyRecNum + (int) DataManager.Instance.BeingRallyRecNum;
          if (DataManager.Instance.ActiveRallyRecNum > 0U || DataManager.Instance.BeingRallyRecNum > 0U)
            this.m_RallyRecFlash.gameObject.SetActive(true);
          else
            this.m_RallyRecFlash.gameObject.SetActive(false);
          long num = DataManager.Instance.RoleAlliance.ChatMax - DataManager.Instance.RoleAlliance.ChatId;
          if (num > 0L)
          {
            this.m_FuncBtnCount[tmpIndex] += num <= 20L ? (int) num : 20;
            break;
          }
          break;
        }
        break;
    }
    if (tmpIndex < 0 || tmpIndex >= 6)
      return;
    this.SetFuncBtnCount(tmpIndex);
  }

  private void SetFuncBtnCount(int tmpIndex)
  {
    if (this.m_FuncBtnCount[tmpIndex] > 0)
    {
      if (tmpIndex != 0)
      {
        this.m_FuncBtnCountStr[tmpIndex].ClearString();
        this.m_FuncBtnCountStr[tmpIndex].IntToFormat((long) this.m_FuncBtnCount[tmpIndex]);
        this.m_FuncBtnCountStr[tmpIndex].AppendFormat("{0}");
        this.m_FuncBtnText[tmpIndex].text = this.m_FuncBtnCountStr[tmpIndex].ToString();
        this.m_FuncBtnText[tmpIndex].SetAllDirty();
        this.m_FuncBtnText[tmpIndex].cachedTextGenerator.Invalidate();
        this.m_FuncBtnText[tmpIndex].cachedTextGeneratorForLayout.Invalidate();
        this.m_FuncBtnCountRC[tmpIndex].sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_FuncBtnText[tmpIndex].preferredWidth), 51f);
      }
      ((Component) this.m_FuncBtnCountRC[tmpIndex]).gameObject.SetActive(true);
    }
    else
      ((Component) this.m_FuncBtnCountRC[tmpIndex]).gameObject.SetActive(false);
    this.CheckandShowFuncBtnCount(-1);
  }

  public void CheckTroopsState()
  {
    int troopsCount = GUIManager.Instance.m_TroopsCount;
    if (troopsCount > 0)
    {
      this.m_TroopsAlertStr.Length = 0;
      this.m_TroopsAlertStr.IntToFormat((long) troopsCount);
      this.m_TroopsAlertStr.AppendFormat("{0}");
      this.m_TroopsText.text = this.m_TroopsAlertStr.ToString();
      this.m_TroopsText.SetAllDirty();
      this.m_TroopsText.cachedTextGenerator.Invalidate();
      this.m_TroopsText.cachedTextGeneratorForLayout.Invalidate();
      this.m_TroopsRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_TroopsText.preferredWidth), 51f);
      ((Component) this.m_TroopsRC).gameObject.SetActive(true);
      ((Component) this.m_TroopsBtn).gameObject.SetActive(true);
    }
    else
      ((Component) this.m_TroopsBtn).gameObject.SetActive(false);
  }

  public void CheckBuffState()
  {
    int buffListUseCount = DataManager.Instance.m_BuffListUseCount;
    ((Component) this.m_BuffRC2).gameObject.SetActive(false);
    if (buffListUseCount > 0)
    {
      if (buffListUseCount > 1)
      {
        this.m_BuffAlertStr.Length = 0;
        this.m_BuffAlertStr.IntToFormat((long) buffListUseCount);
        this.m_BuffAlertStr.AppendFormat("{0}");
        this.m_BuffText.text = this.m_BuffAlertStr.ToString();
        this.m_BuffText.SetAllDirty();
        this.m_BuffText.cachedTextGenerator.Invalidate();
        this.m_BuffText.cachedTextGeneratorForLayout.Invalidate();
        this.m_BuffRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_BuffText.preferredWidth), 51f);
        ((Component) this.m_BuffRC).gameObject.SetActive(true);
      }
      else
        ((Component) this.m_BuffRC).gameObject.SetActive(false);
      if (DataManager.Instance.bHaveWarBuff)
      {
        ((Component) this.m_BuffRC2).gameObject.SetActive(true);
        this.BuffTextTime = 1f;
        this.m_BuffSA.SetSpriteIndex(6);
      }
      else if (DataManager.Instance.bHaveKvKBuff)
        this.m_BuffSA.SetSpriteIndex(5);
      else if (DataManager.Instance.bHaveWorldBattleBuff)
        this.m_BuffSA.SetSpriteIndex(5);
      else if (DataManager.Instance.bHaveNobilityBattleBuff)
        this.m_BuffSA.SetSpriteIndex(5);
      else
        this.m_BuffSA.SetSpriteIndex((int) DataManager.Instance.m_BuffListOpenIcon);
    }
    else
    {
      ((Component) this.m_BuffRC).gameObject.SetActive(false);
      this.m_BuffSA.SetSpriteIndex(0);
    }
  }

  private void CheckTalentPoint()
  {
    if (DataManager.Instance.RoleTalentPoint > (ushort) 0 && DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.None)
      this.m_HeadBoxFlash.SetActive(true);
    else
      this.m_HeadBoxFlash.SetActive(false);
  }

  private void CheckTreasureBoxState()
  {
    if (this.m_eMapMode == EUIOriginMapMode.OriginMap && (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 3 || MallManager.Instance.CheckBtnShow()))
      this.m_TreasureBoxObject.SetActive(true);
    else
      this.m_TreasureBoxObject.SetActive(false);
  }

  private void SetTreasureBoxSprite()
  {
    ActivityManager instance1 = ActivityManager.Instance;
    DataManager instance2 = DataManager.Instance;
    bool flag1 = false;
    if (MallManager.Instance.CheckBtnShow())
    {
      this.m_TreasureBoxSA.m_Sprites[0] = this.LoadSprite("UI_chest_13a");
      this.m_TreasureBoxSA.m_Sprites[1] = this.LoadSprite("UI_chest_13b");
      ((MaskableGraphic) this.m_TreasureBoxSA.m_Image).material = this.LoadMaterial();
      flag1 = true;
    }
    else
    {
      bool flag2 = instance2.CheckDailyGift();
      if ((UnityEngine.Object) this.m_TreasureBoxSA != (UnityEngine.Object) null && instance1.bDownLoadPic3 && (instance1.TreasureBoxID > (ushort) 0 || flag2))
      {
        ushort IconID = instance1.TreasureBoxID;
        if (flag2)
          IconID = instance2.mDailyGift_Pic;
        if (instance1.bUpDatePic3)
        {
          instance1.m_DoorBoxAsset.UnloadAsset();
          instance1.bUpDatePic3 = false;
        }
        if (instance1.m_DoorBoxAsset.m_AssetBundleKey == 0)
          instance1.m_DoorBoxAsset.InitialAsset("UIActivityBack_3");
        this.m_TreasureBoxSA.m_Sprites[0] = instance1.LoadDoorBoxSprite(IconID, true);
        this.m_TreasureBoxSA.m_Sprites[1] = instance1.LoadDoorBoxSprite(IconID);
        ((MaskableGraphic) this.m_TreasureBoxSA.m_Image).material = instance1.GetDoorBoxMaterial();
        if ((UnityEngine.Object) this.m_TreasureBoxSA.m_Sprites[0] != (UnityEngine.Object) null && (UnityEngine.Object) this.m_TreasureBoxSA.m_Sprites[1] != (UnityEngine.Object) null && (UnityEngine.Object) ((MaskableGraphic) this.m_TreasureBoxSA.m_Image).material != (UnityEngine.Object) null)
          flag1 = true;
      }
    }
    if (!flag1)
    {
      this.m_TreasureBoxSA.m_Sprites[0] = this.LoadSprite("UI_main_chest_a");
      this.m_TreasureBoxSA.m_Sprites[1] = this.LoadSprite("UI_main_chest_b");
      ((MaskableGraphic) this.m_TreasureBoxSA.m_Image).material = this.LoadMaterial();
    }
    this.CheckTreasureBox();
  }

  private void CheckTreasureBox()
  {
    this.CheckTreasureBoxState();
    DataManager instance = DataManager.Instance;
    this.m_TreasureBoxFlash_5x.gameObject.SetActive(false);
    if (MallManager.Instance.CheckBtnShow())
    {
      this.m_TreasureBoxtext.text = instance.mStringTable.GetStringByID(10080U);
      this.m_TreasureBoxSA.SetSpriteIndex(1);
      this.m_TreasureBoxPos.enabled = true;
      this.m_TreasureBoxScale.enabled = true;
    }
    else
    {
      bool flag = instance.CheckDailyGift();
      long sec = instance.RoleAttr.NextOnlineGiftOpenTime - instance.ServerTime;
      if (sec > 0L && !flag)
      {
        this.m_TreasureBoxSA.SetSpriteIndex(0);
        this.m_TreasureBoxPos.enabled = false;
        this.m_TreasureBoxPos.SetCurrentValueToStart();
        this.m_TreasureBoxScale.enabled = false;
        this.m_TreasureBoxScale.SetCurrentValueToStart();
        this.m_TreasureBoxStr.Length = 0;
        GameConstants.GetTimeString(this.m_TreasureBoxStr, (uint) sec, showZeroHour: false);
        this.m_TreasureBoxtext.text = this.m_TreasureBoxStr.ToString();
      }
      else
      {
        this.m_TreasureBoxSA.SetSpriteIndex(1);
        this.m_TreasureBoxPos.enabled = true;
        this.m_TreasureBoxScale.enabled = true;
        this.m_TreasureBoxtext.text = instance.mStringTable.GetStringByID(776U);
      }
      if (instance.RoleAttr.OnlineGiftOpenTimes == (byte) 19 && !flag)
        this.m_TreasureBoxFlash_5x.gameObject.SetActive(true);
    }
    this.m_TreasureBoxtext.SetAllDirty();
    this.m_TreasureBoxtext.cachedTextGenerator.Invalidate();
    this.m_TreasureBoxtext.cachedTextGeneratorForLayout.Invalidate();
  }

  private bool CheckShowLiveImg()
  {
    return GUIManager.Instance.bShowLive && GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 12;
  }

  private bool CheckShowLiveAlert()
  {
    bool flag = false;
    flag = true;
    return false && !DataManager.Instance.CheckPrizeFlag((byte) 28) && GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 12;
  }

  private bool CheckShowRedPocket()
  {
    DataManager instance1 = DataManager.Instance;
    if (instance1.RoleAlliance.Id == 0U)
      return false;
    ActivityGiftManager instance2 = ActivityGiftManager.Instance;
    if (instance2.GroupID == (byte) 0)
      return false;
    if (instance2.EnableRedPocketNum > (byte) 0)
      return true;
    ActivityManager instance3 = ActivityManager.Instance;
    return instance1.RoleAlliance.Rank == AllianceRank.RANK5 && instance2.ActivityGiftBeginTime != 0L && instance3.ServerEventTime >= instance2.ActivityGiftBeginTime && instance2.ActivityGiftEndTime != 0L && instance3.ServerEventTime <= instance2.ActivityGiftEndTime && instance2.mLeaderRedPocketResetTime != 0L && instance3.ServerEventTime >= instance2.mLeaderRedPocketResetTime;
  }

  private void SetSPGiftImgSprite(bool bMain)
  {
    Image TargetImage = !bMain ? this.SPGiftImgAlly : this.SPGiftImgMain;
    if (!GUIManager.Instance.SetFastivalImage(ActivityGiftManager.Instance.GroupID, (ushort) 4, TargetImage) || (UnityEngine.Object) TargetImage.sprite == (UnityEngine.Object) null || (UnityEngine.Object) ((MaskableGraphic) TargetImage).material == (UnityEngine.Object) null)
      ((Behaviour) TargetImage).enabled = false;
    else
      ((Behaviour) TargetImage).enabled = true;
  }

  private void CheckPetSkillBtn(int arg = 0)
  {
    bool flag1 = PetBuff.ShowButt(arg);
    bool flag2 = PetBuff.CheckFlash();
    ushort x = PetBuff.CheckCount();
    this.m_PetSkillBtnGO.SetActive(flag1);
    this.m_PetSkillBtnFlashGO.SetActive(flag2);
    if (x > (ushort) 0)
    {
      this.m_PetSkillStr.Length = 0;
      this.m_PetSkillStr.IntToFormat((long) x);
      this.m_PetSkillStr.AppendFormat("{0}");
      this.m_PetSkillText.text = this.m_PetSkillStr.ToString();
      this.m_PetSkillText.SetAllDirty();
      this.m_PetSkillText.cachedTextGenerator.Invalidate();
      this.m_PetSkillText.cachedTextGeneratorForLayout.Invalidate();
      this.m_PetSkillCountRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_PetSkillText.preferredWidth), 51f);
      ((Component) this.m_PetSkillCountRC).gameObject.SetActive(true);
    }
    else
      ((Component) this.m_PetSkillCountRC).gameObject.SetActive(false);
  }

  private void SetFBBtnTime()
  {
    if ((UnityEngine.Object) this.m_FBBtnTimeGO == (UnityEngine.Object) null || !this.m_FBBtnTimeGO.activeInHierarchy || DataManager.FBMissionDataManager.m_FBTimeEnd)
      return;
    long remainTime = (long) DataManager.FBMissionDataManager.GetRemainTime();
    if (remainTime > 0L)
    {
      this.m_FBBtnTimeStr.Length = 0;
      GameConstants.GetTimeString(this.m_FBBtnTimeStr, (uint) remainTime, hideTimeIfDays: true, showZeroHour: false);
      this.m_FBBtnTimeText.text = this.m_FBBtnTimeStr.ToString();
      this.m_FBBtnTimeText.SetAllDirty();
      this.m_FBBtnTimeText.cachedTextGenerator.Invalidate();
      this.m_FBBtnTimeText.cachedTextGeneratorForLayout.Invalidate();
      this.m_FBBtnTimeGO.SetActive(true);
    }
    else
      this.CheckFBBtn();
  }

  private void CheckFBBtn(int arg = 0)
  {
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_MissionFB, 0, arg);
    if (this.m_eMapMode != EUIOriginMapMode.OriginMap)
    {
      this.m_FBBtnGO.SetActive(false);
    }
    else
    {
      if (DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex <= (byte) 11 || DataManager.FBMissionDataManager.GetRewardCount() > (ushort) 0)
      {
        if (SocialManager.Instance.CheckShowPrize())
        {
          this.m_FBUIType = (byte) 0;
          this.m_FBBtnGO.SetActive(true);
          this.m_FBBtnSA.SetSpriteIndex(2);
          this.m_FBBtnTimeGO.SetActive(false);
          this.m_FBBtnAlertGO.SetActive(false);
          if (SocialManager.Instance.CheckShowPrizeCount())
          {
            this.m_FBBtnCountStr.Length = 0;
            this.m_FBBtnCountStr.IntToFormat((long) DataManager.FBMissionDataManager.GetRewardCount());
            this.m_FBBtnCountStr.AppendFormat("{0}");
            this.m_FBBtnCountText.text = this.m_FBBtnCountStr.ToString();
            this.m_FBBtnCountText.SetAllDirty();
            this.m_FBBtnCountText.cachedTextGenerator.Invalidate();
            this.m_FBBtnCountText.cachedTextGeneratorForLayout.Invalidate();
            this.m_FBBtnCountRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_FBBtnCountText.preferredWidth), 51f);
            ((Component) this.m_FBBtnCountRC).gameObject.SetActive(true);
          }
          else
            ((Component) this.m_FBBtnCountRC).gameObject.SetActive(false);
        }
        else if (SocialManager.Instance.CheckShowMission())
        {
          this.m_FBUIType = (byte) 0;
          if (!DataManager.FBMissionDataManager.m_FBTimeEnd)
            DataManager.FBMissionDataManager.m_FBTimeEnd = DataManager.Instance.CheckPrizeFlag((byte) 27) && !DataManager.FBMissionDataManager.IsInTime();
          if (DataManager.FBMissionDataManager.m_FBTimeEnd)
          {
            if (DataManager.Instance.CheckPrizeFlag((byte) 27))
            {
              this.m_FBBtnAlertGO.SetActive(false);
              this.m_FBBtnTimeStr.Length = 0;
              GameConstants.GetTimeString(this.m_FBBtnTimeStr, 0U, hideTimeIfDays: true, showZeroHour: false);
              this.m_FBBtnTimeText.text = this.m_FBBtnTimeStr.ToString();
              this.m_FBBtnTimeText.SetAllDirty();
              this.m_FBBtnTimeText.cachedTextGenerator.Invalidate();
              this.m_FBBtnTimeText.cachedTextGeneratorForLayout.Invalidate();
              ((Graphic) this.m_FBBtnTimeText).color = Color.red;
              this.m_FBBtnTimeGO.SetActive(true);
            }
            else
            {
              this.m_FBBtnAlertGO.SetActive(true);
              this.m_FBBtnTimeGO.SetActive(false);
            }
            ((Component) this.m_FBBtnCountRC).gameObject.SetActive(false);
            this.m_FBBtnSA.SetSpriteIndex(1);
            this.m_FBBtnGO.SetActive(true);
          }
          else
          {
            this.m_FBBtnAlertGO.SetActive(!DataManager.Instance.CheckPrizeFlag((byte) 27));
            this.m_FBBtnTimeGO.SetActive(!this.m_FBBtnAlertGO.activeSelf);
            ((Component) this.m_FBBtnCountRC).gameObject.SetActive(false);
            this.m_FBBtnSA.SetSpriteIndex(1);
            this.m_FBBtnGO.SetActive(true);
            if (DataManager.FBMissionDataManager.IsInTime())
              this.SetFBBtnTime();
          }
        }
        else
          this.m_FBBtnGO.SetActive(false);
      }
      else
        this.m_FBBtnGO.SetActive(false);
      DataManager.FBMissionDataManager.bFB_CDTime = false;
      if (!this.m_FBBtnGO.activeSelf && (DataManager.FBMissionDataManager.CurMissionProcess.NodeIndex > (byte) 11 || !DataManager.FBMissionDataManager.IsInTime()) && DataManager.FBMissionDataManager.CurrentFriendNum < (byte) 10 && GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 7 && DataManager.Instance.RoleAttr.Invitation != (byte) 0)
      {
        DataManager.FBMissionDataManager.bFB_CDTime = true;
        if (DataManager.FBMissionDataManager.CheckReSetFB_CDTime())
          DataManager.FBMissionDataManager.bFB_btnShow = true;
        if (DataManager.FBMissionDataManager.bFB_btnShow)
        {
          this.m_FBUIType = (byte) 1;
          this.m_FBBtnGO.SetActive(true);
          this.m_FBBtnSA.SetSpriteIndex(0);
          this.m_FBBtnTimeGO.SetActive(false);
          this.m_FBBtnAlertGO.SetActive(false);
          ((Component) this.m_FBBtnCountRC).gameObject.SetActive(false);
        }
      }
      this.m_FBBtnSA.m_Image.SetNativeSize();
    }
  }

  private void SetForceCount()
  {
    this.ForceTime = 0U;
    if (this.m_MoraleSA.m_SpriteIndex != 2)
      return;
    DataManager instance = DataManager.Instance;
    uint stock = instance.PetResource.Stock;
    uint capacity = instance.PetResource.Capacity;
    double num = (double) instance.PetResource.GetSpeed() / 3600.0;
    if (num == 0.0)
      return;
    this.ForceTime = (uint) ((double) (capacity - stock) / num);
  }

  private void UpDateForceHint()
  {
    if (!this.bMoraleHintOpen || !((UnityEngine.Object) this.m_MoraleSA != (UnityEngine.Object) null) || this.m_MoraleSA.m_SpriteIndex != 2)
      return;
    this.SetMolareHint(false);
  }

  private void SetMolareHint(bool bCheckSec = true)
  {
    if (bCheckSec)
    {
      if (this.MoraleHintTime == DataManager.Instance.ServerTime)
        return;
      this.MoraleHintTime = DataManager.Instance.ServerTime;
    }
    DataManager instance = DataManager.Instance;
    if (this.MoraleHintString == null)
      this.MoraleHintString = StringManager.Instance.SpawnString(600);
    if (this.m_MoraleSA.m_SpriteIndex == 0)
    {
      ushort heroMaxMorale = instance.HeroMaxMorale;
      this.MoraleHintString.Length = 0;
      this.MoraleHintString.Append(instance.mStringTable.GetStringByID(251U));
      this.MoraleHintString.Append("\n");
      byte useMoraleItemTimes = instance.RoleAttr.TodayUseMoraleItemTimes;
      byte moraleBanner = instance.VIPLevelTable.GetRecordByKey((ushort) instance.RoleAttr.VIPLevel).moraleBanner;
      this.MoraleHintString.Append("<color=#ffff00>");
      if (moraleBanner == byte.MaxValue)
      {
        this.MoraleHintString.AppendFormat(instance.mStringTable.GetStringByID(8583U));
      }
      else
      {
        if ((int) useMoraleItemTimes >= (int) moraleBanner)
        {
          CString s = StringManager.Instance.StaticString1024();
          StringManager.IntToStr(s, (long) moraleBanner);
          CString tmpS = StringManager.Instance.StaticString1024();
          tmpS.Append("<color=#ff0000>");
          tmpS.Append(s);
          tmpS.Append("</color>");
          this.MoraleHintString.StringToFormat(tmpS);
        }
        else
          this.MoraleHintString.IntToFormat((long) useMoraleItemTimes);
        this.MoraleHintString.IntToFormat((long) moraleBanner);
        this.MoraleHintString.AppendFormat(instance.mStringTable.GetStringByID(8582U));
      }
      this.MoraleHintString.Append("</color>\n");
      this.MoraleHintString.Append("<color=#ffff00>");
      this.MoraleHintString.IntToFormat((long) GameConstants.GetDateTime(instance.RoleAttr.FirstTimer).Hour, 2);
      this.MoraleHintString.IntToFormat((long) GameConstants.GetDateTime(instance.RoleAttr.FirstTimer).Minute, 2);
      this.MoraleHintString.AppendFormat(instance.mStringTable.GetStringByID(753U));
      this.MoraleHintString.Append("</color>\n");
      if ((int) instance.RoleAttr.Morale < (int) heroMaxMorale)
      {
        long num1 = 360L - (instance.ServerTime - instance.RoleAttr.LastMoraleRecoverTime);
        if (num1 < 0L)
          return;
        int x1 = 0;
        int x2 = (int) num1 / 60;
        int x3 = (int) num1 % 60;
        this.MoraleHintString.IntToFormat((long) x1, 2);
        this.MoraleHintString.IntToFormat((long) x2, 2);
        this.MoraleHintString.IntToFormat((long) x3, 2);
        this.MoraleHintString.AppendFormat(instance.mStringTable.GetStringByID(360U));
        this.MoraleHintString.Append("\n");
        int num2 = (int) heroMaxMorale - (int) instance.RoleAttr.Morale;
        if (num2 > 1)
        {
          int num3 = (num2 - 1) * 6;
          x1 += num3 / 60;
          x2 += num3 % 60;
        }
        this.MoraleHintString.IntToFormat((long) x1, 2);
        this.MoraleHintString.IntToFormat((long) x2, 2);
        this.MoraleHintString.IntToFormat((long) x3, 2);
        this.MoraleHintString.AppendFormat(instance.mStringTable.GetStringByID(361U));
      }
      else
        this.MoraleHintString.Append(instance.mStringTable.GetStringByID(359U));
    }
    else if (this.m_MoraleSA.m_SpriteIndex == 2)
    {
      if (bCheckSec && this.ForceTime > 0U)
        --this.ForceTime;
      this.MoraleHintString.Length = 0;
      this.MoraleHintString.Append(instance.mStringTable.GetStringByID(14590U));
      uint stock = instance.PetResource.Stock;
      uint capacity = instance.PetResource.Capacity;
      if (stock >= capacity)
      {
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.IntToFormat((long) stock, bNumber: true);
        cstring.IntToFormat((long) capacity, bNumber: true);
        cstring.AppendFormat(instance.mStringTable.GetStringByID(14594U));
        this.MoraleHintString.Append(cstring);
        if (capacity != 0U)
        {
          this.MoraleHintString.Append("\n");
          this.MoraleHintString.Append(instance.mStringTable.GetStringByID(14592U));
        }
      }
      else
      {
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.IntToFormat((long) stock, bNumber: true);
        cstring.IntToFormat((long) capacity, bNumber: true);
        cstring.AppendFormat(instance.mStringTable.GetStringByID(14593U));
        this.MoraleHintString.Append(cstring);
        this.MoraleHintString.Append("\n");
        this.MoraleHintString.Append(instance.mStringTable.GetStringByID(14591U));
        this.MoraleHintString.Append("<color=#00ff00>");
        CString CStr = StringManager.Instance.StaticString1024();
        GameConstants.GetTimeString(CStr, this.ForceTime);
        this.MoraleHintString.Append(CStr);
        this.MoraleHintString.Append("</color>");
      }
    }
    else
    {
      this.MoraleHintString.Length = 0;
      this.MoraleHintString.Append(instance.mStringTable.GetStringByID(880U));
      this.MoraleHintString.Append("\n");
      if (instance.GetMaxMonsterPoint() > instance.RoleAttr.MonsterPoint)
      {
        if (this.MonsterTime == -1L)
          this.MonsterTime = (long) ((double) (instance.GetMaxMonsterPoint() - instance.RoleAttr.MonsterPoint) * ((double) instance.RoleAttr.MonsterPointRecoverFrequency / 1000.0));
        else
          --this.MonsterTime;
        int x4 = (int) this.MonsterTime / 3600;
        int x5 = (int) this.MonsterTime % 3600 / 60;
        int x6 = (int) this.MonsterTime % 60;
        this.MoraleHintString.IntToFormat((long) x4, 2);
        this.MoraleHintString.IntToFormat((long) x5, 2);
        this.MoraleHintString.IntToFormat((long) x6, 2);
        this.MoraleHintString.AppendFormat(instance.mStringTable.GetStringByID(881U));
      }
      else
        this.MoraleHintString.Append(instance.mStringTable.GetStringByID(882U));
    }
    this.m_MoraleHintText.text = this.MoraleHintString.ToString();
    this.m_MoraleHintText.SetAllDirty();
    this.m_MoraleHintText.cachedTextGenerator.Invalidate();
    this.m_MoraleHintText.cachedTextGeneratorForLayout.Invalidate();
    ((Graphic) this.m_MoraleHintBox).rectTransform.sizeDelta = new Vector2(this.m_MoraleHintText.preferredWidth + 35f, this.m_MoraleHintText.preferredHeight + 31f);
    float x = ((Component) GUIManager.Instance.m_UICanvas).GetComponent<RectTransform>().sizeDelta.x;
    RectTransform rectTransform = ((Graphic) this.m_MoraleHintText).rectTransform;
    if ((double) rectTransform.anchoredPosition.x + (double) rectTransform.sizeDelta.x > (double) x)
      rectTransform.anchoredPosition = new Vector2(x - rectTransform.sizeDelta.x, rectTransform.anchoredPosition.y);
    if ((double) rectTransform.anchoredPosition.x < 0.0)
      rectTransform.anchoredPosition = new Vector2(0.0f, rectTransform.anchoredPosition.y);
    this.m_MoraleHintText.UpdateArabicPos();
  }

  public void SetAlertImageAlpha(float Alpha)
  {
    if (GUIManager.Instance.m_AlertImageIndex != 0 || !((UnityEngine.Object) this.m_AlertBlock != (UnityEngine.Object) null))
      return;
    Color color = new Color(1f, 1f, 1f, Alpha);
    ((Graphic) this.m_AlertBlock_T).color = color;
    ((Graphic) this.m_AlertBlock_B).color = color;
    ((Graphic) this.m_AlertBlock_R).color = color;
    ((Graphic) this.m_AlertBlock_L).color = color;
  }

  public void CheckAttackState()
  {
    GUIManager instance = GUIManager.Instance;
    int[] attackedAlertCount = instance.m_AttackedAlertCount;
    int index1 = -1;
    for (int index2 = 0; index2 < 15; ++index2)
    {
      if (attackedAlertCount[index2] > 0 && index1 == -1)
        index1 = index2;
    }
    if (instance.m_AttackedAlertTCount > 0)
    {
      this.m_AttackedAlertStr.Length = 0;
      this.m_AttackedAlertStr.IntToFormat((long) instance.m_AttackedAlertTCount);
      this.m_AttackedAlertStr.AppendFormat("{0}");
      this.m_AttackedAlertText.text = this.m_AttackedAlertStr.ToString();
      this.m_AttackedAlertText.SetAllDirty();
      this.m_AttackedAlertText.cachedTextGenerator.Invalidate();
      this.m_AttackedAlertText.cachedTextGeneratorForLayout.Invalidate();
      this.m_AttackedAlertRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_AttackedAlertText.preferredWidth), 51f);
      this.m_AttackedAlertSA.SetSpriteIndex(index1);
      this.m_AttackedAlertSA.m_Image.SetNativeSize();
      this.m_AttackedAlertSA2.SetSpriteIndex(index1);
      ((Component) this.m_AttackedAlertRC).gameObject.SetActive(true);
      ((Component) this.m_AttackedAlert).gameObject.SetActive(true);
      switch ((EAttackKind) index1)
      {
        case EAttackKind.Wonder_GatherAttack:
        case EAttackKind.Wonder_Attack:
        case EAttackKind.Wonder_Detect:
        case EAttackKind.Wonder_Reinforce:
          this.m_AttackedAlertBackSA.SetSpriteIndex(1);
          this.m_AttackedAlertBackSA2.SetSpriteIndex(1);
          break;
        default:
          this.m_AttackedAlertBackSA.SetSpriteIndex(0);
          this.m_AttackedAlertBackSA2.SetSpriteIndex(0);
          break;
      }
      ((Component) this.m_AlertBlock).gameObject.SetActive(instance.m_AlertImageIndex == 0);
    }
    else
    {
      ((Component) this.m_AttackedAlert).gameObject.SetActive(false);
      ((Component) this.m_AlertBlock).gameObject.SetActive(false);
    }
  }

  public void CheckHelpAlertState()
  {
    if (DataManager.Instance.mHelpDataList.Count > 0)
    {
      this.m_HelpAlertStr.Length = 0;
      this.m_HelpAlertStr.IntToFormat((long) DataManager.Instance.mHelpDataList.Count);
      this.m_HelpAlertStr.AppendFormat("{0}");
      this.m_HelpAlertext.text = this.m_HelpAlertStr.ToString();
      this.m_HelpAlertext.SetAllDirty();
      this.m_HelpAlertext.cachedTextGenerator.Invalidate();
      this.m_HelpAlertext.cachedTextGeneratorForLayout.Invalidate();
      this.m_HelpAlertRC.sizeDelta = new Vector2(Door.GetRedBackWidth(this.m_HelpAlertext.preferredWidth), 51f);
      ((Component) this.m_HelpAlertRC).gameObject.SetActive(true);
      ((Component) this.m_HelpAlert).gameObject.SetActive(true);
      if (DataManager.Instance.AllianceMoneyBonusRate > (ushort) 100)
      {
        int index = (int) DataManager.Instance.AllianceMoneyBonusRate / 100 - 2;
        if (index >= 0 && index < this.m_HelpAlertSA.m_Sprites.Length)
          this.m_HelpAlertSA.SetSpriteIndex(index);
        else
          this.m_HelpAlertSA.SetSpriteIndex(0);
        ((Component) this.m_HelpAlertL).gameObject.SetActive(true);
        ((Component) this.m_HelpAlertR).gameObject.SetActive(true);
        this.m_HelpAlertImageGO.SetActive(true);
      }
      else
      {
        this.m_HelpAlertImageGO.SetActive(false);
        ((Component) this.m_HelpAlertL).gameObject.SetActive(false);
        ((Component) this.m_HelpAlertR).gameObject.SetActive(false);
      }
    }
    else
      ((Component) this.m_HelpAlert).gameObject.SetActive(false);
  }

  public void CheckAllianceFreeState()
  {
    if (DataManager.Instance.RoleAlliance.Id <= 0U)
    {
      if (DataManager.Instance.CheckPrizeFlag((byte) 0))
      {
        ((Graphic) this.m_AllianceFreetext).rectTransform.offsetMax = new Vector2(-5f, 0.0f);
        ((Graphic) this.m_AllianceFreetext).rectTransform.offsetMin = new Vector2(5f, 0.0f);
        this.m_AllianceFreetext.text = DataManager.Instance.mStringTable.GetStringByID(16110U);
        this.m_AllianceFreeSA1.SetSpriteIndex(1);
        this.m_AllianceFreeSA2.SetSpriteIndex(1);
        ((Graphic) this.m_AllianceFreeSA1.m_Image).rectTransform.anchoredPosition = new Vector2(-39.5f, 156.8f);
      }
      else
      {
        ((Graphic) this.m_AllianceFreetext).rectTransform.offsetMax = Vector2.zero;
        ((Graphic) this.m_AllianceFreetext).rectTransform.offsetMin = Vector2.zero;
        this.m_AllianceFreetext.text = DataManager.Instance.mStringTable.GetStringByID(777U);
        this.m_AllianceFreeSA1.SetSpriteIndex(0);
        this.m_AllianceFreeSA2.SetSpriteIndex(0);
        ((Graphic) this.m_AllianceFreeSA1.m_Image).rectTransform.anchoredPosition = new Vector2(-39.5f, 160.3f);
      }
      this.m_AllianceFreeSA1.m_Image.SetNativeSize();
      this.m_AllianceFreeSA2.m_Image.SetNativeSize();
      ((Component) this.m_AllianceFree).gameObject.SetActive(true);
    }
    else
      ((Component) this.m_AllianceFree).gameObject.SetActive(false);
  }

  public void QueuePanelSetActive(bool bActive)
  {
    ((Component) this.m_QueuePanel).gameObject.SetActive(bActive);
    this.CheckSpQueueBar();
    if (!bActive)
      return;
    for (int index = 0; index < (int) this.m_QueueCount && index < this.m_QueueTimeBar.Length; ++index)
      this.m_QueueTimeBar[index].SetFlashCount(1f, this.m_QueueTimeBar[index].GetTextIndex());
  }

  public void CheckSpQueueBar()
  {
    if (DataManager.Instance.queueBarData[17].bActive)
    {
      if (this.m_QueueCount > (byte) 0)
        this.m_QueueTimeBar[0].gameObject.SetActive(true);
      else
        this.m_QueueTimeBar[0].gameObject.SetActive(false);
    }
    else
      this.m_QueueTimeBar[0].gameObject.SetActive(((Component) this.m_QueuePanel).gameObject.activeSelf);
  }

  public void SetQueueBar(bool bShow)
  {
    Vector2 anchoredPosition = ((Graphic) this.m_QueueIcon).rectTransform.anchoredPosition;
    if (bShow)
    {
      if (DataManager.Instance.queueBarData[17].bActive && this.m_QueueCount <= (byte) 1)
      {
        ((Component) this.m_QueueIcon).transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
        anchoredPosition.x = 36.6f;
      }
      else
      {
        ((Component) this.m_QueueIcon).transform.localRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        anchoredPosition.x = 24f;
      }
      ((Component) this.m_QueueCountBox).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.m_QueueIcon).transform.localRotation = Quaternion.Euler(0.0f, 180f, 0.0f);
      anchoredPosition.x = 36.6f;
      if (this.m_QueueCount > (byte) 0)
        ((Component) this.m_QueueCountBox).gameObject.SetActive(true);
      else
        ((Component) this.m_QueueCountBox).gameObject.SetActive(false);
    }
    ((Graphic) this.m_QueueIcon).rectTransform.anchoredPosition = anchoredPosition;
  }

  public static float GetRedBackWidth(float WordWidth)
  {
    float num = WordWidth + 28f;
    return (double) num < 52.0 ? 52f : num;
  }

  public void CheckSysSetting() => DataManager.Instance.bNeedSortQueueBarData = true;

  public void ShowLoadingImg()
  {
    if (!((UnityEngine.Object) this.LoadingImgT != (UnityEngine.Object) null))
      return;
    this.LoadingImgT.gameObject.SetActive(true);
    this.bShowLoadingImg = true;
  }

  public void HideLoadingImg()
  {
    if (!((UnityEngine.Object) this.LoadingImgT != (UnityEngine.Object) null))
      return;
    this.LoadingImgT.gameObject.SetActive(false);
    this.bShowLoadingImg = false;
  }

  public void GoToKingdom(ushort kingdomID, int MapID = -1)
  {
    if (MapID == -1)
    {
      if (this.m_eMapMode == EUIOriginMapMode.WorldMap)
      {
        DataManager.msgBuffer[0] = (byte) 118;
        GameConstants.GetBytes(kingdomID, DataManager.msgBuffer, 1);
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      }
      else
      {
        DataManager.MapDataController.gotokingdomID = kingdomID;
        DataManager.MapDataController.FocusWorldMapPos = -Vector2.one;
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToWorld);
      }
    }
    else
    {
      DataManager.MapDataController.ClearLayoutMapInfoYolkKind();
      DataManager.MapDataController.FocusKingdomID = kingdomID;
      DataManager.MapDataController.FocusMapID = MapID;
      if ((int) kingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
      {
        DataManager.MapDataController.FocusKingdomPeriod = DataManager.MapDataController.OtherKingdomData.kingdomPeriod;
        if (NetworkManager.GuestController.Connected() || NetworkManager.GuestController.Connecting())
          NetworkManager.Instance.ViewClose();
        if (DataManager.MapDataController.gotoKingdomState != (byte) 0)
          return;
        DataManager.MapDataController.ClearAll();
        this.GoToMapID(kingdomID, DataManager.MapDataController.FocusMapID, (byte) 0, (byte) 1);
      }
      else
      {
        if (!NetworkManager.GuestController.Connected())
          DataManager.MapDataController.OutMap();
        ++DataManager.MapDataController.gotoKingdomState;
        GUIManager.Instance.ShowUILock(EUILock.Normal);
        NetworkManager.Instance.ViewKingdom(kingdomID);
      }
    }
  }

  public void ViewKingdom()
  {
    --DataManager.MapDataController.gotoKingdomState;
    if (DataManager.MapDataController.gotoKingdomState == (byte) 0)
    {
      this.HideLoadingImg();
      DataManager.MapDataController.ClearAll();
      this.GoToMapID(DataManager.MapDataController.FocusKingdomID, DataManager.MapDataController.FocusMapID, (byte) 0, (byte) 1);
    }
    GUIManager.Instance.HideUILock(EUILock.Normal);
  }

  public void GoToGroup(int groupID, byte isOpenGroundInfo = 0, bool bsend = true)
  {
    DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    if (groupID < -1 || groupID >= 10)
      return;
    this.CheckFocusGroup();
    byte isMarkGroundInfo = 1;
    int MapID;
    switch (groupID)
    {
      case 8:
        if (DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
        {
          MapID = this.m_eMapMode != EUIOriginMapMode.KingdomMap ? DataManager.Instance.getMapIDbyGroupID((byte) groupID) : DataManager.Instance.RoleAttr.CapitalPoint;
          DataManager.MapDataController.FocusGroupID = (byte) groupID;
          isMarkGroundInfo = (byte) 0;
          break;
        }
        MapID = DataManager.Instance.RoleAttr.CapitalPoint;
        break;
      case 9:
        if (PetManager.Instance.m_PetMarchEventData.PetID != (ushort) 0)
        {
          MapID = this.m_eMapMode != EUIOriginMapMode.KingdomMap ? DataManager.Instance.getMapIDbyGroupID((byte) groupID) : DataManager.Instance.RoleAttr.CapitalPoint;
          DataManager.MapDataController.FocusGroupID = (byte) groupID;
          isMarkGroundInfo = (byte) 0;
          break;
        }
        MapID = DataManager.Instance.RoleAttr.CapitalPoint;
        break;
      default:
        if (groupID == -1 || DataManager.Instance.MarchEventData[groupID].Type == EMarchEventType.EMET_Standby)
        {
          MapID = DataManager.Instance.RoleAttr.CapitalPoint;
          break;
        }
        if (DataManager.Instance.MarchEventData[groupID].Type < EMarchEventType.EMET_AttackMarching)
        {
          MapID = GameConstants.PointCodeToMapID(DataManager.Instance.MarchEventData[groupID].Point.zoneID, DataManager.Instance.MarchEventData[groupID].Point.pointID);
          break;
        }
        MapID = this.m_eMapMode != EUIOriginMapMode.KingdomMap ? DataManager.Instance.getMapIDbyGroupID((byte) groupID) : DataManager.Instance.RoleAttr.CapitalPoint;
        DataManager.MapDataController.FocusGroupID = (byte) groupID;
        isMarkGroundInfo = (byte) 0;
        break;
    }
    this.GoToMapID(DataManager.MapDataController.OtherKingdomData.kingdomID, MapID, isOpenGroundInfo, isMarkGroundInfo, bsend);
  }

  public void GoToPointCode(ushort kingdomID, ushort zoneID, byte pointID, byte isOpenGroundInfo = 0)
  {
    this.CheckFocusGroup();
    DataManager.MapDataController.FocusGroupID = (byte) 10;
    this.GoToMapID(kingdomID, GameConstants.PointCodeToMapID(zoneID, pointID), isOpenGroundInfo, (byte) 1);
  }

  public void GoToMapID(
    ushort kingdomID,
    int MapID,
    byte isOpenGroundInfo = 0,
    byte isMarkGroundInfo = 1,
    bool bsend = true)
  {
    if (!DataManager.MapDataController.CheckKingdomID(kingdomID))
      return;
    if ((int) kingdomID != (int) DataManager.MapDataController.FocusKingdomID)
    {
      if (this.m_eMapMode == EUIOriginMapMode.KingdomMap)
      {
        DataManager.MapDataController.ClearLayoutMapInfoYolkKind();
        DataManager.MapDataController.FocusKingdomID = kingdomID;
        DataManager.MapDataController.FocusMapID = MapID;
        DataManager.MapDataController.gotoKingdomState = byte.MaxValue;
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToKing);
      }
      else
        this.GoToKingdom(kingdomID, MapID);
    }
    else
    {
      DataManager.MapDataController.FocusMapID = MapID;
      DataManager.MapDataController.isMarkGroundInfo = isMarkGroundInfo;
      DataManager.MapDataController.isOpenGroundInfo = isOpenGroundInfo;
      if (this.m_eMapMode != EUIOriginMapMode.KingdomMap)
      {
        DataManager.MapDataController.ClearLayoutMapInfoYolkKind();
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToKing);
      }
      else
      {
        if (!((UnityEngine.Object) this.TileMapController != (UnityEngine.Object) null))
          return;
        this.CloseMenu(this.m_WindowStack.Count > 0);
        uint num = DataManager.MapDataController.CheckWonderMapID((uint) DataManager.MapDataController.FocusMapID, DataManager.MapDataController.FocusKingdomID);
        DataManager.MapDataController.FocusMapID = num != 40U ? (int) num : DataManager.MapDataController.FocusMapID;
        if (DataManager.MapDataController.FocusGroupID == (byte) 10)
        {
          Vector2 tileMapPosbyMapId = GameConstants.getTileMapPosbyMapID(DataManager.MapDataController.FocusMapID);
          this.TileMapController.MovebyTileMapPos((int) tileMapPosbyMapId.x, (int) tileMapPosbyMapId.y, bsend);
        }
        else if (!this.TileMapController.ClickGroup())
        {
          DataManager.MapDataController.FocusMapID = DataManager.Instance.getMapIDbyGroupID(DataManager.MapDataController.FocusGroupID);
          Vector2 tileMapPosbyMapId = GameConstants.getTileMapPosbyMapID(DataManager.MapDataController.FocusMapID);
          this.TileMapController.MovebyTileMapPos((int) tileMapPosbyMapId.x, (int) tileMapPosbyMapId.y);
        }
        this.TileMapController.CheckCenterPos();
      }
    }
  }

  public void GoToWonder(ushort kingdomID, byte WonderID)
  {
    this.GoToMapID(kingdomID, (int) DataManager.MapDataController.GetYolkMapID((ushort) WonderID, kingdomID), (byte) 0, (byte) 1);
  }

  public void CheckFocusGroup()
  {
    if (DataManager.MapDataController.FocusGroupID == (byte) 10)
      return;
    DataManager.msgBuffer[0] = (byte) 65;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void CheckMapID(int mapInfoID)
  {
    if (this.m_GroundInfo == null)
      return;
    this.m_GroundInfo.CheckMapInfoID(mapInfoID);
  }

  public void OpenGroundInfo(int mapInfoID, POINT_KIND infoKind = POINT_KIND.PK_MAX)
  {
    this.SetDefaultFadeAlpha();
    if (this.m_GroundInfo == null || this.m_WindowStack.Count > 0)
      return;
    if (this.m_GroundInfo.m_PanelGameObject.activeSelf || this.m_GroundInfo.m_TeamPanelGameObject.activeSelf)
    {
      this.m_GroundInfo.Close();
    }
    else
    {
      DataManager.msgBuffer[0] = (byte) 78;
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    }
    this.m_GroundInfo.delayOpen(mapInfoID, infoKind);
  }

  public void ShowKVKTransBtn(bool bShow = true)
  {
    this.KVKTransBtnGO.SetActive(bShow);
    int kvKkingdomType = (int) ActivityManager.Instance.getKvKKingdomType(DataManager.MapDataController.FocusKingdomID);
    if (kvKkingdomType > 0 && kvKkingdomType <= 3)
      this.KVKTransBtnSA.SetSpriteIndex(kvKkingdomType - 1);
    else
      this.KVKTransBtnSA.SetSpriteIndex(0);
  }

  public void ShowKingdomMark(bool bclear = false)
  {
    if (bclear || (int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
    {
      if (!((UnityEngine.Object) this.KingdomMarkGameObject != (UnityEngine.Object) null))
        return;
      this.KingdomMarkGameObject.SetActive(false);
      this.ShowKVKTransBtn(false);
    }
    else
    {
      if ((UnityEngine.Object) this.KingdomMarkGameObject == (UnityEngine.Object) null)
      {
        this.KingdomMarkGameObject = new GameObject("KingdomMark");
        RectTransform rectTransform = this.KingdomMarkGameObject.AddComponent<RectTransform>();
        rectTransform.sizeDelta = Vector2.zero;
        rectTransform.anchoredPosition = new Vector2(0.0f, 200f);
        GameObject gameObject1 = new GameObject("back");
        Image image = gameObject1.AddComponent<Image>();
        Image component = ((Component) this.m_LocationBox).GetComponent<Image>();
        image.sprite = component.sprite;
        ((MaskableGraphic) image).material = ((MaskableGraphic) component).material;
        RectTransform transform = ((Component) image).transform as RectTransform;
        image.type = (Image.Type) 1;
        transform.sizeDelta = new Vector2(500f, 40f);
        gameObject1.transform.SetParent((Transform) rectTransform, false);
        GameObject gameObject2 = new GameObject("kingdom_name");
        this.KingdomMarkText = gameObject2.AddComponent<UIText>();
        gameObject2.AddComponent<Outline>();
        (((Component) this.KingdomMarkText).transform as RectTransform).sizeDelta = new Vector2(500f, 40f);
        this.KingdomMarkText.font = GUIManager.Instance.GetTTFFont();
        this.KingdomMarkText.alignment = TextAnchor.MiddleCenter;
        this.KingdomMarkText.fontSize = 22;
        ((Graphic) this.KingdomMarkText).color = Color.red;
        gameObject2.transform.SetParent((Transform) rectTransform, false);
        ((Transform) rectTransform).SetParent((Transform) this.m_MapFuncPanel, false);
        this.KingdomMarkGameObject.AddComponent<CanvasGroup>().ignoreParentGroups = true;
        this.KingdomMarkString = StringManager.Instance.SpawnString();
      }
      this.KingdomMarkGameObject.SetActive(false);
      this.KingdomMarkString.ClearString();
      if (GUIManager.Instance.IsArabic)
      {
        this.KingdomMarkString.IntToFormat((long) DataManager.MapDataController.FocusKingdomID);
        this.KingdomMarkString.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(592U));
        this.KingdomMarkString.AppendFormat("{1} ({0}:K)");
      }
      else
      {
        this.KingdomMarkString.IntToFormat((long) DataManager.MapDataController.FocusKingdomID);
        this.KingdomMarkString.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(592U));
      }
      this.KingdomMarkText.text = this.KingdomMarkString.ToString();
      this.KingdomMarkText.SetAllDirty();
      this.KingdomMarkGameObject.SetActive(true);
      if (ActivityManager.Instance.IsInKvK((ushort) 0, true) && ((int) DataManager.MapDataController.kingdomData.kingdomID == (int) DataManager.MapDataController.FocusKingdomID && (int) DataManager.MapDataController.kingdomData.kingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID && DataManager.MapDataController.kingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK || DataManager.MapDataController.IsEnemy(DataManager.MapDataController.FocusKingdomID)))
        this.ShowKVKTransBtn();
      else
        this.ShowKVKTransBtn(false);
    }
  }

  public MAP_TERRAIN_KIND GetTerrain(ushort kingdomID, uint mapID)
  {
    if ((UnityEngine.Object) this.TileMapController != (UnityEngine.Object) null && this.TileMapController.TileMapInfo != null && (long) mapID < (long) this.TileMapController.TileMapInfo.Length && this.m_eMapMode == EUIOriginMapMode.KingdomMap && (int) kingdomID == (int) DataManager.MapDataController.FocusKingdomID)
      return DataManager.MapDataController.GetTerrain(this.TileMapController.TileMapInfo[(IntPtr) mapID]);
    KingdomMap recordByKey = DataManager.MapDataController.KingdomMapTable.GetRecordByKey(kingdomID);
    AssetBundle tableAb = DataManager.Instance.GetTableAB();
    if (!(bool) (UnityEngine.Object) tableAb)
      return MAP_TERRAIN_KIND.MTK_NONE;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.IntToFormat((long) recordByKey.mapID, 3);
    cstring.AppendFormat("TileMap_{0}");
    TextAsset textAsset = tableAb.Load(cstring.ToString()) as TextAsset;
    if ((UnityEngine.Object) textAsset == (UnityEngine.Object) null)
      return MAP_TERRAIN_KIND.MTK_NONE;
    Stream stream = (Stream) new MemoryStream(textAsset.bytes);
    MAP_TERRAIN_KIND terrain = DataManager.MapDataController.GetTerrain(textAsset.bytes[(IntPtr) mapID]);
    stream.Close();
    return terrain;
  }

  private void GroundInfoUpdate()
  {
    if (this.m_GroundInfo == null)
      return;
    this.m_GroundInfo.Run();
  }

  public void BeginFadeInOut()
  {
    if (this.FadeInOrOut == (byte) 2 || (double) this.CGDoor.alpha == 0.0)
    {
      this.BeginFadeIn();
    }
    else
    {
      if (this.FadeInOrOut != (byte) 1 && (double) this.CGDoor.alpha != 1.0)
        return;
      this.BeginFadeOut();
    }
  }

  public void BeginFadeIn()
  {
    if (this.FadeInOrOut == (byte) 1 || !DataManager.Instance.MySysSetting.bShowMainMenu)
      return;
    this.FadeBeginAlpha = this.CGDoor.alpha;
    this.FadeInOrOut = (byte) 1;
    this.FadeNowTime = 0.0f;
    this.CGDoor.blocksRaycasts = true;
    this.CGTop.blocksRaycasts = true;
  }

  public void BeginFadeOut()
  {
    if (this.bHideMainMenu || this.FadeInOrOut == (byte) 2 || !DataManager.Instance.MySysSetting.bShowMainMenu)
      return;
    this.FadeBeginAlpha = this.CGDoor.alpha;
    this.FadeInOrOut = (byte) 2;
    this.FadeNowTime = 0.0f;
  }

  public void SetDefaultFadeAlpha()
  {
    if ((double) this.CGDoor.alpha == 1.0)
      return;
    this.BeginFadeIn();
  }

  private void SetFadeTargetAlpha(byte TargetAlpha)
  {
    this.CGDoor.alpha = (float) TargetAlpha;
    this.CGTop.alpha = (float) TargetAlpha;
    this.CGDoor.blocksRaycasts = TargetAlpha == (byte) 1;
    this.CGTop.blocksRaycasts = TargetAlpha == (byte) 1;
    this.FadeInOrOut = (byte) 0;
    this.FadeNowTime = 0.0f;
    this.FadeBeginAlpha = 0.0f;
    if (!GUIManager.Instance.bOpenOnIPhoneX || TargetAlpha != (byte) 1)
      return;
    ((Behaviour) this.m_BackBlock_L).enabled = false;
    ((Behaviour) this.m_BackBlock_R).enabled = false;
    ((Graphic) this.m_BackBlock_L).color = new Color(1f, 1f, 1f, 1f);
    ((Graphic) this.m_BackBlock_R).color = new Color(1f, 1f, 1f, 1f);
  }

  private void FadeInOutUpDate()
  {
    if (this.FadeInOrOut == (byte) 0)
      return;
    this.FadeNowTime += Time.smoothDeltaTime;
    if (this.FadeInOrOut == (byte) 1)
    {
      if ((double) this.FadeNowTime >= (double) this.FadeInTime)
      {
        this.SetFadeTargetAlpha((byte) 1);
      }
      else
      {
        float num = Mathf.Lerp(this.FadeBeginAlpha, 1f, this.FadeNowTime / this.FadeInTime);
        this.CGDoor.alpha = num;
        this.CGTop.alpha = num;
        if (!GUIManager.Instance.bOpenOnIPhoneX)
          return;
        ((Behaviour) this.m_BackBlock_L).enabled = true;
        ((Behaviour) this.m_BackBlock_R).enabled = true;
        ((Graphic) this.m_BackBlock_L).color = new Color(1f, 1f, 1f, 1f - num);
        ((Graphic) this.m_BackBlock_R).color = new Color(1f, 1f, 1f, 1f - num);
      }
    }
    else
    {
      if (this.FadeInOrOut != (byte) 2)
        return;
      if ((double) this.FadeNowTime >= (double) this.FadeOutTime)
      {
        this.SetFadeTargetAlpha((byte) 0);
      }
      else
      {
        float num = Mathf.Lerp(this.FadeBeginAlpha, 0.0f, this.FadeNowTime / this.FadeOutTime);
        this.CGDoor.alpha = num;
        this.CGTop.alpha = num;
        if (!GUIManager.Instance.bOpenOnIPhoneX)
          return;
        ((Behaviour) this.m_BackBlock_L).enabled = true;
        ((Behaviour) this.m_BackBlock_R).enabled = true;
        ((Graphic) this.m_BackBlock_L).color = new Color(1f, 1f, 1f, 1f - num);
        ((Graphic) this.m_BackBlock_R).color = new Color(1f, 1f, 1f, 1f - num);
      }
    }
  }

  private void ReSetPressPosition()
  {
    DataManager.msgBuffer[0] = (byte) 124;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  private void TrackBackGround()
  {
    if (!((Component) this.m_Background).gameObject.activeInHierarchy)
      return;
    Vector3 rotationRate = Input.gyro.rotationRate;
    rotationRate.x *= 0.5f;
    rotationRate.y *= 0.5f;
    this.BackGroundMoved += rotationRate;
    if ((double) this.BackGroundMoved.x < -40.0)
      this.BackGroundMoved.x = -40f;
    else if ((double) this.BackGroundMoved.x > 40.0)
      this.BackGroundMoved.x = 40f;
    if ((double) this.BackGroundMoved.y < -40.0)
      this.BackGroundMoved.y = -40f;
    else if ((double) this.BackGroundMoved.y > 40.0)
      this.BackGroundMoved.y = 40f;
    ((Transform) this.m_Background).localPosition = new Vector3(this.BackGroundMoved.y, this.BackGroundMoved.x, ((Transform) this.m_Background).localPosition.z);
  }
}
