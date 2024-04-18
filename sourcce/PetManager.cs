// Decompiled with JetBrains decompiler
// Type: PetManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

#nullable disable
public class PetManager
{
  public const byte MAX_PET_LEVEL = 60;
  public const byte MAX_PET_SKILL = 4;
  public const ushort MaxPetItemCount = 200;
  private const int MaxCoachCount = 100;
  private const int MaxTrainingCount = 8;
  public const byte MAX_PET_RARITY = 5;
  private static PetManager instance;
  private long LastServerTime;
  public List<byte> sortPetData;
  private List<PetData> CurPetData;
  private List<PetData> PetDataPool;
  private ushort PetPoolDataCountIdx;
  private Dictionary<ushort, byte> PetFinder;
  private PetDataComparer petDataComparer;
  public _CalcPetDataType[] CalcPetDataType;
  public _CalcPetBuffDataType[] CalcPetBuffDataType;
  public PetItem[] PetItemData;
  public ushort[] sortPetItemData;
  private ObjectPool<PetItem> PetItemDataPool;
  public ushort PetItemDataCount;
  private ushort PetMaterialTreasureBox;
  private string PetTrainingListName = "PetTrainingList";
  public PetTraining[] m_PetTrainingData;
  public PetTraining[] m_PetTrainingClinetSave;
  public byte[] m_TrainingHero;
  public List<byte> m_PetTrainginSortData;
  public PetIdleComparer m_PetIdleComparer;
  public byte m_PetBeginLv;
  public byte m_PetEndLv;
  public uint m_BeginExp;
  public uint m_EndExp;
  public ushort m_PetSkillLvUpID;
  public PetManager.EPetTrainDataState m_AllPetTrainState;
  public ObjectPool<UIPetSelect.SScrollData> m_HeroSelectPool;
  public ObjectPool<UIPetSelect.SScrollData> m_PetSelectPool;
  public int m_TrainListIndex;
  public float m_TrainListY;
  public int m_LevelUpIdx;
  public int m_LevelUpSkillIdx;
  public int m_LevelUpStae;
  public byte m_LevelUpLV = 1;
  public uint m_LevelOldExp = 1;
  public uint m_LevelNowExp = 1;
  public ushort m_LevelSkillID;
  public PetMarchEventDataType m_PetMarchEventData;
  public bool bRecvPetMarchFinish;
  public byte BuffInfoLen;
  public PSBuffInfoData[] BuffInfoData;
  public PSBuffInfoTime BuffImmune;
  public List<PSBuffInfoData> BuffInfo;
  public Dictionary<ushort, byte> NegBuff;
  public Dictionary<ushort, byte> PosBuff;
  public byte CoolDownLen;
  public PSCoolDownData[] CoolDownData;
  public List<PSCoolDownData> CoolDown;
  public Dictionary<ushort, long> CDFinder;
  private CString[] HintParm = new CString[7];
  public byte[] UISave = new byte[11];
  private byte PetSortFlag;
  public CExternalTableWithWordKey<PetTbl> PetTable;
  public CExternalTableWithWordKey<PetExpTbl> PetExpTable;
  public CExternalTableWithWordKey<PetSkillTbl> PetSkillTable;
  public CExternalTableWithWordKey<PetSkillExpTbl> PetSkillExpTable;
  public CExternalTableWithWordKey<HeroTrainExpTbl> HeroTrainExpTable;
  public CExternalTableWithWordKey<PetStoneReqTbl> PetStoneReqTable;
  public CExternalTableWithWordKey<PetSkillValTbl> PetSkillValTable;
  public CExternalTableWithWordKey<PetSkillCoolTbl> PetSkillCoolTable;
  public CExternalTableWithWordKey<MapDamageEffTb> MapDamageEffTable;
  private DataManager.eMsgState RecvItemState;
  public int PetUI_PetMaxShowID = -1;
  public int PetUI_PetID = -1;
  public int PetUI_PetSortIndex = -1;
  public ushort PetUI_UseItemPetID;
  public ushort PetUI_EvoID;
  public ushort PetUI_UpNeedStoneCount;
  public uint PetUI_BaseExp;
  public ushort[] PetUI_UpNeedSoulCount = new ushort[5];
  public uint PetUI_OldExp;
  public byte PetUI_OldLV;
  public uint PetUI_GetExp;
  public ushort PetUI_GetRate;
  public ushort ItemCraftID;
  public ushort ItemCraftCount;
  public long ItemCraftBeginTime;
  public uint ItemCraftNeedTime;
  public ushort m_ItemCraftQty;
  public uint m_FusionQty;
  public int Fusion_Lock = 2;
  public long Fusion_SliderValue;
  public int FusionSkill_Lock = 2;
  public long FusionSkill_SliderValue;
  public int mPetSkillItemID = -1;
  public int mPetFusionItemID = -1;
  public float mUIFusion_Y = -1f;
  public int mUIFusion_Idx = -1;
  public bool bCheckLockFusionSkill = true;
  public bool bActFusioncutdown;
  public List<ItemCraftDataType> mItemCraftList = new List<ItemCraftDataType>(200);
  public byte mPetItemNum;
  public byte mPetStoneNum;
  public byte ItemNum;
  public bool IsShowOpen;
  public ItemCrafeComparer mItemCrafeDataComparer = new ItemCrafeComparer();

  private PetManager()
  {
    this.CurPetData = new List<PetData>(16);
    this.sortPetData = new List<byte>(16);
    this.PetDataPool = new List<PetData>(16);
    this.petDataComparer = new PetDataComparer();
    this.PetFinder = new Dictionary<ushort, byte>(16);
    this.CDFinder = new Dictionary<ushort, long>(16);
    this.NegBuff = new Dictionary<ushort, byte>(16);
    this.PosBuff = new Dictionary<ushort, byte>(16);
    this.BuffInfo = new List<PSBuffInfoData>(16);
    this.CoolDown = new List<PSCoolDownData>(16);
    this.PetItemData = new PetItem[200];
    this.sortPetItemData = new ushort[200];
    this.PetItemDataPool = new ObjectPool<PetItem>(new PetItem(), 200);
    for (ushort index = 0; index < (ushort) 200; ++index)
      this.sortPetItemData[(int) index] = index;
    this.CalcPetBuffDataType = new _CalcPetBuffDataType[200];
    this.m_TrainingHero = new byte[256];
    this.m_PetTrainingData = new PetTraining[8];
    for (int index = 0; index < 8; ++index)
      this.m_PetTrainingData[index] = new PetTraining(PetManager.EPetTrainDataState.Closed);
    this.m_PetTrainingClinetSave = new PetTraining[8];
    for (int index = 0; index < 8; ++index)
      this.m_PetTrainingClinetSave[index] = new PetTraining(PetManager.EPetTrainDataState.Closed);
    this.m_PetTrainginSortData = new List<byte>(16);
    this.m_PetIdleComparer = new PetIdleComparer();
    this.LoadTrainingSet();
    this.m_HeroSelectPool = new ObjectPool<UIPetSelect.SScrollData>(new UIPetSelect.SScrollData(), 100);
    this.m_PetSelectPool = new ObjectPool<UIPetSelect.SScrollData>(new UIPetSelect.SScrollData(), 100);
    this.m_TrainListIndex = 0;
    this.m_TrainListY = 0.0f;
    this.m_LevelUpIdx = -1;
    this.m_LevelUpSkillIdx = -1;
    this.m_LevelUpStae = -1;
    this.m_LevelUpLV = (byte) 1;
    this.m_LevelOldExp = 1U;
    this.m_LevelNowExp = 1U;
    this.m_LevelSkillID = (ushort) 0;
    this.m_PetMarchEventData = new PetMarchEventDataType();
    this.m_PetMarchEventData.DesPlayerName = StringManager.Instance.SpawnString(13);
    this.bRecvPetMarchFinish = false;
  }

  public static PetManager Instance
  {
    get
    {
      if (PetManager.instance == null)
        PetManager.instance = new PetManager();
      return PetManager.instance;
    }
  }

  public ushort PetDataCount => (ushort) this.CurPetData.Count;

  public byte GetPetSortFlag() => this.PetSortFlag;

  ~PetManager()
  {
  }

  private T FindData<T>(T[] array, ushort count, ushort searchID, ref ushort index) where T : IComparable<ushort>
  {
    int num1 = 0;
    int num2 = (int) count;
    while (num1 <= num2)
    {
      ushort index1 = (ushort) Math.Floor((double) ((num1 + num2) / 2));
      if ((object) array[(int) index1] == null)
        return default (T);
      if (array[(int) index1].CompareTo(searchID) == 0)
      {
        index = index1;
        return array[(int) index1];
      }
      if (array[(int) index1].CompareTo(searchID) == -1)
        num2 = (int) index1 - 1;
      else
        num1 = (int) index1 + 1;
    }
    return default (T);
  }

  private PetData GetPetDataObj()
  {
    PetData petDataObj = (PetData) null;
    if ((int) this.PetPoolDataCountIdx == this.PetDataPool.Count)
    {
      int capacity = this.PetDataPool.Capacity;
      int count = this.PetDataPool.Count;
      for (byte index = 0; (int) index < capacity; ++index)
        this.PetDataPool.Add(new PetData(count + (int) index));
    }
    int poolDataCountIdx = (int) this.PetPoolDataCountIdx;
    int count1 = this.PetDataPool.Count;
    for (int index1 = 0; index1 < count1; ++index1)
    {
      int index2 = (index1 + poolDataCountIdx) % count1;
      petDataObj = this.PetDataPool[index2];
      if (petDataObj != null)
      {
        this.PetDataPool[index2] = (PetData) null;
        break;
      }
    }
    ++this.PetPoolDataCountIdx;
    return petDataObj;
  }

  private void ReleasePetDataObj(PetData Data)
  {
    if (Data == null || this.PetPoolDataCountIdx == (ushort) 0)
      return;
    --this.PetPoolDataCountIdx;
    this.PetDataPool[Data.DataIndex] = Data;
  }

  public void LoadTable()
  {
    this.PetTable = new CExternalTableWithWordKey<PetTbl>();
    this.PetExpTable = new CExternalTableWithWordKey<PetExpTbl>();
    this.PetSkillTable = new CExternalTableWithWordKey<PetSkillTbl>();
    this.PetSkillExpTable = new CExternalTableWithWordKey<PetSkillExpTbl>();
    this.PetStoneReqTable = new CExternalTableWithWordKey<PetStoneReqTbl>();
    this.PetSkillValTable = new CExternalTableWithWordKey<PetSkillValTbl>();
    this.PetSkillCoolTable = new CExternalTableWithWordKey<PetSkillCoolTbl>();
    this.MapDamageEffTable = new CExternalTableWithWordKey<MapDamageEffTb>();
    this.HeroTrainExpTable = new CExternalTableWithWordKey<HeroTrainExpTbl>();
    this.PetTable.LoadTable("Pet");
    this.PetExpTable.LoadTable("PetLevelUp");
    this.HeroTrainExpTable.LoadTable("HeroExpForPet");
    this.PetSkillTable.LoadTable("PetSkill");
    this.PetSkillExpTable.LoadTable("PetSkillExp");
    this.PetStoneReqTable.LoadTable("PetStoneRequire");
    this.PetSkillValTable.LoadTable("PetSkillValue");
    this.PetSkillCoolTable.LoadTable("PetSkillCD");
    this.MapDamageEffTable.LoadTable("MapDamageShow");
    if (this.CalcPetDataType != null && this.CalcPetDataType.Length >= this.PetTable.TableCount)
      return;
    this.CalcPetDataType = new _CalcPetDataType[this.PetTable.TableCount];
  }

  public PetData FindPetData(ushort ID)
  {
    byte Index = 0;
    return this.PetFinder.TryGetValue(ID, out Index) ? this.GetPetData((int) Index) : (PetData) null;
  }

  public PetData GetPetData(int Index)
  {
    return Index < this.CurPetData.Count ? this.CurPetData[Index] : (PetData) null;
  }

  public void SortPetData()
  {
    if (((int) this.PetSortFlag & 2) != 0)
      return;
    this.sortPetData.Sort((IComparer<byte>) this.petDataComparer);
    this.PetSortFlag |= (byte) 2;
  }

  public void UpdatePetSort(bool bUpdatePetAttr = true)
  {
    this.PetSortFlag &= (byte) 253;
    if (bUpdatePetAttr)
      DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Pet);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
    PetBuff.Update();
  }

  public void UpdatePetItemSore()
  {
    this.PetSortFlag &= (byte) 254;
    if (DataManager.Instance.SortItemDataType == (byte) 32)
      DataManager.Instance.SortItemDataType = (byte) 0;
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public byte UpdateCalculateBuffInfo()
  {
    byte buffInfo = 0;
    int count = this.BuffInfo.Count;
    for (int index = 0; index < count; ++index)
    {
      if (this.BuffInfo[index].SkillID != (ushort) 0 && this.CalcPetBuffDataType.Length > (int) buffInfo)
      {
        this.CalcPetBuffDataType[(int) buffInfo].SkillID = this.BuffInfo[index].SkillID;
        this.CalcPetBuffDataType[(int) buffInfo].Level = this.BuffInfo[index].Level;
        ++buffInfo;
      }
    }
    return buffInfo;
  }

  public void Clear()
  {
    if (this.PetDataCount > (ushort) 0)
    {
      for (ushort index = 0; (int) index < (int) this.PetDataCount; ++index)
        this.ReleasePetDataObj(this.CurPetData[(int) index]);
      this.CurPetData.Clear();
      this.PetFinder.Clear();
      this.sortPetData.Clear();
      this.m_PetTrainginSortData.Clear();
    }
    if (this.PetItemDataCount > (ushort) 0)
    {
      for (ushort index = 0; (int) index < (int) this.PetItemDataCount; ++index)
      {
        this.PetItemDataPool.despawn(this.PetItemData[(int) index]);
        this.PetItemData[(int) index] = (PetItem) null;
      }
      this.PetItemDataCount = (ushort) 0;
    }
    this.PetSortFlag = (byte) 0;
    this.BuffInfoLen = (byte) 0;
    this.CoolDownLen = (byte) 0;
    for (int index = 0; index < this.m_PetTrainingData.Length; ++index)
    {
      if (this.m_PetTrainingData[index].m_PetTrainingSet.m_CoachHeroId != null)
        this.m_PetTrainingData[index].m_PetTrainingSet.Empty();
      this.m_PetTrainingData[index].m_State = PetManager.EPetTrainDataState.Empty;
    }
    if (this.m_TrainingHero != null)
      Array.Clear((Array) this.m_TrainingHero, 0, this.m_TrainingHero.Length);
    this.m_PetMarchEventData.Empty();
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.PetMarch, false, 0L, 0U);
    GameConstants.GetBytes((ushort) 0, DataManager.msgBuffer, 0);
    GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetList, 16);
  }

  public void UnloadAsset()
  {
  }

  public bool CheckNewPetBook(ushort ItemID, int update = 0)
  {
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(ItemID);
    if ((byte) ((uint) recordByKey.EquipKind - 1U) == (byte) 17 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 5)
    {
      if ((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_PetList) != (UnityEngine.Object) null)
      {
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetList, update | 8);
      }
      else
      {
        this.UISave[6] = (byte) 0;
        GameConstants.GetBytes(0.0f, this.UISave, 7);
      }
      return true;
    }
    if (update > 0)
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetList, update);
    return false;
  }

  public bool IsPetItem(ushort ItemID)
  {
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(ItemID);
    switch ((EItemType) ((uint) recordByKey.EquipKind - 1U))
    {
      case EItemType.EIT_Consumables:
        if (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 5 || recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 6)
          return true;
        break;
      case EItemType.EIT_CaseByCase:
        if (recordByKey.PropertiesInfo[0].Propertieskey >= (ushort) 45 && recordByKey.PropertiesInfo[0].Propertieskey <= (ushort) 48)
          return true;
        break;
      case EItemType.EIT_MaterialTreasureBox:
        if (recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 5)
          return true;
        break;
      case EItemType.EIT_EnhanceStone:
        return true;
    }
    return false;
  }

  public void SetCurItemQuantity(ushort ItemID, ushort Quantity, byte Rare = 0)
  {
    ushort Index = 0;
    PetItem itemData = this.FindItemData(ItemID, ref Index);
    if (itemData != null)
    {
      if (Quantity > (ushort) 0)
      {
        if ((int) itemData.EquipKind - 1 == 17)
        {
          this.PetMaterialTreasureBox -= itemData.Quantity;
          this.PetMaterialTreasureBox += Quantity;
        }
        itemData.Quantity = Quantity;
      }
      else
      {
        if ((int) itemData.EquipKind - 1 == 17)
          this.PetMaterialTreasureBox -= itemData.Quantity;
        this.PetItemDataPool.despawn(itemData);
        --this.PetItemDataCount;
        if ((int) Index < (int) this.PetItemDataCount)
          Array.Copy((Array) this.PetItemData, (int) Index + 1, (Array) this.PetItemData, (int) Index, (int) this.PetItemDataCount - (int) Index);
        this.PetItemData[(int) this.PetItemDataCount] = (PetItem) null;
      }
    }
    else
    {
      if ((ushort) 200 <= this.PetItemDataCount || Quantity == (ushort) 0)
        return;
      PetItem petItem = this.PetItemDataPool.spawn();
      petItem.Init();
      petItem.ItemID = ItemID;
      petItem.Quantity = Quantity;
      this.PetItemData[(int) this.PetItemDataCount++] = petItem;
      if ((int) petItem.EquipKind - 1 == 17)
        this.PetMaterialTreasureBox += petItem.Quantity;
    }
    this.UpdatePetItemSore();
  }

  public ushort GetCurItemQuantity(ushort ItemID, byte Rare = 0)
  {
    ushort Index = 0;
    PetItem itemData = this.FindItemData(ItemID, ref Index);
    return itemData != null ? itemData.Quantity : (ushort) 0;
  }

  public PetItem FindItemData(ushort ID, ref ushort Index)
  {
    if (((int) this.PetSortFlag & 1) == 0)
    {
      Array.Sort<PetItem>(this.PetItemData, 0, (int) this.PetItemDataCount);
      this.PetSortFlag |= (byte) 1;
    }
    return this.FindData<PetItem>(this.PetItemData, this.PetItemDataCount, ID, ref Index);
  }

  public PetItem GetItemData(int Index)
  {
    return Index < this.PetItemData.Length ? this.PetItemData[Index] : (PetItem) null;
  }

  public void SortPetItemData()
  {
    DataManager instance = DataManager.Instance;
    if (instance.SortItemDataType == (byte) 32)
      return;
    if (((int) this.PetSortFlag & 1) == 0)
    {
      if (this.PetItemDataCount > (ushort) 0)
        Array.Sort<PetItem>(this.PetItemData, 0, (int) this.PetItemDataCount);
      this.PetSortFlag |= (byte) 1;
    }
    instance.SortItemDataType = (byte) 32;
    instance.bagitemDataComparer.SortType = (byte) 4;
    Array.Clear((Array) instance.sortItemDataStart, 0, instance.sortItemDataStart.Length);
    Array.Clear((Array) instance.sortItemDataCount, 0, instance.sortItemDataCount.Length);
    Array.Sort<ushort>(this.sortPetItemData, 0, this.sortPetItemData.Length, (IComparer<ushort>) instance.bagitemDataComparer);
    EItemType eitemType = EItemType.EIT_MAX;
    ushort num = 0;
    int petItemDataCount = (int) this.PetItemDataCount;
    for (int index1 = 0; index1 < petItemDataCount; ++index1)
    {
      PetItem itemData = this.GetItemData((int) this.sortPetItemData[index1]);
      if (itemData == null)
        break;
      if (itemData.EquipKind > (byte) 2)
      {
        EItemType index2 = itemData.EquipKind <= (byte) 0 || itemData.EquipKind > (byte) 30 ? EItemType.EIT_MAX : (EItemType) ((uint) itemData.EquipKind - 1U);
        if (eitemType != index2)
        {
          if (index2 == EItemType.EIT_CaseByCase)
          {
            ushort propertieskey = itemData.PropertiesInfo[0].Propertieskey;
            if ((int) num != (int) propertieskey)
            {
              switch (propertieskey)
              {
                case 45:
                  instance.sortItemDataStart[0] = (ushort) index1;
                  instance.sortItemDataCount[0] = (ushort) 1;
                  break;
                case 46:
                  instance.sortItemDataStart[1] = (ushort) index1;
                  instance.sortItemDataCount[1] = (ushort) 1;
                  break;
              }
              num = propertieskey;
            }
            else
            {
              switch (propertieskey)
              {
                case 45:
                  ++instance.sortItemDataCount[0];
                  continue;
                case 46:
                  ++instance.sortItemDataCount[1];
                  continue;
                default:
                  continue;
              }
            }
          }
          else
          {
            instance.sortItemDataStart[(int) index2] = (ushort) index1;
            instance.sortItemDataCount[(int) index2] = (ushort) 1;
            eitemType = index2;
          }
        }
        else
          ++instance.sortItemDataCount[(int) index2];
      }
    }
  }

  public void Update()
  {
    bool flag = false;
    if (DataManager.Instance.ServerTime == this.LastServerTime)
      return;
    this.LastServerTime = DataManager.Instance.ServerTime;
    if (this.m_PetTrainingData == null)
      return;
    for (int index = 0; index < this.m_PetTrainingData.Length; ++index)
    {
      if (this.m_PetTrainingData[index].m_State == PetManager.EPetTrainDataState.Training && this.LastServerTime >= this.m_PetTrainingData[index].m_EventTime.BeginTime + (long) this.m_PetTrainingData[index].m_EventTime.RequireTime)
      {
        this.m_PetTrainingData[index].m_State = PetManager.EPetTrainDataState.CanReceive;
        flag = true;
      }
    }
    if (!flag)
      return;
    this.SetAllTrainState();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 20);
  }

  private void SetAllTrainState()
  {
    byte trainBuildNum = this.GetTrainBuildNum();
    bool flag1 = false;
    bool flag2 = false;
    for (int index = 0; index < (int) trainBuildNum && index < this.m_PetTrainingData.Length; ++index)
    {
      if (this.m_PetTrainingData[index].m_State == PetManager.EPetTrainDataState.CanReceive)
      {
        flag2 = true;
        break;
      }
      if (this.m_PetTrainingData[index].m_State == PetManager.EPetTrainDataState.Empty || this.m_PetTrainingData[index].m_State == PetManager.EPetTrainDataState.Received)
        flag1 = true;
    }
    this.m_AllPetTrainState = !flag2 ? (!flag1 ? PetManager.EPetTrainDataState.Training : PetManager.EPetTrainDataState.Empty) : PetManager.EPetTrainDataState.CanReceive;
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public byte GetTrainBuildNum()
  {
    byte buildNumById = GUIManager.Instance.BuildingData.GetBuildNumByID((ushort) 23);
    BuildsData buildingData = GUIManager.Instance.BuildingData;
    if (buildNumById > (byte) 0 && buildingData.QueueBuildType == (byte) 2 && buildingData.AllBuildsData[(int) buildingData.BuildingManorID].BuildID == (ushort) 23)
      --buildNumById;
    return buildNumById;
  }

  public void SetTrainingCenterNum()
  {
    byte trainBuildNum = this.GetTrainBuildNum();
    for (int index = 0; index < 8; ++index)
    {
      if (!this.m_PetTrainingData[index].HasInstance)
        this.m_PetTrainingData[index] = new PetTraining(PetManager.EPetTrainDataState.Closed);
      if (index < (int) trainBuildNum && this.m_PetTrainingData[index].m_State != PetManager.EPetTrainDataState.Training && this.m_PetTrainingData[index].m_State != PetManager.EPetTrainDataState.CanReceive && this.m_PetTrainingData[index].m_State != PetManager.EPetTrainDataState.Received)
        this.m_PetTrainingData[index].SetState(PetManager.EPetTrainDataState.Empty);
      else if (index > (int) trainBuildNum)
      {
        this.m_PetTrainingClinetSave[index].Empty();
        this.m_PetTrainingClinetSave[index].SetState(PetManager.EPetTrainDataState.Closed);
        this.m_PetTrainingData[index].SetState(PetManager.EPetTrainDataState.Closed);
      }
      else if (index == (int) trainBuildNum)
      {
        this.m_PetTrainingClinetSave[index].SetState(PetManager.EPetTrainDataState.NextOpen);
        this.m_PetTrainingClinetSave[index].Empty();
        this.m_PetTrainingData[index].SetState(PetManager.EPetTrainDataState.NextOpen);
      }
    }
    this.SaveTrainingSet();
    this.SetAllTrainState();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 0);
  }

  public byte SortPetIdle()
  {
    byte num = 0;
    this.m_PetTrainginSortData.Sort((IComparer<byte>) this.m_PetIdleComparer);
    for (byte index = 0; (int) index < this.m_PetTrainginSortData.Count; ++index)
    {
      PetData petData = this.GetPetData((int) this.m_PetTrainginSortData[(int) index]);
      if (petData != null)
      {
        if (!petData.CheckState(PetManager.EPetState.Limit))
          ++num;
        else
          break;
      }
    }
    return num;
  }

  public string GetPetNameByID(ushort id)
  {
    return this.PetTable != null ? DataManager.Instance.mStringTable.GetStringByID((uint) this.PetTable.GetRecordByKey(id).Name) : (string) null;
  }

  public uint GetPetSkillMaxExp(ushort petID, byte skillIdx)
  {
    if (skillIdx >= (byte) 4)
      return 0;
    PetSkillExpTbl recordByKey = this.PetSkillExpTable.GetRecordByKey(this.PetSkillTable.GetRecordByKey(this.PetTable.GetRecordByKey(petID).PetSkill[(int) skillIdx]).Experience);
    PetData petData = this.FindPetData(petID);
    if (petData != null)
    {
      byte num = petData.SkillLv[(int) skillIdx];
      if (num >= (byte) 1 && (int) num <= recordByKey.ExpValue.Length)
        return recordByKey.ExpValue[(int) num - 1];
    }
    return 0;
  }

  public uint GetPetSkillMaxExpByID(ushort skillID, byte lv)
  {
    PetSkillExpTbl recordByKey = this.PetSkillExpTable.GetRecordByKey(this.PetSkillTable.GetRecordByKey(skillID).Experience);
    return lv >= (byte) 1 && (int) lv <= recordByKey.ExpValue.Length ? recordByKey.ExpValue[(int) lv - 1] : 0U;
  }

  public bool IsMaxLevelExp(ushort petID)
  {
    PetData petData = this.FindPetData(petID);
    return petData != null && petData.Level == (byte) 60;
  }

  public void LoadTrainingSet()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendFormat("{0}/Data/{1}{2}", (object) AssetManager.persistentDataPath, (object) this.PetTrainingListName, (object) DataManager.Instance.RoleAttr.UserId);
    string path = stringBuilder.ToString();
    if (!File.Exists(path))
      return;
    using (FileStream input = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read))
    {
      if (input.Length <= 0L)
        return;
      try
      {
        using (BinaryReader binaryReader = new BinaryReader((Stream) input))
        {
          for (int index1 = 0; index1 < this.m_PetTrainingClinetSave.Length; ++index1)
          {
            this.m_PetTrainingClinetSave[index1].m_PetTrainingSet.m_PetId = binaryReader.ReadUInt16();
            int num = binaryReader.ReadInt32();
            this.m_PetTrainingClinetSave[index1].m_PetTrainingSet.m_CoachHeroId.Clear();
            for (int index2 = 0; index2 < num; ++index2)
              this.m_PetTrainingClinetSave[index1].m_PetTrainingSet.m_CoachHeroId.Add(binaryReader.ReadUInt16());
            this.m_PetTrainingClinetSave[index1].m_TotalExp = binaryReader.ReadUInt32();
            this.m_PetTrainingClinetSave[index1].m_CancelExp = binaryReader.ReadUInt32();
            this.m_PetTrainingClinetSave[index1].m_EventTime.RequireTime = binaryReader.ReadUInt32();
            this.m_PetTrainingClinetSave[index1].m_State = this.m_PetTrainingClinetSave[index1].m_PetTrainingSet.m_PetId == (ushort) 0 ? PetManager.EPetTrainDataState.Closed : PetManager.EPetTrainDataState.Received;
          }
        }
      }
      catch (SystemException ex)
      {
      }
    }
  }

  public void SaveTrainingSet()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.AppendFormat("{0}/Data/{1}{2}", (object) AssetManager.persistentDataPath, (object) this.PetTrainingListName, (object) DataManager.Instance.RoleAttr.UserId);
    using (FileStream output = new FileStream(stringBuilder.ToString(), FileMode.OpenOrCreate))
    {
      using (BinaryWriter binaryWriter = new BinaryWriter((Stream) output))
      {
        for (int index1 = 0; index1 < this.m_PetTrainingClinetSave.Length; ++index1)
        {
          binaryWriter.Write(this.m_PetTrainingClinetSave[index1].m_PetTrainingSet.m_PetId);
          if (this.m_PetTrainingClinetSave[index1].m_PetTrainingSet.m_CoachHeroId.Count >= DataManager.Instance.MaxCurHeroData)
            binaryWriter.Write(DataManager.Instance.MaxCurHeroData);
          else
            binaryWriter.Write(this.m_PetTrainingClinetSave[index1].m_PetTrainingSet.m_CoachHeroId.Count);
          for (int index2 = 0; index2 < this.m_PetTrainingClinetSave[index1].m_PetTrainingSet.m_CoachHeroId.Count && index2 < DataManager.Instance.MaxCurHeroData; ++index2)
            binaryWriter.Write(this.m_PetTrainingClinetSave[index1].m_PetTrainingSet.m_CoachHeroId[index2]);
          binaryWriter.Write(this.m_PetTrainingClinetSave[index1].m_TotalExp);
          binaryWriter.Write(this.m_PetTrainingClinetSave[index1].m_CancelExp);
          binaryWriter.Write(this.m_PetTrainingClinetSave[index1].m_EventTime.RequireTime);
        }
      }
    }
  }

  public void SetTrainingHero(ushort heroID)
  {
    if ((int) heroID >= this.m_TrainingHero.Length)
      return;
    this.m_TrainingHero[(int) heroID] = (byte) 1;
  }

  public void RemoveTrainingHero(ushort heroID)
  {
    if ((int) heroID >= this.m_TrainingHero.Length)
      return;
    this.m_TrainingHero[(int) heroID] = (byte) 0;
  }

  public bool IsTrainingHero(ushort heroID)
  {
    bool flag = false;
    return (int) heroID < this.m_TrainingHero.Length ? this.m_TrainingHero[(int) heroID] == (byte) 1 : flag;
  }

  public Sprite LoadPetSkillIcon(ushort skillID)
  {
    if (skillID == (ushort) 0)
    {
      CString SpriteName = StringManager.Instance.StaticString1024();
      SpriteName.Append("s60000");
      return GUIManager.Instance.LoadSkillSprite(SpriteName);
    }
    PetSkillTbl recordByKey = this.PetSkillTable.GetRecordByKey(skillID);
    CString SpriteName1 = StringManager.Instance.StaticString1024();
    SpriteName1.Append('s');
    SpriteName1.IntToFormat((long) recordByKey.Icon, 5);
    SpriteName1.AppendFormat("{0}");
    return GUIManager.Instance.LoadSkillSprite(SpriteName1);
  }

  public void OpenPetLevelUp(
    ushort petID,
    byte beginLv,
    byte endLv,
    uint beginExp,
    uint endExp,
    int UsePetLvUp = 0,
    ushort skillID = 0)
  {
    this.m_PetBeginLv = beginLv;
    this.m_PetEndLv = endLv;
    this.m_BeginExp = beginExp;
    this.m_EndExp = endExp;
    this.m_PetSkillLvUpID = skillID;
    GUIManager.Instance.OpenUI_Queued_Restricted_Top(EGUIWindow.UI_PetLevelUp, (int) petID, UsePetLvUp, true, (byte) 1);
  }

  public ushort GetTrainExpByHeroCount(ushort count, bool bSkill = false)
  {
    ushort trainExpByHeroCount = 0;
    if (this.HeroTrainExpTable != null && count != (ushort) 0)
    {
      HeroTrainExpTbl recordByKey = this.HeroTrainExpTable.GetRecordByKey(count);
      if ((int) recordByKey.ID == (int) count)
        trainExpByHeroCount = !bSkill ? recordByKey.PetSkillExp : recordByKey.PetEep;
    }
    return trainExpByHeroCount;
  }

  public void RequestPetTrainingBegin(byte idx, ushort petID, List<ushort> coachHeroId)
  {
    if ((int) idx >= this.m_PetTrainingData.Length)
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PET_TRAINING_BEGIN;
    messagePacket.AddSeqId();
    messagePacket.Add(idx);
    messagePacket.Add(petID);
    messagePacket.Add((byte) coachHeroId.Count);
    for (int index = 0; index < coachHeroId.Count; ++index)
      messagePacket.Add(coachHeroId[index]);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.PetSelect);
    this.m_AllPetTrainState = PetManager.EPetTrainDataState.Training;
  }

  public void RecvPetTrainingBegin(MessagePacket MP)
  {
    byte result = MP.ReadByte();
    if (result == (byte) 0)
    {
      byte index1 = MP.ReadByte();
      ushort ID = MP.ReadUShort();
      uint num1 = MP.ReadUInt();
      long num2 = MP.ReadLong();
      uint num3 = MP.ReadUInt();
      byte num4 = MP.ReadByte();
      if ((int) index1 <= this.m_PetTrainingData.Length)
      {
        this.m_PetTrainingData[(int) index1].m_PetTrainingSet.m_PetId = ID;
        this.m_PetTrainingData[(int) index1].m_EventTime.BeginTime = num2;
        this.m_PetTrainingData[(int) index1].m_EventTime.RequireTime = num3;
        this.m_PetTrainingData[(int) index1].m_TotalExp = num1;
        this.m_PetTrainingData[(int) index1].m_PetTrainingSet.m_CoachHeroId.Clear();
        this.m_PetTrainingClinetSave[(int) index1].m_PetTrainingSet.m_PetId = ID;
        this.m_PetTrainingClinetSave[(int) index1].m_EventTime.RequireTime = num3;
        this.m_PetTrainingClinetSave[(int) index1].m_PetTrainingSet.m_CoachHeroId.Clear();
        this.m_PetTrainingClinetSave[(int) index1].m_TotalExp = num1;
        this.m_PetTrainingClinetSave[(int) index1].m_CancelExp = 0U;
        for (byte index2 = 0; (int) index2 < (int) num4; ++index2)
        {
          ushort heroID = MP.ReadUShort();
          this.m_PetTrainingData[(int) index1].m_PetTrainingSet.m_CoachHeroId.Add(heroID);
          this.SetTrainingHero(heroID);
          this.m_PetTrainingClinetSave[(int) index1].m_PetTrainingSet.m_CoachHeroId.Add(heroID);
        }
        this.m_PetTrainingData[(int) index1].m_State = PetManager.EPetTrainDataState.Training;
        this.SaveTrainingSet();
      }
      this.FindPetData(ID)?.AddState(PetManager.EPetState.Training);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetSelect, 0, (int) index1);
    }
    else
      this.ShowTrainErrorMsg(result);
    GUIManager.Instance.HideUILock(EUILock.PetSelect);
    this.SetAllTrainState();
    GameConstants.GetBytes((ushort) 0, DataManager.msgBuffer, 0);
    GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
  }

  public void RequestPetTrainingCancel(ushort petID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PET_TRAINING_CANCEL;
    messagePacket.AddSeqId();
    messagePacket.Add(petID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.PetSelect);
  }

  public void RecvPetTrainingCancel(MessagePacket MP)
  {
    byte result = MP.ReadByte();
    if (result == (byte) 0)
    {
      byte index1 = MP.ReadByte();
      ushort ID = MP.ReadUShort();
      uint num = MP.ReadUInt();
      if ((int) index1 < this.m_PetTrainingData.Length)
      {
        this.m_PetTrainingData[(int) index1].m_PetTrainingSet.m_PetId = ID;
        this.m_PetTrainingData[(int) index1].m_EventTime.BeginTime = 0L;
        this.m_PetTrainingData[(int) index1].m_EventTime.RequireTime = 0U;
        this.m_PetTrainingData[(int) index1].m_TotalExp = num;
        this.m_PetTrainingClinetSave[(int) index1].m_CancelExp = num;
        if (num > 0U)
        {
          this.m_PetTrainingData[(int) index1].m_State = PetManager.EPetTrainDataState.CanReceive;
        }
        else
        {
          this.m_PetTrainingData[(int) index1].m_State = PetManager.EPetTrainDataState.Received;
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17106U), (ushort) 35);
        }
        this.SaveTrainingSet();
      }
      if (num == 0U)
      {
        for (int index2 = 0; index2 < (int) this.m_PetTrainingData[(int) index1].CoachHeroCount; ++index2)
          this.RemoveTrainingHero(this.m_PetTrainingData[(int) index1].m_PetTrainingSet.m_CoachHeroId[index2]);
        this.m_PetTrainingData[(int) index1].m_PetTrainingSet.m_CoachHeroId.Clear();
        this.FindPetData(ID)?.Remove(PetManager.EPetState.Training);
      }
      this.SetAllTrainState();
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 20);
    }
    else
      this.ShowTrainErrorMsg(result);
    GUIManager.Instance.HideUILock(EUILock.PetSelect);
    this.SetAllTrainState();
    GameConstants.GetBytes((ushort) 0, DataManager.msgBuffer, 0);
    GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
  }

  public void RequestPetTrainingComplete(ushort petID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PET_TRAINING_COMPLETE;
    messagePacket.AddSeqId();
    messagePacket.Add(petID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.PetSelect);
  }

  public void RecvPetTrainingComplete(MessagePacket MP)
  {
    byte result = MP.ReadByte();
    if (result == (byte) 0)
    {
      byte num1 = byte.MaxValue;
      byte num2 = byte.MaxValue;
      byte[] numArray1 = new byte[4];
      uint[] numArray2 = new uint[4];
      byte index1 = MP.ReadByte();
      ushort num3 = MP.ReadUShort();
      bool flag = this.IsMaxLevelExp(num3);
      PetData petData = this.FindPetData(num3);
      if (petData != null && (int) index1 < this.m_PetTrainingData.Length)
      {
        byte level = petData.Level;
        uint exp = petData.Exp;
        petData.Level = MP.ReadByte();
        petData.Exp = MP.ReadUInt();
        petData.Enhance = MP.ReadByte();
        for (int index2 = 0; index2 < petData.SkillLv.Length; ++index2)
        {
          numArray1[index2] = petData.SkillLv[index2];
          petData.SkillLv[index2] = MP.ReadByte();
          if ((int) numArray1[index2] != (int) petData.SkillLv[index2])
            num2 = (byte) index2;
        }
        for (int index3 = 0; index3 < petData.SkillExp.Length; ++index3)
        {
          numArray2[index3] = petData.SkillExp[index3];
          petData.SkillExp[index3] = MP.ReadUInt();
          if ((int) numArray2[index3] != (int) petData.SkillExp[index3])
            num1 = (byte) index3;
        }
        petData.UpdateLevelState();
        this.UpdatePetSort();
        this.m_PetTrainingClinetSave[(int) index1].m_PetTrainingSet.m_PetId = num3;
        this.m_PetTrainingClinetSave[(int) index1].m_CancelExp = 0U;
        this.SaveTrainingSet();
        if ((int) index1 < this.m_PetTrainingData.Length)
        {
          this.m_PetTrainingData[(int) index1].m_PetTrainingSet.m_PetId = num3;
          this.m_PetTrainingData[(int) index1].m_EventTime.BeginTime = 0L;
          this.m_PetTrainingData[(int) index1].m_EventTime.RequireTime = 0U;
          this.m_PetTrainingData[(int) index1].m_State = PetManager.EPetTrainDataState.Received;
          for (int index4 = 0; index4 < (int) this.m_PetTrainingData[(int) index1].CoachHeroCount; ++index4)
            this.RemoveTrainingHero(this.m_PetTrainingData[(int) index1].m_PetTrainingSet.m_CoachHeroId[index4]);
          this.m_PetTrainingData[(int) index1].m_PetTrainingSet.m_CoachHeroId.Clear();
          petData.Remove(PetManager.EPetState.Training);
          PetTbl recordByKey = this.PetTable.GetRecordByKey(num3);
          this.m_LevelUpIdx = (int) index1;
          if (flag)
          {
            for (int index5 = 0; index5 < 4; ++index5)
            {
              if ((int) numArray1[index5] != (int) petData.SkillLv[index5] || (int) numArray2[index5] != (int) petData.SkillExp[index5])
              {
                this.m_LevelUpSkillIdx = index5;
                if ((int) numArray1[index5] < (int) petData.SkillLv[index5] && index5 < recordByKey.PetSkill.Length)
                {
                  this.OpenPetLevelUp(num3, numArray1[index5], petData.SkillLv[index5], numArray2[index5], petData.SkillExp[index5], 1, recordByKey.PetSkill[index5]);
                  break;
                }
                this.m_LevelUpLV = petData.SkillLv[index5];
                this.m_LevelOldExp = numArray2[index5];
                this.m_LevelNowExp = petData.SkillExp[index5];
                this.m_LevelUpStae = 2;
                this.m_LevelSkillID = recordByKey.PetSkill[index5];
                GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 0);
                break;
              }
            }
          }
          else if ((int) level < (int) petData.Level)
          {
            this.OpenPetLevelUp(num3, level, petData.Level, exp, petData.Exp, skillID: (ushort) 0);
          }
          else
          {
            this.m_LevelUpStae = 1;
            GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 0);
          }
          this.m_LevelUpIdx = -1;
          this.m_LevelUpSkillIdx = -1;
          this.m_LevelUpStae = -1;
          this.m_LevelUpLV = (byte) 1;
          this.m_LevelOldExp = 1U;
          this.m_LevelNowExp = 1U;
        }
      }
      this.SetAllTrainState();
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetList, 2);
      DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Pet);
      if (petData.CheckState(PetManager.EPetState.Limit))
      {
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(17142U), (ushort) 35);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 0);
      }
    }
    else
      this.ShowTrainErrorMsg(result);
    GUIManager.Instance.HideUILock(EUILock.PetSelect);
    this.SetAllTrainState();
    GameConstants.GetBytes((ushort) 0, DataManager.msgBuffer, 0);
    GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
  }

  public void RecvPetTrainingEvevt(MessagePacket MP)
  {
    DataManager.eMsgState eMsgState = (DataManager.eMsgState) MP.ReadByte();
    byte index1 = MP.ReadByte();
    ushort ID = MP.ReadUShort();
    uint num1 = MP.ReadUInt();
    long num2 = MP.ReadLong();
    uint num3 = MP.ReadUInt();
    byte num4 = MP.ReadByte();
    if ((int) index1 < this.m_PetTrainingData.Length)
    {
      this.m_PetTrainingData[(int) index1].m_PetTrainingSet.m_PetId = ID;
      this.m_PetTrainingData[(int) index1].m_EventTime.BeginTime = num2;
      this.m_PetTrainingData[(int) index1].m_EventTime.RequireTime = num3;
      this.m_PetTrainingData[(int) index1].m_TotalExp = num1;
      this.m_PetTrainingData[(int) index1].m_PetTrainingSet.m_CoachHeroId.Clear();
      for (byte index2 = 0; (int) index2 < (int) num4; ++index2)
      {
        ushort heroID = MP.ReadUShort();
        if (heroID != (ushort) 0)
        {
          this.m_PetTrainingData[(int) index1].m_PetTrainingSet.m_CoachHeroId.Add(heroID);
          this.SetTrainingHero(heroID);
        }
        else
          break;
      }
      this.m_PetTrainingData[(int) index1].m_State = PetManager.EPetTrainDataState.Training;
      this.FindPetData(ID)?.AddState(PetManager.EPetState.Training);
    }
    if (eMsgState != DataManager.eMsgState.EMS_End && eMsgState != DataManager.eMsgState.EMS_BeginAndEnd)
      return;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 20);
    this.SetAllTrainState();
    GameConstants.GetBytes((ushort) 0, DataManager.msgBuffer, 0);
    GameManager.OnRefresh(NetworkNews.Refresh_BuildBase, DataManager.msgBuffer);
  }

  private void ShowTrainErrorMsg(byte result)
  {
    if (result < (byte) 1)
      return;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.IntToFormat((long) result);
    cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17134U));
    GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) 35);
  }

  public void RecvPetMarchEventData(MessagePacket MP)
  {
    this.m_PetMarchEventData.PetID = MP.ReadUShort();
    this.m_PetMarchEventData.Point.zoneID = MP.ReadUShort();
    this.m_PetMarchEventData.Point.pointID = MP.ReadByte();
    this.m_PetMarchEventData.MarchEventTime.BeginTime = MP.ReadLong();
    this.m_PetMarchEventData.MarchEventTime.RequireTime = MP.ReadUInt();
    this.m_PetMarchEventData.DesPointKind = (POINT_KIND) MP.ReadByte();
    this.m_PetMarchEventData.DesPointLevel = MP.ReadByte();
    MP.ReadStringPlus(13, this.m_PetMarchEventData.DesPlayerName);
    if (this.m_PetMarchEventData.PetID == (ushort) 0)
      return;
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.PetMarch, true, this.m_PetMarchEventData.MarchEventTime.BeginTime, this.m_PetMarchEventData.MarchEventTime.RequireTime);
    DataManager.Instance.SetRecvQueueBarData(36);
  }

  public void RecvPetMarchEnd(MessagePacket MP)
  {
    MP.ReadByte();
    this.m_PetMarchEventData.Empty();
    DataManager.Instance.SetQueueBarData(EQueueBarIndex.PetMarch, false, 0L, 0U);
  }

  public void OpenPetUI(int SortIndex, int PetID)
  {
    this.PetUI_PetID = PetID;
    this.PetUI_PetSortIndex = SortIndex;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (UnityEngine.Object) menu)
      return;
    menu.OpenMenu(EGUIWindow.UI_Pet, bCameraMode: true);
  }

  public void OpenPetMaxShowUI(int PetID)
  {
    this.PetUI_PetMaxShowID = PetID;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (UnityEngine.Object) menu)
      return;
    menu.OpenMenu(EGUIWindow.UI_Pet, 1, bCameraMode: true);
  }

  public void OpenPetEvoPanel(int PetID, bool bCloseOpenPetList = true)
  {
    if (bCloseOpenPetList)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if ((bool) (UnityEngine.Object) menu)
      {
        menu.ClearWindowStack();
        GUIWindowStackData guiWindowStackData;
        guiWindowStackData.m_eWindow = EGUIWindow.UI_PetList;
        guiWindowStackData.m_Arg1 = 49;
        guiWindowStackData.m_Arg2 = 20;
        guiWindowStackData.bCameraMode = false;
        menu.m_WindowStack.Add(guiWindowStackData);
      }
    }
    this.OpenPetUI(0, PetID);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 11);
  }

  public uint GetNeedExp(byte Level, byte Rare)
  {
    PetExpTbl recordByKey = this.PetExpTable.GetRecordByKey((ushort) Level);
    return Rare > (byte) 0 && (int) Rare <= recordByKey.ExpValue.Length ? recordByKey.ExpValue[(int) Rare - 1] : 0U;
  }

  public byte GetMaxEnhance() => 2;

  public ushort GetEvoNeed_Stone(byte Enhance, byte Rare)
  {
    PetStoneReqTbl recordByKey = this.PetStoneReqTable.GetRecordByKey((ushort) Rare);
    return (int) Enhance < recordByKey.StoneReq.Length ? recordByKey.StoneReq[(int) Enhance] : (ushort) 0;
  }

  public uint GetEvoNeed_Time(byte Enhance)
  {
    if (Enhance == (byte) 0)
      return 43200;
    return Enhance == (byte) 1 ? 129600U : 0U;
  }

  public byte GetEvoNeed_Lv(byte Enhance)
  {
    if (Enhance == (byte) 0)
      return 20;
    return Enhance == (byte) 1 ? (byte) 50 : (byte) 0;
  }

  public void CheckPetSortIndexAndSort()
  {
    this.SortPetData();
    if (this.PetUI_PetSortIndex < 0 || this.PetUI_PetSortIndex >= (int) this.PetDataCount)
      return;
    PetData petData1 = this.GetPetData((int) this.sortPetData[this.PetUI_PetSortIndex]);
    if (petData1 != null && (int) petData1.ID == this.PetUI_PetID)
      return;
    for (int index = 0; index < (int) this.PetDataCount; ++index)
    {
      PetData petData2 = this.GetPetData((int) this.sortPetData[index]);
      if (petData2 != null && (int) petData2.ID == this.PetUI_PetID)
      {
        this.PetUI_PetSortIndex = index;
        break;
      }
    }
  }

  public bool IsFakePetItem(ushort ItemID)
  {
    return DataManager.Instance.EquipTable.GetRecordByKey(ItemID).EquipKind == (byte) 30;
  }

  public void SkillBuffComplete(ushort skillId)
  {
    if (skillId != (ushort) 87)
      return;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Market, 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Market_Help, 2);
  }

  public bool UseSkill(ushort skillId, ushort petId, bool onSelf = true)
  {
    PetSkillTbl recordByKey1 = this.PetSkillTable.GetRecordByKey(skillId);
    PetSkillValTbl recordByKey2 = this.PetSkillValTable.GetRecordByKey(recordByKey1.XValue);
    if (recordByKey1.Kind == (byte) 4 && (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 13 || ((int) MerchantmanManager.Instance.TradeLocks & 1) == 1 && ((int) MerchantmanManager.Instance.TradeLocks >> 1 & 1) == 1 && ((int) MerchantmanManager.Instance.TradeLocks >> 2 & 1) == 1 && ((int) MerchantmanManager.Instance.TradeLocks >> 3 & 1) == 1 && ((int) MerchantmanManager.Instance.MerchantmanExtraData.LocksBought & 1) == 1))
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(13544U), (ushort) byte.MaxValue);
      return false;
    }
    if (recordByKey1.Kind == (byte) 15 && GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 10)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12624U), (ushort) byte.MaxValue);
      return false;
    }
    if (recordByKey1.Kind == (byte) 8 && (recordByKey2.EffectBySkillLv[0] != 2U || !DataManager.Instance.queueBarData[1].bActive || DataManager.Instance.mPlayHelpDataType[0].HelpMax == (byte) 0 || (int) DataManager.Instance.mPlayHelpDataType[0].AlreadyHelperNum >= (int) DataManager.Instance.mPlayHelpDataType[0].HelpMax) && (recordByKey2.EffectBySkillLv[0] != 1U || !DataManager.Instance.queueBarData[0].bActive || DataManager.Instance.mPlayHelpDataType[1].HelpMax == (byte) 0 || (int) DataManager.Instance.mPlayHelpDataType[1].AlreadyHelperNum >= (int) DataManager.Instance.mPlayHelpDataType[1].HelpMax))
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12615U), (ushort) byte.MaxValue);
      return false;
    }
    if (recordByKey1.Kind == (byte) 28 && PetManager.Instance.NegBuff.Count == 0)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12622U), (ushort) byte.MaxValue);
      return false;
    }
    if (recordByKey1.Kind == (byte) 6 && GUIManager.Instance.m_TroopsCount == 0)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12614U), (ushort) byte.MaxValue);
      return false;
    }
    if (recordByKey1.Kind == (byte) 23)
    {
      for (int index = 0; index < 8; ++index)
      {
        if (DataManager.Instance.MarchEventData[index].Type == EMarchEventType.EMET_Gathering && DataManager.Instance.MarchEventData[index].PointKind != POINT_KIND.PK_CRYSTAL)
          return true;
      }
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12620U), (ushort) byte.MaxValue);
      return false;
    }
    if (recordByKey1.Kind == (byte) 5 && (recordByKey2.EffectBySkillLv[0] == 3U || recordByKey2.EffectBySkillLv[0] == 1U))
    {
      PetData petData = this.FindPetData(petId);
      PetTbl recordByKey3 = this.PetTable.GetRecordByKey(petId);
      PetSkillValTbl recordByKey4 = this.PetSkillValTable.GetRecordByKey(recordByKey1.ZValue);
      for (int index = 0; index < 4 && index < recordByKey3.PetSkill.Length; ++index)
      {
        if ((int) recordByKey3.PetSkill[index] == (int) skillId && petData != null && (int) petData.SkillLv[index] - 1 < recordByKey4.EffectBySkillLv.Length)
        {
          if (recordByKey2.EffectBySkillLv[0] == 1U)
          {
            if ((uint) DataManager.Instance.RoleAttr.Morale + recordByKey4.EffectBySkillLv[(int) petData.SkillLv[index] - 1] > 999U)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(809U), (ushort) byte.MaxValue);
              return false;
            }
            break;
          }
          if (recordByKey4.EffectBySkillLv[(int) petData.SkillLv[index] - 1] > uint.MaxValue - DataManager.Instance.Resource[4].Stock)
          {
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(820U), (ushort) byte.MaxValue);
            return false;
          }
          break;
        }
      }
    }
    if (recordByKey1.Kind == (byte) 2)
    {
      long soldierTotal = DataManager.Instance.SoldierTotal;
      for (int index1 = 0; index1 < DataManager.Instance.MarchEventData.Length; ++index1)
      {
        for (int index2 = 0; index2 < DataManager.Instance.MarchEventData[index1].TroopData.Length; ++index2)
        {
          if (DataManager.Instance.MarchEventData[index1].Type != EMarchEventType.EMET_Standby)
          {
            for (int index3 = 0; index3 < DataManager.Instance.MarchEventData[index1].TroopData[index2].Length; ++index3)
              soldierTotal += (long) DataManager.Instance.MarchEventData[index1].TroopData[index2][index3];
          }
        }
      }
      if (DataManager.Instance.queueBarData[10].bActive)
        soldierTotal += (long) DataManager.Instance.SoldierQuantity;
      PetData petData = this.FindPetData(petId);
      PetTbl recordByKey5 = this.PetTable.GetRecordByKey(petId);
      int index4 = 0;
      for (int index5 = 0; index5 < 4 && index5 < recordByKey5.PetSkill.Length; ++index5)
      {
        if ((int) skillId == (int) recordByKey5.PetSkill[index5])
          index4 = index5;
      }
      for (int index6 = 0; index6 < 16; ++index6)
        soldierTotal += (long) DataManager.Instance.mSoldier_Hospital[index6];
      if ((int) petData.SkillLv[index4] - 1 < recordByKey2.EffectBySkillLv.Length)
        soldierTotal += (long) recordByKey2.EffectBySkillLv[(int) petData.SkillLv[index4] - 1];
      if (soldierTotal >= 4200000000L)
      {
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12625U), (ushort) byte.MaxValue);
        return false;
      }
    }
    if (skillId == (ushort) 76 && ((long) DataManager.Instance.RoleAttr.Guide & 16777216L) == 0L)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12628U), (ushort) byte.MaxValue);
      return false;
    }
    if (skillId == (ushort) 88)
    {
      if (DataManager.Instance.m_WallRepairNowValue >= DataManager.Instance.m_WallRepairMaxValue)
      {
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12618U), (ushort) 35);
        return false;
      }
      if (LandWalkerManager.IsBattleFire())
      {
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12619U), (ushort) 35);
        return false;
      }
    }
    return true;
  }

  public void UseSkillResult(ushort skillId, ushort petId, byte Result, MessagePacket MP = null)
  {
    PetManager.EPetSkillExecuteErrorCode executeErrorCode1 = (PetManager.EPetSkillExecuteErrorCode) Result;
    PetManager.EPetSkillExecuteErrorCode executeErrorCode2 = executeErrorCode1;
    switch (executeErrorCode2)
    {
      case PetManager.EPetSkillExecuteErrorCode.EPSEEC_SHIELD:
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826U), DataManager.Instance.mStringTable.GetStringByID(12572U));
        break;
      case PetManager.EPetSkillExecuteErrorCode.EPSEEC_PET_MARCHING:
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826U), DataManager.Instance.mStringTable.GetStringByID(12576U));
        break;
      case PetManager.EPetSkillExecuteErrorCode.EPSEEC_NO_NPCCITYREWARD:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12616U), (ushort) 35);
        break;
      case PetManager.EPetSkillExecuteErrorCode.EPSEEC_NEWBIESHIELD:
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826U), DataManager.Instance.mStringTable.GetStringByID(12577U));
        break;
      case PetManager.EPetSkillExecuteErrorCode.EPSEEC_NO_MARCHING_TROOP:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12614U), (ushort) 35);
        break;
      case PetManager.EPetSkillExecuteErrorCode.EPSEEC_NO_GATHER:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12620U), (ushort) 35);
        break;
      case PetManager.EPetSkillExecuteErrorCode.EPSEEC_HAS_HIGHER_BUFF:
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826U), DataManager.Instance.mStringTable.GetStringByID(12626U));
        break;
      case PetManager.EPetSkillExecuteErrorCode.EPSEEC_NO_MARKET:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12617U), (ushort) 35);
        break;
      case PetManager.EPetSkillExecuteErrorCode.EPSEEC_NO_WARHALL:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12623U), (ushort) 35);
        break;
      case PetManager.EPetSkillExecuteErrorCode.EPSEEC_NO_MISSION:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12621U), (ushort) 35);
        break;
      case PetManager.EPetSkillExecuteErrorCode.EPSEEC_BM_ALL_LOCK:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(13544U), (ushort) 35);
        break;
      case PetManager.EPetSkillExecuteErrorCode.EPSEEC_DES_OUT_RANGE:
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(4826U), DataManager.Instance.mStringTable.GetStringByID(12563U));
        break;
      default:
        switch (executeErrorCode2)
        {
          case PetManager.EPetSkillExecuteErrorCode.EPSEEC_SUCCEED:
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12574U), (ushort) 35);
            break;
          case PetManager.EPetSkillExecuteErrorCode.EPSEEC_SUCCEED_SPAWN_SOLDIER:
            byte num1 = MP.ReadByte();
            byte num2 = MP.ReadByte();
            uint x = MP.ReadUInt();
            SoldierData recordByKey1 = DataManager.Instance.SoldierDataTable.GetRecordByKey((ushort) ((int) num1 * 4 + (int) num2 + 1));
            CString cstring1 = StringManager.Instance.StaticString1024();
            cstring1.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey1.Name));
            cstring1.IntToFormat((long) x);
            cstring1.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12613U));
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12574U), (ushort) 35);
            GUIManager.Instance.AddHUDMessage(cstring1.ToString(), (ushort) 35);
            break;
          case PetManager.EPetSkillExecuteErrorCode.EPSEEC_SUCCEED_GET_RSS:
            uint[] numArray = new uint[5];
            int index1 = 0;
            Array.Clear((Array) GUIManager.Instance.SE_Kind, 0, GUIManager.Instance.SE_Kind.Length);
            Array.Clear((Array) GUIManager.Instance.SE_ItemID, 0, GUIManager.Instance.SE_ItemID.Length);
            for (byte index2 = 0; (int) index2 < numArray.Length; ++index2)
            {
              numArray[(int) index2] = MP.ReadUInt();
              if (numArray[(int) index2] > 0U)
              {
                GUIManager.Instance.SE_Kind[index1] = (SpeciallyEffect_Kind) (16 + (int) index2);
                GUIManager.Instance.m_SpeciallyEffect.mResValue[(int) index2] = numArray[(int) index2];
                ++index1;
              }
            }
            GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
            GUIManager.Instance.m_SpeciallyEffect.AddIconShow(GUIManager.Instance.mStartV2, GUIManager.Instance.SE_Kind, GUIManager.Instance.SE_ItemID);
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(12574U), (ushort) 35);
            GameManager.OnRefresh(NetworkNews.Refresh_Resource);
            break;
          default:
            CString cstring2 = StringManager.Instance.StaticString1024();
            cstring2.IntToFormat((long) Result);
            cstring2.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12570U));
            GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(12550U), cstring2.ToString(), 35);
            break;
        }
        break;
    }
    if (executeErrorCode1 != PetManager.EPetSkillExecuteErrorCode.EPSEEC_NO_PLAYER && executeErrorCode1 != PetManager.EPetSkillExecuteErrorCode.EPSEEC_BAD_TARGET && executeErrorCode1 != PetManager.EPetSkillExecuteErrorCode.EPSEEC_SHIELD && executeErrorCode1 != PetManager.EPetSkillExecuteErrorCode.EPSEEC_PET_MARCHING && executeErrorCode1 != PetManager.EPetSkillExecuteErrorCode.EPSEEC_NEWBIESHIELD && executeErrorCode1 != PetManager.EPetSkillExecuteErrorCode.EPSEEC_NO_MARCHING_TROOP && executeErrorCode1 != PetManager.EPetSkillExecuteErrorCode.EPSEEC_NO_GATHER && executeErrorCode1 != PetManager.EPetSkillExecuteErrorCode.EPSEEC_HAS_HIGHER_BUFF && executeErrorCode1 != PetManager.EPetSkillExecuteErrorCode.EPSEEC_DES_OUT_RANGE)
      return;
    PetSkillTbl recordByKey2 = this.PetSkillTable.GetRecordByKey(skillId);
    if (skillId != (ushort) 0 && (recordByKey2.Type <= (byte) 0 || recordByKey2.Subject <= (byte) 1))
      return;
    DataManager.MapDataController.StopMapWeapon();
  }

  public void SetSkillFatigue(ushort value = 0, ushort speed = 0, long time = 0, bool Update = true)
  {
    DataManager.Instance.RoleAttr.PetSkillFatigue = value;
    DataManager.Instance.RoleAttr.FatigueRestoreSpeed = speed;
    DataManager.Instance.RoleAttr.LastPetSkillFatigueTime = time;
    if (!Update)
      return;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 26);
  }

  public bool CheckPetListBuildMark()
  {
    if (this.PetMaterialTreasureBox > (ushort) 0)
      return true;
    for (int index = 0; index < (int) this.PetDataCount; ++index)
    {
      bool flag1 = (int) this.CurPetData[index].Level == (int) this.CurPetData[index].GetMaxLevel(false);
      if (flag1 && this.CurPetData[index].Enhance != (byte) 2 && !this.CurPetData[index].CheckState(PetManager.EPetState.Evolution))
      {
        bool flag2 = (int) this.GetCurItemQuantity(this.PetTable.GetRecordByKey(this.CurPetData[index].ID).SoulID, (byte) 0) >= (int) this.GetEvoNeed_Stone(this.CurPetData[index].Enhance, this.CurPetData[index].Rare);
        if (flag1 && flag2)
          return true;
      }
    }
    return false;
  }

  public void FormatSkillContent(ushort skillID, byte level, CString NewStr, byte ContType = 0)
  {
    if (skillID == (ushort) 0 || level == (byte) 0 || NewStr == null)
      return;
    NewStr.ClearString();
    for (int index = 0; index < this.HintParm.Length; ++index)
      this.HintParm[index] = StringManager.Instance.StaticString1024();
    PetSkillTbl recordByKey = this.PetSkillTable.GetRecordByKey(skillID);
    if ((int) recordByKey.UpLevel < (int) level)
      level = recordByKey.UpLevel;
    if (recordByKey.Type == (byte) 2)
    {
      this.GetEffectStr(ref recordByKey, level, NewStr);
    }
    else
    {
      this.GetSkillTypeStr(ref recordByKey, level, this.HintParm);
      string str = ContType != (byte) 0 ? DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.Status) : DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.Effect1);
      int index = 0;
      while (index < str.Length)
      {
        char ch = str[index++];
        if (ch == '%')
        {
          switch (str[index])
          {
            case 'a':
              NewStr.Append(this.HintParm[0]);
              ++index;
              continue;
            case 'b':
              NewStr.Append(this.HintParm[1]);
              ++index;
              continue;
            case 'c':
              NewStr.Append(this.HintParm[2]);
              ++index;
              continue;
            case 'd':
              NewStr.Append(this.HintParm[3]);
              ++index;
              continue;
            case 'e':
              NewStr.Append(this.HintParm[4]);
              ++index;
              continue;
            case 'f':
              NewStr.Append(this.HintParm[5]);
              ++index;
              continue;
            case 'g':
              NewStr.Append(this.HintParm[6]);
              ++index;
              continue;
            default:
              NewStr.Append(ch);
              continue;
          }
        }
        else
          NewStr.Append(ch);
      }
    }
  }

  private unsafe void GetEffectStr(ref PetSkillTbl skillTbl, byte level, CString ParmA)
  {
    DataManager instance = DataManager.Instance;
    PetSkillValTbl recordByKey1 = this.PetSkillValTable.GetRecordByKey(skillTbl.XValue);
    if ((int) --level >= recordByKey1.EffectBySkillLv.Length)
      return;
    // ISSUE: untyped stack allocation
    ushort* numPtr = (ushort*) __untypedstackalloc((int) checked (6U * 2U));
    *numPtr = skillTbl.XValue;
    numPtr[1] = skillTbl.YValue;
    numPtr[2] = skillTbl.AValue;
    numPtr[3] = skillTbl.BValue;
    numPtr[4] = skillTbl.CValue;
    numPtr[5] = skillTbl.DValue;
    for (int index1 = 0; index1 < 3; ++index1)
    {
      int index2 = index1 * 2;
      if (numPtr[index2] != (ushort) 0)
      {
        Effect recordByKey2 = instance.EffectData.GetRecordByKey((ushort) recordByKey1.EffectBySkillLv[(int) level]);
        recordByKey1 = this.PetSkillValTable.GetRecordByKey(numPtr[index2 + 1]);
        float x = (float) recordByKey1.EffectBySkillLv[(int) level];
        if (recordByKey1.Unit == (byte) 0)
        {
          ParmA.Append(instance.mStringTable.GetStringByID((uint) recordByKey2.String_infoID));
          float f = x / 100f;
          ParmA.FloatToFormat(f, 2, false);
          ParmA.AppendFormat("{0}");
        }
        else if (recordByKey1.Unit == (byte) 1)
        {
          ParmA.AppendFormat(instance.mStringTable.GetStringByID((uint) recordByKey2.String_infoID));
          ParmA.IntToFormat((long) (int) x, bNumber: true);
          ParmA.AppendFormat("{0}");
        }
        else
        {
          ParmA.Append(instance.mStringTable.GetStringByID((uint) recordByKey2.String_infoID));
          float f = x / 60f;
          ParmA.FloatToFormat(f, 2, false);
          ParmA.AppendFormat("{0}");
        }
        if (recordByKey2.ValueID > (ushort) 0)
          ParmA.Append(instance.mStringTable.GetStringByID((uint) recordByKey2.ValueID));
        int index3 = (index1 + 1) * 2;
        if (index3 < 6 && numPtr[index3] > (ushort) 0)
        {
          recordByKey1 = this.PetSkillValTable.GetRecordByKey(numPtr[index3]);
          ParmA.Append('\n');
        }
      }
    }
  }

  private unsafe void GetSkillTypeStr(ref PetSkillTbl skillTbl, byte level, CString[] Parms)
  {
    DataManager instance = DataManager.Instance;
    PetSkillValTbl recordByKey = this.PetSkillValTable.GetRecordByKey(skillTbl.ZValue);
    if ((int) --level >= recordByKey.EffectBySkillLv.Length)
      return;
    float x1 = (float) recordByKey.EffectBySkillLv[(int) level];
    if (recordByKey.Unit == (byte) 0)
    {
      float f = x1 / 100f;
      Parms[0].FloatToFormat(f, 2, false);
    }
    else if (recordByKey.Unit == (byte) 1)
    {
      Parms[0].IntToFormat((long) (int) x1, bNumber: true);
    }
    else
    {
      float f = x1 / 60f;
      Parms[0].FloatToFormat(f, 2, false);
    }
    Parms[0].AppendFormat("{0}");
    // ISSUE: untyped stack allocation
    ushort* numPtr = (ushort*) __untypedstackalloc((int) checked (6U * 2U));
    *numPtr = skillTbl.XValue;
    numPtr[1] = skillTbl.YValue;
    numPtr[2] = skillTbl.AValue;
    numPtr[3] = skillTbl.BValue;
    numPtr[4] = skillTbl.CValue;
    numPtr[5] = skillTbl.DValue;
    for (int index = 0; index < 6; ++index)
    {
      if (numPtr[index] != (ushort) 0)
      {
        recordByKey = this.PetSkillValTable.GetRecordByKey(numPtr[index]);
        float x2 = (float) recordByKey.EffectBySkillLv[(int) level];
        if (recordByKey.Unit == (byte) 0)
        {
          float f = x2 / 100f;
          Parms[index + 1].FloatToFormat(f, 2, false);
        }
        else if (recordByKey.Unit == (byte) 1)
        {
          Parms[index + 1].IntToFormat((long) (int) x2, bNumber: true);
        }
        else
        {
          float f = x2 / 60f;
          Parms[index + 1].FloatToFormat(f, 2, false);
        }
        Parms[index + 1].AppendFormat("{0}");
      }
    }
  }

  public void FormatCoolTime(ushort time, CString timeStr, byte HavaArabicStr = 0)
  {
    if (timeStr == null || time == (ushort) 0)
      return;
    timeStr.Append("<color=#4CF5F5FF>");
    if (time < (ushort) 60)
    {
      timeStr.IntToFormat((long) time);
      timeStr.AppendFormat("{0}m");
    }
    else
    {
      int x1 = (int) time / 60;
      if (x1 < 24)
      {
        int x2 = (int) time % 60;
        timeStr.IntToFormat((long) x1);
        if (x2 > 0)
        {
          timeStr.IntToFormat((long) x2);
          if (HavaArabicStr == (byte) 0)
            timeStr.AppendFormat("{0}h {1}m");
          else
            timeStr.AppendFormat("{1}m {0}h");
        }
        else
        {
          timeStr.IntToFormat((long) x2);
          timeStr.AppendFormat("{0}h");
        }
      }
      else
      {
        int x3 = x1 / 24;
        int x4 = x1 % 24;
        int x5 = (int) time % 60;
        timeStr.IntToFormat((long) x3);
        if (x4 > 0 && x5 > 0)
        {
          timeStr.IntToFormat((long) x4);
          timeStr.IntToFormat((long) x5);
          if (HavaArabicStr == (byte) 0)
            timeStr.AppendFormat("{0}d {1}h {2}m");
          else
            timeStr.AppendFormat("{2}m {1}h {0}d ");
        }
        else if (x4 > 0)
        {
          timeStr.IntToFormat((long) x4);
          if (HavaArabicStr == (byte) 0)
            timeStr.AppendFormat("{0}d {1}h");
          else
            timeStr.AppendFormat("{1}h {0}d");
        }
        else if (x5 > 0)
        {
          timeStr.IntToFormat((long) x5);
          if (HavaArabicStr == (byte) 0)
            timeStr.AppendFormat("{0}d {1}m");
          else
            timeStr.AppendFormat("{1}m {0}d");
        }
        else
          timeStr.AppendFormat("{0}d");
      }
    }
    timeStr.Append("</color>");
  }

  public void RecvPetItemInfo(MessagePacket MP)
  {
    this.RecvItemState = (DataManager.eMsgState) MP.ReadByte();
    if (this.RecvItemState == DataManager.eMsgState.EMS_Begin || this.RecvItemState == DataManager.eMsgState.EMS_BeginAndEnd)
    {
      if (this.PetItemDataCount > (ushort) 0)
      {
        for (int index = 0; index < (int) this.PetItemDataCount; ++index)
          this.PetItemDataPool.despawn(this.PetItemData[index]);
        this.PetItemDataCount = (ushort) 0;
      }
      this.PetSortFlag &= (byte) 254;
      if (DataManager.Instance.SortItemDataType == (byte) 32)
        DataManager.Instance.SortItemDataType = (byte) 0;
      this.PetMaterialTreasureBox = (ushort) 0;
    }
    ushort num1 = MP.ReadUShort();
    for (int index = 0; index < (int) num1; ++index)
    {
      ushort num2 = MP.ReadUShort();
      if ((int) this.PetItemDataCount + index < 200)
      {
        PetItem petItem = this.PetItemDataPool.spawn();
        petItem.ItemID = num2;
        petItem.Quantity = MP.ReadUShort();
        this.PetItemData[(int) this.PetItemDataCount + index] = petItem;
        if ((int) petItem.EquipKind - 1 == 17)
          this.PetMaterialTreasureBox += petItem.Quantity;
      }
      else
        break;
    }
    this.PetItemDataCount += num1;
    if (this.PetItemDataCount > (ushort) 200)
      this.PetItemDataCount = (ushort) 200;
    if (this.RecvItemState != DataManager.eMsgState.EMS_End && this.RecvItemState != DataManager.eMsgState.EMS_BeginAndEnd)
      return;
    this.UpdatePetItemSore();
    GameManager.OnRefresh(NetworkNews.Refresh_Item);
  }

  public void RecvPetInfo(MessagePacket MP)
  {
    byte num1 = MP.ReadByte();
    ushort num2 = MP.ReadUShort();
    for (ushort index1 = 0; (int) index1 < (int) num2; ++index1)
    {
      PetData petDataObj = this.GetPetDataObj();
      petDataObj.Init();
      petDataObj.ID = MP.ReadUShort();
      petDataObj.Level = MP.ReadByte();
      petDataObj.Exp = MP.ReadUInt();
      petDataObj.Enhance = MP.ReadByte();
      if (petDataObj.Enhance > (byte) 2)
        petDataObj.Enhance = (byte) 2;
      MP.ReadBlock(petDataObj.SkillLv, 0, 4);
      for (byte index2 = 0; index2 < (byte) 4; ++index2)
        petDataObj.SkillExp[(int) index2] = MP.ReadUInt();
      petDataObj.UpdateLevelState();
      if (!this.PetFinder.ContainsKey(petDataObj.ID))
      {
        this.PetFinder.Add(petDataObj.ID, (byte) this.PetDataCount);
        this.sortPetData.Add((byte) this.PetDataCount);
        this.m_PetTrainginSortData.Add((byte) this.PetDataCount);
        this.CurPetData.Add(petDataObj);
      }
      else
        this.ReleasePetDataObj(petDataObj);
    }
    if (num1 != (byte) 1)
      return;
    this.UpdatePetSort();
    GameManager.OnRefresh(NetworkNews.Refresh_Pet);
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Pet);
  }

  public void RecvPetAddNewPet(MessagePacket MP)
  {
    PetData petDataObj = this.GetPetDataObj();
    petDataObj.Init();
    petDataObj.AddState(PetManager.EPetState.NewPet);
    petDataObj.ID = MP.ReadUShort();
    petDataObj.Level = MP.ReadByte();
    petDataObj.Exp = MP.ReadUInt();
    petDataObj.Enhance = MP.ReadByte();
    if (petDataObj.Enhance > (byte) 2)
      petDataObj.Enhance = (byte) 2;
    MP.ReadBlock(petDataObj.SkillLv, 0, 4);
    for (byte index = 0; index < (byte) 4; ++index)
      petDataObj.SkillExp[(int) index] = MP.ReadUInt();
    if (!this.PetFinder.ContainsKey(petDataObj.ID))
    {
      this.PetFinder.Add(petDataObj.ID, (byte) this.PetDataCount);
      this.sortPetData.Add((byte) this.PetDataCount);
      this.m_PetTrainginSortData.Add((byte) this.PetDataCount);
      this.CurPetData.Add(petDataObj);
    }
    else
      this.ReleasePetDataObj(petDataObj);
    this.UpdatePetSort();
    GameManager.OnRefresh(NetworkNews.Refresh_Pet);
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Pet);
  }

  public void RecvPetUpdate(MessagePacket MP)
  {
    PetData petData = this.FindPetData(MP.ReadUShort());
    if (petData == null)
      return;
    petData.Level = MP.ReadByte();
    petData.Exp = MP.ReadUInt();
    petData.Enhance = MP.ReadByte();
    MP.ReadBlock(petData.SkillLv, 0, 4);
    for (byte index = 0; index < (byte) 4; ++index)
      petData.SkillExp[(int) index] = MP.ReadUInt();
    this.UpdatePetSort();
    GameManager.OnRefresh(NetworkNews.Refresh_Pet);
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Pet);
  }

  public void Recv_PET_CURRENT_STARUP(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.PetUI);
    this.PetUI_EvoID = MP.ReadUShort();
    long StartTime = MP.ReadLong();
    uint TotalTime = MP.ReadUInt();
    this.FindPetData(this.PetUI_EvoID)?.AddState(PetManager.EPetState.Evolution);
    if (this.PetUI_EvoID > (ushort) 0 && StartTime > 0L && TotalTime > 0U)
    {
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.PetEvolution, true, StartTime, TotalTime);
      DataManager.Instance.SetRecvQueueBarData(35);
    }
    else
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.PetEvolution, false, 0L, 0U);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 5);
  }

  public void Recv_PET_STARUP_START(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.PetUI);
    PetManager.PET_STARUP_START_RESULT x = (PetManager.PET_STARUP_START_RESULT) MP.ReadByte();
    if (x == PetManager.PET_STARUP_START_RESULT.PET_STARUP_START_RESULT_SUCCESS)
    {
      this.PetUI_EvoID = MP.ReadUShort();
      ushort ItemID = MP.ReadUShort();
      ushort Quantity = MP.ReadUShort();
      long StartTime = MP.ReadLong();
      uint TotalTime = MP.ReadUInt();
      this.FindPetData(this.PetUI_EvoID)?.AddState(PetManager.EPetState.Evolution);
      DataManager instance = DataManager.Instance;
      if (this.PetUI_EvoID > (ushort) 0 && StartTime > 0L && TotalTime > 0U)
      {
        instance.SetQueueBarData(EQueueBarIndex.PetEvolution, true, StartTime, TotalTime);
        instance.SetRecvQueueBarData(35);
      }
      else
        instance.SetQueueBarData(EQueueBarIndex.PetEvolution, false, 0L, 0U);
      instance.SetCurItemQuantity(ItemID, Quantity, (byte) 0, 0L);
      GameManager.OnRefresh(NetworkNews.Refresh_Item);
      GameManager.OnRefresh(NetworkNews.Refresh_Pet);
    }
    else
    {
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.IntToFormat((long) (byte) x);
      cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(16084U));
      GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
    }
  }

  public void Recv_PET_STARUP_COMPLETE(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.PetUI);
    PetManager.PET_STARUP_COMPLETE_RESULT x = (PetManager.PET_STARUP_COMPLETE_RESULT) MP.ReadByte();
    if (x == PetManager.PET_STARUP_COMPLETE_RESULT.PET_STARUP_COMPLETE_RESULT_SUCCESS)
    {
      DataManager instance = DataManager.Instance;
      ushort num1 = MP.ReadUShort();
      byte num2 = MP.ReadByte();
      uint diamond = MP.ReadUInt();
      ushort ItemID = MP.ReadUShort();
      ushort Quantity = MP.ReadUShort();
      this.PetUI_EvoID = (ushort) 0;
      instance.SetQueueBarData(EQueueBarIndex.PetEvolution, false, 0L, 0U);
      PetData petData = this.FindPetData(num1);
      if (petData != null)
      {
        petData.Enhance = num2;
        petData.Remove(PetManager.EPetState.Evolution);
        GameManager.OnRefresh(NetworkNews.Refresh_Pet);
        PetTbl recordByKey = this.PetTable.GetRecordByKey(num1);
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.StringToFormat(instance.mStringTable.GetStringByID((uint) recordByKey.Name));
        cstring.AppendFormat(instance.mStringTable.GetStringByID(16058U));
        GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) 35);
        this.UpdatePetSort();
        petData.UpdateLevelState();
      }
      GUIManager.Instance.SetRoleAttrDiamond(diamond, (ushort) 0);
      DataManager.Instance.SetCurItemQuantity(ItemID, Quantity, (byte) 0, 0L);
      GameManager.OnRefresh();
      DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Pet);
      GameManager.OnRefresh(NetworkNews.Refresh_Attr);
      GameManager.OnRefresh(NetworkNews.Refresh_Item);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 6, (int) num1);
    }
    else
    {
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.IntToFormat((long) (byte) x);
      cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(16084U));
      GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
    }
  }

  public void Recv_PET_STARUP_CANCEL(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.PetUI);
    PetManager.PET_STARUP_CANCEL_RESULT x = (PetManager.PET_STARUP_CANCEL_RESULT) MP.ReadByte();
    if (x == PetManager.PET_STARUP_CANCEL_RESULT.PET_STARUP_CANCEL_RESULT_SUCCESS)
    {
      ushort ID = MP.ReadUShort();
      ushort ItemID = MP.ReadUShort();
      ushort Quantity = MP.ReadUShort();
      this.FindPetData(ID)?.Remove(PetManager.EPetState.Evolution);
      this.PetUI_EvoID = (ushort) 0;
      DataManager.Instance.SetQueueBarData(EQueueBarIndex.PetEvolution, false, 0L, 0U);
      DataManager.Instance.SetCurItemQuantity(ItemID, Quantity, (byte) 0, 0L);
      GameManager.OnRefresh(NetworkNews.Refresh_Item);
      GameManager.OnRefresh(NetworkNews.Refresh_Pet);
    }
    else
    {
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.IntToFormat((long) (byte) x);
      cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(16084U));
      GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
    }
  }

  public void Send_PET_STARUP(ushort PetID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PET_STARUP;
    messagePacket.AddSeqId();
    messagePacket.Add(PetID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.PetUI);
  }

  public void Send_PET_STARUP_FREECOMPLETE()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PET_STARUP_FREECOMPLETE;
    messagePacket.AddSeqId();
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.PetUI);
  }

  public void Send_PET_STARUP_INSTANT(ushort PetID = 0)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PET_STARUP_INSTANT;
    messagePacket.AddSeqId();
    if (PetID == (ushort) 0)
      messagePacket.Add(this.PetUI_EvoID);
    else
      messagePacket.Add(PetID);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.PetUI);
  }

  public void Send_PET_STARUP_CANCEL()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PET_STARUP_CANCEL;
    messagePacket.AddSeqId();
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.PetUI);
  }

  public void Recv_PETSKILL_UPGRADESKILL(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.PetUI);
    PetManager.EPetSkillUpgradeErrorCode x = (PetManager.EPetSkillUpgradeErrorCode) MP.ReadByte();
    if (x == PetManager.EPetSkillUpgradeErrorCode.EPSUEC_SUCCEED)
    {
      PetData petData = this.FindPetData(MP.ReadUShort());
      if (petData == null)
        return;
      byte index1 = MP.ReadByte();
      if (index1 < (byte) 4)
      {
        this.PetUI_OldExp = petData.SkillExp[(int) index1];
        petData.SkillExp[(int) index1] = MP.ReadUInt();
        this.PetUI_OldLV = petData.SkillLv[(int) index1];
        petData.SkillLv[(int) index1] = MP.ReadByte();
        this.PetUI_UpNeedStoneCount = MP.ReadUShort();
        for (int index2 = 0; index2 < this.PetUI_UpNeedSoulCount.Length; ++index2)
          this.PetUI_UpNeedSoulCount[index2] = MP.ReadUShort();
        this.PetUI_BaseExp = MP.ReadUInt();
        this.PetUI_GetExp = MP.ReadUInt();
        this.PetUI_GetRate = MP.ReadUShort();
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 9, (int) petData.SkillLv[(int) index1] - (int) this.PetUI_OldLV);
        petData.UpdateLevelState();
      }
      DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Buff);
      DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Pet);
    }
    else
    {
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.IntToFormat((long) (byte) x);
      cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12130U));
      GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 2);
    }
    this.PetSortFlag |= (byte) 4;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetList, 4);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public void Recv_PETSKILL_UPGRADE_STONE_AMOUNT(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.PetUI);
    this.PetUI_UpNeedStoneCount = MP.ReadUShort();
    for (int index = 0; index < this.PetUI_UpNeedSoulCount.Length; ++index)
      this.PetUI_UpNeedSoulCount[index] = MP.ReadUShort();
    this.PetUI_BaseExp = MP.ReadUInt();
    this.PetSortFlag |= (byte) 4;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Pet, 1);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetList, 4);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public void Send_PETSKILL_UPGRADESKILL(ushort PetID, byte SkillIndex, byte CoinType)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PETSKILL_UPGRADESKILL;
    messagePacket.AddSeqId();
    messagePacket.Add(PetID);
    messagePacket.Add(SkillIndex);
    messagePacket.Add(CoinType);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.PetUI);
  }

  public void Send_PETSKILL_UPGRADE_STONE_AMOUNT()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PETSKILL_UPGRADE_STONE_AMOUNT;
    messagePacket.AddSeqId();
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.PetUI);
    this.PetSortFlag &= (byte) 251;
  }

  public void SendItemCraft_Start(ushort mItemCraftID, ushort mItemCount, byte InstantComplete = 0)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ITEMCRAFT_START;
    messagePacket.AddSeqId();
    messagePacket.Add(mItemCraftID);
    messagePacket.Add(mItemCount);
    messagePacket.Add(InstantComplete);
    messagePacket.Send();
  }

  public void SendItemCraft_Cancel()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ITEMCRAFT_CANCEL;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_ITEMCRAFT(MessagePacket MP)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    instance2.HideUILock(EUILock.PetFusion);
    byte num1 = MP.ReadByte();
    if (num1 == (byte) 3)
    {
      this.Recv_MSG_RESP_ITEMCRAFT_Type3(MP);
    }
    else
    {
      byte x = MP.ReadByte();
      switch (x)
      {
        case 0:
          ushort InKey = MP.ReadUShort();
          ushort Quantity1 = MP.ReadUShort();
          long num2 = MP.ReadLong();
          uint num3 = MP.ReadUInt();
          FusionData recordByKey = instance1.FusionDataTable.GetRecordByKey(InKey);
          switch (num1)
          {
            case 0:
              this.ItemCraftID = InKey;
              this.ItemCraftCount = Quantity1;
              if (this.ItemCraftCount == (ushort) 0)
                instance2.OpenMessageBox(instance1.mStringTable.GetStringByID(4829U), instance1.mStringTable.GetStringByID(3870U), instance1.mStringTable.GetStringByID(4831U));
              else if ((int) this.ItemCraftCount < (int) this.m_ItemCraftQty)
              {
                instance2.MsgStr.ClearString();
                instance2.MsgStr.IntToFormat((long) this.m_ItemCraftQty);
                instance2.MsgStr.IntToFormat((long) this.ItemCraftCount);
                if (recordByKey.Fusion_Kind < (byte) 1)
                  instance2.MsgStr.AppendFormat(instance1.mStringTable.GetStringByID(14674U));
                else
                  instance2.MsgStr.AppendFormat(instance1.mStringTable.GetStringByID(14675U));
                instance2.OpenMessageBox(instance1.mStringTable.GetStringByID(3971U), instance2.MsgStr.ToString(), instance1.mStringTable.GetStringByID(4026U));
              }
              this.ItemCraftBeginTime = num2;
              this.ItemCraftNeedTime = num3;
              if (this.ItemCraftBeginTime > 0L && this.ItemCraftNeedTime > 0U)
              {
                instance1.SetQueueBarData(EQueueBarIndex.PetFusion, true, this.ItemCraftBeginTime, this.ItemCraftNeedTime);
                instance1.SetRecvQueueBarData(34);
              }
              else
                instance1.SetQueueBarData(EQueueBarIndex.PetFusion, false, 0L, 0U);
              AudioManager.Instance.PlaySFX((ushort) 2201);
              break;
            case 1:
              instance1.SetCurItemQuantity(recordByKey.Fusion_ItemID, Quantity1, (byte) 0, 0L);
              instance2.MsgStr.ClearString();
              if (recordByKey.Fusion_Kind < (byte) 1)
              {
                instance2.MsgStr.StringToFormat(instance1.mStringTable.GetStringByID((uint) instance1.EquipTable.GetRecordByKey(recordByKey.Fusion_ItemID).EquipName));
              }
              else
              {
                CString tmpS = StringManager.Instance.StaticString1024();
                tmpS.ClearString();
                tmpS.StringToFormat(instance1.mStringTable.GetStringByID((uint) instance1.EquipTable.GetRecordByKey(recordByKey.Fusion_ItemID).EquipName));
                tmpS.StringToFormat(instance1.mStringTable.GetStringByID(14669U));
                tmpS.AppendFormat("{0}{1}");
                instance2.MsgStr.StringToFormat(tmpS);
              }
              instance2.MsgStr.AppendFormat(instance1.mStringTable.GetStringByID(14676U));
              instance2.AddHUDMessage(instance2.MsgStr.ToString(), (ushort) byte.MaxValue);
              this.CheckNewPetBook(recordByKey.Fusion_ItemID);
              AudioManager.Instance.PlaySFX((ushort) 2404);
              break;
            case 2:
              instance1.SetQueueBarData(EQueueBarIndex.PetFusion, false, 0L, 0U);
              break;
          }
          for (int index = 0; index < 5; ++index)
            instance1.Resource[index].Stock = MP.ReadUInt();
          instance1.PetResource.Stock = MP.ReadUInt();
          for (int index = 0; index < 3; ++index)
          {
            ushort Quantity2 = MP.ReadUShort();
            if (Quantity2 >= (ushort) 0)
              instance1.SetCurItemQuantity(recordByKey.ItemData[index].ItemID, Quantity2, recordByKey.ItemData[index].Rank, 0L);
          }
          ushort Quantity3 = MP.ReadUShort();
          if (num1 == (byte) 1 && Quantity3 >= (ushort) 0)
            instance1.SetCurItemQuantity(recordByKey.Fusion_ItemID, Quantity3, (byte) 0, 0L);
          if (num1 == (byte) 1)
            instance2.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0);
          instance2.UpdateUI(EGUIWindow.UI_PetFusion, 1);
          instance2.UpdateUI(EGUIWindow.UI_PetFusionbuilding, 1);
          GameManager.OnRefresh();
          GameManager.OnRefresh(NetworkNews.Refresh_Resource);
          GameManager.OnRefresh(NetworkNews.Refresh_Item);
          break;
        case 3:
          instance2.OpenMessageBox(instance1.mStringTable.GetStringByID(4829U), instance1.mStringTable.GetStringByID(3870U), instance1.mStringTable.GetStringByID(4831U));
          break;
        default:
          instance2.MsgStr.ClearString();
          instance2.MsgStr.IntToFormat((long) x);
          instance2.MsgStr.AppendFormat(instance1.mStringTable.GetStringByID(14673U));
          instance2.AddHUDMessage(instance2.MsgStr.ToString(), (ushort) byte.MaxValue);
          break;
      }
    }
  }

  public void Recv_MSG_RESP_ITEMCRAFT_Type3(MessagePacket MP)
  {
    byte x = MP.ReadByte();
    if (x == (byte) 0)
    {
      int num1 = (int) MP.ReadUShort();
      int num2 = (int) MP.ReadUShort();
      MP.ReadLong();
      int num3 = (int) MP.ReadUInt();
      for (int index = 0; index < 5; ++index)
      {
        int num4 = (int) MP.ReadUInt();
      }
      int num5 = (int) MP.ReadUInt();
      int num6 = (int) MP.ReadUShort();
      int num7 = (int) MP.ReadUShort();
      int num8 = (int) MP.ReadUShort();
      int num9 = (int) MP.ReadUShort();
      GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetFusionbuilding, 1);
      GameManager.OnRefresh();
      GameManager.OnRefresh(NetworkNews.Refresh_Resource);
      GameManager.OnRefresh(NetworkNews.Refresh_Item);
    }
    else
    {
      GUIManager.Instance.MsgStr.ClearString();
      GUIManager.Instance.MsgStr.IntToFormat((long) x);
      GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(14673U));
      GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), (ushort) byte.MaxValue);
    }
  }

  public void Recv_MSG_ITEMCRAFT_INFO(MessagePacket MP)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    this.ItemCraftID = MP.ReadUShort();
    this.ItemCraftCount = MP.ReadUShort();
    this.ItemCraftBeginTime = MP.ReadLong();
    this.ItemCraftNeedTime = MP.ReadUInt();
    if (this.ItemCraftBeginTime > 0L && this.ItemCraftNeedTime > 0U)
    {
      instance1.SetQueueBarData(EQueueBarIndex.PetFusion, true, this.ItemCraftBeginTime, this.ItemCraftNeedTime);
      instance1.SetRecvQueueBarData(34);
    }
    else
      instance1.SetQueueBarData(EQueueBarIndex.PetFusion, false, 0L, 0U);
    instance2.UpdateUI(EGUIWindow.UI_PetFusionbuilding, 1);
  }

  public void Recv_MSG_ITEMCRAFT_DONE(MessagePacket MP)
  {
    DataManager instance1 = DataManager.Instance;
    GUIManager instance2 = GUIManager.Instance;
    this.ItemCraftID = MP.ReadUShort();
    FusionData recordByKey = instance1.FusionDataTable.GetRecordByKey(this.ItemCraftID);
    ushort Quantity = MP.ReadUShort();
    if (Quantity >= (ushort) 0)
      instance1.SetCurItemQuantity(recordByKey.Fusion_ItemID, Quantity, (byte) 0, 0L);
    this.ItemCraftBeginTime = 0L;
    this.ItemCraftNeedTime = 0U;
    instance1.SetQueueBarData(EQueueBarIndex.PetFusion, false, 0L, 0U);
    instance2.MsgStr.ClearString();
    if (recordByKey.Fusion_Kind < (byte) 1)
    {
      instance2.MsgStr.StringToFormat(instance1.mStringTable.GetStringByID((uint) instance1.EquipTable.GetRecordByKey(recordByKey.Fusion_ItemID).EquipName));
    }
    else
    {
      CString tmpS = StringManager.Instance.StaticString1024();
      tmpS.ClearString();
      tmpS.StringToFormat(instance1.mStringTable.GetStringByID((uint) instance1.EquipTable.GetRecordByKey(recordByKey.Fusion_ItemID).EquipName));
      tmpS.StringToFormat(instance1.mStringTable.GetStringByID(14669U));
      tmpS.AppendFormat("{0}{1}");
      instance2.MsgStr.StringToFormat(tmpS);
    }
    instance2.MsgStr.AppendFormat(instance1.mStringTable.GetStringByID(14676U));
    instance2.AddHUDMessage(instance2.MsgStr.ToString(), (ushort) byte.MaxValue);
    this.CheckNewPetBook(recordByKey.Fusion_ItemID);
    instance2.UpdateUI(EGUIWindow.UI_PetFusion, 2);
    instance2.UpdateUI(EGUIWindow.UI_PetFusionbuilding, 1);
    instance2.UpdateUI(EGUIWindow.UI_PetList, 9, (int) recordByKey.Fusion_ItemID);
    GameManager.OnRefresh(NetworkNews.Refresh_Item);
    AudioManager.Instance.PlaySFX((ushort) 2404);
  }

  public void Recv_MSG_RESP_PET_OPENPETBOX(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.UseItem);
    byte num1 = MP.ReadByte();
    if (num1 == (byte) 0)
    {
      DataManager instance1 = DataManager.Instance;
      GUIManager instance2 = GUIManager.Instance;
      this.IsShowOpen = false;
      this.mItemCraftList.Clear();
      ushort ItemID = MP.ReadUShort();
      ushort curItemQuantity1 = instance1.GetCurItemQuantity(ItemID, (byte) 0);
      ushort Quantity = MP.ReadUShort();
      ushort num2 = (ushort) ((uint) curItemQuantity1 - (uint) Quantity);
      instance1.SetCurItemQuantity(ItemID, Quantity, (byte) 0, 0L);
      instance2.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0);
      instance1.RoleAlliance.Money = MP.ReadUInt();
      this.mPetItemNum = MP.ReadByte();
      this.ItemNum = MP.ReadByte();
      this.mPetStoneNum = (byte) 0;
      int num3 = (int) this.mPetItemNum + (int) this.ItemNum;
      ItemCraftDataType itemCraftDataType = new ItemCraftDataType();
      for (int index = 0; index < num3 && num3 < 200; ++index)
      {
        itemCraftDataType.ItemID = MP.ReadUShort();
        itemCraftDataType.Num = MP.ReadUShort();
        itemCraftDataType.ItemRank = MP.ReadByte();
        itemCraftDataType.mNo = (byte) index;
        Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(itemCraftDataType.ItemID);
        itemCraftDataType.mPetID = recordByKey.SyntheticParts[0].SyntheticItem;
        itemCraftDataType.mPetName = recordByKey.EquipName;
        itemCraftDataType.mItemKind = recordByKey.EquipKind;
        if (itemCraftDataType.mItemKind == (byte) 29)
        {
          PetData petData = this.FindPetData(itemCraftDataType.mPetID);
          itemCraftDataType.mPetEnhance = petData.Enhance;
        }
        this.mItemCraftList.Add(itemCraftDataType);
        if (recordByKey.EquipKind <= (byte) 29)
        {
          ushort curItemQuantity2 = instance1.GetCurItemQuantity(itemCraftDataType.ItemID, (byte) 0);
          if ((int) curItemQuantity2 + (int) itemCraftDataType.Num > (int) ushort.MaxValue)
            instance1.SetCurItemQuantity(itemCraftDataType.ItemID, ushort.MaxValue, (byte) 0, 0L);
          else
            instance1.SetCurItemQuantity(itemCraftDataType.ItemID, (ushort) ((uint) curItemQuantity2 + (uint) itemCraftDataType.Num), (byte) 0, 0L);
          if (itemCraftDataType.mItemKind == (byte) 29)
            ++this.mPetStoneNum;
        }
      }
      this.ItemNum -= this.mPetStoneNum;
      this.mItemCraftList.Sort((IComparer<ItemCraftDataType>) this.mItemCrafeDataComparer);
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if ((bool) (UnityEngine.Object) menu)
        menu.OpenMenu(EGUIWindow.UI_ItemCraftShow, (int) ItemID, (int) num2, true);
      GameManager.OnRefresh(NetworkNews.Refresh_Item);
      FBAdvanceManager.Instance.TriggerFbUniqueEvent(EFBEvent.FIRST_PACT_OPENED);
    }
    else
    {
      switch (num1)
      {
        case 1:
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9771U), (ushort) byte.MaxValue);
          break;
        case 2:
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(702U), (ushort) byte.MaxValue);
          break;
      }
    }
  }

  public void Recv_PETSKILL_USE(MessagePacket MP)
  {
    byte Result = MP.ReadByte();
    ushort petId = MP.ReadUShort();
    PSCoolDownData psCoolDownData;
    psCoolDownData.SkillID = MP.ReadUShort();
    psCoolDownData.EndTime = MP.ReadLong();
    DataManager.Instance.SetCurItemQuantity(MP.ReadUShort(), MP.ReadUShort(), (byte) 0, 0L);
    if (psCoolDownData.SkillID > (ushort) 0 && !this.CDFinder.ContainsKey(psCoolDownData.SkillID))
    {
      this.CoolDown.Add(psCoolDownData);
    }
    else
    {
      for (int index = 0; index < this.CoolDown.Count; ++index)
      {
        if ((int) this.CoolDown[index].SkillID == (int) psCoolDownData.SkillID)
        {
          this.CoolDown[index] = psCoolDownData;
          break;
        }
      }
    }
    this.CDFinder[psCoolDownData.SkillID] = psCoolDownData.EndTime;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetBuff, 0);
    GUIManager.Instance.HideUILock(EUILock.PetSkill);
    GameManager.OnRefresh(NetworkNews.Refresh_Item);
    this.UseSkillResult(psCoolDownData.SkillID, petId, Result, MP);
  }

  public void Recv_PETSKILL_GETSKILL(MessagePacket MP)
  {
    PSBuffInfoData psBuffInfoData;
    psBuffInfoData.SkillID = MP.ReadUShort();
    psBuffInfoData.Level = MP.ReadByte();
    psBuffInfoData.BeginTime = MP.ReadLong();
    psBuffInfoData.RequireTime = MP.ReadUInt();
    if (psBuffInfoData.BeginTime > 0L)
    {
      if (psBuffInfoData.SkillID > (ushort) 0)
      {
        PetSkillTbl recordByKey = this.PetSkillTable.GetRecordByKey(psBuffInfoData.SkillID);
        if ((int) psBuffInfoData.SkillID == (int) recordByKey.ID && recordByKey.Type == (byte) 1 && recordByKey.Subject == (byte) 2)
        {
          byte index;
          if (this.NegBuff.TryGetValue(psBuffInfoData.SkillID, out index))
          {
            this.BuffInfo[(int) index] = psBuffInfoData;
          }
          else
          {
            this.NegBuff[psBuffInfoData.SkillID] = (byte) this.BuffInfo.Count;
            this.BuffInfo.Add(psBuffInfoData);
          }
          PetBuff.Refreshed = false;
          PetBuff.Update(6);
        }
        else
        {
          byte index;
          if (this.PosBuff.TryGetValue(psBuffInfoData.SkillID, out index))
          {
            this.BuffInfo[(int) index] = psBuffInfoData;
          }
          else
          {
            this.PosBuff[psBuffInfoData.SkillID] = (byte) this.BuffInfo.Count;
            this.BuffInfo.Add(psBuffInfoData);
          }
        }
      }
      else
      {
        this.BuffImmune.BeginTime = psBuffInfoData.BeginTime;
        this.BuffImmune.RequireTime = psBuffInfoData.RequireTime;
      }
      DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Buff);
    }
    this.SetSkillFatigue(MP.ReadUShort(), MP.ReadUShort(), MP.ReadLong());
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetBuff, 1);
  }

  public void Recv_PETSKILL_FATIGUE(MessagePacket MP)
  {
    this.SetSkillFatigue(MP.ReadUShort(), MP.ReadUShort(), MP.ReadLong());
  }

  public void Recv_PETSKILL_BUFFCOMPLETE(MessagePacket MP)
  {
    ushort num = MP.ReadUShort();
    if (num == (ushort) 0)
    {
      this.BuffImmune.BeginTime = (long) (this.BuffImmune.RequireTime = 0U);
    }
    else
    {
      byte index;
      if (this.NegBuff.TryGetValue(num, out index))
      {
        this.BuffInfo[(int) index] = new PSBuffInfoData();
        this.NegBuff.Remove(num);
        PetBuff.Update(6);
      }
      else if (this.PosBuff.TryGetValue(num, out index))
      {
        this.BuffInfo[(int) index] = new PSBuffInfoData();
        this.PosBuff.Remove(num);
      }
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 26);
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Buff);
    this.SkillBuffComplete(num);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_MapMonster, 0);
  }

  public void Recv_PETSKILL_BUFFINFO(MessagePacket MP)
  {
    this.BuffImmune.BeginTime = MP.ReadLong();
    this.BuffImmune.RequireTime = MP.ReadUInt();
    this.PosBuff.Clear();
    this.NegBuff.Clear();
    this.BuffInfo.Clear();
    this.BuffInfoLen = MP.ReadByte();
    this.BuffInfoData = new PSBuffInfoData[(int) this.BuffInfoLen];
    for (byte index1 = 0; (int) index1 < (int) this.BuffInfoLen; ++index1)
    {
      this.BuffInfoData[(int) index1].SkillID = MP.ReadUShort();
      this.BuffInfoData[(int) index1].Level = MP.ReadByte();
      this.BuffInfoData[(int) index1].BeginTime = MP.ReadLong();
      this.BuffInfoData[(int) index1].RequireTime = MP.ReadUInt();
      PetSkillTbl recordByKey = this.PetSkillTable.GetRecordByKey(this.BuffInfoData[(int) index1].SkillID);
      byte index2;
      if (DataManager.Instance.ServerTime < this.BuffInfoData[(int) index1].BeginTime + (long) this.BuffInfoData[(int) index1].RequireTime)
      {
        if (recordByKey.Type == (byte) 1 && recordByKey.Subject == (byte) 2)
        {
          if (this.NegBuff.TryGetValue(this.BuffInfoData[(int) index1].SkillID, out index2))
          {
            this.BuffInfo[(int) index2] = this.BuffInfoData[(int) index1];
          }
          else
          {
            this.NegBuff[this.BuffInfoData[(int) index1].SkillID] = (byte) this.BuffInfo.Count;
            this.BuffInfo.Add(this.BuffInfoData[(int) index1]);
          }
        }
        else if (this.PosBuff.TryGetValue(this.BuffInfoData[(int) index1].SkillID, out index2))
        {
          this.BuffInfo[(int) index2] = this.BuffInfoData[(int) index1];
        }
        else
        {
          this.PosBuff[this.BuffInfoData[(int) index1].SkillID] = (byte) this.BuffInfo.Count;
          this.BuffInfo.Add(this.BuffInfoData[(int) index1]);
        }
      }
    }
    PetBuff.Update(6);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 26);
    DataManager.Instance.AttribVal.UpdateAttrVal(UpdateAttrKind.Buff);
  }

  public void Recv_PETSKILL_COOLDOWN(MessagePacket MP)
  {
    this.CDFinder.Clear();
    this.CoolDown.Clear();
    this.CoolDownLen = MP.ReadByte();
    this.CoolDownData = new PSCoolDownData[(int) this.CoolDownLen];
    for (int index = 0; index < (int) this.CoolDownLen; ++index)
    {
      this.CoolDownData[index].SkillID = MP.ReadUShort();
      this.CoolDownData[index].EndTime = MP.ReadLong();
      if (!this.CDFinder.ContainsKey(this.CoolDownData[index].SkillID))
      {
        this.CoolDown.Add(this.CoolDownData[index]);
      }
      else
      {
        int num = 0;
        while (index < this.CoolDown.Count)
        {
          if ((int) this.CoolDown[index].SkillID == (int) this.CoolDownData[index].SkillID)
          {
            this.CoolDown[index] = this.CoolDownData[index];
            break;
          }
          ++num;
        }
      }
      this.CDFinder[this.CoolDownData[index].SkillID] = this.CoolDownData[index].EndTime;
    }
  }

  public ulong CalTotalPetPower()
  {
    ulong num = 0;
    for (int index = 0; index < (int) this.PetDataCount; ++index)
      num += this.CurPetData[index].getPetPower();
    return num;
  }

  public enum EPetState
  {
    None = 0,
    Training = 1,
    LockLimit = 2,
    Limit = 4,
    Evolution = 8,
    NewPet = 16, // 0x00000010
  }

  public enum EPetTrainDataState
  {
    Empty,
    Training,
    CanReceive,
    Received,
    Closed,
    NextOpen,
  }

  private enum EPetSkillExecuteErrorCode
  {
    EPSEEC_SUCCEED,
    EPSEEC_SUCCEED_SPAWN_SOLDIER,
    EPSEEC_SUCCEED_GET_RSS,
    EPSEEC_SKILL_DATA_NOT_FOUND,
    EPSEEC_IN_CD,
    EPSEEC_UNDEFINE_KIND,
    EPSEEC_NO_PLAYER,
    EPSEEC_BAD_TARGET,
    EPSEEC_PET_NOT_FOUND,
    EPSEEC_PET_DATA_NOT_FOUND,
    EPSEEC_NO_SKILL,
    EPSEEC_NO_SKILL_ITEM,
    EPSEEC_NOT_ACTIVE,
    EPSEEC_SHIELD,
    EPSEEC_UNDEFINE_TARGETTYPE,
    EPSEEC_PET_MARCHING,
    EPSEEC_CONSUMINGVALUE_ZERO,
    EPSEEC_HELPTYPE_ERROR,
    EPSEEC_HELPSTATUS_ERROR,
    EPSEEC_BM_CASTLE_LEVEL_LOW,
    EPSEEC_WALL_MAX,
    EPSEEC_WALL_ONFIRE,
    EPSEEC_NO_NPCCITYREWARD,
    EPSEEC_SOLDIER_MAX,
    EPSEEC_POOR_PETSTAR,
    EPSEEC_NEWBIESHIELD,
    EPSEEC_NO_MARCHING_TROOP,
    EPSEEC_NO_GATHER,
    EPSEEC_HAS_HIGHER_BUFF,
    EPSEEC_NO_MARKET,
    EPSEEC_NO_WARHALL,
    EPSEEC_NO_MISSION,
    EPSEEC_BM_ALL_LOCK,
    EPSEEC_MORALE_LIMIT,
    EPSEEC_DES_OUT_RANGE,
  }

  public enum eSortFlag : byte
  {
    Item = 1,
    PetList = 2,
    RefreshNeedStone = 4,
  }

  private enum PET_STARUP_START_RESULT
  {
    PET_STARUP_START_RESULT_SUCCESS,
    PET_STARUP_START_RESULT_NOTEXIST,
    PET_STARUP_START_RESULT_STARLIMIT,
    PET_STARUP_START_RESULT_DOING,
    PET_STARUP_START_RESULT_STONE,
  }

  private enum PET_STARUP_COMPLETE_RESULT
  {
    PET_STARUP_COMPLETE_RESULT_SUCCESS,
    PET_STARUP_COMPLETE_RESULT_NOTDOING,
    PET_STARUP_COMPLETE_RESULT_NOTYET,
    PET_STARUP_COMPLETE_RESULT_NOTEXIST,
    PET_STARUP_COMPLETE_RESULT_STARLIMIT,
    PET_STARUP_COMPLETE_RESULT_DOING,
    PET_STARUP_COMPLETE_RESULT_STONE,
    PET_STARUP_COMPLETE_RESULT_CRYSTAL,
  }

  private enum PET_STARUP_CANCEL_RESULT
  {
    PET_STARUP_CANCEL_RESULT_SUCCESS,
    PET_STARUP_CANCEL_RESULT_NOTDOING,
  }

  private enum EPetSkillUpgradeErrorCode
  {
    EPSUEC_SUCCEED,
    EPSUEC_PET_NOT_FOUND,
    EPSUEC_PET_DATA_NOT_FOUND,
    EPSUEC_SKILL_DATA_NOT_FOUND,
    EPSUEC_ITEMCOUNT_ERROR,
    EPSUEC_NO_SKILL_ITEM,
    EPSUEC_CAN_NOT_UPGRADE,
    EPSUEC_PETLEVEL_POOR,
    EPSUEC_PET_STAR_POOR,
  }
}
