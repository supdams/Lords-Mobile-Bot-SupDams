// Decompiled with JetBrains decompiler
// Type: UIPetSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIPetSelect : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  private const int PANEL_OBJECT_COUNT = 7;
  private int SCROLL_DATA_COUNT;
  private UIPetSelect.SSrollPanelItem[] m_ScrollObjects = new UIPetSelect.SSrollPanelItem[7];
  private bool bInitScroll;
  private byte PetIdelCount;
  private byte HeroIdleCount;
  private UIPetSelect.EUIType m_UIType;
  private List<UIPetSelect.SScrollData> m_PetScrollData;
  private List<UIPetSelect.SScrollData> m_HeroScrollData;
  private PetManager PetMgr;
  private DataManager DM;
  private Door door;
  private ScrollPanel m_ScrollPanel;
  private Transform[] m_SelectCountTransform;
  private Transform[] m_InfoTransform;
  private Transform m_InfoExpTf;
  private Transform m_SkillIconTf;
  private UIHIBtn m_PetHiBtn;
  private UIText m_InfoTitleText;
  private UIText m_InfoTitleText2;
  private UIText m_InfoRandSkillText;
  private UIText m_InfoRandSkillText2;
  private UIText m_LvText;
  private UIText[] m_PetInfoText;
  private UIText m_HeroInfoCount;
  private UIText[] m_HeroInfoText;
  private UIText m_HeroInfoExp;
  private UIText m_HeroInfoTime;
  private UIText[] m_AutoSelectText;
  private UIText m_OKTExt;
  private UIText m_HeroImageText;
  private Image m_PetHeroSelectBlack;
  private Image m_PetInfoExp;
  private Image m_PetInfoDeltaExp;
  private Image m_SelectEffect;
  private Image m_HeroImage;
  private Image[] m_RankSelect;
  private Image[] m_PetInfoSkillIcon;
  private Image[] m_PetInfoSkillLcokImg;
  private Image[] m_PetInfoSkillBackImg;
  private Image m_PetInfoOverTimeIcon;
  private UIButtonHint[] m_PetInfoSkillHint;
  private Transform[] m_PetInfoSkillTf;
  private UIButton m_AutoSelectHeroBtn;
  private UIButton m_SwitchHeroTypeBtn;
  private CString[] m_CStr;
  private int[] m_ScrollIdx;
  private float[] m_ScrollPosY;
  private byte m_TrainingSetIdx;
  private List<ushort> m_CoachHeroId;
  private uint m_CoachHeroTime;
  private byte[] m_ColorCount;
  private ushort m_CanSelectHeroCount;
  private UIPetSelect.EAutoState m_AutoState;
  private bool bShowSelectEffect;
  private float m_SelectEffectAlpha;
  private float m_SelectTime;
  private float[] m_RanSelectTime;
  private float[] m_RanSelectAlpha;
  private float m_SliderEffectAlpha;
  private float m_SliderTime;
  private UIPetSelect.ESelectItem m_PetSelect = new UIPetSelect.ESelectItem(UIPetSelect.EItemIdx.Left);
  private byte ErrorType;
  private UISpritesArray m_Sp;

  public override void OnOpen(int arg1, int arg2)
  {
    this.PetMgr = PetManager.Instance;
    this.DM = DataManager.Instance;
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.SCROLL_DATA_COUNT = this.PetMgr.PetTable.TableCount / 2 + 10;
    this.m_TrainingSetIdx = (byte) arg1;
    this.m_CoachHeroId = new List<ushort>();
    this.m_CoachHeroTime = 0U;
    this.m_ColorCount = new byte[5];
    this.bShowSelectEffect = false;
    this.m_SelectEffectAlpha = 0.0f;
    this.m_SelectTime = 0.0f;
    this.m_RanSelectTime = new float[6];
    this.m_RanSelectAlpha = new float[6];
    this.SpawnCStr();
    this.PetIdelCount = this.PetMgr.SortPetIdle();
    DataManager.SortHeroData();
    this.m_PetScrollData = new List<UIPetSelect.SScrollData>();
    this.m_HeroScrollData = new List<UIPetSelect.SScrollData>();
    this.m_ScrollIdx = new int[2];
    this.m_ScrollPosY = new float[2];
    this.SetPetData((int) this.m_TrainingSetIdx);
    this.SetHeroData((int) this.m_TrainingSetIdx);
    this.Init();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
  }

  public override void OnClose()
  {
    this.DeSpawnCStr();
    this.DeSpawnPetData();
    this.DeSpawnHeroData();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 0 || !(bool) (UnityEngine.Object) this.door)
      return;
    this.door.CloseMenu();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if (this.m_TrainingSetIdx < (byte) 0 || (int) this.m_TrainingSetIdx >= this.PetMgr.m_PetTrainingData.Length)
          break;
        if (this.PetMgr.m_PetTrainingData[(int) this.m_TrainingSetIdx].m_State == PetManager.EPetTrainDataState.Training || this.PetMgr.m_PetTrainingData[(int) this.m_TrainingSetIdx].m_State == PetManager.EPetTrainDataState.CanReceive || this.PetMgr.m_PetTrainingData[(int) this.m_TrainingSetIdx].m_State == PetManager.EPetTrainDataState.Closed)
        {
          if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
            break;
          this.door.CloseMenu();
          break;
        }
        this.PetIdelCount = this.PetMgr.SortPetIdle();
        DataManager.SortHeroData();
        this.DeSpawnHeroData();
        this.DeSpawnPetData();
        this.SetHeroData(-1);
        this.SetPetData(-1);
        this.SetType(this.m_UIType);
        this.UpdateScrollPanel(false);
        break;
      case NetworkNews.Refresh_Hero:
        DataManager.SortHeroData();
        this.DeSpawnHeroData();
        this.SetHeroData(-1);
        this.SetType(this.m_UIType);
        this.UpdateScrollPanel(false);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.RefreshFontTexture();
        break;
      case NetworkNews.Refresh_Pet:
        this.PetIdelCount = this.PetMgr.SortPetIdle();
        this.DeSpawnPetData();
        this.SetPetData(-1);
        this.SetType(this.m_UIType);
        this.UpdateScrollPanel(false);
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    ushort id = this.m_PetSelect.m_ID;
    if (!bOK)
      return;
    switch (arg1)
    {
      case 0:
      case 1:
        this.PetMgr.RequestPetTrainingBegin(this.m_TrainingSetIdx, id, this.m_CoachHeroId);
        break;
      case 2:
        this.PetMgr.OpenPetEvoPanel(arg2);
        break;
    }
  }

  public override bool OnBackButtonClick() => false;

  private void Update()
  {
    if (this.bShowSelectEffect && (double) this.m_SelectTime < 0.5)
    {
      this.m_SelectTime += Time.deltaTime;
      this.m_SelectEffectAlpha = Mathf.Lerp(0.0f, 2f, this.m_SelectTime / 0.5f);
      if ((double) this.m_SelectEffectAlpha > 1.0)
        ((Graphic) this.m_SelectEffect).color = new Color(1f, 1f, 1f, 2f - this.m_SelectEffectAlpha);
      else
        ((Graphic) this.m_SelectEffect).color = new Color(1f, 1f, 1f, this.m_SelectEffectAlpha);
      if ((double) this.m_SelectEffectAlpha >= 2.0)
      {
        this.m_SelectTime = 0.0f;
        this.bShowSelectEffect = false;
      }
    }
    if (this.m_RankSelect != null)
    {
      for (int index = 0; index < this.m_RanSelectTime.Length && index < this.m_RankSelect.Length; ++index)
      {
        if ((double) this.m_RanSelectTime[index] < 0.30000001192092896 && ((Behaviour) this.m_RankSelect[index]).enabled)
        {
          this.m_RanSelectTime[index] += Time.deltaTime;
          this.m_RanSelectAlpha[index] = Mathf.Lerp(0.0f, 2f, this.m_RanSelectTime[index] / 0.3f);
          if ((double) this.m_RanSelectAlpha[index] > 1.0)
            ((Graphic) this.m_RankSelect[index]).color = new Color(1f, 1f, 1f, 2f - this.m_RanSelectAlpha[index]);
          else
            ((Graphic) this.m_RankSelect[index]).color = new Color(1f, 1f, 1f, this.m_RanSelectAlpha[index]);
          if ((double) this.m_RanSelectAlpha[index] >= 2.0)
          {
            this.m_RanSelectTime[index] = 0.0f;
            ((Behaviour) this.m_RankSelect[index]).enabled = false;
          }
        }
      }
    }
    if (this.m_PetSelect.m_ID == (ushort) 0)
      return;
    this.m_SliderTime += Time.deltaTime;
    this.m_SliderEffectAlpha = Mathf.Lerp(0.0f, 2f, this.m_SliderTime / 1f);
    if ((double) this.m_SliderEffectAlpha > 1.0)
      ((Graphic) this.m_PetInfoDeltaExp).color = new Color(1f, 1f, 1f, 2f - this.m_SliderEffectAlpha);
    else
      ((Graphic) this.m_PetInfoDeltaExp).color = new Color(1f, 1f, 1f, this.m_SliderEffectAlpha);
    if ((double) this.m_SliderEffectAlpha < 2.0)
      return;
    this.m_SliderTime = 0.0f;
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelObjectIdx >= 7)
      return;
    if (!this.m_ScrollObjects[panelObjectIdx].m_PetItem.HasInstance)
      this.InitScrollItem(item, panelObjectIdx);
    this.UpdateScrollItem(item, dataIdx, panelObjectIdx);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        this.SetType(UIPetSelect.EUIType.Hero);
        break;
      case 1:
        if (this.m_AutoState == UIPetSelect.EAutoState.AutoState)
        {
          this.ClearAutoSelect();
          this.AutoSelectHero();
          break;
        }
        if (this.m_AutoState != UIPetSelect.EAutoState.ClearnState)
          break;
        this.ClearAutoSelect();
        break;
      case 2:
        if (this.m_UIType == UIPetSelect.EUIType.Hero)
        {
          this.SetType(UIPetSelect.EUIType.Pet);
          break;
        }
        this.RequestPetTrainingBegin();
        break;
      case 3:
        UIPetSelect.EItemIdx btnId2 = (UIPetSelect.EItemIdx) sender.m_BtnID2;
        int btnId3 = sender.m_BtnID3;
        int btnId4 = sender.m_BtnID4;
        if (this.m_UIType == UIPetSelect.EUIType.Pet)
        {
          if (this.m_PetScrollData[btnId3].CheckIconType(btnId2, UIPetSelect.EIconType.Training))
          {
            GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(17105U), (ushort) 35);
            break;
          }
          if (this.m_PetScrollData[btnId3].CheckIconType(btnId2, UIPetSelect.EIconType.LockLimit))
          {
            ushort ID = this.m_PetScrollData[btnId3].m_ID[(int) btnId2];
            if (ID <= (ushort) 0)
              break;
            PetData petData = this.PetMgr.FindPetData(ID);
            if (petData == null)
              break;
            if (petData.CheckState(PetManager.EPetState.Evolution))
            {
              GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(17150U), (ushort) 35);
              break;
            }
            GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(16082U), this.DM.mStringTable.GetStringByID(16069U), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 2, (int) ID, true);
            break;
          }
          if (this.m_PetScrollData[btnId3].CheckIconType(btnId2, UIPetSelect.EIconType.Lock))
          {
            GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(17089U), (ushort) 35);
            break;
          }
          if (this.m_PetScrollData[btnId3].CheckIconType(btnId2, UIPetSelect.EIconType.Training))
            break;
          for (int index = 0; index < this.m_ScrollObjects.Length; ++index)
          {
            if (this.m_ScrollObjects[index].m_PetItem.HasInstance)
            {
              this.m_ScrollObjects[index].m_PetItem.RemoveIcon(UIPetSelect.EItemIdx.Left, UIPetSelect.EIconType.Select);
              this.m_ScrollObjects[index].m_PetItem.RemoveIcon(UIPetSelect.EItemIdx.Right, UIPetSelect.EIconType.Select);
            }
          }
          this.m_ScrollObjects[btnId4].m_PetItem.OnSelect(btnId2);
          if (this.m_PetSelect.m_DataIdx != byte.MaxValue && (int) this.m_PetSelect.m_DataIdx <= this.m_PetScrollData.Count)
            this.m_PetScrollData[(int) this.m_PetSelect.m_DataIdx].RemoveSelectIcon(this.m_PetSelect.m_ItemIdx);
          this.m_PetSelect = this.m_PetScrollData[btnId3].OnSelect(btnId2, (byte) btnId3);
          this.SetInfoPanel();
          this.bShowSelectEffect = true;
          this.SetSelectCountPanel();
          break;
        }
        if (this.m_UIType != UIPetSelect.EUIType.Hero)
          break;
        if (!this.m_HeroScrollData[btnId3].CheckIconType(btnId2, UIPetSelect.EIconType.Training))
        {
          this.m_ScrollObjects[btnId4].m_HeroItem.OnSelect(btnId2);
          UIPetSelect.ESelectItem eselectItem = this.m_HeroScrollData[btnId3].OnSelect(btnId2, (byte) btnId3);
          ushort num = this.m_HeroScrollData[btnId3].m_ID[(int) btnId2];
          if (eselectItem.m_DataIdx != byte.MaxValue)
          {
            if ((int) this.m_HeroScrollData[btnId3].m_Color[(int) btnId2] < this.m_ColorCount.Length)
              ++this.m_ColorCount[(int) this.m_HeroScrollData[btnId3].m_Color[(int) btnId2]];
            if ((int) this.m_HeroScrollData[btnId3].m_Color[(int) btnId2] < this.m_RankSelect.Length)
              ((Behaviour) this.m_RankSelect[(int) this.m_HeroScrollData[btnId3].m_Color[(int) btnId2]]).enabled = true;
            ((Behaviour) this.m_RankSelect[5]).enabled = true;
            this.m_CoachHeroTime += this.m_HeroScrollData[btnId3].m_TrainTime[(int) btnId2];
            this.m_CoachHeroId.Add(num);
          }
          else
          {
            if ((int) this.m_HeroScrollData[btnId3].m_Color[(int) btnId2] < this.m_ColorCount.Length)
              --this.m_ColorCount[(int) this.m_HeroScrollData[btnId3].m_Color[(int) btnId2]];
            this.m_CoachHeroTime -= this.m_HeroScrollData[btnId3].m_TrainTime[(int) btnId2];
            if (!this.m_CoachHeroId.Remove(num))
              Debug.Log((object) ("heroID " + (object) num + " RemoveError"));
          }
          this.SetInfoPanel();
          this.SetSelectCountPanel();
          break;
        }
        GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(17112U), (ushort) 35);
        break;
      case 4:
        if (this.m_UIType == UIPetSelect.EUIType.Hero)
        {
          this.SetType(UIPetSelect.EUIType.Pet);
          break;
        }
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.CloseMenu();
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (sender.Parm1 == (ushort) 10 || sender.Parm1 == (ushort) 11 || sender.Parm1 == (ushort) 12)
    {
      int index = (int) sender.Parm1 - 10;
      PetData petData = this.PetMgr.FindPetData(this.m_PetSelect.m_ID);
      if (petData != null && (int) petData.ID == (int) this.m_PetSelect.m_ID && index >= 0 && index < petData.SkillLv.Length && index < petData.SkillID.Length)
        GUIManager.Instance.m_Hint.ShowPetHint(sender, PetSkillHint.eKind.Normal, petData.ID, petData.SkillID[index], petData.SkillLv[index], new Vector2(-22f, 0.0f), UIButtonHint.ePosition.LeftSide);
    }
    else
    {
      ushort Parm1 = 0;
      if (sender.Parm1 == (ushort) 5)
        Parm1 = (ushort) 17108;
      else if (sender.Parm1 == (ushort) 6)
        Parm1 = (ushort) 17109;
      else if (sender.Parm1 == (ushort) 7)
        Parm1 = (ushort) 17110;
      else if (sender.Parm1 == (ushort) 8)
        Parm1 = (ushort) 17111;
      else if (sender.Parm1 == (ushort) 9)
        Parm1 = (ushort) 17095;
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 277f, 20, (int) Parm1, 0, Vector2.zero);
    }
    AudioManager.Instance.PlayUISFX();
  }

  public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide();

  private void Init()
  {
    this.m_Sp = this.transform.GetComponent<UISpritesArray>();
    this.m_ScrollPanel = this.transform.GetChild(2).GetComponent<ScrollPanel>();
    Transform child1 = this.transform.GetChild(4);
    Transform child2 = this.transform.GetChild(1);
    this.m_SelectCountTransform = new Transform[2];
    this.m_SelectCountTransform[0] = child2.GetChild(0);
    this.m_SelectCountTransform[1] = child2.GetChild(1);
    this.m_InfoTitleText = child1.GetChild(1).GetComponent<UIText>();
    this.m_InfoTitleText.font = GUIManager.Instance.GetTTFFont();
    this.m_InfoTitleText.text = DataManager.Instance.mStringTable.GetStringByID(17098U);
    this.m_InfoTitleText2 = child1.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.m_InfoTitleText2.font = GUIManager.Instance.GetTTFFont();
    this.m_InfoTitleText2.text = DataManager.Instance.mStringTable.GetStringByID(17102U);
    if (GUIManager.Instance.IsArabic)
      ((Transform) ((Graphic) this.m_InfoTitleText2).rectTransform).Rotate(0.0f, 180f, 0.0f);
    this.m_InfoTransform = new Transform[2];
    this.m_InfoTransform[0] = child1.GetChild(2);
    this.m_PetHiBtn = this.m_InfoTransform[0].GetChild(0).GetChild(0).GetComponent<UIHIBtn>();
    GUIManager.Instance.InitianHeroItemImg(((Component) this.m_PetHiBtn).transform, eHeroOrItem.Pet, (ushort) 0, (byte) 0, (byte) 0);
    this.m_SelectEffect = this.m_InfoTransform[0].GetChild(0).GetChild(1).GetComponent<Image>();
    this.m_SkillIconTf = this.m_InfoTransform[0].GetChild(0).GetChild(2);
    Image component1 = this.m_InfoTransform[0].GetChild(0).GetChild(2).GetComponent<Image>();
    component1.sprite = this.PetMgr.LoadPetSkillIcon((ushort) 0);
    ((MaskableGraphic) component1).material = GUIManager.Instance.GetSkillMaterial();
    Image component2 = this.m_InfoTransform[0].GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>();
    component2.sprite = GUIManager.Instance.LoadFrameSprite("sk");
    ((MaskableGraphic) component2).material = GUIManager.Instance.GetFrameMaterial();
    UIButtonHint uiButtonHint1 = ((Component) component2).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    uiButtonHint1.Parm1 = (ushort) 9;
    this.m_InfoExpTf = this.m_InfoTransform[0].GetChild(1);
    this.m_PetInfoExp = this.m_InfoTransform[0].GetChild(1).GetChild(1).GetComponent<Image>();
    this.m_PetInfoDeltaExp = this.m_InfoTransform[0].GetChild(1).GetChild(0).GetComponent<Image>();
    this.m_LvText = this.m_InfoTransform[0].GetChild(1).GetChild(2).GetChild(1).GetComponent<UIText>();
    this.m_LvText.font = GUIManager.Instance.GetTTFFont();
    this.m_InfoRandSkillText = this.m_InfoTransform[0].GetChild(1).GetChild(3).GetComponent<UIText>();
    this.m_InfoRandSkillText.font = GUIManager.Instance.GetTTFFont();
    this.m_InfoRandSkillText2 = this.m_InfoTransform[0].GetChild(1).GetChild(4).GetComponent<UIText>();
    this.m_InfoRandSkillText2.font = GUIManager.Instance.GetTTFFont();
    this.m_PetInfoText = new UIText[3];
    this.m_PetInfoText[0] = this.m_InfoTransform[0].GetChild(2).GetChild(1).GetComponent<UIText>();
    this.m_PetInfoText[0].font = GUIManager.Instance.GetTTFFont();
    this.m_PetInfoText[1] = this.m_InfoTransform[0].GetChild(2).GetChild(2).GetComponent<UIText>();
    this.m_PetInfoText[1].font = GUIManager.Instance.GetTTFFont();
    this.m_PetInfoText[2] = this.m_InfoTransform[0].GetChild(3).GetChild(1).GetComponent<UIText>();
    this.m_PetInfoText[2].font = GUIManager.Instance.GetTTFFont();
    this.m_PetInfoOverTimeIcon = this.m_InfoTransform[0].GetChild(3).GetChild(2).GetComponent<Image>();
    this.m_PetInfoSkillTf = new Transform[3];
    this.m_PetInfoSkillIcon = new Image[3];
    this.m_PetInfoSkillHint = new UIButtonHint[3];
    this.m_PetInfoSkillLcokImg = new Image[3];
    this.m_PetInfoSkillBackImg = new Image[3];
    for (int index = 0; index < 3; ++index)
    {
      this.m_PetInfoSkillTf[index] = this.m_InfoTransform[0].GetChild(4).GetChild(index);
      this.m_PetInfoSkillHint[index] = this.m_PetInfoSkillTf[index].GetChild(0).gameObject.AddComponent<UIButtonHint>();
      this.m_PetInfoSkillHint[index].m_eHint = EUIButtonHint.DownUpHandler;
      this.m_PetInfoSkillHint[index].m_Handler = (MonoBehaviour) this;
      this.m_PetInfoSkillHint[index].Parm1 = (ushort) (10 + index);
      this.m_PetInfoSkillIcon[index] = this.m_PetInfoSkillTf[index].GetChild(0).GetComponent<Image>();
      this.m_PetInfoSkillIcon[index].sprite = this.PetMgr.LoadPetSkillIcon((ushort) 0);
      ((MaskableGraphic) this.m_PetInfoSkillIcon[index]).material = GUIManager.Instance.GetSkillMaterial();
      Image component3 = this.m_PetInfoSkillTf[index].GetChild(1).GetComponent<Image>();
      component3.sprite = GUIManager.Instance.LoadFrameSprite("sk");
      ((MaskableGraphic) component3).material = GUIManager.Instance.GetFrameMaterial();
      this.m_PetInfoSkillLcokImg[index] = this.m_PetInfoSkillTf[index].GetChild(2).GetComponent<Image>();
      this.m_PetInfoSkillBackImg[index] = this.m_PetInfoSkillTf[index].GetChild(3).GetComponent<Image>();
    }
    uint selectHeroTime = this.GetSelectHeroTime();
    this.m_CStr[2].ClearString();
    this.m_CStr[2].IntToFormat((long) this.GetSelectHeroExpByMin((double) selectHeroTime / 60.0), bNumber: true);
    this.m_CStr[2].AppendFormat("{0}");
    this.m_PetInfoText[0].text = this.m_CStr[2].ToString();
    this.m_PetInfoText[0].SetAllDirty();
    this.m_PetInfoText[0].cachedTextGenerator.Invalidate();
    float f = (float) (int) DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETTRAININGEXP_EXP_PERCENT) / 100f;
    this.m_CStr[1].ClearString();
    this.m_CStr[1].FloatToFormat(f, 2, false);
    this.m_CStr[1].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17130U));
    this.m_PetInfoText[1].text = this.m_CStr[1].ToString();
    this.m_PetInfoText[1].SetAllDirty();
    this.m_PetInfoText[1].cachedTextGenerator.Invalidate();
    this.m_CStr[3].ClearString();
    UIPetSelect.GetTimeInfoString(this.m_CStr[3], selectHeroTime);
    this.m_PetInfoText[2].text = this.m_CStr[3].ToString();
    this.m_PetInfoText[2].SetAllDirty();
    this.m_PetInfoText[2].cachedTextGenerator.Invalidate();
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
      this.m_InfoTransform[0].GetChild(2).GetComponent<Image>().sprite = this.m_Sp.GetSprite(3);
    this.m_InfoTransform[0].GetChild(2).gameObject.AddComponent<ArabicItemTextureRot>();
    UIButtonHint uiButtonHint2 = this.m_InfoTransform[0].GetChild(2).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint2.m_Handler = (MonoBehaviour) this;
    uiButtonHint2.Parm1 = (ushort) 5;
    UIButtonHint uiButtonHint3 = this.m_InfoTransform[0].GetChild(3).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint3.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint3.m_Handler = (MonoBehaviour) this;
    uiButtonHint3.Parm1 = (ushort) 6;
    this.m_InfoTransform[1] = child1.GetChild(3);
    UIButton component4 = this.m_InfoTransform[1].GetChild(0).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_BtnID1 = 1;
    UIButton component5 = child1.GetChild(4).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_BtnID1 = 2;
    this.m_OKTExt = child1.GetChild(4).GetChild(0).GetComponent<UIText>();
    this.m_OKTExt.font = GUIManager.Instance.GetTTFFont();
    this.m_OKTExt.text = this.DM.mStringTable.GetStringByID(189U);
    this.m_PetHeroSelectBlack = this.m_SelectCountTransform[0].GetChild(0).GetComponent<Image>();
    this.m_SelectCountTransform[0].GetChild(3).gameObject.AddComponent<ArabicItemTextureRot>();
    this.m_HeroInfoCount = this.m_SelectCountTransform[0].GetChild(3).GetChild(1).GetComponent<UIText>();
    this.m_HeroInfoCount.font = GUIManager.Instance.GetTTFFont();
    this.m_HeroInfoText = new UIText[5];
    this.m_RankSelect = new Image[6];
    for (int index = 0; index < this.m_HeroInfoText.Length; ++index)
    {
      this.m_RankSelect[index] = this.m_SelectCountTransform[0].GetChild(4 + index).GetChild(0).GetComponent<Image>();
      this.m_HeroInfoText[index] = this.m_SelectCountTransform[0].GetChild(4 + index).GetChild(1).GetComponent<UIText>();
      if ((UnityEngine.Object) this.m_HeroInfoText[index] != (UnityEngine.Object) null)
        this.m_HeroInfoText[index].font = GUIManager.Instance.GetTTFFont();
    }
    this.m_RankSelect[5] = this.m_SelectCountTransform[0].GetChild(3).GetChild(0).GetComponent<Image>();
    ((Component) this.m_RankSelect[5]).gameObject.AddComponent<ArabicItemTextureRot>();
    this.m_AutoSelectText = new UIText[2];
    this.m_AutoSelectText[0] = this.transform.GetChild(1).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
    this.m_AutoSelectText[0].font = GUIManager.Instance.GetTTFFont();
    this.m_AutoSelectText[1] = this.m_InfoTransform[1].GetChild(0).GetChild(0).GetComponent<UIText>();
    this.m_AutoSelectText[1].font = GUIManager.Instance.GetTTFFont();
    this.m_SwitchHeroTypeBtn = this.transform.GetChild(1).GetChild(0).GetChild(1).GetComponent<UIButton>();
    this.m_SwitchHeroTypeBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_SwitchHeroTypeBtn.m_BtnID1 = 0;
    this.m_HeroImage = this.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
    this.m_HeroImageText = this.transform.GetChild(1).GetChild(0).GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
    this.m_HeroImageText.font = GUIManager.Instance.GetTTFFont();
    this.m_HeroImageText.text = this.DM.mStringTable.GetStringByID(17090U);
    this.m_AutoSelectHeroBtn = this.transform.GetChild(1).GetChild(0).GetChild(2).GetComponent<UIButton>();
    this.m_AutoSelectHeroBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_AutoSelectHeroBtn.m_BtnID1 = 1;
    this.m_SelectCountTransform[1].GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
      this.m_SelectCountTransform[1].GetChild(1).GetComponent<Image>().sprite = this.m_Sp.GetSprite(3);
    this.m_HeroInfoExp = this.m_SelectCountTransform[1].GetChild(1).GetChild(0).GetComponent<UIText>();
    this.m_HeroInfoExp.font = GUIManager.Instance.GetTTFFont();
    this.m_HeroInfoTime = this.m_SelectCountTransform[1].GetChild(2).GetChild(0).GetComponent<UIText>();
    this.m_HeroInfoTime.font = GUIManager.Instance.GetTTFFont();
    UIButtonHint uiButtonHint4 = this.m_SelectCountTransform[1].GetChild(4).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint4.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint4.m_Handler = (MonoBehaviour) this;
    uiButtonHint4.Parm1 = (ushort) 7;
    UIButtonHint uiButtonHint5 = this.m_SelectCountTransform[1].GetChild(5).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint5.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint5.m_Handler = (MonoBehaviour) this;
    uiButtonHint5.Parm1 = (ushort) 8;
    Image component6 = this.transform.GetChild(5).GetComponent<Image>();
    component6.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component6).material = this.door.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (UnityEngine.Object) component6)
      ((Behaviour) component6).enabled = false;
    UIButton component7 = this.transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
    component7.m_Handler = (IUIButtonClickHandler) this;
    component7.m_BtnID1 = 4;
    component7.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component7.image).material = this.door.LoadMaterial();
    if (this.m_CoachHeroId != null && this.m_CoachHeroId.Count > 0)
      this.SetAutoBtnState(UIPetSelect.EAutoState.ClearnState);
    else
      this.SetAutoBtnState(UIPetSelect.EAutoState.AutoState);
    this.InitScorllPanel();
    this.SetType(UIPetSelect.EUIType.Pet);
  }

  private UIPetSelect.SScrollData SpawnPetData() => this.PetMgr.m_PetSelectPool.spawn();

  private UIPetSelect.SScrollData SpawnHeroData() => this.PetMgr.m_HeroSelectPool.spawn();

  private void SetPetData(int selectIdx)
  {
    ushort num1 = 0;
    if (selectIdx >= 0 && selectIdx < this.PetMgr.m_PetTrainingClinetSave.Length)
      num1 = this.PetMgr.m_PetTrainingClinetSave[selectIdx].m_PetTrainingSet.m_PetId;
    else if (selectIdx == -1)
      num1 = this.m_PetSelect.m_ID;
    int index1 = 0;
    int num2 = 0;
    UIPetSelect.SScrollData sscrollData = (UIPetSelect.SScrollData) null;
    bool flag = false;
    for (int index2 = 0; index2 < (int) this.PetIdelCount && index2 < this.PetMgr.m_PetTrainginSortData.Count; ++index2)
    {
      if (index1 == 0)
      {
        sscrollData = this.SpawnPetData();
        flag = true;
      }
      if (sscrollData != null)
      {
        sscrollData.bLineType = false;
        sscrollData.bShowOnlyLeft = true;
        sscrollData.bDataPadding = true;
        sscrollData.m_DataIdx[index1] = (int) this.PetMgr.m_PetTrainginSortData[index2];
        PetData petData = this.PetMgr.GetPetData((int) (byte) sscrollData.m_DataIdx[index1]);
        sscrollData.m_ID[index1] = petData.ID;
        sscrollData.m_EIconType[index1] = UIPetSelect.EIconType.None;
        if (petData.CheckState(PetManager.EPetState.Training))
          sscrollData.m_EIconType[index1] |= UIPetSelect.EIconType.Training;
        else if (petData.CheckState(PetManager.EPetState.LockLimit))
          sscrollData.m_EIconType[index1] |= UIPetSelect.EIconType.LockLimit;
        else if ((int) num1 == (int) petData.ID)
        {
          this.m_PetSelect.m_ID = num1;
          this.m_PetSelect.m_DataIdx = (byte) this.m_PetScrollData.Count;
          this.m_PetSelect.m_ItemIdx = (UIPetSelect.EItemIdx) index1;
          sscrollData.m_EIconType[index1] |= UIPetSelect.EIconType.Select;
        }
        if (index1 == 1)
        {
          this.m_PetScrollData.Add(sscrollData);
          flag = false;
        }
        if (index1 == 1)
        {
          index1 = 0;
          sscrollData.bShowOnlyLeft = false;
        }
        else if (index1 == 0)
          index1 = 1;
      }
    }
    if (flag && sscrollData != null)
      this.m_PetScrollData.Add(sscrollData);
    byte num3 = 1;
    if ((int) PetManager.Instance.PetDataCount > (int) this.PetIdelCount)
    {
      sscrollData = this.SpawnPetData();
      for (int index3 = 0; index3 < 2; ++index3)
      {
        sscrollData.bLineType = true;
        sscrollData.bShowOnlyLeft = true;
        sscrollData.bDataPadding = true;
        ++num3;
        if (num3 > (byte) 2)
        {
          this.m_PetScrollData.Add(sscrollData);
          ++num2;
        }
      }
    }
    byte num4 = 1;
    for (int petIdelCount = (int) this.PetIdelCount; petIdelCount < (int) PetManager.Instance.PetDataCount && petIdelCount < this.PetMgr.m_PetTrainginSortData.Count; ++petIdelCount)
    {
      int index4;
      if (num4 == (byte) 1)
      {
        sscrollData = this.SpawnPetData();
        index4 = 0;
      }
      else
        index4 = 1;
      sscrollData.bLineType = false;
      sscrollData.bShowOnlyLeft = true;
      sscrollData.bDataPadding = true;
      sscrollData.m_DataIdx[index4] = (int) this.PetMgr.m_PetTrainginSortData[petIdelCount];
      PetData petData = this.PetMgr.GetPetData((int) (byte) sscrollData.m_DataIdx[index4]);
      sscrollData.m_ID[index4] = petData.ID;
      this.PetMgr.FindPetData(petData.ID);
      if (selectIdx >= 0 && selectIdx < this.PetMgr.m_PetTrainingClinetSave.Length)
      {
        ushort petId = this.PetMgr.m_PetTrainingClinetSave[selectIdx].m_PetTrainingSet.m_PetId;
      }
      sscrollData.m_EIconType[index4] = UIPetSelect.EIconType.None;
      sscrollData.m_EIconType[index4] |= UIPetSelect.EIconType.Lock;
      ++num4;
      if (index4 == 1 || petIdelCount == (int) PetManager.Instance.PetDataCount - 1)
      {
        sscrollData.bShowOnlyLeft = index4 != 1;
        this.m_PetScrollData.Add(sscrollData);
        ++num2;
        num4 = (byte) 1;
      }
    }
  }

  private void SetHeroData(int selectIdx)
  {
    int index1 = 0;
    int num1 = 0;
    UIPetSelect.SScrollData sscrollData = (UIPetSelect.SScrollData) null;
    List<ushort> ushortList = new List<ushort>();
    if (selectIdx != -1)
    {
      ushortList.Clear();
      this.m_CoachHeroId.Clear();
    }
    this.m_CoachHeroTime = 0U;
    Array.Clear((Array) this.m_ColorCount, 0, this.m_ColorCount.Length);
    bool flag = false;
    this.m_CanSelectHeroCount = (ushort) 0;
    CurHeroData curHeroData;
    for (int index2 = 0; (long) index2 < (long) this.DM.CurHeroDataCount; ++index2)
    {
      if (this.DM.curHeroData.ContainsKey(this.DM.sortHeroData[index2]))
      {
        curHeroData = this.DM.curHeroData[this.DM.sortHeroData[index2]];
        if (!this.PetMgr.IsTrainingHero(curHeroData.ID))
        {
          if (index1 == 0)
          {
            sscrollData = this.SpawnHeroData();
            flag = true;
          }
          if (sscrollData != null)
          {
            ++this.m_CanSelectHeroCount;
            sscrollData.bShowOnlyLeft = true;
            sscrollData.bLineType = false;
            sscrollData.bDataPadding = true;
            sscrollData.m_DataIdx[index1] = (int) this.DM.sortHeroData[index2];
            sscrollData.m_ID[index1] = curHeroData.ID;
            sscrollData.m_TrainTime[index1] = (uint) ((int) curHeroData.Star * 10 + 10);
            sscrollData.m_Color[index1] = (byte) ((uint) curHeroData.Star - 1U);
            if (selectIdx == -1)
            {
              if (this.m_CoachHeroId.Contains(curHeroData.ID))
              {
                sscrollData.m_EIconType[index1] = UIPetSelect.EIconType.Select;
                this.m_CoachHeroTime += sscrollData.m_TrainTime[index1];
                if ((int) sscrollData.m_Color[index1] < this.m_ColorCount.Length)
                  ++this.m_ColorCount[(int) sscrollData.m_Color[index1]];
              }
            }
            else if (selectIdx >= 0 && selectIdx < this.PetMgr.m_PetTrainingClinetSave.Length)
            {
              if (this.PetMgr.m_PetTrainingClinetSave[selectIdx].m_PetTrainingSet.m_CoachHeroId.Contains(curHeroData.ID))
              {
                this.m_CoachHeroId.Add(curHeroData.ID);
                sscrollData.m_EIconType[index1] = UIPetSelect.EIconType.Select;
                this.m_CoachHeroTime += sscrollData.m_TrainTime[index1];
                if ((int) sscrollData.m_Color[index1] < this.m_ColorCount.Length)
                  ++this.m_ColorCount[(int) sscrollData.m_Color[index1]];
              }
            }
            else
              sscrollData.m_EIconType[index1] = UIPetSelect.EIconType.None;
            if (index1 == 1)
            {
              this.m_HeroScrollData.Add(sscrollData);
              flag = false;
            }
            if (index1 == 1)
            {
              index1 = 0;
              sscrollData.bShowOnlyLeft = false;
            }
            else if (index1 == 0)
              index1 = 1;
          }
        }
        else
          ushortList.Add(curHeroData.ID);
      }
    }
    if (flag && sscrollData != null)
      this.m_HeroScrollData.Add(sscrollData);
    byte num2 = 1;
    if (ushortList.Count > 0)
    {
      for (int index3 = 0; index3 < 2; ++index3)
      {
        int index4;
        if (num2 == (byte) 1)
        {
          sscrollData = this.SpawnHeroData();
          index4 = 0;
        }
        else
          index4 = 1;
        sscrollData.bLineType = true;
        sscrollData.bShowOnlyLeft = true;
        sscrollData.bDataPadding = true;
        sscrollData.m_EIconType[index4] = UIPetSelect.EIconType.None;
        ++num2;
        if (num2 > (byte) 2)
        {
          this.m_HeroScrollData.Add(sscrollData);
          ++num1;
        }
      }
    }
    byte num3 = 1;
    if (ushortList.Count <= 0)
      return;
    for (int index5 = 0; index5 < ushortList.Count; ++index5)
    {
      int index6;
      if (num3 == (byte) 1)
      {
        sscrollData = this.SpawnHeroData();
        index6 = 0;
      }
      else
        index6 = 1;
      sscrollData.bLineType = false;
      sscrollData.bShowOnlyLeft = true;
      sscrollData.bDataPadding = true;
      sscrollData.m_DataIdx[index6] = (int) ushortList[index5];
      if (this.DM.curHeroData.ContainsKey((uint) sscrollData.m_DataIdx[index6]))
      {
        curHeroData = this.DM.curHeroData[(uint) sscrollData.m_DataIdx[index6]];
        sscrollData.m_ID[index6] = curHeroData.ID;
        sscrollData.m_TrainTime[index6] = (uint) ((int) curHeroData.Star * 10 + 10);
        sscrollData.m_Color[index6] = (byte) ((uint) curHeroData.Star - 1U);
        sscrollData.m_EIconType[index6] = UIPetSelect.EIconType.Training;
        ++num3;
        if (num3 > (byte) 2 || index5 == ushortList.Count - 1)
        {
          if (num3 > (byte) 2)
            sscrollData.bShowOnlyLeft = false;
          this.m_HeroScrollData.Add(sscrollData);
          ++num1;
          num3 = (byte) 1;
        }
      }
    }
  }

  private void SetType(UIPetSelect.EUIType type)
  {
    if ((UnityEngine.Object) this.m_ScrollPanel != (UnityEngine.Object) null)
    {
      this.m_ScrollIdx[(int) this.m_UIType] = this.m_ScrollPanel.GetTopIdx();
      this.m_ScrollPosY[(int) this.m_UIType] = this.m_ScrollPanel.GetContentPos();
    }
    this.m_UIType = type;
    this.UpdateScrollPanel(bUsePos: true);
    this.SetInfoPanel();
    this.SetSelectCountPanel();
  }

  private double GetExpPerMinute()
  {
    bool bSkill = false;
    PetData petData = this.PetMgr.FindPetData(this.m_PetSelect.m_ID);
    if (petData != null)
      bSkill = petData.Level == (byte) 60;
    double num = (double) DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETTRAININGEXP_EXP_PERCENT) / 10000.0;
    return (double) (10 + (int) this.PetMgr.GetTrainExpByHeroCount((ushort) this.m_CoachHeroId.Count, bSkill)) * (1.0 + num) / 60.0;
  }

  private uint GetSelectHeroExpByMin(double minute) => (uint) (this.GetExpPerMinute() * minute);

  private uint GetSelectHeroExp()
  {
    bool bSkill = false;
    PetData petData = this.PetMgr.FindPetData(this.m_PetSelect.m_ID);
    if (petData != null)
      bSkill = petData.Level == (byte) 60;
    float num = (float) DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETTRAININGEXP_EXP_PERCENT) / 10000f;
    return (uint) ((double) (10 + (int) this.PetMgr.GetTrainExpByHeroCount((ushort) this.m_CoachHeroId.Count, bSkill)) * (1.0 + (double) num));
  }

  private uint GetSelectHeroTime()
  {
    return (uint) ((120 + (int) this.m_CoachHeroTime + (int) DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETTRAININGEXP_TIME)) * 60);
  }

  private void SetInfoPanel()
  {
    if (this.m_UIType == UIPetSelect.EUIType.Pet)
    {
      this.m_InfoTransform[0].gameObject.SetActive(true);
      this.m_InfoTitleText.text = this.m_PetSelect.m_ID != (ushort) 0 ? DataManager.Instance.mStringTable.GetStringByID(17107U) : DataManager.Instance.mStringTable.GetStringByID(17098U);
      ((Behaviour) this.m_InfoTitleText2).enabled = false;
      byte dataIdx = this.m_PetSelect.m_DataIdx;
      UIPetSelect.EItemIdx itemIdx = this.m_PetSelect.m_ItemIdx;
      if ((int) dataIdx < this.m_PetScrollData.Count && itemIdx < UIPetSelect.EItemIdx.Max)
      {
        PetData petData = this.PetMgr.GetPetData((int) (byte) this.m_PetScrollData[(int) dataIdx].m_DataIdx[(int) itemIdx]);
        if (petData != null)
        {
          PetTbl recordByKey1 = this.PetMgr.PetTable.GetRecordByKey(petData.ID);
          if ((UnityEngine.Object) this.m_PetHiBtn != (UnityEngine.Object) null)
            GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_PetHiBtn).transform, eHeroOrItem.Pet, petData.ID, petData.Enhance, (byte) 0);
          float max = 183f;
          PetExpTbl recordByKey2 = this.PetMgr.PetExpTable.GetRecordByKey((ushort) petData.Level);
          uint num1 = petData.Exp;
          uint selectHeroExpByMin1 = this.GetSelectHeroExpByMin((double) this.GetSelectHeroTime() / 60.0);
          uint num2 = 0;
          byte num3 = 0;
          uint num4 = selectHeroExpByMin1;
          byte maxLevel = petData.GetMaxLevel();
          for (ushort level = (ushort) petData.Level; (int) level <= (int) maxLevel; ++level)
          {
            recordByKey2 = this.PetMgr.PetExpTable.GetRecordByKey(level);
            num2 = this.PetMgr.GetNeedExp((byte) level, recordByKey1.Rare);
            num3 = (byte) level;
            if ((int) level == (int) petData.Level)
              num1 = petData.Exp;
            else if ((int) level > (int) petData.Level)
              num1 = 0U;
            uint num5 = num2 - num1;
            if ((int) level == (int) maxLevel)
            {
              if (num4 >= num5)
              {
                num4 = num2 - 1U;
                break;
              }
              break;
            }
            if (num4 > num5)
              num4 -= num5;
            else
              break;
          }
          this.m_CStr[0].ClearString();
          this.m_CStr[0].IntToFormat((long) num3);
          this.m_CStr[0].AppendFormat("{0}");
          this.m_LvText.text = this.m_CStr[0].ToString();
          this.m_LvText.SetAllDirty();
          this.m_LvText.cachedTextGenerator.Invalidate();
          if ((int) num3 > (int) petData.Level)
            ((Graphic) this.m_LvText).color = new Color(0.031f, 0.956f, 0.29f, 1f);
          else
            ((Graphic) this.m_LvText).color = new Color(1f, 1f, 1f, 1f);
          Vector2 sizeDelta = ((Graphic) this.m_PetInfoDeltaExp).rectTransform.sizeDelta;
          if (num4 != 0U)
          {
            byte level = DataManager.Instance.RoleAttr.Level;
            float min = 1f;
            if (num3 == (byte) 60 || num3 >= (byte) 15 && (int) num3 >= (int) level && petData.Exp >= num2 - 1U)
            {
              min = 0.0f;
              sizeDelta.x = 0.0f;
            }
            else if ((int) num3 == (int) petData.Level)
            {
              sizeDelta.x = num2 <= 0U ? 0.0f : max * ((float) (num4 + num1) / (float) num2);
              min = Mathf.Clamp(sizeDelta.x, (float) ((double) max * (double) num1 / (double) num2 + 1.0), max);
            }
            else
              sizeDelta.x = num2 <= 0U ? 0.0f : max * ((float) num4 / (float) num2);
            sizeDelta.x = Mathf.Clamp(sizeDelta.x, min, max);
            ((Graphic) this.m_PetInfoDeltaExp).rectTransform.sizeDelta = sizeDelta;
          }
          else
          {
            sizeDelta.x = 0.0f;
            ((Graphic) this.m_PetInfoDeltaExp).rectTransform.sizeDelta = sizeDelta;
          }
          sizeDelta = ((Graphic) this.m_PetInfoExp).rectTransform.sizeDelta;
          if (num3 >= (byte) 60)
          {
            sizeDelta.x = 0.0f;
            ((Graphic) this.m_PetInfoExp).rectTransform.sizeDelta = sizeDelta;
          }
          else if ((int) num3 == (int) petData.Level)
          {
            recordByKey2 = this.PetMgr.PetExpTable.GetRecordByKey((ushort) petData.Level);
            num2 = this.PetMgr.GetNeedExp(petData.Level, recordByKey1.Rare);
            num1 = petData.Exp;
            sizeDelta.x = num2 <= 0U ? 0.0f : max * ((float) num1 / (float) num2);
            sizeDelta.x = Mathf.Clamp(sizeDelta.x, 0.0f, max - 1f);
            ((Graphic) this.m_PetInfoExp).rectTransform.sizeDelta = sizeDelta;
          }
          else
          {
            sizeDelta.x = 0.0f;
            ((Graphic) this.m_PetInfoExp).rectTransform.sizeDelta = sizeDelta;
          }
          uint maxLevelExp = this.GetMaxLevelExp(petData.ID, petData.Level, petData.Exp, num3);
          uint selectHeroTime = this.GetSelectHeroTime();
          uint selectHeroExpByMin2 = this.GetSelectHeroExpByMin((double) selectHeroTime / 60.0);
          uint canTrainTime = this.GetCanTrainTime(maxLevelExp, selectHeroExpByMin2, selectHeroTime);
          this.m_CStr[2].ClearString();
          bool flag = selectHeroExpByMin2 > maxLevelExp && maxLevelExp > 0U;
          if (maxLevelExp > 0U)
            this.m_CStr[2].IntToFormat(!flag ? (long) selectHeroExpByMin2 : (long) maxLevelExp, bNumber: true);
          else
            this.m_CStr[2].IntToFormat((long) selectHeroExpByMin2, bNumber: true);
          this.m_CStr[2].AppendFormat("{0}");
          this.m_PetInfoText[0].text = this.m_CStr[2].ToString();
          this.m_PetInfoText[0].SetAllDirty();
          this.m_PetInfoText[0].cachedTextGenerator.Invalidate();
          float f = (float) (int) DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_PETTRAININGEXP_EXP_PERCENT) / 100f;
          this.m_CStr[1].ClearString();
          this.m_CStr[1].FloatToFormat(f, 2, false);
          this.m_CStr[1].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17130U));
          this.m_PetInfoText[1].text = this.m_CStr[1].ToString();
          this.m_PetInfoText[1].SetAllDirty();
          this.m_PetInfoText[1].cachedTextGenerator.Invalidate();
          this.m_CStr[3].ClearString();
          UIPetSelect.GetTimeInfoString(this.m_CStr[3], !flag ? selectHeroTime : canTrainTime);
          this.m_PetInfoText[2].text = this.m_CStr[3].ToString();
          this.m_PetInfoText[2].SetAllDirty();
          if (flag)
            ((Graphic) this.m_PetInfoText[2]).color = new Color(1f, 0.988f, 0.819f);
          else
            ((Graphic) this.m_PetInfoText[2]).color = new Color(1f, 0.952f, 0.278f);
          this.m_PetInfoText[2].cachedTextGenerator.Invalidate();
          this.ErrorType = (byte) 0;
          ((Behaviour) this.m_InfoExpTf.GetComponent<Image>()).enabled = true;
          for (int index = 0; index < this.m_InfoExpTf.childCount; ++index)
            this.m_InfoExpTf.GetChild(index).gameObject.SetActive(true);
          this.m_InfoExpTf.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector2(-44f, -43f);
          this.m_InfoExpTf.GetChild(3).GetComponent<UIText>().UpdateArabicPos();
          ((Component) this.m_InfoRandSkillText2).gameObject.SetActive(false);
          if (this.m_PetSelect.m_ID == (ushort) 0)
            this.m_InfoExpTf.gameObject.SetActive(this.m_PetSelect.m_ID != (ushort) 0);
          else if (this.PetMgr.IsMaxLevelExp(petData.ID))
          {
            this.m_InfoRandSkillText.text = DataManager.Instance.mStringTable.GetStringByID(17100U);
            ((Behaviour) this.m_InfoRandSkillText).enabled = true;
            this.m_SkillIconTf.gameObject.SetActive(false);
            this.m_InfoExpTf.gameObject.SetActive(true);
            ((Behaviour) this.m_InfoExpTf.GetComponent<Image>()).enabled = false;
            this.m_InfoExpTf.GetChild(0).gameObject.SetActive(false);
            this.m_InfoExpTf.GetChild(1).gameObject.SetActive(false);
            this.m_InfoExpTf.GetChild(2).gameObject.SetActive(false);
            this.m_InfoExpTf.GetChild(3).GetComponent<RectTransform>().anchoredPosition = new Vector2(-44f, 0.0f);
            this.m_InfoExpTf.GetChild(3).GetComponent<UIText>().UpdateArabicPos();
            this.m_InfoRandSkillText.alignment = TextAnchor.UpperLeft;
          }
          else if (petData.CheckState(PetManager.EPetState.LockLimit) || num4 + num1 >= num2 - 1U && (int) num3 == (int) maxLevel)
          {
            if (num3 == (byte) 60)
            {
              this.m_CStr[15].ClearString();
              this.m_CStr[15].IntToFormat((long) petData.Level);
              this.m_CStr[15].IntToFormat((long) num3);
              this.m_CStr[15].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17104U));
              this.m_InfoRandSkillText2.text = this.m_CStr[15].ToString();
              ((Component) this.m_InfoRandSkillText2).gameObject.SetActive(true);
              this.m_InfoRandSkillText2.SetAllDirty();
              this.m_InfoRandSkillText2.cachedTextGenerator.Invalidate();
              this.m_InfoRandSkillText.text = DataManager.Instance.mStringTable.GetStringByID(17099U);
              ((Behaviour) this.m_InfoRandSkillText).enabled = true;
              this.m_SkillIconTf.gameObject.SetActive(false);
              this.m_InfoExpTf.gameObject.SetActive(true);
              this.m_InfoRandSkillText.alignment = TextAnchor.UpperLeft;
              ((Graphic) this.m_InfoRandSkillText).rectTransform.anchoredPosition = new Vector2(-44f, -68.85f);
              this.m_InfoRandSkillText.UpdateArabicPos();
            }
            else
            {
              byte level = DataManager.Instance.RoleAttr.Level;
              if (num3 >= (byte) 15 && (int) num3 >= (int) level)
              {
                this.m_InfoRandSkillText.text = DataManager.Instance.mStringTable.GetStringByID(17140U);
                this.ErrorType = petData.Exp < num2 - 1U ? (byte) 2 : (byte) 1;
              }
              else
              {
                this.ErrorType = (byte) 2;
                this.m_InfoRandSkillText.text = DataManager.Instance.mStringTable.GetStringByID(17099U);
              }
              ((Behaviour) this.m_InfoRandSkillText).enabled = true;
              this.m_SkillIconTf.gameObject.SetActive(false);
              this.m_InfoExpTf.gameObject.SetActive(true);
              this.m_InfoRandSkillText.alignment = TextAnchor.UpperLeft;
            }
            ((Graphic) this.m_InfoRandSkillText).color = new Color(0.937f, 0.227f, 0.329f, 1f);
          }
          else if ((int) num3 >= (int) petData.Level)
          {
            this.m_CStr[14].ClearString();
            this.m_CStr[14].IntToFormat((long) petData.Level);
            this.m_CStr[14].IntToFormat((long) num3);
            this.m_CStr[14].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17104U));
            this.m_InfoRandSkillText.text = this.m_CStr[14].ToString();
            this.m_InfoRandSkillText.SetAllDirty();
            this.m_InfoRandSkillText.cachedTextGenerator.Invalidate();
            ((Behaviour) this.m_InfoRandSkillText).enabled = true;
            this.m_InfoRandSkillText.alignment = TextAnchor.UpperCenter;
            this.m_SkillIconTf.gameObject.SetActive(false);
            this.m_InfoExpTf.gameObject.SetActive(true);
            if ((int) num3 == (int) petData.Level)
              ((Behaviour) this.m_InfoRandSkillText).enabled = false;
          }
          this.SetPetSkillcon(petData.ID);
          ((Component) this.m_PetInfoOverTimeIcon).gameObject.SetActive(flag);
        }
        else
          this.m_InfoExpTf.gameObject.SetActive(false);
      }
      else
        this.m_InfoExpTf.gameObject.SetActive(false);
      this.m_InfoTransform[1].gameObject.SetActive(false);
      ((Behaviour) this.m_InfoTitleText2).enabled = false;
    }
    else
    {
      this.m_InfoTransform[0].gameObject.SetActive(false);
      this.m_InfoTransform[1].gameObject.SetActive(true);
      this.m_InfoTitleText.text = this.DM.mStringTable.GetStringByID(17101U);
      this.m_InfoTitleText2.text = this.DM.mStringTable.GetStringByID(17102U);
      ((Behaviour) this.m_InfoTitleText2).enabled = true;
    }
  }

  private void SetPetSkillcon(ushort petID)
  {
    byte num = 0;
    PetData petData = this.PetMgr.FindPetData(petID);
    if (petData != null)
      num = petData.Enhance;
    if (this.m_PetInfoSkillTf == null || (int) petData.ID != (int) petID)
      return;
    for (int index = 0; index < this.m_PetInfoSkillTf.Length; ++index)
    {
      if (petData.SkillID[index] > (ushort) 0)
      {
        this.m_PetInfoSkillTf[index].gameObject.SetActive(true);
        this.m_PetInfoSkillIcon[index].sprite = this.PetMgr.LoadPetSkillIcon(petData.SkillID[index]);
        this.m_PetInfoSkillHint[index].Parm2 = petData.SkillLv[index];
        if (index <= (int) num)
        {
          ((Component) this.m_PetInfoSkillBackImg[index]).gameObject.SetActive(false);
          ((Component) this.m_PetInfoSkillLcokImg[index]).gameObject.SetActive(false);
        }
        else
        {
          ((Component) this.m_PetInfoSkillBackImg[index]).gameObject.SetActive(true);
          ((Component) this.m_PetInfoSkillLcokImg[index]).gameObject.SetActive(true);
        }
      }
      else
        this.m_PetInfoSkillTf[index].gameObject.SetActive(false);
    }
  }

  private void SetSelectCountPanel()
  {
    if (this.m_UIType == UIPetSelect.EUIType.Pet)
    {
      this.m_SelectCountTransform[1].gameObject.SetActive(false);
      this.SetPetColorCount();
      ((Component) this.m_AutoSelectHeroBtn).gameObject.SetActive(true);
      ((Component) this.m_SwitchHeroTypeBtn).gameObject.SetActive(true);
      ((Behaviour) this.m_PetHeroSelectBlack).enabled = false;
    }
    else
    {
      if (this.m_CoachHeroTime > 0U)
      {
        this.m_CStr[12].ClearString();
        UIPetSelect.GetTimeInfoString(this.m_CStr[12], this.m_CoachHeroTime * 60U, true);
        this.m_HeroInfoTime.text = this.m_CStr[12].ToString();
        this.m_HeroInfoTime.SetAllDirty();
        this.m_HeroInfoTime.cachedTextGenerator.Invalidate();
      }
      else
      {
        this.m_HeroInfoTime.text = this.DM.mStringTable.GetStringByID(17135U);
        this.m_HeroInfoTime.SetAllDirty();
        this.m_HeroInfoTime.cachedTextGenerator.Invalidate();
      }
      if (this.m_CoachHeroId != null)
      {
        ushort trainExpByHeroCount = this.PetMgr.GetTrainExpByHeroCount((ushort) this.m_CoachHeroId.Count);
        if (this.m_CoachHeroId.Count > 0)
        {
          this.m_CStr[13].ClearString();
          this.m_CStr[13].Append("+");
          this.m_CStr[13].IntToFormat((long) trainExpByHeroCount, bNumber: true);
          this.m_CStr[13].AppendFormat(this.DM.mStringTable.GetStringByID(17136U));
          this.m_HeroInfoExp.text = this.m_CStr[13].ToString();
          this.m_HeroInfoExp.SetAllDirty();
          this.m_HeroInfoExp.cachedTextGenerator.Invalidate();
        }
        else
        {
          this.m_HeroInfoExp.text = this.DM.mStringTable.GetStringByID(17135U);
          this.m_HeroInfoExp.SetAllDirty();
          this.m_HeroInfoExp.cachedTextGenerator.Invalidate();
        }
      }
      this.m_SelectCountTransform[1].gameObject.SetActive(true);
      this.SetHeroColorCount();
      ((Component) this.m_AutoSelectHeroBtn).gameObject.SetActive(false);
      ((Component) this.m_SwitchHeroTypeBtn).gameObject.SetActive(false);
      ((Behaviour) this.m_PetHeroSelectBlack).enabled = true;
    }
  }

  private void SetPetColorCount()
  {
    if (this.m_CoachHeroId.Count > 0)
      ((Component) this.m_HeroImage).gameObject.SetActive(false);
    else
      ((Component) this.m_HeroImage).gameObject.SetActive(true);
    this.m_SelectCountTransform[0].gameObject.SetActive(true);
    this.m_CStr[4].ClearString();
    this.m_CStr[4].IntToFormat((long) this.m_CoachHeroId.Count);
    this.m_CStr[4].AppendFormat("{0}");
    this.m_HeroInfoCount.text = this.m_CStr[4].ToString();
    this.m_HeroInfoCount.SetAllDirty();
    this.m_HeroInfoCount.cachedTextGenerator.Invalidate();
    ((Component) this.m_HeroInfoCount).transform.parent.gameObject.SetActive(this.m_CoachHeroId.Count > 0);
    float[] numArray = new float[5]
    {
      279.8333f,
      325.8333f,
      371.8333f,
      417.8333f,
      463.8333f
    };
    byte index1 = 0;
    for (int index2 = this.m_ColorCount.Length - 1; index2 >= 0 && index2 < this.m_HeroInfoText.Length; --index2)
    {
      if (this.m_ColorCount[index2] > (byte) 0)
      {
        this.m_CStr[7 + index2].ClearString();
        this.m_CStr[7 + index2].IntToFormat((long) this.m_ColorCount[index2]);
        this.m_CStr[7 + index2].AppendFormat("{0}");
        this.m_HeroInfoText[index2].text = this.m_CStr[7 + index2].ToString();
        this.m_HeroInfoText[index2].SetAllDirty();
        this.m_HeroInfoText[index2].cachedTextGenerator.Invalidate();
        RectTransform component = ((Component) this.m_HeroInfoText[index2]).transform.parent.gameObject.GetComponent<RectTransform>();
        component.anchoredPosition = new Vector2(numArray[(int) index1], component.anchoredPosition.y);
        ++index1;
        ((Component) this.m_HeroInfoText[index2]).transform.parent.gameObject.SetActive(true);
      }
      else
        ((Component) this.m_HeroInfoText[index2]).transform.parent.gameObject.SetActive(false);
    }
  }

  private void SetHeroColorCount()
  {
    ((Component) this.m_HeroImage).gameObject.SetActive(false);
    if (this.m_CoachHeroId.Count > 0)
    {
      this.m_SelectCountTransform[0].gameObject.SetActive(true);
      this.m_CStr[4].ClearString();
      this.m_CStr[4].IntToFormat((long) this.m_CoachHeroId.Count);
      this.m_CStr[4].AppendFormat("{0}");
      this.m_HeroInfoCount.text = this.m_CStr[4].ToString();
      this.m_HeroInfoCount.SetAllDirty();
      this.m_HeroInfoCount.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.m_HeroInfoCount.text = DataManager.Instance.mStringTable.GetStringByID(17135U);
      this.m_HeroInfoCount.SetAllDirty();
      this.m_HeroInfoCount.cachedTextGenerator.Invalidate();
    }
    ((Component) this.m_HeroInfoCount).transform.parent.gameObject.SetActive(true);
    float[] numArray = new float[5]
    {
      279.8333f,
      325.8333f,
      371.8333f,
      417.8333f,
      463.8333f
    };
    byte index1 = 0;
    for (int index2 = this.m_ColorCount.Length - 1; index2 >= 0 && index2 < this.m_HeroInfoText.Length; --index2)
    {
      if (this.m_ColorCount[index2] > (byte) 0)
      {
        this.m_CStr[7 + index2].ClearString();
        this.m_CStr[7 + index2].IntToFormat((long) this.m_ColorCount[index2]);
        this.m_CStr[7 + index2].AppendFormat("{0}");
        this.m_HeroInfoText[index2].text = this.m_CStr[7 + index2].ToString();
        this.m_HeroInfoText[index2].SetAllDirty();
        this.m_HeroInfoText[index2].cachedTextGenerator.Invalidate();
        RectTransform component = ((Component) this.m_HeroInfoText[index2]).transform.parent.gameObject.GetComponent<RectTransform>();
        component.anchoredPosition = new Vector2(numArray[(int) index1], component.anchoredPosition.y);
        ++index1;
        ((Component) this.m_HeroInfoText[index2]).transform.parent.gameObject.SetActive(true);
      }
      else
        ((Component) this.m_HeroInfoText[index2]).transform.parent.gameObject.SetActive(false);
    }
  }

  private void RequestPetTrainingBegin()
  {
    ushort id = this.m_PetSelect.m_ID;
    if (this.ErrorType == (byte) 1)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17140U), (ushort) 35);
    else if (id == (ushort) 0)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17098U), (ushort) 35);
    else if (this.m_CoachHeroId.Count == 0 && this.m_CanSelectHeroCount > (ushort) 0)
      GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(614U), DataManager.Instance.mStringTable.GetStringByID(17144U), 1);
    else if (this.ErrorType == (byte) 2)
      GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(614U), DataManager.Instance.mStringTable.GetStringByID(17143U));
    else
      this.PetMgr.RequestPetTrainingBegin(this.m_TrainingSetIdx, id, this.m_CoachHeroId);
  }

  private void AutoSelectHero()
  {
    this.m_CoachHeroId.Clear();
    for (byte index = 0; (int) index < this.m_HeroScrollData.Count; ++index)
    {
      if (this.m_HeroScrollData[(int) index].HasInstance)
      {
        for (int idx = 0; idx < 2; ++idx)
        {
          if (!this.m_HeroScrollData[(int) index].CheckIconType((UIPetSelect.EItemIdx) idx, UIPetSelect.EIconType.Training) && !this.m_HeroScrollData[(int) index].CheckIconType((UIPetSelect.EItemIdx) idx, UIPetSelect.EIconType.Select) && !this.m_HeroScrollData[(int) index].CheckIconType((UIPetSelect.EItemIdx) idx, UIPetSelect.EIconType.LockLimit) && !this.m_HeroScrollData[(int) index].CheckIconType((UIPetSelect.EItemIdx) idx, UIPetSelect.EIconType.Lock) && this.m_HeroScrollData[(int) index].m_ID[idx] != (ushort) 0 && !this.m_HeroScrollData[(int) index].bLineType)
          {
            if ((int) this.m_HeroScrollData[(int) index].m_Color[idx] < this.m_ColorCount.Length)
              ++this.m_ColorCount[(int) this.m_HeroScrollData[(int) index].m_Color[idx]];
            this.m_HeroScrollData[(int) index].OnSelect((UIPetSelect.EItemIdx) idx, index);
            this.m_CoachHeroId.Add(this.m_HeroScrollData[(int) index].m_ID[idx]);
            this.m_CoachHeroTime += this.m_HeroScrollData[(int) index].m_TrainTime[idx];
          }
        }
      }
    }
    if (this.m_UIType == UIPetSelect.EUIType.Hero)
    {
      for (int index = 0; index < this.m_RankSelect.Length; ++index)
        ((Behaviour) this.m_RankSelect[index]).enabled = true;
    }
    if (this.m_CoachHeroId.Count != 0)
    {
      this.UpdateScrollPanel(false);
      this.SetAutoBtnState(UIPetSelect.EAutoState.ClearnState);
      this.SetInfoPanel();
      this.SetSelectCountPanel();
    }
    else
      GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(17137U), (ushort) 35);
  }

  private void ClearAutoSelect()
  {
    this.m_CoachHeroId.Clear();
    this.m_CoachHeroTime = 0U;
    Array.Clear((Array) this.m_ColorCount, 0, this.m_ColorCount.Length);
    for (int index = 0; index < this.m_ColorCount.Length; ++index)
      this.m_ColorCount[index] = (byte) 0;
    for (byte index = 0; (int) index < this.m_HeroScrollData.Count; ++index)
    {
      if (this.m_HeroScrollData[(int) index].HasInstance)
      {
        for (int idx = 0; idx < 2; ++idx)
        {
          this.m_HeroScrollData[(int) index].RemoveIcon((UIPetSelect.EItemIdx) idx, UIPetSelect.EIconType.Select);
          this.m_CoachHeroId.Remove(this.m_HeroScrollData[(int) index].m_ID[idx]);
        }
      }
    }
    this.UpdateScrollPanel(false);
    this.SetAutoBtnState(UIPetSelect.EAutoState.AutoState);
    this.SetInfoPanel();
    this.SetSelectCountPanel();
  }

  private void SetAutoBtnState(UIPetSelect.EAutoState state)
  {
    this.m_AutoState = state;
    if (this.m_AutoState == UIPetSelect.EAutoState.AutoState)
    {
      this.m_AutoSelectText[0].text = DataManager.Instance.mStringTable.GetStringByID(824U);
      this.m_AutoSelectText[1].text = DataManager.Instance.mStringTable.GetStringByID(824U);
    }
    else
    {
      if (this.m_AutoState != UIPetSelect.EAutoState.ClearnState)
        return;
      this.m_AutoSelectText[0].text = DataManager.Instance.mStringTable.GetStringByID(825U);
      this.m_AutoSelectText[1].text = DataManager.Instance.mStringTable.GetStringByID(825U);
    }
  }

  private void InitScorllPanel()
  {
    if (this.bInitScroll)
      return;
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_PetScrollData.Count; ++index)
    {
      if (this.m_PetScrollData[index].bDataPadding)
      {
        if (this.m_PetScrollData[index].bLineType)
          _DataHeight.Add(30f);
        else
          _DataHeight.Add(80f);
      }
    }
    if ((UnityEngine.Object) this.m_ScrollPanel != (UnityEngine.Object) null)
      this.m_ScrollPanel.IntiScrollPanel(403f, 10f, 6f, _DataHeight, 7, (IUpDateScrollPanel) this);
    this.bInitScroll = true;
  }

  private void UpdateScrollPanel(bool IsSetBeginPos = true, bool bUsePos = false)
  {
    if ((UnityEngine.Object) this.m_ScrollPanel == (UnityEngine.Object) null && !this.bInitScroll)
      return;
    List<float> _DataHeight = new List<float>();
    List<UIPetSelect.SScrollData> sscrollDataList = this.m_UIType != UIPetSelect.EUIType.Pet ? this.m_HeroScrollData : this.m_PetScrollData;
    for (int index = 0; index < sscrollDataList.Count; ++index)
    {
      if (sscrollDataList[index].bDataPadding)
      {
        if (sscrollDataList[index].bLineType)
          _DataHeight.Add(50f);
        else
          _DataHeight.Add(80f);
      }
    }
    this.m_ScrollPanel.AddNewDataHeight(_DataHeight, IsSetBeginPos);
    if (!bUsePos)
      return;
    this.m_ScrollPanel.GoTo(this.m_ScrollIdx[(int) this.m_UIType], this.m_ScrollPosY[(int) this.m_UIType]);
  }

  private void InitScrollItem(GameObject item, int panelObjectIdx)
  {
    if (panelObjectIdx >= this.m_ScrollObjects.Length)
      return;
    Transform child1 = item.transform.GetChild(0);
    Transform child2 = item.transform.GetChild(1);
    Transform child3 = item.transform.GetChild(2);
    Transform[] trans1 = new Transform[2];
    UIButton[] btn1 = new UIButton[2];
    UIHIBtn[] hiBtn1 = new UIHIBtn[2];
    UIText[] name = new UIText[2];
    UIText[] sliderText = new UIText[2];
    Image[] slider = new Image[2];
    Image[] mask1 = new Image[2];
    Image[][] stateIcon1 = new Image[2][]
    {
      new Image[3],
      new Image[3]
    };
    UIButton[] btn2 = new UIButton[2];
    Transform[] trans2 = new Transform[2];
    UIHIBtn[] hiBtn2 = new UIHIBtn[2];
    UIText[] additionalTimeText = new UIText[2];
    Image[] mask2 = new Image[2];
    Image[][] stateIcon2 = new Image[2][]
    {
      new Image[3],
      new Image[3]
    };
    for (int index = 0; index < trans1.Length; ++index)
      trans1[index] = child1.GetChild(index);
    for (int index = 0; index < 2; ++index)
    {
      btn1[index] = trans1[index].GetComponent<UIButton>();
      btn1[index].m_BtnID1 = 3;
      btn1[index].m_Handler = (IUIButtonClickHandler) this;
      hiBtn1[index] = trans1[index].GetChild(0).GetComponent<UIHIBtn>();
      name[index] = trans1[index].GetChild(1).GetComponent<UIText>();
      name[index].font = GUIManager.Instance.GetTTFFont();
      slider[index] = trans1[index].GetChild(2).GetChild(0).GetComponent<Image>();
      sliderText[index] = trans1[index].GetChild(2).GetChild(1).GetComponent<UIText>();
      sliderText[index].font = GUIManager.Instance.GetTTFFont();
      mask1[index] = trans1[index].GetChild(3).GetComponent<Image>();
      stateIcon1[index][0] = trans1[index].GetChild(4).GetComponent<Image>();
      stateIcon1[index][1] = trans1[index].GetChild(5).GetComponent<Image>();
      stateIcon1[index][2] = trans1[index].GetChild(6).GetComponent<Image>();
      ((Component) stateIcon1[index][2]).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    for (int index = 0; index < trans2.Length; ++index)
      trans2[index] = child2.GetChild(index);
    for (int index = 0; index < 2; ++index)
    {
      btn2[index] = trans2[index].GetComponent<UIButton>();
      btn2[index].m_BtnID1 = 3;
      btn2[index].m_Handler = (IUIButtonClickHandler) this;
      hiBtn2[index] = trans2[index].GetChild(0).GetComponent<UIHIBtn>();
      additionalTimeText[index] = trans2[index].GetChild(1).GetChild(0).GetComponent<UIText>();
      additionalTimeText[index].font = GUIManager.Instance.GetTTFFont();
      mask2[index] = trans2[index].GetChild(2).GetComponent<Image>();
      stateIcon2[index][0] = trans2[index].GetChild(3).GetComponent<Image>();
      stateIcon2[index][1] = trans2[index].GetChild(4).GetComponent<Image>();
      stateIcon2[index][2] = trans2[index].GetChild(5).GetComponent<Image>();
      ((Component) stateIcon2[index][2]).gameObject.AddComponent<ArabicItemTextureRot>();
    }
    UIText component = child3.GetChild(0).GetComponent<UIText>();
    component.font = GUIManager.Instance.GetTTFFont();
    this.m_ScrollObjects[panelObjectIdx] = new UIPetSelect.SSrollPanelItem(UIPetSelect.SSrollPanelItem.EItemType.PetType, this.m_Sp);
    this.m_ScrollObjects[panelObjectIdx].m_PetItem.Init(child1, trans1, btn1, hiBtn1, name, sliderText, slider, mask1, stateIcon1);
    this.m_ScrollObjects[panelObjectIdx].m_LineItem.Init(child3, component);
    this.m_ScrollObjects[panelObjectIdx].m_HeroItem.Init(child2, trans2, btn2, hiBtn2, additionalTimeText, mask2, stateIcon2);
  }

  private void UpdateScrollItem(GameObject item, int dataIdx, int panelObjectIdx)
  {
    if (panelObjectIdx >= 7)
      return;
    if (this.m_UIType == UIPetSelect.EUIType.Pet)
    {
      if (dataIdx < 0 || dataIdx >= this.m_PetScrollData.Count)
        return;
      this.UpdateScrollItemPet(dataIdx, panelObjectIdx);
    }
    else
    {
      if (dataIdx < 0 || dataIdx >= this.m_HeroScrollData.Count)
        return;
      this.UpdateScrollItemHero(dataIdx, panelObjectIdx);
    }
  }

  private void UpdateScrollItemPet(int dataIdx, int panelObjectIdx)
  {
    if (!this.m_ScrollObjects[panelObjectIdx].m_PetItem.HasInstance)
      return;
    UIPetSelect.SScrollData sscrollData = this.m_PetScrollData[dataIdx];
    if (sscrollData.m_ID == null || sscrollData.m_DataIdx == null || sscrollData.m_EIconType == null)
      return;
    PetData petData1 = PetManager.Instance.GetPetData((int) (byte) sscrollData.m_DataIdx[0]);
    PetData petData2 = PetManager.Instance.GetPetData((int) (byte) sscrollData.m_DataIdx[1]);
    if (sscrollData.bLineType)
    {
      this.m_ScrollObjects[panelObjectIdx].SetType(UIPetSelect.SSrollPanelItem.EItemType.LineType);
    }
    else
    {
      this.m_ScrollObjects[panelObjectIdx].SetType(UIPetSelect.SSrollPanelItem.EItemType.PetType);
      if (petData1 != null && petData2 != null)
      {
        this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetBtnID(UIPetSelect.EItemIdx.Left, dataIdx, panelObjectIdx);
        this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetBtnID(UIPetSelect.EItemIdx.Right, dataIdx, panelObjectIdx);
        this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetHiBtn(UIPetSelect.EItemIdx.Left, petData1.ID, petData1.Enhance, petData1.Rare, (int) petData1.Level);
        this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetHiBtn(UIPetSelect.EItemIdx.Right, petData2.ID, petData2.Enhance, petData2.Rare, (int) petData2.Level);
        uint needExp1 = this.PetMgr.GetNeedExp(petData1.Level, petData1.Rare);
        uint needExp2 = this.PetMgr.GetNeedExp(petData2.Level, petData2.Rare);
        byte maxLevel1 = petData1.GetMaxLevel();
        byte maxLevel2 = petData2.GetMaxLevel();
        this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetSlider(UIPetSelect.EItemIdx.Left, petData1.Exp, needExp1, petData1.Level, maxLevel1);
        this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetSlider(UIPetSelect.EItemIdx.Right, petData2.Exp, needExp2, petData2.Level, maxLevel2);
        this.m_ScrollObjects[panelObjectIdx].m_PetItem.ClearIcon(UIPetSelect.EItemIdx.Left);
        this.m_ScrollObjects[panelObjectIdx].m_PetItem.ClearIcon(UIPetSelect.EItemIdx.Right);
        this.m_ScrollObjects[panelObjectIdx].m_PetItem.AddIcon(UIPetSelect.EItemIdx.Left, sscrollData.m_EIconType[0]);
        this.m_ScrollObjects[panelObjectIdx].m_PetItem.AddIcon(UIPetSelect.EItemIdx.Right, sscrollData.m_EIconType[1]);
        this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetName(UIPetSelect.EItemIdx.Left, petData1.ID);
        this.m_ScrollObjects[panelObjectIdx].m_PetItem.SetName(UIPetSelect.EItemIdx.Right, petData2.ID);
        if (!sscrollData.bShowOnlyLeft)
          return;
        this.m_ScrollObjects[panelObjectIdx].m_PetItem.OnlyShowLeft(sscrollData.bShowOnlyLeft);
      }
      else
        Debug.Log((object) ("dataIdx " + (object) dataIdx + "is Null"));
    }
  }

  private void UpdateScrollItemHero(int dataIdx, int panelObjectIdx)
  {
    if (!this.m_ScrollObjects[panelObjectIdx].m_HeroItem.HasInstance)
      return;
    UIPetSelect.SScrollData sscrollData = this.m_HeroScrollData[dataIdx];
    if (sscrollData.m_ID == null || sscrollData.m_DataIdx == null || sscrollData.m_EIconType == null)
      return;
    if (sscrollData.bLineType)
    {
      this.m_ScrollObjects[panelObjectIdx].SetType(UIPetSelect.SSrollPanelItem.EItemType.LineType, false);
    }
    else
    {
      this.m_ScrollObjects[panelObjectIdx].SetType(UIPetSelect.SSrollPanelItem.EItemType.HeroType, false);
      this.m_ScrollObjects[panelObjectIdx].m_HeroItem.SetBtnID(UIPetSelect.EItemIdx.Left, dataIdx, panelObjectIdx);
      this.m_ScrollObjects[panelObjectIdx].m_HeroItem.SetBtnID(UIPetSelect.EItemIdx.Right, dataIdx, panelObjectIdx);
      if (!sscrollData.bShowOnlyLeft)
      {
        if (!this.DM.curHeroData.ContainsKey((uint) sscrollData.m_DataIdx[1]))
          return;
        CurHeroData curHeroData = this.DM.curHeroData[(uint) sscrollData.m_DataIdx[1]];
        this.m_ScrollObjects[panelObjectIdx].m_HeroItem.SetHiBtn(UIPetSelect.EItemIdx.Right, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level);
      }
      else
        this.m_ScrollObjects[panelObjectIdx].m_HeroItem.OnlyShowLeft(true);
      if (!this.DM.curHeroData.ContainsKey((uint) sscrollData.m_DataIdx[0]))
        return;
      CurHeroData curHeroData1 = this.DM.curHeroData[(uint) sscrollData.m_DataIdx[0]];
      this.m_ScrollObjects[panelObjectIdx].m_HeroItem.SetHiBtn(UIPetSelect.EItemIdx.Left, curHeroData1.ID, curHeroData1.Star, curHeroData1.Enhance, (int) curHeroData1.Level);
      this.m_ScrollObjects[panelObjectIdx].m_HeroItem.SetTrainTime(UIPetSelect.EItemIdx.Left, sscrollData.m_TrainTime[0]);
      this.m_ScrollObjects[panelObjectIdx].m_HeroItem.SetTrainTime(UIPetSelect.EItemIdx.Right, sscrollData.m_TrainTime[1]);
      this.m_ScrollObjects[panelObjectIdx].m_HeroItem.ClearIcon(UIPetSelect.EItemIdx.Left);
      this.m_ScrollObjects[panelObjectIdx].m_HeroItem.ClearIcon(UIPetSelect.EItemIdx.Right);
      this.m_ScrollObjects[panelObjectIdx].m_HeroItem.AddIcon(UIPetSelect.EItemIdx.Left, sscrollData.m_EIconType[0]);
      this.m_ScrollObjects[panelObjectIdx].m_HeroItem.AddIcon(UIPetSelect.EItemIdx.Right, sscrollData.m_EIconType[1]);
      if (!sscrollData.bShowOnlyLeft)
        return;
      this.m_ScrollObjects[panelObjectIdx].m_HeroItem.OnlyShowLeft(sscrollData.bShowOnlyLeft);
    }
  }

  public void SpawnCStr()
  {
    this.m_CStr = new CString[16];
    for (int index = 0; index < this.m_CStr.Length; ++index)
      this.m_CStr[index] = StringManager.Instance.SpawnString(100);
  }

  public void DeSpawnCStr()
  {
    if (this.m_CStr != null)
    {
      for (int index = 0; index < this.m_CStr.Length; ++index)
      {
        if (this.m_CStr[index] != null)
        {
          StringManager.Instance.DeSpawnString(this.m_CStr[index]);
          this.m_CStr[index] = (CString) null;
        }
      }
    }
    for (int index = 0; index < 7; ++index)
    {
      if (this.m_ScrollObjects[index].m_HeroItem.HasInstance)
      {
        this.m_ScrollObjects[index].m_HeroItem.DeSpawn();
        this.m_ScrollObjects[index].m_PetItem.DeSpawn();
      }
    }
  }

  public void DeSpawnPetData()
  {
    for (int index = 0; index < this.m_PetScrollData.Count; ++index)
    {
      this.m_PetScrollData[index].Empty();
      this.PetMgr.m_PetSelectPool.despawn(this.m_PetScrollData[index]);
    }
    this.m_PetScrollData.Clear();
  }

  public void DeSpawnHeroData()
  {
    for (int index = 0; index < this.m_HeroScrollData.Count; ++index)
    {
      this.m_HeroScrollData[index].Empty();
      this.PetMgr.m_HeroSelectPool.despawn(this.m_HeroScrollData[index]);
    }
    this.m_HeroScrollData.Clear();
  }

  private void RefreshFontTexture()
  {
    for (int index = 0; index < 7; ++index)
    {
      if (this.m_ScrollObjects[index].m_HeroItem.HasInstance)
      {
        if (this.m_ScrollObjects[index].m_HeroItem.HasInstance)
          this.m_ScrollObjects[index].m_HeroItem.RefreshFontTexture();
        if (this.m_ScrollObjects[index].m_PetItem.HasInstance)
          this.m_ScrollObjects[index].m_PetItem.RefreshFontTexture();
        if (this.m_ScrollObjects[index].m_LineItem.HasInstance)
          this.m_ScrollObjects[index].m_LineItem.RefreshFontTexture();
      }
    }
    if ((UnityEngine.Object) this.m_InfoTitleText != (UnityEngine.Object) null && ((Behaviour) this.m_InfoTitleText).enabled)
    {
      ((Behaviour) this.m_InfoTitleText).enabled = false;
      ((Behaviour) this.m_InfoTitleText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_InfoTitleText2 != (UnityEngine.Object) null && ((Behaviour) this.m_InfoTitleText2).enabled)
    {
      ((Behaviour) this.m_InfoTitleText2).enabled = false;
      ((Behaviour) this.m_InfoTitleText2).enabled = true;
    }
    if ((UnityEngine.Object) this.m_InfoRandSkillText != (UnityEngine.Object) null && ((Behaviour) this.m_InfoRandSkillText).enabled)
    {
      ((Behaviour) this.m_InfoRandSkillText).enabled = false;
      ((Behaviour) this.m_InfoRandSkillText).enabled = true;
    }
    if ((UnityEngine.Object) this.m_InfoRandSkillText2 != (UnityEngine.Object) null && ((Behaviour) this.m_InfoRandSkillText2).enabled)
    {
      ((Behaviour) this.m_InfoRandSkillText2).enabled = false;
      ((Behaviour) this.m_InfoRandSkillText2).enabled = true;
    }
    if ((UnityEngine.Object) this.m_LvText != (UnityEngine.Object) null && ((Behaviour) this.m_LvText).enabled)
    {
      ((Behaviour) this.m_LvText).enabled = false;
      ((Behaviour) this.m_LvText).enabled = true;
    }
    for (int index = 0; index < this.m_PetInfoText.Length; ++index)
    {
      if ((UnityEngine.Object) this.m_PetInfoText[index] != (UnityEngine.Object) null && ((Behaviour) this.m_PetInfoText[index]).enabled)
      {
        ((Behaviour) this.m_PetInfoText[index]).enabled = false;
        ((Behaviour) this.m_PetInfoText[index]).enabled = true;
      }
    }
    if ((UnityEngine.Object) this.m_HeroInfoExp != (UnityEngine.Object) null && ((Behaviour) this.m_HeroInfoExp).enabled)
    {
      ((Behaviour) this.m_HeroInfoExp).enabled = false;
      ((Behaviour) this.m_HeroInfoExp).enabled = true;
    }
    if ((UnityEngine.Object) this.m_HeroInfoTime != (UnityEngine.Object) null && ((Behaviour) this.m_HeroInfoTime).enabled)
    {
      ((Behaviour) this.m_HeroInfoTime).enabled = false;
      ((Behaviour) this.m_HeroInfoTime).enabled = true;
    }
    if ((UnityEngine.Object) this.m_HeroInfoCount != (UnityEngine.Object) null && ((Behaviour) this.m_HeroInfoCount).enabled)
    {
      ((Behaviour) this.m_HeroInfoCount).enabled = false;
      ((Behaviour) this.m_HeroInfoCount).enabled = true;
    }
    for (int index = 0; index < this.m_HeroInfoText.Length; ++index)
    {
      if ((UnityEngine.Object) this.m_HeroInfoText[index] != (UnityEngine.Object) null && ((Behaviour) this.m_HeroInfoText[index]).enabled)
      {
        ((Behaviour) this.m_HeroInfoText[index]).enabled = false;
        ((Behaviour) this.m_HeroInfoText[index]).enabled = true;
      }
    }
    for (int index = 0; index < this.m_AutoSelectText.Length; ++index)
    {
      if (this.m_AutoSelectText != null && (UnityEngine.Object) this.m_AutoSelectText[index] != (UnityEngine.Object) null && ((Behaviour) this.m_AutoSelectText[index]).enabled)
      {
        ((Behaviour) this.m_AutoSelectText[index]).enabled = false;
        ((Behaviour) this.m_AutoSelectText[index]).enabled = true;
      }
    }
    if (!((UnityEngine.Object) this.m_OKTExt != (UnityEngine.Object) null) || !((Behaviour) this.m_OKTExt).enabled)
      return;
    ((Behaviour) this.m_OKTExt).enabled = false;
    ((Behaviour) this.m_OKTExt).enabled = true;
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
      if (num2 <= 0U)
        return;
      if (num2 % 60U == 0U)
        CStr.IntToFormat((long) (int) (num2 / 60U));
      else
        CStr.IntToFormat((long) ((int) (num2 / 60U) + 1));
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
      if (num1 <= 0U)
        return;
      if (num1 % 60U == 0U)
        CStr.IntToFormat((long) (int) (num1 / 60U));
      else
        CStr.IntToFormat((long) ((int) (num1 / 60U) + 1));
      CStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17133U));
    }
  }

  private uint GetMaxLevelExp(ushort petID, byte nowLv, uint nowExp, byte maxLv)
  {
    PetData petData = this.PetMgr.FindPetData(petID);
    if (petData == null)
      return 0;
    PetTbl recordByKey = this.PetMgr.PetTable.GetRecordByKey(petID);
    uint num = 0;
    maxLv = (byte) Mathf.Clamp((int) maxLv, 2, 59);
    for (byte Level = nowLv; (int) Level <= (int) maxLv; ++Level)
      num += this.PetMgr.GetNeedExp(Level, recordByKey.Rare);
    uint maxLevelExp = num - nowExp;
    if (petData != null && (int) petData.GetMaxLevel() == (int) maxLv && maxLv != (byte) 60)
      --maxLevelExp;
    return maxLevelExp;
  }

  private uint GetCanTrainTime(uint MaxLevelExp, uint totalExp, uint nowTime)
  {
    if (MaxLevelExp >= totalExp)
      return nowTime;
    double expPerMinute = this.GetExpPerMinute();
    if (expPerMinute <= 0.0)
      return 0;
    uint max = (uint) ((double) MaxLevelExp / expPerMinute * 60.0);
    return (uint) Mathf.Clamp((float) max, 1f, (float) max);
  }

  private enum EAutoState
  {
    AutoState,
    ClearnState,
  }

  private enum ECStrID
  {
    PetInfoLv,
    PetInfoExpAddition,
    PetInfoHeroExp,
    PetInfoHeroTime,
    HeroInfoHeroNum,
    HeroInfoHeroExp,
    HeroInfoHeroTime,
    HeroInfoText1,
    HeroInfoText2,
    HeroInfoText3,
    HeroInfoText4,
    HeroInfoText5,
    HeroSelectTime,
    HeroSelectExp,
    PetInfoLvUp,
    PetInfoLvUp2,
    Max,
  }

  private enum EUIType
  {
    Pet,
    Hero,
    Max,
  }

  private enum EPetSelect
  {
    BgPanel,
    SelectCountPanel,
    ScrollPanel,
    Item,
    InfoPanel,
    ExiteBtn,
  }

  private enum EBtnID
  {
    SwitchHeroType,
    AutoSelectHero,
    OK,
    ItemSelect,
    ExitBtn,
    ExpHint,
    TimeHint,
    HeroSelectLeft,
    HeroSelectRight,
    SkillIconHint,
    PetInfoSkillHint1,
    PetInfoSkillHint2,
    PetInfoSkillHint3,
    PetInfoOverTime,
  }

  private enum EMsgBox
  {
    OverTimer,
    NoSelectHero,
    NeedEvo,
  }

  public enum EItemIdx
  {
    Left,
    Right,
    Max,
  }

  public enum EIconType
  {
    None = 0,
    Lock = 1,
    Training = 2,
    Select = 4,
    LockLimit = 8,
  }

  public struct ESelectItem
  {
    public const byte NoneSelect = 255;
    public byte m_DataIdx;
    public UIPetSelect.EItemIdx m_ItemIdx;
    public ushort m_ID;

    public ESelectItem(UIPetSelect.EItemIdx idx)
    {
      this.m_DataIdx = byte.MaxValue;
      this.m_ItemIdx = idx;
      this.m_ID = (ushort) 0;
    }
  }

  private struct PetItem
  {
    private const byte NoneSelect = 255;
    private Transform m_MainTf;
    private Transform[] m_Transform;
    private UIButton[] m_Btn;
    private UIHIBtn[] m_HiBtn;
    private UIText[] m_Name;
    private UIText[] m_SliderText;
    private Image[] m_Slider;
    private Image[] m_Mask;
    private Image[][] m_StateIcon;
    private CString[] m_NameCStr;
    private CString[] m_ExpCStr;
    private UIPetSelect.EIconType[] m_IconType;
    private UISpritesArray m_Sp;
    private bool bHasInstance;

    public PetItem(Transform transform, UISpritesArray sp)
    {
      this.m_Sp = sp;
      this.m_MainTf = (Transform) null;
      this.m_Transform = (Transform[]) null;
      this.m_Btn = new UIButton[2];
      this.m_HiBtn = new UIHIBtn[2];
      this.m_Name = new UIText[2];
      this.m_SliderText = new UIText[2];
      this.m_Slider = new Image[2];
      this.m_Mask = new Image[2];
      this.m_StateIcon = new Image[2][];
      this.m_StateIcon[0] = new Image[4];
      this.m_StateIcon[1] = new Image[4];
      this.m_NameCStr = new CString[2];
      this.m_ExpCStr = new CString[2];
      this.m_NameCStr[0] = StringManager.Instance.SpawnString();
      this.m_NameCStr[1] = StringManager.Instance.SpawnString();
      this.m_ExpCStr[0] = StringManager.Instance.SpawnString();
      this.m_ExpCStr[1] = StringManager.Instance.SpawnString();
      this.m_IconType = new UIPetSelect.EIconType[2];
      this.m_IconType[0] = UIPetSelect.EIconType.None;
      this.m_IconType[1] = UIPetSelect.EIconType.None;
      this.bHasInstance = false;
    }

    public bool HasInstance => this.bHasInstance;

    private void InitHiBtn()
    {
      GUIManager.Instance.InitianHeroItemImg(((Component) this.m_HiBtn[0]).transform, eHeroOrItem.Pet, (ushort) 0, (byte) 1, (byte) 0, 1, bAutoShowHint: false);
      ((Component) this.m_HiBtn[0]).transform.gameObject.AddComponent<IgnoreRaycast>();
      GUIManager.Instance.InitianHeroItemImg(((Component) this.m_HiBtn[1]).transform, eHeroOrItem.Pet, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
      ((Component) this.m_HiBtn[1]).transform.gameObject.AddComponent<IgnoreRaycast>();
    }

    public void Init(
      Transform mainTf,
      Transform[] trans,
      UIButton[] btn,
      UIHIBtn[] hiBtn,
      UIText[] name,
      UIText[] sliderText,
      Image[] slider,
      Image[] mask,
      Image[][] stateIcon)
    {
      this.m_MainTf = mainTf;
      this.m_Transform = trans;
      this.m_Btn = btn;
      this.m_HiBtn = hiBtn;
      this.m_Name = name;
      this.m_Slider = slider;
      this.m_StateIcon = stateIcon;
      this.m_SliderText = sliderText;
      this.m_Mask = mask;
      this.InitHiBtn();
      this.bHasInstance = true;
    }

    public void SetName(UIPetSelect.EItemIdx idx, ushort id)
    {
      if (this.m_Name == null || !((UnityEngine.Object) this.m_Name[(int) idx] != (UnityEngine.Object) null))
        return;
      this.m_Name[(int) idx].text = PetManager.Instance.GetPetNameByID(id);
    }

    public void SetHiBtn(UIPetSelect.EItemIdx idx, ushort id, byte circle = 0, byte rank = 0, int lv = 0)
    {
      GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_HiBtn[(int) idx]).transform, eHeroOrItem.Pet, id, circle, (byte) 0, lv);
    }

    public void SetSlider(UIPetSelect.EItemIdx idx, uint value, uint Max, byte petLv, byte maxLv)
    {
      float num1 = 0.0f;
      float num2 = 151f;
      Vector2 vector2 = Vector2.zero;
      if ((UnityEngine.Object) this.m_Slider[(int) idx] != (UnityEngine.Object) null)
      {
        vector2 = ((Graphic) this.m_Slider[(int) idx]).rectTransform.sizeDelta;
        num1 = Mathf.Clamp((float) value / (float) Max, 0.0f, 1f);
        vector2.x = num1 * num2;
        ((Graphic) this.m_Slider[(int) idx]).rectTransform.sizeDelta = vector2;
      }
      if (this.m_SliderText != null && (UnityEngine.Object) this.m_SliderText[(int) idx] != (UnityEngine.Object) null)
      {
        this.m_ExpCStr[(int) idx].ClearString();
        this.m_ExpCStr[(int) idx].IntToFormat((long) (int) ((double) num1 * 100.0));
        if (GUIManager.Instance.IsArabic)
          this.m_ExpCStr[(int) idx].AppendFormat("%{0}");
        else
          this.m_ExpCStr[(int) idx].AppendFormat("{0}%");
        this.m_SliderText[(int) idx].text = this.m_ExpCStr[(int) idx].ToString();
        this.m_SliderText[(int) idx].SetAllDirty();
        this.m_SliderText[(int) idx].cachedTextGenerator.Invalidate();
        this.m_SliderText[(int) idx].cachedTextGeneratorForLayout.Invalidate();
      }
      if (petLv == (byte) 60)
      {
        this.m_SliderText[(int) idx].text = DataManager.Instance.mStringTable.GetStringByID(1507U);
        this.m_SliderText[(int) idx].SetAllDirty();
        this.m_SliderText[(int) idx].cachedTextGenerator.Invalidate();
        this.m_SliderText[(int) idx].cachedTextGeneratorForLayout.Invalidate();
        vector2.x = num2;
        ((Graphic) this.m_Slider[(int) idx]).rectTransform.sizeDelta = vector2;
        this.m_Slider[(int) idx].sprite = this.m_Sp.GetSprite(1);
      }
      else if ((int) petLv >= (int) maxLv && value >= Max - 1U)
      {
        this.m_SliderText[(int) idx].text = DataManager.Instance.mStringTable.GetStringByID(16051U);
        this.m_SliderText[(int) idx].SetAllDirty();
        this.m_SliderText[(int) idx].cachedTextGenerator.Invalidate();
        this.m_SliderText[(int) idx].cachedTextGeneratorForLayout.Invalidate();
      }
      else
        this.m_Slider[(int) idx].sprite = this.m_Sp.GetSprite(0);
    }

    public void SetBtnID(UIPetSelect.EItemIdx idx, int dataIdx, int panelObjectIdx)
    {
      this.m_Btn[(int) idx].m_BtnID2 = (int) idx;
      this.m_Btn[(int) idx].m_BtnID3 = dataIdx;
      this.m_Btn[(int) idx].m_BtnID4 = panelObjectIdx;
    }

    public void ClearIcon(UIPetSelect.EItemIdx idx)
    {
      this.m_IconType[(int) idx] = UIPetSelect.EIconType.None;
    }

    public void AddIcon(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
    {
      this.m_IconType[(int) idx] |= type;
      ((Behaviour) this.m_StateIcon[(int) idx][0]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.LockLimit) == UIPetSelect.EIconType.LockLimit;
      ((Behaviour) this.m_StateIcon[(int) idx][1]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Training) == UIPetSelect.EIconType.Training;
      ((Behaviour) this.m_StateIcon[(int) idx][2]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select;
      ((Behaviour) this.m_Mask[(int) idx]).enabled = this.m_IconType[(int) idx] != UIPetSelect.EIconType.None;
    }

    public void RemoveIcon(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
    {
      if (this.m_IconType == null)
        return;
      this.m_IconType[(int) idx] &= ~type;
      ((Behaviour) this.m_StateIcon[(int) idx][0]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.LockLimit) == UIPetSelect.EIconType.LockLimit;
      ((Behaviour) this.m_StateIcon[(int) idx][1]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Training) == UIPetSelect.EIconType.Training;
      ((Behaviour) this.m_StateIcon[(int) idx][2]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select;
      ((Behaviour) this.m_Mask[(int) idx]).enabled = this.m_IconType[(int) idx] != UIPetSelect.EIconType.None;
    }

    public void SetIcon(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
    {
      if (this.m_IconType == null)
        return;
      this.m_IconType[(int) idx] = type;
      ((Behaviour) this.m_StateIcon[(int) idx][0]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Lock) == UIPetSelect.EIconType.Lock;
      ((Behaviour) this.m_StateIcon[(int) idx][0]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.LockLimit) == UIPetSelect.EIconType.LockLimit;
      ((Behaviour) this.m_StateIcon[(int) idx][1]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Training) == UIPetSelect.EIconType.Training;
      ((Behaviour) this.m_StateIcon[(int) idx][2]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select;
      ((Behaviour) this.m_Mask[(int) idx]).enabled = this.m_IconType[(int) idx] != UIPetSelect.EIconType.None;
    }

    public void OnSelect(UIPetSelect.EItemIdx idx)
    {
      if (this.m_IconType == null)
        return;
      bool flag = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select;
      if (flag)
        this.m_IconType[(int) idx] &= ~UIPetSelect.EIconType.Select;
      else
        this.m_IconType[(int) idx] |= UIPetSelect.EIconType.Select;
      ((Behaviour) this.m_StateIcon[(int) idx][2]).enabled = !flag;
      ((Behaviour) this.m_Mask[(int) idx]).enabled = this.m_IconType[(int) idx] != UIPetSelect.EIconType.None;
    }

    public void Show(bool bShow)
    {
      if ((UnityEngine.Object) this.m_MainTf != (UnityEngine.Object) null)
        this.m_MainTf.gameObject.SetActive(bShow);
      if ((bool) (UnityEngine.Object) this.m_Transform[0])
        this.m_Transform[0].gameObject.SetActive(bShow);
      if (!(bool) (UnityEngine.Object) this.m_Transform[1])
        return;
      this.m_Transform[1].gameObject.SetActive(bShow);
    }

    public void OnlyShowLeft(bool onlyLeft)
    {
      if ((bool) (UnityEngine.Object) this.m_Transform[1])
        this.m_Transform[1].gameObject.SetActive(!onlyLeft);
      if (!(bool) (UnityEngine.Object) this.m_Transform[0])
        return;
      this.m_Transform[0].gameObject.SetActive(true);
    }

    public void DeSpawn()
    {
      if (this.m_NameCStr[0] != null)
      {
        StringManager.Instance.DeSpawnString(this.m_NameCStr[0]);
        this.m_NameCStr[0] = (CString) null;
      }
      if (this.m_NameCStr[1] != null)
      {
        StringManager.Instance.DeSpawnString(this.m_NameCStr[1]);
        this.m_NameCStr[1] = (CString) null;
      }
      if (this.m_ExpCStr[0] != null)
      {
        StringManager.Instance.DeSpawnString(this.m_NameCStr[0]);
        this.m_ExpCStr[0] = (CString) null;
      }
      if (this.m_ExpCStr[1] == null)
        return;
      StringManager.Instance.DeSpawnString(this.m_NameCStr[1]);
      this.m_ExpCStr[1] = (CString) null;
    }

    public void RefreshFontTexture()
    {
      if ((UnityEngine.Object) this.m_HiBtn[0] != (UnityEngine.Object) null && ((Behaviour) this.m_HiBtn[0]).enabled)
        this.m_HiBtn[0].Refresh_FontTexture();
      if ((UnityEngine.Object) this.m_HiBtn[1] != (UnityEngine.Object) null && ((Behaviour) this.m_HiBtn[1]).enabled)
        this.m_HiBtn[1].Refresh_FontTexture();
      if ((UnityEngine.Object) this.m_Name[0] != (UnityEngine.Object) null && ((Behaviour) this.m_Name[0]).enabled)
      {
        ((Behaviour) this.m_Name[0]).enabled = false;
        ((Behaviour) this.m_Name[0]).enabled = true;
      }
      if (this.m_Name != null && ((Behaviour) this.m_Name[1]).enabled)
      {
        ((Behaviour) this.m_Name[1]).enabled = false;
        ((Behaviour) this.m_Name[1]).enabled = true;
      }
      if ((UnityEngine.Object) this.m_SliderText[0] != (UnityEngine.Object) null && ((Behaviour) this.m_SliderText[0]).enabled)
      {
        ((Behaviour) this.m_SliderText[0]).enabled = false;
        ((Behaviour) this.m_SliderText[0]).enabled = true;
      }
      if (!((UnityEngine.Object) this.m_SliderText[1] != (UnityEngine.Object) null) || !((Behaviour) this.m_SliderText[1]).enabled)
        return;
      ((Behaviour) this.m_SliderText[1]).enabled = false;
      ((Behaviour) this.m_SliderText[1]).enabled = true;
    }
  }

  private struct HeroItem
  {
    private Transform m_MainTf;
    private UIButton[] m_Btn;
    private Transform[] m_Transform;
    private UIHIBtn[] m_HiBtn;
    private UIText[] m_AdditionalTimeText;
    private Image[] m_Mask;
    private Image[][] m_StateIcon;
    private CString[] m_TimeTextCStr;
    private UIPetSelect.EIconType[] m_IconType;
    private bool bHasInstance;

    public HeroItem(Transform transform = null)
    {
      this.m_MainTf = (Transform) null;
      this.m_Transform = new Transform[2];
      this.m_Btn = new UIButton[2];
      this.m_HiBtn = new UIHIBtn[2];
      this.m_AdditionalTimeText = new UIText[2];
      this.m_Mask = new Image[2];
      this.m_StateIcon = new Image[2][];
      this.m_StateIcon[0] = new Image[4];
      this.m_StateIcon[1] = new Image[4];
      this.m_TimeTextCStr = new CString[2];
      this.m_TimeTextCStr[0] = StringManager.Instance.SpawnString();
      this.m_TimeTextCStr[1] = StringManager.Instance.SpawnString();
      this.m_IconType = new UIPetSelect.EIconType[2];
      this.m_IconType[0] = UIPetSelect.EIconType.None;
      this.m_IconType[1] = UIPetSelect.EIconType.None;
      this.bHasInstance = false;
    }

    public bool HasInstance => this.bHasInstance;

    private void InitHiBtn()
    {
      GUIManager.Instance.InitianHeroItemImg(((Component) this.m_HiBtn[0]).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
      ((Component) this.m_HiBtn[0]).transform.gameObject.AddComponent<IgnoreRaycast>();
      GUIManager.Instance.InitianHeroItemImg(((Component) this.m_HiBtn[1]).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
      ((Component) this.m_HiBtn[1]).transform.gameObject.AddComponent<IgnoreRaycast>();
    }

    public void Init(
      Transform mainTf,
      Transform[] trans,
      UIButton[] btn,
      UIHIBtn[] hiBtn,
      UIText[] additionalTimeText,
      Image[] mask,
      Image[][] stateIcon)
    {
      this.m_MainTf = mainTf;
      this.m_Transform = trans;
      this.m_Btn = btn;
      this.m_HiBtn = hiBtn;
      this.m_AdditionalTimeText = additionalTimeText;
      this.m_Mask = mask;
      this.m_StateIcon = stateIcon;
      this.m_TimeTextCStr[0] = StringManager.Instance.SpawnString();
      this.m_TimeTextCStr[1] = StringManager.Instance.SpawnString();
      this.InitHiBtn();
      this.bHasInstance = true;
    }

    public void SetHiBtn(UIPetSelect.EItemIdx idx, ushort id, byte circle = 0, byte rank = 0, int lv = 0)
    {
      GUIManager.Instance.ChangeHeroItemImg(((Component) this.m_HiBtn[(int) idx]).transform, eHeroOrItem.Hero, id, circle, (byte) 0, lv);
    }

    public void SetBtnID(UIPetSelect.EItemIdx idx, int dataIdx, int panelObjectIdx)
    {
      this.m_Btn[(int) idx].m_BtnID2 = (int) idx;
      this.m_Btn[(int) idx].m_BtnID3 = dataIdx;
      this.m_Btn[(int) idx].m_BtnID4 = panelObjectIdx;
    }

    public void SetTrainTime(UIPetSelect.EItemIdx idx, uint minute)
    {
      this.m_TimeTextCStr[(int) idx].ClearString();
      UIPetSelect.GetTimeInfoString(this.m_TimeTextCStr[(int) idx], minute * 60U);
      this.m_AdditionalTimeText[(int) idx].text = this.m_TimeTextCStr[(int) idx].ToString();
      this.m_AdditionalTimeText[(int) idx].SetAllDirty();
      this.m_AdditionalTimeText[(int) idx].cachedTextGenerator.Invalidate();
    }

    public void ClearIcon(UIPetSelect.EItemIdx idx)
    {
      this.m_IconType[(int) idx] = UIPetSelect.EIconType.None;
    }

    public void AddIcon(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
    {
      this.m_IconType[(int) idx] |= type;
      ((Behaviour) this.m_StateIcon[(int) idx][0]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Lock) == UIPetSelect.EIconType.Lock;
      ((Behaviour) this.m_StateIcon[(int) idx][0]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.LockLimit) == UIPetSelect.EIconType.LockLimit;
      ((Behaviour) this.m_StateIcon[(int) idx][1]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Training) == UIPetSelect.EIconType.Training;
      ((Behaviour) this.m_StateIcon[(int) idx][2]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select;
      ((Behaviour) this.m_Mask[(int) idx]).enabled = this.m_IconType[(int) idx] != UIPetSelect.EIconType.None;
    }

    public void RemoveIcon(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
    {
      this.m_IconType[(int) idx] &= ~type;
      ((Behaviour) this.m_StateIcon[(int) idx][0]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Lock) == UIPetSelect.EIconType.Lock;
      ((Behaviour) this.m_StateIcon[(int) idx][0]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.LockLimit) == UIPetSelect.EIconType.LockLimit;
      ((Behaviour) this.m_StateIcon[(int) idx][1]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Training) == UIPetSelect.EIconType.Training;
      ((Behaviour) this.m_StateIcon[(int) idx][2]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select;
      ((Behaviour) this.m_Mask[(int) idx]).enabled = this.m_IconType[(int) idx] != UIPetSelect.EIconType.None;
    }

    public void SetIcon(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
    {
      this.m_IconType[(int) idx] = type;
      ((Behaviour) this.m_StateIcon[(int) idx][0]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Lock) == UIPetSelect.EIconType.Lock;
      ((Behaviour) this.m_StateIcon[(int) idx][0]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.LockLimit) == UIPetSelect.EIconType.LockLimit;
      ((Behaviour) this.m_StateIcon[(int) idx][1]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Training) == UIPetSelect.EIconType.Training;
      ((Behaviour) this.m_StateIcon[(int) idx][2]).enabled = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select;
      ((Behaviour) this.m_Mask[(int) idx]).enabled = this.m_IconType[(int) idx] != UIPetSelect.EIconType.None;
    }

    public void OnSelect(UIPetSelect.EItemIdx idx)
    {
      bool flag = (this.m_IconType[(int) idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select;
      if (flag)
        this.m_IconType[(int) idx] &= ~UIPetSelect.EIconType.Select;
      else
        this.m_IconType[(int) idx] |= UIPetSelect.EIconType.Select;
      ((Behaviour) this.m_StateIcon[(int) idx][2]).enabled = !flag;
      ((Behaviour) this.m_Mask[(int) idx]).enabled = this.m_IconType[(int) idx] != UIPetSelect.EIconType.None;
    }

    public void Show(bool bShow)
    {
      if ((bool) (UnityEngine.Object) this.m_MainTf)
        this.m_MainTf.gameObject.SetActive(bShow);
      if ((bool) (UnityEngine.Object) this.m_Transform[0])
        this.m_Transform[0].gameObject.SetActive(bShow);
      if (!(bool) (UnityEngine.Object) this.m_Transform[1])
        return;
      this.m_Transform[1].gameObject.SetActive(bShow);
    }

    public void OnlyShowLeft(bool onlyLeft)
    {
      if ((bool) (UnityEngine.Object) this.m_Transform[1])
        this.m_Transform[1].gameObject.SetActive(!onlyLeft);
      if (!(bool) (UnityEngine.Object) this.m_Transform[0])
        return;
      this.m_Transform[0].gameObject.SetActive(true);
    }

    public void DeSpawn()
    {
      if (this.m_TimeTextCStr[0] != null)
      {
        StringManager.Instance.DeSpawnString(this.m_TimeTextCStr[0]);
        this.m_TimeTextCStr[0] = (CString) null;
      }
      if (this.m_TimeTextCStr[1] == null)
        return;
      StringManager.Instance.DeSpawnString(this.m_TimeTextCStr[1]);
      this.m_TimeTextCStr[1] = (CString) null;
    }

    public void RefreshFontTexture()
    {
      if ((UnityEngine.Object) this.m_HiBtn[0] != (UnityEngine.Object) null && ((Behaviour) this.m_HiBtn[0]).enabled)
        this.m_HiBtn[0].Refresh_FontTexture();
      if ((UnityEngine.Object) this.m_HiBtn[1] != (UnityEngine.Object) null && ((Behaviour) this.m_HiBtn[1]).enabled)
        this.m_HiBtn[1].Refresh_FontTexture();
      if ((UnityEngine.Object) this.m_AdditionalTimeText[0] != (UnityEngine.Object) null && ((Behaviour) this.m_AdditionalTimeText[0]).enabled)
      {
        ((Behaviour) this.m_AdditionalTimeText[0]).enabled = false;
        ((Behaviour) this.m_AdditionalTimeText[0]).enabled = true;
      }
      if (!((UnityEngine.Object) this.m_AdditionalTimeText[1] != (UnityEngine.Object) null) || !((Behaviour) this.m_AdditionalTimeText[1]).enabled)
        return;
      ((Behaviour) this.m_AdditionalTimeText[1]).enabled = false;
      ((Behaviour) this.m_AdditionalTimeText[1]).enabled = true;
    }
  }

  private struct LinelItem
  {
    private Transform m_Transform;
    private UIText m_Content;
    private bool bHasInstance;

    public LinelItem(Transform transform = null)
    {
      this.m_Transform = transform;
      this.m_Content = (UIText) null;
      this.bHasInstance = false;
    }

    public bool HasInstance => this.bHasInstance;

    public void Init(Transform trans, UIText content)
    {
      this.m_Transform = trans;
      this.m_Content = content;
      this.m_Content.text = DataManager.Instance.mStringTable.GetStringByID(17097U);
      this.bHasInstance = true;
    }

    public void Show(bool bShow, bool bPet = true)
    {
      this.m_Transform.gameObject.SetActive(bShow);
      if (!bShow)
        return;
      if (bPet)
        this.m_Content.text = DataManager.Instance.mStringTable.GetStringByID(17097U);
      else
        this.m_Content.text = DataManager.Instance.mStringTable.GetStringByID(17103U);
    }

    public void RefreshFontTexture()
    {
      if (!((UnityEngine.Object) this.m_Content != (UnityEngine.Object) null) || !((Behaviour) this.m_Content).enabled)
        return;
      ((Behaviour) this.m_Content).enabled = false;
      ((Behaviour) this.m_Content).enabled = true;
    }
  }

  private struct SSrollPanelItem
  {
    public UIPetSelect.SSrollPanelItem.EItemType m_ItemType;
    public UIPetSelect.PetItem m_PetItem;
    public UIPetSelect.HeroItem m_HeroItem;
    public UIPetSelect.LinelItem m_LineItem;
    private UISpritesArray m_Sp;

    public SSrollPanelItem(UIPetSelect.SSrollPanelItem.EItemType type, UISpritesArray sp)
    {
      this.m_Sp = sp;
      this.m_ItemType = type;
      this.m_PetItem = new UIPetSelect.PetItem((Transform) null, this.m_Sp);
      this.m_HeroItem = new UIPetSelect.HeroItem();
      this.m_LineItem = new UIPetSelect.LinelItem();
    }

    public void SetType(UIPetSelect.SSrollPanelItem.EItemType type, bool bPetLine = true)
    {
      if (type == UIPetSelect.SSrollPanelItem.EItemType.PetType)
      {
        this.m_PetItem.Show(true);
        this.m_HeroItem.Show(false);
        this.m_LineItem.Show(false);
      }
      else if (type == UIPetSelect.SSrollPanelItem.EItemType.HeroType)
      {
        this.m_PetItem.Show(false);
        this.m_HeroItem.Show(true);
        this.m_LineItem.Show(false);
      }
      else
      {
        this.m_PetItem.Show(false);
        this.m_HeroItem.Show(false);
        if (bPetLine)
          this.m_LineItem.Show(true);
        else
          this.m_LineItem.Show(true, false);
      }
    }

    public enum EItemType
    {
      PetType,
      HeroType,
      LineType,
    }
  }

  public class SScrollData
  {
    public bool bLineType;
    public bool bShowOnlyLeft;
    public bool bDataPadding;
    public ushort[] m_ID;
    public int[] m_DataIdx;
    public UIPetSelect.EIconType[] m_EIconType;
    public uint[] m_TrainTime;
    public byte[] m_Color;
    private bool bHasInstance;

    public SScrollData()
    {
      this.bLineType = false;
      this.bShowOnlyLeft = true;
      this.bDataPadding = false;
      this.m_DataIdx = new int[2];
      this.m_ID = new ushort[2];
      this.m_EIconType = new UIPetSelect.EIconType[2];
      this.m_TrainTime = new uint[2];
      this.m_Color = new byte[2];
      this.bHasInstance = true;
    }

    public bool HasInstance => this.bHasInstance;

    public void Empty()
    {
      this.bLineType = false;
      this.bShowOnlyLeft = true;
      this.bDataPadding = false;
      Array.Clear((Array) this.m_DataIdx, 0, 2);
      Array.Clear((Array) this.m_ID, 0, 2);
      Array.Clear((Array) this.m_EIconType, 0, 2);
      Array.Clear((Array) this.m_TrainTime, 0, 2);
      this.m_Color[0] = (byte) 0;
      this.m_Color[1] = (byte) 0;
    }

    public UIPetSelect.ESelectItem OnSelect(UIPetSelect.EItemIdx idx, byte dataIdx)
    {
      UIPetSelect.ESelectItem eselectItem = new UIPetSelect.ESelectItem(UIPetSelect.EItemIdx.Left);
      if (this.m_EIconType == null)
        return eselectItem;
      if ((this.m_EIconType[(int) idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select)
      {
        this.m_EIconType[(int) idx] &= ~UIPetSelect.EIconType.Select;
        eselectItem.m_DataIdx = byte.MaxValue;
        eselectItem.m_ID = (ushort) 0;
      }
      else
      {
        this.m_EIconType[(int) idx] |= UIPetSelect.EIconType.Select;
        eselectItem.m_DataIdx = dataIdx;
        eselectItem.m_ItemIdx = idx;
        eselectItem.m_ID = this.m_ID[(int) idx];
      }
      return eselectItem;
    }

    public void RemoveSelectIcon(UIPetSelect.EItemIdx idx)
    {
      if (this.m_EIconType == null)
        return;
      this.m_EIconType[(int) idx] &= ~UIPetSelect.EIconType.Select;
    }

    public void RemoveIcon(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
    {
      if (this.m_EIconType == null)
        return;
      this.m_EIconType[(int) idx] &= ~UIPetSelect.EIconType.Select;
    }

    public ushort GetPetSelectID() => 0;

    public ushort GetHeroSelectID(UIPetSelect.EItemIdx idx)
    {
      ushort heroSelectId = 0;
      if (this.m_EIconType != null && this.m_ID != null && (this.m_EIconType[(int) idx] & UIPetSelect.EIconType.Select) == UIPetSelect.EIconType.Select)
        heroSelectId = this.m_ID[(int) idx];
      return heroSelectId;
    }

    public bool CheckIconType(UIPetSelect.EItemIdx idx, UIPetSelect.EIconType type)
    {
      return this.m_EIconType != null && (this.m_EIconType[(int) idx] & type) == type;
    }
  }
}
