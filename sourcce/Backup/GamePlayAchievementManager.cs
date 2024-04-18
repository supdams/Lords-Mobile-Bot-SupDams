// Decompiled with JetBrains decompiler
// Type: GamePlayAchievementManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

#nullable disable
public class GamePlayAchievementManager
{
  public CExternalTableWithWordKey<_AchieveTbl> AchievementTable;
  private bool bAuthenticate;
  private bool bLoadRoleAchievement;
  private bool bSignin;
  private bool bSigninOpenAchievementUI;
  private Dictionary<int, string> RoleAchievementData;
  private string[] AchievementIDStr;
  private byte[] SendAchievement;
  private byte SendCount;
  private byte PushIdx;
  private byte Popindex;
  private byte Sending;
  private byte checkAuthenticate;
  private GamePlayAchievementManager._unlockAchievementList UnlockAchievementListNoSign = new GamePlayAchievementManager._unlockAchievementList();
  private float DelayTime;

  public void Init()
  {
    if (this.RoleAchievementData != null)
      return;
    this.RoleAchievementData = new Dictionary<int, string>();
  }

  public void Signin()
  {
    bool.TryParse(PlayerPrefs.GetString("Google_AchieveMent"), out this.bSignin);
    if (this.bSignin || !IGGSDKPlugin.CheckGooglePlayServicesUtil())
      return;
    PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().WithInvitationDelegate(new GooglePlayGames.BasicApi.InvitationReceivedDelegate(this.InvitationReceivedDelegate)).WithMatchDelegate(new GooglePlayGames.BasicApi.Multiplayer.MatchDelegate(this.MatchDelegate)).RequireGooglePlus().Build());
    PlayGamesPlatform.Activate();
    PlayGamesPlatform.Instance.Authenticate(new Action<bool>(this.AuthenticateRes), false);
    this.bSignin = true;
    PlayerPrefs.SetString("Google_AchieveMent", this.bSignin.ToString());
  }

  public void OpenAchievementUI()
  {
    if (!this.bAuthenticate)
    {
      if (!IGGSDKPlugin.CheckGooglePlayServicesUtil())
        return;
      PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().WithInvitationDelegate(new GooglePlayGames.BasicApi.InvitationReceivedDelegate(this.InvitationReceivedDelegate)).WithMatchDelegate(new GooglePlayGames.BasicApi.Multiplayer.MatchDelegate(this.MatchDelegate)).RequireGooglePlus().Build());
      PlayGamesPlatform.Activate();
      PlayGamesPlatform.Instance.Authenticate(new Action<bool>(this.AuthenticateRes), false);
      this.bSigninOpenAchievementUI = true;
    }
    else
    {
      Social.ShowAchievementsUI();
      this.bAuthenticate = false;
      this.checkAuthenticate = (byte) 5;
      if (this.Sending <= (byte) 0)
        return;
      this.Push((byte) ((uint) this.Sending - 1U));
      this.Sending = (byte) 0;
    }
  }

  public void testSignin()
  {
    if (this.bAuthenticate)
      ;
  }

  public void LoadTable()
  {
    this.AchievementTable = new CExternalTableWithWordKey<_AchieveTbl>();
    this.AchievementTable.LoadTable("Achievements");
  }

  public void Make(byte[] Buffer)
  {
    int tableCount = this.AchievementTable.TableCount;
    this.AchievementIDStr = new string[tableCount];
    this.SendAchievement = new byte[tableCount];
    for (int Index = 0; Index < tableCount; ++Index)
    {
      _AchieveTbl recordByIndex = this.AchievementTable.GetRecordByIndex(Index);
      Buffer[(int) recordByIndex.MissionID] = (byte) recordByIndex.AchievementID;
      this.AchievementIDStr[Index] = new string(recordByIndex.AchievementName, 0, this.CharLen(recordByIndex.AchievementName));
    }
  }

  private int CharLen(char[] str)
  {
    int index;
    for (index = str.Length - 1; index >= 0; --index)
    {
      if (str[index] != char.MinValue)
      {
        ++index;
        break;
      }
    }
    return index;
  }

  public void InvitationReceivedDelegate(Invitation invitation, bool shouldAutoAccept)
  {
  }

  public void MatchDelegate(TurnBasedMatch match, bool shouldAutoLaunch)
  {
  }

  public void AuthenticateRes(bool success)
  {
    this.bAuthenticate = success;
    if (!success)
      return;
    this.CheckUnlockAchievementState();
    if (!this.bSigninOpenAchievementUI)
      return;
    this.UpdateGameCenterLevel((ushort) DataManager.Instance.RoleAttr.Level);
    this.OpenAchievementUI();
    this.bSigninOpenAchievementUI = false;
  }

  public void LoadAchievementProcess(IAchievement[] achievements)
  {
    this.bLoadRoleAchievement = true;
    this.RoleAchievementData.Clear();
    for (int index = 0; index < achievements.Length; ++index)
    {
      if (achievements[index].completed)
        this.RoleAchievementData.Add(achievements[index].id.GetHashCode(), achievements[index].id);
    }
  }

  private void CheckUnlockAchievementState()
  {
    for (int index1 = 0; index1 < this.UnlockAchievementListNoSign.ID.Length; ++index1)
    {
      for (int index2 = 0; index2 < 8; ++index2)
      {
        if (this.UnlockAchievementListNoSign.Count == (byte) 0)
        {
          Array.Clear((Array) this.UnlockAchievementListNoSign.ID, 0, this.UnlockAchievementListNoSign.ID.Length);
          break;
        }
        if (((int) this.UnlockAchievementListNoSign.ID[index1] >> index2 & 1) > 0)
        {
          this.UnlockAchievement((byte) (8 * index1 + index2 + 1));
          --this.UnlockAchievementListNoSign.Count;
        }
      }
    }
  }

  public void UpdateGameCenterLevel(ushort level)
  {
    if (!this.bAuthenticate)
      return;
    Social.ReportScore((long) level, nameof (level), new Action<bool>(this.ScoreCallBack));
  }

  public void ScoreCallBack(bool result)
  {
  }

  public void UnlockAchievement(byte AchievementID)
  {
    if (!this.bAuthenticate)
      this.UnlockAchievementListNoSign.push(AchievementID);
    else
      this.Push((byte) this.AchievementTable.GetIndexByKey((ushort) AchievementID));
  }

  private void Push(byte val)
  {
    if ((int) this.SendCount >= this.SendAchievement.Length)
      return;
    this.SendAchievement[(int) this.PushIdx++ % this.SendAchievement.Length] = ++val;
    if (this.PushIdx == (byte) 0)
      this.PushIdx = (byte) (256 % this.SendAchievement.Length);
    ++this.SendCount;
  }

  private byte Pop()
  {
    if (this.SendCount == (byte) 0)
      return 0;
    --this.SendCount;
    byte num = this.SendAchievement[(int) this.Popindex++ % this.SendAchievement.Length];
    if (this.Popindex == (byte) 0)
      this.Popindex = (byte) (256 % this.SendAchievement.Length);
    return num;
  }

  private bool ReportAchievement(byte id)
  {
    string str;
    this.RoleAchievementData.TryGetValue(this.AchievementIDStr[(int) id].GetHashCode(), out str);
    if (str != null)
      return false;
    Social.ReportProgress(this.AchievementIDStr[(int) id], 100.0, new Action<bool>(this.AchievementRes));
    return true;
  }

  public void RefleshRoleAchievement()
  {
    if (!this.bAuthenticate)
      return;
    this.bLoadRoleAchievement = false;
    Social.LoadAchievements(new Action<IAchievement[]>(this.LoadAchievementProcess));
  }

  public void AchievementRes(bool res)
  {
    if (res)
    {
      this.RoleAchievementData.Add(this.AchievementIDStr[(int) this.Sending].GetHashCode(), this.AchievementIDStr[(int) this.Sending]);
      Debug.Log((object) "Success Achievement");
    }
    else
      Debug.Log((object) "Fail Achievement");
    this.Sending = (byte) 0;
  }

  public void Update(float delta)
  {
    if (this.checkAuthenticate > (byte) 0 || this.Sending != (byte) 0 || !this.bLoadRoleAchievement || !this.bAuthenticate)
      return;
    if ((double) this.DelayTime < 0.0)
    {
      byte num1 = this.Pop();
      if (num1 == (byte) 0)
        return;
      byte num2;
      for (this.Sending = (byte) ((uint) num1 - 1U); !this.ReportAchievement(this.Sending); this.Sending = (byte) ((uint) num2 - 1U))
      {
        this.Sending = (byte) 0;
        num2 = this.Pop();
        if (num2 == (byte) 0)
          return;
      }
      this.DelayTime = 2f;
    }
    else
      this.DelayTime -= delta;
  }

  public void ClearAchievement()
  {
    this.SendCount = (byte) 0;
    this.PushIdx = (byte) 0;
    this.Popindex = (byte) 0;
    this.Sending = (byte) 0;
    this.bLoadRoleAchievement = false;
  }

  public void CheckAuthenticate()
  {
    if (this.checkAuthenticate <= (byte) 0)
      return;
    this.checkAuthenticate = (byte) 0;
    this.bAuthenticate = PlayGamesPlatform.Instance.IsAuthenticated();
    if (!this.bAuthenticate)
      return;
    this.CheckUnlockAchievementState();
  }

  private struct _unlockAchievementList
  {
    public byte[] ID;
    public byte Count;

    public _unlockAchievementList(bool init = true)
    {
      this.ID = new byte[32];
      this.Count = (byte) 0;
    }

    public void push(byte val)
    {
      if (val == (byte) 0)
        return;
      int index = (int) val - 1 >> 3;
      int num = 1 << ((int) val - 1 & 7);
      if (((int) this.ID[index] & num) == 0)
        ++this.Count;
      this.ID[index] |= (byte) num;
    }
  }
}
