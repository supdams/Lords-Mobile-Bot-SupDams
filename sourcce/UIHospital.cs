// Decompiled with JetBrains decompiler
// Type: UIHospital
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIHospital : 
  GUIWindow,
  IBuildingWindowType,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUICalculatorHandler,
  IUTimeBarOnTimer,
  IUIUnitRSliderHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private UIButton btn_ALL;
  private UIButton btn_Treatment;
  private UIButton btn_TreatmentCompleted;
  private UIButton btn_RD;
  private UIButton btn_EXIT;
  private UIButton btn_Disband_Exit;
  private UIButton btn_Disband;
  private UIButton[] btn_Item = new UIButton[5];
  private UIButton[] btn_ItemInput = new UIButton[5];
  private Image BG;
  private Image Img_Base;
  private Image Img_Lock;
  private Image Img_Exit;
  private Image Img_Treatment;
  private Image ImgDisbandblack;
  private Image ImgDisband_Item;
  private Image[] Img_Slider = new Image[3];
  private Image[] Img_Soldier_Item = new Image[5];
  private Image[] Img_Soldier_ItemFrame = new Image[5];
  private ScrollPanel m_ScrollPanel;
  private CScrollRect m_ScrollRect;
  private DemandResources m_DResources;
  private UnitResourcesSlider m_UnitRS;
  private UnitResourcesSlider m_DisbandSlider;
  private UnitResourcesSlider[] m_UnitRS_Item = new UnitResourcesSlider[5];
  private UIText text_ALL;
  private UIText text_Treatment;
  private UIText text_TreatmentCompleted;
  private UIText text_Gemstone;
  private UIText text_Time;
  private UIText text_Slider;
  private UIText text_NoNeedTreatment;
  private UIText text_Treatmenting;
  private UIText text_TrapTotal;
  private UIText text_Disband_Name;
  private UIText text_Disband_Num;
  private UIText text_Disband_Title;
  private UIText text_Disband;
  private UIText[] text_TrapNum = new UIText[2];
  private UIText[] text_InjuredTroops = new UIText[4];
  private UIText[] text_Soldier_Item = new UIText[5];
  private UIText[] text_tmpStr = new UIText[5];
  private UIText[] text_timeBar = new UIText[2];
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Tmp2;
  private RectTransform DisbandSliderRT;
  public BuildTypeData buildTypeData;
  private BuildingWindow baseBuild;
  private StringBuilder tmpString = new StringBuilder();
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private SoldierData tmpSD;
  private UITimeBar timeBar;
  private uint HospitalNum;
  private uint InjuredNum;
  private long TreatmentNum;
  public UnitResources_H[] m_UnitResources = new UnitResources_H[16];
  private long[] m_Soldier = new long[16];
  private uint[] m_SoldierMax = new uint[16];
  private string[] m_SoldierName = new string[16];
  private Sprite[] m_SoldierSprite = new Sprite[16];
  private Sprite[] m_SoldierSpriteFrame = new Sprite[16];
  private byte[] ShowListIndex = new byte[16];
  private bool bTreatmenting;
  private bool bNOInjured = true;
  private bool bClear;
  private Material FrameMaterial;
  private Material m_BW;
  private Material m_Arms;
  private Material m_Mat;
  private RectTransform tmpRC;
  private Image tmpimg;
  private UIText tmptext;
  private Door door;
  private string AssetName;
  private string AssetName1;
  private string AssetName_D;
  private int B_ID;
  private List<float> tmplist = new List<float>();
  private long begin;
  private long target;
  private long notify;
  private int mTreatmentCount;
  private int Count = 12;
  private ushort buildID;
  private float tmpEGA = 1f;
  private float tmpEGA_T = 1f;
  private float[] Pos = new float[5];
  private float[] Width = new float[5];
  private uint mTrapTreatmentMax;
  private uint needDiamond;
  private byte mDisband_Kind;
  private byte mDisband_Rank;
  private CString tmpStr = StringManager.Instance.StaticString1024();
  private CString Cstr;
  private CString Cstr_SliderQty;
  private CString Cstr_Gemstone;
  private CString Cstr_Time;
  private CString Cstr_TimeBar;
  private CString Cstr_Msg;
  private CString[] Cstr_TrapNum = new CString[2];
  private CString[] Cstr_InjuredTroop = new CString[2];
  private CString[] Cstr_SliderMaxQty = new CString[5];
  private CString[] Cstr_ItemSliderQty = new CString[5];
  private float tmpEGA_Cost = 1f;

  public void OnTypeChange(e_BuildType buildType)
  {
    if (buildType == e_BuildType.Normal || buildType == e_BuildType.SelfUpgradeing || buildType == e_BuildType.SelfBackOuting)
    {
      ((Component) this.BG).gameObject.SetActive(true);
      this.m_DResources.gameObject.SetActive(true);
      ((Component) this.btn_ALL).gameObject.SetActive(true);
      ((Component) this.btn_Treatment).gameObject.SetActive(true);
      ((Component) this.btn_TreatmentCompleted).gameObject.SetActive(true);
      ((Component) this.Img_Slider[0]).gameObject.SetActive(true);
      if (this.bTreatmenting)
        ((Component) this.Img_Treatment).gameObject.SetActive(true);
      if (this.bNOInjured)
      {
        this.m_ScrollPanel.gameObject.SetActive(false);
        ((Component) this.text_NoNeedTreatment).gameObject.SetActive(true);
        this.btn_ALL.ForTextChange(e_BtnType.e_ChangeText);
        this.btn_Treatment.ForTextChange(e_BtnType.e_ChangeText);
      }
      else
      {
        this.m_ScrollPanel.gameObject.SetActive(true);
        ((Component) this.text_NoNeedTreatment).gameObject.SetActive(false);
        int num = (int) this.CheckAllMax(false);
        this.SetDRformURS(false);
        if (this.buildID == (ushort) 7)
        {
          this.HospitalNum = this.GetHospitalMaxCapacity();
          ((Component) this.text_InjuredTroops[1]).gameObject.SetActive(true);
          ((Component) this.text_InjuredTroops[2]).gameObject.SetActive(true);
          this.Cstr_InjuredTroop[0].ClearString();
          this.Cstr_InjuredTroop[0].IntToFormat((long) this.InjuredNum, bNumber: true);
          this.Cstr_InjuredTroop[0].AppendFormat("{0}");
          this.text_InjuredTroops[1].text = this.Cstr_InjuredTroop[0].ToString();
          this.text_InjuredTroops[1].SetAllDirty();
          this.text_InjuredTroops[1].cachedTextGenerator.Invalidate();
          this.Cstr_InjuredTroop[1].ClearString();
          this.Cstr_InjuredTroop[1].IntToFormat((long) this.HospitalNum, bNumber: true);
          if (this.GUIM.IsArabic)
            this.Cstr_InjuredTroop[1].AppendFormat("{0} / ");
          else
            this.Cstr_InjuredTroop[1].AppendFormat(" / {0}");
          this.text_InjuredTroops[2].text = this.Cstr_InjuredTroop[1].ToString();
          this.text_InjuredTroops[2].SetAllDirty();
          this.text_InjuredTroops[2].cachedTextGenerator.Invalidate();
        }
        else
        {
          this.HospitalNum = this.GetTrapCapacity();
          this.Cstr_TrapNum[0].ClearString();
          this.Cstr_TrapNum[0].IntToFormat((long) this.DM.TrapHospitalTotal, bNumber: true);
          this.Cstr_TrapNum[0].AppendFormat("{0}");
          this.text_TrapNum[0].text = this.Cstr_TrapNum[0].ToString();
          this.text_TrapNum[0].SetAllDirty();
          this.text_TrapNum[0].cachedTextGenerator.Invalidate();
          this.Cstr_TrapNum[1].ClearString();
          this.Cstr_TrapNum[1].IntToFormat((long) this.HospitalNum, bNumber: true);
          if (this.GUIM.IsArabic)
            this.Cstr_TrapNum[1].AppendFormat("{0} / ");
          else
            this.Cstr_TrapNum[1].AppendFormat(" / {0}");
          this.text_TrapNum[1].text = this.Cstr_TrapNum[1].ToString();
          this.text_TrapNum[1].SetAllDirty();
          this.text_TrapNum[1].cachedTextGenerator.Invalidate();
        }
      }
    }
    else
    {
      this.m_ScrollRect.StopMovement();
      ((Component) this.BG).gameObject.SetActive(false);
      this.m_DResources.gameObject.SetActive(false);
      ((Component) this.btn_ALL).gameObject.SetActive(false);
      ((Component) this.btn_Treatment).gameObject.SetActive(false);
      ((Component) this.btn_TreatmentCompleted).gameObject.SetActive(false);
      this.m_ScrollPanel.gameObject.SetActive(false);
      ((Component) this.Img_Slider[0]).gameObject.SetActive(false);
      if (this.bTreatmenting)
        ((Component) this.Img_Treatment).gameObject.SetActive(false);
      ((Component) this.text_NoNeedTreatment).gameObject.SetActive(false);
    }
  }

  public void OnVauleChang(UnitResourcesSlider sender)
  {
    int id = sender.m_ID;
    bool bCheck = true;
    if (sender.Value < this.m_Soldier[id])
      bCheck = false;
    if (this.buildID == (ushort) 12 && (long) this.mTrapTreatmentMax < this.TreatmentNum - this.m_Soldier[id] + sender.Value && sender.Type == (byte) 1)
    {
      sender.Value = (long) this.mTrapTreatmentMax - this.TreatmentNum + this.m_Soldier[id];
      sender.m_slider.value = (double) sender.Value;
      this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(3755U), (ushort) byte.MaxValue);
    }
    else if (sender.Type == (byte) 1)
    {
      int btnId2 = sender.gameObject.transform.parent.GetComponent<ScrollPanelItem>().m_BtnID2;
      this.Cstr_ItemSliderQty[btnId2].ClearString();
      this.Cstr_ItemSliderQty[btnId2].IntToFormat(sender.Value, bNumber: true);
      this.Cstr_ItemSliderQty[btnId2].AppendFormat("{0}");
      sender.m_inputText.text = this.Cstr_ItemSliderQty[btnId2].ToString();
      sender.m_inputText.SetAllDirty();
      sender.m_inputText.cachedTextGenerator.Invalidate();
      this.m_Soldier[id] = sender.Value;
      this.DM.mExpeditionSoldierList[id] = (uint) this.m_Soldier[id];
      this.SetDRformURS(bCheck);
    }
    else
    {
      this.Cstr.ClearString();
      StringManager.IntToStr(this.Cstr, sender.Value, bNumber: true);
      sender.m_inputText.text = this.Cstr.ToString();
      sender.m_inputText.SetAllDirty();
      sender.m_inputText.cachedTextGenerator.Invalidate();
      if (sender.Value == 0L && this.btn_Disband.m_BtnType == e_BtnType.e_Normal)
      {
        this.btn_Disband.ForTextChange(e_BtnType.e_ChangeText);
      }
      else
      {
        if (this.btn_Disband.m_BtnType != e_BtnType.e_ChangeText)
          return;
        this.btn_Disband.ForTextChange(e_BtnType.e_Normal);
      }
    }
  }

  public void OnTextChang(UnitResourcesSlider sender)
  {
    int id = sender.m_ID;
    if (this.buildID == (ushort) 12 && (long) this.mTrapTreatmentMax < this.TreatmentNum - this.m_Soldier[id] + sender.Value && sender.Type == (byte) 1)
    {
      sender.Value = (long) this.mTrapTreatmentMax - this.TreatmentNum + this.m_Soldier[id];
      sender.m_slider.value = (double) sender.Value;
      this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(3755U), (ushort) byte.MaxValue);
    }
    else
    {
      bool bCheck = true;
      if (sender.Value < this.m_Soldier[id])
        bCheck = false;
      if (sender.Type == (byte) 1)
      {
        int btnId2 = sender.gameObject.transform.parent.GetComponent<ScrollPanelItem>().m_BtnID2;
        this.Cstr_ItemSliderQty[btnId2].ClearString();
        this.Cstr_ItemSliderQty[btnId2].IntToFormat(sender.Value, bNumber: true);
        this.Cstr_ItemSliderQty[btnId2].AppendFormat("{0}");
        sender.m_inputText.text = this.Cstr_ItemSliderQty[btnId2].ToString();
        sender.m_inputText.SetAllDirty();
        sender.m_inputText.cachedTextGenerator.Invalidate();
        this.m_Soldier[id] = sender.Value;
        this.DM.mExpeditionSoldierList[id] = (uint) this.m_Soldier[id];
        this.SetDRformURS(bCheck);
      }
      else
      {
        this.Cstr.ClearString();
        StringManager.IntToStr(this.Cstr, sender.Value, bNumber: true);
        sender.m_inputText.text = this.Cstr.ToString();
        sender.m_inputText.SetAllDirty();
        sender.m_inputText.cachedTextGenerator.Invalidate();
        if (sender.Value == 0L && this.btn_Disband.m_BtnType == e_BtnType.e_Normal)
        {
          this.btn_Disband.ForTextChange(e_BtnType.e_ChangeText);
        }
        else
        {
          if (this.btn_Disband.m_BtnType != e_BtnType.e_ChangeText)
            return;
          this.btn_Disband.ForTextChange(e_BtnType.e_Normal);
        }
      }
    }
  }

  public void SetDRformURS(bool bCheck)
  {
    long[] Resources = new long[6];
    Array.Clear((Array) Resources, 0, Resources.Length);
    this.TreatmentNum = 0L;
    double InFloat = 0.0;
    int num1 = 4;
    if (this.buildID == (ushort) 12)
      num1 = 3;
    for (int index = 0; index < this.Count; ++index)
    {
      int num2 = (3 - index / 4) * 4 + index % 4;
      if (this.buildID == (ushort) 7)
      {
        uint num3 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM) (79 + num2));
        if (num3 >= 9900U)
          num3 = 9900U;
        this.tmpEGA_Cost = (float) (1.0 - (double) num3 / 10000.0);
      }
      else
        this.tmpEGA_Cost = 1f;
      Resources[0] += (long) GameConstants.appCeil((float) GameConstants.appCeil((float) this.m_UnitResources[index].Food * this.tmpEGA_Cost) / 2.5f) * this.m_Soldier[index];
      Resources[1] += (long) GameConstants.appCeil((float) GameConstants.appCeil((float) this.m_UnitResources[index].Stone * this.tmpEGA_Cost) / 2.5f) * this.m_Soldier[index];
      Resources[2] += (long) GameConstants.appCeil((float) GameConstants.appCeil((float) this.m_UnitResources[index].Wood * this.tmpEGA_Cost) / 2.5f) * this.m_Soldier[index];
      Resources[3] += (long) GameConstants.appCeil((float) GameConstants.appCeil((float) this.m_UnitResources[index].Ironore * this.tmpEGA_Cost) / 2.5f) * this.m_Soldier[index];
      Resources[4] += (long) GameConstants.appCeil((float) GameConstants.appCeil((float) this.m_UnitResources[index].Money * this.tmpEGA_Cost) / 2.5f) * this.m_Soldier[index];
      if (index >= this.Count - num1 && index < this.Count)
        InFloat = InFloat;
      else
        InFloat += (double) ((long) this.m_UnitResources[index].Time * this.m_Soldier[index]) * (double) this.tmpEGA_T;
      this.TreatmentNum += this.m_Soldier[index];
    }
    this.GUIM.SetDemandResourcesText(this.m_DResources.GetComponent<Transform>(), Resources);
    double num4 = (double) GameConstants.appCeil((float) GameConstants.appCeil((float) InFloat) / 25f);
    uint num5 = 0;
    uint Num = GameConstants.appCeil((float) num4 * this.tmpEGA);
    uint num6 = Num / 3600U;
    this.Cstr_Time.ClearString();
    if (num6 < 24U)
    {
      this.Cstr_Time.IntToFormat((long) (num6 % 60U), 2);
      this.Cstr_Time.IntToFormat((long) (Num / 60U % 60U), 2);
      this.Cstr_Time.IntToFormat((long) (Num % 60U), 2);
      this.Cstr_Time.AppendFormat("{0:00}:{1:00}:{2:00}");
    }
    else if (this.GUIM.IsArabic)
    {
      this.Cstr_Time.IntToFormat((long) (num6 % 24U));
      this.Cstr_Time.IntToFormat((long) (Num / 60U % 60U), 2);
      this.Cstr_Time.IntToFormat((long) (Num % 60U), 2);
      this.Cstr_Time.IntToFormat((long) (num6 / 24U));
      this.Cstr_Time.AppendFormat("{0:00}:{1:00}:{2:00} {3}d");
    }
    else
    {
      this.Cstr_Time.IntToFormat((long) (num6 / 24U));
      this.Cstr_Time.IntToFormat((long) (num6 % 24U));
      this.Cstr_Time.IntToFormat((long) (Num / 60U % 60U), 2);
      this.Cstr_Time.IntToFormat((long) (Num % 60U), 2);
      this.Cstr_Time.AppendFormat("{0}d {1:00}:{2:00}:{3:00}");
    }
    this.text_Time.text = this.Cstr_Time.ToString();
    this.text_Time.SetAllDirty();
    this.text_Time.cachedTextGenerator.Invalidate();
    this.needDiamond = 0U;
    for (int Type = 0; Type < 5; ++Type)
    {
      if (Resources[Type] > (long) this.DM.Resource[Type].Stock)
        this.needDiamond += this.DM.GetResourceExchange((PriceListType) Type, (uint) Resources[Type] - this.DM.Resource[Type].Stock);
    }
    this.needDiamond += this.DM.GetResourceExchange(PriceListType.Time, Num);
    num5 = 1U;
    this.Cstr_Gemstone.ClearString();
    this.Cstr_Gemstone.IntToFormat((long) this.needDiamond, bNumber: true);
    this.Cstr_Gemstone.AppendFormat("{0}");
    this.text_Gemstone.text = this.Cstr_Gemstone.ToString();
    this.text_Gemstone.SetAllDirty();
    this.text_Gemstone.cachedTextGenerator.Invalidate();
    this.Cstr_SliderQty.ClearString();
    this.Cstr_SliderQty.IntToFormat(this.TreatmentNum, bNumber: true);
    this.Cstr_SliderQty.AppendFormat("{0}");
    if (this.buildID != (ushort) 12)
    {
      this.text_Slider.text = this.Cstr_SliderQty.ToString();
      this.text_Slider.SetAllDirty();
      this.text_Slider.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.text_TrapTotal.text = this.Cstr_SliderQty.ToString();
      this.text_TrapTotal.SetAllDirty();
      this.text_TrapTotal.cachedTextGenerator.Invalidate();
    }
    if (this.bNOInjured)
    {
      this.btn_ALL.ForTextChange(e_BtnType.e_ChangeText);
      this.btn_TreatmentCompleted.ForTextChange(e_BtnType.e_ChangeText);
      this.btn_Treatment.ForTextChange(e_BtnType.e_ChangeText);
    }
    else
    {
      if (this.buildID == (ushort) 12 && (long) this.mTrapTreatmentMax == this.TreatmentNum)
        this.btn_ALL.ForTextChange(e_BtnType.e_ChangeText);
      else
        this.btn_ALL.ForTextChange(e_BtnType.e_Normal);
      bool flag = true;
      for (int index = 0; index < 5; ++index)
      {
        if (flag && ((Component) this.m_DResources.BtnResources[index]).gameObject.activeSelf)
        {
          flag = false;
          break;
        }
      }
      if (!bCheck && this.TreatmentNum == 0L)
      {
        this.btn_TreatmentCompleted.ForTextChange(e_BtnType.e_ChangeText);
        this.btn_Treatment.ForTextChange(e_BtnType.e_ChangeText);
      }
      if (this.TreatmentNum > 0L)
      {
        if (!flag)
          this.btn_Treatment.ForTextChange(e_BtnType.e_ChangeText);
        else
          this.btn_Treatment.ForTextChange(e_BtnType.e_Normal);
        this.btn_TreatmentCompleted.ForTextChange(e_BtnType.e_Normal);
        this.text_ALL.text = this.DM.mStringTable.GetStringByID(7010U);
        this.bClear = true;
      }
      else
      {
        this.text_ALL.text = this.DM.mStringTable.GetStringByID(3878U);
        this.bClear = false;
      }
      this.text_ALL.SetAllDirty();
      this.text_ALL.cachedTextGenerator.Invalidate();
    }
  }

  public void UpdateTarpMax()
  {
    this.mTrapTreatmentMax = this.DM.TrapTotal;
    if (this.DM.queueBarData[14].bActive)
      this.mTrapTreatmentMax += this.DM.TrapTrainingQty;
    if (this.DM.queueBarData[15].bActive)
      this.mTrapTreatmentMax += this.DM.Trap_TreatmentQuantity;
    this.mTrapTreatmentMax = this.HospitalNum - this.mTrapTreatmentMax;
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.FrameMaterial = GUIManager.Instance.GetFrameMaterial();
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    Transform transform = this.gameObject.transform;
    this.B_ID = arg1;
    Array.Clear((Array) this.m_Soldier, 0, this.m_Soldier.Length);
    Array.Clear((Array) this.m_SoldierMax, 0, this.m_SoldierMax.Length);
    if (this.B_ID < GUIManager.Instance.BuildingData.AllBuildsData.Length)
      this.buildID = GUIManager.Instance.BuildingData.AllBuildsData[this.B_ID].BuildID;
    this.Pos[0] = -42f;
    this.Pos[1] = -61f;
    this.Pos[2] = -70f;
    this.Pos[3] = -80f;
    this.Pos[4] = -87f;
    this.Width[0] = 66f;
    this.Width[1] = 90f;
    this.Width[2] = 114f;
    this.Width[3] = 134f;
    this.Width[4] = 150f;
    if (this.buildID != (ushort) 12)
    {
      this.tmpEGA = 10000f / (float) (10000U + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_HOSPITAL_HEALING_SPEED));
      float num = (float) (10000U + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED)) - (float) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TROOP_TRAINING_SPEED_DEBUFF);
      if ((double) num <= 100.0)
        num = 100f;
      this.tmpEGA_T = 10000f / num;
      this.buildTypeData = this.DM.BuildsTypeData.GetRecordByKey((ushort) 7);
      this.Count = 16;
      this.HospitalNum = this.GetHospitalMaxCapacity();
      this.AssetName_D = "UI_arms";
      this.m_Arms = this.GUIM.AddSpriteAsset(this.AssetName_D);
    }
    else
    {
      this.HospitalNum = this.GetTrapCapacity();
      this.tmpEGA_T = 10000f / (float) (10000U + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAP_TRAINING_SPEED));
      this.UpdateTarpMax();
      this.AssetName_D = "UI_trap";
      this.m_Arms = this.GUIM.AddSpriteAsset(this.AssetName_D);
    }
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.AssetName = "BuildingWindow";
    this.m_BW = this.GUIM.AddSpriteAsset(this.AssetName);
    this.m_Mat = this.door.LoadMaterial();
    this.Cstr = StringManager.Instance.SpawnString();
    this.Cstr_SliderQty = StringManager.Instance.SpawnString();
    this.Cstr_Gemstone = StringManager.Instance.SpawnString();
    this.Cstr_Time = StringManager.Instance.SpawnString();
    this.Cstr_TimeBar = StringManager.Instance.SpawnString();
    this.Cstr_Msg = StringManager.Instance.SpawnString();
    for (int index = 0; index < 2; ++index)
    {
      this.Cstr_TrapNum[index] = StringManager.Instance.SpawnString();
      this.Cstr_InjuredTroop[index] = StringManager.Instance.SpawnString();
    }
    for (int index = 0; index < 5; ++index)
    {
      this.Cstr_SliderMaxQty[index] = StringManager.Instance.SpawnString();
      this.Cstr_ItemSliderQty[index] = StringManager.Instance.SpawnString();
    }
    this.Tmp = transform.GetChild(0);
    this.Img_Base = this.Tmp.GetComponent<Image>();
    this.Img_Base.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_04");
    ((MaskableGraphic) this.Img_Base).material = this.m_BW;
    if (this.buildID == (ushort) 12)
    {
      ((Component) this.Img_Base).gameObject.SetActive(true);
      this.Tmp1 = this.Tmp.GetChild(0);
      this.tmpimg = this.Tmp1.GetComponent<Image>();
      this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_19");
      ((MaskableGraphic) this.tmpimg).material = this.m_BW;
      this.text_tmpStr[0] = this.Tmp1.GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[0].font = this.TTFont;
      this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(3750U);
      this.AssetName1 = "UICityWall";
      this.GUIM.AddSpriteAsset(this.AssetName1);
      this.Tmp1 = this.Tmp.GetChild(1);
      this.tmpimg = this.Tmp1.GetComponent<Image>();
      this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName1, "UI_walllist_pic_04");
      ((MaskableGraphic) this.tmpimg).material = this.GUIM.LoadMaterial(this.AssetName1, "UI_wall_list_m");
      this.Tmp1 = this.Tmp.GetChild(2);
      this.Img_Lock = this.Tmp1.GetComponent<Image>();
      this.Img_Lock.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_market_bar_01");
      ((MaskableGraphic) this.Img_Lock).material = this.m_BW;
      this.btn_RD = this.Tmp1.GetChild(0).GetComponent<UIButton>();
      this.btn_RD.m_Handler = (IUIButtonClickHandler) this;
      this.btn_RD.m_BtnID1 = 3;
      this.btn_RD.image.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_butt_07");
      ((MaskableGraphic) this.btn_RD.image).material = this.m_BW;
      this.btn_RD.m_EffectType = e_EffectType.e_Scale;
      this.btn_RD.transition = (Selectable.Transition) 0;
      this.text_tmpStr[1] = this.Tmp1.GetChild(0).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[1].font = this.TTFont;
      this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(3776U);
      this.tmpimg = this.Tmp1.GetChild(1).GetComponent<Image>();
      this.tmpimg.sprite = this.door.LoadSprite("UI_main_lock");
      ((MaskableGraphic) this.tmpimg).material = this.m_Mat;
      this.text_tmpStr[2] = this.Tmp1.GetChild(2).GetComponent<UIText>();
      this.text_tmpStr[2].font = this.TTFont;
      this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(3760U);
      this.Tmp1 = this.Tmp.GetChild(3);
      this.tmpimg = this.Tmp1.GetComponent<Image>();
      this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_06");
      ((MaskableGraphic) this.tmpimg).material = this.m_BW;
      this.tmpimg = this.Tmp1.GetChild(0).GetComponent<Image>();
      this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_13");
      ((MaskableGraphic) this.tmpimg).material = this.m_BW;
      this.tmpimg = this.Tmp1.GetChild(1).GetComponent<Image>();
      this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_wall_trap_03");
      ((MaskableGraphic) this.tmpimg).material = this.m_BW;
      this.tmpimg = this.Tmp1.GetChild(2).GetComponent<Image>();
      this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_15");
      ((MaskableGraphic) this.tmpimg).material = this.m_BW;
      this.text_TrapTotal = this.Tmp1.GetChild(2).GetChild(0).GetComponent<UIText>();
      this.text_TrapTotal.font = this.TTFont;
      this.text_TrapTotal.text = this.TreatmentNum.ToString();
      this.text_tmpStr[3] = this.Tmp1.GetChild(3).GetComponent<UIText>();
      this.text_tmpStr[3].font = this.TTFont;
      this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(3779U);
      this.text_TrapNum[0] = this.Tmp1.GetChild(4).GetComponent<UIText>();
      this.text_TrapNum[0].font = this.TTFont;
      this.text_TrapNum[1] = this.Tmp1.GetChild(5).GetComponent<UIText>();
      this.text_TrapNum[1].font = this.TTFont;
      this.Cstr_TrapNum[0].ClearString();
      this.Cstr_TrapNum[0].IntToFormat((long) this.DM.TrapHospitalTotal, bNumber: true);
      this.Cstr_TrapNum[0].AppendFormat("{0}");
      this.text_TrapNum[0].text = this.Cstr_TrapNum[0].ToString();
      this.Cstr_TrapNum[1].ClearString();
      this.Cstr_TrapNum[1].IntToFormat((long) this.HospitalNum, bNumber: true);
      if (this.GUIM.IsArabic)
        this.Cstr_TrapNum[1].AppendFormat("{0} / ");
      else
        this.Cstr_TrapNum[1].AppendFormat(" / {0}");
      this.text_TrapNum[1].text = this.Cstr_TrapNum[1].ToString();
      this.text_tmpStr[4] = this.Tmp1.GetChild(6).GetComponent<UIText>();
      this.text_tmpStr[4].font = this.TTFont;
      this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(3780U);
      this.Tmp1 = this.Tmp.GetChild(4);
      this.tmpimg = this.Tmp1.GetComponent<Image>();
      this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_divider_01");
      ((MaskableGraphic) this.tmpimg).material = this.m_BW;
    }
    this.Tmp = transform.GetChild(1);
    this.BG = this.Tmp.GetComponent<Image>();
    this.BG.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_divider_02");
    ((MaskableGraphic) this.BG).material = this.m_BW;
    this.Tmp1 = this.Tmp.GetChild(0);
    this.tmpimg = this.Tmp1.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_16");
    ((MaskableGraphic) this.tmpimg).material = this.m_BW;
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.tmpimg = this.Tmp2.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_17");
    ((MaskableGraphic) this.tmpimg).material = this.m_BW;
    this.Tmp2 = this.Tmp1.GetChild(1);
    this.tmpimg = this.Tmp2.GetComponent<Image>();
    this.tmpimg.sprite = this.door.LoadSprite("UI_main_money_02");
    ((MaskableGraphic) this.tmpimg).material = this.m_Mat;
    this.tmpimg.SetNativeSize();
    this.Tmp2 = this.Tmp1.GetChild(2);
    this.text_Gemstone = this.Tmp2.GetComponent<UIText>();
    this.text_Gemstone.font = this.TTFont;
    this.Cstr_Gemstone.ClearString();
    this.Cstr_Gemstone.IntToFormat(0L, bNumber: true);
    this.Cstr_Gemstone.AppendFormat("{0}");
    this.text_Gemstone.text = this.Cstr_Gemstone.ToString();
    this.Tmp1 = this.Tmp.GetChild(1);
    this.tmpimg = this.Tmp1.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_16");
    ((MaskableGraphic) this.tmpimg).material = this.m_BW;
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.tmpimg = this.Tmp2.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_17");
    ((MaskableGraphic) this.tmpimg).material = this.m_BW;
    this.Tmp2 = this.Tmp1.GetChild(1);
    this.tmpimg = this.Tmp2.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_icon_10");
    ((MaskableGraphic) this.tmpimg).material = this.m_BW;
    this.tmpimg.SetNativeSize();
    this.Tmp2 = this.Tmp1.GetChild(2);
    this.text_Time = this.Tmp2.GetComponent<UIText>();
    this.text_Time.font = this.TTFont;
    this.Tmp = transform.GetChild(2);
    this.m_DResources = this.Tmp.GetComponent<DemandResources>();
    this.GUIM.InitDemandResources(this.Tmp, 489f, 98f, true);
    for (int index = 0; index < 5; ++index)
      this.m_DResources.TextResources[index].fontSize = 14;
    this.Tmp = transform.GetChild(3);
    this.btn_ALL = this.Tmp.GetComponent<UIButton>();
    this.btn_ALL.image.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_butt_07");
    ((MaskableGraphic) this.btn_ALL.image).material = this.m_BW;
    this.btn_ALL.m_Handler = (IUIButtonClickHandler) this;
    this.btn_ALL.m_BtnID1 = 0;
    this.btn_ALL.m_EffectType = e_EffectType.e_Scale;
    this.btn_ALL.transition = (Selectable.Transition) 0;
    this.Tmp1 = this.Tmp.GetChild(0);
    this.text_ALL = this.Tmp1.GetComponent<UIText>();
    this.text_ALL.font = this.TTFont;
    this.text_ALL.text = this.DM.mStringTable.GetStringByID(3878U);
    this.btn_ALL.m_Text = this.text_ALL;
    this.Tmp = transform.GetChild(4);
    this.btn_TreatmentCompleted = this.Tmp.GetComponent<UIButton>();
    this.btn_TreatmentCompleted.image.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_butt_07");
    ((MaskableGraphic) this.btn_TreatmentCompleted.image).material = this.m_BW;
    this.btn_TreatmentCompleted.m_Handler = (IUIButtonClickHandler) this;
    this.btn_TreatmentCompleted.m_BtnID1 = 2;
    this.btn_TreatmentCompleted.m_EffectType = e_EffectType.e_Scale;
    this.btn_TreatmentCompleted.transition = (Selectable.Transition) 0;
    this.Tmp1 = this.Tmp.GetChild(0);
    this.text_TreatmentCompleted = this.Tmp1.GetComponent<UIText>();
    this.text_TreatmentCompleted.font = this.TTFont;
    this.btn_TreatmentCompleted.m_Text = this.text_TreatmentCompleted;
    this.Tmp = transform.GetChild(5);
    this.btn_Treatment = this.Tmp.GetComponent<UIButton>();
    this.btn_Treatment.image.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_butt_07");
    ((MaskableGraphic) this.btn_Treatment.image).material = this.m_BW;
    this.btn_Treatment.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Treatment.m_BtnID1 = 1;
    this.btn_Treatment.m_EffectType = e_EffectType.e_Scale;
    this.btn_Treatment.transition = (Selectable.Transition) 0;
    this.Tmp1 = this.Tmp.GetChild(0);
    this.text_Treatment = this.Tmp1.GetComponent<UIText>();
    this.text_Treatment.font = this.TTFont;
    this.btn_Treatment.m_Text = this.text_Treatment;
    if (this.buildID != (ushort) 12)
    {
      this.text_TreatmentCompleted.text = this.DM.mStringTable.GetStringByID(3879U);
      this.text_Treatment.text = this.DM.mStringTable.GetStringByID(3880U);
    }
    else
    {
      this.text_TreatmentCompleted.text = this.DM.mStringTable.GetStringByID(3777U);
      this.text_Treatment.text = this.DM.mStringTable.GetStringByID(3778U);
    }
    this.Tmp = transform.GetChild(6);
    this.Img_Slider[0] = this.Tmp.GetComponent<Image>();
    this.Img_Slider[0].sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_15");
    ((MaskableGraphic) this.Img_Slider[0]).material = this.m_BW;
    this.Tmp1 = this.Tmp.GetChild(0);
    this.Img_Slider[1] = this.Tmp1.GetComponent<Image>();
    this.Img_Slider[1].sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_icon_01");
    ((MaskableGraphic) this.Img_Slider[1]).material = this.m_BW;
    this.Img_Slider[1].SetNativeSize();
    this.Tmp1 = this.Tmp.GetChild(1);
    this.Img_Slider[2] = this.Tmp1.GetComponent<Image>();
    this.Img_Slider[2].sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_13");
    ((MaskableGraphic) this.Img_Slider[2]).material = this.m_BW;
    this.Tmp1 = this.Tmp.GetChild(2);
    this.text_Slider = this.Tmp1.GetComponent<UIText>();
    this.text_Slider.font = this.TTFont;
    this.Tmp1 = this.Tmp.GetChild(3);
    this.text_InjuredTroops[0] = this.Tmp1.GetComponent<UIText>();
    this.text_InjuredTroops[0].font = this.TTFont;
    this.text_InjuredTroops[0].text = this.DM.mStringTable.GetStringByID(3932U);
    this.Tmp1 = this.Tmp.GetChild(4);
    this.text_InjuredTroops[1] = this.Tmp1.GetComponent<UIText>();
    this.text_InjuredTroops[1].font = this.TTFont;
    this.Tmp1 = this.Tmp.GetChild(5);
    this.text_InjuredTroops[2] = this.Tmp1.GetComponent<UIText>();
    this.text_InjuredTroops[2].font = this.TTFont;
    this.Tmp1 = this.Tmp.GetChild(6);
    this.text_InjuredTroops[3] = this.Tmp1.GetComponent<UIText>();
    this.text_InjuredTroops[3].font = this.TTFont;
    this.text_InjuredTroops[3].text = this.DM.mStringTable.GetStringByID((uint) this.buildTypeData.UIExplain);
    this.tmpRC = this.Tmp1.GetComponent<RectTransform>();
    this.Tmp = transform.GetChild(7);
    this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
    this.tmpimg = this.Tmp.gameObject.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_alp");
    ((MaskableGraphic) this.tmpimg).material = this.m_BW;
    Transform child = transform.GetChild(8);
    this.Tmp = child.GetChild(0);
    this.tmpimg = this.Tmp.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_07");
    ((MaskableGraphic) this.tmpimg).material = this.m_BW;
    this.Tmp = child.GetChild(1);
    this.m_UnitRS = this.Tmp.GetComponent<UnitResourcesSlider>();
    this.GUIM.InitUnitResourcesSlider(this.Tmp, eUnitSlider.Hospital, 0U, 1000U, 0.7f);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp, eUnitSliderSize.BtnIncrease, this.GUIM.LoadSprite(this.AssetName, "UI_main_strip_01"), this.m_BW);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp, eUnitSliderSize.BtnLessen, this.GUIM.LoadSprite(this.AssetName, "UI_main_strip_02"), this.m_BW);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp, eUnitSliderSize.Input, this.GUIM.LoadSprite(this.AssetName, "UI_main_strip_05"), this.m_BW);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp, eUnitSliderSize.m_sliderBG1, this.GUIM.LoadSprite(this.AssetName, "UI_main_strip_03"), this.m_BW);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp, eUnitSliderSize.m_sliderBG2, this.GUIM.LoadSprite(this.AssetName, "UI_main_strip_04"), this.m_BW);
    if (this.buildID == (ushort) 12)
      this.GUIM.SetUnitResourcesSliderImg(this.Tmp, eUnitSliderSize.m_micon, this.GUIM.LoadSprite(this.AssetName, "UI_wall_trap_03"), this.m_BW);
    this.m_UnitRS.m_Handler = (IUIUnitRSliderHandler) this;
    this.m_UnitRS.Type = (byte) 1;
    this.m_UnitRS.BtnInputText.m_Handler = (IUIButtonClickHandler) this;
    this.m_UnitRS.BtnInputText.m_BtnID1 = 8;
    this.Tmp = child.GetChild(2);
    this.tmpimg = this.Tmp.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite((ushort) 10010);
    ((MaskableGraphic) this.tmpimg).material = this.GUIM.m_IconSpriteAsset.GetMaterial();
    this.Tmp = child.GetChild(2).GetChild(0);
    this.tmpRC = this.Tmp.GetComponent<RectTransform>();
    this.tmpRC.anchorMin = new Vector2(9f / 128f, 9f / 128f);
    this.tmpRC.anchorMax = new Vector2(119f / 128f, 119f / 128f);
    this.tmpRC.offsetMin = Vector2.zero;
    this.tmpRC.offsetMax = Vector2.zero;
    this.tmpimg = this.Tmp.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.m_IconSpriteAsset.LoadSprite((ushort) 10010);
    ((MaskableGraphic) this.tmpimg).material = this.GUIM.m_IconSpriteAsset.GetMaterial();
    if (this.GUIM.IsArabic)
      ((Component) this.tmpimg).transform.localScale = new Vector3(-1f, ((Component) this.tmpimg).transform.localScale.y, ((Component) this.tmpimg).transform.localScale.z);
    UIButton component = child.GetChild(2).GetComponent<UIButton>();
    component.m_Handler = (IUIButtonClickHandler) this;
    component.SoundIndex = (byte) 64;
    this.Tmp = child.GetChild(2).GetChild(1);
    this.tmpimg = this.Tmp.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.LoadFrameSprite("hf003");
    ((MaskableGraphic) this.tmpimg).material = this.FrameMaterial;
    this.tmpRC = this.Tmp.GetComponent<RectTransform>();
    this.tmpRC.anchorMin = Vector2.zero;
    this.tmpRC.anchorMax = new Vector2(1f, 1f);
    this.tmpRC.offsetMin = Vector2.zero;
    this.tmpRC.offsetMax = Vector2.zero;
    this.Tmp = child.GetChild(3);
    this.tmpimg = this.Tmp.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_frame_26");
    ((MaskableGraphic) this.tmpimg).material = this.m_BW;
    this.Tmp1 = this.Tmp.GetChild(0);
    this.tmptext = this.Tmp1.GetComponent<UIText>();
    this.tmptext.font = this.TTFont;
    this.tmplist.Clear();
    this.mTreatmentCount = 0;
    UnitResources_H unitResourcesH = new UnitResources_H();
    this.InjuredNum = 0U;
    for (int index = 0; index < this.Count; ++index)
    {
      this.m_Soldier[index] = 0L;
      if (this.DM.bSetExpediton)
        this.m_Soldier[index] = (long) this.DM.mExpeditionSoldierList[index];
      else
        this.DM.mExpeditionSoldierList[index] = 0U;
      if (this.buildID == (ushort) 7)
      {
        ushort InKey = (ushort) (4 - index / 4 + index % 4 * 4);
        this.m_SoldierMax[index] = this.DM.mSoldier_Hospital[(int) InKey - 1];
        this.InjuredNum += this.DM.mSoldier_Hospital[(int) InKey - 1];
        this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey(InKey);
      }
      else if (this.buildID == (ushort) 12)
      {
        ushort num = (ushort) (4 - index / 3 + index % 3 * 4);
        this.m_SoldierMax[index] = this.DM.mTrap_Hospital[(int) num - 1];
        this.InjuredNum += this.DM.mTrap_Hospital[(int) num - 1];
        this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey((ushort) ((uint) num + 16U));
      }
      unitResourcesH.Food = (uint) this.tmpSD.FoodRequire;
      unitResourcesH.Stone = (uint) this.tmpSD.StoneRequire;
      unitResourcesH.Wood = (uint) this.tmpSD.WoodRequire;
      unitResourcesH.Ironore = (uint) this.tmpSD.IronRequire;
      unitResourcesH.Money = (uint) this.tmpSD.MoneyRequire;
      unitResourcesH.Time = (uint) this.tmpSD.TimeRequire;
      this.m_UnitResources[index] = unitResourcesH;
      this.m_SoldierSprite[index] = this.GUIM.m_IconSpriteAsset.LoadSprite(this.tmpSD.Icon);
      this.tmpStr.ClearString();
      this.tmpStr.IntToFormat((long) this.tmpSD.Tier);
      this.tmpStr.AppendFormat("hf00{0}");
      this.m_SoldierSpriteFrame[index] = this.GUIM.LoadFrameSprite(this.tmpStr);
      this.m_SoldierName[index] = this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name);
      if (this.m_SoldierMax[index] > 0U)
      {
        this.ShowListIndex[this.mTreatmentCount] = (byte) (index + 1);
        ++this.mTreatmentCount;
        this.tmplist.Add(91f);
        if (this.bNOInjured)
          this.bNOInjured = false;
      }
    }
    this.m_ScrollPanel.IntiScrollPanel(318f, 0.0f, 0.0f, this.tmplist, 5, (IUpDateScrollPanel) this);
    this.m_ScrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
    this.Cstr_InjuredTroop[0].ClearString();
    this.Cstr_InjuredTroop[0].IntToFormat((long) this.InjuredNum, bNumber: true);
    this.Cstr_InjuredTroop[0].AppendFormat("{0}");
    this.text_InjuredTroops[1].text = this.Cstr_InjuredTroop[0].ToString();
    this.text_InjuredTroops[1].SetAllDirty();
    this.text_InjuredTroops[1].cachedTextGenerator.Invalidate();
    this.Cstr_InjuredTroop[1].ClearString();
    this.Cstr_InjuredTroop[1].IntToFormat((long) this.HospitalNum, bNumber: true);
    if (this.GUIM.IsArabic)
      this.Cstr_InjuredTroop[1].AppendFormat("{0} / ");
    else
      this.Cstr_InjuredTroop[1].AppendFormat(" / {0}");
    this.text_InjuredTroops[2].text = this.Cstr_InjuredTroop[1].ToString();
    this.text_InjuredTroops[2].SetAllDirty();
    this.text_InjuredTroops[2].cachedTextGenerator.Invalidate();
    this.Tmp = transform.GetChild(9);
    this.Img_Treatment = this.Tmp.GetComponent<Image>();
    this.Img_Treatment.sprite = this.GUIM.LoadSprite(this.AssetName, "UI_con_black");
    ((MaskableGraphic) this.Img_Treatment).material = this.m_BW;
    this.Tmp1 = this.Tmp.GetChild(0);
    this.timeBar = this.Tmp1.GetComponent<UITimeBar>();
    this.GUIM.CreateTimerBar(this.timeBar, 0L, 0L, 0L, eTimeBarType.CancelType, string.Empty, string.Empty);
    this.GUIM.SetTimerSpriteType(this.timeBar, eTimerSpriteType.Speed);
    this.timeBar.m_Handler = (IUTimeBarOnTimer) this;
    this.timeBar.m_TimeBarID = 1;
    this.text_timeBar[0] = this.Tmp1.GetChild(2).GetComponent<UIText>();
    this.text_timeBar[1] = this.Tmp1.GetChild(3).GetComponent<UIText>();
    this.Tmp1 = this.Tmp.GetChild(1);
    this.text_Treatmenting = this.Tmp1.GetComponent<UIText>();
    this.text_Treatmenting.font = this.TTFont;
    uint x = 0;
    if (this.buildID == (ushort) 7 && this.DM.queueBarData[13].bActive)
    {
      this.bTreatmenting = true;
      ((Component) this.Img_Treatment).gameObject.SetActive(true);
      this.begin = this.DM.queueBarData[13].StartTime;
      this.target = this.begin + (long) this.DM.queueBarData[13].TotalTime;
      this.notify = 0L;
      for (int index = 0; index < this.Count; ++index)
        x += this.DM.mTreatmentSoldier[index];
      this.Cstr_TimeBar.ClearString();
      this.Cstr_TimeBar.IntToFormat((long) x, bNumber: true);
      this.Cstr_TimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(4046U));
      this.GUIM.SetTimerBar(this.timeBar, this.begin, this.target, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(4045U), this.Cstr_TimeBar.ToString());
      this.timeBar.gameObject.SetActive(true);
      this.text_Treatmenting.text = this.DM.mStringTable.GetStringByID(3814U);
      ((Component) this.text_Treatmenting).gameObject.SetActive(true);
      if (this.bNOInjured)
        this.bNOInjured = false;
    }
    if (this.buildID == (ushort) 12 && this.DM.queueBarData[15].bActive)
    {
      this.bTreatmenting = true;
      ((Component) this.Img_Treatment).gameObject.SetActive(true);
      this.begin = this.DM.queueBarData[15].StartTime;
      this.target = this.begin + (long) this.DM.queueBarData[15].TotalTime;
      this.notify = 0L;
      this.Cstr_TimeBar.ClearString();
      this.Cstr_TimeBar.IntToFormat((long) this.DM.Trap_TreatmentQuantity, bNumber: true);
      this.Cstr_TimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(1047U));
      this.GUIM.SetTimerBar(this.timeBar, this.begin, this.target, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(1046U), this.Cstr_TimeBar.ToString());
      this.timeBar.gameObject.SetActive(true);
      this.text_Treatmenting.text = this.DM.mStringTable.GetStringByID(1045U);
      ((Component) this.text_Treatmenting).gameObject.SetActive(true);
      if (this.bNOInjured)
        this.bNOInjured = false;
    }
    this.Img_Exit = transform.GetChild(10).GetComponent<Image>();
    this.Img_Exit.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.Img_Exit).material = this.m_Mat;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.Img_Exit).enabled = false;
    this.btn_EXIT = transform.GetChild(10).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 4;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.m_Mat;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.Tmp = transform.GetChild(11);
    this.ImgDisbandblack = this.Tmp.GetComponent<Image>();
    this.ImgDisbandblack.sprite = this.door.LoadSprite("UI_main_black");
    ((MaskableGraphic) this.ImgDisbandblack).material = this.door.LoadMaterial();
    if (this.GUIM.bOpenOnIPhoneX)
    {
      this.Tmp.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
      this.Tmp.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    HelperUIButton helperUiButton = ((Component) this.ImgDisbandblack).gameObject.AddComponent<HelperUIButton>();
    helperUiButton.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton.m_BtnID1 = 5;
    this.Tmp1 = this.Tmp.GetChild(0);
    this.tmpimg = this.Tmp1.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_29");
    ((MaskableGraphic) this.tmpimg).material = this.m_BW;
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.tmpimg = this.Tmp2.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_title_orange");
    ((MaskableGraphic) this.tmpimg).material = this.m_BW;
    this.text_Disband_Title = this.Tmp2.GetChild(0).GetComponent<UIText>();
    this.text_Disband_Title.font = this.TTFont;
    this.text_Disband_Title.text = this.buildID != (ushort) 7 ? this.DM.mStringTable.GetStringByID(3794U) : this.DM.mStringTable.GetStringByID(5772U);
    this.Tmp1 = this.Tmp.GetChild(1);
    this.tmpimg = this.Tmp1.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_06");
    ((MaskableGraphic) this.tmpimg).material = this.m_BW;
    this.Tmp1 = this.Tmp.GetChild(2);
    this.tmpimg = this.Tmp1.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_13");
    ((MaskableGraphic) this.tmpimg).material = this.m_BW;
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.text_Disband_Name = this.Tmp2.GetComponent<UIText>();
    this.text_Disband_Name.font = this.TTFont;
    this.text_Disband_Name.text = this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name);
    this.Tmp1 = this.Tmp.GetChild(3);
    this.ImgDisband_Item = this.Tmp1.GetComponent<Image>();
    ((MaskableGraphic) this.ImgDisband_Item).material = this.m_Arms;
    if (this.GUIM.IsArabic)
      ((Component) this.ImgDisband_Item).transform.localScale = new Vector3(-1f, ((Component) this.ImgDisband_Item).transform.localScale.y, ((Component) this.ImgDisband_Item).transform.localScale.z);
    this.Tmp1 = this.Tmp.GetChild(4);
    this.tmpimg = this.Tmp1.GetComponent<Image>();
    this.tmpimg.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_frame_20");
    ((MaskableGraphic) this.tmpimg).material = this.m_BW;
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.text_Disband_Num = this.Tmp2.GetComponent<UIText>();
    this.text_Disband_Num.font = this.TTFont;
    this.Tmp1 = this.Tmp.GetChild(5);
    this.m_DisbandSlider = this.Tmp1.GetComponent<UnitResourcesSlider>();
    this.GUIM.InitUnitResourcesSlider(this.Tmp1, eUnitSlider.Other, 0U, 0U, 0.7f);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.BtnIncrease, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_01"), this.m_BW);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.BtnLessen, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_02"), this.m_BW);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.Input, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_05"), this.m_BW);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_sliderBG1, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_03"), this.m_BW);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_sliderBG2, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_04"), this.m_BW);
    this.GUIM.SetUnitResourcesSliderImg(this.Tmp1, eUnitSliderSize.m_Img, this.GUIM.LoadSprite("BuildingWindow", "UI_main_strip_06"), this.m_BW);
    this.GUIM.SetUnitResourcesSliderSize(this.Tmp1, eUnitSliderSize.m_Img, 5f, 52.5f, 22f, 28f, 0.0f, 0.0f);
    this.m_DisbandSlider.m_Handler = (IUIUnitRSliderHandler) this;
    this.m_DisbandSlider.Type = (byte) 2;
    this.m_DisbandSlider.BtnInputText.m_Handler = (IUIButtonClickHandler) this;
    this.m_DisbandSlider.BtnInputText.m_BtnID1 = 9;
    this.tmpRC = ((Component) this.m_DisbandSlider.m_TotalText).transform.GetComponent<RectTransform>();
    this.tmpRC.sizeDelta = new Vector2(120f, this.tmpRC.sizeDelta.y);
    this.tmpRC.anchoredPosition = new Vector2(269f, this.tmpRC.anchoredPosition.y);
    this.DisbandSliderRT = this.m_DisbandSlider.GetComponent<Transform>().GetChild(3).GetComponent<RectTransform>();
    this.Tmp1 = this.Tmp.GetChild(6);
    this.btn_Disband = this.Tmp1.GetComponent<UIButton>();
    this.btn_Disband.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Disband.m_BtnID1 = 6;
    this.btn_Disband.image.sprite = this.GUIM.LoadSprite("BuildingWindow", "UI_con_butt_07");
    ((MaskableGraphic) this.btn_Disband.image).material = this.m_BW;
    this.btn_Disband.m_EffectType = e_EffectType.e_Scale;
    this.btn_Disband.transition = (Selectable.Transition) 0;
    this.Tmp2 = this.Tmp1.GetChild(0);
    this.text_Disband = this.Tmp2.GetComponent<UIText>();
    this.text_Disband.font = this.TTFont;
    this.text_Disband.text = this.DM.mStringTable.GetStringByID(4050U);
    this.Tmp1 = this.Tmp.GetChild(7);
    this.btn_Disband_Exit = this.Tmp1.GetComponent<UIButton>();
    this.btn_Disband_Exit.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Disband_Exit.m_BtnID1 = 5;
    this.btn_Disband_Exit.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_Disband_Exit.image).material = this.m_Mat;
    this.btn_Disband_Exit.m_EffectType = e_EffectType.e_Scale;
    this.btn_Disband_Exit.transition = (Selectable.Transition) 0;
    this.Tmp = transform.GetChild(12);
    this.text_NoNeedTreatment = this.Tmp.GetComponent<UIText>();
    this.text_NoNeedTreatment.font = this.TTFont;
    if (this.buildID == (ushort) 12)
    {
      ((Component) this.Img_Slider[0]).gameObject.SetActive(false);
      ((Component) this.Img_Exit).gameObject.SetActive(true);
      ((Component) this.btn_EXIT).gameObject.SetActive(true);
      if (this.DM.GetTechLevel((ushort) 56) == (byte) 0)
      {
        ((Component) this.Img_Lock).gameObject.SetActive(true);
        ((Component) this.btn_ALL).gameObject.SetActive(false);
        ((Component) this.btn_Treatment).gameObject.SetActive(false);
        ((Component) this.btn_TreatmentCompleted).gameObject.SetActive(false);
        ((Component) this.BG).gameObject.SetActive(false);
        this.m_DResources.gameObject.SetActive(false);
      }
      else
        ((Component) this.Img_Lock).gameObject.SetActive(false);
      this.text_Disband.text = this.DM.mStringTable.GetStringByID(3772U);
    }
    if (this.buildID == (ushort) 7)
      this.text_NoNeedTreatment.text = this.DM.mStringTable.GetStringByID(3829U);
    else if (this.buildID == (ushort) 12 && !((UIBehaviour) this.Img_Lock).IsActive())
      this.text_NoNeedTreatment.text = this.DM.mStringTable.GetStringByID(3791U);
    if (this.bNOInjured)
    {
      this.m_ScrollPanel.gameObject.SetActive(false);
      ((Component) this.text_NoNeedTreatment).gameObject.SetActive(true);
    }
    if (this.DM.bSetExpediton)
    {
      this.m_ScrollPanel.GoTo(this.DM.mScroll_Idx);
      this.DM.bSetExpediton = false;
      this.SetDRformURS(true);
    }
    else
    {
      if (!this.bTreatmenting)
      {
        int num = (int) this.CheckAllMax();
      }
      else
        this.SetbTreatmenting();
      if (this.mTreatmentCount >= 5)
        this.mTreatmentCount = 5;
      for (int index = 0; index < this.mTreatmentCount; ++index)
      {
        this.m_UnitRS_Item[index].MaxValue = (long) this.m_SoldierMax[this.m_UnitRS_Item[index].m_ID];
        this.m_UnitRS_Item[index].Value = this.m_Soldier[this.m_UnitRS_Item[index].m_ID];
        this.m_UnitRS_Item[index].m_slider.maxValue = (double) this.m_SoldierMax[this.m_UnitRS_Item[index].m_ID];
        this.m_UnitRS_Item[index].m_slider.value = (double) this.m_Soldier[this.m_UnitRS_Item[index].m_ID];
        this.Cstr_ItemSliderQty[index].ClearString();
        StringManager.IntToStr(this.Cstr_ItemSliderQty[index], this.m_UnitRS_Item[index].Value, bNumber: true);
        this.m_UnitRS_Item[index].m_inputText.text = this.Cstr_ItemSliderQty[index].ToString();
        this.m_UnitRS_Item[index].m_inputText.SetAllDirty();
        this.m_UnitRS_Item[index].m_inputText.cachedTextGenerator.Invalidate();
      }
      this.SetDRformURS(false);
    }
    if (this.buildID == (ushort) 7)
    {
      for (int index = 0; index < 16; ++index)
        this.DM.mExpeditionSoldierList[index] = (uint) this.m_Soldier[index];
    }
    else
    {
      for (int index = 0; index < 12; ++index)
        this.DM.mExpeditionSoldierList[index] = (uint) this.m_Soldier[index];
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public uint GetHospitalMaxCapacity()
  {
    ulong effectBaseVal1 = (ulong) DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_HOSPITAL_CAPACITY_PERCENT);
    ulong effectBaseVal2 = (ulong) DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_HOSPITAL_CAPACITY);
    return (uint) (effectBaseVal2 + effectBaseVal2 * effectBaseVal1 / 10000UL);
  }

  public uint GetTrapCapacity()
  {
    return DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRAP_CAPACITY);
  }

  public bool CheckDiamondToSend()
  {
    bool send = false;
    long[] numArray = new long[6];
    this.needDiamond = 0U;
    this.TreatmentNum = 0L;
    for (int index1 = 0; index1 < this.Count; ++index1)
    {
      byte index2 = (byte) ((uint) this.ShowListIndex[index1] - 1U);
      if (this.ShowListIndex[index1] != (byte) 0)
      {
        int num1 = (3 - (int) index2 / 4) * 4 + (int) index2 % 4;
        if (this.buildID == (ushort) 7)
        {
          uint num2 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM) (79 + num1));
          if (num2 >= 9900U)
            num2 = 9900U;
          this.tmpEGA_Cost = (float) (1.0 - (double) num2 / 10000.0);
        }
        else
          this.tmpEGA_Cost = 1f;
        numArray[0] += (long) GameConstants.appCeil((float) this.m_UnitResources[(int) index2].Food / 2.5f * this.tmpEGA_Cost * (float) this.m_Soldier[(int) index2]);
        numArray[1] += (long) GameConstants.appCeil((float) this.m_UnitResources[(int) index2].Stone / 2.5f * this.tmpEGA_Cost * (float) this.m_Soldier[(int) index2]);
        numArray[2] += (long) GameConstants.appCeil((float) this.m_UnitResources[(int) index2].Wood / 2.5f * this.tmpEGA_Cost * (float) this.m_Soldier[(int) index2]);
        numArray[3] += (long) GameConstants.appCeil((float) this.m_UnitResources[(int) index2].Ironore / 2.5f * this.tmpEGA_Cost * (float) this.m_Soldier[(int) index2]);
        numArray[4] += (long) GameConstants.appCeil((float) this.m_UnitResources[(int) index2].Money / 2.5f * this.tmpEGA_Cost * (float) this.m_Soldier[(int) index2]);
        if (this.buildID == (ushort) 7 && index2 >= (byte) 12 && index2 < (byte) 16 || this.buildID == (ushort) 12 && index2 >= (byte) 9 && index2 <= (byte) 12)
        {
          ref long local = ref numArray[5];
          local = local;
        }
        else
          numArray[5] += (long) ((double) ((long) this.m_UnitResources[(int) index2].Time * this.m_Soldier[(int) index2]) * (double) this.tmpEGA_T);
        this.TreatmentNum += this.m_Soldier[(int) index2];
      }
      else
        break;
    }
    for (int Type = 0; Type < 5; ++Type)
    {
      if (numArray[Type] > (long) this.DM.Resource[Type].Stock)
        this.needDiamond += this.DM.GetResourceExchange((PriceListType) Type, (uint) numArray[Type] - this.DM.Resource[Type].Stock);
    }
    numArray[5] = (long) GameConstants.appCeil((float) numArray[5]);
    numArray[5] = (long) GameConstants.appCeil((float) numArray[5] / 25f);
    this.needDiamond += this.DM.GetResourceExchange(PriceListType.Time, GameConstants.appCeil((float) numArray[5] * this.tmpEGA));
    if (this.TreatmentNum > 0L && this.DM.RoleAttr.Diamond >= this.needDiamond)
      send = true;
    return send;
  }

  public byte CheckAllMax(bool bset = true)
  {
    this.TreatmentNum = 0L;
    byte num1 = 0;
    uint trapTreatmentMax = this.mTrapTreatmentMax;
    uint[] numArray1 = new uint[5];
    uint[] numArray2 = new uint[5];
    uint[] numArray3 = new uint[5];
    for (int index = 0; index < 5; ++index)
      numArray1[index] = this.DM.Resource[index].Stock;
    for (int index1 = 0; index1 < this.Count; ++index1)
    {
      byte num2 = 0;
      byte index2 = (byte) ((uint) this.ShowListIndex[index1] - 1U);
      if (this.ShowListIndex[index1] != (byte) 0)
      {
        int num3 = (3 - (int) index2 / 4) * 4 + (int) index2 % 4;
        if (this.buildID == (ushort) 7)
        {
          uint num4 = this.DM.AttribVal.GetEffectBaseVal((GATTR_ENUM) (79 + num3));
          if (num4 >= 9900U)
            num4 = 9900U;
          this.tmpEGA_Cost = (float) (1.0 - (double) num4 / 10000.0);
        }
        else
          this.tmpEGA_Cost = 1f;
        numArray3[0] = this.m_UnitResources[(int) index2].Food;
        numArray3[1] = this.m_UnitResources[(int) index2].Stone;
        numArray3[2] = this.m_UnitResources[(int) index2].Wood;
        numArray3[3] = this.m_UnitResources[(int) index2].Ironore;
        numArray3[4] = this.m_UnitResources[(int) index2].Money;
        for (int index3 = 0; index3 < 5; ++index3)
        {
          if (numArray3[index3] != 0U)
          {
            uint num5 = GameConstants.appCeil((float) GameConstants.appCeil((float) numArray3[index3] * this.tmpEGA_Cost) / 2.5f) * this.m_SoldierMax[(int) index2];
            if (numArray1[index3] == 0U)
            {
              num2 = (byte) 2;
              numArray2[index3] = 0U;
              if (num1 != (byte) 2)
                num1 = (byte) 2;
            }
            else if (numArray1[index3] < num5 && num2 < (byte) 2)
            {
              num2 = (byte) 1;
              numArray2[index3] = this.buildID != (ushort) 12 || numArray1[index3] / GameConstants.appCeil((float) numArray3[index3] / 2.5f) <= trapTreatmentMax ? numArray1[index3] / GameConstants.appCeil((float) GameConstants.appCeil((float) numArray3[index3] * this.tmpEGA_Cost) / 2.5f) : trapTreatmentMax;
              if (num1 < (byte) 1)
                num1 = (byte) 1;
            }
            else
              numArray2[index3] = this.buildID != (ushort) 12 || this.m_SoldierMax[(int) index2] <= trapTreatmentMax ? this.m_SoldierMax[(int) index2] : trapTreatmentMax;
          }
        }
        if (bset)
        {
          switch (num2)
          {
            case 0:
              this.m_Soldier[(int) index2] = this.buildID != (ushort) 12 || this.m_SoldierMax[(int) index2] <= trapTreatmentMax ? (long) this.m_SoldierMax[(int) index2] : (long) trapTreatmentMax;
              break;
            case 1:
              this.m_Soldier[(int) index2] = (long) numArray2[0];
              for (int index4 = 1; index4 < 5; ++index4)
              {
                if (numArray3[index4] != 0U && this.m_Soldier[(int) index2] > (long) numArray2[index4])
                  this.m_Soldier[(int) index2] = (long) numArray2[index4];
              }
              break;
          }
          this.DM.mExpeditionSoldierList[(int) index2] = (uint) this.m_Soldier[(int) index2];
          this.TreatmentNum += this.m_Soldier[(int) index2];
          if (this.buildID == (ushort) 12)
            trapTreatmentMax -= (uint) this.m_Soldier[(int) index2];
          numArray1[0] -= (uint) ((ulong) GameConstants.appCeil((float) GameConstants.appCeil((float) this.m_UnitResources[(int) index2].Food * this.tmpEGA_Cost) / 2.5f) * (ulong) this.m_Soldier[(int) index2]);
          numArray1[1] -= (uint) ((ulong) GameConstants.appCeil((float) GameConstants.appCeil((float) this.m_UnitResources[(int) index2].Stone * this.tmpEGA_Cost) / 2.5f) * (ulong) this.m_Soldier[(int) index2]);
          numArray1[2] -= (uint) ((ulong) GameConstants.appCeil((float) GameConstants.appCeil((float) this.m_UnitResources[(int) index2].Wood * this.tmpEGA_Cost) / 2.5f) * (ulong) this.m_Soldier[(int) index2]);
          numArray1[3] -= (uint) ((ulong) GameConstants.appCeil((float) GameConstants.appCeil((float) this.m_UnitResources[(int) index2].Ironore * this.tmpEGA_Cost) / 2.5f) * (ulong) this.m_Soldier[(int) index2]);
          numArray1[4] -= (uint) ((ulong) GameConstants.appCeil((float) GameConstants.appCeil((float) this.m_UnitResources[(int) index2].Money * this.tmpEGA_Cost) / 2.5f) * (ulong) this.m_Soldier[(int) index2]);
        }
      }
      else
        break;
    }
    if (this.bNOInjured)
      this.btn_ALL.ForTextChange(e_BtnType.e_ChangeText);
    else
      this.btn_ALL.ForTextChange(e_BtnType.e_Normal);
    return num1;
  }

  public void SetbTreatmenting()
  {
    this.TreatmentNum = 0L;
    for (int index1 = 0; index1 < this.Count; ++index1)
    {
      byte index2 = (byte) ((uint) this.ShowListIndex[index1] - 1U);
      if (this.ShowListIndex[index1] == (byte) 0)
        break;
      if (this.buildID == (ushort) 7)
      {
        byte num = (byte) (4 - (int) index2 / 4 + (int) index2 % 4 * 4);
        this.m_Soldier[(int) index2] = (long) this.DM.mTreatmentSoldier[(int) num - 1];
      }
      else
      {
        byte num = (byte) (4 - (int) index2 / 3 + (int) index2 % 3 * 4);
        this.m_Soldier[(int) index2] = (long) this.DM.mRepairTrap[(int) num - 1];
      }
    }
  }

  public void SetALLMax()
  {
    byte num1 = 0;
    this.TreatmentNum = 0L;
    uint num2 = this.mTrapTreatmentMax;
    for (int index1 = 0; index1 < this.Count && num1 == (byte) 0; ++index1)
    {
      byte index2 = (byte) ((uint) this.ShowListIndex[index1] - 1U);
      if (this.ShowListIndex[index1] != (byte) 0)
      {
        this.m_Soldier[(int) index2] = this.buildID != (ushort) 12 || this.m_SoldierMax[(int) index2] <= num2 ? (long) this.m_SoldierMax[(int) index2] : (long) num2;
        this.DM.mExpeditionSoldierList[(int) index2] = (uint) this.m_Soldier[(int) index2];
        num2 -= (uint) this.m_Soldier[(int) index2];
        if (num2 < 0U)
          num2 = 0U;
        this.TreatmentNum += this.m_Soldier[(int) index2];
      }
      else
        break;
    }
    if (this.bNOInjured)
      this.btn_ALL.ForTextChange(e_BtnType.e_ChangeText);
    else if (this.buildID == (ushort) 12 && (long) this.mTrapTreatmentMax == this.TreatmentNum)
      this.btn_ALL.ForTextChange(e_BtnType.e_ChangeText);
    else
      this.btn_ALL.ForTextChange(e_BtnType.e_Normal);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (this.bNOInjured)
          break;
        if (this.buildID == (ushort) 12 && (long) this.mTrapTreatmentMax == this.TreatmentNum)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(3755U), (ushort) byte.MaxValue);
          break;
        }
        if (!this.bClear)
        {
          this.bClear = true;
          this.SetALLMax();
          this.text_ALL.text = this.DM.mStringTable.GetStringByID(7010U);
        }
        else
        {
          this.bClear = false;
          for (int index = 0; index < this.Count; ++index)
          {
            this.m_Soldier[index] = 0L;
            this.DM.mExpeditionSoldierList[index] = (uint) this.m_Soldier[index];
          }
          this.text_ALL.text = this.DM.mStringTable.GetStringByID(3878U);
        }
        this.text_ALL.SetAllDirty();
        this.text_ALL.cachedTextGenerator.Invalidate();
        if (this.mTreatmentCount >= 5)
          this.mTreatmentCount = 5;
        for (int index = 0; index < this.mTreatmentCount; ++index)
        {
          this.m_UnitRS_Item[index].MaxValue = (long) this.m_SoldierMax[this.m_UnitRS_Item[index].m_ID];
          this.m_UnitRS_Item[index].Value = this.m_Soldier[this.m_UnitRS_Item[index].m_ID];
          this.m_UnitRS_Item[index].m_slider.maxValue = (double) this.m_SoldierMax[this.m_UnitRS_Item[index].m_ID];
          this.m_UnitRS_Item[index].m_slider.value = (double) this.m_Soldier[this.m_UnitRS_Item[index].m_ID];
          this.Cstr_ItemSliderQty[index].ClearString();
          StringManager.IntToStr(this.Cstr_ItemSliderQty[index], this.m_UnitRS_Item[index].Value, bNumber: true);
          this.m_UnitRS_Item[index].m_inputText.text = this.Cstr_ItemSliderQty[index].ToString();
          this.m_UnitRS_Item[index].m_inputText.SetAllDirty();
          this.m_UnitRS_Item[index].m_inputText.cachedTextGenerator.Invalidate();
        }
        this.SetDRformURS(false);
        break;
      case 1:
        if (this.bNOInjured)
          break;
        if (sender.m_BtnType == e_BtnType.e_Normal && GUIManager.Instance.ShowUILock(EUILock.Hospital))
        {
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          if (this.buildID == (ushort) 7)
          {
            this.DM.TreatmentQuantity = 0U;
            messagePacket.Protocol = Protocol._MSG_REQUEST_HEALINGTROOP;
            messagePacket.AddSeqId();
            for (int index1 = 0; index1 < 16; ++index1)
            {
              int index2 = (3 - index1 % 4) * 4 + index1 / 4;
              messagePacket.Add((uint) this.m_Soldier[index2]);
              this.DM.TreatmentQuantity += (uint) this.m_Soldier[index2];
            }
          }
          else
          {
            this.DM.Trap_TreatmentQuantity = 0U;
            messagePacket.Protocol = Protocol._MSG_REQUEST_REPAIRTRAP;
            messagePacket.AddSeqId();
            for (int index3 = 0; index3 < 12; ++index3)
            {
              int index4 = (3 - index3 % 4) * 3 + index3 / 4;
              messagePacket.Add((uint) this.m_Soldier[index4]);
              this.DM.Trap_TreatmentQuantity += (uint) this.m_Soldier[index4];
            }
          }
          messagePacket.Send();
        }
        else if (sender.m_BtnType == e_BtnType.e_ChangeText)
        {
          if (this.TreatmentNum == 0L)
            this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5701U), (ushort) byte.MaxValue);
          else
            this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4888U), (ushort) byte.MaxValue);
        }
        this.SetDRformURS(false);
        break;
      case 2:
        if (this.bNOInjured)
          break;
        if (this.TreatmentNum == 0L)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5701U), (ushort) byte.MaxValue);
          break;
        }
        if (!this.CheckDiamondToSend())
        {
          this.Cstr_Msg.ClearString();
          this.Cstr_Msg.StringToFormat(this.DM.mStringTable.GetStringByID(3880U));
          this.Cstr_Msg.AppendFormat(this.DM.mStringTable.GetStringByID(3857U));
          this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966U), this.Cstr_Msg.ToString(), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 3, bCloseIDSet: true);
          this.Cstr_Gemstone.ClearString();
          this.Cstr_Gemstone.IntToFormat((long) this.needDiamond, bNumber: true);
          this.Cstr_Gemstone.AppendFormat("{0}");
          this.text_Gemstone.text = this.Cstr_Gemstone.ToString();
          this.text_Gemstone.SetAllDirty();
          this.text_Gemstone.cachedTextGenerator.Invalidate();
          break;
        }
        if (sender.m_BtnType != e_BtnType.e_Normal)
          break;
        if (this.buildID == (ushort) 7)
        {
          if (this.GUIM.OpenCheckCrystal(this.needDiamond, (byte) 5, (int) this.m_eWindow << 16 | 100))
            break;
          this.SendInstHealing();
          break;
        }
        if (this.GUIM.OpenCheckCrystal(this.needDiamond, (byte) 5, (int) this.m_eWindow << 16 | 100))
          break;
        this.SendInstTrackFix();
        break;
      case 3:
        this.GUIM.OpenTechTree((ushort) 56);
        break;
      case 4:
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 5:
        ((Component) this.ImgDisbandblack).gameObject.SetActive(false);
        break;
      case 6:
        if (sender.m_BtnType != e_BtnType.e_Normal)
          break;
        if (this.buildID == (ushort) 7)
        {
          this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5772U), this.DM.mStringTable.GetStringByID(5773U), 6, YesText: this.DM.mStringTable.GetStringByID(4053U), NoText: this.DM.mStringTable.GetStringByID(4054U));
          break;
        }
        this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(3794U), this.DM.mStringTable.GetStringByID(3795U), 7, YesText: this.DM.mStringTable.GetStringByID(4053U), NoText: this.DM.mStringTable.GetStringByID(4054U));
        break;
      case 7:
        ushort num1 = (ushort) ((uint) this.ShowListIndex[((Component) sender).gameObject.transform.parent.GetComponent<ScrollPanelItem>().m_BtnID1] - 1U);
        this.tmpString.Length = 0;
        ushort InKey;
        uint num2;
        if (this.buildID == (ushort) 7)
        {
          InKey = (ushort) (4 - (int) num1 / 4 + (int) num1 % 4 * 4);
          num2 = this.DM.mSoldier_Hospital[(int) InKey - 1];
        }
        else
        {
          InKey = (ushort) (4 - (int) num1 / 3 + (int) num1 % 3 * 4 + 16);
          num2 = this.DM.mTrap_Hospital[(int) InKey - 17];
        }
        GameConstants.FormatValue(this.tmpString, num2);
        this.text_Disband_Num.text = this.tmpString.ToString();
        this.m_DisbandSlider.m_TotalText.text = this.tmpString.ToString();
        this.m_DisbandSlider.MaxValue = (long) num2;
        this.tmpSD = this.DM.SoldierDataTable.GetRecordByKey(InKey);
        this.mDisband_Kind = this.tmpSD.SoldierKind;
        this.mDisband_Rank = this.tmpSD.Tier;
        this.tmpString.Length = 0;
        this.tmpString.AppendFormat("q{0}", (object) this.tmpSD.Icon);
        this.ImgDisband_Item.sprite = this.GUIM.LoadSprite(this.AssetName_D, this.tmpString.ToString());
        this.text_Disband_Name.text = this.DM.mStringTable.GetStringByID((uint) this.tmpSD.Name);
        ushort index5 = 0;
        if (num2 / 1000U > 0U)
          index5 = num2 / 100000000U <= 0U ? (num2 / 10000000U <= 0U ? (num2 / 100000U <= 0U ? (ushort) 1 : (ushort) 2) : (ushort) 3) : (ushort) 4;
        this.DisbandSliderRT.anchoredPosition = new Vector2(this.Pos[(int) index5], this.DisbandSliderRT.anchoredPosition.y);
        this.DisbandSliderRT.sizeDelta = new Vector2(this.Width[(int) index5], this.DisbandSliderRT.sizeDelta.y);
        this.Cstr.ClearString();
        StringManager.IntToStr(this.Cstr, 0L, bNumber: true);
        this.m_DisbandSlider.m_slider.maxValue = (double) num2;
        this.m_DisbandSlider.m_slider.value = 0.0;
        this.m_DisbandSlider.m_inputText.text = this.Cstr.ToString();
        this.m_DisbandSlider.m_inputText.SetAllDirty();
        this.m_DisbandSlider.m_inputText.cachedTextGenerator.Invalidate();
        this.btn_Disband.ForTextChange(e_BtnType.e_ChangeText);
        ((Component) this.ImgDisbandblack).gameObject.SetActive(true);
        break;
      case 8:
        this.GUIM.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
        this.GUIM.m_UICalculator.OpenCalculator(this.m_UnitRS_Item[sender.m_BtnID2].MaxValue, this.m_UnitRS_Item[sender.m_BtnID2].Value, 270f, 0.0f, this.m_UnitRS_Item[sender.m_BtnID2], 0L);
        break;
      case 9:
        this.GUIM.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
        this.GUIM.m_UICalculator.OpenCalculator(this.m_DisbandSlider.MaxValue, this.m_DisbandSlider.Value, -283f, 0.0f, this.m_DisbandSlider, 0L);
        break;
    }
  }

  private void SendInstHealing()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Hospital))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_INSTANTHEALING;
    messagePacket.AddSeqId();
    for (int index1 = 0; index1 < this.Count; ++index1)
    {
      int index2 = (3 - index1 % 4) * 4 + index1 / 4;
      messagePacket.Add((uint) this.m_Soldier[index2]);
    }
    messagePacket.Send();
  }

  private void SendInstTrackFix()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Hospital))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_INSTANTREPAIRTRAP;
    messagePacket.AddSeqId();
    for (int index1 = 0; index1 < this.Count; ++index1)
    {
      int index2 = (3 - index1 % 4) * 3 + index1 / 4;
      messagePacket.Add((uint) this.m_Soldier[index2]);
    }
    messagePacket.Send();
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    int index = (int) this.ShowListIndex[dataIdx] - 1;
    if ((UnityEngine.Object) this.m_UnitRS_Item[panelObjectIdx] == (UnityEngine.Object) null)
    {
      item.GetComponent<ScrollPanelItem>().m_BtnID2 = panelObjectIdx;
      this.m_UnitRS_Item[panelObjectIdx] = item.transform.GetChild(1).GetComponent<UnitResourcesSlider>();
      this.m_UnitRS_Item[panelObjectIdx].m_Handler = (IUIUnitRSliderHandler) this;
      this.m_UnitRS_Item[panelObjectIdx].m_ID = index;
      this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = (double) this.m_SoldierMax[index];
      this.m_UnitRS_Item[panelObjectIdx].m_slider.value = (double) this.m_Soldier[index];
      this.btn_ItemInput[panelObjectIdx] = this.m_UnitRS_Item[panelObjectIdx].BtnInputText;
      this.btn_ItemInput[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.btn_ItemInput[panelObjectIdx].m_BtnID2 = panelObjectIdx;
      this.btn_Item[panelObjectIdx] = item.transform.GetChild(2).GetComponent<UIButton>();
      this.btn_Item[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Item[panelObjectIdx].m_BtnID1 = 7;
      this.Tmp = item.transform.GetChild(2).GetChild(0);
      this.Img_Soldier_Item[panelObjectIdx] = this.Tmp.GetComponent<Image>();
      this.Tmp = item.transform.GetChild(2).GetChild(1);
      this.Img_Soldier_ItemFrame[panelObjectIdx] = this.Tmp.GetComponent<Image>();
      ((MaskableGraphic) this.Img_Soldier_ItemFrame[panelObjectIdx]).material = this.FrameMaterial;
      this.Tmp = item.transform.GetChild(3).GetChild(0);
      this.text_Soldier_Item[panelObjectIdx] = this.Tmp.GetComponent<UIText>();
      this.text_Soldier_Item[panelObjectIdx].font = this.TTFont;
    }
    else
    {
      this.m_UnitRS_Item[panelObjectIdx].m_ID = index;
      if ((double) this.m_SoldierMax[index] < this.m_UnitRS_Item[panelObjectIdx].m_slider.value)
      {
        this.m_UnitRS_Item[panelObjectIdx].m_slider.value = (double) this.m_Soldier[index];
        this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = (double) this.m_SoldierMax[index];
      }
      else
      {
        this.m_UnitRS_Item[panelObjectIdx].m_slider.maxValue = (double) this.m_SoldierMax[index];
        this.m_UnitRS_Item[panelObjectIdx].m_slider.value = (double) this.m_Soldier[index];
      }
    }
    this.m_UnitRS_Item[panelObjectIdx].MaxValue = (long) this.m_SoldierMax[index];
    this.m_UnitRS_Item[panelObjectIdx].Value = this.m_Soldier[index];
    this.Cstr_SliderMaxQty[panelObjectIdx].ClearString();
    this.Cstr_SliderMaxQty[panelObjectIdx].IntToFormat((long) this.m_SoldierMax[index], bNumber: true);
    this.Cstr_SliderMaxQty[panelObjectIdx].AppendFormat("{0}");
    this.m_UnitRS_Item[panelObjectIdx].m_TotalText.text = this.Cstr_SliderMaxQty[panelObjectIdx].ToString();
    this.m_UnitRS_Item[panelObjectIdx].m_TotalText.SetAllDirty();
    this.m_UnitRS_Item[panelObjectIdx].m_TotalText.cachedTextGenerator.Invalidate();
    this.Img_Soldier_Item[panelObjectIdx].sprite = this.m_SoldierSprite[index];
    this.Img_Soldier_ItemFrame[panelObjectIdx].sprite = this.m_SoldierSpriteFrame[index];
    this.text_Soldier_Item[panelObjectIdx].text = this.m_SoldierName[index];
    this.Cstr_ItemSliderQty[panelObjectIdx].ClearString();
    this.Cstr_ItemSliderQty[panelObjectIdx].IntToFormat(this.m_Soldier[index], bNumber: true);
    this.Cstr_ItemSliderQty[panelObjectIdx].AppendFormat("{0}");
    this.m_UnitRS_Item[panelObjectIdx].m_inputText.text = this.Cstr_ItemSliderQty[panelObjectIdx].ToString();
    this.m_UnitRS_Item[panelObjectIdx].m_inputText.SetAllDirty();
    this.m_UnitRS_Item[panelObjectIdx].m_inputText.cachedTextGenerator.Invalidate();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 1:
        if (!GUIManager.Instance.ShowUILock(EUILock.Hospital))
          break;
        MessagePacket messagePacket1 = new MessagePacket((ushort) 1024);
        messagePacket1.Protocol = Protocol._MSG_REQUEST_CANCELHEALING;
        messagePacket1.AddSeqId();
        messagePacket1.Send();
        break;
      case 2:
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 13);
        break;
      case 3:
        MallManager.Instance.Send_Mall_Info();
        break;
      case 4:
        if (!GUIManager.Instance.ShowUILock(EUILock.Hospital))
          break;
        MessagePacket messagePacket2 = new MessagePacket((ushort) 1024);
        messagePacket2.Protocol = Protocol._MSG_REQUEST_CANCELHEALING;
        messagePacket2.AddSeqId();
        messagePacket2.Send();
        break;
      case 5:
        if (!GUIManager.Instance.ShowUILock(EUILock.Hospital))
          break;
        MessagePacket messagePacket3 = new MessagePacket((ushort) 1024);
        messagePacket3.Protocol = Protocol._MSG_REQUEST_CANCELREPAIRTRAP;
        messagePacket3.AddSeqId();
        messagePacket3.Send();
        break;
      case 6:
        if (!GUIManager.Instance.ShowUILock(EUILock.Hospital))
          break;
        byte mDisbandKind1 = this.mDisband_Kind;
        MessagePacket messagePacket4 = new MessagePacket((ushort) 1024);
        messagePacket4.Protocol = Protocol._MSG_REQUEST_GIVEUP_HEALING;
        messagePacket4.AddSeqId();
        messagePacket4.Add(mDisbandKind1);
        messagePacket4.Add((byte) ((uint) this.mDisband_Rank - 1U));
        messagePacket4.Add((uint) this.m_DisbandSlider.Value);
        messagePacket4.Send();
        ((Component) this.ImgDisbandblack).gameObject.SetActive(false);
        break;
      case 7:
        if (!GUIManager.Instance.ShowUILock(EUILock.Hospital))
          break;
        byte mDisbandKind2 = this.mDisband_Kind;
        MessagePacket messagePacket5 = new MessagePacket((ushort) 1024);
        messagePacket5.Protocol = Protocol._MSG_REQUEST_GIVEUP_TRAP_REPAIR;
        byte data = (byte) ((uint) mDisbandKind2 - 4U);
        messagePacket5.AddSeqId();
        messagePacket5.Add(data);
        messagePacket5.Add((byte) ((uint) this.mDisband_Rank - 1U));
        messagePacket5.Add((uint) this.m_DisbandSlider.Value);
        messagePacket5.Send();
        ((Component) this.ImgDisbandblack).gameObject.SetActive(false);
        break;
    }
  }

  public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
  {
    URS.m_slider.value = (double) mValue;
    URS.SliderValueChange();
  }

  private void Start()
  {
    if (this.buildID == (ushort) 12)
      return;
    this.baseBuild = this.transform.gameObject.AddComponent<BuildingWindow>();
    this.baseBuild.m_Handler = (IBuildingWindowType) this;
    this.baseBuild.InitBuildingWindow((byte) 7, (ushort) this.B_ID, (byte) 1, this.B_ID >= this.GUIM.BuildingData.AllBuildsData.Length ? (byte) 0 : this.GUIM.BuildingData.AllBuildsData[this.B_ID].Level);
    this.baseBuild.baseTransform.SetAsFirstSibling();
  }

  public override void OnClose()
  {
    if ((UnityEngine.Object) this.baseBuild != (UnityEngine.Object) null)
      this.baseBuild.DestroyBuildingWindow();
    if (this.AssetName != null)
      GUIManager.Instance.RemoveSpriteAsset(this.AssetName);
    if (this.AssetName1 != null)
      GUIManager.Instance.RemoveSpriteAsset(this.AssetName1);
    if (this.AssetName_D != null)
      GUIManager.Instance.RemoveSpriteAsset(this.AssetName_D);
    this.tmplist = (List<float>) null;
    if (this.Cstr != null)
      StringManager.Instance.DeSpawnString(this.Cstr);
    if (this.Cstr_SliderQty != null)
      StringManager.Instance.DeSpawnString(this.Cstr_SliderQty);
    if (this.Cstr_Gemstone != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Gemstone);
    if (this.Cstr_Time != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Time);
    if (this.Cstr_TimeBar != null)
      StringManager.Instance.DeSpawnString(this.Cstr_TimeBar);
    if (this.Cstr_Msg != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Msg);
    for (int index = 0; index < 2; ++index)
    {
      if (this.Cstr_TrapNum[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_TrapNum[index]);
      if (this.Cstr_InjuredTroop[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_InjuredTroop[index]);
    }
    for (int index = 0; index < 5; ++index)
    {
      if (this.Cstr_SliderMaxQty[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_SliderMaxQty[index]);
      if (this.Cstr_ItemSliderQty[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemSliderQty[index]);
    }
    if (!this.DM.bSetExpediton)
    {
      this.DM.mScroll_Idx = 0;
      this.DM.mScroll_Y = 0.0f;
    }
    else
    {
      this.DM.mScroll_Idx = this.m_ScrollPanel.GetTopIdx();
      for (int index = 0; index < 16; ++index)
        this.DM.mExpeditionSoldierList[index] = (uint) this.m_Soldier[index];
    }
    this.GUIM.RemoverTimeBaarToList(this.timeBar);
    this.GUIM.ClearCalculator();
  }

  public void OnTimer(UITimeBar sender)
  {
    if (!((UnityEngine.Object) this.timeBar != (UnityEngine.Object) null))
      return;
    this.timeBar.gameObject.SetActive(false);
  }

  public void OnNotify(UITimeBar sender)
  {
  }

  public void RefreshSoldierUI()
  {
    this.tmplist.Clear();
    this.mTreatmentCount = 0;
    this.InjuredNum = 0U;
    this.bNOInjured = true;
    if (this.buildID == (ushort) 7)
    {
      for (int index = 0; index < 16; ++index)
      {
        this.m_Soldier[index] = (long) this.DM.mExpeditionSoldierList[index];
        ushort num = (ushort) (4 - index / 4 + index % 4 * 4);
        this.m_SoldierMax[index] = this.DM.mSoldier_Hospital[(int) num - 1];
        if (this.m_Soldier[index] > (long) this.m_SoldierMax[index])
        {
          this.m_Soldier[index] = (long) this.m_SoldierMax[index];
          this.DM.mExpeditionSoldierList[index] = (uint) this.m_Soldier[index];
        }
        this.InjuredNum += this.DM.mSoldier_Hospital[(int) num - 1];
        if (this.m_SoldierMax[index] > 0U)
        {
          this.ShowListIndex[this.mTreatmentCount] = (byte) (index + 1);
          ++this.mTreatmentCount;
          this.tmplist.Add(91f);
          if (this.bNOInjured)
            this.bNOInjured = false;
        }
      }
      this.m_ScrollPanel.AddNewDataHeight(this.tmplist);
    }
    else
    {
      for (int index = 0; index < 12; ++index)
      {
        this.m_Soldier[index] = (long) this.DM.mExpeditionSoldierList[index];
        ushort num = (ushort) (4 - index / 3 + index % 3 * 4);
        this.m_SoldierMax[index] = this.DM.mTrap_Hospital[(int) num - 1];
        if (this.m_Soldier[index] > (long) this.m_SoldierMax[index])
        {
          this.m_Soldier[index] = (long) this.m_SoldierMax[index];
          this.DM.mExpeditionSoldierList[index] = (uint) this.m_Soldier[index];
        }
        this.InjuredNum += this.DM.mTrap_Hospital[(int) num - 1];
        if (this.m_SoldierMax[index] > 0U)
        {
          this.ShowListIndex[this.mTreatmentCount] = (byte) (index + 1);
          ++this.mTreatmentCount;
          this.tmplist.Add(91f);
          if (this.bNOInjured)
            this.bNOInjured = false;
        }
      }
      this.m_ScrollPanel.AddNewDataHeight(this.tmplist);
    }
    if (this.bNOInjured && (UnityEngine.Object) this.baseBuild != (UnityEngine.Object) null && (this.baseBuild.buildType == e_BuildType.Normal || this.baseBuild.buildType == e_BuildType.SelfUpgradeing || this.baseBuild.buildType == e_BuildType.SelfBackOuting))
      ((Component) this.text_NoNeedTreatment).gameObject.SetActive(true);
    else
      ((Component) this.text_NoNeedTreatment).gameObject.SetActive(false);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_Hospital:
        this.RefreshSoldierUI();
        break;
      case NetworkNews.Refresh_BuildBase:
        if (meg[1] == (byte) 1)
        {
          this.door.CloseMenu(true);
          break;
        }
        if (!((UnityEngine.Object) this.baseBuild != (UnityEngine.Object) null))
          break;
        this.baseBuild.MyUpdate(meg[1]);
        break;
      case NetworkNews.Refresh_AttribEffectVal:
        if (this.buildID == (ushort) 7)
        {
          this.tmpEGA = 10000f / (float) (10000U + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_HOSPITAL_HEALING_SPEED));
          this.HospitalNum = this.GetHospitalMaxCapacity();
        }
        else
        {
          this.HospitalNum = this.GetTrapCapacity();
          this.UpdateTarpMax();
        }
        if ((UnityEngine.Object) this.baseBuild != (UnityEngine.Object) null)
          this.baseBuild.MyUpdate((byte) 0);
        this.SetDRformURS(false);
        break;
      default:
        switch (networkNews)
        {
          case NetworkNews.Login:
          case NetworkNews.Refresh:
            if ((UnityEngine.Object) this.baseBuild != (UnityEngine.Object) null)
              this.baseBuild.MyUpdate((byte) 0);
            this.RefreshSoldierUI();
            this.SetDRformURS(true);
            return;
          default:
            if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
              return;
            this.Refresh_FontTexture();
            if ((UnityEngine.Object) this.baseBuild != (UnityEngine.Object) null)
              this.baseBuild.Refresh_FontTexture();
            if ((UnityEngine.Object) this.m_DResources != (UnityEngine.Object) null)
              this.m_DResources.Refresh_FontTexture();
            if ((UnityEngine.Object) this.m_UnitRS != (UnityEngine.Object) null)
              this.m_UnitRS.Refresh_FontTexture();
            if ((UnityEngine.Object) this.m_DisbandSlider != (UnityEngine.Object) null)
              this.m_DisbandSlider.Refresh_FontTexture();
            for (int index = 0; index < 5; ++index)
            {
              if ((UnityEngine.Object) this.m_UnitRS_Item[index] != (UnityEngine.Object) null)
                this.m_UnitRS_Item[index].Refresh_FontTexture();
            }
            if (!((UnityEngine.Object) this.timeBar != (UnityEngine.Object) null) || !this.timeBar.enabled)
              return;
            this.timeBar.Refresh_FontTexture();
            return;
        }
    }
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.text_ALL != (UnityEngine.Object) null && ((Behaviour) this.text_ALL).enabled)
    {
      ((Behaviour) this.text_ALL).enabled = false;
      ((Behaviour) this.text_ALL).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Treatment != (UnityEngine.Object) null && ((Behaviour) this.text_Treatment).enabled)
    {
      ((Behaviour) this.text_Treatment).enabled = false;
      ((Behaviour) this.text_Treatment).enabled = true;
    }
    if ((UnityEngine.Object) this.text_TreatmentCompleted != (UnityEngine.Object) null && ((Behaviour) this.text_TreatmentCompleted).enabled)
    {
      ((Behaviour) this.text_TreatmentCompleted).enabled = false;
      ((Behaviour) this.text_TreatmentCompleted).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Gemstone != (UnityEngine.Object) null && ((Behaviour) this.text_Gemstone).enabled)
    {
      ((Behaviour) this.text_Gemstone).enabled = false;
      ((Behaviour) this.text_Gemstone).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Time != (UnityEngine.Object) null && ((Behaviour) this.text_Time).enabled)
    {
      ((Behaviour) this.text_Time).enabled = false;
      ((Behaviour) this.text_Time).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Slider != (UnityEngine.Object) null && ((Behaviour) this.text_Slider).enabled)
    {
      ((Behaviour) this.text_Slider).enabled = false;
      ((Behaviour) this.text_Slider).enabled = true;
    }
    if ((UnityEngine.Object) this.text_NoNeedTreatment != (UnityEngine.Object) null && ((Behaviour) this.text_NoNeedTreatment).enabled)
    {
      ((Behaviour) this.text_NoNeedTreatment).enabled = false;
      ((Behaviour) this.text_NoNeedTreatment).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Treatmenting != (UnityEngine.Object) null && ((Behaviour) this.text_Treatmenting).enabled)
    {
      ((Behaviour) this.text_Treatmenting).enabled = false;
      ((Behaviour) this.text_Treatmenting).enabled = true;
    }
    if ((UnityEngine.Object) this.text_TrapTotal != (UnityEngine.Object) null && ((Behaviour) this.text_TrapTotal).enabled)
    {
      ((Behaviour) this.text_TrapTotal).enabled = false;
      ((Behaviour) this.text_TrapTotal).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Disband_Name != (UnityEngine.Object) null && ((Behaviour) this.text_Disband_Name).enabled)
    {
      ((Behaviour) this.text_Disband_Name).enabled = false;
      ((Behaviour) this.text_Disband_Name).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Disband_Num != (UnityEngine.Object) null && ((Behaviour) this.text_Disband_Num).enabled)
    {
      ((Behaviour) this.text_Disband_Num).enabled = false;
      ((Behaviour) this.text_Disband_Num).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Disband_Title != (UnityEngine.Object) null && ((Behaviour) this.text_Disband_Title).enabled)
    {
      ((Behaviour) this.text_Disband_Title).enabled = false;
      ((Behaviour) this.text_Disband_Title).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Disband != (UnityEngine.Object) null && ((Behaviour) this.text_Disband).enabled)
    {
      ((Behaviour) this.text_Disband).enabled = false;
      ((Behaviour) this.text_Disband).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((UnityEngine.Object) this.text_TrapNum[index] != (UnityEngine.Object) null && ((Behaviour) this.text_TrapNum[index]).enabled)
      {
        ((Behaviour) this.text_TrapNum[index]).enabled = false;
        ((Behaviour) this.text_TrapNum[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_timeBar[index] != (UnityEngine.Object) null && ((Behaviour) this.text_timeBar[index]).enabled)
      {
        ((Behaviour) this.text_timeBar[index]).enabled = false;
        ((Behaviour) this.text_timeBar[index]).enabled = true;
      }
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((UnityEngine.Object) this.text_InjuredTroops[index] != (UnityEngine.Object) null && ((Behaviour) this.text_InjuredTroops[index]).enabled)
      {
        ((Behaviour) this.text_InjuredTroops[index]).enabled = false;
        ((Behaviour) this.text_InjuredTroops[index]).enabled = true;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((UnityEngine.Object) this.text_Soldier_Item[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Soldier_Item[index]).enabled)
      {
        ((Behaviour) this.text_Soldier_Item[index]).enabled = false;
        ((Behaviour) this.text_Soldier_Item[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_tmpStr[index] != (UnityEngine.Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (this.buildID == (ushort) 7 && (UnityEngine.Object) this.baseBuild == (UnityEngine.Object) null)
      return;
    switch (arg1)
    {
      case 1:
        this.HospitalNum = 0U;
        if (this.buildID == (ushort) 7)
        {
          this.HospitalNum = this.GetHospitalMaxCapacity();
          ((Component) this.text_InjuredTroops[1]).gameObject.SetActive(true);
          this.Cstr_InjuredTroop[0].ClearString();
          this.Cstr_InjuredTroop[0].IntToFormat((long) this.InjuredNum, bNumber: true);
          this.Cstr_InjuredTroop[0].AppendFormat("{0}");
          this.text_InjuredTroops[1].text = this.Cstr_InjuredTroop[0].ToString();
          this.text_InjuredTroops[1].SetAllDirty();
          this.text_InjuredTroops[1].cachedTextGenerator.Invalidate();
          this.Cstr_InjuredTroop[1].ClearString();
          this.Cstr_InjuredTroop[1].IntToFormat((long) this.HospitalNum, bNumber: true);
          if (this.GUIM.IsArabic)
            this.Cstr_InjuredTroop[1].AppendFormat("{0} / ");
          else
            this.Cstr_InjuredTroop[1].AppendFormat(" / {0}");
          this.text_InjuredTroops[2].text = this.Cstr_InjuredTroop[1].ToString();
          this.text_InjuredTroops[2].SetAllDirty();
          this.text_InjuredTroops[2].cachedTextGenerator.Invalidate();
          this.baseBuild.MyUpdate((byte) 0);
        }
        else if (this.buildID == (ushort) 12)
        {
          this.HospitalNum = this.GetTrapCapacity();
          this.Cstr_TrapNum[0].ClearString();
          this.Cstr_TrapNum[0].IntToFormat((long) this.DM.TrapHospitalTotal, bNumber: true);
          this.Cstr_TrapNum[0].AppendFormat("{0}");
          this.text_TrapNum[0].text = this.Cstr_TrapNum[0].ToString();
          this.text_TrapNum[0].SetAllDirty();
          this.text_TrapNum[0].cachedTextGenerator.Invalidate();
          this.Cstr_TrapNum[1].ClearString();
          this.Cstr_TrapNum[1].IntToFormat((long) this.HospitalNum, bNumber: true);
          if (this.GUIM.IsArabic)
            this.Cstr_TrapNum[1].AppendFormat("{0} / ");
          else
            this.Cstr_TrapNum[1].AppendFormat(" / {0}");
          this.text_TrapNum[1].text = this.Cstr_TrapNum[1].ToString();
          this.text_TrapNum[1].SetAllDirty();
          this.text_TrapNum[1].cachedTextGenerator.Invalidate();
        }
        if (this.InjuredNum != 0U)
          break;
        this.btn_ALL.ForTextChange(e_BtnType.e_ChangeText);
        this.bNOInjured = true;
        break;
      case 2:
        this.bTreatmenting = true;
        if (!this.bTreatmenting)
          break;
        ((Component) this.Img_Treatment).gameObject.SetActive(true);
        if (this.buildID == (ushort) 7)
        {
          if (this.DM.queueBarData[13].bActive)
          {
            this.begin = this.DM.queueBarData[13].StartTime;
            this.target = this.begin + (long) this.DM.queueBarData[13].TotalTime;
            this.notify = 0L;
            uint x = 0;
            for (int index = 0; index < this.Count; ++index)
              x += this.DM.mTreatmentSoldier[index];
            this.Cstr_TimeBar.ClearString();
            this.Cstr_TimeBar.IntToFormat((long) x, bNumber: true);
            this.Cstr_TimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(4046U));
            this.GUIM.SetTimerBar(this.timeBar, this.begin, this.target, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(4045U), this.Cstr_TimeBar.ToString());
            this.timeBar.gameObject.SetActive(true);
            this.text_Treatmenting.text = this.DM.mStringTable.GetStringByID(3814U);
          }
        }
        else if (this.DM.queueBarData[15].bActive)
        {
          this.begin = this.DM.queueBarData[15].StartTime;
          this.target = this.begin + (long) this.DM.queueBarData[15].TotalTime;
          this.notify = 0L;
          this.Cstr_TimeBar.ClearString();
          this.Cstr_TimeBar.IntToFormat((long) this.DM.Trap_TreatmentQuantity, bNumber: true);
          this.Cstr_TimeBar.AppendFormat(this.DM.mStringTable.GetStringByID(1047U));
          this.GUIM.SetTimerBar(this.timeBar, this.begin, this.target, this.notify, eTimeBarType.CancelType, this.DM.mStringTable.GetStringByID(1046U), this.Cstr_TimeBar.ToString());
          this.timeBar.gameObject.SetActive(true);
          this.text_Treatmenting.text = this.DM.mStringTable.GetStringByID(1045U);
        }
        ((Component) this.text_Treatmenting).gameObject.SetActive(true);
        break;
      case 3:
        this.bTreatmenting = false;
        ((Component) this.Img_Treatment).gameObject.SetActive(false);
        this.timeBar.gameObject.SetActive(false);
        ((Component) this.text_Treatmenting).gameObject.SetActive(false);
        break;
      case 4:
        this.UpdateTarpMax();
        break;
      case 100:
        if (this.buildID == (ushort) 7)
        {
          this.SendInstHealing();
          break;
        }
        this.SendInstTrackFix();
        break;
    }
  }

  public void Onfunc(UITimeBar sender)
  {
    if (sender.m_TimerSpriteType != eTimerSpriteType.Speed)
      return;
    if (this.buildID == (ushort) 7)
      this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 13);
    else
      this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 15);
  }

  public void OnCancel(UITimeBar sender)
  {
    if (this.buildID == (ushort) 7)
      this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4993U), this.DM.mStringTable.GetStringByID(4994U), 4, YesText: this.DM.mStringTable.GetStringByID(4995U), NoText: this.DM.mStringTable.GetStringByID(4996U));
    else
      this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(3785U), this.DM.mStringTable.GetStringByID(3786U), 5, YesText: this.DM.mStringTable.GetStringByID(4995U), NoText: this.DM.mStringTable.GetStringByID(4996U));
  }
}
