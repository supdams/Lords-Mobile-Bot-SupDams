// Decompiled with JetBrains decompiler
// Type: ActivityDataType
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;

#nullable disable
public class ActivityDataType
{
  public EActivityType ActiveType;
  public EKVKActivityType KVKActiveType;
  public bool bAskDetailData;
  public bool bAskRankPrize;
  public EActivityState EventState;
  public long EventBeginTime;
  public uint EventReqiureTIme;
  public ulong EventScore;
  public byte EventRank;
  public long EventCountTime;
  public ushort EventPrizeID;
  public ushort EventPrizeID2;
  public ushort EventPrizeID3;
  public ushort Name;
  public ushort Pic;
  public ushort PicStr;
  public ushort DetailContentStrID;
  public uint[] RequireScore = new uint[3];
  public ActivityPrizeWorthDataType EventAllDegreePrizeWorthData = new ActivityPrizeWorthDataType();
  public ActGetScoreFactorDataType[] GetScoreFactor = new ActGetScoreFactorDataType[6];
  public ActivityPrizeWorthDataType[] EventPrizeWorthData = new ActivityPrizeWorthDataType[3];
  public byte[] DataLen = new byte[3];
  public ActPrizeDataType[] DegreePrize = new ActPrizeDataType[60];
  public ActivityPrizeWorthDataType[] RankPrizeWorthData = new ActivityPrizeWorthDataType[7];
  public byte[] RankingPrizeDataLen = new byte[7];
  public ActPrizeDataType[] RankingPrize = new ActPrizeDataType[140];
  public byte SpDegreePrizeFlag;
  public EActEventBonusType EventBonusType;
  public byte GroupCount;
  public NobilityGroupDataType[] NobilityGroupData;
  public byte[] NobilityGroupDataIndex;
  public List<byte> NobilityGroupDataSortIndex;

  public void Initial()
  {
    this.ActiveType = EActivityType.EAT_MAX;
    this.KVKActiveType = EKVKActivityType.EKAT_MAX;
    this.bAskDetailData = false;
    this.bAskRankPrize = false;
    this.EventState = EActivityState.EAS_None;
    this.EventBeginTime = 0L;
    this.EventReqiureTIme = 0U;
    this.EventScore = 0UL;
    this.EventRank = (byte) 0;
    this.EventCountTime = 0L;
    this.EventPrizeID = (ushort) 0;
    this.EventPrizeID2 = (ushort) 0;
    this.EventPrizeID3 = (ushort) 0;
    this.Name = (ushort) 0;
    this.Pic = (ushort) 0;
    this.PicStr = (ushort) 0;
    this.DetailContentStrID = (ushort) 0;
    Array.Clear((Array) this.RequireScore, 0, this.RequireScore.Length);
    this.EventAllDegreePrizeWorthData.CrystalPrice = 0U;
    this.EventAllDegreePrizeWorthData.Crystal = 0U;
    this.EventAllDegreePrizeWorthData.Priceless = (ushort) 0;
    for (int index = 0; index < this.GetScoreFactor.Length; ++index)
    {
      this.GetScoreFactor[index].Factor = EGetScoreFactor.EGSF_MAX;
      this.GetScoreFactor[index].BonusRate = (byte) 0;
    }
    Array.Clear((Array) this.EventPrizeWorthData, 0, this.EventPrizeWorthData.Length);
    Array.Clear((Array) this.DataLen, 0, this.DataLen.Length);
    Array.Clear((Array) this.DegreePrize, 0, this.DegreePrize.Length);
    this.SpDegreePrizeFlag = (byte) 0;
    this.EventBonusType = EActEventBonusType.EAEBT_None;
  }

  public bool CheckPrizeFlag(byte bit) => ((int) this.SpDegreePrizeFlag & 1 << (int) bit) != 0;

  public bool CheckBonusType(ushort ItemID)
  {
    if (this.EventBonusType == EActEventBonusType.EAEBT_None || this.EventBonusType == EActEventBonusType.EAEBT_RequireScoreDown)
      return false;
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(ItemID);
    if ((int) recordByKey.EquipKey != (int) ItemID)
      return false;
    switch (this.EventBonusType)
    {
      case EActEventBonusType.EAEBT_Crystal:
        if (recordByKey.EquipKind == (byte) 11 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 6)
          return true;
        break;
      case EActEventBonusType.EAEBT_SpeedUpItem:
        if (recordByKey.EquipKind == (byte) 12 && (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 1 || recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 12 || recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 17 || recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 18 || recordByKey.PropertiesInfo[0].Propertieskey >= (ushort) 21 && recordByKey.PropertiesInfo[0].Propertieskey <= (ushort) 30))
          return true;
        break;
      case EActEventBonusType.EAEBT_MatLotteryBox:
        if (recordByKey.EquipKind == (byte) 18 && recordByKey.PropertiesInfo[3].Propertieskey == (ushort) 1)
          return true;
        break;
      case EActEventBonusType.EAEBT_Gold:
        if (recordByKey.EquipKind == (byte) 11 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 5)
          return true;
        break;
    }
    return false;
  }

  public void InitialNobility()
  {
    if (this.NobilityGroupData != null)
    {
      for (int index = 0; index < this.NobilityGroupData.Length; ++index)
      {
        StringManager.Instance.DeSpawnString(this.NobilityGroupData[index].NobilityName);
        StringManager.Instance.DeSpawnString(this.NobilityGroupData[index].EventTimeStr);
      }
    }
    this.GroupCount = (byte) 0;
    this.NobilityGroupData = (NobilityGroupDataType[]) null;
    this.NobilityGroupDataIndex = new byte[256];
    if (this.NobilityGroupDataSortIndex == null)
      this.NobilityGroupDataSortIndex = new List<byte>();
    else
      this.NobilityGroupDataSortIndex.Clear();
  }

  public void InitGroupData(byte Count)
  {
    this.GroupCount = Count;
    this.NobilityGroupData = new NobilityGroupDataType[(int) Count];
    this.NobilityGroupDataSortIndex.Clear();
    for (int index1 = 0; index1 < this.NobilityGroupData.Length; ++index1)
    {
      this.NobilityGroupData[index1].KingdomID = (ushort) 0;
      this.NobilityGroupData[index1].WonderID = (byte) 0;
      this.NobilityGroupData[index1].EventState = EActivityState.EAS_None;
      this.NobilityGroupData[index1].EventBeginTime = 0L;
      this.NobilityGroupData[index1].EventRequireTime = 0U;
      this.NobilityGroupData[index1].EventCountTime = 0L;
      this.NobilityGroupData[index1].FightKingdomCount = (byte) 0;
      this.NobilityGroupData[index1].FightKingdomID = (ushort[]) null;
      this.NobilityGroupData[index1].NobilityKingdomID = (ushort) 0;
      this.NobilityGroupData[index1].NobilityHeroID = (ushort) 0;
      this.NobilityGroupData[index1].bAskPrizeData = false;
      this.NobilityGroupData[index1].bAskKingdomData = false;
      this.NobilityGroupData[index1].bAskNobilityData = false;
      this.NobilityGroupData[index1].PreparePrize = new ActPrizeDataType[3][];
      for (int index2 = 0; index2 < 3; ++index2)
        this.NobilityGroupData[index1].PreparePrize[index2] = new ActPrizeDataType[3];
      this.NobilityGroupData[index1].NobilityName = StringManager.Instance.SpawnString();
      this.NobilityGroupData[index1].EventTimeStr = StringManager.Instance.SpawnString();
      this.NobilityGroupDataSortIndex.Add((byte) index1);
    }
  }

  public void SetGroupEventTime()
  {
    for (int index = 0; index < this.NobilityGroupData.Length; ++index)
    {
      DateTime dateTime1 = GameConstants.GetDateTime(this.NobilityGroupData[index].EventBeginTime);
      DateTime dateTime2 = GameConstants.GetDateTime(this.NobilityGroupData[index].EventBeginTime + (long) this.NobilityGroupData[index].EventRequireTime);
      this.NobilityGroupData[index].EventTimeStr.Length = 0;
      this.NobilityGroupData[index].EventTimeStr.StringToFormat(dateTime1.ToString("MM/dd/yy HH:mm"));
      this.NobilityGroupData[index].EventTimeStr.StringToFormat(dateTime2.ToString("HH:mm"));
      this.NobilityGroupData[index].EventTimeStr.AppendFormat("{0}~{1}");
    }
  }
}
