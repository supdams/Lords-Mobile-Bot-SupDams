// Decompiled with JetBrains decompiler
// Type: UIAlliVSAlliBoard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAlliVSAlliBoard : UILeaderBoardBase
{
  public static int MemTopIndex;
  public static bool NewOpen;
  public List<int> RankingTable;
  private static int SPtab = 10000;

  public override void OnOpen(int arg1, int arg2)
  {
    base.OnOpen(arg1, arg2);
    this.RankingTable = new List<int>();
    if (LeaderBoardManager.Instance.AllianceWarAlliBoardUpdateTime < DataManager.Instance.ServerTime || (int) LeaderBoardManager.Instance.MobiGroupAllianceID != (int) DataManager.Instance.RoleAlliance.Id)
    {
      UIAlliVSAlliBoard.MemTopIndex = 0;
      ActivityManager.Instance.AllianceWarMgr.SendAllianceWarList();
      this.DataReady = false;
    }
    else
      this.DataReady = true;
  }

  private void CreateAlliVSAlliBoard()
  {
    this.SPHeight.Clear();
    this.SPHeight.Add(38f);
    for (ushort index = 0; (int) index < (int) ActivityManager.Instance.AllianceWarMgr.GetRegisterCount(); ++index)
      this.SPHeight.Add(53f);
    this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(17012U);
    this.AGS_Form.GetChild(2).gameObject.SetActive(true);
    this.AGS_Form.GetChild(5).gameObject.SetActive(false);
    this.AGS_Form.GetChild(3).gameObject.SetActive(true);
    this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
    this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
    Transform child = this.AGS_Form.GetChild(3).GetChild(0);
    child.gameObject.SetActive(true);
    GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, (byte) 11, (byte) 0);
    if (ActivityManager.Instance.AllianceWarMgr.MyRank > (byte) 0)
    {
      int x = (int) ActivityManager.Instance.AllianceWarMgr.GetRegisterCount() < (int) ActivityManager.Instance.AW_MemberCount ? ActivityManager.Instance.AllianceWarMgr.getMyRankIndex() : ((int) ActivityManager.Instance.AllianceWarMgr.MyRank > (int) ActivityManager.Instance.AW_MemberCount ? (int) ActivityManager.Instance.AW_MemberCount - (int) ActivityManager.Instance.AllianceWarMgr.MyRank : (int) ActivityManager.Instance.AW_MemberCount - (int) ActivityManager.Instance.AllianceWarMgr.MyRank + 1);
      UIText component1 = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
      this.Ranking.ClearString();
      if (x < 0)
      {
        this.Ranking.IntToFormat((long) (x * -1));
        this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17017U));
      }
      else
      {
        this.Ranking.IntToFormat((long) x);
        this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17036U));
      }
      component1.text = this.Ranking.ToString();
      component1.SetAllDirty();
      component1.cachedTextGenerator.Invalidate();
      UIText component2 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
      this.RankValue.ClearString();
      this.RankValue.uLongToFormat(ActivityManager.Instance.AllianceWarMgr.GetMyDataIdx((int) ActivityManager.Instance.AllianceWarMgr.MyRank).Power, bNumber: true);
      this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7061U));
      component2.text = this.RankValue.ToString();
      component2.SetAllDirty();
      component2.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.AGS_Form.GetChild(3).gameObject.SetActive(false);
      this.AGS_Form.GetChild(5).gameObject.SetActive(true);
      UIText component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
      this.Ranking.ClearString();
      this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(14627U));
      component.text = this.Ranking.ToString();
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
    }
    this.RankingTable.Clear();
    this.RankingTable.Add(UIAlliVSAlliBoard.SPtab);
    for (int index = 0; index < (int) ActivityManager.Instance.AllianceWarMgr.GetRegisterCount(); ++index)
      this.RankingTable.Add(index);
    if (ActivityManager.Instance.AllianceWarMgr.GetRegisterCount() == (byte) 0)
    {
      this.AGS_Form.GetChild(13).gameObject.SetActive(true);
      this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(17075U);
    }
    else
      this.AGS_Form.GetChild(13).gameObject.SetActive(false);
  }

  public void Update()
  {
    if (!this.LoadComplet)
    {
      this.SetDefaultSize();
      this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(10).gameObject.SetActive(true);
      this.LoadComplet = true;
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
    if (!this.DataReady || !this.LoadComplet)
      return;
    this.DataReady = false;
    this.CreateAlliVSAlliBoard();
    this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
    this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
    if (UIAlliVSAlliBoard.MemTopIndex == 0 && UIAlliVSAlliBoard.NewOpen)
    {
      UIAlliVSAlliBoard.NewOpen = false;
      int myRankIndex = ActivityManager.Instance.AllianceWarMgr.getMyRankIndex();
      if (myRankIndex > 4)
        UIAlliVSAlliBoard.MemTopIndex = myRankIndex - 3;
    }
    this.AGS_Panel2.GoTo(UIAlliVSAlliBoard.MemTopIndex);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    this.CreateAlliVSAlliBoard();
    if (!this.LoadComplet)
    {
      this.DataReady = true;
    }
    else
    {
      this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
      this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
      if (UIAlliVSAlliBoard.MemTopIndex == 0 && UIAlliVSAlliBoard.NewOpen)
      {
        UIAlliVSAlliBoard.NewOpen = false;
        int myRankIndex = ActivityManager.Instance.AllianceWarMgr.getMyRankIndex();
        if (myRankIndex > 4)
          UIAlliVSAlliBoard.MemTopIndex = myRankIndex - 3;
      }
      this.AGS_Panel2.GoTo(UIAlliVSAlliBoard.MemTopIndex);
    }
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

  public override void UpDateRowItem(
    GameObject item,
    int dataIdx,
    int panelObjectIdx,
    int panelId)
  {
    if (dataIdx == 0)
    {
      item.transform.GetChild(0).gameObject.SetActive(true);
      item.transform.GetChild(1).gameObject.SetActive(false);
      UIText component1 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
      component1.text = DataManager.Instance.mStringTable.GetStringByID(17013U);
      component1.SetAllDirty();
      component1.cachedTextGenerator.Invalidate();
      UIText component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
      component2.text = DataManager.Instance.mStringTable.GetStringByID(17012U);
      component2.SetAllDirty();
      component2.cachedTextGenerator.Invalidate();
      UIText component3 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
      component3.text = DataManager.Instance.mStringTable.GetStringByID(1560U);
      component3.SetAllDirty();
      component3.cachedTextGenerator.Invalidate();
    }
    else if (this.RankingTable[dataIdx] == UIAlliVSAlliBoard.SPtab)
    {
      item.transform.GetChild(0).gameObject.SetActive(false);
      item.transform.GetChild(1).gameObject.SetActive(true);
      item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
      this.SortTextArray[0, panelObjectIdx].ClearString();
      this.SortTextArray[0, panelObjectIdx].IntToFormat((long) dataIdx);
      this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
      UIText component4 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
      component4.text = this.SortTextArray[0, panelObjectIdx].ToString();
      component4.SetAllDirty();
      component4.cachedTextGenerator.Invalidate();
      this.SortTextArray[1, panelObjectIdx].ClearString();
      this.SortTextArray[1, panelObjectIdx].Append(string.Empty);
      UIText component5 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
      component5.text = this.SortTextArray[1, panelObjectIdx].ToString();
      component5.SetAllDirty();
      component5.cachedTextGenerator.Invalidate();
      this.SortTextArray[2, panelObjectIdx].ClearString();
      this.SortTextArray[2, panelObjectIdx].Append(string.Empty);
      UIText component6 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
      component6.text = this.SortTextArray[2, panelObjectIdx].ToString();
      component6.SetAllDirty();
      component6.cachedTextGenerator.Invalidate();
      item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(0);
      item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(0);
      item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(0);
    }
    else
    {
      AllianceWarManager._RegisterData dataIndex = ActivityManager.Instance.AllianceWarMgr.GetDataIndex(this.RankingTable[dataIdx]);
      item.transform.GetChild(0).gameObject.SetActive(false);
      item.transform.GetChild(1).gameObject.SetActive(true);
      item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
      this.SortTextArray[0, panelObjectIdx].ClearString();
      if (dataIdx > (int) ActivityManager.Instance.AW_MemberCount)
      {
        this.SortTextArray[0, panelObjectIdx].IntToFormat((long) (dataIdx - (int) ActivityManager.Instance.AW_MemberCount));
        this.SortTextArray[0, panelObjectIdx].AppendFormat("~{0}");
      }
      else
      {
        this.SortTextArray[0, panelObjectIdx].IntToFormat((long) dataIdx);
        this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
      }
      UIText component7 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
      component7.text = this.SortTextArray[0, panelObjectIdx].ToString();
      component7.SetAllDirty();
      component7.cachedTextGenerator.Invalidate();
      this.SortTextArray[1, panelObjectIdx].ClearString();
      this.SortTextArray[1, panelObjectIdx].Append(dataIndex.Name);
      UIText component8 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
      component8.text = this.SortTextArray[1, panelObjectIdx].ToString();
      component8.SetAllDirty();
      component8.cachedTextGenerator.Invalidate();
      this.SortTextArray[2, panelObjectIdx].ClearString();
      this.SortTextArray[2, panelObjectIdx].uLongToFormat(dataIndex.Power, bNumber: true);
      this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
      UIText component9 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
      component9.text = this.SortTextArray[2, panelObjectIdx].ToString();
      component9.SetAllDirty();
      component9.cachedTextGenerator.Invalidate();
      UIButton component10 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
      component10.m_Handler = (IUIButtonClickHandler) this;
      component10.m_BtnID1 = 6;
      component10.m_BtnID2 = dataIdx;
      if (ActivityManager.Instance.AllianceWarMgr.getMyRankIndex() == dataIdx)
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

  public override void OnButtonClick(UIButton sender)
  {
    int topIdx = this.AGS_Panel2.GetTopIdx();
    UIAlliVSAlliBoard.MemTopIndex = topIdx <= 0 ? 1 : topIdx;
    switch (sender.m_BtnID1)
    {
      case 0:
        this.door.CloseMenu();
        break;
      case 6:
        DataManager.Instance.ShowLordProfile(ActivityManager.Instance.AllianceWarMgr.GetDataIndex(this.RankingTable[sender.m_BtnID2]).Name.ToString());
        break;
      case 99:
        GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7028U), DataManager.Instance.mStringTable.GetStringByID(9041U), bInfo: true);
        break;
    }
  }
}
