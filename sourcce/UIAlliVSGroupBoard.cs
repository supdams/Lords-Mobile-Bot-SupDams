// Decompiled with JetBrains decompiler
// Type: UIAlliVSGroupBoard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAlliVSGroupBoard : UILeaderBoardBase
{
  private static readonly int[] VSBoardSize = new int[4]
  {
    92,
    90,
    307,
    287
  };
  public static bool NewOpen;
  private CString HintStr;
  private UIText Text1;

  public override void OnOpen(int arg1, int arg2)
  {
    base.OnOpen(arg1, arg2);
    UIButton component = this.AGS_Form.GetChild(10).GetComponent<UIButton>();
    component.m_Handler = (IUIButtonClickHandler) this;
    component.m_EffectType = e_EffectType.e_Normal;
    component.transition = (Selectable.Transition) 0;
    component.m_BtnID1 = 12;
    UIButtonHint uiButtonHint = ((Component) component).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_eHint = EUIButtonHint.UIArena_Hint;
    uiButtonHint.m_Handler = (MonoBehaviour) this;
    uiButtonHint.ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
    uiButtonHint.ScrollID = (byte) 1;
    this.HintStr = StringManager.Instance.SpawnString(300);
    if (LeaderBoardManager.Instance.AllianceWarGroupBoardUpdateTime < DataManager.Instance.ServerTime || (int) LeaderBoardManager.Instance.MobiGroupAllianceID != (int) DataManager.Instance.RoleAlliance.Id)
    {
      UILeaderBoardBase.TopIndex[19] = 0;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_RANK;
      messagePacket.AddSeqId();
      messagePacket.Send();
      this.DataReady = false;
    }
    else
      this.DataReady = true;
    GameObject gameObject = new GameObject("Text1");
    gameObject.transform.SetParent(this.AGS_Form.GetChild(10).transform, false);
    RectTransform rectTransform = gameObject.AddComponent<RectTransform>();
    rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
    rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 44f);
    rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 44f);
    UIText uiText = gameObject.AddComponent<UIText>();
    uiText.font = GUIManager.Instance.GetTTFFont();
    uiText.resizeTextForBestFit = true;
    uiText.resizeTextMinSize = 24;
    uiText.resizeTextMaxSize = 30;
    uiText.alignment = TextAnchor.LowerCenter;
    uiText.text = string.Empty;
    this.Text1 = uiText;
    gameObject.AddComponent<Outline>();
    gameObject.AddComponent<Shadow>();
  }

  public override void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.HintStr);
    base.OnClose();
  }

  private void CreateAlliVSBoard()
  {
    this.SPHeight.Clear();
    this.SPHeight.Add(38f);
    for (ushort index = 0; (int) index < LeaderBoardManager.Instance.AllianceWarGroupBoard.Count; ++index)
      this.SPHeight.Add(53f);
    this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7091U);
    this.AGS_Form.GetChild(2).gameObject.SetActive(true);
    this.AGS_Form.GetChild(5).gameObject.SetActive(true);
    UIText component1 = this.AGS_Form.GetChild(5).GetComponent<UIText>();
    this.Ranking.ClearString();
    this.Ranking.IntToFormat((long) LeaderBoardManager.Instance.AllianceWarGroupRank);
    this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9856U));
    component1.text = this.Ranking.ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    Image component2 = this.AGS_Form.GetChild(10).GetComponent<Image>();
    ((Component) component2).gameObject.SetActive(true);
    GUIManager.Instance.SetAllyWarRankImage(component2, ActivityManager.Instance.AW_Rank);
    this.Text1.text = ActivityManager.Instance.AW_Rank.ToString();
    ((Component) this.Text1).gameObject.GetComponent<RectTransform>().anchoredPosition = ActivityManager.Instance.AW_Rank <= (byte) 20 ? new Vector2(0.0f, 5f) : Vector2.zero;
    UIButton component3 = this.AGS_Form.GetChild(10).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_EffectType = e_EffectType.e_Normal;
    component3.transition = (Selectable.Transition) 0;
    component3.m_BtnID1 = 12;
    UIButtonHint uiButtonHint = ((Component) component3).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_eHint = EUIButtonHint.UIArena_Hint;
    uiButtonHint.m_Handler = (MonoBehaviour) this;
    uiButtonHint.ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
    uiButtonHint.ScrollID = (byte) 1;
  }

  public void Update()
  {
    if (!this.LoadComplet)
    {
      this.UpdateScrollSize();
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
    this.CreateAlliVSBoard();
    this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
    this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
    if (UILeaderBoardBase.TopIndex[19] == 0 && UIAlliVSGroupBoard.NewOpen)
    {
      UIAlliVSGroupBoard.NewOpen = false;
      if (LeaderBoardManager.Instance.AllianceWarGroupRank > 4)
        UILeaderBoardBase.TopIndex[19] = LeaderBoardManager.Instance.AllianceWarGroupRank - 3;
    }
    this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[19]);
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    this.CreateAlliVSBoard();
    if (!this.LoadComplet)
    {
      this.DataReady = true;
    }
    else
    {
      this.SetOpenType(UILeaderBoardBase.e_OpenType.BoardContent);
      this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
      if (UILeaderBoardBase.TopIndex[19] == 0 && UIAlliVSGroupBoard.NewOpen)
      {
        UIAlliVSGroupBoard.NewOpen = false;
        if (LeaderBoardManager.Instance.AllianceWarGroupRank > 4)
          UILeaderBoardBase.TopIndex[19] = LeaderBoardManager.Instance.AllianceWarGroupRank - 3;
      }
      this.AGS_Panel2.GoTo(UILeaderBoardBase.TopIndex[19]);
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
      component2.text = DataManager.Instance.mStringTable.GetStringByID(17034U);
      component2.SetAllDirty();
      component2.cachedTextGenerator.Invalidate();
      UIText component3 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
      component3.text = DataManager.Instance.mStringTable.GetStringByID(7094U);
      component3.SetAllDirty();
      component3.cachedTextGenerator.Invalidate();
      UIText component4 = item.transform.GetChild(0).GetChild(7).GetComponent<UIText>();
      component4.text = DataManager.Instance.mStringTable.GetStringByID(17039U);
      component4.SetAllDirty();
      component4.cachedTextGenerator.Invalidate();
    }
    else
    {
      item.transform.GetChild(0).gameObject.SetActive(false);
      item.transform.GetChild(1).gameObject.SetActive(true);
      item.transform.GetChild(1).GetChild(10).gameObject.SetActive(true);
      item.transform.GetChild(1).GetChild(12).gameObject.SetActive(true);
      this.SortTextArray[0, panelObjectIdx].ClearString();
      this.SortTextArray[0, panelObjectIdx].IntToFormat((long) dataIdx);
      this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
      UIText component5 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
      component5.text = this.SortTextArray[0, panelObjectIdx].ToString();
      component5.SetAllDirty();
      component5.cachedTextGenerator.Invalidate();
      this.SortTextArray[1, panelObjectIdx].ClearString();
      GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], (ushort) 0, LeaderBoardManager.Instance.AllianceWarGroupBoard[dataIdx - 1].Name, LeaderBoardManager.Instance.AllianceWarGroupBoard[dataIdx - 1].AllianceTag);
      UIText component6 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
      component6.text = this.SortTextArray[1, panelObjectIdx].ToString();
      component6.SetAllDirty();
      component6.cachedTextGenerator.Invalidate();
      this.SortTextArray[2, panelObjectIdx].ClearString();
      this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.AllianceWarGroupBoard[dataIdx - 1].Power, bNumber: true);
      this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
      UIText component7 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
      component7.text = this.SortTextArray[2, panelObjectIdx].ToString();
      component7.SetAllDirty();
      component7.cachedTextGenerator.Invalidate();
      this.SortTextArray[3, panelObjectIdx].ClearString();
      this.SortTextArray[3, panelObjectIdx].IntToFormat((long) LeaderBoardManager.Instance.AllianceWarGroupBoard[dataIdx - 1].Score, bNumber: true);
      this.SortTextArray[3, panelObjectIdx].AppendFormat("{0}");
      UIText component8 = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
      component8.text = this.SortTextArray[3, panelObjectIdx].ToString();
      component8.SetAllDirty();
      component8.cachedTextGenerator.Invalidate();
      if (dataIdx == LeaderBoardManager.Instance.AllianceWarGroupRank)
      {
        item.transform.GetChild(1).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(2);
        item.transform.GetChild(1).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(2);
        item.transform.GetChild(1).GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(2);
        item.transform.GetChild(1).GetChild(3).GetComponent<UISpritesArray>().SetSpriteIndex(2);
      }
      else if (dataIdx % 2 == 0)
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
      UIButton component9 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
      component9.m_Handler = (IUIButtonClickHandler) this;
      component9.m_BtnID1 = 6;
      component9.m_BtnID2 = dataIdx - 1;
      UIButton component10 = item.transform.GetChild(1).GetChild(12).GetComponent<UIButton>();
      component10.m_Handler = (IUIButtonClickHandler) this;
      component10.m_BtnID1 = 11;
      component10.m_BtnID2 = dataIdx;
      UIText component11 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
      if (dataIdx <= (int) LeaderBoardManager.Instance.AllianceWarGroupRankUpNum)
      {
        component10.m_BtnID3 = 1;
        ((Graphic) component11).color = (Color) new Color32(byte.MaxValue, byte.MaxValue, (byte) 0, byte.MaxValue);
      }
      else if (dataIdx >= (int) LeaderBoardManager.Instance.AllianceWarGroupRankDownNum)
      {
        component10.m_BtnID3 = 2;
        ((Graphic) component11).color = (Color) new Color32((byte) 0, byte.MaxValue, byte.MaxValue, byte.MaxValue);
      }
      else
      {
        component10.m_BtnID3 = 3;
        ((Graphic) component11).color = (Color) new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
      }
      UIButtonHint component12 = item.transform.GetChild(1).GetChild(12).GetComponent<UIButtonHint>();
      component12.Parm1 = (ushort) dataIdx;
      component12.m_eHint = EUIButtonHint.DownUpHandler;
      component12.m_Handler = (MonoBehaviour) this;
      component12.ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
    }
  }

  public override void OnButtonClick(UIButton sender)
  {
    int topIdx = this.AGS_Panel2.GetTopIdx();
    UILeaderBoardBase.TopIndex[19] = topIdx <= 0 ? 1 : topIdx;
    switch (sender.m_BtnID1)
    {
      case 0:
        this.door.CloseMenu();
        break;
      case 6:
        this.door.AllianceInfo(LeaderBoardManager.Instance.AllianceWarGroupBoard[sender.m_BtnID2].AlliacneID);
        break;
    }
  }

  public override void OnButtonDown(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    if ((Object) button == (Object) null)
      return;
    switch (button.m_BtnID1)
    {
      case 11:
        this.HintStr.ClearString();
        switch (button.m_BtnID3)
        {
          case 1:
            this.HintStr.IntToFormat((long) button.m_BtnID2);
            this.HintStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17025U));
            break;
          case 2:
            this.HintStr.IntToFormat((long) button.m_BtnID2);
            this.HintStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17026U));
            break;
          case 3:
            this.HintStr.IntToFormat((long) button.m_BtnID2);
            this.HintStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17027U));
            break;
        }
        GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.HintStr, new Vector2(70f, -50f));
        break;
      case 12:
        this.HintStr.ClearString();
        this.HintStr.IntToFormat((long) ActivityManager.Instance.AW_Rank);
        this.HintStr.IntToFormat((long) ActivityManager.Instance.AW_MemberCount);
        this.HintStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17074U));
        GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.HintStr, new Vector2(70f, -50f));
        break;
    }
  }

  public override void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide();

  private void UpdateScrollSize()
  {
    int num = 0;
    RectTransform component1 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
    RectTransform component2 = ((Transform) component1).GetChild(0).GetChild(4).GetComponent<RectTransform>();
    component2.anchoredPosition = new Vector2((float) (num + UIAlliVSGroupBoard.VSBoardSize[0] / 2), component2.anchoredPosition.y);
    component2.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) (UIAlliVSGroupBoard.VSBoardSize[0] - 2));
    ((Component) component1).transform.GetChild(0).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UIAlliVSGroupBoard.VSBoardSize[0]);
    ((Component) component1).transform.GetChild(1).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UIAlliVSGroupBoard.VSBoardSize[0]);
    RectTransform component3 = ((Component) component1).transform.GetChild(1).GetChild(4).GetComponent<RectTransform>();
    component3.anchoredPosition = new Vector2((float) (num + UIAlliVSGroupBoard.VSBoardSize[0] / 2), component3.anchoredPosition.y);
    component3.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) (UIAlliVSGroupBoard.VSBoardSize[0] - 20));
    int x1 = UIAlliVSGroupBoard.VSBoardSize[0];
    ((Component) component1).transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
    ((Component) component1).transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
    ((Component) component1).transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
    ((Component) component1).transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
    RectTransform component4 = ((Transform) component1).GetChild(0).GetChild(5).GetComponent<RectTransform>();
    component4.anchoredPosition = new Vector2((float) (x1 + UIAlliVSGroupBoard.VSBoardSize[1] / 2), component4.anchoredPosition.y);
    component4.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UIAlliVSGroupBoard.VSBoardSize[1]);
    RectTransform component5 = ((Component) component1).transform.GetChild(0).GetChild(1).GetComponent<RectTransform>();
    component5.anchoredPosition = new Vector2((float) x1, component5.anchoredPosition.y);
    component5.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UIAlliVSGroupBoard.VSBoardSize[1]);
    RectTransform component6 = ((Component) component1).transform.GetChild(1).GetChild(1).GetComponent<RectTransform>();
    component6.anchoredPosition = new Vector2((float) x1, component6.anchoredPosition.y);
    component6.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UIAlliVSGroupBoard.VSBoardSize[1]);
    RectTransform component7 = ((Component) component1).transform.GetChild(1).GetChild(7).GetComponent<RectTransform>();
    component7.anchoredPosition = new Vector2((float) (x1 + 10), component7.anchoredPosition.y);
    component7.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) (UIAlliVSGroupBoard.VSBoardSize[1] - 20));
    ((Component) component7).GetComponent<UIText>().alignment = TextAnchor.MiddleCenter;
    int x2 = x1 + UIAlliVSGroupBoard.VSBoardSize[1];
    RectTransform component8 = ((Component) component1).transform.GetChild(0).GetChild(6).GetComponent<RectTransform>();
    component8.anchoredPosition = new Vector2((float) (x2 + UIAlliVSGroupBoard.VSBoardSize[2] / 2), component8.anchoredPosition.y);
    component8.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UIAlliVSGroupBoard.VSBoardSize[2]);
    RectTransform component9 = ((Component) component1).transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
    component9.anchoredPosition = new Vector2((float) x2, component9.anchoredPosition.y);
    component9.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UIAlliVSGroupBoard.VSBoardSize[2]);
    RectTransform component10 = ((Transform) component1).GetChild(1).GetChild(5).GetComponent<RectTransform>();
    component10.anchoredPosition = new Vector2((float) (x2 + 10), component10.anchoredPosition.y);
    component10.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) (UIAlliVSGroupBoard.VSBoardSize[2] - 20));
    RectTransform component11 = ((Component) component1).transform.GetChild(1).GetChild(3).GetComponent<RectTransform>();
    component11.anchoredPosition = new Vector2((float) x2, component11.anchoredPosition.y);
    component11.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UIAlliVSGroupBoard.VSBoardSize[2]);
    ((Component) component11).gameObject.SetActive(true);
    int x3 = x2 + UIAlliVSGroupBoard.VSBoardSize[2];
    RectTransform component12 = ((Component) component1).transform.GetChild(0).GetChild(7).GetComponent<RectTransform>();
    component12.anchoredPosition = new Vector2((float) (x3 + UIAlliVSGroupBoard.VSBoardSize[3] / 2), component12.anchoredPosition.y);
    component12.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UIAlliVSGroupBoard.VSBoardSize[3]);
    RectTransform component13 = ((Component) component1).transform.GetChild(0).GetChild(3).GetComponent<RectTransform>();
    component13.anchoredPosition = new Vector2((float) x3, component13.anchoredPosition.y);
    component13.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UIAlliVSGroupBoard.VSBoardSize[3]);
    RectTransform component14 = ((Component) component1).transform.GetChild(1).GetChild(6).GetComponent<RectTransform>();
    component14.anchoredPosition = new Vector2((float) (x3 + 10), component14.anchoredPosition.y);
    component14.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) (UIAlliVSGroupBoard.VSBoardSize[3] - 96));
    ((Component) component14).GetComponent<UIText>().alignment = TextAnchor.MiddleRight;
    RectTransform component15 = ((Component) component1).transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
    component15.anchoredPosition = new Vector2((float) x3, component15.anchoredPosition.y);
    component15.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UIAlliVSGroupBoard.VSBoardSize[3]);
    UIButton component16 = ((Component) component1).transform.GetChild(1).GetChild(12).GetComponent<UIButton>();
    component16.m_Handler = (IUIButtonClickHandler) this;
    ((Component) component16).gameObject.SetActive(true);
    UIButtonHint uiButtonHint = ((Component) component16).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint.m_Handler = (MonoBehaviour) this;
    uiButtonHint.ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
    ((Component) component16).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UIAlliVSGroupBoard.VSBoardSize[1]);
    ((Component) component1).transform.GetChild(1).GetChild(10).gameObject.SetActive(true);
  }
}
