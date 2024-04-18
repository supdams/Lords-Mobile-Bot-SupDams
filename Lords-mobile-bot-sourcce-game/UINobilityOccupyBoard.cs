// Decompiled with JetBrains decompiler
// Type: UINobilityOccupyBoard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal class UINobilityOccupyBoard : UILeaderBoardBase
{
  public byte CurrentWonderId;

  public override void OnOpen(int arg1, int arg2)
  {
    base.OnOpen(0, 0);
    if (LeaderBoardManager.Instance.NobileTime < DataManager.Instance.ServerTime | arg1 != (int) LeaderBoardManager.Instance.NobileWonderId)
    {
      this.CurrentWonderId = (byte) arg1;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_FEDERAL_RANKDATA;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) arg1);
      messagePacket.Send();
    }
    else
    {
      this.CurrentWonderId = (byte) arg1;
      this.DataReady = true;
    }
  }

  private void CreateNobilityOccupyBoard()
  {
    if ((int) LeaderBoardManager.Instance.NobileWonderId != (int) this.CurrentWonderId)
      return;
    this.SPHeight.Clear();
    this.SPHeight.Add(38f);
    Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
    for (ushort index = 0; (int) index < LeaderBoardManager.Instance.NobileBoard.Count && LeaderBoardManager.Instance.NobileBoard[(int) index].HomeKingdomID > (ushort) 0; ++index)
      this.SPHeight.Add(53f);
    this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(11153U);
    this.AGS_Form.GetChild(2).gameObject.SetActive(true);
    this.AGS_Form.GetChild(5).gameObject.SetActive(false);
    this.AGS_Form.GetChild(3).gameObject.SetActive(true);
    this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
    this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
    Transform child = this.AGS_Form.GetChild(3).GetChild(0);
    child.gameObject.SetActive(true);
    GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, LeaderBoardManager.Instance.NobileHead, (byte) 11, (byte) 0);
    UIText component1 = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
    this.Ranking.ClearString();
    this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(11154U));
    component1.text = this.Ranking.ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    UIText component2 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
    this.RankValue.ClearString();
    if (LeaderBoardManager.Instance.NobileBoard.Count > 0)
      GameConstants.GetNameString(this.RankValue, LeaderBoardManager.Instance.NobileBoard[0].HomeKingdomID, LeaderBoardManager.Instance.NobileBoard[0].Name, LeaderBoardManager.Instance.NobileBoard[0].AllianceTag, true);
    component2.text = this.RankValue.ToString();
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
  }

  public void Update()
  {
    if (!this.LoadComplet)
    {
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
    this.CreateNobilityOccupyBoard();
    this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
    this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
    this.AGS_Panel2.GoTo(0);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != (int) this.CurrentWonderId)
      return;
    this.CreateNobilityOccupyBoard();
    if (!this.LoadComplet)
    {
      this.DataReady = true;
    }
    else
    {
      this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
      this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
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
      component3.text = DataManager.Instance.mStringTable.GetStringByID(11011U);
      component3.SetAllDirty();
      component3.cachedTextGenerator.Invalidate();
    }
    else
    {
      item.transform.GetChild(0).gameObject.SetActive(false);
      item.transform.GetChild(1).gameObject.SetActive(true);
      item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
      item.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
      this.SortTextArray[0, panelObjectIdx].ClearString();
      this.SortTextArray[0, panelObjectIdx].IntToFormat((long) dataIdx);
      this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
      UIText component4 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
      component4.text = this.SortTextArray[0, panelObjectIdx].ToString();
      component4.SetAllDirty();
      component4.cachedTextGenerator.Invalidate();
      this.SortTextArray[1, panelObjectIdx].ClearString();
      GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.NobileBoard[dataIdx - 1].HomeKingdomID, LeaderBoardManager.Instance.NobileBoard[dataIdx - 1].Name, LeaderBoardManager.Instance.NobileBoard[dataIdx - 1].AllianceTag, true);
      UIText component5 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
      component5.text = this.SortTextArray[1, panelObjectIdx].ToString();
      component5.SetAllDirty();
      component5.cachedTextGenerator.Invalidate();
      this.SortTextArray[2, panelObjectIdx].ClearString();
      GameConstants.GetTimeString(this.SortTextArray[2, panelObjectIdx], LeaderBoardManager.Instance.NobileBoard[dataIdx - 1].OccupyTime);
      UIText component6 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
      component6.text = this.SortTextArray[2, panelObjectIdx].ToString();
      component6.alignment = TextAnchor.MiddleCenter;
      component6.SetAllDirty();
      component6.cachedTextGenerator.Invalidate();
      if (dataIdx % 2 == 0)
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
      UIButton component7 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
      component7.m_Handler = (IUIButtonClickHandler) this;
      component7.m_BtnID1 = 10;
      component7.m_BtnID2 = dataIdx - 1;
    }
  }

  public override void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        this.door.CloseMenu();
        break;
      case 10:
        if (sender.m_BtnID2 >= LeaderBoardManager.Instance.NobileBoard.Count || sender.m_BtnID2 < 0)
          break;
        DataManager.Instance.ShowLordProfile(LeaderBoardManager.Instance.NobileBoard[sender.m_BtnID2].Name.ToString());
        break;
    }
  }
}
