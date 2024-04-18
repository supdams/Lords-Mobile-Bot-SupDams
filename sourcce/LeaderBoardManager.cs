// Decompiled with JetBrains decompiler
// Type: LeaderBoardManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
public class LeaderBoardManager
{
  private const int boardCount = 16;
  public const int AllianceWarGap = 43200;
  public const int MobilizationUpdateGap = 180;
  public const int AlliHuntUpdateGap = 180;
  public LeaderBoardTopBoard TopBoard;
  public long[] BoardUpdateTime;
  public List<BoardUnit>[] Boards;
  public ushort[] MyRank;
  public byte[] BoardRecived;
  public UIButtonHint hintTarget;
  public Transform hintCenter;
  public long KingdomBoardNextTime;
  public KVKBoardTopBoard KvKTopBoard;
  public long AlliMobiEventTime;
  public uint MobiGroupAllianceID;
  public List<MobilizationGroupBroudUnit> MobiGroupBoard;
  public long MobiGroupBoardUpdateTime;
  public int MobiGroupRank;
  public uint MobiGroupLastScore;
  public ushort MobiGroupSaveVer;
  public List<MobilizationAlliBroudUnit> MobiAlliBoard;
  public long MobiAlliBoardUpdateTime;
  public int MobiAlliRank;
  public List<HistoryWorldKingDataType> MobiWorldKingBoard;
  public byte HistoryKingDataNum;
  public ushort KingHead;
  public WorldLeaderBoardTopBoard WorldLeaderBoardTopBoard;
  public long KingofWorldTime;
  public ushort KingofWorldHead;
  public List<KingofWorldBoardUnit> KingofWorldBoard;
  public ushort NobileWonderId;
  public long NobileTime;
  public ushort NobileHead;
  public List<KingofWorldBoardUnit> NobileBoard;
  public KVSBoardTopBoard KVSTopBoard;
  public List<BoardUnit> AlliHuntBoard;
  public long AlliHuntBoardUpdateTime;
  public int AlliHuntRank;
  public long AlliHuntEventTime;
  public long AlliVSEventTime;
  public List<AllianceWarBroudUnit> AllianceWarGroupBoard;
  public long AllianceWarGroupBoardUpdateTime;
  public int AllianceWarGroupRank;
  public byte AllianceWarGroupRankUpNum;
  public byte AllianceWarGroupRankDownNum;
  public long AllianceWarAlliBoardUpdateTime;
  private static LeaderBoardManager _instance;

  private LeaderBoardManager()
  {
    this.BoardUpdateTime = new long[16];
    this.BoardRecived = new byte[16];
    this.MyRank = new ushort[16];
    this.TopBoard = new LeaderBoardTopBoard();
    this.Boards = new List<BoardUnit>[16];
    for (int index = 0; index < 16; ++index)
    {
      this.Boards[index] = new List<BoardUnit>();
      this.Boards[index].Clear();
    }
    this.KvKTopBoard = new KVKBoardTopBoard();
    this.KvKTopBoard.KvKAlliTopPlayerHead = (ushort) 0;
    this.KvKTopBoard.KvKAlliTopPlayerName.ClearString();
    this.KvKTopBoard.KvKAlliTopPlayerValue = 0UL;
    this.KVSTopBoard = new KVSBoardTopBoard();
    this.MobiGroupBoard = new List<MobilizationGroupBroudUnit>();
    this.MobiAlliBoard = new List<MobilizationAlliBroudUnit>();
    this.MobiWorldKingBoard = new List<HistoryWorldKingDataType>();
    this.WorldLeaderBoardTopBoard = new WorldLeaderBoardTopBoard();
    this.KingofWorldBoard = new List<KingofWorldBoardUnit>();
    this.NobileBoard = new List<KingofWorldBoardUnit>();
    ushort result1 = 0;
    uint result2 = 0;
    if (ushort.TryParse(PlayerPrefs.GetString("AllianceMobilizationVer_" + (object) DataManager.Instance.RoleAttr.UserId), out result1))
      this.MobiGroupSaveVer = result1;
    if (!uint.TryParse(PlayerPrefs.GetString("AllianceMobilizationScore_" + (object) DataManager.Instance.RoleAttr.UserId), out result2))
      return;
    this.MobiGroupLastScore = result2;
  }

  public bool ClearBoard(int BoardID)
  {
    for (int index = 0; index < this.Boards[BoardID].Count; ++index)
    {
      StringManager.Instance.DeSpawnString(this.Boards[BoardID][index].AlliaceTag);
      StringManager.Instance.DeSpawnString(this.Boards[BoardID][index].Name);
    }
    this.Boards[BoardID].Clear();
    this.BoardUpdateTime[BoardID] = 0L;
    byte num = this.BoardRecived[BoardID];
    this.BoardRecived[BoardID] = (byte) 0;
    return num != (byte) 0;
  }

  public void TotalClear()
  {
    this.TopBoard.SortTime = 0L;
    this.KingdomBoardNextTime = 0L;
    for (int BoardID = 0; BoardID < 16; ++BoardID)
      this.ClearBoard(BoardID);
  }

  public void ClearMobilizationBoard(UI_LeaderBoardUpdateKind kind)
  {
    switch (kind)
    {
      case UI_LeaderBoardUpdateKind.MobilizationGroupData:
        for (int index = 0; index < this.MobiGroupBoard.Count; ++index)
        {
          StringManager.Instance.DeSpawnString(this.MobiGroupBoard[index].AllianceTag);
          StringManager.Instance.DeSpawnString(this.MobiGroupBoard[index].Name);
        }
        this.MobiGroupBoard.Clear();
        this.MobiGroupBoardUpdateTime = 0L;
        break;
      case UI_LeaderBoardUpdateKind.MobilizationAlliData:
        for (int index = 0; index < this.MobiAlliBoard.Count; ++index)
          StringManager.Instance.DeSpawnString(this.MobiAlliBoard[index].Name);
        this.MobiAlliBoard.Clear();
        this.MobiAlliBoardUpdateTime = 0L;
        break;
    }
  }

  public void Recv_MSG_RESP_LEADERBOARDS_CLIENT(MessagePacket MP)
  {
    this.TopBoard.SortTime = MP.ReadLong();
    MP.ReadStringPlus(3, this.TopBoard.PowerTop.AlliaceTag);
    MP.ReadStringPlus(13, this.TopBoard.PowerTop.Name);
    this.TopBoard.PowerTop.Value = MP.ReadULong();
    this.TopBoard.PowerTopHead = MP.ReadUShort();
    MP.ReadStringPlus(3, this.TopBoard.KillsTop.AlliaceTag);
    MP.ReadStringPlus(13, this.TopBoard.KillsTop.Name);
    this.TopBoard.KillsTop.Value = MP.ReadULong();
    this.TopBoard.KillTopHead = MP.ReadUShort();
    MP.ReadStringPlus(3, this.TopBoard.AlliPowerTop.AlliaceTag);
    MP.ReadStringPlus(20, this.TopBoard.AlliPowerTop.Name);
    this.TopBoard.AlliPowerTop.Value = MP.ReadULong();
    int num1 = (int) MP.ReadUInt();
    this.TopBoard.PowerTopEmblem = MP.ReadUShort();
    MP.ReadStringPlus(3, this.TopBoard.AlliKillsTop.AlliaceTag);
    MP.ReadStringPlus(20, this.TopBoard.AlliKillsTop.Name);
    this.TopBoard.AlliKillsTop.Value = MP.ReadULong();
    int num2 = (int) MP.ReadUInt();
    this.TopBoard.KillsTopEmblem = MP.ReadUShort();
    MP.ReadStringPlus(3, this.TopBoard.ArenaTop.AlliaceTag);
    MP.ReadStringPlus(13, this.TopBoard.ArenaTop.Name);
    this.TopBoard.ArenaTop.Value = MP.ReadULong();
    this.TopBoard.ArenaTopHead = MP.ReadUShort();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 2);
  }

  public void Recv_MSG_RESP_BOARDCONTENT(MessagePacket MP)
  {
    byte BoardID = MP.ReadByte();
    byte num1 = MP.ReadByte();
    ushort num2 = MP.ReadUShort();
    long num3 = MP.ReadLong();
    MP.ReadByte();
    bool flag = false;
    if (BoardID >= (byte) 16)
      return;
    if (num1 == (byte) 0)
    {
      flag = this.ClearBoard((int) BoardID);
      this.BoardUpdateTime[(int) BoardID] = num3;
      this.MyRank[(int) BoardID] = num2;
      if (GameConstants.IsBetween((int) BoardID, 5, 7))
        this.BoardUpdateTime[(int) BoardID] = DataManager.Instance.ServerTime + 43200L;
      if (GameConstants.IsBetween((int) BoardID, 12, 15))
        this.BoardUpdateTime[(int) BoardID] = DataManager.Instance.ServerTime + 43200L;
    }
    if (num1 > (byte) 0 && (int) num1 != (int) this.BoardRecived[(int) BoardID] + 1)
      return;
    this.BoardRecived[(int) BoardID] = num1;
    switch (BoardID)
    {
      case 0:
      case 1:
      case 4:
        for (int index = 0; index < 20; ++index)
        {
          BoardUnit boardUnit = new BoardUnit();
          MP.ReadStringPlus(3, boardUnit.AlliaceTag);
          MP.ReadStringPlus(13, boardUnit.Name);
          boardUnit.Value = MP.ReadULong();
          this.Boards[(int) BoardID].Add(boardUnit);
        }
        break;
      case 2:
      case 3:
        for (int index = 0; index < 20; ++index)
        {
          BoardUnitAlliance boardUnitAlliance = new BoardUnitAlliance();
          MP.ReadStringPlus(3, boardUnitAlliance.AlliaceTag);
          MP.ReadStringPlus(20, boardUnitAlliance.Name);
          boardUnitAlliance.Value = MP.ReadULong();
          boardUnitAlliance.AllianceID = MP.ReadUInt();
          this.Boards[(int) BoardID].Add((BoardUnit) boardUnitAlliance);
        }
        break;
      case 5:
      case 12:
        for (int index = 0; index < 20; ++index)
        {
          BoardUnitKingdom boardUnitKingdom = new BoardUnitKingdom();
          boardUnitKingdom.KingdomID = MP.ReadUShort();
          MP.ReadStringPlus(3, boardUnitKingdom.AlliaceTag);
          MP.ReadStringPlus(13, boardUnitKingdom.Name);
          boardUnitKingdom.KingKingdomID = MP.ReadUShort();
          this.Boards[(int) BoardID].Add((BoardUnit) boardUnitKingdom);
        }
        break;
      case 6:
      case 13:
        for (int index = 0; index < 20; ++index)
        {
          BoardUnitKingdomWarAlliance kingdomWarAlliance = new BoardUnitKingdomWarAlliance();
          kingdomWarAlliance.KingdomID = MP.ReadUShort();
          kingdomWarAlliance.AllianceID = MP.ReadUInt();
          MP.ReadStringPlus(3, kingdomWarAlliance.AlliaceTag);
          MP.ReadStringPlus(20, kingdomWarAlliance.Name);
          kingdomWarAlliance.Value = MP.ReadULong();
          this.Boards[(int) BoardID].Add((BoardUnit) kingdomWarAlliance);
        }
        break;
      case 8:
      case 9:
      case 14:
      case 15:
        for (int index = 0; index < 20; ++index)
        {
          WorldRankingBoardUnit rankingBoardUnit = new WorldRankingBoardUnit();
          MP.ReadStringPlus(3, rankingBoardUnit.AlliaceTag);
          MP.ReadStringPlus(13, rankingBoardUnit.Name);
          rankingBoardUnit.Value = MP.ReadULong();
          rankingBoardUnit.KingdomID = MP.ReadUShort();
          this.Boards[(int) BoardID].Add((BoardUnit) rankingBoardUnit);
        }
        break;
      case 10:
      case 11:
        for (int index = 0; index < 20; ++index)
        {
          WorldRankingBoardUnitAlliance boardUnitAlliance = new WorldRankingBoardUnitAlliance();
          MP.ReadStringPlus(3, boardUnitAlliance.AlliaceTag);
          MP.ReadStringPlus(20, boardUnitAlliance.Name);
          boardUnitAlliance.Value = MP.ReadULong();
          boardUnitAlliance.AllianceID = MP.ReadUInt();
          boardUnitAlliance.KingdomID = MP.ReadUShort();
          this.Boards[(int) BoardID].Add((BoardUnit) boardUnitAlliance);
        }
        break;
    }
    if (flag)
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8457U), (ushort) byte.MaxValue);
    if (num1 == (byte) 0)
    {
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 4, (int) BoardID);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_KingdomVSLBoard, 4, (int) BoardID);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_KVKLBoard, 4, (int) BoardID);
    }
    else
    {
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 3, (int) BoardID);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_KingdomVSLBoard, 3, (int) BoardID);
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_KVKLBoard, 3, (int) BoardID);
    }
  }

  public void Recv_MSG_RESP_ARENA_BOARDDATA(MessagePacket MP)
  {
    ArenaManager.Instance.m_ArenaTargetHint.AllianceTagTag = MP.ReadString(3);
    ArenaManager.Instance.m_ArenaTargetHint.Name = MP.ReadString(13);
    ArenaManager.Instance.m_ArenaTargetHint.Place = (uint) (byte) MP.ReadULong();
    ArenaManager.Instance.m_ArenaTargetHint.HeroData = new ArenaTargetHeroDataType[5];
    ++ArenaManager.Instance.m_ArenaTargetHint.Place;
    for (int index = 0; index < 5; ++index)
    {
      ArenaManager.Instance.m_ArenaTargetHint.HeroData[index].ID = MP.ReadUShort();
      ArenaManager.Instance.m_ArenaTargetHint.HeroData[index].Level = MP.ReadByte();
      ArenaManager.Instance.m_ArenaTargetHint.HeroData[index].Rank = MP.ReadByte();
      ArenaManager.Instance.m_ArenaTargetHint.HeroData[index].Star = MP.ReadByte();
      ArenaManager.Instance.m_ArenaTargetHint.HeroData[index].Equip = MP.ReadByte();
      MP.ReadInt();
    }
    ArenaManager.Instance.m_ArenaTargetHint.Head = ArenaManager.Instance.m_ArenaTargetHint.HeroData[0].ID;
    Transform parent = this.hintTarget.transform.parent;
    this.hintTarget.transform.SetParent(this.hintCenter);
    Vector2 anchoredPosition = this.hintTarget.GetComponent<RectTransform>().anchoredPosition;
    this.hintTarget.transform.SetParent(parent);
    this.hintTarget.transform.SetSiblingIndex(11);
    GUIManager.Instance.m_Arena_Hint.Show(this.hintTarget, -40f, Mathf.Clamp(anchoredPosition.y + 410f, -190f, 150f), (byte) 0);
  }

  public void Recv_MSG_RESP_ACTIVITY_AEVENT_PERSONAL_RANK(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    byte num1 = MP.ReadByte();
    byte num2 = MP.ReadByte();
    if (((int) num1 & 1) > 0)
    {
      this.ClearBoard(7);
      this.MyRank[7] = (ushort) 0;
    }
    for (int index = 0; index < (int) num2; ++index)
    {
      BoardUnit boardUnit = new BoardUnit();
      MP.ReadStringPlus(13, boardUnit.Name);
      boardUnit.Value = MP.ReadULong();
      boardUnit.AlliaceTag.Append(DataManager.Instance.RoleAlliance.Tag);
      this.Boards[7].Add(boardUnit);
    }
    if (num1 < (byte) 2)
      return;
    LeaderBoardManager.Instance.BoardUpdateTime[7] = DataManager.Instance.ServerTime + 43200L;
    this.Boards[7].Sort(new Comparison<BoardUnit>(LeaderBoardManager.BoardUnitSortByValue));
    for (int index = 0; index < this.Boards[7].Count; ++index)
    {
      if (DataManager.CompareStr(this.Boards[7][index].Name, DataManager.Instance.RoleAttr.Name) == 0)
        this.MyRank[7] = (ushort) (index + 1);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 3, 7);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_KingdomVSLBoard, 3, 7);
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_KVKLBoard, 3, 7);
  }

  public void Recv_MSG_RESP_KVK_TOPBORAD(MessagePacket MP)
  {
    LeaderBoardManager.Instance.KingdomBoardNextTime = DataManager.Instance.ServerTime + 43200L;
    if (this.KvKTopBoard == null)
      this.KvKTopBoard = new KVKBoardTopBoard();
    this.KvKTopBoard.SortTime = MP.ReadLong();
    this.KvKTopBoard.TopKingdom = MP.ReadUShort();
    this.KvKTopBoard.KvKTopAlliKingdomID = MP.ReadUShort();
    this.KvKTopBoard.KvKTopAlliAllianceID = MP.ReadUInt();
    MP.ReadStringPlus(3, this.KvKTopBoard.KvKTopAlliTag);
    MP.ReadStringPlus(20, this.KvKTopBoard.KvKTopAlliName);
    this.KvKTopBoard.KvKTopAlliScore = MP.ReadULong();
    this.KvKTopBoard.KvKTopAlliEmblem = MP.ReadUShort();
    MP.ReadStringPlus(13, this.KvKTopBoard.KvKAlliTopPlayerName);
    this.KvKTopBoard.KvKAlliTopPlayerValue = MP.ReadULong();
    this.KvKTopBoard.KvKAlliTopPlayerHead = MP.ReadUShort();
    this.KvKTopBoard.KingdomEventRequireTime = MP.ReadUInt();
    MP.ReadStringPlus(3, this.KvKTopBoard.KvKTopPlayerTag);
    MP.ReadStringPlus(13, this.KvKTopBoard.KvKTopPlayerName);
    this.KvKTopBoard.KvKPlayerValue = MP.ReadULong();
    this.KvKTopBoard.KvKTopPlayerKingdomID = MP.ReadUShort();
    this.KvKTopBoard.KvKPlayerHead = MP.ReadUShort();
    this.KvKTopBoard.AllianceID = (ulong) DataManager.Instance.RoleAlliance.Id;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_KVKLBoard, 2);
  }

  public void Recv_MSG_RESP_KINGDOM_VS_TOPBOARD(MessagePacket MP)
  {
    LeaderBoardManager.Instance.KingdomBoardNextTime = DataManager.Instance.ServerTime + 43200L;
    if (this.KVSTopBoard == null)
      this.KVSTopBoard = new KVSBoardTopBoard();
    this.KVSTopBoard.SortTime = MP.ReadLong();
    if (this.KVSTopBoard.SortTime == 0L)
      LeaderBoardManager.Instance.KingdomBoardNextTime = 0L;
    this.KVSTopBoard.KVSTopKingdom = MP.ReadUShort();
    this.KVSTopBoard.KVSTopAlliKingdomID = MP.ReadUShort();
    this.KVSTopBoard.KVSTopAlliAllianceID = MP.ReadUInt();
    MP.ReadStringPlus(3, this.KVSTopBoard.KVSTopAlliTag);
    MP.ReadStringPlus(20, this.KVSTopBoard.KVSTopAlliName);
    this.KVSTopBoard.KVSTopAlliScore = MP.ReadULong();
    this.KVSTopBoard.KVSTopAlliEmblem = MP.ReadUShort();
    MP.ReadStringPlus(3, this.KVSTopBoard.KVSTopPlayerTag);
    MP.ReadStringPlus(13, this.KVSTopBoard.KVSTopPlayerName);
    this.KVSTopBoard.KVSPlayerValue = MP.ReadULong();
    this.KVSTopBoard.KVSTopPlayerKingdomID = MP.ReadUShort();
    this.KVSTopBoard.KVSPlayerHead = MP.ReadUShort();
    MP.ReadStringPlus(13, this.KVSTopBoard.KvKAlliTopPlayerName);
    this.KVSTopBoard.KvKAlliTopPlayerValue = MP.ReadULong();
    this.KVSTopBoard.KvKAlliTopPlayerHead = MP.ReadUShort();
    this.KVSTopBoard.KVKTopKingdom = MP.ReadUShort();
    this.KVSTopBoard.KvKTopAlliKingdomID = MP.ReadUShort();
    this.KVSTopBoard.KvKTopAlliAllianceID = MP.ReadUInt();
    MP.ReadStringPlus(3, this.KVSTopBoard.KvKTopAlliTag);
    MP.ReadStringPlus(20, this.KVSTopBoard.KvKTopAlliName);
    this.KVSTopBoard.KvKTopAlliScore = MP.ReadULong();
    this.KVSTopBoard.KvKTopAlliEmblem = MP.ReadUShort();
    MP.ReadStringPlus(3, this.KVSTopBoard.KvKTopPlayerTag);
    MP.ReadStringPlus(13, this.KVSTopBoard.KvKTopPlayerName);
    this.KVSTopBoard.KvKPlayerValue = MP.ReadULong();
    this.KVSTopBoard.KvKTopPlayerKingdomID = MP.ReadUShort();
    this.KVSTopBoard.KvKPlayerHead = MP.ReadUShort();
    this.KVSTopBoard.KingdomEventRequireTime = MP.ReadUInt();
    this.KVSTopBoard.AllianceID = (ulong) DataManager.Instance.RoleAlliance.Id;
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_KingdomVSLBoard, 2);
  }

  public void Recv_MSG_RESP_ACTIVITY_AM_MEMBER_RANK(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    byte num = MP.ReadByte();
    this.ClearMobilizationBoard(UI_LeaderBoardUpdateKind.MobilizationAlliData);
    this.MobiAlliBoardUpdateTime = DataManager.Instance.ServerTime + 180L;
    this.MobiGroupAllianceID = DataManager.Instance.RoleAlliance.Id;
    for (int index = 0; index < (int) num; ++index)
    {
      MobilizationAlliBroudUnit mobilizationAlliBroudUnit = new MobilizationAlliBroudUnit();
      MP.ReadStringPlus(13, mobilizationAlliBroudUnit.Name);
      mobilizationAlliBroudUnit.Score = MP.ReadUShort();
      mobilizationAlliBroudUnit.AquiredMission = MP.ReadByte();
      mobilizationAlliBroudUnit.FinishedMission = MP.ReadByte();
      this.MobiAlliBoard.Add(mobilizationAlliBroudUnit);
    }
    this.MobiAlliBoard.Sort(new Comparison<MobilizationAlliBroudUnit>(LeaderBoardManager.MobiGroupUnitSortByValue));
    for (int index = 0; index < this.MobiAlliBoard.Count; ++index)
    {
      if (DataManager.CompareStr(this.MobiAlliBoard[index].Name, DataManager.Instance.RoleAttr.Name) == 0)
        this.MobiAlliRank = (int) (ushort) (index + 1);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 7);
  }

  public void Recv_MSG_RESP_ACTIVITY_AM_ALLIANCE_RANK(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    byte num1 = MP.ReadByte();
    ushort num2 = MP.ReadUShort();
    byte num3 = MP.ReadByte();
    if (((int) num1 & 1) > 0)
    {
      if ((int) this.MobiGroupAllianceID != (int) DataManager.Instance.RoleAlliance.Id)
        this.ClearMobilizationBoard(UI_LeaderBoardUpdateKind.MobilizationGroupData);
      else if (ActivityManager.Instance.AllyMobilizationData.EventBeginTime != this.AlliMobiEventTime)
        this.ClearMobilizationBoard(UI_LeaderBoardUpdateKind.MobilizationGroupData);
      this.AlliMobiEventTime = ActivityManager.Instance.AllyMobilizationData.EventBeginTime;
      this.MobiGroupBoardUpdateTime = DataManager.Instance.ServerTime + 180L;
      this.MobiGroupAllianceID = DataManager.Instance.RoleAlliance.Id;
    }
    for (int index1 = 0; index1 < (int) num3; ++index1)
    {
      uint num4 = MP.ReadUInt();
      bool flag = false;
      for (int index2 = 0; index2 < this.MobiGroupBoard.Count; ++index2)
      {
        if ((int) this.MobiGroupBoard[index2].AlliacneID == (int) num4)
        {
          this.MobiGroupBoard[index2].AllianceTag.ClearString();
          this.MobiGroupBoard[index2].Name.ClearString();
          MP.ReadStringPlus(3, this.MobiGroupBoard[index2].AllianceTag);
          MP.ReadStringPlus(20, this.MobiGroupBoard[index2].Name);
          this.MobiGroupBoard[index2].Score = MP.ReadUInt();
          flag = true;
          break;
        }
      }
      if (!flag)
      {
        MobilizationGroupBroudUnit mobilizationGroupBroudUnit = new MobilizationGroupBroudUnit();
        mobilizationGroupBroudUnit.AlliacneID = num4;
        MP.ReadStringPlus(3, mobilizationGroupBroudUnit.AllianceTag);
        MP.ReadStringPlus(20, mobilizationGroupBroudUnit.Name);
        mobilizationGroupBroudUnit.Score = MP.ReadUInt();
        this.MobiGroupBoard.Add(mobilizationGroupBroudUnit);
      }
    }
    if (num1 < (byte) 2)
      return;
    this.MobiGroupBoard.Sort(new Comparison<MobilizationGroupBroudUnit>(LeaderBoardManager.MobiGroupUnitSortByValue));
    for (int index = 0; index < this.MobiGroupBoard.Count; ++index)
    {
      if (this.MobiGroupBoard[index].Rank > 0)
        this.MobiGroupBoard[index].ChangeRank = this.MobiGroupBoard[index].Rank - index - 1;
      this.MobiGroupBoard[index].Rank = index + 1;
      if (DataManager.CompareStr(this.MobiGroupBoard[index].AllianceTag, DataManager.Instance.RoleAlliance.Tag) == 0)
      {
        this.MobiGroupRank = (int) (ushort) (index + 1);
        if ((int) this.MobiGroupSaveVer != (int) num2)
          this.MobiGroupLastScore = 0U;
        if ((int) this.MobiGroupLastScore != (int) this.MobiGroupBoard[index].Score)
        {
          UILeaderBoard.ShowSP = true;
          UILeaderBoard.SPScoreValue = (int) this.MobiGroupLastScore;
          UILeaderBoard.SPScoreFlyValue = (int) this.MobiGroupBoard[index].Score - (int) this.MobiGroupLastScore;
          UILeaderBoard.SPRankChange = this.MobiGroupBoard[this.MobiGroupRank - 1].ChangeRank;
          this.MobiGroupLastScore = this.MobiGroupBoard[index].Score;
          this.MobiGroupSaveVer = num2;
          PlayerPrefs.SetString("AllianceMobilizationVer_" + (object) DataManager.Instance.RoleAttr.UserId, this.MobiGroupSaveVer.ToString());
          PlayerPrefs.SetString("AllianceMobilizationScore_" + (object) DataManager.Instance.RoleAttr.UserId, this.MobiGroupLastScore.ToString());
        }
      }
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 6);
  }

  public void Recv_MSG_RESP_KINGOFTHEWORLD_HISTORYKINGDATA(MessagePacket MP)
  {
    this.MobiWorldKingBoard.Clear();
    this.KingHead = MP.ReadUShort();
    this.HistoryKingDataNum = MP.ReadByte();
    for (int index = 0; index < (int) this.HistoryKingDataNum; ++index)
    {
      HistoryWorldKingDataType worldKingDataType = new HistoryWorldKingDataType();
      worldKingDataType.HomeKingdomID = MP.ReadUShort();
      MP.ReadStringPlus(3, worldKingDataType.AllianceTag);
      MP.ReadStringPlus(13, worldKingDataType.Name);
      worldKingDataType.OccupyTime = MP.ReadUInt();
      worldKingDataType.TakeOfficeTime = MP.ReadLong();
      this.MobiWorldKingBoard.Add(worldKingDataType);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 9);
  }

  public void Send_MSG_REQUEST_KINGOFTHEWORLD_HISTORYKINGDATA()
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_KINGOFTHEWORLD_HISTORYKINGDATA;
    messagePacket.AddSeqId();
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_WORLDRANKING_LEADERBOARDS_CLIENT(MessagePacket MP)
  {
    this.WorldLeaderBoardTopBoard.SortTime = MP.ReadLong();
    MP.ReadStringPlus(3, this.WorldLeaderBoardTopBoard.PowerTop.AlliaceTag);
    MP.ReadStringPlus(13, this.WorldLeaderBoardTopBoard.PowerTop.Name);
    this.WorldLeaderBoardTopBoard.PowerTop.Value = MP.ReadULong();
    this.WorldLeaderBoardTopBoard.PowerTop.KingdomID = MP.ReadUShort();
    this.WorldLeaderBoardTopBoard.PowerTopHead = MP.ReadUShort();
    MP.ReadStringPlus(3, this.WorldLeaderBoardTopBoard.KillsTop.AlliaceTag);
    MP.ReadStringPlus(13, this.WorldLeaderBoardTopBoard.KillsTop.Name);
    this.WorldLeaderBoardTopBoard.KillsTop.Value = MP.ReadULong();
    this.WorldLeaderBoardTopBoard.KillsTop.KingdomID = MP.ReadUShort();
    this.WorldLeaderBoardTopBoard.KillsTopHead = MP.ReadUShort();
    MP.ReadStringPlus(3, this.WorldLeaderBoardTopBoard.AlliPowerTop.AlliaceTag);
    MP.ReadStringPlus(20, this.WorldLeaderBoardTopBoard.AlliPowerTop.Name);
    this.WorldLeaderBoardTopBoard.AlliPowerTop.Value = MP.ReadULong();
    int num1 = (int) MP.ReadUInt();
    this.WorldLeaderBoardTopBoard.AlliPowerTop.KingdomID = MP.ReadUShort();
    this.WorldLeaderBoardTopBoard.PowerTopEmblem = MP.ReadUShort();
    MP.ReadStringPlus(3, this.WorldLeaderBoardTopBoard.AlliKillsTop.AlliaceTag);
    MP.ReadStringPlus(20, this.WorldLeaderBoardTopBoard.AlliKillsTop.Name);
    this.WorldLeaderBoardTopBoard.AlliKillsTop.Value = MP.ReadULong();
    int num2 = (int) MP.ReadUInt();
    this.WorldLeaderBoardTopBoard.AlliKillsTop.KingdomID = MP.ReadUShort();
    this.WorldLeaderBoardTopBoard.KillsTopEmblem = MP.ReadUShort();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 2);
  }

  public void Send_MSG_REQUEST_FEDERAL_HISTORYKINGDATA(byte WonderID)
  {
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_FEDERAL_HISTORYKINGDATA;
    messagePacket.AddSeqId();
    messagePacket.Add(WonderID);
    messagePacket.Send();
  }

  public void Recv_MSG_RESP_FEDERAL_HISTORYKINGDATA(MessagePacket MP)
  {
    this.MobiWorldKingBoard.Clear();
    if (MP.ReadByte() == (byte) 0)
    {
      MP.ReadByte();
      this.KingHead = MP.ReadUShort();
      this.HistoryKingDataNum = MP.ReadByte();
      for (int index = 0; index < (int) this.HistoryKingDataNum; ++index)
      {
        HistoryWorldKingDataType worldKingDataType = new HistoryWorldKingDataType();
        worldKingDataType.HomeKingdomID = MP.ReadUShort();
        MP.ReadStringPlus(3, worldKingDataType.AllianceTag);
        MP.ReadStringPlus(13, worldKingDataType.Name);
        worldKingDataType.OccupyTime = MP.ReadUInt();
        worldKingDataType.TakeOfficeTime = MP.ReadLong();
        this.MobiWorldKingBoard.Add(worldKingDataType);
      }
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_NobilityBoard, 0);
    }
    else
      GUIManager.Instance.UpdateUI(EGUIWindow.UI_NobilityBoard, 0, 2);
  }

  public void Recv_MSG_RESP_KINGOFTHEWORLD_RANKDATA(MessagePacket MP)
  {
    this.KingofWorldTime = DataManager.Instance.ServerTime + 21600L;
    this.KingofWorldHead = MP.ReadUShort();
    this.KingofWorldBoard.Clear();
    for (int index = 0; index < 10; ++index)
    {
      KingofWorldBoardUnit kingofWorldBoardUnit = new KingofWorldBoardUnit();
      kingofWorldBoardUnit.HomeKingdomID = MP.ReadUShort();
      MP.ReadStringPlus(3, kingofWorldBoardUnit.AllianceTag);
      MP.ReadStringPlus(13, kingofWorldBoardUnit.Name);
      kingofWorldBoardUnit.OccupyTime = MP.ReadUInt();
      this.KingofWorldBoard.Add(kingofWorldBoardUnit);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_LeaderBoard, 10);
  }

  public void Recv_MSG_RESP_Nobile_RANKDATA(MessagePacket MP)
  {
    this.NobileWonderId = (ushort) MP.ReadByte();
    this.NobileTime = DataManager.Instance.ServerTime + 21600L;
    this.NobileHead = MP.ReadUShort();
    this.NobileBoard.Clear();
    for (int index = 0; index < 10; ++index)
    {
      KingofWorldBoardUnit kingofWorldBoardUnit = new KingofWorldBoardUnit();
      kingofWorldBoardUnit.HomeKingdomID = MP.ReadUShort();
      MP.ReadStringPlus(3, kingofWorldBoardUnit.AllianceTag);
      MP.ReadStringPlus(13, kingofWorldBoardUnit.Name);
      kingofWorldBoardUnit.OccupyTime = MP.ReadUInt();
      this.NobileBoard.Add(kingofWorldBoardUnit);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_NobilityOccupyBoard, (int) this.NobileWonderId);
  }

  public void Recv_MSG_RESP_AlliHunt_RANKDATA(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    byte num1 = MP.ReadByte();
    byte num2 = MP.ReadByte();
    if (this.AlliHuntBoard == null)
      this.AlliHuntBoard = new List<BoardUnit>();
    if (((int) num1 & 1) > 0)
    {
      this.AlliHuntBoard.Clear();
      this.AlliHuntBoardUpdateTime = DataManager.Instance.ServerTime + 180L;
      this.MobiGroupAllianceID = DataManager.Instance.RoleAlliance.Id;
    }
    for (int index = 0; index < (int) num2; ++index)
    {
      BoardUnit boardUnit = new BoardUnit();
      MP.ReadStringPlus(13, boardUnit.Name);
      boardUnit.Value = MP.ReadULong();
      this.AlliHuntBoard.Add(boardUnit);
    }
    if (num1 < (byte) 2)
      return;
    this.AlliHuntBoard.Sort(new Comparison<BoardUnit>(LeaderBoardManager.BoardUnitSortByValue));
    for (int index = 0; index < this.AlliHuntBoard.Count; ++index)
    {
      if (DataManager.CompareStr(this.AlliHuntBoard[index].Name, DataManager.Instance.RoleAttr.Name) == 0)
        this.AlliHuntRank = index + 1;
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_AlliHuntBoard, 11);
  }

  public void Recv_MSG_RESP_ALLIANCEWAR_RANK(MessagePacket MP)
  {
    if (MP.ReadByte() != (byte) 0)
      return;
    if (this.AllianceWarGroupBoard == null)
      this.AllianceWarGroupBoard = new List<AllianceWarBroudUnit>();
    this.AllianceWarGroupBoard.Clear();
    this.AllianceWarGroupRank = 0;
    this.AllianceWarGroupBoardUpdateTime = DataManager.Instance.ServerTime + 180L;
    this.MobiGroupAllianceID = DataManager.Instance.RoleAlliance.Id;
    this.AllianceWarGroupRankUpNum = MP.ReadByte();
    this.AllianceWarGroupRankDownNum = MP.ReadByte();
    this.AllianceWarGroupRankDownNum = (byte) (16 - (int) this.AllianceWarGroupRankDownNum + 1);
    for (int index = 0; index < 16; ++index)
    {
      uint num = MP.ReadUInt();
      AllianceWarBroudUnit allianceWarBroudUnit = new AllianceWarBroudUnit();
      allianceWarBroudUnit.AlliacneID = num;
      MP.ReadStringPlus(3, allianceWarBroudUnit.AllianceTag);
      MP.ReadStringPlus(20, allianceWarBroudUnit.Name);
      allianceWarBroudUnit.Score = (int) MP.ReadUShort();
      allianceWarBroudUnit.Power = MP.ReadULong();
      if (num != 0U)
      {
        this.AllianceWarGroupBoard.Add(allianceWarBroudUnit);
        if ((int) allianceWarBroudUnit.AlliacneID == (int) DataManager.Instance.RoleAlliance.Id)
          this.AllianceWarGroupRank = this.AllianceWarGroupBoard.Count;
      }
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_AlliVSGroupBoard, 0);
  }

  public static LeaderBoardManager Instance
  {
    get
    {
      if (LeaderBoardManager._instance == null)
        LeaderBoardManager._instance = new LeaderBoardManager();
      return LeaderBoardManager._instance;
    }
  }

  public void CheckNextPart(byte BoardID, byte Index)
  {
    if (BoardID == (byte) 7)
      return;
    byte data = (byte) ((uint) Index / 20U);
    if (data >= (byte) 5 || (int) data <= (int) this.BoardRecived[(int) BoardID])
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_LEADERBOARD_CONTENT;
    messagePacket.AddSeqId();
    ushort zoneID;
    byte pointID;
    GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out zoneID, out pointID);
    messagePacket.Add(zoneID);
    messagePacket.Add(pointID);
    messagePacket.Add(BoardID);
    messagePacket.Add(data);
    if (GameConstants.IsBetween((int) BoardID, 5, 7))
      messagePacket.Add(LeaderBoardManager.Instance.KvKTopBoard.SortTime);
    else
      messagePacket.Add(LeaderBoardManager.Instance.BoardUpdateTime[(int) BoardID]);
    messagePacket.Send();
  }

  public static int isOpenArena()
  {
    switch (ActivityManager.Instance.KvKActivityData[4].EventState)
    {
      case EActivityState.EAS_Run:
      case EActivityState.EAS_HomeStart:
      case EActivityState.EAS_HomeEnd:
      case EActivityState.EAS_StartRanking:
        return 1;
      default:
        if (ArenaManager.Instance.m_ArenaClose_ActivityType == EActivityType.EAT_KingOfTheWorld && ArenaManager.Instance.m_ArenaClose_CDTime > DataManager.Instance.ServerTime)
          return 2;
        return ArenaManager.Instance.m_ArenaClose_ActivityType == EActivityType.EAT_FederalEvent && ArenaManager.Instance.m_ArenaClose_CDTime > DataManager.Instance.ServerTime ? 3 : 0;
    }
  }

  private static int BoardUnitSortByValue(BoardUnit x, BoardUnit y)
  {
    if (x.Value > y.Value)
      return -1;
    return x.Value < y.Value ? 1 : 0;
  }

  private static int MobiGroupUnitSortByValue(
    MobilizationGroupBroudUnit x,
    MobilizationGroupBroudUnit y)
  {
    if (x.Score > y.Score)
      return -1;
    return x.Score < y.Score ? 1 : DataManager.CompareStr(x.AllianceTag, y.AllianceTag);
  }

  private static int MobiGroupUnitSortByValue(
    MobilizationAlliBroudUnit x,
    MobilizationAlliBroudUnit y)
  {
    if ((int) x.Score > (int) y.Score)
      return -1;
    if ((int) x.Score < (int) y.Score)
      return 1;
    if ((int) x.FinishedMission > (int) y.FinishedMission)
      return -1;
    return (int) x.FinishedMission < (int) y.FinishedMission ? 1 : DataManager.CompareStr(x.Name, y.Name);
  }
}
