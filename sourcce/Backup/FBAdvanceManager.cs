// Decompiled with JetBrains decompiler
// Type: FBAdvanceManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
internal class FBAdvanceManager
{
  private const string FBvanceEventDataTag = "FBAdvanceEventData";
  private const string CastleLv = "FBCustomEvent_CastleLv";
  private const string FirstConquerTurfBattle = "FBCustomEvent_FirstConquerTurfBattle";
  private const string FirstUnlockNormalChapter = "FBCustomEvent_FirstUnlockNormalChapter";
  private const string CreditsForKVK = "FBCustomEvent_CreditsForKVK";
  private const string CreditsForGuildFest = "FBCustomEvent_CreditsForGuildFest";
  private const string KvKBeginTimeTag = "FBCustomEvent_KvKBeginTime";
  private const string MobilizationBeginTimeTag = "FBCustomEvent_MobilizationBeginTime";
  private const string TimeKey = "Time";
  private const string IGGIDKey = "IGGID";
  private const string CastleLvKey = "CastleLv";
  private const string BattleIdKey = "BattleId";
  private const string FirstPointKey = "FirstPoint";
  private const int MAX_LEN = 1;
  private long kvKBeginTime;
  private long mobilizationBeginTime;
  private long[] m_SaveData = new long[1];
  private static FBAdvanceManager instance;

  public static FBAdvanceManager Instance
  {
    get
    {
      if (FBAdvanceManager.instance == null)
        FBAdvanceManager.instance = new FBAdvanceManager();
      return FBAdvanceManager.instance;
    }
  }

  public void TriggerFbEvent(EFBEvent evnet, long beginTime = 0, ulong point = 0)
  {
    switch (evnet)
    {
      case EFBEvent.SUPPLY_CHEST:
        IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID);
        break;
      case EFBEvent.CASTLE_LEVEL:
        int result1 = 0;
        int.TryParse(PlayerPrefs.GetString("FBCustomEvent_CastleLv"), out result1);
        int level = (int) GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level;
        if (level <= result1)
          break;
        PlayerPrefs.SetInt("FBCustomEvent_CastleLv", level);
        KeyValuePair<string, string> keyValuePair1 = new KeyValuePair<string, string>("CastleLv", level.ToString());
        IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID, keyValuePair1);
        break;
      case EFBEvent.FIRST_CONQUER_TURF_BATTLE:
        int num1 = (int) DataManager.StageDataController.StageRecord[2];
        int result2 = 0;
        int.TryParse(PlayerPrefs.GetString("FBCustomEvent_FirstConquerTurfBattle"), out result2);
        if (num1 <= result2)
          break;
        PlayerPrefs.SetInt("FBCustomEvent_FirstConquerTurfBattle", num1);
        KeyValuePair<string, string> keyValuePair2 = new KeyValuePair<string, string>("BattleId", num1.ToString());
        IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID, keyValuePair2);
        break;
      case EFBEvent.FIRST_UNLOCK_NORMAL_CHAPTER:
        int num2 = (int) DataManager.StageDataController.StageRecord[0];
        int result3 = 0;
        int.TryParse(PlayerPrefs.GetString("FBCustomEvent_FirstUnlockNormalChapter"), out result3);
        if (num2 <= result3)
          break;
        PlayerPrefs.SetInt("FBCustomEvent_FirstUnlockNormalChapter", num2);
        KeyValuePair<string, string> keyValuePair3 = new KeyValuePair<string, string>("BattleId", num2.ToString());
        IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID, keyValuePair3);
        break;
      case EFBEvent.CREDITS_FOR_KVK:
        if (beginTime <= this.kvKBeginTime)
          break;
        long result4 = 0;
        long.TryParse(PlayerPrefs.GetString("FBCustomEvent_KvKBeginTime"), out result4);
        if (beginTime <= result4)
          break;
        this.kvKBeginTime = beginTime;
        PlayerPrefs.SetString("FBCustomEvent_KvKBeginTime", this.kvKBeginTime.ToString());
        KeyValuePair<string, string> keyValuePair4 = new KeyValuePair<string, string>("FirstPoint", point.ToString());
        IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID, keyValuePair4);
        break;
      case EFBEvent.CREDITS_FOR_GUILD_FEST:
        if (beginTime <= this.mobilizationBeginTime)
          break;
        long result5 = 0;
        long.TryParse(PlayerPrefs.GetString("FBCustomEvent_MobilizationBeginTime"), out result5);
        if (beginTime <= result5)
          break;
        this.mobilizationBeginTime = beginTime;
        PlayerPrefs.SetString("FBCustomEvent_MobilizationBeginTime", this.mobilizationBeginTime.ToString());
        KeyValuePair<string, string> keyValuePair5 = new KeyValuePair<string, string>("FirstPoint", point.ToString());
        IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID, keyValuePair5);
        break;
      case EFBEvent.COLLECT_EXTRA_SUPPLIES:
        IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID);
        break;
    }
  }

  public void TriggerFbUniqueEvent(EFBEvent evnet)
  {
    if (evnet < EFBEvent.FIRST_PACT_OPENED || evnet >= EFBEvent.MAX || !this.CheckRequirement(evnet))
      return;
    IGGSDKPlugin.SetFacebookCustomEvent(evnet.ToString(), this.GetTimeString(), IGGGameSDK.Instance.m_IGGID);
    this.SaveEventData(evnet);
  }

  private void SaveEventData(EFBEvent evnet)
  {
    int index = (int) evnet / 64;
    if (index >= 0 && index < this.m_SaveData.Length)
    {
      this.m_SaveData[index] |= 1L << (int) (evnet & (EFBEvent) 63 & (EFBEvent) 63);
      PlayerPrefs.SetString("FBAdvanceEventData_" + (object) index, this.m_SaveData[index].ToString());
    }
    else
      Debug.Log((object) ("FBAdvanceEventData_" + (object) index + " : Index Error"));
  }

  private bool IsRecord(EFBEvent evnet)
  {
    int index = (int) evnet / 64;
    if (index >= 0)
    {
      if (index < this.m_SaveData.Length)
      {
        try
        {
          bool flag = false;
          this.m_SaveData[index] = 0L;
          flag = long.TryParse(PlayerPrefs.GetString("FBAdvanceEventData_" + (object) index), out this.m_SaveData[index]);
          return (this.m_SaveData[index] & 1L << (int) (evnet & (EFBEvent) 63)) != 0L;
        }
        catch (Exception ex)
        {
          Debug.Log((object) ("FBAdvanceEventData_" + (object) index + " Exception : " + ex.ToString()));
          return true;
        }
      }
    }
    Debug.Log((object) ("FBAdvanceEventData_" + (object) index + " : Index Error"));
    return true;
  }

  private bool CheckRequirement(EFBEvent evnet) => !this.IsRecord(evnet);

  public string GetTimeString()
  {
    try
    {
      return GameConstants.GetDateTime(DataManager.Instance.ServerTime).ToUniversalTime().AddHours(-5.0).ToString();
    }
    catch (Exception ex)
    {
      return string.Empty;
    }
  }
}
