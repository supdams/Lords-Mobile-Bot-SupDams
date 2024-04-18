// Decompiled with JetBrains decompiler
// Type: UI_AlliWarSchedule
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UI_AlliWarSchedule : GUIWindow, IUIButtonClickHandler
{
  private Door door;
  private Transform AGS_Form;
  private UISpritesArray AGS_SpriteArray;
  private UISpritesArray AGS_SpriteArray2;
  private UI_AlliWarSchedule.AWS_NodeData[] Top16Nodes = new UI_AlliWarSchedule.AWS_NodeData[16];
  private UI_AlliWarSchedule.AWS_NodeData[] Top8Nodes = new UI_AlliWarSchedule.AWS_NodeData[8];
  private UI_AlliWarSchedule.AWS_NodeData[] Top4Nodes = new UI_AlliWarSchedule.AWS_NodeData[4];
  private UI_AlliWarSchedule.AWS_NodeData[] Top2Nodes = new UI_AlliWarSchedule.AWS_NodeData[2];
  private UI_AlliWarSchedule.AWS_LineData[] Top16Lines = new UI_AlliWarSchedule.AWS_LineData[8];
  private UI_AlliWarSchedule.AWS_LineData[] Top8Lines = new UI_AlliWarSchedule.AWS_LineData[4];
  private UI_AlliWarSchedule.AWS_LineData[] Top4Lines = new UI_AlliWarSchedule.AWS_LineData[2];
  private UI_AlliWarSchedule.AWS_LineData[] Top2Lines = new UI_AlliWarSchedule.AWS_LineData[1];
  public static UI_AlliWarSchedule.AWS_AlliData[] AllianceData = new UI_AlliWarSchedule.AWS_AlliData[16];
  public static UI_AlliWarSchedule.AWS_FightData[] FightData = new UI_AlliWarSchedule.AWS_FightData[15];
  public static int[] NodePos_S2C = new int[16]
  {
    0,
    12,
    4,
    8,
    2,
    14,
    6,
    10,
    1,
    13,
    5,
    9,
    3,
    15,
    7,
    11
  };
  public static int[] LinePos_S2C = new int[15]
  {
    14,
    13,
    12,
    10,
    9,
    11,
    8,
    5,
    3,
    7,
    1,
    4,
    2,
    6,
    0
  };
  public static int[] LinePos_C2S = new int[15]
  {
    15,
    11,
    13,
    9,
    12,
    8,
    14,
    10,
    7,
    5,
    4,
    6,
    3,
    2,
    1
  };
  private UI_AlliWarSchedule.WinnerEffect WinnerEff = new UI_AlliWarSchedule.WinnerEffect();
  public static UI_AlliWarSchedule.EAWSFightStep Step = UI_AlliWarSchedule.EAWSFightStep.Top16;
  private int[] BtnIndexToLevel = new int[15]
  {
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    0,
    1,
    1,
    1,
    1,
    2,
    2,
    3
  };
  private uint[] LevelToStr = new uint[4]
  {
    14604U,
    14605U,
    14606U,
    14607U
  };
  private UIText Title;
  private UIText Notes;
  private CString HudStr = new CString(1024);
  private CString MsgStr = new CString(1024);
  private bool bExit;
  public static bool Reconnect = false;
  public static float ReconnectTimeCache = 0.0f;

  public override void OnOpen(int arg1, int arg2)
  {
    this.door = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    this.AGS_SpriteArray = this.AGS_Form.GetChild(0).GetComponent<UISpritesArray>();
    this.AGS_SpriteArray2 = this.AGS_Form.GetChild(1).GetComponent<UISpritesArray>();
    this.WinnerEff.IO = (byte) 0;
    this.WinnerEff.EffectNode1 = this.AGS_Form.GetChild(2).GetChild(0);
    this.WinnerEff.RotateingLight = this.WinnerEff.EffectNode1.GetChild(2);
    ((Graphic) this.WinnerEff.RotateingLight.GetComponent<Image>()).color = (Color) new Color32(byte.MaxValue, (byte) 216, (byte) 98, byte.MaxValue);
    this.WinnerEff.EffectNode2 = this.AGS_Form.GetChild(2).GetChild(9);
    this.WinnerEff.lightBox = this.WinnerEff.EffectNode2.GetComponent<Image>();
    this.WinnerEff.lightBoxStep = -1;
    this.WinnerEff.EffectNode1.localScale = Vector3.zero;
    this.WinnerEff.EffectNode2.localScale = Vector3.zero;
    for (int index = 0; index < 16; ++index)
      this.InitNode(this.Top16Nodes, index, this.AGS_Form.GetChild(2).GetChild(1));
    for (int index = 0; index < 8; ++index)
    {
      this.InitNode(this.Top8Nodes, index, this.AGS_Form.GetChild(2).GetChild(2));
      this.InitLine(this.Top16Lines, index, this.Top16Nodes, (byte) index, (UI_AlliWarSchedule.AWS_LineData[]) null, this.AGS_Form.GetChild(2).GetChild(5), UI_AlliWarSchedule.EAWSLineStyle.Vertical);
    }
    for (int index = 0; index < 4; ++index)
    {
      this.InitNode(this.Top4Nodes, index, this.AGS_Form.GetChild(2).GetChild(3));
      this.InitLine(this.Top8Lines, index, this.Top8Nodes, (byte) (8 + index), this.Top16Lines, this.AGS_Form.GetChild(2).GetChild(6), UI_AlliWarSchedule.EAWSLineStyle.Vertical);
    }
    for (int index = 0; index < 2; ++index)
    {
      this.InitNode(this.Top2Nodes, index, this.AGS_Form.GetChild(2).GetChild(4));
      this.InitLine(this.Top4Lines, index, this.Top4Nodes, (byte) (12 + index), this.Top8Lines, this.AGS_Form.GetChild(2).GetChild(7), UI_AlliWarSchedule.EAWSLineStyle.Horizontal);
    }
    this.InitLine(this.Top2Lines, 0, this.Top2Nodes, (byte) 14, this.Top4Lines, this.AGS_Form.GetChild(2).GetChild(8), UI_AlliWarSchedule.EAWSLineStyle.Vertical);
    ((Transform) ((Graphic) this.Top2Lines[0].Score).rectTransform).localPosition = new Vector3(((Transform) ((Graphic) this.Top2Lines[0].Score).rectTransform).localPosition.x, ((Transform) ((Graphic) this.Top2Lines[0].Score).rectTransform).localPosition.y - 2f, ((Transform) ((Graphic) this.Top2Lines[0].Score).rectTransform).localPosition.z);
    this.Notes = this.AGS_Form.GetChild(2).GetChild(10).GetComponent<UIText>();
    this.Notes.font = ttfFont;
    this.Title = this.AGS_Form.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.Title.font = ttfFont;
    this.Title.text = DataManager.Instance.mStringTable.GetStringByID(17501U);
    Image component1 = this.AGS_Form.GetChild(4).GetComponent<Image>();
    component1.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component1).material = this.door.LoadMaterial();
    ((Behaviour) component1).enabled = !GUIManager.Instance.bOpenOnIPhoneX;
    Image component2 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component2).material = this.door.LoadMaterial();
    UIButton component3 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 0;
    component3.transition = (Selectable.Transition) 0;
    component3.m_EffectType = e_EffectType.e_Scale;
    for (int index = 0; index < 15; ++index)
    {
      UIButton component4 = this.AGS_Form.GetChild(2).GetChild(11).GetChild(index).GetComponent<UIButton>();
      component4.m_BtnID1 = 1 + index;
      component4.m_Handler = (IUIButtonClickHandler) this;
    }
    this.RefreshData();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    ActivityManager instance = ActivityManager.Instance;
    if ((UnityEngine.Object) this.door != (UnityEngine.Object) null && (instance.AW_State == EAllianceWarState.EAWS_None || DataManager.Instance.RoleAlliance.Id == 0U))
    {
      this.bExit = true;
    }
    else
    {
      if ((instance.AW_Round != (byte) 0 ? (int) (byte) ((uint) instance.AW_Round - 1U) : 5) == (int) (byte) UI_AlliWarSchedule.Step)
        return;
      UI_AlliWarSchedule.RequestScheduleData();
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
      case NetworkNews.Refresh_AllianceWarRound:
        UI_AlliWarSchedule.RequestScheduleData();
        break;
      case NetworkNews.Refresh_RecvAllianceInfo:
        UI_AlliWarSchedule.RequestScheduleData();
        break;
      default:
        if (networkNews != NetworkNews.Login || ActivityManager.Instance.AW_State != EAllianceWarState.EAWS_None && DataManager.Instance.RoleAlliance.Id != 0U || !((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.CloseMenu();
        break;
    }
  }

  private UI_AlliWarSchedule.AWS_NodeData InitNode(
    UI_AlliWarSchedule.AWS_NodeData[] container,
    int index,
    Transform nodeTrans)
  {
    UI_AlliWarSchedule.AWS_NodeData awsNodeData = new UI_AlliWarSchedule.AWS_NodeData();
    awsNodeData.AlliTag = nodeTrans.GetChild(index).GetChild(2).GetComponent<UIText>();
    awsNodeData.AlliTag.font = GUIManager.Instance.GetTTFFont();
    awsNodeData.StrNone = nodeTrans.GetChild(index).GetChild(3).GetComponent<UIText>();
    awsNodeData.StrNone.font = GUIManager.Instance.GetTTFFont();
    awsNodeData.StrNone.text = DataManager.Instance.mStringTable.GetStringByID(17505U);
    awsNodeData.IconBackObj = nodeTrans.GetChild(index).GetChild(1).gameObject;
    awsNodeData.ElbemTrans = awsNodeData.IconBackObj.transform.GetChild(0) as RectTransform;
    awsNodeData.ImgUnknown = nodeTrans.GetChild(index).GetChild(0).GetComponent<Image>();
    RectTransform transform = ((Component) awsNodeData.ImgUnknown).transform as RectTransform;
    if ((UnityEngine.Object) transform != (UnityEngine.Object) null)
      transform.sizeDelta = awsNodeData.ElbemTrans.sizeDelta;
    awsNodeData.Mask = nodeTrans.GetChild(index).GetChild(4).GetComponent<Image>();
    awsNodeData.NodeBack = nodeTrans.GetChild(index).GetComponent<Image>();
    ((Graphic) awsNodeData.Mask).color = (Color) new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, (byte) 128);
    container[index] = awsNodeData;
    return awsNodeData;
  }

  private void SetupNode(
    ref UI_AlliWarSchedule.AWS_NodeData _node,
    UI_AlliWarSchedule.EAWSNodeState state,
    bool highlight = true,
    int dataindex = 0)
  {
    switch (state)
    {
      case UI_AlliWarSchedule.EAWSNodeState.Normal:
        _node.NodeBack.sprite = (int) DataManager.Instance.RoleAlliance.Id != (int) UI_AlliWarSchedule.AllianceData[dataindex].ID ? this.AGS_SpriteArray.GetSprite(1) : this.AGS_SpriteArray.GetSprite(2);
        _node.IconBackObj.SetActive(true);
        if (((Transform) _node.ElbemTrans).childCount == 0)
          GUIManager.Instance.InitBadgeTotem((Transform) _node.ElbemTrans, UI_AlliWarSchedule.AllianceData[dataindex].Emblem);
        else
          GUIManager.Instance.SetBadgeTotemImg((Transform) _node.ElbemTrans, UI_AlliWarSchedule.AllianceData[dataindex].Emblem);
        RectTransform child = ((Transform) _node.ElbemTrans).GetChild(0) as RectTransform;
        if ((UnityEngine.Object) child != (UnityEngine.Object) null)
          child.sizeDelta = _node.ElbemTrans.sizeDelta;
        ((Behaviour) _node.AlliTag).enabled = true;
        _node.AlliTag.text = UI_AlliWarSchedule.AllianceData[dataindex].Tag;
        ((Behaviour) _node.StrNone).enabled = false;
        ((Behaviour) _node.ImgUnknown).enabled = false;
        break;
      case UI_AlliWarSchedule.EAWSNodeState.UnKnown:
        _node.NodeBack.sprite = this.AGS_SpriteArray.GetSprite(0);
        _node.IconBackObj.SetActive(false);
        ((Behaviour) _node.AlliTag).enabled = false;
        ((Behaviour) _node.StrNone).enabled = false;
        ((Behaviour) _node.ImgUnknown).enabled = true;
        break;
      case UI_AlliWarSchedule.EAWSNodeState.NoAlliance:
        _node.NodeBack.sprite = this.AGS_SpriteArray.GetSprite(1);
        _node.IconBackObj.SetActive(false);
        ((Behaviour) _node.AlliTag).enabled = false;
        ((Behaviour) _node.StrNone).enabled = true;
        ((Behaviour) _node.ImgUnknown).enabled = false;
        break;
      default:
        _node.NodeBack.sprite = this.AGS_SpriteArray.GetSprite(0);
        _node.IconBackObj.SetActive(false);
        ((Behaviour) _node.AlliTag).enabled = false;
        ((Behaviour) _node.StrNone).enabled = false;
        ((Behaviour) _node.ImgUnknown).enabled = false;
        break;
    }
    ((Behaviour) _node.Mask).enabled = !highlight;
    _node.State = state;
  }

  private UI_AlliWarSchedule.AWS_LineData InitLine(
    UI_AlliWarSchedule.AWS_LineData[] container,
    int index,
    UI_AlliWarSchedule.AWS_NodeData[] childnodes,
    byte fightDataIndex,
    UI_AlliWarSchedule.AWS_LineData[] childlines,
    Transform lineTrans,
    UI_AlliWarSchedule.EAWSLineStyle style)
  {
    UI_AlliWarSchedule.AWS_LineData awsLineData = new UI_AlliWarSchedule.AWS_LineData();
    awsLineData.Style = style;
    awsLineData.Score = lineTrans.GetChild(index).GetChild(1).GetComponent<UIText>();
    awsLineData.Score.font = GUIManager.Instance.GetTTFFont();
    awsLineData.ImgVS = lineTrans.GetChild(index).GetChild(0).GetComponent<Image>();
    if (GUIManager.Instance.IsArabic)
      ((Transform) ((Graphic) awsLineData.ImgVS).rectTransform).localScale = new Vector3(-((Transform) ((Graphic) awsLineData.ImgVS).rectTransform).localScale.x, ((Transform) ((Graphic) awsLineData.ImgVS).rectTransform).localScale.y, ((Transform) ((Graphic) awsLineData.ImgVS).rectTransform).localScale.z);
    awsLineData.Line = lineTrans.GetChild(index).GetComponent<Image>();
    if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
      awsLineData.ImgVS.sprite = this.AGS_SpriteArray2.GetSprite(1);
    awsLineData.Node1 = childnodes[index * 2];
    awsLineData.Node2 = childnodes[index * 2 + 1];
    awsLineData.ChildLine1 = childlines?[index * 2];
    awsLineData.ChildLine2 = childlines?[index * 2 + 1];
    awsLineData.FightDataIndex = fightDataIndex;
    awsLineData.StrScore = new CString(10);
    container[index] = awsLineData;
    return awsLineData;
  }

  private void SetupLine(
    ref UI_AlliWarSchedule.AWS_LineData _node,
    UI_AlliWarSchedule.EAWSLineState state,
    int fightDataIndex = 0)
  {
    switch (state)
    {
      case UI_AlliWarSchedule.EAWSLineState.VS:
        if (((Color32) ((Graphic) _node.Line).color).a != (byte) 0)
          ((Graphic) _node.Line).color = (Color) new Color32((byte) 93, (byte) 187, (byte) 236, byte.MaxValue);
        ((Behaviour) _node.Score).enabled = false;
        ((Behaviour) _node.ImgVS).enabled = true;
        _node.State = UI_AlliWarSchedule.EAWSLineState.VS;
        break;
      case UI_AlliWarSchedule.EAWSLineState.Score:
        if (((Color32) ((Graphic) _node.Line).color).a != (byte) 0)
          ((Graphic) _node.Line).color = (Color) new Color32((byte) 108, (byte) 118, (byte) 126, byte.MaxValue);
        if (UI_AlliWarSchedule.FightData[fightDataIndex].Score1 != (byte) 0 || UI_AlliWarSchedule.FightData[fightDataIndex].Score2 != (byte) 0)
        {
          _node.StrScore.ClearString();
          _node.StrScore.IntToFormat((long) UI_AlliWarSchedule.FightData[fightDataIndex].Score1);
          _node.StrScore.IntToFormat((long) UI_AlliWarSchedule.FightData[fightDataIndex].Score2);
          if (_node.Style == UI_AlliWarSchedule.EAWSLineStyle.Vertical)
            _node.StrScore.AppendFormat("{0}\n|\n{1}");
          else if (GUIManager.Instance.IsArabic)
            _node.StrScore.AppendFormat("{1}─{0}");
          else
            _node.StrScore.AppendFormat("{0}─{1}");
          _node.Score.text = _node.StrScore.ToString();
        }
        else
          _node.Score.text = string.Empty;
        ((Behaviour) _node.Score).enabled = true;
        ((Behaviour) _node.ImgVS).enabled = false;
        _node.State = UI_AlliWarSchedule.EAWSLineState.Score;
        break;
      case UI_AlliWarSchedule.EAWSLineState.EmptyLightLine:
        if (((Color32) ((Graphic) _node.Line).color).a != (byte) 0)
          ((Graphic) _node.Line).color = (Color) new Color32((byte) 93, (byte) 187, (byte) 236, byte.MaxValue);
        ((Behaviour) _node.Score).enabled = false;
        ((Behaviour) _node.ImgVS).enabled = false;
        _node.State = UI_AlliWarSchedule.EAWSLineState.Empty;
        break;
      default:
        if (((Color32) ((Graphic) _node.Line).color).a != (byte) 0)
          ((Graphic) _node.Line).color = (Color) new Color32((byte) 108, (byte) 118, (byte) 126, byte.MaxValue);
        ((Behaviour) _node.Score).enabled = false;
        ((Behaviour) _node.ImgVS).enabled = false;
        _node.State = UI_AlliWarSchedule.EAWSLineState.Empty;
        break;
    }
  }

  private void RefreshData()
  {
    for (int LineIdx = 0; LineIdx < 8; ++LineIdx)
      this.RefreshNode((byte) 0, LineIdx, this.Top16Nodes, this.Top16Lines);
    for (int LineIdx = 0; LineIdx < 4; ++LineIdx)
      this.RefreshNode((byte) 1, LineIdx, this.Top8Nodes, this.Top8Lines);
    for (int LineIdx = 0; LineIdx < 2; ++LineIdx)
      this.RefreshNode((byte) 2, LineIdx, this.Top4Nodes, this.Top4Lines);
    this.RefreshNode((byte) 3, 0, this.Top2Nodes, this.Top2Lines);
    if (UI_AlliWarSchedule.Step == UI_AlliWarSchedule.EAWSFightStep.Final)
    {
      if (UI_AlliWarSchedule.FightData[14].Winner == (byte) 1)
        this.SetupWinnerEffect(true, 0);
      else if (UI_AlliWarSchedule.FightData[14].Winner == (byte) 2)
        this.SetupWinnerEffect(true, 1);
      else
        this.SetupWinnerEffect(false, 0);
      this.Notes.text = DataManager.Instance.mStringTable.GetStringByID(17506U);
    }
    else
    {
      this.SetupWinnerEffect(false, 0);
      this.Notes.text = DataManager.Instance.mStringTable.GetStringByID(17504U);
    }
  }

  private void RefreshNode(
    byte level,
    int LineIdx,
    UI_AlliWarSchedule.AWS_NodeData[] nodes,
    UI_AlliWarSchedule.AWS_LineData[] lines)
  {
    int index = LineIdx * 2;
    bool flag = false;
    int fightDataIndex = (int) lines[LineIdx].FightDataIndex;
    UI_AlliWarSchedule.AWS_LineData childLine1 = lines[LineIdx].ChildLine1;
    UI_AlliWarSchedule.AWS_LineData childLine2 = lines[LineIdx].ChildLine2;
    UI_AlliWarSchedule.EAWSLineState state;
    if (UI_AlliWarSchedule.FightData[fightDataIndex].Winner != (byte) 0)
      state = UI_AlliWarSchedule.EAWSLineState.Score;
    else if ((int) level > (int) (byte) UI_AlliWarSchedule.Step)
    {
      state = UI_AlliWarSchedule.EAWSLineState.Empty;
    }
    else
    {
      state = UI_AlliWarSchedule.EAWSLineState.VS;
      flag = true;
    }
    bool highlight = false;
    if (UI_AlliWarSchedule.Step == UI_AlliWarSchedule.EAWSFightStep.Final || level == (byte) 3 && state == UI_AlliWarSchedule.EAWSLineState.Score)
      highlight = true;
    else if ((int) (byte) UI_AlliWarSchedule.Step <= (int) level)
      highlight = true;
    if (state == UI_AlliWarSchedule.EAWSLineState.Empty)
    {
      if (childLine1 != null && (childLine1.Node1.State == UI_AlliWarSchedule.EAWSNodeState.UnKnown || childLine1.Node1.State == UI_AlliWarSchedule.EAWSNodeState.Empty) || childLine2 != null && (childLine2.Node2.State == UI_AlliWarSchedule.EAWSNodeState.UnKnown || childLine2.Node2.State == UI_AlliWarSchedule.EAWSNodeState.Empty))
      {
        this.SetupNode(ref nodes[index], UI_AlliWarSchedule.EAWSNodeState.Empty, highlight);
        this.SetupNode(ref nodes[index + 1], UI_AlliWarSchedule.EAWSNodeState.Empty, highlight);
      }
      else
      {
        this.SetupNode(ref nodes[index], UI_AlliWarSchedule.EAWSNodeState.UnKnown, highlight);
        this.SetupNode(ref nodes[index + 1], UI_AlliWarSchedule.EAWSNodeState.UnKnown, highlight);
      }
    }
    else
    {
      if (UI_AlliWarSchedule.AllianceData[(int) UI_AlliWarSchedule.FightData[fightDataIndex].Alliance1Index].ID != 0U)
        this.SetupNode(ref nodes[index], UI_AlliWarSchedule.EAWSNodeState.Normal, highlight, (int) UI_AlliWarSchedule.FightData[fightDataIndex].Alliance1Index);
      else
        this.SetupNode(ref nodes[index], UI_AlliWarSchedule.EAWSNodeState.NoAlliance, highlight, (int) UI_AlliWarSchedule.FightData[fightDataIndex].Alliance1Index);
      if (UI_AlliWarSchedule.AllianceData[(int) UI_AlliWarSchedule.FightData[fightDataIndex].Alliance2Index].ID != 0U)
        this.SetupNode(ref nodes[index + 1], UI_AlliWarSchedule.EAWSNodeState.Normal, highlight, (int) UI_AlliWarSchedule.FightData[fightDataIndex].Alliance2Index);
      else
        this.SetupNode(ref nodes[index + 1], UI_AlliWarSchedule.EAWSNodeState.NoAlliance, highlight, (int) UI_AlliWarSchedule.FightData[fightDataIndex].Alliance2Index);
    }
    if (state == UI_AlliWarSchedule.EAWSLineState.VS && ((Behaviour) nodes[index].StrNone).enabled && ((Behaviour) nodes[index + 1].StrNone).enabled)
      state = (int) (byte) UI_AlliWarSchedule.Step != (int) level ? UI_AlliWarSchedule.EAWSLineState.Empty : UI_AlliWarSchedule.EAWSLineState.EmptyLightLine;
    this.SetupLine(ref lines[LineIdx], state, fightDataIndex);
  }

  private void SetupWinnerEffect(bool show, int posidx)
  {
    if (show)
    {
      this.WinnerEff.IO = (byte) 1;
      this.WinnerEff.EffectNode1.localScale = Vector3.one;
      this.WinnerEff.EffectNode2.localScale = Vector3.one;
      this.WinnerEff.EffectNode1.localPosition = ((Component) this.Top2Nodes[posidx].NodeBack).transform.localPosition;
      this.WinnerEff.EffectNode2.localPosition = ((Component) this.Top2Nodes[posidx].NodeBack).transform.localPosition;
    }
    else
    {
      this.WinnerEff.IO = (byte) 0;
      this.WinnerEff.EffectNode1.localScale = Vector3.zero;
      this.WinnerEff.EffectNode2.localScale = Vector3.zero;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        this.door.CloseMenu();
        break;
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
      case 7:
      case 8:
      case 9:
      case 10:
      case 11:
      case 12:
      case 13:
      case 14:
      case 15:
        int num1 = this.BtnIndexToLevel[sender.m_BtnID1 - 1];
        if (UI_AlliWarSchedule.Step != UI_AlliWarSchedule.EAWSFightStep.Final && (UI_AlliWarSchedule.EAWSFightStep) num1 != UI_AlliWarSchedule.Step)
          break;
        UI_AlliWarSchedule.AWS_AlliData awsAlliData1 = UI_AlliWarSchedule.AllianceData[(int) UI_AlliWarSchedule.FightData[sender.m_BtnID1 - 1].Alliance1Index];
        UI_AlliWarSchedule.AWS_AlliData awsAlliData2 = UI_AlliWarSchedule.AllianceData[(int) UI_AlliWarSchedule.FightData[sender.m_BtnID1 - 1].Alliance2Index];
        if (awsAlliData1.ID == 0U && awsAlliData2.ID == 0U)
          break;
        byte num2 = (byte) UI_AlliWarSchedule.LinePos_C2S[sender.m_BtnID1 - 1];
        if (UI_AlliWarSchedule.Step != UI_AlliWarSchedule.EAWSFightStep.Final)
        {
          if (awsAlliData1.ID == 0U || awsAlliData2.ID == 0U)
          {
            this.HudStr.ClearString();
            this.HudStr.StringToFormat(awsAlliData1.ID != 0U ? awsAlliData1.Tag : awsAlliData2.Tag);
            this.HudStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17507U));
            GUIManager.Instance.AddHUDMessage(this.HudStr.ToString(), (ushort) byte.MaxValue);
            break;
          }
          uint id = DataManager.Instance.RoleAlliance.Id;
          if ((int) id == (int) awsAlliData1.ID || (int) id == (int) awsAlliData2.ID)
          {
            byte num3 = 0;
            if (GUIManager.Instance.bCheckAWSSchedule)
            {
              GUIManager.Instance.OpenCheckAWSSchedule(DataManager.Instance.mStringTable.GetStringByID(17502U), num3);
              break;
            }
            this.RequestPlayWar(num3);
            break;
          }
          this.MsgStr.ClearString();
          this.MsgStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(this.LevelToStr[(int) UI_AlliWarSchedule.Step]));
          this.MsgStr.StringToFormat(awsAlliData1.Tag);
          this.MsgStr.StringToFormat(awsAlliData2.Tag);
          this.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17503U));
          if (GUIManager.Instance.bCheckAWSSchedule)
          {
            GUIManager.Instance.OpenCheckAWSSchedule(this.MsgStr.ToString(), num2);
            break;
          }
          this.RequestPlayWar(num2);
          break;
        }
        if (awsAlliData1.ID == 0U || awsAlliData2.ID == 0U)
        {
          this.HudStr.ClearString();
          this.HudStr.StringToFormat(awsAlliData1.ID != 0U ? awsAlliData1.Tag : awsAlliData2.Tag);
          this.HudStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17507U));
          GUIManager.Instance.AddHUDMessage(this.HudStr.ToString(), (ushort) byte.MaxValue);
          break;
        }
        if (GUIManager.Instance.bCheckAWSSchedule)
        {
          this.MsgStr.ClearString();
          this.MsgStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(this.LevelToStr[this.BtnIndexToLevel[sender.m_BtnID1 - 1]]));
          this.MsgStr.StringToFormat(awsAlliData1.Tag);
          this.MsgStr.StringToFormat(awsAlliData2.Tag);
          this.MsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17503U));
          GUIManager.Instance.OpenCheckAWSSchedule(this.MsgStr.ToString(), num2);
          break;
        }
        this.RequestPlayWar(num2);
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        this.RefreshData();
        break;
      case 1:
        this.RequestPlayWar((byte) arg2);
        break;
      case 2:
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.CloseMenu();
        break;
    }
  }

  private void Update()
  {
    if (this.bExit && (UnityEngine.Object) this.door != (UnityEngine.Object) null)
    {
      this.door.CloseMenu();
      this.bExit = false;
    }
    else
    {
      if (this.WinnerEff.IO != (byte) 0)
      {
        if ((UnityEngine.Object) this.WinnerEff.RotateingLight != (UnityEngine.Object) null)
          this.WinnerEff.RotateingLight.Rotate(0.0f, 0.0f, Time.deltaTime * 20f, Space.Self);
        if ((UnityEngine.Object) this.WinnerEff.lightBox != (UnityEngine.Object) null)
        {
          Color color = ((Graphic) this.WinnerEff.lightBox).color;
          float num = color.a + (float) ((double) this.WinnerEff.lightBoxStep * (double) Time.deltaTime * 0.5);
          if ((double) num < 0.30000001192092896 || (double) num > 1.0)
          {
            this.WinnerEff.lightBoxStep *= -1;
            num = Mathf.Clamp(num, 0.3f, 1f);
          }
          color.a = num;
          ((Graphic) this.WinnerEff.lightBox).color = color;
        }
      }
      if (!UI_AlliWarSchedule.Reconnect || (double) Time.time - (double) UI_AlliWarSchedule.ReconnectTimeCache < 3.0)
        return;
      UI_AlliWarSchedule.RequestScheduleData();
      UI_AlliWarSchedule.ReconnectTimeCache = Time.time;
      UI_AlliWarSchedule.Reconnect = false;
    }
  }

  public static void RequestScheduleData()
  {
    if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.AddSeqId();
    messagePacket.Protocol = Protocol._MSG_REQUEST_AWS_SCHEDULE;
    messagePacket.Add(ActivityManager.Instance.AW_Round);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.AWS_Schedule);
  }

  private void RequestPlayWar(byte MatchID)
  {
    if (MatchID == (byte) 0)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
        return;
      menu.CloseMenu();
    }
    else
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.AddSeqId();
      messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_REPLAY;
      byte data = UI_AlliWarSchedule.Step != UI_AlliWarSchedule.EAWSFightStep.Final ? (byte) 1 : (byte) 0;
      messagePacket.Add(data);
      messagePacket.Add((byte) 0);
      messagePacket.Add(MatchID);
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Activity);
    }
  }

  public void Refresh_FontTexture()
  {
    for (int index = 0; index < 16; ++index)
    {
      if ((UnityEngine.Object) this.Top16Nodes[index].StrNone != (UnityEngine.Object) null && ((Behaviour) this.Top16Nodes[index].StrNone).enabled)
      {
        ((Behaviour) this.Top16Nodes[index].StrNone).enabled = false;
        ((Behaviour) this.Top16Nodes[index].StrNone).enabled = true;
      }
      if ((UnityEngine.Object) this.Top16Nodes[index].AlliTag != (UnityEngine.Object) null && ((Behaviour) this.Top16Nodes[index].AlliTag).enabled)
      {
        ((Behaviour) this.Top16Nodes[index].AlliTag).enabled = false;
        ((Behaviour) this.Top16Nodes[index].AlliTag).enabled = true;
      }
    }
    for (int index = 0; index < 8; ++index)
    {
      if ((UnityEngine.Object) this.Top8Nodes[index].StrNone != (UnityEngine.Object) null && ((Behaviour) this.Top8Nodes[index].StrNone).enabled)
      {
        ((Behaviour) this.Top8Nodes[index].StrNone).enabled = false;
        ((Behaviour) this.Top8Nodes[index].StrNone).enabled = true;
      }
      if ((UnityEngine.Object) this.Top8Nodes[index].AlliTag != (UnityEngine.Object) null && ((Behaviour) this.Top8Nodes[index].AlliTag).enabled)
      {
        ((Behaviour) this.Top8Nodes[index].AlliTag).enabled = false;
        ((Behaviour) this.Top8Nodes[index].AlliTag).enabled = true;
      }
      if ((UnityEngine.Object) this.Top16Lines[index].Score != (UnityEngine.Object) null && ((Behaviour) this.Top16Lines[index].Score).enabled)
      {
        ((Behaviour) this.Top16Lines[index].Score).enabled = false;
        ((Behaviour) this.Top16Lines[index].Score).enabled = true;
      }
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((UnityEngine.Object) this.Top4Nodes[index].StrNone != (UnityEngine.Object) null && ((Behaviour) this.Top4Nodes[index].StrNone).enabled)
      {
        ((Behaviour) this.Top4Nodes[index].StrNone).enabled = false;
        ((Behaviour) this.Top4Nodes[index].StrNone).enabled = true;
      }
      if ((UnityEngine.Object) this.Top4Nodes[index].AlliTag != (UnityEngine.Object) null && ((Behaviour) this.Top4Nodes[index].AlliTag).enabled)
      {
        ((Behaviour) this.Top4Nodes[index].AlliTag).enabled = false;
        ((Behaviour) this.Top4Nodes[index].AlliTag).enabled = true;
      }
      if ((UnityEngine.Object) this.Top8Lines[index].Score != (UnityEngine.Object) null && ((Behaviour) this.Top8Lines[index].Score).enabled)
      {
        ((Behaviour) this.Top8Lines[index].Score).enabled = false;
        ((Behaviour) this.Top8Lines[index].Score).enabled = true;
      }
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((UnityEngine.Object) this.Top2Nodes[index].StrNone != (UnityEngine.Object) null && ((Behaviour) this.Top2Nodes[index].StrNone).enabled)
      {
        ((Behaviour) this.Top2Nodes[index].StrNone).enabled = false;
        ((Behaviour) this.Top2Nodes[index].StrNone).enabled = true;
      }
      if ((UnityEngine.Object) this.Top2Nodes[index].AlliTag != (UnityEngine.Object) null && ((Behaviour) this.Top2Nodes[index].AlliTag).enabled)
      {
        ((Behaviour) this.Top2Nodes[index].AlliTag).enabled = false;
        ((Behaviour) this.Top2Nodes[index].AlliTag).enabled = true;
      }
      if ((UnityEngine.Object) this.Top4Lines[index].Score != (UnityEngine.Object) null && ((Behaviour) this.Top4Lines[index].Score).enabled)
      {
        ((Behaviour) this.Top4Lines[index].Score).enabled = false;
        ((Behaviour) this.Top4Lines[index].Score).enabled = true;
      }
    }
    if ((UnityEngine.Object) this.Top2Lines[0].Score != (UnityEngine.Object) null && ((Behaviour) this.Top2Lines[0].Score).enabled)
    {
      ((Behaviour) this.Top2Lines[0].Score).enabled = false;
      ((Behaviour) this.Top2Lines[0].Score).enabled = true;
    }
    if ((UnityEngine.Object) this.Notes != (UnityEngine.Object) null && ((Behaviour) this.Notes).enabled)
    {
      ((Behaviour) this.Notes).enabled = false;
      ((Behaviour) this.Notes).enabled = true;
    }
    if (!((UnityEngine.Object) this.Title != (UnityEngine.Object) null) || !((Behaviour) this.Title).enabled)
      return;
    ((Behaviour) this.Title).enabled = false;
    ((Behaviour) this.Title).enabled = true;
  }

  public static byte NodePosS2C(byte sPos)
  {
    return sPos > (byte) 15 ? (byte) 0 : (byte) UI_AlliWarSchedule.NodePos_S2C[(int) sPos];
  }

  public static void RespSchedule(MessagePacket MP)
  {
    GUIManager.Instance.HideUILock(EUILock.AWS_Schedule);
    switch (MP.ReadByte())
    {
      case 0:
        UI_AlliWarSchedule.Step = (UI_AlliWarSchedule.EAWSFightStep) Mathf.Clamp((int) MP.ReadByte(), 0, 4);
        Array.Clear((Array) UI_AlliWarSchedule.AllianceData, 0, 16);
        Array.Clear((Array) UI_AlliWarSchedule.FightData, 0, 15);
        for (int index1 = 0; index1 < 16; ++index1)
        {
          int index2 = UI_AlliWarSchedule.NodePos_S2C[index1];
          UI_AlliWarSchedule.AllianceData[index2].ID = MP.ReadUInt();
          UI_AlliWarSchedule.AllianceData[index2].Emblem = MP.ReadUShort();
          UI_AlliWarSchedule.AllianceData[index2].Tag = MP.ReadString(3);
        }
        for (int index3 = 0; index3 < 15; ++index3)
        {
          int index4 = UI_AlliWarSchedule.LinePos_S2C[index3];
          UI_AlliWarSchedule.FightData[index4].Winner = MP.ReadByte();
          UI_AlliWarSchedule.FightData[index4].Alliance1Index = UI_AlliWarSchedule.NodePosS2C(MP.ReadByte());
          UI_AlliWarSchedule.FightData[index4].Alliance2Index = UI_AlliWarSchedule.NodePosS2C(MP.ReadByte());
          UI_AlliWarSchedule.FightData[index4].Score1 = MP.ReadByte();
          UI_AlliWarSchedule.FightData[index4].Score2 = MP.ReadByte();
          if (index3 == 1)
          {
            byte alliance1Index = UI_AlliWarSchedule.FightData[index4].Alliance1Index;
            UI_AlliWarSchedule.FightData[index4].Alliance1Index = UI_AlliWarSchedule.FightData[index4].Alliance2Index;
            UI_AlliWarSchedule.FightData[index4].Alliance2Index = alliance1Index;
            byte score1 = UI_AlliWarSchedule.FightData[index4].Score1;
            UI_AlliWarSchedule.FightData[index4].Score1 = UI_AlliWarSchedule.FightData[index4].Score2;
            UI_AlliWarSchedule.FightData[index4].Score2 = score1;
          }
        }
        if ((bool) (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_AlliWarSchedule))
        {
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_AlliWarSchedule, 0);
          break;
        }
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
          break;
        menu.OpenMenu(EGUIWindow.UI_AlliWarSchedule);
        break;
      case 1:
        if (DataManager.Instance.RoleAlliance.Id == 0U)
          break;
        UI_AlliWarSchedule.Reconnect = true;
        break;
    }
  }

  private enum e_AGS_UI_AlliWarSchedule
  {
    SpriteArray,
    SpriteArray2,
    BGFrame,
    Title,
    exitImage,
  }

  private enum e_AGS_BGFrame
  {
    WinnerEffect,
    Top16Nodes,
    Top8Nodes,
    Top4Nodes,
    Top2Nodes,
    Top16Lines,
    Top8Lines,
    Top4Lines,
    Top2Lines,
    WinnerEffect2,
    Notes,
    Btns,
  }

  private enum e_AGS_AlliNode
  {
    Unknown,
    IconBak,
    Tag,
    None,
    Mask,
  }

  private enum e_AGS_Line
  {
    VS,
    Score,
  }

  private enum e_AGS_Title
  {
    Text,
  }

  private enum e_AGS_exitImage
  {
    exitUIButton,
  }

  private enum e_UIAWSButtonID
  {
    ExitBtn,
    PlayBtn1,
    PlayBtn2,
    PlayBtn3,
    PlayBtn4,
    PlayBtn5,
    PlayBtn6,
    PlayBtn7,
    PlayBtn8,
    PlayBtn9,
    PlayBtn10,
    PlayBtn11,
    PlayBtn12,
    PlayBtn13,
    PlayBtn14,
    PlayBtn15,
  }

  public enum EAWSNodeState
  {
    Normal,
    UnKnown,
    NoAlliance,
    Empty,
  }

  public enum EAWSLineState
  {
    VS,
    Score,
    Empty,
    EmptyLightLine,
  }

  public enum EAWSLineStyle
  {
    Vertical,
    Horizontal,
  }

  public enum EAWSFightStep
  {
    Top16,
    Top8,
    Top4,
    Top2,
    Final,
  }

  public class AWS_NodeData
  {
    public UI_AlliWarSchedule.EAWSNodeState State;
    public Image NodeBack;
    public UIText AlliTag;
    public RectTransform ElbemTrans;
    public Image ImgUnknown;
    public UIText StrNone;
    public GameObject IconBackObj;
    public Image Mask;
  }

  public class AWS_LineData
  {
    public UI_AlliWarSchedule.EAWSLineStyle Style;
    public UI_AlliWarSchedule.EAWSLineState State;
    public Image Line;
    public UIText Score;
    public Image ImgVS;
    public CString StrScore;
    public UI_AlliWarSchedule.AWS_NodeData Node1;
    public UI_AlliWarSchedule.AWS_NodeData Node2;
    public UI_AlliWarSchedule.AWS_LineData ChildLine1;
    public UI_AlliWarSchedule.AWS_LineData ChildLine2;
    public byte FightDataIndex;
  }

  public struct WinnerEffect
  {
    public byte IO;
    public Transform EffectNode1;
    public Transform EffectNode2;
    public Transform RotateingLight;
    public Image lightBox;
    public int lightBoxStep;
  }

  public struct AWS_AlliData
  {
    public uint ID;
    public ushort Emblem;
    public string Tag;
  }

  public struct AWS_FightData
  {
    public byte Winner;
    public byte Alliance1Index;
    public byte Alliance2Index;
    public byte Score1;
    public byte Score2;
  }
}
