// Decompiled with JetBrains decompiler
// Type: UIBattleHeroSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIBattleHeroSelect : 
  GUIWindow,
  IUpDateRowItem,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private const int TextMax = 9;
  private Transform[] m_BattleHeroBg = new Transform[2];
  private Transform[] m_BattleHeroTf = new Transform[5];
  private UIHIBtn[] m_BattleHero = new UIHIBtn[5];
  private ushort[] m_BattleHeroID = new ushort[5];
  private Image[] m_BattleHeroStartImage = new Image[5];
  private Transform[] m_MoveBattleHeroTf = new Transform[5];
  private UIHIBtn[] m_MoveBattleHero = new UIHIBtn[5];
  private MoveObject[] moveStack = new MoveObject[5];
  private Animator[] m_BattleHeroAmins = new Animator[5];
  private Image[] effectImages = new Image[5];
  private Image[] scrollBlack = new Image[3];
  private byte m_BattleHeroNum;
  private UIText m_ScoreText;
  private UIText m_ScoreText2;
  private Image m_ScorePowerImage;
  private Image m_ScorePowerImage2;
  private UIButton m_KingSkill;
  private UIButton m_KingSkillPanel;
  private byte m_KingSkillIndex;
  public ScrollView m_HerosView;
  private UISpritesArray m_SpArray;
  private Material frameMat;
  private Sprite lightSprite;
  private bool bMoving;
  private Sprite tempSprite;
  private ushort NeedShowFlashID;
  private float fightButtonTime;
  private Vector3 m_FightButtonPosition;
  private Vector3 m_AddPositio = new Vector3(0.0f, -70f, -590f);
  private int MoveBtnCount;
  private bool bCanClickbtn;
  private int MonsterMapID;
  private int AttackTimes;
  private ushort MonsterID;
  private UIBattleHeroSelect._SelectMode SelectMode;
  private CString m_Str;
  private CString m_Str2;
  private CString m_Str3;
  private int mTextCount;
  private UIText[] m_tmptext = new UIText[9];
  private bool bNeedCheckAstrology;
  private UIText m_FightButtonText;
  private Transform m_Hint;
  private Image m_HintImage;
  private UIText m_HintText;
  private UIText m_EnemyPower;
  private Image m_EnemyPowerIcon;
  private UIText m_EnemyText;
  private Transform m_TheEnemyPanel;
  private UIHIBtn[] m_BattleHeroEnemy = new UIHIBtn[5];
  private Image[] m_EnemyAstrology = new Image[5];
  private Image[] m_EnemyBg = new Image[5];
  private Transform m_ScoreBG;
  private Transform m_ScoreBG2;
  private Image m_BattleButtonImage;
  private int m_ArenaTargetIdx;
  private ushort tmp_C_Count;
  private ushort[] tmpTopicIdx = new ushort[8];
  private bool bConditionTopic;
  private bool bConditionCount;
  private bool bConditionHeroID;
  private int mCondition_CountIdx;
  private ushort[] tmpHeroIdx = new ushort[8];
  private StageConditionData tmpSCD;
  private ushort ConditionKey;
  private LevelEX LevelexDate;
  private bool bPreviewHeroModel;
  private Image[] m_Previewicon = new Image[2];
  private UIButton m_Preview;
  private Image[] m_ConditionF = new Image[8];
  private Image[] m_ConditionBG = new Image[8];
  private Transform m_BattleHeroPanel;
  private Transform m_PreviewPanel;
  private Transform m_ConditioniconPanel;
  private Transform[] m_ConditioniconItem = new Transform[8];
  private UIText[] m_ConditionText = new UIText[2];
  private Transform mChallengeTitle;
  private Transform[] mConditionLock = new Transform[5];
  private CString m_ConditionHint;
  private CScrollRect itemScrollRect;
  private RectTransform itemCont;

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager.SortHeroData();
    DataManager.Instance.SetFightHeroData();
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (arg2 < 0)
    {
      if (arg2 == -1)
        this.SelectMode = UIBattleHeroSelect._SelectMode.ArenaDefense;
      if (arg2 == -2)
      {
        this.m_ArenaTargetIdx = arg1;
        this.SelectMode = UIBattleHeroSelect._SelectMode.ArenaAttack;
      }
    }
    else if (arg2 > 0)
    {
      this.SelectMode = UIBattleHeroSelect._SelectMode.Monster;
      this.MonsterMapID = arg1;
      this.AttackTimes = arg2;
      MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[this.MonsterMapID];
      if (mapPoint.pointKind == (byte) 10)
        this.MonsterID = DataManager.MapDataController.NPCPointTable[(int) mapPoint.tableID].NPCNum;
    }
    Array.Clear((Array) this.tmpTopicIdx, 0, this.tmpTopicIdx.Length);
    Array.Clear((Array) this.tmpHeroIdx, 0, this.tmpHeroIdx.Length);
    this.mCondition_CountIdx = 0;
    this.bConditionTopic = false;
    this.bConditionCount = false;
    this.bConditionHeroID = false;
    if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero && DataManager.StageDataController._stageMode == StageMode.Dare)
    {
      this.SelectMode = UIBattleHeroSelect._SelectMode.Condition;
      this.LevelexDate = DataManager.StageDataController.GetLevelEXBycurrentPointID((ushort) 0);
      DataManager.SortConditionHeroData();
      this.CheckCondition();
    }
    this.m_SpArray = this.transform.GetComponent<UISpritesArray>();
    Vector2 vector2 = new Vector2(1384f, 640f);
    if ((double) ((RectTransform) this.transform).rect.width > (double) vector2.x)
    {
      vector2.x = ((RectTransform) this.transform).rect.width + (!GUIManager.Instance.bOpenOnIPhoneX ? 0.0f : GUIManager.Instance.IPhoneX_DeltaX * 2f);
      RectTransform child1 = (RectTransform) this.transform.GetChild(0);
      RectTransform child2 = (RectTransform) this.transform.GetChild(1);
      vector2 = new Vector2(vector2.x * 0.5f, vector2.y);
      child1.sizeDelta = vector2;
      child2.sizeDelta = vector2;
      vector2 = new Vector2(vector2.x * 0.25f, 0.0f);
      child1.anchoredPosition = -vector2;
      child2.anchoredPosition = vector2;
    }
    Image component1 = this.transform.GetChild(4).GetComponent<Image>();
    component1.sprite = menu.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component1).material = menu.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (UnityEngine.Object) component1)
      ((Behaviour) component1).enabled = false;
    this.m_TheEnemyPanel = this.transform.GetChild(3);
    UIButtonHint uiButtonHint1 = this.m_TheEnemyPanel.GetChild(6).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint1.Parm1 = (ushort) 2;
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    this.m_EnemyPowerIcon = this.m_TheEnemyPanel.GetChild(6).GetChild(0).GetComponent<Image>();
    this.m_EnemyPower = this.m_TheEnemyPanel.GetChild(6).GetChild(1).GetComponent<UIText>();
    this.m_EnemyPower.font = GUIManager.Instance.GetTTFFont();
    this.m_EnemyText = this.m_TheEnemyPanel.GetChild(7).GetComponent<UIText>();
    this.m_EnemyText.font = GUIManager.Instance.GetTTFFont();
    this.m_EnemyText.text = DataManager.Instance.mStringTable.GetStringByID(9149U);
    for (int index = 0; index < this.m_BattleHeroEnemy.Length; ++index)
    {
      this.m_BattleHeroEnemy[index] = this.m_TheEnemyPanel.GetChild(index + 1).GetChild(1).GetComponent<UIHIBtn>();
      GUIManager.Instance.InitianHeroItemImg(((Component) this.m_BattleHeroEnemy[index]).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
      this.m_BattleHeroEnemy[index].transition = (Selectable.Transition) 0;
      this.m_EnemyAstrology[index] = this.m_TheEnemyPanel.GetChild(index + 1).GetChild(2).GetComponent<Image>();
      this.m_EnemyBg[index] = this.m_TheEnemyPanel.GetChild(index + 1).GetChild(0).GetComponent<Image>();
    }
    UIButton component2 = this.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 1;
    component2.image.sprite = menu.LoadSprite("UI_main_close");
    ((MaskableGraphic) component2.image).material = menu.LoadMaterial();
    this.m_Str = StringManager.Instance.SpawnString();
    this.m_Str2 = StringManager.Instance.SpawnString();
    this.m_Str3 = StringManager.Instance.SpawnString();
    this.m_ConditionHint = StringManager.Instance.SpawnString(1024);
    Transform child3 = this.transform.GetChild(5);
    this.m_BattleHeroPanel = child3;
    this.m_BattleHeroBg[0] = child3.GetChild(0);
    this.m_BattleHeroBg[1] = child3.GetChild(1);
    this.tempSprite = child3.GetChild(6).GetComponent<Image>().sprite;
    for (int index = 0; index < this.m_BattleHero.Length; ++index)
    {
      this.m_BattleHeroTf[index] = child3.GetChild(index + 6);
      this.m_BattleHeroStartImage[index] = child3.GetChild(index + 6).GetChild(3).GetComponent<Image>();
      this.mConditionLock[index] = child3.GetChild(index + 6).GetChild(4);
      Transform child4 = child3.GetChild(index + 6).GetChild(1);
      this.m_BattleHero[index] = child4.GetComponent<UIHIBtn>();
      this.m_BattleHero[index].m_Handler = (IUIHIBtnClickHandler) this;
      this.m_BattleHero[index].m_BtnID1 = 2;
      GUIManager.Instance.InitianHeroItemImg(((Component) this.m_BattleHero[index]).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
      this.m_BattleHero[index].SoundIndex = (byte) 64;
      this.m_BattleHero[index].HIImage.sprite = this.tempSprite;
      ((Component) this.m_BattleHero[index]).gameObject.SetActive(false);
      this.frameMat = GUIManager.Instance.GetFrameMaterial();
      this.lightSprite = GUIManager.Instance.LoadFrameSprite("UI_super_light");
      Transform child5 = child3.GetChild(index + 6).GetChild(2);
      this.effectImages[index] = child5.GetComponent<Image>();
      this.effectImages[index].sprite = this.lightSprite;
      ((MaskableGraphic) this.effectImages[index]).material = this.frameMat;
      Transform child6 = child3.GetChild(index + 12);
      this.m_MoveBattleHeroTf[index] = child6;
      this.m_MoveBattleHero[index] = child6.GetComponent<UIHIBtn>();
      ((Component) this.m_MoveBattleHero[index]).gameObject.SetActive(false);
      GUIManager.Instance.InitianHeroItemImg(((Component) this.m_MoveBattleHero[index]).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
      Transform child7 = child3.GetChild(index + 6).GetChild(2);
      this.m_BattleHeroAmins[index] = child7.GetComponent<Animator>();
      this.m_BattleHeroAmins[index].gameObject.SetActive(false);
    }
    this.m_ScoreBG = child3.GetChild(11);
    this.m_ScoreBG2 = this.transform.GetChild(14);
    UIButtonHint uiButtonHint2 = child3.GetChild(11).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint2.Parm1 = (ushort) 1;
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    UIButtonHint uiButtonHint3 = this.transform.GetChild(14).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint3.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint3.Parm1 = (ushort) 3;
    uiButtonHint3.m_eHint = EUIButtonHint.DownUpHandler;
    this.m_ScorePowerImage = child3.GetChild(11).GetChild(0).GetComponent<Image>();
    this.m_ScoreText = child3.GetChild(11).GetChild(1).GetComponent<UIText>();
    this.m_ScoreText.font = GUIManager.Instance.GetTTFFont();
    this.m_ScoreText2 = this.transform.GetChild(14).GetChild(1).GetComponent<UIText>();
    this.m_ScoreText2.font = GUIManager.Instance.GetTTFFont();
    this.m_ScorePowerImage2 = this.transform.GetChild(14).GetChild(0).GetComponent<Image>();
    Transform child8 = this.transform.GetChild(6);
    this.m_KingSkill = child8.GetComponent<UIButton>();
    this.m_KingSkill.m_Handler = (IUIButtonClickHandler) this;
    this.m_KingSkill.m_BtnID1 = 3;
    this.m_tmptext[this.mTextCount] = child8.GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = GUIManager.Instance.GetTTFFont();
    ++this.mTextCount;
    Transform child9 = this.transform.GetChild(23);
    this.m_KingSkillPanel = child9.GetComponent<UIButton>();
    this.m_KingSkillPanel.m_Handler = (IUIButtonClickHandler) this;
    this.m_KingSkillPanel.m_BtnID1 = 4;
    this.m_Hint = this.transform.GetChild(24);
    this.m_HintImage = this.transform.GetChild(24).gameObject.GetComponent<Image>();
    this.m_HintText = this.transform.GetChild(24).GetChild(0).GetComponent<UIText>();
    this.m_HintText.font = GUIManager.Instance.GetTTFFont();
    for (int index = 0; index < 8; ++index)
    {
      Transform child10 = child9.GetChild(index);
      UIButton component3 = child10.GetComponent<UIButton>();
      component3.m_Handler = (IUIButtonClickHandler) this;
      component3.m_BtnID1 = 4;
      component3.m_BtnID2 = index + 1;
      this.m_tmptext[this.mTextCount] = child10.GetChild(1).GetComponent<UIText>();
      this.m_tmptext[this.mTextCount].font = GUIManager.Instance.GetTTFFont();
      ++this.mTextCount;
    }
    Transform child11 = this.transform.GetChild(15);
    UIButton component4 = child11.GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_BtnID1 = 5;
    component4.SoundIndex = this.SelectMode != UIBattleHeroSelect._SelectMode.ArenaDefense ? byte.MaxValue : (byte) 0;
    this.m_BattleButtonImage = child11.GetChild(0).GetComponent<Image>();
    this.m_FightButtonText = child11.GetChild(1).GetComponent<UIText>();
    this.m_FightButtonText.font = GUIManager.Instance.GetTTFFont();
    this.m_FightButtonText.text = DataManager.Instance.mStringTable.GetStringByID(9127U);
    ((Behaviour) this.m_FightButtonText).enabled = false;
    this.m_FightButtonPosition = ((Transform) ((Component) component4).gameObject.GetComponent<RectTransform>()).localPosition;
    this.m_HerosView = this.transform.GetChild(18).GetComponent<ScrollView>();
    Transform child12 = this.m_HerosView.customItem.transform.GetChild(0);
    this.m_HerosView.customItem.GetComponent<ScrollItem>().SoundIndex = (byte) 64;
    this.m_HerosView.customItem.transform.GetChild(2).GetComponent<Image>().sprite = this.lightSprite;
    ((MaskableGraphic) this.m_HerosView.customItem.transform.GetChild(2).GetComponent<Image>()).material = this.frameMat;
    GUIManager.Instance.InitianHeroItemImg(child12, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component5 = this.transform.GetChild(22).GetChild(1).GetComponent<RectTransform>();
      Vector3 localScale = ((Transform) component5).localScale with
      {
        x = -1f
      };
      ((Transform) component5).localScale = localScale;
    }
    for (int index = 0; index < 3; ++index)
    {
      Transform child13 = this.transform.GetChild(19 + index);
      this.scrollBlack[index] = child13.GetComponent<Image>();
    }
    for (int index = 1; index < 3; ++index)
    {
      this.scrollBlack[index].sprite = GUIManager.Instance.LoadFrameSprite("UI_shared_black");
      ((MaskableGraphic) this.scrollBlack[index]).material = this.frameMat;
    }
    Transform child14 = this.transform.GetChild(25);
    this.m_Preview = child14.GetComponent<UIButton>();
    this.m_Preview.m_Handler = (IUIButtonClickHandler) this;
    this.m_Preview.m_BtnID1 = 6;
    this.m_Previewicon[0] = child14.GetChild(0).GetComponent<Image>();
    this.m_Previewicon[1] = child14.GetChild(1).GetComponent<Image>();
    this.m_PreviewPanel = this.transform.GetChild(26);
    this.m_ConditionText[1] = this.m_PreviewPanel.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.m_ConditionText[1].font = GUIManager.Instance.GetTTFFont();
    this.m_ConditionText[1].text = DataManager.Instance.mStringTable.GetStringByID(10005U);
    this.m_ConditioniconPanel = this.m_PreviewPanel.GetChild(2);
    for (int index = 0; index < 8; ++index)
    {
      this.m_ConditioniconItem[index] = this.m_ConditioniconPanel.GetChild(index);
      UIButtonHint uiButtonHint4 = ((Component) this.m_ConditioniconPanel.GetChild(index).GetChild(0).GetComponent<UIButton>()).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint4.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint4.m_Handler = (MonoBehaviour) this;
      uiButtonHint4.Parm1 = (ushort) 4;
      uiButtonHint4.Parm2 = (byte) index;
      this.m_ConditionBG[index] = this.m_ConditioniconPanel.GetChild(index).GetChild(1).GetComponent<Image>();
      ((Component) this.m_ConditionBG[index]).gameObject.SetActive(false);
      this.m_ConditionF[index] = this.m_ConditioniconPanel.GetChild(index).GetChild(2).GetComponent<Image>();
      ((Component) this.m_ConditionF[index]).gameObject.SetActive(false);
    }
    int index1 = 0;
    if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
    {
      for (int index2 = 0; index2 < this.tmpSCD.ConditionArray.Length; ++index2)
      {
        ((Component) this.m_ConditionBG[index2]).gameObject.SetActive(false);
        if (this.tmpSCD.ConditionArray[index2].ConditionID != (byte) 0)
        {
          this.m_ConditioniconItem[index2].gameObject.SetActive(true);
          ((Component) this.m_ConditionBG[index2]).gameObject.SetActive(true);
          this.m_ConditionBG[index2].sprite = DataManager.StageDataController.GetStageConditionSprite(this.tmpSCD.ConditionArray[index2].ConditionID, this.tmpSCD.ConditionArray[index2].FactorA, this.tmpSCD.ConditionArray[index2].FactorB);
          ((MaskableGraphic) this.m_ConditionBG[index2]).material = DataManager.StageDataController.GetStageConditionMaterial(this.tmpSCD.ConditionArray[index2].ConditionID);
          ++index1;
        }
      }
      if (this.tmp_C_Count > (ushort) 0)
      {
        for (int tmpCCount = (int) this.tmp_C_Count; tmpCCount < this.mConditionLock.Length; ++tmpCCount)
          this.mConditionLock[tmpCCount].gameObject.SetActive(true);
      }
    }
    this.m_ConditioniconItem[index1].gameObject.SetActive(true);
    ((Component) this.m_ConditionBG[index1]).gameObject.SetActive(true);
    this.m_ConditionBG[index1].sprite = DataManager.StageDataController.GetStageConditionSprite(byte.MaxValue, (ushort) 0, (ushort) 0);
    ((MaskableGraphic) this.m_ConditionBG[index1]).material = DataManager.StageDataController.GetStageConditionMaterial(byte.MaxValue);
    this.mChallengeTitle = this.transform.GetChild(27);
    this.m_ConditionText[0] = this.mChallengeTitle.GetChild(0).GetComponent<UIText>();
    this.m_ConditionText[0].font = GUIManager.Instance.GetTTFFont();
    this.m_ConditionText[0].text = DataManager.Instance.mStringTable.GetStringByID(10048U);
    int index3 = 0;
    ushort id = 0;
    if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero)
      DataManager.Instance.GetHeroBattleDataSave();
    if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition && !GUIManager.Instance.bBackInPreviewModel)
    {
      DataManager.Instance.GetHero_Condition_BattleDataSave();
      for (int index4 = 0; index4 < DataManager.Instance.heroBattleConditionData.Length; ++index4)
        DataManager.Instance.heroBattleData[index4].HeroID = DataManager.Instance.heroBattleConditionData[index4].HeroID;
    }
    if (NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
    {
      Array.Clear((Array) DataManager.Instance.heroBattleData, 0, 5);
      this.NewbieSort();
    }
    for (int index5 = 0; index5 < 5; ++index5)
    {
      if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero)
        id = DataManager.Instance.heroBattleData[index5].HeroID;
      else if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaDefense)
        id = ArenaManager.Instance.m_ArenaDefHero[index5];
      else if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaAttack)
      {
        this.SetEnemyHero();
        id = ArenaManager.Instance.m_ArenaTargetHero[index5];
      }
      else if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
        id = this.CheckCondition_HeroNum((ushort) (index5 + 1)) ? (ushort) 0 : DataManager.Instance.heroBattleData[index5].HeroID;
      else if (DataManager.Instance.m_FightNpcData.ContainsKey(this.MonsterID))
        id = DataManager.Instance.m_FightNpcData[this.MonsterID].HeroID[index5];
      if (this.CheckCanSelectById(id) == e_SelecBtnState.None)
      {
        this.m_BattleHeroID[index3] = id;
        if (DataManager.Instance.curHeroData.ContainsKey((uint) this.m_BattleHeroID[index3]))
        {
          ((Component) this.m_BattleHero[index3]).gameObject.SetActive(true);
          CurHeroData curHeroData = DataManager.Instance.curHeroData[(uint) this.m_BattleHeroID[index3]];
          this.m_BattleHero[index3].m_BtnID2 = (int) this.m_BattleHeroID[index3];
          if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition)
            GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_BattleHero[index3]).transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level);
          else
            GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_BattleHero[index3]).transform, eHeroOrItem.Hero, curHeroData.ID, this.LevelexDate.Star, this.LevelexDate.Rank, (int) this.LevelexDate.LV);
          if (index3 < this.m_BattleHeroStartImage.Length)
            ((Component) this.m_BattleHeroStartImage[index3]).gameObject.SetActive(this.CheckAstrology(curHeroData.ID));
          ++this.m_BattleHeroNum;
          ++index3;
        }
      }
    }
    this.m_HerosView.AddHender((IUpDateRowItem) this);
    this.m_HerosView.GetComponent<Mask>().showMaskGraphic = false;
    this.itemScrollRect = this.m_HerosView.transform.GetComponent<CScrollRect>();
    this.itemCont = this.m_HerosView.transform.GetChild(0).GetComponent<RectTransform>();
    if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
    {
      this.mChallengeTitle.gameObject.SetActive(true);
      ((Component) this.m_Preview).gameObject.SetActive(true);
      if (GUIManager.Instance.bBackInPreviewModel)
      {
        this.OnButtonClick(this.m_Preview);
        this.itemScrollRect.StopMovement();
        this.itemCont.anchoredPosition = this.itemCont.anchoredPosition with
        {
          y = GUIManager.Instance.BackInPreviewHight
        };
        this.m_HerosView.SetContentSize((int) DataManager.Instance.CurHeroDataCount);
        this.m_HerosView.UpDateAllItem();
        GUIManager.Instance.bBackInPreviewModel = false;
      }
      this.m_ScoreBG.gameObject.SetActive(false);
    }
    this.m_Str.ClearString();
    StringManager.Instance.IntToFormat((long) this.GetAllPower(), bNumber: true);
    this.m_Str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(53U));
    this.m_ScoreText.text = this.m_Str.ToString();
    this.m_ScoreText.SetAllDirty();
    this.m_ScoreText.cachedTextGenerator.Invalidate();
    this.m_ScoreText.cachedTextGeneratorForLayout.Invalidate();
    this.m_ScoreText2.text = this.m_Str.ToString();
    this.m_ScoreText2.SetAllDirty();
    this.m_ScoreText2.cachedTextGenerator.Invalidate();
    this.m_ScoreText2.cachedTextGeneratorForLayout.Invalidate();
    this.SetCenterText(this.m_ScorePowerImage, this.m_ScoreText, 371f);
    this.SetCenterText(this.m_ScorePowerImage2, this.m_ScoreText2, 292f);
    this.m_HerosView.SetContentSize((int) DataManager.Instance.CurHeroDataCount);
    for (int index6 = 0; index6 < 5; ++index6)
      this.moveStack[index6] = new MoveObject();
    if ((UnityEngine.Object) menu != (UnityEngine.Object) null && this.SelectMode != UIBattleHeroSelect._SelectMode.ArenaDefense)
    {
      GUIManager.Instance.pDVMgr.FightBeginPos = this.transform.GetChild(15).localPosition;
      menu.ShowFightButton(this.m_FightButtonPosition + this.m_AddPositio, 250f, BtnKind: E3DButtonKind.BK_Big);
    }
    this.SetUIBySelectMode(this.SelectMode);
    NewbieManager.CheckTeach(ETeachKind.BATTLE_BEFORE, (object) this);
    if (!GUIManager.Instance.IsArabic)
      return;
    this.Swap(this.m_BattleHeroTf[1], this.m_BattleHeroTf[2]);
    this.Swap(this.m_BattleHeroTf[3], this.m_BattleHeroTf[4]);
    RectTransform component6 = this.transform.GetChild(22).GetChild(1).GetComponent<RectTransform>();
    Vector3 localScale1 = ((Transform) component6).localScale with
    {
      x = -1f
    };
    ((Transform) component6).localScale = localScale1;
  }

  private void Swap(Transform t1, Transform t2)
  {
    Vector2 anchoredPosition = t1.gameObject.GetComponent<RectTransform>().anchoredPosition;
    t1.gameObject.GetComponent<RectTransform>().anchoredPosition = t2.gameObject.GetComponent<RectTransform>().anchoredPosition;
    t2.gameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
  }

  public void NewbieSort()
  {
    DataManager instance = DataManager.Instance;
    int index1 = Array.IndexOf<uint>(instance.sortHeroData, 1U);
    if (index1 != -1)
    {
      instance.sortHeroData[index1] = instance.sortHeroData[0];
      instance.sortHeroData[0] = 1U;
    }
    int index2 = Array.IndexOf<uint>(instance.sortHeroData, 9U);
    if (index2 == -1)
      return;
    instance.sortHeroData[index2] = instance.sortHeroData[1];
    instance.sortHeroData[1] = 9U;
  }

  public void OnButtonClick(UIButton sender)
  {
    if ((double) this.fightButtonTime > 0.0)
      return;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    switch (sender.m_BtnID1)
    {
      case 1:
        if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
          break;
        GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_ArenaBattle);
        menu.CloseMenu();
        break;
      case 3:
        ((Component) this.m_KingSkillPanel).gameObject.SetActive(true);
        break;
      case 4:
        if (sender.m_BtnID2 > 0)
        {
          ((Component) this.m_KingSkillPanel).transform.GetChild((int) this.m_KingSkillIndex).GetChild(0).gameObject.SetActive(false);
          ((Component) sender).transform.GetChild(0).gameObject.SetActive(true);
          ((Component) this.m_KingSkill).transform.GetChild(0).GetComponent<UIText>().text = sender.m_BtnID2.ToString();
          this.m_KingSkillIndex = (byte) (sender.m_BtnID2 - 1);
        }
        ((Component) this.m_KingSkillPanel).gameObject.SetActive(false);
        break;
      case 5:
        DataManager instance = DataManager.Instance;
        if (this.m_BattleHeroNum > (byte) 0)
        {
          if (!this.CheckHeroRes())
          {
            GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8350U), (ushort) byte.MaxValue);
            break;
          }
          if ((this.SelectMode == UIBattleHeroSelect._SelectMode.Hero || this.SelectMode == UIBattleHeroSelect._SelectMode.Condition) && !WarManager.CheckVersion() || this.CheckCondition_HeroID())
            break;
          if (!NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
          {
            uint num = instance.NonFightHeroCount;
            if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition && this.bConditionCount)
              num = (uint) this.tmp_C_Count;
            if ((int) this.m_BattleHeroNum < instance.heroBattleData.Length && (uint) this.m_BattleHeroNum < num)
            {
              GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, (string) null, instance.mStringTable.GetStringByID(35U));
              this.bCanClickbtn = true;
              break;
            }
          }
          Array.Clear((Array) instance.heroBattleData, 0, instance.heroBattleData.Length);
          for (int index = 0; index < 5; ++index)
            instance.heroBattleData[index].HeroID = this.m_BattleHeroID[index];
          instance.heroCount = this.m_BattleHeroNum;
          if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero || this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
          {
            BattleNetwork.sendInitBattle();
            break;
          }
          if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaDefense)
          {
            ArenaManager.Instance.SendArena_Set_DefHero(this.m_BattleHeroID);
            break;
          }
          if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaAttack)
          {
            GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_ArenaBattle);
            for (int index = 0; index < 5; ++index)
              ArenaManager.Instance.m_ArenaTargetHero[index] = this.m_BattleHeroID[index];
            ArenaManager.Instance.SendArena_Challenge((byte) this.m_ArenaTargetIdx);
            break;
          }
          if (!this.CheckMonsterRule())
            break;
          this.UpdateUI(0, 0);
          break;
        }
        GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(39U), (ushort) byte.MaxValue);
        break;
      case 6:
        this.bPreviewHeroModel = !this.bPreviewHeroModel;
        ((Component) this.m_Previewicon[0]).gameObject.SetActive(!this.bPreviewHeroModel);
        ((Component) this.m_Previewicon[1]).gameObject.SetActive(this.bPreviewHeroModel);
        this.m_BattleHeroPanel.gameObject.SetActive(!this.bPreviewHeroModel);
        this.m_PreviewPanel.gameObject.SetActive(this.bPreviewHeroModel);
        this.m_ConditioniconPanel.gameObject.SetActive(true);
        this.mChallengeTitle.gameObject.SetActive(!this.bPreviewHeroModel);
        if (!((UnityEngine.Object) this.itemCont != (UnityEngine.Object) null))
          break;
        for (int index = 0; index < ((Transform) this.itemCont).childCount; ++index)
        {
          UIHIBtn component = ((Transform) this.itemCont).GetChild(index).GetChild(0).GetComponent<UIHIBtn>();
          if ((UnityEngine.Object) component != (UnityEngine.Object) null)
          {
            if (component.m_BtnID4 == 1 && this.bPreviewHeroModel)
              ((Transform) this.itemCont).GetChild(index).GetChild(5).gameObject.SetActive(true);
            else
              ((Transform) this.itemCont).GetChild(index).GetChild(5).gameObject.SetActive(false);
          }
        }
        break;
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    if ((double) this.fightButtonTime > 0.0)
      return;
    switch (sender.m_BtnID1)
    {
      case 2:
        int index = ((Component) sender).transform.parent.GetSiblingIndex() - 6;
        if (index >= (int) this.m_BattleHeroNum)
          break;
        this.NeedShowFlashID = this.m_BattleHeroID[index];
        this.RemoveBattleHero(index);
        this.m_HerosView.UpDateAllItem();
        this.NeedShowFlashID = (ushort) 0;
        break;
      case 6:
        ScrollItem component = ((Component) sender).transform.parent.GetComponent<ScrollItem>();
        this.ButtonOnClick(((Component) component).gameObject, component.m_BtnID1);
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (bOK)
    {
      DataManager instance = DataManager.Instance;
      for (int index = 0; index < 5; ++index)
        instance.heroBattleData[index].HeroID = this.m_BattleHeroID[index];
      instance.heroCount = this.m_BattleHeroNum;
      if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero || this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
        BattleNetwork.sendInitBattle();
      else if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaDefense)
        ArenaManager.Instance.SendArena_Set_DefHero(this.m_BattleHeroID);
      else if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaAttack)
      {
        for (int index = 0; index < 5; ++index)
          ArenaManager.Instance.m_ArenaTargetHero[index] = this.m_BattleHeroID[index];
        ArenaManager.Instance.SendArena_Challenge((byte) this.m_ArenaTargetIdx);
      }
      else if (this.SelectMode == UIBattleHeroSelect._SelectMode.Monster && this.CheckMonsterRule())
        this.UpdateUI(0, 0);
    }
    this.bCanClickbtn = false;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        Door menu1 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((UnityEngine.Object) menu1 != (UnityEngine.Object) null))
          break;
        this.fightButtonTime = menu1.PlayFight();
        this.SaveTempHeroData();
        GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Expedition);
        GUIManager.Instance.ShowUILock(EUILock.Normal);
        break;
      case 2:
        this.m_HerosView.SetContentSize((int) DataManager.Instance.CurHeroDataCount);
        this.m_HerosView.UpDateAllItem();
        break;
      case 3:
        this.CheckSelectHero();
        this.m_HerosView.SetContentSize((int) DataManager.Instance.CurHeroDataCount);
        this.m_HerosView.UpDateAllItem();
        break;
      case 4:
        DataManager.Instance.SaveNpcBattleHeroID(this.MonsterID, this.m_BattleHeroID);
        Door menu2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (arg2 > 0)
        {
          menu2.CloseMenu(true);
          break;
        }
        menu2.CloseMenu();
        break;
      case 5:
        Door menu3 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (UnityEngine.Object) menu3)
          break;
        menu3.CloseMenu();
        break;
      case 6:
        GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_ArenaBattle);
        Door menu4 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (UnityEngine.Object) menu4)
          break;
        menu4.CloseMenu();
        break;
      case 7:
        this.SetEnemyHero();
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
      case NetworkNews.Refresh_Hero:
        if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
          DataManager.SortConditionHeroData();
        else
          DataManager.SortHeroData();
        if (NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE))
          this.NewbieSort();
        this.m_HerosView.SetContentSize((int) DataManager.Instance.CurHeroDataCount);
        this.m_HerosView.UpDateAllItem();
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
    if ((UnityEngine.Object) this.m_ScoreText != (UnityEngine.Object) null && ((Behaviour) this.m_ScoreText).enabled)
    {
      ((Behaviour) this.m_ScoreText).enabled = false;
      ((Behaviour) this.m_ScoreText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_ScoreText2 != (UnityEngine.Object) null && ((Behaviour) this.m_ScoreText2).enabled)
    {
      ((Behaviour) this.m_ScoreText2).enabled = false;
      ((Behaviour) this.m_ScoreText2).enabled = true;
    }
    for (int index = 0; index < 9; ++index)
    {
      if ((UnityEngine.Object) this.m_tmptext[index] != (UnityEngine.Object) null && ((Behaviour) this.m_tmptext[index]).enabled)
      {
        ((Behaviour) this.m_tmptext[index]).enabled = false;
        ((Behaviour) this.m_tmptext[index]).enabled = true;
      }
    }
    if (this.m_BattleHero != null)
    {
      for (int index = 0; index < this.m_BattleHero.Length; ++index)
      {
        if ((UnityEngine.Object) this.m_BattleHero[index] != (UnityEngine.Object) null && ((Behaviour) this.m_BattleHero[index]).enabled)
          this.m_BattleHero[index].Refresh_FontTexture();
      }
    }
    if (this.m_MoveBattleHero != null)
    {
      for (int index = 0; index < this.m_MoveBattleHero.Length; ++index)
      {
        if ((UnityEngine.Object) this.m_MoveBattleHero[index] != (UnityEngine.Object) null && ((Behaviour) this.m_MoveBattleHero[index]).enabled)
          this.m_MoveBattleHero[index].Refresh_FontTexture();
      }
    }
    if ((UnityEngine.Object) this.m_FightButtonText != (UnityEngine.Object) null && ((Behaviour) this.m_FightButtonText).enabled)
    {
      ((Behaviour) this.m_FightButtonText).enabled = false;
      ((Behaviour) this.m_FightButtonText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_HintText != (UnityEngine.Object) null && ((Behaviour) this.m_HintText).enabled)
    {
      ((Behaviour) this.m_HintText).enabled = false;
      ((Behaviour) this.m_HintText).enabled = true;
    }
    if (!((UnityEngine.Object) this.m_EnemyPower != (UnityEngine.Object) null) || !((Behaviour) this.m_EnemyPower).enabled)
      return;
    ((Behaviour) this.m_EnemyPower).enabled = false;
    ((Behaviour) this.m_EnemyPower).enabled = true;
  }

  public override void OnClose()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (this.m_Str != null)
      StringManager.Instance.DeSpawnString(this.m_Str);
    if (this.m_Str2 != null)
      StringManager.Instance.DeSpawnString(this.m_Str2);
    if (this.m_Str3 != null)
      StringManager.Instance.DeSpawnString(this.m_Str3);
    if (this.m_ConditionHint != null)
      StringManager.Instance.DeSpawnString(this.m_ConditionHint);
    if (!(bool) (UnityEngine.Object) menu)
      return;
    menu.HideFightButton();
  }

  public void Initialized()
  {
  }

  public void UpDateRowItem(GameObject[] gameObjs, int[] btnIndexs)
  {
    uint curHeroDataCount = DataManager.Instance.CurHeroDataCount;
    for (int index1 = 0; index1 < gameObjs.Length; ++index1)
    {
      if ((long) btnIndexs[index1] < (long) curHeroDataCount)
      {
        uint key = DataManager.Instance.sortHeroData[btnIndexs[index1]];
        if (DataManager.Instance.curHeroData.ContainsKey(key))
        {
          CurHeroData curHeroData = DataManager.Instance.curHeroData[key];
          Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(curHeroData.ID);
          ((Component) gameObjs[index1].transform.GetChild(2).GetComponent<Image>()).gameObject.SetActive(false);
          if ((int) this.NeedShowFlashID == (int) curHeroData.ID)
            ((Component) gameObjs[index1].transform.GetChild(2).GetComponent<Image>()).gameObject.SetActive(true);
          Color color = Color.white;
          ((Component) gameObjs[index1].transform.GetChild(1).GetComponent<Image>()).gameObject.SetActive(false);
          for (int index2 = 0; index2 < (int) this.m_BattleHeroNum; ++index2)
          {
            if ((int) recordByKey.HeroKey == (int) this.m_BattleHeroID[index2])
            {
              color = Color.gray;
              ((Component) gameObjs[index1].transform.GetChild(1).GetComponent<Image>()).gameObject.SetActive(true);
              break;
            }
          }
          UIHIBtn component1 = gameObjs[index1].transform.GetChild(0).GetComponent<UIHIBtn>();
          component1.m_BtnID1 = 6;
          if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition)
            GUIManager.Instance.ChangeHeroItemImg(((Component) component1).transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level);
          else
            GUIManager.Instance.ChangeHeroItemImg(((Component) component1).transform, eHeroOrItem.Hero, curHeroData.ID, this.LevelexDate.Star, this.LevelexDate.Rank, (int) this.LevelexDate.LV);
          gameObjs[index1].transform.GetChild(3).gameObject.SetActive(false);
          e_SelecBtnState eSelecBtnState = this.CheckCanSelectById(curHeroData.ID);
          if (eSelecBtnState != e_SelecBtnState.None)
          {
            Image component2 = gameObjs[index1].transform.GetChild(3).GetComponent<Image>();
            color = Color.gray;
            gameObjs[index1].transform.GetChild(3).gameObject.SetActive(true);
            if (eSelecBtnState == e_SelecBtnState.Fighting)
              component2.sprite = this.m_SpArray.GetSprite(0);
            else if (eSelecBtnState == e_SelecBtnState.LordJail)
              component2.sprite = this.m_SpArray.GetSprite(1);
            else if (eSelecBtnState == e_SelecBtnState.LordKilled)
              component2.sprite = this.m_SpArray.GetSprite(2);
            else if (eSelecBtnState == e_SelecBtnState.Condition)
              component2.sprite = this.m_SpArray.GetSprite(3);
          }
          ((Component) gameObjs[index1].transform.GetChild(4).GetComponent<Image>()).gameObject.SetActive(this.CheckAstrology(curHeroData.ID));
          if (eSelecBtnState != e_SelecBtnState.Condition)
            gameObjs[index1].transform.GetChild(0).GetComponent<UIHIBtn>().m_BtnID4 = 1;
          else
            gameObjs[index1].transform.GetChild(0).GetComponent<UIHIBtn>().m_BtnID4 = 2;
          if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition && this.bPreviewHeroModel && gameObjs[index1].transform.GetChild(0).GetComponent<UIHIBtn>().m_BtnID4 == 1)
            gameObjs[index1].transform.GetChild(5).gameObject.SetActive(true);
          else
            gameObjs[index1].transform.GetChild(5).gameObject.SetActive(false);
          if (eSelecBtnState == e_SelecBtnState.Fighting || eSelecBtnState == e_SelecBtnState.LordJail || eSelecBtnState == e_SelecBtnState.LordJail)
          {
            color = Color.gray;
            gameObjs[index1].transform.GetChild(3).gameObject.SetActive(true);
          }
          ((Graphic) component1.HIImage).color = color;
          ((Graphic) component1.CircleImage).color = color;
          ((Graphic) component1.LvOrNum).color = color;
        }
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex)
  {
    if (this.bMoving || (double) this.fightButtonTime > 0.0 || this.MoveBtnCount > 0 || this.bCanClickbtn)
      return;
    uint num = DataManager.Instance.sortHeroData[dataIndex];
    if (this.CheckPreviewHeroModel(num, dataIndex) || !DataManager.Instance.curHeroData.ContainsKey(num))
      return;
    if (this.CheckCanSelectById((ushort) num) != e_SelecBtnState.None)
    {
      if (this.CheckCondition_HeroTopic((ushort) num, true))
        return;
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(708U), (ushort) byte.MaxValue);
    }
    else
    {
      CurHeroData curHeroData = DataManager.Instance.curHeroData[num];
      Hero recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(curHeroData.ID);
      UIHIBtn component = gameObject.transform.GetChild(0).GetComponent<UIHIBtn>();
      for (int index = 0; index < (int) this.m_BattleHeroNum; ++index)
      {
        if ((int) recordByKey1.HeroKey == (int) this.m_BattleHeroID[index])
        {
          this.RemoveBattleHero(index);
          ((Graphic) component.HIImage).color = Color.white;
          ((Graphic) component.CircleImage).color = Color.white;
          ((Graphic) component.LvOrNum).color = Color.white;
          ((Component) gameObject.transform.GetChild(1).GetComponent<Image>()).gameObject.SetActive(false);
          return;
        }
      }
      if (this.CheckCondition_HeroNum((ushort) ((uint) this.m_BattleHeroNum + 1U)))
      {
        GUIManager.Instance.MsgStr.ClearString();
        DataManager.StageDataController.GetStageConditionString(GUIManager.Instance.MsgStr, this.tmpSCD.ConditionArray[this.mCondition_CountIdx].ConditionID, this.tmpSCD.ConditionArray[this.mCondition_CountIdx].FactorA, this.ConditionKey, (ushort) 0);
        GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), (ushort) byte.MaxValue);
      }
      else if ((int) this.m_BattleHeroNum >= this.m_BattleHero.Length)
      {
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(36U), (ushort) byte.MaxValue);
      }
      else
      {
        int index1;
        for (index1 = 0; index1 < (int) this.m_BattleHeroNum; ++index1)
        {
          Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(this.m_BattleHeroID[index1]);
          if ((int) recordByKey1.Pos < (int) recordByKey2.Pos)
            break;
        }
        ((Component) this.m_BattleHero[(int) this.m_BattleHeroNum]).gameObject.SetActive(true);
        this.m_BattleHero[(int) this.m_BattleHeroNum].m_BtnID2 = (int) curHeroData.ID;
        for (int battleHeroNum = (int) this.m_BattleHeroNum; battleHeroNum > index1; --battleHeroNum)
        {
          int beginIdx = battleHeroNum - 1;
          int endBtnIdx = battleHeroNum;
          Vector2 anchoredPosition1 = ((Component) this.m_BattleHero[battleHeroNum - 1]).transform.parent.GetComponent<RectTransform>().anchoredPosition;
          Vector2 anchoredPosition2 = ((Component) this.m_BattleHero[battleHeroNum]).transform.parent.GetComponent<RectTransform>().anchoredPosition;
          this.AddToMoveStack(beginIdx, this.m_BattleHeroID[beginIdx], anchoredPosition1, anchoredPosition2, endBtnIdx);
          this.m_BattleHeroID[endBtnIdx] = this.m_BattleHeroID[beginIdx];
        }
        this.m_BattleHeroID[index1] = recordByKey1.HeroKey;
        if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition)
          GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_BattleHero[index1]).transform, eHeroOrItem.Hero, this.m_BattleHeroID[index1], curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level);
        else
          GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_BattleHero[index1]).transform, eHeroOrItem.Hero, this.m_BattleHeroID[index1], this.LevelexDate.Star, this.LevelexDate.Rank, (int) this.LevelexDate.LV);
        for (int index2 = 0; index2 < this.m_BattleHeroAmins.Length; ++index2)
          this.m_BattleHeroAmins[index2].gameObject.SetActive(false);
        this.m_BattleHeroAmins[index1].gameObject.SetActive(true);
        ((Component) this.m_BattleHero[index1]).gameObject.SetActive(true);
        ++this.m_BattleHeroNum;
        this.m_Str.ClearString();
        StringManager.Instance.IntToFormat((long) this.GetAllPower(), bNumber: true);
        this.m_Str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(53U));
        this.m_ScoreText.text = this.m_Str.ToString();
        this.m_ScoreText.SetAllDirty();
        this.m_ScoreText.cachedTextGenerator.Invalidate();
        this.m_ScoreText.cachedTextGeneratorForLayout.Invalidate();
        this.SetCenterText(this.m_ScorePowerImage, this.m_ScoreText, 371f);
        this.m_ScoreText2.text = this.m_Str.ToString();
        this.m_ScoreText2.SetAllDirty();
        this.m_ScoreText2.cachedTextGenerator.Invalidate();
        this.m_ScoreText2.cachedTextGeneratorForLayout.Invalidate();
        this.SetCenterText(this.m_ScorePowerImage2, this.m_ScoreText2, 292f);
        ((Graphic) component.HIImage).color = Color.gray;
        ((Graphic) component.CircleImage).color = Color.gray;
        ((Graphic) component.LvOrNum).color = Color.gray;
        ((Component) gameObject.transform.GetChild(1).GetComponent<Image>()).gameObject.SetActive(true);
        this.bNeedCheckAstrology = true;
      }
    }
  }

  private uint GetAllPower()
  {
    int length = this.m_BattleHeroID.Length;
    uint allPower = 0;
    for (int index = 0; index < length; ++index)
      allPower += this.GetPower(this.m_BattleHeroID[index]);
    return allPower;
  }

  private uint GetPower(ushort heroId)
  {
    uint power = 0;
    if (!DataManager.Instance.curHeroData.ContainsKey((uint) heroId))
      return power;
    CurHeroData curHeroData = DataManager.Instance.curHeroData[(uint) heroId];
    CalcAttrDataType CalcAttrData = new CalcAttrDataType();
    byte[] SkillLV = new byte[4];
    ushort[] pAttr1 = new ushort[28];
    ushort[] pAttr2 = new ushort[28];
    uint HP1 = 0;
    CalcAttrData.SkillLV1 = curHeroData.SkillLV[0];
    CalcAttrData.SkillLV2 = curHeroData.SkillLV[1];
    CalcAttrData.SkillLV3 = curHeroData.SkillLV[2];
    CalcAttrData.SkillLV4 = curHeroData.SkillLV[3];
    for (int index = 0; index < 4; ++index)
      SkillLV[index] = curHeroData.SkillLV[index];
    CalcAttrData.LV = curHeroData.Level;
    CalcAttrData.Star = curHeroData.Star;
    CalcAttrData.Enhance = curHeroData.Enhance;
    CalcAttrData.Equip = curHeroData.Equip;
    uint HP2 = 0;
    Array.Clear((Array) pAttr1, 0, pAttr1.Length);
    BSInvokeUtil.getInstance.setCalculateHeroEquipEffect(heroId, curHeroData.Enhance, curHeroData.Equip, ref HP2, pAttr1);
    Array.Clear((Array) pAttr2, 0, pAttr2.Length);
    BSInvokeUtil.getInstance.setCalculateAttribute(heroId, ref CalcAttrData, ref HP1, pAttr2);
    return BSInvokeUtil.getInstance.updateFightScore(heroId, HP1, pAttr2, SkillLV);
  }

  private void RemoveBattleHero(int index)
  {
    if ((double) this.fightButtonTime > 0.0 || this.MoveBtnCount > 0)
      return;
    for (int endBtnIdx = index; endBtnIdx < (int) this.m_BattleHeroNum - 1; ++endBtnIdx)
    {
      Vector2 anchoredPosition1 = ((Component) this.m_BattleHero[endBtnIdx + 1]).transform.parent.GetComponent<RectTransform>().anchoredPosition;
      Vector2 anchoredPosition2 = ((Component) this.m_BattleHero[endBtnIdx]).transform.parent.GetComponent<RectTransform>().anchoredPosition;
      this.AddToMoveStack(endBtnIdx + 1, this.m_BattleHeroID[endBtnIdx + 1], anchoredPosition1, anchoredPosition2, endBtnIdx);
      this.m_BattleHeroID[endBtnIdx] = this.m_BattleHeroID[endBtnIdx + 1];
    }
    --this.m_BattleHeroNum;
    if ((int) this.m_BattleHeroNum < this.m_BattleHero.Length)
    {
      this.m_BattleHeroID[(int) this.m_BattleHeroNum] = (ushort) 0;
      ((Component) this.m_BattleHero[(int) this.m_BattleHeroNum]).gameObject.SetActive(false);
    }
    this.m_Str.ClearString();
    StringManager.Instance.IntToFormat((long) this.GetAllPower(), bNumber: true);
    this.m_Str.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(53U));
    this.m_ScoreText.text = this.m_Str.ToString();
    this.m_ScoreText.SetAllDirty();
    this.m_ScoreText.cachedTextGenerator.Invalidate();
    this.m_ScoreText.cachedTextGeneratorForLayout.Invalidate();
    this.SetCenterText(this.m_ScorePowerImage, this.m_ScoreText, 371f);
    this.m_ScoreText2.text = this.m_Str.ToString();
    this.m_ScoreText2.SetAllDirty();
    this.m_ScoreText2.cachedTextGeneratorForLayout.Invalidate();
    this.m_ScoreText2.cachedTextGenerator.Invalidate();
    this.SetCenterText(this.m_ScorePowerImage2, this.m_ScoreText2, 292f);
    this.SetCenterText(this.m_ScorePowerImage, this.m_ScoreText, 371f);
    this.bNeedCheckAstrology = true;
  }

  private void AddToMoveStack(
    int beginIdx,
    ushort heroID,
    Vector2 begin,
    Vector2 end,
    int endBtnIdx)
  {
    if (endBtnIdx < 0 || endBtnIdx >= 5 || beginIdx < 0 || beginIdx >= 5)
      return;
    if (this.moveStack[beginIdx].bMoving)
    {
      GUIManager.Instance.AddHUDMessage("moveStack[{0}].bMoving", (ushort) byte.MaxValue);
    }
    else
    {
      ((Component) this.m_MoveBattleHero[beginIdx]).gameObject.SetActive(true);
      ((Component) this.m_BattleHero[beginIdx]).gameObject.SetActive(false);
      CurHeroData curHeroData = DataManager.Instance.curHeroData[(uint) heroID];
      if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition)
      {
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_MoveBattleHero[beginIdx]).transform, eHeroOrItem.Hero, heroID, curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level);
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_BattleHero[endBtnIdx]).transform, eHeroOrItem.Hero, heroID, curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level);
      }
      else
      {
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_MoveBattleHero[beginIdx]).transform, eHeroOrItem.Hero, heroID, this.LevelexDate.Star, this.LevelexDate.Rank, (int) this.LevelexDate.LV);
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_BattleHero[endBtnIdx]).transform, eHeroOrItem.Hero, heroID, this.LevelexDate.Star, this.LevelexDate.Rank, (int) this.LevelexDate.LV);
      }
      ((Component) this.m_MoveBattleHero[beginIdx]).gameObject.GetComponent<RectTransform>().anchoredPosition = begin;
      ((Component) this.m_BattleHero[endBtnIdx]).gameObject.SetActive(false);
      this.moveStack[beginIdx].heroID = heroID;
      this.moveStack[beginIdx].begin = begin;
      this.moveStack[beginIdx].end = end;
      this.moveStack[beginIdx].battleBtnIdx = endBtnIdx;
      this.moveStack[beginIdx].bMoving = true;
      ++this.MoveBtnCount;
    }
  }

  private void Update()
  {
    this.bMoving = false;
    for (int index = 0; index < this.moveStack.Length; ++index)
    {
      if (this.moveStack[index].bMoving)
      {
        this.bMoving = true;
        Vector2 vector2 = Vector2.MoveTowards(this.moveStack[index].begin, this.moveStack[index].end, 2000f * Time.deltaTime);
        ((Component) this.m_MoveBattleHero[index]).GetComponent<RectTransform>().anchoredPosition = vector2;
        this.moveStack[index].begin = vector2;
        if (this.moveStack[index].begin == this.moveStack[index].end)
        {
          ((Component) this.m_BattleHero[this.moveStack[index].battleBtnIdx]).gameObject.SetActive(true);
          ((Component) this.m_MoveBattleHero[index]).gameObject.SetActive(false);
          this.moveStack[index].bMoving = false;
          --this.MoveBtnCount;
          this.bNeedCheckAstrology = true;
        }
      }
    }
    if (this.bNeedCheckAstrology)
    {
      for (int index = 0; index < this.m_BattleHeroStartImage.Length; ++index)
        ((Component) this.m_BattleHeroStartImage[index]).gameObject.SetActive(this.CheckAstrology(this.m_BattleHeroID[index]));
      this.bNeedCheckAstrology = false;
    }
    if ((double) this.fightButtonTime <= 0.0)
      return;
    this.fightButtonTime -= Time.deltaTime;
    if ((double) this.fightButtonTime > 0.0)
      return;
    if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero || this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaAttack || this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaDefense || this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
    {
      if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero || this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
        DataManager.Instance.updateBattleData();
      AudioManager.Instance.LoadAndPlayBGM(BGMType.War, (byte) 1);
      GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.MapToBattle);
      GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Expedition);
      GUIManager.Instance.HideUILock(EUILock.Normal);
      if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero)
        DataManager.Instance.SetHeroBattleDataSave();
      if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition)
        return;
      DataManager.Instance.SetHero_Condition_BattleDataSave();
    }
    else
    {
      if (!GUIManager.Instance.ShowUILock(EUILock.Battle))
        return;
      ushort zoneID;
      byte pointID;
      GameConstants.MapIDToPointCode(this.MonsterMapID, out zoneID, out pointID);
      GUIManager.Instance.HideUILock(EUILock.Normal);
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_SENDMONSTER;
      messagePacket.AddSeqId();
      messagePacket.Add(zoneID);
      messagePacket.Add(pointID);
      messagePacket.Add((byte) this.AttackTimes);
      for (byte index = 0; index < (byte) 5; ++index)
        messagePacket.Add(this.m_BattleHeroID[(int) index]);
      messagePacket.Send();
    }
  }

  private bool CheckMonsterRule()
  {
    DataManager instance = DataManager.Instance;
    if (DataManager.Instance.RoleAlliance.Id == 0U)
    {
      GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8341U), (ushort) byte.MaxValue);
      return false;
    }
    int num = 0;
    uint effectBaseVal = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    for (int index = 0; index < 8; ++index)
    {
      if (DataManager.Instance.MarchEventData[index].Type != EMarchEventType.EMET_Standby)
      {
        ++num;
        if ((long) num == (long) effectBaseVal)
        {
          this.m_Str2.ClearString();
          this.m_Str2.IntToFormat((long) effectBaseVal);
          this.m_Str2.AppendFormat(instance.mStringTable.GetStringByID(8351U));
          GUIManager.Instance.AddHUDMessage(this.m_Str2.ToString(), (ushort) byte.MaxValue);
          return false;
        }
      }
    }
    if ((double) DataManager.MapDataController.CheckLenght(GameConstants.getTileMapPosbySpriteID(this.MonsterMapID)) != 0.0)
      return true;
    GUIManager.Instance.OpenMessageBox(instance.mStringTable.GetStringByID(3967U), instance.mStringTable.GetStringByID(119U), instance.mStringTable.GetStringByID(4034U));
    return false;
  }

  public void OnScroll(RectTransform rt)
  {
  }

  public override void ReOnOpen()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.ShowFightButton(this.m_FightButtonPosition + this.m_AddPositio, 200f, BtnKind: E3DButtonKind.BK_Big);
  }

  private e_SelecBtnState CheckCanSelectById(ushort id)
  {
    if (NewbieManager.IsTeachWorking(ETeachKind.BATTLE_BEFORE) || this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaAttack || this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaDefense)
      return e_SelecBtnState.None;
    e_SelecBtnState eSelecBtnState = e_SelecBtnState.None;
    DataManager instance = DataManager.Instance;
    if (this.CheckCondition_HeroTopic(id))
      return e_SelecBtnState.Condition;
    for (int index = 0; (long) index < (long) instance.FightHeroCount; ++index)
    {
      if ((int) instance.GetLeaderID() == (int) id)
      {
        if (instance.beCaptured.nowCaptureStat == LoadCaptureState.Captured)
          return e_SelecBtnState.LordJail;
        if (instance.beCaptured.nowCaptureStat == LoadCaptureState.Dead)
          return e_SelecBtnState.LordKilled;
      }
      if ((int) instance.FightHeroID[index] == (int) id)
        return e_SelecBtnState.Fighting;
    }
    return eSelecBtnState;
  }

  private bool CheckAstrology(ushort heroID)
  {
    return (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaDefense || this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaAttack) && heroID != (ushort) 0 && ArenaManager.Instance.CheckHeroAstrology(heroID);
  }

  private void CheckSelectHero()
  {
    for (int index = 0; index < this.m_BattleHero.Length; ++index)
    {
      if (this.CheckCanSelectById(this.m_BattleHeroID[index]) == e_SelecBtnState.LordJail)
        this.OnHIButtonClick(this.m_BattleHero[index]);
    }
  }

  private void SetEnemyHero()
  {
    ArenaManager instance = ArenaManager.Instance;
    if (this.m_ArenaTargetIdx < 0 || this.m_ArenaTargetIdx >= instance.m_ArenaTarget.Length)
      return;
    for (int index = 0; index < instance.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData.Length; ++index)
    {
      if (instance.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData[index].ID > (ushort) 0)
      {
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_BattleHeroEnemy[index]).transform, eHeroOrItem.Hero, instance.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData[index].ID, instance.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData[index].Star, instance.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData[index].Rank, (int) instance.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData[index].Level);
        ((Component) this.m_BattleHeroEnemy[index]).gameObject.SetActive(true);
        ((Component) this.m_EnemyAstrology[index]).gameObject.SetActive(this.CheckAstrology(instance.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData[index].ID));
        ((Component) this.m_EnemyBg[index]).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.m_EnemyAstrology[index]).gameObject.SetActive(false);
        ((Component) this.m_BattleHeroEnemy[index]).gameObject.SetActive(false);
        ((Component) this.m_EnemyBg[index]).gameObject.SetActive(true);
      }
    }
    this.m_Str3.ClearString();
    this.m_Str3.IntToFormat((long) instance.GetAllPower((byte) 1, (int) (byte) this.m_ArenaTargetIdx), bNumber: true);
    this.m_Str3.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(53U));
    this.m_EnemyPower.text = this.m_Str3.ToString();
    this.m_EnemyPower.SetAllDirty();
    this.m_EnemyPower.cachedTextGenerator.Invalidate();
    this.m_EnemyPower.cachedTextGeneratorForLayout.Invalidate();
    this.SetCenterText(this.m_EnemyPowerIcon, this.m_EnemyPower, 195f);
  }

  private void SetCenterText(Image image, UIText text, float width)
  {
    float num = 5f;
    float x = (float) (((double) width - ((double) ((Graphic) image).rectTransform.sizeDelta.x + (double) text.preferredWidth + (double) num)) / 2.0);
    ((Graphic) image).rectTransform.anchoredPosition = new Vector2(x, ((Graphic) image).rectTransform.anchoredPosition.y);
    Vector2 vector2 = text.ArabicFixPos(new Vector2(((Graphic) image).rectTransform.anchoredPosition.x + ((Graphic) image).rectTransform.sizeDelta.x + num, ((Graphic) text).rectTransform.anchoredPosition.y));
    ((Graphic) text).rectTransform.anchoredPosition = vector2;
  }

  private void SetUIBySelectMode(UIBattleHeroSelect._SelectMode mode)
  {
    switch (mode)
    {
      case UIBattleHeroSelect._SelectMode.ArenaDefense:
        for (int index = 0; index < this.m_BattleHero.Length; ++index)
        {
          Vector2 anchoredPosition = this.m_BattleHeroTf[index].GetComponent<RectTransform>().anchoredPosition;
          anchoredPosition.y -= 25f;
          this.m_BattleHeroTf[index].GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        }
        for (int index = 0; index < this.m_BattleHeroBg.Length; ++index)
        {
          Vector2 anchoredPosition = this.m_BattleHeroBg[index].GetComponent<RectTransform>().anchoredPosition;
          anchoredPosition.y -= 25f;
          this.m_BattleHeroBg[index].GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        }
        ((Behaviour) this.m_BattleButtonImage).enabled = false;
        ((Behaviour) this.m_FightButtonText).enabled = true;
        break;
      case UIBattleHeroSelect._SelectMode.ArenaAttack:
        for (int index = 0; index < this.m_BattleHeroTf.Length; ++index)
        {
          this.m_BattleHeroTf[index].localScale = new Vector3(0.812f, 0.812f, 1f);
          this.m_MoveBattleHeroTf[index].localScale = new Vector3(0.812f, 0.812f, 1f);
        }
        this.m_BattleHeroTf[0].GetComponent<RectTransform>().anchoredPosition = new Vector2(2f, 116f);
        this.m_BattleHeroTf[1].GetComponent<RectTransform>().anchoredPosition = new Vector2(-109.5f, 97f);
        this.m_BattleHeroTf[2].GetComponent<RectTransform>().anchoredPosition = new Vector2(112.5f, 97f);
        this.m_BattleHeroTf[3].GetComponent<RectTransform>().anchoredPosition = new Vector2(-219.5f, 78f);
        this.m_BattleHeroTf[4].GetComponent<RectTransform>().anchoredPosition = new Vector2(223.5f, 78f);
        this.m_TheEnemyPanel.gameObject.SetActive(true);
        this.m_ScoreBG.gameObject.SetActive(false);
        this.m_ScoreBG2.gameObject.SetActive(true);
        ((Behaviour) this.m_BattleButtonImage).enabled = true;
        ((Behaviour) this.m_FightButtonText).enabled = false;
        this.m_BattleHeroBg[0].gameObject.SetActive(false);
        this.m_BattleHeroBg[1].gameObject.SetActive(false);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition && sender.Parm1 == (ushort) 4)
    {
      if (this.tmpSCD.ConditionArray[(int) sender.Parm2].ConditionID != (byte) 0)
        DataManager.StageDataController.GetStageConditionString(this.m_ConditionHint, this.tmpSCD.ConditionArray[(int) sender.Parm2].ConditionID, this.tmpSCD.ConditionArray[(int) sender.Parm2].FactorA, this.tmpSCD.ConditionArray[(int) sender.Parm2].FactorB, this.ConditionKey);
      else
        DataManager.StageDataController.GetStageConditionString(this.m_ConditionHint, byte.MaxValue, (ushort) 0, (ushort) 0, (ushort) 0);
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.m_ConditionHint, Vector2.zero);
    }
    else
    {
      this.m_HintText.text = DataManager.Instance.mStringTable.GetStringByID(19U);
      Vector2 vector2;
      vector2.x = ((Graphic) this.m_HintText).rectTransform.sizeDelta.x + 20f;
      vector2.y = this.m_HintText.preferredHeight + 20f;
      ((Graphic) this.m_HintImage).rectTransform.sizeDelta = vector2;
      vector2.x = ((Graphic) this.m_HintText).rectTransform.sizeDelta.x;
      vector2.y = this.m_HintText.preferredHeight;
      ((Graphic) this.m_HintText).rectTransform.sizeDelta = vector2;
      if (sender.Parm1 == (ushort) 1)
        this.m_Hint.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 160f);
      if (sender.Parm1 == (ushort) 2)
        this.m_Hint.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 160f);
      if (sender.Parm1 == (ushort) 3)
        this.m_Hint.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, -80f);
      this.m_Hint.gameObject.SetActive(true);
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if (this.SelectMode == UIBattleHeroSelect._SelectMode.Condition && sender.Parm1 == (ushort) 4)
      GUIManager.Instance.m_Hint.Hide(true);
    else
      this.m_Hint.gameObject.SetActive(false);
  }

  public void SaveTempHeroData()
  {
    DataManager instance = DataManager.Instance;
    if (this.m_BattleHeroID == null)
      return;
    for (int index = 0; index < instance.curTempHeroData.Length && index < this.m_BattleHeroID.Length; ++index)
    {
      if (instance.curHeroData.ContainsKey((uint) this.m_BattleHeroID[index]))
        instance.curTempHeroData[index] = instance.curHeroData[(uint) this.m_BattleHeroID[index]];
    }
  }

  public bool CheckHeroRes()
  {
    bool flag = true;
    ushort[] battleHeroID = new ushort[10];
    DataManager instance1 = DataManager.Instance;
    ArenaManager instance2 = ArenaManager.Instance;
    if (this.SelectMode == UIBattleHeroSelect._SelectMode.Hero || this.SelectMode == UIBattleHeroSelect._SelectMode.Condition)
      flag = instance1.CheckHeroBattleResourceReady(HeroFightType.HeroBattle, this.m_BattleHeroID);
    else if (this.SelectMode == UIBattleHeroSelect._SelectMode.ArenaAttack)
    {
      for (int index = 0; index < this.m_BattleHeroID.Length; ++index)
        battleHeroID[index] = this.m_BattleHeroID[index];
      for (int index = 0; index < instance2.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData.Length; ++index)
        battleHeroID[index + 5] = instance2.m_ArenaTarget[this.m_ArenaTargetIdx].HeroData[index].ID;
      flag = instance1.CheckHeroBattleResourceReady(HeroFightType.HeorArena, battleHeroID);
    }
    else if (this.SelectMode == UIBattleHeroSelect._SelectMode.Monster)
      flag = instance1.CheckHeroBattleResourceReady(HeroFightType.MonsterBattle, this.m_BattleHeroID);
    return flag;
  }

  public void CheckCondition()
  {
    this.tmpSCD = DataManager.StageDataController.StageDareMode(DataManager.StageDataController.currentPointID) != StageMode.Lean ? DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(this.LevelexDate.NodusTwoID) : DataManager.StageDataController.StageConditionDataTable.GetRecordByKey((ushort) ((int) this.LevelexDate.NodusOneID + (int) DataManager.StageDataController.currentNodus - 1));
    this.ConditionKey = this.tmpSCD.ConditionKey;
    int index1 = 0;
    int index2 = 0;
    for (int index3 = 0; index3 < this.tmpSCD.ConditionArray.Length; ++index3)
    {
      if (this.tmpSCD.ConditionArray[index3].ConditionID == (byte) 1 || this.tmpSCD.ConditionArray[index3].ConditionID == (byte) 2 || this.tmpSCD.ConditionArray[index3].ConditionID == (byte) 3)
      {
        if (this.tmpSCD.ConditionArray[index3].ConditionID == (byte) 1)
        {
          this.bConditionTopic = true;
          this.tmpTopicIdx[index1] = (ushort) index3;
          ++index1;
        }
        else if (this.tmpSCD.ConditionArray[index3].ConditionID == (byte) 2 && !this.bConditionCount)
        {
          this.bConditionCount = true;
          this.mCondition_CountIdx = index3;
          this.tmp_C_Count = this.tmpSCD.ConditionArray[index3].FactorA;
        }
        else if (this.tmpSCD.ConditionArray[index3].ConditionID == (byte) 3)
        {
          this.bConditionHeroID = true;
          this.tmpHeroIdx[index2] = (ushort) index3;
          ++index2;
        }
      }
    }
  }

  public bool CheckCondition_HeroTopic(ushort HeroID, bool bshowmsg = false)
  {
    if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition || !this.bConditionTopic)
      return false;
    if (this.bConditionHeroID)
    {
      for (int index = 0; index < this.tmpHeroIdx.Length; ++index)
      {
        if (this.tmpHeroIdx[index] != (ushort) 0 && (int) this.tmpHeroIdx[index] < this.tmpSCD.ConditionArray.Length && this.tmpSCD.ConditionArray[(int) this.tmpHeroIdx[index]].ConditionID == (byte) 3 && (int) this.tmpSCD.ConditionArray[(int) this.tmpHeroIdx[index]].FactorA == (int) HeroID)
          return false;
      }
    }
    ArenaHeroTopic recordByKey = DataManager.Instance.ArenaHeroTopicData.GetRecordByKey(HeroID);
    for (int index = 0; index < this.tmpTopicIdx.Length; ++index)
    {
      if (this.tmpSCD.ConditionArray[(int) this.tmpTopicIdx[index]].ConditionID == (byte) 1 && (this.tmpSCD.ConditionArray[(int) this.tmpTopicIdx[index]].FactorA == (ushort) 0 && ((int) (recordByKey.Value >> (int) this.tmpSCD.ConditionArray[(int) this.tmpTopicIdx[index]].FactorB - 1) & 1) == 1 || this.tmpSCD.ConditionArray[(int) this.tmpTopicIdx[index]].FactorA == (ushort) 1 && ((int) (recordByKey.Value >> (int) this.tmpSCD.ConditionArray[(int) this.tmpTopicIdx[index]].FactorB - 1) & 1) == 0))
      {
        if (bshowmsg)
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(10047U), (ushort) byte.MaxValue);
        return true;
      }
    }
    return false;
  }

  public bool CheckCondition_HeroNum(ushort HeroNum)
  {
    return this.SelectMode == UIBattleHeroSelect._SelectMode.Condition && this.bConditionCount && (int) HeroNum > (int) this.tmpSCD.ConditionArray[this.mCondition_CountIdx].FactorA;
  }

  public bool CheckCondition_HeroID()
  {
    if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition || !this.bConditionHeroID)
      return false;
    for (int index1 = 0; index1 < this.tmpHeroIdx.Length; ++index1)
    {
      if (this.tmpHeroIdx[index1] != (ushort) 0 && (int) this.tmpHeroIdx[index1] < this.tmpSCD.ConditionArray.Length && this.tmpSCD.ConditionArray[(int) this.tmpHeroIdx[index1]].ConditionID == (byte) 3)
      {
        bool flag = false;
        for (int index2 = 0; index2 < 5; ++index2)
        {
          if (this.m_BattleHeroID[index2] != (ushort) 0 && (int) this.tmpSCD.ConditionArray[(int) this.tmpHeroIdx[index1]].FactorA == (int) this.m_BattleHeroID[index2])
          {
            flag = true;
            break;
          }
        }
        if (!flag)
        {
          GUIManager.Instance.MsgStr.ClearString();
          DataManager.StageDataController.GetStageConditionString(GUIManager.Instance.MsgStr, this.tmpSCD.ConditionArray[(int) this.tmpHeroIdx[index1]].ConditionID, this.tmpSCD.ConditionArray[(int) this.tmpHeroIdx[index1]].FactorA, this.ConditionKey, (ushort) 0);
          GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), (ushort) byte.MaxValue);
          return true;
        }
      }
    }
    return false;
  }

  public bool CheckPreviewHeroModel(uint key, int mIdx)
  {
    if (this.SelectMode != UIBattleHeroSelect._SelectMode.Condition || !this.bPreviewHeroModel || !this.bPreviewHeroModel || this.CheckCanSelectById((ushort) key) == e_SelecBtnState.Condition)
      return false;
    Array.Clear((Array) DataManager.Instance.heroBattleData, 0, DataManager.Instance.heroBattleData.Length);
    for (int index = 0; index < this.m_BattleHeroID.Length; ++index)
      DataManager.Instance.heroBattleData[index].HeroID = this.m_BattleHeroID[index];
    GUIManager.Instance.bBackInPreviewModel = true;
    GUIManager.Instance.BackInPreviewHight = this.itemCont.anchoredPosition.y;
    GUIManager.Instance.OpenPreviewHeroInfo(DataManager.Instance.curHeroData[key].ID, false, this.LevelexDate.LV, this.LevelexDate.Rank, this.LevelexDate.Star, (byte) ((1 << (int) this.LevelexDate.Equip) - 1), mIdx);
    return true;
  }

  private enum _SelectMode
  {
    Hero,
    Monster,
    ArenaDefense,
    ArenaAttack,
    Condition,
  }
}
