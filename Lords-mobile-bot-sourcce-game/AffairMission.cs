// Decompiled with JetBrains decompiler
// Type: AffairMission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class AffairMission : UIMissionItem
{
  private Transform SelectTrans;
  private Transform BarLink;
  private UISpritesArray SpriteArray;
  private Image Icon;
  private CanvasGroup RewardAlpha;
  private UIButton RewardBtn;
  private UIText NameText;
  private UIText RewardText;
  private CString NameStr;
  private TimerTypeMission MissionData;
  private _MissionTimeBar TimeBar;
  private _eMissionType MissionType;
  private byte VipComplete;

  public AffairMission(Transform transform, UISpritesArray spriteArray, _MissionTimeBar timebar)
  {
    this.transform = transform;
    this.TimeBar = timebar;
    this.SpriteArray = spriteArray;
    this.NameStr = StringManager.Instance.SpawnString(200);
    this.BarLink = transform.GetChild(2);
    this.ItemBtn = new UIButton[1];
    this.ItemBtn[0] = transform.GetComponent<UIButton>();
    this.ItemBtn[0].m_BtnID1 = 11;
    this.SelectTrans = transform.GetChild(4);
    this.Icon = transform.GetChild(0).GetComponent<Image>();
    this.NameText = transform.GetChild(1).GetComponent<UIText>();
    this.RewardBtn = transform.GetChild(3).GetComponent<UIButton>();
    this.RewardBtn.m_BtnID1 = 7;
    this.RewardBtn.m_Handler = (IUIButtonClickHandler) this;
    this.RewardAlpha = transform.GetChild(3).GetChild(0).GetComponent<CanvasGroup>();
    this.NameText = transform.GetChild(1).GetComponent<UIText>();
    this.RewardText = transform.GetChild(3).GetChild(1).GetComponent<UIText>();
  }

  public void SetType(_eMissionType type)
  {
    this.MissionType = type;
    this.MissionData = DataManager.MissionDataManager.GetTimerMissionData(this.MissionType);
    this.VipComplete = DataManager.MissionDataManager.VipAutoComplete[(int) (byte) (this.MissionType - 1)];
    if (this.VipComplete != (byte) 1)
      return;
    this.MissionData.ProcessIdx = byte.MaxValue;
    this.MissionData.MissionTime = -1L;
  }

  public override void SetMissionData(int Index)
  {
    MissionManager missionDataManager = DataManager.MissionDataManager;
    DataManager instance = DataManager.Instance;
    this.SetSelect(false, 0, (uint[]) null, (ushort[]) null, (ushort[]) null);
    this.DataIndex = Index;
    this.ItemBtn[0].m_BtnID2 = this.DataIndex;
    AffairNarrativeTbl affairNarrativeTbl = this.MissionType != _eMissionType.Affair ? missionDataManager.AllianceNarrativeTable.GetRecordByIndex((int) this.MissionData.TimeMission[this.DataIndex].ID) : missionDataManager.AffairNarrativeTable.GetRecordByIndex((int) this.MissionData.TimeMission[this.DataIndex].ID);
    this.RewardBtn.m_BtnID2 = this.DataIndex;
    if (affairNarrativeTbl.Quality > (byte) 0)
      this.Icon.sprite = this.SpriteArray.GetSprite((int) affairNarrativeTbl.Quality - 1);
    this.NameStr.ClearString();
    this.RewardBtn.m_BtnID2 = this.DataIndex;
    switch (affairNarrativeTbl.Quality)
    {
      case 1:
        this.NameStr.StringToFormat("<color=#dfe0e0ff>");
        break;
      case 2:
        this.NameStr.StringToFormat("<color=#51e369ff>");
        break;
      case 3:
        this.NameStr.StringToFormat("<color=#5ccff5ff>");
        break;
      case 4:
        this.NameStr.StringToFormat("<color=#c881ffff>");
        break;
      case 5:
        this.NameStr.StringToFormat("<color=#f5d94fff>");
        break;
    }
    this.NameStr.StringToFormat(instance.mStringTable.GetStringByID((uint) affairNarrativeTbl.Narrative));
    this.NameStr.AppendFormat("{0}{1}</color>");
    if (this.VipComplete == (byte) 1 && (this.MissionData.TimeMission[this.DataIndex].State == _eTimerMissionState.Wait || this.MissionData.TimeMission[this.DataIndex].State == _eTimerMissionState.Countdown))
      this.MissionData.TimeMission[this.DataIndex].State = _eTimerMissionState.AutoComplete;
    switch (this.MissionData.TimeMission[this.DataIndex].State)
    {
      case _eTimerMissionState.Wait:
        CString tmpS = missionDataManager.FormatMissionTime((uint) affairNarrativeTbl.TotalTime);
        if (this.MissionData.ProcessIdx == byte.MaxValue && ((int) missionDataManager.MissionNotice & 1 << (int) (byte) this.MissionType) == 0)
          ((Component) this.RewardBtn).gameObject.SetActive(true);
        else
          ((Component) this.RewardBtn).gameObject.SetActive(false);
        this.RewardText.text = instance.mStringTable.GetStringByID(1541U);
        this.RewardBtn.m_BtnID1 = 8;
        this.RewardBtn.m_BtnID2 = (int) this.MissionType;
        this.RewardBtn.m_BtnID3 = this.DataIndex;
        this.NameStr.StringToFormat("\n");
        this.NameStr.StringToFormat(tmpS);
        this.NameStr.AppendFormat("{0}{1}");
        this.RewardAlpha.alpha = 0.0f;
        if (this.BarLink.childCount > 0)
        {
          ((Component) this.TimeBar.transform).gameObject.SetActive(false);
          break;
        }
        break;
      case _eTimerMissionState.Reward:
        this.RewardText.text = instance.mStringTable.GetStringByID(1542U);
        this.RewardBtn.m_BtnID1 = 7;
        this.RewardBtn.m_BtnID2 = (int) this.MissionType;
        this.RewardBtn.m_BtnID3 = this.DataIndex;
        ((Component) this.RewardBtn).gameObject.SetActive(true);
        if (this.BarLink.childCount > 0)
        {
          ((Component) this.TimeBar.transform).gameObject.SetActive(false);
          break;
        }
        break;
      case _eTimerMissionState.Countdown:
        ((Component) this.RewardBtn).gameObject.SetActive(false);
        if (this.BarLink.childCount == 0)
          ((Transform) this.TimeBar.transform).SetParent(this.BarLink);
        ((Component) this.TimeBar.transform).gameObject.SetActive(true);
        this.TimeBar.transform.anchoredPosition = new Vector2(21.21f, -9.34f);
        this.TimeBar.Speed.m_Handler = (IUIButtonClickHandler) this;
        this.TimeBar.Speed.m_BtnID2 = (int) this.MissionType;
        this.TimeBar.Speed.m_BtnID3 = this.DataIndex;
        byte index = this.MissionType != _eMissionType.Affair ? (byte) 20 : (byte) 19;
        GUIManager.Instance.SetTimerBar(this.TimeBar.TimeBar, instance.queueBarData[(int) index].StartTime, instance.queueBarData[(int) index].StartTime + (long) instance.queueBarData[(int) index].TotalTime, 0L, eTimeBarType.UIMission, this.TimeBar.TimeBar.m_Titles[0], this.TimeBar.TimeBar.m_Titles[1]);
        break;
      case _eTimerMissionState.AutoComplete:
        this.RewardText.text = instance.mStringTable.GetStringByID(1543U);
        this.RewardBtn.m_BtnID1 = 7;
        this.RewardBtn.m_BtnID2 = (int) this.MissionType;
        this.RewardBtn.m_BtnID3 = this.DataIndex;
        ((Component) this.RewardBtn).gameObject.SetActive(true);
        if (this.BarLink.childCount > 0)
        {
          ((Component) this.TimeBar.transform).gameObject.SetActive(false);
          break;
        }
        break;
      default:
        if (this.BarLink.childCount > 0 && this.TimeBar.Speed.m_BtnID2 != this.DataIndex)
        {
          ((Component) this.TimeBar.transform).gameObject.SetActive(false);
          break;
        }
        break;
    }
    this.NameText.text = this.NameStr.ToString();
    this.NameText.SetAllDirty();
    this.NameText.cachedTextGenerator.Invalidate();
  }

  public override void Destroy()
  {
    StringManager.Instance.DeSpawnString(this.NameStr);
    this.NameStr = (CString) null;
  }

  public override void Update()
  {
    if (this.MissionData.TimeMission[this.DataIndex].State != _eTimerMissionState.Reward && this.MissionData.TimeMission[this.DataIndex].State != _eTimerMissionState.AutoComplete)
      return;
    float deltaTime = this.TimeHandle.GetDeltaTime();
    this.RewardAlpha.alpha = (double) deltaTime <= 1.0 ? deltaTime : 2f - deltaTime;
  }

  public override float GetHeight() => 73f;

  public override void SetSelect(
    bool bSelect,
    int index = 0,
    uint[] reward = null,
    ushort[] rewardItem = null,
    ushort[] count = null)
  {
    this.SelectTrans.gameObject.SetActive(bSelect);
    if (reward == null || !bSelect)
      return;
    MissionManager missionDataManager = DataManager.MissionDataManager;
    Array.Clear((Array) reward, 0, reward.Length);
    Array.Clear((Array) rewardItem, 0, rewardItem.Length);
    ProbabilityTbl recordByIndex1 = missionDataManager.ProbabilityTable.GetRecordByIndex((int) this.MissionData.TimeMission[this.DataIndex].Quality);
    byte level = GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level;
    if (this.MissionType == _eMissionType.Affair)
    {
      AffairCardinalTbl recordByIndex2 = missionDataManager.AffairCardinalTable.GetRecordByIndex((int) this.MissionData.TimeMission[this.DataIndex].Base);
      if (recordByIndex2.ResourceCardinal != null)
      {
        for (int index1 = 0; index1 < recordByIndex2.ResourceCardinal.Length; ++index1)
          reward[3 + index1] = recordByIndex2.ResourceCardinal[index1] * (uint) recordByIndex1.Multiple * (uint) level;
      }
      reward[0] = recordByIndex2.Exp * (uint) recordByIndex1.Multiple * (uint) level;
      reward[0] = DataManager.Instance.GetExpAddition(reward[0]);
    }
    else
    {
      AllianceCardinalTbl recordByIndex3 = missionDataManager.AllianceCardinalTable.GetRecordByIndex((int) this.MissionData.TimeMission[this.DataIndex].Base);
      if (recordByIndex3.ResourceCardinal != null)
      {
        for (int index2 = 0; index2 < recordByIndex3.ResourceCardinal.Length; ++index2)
          reward[3 + index2] = (uint) ((ulong) (recordByIndex3.ResourceCardinal[index2] * (uint) recordByIndex1.Multiple * (uint) level) * (ulong) missionDataManager.AllianceMissionBonusRate / 100UL);
      }
      reward[8] = (uint) ((ulong) ((int) recordByIndex3.AllianceMoney * (int) recordByIndex1.Multiple) * (ulong) missionDataManager.AllianceMissionBonusRate / 100UL);
      reward[0] = recordByIndex3.Exp * (uint) recordByIndex1.Multiple * (uint) level;
      reward[0] = (uint) ((ulong) DataManager.Instance.GetExpAddition(reward[0]) * (ulong) missionDataManager.AllianceMissionBonusRate / 100UL);
    }
    rewardItem[0] = this.MissionData.TimeMission[this.DataIndex].ItemID;
    if (rewardItem[0] <= (ushort) 0)
      return;
    count[0] = (ushort) 1;
  }

  public override void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 6:
        int num = 19;
        if (this.MissionType == _eMissionType.Alliance)
          num = 20;
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BagFilter, 2, num);
        Debug.Log((object) "Speed Mission");
        break;
      case 7:
        DataManager.MissionDataManager.sendTimeMissionReward(this.MissionType, (byte) (sender.m_BtnID3 + 1));
        RectTransform component1 = this.transform.parent.parent.parent.parent.GetComponent<RectTransform>();
        RectTransform component2 = this.transform.parent.parent.parent.GetComponent<RectTransform>();
        RectTransform component3 = this.transform.parent.parent.GetComponent<RectTransform>();
        RectTransform component4 = this.transform.parent.transform.GetComponent<RectTransform>();
        RectTransform component5 = this.transform.GetComponent<RectTransform>();
        RectTransform component6 = ((Component) sender).transform.GetComponent<RectTransform>();
        GUIManager.Instance.mStartV2 = new Vector2((float) ((double) ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x / 2.0 + (double) component1.anchoredPosition.x - (double) component1.sizeDelta.x / 2.0) + component2.anchoredPosition.x + component5.anchoredPosition.x + component6.anchoredPosition.x, (float) ((double) ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.y / 2.0 - (double) component1.anchoredPosition.y - (double) component1.sizeDelta.y / 2.0) - component2.anchoredPosition.y - component3.anchoredPosition.y - component4.anchoredPosition.y - component6.anchoredPosition.y);
        Debug.Log((object) "Reward Mission");
        break;
      case 8:
        DataManager.MissionDataManager.sendTimeMissionStart(this.MissionType, (byte) (sender.m_BtnID3 + 1));
        break;
    }
  }

  public override void TextRefresh()
  {
    ((Behaviour) this.NameText).enabled = false;
    ((Behaviour) this.NameText).enabled = true;
    ((Behaviour) this.RewardText).enabled = false;
    ((Behaviour) this.RewardText).enabled = true;
  }

  public enum UIControl
  {
    MissionPic,
    MissionName,
    BarLink,
    Reward,
    Select,
  }
}
