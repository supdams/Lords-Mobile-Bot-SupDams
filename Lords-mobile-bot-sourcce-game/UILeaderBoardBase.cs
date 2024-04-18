// Decompiled with JetBrains decompiler
// Type: UILeaderBoardBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UILeaderBoardBase : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  protected Transform AGS_Form;
  protected ScrollPanel AGS_Panel1;
  protected ScrollPanel AGS_Panel2;
  protected Door door;
  protected float GetPointTime;
  protected Image POPLight1;
  protected Image POPLight3;
  protected bool LoadComplet;
  protected bool DataReady;
  protected List<float> SPHeight;
  protected CString[,] SortTextArray = new CString[4, 12];
  protected CString Ranking;
  protected CString RankValue;
  public static int[] TopIndex = new int[20];
  private static readonly int[] CommonBoardSize = new int[3]
  {
    102,
    385,
    289
  };

  public override void OnOpen(int arg1, int arg2)
  {
    this.door = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    this.SPHeight = new List<float>();
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
    UIButtonHint uiButtonHint = ((Component) component26).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_eHint = EUIButtonHint.UIArena_Hint;
    uiButtonHint.m_Handler = (MonoBehaviour) this;
    uiButtonHint.ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
    this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(3).gameObject.SetActive(false);
    this.AGS_Form.GetChild(7).GetChild(1).GetChild(1).GetChild(8).gameObject.SetActive(false);
    this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    UIButton component27 = this.AGS_Form.GetChild(9).GetComponent<UIButton>();
    component27.m_Handler = (IUIButtonClickHandler) this;
    component27.m_EffectType = e_EffectType.e_Scale;
    component27.m_BtnID1 = 99;
    ((Component) component27).gameObject.SetActive(false);
    UIText component28 = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
    component28.font = ttfFont;
    component28.text = DataManager.Instance.mStringTable.GetStringByID(11025U);
    Transform child1 = this.AGS_Form.GetChild(13).GetChild(1);
    if ((Object) child1 != (Object) null)
      child1.gameObject.SetActive(false);
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component29 = ((Component) component27).gameObject.GetComponent<RectTransform>();
      ((Transform) component29).localScale = new Vector3(-1f, 1f, 1f);
      component29.anchoredPosition = new Vector2(component29.anchoredPosition.x + 44f, component29.anchoredPosition.y);
      ((Transform) this.AGS_Form.GetChild(12).gameObject.GetComponent<RectTransform>()).localScale = new Vector3(-1f, 1f, 1f);
    }
    Transform child2 = this.AGS_Form.GetChild(3).GetChild(0);
    GUIManager.Instance.InitianHeroItemImg(child2, eHeroOrItem.Hero, DataManager.Instance.RoleAttr.Head, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
    child2.gameObject.SetActive(false);
    Transform child3 = this.AGS_Form.GetChild(3).GetChild(1);
    GUIManager.Instance.InitBadgeTotem(child3, DataManager.Instance.RoleAlliance.Emblem);
    child3.gameObject.SetActive(false);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.Ranking);
    StringManager.Instance.DeSpawnString(this.RankValue);
    for (int index1 = 0; index1 < this.SortTextArray.GetLength(0); ++index1)
    {
      for (int index2 = 0; index2 < this.SortTextArray.GetLength(1); ++index2)
        StringManager.Instance.DeSpawnString(this.SortTextArray[index1, index2]);
    }
  }

  public virtual void OnButtonClick(UIButton sender)
  {
  }

  public virtual void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
  }

  public virtual void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public virtual void OnButtonDown(UIButtonHint sender)
  {
  }

  public virtual void OnButtonUp(UIButtonHint sender)
  {
  }

  protected virtual void CreateBoard()
  {
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIText>();
    if ((Object) component2 != (Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIText>();
    if ((Object) component3 != (Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.AGS_Form.GetChild(5).GetComponent<UIText>();
    if ((Object) component4 != (Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    if ((Object) this.AGS_Panel1 != (Object) null && this.AGS_Panel1.gameObject.activeInHierarchy)
    {
      Transform child1 = this.AGS_Panel1.transform.GetChild(0);
      for (int index = 0; index < child1.childCount; ++index)
      {
        Transform child2 = child1.GetChild(index);
        if (child2.gameObject.activeInHierarchy)
        {
          UIText component5 = child2.GetChild(4).GetComponent<UIText>();
          if ((Object) component5 != (Object) null && ((Behaviour) component5).enabled)
          {
            ((Behaviour) component5).enabled = false;
            ((Behaviour) component5).enabled = true;
          }
          UIText component6 = child2.GetChild(5).GetComponent<UIText>();
          if ((Object) component6 != (Object) null && ((Behaviour) component6).enabled)
          {
            ((Behaviour) component6).enabled = false;
            ((Behaviour) component6).enabled = true;
          }
          UIText component7 = child2.GetChild(6).GetComponent<UIText>();
          if ((Object) component7 != (Object) null && ((Behaviour) component7).enabled)
          {
            ((Behaviour) component7).enabled = false;
            ((Behaviour) component7).enabled = true;
          }
        }
      }
    }
    if ((Object) this.AGS_Panel2 != (Object) null && this.AGS_Panel2.gameObject.activeInHierarchy)
    {
      Transform child3 = this.AGS_Panel2.transform.GetChild(0);
      for (int index = 0; index < child3.childCount; ++index)
      {
        Transform child4 = child3.GetChild(index);
        if (child4.GetChild(0).gameObject.activeInHierarchy)
        {
          UIText component8 = child4.GetChild(0).GetChild(4).GetComponent<UIText>();
          if ((Object) component8 != (Object) null && ((Behaviour) component8).enabled)
          {
            ((Behaviour) component8).enabled = false;
            ((Behaviour) component8).enabled = true;
          }
          UIText component9 = child4.GetChild(0).GetChild(5).GetComponent<UIText>();
          if ((Object) component9 != (Object) null && ((Behaviour) component9).enabled)
          {
            ((Behaviour) component9).enabled = false;
            ((Behaviour) component9).enabled = true;
          }
          UIText component10 = child4.GetChild(0).GetChild(6).GetComponent<UIText>();
          if ((Object) component10 != (Object) null && ((Behaviour) component10).enabled)
          {
            ((Behaviour) component10).enabled = false;
            ((Behaviour) component10).enabled = true;
          }
          UIText component11 = child4.GetChild(0).GetChild(7).GetComponent<UIText>();
          if ((Object) component11 != (Object) null && ((Behaviour) component11).enabled)
          {
            ((Behaviour) component11).enabled = false;
            ((Behaviour) component11).enabled = true;
          }
        }
        if (child4.GetChild(1).gameObject.activeInHierarchy)
        {
          UIText component12 = child4.GetChild(1).GetChild(4).GetComponent<UIText>();
          if ((Object) component12 != (Object) null && ((Behaviour) component12).enabled)
          {
            ((Behaviour) component12).enabled = false;
            ((Behaviour) component12).enabled = true;
          }
          UIText component13 = child4.GetChild(1).GetChild(5).GetComponent<UIText>();
          if ((Object) component13 != (Object) null && ((Behaviour) component13).enabled)
          {
            ((Behaviour) component13).enabled = false;
            ((Behaviour) component13).enabled = true;
          }
          UIText component14 = child4.GetChild(1).GetChild(6).GetComponent<UIText>();
          if ((Object) component14 != (Object) null && ((Behaviour) component14).enabled)
          {
            ((Behaviour) component14).enabled = false;
            ((Behaviour) component14).enabled = true;
          }
          UIText component15 = child4.GetChild(1).GetChild(7).GetComponent<UIText>();
          if ((Object) component15 != (Object) null && ((Behaviour) component15).enabled)
          {
            ((Behaviour) component15).enabled = false;
            ((Behaviour) component15).enabled = true;
          }
          UIText component16 = child4.GetChild(1).GetChild(9).GetComponent<UIText>();
          if ((Object) component16 != (Object) null && ((Behaviour) component16).enabled)
          {
            ((Behaviour) component16).enabled = false;
            ((Behaviour) component16).enabled = true;
          }
        }
      }
    }
    UIText component17 = this.AGS_Form.GetChild(13).GetChild(0).GetComponent<UIText>();
    if ((Object) component17 != (Object) null && ((Behaviour) component17).enabled)
    {
      ((Behaviour) component17).enabled = false;
      ((Behaviour) component17).enabled = true;
    }
    UIText component18 = this.AGS_Form.GetChild(14).GetChild(0).GetComponent<UIText>();
    if ((Object) component18 != (Object) null && ((Behaviour) component18).enabled)
    {
      ((Behaviour) component18).enabled = false;
      ((Behaviour) component18).enabled = true;
    }
    UIText component19 = this.AGS_Form.GetChild(14).GetChild(1).GetComponent<UIText>();
    if ((Object) component19 != (Object) null && ((Behaviour) component19).enabled)
    {
      ((Behaviour) component19).enabled = false;
      ((Behaviour) component19).enabled = true;
    }
    UIText component20 = this.AGS_Form.GetChild(14).GetChild(2).GetComponent<UIText>();
    if ((Object) component20 != (Object) null && ((Behaviour) component20).enabled)
    {
      ((Behaviour) component20).enabled = false;
      ((Behaviour) component20).enabled = true;
    }
    UIText component21 = this.AGS_Form.GetChild(14).GetChild(4).GetComponent<UIText>();
    if (!((Object) component21 != (Object) null) || !((Behaviour) component21).enabled)
      return;
    ((Behaviour) component21).enabled = false;
    ((Behaviour) component21).enabled = true;
  }

  protected void SetOpenType(UILeaderBoardBase.e_OpenType openType)
  {
    switch (openType)
    {
      case UILeaderBoardBase.e_OpenType.BoardTypes:
        this.AGS_Form.GetChild(6).gameObject.SetActive(true);
        this.AGS_Form.GetChild(7).gameObject.SetActive(false);
        break;
      case UILeaderBoardBase.e_OpenType.BoardContent:
        this.AGS_Form.GetChild(6).gameObject.SetActive(false);
        this.AGS_Form.GetChild(7).gameObject.SetActive(true);
        break;
    }
  }

  protected void SetDefaultSize()
  {
    RectTransform component1 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<RectTransform>();
    int x1 = UILeaderBoardBase.CommonBoardSize[0];
    RectTransform component2 = ((Transform) component1).GetChild(0).GetChild(5).GetComponent<RectTransform>();
    component2.anchoredPosition = new Vector2((float) (x1 + UILeaderBoardBase.CommonBoardSize[1] / 2), component2.anchoredPosition.y);
    component2.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoardBase.CommonBoardSize[1]);
    RectTransform component3 = ((Transform) component1).GetChild(0).GetChild(1).GetComponent<RectTransform>();
    component3.anchoredPosition = new Vector2((float) x1, component3.anchoredPosition.y);
    component3.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoardBase.CommonBoardSize[1]);
    RectTransform component4 = ((Transform) component1).GetChild(1).GetChild(5).GetComponent<RectTransform>();
    component4.anchoredPosition = new Vector2((float) (x1 + 10), component4.anchoredPosition.y);
    component4.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) (UILeaderBoardBase.CommonBoardSize[1] - 20));
    RectTransform component5 = ((Transform) component1).GetChild(1).GetChild(1).GetComponent<RectTransform>();
    component5.anchoredPosition = new Vector2((float) x1, component5.anchoredPosition.y);
    component5.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoardBase.CommonBoardSize[1]);
    int x2 = x1 + UILeaderBoardBase.CommonBoardSize[1];
    RectTransform component6 = ((Transform) component1).GetChild(0).GetChild(6).GetComponent<RectTransform>();
    component6.anchoredPosition = new Vector2((float) (x2 + UILeaderBoardBase.CommonBoardSize[2] / 2), component6.anchoredPosition.y);
    component6.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoardBase.CommonBoardSize[2]);
    RectTransform component7 = ((Transform) component1).GetChild(0).GetChild(2).GetComponent<RectTransform>();
    component7.anchoredPosition = new Vector2((float) x2, component7.anchoredPosition.y);
    component7.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoardBase.CommonBoardSize[2]);
    RectTransform component8 = ((Transform) component1).GetChild(1).GetChild(6).GetComponent<RectTransform>();
    component8.anchoredPosition = new Vector2((float) (x2 + 10), component8.anchoredPosition.y);
    component8.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) (UILeaderBoardBase.CommonBoardSize[2] - 96));
    ((Component) component8).GetComponent<UIText>().alignment = TextAnchor.MiddleRight;
    RectTransform component9 = ((Transform) component1).GetChild(1).GetChild(2).GetComponent<RectTransform>();
    component9.anchoredPosition = new Vector2((float) x2, component9.anchoredPosition.y);
    component9.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, (float) UILeaderBoardBase.CommonBoardSize[2]);
  }

  protected enum e_AGS_UI_LeaderBoard_Editor
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

  protected enum e_AGS_PlayerSelf
  {
    UIHIBtn,
    Alliance,
    Position,
    Power,
  }

  protected enum e_AGS_SwitchTags
  {
    Players,
    Alliance,
  }

  protected enum e_AGS_FunctionlPanel
  {
    Panel1,
    Panel1Item,
    KingdomIcon,
  }

  protected enum e_AGS_Panel1Item
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

  protected enum e_AGS_LeaderBoardPanel
  {
    Panel2,
    Panel2Item,
  }

  protected enum e_AGS_Panel2Item
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

  protected enum e_AGS_ScoreChange
  {
    name,
    score,
    scorefly,
    updown,
    updownRanking,
  }

  protected enum e_OpenType
  {
    BoardTypes,
    BoardContent,
  }

  protected enum UIRecallMemoryPos
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
    AllianceHunt,
    AllianceVSGroup,
    AllianceVSAlli,
    AllianceWarGroup,
    Max,
  }
}
