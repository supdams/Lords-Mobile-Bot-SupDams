// Decompiled with JetBrains decompiler
// Type: AllianceBattle
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;

#nullable disable
public struct AllianceBattle
{
  public static BattleStation BattleRoyale;
  public static BattleStation BattleRoyaleView;
  public static bool ReplayPaused;
  public static byte ReplaySpeed;

  public static void CheckBattleStationA()
  {
    AllianceBattle.BattleRoyaleView.Clear();
    AllianceBattle.BattleRoyale.Clear();
  }

  public static void Reset() => AllianceBattle.ReplayPaused = false;

  public static bool Check()
  {
    return (int) ActivityManager.Instance.AW_Round == (int) AllianceBattle.BattleRoyale.GameRound && ActivityManager.Instance.AW_RoundBeginTime == AllianceBattle.BattleRoyale.BeginTime;
  }

  public static void RecvAllianceBattleStation(MessagePacket MP)
  {
    switch (MP.Protocol)
    {
      case Protocol._MSG_RESP_ALLIANCEWAR_LIVE_LEFTSIDE_LIST:
        if (AllianceBattle.BattleRoyale.AutobotTag == null)
          AllianceBattle.BattleRoyale.AutobotTag = StringManager.Instance.SpawnString(3);
        MP.ReadStringPlus(3, AllianceBattle.BattleRoyale.AutobotTag);
        AllianceBattle.BattleRoyale.CampAutobot = MP.ReadByte();
        AllianceBattle.BattleRoyale.AutobotIcon = MP.ReadUShort();
        AllianceBattle.BattleRoyale.AutobotPos = MP.ReadByte();
        AllianceBattle.BattleRoyale.Autobots = MP.ReadByte();
        ActivityManager.Instance.AllianceWarMgr.Initial();
        for (int index = 0; index < (int) AllianceBattle.BattleRoyale.Autobots && index < ActivityManager.Instance.AllianceWarMgr.RegisterData.Length; ++index)
        {
          ActivityManager.Instance.AllianceWarMgr.RegisterData[(int) AllianceBattle.BattleRoyale.Autobots - index - 1].Initial();
          MP.ReadStringPlus(13, ActivityManager.Instance.AllianceWarMgr.RegisterData[(int) AllianceBattle.BattleRoyale.Autobots - index - 1].Name);
          ActivityManager.Instance.AllianceWarMgr.RegisterData[(int) AllianceBattle.BattleRoyale.Autobots - index - 1].Power = MP.ReadULong();
          ActivityManager.Instance.AllianceWarMgr.RegisterData[(int) AllianceBattle.BattleRoyale.Autobots - index - 1].Head = MP.ReadUShort();
        }
        if (AllianceBattle.BattleRoyale.Autobots <= (byte) 0 || AllianceBattle.BattleRoyale.AutobotPos <= (byte) 0 || (int) AllianceBattle.BattleRoyale.Autobots < (int) AllianceBattle.BattleRoyale.AutobotPos)
          break;
        AllianceBattle.BattleRoyale.AutobotPos = (byte) ((int) AllianceBattle.BattleRoyale.Autobots - (int) AllianceBattle.BattleRoyale.AutobotPos + 1);
        break;
      case Protocol._MSG_RESP_ALLIANCEWAR_LIVE_RIGHTSIDE_LIST:
        if (AllianceBattle.BattleRoyale.DecepticonTag == null)
          AllianceBattle.BattleRoyale.DecepticonTag = StringManager.Instance.SpawnString(3);
        MP.ReadStringPlus(3, AllianceBattle.BattleRoyale.DecepticonTag);
        AllianceBattle.BattleRoyale.CampDecepticon = MP.ReadByte();
        AllianceBattle.BattleRoyale.DecepticonIcon = MP.ReadUShort();
        AllianceBattle.BattleRoyale.DecepticonPos = MP.ReadByte();
        AllianceBattle.BattleRoyale.Decepticons = MP.ReadByte();
        ActivityManager.Instance.AllianceWarMgr.Initial();
        for (int index = 0; index < (int) AllianceBattle.BattleRoyale.Decepticons && index < ActivityManager.Instance.AllianceWarMgr.WaitData.Length; ++index)
        {
          ActivityManager.Instance.AllianceWarMgr.WaitData[(int) AllianceBattle.BattleRoyale.Decepticons - index - 1].Initial();
          MP.ReadStringPlus(13, ActivityManager.Instance.AllianceWarMgr.WaitData[(int) AllianceBattle.BattleRoyale.Decepticons - index - 1].Name);
          ActivityManager.Instance.AllianceWarMgr.WaitData[(int) AllianceBattle.BattleRoyale.Decepticons - index - 1].Power = MP.ReadULong();
          ActivityManager.Instance.AllianceWarMgr.WaitData[(int) AllianceBattle.BattleRoyale.Decepticons - index - 1].Head = MP.ReadUShort();
        }
        if (AllianceBattle.BattleRoyale.Decepticons <= (byte) 0 || AllianceBattle.BattleRoyale.DecepticonPos <= (byte) 0 || (int) AllianceBattle.BattleRoyale.Decepticons < (int) AllianceBattle.BattleRoyale.DecepticonPos)
          break;
        AllianceBattle.BattleRoyale.DecepticonPos = (byte) ((int) AllianceBattle.BattleRoyale.Decepticons - (int) AllianceBattle.BattleRoyale.DecepticonPos + 1);
        break;
      case Protocol._MSG_RESP_ALLIANCEWAR_LIVE_WAR_DETAIL:
        AllianceBattle.BattleRoyale.BattleSide = AllianceBattle.BattleRoyale.CampAutobot <= (byte) 0 ? (AllianceBattle.BattleRoyale.CampDecepticon <= (byte) 0 ? (byte) 0 : (byte) 2) : (byte) 1;
        AllianceBattle.BattleRoyale.BattlePosition = AllianceBattle.BattleRoyale.AutobotPos <= (byte) 0 ? (AllianceBattle.BattleRoyale.DecepticonPos <= (byte) 0 ? (byte) 0 : AllianceBattle.BattleRoyale.DecepticonPos) : AllianceBattle.BattleRoyale.AutobotPos;
        byte num1 = MP.ReadByte();
        AllianceBattle.BattleRoyale.OnLive = MP.ReadByte();
        AllianceBattle.BattleRoyale.MatchID = MP.ReadByte();
        AllianceBattle.BattleRoyale.GameRound = MP.ReadByte();
        AllianceBattle.BattleRoyale.BattleMatchs = MP.ReadByte();
        if (num1 == (byte) 0 || AllianceBattle.BattleRoyale.BattleMatch == null || AllianceBattle.BattleRoyale.BattleMatch.Length != (int) AllianceBattle.BattleRoyale.BattleMatchs)
          AllianceBattle.BattleRoyale.BattleMatch = new AlliWarWarDetail[(int) AllianceBattle.BattleRoyale.BattleMatchs];
        for (int index = 0; index < AllianceBattle.BattleRoyale.BattleMatch.Length; ++index)
        {
          if (num1 == (byte) 0)
          {
            AllianceBattle.BattleRoyale.BattleMatch[index].WinnerSide = MP.ReadByte();
            AllianceBattle.BattleRoyale.BattleMatch[index].LeftSurvive = MP.ReadUInt();
            AllianceBattle.BattleRoyale.BattleMatch[index].RightSurvive = MP.ReadUInt();
          }
          else
          {
            AllianceBattle.BattleRoyale.BattleMatch[index].WinnerSide = MP.ReadByte();
            AllianceBattle.BattleRoyale.BattleMatch[index].LeftDead = MP.ReadUInt();
            AllianceBattle.BattleRoyale.BattleMatch[index].RightDead = MP.ReadUInt();
          }
        }
        if (AllianceBattle.BattleRoyale.OnLive > (byte) 0)
          AllianceBattle.BattleRoyale.BeginTime = ActivityManager.Instance.AW_RoundBeginTime;
        if (num1 != (byte) 1)
          break;
        ActivityManager.Instance.AW_bcalculateEnd = true;
        GUIManager.Instance.HideUILock(EUILock.Activity);
        Door menu1 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (UnityEngine.Object) menu1)
          break;
        ActivityManager.Instance.AllianceWarReopenCheck();
        if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarBattle))
        {
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarBattle, 4);
          break;
        }
        menu1.OpenMenu(EGUIWindow.UI_AllianceWarBattle, bCameraMode: true);
        break;
      case Protocol._MSG_RESP_ALLIANCEWAR_REPLAY_LEFTSIDE_LIST:
        if (AllianceBattle.BattleRoyaleView.AutobotTag == null)
          AllianceBattle.BattleRoyaleView.AutobotTag = StringManager.Instance.SpawnString(3);
        if (AllianceBattle.BattleRoyaleView.Autobot == null)
          AllianceBattle.BattleRoyaleView.Autobot = new AllianceWarManager._RegisterData[80];
        MP.ReadStringPlus(3, AllianceBattle.BattleRoyaleView.AutobotTag);
        AllianceBattle.BattleRoyaleView.CampAutobot = MP.ReadByte();
        AllianceBattle.BattleRoyaleView.AutobotIcon = MP.ReadUShort();
        AllianceBattle.BattleRoyaleView.AutobotPos = MP.ReadByte();
        AllianceBattle.BattleRoyaleView.Autobots = Math.Min(MP.ReadByte(), (byte) AllianceBattle.BattleRoyaleView.Autobot.Length);
        for (int index = 0; index < (int) AllianceBattle.BattleRoyaleView.Autobots && index < AllianceBattle.BattleRoyaleView.Autobot.Length; ++index)
        {
          AllianceBattle.BattleRoyaleView.Autobot[(int) AllianceBattle.BattleRoyaleView.Autobots - index - 1].Initial();
          MP.ReadStringPlus(13, AllianceBattle.BattleRoyaleView.Autobot[(int) AllianceBattle.BattleRoyaleView.Autobots - index - 1].Name);
          AllianceBattle.BattleRoyaleView.Autobot[(int) AllianceBattle.BattleRoyaleView.Autobots - index - 1].Power = MP.ReadULong();
          AllianceBattle.BattleRoyaleView.Autobot[(int) AllianceBattle.BattleRoyaleView.Autobots - index - 1].Head = MP.ReadUShort();
        }
        if (AllianceBattle.BattleRoyaleView.Autobots <= (byte) 0 || AllianceBattle.BattleRoyaleView.AutobotPos <= (byte) 0 || (int) AllianceBattle.BattleRoyaleView.Autobots < (int) AllianceBattle.BattleRoyaleView.AutobotPos)
          break;
        AllianceBattle.BattleRoyaleView.AutobotPos = (byte) ((int) AllianceBattle.BattleRoyaleView.Autobots - (int) AllianceBattle.BattleRoyaleView.AutobotPos + 1);
        break;
      case Protocol._MSG_RESP_ALLIANCEWAR_REPLAY_RIGHTSIDE_LIST:
        if (AllianceBattle.BattleRoyaleView.DecepticonTag == null)
          AllianceBattle.BattleRoyaleView.DecepticonTag = StringManager.Instance.SpawnString(3);
        if (AllianceBattle.BattleRoyaleView.Decepticon == null)
          AllianceBattle.BattleRoyaleView.Decepticon = new AllianceWarManager._RegisterData[80];
        MP.ReadStringPlus(3, AllianceBattle.BattleRoyaleView.DecepticonTag);
        AllianceBattle.BattleRoyaleView.CampDecepticon = MP.ReadByte();
        AllianceBattle.BattleRoyaleView.DecepticonIcon = MP.ReadUShort();
        AllianceBattle.BattleRoyaleView.DecepticonPos = MP.ReadByte();
        AllianceBattle.BattleRoyaleView.Decepticons = Math.Min(MP.ReadByte(), (byte) AllianceBattle.BattleRoyaleView.Decepticon.Length);
        for (int index = 0; index < (int) AllianceBattle.BattleRoyaleView.Decepticons && index < AllianceBattle.BattleRoyaleView.Decepticon.Length; ++index)
        {
          AllianceBattle.BattleRoyaleView.Decepticon[(int) AllianceBattle.BattleRoyaleView.Decepticons - index - 1].Initial();
          MP.ReadStringPlus(13, AllianceBattle.BattleRoyaleView.Decepticon[(int) AllianceBattle.BattleRoyaleView.Decepticons - index - 1].Name);
          AllianceBattle.BattleRoyaleView.Decepticon[(int) AllianceBattle.BattleRoyaleView.Decepticons - index - 1].Power = MP.ReadULong();
          AllianceBattle.BattleRoyaleView.Decepticon[(int) AllianceBattle.BattleRoyaleView.Decepticons - index - 1].Head = MP.ReadUShort();
        }
        if (AllianceBattle.BattleRoyaleView.Decepticons <= (byte) 0 || AllianceBattle.BattleRoyaleView.DecepticonPos <= (byte) 0 || (int) AllianceBattle.BattleRoyaleView.Decepticons < (int) AllianceBattle.BattleRoyaleView.DecepticonPos)
          break;
        AllianceBattle.BattleRoyaleView.DecepticonPos = (byte) ((int) AllianceBattle.BattleRoyaleView.Decepticons - (int) AllianceBattle.BattleRoyaleView.DecepticonPos + 1);
        break;
      case Protocol._MSG_RESP_ALLIANCEWAR_REPLAY_WAR_DETAIL:
        AllianceBattle.BattleRoyaleView.BattleSide = AllianceBattle.BattleRoyaleView.CampAutobot <= (byte) 0 ? (AllianceBattle.BattleRoyaleView.CampDecepticon <= (byte) 0 ? (byte) 0 : (byte) 2) : (byte) 1;
        AllianceBattle.BattleRoyaleView.BattlePosition = AllianceBattle.BattleRoyaleView.AutobotPos <= (byte) 0 ? (AllianceBattle.BattleRoyaleView.DecepticonPos <= (byte) 0 ? (byte) 0 : AllianceBattle.BattleRoyaleView.DecepticonPos) : AllianceBattle.BattleRoyaleView.AutobotPos;
        byte num2 = MP.ReadByte();
        AllianceBattle.BattleRoyaleView.OnLive = MP.ReadByte();
        AllianceBattle.BattleRoyaleView.MatchID = MP.ReadByte();
        AllianceBattle.BattleRoyaleView.GameRound = MP.ReadByte();
        AllianceBattle.BattleRoyaleView.BattleMatchs = MP.ReadByte();
        if (num2 == (byte) 0 || AllianceBattle.BattleRoyaleView.BattleMatch == null || AllianceBattle.BattleRoyaleView.BattleMatch.Length != (int) AllianceBattle.BattleRoyaleView.BattleMatchs)
          AllianceBattle.BattleRoyaleView.BattleMatch = new AlliWarWarDetail[(int) AllianceBattle.BattleRoyaleView.BattleMatchs];
        for (int index = 0; index < AllianceBattle.BattleRoyaleView.BattleMatch.Length; ++index)
        {
          if (num2 == (byte) 0)
          {
            AllianceBattle.BattleRoyaleView.BattleMatch[index].WinnerSide = MP.ReadByte();
            AllianceBattle.BattleRoyaleView.BattleMatch[index].LeftSurvive = MP.ReadUInt();
            AllianceBattle.BattleRoyaleView.BattleMatch[index].RightSurvive = MP.ReadUInt();
          }
          else
          {
            AllianceBattle.BattleRoyaleView.BattleMatch[index].WinnerSide = MP.ReadByte();
            AllianceBattle.BattleRoyaleView.BattleMatch[index].LeftDead = MP.ReadUInt();
            AllianceBattle.BattleRoyaleView.BattleMatch[index].RightDead = MP.ReadUInt();
          }
        }
        if (AllianceBattle.BattleRoyaleView.OnLive > (byte) 0)
          AllianceBattle.BattleRoyaleView.BeginTime = ActivityManager.Instance.AW_RoundBeginTime;
        if (num2 != (byte) 1)
          break;
        GUIManager.Instance.HideUILock(EUILock.Activity);
        Door menu2 = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (UnityEngine.Object) menu2)
          break;
        ActivityManager.Instance.AllianceWarReopenCheck();
        UIAllianceWarBattle.ResetMatchID();
        if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWarBattle))
        {
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWarBattle, 4);
          break;
        }
        menu2.OpenMenu(EGUIWindow.UI_AllianceWarBattle, arg2: 1, bCameraMode: true);
        break;
    }
  }
}
