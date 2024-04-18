// Decompiled with JetBrains decompiler
// Type: UINobilityBoard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal class UINobilityBoard : UILeaderBoardBase
{
  private byte SendResult;
  private static readonly int[] MobiWorldKingBoardSize = new int[4]
  {
    330,
    189,
    257,
    257
  };
  private int m_WonderID;

  public override void OnOpen(int arg1, int arg2)
  {
    base.OnOpen(arg1, arg2);
    this.m_WonderID = arg2;
    LeaderBoardManager.Instance.Send_MSG_REQUEST_FEDERAL_HISTORYKINGDATA((byte) this.m_WonderID);
  }

  private void CreateNobilityBoard()
  {
    this.SPHeight.Clear();
    this.SPHeight.Add(38f);
    for (ushort index = 0; (int) index < LeaderBoardManager.Instance.MobiWorldKingBoard.Count; ++index)
      this.SPHeight.Add(53f);
    this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(11061U);
    this.AGS_Form.GetChild(2).gameObject.SetActive(true);
    this.AGS_Form.GetChild(5).gameObject.SetActive(false);
    this.AGS_Form.GetChild(3).gameObject.SetActive(true);
    this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
    this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
    this.SetHiBtnAndText();
    UIText component1 = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
    if (this.Ranking != null)
    {
      this.Ranking.ClearString();
      component1.text = DataManager.Instance.mStringTable.GetStringByID(11088U);
      component1.SetAllDirty();
      component1.cachedTextGenerator.Invalidate();
    }
    this.AGS_Form.GetChild(9).gameObject.SetActive(true);
    UIText component2 = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
      component2.text = this.SendResult != (byte) 0 ? DataManager.Instance.mStringTable.GetStringByID(11155U) : DataManager.Instance.mStringTable.GetStringByID(11090U);
    if (LeaderBoardManager.Instance.MobiWorldKingBoard.Count <= 0)
      this.AGS_Form.GetChild(13).gameObject.SetActive(true);
    else
      this.AGS_Form.GetChild(13).gameObject.SetActive(false);
  }

  private void SetHiBtnAndText()
  {
    Transform child = this.AGS_Form.GetChild(3).GetChild(0);
    GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, LeaderBoardManager.Instance.KingHead, (byte) 11, (byte) 0);
    UIText component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
    if (LeaderBoardManager.Instance.MobiWorldKingBoard.Count > 0 && LeaderBoardManager.Instance.KingHead != (ushort) 0)
    {
      GameConstants.FormatRoleName(this.RankValue, LeaderBoardManager.Instance.MobiWorldKingBoard[0].Name, LeaderBoardManager.Instance.MobiWorldKingBoard[0].AllianceTag, bCheckedNickname: (byte) 0, KingdomID: LeaderBoardManager.Instance.MobiWorldKingBoard[0].HomeKingdomID);
      component.text = this.RankValue.ToString();
    }
    if (this.m_WonderID >= 0 && this.m_WonderID < DataManager.MapDataController.YolkPointTable.Length)
    {
      MapYolk mapYolk = DataManager.MapDataController.YolkPointTable[this.m_WonderID];
      bool flag = mapYolk.WonderLeader != null && mapYolk.WonderLeader.Length > 0;
      if (mapYolk.WonderState == (byte) 0 && flag && LeaderBoardManager.Instance.KingHead > (ushort) 0)
      {
        child.gameObject.SetActive(true);
        ((Component) component).gameObject.SetActive(true);
      }
      else
      {
        child.gameObject.SetActive(false);
        ((Component) component).gameObject.SetActive(false);
      }
    }
    else
    {
      child.gameObject.SetActive(false);
      ((Component) component).gameObject.SetActive(false);
    }
  }

  public void Update()
  {
    if (!this.LoadComplet)
    {
      RectTransform component1 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
      int x1 = 0;
      ((Component) component1).transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
      ((Component) component1).transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
      ((Component) component1).transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
      ((Component) component1).transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
      RectTransform component2 = ((Transform) component1).GetChild(0).GetChild(0).GetComponent<RectTransform>();
      component2.anchoredPosition = new Vector2((float) x1, component2.anchoredPosition.y);
      component2.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UINobilityBoard.MobiWorldKingBoardSize[0]);
      RectTransform component3 = ((Transform) component1).GetChild(0).GetChild(4).GetComponent<RectTransform>();
      component3.anchoredPosition = new Vector2((float) (x1 + UINobilityBoard.MobiWorldKingBoardSize[0] / 2), component3.anchoredPosition.y);
      component3.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UINobilityBoard.MobiWorldKingBoardSize[0]);
      int x2 = UINobilityBoard.MobiWorldKingBoardSize[0];
      RectTransform component4 = ((Transform) component1).GetChild(0).GetChild(1).GetComponent<RectTransform>();
      component4.anchoredPosition = new Vector2((float) x2, component4.anchoredPosition.y);
      component4.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UINobilityBoard.MobiWorldKingBoardSize[1]);
      RectTransform component5 = ((Transform) component1).GetChild(0).GetChild(5).GetComponent<RectTransform>();
      component5.anchoredPosition = new Vector2((float) (x2 + UINobilityBoard.MobiWorldKingBoardSize[1] / 2), component5.anchoredPosition.y);
      component5.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UINobilityBoard.MobiWorldKingBoardSize[1]);
      int x3 = UINobilityBoard.MobiWorldKingBoardSize[0] + UINobilityBoard.MobiWorldKingBoardSize[1];
      RectTransform component6 = ((Transform) component1).GetChild(0).GetChild(2).GetComponent<RectTransform>();
      component6.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UINobilityBoard.MobiWorldKingBoardSize[2]);
      component6.anchoredPosition = new Vector2((float) x3, component6.anchoredPosition.y);
      RectTransform component7 = ((Transform) component1).GetChild(0).GetChild(6).GetComponent<RectTransform>();
      component7.anchoredPosition = new Vector2((float) (x3 + UINobilityBoard.MobiWorldKingBoardSize[2] / 2), component7.anchoredPosition.y);
      component7.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UINobilityBoard.MobiWorldKingBoardSize[2]);
      ((Component) ((Transform) component1).GetChild(0).GetChild(3).GetComponent<RectTransform>()).gameObject.SetActive(false);
      ((Component) ((Transform) component1).GetChild(0).GetChild(7).GetComponent<RectTransform>()).gameObject.SetActive(false);
      int x4 = 0;
      RectTransform component8 = ((Transform) component1).GetChild(1).GetChild(0).GetComponent<RectTransform>();
      component8.anchoredPosition = new Vector2((float) x4, component8.anchoredPosition.y);
      component8.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UINobilityBoard.MobiWorldKingBoardSize[0]);
      int num = 10;
      RectTransform component9 = ((Transform) component1).GetChild(1).GetChild(4).GetComponent<RectTransform>();
      component9.anchoredPosition = new Vector2((float) (num + UINobilityBoard.MobiWorldKingBoardSize[0] / 2), component9.anchoredPosition.y);
      component9.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) (UINobilityBoard.MobiWorldKingBoardSize[0] - 20));
      ((Transform) component1).GetChild(1).GetChild(4).GetComponent<UIText>().alignment = TextAnchor.MiddleLeft;
      int x5 = UINobilityBoard.MobiWorldKingBoardSize[0];
      RectTransform component10 = ((Transform) component1).GetChild(1).GetChild(1).GetComponent<RectTransform>();
      component10.anchoredPosition = new Vector2((float) x5, component10.anchoredPosition.y);
      component10.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UINobilityBoard.MobiWorldKingBoardSize[1]);
      RectTransform component11 = ((Transform) component1).GetChild(1).GetChild(5).GetComponent<RectTransform>();
      ((Transform) component1).GetChild(1).GetChild(5).GetComponent<UIText>().alignment = TextAnchor.MiddleCenter;
      component11.anchoredPosition = new Vector2((float) x5, component11.anchoredPosition.y);
      component11.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UINobilityBoard.MobiWorldKingBoardSize[1]);
      int x6 = UINobilityBoard.MobiWorldKingBoardSize[0] + UINobilityBoard.MobiWorldKingBoardSize[1];
      RectTransform component12 = ((Transform) component1).GetChild(1).GetChild(2).GetComponent<RectTransform>();
      component12.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UINobilityBoard.MobiWorldKingBoardSize[2]);
      component12.anchoredPosition = new Vector2((float) x6, component12.anchoredPosition.y);
      RectTransform component13 = ((Transform) component1).GetChild(1).GetChild(6).GetComponent<RectTransform>();
      component13.anchoredPosition = new Vector2((float) x6, component13.anchoredPosition.y);
      component13.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UINobilityBoard.MobiWorldKingBoardSize[3]);
      ((Component) ((Transform) component1).GetChild(1).GetChild(3).GetComponent<RectTransform>()).gameObject.SetActive(false);
      ((Component) ((Transform) component1).GetChild(1).GetChild(7).GetComponent<RectTransform>()).gameObject.SetActive(false);
      ((Component) ((Component) component1).transform.GetChild(1).GetChild(10).GetComponent<RectTransform>()).gameObject.SetActive(false);
      this.LoadComplet = true;
      this.AGS_Panel1.IntiScrollPanel(447f, 0.0f, 0.0f, this.SPHeight, 3, (IUpDateScrollPanel) this);
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
    this.CreateNobilityBoard();
    this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
    this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
    this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[15]);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg2)
    {
      case 0:
      case 2:
        if (arg2 == 2)
          this.SendResult = (byte) 1;
        this.CreateNobilityBoard();
        if (!this.LoadComplet)
        {
          this.DataReady = true;
          break;
        }
        this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
        this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
        this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[15]);
        break;
      case 1:
        this.DataReady = false;
        LeaderBoardManager.Instance.Send_MSG_REQUEST_FEDERAL_HISTORYKINGDATA((byte) this.m_WonderID);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh:
        this.DataReady = false;
        LeaderBoardManager.Instance.Send_MSG_REQUEST_FEDERAL_HISTORYKINGDATA((byte) this.m_WonderID);
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
      component1.text = DataManager.Instance.mStringTable.GetStringByID(7063U);
      component1.SetAllDirty();
      component1.cachedTextGenerator.Invalidate();
      UIText component2 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
      component2.text = DataManager.Instance.mStringTable.GetStringByID(11011U);
      component2.SetAllDirty();
      component2.cachedTextGenerator.Invalidate();
      UIText component3 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
      component3.text = DataManager.Instance.mStringTable.GetStringByID(11012U);
      component3.SetAllDirty();
      component3.cachedTextGenerator.Invalidate();
    }
    else
    {
      if (dataIdx > 0 && dataIdx <= LeaderBoardManager.Instance.MobiWorldKingBoard.Count)
      {
        item.transform.GetChild(0).gameObject.SetActive(false);
        item.transform.GetChild(1).gameObject.SetActive(true);
        item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
        this.SortTextArray[0, panelObjectIdx].ClearString();
        GameConstants.FormatRoleName(this.SortTextArray[0, panelObjectIdx], LeaderBoardManager.Instance.MobiWorldKingBoard[dataIdx - 1].Name, LeaderBoardManager.Instance.MobiWorldKingBoard[dataIdx - 1].AllianceTag, bCheckedNickname: (byte) 0, KingdomID: LeaderBoardManager.Instance.MobiWorldKingBoard[dataIdx - 1].HomeKingdomID);
        UIText component4 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
        component4.text = this.SortTextArray[0, panelObjectIdx].ToString();
        component4.SetAllDirty();
        component4.cachedTextGenerator.Invalidate();
        this.SortTextArray[1, panelObjectIdx].ClearString();
        GameConstants.GetTimeString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.MobiWorldKingBoard[dataIdx - 1].OccupyTime);
        UIText component5 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
        component5.text = this.SortTextArray[1, panelObjectIdx].ToString();
        component5.SetAllDirty();
        component5.cachedTextGenerator.Invalidate();
        this.SortTextArray[2, panelObjectIdx].ClearString();
        DateTime dateTime = GameConstants.GetDateTime(LeaderBoardManager.Instance.MobiWorldKingBoard[dataIdx - 1].TakeOfficeTime);
        this.SortTextArray[2, panelObjectIdx].StringToFormat(dateTime.ToString("MM/dd/yy"));
        this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
        UIText component6 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
        component6.text = this.SortTextArray[2, panelObjectIdx].ToString();
        component6.alignment = TextAnchor.MiddleCenter;
        component6.SetAllDirty();
        component6.cachedTextGenerator.Invalidate();
        UIButton component7 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
        component7.m_Handler = (IUIButtonClickHandler) this;
        component7.m_BtnID1 = 8;
        component7.m_BtnID2 = dataIdx - 1;
      }
      if (dataIdx % 2 == 0)
      {
        item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(1);
        item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(1);
        item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(1);
        item.transform.GetChild(1).GetChild(3).GetComponent<UISpritesArray>().SetSpriteIndex(1);
      }
      else
      {
        item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(0);
        item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(0);
        item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(0);
        item.transform.GetChild(1).GetChild(3).GetComponent<UISpritesArray>().SetSpriteIndex(0);
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
        GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(11061U), DataManager.Instance.mStringTable.GetStringByID(11089U), BackExit: true);
        break;
    }
  }
}
