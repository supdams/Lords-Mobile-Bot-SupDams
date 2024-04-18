// Decompiled with JetBrains decompiler
// Type: NoticeContent
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
[Serializable]
[StructLayout(LayoutKind.Sequential, Pack = 1)]
public class NoticeContent : MailReportHead
{
  public uint OffsetLen;
  public NoticeReport Type;
  public NoticeContent.Enhance NoticeHeroEnhance;
  public NoticeContent.StarUp NoticeHeroStarUp;
  public NoticeContent.JoinAlliance Notice_JoinAlliance;
  public NoticeContent.ApplyAlliance Notice_ApplyAlliance;
  public NoticeContent.ApplyAllianceBeDenied Notice_ApplyAllianceBeDenied;
  public NoticeContent.AllianceDismiss Notice_AllianceDismiss;
  public NoticeContent.AllianceLeaderStepDown Notice_AllianceLeaderStepDown;
  public NoticeContent.ActivityDegreePrize Notice_ActivityDegreePrize;
  public NoticeContent.ActivityRankPrize Notice_ActivityRankPrize;
  public NoticeContent.InviteAlliance Notice_InviteAlliance;
  public NoticeContent.SynLordEquip Notice_SynLordEquip;
  public NoticeContent.RallyNotice Notice_RallyNotice;
  public NoticeContent.CryptNotice Notice_CryptNotice;
  public NoticeContent.AsTargetAlly Notice_AsTargetAlly;
  public NoticeContent.OtherSavedLord Notice_OtherSavedLord;
  public NoticeContent.LordBeingReleased Notice_LordBeingReleased;
  public NoticeContent.LordBeingExecuted Notice_LordBeingExecuted;
  public NoticeContent.OtherBreakPrison Notice_OtherBreakPrison;
  public NoticeContent.RescuedPrisoner Notice_RescuedPrisoner;
  public NoticeContent.RequestRansom Notice_RequestRansom;
  public NoticeContent.ReceivedRansom Notice_ReceivedRansom;
  public NoticeContent.PrisonFull Notice_PrisonFull;
  public NoticeContent.BeQuitAlliance Notice_BeQuitAlliance;
  public NoticeContent.BuyTreasure Notice_BuyTreasure;
  public NoticeContent.RallyNotice_Moving Notice_RallyNotice_Moving;
  public NoticeContent.AtkFailedSelfShield Enotice_AtkFailedSelfShield;
  public NoticeContent.Gifts Enotice_RecivedGift;
  public NoticeContent.PrisonAmnestied Enotice_PrisonAmnestied;
  public NoticeContent.LordBeingAmnestied Enotice_LordBeingAmnestied;
  public NoticeContent.RulerGift Enotice_RulerGift;
  public NoticeContent.AllianceDismissLeader Enotice_DismissAllianceLeader;
  public NoticeContent.Cantonment Enotice_AmbushDefSuccess;
  public NoticeContent.Cantonment Enotice_AmbushDefFailed;
  public NoticeContent.ActivityKVKDegreePrize Enotice_ActivityKVKDegreePrize;
  public NoticeContent.ActivityKVKRankPrize Enotice_ActivityKVKRankPrize;
  public NoticeContent.BuyTreasure Enotice_BuyBlackMarketTreasure;
  public NoticeContent.KickOffTeam Enotice_KickOffTeam;
  public NoticeContent.ActivityKVKRankPrize Enotice_AMRankPrize;
  public NoticeContent.AllianceChangeHomeKingdom Enotice_AllianceHomeKingdom;
  public NoticeContent.WorldKingPrize Enotice_WorldKingPrize;
  public NoticeContent.AddCrystal Enotice_BackendAddCrystal;
  public NoticeContent.AddCrystal Enotice_LoginConpensate;
  public NoticeContent.AddCrystal Enotice_PurchaseConpensate;
  public NoticeContent.RallyNpcCancel Enotice_RallyNPCCancel;
  public NoticeContent.RallyNpcCancel Enotice_RallyNPCCancelInvalid;
  public NoticeContent.LordEquipExpire Enotice_LordEquipExpire;
  public NoticeContent.WorldKingPrize_NotKing Enotice_WorldNotKingPrize;
  public NoticeContent.BuyEmoteTreasure Enotice_BuyEmoteTreasure;
  public NoticeContent.PrisonerUsePoison Enotice_PrisnerUsePoison;
  public NoticeContent.PrisonerPoisonEffect Enotice_PrisnerPoisonEffect;
  public NoticeContent.BackendActivity Enotice_BackendActivity;
  public NoticeContent.BuyCastleSkinreasure Enotice_BuyCastleSkinTreasure;
  public NoticeContent.WorldKingPrize_NotKing Enotice_FederalRankPrize;
  public NoticeContent.BuyTreasure Enotice_TreasureBackPrize;
  public NoticeContent.LookingForStringTable Enotice_LookingForStringTable;
  public NoticeContent.MarchingPet_Cancel Enotice_MarchingPet_Cancel;
  public NoticeContent.PetStarUp ENotice_PetStarUp;
  public NoticeContent.PetSkillEscaped ENotice_PrisonerPetSkillEscaped;
  public NoticeContent.PetSkillEscaped ENotice_LordPetSkillEscaped;
  public NoticeContent.MarchTargetLeave Enotice_ScoutTargetLeave;
  public NoticeContent.MarchTargetLeave Enotice_AttackTargetLeave;
  public NoticeContent.MaintainCompensation Enotice_MaintainCompensation;
  public NoticeContent.BuyRedPocketTreasure Enotice_BuyRedPocketTreasure;
  public NoticeContent.SocialFriendMail Enotice_SocialFriendModify;
  public NoticeContent.ReturnCeremony Enotice_ReturnCeremony;

  public class Enhance
  {
    public ushort HeroID;
    public byte Rank;
    public byte Star;
  }

  public class StarUp
  {
    public ushort HeroID;
    public byte Star;
    public byte Rank;
  }

  public class JoinAlliance
  {
    public string Name;
    public string Tag;
  }

  public class ApplyAlliance
  {
    public string Name;
    public string Tag;
  }

  public class ApplyAllianceBeDenied
  {
    public string Dealer;
    public string Name;
    public string Tag;
  }

  public class AllianceDismiss
  {
    public string Leader;
  }

  public class AllianceLeaderStepDown
  {
    public string OldLeader;
    public string NewLeader;
  }

  public class ActivityDegreePrize
  {
    public byte Degree;
    public byte PrizeNum;
    public NoticeContent.ActPrize[] PrizeData;
    public NoticeContent.ActivityCircleEventType Type;
  }

  public enum ActivityCircleEventType : byte
  {
    EACET_SoloEvent,
    EACET_InfernalEvent,
    EACET_MAX,
  }

  public struct ActPrize
  {
    public byte Rank;
    public ushort ItemID;
    public byte Num;
  }

  public class ActivityRankPrize
  {
    public byte Place;
    public byte PrizeNum;
    public NoticeContent.ActPrize[] PrizeData;
    public NoticeContent.ActivityCircleEventType Type;
  }

  public class InviteAlliance
  {
    public uint AllianceID;
    public string InviterName;
    public string Name;
    public string Tag;
  }

  public class SynLordEquip
  {
    public ushort ItemID;
    public byte Rank;
    public uint AddExp;
  }

  public class RallyNotice
  {
    public string HostName;
    public string HostTag;
    public string TargetName;
    public string TargetTag;
  }

  public class CryptNotice
  {
    public ushort Money;
    public byte Kind;
    public byte Level;
  }

  public class AsTargetAlly
  {
    public string HostName;
    public string HostTag;
    public string TargetName;
  }

  public class OtherSavedLord
  {
    public ushort HomeKingdom;
    public string AllianceTag;
    public string Name;
  }

  public class LordBeingReleased
  {
    public ushort HomeKingdom;
    public string AllianceTag;
    public string Name;
  }

  public class LordBeingExecuted
  {
    public ushort HomeKingdom;
    public string AllianceTag;
    public string Name;
  }

  public class OtherBreakPrison
  {
    public ushort HomeKingdom;
    public string AllianceTag;
    public string Name;
  }

  public class RescuedPrisoner
  {
    public ushort HomeKingdom;
    public string AllianceTag;
    public string Name;
    public byte PrisonerNum;
    public uint ClaimReward;
  }

  public class RequestRansom
  {
    public uint Ransom;
  }

  public class ReceivedRansom
  {
    public uint Ransom;
  }

  public class PrisonFull
  {
    public ushort HomeKingdom;
    public string AllianceTag;
    public string Name;
  }

  public class BeQuitAlliance
  {
    public string Dealer;
    public string Alliance;
    public string AllianceTag;
  }

  public class TreasureAllianceGift
  {
    public ushort ItemID;
    public ushort ItemNum;
  }

  public class ComboBoxTBItem
  {
    public ushort ItemID;
    public ushort ItemNum;
    public byte ItemRank;
  }

  public class BuyTreasure
  {
    public uint Crystal;
    public uint BonusCrystal;
    public NoticeContent.TreasureAllianceGift[] Gift;
    public byte ItemNum;
    public NoticeContent.ComboBoxTBItem[] Item;
    public byte GiftTop;
  }

  public class RallyNotice_Moving
  {
    public string HostName;
    public string HostTag;
    public string TargetName;
    public string TargetTag;
  }

  public class AtkFailedSelfShield
  {
    public byte FailedType;
    public ushort KingdomID;
    public ushort zoneID;
    public byte pointID;
  }

  public class Gifts
  {
    public string GiftsName;
    public string GiftsTag;
    public NoticeContent.TreasureAllianceGift Item;
  }

  public class LordBeingAmnestied
  {
    public ushort KingsHomeKingdom;
    public string KingdomTag;
    public string KingdomName;
    public ushort WardensHomeKingdom;
    public string Tag;
    public string Name;
  }

  public class PrisonAmnestied
  {
    public ushort KingsHomeKingdom;
    public string KingdomTag;
    public string KingdomName;
  }

  public class RulerGift
  {
    public byte RulerKind;
    public ushort RulerAllianceKingdomID;
    public string Tag;
    public string Name;
    public byte GiftKindNum;
    public NoticeContent.TreasureAllianceGift[] Gifts;
  }

  public class AllianceDismissLeader
  {
    public string OldLeader;
    public string NewLeader;
    public byte OffLineDay;
  }

  public class Cantonment
  {
    public string AmbushName;
    public ushort AtkPlayerHomeKingdom;
    public string AtkPlayerAllianceTag;
    public string AtkPlayerName;
  }

  public class ActivityKVKDegreePrize
  {
    public EActivityType ActType;
    public EActivityKingdomEventType EventType;
    public byte Degree;
    public byte PrizeNum;
    public NoticeContent.ActPrize[] PrizeData;
  }

  public class ActivityKVKRankPrize
  {
    public EActivityType ActType;
    public EActivityKingdomEventType EventType;
    public byte Place;
    public byte PrizeNum;
    public NoticeContent.ActPrize[] PrizeData;
  }

  public class KickOffTeam
  {
    public string HostName;
    public string AllianceTag;
  }

  public class AllianceChangeHomeKingdom
  {
    public string AllianceTag;
    public string Leader;
    public ushort HomeKingdom;
  }

  public class WorldKingPrize
  {
    public byte PrizeNum;
    public NoticeContent.ActPrize[] PrizeData;
  }

  public class AddCrystal
  {
    public uint Crystal;
  }

  public class RallyNpcCancel
  {
    public string HostName;
    public string AllianceTag;
    public byte NPCLevel;
    public ushort NPCID;
  }

  public class LordEquipExpire
  {
    public ushort ItemID;
    public byte Rank;
  }

  public class WorldKingPrize_NotKing
  {
    public byte Place;
    public byte PrizeNum;
    public NoticeContent.ActPrize[] PrizeData;
  }

  public class BuyEmoteTreasure
  {
    public ushort ItemID;
    public byte ItemNum;
  }

  public class PrisonerUsePoison
  {
    public ushort HomeKingdom;
    public string AllianceTag;
    public string Name;
    public uint EffectTime;
  }

  public class PrisonerPoisonEffect
  {
    public ushort HomeKingdom;
    public string AllianceTag;
    public string Name;
  }

  public class BackendActivity
  {
    public uint Crystal;
    public byte ItemNum;
    public NoticeContent.ComboBoxTBItem[] Item;
  }

  public class BuyCastleSkinreasure
  {
    public ushort CastleSkinID;
    public ushort ItemID;
    public byte ItemNum;
  }

  public class MarchingPet_Cancel
  {
    public byte HasTarget;
    public ushort HomeKingdom;
    public string AllianceTag;
    public string Name;
    public ushort PetID;
    public ushort Skill_ID;
    public byte Skill_LV;
  }

  public class LookingForStringTable
  {
    public uint Title;
    public uint Content;
  }

  public class PetSkillEscaped
  {
    public ushort PetID;
    public ushort Skill_ID;
    public byte Skill_LV;
  }

  public class PetStarUp
  {
    public ushort PetID;
    public byte PetStar;
  }

  public class MarchTargetLeave
  {
    public uint OffsetLen;
    public ushort HomeKingdom;
    public string AllianceTag;
    public string Name;
  }

  public class MaintainCompensation
  {
    public ushort MailTitleStrID;
    public ushort MailContentStrID;
    public uint Crystal;
    public byte ItemNum;
    public NoticeContent.ComboBoxTBItem[] Item;
  }

  public class BuyRedPocketTreasure
  {
    public ushort StringID;
  }

  public class SocialFriendMail
  {
    public byte RemoveType;
    public string TargetName;
    public string PlayerName;
    public string PlayerTag;
  }

  public class ReturnCeremony
  {
    public uint Crystal;
    public byte ItemNum;
    public NoticeContent.ComboBoxTBItem[] Item;
  }
}
