// Decompiled with JetBrains decompiler
// Type: AttribValManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
public class AttribValManager
{
  private uint[][] UpdateBaseVal;
  private bool[] bUpdate;
  private uint[] TotalBaseVal;
  private uint[] TalentBaseVa;
  private uint[] LordEquipBaseVa;
  private uint[] LordBaseVal;
  private bool bUpdateTalentVal;
  private bool bUpdateLordEquipVal;
  private bool bUpdateJailVal;
  private byte HeroNum;
  private byte BuffNum;
  private CalcHeroDataType[] calcHeroData;
  private ushort[] BuffItem;
  private uint[] OuterSoldier = new uint[8];
  public uint TotalOuterSoldier;
  public uint TotalDugoutSoldier;
  private uint[] OuterSoldierConsume = new uint[8];
  private ulong TotalOuterSoldierConsume;
  private ulong[] InnerSoldierConsume = new ulong[16];
  private ulong TotalInnerSoldierConsume;
  private ulong TotalHideSoldierConsume;
  private uint JailAddTroopAtk;

  public AttribValManager()
  {
    ushort length = 179;
    this.UpdateBaseVal = new uint[8][];
    for (int index = 0; index < this.UpdateBaseVal.Length; ++index)
      this.UpdateBaseVal[index] = new uint[(int) length];
    this.bUpdate = new bool[8];
    this.TotalBaseVal = new uint[(int) length];
    this.TalentBaseVa = new uint[(int) length];
    this.LordEquipBaseVa = new uint[(int) length];
    this.LordBaseVal = new uint[(int) length];
    this.calcHeroData = new CalcHeroDataType[100];
  }

  public ulong TotalSoldierConsume
  {
    get
    {
      ulong effectBaseVal = (ulong) this.GetEffectBaseVal(GATTR_ENUM.EGA_UPKEEP_REDUCTION);
      return (this.TotalOuterSoldierConsume + this.TotalInnerSoldierConsume + this.TotalHideSoldierConsume) * (effectBaseVal <= 10000UL ? 10000UL - effectBaseVal : 0UL) / 10000UL;
    }
  }

  public uint[] BaseVal_Total => this.TotalBaseVal;

  public void ResetAllVal()
  {
    GameConstants.ArrayFill<bool>(this.bUpdate, true);
    this.bUpdateTalentVal = true;
    this.bUpdateLordEquipVal = true;
  }

  public void GetWallValue()
  {
    uint effectBaseVal = this.GetEffectBaseVal(GATTR_ENUM.EGA_WALL_HEALTH);
    uint num = effectBaseVal - DataManager.Instance.m_WallRepairMaxValue;
    DataManager.Instance.m_WallRepairMaxValue = effectBaseVal;
    DataManager.Instance.m_WallRepairNowValue += num;
    DataManager.Instance.bNeedShowWallQueueBar = true;
  }

  public void UpdateTalentData()
  {
    this.bUpdateTalentVal = true;
    GameManager.OnRefresh(NetworkNews.Refresh_AttribEffectVal);
    this.UpdateResourceMission();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
  }

  public void UpdateLordEquipData()
  {
    this.bUpdateLordEquipVal = true;
    GameManager.OnRefresh(NetworkNews.Refresh_AttribEffectVal);
    this.UpdateResourceMission();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
  }

  public void UpdateJailData()
  {
    if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 18, (ushort) 0).Level != (byte) 25)
      return;
    this.bUpdateJailVal = true;
    GameManager.OnRefresh(NetworkNews.Refresh_AttribEffectVal);
  }

  public void UpdateAttrVal(UpdateAttrKind Kind)
  {
    this.bUpdate[(int) (byte) Kind] = true;
    if (Kind == UpdateAttrKind.Build)
      this.bUpdate[6] = true;
    if (Kind == UpdateAttrKind.Hero)
      DataManager.MissionDataManager.SetCompleteWhileLogin(eMissionKind.Record);
    if (Kind == UpdateAttrKind.Build || Kind == UpdateAttrKind.Technoolgy || Kind == UpdateAttrKind.Wonder || Kind == UpdateAttrKind.Pet)
    {
      for (int index = 0; index < DataManager.Instance.Resource.Length; ++index)
        DataManager.Instance.Resource[index].UpdateCapacity();
      DataManager.Instance.PetResource.UpdateCapacity();
    }
    DataManager.Instance.MaxMarchEventNum = (byte) this.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
    GameManager.OnRefresh(NetworkNews.Refresh_AttribEffectVal);
    this.UpdateResourceMission();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 15);
    if (Kind != UpdateAttrKind.Build)
      return;
    PetManager.Instance.SetTrainingCenterNum();
  }

  private void UpdateResourceMission()
  {
    for (ResourceType Type = ResourceType.Grain; Type < ResourceType.MAX; ++Type)
    {
      long num = DataManager.MissionDataManager.UpdateResourceInfo(Type);
      if (num > 0L)
        DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) ((byte) 1 + Type), num >= (long) ushort.MaxValue ? ushort.MaxValue : (ushort) num);
    }
  }

  public void UpdateHeroCalData()
  {
    DataManager instance = DataManager.Instance;
    Array.Clear((Array) this.calcHeroData, 0, this.calcHeroData.Length);
    this.HeroNum = (byte) 0;
    for (int index = 0; index < instance.curHeroData.Keys.Length; ++index)
    {
      if (instance.curHeroData.Keys[index] != 0U)
      {
        CurHeroData curHeroData = instance.curHeroData[instance.curHeroData.Keys[index]];
        this.calcHeroData[(int) this.HeroNum].HeroID = curHeroData.ID;
        this.calcHeroData[(int) this.HeroNum].Rank = curHeroData.Enhance;
        this.calcHeroData[(int) this.HeroNum].Star = curHeroData.Star;
        ++this.HeroNum;
      }
    }
    DataManager.MissionDataManager.SetCompleteWhileLogin(eMissionKind.Record);
  }

  public void UpdateBuffData()
  {
    DataManager instance = DataManager.Instance;
    if (this.BuffItem == null)
      this.BuffItem = new ushort[instance.MaxBuffTableCount];
    Array.Clear((Array) this.BuffItem, 0, this.BuffItem.Length);
    this.BuffNum = (byte) 0;
    for (int index = 0; index < instance.MaxBuffTableCount; ++index)
    {
      if (instance.m_RecvItemBuffData[index].bEnable)
        this.BuffItem[(int) this.BuffNum++] = instance.m_RecvItemBuffData[index].ItemID;
    }
  }

  public uint GetEffectBaseVal(GATTR_ENUM Type)
  {
    bool flag = false;
    for (int index = 0; index < this.bUpdate.Length; ++index)
    {
      if (this.bUpdate[index])
      {
        switch (index)
        {
          case 0:
            BSInvokeUtil.getInstance.updateBuildEffectval(this.UpdateBaseVal[index]);
            break;
          case 1:
            BSInvokeUtil.getInstance.updateTechnlolgyEffectval(this.UpdateBaseVal[index]);
            break;
          case 2:
            this.UpdateHeroCalData();
            BSInvokeUtil.getInstance.updateHeroEffectval(this.HeroNum, this.calcHeroData, this.UpdateBaseVal[index]);
            break;
          case 3:
            this.UpdateBuffData();
            BSInvokeUtil.getInstance.updateBuffBonus(this.BuffNum, this.BuffItem, this.UpdateBaseVal[index]);
            break;
          case 4:
            BSInvokeUtil.getInstance.updateVIPBonus(this.UpdateBaseVal[index]);
            break;
          case 5:
            BSInvokeUtil.getInstance.updateWonderBonus(this.UpdateBaseVal[index]);
            break;
          case 6:
            BSInvokeUtil.getInstance.updateCastleSkinBonus(this.UpdateBaseVal[index]);
            break;
          case 7:
            BSInvokeUtil.getInstance.updatePetAttribBonum(this.UpdateBaseVal[index]);
            break;
        }
        this.bUpdate[index] = false;
        flag = true;
      }
    }
    if (this.bUpdateLordEquipVal)
    {
      BSInvokeUtil.getInstance.updateLordBonus(this.LordEquipBaseVa);
      flag = true;
    }
    this.bUpdateLordEquipVal = false;
    if (this.bUpdateTalentVal)
    {
      BSInvokeUtil.getInstance.updateTalentval(this.TalentBaseVa);
      flag = true;
    }
    this.bUpdateTalentVal = false;
    DataManager instance = DataManager.Instance;
    if (this.bUpdateJailVal)
    {
      this.JailAddTroopAtk = instance.PrisonerHighestLevel == (byte) 0 ? 0U : (uint) instance.LevelUpTable.GetRecordByKey((ushort) instance.PrisonerHighestLevel).PrisonEffect;
      flag = true;
    }
    this.bUpdateJailVal = false;
    if (flag)
    {
      Array.Clear((Array) this.TotalBaseVal, 0, this.TotalBaseVal.Length);
      for (int index1 = 0; index1 < this.TotalBaseVal.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.UpdateBaseVal.Length; ++index2)
          this.TotalBaseVal[index1] += this.UpdateBaseVal[index2][index1];
      }
      Array.Clear((Array) this.LordBaseVal, 0, this.LordBaseVal.Length);
      if (instance.beCaptured.nowCaptureStat == LoadCaptureState.None || instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
      {
        for (int index = 0; index < this.LordBaseVal.Length; ++index)
          this.LordBaseVal[index] = this.TalentBaseVa[index] + this.LordEquipBaseVa[index];
      }
      this.TotalBaseVal[15] += this.JailAddTroopAtk;
    }
    if (Type == GATTR_ENUM.EGA_WALL_DEFENCE_ADD && instance.beCaptured.nowCaptureStat != LoadCaptureState.None && instance.beCaptured.nowCaptureStat != LoadCaptureState.Returning)
      return 0;
    return instance.beCaptured.nowCaptureStat == LoadCaptureState.None || instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning ? this.TotalBaseVal[(int) Type] + this.TalentBaseVa[(int) Type] + this.LordEquipBaseVa[(int) Type] : this.TotalBaseVal[(int) Type];
  }

  public void UpdateSoldierConsume(SoldierConsumeType Type, byte Index = 255)
  {
    DataManager instance = DataManager.Instance;
    MissionManager missionDataManager = DataManager.MissionDataManager;
    switch (Type)
    {
      case SoldierConsumeType.Inner:
        if (Index == byte.MaxValue)
        {
          int length = instance.RoleAttr.m_Soldier.Length;
          Array.Clear((Array) this.InnerSoldierConsume, 0, this.InnerSoldierConsume.Length);
          this.TotalInnerSoldierConsume = 0UL;
          for (ushort index = 0; (int) index < length; ++index)
          {
            ushort InKey = (ushort) ((uint) index + 1U);
            int salaries = (int) instance.SoldierDataTable.GetRecordByKey(InKey).Salaries;
            this.InnerSoldierConsume[(int) index] = (ulong) instance.RoleAttr.m_Soldier[(int) index] * (ulong) salaries;
            this.TotalInnerSoldierConsume += this.InnerSoldierConsume[(int) index];
          }
          break;
        }
        long num1 = (long) this.InnerSoldierConsume[(int) Index];
        ushort num2 = (ushort) ((uint) Index + 1U);
        this.TotalInnerSoldierConsume -= this.InnerSoldierConsume[(int) Index];
        int salaries1 = (int) instance.SoldierDataTable.GetRecordByKey(num2).Salaries;
        this.InnerSoldierConsume[(int) Index] = (ulong) instance.RoleAttr.m_Soldier[(int) Index] * (ulong) salaries1;
        this.TotalInnerSoldierConsume += this.InnerSoldierConsume[(int) Index];
        long num3 = (long) this.InnerSoldierConsume[(int) Index] - num1;
        if (num3 > 0L)
        {
          long Val = num3 / (long) salaries1;
          missionDataManager.CheckChanged(eMissionKind.Army, num2, (ushort) Val);
          break;
        }
        break;
      case SoldierConsumeType.Outer:
        if (Index == byte.MaxValue)
        {
          uint effectBaseVal = this.GetEffectBaseVal(GATTR_ENUM.EGA_MARCH_NUM);
          Array.Clear((Array) this.OuterSoldierConsume, 0, this.OuterSoldierConsume.Length);
          Array.Clear((Array) this.OuterSoldier, 0, this.OuterSoldier.Length);
          this.TotalOuterSoldierConsume = 0UL;
          this.TotalOuterSoldier = 0U;
          for (int index1 = 0; (long) index1 < (long) effectBaseVal; ++index1)
          {
            for (int index2 = 0; index2 < 4; ++index2)
            {
              for (int index3 = 0; index3 < 4; ++index3)
              {
                ushort InKey = (ushort) (index2 * 4 + index3 + 1);
                int salaries2 = (int) instance.SoldierDataTable.GetRecordByKey(InKey).Salaries;
                this.OuterSoldierConsume[index1] += (uint) ((ulong) instance.MarchEventData[index1].TroopData[index2][index3] * (ulong) salaries2);
                this.OuterSoldier[index1] += instance.MarchEventData[index1].TroopData[index2][index3];
              }
            }
            this.TotalOuterSoldierConsume += (ulong) this.OuterSoldierConsume[index1];
            this.TotalOuterSoldier += this.OuterSoldier[index1];
          }
          break;
        }
        this.TotalOuterSoldierConsume -= (ulong) this.OuterSoldierConsume[(int) Index];
        this.TotalOuterSoldier -= this.OuterSoldier[(int) Index];
        this.OuterSoldierConsume[(int) Index] = 0U;
        this.OuterSoldier[(int) Index] = 0U;
        for (int index4 = 0; index4 < 4; ++index4)
        {
          for (int index5 = 0; index5 < 4; ++index5)
          {
            ushort InKey = (ushort) (index4 * 4 + index5 + 1);
            int salaries3 = (int) instance.SoldierDataTable.GetRecordByKey(InKey).Salaries;
            this.OuterSoldierConsume[(int) Index] += (uint) ((ulong) instance.MarchEventData[(int) Index].TroopData[index4][index5] * (ulong) salaries3);
            this.OuterSoldier[(int) Index] += instance.MarchEventData[(int) Index].TroopData[index4][index5];
          }
        }
        this.TotalOuterSoldierConsume += (ulong) this.OuterSoldierConsume[(int) Index];
        this.TotalOuterSoldier += this.OuterSoldier[(int) Index];
        break;
      case SoldierConsumeType.Hide:
        this.TotalDugoutSoldier = 0U;
        this.TotalHideSoldierConsume = 0UL;
        if (Index != (byte) 0)
        {
          uint[] hideTroopData = HideArmyManager.Instance.GetHideTroopData();
          for (int index = 0; index < hideTroopData.Length; ++index)
          {
            ushort InKey = (ushort) (index + 1);
            int salaries4 = (int) instance.SoldierDataTable.GetRecordByKey(InKey).Salaries;
            this.TotalHideSoldierConsume += (ulong) hideTroopData[index] * (ulong) salaries4;
            this.TotalDugoutSoldier += hideTroopData[index];
          }
          break;
        }
        break;
    }
    GameManager.OnRefresh(NetworkNews.Refresh_AttribEffectVal);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public uint[] GetLordBaseVal()
  {
    bool flag = false;
    if (this.bUpdateLordEquipVal)
    {
      BSInvokeUtil.getInstance.updateLordBonus(this.LordEquipBaseVa);
      this.bUpdateLordEquipVal = false;
      flag = true;
    }
    if (this.bUpdateTalentVal)
    {
      BSInvokeUtil.getInstance.updateTalentval(this.TalentBaseVa);
      this.bUpdateTalentVal = false;
      flag = true;
    }
    if (flag)
    {
      Array.Clear((Array) this.LordBaseVal, 0, this.LordBaseVal.Length);
      if (DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.None || DataManager.Instance.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
      {
        for (int index = 0; index < this.LordBaseVal.Length; ++index)
          this.LordBaseVal[index] = this.TalentBaseVa[index] + this.LordEquipBaseVa[index];
      }
    }
    return this.LordBaseVal;
  }

  public uint GetEffectBaseValByEffectID(ushort effectID)
  {
    return effectID > (ushort) 200 && effectID < (ushort) 380 ? this.GetEffectBaseVal((GATTR_ENUM) ((uint) effectID - 201U)) : 0U;
  }

  public uint GetEffectBaseValDueLord(ushort effectID, bool isLordCount)
  {
    if (!GameConstants.IsBetween((int) effectID, 201, 399))
      return 0;
    effectID -= (ushort) 201;
    if ((int) effectID > this.TotalBaseVal.Length)
      return 0;
    return isLordCount ? this.TotalBaseVal[(int) effectID] + this.TalentBaseVa[(int) effectID] + this.LordEquipBaseVa[(int) effectID] : this.TotalBaseVal[(int) effectID];
  }
}
