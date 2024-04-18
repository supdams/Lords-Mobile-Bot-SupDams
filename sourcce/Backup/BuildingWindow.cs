// Decompiled with JetBrains decompiler
// Type: BuildingWindow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class BuildingWindow : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUTimeBarOnTimer
{
  private const int m_MaxUpgradeItemCount = 10;
  private const float m_DuringTime = 2f;
  private const float m_AnimBtnTime = 1f;
  private const int MaxTempTextNum = 5;
  private byte buildID;
  private byte style = 1;
  private byte buildLv;
  private ushort manorID;
  private byte buildLvMAx = 25;
  public e_BuildType buildType;
  private string abName = "UI/BuildingWindow";
  private int abKey;
  private Material uiMat;
  public Image mainTransform_Bg;
  public Image mainTransform_Bg2;
  public Transform mainTransform;
  public Transform mainTransform_V;
  public Transform mainTransform_H;
  private Transform buildingTransform;
  private Transform buildingTransformBG;
  private Transform buildingInfoTransform;
  private Transform uiButtonTransform;
  private Transform normalPanel;
  private Transform upgradePanel;
  private Transform upgradePanelItem;
  private Transform updateTimePanel;
  private Transform timeTextTf1;
  private Transform timeTitleTf1;
  private Transform timeTextTf2;
  private Transform timeTitleTf2;
  private Transform infoPanel;
  private Transform buildingLvBG;
  public UIButton exitBtn;
  private UIButton backOutBtn;
  public UIButton upgradeBtn;
  public RectTransform upgradeBtnRect;
  private UIButton buildInfo;
  private UIButton statistics;
  private UIText backOutBtnText;
  private UIText backOutBtnMoneyText;
  private UIText upgradeBtnText;
  private Image backOutBtnBgImage;
  private Image upgradeBtnBGImage;
  private Image backOutBtnImage;
  private Image upgradeBtnImage;
  private Transform exclamationTf;
  private RectTransform backOutBtnImageRt;
  private RectTransform upgradeBtnImageRt;
  private RectTransform backOutBtnTextRt;
  private UIText titleText;
  private Image sliderBGImage;
  private Image sliderImage;
  private Transform maxLvImage;
  private Transform upgradeBtnTf;
  private Transform maxLvImageRotate;
  private UIText updateTimeText1;
  private UIText updateTimeText2;
  private UIText lvText;
  private UISpritesArray spArray;
  private UISpritesArray btnSpArray;
  private UISpritesArray btnBGSpArray;
  private Material m_Mat;
  private e_FuncBtnType backOutBtnType;
  private e_FuncBtnType upgradeBtnType = e_FuncBtnType.Speed;
  private UIText[] normalPanelTitles = new UIText[4];
  private UIText[] normalPanelInfos = new UIText[4];
  private Image[] normalPanelInfosImage = new Image[4];
  private Transform normalPanelInfoTf3;
  private Transform upgradePanelTitle;
  private Transform infoPanelTitle;
  private UITimeBar timeBar;
  private ScrollPanel infoScrollPanel;
  private ScrollPanel upgradeScrollPanel;
  private Transform normallInfoPanel;
  private StringBuilder sb = new StringBuilder();
  private List<BuildInfoObject> upgradePanelData;
  private int totalUpgradeCount;
  private int upgradeDataIdx;
  private List<BuildInfoObject2> upgradeEffectData;
  private int totalUpgradeEffectCount;
  private int upgradeEffectIdx;
  public IBuildingWindowType m_Handler;
  public Transform baseTransform;
  private UIText upgradeScrollPanelTitle;
  private UpgradeItemObject[] m_UpgradeItem;
  private int m_MaxUpgradeInfoItemCount = 6;
  private UIText[] m_UpgradeInfoItemTexts;
  private Image[] m_UpgradeInfoItemImages;
  private UIText upgradeInfoScrollPanelTitle;
  private string[] iconSpriteName;
  private string[] iconBulidSpriteName;
  private string petResIcon = "UI_main_Force";
  private Transform customCastleTf;
  private CString tempString;
  private CString tempString3;
  private CString effectString;
  private CString tempString2;
  private float m_TimeTick = 1f;
  private long m_BuildStartTime;
  private long m_BuildEndTime;
  private int m_TimeObjectIdx;
  private bool m_bNeedShow;
  private long m_updateTime;
  private uint m_BackOutTime;
  private uint m_BackOutCostCrystal;
  private float m_ResTimeTick = 1f;
  private int[] m_ResUpdateTextsIdx = new int[5]
  {
    -1,
    -1,
    -1,
    -1,
    -1
  };
  private bool m_bSpecialConform;
  private bool m_bGeneralConform;
  private bool m_bGeneralConform_update = true;
  private bool bIsTechWindow;
  private byte techID;
  private byte techLv;
  private byte techLvMax = 25;
  private uint[] m_CostCrystal = new uint[9];
  private string m_TimeBarStr1;
  private string m_TimeBarStr2;
  private bool bOpenBackOutCheckBox;
  private ushort GuideParm2;
  private float m_TickBeginAnimBtnTime = 2f;
  private float m_TickEndAnimBtnTime = 1f;
  private Door door;
  private GUIManager GM;
  private UIText[] m_TempText = new UIText[5];
  private int m_TempTextIdx;
  private UIText m_SetNormalInfoPanelText;
  private byte bUpdateFreeState;

  private void Awake()
  {
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.GM = GUIManager.Instance;
    AssetBundle assetBundle = AssetManager.GetAssetBundle(this.abName, out this.abKey);
    if ((Object) assetBundle == (Object) null)
      return;
    GameObject gameObject = (GameObject) Object.Instantiate(assetBundle.mainAsset);
    if ((Object) gameObject == (Object) null)
    {
      AssetManager.UnloadAssetBundle(this.abKey);
    }
    else
    {
      gameObject.transform.SetParent(this.transform, false);
      this.baseTransform = gameObject.transform;
      this.spArray = gameObject.transform.GetComponent<UISpritesArray>();
      this.titleText = gameObject.transform.GetChild(4).GetChild(0).GetComponent<UIText>();
      this.mainTransform = gameObject.transform.GetChild(5);
      this.mainTransform_Bg = gameObject.transform.GetChild(2).GetComponent<Image>();
      this.mainTransform_Bg2 = gameObject.transform.GetChild(3).GetComponent<Image>();
      this.mainTransform_V = gameObject.transform.GetChild(5).GetChild(0);
      this.mainTransform_H = gameObject.transform.GetChild(5).GetChild(1);
      this.buildingTransformBG = gameObject.transform.GetChild(7);
      this.buildingTransform = gameObject.transform.GetChild(7).GetChild(0);
      if (this.GM.IsArabic)
        this.buildingTransform.gameObject.AddComponent<ArabicItemTextureRot>();
      this.buildingInfoTransform = gameObject.transform.GetChild(10);
      this.uiButtonTransform = gameObject.transform.GetChild(9);
      if (GUIManager.Instance.IsArabic)
        this.uiButtonTransform.GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
      this.normalPanel = gameObject.transform.GetChild(15);
      this.buildingLvBG = gameObject.transform.GetChild(8);
      this.sliderImage = gameObject.transform.GetChild(8).GetChild(0).GetComponent<Image>();
      this.sliderBGImage = gameObject.transform.GetChild(8).GetComponent<Image>();
      this.lvText = gameObject.transform.GetChild(8).GetChild(1).GetComponent<UIText>();
      this.normalPanelInfoTf3 = this.normalPanel.GetChild(7);
      for (int index = 0; index < 4; ++index)
      {
        this.normalPanelTitles[index] = this.normalPanel.GetChild(index * 2).GetComponent<UIText>();
        this.normalPanelInfosImage[index] = this.normalPanel.GetChild(index * 2 + 1).GetChild(0).GetComponent<Image>();
        this.normalPanelInfos[index] = this.normalPanel.GetChild(index * 2 + 1).GetChild(1).GetComponent<UIText>();
      }
      this.normallInfoPanel = gameObject.transform.GetChild(18);
      this.upgradePanel = gameObject.transform.GetChild(17);
      this.infoPanel = gameObject.transform.GetChild(19);
      if (GUIManager.Instance.bOpenOnIPhoneX)
      {
        Image component = gameObject.transform.GetChild(14).GetComponent<Image>();
        if ((bool) (Object) component)
          ((Behaviour) component).enabled = false;
      }
      this.exitBtn = gameObject.transform.GetChild(14).GetChild(0).GetComponent<UIButton>();
      this.exitBtn.m_BtnID1 = 3;
      this.exitBtn.m_Handler = (IUIButtonClickHandler) this;
      this.exitBtn.image.sprite = this.door.LoadSprite("UI_main_close");
      ((MaskableGraphic) this.exitBtn.image).material = this.door.LoadMaterial();
      Image component1 = gameObject.transform.GetChild(14).GetComponent<Image>();
      component1.sprite = this.door.LoadSprite("UI_main_close_base");
      ((MaskableGraphic) component1).material = this.door.LoadMaterial();
      Transform child1 = gameObject.transform.GetChild(11);
      this.btnSpArray = child1.GetComponent<UISpritesArray>();
      this.backOutBtnBgImage = child1.GetComponent<Image>();
      this.backOutBtnImage = child1.GetChild(0).GetComponent<Image>();
      this.backOutBtnImageRt = child1.GetChild(0).GetComponent<RectTransform>();
      this.backOutBtnTextRt = child1.GetChild(1).GetComponent<RectTransform>();
      this.backOutBtnText = child1.GetChild(1).GetComponent<UIText>();
      this.backOutBtnText.font = GUIManager.Instance.GetTTFFont();
      this.backOutBtnMoneyText = child1.GetChild(2).GetComponent<UIText>();
      this.backOutBtnMoneyText.font = GUIManager.Instance.GetTTFFont();
      this.backOutBtn = child1.GetComponent<UIButton>();
      this.backOutBtn.m_BtnID1 = 1;
      this.backOutBtn.m_Handler = (IUIButtonClickHandler) this;
      Transform child2 = gameObject.transform.GetChild(12);
      this.upgradeBtnRect = child2.GetComponent<RectTransform>();
      this.btnBGSpArray = child2.GetComponent<UISpritesArray>();
      this.upgradeBtnBGImage = child2.GetComponent<Image>();
      this.upgradeBtnImageRt = child2.GetChild(0).GetComponent<RectTransform>();
      this.upgradeBtnText = child2.GetChild(1).GetComponent<UIText>();
      this.upgradeBtnImage = child2.GetChild(0).GetComponent<Image>();
      this.upgradeBtnText.font = GUIManager.Instance.GetTTFFont();
      this.upgradeBtn = gameObject.transform.GetChild(12).GetComponent<UIButton>();
      this.upgradeBtn.m_BtnID1 = 2;
      this.upgradeBtn.m_Handler = (IUIButtonClickHandler) this;
      this.upgradeBtnTf = child2;
      this.buildInfo = gameObject.transform.GetChild(9).GetChild(0).GetComponent<UIButton>();
      this.buildInfo.m_BtnID1 = 0;
      this.buildInfo.m_Handler = (IUIButtonClickHandler) this;
      this.statistics = gameObject.transform.GetChild(9).GetChild(1).GetComponent<UIButton>();
      this.statistics.m_BtnID1 = 4;
      this.statistics.m_Handler = (IUIButtonClickHandler) this;
      this.upgradePanelTitle = gameObject.transform.GetChild(16);
      this.upgradeScrollPanelTitle = gameObject.transform.GetChild(16).GetChild(1).GetComponent<UIText>();
      this.infoPanelTitle = gameObject.transform.GetChild(20);
      this.upgradeInfoScrollPanelTitle = gameObject.transform.GetChild(20).GetChild(1).GetComponent<UIText>();
      this.upgradePanelItem = gameObject.transform.GetChild(22);
      this.updateTimePanel = gameObject.transform.GetChild(21);
      this.timeTextTf1 = this.updateTimePanel.GetChild(0);
      this.timeTitleTf1 = this.updateTimePanel.GetChild(2);
      this.timeTextTf2 = this.updateTimePanel.GetChild(1);
      this.timeTitleTf2 = this.updateTimePanel.GetChild(3);
      this.updateTimeText1 = this.timeTextTf1.GetComponent<UIText>();
      this.updateTimeText2 = this.timeTextTf2.GetComponent<UIText>();
      this.updateTimeText1.font = GUIManager.Instance.GetTTFFont();
      this.updateTimeText2.font = GUIManager.Instance.GetTTFFont();
      UIText component2 = this.updateTimePanel.GetChild(2).GetComponent<UIText>();
      component2.font = GUIManager.Instance.GetTTFFont();
      this.m_TempText[this.m_TempTextIdx++] = component2;
      component2.text = DataManager.Instance.mStringTable.GetStringByID(3945U);
      this.m_TempText[this.m_TempTextIdx++] = component2;
      UIText component3 = this.updateTimePanel.GetChild(3).GetComponent<UIText>();
      component3.font = GUIManager.Instance.GetTTFFont();
      this.m_TempText[this.m_TempTextIdx++] = component3;
      component3.text = DataManager.Instance.mStringTable.GetStringByID(3946U);
      this.m_TempText[this.m_TempTextIdx++] = component3;
      this.m_Mat = ((MaskableGraphic) gameObject.transform.GetChild(23).GetChild(1).GetComponent<Image>()).material;
      this.timeBar = gameObject.transform.GetChild(24).GetComponent<UITimeBar>();
      GUIManager.Instance.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.NormalType, string.Empty, string.Empty);
      GUIManager.Instance.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Free);
      this.timeBar.m_Handler = (IUTimeBarOnTimer) this;
      this.timeBar.m_TimeBarID = 1;
      this.timeBar.gameObject.SetActive(false);
      this.customCastleTf = gameObject.transform.GetChild(25);
      UIButton component4 = this.customCastleTf.GetComponent<UIButton>();
      component4.m_BtnID1 = 5;
      component4.m_Handler = (IUIButtonClickHandler) this;
      this.customCastleTf.GetComponent<Image>().sprite = this.btnBGSpArray.m_Sprites[1];
      Image component5 = this.customCastleTf.GetChild(0).GetComponent<Image>();
      component5.sprite = this.door.LoadSprite("UI_castle_icon_01");
      ((MaskableGraphic) component5).material = this.door.LoadMaterial();
      ((Graphic) component5).rectTransform.anchoredPosition = new Vector2(10f, -10f);
      component5.SetNativeSize();
      this.exclamationTf = this.customCastleTf.GetChild(1);
      Image component6 = this.exclamationTf.GetComponent<Image>();
      component6.sprite = this.door.LoadSprite("UI_main_redbox_01");
      ((MaskableGraphic) component6).material = this.door.LoadMaterial();
      Image component7 = this.exclamationTf.GetChild(0).GetComponent<Image>();
      component7.sprite = this.door.LoadSprite("UI_main_mess_ex_dark");
      ((MaskableGraphic) component7).material = this.door.LoadMaterial();
      Image component8 = this.exclamationTf.GetChild(0).GetChild(0).GetComponent<Image>();
      component8.sprite = this.door.LoadSprite("UI_main_mess_ex_light");
      ((MaskableGraphic) component8).material = this.door.LoadMaterial();
      this.upgradeScrollPanel = gameObject.transform.GetChild(17).GetComponent<ScrollPanel>();
      this.infoScrollPanel = gameObject.transform.GetChild(19).GetComponent<ScrollPanel>();
      this.maxLvImage = gameObject.transform.GetChild(13);
      this.maxLvImageRotate = this.maxLvImage.GetChild(0);
      UIText component9 = this.maxLvImage.GetChild(2).GetComponent<UIText>();
      component9.font = GUIManager.Instance.GetTTFFont();
      component9.text = DataManager.Instance.mStringTable.GetStringByID(3831U);
      this.m_TempText[this.m_TempTextIdx++] = component9;
      GUIManager.Instance.AddSpriteAsset(nameof (BuildingWindow));
      this.uiMat = GUIManager.Instance.LoadMaterial(nameof (BuildingWindow), "BuildingWindow_m");
      this.tempString = StringManager.Instance.SpawnString();
      this.tempString3 = StringManager.Instance.SpawnString();
      this.tempString2 = StringManager.Instance.SpawnString();
      this.effectString = StringManager.Instance.SpawnString();
    }
  }

  public void InitBuildingWindow(byte _buildID, ushort _manorID, byte _Style = 0, byte _buildLv = 1)
  {
    this.bIsTechWindow = false;
    this.buildID = _buildID;
    this.manorID = _manorID;
    this.style = _Style;
    this.buildLv = _buildLv;
    if (_buildID == (byte) 16)
      this.buildLvMAx = (byte) 9;
    this.m_UpgradeItem = new UpgradeItemObject[10];
    for (int index = 0; index < this.m_UpgradeItem.Length; ++index)
      this.m_UpgradeItem[index] = new UpgradeItemObject();
    this.titleText.font = GUIManager.Instance.GetTTFFont();
    this.titleText.text = DataManager.Instance.mStringTable.GetStringByID((uint) DataManager.Instance.BuildsTypeData.GetRecordByKey((ushort) this.buildID).NameID);
    this.iconSpriteName = new string[12]
    {
      "UI_main_res_house",
      "UI_main_res_food",
      "UI_main_res_stone",
      "UI_main_res_wood",
      "UI_main_res_iron",
      "UI_main_money_01",
      "UI_main_art_butt_up",
      "UI_main_art_butt_plus",
      "UI_main_res_noputup",
      "UI_main_xxx",
      "UI_main_art_butt_go",
      "UI_main_art_butt_go_icon"
    };
    this.iconBulidSpriteName = new string[6]
    {
      string.Empty,
      "UI_main_res_wood",
      "UI_main_res_stone",
      "UI_main_res_iron",
      "UI_main_res_food",
      "UI_main_money_01"
    };
    this.upgradeScrollPanelTitle.font = GUIManager.Instance.GetTTFFont();
    this.upgradeScrollPanelTitle.text = DataManager.Instance.mStringTable.GetStringByID(3818U);
    this.upgradeInfoScrollPanelTitle.font = GUIManager.Instance.GetTTFFont();
    this.upgradeInfoScrollPanelTitle.text = DataManager.Instance.mStringTable.GetStringByID(3817U);
    this.upgradePanelData = new List<BuildInfoObject>();
    this.upgradeEffectData = new List<BuildInfoObject2>();
    if ((int) this.manorID < GUIManager.Instance.BuildingData.AllBuildsData.Length)
      DataManager.Instance.BuildsTypeData.GetRecordByKey(GUIManager.Instance.BuildingData.AllBuildsData[(int) this.manorID].BuildID);
    DataManager.Instance.GetQueueBarTitle(EQueueBarIndex.Building, this.sb, ref this.m_TimeBarStr1, ref this.m_TimeBarStr2);
    if (_buildID == (byte) 6 || _buildID == (byte) 12)
      ((Component) this.statistics).gameObject.SetActive(true);
    else
      ((Component) this.statistics).gameObject.SetActive(false);
    if (GUIManager.Instance.GuideParm1 == (byte) 1 || GUIManager.Instance.GuideParm1 == (byte) 2)
    {
      if (GUIManager.Instance.GuideParm1 == (byte) 1 && (int) GUIManager.Instance.GuideParm2 == (int) _buildID || GUIManager.Instance.GuideParm1 == (byte) 2 && (int) GUIManager.Instance.GuideParm2 == (int) this.manorID)
      {
        this.GuideParm2 = GUIManager.Instance.GuideParm2;
        GUIManager.Instance.GuideArrow(((Component) this.upgradeBtn).gameObject.GetComponent<RectTransform>(), ArrowDirect.Ar_Up);
      }
      else
      {
        GUIManager.Instance.HideArrow(true);
        this.GuideParm2 = (ushort) 0;
      }
    }
    this.MyUpdate((byte) 0, true);
    DataManager.Instance.OpenBagFilterByBuildingWindow = (byte) 0;
    DataManager.Instance.OpenBuildingWindowUpdateNoClose = (byte) 0;
  }

  public void InitTechWindow(byte _techID, byte _techLv)
  {
    this.bIsTechWindow = true;
    this.techID = _techID;
    this.techLv = _techLv;
    this.m_UpgradeItem = new UpgradeItemObject[10];
    for (int index = 0; index < this.m_UpgradeItem.Length; ++index)
      this.m_UpgradeItem[index] = new UpgradeItemObject();
    TechDataTbl recordByKey = DataManager.Instance.TechData.GetRecordByKey((ushort) this.techID);
    this.titleText.font = GUIManager.Instance.GetTTFFont();
    this.titleText.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.TechName);
    this.iconSpriteName = new string[12]
    {
      "UI_main_res_house",
      "UI_main_res_food",
      "UI_main_res_stone",
      "UI_main_res_wood",
      "UI_main_res_iron",
      "UI_main_money_01",
      "UI_main_art_butt_up",
      "UI_main_art_butt_plus",
      "UI_main_res_noputup",
      "UI_main_xxx",
      "UI_main_art_butt_go",
      "UI_main_art_butt_go_icon"
    };
    this.iconBulidSpriteName = new string[6]
    {
      string.Empty,
      "UI_main_res_wood",
      "UI_main_res_stone",
      "UI_main_res_iron",
      "UI_main_res_food",
      "UI_main_money_01"
    };
    this.upgradeScrollPanelTitle.font = GUIManager.Instance.GetTTFFont();
    this.upgradeScrollPanelTitle.text = DataManager.Instance.mStringTable.GetStringByID(3818U);
    this.upgradeInfoScrollPanelTitle.font = GUIManager.Instance.GetTTFFont();
    this.upgradeInfoScrollPanelTitle.text = DataManager.Instance.mStringTable.GetStringByID(3817U);
    this.upgradePanelData = new List<BuildInfoObject>();
    this.upgradeEffectData = new List<BuildInfoObject2>();
    this.MyUpdate((byte) 0, true);
    DataManager.Instance.OpenBagFilterByBuildingWindow = (byte) 0;
  }

  private void Update()
  {
    if (this.maxLvImage.gameObject.activeSelf)
      this.maxLvImageRotate.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    if (this.m_bNeedShow)
    {
      this.m_updateTime = this.m_BuildEndTime - DataManager.Instance.ServerTime;
      this.m_TimeTick += Time.deltaTime;
      if ((double) this.m_TimeTick >= 1.0)
      {
        this.m_TimeTick = 0.0f;
        --this.m_updateTime;
        if (this.m_updateTime > 0L)
        {
          for (int Idx = 0; Idx < this.m_UpgradeItem.Length; ++Idx)
          {
            if (this.m_UpgradeItem[Idx].upgradeScrollPanelIconType == (byte) 6 && ((Component) this.m_UpgradeItem[Idx].m_UpgradeItemTimeTexts).gameObject.activeSelf)
            {
              eTimerSpriteType type = this.bIsTechWindow ? DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Researching) : DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Building);
              if (type == eTimerSpriteType.Speed && this.m_updateTime <= (long) DataManager.Instance.GetFreeCompleteTime() && this.bUpdateFreeState++ == (byte) 0)
              {
                if (this.bIsTechWindow)
                  type = eTimerSpriteType.Free;
                else if (GUIManager.Instance.BuildingData.QueueBuildType == (byte) 1)
                  type = eTimerSpriteType.Free;
              }
              if (this.m_UpgradeItem[Idx].timerSpriteType != type)
                this.SetTimeBarBtnSprite(type, Idx);
              this.SetTime((int) this.m_updateTime / 86400, (int) (this.m_updateTime / 3600L) % 24, (int) (this.m_updateTime / 60L) % 60, (int) this.m_updateTime % 60, this.tempString2, this.m_UpgradeItem[Idx].m_UpgradeItemTimeTexts);
              break;
            }
          }
        }
        else
        {
          --this.totalUpgradeCount;
          List<float> _DataHeight = new List<float>();
          for (int index = 0; index < this.totalUpgradeCount; ++index)
            _DataHeight.Add(59f);
          this.upgradeScrollPanel.AddNewDataHeight(_DataHeight, false);
          this.m_bNeedShow = false;
        }
      }
    }
    this.m_ResTimeTick += Time.deltaTime;
    if ((double) this.m_ResTimeTick >= 1.0)
    {
      bool flag1 = true;
      this.m_bGeneralConform_update = true;
      for (int index = 0; index < this.m_UpgradeItem.Length && index < this.upgradePanelData.Count; ++index)
      {
        int scrollPanelIconType = (int) this.m_UpgradeItem[index].upgradeScrollPanelIconType;
        int scrollPanelIconIdx = this.m_UpgradeItem[index].upgradeScrollPanelIconIdx;
        if (scrollPanelIconType == 8)
        {
          if (this.bIsTechWindow)
          {
            byte lv = (byte) Mathf.Clamp((int) this.techLv + 1, 1, (int) this.techLvMax);
            bool petResourceStr = this.GetPetResourceStr(out this.upgradePanelData[scrollPanelIconIdx].text, this.techID, lv, out this.upgradePanelData[scrollPanelIconIdx].value);
            this.m_UpgradeItem[index].m_UpgradeItemTexts.text = this.upgradePanelData[scrollPanelIconIdx].text;
            if (!petResourceStr)
              flag1 = false;
          }
        }
        else if (scrollPanelIconType > 0 && scrollPanelIconType <= 5)
        {
          bool flag2;
          if (this.bIsTechWindow)
          {
            byte lv = (byte) Mathf.Clamp((int) this.techLv + 1, 1, (int) this.techLvMax);
            flag2 = this.GetResStr_Tech((ResourceType) ((uint) (byte) scrollPanelIconType - 1U), out this.upgradePanelData[scrollPanelIconIdx].text, this.techID, lv, out this.upgradePanelData[scrollPanelIconIdx].value);
            this.m_UpgradeItem[index].m_UpgradeItemTexts.text = this.upgradePanelData[scrollPanelIconIdx].text;
            if (!flag2)
              flag1 = false;
          }
          else
          {
            byte lv = (byte) Mathf.Clamp((int) this.buildLv + 1, 1, (int) this.buildLvMAx);
            flag2 = this.GetResStr((ResourceType) ((uint) (byte) scrollPanelIconType - 1U), out this.upgradePanelData[scrollPanelIconIdx].text, this.buildID, lv, out this.upgradePanelData[scrollPanelIconIdx].value);
            this.m_UpgradeItem[index].m_UpgradeItemTexts.text = this.upgradePanelData[scrollPanelIconIdx].text;
            if (!flag2)
              flag1 = false;
          }
          if ((bool) (Object) this.m_UpgradeItem[index].m_UpgradeItemImageXs && (bool) (Object) this.m_UpgradeItem[index].m_UpgradeItemBtnImages)
          {
            ((Behaviour) this.m_UpgradeItem[index].m_UpgradeItemImageXs).enabled = !flag2;
            ((Behaviour) this.m_UpgradeItem[index].m_UpgradeItemBtnImages).enabled = !flag2;
          }
          if (!flag1)
            this.m_bGeneralConform_update = false;
        }
        else if (scrollPanelIconType == 6 && this.m_UpgradeItem[index].upgradeScrollPanelbConform)
        {
          ((Behaviour) this.m_UpgradeItem[index].m_UpgradeItemImageXs).enabled = true;
          ((Behaviour) this.m_UpgradeItem[index].m_UpgradeItemBtnImages).enabled = true;
          this.upgradePanelData[scrollPanelIconIdx].btnType = (byte) 0;
        }
      }
      if (this.backOutBtnType == e_FuncBtnType.AtOnce_Upgrade || this.backOutBtnType == e_FuncBtnType.AtOnce_Build || this.backOutBtnType == e_FuncBtnType.AtOnce_Research)
      {
        uint costCrystal = this.GetCostCrystal();
        this.sb.Length = 0;
        this.sb.AppendFormat("{0:N0}", (object) costCrystal);
        this.backOutBtnMoneyText.text = this.sb.ToString();
      }
      this.CheckBtnState(this.upgradeBtnType);
      this.m_ResTimeTick = 0.0f;
    }
    if ((double) this.m_TickBeginAnimBtnTime <= 2.0)
      this.m_TickBeginAnimBtnTime += Time.deltaTime;
    if ((double) this.m_TickBeginAnimBtnTime >= 2.0 && (double) this.m_TickEndAnimBtnTime <= 1.0)
      this.m_TickEndAnimBtnTime += Time.deltaTime;
    for (int index = 0; index < this.m_UpgradeItem.Length && index < this.upgradePanelData.Count; ++index)
    {
      int scrollPanelIconIdx = this.m_UpgradeItem[index].upgradeScrollPanelIconIdx;
      if (this.m_UpgradeItem[index] != null && (Object) this.m_UpgradeItem[index].m_TweenRotation != (Object) null)
      {
        if (this.upgradePanelData[scrollPanelIconIdx].btnType == (byte) 4 && (double) this.m_TickBeginAnimBtnTime >= 2.0)
        {
          if (!this.m_UpgradeItem[index].m_TweenRotation.enabled)
          {
            this.m_UpgradeItem[index].m_TweenRotation.enabled = true;
            this.m_UpgradeItem[index].m_TweenRotation.factor = 0.0f;
          }
          float num = 0.1f;
          if ((double) this.m_TickEndAnimBtnTime >= 1.0 && (double) Mathf.Abs(((Transform) this.m_UpgradeItem[index].m_UpgradeItemBtnRect).localRotation.z) <= (double) num)
          {
            this.m_TickEndAnimBtnTime = 0.0f;
            this.m_TickBeginAnimBtnTime = 0.0f;
          }
        }
        else
        {
          ((Transform) this.m_UpgradeItem[index].m_UpgradeItemBtnRect).localRotation = new Quaternion();
          this.m_UpgradeItem[index].m_TweenRotation.enabled = false;
        }
      }
    }
  }

  public void SetUIPos(int style)
  {
    if (style == 2)
    {
      if (this.buildID == (byte) 8 || this.buildID == (byte) 21)
      {
        ((Component) this.mainTransform_H.GetComponent<Image>()).gameObject.SetActive(true);
        ((Behaviour) this.mainTransform_H.GetComponent<Image>()).enabled = false;
        ((Component) this.mainTransform_Bg).gameObject.SetActive(true);
        ((Component) this.mainTransform_Bg2).gameObject.SetActive(true);
        this.mainTransform_V.gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.mainTransform_Bg).gameObject.SetActive(false);
        ((Component) this.mainTransform_Bg2).gameObject.SetActive(false);
        this.mainTransform_V.gameObject.SetActive(false);
        this.mainTransform_H.gameObject.SetActive(true);
      }
      this.buildingTransformBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(-241.5f, -236.5f);
      this.uiButtonTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(-101f, -270f);
      this.buildingLvBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(-241.5f, -290f);
      this.updateTimePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(55f, -192f);
    }
    else
    {
      ((Component) this.mainTransform_Bg).gameObject.SetActive(false);
      ((Component) this.mainTransform_Bg2).gameObject.SetActive(false);
      this.mainTransform_V.gameObject.SetActive(true);
      this.mainTransform_H.gameObject.SetActive(false);
      this.buildingTransformBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(223.5f, 121.5f);
      this.uiButtonTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(363f, 86f);
      this.buildingLvBG.GetComponent<RectTransform>().anchoredPosition = new Vector2(212f, 78f);
      this.updateTimePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(254f, -163f);
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    int num1 = 101;
    int num2 = arg1;
    switch (num2)
    {
      case 0:
      case 1:
        if (bOK)
        {
          if (GUIManager.Instance.BuildingData.QueueBuildType == (byte) 1)
            GUIManager.Instance.BuildingData.sendBuildingCancel();
          else
            GUIManager.Instance.BuildingData.sendBuildDismantleCancel();
        }
        this.bOpenBackOutCheckBox = false;
        break;
      case 5:
        int num3 = !bOK ? 2 : 1;
        uint strength = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort) this.buildID, this.buildLv).Strength;
        this.sb.Length = 0;
        this.bOpenBackOutCheckBox = true;
        BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey((ushort) this.buildID);
        if (recordByKey.Kind != (byte) 1 && recordByKey.Kind != (byte) 2 && recordByKey.Kind != (byte) 6)
          break;
        this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3963U), (object) strength);
        GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(3962U), this.sb.ToString(), num1, num3, DataManager.Instance.mStringTable.GetStringByID(4021U), DataManager.Instance.mStringTable.GetStringByID(4022U));
        break;
      case 101:
        this.bOpenBackOutCheckBox = false;
        if (!bOK)
          break;
        switch (arg2)
        {
          case 1:
            if (DataManager.Instance.GetCurItemQuantity((ushort) 1076, (byte) 0) > (ushort) 0)
            {
              GUIManager.Instance.BuildingData.sendBuildDismantleImmediate(this.manorID);
              return;
            }
            if (DataManager.Instance.RoleAttr.Diamond >= this.m_BackOutCostCrystal)
            {
              GUIManager.Instance.BuildingData.sendBuildDismantleImmediate(this.manorID);
              return;
            }
            this.sb.Length = 0;
            if (this.backOutBtnType == e_FuncBtnType.BackOut)
              this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3857U), (object) DataManager.Instance.mStringTable.GetStringByID(3828U));
            GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3966U), this.sb.ToString(), DataManager.Instance.mStringTable.GetStringByID(3968U), (GUIWindow) this, 103, bCloseIDSet: true);
            return;
          case 2:
            if (DataManager.Instance.queueBarData[0].bActive)
            {
              GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(3969U), DataManager.Instance.mStringTable.GetStringByID(3970U), 102, 1, DataManager.Instance.mStringTable.GetStringByID(4024U), DataManager.Instance.mStringTable.GetStringByID(4025U));
              return;
            }
            GUIManager.Instance.BuildingData.sendBuildDismantle(this.manorID);
            return;
          default:
            return;
        }
      case 102:
        if (!bOK)
          break;
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2);
        break;
      case 103:
        if (!bOK)
          break;
        MallManager.Instance.Send_Mall_Info();
        break;
      case 104:
        if (!this.bIsTechWindow)
          break;
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 1);
        break;
      case 105:
        if (!bOK)
          break;
        if ((int) GUIManager.Instance.BuildingData.BuildingManorID == (int) this.manorID)
        {
          GUIManager.Instance.BuildingData.sendBuildFinish();
          break;
        }
        if (GUIManager.Instance.OpenCheckCrystal(this.GetCostCrystal(), (byte) 4, (int) this.manorID, (int) this.buildID))
          break;
        GUIManager.Instance.BuildingData.sendBuildCompleteImmediate(this.manorID, (ushort) this.buildID);
        break;
      case 106:
        if (!bOK)
          break;
        if (this.upgradeBtnType == e_FuncBtnType.Speed)
          GUIManager.Instance.BuildingData.sendStartBuilding(this.manorID, (ushort) this.buildID);
        else if (this.upgradeBtnType == e_FuncBtnType.Free)
          GUIManager.Instance.BuildingData.sendBuildCompleteFree();
        if (this.upgradeBtnType != e_FuncBtnType.Upgrade && this.upgradeBtnType != e_FuncBtnType.Build)
          break;
        GUIManager.Instance.BuildingData.sendStartBuilding(this.manorID, (ushort) this.buildID);
        break;
      case 107:
        if (!bOK)
          break;
        if ((int) GUIManager.Instance.BuildingData.BuildingManorID == (int) this.manorID)
        {
          GUIManager.Instance.BuildingData.sendBuildFinish();
          break;
        }
        if (GUIManager.Instance.OpenCheckCrystal(this.GetCostCrystal(), (byte) 4, (int) this.manorID, (int) this.buildID))
          break;
        GUIManager.Instance.BuildingData.sendBuildCompleteImmediate(this.manorID, (ushort) this.buildID);
        break;
      case 108:
        if (!bOK)
          break;
        if (this.upgradeBtnType == e_FuncBtnType.Speed)
          GUIManager.Instance.BuildingData.sendStartBuilding(this.manorID, (ushort) this.buildID);
        else if (this.upgradeBtnType == e_FuncBtnType.Free)
          GUIManager.Instance.BuildingData.sendBuildCompleteFree();
        if (this.upgradeBtnType != e_FuncBtnType.Upgrade && this.upgradeBtnType != e_FuncBtnType.Build)
          break;
        GUIManager.Instance.BuildingData.sendStartBuilding(this.manorID, (ushort) this.buildID);
        break;
      default:
        if (num2 != 14 || !bOK)
          break;
        DataManager.Instance.sendTechnologyResearchCancel();
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    this.GuideParm2 = (ushort) 0;
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    switch (sender.m_BtnID1)
    {
      case 0:
        if (this.buildID == (byte) 20)
        {
          GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(12110U), DataManager.Instance.mStringTable.GetStringByID(12117U), bInfo: true, BackExit: true);
          break;
        }
        if (this.buildID == (byte) 12 || this.buildID == (byte) 6)
          GUIManager.Instance.BuildingData.GuideSoldierID = (ushort) 0;
        if (this.buildType == e_BuildType.Upgrade || this.buildType == e_BuildType.Upgrade_Tech || this.buildType == e_BuildType.Upgradeing)
          DataManager.Instance.OpenBagFilterByBuildingWindow = (byte) 1;
        if (this.bIsTechWindow)
        {
          this.door.OpenMenu(EGUIWindow.UI_Information, -1, (int) this.techID);
          break;
        }
        this.door.OpenMenu(EGUIWindow.UI_Information, (int) this.buildID, (int) this.manorID);
        break;
      case 1:
        if (!this.bIsTechWindow)
        {
          if (sender.m_BtnID2 == 101)
          {
            GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(5707U), DataManager.Instance.mStringTable.GetStringByID(5702U));
            break;
          }
          if (sender.m_BtnID2 == 102)
          {
            GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(5707U), DataManager.Instance.mStringTable.GetStringByID(12104U));
            break;
          }
          if (sender.m_BtnID2 != 100)
          {
            if (this.backOutBtnType == e_FuncBtnType.Cancel)
            {
              GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(12049U), DataManager.Instance.mStringTable.GetStringByID(3961U), YesText: DataManager.Instance.mStringTable.GetStringByID(3964U), NoText: DataManager.Instance.mStringTable.GetStringByID(3965U));
              break;
            }
            if (this.backOutBtnType == e_FuncBtnType.Cancel_BackOut)
            {
              this.bOpenBackOutCheckBox = true;
              GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(12050U), DataManager.Instance.mStringTable.GetStringByID(3921U), 1, YesText: DataManager.Instance.mStringTable.GetStringByID(3964U), NoText: DataManager.Instance.mStringTable.GetStringByID(3965U));
              break;
            }
            if (this.backOutBtnType == e_FuncBtnType.BackOut)
            {
              uint num1 = 0;
              for (byte Level = 1; (int) Level <= (int) this.buildLv; ++Level)
              {
                BuildLevelRequest levelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort) this.buildID, Level);
                num1 += levelRequestData.BuildTime;
              }
              uint effectBaseVal1;
              uint effectBaseVal2;
              if (this.bIsTechWindow)
              {
                effectBaseVal1 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESEARCH_SPEED);
                effectBaseVal2 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESEARCH_SPEED_DEBUFF);
              }
              else
              {
                effectBaseVal1 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_CONSTRUCTION_SPEED);
                effectBaseVal2 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_CONSTRUCTION_SPEED_DEBUFF);
              }
              long num2;
              if (effectBaseVal1 >= effectBaseVal2)
              {
                uint num3 = effectBaseVal1 - effectBaseVal2;
                num2 = (long) num1 * 10000L / ((long) num3 + 10000L) + (long) Mathf.Clamp((int) ((long) num1 * 10000L % ((long) num3 + 10000L)), 0, 1);
              }
              else
              {
                uint num4 = effectBaseVal2 - effectBaseVal1;
                if (num4 > 9900U)
                  num4 = 9900U;
                num2 = (long) num1 * 10000L / (10000L - (long) num4) + (long) Mathf.Clamp((int) ((long) num1 * 10000L % (10000L - (long) num4)), 0, 1);
              }
              this.m_BackOutTime = (uint) ((ulong) (num2 / 2L) + (ulong) Mathf.Clamp((int) (num2 % 2L), 0, 1));
              if (this.m_BackOutTime < 300U)
                this.m_BackOutTime = 300U;
              int sec = (int) this.m_BackOutTime % 60;
              int min = (int) (this.m_BackOutTime / 60U) % 60;
              int hour = (int) (this.m_BackOutTime / 3600U) % 24;
              int day = (int) this.m_BackOutTime / 86400;
              this.m_BackOutCostCrystal = DataManager.Instance.StoreData.GetRecordByKey(DataManager.Instance.TotalShopItemData.Find((ushort) 1076)).Price;
              GUIManager.Instance.OpenSpendWindow_ItemID2((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(3922U), (ushort) 1076, (ushort) 1075, this.m_BackOutCostCrystal, (ushort) day, (byte) hour, (byte) min, (byte) sec, arg1: 5, HaveItemText: DataManager.Instance.mStringTable.GetStringByID(5788U), NoItemText: DataManager.Instance.mStringTable.GetStringByID(5786U), BottomText: DataManager.Instance.mStringTable.GetStringByID(5787U));
              break;
            }
            if (this.backOutBtnType != e_FuncBtnType.AtOnce_Upgrade && this.backOutBtnType != e_FuncBtnType.AtOnce_Build)
              break;
            uint costCrystal = this.GetCostCrystal();
            if (DataManager.Instance.RoleAttr.Diamond >= costCrystal)
            {
              if (this.buildID == (byte) 8 && this.buildLv == (byte) 8 && DataManager.Instance.HasNewbieShield())
              {
                this.OpenCheckBycastleLv8(107);
                break;
              }
              if ((int) GUIManager.Instance.BuildingData.BuildingManorID == (int) this.manorID)
              {
                GUIManager.Instance.BuildingData.sendBuildFinish();
                break;
              }
              if (GUIManager.Instance.OpenCheckCrystal(costCrystal, (byte) 4, (int) this.manorID, (int) this.buildID))
                break;
              GUIManager.Instance.BuildingData.sendBuildCompleteImmediate(this.manorID, (ushort) this.buildID);
              break;
            }
            this.sb.Length = 0;
            if (this.backOutBtnType == e_FuncBtnType.AtOnce_Upgrade)
              this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3857U), (object) DataManager.Instance.mStringTable.GetStringByID(3822U));
            if (this.backOutBtnType == e_FuncBtnType.AtOnce_Build)
              this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3857U), (object) DataManager.Instance.mStringTable.GetStringByID(3820U));
            GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3966U), this.sb.ToString(), DataManager.Instance.mStringTable.GetStringByID(3968U), (GUIWindow) this, 103, bCloseIDSet: true);
            break;
          }
          if (DataManager.Instance.queueBarData[0].bActive)
          {
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(3819U), (ushort) byte.MaxValue);
            break;
          }
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5771U), (ushort) byte.MaxValue);
          break;
        }
        if (sender.m_BtnID2 != 100)
        {
          if (this.backOutBtnType == e_FuncBtnType.AtOnce_Research)
          {
            uint costCrystal = this.GetCostCrystal();
            if (DataManager.Instance.RoleAttr.Diamond >= costCrystal)
            {
              if (GUIManager.Instance.OpenCheckCrystal(costCrystal, (byte) 3, (int) this.techID))
                break;
              DataManager.Instance.sendTechnologyResearchCompleteImmediate((ushort) this.techID);
              break;
            }
            GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(3966U), DataManager.Instance.mStringTable.GetStringByID(646U), 103, YesText: DataManager.Instance.mStringTable.GetStringByID(3968U), NoText: DataManager.Instance.mStringTable.GetStringByID(4025U));
            break;
          }
          if (this.backOutBtnType != e_FuncBtnType.Cancel_Research)
            break;
          GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(5023U), DataManager.Instance.mStringTable.GetStringByID(5024U), 14, YesText: DataManager.Instance.mStringTable.GetStringByID(5026U), NoText: DataManager.Instance.mStringTable.GetStringByID(5025U));
          break;
        }
        CString msg1 = StringManager.Instance.StaticString1024();
        if (DataManager.Instance.queueBarData[1].bActive)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5017U), (ushort) byte.MaxValue);
          break;
        }
        if (!DataManager.Instance.CheckTechKind((ushort) DataManager.Instance.TechData.GetRecordByKey((ushort) this.techID).Kind, msg1))
        {
          GUIManager.Instance.AddHUDMessage(msg1.ToString(), (ushort) byte.MaxValue);
          break;
        }
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5771U), (ushort) byte.MaxValue);
        break;
      case 2:
        if (sender.m_BtnID2 != 100)
        {
          if (!this.bIsTechWindow)
          {
            if (this.buildID == (byte) 12 || this.buildID == (byte) 6)
              GUIManager.Instance.BuildingData.GuideSoldierID = (ushort) 0;
            if (this.buildType == e_BuildType.Normal)
            {
              if ((int) this.manorID == (int) GUIManager.Instance.BuildingData.BuildingManorID && this.buildID != (byte) 0)
              {
                this.SetBuildType(e_BuildType.Upgradeing);
                break;
              }
              this.SetBuildType(e_BuildType.Upgrade);
              break;
            }
            if (this.buildType == e_BuildType.Upgrade)
            {
              if (GUIManager.Instance.BuildingData.CheckLevelupRule((ushort) this.buildID, (byte) ((uint) this.buildLv + 1U)) != (byte) 0)
                break;
              if (this.buildID == (byte) 8 && this.buildLv == (byte) 8 && DataManager.Instance.HasNewbieShield())
              {
                this.OpenCheckBycastleLv8(108);
                break;
              }
              GUIManager.Instance.HideArrow();
              if (this.upgradeBtnType == e_FuncBtnType.Speed)
                GUIManager.Instance.BuildingData.sendStartBuilding(this.manorID, (ushort) this.buildID);
              else if (this.upgradeBtnType == e_FuncBtnType.Free)
                GUIManager.Instance.BuildingData.sendBuildCompleteFree();
              if (this.upgradeBtnType != e_FuncBtnType.Upgrade && this.upgradeBtnType != e_FuncBtnType.Build)
                break;
              GUIManager.Instance.BuildingData.sendStartBuilding(this.manorID, (ushort) this.buildID);
              break;
            }
            if (this.upgradeBtnType == e_FuncBtnType.Speed)
            {
              this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2);
              break;
            }
            if (this.upgradeBtnType == e_FuncBtnType.Free)
            {
              GUIManager.Instance.BuildingData.sendBuildCompleteFree();
              break;
            }
            if (this.upgradeBtnType != e_FuncBtnType.Help)
              break;
            DataManager.Instance.SendAllianceHelp((byte) 1);
            break;
          }
          if (this.buildType == e_BuildType.Upgrade_Tech)
          {
            if (DataManager.Instance.ResearchTech > (ushort) 0)
            {
              this.sb.Length = 0;
              TechDataTbl recordByKey = DataManager.Instance.TechData.GetRecordByKey(DataManager.Instance.ResearchTech);
              this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(5028U), (object) DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.TechName));
              GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(5027U), this.sb.ToString(), 104, YesText: DataManager.Instance.mStringTable.GetStringByID(5025U), NoText: DataManager.Instance.mStringTable.GetStringByID(5026U));
              break;
            }
            if (this.upgradeBtnType == e_FuncBtnType.Research)
            {
              DataManager.Instance.sendTechnologyResearchStart((ushort) this.techID);
              break;
            }
            if (this.upgradeBtnType != e_FuncBtnType.Free)
              break;
            DataManager.Instance.sendTechnologyCompleteFree();
            break;
          }
          if (this.buildType != e_BuildType.Upgradeing_Tech)
            break;
          if (this.upgradeBtnType == e_FuncBtnType.Free)
          {
            DataManager.Instance.sendTechnologyCompleteFree();
            break;
          }
          if (this.upgradeBtnType == e_FuncBtnType.Speed)
          {
            this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 1);
            break;
          }
          if (this.upgradeBtnType != e_FuncBtnType.Help)
            break;
          DataManager.Instance.SendAllianceHelp((byte) 0);
          break;
        }
        if (!this.bIsTechWindow)
        {
          if (DataManager.Instance.queueBarData[0].bActive)
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(3819U), (ushort) byte.MaxValue);
          else
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5771U), (ushort) byte.MaxValue);
        }
        else
        {
          CString msg2 = StringManager.Instance.StaticString1024();
          if (DataManager.Instance.queueBarData[1].bActive)
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5017U), (ushort) byte.MaxValue);
          else if (!DataManager.Instance.CheckTechKind((ushort) DataManager.Instance.TechData.GetRecordByKey((ushort) this.techID).Kind, msg2))
            GUIManager.Instance.AddHUDMessage(msg2.ToString(), (ushort) byte.MaxValue);
          else
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5771U), (ushort) byte.MaxValue);
        }
        GUIManager.Instance.HideArrow();
        break;
      case 3:
        this.Exit();
        break;
      case 4:
        if (this.buildID == (byte) 12 || this.buildID == (byte) 6)
          GUIManager.Instance.BuildingData.GuideSoldierID = (ushort) 0;
        switch (this.buildID)
        {
          case 6:
            this.door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 3);
            DataManager.Instance.OpenBagFilterByBuildingWindow = this.CheckNowOpenEBuildTypeWindow(this.buildType);
            DataManager.Instance.OriginalBuildType = this.buildType;
            return;
          case 12:
            this.door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 2);
            DataManager.Instance.OpenBagFilterByBuildingWindow = this.CheckNowOpenEBuildTypeWindow(this.buildType);
            DataManager.Instance.OriginalBuildType = this.buildType;
            return;
          default:
            return;
        }
      case 5:
        this.door.OpenMenu(EGUIWindow.UI_CastleSkin, bCameraMode: true);
        break;
      case 101:
        switch (this.bIsTechWindow ? DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Researching) : DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Building))
        {
          case eTimerSpriteType.Speed:
            if (this.bIsTechWindow)
              this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 1);
            else
              this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2);
            DataManager.Instance.OpenBagFilterByBuildingWindow = (byte) 1;
            DataManager.Instance.OriginalBuildType = this.buildType;
            return;
          case eTimerSpriteType.Help:
            DataManager.Instance.OpenBuildingWindowUpdateNoClose = (byte) 1;
            if (!this.bIsTechWindow)
            {
              DataManager.Instance.SendAllianceHelp((byte) 1);
              return;
            }
            DataManager.Instance.SendAllianceHelp((byte) 0);
            return;
          case eTimerSpriteType.Free:
            DataManager.Instance.OpenBuildingWindowUpdateNoClose = (byte) 1;
            if (this.bIsTechWindow)
            {
              DataManager.Instance.sendTechnologyCompleteFree();
              return;
            }
            GUIManager.Instance.BuildingData.sendBuildCompleteFree();
            return;
          default:
            return;
        }
      case 102:
        int btnId2_1 = sender.m_BtnID2;
        if (btnId2_1 >= this.upgradePanelData.Count)
          break;
        byte iconType = this.upgradePanelData[btnId2_1].iconType;
        uint Num = this.upgradePanelData[btnId2_1].value;
        uint itemId = this.upgradePanelData[btnId2_1].itemID;
        if ((bool) (Object) this.door)
        {
          if (this.upgradePanelData[btnId2_1].iconType == (byte) 8)
            this.door.OpenMenu(EGUIWindow.UI_BagFilter, 655361, (int) Num);
          else if (this.upgradePanelData[btnId2_1].iconType == (byte) 7)
            GUIManager.Instance.OpenItemFilterUI((ushort) itemId, (ushort) Num);
          else
            this.door.OpenMenu(EGUIWindow.UI_BagFilter, 1 + (4 + (int) iconType << 16), (int) Num);
          this.SaveScrollPostion();
        }
        DataManager.Instance.OpenBagFilterByBuildingWindow = (byte) 1;
        DataManager.Instance.OriginalBuildType = this.buildType;
        break;
      case 104:
        int btnId2_2 = sender.m_BtnID2;
        if (btnId2_2 >= this.upgradePanelData.Count || this.upgradePanelData[btnId2_2].btnType != (byte) 4)
          break;
        if (this.bIsTechWindow && this.upgradePanelData[btnId2_2].buildID == (ushort) 0)
        {
          ushort techId = this.upgradePanelData[btnId2_2].techID;
          GUIManager.Instance.HideArrow();
          GUIManager.Instance.GuideParm1 = (byte) 3;
          GUIManager.Instance.GuideParm2 = techId;
          GUIManager.Instance.OpenTechTree(techId);
          break;
        }
        ushort buildId = this.upgradePanelData[btnId2_2].buildID;
        GUIManager.Instance.BuildingData.ManorGuild((ushort) (byte) buildId);
        GUIManager.Instance.HideArrow();
        GUIManager.Instance.GuideParm1 = (byte) 1;
        GUIManager.Instance.GuideParm2 = buildId;
        this.door.CloseMenu(true);
        break;
    }
  }

  public void OnTimer(UITimeBar sender)
  {
    if (sender.m_TimeBarID != 1)
      return;
    this.timeBar.gameObject.SetActive(false);
  }

  public void OnNotify(UITimeBar sender)
  {
    if (this.bIsTechWindow)
    {
      eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Researching);
      GUIManager.Instance.SetTimerSpriteType(this.timeBar, queueBarSpriteType);
      this.SetBuildType(this.buildType, queueBarSpriteType);
    }
    else
    {
      eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Building);
      GUIManager.Instance.SetTimerSpriteType(this.timeBar, queueBarSpriteType);
      this.SetBuildType(this.buildType, queueBarSpriteType);
    }
  }

  public void Onfunc(UITimeBar sender)
  {
  }

  public void OnCancel(UITimeBar sender)
  {
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) item.transform.parent.parent == (Object) this.upgradeScrollPanel.transform)
    {
      if (dataIdx >= this.totalUpgradeCount)
        return;
      if (dataIdx == 0)
      {
        this.m_bNeedShow = false;
        if (this.upgradePanelData[dataIdx].iconType == (byte) 6)
        {
          this.m_TimeObjectIdx = panelObjectIdx;
          this.m_bNeedShow = true;
          this.m_TimeTick = 1f;
        }
      }
      if ((Object) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTexts == (Object) null)
      {
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTexts = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(2).GetComponent<UIText>();
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTimeTexts = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(4).GetComponent<UIText>();
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(0).GetComponent<Image>();
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnRect = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(1).GetComponent<RectTransform>();
        this.m_UpgradeItem[panelObjectIdx].m_TweenRotation = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(1).GetComponent<uTweenRotation>();
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(1).GetComponent<UIButton>().image;
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(1).GetComponent<UIButton>();
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_Handler = (IUIButtonClickHandler) this;
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText.font = GUIManager.Instance.GetTTFFont();
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText.text = DataManager.Instance.mStringTable.GetStringByID(5892U);
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTexts.font = GUIManager.Instance.GetTTFFont();
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTexts.supportRichText = true;
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTimeTexts.font = GUIManager.Instance.GetTTFFont();
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTimeTexts.supportRichText = true;
        this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImageXs = this.upgradeScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(5).GetComponent<Image>();
      }
      if ((bool) (Object) this.door)
      {
        this.m_UpgradeItem[panelObjectIdx].upgradeScrollPanelbConform = this.upgradePanelData[dataIdx].bConform;
        this.m_UpgradeItem[panelObjectIdx].upgradeScrollPanelIconType = this.upgradePanelData[dataIdx].iconType;
        this.m_UpgradeItem[panelObjectIdx].upgradeScrollPanelIconIdx = dataIdx;
        this.upgradePanelData[dataIdx].panelObjectIdx = panelObjectIdx;
        ((Behaviour) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImageXs).enabled = !this.upgradePanelData[dataIdx].bConform;
        if (this.upgradePanelData[dataIdx].iconType == (byte) 6)
        {
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.sprite = this.door.LoadSprite(this.iconSpriteName[8]);
          ((MaskableGraphic) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages).material = this.door.LoadMaterial();
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.SetNativeSize();
        }
        else if (this.upgradePanelData[dataIdx].iconType >= (byte) 0 && this.upgradePanelData[dataIdx].iconType <= (byte) 5)
        {
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.sprite = this.door.LoadSprite(this.iconSpriteName[(int) this.upgradePanelData[dataIdx].iconType]);
          ((MaskableGraphic) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages).material = this.door.LoadMaterial();
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.SetNativeSize();
        }
        else if (this.upgradePanelData[dataIdx].iconType == (byte) 7)
        {
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.sprite = !this.bIsTechWindow ? this.GM.LoadFrameSprite("icon020") : this.GM.LoadFrameSprite("icon015");
          ((MaskableGraphic) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages).material = GUIManager.Instance.GetFrameMaterial();
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.SetNativeSize();
        }
        else if (this.bIsTechWindow && this.upgradePanelData[dataIdx].iconType == (byte) 8)
        {
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.sprite = this.door.LoadSprite(this.petResIcon);
          ((MaskableGraphic) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages).material = this.door.LoadMaterial();
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemImages.SetNativeSize();
        }
        ((Behaviour) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText).enabled = false;
        this.m_UpgradeItem[panelObjectIdx].m_TweenRotation.enabled = false;
        if (this.upgradePanelData[dataIdx].btnType == (byte) 0)
        {
          this.SetTimeBarBtnSprite(this.bIsTechWindow ? DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Researching) : DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Building), panelObjectIdx);
          if (!this.upgradePanelData[dataIdx].bConform)
            ((Behaviour) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages).enabled = true;
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID1 = 101;
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID2 = dataIdx;
        }
        else if (this.upgradePanelData[dataIdx].btnType == (byte) 1)
        {
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.sprite = this.door.LoadSprite(this.iconSpriteName[7]);
          ((MaskableGraphic) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages).material = this.door.LoadMaterial();
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.SetNativeSize();
          if (!this.upgradePanelData[dataIdx].bConform)
            ((Behaviour) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages).enabled = true;
          else
            ((Behaviour) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages).enabled = false;
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID1 = 102;
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID2 = dataIdx;
        }
        else if (this.upgradePanelData[dataIdx].btnType == (byte) 2)
        {
          ((MaskableGraphic) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages).material = this.door.LoadMaterial();
          ((Behaviour) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages).enabled = false;
        }
        else if (this.upgradePanelData[dataIdx].btnType == (byte) 3)
        {
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.sprite = this.door.LoadSprite(this.iconSpriteName[6]);
          ((MaskableGraphic) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages).material = this.door.LoadMaterial();
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.SetNativeSize();
          if (!this.upgradePanelData[dataIdx].bConform)
            ((Behaviour) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages).enabled = true;
          else
            ((Behaviour) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages).enabled = false;
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID1 = 103;
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID2 = dataIdx;
        }
        else if (this.upgradePanelData[dataIdx].btnType == (byte) 4)
        {
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.sprite = this.door.LoadSprite(this.iconSpriteName[10]);
          ((MaskableGraphic) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages).material = this.door.LoadMaterial();
          ((Graphic) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages).rectTransform.sizeDelta = new Vector2(69f, 47f);
          ((Behaviour) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText).enabled = true;
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages.type = (Image.Type) 1;
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText.text = DataManager.Instance.mStringTable.GetStringByID(5892U);
          if (!this.upgradePanelData[dataIdx].bConform)
          {
            ((Behaviour) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages).enabled = true;
            ((Behaviour) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText).enabled = true;
          }
          else
          {
            ((Behaviour) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnText).enabled = false;
            ((Behaviour) this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtnImages).enabled = false;
          }
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID1 = 104;
          this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemBtns.m_BtnID2 = dataIdx;
        }
      }
      this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTexts.text = this.upgradePanelData[dataIdx].text;
      this.m_UpgradeItem[panelObjectIdx].m_UpgradeItemTimeTexts.text = string.Empty;
    }
    else
    {
      if (!((Object) item.transform.parent.parent == (Object) this.infoScrollPanel.transform) || dataIdx >= this.totalUpgradeEffectCount || this.m_UpgradeInfoItemTexts == null)
        return;
      if ((Object) this.m_UpgradeInfoItemTexts[panelObjectIdx] == (Object) null)
      {
        this.m_UpgradeInfoItemTexts[panelObjectIdx] = this.infoScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(0).GetComponent<UIText>();
        this.m_UpgradeInfoItemImages[panelObjectIdx] = this.infoScrollPanel.m_PanelObjects[panelObjectIdx].gameObject.transform.GetChild(1).GetComponent<Image>();
        ArabicItemTextureRot arabicItemTextureRot = ((Component) this.m_UpgradeInfoItemImages[panelObjectIdx]).gameObject.AddComponent<ArabicItemTextureRot>();
        if ((bool) (Object) arabicItemTextureRot)
          ((Behaviour) arabicItemTextureRot).enabled = false;
        this.m_UpgradeInfoItemTexts[panelObjectIdx].font = GUIManager.Instance.GetTTFFont();
        this.m_UpgradeInfoItemTexts[panelObjectIdx].supportRichText = true;
      }
      this.m_UpgradeInfoItemTexts[panelObjectIdx].text = this.upgradeEffectData[dataIdx].text;
      ((Component) this.m_UpgradeInfoItemImages[panelObjectIdx]).gameObject.SetActive(true);
      ArabicItemTextureRot component = ((Component) this.m_UpgradeInfoItemImages[panelObjectIdx]).GetComponent<ArabicItemTextureRot>();
      if ((bool) (Object) component)
        ((Behaviour) component).enabled = false;
      if (this.upgradeEffectData[dataIdx].iconType == (ushort) 1)
      {
        this.m_UpgradeInfoItemImages[panelObjectIdx].sprite = this.spArray.m_Sprites[1];
        ((MaskableGraphic) this.m_UpgradeInfoItemImages[panelObjectIdx]).material = this.m_Mat;
        this.m_UpgradeInfoItemImages[panelObjectIdx].SetNativeSize();
      }
      else
      {
        if (this.upgradeEffectData[dataIdx].iconType == (ushort) 55)
          ((Behaviour) component).enabled = true;
        this.m_UpgradeInfoItemImages[panelObjectIdx].sprite = this.GetSpriteByEffect(this.upgradeEffectData[dataIdx].iconType);
        ((MaskableGraphic) this.m_UpgradeInfoItemImages[panelObjectIdx]).material = GUIManager.Instance.GetFrameMaterial();
        this.m_UpgradeInfoItemImages[panelObjectIdx].SetNativeSize();
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void DestroyBuildingWindow()
  {
    AssetManager.UnloadAssetBundle(this.abKey);
    if (this.GM.upgradePanelDataPool != null)
    {
      for (int index = this.upgradePanelData.Count - 1; index >= 0; --index)
      {
        this.GM.upgradePanelDataPool.despawn(this.upgradePanelData[index]);
        this.upgradePanelData.RemoveAt(index);
      }
    }
    if (this.GM.upgradeEffectDataPool != null)
    {
      for (int index = this.upgradeEffectData.Count - 1; index >= 0; --index)
      {
        this.GM.upgradeEffectDataPool.despawn(this.upgradeEffectData[index]);
        this.upgradeEffectData.RemoveAt(index);
      }
    }
    this.upgradePanelData = (List<BuildInfoObject>) null;
    this.upgradeEffectData = (List<BuildInfoObject2>) null;
    GUIManager.Instance.RemoverTimeBaarToList(this.timeBar);
    GUIManager.Instance.RemoveSpriteAsset(nameof (BuildingWindow));
    DataManager.Instance.OriginalBuildType = DataManager.Instance.OpenBagFilterByBuildingWindow != (byte) 1 ? e_BuildType.Normal : this.buildType;
    StringManager.Instance.DeSpawnString(this.tempString);
    StringManager.Instance.DeSpawnString(this.tempString2);
    StringManager.Instance.DeSpawnString(this.tempString3);
    StringManager.Instance.DeSpawnString(this.effectString);
  }

  public void MyUpdate(byte close = 0, bool bSetBuildType = false)
  {
    if (close >= (byte) 1)
    {
      if (close == (byte) 1)
        this.door.CloseMenu(true);
      else if (close == (byte) 2)
        this.door.CloseMenu();
      else if (close == (byte) 3 && (int) this.manorID == (int) this.GM.BuildingData.BuildingManorID)
        this.door.CloseMenu();
      if (!this.bOpenBackOutCheckBox)
        return;
      GUIManager.Instance.CloseOKCancelBox();
    }
    else if (!this.bIsTechWindow)
    {
      if (GUIManager.Instance.BuildingData.AllBuildsData.Length <= (int) this.manorID)
        return;
      this.buildLv = GUIManager.Instance.BuildingData.AllBuildsData[(int) this.manorID].Level;
      if ((bool) (Object) this.door)
      {
        ((MaskableGraphic) this.sliderBGImage).material = this.door.LoadMaterial();
        this.sliderBGImage.sprite = this.door.LoadSprite("UI_main_up_box");
        this.sliderBGImage.type = (Image.Type) 1;
        ((MaskableGraphic) this.sliderImage).material = this.door.LoadMaterial();
        this.sliderImage.sprite = (int) this.buildLv < (int) this.buildLvMAx ? this.door.LoadSprite("UI_main_up_blood_a") : this.door.LoadSprite("UI_main_up_blood_b");
        this.sliderImage.type = (Image.Type) 1;
        ((Component) this.sliderImage).GetComponent<RectTransform>().sizeDelta = new Vector2((float) ((double) this.buildLv / (double) this.buildLvMAx * 136.0), 13f);
        this.sb.Length = 0;
        if ((int) this.buildLv >= (int) this.buildLvMAx)
          this.sb.Append(DataManager.Instance.mStringTable.GetStringByID(3831U));
        else if (GUIManager.Instance.IsArabic)
          this.sb.AppendFormat("{0}/{1}", (object) this.buildLvMAx, (object) this.buildLv);
        else
          this.sb.AppendFormat("{0}/{1}", (object) this.buildLv, (object) this.buildLvMAx);
        this.lvText.font = GUIManager.Instance.GetTTFFont();
        this.lvText.text = this.sb.ToString();
      }
      if (this.buildID == (byte) 6)
      {
        ((Transform) this.buildingTransform.GetComponent<RectTransform>()).localScale = (Vector3) new Vector2(0.7f, 0.7f);
        this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 10f);
      }
      else if (this.buildID == (byte) 8)
      {
        ((Transform) this.buildingTransform.GetComponent<RectTransform>()).localScale = (Vector3) new Vector2(0.4f, 0.4f);
        this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(2f, 4f);
      }
      else if (this.buildID == (byte) 10)
      {
        ((Transform) this.buildingTransform.GetComponent<RectTransform>()).localScale = (Vector3) new Vector2(0.6f, 0.6f);
        this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 20f);
      }
      else if (this.buildID == (byte) 11)
      {
        ((Transform) this.buildingTransform.GetComponent<RectTransform>()).localScale = (Vector3) new Vector2(0.6f, 0.6f);
        this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 10f);
      }
      else if (this.buildID == (byte) 12)
      {
        ((Transform) this.buildingTransform.GetComponent<RectTransform>()).localScale = (Vector3) new Vector2(0.8f, 0.8f);
        this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 20f);
      }
      else if (this.buildID == (byte) 15)
      {
        ((Transform) this.buildingTransform.GetComponent<RectTransform>()).localScale = (Vector3) new Vector2(0.7f, 0.7f);
        this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 15f);
      }
      else if (this.buildID == (byte) 16)
      {
        ((Transform) this.buildingTransform.GetComponent<RectTransform>()).localScale = (Vector3) new Vector2(0.6f, 0.6f);
        this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 10f);
      }
      else if (this.buildID == (byte) 18)
      {
        ((Transform) this.buildingTransform.GetComponent<RectTransform>()).localScale = (Vector3) new Vector2(0.65f, 0.65f);
        this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 10f);
      }
      else if (this.buildID == (byte) 19)
      {
        ((Transform) this.buildingTransform.GetComponent<RectTransform>()).localScale = (Vector3) new Vector2(0.65f, 0.65f);
        this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 10f);
      }
      else if (this.buildID == (byte) 20)
      {
        ((Transform) this.buildingTransform.GetComponent<RectTransform>()).localScale = (Vector3) new Vector2(0.61f, 0.61f);
        this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 10f);
      }
      else if (this.buildID == (byte) 21)
      {
        ((Transform) this.buildingTransform.GetComponent<RectTransform>()).localScale = (Vector3) new Vector2(0.8f, 0.8f);
        this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 10f);
      }
      else if (this.buildID == (byte) 22)
      {
        ((Transform) this.buildingTransform.GetComponent<RectTransform>()).localScale = (Vector3) new Vector2(0.7f, 0.7f);
        this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 10f);
      }
      else if (this.buildID == (byte) 23)
      {
        ((Transform) this.buildingTransform.GetComponent<RectTransform>()).localScale = (Vector3) new Vector2(0.7f, 0.7f);
        this.buildingTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, 15f);
      }
      Image component1 = this.buildingTransform.GetComponent<Image>();
      if (this.buildID == (byte) 8)
      {
        component1.sprite = GUIManager.Instance.BuildingData.castleSkin.GetUISprite((byte) 0, this.buildLv);
        ((MaskableGraphic) component1).material = GUIManager.Instance.BuildingData.castleSkin.GetUIMaterial((byte) 0, this.buildLv);
      }
      else
      {
        component1.sprite = GUIManager.Instance.BuildingData.GetBuildSprite((ushort) this.buildID, this.buildLv);
        ((MaskableGraphic) component1).material = GUIManager.Instance.BuildingData.mapspriteManager.SpriteUIMaterial;
      }
      component1.SetNativeSize();
      if (this.style == (byte) 1)
      {
        this.SetNormalPanel();
        this.SetNormalInfoPanel();
      }
      Image component2 = this.upgradePanelItem.GetChild(5).GetComponent<Image>();
      component2.sprite = this.door.LoadSprite(this.iconSpriteName[9]);
      ((MaskableGraphic) component2).material = this.door.LoadMaterial();
      component2.SetNativeSize();
      this.SetUpgradePanel();
      this.SetUpgradeInfoPanel();
      if (DataManager.Instance.OpenBagFilterByBuildingWindow == (byte) 1)
      {
        if (DataManager.Instance.OriginalBuildType == e_BuildType.SelfUpgradeing)
        {
          if ((int) GUIManager.Instance.BuildingData.BuildingManorID == (int) this.manorID)
            this.SetBuildType(DataManager.Instance.OriginalBuildType);
          else
            this.SetBuildType(e_BuildType.Upgrade);
        }
        else
          this.SetBuildType(DataManager.Instance.OriginalBuildType);
      }
      else if ((int) GUIManager.Instance.BuildingData.BuildingManorID == (int) this.manorID)
      {
        long startTime = DataManager.Instance.queueBarData[0].StartTime;
        long target = startTime + (long) DataManager.Instance.queueBarData[0].TotalTime;
        long notifyTime = target - (long) DataManager.Instance.FreeCompletePeriod;
        eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Building);
        DataManager.Instance.GetQueueBarTitle(EQueueBarIndex.Building, this.sb, ref this.m_TimeBarStr1, ref this.m_TimeBarStr2);
        GUIManager.Instance.SetTimerSpriteType(this.timeBar, queueBarSpriteType);
        GUIManager.Instance.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.NormalType, this.m_TimeBarStr1, this.m_TimeBarStr2);
        this.timeBar.gameObject.SetActive(true);
        if (GUIManager.Instance.BuildingData.QueueBuildType == (byte) 1)
          this.SetBuildType(e_BuildType.SelfUpgradeing, queueBarSpriteType);
        else
          this.SetBuildType(e_BuildType.SelfBackOuting, queueBarSpriteType);
      }
      else if (GUIManager.Instance.BuildingData.BuildingManorID != (ushort) 0 && GUIManager.Instance.BuildingData.AllBuildsData[(int) this.manorID].BuildID != (ushort) 0)
      {
        long startTime = DataManager.Instance.queueBarData[0].StartTime;
        long target = startTime + (long) DataManager.Instance.queueBarData[0].TotalTime;
        long notifyTime = target - (long) DataManager.Instance.FreeCompletePeriod;
        eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Building);
        GUIManager.Instance.SetTimerSpriteType(this.timeBar, queueBarSpriteType);
        GUIManager.Instance.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.NormalType, this.m_TimeBarStr1, this.m_TimeBarStr2);
        this.timeBar.gameObject.SetActive(true);
        this.SetBuildType(this.buildType, queueBarSpriteType);
      }
      else if (GUIManager.Instance.BuildingData.AllBuildsData[(int) this.manorID].BuildID == (ushort) 0)
      {
        this.SetBuildType(e_BuildType.Upgrade);
      }
      else
      {
        this.timeBar.gameObject.SetActive(false);
        if (this.buildType == e_BuildType.SelfUpgradeing)
          this.SetBuildType(e_BuildType.Normal);
        else
          this.SetBuildType(this.buildType);
      }
      this.SetUpdateTimeText();
    }
    else
    {
      Image component = this.upgradePanelItem.GetChild(5).GetComponent<Image>();
      component.sprite = this.door.LoadSprite(this.iconSpriteName[9]);
      ((MaskableGraphic) component).material = this.door.LoadMaterial();
      component.SetNativeSize();
      this.SetUpdateTimeText();
      this.SetUpgradePanel_Tech();
      this.SetUpgradeInfoPanel_Tech();
      this.buildingLvBG.gameObject.SetActive(false);
      this.buildingTransformBG.gameObject.SetActive(false);
      if ((int) DataManager.Instance.ResearchTech == (int) this.techID)
      {
        long startTime = DataManager.Instance.queueBarData[1].StartTime;
        long target = startTime + (long) DataManager.Instance.queueBarData[1].TotalTime;
        long notifyTime = target - (long) DataManager.Instance.FreeCompletePeriod;
        DataManager.Instance.GetQueueBarTitle(EQueueBarIndex.Researching, this.sb, ref this.m_TimeBarStr1, ref this.m_TimeBarStr2);
        eTimerSpriteType queueBarSpriteType = DataManager.Instance.GetQueueBarSpriteType(EQueueBarIndex.Researching);
        GUIManager.Instance.SetTimerSpriteType(this.timeBar, queueBarSpriteType);
        GUIManager.Instance.SetTimerBar(this.timeBar, startTime, target, notifyTime, eTimeBarType.NormalType, this.m_TimeBarStr1, this.m_TimeBarStr2);
        this.timeBar.gameObject.SetActive(true);
        this.SetBuildType(e_BuildType.Upgradeing_Tech, queueBarSpriteType);
      }
      else
      {
        this.timeBar.gameObject.SetActive(false);
        this.SetBuildType(e_BuildType.Upgrade_Tech);
      }
    }
  }

  private void SetNormalPanel()
  {
    int index1 = 0;
    ResourceType Type = ResourceType.Grain;
    AttribValManager attribVal = DataManager.Instance.AttribVal;
    uint num1 = 0;
    uint num2 = 0;
    if (this.buildID == (byte) 1)
    {
      Type = ResourceType.Wood;
      num1 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_WOOD_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
      num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_WOOD_PRODUCTION_PERCENT_DEBUFF);
    }
    if (this.buildID == (byte) 2)
    {
      Type = ResourceType.Rock;
      num1 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ROCK_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
      num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ROCK_PRODUCTION_PERCENT_DEBUFF);
    }
    if (this.buildID == (byte) 3)
    {
      Type = ResourceType.Steel;
      num1 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_STEEL_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
      num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_STEEL_PRODUCTION_PERCENT_DEBUFF);
    }
    if (this.buildID == (byte) 4)
    {
      Type = ResourceType.Grain;
      num1 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_FOOD_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
      num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_FOOD_PRODUCTION_PERCENT_DEBUFF);
    }
    if (this.buildID == (byte) 5)
    {
      Type = ResourceType.Money;
      num1 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MONEY_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
      num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MONEY_PRODUCTION_PERCENT_DEBUFF);
    }
    if (this.buildID == (byte) 4)
    {
      this.normalPanelInfoTf3.gameObject.SetActive(true);
      ((Component) this.normalPanelTitles[3]).gameObject.SetActive(true);
    }
    else
    {
      this.normalPanelInfoTf3.gameObject.SetActive(false);
      ((Component) this.normalPanelTitles[3]).gameObject.SetActive(false);
    }
    for (int index2 = 0; index2 < 4; ++index2)
    {
      this.normalPanelTitles[index2].font = GUIManager.Instance.GetTTFFont();
      this.normalPanelInfos[index2].font = GUIManager.Instance.GetTTFFont();
      ((MaskableGraphic) this.normalPanelInfosImage[index2]).material = this.door.LoadMaterial();
    }
    BuildLevelRequest levelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort) this.buildID, (byte) Mathf.Clamp((int) this.buildLv, 1, (int) this.buildLvMAx));
    this.sb.Length = 0;
    GameConstants.GetEffectValue(this.sb, levelRequestData.Effect1, 0U, (byte) 0, 0.0f, 0L);
    this.normalPanelTitles[index1].text = this.sb.ToString();
    ulong num3;
    if (num2 > num1)
    {
      uint num4 = num2 - num1;
      if (num4 > 9900U)
        num4 = 9900U;
      num3 = (ulong) ((long) levelRequestData.Value1 * 10000L - (long) levelRequestData.Value1 * (long) num4);
    }
    else
    {
      uint num5 = num1 - num2;
      num3 = (ulong) ((long) levelRequestData.Value1 * 10000L + (long) levelRequestData.Value1 * (long) num5);
    }
    uint num6 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_CURSE);
    if (num6 > 9900U)
      num6 = 9900U;
    ulong num7 = (ulong) (10000L * (long) num3 - (long) num3 * (long) num6) / 100000000UL;
    this.normalPanelInfos[index1].text = this.buildLv != (byte) 0 ? num7.ToString("N0") : "0";
    if ((int) this.buildID < this.iconBulidSpriteName.Length)
      this.normalPanelInfosImage[index1].sprite = this.door.LoadSprite(this.iconBulidSpriteName[(int) this.buildID]);
    this.normalPanelInfosImage[index1].SetNativeSize();
    int index3 = index1 + 1;
    if (this.buildID == (byte) 4)
    {
      this.normalPanelTitles[index3].text = DataManager.Instance.mStringTable.GetStringByID(3830U);
      this.sb.Length = 0;
      if (DataManager.Instance.AttribVal.TotalSoldierConsume > 0UL)
        this.sb.AppendFormat("<color=#F63954>-{0:N0}</color>", (object) DataManager.Instance.AttribVal.TotalSoldierConsume);
      else
        this.sb.AppendFormat("{0:N0}", (object) DataManager.Instance.AttribVal.TotalSoldierConsume);
      this.normalPanelInfos[index3].text = this.sb.ToString();
      ((MaskableGraphic) this.normalPanelInfosImage[index3]).material = this.uiMat;
      this.normalPanelInfosImage[index3].sprite = this.spArray.m_Sprites[2];
      this.normalPanelInfosImage[index3].SetNativeSize();
      ++index3;
    }
    switch (Type)
    {
      case ResourceType.Grain:
        this.normalPanelTitles[index3].text = DataManager.Instance.mStringTable.GetStringByID(5792U);
        break;
      case ResourceType.Rock:
        this.normalPanelTitles[index3].text = DataManager.Instance.mStringTable.GetStringByID(5793U);
        break;
      case ResourceType.Wood:
        this.normalPanelTitles[index3].text = DataManager.Instance.mStringTable.GetStringByID(5794U);
        break;
      case ResourceType.Steel:
        this.normalPanelTitles[index3].text = DataManager.Instance.mStringTable.GetStringByID(5795U);
        break;
      case ResourceType.Money:
        this.normalPanelTitles[index3].text = DataManager.Instance.mStringTable.GetStringByID(5796U);
        break;
    }
    this.normalPanelInfos[index3].text = DataManager.Instance.Resource[(int) Type].Capacity.ToString("N0");
    ((MaskableGraphic) this.normalPanelInfosImage[index3]).material = this.uiMat;
    this.normalPanelInfosImage[index3].sprite = this.spArray.m_Sprites[3];
    this.normalPanelInfosImage[index3].SetNativeSize();
    int index4 = index3 + 1;
    this.normalPanelTitles[index4].text = DataManager.Instance.mStringTable.GetStringByID(3832U);
    long num8 = DataManager.MissionDataManager.UpdateResourceInfo(Type);
    this.normalPanelInfos[index4].text = num8.ToString("N0");
    if ((int) this.buildID < this.iconBulidSpriteName.Length)
      this.normalPanelInfosImage[index4].sprite = this.door.LoadSprite(this.iconBulidSpriteName[(int) this.buildID]);
    this.normalPanelInfosImage[index4].SetNativeSize();
    int num9 = index4 + 1;
  }

  private bool GetResStr(ResourceType resType, out string text, byte id, byte lv, out uint value)
  {
    bool resStr = false;
    value = 0U;
    BuildLevelRequest levelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort) id, lv);
    switch (resType)
    {
      case ResourceType.Grain:
        value = levelRequestData.RequestFood;
        resStr = levelRequestData.RequestFood <= DataManager.Instance.Resource[(int) resType].Stock;
        break;
      case ResourceType.Rock:
        value = levelRequestData.RequestRock;
        resStr = levelRequestData.RequestRock <= DataManager.Instance.Resource[(int) resType].Stock;
        break;
      case ResourceType.Wood:
        value = levelRequestData.RequestWood;
        resStr = levelRequestData.RequestWood <= DataManager.Instance.Resource[(int) resType].Stock;
        break;
      case ResourceType.Steel:
        value = levelRequestData.RequestIron;
        resStr = levelRequestData.RequestIron <= DataManager.Instance.Resource[(int) resType].Stock;
        break;
      case ResourceType.Money:
        value = levelRequestData.RequestGold;
        resStr = levelRequestData.RequestGold <= DataManager.Instance.Resource[(int) resType].Stock;
        break;
    }
    this.sb.Length = 0;
    if (resStr)
    {
      if (this.GM.IsArabic)
        this.sb.AppendFormat("{0:N0} / {1:N0}", (object) value, (object) DataManager.Instance.Resource[(int) resType].Stock);
      else
        this.sb.AppendFormat("{0:N0} / {1:N0}", (object) DataManager.Instance.Resource[(int) resType].Stock, (object) value);
      this.m_CostCrystal[(int) resType] = 0U;
    }
    else
    {
      if (this.GM.IsArabic)
        this.sb.AppendFormat("{0:N0} / <color=#F63954>{1:N0}</color>  ", (object) value, (object) DataManager.Instance.Resource[(int) resType].Stock);
      else
        this.sb.AppendFormat("<color=#F63954>{0:N0}</color> / {1:N0} ", (object) DataManager.Instance.Resource[(int) resType].Stock, (object) value);
      this.m_CostCrystal[(int) resType] = value - DataManager.Instance.Resource[(int) resType].Stock;
    }
    text = this.sb.ToString();
    return resStr;
  }

  private bool GetResStr_Tech(
    ResourceType resType,
    out string text,
    byte id,
    byte lv,
    out uint value)
  {
    bool flag = false;
    bool resStrTech = false;
    TechLevelTbl Data;
    flag = DataManager.Instance.GetTechLevelupData(out Data, (ushort) id, lv);
    value = 0U;
    switch (resType)
    {
      case ResourceType.Grain:
        value = Data.Grain;
        resStrTech = Data.Grain <= DataManager.Instance.Resource[(int) resType].Stock;
        break;
      case ResourceType.Rock:
        value = Data.Rock;
        resStrTech = Data.Rock <= DataManager.Instance.Resource[(int) resType].Stock;
        break;
      case ResourceType.Wood:
        value = Data.Wood;
        resStrTech = Data.Wood <= DataManager.Instance.Resource[(int) resType].Stock;
        break;
      case ResourceType.Steel:
        value = Data.Iron;
        resStrTech = Data.Iron <= DataManager.Instance.Resource[(int) resType].Stock;
        break;
      case ResourceType.Money:
        value = Data.Gold;
        resStrTech = Data.Gold <= DataManager.Instance.Resource[(int) resType].Stock;
        break;
    }
    this.sb.Length = 0;
    if (resStrTech)
    {
      this.m_CostCrystal[(int) resType] = 0U;
      if (this.GM.IsArabic)
        this.sb.AppendFormat("{0:N0} / {1:N0}", (object) value, (object) DataManager.Instance.Resource[(int) resType].Stock);
      else
        this.sb.AppendFormat("{0:N0} / {1:N0}", (object) DataManager.Instance.Resource[(int) resType].Stock, (object) value);
    }
    else
    {
      if (this.GM.IsArabic)
        this.sb.AppendFormat("{0:N0} / <color=#F63954>{1:N0}</color>  ", (object) value, (object) DataManager.Instance.Resource[(int) resType].Stock);
      else
        this.sb.AppendFormat("<color=#F63954>{0:N0}</color> / {1:N0} ", (object) DataManager.Instance.Resource[(int) resType].Stock, (object) value);
      this.m_CostCrystal[(int) resType] = value - DataManager.Instance.Resource[(int) resType].Stock;
    }
    text = this.sb.ToString();
    return resStrTech;
  }

  private bool GetPetResourceStr(out string text, byte id, byte lv, out uint value)
  {
    int index = 8;
    bool petResourceStr = false;
    TechLevelExTbl Data;
    bool techLevelupDataEx = DataManager.Instance.GetTechLevelupDataEx(out Data, (ushort) id, lv);
    value = 0U;
    if (techLevelupDataEx)
    {
      value = Data.PetResource;
      petResourceStr = value <= DataManager.Instance.PetResource.Stock;
      this.sb.Length = 0;
      if (petResourceStr)
      {
        this.m_CostCrystal[index] = 0U;
        if (this.GM.IsArabic)
          this.sb.AppendFormat("{0:N0} / {1:N0}", (object) value, (object) DataManager.Instance.PetResource.Stock);
        else
          this.sb.AppendFormat("{0:N0} / {1:N0}", (object) DataManager.Instance.PetResource.Stock, (object) value);
      }
      else
      {
        if (this.GM.IsArabic)
          this.sb.AppendFormat("{0:N0} / <color=#F63954>{1:N0}</color>  ", (object) value, (object) DataManager.Instance.PetResource.Stock);
        else
          this.sb.AppendFormat("<color=#F63954>{0:N0}</color> / {1:N0} ", (object) DataManager.Instance.PetResource.Stock, (object) value);
        this.m_CostCrystal[index] = value - DataManager.Instance.PetResource.Stock;
      }
    }
    text = this.sb.ToString();
    return petResourceStr;
  }

  private void SetUpgradePanel()
  {
    this.m_bSpecialConform = true;
    this.m_bGeneralConform = true;
    this.m_CostCrystal[7] = 0U;
    byte num1 = (byte) Mathf.Clamp((int) this.buildLv + 1, 1, (int) this.buildLvMAx);
    BuildLevelRequest levelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort) this.buildID, num1);
    int BeginIndex = 0;
    int Num = 0;
    ushort groupId = levelRequestData.GroupID;
    this.upgradeDataIdx = 0;
    if (groupId > (ushort) 0)
      GUIManager.Instance.BuildingData.GetLevelRequestGroupIndex(groupId, ref BeginIndex, ref Num);
    this.totalUpgradeCount = !DataManager.Instance.queueBarData[0].bActive ? Num : Num + 1;
    if (levelRequestData.RequestFood > 0U)
      ++this.totalUpgradeCount;
    if (levelRequestData.RequestWood > 0U)
      ++this.totalUpgradeCount;
    if (levelRequestData.RequestRock > 0U)
      ++this.totalUpgradeCount;
    if (levelRequestData.RequestIron > 0U)
      ++this.totalUpgradeCount;
    if (levelRequestData.RequestGold > 0U)
      ++this.totalUpgradeCount;
    for (int index = 0; index < this.upgradePanelData.Count; ++index)
      this.GM.upgradePanelDataPool.despawn(this.upgradePanelData[index]);
    this.upgradePanelData.Clear();
    if (this.upgradePanelData.Count < this.totalUpgradeCount)
    {
      int num2 = this.totalUpgradeCount - this.upgradePanelData.Count;
      for (int index = 0; index < num2; ++index)
        this.upgradePanelData.Add(this.GM.upgradePanelDataPool.spawn());
    }
    if (DataManager.Instance.queueBarData[0].bActive)
    {
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 2;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 6;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 0;
      this.upgradePanelData[this.upgradeDataIdx].bConform = false;
      this.m_BuildStartTime = DataManager.Instance.queueBarData[0].StartTime;
      this.m_BuildEndTime = this.m_BuildStartTime + (long) DataManager.Instance.queueBarData[0].TotalTime;
      this.sb.Length = 0;
      this.sb.AppendFormat("<color=#F63954>{0}</color>", (object) DataManager.Instance.mStringTable.GetStringByID(3819U));
      this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
      this.m_bGeneralConform = false;
      this.upgradePanelData[this.upgradeDataIdx].bConform = this.m_bGeneralConform;
      ++this.upgradeDataIdx;
    }
    else
    {
      this.m_BuildStartTime = 0L;
      this.m_BuildEndTime = 0L;
    }
    for (int Index = BeginIndex; Index < BeginIndex + Num; ++Index)
    {
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 2;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 4;
      this.upgradePanelData[this.upgradeDataIdx].buildID = (ushort) 0;
      this.upgradePanelData[this.upgradeDataIdx].techID = (ushort) 0;
      this.sb.Length = 0;
      BuildLevelRequestGroup recordByIndex = DataManager.Instance.BuildsLevelRequestGroup.GetRecordByIndex(Index);
      if (recordByIndex.ConditionType == (byte) 1)
      {
        BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey(recordByIndex.Condition);
        this.upgradePanelData[this.upgradeDataIdx].buildID = recordByKey.BuildID;
        int length = GUIManager.Instance.BuildingData.AllBuildsData.Length;
        byte a = 0;
        for (int index = 0; index < length; ++index)
        {
          ushort buildId = GUIManager.Instance.BuildingData.AllBuildsData[index].BuildID;
          if (buildId != (ushort) 0 && (int) buildId == (int) recordByKey.BuildID)
            a = (byte) Mathf.Max((int) a, (int) GUIManager.Instance.BuildingData.AllBuildsData[index].Level);
        }
        bool flag = (int) recordByIndex.Num <= (int) a;
        this.upgradePanelData[this.upgradeDataIdx].bConform = flag;
        if (flag)
        {
          this.sb.AppendFormat("{0} : {1}{2} ", (object) DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.NameID), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) recordByIndex.Num);
        }
        else
        {
          this.m_bSpecialConform = false;
          this.sb.AppendFormat("<color=#F63954>{0}: {1}{2}</color> ", (object) DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.NameID), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) recordByIndex.Num);
        }
        this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 0;
        this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
      }
      else if (recordByIndex.ConditionType == (byte) 2)
      {
        Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(recordByIndex.Condition);
        ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(recordByIndex.Condition, (byte) 0);
        if ((int) curItemQuantity >= (int) recordByIndex.Num)
        {
          this.upgradePanelData[this.upgradeDataIdx].bConform = true;
          this.sb.AppendFormat("{0} : {1:N0} / {2:N0} ", (object) DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.EquipName), (object) curItemQuantity, (object) recordByIndex.Num);
        }
        else
        {
          this.upgradePanelData[this.upgradeDataIdx].bConform = false;
          this.m_bGeneralConform = false;
          this.sb.AppendFormat("{0} : <color=#F63954>{1:N0}</color> / {2:N0} ", (object) DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.EquipName), (object) curItemQuantity, (object) recordByIndex.Num);
          this.m_CostCrystal[7] += (uint) ((ulong) DataManager.Instance.StoreData.GetRecordByKey(DataManager.Instance.TotalShopItemData.Find(recordByKey.EquipKey)).Price * (ulong) ((int) recordByIndex.Num - (int) curItemQuantity));
        }
        this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 7;
        this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 1;
        this.upgradePanelData[this.upgradeDataIdx].itemID = (uint) recordByKey.EquipKey;
        this.upgradePanelData[this.upgradeDataIdx].value = (uint) recordByIndex.Num;
        this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
      }
      ++this.upgradeDataIdx;
    }
    if (levelRequestData.RequestFood > 0U)
    {
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 3;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 1;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 1;
      bool resStr = this.GetResStr(ResourceType.Grain, out this.upgradePanelData[this.upgradeDataIdx].text, this.buildID, num1, out this.upgradePanelData[this.upgradeDataIdx].value);
      if (!resStr)
        this.m_bGeneralConform_update = false;
      this.upgradePanelData[this.upgradeDataIdx].bConform = resStr;
      ++this.upgradeDataIdx;
    }
    if (levelRequestData.RequestRock > 0U)
    {
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 3;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 2;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 1;
      bool resStr = this.GetResStr(ResourceType.Rock, out this.upgradePanelData[this.upgradeDataIdx].text, this.buildID, num1, out this.upgradePanelData[this.upgradeDataIdx].value);
      if (!resStr)
        this.m_bGeneralConform_update = false;
      this.upgradePanelData[this.upgradeDataIdx].bConform = resStr;
      ++this.upgradeDataIdx;
    }
    if (levelRequestData.RequestWood > 0U)
    {
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 3;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 3;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 1;
      bool resStr = this.GetResStr(ResourceType.Wood, out this.upgradePanelData[this.upgradeDataIdx].text, this.buildID, num1, out this.upgradePanelData[this.upgradeDataIdx].value);
      if (!resStr)
        this.m_bGeneralConform_update = false;
      this.upgradePanelData[this.upgradeDataIdx].bConform = resStr;
      ++this.upgradeDataIdx;
    }
    if (levelRequestData.RequestIron > 0U)
    {
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 3;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 4;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 1;
      bool resStr = this.GetResStr(ResourceType.Steel, out this.upgradePanelData[this.upgradeDataIdx].text, this.buildID, num1, out this.upgradePanelData[this.upgradeDataIdx].value);
      if (!resStr)
        this.m_bGeneralConform_update = false;
      this.upgradePanelData[this.upgradeDataIdx].bConform = resStr;
      ++this.upgradeDataIdx;
    }
    if (levelRequestData.RequestGold > 0U)
    {
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 3;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 5;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 1;
      bool resStr = this.GetResStr(ResourceType.Money, out this.upgradePanelData[this.upgradeDataIdx].text, this.buildID, num1, out this.upgradePanelData[this.upgradeDataIdx].value);
      if (!resStr)
        this.m_bGeneralConform_update = false;
      this.upgradePanelData[this.upgradeDataIdx].bConform = resStr;
      ++this.upgradeDataIdx;
    }
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.totalUpgradeCount; ++index)
      _DataHeight.Add(59f);
    if (this.upgradeScrollPanel.m_PanelObjects == null)
    {
      this.upgradeScrollPanel.IntiScrollPanel(456f, 0.0f, 0.0f, _DataHeight, 10, (IUpDateScrollPanel) this);
      this.upgradeScrollPanel.GoTo(this.GM.m_BuildingTopIdx, this.GM.m_BuildingPosY);
      this.ClearScrollPostionSave();
    }
    else
      this.upgradeScrollPanel.AddNewDataHeight(_DataHeight, false);
  }

  private void SetUpgradePanel_Tech()
  {
    this.m_bSpecialConform = true;
    this.m_bGeneralConform = true;
    byte num = (byte) Mathf.Clamp((int) this.techLv + 1, 1, (int) this.techLvMax);
    TechLevelTbl Data1;
    bool techLevelupData = DataManager.Instance.GetTechLevelupData(out Data1, (ushort) this.techID, num);
    TechLevelExTbl Data2;
    bool techLevelupDataEx = DataManager.Instance.GetTechLevelupDataEx(out Data2, (ushort) this.techID, num);
    this.totalUpgradeCount = 0;
    this.upgradeDataIdx = 0;
    if (!techLevelupData)
      return;
    if (DataManager.Instance.queueBarData[1].bActive)
      ++this.totalUpgradeCount;
    if (Data1.ResearchLevel > (byte) 0)
      ++this.totalUpgradeCount;
    if (Data1.RequireTechID1 != (ushort) 0)
      ++this.totalUpgradeCount;
    if (Data1.RequireTechID2 != (ushort) 0)
      ++this.totalUpgradeCount;
    if (Data1.RequireTechID3 != (ushort) 0)
      ++this.totalUpgradeCount;
    if (Data1.RequireTechID4 != (ushort) 0)
      ++this.totalUpgradeCount;
    if (Data1.Grain != 0U)
      ++this.totalUpgradeCount;
    if (Data1.Rock != 0U)
      ++this.totalUpgradeCount;
    if (Data1.Wood != 0U)
      ++this.totalUpgradeCount;
    if (Data1.Iron != 0U)
      ++this.totalUpgradeCount;
    if (Data1.Gold != 0U)
      ++this.totalUpgradeCount;
    if (techLevelupDataEx)
      ++this.totalUpgradeCount;
    for (int index = 0; index < this.upgradePanelData.Count; ++index)
      this.GM.upgradePanelDataPool.despawn(this.upgradePanelData[index]);
    this.upgradePanelData.Clear();
    for (int index = 0; index < this.totalUpgradeCount; ++index)
      this.upgradePanelData.Add(this.GM.upgradePanelDataPool.spawn());
    this.sb.Length = 0;
    if (DataManager.Instance.queueBarData[1].bActive)
    {
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 2;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 6;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 0;
      this.m_BuildStartTime = DataManager.Instance.queueBarData[1].StartTime;
      this.m_BuildEndTime = this.m_BuildStartTime + (long) DataManager.Instance.queueBarData[1].TotalTime;
      this.sb.Length = 0;
      this.sb.AppendFormat("<color=#F63954>{0}</color>", (object) DataManager.Instance.mStringTable.GetStringByID(5017U));
      this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
      this.m_bGeneralConform = false;
      this.upgradePanelData[this.upgradeDataIdx].bConform = this.m_bGeneralConform;
      ++this.upgradeDataIdx;
    }
    else
    {
      this.m_BuildStartTime = 0L;
      this.m_BuildEndTime = 0L;
    }
    this.upgradePanelData[this.upgradeDataIdx].type = (byte) 2;
    this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 0;
    this.upgradePanelData[this.upgradeDataIdx].buildID = (ushort) 10;
    this.upgradePanelData[this.upgradeDataIdx].techID = (ushort) 0;
    this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 4;
    ushort level = (ushort) GUIManager.Instance.BuildingData.GetBuildData((ushort) 10, (ushort) 0).Level;
    this.sb.Length = 0;
    ushort nameId = DataManager.Instance.BuildsTypeData.GetRecordByKey((ushort) 10).NameID;
    if ((int) level >= (int) Data1.ResearchLevel)
    {
      this.upgradePanelData[this.upgradeDataIdx].bConform = true;
      this.sb.AppendFormat("{0} : {1}{2} ", (object) DataManager.Instance.mStringTable.GetStringByID((uint) nameId), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) Data1.ResearchLevel);
    }
    else
    {
      this.m_bSpecialConform = false;
      this.upgradePanelData[this.upgradeDataIdx].bConform = false;
      this.sb.AppendFormat("<color=#F63954>{0}: {1}{2}</color> ", (object) DataManager.Instance.mStringTable.GetStringByID((uint) nameId), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) Data1.ResearchLevel);
    }
    this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
    ++this.upgradeDataIdx;
    TechDataTbl recordByKey;
    if (Data1.RequireTechID1 != (ushort) 0)
    {
      ushort techLevel = (ushort) DataManager.Instance.GetTechLevel(Data1.RequireTechID1);
      this.sb.Length = 0;
      recordByKey = DataManager.Instance.TechData.GetRecordByKey(Data1.RequireTechID1);
      ushort techName = recordByKey.TechName;
      if ((int) techLevel >= (int) Data1.RequireTechLv1)
      {
        this.sb.AppendFormat("{0} : {1}{2} ", (object) DataManager.Instance.mStringTable.GetStringByID((uint) techName), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) Data1.RequireTechLv1);
        this.upgradePanelData[this.upgradeDataIdx].bConform = true;
      }
      else
      {
        this.m_bSpecialConform = false;
        this.upgradePanelData[this.upgradeDataIdx].bConform = false;
        this.sb.AppendFormat("<color=#F63954>{0}: {1}{2}</color> ", (object) DataManager.Instance.mStringTable.GetStringByID((uint) techName), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) Data1.RequireTechLv1);
      }
      this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 2;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 7;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 4;
      this.upgradePanelData[this.upgradeDataIdx].buildID = (ushort) 0;
      this.upgradePanelData[this.upgradeDataIdx].techID = Data1.RequireTechID1;
      ++this.upgradeDataIdx;
    }
    if (Data1.RequireTechID2 != (ushort) 0)
    {
      ushort techLevel = (ushort) DataManager.Instance.GetTechLevel(Data1.RequireTechID2);
      this.sb.Length = 0;
      recordByKey = DataManager.Instance.TechData.GetRecordByKey(Data1.RequireTechID2);
      ushort techName = recordByKey.TechName;
      if ((int) techLevel >= (int) Data1.RequireTechLv2)
      {
        this.sb.AppendFormat("{0} : {1}{2} ", (object) DataManager.Instance.mStringTable.GetStringByID((uint) techName), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) Data1.RequireTechLv2);
        this.upgradePanelData[this.upgradeDataIdx].bConform = true;
      }
      else
      {
        this.m_bSpecialConform = false;
        this.upgradePanelData[this.upgradeDataIdx].bConform = false;
        this.sb.AppendFormat("<color=#F63954>{0}: {1}{2}</color> ", (object) DataManager.Instance.mStringTable.GetStringByID((uint) techName), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) Data1.RequireTechLv2);
      }
      this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 2;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 7;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 4;
      this.upgradePanelData[this.upgradeDataIdx].buildID = (ushort) 0;
      this.upgradePanelData[this.upgradeDataIdx].techID = Data1.RequireTechID2;
      ++this.upgradeDataIdx;
    }
    if (Data1.RequireTechID3 != (ushort) 0)
    {
      ushort techLevel = (ushort) DataManager.Instance.GetTechLevel(Data1.RequireTechID3);
      this.sb.Length = 0;
      recordByKey = DataManager.Instance.TechData.GetRecordByKey(Data1.RequireTechID3);
      ushort techName = recordByKey.TechName;
      if ((int) techLevel >= (int) Data1.RequireTechLv3)
      {
        this.sb.AppendFormat("{0} : {1}{2} ", (object) DataManager.Instance.mStringTable.GetStringByID((uint) techName), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) Data1.RequireTechLv3);
        this.upgradePanelData[this.upgradeDataIdx].bConform = true;
      }
      else
      {
        this.m_bSpecialConform = false;
        this.upgradePanelData[this.upgradeDataIdx].bConform = false;
        this.sb.AppendFormat("<color=#F63954>{0}: {1}{2}</color> ", (object) DataManager.Instance.mStringTable.GetStringByID((uint) techName), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) Data1.RequireTechLv3);
      }
      this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 2;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 7;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 4;
      this.upgradePanelData[this.upgradeDataIdx].buildID = (ushort) 0;
      this.upgradePanelData[this.upgradeDataIdx].techID = Data1.RequireTechID3;
      ++this.upgradeDataIdx;
    }
    if (Data1.RequireTechID4 != (ushort) 0)
    {
      ushort techLevel = (ushort) DataManager.Instance.GetTechLevel(Data1.RequireTechID4);
      this.sb.Length = 0;
      recordByKey = DataManager.Instance.TechData.GetRecordByKey(Data1.RequireTechID4);
      ushort techName = recordByKey.TechName;
      if ((int) techLevel >= (int) Data1.RequireTechLv4)
      {
        this.upgradePanelData[this.upgradeDataIdx].bConform = true;
        this.sb.AppendFormat("{0} : {1}{2} ", (object) DataManager.Instance.mStringTable.GetStringByID((uint) techName), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) Data1.RequireTechLv4);
      }
      else
      {
        this.m_bSpecialConform = false;
        this.upgradePanelData[this.upgradeDataIdx].bConform = false;
        this.sb.AppendFormat("<color=#F63954>{0}: {1}{2}</color> ", (object) DataManager.Instance.mStringTable.GetStringByID((uint) techName), (object) DataManager.Instance.mStringTable.GetStringByID(32U), (object) Data1.RequireTechLv4);
      }
      this.upgradePanelData[this.upgradeDataIdx].text = this.sb.ToString();
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 2;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 7;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 4;
      this.upgradePanelData[this.upgradeDataIdx].buildID = (ushort) 0;
      this.upgradePanelData[this.upgradeDataIdx].techID = Data1.RequireTechID4;
      ++this.upgradeDataIdx;
    }
    if (!DataManager.Instance.CheckTechKind((ushort) DataManager.Instance.TechData.GetRecordByKey((ushort) this.techID).Kind))
      this.m_bSpecialConform = false;
    if (techLevelupDataEx && Data2.PetResource > 0U)
    {
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 3;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 8;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 1;
      bool petResourceStr = this.GetPetResourceStr(out this.upgradePanelData[this.upgradeDataIdx].text, this.techID, num, out this.upgradePanelData[this.upgradeDataIdx].value);
      if (!petResourceStr)
        this.m_bGeneralConform_update = false;
      this.upgradePanelData[this.upgradeDataIdx].bConform = petResourceStr;
      ++this.upgradeDataIdx;
    }
    if (Data1.Grain > 0U)
    {
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 3;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 1;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 1;
      bool resStrTech = this.GetResStr_Tech(ResourceType.Grain, out this.upgradePanelData[this.upgradeDataIdx].text, this.techID, num, out this.upgradePanelData[this.upgradeDataIdx].value);
      if (!resStrTech)
        this.m_bGeneralConform_update = false;
      this.upgradePanelData[this.upgradeDataIdx].bConform = resStrTech;
      ++this.upgradeDataIdx;
    }
    if (Data1.Rock > 0U)
    {
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 3;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 2;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 1;
      bool resStrTech = this.GetResStr_Tech(ResourceType.Rock, out this.upgradePanelData[this.upgradeDataIdx].text, this.techID, num, out this.upgradePanelData[this.upgradeDataIdx].value);
      if (!resStrTech)
        this.m_bGeneralConform_update = false;
      this.upgradePanelData[this.upgradeDataIdx].bConform = resStrTech;
      ++this.upgradeDataIdx;
    }
    if (Data1.Wood > 0U)
    {
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 3;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 3;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 1;
      bool resStrTech = this.GetResStr_Tech(ResourceType.Wood, out this.upgradePanelData[this.upgradeDataIdx].text, this.techID, num, out this.upgradePanelData[this.upgradeDataIdx].value);
      if (!resStrTech)
        this.m_bGeneralConform_update = false;
      this.upgradePanelData[this.upgradeDataIdx].bConform = resStrTech;
      ++this.upgradeDataIdx;
    }
    if (Data1.Iron > 0U)
    {
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 3;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 4;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 1;
      bool resStrTech = this.GetResStr_Tech(ResourceType.Steel, out this.upgradePanelData[this.upgradeDataIdx].text, this.techID, num, out this.upgradePanelData[this.upgradeDataIdx].value);
      if (!resStrTech)
        this.m_bGeneralConform_update = false;
      this.upgradePanelData[this.upgradeDataIdx].bConform = resStrTech;
      ++this.upgradeDataIdx;
    }
    if (Data1.Gold > 0U)
    {
      this.upgradePanelData[this.upgradeDataIdx].type = (byte) 3;
      this.upgradePanelData[this.upgradeDataIdx].iconType = (byte) 5;
      this.upgradePanelData[this.upgradeDataIdx].btnType = (byte) 1;
      bool resStrTech = this.GetResStr_Tech(ResourceType.Money, out this.upgradePanelData[this.upgradeDataIdx].text, this.techID, num, out this.upgradePanelData[this.upgradeDataIdx].value);
      if (!resStrTech)
        this.m_bGeneralConform_update = false;
      this.upgradePanelData[this.upgradeDataIdx].bConform = resStrTech;
      ++this.upgradeDataIdx;
    }
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.totalUpgradeCount; ++index)
      _DataHeight.Add(59f);
    if (this.upgradeScrollPanel.m_PanelObjects == null)
    {
      this.upgradeScrollPanel.IntiScrollPanel(456f, 0.0f, 0.0f, _DataHeight, 10, (IUpDateScrollPanel) this);
      this.upgradeScrollPanel.GoTo(this.GM.m_BuildingTopIdx, this.GM.m_BuildingPosY);
      this.ClearScrollPostionSave();
    }
    else
      this.upgradeScrollPanel.AddNewDataHeight(_DataHeight, false);
  }

  private void SetNormalInfoPanel()
  {
    UIText component = this.normallInfoPanel.GetChild(0).GetComponent<UIText>();
    component.font = GUIManager.Instance.GetTTFFont();
    BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey((ushort) this.buildID);
    component.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.UIExplain);
    this.m_SetNormalInfoPanelText = component;
  }

  private void SetUpgradeInfoPanel()
  {
    this.upgradeEffectIdx = 0;
    BuildLevelRequest buildLevelRequest1 = this.buildLv <= (byte) 0 ? new BuildLevelRequest() : GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort) this.buildID, this.buildLv);
    BuildLevelRequest buildLevelRequest2 = (int) this.buildLv >= (int) this.buildLvMAx ? new BuildLevelRequest() : GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort) this.buildID, (byte) ((uint) this.buildLv + 1U));
    this.totalUpgradeEffectCount = 0;
    if ((int) buildLevelRequest2.Strength != (int) buildLevelRequest1.Strength)
      ++this.totalUpgradeEffectCount;
    if (this.buildID == (byte) 13 || (int) buildLevelRequest2.Value1 != (int) buildLevelRequest1.Value1 || buildLevelRequest2.Effect1 > (ushort) 1000)
      ++this.totalUpgradeEffectCount;
    if (this.buildID != (byte) 13)
    {
      if ((int) buildLevelRequest2.Value2 != (int) buildLevelRequest1.Value2 || buildLevelRequest2.Effect2 > (ushort) 1000)
        ++this.totalUpgradeEffectCount;
      if ((int) buildLevelRequest2.Value3 != (int) buildLevelRequest1.Value3 || buildLevelRequest2.Effect3 > (ushort) 1000)
        ++this.totalUpgradeEffectCount;
      if ((int) buildLevelRequest2.Value4 != (int) buildLevelRequest1.Value4 || buildLevelRequest2.Effect4 > (ushort) 1000)
        ++this.totalUpgradeEffectCount;
      if (buildLevelRequest2.Value5 != (ushort) 0 && buildLevelRequest2.Value5 > (ushort) 1000)
        ++this.totalUpgradeEffectCount;
      if ((int) buildLevelRequest2.ExtValue1 != (int) buildLevelRequest1.ExtValue1 || buildLevelRequest2.ExtEffect1 > (ushort) 1000)
        ++this.totalUpgradeEffectCount;
      if ((int) buildLevelRequest2.ExtValue2 != (int) buildLevelRequest1.ExtValue2 || buildLevelRequest2.ExtEffect2 > (ushort) 1000)
        ++this.totalUpgradeEffectCount;
    }
    for (int index = 0; index < this.upgradeEffectData.Count; ++index)
      this.GM.upgradeEffectDataPool.despawn(this.upgradeEffectData[index]);
    this.upgradeEffectData.Clear();
    for (int index = 0; index < this.totalUpgradeEffectCount; ++index)
      this.upgradeEffectData.Add(this.GM.upgradeEffectDataPool.spawn());
    if ((int) buildLevelRequest2.Strength != (int) buildLevelRequest1.Strength)
    {
      this.sb.Length = 0;
      uint num = buildLevelRequest2.Strength - buildLevelRequest1.Strength;
      this.sb.AppendFormat("{0}{1:N0}", (object) DataManager.Instance.mStringTable.GetStringByID(4020U), (object) num);
      this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
      this.upgradeEffectData[this.upgradeEffectIdx].iconType = (ushort) 1;
      ++this.upgradeEffectIdx;
    }
    if (this.buildID == (byte) 13)
    {
      this.sb.Length = 0;
      this.sb.AppendFormat("{0}", (object) DataManager.Instance.mStringTable.GetStringByID(5766U));
      this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
      this.upgradeEffectData[this.upgradeEffectIdx].iconType = (ushort) 269;
      ++this.upgradeEffectIdx;
    }
    else
    {
      if ((int) buildLevelRequest2.Value1 != (int) buildLevelRequest1.Value1 || buildLevelRequest1.Effect1 > (ushort) 1000)
      {
        this.sb.Length = 0;
        Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(buildLevelRequest2.Effect1);
        uint mValue = buildLevelRequest2.Value1 - buildLevelRequest1.Value1;
        if (this.buildID == (byte) 18)
        {
          uint num1 = mValue / 60U;
          uint num2 = num1 % 60U;
          uint num3 = num1 / 60U % 24U;
          uint num4 = num1 / 1440U;
          GameConstants.GetEffectValue(this.sb, buildLevelRequest2.Effect1, 0U, (byte) 0, 0.0f, 0L);
          if (num4 > 0U)
          {
            if (num3 > 0U)
              this.sb.AppendFormat("{0}d{1}h", (object) num4, (object) num3);
            else
              this.sb.AppendFormat("{0}h", (object) num3);
          }
          else if (num3 > 0U)
            this.sb.AppendFormat("{0}h", (object) num3);
          else if (num2 > 0U)
            this.sb.AppendFormat("{0}m", (object) num2);
        }
        else
          GameConstants.GetEffectValue(this.sb, buildLevelRequest2.Effect1, mValue, (byte) 7, 0.0f, 0L);
        this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
        this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
        ++this.upgradeEffectIdx;
      }
      if ((int) buildLevelRequest2.Value2 != (int) buildLevelRequest1.Value2 || buildLevelRequest2.Effect2 > (ushort) 1000)
      {
        this.sb.Length = 0;
        Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(buildLevelRequest2.Effect2);
        uint mValue = 0;
        long mValue2 = (long) buildLevelRequest2.Value2 - (long) buildLevelRequest1.Value2;
        GameConstants.GetEffectValue(this.sb, buildLevelRequest2.Effect2, mValue, (byte) 7, 0.0f, mValue2);
        this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
        this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
        ++this.upgradeEffectIdx;
      }
      if ((int) buildLevelRequest2.Value3 != (int) buildLevelRequest1.Value3 || buildLevelRequest2.Effect3 > (ushort) 1000)
      {
        this.sb.Length = 0;
        Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(buildLevelRequest2.Effect3);
        uint mValue = (uint) buildLevelRequest2.Value3 - (uint) buildLevelRequest1.Value3;
        GameConstants.GetEffectValue(this.sb, buildLevelRequest2.Effect3, mValue, (byte) 7, 0.0f, 0L);
        this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
        this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
        ++this.upgradeEffectIdx;
      }
      if ((int) buildLevelRequest2.Value4 != (int) buildLevelRequest1.Value4 || buildLevelRequest2.Effect4 > (ushort) 1000)
      {
        this.sb.Length = 0;
        Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(buildLevelRequest2.Effect4);
        uint mValue = (uint) buildLevelRequest2.Value4 - (uint) buildLevelRequest1.Value4;
        GameConstants.GetEffectValue(this.sb, buildLevelRequest2.Effect4, mValue, (byte) 7, 0.0f, 0L);
        this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
        this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
        ++this.upgradeEffectIdx;
      }
      if (buildLevelRequest2.Value5 != (ushort) 0 && buildLevelRequest2.Value5 > (ushort) 1000)
      {
        this.sb.Length = 0;
        Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(buildLevelRequest2.Value5);
        uint num = (uint) buildLevelRequest2.Value5 - (uint) buildLevelRequest1.Value5;
        GameConstants.GetEffectValue(this.sb, buildLevelRequest2.Value5, 0U, (byte) 0, 0.0f, 0L);
        this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
        this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
        ++this.upgradeEffectIdx;
      }
      if ((int) buildLevelRequest2.ExtValue1 != (int) buildLevelRequest1.ExtValue1 || buildLevelRequest2.ExtEffect1 > (ushort) 1000)
      {
        this.sb.Length = 0;
        Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(buildLevelRequest2.ExtEffect1);
        uint mValue = buildLevelRequest2.ExtValue1 - buildLevelRequest1.ExtValue1;
        GameConstants.GetEffectValue(this.sb, buildLevelRequest2.ExtEffect1, mValue, (byte) 7, 0.0f, 0L);
        this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
        this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
        ++this.upgradeEffectIdx;
      }
      if ((int) buildLevelRequest2.ExtValue2 != (int) buildLevelRequest1.ExtValue2 || buildLevelRequest2.ExtEffect2 > (ushort) 1000)
      {
        this.sb.Length = 0;
        Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(buildLevelRequest2.ExtEffect2);
        uint mValue = (uint) buildLevelRequest2.ExtValue2 - (uint) buildLevelRequest1.ExtValue2;
        GameConstants.GetEffectValue(this.sb, buildLevelRequest2.ExtEffect2, mValue, (byte) 7, 0.0f, 0L);
        this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
        this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
        ++this.upgradeEffectIdx;
      }
    }
    List<float> _DataHeight = new List<float>();
    this.m_UpgradeInfoItemTexts = new UIText[this.m_MaxUpgradeInfoItemCount];
    this.m_UpgradeInfoItemImages = new Image[this.m_MaxUpgradeInfoItemCount];
    for (int index = 0; index < this.totalUpgradeEffectCount; ++index)
      _DataHeight.Add(39f);
    if (this.infoScrollPanel.m_PanelObjects == null)
      this.infoScrollPanel.IntiScrollPanel(142.5f, 0.0f, 15f, _DataHeight, this.m_MaxUpgradeInfoItemCount, (IUpDateScrollPanel) this);
    else
      this.infoScrollPanel.AddNewDataHeight(_DataHeight);
  }

  private void SetUpgradeInfoPanel_Tech()
  {
    TechLevelTbl Data1;
    if (this.techLv > (byte) 0)
      DataManager.Instance.GetTechLevelupData(out Data1, (ushort) this.techID, this.techLv);
    else
      Data1 = new TechLevelTbl();
    TechLevelTbl Data2;
    if ((int) this.techLv < (int) this.techLvMax)
      DataManager.Instance.GetTechLevelupData(out Data2, (ushort) this.techID, (byte) ((uint) this.techLv + 1U));
    else
      Data2 = new TechLevelTbl();
    this.totalUpgradeEffectCount = 1;
    if ((int) Data2.EffectVal != (int) Data1.EffectVal || Data2.Effect > (ushort) 1000)
      ++this.totalUpgradeEffectCount;
    for (int index = 0; index < this.upgradeEffectData.Count; ++index)
      this.GM.upgradeEffectDataPool.despawn(this.upgradeEffectData[index]);
    this.upgradeEffectData.Clear();
    for (int index = 0; index < this.totalUpgradeEffectCount; ++index)
      this.upgradeEffectData.Add(this.GM.upgradeEffectDataPool.spawn());
    this.upgradeEffectIdx = 0;
    if ((int) Data2.Strength != (int) Data1.Strength)
    {
      this.sb.Length = 0;
      this.sb.AppendFormat("{0}{1:N0}", (object) DataManager.Instance.mStringTable.GetStringByID(4020U), (object) (uint) ((int) Data2.Strength - (int) Data1.Strength));
      this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
      this.upgradeEffectData[this.upgradeEffectIdx].iconType = (ushort) 1;
      ++this.upgradeEffectIdx;
    }
    if (this.techID == (byte) 43)
    {
      this.sb.Length = 0;
      this.sb.AppendFormat("{0}", (object) DataManager.Instance.mStringTable.GetStringByID(5033U));
      this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
      this.upgradeEffectData[this.upgradeEffectIdx].iconType = DataManager.Instance.EffectData.GetRecordByKey(Data2.Effect).ID;
      ++this.upgradeEffectIdx;
    }
    else if ((int) Data2.EffectVal != (int) Data1.EffectVal || Data2.Effect > (ushort) 1000)
    {
      this.sb.Length = 0;
      Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(Data2.Effect);
      uint num = Data2.EffectVal - Data1.EffectVal;
      GameConstants.GetEffectValue(this.sb, Data2.Effect, num, (byte) 7, (float) num, 0L);
      this.upgradeEffectData[this.upgradeEffectIdx].text = this.sb.ToString();
      this.upgradeEffectData[this.upgradeEffectIdx].iconType = recordByKey.ID;
      ++this.upgradeEffectIdx;
    }
    List<float> _DataHeight = new List<float>();
    this.m_UpgradeInfoItemTexts = new UIText[this.m_MaxUpgradeInfoItemCount];
    this.m_UpgradeInfoItemImages = new Image[this.m_MaxUpgradeInfoItemCount];
    for (int index = 0; index < this.totalUpgradeEffectCount; ++index)
      _DataHeight.Add(39f);
    if (this.infoScrollPanel.m_PanelObjects == null)
      this.infoScrollPanel.IntiScrollPanel(142.5f, 0.0f, 0.0f, _DataHeight, this.m_MaxUpgradeInfoItemCount, (IUpDateScrollPanel) this);
    else
      this.infoScrollPanel.AddNewDataHeight(_DataHeight);
  }

  public void SetTime(int dd, int hh, int mm, int ss, CString _tempString, UIText text)
  {
    if (dd >= 0 && hh >= 0 && mm >= 0 && ss >= 0)
    {
      _tempString.ClearString();
      if (dd > 0)
      {
        _tempString.IntToFormat((long) dd);
        _tempString.AppendFormat("{0}d ");
      }
      _tempString.IntToFormat((long) hh, 2);
      _tempString.IntToFormat((long) mm, 2);
      _tempString.IntToFormat((long) ss, 2);
      _tempString.AppendFormat("{0}:{1}:{2}");
    }
    text.text = _tempString.ToString();
    text.SetAllDirty();
    text.cachedTextGenerator.Invalidate();
  }

  private uint GetCostCrystal()
  {
    uint num = 0;
    for (int Type = 0; Type < 5; ++Type)
      num += DataManager.Instance.GetResourceExchange((PriceListType) Type, this.m_CostCrystal[Type]);
    return num + DataManager.Instance.GetResourceExchange(PriceListType.Time, this.m_CostCrystal[6]) + this.m_CostCrystal[7] + DataManager.Instance.GetResourceExchange(PriceListType.PetResource, this.m_CostCrystal[8]);
  }

  private void SetUpdateTimeText()
  {
    this.m_CostCrystal[5] = 0U;
    if (this.bIsTechWindow)
    {
      TechLevelTbl Data;
      DataManager.Instance.GetTechLevelupData(out Data, (ushort) this.techID, (byte) ((uint) this.techLv + 1U));
      this.m_CostCrystal[5] = Data.LevelupTime;
    }
    else
      this.m_CostCrystal[5] = GUIManager.Instance.BuildingData.GetBuildLevelRequestData((ushort) this.buildID, (byte) ((uint) this.buildLv + 1U)).BuildTime;
    if (this.m_CostCrystal[5] < 0U)
      return;
    this.SetTime((int) this.m_CostCrystal[5] / 86400, (int) (this.m_CostCrystal[5] / 3600U) % 24, (int) (this.m_CostCrystal[5] / 60U) % 60, (int) this.m_CostCrystal[5] % 60, this.tempString, this.updateTimeText1);
    uint effectBaseVal1;
    uint effectBaseVal2;
    if (this.bIsTechWindow)
    {
      effectBaseVal1 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESEARCH_SPEED);
      effectBaseVal2 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESEARCH_SPEED_DEBUFF);
    }
    else
    {
      effectBaseVal1 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_CONSTRUCTION_SPEED);
      effectBaseVal2 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_CONSTRUCTION_SPEED_DEBUFF);
    }
    long num1;
    if (effectBaseVal1 >= effectBaseVal2)
    {
      uint num2 = effectBaseVal1 - effectBaseVal2;
      num1 = (long) this.m_CostCrystal[5] * 10000L / ((long) num2 + 10000L) + (long) Mathf.Clamp((int) ((long) this.m_CostCrystal[5] * 10000L % ((long) num2 + 10000L)), 0, 1);
    }
    else
    {
      uint num3 = effectBaseVal2 - effectBaseVal1;
      if (num3 > 9900U)
        num3 = 9900U;
      num1 = (long) this.m_CostCrystal[5] * 10000L / (10000L - (long) num3) + (long) Mathf.Clamp((int) ((long) this.m_CostCrystal[5] * 10000L % (10000L - (long) num3)), 0, 1);
    }
    this.m_CostCrystal[6] = (uint) num1;
    int ss = (int) num1 % 60;
    int mm = (int) (num1 / 60L) % 60;
    int hh = (int) (num1 / 3600L) % 24;
    this.SetTime((int) num1 / 86400, hh, mm, ss, this.tempString3, this.updateTimeText2);
  }

  private void SetFuncBtnType()
  {
    this.backOutBtnText.fontSize = 19;
    this.backOutBtnText.resizeTextMaxSize = 19;
    this.backOutBtnTextRt.anchoredPosition = new Vector2(-2f, -30f);
    ((Graphic) this.backOutBtnText).color = new Color(1f, 0.968f, 0.6f);
    this.backOutBtn.interactable = true;
    this.backOutBtn.ForTextChange(e_BtnType.e_Normal);
    this.backOutBtn.m_BtnID2 = 200;
    ((Component) this.backOutBtnMoneyText).gameObject.SetActive(false);
    ((Component) this.backOutBtn).gameObject.SetActive(true);
    ((Behaviour) this.backOutBtnImage).enabled = true;
    ((Behaviour) this.backOutBtnText).enabled = true;
    e_FuncBtnType backOutBtnType = this.backOutBtnType;
    switch (backOutBtnType)
    {
      case e_FuncBtnType.Cancel:
      case e_FuncBtnType.Cancel_BackOut:
        this.backOutBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3827U);
        this.backOutBtnImage.sprite = this.btnSpArray.m_Sprites[0];
        ((MaskableGraphic) this.backOutBtnImage).material = this.uiMat;
        this.backOutBtnImage.SetNativeSize();
        this.backOutBtnBgImage.sprite = this.btnBGSpArray.m_Sprites[0];
        this.backOutBtnImageRt.anchoredPosition = new Vector2(15f, -11f);
        break;
      case e_FuncBtnType.BackOut:
        this.backOutBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3828U);
        this.backOutBtnImage.sprite = this.btnSpArray.m_Sprites[1];
        ((MaskableGraphic) this.backOutBtnImage).material = this.uiMat;
        this.backOutBtnImage.SetNativeSize();
        this.backOutBtnBgImage.sprite = this.btnBGSpArray.m_Sprites[0];
        this.backOutBtnImageRt.anchoredPosition = new Vector2(15f, -2f);
        BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey((ushort) this.buildID);
        if (recordByKey.Kind == (byte) 3 || recordByKey.Kind == (byte) 4 || recordByKey.Kind == (byte) 5)
          ((Component) this.backOutBtn).gameObject.SetActive(false);
        if (this.buildID == (byte) 7)
        {
          int length = DataManager.Instance.mSoldier_Hospital.Length;
          for (int index = 0; index < length; ++index)
          {
            if (DataManager.Instance.mSoldier_Hospital[index] != 0U)
            {
              this.backOutBtn.m_BtnID2 = 101;
              break;
            }
          }
        }
        if (this.buildID == (byte) 23)
        {
          int length = PetManager.Instance.m_PetTrainingData.Length;
          for (int index = 0; index < length; ++index)
          {
            if (PetManager.Instance.m_PetTrainingData[index].m_State == PetManager.EPetTrainDataState.Training || PetManager.Instance.m_PetTrainingData[index].m_State == PetManager.EPetTrainDataState.CanReceive)
            {
              this.backOutBtn.m_BtnID2 = 102;
              break;
            }
          }
          break;
        }
        break;
      default:
        switch (backOutBtnType - 9)
        {
          case e_FuncBtnType.Cancel:
            this.backOutBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3822U);
            this.backOutBtnImage.sprite = this.btnSpArray.m_Sprites[4];
            ((MaskableGraphic) this.backOutBtnImage).material = this.uiMat;
            this.backOutBtnImage.SetNativeSize();
            this.backOutBtnBgImage.sprite = this.btnBGSpArray.m_Sprites[3];
            this.backOutBtnImageRt.anchoredPosition = new Vector2(6f, -3f);
            this.backOutBtnTextRt.anchoredPosition = new Vector2(-2f, -30f);
            ((Component) this.backOutBtnMoneyText).gameObject.SetActive(true);
            uint costCrystal1 = this.GetCostCrystal();
            this.sb.Length = 0;
            this.sb.AppendFormat("{0:N0}", (object) costCrystal1);
            this.backOutBtnMoneyText.text = this.sb.ToString();
            if (!this.m_bSpecialConform)
            {
              this.backOutBtn.ForTextChange(e_BtnType.e_ChangeText);
              this.backOutBtn.m_BtnID2 = 100;
              break;
            }
            break;
          case e_FuncBtnType.Cancel_BackOut:
            this.backOutBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3820U);
            this.backOutBtnImage.sprite = this.btnSpArray.m_Sprites[4];
            ((MaskableGraphic) this.backOutBtnImage).material = this.uiMat;
            this.backOutBtnImage.SetNativeSize();
            this.backOutBtnBgImage.sprite = this.btnBGSpArray.m_Sprites[3];
            this.backOutBtnImageRt.anchoredPosition = new Vector2(6f, -3f);
            this.backOutBtnTextRt.anchoredPosition = new Vector2(-2f, -30f);
            ((Component) this.backOutBtnMoneyText).gameObject.SetActive(true);
            uint costCrystal2 = this.GetCostCrystal();
            this.sb.Length = 0;
            this.sb.AppendFormat("{0:N0}", (object) costCrystal2);
            this.backOutBtnMoneyText.text = this.sb.ToString();
            if (!this.m_bSpecialConform)
            {
              this.backOutBtn.ForTextChange(e_BtnType.e_ChangeText);
              this.backOutBtn.m_BtnID2 = 100;
              break;
            }
            break;
          case e_FuncBtnType.Help:
            this.backOutBtnText.text = DataManager.Instance.mStringTable.GetStringByID(5022U);
            this.backOutBtnImage.sprite = this.btnSpArray.m_Sprites[4];
            ((MaskableGraphic) this.backOutBtnImage).material = this.uiMat;
            this.backOutBtnImage.SetNativeSize();
            this.backOutBtnBgImage.sprite = this.btnBGSpArray.m_Sprites[3];
            this.backOutBtnImageRt.anchoredPosition = new Vector2(6f, -3f);
            this.backOutBtnTextRt.anchoredPosition = new Vector2(-2f, -30f);
            ((Component) this.backOutBtnMoneyText).gameObject.SetActive(true);
            uint costCrystal3 = this.GetCostCrystal();
            this.sb.Length = 0;
            this.sb.AppendFormat("{0:N0}", (object) costCrystal3);
            this.backOutBtnMoneyText.text = this.sb.ToString();
            if (!this.m_bSpecialConform)
            {
              this.backOutBtn.ForTextChange(e_BtnType.e_ChangeText);
              this.backOutBtn.m_BtnID2 = 100;
              break;
            }
            break;
          case e_FuncBtnType.BackOut:
            this.backOutBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3827U);
            this.backOutBtnImage.sprite = this.btnSpArray.m_Sprites[11];
            ((MaskableGraphic) this.backOutBtnImage).material = this.uiMat;
            this.backOutBtnImage.SetNativeSize();
            this.backOutBtnBgImage.sprite = this.btnBGSpArray.m_Sprites[0];
            this.backOutBtnImageRt.anchoredPosition = new Vector2(30f, -14f);
            break;
        }
        break;
    }
    ((Component) this.upgradeBtn).gameObject.SetActive(true);
    this.maxLvImage.gameObject.SetActive(false);
    this.upgradeBtn.m_BtnID2 = 200;
    this.upgradeBtn.ForTextChange(e_BtnType.e_Normal);
    if (this.GM.IsArabic)
      ((Transform) this.upgradeBtnImageRt).localScale = new Vector3(1f, 1f, 1f);
    switch (this.upgradeBtnType)
    {
      case e_FuncBtnType.Free:
        this.upgradeBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3826U);
        this.upgradeBtnImage.sprite = this.btnSpArray.m_Sprites[6];
        this.upgradeBtnImage.SetNativeSize();
        this.upgradeBtnBGImage.sprite = this.btnBGSpArray.m_Sprites[5];
        if (this.GM.IsArabic)
        {
          ((Transform) this.upgradeBtnImageRt).localScale = new Vector3(-1f, 1f, 1f);
          this.upgradeBtnImageRt.anchoredPosition = new Vector2(90f, -2f);
          break;
        }
        this.upgradeBtnImageRt.anchoredPosition = new Vector2(20f, -2f);
        break;
      case e_FuncBtnType.Speed:
        this.upgradeBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3825U);
        this.upgradeBtnImage.sprite = this.btnSpArray.m_Sprites[2];
        this.upgradeBtnImage.SetNativeSize();
        this.upgradeBtnBGImage.sprite = this.btnBGSpArray.m_Sprites[1];
        if (this.GM.IsArabic)
        {
          ((Transform) this.upgradeBtnImageRt).localScale = new Vector3(-1f, 1f, 1f);
          this.upgradeBtnImageRt.anchoredPosition = new Vector2(85f, -11f);
          break;
        }
        this.upgradeBtnImageRt.anchoredPosition = new Vector2(26f, -11f);
        break;
      case e_FuncBtnType.Help:
        this.upgradeBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3824U);
        this.upgradeBtnImage.sprite = this.btnSpArray.m_Sprites[5];
        this.upgradeBtnImage.SetNativeSize();
        this.upgradeBtnBGImage.sprite = this.btnBGSpArray.m_Sprites[4];
        this.upgradeBtnImageRt.anchoredPosition = new Vector2(16f, -11f);
        break;
      case e_FuncBtnType.Disable:
        ((Component) this.upgradeBtn).gameObject.SetActive(false);
        break;
      case e_FuncBtnType.MaxLv:
        this.upgradeBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3831U);
        this.maxLvImage.gameObject.SetActive(true);
        ((Component) this.upgradeBtn).gameObject.SetActive(false);
        break;
      case e_FuncBtnType.Upgrade:
        this.upgradeBtnImage.sprite = this.btnSpArray.m_Sprites[3];
        this.upgradeBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3823U);
        this.upgradeBtnImage.SetNativeSize();
        this.upgradeBtnBGImage.sprite = this.btnBGSpArray.m_Sprites[2];
        this.upgradeBtnImageRt.anchoredPosition = new Vector2(15f, -8f);
        if (this.buildType != e_BuildType.Upgrade || this.m_bGeneralConform && this.m_bSpecialConform && this.m_bGeneralConform_update)
          break;
        this.upgradeBtn.m_BtnID2 = 100;
        this.upgradeBtn.ForTextChange(e_BtnType.e_ChangeText);
        break;
      case e_FuncBtnType.Build:
        this.upgradeBtnImage.sprite = this.btnSpArray.m_Sprites[3];
        this.upgradeBtnText.text = DataManager.Instance.mStringTable.GetStringByID(3821U);
        this.upgradeBtnImage.SetNativeSize();
        this.upgradeBtnBGImage.sprite = this.btnBGSpArray.m_Sprites[2];
        this.upgradeBtnImageRt.anchoredPosition = new Vector2(15f, -8f);
        if (this.buildType != e_BuildType.Upgrade || this.m_bGeneralConform && this.m_bSpecialConform && this.m_bGeneralConform_update)
          break;
        this.upgradeBtn.ForTextChange(e_BtnType.e_ChangeText);
        this.upgradeBtn.m_BtnID2 = 100;
        break;
      case e_FuncBtnType.Research:
        this.upgradeBtnImage.sprite = this.btnSpArray.m_Sprites[10];
        this.upgradeBtnText.text = DataManager.Instance.mStringTable.GetStringByID(5021U);
        this.upgradeBtnImage.SetNativeSize();
        this.upgradeBtnBGImage.sprite = this.btnBGSpArray.m_Sprites[2];
        this.upgradeBtnImageRt.anchoredPosition = new Vector2(30f, -20f);
        if (this.buildType != e_BuildType.Upgrade_Tech || this.m_bGeneralConform && this.m_bSpecialConform && this.m_bGeneralConform_update)
          break;
        this.upgradeBtn.m_BtnID2 = 100;
        this.upgradeBtn.ForTextChange(e_BtnType.e_ChangeText);
        break;
    }
  }

  private void SetBuildType(e_BuildType _buildType, eTimerSpriteType _SpriteType = eTimerSpriteType.Speed)
  {
    this.buildType = _buildType;
    this.SetCustomCastleBtn(this.buildType);
    switch (this.buildType)
    {
      case e_BuildType.Normal:
        this.normallInfoPanel.gameObject.SetActive(true);
        this.normalPanel.gameObject.SetActive(true);
        this.upgradePanel.gameObject.SetActive(false);
        this.infoPanel.gameObject.SetActive(false);
        this.timeBar.gameObject.SetActive(false);
        this.upgradePanelTitle.gameObject.SetActive(false);
        this.infoPanelTitle.gameObject.SetActive(false);
        this.updateTimePanel.gameObject.SetActive(false);
        if (this.buildID > (byte) 0 && this.buildID <= (byte) 7)
          this.normalPanel.gameObject.SetActive(true);
        else
          this.normalPanel.gameObject.SetActive(false);
        this.backOutBtnType = this.buildLv != (byte) 0 ? e_FuncBtnType.BackOut : e_FuncBtnType.Cancel;
        this.upgradeBtnType = (int) this.buildLvMAx != (int) this.buildLv ? e_FuncBtnType.Upgrade : e_FuncBtnType.MaxLv;
        if (this.buildID == (byte) 7)
        {
          this.normalPanel.gameObject.SetActive(false);
          this.normallInfoPanel.gameObject.SetActive(false);
          break;
        }
        break;
      case e_BuildType.Upgrade:
        this.normallInfoPanel.gameObject.SetActive(false);
        this.normalPanel.gameObject.SetActive(false);
        if ((int) this.buildLv == (int) this.buildLvMAx)
          this.upgradePanel.gameObject.SetActive(false);
        else
          this.upgradePanel.gameObject.SetActive(true);
        this.infoPanel.gameObject.SetActive(true);
        this.timeBar.gameObject.SetActive(false);
        this.upgradePanelTitle.gameObject.SetActive(true);
        this.infoPanelTitle.gameObject.SetActive(true);
        this.updateTimePanel.gameObject.SetActive(this.m_bSpecialConform);
        if ((int) this.manorID == (int) GUIManager.Instance.BuildingData.BuildingManorID && this.buildID != (byte) 0)
        {
          this.upgradeBtnType = DataManager.Instance.mPlayHelpDataType[1].Kind != (byte) 0 ? e_FuncBtnType.Speed : e_FuncBtnType.Help;
          break;
        }
        if (GUIManager.Instance.BuildingData.AllBuildsData[(int) this.manorID].BuildID == (ushort) 0)
        {
          this.upgradeBtnType = e_FuncBtnType.Build;
          this.backOutBtnType = e_FuncBtnType.AtOnce_Build;
          break;
        }
        this.upgradeBtnType = (int) this.buildLv >= (int) this.buildLvMAx ? e_FuncBtnType.MaxLv : e_FuncBtnType.Upgrade;
        this.backOutBtnType = e_FuncBtnType.AtOnce_Upgrade;
        break;
      case e_BuildType.Upgradeing:
        this.normallInfoPanel.gameObject.SetActive(false);
        this.normalPanel.gameObject.SetActive(false);
        if ((int) this.buildLv == (int) this.buildLvMAx)
          this.upgradePanel.gameObject.SetActive(false);
        else
          this.upgradePanel.gameObject.SetActive(true);
        this.infoPanel.gameObject.SetActive(true);
        this.timeBar.gameObject.SetActive(true);
        this.upgradePanelTitle.gameObject.SetActive(true);
        this.infoPanelTitle.gameObject.SetActive(true);
        this.updateTimePanel.gameObject.SetActive(false);
        this.backOutBtnType = e_FuncBtnType.Cancel;
        this.upgradeBtnType = DataManager.Instance.mPlayHelpDataType[1].Kind != (byte) 0 ? e_FuncBtnType.Speed : e_FuncBtnType.Help;
        break;
      case e_BuildType.SelfUpgradeing:
      case e_BuildType.SelfBackOuting:
        this.normallInfoPanel.gameObject.SetActive(true);
        this.normalPanel.gameObject.SetActive(true);
        this.upgradePanel.gameObject.SetActive(false);
        this.infoPanel.gameObject.SetActive(false);
        this.timeBar.gameObject.SetActive(true);
        this.upgradePanelTitle.gameObject.SetActive(false);
        this.infoPanelTitle.gameObject.SetActive(false);
        this.updateTimePanel.gameObject.SetActive(false);
        if (this.buildID > (byte) 0 && this.buildID <= (byte) 7)
          this.normalPanel.gameObject.SetActive(true);
        else
          this.normalPanel.gameObject.SetActive(false);
        this.backOutBtnType = this.buildType != e_BuildType.SelfBackOuting ? e_FuncBtnType.Cancel : e_FuncBtnType.Cancel_BackOut;
        switch (_SpriteType)
        {
          case eTimerSpriteType.Speed:
            this.upgradeBtnType = e_FuncBtnType.Speed;
            break;
          case eTimerSpriteType.Help:
            this.upgradeBtnType = e_FuncBtnType.Help;
            break;
          case eTimerSpriteType.Free:
            this.upgradeBtnType = e_FuncBtnType.Free;
            break;
        }
        if (this.buildID == (byte) 7)
        {
          this.normalPanel.gameObject.SetActive(false);
          this.normallInfoPanel.gameObject.SetActive(false);
          break;
        }
        break;
      case e_BuildType.Upgrade_Tech:
        this.normallInfoPanel.gameObject.SetActive(false);
        this.normalPanel.gameObject.SetActive(false);
        if ((int) this.buildLv == (int) this.buildLvMAx)
          this.upgradePanel.gameObject.SetActive(false);
        else
          this.upgradePanel.gameObject.SetActive(true);
        this.infoPanel.gameObject.SetActive(true);
        this.timeBar.gameObject.SetActive(false);
        this.upgradePanelTitle.gameObject.SetActive(true);
        this.infoPanelTitle.gameObject.SetActive(true);
        this.updateTimePanel.gameObject.SetActive(this.m_bSpecialConform);
        this.upgradeBtnType = e_FuncBtnType.Research;
        this.backOutBtnType = e_FuncBtnType.AtOnce_Research;
        break;
      case e_BuildType.Upgradeing_Tech:
        this.normallInfoPanel.gameObject.SetActive(false);
        this.normalPanel.gameObject.SetActive(false);
        if ((int) this.techLv == (int) this.techLvMax)
          this.upgradePanel.gameObject.SetActive(false);
        else
          this.upgradePanel.gameObject.SetActive(true);
        this.infoPanel.gameObject.SetActive(true);
        this.timeBar.gameObject.SetActive(true);
        this.upgradePanelTitle.gameObject.SetActive(true);
        this.infoPanelTitle.gameObject.SetActive(true);
        this.updateTimePanel.gameObject.SetActive(false);
        this.backOutBtnType = e_FuncBtnType.Cancel_Research;
        switch (_SpriteType)
        {
          case eTimerSpriteType.Speed:
            this.upgradeBtnType = e_FuncBtnType.Speed;
            break;
          case eTimerSpriteType.Help:
            this.upgradeBtnType = e_FuncBtnType.Help;
            break;
          case eTimerSpriteType.Free:
            this.upgradeBtnType = e_FuncBtnType.Free;
            break;
        }
        break;
    }
    if (this.style == (byte) 2)
    {
      if (this.buildType == e_BuildType.Normal || this.buildType == e_BuildType.SelfUpgradeing || this.buildType == e_BuildType.SelfBackOuting)
      {
        this.normalPanel.gameObject.SetActive(false);
        this.infoPanel.gameObject.SetActive(false);
        this.upgradePanelTitle.gameObject.SetActive(false);
        this.infoPanelTitle.gameObject.SetActive(false);
        this.buildingInfoTransform.gameObject.SetActive(false);
        this.SetUIPos(2);
      }
      else
      {
        this.buildingInfoTransform.gameObject.SetActive(true);
        this.SetUIPos(1);
      }
    }
    this.SetFuncBtnType();
    if (this.m_Handler == null)
      return;
    this.m_Handler.OnTypeChange(this.buildType);
  }

  private void Exit()
  {
    if (this.buildType == e_BuildType.Upgrade && GUIManager.Instance.BuildingData.AllBuildsData[(int) this.manorID].BuildID != (ushort) 0)
    {
      this.SetBuildType(e_BuildType.Normal);
      GUIManager.Instance.HideArrow();
    }
    else
    {
      if (!((Object) this.door != (Object) null))
        return;
      this.door.CloseMenu();
    }
  }

  private Sprite GetSpriteByEffect(ushort effectId)
  {
    Effect recordByKey = DataManager.Instance.EffectData.GetRecordByKey(effectId);
    Sprite spriteByEffect;
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
    {
      this.effectString.ClearString();
      this.effectString.IntToFormat((long) recordByKey.EffectIcon, 3);
      this.effectString.AppendFormat("icon{0}_cn");
      spriteByEffect = this.GM.LoadFrameSprite(this.effectString);
      if ((Object) spriteByEffect == (Object) null)
      {
        this.effectString.ClearString();
        this.effectString.IntToFormat((long) recordByKey.EffectIcon, 3);
        this.effectString.AppendFormat("icon{0}");
        spriteByEffect = this.GM.LoadFrameSprite(this.effectString);
      }
    }
    else
    {
      this.effectString.ClearString();
      this.effectString.IntToFormat((long) recordByKey.EffectIcon, 3);
      this.effectString.AppendFormat("icon{0}");
      spriteByEffect = this.GM.LoadFrameSprite(this.effectString);
    }
    if ((Object) spriteByEffect == (Object) null)
      spriteByEffect = this.GM.LoadFrameSprite("icon001");
    return spriteByEffect;
  }

  private void CheckBtnState(e_FuncBtnType bTnType)
  {
    if (bTnType != e_FuncBtnType.Upgrade && bTnType != e_FuncBtnType.Build && bTnType != e_FuncBtnType.Research || this.buildType != e_BuildType.Upgrade && this.buildType != e_BuildType.Upgrade_Tech)
      return;
    if (this.m_bGeneralConform && this.m_bGeneralConform_update && this.m_bSpecialConform)
    {
      this.upgradeBtn.m_BtnID2 = 200;
      this.upgradeBtn.ForTextChange(e_BtnType.e_Normal);
    }
    else
    {
      this.upgradeBtn.m_BtnID2 = 100;
      this.upgradeBtn.ForTextChange(e_BtnType.e_ChangeText);
    }
  }

  private byte CheckNowOpenEBuildTypeWindow(e_BuildType buildType)
  {
    switch (buildType)
    {
      case e_BuildType.Upgrade:
      case e_BuildType.Upgradeing:
        return 1;
      default:
        return 0;
    }
  }

  private void OpenCheckBycastleLv6(int arg)
  {
    ushort ID = DataManager.Instance.RoleAlliance.Id == 0U || (int) DataManager.Instance.RoleAlliance.KingdomID == (int) DataManager.MapDataController.OtherKingdomData.kingdomID ? (ushort) 5894 : (ushort) 8593;
    GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(5893U), DataManager.Instance.mStringTable.GetStringByID((uint) ID), arg, YesText: DataManager.Instance.mStringTable.GetStringByID(8595U), NoText: DataManager.Instance.mStringTable.GetStringByID(8596U));
  }

  private void OpenCheckBycastleLv8(int arg)
  {
    GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(5893U), DataManager.Instance.mStringTable.GetStringByID(9723U), arg, YesText: DataManager.Instance.mStringTable.GetStringByID(5895U), NoText: DataManager.Instance.mStringTable.GetStringByID(5896U));
  }

  private void SetTimeBarBtnSprite(eTimerSpriteType type, int Idx)
  {
    if (Idx >= this.m_UpgradeItem.Length || !(bool) (Object) this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages || !(bool) (Object) this.m_UpgradeItem[Idx].m_UpgradeItemBtnText)
      return;
    ((Transform) ((Graphic) this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages).rectTransform).localScale = new Vector3(1f, 1f, 1f);
    switch (type)
    {
      case eTimerSpriteType.Help:
        this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages.sprite = this.door.LoadSprite("UI_main_queue_butt_help");
        this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.text = DataManager.Instance.mStringTable.GetStringByID(781U);
        ((Behaviour) this.m_UpgradeItem[Idx].m_UpgradeItemBtnText).enabled = true;
        this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.SetAllDirty();
        this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.cachedTextGenerator.Invalidate();
        break;
      case eTimerSpriteType.Free:
        this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages.sprite = this.door.LoadSprite("UI_main_queue_butt_end");
        this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.text = DataManager.Instance.mStringTable.GetStringByID(780U);
        ((Behaviour) this.m_UpgradeItem[Idx].m_UpgradeItemBtnText).enabled = true;
        this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.SetAllDirty();
        this.m_UpgradeItem[Idx].m_UpgradeItemBtnText.cachedTextGenerator.Invalidate();
        break;
      default:
        if (this.GM.IsArabic)
          ((Transform) ((Graphic) this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
        this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages.sprite = this.door.LoadSprite("UI_main_queue_butt_up");
        ((Behaviour) this.m_UpgradeItem[Idx].m_UpgradeItemBtnText).enabled = false;
        break;
    }
    ((Graphic) this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages).rectTransform.sizeDelta = new Vector2(69f, 47f);
    ((MaskableGraphic) this.m_UpgradeItem[Idx].m_UpgradeItemBtnImages).material = this.door.LoadMaterial();
    this.m_UpgradeItem[Idx].timerSpriteType = type;
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.backOutBtnText != (Object) null && ((Behaviour) this.backOutBtnText).enabled)
    {
      ((Behaviour) this.backOutBtnText).enabled = false;
      ((Behaviour) this.backOutBtnText).enabled = true;
    }
    if ((Object) this.backOutBtnMoneyText != (Object) null && ((Behaviour) this.backOutBtnMoneyText).enabled)
    {
      ((Behaviour) this.backOutBtnMoneyText).enabled = false;
      ((Behaviour) this.backOutBtnMoneyText).enabled = true;
    }
    if ((Object) this.upgradeBtnText != (Object) null && ((Behaviour) this.upgradeBtnText).enabled)
    {
      ((Behaviour) this.upgradeBtnText).enabled = false;
      ((Behaviour) this.upgradeBtnText).enabled = true;
    }
    if ((Object) this.titleText != (Object) null && ((Behaviour) this.titleText).enabled)
    {
      ((Behaviour) this.titleText).enabled = false;
      ((Behaviour) this.titleText).enabled = true;
    }
    if ((Object) this.updateTimeText1 != (Object) null && ((Behaviour) this.updateTimeText1).enabled)
    {
      ((Behaviour) this.updateTimeText1).enabled = false;
      ((Behaviour) this.updateTimeText1).enabled = true;
    }
    if ((Object) this.updateTimeText2 != (Object) null && ((Behaviour) this.updateTimeText2).enabled)
    {
      ((Behaviour) this.updateTimeText2).enabled = false;
      ((Behaviour) this.updateTimeText2).enabled = true;
    }
    if ((Object) this.lvText != (Object) null && ((Behaviour) this.lvText).enabled)
    {
      ((Behaviour) this.lvText).enabled = false;
      ((Behaviour) this.lvText).enabled = true;
    }
    for (int index = 0; this.normalPanelTitles != null && index < this.normalPanelTitles.Length; ++index)
    {
      if ((Object) this.normalPanelTitles[index] != (Object) null && ((Behaviour) this.normalPanelTitles[index]).enabled)
      {
        ((Behaviour) this.normalPanelTitles[index]).enabled = false;
        ((Behaviour) this.normalPanelTitles[index]).enabled = true;
      }
    }
    for (int index = 0; this.normalPanelInfos != null && index < this.normalPanelInfos.Length; ++index)
    {
      if ((Object) this.normalPanelInfos[index] != (Object) null && ((Behaviour) this.normalPanelInfos[index]).enabled)
      {
        ((Behaviour) this.normalPanelInfos[index]).enabled = false;
        ((Behaviour) this.normalPanelInfos[index]).enabled = true;
      }
    }
    if ((Object) this.upgradeScrollPanelTitle != (Object) null && ((Behaviour) this.upgradeScrollPanelTitle).enabled)
    {
      ((Behaviour) this.upgradeScrollPanelTitle).enabled = false;
      ((Behaviour) this.upgradeScrollPanelTitle).enabled = true;
    }
    for (int index = 0; this.m_UpgradeInfoItemTexts != null && index < this.m_UpgradeInfoItemTexts.Length; ++index)
    {
      if ((Object) this.m_UpgradeInfoItemTexts[index] != (Object) null && ((Behaviour) this.m_UpgradeInfoItemTexts[index]).enabled)
      {
        ((Behaviour) this.m_UpgradeInfoItemTexts[index]).enabled = false;
        ((Behaviour) this.m_UpgradeInfoItemTexts[index]).enabled = true;
      }
    }
    if ((Object) this.upgradeInfoScrollPanelTitle != (Object) null && ((Behaviour) this.upgradeInfoScrollPanelTitle).enabled)
    {
      ((Behaviour) this.upgradeInfoScrollPanelTitle).enabled = false;
      ((Behaviour) this.upgradeInfoScrollPanelTitle).enabled = true;
    }
    for (int index = 0; this.m_UpgradeItem != null && index < this.m_UpgradeItem.Length; ++index)
    {
      if ((Object) this.m_UpgradeItem[index].m_UpgradeItemTexts != (Object) null && ((Behaviour) this.m_UpgradeItem[index].m_UpgradeItemTexts).enabled)
      {
        ((Behaviour) this.m_UpgradeItem[index].m_UpgradeItemTexts).enabled = false;
        ((Behaviour) this.m_UpgradeItem[index].m_UpgradeItemTexts).enabled = true;
      }
      if ((Object) this.m_UpgradeItem[index].m_UpgradeItemBtnText != (Object) null && ((Behaviour) this.m_UpgradeItem[index].m_UpgradeItemBtnText).enabled)
      {
        ((Behaviour) this.m_UpgradeItem[index].m_UpgradeItemBtnText).enabled = false;
        ((Behaviour) this.m_UpgradeItem[index].m_UpgradeItemBtnText).enabled = true;
      }
      if ((Object) this.m_UpgradeItem[index].m_UpgradeItemTimeTexts != (Object) null && ((Behaviour) this.m_UpgradeItem[index].m_UpgradeItemTimeTexts).enabled)
      {
        ((Behaviour) this.m_UpgradeItem[index].m_UpgradeItemTimeTexts).enabled = false;
        ((Behaviour) this.m_UpgradeItem[index].m_UpgradeItemTimeTexts).enabled = true;
      }
    }
    for (int index = 0; index < this.m_TempText.Length; ++index)
    {
      if ((Object) this.m_TempText[index] != (Object) null && ((Behaviour) this.m_TempText[index]).enabled)
      {
        ((Behaviour) this.m_TempText[index]).enabled = false;
        ((Behaviour) this.m_TempText[index]).enabled = true;
      }
    }
    if ((Object) this.m_SetNormalInfoPanelText != (Object) null && ((Behaviour) this.m_SetNormalInfoPanelText).enabled)
    {
      ((Behaviour) this.m_SetNormalInfoPanelText).enabled = false;
      ((Behaviour) this.m_SetNormalInfoPanelText).enabled = true;
    }
    if (!((Object) this.timeBar != (Object) null) || !this.timeBar.enabled)
      return;
    this.timeBar.Refresh_FontTexture();
  }

  private void SaveScrollPostion()
  {
    if (!((Object) this.upgradeScrollPanel != (Object) null) || this.upgradeScrollPanel.m_PanelObjects == null)
      return;
    this.GM.m_BuildingTopIdx = this.upgradeScrollPanel.GetTopIdx();
    this.GM.m_BuildingPosY = this.upgradeScrollPanel.GetContentPos();
  }

  private void ClearScrollPostionSave()
  {
    this.GM.m_BuildingTopIdx = 0;
    this.GM.m_BuildingPosY = 0.0f;
  }

  private void SetCustomCastleBtn(e_BuildType _buildType)
  {
    if ((_buildType == e_BuildType.Normal || _buildType == e_BuildType.SelfUpgradeing) && this.buildID == (byte) 8 && GUIManager.Instance.BuildingData.castleSkin.CheckShowCastleSkin())
    {
      this.customCastleTf.gameObject.SetActive(true);
      this.exclamationTf.gameObject.SetActive(GUIManager.Instance.BuildingData.castleSkin.CheckShowExclamation(true));
    }
    else
      this.customCastleTf.gameObject.SetActive(false);
  }
}
