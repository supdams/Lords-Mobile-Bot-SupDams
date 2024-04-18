// Decompiled with JetBrains decompiler
// Type: UILeaderBoard
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UILeaderBoard : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  private Transform AGS_Form;
  private ScrollPanel AGS_Panel1;
  private ScrollPanel AGS_Panel2;
  private Door door;
  private float GetPointTime;
  private Image POPLight1;
  private Image POPLight3;
  private RectTransform KingdomImg;
  private bool LoadComplet;
  private bool DataReady;
  private List<float> SPHeight;
  private UI_LeaderBoardOpenKind OpenKind;
  private static List<AllianceBoardData> SortedAlliInterList;
  private CString[,] SortTextArray = new CString[4, 12];
  private CString Ranking;
  private CString RankValue;
  private CString HintStr;
  private ushort MyRank;
  public static int[] TopIndex = new int[16];
  private uint m_targetAllianceID;
  public static byte SubBoardID;
  public static bool isTopBoard = true;
  public static bool isPersonBoard = true;
  public static bool NewOpen;
  public static bool WorldBoard = false;
  private static readonly int[] MobiGroupBoardSize = new int[4]
  {
    102,
    80,
    307,
    287
  };
  private static readonly int[] MobiAlliBoardSize = new int[4]
  {
    102,
    307,
    184,
    183
  };
  private static readonly int[] MobiWorldKingBoardSize = new int[4]
  {
    330,
    189,
    257,
    257
  };
  private static readonly int[] CommonBoardSize = new int[3]
  {
    102,
    385,
    289
  };
  private bool SPReady;
  private Image SPBG;
  private Image SPRankUpDown;
  private UIText SPName;
  private UIText SPScore;
  private UIText SPScoreFly;
  private UIText SPRank;
  private CString[] SPStrings = new CString[4];
  private RectTransform SPFly;
  private float SPShowTime;
  private float SPShowPhase;
  private float[] SPShowTiming = new float[9]
  {
    0.4f,
    0.2f,
    0.05f,
    0.1f,
    0.4f,
    0.1f,
    0.1f,
    0.8f,
    0.4f
  };
  public static bool ShowSP = false;
  public static int SPScoreValue = 0;
  public static int SPScoreFlyValue = 0;
  public static int SPRankChange = 0;

  public override void OnOpen(int arg1, int arg2)
  {
    this.door = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    this.SPHeight = new List<float>();
    this.OpenKind = (UI_LeaderBoardOpenKind) arg1;
    this.m_targetAllianceID = (uint) arg2;
    this.DataReady = false;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = string.Empty;
    Image component2 = this.AGS_Form.GetChild(8).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component2).material = this.door.LoadMaterial();
    ((Behaviour) component2).enabled = !GUIManager.Instance.bOpenOnIPhoneX;
    Image component3 = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<Image>();
    component3.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component3).material = this.door.LoadMaterial();
    UIButton component4 = this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_EffectType = e_EffectType.e_Scale;
    UIHIBtn component5 = this.AGS_Form.GetChild(3).GetChild(0).GetComponent<UIHIBtn>();
    UIText component6 = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
    component6.font = ttfFont;
    component6.text = string.Empty;
    UIText component7 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
    component7.font = ttfFont;
    component7.text = string.Empty;
    UIButton component8 = this.AGS_Form.GetChild(11).GetComponent<UIButton>();
    component8.m_Handler = (IUIButtonClickHandler) this;
    component8.m_BtnID1 = 7;
    ((Component) component8).gameObject.SetActive(false);
    this.SPBG = this.AGS_Form.GetChild(14).GetComponent<Image>();
    this.SPRankUpDown = this.AGS_Form.GetChild(14).GetChild(3).GetComponent<Image>();
    ((Component) this.SPBG).gameObject.SetActive(false);
    UIButton component9 = this.AGS_Form.GetChild(12).GetComponent<UIButton>();
    component9.m_Handler = (IUIButtonClickHandler) this;
    component9.m_BtnID1 = 9;
    ((Component) component9).gameObject.SetActive(false);
    UIButton component10 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
    component10.m_Handler = (IUIButtonClickHandler) this;
    component10.m_BtnID1 = 2;
    component10.m_BtnID2 = 1;
    this.POPLight1 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<Image>();
    UIButton component11 = this.AGS_Form.GetChild(4).GetChild(1).GetComponent<UIButton>();
    component11.m_Handler = (IUIButtonClickHandler) this;
    component11.m_BtnID1 = 2;
    component11.m_BtnID2 = 2;
    this.POPLight3 = this.AGS_Form.GetChild(4).GetChild(1).GetChild(0).GetComponent<Image>();
    UIText component12 = this.AGS_Form.GetChild(5).GetComponent<UIText>();
    component12.font = ttfFont;
    component12.text = string.Empty;
    this.AGS_Panel1 = this.AGS_Form.GetChild(6).GetChild(0).GetComponent<ScrollPanel>();
    this.AGS_Panel1.m_ScrollPanelID = 1;
    this.AGS_Form.GetChild(6).GetChild(1).GetChild(1).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    ((Graphic) this.AGS_Form.GetChild(6).GetChild(1).GetChild(1).GetComponent<Image>()).color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    component5 = this.AGS_Form.GetChild(6).GetChild(1).GetChild(3).GetComponent<UIHIBtn>();
    UIText component13 = this.AGS_Form.GetChild(6).GetChild(1).GetChild(4).GetComponent<UIText>();
    component13.font = ttfFont;
    component13.text = string.Empty;
    UIText component14 = this.AGS_Form.GetChild(6).GetChild(1).GetChild(5).GetComponent<UIText>();
    component14.font = ttfFont;
    component14.text = string.Empty;
    UIText component15 = this.AGS_Form.GetChild(6).GetChild(1).GetChild(6).GetComponent<UIText>();
    component15.font = ttfFont;
    component15.text = string.Empty;
    this.AGS_Panel2 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<ScrollPanel>();
    this.AGS_Panel2.m_ScrollPanelID = 2;
    UIText component16 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetChild(4).GetComponent<UIText>();
    component16.font = ttfFont;
    component16.text = string.Empty;
    UIText component17 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetChild(5).GetComponent<UIText>();
    component17.font = ttfFont;
    component17.text = string.Empty;
    UIText component18 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetChild(6).GetComponent<UIText>();
    component18.font = ttfFont;
    component18.text = string.Empty;
    UIText component19 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetChild(7).GetComponent<UIText>();
    component19.font = ttfFont;
    component19.text = string.Empty;
    UIText component20 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(4).GetComponent<UIText>();
    component20.font = ttfFont;
    component20.text = string.Empty;
    UIText component21 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(5).GetComponent<UIText>();
    component21.font = ttfFont;
    component21.text = string.Empty;
    UIText component22 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(6).GetComponent<UIText>();
    component22.font = ttfFont;
    component22.text = string.Empty;
    UIText component23 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(7).GetComponent<UIText>();
    component23.font = ttfFont;
    component23.text = string.Empty;
    ((Component) component23).gameObject.SetActive(false);
    UIText component24 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(9).GetComponent<UIText>();
    component24.font = ttfFont;
    component24.text = string.Empty;
    ((Component) component24).gameObject.SetActive(false);
    UIButton component25 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(10).GetComponent<UIButton>();
    component25.m_Handler = (IUIButtonClickHandler) this;
    component25.m_EffectType = e_EffectType.e_Scale;
    UIButton component26 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(11).GetComponent<UIButton>();
    component26.m_Handler = (IUIButtonClickHandler) this;
    component26.m_EffectType = e_EffectType.e_Scale;
    UIButtonHint uiButtonHint1 = ((Component) component26).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.UIArena_Hint;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    uiButtonHint1.ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
    this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(3).gameObject.SetActive(false);
    this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(8).gameObject.SetActive(false);
    this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    UIButton component27 = this.AGS_Form.GetChild(9).GetComponent<UIButton>();
    component27.m_Handler = (IUIButtonClickHandler) this;
    component27.m_EffectType = e_EffectType.e_Scale;
    component27.m_BtnID1 = 99;
    ((Component) component27).gameObject.SetActive(this.OpenKind == UI_LeaderBoardOpenKind.BoardMenu);
    UIText component28 = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
    component28.font = ttfFont;
    component28.text = DataManager.Instance.mStringTable.GetStringByID(11025U);
    this.SPBG = this.AGS_Form.GetChild(14).GetComponent<Image>();
    this.SPRankUpDown = this.AGS_Form.GetChild(14).GetChild(3).GetComponent<Image>();
    ((Component) this.SPBG).gameObject.SetActive(false);
    UIText component29 = this.AGS_Form.GetChild(14).GetChild(0).GetComponent<UIText>();
    component29.font = ttfFont;
    component29.text = string.Empty;
    this.SPName = component29;
    UIText component30 = this.AGS_Form.GetChild(14).GetChild(1).GetComponent<UIText>();
    component30.font = ttfFont;
    component30.text = string.Empty;
    this.SPScore = component30;
    UIText component31 = this.AGS_Form.GetChild(14).GetChild(2).GetComponent<UIText>();
    component31.font = ttfFont;
    component31.text = string.Empty;
    this.SPScoreFly = component31;
    this.SPFly = ((Graphic) component31).rectTransform;
    UIText component32 = this.AGS_Form.GetChild(14).GetChild(4).GetComponent<UIText>();
    component32.font = ttfFont;
    component32.text = string.Empty;
    this.SPRank = component32;
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component33 = ((Component) component27).gameObject.GetComponent<RectTransform>();
      ((Transform) component33).localScale = new Vector3(-1f, 1f, 1f);
      component33.anchoredPosition = new Vector2(component33.anchoredPosition.x + 44f, component33.anchoredPosition.y);
      ((Transform) this.AGS_Form.GetChild(12).gameObject.GetComponent<RectTransform>()).localScale = new Vector3(-1f, 1f, 1f);
    }
    Transform child1 = this.AGS_Form.GetChild(3).GetChild(0);
    GUIManager.Instance.InitianHeroItemImg(child1, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
    child1.gameObject.SetActive(false);
    Transform child2 = this.AGS_Form.GetChild(3).GetChild(1);
    GUIManager.Instance.InitBadgeTotem(child2, DataManager.Instance.RoleAlliance.Emblem);
    child2.gameObject.SetActive(false);
    this.KingdomImg = this.AGS_Form.GetChild(6).GetChild(2).GetComponent<RectTransform>();
    ((Component) this.KingdomImg).gameObject.SetActive(false);
    switch (this.OpenKind)
    {
      case UI_LeaderBoardOpenKind.Alli_Inter:
        if (DataManager.Instance.RoleAlliance.Id == 0U)
        {
          this.door.CloseMenu();
          return;
        }
        if (UILeaderBoard.NewOpen)
        {
          UILeaderBoard.TopIndex[12] = 0;
          DataManager.Instance.SendAllianceMember();
          break;
        }
        this.DataReady = true;
        break;
      case UI_LeaderBoardOpenKind.OtherAlli_inter:
        if (UILeaderBoard.NewOpen)
        {
          UILeaderBoard.TopIndex[12] = 0;
          DataManager.Instance.SendAllianceOthorMemberInfo(this.m_targetAllianceID);
          break;
        }
        this.DataReady = true;
        break;
      case UI_LeaderBoardOpenKind.BoardMenu:
        this.AGS_Form.GetChild(4).gameObject.SetActive(true);
        if (UILeaderBoard.NewOpen)
        {
          UILeaderBoard.isTopBoard = true;
          UILeaderBoard.isPersonBoard = true;
          UILeaderBoard.SubBoardID = (byte) 0;
          UILeaderBoard.NewOpen = false;
        }
        if (UILeaderBoard.WorldBoard)
        {
          if (LeaderBoardManager.Instance.TopBoard.SortTime + 600L < DataManager.Instance.ServerTime && UILeaderBoard.isTopBoard)
          {
            MessagePacket messagePacket = new MessagePacket((ushort) 1024);
            messagePacket.Protocol = Protocol._MSG_REQUEST_LEADERBOARDS_CLIENT;
            messagePacket.AddSeqId();
            messagePacket.Send();
            this.DataReady = false;
            break;
          }
          this.DataReady = true;
          break;
        }
        if (LeaderBoardManager.Instance.TopBoard.SortTime + 600L < DataManager.Instance.ServerTime && UILeaderBoard.isTopBoard)
        {
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_LEADERBOARDS_CLIENT;
          messagePacket.AddSeqId();
          messagePacket.Send();
          this.DataReady = false;
          break;
        }
        this.DataReady = true;
        break;
      case UI_LeaderBoardOpenKind.ArenaBoard:
        if (UILeaderBoard.NewOpen)
        {
          UILeaderBoard.isTopBoard = false;
          UILeaderBoard.isPersonBoard = true;
          UILeaderBoard.SubBoardID = (byte) 4;
          UILeaderBoard.NewOpen = false;
        }
        this.DataReady = true;
        break;
      case UI_LeaderBoardOpenKind.MobilizationGroupBoard:
        if (LeaderBoardManager.Instance.MobiGroupBoardUpdateTime < DataManager.Instance.ServerTime || (int) LeaderBoardManager.Instance.MobiGroupAllianceID != (int) DataManager.Instance.RoleAlliance.Id)
        {
          UILeaderBoard.TopIndex[13] = 0;
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AM_ALLIANCE_RANK;
          messagePacket.AddSeqId();
          messagePacket.Send();
        }
        else
          this.DataReady = true;
        Image component34 = this.AGS_Form.GetChild(10).GetComponent<Image>();
        ((Component) component34).gameObject.SetActive(true);
        GUIManager.Instance.SetAllyRankImage(component34, DataManager.Instance.RoleAlliance.AMRank);
        UIButton component35 = this.AGS_Form.GetChild(10).GetComponent<UIButton>();
        component35.m_Handler = (IUIButtonClickHandler) this;
        component35.m_EffectType = e_EffectType.e_Normal;
        component35.transition = (Selectable.Transition) 0;
        component35.m_BtnID1 = 12;
        UIButtonHint uiButtonHint2 = ((Component) component35).gameObject.AddComponent<UIButtonHint>();
        uiButtonHint2.m_eHint = EUIButtonHint.UIArena_Hint;
        uiButtonHint2.m_Handler = (MonoBehaviour) this;
        uiButtonHint2.ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
        uiButtonHint2.ScrollID = (byte) 1;
        break;
      case UI_LeaderBoardOpenKind.MobilizationAlliBoard:
        if (LeaderBoardManager.Instance.MobiAlliBoardUpdateTime < DataManager.Instance.ServerTime || (int) LeaderBoardManager.Instance.MobiGroupAllianceID != (int) DataManager.Instance.RoleAlliance.Id)
        {
          UILeaderBoard.TopIndex[14] = 0;
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_ACTIVITY_AM_MEMBER_RANK;
          messagePacket.AddSeqId();
          messagePacket.Send();
          break;
        }
        this.DataReady = true;
        break;
      case UI_LeaderBoardOpenKind.WorldKingHistory:
        LeaderBoardManager.Instance.Send_MSG_REQUEST_KINGOFTHEWORLD_HISTORYKINGDATA();
        break;
      case UI_LeaderBoardOpenKind.KingofWorldRankingBoard:
        if (LeaderBoardManager.Instance.KingofWorldTime < DataManager.Instance.ServerTime)
        {
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_KINGOFTHEWORLD_RANKDATA;
          messagePacket.AddSeqId();
          messagePacket.Send();
          break;
        }
        this.DataReady = true;
        break;
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.Ranking);
    StringManager.Instance.DeSpawnString(this.RankValue);
    StringManager.Instance.DeSpawnString(this.HintStr);
    for (int index1 = 0; index1 < this.SortTextArray.GetLength(0); ++index1)
    {
      for (int index2 = 0; index2 < this.SortTextArray.GetLength(1); ++index2)
        StringManager.Instance.DeSpawnString(this.SortTextArray[index1, index2]);
    }
    for (int index = 0; index < this.SPStrings.Length; ++index)
      StringManager.Instance.DeSpawnString(this.SPStrings[index]);
    UILeaderBoard.ShowSP = false;
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (this.OpenKind != UI_LeaderBoardOpenKind.MobilizationGroupBoard)
      return;
    UIButton button = sender.m_Button as UIButton;
    if ((UnityEngine.Object) button == (UnityEngine.Object) null)
      return;
    switch (button.m_BtnID1)
    {
      case 11:
        switch (button.m_BtnID3)
        {
          case 1:
            this.HintStr.Append(DataManager.Instance.mStringTable.GetStringByID(3703U));
            break;
          case 2:
            this.HintStr.Append(DataManager.Instance.mStringTable.GetStringByID(3704U));
            break;
          case 3:
            this.HintStr.IntToFormat((long) button.m_BtnID2);
            this.HintStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(3712U));
            break;
        }
        GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.HintStr, new Vector2(70f, -50f));
        break;
      case 12:
        uint ID = 1028U - (uint) DataManager.Instance.RoleAlliance.AMRank;
        this.HintStr.ClearString();
        this.HintStr.Append(DataManager.Instance.mStringTable.GetStringByID(ID));
        GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.HintStr, Vector2.zero);
        break;
    }
    this.HintStr.ClearString();
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if (this.OpenKind == UI_LeaderBoardOpenKind.MobilizationGroupBoard)
      GUIManager.Instance.m_Hint.Hide();
    else
      GUIManager.Instance.m_Arena_Hint.Hide(sender);
  }

  private void SetOpenType(UILeaderBoard.e_OpenType openType)
  {
    switch (openType)
    {
      case UILeaderBoard.e_OpenType.BoardTypes:
        this.AGS_Form.GetChild(6).gameObject.SetActive(true);
        this.AGS_Form.GetChild(7).gameObject.SetActive(false);
        break;
      case UILeaderBoard.e_OpenType.BoardContent:
        this.AGS_Form.GetChild(6).gameObject.SetActive(false);
        this.AGS_Form.GetChild(7).gameObject.SetActive(true);
        break;
    }
  }

  private void CreateAlliInterBoard()
  {
    this.MyRank = (ushort) 0;
    if (UILeaderBoard.NewOpen)
    {
      UILeaderBoard.NewOpen = false;
      if (UILeaderBoard.SortedAlliInterList == null)
        UILeaderBoard.SortedAlliInterList = new List<AllianceBoardData>();
      UILeaderBoard.SortedAlliInterList.Clear();
      this.SPHeight.Clear();
      this.SPHeight.Add(38f);
      int num = Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
      for (ushort index = 0; (int) index < num; ++index)
      {
        if (DataManager.Instance.AllianceMember[(int) index].UserId != 0L)
        {
          if (DataManager.Instance.RoleAttr.UserId == DataManager.Instance.AllianceMember[(int) index].UserId)
            this.MyRank = (ushort) ((uint) index + 1U);
          AllianceBoardData allianceBoardData = new AllianceBoardData();
          allianceBoardData.Name = StringManager.Instance.SpawnString();
          allianceBoardData.Name.Append(DataManager.Instance.AllianceMember[(int) index].Name);
          allianceBoardData.Power = DataManager.Instance.AllianceMember[(int) index].Power;
          allianceBoardData.isMe = DataManager.Instance.AllianceMember[(int) index].UserId == DataManager.Instance.RoleAttr.UserId;
          UILeaderBoard.SortedAlliInterList.Add(allianceBoardData);
          this.SPHeight.Add(53f);
        }
      }
      UILeaderBoard.SortedAlliInterList.Sort(new Comparison<AllianceBoardData>(UILeaderBoard.AlliInterPowerSort));
      for (ushort index = 0; (int) index < UILeaderBoard.SortedAlliInterList.Count; ++index)
      {
        if (UILeaderBoard.SortedAlliInterList[(int) index].isMe)
          this.MyRank = (ushort) ((uint) index + 1U);
      }
      UILeaderBoard.SortedAlliInterList.Insert(0, UILeaderBoard.SortedAlliInterList[0]);
    }
    else
    {
      this.SPHeight.Clear();
      this.SPHeight.Add(38f);
      for (ushort index = 1; (int) index < UILeaderBoard.SortedAlliInterList.Count; ++index)
      {
        if (UILeaderBoard.SortedAlliInterList[(int) index].isMe)
          this.MyRank = index;
        this.SPHeight.Add(53f);
      }
    }
    this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7059U);
    this.AGS_Form.GetChild(3).gameObject.SetActive(true);
    Transform child = this.AGS_Form.GetChild(3).GetChild(0);
    child.gameObject.SetActive(true);
    GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, (byte) 11, (byte) 0);
    UIText component1 = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
    this.Ranking.ClearString();
    this.Ranking.IntToFormat((long) this.MyRank);
    this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7060U));
    component1.text = this.Ranking.ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    UIText component2 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
    this.RankValue.ClearString();
    this.RankValue.uLongToFormat(DataManager.Instance.RoleAttr.Power, bNumber: true);
    this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7061U));
    component2.text = this.RankValue.ToString();
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
  }

  private void CreateOtherAlliInterBoard()
  {
    if (UILeaderBoard.NewOpen)
    {
      UILeaderBoard.NewOpen = false;
      if (UILeaderBoard.SortedAlliInterList == null)
        UILeaderBoard.SortedAlliInterList = new List<AllianceBoardData>();
      UILeaderBoard.SortedAlliInterList.Clear();
      this.SPHeight.Clear();
      this.SPHeight.Add(38f);
      int num = Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
      for (ushort index = 0; (int) index < num; ++index)
      {
        AllianceBoardData allianceBoardData = new AllianceBoardData();
        allianceBoardData.Name = StringManager.Instance.SpawnString();
        allianceBoardData.Name.Append(DataManager.Instance.AllianceMember[(int) index].Name);
        allianceBoardData.Power = DataManager.Instance.AllianceMember[(int) index].Power;
        allianceBoardData.isMe = false;
        UILeaderBoard.SortedAlliInterList.Add(allianceBoardData);
        this.SPHeight.Add(53f);
      }
      UILeaderBoard.SortedAlliInterList.Sort(new Comparison<AllianceBoardData>(UILeaderBoard.AlliInterPowerSort));
      UILeaderBoard.SortedAlliInterList.Insert(0, UILeaderBoard.SortedAlliInterList[0]);
    }
    else
    {
      this.SPHeight.Clear();
      this.SPHeight.Add(38f);
      for (ushort index = 1; (int) index < UILeaderBoard.SortedAlliInterList.Count; ++index)
        this.SPHeight.Add(53f);
    }
    this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7059U);
    this.AGS_Form.GetChild(2).gameObject.SetActive(true);
    this.AGS_Form.GetChild(5).gameObject.SetActive(true);
    UIText component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
    this.Ranking.ClearString();
    this.Ranking.StringToFormat(DataManager.Instance.AllianceView.Tag);
    this.Ranking.StringToFormat(DataManager.Instance.AllianceView.Name);
    this.Ranking.AppendFormat("[{0}]{1}");
    component.text = this.Ranking.ToString();
    component.SetAllDirty();
    component.cachedTextGenerator.Invalidate();
  }

  private void CreateMobilizationGroupBoard()
  {
    this.SPHeight.Clear();
    this.SPHeight.Add(38f);
    Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
    for (ushort index = 0; (int) index < LeaderBoardManager.Instance.MobiGroupBoard.Count; ++index)
      this.SPHeight.Add(53f);
    this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7091U);
    this.AGS_Form.GetChild(2).gameObject.SetActive(true);
    this.AGS_Form.GetChild(5).gameObject.SetActive(true);
    UIText component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
    this.Ranking.ClearString();
    this.Ranking.IntToFormat((long) LeaderBoardManager.Instance.MobiGroupRank);
    this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9856U));
    component.text = this.Ranking.ToString();
    component.SetAllDirty();
    component.cachedTextGenerator.Invalidate();
    this.AGS_Form.GetChild(11).gameObject.SetActive(true);
  }

  private void CreateMobilizationAlliBoard()
  {
    this.SPHeight.Clear();
    this.SPHeight.Add(38f);
    Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
    for (ushort index = 0; (int) index < LeaderBoardManager.Instance.MobiAlliBoard.Count; ++index)
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
    UIText component1 = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
    this.Ranking.ClearString();
    this.Ranking.IntToFormat((long) LeaderBoardManager.Instance.MobiAlliRank);
    this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7060U));
    component1.text = this.Ranking.ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    UIText component2 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
    this.RankValue.ClearString();
    this.RankValue.IntToFormat((long) LeaderBoardManager.Instance.MobiAlliBoard[LeaderBoardManager.Instance.MobiAlliRank - 1].Score);
    this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8121U));
    component2.text = this.RankValue.ToString();
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
  }

  private void CreateWorldKingHistoryBoard()
  {
    UILeaderBoard.NewOpen = false;
    this.SPHeight.Clear();
    this.SPHeight.Add(38f);
    for (ushort index = 0; (int) index < LeaderBoardManager.Instance.MobiWorldKingBoard.Count; ++index)
      this.SPHeight.Add(53f);
    this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(11030U);
    this.AGS_Form.GetChild(2).gameObject.SetActive(true);
    this.AGS_Form.GetChild(5).gameObject.SetActive(false);
    this.AGS_Form.GetChild(3).gameObject.SetActive(true);
    this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
    this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
    this.SetHiBtnAndText();
    UIText component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
    component.text = DataManager.Instance.mStringTable.GetStringByID(11010U);
    component.SetAllDirty();
    component.cachedTextGenerator.Invalidate();
    this.AGS_Form.GetChild(9).gameObject.SetActive(true);
    if (LeaderBoardManager.Instance.MobiWorldKingBoard.Count <= 0)
      this.AGS_Form.GetChild(13).gameObject.SetActive(true);
    else
      this.AGS_Form.GetChild(13).gameObject.SetActive(false);
  }

  private void CreateKingofWorldRankingBoard()
  {
    UILeaderBoard.NewOpen = false;
    this.SPHeight.Clear();
    this.SPHeight.Add(38f);
    Mathf.Clamp(DataManager.Instance.m_RecvDataIdx, 0, 100);
    for (ushort index = 0; (int) index < LeaderBoardManager.Instance.KingofWorldBoard.Count && LeaderBoardManager.Instance.KingofWorldBoard[(int) index].HomeKingdomID > (ushort) 0; ++index)
      this.SPHeight.Add(53f);
    this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(10016U);
    this.AGS_Form.GetChild(2).gameObject.SetActive(true);
    this.AGS_Form.GetChild(5).gameObject.SetActive(false);
    this.AGS_Form.GetChild(3).gameObject.SetActive(true);
    this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
    this.AGS_Form.GetChild(3).GetChild(1).gameObject.SetActive(false);
    Transform child = this.AGS_Form.GetChild(3).GetChild(0);
    child.gameObject.SetActive(true);
    GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, LeaderBoardManager.Instance.KingofWorldHead, (byte) 11, (byte) 0);
    UIText component1 = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
    this.Ranking.ClearString();
    this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(11010U));
    component1.text = this.Ranking.ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    UIText component2 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
    this.RankValue.ClearString();
    if (LeaderBoardManager.Instance.KingofWorldBoard.Count > 0)
      GameConstants.GetNameString(this.RankValue, LeaderBoardManager.Instance.KingofWorldBoard[0].HomeKingdomID, LeaderBoardManager.Instance.KingofWorldBoard[0].Name, LeaderBoardManager.Instance.KingofWorldBoard[0].AllianceTag, true);
    component2.text = this.RankValue.ToString();
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
  }

  private static int AlliInterPowerSort(AllianceBoardData x, AllianceBoardData y)
  {
    if (x.Power > y.Power)
      return -1;
    return x.Power < y.Power ? 1 : 0;
  }

  public void UpdatRow_Alli(GameObject item, int dataIdx, int panelObjectIdx)
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
      component2.text = DataManager.Instance.mStringTable.GetStringByID(7063U);
      component2.SetAllDirty();
      component2.cachedTextGenerator.Invalidate();
      UIText component3 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
      component3.text = DataManager.Instance.mStringTable.GetStringByID(7064U);
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
      this.SortTextArray[1, panelObjectIdx].Append(UILeaderBoard.SortedAlliInterList[dataIdx].Name);
      UIText component5 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
      component5.text = this.SortTextArray[1, panelObjectIdx].ToString();
      component5.SetAllDirty();
      component5.cachedTextGenerator.Invalidate();
      this.SortTextArray[2, panelObjectIdx].ClearString();
      this.SortTextArray[2, panelObjectIdx].uLongToFormat(UILeaderBoard.SortedAlliInterList[dataIdx].Power, bNumber: true);
      this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
      UIText component6 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
      component6.text = this.SortTextArray[2, panelObjectIdx].ToString();
      component6.SetAllDirty();
      component6.cachedTextGenerator.Invalidate();
      UIButton component7 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
      component7.m_Handler = (IUIButtonClickHandler) this;
      component7.m_BtnID1 = 1;
      component7.m_BtnID2 = dataIdx;
      if (dataIdx == (int) this.MyRank)
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

  public void UpdatRow_MobiGroup(GameObject item, int dataIdx, int panelObjectIdx)
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
      component2.text = DataManager.Instance.mStringTable.GetStringByID(1364U);
      component2.SetAllDirty();
      component2.cachedTextGenerator.Invalidate();
      UIText component3 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
      component3.text = DataManager.Instance.mStringTable.GetStringByID(4612U);
      component3.SetAllDirty();
      component3.cachedTextGenerator.Invalidate();
      UIText component4 = item.transform.GetChild(0).GetChild(7).GetComponent<UIText>();
      ((Component) component4).gameObject.SetActive(true);
      component4.text = DataManager.Instance.mStringTable.GetStringByID(9857U);
      component4.SetAllDirty();
      component4.cachedTextGenerator.Invalidate();
    }
    else
    {
      item.transform.GetChild(0).gameObject.SetActive(false);
      item.transform.GetChild(1).gameObject.SetActive(true);
      item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
      this.SortTextArray[0, panelObjectIdx].ClearString();
      this.SortTextArray[0, panelObjectIdx].IntToFormat((long) dataIdx);
      this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
      UIText component5 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
      component5.text = this.SortTextArray[0, panelObjectIdx].ToString();
      component5.SetAllDirty();
      component5.cachedTextGenerator.Invalidate();
      this.SortTextArray[1, panelObjectIdx].ClearString();
      GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], (ushort) 0, LeaderBoardManager.Instance.MobiGroupBoard[dataIdx - 1].Name, LeaderBoardManager.Instance.MobiGroupBoard[dataIdx - 1].AllianceTag);
      UIText component6 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
      component6.text = this.SortTextArray[1, panelObjectIdx].ToString();
      component6.SetAllDirty();
      component6.cachedTextGenerator.Invalidate();
      this.SortTextArray[2, panelObjectIdx].ClearString();
      this.SortTextArray[2, panelObjectIdx].uLongToFormat((ulong) LeaderBoardManager.Instance.MobiGroupBoard[dataIdx - 1].Score, bNumber: true);
      this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
      UIText component7 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
      component7.text = this.SortTextArray[2, panelObjectIdx].ToString();
      component7.SetAllDirty();
      component7.cachedTextGenerator.Invalidate();
      UIButton component8 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
      component8.m_Handler = (IUIButtonClickHandler) this;
      component8.m_BtnID1 = 6;
      component8.m_BtnID2 = dataIdx - 1;
      this.SortTextArray[3, panelObjectIdx].ClearString();
      this.SortTextArray[3, panelObjectIdx].IntToFormat((long) Math.Abs(LeaderBoardManager.Instance.MobiGroupBoard[dataIdx - 1].ChangeRank), bNumber: true);
      this.SortTextArray[3, panelObjectIdx].AppendFormat("{0}");
      UIText component9 = item.transform.GetChild(1).GetChild(9).GetComponent<UIText>();
      component9.text = this.SortTextArray[3, panelObjectIdx].ToString();
      component9.SetAllDirty();
      component9.cachedTextGenerator.Invalidate();
      UISpritesArray component10 = item.transform.GetChild(1).GetChild(8).GetComponent<UISpritesArray>();
      if (LeaderBoardManager.Instance.MobiGroupBoard[dataIdx - 1].ChangeRank > 0)
      {
        component10.SetSpriteIndex(0);
        component10.gameObject.SetActive(true);
        ((Component) component9).gameObject.SetActive(true);
      }
      else if (LeaderBoardManager.Instance.MobiGroupBoard[dataIdx - 1].ChangeRank < 0)
      {
        component10.SetSpriteIndex(1);
        component10.gameObject.SetActive(true);
        ((Component) component9).gameObject.SetActive(true);
      }
      else
      {
        component10.gameObject.SetActive(false);
        ((Component) component9).gameObject.SetActive(false);
      }
      if (dataIdx == LeaderBoardManager.Instance.MobiGroupRank)
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
      UIButton component11 = item.transform.GetChild(1).GetChild(12).GetComponent<UIButton>();
      component11.m_Handler = (IUIButtonClickHandler) this;
      component11.m_BtnID1 = 11;
      component11.m_BtnID2 = dataIdx;
      UIText component12 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
      if (dataIdx < 6 && DataManager.Instance.RoleAlliance.AMRank != (byte) 3)
      {
        component11.m_BtnID3 = 1;
        ((Graphic) component12).color = (Color) new Color32(byte.MaxValue, byte.MaxValue, (byte) 0, byte.MaxValue);
      }
      else if (dataIdx > 15 && DataManager.Instance.RoleAlliance.AMRank != (byte) 0)
      {
        component11.m_BtnID3 = 2;
        ((Graphic) component12).color = (Color) new Color32((byte) 0, byte.MaxValue, byte.MaxValue, byte.MaxValue);
      }
      else
      {
        component11.m_BtnID3 = 3;
        ((Graphic) component12).color = (Color) new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);
      }
      UIButtonHint component13 = item.transform.GetChild(1).GetChild(12).GetComponent<UIButtonHint>();
      component13.Parm1 = (ushort) dataIdx;
      component13.m_eHint = EUIButtonHint.DownUpHandler;
      component13.m_Handler = (MonoBehaviour) this;
      component13.ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
    }
  }

  public void UpdatRow_MobiAlli(GameObject item, int dataIdx, int panelObjectIdx)
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
      UIText component4 = item.transform.GetChild(0).GetChild(7).GetComponent<UIText>();
      ((Component) component4).gameObject.SetActive(true);
      component4.text = DataManager.Instance.mStringTable.GetStringByID(1363U);
      component4.SetAllDirty();
      component4.cachedTextGenerator.Invalidate();
    }
    else
    {
      item.transform.GetChild(0).gameObject.SetActive(false);
      item.transform.GetChild(1).gameObject.SetActive(true);
      item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
      this.SortTextArray[0, panelObjectIdx].ClearString();
      this.SortTextArray[0, panelObjectIdx].IntToFormat((long) dataIdx);
      this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
      UIText component5 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
      component5.text = this.SortTextArray[0, panelObjectIdx].ToString();
      component5.SetAllDirty();
      component5.cachedTextGenerator.Invalidate();
      this.SortTextArray[1, panelObjectIdx].ClearString();
      this.SortTextArray[1, panelObjectIdx].Append(LeaderBoardManager.Instance.MobiAlliBoard[dataIdx - 1].Name);
      UIText component6 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
      component6.text = this.SortTextArray[1, panelObjectIdx].ToString();
      component6.SetAllDirty();
      component6.cachedTextGenerator.Invalidate();
      this.SortTextArray[2, panelObjectIdx].ClearString();
      this.SortTextArray[2, panelObjectIdx].uLongToFormat((ulong) LeaderBoardManager.Instance.MobiAlliBoard[dataIdx - 1].Score, bNumber: true);
      this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
      UIText component7 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
      component7.text = this.SortTextArray[2, panelObjectIdx].ToString();
      component7.alignment = TextAnchor.MiddleCenter;
      component7.SetAllDirty();
      component7.cachedTextGenerator.Invalidate();
      this.SortTextArray[3, panelObjectIdx].ClearString();
      this.SortTextArray[3, panelObjectIdx].IntToFormat((long) Math.Abs((short) LeaderBoardManager.Instance.MobiAlliBoard[dataIdx - 1].FinishedMission), bNumber: true);
      this.SortTextArray[3, panelObjectIdx].IntToFormat((long) Math.Abs((short) LeaderBoardManager.Instance.MobiAlliBoard[dataIdx - 1].AquiredMission), bNumber: true);
      if (!GUIManager.Instance.IsArabic)
        this.SortTextArray[3, panelObjectIdx].AppendFormat("{0} / {1}");
      else
        this.SortTextArray[3, panelObjectIdx].AppendFormat("{1} / {0}");
      UIText component8 = item.transform.GetChild(1).GetChild(7).GetComponent<UIText>();
      component8.text = this.SortTextArray[3, panelObjectIdx].ToString();
      component8.alignment = TextAnchor.MiddleCenter;
      component8.SetAllDirty();
      component8.cachedTextGenerator.Invalidate();
      if (dataIdx == LeaderBoardManager.Instance.MobiAlliRank)
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
    }
  }

  public void UpdatRow_MobilizationWorldKing(GameObject item, int dataIdx, int panelObjectIdx)
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

  public void UpdatRow_KingofWorld(GameObject item, int dataIdx, int panelObjectIdx)
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
      GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.KingofWorldBoard[dataIdx - 1].HomeKingdomID, LeaderBoardManager.Instance.KingofWorldBoard[dataIdx - 1].Name, LeaderBoardManager.Instance.KingofWorldBoard[dataIdx - 1].AllianceTag, true);
      UIText component5 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
      component5.text = this.SortTextArray[1, panelObjectIdx].ToString();
      component5.SetAllDirty();
      component5.cachedTextGenerator.Invalidate();
      this.SortTextArray[2, panelObjectIdx].ClearString();
      GameConstants.GetTimeString(this.SortTextArray[2, panelObjectIdx], LeaderBoardManager.Instance.KingofWorldBoard[dataIdx - 1].OccupyTime);
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

  public void CreateTopBoard()
  {
    this.SPHeight.Clear();
    this.SPHeight.Add(118f);
    this.SPHeight.Add(118f);
    this.AGS_Form.GetChild(3).gameObject.SetActive(false);
    GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0);
    if (this.OpenKind != UI_LeaderBoardOpenKind.BoardMenu)
    {
      this.AGS_Form.GetChild(12).gameObject.SetActive(false);
    }
    else
    {
      this.AGS_Form.GetChild(12).gameObject.SetActive(true);
      this.AGS_Form.GetChild(12).GetComponent<UISpritesArray>().SetSpriteIndex(0);
    }
    UILeaderBoard.isTopBoard = true;
    if (UILeaderBoard.isPersonBoard)
    {
      this.SPHeight.Add(118f);
      this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7089U);
      this.AGS_Form.GetChild(2).gameObject.SetActive(true);
      this.AGS_Form.GetChild(5).gameObject.SetActive(true);
      UIText component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
      component.text = DataManager.Instance.mStringTable.GetStringByID(7090U);
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
      ((Component) this.POPLight1).gameObject.SetActive(true);
      ((Component) this.POPLight3).gameObject.SetActive(false);
    }
    else
    {
      this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7091U);
      this.AGS_Form.GetChild(2).gameObject.SetActive(true);
      this.AGS_Form.GetChild(5).gameObject.SetActive(true);
      UIText component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
      component.text = DataManager.Instance.mStringTable.GetStringByID(7090U);
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
      ((Component) this.POPLight1).gameObject.SetActive(false);
      ((Component) this.POPLight3).gameObject.SetActive(true);
    }
  }

  public void CreateSubBoard()
  {
    this.AGS_Form.GetChild(5).gameObject.SetActive(false);
    this.AGS_Form.GetChild(12).gameObject.SetActive(false);
    this.SPHeight.Clear();
    this.SPHeight.Add(38f);
    if (UILeaderBoard.SubBoardID == (byte) 4)
    {
      for (int index = 0; index < LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID].Count; ++index)
        this.SPHeight.Add(53f);
    }
    else
    {
      for (int index = 0; index < LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID].Count; ++index)
      {
        if (LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][index].Value > 0UL)
          this.SPHeight.Add(53f);
      }
    }
    this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = !UILeaderBoard.isPersonBoard ? DataManager.Instance.mStringTable.GetStringByID(7091U) : DataManager.Instance.mStringTable.GetStringByID(7089U);
    this.AGS_Form.GetChild(3).gameObject.SetActive(true);
    if (UILeaderBoard.isPersonBoard)
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
    if (UILeaderBoard.isPersonBoard)
    {
      this.Ranking.ClearString();
      UIText component;
      if (LeaderBoardManager.Instance.MyRank[(int) UILeaderBoard.SubBoardID] != (ushort) 0)
      {
        component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
        this.Ranking.IntToFormat((long) LeaderBoardManager.Instance.MyRank[(int) UILeaderBoard.SubBoardID], bNumber: true);
        this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7060U));
      }
      else if (UILeaderBoard.SubBoardID == (byte) 4 && ArenaManager.Instance.m_ArenaHistoryPlace != 0U)
      {
        component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
        this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8414U));
      }
      else
      {
        this.AGS_Form.GetChild(3).gameObject.SetActive(false);
        this.AGS_Form.GetChild(5).gameObject.SetActive(true);
        component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
        this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8414U));
      }
      component.text = this.Ranking.ToString();
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
    }
    else if (DataManager.Instance.RoleAlliance.Id != 0U)
    {
      this.AGS_Form.GetChild(3).gameObject.SetActive(false);
      this.AGS_Form.GetChild(5).gameObject.SetActive(true);
      UIText component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
      this.Ranking.ClearString();
      if (LeaderBoardManager.Instance.MyRank[(int) UILeaderBoard.SubBoardID] != (ushort) 0)
      {
        this.Ranking.IntToFormat((long) LeaderBoardManager.Instance.MyRank[(int) UILeaderBoard.SubBoardID]);
        this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7092U));
      }
      else
        this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8414U));
      component.text = this.Ranking.ToString();
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.AGS_Form.GetChild(3).gameObject.SetActive(false);
      this.AGS_Form.GetChild(5).gameObject.SetActive(true);
      this.AGS_Form.GetChild(5).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7095U);
    }
    switch (UILeaderBoard.SubBoardID)
    {
      case 0:
        UIText component1 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
        this.RankValue.ClearString();
        this.RankValue.uLongToFormat(DataManager.Instance.RoleAttr.Power, bNumber: true);
        this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7061U));
        component1.text = this.RankValue.ToString();
        component1.SetAllDirty();
        component1.cachedTextGenerator.Invalidate();
        break;
      case 1:
        UIText component2 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
        this.RankValue.ClearString();
        this.RankValue.uLongToFormat(DataManager.Instance.RoleAttr.Kills, bNumber: true);
        this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8415U));
        component2.text = this.RankValue.ToString();
        component2.SetAllDirty();
        component2.cachedTextGenerator.Invalidate();
        break;
      case 4:
        UIText component3 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
        this.RankValue.ClearString();
        this.RankValue.Append(DataManager.Instance.mStringTable.GetStringByID(9126U));
        this.RankValue.uLongToFormat((ulong) ArenaManager.Instance.m_ArenaHistoryPlace, bNumber: true);
        this.RankValue.AppendFormat("{0}");
        component3.text = this.RankValue.ToString();
        component3.SetAllDirty();
        component3.cachedTextGenerator.Invalidate();
        break;
      case 7:
        if (LeaderBoardManager.Instance.MyRank[(int) UILeaderBoard.SubBoardID] != (ushort) 0)
        {
          UIText component4 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
          this.RankValue.ClearString();
          this.RankValue.uLongToFormat(LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][(int) LeaderBoardManager.Instance.MyRank[(int) UILeaderBoard.SubBoardID] - 1].Value, bNumber: true);
          this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8121U));
          component4.text = this.RankValue.ToString();
          component4.SetAllDirty();
          component4.cachedTextGenerator.Invalidate();
          break;
        }
        break;
    }
    if (UILeaderBoard.isPersonBoard)
    {
      ((Component) this.POPLight1).gameObject.SetActive(true);
      ((Component) this.POPLight3).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.POPLight1).gameObject.SetActive(false);
      ((Component) this.POPLight3).gameObject.SetActive(true);
    }
  }

  public void CreateWorldRankingTopBoard()
  {
    this.SPHeight.Clear();
    this.SPHeight.Add(118f);
    this.SPHeight.Add(118f);
    this.AGS_Form.GetChild(3).gameObject.SetActive(false);
    this.AGS_Form.GetChild(12).gameObject.SetActive(true);
    this.AGS_Form.GetChild(12).GetComponent<UISpritesArray>().SetSpriteIndex(1);
    UILeaderBoard.isTopBoard = true;
    if (UILeaderBoard.isPersonBoard)
    {
      this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9581U);
      this.AGS_Form.GetChild(2).gameObject.SetActive(true);
      this.AGS_Form.GetChild(5).gameObject.SetActive(true);
      UIText component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
      component.text = DataManager.Instance.mStringTable.GetStringByID(9574U);
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
      ((Component) this.POPLight1).gameObject.SetActive(true);
      ((Component) this.POPLight3).gameObject.SetActive(false);
    }
    else
    {
      this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9582U);
      this.AGS_Form.GetChild(2).gameObject.SetActive(true);
      this.AGS_Form.GetChild(5).gameObject.SetActive(true);
      UIText component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
      component.text = DataManager.Instance.mStringTable.GetStringByID(9574U);
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
      ((Component) this.POPLight1).gameObject.SetActive(false);
      ((Component) this.POPLight3).gameObject.SetActive(true);
    }
  }

  public void CreateWorldRankingSubBoard()
  {
    this.AGS_Form.GetChild(5).gameObject.SetActive(false);
    this.AGS_Form.GetChild(12).gameObject.SetActive(false);
    this.SPHeight.Clear();
    this.SPHeight.Add(38f);
    for (int index = 0; index < LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID].Count; ++index)
    {
      if (LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][index].Value > 0UL)
        this.SPHeight.Add(53f);
    }
    this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = !UILeaderBoard.isPersonBoard ? DataManager.Instance.mStringTable.GetStringByID(9582U) : DataManager.Instance.mStringTable.GetStringByID(9581U);
    this.AGS_Form.GetChild(3).gameObject.SetActive(true);
    if (UILeaderBoard.isPersonBoard)
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
    if (UILeaderBoard.isPersonBoard)
    {
      this.Ranking.ClearString();
      UIText component;
      if (LeaderBoardManager.Instance.MyRank[(int) UILeaderBoard.SubBoardID] != (ushort) 0)
      {
        component = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
        this.Ranking.IntToFormat((long) LeaderBoardManager.Instance.MyRank[(int) UILeaderBoard.SubBoardID], bNumber: true);
        this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7060U));
      }
      else
      {
        this.AGS_Form.GetChild(3).gameObject.SetActive(false);
        this.AGS_Form.GetChild(5).gameObject.SetActive(true);
        component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
        this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8414U));
      }
      component.text = this.Ranking.ToString();
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
    }
    else if (DataManager.Instance.RoleAlliance.Id != 0U)
    {
      this.AGS_Form.GetChild(3).gameObject.SetActive(false);
      this.AGS_Form.GetChild(5).gameObject.SetActive(true);
      UIText component = this.AGS_Form.GetChild(5).GetComponent<UIText>();
      this.Ranking.ClearString();
      if (LeaderBoardManager.Instance.MyRank[(int) UILeaderBoard.SubBoardID] != (ushort) 0)
      {
        this.Ranking.IntToFormat((long) LeaderBoardManager.Instance.MyRank[(int) UILeaderBoard.SubBoardID]);
        this.Ranking.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7092U));
      }
      else
        this.Ranking.Append(DataManager.Instance.mStringTable.GetStringByID(8414U));
      component.text = this.Ranking.ToString();
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.AGS_Form.GetChild(3).gameObject.SetActive(false);
      this.AGS_Form.GetChild(5).gameObject.SetActive(true);
      this.AGS_Form.GetChild(5).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7095U);
    }
    switch (UILeaderBoard.SubBoardID)
    {
      case 8:
        UIText component1 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
        this.RankValue.ClearString();
        this.RankValue.uLongToFormat(DataManager.Instance.RoleAttr.Power, bNumber: true);
        this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(7061U));
        component1.text = this.RankValue.ToString();
        component1.SetAllDirty();
        component1.cachedTextGenerator.Invalidate();
        break;
      case 9:
        UIText component2 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
        this.RankValue.ClearString();
        this.RankValue.uLongToFormat(DataManager.Instance.RoleAttr.Kills, bNumber: true);
        this.RankValue.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8415U));
        component2.text = this.RankValue.ToString();
        component2.SetAllDirty();
        component2.cachedTextGenerator.Invalidate();
        break;
    }
    if (UILeaderBoard.isPersonBoard)
    {
      ((Component) this.POPLight1).gameObject.SetActive(true);
      ((Component) this.POPLight3).gameObject.SetActive(false);
    }
    else
    {
      ((Component) this.POPLight1).gameObject.SetActive(false);
      ((Component) this.POPLight3).gameObject.SetActive(true);
    }
  }

  private void MainBoardChange()
  {
    if (this.OpenKind == UI_LeaderBoardOpenKind.BoardMenu && LeaderBoardManager.Instance.TopBoard.SortTime + 600L < DataManager.Instance.ServerTime)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_LEADERBOARDS_CLIENT;
      messagePacket.AddSeqId();
      messagePacket.Send();
      UILeaderBoard.isTopBoard = true;
    }
    else
    {
      this.CreateTopBoard();
      this.SetOpenType(UILeaderBoard.e_OpenType.BoardTypes);
      this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false);
      this.AGS_Panel1.GoTo(0);
    }
  }

  private void SubBoardChange(byte newSubID)
  {
    UILeaderBoard.SubBoardID = newSubID;
    UILeaderBoard.isTopBoard = false;
    if (UILeaderBoard.SubBoardID < (byte) 5 && LeaderBoardManager.Instance.BoardUpdateTime[(int) UILeaderBoard.SubBoardID] + 600L < DataManager.Instance.ServerTime)
    {
      UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID] = 0;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.AddSeqId();
      messagePacket.Protocol = Protocol._MSG_REQUEST_LEADERBOARD_CONTENT;
      ushort zoneID;
      byte pointID;
      GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out zoneID, out pointID);
      messagePacket.Add(zoneID);
      messagePacket.Add(pointID);
      messagePacket.Add(UILeaderBoard.SubBoardID);
      byte data1 = 0;
      messagePacket.Add(data1);
      long data2 = 0;
      messagePacket.Add(data2);
      messagePacket.Send();
    }
    else if (UILeaderBoard.SubBoardID >= (byte) 5 && LeaderBoardManager.Instance.BoardUpdateTime[(int) UILeaderBoard.SubBoardID] < DataManager.Instance.ServerTime)
    {
      UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID] = 0;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.AddSeqId();
      messagePacket.Protocol = Protocol._MSG_REQUEST_LEADERBOARD_CONTENT;
      ushort zoneID;
      byte pointID;
      GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out zoneID, out pointID);
      messagePacket.Add(zoneID);
      messagePacket.Add(pointID);
      messagePacket.Add(UILeaderBoard.SubBoardID);
      byte data = 0;
      messagePacket.Add(data);
      messagePacket.Add(LeaderBoardManager.Instance.KvKTopBoard.SortTime);
      if (UILeaderBoard.SubBoardID == (byte) 6)
        messagePacket.Add(DataManager.Instance.RoleAlliance.Id);
      messagePacket.Send();
    }
    else
    {
      this.CreateSubBoard();
      this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
      this.AGS_Panel2.AddNewDataHeight(this.SPHeight);
      this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID]);
    }
  }

  private void WorldRankingMainBoardChange()
  {
    if (UILeaderBoard.WorldBoard && LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.SortTime + 600L < DataManager.Instance.ServerTime)
    {
      UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID] = 0;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_WORLDRANKING_LEADERBOARDS_CLIENT;
      messagePacket.AddSeqId();
      messagePacket.Send();
      UILeaderBoard.isTopBoard = true;
    }
    else
    {
      this.CreateWorldRankingTopBoard();
      this.SetOpenType(UILeaderBoard.e_OpenType.BoardTypes);
      this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false);
      this.AGS_Panel1.GoTo(UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID]);
    }
  }

  private void WorldRankingSubBoardChange(byte newSubID)
  {
    UILeaderBoard.SubBoardID = newSubID;
    UILeaderBoard.isTopBoard = false;
    if (LeaderBoardManager.Instance.BoardUpdateTime[(int) UILeaderBoard.SubBoardID] + 600L < DataManager.Instance.ServerTime)
    {
      UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID] = 0;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.AddSeqId();
      messagePacket.Protocol = Protocol._MSG_REQUEST_LEADERBOARD_CONTENT;
      ushort zoneID;
      byte pointID;
      GameConstants.MapIDToPointCode(DataManager.Instance.RoleAttr.CapitalPoint, out zoneID, out pointID);
      messagePacket.Add(zoneID);
      messagePacket.Add(pointID);
      messagePacket.Add(UILeaderBoard.SubBoardID);
      byte data1 = 0;
      messagePacket.Add(data1);
      long data2 = 0;
      messagePacket.Add(data2);
      messagePacket.Send();
    }
    else
    {
      this.CreateWorldRankingSubBoard();
      this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
      this.AGS_Panel2.AddNewDataHeight(this.SPHeight);
      this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID]);
    }
  }

  public void UpdateRow_FunctionList(GameObject item, int dataIdx, int panelObjectIdx)
  {
    if (UILeaderBoard.isPersonBoard)
    {
      switch (dataIdx)
      {
        case 0:
          item.transform.GetChild(2).gameObject.SetActive(false);
          item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.TopBoard.PowerTop.Value != 0UL);
          if (item.transform.GetChild(3).childCount < 1)
            GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.TopBoard.PowerTopHead, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
          else
            GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.TopBoard.PowerTopHead, (byte) 11, (byte) 0);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7064U);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.TopBoard.PowerTop.Value == 0UL)
            this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475U));
          else
            GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], (ushort) 0, LeaderBoardManager.Instance.TopBoard.PowerTop.Name, LeaderBoardManager.Instance.TopBoard.PowerTop.AlliaceTag);
          UIText component1 = item.transform.GetChild(5).GetComponent<UIText>();
          component1.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component1.SetAllDirty();
          component1.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.TopBoard.PowerTop.Value, bNumber: true);
          this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
          UIText component2 = item.transform.GetChild(6).GetComponent<UIText>();
          component2.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component2.SetAllDirty();
          component2.cachedTextGenerator.Invalidate();
          UIButton component3 = item.transform.GetChild(1).GetComponent<UIButton>();
          component3.m_Handler = (IUIButtonClickHandler) this;
          component3.m_BtnID1 = 3;
          component3.m_BtnID2 = 0;
          break;
        case 1:
          item.transform.GetChild(2).gameObject.SetActive(false);
          item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.TopBoard.KillsTop.Value != 0UL);
          if (item.transform.GetChild(3).childCount < 1)
            GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.TopBoard.KillTopHead, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
          else
            GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.TopBoard.KillTopHead, (byte) 11, (byte) 0);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7312U);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.TopBoard.KillsTop.Value == 0UL)
            this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475U));
          else
            GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], (ushort) 0, LeaderBoardManager.Instance.TopBoard.KillsTop.Name, LeaderBoardManager.Instance.TopBoard.KillsTop.AlliaceTag);
          UIText component4 = item.transform.GetChild(5).GetComponent<UIText>();
          component4.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component4.SetAllDirty();
          component4.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.TopBoard.KillsTop.Value, bNumber: true);
          this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
          UIText component5 = item.transform.GetChild(6).GetComponent<UIText>();
          component5.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component5.SetAllDirty();
          component5.cachedTextGenerator.Invalidate();
          UIButton component6 = item.transform.GetChild(1).GetComponent<UIButton>();
          component6.m_Handler = (IUIButtonClickHandler) this;
          component6.m_BtnID1 = 3;
          component6.m_BtnID2 = 1;
          break;
        case 2:
          item.transform.GetChild(2).gameObject.SetActive(false);
          item.transform.GetChild(3).gameObject.SetActive(true);
          if (item.transform.GetChild(3).childCount < 1)
            GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.TopBoard.ArenaTopHead, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
          else
            GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.TopBoard.ArenaTopHead, (byte) 11, (byte) 0);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(9125U);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          switch (LeaderBoardManager.isOpenArena())
          {
            case 0:
              GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], (ushort) 0, LeaderBoardManager.Instance.TopBoard.ArenaTop.Name, LeaderBoardManager.Instance.TopBoard.ArenaTop.AlliaceTag);
              break;
            case 1:
              this.SortTextArray[1, panelObjectIdx].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(977U));
              this.SortTextArray[1, panelObjectIdx].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9584U));
              item.transform.GetChild(3).gameObject.SetActive(false);
              break;
            case 2:
              this.SortTextArray[1, panelObjectIdx].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(10003U));
              this.SortTextArray[1, panelObjectIdx].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9584U));
              item.transform.GetChild(3).gameObject.SetActive(false);
              break;
            case 3:
              this.SortTextArray[1, panelObjectIdx].StringToFormat(DataManager.Instance.mStringTable.GetStringByID(11095U));
              this.SortTextArray[1, panelObjectIdx].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9584U));
              item.transform.GetChild(3).gameObject.SetActive(false);
              break;
          }
          UIText component7 = item.transform.GetChild(5).GetComponent<UIText>();
          component7.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component7.SetAllDirty();
          component7.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          UIText component8 = item.transform.GetChild(6).GetComponent<UIText>();
          component8.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component8.SetAllDirty();
          component8.cachedTextGenerator.Invalidate();
          UIButton component9 = item.transform.GetChild(1).GetComponent<UIButton>();
          component9.m_Handler = (IUIButtonClickHandler) this;
          component9.m_BtnID1 = 3;
          component9.m_BtnID2 = 4;
          break;
      }
    }
    else
    {
      switch (dataIdx)
      {
        case 0:
          item.transform.GetChild(2).gameObject.SetActive(LeaderBoardManager.Instance.TopBoard.PowerTopEmblem != (ushort) 0);
          item.transform.GetChild(3).gameObject.SetActive(false);
          if (item.transform.GetChild(2).GetChild(0).childCount < 1)
            GUIManager.Instance.InitBadgeTotem(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.TopBoard.PowerTopEmblem);
          else
            GUIManager.Instance.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.TopBoard.PowerTopEmblem);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7064U);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.TopBoard.AlliPowerTop.Value == 0UL)
            this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8477U));
          else
            GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], (ushort) 0, LeaderBoardManager.Instance.TopBoard.AlliPowerTop.Name, LeaderBoardManager.Instance.TopBoard.AlliPowerTop.AlliaceTag);
          UIText component10 = item.transform.GetChild(5).GetComponent<UIText>();
          component10.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component10.SetAllDirty();
          component10.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.TopBoard.AlliPowerTop.Value, bNumber: true);
          this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
          UIText component11 = item.transform.GetChild(6).GetComponent<UIText>();
          component11.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component11.SetAllDirty();
          component11.cachedTextGenerator.Invalidate();
          UIButton component12 = item.transform.GetChild(1).GetComponent<UIButton>();
          component12.m_Handler = (IUIButtonClickHandler) this;
          component12.m_BtnID1 = 3;
          component12.m_BtnID2 = 2;
          break;
        case 1:
          item.transform.GetChild(2).gameObject.SetActive(LeaderBoardManager.Instance.TopBoard.KillsTopEmblem != (ushort) 0);
          item.transform.GetChild(3).gameObject.SetActive(false);
          if (item.transform.GetChild(2).GetChild(0).childCount < 1)
            GUIManager.Instance.InitBadgeTotem(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.TopBoard.KillsTopEmblem);
          else
            GUIManager.Instance.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.TopBoard.KillsTopEmblem);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7312U);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.TopBoard.AlliKillsTop.Value == 0UL)
            this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8477U));
          else
            GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], (ushort) 0, LeaderBoardManager.Instance.TopBoard.AlliKillsTop.Name, LeaderBoardManager.Instance.TopBoard.AlliKillsTop.AlliaceTag);
          UIText component13 = item.transform.GetChild(5).GetComponent<UIText>();
          component13.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component13.SetAllDirty();
          component13.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.TopBoard.AlliKillsTop.Value, bNumber: true);
          this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
          UIText component14 = item.transform.GetChild(6).GetComponent<UIText>();
          component14.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component14.SetAllDirty();
          component14.cachedTextGenerator.Invalidate();
          UIButton component15 = item.transform.GetChild(1).GetComponent<UIButton>();
          component15.m_Handler = (IUIButtonClickHandler) this;
          component15.m_BtnID1 = 3;
          component15.m_BtnID2 = 3;
          break;
      }
    }
  }

  public void UpdatRow_Boards(GameObject item, int dataIdx, int panelObjectIdx)
  {
    if (dataIdx == 0)
    {
      RectTransform component1 = item.transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
      if (UILeaderBoard.SubBoardID != (byte) 4)
      {
        item.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        component1.anchoredPosition = new Vector2((float) (UILeaderBoard.CommonBoardSize[0] + UILeaderBoard.CommonBoardSize[1]), component1.anchoredPosition.y);
        component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.CommonBoardSize[2]);
        RectTransform component2 = item.transform.GetChild(0).GetChild(5).GetComponent<RectTransform>();
        component2.anchoredPosition = new Vector2((float) (UILeaderBoard.CommonBoardSize[0] + UILeaderBoard.CommonBoardSize[1] / 2), component2.anchoredPosition.y);
      }
      else
      {
        item.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
        component1.anchoredPosition = new Vector2(102f, -3f);
        component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 674f);
        item.transform.GetChild(0).GetChild(5).GetComponent<RectTransform>().anchoredPosition = new Vector2(368f, -18f);
      }
      switch (UILeaderBoard.SubBoardID)
      {
        case 0:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component3 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component3.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component3.SetAllDirty();
          component3.cachedTextGenerator.Invalidate();
          UIText component4 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component4.text = DataManager.Instance.mStringTable.GetStringByID(7063U);
          component4.SetAllDirty();
          component4.cachedTextGenerator.Invalidate();
          UIText component5 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component5.text = DataManager.Instance.mStringTable.GetStringByID(7064U);
          component5.SetAllDirty();
          component5.cachedTextGenerator.Invalidate();
          break;
        case 1:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component6 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component6.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component6.SetAllDirty();
          component6.cachedTextGenerator.Invalidate();
          UIText component7 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component7.text = DataManager.Instance.mStringTable.GetStringByID(7063U);
          component7.SetAllDirty();
          component7.cachedTextGenerator.Invalidate();
          UIText component8 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component8.text = DataManager.Instance.mStringTable.GetStringByID(7312U);
          component8.SetAllDirty();
          component8.cachedTextGenerator.Invalidate();
          break;
        case 2:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component9 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component9.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component9.SetAllDirty();
          component9.cachedTextGenerator.Invalidate();
          UIText component10 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component10.text = DataManager.Instance.mStringTable.GetStringByID(7094U);
          component10.SetAllDirty();
          component10.cachedTextGenerator.Invalidate();
          UIText component11 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component11.text = DataManager.Instance.mStringTable.GetStringByID(7064U);
          component11.SetAllDirty();
          component11.cachedTextGenerator.Invalidate();
          break;
        case 3:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component12 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component12.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component12.SetAllDirty();
          component12.cachedTextGenerator.Invalidate();
          UIText component13 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component13.text = DataManager.Instance.mStringTable.GetStringByID(7094U);
          component13.SetAllDirty();
          component13.cachedTextGenerator.Invalidate();
          UIText component14 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component14.text = DataManager.Instance.mStringTable.GetStringByID(7312U);
          component14.SetAllDirty();
          component14.cachedTextGenerator.Invalidate();
          break;
        case 4:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component15 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component15.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component15.SetAllDirty();
          component15.cachedTextGenerator.Invalidate();
          UIText component16 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component16.text = DataManager.Instance.mStringTable.GetStringByID(7063U);
          component16.SetAllDirty();
          component16.cachedTextGenerator.Invalidate();
          UIText component17 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component17.text = string.Empty;
          component17.SetAllDirty();
          component17.cachedTextGenerator.Invalidate();
          break;
        case 5:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component18 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component18.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component18.SetAllDirty();
          component18.cachedTextGenerator.Invalidate();
          UIText component19 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component19.text = DataManager.Instance.mStringTable.GetStringByID(9850U);
          component19.SetAllDirty();
          component19.cachedTextGenerator.Invalidate();
          UIText component20 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component20.text = DataManager.Instance.mStringTable.GetStringByID(9851U);
          component20.SetAllDirty();
          component20.cachedTextGenerator.Invalidate();
          break;
        case 6:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component21 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component21.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component21.SetAllDirty();
          component21.cachedTextGenerator.Invalidate();
          UIText component22 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component22.text = DataManager.Instance.mStringTable.GetStringByID(7094U);
          component22.SetAllDirty();
          component22.cachedTextGenerator.Invalidate();
          UIText component23 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component23.text = DataManager.Instance.mStringTable.GetStringByID(9857U);
          component23.SetAllDirty();
          component23.cachedTextGenerator.Invalidate();
          break;
        case 7:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component24 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component24.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component24.SetAllDirty();
          component24.cachedTextGenerator.Invalidate();
          UIText component25 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component25.text = DataManager.Instance.mStringTable.GetStringByID(7063U);
          component25.SetAllDirty();
          component25.cachedTextGenerator.Invalidate();
          UIText component26 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component26.text = DataManager.Instance.mStringTable.GetStringByID(9858U);
          component26.SetAllDirty();
          component26.cachedTextGenerator.Invalidate();
          break;
      }
    }
    else
    {
      LeaderBoardManager.Instance.CheckNextPart(UILeaderBoard.SubBoardID, (byte) dataIdx);
      item.transform.GetChild(0).gameObject.SetActive(false);
      item.transform.GetChild(1).gameObject.SetActive(true);
      this.SortTextArray[0, panelObjectIdx].ClearString();
      this.SortTextArray[0, panelObjectIdx].IntToFormat((long) dataIdx);
      this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
      UIText component27 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
      component27.text = this.SortTextArray[0, panelObjectIdx].ToString();
      component27.SetAllDirty();
      component27.cachedTextGenerator.Invalidate();
      this.SortTextArray[1, panelObjectIdx].ClearString();
      GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], (ushort) 0, LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][dataIdx - 1].AlliaceTag);
      UIText component28 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
      component28.text = this.SortTextArray[1, panelObjectIdx].ToString();
      component28.SetAllDirty();
      component28.cachedTextGenerator.Invalidate();
      this.SortTextArray[2, panelObjectIdx].ClearString();
      RectTransform component29 = item.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
      if (UILeaderBoard.SubBoardID == (byte) 4)
      {
        component29.anchoredPosition = new Vector2(102f, 0.0f);
        component29.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 674f);
        UIButtonHint component30 = item.transform.GetChild(1).GetChild(11).GetComponent<UIButtonHint>();
        component30.Parm1 = (ushort) (dataIdx - 1);
        component30.m_eHint = EUIButtonHint.UIArena_Hint;
        component30.m_Handler = (MonoBehaviour) this;
        component30.ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
        UIButton component31 = item.transform.GetChild(1).GetChild(11).GetComponent<UIButton>();
        ((Component) component31).gameObject.SetActive(true);
        component31.m_Handler = (IUIButtonClickHandler) this;
        component31.m_BtnID1 = 5;
        component31.m_BtnID2 = dataIdx - 1;
        item.transform.GetChild(1).GetChild(1).gameObject.SetActive(false);
      }
      else
      {
        component29.anchoredPosition = new Vector2((float) (UILeaderBoard.CommonBoardSize[0] + UILeaderBoard.CommonBoardSize[1]), component29.anchoredPosition.y);
        component29.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.CommonBoardSize[2]);
        item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
        this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][dataIdx - 1].Value, bNumber: true);
        this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
      }
      UIText component32 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
      component32.text = this.SortTextArray[2, panelObjectIdx].ToString();
      component32.SetAllDirty();
      component32.cachedTextGenerator.Invalidate();
      if (UILeaderBoard.SubBoardID != (byte) 4)
      {
        UIButton component33 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
        component33.m_Handler = (IUIButtonClickHandler) this;
        component33.m_BtnID1 = 4;
        component33.m_BtnID2 = dataIdx - 1;
        ((Component) component33).gameObject.SetActive(true);
      }
      else
      {
        UIButton component34 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
        component34.m_Handler = (IUIButtonClickHandler) this;
        component34.m_BtnID1 = 4;
        component34.m_BtnID2 = dataIdx - 1;
        ((Component) component34).gameObject.SetActive(LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][dataIdx - 1].Value == 0UL);
      }
      if (dataIdx == (int) LeaderBoardManager.Instance.MyRank[(int) UILeaderBoard.SubBoardID])
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

  public void UpdateRow_WorldRanking_FunctionList(GameObject item, int dataIdx, int panelObjectIdx)
  {
    if (UILeaderBoard.isPersonBoard)
    {
      switch (dataIdx)
      {
        case 0:
          item.transform.GetChild(2).gameObject.SetActive(false);
          item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTop.Value != 0UL);
          if (item.transform.GetChild(3).childCount < 1)
            GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTopHead, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
          else
            GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTopHead, (byte) 11, (byte) 0);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7064U);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTop.Value == 0UL)
            this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475U));
          else
            GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTop.KingdomID, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTop.Name, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTop.AlliaceTag);
          UIText component1 = item.transform.GetChild(5).GetComponent<UIText>();
          component1.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component1.SetAllDirty();
          component1.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTop.Value, bNumber: true);
          this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
          UIText component2 = item.transform.GetChild(6).GetComponent<UIText>();
          component2.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component2.SetAllDirty();
          component2.cachedTextGenerator.Invalidate();
          UIButton component3 = item.transform.GetChild(1).GetComponent<UIButton>();
          component3.m_Handler = (IUIButtonClickHandler) this;
          component3.m_BtnID1 = 3;
          component3.m_BtnID2 = 8;
          break;
        case 1:
          item.transform.GetChild(2).gameObject.SetActive(false);
          item.transform.GetChild(3).gameObject.SetActive(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTop.Value != 0UL);
          if (item.transform.GetChild(3).childCount < 1)
            GUIManager.Instance.InitianHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTopHead, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
          else
            GUIManager.Instance.ChangeHeroItemImg(item.transform.GetChild(3), eHeroOrItem.Hero, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTopHead, (byte) 11, (byte) 0);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7312U);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTop.Value == 0UL)
            this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8475U));
          else
            GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTop.KingdomID, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTop.Name, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTop.AlliaceTag);
          UIText component4 = item.transform.GetChild(5).GetComponent<UIText>();
          component4.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component4.SetAllDirty();
          component4.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTop.Value, bNumber: true);
          this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
          UIText component5 = item.transform.GetChild(6).GetComponent<UIText>();
          component5.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component5.SetAllDirty();
          component5.cachedTextGenerator.Invalidate();
          UIButton component6 = item.transform.GetChild(1).GetComponent<UIButton>();
          component6.m_Handler = (IUIButtonClickHandler) this;
          component6.m_BtnID1 = 3;
          component6.m_BtnID2 = 9;
          break;
      }
    }
    else
    {
      switch (dataIdx)
      {
        case 0:
          item.transform.GetChild(2).gameObject.SetActive(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTopEmblem != (ushort) 0);
          item.transform.GetChild(3).gameObject.SetActive(false);
          if (item.transform.GetChild(2).GetChild(0).childCount < 1)
            GUIManager.Instance.InitBadgeTotem(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTopEmblem);
          else
            GUIManager.Instance.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.PowerTopEmblem);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7064U);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliPowerTop.Value == 0UL)
            this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8477U));
          else
            GameConstants.GetAllianceNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliPowerTop.KingdomID, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliPowerTop.Name, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliPowerTop.AlliaceTag);
          UIText component7 = item.transform.GetChild(5).GetComponent<UIText>();
          component7.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component7.SetAllDirty();
          component7.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliPowerTop.Value, bNumber: true);
          this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
          UIText component8 = item.transform.GetChild(6).GetComponent<UIText>();
          component8.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component8.SetAllDirty();
          component8.cachedTextGenerator.Invalidate();
          UIButton component9 = item.transform.GetChild(1).GetComponent<UIButton>();
          component9.m_Handler = (IUIButtonClickHandler) this;
          component9.m_BtnID1 = 3;
          component9.m_BtnID2 = 10;
          break;
        case 1:
          item.transform.GetChild(2).gameObject.SetActive(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTopEmblem != (ushort) 0);
          item.transform.GetChild(3).gameObject.SetActive(false);
          if (item.transform.GetChild(2).GetChild(0).childCount < 1)
            GUIManager.Instance.InitBadgeTotem(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTopEmblem);
          else
            GUIManager.Instance.SetBadgeTotemImg(item.transform.GetChild(2).GetChild(0), LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.KillsTopEmblem);
          item.transform.GetChild(4).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7312U);
          this.SortTextArray[1, panelObjectIdx].ClearString();
          if (LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliKillsTop.Value == 0UL)
            this.SortTextArray[1, panelObjectIdx].Append(DataManager.Instance.mStringTable.GetStringByID(8477U));
          else
            GameConstants.GetAllianceNameString(this.SortTextArray[1, panelObjectIdx], LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliKillsTop.KingdomID, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliKillsTop.Name, LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliKillsTop.AlliaceTag);
          UIText component10 = item.transform.GetChild(5).GetComponent<UIText>();
          component10.text = this.SortTextArray[1, panelObjectIdx].ToString();
          component10.SetAllDirty();
          component10.cachedTextGenerator.Invalidate();
          this.SortTextArray[2, panelObjectIdx].ClearString();
          this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.WorldLeaderBoardTopBoard.AlliKillsTop.Value, bNumber: true);
          this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
          UIText component11 = item.transform.GetChild(6).GetComponent<UIText>();
          component11.text = this.SortTextArray[2, panelObjectIdx].ToString();
          component11.SetAllDirty();
          component11.cachedTextGenerator.Invalidate();
          UIButton component12 = item.transform.GetChild(1).GetComponent<UIButton>();
          component12.m_Handler = (IUIButtonClickHandler) this;
          component12.m_BtnID1 = 3;
          component12.m_BtnID2 = 11;
          break;
      }
    }
  }

  public void UpdatRow_WorldRanking_Boards(GameObject item, int dataIdx, int panelObjectIdx)
  {
    if (dataIdx == 0)
    {
      RectTransform component1 = item.transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
      item.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
      component1.anchoredPosition = new Vector2((float) (UILeaderBoard.CommonBoardSize[0] + UILeaderBoard.CommonBoardSize[1]), component1.anchoredPosition.y);
      component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.CommonBoardSize[2]);
      RectTransform component2 = item.transform.GetChild(0).GetChild(5).GetComponent<RectTransform>();
      component2.anchoredPosition = new Vector2((float) (UILeaderBoard.CommonBoardSize[0] + UILeaderBoard.CommonBoardSize[1] / 2), component2.anchoredPosition.y);
      switch (UILeaderBoard.SubBoardID)
      {
        case 8:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component3 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component3.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component3.SetAllDirty();
          component3.cachedTextGenerator.Invalidate();
          UIText component4 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component4.text = DataManager.Instance.mStringTable.GetStringByID(7063U);
          component4.SetAllDirty();
          component4.cachedTextGenerator.Invalidate();
          UIText component5 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component5.text = DataManager.Instance.mStringTable.GetStringByID(7064U);
          component5.SetAllDirty();
          component5.cachedTextGenerator.Invalidate();
          break;
        case 9:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component6 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component6.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component6.SetAllDirty();
          component6.cachedTextGenerator.Invalidate();
          UIText component7 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component7.text = DataManager.Instance.mStringTable.GetStringByID(7063U);
          component7.SetAllDirty();
          component7.cachedTextGenerator.Invalidate();
          UIText component8 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component8.text = DataManager.Instance.mStringTable.GetStringByID(7312U);
          component8.SetAllDirty();
          component8.cachedTextGenerator.Invalidate();
          break;
        case 10:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component9 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component9.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component9.SetAllDirty();
          component9.cachedTextGenerator.Invalidate();
          UIText component10 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component10.text = DataManager.Instance.mStringTable.GetStringByID(7094U);
          component10.SetAllDirty();
          component10.cachedTextGenerator.Invalidate();
          UIText component11 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component11.text = DataManager.Instance.mStringTable.GetStringByID(7064U);
          component11.SetAllDirty();
          component11.cachedTextGenerator.Invalidate();
          break;
        case 11:
          item.transform.GetChild(0).gameObject.SetActive(true);
          item.transform.GetChild(1).gameObject.SetActive(false);
          UIText component12 = item.transform.GetChild(0).GetChild(4).GetComponent<UIText>();
          component12.text = DataManager.Instance.mStringTable.GetStringByID(7062U);
          component12.SetAllDirty();
          component12.cachedTextGenerator.Invalidate();
          UIText component13 = item.transform.GetChild(0).GetChild(5).GetComponent<UIText>();
          component13.text = DataManager.Instance.mStringTable.GetStringByID(7094U);
          component13.SetAllDirty();
          component13.cachedTextGenerator.Invalidate();
          UIText component14 = item.transform.GetChild(0).GetChild(6).GetComponent<UIText>();
          component14.text = DataManager.Instance.mStringTable.GetStringByID(7312U);
          component14.SetAllDirty();
          component14.cachedTextGenerator.Invalidate();
          break;
      }
    }
    else
    {
      LeaderBoardManager.Instance.CheckNextPart(UILeaderBoard.SubBoardID, (byte) dataIdx);
      item.transform.GetChild(0).gameObject.SetActive(false);
      item.transform.GetChild(1).gameObject.SetActive(true);
      this.SortTextArray[0, panelObjectIdx].ClearString();
      this.SortTextArray[0, panelObjectIdx].IntToFormat((long) dataIdx);
      this.SortTextArray[0, panelObjectIdx].AppendFormat("{0}");
      UIText component15 = item.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
      component15.text = this.SortTextArray[0, panelObjectIdx].ToString();
      component15.SetAllDirty();
      component15.cachedTextGenerator.Invalidate();
      this.SortTextArray[1, panelObjectIdx].ClearString();
      if (UILeaderBoard.isPersonBoard)
        GameConstants.GetNameString(this.SortTextArray[1, panelObjectIdx], ((WorldRankingBoardUnit) LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][dataIdx - 1]).KingdomID, LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][dataIdx - 1].AlliaceTag);
      else
        GameConstants.GetAllianceNameString(this.SortTextArray[1, panelObjectIdx], ((WorldRankingBoardUnitAlliance) LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][dataIdx - 1]).KingdomID, LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][dataIdx - 1].Name, LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][dataIdx - 1].AlliaceTag);
      UIText component16 = item.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
      component16.text = this.SortTextArray[1, panelObjectIdx].ToString();
      component16.SetAllDirty();
      component16.cachedTextGenerator.Invalidate();
      this.SortTextArray[2, panelObjectIdx].ClearString();
      RectTransform component17 = item.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
      component17.anchoredPosition = new Vector2((float) (UILeaderBoard.CommonBoardSize[0] + UILeaderBoard.CommonBoardSize[1]), component17.anchoredPosition.y);
      component17.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.CommonBoardSize[2]);
      item.transform.GetChild(1).GetChild(11).gameObject.SetActive(false);
      item.transform.GetChild(1).GetChild(12).gameObject.SetActive(false);
      item.transform.GetChild(1).GetChild(1).gameObject.SetActive(true);
      this.SortTextArray[2, panelObjectIdx].uLongToFormat(LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][dataIdx - 1].Value, bNumber: true);
      this.SortTextArray[2, panelObjectIdx].AppendFormat("{0}");
      UIText component18 = item.transform.GetChild(1).GetChild(6).GetComponent<UIText>();
      component18.text = this.SortTextArray[2, panelObjectIdx].ToString();
      component18.SetAllDirty();
      component18.cachedTextGenerator.Invalidate();
      UIButton component19 = item.transform.GetChild(1).GetChild(10).GetComponent<UIButton>();
      component19.m_Handler = (IUIButtonClickHandler) this;
      component19.m_BtnID1 = 4;
      component19.m_BtnID2 = dataIdx - 1;
      ((Component) component19).gameObject.SetActive(true);
      if (dataIdx == (int) LeaderBoardManager.Instance.MyRank[(int) UILeaderBoard.SubBoardID])
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

  public override void UpdateUI(int arg1, int arg2)
  {
    if ((byte) arg1 == (byte) 5)
      this.door.CloseMenu();
    switch (this.OpenKind)
    {
      case UI_LeaderBoardOpenKind.Alli_Inter:
        if ((byte) arg1 != (byte) 0)
          break;
        this.CreateAlliInterBoard();
        if (!this.LoadComplet)
        {
          this.DataReady = true;
          break;
        }
        this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
        this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
        this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[12]);
        break;
      case UI_LeaderBoardOpenKind.OtherAlli_inter:
        if ((byte) arg1 != (byte) 1)
          break;
        this.CreateOtherAlliInterBoard();
        if (!this.LoadComplet)
        {
          this.DataReady = true;
          break;
        }
        this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
        this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
        this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[12]);
        break;
      case UI_LeaderBoardOpenKind.BoardMenu:
        if (UILeaderBoard.WorldBoard)
        {
          switch ((byte) arg1)
          {
            case 2:
              if (!UILeaderBoard.isTopBoard)
                return;
              this.CreateWorldRankingTopBoard();
              if (!this.LoadComplet)
              {
                this.DataReady = true;
                return;
              }
              this.SetOpenType(UILeaderBoard.e_OpenType.BoardTypes);
              this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false);
              this.AGS_Panel1.GoTo(0);
              return;
            case 3:
              if (UILeaderBoard.isTopBoard || arg2 != (int) UILeaderBoard.SubBoardID)
                return;
              this.CreateWorldRankingSubBoard();
              this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
              this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
              return;
            case 4:
              if (UILeaderBoard.isTopBoard || arg2 != (int) UILeaderBoard.SubBoardID)
                return;
              UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID] = 0;
              this.CreateWorldRankingSubBoard();
              this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
              this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
              this.AGS_Panel2.GoTo(0);
              return;
            default:
              return;
          }
        }
        else
        {
          switch ((byte) arg1)
          {
            case 2:
              if (!UILeaderBoard.isTopBoard)
                return;
              this.CreateTopBoard();
              if (!this.LoadComplet)
              {
                this.DataReady = true;
                return;
              }
              this.SetOpenType(UILeaderBoard.e_OpenType.BoardTypes);
              this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false);
              this.AGS_Panel1.GoTo(0);
              return;
            case 3:
              if (UILeaderBoard.isTopBoard || arg2 != (int) UILeaderBoard.SubBoardID)
                return;
              this.CreateSubBoard();
              this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
              this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
              return;
            case 4:
              if (UILeaderBoard.isTopBoard || arg2 != (int) UILeaderBoard.SubBoardID)
                return;
              UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID] = 0;
              this.CreateSubBoard();
              this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
              this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
              this.AGS_Panel2.GoTo(0);
              return;
            default:
              return;
          }
        }
      case UI_LeaderBoardOpenKind.ArenaBoard:
        switch ((UI_LeaderBoardUpdateKind) arg1)
        {
          case UI_LeaderBoardUpdateKind.BoardData:
            if (arg2 != 4)
              return;
            this.CreateSubBoard();
            this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
            return;
          case UI_LeaderBoardUpdateKind.BoardDataReset:
            if (arg2 != 4)
              return;
            UILeaderBoard.TopIndex[4] = 0;
            this.CreateSubBoard();
            this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
            this.AGS_Panel2.GoTo(0);
            return;
          default:
            return;
        }
      case UI_LeaderBoardOpenKind.MobilizationGroupBoard:
        if ((byte) arg1 != (byte) 6)
          break;
        this.CreateMobilizationGroupBoard();
        if (!this.LoadComplet)
        {
          this.DataReady = true;
          break;
        }
        this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
        this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
        if (UILeaderBoard.TopIndex[13] == 0 && UILeaderBoard.NewOpen)
        {
          UILeaderBoard.NewOpen = false;
          if (LeaderBoardManager.Instance.MobiGroupRank > 4)
            UILeaderBoard.TopIndex[13] = LeaderBoardManager.Instance.MobiGroupRank - 3;
        }
        this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[13]);
        break;
      case UI_LeaderBoardOpenKind.MobilizationAlliBoard:
        if ((byte) arg1 != (byte) 7)
          break;
        this.CreateMobilizationAlliBoard();
        if (!this.LoadComplet)
        {
          this.DataReady = true;
          break;
        }
        this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
        this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
        if (UILeaderBoard.TopIndex[14] == 0 && UILeaderBoard.NewOpen)
        {
          UILeaderBoard.NewOpen = false;
          if (LeaderBoardManager.Instance.MobiAlliRank > 4)
            UILeaderBoard.TopIndex[14] = LeaderBoardManager.Instance.MobiAlliRank - 3;
        }
        this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[14]);
        break;
      case UI_LeaderBoardOpenKind.WorldKingHistory:
        if ((byte) arg1 != (byte) 9)
          break;
        switch (arg2)
        {
          case 0:
            this.CreateWorldKingHistoryBoard();
            if (!this.LoadComplet)
            {
              this.DataReady = true;
              return;
            }
            this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
            this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
            this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[15]);
            return;
          case 1:
            this.DataReady = false;
            LeaderBoardManager.Instance.Send_MSG_REQUEST_KINGOFTHEWORLD_HISTORYKINGDATA();
            return;
          default:
            return;
        }
      case UI_LeaderBoardOpenKind.KingofWorldRankingBoard:
        if ((byte) arg1 != (byte) 10)
          break;
        this.CreateKingofWorldRankingBoard();
        if (!this.LoadComplet)
        {
          this.DataReady = true;
          break;
        }
        this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
        this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
        this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[15]);
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        if ((UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_Chat) != (UnityEngine.Object) null)
        {
          this.door.CloseMenu_Alliance(EGUIWindow.UI_LeaderBoard);
          break;
        }
        this.door.CloseMenu();
        break;
      case NetworkNews.Refresh:
        if (this.OpenKind == UI_LeaderBoardOpenKind.WorldKingHistory)
        {
          this.DataReady = false;
          LeaderBoardManager.Instance.Send_MSG_REQUEST_KINGOFTHEWORLD_HISTORYKINGDATA();
        }
        if (DataManager.Instance.RoleAlliance.Id != 0U || this.OpenKind != UI_LeaderBoardOpenKind.Alli_Inter)
          break;
        this.door.CloseMenu_Alliance(EGUIWindow.UI_LeaderBoard);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Alliance)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.Refresh_FontTexture();
          break;
        }
        if (DataManager.Instance.RoleAlliance.Id != 0U || this.OpenKind != UI_LeaderBoardOpenKind.Alli_Inter)
          break;
        this.door.CloseMenu_Alliance(EGUIWindow.UI_LeaderBoard);
        break;
    }
  }

  public void Update()
  {
    if (!this.LoadComplet)
    {
      switch (this.OpenKind)
      {
        case UI_LeaderBoardOpenKind.MobilizationGroupBoard:
          RectTransform component1 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
          int num1 = UILeaderBoard.MobiGroupBoardSize[0];
          ((Component) component1).transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
          ((Component) component1).transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
          ((Component) component1).transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
          ((Component) component1).transform.GetChild(1).GetChild(9).gameObject.SetActive(true);
          RectTransform component2 = ((Transform) component1).GetChild(0).GetChild(5).GetComponent<RectTransform>();
          component2.anchoredPosition = new Vector2((float) (num1 + UILeaderBoard.MobiGroupBoardSize[1] / 2), component2.anchoredPosition.y);
          component2.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiGroupBoardSize[1]);
          ((Component) component1).transform.GetChild(0).GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiGroupBoardSize[1]);
          ((Component) component1).transform.GetChild(1).GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiGroupBoardSize[1]);
          int x1 = num1 + UILeaderBoard.MobiGroupBoardSize[1];
          RectTransform component3 = ((Component) component1).transform.GetChild(0).GetChild(6).GetComponent<RectTransform>();
          component3.anchoredPosition = new Vector2((float) (x1 + UILeaderBoard.MobiGroupBoardSize[2] / 2), component3.anchoredPosition.y);
          component3.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiGroupBoardSize[2]);
          RectTransform component4 = ((Component) component1).transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
          component4.anchoredPosition = new Vector2((float) x1, component4.anchoredPosition.y);
          component4.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiGroupBoardSize[2]);
          RectTransform component5 = ((Transform) component1).GetChild(1).GetChild(5).GetComponent<RectTransform>();
          component5.anchoredPosition = new Vector2((float) (x1 + 10), component5.anchoredPosition.y);
          component5.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) (UILeaderBoard.MobiGroupBoardSize[2] - 20));
          RectTransform component6 = ((Component) component1).transform.GetChild(1).GetChild(3).GetComponent<RectTransform>();
          component6.anchoredPosition = new Vector2((float) x1, component6.anchoredPosition.y);
          component6.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiGroupBoardSize[2]);
          ((Component) component6).gameObject.SetActive(true);
          int x2 = x1 + UILeaderBoard.MobiGroupBoardSize[2];
          RectTransform component7 = ((Component) component1).transform.GetChild(0).GetChild(7).GetComponent<RectTransform>();
          component7.anchoredPosition = new Vector2((float) (x2 + UILeaderBoard.MobiGroupBoardSize[3] / 2), component7.anchoredPosition.y);
          component7.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiGroupBoardSize[3]);
          RectTransform component8 = ((Component) component1).transform.GetChild(0).GetChild(3).GetComponent<RectTransform>();
          component8.anchoredPosition = new Vector2((float) x2, component8.anchoredPosition.y);
          component8.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiGroupBoardSize[3]);
          RectTransform component9 = ((Component) component1).transform.GetChild(1).GetChild(6).GetComponent<RectTransform>();
          component9.anchoredPosition = new Vector2((float) (x2 + 10), component9.anchoredPosition.y);
          component9.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) (UILeaderBoard.MobiGroupBoardSize[3] - 116));
          ((Component) component9).GetComponent<UIText>().alignment = TextAnchor.MiddleRight;
          RectTransform component10 = ((Component) component1).transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
          component10.anchoredPosition = new Vector2((float) x2, component10.anchoredPosition.y);
          component10.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiGroupBoardSize[3]);
          RectTransform component11 = ((Component) component1).transform.GetChild(1).GetChild(9).GetComponent<RectTransform>();
          component11.anchoredPosition = new Vector2(92.5f, component11.anchoredPosition.y);
          UIButton component12 = ((Component) component1).transform.GetChild(1).GetChild(12).GetComponent<UIButton>();
          component12.m_Handler = (IUIButtonClickHandler) this;
          ((Component) component12).gameObject.SetActive(true);
          UIButtonHint uiButtonHint = ((Component) component12).gameObject.AddComponent<UIButtonHint>();
          uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
          uiButtonHint.m_Handler = (MonoBehaviour) this;
          uiButtonHint.ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
          ((Component) component12).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiGroupBoardSize[1]);
          break;
        case UI_LeaderBoardOpenKind.MobilizationAlliBoard:
          RectTransform component13 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
          int num2 = UILeaderBoard.MobiAlliBoardSize[0];
          ((Component) component13).transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
          ((Component) component13).transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
          ((Component) component13).transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
          ((Component) component13).transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
          RectTransform component14 = ((Transform) component13).GetChild(0).GetChild(5).GetComponent<RectTransform>();
          component14.anchoredPosition = new Vector2((float) (num2 + UILeaderBoard.MobiAlliBoardSize[1] / 2), component14.anchoredPosition.y);
          component14.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiAlliBoardSize[1]);
          ((Component) component13).transform.GetChild(0).GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiAlliBoardSize[1]);
          ((Component) component13).transform.GetChild(1).GetChild(1).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiAlliBoardSize[1]);
          ((Transform) component13).GetChild(1).GetChild(5).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiAlliBoardSize[1]);
          int x3 = num2 + UILeaderBoard.MobiAlliBoardSize[1];
          RectTransform component15 = ((Component) component13).transform.GetChild(0).GetChild(6).GetComponent<RectTransform>();
          component15.anchoredPosition = new Vector2((float) (x3 + UILeaderBoard.MobiAlliBoardSize[2] / 2), component15.anchoredPosition.y);
          component15.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiAlliBoardSize[2]);
          RectTransform component16 = ((Component) component13).transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
          component16.anchoredPosition = new Vector2((float) x3, component16.anchoredPosition.y);
          component16.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiAlliBoardSize[2]);
          RectTransform component17 = ((Component) component13).transform.GetChild(1).GetChild(6).GetComponent<RectTransform>();
          component17.anchoredPosition = new Vector2((float) x3, component17.anchoredPosition.y);
          component17.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiAlliBoardSize[2]);
          RectTransform component18 = ((Component) component13).transform.GetChild(1).GetChild(3).GetComponent<RectTransform>();
          component18.anchoredPosition = new Vector2((float) x3, component18.anchoredPosition.y);
          component18.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiAlliBoardSize[2]);
          ((Component) component18).gameObject.SetActive(true);
          int x4 = x3 + UILeaderBoard.MobiAlliBoardSize[2];
          RectTransform component19 = ((Component) component13).transform.GetChild(0).GetChild(7).GetComponent<RectTransform>();
          component19.anchoredPosition = new Vector2((float) (x4 + UILeaderBoard.MobiAlliBoardSize[3] / 2), component19.anchoredPosition.y);
          component19.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiAlliBoardSize[3]);
          RectTransform component20 = ((Component) component13).transform.GetChild(0).GetChild(3).GetComponent<RectTransform>();
          component20.anchoredPosition = new Vector2((float) x4, component20.anchoredPosition.y);
          component20.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiAlliBoardSize[3]);
          RectTransform component21 = ((Component) component13).transform.GetChild(1).GetChild(7).GetComponent<RectTransform>();
          component21.anchoredPosition = new Vector2((float) x4, component21.anchoredPosition.y);
          component21.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiAlliBoardSize[3]);
          ((Component) component21).gameObject.SetActive(true);
          RectTransform component22 = ((Component) component13).transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
          component22.anchoredPosition = new Vector2((float) x4, component22.anchoredPosition.y);
          component22.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiAlliBoardSize[3]);
          ((Component) ((Component) component13).transform.GetChild(1).GetChild(10).GetComponent<RectTransform>()).gameObject.SetActive(false);
          break;
        case UI_LeaderBoardOpenKind.WorldKingHistory:
          RectTransform component23 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
          int x5 = 0;
          ((Component) component23).transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
          ((Component) component23).transform.GetChild(0).GetChild(3).gameObject.SetActive(true);
          ((Component) component23).transform.GetChild(0).GetChild(7).gameObject.SetActive(true);
          ((Component) component23).transform.GetChild(1).GetChild(7).gameObject.SetActive(true);
          RectTransform component24 = ((Transform) component23).GetChild(0).GetChild(0).GetComponent<RectTransform>();
          component24.anchoredPosition = new Vector2((float) x5, component24.anchoredPosition.y);
          component24.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiWorldKingBoardSize[0]);
          RectTransform component25 = ((Transform) component23).GetChild(0).GetChild(4).GetComponent<RectTransform>();
          component25.anchoredPosition = new Vector2((float) (x5 + UILeaderBoard.MobiWorldKingBoardSize[0] / 2), component25.anchoredPosition.y);
          component25.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiWorldKingBoardSize[0]);
          int x6 = UILeaderBoard.MobiWorldKingBoardSize[0];
          RectTransform component26 = ((Transform) component23).GetChild(0).GetChild(1).GetComponent<RectTransform>();
          component26.anchoredPosition = new Vector2((float) x6, component26.anchoredPosition.y);
          component26.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiWorldKingBoardSize[1]);
          RectTransform component27 = ((Transform) component23).GetChild(0).GetChild(5).GetComponent<RectTransform>();
          component27.anchoredPosition = new Vector2((float) (x6 + UILeaderBoard.MobiWorldKingBoardSize[1] / 2), component27.anchoredPosition.y);
          component27.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiWorldKingBoardSize[1]);
          int x7 = UILeaderBoard.MobiWorldKingBoardSize[0] + UILeaderBoard.MobiWorldKingBoardSize[1];
          RectTransform component28 = ((Transform) component23).GetChild(0).GetChild(2).GetComponent<RectTransform>();
          component28.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiWorldKingBoardSize[2]);
          component28.anchoredPosition = new Vector2((float) x7, component28.anchoredPosition.y);
          RectTransform component29 = ((Transform) component23).GetChild(0).GetChild(6).GetComponent<RectTransform>();
          component29.anchoredPosition = new Vector2((float) (x7 + UILeaderBoard.MobiWorldKingBoardSize[2] / 2), component29.anchoredPosition.y);
          component29.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiWorldKingBoardSize[2]);
          ((Component) ((Transform) component23).GetChild(0).GetChild(3).GetComponent<RectTransform>()).gameObject.SetActive(false);
          ((Component) ((Transform) component23).GetChild(0).GetChild(7).GetComponent<RectTransform>()).gameObject.SetActive(false);
          int x8 = 0;
          RectTransform component30 = ((Transform) component23).GetChild(1).GetChild(0).GetComponent<RectTransform>();
          component30.anchoredPosition = new Vector2((float) x8, component30.anchoredPosition.y);
          component30.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiWorldKingBoardSize[0]);
          int num3 = 10;
          RectTransform component31 = ((Transform) component23).GetChild(1).GetChild(4).GetComponent<RectTransform>();
          component31.anchoredPosition = new Vector2((float) (num3 + UILeaderBoard.MobiWorldKingBoardSize[0] / 2), component31.anchoredPosition.y);
          component31.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) (UILeaderBoard.MobiWorldKingBoardSize[0] - 20));
          ((Transform) component23).GetChild(1).GetChild(4).GetComponent<UIText>().alignment = TextAnchor.MiddleLeft;
          int x9 = UILeaderBoard.MobiWorldKingBoardSize[0];
          RectTransform component32 = ((Transform) component23).GetChild(1).GetChild(1).GetComponent<RectTransform>();
          component32.anchoredPosition = new Vector2((float) x9, component32.anchoredPosition.y);
          component32.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiWorldKingBoardSize[1]);
          RectTransform component33 = ((Transform) component23).GetChild(1).GetChild(5).GetComponent<RectTransform>();
          ((Transform) component23).GetChild(1).GetChild(5).GetComponent<UIText>().alignment = TextAnchor.MiddleCenter;
          component33.anchoredPosition = new Vector2((float) x9, component33.anchoredPosition.y);
          component33.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiWorldKingBoardSize[1]);
          int x10 = UILeaderBoard.MobiWorldKingBoardSize[0] + UILeaderBoard.MobiWorldKingBoardSize[1];
          RectTransform component34 = ((Transform) component23).GetChild(1).GetChild(2).GetComponent<RectTransform>();
          component34.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiWorldKingBoardSize[2]);
          component34.anchoredPosition = new Vector2((float) x10, component34.anchoredPosition.y);
          RectTransform component35 = ((Transform) component23).GetChild(1).GetChild(6).GetComponent<RectTransform>();
          component35.anchoredPosition = new Vector2((float) x10, component35.anchoredPosition.y);
          component35.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.MobiWorldKingBoardSize[3]);
          ((Component) ((Transform) component23).GetChild(1).GetChild(3).GetComponent<RectTransform>()).gameObject.SetActive(false);
          ((Component) ((Transform) component23).GetChild(1).GetChild(7).GetComponent<RectTransform>()).gameObject.SetActive(false);
          ((Component) ((Component) component23).transform.GetChild(1).GetChild(10).GetComponent<RectTransform>()).gameObject.SetActive(false);
          break;
        default:
          RectTransform component36 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
          int x11 = UILeaderBoard.CommonBoardSize[0];
          RectTransform component37 = ((Transform) component36).GetChild(0).GetChild(5).GetComponent<RectTransform>();
          component37.anchoredPosition = new Vector2((float) (x11 + UILeaderBoard.CommonBoardSize[1] / 2), component37.anchoredPosition.y);
          component37.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.CommonBoardSize[1]);
          RectTransform component38 = ((Transform) component36).GetChild(0).GetChild(1).GetComponent<RectTransform>();
          component38.anchoredPosition = new Vector2((float) x11, component38.anchoredPosition.y);
          component38.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.CommonBoardSize[1]);
          RectTransform component39 = ((Transform) component36).GetChild(1).GetChild(5).GetComponent<RectTransform>();
          component39.anchoredPosition = new Vector2((float) (x11 + 10), component39.anchoredPosition.y);
          component39.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) (UILeaderBoard.CommonBoardSize[1] - 20));
          RectTransform component40 = ((Transform) component36).GetChild(1).GetChild(1).GetComponent<RectTransform>();
          component40.anchoredPosition = new Vector2((float) x11, component40.anchoredPosition.y);
          component40.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.CommonBoardSize[1]);
          int x12 = x11 + UILeaderBoard.CommonBoardSize[1];
          RectTransform component41 = ((Transform) component36).GetChild(0).GetChild(6).GetComponent<RectTransform>();
          component41.anchoredPosition = new Vector2((float) (x12 + UILeaderBoard.CommonBoardSize[2] / 2), component41.anchoredPosition.y);
          component41.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.CommonBoardSize[2]);
          RectTransform component42 = ((Transform) component36).GetChild(0).GetChild(2).GetComponent<RectTransform>();
          component42.anchoredPosition = new Vector2((float) x12, component42.anchoredPosition.y);
          component42.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.CommonBoardSize[2]);
          RectTransform component43 = ((Transform) component36).GetChild(1).GetChild(6).GetComponent<RectTransform>();
          component43.anchoredPosition = new Vector2((float) (x12 + 10), component43.anchoredPosition.y);
          component43.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) (UILeaderBoard.CommonBoardSize[2] - 96));
          ((Component) component43).GetComponent<UIText>().alignment = TextAnchor.MiddleRight;
          RectTransform component44 = ((Transform) component36).GetChild(1).GetChild(2).GetComponent<RectTransform>();
          component44.anchoredPosition = new Vector2((float) x12, component44.anchoredPosition.y);
          component44.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoard.CommonBoardSize[2]);
          break;
      }
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
      this.HintStr = StringManager.Instance.SpawnString(300);
    }
    if (this.DataReady && this.LoadComplet)
    {
      this.DataReady = false;
      switch (this.OpenKind)
      {
        case UI_LeaderBoardOpenKind.Alli_Inter:
          this.CreateAlliInterBoard();
          this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
          this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
          this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[12]);
          break;
        case UI_LeaderBoardOpenKind.OtherAlli_inter:
          this.CreateOtherAlliInterBoard();
          this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
          this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
          this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[12]);
          break;
        case UI_LeaderBoardOpenKind.BoardMenu:
          if (UILeaderBoard.WorldBoard)
          {
            if (UILeaderBoard.isTopBoard)
            {
              this.CreateWorldRankingTopBoard();
              this.SetOpenType(UILeaderBoard.e_OpenType.BoardTypes);
              this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false);
              this.AGS_Panel1.GoTo(0);
              break;
            }
            this.CreateWorldRankingSubBoard();
            this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
            this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
            this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID]);
            break;
          }
          if (UILeaderBoard.isTopBoard)
          {
            this.CreateTopBoard();
            this.SetOpenType(UILeaderBoard.e_OpenType.BoardTypes);
            this.AGS_Panel1.AddNewDataHeight(this.SPHeight, false);
            this.AGS_Panel1.GoTo(0);
            break;
          }
          this.CreateSubBoard();
          this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
          this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
          this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID]);
          break;
        case UI_LeaderBoardOpenKind.ArenaBoard:
          int itemidx = UILeaderBoard.TopIndex[4];
          this.SubBoardChange((byte) 4);
          this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
          this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
          this.AGS_Panel2.GoTo(itemidx);
          break;
        case UI_LeaderBoardOpenKind.MobilizationGroupBoard:
          this.CreateMobilizationGroupBoard();
          this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
          this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
          if (UILeaderBoard.TopIndex[13] == 0 && UILeaderBoard.NewOpen)
          {
            UILeaderBoard.NewOpen = false;
            if (LeaderBoardManager.Instance.MobiGroupRank > 4)
              UILeaderBoard.TopIndex[13] = LeaderBoardManager.Instance.MobiGroupRank - 3;
          }
          this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[13]);
          break;
        case UI_LeaderBoardOpenKind.MobilizationAlliBoard:
          this.CreateMobilizationAlliBoard();
          this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
          this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
          if (UILeaderBoard.TopIndex[14] == 0 && UILeaderBoard.NewOpen)
          {
            UILeaderBoard.NewOpen = false;
            if (LeaderBoardManager.Instance.MobiAlliRank > 4)
              UILeaderBoard.TopIndex[14] = LeaderBoardManager.Instance.MobiAlliRank - 3;
          }
          this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[14]);
          break;
        case UI_LeaderBoardOpenKind.WorldKingHistory:
          this.CreateWorldKingHistoryBoard();
          this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
          this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
          this.AGS_Panel2.GoTo(UILeaderBoard.TopIndex[15]);
          break;
        case UI_LeaderBoardOpenKind.KingofWorldRankingBoard:
          this.CreateKingofWorldRankingBoard();
          this.SetOpenType(UILeaderBoard.e_OpenType.BoardContent);
          this.AGS_Panel2.AddNewDataHeight(this.SPHeight, false);
          this.AGS_Panel2.GoTo(0);
          break;
      }
    }
    this.GetPointTime += Time.smoothDeltaTime / 2f;
    if ((double) this.GetPointTime >= 1.7000000476837158)
      this.GetPointTime = 0.3f;
    Color color1 = new Color(1f, 1f, 1f, (double) this.GetPointTime <= 1.0 ? this.GetPointTime : 2f - this.GetPointTime);
    ((Graphic) this.POPLight1).color = color1;
    ((Graphic) this.POPLight3).color = color1;
    if (UILeaderBoard.ShowSP && !this.SPReady)
    {
      float num = 0.0f;
      for (int index = 0; index < this.SPShowTiming.Length; ++index)
      {
        num += this.SPShowTiming[index];
        this.SPShowTiming[index] = num;
      }
      for (int index = 0; index < this.SPStrings.Length; ++index)
        this.SPStrings[index] = StringManager.Instance.SpawnString();
      GameConstants.GetNameString(this.SPStrings[0], (ushort) 0, DataManager.Instance.RoleAlliance.Name, DataManager.Instance.RoleAlliance.Tag);
      this.SPName.text = this.SPStrings[0].ToString();
      this.SPName.SetAllDirty();
      this.SPName.cachedTextGenerator.Invalidate();
      this.SPStrings[1].IntToFormat((long) UILeaderBoard.SPScoreValue, bNumber: true);
      this.SPStrings[1].AppendFormat("{0}");
      this.SPScore.text = this.SPStrings[1].ToString();
      this.SPScore.SetAllDirty();
      this.SPScore.cachedTextGenerator.Invalidate();
      this.SPStrings[2].IntToFormat((long) UILeaderBoard.SPScoreFlyValue, bNumber: true);
      this.SPStrings[2].AppendFormat("{0}");
      this.SPScoreFly.text = this.SPStrings[2].ToString();
      this.SPScoreFly.SetAllDirty();
      this.SPScoreFly.cachedTextGenerator.Invalidate();
      this.SPReady = true;
      this.SPShowTime = 0.0f;
      if (this.OpenKind != UI_LeaderBoardOpenKind.MobilizationGroupBoard)
        UILeaderBoard.ShowSP = false;
    }
    if (!UILeaderBoard.ShowSP)
      return;
    this.SPShowTime += Time.smoothDeltaTime;
    if ((double) this.SPShowTime < (double) this.SPShowTiming[0])
    {
      if ((double) this.SPShowPhase < 1.0)
      {
        this.SPShowPhase = 1f;
        ((Component) this.SPScoreFly).gameObject.SetActive(false);
        ((Component) this.SPRankUpDown).gameObject.SetActive(false);
        ((Component) this.SPBG).gameObject.SetActive(true);
        if (!GUIManager.Instance.IsArabic)
          ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (Vector2.one * 0.6f);
        else
          ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (new Vector2(-1f, 1f) * 0.6f);
      }
      float num = Mathf.InverseLerp(0.0f, this.SPShowTiming[0], this.SPShowTime);
      ((Graphic) this.SPBG).color = ((Graphic) this.SPBG).color with
      {
        a = num * 0.8f
      };
      ((Graphic) this.SPName).color = ((Graphic) this.SPName).color with
      {
        a = num
      };
      ((Graphic) this.SPScore).color = Color.white with
      {
        a = num
      };
    }
    else if ((double) this.SPShowTime < (double) this.SPShowTiming[2])
    {
      Color color2;
      if ((double) this.SPShowPhase < 2.0)
      {
        this.SPShowPhase = 2f;
        ((Component) this.SPScoreFly).gameObject.SetActive(true);
        this.SPStrings[3].ClearString();
        this.SPStrings[3].IntToFormat((long) Math.Abs(UILeaderBoard.SPRankChange), bNumber: true);
        this.SPStrings[3].AppendFormat("{0}");
        this.SPRank.text = this.SPStrings[3].ToString();
        this.SPRank.SetAllDirty();
        this.SPRank.cachedTextGenerator.Invalidate();
        if (UILeaderBoard.SPRankChange > 0)
        {
          ((Component) this.SPRank).gameObject.SetActive(true);
          ((Component) this.SPRankUpDown).GetComponent<UISpritesArray>().SetSpriteIndex(0);
          ((Component) this.SPRankUpDown).gameObject.SetActive(true);
        }
        else if (UILeaderBoard.SPRankChange < 0)
        {
          ((Component) this.SPRank).gameObject.SetActive(true);
          ((Component) this.SPRankUpDown).GetComponent<UISpritesArray>().SetSpriteIndex(1);
          ((Component) this.SPRankUpDown).gameObject.SetActive(true);
        }
        else
          ((Component) this.SPRank).gameObject.SetActive(false);
        color2 = Color.white with { a = 0.0f };
        ((Graphic) this.SPRank).color = color2;
        ((Graphic) this.SPRankUpDown).color = color2;
      }
      float num = Mathf.InverseLerp(this.SPShowTiming[2], this.SPShowTiming[1], this.SPShowTime);
      color2 = ((Graphic) this.SPScoreFly).color with
      {
        a = num
      };
      ((Graphic) this.SPScoreFly).color = color2;
      ((Graphic) this.SPScoreFly).rectTransform.anchoredPosition = Vector2.Lerp(new Vector2(0.0f, -265f), ((Graphic) this.SPScore).rectTransform.anchoredPosition, Mathf.InverseLerp(this.SPShowTiming[0], this.SPShowTiming[2], this.SPShowTime));
    }
    else if ((double) this.SPShowTime < (double) this.SPShowTiming[3])
    {
      if ((double) this.SPShowPhase < 3.0)
      {
        this.SPShowPhase = 3f;
        ((Component) this.SPScoreFly).gameObject.SetActive(false);
        ((Graphic) this.SPScore).color = Color.yellow;
      }
      if (!GUIManager.Instance.IsArabic)
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (Vector2.one * Mathf.Lerp(0.5f, 0.8f, Mathf.InverseLerp(this.SPShowTiming[2], this.SPShowTiming[3], this.SPShowTime)));
      else
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (new Vector2(-1f, 1f) * Mathf.Lerp(0.5f, 0.8f, Mathf.InverseLerp(this.SPShowTiming[2], this.SPShowTiming[3], this.SPShowTime)));
    }
    else if ((double) this.SPShowTime < (double) this.SPShowTiming[4])
    {
      if ((double) this.SPShowPhase < 4.0)
      {
        this.SPShowPhase = 4f;
        AudioManager.Instance.PlaySFX((ushort) 40044);
      }
      this.SPStrings[1].ClearString();
      this.SPStrings[1].IntToFormat((long) (int) Mathf.Lerp((float) UILeaderBoard.SPScoreValue, (float) (UILeaderBoard.SPScoreValue + UILeaderBoard.SPScoreFlyValue), Mathf.InverseLerp(this.SPShowTiming[3], this.SPShowTiming[4], this.SPShowTime)), bNumber: true);
      this.SPStrings[1].AppendFormat("{0}");
      this.SPScore.text = this.SPStrings[1].ToString();
      this.SPScore.SetAllDirty();
      this.SPScore.cachedTextGenerator.Invalidate();
    }
    else if ((double) this.SPShowTime < (double) this.SPShowTiming[5])
    {
      if ((double) this.SPShowPhase < 5.0)
      {
        this.SPShowPhase = 5f;
        this.SPStrings[1].ClearString();
        this.SPStrings[1].IntToFormat((long) (UILeaderBoard.SPScoreValue + UILeaderBoard.SPScoreFlyValue), bNumber: true);
        this.SPStrings[1].AppendFormat("{0}");
        this.SPScore.text = this.SPStrings[1].ToString();
        this.SPScore.SetAllDirty();
        this.SPScore.cachedTextGenerator.Invalidate();
        AudioManager.Instance.PlaySFX((ushort) 40045);
      }
      float num = Mathf.InverseLerp(this.SPShowTiming[4], this.SPShowTiming[5], this.SPShowTime);
      Color white = Color.white with { a = num };
      ((Graphic) this.SPRank).color = white;
      ((Graphic) this.SPRankUpDown).color = white;
      if (!GUIManager.Instance.IsArabic)
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (Vector2.one * Mathf.Lerp(0.6f, 2f, Mathf.InverseLerp(this.SPShowTiming[4], this.SPShowTiming[5], this.SPShowTime)));
      else
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (new Vector2(-1f, 1f) * Mathf.Lerp(0.6f, 2f, Mathf.InverseLerp(this.SPShowTiming[4], this.SPShowTiming[5], this.SPShowTime)));
    }
    else if ((double) this.SPShowTime < (double) this.SPShowTiming[6])
    {
      if (!GUIManager.Instance.IsArabic)
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (Vector2.one * Mathf.Lerp(2f, 1f, Mathf.InverseLerp(this.SPShowTiming[5], this.SPShowTiming[6], this.SPShowTime)));
      else
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) (new Vector2(-1f, 1f) * Mathf.Lerp(2f, 1f, Mathf.InverseLerp(this.SPShowTiming[5], this.SPShowTiming[6], this.SPShowTime)));
    }
    else if ((double) this.SPShowTime < (double) this.SPShowTiming[7])
    {
      if (!GUIManager.Instance.IsArabic)
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) Vector2.one;
      else
        ((Transform) ((Graphic) this.SPScore).rectTransform).localScale = (Vector3) new Vector2(-1f, 1f);
    }
    else if ((double) this.SPShowTime < (double) this.SPShowTiming[8])
    {
      float num = Mathf.InverseLerp(this.SPShowTiming[8], this.SPShowTiming[7], this.SPShowTime);
      ((Graphic) this.SPBG).color = Color.white with
      {
        a = num * 0.8f
      };
      Color white = Color.white with { a = num };
      ((Graphic) this.SPRank).color = white;
      ((Graphic) this.SPRankUpDown).color = white;
      ((Graphic) this.SPScore).color = white;
      ((Graphic) this.SPName).color = ((Graphic) this.SPName).color with
      {
        a = num
      };
    }
    else
    {
      if ((double) this.SPShowTime <= (double) this.SPShowTiming[8])
        return;
      ((Component) this.SPBG).gameObject.SetActive(false);
      UILeaderBoard.ShowSP = false;
      this.SPShowTime = 0.0f;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    switch (panelId)
    {
      case 1:
        if (UILeaderBoard.WorldBoard)
        {
          this.UpdateRow_WorldRanking_FunctionList(item, dataIdx, panelObjectIdx);
          break;
        }
        this.UpdateRow_FunctionList(item, dataIdx, panelObjectIdx);
        break;
      case 2:
        switch (this.OpenKind)
        {
          case UI_LeaderBoardOpenKind.Alli_Inter:
          case UI_LeaderBoardOpenKind.OtherAlli_inter:
            this.UpdatRow_Alli(item, dataIdx, panelObjectIdx);
            return;
          case UI_LeaderBoardOpenKind.BoardMenu:
            if (UILeaderBoard.WorldBoard)
            {
              this.UpdatRow_WorldRanking_Boards(item, dataIdx, panelObjectIdx);
              return;
            }
            this.UpdatRow_Boards(item, dataIdx, panelObjectIdx);
            return;
          case UI_LeaderBoardOpenKind.ArenaBoard:
            this.UpdatRow_Boards(item, dataIdx, panelObjectIdx);
            return;
          case UI_LeaderBoardOpenKind.MobilizationGroupBoard:
            this.UpdatRow_MobiGroup(item, dataIdx, panelObjectIdx);
            return;
          case UI_LeaderBoardOpenKind.MobilizationAlliBoard:
            this.UpdatRow_MobiAlli(item, dataIdx, panelObjectIdx);
            return;
          case UI_LeaderBoardOpenKind.WorldKingHistory:
            this.UpdatRow_MobilizationWorldKing(item, dataIdx, panelObjectIdx);
            return;
          case UI_LeaderBoardOpenKind.KingofWorldRankingBoard:
            this.UpdatRow_KingofWorld(item, dataIdx, panelObjectIdx);
            return;
          default:
            return;
        }
    }
  }

  public void SetHiBtnAndText()
  {
    Transform child = this.AGS_Form.GetChild(3).GetChild(0);
    GUIManager.Instance.ChangeHeroItemImg(child, eHeroOrItem.Hero, LeaderBoardManager.Instance.KingHead, (byte) 11, (byte) 0);
    UIText component = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
    if (LeaderBoardManager.Instance.MobiWorldKingBoard.Count > 0)
    {
      GameConstants.FormatRoleName(this.RankValue, LeaderBoardManager.Instance.MobiWorldKingBoard[0].Name, LeaderBoardManager.Instance.MobiWorldKingBoard[0].AllianceTag, bCheckedNickname: (byte) 0, KingdomID: LeaderBoardManager.Instance.MobiWorldKingBoard[0].HomeKingdomID);
      component.text = this.RankValue.ToString();
    }
    if (ActivityManager.Instance.KOWData.EventState == EActivityState.EAS_Run || ActivityManager.Instance.KOWData.EventState == EActivityState.EAS_Prepare)
    {
      child.gameObject.SetActive(false);
      ((Component) component).gameObject.SetActive(false);
    }
    else
    {
      child.gameObject.SetActive(true);
      ((Component) component).gameObject.SetActive(true);
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (UILeaderBoard.isTopBoard || this.OpenKind != UI_LeaderBoardOpenKind.BoardMenu)
        {
          this.door.CloseMenu();
          UILeaderBoard.NewOpen = true;
          break;
        }
        UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
        if (UILeaderBoard.WorldBoard)
        {
          this.WorldRankingMainBoardChange();
          break;
        }
        this.MainBoardChange();
        break;
      case 1:
        DataManager.Instance.ShowLordProfile(UILeaderBoard.SortedAlliInterList[sender.m_BtnID2].Name.ToString());
        UILeaderBoard.TopIndex[12] = this.AGS_Panel2.GetTopIdx();
        break;
      case 2:
        UILeaderBoard.isPersonBoard = sender.m_BtnID2 == 1;
        UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
        if (UILeaderBoard.WorldBoard)
        {
          this.WorldRankingMainBoardChange();
          break;
        }
        this.MainBoardChange();
        break;
      case 3:
        switch (sender.m_BtnID2)
        {
          case 0:
            if (LeaderBoardManager.Instance.TopBoard.PowerTop.Value == 0UL)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8476U), (ushort) byte.MaxValue);
              return;
            }
            break;
          case 1:
            if (LeaderBoardManager.Instance.TopBoard.KillsTop.Value == 0UL)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8476U), (ushort) byte.MaxValue);
              return;
            }
            break;
          case 2:
            if (LeaderBoardManager.Instance.TopBoard.AlliPowerTop.Value == 0UL)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8476U), (ushort) byte.MaxValue);
              return;
            }
            break;
          case 3:
            if (LeaderBoardManager.Instance.TopBoard.AlliKillsTop.Value == 0UL)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(8476U), (ushort) byte.MaxValue);
              return;
            }
            break;
          case 4:
            if (LeaderBoardManager.isOpenArena() != 0)
              return;
            break;
          case 8:
          case 9:
          case 10:
          case 11:
            this.WorldRankingSubBoardChange((byte) sender.m_BtnID2);
            return;
        }
        this.SubBoardChange((byte) sender.m_BtnID2);
        break;
      case 4:
        if (UILeaderBoard.isPersonBoard)
        {
          if (UILeaderBoard.SubBoardID == (byte) 4 && LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][sender.m_BtnID2].Value == 1UL)
            break;
          DataManager.Instance.ShowLordProfile(LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][sender.m_BtnID2].Name.ToString());
          UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
          break;
        }
        UILeaderBoard.TopIndex[(int) UILeaderBoard.SubBoardID] = this.AGS_Panel2.GetTopIdx();
        DataManager.Instance.AllianceView.Id = ((BoardUnitAlliance) LeaderBoardManager.Instance.Boards[(int) UILeaderBoard.SubBoardID][sender.m_BtnID2]).AllianceID;
        this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5);
        break;
      case 5:
        LeaderBoardManager.Instance.hintTarget = ((Component) sender).GetComponent<UIButtonHint>();
        LeaderBoardManager.Instance.hintCenter = this.AGS_Form;
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_ARENA_BOARDDATA;
        messagePacket.AddSeqId();
        messagePacket.Add((byte) sender.m_BtnID2);
        messagePacket.Send();
        break;
      case 6:
        this.door.AllianceInfo(LeaderBoardManager.Instance.MobiGroupBoard[sender.m_BtnID2].AllianceTag.ToString());
        int topIdx1 = this.AGS_Panel2.GetTopIdx();
        if (topIdx1 > 0)
        {
          UILeaderBoard.TopIndex[13] = topIdx1;
          break;
        }
        UILeaderBoard.TopIndex[13] = 1;
        break;
      case 7:
        ActivityManager.Instance.Send_ACTIVITY_AM_RANKING_PRIZE();
        int topIdx2 = this.AGS_Panel2.GetTopIdx();
        if (topIdx2 > 0)
        {
          UILeaderBoard.TopIndex[13] = topIdx2;
          break;
        }
        UILeaderBoard.TopIndex[13] = 1;
        break;
      case 8:
        if (sender.m_BtnID2 > LeaderBoardManager.Instance.MobiWorldKingBoard.Count || sender.m_BtnID2 < 0)
          break;
        UILeaderBoard.TopIndex[15] = this.AGS_Panel2.GetTopIdx();
        DataManager.Instance.ShowLordProfile(LeaderBoardManager.Instance.MobiWorldKingBoard[sender.m_BtnID2].Name.ToString());
        break;
      case 9:
        if (!UILeaderBoard.WorldBoard)
        {
          if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level < (byte) 25)
          {
            GUIManager.Instance.MsgStr.ClearString();
            GUIManager.Instance.MsgStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9566U));
            GUIManager.Instance.MsgStr.IntToFormat(25L);
            GUIManager.Instance.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9749U));
            GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), (ushort) byte.MaxValue);
            break;
          }
          UILeaderBoard.WorldBoard = true;
          this.WorldRankingMainBoardChange();
          break;
        }
        UILeaderBoard.WorldBoard = false;
        this.MainBoardChange();
        break;
      case 10:
        if (sender.m_BtnID2 >= LeaderBoardManager.Instance.KingofWorldBoard.Count || sender.m_BtnID2 < 0)
          break;
        DataManager.Instance.ShowLordProfile(LeaderBoardManager.Instance.KingofWorldBoard[sender.m_BtnID2].Name.ToString());
        break;
      case 99:
        if (this.OpenKind == UI_LeaderBoardOpenKind.WorldKingHistory)
        {
          GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(11030U), DataManager.Instance.mStringTable.GetStringByID(11013U), BackExit: true);
          break;
        }
        GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7028U), DataManager.Instance.mStringTable.GetStringByID(9041U), bInfo: true);
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component3 != (UnityEngine.Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.AGS_Form.GetChild(5).GetComponent<UIText>();
    if ((UnityEngine.Object) component4 != (UnityEngine.Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    if ((UnityEngine.Object) this.SPName != (UnityEngine.Object) null && ((Behaviour) this.SPName).enabled)
    {
      ((Behaviour) this.SPName).enabled = false;
      ((Behaviour) this.SPName).enabled = true;
    }
    if ((UnityEngine.Object) this.SPScore != (UnityEngine.Object) null && ((Behaviour) this.SPScore).enabled)
    {
      ((Behaviour) this.SPScore).enabled = false;
      ((Behaviour) this.SPScore).enabled = true;
    }
    if ((UnityEngine.Object) this.SPScoreFly != (UnityEngine.Object) null && ((Behaviour) this.SPScoreFly).enabled)
    {
      ((Behaviour) this.SPScoreFly).enabled = false;
      ((Behaviour) this.SPScoreFly).enabled = true;
    }
    if ((UnityEngine.Object) this.SPRank != (UnityEngine.Object) null && ((Behaviour) this.SPRank).enabled)
    {
      ((Behaviour) this.SPRank).enabled = false;
      ((Behaviour) this.SPRank).enabled = true;
    }
    if ((UnityEngine.Object) this.AGS_Panel1 != (UnityEngine.Object) null && this.AGS_Panel1.gameObject.activeInHierarchy)
    {
      Transform child1 = this.AGS_Panel1.transform.GetChild(0);
      for (int index = 0; index < child1.childCount; ++index)
      {
        Transform child2 = child1.GetChild(index);
        if (child2.gameObject.activeInHierarchy)
        {
          UIText component5 = child2.GetChild(4).GetComponent<UIText>();
          if ((UnityEngine.Object) component5 != (UnityEngine.Object) null && ((Behaviour) component5).enabled)
          {
            ((Behaviour) component5).enabled = false;
            ((Behaviour) component5).enabled = true;
          }
          UIText component6 = child2.GetChild(5).GetComponent<UIText>();
          if ((UnityEngine.Object) component6 != (UnityEngine.Object) null && ((Behaviour) component6).enabled)
          {
            ((Behaviour) component6).enabled = false;
            ((Behaviour) component6).enabled = true;
          }
          UIText component7 = child2.GetChild(6).GetComponent<UIText>();
          if ((UnityEngine.Object) component7 != (UnityEngine.Object) null && ((Behaviour) component7).enabled)
          {
            ((Behaviour) component7).enabled = false;
            ((Behaviour) component7).enabled = true;
          }
        }
      }
    }
    if ((UnityEngine.Object) this.AGS_Panel2 != (UnityEngine.Object) null && this.AGS_Panel2.gameObject.activeInHierarchy)
    {
      Transform child3 = this.AGS_Panel2.transform.GetChild(0);
      for (int index = 0; index < child3.childCount; ++index)
      {
        Transform child4 = child3.GetChild(index);
        if (child4.GetChild(0).gameObject.activeInHierarchy)
        {
          UIText component8 = child4.GetChild(0).GetChild(4).GetComponent<UIText>();
          if ((UnityEngine.Object) component8 != (UnityEngine.Object) null && ((Behaviour) component8).enabled)
          {
            ((Behaviour) component8).enabled = false;
            ((Behaviour) component8).enabled = true;
          }
          UIText component9 = child4.GetChild(0).GetChild(5).GetComponent<UIText>();
          if ((UnityEngine.Object) component9 != (UnityEngine.Object) null && ((Behaviour) component9).enabled)
          {
            ((Behaviour) component9).enabled = false;
            ((Behaviour) component9).enabled = true;
          }
          UIText component10 = child4.GetChild(0).GetChild(6).GetComponent<UIText>();
          if ((UnityEngine.Object) component10 != (UnityEngine.Object) null && ((Behaviour) component10).enabled)
          {
            ((Behaviour) component10).enabled = false;
            ((Behaviour) component10).enabled = true;
          }
          UIText component11 = child4.GetChild(0).GetChild(7).GetComponent<UIText>();
          if ((UnityEngine.Object) component11 != (UnityEngine.Object) null && ((Behaviour) component11).enabled)
          {
            ((Behaviour) component11).enabled = false;
            ((Behaviour) component11).enabled = true;
          }
        }
        if (child4.GetChild(1).gameObject.activeInHierarchy)
        {
          UIText component12 = child4.GetChild(1).GetChild(4).GetComponent<UIText>();
          if ((UnityEngine.Object) component12 != (UnityEngine.Object) null && ((Behaviour) component12).enabled)
          {
            ((Behaviour) component12).enabled = false;
            ((Behaviour) component12).enabled = true;
          }
          UIText component13 = child4.GetChild(1).GetChild(5).GetComponent<UIText>();
          if ((UnityEngine.Object) component13 != (UnityEngine.Object) null && ((Behaviour) component13).enabled)
          {
            ((Behaviour) component13).enabled = false;
            ((Behaviour) component13).enabled = true;
          }
          UIText component14 = child4.GetChild(1).GetChild(6).GetComponent<UIText>();
          if ((UnityEngine.Object) component14 != (UnityEngine.Object) null && ((Behaviour) component14).enabled)
          {
            ((Behaviour) component14).enabled = false;
            ((Behaviour) component14).enabled = true;
          }
          UIText component15 = child4.GetChild(1).GetChild(7).GetComponent<UIText>();
          if ((UnityEngine.Object) component15 != (UnityEngine.Object) null && ((Behaviour) component15).enabled)
          {
            ((Behaviour) component15).enabled = false;
            ((Behaviour) component15).enabled = true;
          }
          UIText component16 = child4.GetChild(1).GetChild(9).GetComponent<UIText>();
          if ((UnityEngine.Object) component16 != (UnityEngine.Object) null && ((Behaviour) component16).enabled)
          {
            ((Behaviour) component16).enabled = false;
            ((Behaviour) component16).enabled = true;
          }
        }
      }
    }
    UIText component17 = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component17 != (UnityEngine.Object) null && ((Behaviour) component17).enabled)
    {
      ((Behaviour) component17).enabled = false;
      ((Behaviour) component17).enabled = true;
    }
    UIText component18 = this.AGS_Form.GetChild(14).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component18 != (UnityEngine.Object) null && ((Behaviour) component18).enabled)
    {
      ((Behaviour) component18).enabled = false;
      ((Behaviour) component18).enabled = true;
    }
    UIText component19 = this.AGS_Form.GetChild(14).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component19 != (UnityEngine.Object) null && ((Behaviour) component19).enabled)
    {
      ((Behaviour) component19).enabled = false;
      ((Behaviour) component19).enabled = true;
    }
    UIText component20 = this.AGS_Form.GetChild(14).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component20 != (UnityEngine.Object) null && ((Behaviour) component20).enabled)
    {
      ((Behaviour) component20).enabled = false;
      ((Behaviour) component20).enabled = true;
    }
    UIText component21 = this.AGS_Form.GetChild(14).GetChild(4).GetComponent<UIText>();
    if (!((UnityEngine.Object) component21 != (UnityEngine.Object) null) || !((Behaviour) component21).enabled)
      return;
    ((Behaviour) component21).enabled = false;
    ((Behaviour) component21).enabled = true;
  }

  private enum e_AGS_UI_LeaderBoard_Editor
  {
    BGFrame,
    BGFrameTitle,
    Laurel,
    PlayerSelf,
    SwitchTags,
    CenterText,
    FunctionlPanel,
    LeaderBoardPanel,
    exitImage,
    iButton,
    AMRank,
    RankReward,
    BoardSwitch,
    EmptyDial,
    ScoreChange,
  }

  private enum e_AGS_PlayerSelf
  {
    UIHIBtn,
    Alliance,
    Position,
    Power,
  }

  private enum e_AGS_SwitchTags
  {
    Players,
    Alliance,
  }

  private enum e_AGS_FunctionlPanel
  {
    Panel1,
    Panel1Item,
    KingdomIcon,
  }

  private enum e_AGS_Panel1Item
  {
    TitleBG,
    ColBG,
    Alliance,
    UIHIBtn,
    Title,
    Name,
    Value,
    Arrow,
  }

  private enum e_AGS_LeaderBoardPanel
  {
    Panel2,
    Panel2Item,
  }

  private enum e_AGS_Panel2Item
  {
    Title,
    Block,
  }

  public enum e_AGS_Block
  {
    BG1,
    BG2,
    BG3,
    BG4,
    Rank,
    Name,
    KindVar,
    change,
    updown,
    updowntext,
    SearchBtn,
    ArenaBtn,
    ArenaBGBtn,
  }

  private enum e_AGS_ScoreChange
  {
    name,
    score,
    scorefly,
    updown,
    updownRanking,
  }

  private enum e_OpenType
  {
    BoardTypes,
    BoardContent,
  }

  private enum UIRecallMemoryPos
  {
    PlayerPower,
    PlayerKills,
    AlliancePower,
    ALLianceKill,
    Arena,
    KVKKingdom,
    KVKAllianceRank,
    KVKAllianceMemberRank,
    World_PlayerPower,
    World_PlayerKills,
    World_AlliancePower,
    World_ALLianceKill,
    AlliancePublic,
    MobilizationGroupBoard,
    MobilizationAllianceBoard,
    KingOfWorldHistoryBoard,
    Max,
  }
}
