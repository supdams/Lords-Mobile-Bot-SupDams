// Decompiled with JetBrains decompiler
// Type: UIMissionItemController
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIMissionItemController : iMissionTimeDelta, IUIButtonClickHandler
{
  private ScrollPanel scrollPanel;
  private RectTransform RectSecroll;
  private RectTransform Content;
  private Transform ControllerTrans;
  private Transform TitleTrans;
  private Transform NoMission;
  private Transform TimebarTrans;
  public UIText NoMissionText;
  public UIText TimeText;
  public UIText AllianceBoundRateText;
  private CString NoMissionStr;
  private CString TimeStr;
  private CString AllianceBoundRateStr;
  private UIButton InfoBtn;
  private UIButton ResetBtn;
  private UISpritesArray AffairSpriteArray;
  private UISpritesArray ReCommandSpriteArray;
  private UISpritesArray ManorKindSpriteArray;
  private byte MaxItemCount;
  private UIMissionItem[][] MissionListItem;
  private VIPMission vipMission;
  public eMissionClickType CurrentTag = eMissionClickType.MaxTag;
  private int Oldid;
  private ScrollPanelItem[] scrollItem;
  private List<float> ItemsHeight = new List<float>();
  public List<byte> MissionList = new List<byte>();
  public Transform[] ItemSample = new Transform[4];
  private UIMissionItem Select;
  private UIMission GUIWin;
  private int SelectIndex;
  private int SelectDataIndex;
  private _MissionTimeBar TimebarData;
  private _MissionTimeBar VIPTimebar;
  private float DeltaTime;
  private float SmoothTime;
  private float[] OffsetX = new float[3]
  {
    21.48f,
    18.4f,
    18.4f
  };
  private float UpdateTime = 0.2f;

  public UIMissionItemController(UIMission GUIWin, Transform listTrans, byte MaxItemCount)
  {
    this.ControllerTrans = listTrans;
    this.MaxItemCount = MaxItemCount;
    this.GUIWin = GUIWin;
    this.ManorKindSpriteArray = this.ControllerTrans.GetChild(3).GetChild(1).GetComponent<UISpritesArray>();
    this.scrollPanel = this.ControllerTrans.GetChild(2).GetComponent<ScrollPanel>();
    for (int index = 0; index < (int) MaxItemCount; ++index)
      this.ItemsHeight.Add(106f);
    this.scrollPanel.IntiScrollPanel(429f, 0.0f, 0.0f, this.ItemsHeight, (int) MaxItemCount, (IUpDateScrollPanel) GUIWin);
    this.scrollPanel.gameObject.SetActive(true);
    this.RectSecroll = this.scrollPanel.transform.GetComponent<RectTransform>();
    this.Content = this.scrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
    this.AffairSpriteArray = this.ControllerTrans.GetChild(3).GetComponent<UISpritesArray>();
    this.ReCommandSpriteArray = this.ControllerTrans.GetChild(3).GetChild(0).GetComponent<UISpritesArray>();
    this.TitleTrans = this.ControllerTrans.GetChild(0);
    this.NoMission = this.ControllerTrans.GetChild(1);
    this.NoMissionText = this.NoMission.GetChild(0).GetComponent<UIText>();
    this.NoMissionStr = StringManager.Instance.SpawnString(150);
    this.AllianceBoundRateText = this.NoMission.GetChild(1).GetComponent<UIText>();
    this.AllianceBoundRateStr = StringManager.Instance.SpawnString(150);
    this.AllianceBoundRateStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(1525U));
    this.AllianceBoundRateStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(1003U));
    this.AllianceBoundRateText.text = this.AllianceBoundRateStr.ToString();
    this.TimeStr = StringManager.Instance.SpawnString(100);
    this.TimeText = this.ControllerTrans.GetChild(0).GetChild(3).GetComponent<UIText>();
    this.ResetBtn = this.ControllerTrans.GetChild(0).GetChild(0).GetComponent<UIButton>();
    this.ResetBtn.m_BtnID1 = 10;
    this.ResetBtn.m_Handler = (IUIButtonClickHandler) this;
    UIButtonHint uiButtonHint = this.ControllerTrans.GetChild(0).GetChild(1).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint.m_Handler = (MonoBehaviour) GUIWin;
    uiButtonHint.Parm1 = (ushort) 1566;
    uiButtonHint.ControlFadeOut = ((Component) GUIWin.HintRect).gameObject;
    this.InfoBtn = this.ControllerTrans.GetChild(0).GetChild(2).GetComponent<UIButton>();
    this.InfoBtn.m_BtnID1 = 9;
    this.InfoBtn.m_Handler = (IUIButtonClickHandler) this;
    if (GUIManager.Instance.IsArabic)
      ((Component) this.InfoBtn).transform.localScale = new Vector3(-1f, 1f, 1f);
    this.TimebarTrans = this.ControllerTrans.GetChild(4);
    this.TimebarData.transform = this.TimebarTrans.GetChild(0).GetComponent<RectTransform>();
    this.TimebarData.TimeBar = this.TimebarTrans.GetChild(0).GetChild(0).GetComponent<UITimeBar>();
    this.TimebarData.Speed = this.TimebarTrans.GetChild(0).GetChild(1).GetComponent<UIButton>();
    this.TimebarData.Speed.m_BtnID1 = 6;
    this.TimebarData.Speed.m_Handler = (IUIButtonClickHandler) this;
    GUIManager.Instance.CreateTimerBar(this.TimebarData.TimeBar, 0L, 0L, 0L, eTimeBarType.UIMission, string.Empty, string.Empty);
    this.VIPTimebar.transform = this.TimebarTrans.GetChild(1).GetComponent<RectTransform>();
    this.VIPTimebar.TimeBar = this.TimebarTrans.GetChild(1).GetChild(0).GetComponent<UITimeBar>();
    this.VIPTimebar.Speed = this.TimebarTrans.GetChild(1).GetChild(1).GetComponent<UIButton>();
    this.VIPTimebar.Speed.m_BtnID1 = 12;
    this.VIPTimebar.Speed.m_Handler = (IUIButtonClickHandler) this;
    GUIManager.Instance.CreateTimerBar(this.VIPTimebar.TimeBar, 0L, 0L, 0L, eTimeBarType.UIMission, string.Empty, string.Empty);
    this.MissionListItem = new UIMissionItem[4][];
    this.scrollItem = new ScrollPanelItem[(int) MaxItemCount];
    for (int index = 0; index < (int) MaxItemCount; ++index)
      this.scrollItem[index] = ((Transform) this.Content).GetChild(index).GetComponent<ScrollPanelItem>();
  }

  public bool ChangeTag(eMissionClickType Tag, bool ForceUpdate = false)
  {
    if (!ForceUpdate && this.CurrentTag == Tag)
      return false;
    if (DataManager.Instance.RoleAlliance.Id == 0U && Tag == eMissionClickType.Tag3)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      DataManager.Instance.SetSelectRequest = 0;
      menu.OpenMenu(EGUIWindow.UI_AllianceHint);
      return false;
    }
    if (this.Select != null)
      this.Select.SetSelect(false, this.SelectIndex);
    if (this.CurrentTag != eMissionClickType.Tag4)
      this.Oldid = (int) this.CurrentTag;
    this.CurrentTag = Tag;
    int currentTag = (int) this.CurrentTag;
    if (this.NoMission.gameObject.activeSelf)
      this.NoMission.gameObject.SetActive(false);
    if (!this.scrollPanel.gameObject.activeSelf)
      this.scrollPanel.gameObject.SetActive(true);
    if (this.CurrentTag != eMissionClickType.Tag1)
      this.SetScrollViewRange((byte) 1);
    else
      this.SetScrollViewRange((byte) 2);
    if (this.MissionListItem[currentTag] == null)
    {
      this.MissionListItem[currentTag] = new UIMissionItem[(int) this.MaxItemCount];
      for (int index = 0; index < (int) this.MaxItemCount; ++index)
      {
        switch (this.CurrentTag)
        {
          case eMissionClickType.Tag1:
            switch (index)
            {
              case 0:
                this.MissionListItem[currentTag][index] = (UIMissionItem) new ReCommandMission(UnityEngine.Object.Instantiate((UnityEngine.Object) this.ItemSample[2]) as Transform, this.ReCommandSpriteArray);
                break;
              case 1:
                this.MissionListItem[currentTag][index] = (UIMissionItem) new AchieveTarget(UnityEngine.Object.Instantiate((UnityEngine.Object) this.ItemSample[0]) as Transform, this.ManorKindSpriteArray.GetSprite(0));
                break;
              default:
                this.MissionListItem[currentTag][index] = (UIMissionItem) new ManorMissionKind(UnityEngine.Object.Instantiate((UnityEngine.Object) this.ItemSample[0]) as Transform, (eUIMissionKind) (index - 2), this.ManorKindSpriteArray);
                break;
            }
            this.MissionListItem[currentTag][index].TimeHandle = (iMissionTimeDelta) this;
            break;
          case eMissionClickType.Tag2:
            this.MissionListItem[currentTag][index] = (UIMissionItem) new AffairMission(UnityEngine.Object.Instantiate((UnityEngine.Object) this.ItemSample[1]) as Transform, this.AffairSpriteArray, this.TimebarData);
            if (this.MissionListItem[currentTag + 1] == null)
              this.MissionListItem[currentTag + 1] = new UIMissionItem[(int) this.MaxItemCount];
            this.MissionListItem[currentTag + 1][index] = this.MissionListItem[currentTag][index];
            this.MissionListItem[currentTag + 1][index].TimeHandle = (iMissionTimeDelta) this;
            break;
          case eMissionClickType.Tag3:
            this.MissionListItem[currentTag][index] = (UIMissionItem) new AffairMission(UnityEngine.Object.Instantiate((UnityEngine.Object) this.ItemSample[1]) as Transform, this.AffairSpriteArray, this.TimebarData);
            if (this.MissionListItem[currentTag - 1] == null)
              this.MissionListItem[currentTag - 1] = new UIMissionItem[(int) this.MaxItemCount];
            this.MissionListItem[currentTag - 1][index] = this.MissionListItem[currentTag][index];
            this.MissionListItem[currentTag - 1][index].TimeHandle = (iMissionTimeDelta) this;
            break;
          case eMissionClickType.Tag4:
            if (this.vipMission == null)
              this.vipMission = new VIPMission(this.ItemSample[3], this.VIPTimebar);
            this.vipMission.TimdHandle = (iMissionTimeDelta) this;
            break;
        }
        if (this.CurrentTag == eMissionClickType.Tag4)
          break;
      }
    }
    if (this.CurrentTag == eMissionClickType.Tag4)
    {
      this.ControllerTrans.gameObject.SetActive(false);
      this.vipMission.SetAchieve(true);
      return true;
    }
    if (!this.ControllerTrans.gameObject.activeSelf)
    {
      this.vipMission.SetAchieve(false);
      this.ControllerTrans.gameObject.SetActive(true);
    }
    bool flag = true;
    if (this.Oldid == 1 && this.CurrentTag == eMissionClickType.Tag3 || this.Oldid == 2 && this.CurrentTag == eMissionClickType.Tag2)
      flag = false;
    if (this.CurrentTag == eMissionClickType.Tag2 || this.CurrentTag == eMissionClickType.Tag3)
    {
      for (int index = 0; index < (int) this.MaxItemCount; ++index)
      {
        AffairMission affairMission = this.MissionListItem[currentTag][index] as AffairMission;
        if (this.CurrentTag == eMissionClickType.Tag2)
          affairMission.SetType(_eMissionType.Affair);
        else
          affairMission.SetType(_eMissionType.Alliance);
      }
    }
    if (flag)
    {
      for (byte index1 = 0; (int) index1 < (int) this.MaxItemCount; ++index1)
      {
        if (this.MissionListItem.Length > this.Oldid && this.MissionListItem[this.Oldid][(int) index1] != null)
          this.MissionListItem[this.Oldid][(int) index1].transform.gameObject.SetActive(false);
        if ((UnityEngine.Object) this.MissionListItem[currentTag][(int) index1].transform.parent == (UnityEngine.Object) null)
          this.MissionListItem[currentTag][(int) index1].transform.SetParent(((Transform) this.Content).GetChild((int) index1));
        this.MissionListItem[currentTag][(int) index1].transform.localPosition = new Vector3(this.OffsetX[currentTag], 0.0f, 0.0f);
        this.MissionListItem[currentTag][(int) index1].transform.localScale = Vector3.one;
        this.MissionListItem[currentTag][(int) index1].transform.gameObject.SetActive(true);
        for (int index2 = 0; index2 < this.MissionListItem[currentTag][(int) index1].ItemBtn.Length; ++index2)
        {
          if ((UnityEngine.Object) this.MissionListItem[currentTag][(int) index1].ItemBtn[index2] != (UnityEngine.Object) null)
            this.MissionListItem[currentTag][(int) index1].ItemBtn[index2].m_Handler = (IUIButtonClickHandler) this;
        }
      }
    }
    this.ItemsHeight.Clear();
    float num = 0.0f;
    ushort itemCount = this.GetItemCount();
    for (int index = 0; index < (int) itemCount; ++index)
    {
      if (index < this.MissionListItem[currentTag].Length)
        num = this.MissionListItem[currentTag][index].GetHeight();
      this.ItemsHeight.Add(num);
    }
    Vector2 vector2 = Vector2.zero;
    int itemidx = 0;
    this.Select = (UIMissionItem) null;
    if (itemCount > (ushort) 0)
    {
      if (ForceUpdate)
      {
        vector2 = this.Content.anchoredPosition;
        itemidx = this.scrollPanel.GetBeginIdx();
      }
      this.scrollPanel.AddNewDataHeight(this.ItemsHeight, this.RectSecroll.sizeDelta.y);
    }
    this.ResetBtn.m_BtnID2 = (int) this.CurrentTag;
    this.InfoBtn.m_BtnID2 = (int) this.CurrentTag;
    this.UpdateTime = 0.0f;
    this.Update();
    if (itemCount > (ushort) 0 && ForceUpdate)
      this.scrollPanel.GoTo(itemidx, vector2.y);
    if (this.CurrentTag == eMissionClickType.Tag1 && DataManager.MissionDataManager.RewardList.Priority.Count > 0)
      this.OnButtonClick(this.MissionListItem[currentTag][1].ItemBtn[0]);
    else if (this.MissionListItem[currentTag][0] != null)
      this.OnButtonClick(this.MissionListItem[currentTag][0].ItemBtn[0]);
    return true;
  }

  public void SetScrollViewRange(byte Type)
  {
    if (Type == (byte) 1)
    {
      this.TitleTrans.gameObject.SetActive(true);
      Vector2 anchoredPosition = this.RectSecroll.anchoredPosition;
      anchoredPosition.Set(anchoredPosition.x, -53f);
      this.RectSecroll.anchoredPosition = anchoredPosition;
      Vector2 sizeDelta = this.RectSecroll.sizeDelta;
      sizeDelta.Set(sizeDelta.x, 410.8f);
      this.RectSecroll.sizeDelta = sizeDelta;
    }
    else
    {
      this.TitleTrans.gameObject.SetActive(false);
      Vector2 anchoredPosition = this.RectSecroll.anchoredPosition;
      anchoredPosition.Set(anchoredPosition.x, 4.06f);
      this.RectSecroll.anchoredPosition = anchoredPosition;
      Vector2 sizeDelta = this.RectSecroll.sizeDelta;
      sizeDelta.Set(sizeDelta.x, 468.32f);
      this.RectSecroll.sizeDelta = sizeDelta;
    }
  }

  public ushort GetItemCount(eMissionClickType Tag = eMissionClickType.None)
  {
    if (Tag == eMissionClickType.None)
      Tag = this.CurrentTag;
    this.MissionList.Clear();
    switch (Tag)
    {
      case eMissionClickType.Tag1:
        for (byte index = 0; index < (byte) 8; ++index)
          this.MissionList.Add(index);
        return (ushort) this.MissionList.Count;
      case eMissionClickType.Tag2:
      case eMissionClickType.Tag3:
        _eMissionType Type = Tag != eMissionClickType.Tag2 ? _eMissionType.Alliance : _eMissionType.Affair;
        ushort itemCount = 0;
        TimerTypeMission timerMissionData = DataManager.MissionDataManager.GetTimerMissionData(Type);
        for (byte index1 = 0; (int) index1 < (int) timerMissionData.MissionCount; ++index1)
        {
          if (timerMissionData.TimeMission[(int) index1].State != _eTimerMissionState.Complete)
          {
            this.MissionList.Add(timerMissionData.TimeMission[(int) index1].Index);
            if (itemCount > (ushort) 0 && (timerMissionData.TimeMission[(int) index1].State == _eTimerMissionState.Reward || timerMissionData.TimeMission[(int) index1].State == _eTimerMissionState.Countdown))
            {
              for (int index2 = (int) itemCount; index2 > 0; --index2)
              {
                this.MissionList[index2 - 1] = (byte) ((uint) this.MissionList[index2 - 1] ^ (uint) this.MissionList[index2]);
                this.MissionList[index2] ^= this.MissionList[index2 - 1];
                this.MissionList[index2 - 1] = (byte) ((uint) this.MissionList[index2 - 1] ^ (uint) this.MissionList[index2]);
              }
            }
            ++itemCount;
          }
        }
        return itemCount;
      default:
        return 0;
    }
  }

  public float GetDeltaTime() => this.DeltaTime;

  public float GetSmoothDeltaTime() => this.SmoothTime;

  public void Destroy()
  {
    StringManager.Instance.DeSpawnString(this.TimeStr);
    StringManager.Instance.DeSpawnString(this.NoMissionStr);
    StringManager.Instance.DeSpawnString(this.AllianceBoundRateStr);
    for (byte index1 = 0; (int) index1 < this.MissionListItem.Length; ++index1)
    {
      if (this.MissionListItem[(int) index1] != null)
      {
        for (byte index2 = 0; (int) index2 < this.MissionListItem[(int) index1].Length; ++index2)
        {
          if (this.MissionListItem[(int) index1][(int) index2] != null)
            this.MissionListItem[(int) index1][(int) index2].Destroy();
        }
      }
    }
    GUIManager.Instance.RemoverTimeBaarToList(this.TimebarData.TimeBar);
    GUIManager.Instance.RemoverTimeBaarToList(this.VIPTimebar.TimeBar);
    if (this.vipMission == null)
      return;
    this.vipMission.Destroy();
  }

  public void UpdateItem(int dataIndex, int panelIndex)
  {
    if (this.CurrentTag == eMissionClickType.MaxTag || this.MissionListItem[(int) this.CurrentTag] == null)
      return;
    this.MissionListItem[(int) this.CurrentTag][panelIndex].SetMissionData((int) this.MissionList[dataIndex]);
    if (this.Select == null || this.SelectDataIndex != (int) this.MissionList[dataIndex])
      return;
    this.MissionListItem[(int) this.CurrentTag][panelIndex].SetSelect(true);
  }

  public void Update()
  {
    if (this.CurrentTag == eMissionClickType.MaxTag)
      return;
    byte currentTag = (byte) this.CurrentTag;
    for (int index = 0; index < this.MissionListItem[(int) currentTag].Length; ++index)
    {
      if (this.MissionListItem[(int) currentTag][index] != null)
        this.MissionListItem[(int) currentTag][index].Update();
    }
    this.DeltaTime += Time.deltaTime;
    this.SmoothTime += Time.smoothDeltaTime;
    if ((double) this.DeltaTime >= 2.0)
      this.DeltaTime = 0.0f;
    this.UpdateTime -= Time.deltaTime;
    if ((double) this.UpdateTime > 0.0)
      return;
    this.UpdateTime = 0.2f;
    if (this.CurrentTag == eMissionClickType.Tag1)
    {
      if (this.MissionList.Count == 0 && this.scrollPanel.gameObject.activeSelf)
      {
        this.scrollPanel.gameObject.SetActive(false);
        this.NoMission.gameObject.SetActive(true);
        this.NoMissionText.text = DataManager.Instance.mStringTable.GetStringByID(1539U);
      }
    }
    else if (this.CurrentTag == eMissionClickType.Tag2 || this.CurrentTag == eMissionClickType.Tag3)
    {
      TimerTypeMission timerMissionData = DataManager.MissionDataManager.GetTimerMissionData((_eMissionType) this.CurrentTag);
      this.TimeStr.ClearString();
      this.TimeStr.Append(DataManager.MissionDataManager.FormatMissionTime((uint) Math.Max(timerMissionData.ResetTime - DataManager.Instance.ServerTime, 0L)));
      this.TimeText.text = this.TimeStr.ToString();
      this.TimeText.SetAllDirty();
      this.TimeText.cachedTextGenerator.Invalidate();
      if (this.MissionList.Count == 0)
      {
        if (this.scrollPanel.gameObject.activeSelf)
        {
          this.scrollPanel.gameObject.SetActive(false);
          this.NoMission.gameObject.SetActive(true);
          this.UpdateAllianceBoundRate();
        }
        StringTable mStringTable = DataManager.Instance.mStringTable;
        this.NoMissionStr.ClearString();
        this.NoMissionStr.StringToFormat(mStringTable.GetStringByID(1544U));
        this.NoMissionStr.StringToFormat("\n");
        this.NoMissionStr.StringToFormat(this.TimeStr);
        this.NoMissionStr.AppendFormat("{0}{1}{2}");
        this.NoMissionText.text = this.NoMissionStr.ToString();
        this.NoMissionText.SetAllDirty();
        this.NoMissionText.cachedTextGenerator.Invalidate();
      }
    }
    else if (this.CurrentTag == eMissionClickType.Tag4)
      this.vipMission.Update();
    this.SmoothTime = 0.0f;
  }

  private void UpdateAllianceBoundRate()
  {
    if (this.MissionList.Count != 0 || this.scrollPanel.gameObject.activeSelf)
      return;
    if (this.CurrentTag == eMissionClickType.Tag3 && DataManager.MissionDataManager.AllianceMissionBonusRate > (ushort) 100)
      ((Component) this.AllianceBoundRateText).gameObject.SetActive(true);
    else
      ((Component) this.AllianceBoundRateText).gameObject.SetActive(false);
  }

  public void Update(int arg1, int arg2)
  {
    bool flag = true;
    eMissionUpdateType missionUpdateType = (eMissionUpdateType) arg1;
    switch (missionUpdateType)
    {
      case eMissionUpdateType.MissionState:
        if (this.CurrentTag == eMissionClickType.Tag2 || this.CurrentTag == eMissionClickType.Tag3)
        {
          for (int index = 0; index < this.MissionListItem[(int) this.CurrentTag].Length; ++index)
            this.MissionListItem[(int) this.CurrentTag][index].SetMissionData(this.MissionListItem[(int) this.CurrentTag][index].DataIndex);
          break;
        }
        break;
      case eMissionUpdateType.MissionStart:
        if (this.CurrentTag == eMissionClickType.Tag2 || this.CurrentTag == eMissionClickType.Tag3)
        {
          int num = this.MissionList.BinarySearch(DataManager.MissionDataManager.GetTimerMissionData(this.CurrentTag != eMissionClickType.Tag2 ? _eMissionType.Alliance : _eMissionType.Affair).ProcessIdx);
          if (num < 0)
            return;
          if (num != 0)
          {
            for (int index = num; index > 0; --index)
            {
              this.MissionList[index - 1] = (byte) ((uint) this.MissionList[index - 1] ^ (uint) this.MissionList[index]);
              this.MissionList[index] ^= this.MissionList[index - 1];
              this.MissionList[index - 1] = (byte) ((uint) this.MissionList[index - 1] ^ (uint) this.MissionList[index]);
            }
          }
          this.scrollPanel.GoTo(0, 0.0f);
          for (int index = 0; index < this.MissionListItem[(int) this.CurrentTag].Length && index < this.MissionList.Count; ++index)
            this.MissionListItem[(int) this.CurrentTag][index].SetMissionData((int) this.MissionList[index]);
          break;
        }
        break;
      case eMissionUpdateType.UpdateMissionCount:
        this.ChangeTag(this.CurrentTag, true);
        break;
      case eMissionUpdateType.CheckAlliance:
        DataManager instance = DataManager.Instance;
        if (instance.RoleAlliance.Id == 0U && this.CurrentTag == eMissionClickType.Tag3)
        {
          GUIManager.Instance.OpenMessageBox(instance.mStringTable.GetStringByID(3782U), instance.mStringTable.GetStringByID(1569U), instance.mStringTable.GetStringByID(3784U));
          (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu_Alliance(EGUIWindow.UI_Mission);
          break;
        }
        break;
      default:
        if (missionUpdateType != eMissionUpdateType.UpdateManorAim)
        {
          if (missionUpdateType == eMissionUpdateType.UpdateAllianceBoundRate)
          {
            flag = false;
            this.GUIWin.UpdatAllianceUpGrade();
            this.UpdateAllianceBoundRate();
            break;
          }
          break;
        }
        if (this.Select is ManorAimMission select)
        {
          int index = this.SelectIndex;
          this.ChangeTag(this.CurrentTag, true);
          if (select.SlotCount > 0)
          {
            if (index >= select.SlotCount)
              index = select.SlotCount - 1;
            this.GUIWin.OnButtonClick(select.ItemBtn[index]);
            arg2 = 1;
            break;
          }
          break;
        }
        break;
    }
    if (!flag || arg1 <= 0 || this.MissionList.Count <= 0 || arg2 != 0 || this.MissionListItem[(int) this.CurrentTag][0] == null)
      return;
    this.OnButtonClick(this.MissionListItem[(int) this.CurrentTag][0].ItemBtn[0]);
  }

  public void SetSelect(
    int dataIndex,
    int index,
    uint[] reward,
    ushort[] rewardItem,
    ushort[] Count)
  {
    if (this.MissionList.Count == 0)
    {
      Array.Clear((Array) reward, 0, reward.Length);
      Array.Clear((Array) rewardItem, 0, rewardItem.Length);
      Array.Clear((Array) Count, 0, Count.Length);
    }
    else
    {
      int currentTag = (int) this.CurrentTag;
      for (int index1 = 0; index1 < this.MissionListItem[currentTag].Length && this.MissionListItem[currentTag][index1] != null; ++index1)
      {
        if (this.MissionListItem[currentTag][index1].DataIndex == dataIndex)
        {
          if (this.Select != null)
            this.Select.SetSelect(false, this.SelectIndex);
          this.SelectIndex = index;
          this.MissionListItem[currentTag][index1].SetSelect(true, index, reward, rewardItem, Count);
          this.Select = this.MissionListItem[currentTag][index1];
          this.SelectDataIndex = this.Select.DataIndex;
          break;
        }
      }
    }
  }

  public ushort GetQuality(int dataIndex, int index)
  {
    return this.CurrentTag == eMissionClickType.Tag2 || this.CurrentTag == eMissionClickType.Tag3 ? DataManager.MissionDataManager.GetTimerMissionData((_eMissionType) this.CurrentTag).TimeMission[dataIndex].Quality : (ushort) 0;
  }

  public void OnButtonClick(UIButton sender)
  {
    StringTable mStringTable = DataManager.Instance.mStringTable;
    switch (sender.m_BtnID1)
    {
      case 9:
        switch (sender.m_BtnID2)
        {
          case 0:
            return;
          case 1:
            GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(1524U), mStringTable.GetStringByID(3799U), BackExit: true);
            return;
          case 2:
            GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(1525U), mStringTable.GetStringByID(3800U), BackExit: true);
            return;
          default:
            return;
        }
      case 10:
        switch (sender.m_BtnID2)
        {
          case 0:
            return;
          case 1:
            GUIManager.Instance.UseOrSpend((ushort) 1112, mStringTable.GetStringByID(1513U), (ushort) 0, (ushort) 0, (ushort) 0, maxcount: (ushort) 0);
            return;
          case 2:
            GUIManager.Instance.UseOrSpend((ushort) 1113, mStringTable.GetStringByID(1515U), (ushort) 0, (ushort) 0, (ushort) 0, maxcount: (ushort) 0);
            return;
          case 3:
            return;
          default:
            return;
        }
      case 11:
        this.GUIWin.OnButtonClick(sender);
        break;
      case 12:
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BagFilter, 2, 21);
        break;
    }
  }

  public void TextRefresh()
  {
    ((Behaviour) this.NoMissionText).enabled = false;
    ((Behaviour) this.NoMissionText).enabled = true;
    ((Behaviour) this.AllianceBoundRateText).enabled = false;
    ((Behaviour) this.AllianceBoundRateText).enabled = true;
    ((Behaviour) this.TimeText).enabled = false;
    ((Behaviour) this.TimeText).enabled = true;
    this.TimebarData.TimeBar.Refresh_FontTexture();
    this.VIPTimebar.TimeBar.Refresh_FontTexture();
    if (this.vipMission != null)
      this.vipMission.TextRefresh();
    for (byte index1 = 0; (int) index1 < this.MissionListItem.Length; ++index1)
    {
      if (this.MissionListItem[(int) index1] != null)
      {
        for (byte index2 = 0; (int) index2 < this.MissionListItem[(int) index1].Length; ++index2)
        {
          if (this.MissionListItem[(int) index1][(int) index2] != null)
            this.MissionListItem[(int) index1][(int) index2].TextRefresh();
        }
      }
    }
  }

  public enum MissionListControl
  {
    Title,
    NoMission,
    Scroll,
    SpriteArray,
    TimeBar,
  }
}
