// Decompiled with JetBrains decompiler
// Type: UIAlliHuntBoard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAlliHuntBoard : UILeaderBoardBase
{
  public static bool NewOpen;

  public override void OnOpen(int arg1, int arg2)
  {
    base.OnOpen(arg1, arg2);
    if (LeaderBoardManager.Instance.AlliHuntBoardUpdateTime < DataManager.Instance.ServerTime || (int) LeaderBoardManager.Instance.MobiGroupAllianceID != (int) DataManager.Instance.RoleAlliance.Id)
    {
      UILeaderBoardBase.TopIndex[3] = 0;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AS_PERSONAL_RANK;
      messagePacket.AddSeqId();
      messagePacket.Send();
      this.DataReady = false;
    }
    else
      this.DataReady = true;
  }

  private void CreateAlliHuntBoard()
  {
    this.SPHeight.Clear();
    this.SPHeight.Add(38f);
    for (ushort index = 0; (int) index < LeaderBoardManager.Instance.AlliHuntBoard.Count; ++index)
      this.SPHeight.Add(53f);
    this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(1362U);
    this.AGS_Form.GetChild(2).gameObject.SetActive(true);
    this.AGS_Form.GetChild(5).gameObject.SetActive(false);
    this.AGS_Form.GetChild(3).gameObject.SetActive(true);
    this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
    this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
    Transform child = this.AGS_Form.GetChild(3).GetChild(0);
    child.gameObject.SetActive(true);
    GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, (byte) 11, (byte) 0);
    if (LeaderBoardManager.Instance.AlliHuntRank <= 0)
      return;
    UIText component1 = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
    this.Ranking.ClearString();
    this.Ranking.IntToFormat((long) LeaderBoardManager.Instance.AlliHuntRank);
    this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7060U));
    component1.text = this.Ranking.ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    UIText component2 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
    this.RankValue.ClearString();
    this.RankValue.uLongToFormat(LeaderBoardManager.Instance.AlliHuntBoard[LeaderBoardManager.Instance.AlliHuntRank - 1].Value);
    this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8121U));
    component2.text = this.RankValue.ToString();
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
  }

  public void Update()
  {
    if (!this.LoadComplet)
    {
      this.SetDefaultSize();
      this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(10).gameObject.SetActive(false);
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
    this.CreateAlliHuntBoard();
    this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
    this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
    this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[16]);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if ((byte) arg1 == (byte) 5)
      this.door.CloseMenu();
    if ((byte) arg1 != (byte) 11)
      return;
    this.CreateAlliHuntBoard();
    if (!this.LoadComplet)
    {
      this.DataReady = true;
    }
    else
    {
      this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
      this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
      if (UILeaderBoardBase.TopIndex[16] == 0 && UIAlliHuntBoard.NewOpen)
      {
        UIAlliHuntBoard.NewOpen = false;
        UILeaderBoardBase.TopIndex[16] = LeaderBoardManager.Instance.AlliHuntRank;
      }
      this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[16]);
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
      component1.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
      component1.SetAllDirty();
      component1.cachedTextGenerator.Invalidate();
      UIText component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
      component2.text = DataManager.Instance.mStringTable.GetStringByID(4717U);
      component2.SetAllDirty();
      component2.cachedTextGenerator.Invalidate();
      UIText component3 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
      component3.text = DataManager.Instance.mStringTable.GetStringByID(9858U);
      component3.SetAllDirty();
      component3.cachedTextGenerator.Invalidate();
    }
    else
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
      this.SortTextArray[1, panelObjectIdx].Append(LeaderBoardManager.Instance.AlliHuntBoard[dataIdx - 1].Name);
      UIText component5 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
      component5.text = this.SortTextArray[1, panelObjectIdx].ToString();
      component5.SetAllDirty();
      component5.cachedTextGenerator.Invalidate();
      this.SortTextArray[2, panelObjectIdx].ClearString();
      this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.AlliHuntBoard[dataIdx - 1].Value, bNumber: true);
      this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
      UIText component6 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
      component6.text = this.SortTextArray[2, panelObjectIdx].ToString();
      component6.SetAllDirty();
      component6.cachedTextGenerator.Invalidate();
      if (dataIdx == LeaderBoardManager.Instance.AlliHuntRank)
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
    switch (sender.m_BtnID1)
    {
      case 0:
        this.door.CloseMenu();
        break;
      case 99:
        UILeaderBoardBase.TopIndex[14] = this.AGS_Panel2.GetTopIdx();
        GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7028U), DataManager.Instance.mStringTable.GetStringByID(9041U), bInfo: true);
        break;
    }
  }
}
