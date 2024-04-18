// Decompiled with JetBrains decompiler
// Type: BuildsData
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable disable
public class BuildsData
{
  private int[] BuildsLevelRequestGroupIndexTbl;
  private List<byte>[] BuildManorGroupIndexTbl;
  private ushort[] SortBuildStart;
  public byte[] BuildIDCount;
  public bool NeedSortData;
  public BuildDataComparer buildDataComparer = new BuildDataComparer();
  public MapSpriteManager mapspriteManager;
  public ushort BuildingManorID;
  public ushort OpenUiManorID;
  public ushort GuideBuildID;
  public ushort GuideSoldierID;
  public uint GuideSoldierNum;
  public byte QueueBuildType;
  public byte ImmEffect;
  public RoleBuildingData[] AllBuildsData;
  public ushort[] SortBuildsData;
  public Vector3 BuildRot = new Vector3(45f, 185f, 3f);
  public Vector3 BaseBuildScale = new Vector3(10f, 10f, 10f);
  private Vector3 GateScale = new Vector3(12f, 12f, 12f);
  private float SpriteBaseSizeY;
  private StringBuilder SpriteName = new StringBuilder();
  public Transform[] ManorGride = new Transform[10];
  public ushort GuideParm;
  public byte[] BuildlevelupCheck;
  private bool bClose;
  public byte bHideLaboryPromptLock;
  public CastleSkin castleSkin;
  private byte _CastleID;

  public BuildsData() => this.castleSkin = new CastleSkin();

  public byte CastleID
  {
    get => this._CastleID;
    set
    {
      if ((int) this._CastleID == (int) (byte) ((uint) value + 1U))
        return;
      this._CastleID = (byte) ((uint) value + 1U);
      this.UpdateBuildState((byte) 12, (ushort) 1);
    }
  }

  private void InitialBuildData()
  {
    ushort mapCount = DataManager.Instance.BuildManorData.MapCount;
    this.AllBuildsData = new RoleBuildingData[(int) mapCount];
    this.SortBuildsData = new ushort[(int) mapCount];
    this.BuildlevelupCheck = new byte[(int) DataManager.Instance.BuildsTypeData.MapCount];
    for (ushort index = 0; (int) index < (int) mapCount; ++index)
      this.SortBuildsData[(int) index] = index;
  }

  public void MakeIndexTable()
  {
    int tableCount1 = DataManager.Instance.BuildsLevelRequestGroup.TableCount;
    if (tableCount1 == 0)
      return;
    DataManager instance = DataManager.Instance;
    ushort num1 = 0;
    this.BuildsLevelRequestGroupIndexTbl = new int[(int) instance.BuildsLevelRequestGroup.GetRecordByIndex(tableCount1 - 1).GroupID];
    ushort index = 0;
    while ((int) index < tableCount1)
    {
      BuildLevelRequestGroup recordByIndex = instance.BuildsLevelRequestGroup.GetRecordByIndex((int) index);
      ushort groupId = recordByIndex.GroupID;
      this.GetRequestGroupIDEnd(ref recordByIndex, groupId, ref index);
      ushort num2 = (ushort) ((uint) index - (uint) num1);
      int num3 = ((int) num1 << 16) + (int) num2;
      this.BuildsLevelRequestGroupIndexTbl[(int) groupId - 1] = num3;
      num1 = index;
    }
    int tableCount2 = instance.BuildManorData.TableCount;
    this.BuildManorGroupIndexTbl = new List<byte>[(int) instance.BuildManorData.GetRecordByIndex(tableCount2 - 1).MapGroup + 1];
    for (ushort Index = 0; (int) Index < tableCount2; ++Index)
    {
      BuildManorData recordByIndex = instance.BuildManorData.GetRecordByIndex((int) Index);
      if (this.BuildManorGroupIndexTbl[(int) recordByIndex.MapGroup] == null)
        this.BuildManorGroupIndexTbl[(int) recordByIndex.MapGroup] = new List<byte>();
      this.BuildManorGroupIndexTbl[(int) recordByIndex.MapGroup].Add((byte) Index);
    }
    this.BuildIDCount = new byte[(int) instance.BuildsTypeData.MapCount];
    this.SortBuildStart = new ushort[(int) instance.BuildsTypeData.MapCount];
    this.InitialBuildData();
  }

  private void GetRequestGroupIDEnd(
    ref BuildLevelRequestGroup Data,
    ushort groupID,
    ref ushort index)
  {
    DataManager instance = DataManager.Instance;
    ++index;
    if ((int) index >= instance.BuildsLevelRequestGroup.TableCount)
      return;
    Data = instance.BuildsLevelRequestGroup.GetRecordByIndex((int) index);
    if ((int) Data.GroupID != (int) groupID)
      return;
    this.GetRequestGroupIDEnd(ref Data, groupID, ref index);
  }

  private void GetRequestGroupIDEnd(ref BuildManorData Data, ushort groupID, ref ushort index)
  {
    DataManager instance = DataManager.Instance;
    ++index;
    if ((int) index >= instance.BuildManorData.TableCount)
      return;
    Data = instance.BuildManorData.GetRecordByIndex((int) index);
    if ((int) Data.MapGroup != (int) groupID)
      return;
    this.GetRequestGroupIDEnd(ref Data, groupID, ref index);
  }

  public BuildLevelRequest GetBuildLevelRequestData(ushort BuildID, byte Level)
  {
    return DataManager.Instance.BuildsRequest.GetRecordByIndex(25 * ((int) BuildID - 1) + ((int) Level - 1));
  }

  public void GetLevelRequestGroupIndex(ushort groupID, ref int BeginIndex, ref int Num)
  {
    if (groupID == (ushort) 0)
    {
      BeginIndex = 0;
      Num = 0;
    }
    else
    {
      int num = this.BuildsLevelRequestGroupIndexTbl[(int) groupID - 1];
      int maxValue = (int) ushort.MaxValue;
      BeginIndex = num >> 16;
      Num = num & maxValue;
    }
  }

  public void GetManorGroup(ushort groupID, ref int BeginIndex, ref int Num)
  {
    BeginIndex = (int) this.BuildManorGroupIndexTbl[(int) groupID][0];
    Num = this.BuildManorGroupIndexTbl[(int) groupID].Count;
  }

  public int GetCurrentChapterBuildCount()
  {
    StageManager stageDataController = DataManager.StageDataController;
    int num = (int) stageDataController.StageRecord[2];
    int chapterBuildCount = 0;
    if ((int) stageDataController.limitRecord[2] == (int) stageDataController.StageRecord[2])
      ++num;
    for (int index = num; index >= 0; --index)
    {
      if (this.BuildManorGroupIndexTbl != null && this.BuildManorGroupIndexTbl.Length > index)
        chapterBuildCount += this.BuildManorGroupIndexTbl[index].Count;
    }
    return chapterBuildCount;
  }

  public byte GetMonorIndex(int Index)
  {
    for (int index = 0; index < this.BuildManorGroupIndexTbl.Length; ++index)
    {
      if (this.BuildManorGroupIndexTbl[index].Count > Index)
        return this.BuildManorGroupIndexTbl[index][Index];
      Index -= this.BuildManorGroupIndexTbl[index].Count;
    }
    return 0;
  }

  public void EmptyManorGuide(ushort BuildID, bool UiGuide = false)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    RoleBuildingData buildData = this.GetBuildData(BuildID, (ushort) 0);
    ushort searchGroupID = 0;
    ushort searchManorID = 0;
    instance1.BuildManorData.GetRecordByKey(buildData.ManorID);
    if (this.BuildingManorID > (ushort) 0 && (int) this.BuildingManorID < this.AllBuildsData.Length && (int) this.AllBuildsData[(int) this.BuildingManorID].BuildID == (int) BuildID)
    {
      BuildManorData recordByKey = DataManager.Instance.BuildManorData.GetRecordByKey(this.BuildingManorID);
      DataManager.msgBuffer[0] = (byte) 24;
      GameConstants.GetBytes(recordByKey.MapGroup, DataManager.msgBuffer, 1);
      GameConstants.GetBytes(recordByKey.ID, DataManager.msgBuffer, 3);
      GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      if (!UiGuide)
        return;
      instance2.GuideParm1 = (byte) 2;
      instance2.GuideParm2 = buildData.ManorID;
    }
    else
    {
      StageManager stageDataController = DataManager.StageDataController;
      byte kind = instance1.BuildsTypeData.GetRecordByKey(BuildID).Kind;
      int num = (int) stageDataController.StageRecord[2];
      if ((int) stageDataController.limitRecord[2] == (int) stageDataController.StageRecord[2])
        ++num;
      List<byte> MonorList1 = this.BuildManorGroupIndexTbl[0];
      for (ushort index = 0; (int) index < MonorList1.Count; ++index)
      {
        BuildManorData recordByIndex = DataManager.Instance.BuildManorData.GetRecordByIndex((int) MonorList1[(int) index]);
        if ((int) recordByIndex.Kind == (int) kind && this.AllBuildsData[(int) recordByIndex.ID].BuildID == (ushort) 0)
        {
          if (!NewbieManager.IsWorking())
            this.GuideBuildID = BuildID;
          this.FindNearMainTown(ref recordByIndex, MonorList1, (int) index + 1, MonorList1.Count - ((int) index + 1), ref searchGroupID, ref searchManorID);
          DataManager.msgBuffer[0] = (byte) 24;
          GameConstants.GetBytes(searchGroupID, DataManager.msgBuffer, 1);
          GameConstants.GetBytes(searchManorID, DataManager.msgBuffer, 3);
          GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
          if (!UiGuide)
            return;
          instance2.GuideParm1 = (byte) 1;
          instance2.GuideParm2 = BuildID;
          return;
        }
      }
      for (ushort index1 = 1; (int) index1 < this.BuildManorGroupIndexTbl.Length; ++index1)
      {
        List<byte> MonorList2 = this.BuildManorGroupIndexTbl[(int) index1];
        BuildManorData recordByIndex = DataManager.Instance.BuildManorData.GetRecordByIndex((int) MonorList2[0]);
        if ((int) recordByIndex.Kind == (int) kind)
        {
          if (num < (int) index1)
          {
            GUIManager.Instance.AddHUDMessage(instance1.mStringTable.GetStringByID(5802U), (ushort) byte.MaxValue);
            return;
          }
          for (int index2 = 0; index2 < MonorList2.Count; ++index2)
          {
            recordByIndex = DataManager.Instance.BuildManorData.GetRecordByIndex((int) MonorList2[index2]);
            if (this.AllBuildsData[(int) recordByIndex.ID].BuildID == (ushort) 0)
            {
              if (!NewbieManager.IsWorking())
                this.GuideBuildID = BuildID;
              this.FindNearMainTown(ref recordByIndex, MonorList2, index2 + 1, MonorList2.Count - (index2 + 1), ref searchGroupID, ref searchManorID);
              DataManager.msgBuffer[0] = (byte) 24;
              GameConstants.GetBytes(searchGroupID, DataManager.msgBuffer, 1);
              GameConstants.GetBytes(searchManorID, DataManager.msgBuffer, 3);
              GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
              if (!UiGuide)
                return;
              instance2.GuideParm1 = (byte) 1;
              instance2.GuideParm2 = BuildID;
              return;
            }
          }
        }
      }
      GUIManager.Instance.AddHUDMessage(instance1.mStringTable.GetStringByID(5803U), (ushort) byte.MaxValue);
    }
  }

  public void ManorGuild(ushort BuildID, bool UiGuide = false)
  {
    GUIManager instance1 = GUIManager.Instance;
    DataManager instance2 = DataManager.Instance;
    RoleBuildingData buildData = this.GetBuildData(BuildID, (ushort) 0);
    ushort searchGroupID = 0;
    ushort searchManorID = 0;
    instance1.BuildGuildQueue = (ushort) 0;
    Door menu = instance1.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu == (UnityEngine.Object) null)
      return;
    if (menu.m_eMapMode == EUIOriginMapMode.KingdomMap)
      instance1.BuildGuildQueue = BuildID;
    if (buildData.BuildID > (ushort) 0)
    {
      if (menu.m_eMapMode == EUIOriginMapMode.KingdomMap)
      {
        instance1.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToMap);
      }
      else
      {
        BuildManorData recordByKey = instance2.BuildManorData.GetRecordByKey(buildData.ManorID);
        DataManager.msgBuffer[0] = (byte) 24;
        GameConstants.GetBytes(recordByKey.MapGroup, DataManager.msgBuffer, 1);
        GameConstants.GetBytes(recordByKey.ID, DataManager.msgBuffer, 3);
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        if (!UiGuide)
          return;
        instance1.GuideParm1 = (byte) 2;
        instance1.GuideParm2 = buildData.ManorID;
      }
    }
    else
    {
      bool flag = false;
      if (this.BuildingManorID > (ushort) 0 && (int) this.BuildingManorID < this.AllBuildsData.Length && (int) this.AllBuildsData[(int) this.BuildingManorID].BuildID == (int) BuildID)
      {
        BuildManorData recordByKey = DataManager.Instance.BuildManorData.GetRecordByKey(this.BuildingManorID);
        DataManager.msgBuffer[0] = (byte) 24;
        GameConstants.GetBytes(recordByKey.MapGroup, DataManager.msgBuffer, 1);
        GameConstants.GetBytes(recordByKey.ID, DataManager.msgBuffer, 3);
        GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
      }
      else
      {
        StageManager stageDataController = DataManager.StageDataController;
        byte kind = instance2.BuildsTypeData.GetRecordByKey(BuildID).Kind;
        int num = (int) stageDataController.StageRecord[2];
        if ((int) stageDataController.limitRecord[2] == (int) stageDataController.StageRecord[2])
          ++num;
        List<byte> MonorList1 = this.BuildManorGroupIndexTbl[0];
        BuildManorData recordByIndex;
        for (ushort index = 0; (int) index < MonorList1.Count; ++index)
        {
          recordByIndex = DataManager.Instance.BuildManorData.GetRecordByIndex((int) MonorList1[(int) index]);
          if ((int) recordByIndex.Kind == (int) kind && (int) recordByIndex.ID < this.AllBuildsData.Length && this.AllBuildsData[(int) recordByIndex.ID].BuildID == (ushort) 0)
          {
            if (!NewbieManager.IsWorking())
              this.GuideBuildID = BuildID;
            this.FindNearMainTown(ref recordByIndex, MonorList1, (int) index + 1, MonorList1.Count - ((int) index + 1), ref searchGroupID, ref searchManorID);
            DataManager.msgBuffer[0] = (byte) 24;
            GameConstants.GetBytes(searchGroupID, DataManager.msgBuffer, 1);
            GameConstants.GetBytes(searchManorID, DataManager.msgBuffer, 3);
            flag = true;
            if (UiGuide)
            {
              instance1.GuideParm1 = (byte) 1;
              instance1.GuideParm2 = BuildID;
              break;
            }
            break;
          }
        }
        for (ushort index1 = 1; (int) index1 < this.BuildManorGroupIndexTbl.Length && !flag; ++index1)
        {
          List<byte> MonorList2 = this.BuildManorGroupIndexTbl[(int) index1];
          for (int index2 = 0; index2 < MonorList2.Count && !flag && (index1 >= (ushort) 8 || index2 <= 0); ++index2)
          {
            recordByIndex = DataManager.Instance.BuildManorData.GetRecordByIndex((int) MonorList2[index2]);
            if ((int) recordByIndex.Kind == (int) kind)
            {
              if (num < (int) index1)
              {
                GUIManager.Instance.AddHUDMessage(instance2.mStringTable.GetStringByID(5802U), (ushort) byte.MaxValue);
                return;
              }
              for (int index3 = 0; index3 < MonorList2.Count; ++index3)
              {
                recordByIndex = DataManager.Instance.BuildManorData.GetRecordByIndex((int) MonorList2[index3]);
                if (this.AllBuildsData[(int) recordByIndex.ID].BuildID == (ushort) 0 && (int) kind == (int) recordByIndex.Kind)
                {
                  if (!NewbieManager.IsWorking())
                    this.GuideBuildID = BuildID;
                  this.FindNearMainTown(ref recordByIndex, MonorList2, index3 + 1, MonorList2.Count - (index3 + 1), ref searchGroupID, ref searchManorID);
                  DataManager.msgBuffer[0] = (byte) 24;
                  GameConstants.GetBytes(searchGroupID, DataManager.msgBuffer, 1);
                  GameConstants.GetBytes(searchManorID, DataManager.msgBuffer, 3);
                  flag = true;
                  if (UiGuide)
                  {
                    instance1.GuideParm1 = (byte) 1;
                    instance1.GuideParm2 = BuildID;
                    break;
                  }
                  break;
                }
              }
            }
          }
        }
        if (flag)
        {
          if (instance1.BuildGuildQueue > (ushort) 0)
            instance1.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.ChangeToMap);
          else
            GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
        }
        else
          GUIManager.Instance.AddHUDMessage(instance2.mStringTable.GetStringByID(5803U), (ushort) byte.MaxValue);
      }
    }
  }

  public void ArneaGuild()
  {
    DataManager.msgBuffer[0] = (byte) 25;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void DugoutGuild()
  {
    DataManager.msgBuffer[0] = (byte) 26;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void BlackMarketGuild()
  {
    DataManager.msgBuffer[0] = (byte) 27;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void WarLobbyGuide()
  {
    DataManager.msgBuffer[0] = (byte) 28;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void CasinoGuide()
  {
    DataManager.msgBuffer[0] = (byte) 29;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void LaboratoryGuide()
  {
    DataManager.msgBuffer[0] = (byte) 30;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    this.bHideLaboryPromptLock = (byte) 1;
    this.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public void PetListGuide()
  {
    DataManager.msgBuffer[0] = (byte) 31;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void OpenWarlobbyUI()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    menu.OpenMenu(EGUIWindow.UI_WarLobby, (int) this.GuideParm, 11);
  }

  private void FindNearMainTown(
    ref BuildManorData ManorData,
    List<byte> MonorList,
    int Begin,
    int Num,
    ref ushort searchGroupID,
    ref ushort searchManorID)
  {
    byte searchPriority = ManorData.SearchPriority;
    byte kind = ManorData.Kind;
    searchGroupID = ManorData.MapGroup;
    searchManorID = ManorData.ID;
    for (ushort index = 0; (int) index < Num; ++index)
    {
      ManorData = DataManager.Instance.BuildManorData.GetRecordByIndex((int) MonorList[Begin + (int) index]);
      if ((int) ManorData.SearchPriority < (int) searchPriority && (int) ManorData.Kind == (int) kind && this.AllBuildsData[(int) ManorData.ID].BuildID == (ushort) 0)
      {
        searchPriority = ManorData.SearchPriority;
        searchGroupID = ManorData.MapGroup;
        searchManorID = ManorData.ID;
      }
    }
  }

  public byte CheckLevelupRule(ushort BuildID, byte Level)
  {
    int BeginIndex = 0;
    int Num = 0;
    DataManager instance = DataManager.Instance;
    if (instance.BuildsTypeData.GetRecordByKey(BuildID).Kind == (byte) 3 && (Level == (byte) 1 && this.GetBuildNumByID(BuildID) > (byte) 0 || (int) this.BuildingManorID < this.AllBuildsData.Length && (int) this.AllBuildsData[(int) this.BuildingManorID].BuildID == (int) BuildID))
      return 3;
    BuildLevelRequest levelRequestData = this.GetBuildLevelRequestData(BuildID, Level);
    if (levelRequestData.GroupID > (ushort) 0)
      this.GetLevelRequestGroupIndex(levelRequestData.GroupID, ref BeginIndex, ref Num);
    if (Num > 0)
    {
      for (int Index = BeginIndex; Index < BeginIndex + Num; ++Index)
      {
        BuildLevelRequestGroup recordByIndex = instance.BuildsLevelRequestGroup.GetRecordByIndex(Index);
        if (recordByIndex.ConditionType == (byte) 1)
        {
          if ((int) this.GetBuildData(recordByIndex.Condition, (ushort) 0).Level < (int) recordByIndex.Num)
            return 2;
        }
        else if (recordByIndex.ConditionType == (byte) 2 && (int) instance.GetCurItemQuantity(recordByIndex.Condition, (byte) 0) < (int) recordByIndex.Num)
          return 2;
      }
    }
    return levelRequestData.RequestFood > instance.Resource[0].Stock || levelRequestData.RequestWood > instance.Resource[2].Stock || levelRequestData.RequestIron > instance.Resource[3].Stock || levelRequestData.RequestRock > instance.Resource[1].Stock || levelRequestData.RequestGold > instance.Resource[4].Stock ? (byte) 1 : (byte) 0;
  }

  public byte GetBuildNumByID(ushort BuildID)
  {
    this.SortBuildData();
    return this.BuildIDCount == null || this.BuildIDCount.Length <= (int) BuildID ? (byte) 0 : this.BuildIDCount[(int) BuildID];
  }

  public void UpdateLevelupResource()
  {
    if (this.AllBuildsData == null)
      this.InitialBuildData();
    DataManager instance = DataManager.Instance;
    if (!instance.MySysSetting.bShowBuildUp)
      return;
label_13:
    for (byte index = 1; (int) index < this.BuildlevelupCheck.Length; ++index)
    {
      this.BuildlevelupCheck[(int) index] = (byte) 0;
      byte Index1 = 0;
      ushort BuildID1 = (ushort) index;
      if (BuildID1 == (ushort) 16 && this.GetBuildData(BuildID1, (ushort) Index1).Level == (byte) 9)
        this.BuildlevelupCheck[(int) index] = (byte) 9;
      else if (this.GetBuildNumByID(BuildID1) == (byte) 1 && this.GetBuildData(BuildID1, (ushort) Index1).Level == (byte) 25)
      {
        this.BuildlevelupCheck[(int) index] = (byte) 25;
      }
      else
      {
        byte Level;
        BuildLevelRequest levelRequestData;
        do
        {
          int BuildID2 = (int) BuildID1;
          int Index2 = Index1++;
          RoleBuildingData buildData;
          if ((buildData = this.GetBuildData((ushort) BuildID2, (ushort) Index2)).BuildID != (ushort) 0)
          {
            Level = Math.Min((byte) 25, (byte) ((uint) buildData.Level + 1U));
            levelRequestData = GUIManager.Instance.BuildingData.GetBuildLevelRequestData(BuildID1, Level);
          }
          else
            goto label_13;
        }
        while (levelRequestData.RequestFood > instance.Resource[0].Stock || levelRequestData.RequestRock > instance.Resource[1].Stock || levelRequestData.RequestWood > instance.Resource[2].Stock || levelRequestData.RequestIron > instance.Resource[3].Stock || levelRequestData.RequestGold > instance.Resource[4].Stock);
        this.BuildlevelupCheck[(int) index] = Level;
      }
    }
    this.UpdateBuildState((byte) 8, (ushort) byte.MaxValue);
  }

  private void SortBuildData()
  {
    if (!this.NeedSortData || this.SortBuildsData == null || this.SortBuildStart == null || this.BuildIDCount == null)
      return;
    Array.Sort<ushort>(this.SortBuildsData, (IComparer<ushort>) this.buildDataComparer);
    Array.Clear((Array) this.SortBuildStart, 0, this.SortBuildStart.Length);
    Array.Clear((Array) this.BuildIDCount, 0, this.BuildIDCount.Length);
    this.NeedSortData = false;
    ushort num = 0;
    for (ushort index1 = 0; (int) index1 < this.SortBuildsData.Length; ++index1)
    {
      ushort index2 = this.SortBuildsData[(int) index1];
      if (this.AllBuildsData[(int) index2].BuildID != (ushort) 0 && this.AllBuildsData[(int) index2].Level != (byte) 0)
      {
        ushort buildId = this.AllBuildsData[(int) index2].BuildID;
        if ((int) buildId != (int) num)
        {
          this.SortBuildStart[(int) buildId] = index1;
          this.BuildIDCount[(int) buildId] = (byte) 1;
          num = buildId;
        }
        else
          ++this.BuildIDCount[(int) this.AllBuildsData[(int) index2].BuildID];
      }
    }
  }

  public void GetBuildSprite(
    ushort ManorID,
    SpriteRenderer spriterender,
    SpriteRenderer levelrender)
  {
    if (this.AllBuildsData == null)
      this.InitialBuildData();
    if ((double) this.SpriteBaseSizeY <= 0.0)
      this.SpriteBaseSizeY = this.mapspriteManager.GetSpriteByName("space_01-1").rect.size.y;
    BuildManorData recordByKey = DataManager.Instance.BuildManorData.GetRecordByKey(ManorID);
    if (ManorID < (ushort) 100 && (int) ManorID != (int) recordByKey.ID)
      return;
    this.SpriteName.Remove(0, this.SpriteName.Length);
    spriterender.name = this.SpriteName.AppendFormat("Sprite{0}", (object) ManorID).ToString();
    Vector3 position = spriterender.transform.position;
    float new_x1;
    float new_y1;
    float new_z1;
    switch ((byte) ManorID)
    {
      case 100:
        new_x1 = 22f;
        new_y1 = 1f;
        new_z1 = 60f;
        spriterender.sprite = this.mapspriteManager.GetSpriteByName("herotower");
        if (DataManager.StageDataController.StageRecord[2] == (ushort) 0)
          spriterender.enabled = false;
        spriterender.sortingOrder = -33;
        break;
      case 101:
        new_x1 = 119.07f;
        new_y1 = 2.8f;
        new_z1 = 78.78f;
        if (DataManager.StageDataController.StageRecord[2] < (ushort) 2)
          spriterender.enabled = false;
        else
          spriterender.sprite = this.mapspriteManager.GetSpriteByName("Arena");
        spriterender.sortingOrder = -33;
        break;
      case 102:
        new_x1 = -22.22f;
        new_y1 = 13.39f;
        new_z1 = -22.2f;
        spriterender.sprite = this.mapspriteManager.GetSpriteByName("build_22-1");
        spriterender.sortingOrder = -33;
        break;
      case 103:
        new_x1 = 1.6f;
        new_y1 = -1.5f;
        new_z1 = 39.12f;
        spriterender.sprite = this.mapspriteManager.GetSpriteByName("Cantonment");
        spriterender.enabled = false;
        spriterender.sortingOrder = -33;
        break;
      case 104:
        new_x1 = 51.5f;
        new_y1 = -0.5f;
        new_z1 = 87.44f;
        if (DataManager.StageDataController.StageRecord[2] < (ushort) 2)
          spriterender.enabled = false;
        else
          spriterender.sprite = this.mapspriteManager.GetSpriteByName("cargo_ship");
        spriterender.sortingOrder = -33;
        break;
      case 105:
        new_x1 = -5.179f;
        new_y1 = 0.6343f;
        new_z1 = 130.0719f;
        spriterender.sprite = this.mapspriteManager.GetSpriteByName("Dark_Alchemy");
        spriterender.sortingOrder = -33;
        break;
      case 106:
        new_x1 = 131.4549f;
        new_y1 = 9.1178f;
        new_z1 = -7.681f;
        if (DataManager.StageDataController.StageRecord[2] < (ushort) 8)
          spriterender.enabled = false;
        else
          spriterender.sprite = this.mapspriteManager.GetSpriteByName("Underground_city");
        spriterender.sortingOrder = -33;
        break;
      default:
        if (this.AllBuildsData[(int) ManorID].BuildID > (ushort) 0)
        {
          new_x1 = (float) ((recordByKey.bPosionX <= (ushort) 30000 ? (double) recordByKey.bPosionX : (double) recordByKey.bPosionX - (double) ushort.MaxValue) * 0.0099999997764825821);
          new_y1 = (float) ((recordByKey.bPosionY <= (ushort) 32768 ? (double) recordByKey.bPosionY : (double) recordByKey.bPosionY - (double) ushort.MaxValue) * 0.0099999997764825821);
          new_z1 = (float) ((recordByKey.bPosionZ <= (ushort) 32768 ? (double) recordByKey.bPosionZ : (double) recordByKey.bPosionZ - (double) ushort.MaxValue) * 0.0099999997764825821);
          if (this.AllBuildsData[(int) ManorID].BuildID == (ushort) 8)
          {
            spriterender.sprite = this.castleSkin.GetSprite(this.CastleID, this.AllBuildsData[(int) ManorID].Level);
            spriterender.material = this.castleSkin.GetMaterial(this.CastleID, this.AllBuildsData[(int) ManorID].Level);
            spriterender.sortingOrder = -34;
          }
          else
          {
            spriterender.sprite = this.GetBuildSprite(this.AllBuildsData[(int) ManorID].BuildID, this.AllBuildsData[(int) ManorID].Level);
            spriterender.sortingOrder = -33;
          }
          levelrender.enabled = true;
          break;
        }
        float new_x2 = (float) ((recordByKey.mPosionX <= (ushort) 30000 ? (double) recordByKey.mPosionX : (double) recordByKey.mPosionX - (double) ushort.MaxValue) * 0.0099999997764825821);
        float new_y2 = (float) ((recordByKey.mPosionY <= (ushort) 32768 ? (double) recordByKey.mPosionY : (double) recordByKey.mPosionY - (double) ushort.MaxValue) * 0.0099999997764825821);
        float new_z2 = (float) ((recordByKey.mPosionZ <= (ushort) 32768 ? (double) recordByKey.mPosionZ : (double) recordByKey.mPosionZ - (double) ushort.MaxValue) * 0.0099999997764825821);
        position.Set(new_x2, new_y2, new_z2);
        spriterender.transform.position = position;
        spriterender.sprite = recordByKey.Kind != (byte) 1 ? (recordByKey.Kind != (byte) 2 ? (recordByKey.Kind != (byte) 3 ? this.mapspriteManager.GetSpriteByName("space_01-4") : this.mapspriteManager.GetSpriteByName("space_01-3")) : this.mapspriteManager.GetSpriteByName("space_01-2")) : this.mapspriteManager.GetSpriteByName("space_01-1");
        Quaternion rotation1 = spriterender.transform.rotation with
        {
          eulerAngles = this.BuildRot
        };
        spriterender.transform.rotation = rotation1;
        float num = 9f;
        position.Set(num, num, num);
        spriterender.transform.localScale = position;
        levelrender.sprite = (Sprite) null;
        levelrender.enabled = false;
        spriterender.sortingOrder = -61;
        return;
    }
    position.Set(new_x1, new_y1, new_z1);
    spriterender.transform.position = position;
    Quaternion rotation2 = spriterender.transform.rotation with
    {
      eulerAngles = ManorID != (ushort) 103 ? this.BuildRot : new Vector3(30f, 185f, 3f)
    };
    spriterender.transform.rotation = rotation2;
    if ((int) ManorID < this.AllBuildsData.Length && this.AllBuildsData[(int) ManorID].BuildID == (ushort) 12)
      spriterender.transform.localScale = this.GateScale;
    else
      spriterender.transform.localScale = this.BaseBuildScale;
    if ((int) ManorID < this.AllBuildsData.Length && this.AllBuildsData[(int) ManorID].Level > (byte) 0)
    {
      this.SpriteName.Remove(0, this.SpriteName.Length);
      this.SpriteName.AppendFormat("rank_{0:00}", (object) this.AllBuildsData[(int) ManorID].Level);
      levelrender.sprite = this.mapspriteManager.GetSpriteByName(this.SpriteName.ToString());
      levelrender.transform.position = spriterender.transform.position;
      levelrender.transform.rotation = spriterender.transform.rotation;
      levelrender.transform.localScale = this.BaseBuildScale;
    }
    else
      levelrender.enabled = false;
  }

  public Sprite GetBuildSprite(ushort BuildID, byte Level)
  {
    if (this.mapspriteManager == null || this.AllBuildsData == null)
      return (Sprite) null;
    byte num = 1;
    if (BuildID != (ushort) 16)
    {
      if (Level >= (byte) 9 && Level < (byte) 17)
        num = (byte) 2;
      else if (Level >= (byte) 17 && Level < (byte) 25)
        num = (byte) 3;
      else if (Level >= (byte) 25)
        num = (byte) 4;
    }
    else if (Level >= (byte) 3 && Level < (byte) 6)
      num = (byte) 2;
    else if (Level >= (byte) 6 && Level < (byte) 9)
      num = (byte) 3;
    else if (Level >= (byte) 9)
      num = (byte) 4;
    this.SpriteName.Remove(0, this.SpriteName.Length);
    BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey(BuildID);
    if (BuildID == (ushort) 8)
      return this.castleSkin.GetUISprite((byte) 0, Level);
    this.SpriteName.AppendFormat("build_{0}-{1}", (object) recordByKey.GraphicID.ToString("d2"), (object) num);
    Sprite buildSprite = this.mapspriteManager.GetSpriteByName(this.SpriteName.ToString());
    if ((UnityEngine.Object) buildSprite == (UnityEngine.Object) null && BuildID != (ushort) 1)
      buildSprite = this.GetBuildSprite((ushort) 1, (byte) 1);
    return buildSprite;
  }

  public void NotifyOpenUI(ushort ManorID)
  {
    DataManager.msgBuffer[0] = (byte) 23;
    GameConstants.GetBytes(ManorID, DataManager.msgBuffer, 1);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void NotifyCloseUI()
  {
    DataManager.msgBuffer[0] = (byte) 33;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }

  public void OpenUI(ushort ManorID, Door doorController)
  {
    Debug.Log((object) ("SentBuild  " + (object) ManorID));
    bool bCameraMode = false;
    switch ((byte) ManorID)
    {
      case 100:
        if (DataManager.StageDataController.StageRecord[2] > (ushort) 1)
        {
          DataManager.StageDataController.resetStageMode(DataManager.StageDataController.inoutStageMode);
          DataManager.Instance.WorldCameraTransitionsPos = GameConstants.GoldGuy;
          GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.DoorOpenUp);
        }
        else
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(5899U), (ushort) byte.MaxValue);
        GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_Hero);
        break;
      case 101:
        if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 10)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9101U), (ushort) byte.MaxValue);
          break;
        }
        doorController.OpenMenu(EGUIWindow.UI_Arena);
        break;
      case 102:
        if (DataManager.StageDataController.StageRecord[2] < (ushort) 3)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8585U), (ushort) byte.MaxValue);
          break;
        }
        HideArmyManager.Instance.OpenHideArmyUI();
        break;
      case 103:
        doorController.OpenMenu(EGUIWindow.UI_Ambush);
        break;
      case 104:
        if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 13)
        {
          CString cstring = StringManager.Instance.StaticString1024();
          cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(1479U));
          cstring.IntToFormat(13L);
          cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9749U));
          GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
          break;
        }
        doorController.OpenMenu(EGUIWindow.UI_Merchantman);
        break;
      case 105:
        if (((long) DataManager.Instance.RoleAttr.Guide & 16777216L) == 0L && GUIManager.Instance.BoxID[0] == (ushort) 0)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12045U), (ushort) byte.MaxValue);
          break;
        }
        doorController.OpenMenu(EGUIWindow.UIAlchemy, bCameraMode: true);
        break;
      case 106:
        if (GamblingManager.Instance.m_GambleEventSave.State == EActivityState.EAS_None)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9182U), (ushort) byte.MaxValue);
          break;
        }
        GamblingManager.Instance.BattleMonsterID = GamblingManager.Instance.m_GambleEventSave.MonsterID;
        if (!DataManager.CheckGambleBattleResources())
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8350U), (ushort) byte.MaxValue);
          break;
        }
        if (NewbieManager.CheckGambleNormal())
          break;
        GamblingManager.Instance.Send_MSG_REQUEST_GAMBLE_INFO();
        break;
      default:
        EGUIWindow eWin;
        switch (this.AllBuildsData[(int) ManorID].BuildID)
        {
          case 0:
            eWin = EGUIWindow.UI_SuitBuilding;
            break;
          case 6:
            eWin = EGUIWindow.UI_Barrack;
            break;
          case 7:
            eWin = EGUIWindow.UI_Hospital;
            break;
          case 8:
            eWin = EGUIWindow.UI_Castle;
            break;
          case 9:
            eWin = EGUIWindow.UI_Warehouse;
            break;
          case 10:
            eWin = EGUIWindow.UI_TechInstitute;
            break;
          case 11:
            eWin = EGUIWindow.UI_WarLobby;
            break;
          case 12:
            eWin = EGUIWindow.UI_CityWall;
            break;
          case 13:
            eWin = EGUIWindow.UI_Watchtower;
            break;
          case 14:
            eWin = EGUIWindow.UI_Embassy;
            break;
          case 15:
            eWin = EGUIWindow.UI_Forge;
            break;
          case 16:
            eWin = EGUIWindow.UI_Crypt;
            if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 17)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(3929U), (ushort) byte.MaxValue);
              return;
            }
            break;
          case 17:
            eWin = EGUIWindow.UI_Market;
            break;
          case 18:
            eWin = EGUIWindow.UI_Jail;
            break;
          case 19:
            bCameraMode = true;
            eWin = EGUIWindow.UI_Altar;
            break;
          case 20:
            eWin = EGUIWindow.UI_PetList;
            break;
          case 21:
            eWin = EGUIWindow.UI_PetResourceStation;
            break;
          case 22:
            eWin = EGUIWindow.UI_PetFusionbuilding;
            break;
          case 23:
            eWin = EGUIWindow.UI_PetTrainingCenter;
            break;
          default:
            eWin = EGUIWindow.UIResourceBuilding;
            break;
        }
        this.OpenUiManorID = ManorID;
        doorController.OpenMenu(eWin, (int) ManorID, (int) this.AllBuildsData[(int) ManorID].BuildID, bCameraMode);
        this.GuideBuildID = (ushort) 0;
        this.GuideSoldierNum = 0U;
        if (eWin == EGUIWindow.UI_CityWall)
          break;
        this.GuideSoldierID = (ushort) 0;
        break;
    }
  }

  public RoleBuildingData GetBuildData(ushort BuildID, ushort Index)
  {
    if (this.AllBuildsData == null)
      this.InitialBuildData();
    if (this.BuildIDCount == null)
      return new RoleBuildingData();
    this.SortBuildData();
    return (int) this.BuildIDCount[(int) BuildID] > (int) Index ? this.AllBuildsData[(int) this.SortBuildsData[(int) this.SortBuildStart[(int) BuildID] + (int) Index]] : this.AllBuildsData[0];
  }

  public void sendStartBuilding(ushort MonorID, ushort BuildID)
  {
    if (NewbieManager.IsNewbie || !GUIManager.Instance.ShowUILock(EUILock.Build))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_BUILDBEGIN;
    messagePacket.AddSeqId();
    messagePacket.Add(MonorID);
    messagePacket.Add(BuildID);
    messagePacket.Send();
  }

  public void sendBuildingCancel()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Build))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_BUILDCANCEL;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void sendBuildCompleteFree()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Build))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_BUILDFREE;
    messagePacket.AddSeqId();
    messagePacket.Send();
    if (DataManager.Instance.OpenBuildingWindowUpdateNoClose == (byte) 1)
      this.bClose = false;
    else
      this.bClose = true;
  }

  public void sendBuildCompleteImmediate(ushort ManorID, ushort BuildID = 0)
  {
    if (NewbieManager.IsNewbie || !GUIManager.Instance.ShowUILock(EUILock.Build))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_INSTANTBUILD;
    messagePacket.AddSeqId();
    messagePacket.Add(ManorID);
    if (BuildID == (ushort) 0)
      messagePacket.Add(this.AllBuildsData[(int) ManorID].BuildID);
    else
      messagePacket.Add(BuildID);
    messagePacket.Send();
    if (BuildID != (ushort) 8)
      return;
    NewbieManager.BuildCastleImmediate = true;
  }

  public void sendBuildFinish()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Build))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_FINISHBUILD;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void sendBuildDismantle(ushort ManorID)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Build))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_DECONSTRBEGIN;
    messagePacket.AddSeqId();
    messagePacket.Add(ManorID);
    messagePacket.Send();
  }

  public void sendBuildDismantleCancel()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Build))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_DECONSTRCANCEL;
    messagePacket.AddSeqId();
    messagePacket.Add(this.BuildingManorID);
    messagePacket.Send();
  }

  public void sendBuildDismantleImmediate(ushort ManorID)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Build))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_INSTANTDECONSTR;
    messagePacket.AddSeqId();
    messagePacket.Add(ManorID);
    messagePacket.Send();
  }

  public void sendBuildDismantleFinish()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Build))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_FINISHDECONSTR;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void RecvAllBuildData(MessagePacket MP)
  {
    if (this.AllBuildsData == null)
      this.InitialBuildData();
    Array.Clear((Array) this.AllBuildsData, 0, this.AllBuildsData.Length);
    if (this.BuildIDCount != null)
      Array.Clear((Array) this.BuildIDCount, 0, this.BuildIDCount.Length);
    for (ushort index = 0; (int) index < this.AllBuildsData.Length; ++index)
      this.AllBuildsData[(int) index].ManorID = index;
    byte num1 = MP.ReadByte();
    for (byte index1 = 0; (int) index1 < (int) num1; ++index1)
    {
      ushort index2 = MP.ReadUShort();
      if ((int) index2 >= this.AllBuildsData.Length)
      {
        int num2 = (int) MP.ReadUShort();
        int num3 = (int) MP.ReadByte();
      }
      else
      {
        ushort InKey = MP.ReadUShort();
        byte num4 = MP.ReadByte();
        if ((int) DataManager.Instance.BuildsTypeData.GetRecordByKey(InKey).BuildID == (int) InKey)
        {
          this.AllBuildsData[(int) index2].BuildID = InKey;
          this.AllBuildsData[(int) index2].Level = num4;
        }
      }
    }
    this.bHideLaboryPromptLock = (byte) 0;
    if (this.BuildingManorID > (ushort) 0)
    {
      this.UpdateBuildState((byte) 3, this.BuildingManorID);
      this.BuildingManorID = (ushort) 0;
    }
    this.NeedSortData = true;
    this.ImmEffect = (byte) 0;
    DataManager.MissionDataManager.SetCompleteWhileLogin(eMissionKind.Build);
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Build);
    for (byte index = 0; index < (byte) 7; ++index)
      DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) (21U + (uint) index), (ushort) this.GetBuildNumByID((ushort) ((uint) index + 1U)));
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuitBuilding, 0);
    if (this.GetBuildData((ushort) 8, (ushort) 0).Level > (byte) 2)
      GUIManager.Instance.SetFrontMark((byte) 1);
    AssetManager.SetCastleLevel(this.GetBuildData((ushort) 12, (ushort) 0).Level, (byte) 0);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 6, (ushort) byte.MaxValue);
    ActivityManager.Instance.CheckCastleLevel();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 19);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 16);
  }

  public void RecvBuildingQueue(MessagePacket MP)
  {
    if (this.AllBuildsData == null)
      this.InitialBuildData();
    this.QueueBuildType = MP.ReadByte();
    ushort Parm = MP.ReadUShort();
    if ((int) Parm >= this.AllBuildsData.Length)
    {
      this.QueueBuildType = (byte) 0;
    }
    else
    {
      this.BuildingManorID = Parm;
      this.AllBuildsData[(int) Parm].BuildID = MP.ReadUShort();
      int num = (int) MP.ReadByte();
      long StartTime = MP.ReadLong();
      uint TotalTime = MP.ReadUInt();
      this.UpdateBuildState((byte) 2, Parm);
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, this.BuildingManorID != (ushort) 0, StartTime, TotalTime);
      DataManager.Instance.SetRecvQueueBarData(0);
      PetManager.Instance.SetTrainingCenterNum();
    }
  }

  public void RecvUpdateBuildData(MessagePacket MP)
  {
    ushort Parm = MP.ReadUShort();
    if (this.AllBuildsData.Length <= (int) Parm)
      return;
    this.BuildingManorID = Parm;
    this.AllBuildsData[(int) Parm].BuildID = MP.ReadUShort();
    byte num1 = MP.ReadByte();
    if (Parm == (ushort) 1 && num1 == (byte) 3 && !NewbieManager.IsWorking() && NewbieManager.EntryTeach(ETeachKind.TURBO) && NewbieManager.Get() != null)
      NewbieManager.Get().CheckTimeBarStatus();
    long StartTime = MP.ReadLong();
    uint TotalTime = MP.ReadUInt();
    DataManager instance = DataManager.Instance;
    for (byte index = 0; (int) index < instance.Resource.Length; ++index)
      instance.Resource[(int) index].Stock = MP.ReadUInt();
    ushort num2 = MP.ReadUShort();
    for (ushort index = 0; (int) index < (int) num2; ++index)
    {
      ushort ItemID = MP.ReadUShort();
      ushort Quantity = (ushort) ((uint) instance.GetCurItemQuantity(ItemID, (byte) 0) - (uint) MP.ReadUShort());
      DataManager.Instance.SetCurItemQuantity(ItemID, Quantity, (byte) 0, 0L);
    }
    GameManager.OnRefresh(NetworkNews.Refresh_Item);
    this.UpdateBuildState((byte) 2, Parm);
    this.QueueBuildType = (byte) 1;
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, true, StartTime, TotalTime);
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
    GameConstants.GetBytes((ushort) 1, DataManager.msgBuffer, 0);
    GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
    AudioManager.Instance.PlayUISFX(UIKind.Construction);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
    GUIManager.Instance.HideUILock(EUILock.Build);
    if (!IGGGameSDK.Instance.GetStarStatus() || num1 != (byte) 5 || this.AllBuildsData[(int) Parm].BuildID != (ushort) 8)
      return;
    bool result1 = false;
    long result2 = 0;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.IntToFormat(NetworkManager.UserID);
    cstring.AppendFormat("{0}_Score_UseID");
    long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result2);
    if (result2 != 0L)
    {
      cstring.ClearString();
      cstring.IntToFormat(result2);
      cstring.AppendFormat("{0}_Score_bScoreFirst");
      bool.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result1);
      if (result1)
        return;
      GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_TreasureBox, 4, openMode: (byte) 0);
    }
    else
      GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_TreasureBox, 4, openMode: (byte) 0);
  }

  public void RecvBuildCancel(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    for (byte index = 0; (int) index < instance.Resource.Length; ++index)
      instance.Resource[(int) index].Stock = MP.ReadUInt();
    this.NeedSortData = true;
    ushort num = MP.ReadUShort();
    for (ushort index = 0; (int) index < (int) num; ++index)
    {
      ushort ItemID = MP.ReadUShort();
      ushort Quantity = (ushort) ((uint) instance.GetCurItemQuantity(ItemID, (byte) 0) + (uint) MP.ReadUShort());
      instance.SetCurItemQuantity(ItemID, Quantity, (byte) 0, 0L);
    }
    GameManager.OnRefresh(NetworkNews.Refresh_Item);
    ushort buildingManorId = this.BuildingManorID;
    this.BuildingManorID = (ushort) 0;
    if ((int) buildingManorId < this.AllBuildsData.Length && this.AllBuildsData[(int) buildingManorId].Level == (byte) 0)
      this.AllBuildsData[(int) buildingManorId].BuildID = (ushort) 0;
    this.UpdateBuildState((byte) 4, buildingManorId);
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0U);
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
    GameConstants.GetBytes((ushort) 1, DataManager.msgBuffer, 0);
    GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuitBuilding, 0);
    GUIManager.Instance.HideUILock(EUILock.Build);
  }

  public void RecvBuildComplete(MessagePacket MP)
  {
    this.BuildingManorID = (ushort) 0;
    ushort index1 = MP.ReadUShort();
    if ((int) index1 >= this.AllBuildsData.Length)
      return;
    this.AllBuildsData[(int) index1].BuildID = MP.ReadUShort();
    this.NeedSortData = true;
    this.AllBuildsData[(int) index1].Level = MP.ReadByte();
    if (NewbieManager.IsTeachWorking(ETeachKind.TURBO) && index1 == (ushort) 1 && this.AllBuildsData[(int) index1].Level == (byte) 3)
    {
      NewbieManager.Get().IgnoreStep(true);
      NewbieManager.Get().RestoreTimeBarStatus();
    }
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Build);
    if (this.AllBuildsData[(int) index1].BuildID == (ushort) 8)
    {
      for (int index2 = 0; index2 < 5; ++index2)
        DataManager.Instance.Resource[index2].Stock = MP.ReadUInt();
      for (ushort index3 = 0; index3 < (ushort) 4; ++index3)
      {
        ushort ItemID = MP.ReadUShort();
        ushort Quantity = MP.ReadUShort();
        if (ItemID != (ushort) 0)
          DataManager.Instance.SetCurItemQuantity(ItemID, Quantity, (byte) 0, 0L);
      }
      this.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
      GUIManager.Instance.SetFrontMark((byte) 1);
      if (this.AllBuildsData[(int) index1].Level == (byte) 15)
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 6);
    }
    this.ImmEffect = (byte) 0;
    this.UpdateBuildState((byte) 3, index1);
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0U);
    this.ShowBuildHUD(index1, (byte) 1);
    if (!this.bClose)
    {
      GameConstants.GetBytes((ushort) 0, DataManager.msgBuffer, 0);
    }
    else
    {
      GameConstants.GetBytes((ushort) 1, DataManager.msgBuffer, 0);
      this.bClose = false;
    }
    GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
    DataManager.Instance.OpenBuildingWindowUpdateNoClose = (byte) 0;
    if (this.AllBuildsData[(int) index1].BuildID == (ushort) 8)
    {
      bool flag = false;
      Door menu = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
      if ((UnityEngine.Object) menu != (UnityEngine.Object) null && menu.m_eMode == EUIOriginMode.Show && menu.m_eMapMode == EUIOriginMapMode.OriginMap)
        flag = true;
      if ((UnityEngine.Object) GUIManager.Instance.m_SecWindow != (UnityEngine.Object) null || (UnityEngine.Object) GUIManager.Instance.m_OtheCanvas != (UnityEngine.Object) null)
        flag = false;
      if (!NewbieManager.IsWorking() && flag)
      {
        if (this.AllBuildsData[(int) index1].Level == (byte) 5)
          NewbieManager.EntryTeach(ETeachKind.ACTIVITY);
        else if (this.AllBuildsData[(int) index1].Level == (byte) 10)
          NewbieManager.EntryTeach(ETeachKind.ARENA);
        else if (this.AllBuildsData[(int) index1].Level == (byte) 13)
          NewbieManager.EntryTeach(ETeachKind.BLACK_MARKET);
        else if (this.AllBuildsData[(int) index1].Level == (byte) 9)
          NewbieManager.EntryTeach(ETeachKind.DESHIELD);
      }
      AFAdvanceManager.Instance.CheckCastleLvEvent(GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level);
      FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.CASTLE_LEVEL, 0L, 0UL);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuitBuilding, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_DevelopmentDetails, 0);
    if (this.AllBuildsData[(int) index1].BuildID == (ushort) 13)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Watchtower_Details, 1);
    if (this.AllBuildsData[(int) index1].BuildID == (ushort) 12)
    {
      AssetManager.SetCastleLevel(this.AllBuildsData[(int) index1].Level, (byte) 0);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Trap, 2);
      GameManager.OnRefresh(NetworkNews.Refresh_Soldier);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hospital, 1);
    }
    if (this.AllBuildsData[(int) index1].BuildID == (ushort) 6)
      GameManager.OnRefresh(NetworkNews.Refresh_Soldier);
    if (this.AllBuildsData[(int) index1].BuildID == (ushort) 7)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hospital, 1);
    if (this.AllBuildsData[(int) index1].BuildID == (ushort) 8)
    {
      GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_CastleUpgradeReward, (int) this.AllBuildsData[(int) index1].Level, openMode: (byte) 0);
      GameManager.OnRefresh(NetworkNews.Refresh_Resource);
      ActivityManager.Instance.CheckCastleLevel();
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 19);
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 16);
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27);
      LandWalkerManager.SetNewCastleLevel(this.AllBuildsData[(int) index1].Level);
      if (NewbieManager.IsTeachWorking(ETeachKind.ACTIVITY))
        NewbieManager.CheckTeach(ETeachKind.ACTIVITY);
      else if (NewbieManager.IsTeachWorking(ETeachKind.ARENA))
        NewbieManager.CheckTeach(ETeachKind.ARENA);
      else if (NewbieManager.IsTeachWorking(ETeachKind.BLACK_MARKET))
        NewbieManager.CheckTeach(ETeachKind.BLACK_MARKET);
      else if (NewbieManager.IsTeachWorking(ETeachKind.DESHIELD))
        NewbieManager.CheckTeach(ETeachKind.DESHIELD);
      if (this.AllBuildsData[(int) index1].Level == (byte) 12)
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other, 2);
      if (this.AllBuildsData[(int) index1].Level == (byte) 7)
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other, 4);
    }
    if (this.AllBuildsData[(int) index1].BuildID == (ushort) 16)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_CryptDig, 0);
    if (this.AllBuildsData[(int) index1].BuildID == (ushort) 4)
      AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.BUILD_FARM);
    DataManager.MissionDataManager.CheckChanged(eMissionKind.Build, this.AllBuildsData[(int) index1].BuildID, (ushort) this.AllBuildsData[(int) index1].Level);
    if (this.AllBuildsData[(int) index1].BuildID >= (ushort) 1 && this.AllBuildsData[(int) index1].BuildID <= (ushort) 7)
      DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) (20U + (uint) this.AllBuildsData[(int) index1].BuildID), (ushort) this.GetBuildNumByID(this.AllBuildsData[(int) index1].BuildID));
    GUIManager.Instance.HideUILock(EUILock.Build);
  }

  public void RecvBuildErrMsg(MessagePacket MP)
  {
    MP.ReadByte();
    GUIManager.Instance.HideUILock(EUILock.Build);
  }

  public void RecvResources(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    for (byte index = 0; (int) index < instance.Resource.Length; ++index)
      instance.Resource[(int) index].SetResource(MP.ReadUInt(), MP.ReadLong());
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
  }

  public void RecvResourcesUpdate(MessagePacket MP)
  {
    byte index = MP.ReadByte();
    if ((int) index < DataManager.Instance.Resource.Length)
      DataManager.Instance.Resource[(int) index].SetResource(MP.ReadUInt(), MP.ReadLong());
    if (MP.ReadByte() == (byte) 1)
    {
      uint x = MP.ReadUInt();
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(3952U + (uint) index));
      cstring.IntToFormat((long) x, bNumber: true);
      cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12612U));
      GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) 35);
      GUIManager.Instance.m_SpeciallyEffect.mResValue[(int) index] = x;
      GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
      GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, (SpeciallyEffect_Kind) (16 + (int) index), ItemID: (ushort) 0, EndTime: 2f);
    }
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
  }

  public void RecvBuildCompleteImmediate(MessagePacket MP)
  {
    if (MP.ReadByte() == (byte) 0)
    {
      GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0, eSpentCredits.eBuildImmediate);
      ushort index1 = MP.ReadUShort();
      if ((int) index1 >= this.AllBuildsData.Length)
        return;
      this.AllBuildsData[(int) index1].BuildID = MP.ReadUShort();
      this.AllBuildsData[(int) index1].Level = MP.ReadByte();
      for (byte index2 = 0; index2 < (byte) 5; ++index2)
        DataManager.Instance.Resource[(int) index2].Stock = MP.ReadUInt();
      ushort num1 = MP.ReadUShort();
      ushort num2 = MP.ReadUShort();
      for (ushort index3 = 0; (int) index3 < (int) num1; ++index3)
      {
        ushort ItemID = MP.ReadUShort();
        ushort Quantity = (ushort) ((uint) DataManager.Instance.GetCurItemQuantity(ItemID, (byte) 0) - (uint) MP.ReadUShort());
        DataManager.Instance.SetCurItemQuantity(ItemID, Quantity, (byte) 0, 0L);
      }
      for (ushort index4 = 0; (int) index4 < (int) num2; ++index4)
        DataManager.Instance.SetCurItemQuantity(MP.ReadUShort(), MP.ReadUShort(), (byte) 0, 0L);
      this.ImmEffect = (byte) 1;
      this.UpdateBuildState((byte) 3, index1);
      this.NeedSortData = true;
      this.ShowBuildHUD(index1, (byte) 1);
      DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Build);
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 8)
      {
        AFAdvanceManager.Instance.CheckCastleLvEvent(GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level);
        FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.CASTLE_LEVEL, 0L, 0UL);
        if (!NewbieManager.IsWorking())
        {
          if (this.AllBuildsData[(int) index1].Level == (byte) 5)
            NewbieManager.EntryTeach(ETeachKind.ACTIVITY);
          else if (this.AllBuildsData[(int) index1].Level == (byte) 10)
            NewbieManager.EntryTeach(ETeachKind.ARENA);
          else if (this.AllBuildsData[(int) index1].Level == (byte) 13)
            NewbieManager.EntryTeach(ETeachKind.BLACK_MARKET);
          else if (this.AllBuildsData[(int) index1].Level == (byte) 9)
            NewbieManager.EntryTeach(ETeachKind.DESHIELD);
        }
        this.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
        GUIManager.Instance.SetFrontMark((byte) 1);
        if (this.AllBuildsData[(int) index1].Level == (byte) 15)
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 6);
      }
      GameConstants.GetBytes((ushort) 1, DataManager.msgBuffer, 0);
      GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuitBuilding, 0);
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 13)
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Watchtower_Details, 1);
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 12)
      {
        AssetManager.SetCastleLevel(this.AllBuildsData[(int) index1].Level, (byte) 0);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Trap, 2);
        GameManager.OnRefresh(NetworkNews.Refresh_Soldier);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hospital, 1);
      }
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 10)
        GameManager.OnRefresh(NetworkNews.Refresh_QBarTime);
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 6)
        GameManager.OnRefresh(NetworkNews.Refresh_Soldier);
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 7)
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hospital, 1);
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 8)
      {
        GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_CastleUpgradeReward, (int) this.AllBuildsData[(int) index1].Level, openMode: (byte) 0);
        ActivityManager.Instance.CheckCastleLevel();
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 19);
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 16);
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27);
        LandWalkerManager.SetNewCastleLevel(this.AllBuildsData[(int) index1].Level);
        if (NewbieManager.IsTeachWorking(ETeachKind.ACTIVITY))
          NewbieManager.CheckTeach(ETeachKind.ACTIVITY);
        else if (NewbieManager.IsTeachWorking(ETeachKind.ARENA))
          NewbieManager.CheckTeach(ETeachKind.ARENA);
        else if (NewbieManager.IsTeachWorking(ETeachKind.BLACK_MARKET))
          NewbieManager.CheckTeach(ETeachKind.BLACK_MARKET);
        else if (NewbieManager.IsTeachWorking(ETeachKind.DESHIELD))
          NewbieManager.CheckTeach(ETeachKind.DESHIELD);
      }
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 4)
        AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.BUILD_FARM);
      GameManager.OnRefresh();
      DataManager.MissionDataManager.CheckChanged(eMissionKind.Build, this.AllBuildsData[(int) index1].BuildID, (ushort) this.AllBuildsData[(int) index1].Level);
      if (this.AllBuildsData[(int) index1].BuildID >= (ushort) 1 && this.AllBuildsData[(int) index1].BuildID <= (ushort) 7)
        DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) (20U + (uint) this.AllBuildsData[(int) index1].BuildID), (ushort) this.GetBuildNumByID(this.AllBuildsData[(int) index1].BuildID));
    }
    GUIManager.Instance.HideUILock(EUILock.Build);
  }

  public void RecvBuildFinish(MessagePacket MP)
  {
    if (MP.ReadByte() == (byte) 0)
    {
      this.BuildingManorID = (ushort) 0;
      GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0, eSpentCredits.eBuildFinish);
      ushort index1 = MP.ReadUShort();
      if ((int) index1 >= this.AllBuildsData.Length)
        return;
      this.AllBuildsData[(int) index1].BuildID = MP.ReadUShort();
      this.AllBuildsData[(int) index1].Level = MP.ReadByte();
      DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Build);
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 8)
      {
        if (!NewbieManager.CheckActivity(true) && !NewbieManager.CheckArena(true) && !NewbieManager.CheckBlackmarket() && !NewbieManager.CheckTroopMemory())
          NewbieManager.CheckDeShield();
        for (int index2 = 0; index2 < 5; ++index2)
          DataManager.Instance.Resource[index2].Stock = MP.ReadUInt();
        for (ushort index3 = 0; index3 < (ushort) 4; ++index3)
        {
          ushort ItemID = MP.ReadUShort();
          ushort Quantity = MP.ReadUShort();
          if (ItemID != (ushort) 0)
            DataManager.Instance.SetCurItemQuantity(ItemID, Quantity, (byte) 0, 0L);
        }
        this.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
        GUIManager.Instance.SetFrontMark((byte) 1);
        if (this.AllBuildsData[(int) index1].Level == (byte) 15)
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_Alliance_Mobilization, 6);
      }
      this.ImmEffect = (byte) 1;
      this.ShowBuildHUD(index1, (byte) 1);
      this.UpdateBuildState((byte) 3, index1);
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0U);
      GameManager.OnRefresh(NetworkNews.Refresh_BuildBase);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuitBuilding, 0);
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 13)
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Watchtower_Details, 1);
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 12)
      {
        AssetManager.SetCastleLevel(this.AllBuildsData[(int) index1].Level, (byte) 0);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Trap, 2);
        GameManager.OnRefresh(NetworkNews.Refresh_Soldier);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hospital, 1);
      }
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 6)
        GameManager.OnRefresh(NetworkNews.Refresh_Soldier);
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 7)
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Hospital, 1);
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 8)
      {
        GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_CastleUpgradeReward, (int) this.AllBuildsData[(int) index1].Level, openMode: (byte) 0);
        ActivityManager.Instance.CheckCastleLevel();
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 19);
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 16);
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27);
        LandWalkerManager.SetNewCastleLevel(this.AllBuildsData[(int) index1].Level);
        if (NewbieManager.IsTeachWorking(ETeachKind.ACTIVITY))
          NewbieManager.CheckTeach(ETeachKind.ACTIVITY);
        else if (NewbieManager.IsTeachWorking(ETeachKind.ARENA))
          NewbieManager.CheckTeach(ETeachKind.ARENA);
        else if (NewbieManager.IsTeachWorking(ETeachKind.BLACK_MARKET))
          NewbieManager.CheckTeach(ETeachKind.BLACK_MARKET);
        else if (NewbieManager.IsTeachWorking(ETeachKind.DESHIELD))
          NewbieManager.CheckTeach(ETeachKind.DESHIELD);
        AFAdvanceManager.Instance.CheckCastleLvEvent(GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level);
        FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.CASTLE_LEVEL, 0L, 0UL);
      }
      GameManager.OnRefresh();
      DataManager.MissionDataManager.CheckChanged(eMissionKind.Build, this.AllBuildsData[(int) index1].BuildID, (ushort) this.AllBuildsData[(int) index1].Level);
      if (this.AllBuildsData[(int) index1].BuildID >= (ushort) 1 && this.AllBuildsData[(int) index1].BuildID <= (ushort) 7)
        DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) (20U + (uint) this.AllBuildsData[(int) index1].BuildID), (ushort) this.GetBuildNumByID(this.AllBuildsData[(int) index1].BuildID));
      if (this.AllBuildsData[(int) index1].BuildID == (ushort) 4)
        AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.BUILD_FARM);
    }
    GUIManager.Instance.HideUILock(EUILock.Build);
  }

  public void RecvBuildDismantle(MessagePacket MP)
  {
    ushort Parm = MP.ReadUShort();
    if ((int) Parm >= this.AllBuildsData.Length)
      return;
    this.BuildingManorID = Parm;
    long StartTime = MP.ReadLong();
    uint TotalTime = MP.ReadUInt();
    this.UpdateBuildState((byte) 2, Parm);
    this.QueueBuildType = (byte) 2;
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, true, StartTime, TotalTime);
    GameConstants.GetBytes((ushort) 1, DataManager.msgBuffer, 0);
    GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
    AudioManager.Instance.PlayUISFX(UIKind.Construction);
    GUIManager.Instance.HideUILock(EUILock.Build);
    PetManager.Instance.SetTrainingCenterNum();
  }

  public void RecvBuildDismantleComplete(MessagePacket MP)
  {
    ushort index = MP.ReadUShort();
    if ((int) index >= this.AllBuildsData.Length)
      return;
    this.ShowBuildHUD(index, (byte) 2);
    ushort buildId = this.AllBuildsData[(int) index].BuildID;
    this.AllBuildsData[(int) index].BuildID = (ushort) 0;
    this.AllBuildsData[(int) index].Level = (byte) 0;
    this.NeedSortData = true;
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Build);
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0U);
    if ((int) this.OpenUiManorID == (int) index)
      GameConstants.GetBytes((ushort) 1, DataManager.msgBuffer, 0);
    else
      GameConstants.GetBytes((ushort) 0, DataManager.msgBuffer, 0);
    GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
    this.BuildingManorID = (ushort) 0;
    GUIManager.Instance.HideUILock(EUILock.Build);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_SuitBuilding, 0);
    this.UpdateBuildState((byte) 3, index);
    DataManager.MissionDataManager.CheckChanged(eMissionKind.Build, buildId, (ushort) 0);
    if (buildId < (ushort) 1 || buildId > (ushort) 7)
      return;
    DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) (20U + (uint) buildId), (ushort) this.GetBuildNumByID(buildId));
  }

  public void RecvBuildDismantleCancel(MessagePacket MP)
  {
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0U);
    this.UpdateBuildState((byte) 4, this.BuildingManorID);
    this.BuildingManorID = (ushort) 0;
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0U);
    GameConstants.GetBytes((ushort) 1, DataManager.msgBuffer, 0);
    GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
    GUIManager.Instance.HideUILock(EUILock.Build);
    PetManager.Instance.SetTrainingCenterNum();
  }

  public void RecvBuildDismantleCompleteImmediate(MessagePacket MP)
  {
    if (MP.ReadByte() > (byte) 0)
      return;
    GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0, eSpentCredits.eBuildDismentleImmediate);
    ushort ItemID = MP.ReadUShort();
    ushort num = MP.ReadUShort();
    if (ItemID > (ushort) 0 && num > (ushort) 0)
    {
      ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(ItemID, (byte) 0);
      DataManager.Instance.SetCurItemQuantity(ItemID, (ushort) ((uint) curItemQuantity - (uint) num), (byte) 0, 0L);
    }
    ushort index = MP.ReadUShort();
    if ((int) index >= this.AllBuildsData.Length)
      return;
    ushort buildId = this.AllBuildsData[(int) index].BuildID;
    this.ShowBuildHUD(index, (byte) 2);
    this.AllBuildsData[(int) index].BuildID = (ushort) 0;
    this.AllBuildsData[(int) index].Level = (byte) 0;
    this.NeedSortData = true;
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Build);
    GameConstants.GetBytes((ushort) 1, DataManager.msgBuffer, 0);
    GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
    this.UpdateBuildState((byte) 3, index);
    GameManager.OnRefresh();
    DataManager.MissionDataManager.CheckChanged(eMissionKind.Build, buildId, (ushort) 0);
    if (buildId >= (ushort) 1 && buildId <= (ushort) 7)
      DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) (20U + (uint) buildId), (ushort) this.GetBuildNumByID(buildId));
    AudioManager.Instance.PlayUISFX(UIKind.BuildDestroy);
    GUIManager.Instance.HideUILock(EUILock.Build);
  }

  public void RecvBuildDismantleCompleteFinish(MessagePacket MP)
  {
    if (MP.ReadByte() > (byte) 0)
      return;
    GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0, eSpentCredits.eBuildDismentleFinish);
    ushort index = MP.ReadUShort();
    if ((int) index >= this.AllBuildsData.Length)
      return;
    ushort buildId = this.AllBuildsData[(int) index].BuildID;
    this.ShowBuildHUD(index, (byte) 2);
    DataManager.MissionDataManager.CheckChanged(eMissionKind.Build, this.AllBuildsData[(int) index].BuildID, (ushort) 0);
    if (buildId >= (ushort) 1 && buildId <= (ushort) 7)
      DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) (20U + (uint) buildId), (ushort) this.GetBuildNumByID(buildId));
    this.AllBuildsData[(int) index].BuildID = (ushort) 0;
    this.AllBuildsData[(int) index].Level = (byte) 0;
    this.NeedSortData = true;
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Build);
    if ((int) this.OpenUiManorID == (int) index)
      GameConstants.GetBytes((ushort) 1, DataManager.msgBuffer, 0);
    else
      GameConstants.GetBytes((ushort) 0, DataManager.msgBuffer, 0);
    GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
    this.BuildingManorID = (ushort) 0;
    this.UpdateBuildState((byte) 3, index);
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.Building, false, 0L, 0U);
    GameManager.OnRefresh();
    DataManager.MissionDataManager.CheckChanged(eMissionKind.Build, buildId, (ushort) 0);
    if (buildId >= (ushort) 1 && buildId <= (ushort) 7)
      DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) (20U + (uint) buildId), (ushort) this.GetBuildNumByID(buildId));
    GUIManager.Instance.HideUILock(EUILock.Build);
  }

  private void ShowBuildHUD(ushort ManorID, byte BuildType)
  {
    CString cstring = StringManager.Instance.StaticString1024();
    BuildTypeData recordByKey = DataManager.Instance.BuildsTypeData.GetRecordByKey(this.AllBuildsData[(int) ManorID].BuildID);
    if (BuildType == (byte) 1)
    {
      cstring.IntToFormat((long) this.AllBuildsData[(int) ManorID].Level);
      cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.NameID));
      cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3919U));
    }
    else
    {
      cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.NameID));
      cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3920U));
    }
    GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) 1);
  }

  public void UpdateBuildState(byte State, ushort Parm)
  {
    DataManager.msgBuffer[0] = (byte) 32;
    DataManager.msgBuffer[11] = State;
    GameConstants.GetBytes(Parm, DataManager.msgBuffer, 12);
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }
}
