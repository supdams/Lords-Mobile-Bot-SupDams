// Decompiled with JetBrains decompiler
// Type: UIActivity2
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIActivity2 : 
  GUIWindow,
  UILoadImageHander,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUILEBtnClickHandler
{
  private const byte StepCount = 3;
  private const float ItemDeltaY = -70f;
  private const byte FactorCount = 5;
  private const byte HintCount = 12;
  private const int UnitCount = 7;
  private Transform m_transform;
  private Transform ContentT;
  private Transform UnitObjectT;
  private DataManager DM;
  private GUIManager GM;
  private ActivityManager AM;
  private Font tmpFont;
  private Image TopTriImage;
  private Vector2 TriLastPos = new Vector2(395f, 9f);
  private Image[] SliderNormal = new Image[3];
  private Image[] SliderFlash = new Image[3];
  private UIText[] StageScoreText = new UIText[3];
  private CString[] StageScore = new CString[3];
  private Color StageScoreColorY = new Color(1f, 0.945f, 0.203f);
  private CString NowScoreStr;
  private UIText NowScoreText;
  private CString NextScoreStr;
  private UIText NextScoreText;
  private Image[] PrizeStageImg = new Image[3];
  private CString[] GemCountText = new CString[3];
  private CString[] TitleText2 = new CString[3];
  private CString[] TotalpriceText = new CString[3];
  private CString[] NoPriceText = new CString[3];
  private int[] ItemCount = new int[3];
  private CString[][] ItemCountText;
  private CString RankStr;
  private UISpritesArray TimeSA;
  private UIText TimeTitle;
  private UIText TimeTitle2;
  private UIText TimeText;
  private CString TimeStr;
  private byte nowStep;
  private ulong nowScore;
  private ulong[] StepScore = new ulong[3];
  private CString[] ScoreFactorRateStr = new CString[5];
  private CString[] ScoreFactorRateStr2 = new CString[5];
  private ActivityDataType tmpData;
  private byte ActivityIndex;
  private Transform Main2T;
  private Transform NotOpenT;
  private RectTransform HintT;
  private RectTransform HintT2;
  private RectTransform HintT3;
  private RectTransform HintT4;
  private UIText[] HintTextL = new UIText[12];
  private UIText[] HintTextR = new UIText[12];
  private CString[] HintStrL = new CString[12];
  private CString[] HintStrR = new CString[12];
  private UIText HintT3Text;
  private UIText HintSPText;
  private CString HintT3Str;
  private UIText[] RBText = new UIText[8];
  private UIText[] RBText2 = new UIText[11];
  private UIText[] RBText3 = new UIText[9];
  private UIText[] RBText4;
  private UIText[] RBText5 = new UIText[16];
  private UIText[] FctorText1 = new UIText[5];
  private UIText[] FctorText2 = new UIText[5];
  private UIText[] FctorText3 = new UIText[5];
  private UIText[] StepText1 = new UIText[3];
  private UIText[] StepText2 = new UIText[3];
  private UIText[] StepText3 = new UIText[3];
  private UIText[] StepText4 = new UIText[3];
  private UIText[][] StepItemCountText = new UIText[3][];
  private CString[] ItemNameStr = new CString[8];
  private UIText[] ItemNameText = new UIText[3];
  private float Sizex;
  private float Sizey;
  private GameObject BossGO;
  private int AssetKey;
  private AssetBundle AB;
  private AssetBundleRequest AR;
  private bool bABInitial;
  private Transform ActorT;
  private Transform LightT;
  private Hero sHero;
  private Animation tmpAN;
  private string HeroAct;
  private float ActionTime;
  private float ActionTimeRandom;
  private AnimationUnit.AnimName[] ANIndex = new AnimationUnit.AnimName[1]
  {
    AnimationUnit.AnimName.VICTORY
  };
  private List<AnimationUnit.AnimName> ANList = new List<AnimationUnit.AnimName>();
  private int OtherAssetKey;
  private AssetBundle OtherAB;
  private CString[] kingdomIDstr;
  private CString[] kingdomPrizestr;
  private Color GreenColor = new Color(0.07843f, 0.9725f, 0.3333f, 1f);
  private bool bSummonType;
  private GameObject SummonBtn;
  private GameObject SummonFlash;
  private GameObject SummonAlert;
  private GameObject SummonBtn2;
  private GameObject NoImgGO;
  private GameObject StarObj;
  private GameObject StarObj2;
  private GameObject SummonTimeObj;
  private UIText NoText1;
  private UIText NoText2;
  private UIText RankReplayTitleText;
  private CString[] Hint5Str = new CString[16];
  private bool bNobilityWar;
  private bool[] bFindScrollComp = new bool[7];
  private UnitComp_Act2[] Scroll_Comp = new UnitComp_Act2[7];
  private CString[] CountTimeStr = new CString[7];
  private List<float> NowHeightList = new List<float>();
  private ScrollPanel Scroll;
  private CScrollRect cScrollRect;
  private Color NW_YellowColor = new Color(0.9647f, 0.9333f, 0.749f, 1f);
  private Color NW_GreenColor = new Color(0.0f, 1f, 0.0f, 1f);
  private GameObject RightObject_Prize;
  private GameObject RightObject_RP;
  private GameObject RightObject_Part1;
  private GameObject HintTargetImageGO;
  private GameObject RightObject_KingdomBtn;
  private GameObject MyKingdom_prize;
  private GameObject MyKingdom_RP;
  private GameObject P2_FightX;
  private RectTransform P2RC;
  private RectTransform P3RC;
  private RectTransform P2_WonderNameLeftImgRC;
  private RectTransform P2_WonderNameRC;
  private RectTransform P2_WonderPosRC;
  private RectTransform P3_1stItem;
  private RectTransform P3_2ndItem;
  private RectTransform P3_3rdItem;
  private UIText P1_TitleText;
  private UIText P2_KingdomIDText;
  private UIText P2_WonderNameText;
  private UIText P2_WonderPosText;
  private UIText P3_CrystalText;
  private UIText P3_MoneyText;
  private UIText RP_NameText;
  private UIText RP_KingdomIDText;
  private UIText NWText;
  private Image RP_NameImage;
  private Image NW_New;
  private RectTransform HintKingdom;
  private RectTransform HintNormal;
  private GameObject[] HintObject;
  private UIText[] HintKingdomText;
  private UIText[] P3_ItemText;
  private CString[] HintKingdomStr;
  private CString[] P3_ItemStr;
  private ushort HeroID;
  private Vector2 ContentSize;
  private bool bKVKForFourth;
  private GameObject KVKLine1;
  private GameObject KVKLine2;
  private GameObject HintGO;
  private Image ReTimeImage;
  private Image ReImageDevil;
  private Image ReImageTarget;
  private UIText ReTimeText;
  private UIText ReImageDevilText;
  private UIText HintText1;
  private UIText HintText2;
  private CString ReTimeStr;
  private CString ReImageDevilStr;
  private CString HintStr1;
  private CString HintStr2;
  private byte ShowRate;
  private Transform SPT;
  private GameObject SPGO;
  private int SPAssetKey;

  public override void OnOpen(int arg1, int arg2)
  {
    // ISSUE: unable to decompile the method.
  }

  public override void OnClose()
  {
    StringManager instance = StringManager.Instance;
    instance.DeSpawnString(this.NowScoreStr);
    instance.DeSpawnString(this.NextScoreStr);
    for (int index1 = 0; index1 < 3; ++index1)
    {
      instance.DeSpawnString(this.StageScore[index1]);
      instance.DeSpawnString(this.GemCountText[index1]);
      instance.DeSpawnString(this.TitleText2[index1]);
      instance.DeSpawnString(this.TotalpriceText[index1]);
      instance.DeSpawnString(this.NoPriceText[index1]);
      for (int index2 = 0; index2 < this.ItemCount[index1]; ++index2)
        instance.DeSpawnString(this.ItemCountText[index1][index2]);
    }
    for (int index = 0; index < 5; ++index)
    {
      if (this.ScoreFactorRateStr[index] != null)
        instance.DeSpawnString(this.ScoreFactorRateStr[index]);
      if (this.ScoreFactorRateStr2[index] != null)
        instance.DeSpawnString(this.ScoreFactorRateStr2[index]);
    }
    for (int index = 0; index < 12; ++index)
    {
      if (this.HintStrL[index] != null)
        instance.DeSpawnString(this.HintStrL[index]);
      if (this.HintStrR[index] != null)
        instance.DeSpawnString(this.HintStrR[index]);
    }
    instance.DeSpawnString(this.TimeStr);
    instance.DeSpawnString(this.RankStr);
    instance.DeSpawnString(this.ReTimeStr);
    instance.DeSpawnString(this.HintT3Str);
    instance.DeSpawnString(this.ReImageDevilStr);
    instance.DeSpawnString(this.HintStr1);
    instance.DeSpawnString(this.HintStr2);
    if (this.P3_ItemStr != null)
    {
      for (int index = 0; index < this.P3_ItemStr.Length; ++index)
        instance.DeSpawnString(this.P3_ItemStr[index]);
    }
    if (this.HintKingdomStr != null)
    {
      for (int index = 0; index < this.HintKingdomStr.Length; ++index)
        instance.DeSpawnString(this.HintKingdomStr[index]);
    }
    if (this.kingdomIDstr != null)
    {
      for (int index = 0; index < this.kingdomIDstr.Length; ++index)
        instance.DeSpawnString(this.kingdomIDstr[index]);
    }
    if (this.kingdomPrizestr != null)
    {
      for (int index = 0; index < this.kingdomPrizestr.Length; ++index)
        instance.DeSpawnString(this.kingdomPrizestr[index]);
    }
    for (int index = 0; index < this.ItemNameStr.Length; ++index)
    {
      if (this.ItemNameStr[index] != null)
        instance.DeSpawnString(this.ItemNameStr[index]);
    }
    for (int index = 0; index < this.Hint5Str.Length; ++index)
    {
      if (this.Hint5Str[index] != null)
        instance.DeSpawnString(this.Hint5Str[index]);
    }
    for (int index = 0; index < this.CountTimeStr.Length; ++index)
    {
      if (this.CountTimeStr[index] != null)
        instance.DeSpawnString(this.CountTimeStr[index]);
    }
    if ((Object) this.BossGO != (Object) null)
    {
      ModelLoader.Instance.Unload((Object) this.BossGO);
      this.BossGO = (GameObject) null;
    }
    if ((Object) this.ContentT != (Object) null)
      this.AM.Act2Pos = this.ContentT.GetComponent<RectTransform>().anchoredPosition;
    if (this.OtherAssetKey != 0)
    {
      AssetManager.UnloadAssetBundle(this.OtherAssetKey);
      this.OtherAB = (AssetBundle) null;
      this.OtherAssetKey = 0;
    }
    if (this.SPAssetKey != 0)
    {
      AssetManager.UnloadAssetBundle(this.SPAssetKey);
      this.SPGO = (GameObject) null;
      this.SPT = (Transform) null;
      this.SPAssetKey = 0;
    }
    GUIManager.Instance.m_LordInfo.HideEquipVal = false;
  }

  private void LoadSP(string ABName)
  {
    if ((Object) this.ContentT == (Object) null)
      return;
    AssetBundle assetBundle = AssetManager.GetAssetBundle("UI/UIActivity2", out this.SPAssetKey);
    if ((Object) assetBundle == (Object) null)
      return;
    this.SPGO = Object.Instantiate(assetBundle.Load(ABName)) as GameObject;
    this.SPGO.transform.SetParent(this.ContentT, false);
    this.SPT = this.SPGO.transform;
    ((RectTransform) this.SPT).anchoredPosition = Vector2.zero;
  }

  private void SetRight(byte SelectIndex)
  {
    if (this.tmpData.GroupCount == (byte) 0 || SelectIndex < (byte) 0 || (int) SelectIndex >= (int) this.tmpData.GroupCount)
      return;
    byte index1 = this.tmpData.NobilityGroupDataSortIndex[(int) SelectIndex];
    EActivityState eventState = this.tmpData.NobilityGroupData[(int) index1].EventState;
    bool flag1 = this.AM.FederalActKingdomWonderID != (byte) 0 && (int) this.tmpData.NobilityGroupData[(int) index1].WonderID == (int) this.AM.FederalActKingdomWonderID;
    if (this.AM.NW_UI_SelectWonderID == -1)
      this.AM.NW_UI_SelectWonderID = (int) this.tmpData.NobilityGroupData[(int) index1].WonderID;
    this.NWText.text = this.DM.mStringTable.GetStringByID(3734U);
    ((Component) this.NW_New).gameObject.SetActive(false);
    if (this.tmpData.EventState == EActivityState.EAS_Prepare || this.tmpData.EventState == EActivityState.EAS_Run)
    {
      byte index2 = this.tmpData.NobilityGroupDataIndex[(int) this.AM.FederalActKingdomWonderID];
      if (this.AM.FederalActKingdomID != (ushort) 0 && this.tmpData.NobilityGroupData[(int) index2].EventState == EActivityState.EAS_ReplayRanking)
      {
        this.NWText.text = this.DM.mStringTable.GetStringByID(3714U);
        this.NWText.SetAllDirty();
        this.NWText.cachedTextGenerator.Invalidate();
        this.NWText.cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.NW_New).rectTransform.anchoredPosition = new Vector2((float) (-((double) this.NWText.preferredWidth / 2.0) - 30.0), ((Graphic) this.NW_New).rectTransform.anchoredPosition.y);
        ((Component) this.NW_New).gameObject.SetActive(true);
      }
      else if (this.AM.FederalActKingdomID == (ushort) 0)
      {
        this.NWText.text = this.DM.mStringTable.GetStringByID(1353U);
        this.NWText.SetAllDirty();
        this.NWText.cachedTextGenerator.Invalidate();
        this.NWText.cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.NW_New).rectTransform.anchoredPosition = new Vector2((float) (-((double) this.NWText.preferredWidth / 2.0) - 30.0), ((Graphic) this.NW_New).rectTransform.anchoredPosition.y);
        ((Component) this.NW_New).gameObject.SetActive(true);
      }
      else if (this.GM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 25)
      {
        this.NWText.text = this.DM.mStringTable.GetStringByID(3715U);
        this.NWText.SetAllDirty();
        this.NWText.cachedTextGenerator.Invalidate();
        this.NWText.cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.NW_New).rectTransform.anchoredPosition = new Vector2((float) (-((double) this.NWText.preferredWidth / 2.0) - 30.0), ((Graphic) this.NW_New).rectTransform.anchoredPosition.y);
        ((Component) this.NW_New).gameObject.SetActive(true);
      }
      else if ((int) this.AM.FederalActKingdomWonderID != (int) this.AM.FederalHomeKingdomWonderID)
      {
        if (this.ItemNameStr[2] == null)
          this.ItemNameStr[2] = StringManager.Instance.SpawnString(300);
        this.ItemNameStr[2].Length = 0;
        this.ItemNameStr[2].IntToFormat((long) this.AM.FederalActKingdomID);
        this.ItemNameStr[2].AppendFormat(this.DM.mStringTable.GetStringByID(3716U));
        this.NWText.text = this.ItemNameStr[2].ToString();
        this.NWText.SetAllDirty();
        this.NWText.cachedTextGenerator.Invalidate();
        this.NWText.cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.NW_New).rectTransform.anchoredPosition = new Vector2((float) (-((double) this.NWText.preferredWidth / 2.0) - 30.0), ((Graphic) this.NW_New).rectTransform.anchoredPosition.y);
        ((Component) this.NW_New).gameObject.SetActive(true);
      }
    }
    if (eventState == EActivityState.EAS_Prepare || eventState == EActivityState.EAS_Run)
    {
      if (eventState == EActivityState.EAS_Prepare && !this.tmpData.NobilityGroupData[(int) index1].bAskPrizeData || eventState == EActivityState.EAS_Run && !this.tmpData.NobilityGroupData[(int) index1].bAskKingdomData)
      {
        this.AM.Send_FEDERAL_ORDERDETAIL(this.tmpData.NobilityGroupData[(int) index1].WonderID);
      }
      else
      {
        this.RightObject_RP.SetActive(false);
        this.RightObject_Prize.SetActive(true);
        this.RightObject_Part1.SetActive(false);
        ((Component) this.NWText).gameObject.SetActive(true);
        this.RightObject_KingdomBtn.SetActive(false);
        bool flag2 = false;
        this.ContentT.GetComponent<RectTransform>().sizeDelta = this.ContentSize;
        this.ContentT.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        if (flag1)
        {
          if (this.GM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 25)
          {
            this.RightObject_Part1.SetActive(true);
            flag2 = true;
            this.P1_TitleText.text = this.DM.mStringTable.GetStringByID(3715U);
            this.ContentT.GetComponent<RectTransform>().sizeDelta = this.ContentSize + new Vector2(0.0f, 45f);
          }
          else if ((int) this.tmpData.NobilityGroupData[(int) index1].WonderID == (int) this.AM.FederalActKingdomWonderID && (int) this.AM.FederalActKingdomWonderID != (int) this.AM.FederalHomeKingdomWonderID)
          {
            this.RightObject_Part1.SetActive(true);
            flag2 = true;
            if (this.ItemNameStr[2] == null)
              this.ItemNameStr[2] = StringManager.Instance.SpawnString(300);
            this.ItemNameStr[2].Length = 0;
            this.ItemNameStr[2].IntToFormat((long) this.AM.FederalActKingdomID);
            this.ItemNameStr[2].AppendFormat(this.DM.mStringTable.GetStringByID(3716U));
            this.P1_TitleText.text = this.ItemNameStr[2].ToString();
            this.P1_TitleText.SetAllDirty();
            this.P1_TitleText.cachedTextGenerator.Invalidate();
            this.ContentT.GetComponent<RectTransform>().sizeDelta = this.ContentSize + new Vector2(0.0f, 45f);
          }
        }
        if (flag2)
        {
          this.P2RC.anchoredPosition = new Vector2(0.0f, -45f);
          this.P3RC.anchoredPosition = new Vector2(0.0f, -387f);
        }
        else
        {
          this.P2RC.anchoredPosition = new Vector2(0.0f, 0.0f);
          this.P3RC.anchoredPosition = new Vector2(0.0f, -342f);
        }
        this.RBText[7].text = this.DM.mStringTable.GetStringByID(3649U);
        this.RBText[7].SetAllDirty();
        this.RBText[7].cachedTextGenerator.Invalidate();
        if (flag1)
        {
          if (this.ItemNameStr[3] == null)
            this.ItemNameStr[3] = StringManager.Instance.SpawnString(300);
          this.ItemNameStr[3].Length = 0;
          if ((int) this.AM.FederalActKingdomWonderID != (int) this.AM.FederalHomeKingdomWonderID)
            this.ItemNameStr[3].IntToFormat((long) this.AM.FederalActKingdomID);
          else
            this.ItemNameStr[3].IntToFormat((long) DataManager.MapDataController.kingdomData.kingdomID);
          this.ItemNameStr[3].AppendFormat(this.DM.mStringTable.GetStringByID(3650U));
          this.P2_KingdomIDText.text = this.ItemNameStr[3].ToString();
          this.P2_KingdomIDText.SetAllDirty();
          this.P2_KingdomIDText.cachedTextGenerator.Invalidate();
          this.P2_KingdomIDText.cachedTextGeneratorForLayout.Invalidate();
          this.MyKingdom_prize.SetActive(true);
        }
        else
          this.MyKingdom_prize.SetActive(false);
        this.P2_WonderNameText.text = DataManager.MapDataController.GetYolkName((ushort) this.tmpData.NobilityGroupData[(int) index1].WonderID, this.tmpData.NobilityGroupData[(int) index1].KingdomID).ToString();
        this.P2_WonderNameText.SetAllDirty();
        this.P2_WonderNameText.cachedTextGenerator.Invalidate();
        this.P2_WonderNameText.cachedTextGeneratorForLayout.Invalidate();
        this.P2_WonderNameRC.sizeDelta = new Vector2(this.P2_WonderNameText.preferredWidth + 1f, this.P2_WonderNameRC.sizeDelta.y);
        this.P2_WonderNameLeftImgRC.anchoredPosition = new Vector2((float) (241.0 - ((double) this.P2_WonderNameRC.sizeDelta.x + (double) this.P2_WonderNameLeftImgRC.sizeDelta.x) / 2.0), this.P2_WonderNameLeftImgRC.anchoredPosition.y);
        Vector2 yolkPos = DataManager.MapDataController.GetYolkPos((ushort) this.tmpData.NobilityGroupData[(int) index1].WonderID, this.tmpData.NobilityGroupData[(int) index1].KingdomID);
        if (this.ItemNameStr[4] == null)
          this.ItemNameStr[4] = StringManager.Instance.SpawnString();
        this.ItemNameStr[4].Length = 0;
        this.ItemNameStr[4].IntToFormat((long) this.tmpData.NobilityGroupData[(int) index1].KingdomID);
        this.ItemNameStr[4].IntToFormat((long) (int) yolkPos.x);
        this.ItemNameStr[4].IntToFormat((long) (int) yolkPos.y);
        if (this.GM.IsArabic)
          this.ItemNameStr[4].AppendFormat("{0}:K {1}:X {2}:Y");
        else
          this.ItemNameStr[4].AppendFormat(this.DM.mStringTable.GetStringByID(4633U));
        this.P2_WonderPosText.text = this.ItemNameStr[4].ToString();
        this.P2_WonderPosText.SetAllDirty();
        this.P2_WonderPosText.cachedTextGenerator.Invalidate();
        this.P2_WonderPosText.cachedTextGeneratorForLayout.Invalidate();
        this.P2_WonderPosRC.sizeDelta = new Vector2(this.P2_WonderPosText.preferredWidth + 1f, this.P2_WonderPosRC.sizeDelta.y);
        ushort itemId1 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[0][0].ItemID;
        byte rank1 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[0][0].Rank;
        byte num1 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[0][0].Num;
        Equip recordByKey = this.DM.EquipTable.GetRecordByKey(itemId1);
        if ((int) recordByKey.EquipKey == (int) itemId1)
        {
          if (this.GM.IsLeadItem(recordByKey.EquipKind))
          {
            ((Transform) this.P3_1stItem).GetChild(0).gameObject.SetActive(false);
            ((Transform) this.P3_1stItem).GetChild(1).gameObject.SetActive(true);
            this.GM.ChangeLordEquipImg(((Transform) this.P3_1stItem).GetChild(1), itemId1, rank1, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
          }
          else
          {
            ((Transform) this.P3_1stItem).GetChild(0).gameObject.SetActive(true);
            ((Transform) this.P3_1stItem).GetChild(1).gameObject.SetActive(false);
            this.GM.ChangeHeroItemImg(((Transform) this.P3_1stItem).GetChild(0), eHeroOrItem.Item, itemId1, (byte) 0, rank1);
            if (MallManager.Instance.CheckCanOpenDetail(itemId1))
              ((Transform) this.P3_1stItem).GetChild(0).GetComponent<UIButtonHint>().enabled = false;
            else
              ((Transform) this.P3_1stItem).GetChild(0).GetComponent<UIButtonHint>().enabled = true;
          }
          if (num1 > (byte) 1)
          {
            this.P3_ItemStr[0].Length = 0;
            this.P3_ItemStr[0].IntToFormat((long) num1, bNumber: true);
            if (this.GM.IsArabic)
              this.P3_ItemStr[0].AppendFormat("{0}x");
            else
              this.P3_ItemStr[0].AppendFormat("x{0}");
            this.P3_ItemText[0].text = this.P3_ItemStr[0].ToString();
            this.P3_ItemText[0].SetAllDirty();
            this.P3_ItemText[0].cachedTextGenerator.Invalidate();
            ((Component) this.P3_ItemText[0]).gameObject.SetActive(true);
          }
          else
            ((Component) this.P3_ItemText[0]).gameObject.SetActive(false);
        }
        ushort itemId2 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[0][1].ItemID;
        byte rank2 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[0][1].Rank;
        byte num2 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[0][1].Num;
        if (this.ItemNameStr[5] == null)
          this.ItemNameStr[5] = StringManager.Instance.SpawnString(100);
        this.ItemNameStr[5].Length = 0;
        if (itemId2 > (ushort) 0)
        {
          recordByKey = this.DM.EquipTable.GetRecordByKey(itemId2);
          if ((int) recordByKey.EquipKey == (int) itemId2)
          {
            this.ItemNameStr[5].IntToFormat((long) ((int) recordByKey.PropertiesInfo[1].Propertieskey * (int) recordByKey.PropertiesInfo[1].PropertiesValue * (int) num2), bNumber: true);
            this.ItemNameStr[5].AppendFormat("x{0}");
          }
        }
        this.P3_CrystalText.text = this.ItemNameStr[5].ToString();
        this.P3_CrystalText.SetAllDirty();
        this.P3_CrystalText.cachedTextGenerator.Invalidate();
        ushort itemId3 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[0][2].ItemID;
        rank2 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[0][2].Rank;
        byte num3 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[0][2].Num;
        if (this.ItemNameStr[6] == null)
          this.ItemNameStr[6] = StringManager.Instance.SpawnString(100);
        this.ItemNameStr[6].Length = 0;
        if (itemId3 > (ushort) 0)
        {
          recordByKey = this.DM.EquipTable.GetRecordByKey(itemId3);
          if ((int) recordByKey.EquipKey == (int) itemId3)
          {
            this.ItemNameStr[6].IntToFormat((long) ((int) recordByKey.PropertiesInfo[1].Propertieskey * (int) recordByKey.PropertiesInfo[1].PropertiesValue * (int) num3), bNumber: true);
            this.ItemNameStr[6].AppendFormat("x{0}");
          }
        }
        this.P3_MoneyText.text = this.ItemNameStr[6].ToString();
        this.P3_MoneyText.SetAllDirty();
        this.P3_MoneyText.cachedTextGenerator.Invalidate();
        ushort itemId4 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[1][0].ItemID;
        byte rank3 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[1][0].Rank;
        byte num4 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[1][0].Num;
        recordByKey = this.DM.EquipTable.GetRecordByKey(itemId4);
        if ((int) recordByKey.EquipKey == (int) itemId4)
        {
          if (this.GM.IsLeadItem(recordByKey.EquipKind))
          {
            ((Transform) this.P3_2ndItem).GetChild(0).gameObject.SetActive(false);
            ((Transform) this.P3_2ndItem).GetChild(1).gameObject.SetActive(true);
            this.GM.ChangeLordEquipImg(((Transform) this.P3_2ndItem).GetChild(1), itemId4, rank3, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
          }
          else
          {
            ((Transform) this.P3_2ndItem).GetChild(0).gameObject.SetActive(true);
            ((Transform) this.P3_2ndItem).GetChild(1).gameObject.SetActive(false);
            this.GM.ChangeHeroItemImg(((Transform) this.P3_2ndItem).GetChild(0), eHeroOrItem.Item, itemId4, (byte) 0, rank3);
            if (MallManager.Instance.CheckCanOpenDetail(itemId4))
              ((Transform) this.P3_2ndItem).GetChild(0).GetComponent<UIButtonHint>().enabled = false;
            else
              ((Transform) this.P3_2ndItem).GetChild(0).GetComponent<UIButtonHint>().enabled = true;
          }
          if (num4 > (byte) 1)
          {
            this.P3_ItemStr[1].Length = 0;
            this.P3_ItemStr[1].IntToFormat((long) num4, bNumber: true);
            if (this.GM.IsArabic)
              this.P3_ItemStr[1].AppendFormat("{0}x");
            else
              this.P3_ItemStr[1].AppendFormat("x{0}");
            this.P3_ItemText[1].text = this.P3_ItemStr[1].ToString();
            this.P3_ItemText[1].SetAllDirty();
            this.P3_ItemText[1].cachedTextGenerator.Invalidate();
            ((Component) this.P3_ItemText[1]).gameObject.SetActive(true);
          }
          else
            ((Component) this.P3_ItemText[1]).gameObject.SetActive(false);
        }
        ushort itemId5 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[2][0].ItemID;
        byte rank4 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[2][0].Rank;
        byte num5 = this.tmpData.NobilityGroupData[(int) index1].PreparePrize[2][0].Num;
        recordByKey = this.DM.EquipTable.GetRecordByKey(itemId5);
        if ((int) recordByKey.EquipKey == (int) itemId5)
        {
          if (this.GM.IsLeadItem(recordByKey.EquipKind))
          {
            ((Transform) this.P3_3rdItem).GetChild(0).gameObject.SetActive(false);
            ((Transform) this.P3_3rdItem).GetChild(1).gameObject.SetActive(true);
            this.GM.ChangeLordEquipImg(((Transform) this.P3_3rdItem).GetChild(1), itemId5, rank4, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
          }
          else
          {
            ((Transform) this.P3_3rdItem).GetChild(0).gameObject.SetActive(true);
            ((Transform) this.P3_3rdItem).GetChild(1).gameObject.SetActive(false);
            this.GM.ChangeHeroItemImg(((Transform) this.P3_3rdItem).GetChild(0), eHeroOrItem.Item, itemId5, (byte) 0, rank4);
            if (MallManager.Instance.CheckCanOpenDetail(itemId5))
              ((Transform) this.P3_3rdItem).GetChild(0).GetComponent<UIButtonHint>().enabled = false;
            else
              ((Transform) this.P3_3rdItem).GetChild(0).GetComponent<UIButtonHint>().enabled = true;
          }
          if (num5 > (byte) 1)
          {
            this.P3_ItemStr[2].Length = 0;
            this.P3_ItemStr[2].IntToFormat((long) num5, bNumber: true);
            if (this.GM.IsArabic)
              this.P3_ItemStr[2].AppendFormat("{0}x");
            else
              this.P3_ItemStr[2].AppendFormat("x{0}");
            this.P3_ItemText[2].text = this.P3_ItemStr[2].ToString();
            this.P3_ItemText[2].SetAllDirty();
            this.P3_ItemText[2].cachedTextGenerator.Invalidate();
            ((Component) this.P3_ItemText[2]).gameObject.SetActive(true);
          }
          else
            ((Component) this.P3_ItemText[2]).gameObject.SetActive(false);
        }
        if (eventState == EActivityState.EAS_Run)
          this.P2_FightX.SetActive(true);
        else
          this.P2_FightX.SetActive(false);
        if (eventState == EActivityState.EAS_Run)
        {
          if ((Object) this.HintT2 != (Object) null)
            ((Component) this.HintT2).gameObject.SetActive(false);
          this.HintT2 = this.HintKingdom;
          int index3 = 0;
          ushort x = 0;
          if (flag1)
          {
            x = (int) this.AM.FederalActKingdomWonderID == (int) this.AM.FederalHomeKingdomWonderID ? DataManager.MapDataController.kingdomData.kingdomID : this.AM.FederalActKingdomID;
            this.HintObject[index3].SetActive(true);
            this.HintKingdomStr[index3].Length = 0;
            this.HintKingdomStr[index3].IntToFormat((long) x);
            this.HintKingdomStr[index3].AppendFormat("#{0}");
            this.HintKingdomText[index3].text = this.HintKingdomStr[index3].ToString();
            this.HintKingdomText[index3].SetAllDirty();
            this.HintKingdomText[index3].cachedTextGenerator.Invalidate();
            ++index3;
            this.HintTargetImageGO.SetActive(true);
          }
          else
            this.HintTargetImageGO.SetActive(false);
          for (int index4 = 0; index4 < 50 && index3 < 50; ++index4)
          {
            if (index4 < (int) this.tmpData.NobilityGroupData[(int) index1].FightKingdomCount)
            {
              if (!flag1 || (int) x != (int) this.tmpData.NobilityGroupData[(int) index1].FightKingdomID[index4])
              {
                this.HintObject[index3].SetActive(true);
                this.HintKingdomStr[index3].Length = 0;
                this.HintKingdomStr[index3].IntToFormat((long) this.tmpData.NobilityGroupData[(int) index1].FightKingdomID[index4]);
                this.HintKingdomStr[index3].AppendFormat("#{0}");
                this.HintKingdomText[index3].text = this.HintKingdomStr[index3].ToString();
                this.HintKingdomText[index3].SetAllDirty();
                this.HintKingdomText[index3].cachedTextGenerator.Invalidate();
              }
              else
                continue;
            }
            else
              this.HintObject[index3].SetActive(false);
            ++index3;
          }
          this.HintKingdom.sizeDelta = new Vector2(this.HintKingdom.sizeDelta.x, (float) (118 + ((int) this.tmpData.NobilityGroupData[(int) index1].FightKingdomCount - 1) / 4 * 45));
          if (-((double) this.HintKingdom.anchoredPosition.y - (double) this.HintKingdom.sizeDelta.y) > (double) this.Sizey - 100.0)
            this.HintKingdom.anchoredPosition = new Vector2(this.HintKingdom.anchoredPosition.x, (float) (-(double) this.Sizey + (double) this.HintKingdom.sizeDelta.y + 100.0));
          if ((double) this.HintKingdom.anchoredPosition.y <= 0.0)
            return;
          this.HintKingdom.anchoredPosition = new Vector2(this.HintKingdom.anchoredPosition.x, 0.0f);
        }
        else
        {
          if ((Object) this.HintT2 != (Object) null)
            ((Component) this.HintT2).gameObject.SetActive(false);
          this.HintT2 = this.HintNormal;
          if (flag1)
          {
            if (this.ItemNameStr[7] == null)
              this.ItemNameStr[7] = StringManager.Instance.SpawnString(500);
            this.ItemNameStr[7].Length = 0;
            this.ItemNameStr[7].IntToFormat((long) this.AM.FederalActKingdomID);
            this.ItemNameStr[7].AppendFormat(this.DM.mStringTable.GetStringByID(3781U));
            this.RBText3[5].text = this.ItemNameStr[7].ToString();
            this.RBText3[5].SetAllDirty();
            this.RBText3[5].cachedTextGenerator.Invalidate();
          }
          else
            this.RBText3[5].text = this.DM.mStringTable.GetStringByID(3754U);
          float y = this.RBText3[5].preferredHeight + 1f;
          ((Graphic) this.RBText3[5]).rectTransform.sizeDelta = new Vector2(((Graphic) this.RBText3[5]).rectTransform.sizeDelta.x, y);
          this.HintT2.sizeDelta = new Vector2(this.HintT2.sizeDelta.x, y + 30f);
        }
      }
    }
    else if (!this.tmpData.NobilityGroupData[(int) index1].bAskNobilityData)
    {
      this.AM.Send_FEDERAL_ORDERDETAIL(this.tmpData.NobilityGroupData[(int) index1].WonderID);
    }
    else
    {
      this.RightObject_RP.SetActive(true);
      this.RightObject_Prize.SetActive(false);
      this.RightObject_Part1.SetActive(false);
      this.RightObject_KingdomBtn.SetActive(true);
      this.RBText[7].text = DataManager.MapDataController.GetYolkName((ushort) this.tmpData.NobilityGroupData[(int) index1].WonderID, this.tmpData.NobilityGroupData[(int) index1].KingdomID).ToString();
      this.RBText[7].SetAllDirty();
      this.RBText[7].cachedTextGenerator.Invalidate();
      if ((Object) this.HintT2 != (Object) null)
        ((Component) this.HintT2).gameObject.SetActive(false);
      if (flag1)
      {
        if (this.ItemNameStr[2] == null)
          this.ItemNameStr[2] = StringManager.Instance.SpawnString(300);
        this.ItemNameStr[2].Length = 0;
        if ((int) this.AM.FederalActKingdomWonderID != (int) this.AM.FederalHomeKingdomWonderID)
          this.ItemNameStr[2].IntToFormat((long) this.AM.FederalActKingdomID);
        else
          this.ItemNameStr[2].IntToFormat((long) DataManager.MapDataController.kingdomData.kingdomID);
        this.ItemNameStr[2].AppendFormat(this.DM.mStringTable.GetStringByID(3650U));
        this.RP_KingdomIDText.text = this.ItemNameStr[2].ToString();
        this.RP_KingdomIDText.SetAllDirty();
        this.RP_KingdomIDText.cachedTextGenerator.Invalidate();
        this.RP_KingdomIDText.cachedTextGeneratorForLayout.Invalidate();
        this.HintT2 = this.HintNormal;
        if (this.ItemNameStr[7] == null)
          this.ItemNameStr[7] = StringManager.Instance.SpawnString(500);
        this.ItemNameStr[7].Length = 0;
        this.ItemNameStr[7].IntToFormat((long) this.AM.FederalActKingdomID);
        this.ItemNameStr[7].AppendFormat(this.DM.mStringTable.GetStringByID(3714U));
        this.RBText3[5].text = this.ItemNameStr[7].ToString();
        this.RBText3[5].SetAllDirty();
        this.RBText3[5].cachedTextGenerator.Invalidate();
        float y = this.RBText3[5].preferredHeight + 1f;
        ((Graphic) this.RBText3[5]).rectTransform.sizeDelta = new Vector2(((Graphic) this.RBText3[5]).rectTransform.sizeDelta.x, y);
        this.HintT2.sizeDelta = new Vector2(this.HintT2.sizeDelta.x, y + 30f);
        this.HintT2.anchoredPosition3D = new Vector3(this.HintT2.anchoredPosition3D.x, this.HintT2.anchoredPosition3D.y, -790f);
        this.MyKingdom_RP.SetActive(true);
      }
      else
        this.MyKingdom_RP.SetActive(false);
      if (this.ItemNameStr[3] == null)
        this.ItemNameStr[3] = StringManager.Instance.SpawnString(150);
      this.ItemNameStr[3].Length = 0;
      this.ItemNameStr[3].Append(this.DM.mStringTable.GetStringByID(11057U));
      this.ItemNameStr[3].Append(' ');
      this.ItemNameStr[3].Append(this.tmpData.NobilityGroupData[(int) index1].NobilityName);
      this.RP_NameText.text = this.ItemNameStr[3].ToString();
      this.RP_NameText.SetAllDirty();
      this.RP_NameText.cachedTextGenerator.Invalidate();
      this.RP_NameText.cachedTextGeneratorForLayout.Invalidate();
      if ((double) this.RP_NameText.preferredWidth + 4.0 > 251.30000305175781)
        ((Graphic) this.RP_NameImage).rectTransform.sizeDelta = new Vector2(251.3f, ((Graphic) this.RP_NameImage).rectTransform.sizeDelta.y);
      else
        ((Graphic) this.RP_NameImage).rectTransform.sizeDelta = new Vector2(this.RP_NameText.preferredWidth + 4f, ((Graphic) this.RP_NameImage).rectTransform.sizeDelta.y);
      this.HeroID = this.tmpData.NobilityGroupData[(int) index1].NobilityHeroID;
      this.sHero = this.DM.HeroTable.GetRecordByKey(this.tmpData.NobilityGroupData[(int) index1].NobilityHeroID);
      CString Name = StringManager.Instance.StaticString1024();
      Name.IntToFormat((long) this.sHero.Modle, 5);
      Name.AppendFormat("Role/hero_{0}");
      if (!AssetManager.GetAssetBundleDownload(Name, AssetPath.Role, AssetType.Hero, this.sHero.Modle))
        return;
      this.LoadAB(true);
    }
  }

  private void UpdateTime()
  {
    if (this.tmpData == null || this.tmpData.EventState == EActivityState.EAS_None)
      return;
    if (this.bNobilityWar)
    {
      for (int ScrollIndex = 0; ScrollIndex < 7; ++ScrollIndex)
      {
        if (this.bFindScrollComp[ScrollIndex] && this.Scroll_Comp[ScrollIndex].ItemGO.activeInHierarchy && this.Scroll_Comp[ScrollIndex].bShowCountTime)
          this.SetGroupTimeStr(ScrollIndex);
      }
    }
    if (!this.bKVKForFourth)
      return;
    this.SetKVKReTime();
  }

  private void SetGroupTimeStr(int ScrollIndex)
  {
    if (this.tmpData.NobilityGroupData == null)
      return;
    byte index = this.tmpData.NobilityGroupDataSortIndex[(int) this.Scroll_Comp[ScrollIndex].DataIndex];
    if (index < (byte) 0 || (int) index >= this.tmpData.NobilityGroupData.Length)
      return;
    switch (this.tmpData.NobilityGroupData[(int) index].EventState)
    {
      case EActivityState.EAS_None:
        this.tmpData.NobilityGroupData[(int) index].EventCountTime = 0L;
        break;
      case EActivityState.EAS_Run:
      case EActivityState.EAS_HomeStart:
      case EActivityState.EAS_HomeEnd:
      case EActivityState.EAS_StartRanking:
      case EActivityState.EAS_ReplayRanking:
        this.tmpData.NobilityGroupData[(int) index].EventCountTime = this.tmpData.NobilityGroupData[(int) index].EventBeginTime + (long) this.tmpData.NobilityGroupData[(int) index].EventRequireTime - DataManager.Instance.ServerTime;
        break;
      case EActivityState.EAS_Prepare:
        this.tmpData.NobilityGroupData[(int) index].EventCountTime = this.tmpData.NobilityGroupData[(int) index].EventBeginTime - DataManager.Instance.ServerTime;
        break;
    }
    if (this.tmpData.NobilityGroupData[(int) index].EventCountTime < 0L)
      this.tmpData.NobilityGroupData[(int) index].EventCountTime = 0L;
    this.CountTimeStr[ScrollIndex].Length = 0;
    if (this.tmpData.NobilityGroupData[(int) index].EventState == EActivityState.EAS_Prepare)
    {
      ((Graphic) this.Scroll_Comp[ScrollIndex].CountTimeText).color = this.NW_YellowColor;
      this.CountTimeStr[ScrollIndex].Append(this.DM.mStringTable.GetStringByID(8111U));
    }
    else
    {
      ((Graphic) this.Scroll_Comp[ScrollIndex].CountTimeText).color = this.NW_GreenColor;
      this.CountTimeStr[ScrollIndex].Append(this.DM.mStringTable.GetStringByID(8110U));
    }
    this.CountTimeStr[ScrollIndex].Append(' ');
    CString CStr = StringManager.Instance.StaticString1024();
    GameConstants.GetTimeString(CStr, (uint) this.tmpData.NobilityGroupData[(int) index].EventCountTime);
    this.CountTimeStr[ScrollIndex].Append(CStr);
    this.Scroll_Comp[ScrollIndex].CountTimeText.text = this.CountTimeStr[ScrollIndex].ToString();
    this.Scroll_Comp[ScrollIndex].CountTimeText.SetAllDirty();
    this.Scroll_Comp[ScrollIndex].CountTimeText.cachedTextGenerator.Invalidate();
  }

  private void Refresh_NWLeftList()
  {
    if (this.tmpData.GroupCount == (byte) 0)
      return;
    this.NowHeightList.Clear();
    for (int index = 0; index < this.tmpData.NobilityGroupData.Length; ++index)
      this.NowHeightList.Add(78f);
    this.Scroll.AddNewDataHeight(this.NowHeightList);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelId != 1 || panelObjectIdx >= 7)
      return;
    if (!this.bFindScrollComp[panelObjectIdx])
    {
      this.bFindScrollComp[panelObjectIdx] = true;
      Transform transform = item.transform;
      this.Scroll_Comp[panelObjectIdx].ItemGO = item;
      this.Scroll_Comp[panelObjectIdx].ScrollItem = transform.GetComponent<ScrollPanelItem>();
      this.Scroll_Comp[panelObjectIdx].ScrollItem.m_BtnID2 = panelObjectIdx;
      this.Scroll_Comp[panelObjectIdx].BackImage = transform.GetChild(0).GetComponent<Image>();
      this.Scroll_Comp[panelObjectIdx].SA = transform.GetChild(0).GetComponent<UISpritesArray>();
      this.Scroll_Comp[panelObjectIdx].MyGroupImg = transform.GetChild(0).GetChild(0).GetComponent<Image>();
      this.Scroll_Comp[panelObjectIdx].ActivityTimeText = transform.GetChild(0).GetChild(1).GetComponent<UIText>();
      this.Scroll_Comp[panelObjectIdx].CountTimeText = transform.GetChild(0).GetChild(2).GetComponent<UIText>();
      this.Scroll_Comp[panelObjectIdx].SelectImage = transform.GetChild(0).GetChild(3).GetComponent<Image>();
      this.CountTimeStr[panelObjectIdx] = StringManager.Instance.SpawnString();
    }
    if (this.tmpData.GroupCount == (byte) 0 || dataIdx < 0 || dataIdx >= (int) this.tmpData.GroupCount)
      return;
    byte index = this.tmpData.NobilityGroupDataSortIndex[dataIdx];
    if (index < (byte) 0 || (int) index >= this.tmpData.NobilityGroupData.Length)
      return;
    bool flag1 = dataIdx == 0;
    bool flag2 = this.AM.FederalActKingdomWonderID != (byte) 0 && (int) this.tmpData.NobilityGroupData[(int) index].WonderID == (int) this.AM.FederalActKingdomWonderID;
    this.Scroll_Comp[panelObjectIdx].DataIndex = (byte) dataIdx;
    this.Scroll_Comp[panelObjectIdx].bShowCountTime = flag1 || flag2;
    if (flag1 && this.tmpData.NobilityGroupData[(int) index].EventState == EActivityState.EAS_Prepare)
      this.Scroll_Comp[panelObjectIdx].SA.SetSpriteIndex(1);
    else if (flag1 && this.tmpData.NobilityGroupData[(int) index].EventState == EActivityState.EAS_Run)
      this.Scroll_Comp[panelObjectIdx].SA.SetSpriteIndex(2);
    else if (this.tmpData.NobilityGroupData[(int) index].EventState == EActivityState.EAS_ReplayRanking)
      this.Scroll_Comp[panelObjectIdx].SA.SetSpriteIndex(3);
    else
      this.Scroll_Comp[panelObjectIdx].SA.SetSpriteIndex(0);
    if (flag2)
      ((Component) this.Scroll_Comp[panelObjectIdx].MyGroupImg).gameObject.SetActive(true);
    else
      ((Component) this.Scroll_Comp[panelObjectIdx].MyGroupImg).gameObject.SetActive(false);
    this.Scroll_Comp[panelObjectIdx].ActivityTimeText.text = this.tmpData.NobilityGroupData[(int) index].EventTimeStr.ToString();
    if (this.tmpData.NobilityGroupData[(int) index].EventState != EActivityState.EAS_ReplayRanking && (flag1 || flag2))
    {
      this.Scroll_Comp[panelObjectIdx].ActivityTimeText.alignment = TextAnchor.UpperLeft;
      ((Component) this.Scroll_Comp[panelObjectIdx].CountTimeText).gameObject.SetActive(true);
      this.SetGroupTimeStr(panelObjectIdx);
    }
    else
    {
      this.Scroll_Comp[panelObjectIdx].ActivityTimeText.alignment = TextAnchor.MiddleLeft;
      ((Component) this.Scroll_Comp[panelObjectIdx].CountTimeText).gameObject.SetActive(false);
    }
    if ((int) this.Scroll_Comp[panelObjectIdx].DataIndex == (int) this.AM.NW_UI_SelectIndex)
      ((Component) this.Scroll_Comp[panelObjectIdx].SelectImage).gameObject.SetActive(true);
    else
      ((Component) this.Scroll_Comp[panelObjectIdx].SelectImage).gameObject.SetActive(false);
  }

  private void Update()
  {
    // ISSUE: unable to decompile the method.
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        if (this.tmpData == null)
          break;
        this.SetStepScore(this.tmpData.EventScore);
        this.SetMonsterState();
        break;
      case 2:
        if ((int) this.ActivityIndex != arg2)
          break;
        if (this.tmpData.EventState == EActivityState.EAS_None)
        {
          this.Main2T.gameObject.SetActive(false);
          this.NotOpenT.gameObject.SetActive(true);
        }
        else
          ActivityManager.Instance.ChangeStateReOpenMenu(this.ActivityIndex);
        this.SetTimeTitle();
        break;
      case 3:
        this.SetTimeStr();
        this.UpdateTime();
        break;
      case 4:
        this.SetMonsterState();
        break;
      case 5:
        this.SetNPCCityStarObj();
        this.SetNPCCityCombatTimes();
        break;
      case 6:
        if (this.AM.NW_UI_SelectWonderID != -1 && this.tmpData.GroupCount != (byte) 0 && this.AM.NW_UI_SelectIndex >= (byte) 0 && (int) this.AM.NW_UI_SelectIndex < (int) this.tmpData.GroupCount)
        {
          bool flag = false;
          if ((int) this.tmpData.NobilityGroupData[(int) this.tmpData.NobilityGroupDataSortIndex[(int) this.AM.NW_UI_SelectIndex]].WonderID != this.AM.NW_UI_SelectWonderID)
          {
            for (byte index = 0; (int) index < (int) this.tmpData.GroupCount; ++index)
            {
              if ((int) this.tmpData.NobilityGroupData[(int) this.tmpData.NobilityGroupDataSortIndex[(int) index]].WonderID == this.AM.NW_UI_SelectWonderID)
              {
                this.AM.NW_UI_SelectIndex = index;
                flag = true;
              }
            }
          }
          else
            flag = true;
          if (!flag)
          {
            this.AM.NW_UI_SelectIndex = (byte) 0;
            this.AM.NW_UI_SelectWonderID = -1;
          }
        }
        this.Refresh_NWLeftList();
        this.SetRight(this.AM.NW_UI_SelectIndex);
        break;
      case 7:
        this.SetRight(this.AM.NW_UI_SelectIndex);
        break;
      case 8:
        if ((int) this.ActivityIndex != arg2)
          break;
        if (this.tmpData.EventState == EActivityState.EAS_None)
        {
          this.Main2T.gameObject.SetActive(false);
          this.NotOpenT.gameObject.SetActive(true);
        }
        else
          ActivityManager.Instance.ChangeStateReOpenMenu(this.ActivityIndex);
        this.SetTimeTitle();
        break;
      case 9:
        this.SetReLineAndPic();
        this.SetKVKReTime();
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
        EKVKActivityType kvkActiveType = this.tmpData.KVKActiveType;
        EActivityState eventState = this.tmpData.EventState;
        if (kvkActiveType != EKVKActivityType.EKAT_MAX && (kvkActiveType == EKVKActivityType.EKAT_KvKEvent && eventState == EActivityState.EAS_None || kvkActiveType == EKVKActivityType.EKAT_KNormalSoloEvent && eventState == EActivityState.EAS_None || kvkActiveType == EKVKActivityType.EKAT_KNormalAllianceEvent && eventState == EActivityState.EAS_None || kvkActiveType == EKVKActivityType.EKAT_KvKSoloEvent && (eventState == EActivityState.EAS_None || eventState == EActivityState.EAS_ReplayRanking) || kvkActiveType == EKVKActivityType.EKAT_KvKAllianceEvent && (eventState == EActivityState.EAS_None || eventState == EActivityState.EAS_ReplayRanking)))
        {
          Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
          ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST();
          if ((bool) (Object) menu)
            menu.CloseMenu();
        }
        if (this.tmpData.EventState == EActivityState.EAS_None)
        {
          this.Main2T.gameObject.SetActive(false);
          this.NotOpenT.gameObject.SetActive(true);
          break;
        }
        ActivityManager.Instance.ChangeStateReOpenMenu(this.ActivityIndex);
        break;
      case NetworkNews.Refresh_Asset:
        if (meg[1] != (byte) 1 || meg[2] != (byte) 2 || (int) GameConstants.ConvertBytesToUShort(meg, 3) != (int) this.sHero.Modle)
          break;
        this.LoadAB(true);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        for (int index = 0; index < 7; ++index)
        {
          if (this.bFindScrollComp[index])
          {
            if ((Object) this.Scroll_Comp[index].ActivityTimeText != (Object) null && ((Behaviour) this.Scroll_Comp[index].ActivityTimeText).enabled)
            {
              ((Behaviour) this.Scroll_Comp[index].ActivityTimeText).enabled = false;
              ((Behaviour) this.Scroll_Comp[index].ActivityTimeText).enabled = true;
            }
            if ((Object) this.Scroll_Comp[index].CountTimeText != (Object) null && ((Behaviour) this.Scroll_Comp[index].CountTimeText).enabled)
            {
              ((Behaviour) this.Scroll_Comp[index].CountTimeText).enabled = false;
              ((Behaviour) this.Scroll_Comp[index].CountTimeText).enabled = true;
            }
          }
        }
        for (int index = 0; index < this.ItemNameText.Length; ++index)
        {
          if ((Object) this.ItemNameText[index] != (Object) null && ((Behaviour) this.ItemNameText[index]).enabled)
          {
            ((Behaviour) this.ItemNameText[index]).enabled = false;
            ((Behaviour) this.ItemNameText[index]).enabled = true;
          }
        }
        for (int index = 0; index < this.RBText5.Length; ++index)
        {
          if ((Object) this.RBText5[index] != (Object) null && ((Behaviour) this.RBText5[index]).enabled)
          {
            ((Behaviour) this.RBText5[index]).enabled = false;
            ((Behaviour) this.RBText5[index]).enabled = true;
          }
        }
        if (this.RBText4 != null)
        {
          for (int index = 0; index < this.RBText4.Length; ++index)
          {
            if ((Object) this.RBText4[index] != (Object) null && ((Behaviour) this.RBText4[index]).enabled)
            {
              ((Behaviour) this.RBText4[index]).enabled = false;
              ((Behaviour) this.RBText4[index]).enabled = true;
            }
          }
        }
        for (int index = 0; index < this.RBText3.Length; ++index)
        {
          if ((Object) this.RBText3[index] != (Object) null && ((Behaviour) this.RBText3[index]).enabled)
          {
            ((Behaviour) this.RBText3[index]).enabled = false;
            ((Behaviour) this.RBText3[index]).enabled = true;
          }
        }
        for (int index = 0; index < this.RBText2.Length; ++index)
        {
          if ((Object) this.RBText2[index] != (Object) null && ((Behaviour) this.RBText2[index]).enabled)
          {
            ((Behaviour) this.RBText2[index]).enabled = false;
            ((Behaviour) this.RBText2[index]).enabled = true;
          }
        }
        for (int index = 0; index < this.RBText.Length; ++index)
        {
          if ((Object) this.RBText[index] != (Object) null && ((Behaviour) this.RBText[index]).enabled)
          {
            ((Behaviour) this.RBText[index]).enabled = false;
            ((Behaviour) this.RBText[index]).enabled = true;
          }
        }
        if (this.HintKingdomText != null)
        {
          for (int index = 0; index < this.HintKingdomText.Length; ++index)
          {
            if ((Object) this.HintKingdomText[index] != (Object) null && ((Behaviour) this.HintKingdomText[index]).enabled)
            {
              ((Behaviour) this.HintKingdomText[index]).enabled = false;
              ((Behaviour) this.HintKingdomText[index]).enabled = true;
            }
          }
        }
        if (this.P3_ItemText != null)
        {
          for (int index = 0; index < this.P3_ItemText.Length; ++index)
          {
            if ((Object) this.P3_ItemText[index] != (Object) null && ((Behaviour) this.P3_ItemText[index]).enabled)
            {
              ((Behaviour) this.P3_ItemText[index]).enabled = false;
              ((Behaviour) this.P3_ItemText[index]).enabled = true;
            }
          }
        }
        for (int index = 0; index < 5; ++index)
        {
          if ((Object) this.FctorText1[index] != (Object) null && ((Behaviour) this.FctorText1[index]).enabled)
          {
            ((Behaviour) this.FctorText1[index]).enabled = false;
            ((Behaviour) this.FctorText1[index]).enabled = true;
          }
          if ((Object) this.FctorText2[index] != (Object) null && ((Behaviour) this.FctorText2[index]).enabled)
          {
            ((Behaviour) this.FctorText2[index]).enabled = false;
            ((Behaviour) this.FctorText2[index]).enabled = true;
          }
          if ((Object) this.FctorText3[index] != (Object) null && ((Behaviour) this.FctorText3[index]).enabled)
          {
            ((Behaviour) this.FctorText3[index]).enabled = false;
            ((Behaviour) this.FctorText3[index]).enabled = true;
          }
        }
        for (int index1 = 0; index1 < 3; ++index1)
        {
          for (int index2 = 0; index2 < this.ItemCount[index1]; ++index2)
          {
            if (this.StepItemCountText[index1] != null && (Object) this.StepItemCountText[index1][index2] != (Object) null && ((Behaviour) this.StepItemCountText[index1][index2]).enabled)
            {
              ((Behaviour) this.StepItemCountText[index1][index2]).enabled = false;
              ((Behaviour) this.StepItemCountText[index1][index2]).enabled = true;
            }
          }
          if ((Object) this.StageScoreText[index1] != (Object) null && ((Behaviour) this.StageScoreText[index1]).enabled)
          {
            ((Behaviour) this.StageScoreText[index1]).enabled = false;
            ((Behaviour) this.StageScoreText[index1]).enabled = true;
          }
          if ((Object) this.StepText1[index1] != (Object) null && ((Behaviour) this.StepText1[index1]).enabled)
          {
            ((Behaviour) this.StepText1[index1]).enabled = false;
            ((Behaviour) this.StepText1[index1]).enabled = true;
          }
          if ((Object) this.StepText2[index1] != (Object) null && ((Behaviour) this.StepText2[index1]).enabled)
          {
            ((Behaviour) this.StepText2[index1]).enabled = false;
            ((Behaviour) this.StepText2[index1]).enabled = true;
          }
          if ((Object) this.StepText3[index1] != (Object) null && ((Behaviour) this.StepText3[index1]).enabled)
          {
            ((Behaviour) this.StepText3[index1]).enabled = false;
            ((Behaviour) this.StepText3[index1]).enabled = true;
          }
          if ((Object) this.StepText4[index1] != (Object) null && ((Behaviour) this.StepText4[index1]).enabled)
          {
            ((Behaviour) this.StepText4[index1]).enabled = false;
            ((Behaviour) this.StepText4[index1]).enabled = true;
          }
        }
        for (int index = 0; index < 12; ++index)
        {
          if ((Object) this.HintTextL[index] != (Object) null && ((Behaviour) this.HintTextL[index]).enabled)
          {
            ((Behaviour) this.HintTextL[index]).enabled = false;
            ((Behaviour) this.HintTextL[index]).enabled = true;
          }
          if ((Object) this.HintTextR[index] != (Object) null && ((Behaviour) this.HintTextR[index]).enabled)
          {
            ((Behaviour) this.HintTextR[index]).enabled = false;
            ((Behaviour) this.HintTextR[index]).enabled = true;
          }
        }
        if ((Object) this.NowScoreText != (Object) null && ((Behaviour) this.NowScoreText).enabled)
        {
          ((Behaviour) this.NowScoreText).enabled = false;
          ((Behaviour) this.NowScoreText).enabled = true;
        }
        if ((Object) this.NextScoreText != (Object) null && ((Behaviour) this.NextScoreText).enabled)
        {
          ((Behaviour) this.NextScoreText).enabled = false;
          ((Behaviour) this.NextScoreText).enabled = true;
        }
        if ((Object) this.TimeTitle != (Object) null && ((Behaviour) this.TimeTitle).enabled)
        {
          ((Behaviour) this.TimeTitle).enabled = false;
          ((Behaviour) this.TimeTitle).enabled = true;
        }
        if ((Object) this.TimeText != (Object) null && ((Behaviour) this.TimeText).enabled)
        {
          ((Behaviour) this.TimeText).enabled = false;
          ((Behaviour) this.TimeText).enabled = true;
        }
        if ((Object) this.RankReplayTitleText != (Object) null && ((Behaviour) this.RankReplayTitleText).enabled)
        {
          ((Behaviour) this.RankReplayTitleText).enabled = false;
          ((Behaviour) this.RankReplayTitleText).enabled = true;
        }
        if ((Object) this.P1_TitleText != (Object) null && ((Behaviour) this.P1_TitleText).enabled)
        {
          ((Behaviour) this.P1_TitleText).enabled = false;
          ((Behaviour) this.P1_TitleText).enabled = true;
        }
        if ((Object) this.P2_KingdomIDText != (Object) null && ((Behaviour) this.P2_KingdomIDText).enabled)
        {
          ((Behaviour) this.P2_KingdomIDText).enabled = false;
          ((Behaviour) this.P2_KingdomIDText).enabled = true;
        }
        if ((Object) this.P2_WonderNameText != (Object) null && ((Behaviour) this.P2_WonderNameText).enabled)
        {
          ((Behaviour) this.P2_WonderNameText).enabled = false;
          ((Behaviour) this.P2_WonderNameText).enabled = true;
        }
        if ((Object) this.P2_WonderPosText != (Object) null && ((Behaviour) this.P2_WonderPosText).enabled)
        {
          ((Behaviour) this.P2_WonderPosText).enabled = false;
          ((Behaviour) this.P2_WonderPosText).enabled = true;
        }
        if ((Object) this.P3_CrystalText != (Object) null && ((Behaviour) this.P3_CrystalText).enabled)
        {
          ((Behaviour) this.P3_CrystalText).enabled = false;
          ((Behaviour) this.P3_CrystalText).enabled = true;
        }
        if ((Object) this.P3_MoneyText != (Object) null && ((Behaviour) this.P3_MoneyText).enabled)
        {
          ((Behaviour) this.P3_MoneyText).enabled = false;
          ((Behaviour) this.P3_MoneyText).enabled = true;
        }
        if ((Object) this.RP_NameText != (Object) null && ((Behaviour) this.RP_NameText).enabled)
        {
          ((Behaviour) this.RP_NameText).enabled = false;
          ((Behaviour) this.RP_NameText).enabled = true;
        }
        if ((Object) this.RP_KingdomIDText != (Object) null && ((Behaviour) this.RP_KingdomIDText).enabled)
        {
          ((Behaviour) this.RP_KingdomIDText).enabled = false;
          ((Behaviour) this.RP_KingdomIDText).enabled = true;
        }
        if ((Object) this.NWText != (Object) null && ((Behaviour) this.NWText).enabled)
        {
          ((Behaviour) this.NWText).enabled = false;
          ((Behaviour) this.NWText).enabled = true;
        }
        if ((Object) this.HintT3Text != (Object) null && ((Behaviour) this.HintT3Text).enabled)
        {
          ((Behaviour) this.HintT3Text).enabled = false;
          ((Behaviour) this.HintT3Text).enabled = true;
        }
        if ((Object) this.ReTimeText != (Object) null && ((Behaviour) this.ReTimeText).enabled)
        {
          ((Behaviour) this.ReTimeText).enabled = false;
          ((Behaviour) this.ReTimeText).enabled = true;
        }
        if ((Object) this.ReImageDevilText != (Object) null && ((Behaviour) this.ReImageDevilText).enabled)
        {
          ((Behaviour) this.ReImageDevilText).enabled = false;
          ((Behaviour) this.ReImageDevilText).enabled = true;
        }
        if ((Object) this.HintText1 != (Object) null && ((Behaviour) this.HintText1).enabled)
        {
          ((Behaviour) this.HintText1).enabled = false;
          ((Behaviour) this.HintText1).enabled = true;
        }
        if ((Object) this.HintText2 != (Object) null && ((Behaviour) this.HintText2).enabled)
        {
          ((Behaviour) this.HintText2).enabled = false;
          ((Behaviour) this.HintText2).enabled = true;
        }
        if (!((Object) this.HintSPText != (Object) null) || !((Behaviour) this.HintSPText).enabled)
          break;
        ((Behaviour) this.HintSPText).enabled = false;
        ((Behaviour) this.HintSPText).enabled = true;
        break;
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    if (panelId != 1)
      return;
    int btnId2 = gameObject.GetComponent<ScrollPanelItem>().m_BtnID2;
    if (btnId2 < 0 || btnId2 >= this.Scroll_Comp.Length || !this.bFindScrollComp[btnId2] || (int) this.AM.NW_UI_SelectIndex == (int) this.Scroll_Comp[btnId2].DataIndex)
      return;
    for (int index = 0; index < this.Scroll_Comp.Length; ++index)
    {
      if ((int) this.Scroll_Comp[index].DataIndex == (int) this.AM.NW_UI_SelectIndex)
      {
        ((Component) this.Scroll_Comp[index].SelectImage).gameObject.SetActive(false);
        break;
      }
    }
    this.AM.NW_UI_SelectIndex = this.Scroll_Comp[btnId2].DataIndex;
    if (this.tmpData.GroupCount != (byte) 0 && this.AM.NW_UI_SelectIndex >= (byte) 0 && (int) this.AM.NW_UI_SelectIndex < (int) this.tmpData.GroupCount)
      this.AM.NW_UI_SelectWonderID = (int) this.tmpData.NobilityGroupData[(int) this.tmpData.NobilityGroupDataSortIndex[(int) this.AM.NW_UI_SelectIndex]].WonderID;
    ((Component) this.Scroll_Comp[btnId2].SelectImage).gameObject.SetActive(true);
    this.SetRight(this.AM.NW_UI_SelectIndex);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (sender.m_BtnID2 == 1)
      {
        ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST();
        if (!(bool) (Object) menu)
          return;
        menu.CloseMenu();
      }
      else
      {
        if (sender.m_BtnID2 != 2 || !(bool) (Object) menu)
          return;
        menu.OpenMenu(EGUIWindow.UI_Activity4, 1, (int) this.ActivityIndex);
      }
    }
    else if (sender.m_BtnID1 == 2)
    {
      if (sender.m_BtnID2 == 1)
      {
        if (this.ActivityIndex >= (byte) 201 && this.ActivityIndex <= (byte) 205)
          ActivityManager.Instance.Send_ACTIVITY_KEVENT_RANKING_PRIZE(this.ActivityIndex);
        else
          ActivityManager.Instance.Send_ACTIVITY_RANKING_PRIZE(this.ActivityIndex);
      }
      else if (sender.m_BtnID2 == 2)
      {
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (this.ActivityIndex == (byte) 207)
        {
          if (!(bool) (Object) menu)
            return;
          menu.OpenMenu(EGUIWindow.UI_LeaderBoard, 7);
        }
        else if (this.ActivityIndex == (byte) 209)
        {
          byte index = this.tmpData.NobilityGroupDataSortIndex[(int) this.AM.NW_UI_SelectIndex];
          if (!(bool) (Object) menu)
            return;
          menu.OpenMenu(EGUIWindow.UI_NobilityOccupyBoard, (int) this.tmpData.NobilityGroupData[(int) index].WonderID);
        }
        else
        {
          UILeaderBoard.NewOpen = true;
          if (!(bool) (Object) menu)
            return;
          if (this.AM.IsMatchKvk())
          {
            UIKingdomVSLBoard.NewOpen = true;
            menu.OpenMenu(EGUIWindow.UI_KingdomVSLBoard);
          }
          else
          {
            UIKVKLBoard.NewOpen = true;
            menu.OpenMenu(EGUIWindow.UI_KVKLBoard);
          }
        }
      }
      else
      {
        if (sender.m_BtnID2 != 3)
          return;
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (Object) menu)
          return;
        if (this.ActivityIndex == (byte) 207)
          menu.GoToKingdom(ActivityManager.Instance.KOWKingdomID);
        else
          menu.GoToKingdom(DataManager.MapDataController.OtherKingdomData.kingdomID);
      }
    }
    else if (sender.m_BtnID1 == 3)
    {
      if (sender.m_BtnID2 != 1 || this.AM.WKName.Length <= 0)
        return;
      DataManager.Instance.ShowLordProfile(this.AM.WKName.ToString());
    }
    else if (sender.m_BtnID1 == 4)
    {
      if (sender.m_BtnID2 == 1)
      {
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (Object) menu)
          return;
        menu.GoToKingdom(DataManager.MapDataController.kingdomData.kingdomID);
      }
      else if (this.tmpData.EventState == EActivityState.EAS_Prepare)
      {
        this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(12014U), (ushort) byte.MaxValue);
      }
      else
      {
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (Object) menu)
          return;
        menu.GoToKingdom((ushort) sender.m_BtnID3);
      }
    }
    else if (sender.m_BtnID1 == 5)
    {
      if (sender.m_BtnID2 == 1)
      {
        Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
        if (this.DM.RoleAlliance.Id > 0U)
        {
          if (!(bool) (Object) menu)
            return;
          menu.OpenMenu(EGUIWindow.UI_SummonMonster, bCameraMode: true);
        }
        else
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(689U), (ushort) byte.MaxValue);
      }
      else
      {
        if (sender.m_BtnID2 != 2 || this.DM.RoleAlliance.Id == 0U || this.AM.AllianceSummonAllianceID == 0U || (int) this.DM.RoleAlliance.Id != (int) this.AM.AllianceSummonAllianceID)
          return;
        Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (Object) menu)
          return;
        UIAlliHuntBoard.NewOpen = true;
        menu.OpenMenu(EGUIWindow.UI_AlliHuntBoard);
      }
    }
    else if (sender.m_BtnID1 == 6)
    {
      if (this.tmpData == null || this.tmpData.GroupCount == (byte) 0)
        return;
      if (sender.m_BtnID2 == 1)
      {
        byte index = this.tmpData.NobilityGroupDataSortIndex[(int) this.AM.NW_UI_SelectIndex];
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (Object) menu)
          return;
        menu.GoToWonder(this.tmpData.NobilityGroupData[(int) index].KingdomID, this.tmpData.NobilityGroupData[(int) index].WonderID);
      }
      else
      {
        if (sender.m_BtnID2 != 3)
          return;
        byte index = this.tmpData.NobilityGroupDataSortIndex[(int) this.AM.NW_UI_SelectIndex];
        if (this.tmpData.NobilityGroupData[(int) index].NobilityHeroID <= (ushort) 0)
          return;
        DataManager.Instance.ShowLordProfile(this.tmpData.NobilityGroupData[(int) index].NobilityName.ToString());
      }
    }
    else
    {
      if (sender.m_BtnID1 != 10 || sender.m_BtnID2 != 17)
        return;
      if (this.tmpData.EventState == EActivityState.EAS_Prepare)
        this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8111U), (ushort) byte.MaxValue);
      else if (this.DM.RoleAlliance.Id == 0U || this.AM.AllianceSummonAllianceID == 0U || (int) this.DM.RoleAlliance.Id != (int) this.AM.AllianceSummonAllianceID)
        this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1353U), (ushort) byte.MaxValue);
      else if (this.tmpData.EventState != EActivityState.EAS_Run)
      {
        this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1594U), (ushort) byte.MaxValue);
      }
      else
      {
        Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (Object) menu)
          return;
        menu.OpenMenu(EGUIWindow.UIDonation);
      }
    }
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
  }

  public void OnHIButtonClick(UIHIBtn sender) => MallManager.Instance.OpenDetail(sender.HIID);

  public override bool OnBackButtonClick()
  {
    ActivityManager.Instance.Send_ACTIVITY_EVENT_LIST();
    return false;
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (sender.Parm1 == (ushort) 1)
    {
      if (!((Object) this.HintT2 != (Object) null))
        return;
      ((Component) this.HintT2).gameObject.SetActive(true);
    }
    else if (sender.Parm1 == (ushort) 2)
    {
      if (!((Object) this.HintT3 != (Object) null))
        return;
      ((Component) this.HintT3).gameObject.SetActive(true);
    }
    else if (sender.Parm1 == (ushort) 3)
    {
      if (!((Object) this.HintT4 != (Object) null))
        return;
      this.SetNPCCityCombatTimes(true);
      ((Component) this.HintT4).gameObject.SetActive(true);
    }
    else if (sender.Parm1 == (ushort) 4)
    {
      if (!((Object) this.HintT2 != (Object) null))
        return;
      ((Component) this.HintT2).gameObject.SetActive(true);
    }
    else if (sender.Parm1 == (ushort) 5)
    {
      if ((Object) this.HintT3 == (Object) null)
        return;
      this.HintT3Str.Length = 0;
      if (sender.Parm2 == (byte) 1)
        this.HintT3Str.Append(this.DM.mStringTable.GetStringByID(12092U));
      else if (sender.Parm2 == (byte) 2)
      {
        if (this.tmpData.EventState == EActivityState.EAS_Prepare)
        {
          this.HintT3Str.AppendFormat(this.DM.mStringTable.GetStringByID(12093U));
        }
        else
        {
          this.HintT3Str.IntToFormat((long) this.AM.MatchKingdomID_4[this.AM.KVKHuntOrder != (byte) 2 ? 2 : 1]);
          this.HintT3Str.AppendFormat(this.DM.mStringTable.GetStringByID(12090U));
        }
      }
      else if (sender.Parm2 == (byte) 3)
      {
        if (this.tmpData.EventState == EActivityState.EAS_Prepare)
        {
          this.HintT3Str.IntToFormat((long) this.ShowRate);
          this.HintT3Str.AppendFormat(this.DM.mStringTable.GetStringByID(12094U));
        }
        else
        {
          this.HintT3Str.IntToFormat((long) this.AM.MatchKingdomID_4[this.AM.KVKHuntOrder != (byte) 2 ? 1 : 2]);
          this.HintT3Str.IntToFormat((long) this.ShowRate);
          this.HintT3Str.AppendFormat(this.DM.mStringTable.GetStringByID(12091U));
        }
      }
      this.HintT3Text.text = this.HintT3Str.ToString();
      this.HintT3Text.SetAllDirty();
      this.HintT3Text.cachedTextGenerator.Invalidate();
      this.HintT3Text.cachedTextGeneratorForLayout.Invalidate();
      float y = this.HintT3Text.preferredHeight + 1f;
      ((Graphic) this.HintT3Text).rectTransform.sizeDelta = new Vector2(((Graphic) this.HintT3Text).rectTransform.sizeDelta.x, y);
      this.HintT3.sizeDelta = new Vector2(this.HintT3.sizeDelta.x, y + 30f);
      ((Component) this.HintT3).gameObject.SetActive(true);
    }
    else
    {
      byte btnId2 = (byte) (sender.m_Button as UIButton).m_BtnID2;
      if ((int) btnId2 >= this.tmpData.GetScoreFactor.Length)
        return;
      EGetScoreFactor factor = this.tmpData.GetScoreFactor[(int) btnId2].Factor;
      int scoreFactorCount = (int) this.GetScoreFactorCount(factor);
      if (scoreFactorCount <= 0)
        return;
      bool flag = false;
      if (this.tmpData.ActiveType == EActivityType.EAT_KingdomMatchEvent && this.AM.MatchKingdomCount == (byte) 4)
      {
        byte huntBonusRate = this.AM.GetHuntBonusRate(this.ActivityIndex, factor);
        if (huntBonusRate > (byte) 1)
        {
          this.HintStr1.Length = 0;
          this.HintStr1.IntToFormat((long) huntBonusRate);
          if (this.GM.IsArabic)
            this.HintStr1.AppendFormat("{0}x");
          else
            this.HintStr1.AppendFormat("x{0}");
          this.HintText1.text = this.HintStr1.ToString();
          this.HintText1.SetAllDirty();
          this.HintText1.cachedTextGenerator.Invalidate();
          this.HintText1.cachedTextGeneratorForLayout.Invalidate();
          this.HintStr2.Length = 0;
          if (this.ActivityIndex >= (byte) 203 && this.ActivityIndex <= (byte) 205 && this.tmpData.EventState != EActivityState.EAS_Run)
          {
            this.HintStr2.IntToFormat((long) huntBonusRate);
            this.HintStr2.AppendFormat(this.DM.mStringTable.GetStringByID(12095U));
          }
          else if (this.ActivityIndex == (byte) 204 && factor == EGetScoreFactor.EGSF_WonderOccupy)
          {
            if (!this.AM.IsMatchKvk_kingdom(DataManager.Instance.RoleAlliance.KingdomID))
            {
              this.HintStr2.Append(this.DM.mStringTable.GetStringByID(12097U));
            }
            else
            {
              ushort x = 0;
              for (int index = 0; index < (int) this.AM.MatchKingdomIDCount && index < 6; ++index)
              {
                if ((int) this.AM.MatchKingdomID[index] == (int) this.DM.RoleAlliance.KingdomID)
                  x = this.AM.KVKHuntOrder != (byte) 2 ? (index != (int) this.AM.MatchKingdomIDCount - 1 ? this.AM.MatchKingdomID[index + 1] : this.AM.MatchKingdomID[0]) : (index != 0 ? this.AM.MatchKingdomID[index - 1] : this.AM.MatchKingdomID[(int) this.AM.MatchKingdomIDCount - 1]);
              }
              this.HintStr2.IntToFormat((long) x);
              this.HintStr2.IntToFormat((long) huntBonusRate);
              this.HintStr2.AppendFormat(this.DM.mStringTable.GetStringByID(12087U));
            }
          }
          else
          {
            this.HintStr2.IntToFormat((long) this.AM.MatchKingdomID_4[this.AM.KVKHuntOrder != (byte) 2 ? 1 : 2]);
            this.HintStr2.IntToFormat((long) huntBonusRate);
            this.HintStr2.AppendFormat(this.DM.mStringTable.GetStringByID(12088U));
          }
          this.HintText2.text = this.HintStr2.ToString();
          this.HintText2.SetAllDirty();
          this.HintText2.cachedTextGenerator.Invalidate();
          this.HintText2.cachedTextGeneratorForLayout.Invalidate();
          flag = true;
        }
      }
      float num1 = !flag ? 0.0f : 55f;
      this.HintGO.SetActive(flag);
      float x1 = 0.0f;
      float num2 = 30f;
      for (int index = 0; index < 12; ++index)
      {
        if (index < scoreFactorCount)
        {
          ((Component) this.HintTextL[index]).gameObject.SetActive(true);
          if (this.bSummonType)
            this.SetScoreFactorHintL_AS(factor, index, this.HintStrL[index]);
          else
            this.SetScoreFactorHintL(factor, index, this.HintStrL[index]);
          this.HintTextL[index].text = this.HintStrL[index].ToString();
          this.HintTextL[index].SetAllDirty();
          this.HintTextL[index].cachedTextGenerator.Invalidate();
          this.HintTextL[index].cachedTextGeneratorForLayout.Invalidate();
          float num3 = this.HintTextL[index].preferredWidth + 2f;
          ((Component) this.HintTextR[index]).gameObject.SetActive(true);
          if (this.bSummonType)
            this.SetScoreFactorHintR_AS(factor, index, this.HintStrR[index], (int) this.tmpData.GetScoreFactor[(int) btnId2].BonusRate);
          else
            this.SetScoreFactorHintR(factor, index, this.HintStrR[index], (int) this.tmpData.GetScoreFactor[(int) btnId2].BonusRate);
          this.HintTextR[index].text = this.HintStrR[index].ToString();
          this.HintTextR[index].SetAllDirty();
          this.HintTextR[index].cachedTextGenerator.Invalidate();
          this.HintTextR[index].cachedTextGeneratorForLayout.Invalidate();
          float num4 = this.HintTextR[index].preferredWidth + 2f;
          ((Graphic) this.HintTextL[index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.HintTextL[index]).rectTransform.anchoredPosition.x, -16f - num1 - (float) (30 * index));
          ((Graphic) this.HintTextR[index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.HintTextR[index]).rectTransform.anchoredPosition.x, -16f - num1 - (float) (30 * index));
          float num5 = 88f + num3 + num4;
          if ((double) x1 < (double) num5)
            x1 = num5;
          num2 += 30f;
        }
        else
        {
          ((Component) this.HintTextL[index]).gameObject.SetActive(false);
          ((Component) this.HintTextR[index]).gameObject.SetActive(false);
        }
      }
      this.HintT.sizeDelta = new Vector2(x1, num2 + num1);
      ((Component) this.HintSPText).gameObject.SetActive(false);
      this.HintT.anchoredPosition = new Vector2((float) ((double) this.Sizex / 2.0 - 86.0), (float) (-(double) this.Sizey / 2.0 + 51.0));
      if ((double) this.HintT.anchoredPosition.x + (double) this.HintT.sizeDelta.x > (double) this.Sizex)
        this.HintT.anchoredPosition = new Vector2(this.Sizex - this.HintT.sizeDelta.x, this.HintT.anchoredPosition.y);
      if ((double) this.HintT.anchoredPosition.x < 0.0)
        this.HintT.anchoredPosition = new Vector2(0.0f, this.HintT.anchoredPosition.y);
      if (-((double) this.HintT.anchoredPosition.y - (double) this.HintT.sizeDelta.y) > (double) this.Sizey - 100.0)
        this.HintT.anchoredPosition = new Vector2(this.HintT.anchoredPosition.x, (float) (-(double) this.Sizey + (double) this.HintT.sizeDelta.y + 100.0));
      if ((double) this.HintT.anchoredPosition.y > 0.0)
        this.HintT.anchoredPosition = new Vector2(this.HintT.anchoredPosition.x, 0.0f);
      ((Component) this.HintT).gameObject.SetActive(true);
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if (sender.Parm1 == (ushort) 1)
    {
      if (!((Object) this.HintT2 != (Object) null))
        return;
      ((Component) this.HintT2).gameObject.SetActive(false);
    }
    else if (sender.Parm1 == (ushort) 2)
    {
      if (!((Object) this.HintT3 != (Object) null))
        return;
      ((Component) this.HintT3).gameObject.SetActive(false);
    }
    else if (sender.Parm1 == (ushort) 3)
    {
      if (!((Object) this.HintT4 != (Object) null))
        return;
      ((Component) this.HintT4).gameObject.SetActive(false);
    }
    else if (sender.Parm1 == (ushort) 4)
    {
      if (!((Object) this.HintT2 != (Object) null))
        return;
      ((Component) this.HintT2).gameObject.SetActive(false);
    }
    else if (sender.Parm1 == (ushort) 5)
    {
      if (!((Object) this.HintT3 != (Object) null))
        return;
      ((Component) this.HintT3).gameObject.SetActive(false);
    }
    else
      ((Component) this.HintT).gameObject.SetActive(false);
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (Object) menu)
      return;
    img.sprite = menu.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = menu.LoadMaterial();
  }

  private void SetTimeTitle()
  {
    if (this.tmpData.EventState == EActivityState.EAS_Prepare)
    {
      this.TimeSA.SetSpriteIndex(1);
      ((Behaviour) this.TimeTitle).enabled = true;
      this.TimeTitle.text = this.DM.mStringTable.GetStringByID(8111U);
    }
    else if (this.tmpData.EventState == EActivityState.EAS_Run)
    {
      this.TimeSA.SetSpriteIndex(0);
      ((Behaviour) this.TimeTitle).enabled = true;
      this.TimeTitle.text = this.DM.mStringTable.GetStringByID(8110U);
    }
    else if (this.tmpData.EventState == EActivityState.EAS_HomeEnd || this.tmpData.EventState == EActivityState.EAS_HomeStart || this.tmpData.EventState == EActivityState.EAS_StartRanking)
    {
      this.TimeSA.SetSpriteIndex(1);
      ((Behaviour) this.TimeTitle).enabled = true;
      this.TimeTitle.text = this.DM.mStringTable.GetStringByID(9810U);
    }
    else
    {
      if (this.tmpData.EventState != EActivityState.EAS_ReplayRanking)
        return;
      this.TimeSA.SetSpriteIndex(1);
      this.TimeTitle.text = this.tmpData.ActiveType != EActivityType.EAT_KingOfTheWorld ? this.DM.mStringTable.GetStringByID(9819U) : this.DM.mStringTable.GetStringByID(10010U);
      ((Behaviour) this.TimeTitle).enabled = false;
      ((Behaviour) this.TimeTitle2).enabled = true;
      if (this.tmpData.ActiveType == EActivityType.EAT_KingOfTheWorld)
        this.TimeTitle2.text = this.DM.mStringTable.GetStringByID(10010U);
      else if (this.tmpData.ActiveType == EActivityType.EAT_AllianceSummon)
        this.TimeTitle2.text = this.DM.mStringTable.GetStringByID(14520U);
      else if (this.tmpData.ActiveType == EActivityType.EAT_FederalEvent)
        this.TimeTitle2.text = this.DM.mStringTable.GetStringByID(5042U);
      else
        this.TimeTitle2.text = this.DM.mStringTable.GetStringByID(9819U);
    }
  }

  private void SetTimeStr()
  {
    if ((Object) this.TimeText == (Object) null)
      return;
    this.TimeStr.Length = 0;
    if (this.tmpData.EventState == EActivityState.EAS_ReplayRanking && this.tmpData.ActiveType != EActivityType.EAT_AllianceSummon)
    {
      this.TimeText.text = this.TimeStr.ToString();
      this.TimeText.SetAllDirty();
      this.TimeText.cachedTextGenerator.Invalidate();
    }
    else
    {
      GameConstants.GetTimeString(this.TimeStr, (uint) this.tmpData.EventCountTime, hideTimeIfDays: true, showZeroHour: false);
      this.TimeText.text = this.TimeStr.ToString();
      this.TimeText.SetAllDirty();
      this.TimeText.cachedTextGenerator.Invalidate();
    }
  }

  private void SetStepScore(ulong Score)
  {
    if (this.tmpData == null || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKEvent || this.tmpData.ActiveType == EActivityType.EAT_KingOfTheWorld || this.tmpData.ActiveType == EActivityType.EAT_FederalEvent)
      return;
    this.nowScore = Score;
    this.NowScoreStr.Length = 0;
    this.NowScoreStr.uLongToFormat(Score, bNumber: true);
    this.NowScoreStr.AppendFormat("{0}");
    this.NowScoreText.text = this.NowScoreStr.ToString();
    this.NowScoreText.SetAllDirty();
    this.NowScoreText.cachedTextGenerator.Invalidate();
    for (int index = 0; index < 3; ++index)
    {
      this.SliderNormal[index].fillAmount = 0.0f;
      ((Component) this.SliderFlash[index]).gameObject.SetActive(false);
      ((Component) this.PrizeStageImg[index]).gameObject.SetActive(false);
      if (this.tmpData.EventBonusType == EActEventBonusType.EAEBT_RequireScoreDown)
        ((Graphic) this.StageScoreText[index]).color = this.GreenColor;
      else
        ((Graphic) this.StageScoreText[index]).color = Color.white;
    }
    ulong x = 0;
    this.nowStep = (byte) 0;
    for (int index = 0; index < 3; ++index)
    {
      if (this.nowScore >= this.StepScore[index])
        ++this.nowStep;
    }
    if (this.nowStep < (byte) 3)
    {
      x = this.StepScore[(int) this.nowStep] - Score;
      if (this.nowStep == (byte) 0)
      {
        double num = (double) this.StepScore[(int) this.nowStep];
        this.SliderNormal[(int) this.nowStep].fillAmount = num <= 0.0 ? 0.0f : (float) Score / (float) num;
      }
      else
      {
        double num = (double) (this.StepScore[(int) this.nowStep] - this.StepScore[(int) this.nowStep - 1]);
        this.SliderNormal[(int) this.nowStep].fillAmount = num <= 0.0 ? 0.0f : (float) (Score - this.StepScore[(int) this.nowStep - 1]) / (float) num;
      }
      RectTransform rectTransform = ((Graphic) this.SliderNormal[(int) this.nowStep]).rectTransform;
      ((Graphic) this.TopTriImage).rectTransform.anchoredPosition = new Vector2((float) ((double) rectTransform.anchoredPosition.x + (double) rectTransform.sizeDelta.x * (double) this.SliderNormal[(int) this.nowStep].fillAmount - 15.0), this.TriLastPos.y);
    }
    else
      ((Graphic) this.TopTriImage).rectTransform.anchoredPosition = this.TriLastPos;
    for (int index = 0; index < (int) this.nowStep; ++index)
    {
      this.SliderNormal[index].fillAmount = 1f;
      ((Component) this.SliderFlash[index]).gameObject.SetActive(true);
      ((Component) this.PrizeStageImg[index]).gameObject.SetActive(true);
      ((Graphic) this.StageScoreText[index]).color = this.StageScoreColorY;
    }
    this.NextScoreStr.Length = 0;
    this.NextScoreStr.uLongToFormat(x, bNumber: true);
    this.NextScoreStr.AppendFormat("{0}");
    this.NextScoreText.text = this.NextScoreStr.ToString();
    this.NextScoreText.SetAllDirty();
    this.NextScoreText.cachedTextGenerator.Invalidate();
  }

  private void SetSummonBtnState()
  {
    if (this.ActivityIndex != (byte) 208)
      return;
    this.SummonBtn.SetActive(true);
    this.SummonFlash.SetActive(false);
    this.SummonAlert.SetActive(false);
  }

  public string GetScoreFactorStr(EGetScoreFactor Factor)
  {
    switch (Factor)
    {
      case EGetScoreFactor.EGSF_TrainingSoldier:
        return this.DM.mStringTable.GetStringByID(8124U);
      case EGetScoreFactor.EGSF_Research:
        return this.DM.mStringTable.GetStringByID(8125U);
      case EGetScoreFactor.EGSF_Building:
        return this.DM.mStringTable.GetStringByID(8126U);
      case EGetScoreFactor.EGSF_KillTroop:
        return this.DM.mStringTable.GetStringByID(8129U);
      case EGetScoreFactor.EGSF_Gather:
        return this.DM.mStringTable.GetStringByID(8130U);
      case EGetScoreFactor.EGSF_TrainingTrap:
        return this.DM.mStringTable.GetStringByID(8166U);
      case EGetScoreFactor.EGSF_NPC:
        return this.DM.mStringTable.GetStringByID(8127U);
      case EGetScoreFactor.EGSF_WonderOccupy:
        return this.DM.mStringTable.GetStringByID(9808U);
      case EGetScoreFactor.EGSF_KVKKillEnemy:
        return this.DM.mStringTable.GetStringByID(9806U);
      case EGetScoreFactor.EGSF_KVKNPC:
        return this.DM.mStringTable.GetStringByID(9807U);
      case EGetScoreFactor.EGSF_KVKGather:
        return this.DM.mStringTable.GetStringByID(12005U);
      case EGetScoreFactor.EGSF_Gamble:
        return this.DM.mStringTable.GetStringByID(9171U);
      case EGetScoreFactor.EGSF_CompleteInfernalEvent:
        return this.DM.mStringTable.GetStringByID(14536U);
      case EGetScoreFactor.EGSF_WinNPCCity:
        return this.DM.mStringTable.GetStringByID(14537U);
      case EGetScoreFactor.EGSF_Donate:
        return this.DM.mStringTable.GetStringByID(14544U);
      case EGetScoreFactor.EGSF_MakePetBox:
        return this.DM.mStringTable.GetStringByID(17516U);
      default:
        return string.Empty;
    }
  }

  public byte GetScoreFactorCount(EGetScoreFactor Factor)
  {
    switch (Factor)
    {
      case EGetScoreFactor.EGSF_TrainingSoldier:
        return 4;
      case EGetScoreFactor.EGSF_Research:
        return 1;
      case EGetScoreFactor.EGSF_Building:
        return 1;
      case EGetScoreFactor.EGSF_KillTroop:
        return 8;
      case EGetScoreFactor.EGSF_Gather:
        return 6;
      case EGetScoreFactor.EGSF_TrainingTrap:
        return 4;
      case EGetScoreFactor.EGSF_NPC:
        return 10;
      case EGetScoreFactor.EGSF_WonderOccupy:
        return this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKSoloEvent || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalSoloEvent ? (byte) 4 : (byte) 2;
      case EGetScoreFactor.EGSF_KVKKillEnemy:
        return 8;
      case EGetScoreFactor.EGSF_KVKNPC:
        return 10;
      case EGetScoreFactor.EGSF_KVKGather:
        return 5;
      case EGetScoreFactor.EGSF_Gamble:
        return 2;
      case EGetScoreFactor.EGSF_CompleteInfernalEvent:
        return 1;
      case EGetScoreFactor.EGSF_MakePetBox:
        return 4;
      default:
        return 0;
    }
  }

  public void SetScoreFactorHintL(EGetScoreFactor Factor, int index, CString tmpStr)
  {
    tmpStr.Length = 0;
    switch (Factor)
    {
      case EGetScoreFactor.EGSF_TrainingSoldier:
        tmpStr.IntToFormat((long) (index + 1));
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8131U));
        break;
      case EGetScoreFactor.EGSF_Research:
        tmpStr.Append(this.DM.mStringTable.GetStringByID(8132U));
        break;
      case EGetScoreFactor.EGSF_Building:
        tmpStr.Append(this.DM.mStringTable.GetStringByID(8133U));
        break;
      case EGetScoreFactor.EGSF_KillTroop:
        if (index < 4)
        {
          tmpStr.IntToFormat((long) (index + 1));
          tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8138U));
          break;
        }
        tmpStr.IntToFormat((long) (index - 3));
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8160U));
        break;
      case EGetScoreFactor.EGSF_Gather:
        switch (index)
        {
          case 0:
            tmpStr.Append(this.DM.mStringTable.GetStringByID(8139U));
            return;
          case 1:
            tmpStr.Append(this.DM.mStringTable.GetStringByID(8140U));
            return;
          case 2:
            tmpStr.Append(this.DM.mStringTable.GetStringByID(8141U));
            return;
          case 3:
            tmpStr.Append(this.DM.mStringTable.GetStringByID(8142U));
            return;
          case 4:
            tmpStr.Append(this.DM.mStringTable.GetStringByID(8143U));
            return;
          case 5:
            tmpStr.Append(this.DM.mStringTable.GetStringByID(8144U));
            return;
          default:
            return;
        }
      case EGetScoreFactor.EGSF_TrainingTrap:
        tmpStr.IntToFormat((long) (index + 1));
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8167U));
        break;
      case EGetScoreFactor.EGSF_NPC:
        if (index < 5)
        {
          tmpStr.IntToFormat((long) (index + 1));
          tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8134U));
          break;
        }
        tmpStr.IntToFormat((long) (index - 4));
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8135U));
        break;
      case EGetScoreFactor.EGSF_WonderOccupy:
        if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKSoloEvent || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalSoloEvent)
        {
          switch (index)
          {
            case 0:
              tmpStr.Append(this.DM.mStringTable.GetStringByID(9829U));
              return;
            case 1:
              tmpStr.Append(this.DM.mStringTable.GetStringByID(9830U));
              return;
            case 2:
              tmpStr.Append(this.DM.mStringTable.GetStringByID(9832U));
              return;
            case 3:
              tmpStr.Append(this.DM.mStringTable.GetStringByID(9833U));
              return;
            default:
              return;
          }
        }
        else
        {
          if (index == 0)
          {
            tmpStr.Append(this.DM.mStringTable.GetStringByID(9831U));
            break;
          }
          if (index != 1)
            break;
          tmpStr.Append(this.DM.mStringTable.GetStringByID(9834U));
          break;
        }
      case EGetScoreFactor.EGSF_KVKKillEnemy:
        if (index < 4)
        {
          tmpStr.IntToFormat((long) (index + 1));
          tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(9835U));
          break;
        }
        tmpStr.IntToFormat((long) (index - 3));
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(12006U));
        break;
      case EGetScoreFactor.EGSF_KVKNPC:
        if (index < 5)
        {
          tmpStr.IntToFormat((long) (index + 1));
          tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(9837U));
          break;
        }
        tmpStr.IntToFormat((long) (index - 4));
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(9836U));
        break;
      case EGetScoreFactor.EGSF_KVKGather:
        uint score1 = this.AM.GetKVKActivityScore_SDataByFactor((byte) Factor, (byte) (index + 1)).Score1;
        tmpStr.IntToFormat((long) score1, bNumber: true);
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID((uint) (12015 + index)));
        break;
      case EGetScoreFactor.EGSF_Gamble:
        if (index == 1)
        {
          tmpStr.Append(this.DM.mStringTable.GetStringByID(9859U));
          break;
        }
        if (index != 0)
          break;
        tmpStr.Append(this.DM.mStringTable.GetStringByID(9860U));
        break;
      case EGetScoreFactor.EGSF_CompleteInfernalEvent:
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(14539U));
        break;
      case EGetScoreFactor.EGSF_MakePetBox:
        tmpStr.Append(this.DM.mStringTable.GetStringByID((uint) (17517 + index)));
        break;
    }
  }

  public void SetScoreFactorHintR(EGetScoreFactor Factor, int index, CString tmpStr, int x)
  {
    tmpStr.Length = 0;
    switch (Factor)
    {
      case EGetScoreFactor.EGSF_TrainingSoldier:
        if (this.tmpData.KVKActiveType != EKVKActivityType.EKAT_MAX)
        {
          byte facotr = (byte) Factor;
          uint num = 0;
          switch (index)
          {
            case 0:
              num = this.AM.GetKVKActivityScore_SDataByFactor(facotr, (byte) 1).Score1;
              break;
            case 1:
              num = this.AM.GetKVKActivityScore_SDataByFactor(facotr, (byte) 2).Score1;
              break;
            case 2:
              num = this.AM.GetKVKActivityScore_SDataByFactor(facotr, (byte) 3).Score1;
              break;
            case 3:
              num = this.AM.GetKVKActivityScore_SDataByFactor(facotr, (byte) 4).Score1;
              break;
          }
          tmpStr.IntToFormat((long) num * (long) x, bNumber: true);
          break;
        }
        switch (index)
        {
          case 0:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 1:
            tmpStr.IntToFormat((long) (2 * x), bNumber: true);
            break;
          case 2:
            tmpStr.IntToFormat((long) (5 * x), bNumber: true);
            break;
          case 3:
            tmpStr.IntToFormat((long) (15 * x), bNumber: true);
            break;
        }
        break;
      case EGetScoreFactor.EGSF_Research:
        if (this.tmpData.KVKActiveType != EKVKActivityType.EKAT_MAX)
        {
          uint score1 = this.AM.GetKVKActivityScore_SDataByFactor((byte) Factor, (byte) 1).Score1;
          tmpStr.IntToFormat((long) score1 * (long) x, bNumber: true);
          break;
        }
        tmpStr.IntToFormat((long) (1 * x), bNumber: true);
        break;
      case EGetScoreFactor.EGSF_Building:
        if (this.tmpData.KVKActiveType != EKVKActivityType.EKAT_MAX)
        {
          uint score1 = this.AM.GetKVKActivityScore_SDataByFactor((byte) Factor, (byte) 1).Score1;
          tmpStr.IntToFormat((long) score1 * (long) x, bNumber: true);
          break;
        }
        tmpStr.IntToFormat((long) (1 * x), bNumber: true);
        break;
      case EGetScoreFactor.EGSF_KillTroop:
        switch (index)
        {
          case 0:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 1:
            tmpStr.IntToFormat((long) (2 * x), bNumber: true);
            break;
          case 2:
            tmpStr.IntToFormat((long) (5 * x), bNumber: true);
            break;
          case 3:
            tmpStr.IntToFormat((long) (15 * x), bNumber: true);
            break;
          case 4:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 5:
            tmpStr.IntToFormat((long) (2 * x), bNumber: true);
            break;
          case 6:
            tmpStr.IntToFormat((long) (5 * x), bNumber: true);
            break;
          case 7:
            tmpStr.IntToFormat((long) (15 * x), bNumber: true);
            break;
        }
        break;
      case EGetScoreFactor.EGSF_Gather:
        switch (index)
        {
          case 0:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 1:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 2:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 3:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 4:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 5:
            tmpStr.IntToFormat((long) (100 * x), bNumber: true);
            break;
        }
        break;
      case EGetScoreFactor.EGSF_TrainingTrap:
        switch (index)
        {
          case 0:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 1:
            tmpStr.IntToFormat((long) (2 * x), bNumber: true);
            break;
          case 2:
            tmpStr.IntToFormat((long) (5 * x), bNumber: true);
            break;
          case 3:
            tmpStr.IntToFormat((long) (15 * x), bNumber: true);
            break;
        }
        break;
      case EGetScoreFactor.EGSF_NPC:
        uint num1;
        if (this.tmpData.KVKActiveType != EKVKActivityType.EKAT_MAX)
        {
          byte facotr = (byte) Factor;
          num1 = index >= 5 ? this.AM.GetKVKActivityScore_SDataByFactor(facotr, (byte) (index - 4)).Score1 : this.AM.GetKVKActivityScore_SDataByFactor(facotr, (byte) (index + 1)).Score2;
        }
        else
          num1 = index >= 5 ? DataManager.Instance.MonsterActivityScoreTable.GetRecordByIndex((int) (ushort) (index - 5)).KillPoint : DataManager.Instance.MonsterActivityScoreTable.GetRecordByIndex((int) (ushort) index).FightPoint;
        tmpStr.IntToFormat((long) num1 * (long) x, bNumber: true);
        break;
      case EGetScoreFactor.EGSF_WonderOccupy:
        uint num2 = 0;
        byte facotr1 = (byte) Factor;
        if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKSoloEvent || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalSoloEvent)
        {
          switch (index)
          {
            case 0:
              num2 = this.AM.GetKVKActivityScore_SDataByFactor(facotr1, (byte) 1).Score2;
              break;
            case 1:
              num2 = this.AM.GetKVKActivityScore_SDataByFactor(facotr1, (byte) 1).Score1;
              break;
            case 2:
              num2 = this.AM.GetKVKActivityScore_SDataByFactor(facotr1, (byte) 2).Score2;
              break;
            case 3:
              num2 = this.AM.GetKVKActivityScore_SDataByFactor(facotr1, (byte) 2).Score1;
              break;
          }
        }
        else if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKAllianceEvent || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalAllianceEvent)
        {
          switch (index)
          {
            case 0:
              num2 = this.AM.GetKVKActivityScore_SDataByFactor(facotr1, (byte) 3).Score1;
              break;
            case 1:
              num2 = this.AM.GetKVKActivityScore_SDataByFactor(facotr1, (byte) 4).Score1;
              break;
          }
        }
        else if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKEvent)
        {
          switch (index)
          {
            case 0:
              num2 = this.AM.GetKVKActivityScore_SDataByFactor(facotr1, (byte) 3).Score2;
              break;
            case 1:
              num2 = this.AM.GetKVKActivityScore_SDataByFactor(facotr1, (byte) 4).Score2;
              break;
          }
        }
        tmpStr.IntToFormat((long) num2 * (long) x, bNumber: true);
        break;
      case EGetScoreFactor.EGSF_KVKKillEnemy:
        byte facotr2 = (byte) Factor;
        uint num3 = index >= 4 ? this.AM.GetKVKActivityScore_SDataByFactor(facotr2, (byte) (index - 3)).Score2 : this.AM.GetKVKActivityScore_SDataByFactor(facotr2, (byte) (index + 1)).Score2;
        tmpStr.IntToFormat((long) num3 * (long) x, bNumber: true);
        break;
      case EGetScoreFactor.EGSF_KVKNPC:
        byte facotr3 = (byte) Factor;
        uint num4 = index >= 5 ? this.AM.GetKVKActivityScore_SDataByFactor(facotr3, (byte) (index - 4)).Score1 : this.AM.GetKVKActivityScore_SDataByFactor(facotr3, (byte) (index + 1)).Score2;
        tmpStr.IntToFormat((long) num4 * (long) x, bNumber: true);
        break;
      case EGetScoreFactor.EGSF_KVKGather:
        uint score2_1 = this.AM.GetKVKActivityScore_SDataByFactor((byte) Factor, (byte) (index + 1)).Score2;
        tmpStr.IntToFormat((long) score2_1 * (long) x, bNumber: true);
        break;
      case EGetScoreFactor.EGSF_Gamble:
        uint score1_1 = this.AM.GetKVKActivityScore_SDataByFactor((byte) Factor, (byte) index).Score1;
        tmpStr.IntToFormat((long) score1_1 * (long) x, bNumber: true);
        break;
      case EGetScoreFactor.EGSF_CompleteInfernalEvent:
        uint score2_2 = this.AM.GetKVKActivityScore_SDataByFactor((byte) Factor, (byte) 1).Score2;
        tmpStr.IntToFormat((long) score2_2 * (long) x, bNumber: true);
        break;
      case EGetScoreFactor.EGSF_MakePetBox:
        uint score1_2 = this.AM.GetKVKActivityScore_SDataByFactor((byte) Factor, (byte) (index + 1)).Score1;
        tmpStr.IntToFormat((long) score1_2 * (long) x, bNumber: true);
        break;
    }
    if (x > 1 && this.tmpData.ActiveType == EActivityType.EAT_KingdomMatchEvent && this.AM.MatchKingdomCount == (byte) 4)
      tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(12096U));
    else
      tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8145U));
  }

  public void SetScoreFactorHintL_AS(EGetScoreFactor Factor, int index, CString tmpStr)
  {
    tmpStr.Length = 0;
    switch (Factor)
    {
      case EGetScoreFactor.EGSF_TrainingSoldier:
        tmpStr.IntToFormat((long) (index + 1));
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8131U));
        break;
      case EGetScoreFactor.EGSF_Research:
        tmpStr.Append(this.DM.mStringTable.GetStringByID(8132U));
        break;
      case EGetScoreFactor.EGSF_Building:
        tmpStr.Append(this.DM.mStringTable.GetStringByID(8133U));
        break;
      case EGetScoreFactor.EGSF_KillTroop:
        if (index < 4)
        {
          tmpStr.IntToFormat((long) (index + 1));
          tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8138U));
          break;
        }
        tmpStr.IntToFormat((long) (index - 3));
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8160U));
        break;
      case EGetScoreFactor.EGSF_Gather:
        switch (index)
        {
          case 0:
            tmpStr.Append(this.DM.mStringTable.GetStringByID(8139U));
            return;
          case 1:
            tmpStr.Append(this.DM.mStringTable.GetStringByID(8140U));
            return;
          case 2:
            tmpStr.Append(this.DM.mStringTable.GetStringByID(8141U));
            return;
          case 3:
            tmpStr.Append(this.DM.mStringTable.GetStringByID(8142U));
            return;
          case 4:
            tmpStr.Append(this.DM.mStringTable.GetStringByID(8143U));
            return;
          case 5:
            tmpStr.Append(this.DM.mStringTable.GetStringByID(8144U));
            return;
          default:
            return;
        }
      case EGetScoreFactor.EGSF_TrainingTrap:
        tmpStr.IntToFormat((long) (index + 1));
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8167U));
        break;
      case EGetScoreFactor.EGSF_NPC:
        if (index < 5)
        {
          tmpStr.IntToFormat((long) (index + 1));
          tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8134U));
          break;
        }
        tmpStr.IntToFormat((long) (index - 4));
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8135U));
        break;
      case EGetScoreFactor.EGSF_WonderOccupy:
        if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKSoloEvent || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalSoloEvent)
        {
          switch (index)
          {
            case 0:
              tmpStr.Append(this.DM.mStringTable.GetStringByID(9829U));
              return;
            case 1:
              tmpStr.Append(this.DM.mStringTable.GetStringByID(9830U));
              return;
            case 2:
              tmpStr.Append(this.DM.mStringTable.GetStringByID(9832U));
              return;
            case 3:
              tmpStr.Append(this.DM.mStringTable.GetStringByID(9833U));
              return;
            default:
              return;
          }
        }
        else
        {
          if (index == 0)
          {
            tmpStr.Append(this.DM.mStringTable.GetStringByID(9831U));
            break;
          }
          if (index != 1)
            break;
          tmpStr.Append(this.DM.mStringTable.GetStringByID(9834U));
          break;
        }
      case EGetScoreFactor.EGSF_KVKKillEnemy:
        if (index < 4)
        {
          tmpStr.IntToFormat((long) (index + 1));
          tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(9835U));
          break;
        }
        tmpStr.IntToFormat((long) (index - 3));
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(12006U));
        break;
      case EGetScoreFactor.EGSF_KVKNPC:
        if (index < 5)
        {
          tmpStr.IntToFormat((long) (index + 1));
          tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(9837U));
          break;
        }
        tmpStr.IntToFormat((long) (index - 4));
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(9836U));
        break;
      case EGetScoreFactor.EGSF_KVKGather:
        uint score1 = this.AM.GetAllianceSummonScore_SDataByFactor((byte) Factor, (byte) (index + 1)).Score1;
        tmpStr.IntToFormat((long) score1, bNumber: true);
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID((uint) (12015 + index)));
        break;
      case EGetScoreFactor.EGSF_Gamble:
        if (index == 1)
        {
          tmpStr.Append(this.DM.mStringTable.GetStringByID(9859U));
          break;
        }
        if (index != 0)
          break;
        tmpStr.Append(this.DM.mStringTable.GetStringByID(9860U));
        break;
      case EGetScoreFactor.EGSF_CompleteInfernalEvent:
        tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(14539U));
        break;
      case EGetScoreFactor.EGSF_MakePetBox:
        tmpStr.Append(this.DM.mStringTable.GetStringByID((uint) (17517 + index)));
        break;
    }
  }

  public void SetScoreFactorHintR_AS(EGetScoreFactor Factor, int index, CString tmpStr, int x)
  {
    tmpStr.Length = 0;
    switch (Factor)
    {
      case EGetScoreFactor.EGSF_TrainingSoldier:
        if (this.tmpData.KVKActiveType != EKVKActivityType.EKAT_MAX)
        {
          byte facotr = (byte) Factor;
          uint num = 0;
          switch (index)
          {
            case 0:
              num = this.AM.GetAllianceSummonScore_SDataByFactor(facotr, (byte) 1).Score1;
              break;
            case 1:
              num = this.AM.GetAllianceSummonScore_SDataByFactor(facotr, (byte) 2).Score1;
              break;
            case 2:
              num = this.AM.GetAllianceSummonScore_SDataByFactor(facotr, (byte) 3).Score1;
              break;
            case 3:
              num = this.AM.GetAllianceSummonScore_SDataByFactor(facotr, (byte) 4).Score1;
              break;
          }
          tmpStr.IntToFormat((long) num * (long) x, bNumber: true);
          break;
        }
        switch (index)
        {
          case 0:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 1:
            tmpStr.IntToFormat((long) (2 * x), bNumber: true);
            break;
          case 2:
            tmpStr.IntToFormat((long) (5 * x), bNumber: true);
            break;
          case 3:
            tmpStr.IntToFormat((long) (15 * x), bNumber: true);
            break;
        }
        break;
      case EGetScoreFactor.EGSF_Research:
        if (this.tmpData.KVKActiveType != EKVKActivityType.EKAT_MAX)
        {
          uint score1 = this.AM.GetAllianceSummonScore_SDataByFactor((byte) Factor, (byte) 1).Score1;
          tmpStr.IntToFormat((long) score1 * (long) x, bNumber: true);
          break;
        }
        tmpStr.IntToFormat((long) (1 * x), bNumber: true);
        break;
      case EGetScoreFactor.EGSF_Building:
        if (this.tmpData.KVKActiveType != EKVKActivityType.EKAT_MAX)
        {
          uint score1 = this.AM.GetAllianceSummonScore_SDataByFactor((byte) Factor, (byte) 1).Score1;
          tmpStr.IntToFormat((long) score1 * (long) x, bNumber: true);
          break;
        }
        tmpStr.IntToFormat((long) (1 * x), bNumber: true);
        break;
      case EGetScoreFactor.EGSF_KillTroop:
        switch (index)
        {
          case 0:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 1:
            tmpStr.IntToFormat((long) (2 * x), bNumber: true);
            break;
          case 2:
            tmpStr.IntToFormat((long) (5 * x), bNumber: true);
            break;
          case 3:
            tmpStr.IntToFormat((long) (15 * x), bNumber: true);
            break;
          case 4:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 5:
            tmpStr.IntToFormat((long) (2 * x), bNumber: true);
            break;
          case 6:
            tmpStr.IntToFormat((long) (5 * x), bNumber: true);
            break;
          case 7:
            tmpStr.IntToFormat((long) (15 * x), bNumber: true);
            break;
        }
        break;
      case EGetScoreFactor.EGSF_Gather:
        switch (index)
        {
          case 0:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 1:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 2:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 3:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 4:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 5:
            tmpStr.IntToFormat((long) (100 * x), bNumber: true);
            break;
        }
        break;
      case EGetScoreFactor.EGSF_TrainingTrap:
        switch (index)
        {
          case 0:
            tmpStr.IntToFormat((long) (1 * x), bNumber: true);
            break;
          case 1:
            tmpStr.IntToFormat((long) (2 * x), bNumber: true);
            break;
          case 2:
            tmpStr.IntToFormat((long) (5 * x), bNumber: true);
            break;
          case 3:
            tmpStr.IntToFormat((long) (15 * x), bNumber: true);
            break;
        }
        break;
      case EGetScoreFactor.EGSF_NPC:
        byte facotr1 = (byte) Factor;
        uint num1 = index >= 5 ? this.AM.GetAllianceSummonScore_SDataByFactor(facotr1, (byte) (index - 4)).Score2 : this.AM.GetAllianceSummonScore_SDataByFactor(facotr1, (byte) (index + 1)).Score1;
        tmpStr.IntToFormat((long) num1 * (long) x, bNumber: true);
        break;
      case EGetScoreFactor.EGSF_WonderOccupy:
        uint num2 = 0;
        byte facotr2 = (byte) Factor;
        if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKSoloEvent || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalSoloEvent)
        {
          switch (index)
          {
            case 0:
              num2 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr2, (byte) 1).Score2;
              break;
            case 1:
              num2 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr2, (byte) 1).Score1;
              break;
            case 2:
              num2 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr2, (byte) 2).Score2;
              break;
            case 3:
              num2 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr2, (byte) 2).Score1;
              break;
          }
        }
        else if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKAllianceEvent || this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KNormalAllianceEvent)
        {
          switch (index)
          {
            case 0:
              num2 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr2, (byte) 3).Score1;
              break;
            case 1:
              num2 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr2, (byte) 4).Score1;
              break;
          }
        }
        else if (this.tmpData.KVKActiveType == EKVKActivityType.EKAT_KvKEvent)
        {
          switch (index)
          {
            case 0:
              num2 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr2, (byte) 3).Score2;
              break;
            case 1:
              num2 = this.AM.GetAllianceSummonScore_SDataByFactor(facotr2, (byte) 4).Score2;
              break;
          }
        }
        tmpStr.IntToFormat((long) num2 * (long) x, bNumber: true);
        break;
      case EGetScoreFactor.EGSF_KVKKillEnemy:
        byte facotr3 = (byte) Factor;
        uint num3 = index >= 4 ? this.AM.GetAllianceSummonScore_SDataByFactor(facotr3, (byte) (index - 3)).Score2 : this.AM.GetAllianceSummonScore_SDataByFactor(facotr3, (byte) (index + 1)).Score2;
        tmpStr.IntToFormat((long) num3 * (long) x, bNumber: true);
        break;
      case EGetScoreFactor.EGSF_KVKNPC:
        byte facotr4 = (byte) Factor;
        uint num4 = index >= 5 ? this.AM.GetAllianceSummonScore_SDataByFactor(facotr4, (byte) (index - 4)).Score2 : this.AM.GetAllianceSummonScore_SDataByFactor(facotr4, (byte) (index + 1)).Score1;
        tmpStr.IntToFormat((long) num4 * (long) x, bNumber: true);
        break;
      case EGetScoreFactor.EGSF_KVKGather:
        uint score2 = this.AM.GetAllianceSummonScore_SDataByFactor((byte) Factor, (byte) (index + 1)).Score2;
        tmpStr.IntToFormat((long) score2 * (long) x, bNumber: true);
        break;
      case EGetScoreFactor.EGSF_Gamble:
        uint score1_1 = this.AM.GetAllianceSummonScore_SDataByFactor((byte) Factor, (byte) index).Score1;
        tmpStr.IntToFormat((long) score1_1 * (long) x, bNumber: true);
        break;
      case EGetScoreFactor.EGSF_CompleteInfernalEvent:
        uint score1_2 = this.AM.GetAllianceSummonScore_SDataByFactor((byte) Factor, (byte) 1).Score1;
        tmpStr.IntToFormat((long) score1_2 * (long) x, bNumber: true);
        break;
      case EGetScoreFactor.EGSF_MakePetBox:
        uint score1_3 = this.AM.GetAllianceSummonScore_SDataByFactor((byte) Factor, (byte) (index + 1)).Score1;
        tmpStr.IntToFormat((long) score1_3 * (long) x, bNumber: true);
        break;
    }
    tmpStr.AppendFormat(this.DM.mStringTable.GetStringByID(8145U));
  }

  public void HeroActionChang()
  {
    if ((Object) this.BossGO == (Object) null)
      return;
    int index = Random.Range(0, this.ANList.Count);
    byte an = (byte) this.ANList[index];
    AnimationClip animationClip = this.tmpAN.GetClip(AnimationUnit.ANIM_STRING[(int) an]);
    this.HeroAct = AnimationUnit.ANIM_STRING[(int) an];
    if (this.ANList[index] == AnimationUnit.AnimName.SKILL1 && (Object) this.tmpAN.GetClip(this.HeroAct + "_ch") != (Object) null)
      animationClip = (AnimationClip) null;
    if ((Object) animationClip != (Object) null)
      this.tmpAN.CrossFade(animationClip.name);
    this.ActionTimeRandom = 0.0f;
    this.ActionTime = 0.0f;
  }

  public void LoadAB(bool ReLoad = false)
  {
    if (ReLoad && (Object) this.AB != (Object) null)
    {
      if (this.AssetKey != 0)
        AssetManager.UnloadAssetBundle(this.AssetKey);
      if ((Object) this.BossGO != (Object) null)
        ModelLoader.Instance.Unload((Object) this.BossGO);
      this.AssetKey = 0;
      this.BossGO = (GameObject) null;
      this.AB = (AssetBundle) null;
      this.bABInitial = false;
    }
    CString Name = StringManager.Instance.StaticString1024();
    Name.IntToFormat((long) this.sHero.Modle, 5);
    Name.AppendFormat("Role/hero_{0}");
    this.AB = AssetManager.GetAssetBundle(Name, out this.AssetKey);
    if (!((Object) this.AB != (Object) null))
      return;
    this.AR = this.AB.LoadAsync("m", typeof (GameObject));
    this.bABInitial = false;
  }

  private float GetBestLineWidth(UIText tmpText, float MaxWidth, int minFontSize)
  {
    if ((Object) tmpText == (Object) null)
      return MaxWidth;
    while ((double) tmpText.preferredWidth > (double) MaxWidth && tmpText.fontSize > minFontSize)
    {
      --tmpText.fontSize;
      ((Graphic) tmpText).SetLayoutDirty();
    }
    if (tmpText.fontSize > minFontSize)
      return tmpText.preferredWidth;
    tmpText.fontSize = minFontSize;
    return MaxWidth;
  }

  private void CheckAllianceID()
  {
    if ((Object) this.ContentT == (Object) null || (Object) this.NoImgGO == (Object) null || (Object) this.NoText1 == (Object) null || (Object) this.NoText2 == (Object) null || !this.bSummonType)
      return;
    if (this.DM.RoleAlliance.Id == 0U)
    {
      this.SPT.GetChild(0).gameObject.SetActive(false);
      this.SPT.GetChild(1).gameObject.SetActive(false);
      this.SPT.GetChild(2).gameObject.SetActive(false);
      this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 364f);
      this.NoImgGO.SetActive(true);
      ((Component) this.NoText1).gameObject.SetActive(false);
      ((Component) this.NoText2).gameObject.SetActive(true);
      this.NoText2.text = this.DM.mStringTable.GetStringByID(1374U);
      ((Graphic) this.NoText2).color = ((Graphic) this.NoText1).color;
    }
    else if (this.tmpData.EventState != EActivityState.EAS_Prepare && (this.AM.AllianceSummonAllianceID == 0U || (int) this.DM.RoleAlliance.Id != (int) this.AM.AllianceSummonAllianceID))
    {
      this.SPT.GetChild(0).gameObject.SetActive(false);
      this.SPT.GetChild(1).gameObject.SetActive(false);
      this.SPT.GetChild(2).gameObject.SetActive(false);
      this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 364f);
      this.NoImgGO.SetActive(true);
      ((Component) this.NoText1).gameObject.SetActive(true);
      this.NoText1.text = this.DM.mStringTable.GetStringByID(1353U);
      ((Component) this.NoText2).gameObject.SetActive(true);
      this.NoText2.text = this.DM.mStringTable.GetStringByID(1354U);
      ((Graphic) this.NoText2).color = Color.white;
    }
    else
    {
      this.SPT.GetChild(0).gameObject.SetActive(true);
      this.SPT.GetChild(1).gameObject.SetActive(true);
      this.SPT.GetChild(2).gameObject.SetActive(true);
      this.NoImgGO.SetActive(false);
      ((Component) this.NoText1).gameObject.SetActive(false);
      ((Component) this.NoText2).gameObject.SetActive(false);
      this.ContentT.GetComponent<RectTransform>().sizeDelta = new Vector2(483f, 511f);
    }
  }

  private void SetPointTexture(byte point, Image numImg)
  {
    if (!this.bSummonType)
      return;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (Object) menu)
      return;
    if (point == byte.MaxValue)
    {
      numImg.sprite = menu.LoadSprite("UI_mall_x_001");
    }
    else
    {
      CString SpriteName = StringManager.Instance.StaticString1024();
      SpriteName.IntToFormat((long) point);
      SpriteName.AppendFormat("UI_mall_{0}_001");
      numImg.sprite = menu.LoadSprite(SpriteName);
    }
    ((MaskableGraphic) numImg).material = menu.LoadMaterial();
  }

  private void SetMonsterState()
  {
    if (!this.bSummonType || (Object) this.SummonFlash == (Object) null || (Object) this.SummonAlert == (Object) null)
      return;
    bool flag1 = this.AM.AllianceSummon_SummonData.MonsterEndTime > 0L;
    bool flag2 = this.AM.AllianceSummon_SummonData.CostPoint > (byte) 0 && (int) this.AM.AllianceSummon_SummonData.SummonPoint / (int) this.AM.AllianceSummon_SummonData.CostPoint >= 1;
    if (flag1)
      this.SummonFlash.SetActive(true);
    else
      this.SummonFlash.SetActive(false);
    if (flag1 || flag2)
      this.SummonAlert.SetActive(true);
    else
      this.SummonAlert.SetActive(false);
    if (this.tmpData.EventState != EActivityState.EAS_ReplayRanking || (Object) this.SummonTimeObj == (Object) null || (Object) this.RankReplayTitleText == (Object) null)
      return;
    if (!this.SummonTimeObj.activeInHierarchy)
      this.SummonTimeObj.SetActive(true);
    if (flag1 || flag2)
    {
      this.SummonTimeObj.transform.GetChild(1).gameObject.SetActive(true);
      this.SummonTimeObj.transform.GetChild(2).gameObject.SetActive(true);
      this.RankReplayTitleText.text = this.DM.mStringTable.GetStringByID(14521U);
    }
    else
    {
      this.SummonTimeObj.transform.GetChild(1).gameObject.SetActive(false);
      this.SummonTimeObj.transform.GetChild(2).gameObject.SetActive(false);
      if (this.nowStep > (byte) 0)
        this.RankReplayTitleText.text = this.DM.mStringTable.GetStringByID(14535U);
      else
        this.RankReplayTitleText.text = this.DM.mStringTable.GetStringByID(1594U);
    }
  }

  private void SetNPCCityStarObj()
  {
    if (!this.bSummonType || (Object) this.StarObj == (Object) null || (Object) this.StarObj2 == (Object) null)
      return;
    bool flag = true;
    for (int index = 0; index < 5; ++index)
    {
      SummonScoreData scoreSdataByFactor = this.AM.GetAllianceSummonScore_SDataByFactor((byte) 16, (byte) (index + 1));
      if ((uint) this.AM.NPCCityCombatTimes[index] < scoreSdataByFactor.Score2)
        flag = false;
    }
    this.StarObj.SetActive(!flag);
    this.StarObj2.SetActive(flag);
  }

  private void SetNPCCityCombatTimes(bool ForceSet = false)
  {
    if (!this.bSummonType || !((Component) this.HintT4).gameObject.activeInHierarchy && !ForceSet)
      return;
    int index1 = 1;
    for (int index2 = 0; index2 < 5; ++index2)
    {
      SummonScoreData scoreSdataByFactor = this.AM.GetAllianceSummonScore_SDataByFactor((byte) 16, (byte) (index2 + 1));
      bool flag = (uint) this.AM.NPCCityCombatTimes[index2] >= scoreSdataByFactor.Score2;
      if (flag)
        ((Graphic) this.RBText5[index1]).color = Color.yellow;
      else
        ((Graphic) this.RBText5[index1]).color = Color.white;
      int index3 = index1 + 1;
      if (flag)
        ((Graphic) this.RBText5[index3]).color = Color.yellow;
      else
        ((Graphic) this.RBText5[index3]).color = Color.white;
      int index4 = index3 + 1;
      this.Hint5Str[index4].Length = 0;
      if (flag)
      {
        this.Hint5Str[index4].Append(this.DM.mStringTable.GetStringByID(14543U));
        ((Graphic) this.RBText5[index4]).color = Color.yellow;
      }
      else
      {
        this.Hint5Str[index4].IntToFormat((long) (scoreSdataByFactor.Score2 - (uint) this.AM.NPCCityCombatTimes[index2]));
        this.Hint5Str[index4].AppendFormat(this.DM.mStringTable.GetStringByID(14542U));
        ((Graphic) this.RBText5[index4]).color = Color.white;
      }
      this.RBText5[index4].text = this.Hint5Str[index4].ToString();
      this.RBText5[index4].SetAllDirty();
      this.RBText5[index4].cachedTextGeneratorForLayout.Invalidate();
      index1 = index4 + 1;
    }
  }

  private void SetKVKReTime()
  {
    if ((Object) this.ReTimeText == (Object) null)
      return;
    if (this.tmpData.EventState != EActivityState.EAS_Run || this.AM.KVKReTime > this.tmpData.EventBeginTime + (long) this.tmpData.EventReqiureTIme)
    {
      if (!((Component) this.ReTimeImage).gameObject.activeInHierarchy && !((Component) this.ReTimeText).gameObject.activeInHierarchy)
        return;
      ((Component) this.ReTimeImage).gameObject.SetActive(false);
      ((Component) this.ReTimeText).gameObject.SetActive(false);
    }
    else
    {
      long sec = this.AM.KVKReTime - this.AM.ServerEventTime;
      if (sec < 0L)
        sec = 0L;
      this.ReTimeStr.Length = 0;
      GameConstants.GetTimeString(this.ReTimeStr, (uint) sec, hideTimeIfDays: true, showZeroHour: false);
      this.ReTimeText.text = this.ReTimeStr.ToString();
      this.ReTimeText.SetAllDirty();
      this.ReTimeText.cachedTextGenerator.Invalidate();
    }
  }

  private void SetReLineAndPic()
  {
    if ((Object) this.ReImageTarget == (Object) null)
      return;
    if ((Object) this.HintT3 != (Object) null)
      ((Component) this.HintT3).gameObject.SetActive(false);
    if ((Object) this.HintT != (Object) null)
      ((Component) this.HintT).gameObject.SetActive(false);
    if (this.tmpData.EventState != EActivityState.EAS_Run && this.tmpData.EventState != EActivityState.EAS_Prepare)
    {
      this.KVKLine1.SetActive(false);
      this.KVKLine2.SetActive(false);
      ((Component) this.ReImageTarget).gameObject.SetActive(false);
      ((Component) this.ReImageDevil).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.ReImageTarget).gameObject.SetActive(true);
      ((Component) this.ReImageDevil).gameObject.SetActive(true);
      if (this.AM.KVKHuntOrder == (byte) 2)
      {
        ((Graphic) this.ReImageTarget).rectTransform.anchoredPosition = new Vector2(-167f, 174.5f);
        ((Graphic) this.ReImageDevil).rectTransform.anchoredPosition = new Vector2(166f, 175f);
        ((Transform) ((Graphic) this.ReImageDevil).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
        this.KVKLine1.SetActive(false);
        this.KVKLine2.SetActive(true);
      }
      else
      {
        ((Graphic) this.ReImageTarget).rectTransform.anchoredPosition = new Vector2(167f, 174.5f);
        ((Graphic) this.ReImageDevil).rectTransform.anchoredPosition = new Vector2(-166f, 175f);
        ((Transform) ((Graphic) this.ReImageDevil).rectTransform).localScale = Vector3.one;
        this.KVKLine1.SetActive(true);
        this.KVKLine2.SetActive(false);
      }
    }
  }
}
