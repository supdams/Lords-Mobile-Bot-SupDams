// Decompiled with JetBrains decompiler
// Type: UIBattle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Text;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIBattle : 
  GUIWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnUpDownHandler,
  IUIHIBtnDrag
{
  private const int MaxIcon = 5;
  private const int MaxCheckpoint = 3;
  private const int MaxDeltatime = 90;
  private const int MaxChallengeIcons = 8;
  private Transform m_transform;
  private StringBuilder sb = new StringBuilder();
  private Transform alertBlock;
  private Image alertBlock_T;
  private Image alertBlock_B;
  private Image alertBlock_L;
  private Image alertBlock_R;
  public RectTransform[] btnRt = new RectTransform[5];
  private RectTransform[] hpSlidersRt = new RectTransform[5];
  private RectTransform[] mpSlidersRt = new RectTransform[5];
  private RectTransform[] selectImageRt = new RectTransform[5];
  private Transform[] maxMpSlider = new Transform[5];
  private Transform[] weekHpSlider = new Transform[5];
  private Slider[] ChallegeBloodRestrictSL = new Slider[5];
  private Image[] hpImage = new Image[5];
  public UIHIBtn[] buttons = new UIHIBtn[5];
  private Image[] deadImages = new Image[5];
  private Slider[] hpSliders = new Slider[5];
  private Slider[] mpSliders = new Slider[5];
  private Image[] selectImage = new Image[5];
  private uTweenAlpha[] selectTween = new uTweenAlpha[5];
  private UIButton kingBtn;
  private Image kingBar;
  private UIButton nextButton1;
  private UIButton nextButton2;
  private Sprite nextSprite;
  private Transform itemTextTf;
  private Transform checkpointTextTf;
  private Transform infoImg0;
  private Transform infoImg2;
  private Transform infoImg3;
  private UIText timeText;
  private UIText itemText;
  private UIText checkpointText;
  private UIButton pauseButton;
  public UIButton autoButtonUp;
  private Material iconMat;
  private UIButton debugButton;
  private UISpritesArray spriteArray;
  private UIButton CameraBtn;
  private Transform PausePanel;
  private float deltaTime = 90f;
  private float tempDeltaTime;
  private bool isPause;
  private bool bCountDown = true;
  private int itemCount;
  public BattleController bc;
  public byte[] indexPosMap = new byte[5]
  {
    (byte) 2,
    (byte) 1,
    (byte) 3,
    (byte) 0,
    (byte) 4
  };
  private IconScaleValue[] iconScaleValue = new IconScaleValue[5];
  private SliserTime[] IconSliserTime = new SliserTime[5];
  private UIText m_CenterMsgText;
  private Image m_CenterMsgBg;
  private Transform m_CenterMsgTf;
  private Transform m_IPhoneXPPanel;
  private float m_CenterMsgTime;
  private bool bShowCenterMsg;
  private float m_CenterMsgColorA;
  private float m_CenterCountDownTime = 2f;
  private RectTransform m_CountDownRect;
  private UIText m_CountDownText;
  private float m_CounDownTick;
  private float m_CountDownScale;
  private float m_CountDownAColor;
  private bool bShowCountDownText;
  private float m_PreCountDownNum;
  private bool bArenaMod;
  private bool bNpcBossMod;
  private Transform npcHpTf;
  private Image npcHpImg;
  private UIText npcBossID;
  private UIText npcBossHpValue;
  private int bossDataIdx;
  private byte bossLv;
  private ushort bossID;
  private uint bossMaxHp;
  private uint bossCurHp;
  private ushort MaxTime = 90;
  private float effectTime = 0.35f;
  private float effectTime2 = 0.05f;
  private float delay = 0.15f;
  private float mpValueTime = 1f;
  public Transform projectorTrans;
  public bool ultraSkillWorking;
  public bool bProjectorMode;
  public int projectorType;
  private Vector3 curUltraSkillerPos = Vector3.zero;
  public Ray rayCache = new Ray();
  private Transform challengePausePanel;
  private UIText text_ChallengeTitle;
  private UIText text_ChallengeContinuance;
  private UIText text_ChallengeExit;
  private UIText text_ChallengeGgain;
  private UIText text_ChallengeHint;
  private BattleChallengeIcon[] battleChallengeIcons = new BattleChallengeIcon[8];
  private ushort ConditionKey;
  private bool bChallegeMode;
  private ushort[] ChallegeCheckPointTimeRule = new ushort[3];
  private ushort RestrictBlood;
  private int CheckPoint;
  private int MaxStr = 6;
  private CString[] m_Str;
  private int[] MaxStrLen = new int[6]
  {
    30,
    30,
    30,
    30,
    30,
    300
  };

  private void Start()
  {
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.m_Str = new CString[this.MaxStr];
    for (int index = 0; index < this.MaxStr; ++index)
    {
      int StringLength = index >= this.MaxStrLen.Length ? 30 : this.MaxStrLen[index];
      this.m_Str[index] = StringManager.Instance.SpawnString(StringLength);
    }
    this.m_transform = this.transform;
    this.bc = GameManager.ActiveGameplay as BattleController;
    this.iconMat = GUIManager.Instance.m_IconSpriteAsset.GetMaterial();
    if (this.bc.BattleType == EBattleType.PLAYBACK)
      this.bNpcBossMod = true;
    if (this.bc.BattleType == EBattleType.PVP)
      this.bArenaMod = true;
    this.alertBlock = this.m_transform.GetChild(0);
    this.alertBlock_T = this.m_transform.GetChild(0).GetChild(0).GetComponent<Image>();
    this.alertBlock_B = this.m_transform.GetChild(0).GetChild(1).GetComponent<Image>();
    this.alertBlock_R = this.m_transform.GetChild(0).GetChild(2).GetComponent<Image>();
    this.alertBlock_L = this.m_transform.GetChild(0).GetChild(3).GetComponent<Image>();
    this.InitChallegeMode();
    this.InitIcon();
    if (this.bNpcBossMod)
    {
      this.bossLv = (byte) (arg1 >> 16);
      this.bossID = (ushort) (arg1 & (int) ushort.MaxValue);
      this.bossDataIdx = arg2;
      MapMonster recordByKey = DataManager.MapDataController.MapMonsterTable.GetRecordByKey(this.bossID);
      this.m_Str[3].ClearString();
      this.m_Str[3].IntToFormat((long) this.bossLv);
      this.m_Str[3].StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.NameID));
      this.m_Str[3].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(883U));
      this.npcBossID.text = this.m_Str[3].ToString();
      this.npcBossID.SetAllDirty();
      this.npcBossID.cachedTextGenerator.Invalidate();
      if (this.bc != null && this.bossDataIdx < 20)
      {
        this.bossCurHp = this.bc.enemyAttr[this.bossDataIdx].CUR_HP;
        this.bossMaxHp = this.bc.enemyAttr[this.bossDataIdx].MAX_HP;
      }
      this.SetNpcBossHP(this.bossCurHp, this.bossMaxHp);
      this.itemTextTf.gameObject.SetActive(false);
      this.checkpointTextTf.gameObject.SetActive(false);
      this.infoImg0.gameObject.SetActive(false);
      this.infoImg2.gameObject.SetActive(false);
      this.infoImg3.gameObject.SetActive(false);
      this.autoButtonUp.image.sprite = this.spriteArray.GetSprite(1);
    }
    if (this.bArenaMod)
    {
      this.itemTextTf.gameObject.SetActive(false);
      this.checkpointTextTf.gameObject.SetActive(false);
      this.infoImg0.gameObject.SetActive(false);
      this.infoImg2.gameObject.SetActive(false);
      this.infoImg3.gameObject.SetActive(false);
      this.autoButtonUp.image.sprite = this.spriteArray.GetSprite(1);
    }
    this.npcHpTf.gameObject.SetActive(this.bNpcBossMod);
    GUIManager.Instance.BattleOpenChatBox();
    this.CheckAutoBattleStatus();
    if (BattleController.IsDareMode)
      this.SetBattleChallengeIcons();
    GUIManager.Instance.CheckBattleAttackState();
  }

  private void InitChallegeMode()
  {
    if (!BattleController.IsDareMode)
      return;
    StageManager stageDataController = DataManager.StageDataController;
    this.bChallegeMode = true;
    byte currentNodus = stageDataController.currentNodus;
    LevelEX bycurrentPointId = stageDataController.GetLevelEXBycurrentPointID((ushort) 0);
    ushort InKey;
    switch (currentNodus)
    {
      case 1:
        InKey = bycurrentPointId.NodusOneID;
        break;
      case 2:
        InKey = bycurrentPointId.NodusTwoID;
        break;
      default:
        InKey = bycurrentPointId.NodusThrID;
        break;
    }
    StageConditionData recordByKey = stageDataController.StageConditionDataTable.GetRecordByKey(InKey);
    int length = recordByKey.ConditionArray.Length;
    for (int index = 0; index < length; ++index)
    {
      if (recordByKey.ConditionArray[index].ConditionID == (byte) 4)
        this.RestrictBlood = recordByKey.ConditionArray[index].FactorA;
      else if (recordByKey.ConditionArray[index].ConditionID == (byte) 7 && recordByKey.ConditionArray[index].FactorA >= (ushort) 1 && recordByKey.ConditionArray[index].FactorA <= (ushort) 3)
        this.ChallegeCheckPointTimeRule[(int) recordByKey.ConditionArray[index].FactorA - 1] = recordByKey.ConditionArray[index].FactorB;
    }
  }

  public override void OnClose()
  {
    for (int index = 0; index < this.MaxStr; ++index)
    {
      StringManager.Instance.DeSpawnString(this.m_Str[index]);
      this.m_Str[index] = (CString) null;
    }
    Time.timeScale = 1f;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.transform.GetChild(27).GetComponent<UIText>();
    if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.transform.GetChild(28).GetComponent<UIText>();
    if ((Object) component2 != (Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.transform.GetChild(29).GetComponent<UIText>();
    if ((Object) component3 != (Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.transform.GetChild(36).GetComponent<UIText>();
    if ((Object) component4 != (Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    UIText component5 = this.transform.GetChild(37).GetChild(1).GetComponent<UIText>();
    if ((Object) component5 != (Object) null && ((Behaviour) component5).enabled)
    {
      ((Behaviour) component5).enabled = false;
      ((Behaviour) component5).enabled = true;
    }
    UIText component6 = this.transform.GetChild(37).GetChild(2).GetComponent<UIText>();
    if ((Object) component6 != (Object) null && ((Behaviour) component6).enabled)
    {
      ((Behaviour) component6).enabled = false;
      ((Behaviour) component6).enabled = true;
    }
    UIText component7 = this.transform.GetChild(38).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((Object) component7 != (Object) null && ((Behaviour) component7).enabled)
    {
      ((Behaviour) component7).enabled = false;
      ((Behaviour) component7).enabled = true;
    }
    UIText component8 = this.transform.GetChild(38).GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((Object) component8 != (Object) null && ((Behaviour) component8).enabled)
    {
      ((Behaviour) component8).enabled = false;
      ((Behaviour) component8).enabled = true;
    }
    UIText component9 = this.transform.GetChild(38).GetChild(2).GetChild(0).GetComponent<UIText>();
    if ((Object) component9 != (Object) null && ((Behaviour) component9).enabled)
    {
      ((Behaviour) component9).enabled = false;
      ((Behaviour) component9).enabled = true;
    }
    UIText component10 = this.transform.GetChild(40).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((Object) component10 != (Object) null && ((Behaviour) component10).enabled)
    {
      ((Behaviour) component10).enabled = false;
      ((Behaviour) component10).enabled = true;
    }
    if ((Object) this.text_ChallengeContinuance != (Object) null && ((Behaviour) this.text_ChallengeContinuance).enabled)
    {
      ((Behaviour) this.text_ChallengeContinuance).enabled = false;
      ((Behaviour) this.text_ChallengeContinuance).enabled = true;
    }
    if ((Object) this.text_ChallengeExit != (Object) null && ((Behaviour) this.text_ChallengeExit).enabled)
    {
      ((Behaviour) this.text_ChallengeExit).enabled = false;
      ((Behaviour) this.text_ChallengeExit).enabled = true;
    }
    if ((Object) this.text_ChallengeGgain != (Object) null && ((Behaviour) this.text_ChallengeGgain).enabled)
    {
      ((Behaviour) this.text_ChallengeGgain).enabled = false;
      ((Behaviour) this.text_ChallengeGgain).enabled = true;
    }
    if ((Object) this.text_ChallengeTitle != (Object) null && ((Behaviour) this.text_ChallengeTitle).enabled)
    {
      ((Behaviour) this.text_ChallengeTitle).enabled = false;
      ((Behaviour) this.text_ChallengeTitle).enabled = true;
    }
    if ((Object) this.text_ChallengeHint != (Object) null && ((Behaviour) this.text_ChallengeHint).enabled)
    {
      ((Behaviour) this.text_ChallengeHint).enabled = false;
      ((Behaviour) this.text_ChallengeHint).enabled = true;
    }
    this.RefreshUIHIBtnText();
  }

  private void RefreshUIHIBtnText()
  {
    if (this.buttons == null)
      return;
    for (int index = 0; index < this.buttons.Length; ++index)
    {
      if ((Object) this.buttons[index] != (Object) null)
        this.buttons[index].Refresh_FontTexture();
    }
  }

  private void InitIcon()
  {
    byte num;
    HeroBattleData[] heroBattleDataArray;
    if (this.bc.BattleType == EBattleType.PLAYBACK)
    {
      num = GUIManager.Instance.WM_HeroCount;
      heroBattleDataArray = GUIManager.Instance.WM_HeroData;
    }
    else if (this.bc.BattleType == EBattleType.PVP)
    {
      heroBattleDataArray = new HeroBattleData[5];
      num = (byte) 0;
      for (int index = 0; index < 5; ++index)
      {
        heroBattleDataArray[index] = (HeroBattleData) ArenaManager.Instance.ArenaPlayingData.MyHeroData[index];
        if (heroBattleDataArray[index].HeroID != (ushort) 0)
          ++num;
      }
    }
    else
    {
      num = DataManager.Instance.heroCount;
      heroBattleDataArray = DataManager.Instance.heroBattleData;
    }
    for (int i = 0; i < 5; ++i)
    {
      int battlePosId = this.GetBattlePosID(i);
      bool flag1 = battlePosId < (int) num;
      ushort heroId = heroBattleDataArray[battlePosId].HeroID;
      Transform child1 = this.m_transform.GetChild(13 + i).GetChild(0);
      this.btnRt[i] = child1.GetComponent<RectTransform>();
      this.buttons[i] = child1.GetComponent<UIHIBtn>();
      Transform child2 = child1.GetChild(0);
      this.selectImageRt[i] = child2.GetComponent<RectTransform>();
      this.selectImage[i] = child2.GetComponent<Image>();
      ((Component) this.selectImage[i]).gameObject.AddComponent<IgnoreRaycast>();
      ((Component) this.selectImage[i]).gameObject.SetActive(false);
      this.selectTween[i] = child2.GetComponent<uTweenAlpha>();
      Transform child3 = this.m_transform.GetChild(13 + i).GetChild(0).GetChild(1);
      this.deadImages[i] = child3.GetComponent<Image>();
      ((Component) this.deadImages[i]).gameObject.SetActive(false);
      ((MaskableGraphic) this.buttons[i].image).material = this.iconMat;
      this.buttons[i].interactable = true;
      this.buttons[i].m_UpDownHandler = (IUIHIBtnUpDownHandler) this;
      this.buttons[i].m_DHandler = (IUIHIBtnDrag) this;
      this.buttons[i].m_BtnID1 = i;
      ((Component) this.buttons[i]).transform.parent.gameObject.SetActive(flag1);
      GUIManager.Instance.InitianHeroItemImg(((Component) this.buttons[i]).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
      CurHeroData data;
      if (DataManager.Instance.curHeroData.ContainsKey((uint) heroId))
      {
        data = DataManager.Instance.curHeroData[(uint) heroId];
        this.CheckChalleneHeroRule(ref data);
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.buttons[i]).transform, eHeroOrItem.Hero, data.ID, data.Star, data.Enhance, (int) data.Level);
      }
      else
      {
        data = new CurHeroData();
        bool flag2 = false;
        for (int index = 0; index < DataManager.Instance.curTempHeroData.Length; ++index)
        {
          if ((int) DataManager.Instance.curTempHeroData[index].ID == (int) heroId)
          {
            data = DataManager.Instance.curTempHeroData[index];
            this.CheckChalleneHeroRule(ref data);
            flag2 = true;
            break;
          }
        }
        if (flag2)
          GUIManager.Instance.ChangeHeroItemImg(((Component) this.buttons[i]).transform, eHeroOrItem.Hero, data.ID, data.Star, data.Enhance, (int) data.Level);
      }
      ((Component) this.deadImages[i]).transform.SetSiblingIndex(3);
      ((Transform) this.selectImageRt[i]).SetAsLastSibling();
      Transform child4 = this.m_transform.transform.GetChild(3 + i);
      this.hpSlidersRt[i] = child4.GetComponent<RectTransform>();
      this.hpSliders[i] = child4.GetComponent<Slider>();
      ((Component) this.hpSliders[i]).gameObject.SetActive(flag1);
      this.weekHpSlider[i] = child4.GetChild(0).GetChild(0).GetChild(0);
      this.hpImage[i] = child4.GetChild(0).GetChild(0).GetComponent<Image>();
      this.ChallegeBloodRestrictSL[i] = child4.GetChild(0).GetChild(1).GetComponent<Slider>();
      if (this.bChallegeMode && this.RestrictBlood > (ushort) 0)
      {
        this.ChallegeBloodRestrictSL[i].value = (float) this.RestrictBlood;
        ((Component) this.ChallegeBloodRestrictSL[i]).gameObject.SetActive(true);
      }
      Transform child5 = this.m_transform.transform.GetChild(8 + i);
      this.mpSlidersRt[i] = child5.GetComponent<RectTransform>();
      this.mpSliders[i] = child5.GetComponent<Slider>();
      ((Component) this.mpSliders[i]).gameObject.SetActive(flag1);
      this.maxMpSlider[i] = child5.GetChild(0).GetChild(0).GetChild(0);
      this.iconScaleValue[i].NowType = (byte) 1;
      this.IconSliserTime[i].bShowIconEffect = (byte) 0;
    }
    this.kingBtn = this.m_transform.transform.GetChild(18).GetComponent<UIButton>();
    this.kingBtn.m_BtnID1 = 5;
    this.kingBtn.m_Handler = (IUIButtonClickHandler) this;
    this.kingBar = this.m_transform.transform.GetChild(19).GetComponent<Image>();
    this.nextButton1 = this.m_transform.transform.GetChild(20).GetComponent<UIButton>();
    this.nextButton1.m_BtnID1 = 6;
    this.nextButton1.m_Handler = (IUIButtonClickHandler) this;
    this.nextButton2 = this.m_transform.transform.GetChild(21).GetComponent<UIButton>();
    this.nextButton2.m_BtnID1 = 6;
    this.nextButton2.m_Handler = (IUIButtonClickHandler) this;
    this.infoImg0 = this.m_transform.transform.GetChild(22);
    this.infoImg2 = this.m_transform.transform.GetChild(24);
    this.infoImg3 = this.m_transform.transform.GetChild(25);
    if (GUIManager.Instance.IsArabic)
      this.m_transform.transform.GetChild(26).gameObject.AddComponent<ArabicItemTextureRot>();
    this.timeText = this.m_transform.transform.GetChild(27).GetComponent<UIText>();
    this.timeText.font = GUIManager.Instance.GetTTFFont();
    this.itemTextTf = this.m_transform.transform.GetChild(28);
    this.itemText = this.itemTextTf.GetComponent<UIText>();
    this.itemText.font = GUIManager.Instance.GetTTFFont();
    this.itemText.text = "0";
    this.checkpointTextTf = this.m_transform.transform.GetChild(29);
    this.checkpointText = this.checkpointTextTf.GetComponent<UIText>();
    this.checkpointText.font = GUIManager.Instance.GetTTFFont();
    this.SetKingBar(0.0f);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      Image component = this.m_transform.transform.GetChild(30).GetComponent<Image>();
      if ((bool) (Object) component)
        ((Behaviour) component).enabled = false;
    }
    this.pauseButton = this.m_transform.transform.GetChild(31).GetComponent<UIButton>();
    this.pauseButton.m_BtnID1 = 7;
    this.pauseButton.m_Handler = (IUIButtonClickHandler) this;
    Transform child6 = this.m_transform.transform.GetChild(33);
    this.autoButtonUp = child6.GetComponent<UIButton>();
    this.autoButtonUp.m_BtnID1 = 8;
    this.autoButtonUp.m_Handler = (IUIButtonClickHandler) this;
    if (this.bNpcBossMod || this.bArenaMod)
    {
      child6.gameObject.AddComponent<IgnoreRaycast>();
      child6.GetChild(0).gameObject.SetActive(true);
    }
    if (this.CheckShowAutoBtn())
    {
      ((Component) this.autoButtonUp).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.autoButtonUp).gameObject.SetActive(false);
      this.m_transform.transform.GetChild(32).gameObject.SetActive(false);
    }
    if (GUIManager.Instance.IsArabic)
      ((Component) this.autoButtonUp).gameObject.AddComponent<ArabicItemTextureRot>();
    this.spriteArray = child6.GetComponent<UISpritesArray>();
    this.debugButton = this.m_transform.transform.GetChild(34).GetComponent<UIButton>();
    this.debugButton.m_BtnID1 = 10;
    this.debugButton.m_Handler = (IUIButtonClickHandler) this;
    ((Component) this.debugButton).gameObject.SetActive(false);
    this.CameraBtn = this.m_transform.transform.GetChild(35).GetComponent<UIButton>();
    this.CameraBtn.m_BtnID1 = 11;
    this.CameraBtn.m_Handler = (IUIButtonClickHandler) this;
    ((Component) this.CameraBtn).gameObject.SetActive(true);
    this.PausePanel = this.m_transform.GetChild(38);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      ((RectTransform) this.PausePanel).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.PausePanel).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    UIButton component1 = this.PausePanel.GetChild(0).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 12;
    UIText component2 = this.PausePanel.GetChild(0).GetChild(0).GetComponent<UIText>();
    component2.font = GUIManager.Instance.GetTTFFont();
    component2.text = DataManager.Instance.mStringTable.GetStringByID(241U);
    UIButton component3 = this.PausePanel.GetChild(1).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 13;
    if (GUIManager.Instance.IsArabic)
      ((Component) component3).gameObject.AddComponent<ArabicItemTextureRot>();
    UIText component4 = this.PausePanel.GetChild(1).GetChild(0).GetComponent<UIText>();
    component4.font = GUIManager.Instance.GetTTFFont();
    component4.text = DataManager.Instance.mStringTable.GetStringByID(240U);
    UIButton component5 = this.PausePanel.GetChild(2).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_BtnID1 = 14;
    UIText component6 = this.PausePanel.GetChild(2).GetChild(0).GetComponent<UIText>();
    component6.font = GUIManager.Instance.GetTTFFont();
    component6.text = DataManager.Instance.mStringTable.GetStringByID(801U);
    this.challengePausePanel = this.m_transform.GetChild(39);
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      ((RectTransform) this.challengePausePanel).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.challengePausePanel).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    this.text_ChallengeTitle = this.challengePausePanel.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_ChallengeTitle.font = GUIManager.Instance.GetTTFFont();
    this.text_ChallengeTitle.text = DataManager.Instance.mStringTable.GetStringByID(10005U);
    UIButton component7 = this.challengePausePanel.GetChild(2).GetComponent<UIButton>();
    component7.m_Handler = (IUIButtonClickHandler) this;
    component7.m_BtnID1 = 12;
    this.text_ChallengeExit = this.challengePausePanel.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.text_ChallengeExit.font = GUIManager.Instance.GetTTFFont();
    this.text_ChallengeExit.text = DataManager.Instance.mStringTable.GetStringByID(241U);
    UIButton component8 = this.challengePausePanel.GetChild(3).GetComponent<UIButton>();
    component8.m_Handler = (IUIButtonClickHandler) this;
    component8.m_BtnID1 = 13;
    if (GUIManager.Instance.IsArabic)
      ((Component) component3).gameObject.AddComponent<ArabicItemTextureRot>();
    this.text_ChallengeContinuance = this.challengePausePanel.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.text_ChallengeContinuance.font = GUIManager.Instance.GetTTFFont();
    this.text_ChallengeContinuance.text = DataManager.Instance.mStringTable.GetStringByID(240U);
    UIButton component9 = this.challengePausePanel.GetChild(4).GetComponent<UIButton>();
    component9.m_Handler = (IUIButtonClickHandler) this;
    component9.m_BtnID1 = 14;
    this.text_ChallengeGgain = this.challengePausePanel.GetChild(4).GetChild(0).GetComponent<UIText>();
    this.text_ChallengeGgain.font = GUIManager.Instance.GetTTFFont();
    this.text_ChallengeGgain.text = DataManager.Instance.mStringTable.GetStringByID(801U);
    this.text_ChallengeHint = this.challengePausePanel.GetChild(5).GetChild(0).GetComponent<UIText>();
    this.text_ChallengeHint.font = GUIManager.Instance.GetTTFFont();
    Transform child7 = this.challengePausePanel.GetChild(1);
    for (int index = 0; index < this.battleChallengeIcons.Length; ++index)
    {
      this.battleChallengeIcons[index].Init();
      this.battleChallengeIcons[index].gameObj = child7.GetChild(index).gameObject;
      this.battleChallengeIcons[index].Btn = child7.GetChild(index).GetChild(0).GetComponent<UIButton>();
      UIButtonHint uiButtonHint = ((Component) this.battleChallengeIcons[index].Btn).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint.Parm1 = (ushort) index;
      uiButtonHint.m_Handler = (MonoBehaviour) this;
      uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
      this.battleChallengeIcons[index].Background = child7.GetChild(index).GetChild(0).GetComponent<Image>();
      this.battleChallengeIcons[index].Frame = child7.GetChild(index).GetChild(1).GetComponent<Image>();
      this.battleChallengeIcons[index].Item = child7.GetChild(index).GetChild(2).GetComponent<Image>();
    }
    if (this.bNpcBossMod || this.bArenaMod)
    {
      ((RectTransform) ((Component) component1).transform).anchoredPosition = new Vector2(-101f, 25f);
      ((RectTransform) ((Component) component3).transform).anchoredPosition = new Vector2(103f, 25f);
      ((Component) component5).gameObject.SetActive(false);
    }
    this.m_CenterMsgTf = this.m_transform.GetChild(40).GetChild(0);
    this.m_CenterMsgBg = this.m_CenterMsgTf.GetComponent<Image>();
    this.m_CenterMsgText = this.m_CenterMsgTf.GetChild(0).GetComponent<UIText>();
    this.m_CenterMsgText.font = GUIManager.Instance.GetTTFFont();
    this.m_IPhoneXPPanel = this.m_transform.GetChild(41);
    if (GUIManager.Instance.bOpenOnIPhoneX)
      this.m_IPhoneXPPanel.gameObject.SetActive(true);
    this.m_CountDownRect = this.m_transform.GetChild(36).GetComponent<RectTransform>();
    this.m_CountDownText = this.m_transform.GetChild(36).GetComponent<UIText>();
    this.m_CountDownText.font = GUIManager.Instance.GetTTFFont();
    this.npcHpTf = this.m_transform.GetChild(37);
    this.npcHpImg = this.npcHpTf.GetChild(0).GetChild(0).GetComponent<Image>();
    this.npcBossID = this.npcHpTf.GetChild(1).GetComponent<UIText>();
    this.npcBossHpValue = this.npcHpTf.GetChild(2).GetComponent<UIText>();
    this.npcBossID.font = GUIManager.Instance.GetTTFFont();
    this.npcBossHpValue.font = GUIManager.Instance.GetTTFFont();
    if (!GUIManager.Instance.IsArabic)
      return;
    this.SwapBtn(this.buttons[0], this.buttons[4]);
    this.SwapBtn(this.buttons[1], this.buttons[3]);
    this.SwapSlider(this.hpSlidersRt[0], this.hpSlidersRt[4]);
    this.SwapSlider(this.hpSlidersRt[1], this.hpSlidersRt[3]);
    this.SwapSlider(this.mpSlidersRt[0], this.mpSlidersRt[4]);
    this.SwapSlider(this.mpSlidersRt[1], this.mpSlidersRt[3]);
    Vector3 localScale1 = ((Transform) ((Component) this.nextButton1).GetComponent<RectTransform>()).localScale;
    localScale1.x *= -1f;
    ((Transform) ((Component) this.nextButton1).GetComponent<RectTransform>()).localScale = localScale1;
    uTweenPosition component10 = ((Component) this.nextButton1).GetComponent<uTweenPosition>();
    component10.from.x *= -1f;
    component10.to.x *= -1f;
    Vector3 localScale2 = ((Transform) ((Component) this.nextButton2).GetComponent<RectTransform>()).localScale;
    localScale2.x *= -1f;
    ((Transform) ((Component) this.nextButton2).GetComponent<RectTransform>()).localScale = localScale2;
    uTweenPosition component11 = ((Component) this.nextButton2).GetComponent<uTweenPosition>();
    component11.from.x *= -1f;
    component11.to.x *= -1f;
  }

  private void CheckChalleneHeroRule(ref CurHeroData data)
  {
    if (!this.bChallegeMode)
      return;
    LevelEX bycurrentPointId = DataManager.StageDataController.GetLevelEXBycurrentPointID((ushort) 0);
    data.Level = bycurrentPointId.LV;
    data.Enhance = bycurrentPointId.Rank;
    data.Star = bycurrentPointId.Star;
  }

  private void SwapBtn(UIHIBtn btn1, UIHIBtn btn2)
  {
    Vector2 anchoredPosition = ((Component) btn1).gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition;
    ((Component) btn1).gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition = ((Component) btn2).gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition;
    ((Component) btn2).gameObject.transform.parent.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
  }

  private void SwapSlider(RectTransform rt1, RectTransform rt2)
  {
    Vector2 anchoredPosition = rt1.anchoredPosition;
    rt1.anchoredPosition = rt2.anchoredPosition;
    rt2.anchoredPosition = anchoredPosition;
  }

  public void OnHIButtonDragExit(UIHIBtn sender)
  {
    if (!((Object) this.projectorTrans == (Object) null) || !this.ultraSkillWorking)
      return;
    Ray ray = Camera.main.ScreenPointToRay((Vector3) Input.GetTouch(0).position);
    Vector3? nullable = BattleController.Tracing(ray.direction, ray.origin);
    if (nullable.HasValue)
    {
      this.projectorTrans = this.bc.setupProjector(true, ref this.projectorType);
      if (this.projectorType == 1)
        this.projectorTrans.localPosition = nullable.Value;
      else if (this.projectorType == 3 || this.projectorType == 4)
        this.projectorTrans.localPosition = Vector3.forward * this.bc.PJ_FireRadius * 0.5f;
    }
    this.bProjectorMode = true;
  }

  public void OnHIButtonDrag(UIHIBtn sender)
  {
  }

  public void OnHIButtonDragEnd(UIHIBtn sender)
  {
  }

  public void InterruptInput()
  {
    if (!this.ultraSkillWorking)
      return;
    this.OnHIButtonUp(this.buttons[0]);
  }

  public void OnHIButtonUp(UIHIBtn sender)
  {
    if ((Object) this.projectorTrans == (Object) null && this.ultraSkillWorking)
    {
      this.bc.inputUltra(false);
      this.ultraSkillWorking = false;
    }
    else
    {
      if (!((Object) this.projectorTrans != (Object) null))
        return;
      this.bc.setupProjector(false, ref this.projectorType);
      this.bc.inputUltra(true, new Ray?(this.rayCache));
      this.ultraSkillWorking = false;
      this.projectorTrans = (Transform) null;
      this.bProjectorMode = false;
    }
  }

  public void OnButtonClick(UIButton sender) => this.UseSkill(sender.m_BtnID1);

  public void OnHIButtonDown(UIHIBtn sender)
  {
    if (this.bNpcBossMod || this.bArenaMod || this.bc.StartAutoBattle)
      return;
    int btnId1 = sender.m_BtnID1;
    if (btnId1 >= 5 || btnId1 < 0 || !((Component) this.selectImage[btnId1]).gameObject.activeSelf)
      return;
    int battlePosId = this.GetBattlePosID(btnId1);
    if (this.ultraSkillWorking || !this.bc.checkInitUltra(battlePosId))
      return;
    this.curUltraSkillerPos = this.bc.playerUnit[battlePosId].Position;
    this.ultraSkillWorking = true;
    this.rayCache = new Ray();
  }

  private void UseSkill(int tag)
  {
    if ((this.bNpcBossMod || this.bArenaMod) && (tag == 6 || tag == 8 || tag == 9))
      return;
    switch (tag)
    {
      case 6:
        this.NextTransitions();
        break;
      case 7:
        if (this.bc.IsBattleEnd)
          break;
        this.OnBackButtonClick();
        break;
      case 8:
      case 9:
        if (this.bc == null)
          break;
        this.bc.StartAutoBattle = !this.bc.StartAutoBattle;
        if (this.bc.StartAutoBattle)
        {
          this.autoButtonUp.image.sprite = this.spriteArray.GetSprite(1);
          if (BattleController.CameraModel == (byte) 0)
          {
            ((Component) this.nextButton1).gameObject.SetActive(false);
            break;
          }
          ((Component) this.nextButton2).gameObject.SetActive(false);
          break;
        }
        this.autoButtonUp.image.sprite = this.spriteArray.GetSprite(0);
        break;
      case 10:
        if (this.bc == null)
          break;
        this.bc.ReturnFirstStage();
        break;
      case 11:
        if (this.bc != null)
          this.bc.SetBattleCameraModel();
        if (!((Component) this.nextButton1).gameObject.activeSelf && !((Component) this.nextButton2).gameObject.activeSelf)
          break;
        if (BattleController.CameraModel == (byte) 0)
        {
          ((Component) this.nextButton1).gameObject.SetActive(true);
          ((Component) this.nextButton2).gameObject.SetActive(false);
          break;
        }
        ((Component) this.nextButton2).gameObject.SetActive(true);
        ((Component) this.nextButton1).gameObject.SetActive(false);
        break;
      case 12:
        if (this.bNpcBossMod)
        {
          GUIManager.Instance.CheckSynIsOpned();
          DataManager.Instance.SendExitBattle();
          break;
        }
        if (this.bArenaMod)
        {
          if (this.bc.IsReplay_PVP)
          {
            GUIManager.Instance.CheckSynIsOpned();
            DataManager.Instance.SendExitBattle();
          }
          else
          {
            this.bc.m_BattleState = BattleController.BattleState.BATTLE_STOP;
            GUIManager.Instance.OpenMenu(EGUIWindow.UI_Settlement, 1, bCameraMode: true);
          }
          GUIManager.Instance.ClosePvPUI();
          break;
        }
        Time.timeScale = 0.0f;
        GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(685U), DataManager.Instance.mStringTable.GetStringByID(596U), 1);
        break;
      case 13:
        this.OnBackButtonClick();
        break;
      case 14:
        this.OnBackButtonClick();
        this.bc.m_BattleState = BattleController.BattleState.BATTLE_STOP;
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleReplay_Force);
        break;
    }
  }

  private void NextTransitions()
  {
    if (this.bc != null && this.bc.CheckNextLevel() && this.bc.movePlayerOutside())
      GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.Battle);
    this.deltaTime = 90f;
    ((Component) this.nextButton1).gameObject.SetActive(false);
    ((Component) this.nextButton2).gameObject.SetActive(false);
  }

  private void OverGame()
  {
    if (this.bc == null || !this.bc.CheckNextLevel() || !this.bc.movePlayerOutside())
      return;
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
  }

  private void Pause()
  {
    this.isPause = !this.isPause;
    if (this.isPause)
      Time.timeScale = 0.0f;
    else
      Time.timeScale = 1f;
  }

  private int GetBattlePosID(int i)
  {
    int battlePosId = 0;
    switch (i)
    {
      case 0:
        battlePosId = 3;
        break;
      case 1:
        battlePosId = 1;
        break;
      case 2:
        battlePosId = 0;
        break;
      case 3:
        battlePosId = 2;
        break;
      case 4:
        battlePosId = 4;
        break;
    }
    return battlePosId;
  }

  private void SetSliderHP(int Index, float val)
  {
    if (Index >= 5 || Index < 0)
      return;
    this.hpSliders[Index].value = val;
    if ((double) val == 0.0)
    {
      ((Component) this.selectImage[Index]).gameObject.SetActive(false);
      this.buttons[Index].interactable = false;
      ((Graphic) this.buttons[Index].HIImage).color = new Color(0.168f, 0.168f, 0.168f, 1f);
      if (!this.weekHpSlider[Index].gameObject.activeSelf)
        return;
      this.weekHpSlider[Index].gameObject.SetActive(false);
      ((Component) this.deadImages[Index]).gameObject.SetActive(false);
    }
    else if ((double) this.hpSliders[Index].value / (double) this.hpSliders[Index].maxValue <= 0.34999999403953552)
    {
      if (this.weekHpSlider[Index].gameObject.activeSelf)
        return;
      this.weekHpSlider[Index].gameObject.SetActive(true);
      ((Component) this.deadImages[Index]).gameObject.SetActive(true);
      ((Behaviour) this.hpImage[Index]).enabled = false;
    }
    else
    {
      if (!((Behaviour) this.hpImage[Index]).enabled)
        ((Behaviour) this.hpImage[Index]).enabled = true;
      if (this.weekHpSlider[Index].gameObject.activeSelf)
      {
        this.weekHpSlider[Index].gameObject.SetActive(false);
        ((Component) this.deadImages[Index]).gameObject.SetActive(false);
      }
      if (!(((Graphic) this.buttons[Index].HIImage).color != Color.white))
        return;
      ((Graphic) this.buttons[Index].HIImage).color = Color.white;
    }
  }

  private void SetSliderMP(int Index, float val)
  {
    if (Index >= 5 || Index < 0)
      return;
    if ((double) val > 0.0)
    {
      if ((double) val >= (double) this.mpSliders[Index].maxValue && (double) this.mpSliders[Index].value != (double) this.mpSliders[Index].maxValue)
      {
        this.buttons[Index].interactable = true;
        if (!this.maxMpSlider[Index].gameObject.activeSelf)
          this.maxMpSlider[Index].gameObject.SetActive(true);
        NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, (object) this);
      }
      this.mpSliders[Index].value = val;
    }
    else
    {
      if ((double) val != (double) this.mpSliders[Index].minValue && (double) val != 0.0)
        return;
      this.mpSliders[Index].value = (double) this.mpSliders[Index].value != (double) this.mpSliders[Index].maxValue || (double) val != 0.0 ? val : val;
      this.buttons[Index].interactable = false;
      if (this.iconScaleValue[Index].NowType == (byte) 2)
        this.SetBtnTween(Index, 2);
      if (!this.maxMpSlider[Index].gameObject.activeSelf)
        return;
      this.maxMpSlider[Index].gameObject.SetActive(false);
    }
  }

  private void SetSliderMPMax(int Index, float val)
  {
    if (Index >= 5 || Index < 0)
      return;
    this.mpSliders[Index].maxValue = val;
    this.mpSliders[Index].minValue = 0.0f;
  }

  private void SetSliderHPMax(int Index, float val)
  {
    if (Index >= 5 || Index < 0)
      return;
    this.hpSliders[Index].maxValue = val;
    this.mpSliders[Index].minValue = 0.0f;
  }

  private void SetKingBar(float val) => this.kingBar.fillAmount = val;

  public void SetTeachProjector(bool bShow)
  {
    if (bShow)
    {
      Transform transform = this.bc.setupTeachProjector(true, this.projectorType);
      Ray ray = Camera.main.ScreenPointToRay((Vector3) ((Vector2) Camera.main.WorldToScreenPoint(this.bc.enemyUnit[0].Position) / GUIManager.Instance.m_UICanvas.scaleFactor));
      if (!BattleController.Tracing(ray.direction, ray.origin).HasValue)
        return;
      Vector3 position = this.bc.enemyUnit[0].Position;
      position.x = Mathf.Clamp(position.x, 0.0f, 23.8f);
      position.z = Mathf.Clamp(position.z, 0.0f, 11f);
      if (this.projectorType == 3)
      {
        this.bc.newbie_projector_parent.rotation = Quaternion.LookRotation(position - this.curUltraSkillerPos);
        transform.localPosition = Vector3.forward * this.bc.PJ_FireRadius * 0.5f;
      }
      else
      {
        if (this.projectorType != 5)
          return;
        Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.bc.enemyUnit[0].NpcID);
        this.bc.newbie_projector.ShadowSize = (float) recordByKey.Radius * (1f / 500f);
        this.bc.newbie_projector.transform.position = this.bc.enemyUnit[0].Position;
        float num1 = Vector3.Distance(this.bc.enemyUnit[0].Position, this.curUltraSkillerPos) - (float) recordByKey.Radius * 0.02f;
        float num2 = (double) num1 <= 1.0 ? num1 : num1 - 0.5f;
        this.bc.newbie_projector_line_transform.localScale = new Vector3(3f / 500f, num2 * 0.05f, 3f / 500f);
        Vector3 forward = this.bc.enemyUnit[0].Position - this.curUltraSkillerPos;
        forward.Normalize();
        this.bc.newbie_projector_line.transform.rotation = Quaternion.LookRotation(forward);
        this.bc.newbie_projector_line.transform.Rotate(270f, 0.0f, 0.0f);
        this.bc.newbie_projector_line.transform.position = this.curUltraSkillerPos + forward * num2 * 0.5f;
      }
    }
    else
      this.bc.setupTeachProjector(false, 0);
  }

  public void UpdateProjector(bool useRayCache = false, bool bNewbieSpecial = false)
  {
    if (this.bProjectorMode)
    {
      if ((Object) this.projectorTrans != (Object) null)
      {
        bool flag = true;
        if (!useRayCache)
        {
          if (Input.touchCount > 0)
          {
            this.rayCache = Camera.main.ScreenPointToRay((Vector3) Input.GetTouch(0).position);
          }
          else
          {
            this.OnHIButtonUp(this.buttons[0]);
            flag = false;
          }
        }
        if (!flag)
          return;
        Vector3? nullable = BattleController.Tracing(this.rayCache.direction, this.rayCache.origin);
        if (!nullable.HasValue)
          return;
        Vector3 vector3_1 = nullable.Value;
        if (bNewbieSpecial)
          vector3_1 = this.bc.enemyUnit[0].Position;
        vector3_1.x = Mathf.Clamp(vector3_1.x, 0.0f, 23.8f);
        vector3_1.z = Mathf.Clamp(vector3_1.z, 0.0f, 11f);
        if (this.projectorType == 1)
        {
          if ((double) GameConstants.DistanceSquare(vector3_1, this.curUltraSkillerPos) > (double) this.bc.PJ_FireRange * (double) this.bc.PJ_FireRange)
          {
            Vector3 vector3_2 = vector3_1 - this.curUltraSkillerPos;
            vector3_2.Normalize();
            vector3_1 = (this.curUltraSkillerPos + vector3_2 * this.bc.PJ_FireRange) with
            {
              y = 0.0f
            };
          }
          this.projectorTrans.transform.localPosition = vector3_1;
          this.bc.getUltraTargets((byte) ((double) vector3_1.x * 10.0), (byte) ((double) vector3_1.z * 10.0));
        }
        else if (this.projectorType == 3 || this.projectorType == 4)
        {
          this.bc.getProjectorParent().rotation = Quaternion.LookRotation(vector3_1 - this.curUltraSkillerPos);
          this.bc.getUltraTargets((byte) ((double) vector3_1.x * 10.0), (byte) ((double) vector3_1.z * 10.0));
        }
        else if (this.projectorType == 5)
          this.bc.updateNearestTargetHightlight(nullable.Value);
        if (this.projectorType == 6 || this.projectorType == 5 || this.projectorType == 2)
          return;
        this.bc.getUltraSkiller().updateDirection(vector3_1);
      }
      else
        this.bProjectorMode = false;
    }
    else
    {
      if (!this.ultraSkillWorking || NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE) || NewbieManager.IsTeachWorking(ETeachKind.AUTO_BATTLE) || Input.touchCount > 0)
        return;
      this.OnHIButtonUp(this.buttons[0]);
    }
  }

  private void Update()
  {
    this.UpdateProjector();
    if ((double) this.deltaTime != 0.0)
      this.tempDeltaTime += Time.deltaTime;
    this.tempDeltaTime = 0.0f;
    if (this.bc != null)
    {
      this.MaxTime = !this.bNpcBossMod ? (!this.bChallegeMode || this.ChallegeCheckPointTimeRule[this.CheckPoint - 1] <= (ushort) 0 ? (ushort) 90 : this.ChallegeCheckPointTimeRule[this.CheckPoint - 1]) : (ushort) 40;
      this.deltaTime = (float) ((uint) this.MaxTime - this.bc.m_ui32Tcik / 10U);
    }
    this.m_Str[0].ClearString();
    this.m_Str[0].IntToFormat((long) ((int) this.deltaTime / 60));
    this.m_Str[0].IntToFormat((long) ((int) this.deltaTime % 60), 2);
    this.m_Str[0].AppendFormat("{0} : {1}");
    this.timeText.text = this.m_Str[0].ToString();
    this.timeText.SetAllDirty();
    this.timeText.cachedTextGenerator.Invalidate();
    if ((double) this.deltaTime < 11.0)
    {
      this.bShowCountDownText = true;
      if ((double) this.deltaTime != (double) this.m_PreCountDownNum)
      {
        this.bShowCountDownText = true;
        this.m_PreCountDownNum = this.deltaTime;
        this.m_Str[1].ClearString();
        this.m_Str[1].IntToFormat((long) (int) this.deltaTime);
        this.m_Str[1].AppendFormat("{0}");
        this.m_CountDownText.text = this.m_Str[1].ToString();
        this.m_CountDownText.SetAllDirty();
        this.m_CountDownText.cachedTextGenerator.Invalidate();
        this.m_CounDownTick = 0.0f;
      }
    }
    else
      this.bShowCountDownText = false;
    for (int index = 0; index < 5; ++index)
    {
      if (this.iconScaleValue[index].bShowIconEffect == (byte) 2)
      {
        if ((double) this.iconScaleValue[index].time <= (double) this.effectTime)
        {
          this.iconScaleValue[index].iconSize = this.IconTween(this.iconScaleValue[index].time, 68f, 30f, this.effectTime);
          this.iconScaleValue[index].sliderSize = this.IconTween(this.iconScaleValue[index].time, 82f, 30f, this.effectTime);
          this.btnRt[index].sizeDelta = new Vector2(this.iconScaleValue[index].iconSize, this.iconScaleValue[index].iconSize);
          this.hpSlidersRt[index].sizeDelta = new Vector2(this.iconScaleValue[index].sliderSize, 22f);
          this.mpSlidersRt[index].sizeDelta = new Vector2(this.iconScaleValue[index].sliderSize, 22f);
        }
        if ((double) this.iconScaleValue[index].time > (double) this.effectTime - (double) this.delay)
        {
          if (!((Component) this.selectImage[index]).gameObject.activeSelf)
          {
            this.selectTween[index].enabled = false;
            ((Component) this.selectImage[index]).gameObject.SetActive(true);
          }
          this.iconScaleValue[index].selectSize = this.SelectTween(this.iconScaleValue[index].time, 400f, -250f, this.effectTime + this.effectTime2);
          this.selectImageRt[index].sizeDelta = new Vector2(this.iconScaleValue[index].selectSize, this.iconScaleValue[index].selectSize);
          this.iconScaleValue[index].colorA = this.ATween(this.iconScaleValue[index].time, 1f, -0.8f, this.effectTime + this.effectTime2);
          ((Graphic) this.selectImage[index]).color = new Color(1f, 1f, 1f, this.iconScaleValue[index].colorA);
        }
        if ((double) this.iconScaleValue[index].time >= (double) this.effectTime + (double) this.effectTime2)
        {
          this.selectTween[index].enabled = true;
          this.iconScaleValue[index].bShowIconEffect = (byte) 0;
        }
        this.iconScaleValue[index].time += Time.deltaTime;
      }
      else if (this.iconScaleValue[index].bShowIconEffect == (byte) 1)
      {
        if ((double) this.iconScaleValue[index].time <= 0.20000000298023224)
        {
          if (this.selectTween[index].enabled)
            this.selectTween[index].enabled = false;
          if (!((Component) this.selectImage[index]).gameObject.activeSelf)
            ((Component) this.selectImage[index]).gameObject.SetActive(true);
          this.iconScaleValue[index].selectSize = this.SelectTween(this.iconScaleValue[index].time, 110f, 100f, 0.2f);
          this.selectImageRt[index].sizeDelta = new Vector2(this.iconScaleValue[index].selectSize, this.iconScaleValue[index].selectSize);
          this.iconScaleValue[index].colorA = this.ATween(this.iconScaleValue[index].time, 1f, -1f, 0.2f);
          ((Graphic) this.selectImage[index]).color = new Color(1f, 1f, 1f, this.iconScaleValue[index].colorA);
        }
        if ((double) this.iconScaleValue[index].time >= 0.20000000298023224)
        {
          this.selectTween[index].enabled = false;
          ((Component) this.selectImage[index]).gameObject.SetActive(false);
          this.iconScaleValue[index].bShowIconEffect = (byte) 0;
        }
        this.iconScaleValue[index].time += Time.deltaTime;
      }
    }
    for (int i = 0; i < 5; ++i)
    {
      if (this.IconSliserTime[i].bShowIconEffect == (byte) 1)
      {
        if ((double) this.IconSliserTime[i].time <= (double) this.mpValueTime)
        {
          this.IconSliserTime[i].mpSliderValue = this.ATween(this.IconSliserTime[i].time, this.mpSliders[i].maxValue, -this.mpSliders[i].maxValue, this.mpValueTime);
          this.mpSliders[i].value = this.IconSliserTime[i].mpSliderValue;
        }
        if ((double) this.IconSliserTime[i].time >= (double) this.mpValueTime)
        {
          this.IconSliserTime[i].bShowIconEffect = (byte) 0;
          this.mpSliders[i].value = (float) this.bc.playerAttr[this.GetBattlePosID(i)].CUR_MP;
        }
        this.IconSliserTime[i].time += Time.deltaTime;
      }
    }
    if (this.bShowCenterMsg)
    {
      Color color = ((Graphic) this.m_CenterMsgText).color;
      this.m_CenterMsgTime += Time.deltaTime;
      if ((double) this.m_CenterMsgTime > (double) this.m_CenterCountDownTime)
        this.m_CenterMsgColorA = this.ATween(this.m_CenterMsgTime - this.m_CenterCountDownTime, 1f, -1f, 0.5f);
      ((Graphic) this.m_CenterMsgBg).color = new Color(1f, 1f, 1f, this.m_CenterMsgColorA);
      ((Graphic) this.m_CenterMsgText).color = new Color(color.r, color.g, color.b, this.m_CenterMsgColorA);
      if ((double) this.m_CenterMsgTime >= (double) this.m_CenterCountDownTime + 0.5)
      {
        this.m_CenterMsgTf.gameObject.SetActive(false);
        this.bShowCenterMsg = false;
      }
    }
    if (this.bShowCountDownText)
    {
      this.m_CounDownTick += Time.deltaTime;
      if ((double) this.m_CounDownTick <= 1.0)
      {
        this.m_CountDownScale = this.ATween(this.m_CounDownTick, 0.0f, 1f, 1f);
        this.m_CountDownAColor = this.ATween(this.m_CounDownTick, 1f, -1f, 1f);
        if (GUIManager.Instance.IsArabic)
          ((Transform) this.m_CountDownRect).localScale = new Vector3((float) (-1.0 - (double) this.m_CountDownScale * 1.2999999523162842), 1f + this.m_CountDownScale, 1f + this.m_CountDownScale);
        else
          ((Transform) this.m_CountDownRect).localScale = new Vector3((float) (1.0 + (double) this.m_CountDownScale * 1.2999999523162842), 1f + this.m_CountDownScale, 1f + this.m_CountDownScale);
        ((Graphic) this.m_CountDownText).color = new Color(((Graphic) this.m_CountDownText).color.r, ((Graphic) this.m_CountDownText).color.g, ((Graphic) this.m_CountDownText).color.b, this.m_CountDownAColor);
        ((Behaviour) this.m_CountDownText).enabled = true;
      }
      else
        ((Behaviour) this.m_CountDownText).enabled = false;
    }
    if (!this.bNpcBossMod || this.bc == null || this.bossDataIdx >= 20)
      return;
    this.bossCurHp = this.bc.enemyAttr[this.bossDataIdx].CUR_HP;
    this.bossMaxHp = this.bc.enemyAttr[this.bossDataIdx].MAX_HP;
    this.SetNpcBossHP(this.bossCurHp, this.bossMaxHp);
  }

  public float IconTween(float t, float b, float c, float d)
  {
    float num1 = (t /= d) * t;
    float num2 = num1 * t;
    return b + c * ((float) (-13.4 * (double) num2 * (double) num1 + 48.895 * (double) num1 * (double) num1 + -56.39 * (double) num2 + 20.895 * (double) num1) + t);
  }

  public float SelectTween(float t, float b, float c, float d)
  {
    t /= d;
    return b + c * t;
  }

  public float ATween(float t, float b, float c, float d)
  {
    float num1 = (t /= d) * t;
    float num2 = num1 * t;
    return b + c * (num2 * num1);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    int length = this.bc.playerAttr.Length;
    switch (arg1)
    {
      case 0:
        for (int index = 0; index < length; ++index)
        {
          int battlePosId = this.GetBattlePosID(index);
          uint maxMp = this.bc.playerAttr[battlePosId].MAX_MP;
          this.SetSliderMPMax(index, (float) maxMp);
          uint maxHp = this.bc.playerAttr[battlePosId].MAX_HP;
          this.SetSliderHPMax(index, (float) maxHp);
        }
        break;
      case 1:
        for (int index = 0; index < length; ++index)
        {
          int battlePosId = this.GetBattlePosID(index);
          uint curMp = this.bc.playerAttr[battlePosId].CUR_MP;
          this.SetSliderMP(index, (float) curMp);
          uint curHp = this.bc.playerAttr[battlePosId].CUR_HP;
          this.SetSliderHP(index, (float) curHp);
        }
        break;
      case 2:
        this.SetKingBar((float) arg2);
        break;
      case 6:
        if (arg2 != 1)
          break;
        if (BattleController.CameraModel == (byte) 0)
          ((Component) this.nextButton1).gameObject.SetActive(true);
        else
          ((Component) this.nextButton2).gameObject.SetActive(true);
        this.bCountDown = false;
        break;
      case 7:
        this.AddItemCount();
        break;
      case 8:
        this.ClearItemCount();
        break;
      case 9:
        Time.timeScale = 1f;
        DataManager instance = DataManager.Instance;
        instance.lastBattleResult = (short) 0;
        instance.BattleSeqID = 0UL;
        this.bc.m_BattleState = BattleController.BattleState.BATTLE_STOP;
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleToMap);
        break;
      case 10:
        this.CheckPoint = Mathf.Clamp(arg2, 1, 3);
        this.m_Str[2].ClearString();
        this.m_Str[2].IntToFormat((long) arg2);
        if (GUIManager.Instance.IsArabic)
          this.m_Str[2].AppendFormat("3/{0}");
        else
          this.m_Str[2].AppendFormat("{0}/3");
        this.checkpointText.text = this.m_Str[2].ToString();
        this.checkpointText.SetAllDirty();
        this.checkpointText.cachedTextGenerator.Invalidate();
        this.deltaTime = 90f;
        this.bShowCountDownText = false;
        this.m_CountDownText.text = string.Empty;
        if (BattleController.CameraModel == (byte) 0)
          ((Component) this.nextButton1).gameObject.SetActive(false);
        else
          ((Component) this.nextButton2).gameObject.SetActive(false);
        this.bCountDown = true;
        break;
      case 11:
        this.RefreshData();
        break;
      case 12:
        ((Component) this.nextButton1).gameObject.SetActive(false);
        ((Component) this.nextButton2).gameObject.SetActive(false);
        break;
      case 13:
        int indexPos = (int) this.indexPosMap[arg2 >> 8];
        bool flag = (arg2 & (int) byte.MaxValue) != 0;
        ((Component) this.selectImage[indexPos]).gameObject.SetActive(flag);
        this.buttons[indexPos].interactable = flag;
        break;
      case 14:
        for (int index = 0; index < 5; ++index)
        {
          if (((Component) this.buttons[index]).gameObject.activeSelf)
          {
            ((Component) this.selectImage[index]).gameObject.SetActive(false);
            this.buttons[index].interactable = false;
          }
        }
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    GUIManager.Instance.CheckSynIsOpned();
    DataManager.Instance.SendExitBattle();
  }

  public override bool OnBackButtonClick()
  {
    if (this.bc != null && !BattleController.IsGambleMode)
    {
      if (DataManager.StageDataController._stageMode == StageMode.Dare && this.bc.IsType(EBattleType.NORMAL))
      {
        this.challengePausePanel.gameObject.SetActive(!this.challengePausePanel.gameObject.activeSelf);
        Time.timeScale = !this.challengePausePanel.gameObject.activeSelf ? 1f : 0.0f;
      }
      else
      {
        this.PausePanel.gameObject.SetActive(!this.PausePanel.gameObject.activeSelf);
        Time.timeScale = !this.PausePanel.gameObject.activeSelf ? 1f : 0.0f;
      }
    }
    return true;
  }

  public void OnBattlePause()
  {
    if (NewbieManager.IsWorking() || (bool) (Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Settlement))
      return;
    this.OnBackButtonClick();
  }

  public void AddItemCount()
  {
    ++this.itemCount;
    this.itemText.text = this.itemCount.ToString();
  }

  public void ClearItemCount()
  {
    this.itemCount = 0;
    this.itemText.text = this.itemCount.ToString();
  }

  public bool CheckShowAutoBtn()
  {
    if (this.bNpcBossMod || this.bArenaMod)
      return true;
    StageManager stageDataController = DataManager.StageDataController;
    int num = 0;
    if (stageDataController._stageMode != StageMode.Full || (int) BattleNetwork.battlePointID % 3 == 0)
      num = (int) (byte) DataManager.StageDataController.GetStagePoint(BattleNetwork.battlePointID, (byte) 0);
    DataManager instance = DataManager.Instance;
    VIP_DataTbl recordByKey = instance.VIPLevelTable.GetRecordByKey((ushort) instance.GetVIPLevel(instance.RoleAttr.VipPoint));
    return num > 0 || recordByKey.AutoFightMission != (byte) 0;
  }

  public void CheckAutoBattleStatus()
  {
    if (!((Component) this.autoButtonUp).gameObject.activeSelf || this.bc == null || !this.bc.IsType(EBattleType.NORMAL) || !BattleController.AutoBattleFlag || this.bc.StartAutoBattle)
      return;
    this.UseSkill(9);
  }

  public void RefreshData()
  {
    DataManager instance = DataManager.Instance;
    Transform child = this.m_transform.transform.GetChild(32);
    if (this.CheckShowAutoBtn())
    {
      ((Component) this.autoButtonUp).gameObject.SetActive(true);
      child.gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.autoButtonUp).gameObject.SetActive(false);
      child.gameObject.SetActive(false);
    }
    this.CheckAutoBattleStatus();
    for (int i = 0; i < (int) instance.heroCount; ++i)
    {
      ushort heroId = instance.heroBattleData[this.GetBattlePosID(i)].HeroID;
      if (instance.curHeroData.ContainsKey((uint) heroId))
      {
        CurHeroData data = instance.curHeroData[(uint) heroId];
        this.CheckChalleneHeroRule(ref data);
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.buttons[i]).transform, eHeroOrItem.Hero, data.ID, data.Star, data.Enhance, (int) data.Level);
      }
    }
    for (int btnIdx = 0; btnIdx < 5; ++btnIdx)
    {
      this.SetBtnTween(btnIdx, 0);
      ((Graphic) this.buttons[btnIdx].HIImage).color = new Color(1f, 1f, 1f, 1f);
      this.weekHpSlider[btnIdx].gameObject.SetActive(false);
      ((Component) this.deadImages[btnIdx]).gameObject.SetActive(false);
      ((Behaviour) this.hpImage[btnIdx]).enabled = true;
    }
  }

  public void SetBtnTween(int btnIdx, int setType)
  {
    if (setType == 0)
    {
      btnIdx = (int) this.indexPosMap[btnIdx];
      ((Component) this.selectImage[btnIdx]).gameObject.SetActive(false);
      this.SetBtnTween(btnIdx, 2);
    }
    else if (setType == 1)
    {
      btnIdx = (int) this.indexPosMap[btnIdx];
      ((Component) this.selectImage[btnIdx]).gameObject.SetActive(true);
      if (this.gameObject.activeSelf)
        AudioManager.Instance.PlayUISFX(UIKind.HeroSkill);
      this.SetBtnTween(btnIdx, 3);
    }
    if (setType == 2)
    {
      this.iconScaleValue[btnIdx].NowType = (byte) 1;
      this.iconScaleValue[btnIdx].bShowIconEffect = (byte) 1;
      this.iconScaleValue[btnIdx].iconSize = 68f;
      this.iconScaleValue[btnIdx].selectSize = 400f;
      this.iconScaleValue[btnIdx].time = 0.0f;
      this.iconScaleValue[btnIdx].sliderSize = 82f;
      this.selectTween[btnIdx].enabled = false;
      this.btnRt[btnIdx].sizeDelta = new Vector2(this.iconScaleValue[btnIdx].iconSize, this.iconScaleValue[btnIdx].iconSize);
      this.hpSlidersRt[btnIdx].sizeDelta = new Vector2(this.iconScaleValue[btnIdx].sliderSize, 22f);
      this.mpSlidersRt[btnIdx].sizeDelta = new Vector2(this.iconScaleValue[btnIdx].sliderSize, 22f);
      this.selectImageRt[btnIdx].sizeDelta = new Vector2(this.iconScaleValue[btnIdx].selectSize, this.iconScaleValue[btnIdx].selectSize);
      ((Graphic) this.selectImage[btnIdx]).color = new Color(1f, 1f, 1f, this.iconScaleValue[btnIdx].colorA);
      ((Component) this.selectImage[btnIdx]).gameObject.SetActive(false);
      this.buttons[btnIdx].interactable = false;
    }
    else if (setType == 3)
    {
      this.iconScaleValue[btnIdx].NowType = (byte) 2;
      this.iconScaleValue[btnIdx].bShowIconEffect = (byte) 2;
      this.iconScaleValue[btnIdx].iconSize = 68f;
      this.iconScaleValue[btnIdx].selectSize = 150f;
      this.iconScaleValue[btnIdx].time = 0.0f;
      ((Transform) this.btnRt[btnIdx]).localScale = (Vector3) new Vector2(1f, 1f);
      this.hpSlidersRt[btnIdx].sizeDelta = new Vector2(this.iconScaleValue[btnIdx].sliderSize, 22f);
      this.mpSlidersRt[btnIdx].sizeDelta = new Vector2(this.iconScaleValue[btnIdx].sliderSize, 22f);
      this.selectImageRt[btnIdx].sizeDelta = new Vector2(this.iconScaleValue[btnIdx].selectSize, this.iconScaleValue[btnIdx].selectSize);
      ((Graphic) this.selectImage[btnIdx]).color = new Color(1f, 1f, 1f, this.iconScaleValue[btnIdx].colorA);
      this.buttons[btnIdx].interactable = true;
    }
    else
    {
      if (setType != 4)
        return;
      this.IconSliserTime[btnIdx].bShowIconEffect = (byte) 1;
      this.IconSliserTime[btnIdx].time = 0.0f;
    }
  }

  public void UpdateSetSliderHP(int idx)
  {
    float curMp = (float) this.bc.playerAttr[idx].CUR_MP;
    this.SetSliderMP((int) this.indexPosMap[idx], curMp);
    float curHp = (float) this.bc.playerAttr[idx].CUR_HP;
    this.SetSliderHP((int) this.indexPosMap[idx], curHp);
  }

  public void AddCenterMsg()
  {
    this.bShowCenterMsg = true;
    this.m_CenterMsgTf.gameObject.SetActive(true);
    this.m_CenterMsgColorA = 1f;
    this.m_CenterMsgTime = 0.0f;
    this.m_CenterMsgText.text = DataManager.Instance.mStringTable.GetStringByID(743U);
    this.m_CenterMsgText.SetAllDirty();
    this.m_CenterMsgText.cachedTextGenerator.Invalidate();
    this.m_CenterMsgText.cachedTextGeneratorForLayout.Invalidate();
    this.m_CenterMsgTf.GetComponent<RectTransform>().sizeDelta = new Vector2(this.m_CenterMsgText.preferredWidth + 89f, 47f);
    ((Graphic) this.m_CenterMsgText).rectTransform.anchoredPosition = new Vector2(69f, ((Graphic) this.m_CenterMsgText).rectTransform.anchoredPosition.y);
    this.m_CenterMsgText.UpdateArabicPos();
  }

  public void SetNpcBossHP(uint curHp, uint maxHp)
  {
    if (maxHp == 0U)
      return;
    this.m_Str[4].ClearString();
    float num = (float) curHp / (float) maxHp;
    if ((double) num >= 9.9999997473787516E-05)
      this.m_Str[4].FloatToFormat(num * 100f, 2);
    else if ((double) num <= 0.0)
      this.m_Str[4].FloatToFormat(0.0f);
    else
      this.m_Str[4].FloatToFormat(0.01f);
    this.m_Str[4].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(884U));
    ((Graphic) this.npcHpImg).rectTransform.sizeDelta = new Vector2(338f * num, 16f);
    this.npcBossHpValue.text = this.m_Str[4].ToString();
    this.npcBossHpValue.SetAllDirty();
    this.npcBossHpValue.cachedTextGenerator.Invalidate();
  }

  private void SetBattleChallengeIcons()
  {
    StageManager stageDataController = DataManager.StageDataController;
    byte currentNodus = stageDataController.currentNodus;
    bool flag = stageDataController.StageDareMode(stageDataController.currentPointID) == StageMode.Lean;
    LevelEX bycurrentPointId = stageDataController.GetLevelEXBycurrentPointID((ushort) 0);
    if (flag)
    {
      switch (currentNodus)
      {
        case 1:
          this.ConditionKey = bycurrentPointId.NodusOneID;
          break;
        case 2:
          this.ConditionKey = bycurrentPointId.NodusTwoID;
          break;
        case 3:
          this.ConditionKey = bycurrentPointId.NodusThrID;
          break;
      }
    }
    else
      this.ConditionKey = bycurrentPointId.NodusTwoID;
    StageConditionData recordByKey1 = stageDataController.StageConditionDataTable.GetRecordByKey(this.ConditionKey);
    int index1 = 0;
    for (int index2 = 0; index2 < 8; ++index2)
    {
      StageConditionInfo recordByKey2 = stageDataController.StageConditionInfoTable.GetRecordByKey((ushort) recordByKey1.ConditionArray[index2].ConditionID);
      if (recordByKey1.ConditionArray[index2].ConditionID > (byte) 0)
      {
        this.battleChallengeIcons[index2].Btn.m_BtnID2 = (int) recordByKey1.ConditionArray[index2].ConditionID;
        this.battleChallengeIcons[index2].Btn.m_BtnID3 = (int) recordByKey1.ConditionArray[index2].FactorA;
        this.battleChallengeIcons[index2].Btn.m_BtnID4 = (int) recordByKey1.ConditionArray[index2].FactorB;
        if (recordByKey2.Type != (byte) 1)
          this.battleChallengeIcons[index2].gameObj.SetActive(true);
        else
          this.battleChallengeIcons[index2].gameObj.SetActive(false);
        ++index1;
      }
    }
    if (index1 < this.battleChallengeIcons.Length)
    {
      this.battleChallengeIcons[index1].Btn.m_BtnID2 = (int) byte.MaxValue;
      this.battleChallengeIcons[index1].Btn.m_BtnID3 = (int) byte.MaxValue;
      this.battleChallengeIcons[index1].Btn.m_BtnID4 = (int) byte.MaxValue;
      this.battleChallengeIcons[index1].gameObj.SetActive(true);
    }
    for (int index3 = 0; index3 < 8; ++index3)
    {
      if (this.battleChallengeIcons[index3].Btn.m_BtnID2 > 0)
      {
        byte btnId2 = (byte) this.battleChallengeIcons[index3].Btn.m_BtnID2;
        ushort btnId3 = (ushort) this.battleChallengeIcons[index3].Btn.m_BtnID3;
        ushort btnId4 = (ushort) this.battleChallengeIcons[index3].Btn.m_BtnID4;
        ((MaskableGraphic) this.battleChallengeIcons[index3].Item).material = stageDataController.GetStageConditionMaterial((byte) this.battleChallengeIcons[index3].Btn.m_BtnID2);
        this.battleChallengeIcons[index3].Item.sprite = stageDataController.GetStageConditionSprite(btnId2, btnId3, btnId4);
      }
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    StageManager stageDataController = DataManager.StageDataController;
    byte ConditionID = 0;
    ushort FactorA = 0;
    ushort FactorB = 0;
    this.m_Str[5].ClearString();
    if (sender.Parm1 >= (ushort) 0 && (int) sender.Parm1 < this.battleChallengeIcons.Length)
    {
      ConditionID = (byte) this.battleChallengeIcons[(int) sender.Parm1].Btn.m_BtnID2;
      FactorA = (ushort) this.battleChallengeIcons[(int) sender.Parm1].Btn.m_BtnID3;
      FactorB = (ushort) this.battleChallengeIcons[(int) sender.Parm1].Btn.m_BtnID4;
    }
    stageDataController.GetStageConditionString(this.m_Str[5], ConditionID, FactorA, FactorB, this.ConditionKey);
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.m_Str[5], Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide();

  public void SetAlertImageAlpha(float Alpha)
  {
    if (GUIManager.Instance.m_AlertImageIndex != 0 || !((Object) this.alertBlock != (Object) null) || !this.alertBlock.gameObject.activeSelf)
      return;
    Color color = new Color(1f, 1f, 1f, Alpha);
    if ((Object) this.alertBlock_T != (Object) null)
      ((Graphic) this.alertBlock_T).color = color;
    if ((Object) this.alertBlock_B != (Object) null)
      ((Graphic) this.alertBlock_B).color = color;
    if ((Object) this.alertBlock_L != (Object) null)
      ((Graphic) this.alertBlock_L).color = color;
    if (!((Object) this.alertBlock_R != (Object) null))
      return;
    ((Graphic) this.alertBlock_R).color = color;
  }

  public void SetAlertBlock(bool bOpenAlertBlock)
  {
    this.alertBlock.gameObject.SetActive(bOpenAlertBlock);
  }

  public enum e_BattleIcon
  {
    AlertBlock,
    ImageLeft,
    ImageRight,
    SliderHP0,
    SliderHP1,
    SliderHP2,
    SliderHP3,
    SliderHP4,
    SliderMP0,
    SliderMP1,
    SliderMP2,
    SliderMP3,
    SliderMP4,
    Icon0,
    Icon1,
    Icon2,
    Icon3,
    Icon4,
    KingSkill,
    KingBar,
    NextButton,
    NextButton2,
    InfoImage0,
    InfoImage1,
    InfoImage2,
    InfoImage3,
    InfoImage4,
    TimeText,
    ItemText,
    Checkpoint,
    PauseButtonImage,
    PauseButton,
    AutoButtonImage,
    AutoButton,
    DebugSpeep,
    CameraBtn,
    CountDownText,
    NpcHp,
    PausePanel,
    ChallengePausePanel,
    CenterHudPanel,
    IPhoneX,
  }
}
