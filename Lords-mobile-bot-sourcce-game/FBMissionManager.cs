// Decompiled with JetBrains decompiler
// Type: FBMissionManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class FBMissionManager
{
  public const byte MaxPriceNum = 4;
  public const byte MaxMiaaionKind = 18;
  public const byte MAX_FB_FRIEND_IN_MISSION_NUM = 10;
  public const byte SOCIAL_NAME_LEN = 41;
  public const byte FB_MISSION_GOAL_NUM = 2;
  public CExternalTableWithWordKey<FBMissionTbl> FBMissionTable;
  public FBMissionManager.FBMissionGoalData[] Goals;
  public FBMissionManager.FbMissionProgress CurMissionProcess;
  private FBMissionManager.FBAward CurFBAwardData;
  public byte CurrentFriendNum;
  public SocialFriend[] FBFriends;
  private FriendComparer FriendComparer;
  public byte UpdateFriendSerialNo;
  public bool m_FBTimeEnd;
  public bool m_FBBindEnd;
  public bool bFB_CDTime;
  public bool bFB_btnShow;
  private FBMissionManager._FBHUMArray HudArray;
  private byte[] FriendsIndexTable;
  private byte[] FriendsBegin;
  private byte[] FriendsCount;
  public byte NeedSort;
  private byte[] FriendIconTable = new byte[10]
  {
    (byte) 3,
    (byte) 6,
    (byte) 2,
    (byte) 14,
    (byte) 11,
    (byte) 15,
    (byte) 26,
    (byte) 29,
    (byte) 30,
    (byte) 25
  };

  public FBMissionManager()
  {
    this.CurMissionProcess = new FBMissionManager.FbMissionProgress();
    this.Goals = new FBMissionManager.FBMissionGoalData[2];
    this.FBFriends = new SocialFriend[10];
    for (int index = 0; index < 10; ++index)
      this.FBFriends[index] = new SocialFriend();
    this.HudArray = new FBMissionManager._FBHUMArray((byte) 3);
    this.FriendComparer = new FriendComparer();
    this.FriendComparer.FriendsProgress = (FBMissionManager.FbMissionProgress[]) this.FBFriends;
    this.FriendsIndexTable = new byte[10];
  }

  public void LoadTable()
  {
    this.FBMissionTable = new CExternalTableWithWordKey<FBMissionTbl>();
    this.FBMissionTable.LoadTable("FBMission");
    int length = this.FBMissionTable.TableCount + 1;
    this.FriendsBegin = new byte[length];
    this.FriendsCount = new byte[length];
  }

  public ushort GetRewardIndex() => (ushort) this.CurFBAwardData.AwardIndex;

  public byte GetRewardSerial() => this.CurFBAwardData.UserSerialNo;

  public ushort GetRewardCount() => this.CurFBAwardData.AwardTotalNum;

  public FBMissionManager.FBAward GetReward() => this.CurFBAwardData;

  public void GetMissionState(ref FBMissionManager.FBMissionState State, ushort ID, int index)
  {
    if (index >= 2)
    {
      State = new FBMissionManager.FBMissionState();
    }
    else
    {
      FBMissionTbl recordByKey = this.FBMissionTable.GetRecordByKey(ID);
      State.type = recordByKey.MissionItems[index].Kind;
      State.GoalNum = recordByKey.MissionItems[index].Parm;
      State.bCount = State.type == (byte) 1 || State.type == (byte) 3 || State.type == (byte) 4 || State.type == (byte) 7 || State.type == (byte) 8 || State.type == (byte) 10 || State.type == (byte) 15 || State.type == (byte) 17 || (byte) 18 < State.type ? (byte) 0 : (byte) 1;
      if ((int) ID == (int) this.CurMissionProcess.NodeIndex)
      {
        State.CurNum = this.Goals[index].Record;
        if (State.CurNum <= State.GoalNum)
          return;
        State.CurNum = State.GoalNum;
      }
      else
        State.CurNum = State.GoalNum = 0U;
    }
  }

  public void GetNarrative(
    CString NarrativeStr,
    ref FBMissionTbl ManorData,
    byte id,
    bool checkCurMission = true)
  {
    DataManager instance = DataManager.Instance;
    NarrativeStr.ClearString();
    if ((int) id >= ManorData.MissionItems.Length)
      return;
    FBMissionManager.FBMissionState State = new FBMissionManager.FBMissionState();
    if (checkCurMission)
      this.GetMissionState(ref State, ManorData.ID, (int) id);
    switch (ManorData.MissionItems[(int) id].Kind)
    {
      case 0:
        break;
      case 1:
      case 2:
      case 3:
      case 5:
      case 6:
      case 9:
      case 11:
      case 12:
      case 13:
      case 14:
      case 15:
      case 16:
      case 18:
        NarrativeStr.IntToFormat((long) ManorData.MissionItems[(int) id].Parm, 0, true);
        if (checkCurMission && State.bCount == (byte) 1 && State.CurNum < State.GoalNum)
        {
          NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.OwnProcressDescribe[(int) id]));
          break;
        }
        NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.MissionItems[(int) id].Descirb));
        break;
      case 4:
        NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint) instance.TalentData.GetRecordByKey((ushort) ManorData.MissionItems[(int) id].Parm).NameID));
        NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.MissionItems[(int) id].Descirb));
        break;
      case 7:
        NarrativeStr.StringToFormat(instance.mStringTable.GetStringByID((uint) DataManager.StageDataController.CorpsStageTable.GetRecordByKey((ushort) ManorData.MissionItems[(int) id].Parm).StageName));
        NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.MissionItems[(int) id].Descirb));
        break;
      case 8:
        CString tmpS = StringManager.Instance.StaticString1024();
        uint x1 = ManorData.MissionItems[(int) id].Parm / 18U;
        uint x2 = ManorData.MissionItems[(int) id].Parm % 18U;
        if (x2 > 0U)
          ++x1;
        tmpS.IntToFormat((long) x1);
        if (x2 == 0U)
          x2 = 18U;
        tmpS.IntToFormat((long) x2);
        tmpS.AppendFormat("{0}-{1}");
        NarrativeStr.StringToFormat(tmpS);
        NarrativeStr.AppendFormat(instance.mStringTable.GetStringByID((uint) ManorData.MissionItems[(int) id].Descirb));
        break;
      case 10:
      case 17:
        NarrativeStr.Append(instance.mStringTable.GetStringByID((uint) ManorData.MissionItems[(int) id].Descirb));
        break;
      default:
        NarrativeStr.Append(instance.mStringTable.GetStringByID(1049U));
        break;
    }
  }

  public bool IsInTime()
  {
    return this.CurMissionProcess.MissionTime.BeginTime + (long) this.CurMissionProcess.MissionTime.RequireTime > DataManager.Instance.ServerTime;
  }

  public uint GetRemainTime()
  {
    long num = this.CurMissionProcess.MissionTime.BeginTime + (long) this.CurMissionProcess.MissionTime.RequireTime - DataManager.Instance.ServerTime;
    return num > 0L ? (uint) num : 0U;
  }

  public void CheckHUDMsg(byte kind)
  {
    CString msg = StringManager.Instance.StaticString1024();
    GUIManager instance = GUIManager.Instance;
    int index1 = 0;
    this.HudArray.Find(kind, ref index1, msg);
    while (index1 != -1)
    {
      instance.AddHUDQueue(msg.ToString(), (ushort) byte.MaxValue);
      msg = StringManager.Instance.StaticString1024();
      this.HudArray.Find(kind, ref index1, msg);
    }
    byte num = 0;
    FBMissionManager.FBMissionState State = new FBMissionManager.FBMissionState();
    for (int index2 = 0; index2 < 2; ++index2)
    {
      this.GetMissionState(ref State, this.Goals[index2].MissionId, index2);
      if ((int) State.GoalNum == (int) State.CurNum && State.CurNum > 0U)
        ++num;
    }
    if (num != (byte) 2 || this.CurMissionProcess.bShowHUD != (byte) 0)
      return;
    this.CurMissionProcess.bShowHUD = (byte) 1;
    FBMissionTbl recordByKey = this.FBMissionTable.GetRecordByKey((ushort) this.CurMissionProcess.NodeIndex);
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.Name));
    cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12184U));
    GUIManager.Instance.AddHUDQueue(cstring.ToString(), (ushort) byte.MaxValue);
  }

  public void ClearHUDArray() => this.HudArray.Clear();

  public void OnLoginFinish() => this.HudArray.Clear();

  public int GetFriendIndex(byte serialno, byte index = 255)
  {
    int friendIndex = -1;
    if ((int) index < (int) this.CurrentFriendNum && (int) this.FBFriends[(int) index].UserSerialNo == (int) serialno)
    {
      friendIndex = (int) index;
    }
    else
    {
      for (int index1 = 0; index1 < (int) this.CurrentFriendNum; ++index1)
      {
        if ((int) this.FBFriends[index1].UserSerialNo == (int) serialno)
        {
          friendIndex = index1;
          break;
        }
      }
    }
    return friendIndex;
  }

  private void SortFriends()
  {
    if (this.NeedSort == (byte) 0)
      return;
    this.NeedSort = (byte) 0;
    Array.Clear((Array) this.FriendsCount, 0, this.FriendsCount.Length);
    Array.Sort<byte>(this.FriendsIndexTable, 0, (int) this.CurrentFriendNum, (IComparer<byte>) this.FriendComparer);
    byte index1 = 0;
    for (byte index2 = 0; (int) index2 < (int) this.CurrentFriendNum; ++index2)
    {
      int index3 = (int) this.FriendsIndexTable[(int) index2] - 1;
      if (index3 >= 0)
      {
        if ((int) this.FBFriends[index3].NodeIndex != (int) index1)
        {
          if ((int) this.FBFriends[index3].NodeIndex >= this.FriendsBegin.Length)
            break;
          index1 = this.FBFriends[index3].NodeIndex;
          this.FriendsBegin[(int) index1] = index2;
          this.FriendsCount[(int) index1] = (byte) 1;
        }
        else
          ++this.FriendsCount[(int) index1];
      }
    }
  }

  public byte GetFriendCountByProgress(byte progress)
  {
    byte friendCountByProgress = 0;
    this.SortFriends();
    if ((int) progress < this.FriendsCount.Length)
      friendCountByProgress = this.FriendsCount[(int) progress];
    return friendCountByProgress;
  }

  public void GetFriendSocialInfo(byte progress, int index, out SocialFriend friend, bool GetInfo = true)
  {
    friend = (SocialFriend) null;
    if ((int) progress >= this.FriendsCount.Length || index >= (int) this.FriendsCount[(int) progress])
      return;
    int index1 = (int) this.FriendsIndexTable[(int) this.FriendsBegin[(int) progress] + index] - 1;
    if (index1 >= this.FBFriends.Length)
      return;
    friend = this.FBFriends[index1];
    if (!GetInfo || this.FBFriends[index1].Name.Length != 0)
      return;
    this.SendFriend_SocialInfo(this.FBFriends[index1].UserSerialNo);
  }

  public FBMissionManager.FBAward GetAwardSocialInfo() => this.CurFBAwardData;

  public EmojiUnit GetFriendEmoji(byte progress, int index)
  {
    SocialFriend friend;
    this.GetFriendSocialInfo(progress, index, out friend, false);
    return friend != null ? this.GetFriendEmoji((ushort) friend.IconNo) : (EmojiUnit) null;
  }

  public EmojiUnit GetFriendEmoji(ushort key)
  {
    if (key == (ushort) 0 || (int) key > this.FriendIconTable.Length)
      key = (ushort) 1;
    return GUIManager.Instance.pullEmojiIcon((ushort) this.FriendIconTable[(int) key - 1], (byte) 0);
  }

  public bool CheckReSetFB_CDTime()
  {
    bool flag = false;
    long result1 = 0;
    long result2 = 0;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.ClearString();
    cstring.IntToFormat(NetworkManager.UserID);
    cstring.AppendFormat("{0}_FB_CDTime_UseID");
    long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result1);
    if (result1 == 0L)
    {
      PlayerPrefs.SetString(cstring.ToString(), NetworkManager.UserID.ToString());
      result1 = NetworkManager.UserID;
    }
    cstring.ClearString();
    cstring.IntToFormat(result1);
    cstring.AppendFormat("{0}_FB_CDTime_Time");
    long.TryParse(PlayerPrefs.GetString(cstring.ToString()), out result2);
    if (result2 > 0L && result2 - ActivityManager.Instance.ServerEventTime <= 0L || result2 == 0L)
      flag = true;
    return flag;
  }

  public bool IsCanSetFB_CDTime(CString tmpName = null, long m_UseID = 0)
  {
    bool flag = false;
    if (tmpName == null)
      tmpName = StringManager.Instance.StaticString1024();
    long result = 0;
    if (m_UseID == 0L)
    {
      tmpName.ClearString();
      tmpName.IntToFormat(NetworkManager.UserID);
      tmpName.AppendFormat("{0}_FB_CDTime_UseID");
      long.TryParse(PlayerPrefs.GetString(tmpName.ToString()), out m_UseID);
    }
    tmpName.ClearString();
    tmpName.IntToFormat(m_UseID);
    tmpName.AppendFormat("{0}_FB_CDTime_Time_Check");
    long.TryParse(PlayerPrefs.GetString(tmpName.ToString()), out result);
    if (result == 0L || result <= ActivityManager.Instance.ServerEventTime && GameConstants.GetDateTime(result + 86400L).Day <= GameConstants.GetDateTime(ActivityManager.Instance.ServerEventTime).Day || GameConstants.GetDateTime(result + 86400L).Month < GameConstants.GetDateTime(ActivityManager.Instance.ServerEventTime).Month || GameConstants.GetDateTime(result + 86400L).Year < GameConstants.GetDateTime(ActivityManager.Instance.ServerEventTime).Year)
    {
      flag = true;
      PlayerPrefs.SetString(tmpName.ToString(), ActivityManager.Instance.ServerEventTime.ToString());
    }
    return flag;
  }

  public void ReSetFB_CDTime(CString tmpName = null)
  {
    long result = 0;
    if (tmpName == null)
      tmpName = StringManager.Instance.StaticString1024();
    tmpName.ClearString();
    tmpName.IntToFormat(NetworkManager.UserID);
    tmpName.AppendFormat("{0}_FB_CDTime_UseID");
    long.TryParse(PlayerPrefs.GetString(tmpName.ToString()), out result);
    if (!this.IsCanSetFB_CDTime(tmpName, result))
      return;
    tmpName.ClearString();
    tmpName.IntToFormat(result);
    tmpName.AppendFormat("{0}_FB_CDTime_Time");
    long num = (long) (86400 * UnityEngine.Random.Range(10, 14));
    PlayerPrefs.SetString(tmpName.ToString(), (ActivityManager.Instance.ServerEventTime + num).ToString());
    DataManager.FBMissionDataManager.bFB_btnShow = false;
  }

  public void RecvFBMissionInfo(MessagePacket MP)
  {
    this.CurMissionProcess.UserSerialNo = MP.ReadByte();
    this.CurMissionProcess.NodeIndex = MP.ReadByte();
    this.CurMissionProcess.MissionTime.BeginTime = MP.ReadLong();
    this.CurMissionProcess.MissionTime.RequireTime = MP.ReadUInt();
    if (this.CurMissionProcess.NodeIndex > (byte) 1)
      AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_I);
    if (this.CurMissionProcess.NodeIndex > (byte) 5)
      AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_V);
    if (this.CurMissionProcess.NodeIndex > (byte) 10)
      AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_X);
    FBMissionManager.FBMissionState State = new FBMissionManager.FBMissionState();
    byte num = 2;
    for (int index = 0; index < 2; ++index)
    {
      this.Goals[index].MissionId = MP.ReadUShort();
      this.Goals[index].GoalIndex = MP.ReadByte();
      this.Goals[index].Type = MP.ReadByte();
      this.Goals[index].Record = MP.ReadUInt();
      this.GetMissionState(ref State, this.Goals[index].MissionId, index);
      if ((int) State.CurNum == (int) State.GoalNum)
        --num;
    }
    if (num == (byte) 0)
      this.CurMissionProcess.bShowHUD = (byte) 1;
    this.CurFBAwardData.UserSerialNo = MP.ReadByte();
    this.CurFBAwardData.AwardIndex = MP.ReadByte();
    this.CurFBAwardData.AwardTotalNum = MP.ReadUShort();
    this.CurrentFriendNum = MP.ReadByte();
    if (this.CurrentFriendNum > (byte) 10)
      this.CurrentFriendNum = (byte) 10;
    for (int index = 0; index < (int) this.CurrentFriendNum; ++index)
    {
      this.FBFriends[index].Clear();
      this.FBFriends[index].UserSerialNo = MP.ReadByte();
      this.FriendsIndexTable[index] = (byte) (index + 1);
      this.FBFriends[index].NodeIndex = MP.ReadByte();
      if (this.FBFriends[index].NodeIndex == (byte) 0)
        this.FBFriends[index].NodeIndex = (byte) 1;
      this.FBFriends[index].MissionTime.BeginTime = MP.ReadLong();
      this.FBFriends[index].MissionTime.RequireTime = MP.ReadUInt();
      this.FBFriends[index].TimeRemain = this.FBFriends[index].MissionTime.BeginTime > 0L;
    }
    this.NeedSort = (byte) 1;
    DataManager.Instance.RoleAttr.Inviter.Name.ClearString();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 20);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other, 5);
  }

  public void RecvFBMissionStart(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Mission);
    if (MP.ReadByte() > (byte) 0)
      return;
    this.CurMissionProcess.MissionTime.BeginTime = MP.ReadLong();
    this.CurMissionProcess.MissionTime.RequireTime = MP.ReadUInt();
    DataManager.Instance.RoleAttr.PrizeFlag |= 134217728U;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27);
  }

  public void SendFBGetReward()
  {
    GUIManager.Instance.ShowUILock(EUILock.Mission);
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_FB_GET_AWARD;
    messagePacket.AddSeqId();
    messagePacket.Add(this.CurFBAwardData.UserSerialNo);
    messagePacket.Add(this.CurFBAwardData.AwardIndex);
    messagePacket.Send();
  }

  public void RecvFBGetReward(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.Mission);
    byte x = MP.ReadByte();
    if (x > (byte) 0)
    {
      CString cstring = StringManager.Instance.StaticString1024();
      cstring.IntToFormat((long) x);
      cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12185U));
      GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
    }
    else
    {
      if (this.CurFBAwardData.AwardIndex == (byte) 11)
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_MissionFB, 1);
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27, 1);
      AudioManager.Instance.PlayUISFX(UIKind.RewardReceive);
    }
  }

  public void UpdateFBMissionProGress(MessagePacket MP)
  {
    byte serialno = MP.ReadByte();
    if ((int) this.CurMissionProcess.UserSerialNo == (int) serialno)
    {
      byte num = MP.ReadByte();
      if ((int) this.CurMissionProcess.NodeIndex != (int) num)
      {
        this.CurMissionProcess.bShowHUD = (byte) 0;
        this.ClearHUDArray();
      }
      this.CurMissionProcess.NodeIndex = num;
      this.CurMissionProcess.MissionTime.BeginTime = MP.ReadLong();
      this.CurMissionProcess.MissionTime.RequireTime = MP.ReadUInt();
      if (this.CurMissionProcess.NodeIndex > (byte) 1)
        AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_I);
      if (this.CurMissionProcess.NodeIndex > (byte) 5)
        AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_V);
      if (this.CurMissionProcess.NodeIndex <= (byte) 10)
        return;
      AFAdvanceManager.Instance.TriggerAfAdvEvent(EAppsFlayerEvent.COMPLETE_VOYAGE_X);
    }
    else
    {
      int friendIndex = this.GetFriendIndex(serialno);
      if (friendIndex < 0)
        return;
      this.UpdateFriendSerialNo = byte.MaxValue;
      this.FBFriends[friendIndex].NodeIndex = MP.ReadByte();
      if (this.FBFriends[friendIndex].NodeIndex == (byte) 0)
        this.FBFriends[friendIndex].NodeIndex = (byte) 1;
      this.FBFriends[friendIndex].MissionTime.BeginTime = MP.ReadLong();
      this.FBFriends[friendIndex].MissionTime.RequireTime = MP.ReadUInt();
      this.NeedSort = (byte) 1;
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_MissionFB, 0);
    }
  }

  public void UpdateMissionReward(MessagePacket MP)
  {
    ushort awardTotalNum = this.CurFBAwardData.AwardTotalNum;
    this.CurFBAwardData.UserSerialNo = MP.ReadByte();
    this.CurFBAwardData.AwardIndex = MP.ReadByte();
    this.CurFBAwardData.AwardTotalNum = MP.ReadUShort();
    if ((int) this.CurFBAwardData.AwardTotalNum > (int) awardTotalNum && (int) this.CurMissionProcess.UserSerialNo != (int) this.CurFBAwardData.UserSerialNo)
      GUIManager.Instance.AddHUDQueue(DataManager.Instance.mStringTable.GetStringByID(12189U), (ushort) byte.MaxValue);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27, 1);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 20);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_Other, 5);
  }

  public void UpdateMissionGoals(MessagePacket MP)
  {
    FBMissionManager.FBMissionState State = new FBMissionManager.FBMissionState();
    byte num1 = 0;
    byte num2 = 2;
    FBMissionTbl recordByKey = this.FBMissionTable.GetRecordByKey((ushort) this.CurMissionProcess.NodeIndex);
    byte num3 = 0;
    for (int index = 0; index < 2; ++index)
    {
      ushort num4 = MP.ReadUShort();
      if ((int) num4 != (int) this.Goals[index].MissionId)
        this.Goals[index].Clear();
      this.Goals[index].MissionId = num4;
      this.GetMissionState(ref State, this.Goals[index].MissionId, index);
      uint curNum = State.CurNum;
      this.Goals[index].GoalIndex = MP.ReadByte();
      this.Goals[index].Type = MP.ReadByte();
      this.Goals[index].Record = MP.ReadUInt();
      this.GetMissionState(ref State, this.Goals[index].MissionId, index);
      if ((int) State.GoalNum == (int) State.CurNum && State.CurNum > 0U)
      {
        ++num1;
        if (recordByKey.MissionItems[index].Kind != (byte) 17)
        {
          if (State.CurNum > curNum)
          {
            CString msg = StringManager.Instance.StaticString1024();
            CString cstring = StringManager.Instance.StaticString1024();
            this.GetNarrative(cstring, ref recordByKey, (byte) index, false);
            msg.StringToFormat(cstring);
            msg.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12183U));
            if (this.Goals[index].Type == (byte) 11)
            {
              num3 = this.Goals[index].Type;
              this.HudArray.Add(msg, this.Goals[index].MissionId, this.Goals[index].Type);
            }
            else if (this.Goals[index].Type == (byte) 7)
            {
              if (recordByKey.MissionItems[index].Parm > (uint) DataManager.StageDataController.StageRecord[2])
              {
                num3 = this.Goals[index].Type;
                this.HudArray.Add(msg, this.Goals[index].MissionId, this.Goals[index].Type);
              }
              else
                GUIManager.Instance.AddHUDQueue(msg.ToString(), (ushort) byte.MaxValue);
            }
            else
              GUIManager.Instance.AddHUDQueue(msg.ToString(), (ushort) byte.MaxValue);
          }
        }
        else
          --num2;
      }
    }
    if (num3 == (byte) 0 && (int) num1 == (int) num2 && this.CurMissionProcess.bShowHUD == (byte) 0)
    {
      this.CurMissionProcess.bShowHUD = (byte) 1;
      if (recordByKey.ID == (ushort) 11)
      {
        GUIManager.Instance.AddHUDQueue(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.Name), (ushort) byte.MaxValue);
      }
      else
      {
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.Name));
        cstring.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12184U));
        GUIManager.Instance.AddHUDQueue(cstring.ToString(), (ushort) byte.MaxValue);
      }
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_MissionFB, 0);
  }

  public void RecvSocialData(MessagePacket MP)
  {
    MP.ReadStringPlus(41, SocialManager.Instance.SocialName);
    DataManager.Instance.RoleAttr.Inviter.Invited = MP.ReadByte();
    MP.ReadStringPlus(41, DataManager.Instance.RoleAttr.Inviter.SocialName);
    SocialManager.Instance.MaxConcurrentFriend = MP.ReadByte();
    this.CurrentFriendNum = MP.ReadByte();
    if (this.CurrentFriendNum > (byte) 10)
      this.CurrentFriendNum = (byte) 10;
    CString outString = StringManager.Instance.StaticString1024();
    for (byte index = 0; (int) index < (int) this.CurrentFriendNum; ++index)
    {
      MP.ReadStringPlus(41, outString);
      byte num = MP.ReadByte();
      if ((int) this.FBFriends[(int) index].UserSerialNo != (int) num)
      {
        this.FBFriends[(int) index].TimeRemain = false;
        this.FBFriends[(int) index].Clear();
      }
      this.FBFriends[(int) index].SocialName.ClearString();
      this.FBFriends[(int) index].SocialName.Append(outString);
      this.FBFriends[(int) index].UserSerialNo = num;
      this.FBFriends[(int) index].IconNo = MP.ReadByte();
      this.FriendsIndexTable[(int) index] = (byte) ((uint) index + 1U);
    }
    for (byte currentFriendNum = this.CurrentFriendNum; currentFriendNum < (byte) 10; ++currentFriendNum)
      this.FBFriends[(int) currentFriendNum].UserSerialNo = (byte) 0;
    this.NeedSort = (byte) 1;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27);
    if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 2 || DataManager.Instance.RoleAttr.Inviter.Invited <= (byte) 0 || SocialManager.Instance.CheckBonding(false) || DataManager.Instance.CheckPrizeFlag((byte) 30))
      return;
    SocialManager.Instance.BindingPlatform();
  }

  public void SendFriend_SocialInfo(byte serialno)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_FRIEND_USER_INFO;
    messagePacket.AddSeqId();
    messagePacket.Add(serialno);
    messagePacket.Send();
  }

  public void RespFriendSocialInfo(MessagePacket MP)
  {
    byte num = MP.ReadByte();
    byte serialno = MP.ReadByte();
    if (serialno > (byte) 0)
    {
      int friendIndex = this.GetFriendIndex(serialno);
      if (friendIndex < 0)
        return;
      this.UpdateFriendSerialNo = serialno;
      this.FBFriends[friendIndex].Result = num;
      this.FBFriends[friendIndex].Head = MP.ReadUShort();
      MP.ReadStringPlus(13, this.FBFriends[friendIndex].Name);
      MP.ReadStringPlus(3, this.FBFriends[friendIndex].AllianceTag);
      if (this.FBFriends[friendIndex].Name.Length == 0 && num == (byte) 0)
        return;
    }
    else
    {
      this.UpdateFriendSerialNo = serialno;
      DataManager.Instance.RoleAttr.Inviter.Result = num;
      DataManager.Instance.RoleAttr.Inviter.Head = MP.ReadUShort();
      MP.ReadStringPlus(13, DataManager.Instance.RoleAttr.Inviter.Name);
      MP.ReadStringPlus(3, DataManager.Instance.RoleAttr.Inviter.AllianceTag);
      if (DataManager.Instance.RoleAttr.Inviter.Name.Length == 0 && num == (byte) 0)
        return;
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_MissionFB, 0);
  }

  public void UpdateFriendName(MessagePacket MP)
  {
    byte serialno = MP.ReadByte();
    if (serialno == (byte) 0)
    {
      MP.ReadStringPlus(13, DataManager.Instance.RoleAttr.Inviter.Name);
    }
    else
    {
      CString outString = StringManager.Instance.StaticString1024();
      MP.ReadStringPlus(13, outString);
      int friendIndex = this.GetFriendIndex(serialno);
      if (friendIndex >= 0)
      {
        this.UpdateFriendSerialNo = serialno;
        this.FBFriends[friendIndex].Name.ClearString();
        this.FBFriends[friendIndex].Name.Append(outString);
      }
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_MissionFB, 0);
  }

  public void RESP_SOCIAL_ENABLE(MessagePacket MP)
  {
    byte invitation = DataManager.Instance.RoleAttr.Invitation;
    DataManager.Instance.RoleAttr.Invitation = MP.ReadByte();
    if ((int) DataManager.Instance.RoleAttr.Invitation == (int) invitation)
      return;
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 27);
  }

  public struct FBMissionGoalData
  {
    public ushort MissionId;
    public byte GoalIndex;
    public byte Type;
    public uint Record;

    public void Clear()
    {
      this.MissionId = (ushort) 0;
      this.GoalIndex = (byte) 0;
      this.Type = (byte) 0;
      this.Record = 0U;
    }
  }

  public struct FBAward
  {
    public byte UserSerialNo;
    public byte AwardIndex;
    public ushort AwardTotalNum;
  }

  public class FbMissionProgress
  {
    public byte UserSerialNo;
    public byte NodeIndex;
    public byte bShowHUD;
    public TimeEventDataType MissionTime;
  }

  private struct _FBHUMArray
  {
    public CString[] Msg;
    public byte[] Kind;
    public ushort MissionID;
    public byte Size;
    private int End;

    public _FBHUMArray(byte count)
    {
      this.Msg = new CString[(int) count];
      for (int index = 0; index < (int) count; ++index)
        this.Msg[index] = new CString(64);
      this.Kind = new byte[(int) count];
      this.Size = (byte) 0;
      this.End = 0;
      this.MissionID = (ushort) 0;
    }

    public void Add(CString msg, ushort missionID, byte kind)
    {
      if (this.MissionID > (ushort) 0 && (int) this.MissionID != (int) missionID)
        this.Clear();
      if ((int) this.Size >= this.Msg.Length || this.End >= this.Msg.Length)
        return;
      this.MissionID = missionID;
      this.Msg[this.End].ClearString();
      this.Msg[this.End].Append(msg);
      this.Kind[this.End] = kind;
      ++this.End;
      ++this.Size;
    }

    public void Clear()
    {
      this.Size = (byte) 0;
      this.End = 0;
      this.MissionID = (ushort) 0;
    }

    public void Find(byte kind, ref int index, CString msg)
    {
      if (this.Size == (byte) 0)
      {
        index = -1;
      }
      else
      {
        byte size = this.Size;
        for (int index1 = index; index1 < this.Kind.Length; ++index1)
        {
          if ((int) this.Kind[index1] == (int) kind)
          {
            this.Kind[index1] = byte.MaxValue;
            --this.Size;
            msg.ClearString();
            msg.Append(this.Msg[index1]);
            break;
          }
        }
        if ((int) size != (int) this.Size)
          return;
        index = -1;
      }
    }
  }

  public struct FBMissionState
  {
    public byte bCount;
    public byte type;
    public uint CurNum;
    public uint GoalNum;
  }

  private class _FriendUI
  {
    public byte SerialNo;
    public Image HeadImg;
    public UIText SocialText;
    public UIText NameText;
    public CString NameStr;
  }

  private struct FriendUIInfoQueue
  {
    public byte head;
    public byte size;
    public FBMissionManager._FriendUI[] FriendUI;

    public FriendUIInfoQueue(byte Capacity)
    {
      this.head = (byte) 0;
      this.size = (byte) 0;
      this.FriendUI = new FBMissionManager._FriendUI[(int) Capacity];
      for (int index = 0; index < (int) Capacity; ++index)
        this.FriendUI[index] = new FBMissionManager._FriendUI();
    }

    public void Push(
      Image HeadImg,
      UIText Name,
      UIText SocialName,
      CString NameStr,
      byte SerialNo)
    {
      int length = this.FriendUI.Length;
      if (length <= (int) this.size)
        return;
      int index = ((int) this.head + (int) this.size) % length;
      ++this.size;
      this.FriendUI[index].SerialNo = SerialNo;
      this.FriendUI[index].HeadImg = HeadImg;
      this.FriendUI[index].NameText = Name;
      this.FriendUI[index].SocialText = SocialName;
      this.FriendUI[index].NameStr = NameStr;
    }

    public FBMissionManager._FriendUI Pop()
    {
      if (this.size == (byte) 0)
        return (FBMissionManager._FriendUI) null;
      FBMissionManager._FriendUI friendUi = this.FriendUI[(int) this.head++];
      if ((int) this.head == this.FriendUI.Length)
        this.head = (byte) 0;
      --this.size;
      return friendUi;
    }

    public void clear()
    {
      this.head = (byte) 0;
      this.size = (byte) 0;
    }
  }
}
