// Decompiled with JetBrains decompiler
// Type: BattleNetwork
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
public class BattleNetwork
{
  public static bool bReplay = false;
  public static bool[] bStageFirstTry = new bool[4];
  public static ushort battlePointID = 0;
  public static byte NetworkError = 0;
  public static byte SendBattleEndStatus = 0;
  private static ushort[,] GambleHeroIDTemp = new ushort[3, 100];
  private static ushort[] GambleActionHeroIDTemp = new ushort[5];
  private static int[] GambleHeroCount = new int[3];
  private static readonly int[] GambleHeroPriorityCount = new int[3]
  {
    1,
    2,
    2
  };

  public static bool sendInitBattle()
  {
    if (DataManager.StageDataController._stageMode == StageMode.Dare)
      return BattleNetwork.sendInitBattleEx();
    if (!GUIManager.Instance.ShowUILock(EUILock.Battle))
      return false;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_BATTLEINIT_NPC;
    ushort data = BattleNetwork.battlePointID;
    if (!BattleNetwork.bReplay)
    {
      data = DataManager.StageDataController.currentPointID;
      BattleNetwork.battlePointID = data;
    }
    messagePacket.Add((byte) (DataManager.StageDataController._stageMode + (byte) 1));
    messagePacket.Add(data);
    for (int index = 0; index < 5; ++index)
      messagePacket.Add(DataManager.Instance.heroBattleData[index].HeroID);
    if (messagePacket.Send())
      return true;
    GUIManager.Instance.HideUILock(EUILock.Battle);
    return false;
  }

  public static void RecvInitBattle(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    GUIManager.Instance.HideUILock(EUILock.Battle);
    BATTLEINIT_RESULT battleinitResult = (BATTLEINIT_RESULT) MP.ReadByte();
    if (battleinitResult == BATTLEINIT_RESULT.BATTLEINIT_RESULT_SUCCESS)
    {
      instance.BattleSeqID = MP.ReadULong();
      MP.ReadByte();
      MP.ReadUShort();
      ushort num1 = MP.ReadUShort();
      byte num2 = MP.ReadByte();
      DataManager.StageDataController.UpdateRoleAttrMorale(MP.ReadUShort());
      for (int index = 0; index < 5; ++index)
        instance.heroBattleData[index].HeroID = MP.ReadUShort();
      for (int index = 0; index < 5; ++index)
      {
        instance.heroBattleData[index].AttrData.SkillLV1 = MP.ReadByte();
        instance.heroBattleData[index].AttrData.SkillLV2 = MP.ReadByte();
        instance.heroBattleData[index].AttrData.SkillLV3 = MP.ReadByte();
        instance.heroBattleData[index].AttrData.SkillLV4 = MP.ReadByte();
        instance.heroBattleData[index].AttrData.LV = MP.ReadByte();
        instance.heroBattleData[index].AttrData.Star = MP.ReadByte();
        instance.heroBattleData[index].AttrData.Enhance = MP.ReadByte();
        instance.heroBattleData[index].AttrData.Equip = MP.ReadByte();
      }
      MP.ReadBlock(instance.RewardLen, 0, 4);
      instance.RewardCount = (int) instance.RewardLen[0] + (int) instance.RewardLen[1] + (int) instance.RewardLen[2] + (int) instance.RewardLen[3];
      for (int index = 0; index < instance.RewardCount; ++index)
        instance.RewardData[index] = MP.ReadUShort();
      instance.battleInfo.RandomSeed = num1;
      instance.battleInfo.RandomGap = (ushort) num2;
      instance.battleInfo.BattleType = (byte) 1;
      BattleNetwork.SendBattleEndStatus = (byte) 0;
      GameManager.OnRefresh();
      if (!BattleNetwork.bReplay)
      {
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 0);
      }
      else
      {
        BattleNetwork.bReplay = false;
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleReplay);
        AudioManager.Instance.LoadAndPlayBGM(BGMType.War, (byte) 1);
      }
    }
    else if (!BattleNetwork.bReplay)
    {
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 1);
      uint ID = (uint) ((byte) 148 + battleinitResult);
      GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(ID), (ushort) 2);
    }
    else
    {
      BattleNetwork.bReplay = false;
      uint ID = (uint) ((byte) 148 + battleinitResult);
      GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(ID), (ushort) 2);
    }
  }

  public static bool sendBattleEnd()
  {
    if (DataManager.StageDataController._stageMode == StageMode.Dare)
      return BattleNetwork.sendBattleEndEx();
    if (!GUIManager.Instance.ShowUILock(EUILock.Battle))
      return false;
    ushort eventDataLen = (ushort) BSInvokeUtil.getInstance.getEventDataLen();
    int Max = (int) eventDataLen + 22;
    if (Max < 1024)
      Max = 1024;
    MessagePacket messagePacket = new MessagePacket((ushort) Max);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_BATTLEEND;
    messagePacket.Add(DataManager.Instance.BattleSeqID);
    messagePacket.Add(eventDataLen);
    messagePacket.Add(BattleController.EventBuffer, len: (int) eventDataLen);
    if (messagePacket.Send())
      return true;
    GUIManager.Instance.HideUILock(EUILock.Battle);
    return false;
  }

  public static void RecvBattleEnd(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Battle);
    DataManager instance = DataManager.Instance;
    byte Score = MP.ReadByte();
    instance.lastBattleResult = (short) Score;
    instance.BattleSeqID = 0UL;
    BattleNetwork.SendBattleEndStatus = (byte) 0;
    if (Score == (byte) 0)
      return;
    Level bycurrentPointId = DataManager.StageDataController.GetLevelBycurrentPointID((ushort) 0);
    instance.RWMoney = (uint) bycurrentPointId.Money;
    instance.KingOldLv = instance.RoleAttr.Level;
    instance.KingOldExp = instance.RoleAttr.Exp;
    DataManager.StageDataController.RoleAttrLevelUp(MP, 63);
    byte num1 = MP.ReadByte();
    ushort in_StageRecord = MP.ReadUShort();
    ushort Freq = MP.ReadUShort();
    byte in_stageMode = (byte) ((uint) num1 - 1U);
    DataManager.StageDataController.SetStagePoint(BattleNetwork.battlePointID, Score, Freq);
    DataManager.StageDataController.UpdateStageRecord((StageMode) in_stageMode, in_StageRecord);
    BattleNetwork.bStageFirstTry[(int) in_stageMode] = true;
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
    for (int index = 0; index < instance.RewardCount && index < 128; ++index)
    {
      ushort ItemID = instance.RewardData[index];
      ushort curItemQuantity = instance.GetCurItemQuantity(ItemID, (byte) 0);
      if (curItemQuantity < ushort.MaxValue)
        instance.SetCurItemQuantity(ItemID, (ushort) ((uint) curItemQuantity + 1U), (byte) 0, 0L);
    }
    GameManager.OnRefresh();
    GameManager.OnRefresh(NetworkNews.Refresh_Item);
    if ((int) instance.KingOldLv != (int) instance.RoleAttr.Level)
      GameManager.OnRefresh(NetworkNews.Refresh_Attr);
    DataManager.msgBuffer[0] = (byte) 32;
    DataManager.msgBuffer[1] = (byte) 2;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
    AFAdvanceManager.Instance.CheckHeroStageUnbroken();
  }

  public static int GambleGetHeroPriority(ushort _heroID)
  {
    Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(_heroID);
    if ((int) recordByKey.HeroKey == (int) _heroID)
    {
      if (recordByKey.Pos >= (ushort) 1 && recordByKey.Pos <= (ushort) 300)
        return 0;
      if (recordByKey.Pos >= (ushort) 301 && recordByKey.Pos <= (ushort) 600)
        return 1;
      if (recordByKey.Pos >= (ushort) 601 && recordByKey.Pos <= (ushort) 1000)
        return 2;
    }
    return -1;
  }

  public static void GambleGetRandomHero()
  {
    Array.Clear((Array) BattleNetwork.GambleHeroIDTemp, 0, 15);
    Array.Clear((Array) BattleNetwork.GambleHeroCount, 0, 3);
    Array.Clear((Array) BattleNetwork.GambleActionHeroIDTemp, 0, 5);
    GamblingManager instance1 = GamblingManager.Instance;
    DataManager instance2 = DataManager.Instance;
    int index1 = 0;
    for (int index2 = 0; (long) index2 < (long) instance2.CurHeroDataCount; ++index2)
    {
      ushort num = (ushort) instance2.sortHeroData[index2];
      int heroPriority = BattleNetwork.GambleGetHeroPriority(num);
      if (heroPriority != -1 && DataManager.CheckHeroResourceReady(num))
      {
        BattleNetwork.GambleHeroIDTemp[heroPriority, BattleNetwork.GambleHeroCount[heroPriority]] = num;
        ++BattleNetwork.GambleHeroCount[heroPriority];
      }
    }
    for (int index3 = 0; index3 < 3; ++index3)
    {
      for (int index4 = 0; index4 < BattleNetwork.GambleHeroPriorityCount[index3]; ++index4)
      {
        if (BattleNetwork.GambleHeroCount[index3] > 0)
        {
          int index5 = UnityEngine.Random.Range(0, BattleNetwork.GambleHeroCount[index3]);
          BattleNetwork.GambleActionHeroIDTemp[index1] = BattleNetwork.GambleHeroIDTemp[index3, index5];
          ++index1;
          BattleNetwork.GambleHeroIDTemp[index3, index5] = BattleNetwork.GambleHeroIDTemp[index3, BattleNetwork.GambleHeroCount[index3] - 1];
          --BattleNetwork.GambleHeroCount[index3];
        }
      }
    }
    int num1;
    do
    {
      num1 = 0;
      if (BattleNetwork.GambleHeroCount[1] > 0)
      {
        BattleNetwork.GambleHeroIDTemp[0, BattleNetwork.GambleHeroCount[0]] = BattleNetwork.GambleHeroIDTemp[1, 0];
        ++BattleNetwork.GambleHeroCount[0];
        --BattleNetwork.GambleHeroCount[1];
      }
      else
        ++num1;
      if (BattleNetwork.GambleHeroCount[2] > 0)
      {
        BattleNetwork.GambleHeroIDTemp[0, BattleNetwork.GambleHeroCount[0]] = BattleNetwork.GambleHeroIDTemp[2, 0];
        ++BattleNetwork.GambleHeroCount[0];
        --BattleNetwork.GambleHeroCount[2];
      }
      else
        ++num1;
    }
    while (num1 != 2);
    for (int index6 = 0; index6 < 5; ++index6)
    {
      if (BattleNetwork.GambleActionHeroIDTemp[index6] == (ushort) 0 && BattleNetwork.GambleHeroCount[0] > 0)
      {
        int index7 = UnityEngine.Random.Range(0, BattleNetwork.GambleHeroCount[0]);
        BattleNetwork.GambleActionHeroIDTemp[index6] = BattleNetwork.GambleHeroIDTemp[0, index7];
        BattleNetwork.GambleHeroIDTemp[0, index7] = BattleNetwork.GambleHeroIDTemp[0, BattleNetwork.GambleHeroCount[0] - 1];
        --BattleNetwork.GambleHeroCount[0];
      }
    }
    instance1.BattleHeroCount = (byte) 0;
    Array.Clear((Array) instance1.BattleHeroData, 0, 5);
    for (int index8 = 0; index8 < 5; ++index8)
    {
      if (BattleNetwork.GambleActionHeroIDTemp[index8] != (ushort) 0)
      {
        instance1.BattleHeroData[(int) instance1.BattleHeroCount].HeroID = BattleNetwork.GambleActionHeroIDTemp[index8];
        ++instance1.BattleHeroCount;
      }
    }
    for (int index9 = 0; index9 < (int) instance1.BattleHeroCount; ++index9)
    {
      CurHeroData curHeroData = instance2.curHeroData[(uint) instance1.BattleHeroData[index9].HeroID];
      instance1.BattleHeroData[index9].AttrData.SkillLV1 = curHeroData.SkillLV[0];
      instance1.BattleHeroData[index9].AttrData.SkillLV2 = curHeroData.SkillLV[1];
      instance1.BattleHeroData[index9].AttrData.SkillLV3 = curHeroData.SkillLV[2];
      instance1.BattleHeroData[index9].AttrData.SkillLV4 = curHeroData.SkillLV[3];
      instance1.BattleHeroData[index9].AttrData.LV = curHeroData.Level;
      instance1.BattleHeroData[index9].AttrData.Star = curHeroData.Star;
      instance1.BattleHeroData[index9].AttrData.Enhance = curHeroData.Enhance;
      instance1.BattleHeroData[index9].AttrData.Equip = curHeroData.Equip;
    }
  }

  public static void RefreshGambleMode(EGambleMode mode)
  {
    if (!BattleController.IsGambleMode)
      return;
    BattleController.GambleMode = mode;
    GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.GambleSwitchMode);
  }

  public static void SetBattleGambleState(EBattleGambleState state)
  {
    if (!BattleController.IsGambleMode)
      return;
    BattleController activeGameplay = GameManager.ActiveGameplay as BattleController;
    switch (state)
    {
      case EBattleGambleState.SUPPORT_WORK:
        BSInvokeUtil.getInstance.CasinoModeInput((byte) 3);
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 5);
        break;
      case EBattleGambleState.MONSTER_LEAVE:
        BattleController.GambleResult = 2;
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 5);
        break;
      case EBattleGambleState.MONSTER_DIE:
        BSInvokeUtil.getInstance.CasinoModeInput((byte) 2);
        BattleController.GambleResult = 1;
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_Battle_Gambling, 5);
        break;
      case EBattleGambleState.MONSTER_HIT:
        BSInvokeUtil.getInstance.CasinoModeInput((byte) 1);
        break;
    }
  }

  public static bool sendInitBattleEx()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Battle))
      return false;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_EX_BATTLEINIT_NPC;
    ushort num = BattleNetwork.battlePointID;
    if (!BattleNetwork.bReplay)
    {
      num = DataManager.StageDataController.currentPointID;
      BattleNetwork.battlePointID = num;
    }
    StageMode stageMode = DataManager.StageDataController.StageDareMode(BattleNetwork.battlePointID);
    messagePacket.Add(stageMode != StageMode.Full ? (byte) 2 : (byte) 1);
    if (stageMode == StageMode.Lean)
      num /= (ushort) 3;
    messagePacket.Add(num);
    for (int index = 0; index < 5; ++index)
      messagePacket.Add(DataManager.Instance.heroBattleData[index].HeroID);
    byte currentNodus = DataManager.StageDataController.currentNodus;
    messagePacket.Add(currentNodus);
    if (!messagePacket.Send())
    {
      GUIManager.Instance.HideUILock(EUILock.Battle);
      return false;
    }
    StageManager stageDataController = DataManager.StageDataController;
    DataManager instance = DataManager.Instance;
    if (stageDataController.StageDareMode(num) == StageMode.Lean)
    {
      LevelEX bycurrentPointId = stageDataController.GetLevelEXBycurrentPointID((ushort) 0);
      switch (currentNodus)
      {
        case 1:
          instance.BattleConditionKey = bycurrentPointId.NodusOneID;
          break;
        case 2:
          instance.BattleConditionKey = bycurrentPointId.NodusTwoID;
          break;
        case 3:
          instance.BattleConditionKey = bycurrentPointId.NodusThrID;
          break;
      }
    }
    else
    {
      LevelEX bycurrentPointId = stageDataController.GetLevelEXBycurrentPointID((ushort) 0);
      instance.BattleConditionKey = bycurrentPointId.NodusTwoID;
    }
    return true;
  }

  public static void RecvInitBattleEx(MessagePacket MP)
  {
    DataManager instance = DataManager.Instance;
    GUIManager.Instance.HideUILock(EUILock.Battle);
    BATTLEINIT_RESULT battleinitResult = (BATTLEINIT_RESULT) MP.ReadByte();
    if (battleinitResult == BATTLEINIT_RESULT.BATTLEINIT_RESULT_SUCCESS)
    {
      instance.BattleSeqID = MP.ReadULong();
      MP.ReadByte();
      MP.ReadUShort();
      MP.ReadByte();
      ushort num1 = MP.ReadUShort();
      byte num2 = MP.ReadByte();
      for (int index = 0; index < 5; ++index)
        instance.heroBattleData[index].HeroID = MP.ReadUShort();
      for (int index = 0; index < 5; ++index)
      {
        instance.heroBattleData[index].AttrData.SkillLV1 = MP.ReadByte();
        instance.heroBattleData[index].AttrData.SkillLV2 = MP.ReadByte();
        instance.heroBattleData[index].AttrData.SkillLV3 = MP.ReadByte();
        instance.heroBattleData[index].AttrData.SkillLV4 = MP.ReadByte();
        instance.heroBattleData[index].AttrData.LV = MP.ReadByte();
        instance.heroBattleData[index].AttrData.Star = MP.ReadByte();
        instance.heroBattleData[index].AttrData.Enhance = MP.ReadByte();
        instance.heroBattleData[index].AttrData.Equip = MP.ReadByte();
      }
      instance.battleInfo.RandomSeed = num1;
      instance.battleInfo.RandomGap = (ushort) num2;
      instance.battleInfo.BattleType = (byte) 6;
      BattleNetwork.SendBattleEndStatus = (byte) 0;
      GameManager.OnRefresh();
      if (!BattleNetwork.bReplay)
      {
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 0);
      }
      else
      {
        BattleNetwork.bReplay = false;
        GUIManager.Instance.pDVMgr.NextTransitions(eTrans.BEGIN, eTransFunc.BattleReplay);
        AudioManager.Instance.LoadAndPlayBGM(BGMType.War, (byte) 1);
      }
    }
    else if (!BattleNetwork.bReplay)
    {
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_BattleHeroSelect, 1);
      uint ID = (uint) ((byte) 148 + battleinitResult);
      GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(ID), (ushort) 2);
    }
    else
    {
      BattleNetwork.bReplay = false;
      uint ID = (uint) ((byte) 148 + battleinitResult);
      GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(ID), (ushort) 2);
    }
  }

  public static bool sendBattleEndEx()
  {
    if (!GUIManager.Instance.ShowUILock(EUILock.Battle))
      return false;
    ushort eventDataLen = (ushort) BSInvokeUtil.getInstance.getEventDataLen();
    int Max = (int) eventDataLen + 22;
    if (Max < 1024)
      Max = 1024;
    MessagePacket messagePacket = new MessagePacket((ushort) Max);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_EX_BATTLEEND;
    messagePacket.Add(DataManager.Instance.BattleSeqID);
    messagePacket.Add(eventDataLen);
    messagePacket.Add(BattleController.EventBuffer, len: (int) eventDataLen);
    if (messagePacket.Send())
      return true;
    GUIManager.Instance.HideUILock(EUILock.Battle);
    return false;
  }

  public static void RecvBattleEndEx(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Battle);
    DataManager instance = DataManager.Instance;
    byte num1 = MP.ReadByte();
    instance.BattleFailureIndex = MP.ReadByte();
    instance.lastBattleResult = (short) num1;
    instance.BattleSeqID = 0UL;
    BattleNetwork.SendBattleEndStatus = (byte) 0;
    if (num1 == (byte) 0)
      return;
    instance.RWMoney = 0U;
    instance.KingOldLv = instance.RoleAttr.Level;
    instance.KingOldExp = instance.RoleAttr.Exp;
    byte num2 = MP.ReadByte();
    ushort num3 = MP.ReadUShort();
    byte num4 = MP.ReadByte();
    ushort CrystalNum = MP.ReadUShort();
    switch (num2)
    {
      case 1:
        DataManager.StageDataController.UpdateStageRecord(StageMode.Dare, num3);
        break;
      case 2:
        DataManager.StageDataController.SetStagePoint(BattleNetwork.battlePointID, num4, (ushort) 1);
        break;
    }
    if (CrystalNum > (ushort) 0)
    {
      DataManager.Instance.RoleAttr.Diamond += (uint) CrystalNum;
      GUIManager.Instance.SetChallegeRewardUI((int) CrystalNum, num3, num4);
    }
    GameManager.OnRefresh();
    GameManager.OnRefresh(NetworkNews.Refresh_Item);
    if ((int) instance.KingOldLv != (int) instance.RoleAttr.Level)
      GameManager.OnRefresh(NetworkNews.Refresh_Attr);
    DataManager.msgBuffer[0] = (byte) 32;
    DataManager.msgBuffer[1] = (byte) 2;
    GameManager.notifyObservers((byte) 1, (byte) 0, DataManager.msgBuffer);
  }
}
