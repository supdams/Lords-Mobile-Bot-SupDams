// Decompiled with JetBrains decompiler
// Type: ArenaManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class ArenaManager
{
  private static ArenaManager instance;
  public List<ArenaReportDataType> m_ArenaReportData = new List<ArenaReportDataType>(20);
  public byte[] RepoetUnRead = new byte[20];
  public byte RepoetUnReadCount;
  public byte BattleResult;
  public uint m_ArenaPlace;
  public ushort[] m_ArenaDefHero = new ushort[5];
  public byte m_ArenaTodayChallenge;
  public byte m_ArenaTodayResetChallenge;
  public long m_ArenaLastChallengeTime;
  public uint m_ArenaCrystalPrize;
  public ArenaTargetDataType[] m_ArenaTarget = new ArenaTargetDataType[3];
  public byte m_ArenaNewReportNum;
  public byte[] m_NowArenaTopicID = new byte[2];
  public long m_NowArenaTopicEndTime;
  public ArenaTopicEffectDataType[] m_NowTopicEffect = new ArenaTopicEffectDataType[2];
  public byte[] m_NextArenaTopicID = new byte[2];
  public long m_NextArenaTopicBeginTime;
  public ArenaTopicEffectDataType[] m_NextTopicEffect = new ArenaTopicEffectDataType[2];
  public uint m_ArenaHistoryPlace;
  public ushort[] m_TodayChallengeCost = new ushort[12]
  {
    (ushort) 250,
    (ushort) 400,
    (ushort) 700,
    (ushort) 1200,
    (ushort) 1900,
    (ushort) 2800,
    (ushort) 3900,
    (ushort) 5200,
    (ushort) 6700,
    (ushort) 8400,
    (ushort) 10300,
    (ushort) 12500
  };
  public bool bArenaOpenGet = true;
  public bool bArenaKVK;
  public byte m_ArenaTargetIdx;
  public ushort[] m_ArenaTargetHero = new ushort[5];
  public ArenaTargetDataType m_ArenaTargetHint = new ArenaTargetDataType();
  public ArenaReportDataType ArenaPlayingData = new ArenaReportDataType();
  public long m_ArenaClose_CDTime;
  public EActivityType m_ArenaClose_ActivityType = EActivityType.EAT_MAX;
  public float m_ArenaPlacedropTime;
  public bool bShowArenaPlacedrop;
  public byte m_ArenaExtraChallenge;

  private ArenaManager()
  {
  }

  public static ArenaManager Instance
  {
    get
    {
      if (ArenaManager.instance == null)
        ArenaManager.instance = new ArenaManager();
      return ArenaManager.instance;
    }
  }

  public void RecvArena_Info(MessagePacket MP)
  {
    this.m_ArenaPlace = MP.ReadUInt();
    Array.Clear((Array) this.m_ArenaDefHero, 0, this.m_ArenaDefHero.Length);
    Array.Clear((Array) this.m_ArenaTarget, 0, this.m_ArenaTarget.Length);
    for (int index = 0; index < 5; ++index)
      this.m_ArenaDefHero[index] = MP.ReadUShort();
    this.m_ArenaTodayChallenge = MP.ReadByte();
    this.m_ArenaTodayResetChallenge = MP.ReadByte();
    this.m_ArenaLastChallengeTime = MP.ReadLong();
    this.m_ArenaCrystalPrize = MP.ReadUInt();
    for (int index1 = 0; index1 < 3; ++index1)
    {
      this.m_ArenaTarget[index1].Head = MP.ReadUShort();
      this.m_ArenaTarget[index1].Name = MP.ReadString(13);
      this.m_ArenaTarget[index1].AllianceTagTag = MP.ReadString(3);
      this.m_ArenaTarget[index1].Place = MP.ReadUInt();
      if (this.m_ArenaTarget[index1].HeroData == null)
        this.m_ArenaTarget[index1].HeroData = new ArenaTargetHeroDataType[5];
      for (int index2 = 0; index2 < 5; ++index2)
      {
        this.m_ArenaTarget[index1].HeroData[index2].ID = MP.ReadUShort();
        this.m_ArenaTarget[index1].HeroData[index2].Level = MP.ReadByte();
        this.m_ArenaTarget[index1].HeroData[index2].Rank = MP.ReadByte();
        this.m_ArenaTarget[index1].HeroData[index2].Star = MP.ReadByte();
        this.m_ArenaTarget[index1].HeroData[index2].Equip = MP.ReadByte();
      }
    }
    this.m_ArenaNewReportNum = MP.ReadByte();
    this.m_NowArenaTopicID[0] = MP.ReadByte();
    this.m_NowArenaTopicID[1] = MP.ReadByte();
    this.m_NowArenaTopicEndTime = MP.ReadLong();
    this.m_NowTopicEffect[0].Effect = MP.ReadUShort();
    this.m_NowTopicEffect[0].Value = MP.ReadUShort();
    this.m_NowTopicEffect[1].Effect = MP.ReadUShort();
    this.m_NowTopicEffect[1].Value = MP.ReadUShort();
    this.m_NextArenaTopicID[0] = MP.ReadByte();
    this.m_NextArenaTopicID[1] = MP.ReadByte();
    this.m_NextArenaTopicBeginTime = MP.ReadLong();
    this.m_NextTopicEffect[0].Effect = MP.ReadUShort();
    this.m_NextTopicEffect[0].Value = MP.ReadUShort();
    this.m_NextTopicEffect[1].Effect = MP.ReadUShort();
    this.m_NextTopicEffect[1].Value = MP.ReadUShort();
    this.m_ArenaHistoryPlace = MP.ReadUInt();
    this.m_ArenaExtraChallenge = MP.ReadByte();
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 6);
    DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) 28, this.GetHeroAstrologyNum());
    if (this.m_ArenaHistoryPlace <= 0U || this.m_ArenaHistoryPlace >= (uint) ushort.MaxValue)
      return;
    DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) 29, (ushort) ((uint) ushort.MaxValue - this.m_ArenaHistoryPlace));
  }

  public ushort GetHeroAstrologyNum()
  {
    ushort heroAstrologyNum = 0;
    for (int index = 0; index < 5; ++index)
    {
      if (this.m_ArenaDefHero[index] != (ushort) 0 && this.CheckHeroAstrology(this.m_ArenaDefHero[index]))
        ++heroAstrologyNum;
    }
    return heroAstrologyNum;
  }

  public void RecvArena_Report(MessagePacket MP)
  {
    byte num1 = MP.ReadByte();
    GUIManager.Instance.HideUILock(EUILock.Arena);
    byte num2 = MP.ReadByte();
    ArenaReportDataType arenaReportDataType = new ArenaReportDataType();
    int index1 = 0;
    for (int index2 = 0; index2 < (int) num2 && index2 < 10; ++index2)
    {
      if (!this.bArenaOpenGet)
      {
        switch (num1)
        {
          case 0:
          case 2:
            index1 = (int) this.RepoetUnRead[index2 + 10];
            break;
          case 1:
          case 3:
            index1 = (int) this.RepoetUnRead[index2];
            break;
        }
        arenaReportDataType = this.m_ArenaReportData[index1];
      }
      arenaReportDataType.MyHeroData = new ArenaHeroDataType[5];
      arenaReportDataType.EnemyHeroData = new ArenaHeroDataType[5];
      arenaReportDataType.TopicID = new byte[2];
      arenaReportDataType.TopicEffect = new ArenaTopicEffectDataType[2];
      arenaReportDataType.SimulatorVersion = MP.ReadUInt();
      arenaReportDataType.SimulatorPatchNo = MP.ReadUInt();
      arenaReportDataType.Flag = MP.ReadByte();
      arenaReportDataType.TopicID[0] = MP.ReadByte();
      arenaReportDataType.TopicID[1] = MP.ReadByte();
      arenaReportDataType.TopicEffect[0].Effect = MP.ReadUShort();
      arenaReportDataType.TopicEffect[0].Value = MP.ReadUShort();
      arenaReportDataType.TopicEffect[1].Effect = MP.ReadUShort();
      arenaReportDataType.TopicEffect[1].Value = MP.ReadUShort();
      arenaReportDataType.ChangePlace = MP.ReadUInt();
      for (int index3 = 0; index3 < 5; ++index3)
      {
        arenaReportDataType.MyHeroData[index3].SkillLV = new byte[4];
        arenaReportDataType.MyHeroData[index3].ID = MP.ReadUShort();
        arenaReportDataType.MyHeroData[index3].Level = MP.ReadByte();
        arenaReportDataType.MyHeroData[index3].Rank = MP.ReadByte();
        arenaReportDataType.MyHeroData[index3].Star = MP.ReadByte();
        arenaReportDataType.MyHeroData[index3].Equip = MP.ReadByte();
        for (int index4 = 0; index4 < 4; ++index4)
          arenaReportDataType.MyHeroData[index3].SkillLV[index4] = MP.ReadByte();
      }
      arenaReportDataType.EnemyHead = MP.ReadUShort();
      arenaReportDataType.EnemyName = MP.ReadString(13);
      arenaReportDataType.EnemyAllianceTag = MP.ReadString(3);
      for (int index5 = 0; index5 < 5; ++index5)
      {
        arenaReportDataType.EnemyHeroData[index5].SkillLV = new byte[4];
        arenaReportDataType.EnemyHeroData[index5].ID = MP.ReadUShort();
        arenaReportDataType.EnemyHeroData[index5].Level = MP.ReadByte();
        arenaReportDataType.EnemyHeroData[index5].Rank = MP.ReadByte();
        arenaReportDataType.EnemyHeroData[index5].Star = MP.ReadByte();
        arenaReportDataType.EnemyHeroData[index5].Equip = MP.ReadByte();
        for (int index6 = 0; index6 < 4; ++index6)
          arenaReportDataType.EnemyHeroData[index5].SkillLV[index6] = MP.ReadByte();
      }
      arenaReportDataType.RandomSeed = MP.ReadUShort();
      arenaReportDataType.RandomGap = MP.ReadByte();
      arenaReportDataType.PrimarySide = MP.ReadByte();
      arenaReportDataType.Time = MP.ReadLong();
      if (!this.bArenaOpenGet)
      {
        this.m_ArenaReportData[index1] = arenaReportDataType;
      }
      else
      {
        if (this.m_ArenaReportData.Count == 20)
          this.m_ArenaReportData.RemoveAt(0);
        this.m_ArenaReportData.Add(arenaReportDataType);
      }
    }
    if (num1 != (byte) 2 && num1 != (byte) 3)
      return;
    if (this.bArenaOpenGet)
      this.bArenaOpenGet = false;
    this.m_ArenaNewReportNum = (byte) 0;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena_Replay, 1);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public void RecvArena_Refresh_Target(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Arena);
    byte num = MP.ReadByte();
    if (MP.ReadByte() != (byte) 0)
      return;
    for (int index1 = 0; index1 < 3; ++index1)
    {
      this.m_ArenaTarget[index1].Head = MP.ReadUShort();
      this.m_ArenaTarget[index1].Name = MP.ReadString(13);
      this.m_ArenaTarget[index1].AllianceTagTag = MP.ReadString(3);
      this.m_ArenaTarget[index1].Place = MP.ReadUInt();
      for (int index2 = 0; index2 < 5; ++index2)
      {
        this.m_ArenaTarget[index1].HeroData[index2].ID = MP.ReadUShort();
        this.m_ArenaTarget[index1].HeroData[index2].Level = MP.ReadByte();
        this.m_ArenaTarget[index1].HeroData[index2].Rank = MP.ReadByte();
        this.m_ArenaTarget[index1].HeroData[index2].Star = MP.ReadByte();
        this.m_ArenaTarget[index1].HeroData[index2].Equip = MP.ReadByte();
      }
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 4);
    if (num != (byte) 4)
      return;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 7);
    if (!((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject.activeSelf)
      return;
    for (int index = 0; index < 3; ++index)
    {
      if (this.m_ArenaTargetHint.Name == this.m_ArenaTarget[index].Name)
      {
        this.m_ArenaTargetHint = this.m_ArenaTarget[index];
        break;
      }
    }
    GUIManager.Instance.m_Arena_Hint.UpdateUI();
  }

  public void RecvArena_Set_DefHero(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Arena);
    if (MP.ReadByte() != (byte) 0)
      return;
    for (int index = 0; index < 5; ++index)
      this.m_ArenaDefHero[index] = MP.ReadUShort();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 7);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 5);
    DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) 28, this.GetHeroAstrologyNum());
  }

  public void RecvArena_Challenge(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Arena);
    switch (MP.ReadByte())
    {
      case 0:
        this.BattleResult = MP.ReadByte();
        this.m_ArenaPlace = MP.ReadUInt();
        this.m_ArenaTodayChallenge = MP.ReadByte();
        this.m_ArenaLastChallengeTime = MP.ReadLong();
        DataManager instance = DataManager.Instance;
        instance.KingOldLv = instance.RoleAttr.Level;
        instance.KingOldExp = instance.RoleAttr.Exp;
        DataManager.StageDataController.UpdateRoleAttrLevel(MP.ReadByte());
        DataManager.StageDataController.UpdateRoleAttrExp(MP.ReadUInt());
        int num1 = (int) MP.ReadUInt();
        for (int index = 0; index < 5; ++index)
        {
          ushort num2 = MP.ReadUShort();
          if (num2 != (ushort) 0 && instance.curHeroData.ContainsKey((uint) num2))
          {
            CurHeroData curHeroData = instance.curHeroData[(uint) num2];
            instance.heroLv[index] = curHeroData.Level;
            instance.heroExp[index] = curHeroData.Exp;
            int num3 = (int) instance.UpdateHeroAttr(num2, MP);
          }
          else
          {
            int num4 = (int) MP.ReadByte();
            int num5 = (int) MP.ReadUInt();
            int num6 = (int) MP.ReadUInt();
          }
        }
        ArenaReportDataType arenaReportDataType = new ArenaReportDataType();
        arenaReportDataType.MyHeroData = new ArenaHeroDataType[5];
        arenaReportDataType.EnemyHeroData = new ArenaHeroDataType[5];
        arenaReportDataType.TopicID = new byte[2];
        arenaReportDataType.TopicEffect = new ArenaTopicEffectDataType[2];
        arenaReportDataType.SimulatorVersion = MP.ReadUInt();
        arenaReportDataType.SimulatorPatchNo = MP.ReadUInt();
        arenaReportDataType.Flag = MP.ReadByte();
        arenaReportDataType.TopicID[0] = MP.ReadByte();
        arenaReportDataType.TopicID[1] = MP.ReadByte();
        arenaReportDataType.TopicEffect[0].Effect = MP.ReadUShort();
        arenaReportDataType.TopicEffect[0].Value = MP.ReadUShort();
        arenaReportDataType.TopicEffect[1].Effect = MP.ReadUShort();
        arenaReportDataType.TopicEffect[1].Value = MP.ReadUShort();
        arenaReportDataType.ChangePlace = MP.ReadUInt();
        for (int index1 = 0; index1 < 5; ++index1)
        {
          arenaReportDataType.MyHeroData[index1].SkillLV = new byte[4];
          arenaReportDataType.MyHeroData[index1].ID = MP.ReadUShort();
          arenaReportDataType.MyHeroData[index1].Level = MP.ReadByte();
          arenaReportDataType.MyHeroData[index1].Rank = MP.ReadByte();
          arenaReportDataType.MyHeroData[index1].Star = MP.ReadByte();
          arenaReportDataType.MyHeroData[index1].Equip = MP.ReadByte();
          for (int index2 = 0; index2 < 4; ++index2)
            arenaReportDataType.MyHeroData[index1].SkillLV[index2] = MP.ReadByte();
        }
        arenaReportDataType.EnemyHead = MP.ReadUShort();
        arenaReportDataType.EnemyName = MP.ReadString(13);
        arenaReportDataType.EnemyAllianceTag = MP.ReadString(3);
        for (int index3 = 0; index3 < 5; ++index3)
        {
          arenaReportDataType.EnemyHeroData[index3].SkillLV = new byte[4];
          arenaReportDataType.EnemyHeroData[index3].ID = MP.ReadUShort();
          arenaReportDataType.EnemyHeroData[index3].Level = MP.ReadByte();
          arenaReportDataType.EnemyHeroData[index3].Rank = MP.ReadByte();
          arenaReportDataType.EnemyHeroData[index3].Star = MP.ReadByte();
          arenaReportDataType.EnemyHeroData[index3].Equip = MP.ReadByte();
          for (int index4 = 0; index4 < 4; ++index4)
            arenaReportDataType.EnemyHeroData[index3].SkillLV[index4] = MP.ReadByte();
        }
        arenaReportDataType.RandomSeed = MP.ReadUShort();
        arenaReportDataType.RandomGap = MP.ReadByte();
        arenaReportDataType.PrimarySide = MP.ReadByte();
        arenaReportDataType.Time = MP.ReadLong();
        if (!this.bArenaOpenGet)
        {
          if (this.m_ArenaReportData.Count == 20)
            this.m_ArenaReportData.RemoveAt(0);
          bool flag = false;
          if (this.RepoetUnReadCount > (byte) 0 && this.RepoetUnRead[0] == (byte) 0)
          {
            flag = true;
            --this.RepoetUnReadCount;
          }
          if (flag)
          {
            for (int index = 0; index < (int) this.RepoetUnReadCount && this.RepoetUnReadCount < (byte) 19; ++index)
              this.RepoetUnRead[index] = --this.RepoetUnRead[index + 1];
          }
          else
          {
            for (int index = 0; index < (int) this.RepoetUnReadCount && index < this.RepoetUnRead.Length; ++index)
              this.RepoetUnRead[index] = --this.RepoetUnRead[index];
          }
          this.m_ArenaReportData.Add(arenaReportDataType);
        }
        this.m_ArenaHistoryPlace = MP.ReadUInt();
        GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 2);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_TreasureBox, 5);
        if (this.m_ArenaHistoryPlace > 0U && this.m_ArenaHistoryPlace < (uint) ushort.MaxValue)
          DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) 29, (ushort) ((uint) ushort.MaxValue - this.m_ArenaHistoryPlace));
        if (((int) arenaReportDataType.Flag & 2) == 0 || !((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_BattleHeroSelect) != (UnityEngine.Object) null))
          return;
        if (WarManager.CheckVersion(arenaReportDataType.SimulatorVersion, arenaReportDataType.SimulatorPatchNo))
        {
          this.ArenaPlayingData = arenaReportDataType;
          BattleController.BattleMode = EBattleMode.PVP;
          GUIManager.Instance.bClearWindowStack = false;
          if (GUIManager.Instance.m_WindowStack.Count > 0)
            GUIManager.Instance.m_WindowStack.RemoveAt(GUIManager.Instance.m_WindowStack.Count - 1);
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 0);
          DataManager.Instance.SetArenaHeroBattleDataSave();
          return;
        }
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 6);
        return;
      case 6:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9157U), (ushort) byte.MaxValue);
        break;
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 6);
  }

  public void RecvArena_ReSet_Todaychallenge(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Arena);
    switch (MP.ReadByte())
    {
      case 0:
        this.m_ArenaTodayChallenge = (byte) 0;
        this.m_ArenaTodayResetChallenge = MP.ReadByte();
        GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 1);
        GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
        break;
      case 1:
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9163U), (ushort) byte.MaxValue);
        break;
    }
  }

  public void RecvArena_ReSet_Challenge_CD(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Arena);
    if (MP.ReadByte() != (byte) 0)
      return;
    this.m_ArenaLastChallengeTime = MP.ReadLong();
    GUIManager.Instance.SetRoleAttrDiamond(MP.ReadUInt(), (ushort) 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 2);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
  }

  public void RecvArena_Arena_GetPrize(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Arena);
    if (MP.ReadByte() != (byte) 0)
      return;
    this.m_ArenaCrystalPrize = 0U;
    uint diamond = MP.ReadUInt();
    GUIManager.Instance.m_SpeciallyEffect.mDiamondValue = diamond - DataManager.Instance.RoleAttr.Diamond;
    GUIManager.Instance.SetRoleAttrDiamond(diamond, (ushort) 0);
    GUIManager.Instance.CloseMenu(EGUIWindow.UI_TreasureBox);
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    GameManager.OnRefresh();
    GUIManager.Instance.mStartV2 = new Vector2(GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
    GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, GUIManager.Instance.mStartV2, SpeciallyEffect_Kind.Diamond, ItemID: (ushort) 0, EndTime: 2f);
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 9);
    AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
  }

  public void RecvArena_Update_Topic(MessagePacket MP)
  {
    this.m_NowArenaTopicID[0] = MP.ReadByte();
    this.m_NowArenaTopicID[1] = MP.ReadByte();
    this.m_NowArenaTopicEndTime = MP.ReadLong();
    this.m_NowTopicEffect[0].Effect = MP.ReadUShort();
    this.m_NowTopicEffect[0].Value = MP.ReadUShort();
    this.m_NowTopicEffect[1].Effect = MP.ReadUShort();
    this.m_NowTopicEffect[1].Value = MP.ReadUShort();
    this.m_NextArenaTopicID[0] = MP.ReadByte();
    this.m_NextArenaTopicID[1] = MP.ReadByte();
    this.m_NextArenaTopicBeginTime = MP.ReadLong();
    this.m_NextTopicEffect[0].Effect = MP.ReadUShort();
    this.m_NextTopicEffect[0].Value = MP.ReadUShort();
    this.m_NextTopicEffect[1].Effect = MP.ReadUShort();
    this.m_NextTopicEffect[1].Value = MP.ReadUShort();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 10);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena_Info, 1);
    DataManager.MissionDataManager.CheckChanged(eMissionKind.Record, (ushort) 28, this.GetHeroAstrologyNum());
  }

  public void RecvArena_Update_Single_target(MessagePacket MP)
  {
    byte index1 = (byte) Mathf.Clamp((int) MP.ReadByte(), 0, this.m_ArenaTarget.Length - 1);
    this.m_ArenaTarget[(int) index1].Head = MP.ReadUShort();
    this.m_ArenaTarget[(int) index1].Name = MP.ReadString(13);
    this.m_ArenaTarget[(int) index1].AllianceTagTag = MP.ReadString(3);
    this.m_ArenaTarget[(int) index1].Place = MP.ReadUInt();
    for (int index2 = 0; index2 < 5; ++index2)
    {
      this.m_ArenaTarget[(int) index1].HeroData[index2].ID = MP.ReadUShort();
      this.m_ArenaTarget[(int) index1].HeroData[index2].Level = MP.ReadByte();
      this.m_ArenaTarget[(int) index1].HeroData[index2].Rank = MP.ReadByte();
      this.m_ArenaTarget[(int) index1].HeroData[index2].Star = MP.ReadByte();
      this.m_ArenaTarget[(int) index1].HeroData[index2].Equip = MP.ReadByte();
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Arena, 8, (int) index1);
  }

  public void SendArena_Report()
  {
    GUIManager.Instance.ShowUILock(EUILock.Arena);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_REPORT;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void SendArena_Refresh_Target(byte Kind)
  {
    if (Kind == (byte) 1)
      GUIManager.Instance.ShowUILock(EUILock.Arena);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_REFRESH_TARGET;
    messagePacket.AddSeqId();
    messagePacket.Add(Kind);
    messagePacket.Send();
  }

  public void SendArena_Set_DefHero(ushort[] mHero)
  {
    GUIManager.Instance.ShowUILock(EUILock.Arena);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_SET_DEFHERO;
    messagePacket.AddSeqId();
    for (int index = 0; index < 5; ++index)
      messagePacket.Add(mHero[index]);
    messagePacket.Send();
  }

  public void SendArena_Challenge(byte TargetIdx)
  {
    GUIManager.Instance.ShowUILock(EUILock.Arena);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_CHALLENGE;
    messagePacket.AddSeqId();
    messagePacket.Add(TargetIdx);
    messagePacket.Add(this.m_ArenaTarget[(int) TargetIdx].Place);
    messagePacket.Add(this.m_ArenaTarget[(int) TargetIdx].Name, 13);
    for (int index = 0; index < 5; ++index)
      messagePacket.Add(this.m_ArenaTargetHero[index]);
    messagePacket.Send();
  }

  public void SendArena_ReSet_TodayChallenge()
  {
    GUIManager.Instance.ShowUILock(EUILock.Arena);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_RESET_TODAYCHALLENGE;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void SendArena_ReSet_Challenge_CD()
  {
    GUIManager.Instance.ShowUILock(EUILock.Arena);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_RESET_CHALLENGE_CD;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void SendArena_Arena_GetPrize()
  {
    GUIManager.Instance.ShowUILock(EUILock.Arena);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_GET_PRIZE;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public bool CheckHeroAstrology(ushort HeroID)
  {
    bool flag = false;
    ArenaHeroTopic recordByKey = DataManager.Instance.ArenaHeroTopicData.GetRecordByKey(HeroID);
    if (this.m_NowArenaTopicID[0] != (byte) 0 && ((int) (recordByKey.Value >> (int) this.m_NowArenaTopicID[0] - 1) & 1) == 1)
      flag = true;
    if (!flag && this.m_NowArenaTopicID[1] != (byte) 0 && ((int) (recordByKey.Value >> (int) this.m_NowArenaTopicID[1] - 1) & 1) == 1)
      flag = true;
    return flag;
  }

  public bool CheckHeroAstrology(ushort HeroID, ushort Topic)
  {
    bool flag = false;
    ArenaHeroTopic recordByKey = DataManager.Instance.ArenaHeroTopicData.GetRecordByKey(HeroID);
    if (Topic != (ushort) 0 && ((int) (recordByKey.Value >> (int) Topic - 1) & 1) == 1)
      flag = true;
    return flag;
  }

  public void GetHeroAstrology(CString Str1, CString Str2)
  {
    DataManager instance = DataManager.Instance;
    if (this.m_NowArenaTopicID[0] != (byte) 0)
      Str1.Append(instance.mStringTable.GetStringByID(9200U + (uint) this.m_NowArenaTopicID[0]));
    if (this.m_NowArenaTopicID[1] == (byte) 0)
      return;
    Str2.Append(instance.mStringTable.GetStringByID(9200U + (uint) this.m_NowArenaTopicID[1]));
  }

  public ushort GetNowCrystal()
  {
    ushort nowCrystal = 0;
    for (int tableCount = DataManager.Instance.ArenaRewardData.TableCount; tableCount > 0; --tableCount)
    {
      ArenaReward recordByIndex = DataManager.Instance.ArenaRewardData.GetRecordByIndex(tableCount - 1);
      if (this.m_ArenaPlace >= (uint) recordByIndex.Value1 && this.m_ArenaPlace <= (uint) recordByIndex.Value2)
      {
        nowCrystal = recordByIndex.Crystal;
        break;
      }
    }
    return nowCrystal;
  }

  public uint GetAllPower(byte Kind, int TargetIdx = 0)
  {
    uint allPower = 0;
    ArenaTargetDataType arenaTargetDataType1 = new ArenaTargetDataType();
    ArenaTargetDataType arenaTargetDataType2 = Kind != (byte) 0 ? this.m_ArenaTarget[TargetIdx] : this.m_ArenaTargetHint;
    for (int index = 0; index < 5; ++index)
    {
      if (arenaTargetDataType2.HeroData != null)
        allPower += this.GetPower(arenaTargetDataType2.HeroData[index]);
    }
    return allPower;
  }

  public uint GetPower(ArenaTargetHeroDataType HeroData)
  {
    uint power = 0;
    if (HeroData.ID == (ushort) 0)
      return power;
    CalcAttrDataType CalcAttrData = new CalcAttrDataType();
    byte[] SkillLV = new byte[4];
    ushort[] pAttr1 = new ushort[28];
    ushort[] pAttr2 = new ushort[28];
    uint HP1 = 0;
    CalcAttrData.SkillLV1 = HeroData.Level;
    if (HeroData.Rank >= (byte) 2)
      CalcAttrData.SkillLV2 = HeroData.Level;
    if (HeroData.Rank >= (byte) 4)
      CalcAttrData.SkillLV3 = (byte) ((uint) HeroData.Level - 20U);
    if (HeroData.Rank >= (byte) 7)
      CalcAttrData.SkillLV4 = (byte) ((uint) HeroData.Level - 40U);
    SkillLV[0] = HeroData.Level;
    if (HeroData.Rank >= (byte) 2)
      SkillLV[1] = HeroData.Level;
    if (HeroData.Rank >= (byte) 4)
      SkillLV[2] = (byte) ((uint) HeroData.Level - 20U);
    if (HeroData.Rank >= (byte) 7)
      SkillLV[3] = (byte) ((uint) HeroData.Level - 40U);
    CalcAttrData.LV = HeroData.Level;
    CalcAttrData.Star = HeroData.Star;
    CalcAttrData.Enhance = HeroData.Rank;
    CalcAttrData.Equip = HeroData.Equip;
    uint HP2 = 0;
    Array.Clear((Array) pAttr1, 0, pAttr1.Length);
    BSInvokeUtil.getInstance.setCalculateHeroEquipEffect(HeroData.ID, CalcAttrData.Enhance, CalcAttrData.Equip, ref HP2, pAttr1);
    Array.Clear((Array) pAttr2, 0, pAttr2.Length);
    BSInvokeUtil.getInstance.setCalculateAttribute(HeroData.ID, ref CalcAttrData, ref HP1, pAttr2);
    return BSInvokeUtil.getInstance.updateFightScore(HeroData.ID, HP1, pAttr2, SkillLV);
  }

  public ushort CheckArenaClose()
  {
    ushort num = 0;
    if (this.bArenaKVK)
      num = (ushort) 9109;
    else if (this.m_ArenaClose_CDTime != 0L)
    {
      switch (this.m_ArenaClose_ActivityType)
      {
        case EActivityType.EAT_KingOfTheWorld:
          num = (ushort) 10018;
          break;
        case EActivityType.EAT_FederalEvent:
          num = (ushort) 11107;
          break;
      }
    }
    return num;
  }

  ~ArenaManager()
  {
  }

  public bool SetReportIDToPlayingData(int id)
  {
    if (this.m_ArenaReportData.Count <= id)
      return false;
    id = this.m_ArenaReportData.Count - 1 - id;
    this.ArenaPlayingData = this.m_ArenaReportData[id];
    return true;
  }

  public void SendArena_UIClear()
  {
    DataManager.Instance.RoleAttr.PrizeFlag -= 1048576U;
    GUIManager.Instance.BuildingData.UpdateBuildState((byte) 5, (ushort) byte.MaxValue);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_UICLEAR;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }
}
