// Decompiled with JetBrains decompiler
// Type: PushManage
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;

#nullable disable
public class PushManage
{
  private static PushManage _instance;
  public static bool PushStart;
  public long OrderEventBeginTime;

  private PushManage()
  {
  }

  public static PushManage Instance
  {
    get
    {
      if (PushManage._instance == null)
        PushManage._instance = new PushManage();
      return PushManage._instance;
    }
  }

  public static bool checkOldByteSwitch(int bits)
  {
    int num = 1 << bits;
    return ((int) DataManager.Instance.mSetNotice & num) == num;
  }

  public static bool checkNewByteSwitch(int bits)
  {
    return ((long) DataManager.Instance.mNewPushSwitch & (long) (1UL << bits)) == 0L;
  }

  public static bool checkPushSwitch(int oldBit, int newBit)
  {
    return PushManage.checkNewByteSwitch(newBit) && PushManage.checkOldByteSwitch(oldBit);
  }

  public void SetPushToSDK(bool pause)
  {
    if (!pause)
    {
      PushManage.ClearPush();
    }
    else
    {
      if (!PushManage.PushStart || NewbieManager.IsNewbie)
        return;
      if (PushManage.checkPushSwitch(0, 0))
      {
        long num1 = DataManager.Instance.queueBarData[0].StartTime + (long) DataManager.Instance.queueBarData[0].TotalTime;
        if (num1 > DataManager.Instance.ServerTime)
        {
          long sec = num1 - DataManager.Instance.ServerTime;
          this.SetPush(0, DataManager.Instance.mStringTable.GetStringByID(8440U), (int) sec);
        }
        long num2 = DataManager.Instance.queueBarData[1].StartTime + (long) DataManager.Instance.queueBarData[1].TotalTime;
        if (num2 > DataManager.Instance.ServerTime)
        {
          long sec = num2 - DataManager.Instance.ServerTime;
          this.SetPush(1, DataManager.Instance.mStringTable.GetStringByID(8441U), (int) sec);
        }
        long num3 = DataManager.Instance.queueBarData[10].StartTime + (long) DataManager.Instance.queueBarData[10].TotalTime;
        if (num3 > DataManager.Instance.ServerTime)
        {
          long sec = num3 - DataManager.Instance.ServerTime;
          this.SetPush(2, DataManager.Instance.mStringTable.GetStringByID(8445U), (int) sec);
        }
        long num4 = DataManager.Instance.queueBarData[14].StartTime + (long) DataManager.Instance.queueBarData[14].TotalTime;
        if (num4 > DataManager.Instance.ServerTime)
        {
          long sec = num4 - DataManager.Instance.ServerTime;
          this.SetPush(3, DataManager.Instance.mStringTable.GetStringByID(8446U), (int) sec);
        }
        long num5 = DataManager.Instance.queueBarData[18].StartTime + (long) DataManager.Instance.queueBarData[18].TotalTime;
        if (num5 > DataManager.Instance.ServerTime)
        {
          long sec = num5 - DataManager.Instance.ServerTime;
          this.SetPush(4, DataManager.Instance.mStringTable.GetStringByID(8455U), (int) sec);
        }
        for (int index = 0; index < PetManager.Instance.m_PetTrainingData.Length; ++index)
        {
          long num6 = PetManager.Instance.m_PetTrainingData[index].m_EventTime.BeginTime + (long) PetManager.Instance.m_PetTrainingData[index].m_EventTime.RequireTime;
          if (num6 > DataManager.Instance.ServerTime)
          {
            long sec = num6 - DataManager.Instance.ServerTime;
            this.SetPush(15 + index, DataManager.Instance.mStringTable.GetStringByID(16077U), (int) sec);
          }
        }
        long num7 = DataManager.Instance.queueBarData[34].StartTime + (long) DataManager.Instance.queueBarData[34].TotalTime;
        if (num7 > DataManager.Instance.ServerTime)
        {
          long sec = num7 - DataManager.Instance.ServerTime;
          if (DataManager.Instance.FusionDataTable.GetRecordByKey(PetManager.Instance.ItemCraftID).Fusion_Kind == (byte) 0)
            this.SetPush(23, DataManager.Instance.mStringTable.GetStringByID(16095U), (int) sec);
          else
            this.SetPush(23, DataManager.Instance.mStringTable.GetStringByID(16096U), (int) sec);
        }
      }
      if (PushManage.checkPushSwitch(3, 15) && GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 3 && DataManager.Instance.RoleAttr.NextOnlineGiftOpenTime > DataManager.Instance.ServerTime)
      {
        long sec = DataManager.Instance.RoleAttr.NextOnlineGiftOpenTime - DataManager.Instance.ServerTime;
        this.SetPush(5, DataManager.Instance.mStringTable.GetStringByID(8451U), (int) sec);
      }
      if (PushManage.checkPushSwitch(4, 16))
      {
        int num8 = (int) DataManager.Instance.HeroMaxMorale - (int) DataManager.Instance.RoleAttr.Morale;
        if (num8 > 0)
        {
          long num9 = DataManager.Instance.ServerTime - DataManager.Instance.RoleAttr.LastMoraleRecoverTime;
          int num10 = num8;
          if (num9 % 360L > 0L)
            --num10;
          long sec = (long) (num10 * 360) + num9;
          this.SetPush(6, DataManager.Instance.mStringTable.GetStringByID(8453U), (int) sec);
        }
        DataManager.Instance.GetMaxMonsterPoint();
        if ((int) DataManager.Instance.GetMaxMonsterPoint() - (int) DataManager.Instance.RoleAttr.MonsterPoint > 0)
        {
          long sec = (long) ((double) (DataManager.Instance.GetMaxMonsterPoint() - DataManager.Instance.RoleAttr.MonsterPoint) * ((double) DataManager.Instance.RoleAttr.MonsterPointRecoverFrequency / 1000.0));
          this.SetPush(7, DataManager.Instance.mStringTable.GetStringByID(8467U), (int) sec);
        }
      }
      if (PushManage.checkPushSwitch(5, 17))
      {
        int recvBuffDataIdxById = DataManager.Instance.GetRecvBuffDataIdxByID((ushort) 1);
        if (recvBuffDataIdxById >= 0)
        {
          long sec = DataManager.Instance.m_RecvItemBuffData[recvBuffDataIdxById].TargetTime - DataManager.Instance.ServerTime - 600L;
          if (sec > 0L)
            this.SetPush(8, DataManager.Instance.mStringTable.GetStringByID(8462U), (int) sec);
        }
      }
      if (PushManage.checkPushSwitch(11, 20))
      {
        long sec = DataManager.Instance.m_CryptData.startTime + (long) GameConstants.CryptSecends[(int) DataManager.Instance.m_CryptData.kind] - DataManager.Instance.ServerTime;
        if (sec > 0L)
          this.SetPush(9, DataManager.Instance.mStringTable.GetStringByID(9040U), (int) sec);
      }
      if (PushManage.checkPushSwitch(10, 21))
      {
        TimeEventDataType shelterTime = HideArmyManager.Instance.GetShelterTime();
        long sec = shelterTime.BeginTime + (long) shelterTime.RequireTime - DataManager.Instance.ServerTime - 600L;
        if (sec > 0L)
          this.SetPush(10, DataManager.Instance.mStringTable.GetStringByID(9048U), (int) sec);
      }
      if (PushManage.checkNewByteSwitch(22))
      {
        long sec = DataManager.MissionDataManager.GetTimerMissionData(_eMissionType.Affair).ResetTime - DataManager.Instance.ServerTime;
        if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 13 && sec > 0L)
          this.SetPush(13, DataManager.Instance.mStringTable.GetStringByID(9632U), (int) sec);
      }
      if (PushManage.checkPushSwitch(8, 11))
      {
        TimeEventDataType wonderCountTime = GUIManager.Instance.WonderCountTime;
        long sec1 = wonderCountTime.BeginTime + (long) wonderCountTime.RequireTime - DataManager.Instance.ServerTime - 600L;
        if (ActivityManager.Instance.KvKActivityData[4].EventState == EActivityState.EAS_Prepare)
        {
          long sec2 = ActivityManager.Instance.KvKActivityData[4].EventBeginTime - DataManager.Instance.ServerTime - 600L;
          if (sec2 > 0L)
            this.SetPush(12, DataManager.Instance.mStringTable.GetStringByID(9548U), (int) sec2);
          if (sec1 > 0L && sec1 < sec2)
            this.SetPush(11, DataManager.Instance.mStringTable.GetStringByID(9029U), (int) sec1);
        }
        else if (sec1 > 0L)
          this.SetPush(11, DataManager.Instance.mStringTable.GetStringByID(9029U), (int) sec1);
      }
      if (PushManage.checkNewByteSwitch(25))
      {
        long sec = this.OrderEventBeginTime - DataManager.Instance.ServerTime - 600L;
        if (sec > 0L)
          this.SetPush(14, DataManager.Instance.mStringTable.GetStringByID(9694U), (int) sec);
      }
      RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0);
      for (ushort Index = 0; (int) Index < DataManager.Instance.PushCallBackTable.TableCount; ++Index)
      {
        PushCallBack recordByIndex = DataManager.Instance.PushCallBackTable.GetRecordByIndex((int) Index);
        if (GameConstants.IsBetween((int) buildData.Level, (int) recordByIndex.LowLevel, (int) recordByIndex.HighLevel))
        {
          int ID = 10171 + Random.Range(0, 4);
          if (ID > 10174)
            ID = 10174;
          this.SetPush(24, DataManager.Instance.mStringTable.GetStringByID((uint) (ushort) ID), (int) recordByIndex.Hour * 3600);
          break;
        }
      }
    }
  }

  private void SetPush(int nid, string msg, int sec)
  {
    IGGSDKPlugin.SetLocalNotification(nid, msg, sec);
  }

  public static void ClearPush()
  {
    for (int index = 0; index < 25; ++index)
      IGGSDKPlugin.CancelNotification(index);
  }
}
