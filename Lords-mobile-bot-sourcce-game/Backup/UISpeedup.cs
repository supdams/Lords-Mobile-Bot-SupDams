// Decompiled with JetBrains decompiler
// Type: UISpeedup
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UISpeedup : UIFilterBase, IUIButtonDownUpHandler
{
  private SpeedupBase Speedup;
  private GameObject HelpObj;
  private UIText HelpText;
  private CString TimeStr;
  private CString HelpStr;
  private bool bUseImmediateFree;
  private bool bException;
  private EQueueBarIndex QueueBar;
  private short FreeIdx;
  private short MoneyIdx;
  private UITimeBar timebar;
  private long LeftTime;
  private long MaxSpeedupTimeItem;
  private uint Cost;
  private int MoneyPanelIndex;
  private int FreePanelIndex;
  private int BagCount;
  private int CheckNameID;
  private byte BuyAndUse;
  private List<byte> UpdateState = new List<byte>();
  private byte bForceClose;

  public override unsafe void OnOpen(int arg1, int arg2)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    this.QueueBar = (EQueueBarIndex) arg2;
    this.TimeStr = StringManager.Instance.SpawnString(200);
    this.HelpStr = StringManager.Instance.SpawnString();
    base.OnOpen(arg1, arg2);
    this.ThisTransform = this.SetFunc(this.transform.GetChild(3));
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.ThisTransform.gameObject.SetActive(true);
    this.MainText.font = ttfFont;
    this.HelpObj = this.ThisTransform.GetChild(1).gameObject;
    this.HelpText = this.ThisTransform.GetChild(1).GetChild(1).GetComponent<UIText>();
    this.HelpText.font = ttfFont;
    this.AddRefreshText((Text) this.HelpText);
    UIButtonHint uiButtonHint = this.ThisTransform.GetChild(1).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint.Parm1 = (ushort) 14701;
    uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
    bool flag = true;
    EQueueBarIndex queueBar = this.QueueBar;
    switch (queueBar)
    {
      case EQueueBarIndex.Training:
        this.Speedup = (SpeedupBase) new TrainingSpeedup(this.QueueBar);
        break;
      case EQueueBarIndex.HeroEnhance:
        this.Speedup = (SpeedupBase) new HeroEnhanceSpeedup(this.QueueBar);
        break;
      case EQueueBarIndex.HeroEvolution:
        this.Speedup = (SpeedupBase) new HeroStarupSpeedup(this.QueueBar);
        break;
      case EQueueBarIndex.Treatmenting:
        this.Speedup = (SpeedupBase) new TreatmentingSpeedup(this.QueueBar);
        break;
      case EQueueBarIndex.Manufacturing:
        this.Speedup = (SpeedupBase) new TrapSpeedup(this.QueueBar);
        break;
      case EQueueBarIndex.TrapRepair:
        this.Speedup = (SpeedupBase) new FixTrapSpeedup(this.QueueBar);
        break;
      case EQueueBarIndex.WallRepair:
        this.Speedup = (SpeedupBase) new FixwallSpeedup(this.QueueBar);
        break;
      case EQueueBarIndex.Forging:
        this.Speedup = (SpeedupBase) new ForgingSpeedup(this.QueueBar);
        break;
      case EQueueBarIndex.AffairMission:
        this.Speedup = (SpeedupBase) new MissionAffairSpeedup(this.QueueBar);
        break;
      case EQueueBarIndex.AllianceMission:
        this.Speedup = (SpeedupBase) new MissionAllianceSpeedup(this.QueueBar);
        break;
      case EQueueBarIndex.VIPMission:
        this.Speedup = (SpeedupBase) new MissionVIPSpeedup(this.QueueBar);
        break;
      case EQueueBarIndex.LordReturn:
        this.Speedup = (SpeedupBase) new HeroLeavePrison(this.QueueBar);
        break;
      case EQueueBarIndex.PetFusion:
        this.Speedup = (SpeedupBase) new PetItemCraftSpeed(this.QueueBar);
        break;
      case EQueueBarIndex.PetEvolution:
        this.Speedup = (SpeedupBase) new PetEvolutionSpeed(this.QueueBar);
        break;
      default:
        if (queueBar != EQueueBarIndex.Building)
        {
          if (queueBar == EQueueBarIndex.Researching)
          {
            this.Speedup = (SpeedupBase) new ResearchSpeedup(this.QueueBar);
            this.CheckHelpbarShow();
            break;
          }
          flag = false;
          this.Speedup = (SpeedupBase) new MarchGropSpeedup(arg2);
          this.QueueBar = (EQueueBarIndex) this.Speedup.QueueBar;
          if (this.Speedup.QueueBar == byte.MaxValue)
          {
            MarchGropSpeedup speedup = this.Speedup as MarchGropSpeedup;
            if (speedup.mapline != null && speedup.mapline.lineFlag != (byte) 12)
            {
              this.bException = true;
              break;
            }
            break;
          }
          break;
        }
        this.Speedup = (SpeedupBase) new BuildSpeedup(this.QueueBar);
        this.CheckHelpbarShow();
        break;
    }
    this.SortObj.SetActive(flag);
    this.UseTargetID = (ushort) this.Speedup.UseTarget;
    this.MainText.text = this.Speedup.MainTitleStr;
    string empty1 = string.Empty;
    string empty2 = string.Empty;
    this.timebar = this.ThisTransform.GetChild(0).GetComponent<UITimeBar>();
    instance1.GetQueueBarTitle(this.QueueBar, instance2.tmpString, ref empty1, ref empty2);
    instance2.CreateTimerBar(this.timebar, 0L, 0L, 0L, eTimeBarType.SpeedupType, empty1, empty2);
    if (arg2 < 100)
    {
      if (this.QueueBar >= (EQueueBarIndex) instance1.queueBarData.Length)
      {
        this.bForceClose = (byte) 1;
        this.ThisTransform.gameObject.SetActive(false);
        return;
      }
      QueueBarData* queueBarDataPtr = &instance1.queueBarData[(int) (byte) this.QueueBar];
      instance2.SetTimerBar(this.timebar, queueBarDataPtr->StartTime, queueBarDataPtr->StartTime + (long) queueBarDataPtr->TotalTime, 0L, eTimeBarType.SpeedupType, empty1, empty2);
      this.LeftTime = queueBarDataPtr->StartTime + (long) queueBarDataPtr->TotalTime - instance1.ServerTime;
      queueBarDataPtr = (QueueBarData*) null;
    }
    else
    {
      string stringById = instance1.mStringTable.GetStringByID(4914U);
      if (this.Speedup.Name != null)
        this.CheckNameID = this.Speedup.Name.GetHashCode(false);
      instance2.SetTimerBar(this.timebar, this.Speedup.StartTime, this.Speedup.StartTime + (long) this.Speedup.TotalTime, 0L, eTimeBarType.SpeedupType, stringById, stringById);
      this.LeftTime = this.Speedup.StartTime + (long) this.Speedup.TotalTime - instance1.ServerTime;
    }
    if (this.LeftTime < 0L)
    {
      this.bForceClose = (byte) 1;
      this.ThisTransform.gameObject.SetActive(false);
    }
    this.bUseImmediateFree = this.Speedup.bFreeSpeedup && this.LeftTime <= (long) instance1.GetFreeCompleteTime();
    if (!this.bUseImmediateFree)
    {
      this.MoneyIdx = this.Speedup.bImmediate ? (short) 0 : (short) -1;
      if (this.Speedup.bFreeSpeedup)
        this.FreeIdx = (short) 1;
      else
        this.FreeIdx = (short) -1;
    }
    else
    {
      this.MoneyIdx = (short) -1;
      this.FreeIdx = (short) 0;
      instance2.SetTimerSpriteType(this.timebar, eTimerSpriteType.Free);
    }
  }

  public override void Init()
  {
    base.Init();
    if (!this.bException)
    {
      this.UpdateSpeedupItem();
    }
    else
    {
      this.FilterScrollView.gameObject.SetActive(false);
      UIText component = ((Transform) this.MessageTrans).GetChild(0).GetComponent<UIText>();
      component.text = DataManager.Instance.mStringTable.GetStringByID(10049U);
      Vector2 sizeDelta = this.MessageTrans.sizeDelta with
      {
        x = component.preferredWidth + 165f
      };
      if ((double) sizeDelta.x > 770.0)
        sizeDelta.x = 770f;
      this.MessageTrans.sizeDelta = sizeDelta;
      ((Component) this.MessageTrans).gameObject.SetActive(true);
    }
    this.UpdateTime(true);
  }

  private void CheckHelpbarShow()
  {
    if (this.QueueBar != EQueueBarIndex.Building && this.QueueBar != EQueueBarIndex.Researching || this.Speedup is MarchGropSpeedup)
      return;
    DataManager instance = DataManager.Instance;
    byte index = 0;
    if (this.QueueBar == EQueueBarIndex.Building)
      index = (byte) 1;
    if (instance.RoleAlliance.Id > 0U && (instance.mPlayHelpDataType[(int) index].Kind == (byte) 1 && instance.mPlayHelpDataType[(int) index].HelpMax != (byte) 0 && (int) instance.mPlayHelpDataType[(int) index].AlreadyHelperNum == (int) instance.mPlayHelpDataType[(int) index].HelpMax || instance.mPlayHelpDataType[(int) index].Kind == (byte) 2))
    {
      this.HelpObj.SetActive(true);
      this.UpdateHelpNum();
    }
    else
      this.HelpObj.SetActive(false);
  }

  private void UpdateHelpNum()
  {
    if (!this.HelpObj.activeSelf)
      return;
    DataManager instance = DataManager.Instance;
    this.HelpStr.ClearString();
    if (this.QueueBar == EQueueBarIndex.Building)
    {
      this.HelpStr.IntToFormat((long) instance.mPlayHelpDataType[1].AlreadyHelperNum);
      this.HelpStr.IntToFormat((long) instance.mPlayHelpDataType[1].HelpMax);
    }
    else if (this.QueueBar == EQueueBarIndex.Researching)
    {
      this.HelpStr.IntToFormat((long) instance.mPlayHelpDataType[0].AlreadyHelperNum);
      this.HelpStr.IntToFormat((long) instance.mPlayHelpDataType[0].HelpMax);
    }
    if (GUIManager.Instance.IsArabic)
      this.HelpStr.AppendFormat("{1} / {0}");
    else
      this.HelpStr.AppendFormat("{0} / {1}");
    this.HelpText.text = this.HelpStr.ToString();
    this.HelpText.SetAllDirty();
    this.HelpText.cachedTextGenerator.Invalidate();
  }

  public void UpdateSpeedupItem(bool bForceUpdate = false)
  {
    if (bForceUpdate && this.BuyAndUse > (byte) 0)
      return;
    DataManager instance = DataManager.Instance;
    Vector2 vector2 = Vector2.zero;
    int itemidx = 0;
    instance.SortResourceFilterData();
    if (bForceUpdate)
    {
      vector2 = this.ScrollContent.anchoredPosition;
      itemidx = this.FilterScrollView.GetBeginIdx();
    }
    this.ItemsHeight.Clear();
    this.ItemsData.Clear();
    this.UpdateState.Clear();
    int sortbeginIdx = 0;
    if (this.MoneyIdx >= (short) 0)
    {
      this.UpdateState.Add((byte) 0);
      this.ItemsData.Add((ushort) 0);
      this.ItemsHeight.Add(121f);
      ++sortbeginIdx;
    }
    if (this.FreeIdx >= (short) 0)
    {
      this.UpdateState.Add((byte) 0);
      this.ItemsData.Add((ushort) 0);
      this.ItemsHeight.Add(121f);
      ++sortbeginIdx;
    }
    this.MaxSpeedupTimeItem = 0L;
    this.BagCount = -1;
    byte sort = 0;
    if (this.SortObj.activeSelf)
      sort = this.SortType;
    this.SetItemData(instance.sortItemData, instance.sortItemDataStart[12], instance.sortItemDataCount[12], sort: sort, sortbeginIdx: sortbeginIdx);
    this.BagCount = this.ItemsHeight.Count;
    int bagCount = this.BagCount;
    this.MaxSpeedupTimeItem = 0L;
    this.SetItemData(instance.SortSotreData, instance.SortSotreDataStart[6], instance.SortSotreDataCount[6], sort: sort, sortbeginIdx: bagCount);
    this.Speedup.CustomSort(this.ItemsData, this.BagCount);
    this.UpdateScrollItemsCount();
    if (!bForceUpdate)
      return;
    this.FilterScrollView.GoTo(itemidx, vector2.y);
  }

  public override bool CheckItemRule(ushort id)
  {
    Equip recordByKey1;
    if (this.BagCount == -1)
    {
      if (DataManager.Instance.GetCurItemQuantity(id, (byte) 0) == (ushort) 0)
        return false;
      recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(id);
      if ((int) recordByKey1.PropertiesInfo[0].Propertieskey != (int) this.Speedup.FilterType && (int) recordByKey1.PropertiesInfo[0].Propertieskey != (int) this.Speedup.FilterType2)
        return false;
    }
    else
    {
      StoreTbl recordByKey2 = DataManager.Instance.StoreData.GetRecordByKey(id);
      recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
      if ((int) recordByKey1.PropertiesInfo[0].Propertieskey != (int) this.Speedup.FilterType && (int) recordByKey1.PropertiesInfo[0].Propertieskey != (int) this.Speedup.FilterType2)
        return false;
      if (recordByKey2.AddDiamondBuy != (byte) 0 && recordByKey2.Filter != (byte) 2 && this.Speedup.SkipFilterTime == (byte) 0)
      {
        long num = (long) ((int) recordByKey1.PropertiesInfo[1].Propertieskey * 60);
        if (this.LeftTime < num && this.MaxSpeedupTimeItem == 0L)
          this.MaxSpeedupTimeItem = num;
      }
      if (recordByKey2.AddDiamondBuy == (byte) 0 || recordByKey2.Filter == (byte) 2 || DataManager.Instance.GetCurItemQuantity(recordByKey2.ItemID, (byte) 0) > (ushort) 0)
        return false;
    }
    if (this.Speedup.SkipFilterTime == (byte) 0)
    {
      long num = (long) ((int) recordByKey1.PropertiesInfo[1].Propertieskey * 60);
      if (this.LeftTime < num)
      {
        if (this.MaxSpeedupTimeItem == 0L)
          this.MaxSpeedupTimeItem = num;
        else if (this.MaxSpeedupTimeItem < num)
          return false;
      }
    }
    this.UpdateState.Add((byte) 0);
    return true;
  }

  public override void UpdateUI(int arge1, int arge2)
  {
    if (arge1 == 65537)
      base.UpdateUI(arge1, arge2);
    else if (arge1 == 65538)
    {
      this.Speedup.SendImmediate();
    }
    else
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      BuildsData buildingData = GUIManager.Instance.BuildingData;
      if (arge2 != 100)
      {
        if (this.QueueBar == (EQueueBarIndex) arge2)
        {
          if (buildingData.QueueBuildType == (byte) 2 && buildingData.AllBuildsData[(int) buildingData.OpenUiManorID].Level == (byte) 0)
            menu.CloseMenu(true);
          else
            menu.CloseMenu();
        }
      }
      else if (this.Speedup.Rally == (byte) 1)
      {
        DataManager instance = DataManager.Instance;
        byte queueBar = this.Speedup.QueueBar;
        if (arge1 == -1 || instance.WarTroop.Count <= (int) queueBar)
          menu.CloseMenu();
        else if (instance.WarTroop.Count > (int) queueBar)
        {
          if (instance.WarTroop[(int) queueBar].MarchTime.BeginTime + (long) instance.WarTroop[(int) queueBar].MarchTime.RequireTime < instance.ServerTime || this.CheckNameID != instance.WarTroop[(int) queueBar].AllyNameID)
            menu.CloseMenu();
          else
            GUIManager.Instance.SetTimerBar(this.timebar, instance.WarTroop[(int) queueBar].MarchTime.BeginTime, instance.WarTroop[(int) queueBar].MarchTime.BeginTime + (long) instance.WarTroop[(int) queueBar].MarchTime.RequireTime, 0L, eTimeBarType.SpeedupType, instance.mStringTable.GetStringByID(4914U), instance.mStringTable.GetStringByID(4914U));
        }
      }
      else if (this.Speedup.Rally == (byte) 2)
      {
        if (arge1 == -1)
        {
          menu.CloseMenu();
        }
        else
        {
          DataManager instance = DataManager.Instance;
          bool flag = false;
          if (this.Speedup.Name == null || this.CheckNameID != this.Speedup.Name.GetHashCode(false))
          {
            if (instance.WarHall[0] == null)
              return;
            for (byte index = 0; (int) index < instance.WarHall[0].Count; ++index)
            {
              if (instance.WarHall[0][(int) index].AllyNameID == this.CheckNameID)
              {
                this.Speedup.QueueBar = (byte) ((uint) instance.queueBarData.Length + (uint) index);
                flag = true;
                break;
              }
            }
          }
          else if (this.Speedup.Name != null && this.CheckNameID == this.Speedup.Name.GetHashCode(false))
            flag = true;
          if (!flag || this.Speedup.StartTime + (long) this.Speedup.TotalTime < instance.ServerTime)
            menu.CloseMenu();
        }
      }
      this.UpdateHelpNum();
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_Item:
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (this.Speedup.UseTarget == _UseItemTarget.Rally)
        {
          this.UpdateSpeedupItem(true);
          break;
        }
        if (this.Speedup.QueueBar == (byte) 30)
        {
          menu.GoToGroup(8, (byte) 0);
          menu.CloseMenu();
          break;
        }
        if (this.Speedup.QueueBar >= (byte) 2 && this.Speedup.QueueBar <= (byte) 9)
        {
          menu.GoToGroup((int) this.Speedup.QueueBar - 2, (byte) 0);
          menu.CloseMenu();
          break;
        }
        if (this.Speedup.Rally == (byte) 2 && this.Speedup.QueueBar >= (byte) 22 && this.Speedup.QueueBar <= (byte) 29)
        {
          menu.GoToGroup((int) this.Speedup.QueueBar - 22, (byte) 0);
          menu.CloseMenu();
          break;
        }
        this.UpdateSpeedupItem(true);
        break;
      case NetworkNews.Refresh_Alliance:
        this.CheckHelpbarShow();
        break;
      default:
        switch (networkNews)
        {
          case NetworkNews.Login:
            this.BuyAndUse = (byte) 0;
            if (this.Speedup.UseTarget == _UseItemTarget.Rally)
              (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu(true);
            else if (this.Speedup.UseTarget == _UseItemTarget.SunLordequip)
            {
              LordEquipData.Instance().LoadLordEquip();
            }
            else
            {
              DataManager.Instance.SortResourceFilterData();
              this.UpdateSpeedupItem(true);
            }
            this.UpdateQueuebarTime();
            this.CheckHelpbarShow();
            return;
          case NetworkNews.Refresh_QBarTime:
            if (this.Speedup.Rally > (byte) 0)
            {
              if (this.Speedup.StartTime + (long) this.Speedup.TotalTime < DataManager.Instance.ServerTime)
              {
                (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
                return;
              }
              GUIManager.Instance.SetTimerBar(this.timebar, this.Speedup.StartTime, this.Speedup.StartTime + (long) this.Speedup.TotalTime, 0L, eTimeBarType.SpeedupType, this.timebar.m_Titles[0], this.timebar.m_Titles[1]);
              this.UpdateTime(true);
              this.UpdateSpeedupItem(true);
              return;
            }
            if (this.QueueBar >= (EQueueBarIndex) DataManager.Instance.queueBarData.Length)
              return;
            this.UpdateQueuebarTime();
            return;
          default:
            if (networkNews != NetworkNews.Refresh_FontTextureRebuilt || !((UnityEngine.Object) this.timebar != (UnityEngine.Object) null))
              return;
            this.timebar.Refresh_FontTexture();
            return;
        }
    }
  }

  public unsafe void UpdateQueuebarTime()
  {
    if (this.QueueBar >= (EQueueBarIndex) DataManager.Instance.queueBarData.Length)
      return;
    QueueBarData* queueBarDataPtr = &DataManager.Instance.queueBarData[(int) (byte) this.QueueBar];
    GUIManager.Instance.SetTimerBar(this.timebar, queueBarDataPtr->StartTime, queueBarDataPtr->StartTime + (long) queueBarDataPtr->TotalTime, 0L, eTimeBarType.SpeedupType, this.timebar.m_Titles[0], this.timebar.m_Titles[1]);
    if (this.Speedup.SkipFilterTime == (byte) 0)
    {
      this.UpdateTime(true);
      if (this.BuyAndUse == (byte) 1)
      {
        this.BuyAndUse = (byte) 0;
        this.UpdateSpeedupItem(true);
        this.BuyAndUse = (byte) 1;
      }
      else
        this.UpdateSpeedupItem(true);
    }
    queueBarDataPtr = (QueueBarData*) null;
  }

  public override void UpDateRowItem(
    GameObject item,
    int dataIdx,
    int panelObjectIdx,
    int panelId)
  {
    base.UpDateRowItem(item, dataIdx, panelObjectIdx, panelId);
    if (this.ItemsData.Count == 0 || this.bException)
      return;
    DataManager instance = DataManager.Instance;
    this.FilterItem[panelObjectIdx].BuyImage.sprite = this.FilterSpriteArr.GetSprite(3);
    if ((int) this.FreeIdx == dataIdx)
      this.SetFreeImmediate(panelObjectIdx);
    else if ((int) this.MoneyIdx == dataIdx)
    {
      this.SetMoneyImmediate(panelObjectIdx);
    }
    else
    {
      this.UpdateState[panelObjectIdx] = (byte) 0;
      this.SetItemType(panelObjectIdx, UIFilterBase.eItemType.Use);
      Color color = ((Graphic) this.FilterItem[panelObjectIdx].Name).color with
      {
        r = 1f,
        g = 0.933f,
        b = 0.62f
      };
      ((Graphic) this.FilterItem[panelObjectIdx].Name).color = color;
      ((Behaviour) this.FilterItem[panelObjectIdx].BuyCaption).enabled = true;
      ((Behaviour) this.FilterItem[panelObjectIdx].BuyBtn).enabled = true;
      this.FilterItem[panelObjectIdx].KeyID = this.ItemsData[dataIdx];
      Equip recordByKey1;
      if (this.BagCount > dataIdx)
      {
        this.SetItemType(panelObjectIdx, UIFilterBase.eItemType.Use);
        recordByKey1 = instance.EquipTable.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
        this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = (int) this.FilterItem[panelObjectIdx].KeyID;
        ushort curItemQuantity = instance.GetCurItemQuantity(recordByKey1.EquipKey, (byte) 0);
        if ((byte) ((uint) recordByKey1.EquipKind - 1U) == (byte) 11)
        {
          if (curItemQuantity <= (ushort) 1 || (byte) recordByKey1.PropertiesInfo[0].Propertieskey != (byte) 1 && (byte) recordByKey1.PropertiesInfo[0].Propertieskey != (byte) 12 && (byte) recordByKey1.PropertiesInfo[0].Propertieskey != (byte) 17 && (byte) recordByKey1.PropertiesInfo[0].Propertieskey != (byte) 18 && (byte) recordByKey1.PropertiesInfo[0].Propertieskey != (byte) 21 && (byte) recordByKey1.PropertiesInfo[0].Propertieskey != (byte) 22 && ((Component) this.FilterItem[panelObjectIdx].AutouseBtnTrans).gameObject.activeSelf)
            ((Component) this.FilterItem[panelObjectIdx].AutouseBtnTrans).gameObject.SetActive(false);
        }
        else if ((curItemQuantity <= (ushort) 1 || recordByKey1.Hide > (byte) 0) && ((Component) this.FilterItem[panelObjectIdx].AutouseBtnTrans).gameObject.activeSelf)
          ((Component) this.FilterItem[panelObjectIdx].AutouseBtnTrans).gameObject.SetActive(false);
      }
      else
      {
        this.SetItemType(panelObjectIdx, UIFilterBase.eItemType.BuyAndUse);
        StoreTbl recordByKey2 = instance.StoreData.GetRecordByKey(this.FilterItem[panelObjectIdx].KeyID);
        recordByKey1 = instance.EquipTable.GetRecordByKey(recordByKey2.ItemID);
        this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID3 = (int) recordByKey2.ID;
        this.FilterItem[panelObjectIdx].BuyPriceStr.ClearString();
        this.FilterItem[panelObjectIdx].BuyPriceStr.IntToFormat((long) recordByKey2.Price, bNumber: true);
        this.FilterItem[panelObjectIdx].BuyPriceStr.AppendFormat("{0}");
        this.FilterItem[panelObjectIdx].BuyPrice.text = this.FilterItem[panelObjectIdx].BuyPriceStr.ToString();
        this.FilterItem[panelObjectIdx].BuyPrice.SetAllDirty();
        this.FilterItem[panelObjectIdx].BuyPrice.cachedTextGenerator.Invalidate();
        this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = (int) recordByKey2.ItemID;
        this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID3 = (int) this.FilterItem[panelObjectIdx].KeyID;
      }
      GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[panelObjectIdx].ItemTrans, eHeroOrItem.Item, recordByKey1.EquipKey, (byte) 0, (byte) 0);
      this.FilterItem[panelObjectIdx].Name.text = instance.mStringTable.GetStringByID((uint) recordByKey1.EquipName);
      this.FilterItem[panelObjectIdx].Content.text = instance.mStringTable.GetStringByID((uint) recordByKey1.EquipInfo);
      this.FilterItem[panelObjectIdx].OwnerStr.ClearString();
      this.FilterItem[panelObjectIdx].OwnerStr.StringToFormat(this.OwnerStr);
      this.FilterItem[panelObjectIdx].OwnerStr.IntToFormat((long) instance.GetCurItemQuantity(recordByKey1.EquipKey, (byte) 0), bNumber: true);
      this.FilterItem[panelObjectIdx].OwnerStr.AppendFormat("{0}{1}");
      this.FilterItem[panelObjectIdx].Owner.text = this.FilterItem[panelObjectIdx].OwnerStr.ToString();
      this.FilterItem[panelObjectIdx].Owner.SetAllDirty();
      this.FilterItem[panelObjectIdx].Owner.cachedTextGenerator.Invalidate();
    }
  }

  private void SetFreeImmediate(int index)
  {
    if (index < 0)
      return;
    DataManager instance = DataManager.Instance;
    this.FreePanelIndex = index;
    this.SetItemType(index, UIFilterBase.eItemType.Use);
    if (this.bUseImmediateFree)
    {
      this.FilterItem[index].Content.text = instance.mStringTable.GetStringByID(230U);
      this.FilterItem[index].BuyCaption.text = instance.mStringTable.GetStringByID(229U);
      this.UpdateState[index] = (byte) 0;
    }
    else
    {
      this.FilterItem[index].Content.text = string.Empty;
      this.UpdateState[index] = (byte) 1;
    }
    Color color = ((Graphic) this.FilterItem[index].Name).color with
    {
      r = 0.886f,
      g = 0.608f,
      b = 1f
    };
    ((Graphic) this.FilterItem[index].Name).color = color;
    this.FilterItem[index].BuyImage.sprite = this.FilterSpriteArr.GetSprite(2);
    ((Component) this.FilterItem[index].Lock).gameObject.SetActive(!this.bUseImmediateFree);
    ((Behaviour) this.FilterItem[index].BuyCaption).enabled = this.bUseImmediateFree;
    ((Behaviour) this.FilterItem[index].BuyBtn).enabled = this.bUseImmediateFree;
    this.FilterItem[index].BuyBtn.m_BtnID1 = 301;
    GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[index].ItemTrans, eHeroOrItem.Item, (ushort) 1109, (byte) 0, (byte) 0);
    this.FilterItem[index].Name.text = instance.mStringTable.GetStringByID(227U);
    ((Component) this.FilterItem[index].AutouseBtnTrans).gameObject.SetActive(false);
    this.FilterItem[index].Owner.text = string.Empty;
    this.UpdateTime(true);
  }

  private void SetMoneyImmediate(int index)
  {
    if (index < 0)
      return;
    this.UpdateState[index] = (byte) 2;
    GUIManager instance = GUIManager.Instance;
    this.MoneyPanelIndex = index;
    this.FilterItem[index].Content.text = this.Speedup.CompleteImmContStr;
    this.SetItemType(index, UIFilterBase.eItemType.BuyAndUse);
    this.FilterItem[index].BuyCaption.text = this.Speedup.CompleteImmBntStr;
    ((Behaviour) this.FilterItem[index].BuyCaption).enabled = true;
    if (this.QueueBar == EQueueBarIndex.Building)
    {
      if (instance.BuildingData.QueueBuildType == (byte) 1)
        GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[index].ItemTrans, eHeroOrItem.Item, (ushort) 1108, (byte) 0, (byte) 0);
      else
        GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[index].ItemTrans, eHeroOrItem.Item, (ushort) 1075, (byte) 0, (byte) 0);
    }
    else
      GUIManager.Instance.ChangeHeroItemImg(this.FilterItem[index].ItemTrans, eHeroOrItem.Item, (ushort) 1108, (byte) 0, (byte) 0);
    this.FilterItem[index].Name.text = this.Speedup.CompleteImmBntStr;
    ((Behaviour) this.FilterItem[index].BuyBtn).enabled = true;
    this.FilterItem[index].BuyBtn.m_BtnID1 = 302;
    this.FilterItem[index].Owner.text = string.Empty;
    this.UpdateTime(true);
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (this.bForceClose == (byte) 1)
    {
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
      this.bForceClose = (byte) 0;
    }
    else
    {
      if (!bOnSecond || this.PassInit > (byte) 0)
        return;
      DataManager instance = DataManager.Instance;
      if (this.Speedup.bImmediate || this.Speedup.bFreeSpeedup)
        this.LeftTime = instance.queueBarData[(int) this.Speedup.QueueBar].StartTime + (long) instance.queueBarData[(int) this.Speedup.QueueBar].TotalTime - instance.ServerTime;
      if ((!this.Speedup.bFreeSpeedup || this.bUseImmediateFree == this.LeftTime <= (long) instance.GetFreeCompleteTime() ? 0 : 1) != 0)
      {
        this.bUseImmediateFree = !this.bUseImmediateFree;
        if (!this.bUseImmediateFree)
        {
          this.MoneyIdx = !this.Speedup.bImmediate ? (short) -1 : (short) 0;
          this.FreeIdx = (short) 1;
        }
        else
        {
          this.FreeIdx = (short) 0;
          this.MoneyIdx = (short) -1;
          GUIManager.Instance.SetTimerSpriteType(this.timebar, eTimerSpriteType.Free);
        }
        this.UpdateSpeedupItem();
      }
      for (int index = 0; index < this.UpdateState.Count; ++index)
      {
        switch (this.UpdateState[index])
        {
          case 1:
            TimeSpan timeSpan = new TimeSpan((this.LeftTime - (long) instance.GetFreeCompleteTime()) * 10000000L);
            this.TimeStr.ClearString();
            this.TimeStr.Append(instance.mStringTable.GetStringByID(228U));
            if (timeSpan.Days > 0)
            {
              this.TimeStr.IntToFormat((long) timeSpan.Days);
              this.TimeStr.AppendFormat("{0}d ");
            }
            this.TimeStr.IntToFormat((long) timeSpan.Hours, 2);
            this.TimeStr.IntToFormat((long) timeSpan.Minutes, 2);
            this.TimeStr.IntToFormat((long) timeSpan.Seconds, 2);
            this.TimeStr.AppendFormat("{0}:{1}:{2}</color>");
            this.FilterItem[this.FreePanelIndex].Content.text = this.TimeStr.ToString();
            this.FilterItem[this.FreePanelIndex].Content.SetAllDirty();
            this.FilterItem[this.FreePanelIndex].Content.cachedTextGenerator.Invalidate();
            break;
          case 2:
            this.Cost = this.LeftTime <= 0L ? 0U : (this.QueueBar != EQueueBarIndex.PetFusion ? instance.GetResourceExchange(PriceListType.Time, (uint) this.LeftTime) : instance.GetResourceExchange(PriceListType.PetFusion, (uint) this.LeftTime));
            this.FilterItem[this.MoneyPanelIndex].BuyPriceStr.ClearString();
            this.FilterItem[this.MoneyPanelIndex].BuyPriceStr.IntToFormat((long) this.Cost, bNumber: true);
            this.FilterItem[this.MoneyPanelIndex].BuyPriceStr.AppendFormat("{0}");
            this.FilterItem[this.MoneyPanelIndex].BuyPrice.text = this.FilterItem[this.MoneyPanelIndex].BuyPriceStr.ToString();
            this.FilterItem[this.MoneyPanelIndex].BuyPrice.SetAllDirty();
            this.FilterItem[this.MoneyPanelIndex].BuyPrice.cachedTextGenerator.Invalidate();
            this.FilterItem[this.MoneyPanelIndex].Content.text = this.Speedup.CompleteImmContStr;
            this.FilterItem[this.MoneyPanelIndex].Content.SetAllDirty();
            this.FilterItem[this.MoneyPanelIndex].Content.cachedTextGenerator.Invalidate();
            break;
        }
      }
    }
  }

  public override void OnButtonClick(UIButton sender)
  {
    GUIManager instance1 = GUIManager.Instance;
    DataManager instance2 = DataManager.Instance;
    instance1.BagTagSaved[9] = this.Speedup.QueueBar;
    this.BuyAndUse = (byte) 0;
    if (sender.m_BtnID1 != 1001)
    {
      if (sender.m_BtnID1 == 301)
        this.Speedup.SendImmediateFree();
      else if (sender.m_BtnID1 == 302)
      {
        if (this.Cost <= instance2.RoleAttr.Diamond)
        {
          if (this.Cost > 0U && !GUIManager.Instance.OpenCheckCrystal(this.Cost, (byte) 1, 65538))
            this.Speedup.SendImmediate();
        }
        else
        {
          string stringById = instance2.mStringTable.GetStringByID(3968U);
          instance1.OpenMessageBox(instance2.mStringTable.GetStringByID(3966U), instance2.mStringTable.GetStringByID(646U), stringById, instance1.FindMenu(EGUIWindow.UI_BagFilter), bCloseIDSet: true);
        }
      }
    }
    base.OnButtonClick(sender);
    if (sender.m_BtnID1 != 1003)
      return;
    instance1.UpdateUI(EGUIWindow.UI_BagFilter, 3, !this.Speedup.bFreeSpeedup ? 1073741824 : 1073741825);
  }

  public override void SendPack(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1002:
        this.BuyAndUse = (byte) 0;
        if (this.Speedup.Rally == (byte) 2)
        {
          DataManager.Instance.SpeedupRally((ushort) sender.m_BtnID2, this.UseTargetID, this.Speedup.Name);
          break;
        }
        if (this.Speedup.Rally == (byte) 1)
        {
          DataManager.Instance.UseItem((ushort) sender.m_BtnID2, (ushort) 1, this.UseTargetID, (ushort) this.Speedup.QueueBar, (ushort) 0, 0U, string.Empty);
          break;
        }
        DataManager.Instance.UseItem((ushort) sender.m_BtnID2, (ushort) 1, this.UseTargetID, (ushort) 0, (ushort) 0, 0U, string.Empty);
        break;
      case 1004:
        this.BuyAndUse = (byte) 1;
        if (this.Speedup.Rally == (byte) 1)
        {
          this.CheckBuy((byte) 1, (ushort) sender.m_BtnID3, (ushort) sender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), (int) this.UseTargetID, (int) this.Speedup.QueueBar << 16, 0U);
          break;
        }
        this.CheckBuy((byte) 1, (ushort) sender.m_BtnID3, (ushort) sender.m_BtnID2, true, GUIManager.Instance.FindMenu(EGUIWindow.UI_BagFilter), (int) this.UseTargetID, Parameter3: 0U);
        break;
      case 1006:
        this.UpdateSpeedupItem(true);
        break;
    }
  }

  public override void OnClose()
  {
    base.OnClose();
    GUIManager.Instance.RemoverTimeBaarToList(this.timebar);
    StringManager.Instance.DeSpawnString(this.TimeStr);
    StringManager.Instance.DeSpawnString(this.HelpStr);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    MallManager.Instance.Send_Mall_Info();
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 277f, 20, (int) sender.Parm1, 0, Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide(true);

  private enum CompleteImmieateType
  {
    Free = 301, // 0x0000012D
    Money = 302, // 0x0000012E
  }
}
