// Decompiled with JetBrains decompiler
// Type: UIAlliance_Mobilization
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIAlliance_Mobilization : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private MobilizationManager MM;
  private ActivityManager AM;
  private Transform GameT;
  private Transform Tmp;
  private Transform[] Kind_T = new Transform[2];
  private Transform[][] ItemKind_T = new Transform[3][];
  private RectTransform Img_LvBar_RT;
  private RectTransform Img_MissionBar_RT;
  private RectTransform m_ItemConet;
  private ScrollPanel m_ScrollPanel;
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[3];
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private Door door;
  private UIButton btn_EXIT;
  private UIButton btn_I;
  private UIButton btn_Hint;
  private UIButton btn_Add;
  private UIButton btn_Start;
  private UIButton btn_Report;
  private UIButton btn_Rank1;
  private UIButton btn_Rank2;
  private UIButton btn_Reward;
  private UIButton btn_Reward2;
  private UIButton btn_GetReward;
  private UIButton btn_GiveUp;
  private UIButton btn_RankHint;
  private UIButton[][] btn_Delete = new UIButton[3][];
  private UIButton[][] btn_ItemSelect = new UIButton[3][];
  private Image Img_Mission;
  private Image Img_MissionKind;
  private Image Img_MissionScore;
  private Image Img_Missionstatus;
  private Image Img_MissionTime;
  private Image Img_MissionCDTime;
  private Image Img_LVMax;
  private Image Img_HintBG;
  private Image Img_Hint;
  private Image Img_ActivityTime;
  private Image Img_ActivityEnd;
  private Image Img_MissionBG;
  private Image Img_GetRewardTime;
  private Image Img_LBG;
  private Image Img_RewardOK;
  private Image Img_GetReward;
  private Image Img_Report;
  private Image[] Img_Bar = new Image[2];
  private Image[] Img_RewardBG = new Image[2];
  private Image[][] Img_ItemFrame = new Image[3][];
  private Image[][] Img_ItemIcon = new Image[3][];
  private Image[][] Img_ItemP1Icon = new Image[3][];
  private Image[][] Img_ItemP1Mission = new Image[3][];
  private Image[][] Img_ItemP1Score = new Image[3][];
  private Image[][] Img_ItemP1OK = new Image[3][];
  private Image Img_MoreRewards;
  private Image Img_AllianceRankBG;
  private Image Img_TitleBG;
  private UIText text_Title;
  private UIText text_MobilizationNum;
  private UIText text_MissionCount;
  private UIText text_Lv;
  private UIText text_LvValue;
  private UIText text_Kind;
  private UIText text_Kind1;
  private UIText text_MissionTime;
  private UIText text_Missionstatus;
  private UIText text_Empty;
  private UIText text_Hint;
  private UIText text_Start;
  private UIText text_Report;
  private UIText text_GiveUp;
  private UIText text_RewardTitle;
  private UIText text_GetRewardTime;
  private UIText text_AllianceReward;
  private UIText text_RewardNum;
  private UIText text_Rewardstr;
  private UIText text_RewardOK;
  private UIText text_GetReward;
  private UIText text_TimeBar;
  private UIText[] text_Time = new UIText[2];
  private UIText[] text_NowScore = new UIText[2];
  private UIText[] text_NextScore = new UIText[2];
  private UIText[] text_MissionCDTime = new UIText[2];
  private UIText[] text_Info = new UIText[3];
  private UIText[][] text_ItemTime = new UIText[3][];
  private UIText[][] text_ItemValue = new UIText[3][];
  private UIText[][] text_ItemP1Score = new UIText[3][];
  private UIText[][] text_ItemNoMission = new UIText[3][];
  private UIText text_Resultstr;
  private UIText text_Result;
  private CString Cstr_Lv;
  private CString Cstr_LvValue;
  private CString Cstr_ActivityTime;
  private CString Cstr_NowScore;
  private CString Cstr_NextScore;
  private CString Cstr_MobilizationNum;
  private CString Cstr_MissionTime;
  private CString Cstr_MissionCDTime;
  private CString Cstr_MissionCount;
  private CString Cstr_Hint;
  private CString Cstr_TimeBar;
  private CString Cstr_GetRewardTime;
  private CString Cstr_RewardNum;
  private CString Cstr_RankHint;
  private CString Cstr_Result;
  private CString Cstr_RankResult;
  private CString[] Cstr_Info = new CString[2];
  private CString[][] Cstr_ItemTime = new CString[3][];
  private CString[][] Cstr_ItemValue = new CString[3][];
  private Material m_Mat;
  private UISpritesArray SArray;
  private List<float> tmplist = new List<float>();
  private bool bOpenEnd;
  private long tmpTime;
  private MobilizationMissionData mMMissionData;
  private MobilizationDegreeData mMDData;
  private float tmpAddTime;
  private int tmpAddCount = 10;
  private float ShowGetReward;
  private float ShowReport;
  private float ShowItemF;
  private Color mColor_G = new Color(0.361f, 0.953f, 0.325f);
  private Color mColor_R = new Color(1f, 0.369f, 0.439f);
  private Color mColor_Info = new Color(1f, 0.968f, 0.6f);
  private int tmpItemNum;
  private bool bStartAddSend;
  private UIAlliance_Rank RankObj = new UIAlliance_Rank();

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.MM = MobilizationManager.Instance;
    this.AM = ActivityManager.Instance;
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.GameT = this.gameObject.transform;
    this.m_Mat = this.door.LoadMaterial();
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.tmpAddCount = this.MM.RSAnimationItemID.Length / 3 + 1;
    this.Cstr_Lv = StringManager.Instance.SpawnString();
    this.Cstr_LvValue = StringManager.Instance.SpawnString();
    this.Cstr_ActivityTime = StringManager.Instance.SpawnString();
    this.Cstr_NowScore = StringManager.Instance.SpawnString();
    this.Cstr_NextScore = StringManager.Instance.SpawnString();
    this.Cstr_MobilizationNum = StringManager.Instance.SpawnString();
    this.Cstr_MissionTime = StringManager.Instance.SpawnString();
    this.Cstr_MissionCDTime = StringManager.Instance.SpawnString();
    this.Cstr_MissionCount = StringManager.Instance.SpawnString(100);
    this.Cstr_Hint = StringManager.Instance.SpawnString(200);
    this.Cstr_TimeBar = StringManager.Instance.SpawnString();
    this.Cstr_RewardNum = StringManager.Instance.SpawnString(200);
    this.Cstr_RankHint = StringManager.Instance.SpawnString(200);
    this.Cstr_Result = StringManager.Instance.SpawnString(200);
    this.Cstr_RankResult = StringManager.Instance.SpawnString(300);
    this.Cstr_GetRewardTime = StringManager.Instance.SpawnString();
    this.Cstr_Info[0] = StringManager.Instance.SpawnString(100);
    this.Cstr_Info[1] = StringManager.Instance.SpawnString();
    for (int index1 = 0; index1 < 3; ++index1)
    {
      this.ItemKind_T[index1] = new Transform[9];
      this.btn_ItemSelect[index1] = new UIButton[3];
      this.btn_Delete[index1] = new UIButton[3];
      this.Img_ItemFrame[index1] = new Image[3];
      this.Img_ItemIcon[index1] = new Image[3];
      this.Img_ItemP1Icon[index1] = new Image[3];
      this.Img_ItemP1Mission[index1] = new Image[3];
      this.Img_ItemP1Score[index1] = new Image[3];
      this.Img_ItemP1OK[index1] = new Image[3];
      this.text_ItemTime[index1] = new UIText[3];
      this.text_ItemValue[index1] = new UIText[3];
      this.text_ItemP1Score[index1] = new UIText[3];
      this.text_ItemNoMission[index1] = new UIText[3];
      this.Cstr_ItemTime[index1] = new CString[3];
      this.Cstr_ItemValue[index1] = new CString[3];
      for (int index2 = 0; index2 < 3; ++index2)
      {
        this.Cstr_ItemTime[index1][index2] = StringManager.Instance.SpawnString();
        this.Cstr_ItemValue[index1][index2] = StringManager.Instance.SpawnString();
      }
    }
    this.Tmp = this.GameT.GetChild(0);
    this.Img_TitleBG = this.Tmp.GetChild(0).GetChild(3).GetComponent<Image>();
    if (this.DM.RoleAlliance.AMRank > (byte) 0 && (int) this.DM.RoleAlliance.AMRank + 3 < this.SArray.m_Sprites.Length)
      this.Img_TitleBG.sprite = this.SArray.m_Sprites[(int) this.DM.RoleAlliance.AMRank + 3];
    ((Component) this.Img_TitleBG).gameObject.SetActive(true);
    this.text_Title = this.Tmp.GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.DM.mStringTable.GetStringByID(1339U);
    this.btn_I = this.Tmp.GetChild(0).GetChild(4).GetComponent<UIButton>();
    if (this.GUIM.IsArabic)
      ((Component) this.btn_I).gameObject.AddComponent<ArabicItemTextureRot>();
    this.btn_I.m_Handler = (IUIButtonClickHandler) this;
    this.btn_I.m_BtnID1 = 1;
    this.btn_I.m_EffectType = e_EffectType.e_Scale;
    this.btn_I.transition = (Selectable.Transition) 0;
    this.Img_LBG = this.Tmp.GetChild(0).GetChild(5).GetComponent<Image>();
    this.Img_AllianceRankBG = this.Tmp.GetChild(0).GetChild(6).GetComponent<Image>();
    this.GUIM.SetAllyRankImage(this.Img_AllianceRankBG, this.DM.RoleAlliance.AMRank);
    ((Component) this.Img_AllianceRankBG).gameObject.SetActive(true);
    this.btn_RankHint = this.Tmp.GetChild(0).GetChild(6).GetChild(0).GetComponent<UIButton>();
    this.btn_RankHint.m_Handler = (IUIButtonClickHandler) this;
    this.btn_RankHint.m_BtnID1 = 13;
    UIButtonHint uiButtonHint1 = ((Component) this.btn_RankHint).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    this.Img_ActivityTime = this.Tmp.GetChild(1).GetComponent<Image>();
    ((Component) this.Img_ActivityTime).gameObject.SetActive(false);
    this.Img_HintBG = this.Tmp.GetChild(1).GetChild(0).GetComponent<Image>();
    this.btn_Hint = this.Tmp.GetChild(1).GetChild(0).GetChild(0).GetComponent<UIButton>();
    this.btn_Hint.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Hint.m_BtnID1 = 4;
    this.btn_Hint.m_EffectType = e_EffectType.e_Scale;
    this.btn_Hint.transition = (Selectable.Transition) 0;
    UIButtonHint uiButtonHint2 = ((Component) this.btn_Hint).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint2.m_Handler = (MonoBehaviour) this;
    this.Img_Hint = this.Tmp.GetChild(8).GetComponent<Image>();
    this.text_Hint = this.Tmp.GetChild(8).GetChild(0).GetComponent<UIText>();
    this.text_Hint.font = this.TTFont;
    uiButtonHint2.ControlFadeOut = ((Component) this.Img_Hint).gameObject;
    this.Cstr_Hint.ClearString();
    this.Cstr_Hint.IntToFormat((long) this.MM.involvedMember);
    this.Cstr_Hint.AppendFormat(this.DM.mStringTable.GetStringByID(1341U));
    this.text_Hint.text = this.Cstr_Hint.ToString();
    this.text_Hint.SetAllDirty();
    this.text_Hint.cachedTextGenerator.Invalidate();
    this.text_Hint.cachedTextGeneratorForLayout.Invalidate();
    ((Graphic) this.text_Hint).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Hint).rectTransform.sizeDelta.x, this.text_Hint.preferredHeight + 1f);
    ((Graphic) this.Img_Hint).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Hint).rectTransform.sizeDelta.x, this.text_Hint.preferredHeight + 11f);
    this.text_MobilizationNum = this.Tmp.GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
    this.text_MobilizationNum.font = this.TTFont;
    this.Cstr_MobilizationNum.ClearString();
    this.Cstr_MobilizationNum.IntToFormat((long) this.MM.involvedMember);
    this.Cstr_MobilizationNum.AppendFormat(this.DM.mStringTable.GetStringByID(1340U));
    this.text_MobilizationNum.text = this.Cstr_MobilizationNum.ToString();
    this.text_MobilizationNum.SetAllDirty();
    this.text_MobilizationNum.cachedTextGenerator.Invalidate();
    this.Img_LvBar_RT = this.Tmp.GetChild(1).GetChild(1).GetChild(0).GetComponent<RectTransform>();
    this.Img_LvBar_RT.sizeDelta = new Vector2(214f, this.Img_LvBar_RT.sizeDelta.y);
    this.Img_LVMax = this.Tmp.GetChild(1).GetChild(1).GetChild(1).GetComponent<Image>();
    this.Img_Bar[0] = this.Tmp.GetChild(1).GetChild(1).GetChild(2).GetComponent<Image>();
    this.Img_Bar[1] = this.Tmp.GetChild(1).GetChild(1).GetChild(3).GetComponent<Image>();
    this.text_LvValue = this.Tmp.GetChild(1).GetChild(1).GetChild(4).GetComponent<UIText>();
    this.text_LvValue.font = this.TTFont;
    this.Tmp.GetChild(1).GetChild(2);
    this.text_Lv = this.Tmp.GetChild(1).GetChild(2).GetChild(0).GetComponent<UIText>();
    this.text_Lv.font = this.TTFont;
    this.Cstr_Lv.ClearString();
    this.text_Lv.text = this.Cstr_Lv.ToString();
    this.text_Lv.SetAllDirty();
    this.text_Lv.cachedTextGenerator.Invalidate();
    this.btn_Reward = this.Tmp.GetChild(1).GetChild(3).GetComponent<UIButton>();
    if (this.GUIM.IsArabic)
      ((Component) this.btn_Reward).gameObject.AddComponent<ArabicItemTextureRot>();
    this.btn_Reward.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Reward.m_BtnID1 = 10;
    this.btn_Reward.m_EffectType = e_EffectType.e_Scale;
    this.btn_Reward.transition = (Selectable.Transition) 0;
    this.btn_Reward2 = this.Tmp.GetChild(1).GetChild(4).GetComponent<UIButton>();
    this.btn_Reward2.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Reward2.m_BtnID1 = 10;
    for (int index = 0; index < 2; ++index)
    {
      Transform child1 = this.Tmp.GetChild(1).GetChild(index + 5);
      this.text_Time[index] = child1.GetComponent<UIText>();
      this.text_Time[index].font = this.TTFont;
      Transform child2 = this.Tmp.GetChild(1).GetChild(index + 7);
      this.text_NowScore[index] = child2.GetComponent<UIText>();
      this.text_NowScore[index].font = this.TTFont;
      Transform child3 = this.Tmp.GetChild(1).GetChild(index + 9);
      this.text_NextScore[index] = child3.GetComponent<UIText>();
      this.text_NextScore[index].font = this.TTFont;
    }
    this.text_Time[0].text = this.DM.mStringTable.GetStringByID(8110U);
    this.Cstr_ActivityTime.ClearString();
    if (this.AM.AllyMobilizationData.EventCountTime > 86400L)
    {
      this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime / 86400L);
      this.Cstr_ActivityTime.AppendFormat("{0}d");
    }
    else
    {
      this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime / 3600L, 2);
      this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime % 3600L / 60L, 2);
      this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime % 60L, 2);
      this.Cstr_ActivityTime.AppendFormat("{0}:{1}:{2}");
    }
    this.text_Time[1].text = this.Cstr_ActivityTime.ToString();
    this.text_Time[1].SetAllDirty();
    this.text_Time[1].cachedTextGenerator.Invalidate();
    this.text_NowScore[0].text = this.DM.mStringTable.GetStringByID(8116U);
    this.Cstr_NowScore.ClearString();
    StringManager.IntToStr(this.Cstr_NowScore, (long) this.MM.AMScore, bNumber: true);
    this.text_NowScore[1].text = this.Cstr_NowScore.ToString();
    this.text_NowScore[1].SetAllDirty();
    this.text_NowScore[1].cachedTextGenerator.Invalidate();
    this.text_NextScore[0].text = this.DM.mStringTable.GetStringByID(8117U);
    this.Cstr_NextScore.ClearString();
    this.tmpItemNum = (int) this.DM.RoleAlliance.AMMaxDegree;
    if ((int) this.MM.AMCompleteDegree < this.tmpItemNum)
      StringManager.IntToStr(this.Cstr_NextScore, (long) (this.MM.CompleteScore - this.MM.AMScore), bNumber: true);
    else
      StringManager.IntToStr(this.Cstr_NextScore, 0L, bNumber: true);
    this.text_NextScore[1].text = this.Cstr_NextScore.ToString();
    this.text_NextScore[1].SetAllDirty();
    this.text_NextScore[1].cachedTextGenerator.Invalidate();
    this.Cstr_Lv.ClearString();
    StringManager.IntToStr(this.Cstr_Lv, (long) this.MM.AMCompleteDegree);
    this.text_Lv.text = this.Cstr_Lv.ToString();
    this.text_Lv.SetAllDirty();
    this.text_Lv.cachedTextGenerator.Invalidate();
    this.Cstr_LvValue.ClearString();
    if ((int) this.MM.AMCompleteDegree == this.tmpItemNum)
    {
      this.mMDData = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int) this.MM.AMCompleteDegree - 1);
      StringManager.IntToStr(this.Cstr_LvValue, (long) this.mMDData.MissionDegreeScore, bNumber: true);
      ((Graphic) this.text_LvValue).color = new Color(1f, 0.945f, 0.204f);
    }
    else
      StringManager.IntToStr(this.Cstr_LvValue, (long) this.MM.CompleteScore, bNumber: true);
    this.text_LvValue.text = this.Cstr_LvValue.ToString();
    this.text_LvValue.SetAllDirty();
    this.text_LvValue.cachedTextGenerator.Invalidate();
    if (this.MM.CompleteScore != 0U)
    {
      if (this.MM.AMCompleteDegree == (byte) 0)
      {
        this.Img_LvBar_RT.sizeDelta = new Vector2((float) (214.0 * ((double) this.MM.AMScore / (double) this.MM.CompleteScore)), this.Img_LvBar_RT.sizeDelta.y);
        ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition = new Vector2((float) (11.5 + 214.0 * ((double) this.MM.AMScore / (double) this.MM.CompleteScore)), ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition.y);
      }
      else
      {
        this.mMDData = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int) this.MM.AMCompleteDegree - 1);
        if ((int) this.mMDData.MissionDegreeScore == (int) this.MM.AMScore)
        {
          this.Img_LvBar_RT.sizeDelta = new Vector2(0.0f, this.Img_LvBar_RT.sizeDelta.y);
          ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition = new Vector2(11.5f, ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition.y);
        }
        else
        {
          this.Img_LvBar_RT.sizeDelta = new Vector2((float) (214.0 * ((double) (this.MM.AMScore - this.mMDData.MissionDegreeScore) / (double) (this.MM.CompleteScore - this.mMDData.MissionDegreeScore))), this.Img_LvBar_RT.sizeDelta.y);
          ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition = new Vector2((float) (11.5 + 214.0 * (double) ((float) (this.MM.AMScore - this.mMDData.MissionDegreeScore) / (float) (this.MM.CompleteScore - this.mMDData.MissionDegreeScore))), ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition.y);
        }
      }
    }
    else
      this.Img_LvBar_RT.sizeDelta = new Vector2(0.0f, this.Img_LvBar_RT.sizeDelta.y);
    if ((int) this.MM.AMCompleteDegree == this.tmpItemNum)
    {
      ((Component) this.Img_LVMax).gameObject.SetActive(true);
      this.Img_LvBar_RT.sizeDelta = new Vector2(214f, this.Img_LvBar_RT.sizeDelta.y);
      ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition = new Vector2(225.5f, ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition.y);
    }
    this.Img_ActivityEnd = this.Tmp.GetChild(2).GetComponent<Image>();
    this.Img_RewardBG[0] = this.Tmp.GetChild(2).GetChild(0).GetComponent<Image>();
    this.Img_RewardBG[1] = this.Tmp.GetChild(2).GetChild(1).GetComponent<Image>();
    this.btn_GetReward = this.Tmp.GetChild(2).GetChild(2).GetComponent<UIButton>();
    this.btn_GetReward.m_Handler = (IUIButtonClickHandler) this;
    this.btn_GetReward.m_BtnID1 = 11;
    this.btn_GetReward.m_EffectType = e_EffectType.e_Scale;
    this.btn_GetReward.transition = (Selectable.Transition) 0;
    this.Img_GetReward = this.Tmp.GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>();
    this.text_GetReward = this.Tmp.GetChild(2).GetChild(2).GetChild(1).GetComponent<UIText>();
    this.text_GetReward.font = this.TTFont;
    this.text_GetReward.text = this.DM.mStringTable.GetStringByID(776U);
    this.Img_GetRewardTime = this.Tmp.GetChild(2).GetChild(3).GetComponent<Image>();
    this.text_GetRewardTime = this.Tmp.GetChild(2).GetChild(3).GetChild(0).GetComponent<UIText>();
    this.text_GetRewardTime.font = this.TTFont;
    this.Cstr_GetRewardTime.ClearString();
    long num = 0;
    if (this.AM.AllyMobilizationData.EventState == EActivityState.EAS_ReplayRanking)
      num = this.AM.AllyMobilizationData.EventCountTime;
    if (num < 0L)
      num = 0L;
    if (num > 86400L)
    {
      this.Cstr_GetRewardTime.IntToFormat(num / 86400L);
      this.Cstr_GetRewardTime.AppendFormat("{0}d");
    }
    else
    {
      this.Cstr_GetRewardTime.IntToFormat(num / 3600L, 2);
      this.Cstr_GetRewardTime.IntToFormat(num % 3600L / 60L, 2);
      this.Cstr_GetRewardTime.IntToFormat(num % 60L, 2);
      this.Cstr_GetRewardTime.AppendFormat("{0}:{1}:{2}");
    }
    this.text_GetRewardTime.text = this.Cstr_GetRewardTime.ToString();
    this.text_GetRewardTime.SetAllDirty();
    this.text_GetRewardTime.cachedTextGenerator.Invalidate();
    this.Img_RewardOK = this.Tmp.GetChild(2).GetChild(4).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.Img_RewardOK).gameObject.AddComponent<ArabicItemTextureRot>();
    this.text_RewardOK = this.Tmp.GetChild(2).GetChild(4).GetChild(0).GetComponent<UIText>();
    this.text_RewardOK.font = this.TTFont;
    this.text_RewardOK.text = this.DM.mStringTable.GetStringByID(7012U);
    this.text_AllianceReward = this.Tmp.GetChild(2).GetChild(5).GetComponent<UIText>();
    this.text_AllianceReward.font = this.TTFont;
    this.text_AllianceReward.text = this.DM.mStringTable.GetStringByID(747U);
    this.text_RewardTitle = this.Tmp.GetChild(2).GetChild(6).GetComponent<UIText>();
    this.text_RewardTitle.font = this.TTFont;
    this.text_RewardTitle.text = this.DM.mStringTable.GetStringByID(1371U);
    this.text_RewardNum = this.Tmp.GetChild(2).GetChild(7).GetComponent<UIText>();
    this.text_RewardNum.font = this.TTFont;
    this.text_RewardNum.text = this.DM.mStringTable.GetStringByID(1594U);
    this.text_Result = this.Tmp.GetChild(2).GetChild(8).GetComponent<UIText>();
    this.text_Result.font = this.TTFont;
    this.Img_MissionBG = this.Tmp.GetChild(3).GetComponent<Image>();
    this.Kind_T[0] = this.Tmp.GetChild(3).GetChild(0);
    this.text_Kind = this.Kind_T[0].GetChild(0).GetComponent<UIText>();
    this.text_Kind.font = this.TTFont;
    this.text_Kind1 = this.Kind_T[0].GetChild(1).GetComponent<UIText>();
    this.text_Kind1.font = this.TTFont;
    this.Kind_T[1] = this.Tmp.GetChild(3).GetChild(1);
    this.Img_Mission = this.Kind_T[1].GetChild(0).GetChild(0).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.Img_Mission).gameObject.AddComponent<ArabicItemTextureRot>();
    ((MaskableGraphic) this.Img_Mission).material = this.GUIM.GetLeagueGO_iconMaterial();
    this.Img_MissionKind = this.Kind_T[1].GetChild(1).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.Img_MissionKind).gameObject.AddComponent<ArabicItemTextureRot>();
    ((MaskableGraphic) this.Img_MissionKind).material = this.GUIM.GetFrameMaterial();
    this.Img_MissionScore = this.Kind_T[1].GetChild(2).GetComponent<Image>();
    this.text_Info[2] = this.Kind_T[1].GetChild(2).GetChild(0).GetComponent<UIText>();
    this.text_Info[2].font = this.TTFont;
    this.Img_MissionTime = this.Kind_T[1].GetChild(3).GetComponent<Image>();
    this.text_MissionTime = this.Kind_T[1].GetChild(3).GetChild(0).GetComponent<UIText>();
    this.text_MissionTime.font = this.TTFont;
    this.btn_Start = this.Kind_T[1].GetChild(4).GetComponent<UIButton>();
    this.btn_Start.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Start.m_BtnID1 = 6;
    this.btn_Start.m_EffectType = e_EffectType.e_Scale;
    this.btn_Start.transition = (Selectable.Transition) 0;
    this.text_Start = this.Kind_T[1].GetChild(4).GetChild(0).GetComponent<UIText>();
    this.text_Start.font = this.TTFont;
    this.text_Start.text = this.DM.mStringTable.GetStringByID(1541U);
    this.btn_Report = this.Kind_T[1].GetChild(5).GetComponent<UIButton>();
    this.btn_Report.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Report.m_BtnID1 = 7;
    this.btn_Report.m_EffectType = e_EffectType.e_Scale;
    this.btn_Report.transition = (Selectable.Transition) 0;
    this.Img_Report = this.Kind_T[1].GetChild(5).GetChild(0).GetComponent<Image>();
    this.text_Report = this.Kind_T[1].GetChild(5).GetChild(1).GetComponent<UIText>();
    this.text_Report.font = this.TTFont;
    this.text_Report.text = this.DM.mStringTable.GetStringByID(1377U);
    this.btn_GiveUp = this.Kind_T[1].GetChild(6).GetComponent<UIButton>();
    this.btn_GiveUp.m_Handler = (IUIButtonClickHandler) this;
    this.btn_GiveUp.m_BtnID1 = 12;
    this.btn_GiveUp.m_EffectType = e_EffectType.e_Scale;
    this.btn_GiveUp.transition = (Selectable.Transition) 0;
    this.text_GiveUp = this.Kind_T[1].GetChild(6).GetChild(0).GetComponent<UIText>();
    this.text_GiveUp.font = this.TTFont;
    this.text_GiveUp.text = this.DM.mStringTable.GetStringByID(5880U);
    this.Img_Missionstatus = this.Kind_T[1].GetChild(7).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.Img_Missionstatus).gameObject.AddComponent<ArabicItemTextureRot>();
    this.text_Missionstatus = this.Kind_T[1].GetChild(7).GetChild(0).GetComponent<UIText>();
    this.text_Missionstatus.font = this.TTFont;
    this.Img_MissionBar_RT = this.Kind_T[1].GetChild(8).GetChild(0).GetComponent<RectTransform>();
    this.Img_MissionBar_RT.sizeDelta = new Vector2(0.0f, this.Img_MissionBar_RT.sizeDelta.y);
    this.text_TimeBar = this.Kind_T[1].GetChild(8).GetChild(1).GetComponent<UIText>();
    this.text_TimeBar.font = this.TTFont;
    this.Img_MissionCDTime = this.Kind_T[1].GetChild(9).GetComponent<Image>();
    for (int index = 0; index < 2; ++index)
    {
      Transform child = this.Kind_T[1].GetChild(9).GetChild(index);
      this.text_MissionCDTime[index] = child.GetComponent<UIText>();
      this.text_MissionCDTime[index].font = this.TTFont;
    }
    this.text_MissionCDTime[0].text = this.DM.mStringTable.GetStringByID(1347U);
    for (int index = 0; index < 2; ++index)
    {
      Transform child = this.Kind_T[1].GetChild(10 + index);
      this.text_Info[index] = child.GetComponent<UIText>();
      this.text_Info[index].font = this.TTFont;
    }
    this.m_ScrollPanel = this.Tmp.GetChild(3).GetChild(2).GetComponent<ScrollPanel>();
    Transform child4 = this.Tmp.GetChild(3).GetChild(3);
    for (int index = 0; index < 3; ++index)
    {
      UIButton component1 = child4.GetChild(index).GetComponent<UIButton>();
      component1.m_Handler = (IUIButtonClickHandler) this;
      component1.m_BtnID1 = 3;
      Image component2 = child4.GetChild(index).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
      if (this.GUIM.IsArabic)
        ((Component) component2).gameObject.AddComponent<ArabicItemTextureRot>();
      ((MaskableGraphic) component2).material = this.GUIM.GetLeagueGO_iconMaterial();
      child4.GetChild(index).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>().font = this.TTFont;
      Image component3 = child4.GetChild(index).GetChild(0).GetChild(0).GetChild(3).GetComponent<Image>();
      if (this.GUIM.IsArabic)
        ((Component) component3).gameObject.AddComponent<ArabicItemTextureRot>();
      UIText component4 = child4.GetChild(index).GetChild(0).GetChild(1).GetComponent<UIText>();
      component4.font = this.TTFont;
      component4.text = this.DM.mStringTable.GetStringByID(1343U);
      UIText component5 = child4.GetChild(index).GetChild(0).GetChild(2).GetComponent<UIText>();
      component5.font = this.TTFont;
      component5.text = this.DM.mStringTable.GetStringByID(1342U);
      UIButton component6 = child4.GetChild(index).GetChild(1).GetChild(1).GetComponent<UIButton>();
      component6.m_Handler = (IUIButtonClickHandler) this;
      component6.m_BtnID1 = 2;
      component6.m_EffectType = e_EffectType.e_Scale;
      component6.transition = (Selectable.Transition) 0;
      Image component7 = child4.GetChild(index).GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>();
      if (this.GUIM.IsArabic)
        ((Component) component7).gameObject.AddComponent<ArabicItemTextureRot>();
      ((MaskableGraphic) component7).material = this.GUIM.GetLeagueGO_iconMaterial();
      child4.GetChild(index).GetChild(1).GetChild(3).GetChild(0).GetComponent<UIText>().font = this.TTFont;
      ((Graphic) child4.GetChild(index).GetChild(2).GetComponent<Image>()).color = Color.gray;
      child4.GetChild(index).GetChild(2).GetChild(1).GetComponent<UIText>().font = this.TTFont;
    }
    this.tmplist.Clear();
    for (int index = 0; index < 7; ++index)
      this.tmplist.Add(224f);
    this.m_ScrollPanel.IntiScrollPanel(365f, 0.0f, 0.0f, this.tmplist, 3, (IUpDateScrollPanel) this);
    this.m_ItemConet = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
    this.m_ScrollPanel.GoTo(this.MM.mMobilizationScroll, this.MM.mMobilizationScroll_Y);
    this.btn_Add = this.Tmp.GetChild(4).GetChild(2).GetComponent<UIButton>();
    this.btn_Add.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Add.m_BtnID1 = 5;
    this.btn_Add.m_EffectType = e_EffectType.e_Scale;
    this.btn_Add.transition = (Selectable.Transition) 0;
    this.text_MissionCount = this.Tmp.GetChild(4).GetChild(3).GetComponent<UIText>();
    this.text_MissionCount.font = this.TTFont;
    this.Cstr_MissionCount.ClearString();
    this.Cstr_MissionCount.IntToFormat((long) this.MM.availableMission, bNumber: true);
    this.Cstr_MissionCount.AppendFormat(this.DM.mStringTable.GetStringByID(1345U));
    this.text_MissionCount.text = this.Cstr_MissionCount.ToString();
    ((Component) this.text_MissionCount).gameObject.SetActive(false);
    this.text_Empty = this.Tmp.GetChild(4).GetChild(4).GetComponent<UIText>();
    this.text_Empty.font = this.TTFont;
    this.text_Rewardstr = this.Tmp.GetChild(4).GetChild(5).GetComponent<UIText>();
    this.text_Rewardstr.font = this.TTFont;
    this.text_Rewardstr.text = this.DM.mStringTable.GetStringByID(8119U);
    this.text_Resultstr = this.Tmp.GetChild(4).GetChild(6).GetComponent<UIText>();
    this.text_Resultstr.font = this.TTFont;
    this.text_Resultstr.text = this.DM.mStringTable.GetStringByID(1021U);
    this.btn_Rank1 = this.Tmp.GetChild(5).GetComponent<UIButton>();
    if (this.GUIM.IsArabic)
      ((Component) this.btn_Rank1).gameObject.AddComponent<ArabicItemTextureRot>();
    this.btn_Rank1.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Rank1.m_BtnID1 = 8;
    this.btn_Rank1.m_EffectType = e_EffectType.e_Scale;
    this.btn_Rank1.transition = (Selectable.Transition) 0;
    this.btn_Rank2 = this.Tmp.GetChild(6).GetComponent<UIButton>();
    if (this.GUIM.IsArabic)
      ((Component) this.btn_Rank2).gameObject.AddComponent<ArabicItemTextureRot>();
    this.btn_Rank2.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Rank2.m_BtnID1 = 9;
    this.btn_Rank2.m_EffectType = e_EffectType.e_Scale;
    this.btn_Rank2.transition = (Selectable.Transition) 0;
    this.Img_MoreRewards = this.Tmp.GetChild(7).GetComponent<Image>();
    Image component = this.GameT.GetChild(1).GetComponent<Image>();
    component.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component).material = this.m_Mat;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) component).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(1).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.m_Mat;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.RankObj.OnOpen(this.transform.GetChild(0).GetChild(9).GetChild(0));
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    this.bOpenEnd = true;
    if (this.AM.AllyMobilizationData.EventState == EActivityState.EAS_None)
      this.door.CloseMenu();
    else if ((this.AM.AllyMobilizationData.EventState == EActivityState.EAS_Run || this.AM.AllyMobilizationData.EventState == EActivityState.EAS_ReplayRanking) && this.MM.bFirstOpen && this.DM.RoleAlliance.Id != 0U)
    {
      this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DATA();
      this.MM.bFirstOpen = false;
    }
    else
    {
      this.CheckMissionCD();
      this.CheckInfo();
    }
  }

  public void CheckInfo()
  {
    ((Component) this.text_Empty).gameObject.SetActive(false);
    ((Component) this.Img_HintBG).gameObject.SetActive(false);
    ((Component) this.text_MissionCount).gameObject.SetActive(false);
    ((Component) this.Img_MoreRewards).gameObject.SetActive(false);
    ((Component) this.text_Result).gameObject.SetActive(false);
    ((Component) this.text_Resultstr).gameObject.SetActive(false);
    switch (this.AM.AllyMobilizationData.EventState)
    {
      case EActivityState.EAS_None:
        this.door.CloseMenu();
        break;
      case EActivityState.EAS_Run:
        this.Img_ActivityTime.sprite = this.SArray.m_Sprites[3];
        ((Component) this.Img_ActivityTime).gameObject.SetActive(true);
        if (this.DM.RoleAlliance.Id != 0U)
        {
          if (this.MM.involvedMember == byte.MaxValue)
            this.text_Empty.text = this.DM.mStringTable.GetStringByID(1373U);
          else if (this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 15)
            this.text_Empty.text = this.DM.mStringTable.GetStringByID(1367U);
        }
        else
          this.text_Empty.text = this.DM.mStringTable.GetStringByID(1374U);
        if (this.MM.involvedMember == byte.MaxValue || this.DM.RoleAlliance.Id == 0U || this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 15)
        {
          ((Component) this.text_Empty).gameObject.SetActive(true);
          this.text_Empty.SetAllDirty();
          this.text_Empty.cachedTextGenerator.Invalidate();
          ((Graphic) this.btn_Rank1.image).color = Color.gray;
          ((Graphic) this.btn_Rank2.image).color = Color.gray;
          break;
        }
        this.text_Time[0].text = this.DM.mStringTable.GetStringByID(8110U);
        this.text_Time[0].SetAllDirty();
        this.text_Time[0].cachedTextGenerator.Invalidate();
        ((Component) this.Img_MissionBG).gameObject.SetActive(true);
        if (((Graphic) this.btn_Rank1.image).color != Color.white)
        {
          ((Graphic) this.btn_Rank1.image).color = Color.white;
          ((Graphic) this.btn_Rank2.image).color = Color.white;
        }
        ((Component) this.Img_HintBG).gameObject.SetActive(true);
        ((Component) this.btn_Reward).gameObject.SetActive(true);
        if (this.MM.mMoreRewards > (byte) 1)
          ((Component) this.Img_MoreRewards).gameObject.SetActive(true);
        ((Component) this.btn_Reward2).gameObject.SetActive(true);
        ((Component) this.text_MissionCount).gameObject.SetActive(true);
        if (this.MM.mMissionID == (ushort) 0 && this.MM.AllianceError != (byte) 0)
          ((Component) this.Img_LBG).gameObject.SetActive(true);
        else
          ((Component) this.Img_LBG).gameObject.SetActive(false);
        this.CheckMissionInfo();
        break;
      case EActivityState.EAS_Prepare:
        this.Img_ActivityTime.sprite = this.SArray.m_Sprites[2];
        ((Component) this.Img_ActivityTime).gameObject.SetActive(true);
        ((Component) this.text_Empty).gameObject.SetActive(true);
        this.text_Time[0].text = this.DM.mStringTable.GetStringByID(8111U);
        this.text_Time[0].SetAllDirty();
        this.text_Time[0].cachedTextGenerator.Invalidate();
        this.text_Empty.text = this.DM.RoleAlliance.Id == 0U ? this.DM.mStringTable.GetStringByID(1374U) : (this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 15 ? this.DM.mStringTable.GetStringByID(1367U) : (this.DM.RoleAlliance.Member >= (byte) 25 ? this.DM.mStringTable.GetStringByID(1378U) : this.DM.mStringTable.GetStringByID(1373U)));
        this.text_Empty.SetAllDirty();
        this.text_Empty.cachedTextGenerator.Invalidate();
        ((Graphic) this.btn_Rank1.image).color = Color.gray;
        ((Graphic) this.btn_Rank2.image).color = Color.gray;
        break;
      case EActivityState.EAS_ReplayRanking:
        ((Component) this.Img_ActivityTime).gameObject.SetActive(false);
        ((Component) this.Img_MissionBG).gameObject.SetActive(false);
        ((Component) this.Img_ActivityEnd).gameObject.SetActive(true);
        ((Component) this.Img_LBG).gameObject.SetActive(true);
        ((Component) this.text_Rewardstr).gameObject.SetActive(true);
        ((Component) this.text_Resultstr).gameObject.SetActive(true);
        this.RankObj.SetActive(true);
        if (this.MM.involvedMember == byte.MaxValue || this.DM.RoleAlliance.Id == 0U || this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 15)
        {
          if (this.MM.involvedMember == byte.MaxValue || this.DM.RoleAlliance.Id == 0U)
            this.RankObj.SetAnimVisible = false;
          ((Component) this.Img_RewardBG[0]).gameObject.SetActive(false);
          ((Graphic) this.Img_RewardBG[1]).color = Color.gray;
          ((Graphic) this.btn_Rank1.image).color = Color.gray;
          ((Graphic) this.btn_Rank2.image).color = Color.gray;
          ((Component) this.btn_GetReward).gameObject.SetActive(false);
          ((Component) this.Img_GetRewardTime).gameObject.SetActive(false);
          ((Component) this.text_RewardTitle).gameObject.SetActive(false);
          break;
        }
        if (this.MM.AMCompleteDegree == (byte) 0 || this.MM.AllianceError == (byte) 1)
        {
          ((Component) this.Img_RewardBG[0]).gameObject.SetActive(false);
          ((Graphic) this.Img_RewardBG[1]).color = Color.gray;
          ((Graphic) this.btn_Rank1.image).color = Color.white;
          ((Graphic) this.btn_Rank2.image).color = Color.white;
          ((Component) this.btn_GetReward).gameObject.SetActive(false);
          ((Component) this.Img_GetRewardTime).gameObject.SetActive(false);
          ((Component) this.text_RewardTitle).gameObject.SetActive(false);
          break;
        }
        this.Cstr_RewardNum.ClearString();
        CString tmpS = StringManager.Instance.StaticString1024();
        tmpS.IntToFormat((long) this.MM.AMCompleteDegree);
        tmpS.AppendFormat("<color=#FFFF00>{0}</color>");
        this.Cstr_RewardNum.StringToFormat(tmpS);
        this.Cstr_RewardNum.AppendFormat(this.DM.mStringTable.GetStringByID(1370U));
        this.text_RewardNum.text = this.Cstr_RewardNum.ToString();
        this.text_RewardNum.SetAllDirty();
        this.text_RewardNum.cachedTextGenerator.Invalidate();
        this.SetFutureRankStr();
        this.text_Result.text = this.Cstr_RankResult.ToString();
        this.text_Result.SetAllDirty();
        this.text_Result.cachedTextGenerator.Invalidate();
        ((Component) this.text_Result).gameObject.SetActive(true);
        ((Graphic) this.Img_RewardBG[1]).color = Color.white;
        ((Graphic) this.btn_Rank1.image).color = Color.white;
        ((Graphic) this.btn_Rank2.image).color = Color.white;
        if (!this.MM.IsGetPrize())
          break;
        ((Component) this.Img_RewardOK).gameObject.SetActive(true);
        ((Component) this.Img_RewardBG[0]).gameObject.SetActive(false);
        ((Component) this.btn_GetReward).gameObject.SetActive(false);
        ((Component) this.Img_GetRewardTime).gameObject.SetActive(false);
        ((Component) this.text_RewardTitle).gameObject.SetActive(false);
        break;
    }
  }

  public void SetFutureRankStr()
  {
    this.Cstr_RankResult.ClearString();
    this.Cstr_Result.ClearString();
    this.Cstr_Result.StringToFormat(this.DM.mStringTable.GetStringByID(1033U - (uint) this.MM.mMobilizationFutureRank));
    switch (this.MM.mMobilizationFutureRank)
    {
      case 1:
        this.Cstr_Result.AppendFormat("<color=#14F855>{0}</color>");
        break;
      case 2:
        this.Cstr_Result.AppendFormat("<color=#00DEFF>{0}</color>");
        break;
      case 3:
        this.Cstr_Result.AppendFormat("<color=#7600B0>{0}</color>");
        break;
      case 4:
        this.Cstr_Result.AppendFormat("<color=#FFF100>{0}</color>");
        break;
      default:
        this.Cstr_Result.AppendFormat("<color=#E5E5E5>{0}</color>");
        break;
    }
    this.Cstr_RankResult.StringToFormat(this.Cstr_Result);
    if ((int) this.MM.mMobilizationFutureRank > (int) this.DM.RoleAlliance.AMRank)
      this.Cstr_RankResult.AppendFormat(this.DM.mStringTable.GetStringByID(1015U));
    else if ((int) this.MM.mMobilizationFutureRank < (int) this.DM.RoleAlliance.AMRank)
      this.Cstr_RankResult.AppendFormat(this.DM.mStringTable.GetStringByID(1018U));
    else
      this.Cstr_RankResult.AppendFormat(this.DM.mStringTable.GetStringByID(1376U));
  }

  public void CheckMissionInfo()
  {
    ((Component) this.text_Kind).gameObject.SetActive(false);
    ((Component) this.text_Kind1).gameObject.SetActive(false);
    ((Component) this.Img_MissionTime).gameObject.SetActive(false);
    ((Component) this.Img_MissionCDTime).gameObject.SetActive(false);
    ((Component) this.btn_Start).gameObject.SetActive(false);
    ((Component) this.btn_GiveUp).gameObject.SetActive(false);
    ((Component) this.btn_Report).gameObject.SetActive(false);
    ((Transform) this.Img_MissionBar_RT).parent.gameObject.SetActive(false);
    ((Component) this.Img_Missionstatus).gameObject.SetActive(false);
    if (this.MM.mScrollFrame == 0)
    {
      if (this.MM.mMissionID != (ushort) 0)
      {
        ((Component) this.btn_GiveUp).gameObject.SetActive(true);
        this.SetMissionInfo(this.MM.mMissionID, (int) this.MM.mMissionDifficulty, false);
        if (this.MM.mMissionStatus == (byte) 2)
        {
          ((Component) this.Img_Missionstatus).gameObject.SetActive(true);
          this.Img_Missionstatus.sprite = this.SArray.m_Sprites[1];
          ((Graphic) this.text_Missionstatus).color = this.mColor_R;
          this.text_Missionstatus.text = this.DM.mStringTable.GetStringByID(1360U);
          this.text_Missionstatus.SetAllDirty();
          this.text_Missionstatus.cachedTextGenerator.Invalidate();
        }
        else if (this.MM.mMissionStatus == (byte) 1)
        {
          ((Component) this.btn_GiveUp).gameObject.SetActive(false);
          ((Component) this.Img_Missionstatus).gameObject.SetActive(true);
          this.Img_Missionstatus.sprite = this.SArray.m_Sprites[0];
          ((Component) this.btn_Report).gameObject.SetActive(true);
          ((Graphic) this.text_Missionstatus).color = this.mColor_G;
          this.text_Missionstatus.text = this.DM.mStringTable.GetStringByID(8114U);
          this.text_Missionstatus.SetAllDirty();
          this.text_Missionstatus.cachedTextGenerator.Invalidate();
        }
        else
        {
          ((Component) this.Img_Missionstatus).gameObject.SetActive(false);
          ((Transform) this.Img_MissionBar_RT).parent.gameObject.SetActive(true);
          long num1 = this.MM.mMissionTime - this.DM.ServerTime;
          this.mMMissionData = this.DM.AllianceMobilizationMission.GetRecordByKey(this.MM.mMissionID);
          double num2 = (double) ((int) this.mMMissionData.MissionTime[(int) this.MM.mMissionDifficulty] * 3600);
          this.Img_MissionBar_RT.sizeDelta = new Vector2((float) (259.0 * ((num2 - (double) num1) / num2)), this.Img_MissionBar_RT.sizeDelta.y);
          this.Cstr_TimeBar.ClearString();
          if (num1 > 86400L)
          {
            this.Cstr_TimeBar.IntToFormat(num1 / 86400L);
            long num3 = num1 % 86400L;
            this.Cstr_TimeBar.IntToFormat(num3 / 3600L, 2);
            long num4 = num3 % 3600L;
            this.Cstr_TimeBar.IntToFormat(num4 / 60L, 2);
            this.Cstr_TimeBar.IntToFormat(num4 % 60L, 2);
            this.Cstr_TimeBar.AppendFormat("{0}d {1}:{2}:{3}");
          }
          else
          {
            this.Cstr_TimeBar.IntToFormat(num1 / 3600L, 2);
            long num5 = num1 % 3600L;
            this.Cstr_TimeBar.IntToFormat(num5 / 60L, 2);
            this.Cstr_TimeBar.IntToFormat(num5 % 60L, 2);
            this.Cstr_TimeBar.AppendFormat("{0}:{1}:{2}");
          }
          this.text_TimeBar.text = this.Cstr_TimeBar.ToString();
          this.text_TimeBar.SetAllDirty();
          this.text_TimeBar.cachedTextGenerator.Invalidate();
        }
      }
      else
      {
        ((Component) this.text_Kind).gameObject.SetActive(true);
        ((Component) this.Img_LBG).gameObject.SetActive(true);
        ((Component) this.text_Info[0]).gameObject.SetActive(false);
        ((Component) this.text_Info[1]).gameObject.SetActive(false);
        ((Component) this.Img_Mission).transform.parent.gameObject.SetActive(false);
        ((Component) this.Img_MissionKind).gameObject.SetActive(false);
        ((Component) this.Img_MissionScore).gameObject.SetActive(false);
        if (this.MM.availableMission != (byte) 0 && this.MM.AllianceError == (byte) 0)
        {
          this.text_Kind.text = this.DM.mStringTable.GetStringByID(1346U);
          ((Graphic) this.text_Kind).color = this.mColor_Info;
        }
        else
        {
          ((Graphic) this.text_Kind).color = this.mColor_R;
          if (this.MM.AllianceError != (byte) 0)
          {
            ((Component) this.text_Kind).gameObject.SetActive(true);
            ((Component) this.text_Kind1).gameObject.SetActive(true);
            ((Graphic) this.text_Kind).color = this.mColor_R;
            this.text_Kind.text = this.DM.mStringTable.GetStringByID(1353U);
            this.text_Kind1.text = this.DM.mStringTable.GetStringByID(1354U);
            this.text_Kind1.SetAllDirty();
            this.text_Kind1.cachedTextGenerator.Invalidate();
          }
          else if (this.MM.extraMission == (byte) 0 || this.MM.extraMission > (byte) 0 && (int) this.MM.extraMission < (int) this.MM.mextraMissionBuyLimit)
          {
            if (this.MM.AllianceError == (byte) 0)
              ((Component) this.btn_Add).gameObject.SetActive(true);
            this.text_Kind.text = this.DM.mStringTable.GetStringByID(1348U);
          }
          else
            this.text_Kind.text = this.DM.mStringTable.GetStringByID(1352U);
        }
      }
    }
    else
    {
      ((Component) this.Img_Mission).transform.parent.gameObject.SetActive(false);
      ((Component) this.Img_MissionKind).gameObject.SetActive(false);
      ((Component) this.Img_MissionScore).gameObject.SetActive(false);
      if (this.MM.mMobilizationMission[this.MM.mScrollFrame].MissionType != (ushort) 1001)
      {
        ((Component) this.Img_MissionTime).gameObject.SetActive(true);
        if (this.MM.mMissionID == (ushort) 0)
          ((Component) this.btn_Start).gameObject.SetActive(true);
        this.SetMissionInfo(this.MM.mMobilizationMission[this.MM.mScrollFrame].MissionType, (int) this.MM.mMobilizationMission[this.MM.mScrollFrame].Difficulty);
      }
      else
      {
        for (int index = 0; index < 2; ++index)
          ((Component) this.text_Info[index]).gameObject.SetActive(false);
        ((Component) this.Img_MissionCDTime).gameObject.SetActive(true);
        this.Cstr_MissionCDTime.ClearString();
        long num = this.MM.mMobilizationMission[this.MM.mScrollFrame].CDTime - this.DM.ServerTime;
        if (num < 0L)
          num = 0L;
        this.Cstr_MissionCDTime.IntToFormat(num / 60L, 2);
        this.Cstr_MissionCDTime.IntToFormat(num % 60L, 2);
        this.Cstr_MissionCDTime.AppendFormat("{0}:{1}");
        this.text_MissionCDTime[1].text = this.Cstr_MissionCDTime.ToString();
        this.text_MissionCDTime[1].SetAllDirty();
        this.text_MissionCDTime[1].cachedTextGenerator.Invalidate();
      }
    }
    this.text_Kind.SetAllDirty();
    this.text_Kind.cachedTextGenerator.Invalidate();
    this.text_Kind.cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_Kind.preferredHeight > (double) ((Graphic) this.text_Kind).rectTransform.sizeDelta.y)
    {
      ((Graphic) this.text_Kind).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Kind).rectTransform.sizeDelta.x, this.text_Kind.preferredHeight + 1f);
      if (((UIBehaviour) this.text_Kind1).IsActive())
        ((Graphic) this.text_Kind1).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_Kind1).rectTransform.anchoredPosition.x, (float) ((double) ((Graphic) this.text_Kind).rectTransform.anchoredPosition.y - ((double) this.text_Kind.preferredHeight + 1.0) - 10.0));
    }
    this.text_Kind1.SetAllDirty();
    this.text_Kind1.cachedTextGenerator.Invalidate();
    this.text_Kind1.cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_Kind1.preferredHeight > (double) ((Graphic) this.text_Kind1).rectTransform.sizeDelta.y)
      ((Graphic) this.text_Kind1).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Kind1).rectTransform.sizeDelta.x, this.text_Kind1.preferredHeight + 1f);
    this.CheckMissionCount();
  }

  public void CheckMissionCount()
  {
    this.Cstr_MissionCount.ClearString();
    if (this.MM.availableMission != (byte) 0)
    {
      this.Cstr_MissionCount.IntToFormat((long) this.MM.availableMission);
      if (((Component) this.btn_Add).gameObject.activeSelf)
        ((Component) this.btn_Add).gameObject.SetActive(false);
    }
    else
    {
      this.Cstr_MissionCount.StringToFormat("<color=#FF5E70>0</color>");
      if (this.MM.AllianceError == (byte) 0 && (this.MM.extraMission == (byte) 0 || this.MM.extraMission > (byte) 0 && (int) this.MM.extraMission < (int) this.MM.mextraMissionBuyLimit))
        ((Component) this.btn_Add).gameObject.SetActive(true);
    }
    this.Cstr_MissionCount.AppendFormat(this.DM.mStringTable.GetStringByID(1345U));
    this.text_MissionCount.text = this.Cstr_MissionCount.ToString();
    this.text_MissionCount.SetAllDirty();
    this.text_MissionCount.cachedTextGenerator.Invalidate();
  }

  public void SetMissionInfo(ushort mKey, int Difficulty, bool bother = true)
  {
    ((Component) this.Img_Mission).transform.parent.gameObject.SetActive(true);
    ((Component) this.Img_MissionKind).gameObject.SetActive(true);
    ((Component) this.Img_MissionScore).gameObject.SetActive(true);
    ((Component) this.text_Info[0]).gameObject.SetActive(true);
    ((Component) this.text_Info[1]).gameObject.SetActive(true);
    this.mMMissionData = this.DM.AllianceMobilizationMission.GetRecordByKey(mKey);
    CString SpriteName = StringManager.Instance.StaticString1024();
    SpriteName.ClearString();
    SpriteName.IntToFormat((long) this.mMMissionData.MissionIcon, 3);
    SpriteName.AppendFormat("{0}");
    this.Img_Mission.sprite = this.GUIM.LoadLeagueGO_iconSprite(SpriteName);
    if (this.GUIM.IsArabic)
    {
      if (this.mMMissionData.MissionIcon == (byte) 24)
        ((Transform) ((Graphic) this.Img_Mission).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
      else
        ((Transform) ((Graphic) this.Img_Mission).rectTransform).localScale = new Vector3(1f, 1f, 1f);
    }
    SpriteName.ClearString();
    SpriteName.IntToFormat((long) this.mMMissionData.MissionIcon2, 3);
    SpriteName.AppendFormat("icon{0}");
    this.Img_MissionKind.sprite = this.GUIM.LoadFrameSprite(SpriteName);
    if ((UnityEngine.Object) this.Img_MissionKind.sprite == (UnityEngine.Object) null)
    {
      SpriteName.ClearString();
      SpriteName.Append("icon014");
      this.Img_MissionKind.sprite = this.GUIM.LoadFrameSprite(SpriteName);
    }
    if (this.GUIM.IsArabic)
    {
      if (this.mMMissionData.MissionIcon2 == (byte) 44)
        ((Transform) ((Graphic) this.Img_MissionKind).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
      else
        ((Transform) ((Graphic) this.Img_MissionKind).rectTransform).localScale = new Vector3(1f, 1f, 1f);
    }
    this.Img_MissionKind.SetNativeSize();
    this.text_Info[0].text = this.DM.mStringTable.GetStringByID((uint) this.mMMissionData.MissionInfo);
    this.text_Info[0].SetAllDirty();
    this.text_Info[0].cachedTextGenerator.Invalidate();
    this.Cstr_Info[0].ClearString();
    if (this.mMMissionData.MissionType == (ushort) 41 || this.mMMissionData.MissionType == (ushort) 71)
    {
      CString tmpS1 = StringManager.Instance.StaticString1024();
      tmpS1.ClearString();
      if (!bother)
      {
        if (this.MM.mMissionTarget / 1440U > 0U)
        {
          tmpS1.IntToFormat((long) (this.MM.mMissionTarget / 1440U));
          tmpS1.IntToFormat((long) (this.MM.mMissionTarget % 1440U / 60U), 2);
          tmpS1.IntToFormat((long) (this.MM.mMissionTarget % 60U), 2);
          tmpS1.IntToFormat(0L, 2);
          tmpS1.AppendFormat("{0}d {1}:{2}:{3}");
        }
        else
        {
          tmpS1.IntToFormat((long) (this.MM.mMissionTarget / 60U), 2);
          tmpS1.IntToFormat((long) (this.MM.mMissionTarget % 60U), 2);
          tmpS1.IntToFormat(0L, 2);
          tmpS1.AppendFormat("{0}:{1}:{2}");
        }
      }
      CString tmpS2 = StringManager.Instance.StaticString1024();
      tmpS2.ClearString();
      if (this.mMMissionData.MissionMaxValue[Difficulty] / 1440U > 0U)
      {
        tmpS2.IntToFormat((long) (this.mMMissionData.MissionMaxValue[Difficulty] / 1440U));
        if (this.mMMissionData.MissionMaxValue[Difficulty] % 1440U == 0U)
        {
          tmpS2.AppendFormat("{0}d");
        }
        else
        {
          tmpS2.IntToFormat((long) (this.mMMissionData.MissionMaxValue[Difficulty] % 1440U / 60U), 2);
          tmpS2.IntToFormat((long) (this.mMMissionData.MissionMaxValue[Difficulty] % 60U), 2);
          tmpS2.IntToFormat(0L, 2);
          tmpS2.AppendFormat("{0}d {1}:{2}:{3}");
        }
      }
      else
      {
        tmpS2.IntToFormat((long) (this.mMMissionData.MissionMaxValue[Difficulty] / 60U), 2);
        tmpS2.IntToFormat((long) (this.mMMissionData.MissionMaxValue[Difficulty] % 60U), 2);
        tmpS2.IntToFormat(0L, 2);
        tmpS2.AppendFormat("{0}:{1}:{2}");
      }
      if (!bother)
        this.Cstr_Info[0].StringToFormat(tmpS1);
      else
        this.Cstr_Info[0].IntToFormat(0L, bNumber: true);
      this.Cstr_Info[0].StringToFormat(tmpS2);
    }
    else
    {
      if (!bother)
        this.Cstr_Info[0].IntToFormat((long) this.MM.mMissionTarget, bNumber: true);
      else
        this.Cstr_Info[0].IntToFormat(0L, bNumber: true);
      this.Cstr_Info[0].IntToFormat((long) this.mMMissionData.MissionMaxValue[Difficulty], bNumber: true);
    }
    if (this.GUIM.IsArabic)
      this.Cstr_Info[0].AppendFormat("{1} / {0}");
    else
      this.Cstr_Info[0].AppendFormat("{0} / {1}");
    this.text_Info[1].text = this.Cstr_Info[0].ToString();
    this.text_Info[1].SetAllDirty();
    this.text_Info[1].cachedTextGenerator.Invalidate();
    this.Cstr_Info[1].ClearString();
    this.Cstr_Info[1].IntToFormat((long) this.mMMissionData.MissionScore[Difficulty], bNumber: true);
    if (this.GUIM.IsArabic)
      this.Cstr_Info[1].AppendFormat("{0}+");
    else
      this.Cstr_Info[1].AppendFormat("+{0}");
    this.text_Info[2].text = this.Cstr_Info[1].ToString();
    this.text_Info[2].SetAllDirty();
    this.text_Info[2].cachedTextGenerator.Invalidate();
    this.Cstr_MissionTime.ClearString();
    if ((int) this.mMMissionData.MissionTime[Difficulty] / 24 >= 1)
    {
      this.Cstr_MissionTime.IntToFormat((long) ((int) this.mMMissionData.MissionTime[Difficulty] / 24));
      this.Cstr_MissionTime.IntToFormat((long) ((int) this.mMMissionData.MissionTime[Difficulty] % 24), 2);
      this.Cstr_MissionTime.IntToFormat(0L, 2);
      this.Cstr_MissionTime.IntToFormat(0L, 2);
      this.Cstr_MissionTime.AppendFormat("{0}d {1}:{2}:{3}");
    }
    else
    {
      this.Cstr_MissionTime.IntToFormat((long) this.mMMissionData.MissionTime[Difficulty], 2);
      this.Cstr_MissionTime.IntToFormat(0L, 2);
      this.Cstr_MissionTime.IntToFormat(0L, 2);
      this.Cstr_MissionTime.AppendFormat("{0}:{1}:{2}");
    }
    this.text_MissionTime.text = this.Cstr_MissionTime.ToString();
    this.text_MissionTime.SetAllDirty();
    this.text_MissionTime.cachedTextGenerator.Invalidate();
  }

  public override void OnClose()
  {
    if ((UnityEngine.Object) this.m_ScrollPanel != (UnityEngine.Object) null)
    {
      this.MM.mMobilizationScroll = this.m_ScrollPanel.GetTopIdx();
      this.MM.mMobilizationScroll_Y = this.m_ItemConet.anchoredPosition.y;
    }
    if (this.Cstr_Lv != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Lv);
    if (this.Cstr_Lv != null)
      StringManager.Instance.DeSpawnString(this.Cstr_LvValue);
    if (this.Cstr_ActivityTime != null)
      StringManager.Instance.DeSpawnString(this.Cstr_ActivityTime);
    if (this.Cstr_NowScore != null)
      StringManager.Instance.DeSpawnString(this.Cstr_NowScore);
    if (this.Cstr_NextScore != null)
      StringManager.Instance.DeSpawnString(this.Cstr_NextScore);
    if (this.Cstr_MobilizationNum != null)
      StringManager.Instance.DeSpawnString(this.Cstr_MobilizationNum);
    if (this.Cstr_MissionTime != null)
      StringManager.Instance.DeSpawnString(this.Cstr_MissionTime);
    if (this.Cstr_MissionCDTime != null)
      StringManager.Instance.DeSpawnString(this.Cstr_MissionCDTime);
    if (this.Cstr_MissionCount != null)
      StringManager.Instance.DeSpawnString(this.Cstr_MissionCount);
    if (this.Cstr_Hint != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Hint);
    if (this.Cstr_TimeBar != null)
      StringManager.Instance.DeSpawnString(this.Cstr_TimeBar);
    if (this.Cstr_GetRewardTime != null)
      StringManager.Instance.DeSpawnString(this.Cstr_GetRewardTime);
    if (this.Cstr_RewardNum != null)
      StringManager.Instance.DeSpawnString(this.Cstr_RewardNum);
    if (this.Cstr_RankHint != null)
      StringManager.Instance.DeSpawnString(this.Cstr_RankHint);
    if (this.Cstr_Result != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Result);
    if (this.Cstr_RankResult != null)
      StringManager.Instance.DeSpawnString(this.Cstr_RankResult);
    for (int index = 0; index < 2; ++index)
    {
      if (this.Cstr_Info[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Info[index]);
    }
    for (int index1 = 0; index1 < 3; ++index1)
    {
      for (int index2 = 0; index2 < 3; ++index2)
      {
        if (this.Cstr_ItemTime[index1] != null && this.Cstr_ItemTime[index1][index2] != null)
          StringManager.Instance.DeSpawnString(this.Cstr_ItemTime[index1][index2]);
        if (this.Cstr_ItemValue[index1] != null && this.Cstr_ItemValue[index1][index2] != null)
          StringManager.Instance.DeSpawnString(this.Cstr_ItemValue[index1][index2]);
      }
    }
    this.RankObj.OnClose();
    this.tmpAddCount = 10;
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((UnityEngine.Object) this.tmpItem[panelObjectIdx] == (UnityEngine.Object) null)
    {
      this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      for (int index1 = 0; index1 < 3; ++index1)
      {
        this.btn_ItemSelect[panelObjectIdx][index1] = item.transform.GetChild(index1).GetComponent<UIButton>();
        this.btn_ItemSelect[panelObjectIdx][index1].m_Handler = (IUIButtonClickHandler) this;
        this.btn_ItemSelect[panelObjectIdx][index1].m_BtnID2 = panelObjectIdx;
        this.btn_ItemSelect[panelObjectIdx][index1].m_BtnID3 = index1;
        for (int index2 = 0; index2 < 3; ++index2)
          this.ItemKind_T[panelObjectIdx][index1 * 3 + index2] = item.transform.GetChild(index1).GetChild(index2);
        this.Img_ItemP1Mission[panelObjectIdx][index1] = item.transform.GetChild(index1).GetChild(0).GetChild(0).GetComponent<Image>();
        this.Img_ItemP1Icon[panelObjectIdx][index1] = item.transform.GetChild(index1).GetChild(0).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
        this.Img_ItemP1Score[panelObjectIdx][index1] = item.transform.GetChild(index1).GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>();
        this.text_ItemP1Score[panelObjectIdx][index1] = item.transform.GetChild(index1).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
        this.Img_ItemP1OK[panelObjectIdx][index1] = item.transform.GetChild(index1).GetChild(0).GetChild(0).GetChild(3).GetComponent<Image>();
        this.text_ItemNoMission[panelObjectIdx][index1] = item.transform.GetChild(index1).GetChild(0).GetChild(1).GetComponent<UIText>();
        this.btn_Delete[panelObjectIdx][index1] = item.transform.GetChild(index1).GetChild(1).GetChild(1).GetComponent<UIButton>();
        this.btn_Delete[panelObjectIdx][index1].m_Handler = (IUIButtonClickHandler) this;
        this.btn_Delete[panelObjectIdx][index1].m_BtnID2 = panelObjectIdx;
        this.btn_Delete[panelObjectIdx][index1].m_BtnID3 = index1;
        this.Img_ItemIcon[panelObjectIdx][index1] = item.transform.GetChild(index1).GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>();
        this.text_ItemValue[panelObjectIdx][index1] = item.transform.GetChild(index1).GetChild(1).GetChild(3).GetChild(0).GetComponent<UIText>();
        this.text_ItemTime[panelObjectIdx][index1] = item.transform.GetChild(index1).GetChild(2).GetChild(1).GetComponent<UIText>();
        this.Img_ItemFrame[panelObjectIdx][index1] = item.transform.GetChild(index1).GetChild(3).GetComponent<Image>();
      }
    }
    for (int index = 0; index < 3; ++index)
    {
      if (((Component) this.btn_Delete[panelObjectIdx][index]).gameObject.activeSelf)
        ((Component) this.btn_Delete[panelObjectIdx][index]).gameObject.SetActive(false);
      if (dataIdx * 3 + index == this.MM.mScrollFrame)
      {
        ((Component) this.Img_ItemFrame[panelObjectIdx][index]).gameObject.SetActive(true);
        if (dataIdx != 0 && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4 && this.MM.mMobilizationMission[dataIdx * 3 + index].MissionType != (ushort) 1001)
          ((Component) this.btn_Delete[panelObjectIdx][index]).gameObject.SetActive(true);
      }
      else
        ((Component) this.Img_ItemFrame[panelObjectIdx][index]).gameObject.SetActive(false);
      if (dataIdx * 3 + index == 0)
      {
        if (this.MM.mMissionID == (ushort) 0)
        {
          this.ItemKind_T[panelObjectIdx][0].gameObject.SetActive(true);
          this.ItemKind_T[panelObjectIdx][1].gameObject.SetActive(false);
          this.ItemKind_T[panelObjectIdx][2].gameObject.SetActive(false);
          ((Component) this.Img_ItemP1Score[panelObjectIdx][index]).gameObject.SetActive(false);
          ((Component) this.Img_ItemP1OK[panelObjectIdx][index]).gameObject.SetActive(false);
          ((Component) this.text_ItemNoMission[panelObjectIdx][index]).gameObject.SetActive(true);
          ((Component) this.Img_ItemP1Mission[panelObjectIdx][index]).gameObject.SetActive(false);
        }
        else
        {
          this.ItemKind_T[panelObjectIdx][0].gameObject.SetActive(true);
          this.ItemKind_T[panelObjectIdx][1].gameObject.SetActive(false);
          this.ItemKind_T[panelObjectIdx][2].gameObject.SetActive(false);
          ((Component) this.text_ItemNoMission[panelObjectIdx][index]).gameObject.SetActive(false);
          ((Component) this.Img_ItemP1Mission[panelObjectIdx][index]).gameObject.SetActive(true);
          this.mMMissionData = this.DM.AllianceMobilizationMission.GetRecordByKey(this.MM.mMissionID);
          CString SpriteName = StringManager.Instance.StaticString1024();
          SpriteName.ClearString();
          SpriteName.IntToFormat((long) this.mMMissionData.MissionIcon, 3);
          SpriteName.AppendFormat("{0}");
          this.Img_ItemP1Icon[panelObjectIdx][index].sprite = this.GUIM.LoadLeagueGO_iconSprite(SpriteName);
          if (this.GUIM.IsArabic)
          {
            if (this.mMMissionData.MissionIcon == (byte) 24)
              ((Transform) ((Graphic) this.Img_ItemP1Icon[panelObjectIdx][index]).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
            else
              ((Transform) ((Graphic) this.Img_ItemP1Icon[panelObjectIdx][index]).rectTransform).localScale = new Vector3(1f, 1f, 1f);
          }
          if (this.MM.mMissionStatus == (byte) 0)
          {
            ((Component) this.Img_ItemP1Score[panelObjectIdx][index]).gameObject.SetActive(true);
            this.Cstr_ItemValue[panelObjectIdx][index].ClearString();
            this.Cstr_ItemValue[panelObjectIdx][index].IntToFormat((long) this.mMMissionData.MissionScore[(int) this.MM.mMissionDifficulty], bNumber: true);
            if (this.GUIM.IsArabic)
              this.Cstr_ItemValue[panelObjectIdx][index].AppendFormat("{0}+");
            else
              this.Cstr_ItemValue[panelObjectIdx][index].AppendFormat("+{0}");
            this.text_ItemP1Score[panelObjectIdx][index].text = this.Cstr_ItemValue[panelObjectIdx][index].ToString();
            this.text_ItemP1Score[panelObjectIdx][index].SetAllDirty();
            this.text_ItemP1Score[panelObjectIdx][index].cachedTextGenerator.Invalidate();
          }
          else
          {
            ((Component) this.Img_ItemP1OK[panelObjectIdx][index]).gameObject.SetActive(true);
            ((Component) this.Img_ItemP1Score[panelObjectIdx][index]).gameObject.SetActive(false);
            this.Img_ItemP1OK[panelObjectIdx][index].sprite = this.MM.mMissionStatus != (byte) 1 ? this.SArray.m_Sprites[1] : this.SArray.m_Sprites[0];
          }
        }
      }
      else
      {
        this.ItemKind_T[panelObjectIdx][0 + index * 3].gameObject.SetActive(false);
        if (this.MM.mMobilizationMission[dataIdx * 3 + index].MissionType != (ushort) 1001)
        {
          if (dataIdx * 3 + index == this.MM.mScrollFrame && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
            ((Component) this.btn_Delete[panelObjectIdx][index]).gameObject.SetActive(true);
          this.ItemKind_T[panelObjectIdx][1 + index * 3].gameObject.SetActive(true);
          this.ItemKind_T[panelObjectIdx][2 + index * 3].gameObject.SetActive(false);
          this.mMMissionData = this.DM.AllianceMobilizationMission.GetRecordByKey(this.MM.mMobilizationMission[dataIdx * 3 + index].MissionType);
          CString SpriteName = StringManager.Instance.StaticString1024();
          SpriteName.ClearString();
          SpriteName.IntToFormat((long) this.mMMissionData.MissionIcon, 3);
          SpriteName.AppendFormat("{0}");
          this.Img_ItemIcon[panelObjectIdx][index].sprite = this.GUIM.LoadLeagueGO_iconSprite(SpriteName);
          if (this.GUIM.IsArabic)
          {
            if (this.mMMissionData.MissionIcon == (byte) 24)
              ((Transform) ((Graphic) this.Img_ItemIcon[panelObjectIdx][index]).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
            else
              ((Transform) ((Graphic) this.Img_ItemIcon[panelObjectIdx][index]).rectTransform).localScale = new Vector3(1f, 1f, 1f);
          }
          this.Cstr_ItemValue[panelObjectIdx][index].ClearString();
          this.Cstr_ItemValue[panelObjectIdx][index].IntToFormat((long) this.mMMissionData.MissionScore[(int) this.MM.mMobilizationMission[dataIdx * 3 + index].Difficulty], bNumber: true);
          if (this.GUIM.IsArabic)
            this.Cstr_ItemValue[panelObjectIdx][index].AppendFormat("{0}+");
          else
            this.Cstr_ItemValue[panelObjectIdx][index].AppendFormat("+{0}");
          this.text_ItemValue[panelObjectIdx][index].text = this.Cstr_ItemValue[panelObjectIdx][index].ToString();
          this.text_ItemValue[panelObjectIdx][index].SetAllDirty();
          this.text_ItemValue[panelObjectIdx][index].cachedTextGenerator.Invalidate();
        }
        else
        {
          this.ItemKind_T[panelObjectIdx][1 + index * 3].gameObject.SetActive(false);
          this.ItemKind_T[panelObjectIdx][2 + index * 3].gameObject.SetActive(true);
          this.Cstr_ItemTime[panelObjectIdx][index].ClearString();
          this.tmpTime = this.MM.mMobilizationMission[dataIdx * 3 + index].CDTime - this.DM.ServerTime;
          this.Cstr_ItemTime[panelObjectIdx][index].IntToFormat(this.tmpTime / 60L % 60L, 2);
          this.Cstr_ItemTime[panelObjectIdx][index].IntToFormat(this.tmpTime % 60L, 2);
          this.Cstr_ItemTime[panelObjectIdx][index].AppendFormat("{0}:{1}");
          this.text_ItemTime[panelObjectIdx][index].text = this.Cstr_ItemTime[panelObjectIdx][index].ToString();
          this.text_ItemTime[panelObjectIdx][index].SetAllDirty();
          this.text_ItemTime[panelObjectIdx][index].cachedTextGenerator.Invalidate();
        }
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 1:
        this.door.OpenMenu(EGUIWindow.UI_Alliance_Mobilization_Info);
        break;
      case 2:
        if (this.MM.AllianceError != (byte) 0)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1357U), (ushort) byte.MaxValue);
          break;
        }
        this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(1355U), this.DM.mStringTable.GetStringByID(1356U), 2, this.tmpItem[sender.m_BtnID2].m_BtnID1 * 3 + sender.m_BtnID3 - 1, this.DM.mStringTable.GetStringByID(3737U), this.DM.mStringTable.GetStringByID(3736U));
        break;
      case 3:
        for (int index1 = 0; index1 < 3; ++index1)
        {
          for (int index2 = 0; index2 < 3; ++index2)
          {
            if (this.tmpItem[index1].m_BtnID1 * 3 + index2 == this.MM.mScrollFrame)
            {
              ((Component) this.Img_ItemFrame[index1][index2]).gameObject.SetActive(false);
              if (((Component) this.btn_Delete[index1][index2]).gameObject.activeSelf)
              {
                ((Component) this.btn_Delete[index1][index2]).gameObject.SetActive(false);
                break;
              }
              break;
            }
          }
        }
        this.MM.mScrollFrame = this.tmpItem[sender.m_BtnID2].m_BtnID1 * 3 + sender.m_BtnID3;
        ((Component) this.Img_ItemFrame[sender.m_BtnID2][sender.m_BtnID3]).gameObject.SetActive(true);
        this.ShowItemF = 0.0f;
        if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4 && this.MM.mMobilizationMission[this.MM.mScrollFrame].MissionType != (ushort) 1001)
          ((Component) this.btn_Delete[sender.m_BtnID2][sender.m_BtnID3]).gameObject.SetActive(true);
        this.CheckMissionInfo();
        break;
      case 5:
        this.GUIM.MsgStr.ClearString();
        this.GUIM.MsgStr.IntToFormat((long) this.MM.extraMission);
        this.GUIM.MsgStr.IntToFormat((long) this.MM.mextraMissionBuyLimit);
        this.GUIM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(1009U));
        GUIManager.Instance.OpenSpendWindow_Normal((GUIWindow) this, this.DM.mStringTable.GetStringByID(1349U), this.GUIM.MsgStr.ToString(), (int) this.MM.mextraMissionPrize, 1, Buttontext: this.DM.mStringTable.GetStringByID(1351U));
        break;
      case 6:
        if (this.MM.availableMission > (byte) 0 && this.MM.AllianceError == (byte) 0)
        {
          this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_GET((byte) (this.MM.mScrollFrame - 1));
          break;
        }
        if (this.MM.AllianceError != (byte) 0)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1353U), (ushort) byte.MaxValue);
          this.MM.mScrollFrame = 0;
          this.ShowItemF = 0.0f;
          this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
          this.CheckMissionInfo();
          break;
        }
        if (this.MM.extraMission == (byte) 0 || this.MM.extraMission > (byte) 0 && (int) this.MM.extraMission < (int) this.MM.mextraMissionBuyLimit)
        {
          this.GUIM.MsgStr.ClearString();
          this.GUIM.MsgStr.IntToFormat((long) this.MM.extraMission);
          this.GUIM.MsgStr.IntToFormat((long) this.MM.mextraMissionBuyLimit);
          this.GUIM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(1012U));
          this.GUIM.OpenSpendWindow_Normal((GUIWindow) this, this.DM.mStringTable.GetStringByID(1349U), this.GUIM.MsgStr.ToString(), (int) this.MM.mextraMissionPrize, 4, Buttontext: this.DM.mStringTable.GetStringByID(1351U));
          break;
        }
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1352U), (ushort) byte.MaxValue);
        break;
      case 7:
        this.MM.Send_MSG_REQUEST_ALLIANVEMOBLIZATION_MISSION_FINISH();
        break;
      case 8:
        if (!(((Graphic) sender.image).color != Color.gray))
          break;
        UILeaderBoard.NewOpen = true;
        this.door.OpenMenu(EGUIWindow.UI_LeaderBoard, 5);
        break;
      case 9:
        if (!(((Graphic) sender.image).color != Color.gray))
          break;
        UILeaderBoard.NewOpen = true;
        this.door.OpenMenu(EGUIWindow.UI_LeaderBoard, 4);
        break;
      case 10:
        if (this.MM.AllianceError != (byte) 0)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1595U), (ushort) byte.MaxValue);
          break;
        }
        this.door.OpenMenu(EGUIWindow.UI_RewardsSelect, 1);
        break;
      case 11:
        this.door.OpenMenu(EGUIWindow.UI_RewardsSelect);
        break;
      case 12:
        this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5880U), this.DM.mStringTable.GetStringByID(3668U), 3, YesText: this.DM.mStringTable.GetStringByID(3737U), NoText: this.DM.mStringTable.GetStringByID(3736U));
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 1:
        if (this.DM.RoleAttr.Diamond >= (uint) this.MM.mextraMissionPrize)
        {
          if (this.GUIM.OpenCheckCrystal((uint) this.MM.mextraMissionPrize, (byte) 8))
            break;
          this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_BUY();
          break;
        }
        CString cstring1 = StringManager.Instance.StaticString1024();
        cstring1.ClearString();
        cstring1.StringToFormat(this.DM.mStringTable.GetStringByID(9144U));
        cstring1.AppendFormat(this.DM.mStringTable.GetStringByID(3857U));
        this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966U), cstring1.ToString(), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 5, bCloseIDSet: true);
        break;
      case 2:
        if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
        {
          this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DEL((byte) arg2);
          break;
        }
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9793U), (ushort) byte.MaxValue);
        break;
      case 3:
        this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DEL(byte.MaxValue);
        break;
      case 4:
        if (this.DM.RoleAttr.Diamond >= (uint) this.MM.mextraMissionPrize)
        {
          if (!this.GUIM.OpenCheckCrystal((uint) this.MM.mextraMissionPrize, (byte) 8))
            this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_BUY();
          this.bStartAddSend = true;
          break;
        }
        CString cstring2 = StringManager.Instance.StaticString1024();
        cstring2.ClearString();
        cstring2.StringToFormat(this.DM.mStringTable.GetStringByID(9144U));
        cstring2.AppendFormat(this.DM.mStringTable.GetStringByID(3857U));
        this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966U), cstring2.ToString(), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 5, bCloseIDSet: true);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    switch ((Mobilization_btn) (sender.m_Button as UIButton).m_BtnID1)
    {
      case Mobilization_btn.btn_Hint:
        ((Component) this.Img_Hint).gameObject.SetActive(true);
        break;
      case Mobilization_btn.btn_RankHint:
        uint ID = 1028U - (uint) this.DM.RoleAlliance.AMRank;
        this.Cstr_RankHint.ClearString();
        this.Cstr_RankHint.Append(this.DM.mStringTable.GetStringByID(ID));
        GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.Cstr_RankHint, Vector2.zero);
        break;
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    switch ((Mobilization_btn) (sender.m_Button as UIButton).m_BtnID1)
    {
      case Mobilization_btn.btn_Hint:
        if (!((UIBehaviour) this.Img_Hint).IsActive())
          break;
        ((Component) this.Img_Hint).gameObject.SetActive(false);
        break;
      case Mobilization_btn.btn_RankHint:
        GUIManager.Instance.m_Hint.Hide(true);
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    int num1 = arg1;
    switch (num1)
    {
      case 0:
        this.CheckInfo();
        if (this.MM.involvedMember == byte.MaxValue)
          break;
        this.Cstr_NowScore.ClearString();
        StringManager.IntToStr(this.Cstr_NowScore, (long) this.MM.AMScore, bNumber: true);
        this.text_NowScore[1].text = this.Cstr_NowScore.ToString();
        this.text_NowScore[1].SetAllDirty();
        this.text_NowScore[1].cachedTextGenerator.Invalidate();
        this.Cstr_NextScore.ClearString();
        if ((int) this.MM.AMCompleteDegree < this.tmpItemNum)
          StringManager.IntToStr(this.Cstr_NextScore, (long) (this.MM.CompleteScore - this.MM.AMScore), bNumber: true);
        else
          StringManager.IntToStr(this.Cstr_NextScore, 0L, bNumber: true);
        this.text_NextScore[1].text = this.Cstr_NextScore.ToString();
        this.text_NextScore[1].SetAllDirty();
        this.text_NextScore[1].cachedTextGenerator.Invalidate();
        this.Cstr_Lv.ClearString();
        StringManager.IntToStr(this.Cstr_Lv, (long) this.MM.AMCompleteDegree);
        this.text_Lv.text = this.Cstr_Lv.ToString();
        this.text_Lv.SetAllDirty();
        this.text_Lv.cachedTextGenerator.Invalidate();
        this.Cstr_LvValue.ClearString();
        if ((int) this.MM.AMCompleteDegree == this.tmpItemNum)
        {
          this.mMDData = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int) this.MM.AMCompleteDegree - 1);
          StringManager.IntToStr(this.Cstr_LvValue, (long) this.mMDData.MissionDegreeScore, bNumber: true);
          ((Graphic) this.text_LvValue).color = new Color(1f, 0.945f, 0.204f);
        }
        else
          StringManager.IntToStr(this.Cstr_LvValue, (long) this.MM.CompleteScore, bNumber: true);
        this.text_LvValue.text = this.Cstr_LvValue.ToString();
        this.text_LvValue.SetAllDirty();
        this.text_LvValue.cachedTextGenerator.Invalidate();
        if (this.MM.CompleteScore != 0U)
        {
          if (this.MM.AMCompleteDegree == (byte) 0)
          {
            this.Img_LvBar_RT.sizeDelta = new Vector2((float) (214.0 * ((double) this.MM.AMScore / (double) this.MM.CompleteScore)), this.Img_LvBar_RT.sizeDelta.y);
            ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition = new Vector2((float) (11.5 + 214.0 * ((double) this.MM.AMScore / (double) this.MM.CompleteScore)), ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition.y);
          }
          else
          {
            this.mMDData = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int) this.MM.AMCompleteDegree - 1);
            if ((int) this.mMDData.MissionDegreeScore == (int) this.MM.AMScore)
            {
              this.Img_LvBar_RT.sizeDelta = new Vector2(0.0f, this.Img_LvBar_RT.sizeDelta.y);
              ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition = new Vector2(11.5f, ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition.y);
            }
            else
            {
              this.Img_LvBar_RT.sizeDelta = new Vector2((float) (214.0 * ((double) (this.MM.AMScore - this.mMDData.MissionDegreeScore) / (double) (this.MM.CompleteScore - this.mMDData.MissionDegreeScore))), this.Img_LvBar_RT.sizeDelta.y);
              ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition = new Vector2((float) (11.5 + 214.0 * (double) ((float) (this.MM.AMScore - this.mMDData.MissionDegreeScore) / (float) (this.MM.CompleteScore - this.mMDData.MissionDegreeScore))), ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition.y);
            }
          }
        }
        else
          this.Img_LvBar_RT.sizeDelta = new Vector2(0.0f, this.Img_LvBar_RT.sizeDelta.y);
        if ((int) this.MM.AMCompleteDegree == this.tmpItemNum)
        {
          ((Component) this.Img_LVMax).gameObject.SetActive(true);
          this.Img_LvBar_RT.sizeDelta = new Vector2(214f, this.Img_LvBar_RT.sizeDelta.y);
          ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition = new Vector2(225.5f, ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition.y);
        }
        this.Cstr_MobilizationNum.ClearString();
        this.Cstr_MobilizationNum.IntToFormat((long) this.MM.involvedMember);
        this.Cstr_MobilizationNum.AppendFormat(this.DM.mStringTable.GetStringByID(1340U));
        this.text_MobilizationNum.text = this.Cstr_MobilizationNum.ToString();
        this.text_MobilizationNum.SetAllDirty();
        this.text_MobilizationNum.cachedTextGenerator.Invalidate();
        this.Cstr_Hint.ClearString();
        this.Cstr_Hint.IntToFormat((long) this.MM.involvedMember);
        this.Cstr_Hint.AppendFormat(this.DM.mStringTable.GetStringByID(1341U));
        this.text_Hint.text = this.Cstr_Hint.ToString();
        this.text_Hint.SetAllDirty();
        this.text_Hint.cachedTextGenerator.Invalidate();
        this.text_Hint.cachedTextGeneratorForLayout.Invalidate();
        if ((double) this.text_Hint.preferredHeight > (double) ((Graphic) this.text_Hint).rectTransform.sizeDelta.y)
        {
          ((Graphic) this.text_Hint).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Hint).rectTransform.sizeDelta.x, this.text_Hint.preferredHeight + 1f);
          ((Graphic) this.Img_Hint).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Hint).rectTransform.sizeDelta.x, this.text_Hint.preferredHeight + 11f);
        }
        this.tmplist.Clear();
        for (int index = 0; index < 7; ++index)
          this.tmplist.Add(224f);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        this.Cstr_TimeBar.ClearString();
        long num2 = this.MM.mMissionTime - this.DM.ServerTime;
        this.mMMissionData = this.DM.AllianceMobilizationMission.GetRecordByKey(this.MM.mMissionID);
        double num3 = (double) ((int) this.mMMissionData.MissionTime[(int) this.MM.mMissionDifficulty] * 3600);
        this.Img_MissionBar_RT.sizeDelta = new Vector2((float) (259.0 * ((num3 - (double) num2) / num3)), this.Img_MissionBar_RT.sizeDelta.y);
        if (num2 > 86400L)
        {
          this.Cstr_TimeBar.IntToFormat(num2 / 86400L);
          long num4 = num2 % 86400L;
          this.Cstr_TimeBar.IntToFormat(num4 / 3600L, 2);
          long num5 = num4 % 3600L;
          this.Cstr_TimeBar.IntToFormat(num5 / 60L, 2);
          this.Cstr_TimeBar.IntToFormat(num5 % 60L, 2);
          this.Cstr_TimeBar.AppendFormat("{0}d {1}:{2}:{3}");
        }
        else
        {
          this.Cstr_TimeBar.IntToFormat(num2 / 3600L, 2);
          long num6 = num2 % 3600L;
          this.Cstr_TimeBar.IntToFormat(num6 / 60L, 2);
          this.Cstr_TimeBar.IntToFormat(num6 % 60L, 2);
          this.Cstr_TimeBar.AppendFormat("{0}:{1}:{2}");
        }
        this.text_TimeBar.text = this.Cstr_TimeBar.ToString();
        this.text_TimeBar.SetAllDirty();
        this.text_TimeBar.cachedTextGenerator.Invalidate();
        break;
      case 2:
        this.Cstr_NowScore.ClearString();
        StringManager.IntToStr(this.Cstr_NowScore, (long) this.MM.AMScore, bNumber: true);
        this.text_NowScore[1].text = this.Cstr_NowScore.ToString();
        this.text_NowScore[1].SetAllDirty();
        this.text_NowScore[1].cachedTextGenerator.Invalidate();
        this.Cstr_NextScore.ClearString();
        if ((int) this.MM.AMCompleteDegree < this.tmpItemNum)
          StringManager.IntToStr(this.Cstr_NextScore, (long) (this.MM.CompleteScore - this.MM.AMScore), bNumber: true);
        else
          StringManager.IntToStr(this.Cstr_NextScore, 0L, bNumber: true);
        this.text_NextScore[1].text = this.Cstr_NextScore.ToString();
        this.text_NextScore[1].SetAllDirty();
        this.text_NextScore[1].cachedTextGenerator.Invalidate();
        this.Cstr_Lv.ClearString();
        StringManager.IntToStr(this.Cstr_Lv, (long) this.MM.AMCompleteDegree);
        this.text_Lv.text = this.Cstr_Lv.ToString();
        this.text_Lv.SetAllDirty();
        this.text_Lv.cachedTextGenerator.Invalidate();
        this.Cstr_LvValue.ClearString();
        if ((int) this.MM.AMCompleteDegree == this.tmpItemNum)
        {
          this.mMDData = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int) this.MM.AMCompleteDegree - 1);
          StringManager.IntToStr(this.Cstr_LvValue, (long) this.mMDData.MissionDegreeScore, bNumber: true);
          ((Graphic) this.text_LvValue).color = new Color(1f, 0.945f, 0.204f);
        }
        else
          StringManager.IntToStr(this.Cstr_LvValue, (long) this.MM.CompleteScore, bNumber: true);
        this.text_LvValue.text = this.Cstr_LvValue.ToString();
        this.text_LvValue.SetAllDirty();
        this.text_LvValue.cachedTextGenerator.Invalidate();
        if (this.MM.CompleteScore != 0U)
        {
          if (this.MM.AMCompleteDegree == (byte) 0)
          {
            this.Img_LvBar_RT.sizeDelta = new Vector2((float) (214.0 * ((double) this.MM.AMScore / (double) this.MM.CompleteScore)), this.Img_LvBar_RT.sizeDelta.y);
            ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition = new Vector2((float) (11.5 + 214.0 * ((double) this.MM.AMScore / (double) this.MM.CompleteScore)), ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition.y);
          }
          else
          {
            this.mMDData = this.DM.AllianceMobilizationDegreeInfo.GetRecordByIndex((int) this.MM.AMCompleteDegree - 1);
            if ((int) this.mMDData.MissionDegreeScore == (int) this.MM.AMScore)
            {
              this.Img_LvBar_RT.sizeDelta = new Vector2(0.0f, this.Img_LvBar_RT.sizeDelta.y);
              ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition = new Vector2(11.5f, ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition.y);
            }
            else
            {
              this.Img_LvBar_RT.sizeDelta = new Vector2((float) (214.0 * ((double) (this.MM.AMScore - this.mMDData.MissionDegreeScore) / (double) (this.MM.CompleteScore - this.mMDData.MissionDegreeScore))), this.Img_LvBar_RT.sizeDelta.y);
              ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition = new Vector2((float) (11.5 + 214.0 * (double) ((float) (this.MM.AMScore - this.mMDData.MissionDegreeScore) / (float) (this.MM.CompleteScore - this.mMDData.MissionDegreeScore))), ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition.y);
            }
          }
        }
        else
          this.Img_LvBar_RT.sizeDelta = new Vector2(0.0f, this.Img_LvBar_RT.sizeDelta.y);
        if ((int) this.MM.AMCompleteDegree != this.tmpItemNum)
          break;
        ((Component) this.Img_LVMax).gameObject.SetActive(true);
        this.Img_LvBar_RT.sizeDelta = new Vector2(214f, this.Img_LvBar_RT.sizeDelta.y);
        ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition = new Vector2(225.5f, ((Graphic) this.Img_Bar[0]).rectTransform.anchoredPosition.y);
        break;
      case 3:
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        if (arg2 != this.MM.mScrollFrame)
          break;
        this.CheckMissionInfo();
        break;
      case 4:
        if (this.MM.involvedMember == byte.MaxValue)
          break;
        this.Cstr_MobilizationNum.ClearString();
        this.Cstr_MobilizationNum.IntToFormat((long) this.MM.involvedMember);
        this.Cstr_MobilizationNum.AppendFormat(this.DM.mStringTable.GetStringByID(1340U));
        this.text_MobilizationNum.text = this.Cstr_MobilizationNum.ToString();
        this.text_MobilizationNum.SetAllDirty();
        this.text_MobilizationNum.cachedTextGenerator.Invalidate();
        this.Cstr_Hint.ClearString();
        this.Cstr_Hint.IntToFormat((long) this.MM.involvedMember);
        this.Cstr_Hint.AppendFormat(this.DM.mStringTable.GetStringByID(1341U));
        this.text_Hint.text = this.Cstr_Hint.ToString();
        this.text_Hint.SetAllDirty();
        this.text_Hint.cachedTextGenerator.Invalidate();
        this.text_Hint.cachedTextGeneratorForLayout.Invalidate();
        if ((double) this.text_Hint.preferredHeight <= (double) ((Graphic) this.text_Hint).rectTransform.sizeDelta.y)
          break;
        ((Graphic) this.text_Hint).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_Hint).rectTransform.sizeDelta.x, this.text_Hint.preferredHeight + 1f);
        ((Graphic) this.Img_Hint).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Hint).rectTransform.sizeDelta.x, this.Img_Hint.preferredHeight + 11f);
        break;
      case 5:
        if (this.AM.AllyMobilizationData.EventState != EActivityState.EAS_Prepare)
          break;
        this.CheckInfo();
        break;
      case 6:
        if ((this.AM.AllyMobilizationData.EventState == EActivityState.EAS_Run || this.AM.AllyMobilizationData.EventState == EActivityState.EAS_ReplayRanking) && this.MM.bFirstOpen && this.DM.RoleAlliance.Id != 0U)
        {
          this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DATA();
          this.MM.bFirstOpen = false;
          break;
        }
        this.CheckInfo();
        break;
      case 7:
        if (this.MM.mScrollFrame != 0)
          break;
        this.Cstr_Info[0].ClearString();
        if (this.mMMissionData.MissionType == (ushort) 41 || this.mMMissionData.MissionType == (ushort) 71)
        {
          CString tmpS1 = StringManager.Instance.StaticString1024();
          tmpS1.ClearString();
          if (this.MM.mMissionTarget / 1440U > 0U)
          {
            tmpS1.IntToFormat((long) (this.MM.mMissionTarget / 1440U));
            tmpS1.IntToFormat((long) (this.MM.mMissionTarget % 1440U / 60U), 2);
            tmpS1.IntToFormat((long) (this.MM.mMissionTarget % 60U), 2);
            tmpS1.IntToFormat(0L, 2);
            tmpS1.AppendFormat("{0}d {1}:{2}:{3}");
          }
          else
          {
            tmpS1.IntToFormat((long) (this.MM.mMissionTarget / 60U), 2);
            tmpS1.IntToFormat((long) (this.MM.mMissionTarget % 60U), 2);
            tmpS1.IntToFormat(0L, 2);
            tmpS1.AppendFormat("{0}:{1}:{2}");
          }
          CString tmpS2 = StringManager.Instance.StaticString1024();
          tmpS2.ClearString();
          if (this.mMMissionData.MissionMaxValue[(int) this.MM.mMissionDifficulty] / 1440U > 0U)
          {
            tmpS2.IntToFormat((long) (this.mMMissionData.MissionMaxValue[(int) this.MM.mMissionDifficulty] / 1440U));
            if (this.mMMissionData.MissionMaxValue[(int) this.MM.mMissionDifficulty] % 1440U == 0U)
            {
              tmpS2.AppendFormat("{0}d");
            }
            else
            {
              tmpS2.IntToFormat((long) (this.mMMissionData.MissionMaxValue[(int) this.MM.mMissionDifficulty] % 1440U / 60U), 2);
              tmpS2.IntToFormat((long) (this.mMMissionData.MissionMaxValue[(int) this.MM.mMissionDifficulty] % 60U), 2);
              tmpS2.IntToFormat(0L, 2);
              tmpS2.AppendFormat("{0}d {1}:{2}:{3}");
            }
          }
          else
          {
            tmpS2.IntToFormat((long) (this.mMMissionData.MissionMaxValue[(int) this.MM.mMissionDifficulty] / 60U), 2);
            tmpS2.IntToFormat((long) (this.mMMissionData.MissionMaxValue[(int) this.MM.mMissionDifficulty] % 60U), 2);
            tmpS2.IntToFormat(0L, 2);
            tmpS2.AppendFormat("{0}:{1}:{2}");
          }
          this.Cstr_Info[0].StringToFormat(tmpS1);
          this.Cstr_Info[0].StringToFormat(tmpS2);
        }
        else
        {
          this.Cstr_Info[0].IntToFormat((long) this.MM.mMissionTarget, bNumber: true);
          this.Cstr_Info[0].IntToFormat((long) this.mMMissionData.MissionMaxValue[(int) this.MM.mMissionDifficulty], bNumber: true);
        }
        if (this.GUIM.IsArabic)
          this.Cstr_Info[0].AppendFormat("{1} / {0}");
        else
          this.Cstr_Info[0].AppendFormat("{0} / {1}");
        this.text_Info[1].text = this.Cstr_Info[0].ToString();
        this.text_Info[1].SetAllDirty();
        this.text_Info[1].cachedTextGenerator.Invalidate();
        break;
      case 8:
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        this.CheckMissionInfo();
        break;
      case 9:
        this.MM.mScrollFrame = 0;
        this.ShowItemF = 0.0f;
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist);
        this.CheckMissionInfo();
        if (arg2 != 1)
          break;
        float num7 = 0.0f;
        if (this.GUIM.bOpenOnIPhoneX)
          num7 = this.GUIM.IPhoneX_DeltaX;
        this.GUIM.mStartV2 = new Vector2((float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 + 217.5), (float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 - 21.0));
        this.GUIM.m_SpeciallyEffect.UI_bezieEnd = new Vector2((float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 + 125.0) - num7, (float) -((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 - 150.0));
        this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.MobilizationMission, ItemID: (ushort) 0, EndTime: 2f);
        break;
      case 10:
        this.CheckMissionInfo();
        if (this.bStartAddSend)
          this.OnButtonClick(this.btn_Start);
        this.bStartAddSend = false;
        break;
      case 11:
        if (this.DM.RoleAlliance.AMRank > (byte) 0 && (int) this.DM.RoleAlliance.AMRank + 3 < this.SArray.m_Sprites.Length)
          this.Img_TitleBG.sprite = this.SArray.m_Sprites[(int) this.DM.RoleAlliance.AMRank + 3];
        this.GUIM.SetAllyRankImage(this.Img_AllianceRankBG, this.DM.RoleAlliance.AMRank);
        this.CheckInfo();
        break;
      default:
        if (num1 != 99)
          break;
        Array.Clear((Array) this.GUIM.SE_Kind, 0, this.GUIM.SE_Kind.Length);
        Array.Clear((Array) this.GUIM.m_SpeciallyEffect.mResValue, 0, this.GUIM.m_SpeciallyEffect.mResValue.Length);
        Array.Clear((Array) this.GUIM.SE_ItemID, 0, this.GUIM.SE_ItemID.Length);
        for (int index = 0; index < 3; ++index)
        {
          if (this.MM.RSAnimationItemID[index] != (ushort) 0)
            this.GUIM.SE_ItemID[index] = this.MM.RSAnimationItemID[index];
        }
        int index1 = 0;
        if (this.MM.PrizeCrystal != 0U)
        {
          this.GUIM.m_SpeciallyEffect.mDiamondValue = this.MM.PrizeCrystal;
          this.GUIM.SE_Kind[index1] = SpeciallyEffect_Kind.Diamond;
          ++index1;
        }
        if (this.MM.PrizeAllianceMoney != 0U)
          this.GUIM.SE_Kind[index1] = SpeciallyEffect_Kind.AllianceMoney;
        this.GUIM.mStartV2 = new Vector2((float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 + 259.5), (float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 + 101.0));
        this.GUIM.m_SpeciallyEffect.AddIconShow(this.GUIM.mStartV2, this.GUIM.SE_Kind, this.GUIM.SE_ItemID);
        this.tmpAddTime = 0.6f;
        this.tmpAddCount = 1;
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if ((this.AM.AllyMobilizationData.EventState == EActivityState.EAS_Run || this.AM.AllyMobilizationData.EventState == EActivityState.EAS_ReplayRanking) && this.DM.RoleAlliance.Id != 0U)
        {
          this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_DATA();
          break;
        }
        if (this.AM.AllyMobilizationData.EventState != EActivityState.EAS_None)
          break;
        this.door.CloseMenu();
        break;
      case NetworkNews.Refresh_Alliance:
        if (this.DM.RoleAlliance.Id != 0U)
          break;
        this.door.CloseMenu();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.text_Title != (UnityEngine.Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((UnityEngine.Object) this.text_MobilizationNum != (UnityEngine.Object) null && ((Behaviour) this.text_MobilizationNum).enabled)
    {
      ((Behaviour) this.text_MobilizationNum).enabled = false;
      ((Behaviour) this.text_MobilizationNum).enabled = true;
    }
    if ((UnityEngine.Object) this.text_MissionCount != (UnityEngine.Object) null && ((Behaviour) this.text_MissionCount).enabled)
    {
      ((Behaviour) this.text_MissionCount).enabled = false;
      ((Behaviour) this.text_MissionCount).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Lv != (UnityEngine.Object) null && ((Behaviour) this.text_Lv).enabled)
    {
      ((Behaviour) this.text_Lv).enabled = false;
      ((Behaviour) this.text_Lv).enabled = true;
    }
    if ((UnityEngine.Object) this.text_LvValue != (UnityEngine.Object) null && ((Behaviour) this.text_LvValue).enabled)
    {
      ((Behaviour) this.text_LvValue).enabled = false;
      ((Behaviour) this.text_LvValue).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Kind != (UnityEngine.Object) null && ((Behaviour) this.text_Kind).enabled)
    {
      ((Behaviour) this.text_Kind).enabled = false;
      ((Behaviour) this.text_Kind).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Kind1 != (UnityEngine.Object) null && ((Behaviour) this.text_Kind1).enabled)
    {
      ((Behaviour) this.text_Kind1).enabled = false;
      ((Behaviour) this.text_Kind1).enabled = true;
    }
    if ((UnityEngine.Object) this.text_MissionTime != (UnityEngine.Object) null && ((Behaviour) this.text_MissionTime).enabled)
    {
      ((Behaviour) this.text_MissionTime).enabled = false;
      ((Behaviour) this.text_MissionTime).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Missionstatus != (UnityEngine.Object) null && ((Behaviour) this.text_Missionstatus).enabled)
    {
      ((Behaviour) this.text_Missionstatus).enabled = false;
      ((Behaviour) this.text_Missionstatus).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Empty != (UnityEngine.Object) null && ((Behaviour) this.text_Empty).enabled)
    {
      ((Behaviour) this.text_Empty).enabled = false;
      ((Behaviour) this.text_Empty).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Hint != (UnityEngine.Object) null && ((Behaviour) this.text_Hint).enabled)
    {
      ((Behaviour) this.text_Hint).enabled = false;
      ((Behaviour) this.text_Hint).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Start != (UnityEngine.Object) null && ((Behaviour) this.text_Start).enabled)
    {
      ((Behaviour) this.text_Start).enabled = false;
      ((Behaviour) this.text_Start).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Report != (UnityEngine.Object) null && ((Behaviour) this.text_Report).enabled)
    {
      ((Behaviour) this.text_Report).enabled = false;
      ((Behaviour) this.text_Report).enabled = true;
    }
    if ((UnityEngine.Object) this.text_GiveUp != (UnityEngine.Object) null && ((Behaviour) this.text_GiveUp).enabled)
    {
      ((Behaviour) this.text_GiveUp).enabled = false;
      ((Behaviour) this.text_GiveUp).enabled = true;
    }
    if ((UnityEngine.Object) this.text_RewardTitle != (UnityEngine.Object) null && ((Behaviour) this.text_RewardTitle).enabled)
    {
      ((Behaviour) this.text_RewardTitle).enabled = false;
      ((Behaviour) this.text_RewardTitle).enabled = true;
    }
    if ((UnityEngine.Object) this.text_GetRewardTime != (UnityEngine.Object) null && ((Behaviour) this.text_GetRewardTime).enabled)
    {
      ((Behaviour) this.text_GetRewardTime).enabled = false;
      ((Behaviour) this.text_GetRewardTime).enabled = true;
    }
    if ((UnityEngine.Object) this.text_AllianceReward != (UnityEngine.Object) null && ((Behaviour) this.text_AllianceReward).enabled)
    {
      ((Behaviour) this.text_AllianceReward).enabled = false;
      ((Behaviour) this.text_AllianceReward).enabled = true;
    }
    if ((UnityEngine.Object) this.text_RewardNum != (UnityEngine.Object) null && ((Behaviour) this.text_RewardNum).enabled)
    {
      ((Behaviour) this.text_RewardNum).enabled = false;
      ((Behaviour) this.text_RewardNum).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Rewardstr != (UnityEngine.Object) null && ((Behaviour) this.text_Rewardstr).enabled)
    {
      ((Behaviour) this.text_Rewardstr).enabled = false;
      ((Behaviour) this.text_Rewardstr).enabled = true;
    }
    if ((UnityEngine.Object) this.text_RewardOK != (UnityEngine.Object) null && ((Behaviour) this.text_RewardOK).enabled)
    {
      ((Behaviour) this.text_RewardOK).enabled = false;
      ((Behaviour) this.text_RewardOK).enabled = true;
    }
    if ((UnityEngine.Object) this.text_TimeBar != (UnityEngine.Object) null && ((Behaviour) this.text_TimeBar).enabled)
    {
      ((Behaviour) this.text_TimeBar).enabled = false;
      ((Behaviour) this.text_TimeBar).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Resultstr != (UnityEngine.Object) null && ((Behaviour) this.text_Resultstr).enabled)
    {
      ((Behaviour) this.text_Resultstr).enabled = false;
      ((Behaviour) this.text_Resultstr).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Result != (UnityEngine.Object) null && ((Behaviour) this.text_Result).enabled)
    {
      ((Behaviour) this.text_Result).enabled = false;
      ((Behaviour) this.text_Result).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((UnityEngine.Object) this.text_Time[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Time[index]).enabled)
      {
        ((Behaviour) this.text_Time[index]).enabled = false;
        ((Behaviour) this.text_Time[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_NowScore[index] != (UnityEngine.Object) null && ((Behaviour) this.text_NowScore[index]).enabled)
      {
        ((Behaviour) this.text_NowScore[index]).enabled = false;
        ((Behaviour) this.text_NowScore[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_NextScore[index] != (UnityEngine.Object) null && ((Behaviour) this.text_NextScore[index]).enabled)
      {
        ((Behaviour) this.text_NextScore[index]).enabled = false;
        ((Behaviour) this.text_NextScore[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_MissionCDTime[index] != (UnityEngine.Object) null && ((Behaviour) this.text_MissionCDTime[index]).enabled)
      {
        ((Behaviour) this.text_MissionCDTime[index]).enabled = false;
        ((Behaviour) this.text_MissionCDTime[index]).enabled = true;
      }
    }
    for (int index1 = 0; index1 < 3; ++index1)
    {
      if ((UnityEngine.Object) this.text_Info[index1] != (UnityEngine.Object) null && ((Behaviour) this.text_Info[index1]).enabled)
      {
        ((Behaviour) this.text_Info[index1]).enabled = false;
        ((Behaviour) this.text_Info[index1]).enabled = true;
      }
      for (int index2 = 0; index2 < 3; ++index2)
      {
        if ((UnityEngine.Object) this.text_ItemTime[index1][index2] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemTime[index1][index2]).enabled)
        {
          ((Behaviour) this.text_ItemTime[index1][index2]).enabled = false;
          ((Behaviour) this.text_ItemTime[index1][index2]).enabled = true;
        }
        if ((UnityEngine.Object) this.text_ItemValue[index1][index2] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemValue[index1][index2]).enabled)
        {
          ((Behaviour) this.text_ItemValue[index1][index2]).enabled = false;
          ((Behaviour) this.text_ItemValue[index1][index2]).enabled = true;
        }
        if ((UnityEngine.Object) this.text_ItemP1Score[index1][index2] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemP1Score[index1][index2]).enabled)
        {
          ((Behaviour) this.text_ItemP1Score[index1][index2]).enabled = false;
          ((Behaviour) this.text_ItemP1Score[index1][index2]).enabled = true;
        }
        if ((UnityEngine.Object) this.text_ItemNoMission[index1][index2] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemNoMission[index1][index2]).enabled)
        {
          ((Behaviour) this.text_ItemNoMission[index1][index2]).enabled = false;
          ((Behaviour) this.text_ItemNoMission[index1][index2]).enabled = true;
        }
      }
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!this.bOpenEnd)
      return;
    this.RankObj.UpdateTime(bOnSecond);
    if (!bOnSecond)
      return;
    this.CheckMissionCD();
    if ((UnityEngine.Object) this.text_Time[1] != (UnityEngine.Object) null && ((Component) this.text_Time[1]).gameObject.activeSelf)
    {
      this.Cstr_ActivityTime.ClearString();
      if (this.AM.AllyMobilizationData.EventCountTime > 86400L)
      {
        this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime / 86400L);
        this.Cstr_ActivityTime.AppendFormat("{0}d");
      }
      else
      {
        this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime / 3600L, 2);
        this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime % 3600L / 60L, 2);
        this.Cstr_ActivityTime.IntToFormat(this.AM.AllyMobilizationData.EventCountTime % 60L, 2);
        this.Cstr_ActivityTime.AppendFormat("{0}:{1}:{2}");
      }
      this.text_Time[1].text = this.Cstr_ActivityTime.ToString();
      this.text_Time[1].SetAllDirty();
      this.text_Time[1].cachedTextGenerator.Invalidate();
    }
    if ((UnityEngine.Object) this.Img_MissionCDTime != (UnityEngine.Object) null && (UnityEngine.Object) this.text_MissionCDTime[1] != (UnityEngine.Object) null && ((Component) this.Img_MissionCDTime).gameObject.activeSelf)
    {
      this.Cstr_MissionCDTime.ClearString();
      long num = this.MM.mMobilizationMission[this.MM.mScrollFrame].CDTime - this.DM.ServerTime;
      if (num < 0L)
        num = 0L;
      this.Cstr_MissionCDTime.IntToFormat(num / 60L, 2);
      this.Cstr_MissionCDTime.IntToFormat(num % 60L, 2);
      this.Cstr_MissionCDTime.AppendFormat("{0}:{1}");
      this.text_MissionCDTime[1].text = this.Cstr_MissionCDTime.ToString();
      this.text_MissionCDTime[1].SetAllDirty();
      this.text_MissionCDTime[1].cachedTextGenerator.Invalidate();
    }
    if ((UnityEngine.Object) this.Img_MissionBar_RT != (UnityEngine.Object) null && (UnityEngine.Object) ((Transform) this.Img_MissionBar_RT).parent != (UnityEngine.Object) null && (UnityEngine.Object) this.text_TimeBar != (UnityEngine.Object) null && ((Transform) this.Img_MissionBar_RT).parent.gameObject.activeSelf)
    {
      this.Cstr_TimeBar.ClearString();
      long num1 = this.MM.mMissionTime - this.DM.ServerTime;
      this.mMMissionData = this.DM.AllianceMobilizationMission.GetRecordByKey(this.MM.mMissionID);
      double num2 = (double) ((int) this.mMMissionData.MissionTime[(int) this.MM.mMissionDifficulty] * 3600);
      this.Img_MissionBar_RT.sizeDelta = new Vector2((float) (259.0 * ((num2 - (double) num1) / num2)), this.Img_MissionBar_RT.sizeDelta.y);
      if (num1 > 86400L)
      {
        this.Cstr_TimeBar.IntToFormat(num1 / 86400L);
        long num3 = num1 % 86400L;
        this.Cstr_TimeBar.IntToFormat(num3 / 3600L, 2);
        long num4 = num3 % 3600L;
        this.Cstr_TimeBar.IntToFormat(num4 / 60L, 2);
        this.Cstr_TimeBar.IntToFormat(num4 % 60L, 2);
        this.Cstr_TimeBar.AppendFormat("{0}d {1}:{2}:{3}");
      }
      else
      {
        if (num1 < 0L)
          num1 = 0L;
        this.Cstr_TimeBar.IntToFormat(num1 / 3600L, 2);
        long num5 = num1 % 3600L;
        this.Cstr_TimeBar.IntToFormat(num5 / 60L, 2);
        this.Cstr_TimeBar.IntToFormat(num5 % 60L, 2);
        this.Cstr_TimeBar.AppendFormat("{0}:{1}:{2}");
      }
      this.text_TimeBar.text = this.Cstr_TimeBar.ToString();
      this.text_TimeBar.SetAllDirty();
      this.text_TimeBar.cachedTextGenerator.Invalidate();
    }
    if ((UnityEngine.Object) this.Img_ActivityEnd != (UnityEngine.Object) null && ((Component) this.Img_ActivityEnd).gameObject.activeSelf && (UnityEngine.Object) this.text_GetRewardTime != (UnityEngine.Object) null)
    {
      this.Cstr_GetRewardTime.ClearString();
      long num = this.AM.AllyMobilizationData.EventCountTime;
      if (num < 0L)
        num = 0L;
      if (num > 86400L)
      {
        this.Cstr_GetRewardTime.IntToFormat(num / 86400L);
        this.Cstr_GetRewardTime.AppendFormat("{0}d");
      }
      else
      {
        this.Cstr_GetRewardTime.IntToFormat(num / 3600L, 2);
        this.Cstr_GetRewardTime.IntToFormat(num % 3600L / 60L, 2);
        this.Cstr_GetRewardTime.IntToFormat(num % 60L, 2);
        this.Cstr_GetRewardTime.AppendFormat("{0}:{1}:{2}");
      }
      this.text_GetRewardTime.text = this.Cstr_GetRewardTime.ToString();
      this.text_GetRewardTime.SetAllDirty();
      this.text_GetRewardTime.cachedTextGenerator.Invalidate();
    }
    for (int index1 = 0; index1 < 3; ++index1)
    {
      for (int index2 = 0; index2 < 3; ++index2)
      {
        if ((UnityEngine.Object) this.tmpItem[index1] != (UnityEngine.Object) null && this.tmpItem[index1].m_BtnID1 >= 0 && this.tmpItem[index1].m_BtnID1 < 7 && 2 + index2 * 3 < 9 && (UnityEngine.Object) this.ItemKind_T[index1][2 + index2 * 3] != (UnityEngine.Object) null && this.ItemKind_T[index1][2 + index2 * 3].gameObject.activeSelf && (UnityEngine.Object) this.text_ItemTime[index1][index2] != (UnityEngine.Object) null)
        {
          long num = this.MM.mMobilizationMission[this.tmpItem[index1].m_BtnID1 * 3 + index2].CDTime - this.DM.ServerTime;
          this.Cstr_ItemTime[index1][index2].ClearString();
          if (num < 0L)
            num = 0L;
          this.Cstr_ItemTime[index1][index2].IntToFormat(num / 60L, 2);
          this.Cstr_ItemTime[index1][index2].IntToFormat(num % 60L, 2);
          this.Cstr_ItemTime[index1][index2].AppendFormat("{0}:{1}");
          this.text_ItemTime[index1][index2].text = this.Cstr_ItemTime[index1][index2].ToString();
          this.text_ItemTime[index1][index2].SetAllDirty();
          this.text_ItemTime[index1][index2].cachedTextGenerator.Invalidate();
        }
      }
    }
  }

  public void CheckMissionCD()
  {
    for (int index = 0; index < this.MM.mMobilizationMission.Length; ++index)
    {
      if (this.MM.mMobilizationMission[index].MissionType == (ushort) 1001 && this.MM.mMobilizationMission[index].CDTime - DataManager.Instance.ServerTime <= 0L)
      {
        this.MM.Send_MSG_REQUEST_ALLIANCEMOBLIZATION_MISSION_REFLASH();
        break;
      }
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
    if ((UnityEngine.Object) this.btn_GetReward != (UnityEngine.Object) null && ((UIBehaviour) this.btn_GetReward).IsActive())
    {
      this.ShowGetReward += Time.smoothDeltaTime;
      if ((double) this.ShowGetReward >= 2.0)
        this.ShowGetReward = 0.0f;
      ((Graphic) this.Img_GetReward).color = new Color(1f, 1f, 1f, (double) this.ShowGetReward <= 1.0 ? this.ShowGetReward : 2f - this.ShowGetReward);
    }
    if ((UnityEngine.Object) this.btn_Report != (UnityEngine.Object) null && ((UIBehaviour) this.btn_Report).IsActive())
    {
      this.ShowReport += Time.smoothDeltaTime;
      if ((double) this.ShowReport >= 2.0)
        this.ShowReport = 0.0f;
      ((Graphic) this.Img_Report).color = new Color(1f, 1f, 1f, (double) this.ShowReport <= 1.0 ? this.ShowReport : 2f - this.ShowReport);
    }
    for (int index1 = 0; index1 < 3; ++index1)
    {
      for (int index2 = 0; index2 < 3; ++index2)
      {
        if ((UnityEngine.Object) this.Img_ItemFrame[index1][index2] != (UnityEngine.Object) null && ((UIBehaviour) this.Img_ItemFrame[index1][index2]).IsActive())
        {
          this.ShowItemF += Time.smoothDeltaTime;
          if ((double) this.ShowItemF >= 2.0)
            this.ShowItemF = 0.0f;
          float a = (double) this.ShowItemF <= 1.0 ? (float) (1.0 - (double) this.ShowItemF * 0.699999988079071) : (float) (0.699999988079071 * (double) this.ShowItemF - 0.40000000596046448);
          ((Graphic) this.Img_ItemFrame[index1][index2]).color = new Color(1f, 1f, 1f, a);
        }
      }
    }
    if ((UnityEngine.Object) this.Img_RewardBG[0] != (UnityEngine.Object) null && ((UIBehaviour) this.Img_RewardBG[0]).IsActive())
    {
      if (this.GUIM.IsArabic)
        ((Component) this.Img_RewardBG[0]).transform.Rotate(Vector3.forward * Time.smoothDeltaTime * 50f);
      else
        ((Component) this.Img_RewardBG[0]).transform.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    }
    if (this.MM.AMCompleteDegree <= (byte) 0 || this.tmpAddCount >= ((int) this.MM.AMCompleteDegree - 1) / 3 + 1)
      return;
    this.tmpAddTime -= Time.unscaledDeltaTime;
    if ((double) this.tmpAddTime >= 0.0)
      return;
    Array.Clear((Array) this.GUIM.SE_Kind, 0, this.GUIM.SE_Kind.Length);
    Array.Clear((Array) this.GUIM.m_SpeciallyEffect.mResValue, 0, this.GUIM.m_SpeciallyEffect.mResValue.Length);
    Array.Clear((Array) this.GUIM.SE_ItemID, 0, this.GUIM.SE_ItemID.Length);
    for (int index = 0; index < 3; ++index)
    {
      if (index + this.tmpAddCount * 3 < this.MM.RSAnimationItemID.Length && this.MM.RSAnimationItemID[index + this.tmpAddCount * 3] != (ushort) 0)
        this.GUIM.SE_ItemID[index] = this.MM.RSAnimationItemID[index + this.tmpAddCount * 3];
    }
    this.GUIM.mStartV2 = new Vector2((float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 + 259.5), (float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 + 101.0));
    this.GUIM.m_SpeciallyEffect.AddIconShow(this.GUIM.mStartV2, this.GUIM.SE_Kind, this.GUIM.SE_ItemID);
    ++this.tmpAddCount;
    this.tmpAddTime = 0.6f;
  }
}
