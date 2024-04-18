// Decompiled with JetBrains decompiler
// Type: ActivityWindow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class ActivityWindow : 
  UIBehaviour,
  UILoadImageHander,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  private Transform m_transform;
  private string abName = "UI/ActivityWindow";
  private int abKey;
  private Door door;
  private GUIManager GM;
  private DataManager DM;
  private ActivityManager AM;
  private StringManager SM;
  private AllianceWarManager AWM;
  private e_ActivityType WindowType;
  private IActivityWindow m_handler;
  private ActivityDataType tmpData;
  private CString HintStr;
  private GameObject Title1GO;
  private GameObject Title2GO;
  private UIText TitleRankText;
  private UIText Title2Text;
  private CString TitleRankTextStr;
  private GameObject TimeGO;
  private GameObject InfoGO;
  private UISpritesArray TimeSA;
  private UISpritesArray TitleSA1;
  private UISpritesArray TitleSA2;
  private UIText TimeTitle;
  private UIText TimeTitle2;
  private UIText TimeText;
  private CString TimeStr;
  private GameObject Check1GO;
  private GameObject Check2GO;
  private UIText SignUpCount;
  private UIText MessageText1;
  private UIText MessageText2;
  private CString SignUpCountStr;
  private CString MessageText1Str;
  private CString MessageText2Str;
  private Vector2 RightPos = new Vector2(316.6f, 127.3f);
  private UIText MyNoText;
  private UIText StageText;
  private UIText FTimeText;
  private UIText ReviewText;
  private CString MyNoTextStr;
  private CString FTimeTextStr;
  private GameObject Review1GO;
  private GameObject Review2GO;
  private GameObject BtnGO;
  private UIText No1Text;
  private UIText No2Text;
  private CString No1TextStr;
  private CString No2TextStr;
  private GameObject SBtnGO;
  private List<UIText> rebuildText = new List<UIText>();

  protected virtual void Awake()
  {
    this.GM = GUIManager.Instance;
    this.DM = DataManager.Instance;
    this.AM = ActivityManager.Instance;
    this.SM = StringManager.Instance;
    this.AWM = this.AM.AllianceWarMgr;
    this.door = this.GM.FindMenu(EGUIWindow.Door) as Door;
    AssetBundle assetBundle = AssetManager.GetAssetBundle(this.abName, out this.abKey);
    if ((Object) assetBundle == (Object) null)
      return;
    GameObject gameObject = (GameObject) Object.Instantiate(assetBundle.mainAsset);
    if ((Object) gameObject == (Object) null)
    {
      AssetManager.UnloadAssetBundle(this.abKey);
    }
    else
    {
      gameObject.transform.SetParent(((Component) this).transform, false);
      this.m_transform = gameObject.transform;
      this.m_transform.SetAsFirstSibling();
      this.GM.m_ActivityWindow = this;
      this.tmpData = this.AM.AllianceWarData;
      Font ttfFont = this.GM.GetTTFFont();
      this.m_transform.GetChild(7).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.m_transform.GetChild(7).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      this.m_transform.GetChild(7).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      if (this.GM.bOpenOnIPhoneX)
        ((Behaviour) this.m_transform.GetChild(7).GetComponent<CustomImage>()).enabled = false;
      this.InfoGO = this.m_transform.GetChild(6).gameObject;
      this.InfoGO.AddComponent<ArabicItemTextureRot>();
      this.m_transform.GetChild(6).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.Title1GO = this.m_transform.GetChild(4).gameObject;
      this.Title2GO = this.m_transform.GetChild(5).gameObject;
      UIText component = this.m_transform.GetChild(4).GetChild(0).GetComponent<UIText>();
      component.font = ttfFont;
      component.text = this.DM.mStringTable.GetStringByID(17029U);
      this.rebuildText.Add(component);
      UIButtonHint uiButtonHint = this.m_transform.GetChild(4).GetChild(1).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint.Parm1 = (ushort) 0;
      uiButtonHint.ScrollID = (byte) 1;
      uiButtonHint.m_Handler = (MonoBehaviour) this;
      this.TitleRankText = this.m_transform.GetChild(4).GetChild(1).GetChild(0).GetComponent<UIText>();
      this.TitleRankText.font = ttfFont;
      this.TitleRankText.text = this.DM.mStringTable.GetStringByID(17029U);
      this.TitleRankTextStr = this.SM.SpawnString();
      this.rebuildText.Add(this.TitleRankText);
      this.TitleSA1 = this.m_transform.GetChild(4).GetComponent<UISpritesArray>();
      this.TitleSA2 = this.m_transform.GetChild(4).GetChild(1).GetComponent<UISpritesArray>();
      this.Title2Text = this.m_transform.GetChild(5).GetChild(0).GetComponent<UIText>();
      this.Title2Text.font = ttfFont;
      this.rebuildText.Add(this.Title2Text);
      this.TimeGO = this.m_transform.GetChild(3).gameObject;
      this.TimeSA = this.m_transform.GetChild(3).GetComponent<UISpritesArray>();
      this.TimeTitle = this.m_transform.GetChild(3).GetChild(0).GetComponent<UIText>();
      this.TimeTitle.font = ttfFont;
      this.rebuildText.Add(this.TimeTitle);
      this.TimeText = this.m_transform.GetChild(3).GetChild(1).GetComponent<UIText>();
      this.TimeText.font = ttfFont;
      this.rebuildText.Add(this.TimeText);
      this.TimeTitle2 = this.m_transform.GetChild(3).GetChild(2).GetComponent<UIText>();
      this.TimeTitle2.font = ttfFont;
      this.rebuildText.Add(this.TimeTitle2);
      ((Behaviour) this.TimeTitle2).enabled = false;
      ((Component) this.TimeTitle2).gameObject.SetActive(true);
      this.TimeStr = this.SM.SpawnString();
      this.SetTimeTitle();
      this.SetTimeStr();
    }
  }

  protected virtual void OnDestroy()
  {
    this.SM.DeSpawnString(this.HintStr);
    this.SM.DeSpawnString(this.TitleRankTextStr);
    this.SM.DeSpawnString(this.TimeStr);
    this.SM.DeSpawnString(this.SignUpCountStr);
    this.SM.DeSpawnString(this.MessageText1Str);
    this.SM.DeSpawnString(this.MessageText2Str);
    this.SM.DeSpawnString(this.MyNoTextStr);
    this.SM.DeSpawnString(this.FTimeTextStr);
    this.SM.DeSpawnString(this.No1TextStr);
    this.SM.DeSpawnString(this.No2TextStr);
    if ((Object) this.GM.m_ActivityWindow == (Object) this)
      this.GM.m_ActivityWindow = (ActivityWindow) null;
    base.OnDestroy();
  }

  public void Initial(e_ActivityType Type, IActivityWindow handler)
  {
    this.WindowType = Type;
    this.m_handler = handler;
    Font ttfFont = this.GM.GetTTFFont();
    switch (Type)
    {
      case e_ActivityType.SignUp:
        Transform child1 = this.m_transform.GetChild(8);
        child1.gameObject.SetActive(true);
        UIButtonHint uiButtonHint = child1.GetChild(0).gameObject.AddComponent<UIButtonHint>();
        uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
        uiButtonHint.Parm1 = (ushort) 1;
        uiButtonHint.ScrollID = (byte) 1;
        uiButtonHint.m_Handler = (MonoBehaviour) this;
        this.Check1GO = child1.GetChild(1).gameObject;
        child1.GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
        this.Check2GO = child1.GetChild(2).gameObject;
        child1.GetChild(2).gameObject.AddComponent<ArabicItemTextureRot>();
        UIText component1 = child1.GetChild(1).GetChild(0).GetComponent<UIText>();
        component1.font = ttfFont;
        component1.text = this.DM.mStringTable.GetStringByID(17004U);
        this.rebuildText.Add(component1);
        UIText component2 = child1.GetChild(2).GetChild(0).GetComponent<UIText>();
        component2.font = ttfFont;
        component2.text = this.DM.mStringTable.GetStringByID(17032U);
        this.rebuildText.Add(component2);
        this.MessageText1 = child1.GetChild(3).GetComponent<UIText>();
        this.MessageText1.font = ttfFont;
        this.MessageText1Str = this.SM.SpawnString(150);
        this.rebuildText.Add(this.MessageText1);
        this.MessageText2 = child1.GetChild(4).GetComponent<UIText>();
        this.MessageText2.font = ttfFont;
        this.MessageText2Str = this.SM.SpawnString(150);
        this.rebuildText.Add(this.MessageText2);
        this.SignUpCount = child1.GetChild(5).GetComponent<UIText>();
        this.SignUpCount.font = ttfFont;
        this.SignUpCountStr = this.SM.SpawnString();
        this.rebuildText.Add(this.SignUpCount);
        break;
      case e_ActivityType.Run:
      case e_ActivityType.RunFail:
        Transform child2 = this.m_transform.GetChild(9);
        child2.gameObject.SetActive(true);
        this.MyNoText = child2.GetChild(2).GetComponent<UIText>();
        this.MyNoText.font = ttfFont;
        this.MyNoTextStr = this.SM.SpawnString(100);
        this.rebuildText.Add(this.MyNoText);
        this.StageText = child2.GetChild(3).GetComponent<UIText>();
        this.StageText.font = ttfFont;
        this.rebuildText.Add(this.StageText);
        this.FTimeText = child2.GetChild(4).GetComponent<UIText>();
        this.FTimeText.font = ttfFont;
        this.rebuildText.Add(this.FTimeText);
        this.FTimeTextStr = this.SM.SpawnString(100);
        this.BtnGO = child2.GetChild(5).gameObject;
        child2.GetChild(5).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.Review1GO = child2.GetChild(6).gameObject;
        this.Review2GO = child2.GetChild(7).gameObject;
        this.ReviewText = child2.GetChild(8).GetComponent<UIText>();
        this.ReviewText.font = ttfFont;
        this.rebuildText.Add(this.ReviewText);
        if (Type != e_ActivityType.RunFail)
        {
          if (this.AWM.bReplaying)
          {
            this.m_transform.GetChild(1).gameObject.SetActive(false);
            this.m_transform.GetChild(2).gameObject.SetActive(false);
            this.InfoGO.SetActive(false);
            this.TimeGO.SetActive(false);
            this.BtnGO.SetActive(false);
            this.Title1GO.SetActive(false);
            this.Title2GO.SetActive(true);
            this.Review1GO.SetActive(true);
            this.Review2GO.SetActive(false);
            this.Title2Text.text = this.DM.mStringTable.GetStringByID(14635U);
            this.ReviewText.text = this.DM.mStringTable.GetStringByID(14616U);
            ((Component) this.ReviewText).gameObject.SetActive(true);
            break;
          }
          if (this.AWM.MyAllySide == (byte) 0)
          {
            this.m_transform.GetChild(1).gameObject.SetActive(false);
            this.m_transform.GetChild(2).gameObject.SetActive(false);
            this.InfoGO.SetActive(false);
            this.TimeGO.SetActive(false);
            this.BtnGO.SetActive(false);
            this.Title1GO.SetActive(false);
            this.Title2GO.SetActive(true);
            this.Review1GO.SetActive(false);
            this.Review2GO.SetActive(true);
            this.Title2Text.text = this.DM.mStringTable.GetStringByID(14614U);
            this.ReviewText.text = this.DM.mStringTable.GetStringByID(14615U);
            ((Component) this.ReviewText).gameObject.SetActive(true);
            break;
          }
          break;
        }
        break;
      case e_ActivityType.Ranking:
        Transform child3 = this.m_transform.GetChild(10);
        child3.gameObject.SetActive(true);
        this.No1Text = child3.GetChild(0).GetComponent<UIText>();
        this.No1Text.font = ttfFont;
        this.No1TextStr = this.SM.SpawnString(100);
        this.rebuildText.Add(this.No1Text);
        this.No2Text = child3.GetChild(1).GetComponent<UIText>();
        this.No2Text.font = ttfFont;
        this.No2TextStr = this.SM.SpawnString(100);
        this.rebuildText.Add(this.No2Text);
        this.SBtnGO = child3.GetChild(2).gameObject;
        child3.GetChild(2).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        break;
    }
    this.SetTitleRank();
    this.SetTopText();
  }

  private void SetTimeTitle()
  {
    ((Behaviour) this.TimeTitle).enabled = false;
    ((Behaviour) this.TimeTitle2).enabled = false;
    switch (this.AM.AW_State)
    {
      case EAllianceWarState.EAWS_SignUp:
        ((Behaviour) this.TimeTitle).enabled = true;
        this.TimeTitle.text = this.DM.mStringTable.GetStringByID(17001U);
        this.TimeSA.SetSpriteIndex(0);
        break;
      case EAllianceWarState.EAWS_Prepare:
        ((Behaviour) this.TimeTitle).enabled = true;
        this.TimeTitle.text = this.DM.mStringTable.GetStringByID(17030U);
        this.TimeSA.SetSpriteIndex(0);
        break;
      case EAllianceWarState.EAWS_Run:
        ((Behaviour) this.TimeTitle).enabled = true;
        this.TimeTitle.text = this.DM.mStringTable.GetStringByID(8110U);
        this.TimeSA.SetSpriteIndex(0);
        break;
      case EAllianceWarState.EAWS_Replay:
        this.TimeSA.SetSpriteIndex(1);
        ((Behaviour) this.TimeTitle2).enabled = true;
        if (this.DM.RoleAlliance.Id != 0U && (int) this.DM.RoleAlliance.Id == (int) this.AM.AW_SignUpAllianceID && this.AM.AW_NowAllianceEnterWar != (byte) 0 && this.AM.AW_GetGift == (byte) 0)
        {
          this.TimeTitle2.text = this.DM.mStringTable.GetStringByID(747U);
          break;
        }
        this.TimeTitle2.text = this.DM.mStringTable.GetStringByID(14608U);
        break;
      default:
        ((Behaviour) this.TimeTitle).enabled = true;
        this.TimeTitle.text = this.DM.mStringTable.GetStringByID(8111U);
        this.TimeSA.SetSpriteIndex(3);
        break;
    }
  }

  private void SetTimeStr()
  {
    if ((Object) this.TimeText == (Object) null)
      return;
    this.TimeStr.Length = 0;
    if (this.AM.AW_State != EAllianceWarState.EAWS_Replay)
      GameConstants.GetTimeString(this.TimeStr, (uint) this.tmpData.EventCountTime, hideTimeIfDays: true, showZeroHour: false);
    this.TimeText.text = this.TimeStr.ToString();
    this.TimeText.SetAllDirty();
    this.TimeText.cachedTextGenerator.Invalidate();
  }

  private void SetTopTime()
  {
    if ((Object) this.FTimeText == (Object) null)
      return;
    if (this.WindowType == e_ActivityType.Run && !this.AWM.bReplaying || this.WindowType == e_ActivityType.RunFail)
    {
      CString cstring = this.SM.StaticString1024();
      long num = this.AM.AW_RoundBeginTime + (long) this.AM.AW_PrepareTime;
      ushort ID;
      if (this.AM.ServerEventTime <= num)
      {
        ID = (ushort) 14609;
        GameConstants.GetTimeString(cstring, (uint) (num - this.AM.ServerEventTime), hideTimeIfDays: true, showZeroHour: false);
        ((Graphic) this.FTimeText).color = new Color(0.9921f, 0.9058f, 0.3294f);
      }
      else
      {
        ID = (ushort) 14617;
        GameConstants.GetTimeString(cstring, (uint) (this.AM.AW_RoundEndTime - this.AM.ServerEventTime), hideTimeIfDays: true, showZeroHour: false);
        ((Graphic) this.FTimeText).color = new Color(0.0313f, 0.9568f, 0.2901f);
      }
      this.FTimeTextStr.Length = 0;
      this.FTimeTextStr.StringToFormat(cstring);
      this.FTimeTextStr.AppendFormat(this.DM.mStringTable.GetStringByID((uint) ID));
      this.FTimeText.text = this.FTimeTextStr.ToString();
      this.FTimeText.SetAllDirty();
      this.FTimeText.cachedTextGenerator.Invalidate();
    }
    else
      this.FTimeText.text = string.Empty;
  }

  public void SetTopTimeVivsible(bool bVisible)
  {
    if ((Object) this.FTimeText == (Object) null)
      return;
    ((Component) this.FTimeText).gameObject.SetActive(bVisible);
    if (!bVisible)
      return;
    this.SetTopTime();
  }

  private void SetTitleRank()
  {
    int index = this.AM.AW_Rank <= (byte) 0 ? 0 : ((int) this.AM.AW_Rank - 1) / 5;
    this.TitleSA1.SetSpriteIndex(index);
    this.TitleSA2.SetSpriteIndex(index);
    this.TitleRankTextStr.Length = 0;
    this.TitleRankTextStr.IntToFormat(this.AM.AW_Rank <= (byte) 0 ? 1L : (long) this.AM.AW_Rank);
    this.TitleRankTextStr.AppendFormat("{0}");
    this.TitleRankText.text = this.TitleRankTextStr.ToString();
    this.TitleRankText.SetAllDirty();
    this.TitleRankText.cachedTextGenerator.Invalidate();
    if (this.AM.AW_Rank >= (byte) 21 && this.AM.AW_Rank <= (byte) 25)
      ((Graphic) this.TitleRankText).rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
    else
      ((Graphic) this.TitleRankText).rectTransform.anchoredPosition = new Vector2(0.0f, 5f);
  }

  private void SetRoundText()
  {
    if (!((Object) this.StageText != (Object) null))
      return;
    switch (!this.AWM.bReplaying ? this.AM.AW_Round : this.AWM.ReplayGame)
    {
      case 1:
        this.StageText.text = this.DM.mStringTable.GetStringByID(14604U);
        break;
      case 2:
        this.StageText.text = this.DM.mStringTable.GetStringByID(14605U);
        break;
      case 3:
        this.StageText.text = this.DM.mStringTable.GetStringByID(14606U);
        break;
      case 4:
        this.StageText.text = this.DM.mStringTable.GetStringByID(14607U);
        break;
      default:
        this.StageText.text = string.Empty;
        break;
    }
  }

  private void SetTopText()
  {
    if (this.WindowType == e_ActivityType.SignUp)
    {
      byte registerCount = this.AM.AllianceWarMgr.GetRegisterCount();
      this.SignUpCountStr.Length = 0;
      this.SignUpCountStr.IntToFormat((long) registerCount);
      this.SignUpCountStr.AppendFormat(this.DM.mStringTable.GetStringByID(1340U));
      this.SignUpCount.text = this.SignUpCountStr.ToString();
      this.SignUpCount.SetAllDirty();
      this.SignUpCount.cachedTextGenerator.Invalidate();
      this.Check1GO.SetActive(false);
      this.Check2GO.SetActive(false);
      ((Component) this.MessageText1).gameObject.SetActive(false);
      ((Component) this.MessageText2).gameObject.SetActive(false);
      if (this.AM.AW_State == EAllianceWarState.EAWS_SignUp)
      {
        if (this.DM.RoleAlliance.Id == 0U)
          this.Check2GO.SetActive(true);
        else if ((int) registerCount >= (int) this.AM.AW_MemberCount)
        {
          this.Check1GO.SetActive(true);
          ((Component) this.MessageText2).gameObject.SetActive(true);
          this.MessageText2Str.Length = 0;
          this.MessageText2Str.IntToFormat((long) this.AM.AW_MemberCount);
          this.MessageText2Str.AppendFormat(this.DM.mStringTable.GetStringByID(17038U));
          this.MessageText2.text = this.MessageText2Str.ToString();
          this.MessageText2.SetAllDirty();
          this.MessageText2.cachedTextGenerator.Invalidate();
        }
        else
        {
          ((Component) this.MessageText1).gameObject.SetActive(true);
          this.MessageText1Str.Length = 0;
          this.MessageText1Str.IntToFormat((long) this.AM.AW_MemberCount);
          this.MessageText1Str.AppendFormat(this.DM.mStringTable.GetStringByID(17003U));
          this.MessageText1.text = this.MessageText1Str.ToString();
          this.MessageText1.SetAllDirty();
          this.MessageText1.cachedTextGenerator.Invalidate();
        }
      }
      else if (this.DM.RoleAlliance.Id == 0U)
        this.Check2GO.SetActive(true);
      else if ((int) registerCount < (int) this.AM.AW_MemberCount)
      {
        this.Check2GO.SetActive(true);
        ((Component) this.MessageText2).gameObject.SetActive(true);
        this.MessageText2Str.Length = 0;
        this.MessageText2Str.IntToFormat((long) this.AM.AW_MemberCount);
        this.MessageText2Str.AppendFormat(this.DM.mStringTable.GetStringByID(17003U));
        this.MessageText2.text = this.MessageText2Str.ToString();
        this.MessageText2.SetAllDirty();
        this.MessageText2.cachedTextGenerator.Invalidate();
      }
      else
      {
        this.Check1GO.SetActive(true);
        ((Component) this.MessageText2).gameObject.SetActive(true);
        this.MessageText2Str.Length = 0;
        this.MessageText2Str.IntToFormat((long) this.AM.AW_MemberCount);
        this.MessageText2Str.AppendFormat(this.DM.mStringTable.GetStringByID(17038U));
        this.MessageText2.text = this.MessageText2Str.ToString();
        this.MessageText2.SetAllDirty();
        this.MessageText2.cachedTextGenerator.Invalidate();
      }
    }
    else if (this.WindowType == e_ActivityType.Run || this.WindowType == e_ActivityType.RunFail)
    {
      this.SetRoundText();
      if (this.AWM.bReplaying)
        this.FTimeText.text = string.Empty;
      else
        this.SetTopTime();
      if (this.AWM.MyPosition != (byte) 0)
      {
        if (this.AWM.MyAllySide == (byte) 2)
          ((Graphic) this.MyNoText).rectTransform.anchoredPosition = this.RightPos;
        this.MyNoTextStr.Length = 0;
        this.MyNoTextStr.IntToFormat((long) this.AWM.MyPosition);
        this.MyNoTextStr.AppendFormat(this.DM.mStringTable.GetStringByID(14610U));
        this.MyNoText.text = this.MyNoTextStr.ToString();
        this.MyNoText.SetAllDirty();
        this.MyNoText.cachedTextGenerator.Invalidate();
      }
      else
        this.MyNoText.text = string.Empty;
    }
    else
    {
      if (this.WindowType != e_ActivityType.Ranking)
        return;
      ((Component) this.No2Text).gameObject.SetActive(true);
      if (this.DM.RoleAlliance.Id == 0U)
      {
        this.No1Text.text = this.DM.mStringTable.GetStringByID(1594U);
        ((Component) this.No2Text).gameObject.SetActive(false);
        this.SBtnGO.SetActive(false);
      }
      else if (this.AM.AW_NowAllianceEnterWar == (byte) 0)
      {
        this.No1Text.text = this.DM.mStringTable.GetStringByID(17022U);
        this.No2TextStr.Length = 0;
        this.No2TextStr.IntToFormat((long) this.AM.AW_NextRank);
        if ((int) this.AM.AW_NextRank > (int) this.AM.AW_Rank)
          this.No2TextStr.AppendFormat(this.DM.mStringTable.GetStringByID(17071U));
        else if ((int) this.AM.AW_NextRank == (int) this.AM.AW_Rank)
          this.No2TextStr.AppendFormat(this.DM.mStringTable.GetStringByID(17073U));
        else
          this.No2TextStr.AppendFormat(this.DM.mStringTable.GetStringByID(17072U));
        this.No2Text.text = this.No2TextStr.ToString();
        this.No2Text.SetAllDirty();
        this.No2Text.cachedTextGenerator.Invalidate();
        this.SBtnGO.SetActive(false);
      }
      else
      {
        this.No1TextStr.Length = 0;
        this.No1TextStr.IntToFormat((long) LeaderBoardManager.Instance.AllianceWarGroupRank);
        this.No1TextStr.AppendFormat(this.DM.mStringTable.GetStringByID(17021U));
        this.No1Text.text = this.No1TextStr.ToString();
        this.No1Text.SetAllDirty();
        this.No1Text.cachedTextGenerator.Invalidate();
        this.No2TextStr.Length = 0;
        this.No2TextStr.IntToFormat((long) this.AM.AW_NextRank);
        if ((int) this.AM.AW_NextRank > (int) this.AM.AW_Rank)
          this.No2TextStr.AppendFormat(this.DM.mStringTable.GetStringByID(17071U));
        else if ((int) this.AM.AW_NextRank == (int) this.AM.AW_Rank)
          this.No2TextStr.AppendFormat(this.DM.mStringTable.GetStringByID(17073U));
        else
          this.No2TextStr.AppendFormat(this.DM.mStringTable.GetStringByID(17072U));
        this.No2Text.text = this.No2TextStr.ToString();
        this.No2Text.SetAllDirty();
        this.No2Text.cachedTextGenerator.Invalidate();
        if (this.AM.AW_bcalculateEnd)
          return;
        this.No1Text.text = this.DM.mStringTable.GetStringByID(14613U);
        ((Component) this.No2Text).gameObject.SetActive(false);
      }
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
        if (sender.m_BtnID2 == 1)
        {
          if (!((Object) this.door != (Object) null))
            break;
          this.door.CloseMenu();
          break;
        }
        if (sender.m_BtnID2 != 2 || !((Object) this.door != (Object) null))
          break;
        this.door.OpenMenu(EGUIWindow.UI_AllianceMatchInfo);
        break;
      case 2:
        if (sender.m_BtnID2 != 1)
          break;
        if (!this.AM.AW_bcalculateEnd)
        {
          this.GM.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14613U), (ushort) byte.MaxValue);
          break;
        }
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.AddSeqId();
        messagePacket.Protocol = Protocol._MSG_REQUEST_AWS_SCHEDULE;
        messagePacket.Add(ActivityManager.Instance.AW_Round);
        messagePacket.Send();
        GUIManager.Instance.ShowUILock(EUILock.AWS_Schedule);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (this.DM.RoleAlliance.Id == 0U)
      return;
    if (this.HintStr == null)
      this.HintStr = this.SM.SpawnString(200);
    this.HintStr.Length = 0;
    if (sender.Parm1 == (ushort) 0)
    {
      this.HintStr.IntToFormat((long) this.AM.AW_Rank);
      this.HintStr.IntToFormat((long) this.AM.AW_MemberCount);
      this.HintStr.AppendFormat(this.DM.mStringTable.GetStringByID(17074U));
    }
    else
    {
      this.HintStr.IntToFormat((long) this.AM.AllianceWarMgr.GetRegisterCount());
      this.HintStr.AppendFormat(this.DM.mStringTable.GetStringByID(17002U));
    }
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.HintStr, Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide();

  public void UpdateTime()
  {
    if (this.tmpData == null || this.tmpData.EventState == EActivityState.EAS_None)
      return;
    this.SetTimeStr();
    this.SetTopTime();
  }

  public void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_FontTextureRebuilt:
        for (int index = 0; index < this.rebuildText.Count; ++index)
        {
          if ((Object) this.rebuildText[index] != (Object) null && ((Behaviour) this.rebuildText[index]).enabled)
          {
            ((Behaviour) this.rebuildText[index]).enabled = false;
            ((Behaviour) this.rebuildText[index]).enabled = true;
          }
        }
        break;
      case NetworkNews.Refresh_AllianceWarState:
        if (this.m_handler != null)
          this.m_handler.OnStateChange(this.AM.AW_StateOld, this.AM.AW_State);
        if (this.tmpData != null && this.tmpData.EventState == EActivityState.EAS_ReplayRanking)
          this.SetRoundText();
        this.SetTimeTitle();
        this.RefreshTop();
        break;
      case NetworkNews.Refresh_AllianceWarRound:
        if (this.tmpData == null || this.tmpData.EventState != EActivityState.EAS_ReplayRanking)
          break;
        this.SetRoundText();
        this.SetTopTime();
        break;
      default:
        if (networkNews == NetworkNews.Login)
          break;
        break;
    }
  }

  public void RefreshTop()
  {
    this.SetTimeTitle();
    this.SetTitleRank();
    this.SetTopText();
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (Object) menu)
      return;
    img.sprite = menu.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = menu.LoadMaterial();
  }
}
