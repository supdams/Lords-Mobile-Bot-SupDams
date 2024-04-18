// Decompiled with JetBrains decompiler
// Type: AFAdvanceManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;

#nullable disable
internal class AFAdvanceManager
{
  private const string OnlineTimeTag = "AFOnlineTime";
  private const string AdvanceEventDataTag = "AFAdvanceEventData";
  private const string AdvanceEventDataTag2 = "AFAdvanceEventData2";
  private const string FirstLoginServerTime = "AFFirstLoginServerTime";
  private const string IGG_LAUNCH = "AF_IGG_LAUNCH";
  private const long Minute_30 = 1800;
  private const long Minute_20 = 1200;
  private const long Minute_10 = 600;
  private const long Sec_3Day = 259200;
  private const byte TriggerChearacterLv5 = 5;
  private const byte TriggerCastleLv5 = 5;
  private static AFAdvanceManager instance;
  private float m_TickTime;
  private ExtraObject[] ExtraObjectData = new ExtraObject[73];
  private long m_SaveData;
  private long m_SaveData2;
  private long m_OnlineTime;
  private bool bNeedCheckTimeEvent = true;
  private bool bNeedCheckEvent = true;
  private bool bNeedCheckPower = true;
  private long m_FirstLoginServerTime;
  private bool bNeedCheckPURCHASE4_99 = true;
  private bool bNeedCheckPURCHASE19_99 = true;
  private uint[] PURCHASE4_99 = new uint[24]
  {
    11660U,
    11617U,
    11616U,
    11615U,
    11614U,
    11601U,
    11613U,
    11600U,
    11612U,
    11618U,
    11611U,
    11610U,
    11596U,
    11619U,
    14140U,
    14141U,
    14142U,
    14238U,
    14239U,
    14240U,
    11571U,
    14216U,
    13881U,
    13882U
  };
  private uint[] PURCHASE19_99 = new uint[33]
  {
    11635U,
    11634U,
    11605U,
    11633U,
    11604U,
    11632U,
    11636U,
    11631U,
    11630U,
    11661U,
    11639U,
    11597U,
    11638U,
    11637U,
    14143U,
    14144U,
    14145U,
    14241U,
    14242U,
    14243U,
    11573U,
    14037U,
    14038U,
    14039U,
    14040U,
    14041U,
    14042U,
    14043U,
    14044U,
    14045U,
    14046U,
    13883U,
    13884U
  };

  private AFAdvanceManager()
  {
    for (int eAppsFlayerEvent = 0; eAppsFlayerEvent < this.ExtraObjectData.Length; ++eAppsFlayerEvent)
    {
      if (eAppsFlayerEvent >= 51 && eAppsFlayerEvent <= 62)
        this.ExtraObjectData[eAppsFlayerEvent] = new ExtraObject(eAppsFlayerEvent);
    }
  }

  public static AFAdvanceManager Instance
  {
    get
    {
      if (AFAdvanceManager.instance == null)
        AFAdvanceManager.instance = new AFAdvanceManager();
      return AFAdvanceManager.instance;
    }
  }

  public bool TriggerAfAdvEvent(EAppsFlayerEvent eventType)
  {
    if (!this.bNeedCheckEvent)
    {
      this.DebugMsg("ALL EVENT Allready Trigger", EAppsFlayerEvent.eMax);
      return false;
    }
    if (eventType >= EAppsFlayerEvent.eMax)
    {
      this.DebugMsg("eventType >= EAppsFlayerEvent.eMax", EAppsFlayerEvent.eMax);
      return false;
    }
    if (!this.CheckRequirement(eventType))
      return false;
    switch (eventType)
    {
      case EAppsFlayerEvent.TUTORIAL_COMPLETION:
        IGGSDKPlugin.AppsFlyerTutorialCompletion();
        break;
      case EAppsFlayerEvent.HEROSTAGE1_3_COMPLETION:
        IGGSDKPlugin.HeroStageCompletion();
        break;
      default:
        IGGSDKPlugin.AppsFlyerAdvance(eventType.ToString());
        break;
    }
    if (eventType <= EAppsFlayerEvent.BUY_SUPPLYCHEST)
      this.m_SaveData |= 1L << (int) (eventType & EAppsFlayerEvent.BUY_SUPPLYCHEST & EAppsFlayerEvent.BUY_SUPPLYCHEST);
    else
      this.m_SaveData2 |= 1L << (int) (eventType - 63 - 1 & EAppsFlayerEvent.BUY_SUPPLYCHEST & EAppsFlayerEvent.BUY_SUPPLYCHEST);
    this.SaveEventData(eventType);
    return true;
  }

  public void CheckTriggerEvent_Time(float dt)
  {
    this.m_TickTime += dt;
    if ((double) this.m_TickTime < 10.0)
      return;
    if (this.bNeedCheckTimeEvent && this.m_OnlineTime >= 600L)
    {
      this.TriggerAfAdvEvent(EAppsFlayerEvent.NEWBIE_PLAYS10M);
      if (this.m_OnlineTime >= 1200L)
      {
        this.TriggerAfAdvEvent(EAppsFlayerEvent.NEWBIE_PLAYS20M);
        if (this.m_OnlineTime >= 1800L)
        {
          this.TriggerAfAdvEvent(EAppsFlayerEvent.NEWBIE_PLAYS30M);
          this.bNeedCheckTimeEvent = false;
        }
      }
    }
    this.m_OnlineTime += 10L;
    this.m_TickTime -= 10f;
  }

  public void CheckTriggerEvent_LoginFinish()
  {
    this.CheckCharacterLvEvent(DataManager.Instance.RoleAttr.Level);
    this.CheckCastleLvEvent(GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level);
    this.CheckPower(DataManager.Instance.RoleAttr.Power);
    this.TriggerAfAdvEvent(EAppsFlayerEvent.IGG_LAUNCH);
    this.CheckLoginUnbroken();
    if (IGGSDKPlugin.GetAPILevel() < 23)
      return;
    this.TriggerAfAdvEvent(EAppsFlayerEvent.LOGIN_IPHONE_OS6);
  }

  public void SaveOnlineTime()
  {
    this.DebugMsg("SaveOnlineTime =" + (object) this.m_OnlineTime, EAppsFlayerEvent.eMax);
    PlayerPrefs.SetString("AFOnlineTime", this.m_OnlineTime.ToString());
  }

  public void GetOnlineTime()
  {
    long.TryParse(PlayerPrefs.GetString("AFOnlineTime"), out this.m_OnlineTime);
  }

  public void SaveEventData()
  {
    PlayerPrefs.SetString("AFAdvanceEventData", this.m_SaveData.ToString());
    PlayerPrefs.SetString("AFAdvanceEventData2", this.m_SaveData2.ToString());
  }

  public void SaveExtraData()
  {
  }

  public void SaveEventData(EAppsFlayerEvent eventType)
  {
    this.SaveEventData();
    if (eventType != EAppsFlayerEvent.IGG_LAUNCH)
      return;
    this.SaveIggLaunchDay();
  }

  public void GetEventData()
  {
    long.TryParse(PlayerPrefs.GetString("AFAdvanceEventData"), out this.m_SaveData);
    long.TryParse(PlayerPrefs.GetString("AFAdvanceEventData2"), out this.m_SaveData2);
    if (this.CheckIsRecord(EAppsFlayerEvent.NEWBIE_PLAYS10M) && this.CheckIsRecord(EAppsFlayerEvent.NEWBIE_PLAYS20M) && this.CheckIsRecord(EAppsFlayerEvent.NEWBIE_PLAYS30M))
      this.bNeedCheckTimeEvent = false;
    if (this.CheckIsRecord(EAppsFlayerEvent.REACH_MIGHT50K) && this.CheckIsRecord(EAppsFlayerEvent.REACH_MIGHT500K) && this.CheckIsRecord(EAppsFlayerEvent.REACH_MIGHT1M) && this.CheckIsRecord(EAppsFlayerEvent.REACH_MIGHT5M))
      this.bNeedCheckPower = false;
    if (this.CheckIsRecord(EAppsFlayerEvent.FIRST_4_99PURCHASE))
      this.bNeedCheckPURCHASE4_99 = false;
    if (!this.CheckIsRecord(EAppsFlayerEvent.FIRST_19_99PURCHASE))
      return;
    this.bNeedCheckPURCHASE19_99 = false;
  }

  public void GetExtraData()
  {
  }

  public void SaveFirstLoginTime()
  {
    PlayerPrefs.SetString("AFFirstLoginServerTime", DataManager.Instance.ServerTime.ToString());
    this.m_FirstLoginServerTime = DataManager.Instance.ServerTime;
  }

  public void GetFirstLoginTime()
  {
    if (this.m_FirstLoginServerTime != 0L)
      return;
    long.TryParse(PlayerPrefs.GetString("AFFirstLoginServerTime"), out this.m_FirstLoginServerTime);
  }

  private bool CheckIsRecord(EAppsFlayerEvent eventType)
  {
    return eventType <= EAppsFlayerEvent.BUY_SUPPLYCHEST ? (this.m_SaveData & 1L << (int) (eventType & EAppsFlayerEvent.BUY_SUPPLYCHEST)) != 0L : (this.m_SaveData2 & 1L << (int) (eventType - 63 - 1 & EAppsFlayerEvent.BUY_SUPPLYCHEST)) != 0L;
  }

  private bool CheckRequirement(EAppsFlayerEvent eventType)
  {
    bool flag = this.CheckIsRecord(eventType);
    if (eventType != EAppsFlayerEvent.IGG_LAUNCH)
      return !flag;
    return !flag || this.CheckCanSendLaunch();
  }

  ~AFAdvanceManager()
  {
  }

  private void DebugMsg(string msg, EAppsFlayerEvent eventType)
  {
  }

  public void Clean()
  {
  }

  public void CheckCharacterLvEvent(byte lv)
  {
    EAppsFlayerEvent[] eappsFlayerEventArray = new EAppsFlayerEvent[5]
    {
      EAppsFlayerEvent.REACH_CHARACTERLV5,
      EAppsFlayerEvent.REACH_CHARACTERLV10,
      EAppsFlayerEvent.REACH_CHARACTERLV15,
      EAppsFlayerEvent.REACH_CHARACTERLV20,
      EAppsFlayerEvent.REACH_CHARACTERLV25
    };
    ulong[] numArray = new ulong[5]
    {
      5UL,
      10UL,
      15UL,
      20UL,
      25UL
    };
    int num = 0;
    for (int index = 0; index < eappsFlayerEventArray.Length && index < numArray.Length && (ulong) lv >= numArray[index]; ++index)
      this.TriggerAfAdvEvent(eappsFlayerEventArray[num++]);
  }

  public void CheckCastleLvEvent(byte lv)
  {
    EAppsFlayerEvent[] eappsFlayerEventArray = new EAppsFlayerEvent[9]
    {
      EAppsFlayerEvent.REACH_CASTLELV3,
      EAppsFlayerEvent.REACH_CASTLELV4,
      EAppsFlayerEvent.REACH_CASTLELV5,
      EAppsFlayerEvent.REACH_CASTLELV6,
      EAppsFlayerEvent.REACH_CASTLELV7,
      EAppsFlayerEvent.REACH_CASTLELV8,
      EAppsFlayerEvent.REACH_CASTLELV9,
      EAppsFlayerEvent.REACH_CASTLELV10,
      EAppsFlayerEvent.REACH_CASTLELV11
    };
    int num = 0;
    for (int index = 3; index < 12 && (int) lv >= index; ++index)
      this.TriggerAfAdvEvent(eappsFlayerEventArray[num++]);
  }

  public void CheckPower(ulong might)
  {
    if (!this.bNeedCheckPower)
      return;
    EAppsFlayerEvent[] eappsFlayerEventArray = new EAppsFlayerEvent[4]
    {
      EAppsFlayerEvent.REACH_MIGHT50K,
      EAppsFlayerEvent.REACH_MIGHT500K,
      EAppsFlayerEvent.REACH_MIGHT1M,
      EAppsFlayerEvent.REACH_MIGHT5M
    };
    ulong[] numArray = new ulong[4]
    {
      50000UL,
      500000UL,
      1000000UL,
      5000000UL
    };
    int num1 = 0;
    byte num2 = 0;
    for (int index = 0; index < numArray.Length && might >= numArray[index]; ++index)
    {
      ++num2;
      this.TriggerAfAdvEvent(eappsFlayerEventArray[num1++]);
    }
    this.bNeedCheckPower = num2 != (byte) 4;
  }

  public void CheckTrainTroop()
  {
    ulong num1 = 0;
    for (byte id = 1; id <= (byte) 16; ++id)
      num1 += (ulong) DataManager.MissionDataManager.CheckDynaMark(id);
    EAppsFlayerEvent[] eappsFlayerEventArray = new EAppsFlayerEvent[4]
    {
      EAppsFlayerEvent.TRAIN_TROOPS500,
      EAppsFlayerEvent.TRAIN_TROOPS2000,
      EAppsFlayerEvent.TRAIN_TROOPS10K,
      EAppsFlayerEvent.TRAIN_TROOPS50K
    };
    ulong[] numArray = new ulong[4]
    {
      500UL,
      2000UL,
      10000UL,
      50000UL
    };
    int num2 = 0;
    for (int index = 0; index < numArray.Length && num1 >= numArray[index]; ++index)
      this.TriggerAfAdvEvent(eappsFlayerEventArray[num2++]);
  }

  public void CheckHeroCount(ulong count)
  {
    EAppsFlayerEvent[] eappsFlayerEventArray = new EAppsFlayerEvent[4]
    {
      EAppsFlayerEvent.HIRE_HEROES3,
      EAppsFlayerEvent.HIRE_HEROES5,
      EAppsFlayerEvent.HIRE_HEROES10,
      EAppsFlayerEvent.HIRE_HEROES15
    };
    ulong[] numArray = new ulong[4]{ 3UL, 5UL, 10UL, 15UL };
    int num = 0;
    for (int index = 0; index < numArray.Length && count >= numArray[index]; ++index)
      this.TriggerAfAdvEvent(eappsFlayerEventArray[num++]);
  }

  public void CheckCompleteQuest()
  {
    ushort num1 = DataManager.MissionDataManager.CheckDynaMark((byte) 101);
    EAppsFlayerEvent[] eappsFlayerEventArray = new EAppsFlayerEvent[3]
    {
      EAppsFlayerEvent.COMPLETE_TURFQUESTS10,
      EAppsFlayerEvent.COMPLETE_TURFQUESTS20,
      EAppsFlayerEvent.COMPLETE_TURFQUESTS100
    };
    ushort[] numArray = new ushort[3]
    {
      (ushort) 10,
      (ushort) 20,
      (ushort) 100
    };
    int num2 = 0;
    for (int index = 0; index < numArray.Length && (int) num1 >= (int) numArray[index]; ++index)
      this.TriggerAfAdvEvent(eappsFlayerEventArray[num2++]);
  }

  public void CheckHitMonster()
  {
    if (DataManager.MissionDataManager.CheckDynaMark((byte) 145) > (ushort) 0)
      this.TriggerAfAdvEvent(EAppsFlayerEvent.HIT_MONSTERLV1);
    if (DataManager.MissionDataManager.CheckDynaMark((byte) 146) <= (ushort) 0)
      return;
    this.TriggerAfAdvEvent(EAppsFlayerEvent.HIT_MONSTERLV2);
  }

  public void CheckGatherTimber()
  {
    if (DataManager.MissionDataManager.CheckDynaMark((byte) 126) <= (ushort) 50000)
      return;
    this.TriggerAfAdvEvent(EAppsFlayerEvent.GATHER_TIMBER50K);
  }

  public void CheckPurchase(uint id)
  {
    this.TriggerAfAdvEvent(EAppsFlayerEvent.FIRST_PURCHASE);
    if (this.bNeedCheckPURCHASE4_99)
    {
      for (int index = 0; index < this.PURCHASE4_99.Length; ++index)
      {
        if ((int) this.PURCHASE4_99[index] == (int) id)
        {
          if (this.TriggerAfAdvEvent(EAppsFlayerEvent.FIRST_4_99PURCHASE))
          {
            this.bNeedCheckPURCHASE4_99 = false;
            break;
          }
          break;
        }
      }
    }
    if (!this.bNeedCheckPURCHASE19_99)
      return;
    for (int index = 0; index < this.PURCHASE19_99.Length; ++index)
    {
      if ((int) this.PURCHASE19_99[index] == (int) id)
      {
        if (!this.TriggerAfAdvEvent(EAppsFlayerEvent.FIRST_19_99PURCHASE))
          break;
        this.bNeedCheckPURCHASE19_99 = false;
        break;
      }
    }
  }

  private void SaveIggLaunchDay()
  {
    PlayerPrefs.SetString("AF_IGG_LAUNCH", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day).Ticks.ToString());
  }

  private long GetIggLaunchDay()
  {
    long result = 0;
    return long.TryParse(PlayerPrefs.GetString("AF_IGG_LAUNCH"), out result) ? result : 0L;
  }

  public bool CheckCanSendLaunch()
  {
    long iggLaunchDay = this.GetIggLaunchDay();
    if (iggLaunchDay == 0L)
      return true;
    try
    {
      return (DateTime.Now - new DateTime(iggLaunchDay)).Days >= 1;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public void CheckLoginUnbroken()
  {
    EAppsFlayerEvent[] eappsFlayerEventArray = new EAppsFlayerEvent[2]
    {
      EAppsFlayerEvent.LOGIN_3DAYS,
      EAppsFlayerEvent.LOGIN_7DAYS
    };
    int[] numArray = new int[2]{ 3, 7 };
    for (int index = 0; index < numArray.Length; ++index)
    {
      this.ExtraObjectData[(int) eappsFlayerEventArray[index]].SetUnbrokenDay();
      if ((int) this.ExtraObjectData[(int) eappsFlayerEventArray[index]].UnbrokenDay >= numArray[index])
        this.TriggerAfAdvEvent(eappsFlayerEventArray[index]);
      if ((int) this.ExtraObjectData[(int) eappsFlayerEventArray[index]].UnbrokenDay >= numArray[index])
        this.TriggerAfAdvEvent(eappsFlayerEventArray[index]);
    }
  }

  public void CheckOpenTreasureUnbroken()
  {
    EAppsFlayerEvent[] eappsFlayerEventArray = new EAppsFlayerEvent[2]
    {
      EAppsFlayerEvent.MYSTERYBOX_3DAYS,
      EAppsFlayerEvent.MYSTERYBOX_7DAYS
    };
    int[] numArray = new int[2]{ 3, 7 };
    for (int index = 0; index < numArray.Length; ++index)
    {
      this.ExtraObjectData[(int) eappsFlayerEventArray[index]].SetUnbrokenDay();
      if ((int) this.ExtraObjectData[(int) eappsFlayerEventArray[index]].UnbrokenDay >= numArray[index])
        this.TriggerAfAdvEvent(eappsFlayerEventArray[index]);
      if ((int) this.ExtraObjectData[(int) eappsFlayerEventArray[index]].UnbrokenDay >= numArray[index])
        this.TriggerAfAdvEvent(eappsFlayerEventArray[index]);
    }
  }

  public void CheckGuildHelpUnbroken()
  {
    EAppsFlayerEvent[] eappsFlayerEventArray = new EAppsFlayerEvent[2]
    {
      EAppsFlayerEvent.GUILDHELP_3DAYS,
      EAppsFlayerEvent.GUILDHELP_7DAYS
    };
    int[] numArray = new int[2]{ 3, 7 };
    for (int index = 0; index < numArray.Length; ++index)
    {
      this.ExtraObjectData[(int) eappsFlayerEventArray[index]].SetUnbrokenDay();
      if ((int) this.ExtraObjectData[(int) eappsFlayerEventArray[index]].UnbrokenDay >= numArray[index])
        this.TriggerAfAdvEvent(eappsFlayerEventArray[index]);
      if ((int) this.ExtraObjectData[(int) eappsFlayerEventArray[index]].UnbrokenDay >= numArray[index])
        this.TriggerAfAdvEvent(eappsFlayerEventArray[index]);
    }
  }

  public void CheckGatherTimberUnbroken()
  {
    EAppsFlayerEvent[] eappsFlayerEventArray = new EAppsFlayerEvent[2]
    {
      EAppsFlayerEvent.GATHERTIMBER_3DAYS,
      EAppsFlayerEvent.GATHERTIMBER_7DAYS
    };
    int[] numArray = new int[2]{ 3, 7 };
    for (int index = 0; index < numArray.Length; ++index)
    {
      this.ExtraObjectData[(int) eappsFlayerEventArray[index]].SetUnbrokenDay();
      if ((int) this.ExtraObjectData[(int) eappsFlayerEventArray[index]].UnbrokenDay >= numArray[index])
        this.TriggerAfAdvEvent(eappsFlayerEventArray[index]);
      if ((int) this.ExtraObjectData[(int) eappsFlayerEventArray[index]].UnbrokenDay >= numArray[index])
        this.TriggerAfAdvEvent(eappsFlayerEventArray[index]);
    }
  }

  public void CheckHeroStageUnbroken()
  {
    EAppsFlayerEvent[] eappsFlayerEventArray = new EAppsFlayerEvent[2]
    {
      EAppsFlayerEvent.HEROSTAGE_3DAYS,
      EAppsFlayerEvent.HEROSTAGE_7DAYS
    };
    int[] numArray = new int[2]{ 3, 7 };
    for (int index = 0; index < numArray.Length; ++index)
    {
      this.ExtraObjectData[(int) eappsFlayerEventArray[index]].SetUnbrokenDay();
      if ((int) this.ExtraObjectData[(int) eappsFlayerEventArray[index]].UnbrokenDay >= numArray[index])
        this.TriggerAfAdvEvent(eappsFlayerEventArray[index]);
      if ((int) this.ExtraObjectData[(int) eappsFlayerEventArray[index]].UnbrokenDay >= numArray[index])
        this.TriggerAfAdvEvent(eappsFlayerEventArray[index]);
    }
  }

  public void CheckTurfQuestUnbroken()
  {
    EAppsFlayerEvent[] eappsFlayerEventArray = new EAppsFlayerEvent[2]
    {
      EAppsFlayerEvent.TURFQUEST_3DAYS,
      EAppsFlayerEvent.TURFQUEST_7DAYS
    };
    int[] numArray = new int[2]{ 3, 7 };
    for (int index = 0; index < numArray.Length; ++index)
    {
      this.ExtraObjectData[(int) eappsFlayerEventArray[index]].SetUnbrokenDay();
      if ((int) this.ExtraObjectData[(int) eappsFlayerEventArray[index]].UnbrokenDay >= numArray[index])
        this.TriggerAfAdvEvent(eappsFlayerEventArray[index]);
      if ((int) this.ExtraObjectData[(int) eappsFlayerEventArray[index]].UnbrokenDay >= numArray[index])
        this.TriggerAfAdvEvent(eappsFlayerEventArray[index]);
    }
  }

  public void SupplyHest(uint id)
  {
    if (id != 12378U)
      return;
    this.TriggerAfAdvEvent(EAppsFlayerEvent.BUY_SUPPLYCHEST);
  }
}
