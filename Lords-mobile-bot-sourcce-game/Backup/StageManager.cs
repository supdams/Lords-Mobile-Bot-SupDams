// Decompiled with JetBrains decompiler
// Type: StageManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
public class StageManager
{
  public CExternalTableWithWordKey<Chapter> ChapterTable;
  public CExternalTableWithWordKey<Level>[] LevelTable;
  public CExternalTableWithWordKey<LevelEX>[] LevelEXTable;
  public CExternalTableWithWordKey<Stage> StageTable;
  public CExternalTableWithWordKey<CorpsStage> CorpsStageTable;
  public CExternalTableWithWordKey<CorpsStageBattle> CorpsStageBattleTable;
  public CExternalTableWithWordKey<StageConditionData> StageConditionDataTable;
  public CExternalTableWithWordKey<StageConditionInfo> StageConditionInfoTable;
  public byte currentChapterID = byte.MaxValue;
  public ushort currentPointID;
  public ushort savePointID;
  public StageMode saveStageMode;
  public ushort lastStageRecord;
  public ushort[] StageRecord;
  public ushort[] inoutPointID;
  public byte[][] StageInfo;
  public byte[] isNotFirstInLine;
  public byte[] isNotFirstInChapter;
  public ushort[] limitRecord;
  public StageMode _stageMode = StageMode.Count;
  public StageMode inoutStageMode = StageMode.Count;
  public WorldMode currentWorldMode;
  public CombatStageSoldierDataType[] NowCombatStageInfo;
  public uint CorpsStageWallDefence;
  public byte currentNodus;
  public ushort DareNodusUpdatePointID;
  public byte mStageTroopsCount;
  public byte mStageTrapsCount;
  public uint mStageTroopsAmount;
  public uint mStageTrapsAmount;
  public uint CorpsStagetotalStrength;

  public StageManager() => this.StageInit();

  public void Init() => this.StageInit();

  public void loginFinish()
  {
    if (this.inoutStageMode != StageMode.Count && this.inoutStageMode < StageMode.Count)
      return;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.uLongToFormat((ulong) DataManager.Instance.RoleAttr.UserId);
    cstring.AppendFormat("{0}_currentStageMode");
    this.inoutStageMode = (StageMode) PlayerPrefs.GetInt(cstring.ToString());
    if (this.inoutStageMode == StageMode.Corps || this.inoutStageMode >= StageMode.Count)
      this.inoutStageMode = StageMode.Full;
    this.GetUserStage(StageMode.Full);
    this.GetUserStage(StageMode.Lean);
    this.GetUserStage(StageMode.Dare);
    this.resetStageMode(this.inoutStageMode);
  }

  public void LoadTableData()
  {
    this.LevelTable = new CExternalTableWithWordKey<Level>[3];
    this.LevelEXTable = new CExternalTableWithWordKey<LevelEX>[3];
    this.ChapterTable = new CExternalTableWithWordKey<Chapter>();
    this.LevelTable[0] = new CExternalTableWithWordKey<Level>();
    this.LevelTable[1] = new CExternalTableWithWordKey<Level>();
    this.LevelTable[2] = new CExternalTableWithWordKey<Level>();
    this.StageTable = new CExternalTableWithWordKey<Stage>();
    this.CorpsStageTable = new CExternalTableWithWordKey<CorpsStage>();
    this.CorpsStageBattleTable = new CExternalTableWithWordKey<CorpsStageBattle>();
    this.StageConditionDataTable = new CExternalTableWithWordKey<StageConditionData>();
    this.LevelEXTable[0] = new CExternalTableWithWordKey<LevelEX>();
    this.LevelEXTable[1] = new CExternalTableWithWordKey<LevelEX>();
    this.LevelEXTable[2] = new CExternalTableWithWordKey<LevelEX>();
    this.StageConditionInfoTable = new CExternalTableWithWordKey<StageConditionInfo>();
    this.ChapterTable.LoadTable("Chapter");
    this.LevelTable[0].LoadTable("NormalMiniStage");
    this.LevelTable[1].LoadTable("NormalStage");
    this.LevelTable[2].LoadTable("AdvanceStage");
    this.LevelEXTable[0].LoadTable("EX_NormalMiniStage");
    this.LevelEXTable[1].LoadTable("EX_NormalStage");
    this.LevelEXTable[2].LoadTable("EX_AdvanceStage");
    this.StageTable.LoadTable("Stage");
    this.CorpsStageTable.LoadTable("CorpsPVEface");
    this.CorpsStageBattleTable.LoadTable("CorpsPVEbattle");
    this.StageConditionDataTable.LoadTable("HeroChallengeLevel");
    this.StageConditionInfoTable.LoadTable("HeroChallengeEffect");
    this.limitRecord[2] = (ushort) this.CorpsStageTable.TableCount;
  }

  public void StageInit()
  {
    this.mStageTroopsCount = this.mStageTrapsCount = (byte) 0;
    this.mStageTroopsAmount = this.mStageTrapsAmount = this.CorpsStagetotalStrength = 0U;
    if (this.NowCombatStageInfo == null)
    {
      this.NowCombatStageInfo = new CombatStageSoldierDataType[10];
      Array.Clear((Array) this.NowCombatStageInfo, 0, this.NowCombatStageInfo.Length);
    }
    if (this.StageRecord == null)
    {
      this.StageRecord = new ushort[4];
      Array.Clear((Array) this.StageRecord, 0, this.StageRecord.Length);
    }
    if (this.inoutPointID == null)
    {
      this.inoutPointID = new ushort[4];
      Array.Clear((Array) this.inoutPointID, 0, this.inoutPointID.Length);
    }
    if (this.StageInfo == null)
      this.StageInfo = new byte[4][];
    if (this.StageInfo[0] == null)
    {
      this.StageInfo[0] = new byte[(int) GameConstants.StageInfoSize[0]];
      Array.Clear((Array) this.StageInfo[0], 0, this.StageInfo[0].Length);
    }
    if (this.StageInfo[1] == null)
    {
      this.StageInfo[1] = new byte[(int) GameConstants.StageInfoSize[1]];
      Array.Clear((Array) this.StageInfo[1], 0, this.StageInfo[1].Length);
    }
    this.StageInfo[2] = (byte[]) null;
    if (this.StageInfo[3] == null)
    {
      this.StageInfo[3] = new byte[(int) GameConstants.StageInfoSize[3]];
      Array.Clear((Array) this.StageInfo[3], 0, this.StageInfo[3].Length);
    }
    if (this.isNotFirstInLine == null)
    {
      this.isNotFirstInLine = new byte[4];
      Array.Clear((Array) this.isNotFirstInLine, 0, this.isNotFirstInLine.Length);
    }
    if (this.isNotFirstInChapter == null)
    {
      this.isNotFirstInChapter = new byte[4];
      Array.Clear((Array) this.isNotFirstInChapter, 0, this.isNotFirstInChapter.Length);
    }
    if (this.limitRecord == null)
    {
      this.limitRecord = new ushort[4];
      this.limitRecord[0] = (ushort) 18;
      this.limitRecord[1] = (ushort) 6;
      this.limitRecord[2] = (ushort) 1;
      this.limitRecord[3] = (ushort) 18;
    }
    this.resetStageMode(StageMode.Full);
    this.savePointID = (ushort) 0;
    this.saveStageMode = StageMode.Count;
  }

  public byte ChapterID
  {
    get
    {
      byte stageMode = (byte) this._stageMode;
      ushort num1 = this.StageRecord[(int) stageMode];
      if ((int) num1 >= (int) this.limitRecord[(int) stageMode])
        num1 = this.limitRecord[(int) stageMode] != (ushort) 0 ? (ushort) ((int) this.limitRecord[(int) stageMode] - 1) : (ushort) 0;
      ushort num2;
      return (byte) (num2 = (ushort) ((uint) (ushort) ((uint) num1 / (uint) GameConstants.StagePointNum[(int) stageMode]) + 1U));
    }
  }

  public bool reflashStageRecordInfo(StageMode in_stageMode, ushort in_StageRecord)
  {
    ushort num = this.StageRecord[(int) in_stageMode];
    this.StageRecord[(int) in_stageMode] = in_StageRecord;
    this.UpdateStagelimitRecord();
    if (in_stageMode == StageMode.Full || in_stageMode == StageMode.Lean || in_stageMode == StageMode.Corps)
      DataManager.MissionDataManager.CheckChanged((eMissionKind) ((byte) 3 + in_stageMode), (ushort) 1, this.StageRecord[(int) in_stageMode]);
    else
      DataManager.MissionDataManager.CheckChanged(eMissionKind.ChallengeStage, (ushort) 1, this.StageRecord[(int) in_stageMode]);
    if (num == (ushort) 0 || (int) in_StageRecord <= (int) num)
      return false;
    DataManager.msgBuffer[0] = (byte) 4;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    return true;
  }

  public void UpdateStageRecord(StageMode in_stageMode, ushort in_StageRecord)
  {
    this._stageMode = in_stageMode;
    if (DataManager.Instance.lastBattleResult > (short) 0 && (int) this.currentChapterID == (int) this.ChapterID && (int) this.currentPointID == (int) this.StageRecord[(int) this._stageMode] + 1)
    {
      if ((int) this.StageRecord[(int) this._stageMode] % (int) GameConstants.LinePointNum[(int) this._stageMode] == (int) GameConstants.LinePointNum[(int) this._stageMode] - 1)
      {
        this.isNotFirstInLine[(int) this._stageMode] = (byte) 0;
        if (this._stageMode == StageMode.Full && (int) this.StageRecord[0] % (int) GameConstants.StagePointNum[0] == 17)
        {
          Chapter recordByKey = this.ChapterTable.GetRecordByKey((ushort) this.currentChapterID);
          ushort heroItemId = recordByKey.Hero_ItemID;
          ushort heroItemNum = (ushort) recordByKey.Hero_ItemNum;
          ushort curItemQuantity1 = DataManager.Instance.GetCurItemQuantity(heroItemId, (byte) 0);
          if (curItemQuantity1 < ushort.MaxValue)
            DataManager.Instance.SetCurItemQuantity(heroItemId, (ushort) ((uint) curItemQuantity1 + (uint) heroItemNum), (byte) 0, 0L);
          for (int index = 0; index < 5; ++index)
          {
            if (recordByKey.Items[index].ItemID != (ushort) 0)
            {
              ushort itemId = recordByKey.Items[index].ItemID;
              ushort itemNum = (ushort) recordByKey.Items[index].ItemNum;
              ushort curItemQuantity2 = DataManager.Instance.GetCurItemQuantity(itemId, (byte) 0);
              if (curItemQuantity2 < ushort.MaxValue)
                DataManager.Instance.SetCurItemQuantity(itemId, (ushort) ((uint) curItemQuantity2 + (uint) itemNum), (byte) 0, 0L);
            }
          }
        }
      }
      ++this.currentPointID;
      if ((int) this.currentPointID > (int) this.limitRecord[(int) this._stageMode])
        this.currentPointID = this.limitRecord[(int) this._stageMode];
      this.SaveUserStage(this._stageMode);
    }
    if (in_StageRecord == (ushort) 3 && in_stageMode == StageMode.Full && this.StageRecord[(int) in_stageMode] == (ushort) 2)
      AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.HEROSTAGE1_3_COMPLETION);
    if ((int) in_StageRecord > (int) this.StageRecord[(int) in_stageMode] && in_stageMode == StageMode.Full)
      FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.FIRST_UNLOCK_NORMAL_CHAPTER, 0L, 0UL);
    this.StageRecord[(int) this._stageMode] = in_StageRecord;
    this.UpdateStagelimitRecord();
  }

  public void UpdateStagelimitRecord()
  {
    this.limitRecord[0] = (ushort) ((uint) this.StageRecord[2] * (uint) GameConstants.StagePointNum[0]);
    this.limitRecord[1] = (ushort) ((uint) this.limitRecord[0] / (uint) GameConstants.StagePointNum[0] * (uint) GameConstants.StagePointNum[1]);
    ushort num = (ushort) (this.LevelEXTable[0].TableCount + this.LevelEXTable[1].TableCount);
    this.limitRecord[3] = (ushort) ((uint) this.StageRecord[1] / (uint) GameConstants.StagePointNum[1] * (uint) GameConstants.StagePointNum[3]);
    if ((int) num >= (int) this.limitRecord[3])
      return;
    this.limitRecord[3] = num;
  }

  public void CheckFirstInChapter()
  {
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.uLongToFormat((ulong) DataManager.Instance.RoleAttr.UserId);
    cstring.AppendFormat("{0}_isNotFirstInChapter");
    int num = PlayerPrefs.GetInt(cstring.ToString());
    for (byte index = 0; (int) index < this.isNotFirstInChapter.Length; ++index)
    {
      this.isNotFirstInChapter[(int) index] = (byte) (num >> (int) index & 1);
      if (index != (byte) 2)
      {
        if (this.isNotFirstInChapter[(int) index] == (byte) 0 && ((int) this.StageRecord[(int) index] % (int) GameConstants.StagePointNum[(int) index] != 0 || this.limitRecord[(int) index] != (ushort) 0 && (int) this.StageRecord[(int) index] == (int) this.limitRecord[(int) index]))
          this.isNotFirstInChapter[(int) index] = (byte) 1;
        if (this.isNotFirstInChapter[(int) index] == (byte) 0)
          this.isNotFirstInLine[(int) index] = (byte) 0;
        else if ((int) this.StageRecord[(int) index] % (int) GameConstants.LinePointNum[(int) index] != 0)
          this.isNotFirstInLine[(int) index] = (byte) 1;
      }
    }
  }

  private void InicurrentPointID()
  {
    byte stageMode = (byte) this._stageMode;
    this.currentPointID = (int) this.StageRecord[(int) stageMode] >= (int) this.limitRecord[(int) stageMode] ? this.limitRecord[(int) stageMode] : (ushort) ((uint) this.StageRecord[(int) stageMode] + 1U);
  }

  public void resetCurrentPointIDwithStageRecord()
  {
    byte stageMode = (byte) this._stageMode;
    this.currentPointID = (int) this.StageRecord[(int) stageMode] >= (int) this.limitRecord[(int) stageMode] ? this.limitRecord[(int) stageMode] : (ushort) ((uint) this.StageRecord[(int) stageMode] + 1U);
    this.inoutPointID[(int) stageMode] = this.currentPointID;
  }

  public void SaveCurrentChapter()
  {
    this.saveStageMode = this._stageMode;
    this.savePointID = this.currentPointID;
  }

  public void ReBackCurrentChapter()
  {
    if (this.saveStageMode == StageMode.Count)
      return;
    this._stageMode = this.saveStageMode;
    this.currentPointID = this.savePointID;
    this.currentChapterID = (byte) (((uint) this.currentPointID - 1U) / (uint) GameConstants.StagePointNum[(int) this._stageMode]);
    ++this.currentChapterID;
    DataManager.Instance.lastBattleResult = (short) -1;
    this.saveStageMode = StageMode.Count;
  }

  public void UpdateRoleAttrLevel(byte newLevel)
  {
    AFAdvanceManager.Instance.CheckCharacterLvEvent(DataManager.Instance.RoleAttr.Level);
    if (newLevel > (byte) 60)
      newLevel = (byte) 60;
    if ((int) DataManager.Instance.RoleAttr.Level == (int) newLevel)
      return;
    GUIManager.Instance.PreLeadLevel = (int) DataManager.Instance.RoleAttr.Level;
    DataManager.Instance.RoleAttr.Level = newLevel;
    GUIManager.Instance.CheckLvUp();
  }

  public LevelTableKind GetcurrentPointLevelID(out ushort LevelID, ushort pointid = 0)
  {
    ushort num1 = LevelID = pointid != (ushort) 0 ? pointid : this.currentPointID;
    LevelTableKind levelTableKind = LevelTableKind.NormalMiniStage;
    if (LevelID != (ushort) 0)
    {
      if (this._stageMode == StageMode.Dare)
      {
        if (this.StageDareMode(this.currentChapterID) == StageMode.Lean)
        {
          levelTableKind = LevelTableKind.AdvanceStage;
          --LevelID;
          LevelID /= GameConstants.LinePointNum[(int) this._stageMode];
          ++LevelID;
        }
        else
        {
          --LevelID;
          LevelID /= GameConstants.LinePointNum[(int) this._stageMode];
          ushort num2 = (ushort) ((uint) num1 % (uint) GameConstants.LinePointNum[(int) this._stageMode]);
          if (num2 == (ushort) 0)
          {
            levelTableKind = LevelTableKind.NormalStage;
            ++LevelID;
          }
          else
          {
            LevelID <<= 1;
            LevelID += num2;
          }
        }
      }
      else if (this._stageMode == StageMode.Lean)
        levelTableKind = LevelTableKind.AdvanceStage;
      else if (this._stageMode == StageMode.Full)
      {
        --LevelID;
        LevelID /= GameConstants.LinePointNum[(int) this._stageMode];
        ushort num3 = (ushort) ((uint) num1 % (uint) GameConstants.LinePointNum[(int) this._stageMode]);
        if (num3 == (ushort) 0)
        {
          levelTableKind = LevelTableKind.NormalStage;
          ++LevelID;
        }
        else
        {
          LevelID <<= 1;
          LevelID += num3;
        }
      }
    }
    return levelTableKind;
  }

  public Level GetLevelBycurrentPointID(ushort pointid = 0)
  {
    ushort LevelID = 0;
    return this.LevelTable[(int) this.GetcurrentPointLevelID(out LevelID, pointid)].GetRecordByKey(LevelID);
  }

  public LevelEX GetLevelEXBycurrentPointID(ushort pointid = 0)
  {
    ushort LevelID = 0;
    return this.LevelEXTable[(int) this.GetcurrentPointLevelID(out LevelID, pointid)].GetRecordByKey(LevelID);
  }

  public int GetStagePoint(ushort PointID = 0, byte SetStageMode = 0)
  {
    int stagePoint = -1;
    if (PointID == (ushort) 0)
      PointID = this.currentPointID;
    int num1;
    switch (SetStageMode)
    {
      case 1:
        num1 = 0;
        break;
      case 2:
        num1 = 1;
        break;
      case 3:
        num1 = 3;
        break;
      default:
        num1 = (int) this._stageMode;
        break;
    }
    switch ((StageMode) num1)
    {
      case StageMode.Full:
        if ((int) PointID % 3 != 0 || PointID < (ushort) 1)
          return stagePoint;
        PointID /= (ushort) 3;
        int num2 = (int) --PointID << 1;
        int index1 = num2 >> 3;
        if (index1 < this.StageInfo[0].Length)
        {
          stagePoint = (int) this.StageInfo[0][index1] >> (num2 & 7) & 3;
          break;
        }
        break;
      case StageMode.Lean:
        if ((int) (byte) ((uint) PointID - 1U) < this.StageInfo[1].Length)
        {
          stagePoint = (int) this.StageInfo[1][(int) PointID - 1] & 3;
          break;
        }
        break;
      case StageMode.Dare:
        if (this.StageDareMode(PointID) != StageMode.Lean || (int) PointID % 3 != 0 || PointID < (ushort) 1)
          return stagePoint;
        --PointID;
        int num3 = (int) PointID & 7;
        int index2 = (int) PointID >> 3;
        if (index2 < this.StageInfo[3].Length)
        {
          if (num3 < 2)
          {
            if (index2 > 0)
              stagePoint = num3 != 0 ? ((int) this.StageInfo[3][index2] & 3) << 1 | (int) this.StageInfo[3][index2 - 1] >> 7 : ((int) this.StageInfo[3][index2] & 1) << 2 | (int) this.StageInfo[3][index2 - 1] >> 6;
          }
          else
            stagePoint = (int) this.StageInfo[3][index2] >> num3 - 2;
          stagePoint &= 7;
          break;
        }
        break;
    }
    return stagePoint;
  }

  public void SetStagePoint(ushort PointID, byte Score, ushort Freq = 0)
  {
    this.DareNodusUpdatePointID = (ushort) 0;
    int num1 = this.GetStagePoint(PointID, (byte) 0);
    if (this._stageMode == StageMode.Full)
    {
      if (num1 < 0 || num1 >= (int) Score)
        return;
      PointID /= (ushort) 3;
      int num2 = (int) --PointID << 1;
      int index = num2 >> 3;
      this.StageInfo[0][index] &= (byte) ~(3 << (num2 & 7));
      this.StageInfo[0][index] |= (byte) ((uint) Score << (num2 & 7));
    }
    else if (this._stageMode == StageMode.Lean)
    {
      if (num1 < (int) Score)
        num1 = (int) Score;
      int num3 = num1 | (int) Freq << 2;
      this.StageInfo[1][(int) PointID - 1] = (byte) num3;
    }
    else
    {
      if (this._stageMode != StageMode.Dare)
        return;
      Score &= (byte) 7;
      if (num1 < 0 || num1 >= (int) Score)
        return;
      this.DareNodusUpdatePointID = PointID;
      --PointID;
      int num4 = (int) PointID & 7;
      int index = (int) PointID >> 3;
      if (index >= this.StageInfo[3].Length)
        return;
      if (num4 < 2)
      {
        if (index <= 0)
          return;
        if (num4 == 0)
        {
          this.StageInfo[3][index] &= (byte) 254;
          this.StageInfo[3][index] |= (byte) ((uint) Score >> 2);
          this.StageInfo[3][index - 1] &= (byte) 63;
          this.StageInfo[3][index - 1] |= (byte) ((uint) Score << 6);
        }
        else
        {
          this.StageInfo[3][index] &= (byte) 252;
          this.StageInfo[3][index] |= (byte) ((uint) Score >> 1);
          this.StageInfo[3][index - 1] &= (byte) 127;
          this.StageInfo[3][index - 1] |= (byte) ((uint) Score << 7);
        }
      }
      else
      {
        this.StageInfo[3][index] &= (byte) ~(7 << num4 - 2);
        this.StageInfo[3][index] |= (byte) ((uint) Score << num4 - 2);
      }
    }
  }

  public void ResetLeanStageTimes()
  {
    for (int index = 0; index < this.StageInfo[1].Length; ++index)
      this.StageInfo[1][index] = (byte) ((uint) this.StageInfo[1][index] & 3U);
  }

  public bool UpdateCorpsStageInfo(MessagePacket MP, bool reflash = false)
  {
    if (reflash)
    {
      reflash = this.reflashStageRecordInfo(StageMode.Corps, (ushort) MP.ReadByte());
    }
    else
    {
      this.StageRecord[2] = (ushort) MP.ReadByte();
      this.UpdateStagelimitRecord();
    }
    if (this.StageRecord[2] >= (ushort) 1)
      AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.TURFBATTLE1_COMPLETION);
    FBAdvanceManager.Instance.TriggerFbEvent(EFBEvent.FIRST_CONQUER_TURF_BATTLE, 0L, 0UL);
    this.mStageTrapsCount = this.mStageTroopsCount = (byte) 0;
    this.CorpsStagetotalStrength = this.mStageTrapsAmount = this.mStageTroopsAmount = 0U;
    for (int index = 0; index < 10; ++index)
    {
      this.NowCombatStageInfo[index].SoldierTableID = MP.ReadByte();
      this.NowCombatStageInfo[index].Amount = MP.ReadUInt();
      if (this.NowCombatStageInfo[index].SoldierTableID > (byte) 16)
      {
        ++this.mStageTrapsCount;
        this.mStageTrapsAmount += this.NowCombatStageInfo[index].Amount;
      }
      else if (this.NowCombatStageInfo[index].SoldierTableID > (byte) 0)
      {
        ++this.mStageTroopsCount;
        this.mStageTroopsAmount += this.NowCombatStageInfo[index].Amount;
      }
      this.CorpsStagetotalStrength += (uint) DataManager.Instance.SoldierDataTable.GetRecordByKey((ushort) this.NowCombatStageInfo[index].SoldierTableID).Strength * this.NowCombatStageInfo[index].Amount;
    }
    this.CorpsStageWallDefence = MP.ReadUInt();
    return reflash;
  }

  public void UpdateRoleAttrExp(uint newExp)
  {
    if ((int) DataManager.Instance.RoleAttr.Exp == (int) newExp)
      return;
    DataManager.Instance.RoleAttr.Exp = newExp;
  }

  public void UpdateRoleTalentPoint(ushort newTalentPoint)
  {
    if ((int) DataManager.Instance.RoleTalentPoint == (int) newTalentPoint)
      return;
    DataManager.Instance.tmpRoleTotalTalent = (ushort) ((uint) newTalentPoint - (uint) DataManager.Instance.RoleTalentPoint);
    DataManager.Instance.UpdateSaveTalent_Point(true);
    DataManager.Instance.RoleTalentPoint = newTalentPoint;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 13);
    GameManager.OnRefresh();
    DataManager.Instance.CheckTalentSend();
  }

  public void UpdateRoleAttrMorale(ushort newMorale)
  {
    if ((int) DataManager.Instance.RoleAttr.Morale == (int) newMorale)
      return;
    DataManager.Instance.RoleAttr.Morale = newMorale;
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
    GameManager.OnRefresh();
  }

  public void RoleAttrLevelUp(MessagePacket MP, int UpdateFlag = 59)
  {
    if ((UpdateFlag & 1) != 0)
      this.UpdateRoleAttrLevel(MP.ReadByte());
    if ((UpdateFlag & 2) != 0)
      this.UpdateRoleAttrExp(MP.ReadUInt());
    if ((UpdateFlag & 4) != 0)
      DataManager.Instance.Resource[4].Stock = MP.ReadUInt();
    if ((UpdateFlag & 8) != 0)
      this.UpdateRoleAttrMorale(MP.ReadUShort());
    if ((UpdateFlag & 16) != 0)
      DataManager.Instance.RoleAttr.LastMoraleRecoverTime = MP.ReadLong();
    if ((UpdateFlag & 32) == 0)
      return;
    this.UpdateRoleTalentPoint(MP.ReadUShort());
  }

  public void resetStageMode(StageMode newStageMode)
  {
    if (newStageMode >= StageMode.Count)
      return;
    this._stageMode = newStageMode;
    this.currentPointID = this.inoutPointID[(int) this._stageMode];
    if (this._stageMode == StageMode.Corps || this.currentPointID < (ushort) 1 || (int) this.currentPointID > (int) this.limitRecord[(int) this._stageMode])
    {
      this.currentChapterID = this.ChapterID;
      this.InicurrentPointID();
      if ((int) this.inoutPointID[(int) this._stageMode] == (int) this.currentPointID)
        return;
      this.inoutPointID[(int) this._stageMode] = this.currentPointID;
    }
    else
    {
      this.currentChapterID = (byte) (((uint) this.currentPointID - 1U) / (uint) GameConstants.StagePointNum[(int) this._stageMode]);
      ++this.currentChapterID;
    }
  }

  public bool CheckStageModle()
  {
    byte inoutStageMode = (byte) this.inoutStageMode;
    if ((int) this.currentPointID != (int) this.StageRecord[(int) inoutStageMode] + 1 || (int) this.currentPointID != (int) this.limitRecord[(int) inoutStageMode])
      return true;
    bool flag = false;
    CString Name = StringManager.Instance.SpawnString();
    ushort InKey1 = 1;
    if (DataManager.Instance.RoleAttr.Head != (ushort) 0)
      InKey1 = DataManager.Instance.RoleAttr.Head;
    Hero recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(InKey1);
    Name.ClearString();
    Name.IntToFormat((long) recordByKey1.Modle, 5);
    Name.AppendFormat("Role/hero_{0}");
    if (recordByKey1.Modle > (ushort) 0 && AssetManager.GetAssetBundleDownload(Name, AssetPath.Role, AssetType.Hero, recordByKey1.Modle))
    {
      ushort InKey2 = (ushort) ((uint) (ushort) ((uint) (ushort) this.currentChapterID - 1U) * 6U);
      ushort num1 = this.StageRecord[(int) inoutStageMode];
      if ((int) num1 == (int) this.limitRecord[(int) inoutStageMode] && num1 > (ushort) 0)
        --num1;
      ushort num2 = (ushort) ((uint) (ushort) ((uint) num1 / (uint) GameConstants.LinePointNum[(int) inoutStageMode]) % 6U);
      byte index1 = (byte) ((uint) inoutStageMode + 1U);
      if ((int) index1 > this.LevelTable.Length)
        index1 = (byte) 1;
      for (ushort index2 = 0; (int) index2 <= (int) num2; ++index2)
        ++InKey2;
      Level recordByKey2 = this.LevelTable[(int) index1].GetRecordByKey(InKey2);
      if (recordByKey2.Team == null)
        return flag;
      HeroTeam recordByKey3 = DataManager.Instance.TeamTable.GetRecordByKey(recordByKey2.Team[2]);
      if (recordByKey3.Arrays == null)
        return flag;
      for (int index3 = 0; index3 < recordByKey3.Arrays.Length; ++index3)
      {
        HeroTeamAttribute array = recordByKey3.Arrays[index3];
        if (array.Type == (byte) 3)
        {
          recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(array.Hero);
          Name.ClearString();
          Name.IntToFormat((long) recordByKey1.Modle, 5);
          Name.AppendFormat("Role/hero_{0}");
          flag = AssetManager.GetAssetBundleDownload(Name, AssetPath.Role, AssetType.Hero, recordByKey1.Modle);
          break;
        }
      }
    }
    return flag;
  }

  public void SaveisNotFirstInChapter()
  {
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.uLongToFormat((ulong) DataManager.Instance.RoleAttr.UserId);
    cstring.AppendFormat("{0}_isNotFirstInChapter");
    PlayerPrefs.SetInt(cstring.ToString(), (int) this.isNotFirstInChapter[3] << 3 | (int) this.isNotFirstInChapter[2] << 2 | (int) this.isNotFirstInChapter[1] << 1 | (int) this.isNotFirstInChapter[0]);
  }

  public StageMode StageDareMode(byte in_ChapterID)
  {
    byte index = 3;
    ushort num1 = this.StageRecord[(int) index];
    if ((int) num1 >= (int) this.limitRecord[(int) index])
      num1 = this.limitRecord[(int) index];
    ushort num2;
    byte num3 = (byte) (num2 = (ushort) ((uint) (ushort) ((uint) num1 / (uint) GameConstants.StagePointNum[(int) index]) + 1U));
    return (int) in_ChapterID < (int) num3 ? StageMode.Lean : StageMode.Full;
  }

  public StageMode StageDareMode(ushort in_PointID)
  {
    byte index = 3;
    ushort num1 = in_PointID != (ushort) 0 ? (ushort) ((uint) in_PointID - 1U) : (ushort) 0;
    if ((int) num1 >= (int) this.limitRecord[(int) index])
      num1 = this.limitRecord[(int) index];
    ushort num2;
    return this.StageDareMode((byte) (num2 = (ushort) ((uint) (ushort) ((uint) num1 / (uint) GameConstants.StagePointNum[(int) index]) + 1U)));
  }

  public bool GetStageConditionString(
    CString CStr,
    byte ConditionID,
    ushort FactorA = 0,
    ushort FactorB = 0,
    ushort ConditionKey = 0)
  {
    bool stageConditionString = true;
    DataManager instance = DataManager.Instance;
    CStr.Length = 0;
    switch (ConditionID)
    {
      case 1:
        CStr.StringToFormat(instance.mStringTable.GetStringByID(9200U + (uint) FactorB));
        if (FactorA == (ushort) 0)
        {
          CStr.AppendFormat(instance.mStringTable.GetStringByID(13501U));
          break;
        }
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13502U));
        break;
      case 2:
        CStr.IntToFormat((long) FactorA);
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13503U));
        break;
      case 3:
        Hero recordByKey1 = instance.HeroTable.GetRecordByKey(FactorA);
        CStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey1.HeroTitle));
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13504U));
        break;
      case 4:
        CStr.IntToFormat((long) FactorA);
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13505U));
        break;
      case 5:
        if (FactorA == (ushort) 0)
        {
          CStr.Append(instance.mStringTable.GetStringByID(13506U));
          break;
        }
        CStr.IntToFormat((long) FactorA);
        CStr.AppendFormat(instance.mStringTable.GetStringByID(12502U));
        break;
      case 6:
        if (FactorA == (ushort) 1)
          CStr.StringToFormat(instance.mStringTable.GetStringByID(13517U));
        else
          CStr.StringToFormat(instance.mStringTable.GetStringByID(13519U + (uint) FactorA));
        CStr.IntToFormat((long) FactorB);
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13509U));
        break;
      case 7:
        CStr.IntToFormat((long) FactorA);
        CStr.IntToFormat((long) FactorB);
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13510U));
        break;
      case 8:
        if (FactorA == (ushort) 0)
        {
          CStr.Append(instance.mStringTable.GetStringByID(13531U));
          break;
        }
        CStr.IntToFormat((long) FactorA);
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13511U));
        break;
      case 9:
        CStr.IntToFormat((long) FactorA);
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13512U));
        break;
      case 10:
        Hero recordByKey2 = instance.HeroTable.GetRecordByKey(FactorA);
        CStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey2.HeroTitle));
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13513U));
        break;
      case 11:
        if (FactorA < (ushort) 1 || FactorA > (ushort) 3 || FactorB < (ushort) 1 || FactorB > (ushort) 20)
          return false;
        Level bycurrentPointId1 = this.GetLevelBycurrentPointID((ushort) 0);
        HeroTeam recordByKey3 = instance.TeamTable.GetRecordByKey(bycurrentPointId1.Team[(int) FactorA - 1]);
        Hero recordByKey4 = instance.HeroTable.GetRecordByKey(recordByKey3.Arrays[(int) FactorB - 1].Hero);
        CStr.IntToFormat((long) FactorA);
        CStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey4.HeroTitle));
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13514U));
        break;
      case 12:
        if (FactorA < (ushort) 1 || FactorA > (ushort) 3 || FactorB < (ushort) 1 || FactorB > (ushort) 20)
          return false;
        Level bycurrentPointId2 = this.GetLevelBycurrentPointID((ushort) 0);
        HeroTeam recordByKey5 = instance.TeamTable.GetRecordByKey(bycurrentPointId2.Team[(int) FactorA - 1]);
        Hero recordByKey6 = instance.HeroTable.GetRecordByKey(recordByKey5.Arrays[(int) FactorB - 1].Hero);
        CStr.IntToFormat((long) FactorA);
        CStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey6.HeroTitle));
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13515U));
        break;
      case 13:
        CStr.IntToFormat((long) FactorA);
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13518U));
        break;
      case 14:
        CStr.IntToFormat((long) FactorA);
        CStr.IntToFormat((long) FactorB);
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13519U));
        break;
      case 15:
        switch (FactorA)
        {
          case 1:
            CStr.StringToFormat(instance.mStringTable.GetStringByID(13533U));
            break;
          case 2:
            CStr.StringToFormat(instance.mStringTable.GetStringByID(13534U));
            break;
          case 3:
            CStr.StringToFormat(instance.mStringTable.GetStringByID(13535U));
            break;
          case 4:
            CStr.StringToFormat(instance.mStringTable.GetStringByID(13536U));
            break;
          case 5:
            CStr.StringToFormat(instance.mStringTable.GetStringByID(13537U));
            break;
          default:
            CStr.StringToFormat(instance.mStringTable.GetStringByID(13533U));
            break;
        }
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13507U));
        break;
      case 16:
        CStr.Append(instance.mStringTable.GetStringByID(13508U));
        break;
      case 17:
        if (FactorA == (ushort) 0)
        {
          if (FactorB == (ushort) 1)
            CStr.StringToFormat(instance.mStringTable.GetStringByID(13517U));
          else
            CStr.StringToFormat(instance.mStringTable.GetStringByID(13519U + (uint) FactorB));
          CStr.AppendFormat(instance.mStringTable.GetStringByID(12503U));
          break;
        }
        CStr.IntToFormat((long) FactorA);
        if (FactorB == (ushort) 1)
          CStr.StringToFormat(instance.mStringTable.GetStringByID(13517U));
        else
          CStr.StringToFormat(instance.mStringTable.GetStringByID(13519U + (uint) FactorB));
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13532U));
        break;
      case 18:
      case 27:
        ushort factorA1 = DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(ConditionKey).ConditionArray[7].FactorA;
        switch (factorA1)
        {
          case 1:
          case 2:
          case 3:
            if (FactorA >= (ushort) 1 && FactorA <= (ushort) 20)
            {
              Level bycurrentPointId3 = this.GetLevelBycurrentPointID((ushort) 0);
              HeroTeam recordByKey7 = instance.TeamTable.GetRecordByKey(bycurrentPointId3.Team[(int) factorA1 - 1]);
              Hero recordByKey8 = instance.HeroTable.GetRecordByKey(recordByKey7.Arrays[(int) FactorA - 1].Hero);
              CStr.IntToFormat((long) factorA1);
              CStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey8.HeroTitle));
              if (FactorB == (ushort) 1)
                CStr.StringToFormat(instance.mStringTable.GetStringByID(13517U));
              else
                CStr.StringToFormat(instance.mStringTable.GetStringByID(13519U + (uint) FactorB));
              switch (ConditionID)
              {
                case 18:
                  CStr.AppendFormat(instance.mStringTable.GetStringByID(12504U));
                  goto label_85;
                case 27:
                  CStr.AppendFormat(instance.mStringTable.GetStringByID(12520U));
                  goto label_85;
                default:
                  goto label_85;
              }
            }
            else
              break;
        }
        return false;
      case 19:
        CStr.StringToFormat(instance.mStringTable.GetStringByID(12700U + (uint) FactorA));
        CStr.AppendFormat(instance.mStringTable.GetStringByID(12505U));
        break;
      case 20:
        CStr.IntToFormat((long) FactorA);
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13520U));
        break;
      case 21:
        Hero recordByKey9 = instance.HeroTable.GetRecordByKey(FactorB);
        CStr.IntToFormat((long) FactorA);
        CStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey9.HeroName));
        CStr.AppendFormat(instance.mStringTable.GetStringByID(12507U));
        break;
      case 22:
        if (FactorA == (ushort) 0)
        {
          Skill recordByKey10 = DataManager.Instance.SkillTable.GetRecordByKey(FactorB);
          CStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey10.Describe));
          CStr.AppendFormat(instance.mStringTable.GetStringByID(12503U));
          break;
        }
        CStr.IntToFormat((long) FactorA);
        Skill recordByKey11 = DataManager.Instance.SkillTable.GetRecordByKey(FactorB);
        CStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey11.Describe));
        CStr.AppendFormat(instance.mStringTable.GetStringByID(13532U));
        break;
      case 23:
        ushort factorA2 = DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(ConditionKey).ConditionArray[7].FactorA;
        switch (factorA2)
        {
          case 1:
          case 2:
          case 3:
            if (FactorA >= (ushort) 1 && FactorA <= (ushort) 20)
            {
              Level bycurrentPointId4 = this.GetLevelBycurrentPointID((ushort) 0);
              HeroTeam recordByKey12 = instance.TeamTable.GetRecordByKey(bycurrentPointId4.Team[(int) factorA2 - 1]);
              Hero recordByKey13 = instance.HeroTable.GetRecordByKey(recordByKey12.Arrays[(int) FactorA - 1].Hero);
              CStr.IntToFormat((long) factorA2);
              CStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey13.HeroTitle));
              CStr.IntToFormat((long) FactorB);
              CStr.AppendFormat(instance.mStringTable.GetStringByID(12510U));
              goto label_85;
            }
            else
              break;
        }
        return false;
      case 24:
        if (FactorA == (ushort) 0)
        {
          switch (FactorB)
          {
            case 0:
              CStr.Append(instance.mStringTable.GetStringByID(12512U));
              break;
            case 1:
              CStr.Append(instance.mStringTable.GetStringByID(12514U));
              break;
            case 2:
              CStr.Append(instance.mStringTable.GetStringByID(12516U));
              break;
          }
        }
        else
        {
          CStr.IntToFormat((long) FactorA);
          switch (FactorB)
          {
            case 0:
              CStr.AppendFormat(instance.mStringTable.GetStringByID(12513U));
              break;
            case 1:
              CStr.AppendFormat(instance.mStringTable.GetStringByID(12515U));
              break;
            case 2:
              CStr.AppendFormat(instance.mStringTable.GetStringByID(12517U));
              break;
          }
        }
        break;
      case 25:
        Hero recordByKey14 = instance.HeroTable.GetRecordByKey(FactorB);
        CStr.IntToFormat((long) FactorA);
        CStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey14.HeroName));
        CStr.AppendFormat(instance.mStringTable.GetStringByID(12518U));
        break;
      case 26:
        Hero recordByKey15 = instance.HeroTable.GetRecordByKey(FactorB);
        CStr.IntToFormat((long) FactorA);
        CStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey15.HeroName));
        CStr.AppendFormat(instance.mStringTable.GetStringByID(12519U));
        break;
      case 28:
        ushort factorA3 = DataManager.StageDataController.StageConditionDataTable.GetRecordByKey(ConditionKey).ConditionArray[7].FactorA;
        switch (factorA3)
        {
          case 1:
          case 2:
          case 3:
            if (FactorA >= (ushort) 1 && FactorA <= (ushort) 20)
            {
              Level bycurrentPointId5 = this.GetLevelBycurrentPointID((ushort) 0);
              HeroTeam recordByKey16 = instance.TeamTable.GetRecordByKey(bycurrentPointId5.Team[(int) factorA3 - 1]);
              Hero recordByKey17 = instance.HeroTable.GetRecordByKey(recordByKey16.Arrays[(int) FactorA - 1].Hero);
              CStr.IntToFormat((long) factorA3);
              CStr.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey17.HeroTitle));
              if (FactorB != (ushort) 0)
              {
                CStr.IntToFormat((long) FactorB);
                CStr.AppendFormat(instance.mStringTable.GetStringByID(12522U));
                goto label_85;
              }
              else
              {
                CStr.AppendFormat(instance.mStringTable.GetStringByID(12521U));
                goto label_85;
              }
            }
            else
              break;
        }
        return false;
      case 29:
        Skill recordByKey18 = DataManager.Instance.SkillTable.GetRecordByKey(FactorB);
        CStr.Append(instance.mStringTable.GetStringByID((uint) recordByKey18.Describe));
        break;
      case byte.MaxValue:
        CStr.Append(instance.mStringTable.GetStringByID(13516U));
        break;
      default:
        stageConditionString = false;
        break;
    }
label_85:
    return stageConditionString;
  }

  public Sprite GetStageConditionSprite(byte ConditionID, ushort FactorA = 0, ushort FactorB = 0)
  {
    StageConditionInfo recordByKey1 = this.StageConditionInfoTable.GetRecordByKey((ushort) ConditionID);
    if ((int) recordByKey1.ConditionID != (int) ConditionID)
      recordByKey1 = this.StageConditionInfoTable.GetRecordByKey((ushort) byte.MaxValue);
    GUIManager instance = GUIManager.Instance;
    if (recordByKey1.PicType == (byte) 0)
      return instance.m_ConditiontIconSpriteAsset.LoadSprite((ushort) recordByKey1.PicNo);
    if (recordByKey1.PicType == (byte) 1)
    {
      Hero recordByKey2 = DataManager.Instance.HeroTable.GetRecordByKey(FactorA);
      return instance.m_IconSpriteAsset.LoadSprite(recordByKey2.Graph);
    }
    if (recordByKey1.PicType != (byte) 2)
      return instance.m_ConditiontIconSpriteAsset.LoadSprite((ushort) 1);
    Hero recordByKey3 = DataManager.Instance.HeroTable.GetRecordByKey(FactorB);
    return instance.m_IconSpriteAsset.LoadSprite(recordByKey3.Graph);
  }

  public Material GetStageConditionMaterial(byte ConditionID)
  {
    StageConditionInfo recordByKey = this.StageConditionInfoTable.GetRecordByKey((ushort) ConditionID);
    if ((int) recordByKey.ConditionID != (int) ConditionID)
      recordByKey = this.StageConditionInfoTable.GetRecordByKey((ushort) byte.MaxValue);
    return recordByKey.PicType == (byte) 1 || recordByKey.PicType == (byte) 2 ? GUIManager.Instance.m_IconSpriteAsset.GetMaterial() : GUIManager.Instance.m_ConditiontIconSpriteAsset.GetMaterial();
  }

  public void GetUserStage(StageMode getStageMode)
  {
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.uLongToFormat((ulong) DataManager.Instance.RoleAttr.UserId);
    cstring.IntToFormat((long) getStageMode);
    cstring.AppendFormat("{0}_{1}_currentPointID");
    this.inoutPointID[(int) getStageMode] = (ushort) PlayerPrefs.GetInt(cstring.ToString());
    if ((int) this.inoutPointID[(int) getStageMode] > (int) this.StageRecord[(int) getStageMode] + 1)
      this.inoutPointID[(int) getStageMode] = (ushort) ((uint) this.StageRecord[(int) getStageMode] + 1U);
    if ((int) this.inoutPointID[(int) getStageMode] <= (int) this.limitRecord[(int) getStageMode])
      return;
    this.inoutPointID[(int) getStageMode] = this.StageRecord[(int) getStageMode];
  }

  public void SaveUserStage(StageMode saveStageMode)
  {
    if (saveStageMode != this._stageMode || (int) this.inoutPointID[(int) saveStageMode] == (int) this.currentPointID)
      return;
    this.inoutPointID[(int) saveStageMode] = this.currentPointID;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.uLongToFormat((ulong) DataManager.Instance.RoleAttr.UserId);
    cstring.IntToFormat((long) saveStageMode);
    cstring.AppendFormat("{0}_{1}_currentPointID");
    PlayerPrefs.SetInt(cstring.ToString(), (int) this.inoutPointID[(int) saveStageMode]);
  }

  public void SaveUserStageMode(StageMode saveStageMode)
  {
    if (saveStageMode == this.inoutStageMode)
      return;
    this.inoutStageMode = saveStageMode;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.uLongToFormat((ulong) DataManager.Instance.RoleAttr.UserId);
    cstring.AppendFormat("{0}_currentStageMode");
    PlayerPrefs.SetInt(cstring.ToString(), (int) this.inoutStageMode);
  }
}
