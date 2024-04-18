// Decompiled with JetBrains decompiler
// Type: _ROLEINFO
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

#nullable disable
public struct _ROLEINFO
{
  public int ReadPackNum;
  public long UserId;
  public CString Name;
  public CString NickName;
  public ushort KingdomTitle;
  public ushort WorldTitle_Country;
  public ushort WorldTitle_Personal;
  public ushort NobilityTitle;
  public ushort Head;
  public byte Level;
  public uint Exp;
  public ushort Morale;
  public long LastMoraleRecoverTime;
  public long AddictionTime;
  public long ServerTime;
  public long LogoutTime;
  public long FirstTimer;
  public ulong Guide;
  public uint GuideEx;
  public uint Diamond;
  public uint PrizeFlag;
  public byte HeroSkillPoint;
  public long LastHeroSPRecoverTime;
  public ushort EnhanceEventHeroID;
  public TimeEventDataType HeroEnhanceEventTime;
  public ushort StarUpEventHeroID;
  public TimeEventDataType HeroStarUpEventTime;
  public ulong BattleID;
  public int CapitalPoint;
  public uint[] m_Soldier;
  public ulong LastChatterTime;
  public uint AllianceChatID;
  public ulong Kills;
  public ulong _Power;
  public uint VipPoint;
  public long BookmarkTime;
  public ushort BookmarkNum;
  public ushort BookmarkLimit;
  public ushort SuccessiveLoginDays;
  public byte TodayUseMoraleItemTimes;
  private byte _VIPLevel;
  public byte VIPLevelMax;
  public byte VipLevelUp;
  public byte LordEquipBagSize;
  public long NextOnlineGiftOpenTime;
  public byte OnlineGiftOpenTimes;
  public ItemSaveDataType OnlineGiftItemID;
  public long LastLordEquipUpdateTime;
  public long LastItemMatUpdateTime;
  public long LastItemGemUpdateTime;
  public ItemLordEquip LordEquipEventData;
  public TimeEventDataType LordEquipEventTime;
  public long LastHitMonsterTime;
  public uint LastHitMonsterSerialNO;
  public byte DamageRateForMonster;
  public uint MonsterPoint;
  public byte NowArmyCoordIndex;
  public uint ArmyCoordFlag;
  public byte bAllianceMobilizationGetPrize;
  private uint _recvMonsterPoint;
  public long LastMonsterPointRecoverTime;
  public ushort MonsterPointRecoverFrequency;
  public uint TPP_Point;
  public uint PaidCrystal;
  public byte DailyFreeScardStar;
  public uint ScardStar;
  public ushort PetSkillFatigue;
  public ushort FatigueRestoreSpeed;
  public long LastPetSkillFatigueTime;
  public SocialFriend Inviter;
  public byte Invitation;

  public byte VIPLevel
  {
    get => this._VIPLevel;
    set
    {
      if (this._VIPLevel == (byte) 2 && (int) value > (int) this._VIPLevel)
        AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.REACH_VIPLV3);
      this._VIPLevel = value;
    }
  }

  public uint recvMonsterPoint
  {
    set
    {
      this._recvMonsterPoint = value;
      this.MonsterPoint = this._recvMonsterPoint;
    }
    get => this._recvMonsterPoint;
  }

  public ulong Power
  {
    set
    {
      this._Power = value;
      AFAdvanceManager.Instance.CheckPower(this._Power);
    }
    get => this._Power;
  }
}
