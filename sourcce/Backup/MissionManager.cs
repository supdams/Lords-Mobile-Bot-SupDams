// Decompiled with JetBrains decompiler
// Type: MissionManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class MissionManager
{
  private const byte DynaMarkMax = 185;
  public const ushort VipRewardTotalTime = 3600;
  public CExternalTableWithWordKey<AffairCardinalTbl> AffairCardinalTable;
  public CExternalTableWithWordKey<AllianceCardinalTbl> AllianceCardinalTable;
  public CExternalTableWithWordKey<AffairNarrativeTbl> AffairNarrativeTable;
  public CExternalTableWithWordKey<AffairNarrativeTbl> AllianceNarrativeTable;
  public CExternalTableWithWordKey<ProbabilityTbl> ProbabilityTable;
  public CExternalTableWithWordKey<ManorAimTbl> ManorAimTable;
  public TimerTypeMission[] TimerMissionData;
  public byte[] AccessMissionCount = new byte[4];
  public byte MissionNotice;
  public byte bFirst = 1;
  private byte CollectDelay;
  public _RecommandTbl RecommandTable;
  public _UIClassificationTbl[] UIManorAimKind;
  private _ManorAimTypeMission[] ManorAimMission;
  public _UIClassificationTbl RewardList;
  public byte[] VipAutoComplete = new byte[2];
  private ushort[] DynaMark = new ushort[185];
  public byte[] BoolMark;
  public ushort HeroNum;
  public GamePlayAchievementManager AchievementMgr;
  private byte VipBoxState;
  private byte VipBoxStateMax;
  public byte UpdateUIBox;
  public byte BoxEffectID;
  public long VipRewardStartTime;
  public uint RewardVipDiamond;
  public ushort[] VipRewardItem = new ushort[10];
  public SpeciallyEffect_Kind[] VipRewardKind = new SpeciallyEffect_Kind[10];
  public readonly byte[] VipLvRestrict = new byte[7]
  {
    (byte) 2,
    (byte) 4,
    (byte) 6,
    (byte) 9,
    (byte) 12,
    (byte) 15,
    (byte) 18
  };
  public ushort AllianceMissionBonusRate = 100;

  public MissionManager()
  {
    this.TimerMissionData = new TimerTypeMission[2];
    for (int index = 0; index < this.TimerMissionData.Length; ++index)
      this.TimerMissionData[index] = new TimerTypeMission();
    this.UIManorAimKind = new _UIClassificationTbl[6];
    for (int index = 0; index < this.UIManorAimKind.Length; ++index)
      this.UIManorAimKind[index] = new _UIClassificationTbl();
    this.RewardList = new _UIClassificationTbl();
    this.ManorAimMission = new _ManorAimTypeMission[10];
    this.ManorAimMission[0] = (_ManorAimTypeMission) new BuildAimMission();
    this.ManorAimMission[1] = (_ManorAimTypeMission) new ArmyAimMission(this.DynaMark);
    this.ManorAimMission[2] = (_ManorAimTypeMission) new TechAimMission();
    this.ManorAimMission[3] = (_ManorAimTypeMission) new NormalAimMission();
    this.ManorAimMission[4] = (_ManorAimTypeMission) new AdvanceAimMission();
    this.ManorAimMission[5] = (_ManorAimTypeMission) new CropsAimMission();
    this.ManorAimMission[6] = (_ManorAimTypeMission) new RecordAimMission();
    this.ManorAimMission[7] = (_ManorAimTypeMission) new MarkAimMission(this.DynaMark);
    this.ManorAimMission[8] = (_ManorAimTypeMission) new ChallengeAimMission();
    this.ManorAimMission[9] = (_ManorAimTypeMission) new ChallengeAdvanceAimMission();
    this.AchievementMgr = DataManager.AchievementMgr;
  }

  public void LoadTable()
  {
    this.AffairCardinalTable = new CExternalTableWithWordKey<AffairCardinalTbl>();
    this.AllianceCardinalTable = new CExternalTableWithWordKey<AllianceCardinalTbl>();
    this.ManorAimTable = new CExternalTableWithWordKey<ManorAimTbl>();
    this.AffairCardinalTable.LoadTable("QuestWaitR");
    this.AllianceCardinalTable.LoadTable("QuestWaitRA");
    this.ManorAimTable.LoadTable("QuestLand");
    this.AffairNarrativeTable = new CExternalTableWithWordKey<AffairNarrativeTbl>();
    this.AllianceNarrativeTable = new CExternalTableWithWordKey<AffairNarrativeTbl>();
    this.ProbabilityTable = new CExternalTableWithWordKey<ProbabilityTbl>();
    this.AffairNarrativeTable.LoadTable("QuestWaitS");
    this.AllianceNarrativeTable.LoadTable("QuestWaitSA");
    this.ProbabilityTable.LoadTable("QuestWait");
    this.Make();
    this.AchievementMgr.Init();
    this.AchievementMgr.LoadTable();
    this.AchievementMgr.Make(this.RecommandTable.Achievement);
  }

  private void Make()
  {
    ushort val1 = 0;
    int tableCount = this.ManorAimTable.TableCount;
    this.RecommandTable.RecommandID = new ushort[(int) ushort.MaxValue];
    this.RecommandTable.Achievement = new byte[(int) ushort.MaxValue];
    this.RecommandTable.MinIndex = ushort.MaxValue;
    this.RecommandTable.SaveIndex = (ushort) 1;
    for (int index = 0; index < this.UIManorAimKind.Length; ++index)
    {
      if (this.UIManorAimKind[index].Priority.Count > 0)
        this.UIManorAimKind[index].Priority.Clear();
    }
    for (int index = 0; index < this.ManorAimMission.Length; ++index)
      this.ManorAimMission[index].ClearAll();
    for (int Index = 0; Index < tableCount; ++Index)
    {
      ManorAimTbl recordByIndex = this.ManorAimTable.GetRecordByIndex(Index);
      if ((int) recordByIndex.UIKind - 1 < this.UIManorAimKind.Length)
      {
        this.RecommandTable.RecommandID[(int) recordByIndex.UIPriority] = recordByIndex.ID;
        this.RecommandTable.CheckMin(recordByIndex.UIPriority);
        int num = this.UIManorAimKind[(int) recordByIndex.UIKind - 1].Priority.BinarySearch(recordByIndex.UIPriority);
        this.UIManorAimKind[(int) recordByIndex.UIKind - 1].Priority.Insert(~num, recordByIndex.UIPriority);
      }
      val1 = Math.Max(val1, recordByIndex.ID);
      if ((int) recordByIndex.MissionKind <= this.ManorAimMission.Length)
      {
        if (recordByIndex.MissionKind <= (byte) 10)
          this.ManorAimMission[(int) recordByIndex.MissionKind - 1].AddData(recordByIndex.UIPriority, recordByIndex.Parm1, (ushort) recordByIndex.Parm2);
      }
      else
        Debug.Log((object) "Data Error");
    }
    if (((int) val1 & 7) > 0)
      this.BoolMark = new byte[((int) val1 >> 3) + 1];
    else
      this.BoolMark = new byte[(int) val1 >> 3];
  }

  public void Reset()
  {
    this.bFirst = (byte) 1;
    this.RewardList.Priority.Clear();
    this.RewardList.SaveIndex = (ushort) 1;
    this.RecommandTable.Reset();
    for (int index = 0; index < this.ManorAimMission.Length; ++index)
      this.ManorAimMission[index].Reset();
  }

  public void SetMissionComplete(ushort ID = 132)
  {
    if ((int) ID >= this.DynaMark.Length || this.DynaMark[(int) ID] != (ushort) 0)
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Add(ID);
    messagePacket.Protocol = Protocol._MSG_REQUEST_MISSION_SET;
    messagePacket.Send();
  }

  public void SetCompleteWhileLogin(eMissionKind Kind)
  {
    this.ManorAimMission[(int) (byte) Kind].SetCompleteWhileLogin();
    if (Kind == eMissionKind.Army)
      AFAdvanceManager.Instance.CheckTrainTroop();
    if (Kind == eMissionKind.Mark)
      AFAdvanceManager.Instance.CheckCompleteQuest();
    if (Kind == eMissionKind.Mark)
      AFAdvanceManager.Instance.CheckGatherTimber();
    if (Kind != eMissionKind.Mark)
      return;
    AFAdvanceManager.Instance.CheckHitMonster();
  }

  public bool CheckChanged(eMissionKind Kind, ushort Key, ushort Val)
  {
    if (Kind == eMissionKind.Record && Key == (ushort) 20)
    {
      this.HeroNum = Val;
      AFAdvanceManager.Instance.CheckHeroCount((ulong) this.HeroNum);
    }
    bool flag = this.ManorAimMission[(int) (byte) Kind].CheckValueChanged(Key, Val);
    if (Kind == eMissionKind.Army && Key >= (ushort) 1 && Key <= (ushort) 16)
      AFAdvanceManager.Instance.CheckTrainTroop();
    if (Kind == eMissionKind.Mark && Key == (ushort) 101)
      AFAdvanceManager.Instance.CheckCompleteQuest();
    if (Kind == eMissionKind.Mark && Key == (ushort) 126)
      AFAdvanceManager.Instance.CheckGatherTimber();
    if (Kind == eMissionKind.Mark && (Key == (ushort) 145 || Key == (ushort) 146))
      AFAdvanceManager.Instance.CheckHitMonster();
    return flag;
  }

  public ushort GetReCommandMissionID()
  {
    while ((int) this.RecommandTable.SaveIndex <= this.RecommandTable.RecommandID.Length && (int) this.RecommandTable.SaveIndex != this.RecommandTable.RecommandID.Length && (this.RecommandTable.RecommandID[(int) this.RecommandTable.SaveIndex] <= (ushort) 0 || this.CheckBoolMark(this.RecommandTable.RecommandID[(int) this.RecommandTable.SaveIndex]) || this.CheckManorAim(this.RecommandTable.RecommandID[(int) this.RecommandTable.SaveIndex])))
      ++this.RecommandTable.SaveIndex;
    ushort num1 = 0;
    int num2 = 0;
    DataManager instance = DataManager.Instance;
    BuildsData buildingData = GUIManager.Instance.BuildingData;
    while ((int) this.RecommandTable.SaveIndex + (int) num1 < this.RecommandTable.RecommandID.Length)
    {
      ushort InKey = this.RecommandTable.RecommandID[(int) this.RecommandTable.SaveIndex + (int) num1];
      if (InKey == (ushort) 0)
      {
        ++num1;
      }
      else
      {
        ManorAimTbl recordByKey = this.ManorAimTable.GetRecordByKey(InKey);
        if (this.CheckBoolMark(recordByKey.ID) || this.CheckManorAim(recordByKey.ID))
        {
          ++num1;
        }
        else
        {
          switch (recordByKey.MissionKind)
          {
            case 1:
              if ((int) buildingData.AllBuildsData[(int) buildingData.BuildingManorID].BuildID == (int) recordByKey.Parm1 && (long) ((int) buildingData.AllBuildsData[(int) buildingData.BuildingManorID].Level + 1) == (long) recordByKey.Parm2 && buildingData.QueueBuildType == (byte) 1 && (num2 & 1) == 0)
              {
                num2 |= 1;
                ++num1;
                continue;
              }
              goto label_22;
            case 2:
              if (recordByKey.Parm1 <= (ushort) 16)
              {
                if (instance.queueBarData[10].bActive && 4 * (int) instance.SoldierKind + (int) instance.SoldierRank + 1 == (int) recordByKey.Parm1 && (num2 & 4) == 0)
                {
                  num2 |= 4;
                  ++num1;
                  continue;
                }
                goto label_22;
              }
              else
              {
                if (instance.queueBarData[14].bActive && 4 * (int) instance.TrapKind + (int) instance.TrapRank + 17 == (int) recordByKey.Parm1 && (num2 & 8) == 0)
                {
                  num2 |= 8;
                  ++num1;
                  continue;
                }
                goto label_22;
              }
            case 3:
              if ((int) instance.ResearchTech == (int) recordByKey.Parm1 && (num2 & 2) == 0)
              {
                num2 |= 2;
                ++num1;
                continue;
              }
              goto label_22;
            case 7:
              switch ((eRecordKind) recordByKey.Parm1)
              {
                case eRecordKind.CollectionWood:
                case eRecordKind.CollectionRock:
                case eRecordKind.CollectionSteel:
                case eRecordKind.CollectionGrain:
                case eRecordKind.CollectionMoney:
                case eRecordKind.CollectBarrack:
                case eRecordKind.CollectTreament:
                  if ((num2 & 16) == 0 && (int) buildingData.AllBuildsData[(int) buildingData.BuildingManorID].BuildID == (int) recordByKey.Parm1 - 21 + 1 && buildingData.QueueBuildType == (byte) 1)
                  {
                    num2 |= 16;
                    ++num1;
                    continue;
                  }
                  goto label_22;
                default:
                  goto label_22;
              }
            default:
              goto label_22;
          }
        }
      }
    }
label_22:
    return (int) this.RecommandTable.SaveIndex + (int) num1 == this.RecommandTable.RecommandID.Length ? ushort.MaxValue : this.RecommandTable.RecommandID[(int) this.RecommandTable.SaveIndex + (int) num1];
  }

  public _eMarkAimNarrativeType GetMarkNarrativeType(ushort MarkID)
  {
    switch (MarkID)
    {
      case 101:
      case 102:
        return _eMarkAimNarrativeType.Accumlate;
      default:
        return _eMarkAimNarrativeType.Once;
    }
  }

  public void GetNarrative(CString NarrativeStr, ref ManorAimTbl ManorData)
  {
    DataManager instance = DataManager.Instance;
    NarrativeStr.ClearString();
    switch (ManorData.MissionKind)
    {
      case 1:
        ushort nameId = instance.BuildsTypeData.GetRecordByKey(ManorData.Parm1).NameID;
        NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint) nameId));
        NarrativeStr.IntToFormat((long) ManorData.Parm2);
        NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.Narrative));
        break;
      case 2:
        ushort name = instance.SoldierDataTable.GetRecordByKey(ManorData.Parm1).Name;
        NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint) name));
        NarrativeStr.IntToFormat((long) ManorData.Parm2);
        NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.Narrative));
        break;
      case 3:
        TechDataTbl recordByKey1 = instance.TechData.GetRecordByKey(ManorData.Parm1);
        NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey1.TechName));
        if (ManorData.Narrative == (ushort) 8053)
          NarrativeStr.IntToFormat((long) ManorData.Parm2);
        NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.Narrative));
        break;
      case 4:
      case 5:
      case 9:
      case 10:
        CString tmpS = StringManager.Instance.StaticString1024();
        int x = ((int) ManorData.Parm1 - 1) / 6 + 1;
        tmpS.IntToFormat((long) x);
        int num;
        tmpS.IntToFormat((long) ((int) ManorData.Parm1 * 3 - (num = x - 1) * 18));
        tmpS.AppendFormat("{0}-{1}");
        NarrativeStr.StringToFormat(tmpS);
        NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.Narrative));
        break;
      case 6:
        ushort stageName = DataManager.StageDataController.CorpsStageTable.GetRecordByKey(ManorData.Parm1).StageName;
        NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint) stageName));
        NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.Narrative));
        break;
      case 7:
        switch ((eRecordKind) ManorData.Parm1)
        {
          case eRecordKind.Grain:
          case eRecordKind.Rock:
          case eRecordKind.Wood:
          case eRecordKind.Steel:
          case eRecordKind.Money:
            NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint) ManorData.Parm1 + 3951U));
            NarrativeStr.IntToFormat((long) ManorData.Parm2, bNumber: true);
            break;
          case eRecordKind.CollectionWood:
          case eRecordKind.CollectionRock:
          case eRecordKind.CollectionSteel:
          case eRecordKind.CollectionGrain:
          case eRecordKind.CollectionMoney:
          case eRecordKind.CollectBarrack:
          case eRecordKind.CollectTreament:
            NarrativeStr.IntToFormat((long) ManorData.Parm2, bNumber: true);
            BuildTypeData recordByKey2 = instance.BuildsTypeData.GetRecordByKey((ushort) ((uint) ManorData.Parm1 - 20U));
            NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey2.NameID));
            break;
          default:
            NarrativeStr.IntToFormat((long) ManorData.Parm2, bNumber: true);
            break;
        }
        NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.Narrative));
        break;
      case 8:
        if (ManorData.Parm1 == (ushort) 103 || ManorData.Parm1 == (ushort) 104 || ManorData.Parm1 >= (ushort) 108 && ManorData.Parm1 <= (ushort) 110 || ManorData.Parm1 == (ushort) 113 || ManorData.Parm1 == (ushort) 115 || ManorData.Parm1 == (ushort) 129 || ManorData.Parm1 == (ushort) 130 || ManorData.Parm1 == (ushort) 116 || ManorData.Parm1 >= (ushort) 134 && ManorData.Parm1 <= (ushort) 154)
        {
          NarrativeStr.IntToFormat((long) ManorData.Parm2);
          NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.Narrative));
          break;
        }
        if (ManorData.Parm1 >= (ushort) 124 && ManorData.Parm1 <= (ushort) 128)
        {
          NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint) (3951 + (int) ManorData.Parm1 - 123)));
          NarrativeStr.IntToFormat((long) ManorData.Parm2);
          NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.Narrative));
          break;
        }
        if (ManorData.Parm1 >= (ushort) 160 && ManorData.Parm1 <= (ushort) 184)
        {
          NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint) instance.NPCPrize.GetRecordByKey((ushort) ((uint) ManorData.Parm1 - 159U)).Element));
          NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.Narrative));
          break;
        }
        if (ManorData.Parm1 == (ushort) 118 || ManorData.Parm1 == (ushort) 155 || this.GetMarkNarrativeType(ManorData.Parm1) == _eMarkAimNarrativeType.Accumlate)
        {
          NarrativeStr.IntToFormat((long) ManorData.Parm2);
          NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.Narrative));
          break;
        }
        NarrativeStr.Append(instance.mStringTable.GetStringByID((uint) ManorData.Narrative));
        break;
    }
  }

  public void GetManorAimGuide(ushort ID)
  {
    ManorAimTbl recordByKey = this.ManorAimTable.GetRecordByKey(ID);
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    StageManager stageDataController = DataManager.StageDataController;
    switch (recordByKey.MissionKind)
    {
      case 1:
        instance2.BuildingData.ManorGuild(recordByKey.Parm1, true);
        break;
      case 2:
        if (recordByKey.Parm1 < (ushort) 17)
          instance2.BuildingData.ManorGuild((ushort) 6);
        else
          instance2.BuildingData.ManorGuild((ushort) 12);
        instance2.BuildingData.GuideSoldierID = recordByKey.Parm1;
        instance2.BuildingData.GuideSoldierNum = recordByKey.Parm2;
        break;
      case 3:
        instance2.GuideParm1 = (byte) 3;
        instance2.GuideParm2 = recordByKey.Parm1;
        instance2.OpenTechTree(instance2.GuideParm2);
        break;
      case 4:
        byte currentChapterId1 = stageDataController.currentChapterID;
        StageMode stageMode1 = stageDataController._stageMode;
        stageDataController.currentChapterID = (byte) (((uint) recordByKey.Parm1 - 1U) / (uint) GameConstants.StagePointNum[1]);
        stageDataController._stageMode = StageMode.Full;
        if ((int) stageDataController.currentChapterID >= (int) stageDataController.StageRecord[2])
        {
          instance2.AddHUDMessage(instance1.mStringTable.GetStringByID(668U), (ushort) byte.MaxValue);
          stageDataController.currentChapterID = currentChapterId1;
          stageDataController._stageMode = stageMode1;
          break;
        }
        if ((int) stageDataController.currentChapterID > (int) stageDataController.StageRecord[0] / (int) GameConstants.StagePointNum[0])
          stageDataController.currentChapterID = (byte) ((uint) stageDataController.StageRecord[0] / (uint) GameConstants.StagePointNum[0]);
        ++stageDataController.currentChapterID;
        stageDataController.currentPointID = (ushort) (((int) stageDataController.currentChapterID - 1) * (int) GameConstants.StagePointNum[(int) stageDataController._stageMode] + 1);
        stageDataController.SaveUserStage(stageDataController._stageMode);
        stageDataController.SaveUserStageMode(stageDataController._stageMode);
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.DoorOpenUp);
        break;
      case 5:
        byte currentChapterId2 = stageDataController.currentChapterID;
        StageMode stageMode2 = stageDataController._stageMode;
        stageDataController.currentChapterID = (byte) (((uint) recordByKey.Parm1 - 1U) / (uint) GameConstants.StagePointNum[1]);
        stageDataController._stageMode = StageMode.Lean;
        if ((int) stageDataController.currentChapterID >= (int) stageDataController.StageRecord[2])
        {
          instance2.AddHUDMessage(instance1.mStringTable.GetStringByID(668U), (ushort) byte.MaxValue);
          stageDataController.currentChapterID = currentChapterId2;
          stageDataController._stageMode = stageMode2;
          break;
        }
        if ((int) stageDataController.StageRecord[0] / (int) GameConstants.StagePointNum[0] <= (int) stageDataController.currentChapterID)
        {
          instance2.AddHUDMessage(instance1.mStringTable.GetStringByID(1593U), (ushort) byte.MaxValue);
          stageDataController.currentChapterID = currentChapterId2;
          stageDataController._stageMode = stageMode2;
          break;
        }
        if ((int) stageDataController.currentChapterID > (int) stageDataController.StageRecord[1] / (int) GameConstants.StagePointNum[1])
          stageDataController.currentChapterID = (byte) ((uint) stageDataController.StageRecord[1] / (uint) GameConstants.StagePointNum[1]);
        ++stageDataController.currentChapterID;
        stageDataController.currentPointID = (ushort) (((int) stageDataController.currentChapterID - 1) * (int) GameConstants.StagePointNum[(int) stageDataController._stageMode] + 1);
        stageDataController.SaveUserStage(stageDataController._stageMode);
        stageDataController.SaveUserStageMode(stageDataController._stageMode);
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.DoorOpenUp);
        break;
      case 6:
        Door menu1 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((UnityEngine.Object) menu1 != (UnityEngine.Object) null))
          break;
        menu1.OnButtonClick(menu1.m_BattleButton);
        break;
      case 7:
        if (recordByKey.Parm1 == (ushort) 7)
        {
          Door menu2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
          DataManager.Instance.SetSelectRequest = 0;
          menu2.OpenMenu(EGUIWindow.UI_AllianceHint);
          break;
        }
        if (recordByKey.Parm1 == (ushort) 19)
        {
          instance2.BuildingData.ManorGuild((ushort) 12);
          instance2.BuildingData.GuideSoldierID = (ushort) 30;
          break;
        }
        if (recordByKey.Parm1 < (ushort) 21 || recordByKey.Parm1 > (ushort) 27)
          break;
        GUIManager.Instance.BuildingData.EmptyManorGuide((ushort) ((uint) recordByKey.Parm1 - 20U), true);
        break;
      case 8:
        if (recordByKey.Parm1 == (ushort) 131)
        {
          if (NewbieManager.CheckRename(false))
            break;
          DataManager.Instance.CheckUseItem((ushort) 1006, (ushort) 0, (ushort) 0, (ushort) 0);
          break;
        }
        if (recordByKey.Parm1 != (ushort) 132)
          break;
        Door menu3 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        instance2.GuideArrow((RectTransform) ((Component) menu3.m_MapSwitchButton).transform, ArrowDirect.Ar_Up, 10f);
        break;
      case 9:
      case 10:
        byte currentChapterId3 = stageDataController.currentChapterID;
        StageMode stageMode3 = stageDataController._stageMode;
        stageDataController.currentChapterID = (byte) (((uint) recordByKey.Parm1 - 1U) / (uint) GameConstants.StagePointNum[1]);
        stageDataController._stageMode = StageMode.Dare;
        if ((int) stageDataController.currentChapterID > (int) stageDataController.StageRecord[3] / (int) GameConstants.StagePointNum[3])
          stageDataController.currentChapterID = (byte) ((uint) stageDataController.StageRecord[3] / (uint) GameConstants.StagePointNum[3]);
        ++stageDataController.currentChapterID;
        stageDataController.currentPointID = (ushort) (((int) stageDataController.currentChapterID - 1) * (int) GameConstants.StagePointNum[(int) stageDataController._stageMode] + 1);
        stageDataController.SaveUserStage(stageDataController._stageMode);
        stageDataController.SaveUserStageMode(stageDataController._stageMode);
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.DoorOpenUp);
        break;
    }
  }

  public void UpdateReCommandSaveIndex(ushort index)
  {
    if ((int) this.RecommandTable.SaveIndex <= (int) index || this.CheckBoolMark(this.RecommandTable.RecommandID[(int) index]))
      return;
    this.RecommandTable.SaveIndex = index;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
  }

  public ushort GetUIMissionItemKind(eUIMissionKind Kind, ref int beginID)
  {
    List<ushort> priority = this.UIManorAimKind[(int) (byte) Kind].Priority;
    ushort commandMissionId = this.GetReCommandMissionID();
    for (int index = beginID; index < priority.Count; ++index)
    {
      ushort missionId = this.GetMissionID(priority[index]);
      if ((int) commandMissionId != (int) missionId && !this.CheckBoolMark(missionId) && !this.CheckManorAim(missionId))
      {
        beginID = index + 1;
        return missionId;
      }
    }
    return ushort.MaxValue;
  }

  public ushort GetMissionID(ushort priority) => this.RecommandTable.RecommandID[(int) priority];

  public bool CheckBoolMark(ushort ID)
  {
    return ID != (ushort) 0 && ((int) this.BoolMark[(int) --ID >> 3] & 1 << ((int) ID & 7)) > 0;
  }

  private void SetBoolMark(ushort ID)
  {
    if (ID == (ushort) 0)
      return;
    this.BoolMark[(int) --ID >> 3] |= (byte) (1 << ((int) ID & 7));
  }

  private bool CheckManorAim(ushort ID)
  {
    DataManager instance = DataManager.Instance;
    ManorAimTbl recordByKey = this.ManorAimTable.GetRecordByKey(ID);
    switch (recordByKey.MissionKind)
    {
      case 1:
        RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData(recordByKey.Parm1, (ushort) 0);
        return buildData.BuildID != (ushort) 0 && (uint) buildData.Level >= recordByKey.Parm2;
      case 2:
        if ((uint) this.DynaMark[(int) recordByKey.Parm1] >= recordByKey.Parm2)
          return true;
        break;
      case 3:
        if ((uint) instance.GetTechLevel(recordByKey.Parm1) >= recordByKey.Parm2)
          return true;
        break;
      case 4:
        if ((int) DataManager.StageDataController.StageRecord[0] >= (int) recordByKey.Parm1 * 3)
          return true;
        break;
      case 5:
        if ((int) DataManager.StageDataController.StageRecord[1] >= (int) recordByKey.Parm1)
          return true;
        break;
      case 6:
        if ((int) DataManager.StageDataController.StageRecord[2] >= (int) recordByKey.Parm1)
          return true;
        break;
      case 7:
        eRecordKind parm1 = (eRecordKind) recordByKey.Parm1;
        if (parm1 >= eRecordKind.Grain && parm1 <= eRecordKind.Money)
        {
          if (this.UpdateResourceInfo((ResourceType) ((uint) recordByKey.Parm1 - 1U)) >= (long) recordByKey.Parm2)
            return true;
          break;
        }
        switch (parm1)
        {
          case eRecordKind.Level:
            if ((uint) instance.RoleAttr.Level >= recordByKey.Parm2)
              return true;
            break;
          case eRecordKind.Alliance:
            if (instance.RoleAlliance.Id > 0U)
              return true;
            break;
          default:
            if (parm1 >= eRecordKind.Enhance2 && parm1 <= eRecordKind.Enhance12)
            {
              if ((uint) (this.ManorAimMission[6] as RecordAimMission).HeroEnhanceNum[(int) (parm1 - 8)] >= recordByKey.Parm2)
                return true;
              break;
            }
            switch (parm1)
            {
              case eRecordKind.DefenderHero:
                if ((uint) (this.ManorAimMission[6] as RecordAimMission).DefenderNum >= recordByKey.Parm2)
                  return true;
                break;
              case eRecordKind.HeroNum:
                if (instance.CurHeroDataCount >= recordByKey.Parm2)
                  return true;
                break;
              default:
                if (parm1 >= eRecordKind.CollectionWood && parm1 <= eRecordKind.CollectTreament)
                {
                  if ((uint) GUIManager.Instance.BuildingData.GetBuildNumByID((ushort) (parm1 - 21 + 1)) >= recordByKey.Parm2)
                    return true;
                  break;
                }
                if (parm1 == eRecordKind.ArneaStartHero)
                {
                  if ((uint) ArenaManager.Instance.GetHeroAstrologyNum() >= recordByKey.Parm2)
                    return true;
                  break;
                }
                if (parm1 == eRecordKind.ArneaHiRank && ArenaManager.Instance.m_ArenaHistoryPlace <= recordByKey.Parm2)
                  return true;
                break;
            }
            break;
        }
        break;
      case 8:
        if (this.DynaMark.Length > (int) recordByKey.Parm1 && (uint) this.DynaMark[(int) recordByKey.Parm1] >= recordByKey.Parm2)
          return true;
        break;
      case 9:
        if ((int) DataManager.StageDataController.StageRecord[3] >= (int) recordByKey.Parm1 * 3)
          return true;
        break;
      case 10:
        if ((int) DataManager.StageDataController.StageRecord[3] >= (int) recordByKey.Parm1 * 3 && (long) DataManager.StageDataController.GetStagePoint((ushort) ((uint) recordByKey.Parm1 * 3U), (byte) 3) >= (long) recordByKey.Parm2)
          return true;
        break;
    }
    return false;
  }

  public void AddRewardMission(ushort Priority)
  {
    ushort missionId = this.GetMissionID(Priority);
    if (this.CheckBoolMark(missionId) || !this.CheckManorAim(missionId))
      return;
    int num = this.RewardList.Priority.BinarySearch(Priority);
    if (num >= 0)
      return;
    if (this.RewardList.Priority.Count == 0)
      this.RewardList.Priority.Add(Priority);
    else
      this.RewardList.Priority.Insert(~num, Priority);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
  }

  public byte GetRewardCount(int MaxCount)
  {
    byte index1 = 0;
    for (int index2 = 0; index2 < this.RewardList.Priority.Count && (int) index1 != MaxCount; ++index2)
    {
      ushort missionId = this.GetMissionID(this.RewardList.Priority[(int) index1]);
      if (this.CheckBoolMark(missionId) || !this.CheckManorAim(missionId))
      {
        this.RewardList.Priority.Remove(this.RewardList.Priority[(int) index1]);
        --index2;
      }
      else
        ++index1;
    }
    return index1;
  }

  public TimerTypeMission GetTimerMissionData(_eMissionType Type)
  {
    return Type == _eMissionType.Affair ? this.TimerMissionData[0] : this.TimerMissionData[1];
  }

  public CString FormatMissionTime(uint time)
  {
    CString cstring = StringManager.Instance.StaticString1024();
    TimeSpan timeSpan = new TimeSpan((long) time * 10000000L);
    if (timeSpan.Hours > 0)
    {
      cstring.IntToFormat((long) timeSpan.Hours, 2);
      cstring.IntToFormat((long) timeSpan.Minutes, 2);
      cstring.IntToFormat((long) timeSpan.Seconds, 2);
      cstring.AppendFormat("{0}:{1}:{2}");
    }
    else
    {
      cstring.IntToFormat((long) timeSpan.Minutes, 2);
      cstring.IntToFormat((long) timeSpan.Seconds, 2);
      cstring.AppendFormat("{0}:{1}");
    }
    return cstring;
  }

  public byte GetTotalAccessMissionCount()
  {
    byte accessMissionCount = 0;
    for (int index = 0; index < this.AccessMissionCount.Length; ++index)
    {
      if (index != 2 || DataManager.Instance.RoleAlliance.Id != 0U)
        accessMissionCount += this.AccessMissionCount[index];
    }
    return accessMissionCount;
  }

  public long UpdateResourceInfo(ResourceType Type)
  {
    AttribValManager attribVal = DataManager.Instance.AttribVal;
    long num1 = 0;
    uint num2 = 0;
    uint num3 = 0;
    switch (Type)
    {
      case ResourceType.Grain:
        num1 = (long) (attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_FOOD_PRODUCTION) + 1000U);
        num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_FOOD_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
        num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_FOOD_PRODUCTION_PERCENT_DEBUFF);
        break;
      case ResourceType.Rock:
        num1 = (long) (attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ROCK_PRODUCTION) + 1000U);
        num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ROCK_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
        num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_ROCK_PRODUCTION_PERCENT_DEBUFF);
        break;
      case ResourceType.Wood:
        num1 = (long) (attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_WOOD_PRODUCTION) + 1000U);
        num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_WOOD_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
        num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_WOOD_PRODUCTION_PERCENT_DEBUFF);
        break;
      case ResourceType.Steel:
        num1 = (long) (attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_STEEL_PRODUCTION) + 1000U);
        num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_STEEL_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
        num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_STEEL_PRODUCTION_PERCENT_DEBUFF);
        break;
      case ResourceType.Money:
        num1 = (long) attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MONEY_PRODUCTION);
        num2 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MONEY_PRODUCTION_PERCENT) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION);
        num3 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_DEBUFF) + attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_MONEY_PRODUCTION_PERCENT_DEBUFF);
        break;
    }
    long num4;
    if (num3 > num2)
    {
      uint num5 = num3 - num2;
      if (num5 > 9900U)
        num5 = 9900U;
      num4 = 10000L * num1 - num1 * (long) num5;
    }
    else
    {
      uint num6 = num2 - num3;
      num4 = 10000L * num1 + num1 * (long) num6;
    }
    uint num7 = attribVal.GetEffectBaseVal(GATTR_ENUM.EGA_RESOURCE_PRODUCTION_CURSE);
    if (num7 > 9900U)
      num7 = 9900U;
    return (10000L * num4 - num4 * (long) num7) / 100000000L;
  }

  public void UpdateVipState()
  {
    DataManager instance = DataManager.Instance;
    VIP_DataTbl recordByKey = instance.VIPLevelTable.GetRecordByKey((ushort) instance.RoleAttr.VIPLevel);
    this.VipAutoComplete[0] = recordByKey.AutoDailyMission;
    this.VipAutoComplete[1] = recordByKey.AutoDailyAlliMission;
    if (this.VipAutoComplete[0] == (byte) 1)
    {
      TimerTypeMission timerMissionData = this.GetTimerMissionData(_eMissionType.Affair);
      for (int index = 0; index < (int) timerMissionData.MissionCount; ++index)
      {
        if (timerMissionData.TimeMission[index].State == _eTimerMissionState.Countdown)
          ++this.AccessMissionCount[1];
        if (timerMissionData.TimeMission[index].State == _eTimerMissionState.Wait || timerMissionData.TimeMission[index].State == _eTimerMissionState.Countdown)
          timerMissionData.TimeMission[index].State = _eTimerMissionState.AutoComplete;
      }
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.AffairMission, false, 0L, 0U);
    }
    if (this.VipAutoComplete[1] == (byte) 1)
    {
      TimerTypeMission timerMissionData = this.GetTimerMissionData(_eMissionType.Alliance);
      for (int index = 0; index < (int) timerMissionData.MissionCount; ++index)
      {
        if (timerMissionData.TimeMission[index].State == _eTimerMissionState.Countdown)
          ++this.AccessMissionCount[2];
        if (timerMissionData.TimeMission[index].State == _eTimerMissionState.Wait || timerMissionData.TimeMission[index].State == _eTimerMissionState.Countdown)
          timerMissionData.TimeMission[index].State = _eTimerMissionState.AutoComplete;
      }
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.AllianceMission, false, 0L, 0U);
    }
    this.VipBoxStateMax = (byte) 0;
    for (int index = 0; index < this.VipLvRestrict.Length && (int) this.VipLvRestrict[index] <= (int) instance.RoleAttr.VIPLevel; ++index)
      this.VipBoxStateMax |= (byte) (1 << index);
    this.UpdateVipTime();
    this.UpdateVipCount();
  }

  public void Update(float delta)
  {
    int num1 = 0;
    int num2 = 0;
    long serverTime = DataManager.Instance.ServerTime;
    for (int index = 0; index < this.TimerMissionData.Length; ++index)
    {
      if (!NewbieManager.IsNewbie && this.TimerMissionData[index].ResetTime > 0L && this.TimerMissionData[index].ResetTime < serverTime)
      {
        this.TimerMissionData[index].ResetTime = -1L;
        if (index == 0 || index == 1)
        {
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.AddSeqId();
          messagePacket.Add((byte) (index + 1));
          messagePacket.Protocol = Protocol._MSG_REQUEST_MISSIONINFO;
          messagePacket.Send();
        }
      }
      if (this.TimerMissionData[index].MissionTime > 0L && this.TimerMissionData[index].MissionTime <= serverTime && this.TimerMissionData[index].TimeMission.Length > (int) this.TimerMissionData[index].ProcessIdx)
      {
        this.TimerMissionData[index].MissionTime = -1L;
        this.TimerMissionData[index].TimeMission[(int) this.TimerMissionData[index].ProcessIdx].State = _eTimerMissionState.Reward;
        num1 |= 1;
        this.MissionNotice |= (byte) (1 << index + 1);
        num2 = index + 1;
        DataManager instance = DataManager.Instance;
        if (index == 0)
        {
          GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(7942U), (ushort) 25);
          instance.SetQueueBarData(EQueueBarIndex.AffairMission, false, 0L, 0U);
        }
        else
        {
          GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(7943U), (ushort) 25);
          instance.SetQueueBarData(EQueueBarIndex.AllianceMission, false, 0L, 0U);
        }
        GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
      }
    }
    if (num2 > 0)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, num1, num2);
    if ((int) this.VipBoxState != (int) this.VipBoxStateMax && serverTime - this.VipRewardStartTime >= 3600L && ((int) this.MissionNotice >> 3 & 1) == 0)
    {
      this.MissionNotice |= (byte) 8;
      this.UpdateVipTime();
      if (this.bFirst == (byte) 0)
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7944U), (ushort) 11);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, 4, 3);
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
    }
    if (this.bFirst == byte.MaxValue)
      this.bFirst = (byte) 0;
    this.AchievementMgr.Update(delta);
  }

  public void UpdateTimeMissionTime(byte QueuebarIndex)
  {
    DataManager instance = DataManager.Instance;
    byte index = (byte) ((uint) QueuebarIndex - 19U);
    this.TimerMissionData[(int) index].MissionTime = instance.queueBarData[(int) QueuebarIndex].StartTime + (long) instance.queueBarData[(int) QueuebarIndex].TotalTime;
    if (this.TimerMissionData[(int) index].MissionTime > instance.ServerTime)
      return;
    this.Update(0.0f);
  }

  public void RecvTimeMissionInfo(MessagePacket MP)
  {
    byte num = MP.ReadByte();
    byte index1 = 0;
    if (num == (byte) 1)
    {
      if (this.TimerMissionData[(int) index1].ResetTime < 0L)
        this.TimerMissionData[(int) index1].ResetTime = DataManager.Instance.ServerTime + 2L;
      else
        this.TimerMissionData[1].ResetTime = DataManager.Instance.ServerTime + 2L;
    }
    else
    {
      byte index2 = (byte) ((uint) MP.ReadByte() - 1U);
      if ((int) index2 >= this.TimerMissionData.Length)
        return;
      byte index3 = (byte) ((uint) index2 + 1U);
      this.TimerMissionData[(int) index2].ResetTime = MP.ReadLong();
      this.TimerMissionData[(int) index2].MissionTime = MP.ReadLong();
      this.TimerMissionData[(int) index2].MissionCount = MP.ReadByte();
      this.TimerMissionData[(int) index2].ProcessIdx = byte.MaxValue;
      this.AccessMissionCount[(int) index3] = (byte) 0;
      this.MissionNotice &= (byte) ~(1 << (int) index3);
      for (byte index4 = 0; (int) index4 < (int) this.TimerMissionData[(int) index2].MissionCount; ++index4)
      {
        this.TimerMissionData[(int) index2].TimeMission[(int) index4].Index = index4;
        this.TimerMissionData[(int) index2].TimeMission[(int) index4].ID = MP.ReadUShort();
        this.TimerMissionData[(int) index2].TimeMission[(int) index4].Quality = MP.ReadUShort();
        this.TimerMissionData[(int) index2].TimeMission[(int) index4].Base = MP.ReadUShort();
        this.TimerMissionData[(int) index2].TimeMission[(int) index4].ItemID = MP.ReadUShort();
        this.TimerMissionData[(int) index2].TimeMission[(int) index4].State = (_eTimerMissionState) MP.ReadByte();
        if (this.VipAutoComplete[(int) index2] == (byte) 1 && (this.TimerMissionData[(int) index2].TimeMission[(int) index4].State == _eTimerMissionState.Wait || this.TimerMissionData[(int) index2].TimeMission[(int) index4].State == _eTimerMissionState.Countdown))
        {
          ++this.AccessMissionCount[(int) index3];
          this.TimerMissionData[(int) index2].TimeMission[(int) index4].State = _eTimerMissionState.AutoComplete;
        }
        else if (this.TimerMissionData[(int) index2].TimeMission[(int) index4].State == _eTimerMissionState.Wait)
          ++this.AccessMissionCount[(int) index3];
        else if (this.TimerMissionData[(int) index2].TimeMission[(int) index4].State == _eTimerMissionState.Reward)
        {
          this.TimerMissionData[(int) index2].MissionTime = -1L;
          this.MissionNotice |= (byte) (1U << (int) index3);
          if (index2 == (byte) 0)
            DataManager.Instance.SetQueueBarData(EQueueBarIndex.AffairMission, false, 0L, 0U);
          else
            DataManager.Instance.SetQueueBarData(EQueueBarIndex.AllianceMission, false, 0L, 0U);
        }
        else if (this.TimerMissionData[(int) index2].TimeMission[(int) index4].State == _eTimerMissionState.Countdown)
        {
          this.TimerMissionData[(int) index2].ProcessIdx = index4;
          if (index2 == (byte) 0)
          {
            AffairNarrativeTbl recordByIndex = this.AffairNarrativeTable.GetRecordByIndex((int) this.TimerMissionData[(int) index2].TimeMission[(int) index4].ID);
            DataManager.Instance.SetQueueBarData(EQueueBarIndex.AffairMission, true, this.TimerMissionData[(int) index2].MissionTime - (long) recordByIndex.TotalTime, (uint) recordByIndex.TotalTime);
            DataManager.Instance.SetRecvQueueBarData(19);
          }
          else
          {
            AffairNarrativeTbl recordByIndex = this.AllianceNarrativeTable.GetRecordByIndex((int) this.TimerMissionData[(int) index2].TimeMission[(int) index4].ID);
            DataManager.Instance.SetQueueBarData(EQueueBarIndex.AllianceMission, true, this.TimerMissionData[(int) index2].MissionTime - (long) recordByIndex.TotalTime, (uint) recordByIndex.TotalTime);
            DataManager.Instance.SetRecvQueueBarData(20);
          }
        }
      }
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, 4);
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
      GUIManager.Instance.HideUILock(EUILock.Mission);
    }
  }

  public void RecvTimeMissionStart(MessagePacket MP)
  {
    byte index1 = (byte) ((uint) MP.ReadByte() - 1U);
    byte num1 = MP.ReadByte();
    if (num1 == (byte) 0 || (int) index1 >= this.TimerMissionData.Length)
      return;
    byte index2 = (byte) ((uint) index1 + 1U);
    --this.AccessMissionCount[(int) index2];
    byte num2;
    this.TimerMissionData[(int) index1].ProcessIdx = num2 = (byte) ((uint) num1 - 1U);
    this.TimerMissionData[(int) index1].MissionTime = MP.ReadLong();
    this.TimerMissionData[(int) index1].TimeMission[(int) this.TimerMissionData[(int) index1].ProcessIdx].State = _eTimerMissionState.Countdown;
    if (index1 == (byte) 0)
    {
      AffairNarrativeTbl recordByIndex = this.AffairNarrativeTable.GetRecordByIndex((int) this.TimerMissionData[(int) index1].TimeMission[(int) this.TimerMissionData[(int) index1].ProcessIdx].ID);
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.AffairMission, true, this.TimerMissionData[(int) index1].MissionTime - (long) recordByIndex.TotalTime, (uint) recordByIndex.TotalTime);
    }
    else
    {
      AffairNarrativeTbl recordByIndex = this.AllianceNarrativeTable.GetRecordByIndex((int) this.TimerMissionData[(int) index1].TimeMission[(int) this.TimerMissionData[(int) index1].ProcessIdx].ID);
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.AllianceMission, true, this.TimerMissionData[(int) index1].MissionTime - (long) recordByIndex.TotalTime, (uint) recordByIndex.TotalTime);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, 2, (int) index2);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
    GUIManager.Instance.HideUILock(EUILock.Mission);
  }

  public void RecvTimeMissionReward(MessagePacket MP)
  {
    byte index1 = (byte) ((uint) MP.ReadByte() - 1U);
    byte num1 = MP.ReadByte();
    if (num1 == (byte) 0 || (int) index1 >= this.TimerMissionData.Length || (int) num1 > this.TimerMissionData[(int) index1].TimeMission.Length)
      return;
    byte index2 = (byte) ((uint) index1 + 1U);
    this.MissionNotice &= (byte) ~(1 << (int) index2);
    this.TimerMissionData[(int) index1].ProcessIdx = byte.MaxValue;
    byte index3;
    if (this.TimerMissionData[(int) index1].TimeMission[(int) (index3 = (byte) ((uint) num1 - 1U))].State == _eTimerMissionState.AutoComplete)
      --this.AccessMissionCount[(int) index2];
    this.TimerMissionData[(int) index1].TimeMission[(int) index3].State = _eTimerMissionState.Complete;
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    int index4 = 0;
    Array.Clear((Array) instance2.SE_Kind, 0, instance2.SE_Kind.Length);
    if (index2 == (byte) 1)
    {
      AffairCardinalTbl recordByIndex = this.AffairCardinalTable.GetRecordByIndex((int) this.TimerMissionData[(int) index1].TimeMission[(int) index3].Base);
      for (int index5 = 0; index5 < 5; ++index5)
      {
        if (recordByIndex.ResourceCardinal != null && index5 < recordByIndex.ResourceCardinal.Length && recordByIndex.ResourceCardinal[index5] > 0U)
        {
          instance2.SE_Kind[index4] = (SpeciallyEffect_Kind) (16 + (int) (byte) index5);
          instance2.m_SpeciallyEffect.mResValue[index5] = recordByIndex.ResourceCardinal[index5];
          ++index4;
        }
      }
      if (recordByIndex.Exp > 0U)
      {
        instance2.SE_Kind[index4] = SpeciallyEffect_Kind.LeadExp;
        ++index4;
      }
    }
    else
    {
      AllianceCardinalTbl recordByIndex = this.AllianceCardinalTable.GetRecordByIndex((int) this.TimerMissionData[(int) index1].TimeMission[(int) index3].Base);
      for (int index6 = 0; index6 < 5; ++index6)
      {
        if (recordByIndex.ResourceCardinal != null && index6 < recordByIndex.ResourceCardinal.Length && recordByIndex.ResourceCardinal[index6] > 0U)
        {
          instance2.SE_Kind[index4] = (SpeciallyEffect_Kind) (16 + (int) (byte) index6);
          instance2.m_SpeciallyEffect.mResValue[index6] = recordByIndex.ResourceCardinal[index6];
          ++index4;
        }
      }
      if (recordByIndex.Exp > 0U)
      {
        instance2.SE_Kind[index4] = SpeciallyEffect_Kind.LeadExp;
        ++index4;
      }
      if (recordByIndex.AllianceMoney > (ushort) 0)
      {
        instance2.SE_Kind[index4] = SpeciallyEffect_Kind.AllianceMoney;
        ++index4;
      }
    }
    Array.Clear((Array) instance2.SE_Stock, 0, instance2.SE_Stock.Length);
    for (int index7 = 0; index7 < 5; ++index7)
      instance1.Resource[index7].Stock = MP.ReadUInt();
    instance2.SE_Stock[4] = instance1.RoleAlliance.Money;
    if (index2 == (byte) 1)
    {
      int num2 = (int) MP.ReadUInt();
    }
    else
      instance1.RoleAlliance.Money = MP.ReadUInt();
    ushort morale = instance1.RoleAttr.Morale;
    DataManager.StageDataController.RoleAttrLevelUp(MP);
    if (this.TimerMissionData[(int) index1].TimeMission[(int) index3].ItemID > (ushort) 0)
    {
      DataManager.Instance.ReflashMaterialItem = (byte) 1;
      instance1.SetCurItemQuantity(this.TimerMissionData[(int) index1].TimeMission[(int) index3].ItemID, MP.ReadUShort(), (byte) ((uint) this.TimerMissionData[(int) index1].TimeMission[(int) index3].Quality + 1U), 0L);
    }
    Array.Clear((Array) instance2.SE_ItemID, 0, instance2.SE_ItemID.Length);
    if (this.TimerMissionData[(int) index1].TimeMission[(int) index3].ItemID > (ushort) 0)
    {
      instance2.SE_ItemID[0] = this.TimerMissionData[(int) index1].TimeMission[(int) index3].ItemID;
      instance2.SE_Item_L_Color[0] = (byte) ((uint) this.TimerMissionData[(int) index1].TimeMission[(int) index3].Quality + 1U);
    }
    if ((int) instance1.RoleAttr.Morale - (int) morale > 0)
    {
      instance2.SE_Kind[index4] = SpeciallyEffect_Kind.Morale;
      int num3 = index4 + 1;
    }
    instance2.m_SpeciallyEffect.AddIconShow(instance2.mStartV2, instance2.SE_Kind, instance2.SE_ItemID);
    instance2.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7946U + (uint) index1), (ushort) 11);
    GameManager.OnRefresh(NetworkNews.Refresh_Resource);
    instance2.UpdateUI(EGUIWindow.UI_Mission, 4, (int) index2);
    instance2.UpdateUI(EGUIWindow.Door, 15);
    this.CheckChanged(eMissionKind.Mark, (ushort) 102, (ushort) 1);
    instance2.HideUILock(EUILock.Mission);
  }

  public void RecvTimeMissionCompleteInst(MessagePacket MP)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    byte index = (byte) ((uint) MP.ReadByte() - 1U);
    byte num1 = MP.ReadByte();
    if (num1 == (byte) 0 || (int) index >= this.TimerMissionData.Length || (int) num1 > this.TimerMissionData[(int) index].TimeMission.Length)
      return;
    instance2.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0, eSpentCredits.eMission);
    byte num2 = (byte) ((uint) index + 1U);
    this.TimerMissionData[(int) index].ProcessIdx = byte.MaxValue;
    this.TimerMissionData[(int) index].MissionTime = -1L;
    byte num3;
    this.TimerMissionData[(int) index].TimeMission[(int) (num3 = (byte) ((uint) num1 - 1U))].State = _eTimerMissionState.Reward;
    this.MissionNotice |= (byte) (1U << (int) num2);
    if (num2 == (byte) 1)
    {
      instance1.SetQueueBarData(EQueueBarIndex.AffairMission, false, 0L, 0U);
      instance2.AddHUDMessage(instance1.mStringTable.GetStringByID(7942U), (ushort) 25);
    }
    else
    {
      instance1.SetQueueBarData(EQueueBarIndex.AllianceMission, false, 0L, 0U);
      instance2.AddHUDMessage(instance1.mStringTable.GetStringByID(7943U), (ushort) 25);
    }
    instance2.UpdateUI(EGUIWindow.UI_Mission, 1, (int) num2);
    instance2.HideUILock(EUILock.Mission);
    GameManager.OnRefresh();
  }

  public void RecvMissionComplete(MessagePacket MP)
  {
    ushort num1 = MP.ReadUShort();
    if (num1 == (ushort) 0)
      return;
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    int index1 = 0;
    Array.Clear((Array) instance2.SE_Kind, 0, instance2.SE_Kind.Length);
    this.SetBoolMark(num1);
    ManorAimTbl recordByKey = this.ManorAimTable.GetRecordByKey(num1);
    this.RewardList.Priority.Remove(this.ManorAimTable.GetRecordByKey(num1).UIPriority);
    DataManager.StageDataController.UpdateRoleAttrExp(MP.ReadUInt());
    if (recordByKey.Exp > 0U)
    {
      instance2.SE_Kind[index1] = SpeciallyEffect_Kind.LeadExp;
      ++index1;
    }
    instance1.RoleAttr.Power = MP.ReadULong();
    if (recordByKey.Force > 0U)
    {
      instance2.SE_Kind[index1] = SpeciallyEffect_Kind.Power;
      ++index1;
    }
    instance2.PreLeadLevel = (int) instance1.RoleAttr.Level;
    DataManager.StageDataController.RoleAttrLevelUp(MP, 57);
    if (recordByKey.RewardMorale > (byte) 0)
    {
      instance2.SE_Kind[index1] = SpeciallyEffect_Kind.Morale;
      ++index1;
    }
    Array.Clear((Array) instance2.SE_Stock, 0, instance2.SE_Stock.Length);
    for (ResourceType index2 = ResourceType.Grain; index2 < ResourceType.MAX; ++index2)
    {
      instance2.SE_Stock[(int) index2] = instance1.Resource[(int) index2].Stock;
      instance1.Resource[(int) index2].Stock = MP.ReadUInt();
      if (recordByKey.RewardResource != null && index2 < (ResourceType) recordByKey.RewardResource.Length && recordByKey.RewardResource[(int) index2] > 0U)
      {
        instance2.SE_Kind[index1] = (SpeciallyEffect_Kind) ((byte) 16 + index2);
        instance2.m_SpeciallyEffect.mResValue[(int) index2] = recordByKey.RewardResource[(int) index2];
        ++index1;
      }
    }
    byte num2 = MP.ReadByte();
    Array.Clear((Array) instance2.SE_ItemID, 0, instance2.SE_ItemID.Length);
    for (int index3 = 0; index3 < (int) num2; ++index3)
      instance1.SetCurItemQuantity(MP.ReadUShort(), MP.ReadUShort(), (byte) 0, 0L);
    if (recordByKey.RewardItems != null)
    {
      if (recordByKey.RewardItems[0].ItemID > (ushort) 0)
        instance2.SE_ItemID[0] = recordByKey.RewardItems[0].ItemID;
      if (recordByKey.RewardItems[1].ItemID > (ushort) 0)
        instance2.SE_ItemID[1] = recordByKey.RewardItems[1].ItemID;
      if (recordByKey.RewardItems[2].ItemID > (ushort) 0)
        instance2.SE_ItemID[2] = recordByKey.RewardItems[2].ItemID;
    }
    instance2.m_SpeciallyEffect.AddIconShow(instance2.mStartV2, instance2.SE_Kind, instance2.SE_ItemID);
    this.CheckChanged(eMissionKind.Mark, (ushort) 101, (ushort) 1);
    instance2.HideUILock(EUILock.Mission);
    instance2.UpdateUI(EGUIWindow.Door, 15);
    instance2.AddHUDMessage(instance1.mStringTable.GetStringByID(7945U), (ushort) 11);
    GameManager.OnRefresh();
    GameManager.OnRefresh(NetworkNews.Refresh_Item);
    GameManager.OnRefresh(NetworkNews.Refresh_Attr);
    AFAdvanceManager.Instance.CheckTurfQuestUnbroken();
  }

  public void RecvMissionFlag(MessagePacket MP)
  {
    ushort val1 = MP.ReadUShort();
    MP.ReadBlock(this.BoolMark, 0, Math.Min((int) val1, this.BoolMark.Length));
  }

  public void RecvMissionMark(MessagePacket MP)
  {
    ushort num = MP.ReadUShort();
    for (ushort index = 0; (int) index < (int) num; ++index)
    {
      if (this.DynaMark.Length > (int) index)
        this.DynaMark[(int) index] = MP.ReadUShort();
    }
    this.SetCompleteWhileLogin(eMissionKind.Mark);
    this.SetCompleteWhileLogin(eMissionKind.Army);
  }

  public void RecvMissionmarkUpdate(MessagePacket MP)
  {
    ushort Key = MP.ReadUShort();
    if ((int) Key >= this.DynaMark.Length)
      return;
    this.DynaMark[(int) Key] = MP.ReadUShort();
    if (Key >= (ushort) 124 && Key <= (ushort) 128)
      this.CollectDelay = (byte) Key;
    else
      this.CheckChanged(eMissionKind.Mark, Key, this.DynaMark[(int) Key]);
  }

  public void sendTimeMissionStart(_eMissionType type, byte index)
  {
    if (NewbieManager.IsNewbie || !GUIManager.Instance.ShowUILock(EUILock.Mission))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_MISSION_START;
    messagePacket.Add((byte) (type - 1 + 1));
    messagePacket.Add(index);
    messagePacket.Send();
  }

  public void sendTimeMissionReward(_eMissionType type, byte index)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Mission))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_MISSION_FINISH;
    messagePacket.Add((byte) (type - 1 + 1));
    messagePacket.Add(index);
    messagePacket.Send();
  }

  public void sendMissionComplete(ushort ID, ushort ManorID = 0)
  {
    if (NewbieManager.IsNewbie)
    {
      this.SetBoolMark(ID);
      this.RewardList.Priority.Remove(this.ManorAimTable.GetRecordByKey(ID).UIPriority);
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
    }
    else
    {
      if (BattleController.IsActive || !GUIManager.Instance.ShowUILock(EUILock.Mission))
        return;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.AddSeqId();
      messagePacket.Protocol = Protocol._MSG_REQUEST_MISSION_COMPLETE;
      messagePacket.Add(ID);
      if (ManorID > (ushort) 0)
        messagePacket.Add(ManorID);
      messagePacket.Send();
    }
  }

  public void CheckResourceCollect()
  {
    if (this.CollectDelay == (byte) 0)
      return;
    this.CheckChanged(eMissionKind.Mark, (ushort) this.CollectDelay, this.DynaMark[(int) this.CollectDelay]);
    this.CollectDelay = (byte) 0;
  }

  public bool HaveEmptyBox() => (int) this.VipBoxState != (int) this.VipBoxStateMax;

  public int GetVipBoxState(byte index) => (int) this.VipBoxState >> (int) index & 1;

  public void CleanVipBoxState()
  {
    this.VipBoxState = (byte) 0;
    this.VipRewardStartTime = 0L;
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.VIPMission, false, 0L, 0U);
    this.UpdateVipCount();
    this.Update(0.0f);
  }

  public void RecvVipMission(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    if (MP.ReadByte() > (byte) 0)
    {
      GUIManager.Instance.HideUILock(EUILock.Mission);
    }
    else
    {
      byte num1 = MP.ReadByte();
      this.UpdateUIBox = (byte) ((uint) num1 ^ (uint) this.VipBoxState);
      this.VipBoxState = num1;
      this.VipRewardStartTime = MP.ReadLong();
      instance.RoleAttr.Diamond += MP.ReadUInt();
      instance.RoleAlliance.Money += MP.ReadUInt();
      this.BoxEffectID = (byte) Mathf.Clamp((int) MP.ReadByte(), 1, 5);
      byte num2 = MP.ReadByte();
      if (this.UpdateUIBox > (byte) 0)
        this.MissionNotice &= (byte) 247;
      this.UpdateVipCount();
      this.UpdateVipTime();
      byte index1 = 0;
      if (num2 > (byte) 0)
      {
        this.RewardVipDiamond = 0U;
        for (byte index2 = 0; (int) index2 < (int) num2; ++index2)
        {
          ushort InKey = MP.ReadUShort();
          Equip recordByKey = instance.EquipTable.GetRecordByKey(InKey);
          if ((int) index1 < this.VipRewardItem.Length)
          {
            this.VipRewardItem[(int) index1] = InKey;
            this.VipRewardKind[(int) index1] = SpeciallyEffect_Kind.Kind;
          }
          if (recordByKey.EquipKind == (byte) 11 && recordByKey.PropertiesInfo != null && (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 6 || recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 7))
          {
            if ((int) index1 < this.VipRewardItem.Length)
            {
              if (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 6)
              {
                this.RewardVipDiamond += (uint) recordByKey.PropertiesInfo[1].Propertieskey * (uint) recordByKey.PropertiesInfo[1].PropertiesValue;
                this.VipRewardKind[(int) index1] = SpeciallyEffect_Kind.Diamond;
              }
              else if (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 7)
                this.VipRewardKind[(int) index1] = SpeciallyEffect_Kind.AllianceMoney;
            }
            int num3 = (int) MP.ReadUShort();
            int num4 = (int) MP.ReadByte();
            ++index1;
          }
          else
          {
            ushort Quantity = (ushort) ((uint) instance.GetCurItemQuantity(recordByKey.EquipKey, (byte) 0) + (uint) MP.ReadUShort());
            byte Rare = MP.ReadByte();
            instance.SetCurItemQuantity(recordByKey.EquipKey, Quantity, Rare, 0L);
            ++index1;
          }
        }
        Array.Clear((Array) this.VipRewardItem, (int) index1, this.VipRewardItem.Length - (int) num2);
        Array.Clear((Array) this.VipRewardKind, (int) index1, this.VipRewardKind.Length - (int) num2);
      }
      GUIManager.Instance.HideUILock(EUILock.Mission);
      GameManager.OnRefresh();
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, 4, 3);
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
      this.UpdateUIBox = (byte) 0;
      this.BoxEffectID = (byte) 0;
    }
  }

  public void sendReceiveVipBox(byte index)
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Mission))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_MISSION_VIP_COLLECT;
    messagePacket.Add(index);
    messagePacket.Send();
  }

  public void sendVipMissionImmed()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Mission))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_MISSION_VIP_SPEEDUP;
    messagePacket.Send();
  }

  public void RecvVipMissionImmed(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Mission);
    if (MP.ReadByte() > (byte) 0)
      return;
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.VIPMission, false, 0L, 0U);
    DataManager.Instance.RoleAttr.Diamond = MP.ReadUInt();
    this.VipRewardStartTime = 0L;
    GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7944U), (ushort) 11);
    if ((int) this.VipBoxState != (int) this.VipBoxStateMax)
      this.MissionNotice |= (byte) 8;
    GameManager.OnRefresh();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Mission, 4, 3);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
  }

  public void UpdateVipTime()
  {
    DataManager instance = DataManager.Instance;
    if ((int) this.VipBoxState != (int) this.VipBoxStateMax && this.VipRewardStartTime + 3600L > instance.ServerTime)
    {
      instance.SetQueueBarData(EQueueBarIndex.VIPMission, true, this.VipRewardStartTime, 3600U);
      instance.SetRecvQueueBarData(21);
    }
    else
      instance.SetQueueBarData(EQueueBarIndex.VIPMission, false, 0L, 0U);
  }

  private void UpdateVipCount()
  {
    DataManager instance = DataManager.Instance;
    this.AccessMissionCount[3] = (byte) 0;
    for (int index = 0; index < this.VipLvRestrict.Length; ++index)
    {
      if ((int) this.VipLvRestrict[index] <= (int) instance.RoleAttr.VIPLevel && ((int) this.VipBoxState >> index & 1) == 0)
        ++this.AccessMissionCount[3];
    }
  }

  public ushort CheckDynaMark(byte id)
  {
    return (int) id < this.DynaMark.Length ? this.DynaMark[(int) id] : (ushort) 0;
  }
}
