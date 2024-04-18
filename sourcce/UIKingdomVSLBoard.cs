// Decompiled with JetBrains decompiler
// Type: UIKingdomVSLBoard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIKingdomVSLBoard : UILeaderBoardBase
{
  public static byte SubBoardID;
  public static bool isTopBoard = true;
  public static bool isPersonBoard = true;
  public static bool NewOpen;
  public static bool WorldBoard;
  private RectTransform KingdomImg;

  public override void OnOpen(int arg1, int arg2)
  {
    base.OnOpen(arg1, arg2);
    if (UIKingdomVSLBoard.NewOpen)
    {
      UIKingdomVSLBoard.isTopBoard = true;
      UIKingdomVSLBoard.isPersonBoard = true;
      UIKingdomVSLBoard.NewOpen = false;
      UIKingdomVSLBoard.WorldBoard = false;
    }
    if ((long) LeaderBoardManager.Instance.KVSTopBoard.AllianceID != (long) DataManager.Instance.RoleAlliance.Id)
    {
      LeaderBoardManager.Instance.KingdomBoardNextTime = 0L;
      LeaderBoardManager.Instance.BoardUpdateTime[7] = 0L;
    }
    if (LeaderBoardManager.Instance.KingdomBoardNextTime < DataManager.Instance.ServerTime)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_KVK_TOPBOARD;
      messagePacket.AddSeqId();
      ushort zoneID;
      byte pointID;
      GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out zoneID, out pointID);
      messagePacket.Add(zoneID);
      messagePacket.Add(pointID);
      messagePacket.Send();
      UIKingdomVSLBoard.isTopBoard = true;
      this.DataReady = false;
    }
    else
      this.DataReady = true;
    this.KingdomImg = this.AGS_Form.GetChild(6).GetChild(2).GetComponent<RectTransform>();
    ((Component) this.KingdomImg).gameObject.SetActive(false);
  }

  public void CreateTopBoard()
  {
    this.SPHeight.Clear();
    this.SPHeight.Add(118f);
    this.SPHeight.Add(118f);
    this.SPHeight.Add(118f);
    this.AGS_Form.GetChild(3).gameObject.SetActive(false);
    GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0);
    this.AGS_Form.GetChild(12).gameObject.SetActive(true);
    this.AGS_Form.GetChild(12).GetComponent<UISpritesArray>().SetSpriteIndex(0);
    UIKingdomVSLBoard.isTopBoard = true;
    if (!UIKingdomVSLBoard.WorldBoard)
    {
      this.AGS_Form.GetChild(12).GetComponent<UISpritesArray>().SetSpriteIndex(0);
      this.SPHeight.Add(118f);
      this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9585U);
      this.AGS_Form.GetChild(2).gameObject.SetActive(true);
      this.AGS_Form.GetChild(5).gameObject.SetActive(true);
      UIText component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
      CString cstring1 = StringManager.Instance.StaticString1024();
      CString cstring2 = StringManager.Instance.StaticString1024();
      cstring1.ClearString();
      cstring1.Append(GameConstants.GetDateTime(LeaderBoardManager.Instance.KVSTopBoard.SortTime).ToString("MM/dd/yy HH:mm"));
      cstring2.ClearString();
      cstring2.Append(GameConstants.GetDateTime(LeaderBoardManager.Instance.KVSTopBoard.SortTime + (long) LeaderBoardManager.Instance.KVSTopBoard.KingdomEventRequireTime).ToString("MM/dd/yy HH:mm"));
      this.Ranking.ClearString();
      this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8153U));
      this.Ranking.Append(" ");
      this.Ranking.Append(cstring1);
      this.Ranking.Append(" ~ ");
      this.Ranking.Append(cstring2);
      component.text = this.Ranking.ToString();
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.AGS_Form.GetChild(12).GetComponent<UISpritesArray>().SetSpriteIndex(1);
      this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9566U);
      this.AGS_Form.GetChild(2).gameObject.SetActive(true);
      this.AGS_Form.GetChild(5).gameObject.SetActive(true);
      UIText component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
      CString cstring3 = StringManager.Instance.StaticString1024();
      CString cstring4 = StringManager.Instance.StaticString1024();
      cstring3.ClearString();
      cstring3.Append(GameConstants.GetDateTime(LeaderBoardManager.Instance.KVSTopBoard.SortTime).ToString("MM/dd/yy HH:mm"));
      cstring4.ClearString();
      cstring4.Append(GameConstants.GetDateTime(LeaderBoardManager.Instance.KVSTopBoard.SortTime + (long) LeaderBoardManager.Instance.KVSTopBoard.KingdomEventRequireTime).ToString("MM/dd/yy HH:mm"));
      this.Ranking.ClearString();
      this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8153U));
      this.Ranking.Append(" ");
      this.Ranking.Append(cstring3);
      this.Ranking.Append(" ~ ");
      this.Ranking.Append(cstring4);
      component.text = this.Ranking.ToString();
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
    }
  }

  public void CreateSubBoard()
  {
    this.AGS_Form.GetChild(5).gameObject.SetActive(false);
    this.AGS_Form.GetChild(12).gameObject.SetActive(false);
    this.SPHeight.Clear();
    this.SPHeight.Add(38f);
    switch (UIKingdomVSLBoard.SubBoardID)
    {
      case 5:
      case 12:
        for (int index = 0; index < LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID].Count; ++index)
        {
          if (((BoardUnitKingdom) LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][index]).KingdomID > (ushort) 0)
            this.SPHeight.Add(53f);
        }
        break;
      case 6:
      case 13:
      case 14:
      case 15:
        for (int index = 0; index < LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID].Count; ++index)
        {
          if (LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][index].Value > 0UL)
            this.SPHeight.Add(53f);
        }
        break;
      case 7:
        for (int index = 0; index < LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID].Count; ++index)
          this.SPHeight.Add(53f);
        break;
    }
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
    switch (UIKingdomVSLBoard.SubBoardID)
    {
      case 5:
        component1.text = DataManager.Instance.mStringTable.GetStringByID(9588U);
        break;
      case 6:
        component1.text = DataManager.Instance.mStringTable.GetStringByID(9589U);
        break;
      case 7:
        component1.text = DataManager.Instance.mStringTable.GetStringByID(9855U);
        break;
      case 12:
        component1.text = DataManager.Instance.mStringTable.GetStringByID(9587U);
        break;
      case 13:
        component1.text = DataManager.Instance.mStringTable.GetStringByID(9854U);
        break;
      case 14:
        component1.text = DataManager.Instance.mStringTable.GetStringByID(9586U);
        break;
      case 15:
        component1.text = DataManager.Instance.mStringTable.GetStringByID(9590U);
        break;
    }
    this.AGS_Form.GetChild(3).gameObject.SetActive(true);
    if (UIKingdomVSLBoard.isPersonBoard)
    {
      this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
      this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
      Transform child = this.AGS_Form.GetChild(3).GetChild(0);
      child.gameObject.SetActive(true);
      GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, (byte) 11, (byte) 0);
    }
    else
    {
      this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(false);
      this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(true);
      GUIManager.Instance.SetBadgeTotemImg(this.AGS_Form.GetChild(3).GetChild(1), DataManager.Instance.RoleAlliance.Emblem);
    }
    if ((UIKingdomVSLBoard.SubBoardID == (byte) 5 || UIKingdomVSLBoard.SubBoardID == (byte) 12) && LeaderBoardManager.Instance.MyRank[(int) UIKingdomVSLBoard.SubBoardID] != (ushort) 0)
    {
      this.AGS_Form.GetChild(3).gameObject.SetActive(false);
      this.AGS_Form.GetChild(5).gameObject.SetActive(true);
      this.AGS_Form.GetChild(2).gameObject.SetActive(true);
      UIText component2 = this.AGS_Form.GetChild(5).GetComponent<UIText>();
      this.Ranking.ClearString();
      this.Ranking.IntToFormat((long) LeaderBoardManager.Instance.MyRank[(int) UIKingdomVSLBoard.SubBoardID], bNumber: true);
      this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9849U));
      component2.text = this.Ranking.ToString();
      component2.SetAllDirty();
      component2.cachedTextGenerator.Invalidate();
    }
    if (UIKingdomVSLBoard.SubBoardID == (byte) 7)
    {
      this.Ranking.ClearString();
      UIText component3;
      if (LeaderBoardManager.Instance.MyRank[(int) UIKingdomVSLBoard.SubBoardID] != (ushort) 0)
      {
        component3 = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
        this.Ranking.IntToFormat((long) LeaderBoardManager.Instance.MyRank[(int) UIKingdomVSLBoard.SubBoardID], bNumber: true);
        this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7060U));
      }
      else
      {
        this.AGS_Form.GetChild(3).gameObject.SetActive(false);
        this.AGS_Form.GetChild(5).gameObject.SetActive(true);
        component3 = this.AGS_Form.GetChild(5).GetComponent<UIText>();
        this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8414U));
      }
      component3.text = this.Ranking.ToString();
      component3.SetAllDirty();
      component3.cachedTextGenerator.Invalidate();
    }
    else if (UIKingdomVSLBoard.isPersonBoard)
    {
      this.Ranking.ClearString();
      UIText component4;
      if (LeaderBoardManager.Instance.MyRank[(int) UIKingdomVSLBoard.SubBoardID] != (ushort) 0)
      {
        component4 = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
        this.Ranking.IntToFormat((long) LeaderBoardManager.Instance.MyRank[(int) UIKingdomVSLBoard.SubBoardID], bNumber: true);
        this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7060U));
      }
      else
      {
        this.AGS_Form.GetChild(3).gameObject.SetActive(false);
        this.AGS_Form.GetChild(5).gameObject.SetActive(true);
        component4 = this.AGS_Form.GetChild(5).GetComponent<UIText>();
        this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8414U));
      }
      component4.text = this.Ranking.ToString();
      component4.SetAllDirty();
      component4.cachedTextGenerator.Invalidate();
    }
    else if (DataManager.Instance.RoleAlliance.Id != 0U)
    {
      this.AGS_Form.GetChild(3).gameObject.SetActive(false);
      this.AGS_Form.GetChild(5).gameObject.SetActive(true);
      UIText component5 = this.AGS_Form.GetChild(5).GetComponent<UIText>();
      this.Ranking.ClearString();
      if (LeaderBoardManager.Instance.MyRank[(int) UIKingdomVSLBoard.SubBoardID] != (ushort) 0)
      {
        this.Ranking.IntToFormat((long) LeaderBoardManager.Instance.MyRank[(int) UIKingdomVSLBoard.SubBoardID]);
        this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9856U));
      }
      else
        this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8414U));
      component5.text = this.Ranking.ToString();
      component5.SetAllDirty();
      component5.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.AGS_Form.GetChild(3).gameObject.SetActive(false);
      this.AGS_Form.GetChild(5).gameObject.SetActive(true);
      this.AGS_Form.GetChild(5).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7095U);
    }
    if (UIKingdomVSLBoard.SubBoardID == (byte) 7 && LeaderBoardManager.Instance.MyRank[(int) UIKingdomVSLBoard.SubBoardID] != (ushort) 0 && (int) LeaderBoardManager.Instance.MyRank[(int) UIKingdomVSLBoard.SubBoardID] <= LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID].Count)
    {
      UIText component6 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
      this.RankValue.ClearString();
      this.RankValue.uLongToFormat(LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][(int) LeaderBoardManager.Instance.MyRank[(int) UIKingdomVSLBoard.SubBoardID] - 1].Value, bNumber: true);
      this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8121U));
      component6.text = this.RankValue.ToString();
      component6.SetAllDirty();
      component6.cachedTextGenerator.Invalidate();
    }
    else
    {
      UIText component7 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
      component7.text = string.Empty;
      component7.SetAllDirty();
      component7.cachedTextGenerator.Invalidate();
    }
  }

  private void MainBoardChange()
  {
    if (LeaderBoardManager.Instance.KingdomBoardNextTime < DataManager.Instance.ServerTime || (long) LeaderBoardManager.Instance.KVSTopBoard.AllianceID != (long) DataManager.Instance.RoleAlliance.Id)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_KVK_TOPBOARD;
      messagePacket.AddSeqId();
      ushort zoneID;
      byte pointID;
      GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out zoneID, out pointID);
      messagePacket.Add(zoneID);
      messagePacket.Add(pointID);
      messagePacket.Send();
      UIKingdomVSLBoard.isTopBoard = true;
    }
    else
    {
      this.CreateTopBoard();
      this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardTypes);
      this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false);
      this.AGS_Panel1.GoTo(0);
    }
  }

  private void SubBoardChange(byte newSubID)
  {
    UIKingdomVSLBoard.SubBoardID = newSubID;
    UIKingdomVSLBoard.isTopBoard = false;
    if (UIKingdomVSLBoard.SubBoardID == (byte) 7 && LeaderBoardManager.Instance.BoardUpdateTime[(int) UIKingdomVSLBoard.SubBoardID] < DataManager.Instance.ServerTime)
    {
      UILeaderBoardBase.TopIndex[(int) UIKingdomVSLBoard.SubBoardID] = 0;
      LeaderBoardManager.Instance.ClearBoard(7);
      LeaderBoardManager.Instance.MyRank[(int) UIKingdomVSLBoard.SubBoardID] = (ushort) 0;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.AddSeqId();
      messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AEVENT_PERSONAL_RANK;
      messagePacket.Send();
    }
    else if (UIKingdomVSLBoard.SubBoardID >= (byte) 5 && LeaderBoardManager.Instance.BoardUpdateTime[(int) UIKingdomVSLBoard.SubBoardID] < DataManager.Instance.ServerTime)
    {
      UILeaderBoardBase.TopIndex[(int) UIKingdomVSLBoard.SubBoardID] = 0;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.AddSeqId();
      messagePacket.Protocol = Protocol._MSG_REQUEST_LEADERBOARD_CONTENT;
      ushort zoneID;
      byte pointID;
      GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out zoneID, out pointID);
      messagePacket.Add(zoneID);
      messagePacket.Add(pointID);
      messagePacket.Add(UIKingdomVSLBoard.SubBoardID);
      byte data = 0;
      messagePacket.Add(data);
      messagePacket.Add(LeaderBoardManager.Instance.KVSTopBoard.SortTime);
      if (UIKingdomVSLBoard.SubBoardID == (byte) 6 || UIKingdomVSLBoard.SubBoardID == (byte) 13)
        messagePacket.Add(DataManager.Instance.RoleAlliance.Id);
      messagePacket.Send();
    }
    else
    {
      this.CreateSubBoard();
      this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
      this.AGS_Panel2.AddNewDataHeight(this.SPHeight);
      this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[(int) UIKingdomVSLBoard.SubBoardID]);
    }
  }

  public void UpdateRow_FunctionList(GameObject item, int dataIdx, int panelObjectIdx)
  {
    if (!UIKingdomVSLBoard.WorldBoard)
    {
      switch (dataIdx)
      {
        case 0:
          item.transform.GetChild(2).gameObject.SetActive(false);
          item.transform.GetChild(3).gameObject.SetActive(false);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9587U);
          CString str1 = StringManager.Instance.StaticString1024();
          str1.ClearString();
          DataManager.MapDataController.GetKingdomName(LeaderBoardManager.Instance.KVSTopBoard.KVSTopKingdom, ref str1);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.KVSTopBoard.KVSTopKingdom == (ushort) 0)
          {
            this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475U));
          }
          else
          {
            this.SortTextArray[1, panelObjectIdx].IntToFormat((long) LeaderBoardManager.Instance.KVSTopBoard.KVSTopKingdom);
            this.SortTextArray[1, panelObjectIdx].StringToFormat(str1);
            this.SortTextArray[1, panelObjectIdx].AppendFormat("#{0} {1}");
          }
          UIText component1 = item.transform.GetChild(5).GetComponent<UIText>();
          component1.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component1.SetAllDirty();
          component1.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          UIText component2 = item.transform.GetChild(6).GetComponent<UIText>();
          component2.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component2.SetAllDirty();
          component2.cachedTextGenerator.Invalidate();
          UIButton component3 = item.transform.GetChild(1).GetComponent<UIButton>();
          component3.m_Handler = (IUIButtonClickHandler) this;
          component3.m_BtnID1 = 3;
          component3.m_BtnID2 = 12;
          ((Transform) this.KingdomImg).SetParent(item.transform, false);
          ((Component) this.KingdomImg).gameObject.SetActive(true);
          this.KingdomImg.anchoredPosition = new Vector2(-323f, -20f);
          break;
        case 1:
          item.transform.GetChild(2).gameObject.SetActive(LeaderBoardManager.Instance.KVSTopBoard.KVSTopAlliEmblem != (ushort) 0);
          item.transform.GetChild(3).gameObject.SetActive(false);
          if (item.transform.GetChild(2).GetChild(0).childCount < 1)
            GUIManager.Instance.InitBadgeTotem(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.KVSTopBoard.KVSTopAlliEmblem);
          else
            GUIManager.Instance.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.KVSTopBoard.KVSTopAlliEmblem);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9854U);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.KVSTopBoard.KVSTopAlliScore == 0UL)
            this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8477U));
          else
            GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.KVSTopBoard.KVSTopAlliKingdomID, LeaderBoardManager.Instance.KVSTopBoard.KVSTopAlliName, LeaderBoardManager.Instance.KVSTopBoard.KVSTopAlliTag);
          UIText component4 = item.transform.GetChild(5).GetComponent<UIText>();
          component4.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component4.SetAllDirty();
          component4.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.KVSTopBoard.KVSTopAlliScore, bNumber: true);
          this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
          UIText component5 = item.transform.GetChild(6).GetComponent<UIText>();
          component5.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component5.SetAllDirty();
          component5.cachedTextGenerator.Invalidate();
          UIButton component6 = item.transform.GetChild(1).GetComponent<UIButton>();
          component6.m_Handler = (IUIButtonClickHandler) this;
          component6.m_BtnID1 = 3;
          component6.m_BtnID2 = 13;
          break;
        case 2:
          item.transform.GetChild(2).gameObject.SetActive(false);
          item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.KVSTopBoard.KVSPlayerValue != 0UL);
          if (item.transform.GetChild(3).childCount < 1)
            GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.KVSTopBoard.KVSPlayerHead, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
          else
            GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.KVSTopBoard.KVSPlayerHead, (byte) 11, (byte) 0);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9586U);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.KVSTopBoard.KVSPlayerValue == 0UL)
            this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475U));
          else
            GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.KVSTopBoard.KVSTopPlayerKingdomID, LeaderBoardManager.Instance.KVSTopBoard.KVSTopPlayerName, LeaderBoardManager.Instance.KVSTopBoard.KVSTopPlayerTag);
          UIText component7 = item.transform.GetChild(5).GetComponent<UIText>();
          component7.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component7.SetAllDirty();
          component7.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.KVSTopBoard.KVSPlayerValue > 0UL)
          {
            this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.KVSTopBoard.KVSPlayerValue, bNumber: true);
            this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
          }
          UIText component8 = item.transform.GetChild(6).GetComponent<UIText>();
          component8.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component8.SetAllDirty();
          component8.cachedTextGenerator.Invalidate();
          UIButton component9 = item.transform.GetChild(1).GetComponent<UIButton>();
          component9.m_Handler = (IUIButtonClickHandler) this;
          component9.m_BtnID1 = 3;
          component9.m_BtnID2 = 14;
          break;
        case 3:
          item.transform.GetChild(2).gameObject.SetActive(false);
          item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.KVSTopBoard.KvKAlliTopPlayerName.Length > 0 && DataManager.Instance.RoleAlliance.Id != 0U);
          if (item.transform.GetChild(3).childCount < 1)
            GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.KVSTopBoard.KvKAlliTopPlayerHead, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
          else
            GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.KVSTopBoard.KvKAlliTopPlayerHead, (byte) 11, (byte) 0);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9855U);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          if (DataManager.Instance.RoleAlliance.Id == 0U || LeaderBoardManager.Instance.KVSTopBoard.KvKAlliTopPlayerName.Length == 0)
            this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475U));
          else
            GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], (ushort) 0, LeaderBoardManager.Instance.KVSTopBoard.KvKAlliTopPlayerName, DataManager.Instance.RoleAlliance.Tag);
          UIText component10 = item.transform.GetChild(5).GetComponent<UIText>();
          component10.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component10.SetAllDirty();
          component10.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          if (DataManager.Instance.RoleAlliance.Id > 0U && LeaderBoardManager.Instance.KVSTopBoard.KvKAlliTopPlayerName.Length > 0)
          {
            this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.KVSTopBoard.KvKAlliTopPlayerValue, bNumber: true);
            this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
          }
          UIText component11 = item.transform.GetChild(6).GetComponent<UIText>();
          component11.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component11.SetAllDirty();
          component11.cachedTextGenerator.Invalidate();
          UIButton component12 = item.transform.GetChild(1).GetComponent<UIButton>();
          component12.m_Handler = (IUIButtonClickHandler) this;
          component12.m_BtnID1 = 3;
          component12.m_BtnID2 = 7;
          break;
      }
    }
    else
    {
      switch (dataIdx)
      {
        case 0:
          item.transform.GetChild(2).gameObject.SetActive(false);
          item.transform.GetChild(3).gameObject.SetActive(false);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9588U);
          CString str2 = StringManager.Instance.StaticString1024();
          str2.ClearString();
          DataManager.MapDataController.GetKingdomName(LeaderBoardManager.Instance.KVSTopBoard.KVKTopKingdom, ref str2);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          this.SortTextArray[1, panelObjectIdx].IntToFormat((long) LeaderBoardManager.Instance.KVSTopBoard.KVKTopKingdom);
          this.SortTextArray[1, panelObjectIdx].StringToFormat(str2);
          this.SortTextArray[1, panelObjectIdx].AppendFormat("#{0} {1}");
          UIText component13 = item.transform.GetChild(5).GetComponent<UIText>();
          component13.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component13.SetAllDirty();
          component13.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          UIText component14 = item.transform.GetChild(6).GetComponent<UIText>();
          component14.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component14.SetAllDirty();
          component14.cachedTextGenerator.Invalidate();
          UIButton component15 = item.transform.GetChild(1).GetComponent<UIButton>();
          component15.m_Handler = (IUIButtonClickHandler) this;
          component15.m_BtnID1 = 3;
          component15.m_BtnID2 = 5;
          ((Transform) this.KingdomImg).SetParent(item.transform, false);
          ((Component) this.KingdomImg).gameObject.SetActive(true);
          this.KingdomImg.anchoredPosition = new Vector2(-323f, -20f);
          break;
        case 1:
          item.transform.GetChild(2).gameObject.SetActive(LeaderBoardManager.Instance.KVSTopBoard.KvKTopAlliEmblem != (ushort) 0);
          item.transform.GetChild(3).gameObject.SetActive(false);
          if (item.transform.GetChild(2).GetChild(0).childCount < 1)
            GUIManager.Instance.InitBadgeTotem(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.KVSTopBoard.KvKTopAlliEmblem);
          else
            GUIManager.Instance.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.KVSTopBoard.KvKTopAlliEmblem);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9589U);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.KVSTopBoard.KvKTopAlliScore == 0UL)
            this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8477U));
          else
            GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.KVSTopBoard.KvKTopAlliKingdomID, LeaderBoardManager.Instance.KVSTopBoard.KvKTopAlliName, LeaderBoardManager.Instance.KVSTopBoard.KvKTopAlliTag);
          UIText component16 = item.transform.GetChild(5).GetComponent<UIText>();
          component16.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component16.SetAllDirty();
          component16.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.KVSTopBoard.KvKTopAlliScore > 0UL)
          {
            this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.KVSTopBoard.KvKTopAlliScore, bNumber: true);
            this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
          }
          UIText component17 = item.transform.GetChild(6).GetComponent<UIText>();
          component17.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component17.SetAllDirty();
          component17.cachedTextGenerator.Invalidate();
          UIButton component18 = item.transform.GetChild(1).GetComponent<UIButton>();
          component18.m_Handler = (IUIButtonClickHandler) this;
          component18.m_BtnID1 = 3;
          component18.m_BtnID2 = 6;
          break;
        case 2:
          item.transform.GetChild(2).gameObject.SetActive(false);
          item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.KVSTopBoard.KvKPlayerValue != 0UL);
          if (item.transform.GetChild(3).childCount < 1)
            GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.KVSTopBoard.KvKPlayerHead, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
          else
            GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.KVSTopBoard.KvKPlayerHead, (byte) 11, (byte) 0);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9590U);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.KVSTopBoard.KvKPlayerValue == 0UL)
            this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475U));
          else
            GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.KVSTopBoard.KvKTopPlayerKingdomID, LeaderBoardManager.Instance.KVSTopBoard.KvKTopPlayerName, LeaderBoardManager.Instance.KVSTopBoard.KvKTopPlayerTag);
          UIText component19 = item.transform.GetChild(5).GetComponent<UIText>();
          component19.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component19.SetAllDirty();
          component19.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.KVSTopBoard.KvKPlayerValue > 0UL)
          {
            this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.KVSTopBoard.KvKPlayerValue, bNumber: true);
            this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
          }
          UIText component20 = item.transform.GetChild(6).GetComponent<UIText>();
          component20.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component20.SetAllDirty();
          component20.cachedTextGenerator.Invalidate();
          UIButton component21 = item.transform.GetChild(1).GetComponent<UIButton>();
          component21.m_Handler = (IUIButtonClickHandler) this;
          component21.m_BtnID1 = 3;
          component21.m_BtnID2 = 15;
          break;
      }
    }
  }

  public void UpdatRow_Boards(GameObject item, int dataIdx, int panelObjectIdx)
  {
    if (dataIdx == 0)
    {
      switch (UIKingdomVSLBoard.SubBoardID)
      {
        case 5:
        case 12:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component1 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component1.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component1.SetAllDirty();
          component1.cachedTextGenerator.Invalidate();
          UIText component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component2.text = DataManager.Instance.mStringTable.GetStringByID(9850U);
          component2.SetAllDirty();
          component2.cachedTextGenerator.Invalidate();
          UIText component3 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component3.text = DataManager.Instance.mStringTable.GetStringByID(9851U);
          component3.SetAllDirty();
          component3.cachedTextGenerator.Invalidate();
          break;
        case 6:
        case 13:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component4 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component4.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component4.SetAllDirty();
          component4.cachedTextGenerator.Invalidate();
          UIText component5 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component5.text = DataManager.Instance.mStringTable.GetStringByID(7094U);
          component5.SetAllDirty();
          component5.cachedTextGenerator.Invalidate();
          UIText component6 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component6.text = DataManager.Instance.mStringTable.GetStringByID(9857U);
          component6.SetAllDirty();
          component6.cachedTextGenerator.Invalidate();
          break;
        case 7:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component7 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component7.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component7.SetAllDirty();
          component7.cachedTextGenerator.Invalidate();
          UIText component8 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component8.text = DataManager.Instance.mStringTable.GetStringByID(7063U);
          component8.SetAllDirty();
          component8.cachedTextGenerator.Invalidate();
          UIText component9 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component9.text = DataManager.Instance.mStringTable.GetStringByID(9858U);
          component9.SetAllDirty();
          component9.cachedTextGenerator.Invalidate();
          break;
        case 14:
        case 15:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component10 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component10.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component10.SetAllDirty();
          component10.cachedTextGenerator.Invalidate();
          UIText component11 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component11.text = DataManager.Instance.mStringTable.GetStringByID(7063U);
          component11.SetAllDirty();
          component11.cachedTextGenerator.Invalidate();
          UIText component12 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component12.text = DataManager.Instance.mStringTable.GetStringByID(9858U);
          component12.SetAllDirty();
          component12.cachedTextGenerator.Invalidate();
          break;
      }
    }
    else
    {
      LeaderBoardManager.Instance.CheckNextPart(UIKingdomVSLBoard.SubBoardID, (byte) dataIdx);
      item.transform.GetChild(0).gameObject.SetActive(false);
      item.transform.GetChild(1).gameObject.SetActive(true);
      this.SortTextArray[0, panelObjectIdx].ClearString();
      this.SortTextArray[0, panelObjectIdx].IntToFormat((long) dataIdx);
      this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
      UIText component13 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
      component13.text = this.SortTextArray[0, panelObjectIdx].ToString();
      component13.SetAllDirty();
      component13.cachedTextGenerator.Invalidate();
      switch (UIKingdomVSLBoard.SubBoardID)
      {
        case 5:
        case 12:
          CString str = StringManager.Instance.StaticString1024();
          str.ClearString();
          DataManager.MapDataController.GetKingdomName(((BoardUnitKingdom) LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1]).KingdomID, ref str);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          this.SortTextArray[1, panelObjectIdx].IntToFormat((long) ((BoardUnitKingdom) LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1]).KingdomID);
          this.SortTextArray[1, panelObjectIdx].StringToFormat(str);
          this.SortTextArray[1, panelObjectIdx].AppendFormat("#{0} {1}");
          UIText component14 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
          component14.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component14.SetAllDirty();
          component14.cachedTextGenerator.Invalidate();
          break;
        case 6:
        case 13:
          this.SortTextArray[1, panelObjectIdx].ClearString();
          GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], ((BoardUnitKingdomWarAlliance) LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1]).KingdomID, LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1].AlliaceTag);
          UIText component15 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
          component15.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component15.SetAllDirty();
          component15.cachedTextGenerator.Invalidate();
          break;
        case 7:
          this.SortTextArray[1, panelObjectIdx].ClearString();
          GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], (ushort) 0, LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1].AlliaceTag);
          UIText component16 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
          component16.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component16.SetAllDirty();
          component16.cachedTextGenerator.Invalidate();
          break;
        case 14:
        case 15:
          this.SortTextArray[1, panelObjectIdx].ClearString();
          GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], ((WorldRankingBoardUnit) LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1]).KingdomID, LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1].AlliaceTag);
          UIText component17 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
          component17.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component17.SetAllDirty();
          component17.cachedTextGenerator.Invalidate();
          break;
      }
      this.SortTextArray[2, panelObjectIdx].ClearString();
      if (UIKingdomVSLBoard.SubBoardID == (byte) 5 || UIKingdomVSLBoard.SubBoardID == (byte) 12)
      {
        item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        if (((BoardUnitKingdom) LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1]).KingKingdomID != (ushort) 0)
        {
          if ((int) ((BoardUnitKingdom) LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1]).KingKingdomID == (int) ((BoardUnitKingdom) LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1]).KingdomID)
          {
            GameConstants.GetNameString(this.SortTextArray[2, panelObjectIdx], ((BoardUnitKingdom) LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1]).KingKingdomID, LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1].AlliaceTag, true);
          }
          else
          {
            GameConstants.GetNameString(this.SortTextArray[2, panelObjectIdx], ((BoardUnitKingdom) LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1]).KingKingdomID, LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1].AlliaceTag, true);
            this.SortTextArray[2, panelObjectIdx].Insert(0, "<color=#FFD74CFF>");
            this.SortTextArray[2, panelObjectIdx].Append("</color>");
          }
        }
      }
      else
      {
        item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1].Value, bNumber: true);
        this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
      }
      UIText component18 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
      component18.text = this.SortTextArray[2, panelObjectIdx].ToString();
      component18.SetAllDirty();
      component18.cachedTextGenerator.Invalidate();
      UIButton component19 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
      component19.m_Handler = (IUIButtonClickHandler) this;
      component19.m_BtnID1 = 4;
      component19.m_BtnID2 = dataIdx - 1;
      if ((UIKingdomVSLBoard.SubBoardID == (byte) 5 || UIKingdomVSLBoard.SubBoardID == (byte) 12) && LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][dataIdx - 1].Name.Length == 0)
        ((Component) component19).gameObject.SetActive(false);
      else
        ((Component) component19).gameObject.SetActive(true);
      if (dataIdx == (int) LeaderBoardManager.Instance.MyRank[(int) UIKingdomVSLBoard.SubBoardID])
      {
        item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(2);
        item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(2);
        item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(2);
      }
      else if (dataIdx % 2 == 0)
      {
        item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(1);
        item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(1);
        item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(1);
      }
      else
      {
        item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(0);
        item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(0);
        item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(0);
      }
    }
  }

  public override void UpDateRowItem(
    GameObject item,
    int dataIdx,
    int panelObjectIdx,
    int panelId)
  {
    switch (panelId)
    {
      case 1:
        this.UpdateRow_FunctionList(item, dataIdx, panelObjectIdx);
        break;
      case 2:
        this.UpdatRow_Boards(item, dataIdx, panelObjectIdx);
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if ((byte) arg1 == (byte) 5)
      this.door.CloseMenu();
    switch ((int) (byte) arg1 - 2)
    {
      case 0:
        if (!UIKingdomVSLBoard.isTopBoard)
          break;
        this.CreateTopBoard();
        if (!this.LoadComplet)
        {
          this.DataReady = true;
          break;
        }
        this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardTypes);
        this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false);
        this.AGS_Panel1.GoTo(0);
        break;
      case 1:
        if (UIKingdomVSLBoard.isTopBoard || arg2 != (int) UIKingdomVSLBoard.SubBoardID)
          break;
        this.CreateSubBoard();
        this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
        this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
        break;
      case 2:
        if (UIKingdomVSLBoard.isTopBoard || arg2 != (int) UIKingdomVSLBoard.SubBoardID)
          break;
        UILeaderBoardBase.TopIndex[(int) UIKingdomVSLBoard.SubBoardID] = 0;
        this.CreateSubBoard();
        this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
        this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
        this.AGS_Panel2.GoTo(0);
        break;
    }
  }

  public void Update()
  {
    if (!this.LoadComplet)
    {
      this.SetDefaultSize();
      this.LoadComplet = true;
      this.AGS_Panel1.IntiScrollPanel(447f, 0.0f, 0.0f, this.SPHeight, 4, (IUpDateScrollPanel) this);
      this.AGS_Panel2.IntiScrollPanel(447f, 0.0f, 0.0f, this.SPHeight, 12, (IUpDateScrollPanel) this);
      UIButtonHint.scrollRect = this.AGS_Panel2.GetComponent<CScrollRect>();
      for (int index1 = 0; index1 < this.SortTextArray.GetLength(0); ++index1)
      {
        for (int index2 = 0; index2 < this.SortTextArray.GetLength(1); ++index2)
          this.SortTextArray[index1, index2] = StringManager.Instance.SpawnString(50);
      }
      this.Ranking = StringManager.Instance.SpawnString(300);
      this.RankValue = StringManager.Instance.SpawnString(100);
    }
    if (this.DataReady && this.LoadComplet)
    {
      this.DataReady = false;
      if (UIKingdomVSLBoard.isTopBoard)
      {
        this.CreateTopBoard();
        this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardTypes);
        this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false);
        this.AGS_Panel1.GoTo(0);
      }
      else
      {
        this.CreateSubBoard();
        this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
        this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
        this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[(int) UIKingdomVSLBoard.SubBoardID]);
      }
    }
    this.GetPointTime += Time.smoothDeltaTime / 2f;
    if ((double) this.GetPointTime >= 1.7000000476837158)
      this.GetPointTime = 0.3f;
    Color color = new Color(1f, 1f, 1f, (double) this.GetPointTime <= 1.0 ? this.GetPointTime : 2f - this.GetPointTime);
    ((Graphic) this.POPLight1).color = color;
    ((Graphic) this.POPLight3).color = color;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if ((Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Chat) != (Object) null)
        {
          this.door.CloseMenu_Alliance(EGUIWindow.UI_LeaderBoard);
          break;
        }
        this.door.CloseMenu();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public override void OnButtonClick(UIButton sender)
  {
    int btnId1 = sender.m_BtnID1;
    switch (btnId1)
    {
      case 0:
        if (UIKingdomVSLBoard.isTopBoard)
        {
          this.door.CloseMenu();
          UIKingdomVSLBoard.NewOpen = true;
          break;
        }
        UILeaderBoardBase.TopIndex[(int) UIKingdomVSLBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
        this.MainBoardChange();
        break;
      case 3:
        switch ((byte) sender.m_BtnID2)
        {
          case 5:
            UIKingdomVSLBoard.isPersonBoard = true;
            break;
          case 6:
            UIKingdomVSLBoard.isPersonBoard = false;
            break;
          case 7:
            if (DataManager.Instance.RoleAlliance.Id == 0U || LeaderBoardManager.Instance.KVSTopBoard.KvKAlliTopPlayerName.Length == 0)
              return;
            UIKingdomVSLBoard.isPersonBoard = true;
            break;
          case 12:
            UIKingdomVSLBoard.isPersonBoard = true;
            break;
          case 13:
            UIKingdomVSLBoard.isPersonBoard = false;
            break;
          case 14:
            UIKingdomVSLBoard.isPersonBoard = true;
            break;
          case 15:
            UIKingdomVSLBoard.isPersonBoard = true;
            break;
        }
        this.SubBoardChange((byte) sender.m_BtnID2);
        break;
      case 4:
        if (UIKingdomVSLBoard.isPersonBoard)
        {
          UILeaderBoardBase.TopIndex[(int) UIKingdomVSLBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
          DataManager.Instance.ShowLordProfile(LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][sender.m_BtnID2].Name.ToString());
          break;
        }
        UILeaderBoardBase.TopIndex[(int) UIKingdomVSLBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
        DataManager.Instance.AllianceView.Id = ((BoardUnitAlliance) LeaderBoardManager.Instance.Boards[(int) UIKingdomVSLBoard.SubBoardID][sender.m_BtnID2]).AllianceID;
        this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5);
        break;
      default:
        if (btnId1 != 9)
        {
          if (btnId1 != 99)
            break;
          GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7028U), DataManager.Instance.mStringTable.GetStringByID(9041U), bInfo: true);
          break;
        }
        if (!UIKingdomVSLBoard.WorldBoard)
        {
          UIKingdomVSLBoard.WorldBoard = true;
          this.MainBoardChange();
          break;
        }
        UIKingdomVSLBoard.WorldBoard = false;
        this.MainBoardChange();
        break;
    }
  }
}
