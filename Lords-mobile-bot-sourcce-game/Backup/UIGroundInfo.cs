// Decompiled with JetBrains decompiler
// Type: UIGroundInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Text;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIGroundInfo : IUIButtonClickHandler, IUIButtonDownUpHandler, IUICalculatorHandler
{
  private const int m_StrCount = 51;
  private const int MaxTempTextNum = 52;
  private int[] ScoutNeedMoney_NpcCastle = new int[5]
  {
    250,
    1500,
    2250,
    3500,
    5000
  };
  private int[] ScoutNeedMoney = new int[25]
  {
    1000,
    1100,
    1200,
    1300,
    1400,
    1500,
    1600,
    1700,
    1800,
    1900,
    2000,
    2100,
    2200,
    2300,
    2400,
    2500,
    2600,
    2700,
    2800,
    2900,
    3000,
    3200,
    3400,
    3500,
    4000
  };
  public RectTransform m_Panel;
  public RectTransform m_TeamPanel;
  public GameObject m_PanelGameObject;
  public GameObject m_TeamPanelGameObject;
  public RectTransform m_SearchPanel;
  public RectTransform m_ReinforcePanel;
  public RectTransform m_DetectPanel;
  public RectTransform m_AttackPanel;
  public RectTransform m_BookmarksPanel;
  public RectTransform m_PvePanel;
  public RectTransform m_RewardPanel;
  public RectTransform m_TitlePanel;
  public RectTransform m_RectTransform;
  private Transform m_HintPanel;
  private RectTransform m_BGPanel;
  private Image m_BGIcon;
  private Image m_BGIconMask;
  private Transform m_CityOutwardLevelTf;
  private Image[] m_CityOutwardLevelImages = new Image[5];
  private RectTransform m_GroundTextBGRect;
  private UIText m_GroundTitle;
  private RectTransform m_ButtonPanel;
  private RectTransform m_ButtonRect1;
  private RectTransform m_ButtonRect2;
  private RectTransform m_ButtonRect3;
  private RectTransform m_ButtonRect4;
  private RectTransform m_ButtonRect5;
  private RectTransform m_ButtonRect6;
  private RectTransform m_ButtonRect7;
  private RectTransform m_ButtonRect8;
  private RectTransform m_ButtonRect9;
  private RectTransform m_ButtonRect10;
  private RectTransform m_ButtonRect11;
  private RectTransform m_CustmCastleExclamation;
  private UIButton[] m_Buttons = new UIButton[11];
  private UIText m_ButtonText1;
  private UIText m_ButtonText2;
  private UIText m_ButtonText3;
  private UIText m_ButtonText6;
  private UIText m_ButtonText7;
  private UIText m_ButtonText8;
  private UIText m_ButtonText9;
  private UIText m_ButtonText10;
  private UIText m_ButtonText11;
  private UIText m_LocationText;
  private UIButton m_BookmarkBtn;
  private UIButton m_ExpressionBtn;
  private UIButton m_TeamExpressionBtn;
  private Transform m_Exclamationmark;
  private Transform m_TeamExclamationmark;
  private Door m_Door;
  private AssetBundle m_AssetBundle;
  private int m_AssetBundleKey;
  public int m_MapPointID;
  public int m_MonsterMapPoint = -1;
  public EGroundInfoKind m_eGroundInfoKind;
  private RectTransform m_GroundPanel;
  private UIText m_GroundText;
  private RectTransform m_LocationRt;
  private RectTransform m_ChatBtnRt;
  private RectTransform m_ResourcePanel;
  private RectTransform m_ValueBar1;
  private RectTransform m_ValueBar2;
  private Image m_ResourceIcon;
  private UIText m_ResourceText;
  private UIText m_ResourceProductionTitle;
  private UIText m_ResourceProductionText;
  private UIText m_ResourceOwnerText;
  private Image m_Slider11;
  private Image m_Slider12;
  private Image m_Slider2;
  private UIText m_SliderText1;
  private UIText m_SliderText2;
  private UISpritesArray m_SpriteArray;
  private RectTransform m_CampPanel;
  private RectTransform m_CampTitleTextRt;
  private RectTransform m_IDTextRt;
  private Transform m_VipTf;
  private Transform m_RankTf;
  private UIHIBtn m_CampHiBtn;
  private UIText m_CampTitleText;
  private UIText m_IDText;
  private UIText m_StrengthText;
  private UIText m_WipeOutText;
  private UIText m_LeagueText;
  private UIText m_KingdomText;
  private UIText m_VipText;
  private UIText m_RankText;
  private Image m_RankImage;
  private Image m_TitleIcon;
  private Image m_WorldTitleIcon;
  private Image m_NobilityTitleIcon;
  private RectTransform m_WondersPanel;
  private RectTransform m_NpcCastlePanel;
  private UIButton m_InformationBtn;
  private UIButton m_TeamIDBtn;
  private UIButton m_TeamLocBtn;
  private UIButton m_TeamExitBtn;
  private UIButton m_TeamRetureBtn;
  private UIButton m_TeamSpeedBtn;
  private GameObject m_TeamSpeedBtnGameObject;
  private UIText m_TeamIDText;
  private UIText m_TeamLocText;
  private UIText m_TimeText;
  private UIText m_TeamReturnText;
  private UIText m_TeamTargetText;
  private Image m_TeamLocLine;
  private Image m_TeamIDLine;
  private UIEmojiInput inputField;
  private POINT_KIND m_PreKind = POINT_KIND.PK_MAX;
  private UIHIBtn m_PveHeroBtn;
  private UIText m_PveTitle;
  private UIText m_PveHeroName;
  private UIText m_PvePowerText;
  private Image m_PvePowerIcon;
  private UIButton m_RewardBtn;
  private UIText m_RewardText;
  private UIText m_HintText;
  private Image m_HintBg;
  private GameObject m_NpcCastleIcon;
  private Transform m_NpcCastleIconBone;
  private Image m_NpcCastleFrame;
  private UIText m_NpcCastleIDText;
  private UIText m_NpcCastleStrengthText;
  private UIText m_NpcCastleTimeText;
  private UIText m_NpcCastleInfoText;
  private GameObject m_NpcCastleDLImg;
  private GameObject m_TempNpcCastleDLImg;
  private UIButton m_NpcCastleInfoBtn;
  private Transform m_PetSkillTf;
  private UIButton m_PetSkillUse;
  private Image[] m_PetNegativeBuff = new Image[8];
  private ushort m_NpcCastleHeadID;
  private int m_NpcCastleHeadAssetKey;
  private StringBuilder sb;
  public Material TileMapMat;
  public Material WonderTileMapMat1;
  public Material WonderTileMapMat2;
  private CString[] m_Str = new CString[51];
  private CString BookMarkNameStr;
  public bool bHaveAlly_Self;
  public bool bHaveAlly;
  public byte m_ResType = 1;
  public int OwnerKind;
  private long m_ResStartTime;
  private uint m_ResTotalCount;
  private float m_ResRate;
  private uint m_MaxOverload;
  private float m_TimeTick;
  private float m_ResTextChangeTime = 1.5f;
  private byte m_ResTextType;
  private float delayOpenTime;
  private int delayMapInfoID;
  private POINT_KIND delayInfoKind = POINT_KIND.PK_MAX;
  private bool bHideSelectMod;
  private byte m_AttackSelect;
  private byte m_HideSelect;
  private byte m_BookmarkSelect;
  public bool bRequsetAdvanceMapdata;
  public int m_RequsetMapID = -1;
  public float m_RequsetTick;
  public ushort m_ModifyBookMarkID;
  public bool bOpenPvePanel;
  public byte m_ScoutTagLv;
  public bool bOpenUIExpedition_FromList;
  public bool bGroundInfoOpen;
  public ushort m_SearchLocationK;
  public ushort m_SearchLocationX;
  public ushort m_SearchLocationY;
  public byte m_SearchInput;
  public UIText m_WonderID;
  public UIText m_WonderState;
  public UIText m_WonderTime;
  public UIText m_WonderAlliance;
  public UIText m_WonderOwner;
  public UIText m_WonderKingdom;
  public UIText m_DetectPanelText;
  public Transform m_WonderTimeTF;
  public UIHIBtn m_WonderHIBtn;
  public Transform m_WonderAllianeIcon;
  public Image m_WonderAllianeFrame;
  public Image m_WonderStateImage1;
  public Image m_WonderStateImage2;
  public Image m_WonderStateImage3;
  private UIText[] m_TempText = new UIText[52];
  private int m_TempTextIdx;
  private UIText[] m_AttackPanelTimeText = new UIText[4];
  private UIText m_AttackPanelTitleText;
  private UIText m_AttackPanelInfoText;
  private UIText m_AttackPanelPosText;
  private UIButton[] m_AttackPanelTimeBtn = new UIButton[4];
  private Image[] m_AttackPanelTimeSelectImg = new Image[4];
  private Image m_AttackPanelIcon;
  private Transform m_AttackPanelPosTf;
  private UIGroundInfo._BookmarkSwitch BookmarkSwitch;
  private POINT_KIND m_infoKind;

  public void Refresh_FontTexture()
  {
    if ((Object) this.m_GroundTitle != (Object) null && ((Behaviour) this.m_GroundTitle).enabled)
    {
      ((Behaviour) this.m_GroundTitle).enabled = false;
      ((Behaviour) this.m_GroundTitle).enabled = true;
    }
    if ((Object) this.m_ButtonText1 != (Object) null && ((Behaviour) this.m_ButtonText1).enabled)
    {
      ((Behaviour) this.m_ButtonText1).enabled = false;
      ((Behaviour) this.m_ButtonText1).enabled = true;
    }
    if ((Object) this.m_ButtonText2 != (Object) null && ((Behaviour) this.m_ButtonText2).enabled)
    {
      ((Behaviour) this.m_ButtonText2).enabled = false;
      ((Behaviour) this.m_ButtonText2).enabled = true;
    }
    if ((Object) this.m_ButtonText3 != (Object) null && ((Behaviour) this.m_ButtonText3).enabled)
    {
      ((Behaviour) this.m_ButtonText3).enabled = false;
      ((Behaviour) this.m_ButtonText3).enabled = true;
    }
    if ((Object) this.m_ButtonText6 != (Object) null && ((Behaviour) this.m_ButtonText6).enabled)
    {
      ((Behaviour) this.m_ButtonText6).enabled = false;
      ((Behaviour) this.m_ButtonText6).enabled = true;
    }
    if ((Object) this.m_ButtonText7 != (Object) null && ((Behaviour) this.m_ButtonText7).enabled)
    {
      ((Behaviour) this.m_ButtonText7).enabled = false;
      ((Behaviour) this.m_ButtonText7).enabled = true;
    }
    if ((Object) this.m_ButtonText8 != (Object) null && ((Behaviour) this.m_ButtonText8).enabled)
    {
      ((Behaviour) this.m_ButtonText8).enabled = false;
      ((Behaviour) this.m_ButtonText8).enabled = true;
    }
    if ((Object) this.m_ButtonText9 != (Object) null && ((Behaviour) this.m_ButtonText9).enabled)
    {
      ((Behaviour) this.m_ButtonText9).enabled = false;
      ((Behaviour) this.m_ButtonText9).enabled = true;
    }
    if ((Object) this.m_ButtonText10 != (Object) null && ((Behaviour) this.m_ButtonText10).enabled)
    {
      ((Behaviour) this.m_ButtonText10).enabled = false;
      ((Behaviour) this.m_ButtonText10).enabled = true;
    }
    if ((Object) this.m_LocationText != (Object) null && ((Behaviour) this.m_LocationText).enabled)
    {
      ((Behaviour) this.m_LocationText).enabled = false;
      ((Behaviour) this.m_LocationText).enabled = true;
    }
    if ((Object) this.m_GroundText != (Object) null && ((Behaviour) this.m_GroundText).enabled)
    {
      ((Behaviour) this.m_GroundText).enabled = false;
      ((Behaviour) this.m_GroundText).enabled = true;
    }
    if ((Object) this.m_ResourceText != (Object) null && ((Behaviour) this.m_ResourceText).enabled)
    {
      ((Behaviour) this.m_ResourceText).enabled = false;
      ((Behaviour) this.m_ResourceText).enabled = true;
    }
    if ((Object) this.m_ResourceProductionTitle != (Object) null && ((Behaviour) this.m_ResourceProductionTitle).enabled)
    {
      ((Behaviour) this.m_ResourceProductionTitle).enabled = false;
      ((Behaviour) this.m_ResourceProductionTitle).enabled = true;
    }
    if ((Object) this.m_ResourceProductionText != (Object) null && ((Behaviour) this.m_ResourceProductionText).enabled)
    {
      ((Behaviour) this.m_ResourceProductionText).enabled = false;
      ((Behaviour) this.m_ResourceProductionText).enabled = true;
    }
    if ((Object) this.m_ResourceOwnerText != (Object) null && ((Behaviour) this.m_ResourceOwnerText).enabled)
    {
      ((Behaviour) this.m_ResourceOwnerText).enabled = false;
      ((Behaviour) this.m_ResourceOwnerText).enabled = true;
    }
    if ((Object) this.m_SliderText1 != (Object) null && ((Behaviour) this.m_SliderText1).enabled)
    {
      ((Behaviour) this.m_SliderText1).enabled = false;
      ((Behaviour) this.m_SliderText1).enabled = true;
    }
    if ((Object) this.m_SliderText2 != (Object) null && ((Behaviour) this.m_SliderText2).enabled)
    {
      ((Behaviour) this.m_SliderText2).enabled = false;
      ((Behaviour) this.m_SliderText2).enabled = true;
    }
    if ((Object) this.m_CampTitleText != (Object) null && ((Behaviour) this.m_CampTitleText).enabled)
    {
      ((Behaviour) this.m_CampTitleText).enabled = false;
      ((Behaviour) this.m_CampTitleText).enabled = true;
    }
    if ((Object) this.m_IDText != (Object) null && ((Behaviour) this.m_IDText).enabled)
    {
      ((Behaviour) this.m_IDText).enabled = false;
      ((Behaviour) this.m_IDText).enabled = true;
    }
    if ((Object) this.m_StrengthText != (Object) null && ((Behaviour) this.m_StrengthText).enabled)
    {
      ((Behaviour) this.m_StrengthText).enabled = false;
      ((Behaviour) this.m_StrengthText).enabled = true;
    }
    if ((Object) this.m_WipeOutText != (Object) null && ((Behaviour) this.m_WipeOutText).enabled)
    {
      ((Behaviour) this.m_WipeOutText).enabled = false;
      ((Behaviour) this.m_WipeOutText).enabled = true;
    }
    if ((Object) this.m_LeagueText != (Object) null && ((Behaviour) this.m_LeagueText).enabled)
    {
      ((Behaviour) this.m_LeagueText).enabled = false;
      ((Behaviour) this.m_LeagueText).enabled = true;
    }
    if ((Object) this.m_KingdomText != (Object) null && ((Behaviour) this.m_KingdomText).enabled)
    {
      ((Behaviour) this.m_KingdomText).enabled = false;
      ((Behaviour) this.m_KingdomText).enabled = true;
    }
    if ((Object) this.m_VipText != (Object) null && ((Behaviour) this.m_VipText).enabled)
    {
      ((Behaviour) this.m_VipText).enabled = false;
      ((Behaviour) this.m_VipText).enabled = true;
    }
    if ((Object) this.m_RankText != (Object) null && ((Behaviour) this.m_RankText).enabled)
    {
      ((Behaviour) this.m_RankText).enabled = false;
      ((Behaviour) this.m_RankText).enabled = true;
    }
    if ((Object) this.m_TeamLocText != (Object) null && ((Behaviour) this.m_TeamLocText).enabled)
    {
      ((Behaviour) this.m_TeamLocText).enabled = false;
      ((Behaviour) this.m_TeamLocText).enabled = true;
    }
    if ((Object) this.m_TimeText != (Object) null && ((Behaviour) this.m_TimeText).enabled)
    {
      ((Behaviour) this.m_TimeText).enabled = false;
      ((Behaviour) this.m_TimeText).enabled = true;
    }
    if ((Object) this.m_TeamReturnText != (Object) null && ((Behaviour) this.m_TeamReturnText).enabled)
    {
      ((Behaviour) this.m_TeamReturnText).enabled = false;
      ((Behaviour) this.m_TeamReturnText).enabled = true;
    }
    if ((Object) this.m_TeamTargetText != (Object) null && ((Behaviour) this.m_TeamTargetText).enabled)
    {
      ((Behaviour) this.m_TeamTargetText).enabled = false;
      ((Behaviour) this.m_TeamTargetText).enabled = true;
    }
    if ((Object) this.m_PveTitle != (Object) null && ((Behaviour) this.m_PveTitle).enabled)
    {
      ((Behaviour) this.m_PveTitle).enabled = false;
      ((Behaviour) this.m_PveTitle).enabled = true;
    }
    if ((Object) this.m_PveHeroName != (Object) null && ((Behaviour) this.m_PveHeroName).enabled)
    {
      ((Behaviour) this.m_PveHeroName).enabled = false;
      ((Behaviour) this.m_PveHeroName).enabled = true;
    }
    if ((Object) this.m_PvePowerText != (Object) null && ((Behaviour) this.m_PvePowerText).enabled)
    {
      ((Behaviour) this.m_PvePowerText).enabled = false;
      ((Behaviour) this.m_PvePowerText).enabled = true;
    }
    if ((Object) this.m_RewardText != (Object) null && ((Behaviour) this.m_RewardText).enabled)
    {
      ((Behaviour) this.m_RewardText).enabled = false;
      ((Behaviour) this.m_RewardText).enabled = true;
    }
    if ((Object) this.m_HintText != (Object) null && ((Behaviour) this.m_HintText).enabled)
    {
      ((Behaviour) this.m_HintText).enabled = false;
      ((Behaviour) this.m_HintText).enabled = true;
    }
    if ((Object) this.m_TeamIDText != (Object) null && ((Behaviour) this.m_TeamIDText).enabled)
    {
      ((Behaviour) this.m_TeamIDText).enabled = false;
      ((Behaviour) this.m_TeamIDText).enabled = true;
    }
    if (this.m_TempText != null)
    {
      for (int index = 0; index < this.m_TempText.Length; ++index)
      {
        if ((Object) this.m_TempText[index] != (Object) null && ((Behaviour) this.m_TempText[index]).enabled)
        {
          ((Behaviour) this.m_TempText[index]).enabled = false;
          ((Behaviour) this.m_TempText[index]).enabled = true;
        }
      }
    }
    if ((Object) this.inputField != (Object) null)
    {
      if ((Object) this.inputField.textComponent != (Object) null && ((Behaviour) this.inputField.textComponent).enabled)
      {
        ((Behaviour) this.inputField.placeholder).enabled = false;
        ((Behaviour) this.inputField.placeholder).enabled = true;
      }
      if ((Object) this.inputField.placeholder != (Object) null && ((Behaviour) this.inputField.placeholder).enabled)
      {
        ((Behaviour) this.inputField.placeholder).enabled = false;
        ((Behaviour) this.inputField.placeholder).enabled = true;
      }
    }
    if ((Object) this.m_CampHiBtn != (Object) null && ((Behaviour) this.m_CampHiBtn).enabled)
      this.m_CampHiBtn.Refresh_FontTexture();
    if ((Object) this.m_PveHeroBtn != (Object) null && ((Behaviour) this.m_PveHeroBtn).enabled)
      this.m_PveHeroBtn.Refresh_FontTexture();
    if ((Object) this.m_WonderID != (Object) null && ((Behaviour) this.m_WonderID).enabled)
    {
      ((Behaviour) this.m_WonderID).enabled = false;
      ((Behaviour) this.m_WonderID).enabled = true;
    }
    if ((Object) this.m_WonderState != (Object) null && ((Behaviour) this.m_WonderState).enabled)
    {
      ((Behaviour) this.m_WonderState).enabled = false;
      ((Behaviour) this.m_WonderState).enabled = true;
    }
    if ((Object) this.m_WonderTime != (Object) null && ((Behaviour) this.m_WonderTime).enabled)
    {
      ((Behaviour) this.m_WonderTime).enabled = false;
      ((Behaviour) this.m_WonderTime).enabled = true;
    }
    if ((Object) this.m_WonderAlliance != (Object) null && ((Behaviour) this.m_WonderAlliance).enabled)
    {
      ((Behaviour) this.m_WonderAlliance).enabled = false;
      ((Behaviour) this.m_WonderAlliance).enabled = true;
    }
    if ((Object) this.m_WonderOwner != (Object) null && ((Behaviour) this.m_WonderOwner).enabled)
    {
      ((Behaviour) this.m_WonderOwner).enabled = false;
      ((Behaviour) this.m_WonderOwner).enabled = true;
    }
    if ((Object) this.m_WonderKingdom != (Object) null && ((Behaviour) this.m_WonderKingdom).enabled)
    {
      ((Behaviour) this.m_WonderKingdom).enabled = false;
      ((Behaviour) this.m_WonderKingdom).enabled = true;
    }
    if ((Object) this.m_DetectPanelText != (Object) null && ((Behaviour) this.m_DetectPanelText).enabled)
    {
      ((Behaviour) this.m_DetectPanelText).enabled = false;
      ((Behaviour) this.m_DetectPanelText).enabled = true;
    }
    if (this.m_AttackPanelTimeText != null)
    {
      for (int index = 0; index < this.m_AttackPanelTimeText.Length; ++index)
      {
        if ((Object) this.m_AttackPanelTimeText[index] != (Object) null && ((Behaviour) this.m_AttackPanelTimeText[index]).enabled)
        {
          ((Behaviour) this.m_AttackPanelTimeText[index]).enabled = false;
          ((Behaviour) this.m_AttackPanelTimeText[index]).enabled = true;
        }
      }
    }
    if ((Object) this.m_AttackPanelTitleText != (Object) null && ((Behaviour) this.m_AttackPanelTitleText).enabled)
    {
      ((Behaviour) this.m_AttackPanelTitleText).enabled = false;
      ((Behaviour) this.m_AttackPanelTitleText).enabled = true;
    }
    if ((Object) this.m_AttackPanelInfoText != (Object) null && ((Behaviour) this.m_AttackPanelInfoText).enabled)
    {
      ((Behaviour) this.m_AttackPanelInfoText).enabled = false;
      ((Behaviour) this.m_AttackPanelInfoText).enabled = true;
    }
    if ((Object) this.m_AttackPanelPosText != (Object) null && ((Behaviour) this.m_AttackPanelPosText).enabled)
    {
      ((Behaviour) this.m_AttackPanelPosText).enabled = false;
      ((Behaviour) this.m_AttackPanelPosText).enabled = true;
    }
    if ((Object) this.m_NpcCastleIDText != (Object) null && ((Behaviour) this.m_NpcCastleIDText).enabled)
    {
      ((Behaviour) this.m_NpcCastleIDText).enabled = false;
      ((Behaviour) this.m_NpcCastleIDText).enabled = true;
    }
    if ((Object) this.m_NpcCastleStrengthText != (Object) null && ((Behaviour) this.m_NpcCastleStrengthText).enabled)
    {
      ((Behaviour) this.m_NpcCastleStrengthText).enabled = false;
      ((Behaviour) this.m_NpcCastleStrengthText).enabled = true;
    }
    if ((Object) this.m_NpcCastleTimeText != (Object) null && ((Behaviour) this.m_NpcCastleTimeText).enabled)
    {
      ((Behaviour) this.m_NpcCastleTimeText).enabled = false;
      ((Behaviour) this.m_NpcCastleTimeText).enabled = true;
    }
    if (!((Object) this.m_NpcCastleInfoText != (Object) null) || !((Behaviour) this.m_NpcCastleInfoText).enabled)
      return;
    ((Behaviour) this.m_NpcCastleInfoText).enabled = false;
    ((Behaviour) this.m_NpcCastleInfoText).enabled = true;
  }

  public void Load(Door door)
  {
    this.sb = new StringBuilder();
    for (int index = 0; index < 51; ++index)
      this.m_Str[index] = StringManager.Instance.SpawnString(100);
    this.BookMarkNameStr = StringManager.Instance.SpawnString();
    this.m_AssetBundle = AssetManager.GetAssetBundle("UI/UIGroundInfo", out this.m_AssetBundleKey);
    if ((Object) this.m_AssetBundle == (Object) null)
      return;
    GameObject gameObject = (GameObject) Object.Instantiate(this.m_AssetBundle.mainAsset);
    this.m_RectTransform = (RectTransform) gameObject.transform;
    this.m_Door = door;
    ((Transform) this.m_RectTransform).SetParent((Transform) this.m_Door.m_TopLayer, false);
    this.m_Panel = (RectTransform) ((Transform) this.m_RectTransform).GetChild(0);
    this.m_PanelGameObject = ((Component) this.m_Panel).gameObject;
    this.m_PanelGameObject.SetActive(false);
    this.m_TeamPanel = (RectTransform) ((Transform) this.m_RectTransform).GetChild(1);
    this.m_TeamPanelGameObject = ((Component) this.m_TeamPanel).gameObject;
    this.m_TeamPanelGameObject.SetActive(false);
    Transform transform = (Transform) null;
    this.m_BGPanel = (RectTransform) ((Transform) this.m_Panel).GetChild(0);
    this.m_ButtonPanel = (RectTransform) ((Transform) this.m_Panel).GetChild(1);
    this.m_GroundPanel = (RectTransform) ((Transform) this.m_Panel).GetChild(2);
    this.m_ResourcePanel = (RectTransform) ((Transform) this.m_Panel).GetChild(3);
    this.m_CampPanel = (RectTransform) ((Transform) this.m_Panel).GetChild(4);
    this.m_WondersPanel = (RectTransform) ((Transform) this.m_Panel).GetChild(5);
    this.m_NpcCastlePanel = (RectTransform) ((Transform) this.m_Panel).GetChild(6);
    this.m_LocationRt = (RectTransform) ((Transform) this.m_Panel).GetChild(7);
    this.m_LocationText = ((Transform) this.m_Panel).GetChild(7).GetComponent<UIText>();
    this.m_LocationText.font = GUIManager.Instance.GetTTFFont();
    this.m_ChatBtnRt = (RectTransform) ((Transform) this.m_Panel).GetChild(8);
    this.m_BookmarkBtn = ((Transform) this.m_Panel).GetChild(9).GetComponent<UIButton>();
    this.m_ExpressionBtn = ((Transform) this.m_Panel).GetChild(11).GetComponent<UIButton>();
    this.m_ExpressionBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_ExpressionBtn.m_BtnID2 = 329;
    this.m_Exclamationmark = ((Transform) this.m_Panel).GetChild(11).GetChild(0);
    for (int index = 8; index < 11; ++index)
      ((Transform) this.m_Panel).GetChild(index).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_GroundTextBGRect = (RectTransform) ((Transform) this.m_BGPanel).GetChild(2);
    Transform child1 = ((Transform) this.m_BGPanel).GetChild(4).GetChild(0);
    this.m_BGIcon = child1.GetComponent<Image>();
    UIButtonHint uiButtonHint1 = child1.gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint1.Parm1 = (ushort) 11;
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    this.m_BGIconMask = child1.GetChild(0).GetComponent<Image>();
    this.m_GroundTitle = ((Transform) this.m_BGPanel).GetChild(5).GetComponent<UIText>();
    this.m_GroundTitle.font = GUIManager.Instance.GetTTFFont();
    this.m_GroundTitle.text = DataManager.Instance.mStringTable.GetStringByID(4579U);
    this.m_CityOutwardLevelTf = ((Transform) this.m_BGPanel).GetChild(4).GetChild(0).GetChild(1);
    for (int index = 0; index < this.m_CityOutwardLevelImages.Length; ++index)
    {
      Transform child2 = this.m_CityOutwardLevelTf.GetChild(index);
      if ((Object) child2 != (Object) null)
        this.m_CityOutwardLevelImages[index] = child2.GetComponent<Image>();
    }
    this.m_ButtonRect1 = (RectTransform) ((Transform) this.m_ButtonPanel).GetChild(0);
    this.m_Buttons[0] = ((Component) this.m_ButtonRect1).GetComponent<UIButton>();
    this.m_Buttons[0].m_Handler = (IUIButtonClickHandler) this;
    this.m_ButtonText1 = ((Transform) this.m_ButtonRect1).GetChild(0).GetComponent<UIText>();
    this.m_ButtonText1.font = GUIManager.Instance.GetTTFFont();
    this.m_ButtonRect2 = (RectTransform) ((Transform) this.m_ButtonPanel).GetChild(1);
    this.m_Buttons[1] = ((Component) this.m_ButtonRect2).GetComponent<UIButton>();
    this.m_Buttons[1].m_Handler = (IUIButtonClickHandler) this;
    this.m_ButtonText2 = ((Transform) this.m_ButtonRect2).GetChild(0).GetComponent<UIText>();
    this.m_ButtonText2.font = GUIManager.Instance.GetTTFFont();
    this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4538U);
    this.m_ButtonRect3 = (RectTransform) ((Transform) this.m_ButtonPanel).GetChild(2);
    this.m_Buttons[2] = ((Component) this.m_ButtonRect3).GetComponent<UIButton>();
    this.m_Buttons[2].m_Handler = (IUIButtonClickHandler) this;
    this.m_ButtonText3 = ((Transform) this.m_ButtonRect3).GetChild(0).GetComponent<UIText>();
    this.m_ButtonText3.font = GUIManager.Instance.GetTTFFont();
    this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4544U);
    this.m_ButtonRect4 = (RectTransform) ((Transform) this.m_ButtonPanel).GetChild(3);
    transform = ((Transform) this.m_ButtonRect4).GetChild(0);
    this.m_Buttons[3] = ((Component) this.m_ButtonRect4).GetComponent<UIButton>();
    this.m_Buttons[3].m_Handler = (IUIButtonClickHandler) this;
    UIText component1 = ((Transform) this.m_ButtonRect4).GetChild(1).GetComponent<UIText>();
    component1.font = GUIManager.Instance.GetTTFFont();
    component1.text = DataManager.Instance.mStringTable.GetStringByID(4533U);
    this.m_TempText[this.m_TempTextIdx++] = component1;
    this.m_ButtonRect5 = (RectTransform) ((Transform) this.m_ButtonPanel).GetChild(4);
    transform = ((Transform) this.m_ButtonRect5).GetChild(0);
    this.m_Buttons[4] = ((Component) this.m_ButtonRect5).GetComponent<UIButton>();
    this.m_Buttons[4].m_Handler = (IUIButtonClickHandler) this;
    UIText component2 = ((Transform) this.m_ButtonRect5).GetChild(1).GetComponent<UIText>();
    component2.font = GUIManager.Instance.GetTTFFont();
    component2.text = DataManager.Instance.mStringTable.GetStringByID(4534U);
    this.m_TempText[this.m_TempTextIdx++] = component2;
    this.m_ButtonRect6 = (RectTransform) ((Transform) this.m_ButtonPanel).GetChild(5);
    this.m_Buttons[5] = ((Component) this.m_ButtonRect6).GetComponent<UIButton>();
    this.m_Buttons[5].m_Handler = (IUIButtonClickHandler) this;
    this.m_ButtonText6 = ((Transform) this.m_ButtonRect6).GetChild(0).GetComponent<UIText>();
    this.m_ButtonText6.font = GUIManager.Instance.GetTTFFont();
    this.m_ButtonRect7 = (RectTransform) ((Transform) this.m_ButtonPanel).GetChild(6);
    this.m_Buttons[6] = ((Component) this.m_ButtonRect7).GetComponent<UIButton>();
    this.m_Buttons[6].m_Handler = (IUIButtonClickHandler) this;
    this.m_ButtonText7 = ((Transform) this.m_ButtonRect7).GetChild(0).GetComponent<UIText>();
    this.m_ButtonText7.font = GUIManager.Instance.GetTTFFont();
    this.m_ButtonRect8 = (RectTransform) ((Transform) this.m_ButtonPanel).GetChild(7);
    this.m_Buttons[7] = ((Component) this.m_ButtonRect8).GetComponent<UIButton>();
    this.m_Buttons[7].m_Handler = (IUIButtonClickHandler) this;
    this.m_ButtonText8 = ((Transform) this.m_ButtonRect8).GetChild(0).GetComponent<UIText>();
    this.m_ButtonText8.font = GUIManager.Instance.GetTTFFont();
    this.m_ButtonRect9 = (RectTransform) ((Transform) this.m_ButtonPanel).GetChild(8);
    this.m_Buttons[8] = ((Component) this.m_ButtonRect9).GetComponent<UIButton>();
    this.m_Buttons[8].m_Handler = (IUIButtonClickHandler) this;
    this.m_ButtonText9 = ((Transform) this.m_ButtonRect9).GetChild(0).GetComponent<UIText>();
    this.m_ButtonText9.font = GUIManager.Instance.GetTTFFont();
    this.m_ButtonRect10 = (RectTransform) ((Transform) this.m_ButtonPanel).GetChild(9);
    this.m_CustmCastleExclamation = (RectTransform) ((Transform) this.m_ButtonPanel).GetChild(9).GetChild(2);
    this.m_Buttons[9] = ((Component) this.m_ButtonRect10).GetComponent<UIButton>();
    this.m_Buttons[9].m_Handler = (IUIButtonClickHandler) this;
    this.m_ButtonText10 = ((Transform) this.m_ButtonRect10).GetChild(0).GetComponent<UIText>();
    this.m_ButtonText10.font = GUIManager.Instance.GetTTFFont();
    this.m_ButtonRect11 = (RectTransform) ((Transform) this.m_ButtonPanel).GetChild(10);
    this.m_Buttons[10] = ((Component) this.m_ButtonRect11).GetComponent<UIButton>();
    this.m_Buttons[10].m_Handler = (IUIButtonClickHandler) this;
    this.m_ButtonText11 = ((Transform) this.m_ButtonRect11).GetChild(0).GetComponent<UIText>();
    this.m_ButtonText11.font = GUIManager.Instance.GetTTFFont();
    this.m_GroundText = ((Transform) this.m_GroundPanel).GetChild(0).GetComponent<UIText>();
    this.m_GroundText.font = GUIManager.Instance.GetTTFFont();
    this.m_SpriteArray = ((Component) this.m_ResourcePanel).GetComponent<UISpritesArray>();
    this.m_ResourceIcon = ((Transform) this.m_ResourcePanel).GetChild(0).GetComponent<Image>();
    this.m_ResourceText = ((Transform) this.m_ResourcePanel).GetChild(1).GetComponent<UIText>();
    this.m_ResourceText.font = GUIManager.Instance.GetTTFFont();
    this.m_ResourceProductionTitle = ((Transform) this.m_ResourcePanel).GetChild(2).GetComponent<UIText>();
    this.m_ResourceProductionTitle.font = GUIManager.Instance.GetTTFFont();
    this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4524U);
    this.m_ResourceProductionText = ((Transform) this.m_ResourcePanel).GetChild(3).GetComponent<UIText>();
    this.m_ResourceProductionText.font = GUIManager.Instance.GetTTFFont();
    UIText component3 = ((Transform) this.m_ResourcePanel).GetChild(4).GetComponent<UIText>();
    component3.font = GUIManager.Instance.GetTTFFont();
    component3.text = DataManager.Instance.mStringTable.GetStringByID(4530U);
    this.m_TempText[this.m_TempTextIdx++] = component3;
    this.m_ResourceOwnerText = ((Transform) this.m_ResourcePanel).GetChild(5).GetComponent<UIText>();
    this.m_ResourceOwnerText.font = GUIManager.Instance.GetTTFFont();
    this.m_ValueBar1 = ((Transform) this.m_ResourcePanel).GetChild(9).GetComponent<RectTransform>();
    this.m_Slider11 = ((Transform) this.m_ValueBar1).GetChild(0).GetComponent<Image>();
    this.m_Slider12 = ((Transform) this.m_ValueBar1).GetChild(1).GetComponent<Image>();
    this.m_SliderText1 = ((Transform) this.m_ValueBar1).GetChild(2).GetComponent<UIText>();
    this.m_SliderText1.font = GUIManager.Instance.GetTTFFont();
    this.m_ValueBar2 = ((Transform) this.m_ResourcePanel).GetChild(10).GetComponent<RectTransform>();
    this.m_Slider2 = ((Transform) this.m_ValueBar2).GetChild(0).GetComponent<Image>();
    this.m_SliderText2 = ((Transform) this.m_ValueBar2).GetChild(1).GetComponent<UIText>();
    this.m_SliderText2.font = GUIManager.Instance.GetTTFFont();
    this.m_InformationBtn = ((Transform) this.m_ResourcePanel).GetChild(11).GetComponent<UIButton>();
    this.m_InformationBtn.m_BtnID2 = 323;
    this.m_InformationBtn.m_Handler = (IUIButtonClickHandler) this;
    if (GUIManager.Instance.IsArabic)
      ((Component) this.m_InformationBtn).gameObject.AddComponent<ArabicItemTextureRot>();
    Transform child3 = gameObject.transform.GetChild(0).GetChild(4);
    this.m_CampHiBtn = child3.GetChild(4).GetComponent<UIHIBtn>();
    ((Component) this.m_CampHiBtn).transform.gameObject.AddComponent<IgnoreRaycast>();
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_CampHiBtn).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.m_CampTitleTextRt = child3.GetChild(5).GetComponent<RectTransform>();
    this.m_CampTitleText = child3.GetChild(5).GetComponent<UIText>();
    this.m_IDTextRt = child3.GetChild(6).GetComponent<RectTransform>();
    this.m_IDText = child3.GetChild(6).GetComponent<UIText>();
    this.m_StrengthText = child3.GetChild(7).GetComponent<UIText>();
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component4 = child3.GetChild(7).GetChild(0).GetComponent<RectTransform>();
      Vector2 anchoredPosition = component4.anchoredPosition with
      {
        x = 130f
      };
      component4.anchoredPosition = anchoredPosition;
      RectTransform component5 = child3.GetChild(8).GetChild(0).GetComponent<RectTransform>();
      anchoredPosition.x = 130f;
      component5.anchoredPosition = anchoredPosition;
    }
    UIButtonHint uiButtonHint2 = child3.GetChild(7).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint2.Parm1 = (ushort) 3;
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    UIButtonHint uiButtonHint3 = child3.GetChild(7).GetChild(0).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint3.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint3.Parm1 = (ushort) 3;
    uiButtonHint3.m_eHint = EUIButtonHint.DownUpHandler;
    this.m_WipeOutText = child3.GetChild(8).GetComponent<UIText>();
    UIButtonHint uiButtonHint4 = child3.GetChild(8).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint4.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint4.Parm1 = (ushort) 4;
    uiButtonHint4.m_eHint = EUIButtonHint.DownUpHandler;
    UIButtonHint uiButtonHint5 = child3.GetChild(8).GetChild(0).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint5.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint5.Parm1 = (ushort) 4;
    uiButtonHint5.m_eHint = EUIButtonHint.DownUpHandler;
    this.m_LeagueText = child3.GetChild(9).GetComponent<UIText>();
    this.m_KingdomText = child3.GetChild(10).GetComponent<UIText>();
    this.m_CampTitleText.font = GUIManager.Instance.GetTTFFont();
    this.m_IDText.font = GUIManager.Instance.GetTTFFont();
    this.m_StrengthText.font = GUIManager.Instance.GetTTFFont();
    this.m_WipeOutText.font = GUIManager.Instance.GetTTFFont();
    this.m_LeagueText.font = GUIManager.Instance.GetTTFFont();
    this.m_KingdomText.font = GUIManager.Instance.GetTTFFont();
    this.m_VipText = ((Transform) this.m_CampPanel).GetChild(3).GetChild(1).GetComponent<UIText>();
    this.m_VipText.font = GUIManager.Instance.GetTTFFont();
    this.m_VipTf = ((Transform) this.m_CampPanel).GetChild(3);
    if (GUIManager.Instance.IsArabic)
    {
      Vector2 anchoredPosition = this.m_VipTf.GetChild(0).GetComponent<RectTransform>().anchoredPosition;
      Vector3 localScale = ((Transform) this.m_VipTf.GetChild(0).GetComponent<RectTransform>()).localScale;
      localScale.x *= -1f;
      ((Transform) this.m_VipTf.GetChild(0).GetComponent<RectTransform>()).localScale = localScale;
      anchoredPosition.x = 38f;
      this.m_VipTf.GetChild(0).GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
    }
    this.m_RankText = ((Transform) this.m_CampPanel).GetChild(2).GetChild(1).GetComponent<UIText>();
    this.m_RankText.font = GUIManager.Instance.GetTTFFont();
    this.m_RankTf = ((Transform) this.m_CampPanel).GetChild(2);
    if (GUIManager.Instance.IsArabic)
    {
      Vector2 anchoredPosition = this.m_RankTf.GetChild(0).GetComponent<RectTransform>().anchoredPosition;
      Vector3 localScale = ((Transform) this.m_RankTf.GetChild(0).GetComponent<RectTransform>()).localScale;
      localScale.x *= -1f;
      ((Transform) this.m_RankTf.GetChild(0).GetComponent<RectTransform>()).localScale = localScale;
      anchoredPosition.x = -51f;
      this.m_RankTf.GetChild(0).GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
    }
    UIButtonHint uiButtonHint6 = this.m_RankTf.gameObject.AddComponent<UIButtonHint>();
    uiButtonHint6.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint6.Parm1 = (ushort) 1;
    uiButtonHint6.m_eHint = EUIButtonHint.DownUpHandler;
    UIButtonHint uiButtonHint7 = this.m_VipTf.gameObject.AddComponent<UIButtonHint>();
    uiButtonHint7.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint7.Parm1 = (ushort) 2;
    uiButtonHint7.m_eHint = EUIButtonHint.DownUpHandler;
    this.m_RankImage = this.m_RankTf.GetChild(0).GetComponent<Image>();
    this.m_TitleIcon = ((Transform) this.m_CampPanel).GetChild(11).GetComponent<Image>();
    UIButtonHint uiButtonHint8 = ((Transform) this.m_CampPanel).GetChild(11).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint8.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint8.Parm1 = (ushort) 5;
    uiButtonHint8.m_eHint = EUIButtonHint.DownUpHandler;
    this.m_WorldTitleIcon = ((Transform) this.m_CampPanel).GetChild(12).GetComponent<Image>();
    UIButtonHint uiButtonHint9 = ((Transform) this.m_CampPanel).GetChild(12).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint9.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint9.Parm1 = (ushort) 8;
    uiButtonHint9.m_eHint = EUIButtonHint.DownUpHandler;
    this.m_NobilityTitleIcon = ((Transform) this.m_CampPanel).GetChild(13).GetComponent<Image>();
    UIButtonHint uiButtonHint10 = ((Transform) this.m_CampPanel).GetChild(13).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint10.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint10.Parm1 = (ushort) 12;
    uiButtonHint10.m_eHint = EUIButtonHint.DownUpHandler;
    this.m_PetSkillTf = ((Transform) this.m_CampPanel).GetChild(14);
    this.m_PetSkillUse = ((Transform) this.m_CampPanel).GetChild(15).GetComponent<UIButton>();
    this.m_PetSkillUse.m_Handler = (IUIButtonClickHandler) this;
    this.m_PetSkillUse.m_BtnID2 = 331;
    for (int index = 0; index < this.m_PetNegativeBuff.Length; ++index)
    {
      this.m_PetNegativeBuff[index] = this.m_PetSkillTf.GetChild(index + 1).GetComponent<Image>();
      Image component6 = ((Component) this.m_PetNegativeBuff[index]).transform.GetChild(0).GetComponent<Image>();
      component6.sprite = GUIManager.Instance.LoadFrameSprite("sk");
      ((MaskableGraphic) component6).material = GUIManager.Instance.GetFrameMaterial();
      UIButtonHint uiButtonHint11 = this.m_PetSkillTf.GetChild(index + 1).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint11.m_DownUpHandler = (IUIButtonDownUpHandler) this;
      uiButtonHint11.Parm1 = (ushort) 14;
      uiButtonHint11.Parm2 = (byte) index;
      uiButtonHint11.m_eHint = EUIButtonHint.DownUpHandler;
    }
    this.m_HintPanel = ((Transform) this.m_RectTransform).GetChild(9);
    this.m_HintBg = ((Transform) this.m_RectTransform).GetChild(9).GetComponent<Image>();
    this.m_HintText = this.m_HintPanel.GetChild(0).GetComponent<UIText>();
    this.m_HintText.font = GUIManager.Instance.GetTTFFont();
    Image component7 = this.m_HintPanel.GetComponent<Image>();
    component7.sprite = door.LoadSprite("UI_main_box_012");
    ((MaskableGraphic) component7).material = door.LoadMaterial();
    component7.type = (Image.Type) 1;
    this.m_WonderAllianeIcon = ((Transform) this.m_WondersPanel).GetChild(1);
    GUIManager.Instance.InitBadgeTotem(this.m_WonderAllianeIcon, (ushort) 0);
    this.m_WonderAllianeFrame = ((Transform) this.m_WondersPanel).GetChild(0).GetComponent<Image>();
    this.m_WonderHIBtn = ((Transform) this.m_WondersPanel).GetChild(2).GetComponent<UIHIBtn>();
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_WonderHIBtn).transform, eHeroOrItem.Hero, (ushort) 11, (byte) 1, (byte) 0, bShowText: false, bAutoShowHint: false);
    if (GUIManager.Instance.IsArabic)
      ((Component) this.m_WonderHIBtn).transform.GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
    this.m_WonderID = ((Transform) this.m_WondersPanel).GetChild(4).GetComponent<UIText>();
    this.m_WonderID.font = GUIManager.Instance.GetTTFFont();
    this.m_WonderState = ((Transform) this.m_WondersPanel).GetChild(5).GetComponent<UIText>();
    UIButtonHint uiButtonHint12 = ((Transform) this.m_WondersPanel).GetChild(5).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint12.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint12.Parm1 = (ushort) 6;
    uiButtonHint12.m_eHint = EUIButtonHint.DownUpHandler;
    UIButtonHint uiButtonHint13 = ((Transform) this.m_WondersPanel).GetChild(6).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint13.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint13.Parm1 = (ushort) 7;
    uiButtonHint13.m_eHint = EUIButtonHint.DownUpHandler;
    this.m_WonderState.font = GUIManager.Instance.GetTTFFont();
    this.m_WonderStateImage1 = ((Transform) this.m_WondersPanel).GetChild(5).GetChild(0).GetComponent<Image>();
    this.m_WonderStateImage2 = ((Transform) this.m_WondersPanel).GetChild(5).GetChild(1).GetComponent<Image>();
    this.m_WonderStateImage3 = ((Transform) this.m_WondersPanel).GetChild(5).GetChild(2).GetComponent<Image>();
    this.m_WonderTimeTF = ((Transform) this.m_WondersPanel).GetChild(6);
    this.m_WonderTime = this.m_WonderTimeTF.GetComponent<UIText>();
    this.m_WonderTime.font = GUIManager.Instance.GetTTFFont();
    if (GUIManager.Instance.IsArabic)
    {
      Vector2 anchoredPosition = ((Graphic) this.m_WonderStateImage1).rectTransform.anchoredPosition with
      {
        x = 139f
      };
      ((Graphic) this.m_WonderStateImage1).rectTransform.anchoredPosition = anchoredPosition;
      anchoredPosition = ((Graphic) this.m_WonderStateImage2).rectTransform.anchoredPosition with
      {
        x = 139f
      };
      ((Graphic) this.m_WonderStateImage2).rectTransform.anchoredPosition = anchoredPosition;
      anchoredPosition = ((Graphic) this.m_WonderStateImage3).rectTransform.anchoredPosition with
      {
        x = 139f
      };
      ((Graphic) this.m_WonderStateImage3).rectTransform.anchoredPosition = anchoredPosition;
      RectTransform component8 = ((Transform) this.m_WondersPanel).GetChild(6).GetChild(0).GetComponent<RectTransform>();
      anchoredPosition = component8.anchoredPosition with
      {
        x = 138f
      };
      component8.anchoredPosition = anchoredPosition;
    }
    this.m_WonderAlliance = ((Transform) this.m_WondersPanel).GetChild(7).GetComponent<UIText>();
    this.m_WonderAlliance.font = GUIManager.Instance.GetTTFFont();
    this.m_WonderOwner = ((Transform) this.m_WondersPanel).GetChild(8).GetComponent<UIText>();
    this.m_WonderOwner.font = GUIManager.Instance.GetTTFFont();
    this.m_WonderKingdom = ((Transform) this.m_WondersPanel).GetChild(9).GetComponent<UIText>();
    this.m_WonderKingdom.font = GUIManager.Instance.GetTTFFont();
    this.m_TeamExitBtn = ((Transform) this.m_TeamPanel).GetChild(3).GetComponent<UIButton>();
    this.m_TeamExitBtn.m_BtnID2 = 203;
    this.m_TeamExitBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_TeamIDBtn = ((Transform) this.m_TeamPanel).GetChild(4).GetComponent<UIButton>();
    this.m_TeamIDBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_TeamIDBtn.m_BtnID2 = 204;
    this.m_TeamIDLine = ((Transform) this.m_TeamPanel).GetChild(4).GetChild(0).GetComponent<Image>();
    this.m_TeamIDText = ((Transform) this.m_TeamPanel).GetChild(4).GetChild(1).GetComponent<UIText>();
    this.m_TeamIDText.font = GUIManager.Instance.GetTTFFont();
    this.m_TeamTargetText = ((Transform) this.m_TeamPanel).GetChild(5).GetComponent<UIText>();
    this.m_TeamTargetText.font = GUIManager.Instance.GetTTFFont();
    this.m_TeamTargetText.text = DataManager.Instance.mStringTable.GetStringByID(4572U);
    this.m_TeamLocBtn = ((Transform) this.m_TeamPanel).GetChild(6).GetComponent<UIButton>();
    this.m_TeamLocBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_TeamLocBtn.m_BtnID2 = 205;
    this.m_TeamLocLine = ((Transform) this.m_TeamPanel).GetChild(6).GetChild(0).GetComponent<Image>();
    this.m_TeamLocText = ((Transform) this.m_TeamPanel).GetChild(6).GetChild(1).GetComponent<UIText>();
    this.m_TeamLocText.font = GUIManager.Instance.GetTTFFont();
    this.m_TeamRetureBtn = ((Transform) this.m_TeamPanel).GetChild(9).GetChild(0).GetComponent<UIButton>();
    UIText component9 = ((Transform) this.m_TeamPanel).GetChild(9).GetChild(0).GetChild(0).GetComponent<UIText>();
    component9.font = GUIManager.Instance.GetTTFFont();
    component9.text = DataManager.Instance.mStringTable.GetStringByID(4558U);
    this.m_TempText[this.m_TempTextIdx++] = component9;
    this.m_TeamRetureBtn.m_BtnID2 = 201;
    this.m_TeamRetureBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_TeamSpeedBtn = ((Transform) this.m_TeamPanel).GetChild(9).GetChild(1).GetComponent<UIButton>();
    this.m_TeamSpeedBtnGameObject = ((Component) this.m_TeamSpeedBtn).gameObject;
    UIText component10 = ((Transform) this.m_TeamPanel).GetChild(9).GetChild(1).GetChild(0).GetComponent<UIText>();
    component10.font = GUIManager.Instance.GetTTFFont();
    component10.text = DataManager.Instance.mStringTable.GetStringByID(3825U);
    this.m_TempText[this.m_TempTextIdx++] = component10;
    this.m_TeamSpeedBtn.m_BtnID2 = 202;
    this.m_TeamSpeedBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_TeamReturnText = ((Transform) this.m_TeamPanel).GetChild(7).GetComponent<UIText>();
    this.m_TeamReturnText.font = GUIManager.Instance.GetTTFFont();
    this.m_TeamReturnText.text = DataManager.Instance.mStringTable.GetStringByID(4574U);
    this.m_TimeText = ((Transform) this.m_TeamPanel).GetChild(8).GetComponent<UIText>();
    this.m_TimeText.font = GUIManager.Instance.GetTTFFont();
    this.m_TeamExpressionBtn = ((Transform) this.m_TeamPanel).GetChild(10).GetComponent<UIButton>();
    this.m_TeamExpressionBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_TeamExpressionBtn.m_BtnID2 = 329;
    this.m_TeamExclamationmark = ((Transform) this.m_TeamPanel).GetChild(10).GetChild(0);
    this.m_SearchPanel = (RectTransform) ((Transform) this.m_RectTransform).GetChild(2);
    UIText component11 = ((Transform) this.m_SearchPanel).GetChild(11).GetComponent<UIText>();
    component11.font = GUIManager.Instance.GetTTFFont();
    component11.text = DataManager.Instance.mStringTable.GetStringByID(4501U);
    this.m_TempText[this.m_TempTextIdx++] = component11;
    UIText component12 = ((Transform) this.m_SearchPanel).GetChild(4).GetChild(0).GetComponent<UIText>();
    component12.font = GUIManager.Instance.GetTTFFont();
    component12.text = DataManager.Instance.mStringTable.GetStringByID(4502U);
    this.m_TempText[this.m_TempTextIdx++] = component12;
    UIText component13 = ((Transform) this.m_SearchPanel).GetChild(15).GetComponent<UIText>();
    component13.font = GUIManager.Instance.GetTTFFont();
    this.m_TempText[this.m_TempTextIdx++] = component13;
    UIText component14 = ((Transform) this.m_SearchPanel).GetChild(6).GetChild(0).GetComponent<UIText>();
    component14.font = GUIManager.Instance.GetTTFFont();
    component14.text = DataManager.Instance.mStringTable.GetStringByID(4507U);
    this.m_TempText[this.m_TempTextIdx++] = component14;
    UIText component15 = ((Transform) this.m_SearchPanel).GetChild(12).GetComponent<UIText>();
    component15.font = GUIManager.Instance.GetTTFFont();
    component15.text = !GUIManager.Instance.IsArabic ? DataManager.Instance.mStringTable.GetStringByID(4504U) : ":K";
    this.m_TempText[this.m_TempTextIdx++] = component15;
    UIText component16 = ((Transform) this.m_SearchPanel).GetChild(13).GetComponent<UIText>();
    component16.font = GUIManager.Instance.GetTTFFont();
    component16.text = !GUIManager.Instance.IsArabic ? DataManager.Instance.mStringTable.GetStringByID(4505U) : ":X";
    this.m_TempText[this.m_TempTextIdx++] = component16;
    UIText component17 = ((Transform) this.m_SearchPanel).GetChild(14).GetComponent<UIText>();
    component17.font = GUIManager.Instance.GetTTFFont();
    component17.text = !GUIManager.Instance.IsArabic ? DataManager.Instance.mStringTable.GetStringByID(4506U) : ":Y";
    this.m_TempText[this.m_TempTextIdx++] = component17;
    UIText component18 = ((Transform) this.m_SearchPanel).GetChild(8).GetChild(0).GetComponent<UIText>();
    component18.font = GUIManager.Instance.GetTTFFont();
    this.m_TempText[this.m_TempTextIdx++] = component18;
    UIButton component19 = ((Transform) this.m_SearchPanel).GetChild(8).GetComponent<UIButton>();
    component19.m_BtnID2 = 324;
    component19.m_Handler = (IUIButtonClickHandler) this;
    UIText component20 = ((Transform) this.m_SearchPanel).GetChild(9).GetChild(0).GetComponent<UIText>();
    component20.font = GUIManager.Instance.GetTTFFont();
    this.m_TempText[this.m_TempTextIdx++] = component20;
    UIButton component21 = ((Transform) this.m_SearchPanel).GetChild(9).GetComponent<UIButton>();
    component21.m_BtnID2 = 325;
    component21.m_Handler = (IUIButtonClickHandler) this;
    UIText component22 = ((Transform) this.m_SearchPanel).GetChild(10).GetChild(0).GetComponent<UIText>();
    component22.font = GUIManager.Instance.GetTTFFont();
    this.m_TempText[this.m_TempTextIdx++] = component22;
    UIButton component23 = ((Transform) this.m_SearchPanel).GetChild(10).GetComponent<UIButton>();
    component23.m_BtnID2 = 326;
    component23.m_Handler = (IUIButtonClickHandler) this;
    UIButton component24 = ((Transform) this.m_SearchPanel).GetChild(6).GetComponent<UIButton>();
    component24.m_BtnID2 = 301;
    component24.m_Handler = (IUIButtonClickHandler) this;
    UIButton component25 = ((Transform) this.m_SearchPanel).GetChild(7).GetComponent<UIButton>();
    component25.m_BtnID2 = 302;
    component25.m_Handler = (IUIButtonClickHandler) this;
    UIButton component26 = ((Component) this.m_SearchPanel).GetComponent<UIButton>();
    component26.m_BtnID2 = 302;
    component26.m_Handler = (IUIButtonClickHandler) this;
    UIText component27 = ((Transform) this.m_SearchPanel).GetChild(16).GetChild(0).GetComponent<UIText>();
    component27.font = GUIManager.Instance.GetTTFFont();
    component27.text = DataManager.Instance.mStringTable.GetStringByID(14581U);
    this.m_TempText[this.m_TempTextIdx++] = component27;
    UIText component28 = ((Transform) this.m_SearchPanel).GetChild(16).GetChild(2).GetChild(0).GetComponent<UIText>();
    component28.font = GUIManager.Instance.GetTTFFont();
    this.m_Str[50].ClearString();
    this.m_Str[50].IntToFormat(71L);
    this.m_Str[50].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(14582U));
    component28.text = this.m_Str[50].ToString();
    this.m_TempText[this.m_TempTextIdx++] = component28;
    this.SetCenterText(((Transform) this.m_SearchPanel).GetChild(16).GetChild(2).GetChild(2).GetComponent<Image>(), component28, 416.42f);
    Image component29 = ((Transform) this.m_SearchPanel).GetChild(16).GetChild(2).GetChild(1).GetComponent<Image>();
    ((Graphic) component29).rectTransform.sizeDelta = new Vector2(component28.preferredWidth, 3f);
    ((Graphic) component29).rectTransform.anchoredPosition = new Vector2(((Graphic) component28).rectTransform.anchoredPosition.x, ((Graphic) component29).rectTransform.anchoredPosition.y);
    RectTransform component30 = ((Transform) this.m_SearchPanel).GetChild(16).GetChild(2).GetChild(3).GetComponent<RectTransform>();
    component30.sizeDelta = ((Graphic) component28).rectTransform.sizeDelta;
    component30.anchoredPosition = ((Graphic) component28).rectTransform.anchoredPosition;
    UIButton component31 = ((Transform) this.m_SearchPanel).GetChild(16).GetChild(2).GetChild(3).GetComponent<UIButton>();
    component31.m_Handler = (IUIButtonClickHandler) this;
    component31.m_BtnID2 = 330;
    UIButtonHint uiButtonHint14 = ((Transform) this.m_SearchPanel).GetChild(16).GetChild(2).GetChild(2).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint14.Parm1 = (ushort) 13;
    uiButtonHint14.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint14.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    this.m_ReinforcePanel = (RectTransform) ((Transform) this.m_RectTransform).GetChild(3);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      this.m_ReinforcePanel.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      this.m_ReinforcePanel.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    UIText component32 = ((Transform) this.m_ReinforcePanel).GetChild(4).GetChild(0).GetComponent<UIText>();
    component32.font = GUIManager.Instance.GetTTFFont();
    this.m_TempText[this.m_TempTextIdx++] = component32;
    UIText component33 = ((Transform) this.m_ReinforcePanel).GetChild(7).GetComponent<UIText>();
    component33.font = GUIManager.Instance.GetTTFFont();
    component33.text = DataManager.Instance.mStringTable.GetStringByID(4591U);
    this.m_TempText[this.m_TempTextIdx++] = component33;
    UIText component34 = ((Transform) this.m_ReinforcePanel).GetChild(6).GetComponent<UIText>();
    component34.font = GUIManager.Instance.GetTTFFont();
    component34.text = DataManager.Instance.mStringTable.GetStringByID(4553U);
    this.m_TempText[this.m_TempTextIdx++] = component34;
    UIText component35 = ((Transform) this.m_ReinforcePanel).GetChild(9).GetChild(0).GetComponent<UIText>();
    component35.font = GUIManager.Instance.GetTTFFont();
    component35.text = DataManager.Instance.mStringTable.GetStringByID(4553U);
    this.m_TempText[this.m_TempTextIdx++] = component35;
    UIText component36 = ((Transform) this.m_ReinforcePanel).GetChild(8).GetChild(3).GetComponent<UIText>();
    component36.font = GUIManager.Instance.GetTTFFont();
    this.m_TempText[this.m_TempTextIdx++] = component36;
    UIButton component37 = ((Transform) this.m_ReinforcePanel).GetChild(9).GetComponent<UIButton>();
    component37.m_Handler = (IUIButtonClickHandler) this;
    component37.m_BtnID2 = 303;
    UIButton component38 = ((Transform) this.m_ReinforcePanel).GetChild(10).GetComponent<UIButton>();
    component38.m_Handler = (IUIButtonClickHandler) this;
    component38.m_BtnID2 = 304;
    HelperUIButton helperUiButton1 = ((Component) this.m_ReinforcePanel).gameObject.AddComponent<HelperUIButton>();
    helperUiButton1.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton1.m_BtnID2 = 304;
    this.m_DetectPanel = (RectTransform) ((Transform) this.m_RectTransform).GetChild(4);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      this.m_DetectPanel.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      this.m_DetectPanel.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    UIText component39 = ((Transform) this.m_DetectPanel).GetChild(6).GetComponent<UIText>();
    component39.font = GUIManager.Instance.GetTTFFont();
    component39.text = DataManager.Instance.mStringTable.GetStringByID(4533U);
    this.m_TempText[this.m_TempTextIdx++] = component39;
    this.m_DetectPanelText = ((Transform) this.m_DetectPanel).GetChild(7).GetComponent<UIText>();
    this.m_DetectPanelText.font = GUIManager.Instance.GetTTFFont();
    this.m_DetectPanelText.text = DataManager.Instance.mStringTable.GetStringByID(4536U);
    UIText component40 = ((Transform) this.m_DetectPanel).GetChild(4).GetChild(0).GetComponent<UIText>();
    component40.font = GUIManager.Instance.GetTTFFont();
    this.m_TempText[this.m_TempTextIdx++] = component40;
    UIText component41 = ((Transform) this.m_DetectPanel).GetChild(8).GetChild(0).GetComponent<UIText>();
    component41.font = GUIManager.Instance.GetTTFFont();
    this.m_TempText[this.m_TempTextIdx++] = component41;
    UIText component42 = ((Transform) this.m_DetectPanel).GetChild(9).GetChild(2).GetComponent<UIText>();
    component42.font = GUIManager.Instance.GetTTFFont();
    component42.text = DataManager.Instance.mStringTable.GetStringByID(4533U);
    this.m_TempText[this.m_TempTextIdx++] = component42;
    UIText component43 = ((Transform) this.m_DetectPanel).GetChild(9).GetChild(1).GetComponent<UIText>();
    component43.font = GUIManager.Instance.GetTTFFont();
    this.m_TempText[this.m_TempTextIdx++] = component43;
    UIButton component44 = ((Transform) this.m_DetectPanel).GetChild(9).GetComponent<UIButton>();
    component44.m_Handler = (IUIButtonClickHandler) this;
    component44.m_BtnID2 = 305;
    UIButton component45 = ((Transform) this.m_DetectPanel).GetChild(10).GetComponent<UIButton>();
    component45.m_Handler = (IUIButtonClickHandler) this;
    component45.m_BtnID2 = 306;
    HelperUIButton helperUiButton2 = ((Component) this.m_DetectPanel).gameObject.AddComponent<HelperUIButton>();
    helperUiButton2.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton2.m_BtnID2 = 306;
    this.m_AttackPanel = (RectTransform) ((Transform) this.m_RectTransform).GetChild(5);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      this.m_AttackPanel.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      this.m_AttackPanel.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    HelperUIButton helperUiButton3 = ((Component) this.m_AttackPanel).gameObject.AddComponent<HelperUIButton>();
    helperUiButton3.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton3.m_BtnID2 = 308;
    this.m_AttackPanelIcon = ((Transform) this.m_AttackPanel).GetChild(5).GetComponent<Image>();
    this.m_AttackPanelTitleText = ((Transform) this.m_AttackPanel).GetChild(6).GetComponent<UIText>();
    this.m_AttackPanelTitleText.font = GUIManager.Instance.GetTTFFont();
    this.m_AttackPanelTitleText.text = DataManager.Instance.mStringTable.GetStringByID(4554U);
    this.m_AttackPanelPosTf = ((Transform) this.m_AttackPanel).GetChild(4);
    this.m_AttackPanelPosText = ((Transform) this.m_AttackPanel).GetChild(4).GetChild(0).GetComponent<UIText>();
    this.m_AttackPanelPosText.font = GUIManager.Instance.GetTTFFont();
    this.m_AttackPanelInfoText = ((Transform) this.m_AttackPanel).GetChild(9).GetComponent<UIText>();
    this.m_AttackPanelInfoText.font = GUIManager.Instance.GetTTFFont();
    this.m_AttackPanelInfoText.text = DataManager.Instance.mStringTable.GetStringByID(4593U);
    this.m_AttackPanelTimeText[0] = ((Transform) this.m_AttackPanel).GetChild(10).GetChild(2).GetComponent<UIText>();
    this.m_AttackPanelTimeText[0].font = GUIManager.Instance.GetTTFFont();
    this.m_AttackPanelTimeBtn[0] = ((Transform) this.m_AttackPanel).GetChild(10).GetComponent<UIButton>();
    this.m_AttackPanelTimeBtn[0].m_BtnID2 = 309;
    this.m_AttackPanelTimeBtn[0].m_Handler = (IUIButtonClickHandler) this;
    this.m_AttackPanelTimeText[0].text = DataManager.Instance.mStringTable.GetStringByID(4594U);
    this.m_AttackPanelTimeSelectImg[0] = ((Transform) this.m_AttackPanel).GetChild(10).GetChild(1).GetComponent<Image>();
    this.m_AttackPanelTimeText[1] = ((Transform) this.m_AttackPanel).GetChild(11).GetChild(2).GetComponent<UIText>();
    this.m_AttackPanelTimeText[1].font = GUIManager.Instance.GetTTFFont();
    this.m_AttackPanelTimeBtn[1] = ((Transform) this.m_AttackPanel).GetChild(11).GetComponent<UIButton>();
    this.m_AttackPanelTimeBtn[1].m_BtnID2 = 310;
    this.m_AttackPanelTimeBtn[1].m_Handler = (IUIButtonClickHandler) this;
    this.m_AttackPanelTimeText[1].text = DataManager.Instance.mStringTable.GetStringByID(4595U);
    this.m_AttackPanelTimeSelectImg[1] = ((Transform) this.m_AttackPanel).GetChild(11).GetChild(1).GetComponent<Image>();
    this.m_AttackPanelTimeText[2] = ((Transform) this.m_AttackPanel).GetChild(12).GetChild(2).GetComponent<UIText>();
    this.m_AttackPanelTimeText[2].font = GUIManager.Instance.GetTTFFont();
    this.m_AttackPanelTimeBtn[2] = ((Transform) this.m_AttackPanel).GetChild(12).GetComponent<UIButton>();
    this.m_AttackPanelTimeBtn[2].m_BtnID2 = 311;
    this.m_AttackPanelTimeBtn[2].m_Handler = (IUIButtonClickHandler) this;
    this.m_AttackPanelTimeText[1].text = DataManager.Instance.mStringTable.GetStringByID(4596U);
    this.m_AttackPanelTimeSelectImg[2] = ((Transform) this.m_AttackPanel).GetChild(12).GetChild(1).GetComponent<Image>();
    this.m_AttackPanelTimeText[3] = ((Transform) this.m_AttackPanel).GetChild(13).GetChild(2).GetComponent<UIText>();
    this.m_AttackPanelTimeText[3].font = GUIManager.Instance.GetTTFFont();
    this.m_AttackPanelTimeBtn[3] = ((Transform) this.m_AttackPanel).GetChild(13).GetComponent<UIButton>();
    this.m_AttackPanelTimeBtn[3].m_BtnID2 = 312;
    this.m_AttackPanelTimeBtn[3].m_Handler = (IUIButtonClickHandler) this;
    this.m_AttackPanelTimeText[1].text = DataManager.Instance.mStringTable.GetStringByID(4597U);
    this.m_AttackPanelTimeSelectImg[3] = ((Transform) this.m_AttackPanel).GetChild(13).GetChild(1).GetComponent<Image>();
    if (GUIManager.Instance.IsArabic)
    {
      for (int index = 0; index < this.m_AttackPanelTimeSelectImg.Length; ++index)
      {
        RectTransform component46 = ((Component) this.m_AttackPanelTimeSelectImg[index]).GetComponent<RectTransform>();
        Vector3 localScale = ((Transform) component46).localScale with
        {
          x = -1f
        };
        ((Transform) component46).localScale = localScale;
        Vector2 anchoredPosition = component46.anchoredPosition with
        {
          x = 339f
        };
        component46.anchoredPosition = anchoredPosition;
      }
    }
    UIText component47 = ((Transform) this.m_AttackPanel).GetChild(7).GetChild(0).GetComponent<UIText>();
    component47.font = GUIManager.Instance.GetTTFFont();
    component47.text = DataManager.Instance.mStringTable.GetStringByID(3U);
    this.m_TempText[this.m_TempTextIdx++] = component47;
    UIButton component48 = ((Transform) this.m_AttackPanel).GetChild(7).GetComponent<UIButton>();
    component48.m_BtnID2 = 307;
    component48.m_Handler = (IUIButtonClickHandler) this;
    UIButton component49 = ((Transform) this.m_AttackPanel).GetChild(8).GetComponent<UIButton>();
    component49.m_BtnID2 = 308;
    component49.m_Handler = (IUIButtonClickHandler) this;
    this.m_BookmarksPanel = (RectTransform) ((Transform) this.m_RectTransform).GetChild(6);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      this.m_BookmarksPanel.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      this.m_BookmarksPanel.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    this.BookmarkSwitch = new UIGroundInfo._BookmarkSwitch(this.m_BookmarksPanel);
    UIText component50 = ((Transform) this.m_BookmarksPanel).GetChild(8).GetComponent<UIText>();
    component50.font = GUIManager.Instance.GetTTFFont();
    component50.text = DataManager.Instance.mStringTable.GetStringByID(4518U);
    this.m_TempText[this.m_TempTextIdx++] = component50;
    UIText component51 = ((Transform) this.m_BookmarksPanel).GetChild(5).GetChild(0).GetComponent<UIText>();
    component51.font = GUIManager.Instance.GetTTFFont();
    this.m_TempText[this.m_TempTextIdx++] = component51;
    UIText component52 = ((Transform) this.m_BookmarksPanel).GetChild(6).GetChild(0).GetComponent<UIText>();
    component52.font = GUIManager.Instance.GetTTFFont();
    component52.text = DataManager.Instance.mStringTable.GetStringByID(4520U);
    this.m_TempText[this.m_TempTextIdx++] = component52;
    UIText component53 = ((Transform) this.m_BookmarksPanel).GetChild(10).GetChild(3).GetComponent<UIText>();
    component53.font = GUIManager.Instance.GetTTFFont();
    component53.text = DataManager.Instance.mStringTable.GetStringByID(4521U);
    this.m_TempText[this.m_TempTextIdx++] = component53;
    UIText component54 = ((Transform) this.m_BookmarksPanel).GetChild(11).GetChild(3).GetComponent<UIText>();
    component54.font = GUIManager.Instance.GetTTFFont();
    component54.text = DataManager.Instance.mStringTable.GetStringByID(4522U);
    this.m_TempText[this.m_TempTextIdx++] = component54;
    UIText component55 = ((Transform) this.m_BookmarksPanel).GetChild(12).GetChild(3).GetComponent<UIText>();
    component55.font = GUIManager.Instance.GetTTFFont();
    component55.text = DataManager.Instance.mStringTable.GetStringByID(4523U);
    this.m_TempText[this.m_TempTextIdx++] = component55;
    UIText component56 = ((Transform) this.m_BookmarksPanel).GetChild(13).GetChild(0).GetComponent<UIText>();
    component56.font = GUIManager.Instance.GetTTFFont();
    component56.text = DataManager.Instance.mStringTable.GetStringByID(3U);
    this.m_TempText[this.m_TempTextIdx++] = component56;
    this.inputField = ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>();
    this.inputField.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
    UIText component57 = ((Transform) this.m_BookmarksPanel).GetChild(9).GetChild(0).GetComponent<UIText>();
    component57.font = GUIManager.Instance.GetTTFFont();
    this.m_TempText[this.m_TempTextIdx++] = component57;
    UIText component58 = ((Transform) this.m_BookmarksPanel).GetChild(9).GetChild(1).GetComponent<UIText>();
    this.m_TempText[this.m_TempTextIdx++] = component58;
    UIButton component59 = ((Transform) this.m_BookmarksPanel).GetChild(9).GetChild(2).GetComponent<UIButton>();
    component59.m_Handler = (IUIButtonClickHandler) this;
    component59.m_BtnID2 = 318;
    component58.font = GUIManager.Instance.GetTTFFont();
    UIButton component60 = ((Transform) this.m_BookmarksPanel).GetChild(13).GetComponent<UIButton>();
    component60.m_BtnID2 = 313;
    component60.m_Handler = (IUIButtonClickHandler) this;
    UIButton component61 = ((Transform) this.m_BookmarksPanel).GetChild(14).GetComponent<UIButton>();
    component61.m_BtnID2 = 314;
    component61.m_Handler = (IUIButtonClickHandler) this;
    UIText component62 = ((Transform) this.m_BookmarksPanel).GetChild(15).GetChild(3).GetComponent<UIText>();
    component62.font = GUIManager.Instance.GetTTFFont();
    component62.text = DataManager.Instance.mStringTable.GetStringByID(4624U);
    this.m_TempText[this.m_TempTextIdx++] = component62;
    HelperUIButton helperUiButton4 = ((Component) this.m_BookmarksPanel).gameObject.AddComponent<HelperUIButton>();
    helperUiButton4.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton4.m_BtnID2 = 314;
    UIButton component63 = ((Transform) this.m_BookmarksPanel).GetChild(10).GetComponent<UIButton>();
    component63.m_BtnID2 = 315;
    component63.m_Handler = (IUIButtonClickHandler) this;
    UIButton component64 = ((Transform) this.m_BookmarksPanel).GetChild(11).GetComponent<UIButton>();
    component64.m_BtnID2 = 316;
    component64.m_Handler = (IUIButtonClickHandler) this;
    UIButton component65 = ((Transform) this.m_BookmarksPanel).GetChild(12).GetComponent<UIButton>();
    component65.m_BtnID2 = 317;
    component65.m_Handler = (IUIButtonClickHandler) this;
    UIButton component66 = ((Transform) this.m_BookmarksPanel).GetChild(15).GetComponent<UIButton>();
    component66.m_BtnID2 = 332;
    component66.m_Handler = (IUIButtonClickHandler) this;
    if (GUIManager.Instance.IsArabic)
    {
      for (int index = 0; index < 3; ++index)
      {
        RectTransform component67 = ((Transform) this.m_BookmarksPanel).GetChild(10 + index).GetChild(1).GetComponent<RectTransform>();
        Vector3 localScale = ((Transform) component67).localScale with
        {
          x = -1f
        };
        ((Transform) component67).localScale = localScale;
        Vector2 anchoredPosition = component67.anchoredPosition with
        {
          x = 339f
        };
        component67.anchoredPosition = anchoredPosition;
      }
      RectTransform component68 = ((Transform) this.m_BookmarksPanel).GetChild(15).GetChild(1).GetComponent<RectTransform>();
      Vector3 localScale1 = ((Transform) component68).localScale with
      {
        x = -1f
      };
      ((Transform) component68).localScale = localScale1;
      Vector2 anchoredPosition1 = component68.anchoredPosition with
      {
        x = 339f
      };
      component68.anchoredPosition = anchoredPosition1;
    }
    this.m_PvePanel = (RectTransform) ((Transform) this.m_RectTransform).GetChild(7);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      this.m_PvePanel.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      this.m_PvePanel.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    Transform child4 = ((Transform) this.m_PvePanel).GetChild(10);
    UIButton component69 = child4.GetComponent<UIButton>();
    component69.m_Handler = (IUIButtonClickHandler) this;
    component69.m_BtnID2 = 319;
    UIText component70 = child4.GetChild(1).GetComponent<UIText>();
    component70.font = GUIManager.Instance.GetTTFFont();
    component70.text = DataManager.Instance.mStringTable.GetStringByID(4533U);
    this.m_TempText[this.m_TempTextIdx++] = component70;
    this.m_ButtonRect5 = (RectTransform) ((Transform) this.m_ButtonPanel).GetChild(4);
    Transform child5 = ((Transform) this.m_PvePanel).GetChild(11);
    UIButton component71 = child5.GetComponent<UIButton>();
    component71.m_Handler = (IUIButtonClickHandler) this;
    component71.m_BtnID2 = 320;
    UIText component72 = child5.GetChild(1).GetComponent<UIText>();
    component72.font = GUIManager.Instance.GetTTFFont();
    component72.text = DataManager.Instance.mStringTable.GetStringByID(4534U);
    this.m_TempText[this.m_TempTextIdx++] = component72;
    this.m_PveHeroBtn = ((Transform) this.m_PvePanel).GetChild(4).GetComponent<UIHIBtn>();
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_PveHeroBtn).transform, eHeroOrItem.Hero, (ushort) 11, (byte) 1, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.m_PveTitle = ((Transform) this.m_PvePanel).GetChild(5).GetComponent<UIText>();
    this.m_PveTitle.font = GUIManager.Instance.GetTTFFont();
    this.m_PveHeroName = ((Transform) this.m_PvePanel).GetChild(6).GetComponent<UIText>();
    this.m_PveHeroName.font = GUIManager.Instance.GetTTFFont();
    this.m_PvePowerIcon = ((Transform) this.m_PvePanel).GetChild(7).GetComponent<Image>();
    this.m_PvePowerText = ((Transform) this.m_PvePanel).GetChild(8).GetComponent<UIText>();
    this.m_PvePowerText.font = GUIManager.Instance.GetTTFFont();
    UIText component73 = ((Transform) this.m_PvePanel).GetChild(9).GetComponent<UIText>();
    component73.font = GUIManager.Instance.GetTTFFont();
    component73.text = DataManager.Instance.mStringTable.GetStringByID(791U);
    this.m_TempText[this.m_TempTextIdx++] = component73;
    UIButton component74 = ((Transform) this.m_PvePanel).GetChild(12).GetComponent<UIButton>();
    component74.m_Handler = (IUIButtonClickHandler) this;
    component74.m_BtnID2 = 321;
    HelperUIButton helperUiButton5 = ((Component) this.m_PvePanel).gameObject.AddComponent<HelperUIButton>();
    helperUiButton5.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton5.m_BtnID2 = 321;
    this.m_RewardPanel = (RectTransform) ((Transform) this.m_RectTransform).GetChild(8);
    this.m_RewardBtn = ((Transform) this.m_RewardPanel).GetChild(7).GetComponent<UIButton>();
    this.m_RewardBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_RewardBtn.m_BtnID2 = 322;
    this.m_RewardText = ((Transform) this.m_RewardPanel).GetChild(6).GetComponent<UIText>();
    this.m_RewardText.font = GUIManager.Instance.GetTTFFont();
    UIText component75 = ((Transform) this.m_RewardPanel).GetChild(4).GetComponent<UIText>();
    component75.font = GUIManager.Instance.GetTTFFont();
    component75.text = DataManager.Instance.mStringTable.GetStringByID(861U);
    this.m_TempText[this.m_TempTextIdx++] = component75;
    UIText component76 = ((Transform) this.m_RewardPanel).GetChild(5).GetComponent<UIText>();
    component76.font = GUIManager.Instance.GetTTFFont();
    component76.text = DataManager.Instance.mStringTable.GetStringByID(862U);
    this.m_TempText[this.m_TempTextIdx++] = component76;
    UIText component77 = ((Transform) this.m_RewardPanel).GetChild(7).GetChild(0).GetComponent<UIText>();
    component77.font = GUIManager.Instance.GetTTFFont();
    component77.text = DataManager.Instance.mStringTable.GetStringByID(863U);
    this.m_TempText[this.m_TempTextIdx++] = component77;
    this.m_TitlePanel = (RectTransform) ((Transform) this.m_RectTransform).GetChild(10);
    UIButton component78 = ((Transform) this.m_TitlePanel).GetChild(0).GetComponent<UIButton>();
    component78.m_Handler = (IUIButtonClickHandler) this;
    component78.m_BtnID2 = 327;
    UIText component79 = ((Transform) this.m_TitlePanel).GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
    component79.font = GUIManager.Instance.GetTTFFont();
    component79.text = DataManager.Instance.mStringTable.GetStringByID(9348U);
    this.m_TempText[this.m_TempTextIdx++] = component79;
    this.m_NpcCastleIcon = ((Transform) this.m_NpcCastlePanel).GetChild(0).gameObject;
    this.m_NpcCastleIconBone = ((Transform) this.m_NpcCastlePanel).GetChild(0).GetChild(0);
    this.m_NpcCastleFrame = ((Transform) this.m_NpcCastlePanel).GetChild(0).GetChild(1).GetComponent<Image>();
    this.m_NpcCastleFrame.sprite = GUIManager.Instance.LoadFrameSprite(EFrameSprite.Hero, (byte) 11);
    ((MaskableGraphic) this.m_NpcCastleFrame).material = GUIManager.Instance.GetFrameMaterial();
    this.m_NpcCastleIDText = ((Transform) this.m_NpcCastlePanel).GetChild(1).GetComponent<UIText>();
    this.m_NpcCastleIDText.font = GUIManager.Instance.GetTTFFont();
    this.m_NpcCastleStrengthText = ((Transform) this.m_NpcCastlePanel).GetChild(2).GetComponent<UIText>();
    this.m_NpcCastleStrengthText.font = GUIManager.Instance.GetTTFFont();
    this.m_NpcCastleTimeText = ((Transform) this.m_NpcCastlePanel).GetChild(3).GetComponent<UIText>();
    this.m_NpcCastleTimeText.font = GUIManager.Instance.GetTTFFont();
    this.m_NpcCastleInfoText = ((Transform) this.m_NpcCastlePanel).GetChild(4).GetComponent<UIText>();
    this.m_NpcCastleInfoText.font = GUIManager.Instance.GetTTFFont();
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component80 = ((Transform) this.m_NpcCastlePanel).GetChild(2).GetChild(0).GetComponent<RectTransform>();
      Vector2 anchoredPosition = component80.anchoredPosition with
      {
        x = 130f
      };
      component80.anchoredPosition = anchoredPosition;
      RectTransform component81 = ((Transform) this.m_NpcCastlePanel).GetChild(3).GetChild(0).GetComponent<RectTransform>();
      anchoredPosition.x = 130f;
      component81.anchoredPosition = anchoredPosition;
      Vector3 localScale = ((Transform) ((Transform) this.m_NpcCastlePanel).GetChild(5).GetComponent<RectTransform>()).localScale;
      localScale.x *= -1f;
      ((Transform) ((Transform) this.m_NpcCastlePanel).GetChild(5).GetComponent<RectTransform>()).localScale = localScale;
    }
    this.m_NpcCastleInfoBtn = ((Transform) this.m_NpcCastlePanel).GetChild(5).GetComponent<UIButton>();
    this.m_NpcCastleInfoBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_NpcCastleInfoBtn.m_BtnID2 = 328;
    UIButtonHint uiButtonHint15 = ((Component) this.m_NpcCastleStrengthText).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint15.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint15.Parm1 = (ushort) 9;
    uiButtonHint15.m_eHint = EUIButtonHint.DownUpHandler;
    UIButtonHint uiButtonHint16 = ((Component) this.m_NpcCastleStrengthText).transform.GetChild(0).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint16.Parm1 = (ushort) 9;
    uiButtonHint16.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint16.m_eHint = EUIButtonHint.DownUpHandler;
    UIButtonHint uiButtonHint17 = ((Component) this.m_NpcCastleTimeText).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint17.Parm1 = (ushort) 10;
    uiButtonHint17.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint17.m_eHint = EUIButtonHint.DownUpHandler;
    UIButtonHint uiButtonHint18 = ((Component) this.m_NpcCastleTimeText).transform.GetChild(0).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint18.Parm1 = (ushort) 10;
    uiButtonHint18.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint18.m_DownUpHandler = (IUIButtonDownUpHandler) this;
  }

  public void HideNormalPanel()
  {
    this.m_PanelGameObject.SetActive(false);
    this.m_TeamPanelGameObject.SetActive(false);
    ((Component) this.m_GroundPanel).gameObject.SetActive(false);
    ((Component) this.m_ResourcePanel).gameObject.SetActive(false);
    ((Component) this.m_CampPanel).gameObject.SetActive(false);
    ((Component) this.m_WondersPanel).gameObject.SetActive(false);
    ((Component) this.m_RewardPanel).gameObject.SetActive(false);
    ((Component) this.m_NpcCastlePanel).gameObject.SetActive(false);
  }

  public string GetLocation(int MapPointID, bool bHaveArbText = false, bool bWonder = false)
  {
    Vector2 vector2 = !bWonder ? GameConstants.getTileMapPosbySpriteID(MapPointID) : DataManager.MapDataController.GetYolkPos(DataManager.MapDataController.LayoutMapInfo[MapPointID].tableID, DataManager.MapDataController.FocusKingdomID);
    this.sb.Length = 0;
    if (GUIManager.Instance.IsArabic)
    {
      if (bHaveArbText)
        this.sb.AppendFormat("{1}{0} {3}{2} {5}{4}", (object) DataManager.Instance.mStringTable.GetStringByID(4504U), (object) DataManager.MapDataController.FocusKingdomID, (object) DataManager.Instance.mStringTable.GetStringByID(4505U), (object) (int) vector2.x, (object) DataManager.Instance.mStringTable.GetStringByID(4506U), (object) (int) vector2.y);
      else
        this.sb.AppendFormat("{5}{4} {3}{2} {1}{0}", (object) DataManager.Instance.mStringTable.GetStringByID(4504U), (object) DataManager.MapDataController.FocusKingdomID, (object) DataManager.Instance.mStringTable.GetStringByID(4505U), (object) (int) vector2.x, (object) DataManager.Instance.mStringTable.GetStringByID(4506U), (object) (int) vector2.y);
    }
    else
      this.sb.AppendFormat("{0}{1} {2}{3} {4}{5}", (object) DataManager.Instance.mStringTable.GetStringByID(4504U), (object) DataManager.MapDataController.FocusKingdomID, (object) DataManager.Instance.mStringTable.GetStringByID(4505U), (object) (int) vector2.x, (object) DataManager.Instance.mStringTable.GetStringByID(4506U), (object) (int) vector2.y);
    return this.sb.ToString();
  }

  public string GetYolkLocation(ushort YolkID, ushort KingdomID, bool bHaveArbText = false)
  {
    Vector2 yolkPos = DataManager.MapDataController.GetYolkPos(YolkID, KingdomID);
    this.sb.Length = 0;
    if (GUIManager.Instance.IsArabic)
    {
      if (bHaveArbText)
        this.sb.AppendFormat("{1}{0} {3}{2} {5}{4}", (object) DataManager.Instance.mStringTable.GetStringByID(4504U), (object) DataManager.MapDataController.FocusKingdomID, (object) DataManager.Instance.mStringTable.GetStringByID(4505U), (object) (int) yolkPos.x, (object) DataManager.Instance.mStringTable.GetStringByID(4506U), (object) (int) yolkPos.y);
      else
        this.sb.AppendFormat("{5}{4} {3}{2} {1}{0}", (object) DataManager.Instance.mStringTable.GetStringByID(4504U), (object) DataManager.MapDataController.FocusKingdomID, (object) DataManager.Instance.mStringTable.GetStringByID(4505U), (object) (int) yolkPos.x, (object) DataManager.Instance.mStringTable.GetStringByID(4506U), (object) (int) yolkPos.y);
    }
    else
      this.sb.AppendFormat("{0}{1} {2}{3} {4}{5}", (object) DataManager.Instance.mStringTable.GetStringByID(4504U), (object) DataManager.MapDataController.FocusKingdomID, (object) DataManager.Instance.mStringTable.GetStringByID(4505U), (object) (int) yolkPos.x, (object) DataManager.Instance.mStringTable.GetStringByID(4506U), (object) (int) yolkPos.y);
    return this.sb.ToString();
  }

  public void OpenSearchPanel(bool IsOpen, bool IsWorldMap = false)
  {
    if (IsOpen)
    {
      this.HideNormalPanel();
      ((Transform) this.m_SearchPanel).GetChild(15).gameObject.SetActive(false);
      if (IsWorldMap)
      {
        if (this.m_SearchLocationK == (ushort) 0)
        {
          this.m_SearchLocationK = DataManager.MapDataController.OtherKingdomData.kingdomID;
          this.m_Str[20].ClearString();
          this.m_Str[20].IntToFormat((long) this.m_SearchLocationK);
          this.m_Str[20].AppendFormat("{0}");
          ((Transform) this.m_SearchPanel).GetChild(8).GetChild(0).GetComponent<UIText>().text = this.m_Str[20].ToString();
        }
        RectTransform component1 = ((Transform) this.m_SearchPanel).GetChild(0).GetComponent<RectTransform>();
        Vector2 sizeDelta = component1.sizeDelta with
        {
          y = 390f
        };
        component1.sizeDelta = sizeDelta;
        Vector2 anchoredPosition1 = component1.anchoredPosition with
        {
          y = 16f
        };
        component1.anchoredPosition = anchoredPosition1;
        RectTransform component2 = ((Transform) this.m_SearchPanel).GetChild(6).GetComponent<RectTransform>();
        Vector2 anchoredPosition2 = component2.anchoredPosition with
        {
          y = 12f
        };
        component2.anchoredPosition = anchoredPosition2;
        ((Transform) this.m_SearchPanel).GetChild(16).gameObject.SetActive(true);
        ((Transform) this.m_SearchPanel).GetChild(9).gameObject.SetActive(false);
        ((Transform) this.m_SearchPanel).GetChild(10).gameObject.SetActive(false);
        ((Transform) this.m_SearchPanel).GetChild(13).gameObject.SetActive(false);
        ((Transform) this.m_SearchPanel).GetChild(14).gameObject.SetActive(false);
        ((RectTransform) ((Transform) this.m_SearchPanel).GetChild(8)).anchoredPosition = new Vector2(12f, 84.5f);
        ((RectTransform) ((Transform) this.m_SearchPanel).GetChild(12)).anchoredPosition = new Vector2(-44.5f, 84.5f);
        ((Transform) this.m_SearchPanel).GetChild(4).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(792U);
      }
      else
      {
        int focusKingdomId = (int) DataManager.MapDataController.FocusKingdomID;
        ((Transform) this.m_SearchPanel).GetChild(9).gameObject.SetActive(true);
        ((Transform) this.m_SearchPanel).GetChild(10).gameObject.SetActive(true);
        ((Transform) this.m_SearchPanel).GetChild(13).gameObject.SetActive(true);
        ((Transform) this.m_SearchPanel).GetChild(14).gameObject.SetActive(true);
        ((RectTransform) ((Transform) this.m_SearchPanel).GetChild(8)).anchoredPosition = new Vector2(-105f, 84.5f);
        ((RectTransform) ((Transform) this.m_SearchPanel).GetChild(12)).anchoredPosition = new Vector2(-162.5f, 84.5f);
        ((Transform) this.m_SearchPanel).GetChild(4).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(4502U);
        this.m_Str[20].ClearString();
        this.m_Str[20].IntToFormat((long) focusKingdomId);
        this.m_Str[20].AppendFormat("{0}");
        ((Transform) this.m_SearchPanel).GetChild(8).GetChild(0).GetComponent<UIText>().text = this.m_Str[20].ToString();
        RectTransform component3 = ((Transform) this.m_SearchPanel).GetChild(0).GetComponent<RectTransform>();
        Vector2 sizeDelta = component3.sizeDelta with
        {
          y = 297f
        };
        component3.sizeDelta = sizeDelta;
        Vector2 anchoredPosition3 = component3.anchoredPosition with
        {
          y = 62.5f
        };
        component3.anchoredPosition = anchoredPosition3;
        RectTransform component4 = ((Transform) this.m_SearchPanel).GetChild(6).GetComponent<RectTransform>();
        Vector2 anchoredPosition4 = component4.anchoredPosition with
        {
          y = -15f
        };
        component4.anchoredPosition = anchoredPosition4;
        ((Transform) this.m_SearchPanel).GetChild(16).gameObject.SetActive(false);
        if (this.m_SearchLocationX == (ushort) 0)
        {
          this.m_SearchLocationX = this.m_Door.m_CapitalLocationX;
          this.m_SearchLocationY = this.m_Door.m_CapitalLocationY;
          this.m_Str[21].ClearString();
          this.m_Str[21].IntToFormat((long) this.m_SearchLocationX);
          this.m_Str[21].AppendFormat("{0}");
          ((Transform) this.m_SearchPanel).GetChild(9).GetChild(0).GetComponent<UIText>().text = string.Empty;
          ((Transform) this.m_SearchPanel).GetChild(9).GetChild(0).GetComponent<UIText>().text = this.m_Str[21].ToString();
          this.m_Str[22].ClearString();
          this.m_Str[22].IntToFormat((long) this.m_SearchLocationY);
          this.m_Str[22].AppendFormat("{0}");
          ((Transform) this.m_SearchPanel).GetChild(10).GetChild(0).GetComponent<UIText>().text = string.Empty;
          ((Transform) this.m_SearchPanel).GetChild(10).GetChild(0).GetComponent<UIText>().text = this.m_Str[22].ToString();
        }
      }
    }
    ((Component) this.m_SearchPanel).gameObject.SetActive(IsOpen);
    this.bGroundInfoOpen = IsOpen;
  }

  public void OpenReinforcePanel(bool IsOpen, bool bShowBackground = false, bool bShowLoc = true)
  {
    if (IsOpen)
    {
      ((Transform) this.m_ReinforcePanel).GetChild(4).GetChild(0).GetComponent<UIText>().text = !bShowLoc ? string.Empty : this.GetLocation(this.m_MapPointID);
      this.SetReinforceValue(DataManager.Instance.m_CurrTroopAmount, DataManager.Instance.m_InForceCapacity);
      this.HideNormalPanel();
      if (bShowBackground)
        ((Graphic) ((Component) this.m_ReinforcePanel).GetComponent<Image>()).color = new Color(1f, 1f, 1f, 0.7f);
      else
        ((Graphic) ((Component) this.m_ReinforcePanel).GetComponent<Image>()).color = new Color(1f, 1f, 1f, 0.7f);
    }
    this.bOpenUIExpedition_FromList = !bShowLoc;
    ((Component) this.m_ReinforcePanel).gameObject.SetActive(IsOpen);
    this.bGroundInfoOpen = IsOpen;
  }

  public void SetReinforceValue(uint value, uint max)
  {
    this.sb.Length = 0;
    float num = 0.0f;
    if (max > 0U)
      num = (float) value / (float) max;
    this.m_Str[27].ClearString();
    RectTransform component = ((Transform) this.m_ReinforcePanel).GetChild(8).GetChild(0).GetComponent<RectTransform>();
    component.sizeDelta = new Vector2(253f * num, component.sizeDelta.y);
    this.m_Str[27].IntToFormat((long) value, bNumber: true);
    this.m_Str[27].IntToFormat((long) max, bNumber: true);
    if (GUIManager.Instance.IsArabic)
      this.m_Str[27].AppendFormat("{1} / {0}");
    else
      this.m_Str[27].AppendFormat("{0} / {1}");
    ((Transform) this.m_ReinforcePanel).GetChild(8).GetChild(3).GetComponent<UIText>().text = this.m_Str[27].ToString();
  }

  public void OpenDetectPanel(bool IsOpen, byte lv = 0, bool bWonder = false)
  {
    if (IsOpen)
    {
      if (this.ScoutCheckBox(eScoutCheckBox.PreScout))
      {
        ((Transform) this.m_DetectPanel).GetChild(4).GetChild(0).GetComponent<UIText>().text = this.GetLocation(this.m_MapPointID, bWonder: bWonder);
        this.SetDetectPanel(lv, bWonder);
        this.HideNormalPanel();
        ((Component) this.m_DetectPanel).gameObject.SetActive(IsOpen);
      }
      else
        this.Close();
    }
    else
      ((Component) this.m_DetectPanel).gameObject.SetActive(false);
    this.bGroundInfoOpen = IsOpen;
  }

  public void SetDetectPanel(byte lv = 0, bool bWonder = false)
  {
    if (this.m_MapPointID >= DataManager.MapDataController.LayoutMapInfo.Length)
      return;
    this.m_DetectPanelText.text = !bWonder ? DataManager.Instance.mStringTable.GetStringByID(4536U) : DataManager.Instance.mStringTable.GetStringByID(7273U);
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
    int num = (int) Mathf.Ceil(Mathf.Ceil(Vector2.Distance(new Vector2((float) this.m_Door.m_CapitalLocationX, (float) this.m_Door.m_CapitalLocationY), !bWonder ? GameConstants.getTileMapPosbySpriteID(this.m_MapPointID) : DataManager.MapDataController.GetYolkPos(DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID].tableID, DataManager.MapDataController.FocusKingdomID))) * 0.6f);
    this.sb.Length = 0;
    int x1 = num / 60;
    int x2 = num % 60;
    this.m_Str[18].ClearString();
    UIText component1 = ((Transform) this.m_DetectPanel).GetChild(8).GetChild(0).GetComponent<UIText>();
    this.m_Str[18].ClearString();
    this.m_Str[18].IntToFormat((long) x1, 2);
    this.m_Str[18].IntToFormat((long) x2, 2);
    this.m_Str[18].AppendFormat("{0}:{1}");
    component1.text = this.m_Str[18].ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    this.m_Str[19].ClearString();
    this.m_ScoutTagLv = (byte) 0;
    if ((int) mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
      this.m_ScoutTagLv = DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].level;
    if (bWonder)
      this.m_Str[19].IntToFormat(10000L);
    else if (lv == (byte) 0)
    {
      this.m_Str[19].IntToFormat((long) this.GetScoutMoney(this.m_ScoutTagLv), bNumber: true);
    }
    else
    {
      this.m_ScoutTagLv = lv;
      this.m_Str[19].IntToFormat((long) this.GetScoutMoney(lv), bNumber: true);
    }
    this.m_Str[19].AppendFormat("{0}");
    UIText component2 = ((Transform) this.m_DetectPanel).GetChild(9).GetChild(1).GetComponent<UIText>();
    component2.text = this.m_Str[19].ToString();
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
    ((Transform) this.m_ReinforcePanel).GetChild(4).GetChild(0).GetComponent<UIText>().text = this.GetLocation(this.m_MapPointID);
  }

  public void OpenAttackPanel(bool IsOpen, bool bHideArmy = false)
  {
    if (IsOpen)
    {
      ((Transform) this.m_AttackPanel).GetChild(4).GetChild(0).GetComponent<UIText>().text = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID].pointKind != (byte) 11 || DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID].tableID >= (ushort) 40 ? this.GetLocation(this.m_MapPointID) : this.GetLocation(this.m_MapPointID, bWonder: true);
      this.SetAttackPanel(bHideArmy, byte.MaxValue);
      this.HideNormalPanel();
    }
    ((Component) this.m_AttackPanel).gameObject.SetActive(IsOpen);
    this.bGroundInfoOpen = IsOpen;
  }

  public void SetAttackPanel(bool bHideArmy = false, byte index = 255)
  {
    UISpritesArray component = ((Component) this.m_AttackPanel).GetComponent<UISpritesArray>();
    byte num;
    if (bHideArmy)
    {
      this.bHideSelectMod = true;
      byte[] numArray = new byte[4]
      {
        (byte) 1,
        (byte) 4,
        (byte) 8,
        (byte) 12
      };
      this.m_AttackPanelIcon.sprite = component.GetSprite(3);
      this.m_AttackPanelIcon.SetNativeSize();
      ((Transform) ((Graphic) this.m_AttackPanelIcon).rectTransform).localScale = new Vector3(0.8f, 0.8f, 0.8f);
      this.m_AttackPanelPosTf.gameObject.SetActive(false);
      this.m_AttackPanelTitleText.text = DataManager.Instance.mStringTable.GetStringByID(9046U);
      this.m_AttackPanelInfoText.text = DataManager.Instance.mStringTable.GetStringByID(8586U);
      ((Graphic) this.m_AttackPanelInfoText).rectTransform.anchoredPosition = new Vector2(0.0f, 100f);
      for (int index1 = 0; index1 < this.m_AttackPanelTimeText.Length; ++index1)
      {
        int index2 = 42 + index1;
        if (index2 < this.m_Str.Length && index1 < numArray.Length)
        {
          this.m_Str[index2].ClearString();
          this.m_Str[index2].IntToFormat((long) numArray[index1]);
          this.m_Str[index2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8588U));
          this.m_AttackPanelTimeText[index1].text = this.m_Str[index2].ToString();
          this.m_AttackPanelTimeText[index1].SetAllDirty();
          this.m_AttackPanelTimeText[index1].cachedTextGenerator.Invalidate();
        }
      }
      if (index != byte.MaxValue)
        this.m_HideSelect = index;
      num = this.m_HideSelect;
    }
    else
    {
      this.bHideSelectMod = false;
      this.m_AttackPanelIcon.sprite = component.GetSprite(2);
      this.m_AttackPanelIcon.SetNativeSize();
      ((Transform) ((Graphic) this.m_AttackPanelIcon).rectTransform).localScale = new Vector3(1f, 1f, 1f);
      this.m_AttackPanelPosTf.gameObject.SetActive(true);
      ((Graphic) this.m_AttackPanelInfoText).rectTransform.anchoredPosition = new Vector2(0.0f, 82.7f);
      this.m_AttackPanelTitleText.text = DataManager.Instance.mStringTable.GetStringByID(4554U);
      this.m_AttackPanelInfoText.text = DataManager.Instance.mStringTable.GetStringByID(4593U);
      for (int index3 = 0; index3 < this.m_AttackPanelTimeText.Length; ++index3)
        this.m_AttackPanelTimeText[index3].text = DataManager.Instance.mStringTable.GetStringByID((uint) (4594 + index3));
      GameConstants.MapIDToPointCode(this.m_MapPointID, out DataManager.Instance.RallyDesPoint.zoneID, out DataManager.Instance.RallyDesPoint.pointID);
      if (index != byte.MaxValue)
        this.m_AttackSelect = index;
      num = this.m_AttackSelect;
    }
    for (int index4 = 0; index4 < 4; ++index4)
    {
      if ((int) num == index4)
      {
        this.m_AttackPanelTimeBtn[index4].image.sprite = component.GetSprite(1);
        ((Component) this.m_AttackPanelTimeSelectImg[index4]).gameObject.SetActive(true);
      }
      else
      {
        this.m_AttackPanelTimeBtn[index4].image.sprite = component.GetSprite(0);
        ((Component) this.m_AttackPanelTimeSelectImg[index4]).gameObject.SetActive(false);
      }
    }
  }

  public void OpenMonsterBookmarksPanel(bool IsOpen, int mapPoint)
  {
    this.m_ModifyBookMarkID = (ushort) 0;
    this.m_MonsterMapPoint = mapPoint;
    MapPoint mapPoint1 = DataManager.MapDataController.LayoutMapInfo[this.m_MonsterMapPoint];
    if (mapPoint1.pointKind != (byte) 10)
      return;
    NPCPoint npcPoint = DataManager.MapDataController.NPCPointTable[(int) mapPoint1.tableID];
    if (IsOpen)
    {
      UIText component = ((Transform) this.m_BookmarksPanel).GetChild(8).GetComponent<UIText>();
      component.font = GUIManager.Instance.GetTTFFont();
      component.text = DataManager.Instance.mStringTable.GetStringByID(4518U);
      ((Transform) this.m_BookmarksPanel).GetChild(5).GetChild(0).GetComponent<UIText>().text = this.GetLocation(this.m_MonsterMapPoint);
      if (npcPoint.NPCAllianceTag.Length > 0 && npcPoint.NPCAllianceTag[0] != '0')
      {
        this.BookMarkNameStr.ClearString();
        this.BookMarkNameStr.StringToFormat(npcPoint.NPCAllianceTag);
        this.BookMarkNameStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) DataManager.MapDataController.MapMonsterTable.GetRecordByKey(npcPoint.NPCNum).NameID));
        if (GUIManager.Instance.IsArabic)
          this.BookMarkNameStr.AppendFormat("{1}[{0}]");
        else
          this.BookMarkNameStr.AppendFormat("[{0}]{1}");
        ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = this.BookMarkNameStr.ToString();
        UIText textComponent = ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().textComponent;
        textComponent.SetAllDirty();
        textComponent.cachedTextGeneratorForLayout.Invalidate();
      }
      else
        ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = DataManager.Instance.mStringTable.GetStringByID((uint) DataManager.MapDataController.MapMonsterTable.GetRecordByKey(npcPoint.NPCNum).NameID);
      if ((DataManager.Instance.RoleAlliance.Id == 0U || DataManager.Instance.RoleAlliance.Rank < AllianceRank.RANK4) && this.m_BookmarkSelect == (byte) 3)
        this.m_BookmarkSelect = (byte) 0;
      this.HideNormalPanel();
      this.SetBookmarksPanel();
    }
    this.BookmarkSwitch.Switch(UIGroundInfo._BookmarkSwitch.eType.AddBookmark);
    ((Component) this.m_BookmarksPanel).gameObject.SetActive(true);
    this.bGroundInfoOpen = IsOpen;
  }

  public void OpenBookmarksPanel(bool IsOpen)
  {
    this.m_ModifyBookMarkID = (ushort) 0;
    if (IsOpen)
    {
      int num = 0;
      UIText component1 = ((Transform) this.m_BookmarksPanel).GetChild(8).GetComponent<UIText>();
      component1.font = GUIManager.Instance.GetTTFFont();
      component1.text = DataManager.Instance.mStringTable.GetStringByID(4518U);
      this.UpdateBookmarkTitlePos();
      UIText component2 = ((Transform) this.m_BookmarksPanel).GetChild(5).GetChild(0).GetComponent<UIText>();
      MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
      bool bWonder = mapPoint.pointKind == (byte) 11;
      component2.text = this.GetLocation(this.m_MapPointID, bWonder: bWonder);
      int length = DataManager.MapDataController.ResourcesPointTable.Length;
      if ((int) mapPoint.tableID >= length)
        return;
      ushort level = (ushort) DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].level;
      switch (DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) this.m_MapPointID))
      {
        case POINT_KIND.PK_NONE:
          if (this.m_MapPointID >= 0 && this.m_MapPointID < this.m_Door.TileMapController.TileMapInfo.Length)
            num = (int) this.m_Door.TileMapController.TileMapInfo[this.m_MapPointID];
          ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = this.GetPKNoneGroundTitle(this.m_MapPointID);
          break;
        case POINT_KIND.PK_FOOD:
          this.sb.Length = 0;
          this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4566U), (object) level);
          this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4525U);
          ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = this.sb.ToString();
          break;
        case POINT_KIND.PK_STONE:
          this.sb.Length = 0;
          this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4568U), (object) level);
          this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4526U);
          ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = this.sb.ToString();
          break;
        case POINT_KIND.PK_IRON:
          this.sb.Length = 0;
          this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4567U), (object) level);
          this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4527U);
          ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = this.sb.ToString();
          break;
        case POINT_KIND.PK_WOOD:
          this.sb.Length = 0;
          this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4570U), (object) level);
          this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4524U);
          ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = this.sb.ToString();
          break;
        case POINT_KIND.PK_GOLD:
          this.sb.Length = 0;
          this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4569U), (object) level);
          this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4528U);
          ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = this.sb.ToString();
          break;
        case POINT_KIND.PK_CRYSTAL:
          this.sb.Length = 0;
          this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4571U), (object) level);
          this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4529U);
          ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = this.sb.ToString();
          break;
        case POINT_KIND.PK_CITY:
          if (this.IsNpcCastleType(POINT_KIND.PK_CITY, mapPoint.tableID))
          {
            this.m_Str[14].ClearString();
            StringManager.Instance.IntToFormat((long) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].level);
            this.m_Str[14].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021U));
            ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = "{0}";
            ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = this.m_Str[14].ToString();
            break;
          }
          if ((int) mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
          {
            this.m_Str[14].ClearString();
            if (DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag != null && DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag.Length > 0)
            {
              StringManager.Instance.StringToFormat(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag);
              StringManager.Instance.StringToFormat(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName);
              this.m_Str[14].AppendFormat("[{0}]{1}");
            }
            else
            {
              StringManager.Instance.StringToFormat(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName);
              this.m_Str[14].AppendFormat("{0}");
            }
            ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = "{0}";
            ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = this.m_Str[14].ToString();
            break;
          }
          break;
        case POINT_KIND.PK_CAMP:
          ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = DataManager.Instance.mStringTable.GetStringByID(4540U);
          break;
        case POINT_KIND.PK_YOLK:
          if ((int) mapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
          {
            MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int) mapPoint.tableID];
            ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = DataManager.MapDataController.GetYolkName((ushort) mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID).ToString();
            break;
          }
          break;
      }
      this.HideNormalPanel();
      this.SetBookmarksPanel();
    }
    if (IsOpen)
      this.BookmarkSwitch.Switch(UIGroundInfo._BookmarkSwitch.eType.AddBookmark);
    ((Component) this.m_BookmarksPanel).gameObject.SetActive(IsOpen);
    this.bGroundInfoOpen = IsOpen;
  }

  public void UpdateBookmarkTitlePos()
  {
    UIText component = ((Transform) this.m_BookmarksPanel).GetChild(8).GetComponent<UIText>();
    RectTransform child = ((Transform) this.m_BookmarksPanel).GetChild(7) as RectTransform;
    float num1 = component.preferredWidth;
    if ((double) num1 > 290.0)
    {
      component.resizeTextForBestFit = true;
      component.resizeTextMaxSize = 21;
      component.resizeTextMinSize = 10;
      num1 = 290f;
    }
    else
      component.resizeTextForBestFit = false;
    Vector2 sizeDelta = ((Graphic) component).rectTransform.sizeDelta with
    {
      x = num1
    };
    ((Graphic) component).rectTransform.sizeDelta = sizeDelta;
    float num2 = (float) (((double) num1 + 53.0 + 10.0) / 2.0);
    Vector2 anchoredPosition = child.anchoredPosition with
    {
      x = -num2
    };
    child.anchoredPosition = anchoredPosition;
    anchoredPosition = ((Graphic) component).rectTransform.anchoredPosition with
    {
      x = (float) ((double) child.anchoredPosition.x + 26.5 + 10.0 + (double) num1 / 2.0)
    };
    ((Graphic) component).rectTransform.anchoredPosition = anchoredPosition;
  }

  public void OpenPvePanel(bool IsOpen, ushort CorpsStagekey = 1)
  {
    ushort HIID = 0;
    CorpsStage recordByKey = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(CorpsStagekey);
    if (recordByKey.Heros != null)
      HIID = recordByKey.Heros[0].HeroID;
    if (IsOpen)
    {
      this.m_PveTitle.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.LordTile);
      this.m_PveHeroName.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.LordName);
      this.m_Str[16].ClearString();
      this.m_Str[16].IntToFormat((long) DataManager.StageDataController.CorpsStagetotalStrength);
      this.m_Str[16].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4541U));
      this.m_PvePowerText.text = this.m_Str[16].ToString();
      this.m_PvePowerText.SetAllDirty();
      this.m_PvePowerText.cachedTextGenerator.Invalidate();
      this.m_PvePowerText.cachedTextGeneratorForLayout.Invalidate();
      ((Graphic) this.m_PvePowerText).rectTransform.sizeDelta = new Vector2(this.m_PvePowerText.preferredWidth, ((Graphic) this.m_PvePowerText).rectTransform.sizeDelta.y);
      ((Graphic) this.m_PvePowerText).rectTransform.anchoredPosition = new Vector2(13f, ((Graphic) this.m_PvePowerText).rectTransform.anchoredPosition.y);
      ((Graphic) this.m_PvePowerIcon).rectTransform.anchoredPosition = new Vector2((float) (-((double) this.m_PvePowerText.preferredWidth / 2.0) - 3.0), ((Graphic) this.m_PvePowerIcon).rectTransform.anchoredPosition.y);
      GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_PveHeroBtn).transform, eHeroOrItem.Hero, HIID, (byte) 11, (byte) 0);
      NewbieManager.CheckTeach(ETeachKind.WAR_SCOUT, (object) this);
    }
    ((Component) this.m_PvePanel).gameObject.SetActive(IsOpen);
    this.bGroundInfoOpen = IsOpen;
  }

  public void OpenRewardPanel(bool IsOpen)
  {
    ((Component) this.m_RewardPanel).gameObject.SetActive(IsOpen);
  }

  public void OpenTitlePanel(bool IsOpen)
  {
    ((Component) this.m_TitlePanel).gameObject.SetActive(IsOpen);
  }

  public void ModifyBookmarksPanel(
    ushort bookMarkDataIdx,
    UIGroundInfo._BookmarkSwitch.eType bookType)
  {
    this.m_ModifyBookMarkID = bookMarkDataIdx;
    --bookMarkDataIdx;
    if (bookType == UIGroundInfo._BookmarkSwitch.eType.ModifyBookmark && (int) bookMarkDataIdx < DataManager.Instance.RoleBookMark.AllData.Length)
    {
      UIText component = ((Transform) this.m_BookmarksPanel).GetChild(8).GetComponent<UIText>();
      component.font = GUIManager.Instance.GetTTFFont();
      component.text = DataManager.Instance.mStringTable.GetStringByID(788U);
      int mapId = DataManager.Instance.RoleBookMark.AllData[(int) bookMarkDataIdx].MapID;
      ((Transform) this.m_BookmarksPanel).GetChild(5).GetChild(0).GetComponent<UIText>().text = this.GetLocation(mapId);
      ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = StringManager.InputTemp;
      ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = DataManager.Instance.RoleBookMark.AllData[(int) bookMarkDataIdx].Name.ToString();
      this.m_BookmarkSelect = DataManager.Instance.RoleBookMark.AllData[(int) bookMarkDataIdx].Type;
      this.SetBookmarksPanel();
    }
    else if (bookType == UIGroundInfo._BookmarkSwitch.eType.ModifyAlliancemark && (int) bookMarkDataIdx < DataManager.Instance.RoleBookMark.AllAllianceData.Length)
    {
      UIText component = ((Transform) this.m_BookmarksPanel).GetChild(8).GetComponent<UIText>();
      component.font = GUIManager.Instance.GetTTFFont();
      component.text = DataManager.Instance.mStringTable.GetStringByID(12635U);
      int mapId = DataManager.Instance.RoleBookMark.AllAllianceData[(int) bookMarkDataIdx].MapID;
      ((Transform) this.m_BookmarksPanel).GetChild(5).GetChild(0).GetComponent<UIText>().text = this.GetLocation(mapId);
      ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = StringManager.InputTemp;
      ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text = DataManager.Instance.RoleBookMark.AllAllianceData[(int) bookMarkDataIdx].Name.ToString();
      this.m_BookmarkSelect = DataManager.Instance.RoleBookMark.AllAllianceData[(int) bookMarkDataIdx].Type;
      this.SetBookmarksPanel();
    }
    this.UpdateBookmarkTitlePos();
    this.BookmarkSwitch.Switch(bookType);
    ((Component) this.m_BookmarksPanel).gameObject.SetActive(true);
  }

  public bool ScoutCheckBox(eScoutCheckBox eCheck)
  {
    GUIManager instance = GUIManager.Instance;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
    ResourcesPoint resourcesPoint = DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID];
    PlayerPoint playerPoint = DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID];
    byte capitalFlag = playerPoint.capitalFlag;
    uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    byte techLevel = DataManager.Instance.GetTechLevel((ushort) 43);
    int num = 0;
    for (int index = 0; index < 8; ++index)
    {
      if (DataManager.Instance.MarchEventData[index].Type != EMarchEventType.EMET_Standby)
        ++num;
    }
    if (DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
      ++num;
    POINT_KIND mapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) this.m_MapPointID);
    bool flag1 = !DataManager.MapDataController.IsResources((uint) this.m_MapPointID) ? (mapPoint.pointKind != (byte) 11 ? DataManager.Instance.IsSameAlliance(playerPoint.allianceTag) : DataManager.Instance.IsSameAlliance(DataManager.MapDataController.YolkPointTable[(int) mapPoint.tableID].WonderAllianceTag)) : DataManager.Instance.IsSameAlliance(resourcesPoint.allianceTag);
    bool flag2 = false;
    this.m_Str[17].ClearString();
    switch (eCheck)
    {
      case eScoutCheckBox.PreScout:
        if (mapInfoPointKind == POINT_KIND.PK_CITY && ((int) capitalFlag & 4) != 0)
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(4898U), mStringTable.GetStringByID(4899U));
          flag2 = false;
          break;
        }
        if ((long) num >= (long) effectBaseVal)
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(3967U), mStringTable.GetStringByID(3959U));
          flag2 = false;
          break;
        }
        if (techLevel <= (byte) 0)
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(5710U), mStringTable.GetStringByID(5711U), 9, mStringTable.GetStringByID(3968U), bCloseIDSet: true);
          flag2 = false;
          break;
        }
        flag2 = true;
        break;
      case eScoutCheckBox.Shield_Self:
        if ((long) num >= (long) effectBaseVal)
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(3967U), mStringTable.GetStringByID(3959U));
          flag2 = false;
          break;
        }
        if (techLevel <= (byte) 0)
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(5710U), mStringTable.GetStringByID(5711U), 9, mStringTable.GetStringByID(3968U), bCloseIDSet: true);
          flag2 = false;
          break;
        }
        if (this.IsSameScouting())
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(5710U), mStringTable.GetStringByID(5711U));
          flag2 = false;
          break;
        }
        switch (mapInfoPointKind)
        {
          case POINT_KIND.PK_NONE:
            instance.OpenMessageBox(mStringTable.GetStringByID(5715U), mStringTable.GetStringByID(5716U));
            goto label_50;
          case POINT_KIND.PK_CITY:
            if (((int) capitalFlag & 4) != 0)
            {
              instance.OpenMessageBox(mStringTable.GetStringByID(4898U), mStringTable.GetStringByID(4899U));
              flag2 = false;
              goto label_50;
            }
            else
              break;
        }
        if (flag1)
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(5718U), mStringTable.GetStringByID(5719U));
          flag2 = false;
          break;
        }
        if ((long) DataManager.Instance.Resource[4].Stock < (long) this.GetScoutMoney(this.m_ScoutTagLv, mapInfoPointKind))
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(5721U), mStringTable.GetStringByID(5722U), 6, mStringTable.GetStringByID(5723U), bCloseIDSet: true);
          this.OpenDetectPanel(false, (byte) 0);
          flag2 = false;
          break;
        }
        flag2 = true;
        break;
      case eScoutCheckBox.NoShield_Self:
        if ((long) num >= (long) effectBaseVal)
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(3967U), mStringTable.GetStringByID(3959U));
          flag2 = false;
          break;
        }
        if (techLevel <= (byte) 0)
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(5710U), mStringTable.GetStringByID(5711U), 9, mStringTable.GetStringByID(3968U), bCloseIDSet: true);
          flag2 = false;
          break;
        }
        if (this.IsSameScouting())
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(5725U), mStringTable.GetStringByID(5726U));
          flag2 = false;
          break;
        }
        switch (mapInfoPointKind)
        {
          case POINT_KIND.PK_NONE:
            instance.OpenMessageBox(mStringTable.GetStringByID(5715U), mStringTable.GetStringByID(5716U));
            goto label_50;
          case POINT_KIND.PK_CITY:
            if (((int) capitalFlag & 4) != 0)
            {
              instance.OpenMessageBox(mStringTable.GetStringByID(4898U), mStringTable.GetStringByID(4899U));
              flag2 = false;
              goto label_50;
            }
            else
              break;
        }
        if (flag1)
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(5718U), mStringTable.GetStringByID(5719U));
          flag2 = false;
          break;
        }
        if ((long) DataManager.Instance.Resource[4].Stock < (long) this.GetScoutMoney(this.m_ScoutTagLv, mapInfoPointKind))
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(5721U), mStringTable.GetStringByID(5722U), 6, mStringTable.GetStringByID(5723U), bCloseIDSet: true);
          this.OpenDetectPanel(false, (byte) 0);
          flag2 = false;
          break;
        }
        flag2 = true;
        break;
      case eScoutCheckBox.Shield_Other:
        if (mapInfoPointKind == POINT_KIND.PK_CITY && ((int) capitalFlag & 4) != 0)
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(4898U), mStringTable.GetStringByID(4899U));
          flag2 = false;
          break;
        }
        if ((long) DataManager.Instance.Resource[4].Stock < (long) this.GetScoutMoney(this.m_ScoutTagLv, mapInfoPointKind))
        {
          instance.OpenMessageBox(mStringTable.GetStringByID(5721U), mStringTable.GetStringByID(5722U), 6, mStringTable.GetStringByID(5723U), bCloseIDSet: true);
          this.OpenDetectPanel(false, (byte) 0);
          flag2 = false;
          break;
        }
        flag2 = true;
        break;
    }
label_50:
    return flag2;
  }

  public bool AttackCheckBox()
  {
    GUIManager instance = GUIManager.Instance;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    byte capitalFlag = DataManager.MapDataController.PlayerPointTable[(int) DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID].tableID].capitalFlag;
    POINT_KIND mapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) this.m_MapPointID);
    uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    int num = 0;
    for (int index = 0; index < 8; ++index)
    {
      if (DataManager.Instance.MarchEventData[index].Type != EMarchEventType.EMET_Standby)
        ++num;
    }
    bool flag;
    if (mapInfoPointKind == POINT_KIND.PK_CITY && ((int) capitalFlag & 4) != 0)
    {
      instance.OpenMessageBox(mStringTable.GetStringByID(4898U), mStringTable.GetStringByID(4899U));
      flag = false;
    }
    else if ((long) num >= (long) effectBaseVal)
    {
      instance.OpenMessageBox(mStringTable.GetStringByID(3967U), mStringTable.GetStringByID(3959U));
      flag = false;
    }
    else
      flag = true;
    return flag;
  }

  public bool ReinforceCheck()
  {
    GUIManager instance = GUIManager.Instance;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    int num = 0;
    for (int index = 0; index < 8; ++index)
    {
      if (DataManager.Instance.MarchEventData[index].Type != EMarchEventType.EMET_Standby)
        ++num;
    }
    this.m_Str[26].ClearString();
    bool flag;
    if ((long) num >= (long) effectBaseVal)
    {
      instance.OpenMessageBox(mStringTable.GetStringByID(3967U), mStringTable.GetStringByID(3959U));
      flag = false;
    }
    else
      flag = true;
    if (!flag)
      this.Close();
    return flag;
  }

  public bool RallyCheck()
  {
    GUIManager instance = GUIManager.Instance;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
    PlayerPoint playerPoint = DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID];
    byte capitalFlag = playerPoint.capitalFlag;
    uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    int num = 0;
    for (int index = 0; index < 8; ++index)
    {
      if (DataManager.Instance.MarchEventData[index].Type != EMarchEventType.EMET_Standby)
        ++num;
    }
    bool flag1 = GUIManager.Instance.BuildingData.GetBuildData((ushort) 11, (ushort) 0).Level > (byte) 0;
    bool flag2;
    if (DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) this.m_MapPointID) == POINT_KIND.PK_CITY && ((int) capitalFlag & 4) != 0)
    {
      instance.OpenMessageBox(mStringTable.GetStringByID(4898U), mStringTable.GetStringByID(4899U));
      flag2 = false;
    }
    else if ((long) num >= (long) effectBaseVal)
    {
      instance.OpenMessageBox(mStringTable.GetStringByID(3967U), mStringTable.GetStringByID(3959U));
      flag2 = false;
    }
    else if (DataManager.Instance.RoleAlliance.Id == 0U)
    {
      instance.OpenMessageBox(mStringTable.GetStringByID(4892U), mStringTable.GetStringByID(4893U));
      flag2 = false;
    }
    else if (!flag1)
    {
      instance.OpenMessageBox(mStringTable.GetStringByID(4895U), mStringTable.GetStringByID(4896U));
      flag2 = false;
    }
    else if (!this.IsNpcCastleType((POINT_KIND) mapPoint.pointKind, mapPoint.tableID) && mapPoint.pointKind != (byte) 11 && playerPoint.level < (byte) 17 && playerPoint.allianceTag.Length == 0)
    {
      instance.OpenMessageBox(mStringTable.GetStringByID(4901U), mStringTable.GetStringByID(4902U));
      flag2 = false;
    }
    else
      flag2 = true;
    return flag2;
  }

  public bool IsSameScouting()
  {
    bool flag = false;
    for (int index = 0; index < 8; ++index)
    {
      if (DataManager.Instance.MarchEventData[index].Type == EMarchEventType.EMET_ScoutMarching || DataManager.Instance.MarchEventData[index].Type == EMarchEventType.EMET_ScoutReturn)
      {
        PointCode pointCode;
        GameConstants.MapIDToPointCode(this.m_MapPointID, out pointCode.zoneID, out pointCode.pointID);
        if ((int) DataManager.Instance.MarchEventData[index].Point.zoneID == (int) pointCode.zoneID && (int) DataManager.Instance.MarchEventData[index].Point.pointID == (int) pointCode.pointID)
        {
          flag = true;
          break;
        }
      }
    }
    return flag;
  }

  public int GetScoutMoney(byte lv, POINT_KIND kind = POINT_KIND.PK_CITY)
  {
    int scoutMoney = 0;
    if (kind == POINT_KIND.PK_YOLK)
      scoutMoney = 10000;
    else if (this.m_MapPointID >= 0 && this.m_MapPointID < DataManager.MapDataController.LayoutMapInfo.Length)
    {
      MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
      scoutMoney = !this.IsNpcCastleType(kind, mapPoint.tableID) ? this.ScoutNeedMoney[Mathf.Clamp((int) lv - 1, 0, this.ScoutNeedMoney.Length - 1)] : this.ScoutNeedMoney_NpcCastle[Mathf.Clamp((int) lv - 1, 0, this.ScoutNeedMoney_NpcCastle.Length - 1)];
    }
    return scoutMoney;
  }

  public string GetBooksPanelTitle()
  {
    return ((Transform) this.m_BookmarksPanel).GetChild(9).GetComponent<UIEmojiInput>().text;
  }

  public ushort GetKingdomIDByMapPointID(int mapPointID) => 0;

  public void SetBookmarksPanel()
  {
    UISpritesArray component = ((Component) this.m_AttackPanel).GetComponent<UISpritesArray>();
    if (this.m_BookmarkSelect == (byte) 3)
    {
      ((Transform) this.m_BookmarksPanel).GetChild(15).GetComponent<Image>().sprite = component.GetSprite(1);
      ((Transform) this.m_BookmarksPanel).GetChild(15).GetChild(1).gameObject.SetActive(true);
      for (int index = 0; index < 3; ++index)
      {
        ((Transform) this.m_BookmarksPanel).GetChild(10 + index).GetComponent<Image>().sprite = component.GetSprite(0);
        ((Transform) this.m_BookmarksPanel).GetChild(10 + index).GetChild(1).gameObject.SetActive(false);
      }
    }
    else
    {
      ((Transform) this.m_BookmarksPanel).GetChild(15).GetComponent<Image>().sprite = component.GetSprite(0);
      ((Transform) this.m_BookmarksPanel).GetChild(15).GetChild(1).gameObject.SetActive(false);
      for (int index = 0; index < 3; ++index)
      {
        if ((int) this.m_BookmarkSelect == index)
        {
          ((Transform) this.m_BookmarksPanel).GetChild(10 + index).GetComponent<Image>().sprite = component.GetSprite(1);
          ((Transform) this.m_BookmarksPanel).GetChild(10 + index).GetChild(1).gameObject.SetActive(true);
        }
        else
        {
          ((Transform) this.m_BookmarksPanel).GetChild(10 + index).GetComponent<Image>().sprite = component.GetSprite(0);
          ((Transform) this.m_BookmarksPanel).GetChild(10 + index).GetChild(1).gameObject.SetActive(false);
        }
      }
    }
  }

  public void Unload()
  {
    this.m_PanelGameObject = this.m_TeamPanelGameObject = (GameObject) null;
    for (int index = 0; index < 51; ++index)
    {
      if (this.m_Str[index] != null)
        StringManager.Instance.DeSpawnString(this.m_Str[index]);
    }
    StringManager.Instance.DeSpawnString(this.BookMarkNameStr);
    if ((Object) this.m_AssetBundle == (Object) null)
      return;
    AssetManager.UnloadAssetBundle(this.m_AssetBundleKey);
    this.m_AssetBundle = (AssetBundle) null;
    this.m_AssetBundleKey = 0;
    Object.Destroy((Object) ((Component) this.m_RectTransform).gameObject);
    if ((Object) this.WonderTileMapMat1 != (Object) null)
      Object.Destroy((Object) this.WonderTileMapMat1);
    if ((Object) this.WonderTileMapMat2 != (Object) null)
      Object.Destroy((Object) this.WonderTileMapMat2);
    if (!((Object) this.m_BGIcon != (Object) null))
      return;
    this.m_BGIcon.sprite = (Sprite) null;
  }

  public void OnButtonClick(UIButton sender)
  {
    ushort result1 = 0;
    int result2 = 0;
    int result3 = 0;
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
    POINT_KIND mapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) this.m_MapPointID);
    if (sender.m_BtnID2 >= 101 && sender.m_BtnID2 <= 110 && sender.m_BtnID3 >= 100)
    {
      this.ShowCantClickMsg(sender.m_BtnID3);
    }
    else
    {
      switch (sender.m_BtnID2)
      {
        case 1:
        case 203:
          this.Close();
          break;
        case 2:
          this.m_BookmarkSelect = (byte) 0;
          this.OpenTitlePanel(false);
          this.OpenBookmarksPanel(true);
          break;
        case 3:
          this.SetChatText(this.m_MapPointID);
          break;
        case 101:
          switch (this.m_eGroundInfoKind)
          {
            case EGroundInfoKind.Resource:
              if (this.OwnerKind == 1)
              {
                DataManager.Instance.TroopeTakeBack(this.m_MapPointID, EMarchEventType.EMET_Gathering);
                GUIManager.Instance.HideUILock(EUILock.Expedition);
                this.Close();
                return;
              }
              if (this.OwnerKind == 2 || this.OwnerKind == 3)
              {
                DataManager.Instance.ShowLordProfile(DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].playerName.ToString());
                return;
              }
              if (this.OwnerKind != 0)
                return;
              if (this.CheckMarchEventDataCount())
              {
                PointCode pointCode;
                GameConstants.MapIDToPointCode(this.m_MapPointID, out pointCode.zoneID, out pointCode.pointID);
                if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) != 0.0)
                {
                  this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, this.m_MapPointID, bCameraMode: true);
                  return;
                }
                GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829U), DataManager.Instance.mStringTable.GetStringByID(119U));
                this.Close();
                return;
              }
              this.Close();
              return;
            case EGroundInfoKind.Camp:
              if (this.OwnerKind != 2 && this.OwnerKind != 3)
                return;
              DataManager.Instance.ShowLordProfile(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName.ToString());
              return;
            case EGroundInfoKind.Castle:
              if (this.OwnerKind == 1)
              {
                DataManager.MapDataController.OutMap();
                GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToMap);
                this.Close();
                return;
              }
              if (this.OwnerKind == 2)
              {
                if (this.bHaveAlly)
                {
                  this.m_Door.AllianceOnJoin(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag.ToString());
                  return;
                }
                DataManager.Instance.SendAllinceInvite(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName.ToString());
                return;
              }
              if (this.OwnerKind != 3)
                return;
              DataManager.Instance.ShowLordProfile(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName.ToString());
              return;
            case EGroundInfoKind.NpcCastle:
              if (!((Object) this.m_Door != (Object) null))
                return;
              this.m_Door.AllianceOnClick();
              this.Close();
              return;
            case EGroundInfoKind.Team:
              return;
            case EGroundInfoKind.WonderForest:
              return;
            case EGroundInfoKind.Wonder:
              if (!(bool) (Object) this.m_Door)
                return;
              this.m_Door.OpenMenu(EGUIWindow.UI_WonderLand, this.m_MapPointID, bCameraMode: true);
              return;
            default:
              return;
          }
        case 102:
          switch (this.m_eGroundInfoKind)
          {
            case EGroundInfoKind.Ground:
              DataManager.Instance.MoveTo(DataManager.MapDataController.FocusKingdomID, this.m_MapPointID);
              this.Close();
              return;
            case EGroundInfoKind.Resource:
              return;
            case EGroundInfoKind.Camp:
              DataManager.Instance.TroopeTakeBack(this.m_MapPointID, EMarchEventType.EMET_Camp);
              this.Close();
              return;
            case EGroundInfoKind.Castle:
              switch (this.OwnerKind)
              {
                case 2:
                  DataManager.Instance.ShowLordProfile(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName.ToString());
                  return;
                case 3:
                  if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) == 0.0)
                  {
                    GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829U), DataManager.Instance.mStringTable.GetStringByID(119U));
                    this.Close();
                    return;
                  }
                  if (GUIManager.Instance.CanResourceTransport())
                  {
                    if (this.bRequsetAdvanceMapdata)
                    {
                      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8459U), (ushort) byte.MaxValue);
                      return;
                    }
                    if (!this.IsSameKingdom())
                    {
                      GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826U), DataManager.Instance.mStringTable.GetStringByID(3957U), DataManager.Instance.mStringTable.GetStringByID(4828U));
                      return;
                    }
                    if (!(bool) (Object) this.m_Door)
                      return;
                    this.m_Door.OpenMenu(EGUIWindow.UI_Market_Help, 1, this.m_MapPointID);
                    return;
                  }
                  this.Close();
                  return;
                default:
                  return;
              }
            case EGroundInfoKind.NpcCastle:
              return;
            case EGroundInfoKind.Team:
              return;
            case EGroundInfoKind.WonderForest:
              GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(851U), DataManager.Instance.mStringTable.GetStringByID(852U), bInfo: true, BackExit: true);
              this.Close();
              return;
            case EGroundInfoKind.Wonder:
              if (!(bool) (Object) this.m_Door)
                return;
              this.m_Door.OpenMenu(EGUIWindow.UI_WonderLand, this.m_MapPointID, bCameraMode: true);
              return;
            default:
              return;
          }
        case 103:
          switch (this.m_eGroundInfoKind)
          {
            case EGroundInfoKind.Ground:
              if (this.CheckMarchEventDataCount())
              {
                PointCode pointCode;
                GameConstants.MapIDToPointCode(this.m_MapPointID, out pointCode.zoneID, out pointCode.pointID);
                if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) != 0.0)
                {
                  this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, this.m_MapPointID, bCameraMode: true);
                  return;
                }
                GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829U), DataManager.Instance.mStringTable.GetStringByID(119U));
                this.Close();
                return;
              }
              this.Close();
              return;
            case EGroundInfoKind.Resource:
              return;
            case EGroundInfoKind.Camp:
              if (!(bool) (Object) this.m_Door)
                return;
              this.m_Door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 1, this.GetMarcheventIdx(this.m_MapPointID));
              return;
            case EGroundInfoKind.Castle:
              if (this.OwnerKind == 3)
              {
                if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) == 0.0)
                {
                  GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829U), DataManager.Instance.mStringTable.GetStringByID(119U));
                  this.Close();
                  return;
                }
                if (this.ReinforceCheck())
                {
                  DataManager.Instance.ReinforceCheckType = eReinforceCheck.OpenReinforce;
                  DataManager.Instance.SendAllyInforceInfo(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName.ToString());
                  this.Close();
                  return;
                }
                this.Close();
                return;
              }
              if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) == 0.0)
              {
                GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829U), DataManager.Instance.mStringTable.GetStringByID(119U));
                this.Close();
                return;
              }
              if (this.RallyCheck())
              {
                this.OpenTitlePanel(false);
                this.OpenAttackPanel(true);
                return;
              }
              this.Close();
              return;
            case EGroundInfoKind.NpcCastle:
              if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) == 0.0)
              {
                GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829U), DataManager.Instance.mStringTable.GetStringByID(119U));
                this.Close();
                return;
              }
              if (!this.RallyCheck())
                return;
              this.OpenTitlePanel(false);
              this.OpenAttackPanel(true);
              return;
            case EGroundInfoKind.Team:
              return;
            case EGroundInfoKind.WonderForest:
              DataManager.Instance.MoveTo(DataManager.MapDataController.FocusKingdomID, this.m_MapPointID);
              this.Close();
              return;
            case EGroundInfoKind.Wonder:
              if (this.OwnerKind == 2)
              {
                if (this.RallyCheck())
                {
                  this.OpenAttackPanel(true);
                  return;
                }
                this.Close();
                return;
              }
              if (this.OwnerKind != 1 && this.OwnerKind != 3 || (int) mapPoint.tableID >= DataManager.MapDataController.YolkPointTable.Length)
                return;
              MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int) mapPoint.tableID];
              if (!((Object) this.m_Door != (Object) null))
                return;
              this.m_Door.OpenMenu(EGUIWindow.UI_Rally, 101, (int) mapYolk.WonderID);
              return;
            default:
              return;
          }
        case 104:
          switch (this.m_eGroundInfoKind)
          {
            case EGroundInfoKind.Resource:
              PointCode point;
              GameConstants.MapIDToPointCode(this.m_MapPointID, out point.zoneID, out point.pointID);
              DataManager.Instance.SendResPointLv(point);
              return;
            case EGroundInfoKind.Camp:
            case EGroundInfoKind.Castle:
            case EGroundInfoKind.NpcCastle:
              this.OpenDetectPanel(true, (byte) 0);
              this.OpenTitlePanel(false);
              return;
            case EGroundInfoKind.Team:
              return;
            case EGroundInfoKind.WonderForest:
              return;
            case EGroundInfoKind.Wonder:
              this.OpenDetectPanel(true, (byte) 0, true);
              return;
            default:
              return;
          }
        case 105:
          switch (this.m_eGroundInfoKind)
          {
            case EGroundInfoKind.Resource:
            case EGroundInfoKind.Camp:
            case EGroundInfoKind.Castle:
            case EGroundInfoKind.Wonder:
              if (this.AttackCheckBox())
              {
                PointCode pointCode;
                GameConstants.MapIDToPointCode(this.m_MapPointID, out pointCode.zoneID, out pointCode.pointID);
                if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) != 0.0)
                {
                  this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, this.m_MapPointID, bCameraMode: true);
                  return;
                }
                GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829U), DataManager.Instance.mStringTable.GetStringByID(119U));
                this.Close();
                return;
              }
              this.Close();
              return;
            case EGroundInfoKind.NpcCastle:
              return;
            case EGroundInfoKind.Team:
              return;
            case EGroundInfoKind.WonderForest:
              return;
            default:
              return;
          }
        case 106:
          if (this.m_eGroundInfoKind != EGroundInfoKind.Castle || this.OwnerKind != 3)
            break;
          DataManager.Instance.ShowLordProfile(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName.ToString());
          break;
        case 107:
          if (this.m_eGroundInfoKind != EGroundInfoKind.Castle || this.OwnerKind != 3)
            break;
          if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) == 0.0)
          {
            GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829U), DataManager.Instance.mStringTable.GetStringByID(119U));
            this.Close();
            break;
          }
          if (this.CheckMarchEventDataCount())
          {
            AmbushManager.Instance.SendAllyAmbushInfo(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName.ToString());
            break;
          }
          this.Close();
          break;
        case 109:
          if (this.bRequsetAdvanceMapdata)
          {
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8459U), (ushort) byte.MaxValue);
            break;
          }
          if (!(bool) (Object) this.m_Door)
            break;
          this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, this.m_MapPointID, 7, true);
          break;
        case 110:
          if (!(bool) (Object) this.m_Door)
            break;
          this.m_Door.OpenMenu(EGUIWindow.UI_CastleSkin, bCameraMode: true);
          break;
        case 111:
          ushort zoneID = 0;
          byte pointID = 0;
          GameConstants.MapIDToPointCode(-1, out zoneID, out pointID);
          GUIManager.Instance.UseOrSpend(GameConstants.RandomTeleportItemID, DataManager.Instance.mStringTable.GetStringByID(4512U), DataManager.MapDataController.FocusKingdomID, zoneID, (ushort) pointID, UseOrSpendType.UST_DIAMOND_DOUBLE_CHECK, SpecialStr: string.Empty, maxcount: (ushort) 0);
          this.Close();
          break;
        case 201:
          DataManager.Instance.TroopeTakeBack((uint) this.m_MapPointID);
          break;
        case 202:
          if (!(bool) (Object) this.m_Door)
            break;
          if (DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag == (byte) 22)
          {
            this.m_Door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 30);
            break;
          }
          this.m_Door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 1073741824 | this.m_MapPointID);
          break;
        case 204:
          if (!(bool) (Object) this.m_Door || this.m_MapPointID >= DataManager.MapDataController.MapLineTable.Count)
            break;
          MapLine mapLine = DataManager.MapDataController.MapLineTable[this.m_MapPointID];
          PointCode pointCode1 = mapLine.end;
          if (GameConstants.IsPetSkillLine(this.m_MapPointID))
            pointCode1 = mapLine.start;
          else if (mapLine.lineFlag > (byte) 4 && mapLine.lineFlag < (byte) 14)
            pointCode1 = mapLine.start;
          this.m_Door.GoToPointCode(DataManager.MapDataController.FocusKingdomID, pointCode1.zoneID, pointCode1.pointID, (byte) 0);
          break;
        case 205:
          if (!(bool) (Object) this.m_Door || this.m_MapPointID >= DataManager.MapDataController.MapLineTable.Count)
            break;
          PointCode end = DataManager.MapDataController.MapLineTable[this.m_MapPointID].end;
          this.m_Door.GoToPointCode(DataManager.MapDataController.FocusKingdomID, end.zoneID, end.pointID, (byte) 0);
          break;
        case 301:
          if (this.m_Door.m_eMapMode == EUIOriginMapMode.WorldMap)
          {
            ushort.TryParse(((Component) sender).gameObject.transform.parent.GetChild(8).GetChild(0).GetComponent<UIText>().text, out result1);
            if (DataManager.MapDataController.CheckKingdomID(result1))
            {
              this.m_Door.GoToKingdom(result1);
              this.Close();
              break;
            }
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4503U), (ushort) byte.MaxValue);
            break;
          }
          ushort.TryParse(((Component) sender).gameObject.transform.parent.GetChild(8).GetChild(0).GetComponent<UIText>().text, out result1);
          int.TryParse(((Component) sender).gameObject.transform.parent.GetChild(9).GetChild(0).GetComponent<UIText>().text, out result2);
          int.TryParse(((Component) sender).gameObject.transform.parent.GetChild(10).GetChild(0).GetComponent<UIText>().text, out result3);
          if (DataManager.MapDataController.CheckKingdomID(result1) && GameConstants.CheckTileMapPos(result2, result3))
          {
            this.m_Door.CheckFocusGroup();
            DataManager.MapDataController.FocusGroupID = (byte) 10;
            this.m_Door.GoToMapID(result1, GameConstants.TileMapPosToMapID(result2, result3), (byte) 0, (byte) 1);
            break;
          }
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4503U), (ushort) byte.MaxValue);
          break;
        case 302:
          this.OpenSearchPanel(false);
          break;
        case 303:
          if (this.ReinforceCheck())
          {
            if (this.bOpenUIExpedition_FromList)
            {
              DataManager.Instance.ReinforceCheckType = eReinforceCheck.OpenUIExpedition_FromList;
              DataManager.Instance.SendAllyInforceInfo(DataManager.Instance.m_InForceName);
            }
            else
            {
              DataManager.Instance.ReinforceCheckType = eReinforceCheck.OpenUIExpedition;
              if (mapInfoPointKind != POINT_KIND.PK_YOLK && (int) mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
                DataManager.Instance.SendAllyInforceInfo(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName.ToString());
            }
            this.Close();
            break;
          }
          this.Close();
          break;
        case 304:
          this.OpenReinforcePanel(false);
          break;
        case 305:
          this.OpenDetectPanel(false, (byte) 0);
          bool flag1 = this.ScoutCheckBox(eScoutCheckBox.Shield_Other);
          bool flag2 = this.IsNpcCastleType(mapInfoPointKind, mapPoint.tableID);
          if (!flag1)
            break;
          if (!flag2 && DataManager.Instance.m_BuffListOpenIcon == (byte) 1)
          {
            int warBuffCd = DataManager.Instance.GetWarBuffCD();
            if (warBuffCd > 0)
            {
              CString cstring = StringManager.Instance.StaticString1024();
              cstring.ClearString();
              cstring.IntToFormat((long) warBuffCd);
              cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9933U));
              GUIManager.Instance.OpenOKCancelBox(7, DataManager.Instance.mStringTable.GetStringByID(4840U), cstring.ToString(), this.m_MapPointID, YesText: DataManager.Instance.mStringTable.GetStringByID(4842U), NoText: DataManager.Instance.mStringTable.GetStringByID(4843U));
              break;
            }
            GUIManager.Instance.OpenOKCancelBox(7, DataManager.Instance.mStringTable.GetStringByID(4840U), DataManager.Instance.mStringTable.GetStringByID(4841U), this.m_MapPointID, YesText: DataManager.Instance.mStringTable.GetStringByID(4842U), NoText: DataManager.Instance.mStringTable.GetStringByID(4843U));
            break;
          }
          if (!this.ScoutCheckBox(eScoutCheckBox.NoShield_Self))
            break;
          DataManager.Instance.ScoutDesPoint.pointID = (byte) 0;
          DataManager.Instance.ScoutDesPoint.zoneID = (ushort) 0;
          GameConstants.MapIDToPointCode(this.m_MapPointID, out DataManager.Instance.ScoutDesPoint.zoneID, out DataManager.Instance.ScoutDesPoint.pointID);
          DataManager.Instance.SendScout(DataManager.Instance.ScoutDesPoint);
          break;
        case 306:
          this.OpenDetectPanel(false, (byte) 0);
          break;
        case 307:
          if (this.bHideSelectMod)
          {
            DataManager.Instance.RallyCountDownIndex = this.m_HideSelect;
            this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, arg2: 4, bCameraMode: true);
            break;
          }
          PointCode pointCode2;
          GameConstants.MapIDToPointCode(this.m_MapPointID, out pointCode2.zoneID, out pointCode2.pointID);
          if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) != 0.0)
          {
            DataManager.Instance.RallyCountDownIndex = this.m_AttackSelect;
            if (this.IsNpcCastleType(mapInfoPointKind, mapPoint.tableID))
              this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, arg2: 9, bCameraMode: true);
            else
              this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, arg2: 3, bCameraMode: true);
            this.OpenAttackPanel(false);
            break;
          }
          GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4829U), DataManager.Instance.mStringTable.GetStringByID(119U));
          break;
        case 308:
          this.OpenAttackPanel(false);
          break;
        case 309:
          this.SetAttackPanel(this.bHideSelectMod, (byte) 0);
          break;
        case 310:
          this.SetAttackPanel(this.bHideSelectMod, (byte) 1);
          break;
        case 311:
          this.SetAttackPanel(this.bHideSelectMod, (byte) 2);
          break;
        case 312:
          this.SetAttackPanel(this.bHideSelectMod, (byte) 3);
          break;
        case 313:
          if (this.m_ModifyBookMarkID == (ushort) 0)
          {
            if (this.m_MonsterMapPoint >= 0)
            {
              DataManager.Instance.RoleBookMark.sendAddBookMark(this.GetBooksPanelTitle(), this.m_BookmarkSelect, DataManager.MapDataController.FocusKingdomID, this.m_MonsterMapPoint);
              this.m_MonsterMapPoint = -1;
            }
            else
              DataManager.Instance.RoleBookMark.sendAddBookMark(this.GetBooksPanelTitle(), this.m_BookmarkSelect, DataManager.MapDataController.FocusKingdomID, this.m_MapPointID);
          }
          else
          {
            DataManager.Instance.RoleBookMark.sendModifyBookMark(this.m_ModifyBookMarkID, this.m_BookmarkSelect, this.GetBooksPanelTitle());
            this.m_ModifyBookMarkID = (ushort) 0;
          }
          this.OpenBookmarksPanel(false);
          break;
        case 314:
          this.OpenBookmarksPanel(false);
          break;
        case 315:
          this.m_BookmarkSelect = (byte) 0;
          this.SetBookmarksPanel();
          break;
        case 316:
          this.m_BookmarkSelect = (byte) 1;
          this.SetBookmarksPanel();
          break;
        case 317:
          this.m_BookmarkSelect = (byte) 2;
          this.SetBookmarksPanel();
          break;
        case 318:
          this.inputField.ActivateInputField();
          break;
        case 319:
          this.OpenPvePanel(false, (ushort) 1);
          this.bOpenPvePanel = true;
          this.m_Door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 4);
          break;
        case 320:
          this.OpenPvePanel(false, (ushort) 1);
          this.bOpenPvePanel = true;
          this.m_Door.OpenMenu(EGUIWindow.UI_Expedition, arg2: 1, bCameraMode: true);
          break;
        case 321:
          this.OpenPvePanel(false, (ushort) 1);
          this.bOpenPvePanel = false;
          break;
        case 322:
          this.Close();
          JailManage.Send_MSG_REQUEST_MAP_PRISONER_LIST(this.m_MapPointID);
          break;
        case 323:
          ushort ID = 0;
          if (this.m_ResType == (byte) 1)
            ID = (ushort) 858;
          else if (this.m_ResType == (byte) 2)
            ID = (ushort) 860;
          else if (this.m_ResType == (byte) 4)
            ID = (ushort) 859;
          else if (this.m_ResType == (byte) 3)
            ID = (ushort) 857;
          else if (this.m_ResType == (byte) 6)
            ID = (ushort) 983;
          GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(892U), DataManager.Instance.mStringTable.GetStringByID((uint) ID), DataManager.Instance.mStringTable.GetStringByID(3U), BackExit: true);
          break;
        case 324:
          this.m_SearchInput = (byte) 0;
          GUIManager.Instance.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
          GUIManager.Instance.m_UICalculator.OpenCalculator(9999L, 0L, 280f, 0.0f, mMinValue: 0L);
          break;
        case 325:
          this.m_SearchInput = (byte) 1;
          GUIManager.Instance.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
          GUIManager.Instance.m_UICalculator.OpenCalculator(999L, 0L, 280f, 0.0f, mMinValue: 0L);
          break;
        case 326:
          this.m_SearchInput = (byte) 2;
          GUIManager.Instance.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
          GUIManager.Instance.m_UICalculator.OpenCalculator(9999L, 0L, 280f, 0.0f, mMinValue: 0L);
          break;
        case 327:
          if ((int) mapPoint.tableID >= DataManager.MapDataController.PlayerPointTable.Length)
            break;
          byte btnType = this.ShowCanonizedBtnByTableID(mapPoint.tableID);
          switch (btnType)
          {
            case 1:
              TitleManager.Instance.OpenTitleSet(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName);
              return;
            case 2:
              TitleManager.Instance.OpenTitleListW(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName);
              return;
            case 3:
            case 5:
            case 6:
            case 7:
              GUIManager.Instance.OpenCanonizedPanel(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName, (byte) 1, (int) btnType);
              return;
            case 4:
              TitleManager.Instance.OpenNobilityTitleSet(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName);
              return;
            default:
              return;
          }
        case 328:
          GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(12043U), DataManager.Instance.mStringTable.GetStringByID(12042U), bInfo: true, BackExit: true);
          break;
        case 329:
          this.OpenExpressionUI();
          break;
        case 330:
          ushort kingdomID = 71;
          if (DataManager.MapDataController.CheckKingdomID(kingdomID))
          {
            this.m_Door.GoToKingdom(kingdomID);
            this.Close();
            break;
          }
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(4503U), (ushort) byte.MaxValue);
          break;
        case 331:
          if (sender.m_BtnID3 > 0)
          {
            if (sender.m_BtnID3 == 7744)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID((uint) sender.m_BtnID3), (ushort) byte.MaxValue);
              break;
            }
            if (sender.m_BtnID3 == 12572)
            {
              GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826U), DataManager.Instance.mStringTable.GetStringByID(12572U));
              this.Close();
              break;
            }
            if (sender.m_BtnID3 != 12563)
              break;
            GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826U), DataManager.Instance.mStringTable.GetStringByID(12563U));
            this.Close();
            break;
          }
          if (!PetBuff.ShowActive((byte) 1))
            break;
          this.Close();
          GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_PetSkill, this.m_MapPointID, 2, openMode: (byte) 0);
          break;
        case 332:
          this.m_BookmarkSelect = (byte) 3;
          this.SetBookmarksPanel();
          break;
      }
    }
  }

  public bool CheckMarchEventDataCount()
  {
    bool flag = true;
    int num = 0;
    for (int index = 0; index < 8; ++index)
    {
      if (DataManager.Instance.MarchEventData[index].Type != EMarchEventType.EMET_Standby)
        ++num;
    }
    uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    if ((long) num >= (long) effectBaseVal)
    {
      GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3967U), DataManager.Instance.mStringTable.GetStringByID(3959U));
      flag = false;
    }
    return flag;
  }

  public void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        POINT_KIND mapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) this.m_MapPointID);
        if (this.m_PanelGameObject.activeSelf)
        {
          if (this.m_infoKind == POINT_KIND.PK_NONE)
          {
            this.UpdateUIData_None(this.m_MapPointID);
            break;
          }
          if (mapInfoPointKind != this.m_PreKind)
          {
            this.Open(this.m_MapPointID);
            break;
          }
          this.SetOwnerKind();
          this.UpdateUIData(this.m_MapPointID);
          break;
        }
        if (this.m_TeamPanelGameObject.activeSelf)
        {
          this.SetOwnerKind();
          this.UpdateTeamData();
          break;
        }
        if (UIPetSkill.nowMapPoint != this.m_MapPointID || UIPetSkill.nowKind == mapInfoPointKind || !(bool) (Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_PetSkill))
          break;
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_PetSkill);
        GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        break;
      case 1:
        if (this.m_PanelGameObject.activeSelf)
        {
          this.SetNegativePetSkillBtn(true);
          this.UpdatemPetNegativeBuff(arg2, false);
          break;
        }
        if (!(bool) (Object) this.m_Door || !(bool) (Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_PetSkill) || arg2 != UIPetSkill.nowMapPoint || DataManager.MapDataController.getStateCountByKind((byte) 0) <= (byte) 0)
          break;
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826U), DataManager.Instance.mStringTable.GetStringByID(12572U));
        GUIManager.Instance.CloseMenu(EGUIWindow.UI_PetSkill);
        GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
        break;
    }
  }

  private void SetOwnerKind()
  {
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
    this.OwnerKind = 0;
    this.bHaveAlly = false;
    this.bHaveAlly_Self = false;
    if (DataManager.Instance.RoleAlliance.Id != 0U)
      this.bHaveAlly_Self = true;
    POINT_KIND mapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) this.m_MapPointID);
    if (DataManager.MapDataController.IsResources((uint) this.m_MapPointID))
    {
      if (DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].playerName.Length == 0)
        return;
      if (DataManager.CompareStr(DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].playerName, DataManager.Instance.RoleAttr.Name) == 0)
        this.OwnerKind = 1;
      else if (DataManager.Instance.IsSameAlliance(DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].allianceTag))
        this.OwnerKind = 3;
      else
        this.OwnerKind = 2;
    }
    else
    {
      switch (mapInfoPointKind)
      {
        case POINT_KIND.PK_CITY:
          this.OwnerKind = this.m_MapPointID != DataManager.Instance.RoleAttr.CapitalPoint || (int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID ? (!DataManager.Instance.IsSameAlliance(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag) ? 2 : 3) : 1;
          if (DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag.Length == 0)
            break;
          this.bHaveAlly = true;
          break;
        case POINT_KIND.PK_CAMP:
          if (DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName.Length != 0)
            this.OwnerKind = DataManager.CompareStr(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName, DataManager.Instance.RoleAttr.Name) != 0 ? (!DataManager.Instance.IsSameAlliance(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag) ? 2 : 3) : 1;
          if (DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag.Length == 0)
            break;
          this.bHaveAlly = true;
          break;
        case POINT_KIND.PK_YOLK:
          if (DataManager.Instance.RoleAlliance.Tag == null || DataManager.Instance.RoleAlliance.Tag.Length <= 0)
          {
            this.OwnerKind = 4;
            break;
          }
          if (this.CheckWonderArmy())
          {
            this.OwnerKind = 1;
            break;
          }
          if (DataManager.MapDataController.YolkPointTable[(int) mapPoint.tableID].OwnerAllianceName == null)
            break;
          if (DataManager.Instance.IsSameAlliance(DataManager.MapDataController.YolkPointTable[(int) mapPoint.tableID].WonderAllianceTag))
          {
            this.OwnerKind = 3;
            break;
          }
          this.OwnerKind = 2;
          break;
      }
    }
  }

  private void UpdateTeamData()
  {
    this.m_TeamPanelGameObject.SetActive(true);
    this.m_PanelGameObject.SetActive(false);
    this.m_eGroundInfoKind = EGroundInfoKind.Team;
    if (this.m_MapPointID >= DataManager.MapDataController.MapLineTable.Count)
      return;
    this.OwnerKind = DataManager.MapDataController.MapLineTable[this.m_MapPointID].playerName == null || DataManager.CompareStr(DataManager.MapDataController.MapLineTable[this.m_MapPointID].playerName, DataManager.Instance.RoleAttr.Name) != 0 ? (!DataManager.Instance.IsSameAlliance(DataManager.MapDataController.MapLineTable[this.m_MapPointID].allianceTag) ? 2 : 3) : 1;
    this.m_Str[13].ClearString();
    if (DataManager.MapDataController.MapLineTable[this.m_MapPointID].allianceTag != null && DataManager.MapDataController.MapLineTable[this.m_MapPointID].allianceTag.Length != 0)
    {
      GameConstants.FormatRoleName(this.m_Str[13], DataManager.MapDataController.MapLineTable[this.m_MapPointID].playerName, DataManager.MapDataController.MapLineTable[this.m_MapPointID].allianceTag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    }
    else
    {
      StringManager.Instance.StringToFormat(DataManager.MapDataController.MapLineTable[this.m_MapPointID].playerName);
      this.m_Str[13].AppendFormat("{0}");
    }
    this.m_TeamIDText.text = this.m_Str[13].ToString();
    this.m_TeamIDText.SetAllDirty();
    this.m_TeamIDText.cachedTextGenerator.Invalidate();
    this.m_TeamIDText.cachedTextGeneratorForLayout.Invalidate();
    ((Graphic) this.m_TeamIDLine).rectTransform.sizeDelta = new Vector2(this.m_TeamIDText.preferredWidth, ((Graphic) this.m_TeamIDLine).rectTransform.sizeDelta.y);
    EMarchEventType lineFlag = (EMarchEventType) DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag;
    if (this.OwnerKind == 1)
    {
      if (GameConstants.IsPetSkillLine(this.m_MapPointID))
      {
        ((Component) this.m_TeamRetureBtn).gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-105f, -251f);
        this.m_TeamSpeedBtnGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(30f, -251f);
        ((Component) this.m_TeamRetureBtn).gameObject.SetActive(false);
        this.m_TeamSpeedBtnGameObject.SetActive(false);
        this.SetTempLocation(this.m_Str[11]);
        ((Behaviour) this.m_TeamLocText).enabled = true;
        ((Behaviour) this.m_TeamLocLine).enabled = true;
        ((Behaviour) this.m_TeamReturnText).enabled = false;
        ((Behaviour) this.m_TeamTargetText).enabled = true;
      }
      else if (lineFlag >= EMarchEventType.EMET_RallyStanby && lineFlag <= EMarchEventType.EMET_DeliverMarching)
      {
        ((Component) this.m_TeamRetureBtn).gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-105f, -251f);
        this.m_TeamSpeedBtnGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(30f, -251f);
        ((Component) this.m_TeamRetureBtn).gameObject.SetActive(true);
        this.m_TeamSpeedBtnGameObject.SetActive(true);
        this.SetTempLocation(this.m_Str[11]);
        ((Behaviour) this.m_TeamLocText).enabled = true;
        ((Behaviour) this.m_TeamLocLine).enabled = true;
        ((Behaviour) this.m_TeamReturnText).enabled = false;
        ((Behaviour) this.m_TeamTargetText).enabled = true;
        if (lineFlag == EMarchEventType.EMET_RallyAttack || lineFlag == EMarchEventType.EMET_RallyStanby)
        {
          ((Component) this.m_TeamRetureBtn).gameObject.SetActive(false);
          this.m_TeamSpeedBtnGameObject.SetActive(false);
        }
        else if (lineFlag == EMarchEventType.EMET_RallyMarching)
        {
          this.m_TeamSpeedBtnGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-39f, -251f);
          ((Component) this.m_TeamRetureBtn).gameObject.SetActive(false);
          this.m_TeamSpeedBtnGameObject.SetActive(true);
        }
      }
      else if (lineFlag >= EMarchEventType.EMET_AttackReturn && lineFlag <= EMarchEventType.EMET_HitMonsterRetreat)
      {
        ((Component) this.m_TeamRetureBtn).gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-39f, -251f);
        this.m_TeamSpeedBtnGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-39f, -251f);
        ((Component) this.m_TeamRetureBtn).gameObject.SetActive(false);
        long num = DataManager.Instance.ServerTime - (long) DataManager.MapDataController.MapLineTable[this.m_MapPointID].begin;
        this.m_TeamSpeedBtnGameObject.SetActive(!this.IsAttackActionLineFlag((byte) lineFlag) || num > 5L);
        ((Behaviour) this.m_TeamLocText).enabled = false;
        ((Behaviour) this.m_TeamLocLine).enabled = false;
        ((Behaviour) this.m_TeamReturnText).enabled = true;
        ((Behaviour) this.m_TeamTargetText).enabled = false;
      }
    }
    else
    {
      ((Component) this.m_TeamRetureBtn).gameObject.SetActive(false);
      this.m_TeamSpeedBtnGameObject.SetActive(false);
      if (GameConstants.IsPetSkillLine(this.m_MapPointID))
      {
        ((Component) this.m_TeamRetureBtn).gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-105f, -251f);
        this.m_TeamSpeedBtnGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(30f, -251f);
        this.SetTempLocation(this.m_Str[11]);
        ((Behaviour) this.m_TeamLocText).enabled = true;
        ((Behaviour) this.m_TeamLocLine).enabled = true;
        ((Behaviour) this.m_TeamReturnText).enabled = false;
        ((Behaviour) this.m_TeamTargetText).enabled = true;
      }
      else if (lineFlag >= EMarchEventType.EMET_AttackMarching && lineFlag <= EMarchEventType.EMET_DeliverMarching)
      {
        this.SetTempLocation(this.m_Str[11]);
        ((Graphic) this.m_TeamLocText).color = new Color(1f, 0.93f, 0.619f, 1f);
        ((Behaviour) this.m_TeamLocText).enabled = true;
        ((Behaviour) this.m_TeamLocLine).enabled = true;
        ((Behaviour) this.m_TeamReturnText).enabled = false;
        ((Behaviour) this.m_TeamTargetText).enabled = true;
      }
      else if (lineFlag >= EMarchEventType.EMET_AttackReturn && lineFlag <= EMarchEventType.EMET_HitMonsterRetreat)
      {
        this.SetTempLocation(this.m_Str[11]);
        ((Behaviour) this.m_TeamLocText).enabled = false;
        ((Behaviour) this.m_TeamLocLine).enabled = false;
        ((Behaviour) this.m_TeamReturnText).enabled = true;
        ((Behaviour) this.m_TeamTargetText).enabled = false;
      }
    }
    if (lineFlag == EMarchEventType.EMET_RallyAttack && DataManager.MapDataController.MapLineTable[this.m_MapPointID].allianceTag != null && DataManager.MapDataController.MapLineTable[this.m_MapPointID].allianceTag.Length != 0 && DataManager.CompareStr(DataManager.MapDataController.MapLineTable[this.m_MapPointID].allianceTag, DataManager.Instance.RoleAlliance.Tag) == 0)
    {
      this.m_TeamSpeedBtnGameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-39f, -251f);
      this.m_TeamSpeedBtnGameObject.SetActive(true);
    }
    if (this.SetExpressionButton(this.OwnerKind, POINT_KIND.PK_UNDEFINED))
      return;
    GUIManager.Instance.UpdateUI(EGUIWindow.UIEmojiSelect, 3);
  }

  public void UpdateUIData(int MapPointID, bool bDisbaleColor = false)
  {
    Vector2 zero = Vector2.zero;
    ushort pointIDorLevel = 0;
    int length = DataManager.MapDataController.ResourcesPointTable.Length;
    if ((Object) this.TileMapMat == (Object) null)
    {
      this.TileMapMat = Object.Instantiate((Object) ((MaskableGraphic) this.m_Door.TileMapController.TileSprites.m_Image).material) as Material;
      this.TileMapMat.renderQueue = 3000;
    }
    POINT_KIND mapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) MapPointID);
    if (mapInfoPointKind == POINT_KIND.PK_DYNAMIC_OBSTACLE)
      return;
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[MapPointID];
    this.m_PanelGameObject.SetActive(true);
    this.m_TeamPanelGameObject.SetActive(false);
    ((Component) this.m_GroundPanel).gameObject.SetActive(false);
    ((Component) this.m_ResourcePanel).gameObject.SetActive(false);
    if (mapInfoPointKind != POINT_KIND.PK_CITY && mapInfoPointKind != POINT_KIND.PK_CAMP)
      ((Component) this.m_CampPanel).gameObject.SetActive(false);
    if (mapInfoPointKind != POINT_KIND.PK_YOLK)
      ((Component) this.m_WondersPanel).gameObject.SetActive(false);
    if (!this.IsNpcCastleType(mapInfoPointKind, mapPoint.tableID))
      ((Component) this.m_NpcCastlePanel).gameObject.SetActive(false);
    this.SetOwnerKind();
    ((Component) this.m_ButtonRect6).gameObject.SetActive(false);
    ((Component) this.m_ButtonRect7).gameObject.SetActive(false);
    ((Component) this.m_ButtonRect8).gameObject.SetActive(false);
    ((Component) this.m_ButtonRect9).gameObject.SetActive(false);
    ((Component) this.m_ButtonRect10).gameObject.SetActive(false);
    ((Component) this.m_ButtonRect11).gameObject.SetActive(false);
    zero.Set(121f, -170f);
    this.m_ButtonRect2.anchoredPosition = zero;
    zero.Set(295f, -170f);
    this.m_ButtonRect3.anchoredPosition = zero;
    ((Component) this.m_BookmarkBtn).gameObject.SetActive(true);
    ((Behaviour) this.m_LocationText).enabled = true;
    ((Component) this.m_ChatBtnRt).gameObject.SetActive(true);
    ((Transform) ((Graphic) this.m_BGIcon).rectTransform).localScale = new Vector3(0.7f, 0.7f, 0.7f);
    if (GUIManager.Instance.IsArabic && (Object) ((Component) this.m_BGIcon).gameObject.GetComponent<ArabicItemTextureRot>() == (Object) null)
      ((Component) this.m_BGIcon).gameObject.AddComponent<ArabicItemTextureRot>();
    this.SetCityOutwardLevel((byte) 0);
    POINT_KIND pointKind = mapInfoPointKind;
    switch (pointKind)
    {
      case POINT_KIND.PK_CITY:
        if (this.GetCastleType(mapPoint.tableID) == CITY_PROPERTY.CP_NPC)
        {
          this.SetNpcCastle(MapPointID, bDisbaleColor);
          break;
        }
        this.SetPlayerCastle(MapPointID, bDisbaleColor);
        break;
      case POINT_KIND.PK_CAMP:
        if ((int) mapPoint.tableID < length)
          pointIDorLevel = (ushort) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].level;
        this.m_eGroundInfoKind = EGroundInfoKind.Camp;
        this.m_Door.TileMapController.getTileMapSprite(ref this.m_BGIcon, mapInfoPointKind, (int) pointIDorLevel);
        ((MaskableGraphic) this.m_BGIcon).material = this.TileMapMat;
        this.m_BGIcon.SetNativeSize();
        ((Behaviour) this.m_BGIconMask).enabled = false;
        ((Component) this.m_CampPanel).gameObject.SetActive(true);
        ((Component) this.m_WondersPanel).gameObject.SetActive(false);
        ((Component) this.m_NpcCastlePanel).gameObject.SetActive(false);
        zero.Set(416f, 441f);
        this.m_Panel.sizeDelta = zero;
        zero.Set(35f, -124f);
        this.m_Panel.anchoredPosition = zero;
        zero.Set(377f, 126f);
        this.m_GroundTextBGRect.sizeDelta = zero;
        zero.Set(20f, -94f);
        this.m_GroundTextBGRect.anchoredPosition = zero;
        zero.Set(0.0f, -163f);
        this.m_LocationRt.anchoredPosition = zero;
        zero.Set(0.0f, -185f);
        this.m_ChatBtnRt.anchoredPosition = zero;
        this.m_GroundTitle.text = DataManager.Instance.mStringTable.GetStringByID(6305U);
        this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4535U);
        ((Component) this.m_ButtonRect1).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect2).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect3).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
        switch (this.OwnerKind)
        {
          case 1:
            ((Component) this.m_ButtonRect1).gameObject.SetActive(false);
            ((Component) this.m_ButtonRect2).gameObject.SetActive(true);
            ((Component) this.m_ButtonRect3).gameObject.SetActive(true);
            ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
            ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
            zero.Set(this.m_ButtonRect2.anchoredPosition.x, -250f);
            this.m_ButtonRect2.anchoredPosition = zero;
            zero.Set(this.m_ButtonRect3.anchoredPosition.x, -250f);
            this.m_ButtonRect3.anchoredPosition = zero;
            this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4538U);
            this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4544U);
            break;
          case 2:
            ((Component) this.m_ButtonRect1).gameObject.SetActive(true);
            ((Component) this.m_ButtonRect2).gameObject.SetActive(false);
            ((Component) this.m_ButtonRect3).gameObject.SetActive(false);
            ((Component) this.m_ButtonRect4).gameObject.SetActive(true);
            ((Component) this.m_ButtonRect5).gameObject.SetActive(true);
            zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
            this.m_ButtonRect1.anchoredPosition = zero;
            zero.Set(this.m_ButtonRect4.anchoredPosition.x, -309f);
            this.m_ButtonRect4.anchoredPosition = zero;
            zero.Set(this.m_ButtonRect5.anchoredPosition.x, -309f);
            this.m_ButtonRect5.anchoredPosition = zero;
            break;
          case 3:
            ((Component) this.m_ButtonRect1).gameObject.SetActive(true);
            ((Component) this.m_ButtonRect2).gameObject.SetActive(false);
            ((Component) this.m_ButtonRect3).gameObject.SetActive(false);
            ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
            ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
            zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
            this.m_ButtonRect1.anchoredPosition = zero;
            this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4535U);
            break;
        }
        this.SetCampInfo(this.m_MapPointID, this.OwnerKind, bDisbaleColor);
        break;
      case POINT_KIND.PK_YOLK:
        if ((int) mapPoint.tableID < length)
        {
          ushort level = (ushort) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].level;
        }
        this.m_eGroundInfoKind = EGroundInfoKind.Wonder;
        ((Component) this.m_WondersPanel).gameObject.SetActive(true);
        ((Component) this.m_CampPanel).gameObject.SetActive(false);
        zero.Set(416f, 441f);
        this.m_Panel.sizeDelta = zero;
        zero.Set(0.0f, -124f);
        this.m_Panel.anchoredPosition = zero;
        zero.Set(377f, 126f);
        this.m_GroundTextBGRect.sizeDelta = zero;
        zero.Set(20f, -94f);
        this.m_GroundTextBGRect.anchoredPosition = zero;
        zero.Set(0.0f, -163f);
        this.m_LocationRt.anchoredPosition = zero;
        zero.Set(0.0f, -185f);
        this.m_ChatBtnRt.anchoredPosition = zero;
        this.m_GroundTitle.text = string.Empty;
        ((Behaviour) this.m_BGIconMask).enabled = false;
        this.SetWondersInfo(this.m_MapPointID, bDisbaleColor);
        this.m_BGIcon.SetNativeSize();
        ((Transform) ((Graphic) this.m_BGIcon).rectTransform).localScale = new Vector3(0.32f, 0.32f, 0.32f);
        break;
      default:
        if (pointKind == POINT_KIND.PK_NONE)
        {
          int num = 0;
          this.m_Door.TileMapController.getTileMapSprite(ref this.m_BGIcon, mapInfoPointKind, this.m_MapPointID);
          ((MaskableGraphic) this.m_BGIcon).material = this.TileMapMat;
          this.m_BGIcon.SetNativeSize();
          ((Behaviour) this.m_BGIconMask).enabled = true;
          this.m_eGroundInfoKind = EGroundInfoKind.Ground;
          zero.Set(377f, 126f);
          this.m_GroundTextBGRect.sizeDelta = zero;
          zero.Set(20f, -8f);
          this.m_GroundTextBGRect.anchoredPosition = zero;
          zero.Set(0.0f, -79f);
          this.m_LocationRt.anchoredPosition = zero;
          zero.Set(0.0f, -105f);
          this.m_ChatBtnRt.anchoredPosition = zero;
          if (this.m_MapPointID >= 0 && this.m_MapPointID < this.m_Door.TileMapController.TileMapInfo.Length)
            num = (int) this.m_Door.TileMapController.TileMapInfo[this.m_MapPointID];
          this.m_GroundTitle.text = this.GetPKNoneGroundTitle(this.m_MapPointID);
          ((Component) this.m_ButtonRect1).gameObject.SetActive(false);
          ((Component) this.m_ButtonRect2).gameObject.SetActive(true);
          ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
          ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
          this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4512U);
          this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4511U);
          ((Component) this.m_GroundPanel).gameObject.SetActive(true);
          this.m_Str[10].ClearString();
          this.m_Str[31].ClearString();
          DataManager.MapDataController.GetKingdomName(DataManager.MapDataController.FocusKingdomID, ref this.m_Str[31]);
          StringManager.Instance.StringToFormat(this.m_Str[31]);
          this.m_Str[10].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(802U));
          this.m_GroundText.text = this.m_Str[10].ToString();
          this.m_GroundText.SetAllDirty();
          this.m_GroundText.cachedTextGenerator.Invalidate();
          zero.Set(416f, 267f);
          this.m_Panel.sizeDelta = zero;
          if (this.m_Door.TileMapController.CheckObstacle(MapPointID))
          {
            ((Component) this.m_ButtonRect3).gameObject.SetActive(false);
            ((Component) this.m_ButtonRect2).gameObject.SetActive(false);
          }
          else
          {
            ((Component) this.m_ButtonRect3).gameObject.SetActive(true);
            ((Component) this.m_ButtonRect2).gameObject.SetActive(true);
            this.m_ButtonRect2.anchoredPosition = new Vector2(121f, this.m_ButtonRect3.anchoredPosition.y);
          }
          ((Component) this.m_ResourcePanel).gameObject.SetActive(false);
          ((Component) this.m_GroundText).gameObject.SetActive(true);
          if (GameConstants.IsBetween(num, 109, 112))
          {
            this.m_eGroundInfoKind = EGroundInfoKind.WonderForest;
            this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(851U);
            this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4512U);
            this.m_GroundText.text = DataManager.Instance.mStringTable.GetStringByID(850U);
            this.m_GroundText.SetAllDirty();
            this.m_GroundText.cachedTextGenerator.Invalidate();
            break;
          }
          if (GameConstants.IsBetween(num, 99, 108))
          {
            this.m_GroundText.text = DataManager.Instance.mStringTable.GetStringByID(855U);
            this.m_GroundText.SetAllDirty();
            this.m_GroundText.cachedTextGenerator.Invalidate();
            break;
          }
          break;
        }
        if ((int) mapPoint.tableID < length)
          pointIDorLevel = (ushort) DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].level;
        this.m_ResStartTime = this.GetResStartTime(this.m_MapPointID);
        this.m_ResTotalCount = DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].count;
        this.m_ResRate = DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].rate;
        this.m_MaxOverload = this.GetMaxOverload(this.m_MapPointID);
        this.m_MaxOverload = (uint) Mathf.Clamp((float) this.m_MaxOverload, 0.0f, (float) this.m_ResTotalCount);
        this.m_Door.TileMapController.getTileMapSprite(ref this.m_BGIcon, mapInfoPointKind, (int) pointIDorLevel);
        ((MaskableGraphic) this.m_BGIcon).material = this.TileMapMat;
        this.m_BGIcon.SetNativeSize();
        ((Behaviour) this.m_BGIconMask).enabled = false;
        this.m_Str[4].ClearString();
        if (DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].allianceTag.Length != 0)
        {
          if ((int) DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].kingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID && DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].kingdomID != (ushort) 0)
            GameConstants.FormatRoleName(this.m_Str[4], DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].playerName, DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].allianceTag, bCheckedNickname: (byte) 0, KingdomID: DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].kingdomID);
          else
            GameConstants.FormatRoleName(this.m_Str[4], DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].playerName, DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].allianceTag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
        }
        else if ((int) DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].kingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID && DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].kingdomID != (ushort) 0)
        {
          GameConstants.FormatRoleName(this.m_Str[4], DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].playerName, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
        }
        else
        {
          StringManager.Instance.StringToFormat(DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].playerName);
          this.m_Str[4].AppendFormat("{0}");
        }
        this.m_ResourceOwnerText.text = this.m_Str[4].ToString();
        switch (mapInfoPointKind)
        {
          case POINT_KIND.PK_FOOD:
            this.sb.Length = 0;
            this.sb.AppendFormat("{0} {1}{2}", (object) DataManager.Instance.mStringTable.GetStringByID(6306U), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) pointIDorLevel);
            this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4525U);
            this.m_GroundTitle.text = this.sb.ToString();
            this.m_ResourceIcon.sprite = this.m_SpriteArray.GetSprite(0);
            this.m_ResourceIcon.SetNativeSize();
            this.m_ResType = (byte) 1;
            ((Component) this.m_InformationBtn).gameObject.SetActive(true);
            break;
          case POINT_KIND.PK_STONE:
            this.sb.Length = 0;
            this.sb.AppendFormat("{0} {1}{2}", (object) DataManager.Instance.mStringTable.GetStringByID(6308U), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) pointIDorLevel);
            this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4526U);
            this.m_GroundTitle.text = this.sb.ToString();
            this.m_ResourceIcon.sprite = this.m_SpriteArray.GetSprite(1);
            this.m_ResourceIcon.SetNativeSize();
            this.m_ResType = (byte) 2;
            ((Component) this.m_InformationBtn).gameObject.SetActive(true);
            break;
          case POINT_KIND.PK_IRON:
            this.sb.Length = 0;
            this.sb.AppendFormat("{0} {1}{2}", (object) DataManager.Instance.mStringTable.GetStringByID(6307U), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) pointIDorLevel);
            this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4527U);
            this.m_GroundTitle.text = this.sb.ToString();
            this.m_ResourceIcon.sprite = this.m_SpriteArray.GetSprite(2);
            this.m_ResourceIcon.SetNativeSize();
            this.m_ResType = (byte) 3;
            ((Component) this.m_InformationBtn).gameObject.SetActive(true);
            break;
          case POINT_KIND.PK_WOOD:
            this.sb.Length = 0;
            this.sb.AppendFormat("{0} {1}{2}", (object) DataManager.Instance.mStringTable.GetStringByID(6309U), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) pointIDorLevel);
            this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4524U);
            this.m_GroundTitle.text = this.sb.ToString();
            this.m_ResourceIcon.sprite = this.m_SpriteArray.GetSprite(3);
            this.m_ResourceIcon.SetNativeSize();
            this.m_ResType = (byte) 4;
            ((Component) this.m_InformationBtn).gameObject.SetActive(true);
            break;
          case POINT_KIND.PK_GOLD:
            this.sb.Length = 0;
            this.sb.AppendFormat("{0} {1}{2}", (object) DataManager.Instance.mStringTable.GetStringByID(6311U), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) pointIDorLevel);
            this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4528U);
            this.m_GroundTitle.text = this.sb.ToString();
            this.m_ResourceIcon.sprite = this.m_SpriteArray.GetSprite(4);
            this.m_ResourceIcon.SetNativeSize();
            this.m_ResType = (byte) 5;
            ((Component) this.m_InformationBtn).gameObject.SetActive(false);
            break;
          case POINT_KIND.PK_CRYSTAL:
            this.sb.Length = 0;
            this.sb.AppendFormat("{0} {1}{2}", (object) DataManager.Instance.mStringTable.GetStringByID(6310U), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) pointIDorLevel);
            this.m_ResourceProductionTitle.text = DataManager.Instance.mStringTable.GetStringByID(4529U);
            this.m_GroundTitle.text = this.sb.ToString();
            this.m_ResourceIcon.sprite = this.m_SpriteArray.GetSprite(5);
            this.m_ResourceIcon.SetNativeSize();
            this.m_ResType = (byte) 6;
            ((Component) this.m_InformationBtn).gameObject.SetActive(true);
            break;
        }
        this.m_eGroundInfoKind = EGroundInfoKind.Resource;
        zero.Set(377f, 126f);
        this.m_GroundTextBGRect.sizeDelta = zero;
        zero.Set(20f, -47f);
        this.m_GroundTextBGRect.anchoredPosition = zero;
        zero.Set(0.0f, -140f);
        this.m_LocationRt.anchoredPosition = zero;
        zero.Set(0.0f, -165f);
        this.m_ChatBtnRt.anchoredPosition = zero;
        ((Component) this.m_GroundText).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect1).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect2).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect3).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
        ((Component) this.m_ValueBar1).gameObject.SetActive(false);
        ((Component) this.m_ValueBar2).gameObject.SetActive(false);
        this.m_ResourceText.text = DataManager.Instance.mStringTable.GetStringByID(4565U);
        this.m_ResourceProductionText.text = this.m_ResTotalCount.ToString("N0");
        this.m_SliderText1.text = DataManager.Instance.mStringTable.GetStringByID(4590U);
        switch (this.OwnerKind)
        {
          case 0:
            zero.Set(this.m_ButtonRect1.anchoredPosition.x, -203f);
            this.m_ButtonRect1.anchoredPosition = zero;
            this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(706U);
            this.m_ResourceOwnerText.text = DataManager.Instance.mStringTable.GetStringByID(4576U);
            ((Graphic) this.m_ResourceOwnerText).color = new Color(1f, 0.443f, 0.443f);
            break;
          case 1:
            if (this.m_ResType == (byte) 6)
            {
              zero.Set(43f, -185f);
              this.m_ValueBar1.anchoredPosition = zero;
              zero.Set(43f, -216f);
              this.m_ValueBar2.anchoredPosition = zero;
              ((Component) this.m_ValueBar1).gameObject.SetActive(true);
              ((Component) this.m_ValueBar2).gameObject.SetActive(true);
            }
            else
            {
              zero.Set(43f, -208f);
              this.m_ValueBar2.anchoredPosition = zero;
              ((Component) this.m_ValueBar2).gameObject.SetActive(true);
            }
            zero.Set(this.m_ButtonRect1.anchoredPosition.x, -275f);
            this.m_ButtonRect1.anchoredPosition = zero;
            this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4538U);
            ((Graphic) this.m_ResourceOwnerText).color = new Color(0.807f, 1f, 0.713f);
            break;
          case 2:
            zero.Set(this.m_ButtonRect1.anchoredPosition.x, -203f);
            this.m_ButtonRect1.anchoredPosition = zero;
            zero.Set(this.m_ButtonRect4.anchoredPosition.x, -262f);
            this.m_ButtonRect4.anchoredPosition = zero;
            zero.Set(this.m_ButtonRect5.anchoredPosition.x, -262f);
            this.m_ButtonRect5.anchoredPosition = zero;
            ((Component) this.m_ButtonRect4).gameObject.SetActive(true);
            ((Component) this.m_ButtonRect5).gameObject.SetActive(true);
            this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4535U);
            ((Graphic) this.m_ResourceOwnerText).color = new Color(0.807f, 1f, 0.713f);
            break;
          case 3:
            zero.Set(this.m_ButtonRect1.anchoredPosition.x, -203f);
            this.m_ButtonRect1.anchoredPosition = zero;
            ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
            ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
            this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4535U);
            ((Graphic) this.m_ResourceOwnerText).color = new Color(0.807f, 1f, 0.713f);
            break;
        }
        zero.Set(416f, 394f);
        this.m_Panel.sizeDelta = zero;
        ((Component) this.m_ResourcePanel).gameObject.SetActive(true);
        this.m_TimeTick = 1f;
        this.UpdateResourceInfo();
        break;
    }
    bool bLocalKindom = (int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
    this.SetButtonColor(mapInfoPointKind, bLocalKindom);
    if (this.SetExpressionButton(this.OwnerKind, mapInfoPointKind))
      return;
    GUIManager.Instance.UpdateUI(EGUIWindow.UIEmojiSelect, 3);
  }

  public void UpdateUIData_None(int MapPointID)
  {
    int num = 0;
    Vector2 zero = Vector2.zero;
    if ((Object) this.TileMapMat == (Object) null)
    {
      this.TileMapMat = Object.Instantiate((Object) ((MaskableGraphic) this.m_Door.TileMapController.TileSprites.m_Image).material) as Material;
      this.TileMapMat.renderQueue = 3000;
    }
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[MapPointID];
    this.m_Door.TileMapController.getTileMapSprite(ref this.m_BGIcon, POINT_KIND.PK_NONE, this.m_MapPointID);
    ((MaskableGraphic) this.m_BGIcon).material = this.TileMapMat;
    this.m_BGIcon.SetNativeSize();
    ((Behaviour) this.m_BGIconMask).enabled = true;
    if (this.m_MapPointID >= 0 && this.m_MapPointID < this.m_Door.TileMapController.TileMapInfo.Length)
      num = (int) this.m_Door.TileMapController.TileMapInfo[this.m_MapPointID];
    this.m_GroundTitle.text = this.GetPKNoneGroundTitle(this.m_MapPointID);
    DataManager.MapDataController.GetKingdomName(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomID, ref this.m_Str[28]);
    StringManager.Instance.StringToFormat(this.m_Str[28]);
    this.m_Str[28].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4509U));
    this.m_GroundText.text = this.m_Str[28].ToString();
    this.m_eGroundInfoKind = EGroundInfoKind.Ground;
    zero.Set(377f, 126f);
    this.m_GroundTextBGRect.sizeDelta = zero;
    zero.Set(20f, -8f);
    this.m_GroundTextBGRect.anchoredPosition = zero;
    zero.Set(0.0f, -79f);
    this.m_LocationRt.anchoredPosition = zero;
    zero.Set(0.0f, -105f);
    this.m_ChatBtnRt.anchoredPosition = zero;
    zero.Set(416f, 267f);
    this.m_Panel.sizeDelta = zero;
    ((Component) this.m_BookmarkBtn).gameObject.SetActive(false);
    ((Behaviour) this.m_LocationText).enabled = false;
    ((Component) this.m_ChatBtnRt).gameObject.SetActive(false);
    ((Component) this.m_ButtonRect1).gameObject.SetActive(false);
    ((Component) this.m_ButtonRect2).gameObject.SetActive(false);
    ((Component) this.m_ButtonRect3).gameObject.SetActive(false);
    ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
    ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
    ((Component) this.m_ButtonRect10).gameObject.SetActive(false);
    ((Component) this.m_ButtonRect11).gameObject.SetActive(false);
    this.m_PanelGameObject.SetActive(true);
    this.m_TeamPanelGameObject.SetActive(false);
    ((Component) this.m_GroundPanel).gameObject.SetActive(true);
    ((Component) this.m_ResourcePanel).gameObject.SetActive(false);
    ((Component) this.m_CampPanel).gameObject.SetActive(false);
    ((Component) this.m_WondersPanel).gameObject.SetActive(false);
    ((Component) this.m_NpcCastlePanel).gameObject.SetActive(false);
    this.SetCityOutwardLevel((byte) 0);
    this.SetExpressionButton(this.OwnerKind, POINT_KIND.PK_NONE);
  }

  public void Open(int MapPointID, POINT_KIND infoKind = POINT_KIND.PK_MAX)
  {
    this.m_TimeTick = 1f;
    Vector2 zero = Vector2.zero;
    Vector2 vector2 = infoKind != POINT_KIND.PK_YOLK ? GameConstants.getTileMapPosbySpriteID(MapPointID) : DataManager.MapDataController.GetYolkPos(DataManager.MapDataController.LayoutMapInfo[MapPointID].tableID, DataManager.MapDataController.FocusKingdomID);
    this.m_Str[8].ClearString();
    StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4504U));
    StringManager.Instance.IntToFormat((long) DataManager.MapDataController.FocusKingdomID);
    StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4505U));
    StringManager.Instance.IntToFormat((long) (int) vector2.x);
    StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4506U));
    StringManager.Instance.IntToFormat((long) (int) vector2.y);
    if (GUIManager.Instance.IsArabic)
      this.m_Str[8].AppendFormat("{5}{4} {3}{2} {1}{0}");
    else
      this.m_Str[8].AppendFormat("{0}{1} {2}{3} {4}{5}");
    this.m_LocationText.text = this.m_Str[8].ToString();
    this.m_LocationText.SetAllDirty();
    this.m_LocationText.cachedTextGenerator.Invalidate();
    this.m_MapPointID = MapPointID;
    this.m_infoKind = infoKind;
    switch (infoKind)
    {
      case POINT_KIND.PK_NONE:
        this.UpdateUIData_None(MapPointID);
        break;
      case POINT_KIND.PK_UNDEFINED:
        this.UpdateTeamData();
        break;
      default:
        MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[MapPointID];
        this.UpdateUIData(MapPointID, true);
        this.m_PreKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) MapPointID);
        if (DataManager.MapDataController.IsCityOrCamp((uint) MapPointID) || this.m_PreKind == POINT_KIND.PK_YOLK)
          this.RequsetAdvanceMapdata(this.m_MapPointID);
        if (DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) MapPointID) == POINT_KIND.PK_CITY)
        {
          this.SetNegativePetSkillBtn();
          break;
        }
        break;
    }
    this.bGroundInfoOpen = true;
  }

  private void SetWondersInfo(int _MapPointID, bool bDisbaleColor = false)
  {
    Vector2 zero = Vector2.zero;
    if (this.bRequsetAdvanceMapdata)
      bDisbaleColor = this.bRequsetAdvanceMapdata;
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[_MapPointID];
    if ((int) mapPoint.tableID >= DataManager.MapDataController.YolkPointTable.Length)
      return;
    MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int) mapPoint.tableID];
    if (mapYolk.WonderState == (byte) 2)
      this.Close();
    if ((Object) this.m_Door.TileMapController != (Object) null && this.m_Door.TileMapController.yolk != null)
    {
      if (mapYolk.WonderID == (byte) 0)
      {
        if ((Object) this.WonderTileMapMat1 == (Object) null)
        {
          this.WonderTileMapMat1 = Object.Instantiate((Object) this.m_Door.TileMapController.yolk.getMapTileYolkMaterial(mapYolk.WonderID)) as Material;
          this.WonderTileMapMat1.renderQueue = 3000;
        }
        ((MaskableGraphic) this.m_BGIcon).material = this.WonderTileMapMat1;
      }
      else
      {
        if ((Object) this.WonderTileMapMat2 == (Object) null)
        {
          this.WonderTileMapMat2 = Object.Instantiate((Object) this.m_Door.TileMapController.yolk.getMapTileYolkMaterial(mapYolk.WonderID)) as Material;
          this.WonderTileMapMat2.renderQueue = 3000;
        }
        ((MaskableGraphic) this.m_BGIcon).material = this.WonderTileMapMat2;
      }
      this.m_BGIcon.sprite = this.m_Door.TileMapController.yolk.getMapTileYolkSprite(mapYolk.WonderID);
      ((Graphic) this.m_BGIcon).color = new Color(1f, 1f, 1f, 1f);
    }
    if (this.OwnerKind == 2)
    {
      if (mapYolk.WonderState == (byte) 0)
        this.SetGroundInfoBtnState(UIGroundInfo.BtnState.WondersInfo_NA_Peace);
      else if (mapYolk.WonderState == (byte) 1)
        this.SetGroundInfoBtnState(UIGroundInfo.BtnState.WondersInfo_NA_Fight);
    }
    else if (this.OwnerKind == 3)
    {
      if (mapYolk.WonderState == (byte) 0)
        this.SetGroundInfoBtnState(UIGroundInfo.BtnState.WondersInfo_Ally_Peace);
      else if (mapYolk.WonderState == (byte) 1)
        this.SetGroundInfoBtnState(UIGroundInfo.BtnState.WondersInfo_Ally_Fight);
    }
    else if (this.OwnerKind == 1)
    {
      if (mapYolk.WonderState == (byte) 0)
        this.SetGroundInfoBtnState(UIGroundInfo.BtnState.WondersInfo_Army_Peace);
      else if (mapYolk.WonderState == (byte) 1)
        this.SetGroundInfoBtnState(UIGroundInfo.BtnState.WondersInfo_Army_Fight);
    }
    else if (this.OwnerKind == 4)
      this.SetGroundInfoBtnState(UIGroundInfo.BtnState.WondersInfo_NoAllIance);
    this.m_WonderID.text = DataManager.MapDataController.GetYolkName((ushort) mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID).ToString();
    if (mapYolk.WonderState == (byte) 0)
    {
      this.m_WonderState.text = DataManager.Instance.mStringTable.GetStringByID(7232U);
      ((Graphic) this.m_WonderState).color = new Color(0.207f, 0.968f, 0.423f, 1f);
      ((Graphic) this.m_WonderTime).color = new Color(0.207f, 0.968f, 0.423f, 1f);
      ((Component) this.m_WonderStateImage1).gameObject.SetActive(true);
      ((Component) this.m_WonderStateImage2).gameObject.SetActive(false);
      ((Component) this.m_WonderStateImage3).gameObject.SetActive(false);
      if (this.IsInWorldWarSelf())
        this.m_WonderTimeTF.gameObject.SetActive(false);
      else
        this.m_WonderTimeTF.gameObject.SetActive(true);
    }
    else if (mapYolk.WonderState == (byte) 1)
    {
      this.m_WonderTimeTF.gameObject.SetActive(true);
      if (this.IsInKvk(true) && !this.IsInWorldWarSelf())
      {
        ((Component) this.m_WonderStateImage1).gameObject.SetActive(false);
        ((Component) this.m_WonderStateImage2).gameObject.SetActive(false);
        ((Component) this.m_WonderStateImage3).gameObject.SetActive(true);
        this.m_WonderState.text = DataManager.Instance.mStringTable.GetStringByID(9373U);
        ((Graphic) this.m_WonderTime).color = new Color(1f, 0.788f, 0.439f, 1f);
        ((Graphic) this.m_WonderState).color = new Color(1f, 0.788f, 0.439f, 1f);
      }
      else
      {
        this.m_WonderState.text = DataManager.Instance.mStringTable.GetStringByID(7233U);
        ((Graphic) this.m_WonderState).color = new Color(1f, 0.227f, 0.333f, 1f);
        ((Graphic) this.m_WonderTime).color = new Color(1f, 0.227f, 0.333f, 1f);
        ((Component) this.m_WonderStateImage2).gameObject.SetActive(true);
        ((Component) this.m_WonderStateImage1).gameObject.SetActive(false);
        ((Component) this.m_WonderStateImage3).gameObject.SetActive(false);
      }
    }
    this.m_WonderAlliance.text = mapYolk.OwnerAllianceName.ToString();
    CString str = StringManager.Instance.StaticString1024();
    str.ClearString();
    DataManager.MapDataController.GetKingdomName(DataManager.MapDataController.FocusKingdomID, ref str);
    this.m_Str[40].ClearString();
    if ((int) DataManager.MapDataController.kingdomData.kingdomID == (int) DataManager.MapDataController.FocusKingdomID)
    {
      this.m_Str[40].StringToFormat(str);
      this.m_Str[40].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4509U));
    }
    else
    {
      this.m_Str[40].IntToFormat((long) DataManager.MapDataController.FocusKingdomID);
      this.m_Str[40].StringToFormat(str);
      this.m_Str[40].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9906U));
    }
    this.m_WonderKingdom.text = this.m_Str[40].ToString();
    ((Graphic) this.m_WonderKingdom).color = Color.white;
    if (mapYolk.WonderAllianceTag.Length == 0)
    {
      GUIManager.Instance.ChangeWonderImg(((Component) this.m_WonderHIBtn).transform, mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID);
      ((Component) this.m_WonderHIBtn).gameObject.SetActive(true);
      this.m_WonderAllianeIcon.gameObject.SetActive(false);
      ((Component) this.m_WonderAllianeFrame).gameObject.SetActive(false);
    }
    else
    {
      GUIManager.Instance.SetBadgeTotemImg(this.m_WonderAllianeIcon, mapYolk.OwnerEmblem);
      ((Component) this.m_WonderHIBtn).gameObject.SetActive(false);
      this.m_WonderAllianeIcon.gameObject.SetActive(true);
      ((Component) this.m_WonderAllianeFrame).gameObject.SetActive(true);
    }
    if (mapYolk.WonderLeader[0] == char.MinValue)
    {
      bool flag = (int) DataManager.MapDataController.FocusKingdomID == (int) ActivityManager.Instance.KOWKingdomID;
      this.m_Str[39].ClearString();
      if (flag)
      {
        this.m_Str[39].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(245U));
        if (mapYolk.WonderID > (byte) 0)
        {
          if (mapYolk.WonderState == (byte) 0)
            this.m_Str[39].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11156U));
          else
            this.m_Str[39].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11037U));
        }
        else if (mapYolk.WonderState == (byte) 0)
          this.m_Str[39].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11036U));
        else
          this.m_Str[39].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11037U));
      }
      else
      {
        this.m_Str[39].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(245U));
        this.m_Str[39].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7230U));
      }
      this.m_WonderOwner.text = this.m_Str[39].ToString();
    }
    else
    {
      this.m_Str[39].ClearString();
      if (mapYolk.WonderAllianceTag != null)
        this.SetWonderOwnerText_WorldWar(this.m_Str[39], mapYolk);
      this.m_WonderOwner.text = this.m_Str[39].ToString();
    }
    this.m_Str[38].ClearString();
    if (mapYolk.OwnerAllianceName[0] == char.MinValue)
    {
      this.m_Str[38].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(245U));
      this.m_Str[38].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4600U));
    }
    else
    {
      CString cstring = StringManager.Instance.StaticString1024();
      CString Name = StringManager.Instance.StaticString1024();
      CString Tag = StringManager.Instance.StaticString1024();
      if ((int) DataManager.Instance.RoleAlliance.KingdomID == (int) mapYolk.AllianceKingdomID)
      {
        if (GUIManager.Instance.IsArabic)
        {
          Name.Append(mapYolk.OwnerAllianceName);
          Tag.Append(mapYolk.WonderAllianceTag);
          GUIManager.Instance.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, GUIManager.Instance.IsArabic);
          this.m_Str[38].StringToFormat(cstring);
          this.m_Str[38].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4543U));
        }
        else
        {
          this.m_Str[38].StringToFormat(mapYolk.WonderAllianceTag);
          this.m_Str[38].StringToFormat(mapYolk.OwnerAllianceName);
          this.m_Str[38].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4543U));
        }
      }
      else if (GUIManager.Instance.IsArabic)
      {
        Name.Append(mapYolk.OwnerAllianceName);
        Tag.Append(mapYolk.WonderAllianceTag);
        GUIManager.Instance.FormatRoleNameForChat(cstring, Name, Tag, mapYolk.AllianceKingdomID, GUIManager.Instance.IsArabic);
        this.m_Str[38].StringToFormat(cstring);
        this.m_Str[38].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9904U));
      }
      else
      {
        this.m_Str[38].IntToFormat((long) mapYolk.AllianceKingdomID);
        this.m_Str[38].StringToFormat(mapYolk.WonderAllianceTag);
        this.m_Str[38].StringToFormat(mapYolk.OwnerAllianceName);
        this.m_Str[38].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9904U));
      }
    }
    this.m_WonderAlliance.text = this.m_Str[38].ToString();
    if (bDisbaleColor)
    {
      ((Graphic) this.m_WonderAlliance).color = Color.gray;
      ((Graphic) this.m_WonderOwner).color = Color.gray;
    }
    else
    {
      ((Graphic) this.m_WonderAlliance).color = Color.white;
      ((Graphic) this.m_WonderOwner).color = Color.white;
    }
    this.m_WonderTime.text = DataManager.Instance.mStringTable.GetStringByID(9321U);
    this.m_WonderState.SetAllDirty();
    this.m_WonderState.cachedTextGenerator.Invalidate();
    this.m_WonderID.SetAllDirty();
    this.m_WonderID.cachedTextGenerator.Invalidate();
    this.m_WonderAlliance.SetAllDirty();
    this.m_WonderAlliance.cachedTextGenerator.Invalidate();
    this.m_WonderOwner.SetAllDirty();
    this.m_WonderOwner.cachedTextGenerator.Invalidate();
    this.m_WonderKingdom.SetAllDirty();
    this.m_WonderKingdom.cachedTextGenerator.Invalidate();
  }

  private void SetWonderTimeInfo(int _MapPointID)
  {
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[_MapPointID];
    if ((int) mapPoint.tableID >= DataManager.MapDataController.YolkPointTable.Length)
      return;
    MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int) mapPoint.tableID];
    if (mapYolk.StateBegin <= 0UL)
      return;
    ulong num = mapYolk.StateBegin + (ulong) mapYolk.StateDuring;
    if (num < (ulong) DataManager.Instance.ServerTime)
      return;
    uint sec = (uint) (num - (ulong) DataManager.Instance.ServerTime);
    this.m_Str[37].ClearString();
    GameConstants.GetTimeString(this.m_Str[37], sec);
    this.m_WonderTime.text = this.m_Str[37].ToString();
    this.m_WonderTime.SetAllDirty();
    this.m_WonderTime.cachedTextGenerator.Invalidate();
  }

  private bool CheckWonderArmy()
  {
    bool flag = false;
    uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
    if ((int) mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
    {
      byte wonderId = DataManager.MapDataController.YolkPointTable[(int) mapPoint.tableID].WonderID;
      if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID == (int) DataManager.MapDataController.FocusKingdomID)
      {
        for (int index = 0; (long) index < (long) effectBaseVal; ++index)
        {
          if (DataManager.Instance.MarchEventData[index].Type == EMarchEventType.EMET_Camp && DataManager.Instance.MarchEventData[index].PointKind == POINT_KIND.PK_YOLK)
          {
            Vector2 mapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(DataManager.Instance.MarchEventData[index].Point.zoneID, DataManager.Instance.MarchEventData[index].Point.pointID);
            if (DataManager.MapDataController.GetYolkPos((ushort) wonderId, (ushort) 0) == mapPosbyPointCode)
            {
              flag = true;
              break;
            }
          }
        }
      }
    }
    return flag;
  }

  private void SetCampInfo(int _MapPointID, int _OwnerType, bool bDisbaleColor = false)
  {
    Vector2 zero = Vector2.zero;
    if (this.bRequsetAdvanceMapdata)
      bDisbaleColor = this.bRequsetAdvanceMapdata;
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[_MapPointID];
    bool flag = DataManager.MapDataController.IsEnemy(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomID);
    if ((int) mapPoint.tableID >= DataManager.MapDataController.PlayerPointTable.Length)
      return;
    ushort portraitId = DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].portraitID;
    if (!bDisbaleColor)
    {
      if (portraitId >= (ushort) 1 && portraitId <= (ushort) 100)
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_CampHiBtn).transform, eHeroOrItem.Hero, portraitId, (byte) 11, (byte) 0);
      else
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_CampHiBtn).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 11, (byte) 0);
      ((Component) this.m_CampHiBtn).gameObject.SetActive(true);
    }
    else
      ((Component) this.m_CampHiBtn).gameObject.SetActive(false);
    if (DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomID == (ushort) 0)
    {
      zero.Set(this.m_IDTextRt.anchoredPosition.x, -68.5f);
      this.m_IDTextRt.anchoredPosition = this.m_IDText.ArabicFixPos(zero);
      ((Component) this.m_IDTextRt).gameObject.SetActive(true);
      ((Component) this.m_CampTitleTextRt).gameObject.SetActive(false);
    }
    else
    {
      zero.Set(this.m_CampTitleTextRt.anchoredPosition.x, -61f);
      this.m_CampTitleTextRt.anchoredPosition = zero;
      zero.Set(this.m_IDTextRt.anchoredPosition.x, -63f);
      this.m_IDTextRt.anchoredPosition = this.m_IDText.ArabicFixPos(zero);
      ((Component) this.m_IDTextRt).gameObject.SetActive(true);
      ((Component) this.m_CampTitleTextRt).gameObject.SetActive(true);
    }
    ((Component) this.m_CampTitleText).gameObject.SetActive(false);
    this.m_Str[30].ClearString();
    this.m_Str[30].IntToFormat((long) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].bounty, bNumber: true);
    this.m_Str[30].AppendFormat("{0}");
    this.m_RewardText.text = this.m_Str[30].ToString();
    this.m_RewardText.SetAllDirty();
    this.m_RewardText.cachedTextGenerator.Invalidate();
    this.m_Str[5].ClearString();
    if (flag)
    {
      if (DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag != null && DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag.Length > 0)
        GameConstants.FormatRoleName(this.m_Str[5], DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName, DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag, bCheckedNickname: (byte) 0, KingdomID: DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomID);
      else
        GameConstants.FormatRoleName(this.m_Str[5], DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName, bCheckedNickname: (byte) 0, KingdomID: DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomID);
    }
    else if (DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag != null && DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag.Length > 0)
    {
      GameConstants.FormatRoleName(this.m_Str[5], DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName, DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    }
    else
    {
      StringManager.Instance.StringToFormat(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].playerName);
      this.m_Str[5].AppendFormat("{0}");
    }
    this.m_IDText.text = this.m_Str[5].ToString();
    this.m_IDText.SetAllDirty();
    this.m_IDText.cachedTextGenerator.Invalidate();
    if (DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].VIP != (byte) 0)
    {
      this.m_Str[6].ClearString();
      this.m_VipText.alignment = TextAnchor.MiddleCenter;
      ((Graphic) this.m_VipText).color = new Color(1f, 0.941f, 0.639f);
      StringManager.Instance.IntToFormat((long) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].VIP);
      this.m_Str[6].AppendFormat("{0}");
      this.m_VipText.text = this.m_Str[6].ToString();
      this.m_VipTf.gameObject.SetActive(true);
    }
    else
      this.m_VipTf.gameObject.SetActive(false);
    if (DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceRank != (byte) 0)
    {
      this.m_RankImage.sprite = this.m_SpriteArray.GetSprite(5 + (int) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceRank);
      this.m_RankTf.gameObject.SetActive(true);
    }
    else
      this.m_RankTf.gameObject.SetActive(false);
    this.SetTitleIcon();
    this.m_Str[0].ClearString();
    StringManager.Instance.uLongToFormat(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].power, bNumber: true);
    this.m_Str[0].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4541U));
    this.m_StrengthText.text = this.m_Str[0].ToString();
    this.m_Str[1].ClearString();
    StringManager.Instance.uLongToFormat(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kill, bNumber: true);
    this.m_Str[1].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4542U));
    this.m_WipeOutText.text = this.m_Str[1].ToString();
    this.m_Str[2].ClearString();
    if (DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag.Length == 0)
    {
      StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(245U));
      this.m_Str[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4600U));
    }
    else
    {
      CString cstring = StringManager.Instance.StaticString1024();
      CString Name = StringManager.Instance.StaticString1024();
      CString Tag = StringManager.Instance.StaticString1024();
      if ((int) DataManager.Instance.RoleAlliance.KingdomID == (int) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceKingdomID)
      {
        if (GUIManager.Instance.IsArabic)
        {
          Name.Append(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceName);
          Tag.Append(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag);
          GUIManager.Instance.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, GUIManager.Instance.IsArabic);
          this.m_Str[2].StringToFormat(cstring);
          this.m_Str[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4543U));
        }
        else
        {
          StringManager.Instance.StringToFormat(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag);
          StringManager.Instance.StringToFormat(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceName);
          this.m_Str[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4543U));
        }
      }
      else if (GUIManager.Instance.IsArabic)
      {
        Name.Append(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceName);
        Tag.Append(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag);
        GUIManager.Instance.FormatRoleNameForChat(cstring, Name, Tag, DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceKingdomID, GUIManager.Instance.IsArabic);
        this.m_Str[2].StringToFormat(cstring);
        this.m_Str[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9904U));
      }
      else
      {
        this.m_Str[2].IntToFormat((long) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceKingdomID);
        this.m_Str[2].StringToFormat(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag);
        this.m_Str[2].StringToFormat(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceName);
        this.m_Str[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9904U));
      }
    }
    this.m_LeagueText.text = this.m_Str[2].ToString();
    this.m_Str[3].ClearString();
    if ((int) DataManager.MapDataController.kingdomData.kingdomID == (int) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomID)
    {
      DataManager.MapDataController.GetKingdomName(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomID, ref this.m_Str[28]);
      StringManager.Instance.StringToFormat(this.m_Str[28]);
      this.m_Str[3].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(4509U));
    }
    else
    {
      DataManager.MapDataController.GetKingdomName(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomID, ref this.m_Str[28]);
      StringManager.Instance.IntToFormat((long) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomID);
      StringManager.Instance.StringToFormat(this.m_Str[28]);
      this.m_Str[3].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9906U));
    }
    this.m_KingdomText.text = this.m_Str[3].ToString();
    if (bDisbaleColor)
    {
      ((Graphic) this.m_StrengthText).color = Color.gray;
      ((Graphic) this.m_WipeOutText).color = Color.gray;
      ((Graphic) this.m_LeagueText).color = Color.gray;
      ((Graphic) this.m_KingdomText).color = Color.gray;
    }
    else
    {
      Color white = Color.white;
      ((Graphic) this.m_StrengthText).color = white;
      ((Graphic) this.m_WipeOutText).color = white;
      ((Graphic) this.m_LeagueText).color = white;
      ((Graphic) this.m_KingdomText).color = white;
    }
    this.m_StrengthText.SetAllDirty();
    this.m_WipeOutText.SetAllDirty();
    this.m_LeagueText.SetAllDirty();
    this.m_KingdomText.SetAllDirty();
    this.m_VipText.SetAllDirty();
    this.m_RankText.SetAllDirty();
    this.m_StrengthText.cachedTextGenerator.Invalidate();
    this.m_WipeOutText.cachedTextGenerator.Invalidate();
    this.m_LeagueText.cachedTextGenerator.Invalidate();
    this.m_KingdomText.cachedTextGenerator.Invalidate();
    this.m_VipText.cachedTextGenerator.Invalidate();
    this.m_RankText.cachedTextGenerator.Invalidate();
  }

  public void SetChatText(int MapPointID)
  {
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
    ushort x = 0;
    byte num = 0;
    int length = DataManager.MapDataController.ResourcesPointTable.Length;
    if ((int) mapPoint.tableID < length)
      x = (ushort) DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].level;
    this.sb.Length = 0;
    this.m_Str[15].ClearString();
    switch (DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) this.m_MapPointID))
    {
      case POINT_KIND.PK_NONE:
        if (this.m_MapPointID >= 0 && this.m_MapPointID < this.m_Door.TileMapController.TileMapInfo.Length)
          num = this.m_Door.TileMapController.TileMapInfo[this.m_MapPointID];
        this.m_Str[15].StringToFormat(this.GetPKNoneGroundTitle(this.m_MapPointID));
        this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true));
        this.m_Str[15].AppendFormat("{0} {1}");
        break;
      case POINT_KIND.PK_FOOD:
        this.m_Str[15].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(6306U));
        this.m_Str[15].IntToFormat((long) x);
        this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true));
        this.m_Str[15].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(810U));
        break;
      case POINT_KIND.PK_STONE:
        this.m_Str[15].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(6308U));
        this.m_Str[15].IntToFormat((long) x);
        this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true));
        this.m_Str[15].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(810U));
        break;
      case POINT_KIND.PK_IRON:
        this.m_Str[15].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(6307U));
        this.m_Str[15].IntToFormat((long) x);
        this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true));
        this.m_Str[15].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(810U));
        break;
      case POINT_KIND.PK_WOOD:
        this.m_Str[15].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(6309U));
        this.m_Str[15].IntToFormat((long) x);
        this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true));
        this.m_Str[15].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(810U));
        break;
      case POINT_KIND.PK_GOLD:
        this.m_Str[15].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(6311U));
        this.m_Str[15].IntToFormat((long) x);
        this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true));
        this.m_Str[15].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(810U));
        break;
      case POINT_KIND.PK_CRYSTAL:
        this.m_Str[15].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(6310U));
        this.m_Str[15].IntToFormat((long) x);
        this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true));
        this.m_Str[15].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(810U));
        break;
      case POINT_KIND.PK_CITY:
        PlayerPoint playerPoint = DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID];
        if (this.IsNpcCastleType(POINT_KIND.PK_CITY, mapPoint.tableID))
        {
          CString tmpS = StringManager.Instance.StaticString1024();
          tmpS.IntToFormat((long) playerPoint.level);
          tmpS.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021U));
          this.m_Str[15].StringToFormat(tmpS);
          this.m_Str[15].StringToFormat(this.GetLocation(MapPointID));
          if (GUIManager.Instance.IsArabic)
          {
            this.m_Str[15].AppendFormat("{1} {0}");
            break;
          }
          this.m_Str[15].AppendFormat("{0} {1}");
          break;
        }
        if (playerPoint.allianceTag.Length != 0)
        {
          this.m_Str[15].StringToFormat(playerPoint.allianceTag);
          this.m_Str[15].StringToFormat(playerPoint.playerName);
          this.m_Str[15].StringToFormat(this.GetLocation(MapPointID));
          if (GUIManager.Instance.IsArabic)
          {
            this.m_Str[15].AppendFormat("{2} {1}[{0}]");
            break;
          }
          this.m_Str[15].AppendFormat("[{0}]{1} {2}");
          break;
        }
        this.m_Str[15].StringToFormat(playerPoint.playerName);
        this.m_Str[15].StringToFormat(this.GetLocation(MapPointID));
        if (GUIManager.Instance.IsArabic)
        {
          this.m_Str[15].AppendFormat("{1} {0}");
          break;
        }
        this.m_Str[15].AppendFormat("{0} {1}");
        break;
      case POINT_KIND.PK_CAMP:
        this.m_Str[15].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4540U));
        this.m_Str[15].StringToFormat(this.GetLocation(MapPointID, true));
        this.m_Str[15].AppendFormat("{0} {1}");
        break;
      case POINT_KIND.PK_YOLK:
        if ((int) mapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
        {
          MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int) mapPoint.tableID];
          this.m_Str[15].StringToFormat(DataManager.MapDataController.GetYolkName((ushort) mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID));
          this.m_Str[15].StringToFormat(this.GetYolkLocation((ushort) mapYolk.WonderID, DataManager.MapDataController.FocusKingdomID, true));
          this.m_Str[15].AppendFormat("{0} {1}");
          break;
        }
        break;
    }
    this.m_Door.OpenMenu(EGUIWindow.UI_Chat, (int) GUIManager.Instance.ChannelIndex + 1);
    ((UIChat) GUIManager.Instance.FindMenu(EGUIWindow.UI_Chat)).SetInputText(this.m_Str[15].ToString());
  }

  public void Close()
  {
    if ((double) this.delayOpenTime != 0.0)
    {
      GUIManager.Instance.HideUILock(EUILock.Normal);
      this.delayOpenTime = 0.0f;
    }
    this.m_PreKind = POINT_KIND.PK_MAX;
    this.m_TeamPanelGameObject.SetActive(false);
    this.m_PanelGameObject.SetActive(false);
    ((Component) this.m_GroundPanel).gameObject.SetActive(false);
    ((Component) this.m_ResourcePanel).gameObject.SetActive(false);
    ((Component) this.m_CampPanel).gameObject.SetActive(false);
    ((Component) this.m_WondersPanel).gameObject.SetActive(false);
    ((Component) this.m_NpcCastlePanel).gameObject.SetActive(false);
    this.OpenSearchPanel(false);
    this.OpenReinforcePanel(false);
    this.OpenDetectPanel(false, (byte) 0);
    this.OpenAttackPanel(false);
    this.OpenBookmarksPanel(false);
    this.OpenPvePanel(false, (ushort) 1);
    this.OpenRewardPanel(false);
    this.OpenTitlePanel(false);
    DataManager.msgBuffer[0] = (byte) 77;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    this.bGroundInfoOpen = false;
    if ((Object) this.WonderTileMapMat1 != (Object) null)
    {
      Object.Destroy((Object) this.WonderTileMapMat1);
      this.WonderTileMapMat1 = (Material) null;
    }
    if ((Object) this.WonderTileMapMat2 != (Object) null)
    {
      Object.Destroy((Object) this.WonderTileMapMat2);
      this.WonderTileMapMat2 = (Material) null;
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UIEmojiSelect, 3);
    if ((bool) (Object) this.m_PetSkillUse)
      ((Component) this.m_PetSkillUse).gameObject.SetActive(false);
    this.UpdatemPetNegativeBuff(this.m_MapPointID);
  }

  private uint GetMaxOverload(int _MapPointID)
  {
    GameConstants.getTileMapPosbySpriteID(_MapPointID);
    uint maxOverload = 0;
    uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    for (int index = 0; (long) index < (long) effectBaseVal; ++index)
    {
      if (DataManager.Instance.MarchEventData[index].Type == EMarchEventType.EMET_Gathering && GameConstants.PointCodeToMapID(DataManager.Instance.MarchEventData[index].Point.zoneID, DataManager.Instance.MarchEventData[index].Point.pointID) == _MapPointID)
      {
        maxOverload = DataManager.Instance.MarchEventData[index].MaxOverLoad;
        break;
      }
    }
    return maxOverload;
  }

  private int GetMarcheventIdx(int _MapPointID)
  {
    int marcheventIdx = 0;
    uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    for (int index = 0; (long) index < (long) effectBaseVal; ++index)
    {
      if (GameConstants.PointCodeToMapID(DataManager.Instance.MarchEventData[index].Point.zoneID, DataManager.Instance.MarchEventData[index].Point.pointID) == _MapPointID)
      {
        marcheventIdx = index;
        break;
      }
    }
    return marcheventIdx;
  }

  private long GetResStartTime(int _MapPointID)
  {
    long resStartTime = 0;
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
    if (DataManager.MapDataController.IsResources((uint) this.m_MapPointID))
      resStartTime = (long) DataManager.MapDataController.ResourcesPointTable[(int) mapPoint.tableID].time;
    return resStartTime;
  }

  public void UpdateResourceInfo()
  {
    this.m_TimeTick += Time.deltaTime;
    float x1 = 0.0f;
    if (this.OwnerKind < 1)
      return;
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
    POINT_KIND mapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) this.m_MapPointID);
    if ((double) this.m_TimeTick >= (double) this.m_ResTextChangeTime * 2.0)
    {
      this.m_TimeTick = 0.0f;
      this.m_ResTextType = this.m_ResTextType != (byte) 0 ? (byte) 0 : (byte) 1;
    }
    ((Graphic) this.m_SliderText2).color = new Color(1f, 1f, 1f, (double) this.m_TimeTick < (double) this.m_ResTextChangeTime ? Mathf.Lerp(0.0f, 2f, this.m_TimeTick / this.m_ResTextChangeTime) : Mathf.Lerp(0.0f, 2f, (this.m_ResTextChangeTime * 2f - this.m_TimeTick) / this.m_ResTextChangeTime));
    if (mapInfoPointKind > POINT_KIND.PK_NONE && mapInfoPointKind < POINT_KIND.PK_CRYSTAL)
    {
      if (this.OwnerKind == 1)
      {
        if (NetworkManager.ServerTime >= (double) this.m_ResStartTime)
        {
          float x2 = (float) (uint) Mathf.Clamp((float) (uint) ((NetworkManager.ServerTime - (double) this.m_ResStartTime) * (double) this.m_ResRate), 0.0f, (float) this.m_MaxOverload);
          uint sec = (uint) ((double) this.m_MaxOverload / (double) this.m_ResRate) - (uint) ((double) x2 / (double) this.m_ResRate);
          this.m_Slider2.fillAmount = x2 / (float) this.m_MaxOverload;
          this.m_Str[23].ClearString();
          this.m_Str[24].ClearString();
          if ((double) x2 > (double) this.m_ResTotalCount)
            return;
          if (this.m_ResTextType == (byte) 0)
          {
            this.m_Str[23].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4539U));
            this.m_Str[23].IntToFormat((long) (int) x2, bNumber: true);
            this.m_Str[23].IntToFormat((long) this.m_MaxOverload, bNumber: true);
            this.m_Str[23].AppendFormat("{0} {1}/{2}");
          }
          else
          {
            this.m_Str[25].ClearString();
            GameConstants.GetTimeString(this.m_Str[25], sec);
            this.m_Str[23].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(817U));
            this.m_Str[23].StringToFormat(this.m_Str[25]);
            this.m_Str[23].AppendFormat("{0} {1}");
          }
          this.m_Str[24].IntToFormat(this.m_ResTotalCount <= (uint) x2 ? 0L : (long) (this.m_ResTotalCount - (uint) x2), bNumber: true);
          this.m_Str[24].AppendFormat("{0}");
          this.m_SliderText2.text = this.m_Str[23].ToString();
          this.m_ResourceProductionText.text = this.m_Str[24].ToString();
          this.m_SliderText2.SetAllDirty();
          this.m_ResourceProductionText.SetAllDirty();
          this.m_SliderText2.cachedTextGenerator.Invalidate();
          this.m_ResourceProductionText.cachedTextGenerator.Invalidate();
        }
        else
        {
          this.m_Str[23].ClearString();
          this.m_Str[24].ClearString();
          this.m_Slider2.fillAmount = 0.0f;
          this.m_Str[23].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4539U));
          this.m_Str[23].IntToFormat((long) (int) x1, bNumber: true);
          this.m_Str[23].IntToFormat((long) this.m_MaxOverload, bNumber: true);
          this.m_Str[23].AppendFormat("{0} {1}/{2}");
          this.m_SliderText2.text = this.m_Str[23].ToString();
          this.m_Str[24].IntToFormat((long) this.m_ResTotalCount - (long) (int) x1, bNumber: true);
          this.m_Str[24].AppendFormat("{0}");
          this.m_ResourceProductionText.text = this.m_Str[24].ToString();
        }
      }
      else
      {
        if ((double) x1 >= (double) this.m_ResTotalCount)
          return;
        float num = (float) (uint) ((NetworkManager.ServerTime - (double) this.m_ResStartTime) * (double) this.m_ResRate);
        this.m_Str[24].ClearString();
        this.m_Str[24].IntToFormat(this.m_ResTotalCount <= (uint) num ? 0L : (long) (this.m_ResTotalCount - (uint) num), bNumber: true);
        this.m_Str[24].AppendFormat("{0}");
        this.m_ResourceProductionText.text = this.m_Str[24].ToString();
      }
    }
    else
    {
      if (mapInfoPointKind != POINT_KIND.PK_CRYSTAL || (double) this.m_ResRate == 0.0)
        return;
      if (this.OwnerKind == 1)
      {
        if (NetworkManager.ServerTime >= (double) this.m_ResStartTime)
        {
          float x3 = ((float) NetworkManager.ServerTime - (float) this.m_ResStartTime) * this.m_ResRate;
          if ((double) x3 >= (double) this.m_MaxOverload)
            x3 = (float) this.m_MaxOverload;
          uint sec = (uint) ((double) this.m_MaxOverload / (double) this.m_ResRate - (NetworkManager.ServerTime - (double) this.m_ResStartTime));
          if (this.m_MaxOverload <= 0U)
            this.m_MaxOverload = 1U;
          float num = (float) this.m_MaxOverload / this.m_ResRate / (float) this.m_MaxOverload;
          this.m_Slider11.fillAmount = ((float) NetworkManager.ServerTime - (float) this.m_ResStartTime) % num / num;
          this.m_Slider12.fillAmount = this.m_Slider11.fillAmount;
          if ((double) x3 > (double) this.m_ResTotalCount)
            return;
          this.m_Slider2.fillAmount = x3 / (float) this.m_MaxOverload;
          this.m_Str[23].ClearString();
          this.m_Str[24].ClearString();
          if (this.m_ResTextType == (byte) 0)
          {
            this.m_Str[23].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(691U));
            this.m_Str[23].IntToFormat((long) (uint) x3, bNumber: true);
            this.m_Str[23].IntToFormat((long) this.m_MaxOverload, bNumber: true);
            this.m_Str[23].AppendFormat("{0} {1}/{2}");
          }
          else
          {
            this.m_Str[25].ClearString();
            GameConstants.GetTimeString(this.m_Str[25], sec);
            this.m_Str[23].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(817U));
            this.m_Str[23].StringToFormat(this.m_Str[25]);
            this.m_Str[23].AppendFormat("{0} {1}");
          }
          this.m_Str[24].IntToFormat(this.m_ResTotalCount <= (uint) x3 ? 0L : (long) (this.m_ResTotalCount - (uint) x3), bNumber: true);
          this.m_Str[24].AppendFormat("{0}");
          this.m_SliderText2.text = this.m_Str[23].ToString();
          this.m_ResourceProductionText.text = this.m_Str[24].ToString();
          this.m_SliderText2.SetAllDirty();
          this.m_ResourceProductionText.SetAllDirty();
          this.m_SliderText2.cachedTextGenerator.Invalidate();
          this.m_ResourceProductionText.cachedTextGenerator.Invalidate();
        }
        else
        {
          this.m_Str[23].ClearString();
          this.m_Str[24].ClearString();
          this.m_Slider2.fillAmount = 0.0f;
          this.m_Str[23].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4539U));
          this.m_Str[23].IntToFormat((long) (uint) x1, bNumber: true);
          this.m_Str[23].IntToFormat((long) this.m_MaxOverload, bNumber: true);
          this.m_Str[23].AppendFormat("{0} {1}/{2}");
          this.m_SliderText2.text = this.m_Str[23].ToString();
          this.m_Str[24].IntToFormat(this.m_ResTotalCount <= (uint) x1 ? 0L : (long) (this.m_ResTotalCount - (uint) x1), bNumber: true);
          this.m_Str[24].AppendFormat("{0}");
          this.m_ResourceProductionText.text = this.m_Str[24].ToString();
        }
      }
      else
      {
        if ((double) x1 >= (double) this.m_ResTotalCount)
          return;
        float num = (float) (uint) ((NetworkManager.ServerTime - (double) this.m_ResStartTime) * (double) this.m_ResRate);
        this.m_Str[24].ClearString();
        this.m_Str[24].IntToFormat(this.m_ResTotalCount <= (uint) num ? 0L : (long) (this.m_ResTotalCount - (uint) num), bNumber: true);
        this.m_Str[24].AppendFormat("{0}");
        this.m_ResourceProductionText.text = this.m_Str[24].ToString();
      }
    }
  }

  public void SetTimeText(CString str, double time)
  {
    int x1 = (int) time % 60;
    int x2 = (int) (time / 60.0) % 60;
    int x3 = (int) (time % 86400.0) / 3600;
    int x4 = (int) time / 86400;
    StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4575U));
    if (x4 > 0)
    {
      StringManager.Instance.IntToFormat((long) x4);
      StringManager.Instance.IntToFormat((long) x3, 2);
      StringManager.Instance.IntToFormat((long) x2, 2);
      StringManager.Instance.IntToFormat((long) x1, 2);
      str.ClearString();
      str.AppendFormat("{0}{1}:{2}:{3}:{4}");
    }
    else if (x3 > 0)
    {
      StringManager.Instance.IntToFormat((long) x3);
      StringManager.Instance.IntToFormat((long) x2, 2);
      StringManager.Instance.IntToFormat((long) x1, 2);
      str.ClearString();
      str.AppendFormat("{0}{1}:{2}:{3}");
    }
    else
    {
      StringManager.Instance.IntToFormat((long) x2, 2);
      StringManager.Instance.IntToFormat((long) x1, 2);
      str.ClearString();
      str.AppendFormat("{0}{1}:{2}");
    }
  }

  public void UpdateTeamTime()
  {
    if (this.m_MapPointID < DataManager.MapDataController.MapLineTable.Count)
    {
      double time = (double) ((long) DataManager.MapDataController.MapLineTable[this.m_MapPointID].begin + (long) DataManager.MapDataController.MapLineTable[this.m_MapPointID].during - DataManager.Instance.ServerTime);
      if (time >= 0.0)
      {
        this.SetTimeText(this.m_Str[12], time);
        this.m_TimeText.text = this.m_Str[12].ToString();
        this.m_TimeText.SetAllDirty();
        this.m_TimeText.cachedTextGenerator.Invalidate();
      }
      if (this.OwnerKind != 1 || this.m_TeamSpeedBtnGameObject.activeSelf || !this.IsAttackActionLineFlag(DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag) || DataManager.Instance.ServerTime - (long) DataManager.MapDataController.MapLineTable[this.m_MapPointID].begin <= 5L)
        return;
      this.m_TeamSpeedBtnGameObject.SetActive(true);
      this.SetExpressionButton(this.OwnerKind, POINT_KIND.PK_UNDEFINED);
    }
    else
      this.Close();
  }

  public void SetTempLocation(CString str)
  {
    Vector2 zero1 = Vector2.zero;
    if (this.m_MapPointID >= DataManager.MapDataController.MapLineTable.Count || str == null)
      return;
    PointCode end = DataManager.MapDataController.MapLineTable[this.m_MapPointID].end;
    int mapId = GameConstants.PointCodeToMapID(end.zoneID, end.pointID);
    Vector2 zero2 = Vector2.zero;
    Vector2 vector2 = DataManager.MapDataController.LayoutMapInfo[mapId].pointKind != (byte) 11 || DataManager.MapDataController.LayoutMapInfo[mapId].tableID >= (ushort) 40 ? GameConstants.getTileMapPosbyMapID(mapId) : DataManager.MapDataController.GetYolkPos(DataManager.MapDataController.LayoutMapInfo[mapId].tableID, DataManager.MapDataController.FocusKingdomID);
    str.ClearString();
    StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4505U));
    StringManager.Instance.IntToFormat((long) (int) vector2.x);
    StringManager.Instance.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(4506U));
    StringManager.Instance.IntToFormat((long) (int) vector2.y);
    if (GUIManager.Instance.IsArabic)
      str.AppendFormat("{3}{2} {1}{0}");
    else
      str.AppendFormat("{0}{1} {2}{3}");
    this.m_TeamLocText.text = this.m_Str[11].ToString();
    this.m_TeamLocText.SetAllDirty();
    this.m_TeamLocText.cachedTextGenerator.Invalidate();
    this.m_TeamLocText.cachedTextGeneratorForLayout.Invalidate();
    ((Graphic) this.m_TeamLocLine).rectTransform.sizeDelta = new Vector2(this.m_TeamLocText.preferredWidth, ((Graphic) this.m_TeamLocLine).rectTransform.sizeDelta.y);
    ((Behaviour) this.m_TeamLocLine).enabled = true;
    zero1.Set(this.m_TeamTargetText.preferredWidth, ((Graphic) this.m_TeamTargetText).rectTransform.sizeDelta.y);
    ((Graphic) this.m_TeamTargetText).rectTransform.sizeDelta = zero1;
    float num = 10f;
    float new_x = (float) ((314.0 - (double) this.m_TeamTargetText.preferredWidth - (double) this.m_TeamLocText.preferredWidth - (double) num) / 2.0);
    zero1.Set(new_x, ((Graphic) this.m_TeamTargetText).rectTransform.anchoredPosition.y);
    ((Graphic) this.m_TeamTargetText).rectTransform.anchoredPosition = zero1;
    RectTransform component = ((Component) this.m_TeamLocBtn).gameObject.GetComponent<RectTransform>();
    zero1.Set(new_x + num + this.m_TeamTargetText.preferredWidth, component.anchoredPosition.y);
    component.anchoredPosition = zero1;
  }

  public void RequsetAdvanceMapdata(int MapPointID)
  {
    this.bRequsetAdvanceMapdata = true;
    this.m_RequsetMapID = MapPointID;
    this.m_RequsetTick = 0.0f;
    DataManager.MapDataController.RequsetAdvanceMapdata(this.m_MapPointID);
  }

  public void CheckMapInfoID(int mapInfoID)
  {
    if (!this.m_PanelGameObject.activeSelf || !this.bRequsetAdvanceMapdata || this.m_MapPointID != mapInfoID)
      return;
    this.bRequsetAdvanceMapdata = false;
    this.m_RequsetMapID = -1;
    this.m_RequsetTick = 0.0f;
  }

  public void Run()
  {
    if (this.m_eGroundInfoKind == EGroundInfoKind.Resource)
      this.UpdateResourceInfo();
    if (this.m_eGroundInfoKind == EGroundInfoKind.Team)
      this.UpdateTeamTime();
    if (this.m_eGroundInfoKind == EGroundInfoKind.Wonder)
      this.SetWonderTimeInfo(this.m_MapPointID);
    if (this.m_eGroundInfoKind == EGroundInfoKind.NpcCastle)
      this.SetNpcCastleTimeInfo();
    if (this.m_PanelGameObject.activeSelf && this.bRequsetAdvanceMapdata)
    {
      this.m_RequsetTick += Time.deltaTime;
      if ((double) this.m_RequsetTick >= 3.0)
      {
        this.RequsetAdvanceMapdata(this.m_RequsetMapID);
        this.m_RequsetTick = 0.0f;
      }
    }
    if ((double) this.delayOpenTime == 0.0)
      return;
    this.delayOpenTime -= Time.deltaTime;
    if ((double) this.delayOpenTime > 0.0)
      return;
    GUIManager.Instance.HideUILock(EUILock.Normal);
    this.delayOpenTime = 0.0f;
    this.Open(this.delayMapInfoID, this.delayInfoKind);
  }

  public void delayOpen(int mapInfoID, POINT_KIND infoKind = POINT_KIND.PK_MAX)
  {
    if ((double) this.delayOpenTime == 0.0)
      GUIManager.Instance.ShowUILock(EUILock.Normal);
    this.delayOpenTime = 0.2f;
    this.delayMapInfoID = mapInfoID;
    this.delayInfoKind = infoKind;
  }

  public void SetButtonColor(POINT_KIND kind, bool bLocalKindom)
  {
    ColorBlock colorBlock = new ColorBlock();
    Color color1 = new Color(1f, 1f, 1f);
    Color color2 = new Color(0.5f, 0.5f, 0.5f);
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
    bool flag1 = DataManager.Instance.IsSameAlliance(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceTag);
    Color color3;
    int num;
    if (bLocalKindom)
    {
      color3 = color1;
      ((ColorBlock) ref colorBlock).normalColor = color1;
      num = 0;
    }
    else
    {
      color3 = color2;
      ((ColorBlock) ref colorBlock).normalColor = color2;
      num = 100;
    }
    for (int index = 0; index < this.m_Buttons.Length; ++index)
    {
      this.m_Buttons[index].colors = colorBlock;
      UIText component1 = ((Component) this.m_Buttons[index]).gameObject.transform.GetChild(0).GetComponent<UIText>();
      if ((bool) (Object) component1)
      {
        ((Graphic) component1).color = color3;
      }
      else
      {
        Image component2 = ((Component) this.m_Buttons[index]).gameObject.transform.GetChild(0).GetComponent<Image>();
        UIText component3 = ((Component) this.m_Buttons[index]).gameObject.transform.GetChild(1).GetComponent<UIText>();
        if ((bool) (Object) component2)
          ((Graphic) component2).color = color3;
        if ((bool) (Object) component3)
          ((Graphic) component3).color = color3;
      }
      this.m_Buttons[index].m_BtnID3 = num;
    }
    ((ColorBlock) ref colorBlock).normalColor = color1;
    Color color4 = color1;
    bool flag2 = false;
    switch (kind)
    {
      case POINT_KIND.PK_NONE:
        MAP_TERRAIN_KIND mapTerrainKind = MAP_TERRAIN_KIND.MTK_NONE;
        if ((bool) (Object) this.m_Door)
          mapTerrainKind = this.m_Door.GetTerrain(DataManager.MapDataController.FocusKingdomID, (uint) this.m_MapPointID);
        UIText component4;
        if (DataManager.Instance.IsNewbie())
        {
          flag2 = DataManager.Instance.GetCurItemQuantity(GameConstants.NewbieTeleportItemID, (byte) 0) > (ushort) 0;
          if (mapTerrainKind == MAP_TERRAIN_KIND.MTK_FOREST)
          {
            this.m_Buttons[1].colors = colorBlock;
            this.m_Buttons[1].m_BtnID3 = 0;
            UIText component5 = ((Component) this.m_Buttons[1]).gameObject.transform.GetChild(0).GetComponent<UIText>();
            if ((bool) (Object) component5)
              ((Graphic) component5).color = color4;
            this.m_Buttons[2].colors = colorBlock;
            component4 = ((Component) this.m_Buttons[2]).gameObject.transform.GetChild(0).GetComponent<UIText>();
            this.SetTransBtnState(this.m_Buttons[2]);
            break;
          }
          this.m_Buttons[1].colors = colorBlock;
          component4 = ((Component) this.m_Buttons[1]).gameObject.transform.GetChild(0).GetComponent<UIText>();
          this.SetTransBtnState(this.m_Buttons[1]);
          break;
        }
        flag2 = !bLocalKindom ? DataManager.Instance.GetCurItemQuantity(GameConstants.WorldTeleportItemID, (byte) 0) > (ushort) 0 : DataManager.Instance.GetCurItemQuantity(GameConstants.AdvanceTeleportItemID, (byte) 0) > (ushort) 0;
        if (mapTerrainKind == MAP_TERRAIN_KIND.MTK_FOREST)
        {
          this.m_Buttons[1].colors = colorBlock;
          this.m_Buttons[1].m_BtnID3 = 0;
          UIText component6 = ((Component) this.m_Buttons[1]).gameObject.transform.GetChild(0).GetComponent<UIText>();
          if ((bool) (Object) component6)
            ((Graphic) component6).color = color4;
          this.m_Buttons[2].colors = colorBlock;
          component4 = ((Component) this.m_Buttons[2]).gameObject.transform.GetChild(0).GetComponent<UIText>();
          this.SetTransBtnState(this.m_Buttons[2]);
          break;
        }
        this.m_Buttons[1].colors = colorBlock;
        component4 = ((Component) this.m_Buttons[1]).gameObject.transform.GetChild(0).GetComponent<UIText>();
        this.SetTransBtnState(this.m_Buttons[1]);
        break;
      case POINT_KIND.PK_FOOD:
      case POINT_KIND.PK_STONE:
      case POINT_KIND.PK_IRON:
      case POINT_KIND.PK_WOOD:
      case POINT_KIND.PK_GOLD:
      case POINT_KIND.PK_CRYSTAL:
        if (this.OwnerKind == 0)
          break;
        this.m_Buttons[0].colors = colorBlock;
        this.m_Buttons[0].m_BtnID3 = 0;
        UIText component7 = ((Component) this.m_Buttons[0]).gameObject.transform.GetChild(0).GetComponent<UIText>();
        if (!(bool) (Object) component7)
          break;
        ((Graphic) component7).color = color4;
        break;
      case POINT_KIND.PK_CITY:
        if (this.OwnerKind == 3)
        {
          this.m_Buttons[5].colors = colorBlock;
          this.m_Buttons[5].m_BtnID3 = 0;
          UIText component8 = ((Component) this.m_Buttons[5]).gameObject.transform.GetChild(0).GetComponent<UIText>();
          if (!(bool) (Object) component8)
            break;
          ((Graphic) component8).color = color4;
          break;
        }
        if (this.OwnerKind == 1)
          break;
        if (this.bHaveAlly_Self && this.bHaveAlly && flag1)
        {
          this.m_Buttons[0].colors = colorBlock;
          this.m_Buttons[0].m_BtnID3 = 0;
          UIText component9 = ((Component) this.m_Buttons[0]).gameObject.transform.GetChild(0).GetComponent<UIText>();
          if (!(bool) (Object) component9)
            break;
          ((Graphic) component9).color = color4;
          break;
        }
        this.m_Buttons[1].colors = colorBlock;
        this.m_Buttons[1].m_BtnID3 = 0;
        UIText component10 = ((Component) this.m_Buttons[1]).gameObject.transform.GetChild(0).GetComponent<UIText>();
        if (!(bool) (Object) component10)
          break;
        ((Graphic) component10).color = color4;
        break;
      case POINT_KIND.PK_CAMP:
        this.m_Buttons[0].colors = colorBlock;
        this.m_Buttons[0].m_BtnID3 = 0;
        UIText component11 = ((Component) this.m_Buttons[0]).gameObject.transform.GetChild(0).GetComponent<UIText>();
        if (!(bool) (Object) component11)
          break;
        ((Graphic) component11).color = color4;
        break;
      case POINT_KIND.PK_YOLK:
        if ((int) mapPoint.tableID >= DataManager.MapDataController.YolkPointTable.Length)
          break;
        if (DataManager.MapDataController.YolkPointTable[(int) mapPoint.tableID].WonderState == (byte) 0 || this.OwnerKind == 4)
        {
          this.m_Buttons[0].colors = colorBlock;
          this.m_Buttons[0].m_BtnID3 = 0;
          UIText component12 = ((Component) this.m_Buttons[0]).gameObject.transform.GetChild(0).GetComponent<UIText>();
          if (!(bool) (Object) component12)
            break;
          ((Graphic) component12).color = color4;
          break;
        }
        this.m_Buttons[1].colors = colorBlock;
        this.m_Buttons[1].m_BtnID3 = 0;
        UIText component13 = ((Component) this.m_Buttons[1]).gameObject.transform.GetChild(0).GetComponent<UIText>();
        if (!(bool) (Object) component13)
          break;
        ((Graphic) component13).color = color4;
        break;
    }
  }

  public void SetTransBtnState(UIButton btn)
  {
    Color color1 = new Color(1f, 1f, 1f);
    Color color2 = new Color(0.5f, 0.5f, 0.5f);
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
    UIText component = ((Component) btn).gameObject.transform.GetChild(0).GetComponent<UIText>();
    if ((Object) component == (Object) null)
      return;
    bool bIsInMyKindom = (int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID;
    bool bIsNewbie = DataManager.Instance.IsNewbie();
    bool bCheckMove = DataManager.Instance.CheckMoveingKingdom();
    bool bIsKvk = this.IsInKvk();
    bool bIsInKvkSelf = this.IsInKvkSelf();
    bool flag1 = this.IsInWorldWarSelf();
    bool bHaveItem = this.HaveTransItem(bIsNewbie, bIsKvk, bIsInKvkSelf, bIsInMyKindom);
    ActivityManager.Instance.CheckIsMatchKingdom(DataManager.MapDataController.FocusKingdomID);
    bool bIsEnemy = (int) mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length && DataManager.MapDataController.IsEnemy(DataManager.MapDataController.FocusKingdomID);
    bool flag2 = bCheckMove && this.IsWorldTeleport(bIsNewbie, bIsKvk, bIsInKvkSelf, bIsInMyKindom);
    if ((int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
    {
      btn.m_BtnID3 = 0;
      ((Graphic) component).color = color1;
    }
    else if (DataManager.Instance.bHaveWarBuff && !flag2)
      btn.m_BtnID3 = 104;
    else if (flag1)
    {
      if (ActivityManager.Instance.IsKOWRunning())
        btn.m_BtnID3 = this.CheckWorldWarTranstion(bCheckMove, ref component);
      else if (ActivityManager.Instance.IsNobilityWarRunning())
      {
        btn.m_BtnID3 = this.CheckNoboilityBattle(ref component);
      }
      else
      {
        btn.m_BtnID3 = 106;
        ((Graphic) component).color = color2;
      }
    }
    else
      btn.m_BtnID3 = this.CheckOtherTranstion(bCheckMove, bIsKvk, bIsInKvkSelf, bIsEnemy, bHaveItem, bIsNewbie, ref component);
    if (bIsEnemy && bIsInKvkSelf && !flag1)
    {
      if ((int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
        component.text = DataManager.Instance.mStringTable.GetStringByID(4512U);
      else
        component.text = DataManager.Instance.mStringTable.GetStringByID(974U);
    }
    else if (flag1)
    {
      if ((int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
        component.text = DataManager.Instance.mStringTable.GetStringByID(4512U);
      else
        component.text = DataManager.Instance.mStringTable.GetStringByID(974U);
    }
    else if (!bIsInMyKindom)
      component.text = DataManager.Instance.mStringTable.GetStringByID(949U);
    else
      component.text = DataManager.Instance.mStringTable.GetStringByID(4512U);
  }

  public bool HaveTransItem(bool bIsNewbie, bool bIsKvk, bool bIsInKvkSelf, bool bIsInMyKindom)
  {
    bool flag = this.IsInWorldWarSelf();
    return !bIsNewbie ? (!bIsKvk || !bIsInKvkSelf ? (!flag ? bIsInMyKindom || true : DataManager.Instance.GetCurItemQuantity(GameConstants.WorldWarTeleportItemID, (byte) 0) > (ushort) 0) : DataManager.Instance.GetCurItemQuantity(GameConstants.AdvanceTeleportItemID, (byte) 0) > (ushort) 0) : DataManager.Instance.GetCurItemQuantity(GameConstants.NewbieTeleportItemID, (byte) 0) > (ushort) 0;
  }

  private int CheckWorldWarTranstion(bool bCheckMove, ref UIText text)
  {
    Color color1 = new Color(1f, 1f, 1f);
    Color color2 = new Color(0.5f, 0.5f, 0.5f);
    int num;
    if (bCheckMove)
    {
      if (ActivityManager.Instance.IsKOWRunning())
      {
        if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 25)
        {
          num = 0;
          ((Graphic) text).color = color1;
        }
        else
        {
          num = 105;
          ((Graphic) text).color = color2;
        }
      }
      else
      {
        num = 106;
        ((Graphic) text).color = color2;
      }
    }
    else
    {
      num = 108;
      ((Graphic) text).color = color2;
    }
    return num;
  }

  private int CheckNoboilityBattle(ref UIText text)
  {
    Color color1 = new Color(1f, 1f, 1f);
    Color color2 = new Color(0.5f, 0.5f, 0.5f);
    ActivityManager instance = ActivityManager.Instance;
    bool flag = (int) instance.FederalActKingdomWonderID == (int) instance.FederalHomeKingdomWonderID;
    int num = GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 25 ? 105 : (instance.FederalActKingdomWonderID == (byte) 0 ? 111 : ((int) instance.FederalActKingdomWonderID != (int) instance.FederalFightingWonderID ? 110 : ((int) instance.FederalActKingdomWonderID != (int) instance.FederalHomeKingdomWonderID ? 109 : 0)));
    ((Graphic) text).color = num <= 0 ? color1 : color2;
    return num;
  }

  private int CheckOtherTranstion(
    bool bCheckMove,
    bool bIsKvk,
    bool bIsInKvkSelf,
    bool bIsEnemy,
    bool bHaveItem,
    bool bIsNewbie,
    ref UIText text)
  {
    Color color1 = new Color(1f, 1f, 1f);
    Color color2 = new Color(0.5f, 0.5f, 0.5f);
    int num;
    if (bCheckMove)
    {
      num = 0;
      ((Graphic) text).color = color1;
      if ((int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID)
      {
        if (bIsKvk && bIsInKvkSelf)
        {
          if (!bIsEnemy)
          {
            ((Graphic) text).color = color2;
            num = 107;
          }
        }
        else if (!bIsKvk && bIsInKvkSelf || bIsKvk && !bIsInKvkSelf)
        {
          ((Graphic) text).color = color2;
          num = 107;
        }
        else if (!bIsKvk && !bIsInKvkSelf && !bHaveItem)
          num = !bIsNewbie ? 102 : 101;
      }
    }
    else
      num = 103;
    return num;
  }

  public bool IsWorldTeleport(bool bIsNewbie, bool bIsKvk, bool bIsInKvkSelf, bool bIsInMyKindom)
  {
    bool flag = this.IsInWorldWarSelf();
    return !bIsNewbie && (!bIsKvk || !bIsInKvkSelf) && !flag && !bIsInMyKindom;
  }

  public void ShowCantClickMsg(int msgid = 100)
  {
    switch (msgid)
    {
      case 100:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7744U), (ushort) byte.MaxValue);
        break;
      case 101:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(615U), (ushort) byte.MaxValue);
        break;
      case 102:
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3782U), DataManager.Instance.mStringTable.GetStringByID(955U), bCloseIDSet: true);
        break;
      case 103:
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3782U), DataManager.Instance.mStringTable.GetStringByID(956U), bCloseIDSet: true);
        break;
      case 104:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9943U), (ushort) byte.MaxValue);
        break;
      case 105:
        CString cstring1 = StringManager.Instance.StaticString1024();
        cstring1.IntToFormat(25L);
        cstring1.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9167U));
        GUIManager.Instance.AddHUDMessage(cstring1.ToString(), (ushort) byte.MaxValue);
        break;
      case 106:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8107U), (ushort) byte.MaxValue);
        break;
      case 107:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(952U), (ushort) byte.MaxValue);
        break;
      case 108:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(10035U), (ushort) byte.MaxValue);
        break;
      case 109:
        CString cstring2 = StringManager.Instance.StaticString1024();
        cstring2.IntToFormat((long) ActivityManager.Instance.FederalActKingdomWonderID);
        cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(10066U));
        GUIManager.Instance.AddHUDMessage(cstring2.ToString(), (ushort) byte.MaxValue);
        break;
      case 110:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(10065U), (ushort) byte.MaxValue);
        break;
      case 111:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(10064U), (ushort) byte.MaxValue);
        break;
    }
  }

  protected char OnValidateInput(string text, int index, char check)
  {
    return Encoding.UTF8.GetByteCount(text) + Encoding.UTF8.GetByteCount(check.ToString()) > (int) DataManager.Instance.RoleBookMark.GetNameSize() - 1 || !DataManager.Instance.isNotEmojiCharacter(check) ? char.MinValue : check;
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    bool flag = true;
    switch (sender.Parm1)
    {
      case 1:
        this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(539U);
        Vector2 sizeDelta1 = ((Graphic) this.m_HintText).rectTransform.sizeDelta with
        {
          y = this.m_HintText.preferredHeight
        };
        ((Graphic) this.m_HintText).rectTransform.sizeDelta = sizeDelta1;
        ((Graphic) this.m_HintBg).rectTransform.sizeDelta = sizeDelta1 + new Vector2(20f, 10f);
        ((Graphic) this.m_HintBg).rectTransform.anchoredPosition = new Vector2(51f, 143f);
        break;
      case 2:
        this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(540U);
        Vector2 sizeDelta2 = ((Graphic) this.m_HintText).rectTransform.sizeDelta with
        {
          y = this.m_HintText.preferredHeight
        };
        ((Graphic) this.m_HintText).rectTransform.sizeDelta = sizeDelta2;
        ((Graphic) this.m_HintBg).rectTransform.sizeDelta = sizeDelta2 + new Vector2(20f, 10f);
        ((Graphic) this.m_HintBg).rectTransform.anchoredPosition = new Vector2(51f, 143f);
        break;
      case 3:
        this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(7347U);
        Vector2 sizeDelta3 = ((Graphic) this.m_HintText).rectTransform.sizeDelta with
        {
          y = this.m_HintText.preferredHeight
        };
        ((Graphic) this.m_HintText).rectTransform.sizeDelta = sizeDelta3;
        ((Graphic) this.m_HintBg).rectTransform.sizeDelta = sizeDelta3 + new Vector2(20f, 10f);
        ((Graphic) this.m_HintBg).rectTransform.anchoredPosition = new Vector2(67f, 82f);
        break;
      case 4:
        this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(7348U);
        Vector2 sizeDelta4 = ((Graphic) this.m_HintText).rectTransform.sizeDelta with
        {
          y = this.m_HintText.preferredHeight
        };
        ((Graphic) this.m_HintText).rectTransform.sizeDelta = sizeDelta4;
        ((Graphic) this.m_HintBg).rectTransform.sizeDelta = sizeDelta4 + new Vector2(20f, 10f);
        ((Graphic) this.m_HintBg).rectTransform.anchoredPosition = new Vector2(67f, 82f);
        break;
      case 5:
        this.m_Str[46].ClearString();
        MapPoint mapPoint1 = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
        if ((int) mapPoint1.tableID < DataManager.MapDataController.PlayerPointTable.Length)
        {
          this.m_Str[46].StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) DataManager.Instance.TitleData.GetRecordByKey((ushort) DataManager.MapDataController.PlayerPointTable[(int) mapPoint1.tableID].kingdomTitle).StringID));
          this.m_Str[46].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9370U));
          this.m_HintText.text = this.m_Str[46].ToString();
          Vector2 sizeDelta5 = ((Graphic) this.m_HintText).rectTransform.sizeDelta with
          {
            y = this.m_HintText.preferredHeight
          };
          ((Graphic) this.m_HintText).rectTransform.sizeDelta = sizeDelta5;
          ((Graphic) this.m_HintBg).rectTransform.sizeDelta = sizeDelta5 + new Vector2(20f, 10f);
          ((Graphic) this.m_HintBg).rectTransform.anchoredPosition = new Vector2(51f, 143f);
          break;
        }
        break;
      case 6:
        MapPoint mapPoint2 = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
        if ((int) mapPoint2.tableID < DataManager.MapDataController.YolkPointTable.Length)
        {
          MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int) mapPoint2.tableID];
          if (ActivityManager.Instance.IsInKvK(DataManager.MapDataController.FocusKingdomID != (ushort) 0 ? DataManager.MapDataController.FocusKingdomID : DataManager.MapDataController.OtherKingdomData.kingdomID))
            this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(9902U);
          else if (mapYolk.WonderState == (byte) 0)
            this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(9399U);
          else if (mapYolk.WonderState == (byte) 1)
            this.m_HintText.text = (int) DataManager.MapDataController.FocusKingdomID != (int) ActivityManager.Instance.KOWKingdomID || mapYolk.WonderID <= (byte) 0 ? (!ActivityManager.Instance.IsKOWRunning() || (int) DataManager.MapDataController.FocusKingdomID != (int) ActivityManager.Instance.KOWKingdomID ? DataManager.Instance.mStringTable.GetStringByID(9397U) : DataManager.Instance.mStringTable.GetStringByID(11033U)) : DataManager.Instance.mStringTable.GetStringByID(11033U);
        }
        Vector2 sizeDelta6 = ((Graphic) this.m_HintText).rectTransform.sizeDelta with
        {
          y = this.m_HintText.preferredHeight
        };
        ((Graphic) this.m_HintText).rectTransform.sizeDelta = sizeDelta6;
        ((Graphic) this.m_HintBg).rectTransform.sizeDelta = sizeDelta6 + new Vector2(20f, 10f);
        ((Graphic) this.m_HintBg).rectTransform.anchoredPosition = new Vector2(79f, 135f);
        break;
      case 7:
        MapPoint mapPoint3 = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
        if ((int) mapPoint3.tableID < DataManager.MapDataController.YolkPointTable.Length)
        {
          MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[(int) mapPoint3.tableID];
          if (ActivityManager.Instance.IsInKvK(DataManager.MapDataController.FocusKingdomID != (ushort) 0 ? DataManager.MapDataController.FocusKingdomID : DataManager.MapDataController.OtherKingdomData.kingdomID))
            this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(9398U);
          else if (mapYolk.WonderState == (byte) 0)
            this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(9400U);
          else if (mapYolk.WonderState == (byte) 1)
            this.m_HintText.text = !ActivityManager.Instance.IsKOWRunning() || (int) DataManager.MapDataController.FocusKingdomID != (int) ActivityManager.Instance.KOWKingdomID ? (mapYolk.WonderID <= (byte) 0 || (int) DataManager.MapDataController.FocusKingdomID != (int) ActivityManager.Instance.KOWKingdomID ? DataManager.Instance.mStringTable.GetStringByID(9398U) : DataManager.Instance.mStringTable.GetStringByID(11096U)) : DataManager.Instance.mStringTable.GetStringByID(11034U);
        }
        Vector2 sizeDelta7 = ((Graphic) this.m_HintText).rectTransform.sizeDelta with
        {
          y = this.m_HintText.preferredHeight
        };
        ((Graphic) this.m_HintText).rectTransform.sizeDelta = sizeDelta7;
        ((Graphic) this.m_HintBg).rectTransform.sizeDelta = sizeDelta7 + new Vector2(20f, 10f);
        ((Graphic) this.m_HintBg).rectTransform.anchoredPosition = new Vector2(79f, 135f);
        break;
      case 8:
        this.m_Str[46].ClearString();
        if (this.m_MapPointID >= 0 && this.m_MapPointID < DataManager.MapDataController.LayoutMapInfo.Length)
        {
          MapPoint mapPoint4 = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
          if ((int) mapPoint4.tableID < DataManager.MapDataController.PlayerPointTable.Length)
          {
            this.m_Str[46].StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) DataManager.Instance.TitleDataW.GetRecordByKey((ushort) DataManager.MapDataController.PlayerPointTable[(int) mapPoint4.tableID].worldTitle).StringID));
            this.m_Str[46].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11032U));
            this.m_HintText.text = this.m_Str[46].ToString();
            Vector2 sizeDelta8 = ((Graphic) this.m_HintText).rectTransform.sizeDelta with
            {
              y = this.m_HintText.preferredHeight
            };
            ((Graphic) this.m_HintText).rectTransform.sizeDelta = sizeDelta8;
            ((Graphic) this.m_HintBg).rectTransform.sizeDelta = sizeDelta8 + new Vector2(20f, 10f);
            ((Graphic) this.m_HintBg).rectTransform.anchoredPosition = new Vector2(51f, 143f);
            break;
          }
          break;
        }
        break;
      case 9:
        this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(12023U);
        ((Graphic) this.m_HintBg).rectTransform.sizeDelta = ((Graphic) this.m_HintText).rectTransform.sizeDelta with
        {
          y = this.m_HintText.preferredHeight
        } + new Vector2(20f, 10f);
        ((Graphic) this.m_HintBg).rectTransform.anchoredPosition = new Vector2(51f, 143f);
        break;
      case 10:
        this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(12020U);
        ((Graphic) this.m_HintBg).rectTransform.sizeDelta = ((Graphic) this.m_HintText).rectTransform.sizeDelta with
        {
          y = this.m_HintText.preferredHeight
        } + new Vector2(20f, 10f);
        ((Graphic) this.m_HintBg).rectTransform.anchoredPosition = new Vector2(51f, 143f);
        break;
      case 11:
        flag = false;
        if (this.m_MapPointID >= 0 && this.m_MapPointID < DataManager.MapDataController.LayoutMapInfo.Length)
        {
          POINT_KIND mapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) this.m_MapPointID);
          MapPoint mapPoint5 = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
          if ((int) mapPoint5.tableID < DataManager.MapDataController.PlayerPointTable.Length && mapInfoPointKind == POINT_KIND.PK_CITY && !this.IsNpcCastleType(POINT_KIND.PK_CITY, mapPoint5.tableID))
          {
            if (DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && DataManager.MapDataController.IsEnemy(DataManager.MapDataController.PlayerPointTable[(int) mapPoint5.tableID].kingdomID))
              return;
            byte cityOutward = (byte) DataManager.MapDataController.PlayerPointTable[(int) mapPoint5.tableID].cityOutward;
            this.m_Str[46].ClearString();
            this.m_Str[46].StringToFormat(GUIManager.Instance.BuildingData.castleSkin.GetCastleSkinName(cityOutward));
            this.m_Str[46].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9690U));
            this.m_HintText.text = this.m_Str[46].ToString();
            ((Graphic) this.m_HintBg).rectTransform.sizeDelta = ((Graphic) this.m_HintText).rectTransform.sizeDelta with
            {
              y = this.m_HintText.preferredHeight
            } + new Vector2(20f, 10f);
            ((Graphic) this.m_HintBg).rectTransform.anchoredPosition = new Vector2(51f, 143f);
            flag = true;
            break;
          }
          break;
        }
        break;
      case 12:
        this.m_Str[46].ClearString();
        if (this.m_MapPointID >= 0 && this.m_MapPointID < DataManager.MapDataController.LayoutMapInfo.Length)
        {
          MapPoint mapPoint6 = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
          if ((int) mapPoint6.tableID < DataManager.MapDataController.PlayerPointTable.Length)
          {
            this.m_Str[46].StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) DataManager.Instance.TitleDataF.GetRecordByKey((ushort) DataManager.MapDataController.PlayerPointTable[(int) mapPoint6.tableID].nobilityTitle).StringID));
            this.m_Str[46].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11152U));
            this.m_HintText.text = this.m_Str[46].ToString();
            Vector2 sizeDelta9 = ((Graphic) this.m_HintText).rectTransform.sizeDelta with
            {
              y = this.m_HintText.preferredHeight
            };
            ((Graphic) this.m_HintText).rectTransform.sizeDelta = sizeDelta9;
            ((Graphic) this.m_HintBg).rectTransform.sizeDelta = sizeDelta9 + new Vector2(20f, 10f);
            ((Graphic) this.m_HintBg).rectTransform.anchoredPosition = new Vector2(51f, 143f);
            break;
          }
          break;
        }
        break;
      case 13:
        this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(14583U);
        Vector2 sizeDelta10 = ((Graphic) this.m_HintText).rectTransform.sizeDelta with
        {
          y = this.m_HintText.preferredHeight
        };
        ((Graphic) this.m_HintText).rectTransform.sizeDelta = sizeDelta10;
        ((Graphic) this.m_HintBg).rectTransform.sizeDelta = sizeDelta10 + new Vector2(20f, 10f);
        ((Graphic) this.m_HintBg).rectTransform.anchoredPosition = new Vector2(88f, -35f);
        break;
      case 14:
        Vector2 upsetPos = sender.Parm2 < (byte) 0 || sender.Parm2 >= (byte) 4 ? new Vector2(-53f, 0.0f) : new Vector2(-5f, 0.0f);
        ushort stateSkillIdByIndex = DataManager.MapDataController.getStateSkillIDByIndex((byte) 1, sender.Parm2);
        byte skillLevelByIndex = DataManager.MapDataController.getStateSkillLevelByIndex((byte) 1, sender.Parm2);
        GUIManager.Instance.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.State, (ushort) 0, stateSkillIdByIndex, skillLevelByIndex, upsetPos, UIButtonHint.ePosition.LeftSide);
        return;
    }
    this.m_HintPanel.gameObject.SetActive(flag);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    this.m_HintPanel.gameObject.SetActive(false);
    GUIManager.Instance.m_Hint.Hide(true);
  }

  public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS = null)
  {
    if (this.m_SearchInput == (byte) 0)
    {
      this.m_Str[32].ClearString();
      this.m_Str[32].IntToFormat(mValue);
      this.m_Str[32].AppendFormat("{0}");
      ((Transform) this.m_SearchPanel).GetChild(8).GetChild(0).GetComponent<UIText>().text = this.m_Str[32].ToString();
      ((Transform) this.m_SearchPanel).GetChild(8).GetChild(0).GetComponent<UIText>().SetAllDirty();
      ((Transform) this.m_SearchPanel).GetChild(8).GetChild(0).GetComponent<UIText>().cachedTextGenerator.Invalidate();
    }
    if (this.m_SearchInput == (byte) 1)
    {
      this.m_Str[33].ClearString();
      this.m_Str[33].IntToFormat(mValue);
      this.m_Str[33].AppendFormat("{0}");
      ((Transform) this.m_SearchPanel).GetChild(9).GetChild(0).GetComponent<UIText>().text = this.m_Str[33].ToString();
      ((Transform) this.m_SearchPanel).GetChild(9).GetChild(0).GetComponent<UIText>().SetAllDirty();
      ((Transform) this.m_SearchPanel).GetChild(9).GetChild(0).GetComponent<UIText>().cachedTextGenerator.Invalidate();
    }
    if (this.m_SearchInput != (byte) 2)
      return;
    this.m_Str[34].ClearString();
    this.m_Str[34].IntToFormat(mValue);
    this.m_Str[34].AppendFormat("{0}");
    ((Transform) this.m_SearchPanel).GetChild(10).GetChild(0).GetComponent<UnityEngine.UI.Text>().text = this.m_Str[34].ToString();
    ((Graphic) ((Transform) this.m_SearchPanel).GetChild(10).GetChild(0).GetComponent<UnityEngine.UI.Text>()).SetAllDirty();
    ((Transform) this.m_SearchPanel).GetChild(10).GetChild(0).GetComponent<UnityEngine.UI.Text>().cachedTextGenerator.Invalidate();
  }

  private bool IsInKvk(bool bExceptRanking = false)
  {
    return bExceptRanking ? ActivityManager.Instance.IsInKvK((ushort) 0, true) : ActivityManager.Instance.IsInKvK(DataManager.MapDataController.FocusKingdomID != (ushort) 0 ? DataManager.MapDataController.FocusKingdomID : DataManager.MapDataController.OtherKingdomData.kingdomID);
  }

  private bool IsInKvkSelf()
  {
    return ActivityManager.Instance.IsInKvK(DataManager.MapDataController.OtherKingdomData.kingdomID);
  }

  private bool IsInWorldWarSelf()
  {
    return (int) DataManager.MapDataController.FocusKingdomID == (int) ActivityManager.Instance.KOWKingdomID;
  }

  private void SetWonderOwnerText_WorldWar(CString str, MapYolk mapYolk)
  {
    CString cstring = StringManager.Instance.StaticString1024();
    CString Name = StringManager.Instance.StaticString1024();
    CString Tag = StringManager.Instance.StaticString1024();
    bool flag = (int) DataManager.MapDataController.FocusKingdomID == (int) ActivityManager.Instance.KOWKingdomID;
    if ((int) DataManager.MapDataController.kingdomData.kingdomID == (int) mapYolk.LeaderHomeKingdomID)
    {
      if (GUIManager.Instance.IsArabic)
      {
        Name.Append(mapYolk.WonderLeader);
        Tag.Append(mapYolk.WonderAllianceTag);
        GUIManager.Instance.FormatRoleNameForChat(cstring, Name, Tag, (ushort) 0, GUIManager.Instance.IsArabic);
        str.StringToFormat(cstring);
      }
      else
      {
        CString tmpS = StringManager.Instance.StaticString1024();
        tmpS.ClearString();
        if (mapYolk.WonderAllianceTag[0] == char.MinValue || mapYolk.WonderAllianceTag.Length == 0)
        {
          tmpS.StringToFormat(mapYolk.WonderLeader);
          tmpS.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7007U));
        }
        else
        {
          tmpS.StringToFormat(mapYolk.WonderAllianceTag);
          tmpS.StringToFormat(mapYolk.WonderLeader);
          tmpS.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9315U));
        }
        str.StringToFormat(tmpS);
      }
      if (flag)
      {
        if (mapYolk.WonderState == (byte) 0)
        {
          if (mapYolk.WonderID == (byte) 0)
            str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11036U));
          else
            str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11156U));
        }
        else
        {
          if (mapYolk.WonderState != (byte) 1)
            return;
          str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11037U));
        }
      }
      else
        str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7230U));
    }
    else
    {
      if (GUIManager.Instance.IsArabic)
      {
        Name.Append(mapYolk.WonderLeader);
        Tag.Append(mapYolk.WonderAllianceTag);
        GUIManager.Instance.FormatRoleNameForChat(cstring, Name, Tag, mapYolk.LeaderHomeKingdomID, GUIManager.Instance.IsArabic);
        str.StringToFormat(cstring);
      }
      else
      {
        str.IntToFormat((long) mapYolk.LeaderHomeKingdomID);
        str.StringToFormat(mapYolk.WonderAllianceTag);
        str.StringToFormat(mapYolk.WonderLeader);
      }
      if (flag)
      {
        if (mapYolk.WonderState == (byte) 0)
        {
          if (mapYolk.WonderID == (byte) 0)
            str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11020U));
          else
            str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11097U));
        }
        else
        {
          if (mapYolk.WonderState != (byte) 1)
            return;
          str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(11021U));
        }
      }
      else
        str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9905U));
    }
  }

  private void SetTitleIcon(MapPoint nowMapPoint)
  {
    byte num = 0;
    if ((int) nowMapPoint.tableID >= DataManager.MapDataController.PlayerPointTable.Length || nowMapPoint.tableID < (ushort) 0)
      return;
    WORLD_PLAYER_DESIGNATION worldTitle = DataManager.MapDataController.PlayerPointTable[(int) nowMapPoint.tableID].worldTitle;
    KINGDOM_DESIGNATION kingdomTitle = DataManager.MapDataController.PlayerPointTable[(int) nowMapPoint.tableID].kingdomTitle;
    TitleData recordByKey;
    if (worldTitle != WORLD_PLAYER_DESIGNATION.WKD_NULL)
    {
      ((Component) this.m_WorldTitleIcon).gameObject.SetActive(true);
      recordByKey = DataManager.Instance.TitleDataW.GetRecordByKey((ushort) worldTitle);
      this.m_WorldTitleIcon.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.WorldTitle);
      ((MaskableGraphic) this.m_WorldTitleIcon).material = GUIManager.Instance.GetTitleMaterial();
      ++num;
    }
    else
      ((Component) this.m_WorldTitleIcon).gameObject.SetActive(false);
    if (kingdomTitle != KINGDOM_DESIGNATION.KD_NONE)
    {
      ((Component) this.m_TitleIcon).gameObject.SetActive(true);
      recordByKey = DataManager.Instance.TitleData.GetRecordByKey((ushort) DataManager.MapDataController.PlayerPointTable[(int) nowMapPoint.tableID].kingdomTitle);
      this.m_TitleIcon.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID);
      ((MaskableGraphic) this.m_TitleIcon).material = GUIManager.Instance.GetTitleMaterial();
      num += (byte) 2;
    }
    else
      ((Component) this.m_TitleIcon).gameObject.SetActive(false);
    switch (num)
    {
      case 0:
        this.m_IDTextRt.anchoredPosition = this.m_IDText.ArabicFixPos(((Graphic) this.m_IDText).rectTransform.anchoredPosition with
        {
          x = 138f
        });
        break;
      case 1:
        ((Graphic) this.m_WorldTitleIcon).rectTransform.anchoredPosition = ((Graphic) this.m_WorldTitleIcon).rectTransform.anchoredPosition with
        {
          x = 149.5f
        };
        this.m_IDTextRt.anchoredPosition = this.m_IDText.ArabicFixPos(((Graphic) this.m_IDText).rectTransform.anchoredPosition with
        {
          x = 174f
        });
        this.m_IDTextRt.sizeDelta = ((Graphic) this.m_IDText).rectTransform.sizeDelta with
        {
          x = 227f
        };
        this.m_IDText.UpdateArabicPos();
        break;
      case 2:
        ((Graphic) this.m_TitleIcon).rectTransform.anchoredPosition = ((Graphic) this.m_TitleIcon).rectTransform.anchoredPosition with
        {
          x = 149.5f
        };
        this.m_IDTextRt.anchoredPosition = this.m_IDText.ArabicFixPos(((Graphic) this.m_IDText).rectTransform.anchoredPosition with
        {
          x = 174f
        });
        this.m_IDTextRt.sizeDelta = ((Graphic) this.m_IDText).rectTransform.sizeDelta with
        {
          x = 227f
        };
        this.m_IDText.UpdateArabicPos();
        break;
      case 3:
        ((Graphic) this.m_WorldTitleIcon).rectTransform.anchoredPosition = ((Graphic) this.m_WorldTitleIcon).rectTransform.anchoredPosition with
        {
          x = 149.5f
        };
        ((Graphic) this.m_TitleIcon).rectTransform.anchoredPosition = ((Graphic) this.m_TitleIcon).rectTransform.anchoredPosition with
        {
          x = 195.5f
        };
        this.m_IDTextRt.anchoredPosition = this.m_IDText.ArabicFixPos(((Graphic) this.m_IDText).rectTransform.anchoredPosition with
        {
          x = 223f
        });
        this.m_IDTextRt.sizeDelta = ((Graphic) this.m_IDText).rectTransform.sizeDelta with
        {
          x = 178f
        };
        this.m_IDText.UpdateArabicPos();
        break;
    }
  }

  private bool IsSameKingdom()
  {
    return (int) DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID].tableID < DataManager.MapDataController.PlayerPointTable.Length && (int) DataManager.MapDataController.FocusKingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID;
  }

  private byte NoCommander(MapYolk mapYolk)
  {
    if (mapYolk.AllianceKingdomID == ushort.MaxValue || mapYolk.OwnerName == null || mapYolk.WonderLeader == null)
      return 0;
    return mapYolk.OwnerName[0] == char.MinValue && mapYolk.WonderLeader[0] != char.MinValue ? (byte) 2 : (byte) 1;
  }

  private byte ShowCanonizedBtnByTableID(ushort tableID)
  {
    if ((int) tableID >= DataManager.MapDataController.PlayerPointTable.Length || tableID < (ushort) 0)
      return 0;
    byte num = 0;
    byte[] numArray = new byte[4]
    {
      (byte) 0,
      (byte) 1,
      (byte) 2,
      (byte) 4
    };
    bool flag1 = DataManager.MapDataController.IsKing() && (int) DataManager.MapDataController.PlayerPointTable[(int) tableID].kingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID && KINGDOM_DESIGNATION.KD_1 != DataManager.MapDataController.PlayerPointTable[(int) tableID].kingdomTitle;
    bool flag2 = DataManager.MapDataController.IsKingdomChief() && (int) DataManager.MapDataController.PlayerPointTable[(int) tableID].kingdomID == (int) DataManager.MapDataController.kingdomData.kingdomID && DataManager.MapDataController.PlayerPointTable[(int) tableID].kingdomTitle != KINGDOM_DESIGNATION.KD_1 && KINGDOM_DESIGNATION.KD_20 != DataManager.MapDataController.PlayerPointTable[(int) tableID].kingdomTitle;
    bool flag3 = DataManager.MapDataController.IsWorldKing() && DataManager.MapDataController.PlayerPointTable[(int) tableID].worldTitle != WORLD_PLAYER_DESIGNATION.WKD_1;
    bool flag4 = DataManager.MapDataController.IsWorldChief() && DataManager.MapDataController.PlayerPointTable[(int) tableID].worldTitle != WORLD_PLAYER_DESIGNATION.WKD_1 && DataManager.MapDataController.PlayerPointTable[(int) tableID].worldTitle != WORLD_PLAYER_DESIGNATION.WKD_14;
    bool flag5 = DataManager.MapDataController.IsNobilityKing() && DataManager.MapDataController.PlayerPointTable[(int) tableID].nobilityTitle != (byte) 1 && ActivityManager.Instance.CheckCanonizationNoility(DataManager.MapDataController.PlayerPointTable[(int) tableID].kingdomID);
    bool flag6 = DataManager.MapDataController.IsNobilityChief() && DataManager.MapDataController.PlayerPointTable[(int) tableID].nobilityTitle != (byte) 1 && DataManager.MapDataController.PlayerPointTable[(int) tableID].nobilityTitle != (byte) 14 && ActivityManager.Instance.CheckCanonizationNoility(DataManager.MapDataController.PlayerPointTable[(int) tableID].kingdomID);
    if (flag1 || flag2)
      num += numArray[1];
    if (flag3 || flag4)
      num += numArray[2];
    if (flag5 || flag6)
      num += numArray[3];
    return num;
  }

  private string GetPKNoneGroundTitle(int _MapPointID)
  {
    int num1 = 0;
    if (this.m_Door.TileMapController.TileMapInfoEx != null && _MapPointID >= 0 && _MapPointID < this.m_Door.TileMapController.TileMapInfoEx.Length && this.m_Door.TileMapController.TileMapInfoEx[_MapPointID] != (byte) 0)
    {
      int num2 = (int) this.m_Door.TileMapController.TileMapInfoEx[_MapPointID];
      uint ID = 0;
      switch (num2)
      {
        case 1:
          ID = 6219U;
          break;
        case 2:
          ID = 6220U;
          break;
        case 3:
          ID = 6221U;
          break;
        case 4:
          ID = 6222U;
          break;
        case 5:
          ID = 6223U;
          break;
        case 6:
          ID = 6218U;
          break;
        case 7:
          ID = 6218U;
          break;
        case 8:
          ID = 6218U;
          break;
        case 9:
          ID = 6218U;
          break;
        case 192:
          ID = 6214U;
          break;
        case 193:
          ID = 6215U;
          break;
        case 194:
          ID = 6216U;
          break;
        case 195:
          ID = 6217U;
          break;
        case 196:
          ID = 6218U;
          break;
      }
      return DataManager.Instance.mStringTable.GetStringByID(ID);
    }
    if (_MapPointID >= 0 && _MapPointID < this.m_Door.TileMapController.TileMapInfo.Length)
      num1 = (int) this.m_Door.TileMapController.TileMapInfo[_MapPointID];
    return DataManager.Instance.mStringTable.GetStringByID((uint) (6101 + num1));
  }

  public bool CompareMapPointID(int id) => id == this.m_MapPointID;

  private CITY_PROPERTY GetCastleType(ushort tableID)
  {
    return (int) tableID < DataManager.MapDataController.PlayerPointTable.Length ? DataManager.MapDataController.PlayerPointTable[(int) tableID].cityProperty : CITY_PROPERTY.CP_PLAYER;
  }

  private bool IsNpcCastleType(POINT_KIND infoKind, ushort tableID)
  {
    return infoKind == POINT_KIND.PK_CITY && this.GetCastleType(tableID) == CITY_PROPERTY.CP_NPC;
  }

  private void SetPlayerCastle(int MapPointID, bool bDisbaleColor = false)
  {
    Vector2 zero = Vector2.zero;
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[MapPointID];
    int length = DataManager.MapDataController.PlayerPointTable.Length;
    if ((int) mapPoint.tableID >= length)
      return;
    ushort capitalFlag = (ushort) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].capitalFlag;
    ushort level = (ushort) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].level;
    POINT_KIND mapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) MapPointID);
    this.m_eGroundInfoKind = EGroundInfoKind.Castle;
    ((Component) this.m_CampPanel).gameObject.SetActive(true);
    zero.Set(416f, 441f);
    this.m_Panel.sizeDelta = zero;
    zero.Set(0.0f, -124f);
    this.m_Panel.anchoredPosition = zero;
    zero.Set(377f, 126f);
    this.m_GroundTextBGRect.sizeDelta = zero;
    zero.Set(20f, -94f);
    this.m_GroundTextBGRect.anchoredPosition = zero;
    zero.Set(0.0f, -163f);
    this.m_LocationRt.anchoredPosition = zero;
    zero.Set(0.0f, -185f);
    this.m_ChatBtnRt.anchoredPosition = zero;
    this.m_GroundTitle.text = string.Empty;
    bool flag1 = DataManager.MapDataController.OtherKingdomData.kingdomPeriod == KINGDOM_PERIOD.KP_KVK && DataManager.MapDataController.IsEnemy(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomID);
    this.m_Door.TileMapController.getTileMapSprite(ref this.m_BGIcon, mapInfoPointKind, (int) level, !flag1 ? DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].cityOutward : CITY_OUTWARD.CO_EMEMY);
    ((Graphic) this.m_BGIcon).rectTransform.pivot = new Vector2((float) (0.5 + -(double) this.m_BGIcon.sprite.bounds.center.x / (double) this.m_BGIcon.sprite.bounds.extents.x / 2.0), 0.0f);
    float num = 1f;
    RectTransform component = this.m_CityOutwardLevelTf.GetComponent<RectTransform>();
    if ((double) ((Transform) ((Graphic) this.m_BGIcon).rectTransform).localScale.x > 0.0)
      num = 1f / ((Transform) ((Graphic) this.m_BGIcon).rectTransform).localScale.x;
    ((Transform) component).localScale = new Vector3(num, num, num);
    ((MaskableGraphic) this.m_BGIcon).material = this.TileMapMat;
    this.m_BGIcon.SetNativeSize();
    ((Behaviour) this.m_BGIconMask).enabled = false;
    if (flag1)
      this.SetCityOutwardLevel((byte) 0);
    else
      this.SetCityOutwardLevel(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].cityOutwardLevel);
    switch (this.OwnerKind)
    {
      case 1:
        ((Component) this.m_ButtonRect1).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect2).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect3).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect11).gameObject.SetActive(true);
        zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
        this.m_ButtonRect1.anchoredPosition = zero;
        this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4557U);
        bool flag2 = GUIManager.Instance.BuildingData.castleSkin.CheckShowCastleSkin();
        ((Component) this.m_ButtonRect10).gameObject.SetActive(flag2);
        ((Component) this.m_CustmCastleExclamation).gameObject.SetActive(GUIManager.Instance.BuildingData.castleSkin.CheckShowExclamation());
        zero.Set(this.m_ButtonRect10.anchoredPosition.x, -300f);
        this.m_ButtonRect10.anchoredPosition = zero;
        this.m_ButtonText10.text = DataManager.Instance.mStringTable.GetStringByID(9682U);
        if (flag2)
        {
          zero.Set(this.m_ButtonRect11.anchoredPosition.x, -350f);
          this.m_ButtonRect11.anchoredPosition = zero;
          this.m_ButtonText11.text = DataManager.Instance.mStringTable.GetStringByID(2760U);
          break;
        }
        zero.Set(this.m_ButtonRect11.anchoredPosition.x, -300f);
        this.m_ButtonRect11.anchoredPosition = zero;
        this.m_ButtonText11.text = DataManager.Instance.mStringTable.GetStringByID(2760U);
        break;
      case 2:
        if (this.bHaveAlly_Self)
        {
          if (this.bHaveAlly)
          {
            ((Component) this.m_ButtonRect1).gameObject.SetActive(false);
            ((Component) this.m_ButtonRect2).gameObject.SetActive(true);
            ((Component) this.m_ButtonRect3).gameObject.SetActive(true);
            ((Component) this.m_ButtonRect4).gameObject.SetActive(true);
            ((Component) this.m_ButtonRect5).gameObject.SetActive(true);
            zero.Set(this.m_ButtonRect2.anchoredPosition.x, -250f);
            this.m_ButtonRect2.anchoredPosition = zero;
            this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4535U);
            zero.Set(this.m_ButtonRect3.anchoredPosition.x, -250f);
            this.m_ButtonRect3.anchoredPosition = zero;
            this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4554U);
            zero.Set(this.m_ButtonRect4.anchoredPosition.x, -309f);
            this.m_ButtonRect4.anchoredPosition = zero;
            zero.Set(this.m_ButtonRect5.anchoredPosition.x, -309f);
            this.m_ButtonRect5.anchoredPosition = zero;
            break;
          }
          if (DataManager.Instance.RoleAlliance.Rank >= AllianceRank.RANK4)
          {
            ((Component) this.m_ButtonRect1).gameObject.SetActive(true);
            zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
            this.m_ButtonRect1.anchoredPosition = zero;
            this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4556U);
            zero.Set(this.m_ButtonRect2.anchoredPosition.x, -300f);
            this.m_ButtonRect2.anchoredPosition = zero;
            this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4535U);
            zero.Set(this.m_ButtonRect3.anchoredPosition.x, -300f);
            this.m_ButtonRect3.anchoredPosition = zero;
            this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4554U);
            zero.Set(this.m_ButtonRect4.anchoredPosition.x, -350f);
            this.m_ButtonRect4.anchoredPosition = zero;
            zero.Set(this.m_ButtonRect5.anchoredPosition.x, -350f);
            this.m_ButtonRect5.anchoredPosition = zero;
          }
          else
          {
            ((Component) this.m_ButtonRect1).gameObject.SetActive(false);
            zero.Set(this.m_ButtonRect2.anchoredPosition.x, -250f);
            this.m_ButtonRect2.anchoredPosition = zero;
            this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4535U);
            zero.Set(this.m_ButtonRect3.anchoredPosition.x, -250f);
            this.m_ButtonRect3.anchoredPosition = zero;
            this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4554U);
            zero.Set(this.m_ButtonRect4.anchoredPosition.x, -309f);
            this.m_ButtonRect4.anchoredPosition = zero;
            zero.Set(this.m_ButtonRect5.anchoredPosition.x, -309f);
            this.m_ButtonRect5.anchoredPosition = zero;
          }
          ((Component) this.m_ButtonRect2).gameObject.SetActive(true);
          ((Component) this.m_ButtonRect3).gameObject.SetActive(true);
          ((Component) this.m_ButtonRect4).gameObject.SetActive(true);
          ((Component) this.m_ButtonRect5).gameObject.SetActive(true);
          break;
        }
        if (this.bHaveAlly)
        {
          ((Component) this.m_ButtonRect1).gameObject.SetActive(true);
          ((Component) this.m_ButtonRect2).gameObject.SetActive(true);
          ((Component) this.m_ButtonRect3).gameObject.SetActive(true);
          ((Component) this.m_ButtonRect4).gameObject.SetActive(true);
          ((Component) this.m_ButtonRect5).gameObject.SetActive(true);
          zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
          this.m_ButtonRect1.anchoredPosition = zero;
          this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4555U);
          zero.Set(this.m_ButtonRect2.anchoredPosition.x, -300f);
          this.m_ButtonRect2.anchoredPosition = zero;
          this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4535U);
          zero.Set(this.m_ButtonRect3.anchoredPosition.x, -300f);
          this.m_ButtonRect3.anchoredPosition = zero;
          this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4554U);
          zero.Set(this.m_ButtonRect4.anchoredPosition.x, -350f);
          this.m_ButtonRect4.anchoredPosition = zero;
          zero.Set(this.m_ButtonRect5.anchoredPosition.x, -350f);
          this.m_ButtonRect5.anchoredPosition = zero;
          break;
        }
        ((Component) this.m_ButtonRect1).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect2).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect3).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect4).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect5).gameObject.SetActive(true);
        zero.Set(this.m_ButtonRect2.anchoredPosition.x, -250f);
        this.m_ButtonRect2.anchoredPosition = zero;
        this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4535U);
        zero.Set(this.m_ButtonRect3.anchoredPosition.x, -250f);
        this.m_ButtonRect3.anchoredPosition = zero;
        this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4554U);
        zero.Set(this.m_ButtonRect4.anchoredPosition.x, -309f);
        this.m_ButtonRect4.anchoredPosition = zero;
        zero.Set(this.m_ButtonRect5.anchoredPosition.x, -309f);
        this.m_ButtonRect5.anchoredPosition = zero;
        break;
      case 3:
        ((Component) this.m_ButtonRect1).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect2).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect3).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect6).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect7).gameObject.SetActive(true);
        zero.Set(this.m_ButtonRect2.anchoredPosition.x, -309f);
        this.m_ButtonRect2.anchoredPosition = zero;
        this.m_ButtonText2.text = DataManager.Instance.mStringTable.GetStringByID(4552U);
        zero.Set(this.m_ButtonRect3.anchoredPosition.x, -309f);
        this.m_ButtonRect3.anchoredPosition = zero;
        this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4553U);
        zero.Set(this.m_ButtonRect6.anchoredPosition.x, -250f);
        this.m_ButtonRect6.anchoredPosition = zero;
        this.m_ButtonText6.text = DataManager.Instance.mStringTable.GetStringByID(4535U);
        zero.Set(this.m_ButtonRect7.anchoredPosition.x, -250f);
        this.m_ButtonRect7.anchoredPosition = zero;
        this.m_ButtonText7.text = DataManager.Instance.mStringTable.GetStringByID(9739U);
        break;
    }
    this.SetCampInfo(this.m_MapPointID, this.OwnerKind, bDisbaleColor);
    if (((int) (ushort) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].capitalFlag & 8) != 0)
      this.OpenRewardPanel(true);
    else
      this.OpenRewardPanel(false);
    if (this.ShowCanonizedBtnByTableID(mapPoint.tableID) != (byte) 0)
      this.OpenTitlePanel(true);
    else
      this.OpenTitlePanel(false);
  }

  private void SetNpcCastle(int MapPointID, bool bDisbaleColor = false)
  {
    Vector2 zero = Vector2.zero;
    bool flag = DataManager.Instance.RoleAlliance.Id != 0U;
    int num = 0;
    ulong x = 0;
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[MapPointID];
    if ((int) mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
    {
      num = (int) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].level;
      x = DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].power;
      if (!bDisbaleColor)
        this.SetCastleIcon(DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].portraitID);
    }
    POINT_KIND mapInfoPointKind = DataManager.MapDataController.GetLayoutMapInfoPointKind((uint) MapPointID);
    this.m_eGroundInfoKind = EGroundInfoKind.NpcCastle;
    this.m_Door.TileMapController.getTileMapSprite(ref this.m_BGIcon, mapInfoPointKind, num, DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].cityOutward);
    ((MaskableGraphic) this.m_BGIcon).material = this.TileMapMat;
    this.m_BGIcon.SetNativeSize();
    ((Behaviour) this.m_BGIconMask).enabled = false;
    ((Component) this.m_CampPanel).gameObject.SetActive(false);
    ((Component) this.m_NpcCastlePanel).gameObject.SetActive(true);
    zero.Set(416f, 441f);
    this.m_Panel.sizeDelta = zero;
    zero.Set(0.0f, -124f);
    this.m_Panel.anchoredPosition = zero;
    zero.Set(377f, 126f);
    this.m_GroundTextBGRect.sizeDelta = zero;
    zero.Set(20f, -94f);
    this.m_GroundTextBGRect.anchoredPosition = zero;
    zero.Set(0.0f, -163f);
    this.m_LocationRt.anchoredPosition = zero;
    zero.Set(0.0f, -185f);
    this.m_ChatBtnRt.anchoredPosition = zero;
    this.m_GroundTitle.text = string.Empty;
    this.m_Str[47].ClearString();
    this.m_Str[47].IntToFormat((long) num);
    this.m_Str[47].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021U));
    this.m_NpcCastleIDText.text = this.m_Str[47].ToString();
    this.m_Str[48].ClearString();
    this.m_Str[48].uLongToFormat(x, bNumber: true);
    this.m_Str[48].AppendFormat("{0}");
    this.m_NpcCastleStrengthText.text = this.m_Str[48].ToString();
    this.m_NpcCastleInfoText.text = DataManager.Instance.mStringTable.GetStringByID(12022U);
    if (flag)
      ((Behaviour) this.m_NpcCastleInfoText).enabled = true;
    else
      ((Behaviour) this.m_NpcCastleInfoText).enabled = false;
    if (bDisbaleColor)
    {
      this.m_NpcCastleIcon.SetActive(false);
      ((Graphic) this.m_NpcCastleStrengthText).color = Color.gray;
    }
    else
    {
      this.m_NpcCastleIcon.SetActive(true);
      ((Graphic) this.m_NpcCastleStrengthText).color = Color.white;
    }
    if (flag)
      this.SetGroundInfoBtnState(UIGroundInfo.BtnState.NpcCastle);
    else
      this.SetGroundInfoBtnState(UIGroundInfo.BtnState.NpcCastle_NoAllIance);
  }

  private void SetNpcCastleTimeInfo()
  {
    if (this.m_ResStartTime == ActivityManager.Instance.NPCCityCountTime)
      return;
    this.m_ResStartTime = ActivityManager.Instance.NPCCityCountTime;
    this.m_Str[25].ClearString();
    GameConstants.GetTimeString(this.m_Str[25], (uint) this.m_ResStartTime, hideTimeIfDays: true, showZeroHour: false);
    this.m_NpcCastleTimeText.text = this.m_Str[25].ToString();
    this.m_NpcCastleTimeText.SetAllDirty();
    this.m_NpcCastleTimeText.cachedTextGenerator.Invalidate();
  }

  private void SetCastleIcon(ushort id)
  {
    if (id == (ushort) 0)
      return;
    this.m_NpcCastleHeadID = DataManager.Instance.HeroTable.GetRecordByKey(id).Graph;
    this.UpdateCastleIcon();
  }

  public int Get0NpcCastleHeadID() => (int) this.m_NpcCastleHeadID;

  public void UpdateCastleIcon()
  {
    this.DestroyNpcCastleIcon();
    if (this.m_NpcCastleHeadID < (ushort) 50000)
    {
      if ((Object) this.m_NpcCastleDLImg == (Object) null && (Object) this.m_TempNpcCastleDLImg == (Object) null)
      {
        this.m_TempNpcCastleDLImg = new GameObject("NpcCastleDLImg");
        ((MaskableGraphic) this.m_TempNpcCastleDLImg.AddComponent<Image>()).material = GUIManager.Instance.m_IconSpriteAsset.GetMaterial();
        this.m_TempNpcCastleDLImg.transform.SetParent(this.m_NpcCastleIconBone);
        RectTransform component = this.m_TempNpcCastleDLImg.GetComponent<RectTransform>();
        component.anchorMax = new Vector2(1f, 1f);
        component.anchorMin = new Vector2(0.0f, 0.0f);
        component.offsetMax = new Vector2(0.0f, 0.0f);
        component.offsetMin = new Vector2(0.0f, 0.0f);
        this.m_TempNpcCastleDLImg.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        this.m_TempNpcCastleDLImg.transform.localScale = new Vector3(1f, 1f, 1f);
      }
      this.m_NpcCastleDLImg = this.m_TempNpcCastleDLImg;
      this.m_NpcCastleDLImg.SetActive(true);
      this.m_NpcCastleDLImg.GetComponent<Image>().sprite = GUIManager.Instance.m_IconSpriteAsset.LoadSprite(this.m_NpcCastleHeadID);
    }
    else
    {
      if ((Object) this.m_TempNpcCastleDLImg != (Object) null)
        this.m_TempNpcCastleDLImg.SetActive(false);
      this.m_Str[49].ClearString();
      this.m_Str[49].IntToFormat((long) this.m_NpcCastleHeadID);
      this.m_Str[49].AppendFormat("UI/MapNPCHead_{0}");
      if (!AssetManager.GetAssetBundleDownload(this.m_Str[49], AssetPath.UI, AssetType.NPCHead, this.m_NpcCastleHeadID))
        return;
      AssetBundle assetBundle = AssetManager.GetAssetBundle(this.m_Str[49], out this.m_NpcCastleHeadAssetKey);
      if (!((Object) assetBundle != (Object) null))
        return;
      this.m_NpcCastleDLImg = Object.Instantiate(assetBundle.mainAsset) as GameObject;
      if (!((Object) this.m_NpcCastleDLImg != (Object) null))
        return;
      this.m_NpcCastleDLImg.transform.SetParent(this.m_NpcCastleIconBone);
      RectTransform component = this.m_NpcCastleDLImg.GetComponent<RectTransform>();
      component.anchorMax = new Vector2(1f, 1f);
      component.anchorMin = new Vector2(0.0f, 0.0f);
      component.offsetMax = new Vector2(0.0f, 0.0f);
      component.offsetMin = new Vector2(0.0f, 0.0f);
      this.m_NpcCastleDLImg.gameObject.SetActive(true);
      this.m_NpcCastleDLImg.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      this.m_NpcCastleDLImg.transform.localScale = new Vector3(1f, 1f, 1f);
    }
  }

  private void DestroyNpcCastleIcon()
  {
    if (this.m_NpcCastleHeadAssetKey == 0)
      return;
    AssetManager.UnloadAssetBundle(this.m_NpcCastleHeadAssetKey, false);
    this.m_NpcCastleHeadAssetKey = 0;
    if (!((Object) this.m_NpcCastleDLImg != (Object) null))
      return;
    Object.Destroy((Object) this.m_NpcCastleDLImg);
    this.m_NpcCastleDLImg = (GameObject) null;
  }

  private void SetGroundInfoBtnState(UIGroundInfo.BtnState state)
  {
    Vector2 zero = Vector2.zero;
    MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[0];
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
    if ((int) mapPoint.tableID < DataManager.MapDataController.YolkPointTable.Length)
      mapYolk = DataManager.MapDataController.YolkPointTable[(int) mapPoint.tableID];
    bool flag = (int) DataManager.MapDataController.FocusKingdomID == (int) ActivityManager.Instance.KOWKingdomID;
    switch (state)
    {
      case UIGroundInfo.BtnState.WondersInfo_Ally_Peace:
        ((Component) this.m_ButtonRect1).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect2).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect3).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect6).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect7).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect8).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect9).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect10).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect11).gameObject.SetActive(false);
        zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
        this.m_ButtonRect1.anchoredPosition = zero;
        if (mapYolk.WonderID == (byte) 0)
        {
          this.m_Str[41].ClearString();
          this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
          this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231U));
        }
        else
        {
          this.m_Str[41].ClearString();
          if (flag)
            this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
          else
            this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309U));
          this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231U));
        }
        this.m_ButtonText1.text = this.m_Str[41].ToString();
        this.m_ButtonText1.SetAllDirty();
        this.m_ButtonText1.cachedTextGenerator.Invalidate();
        break;
      case UIGroundInfo.BtnState.WondersInfo_Ally_Fight:
        ((Component) this.m_ButtonRect1).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect2).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect3).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect6).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect7).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect8).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect9).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect10).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect11).gameObject.SetActive(false);
        zero.Set(this.m_ButtonRect2.anchoredPosition.x, -250f);
        this.m_ButtonRect2.anchoredPosition = zero;
        zero.Set(this.m_ButtonRect3.anchoredPosition.x, -250f);
        this.m_ButtonRect3.anchoredPosition = zero;
        if (mapYolk.WonderID == (byte) 0)
        {
          this.m_Str[41].ClearString();
          this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
          this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231U));
        }
        else
        {
          this.m_Str[41].ClearString();
          if (flag)
            this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
          else
            this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309U));
          this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231U));
        }
        this.m_ButtonText2.text = this.m_Str[41].ToString();
        this.m_ButtonText2.SetAllDirty();
        this.m_ButtonText2.cachedTextGenerator.Invalidate();
        this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(7234U);
        switch (this.NoCommander(mapYolk))
        {
          case 0:
            ((Component) this.m_ButtonRect3).gameObject.SetActive(false);
            ((Component) this.m_ButtonRect9).gameObject.SetActive(false);
            return;
          case 2:
            ((Component) this.m_ButtonRect3).gameObject.SetActive(false);
            ((Component) this.m_ButtonRect9).gameObject.SetActive(true);
            zero.Set(this.m_ButtonRect9.anchoredPosition.x, -250f);
            this.m_ButtonRect9.anchoredPosition = zero;
            this.m_ButtonText9.text = DataManager.Instance.mStringTable.GetStringByID(9910U);
            return;
          default:
            return;
        }
      case UIGroundInfo.BtnState.WondersInfo_NA_Peace:
        ((Component) this.m_ButtonRect1).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect2).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect3).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect6).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect7).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect8).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect9).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect10).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect11).gameObject.SetActive(false);
        zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
        this.m_ButtonRect1.anchoredPosition = zero;
        if (mapYolk.WonderID == (byte) 0)
        {
          this.m_Str[41].ClearString();
          this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
          this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231U));
        }
        else
        {
          this.m_Str[41].ClearString();
          if (flag)
            this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
          else
            this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309U));
          this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231U));
        }
        this.m_ButtonText1.text = this.m_Str[41].ToString();
        this.m_ButtonText1.SetAllDirty();
        this.m_ButtonText1.cachedTextGenerator.Invalidate();
        break;
      case UIGroundInfo.BtnState.WondersInfo_NA_Fight:
        ((Component) this.m_ButtonRect1).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect2).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect3).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect4).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect5).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect6).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect7).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect8).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect9).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect10).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect11).gameObject.SetActive(false);
        zero.Set(this.m_ButtonRect2.anchoredPosition.x, -250f);
        this.m_ButtonRect2.anchoredPosition = zero;
        if (mapYolk.WonderID == (byte) 0)
        {
          this.m_Str[41].ClearString();
          this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
          this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231U));
        }
        else
        {
          this.m_Str[41].ClearString();
          if (flag)
            this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
          else
            this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309U));
          this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231U));
        }
        this.m_ButtonText2.text = this.m_Str[41].ToString();
        this.m_ButtonText2.SetAllDirty();
        this.m_ButtonText2.cachedTextGenerator.Invalidate();
        zero.Set(this.m_ButtonRect3.anchoredPosition.x, -250f);
        this.m_ButtonRect3.anchoredPosition = zero;
        this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4554U);
        zero.Set(this.m_ButtonRect4.anchoredPosition.x, -309f);
        this.m_ButtonRect4.anchoredPosition = zero;
        zero.Set(this.m_ButtonRect5.anchoredPosition.x, -309f);
        this.m_ButtonRect5.anchoredPosition = zero;
        break;
      case UIGroundInfo.BtnState.WondersInfo_Army_Peace:
        ((Component) this.m_ButtonRect1).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect2).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect3).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect6).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect7).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect8).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect9).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect10).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect11).gameObject.SetActive(false);
        zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
        this.m_ButtonRect1.anchoredPosition = zero;
        if (mapYolk.WonderID == (byte) 0)
        {
          this.m_Str[41].ClearString();
          this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
          this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231U));
        }
        else
        {
          this.m_Str[41].ClearString();
          if (flag)
            this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
          else
            this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309U));
          this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231U));
        }
        this.m_ButtonText1.text = this.m_Str[41].ToString();
        this.m_ButtonText1.SetAllDirty();
        this.m_ButtonText1.cachedTextGenerator.Invalidate();
        break;
      case UIGroundInfo.BtnState.WondersInfo_Army_Fight:
        ((Component) this.m_ButtonRect1).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect2).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect3).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect6).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect7).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect8).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect9).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect10).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect11).gameObject.SetActive(false);
        zero.Set(this.m_ButtonRect2.anchoredPosition.x, -250f);
        this.m_ButtonRect2.anchoredPosition = zero;
        zero.Set(this.m_ButtonRect3.anchoredPosition.x, -250f);
        this.m_ButtonRect3.anchoredPosition = zero;
        if (mapYolk.WonderID == (byte) 0)
        {
          this.m_Str[41].ClearString();
          this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
          this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231U));
        }
        else
        {
          this.m_Str[41].ClearString();
          if (flag)
            this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
          else
            this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309U));
          this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231U));
        }
        this.m_ButtonText2.text = this.m_Str[41].ToString();
        this.m_ButtonText2.SetAllDirty();
        this.m_ButtonText2.cachedTextGenerator.Invalidate();
        this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(7234U);
        break;
      case UIGroundInfo.BtnState.WondersInfo_NoAllIance:
        ((Component) this.m_ButtonRect1).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect2).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect3).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect6).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect7).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect8).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect9).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect10).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect11).gameObject.SetActive(false);
        zero.Set(this.m_ButtonRect1.anchoredPosition.x, -250f);
        this.m_ButtonRect1.anchoredPosition = zero;
        if (mapYolk.WonderID == (byte) 0)
        {
          this.m_Str[41].ClearString();
          this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
          this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231U));
        }
        else
        {
          this.m_Str[41].ClearString();
          if (flag)
            this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
          else
            this.m_Str[41].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309U));
          this.m_Str[41].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7231U));
        }
        this.m_ButtonText1.text = this.m_Str[41].ToString();
        this.m_ButtonText1.SetAllDirty();
        this.m_ButtonText1.cachedTextGenerator.Invalidate();
        break;
      case UIGroundInfo.BtnState.NpcCastle:
        ((Component) this.m_ButtonRect3).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect4).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect1).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect2).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect6).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect7).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect8).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect9).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect10).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect11).gameObject.SetActive(false);
        zero.Set(this.m_ButtonRect3.anchoredPosition.x, -295f);
        this.m_ButtonRect3.anchoredPosition = zero;
        zero.Set(this.m_ButtonRect4.anchoredPosition.x, -295f);
        this.m_ButtonRect4.anchoredPosition = zero;
        this.m_ButtonText3.text = DataManager.Instance.mStringTable.GetStringByID(4554U);
        break;
      case UIGroundInfo.BtnState.NpcCastle_NoAllIance:
        ((Component) this.m_ButtonRect1).gameObject.SetActive(true);
        ((Component) this.m_ButtonRect2).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect3).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect4).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect5).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect6).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect7).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect8).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect9).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect10).gameObject.SetActive(false);
        ((Component) this.m_ButtonRect11).gameObject.SetActive(false);
        zero.Set(this.m_ButtonRect1.anchoredPosition.x, -295f);
        this.m_ButtonRect1.anchoredPosition = zero;
        this.m_ButtonText1.text = DataManager.Instance.mStringTable.GetStringByID(4601U);
        break;
    }
  }

  private bool SetExpressionButton(int ownerKind, POINT_KIND pointKind)
  {
    bool flag = true;
    if ((pointKind == POINT_KIND.PK_FOOD || pointKind == POINT_KIND.PK_STONE || pointKind == POINT_KIND.PK_IRON || pointKind == POINT_KIND.PK_WOOD || pointKind == POINT_KIND.PK_GOLD || pointKind == POINT_KIND.PK_CRYSTAL || pointKind == POINT_KIND.PK_SP_MINE || pointKind == POINT_KIND.PK_CITY || pointKind == POINT_KIND.PK_CAMP) && ownerKind == 1)
    {
      ((Component) this.m_TeamExpressionBtn).gameObject.SetActive(true);
      ((Component) this.m_ExpressionBtn).gameObject.SetActive(true);
    }
    else if (pointKind == POINT_KIND.PK_YOLK && (ownerKind == 3 || ownerKind == 1))
    {
      ((Component) this.m_TeamExpressionBtn).gameObject.SetActive(true);
      ((Component) this.m_ExpressionBtn).gameObject.SetActive(true);
    }
    else if (pointKind == POINT_KIND.PK_UNDEFINED && ownerKind == 1 && !this.CheckAttackAction())
    {
      ((Component) this.m_TeamExpressionBtn).gameObject.SetActive(true);
      ((Component) this.m_ExpressionBtn).gameObject.SetActive(true);
    }
    else if (pointKind == POINT_KIND.PK_UNDEFINED && ownerKind == 3 && DataManager.MapDataController.MapLineTable != null && this.m_MapPointID < DataManager.MapDataController.MapLineTable.Count && !GameConstants.IsPetSkillLine(this.m_MapPointID) && DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag == (byte) 12)
    {
      ((Component) this.m_TeamExpressionBtn).gameObject.SetActive(true);
      ((Component) this.m_ExpressionBtn).gameObject.SetActive(true);
    }
    else
    {
      flag = false;
      ((Component) this.m_TeamExpressionBtn).gameObject.SetActive(false);
      ((Component) this.m_ExpressionBtn).gameObject.SetActive(false);
    }
    if (flag)
      this.SetExclamationmark(DataManager.Instance.CheckShowOnGroundInfo());
    return flag;
  }

  public void SetExclamationmark(bool show)
  {
    this.m_Exclamationmark.gameObject.SetActive(show);
    this.m_TeamExclamationmark.gameObject.SetActive(show);
  }

  private bool CheckAttackAction()
  {
    if (GameManager.ActiveGameplay is CHAOS activeGameplay && (Object) activeGameplay.realmController != (Object) null && activeGameplay.realmController.mapLineController != null && DataManager.MapDataController.MapLineTable != null && this.m_MapPointID < DataManager.MapDataController.MapLineTable.Count && this.IsAttackActionLineFlag(DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag))
    {
      LineNode nodeByGameObject = activeGameplay.realmController.mapLineController.GetNodeByGameObject(DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineObject);
      if (nodeByGameObject != null && nodeByGameObject.action != ELineAction.NORMAL)
        return true;
    }
    return false;
  }

  private bool IsAttackActionLineFlag(byte lineFlag)
  {
    return !GameConstants.IsPetSkillLine(this.m_MapPointID) && (DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag == (byte) 23 || DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag == (byte) 24 || DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag == (byte) 25 || DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag == (byte) 26 || DataManager.MapDataController.MapLineTable[this.m_MapPointID].lineFlag == (byte) 27);
  }

  private void OpenExpressionUI()
  {
    GUIManager.Instance.OpenMenu(EGUIWindow.UIEmojiSelect, 1, bSecWindow: true);
  }

  private void SetTitleIcon()
  {
    float[] numArray1 = new float[3]{ 78.5f, 133f, 184f };
    float[] numArray2 = new float[3]{ 319.5f, 266f, 214f };
    ((Component) this.m_WorldTitleIcon).gameObject.SetActive(false);
    ((Component) this.m_NobilityTitleIcon).gameObject.SetActive(false);
    ((Component) this.m_TitleIcon).gameObject.SetActive(false);
    this.m_RankTf.gameObject.SetActive(false);
    this.m_VipTf.gameObject.SetActive(false);
    byte[] numArray3 = new byte[3];
    byte num1 = 0;
    MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.m_MapPointID];
    if ((int) mapPoint.tableID < DataManager.MapDataController.PlayerPointTable.Length)
    {
      WORLD_PLAYER_DESIGNATION worldTitle = DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].worldTitle;
      KINGDOM_DESIGNATION kingdomTitle = DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomTitle;
      byte nobilityTitle = DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].nobilityTitle;
      byte allianceRank = DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].allianceRank;
      byte vip = DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].VIP;
      if (worldTitle == WORLD_PLAYER_DESIGNATION.WKD_1)
        numArray3[(int) num1++] = (byte) 1;
      if (nobilityTitle == (byte) 1)
        numArray3[(int) num1++] = (byte) 2;
      if (kingdomTitle == KINGDOM_DESIGNATION.KD_1)
        numArray3[(int) num1++] = (byte) 3;
      if ((int) num1 < numArray3.Length && worldTitle != WORLD_PLAYER_DESIGNATION.WKD_NULL && worldTitle != WORLD_PLAYER_DESIGNATION.WKD_1)
        numArray3[(int) num1++] = (byte) 4;
      if ((int) num1 < numArray3.Length && nobilityTitle != (byte) 0 && nobilityTitle != (byte) 1)
        numArray3[(int) num1++] = (byte) 5;
      if ((int) num1 < numArray3.Length && kingdomTitle != KINGDOM_DESIGNATION.KD_NONE && kingdomTitle != KINGDOM_DESIGNATION.KD_1)
        numArray3[(int) num1++] = (byte) 6;
      if ((int) num1 < numArray3.Length && allianceRank > (byte) 0)
        numArray3[(int) num1++] = (byte) 7;
      if ((int) num1 < numArray3.Length && vip > (byte) 0)
      {
        byte[] numArray4 = numArray3;
        int index = (int) num1;
        byte num2 = (byte) (index + 1);
        numArray4[index] = (byte) 8;
      }
      if (worldTitle != WORLD_PLAYER_DESIGNATION.WKD_NULL)
      {
        this.m_WorldTitleIcon.sprite = GUIManager.Instance.LoadTitleSprite(DataManager.Instance.TitleDataW.GetRecordByKey((ushort) worldTitle).IconID, eTitleKind.WorldTitle);
        ((MaskableGraphic) this.m_WorldTitleIcon).material = GUIManager.Instance.GetTitleMaterial();
      }
      if (kingdomTitle != KINGDOM_DESIGNATION.KD_NONE)
      {
        this.m_TitleIcon.sprite = GUIManager.Instance.LoadTitleSprite(DataManager.Instance.TitleData.GetRecordByKey((ushort) DataManager.MapDataController.PlayerPointTable[(int) mapPoint.tableID].kingdomTitle).IconID);
        ((MaskableGraphic) this.m_TitleIcon).material = GUIManager.Instance.GetTitleMaterial();
      }
      if (nobilityTitle != (byte) 0)
      {
        this.m_NobilityTitleIcon.sprite = GUIManager.Instance.LoadTitleSprite(DataManager.Instance.TitleDataF.GetRecordByKey((ushort) nobilityTitle).IconID, eTitleKind.NobilityTitle);
        ((MaskableGraphic) this.m_NobilityTitleIcon).material = GUIManager.Instance.GetTitleMaterial();
      }
    }
    int num3 = 0;
    for (int idx = 0; idx < numArray3.Length; ++idx)
    {
      if (numArray3[idx] != (byte) 0)
      {
        this.SetTitleIcon(idx, numArray3[idx]);
        ++num3;
      }
    }
    int index1 = Mathf.Clamp(num3 - 1, 0, 2);
    ((Graphic) this.m_IDText).rectTransform.sizeDelta = ((Graphic) this.m_IDText).rectTransform.sizeDelta with
    {
      x = numArray2[index1]
    };
    this.m_IDTextRt.anchoredPosition = this.m_IDText.ArabicFixPos(((Graphic) this.m_IDText).rectTransform.anchoredPosition with
    {
      x = numArray1[index1]
    });
  }

  private void SetTitleIcon(int idx, byte type)
  {
    float[] numArray1 = new float[3]{ -153f, -103f, -52.5f };
    float[] numArray2 = new float[3]{ -153f, -103f, -52.5f };
    float[] numArray3 = new float[3]{ -153f, -103f, -52.5f };
    float[] numArray4 = new float[3]{ -153f, -103f, -52.5f };
    float[] numArray5 = new float[3]{ -153f, -103f, -52.5f };
    if (idx >= 3)
      return;
    switch (type)
    {
      case 1:
      case 4:
        ((Component) this.m_WorldTitleIcon).gameObject.SetActive(true);
        ((Graphic) this.m_WorldTitleIcon).rectTransform.anchoredPosition = new Vector2(numArray1[idx], 141f);
        break;
      case 2:
      case 5:
        ((Component) this.m_NobilityTitleIcon).gameObject.SetActive(true);
        ((Graphic) this.m_NobilityTitleIcon).rectTransform.anchoredPosition = new Vector2(numArray2[idx], 141f);
        break;
      case 3:
      case 6:
        ((Component) this.m_TitleIcon).gameObject.SetActive(true);
        ((Graphic) this.m_TitleIcon).rectTransform.anchoredPosition = new Vector2(numArray3[idx], 141f);
        break;
      case 7:
        this.m_RankTf.gameObject.SetActive(true);
        ((RectTransform) this.m_RankTf).anchoredPosition = new Vector2(numArray4[idx], 141f);
        break;
      case 8:
        this.m_VipTf.gameObject.SetActive(true);
        ((RectTransform) this.m_VipTf).anchoredPosition = new Vector2(numArray5[idx], 141f);
        break;
    }
  }

  private void SetCityOutwardLevel(byte level)
  {
    if (level > (byte) 0)
    {
      int num = (int) level - 1;
      if ((bool) (Object) this.m_CityOutwardLevelTf && !this.m_CityOutwardLevelTf.gameObject.activeInHierarchy)
        this.m_CityOutwardLevelTf.gameObject.SetActive(true);
      for (int index = 0; index < this.m_CityOutwardLevelImages.Length; ++index)
      {
        if ((Object) this.m_CityOutwardLevelImages[index] != (Object) null)
        {
          if (index <= num)
          {
            if (!((Component) this.m_CityOutwardLevelImages[index]).gameObject.activeInHierarchy)
              ((Component) this.m_CityOutwardLevelImages[index]).gameObject.SetActive(true);
          }
          else if (((Component) this.m_CityOutwardLevelImages[index]).gameObject.activeInHierarchy)
            ((Component) this.m_CityOutwardLevelImages[index]).gameObject.SetActive(false);
        }
      }
    }
    else
    {
      if (!(bool) (Object) this.m_CityOutwardLevelTf || !this.m_CityOutwardLevelTf.gameObject.activeInHierarchy)
        return;
      this.m_CityOutwardLevelTf.gameObject.SetActive(false);
    }
  }

  private void SetCenterText(Image image, UIText text, float width)
  {
    float num = 10f;
    float x = (float) (((double) width - ((double) ((Graphic) image).rectTransform.sizeDelta.x + (double) text.preferredWidth + (double) num)) / 2.0);
    ((Graphic) image).rectTransform.anchoredPosition = new Vector2(x, ((Graphic) image).rectTransform.anchoredPosition.y);
    ((Graphic) text).rectTransform.anchoredPosition = new Vector2(((Graphic) image).rectTransform.anchoredPosition.x + ((Graphic) image).rectTransform.sizeDelta.x + num, ((Graphic) text).rectTransform.anchoredPosition.y);
  }

  private void SetCenterText(float width, RectTransform rect, Image image)
  {
    float num = 10f;
    UnityEngine.UI.Text component = (UnityEngine.UI.Text) ((Transform) rect).GetChild(0).GetComponent<UIText>();
    float x = (float) (((double) width - ((double) ((Graphic) image).rectTransform.sizeDelta.x + (double) component.preferredWidth + (double) num)) / 2.0);
    ((Graphic) image).rectTransform.anchoredPosition = new Vector2(x, ((Graphic) image).rectTransform.anchoredPosition.y);
    rect.anchoredPosition = new Vector2(rect.anchoredPosition.x + ((Graphic) image).rectTransform.sizeDelta.x + num, ((Graphic) component).rectTransform.anchoredPosition.y);
  }

  private void UpdatemPetNegativeBuff(int mapPointID = 0, bool bHideAllIcon = true)
  {
    if (!((Object) this.m_PetSkillTf != (Object) null) || mapPointID != this.m_MapPointID)
      return;
    byte kind = 1;
    Image component1 = this.m_PetSkillTf.GetChild(0).GetComponent<Image>();
    this.SetOwnerKind();
    RectTransform component2 = this.m_PetSkillTf.GetComponent<RectTransform>();
    Vector2 vector2 = component2.anchoredPosition with
    {
      y = !((Component) this.m_PetSkillUse).gameObject.activeInHierarchy ? -79f : -30f
    };
    component2.anchoredPosition = vector2;
    if (bHideAllIcon)
    {
      for (byte index = 0; (int) index < this.m_PetNegativeBuff.Length; ++index)
        ((Component) this.m_PetNegativeBuff[(int) index]).gameObject.SetActive(false);
      if (!(bool) (Object) component1)
        return;
      ((Component) component1).gameObject.SetActive(false);
    }
    else
    {
      int stateCountByKind = (int) DataManager.MapDataController.getStateCountByKind(kind);
      for (byte index = 0; (int) index < this.m_PetNegativeBuff.Length; ++index)
      {
        if ((int) index < stateCountByKind)
        {
          ushort stateSkillIdByIndex = DataManager.MapDataController.getStateSkillIDByIndex(kind, index);
          this.m_PetNegativeBuff[(int) index].sprite = PetManager.Instance.LoadPetSkillIcon(stateSkillIdByIndex);
          ((MaskableGraphic) this.m_PetNegativeBuff[(int) index]).material = GUIManager.Instance.GetSkillMaterial();
          ((Component) this.m_PetNegativeBuff[(int) index]).gameObject.SetActive(true);
        }
        else
        {
          this.m_PetNegativeBuff[(int) index].sprite = PetManager.Instance.LoadPetSkillIcon((ushort) 0);
          ((MaskableGraphic) this.m_PetNegativeBuff[(int) index]).material = GUIManager.Instance.GetSkillMaterial();
          ((Component) this.m_PetNegativeBuff[(int) index]).gameObject.SetActive(false);
        }
      }
      if (!(bool) (Object) component1)
        return;
      vector2 = ((Graphic) component1).rectTransform.sizeDelta with
      {
        x = stateCountByKind <= 4 ? 56f : 106f
      };
      ((Graphic) component1).rectTransform.sizeDelta = vector2;
      if (stateCountByKind <= 0)
        return;
      ((Component) component1).gameObject.SetActive(true);
    }
  }

  private void SetNegativePetSkillBtn(bool bCheckShieldKind = false)
  {
    byte kind = 0;
    ((Component) this.m_PetSkillUse).gameObject.SetActive(this.OwnerKind == 2 && PetBuff.ShowActive((byte) 1));
    RectTransform component1 = ((Component) this.m_PetSkillUse).gameObject.GetComponent<RectTransform>();
    component1.anchoredPosition = !((Object) this.m_ButtonRect1 != (Object) null) || !((Component) this.m_ButtonRect1).gameObject.activeSelf ? new Vector2(component1.anchoredPosition.x, -56f) : new Vector2(component1.anchoredPosition.x, -105f);
    Image component2 = ((Component) this.m_PetSkillUse).transform.GetChild(0).GetComponent<Image>();
    Image component3 = ((Component) this.m_PetSkillUse).transform.GetChild(1).GetComponent<Image>();
    if ((bool) (Object) component2)
    {
      ((Graphic) component2).color = Color.white;
      if ((int) DataManager.MapDataController.FocusKingdomID != (int) DataManager.MapDataController.OtherKingdomData.kingdomID)
      {
        if ((bool) (Object) component3)
          ((Behaviour) component3).enabled = false;
        this.m_PetSkillUse.m_BtnID3 = 7744;
        ((Graphic) component2).color = Color.gray;
        return;
      }
    }
    if (!(bool) (Object) component3)
      return;
    if (DataManager.MapDataController.getStateCountByKind(kind) > (byte) 0 && bCheckShieldKind)
    {
      ((Component) component3).gameObject.SetActive(true);
      this.m_PetSkillUse.m_BtnID3 = 12572;
    }
    else if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbyMapID(this.m_MapPointID)) == 0.0)
    {
      ((Component) component3).gameObject.SetActive(false);
      this.m_PetSkillUse.m_BtnID3 = 12563;
    }
    else
    {
      ((Component) component3).gameObject.SetActive(false);
      this.m_PetSkillUse.m_BtnID3 = 0;
    }
  }

  private enum BtnState
  {
    None,
    WondersInfo_Ally_Peace,
    WondersInfo_Ally_Fight,
    WondersInfo_NA_Peace,
    WondersInfo_NA_Fight,
    WondersInfo_Army_Peace,
    WondersInfo_Army_Fight,
    WondersInfo_NoAllIance,
    NpcCastle,
    NpcCastle_NoAllIance,
    Max,
  }

  public struct _BookmarkSwitch
  {
    private RectTransform SizeTrans;
    private RectTransform ConfirmTrans;
    private GameObject SelTitleObj;
    private GameObject[] SelObjs;

    public _BookmarkSwitch(RectTransform rectTrans)
    {
      this.SizeTrans = ((Transform) rectTrans).GetChild(0) as RectTransform;
      this.SelTitleObj = ((Transform) rectTrans).GetChild(6).gameObject;
      this.SelObjs = new GameObject[4];
      for (int index = 0; index < 3; ++index)
        this.SelObjs[index] = ((Transform) rectTrans).GetChild(10 + index).gameObject;
      this.SelObjs[3] = ((Transform) rectTrans).GetChild(15).gameObject;
      this.ConfirmTrans = ((Transform) rectTrans).GetChild(13) as RectTransform;
    }

    public void Switch(UIGroundInfo._BookmarkSwitch.eType bookType)
    {
      switch (bookType)
      {
        case UIGroundInfo._BookmarkSwitch.eType.AddBookmark:
          this.SelTitleObj.SetActive(true);
          if (DataManager.Instance.RoleAlliance.Id > 0U && DataManager.Instance.RoleAlliance.Rank >= AllianceRank.RANK4)
          {
            this.SizeTrans.sizeDelta = new Vector2(416f, 498f);
            for (int index = 0; index < this.SelObjs.Length; ++index)
              this.SelObjs[index].SetActive(true);
            this.ConfirmTrans.anchoredPosition = new Vector2(-1f, -215f);
            break;
          }
          this.SizeTrans.sizeDelta = new Vector2(416f, 453f);
          for (int index = 0; index < this.SelObjs.Length - 1; ++index)
            this.SelObjs[index].SetActive(true);
          this.SelObjs[3].SetActive(false);
          this.ConfirmTrans.anchoredPosition = new Vector2(-1f, -170f);
          break;
        case UIGroundInfo._BookmarkSwitch.eType.ModifyBookmark:
          this.SelTitleObj.SetActive(true);
          this.SizeTrans.sizeDelta = new Vector2(416f, 453f);
          for (int index = 0; index < this.SelObjs.Length - 1; ++index)
            this.SelObjs[index].SetActive(true);
          this.SelObjs[3].SetActive(false);
          this.ConfirmTrans.anchoredPosition = new Vector2(-1f, -170f);
          break;
        case UIGroundInfo._BookmarkSwitch.eType.ModifyAlliancemark:
          this.SizeTrans.sizeDelta = new Vector2(416f, 266f);
          this.SelTitleObj.SetActive(false);
          for (int index = 0; index < this.SelObjs.Length; ++index)
            this.SelObjs[index].SetActive(false);
          this.ConfirmTrans.anchoredPosition = new Vector2(-1f, 17f);
          break;
      }
    }

    public enum eType
    {
      AddBookmark,
      ModifyBookmark,
      ModifyAlliancemark,
    }
  }
}
