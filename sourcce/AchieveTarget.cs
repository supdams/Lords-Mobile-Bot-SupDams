// Decompiled with JetBrains decompiler
// Type: AchieveTarget
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class AchieveTarget : ManorAimMission
{
  private _MissionSlot[] MissionSlot;
  private UIText[] BtnText;

  public AchieveTarget(Transform transform, Sprite Background)
    : base(transform)
  {
    this.transform = transform;
    this.TitleText = transform.GetChild(0).GetComponent<UIText>();
    this.TitleText.text = DataManager.Instance.mStringTable.GetStringByID(1532U);
    this.MissionSlot = new _MissionSlot[ManorAimMission.MaxSlot];
    this.BtnText = new UIText[ManorAimMission.MaxSlot];
    transform.GetComponent<Image>().sprite = Background;
    for (int index = 0; index < ManorAimMission.MaxSlot; ++index)
    {
      this.MissionSlot[index] = new _MissionSlot();
      this.MissionSlot[index].Init(transform.GetChild(1 + index), (UIMissionItem) this);
      this.ItemBtn[index] = this.MissionSlot[index].ItemBtn;
      this.ItemBtn[index].m_BtnID2 = 1;
      this.ItemBtn[index].m_BtnID4 = index;
      this.BtnText[index] = this.MissionSlot[index].transform.GetChild(1).GetChild(1).GetComponent<UIText>();
    }
  }

  public override void SetMissionData(int Index)
  {
    if (!this.transform.gameObject.activeSelf)
      return;
    this.DataIndex = Index;
    MissionManager missionDataManager = DataManager.MissionDataManager;
    CString cstring = StringManager.Instance.StaticString1024();
    for (ushort index = 0; (int) index < this.MissionSlot.Length; ++index)
    {
      if (this.SlotCount > (int) index)
      {
        ushort missionId = missionDataManager.GetMissionID(missionDataManager.RewardList.Priority[(int) index]);
        ManorAimTbl recordByKey = missionDataManager.ManorAimTable.GetRecordByKey(missionId);
        missionDataManager.GetNarrative(cstring, ref recordByKey);
        this.MissionSlot[(int) index].TimdHandle = this.TimeHandle;
        this.MissionSlot[(int) index].SetText(cstring);
        this.MissionSlot[(int) index].transform.gameObject.SetActive(true);
        this.MissionSlot[(int) index].Reward.m_BtnID3 = (int) missionId;
        this.ItemBtn[(int) index].m_BtnID3 = (int) missionId;
      }
      else
        this.MissionSlot[(int) index].transform.gameObject.SetActive(false);
    }
  }

  public override void Destroy()
  {
    for (int index = 0; index < ManorAimMission.MaxSlot; ++index)
      this.MissionSlot[index].Destroy();
  }

  public override void Update()
  {
    for (int index = 0; index < ManorAimMission.MaxSlot; ++index)
      this.MissionSlot[index].Update();
  }

  public override float GetHeight()
  {
    this.SlotCount = (int) DataManager.MissionDataManager.GetRewardCount(ManorAimMission.MaxSlot);
    if (this.SlotCount == 0)
    {
      this.transform.gameObject.SetActive(false);
      return 0.0f;
    }
    this.transform.gameObject.SetActive(true);
    return (float) (39.0 + 64.0 * (double) this.SlotCount);
  }

  public override void SetSelect(
    bool bSelect,
    int index,
    uint[] reward = null,
    ushort[] rewardItem = null,
    ushort[] count = null)
  {
    this.SelectTrans = this.MissionSlot[index].SelectTrans;
    this.SelectTrans.gameObject.SetActive(bSelect);
    base.SetSelect(bSelect, index, reward, rewardItem, count);
  }

  public override void OnButtonClick(UIButton sender)
  {
    ushort btnId3 = (ushort) sender.m_BtnID3;
    ManorAimTbl recordByKey = DataManager.MissionDataManager.ManorAimTable.GetRecordByKey(btnId3);
    if ((int) recordByKey.MissionKind - 1 == 0)
      DataManager.MissionDataManager.sendMissionComplete(btnId3, GUIManager.Instance.BuildingData.GetBuildData(recordByKey.Parm1, (ushort) 0).ManorID);
    else
      DataManager.MissionDataManager.sendMissionComplete(btnId3, (ushort) 0);
    RectTransform component1 = this.transform.parent.parent.parent.parent.GetComponent<RectTransform>();
    RectTransform component2 = this.transform.parent.parent.parent.GetComponent<RectTransform>();
    RectTransform component3 = this.transform.parent.GetComponent<RectTransform>();
    RectTransform component4 = this.transform.GetComponent<RectTransform>();
    RectTransform component5 = ((Component) sender).transform.parent.GetComponent<RectTransform>();
    RectTransform component6 = ((Component) sender).transform.GetComponent<RectTransform>();
    RectTransform component7 = this.transform.parent.parent.GetComponent<RectTransform>();
    GUIManager.Instance.mStartV2 = new Vector2((float) ((double) ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x / 2.0 + (double) component1.anchoredPosition.x - (double) component1.sizeDelta.x / 2.0) + component2.anchoredPosition.x + component3.anchoredPosition.x + component4.anchoredPosition.x + component5.anchoredPosition.x + component6.anchoredPosition.x, (float) ((double) ((Component) GUIManager.Instance.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.y / 2.0 - (double) component7.anchoredPosition.y - (double) component1.anchoredPosition.y - (double) component1.sizeDelta.y / 2.0) - component2.anchoredPosition.y - component3.anchoredPosition.y - component4.anchoredPosition.y - component5.anchoredPosition.y - component6.anchoredPosition.y);
  }

  public override void TextRefresh()
  {
    base.TextRefresh();
    for (int index = 0; index < this.MissionSlot.Length; ++index)
    {
      ((Behaviour) this.MissionSlot[index].NameText).enabled = false;
      ((Behaviour) this.MissionSlot[index].NameText).enabled = true;
      ((Behaviour) this.BtnText[index]).enabled = false;
      ((Behaviour) this.BtnText[index]).enabled = true;
    }
  }

  public enum UIControl
  {
    Title,
    Mission1,
    Mission2,
    Mission3,
    Mission4,
    Mission5,
    Select,
  }
}
