// Decompiled with JetBrains decompiler
// Type: UIPetTrainingCenter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal class UIPetTrainingCenter : 
  GUIWindow,
  IBuildingWindowType,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUTimeBarOnTimer
{
  private const byte BUILD_ID = 23;
  private const int PANEL_OBJECT_COUNT = 6;
  private BuildingWindow m_BuildingWindow;
  private ushort m_ManorID;
  private ScrollPanel m_ScrollPanel;
  private Transform m_BgPenel;
  private UIPetTrainingCenter.SSrollPanelItem[] m_ScrollObjects;
  private UIText[] m_AdditionExpText;
  private UIText[] m_TrainCountText;
  private bool bInitScroll;
  private UIPetTrainingCenter.EUIPage m_UIType;
  private PetManager PetMgr;
  private CString[] m_CStr;
  private UISpritesArray m_Sp;

  public override void OnOpen(int arg1, int arg2)
  {
    this.m_ManorID = (ushort) arg1;
    int num = (int) PetManager.Instance.SortPetIdle();
    this.PetMgr = PetManager.Instance;
    this.m_Sp = this.transform.GetComponent<UISpritesArray>();
    this.m_ScrollObjects = new UIPetTrainingCenter.SSrollPanelItem[6];
    for (int index = 0; index < this.m_ScrollObjects.Length; ++index)
      this.m_ScrollObjects[index] = new UIPetTrainingCenter.SSrollPanelItem(this.m_Sp);
    this.m_AdditionExpText = new UIText[2];
    this.m_TrainCountText = new UIText[2];
    this.SpawnString();
    this.Init();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
    if (GUIManager.Instance.BuildingData.AllBuildsData[(int) this.m_ManorID].Level == (byte) 0)
      return;
    NewbieManager.CheckPetTraining();
  }

  public override void OnClose()
  {
    if ((Object) this.m_BuildingWindow != (Object) null)
      this.m_BuildingWindow.DestroyBuildingWindow();
    this.DeSpawnString();
    if (!((Object) this.m_ScrollPanel != (Object) null))
      return;
    this.PetMgr.m_TrainListIndex = this.m_ScrollPanel.GetTopIdx();
    this.PetMgr.m_TrainListY = this.m_ScrollPanel.GetContentPos();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    this.UpdateScrollPanel();
    this.UpdateTrainPet();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        this.UpdateScrollPanel();
        break;
      default:
        if (networkNews != NetworkNews.Refresh_BuildBase)
        {
          if (networkNews != NetworkNews.Refresh_AttribEffectVal)
          {
            if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
              break;
            this.RefreshFontTexture();
            break;
          }
          this.UpdateAdditionExp();
          break;
        }
        this.m_BuildingWindow.MyUpdate(meg[1]);
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (bOK && arg2 == (int) byte.MaxValue)
    {
      GUIManager.Instance.BuildingData.ManorGuild((ushort) arg1);
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
    }
    else if (arg1 < 2)
    {
      if (!bOK)
        return;
      this.DialogOnOK((UIPetTrainingCenter.EDialogState) arg1, (byte) arg2);
    }
    else
    {
      int index = arg1 - 2;
      byte dataIdx = (byte) arg2;
      if (index < 0 || index >= this.m_ScrollObjects.Length)
        return;
      this.m_ScrollObjects[index].OnTrain(dataIdx);
    }
  }

  public override bool OnBackButtonClick() => false;

  private void Update()
  {
    for (int index = 0; index < this.m_ScrollObjects.Length; ++index)
      this.m_ScrollObjects[index].Run();
    UIPetTrainingCenter.SSrollPanelItem.StaticRun();
  }

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
      this.SetType(UIPetTrainingCenter.EUIPage.eFirst);
    else
      this.SetType(UIPetTrainingCenter.EUIPage.eSecond);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelObjectIdx >= 6)
      return;
    if (!this.m_ScrollObjects[panelObjectIdx].HasInstance)
      this.InitScrollItem(item, dataIdx, panelObjectIdx);
    this.UpdateScrollItem(dataIdx, panelObjectIdx);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnTimer(UITimeBar sender)
  {
  }

  public void OnNotify(UITimeBar sender)
  {
  }

  public void Onfunc(UITimeBar sender)
  {
  }

  public void OnCancel(UITimeBar sender)
  {
    if (!((Object) sender != (Object) null) || !((Object) sender.m_CancelBtn != (Object) null))
      return;
    this.ShowDialog(UIPetTrainingCenter.EDialogState.CancelTrain, (int) (byte) sender.m_CancelBtn.m_BtnID3);
  }

  public void OnButtonClick(UIButton sender)
  {
    byte btnId2 = (byte) sender.m_BtnID2;
    int btnId3 = sender.m_BtnID3;
    switch (sender.m_BtnID1)
    {
      case 0:
        this.ShowDialog(UIPetTrainingCenter.EDialogState.CancelTrain, btnId3);
        break;
      case 1:
        if (PetManager.Instance.PetDataCount == (ushort) 0)
        {
          StringTable mStringTable = DataManager.Instance.mStringTable;
          GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(17138U), mStringTable.GetStringByID(17139U), mStringTable.GetStringByID(3968U), (GUIWindow) this, 22, (int) byte.MaxValue, true, BackExit: true);
          break;
        }
        if (btnId3 < 0 || btnId3 >= this.m_ScrollObjects.Length)
          break;
        ushort petId = this.PetMgr.m_PetTrainingClinetSave[(int) btnId2].m_PetTrainingSet.m_PetId;
        bool flag = false;
        for (int index1 = 0; index1 < this.PetMgr.m_PetTrainingData.Length; ++index1)
        {
          if (index1 != (int) btnId2 && (this.PetMgr.m_PetTrainingData[index1].m_State == PetManager.EPetTrainDataState.Training || this.PetMgr.m_PetTrainingData[index1].m_State == PetManager.EPetTrainDataState.CanReceive))
          {
            if ((int) this.PetMgr.m_PetTrainingData[index1].m_PetTrainingSet.m_PetId == (int) petId)
            {
              flag = true;
              break;
            }
            for (int index2 = 0; index2 < this.PetMgr.m_PetTrainingClinetSave[(int) btnId2].m_PetTrainingSet.m_CoachHeroId.Count; ++index2)
            {
              ushort num = this.PetMgr.m_PetTrainingClinetSave[(int) btnId2].m_PetTrainingSet.m_CoachHeroId[index2];
              if (this.PetMgr.m_PetTrainingData[index1].m_PetTrainingSet.m_CoachHeroId.Contains(num))
              {
                flag = true;
                break;
              }
            }
          }
        }
        if (flag)
        {
          GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(17115U), DataManager.Instance.mStringTable.GetStringByID(17116U), win: (GUIWindow) this, arg1: btnId3 + 2, arg2: (int) btnId2);
          break;
        }
        this.m_ScrollObjects[btnId3].OnTrain(btnId2);
        break;
      case 2:
        if ((int) btnId2 >= this.PetMgr.m_PetTrainingData.Length)
          break;
        uint totalExp = this.PetMgr.m_PetTrainingData[(int) btnId2].m_TotalExp;
        PetData petData = this.PetMgr.FindPetData(this.PetMgr.m_PetTrainingData[(int) btnId2].m_PetTrainingSet.m_PetId);
        byte maxLevel = petData.GetMaxLevel();
        if (petData == null)
          break;
        uint num1 = 0;
        if (petData.Level < (byte) 60)
        {
          for (byte level = petData.Level; level < (byte) 60 && (int) level <= (int) maxLevel; ++level)
          {
            uint needExp = this.PetMgr.GetNeedExp(level, petData.Rare);
            uint exp = (int) petData.Level != (int) level ? 0U : petData.Exp;
            num1 += needExp - exp;
          }
        }
        if (petData.Level < (byte) 60 && totalExp >= num1)
        {
          this.ShowDialog(UIPetTrainingCenter.EDialogState.OverExp, btnId3);
          break;
        }
        if (btnId3 < 0 || btnId3 >= this.m_ScrollObjects.Length)
          break;
        this.m_ScrollObjects[btnId3].OnReceive();
        break;
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    int btnId2 = sender.m_BtnID2;
    PetData petData = this.PetMgr.FindPetData((ushort) btnId2);
    if (btnId2 <= 0 || petData == null)
      return;
    this.PetMgr.OpenPetUI(0, btnId2);
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    ushort Parm1 = 17083;
    if (sender.Parm1 == (ushort) 4)
      Parm1 = (ushort) 17083;
    else if (sender.Parm1 == (ushort) 5)
      Parm1 = (ushort) 17084;
    else if (sender.Parm1 == (ushort) 6)
      Parm1 = (ushort) 17085;
    else if (sender.Parm1 == (ushort) 7)
      Parm1 = (ushort) 17095;
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 277f, 20, (int) Parm1, 0, Vector2.zero);
    AudioManager.Instance.PlayUISFX();
  }

  public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide();

  private void Init()
  {
    this.m_ScrollPanel = this.transform.GetChild(0).GetComponent<ScrollPanel>();
    this.m_BgPenel = this.transform.GetChild(2);
    this.m_TrainCountText[0] = this.m_BgPenel.GetChild(3).GetComponent<UIText>();
    this.m_TrainCountText[1] = this.m_BgPenel.GetChild(4).GetComponent<UIText>();
    this.m_TrainCountText[0].font = GUIManager.Instance.GetTTFFont();
    this.m_TrainCountText[1].font = GUIManager.Instance.GetTTFFont();
    this.m_TrainCountText[0].text = DataManager.Instance.mStringTable.GetStringByID(17081U);
    this.m_AdditionExpText[0] = this.m_BgPenel.GetChild(5).GetComponent<UIText>();
    this.m_AdditionExpText[1] = this.m_BgPenel.GetChild(6).GetComponent<UIText>();
    this.m_AdditionExpText[0].font = GUIManager.Instance.GetTTFFont();
    this.m_AdditionExpText[1].font = GUIManager.Instance.GetTTFFont();
    this.m_AdditionExpText[0].text = DataManager.Instance.mStringTable.GetStringByID(17082U);
    this.InitScorllPanel();
    this.UpdateAdditionExp();
    this.UpdateTrainPet();
    this.m_BuildingWindow = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.m_BuildingWindow.m_Handler = (IBuildingWindowType) this;
    this.m_BuildingWindow.InitBuildingWindow((byte) 23, this.m_ManorID, (byte) 2, (byte) 1);
    this.m_BuildingWindow.baseTransform.SetAsFirstSibling();
  }

  private void InitScorllPanel()
  {
    if (this.bInitScroll)
      return;
    PetManager.Instance.GetTrainBuildNum();
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.PetMgr.m_PetTrainingData.Length; ++index)
    {
      if (this.PetMgr.m_PetTrainingData[index].m_State != PetManager.EPetTrainDataState.Closed)
        _DataHeight.Add(89f);
    }
    if ((Object) this.m_ScrollPanel != (Object) null)
      this.m_ScrollPanel.IntiScrollPanel(403f, 0.0f, 0.0f, _DataHeight, 6, (IUpDateScrollPanel) this);
    UIButtonHint.scrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
    this.m_ScrollPanel.GoTo(this.PetMgr.m_TrainListIndex, this.PetMgr.m_TrainListY);
    this.bInitScroll = true;
  }

  public void UpdateAdditionExp()
  {
    if (this.m_AdditionExpText == null || !((Object) this.m_AdditionExpText[1] != (Object) null))
      return;
    float f = (float) DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETTRAININGEXP_EXP_PERCENT) / 100f;
    this.m_CStr[0].ClearString();
    this.m_CStr[0].FloatToFormat(f, 2, false);
    if (GUIManager.Instance.IsArabic)
      this.m_CStr[0].AppendFormat("%{0}");
    else
      this.m_CStr[0].AppendFormat("{0}%");
    this.m_AdditionExpText[1].text = this.m_CStr[0].ToString();
    this.m_AdditionExpText[1].SetAllDirty();
    this.m_AdditionExpText[1].cachedTextGenerator.Invalidate();
  }

  public void UpdateTrainPet()
  {
    if (this.m_TrainCountText == null || !((Object) this.m_TrainCountText[1] != (Object) null))
      return;
    byte x1 = 0;
    byte x2 = 0;
    for (int index = 0; index < this.PetMgr.m_PetTrainingData.Length; ++index)
    {
      if (this.PetMgr.m_PetTrainingData[index].m_State == PetManager.EPetTrainDataState.Training)
        ++x1;
      if (this.PetMgr.m_PetTrainingData[index].m_State != PetManager.EPetTrainDataState.Closed && this.PetMgr.m_PetTrainingData[index].m_State != PetManager.EPetTrainDataState.NextOpen)
        ++x2;
    }
    this.m_CStr[1].ClearString();
    this.m_CStr[1].IntToFormat((long) x1);
    this.m_CStr[1].IntToFormat((long) x2);
    if (GUIManager.Instance.IsArabic)
      this.m_CStr[1].AppendFormat("{1} / {0}");
    else
      this.m_CStr[1].AppendFormat("{0} / {1}");
    this.m_TrainCountText[1].text = this.m_CStr[1].ToString();
    this.m_TrainCountText[1].SetAllDirty();
    this.m_TrainCountText[1].cachedTextGenerator.Invalidate();
  }

  private void UpdateScrollPanel(int animIdx = -1)
  {
    if (!this.bInitScroll)
      return;
    PetManager.Instance.GetTrainBuildNum();
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.PetMgr.m_PetTrainingData.Length; ++index)
    {
      if (this.PetMgr.m_PetTrainingData[index].m_State != PetManager.EPetTrainDataState.Closed)
        _DataHeight.Add(89f);
    }
    if (!((Object) this.m_ScrollPanel != (Object) null))
      return;
    this.m_ScrollPanel.AddNewDataHeight(_DataHeight, false);
  }

  private void InitScrollItem(GameObject item, int dataIdx, int panelObjectIdx)
  {
    if (panelObjectIdx >= this.m_ScrollObjects.Length)
      return;
    UIText[] valueText = new UIText[3];
    Image[] imageBg = new Image[3];
    Transform[] itemTf = new Transform[2]
    {
      item.transform.GetChild(0),
      item.transform.GetChild(1)
    };
    imageBg[0] = itemTf[0].GetChild(0).GetChild(0).GetComponent<Image>();
    imageBg[1] = itemTf[0].GetChild(0).GetChild(1).GetComponent<Image>();
    imageBg[2] = itemTf[0].GetChild(0).GetChild(2).GetComponent<Image>();
    if (GUIManager.Instance.IsArabic)
      imageBg[2].sprite = this.m_Sp.GetSprite(3);
    UIHIBtn component1 = itemTf[0].GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
    component1.m_Handler = (IUIHIBtnClickHandler) this;
    component1.m_BtnID1 = 3;
    itemTf[0].GetChild(1).gameObject.AddComponent<EventPatchery>().SetEvnetObj(this.m_ScrollPanel.GetComponent<CScrollRect>());
    Image component2 = itemTf[0].GetChild(1).GetChild(2).GetComponent<Image>();
    UIText component3 = itemTf[0].GetChild(1).GetChild(3).GetComponent<UIText>();
    component3.font = GUIManager.Instance.GetTTFFont();
    GUIManager.Instance.InitianHeroItemImg(((Component) component1).transform, eHeroOrItem.Pet, (ushort) 1, (byte) 1, (byte) 0, 1);
    Transform component4 = itemTf[0].GetChild(1).GetChild(1).GetComponent<Transform>();
    Image component5 = itemTf[0].GetChild(1).GetChild(1).GetChild(0).GetComponent<Image>();
    UIText component6 = itemTf[0].GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
    component6.font = GUIManager.Instance.GetTTFFont();
    Image component7 = itemTf[0].GetChild(1).GetChild(4).GetComponent<Image>();
    itemTf[0].GetChild(2).gameObject.AddComponent<ArabicItemTextureRot>();
    UIButtonHint uiButtonHint1 = itemTf[0].GetChild(2).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    uiButtonHint1.Parm1 = (ushort) 4;
    valueText[0] = itemTf[0].GetChild(2).GetChild(0).GetComponent<UIText>();
    valueText[0].font = GUIManager.Instance.GetTTFFont();
    Image component8 = itemTf[0].GetChild(3).GetComponent<Image>();
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
      component8.sprite = this.m_Sp.GetSprite(2);
    UIButtonHint uiButtonHint2 = itemTf[0].GetChild(3).gameObject.AddComponent<UIButtonHint>();
    itemTf[0].GetChild(3).gameObject.AddComponent<ArabicItemTextureRot>();
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint2.m_Handler = (MonoBehaviour) this;
    uiButtonHint2.Parm1 = (ushort) 5;
    valueText[1] = itemTf[0].GetChild(3).GetChild(0).GetComponent<UIText>();
    valueText[1].font = GUIManager.Instance.GetTTFFont();
    UIButtonHint uiButtonHint3 = itemTf[0].GetChild(4).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint3.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint3.m_Handler = (MonoBehaviour) this;
    uiButtonHint3.Parm1 = (ushort) 6;
    valueText[2] = itemTf[0].GetChild(4).GetChild(0).GetComponent<UIText>();
    valueText[2].font = GUIManager.Instance.GetTTFFont();
    UITimeBar component9 = itemTf[0].GetChild(5).GetComponent<UITimeBar>();
    UIButton component10 = itemTf[0].GetChild(6).GetComponent<UIButton>();
    component10.m_Handler = (IUIButtonClickHandler) this;
    component10.m_BtnID1 = 1;
    UIText component11 = itemTf[0].GetChild(6).GetChild(0).GetComponent<UIText>();
    component11.font = GUIManager.Instance.GetTTFFont();
    component11.text = DataManager.Instance.mStringTable.GetStringByID(17087U);
    UIButton component12 = itemTf[0].GetChild(7).GetComponent<UIButton>();
    component12.m_Handler = (IUIButtonClickHandler) this;
    component12.m_BtnID1 = 2;
    UIText component13 = itemTf[0].GetChild(7).GetChild(1).GetComponent<UIText>();
    component13.font = GUIManager.Instance.GetTTFFont();
    component13.text = DataManager.Instance.mStringTable.GetStringByID(17093U);
    Image component14 = itemTf[0].GetChild(7).GetChild(0).GetComponent<Image>();
    Transform child1 = itemTf[0].GetChild(8);
    Image component15 = child1.GetChild(0).GetComponent<Image>();
    UIButtonHint uiButtonHint4 = ((Component) component15).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint4.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint4.m_Handler = (MonoBehaviour) this;
    uiButtonHint4.Parm1 = (ushort) 7;
    Transform child2 = child1.GetChild(1);
    UIText component16 = child2.GetChild(2).GetComponent<UIText>();
    component16.font = GUIManager.Instance.GetTTFFont();
    Image component17 = child2.GetChild(0).GetComponent<Image>();
    Image component18 = child1.GetChild(2).GetComponent<Image>();
    UIText component19 = child1.GetChild(3).GetComponent<UIText>();
    component19.font = GUIManager.Instance.GetTTFFont();
    itemTf[1].GetChild(0).GetComponent<Image>();
    Image component20 = itemTf[1].GetChild(0).GetComponent<Image>();
    UIText component21 = itemTf[1].GetChild(1).GetComponent<UIText>();
    component21.font = GUIManager.Instance.GetTTFFont();
    component21.text = DataManager.Instance.mStringTable.GetStringByID(17086U);
    this.SetCenterText(component20, component21, 829f);
    this.m_ScrollObjects[panelObjectIdx].Init(itemTf, component21, imageBg, component1, component5, component4, component6, component7, valueText, component9, dataIdx, component10, component12, component14, component2, component3, child1, child2, component16, component19, component18, component17, component15);
  }

  private void UpdateScrollItem(int dataIdx, int panelObjectIdx)
  {
    if (panelObjectIdx >= this.m_ScrollObjects.Length)
      return;
    ushort petId = this.PetMgr.m_PetTrainingData[dataIdx].m_PetTrainingSet.m_PetId;
    PetData petData1 = this.PetMgr.FindPetData(petId);
    PetManager.EPetTrainDataState state1 = this.PetMgr.m_PetTrainingData[dataIdx].m_State;
    PetManager.EPetTrainDataState state2 = this.PetMgr.m_PetTrainingClinetSave[dataIdx].m_State;
    this.m_ScrollObjects[panelObjectIdx].StopAnim();
    switch (state1)
    {
      case PetManager.EPetTrainDataState.Training:
      case PetManager.EPetTrainDataState.CanReceive:
        if (petData1 != null && petId != (ushort) 0)
        {
          this.PetMgr.PetExpTable.GetRecordByKey((ushort) petData1.Level);
          PetTbl recordByKey = this.PetMgr.PetTable.GetRecordByKey(petData1.ID);
          uint needExp = this.PetMgr.GetNeedExp(petData1.Level, recordByKey.Rare);
          this.m_ScrollObjects[panelObjectIdx].SetPetHibtn(petId, petData1.Enhance, petData1.Rare, petData1.Level);
          this.m_ScrollObjects[panelObjectIdx].ShowAnim = this.PetMgr.m_LevelUpStae == 1 && this.PetMgr.m_LevelUpIdx == dataIdx;
          this.m_ScrollObjects[panelObjectIdx].ShowSkillAnim = this.PetMgr.m_LevelUpStae == 2 && this.PetMgr.m_LevelUpIdx == dataIdx;
          this.m_ScrollObjects[panelObjectIdx].SetAnimLvExp(petData1.Level, petData1.Exp, needExp);
          byte skillIdx = (byte) Mathf.Clamp(this.PetMgr.m_LevelUpSkillIdx, 0, 3);
          uint petSkillMaxExp = PetManager.Instance.GetPetSkillMaxExp(petData1.ID, skillIdx);
          this.m_ScrollObjects[panelObjectIdx].SetSkillAnimLvExp(this.PetMgr.m_LevelUpLV, this.PetMgr.m_LevelOldExp, this.PetMgr.m_LevelNowExp, petSkillMaxExp, this.PetMgr.m_LevelSkillID);
          this.m_ScrollObjects[panelObjectIdx].SetHeroNum((int) this.PetMgr.m_PetTrainingData[dataIdx].CoachHeroCount);
          if (this.PetMgr.m_PetTrainingClinetSave[dataIdx].m_CancelExp > 0U)
            this.m_ScrollObjects[panelObjectIdx].SetPetExp(this.PetMgr.m_PetTrainingClinetSave[dataIdx].m_CancelExp);
          else
            this.m_ScrollObjects[panelObjectIdx].SetPetExp(this.PetMgr.m_PetTrainingData[dataIdx].m_TotalExp);
          this.m_ScrollObjects[panelObjectIdx].SetPetTime(this.PetMgr.m_PetTrainingData[dataIdx].m_EventTime.RequireTime);
          this.m_ScrollObjects[panelObjectIdx].SetTimer(this.PetMgr.m_PetTrainingData[dataIdx].m_EventTime.BeginTime, (long) this.PetMgr.m_PetTrainingData[dataIdx].m_EventTime.RequireTime, PetManager.Instance.GetPetNameByID(petId), (IUTimeBarOnTimer) this);
          this.m_ScrollObjects[panelObjectIdx].SetState(state1);
          break;
        }
        this.m_ScrollObjects[panelObjectIdx].SetEmpty((IUTimeBarOnTimer) this);
        this.m_ScrollObjects[panelObjectIdx].SetState(PetManager.EPetTrainDataState.Empty);
        break;
      case PetManager.EPetTrainDataState.Received:
        petId = this.PetMgr.m_PetTrainingClinetSave[dataIdx].m_PetTrainingSet.m_PetId;
        PetData petData2 = this.PetMgr.FindPetData(petId);
        if (petId != (ushort) 0 && petData2 != null)
        {
          this.PetMgr.PetExpTable.GetRecordByKey((ushort) petData2.Level);
          PetTbl recordByKey = this.PetMgr.PetTable.GetRecordByKey(petData2.ID);
          uint needExp = this.PetMgr.GetNeedExp(petData2.Level, recordByKey.Rare);
          this.m_ScrollObjects[panelObjectIdx].SetPetHibtn(petId, petData2.Enhance, petData2.Rare, petData2.Level);
          this.m_ScrollObjects[panelObjectIdx].ShowAnim = this.PetMgr.m_LevelUpStae == 1 && this.PetMgr.m_LevelUpIdx == dataIdx;
          this.m_ScrollObjects[panelObjectIdx].ShowSkillAnim = this.PetMgr.m_LevelUpStae == 2 && this.PetMgr.m_LevelUpIdx == dataIdx;
          this.m_ScrollObjects[panelObjectIdx].SetAnimLvExp(petData2.Level, petData2.Exp, needExp);
          byte skillIdx = (byte) Mathf.Clamp(this.PetMgr.m_LevelUpSkillIdx, 0, 3);
          uint petSkillMaxExp = PetManager.Instance.GetPetSkillMaxExp(petData2.ID, skillIdx);
          if (petData2.ID == (ushort) 51)
            Debug.Log((object) string.Empty);
          this.m_ScrollObjects[panelObjectIdx].SetSkillAnimLvExp(this.PetMgr.m_LevelUpLV, this.PetMgr.m_LevelOldExp, this.PetMgr.m_LevelNowExp, petSkillMaxExp, this.PetMgr.m_LevelSkillID);
          this.m_ScrollObjects[panelObjectIdx].SetHeroNum((int) this.PetMgr.m_PetTrainingClinetSave[dataIdx].CoachHeroCount);
          this.m_ScrollObjects[panelObjectIdx].SetPetExp(this.PetMgr.m_PetTrainingClinetSave[dataIdx].m_TotalExp);
          this.m_ScrollObjects[panelObjectIdx].SetPetTime(this.PetMgr.m_PetTrainingClinetSave[dataIdx].m_EventTime.RequireTime);
          this.m_ScrollObjects[panelObjectIdx].SetState(PetManager.EPetTrainDataState.Received);
          break;
        }
        this.m_ScrollObjects[panelObjectIdx].SetEmpty((IUTimeBarOnTimer) this);
        this.m_ScrollObjects[panelObjectIdx].SetState(PetManager.EPetTrainDataState.Empty);
        break;
      case PetManager.EPetTrainDataState.NextOpen:
        if (state1 == PetManager.EPetTrainDataState.Empty)
        {
          this.m_ScrollObjects[panelObjectIdx].SetEmpty((IUTimeBarOnTimer) this);
          this.m_ScrollObjects[panelObjectIdx].SetState(state1);
          break;
        }
        this.m_ScrollObjects[panelObjectIdx].SetState(state1);
        break;
      default:
        if (state2 != PetManager.EPetTrainDataState.Received)
          goto case PetManager.EPetTrainDataState.NextOpen;
        else
          goto case PetManager.EPetTrainDataState.Received;
    }
    this.m_ScrollObjects[panelObjectIdx].SetCancelBtnID(dataIdx, panelObjectIdx);
    this.m_ScrollObjects[panelObjectIdx].SetTrainBtnID(dataIdx, panelObjectIdx);
    this.m_ScrollObjects[panelObjectIdx].SetReceiveBtnID(dataIdx, panelObjectIdx);
    this.m_ScrollObjects[panelObjectIdx].SetPetBtnID((int) petId);
  }

  private void SetType(UIPetTrainingCenter.EUIPage page)
  {
    this.m_UIType = page;
    if (this.m_UIType == UIPetTrainingCenter.EUIPage.eFirst)
    {
      if ((bool) (Object) this.m_ScrollPanel)
        this.m_ScrollPanel.gameObject.SetActive(true);
      if (!(bool) (Object) this.m_BgPenel)
        return;
      this.m_BgPenel.gameObject.SetActive(true);
    }
    else
    {
      if ((bool) (Object) this.m_ScrollPanel)
        this.m_ScrollPanel.gameObject.SetActive(false);
      if (!(bool) (Object) this.m_BgPenel)
        return;
      this.m_BgPenel.gameObject.SetActive(false);
    }
  }

  private void ShowDialog(UIPetTrainingCenter.EDialogState state, int panelObjectIdx)
  {
    switch (state)
    {
      case UIPetTrainingCenter.EDialogState.CancelTrain:
        GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(17091U), DataManager.Instance.mStringTable.GetStringByID(17092U), (int) state, panelObjectIdx);
        break;
      case UIPetTrainingCenter.EDialogState.OverExp:
        GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(685U), DataManager.Instance.mStringTable.GetStringByID(17141U), (int) state, panelObjectIdx, DataManager.Instance.mStringTable.GetStringByID(1520U), DataManager.Instance.mStringTable.GetStringByID(4U));
        break;
    }
  }

  private void DialogOnOK(UIPetTrainingCenter.EDialogState state, byte panelObjectIdx)
  {
    switch (state)
    {
      case UIPetTrainingCenter.EDialogState.CancelTrain:
        if (panelObjectIdx < (byte) 0 || (int) panelObjectIdx >= this.m_ScrollObjects.Length)
          break;
        this.m_ScrollObjects[(int) panelObjectIdx].OnCancel();
        break;
      case UIPetTrainingCenter.EDialogState.OverExp:
        if (panelObjectIdx < (byte) 0 || (int) panelObjectIdx >= this.m_ScrollObjects.Length)
          break;
        this.m_ScrollObjects[(int) panelObjectIdx].OnReceive();
        break;
    }
  }

  public static void GetTimeInfoString(CString CStr, uint sec, bool needPlus = false)
  {
    uint num1 = sec;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    if (needPlus)
      CStr.Append("+");
    if (num1 > 86400U)
    {
      CStr.IntToFormat((long) (int) (num1 / 86400U));
      CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17131U));
      uint num2 = num1 % 86400U;
      if (num2 >= 3600U)
      {
        CStr.Append(" ");
        CStr.IntToFormat((long) (int) (num2 / 3600U));
        CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17132U));
        num2 %= 3600U;
      }
      if (num2 < 60U)
        return;
      CStr.Append(" ");
      CStr.IntToFormat((long) (int) (num2 / 60U));
      CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17133U));
    }
    else
    {
      if (num1 >= 3600U)
      {
        CStr.IntToFormat((long) (int) (num1 / 3600U));
        CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17132U));
        num1 %= 3600U;
      }
      if (num1 < 60U)
        return;
      CStr.IntToFormat((long) (int) (num1 / 60U));
      CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17133U));
    }
  }

  private void SetCenterText(Image image, UIText text, float width)
  {
    float num1 = 10f;
    float num2 = Mathf.Clamp(text.preferredWidth, 0.0f, 500f);
    float x = (float) (((double) width - ((double) ((Graphic) image).rectTransform.sizeDelta.x + (double) num2 + (double) num1)) / 2.0);
    ((Graphic) image).rectTransform.anchoredPosition = new Vector2(x, ((Graphic) image).rectTransform.anchoredPosition.y);
    ((Graphic) text).rectTransform.anchoredPosition = new Vector2(((Graphic) image).rectTransform.anchoredPosition.x + ((Graphic) image).rectTransform.sizeDelta.x + num1, ((Graphic) text).rectTransform.anchoredPosition.y);
  }

  private void SpawnString()
  {
    if (this.m_CStr == null)
      this.m_CStr = new CString[2];
    for (int index = 0; index < this.m_CStr.Length; ++index)
      this.m_CStr[index] = StringManager.Instance.SpawnString();
  }

  private void DeSpawnString()
  {
    for (int index = 0; index < this.m_CStr.Length; ++index)
    {
      StringManager.Instance.DeSpawnString(this.m_CStr[index]);
      this.m_CStr[index] = (CString) null;
    }
  }

  private void RefreshFontTexture()
  {
    for (int index = 0; index < this.m_ScrollObjects.Length; ++index)
    {
      if (this.m_ScrollObjects[index].m_Timer != null)
        this.m_ScrollObjects[index].m_Timer.RefreshFontTexture();
    }
    if ((Object) this.m_BuildingWindow != (Object) null)
      this.m_BuildingWindow.Refresh_FontTexture();
    if (this.m_TrainCountText != null)
    {
      for (int index = 0; index < this.m_TrainCountText.Length; ++index)
      {
        if ((Object) this.m_TrainCountText[index] != (Object) null && ((Behaviour) this.m_TrainCountText[index]).enabled)
        {
          ((Behaviour) this.m_TrainCountText[index]).enabled = false;
          ((Behaviour) this.m_TrainCountText[index]).enabled = true;
        }
      }
    }
    if (this.m_AdditionExpText == null)
      return;
    for (int index = 0; index < this.m_AdditionExpText.Length; ++index)
    {
      if ((Object) this.m_AdditionExpText[index] != (Object) null && ((Behaviour) this.m_AdditionExpText[index]).enabled)
      {
        ((Behaviour) this.m_AdditionExpText[index]).enabled = false;
        ((Behaviour) this.m_AdditionExpText[index]).enabled = true;
      }
    }
  }

  private enum EUIPetTrainingCenter
  {
    ScrollPanel,
    Item,
    BgPanel,
  }

  private enum ECStrID
  {
    UpdateAdditionExp,
    UpdateTrainPetCount,
    Max,
  }

  private enum EBtnID
  {
    Cancel,
    Train,
    Receive,
    PetIcon,
    HeroCountHint,
    ExpHint,
    TimeHint,
    SkillIconHint,
  }

  private enum EUIPage
  {
    eFirst,
    eSecond,
  }

  private enum EDialogState
  {
    CancelTrain,
    OverExp,
    Max,
  }

  private struct SSrollPanelItem
  {
    private Transform[] m_ItemTrams;
    private UIText m_Item2Text;
    private Transform m_ExpTf;
    private Image[] m_ImageBg;
    private UIHIBtn m_PetHiBtn;
    private Image m_SliderImg;
    private UIText m_LvText;
    private UIText m_ExpText;
    private Image m_LockIcon;
    private UIText[] m_ValueText;
    private Image m_ReceiveEffectImg;
    public Transform m_SkillTf;
    public Transform m_SkillExpTf;
    private UIText m_SkillLvText;
    private UIText m_SkillExpText;
    private Image m_SkillSliderImg;
    private Image m_SkillExpImg;
    private Image m_SkillIcon;
    private UISpritesArray m_Sp;
    private Color m_ReceiveColor;
    private byte m_Lv;
    private float[] m_ExpWidth;
    private float[] m_ExpDeltaWidth;
    public uint m_Exp;
    private bool bSkill;
    public PetTrainingTimer m_Timer;
    public LvUpAnimation m_Animation;
    public LvUpAnimation m_AnimationSkill;
    private CString[] m_CStr;
    private ushort m_PetID;
    private static float m_StsticDeltaTime;
    private float[] m_DeltaTime;
    private bool[] m_AddTime;
    private bool bShowAnim;
    private bool bShowSkillAnim;
    private bool bHasInstance;
    private byte m_SkillIdx;

    public SSrollPanelItem(UISpritesArray sp)
    {
      this.m_Sp = sp;
      this.m_SkillTf = (Transform) null;
      this.m_SkillExpTf = (Transform) null;
      this.m_SkillTf = (Transform) null;
      this.m_SkillExpTf = (Transform) null;
      this.m_SkillLvText = (UIText) null;
      this.m_SkillExpImg = (Image) null;
      this.m_SkillExpText = (UIText) null;
      this.m_SkillSliderImg = (Image) null;
      this.m_SkillIcon = (Image) null;
      this.m_ItemTrams = (Transform[]) null;
      this.m_Item2Text = (UIText) null;
      this.m_ImageBg = (Image[]) null;
      this.m_PetHiBtn = (UIHIBtn) null;
      this.m_SliderImg = (Image) null;
      this.m_LockIcon = (Image) null;
      this.m_ExpTf = (Transform) null;
      this.m_LvText = (UIText) null;
      this.m_ValueText = new UIText[3];
      this.m_ExpText = (UIText) null;
      this.m_ReceiveEffectImg = (Image) null;
      this.m_Timer = new PetTrainingTimer();
      this.m_Animation = new LvUpAnimation();
      this.m_AnimationSkill = new LvUpAnimation();
      this.m_CStr = (CString[]) null;
      this.bHasInstance = false;
      this.m_ReceiveColor = Color.white;
      this.m_Lv = (byte) 0;
      this.m_ExpDeltaWidth = new float[2];
      this.m_ExpDeltaWidth[0] = 0.0f;
      this.m_ExpDeltaWidth[1] = 0.0f;
      this.m_ExpWidth = new float[2];
      this.m_ExpWidth[0] = 0.0f;
      this.m_ExpWidth[1] = 1f;
      this.m_Exp = 0U;
      this.bSkill = false;
      this.m_PetID = (ushort) 0;
      UIPetTrainingCenter.SSrollPanelItem.m_StsticDeltaTime = 0.0f;
      this.m_DeltaTime = new float[4];
      this.m_DeltaTime[0] = 0.0f;
      this.m_DeltaTime[1] = 0.0f;
      this.m_DeltaTime[2] = 0.0f;
      this.m_DeltaTime[3] = 0.0f;
      this.m_AddTime = new bool[4];
      this.m_AddTime[0] = false;
      this.m_AddTime[1] = false;
      this.m_AddTime[2] = false;
      this.m_AddTime[3] = false;
      this.bShowAnim = false;
      this.bShowSkillAnim = false;
      this.m_SkillIdx = (byte) 0;
    }

    public bool ShowAnim
    {
      get => this.bShowAnim;
      set => this.bShowAnim = value;
    }

    public bool ShowSkillAnim
    {
      get => this.bShowSkillAnim;
      set => this.bShowSkillAnim = value;
    }

    public byte SkillIdx
    {
      get => this.m_SkillIdx;
      set => this.m_SkillIdx = value;
    }

    public bool HasInstance => this.bHasInstance;

    public void SetItemTransform(Transform[] item) => this.m_ItemTrams = item;

    public void Init(
      Transform[] itemTf,
      UIText item2Text,
      Image[] imageBg,
      UIHIBtn hiBtn,
      Image sliderImg,
      Transform expTf,
      UIText lvText,
      Image lockIcon,
      UIText[] valueText,
      UITimeBar timer,
      int timerID,
      UIButton traningBtn,
      UIButton receive,
      Image receiveEffectImg,
      Image expImg,
      UIText expText,
      Transform skillTf,
      Transform skillExpTf,
      UIText skillLvText,
      UIText skillExpText,
      Image skillExpImg,
      Image skillSliderImg,
      Image skillIcon)
    {
      this.m_ItemTrams = itemTf;
      this.m_Item2Text = item2Text;
      this.m_ReceiveEffectImg = receiveEffectImg;
      this.m_ReceiveColor = ((Graphic) this.m_ReceiveEffectImg).color;
      this.m_ImageBg = imageBg;
      this.m_PetHiBtn = hiBtn;
      this.m_SliderImg = sliderImg;
      this.m_LockIcon = lockIcon;
      this.m_ExpTf = expTf;
      this.m_LvText = lvText;
      this.m_ExpText = expText;
      this.m_ValueText = valueText;
      this.m_SkillTf = skillTf;
      this.m_SkillExpTf = skillExpTf;
      this.m_SkillLvText = skillLvText;
      this.m_SkillExpText = skillExpText;
      this.m_SkillExpImg = skillExpImg;
      this.m_SkillSliderImg = skillSliderImg;
      this.m_SkillIcon = skillIcon;
      this.m_Timer.Init(timer, traningBtn, receive, timerID);
      this.m_Animation.Init(expImg, this.m_ExpText);
      this.m_AnimationSkill.Init(skillExpImg, skillExpText, skillIcon);
      this.SpawnString();
      this.bHasInstance = true;
    }

    public static void StaticRun()
    {
      UIPetTrainingCenter.SSrollPanelItem.m_StsticDeltaTime += Time.deltaTime;
      if ((double) UIPetTrainingCenter.SSrollPanelItem.m_StsticDeltaTime < 2.0)
        return;
      UIPetTrainingCenter.SSrollPanelItem.m_StsticDeltaTime = 0.0f;
    }

    public void Run()
    {
      if (this.bHasInstance && this.m_Animation != null && this.m_AnimationSkill != null && this.m_Animation != null)
      {
        this.m_Animation.Run();
        this.m_AnimationSkill.Run();
      }
      if ((Object) this.m_ReceiveEffectImg != (Object) null && ((Component) this.m_ReceiveEffectImg).gameObject.activeInHierarchy)
      {
        float num = Mathf.Lerp(0.0f, 2f, UIPetTrainingCenter.SSrollPanelItem.m_StsticDeltaTime / 2f);
        this.m_ReceiveColor.a = (double) num <= 1.0 ? num : 2f - num;
        ((Graphic) this.m_ReceiveEffectImg).color = this.m_ReceiveColor;
      }
      if ((double) this.m_ExpDeltaWidth[0] > 0.0 && (double) this.m_ExpDeltaWidth[0] <= 45.0)
      {
        float num1 = (float) (0.5 * ((double) this.m_ExpDeltaWidth[0] / 45.0));
        this.m_DeltaTime[1] += Time.deltaTime;
        float num2 = Mathf.Lerp(0.0f, this.m_ExpDeltaWidth[0], this.m_DeltaTime[1] / num1);
        ((Graphic) this.m_SliderImg).rectTransform.sizeDelta = ((Graphic) this.m_SliderImg).rectTransform.sizeDelta with
        {
          x = this.m_ExpWidth[0] + num2
        };
        if ((double) num2 >= (double) this.m_ExpDeltaWidth[0])
          this.m_ExpDeltaWidth[0] = 0.0f;
      }
      if ((double) this.m_ExpDeltaWidth[1] > 0.0 && (double) this.m_ExpDeltaWidth[1] <= 36.0)
      {
        float num3 = 0.5f;
        this.m_DeltaTime[1] += Time.deltaTime;
        if ((double) this.m_DeltaTime[1] >= (double) num3)
        {
          float num4 = (float) (0.5 * ((double) this.m_ExpDeltaWidth[1] / 36.0));
          float num5 = Mathf.Lerp(0.0f, this.m_ExpDeltaWidth[1], (this.m_DeltaTime[1] - num3) / num4);
          ((Graphic) this.m_SkillSliderImg).rectTransform.sizeDelta = ((Graphic) this.m_SkillSliderImg).rectTransform.sizeDelta with
          {
            x = this.m_ExpWidth[1] + num5
          };
          if ((double) num5 >= (double) this.m_ExpDeltaWidth[1])
            this.m_ExpDeltaWidth[1] = 0.0f;
          Debug.Log((object) ((Graphic) this.m_SkillSliderImg).rectTransform.sizeDelta.x);
        }
      }
      if (this.m_AddTime[2])
      {
        this.m_DeltaTime[2] += Time.deltaTime;
        if ((double) this.m_DeltaTime[2] > 0.0 && (double) this.m_DeltaTime[2] >= 0.5)
        {
          this.m_SkillExpTf.gameObject.SetActive(true);
          this.m_DeltaTime[2] = 0.0f;
          this.m_AddTime[2] = false;
        }
      }
      if (!this.m_AddTime[3])
        return;
      this.m_DeltaTime[3] += Time.deltaTime;
      if ((double) this.m_DeltaTime[3] <= 0.0 || (double) this.m_DeltaTime[3] < 1.5)
        return;
      this.m_SkillExpTf.gameObject.SetActive(false);
      this.m_DeltaTime[3] = 0.0f;
      this.m_AddTime[3] = false;
    }

    public void SetCancelBtnID(int dataIdx, int panelObjectIdx)
    {
      this.m_Timer.SetCancelBtnID(dataIdx, panelObjectIdx);
    }

    public void SetTrainBtnID(int dataIdx, int panelObjectIdx)
    {
      this.m_Timer.SetTrainBtnID(dataIdx, panelObjectIdx);
    }

    public void SetReceiveBtnID(int dataIdx, int panelObjectIdx)
    {
      this.m_Timer.SetReceiveBtnID(dataIdx, panelObjectIdx);
    }

    public void SetPetBtnID(int petID) => this.m_PetHiBtn.m_BtnID2 = petID;

    public void SetPetHibtn(ushort petID, byte Enhance, byte Rare, byte level)
    {
      GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_PetHiBtn).transform, eHeroOrItem.Pet, petID, Enhance, (byte) 0);
      this.m_PetID = petID;
      this.SetSkillIcon(this.m_PetID, (ushort) 0);
    }

    public void SetAnimLvExp(byte lv, uint exp, uint max)
    {
      float num1 = 45f;
      float num2 = 0.0f;
      Vector2 sizeDelta = ((Graphic) this.m_SliderImg).rectTransform.sizeDelta;
      this.m_ExpWidth[0] = sizeDelta.x;
      this.m_Lv = lv;
      if ((Object) this.m_ExpTf != (Object) null)
        this.m_ExpTf.gameObject.SetActive(this.m_Lv != (byte) 0);
      if (max != 0U)
      {
        float num3 = Mathf.Clamp((float) exp / (float) max, 0.0f, 1f);
        num2 = num1 * num3;
      }
      if (this.m_Animation != null)
      {
        this.m_AnimationSkill.End();
        uint exp1 = exp - this.m_Exp;
        if (exp1 > 0U && this.ShowAnim)
        {
          if ((int) this.m_Lv == (int) lv)
            this.m_ExpDeltaWidth[0] = num2 - this.m_ExpWidth[0];
          this.m_Animation.Start(this.m_CStr[5], exp1, (ushort) 0);
          this.m_DeltaTime[1] = 0.0f;
          this.ShowAnim = false;
        }
        else
        {
          sizeDelta.x = num2;
          ((Graphic) this.m_SliderImg).rectTransform.sizeDelta = sizeDelta;
        }
        this.m_Exp = exp;
      }
      ((Component) this.m_LockIcon).gameObject.SetActive(false);
      PetData petData = PetManager.Instance.FindPetData(this.m_PetID);
      if (petData != null)
      {
        byte maxLevel = petData.GetMaxLevel();
        if ((int) petData.Level == (int) maxLevel && exp >= max - 1U)
          ((Component) this.m_LockIcon).gameObject.SetActive(true);
      }
      this.m_CStr[3].ClearString();
      this.m_CStr[3].IntToFormat((long) lv);
      this.m_CStr[3].AppendFormat("{0}");
      this.m_LvText.text = this.m_CStr[3].ToString();
      this.m_LvText.SetAllDirty();
      this.m_LvText.cachedTextGenerator.Invalidate();
      if (lv < (byte) 60)
      {
        this.m_SliderImg.sprite = this.m_Sp.GetSprite(0);
      }
      else
      {
        sizeDelta.x = num1;
        ((Graphic) this.m_SliderImg).rectTransform.sizeDelta = sizeDelta;
        this.m_SliderImg.sprite = this.m_Sp.GetSprite(1);
      }
    }

    public void SetSkillAnimLvExp(byte lv = 1, uint oldexp = 1, uint nowExp = 1, uint max = 1, ushort skillID = 0)
    {
      float num1 = 36f;
      float num2 = 0.0f;
      Vector2 sizeDelta = ((Graphic) this.m_SkillSliderImg).rectTransform.sizeDelta;
      this.m_ExpWidth[1] = num1 * (float) oldexp / (float) max;
      this.m_Lv = lv;
      if ((Object) this.m_ExpTf != (Object) null)
        this.m_ExpTf.gameObject.SetActive(this.m_Lv != (byte) 0);
      if (max != 0U)
      {
        float num3 = Mathf.Clamp((float) nowExp / (float) max, 0.0f, 1f);
        num2 = num1 * num3;
      }
      if (this.m_AnimationSkill != null)
      {
        this.m_AnimationSkill.End();
        uint exp = nowExp - oldexp;
        if (exp > 0U && this.bShowSkillAnim)
        {
          if ((int) this.m_Lv == (int) lv)
            this.m_ExpDeltaWidth[1] = num2 - this.m_ExpWidth[1];
          this.m_AnimationSkill.Start(this.m_CStr[5], exp, skillID);
          this.m_DeltaTime[1] = 0.0f;
          this.m_DeltaTime[2] = 0.0f;
          this.m_DeltaTime[3] = 0.0f;
          this.m_AddTime[2] = true;
          this.m_AddTime[3] = true;
          this.m_SkillExpTf.gameObject.SetActive(false);
          this.bShowSkillAnim = false;
        }
        else
        {
          sizeDelta.x = num2;
          ((Graphic) this.m_SkillSliderImg).rectTransform.sizeDelta = sizeDelta;
          this.m_SkillExpTf.gameObject.SetActive(false);
        }
      }
      this.m_CStr[4].ClearString();
      this.m_CStr[4].IntToFormat((long) lv);
      this.m_CStr[4].AppendFormat("{0}");
      this.m_SkillLvText.text = this.m_CStr[4].ToString();
      this.m_SkillLvText.SetAllDirty();
      this.m_SkillLvText.cachedTextGenerator.Invalidate();
    }

    public void SetHeroNum(int num)
    {
      this.m_CStr[0].ClearString();
      if (num <= 0)
      {
        this.m_CStr[0].Append(DataManager.Instance.mStringTable.GetStringByID(17135U));
      }
      else
      {
        this.m_CStr[0].IntToFormat((long) num);
        this.m_CStr[0].AppendFormat("{0}");
      }
      this.m_ValueText[0].text = this.m_CStr[0].ToString();
      this.m_ValueText[0].SetAllDirty();
      this.m_ValueText[0].cachedTextGenerator.Invalidate();
    }

    public void SetPetExp(uint exp, bool bMaxLv = false)
    {
      this.m_CStr[1].ClearString();
      if (exp <= 0U)
      {
        this.m_CStr[1].Append(DataManager.Instance.mStringTable.GetStringByID(17135U));
      }
      else
      {
        this.m_CStr[1].IntToFormat((long) exp, bNumber: true);
        this.m_CStr[1].AppendFormat("{0}");
      }
      this.m_ValueText[1].text = this.m_CStr[1].ToString();
      this.m_ValueText[1].SetAllDirty();
      this.m_ValueText[1].cachedTextGenerator.Invalidate();
    }

    public void SetSkillIcon(ushort petID, ushort skillID)
    {
      bool flag = PetManager.Instance.IsMaxLevelExp(petID);
      if ((Object) this.m_SkillIcon.sprite == (Object) null)
      {
        this.m_SkillIcon.sprite = PetManager.Instance.LoadPetSkillIcon(skillID);
        ((MaskableGraphic) this.m_SkillIcon).material = GUIManager.Instance.m_ItemIconSpriteAsset.GetMaterial();
        Image component = ((Component) this.m_SkillIcon).transform.GetChild(0).GetComponent<Image>();
        if ((Object) component != (Object) null)
        {
          component.sprite = GUIManager.Instance.LoadFrameSprite("sk");
          ((MaskableGraphic) component).material = GUIManager.Instance.GetFrameMaterial();
        }
      }
      this.m_SkillTf.gameObject.SetActive(flag);
    }

    public void SetPetTime(uint time)
    {
      this.m_CStr[2].ClearString();
      if (time <= 0U)
        this.m_CStr[2].Append(DataManager.Instance.mStringTable.GetStringByID(17135U));
      else
        UIPetTrainingCenter.GetTimeInfoString(this.m_CStr[2], time);
      this.m_ValueText[2].text = this.m_CStr[2].ToString();
      this.m_ValueText[2].SetAllDirty();
      this.m_ValueText[2].cachedTextGenerator.Invalidate();
    }

    public void SetEmpty(IUTimeBarOnTimer hander)
    {
      this.SetPetHibtn((ushort) 0, (byte) 0, (byte) 0, (byte) 0);
      this.SetHeroNum(0);
      this.SetPetExp(0U);
      this.SetPetTime(0U);
      this.m_Timer.SetTimer(0L, 0L, string.Empty, hander);
      if ((Object) this.m_ExpTf != (Object) null)
        this.m_ExpTf.gameObject.SetActive(false);
      if ((Object) this.m_LockIcon != (Object) null)
        ((Component) this.m_LockIcon).gameObject.SetActive(false);
      this.m_Timer.SetState(PetManager.EPetTrainDataState.Empty);
    }

    public void SetTimer(long begin, long require, string petName, IUTimeBarOnTimer hander)
    {
      this.m_Timer.SetTimer(begin, require, petName, hander);
    }

    public void SetState(PetManager.EPetTrainDataState state)
    {
      if (!this.bHasInstance)
        return;
      if (state == PetManager.EPetTrainDataState.NextOpen)
      {
        this.m_ItemTrams[0].gameObject.SetActive(false);
        this.m_ItemTrams[1].gameObject.SetActive(true);
      }
      else
      {
        this.m_ItemTrams[0].gameObject.SetActive(true);
        this.m_ItemTrams[1].gameObject.SetActive(false);
        if (state == PetManager.EPetTrainDataState.Training || state == PetManager.EPetTrainDataState.CanReceive)
        {
          if ((Object) this.m_ImageBg[0] != (Object) null && (Object) this.m_ImageBg[1] != (Object) null)
          {
            ((Behaviour) this.m_ImageBg[0]).enabled = true;
            ((Behaviour) this.m_ImageBg[1]).enabled = false;
          }
        }
        else if ((Object) this.m_ImageBg[0] != (Object) null && (Object) this.m_ImageBg[1] != (Object) null)
        {
          ((Behaviour) this.m_ImageBg[0]).enabled = false;
          ((Behaviour) this.m_ImageBg[1]).enabled = true;
        }
        this.m_Timer.SetState(state);
        this.SetIconTextColor(state);
        this.SetReceived(state);
      }
    }

    private void SetIconTextColor(PetManager.EPetTrainDataState state)
    {
      if (!this.bHasInstance)
        return;
      switch (state)
      {
        case PetManager.EPetTrainDataState.Empty:
        case PetManager.EPetTrainDataState.Received:
          ((Graphic) ((Component) this.m_ValueText[0]).transform.parent.GetComponent<Image>()).color = new Color(0.5f, 0.5f, 0.5f, 1f);
          ((Graphic) this.m_ValueText[0]).color = new Color(0.5f, 0.5f, 0.5f, 1f);
          ((Graphic) ((Component) this.m_ValueText[1]).transform.parent.GetComponent<Image>()).color = new Color(0.5f, 0.5f, 0.5f, 1f);
          ((Graphic) this.m_ValueText[1]).color = new Color(0.14f, 0.48f, 0.48f, 1f);
          ((Graphic) ((Component) this.m_ValueText[2]).transform.parent.GetComponent<Image>()).color = new Color(0.5f, 0.5f, 0.5f, 1f);
          ((Graphic) this.m_ValueText[2]).color = new Color(0.5f, 0.5f, 0.5f, 1f);
          if (state == PetManager.EPetTrainDataState.Received)
          {
            ((Behaviour) this.m_ImageBg[2]).enabled = true;
            break;
          }
          ((Behaviour) this.m_ImageBg[2]).enabled = false;
          break;
        case PetManager.EPetTrainDataState.Training:
        case PetManager.EPetTrainDataState.CanReceive:
          ((Graphic) ((Component) this.m_ValueText[0]).transform.parent.GetComponent<Image>()).color = new Color(1f, 1f, 1f, 1f);
          ((Graphic) this.m_ValueText[0]).color = new Color(1f, 1f, 1f, 1f);
          ((Graphic) ((Component) this.m_ValueText[1]).transform.parent.GetComponent<Image>()).color = new Color(1f, 1f, 1f, 1f);
          ((Graphic) this.m_ValueText[1]).color = new Color(0.28f, 0.96f, 0.96f, 1f);
          ((Graphic) ((Component) this.m_ValueText[2]).transform.parent.GetComponent<Image>()).color = new Color(1f, 1f, 1f, 1f);
          ((Graphic) this.m_ValueText[2]).color = new Color(1f, 1f, 1f, 1f);
          ((Behaviour) this.m_ImageBg[2]).enabled = false;
          break;
      }
    }

    public void SetReceived(PetManager.EPetTrainDataState state)
    {
      Image component1 = ((Component) this.m_ValueText[2]).transform.parent.GetComponent<Image>();
      RectTransform component2 = ((Component) this.m_ValueText[1]).transform.parent.GetComponent<RectTransform>();
      if (state == PetManager.EPetTrainDataState.Received || state == PetManager.EPetTrainDataState.Empty)
      {
        component2.anchoredPosition = new Vector2(366f, -27f);
        ((Component) component1).gameObject.SetActive(true);
      }
      else
      {
        component2.anchoredPosition = new Vector2(366f, -45f);
        ((Component) component1).gameObject.SetActive(false);
      }
    }

    public ushort GetPetID() => (ushort) this.m_PetHiBtn.m_BtnID2;

    public void StopAnim()
    {
      this.m_AnimationSkill.End();
      this.m_Animation.End();
      this.m_ExpDeltaWidth[0] = 0.0f;
      this.m_ExpDeltaWidth[1] = 0.0f;
      this.m_AddTime[2] = false;
      this.m_AddTime[3] = false;
    }

    public void OnTimer()
    {
    }

    public void onFinish()
    {
      if (this.m_Timer == null)
        return;
      this.m_Timer.onFinish();
    }

    public void OnClose()
    {
      if (this.m_Timer != null)
        this.m_Timer.OnClose();
      this.DeSpawnString();
    }

    public void OnTrain(byte dataIdx)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!(bool) (Object) menu)
        return;
      menu.OpenMenu(EGUIWindow.UI_PetSelect, (int) dataIdx, bCameraMode: true);
    }

    public void OnReceive()
    {
      if (this.m_PetID == (ushort) 0)
        return;
      PetManager.Instance.RequestPetTrainingComplete(this.m_PetID);
    }

    public void OnCancel() => PetManager.Instance.RequestPetTrainingCancel(this.m_PetID);

    private void SpawnString()
    {
      if (this.m_CStr == null)
        this.m_CStr = new CString[6];
      for (int index = 0; index < this.m_CStr.Length; ++index)
        this.m_CStr[index] = StringManager.Instance.SpawnString();
    }

    private void DeSpawnString()
    {
      for (int index = 0; index < this.m_CStr.Length; ++index)
      {
        StringManager.Instance.DeSpawnString(this.m_CStr[index]);
        this.m_CStr[index] = (CString) null;
      }
    }

    public void RefreshFontTexture()
    {
      if ((Object) this.m_PetHiBtn != (Object) null)
        this.m_PetHiBtn.Refresh_FontTexture();
      if (this.m_Timer != null)
        this.m_Timer.RefreshFontTexture();
      if (this.m_ValueText != null)
      {
        for (int index = 0; index < this.m_ValueText.Length; ++index)
        {
          if ((Object) this.m_ValueText[index] != (Object) null && ((Behaviour) this.m_ValueText[index]).enabled)
          {
            ((Behaviour) this.m_ValueText[index]).enabled = false;
            ((Behaviour) this.m_ValueText[index]).enabled = true;
          }
        }
      }
      if ((Object) this.m_LvText != (Object) null && ((Behaviour) this.m_LvText).enabled)
      {
        ((Behaviour) this.m_LvText).enabled = false;
        ((Behaviour) this.m_LvText).enabled = true;
      }
      if ((Object) this.m_ExpText != (Object) null && ((Behaviour) this.m_ExpText).enabled)
      {
        ((Behaviour) this.m_ExpText).enabled = false;
        ((Behaviour) this.m_ExpText).enabled = true;
      }
      if (!((Object) this.m_Item2Text != (Object) null) || !((Behaviour) this.m_Item2Text).enabled)
        return;
      ((Behaviour) this.m_Item2Text).enabled = false;
      ((Behaviour) this.m_Item2Text).enabled = true;
    }

    private enum ECStrID
    {
      HeroCount,
      PetExp,
      PetTime,
      LVText,
      SkillLVText,
      ExpText,
      Max,
    }
  }
}
