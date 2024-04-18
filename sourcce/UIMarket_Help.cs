// Decompiled with JetBrains decompiler
// Type: UIMarket_Help
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIMarket_Help : 
  GUIWindow,
  IUIButtonClickHandler,
  IUICalculatorHandler,
  IUIUnitRSliderHandler
{
  private Transform m_transform;
  private Transform m_DResourcesT;
  private CString NameStr;
  private CString TaxStr;
  private CString TaxStr2;
  private CString LoadingStr2;
  private CString TimeStr;
  private CString BootsStr;
  private CString[] ResourcesStr = new CString[5];
  private UIText HelpButtonText;
  private UIText TaxText;
  private UIText LoadingText;
  private UIText LTaxText;
  private UIText AddSpeedText;
  private UIText TotalTimeText;
  private UIButton HelpButton;
  private DemandResources m_DResources;
  private UnitResourcesSlider[] m_Slider = new UnitResourcesSlider[5];
  private int OpenIndex = -1;
  private RoleBuildingData mBD;
  private BuildLevelRequest mBR;
  private GUIManager GM;
  private DataManager DM;
  private StringManager SM;
  private StringTable ST;
  private long[] lResource = new long[5];
  private long[] lTaxResource = new long[5];
  private long[] lSendResource = new long[5];
  private double Tax;
  private long TotalTax;
  private long TotalLoading;
  private long LoadingMax;
  private long TotalSend;
  private Door door;
  private PointCode DesPoint;
  private bool bOpen;
  private bool bOpenOkCancelBox;
  private UIText[] RBText = new UIText[8];

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.SM = StringManager.Instance;
    this.GM = GUIManager.Instance;
    this.ST = this.DM.mStringTable;
    Font ttfFont = this.GM.GetTTFFont();
    this.m_transform = this.transform;
    this.door = this.GM.FindMenu(EGUIWindow.Door) as Door;
    byte num = 1;
    ushort HIID = 1;
    this.NameStr = this.SM.SpawnString();
    switch (arg1)
    {
      case 1:
        PlayerPoint playerPoint = DataManager.MapDataController.PlayerPointTable[(int) DataManager.MapDataController.LayoutMapInfo[arg2].tableID];
        this.NameStr.Append(playerPoint.playerName);
        num = playerPoint.allianceRank;
        HIID = playerPoint.portraitID;
        GameConstants.MapIDToPointCode(arg2, out this.DesPoint.zoneID, out this.DesPoint.pointID);
        break;
      case 2:
        AllianceMemberClientDataType memberClientDataType = this.DM.AllianceMember[arg2];
        this.NameStr.Append(memberClientDataType.Name);
        num = (byte) memberClientDataType.Rank;
        HIID = memberClientDataType.Head;
        this.DesPoint = this.DM.AllyMemberLoc;
        break;
      case 3:
        this.NameStr.Append(this.DM.mLordProfile.PlayerName);
        num = this.DM.mLordProfile.AlliRank;
        HIID = this.DM.mLordProfile.Head;
        this.DesPoint = this.DM.AllyMemberLoc;
        break;
      default:
        this.NameStr.Append("TestHelpName");
        break;
    }
    this.mBD = this.GM.BuildingData.GetBuildData((ushort) 17, (ushort) 0);
    this.mBR = this.GM.BuildingData.GetBuildLevelRequestData((ushort) 17, this.mBD.Level);
    UIButton component1 = this.m_transform.GetChild(9).GetChild(0).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 1;
    this.HelpButton = this.m_transform.GetChild(10).GetComponent<UIButton>();
    this.HelpButton.m_Handler = (IUIButtonClickHandler) this;
    this.HelpButton.m_BtnID1 = 2;
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(9).GetComponent<Image>()).enabled = false;
    this.RBText[5] = this.m_transform.GetChild(11).GetComponent<UIText>();
    this.RBText[5].font = ttfFont;
    this.RBText[5].text = this.DM.mStringTable.GetStringByID(4040U);
    this.HelpButtonText = ((Component) this.HelpButton).transform.GetChild(0).GetComponent<UIText>();
    this.HelpButtonText.font = ttfFont;
    this.HelpButtonText.text = this.DM.mStringTable.GetStringByID(4039U);
    this.HelpButton.m_Text = this.HelpButtonText;
    this.HelpButton.ForTextChange(e_BtnType.e_ChangeText);
    this.RBText[6] = this.m_transform.GetChild(12).GetComponent<UIText>();
    this.RBText[6].font = ttfFont;
    this.RBText[6].text = this.NameStr.ToString();
    this.m_transform.GetChild(3).GetComponent<UISpritesArray>().SetSpriteIndex((int) num - 1);
    if (this.GM.IsArabic)
      this.m_transform.GetChild(3).localScale = new Vector3(-1f, 1f, 1f);
    GUIManager.Instance.InitianHeroItemImg(this.m_transform.GetChild(4), eHeroOrItem.Hero, HIID, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.LTaxText = this.m_transform.GetChild(13).GetComponent<UIText>();
    this.LTaxText.font = ttfFont;
    this.TaxStr = this.SM.SpawnString();
    this.TaxText = this.m_transform.GetChild(14).GetComponent<UIText>();
    this.TaxText.font = ttfFont;
    this.TaxStr2 = this.SM.SpawnString();
    this.TaxStr2.Length = 0;
    StringManager.IntToStr(this.TaxStr2, 0L);
    this.TaxText.text = this.TaxStr2.ToString();
    this.RBText[7] = this.m_transform.GetChild(15).GetComponent<UIText>();
    this.RBText[7].font = ttfFont;
    this.RBText[7].text = this.DM.mStringTable.GetStringByID(4038U);
    this.LoadingMax = this.GetMaxLoading();
    this.LoadingText = this.m_transform.GetChild(16).GetComponent<UIText>();
    this.LoadingText.font = ttfFont;
    this.LoadingStr2 = this.SM.SpawnString();
    this.RefreshTax();
    this.AddSpeedText = this.m_transform.GetChild(18).GetComponent<UIText>();
    this.AddSpeedText.font = ttfFont;
    this.BootsStr = this.SM.SpawnString();
    this.TotalTimeText = this.m_transform.GetChild(17).GetComponent<UIText>();
    this.TotalTimeText.font = ttfFont;
    this.TimeStr = this.SM.SpawnString();
    this.RefreshSpeed();
    this.m_DResourcesT = this.m_transform.GetChild(19);
    this.m_DResources = this.m_DResourcesT.GetComponent<DemandResources>();
    this.GM.InitDemandResources(this.m_DResourcesT, 489f, 100f);
    for (int index = 0; index < 5; ++index)
      this.m_DResources.TextResources[index].fontSize = 14;
    this.GM.SetDemandResourcesText(this.m_DResources.GetComponent<Transform>(), this.lSendResource);
    Transform child1 = this.m_transform.GetChild(20).GetChild(0);
    for (int index = 0; index < 5; ++index)
    {
      this.lResource[index] = (long) this.DM.Resource[index].Stock;
      this.ResourcesStr[index] = this.SM.SpawnString();
      Transform child2 = child1.GetChild(index);
      Transform child3 = child2.GetChild(0);
      Image component2 = child3.GetChild(0).GetComponent<Image>();
      component2.sprite = this.GM.m_ItemIconSpriteAsset.LoadSprite((ushort) (1001 + index));
      ((MaskableGraphic) component2).material = this.GM.m_ItemIconSpriteAsset.GetMaterial();
      Image component3 = child3.GetChild(1).GetComponent<Image>();
      ((MaskableGraphic) component3).material = this.GM.GetFrameMaterial();
      component3.sprite = this.GM.LoadFrameSprite("if001");
      this.RBText[index] = child2.GetChild(1).GetComponent<UIText>();
      this.RBText[index].font = ttfFont;
      this.RBText[index].text = this.DM.mStringTable.GetStringByID((uint) (3952 + index));
      Transform child4 = child2.GetChild(2);
      this.GM.InitUnitResourcesSlider(child4, eUnitSlider.MarketHelp, 0U, (uint) this.lResource[index], 0.7f);
      this.m_Slider[index] = child4.GetComponent<UnitResourcesSlider>();
      this.m_Slider[index].m_Handler = (IUIUnitRSliderHandler) this;
      this.m_Slider[index].m_ID = index;
      this.m_Slider[index].BtnInputText.m_Handler = (IUIButtonClickHandler) this;
      this.m_Slider[index].BtnInputText.m_BtnID1 = 3;
      this.m_Slider[index].BtnInputText.m_BtnID2 = index;
      this.GM.SetUnitResourcesSliderSize(child4, eUnitSliderSize.Input, 85f, 26f, 110f, 26f, 0.0f, 0.0f);
    }
    if (this.GM.m_OpenResourceMenu)
    {
      for (int index = 0; index < 5; ++index)
      {
        if (this.GM.m_SaveResource[index] > 0U)
        {
          this.CheckResource(index, (long) this.GM.m_SaveResource[index]);
          this.SetSlider(index, (long) this.GM.m_SaveResource[index]);
        }
      }
    }
    else
      this.GM.m_OpenResourceMenu = true;
    this.RefreshResource();
    this.GM.UpdateUI(EGUIWindow.Door, 1, 2);
    this.bOpen = true;
  }

  public override void OnClose()
  {
    if (this.NameStr != null)
      StringManager.Instance.DeSpawnString(this.NameStr);
    if (this.TaxStr != null)
      StringManager.Instance.DeSpawnString(this.TaxStr);
    if (this.TaxStr2 != null)
      StringManager.Instance.DeSpawnString(this.TaxStr2);
    if (this.LoadingStr2 != null)
      StringManager.Instance.DeSpawnString(this.LoadingStr2);
    if (this.TimeStr != null)
      StringManager.Instance.DeSpawnString(this.TimeStr);
    if (this.BootsStr != null)
      StringManager.Instance.DeSpawnString(this.BootsStr);
    for (int index = 0; index < 5; ++index)
    {
      if (this.ResourcesStr[index] != null)
        StringManager.Instance.DeSpawnString(this.ResourcesStr[index]);
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    this.bOpenOkCancelBox = false;
    if (!bOK)
      return;
    int num = 0;
    uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    for (int index = 0; index < 8; ++index)
    {
      if (this.DM.MarchEventData[index].Type != EMarchEventType.EMET_Standby)
        ++num;
    }
    if ((long) num >= (long) effectBaseVal)
    {
      this.GM.MsgStr.Length = 0;
      this.GM.MsgStr.IntToFormat((long) effectBaseVal);
      this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(3959U));
      this.GM.OpenMessageBox(this.ST.GetStringByID(3967U), this.GM.MsgStr.ToString(), this.ST.GetStringByID(4034U));
    }
    else if (this.GM.BuildingData.GetBuildData((ushort) 17, (ushort) 0).Level <= (byte) 0)
    {
      this.GM.OpenMessageBox(this.ST.GetStringByID(4834U), this.ST.GetStringByID(4835U), this.ST.GetStringByID(4836U));
    }
    else
    {
      bool flag = true;
      for (int index = 0; index < 5; ++index)
      {
        if (this.lSendResource[index] > 0L)
          flag = false;
      }
      if (flag)
        this.GM.OpenMessageBox(this.ST.GetStringByID(4829U), this.ST.GetStringByID(3870U), this.ST.GetStringByID(4831U));
      else
        this.SendHelp();
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.door.CloseMenu();
        switch (arg2)
        {
          case 0:
            for (int index = 0; index < 5; ++index)
              this.GM.m_SaveResource[index] = 0U;
            this.GM.m_OpenResourceMenu = false;
            return;
          case 1:
            this.GM.MsgStr.Length = 0;
            this.GM.MsgStr.IntToFormat((long) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM));
            this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(3959U));
            this.GM.OpenMessageBox(this.ST.GetStringByID(3967U), this.GM.MsgStr.ToString(), this.ST.GetStringByID(4034U));
            goto case 0;
          case 4:
            this.GM.OpenMessageBox(this.ST.GetStringByID(5715U), this.ST.GetStringByID(5716U), this.ST.GetStringByID(5717U));
            goto case 0;
          case 5:
            this.GM.OpenMessageBox(this.ST.GetStringByID(4032U), this.ST.GetStringByID(3957U), this.ST.GetStringByID(4033U));
            goto case 0;
          case 6:
            this.GM.OpenMessageBox(this.ST.GetStringByID(4834U), this.ST.GetStringByID(4835U), this.ST.GetStringByID(4836U));
            goto case 0;
          case 8:
            this.GM.OpenMessageBox(this.ST.GetStringByID(4829U), this.ST.GetStringByID(3870U), this.ST.GetStringByID(4831U));
            goto case 0;
          case 11:
            this.GM.OpenMessageBox(this.ST.GetStringByID(4829U), this.ST.GetStringByID(5920U), this.ST.GetStringByID(4831U));
            goto case 0;
          default:
            this.GM.MsgStr.Length = 0;
            this.GM.MsgStr.IntToFormat((long) arg2);
            this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(12068U));
            this.GM.OpenMessageBox(this.ST.GetStringByID(4829U), this.GM.MsgStr.ToString(), this.ST.GetStringByID(4831U));
            goto case 0;
        }
      case 2:
        this.RefreshTax();
        this.RefreshResource();
        this.RefreshSpeed();
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (!this.bOpen)
      return;
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_BuildBase:
        this.RefreshTax();
        this.RefreshResource();
        break;
      case NetworkNews.Refresh_Technology:
        this.RefreshTax();
        this.RefreshResource();
        this.RefreshSpeed();
        break;
      default:
        switch (networkNews)
        {
          case NetworkNews.Login:
            this.RefreshTax();
            this.RefreshResource();
            this.RefreshSpeed();
            return;
          case NetworkNews.Refresh_Resource:
            this.RefreshResource(true);
            return;
          case NetworkNews.Refresh_BuffList:
            this.RefreshSpeed();
            return;
          case NetworkNews.Refresh_FontTextureRebuilt:
            if ((UnityEngine.Object) this.HelpButtonText != (UnityEngine.Object) null && ((Behaviour) this.HelpButtonText).enabled)
            {
              ((Behaviour) this.HelpButtonText).enabled = false;
              ((Behaviour) this.HelpButtonText).enabled = true;
            }
            if ((UnityEngine.Object) this.TaxText != (UnityEngine.Object) null && ((Behaviour) this.TaxText).enabled)
            {
              ((Behaviour) this.TaxText).enabled = false;
              ((Behaviour) this.TaxText).enabled = true;
            }
            if ((UnityEngine.Object) this.LoadingText != (UnityEngine.Object) null && ((Behaviour) this.LoadingText).enabled)
            {
              ((Behaviour) this.LoadingText).enabled = false;
              ((Behaviour) this.LoadingText).enabled = true;
            }
            if ((UnityEngine.Object) this.LTaxText != (UnityEngine.Object) null && ((Behaviour) this.LTaxText).enabled)
            {
              ((Behaviour) this.LTaxText).enabled = false;
              ((Behaviour) this.LTaxText).enabled = true;
            }
            if ((UnityEngine.Object) this.AddSpeedText != (UnityEngine.Object) null && ((Behaviour) this.AddSpeedText).enabled)
            {
              ((Behaviour) this.AddSpeedText).enabled = false;
              ((Behaviour) this.AddSpeedText).enabled = true;
            }
            if ((UnityEngine.Object) this.TotalTimeText != (UnityEngine.Object) null && ((Behaviour) this.TotalTimeText).enabled)
            {
              ((Behaviour) this.TotalTimeText).enabled = false;
              ((Behaviour) this.TotalTimeText).enabled = true;
            }
            for (int index = 0; index < this.RBText.Length; ++index)
            {
              if ((UnityEngine.Object) this.RBText[index] != (UnityEngine.Object) null && ((Behaviour) this.RBText[index]).enabled)
              {
                ((Behaviour) this.RBText[index]).enabled = false;
                ((Behaviour) this.RBText[index]).enabled = true;
              }
            }
            if ((UnityEngine.Object) this.m_DResources != (UnityEngine.Object) null)
              this.m_DResources.Refresh_FontTexture();
            for (int index = 0; index < this.m_Slider.Length; ++index)
            {
              if ((UnityEngine.Object) this.m_Slider[index] != (UnityEngine.Object) null)
                this.m_Slider[index].Refresh_FontTexture();
            }
            return;
          default:
            return;
        }
    }
  }

  public override bool OnBackButtonClick()
  {
    for (int index = 0; index < 5; ++index)
      this.GM.m_SaveResource[index] = 0U;
    this.GM.m_OpenResourceMenu = false;
    return false;
  }

  public void RefreshResource(bool FromNetWork = false)
  {
    this.GM.SetDemandResourcesText(this.m_DResources.transform, this.lSendResource);
    long num1 = (long) Math.Ceiling((double) (this.LoadingMax * 100L) / (100.0 - this.Tax));
    for (int index = 0; index < 5; ++index)
    {
      long num2 = (long) this.DM.Resource[index].Stock;
      bool flag = (!FromNetWork || this.OpenIndex != index) && !this.bOpenOkCancelBox;
      if (flag && this.lSendResource[index] > num2)
        this.CheckResource(index, num2);
      if (num1 < num2)
        num2 = num1;
      if (flag)
        this.m_Slider[index].m_slider.maxValue = (double) num2;
      this.m_Slider[index].MaxValue = num2;
    }
  }

  public void RefreshSpeed()
  {
    this.BootsStr.Length = 0;
    this.BootsStr.StringToFormat(this.DM.mStringTable.GetStringByID(4999U));
    int Percent = (int) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED) + (int) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_TRADE_MARCH_SPEED) - (int) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_DEBUFF);
    int effectBaseVal = (int) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_SPEED_CURSE);
    this.BootsStr.IntToFormat((long) (Percent / 100));
    this.BootsStr.AppendFormat("{0} : <color=#1FF984>{1}%</color>");
    this.AddSpeedText.text = this.BootsStr.ToString();
    this.AddSpeedText.SetAllDirty();
    this.AddSpeedText.cachedTextGenerator.Invalidate();
    float num = Vector2.Distance(GameConstants.getTileMapPosbyMapID(DataManager.Instance.RoleAttr.CapitalPoint), GameConstants.getTileMapPosbyPointCode(this.DesPoint.zoneID, this.DesPoint.pointID));
    uint sec = (uint) Mathf.Ceil(14f * this.GATTR_INC_PERCENTAGE(1f, (float) effectBaseVal) / this.GATTR_INC_PERCENTAGE(1f, (float) Percent) * num);
    this.TimeStr.Length = 0;
    GameConstants.GetTimeString(this.TimeStr, sec);
    this.TotalTimeText.text = this.TimeStr.ToString();
    this.TotalTimeText.SetAllDirty();
    this.TotalTimeText.cachedTextGenerator.Invalidate();
  }

  public void RefreshTax()
  {
    this.mBD = this.GM.BuildingData.GetBuildData((ushort) 17, (ushort) 0);
    this.mBR = this.GM.BuildingData.GetBuildLevelRequestData((ushort) 17, this.mBD.Level);
    uint effectBaseVal = this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_TRADE_TAX_REDUCTION);
    if (this.mBR.Value2 >= effectBaseVal)
      this.Tax = (double) (this.mBR.Value2 - effectBaseVal) / 100.0;
    this.TaxStr.Length = 0;
    this.TaxStr.DoubleToFormat(this.Tax, 1, false);
    this.TaxStr.AppendFormat(this.DM.mStringTable.GetStringByID(4037U));
    this.LTaxText.text = this.TaxStr.ToString();
    this.LTaxText.SetAllDirty();
    this.LTaxText.cachedTextGenerator.Invalidate();
    if (this.bOpen)
    {
      this.TotalTax = 0L;
      for (int index = 0; index < 5; ++index)
      {
        this.lTaxResource[index] = (long) Math.Ceiling((double) this.lSendResource[index] * this.Tax / 100.0);
        this.TotalTax += this.lTaxResource[index];
      }
      this.TotalLoading = this.TotalSend - this.TotalTax;
    }
    this.TaxStr2.Length = 0;
    this.TaxStr2.IntToFormat(this.TotalTax, bNumber: true);
    if (this.GM.IsArabic)
      this.TaxStr2.AppendFormat("{0}-");
    else
      this.TaxStr2.AppendFormat("-{0}");
    this.TaxText.text = this.TaxStr2.ToString();
    this.TaxText.SetAllDirty();
    this.TaxText.cachedTextGenerator.Invalidate();
    this.LoadingMax = this.GetMaxLoading();
    this.LoadingStr2.Length = 0;
    this.LoadingStr2.IntToFormat(this.TotalLoading, bNumber: true);
    this.LoadingStr2.IntToFormat(this.LoadingMax, bNumber: true);
    if (this.GM.IsArabic)
      this.LoadingStr2.AppendFormat("{1} / {0}");
    else
      this.LoadingStr2.AppendFormat("{0} / {1}");
    this.LoadingText.text = this.LoadingStr2.ToString();
    this.LoadingText.SetAllDirty();
    this.LoadingText.cachedTextGenerator.Invalidate();
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
        for (int index = 0; index < 5; ++index)
          this.GM.m_SaveResource[index] = 0U;
        this.GM.m_OpenResourceMenu = false;
        this.door.CloseMenu();
        break;
      case 2:
        if (this.TotalLoading <= 0L)
          break;
        this.GM.MsgStr.Length = 0;
        this.GM.MsgStr.StringToFormat(this.TimeStr);
        this.GM.MsgStr.StringToFormat(this.NameStr);
        this.GM.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(3958U));
        this.GM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(3972U), this.GM.MsgStr.ToString());
        this.bOpenOkCancelBox = true;
        break;
      case 3:
        this.GM.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
        this.GM.m_UICalculator.OpenCalculator(this.m_Slider[sender.m_BtnID2].MaxValue, this.m_Slider[sender.m_BtnID2].Value, 260f, 100f, this.m_Slider[sender.m_BtnID2], 0L);
        this.OpenIndex = sender.m_BtnID2;
        break;
    }
  }

  public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
  {
    URS.m_slider.value = (double) mValue;
    URS.SliderValueChange();
    this.OpenIndex = -1;
  }

  public void OnVauleChang(UnitResourcesSlider sender)
  {
    int id = sender.m_ID;
    if (!this.CheckResourceMax(id, sender))
      return;
    StringManager.IntToStr(this.ResourcesStr[id], sender.Value, bNumber: true);
    sender.m_inputText.text = this.ResourcesStr[id].ToString();
    sender.m_inputText.SetAllDirty();
    sender.m_inputText.cachedTextGenerator.Invalidate();
    this.CheckResource(id, sender.Value);
  }

  public void OnTextChang(UnitResourcesSlider sender)
  {
    int id = sender.m_ID;
    if (!this.CheckResourceMax(id, sender))
      return;
    StringManager.IntToStr(this.ResourcesStr[id], sender.Value, bNumber: true);
    this.m_Slider[id].m_inputText.text = this.ResourcesStr[id].ToString();
    this.m_Slider[id].m_inputText.SetAllDirty();
    this.m_Slider[id].m_inputText.cachedTextGenerator.Invalidate();
    this.CheckResource(id, sender.Value);
  }

  public bool CheckResourceMax(int index, UnitResourcesSlider sender)
  {
    if (sender.Value <= this.lSendResource[index])
      return true;
    if (this.TotalLoading >= this.LoadingMax && sender.Value - this.lSendResource[index] == 1L)
    {
      long num = 0;
      int index1 = -1;
      for (int index2 = 0; index2 < 5; ++index2)
      {
        if (index2 != index && this.lSendResource[index2] > num)
        {
          num = this.lSendResource[index2];
          index1 = index2;
        }
      }
      if (index1 == -1)
        return false;
      this.CheckResource(index1, this.lSendResource[index1] - 1L);
      this.SetSlider(index1, this.lSendResource[index1] - 1L);
      return true;
    }
    byte num1 = 0;
    long num2 = this.TotalSend - this.lSendResource[index];
    long num3 = 0;
    long num4 = (long) Math.Ceiling((double) sender.Value * this.Tax / 100.0);
    for (int index3 = 0; index3 < 5; ++index3)
    {
      if (index3 != index && this.lSendResource[index3] != 0L)
      {
        num3 += this.lTaxResource[index3];
        ++num1;
      }
    }
    if (num2 + sender.Value - (num3 + num4) <= this.LoadingMax)
      return true;
    long num5 = (long) Math.Ceiling((double) (this.LoadingMax - (sender.Value - num4)) * 100.0 / (100.0 - this.Tax));
    long num6 = num5;
    for (int index4 = 0; index4 < 5; ++index4)
    {
      if (index4 != index && this.lSendResource[index4] != 0L)
      {
        --num1;
        long num7;
        if (num1 == (byte) 0)
        {
          num7 = num6;
        }
        else
        {
          num7 = (long) ((double) num5 * ((double) this.lSendResource[index4] / (double) num2));
          num6 -= num7;
        }
        this.CheckResource(index4, num7);
        this.SetSlider(index4, num7);
      }
    }
    this.CheckResource(index, sender.Value);
    this.SetSlider(index, sender.Value);
    return false;
  }

  public void CheckResource(int index, long Value)
  {
    this.TotalSend -= this.lSendResource[index];
    this.lTaxResource[index] = (long) Math.Ceiling((double) Value * this.Tax / 100.0);
    this.lSendResource[index] = Value;
    this.GM.m_SaveResource[index] = (uint) Value;
    this.TotalSend += this.lSendResource[index];
    this.TotalTax = 0L;
    for (int index1 = 0; index1 < 5; ++index1)
      this.TotalTax += this.lTaxResource[index1];
    this.TotalLoading = this.TotalSend - this.TotalTax;
    if (this.TotalLoading > 0L)
      this.HelpButton.ForTextChange(e_BtnType.e_Normal);
    else
      this.HelpButton.ForTextChange(e_BtnType.e_ChangeText);
    this.TaxStr2.Length = 0;
    this.TaxStr2.IntToFormat(this.TotalTax, bNumber: true);
    if (this.GM.IsArabic)
      this.TaxStr2.AppendFormat("{0}-");
    else
      this.TaxStr2.AppendFormat("-{0}");
    this.TaxText.text = this.TaxStr2.ToString();
    this.TaxText.SetAllDirty();
    this.TaxText.cachedTextGenerator.Invalidate();
    this.LoadingStr2.Length = 0;
    this.LoadingStr2.IntToFormat(this.TotalLoading, bNumber: true);
    this.LoadingStr2.IntToFormat(this.LoadingMax, bNumber: true);
    if (this.GM.IsArabic)
      this.LoadingStr2.AppendFormat("{1} / {0}");
    else
      this.LoadingStr2.AppendFormat("{0} / {1}");
    this.LoadingText.text = this.LoadingStr2.ToString();
    this.LoadingText.SetAllDirty();
    this.LoadingText.cachedTextGenerator.Invalidate();
    this.GM.SetDemandResourcesText(this.m_DResources.transform, this.lSendResource);
  }

  private float GATTR_INC_PERCENTAGE(float Val, float Percent)
  {
    return (float) ((double) Val * (10000.0 + (double) Percent) / 10000.0);
  }

  public void SendHelp()
  {
    if (!this.GM.ShowUILock(EUILock.Scout))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_SEND_RESHELP;
    messagePacket.AddSeqId();
    messagePacket.Add(this.DesPoint.zoneID);
    messagePacket.Add(this.DesPoint.pointID);
    for (int index = 0; index < 5; ++index)
    {
      this.GM.m_SendResource[index] = (uint) this.lSendResource[index];
      messagePacket.Add(this.GM.m_SendResource[index]);
    }
    messagePacket.Send();
  }

  private void SetSlider(int index, long Value)
  {
    this.m_Slider[index].m_slider.value = (double) Value;
    this.m_Slider[index].Value = Value;
    StringManager.IntToStr(this.ResourcesStr[index], Value, bNumber: true);
    this.m_Slider[index].m_inputText.text = this.ResourcesStr[index].ToString();
    this.m_Slider[index].m_inputText.SetAllDirty();
    this.m_Slider[index].m_inputText.cachedTextGenerator.Invalidate();
  }

  private long GetMaxLoading()
  {
    return (long) ((double) this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_TRADE_CAPACITY) * ((double) (10000U + this.DM.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_TRADE_CAPACITY_PERCENT)) / 10000.0));
  }
}
