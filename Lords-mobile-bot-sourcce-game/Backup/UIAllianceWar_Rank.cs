// Decompiled with JetBrains decompiler
// Type: UIAllianceWar_Rank
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIAllianceWar_Rank : 
  GUIWindow,
  IActivityWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private const long dataCheckGap = 300;
  private const float ZVal = 0.0f;
  private const int MaxReward = 4;
  private Transform AGS_Form;
  private Image glowLight;
  private UIText TimeCountDown;
  private float GetPointTime;
  private int bClose;
  private long nextCheckTime;
  private CString HintStr;
  private CString[] RankStr = new CString[3];
  private CString[] XStr = new CString[4];
  private CString GiftBoxStr;
  private CString countDownStr;
  private UIAlliance_Control RankAnime;
  private Transform[] RankPoint = new Transform[3];
  private RectTransform ImgUpRect;
  private RectTransform ImgDownRect;
  private bool OpenSecendFlyer;
  private float nextFlyer;
  public static bool isDataReady = false;
  public static uint DataAllianceID = 0;
  public static byte[] RewardItemRare = new byte[4];
  public static ushort[] RewardItem = new ushort[4];
  public static ushort[] RewardItemCount = new ushort[4];
  public static byte[] RankLeastMemberCount = new byte[3];

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager instance = DataManager.Instance;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(3).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = string.Empty;
    UIText component2 = this.AGS_Form.GetChild(1).GetChild(4).GetComponent<UIText>();
    component2.font = ttfFont;
    component2.text = string.Empty;
    UIText component3 = this.AGS_Form.GetChild(1).GetChild(5).GetComponent<UIText>();
    component3.font = ttfFont;
    component3.text = instance.mStringTable.GetStringByID(8119U);
    ((Component) component3).gameObject.SetActive(true);
    UIText component4 = this.AGS_Form.GetChild(1).GetChild(6).GetComponent<UIText>();
    component4.font = ttfFont;
    component4.text = instance.mStringTable.GetStringByID(1021U);
    ((Component) component4).gameObject.SetActive(true);
    UIButton component5 = this.AGS_Form.GetChild(1).GetChild(7).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_BtnID1 = 1;
    component5.m_BtnID2 = 1;
    component5.transition = (Selectable.Transition) 0;
    component5.SetButtonEffectType(e_EffectType.e_Scale);
    UIButton component6 = this.AGS_Form.GetChild(1).GetChild(8).GetComponent<UIButton>();
    component6.m_Handler = (IUIButtonClickHandler) this;
    component6.m_BtnID1 = 1;
    component6.m_BtnID2 = 2;
    component6.transition = (Selectable.Transition) 0;
    component6.SetButtonEffectType(e_EffectType.e_Scale);
    ((Component) component6).gameObject.AddComponent<ArabicItemTextureRot>();
    UIButton component7 = this.AGS_Form.GetChild(1).GetChild(9).GetComponent<UIButton>();
    component7.m_Handler = (IUIButtonClickHandler) this;
    component7.m_BtnID1 = 1;
    component7.m_BtnID2 = 3;
    component7.transition = (Selectable.Transition) 0;
    component7.SetButtonEffectType(e_EffectType.e_Scale);
    ((Component) component7).gameObject.AddComponent<ArabicItemTextureRot>();
    UIButton component8 = this.AGS_Form.GetChild(2).GetChild(0).GetComponent<UIButton>();
    component8.m_Handler = (IUIButtonClickHandler) this;
    component8.m_BtnID1 = 2;
    component8.m_BtnID2 = 1;
    ((Component) component8).gameObject.SetActive(true);
    component8.transition = (Selectable.Transition) 0;
    component8.SetButtonEffectType(e_EffectType.e_Scale);
    UIText component9 = this.AGS_Form.GetChild(2).GetChild(0).GetChild(1).GetComponent<UIText>();
    component9.font = ttfFont;
    component9.text = instance.mStringTable.GetStringByID(776U);
    this.AGS_Form.GetChild(2).GetChild(1).gameObject.AddComponent<ArabicItemTextureRot>();
    UIText component10 = this.AGS_Form.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
    component10.font = ttfFont;
    component10.text = instance.mStringTable.GetStringByID(7012U);
    UIText component11 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
    component11.font = ttfFont;
    component11.text = string.Empty;
    ((Graphic) component11).color = (Color) new Color32(byte.MaxValue, (byte) 68, (byte) 89, byte.MaxValue);
    UIHIBtn component12 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetChild(0).GetComponent<UIHIBtn>();
    component12.m_Handler = (IUIHIBtnClickHandler) this;
    component12.m_BtnID1 = 1;
    component12.m_BtnID2 = 0;
    UIText component13 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetChild(1).GetComponent<UIText>();
    component13.font = ttfFont;
    component13.text = string.Empty;
    UIHIBtn component14 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
    component14.m_Handler = (IUIHIBtnClickHandler) this;
    component14.m_BtnID1 = 1;
    component14.m_BtnID2 = 1;
    UIText component15 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetChild(1).GetComponent<UIText>();
    component15.font = ttfFont;
    component15.text = string.Empty;
    UIHIBtn component16 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(2).GetChild(0).GetComponent<UIHIBtn>();
    component16.m_Handler = (IUIHIBtnClickHandler) this;
    component16.m_BtnID1 = 1;
    component16.m_BtnID2 = 2;
    UIText component17 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(2).GetChild(1).GetComponent<UIText>();
    component17.font = ttfFont;
    component17.text = string.Empty;
    UIHIBtn component18 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(3).GetChild(0).GetComponent<UIHIBtn>();
    component18.m_Handler = (IUIHIBtnClickHandler) this;
    component18.m_BtnID1 = 1;
    component18.m_BtnID2 = 3;
    UIText component19 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(3).GetChild(1).GetComponent<UIText>();
    component19.font = ttfFont;
    component19.text = string.Empty;
    UIText component20 = this.AGS_Form.GetChild(2).GetChild(4).GetChild(0).GetComponent<UIText>();
    component20.font = ttfFont;
    component20.text = string.Empty;
    component20.resizeTextMaxSize = 30;
    this.TimeCountDown = component20;
    UIText component21 = this.AGS_Form.GetChild(2).GetChild(5).GetComponent<UIText>();
    component21.font = ttfFont;
    component21.text = DataManager.Instance.mStringTable.GetStringByID(1371U);
    UIText component22 = this.AGS_Form.GetChild(3).GetChild(0).GetChild(1).GetComponent<UIText>();
    component22.font = ttfFont;
    component22.text = string.Empty;
    UIText component23 = this.AGS_Form.GetChild(3).GetChild(1).GetChild(1).GetComponent<UIText>();
    component23.font = ttfFont;
    component23.text = string.Empty;
    UIText component24 = this.AGS_Form.GetChild(3).GetChild(2).GetChild(1).GetComponent<UIText>();
    component24.font = ttfFont;
    component24.text = string.Empty;
    UIButton uiButton1 = this.AGS_Form.GetChild(3).GetChild(0).GetChild(0).gameObject.AddComponent<UIButton>();
    uiButton1.m_Handler = (IUIButtonClickHandler) this;
    uiButton1.m_EffectType = e_EffectType.e_Normal;
    uiButton1.transition = (Selectable.Transition) 0;
    uiButton1.m_BtnID1 = 3;
    uiButton1.m_BtnID2 = 1;
    UIButtonHint uiButtonHint1 = ((Component) uiButton1).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    uiButtonHint1.ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
    uiButtonHint1.ScrollID = (byte) 1;
    UIButton uiButton2 = this.AGS_Form.GetChild(3).GetChild(1).GetChild(0).gameObject.AddComponent<UIButton>();
    uiButton2.m_Handler = (IUIButtonClickHandler) this;
    uiButton2.m_EffectType = e_EffectType.e_Normal;
    uiButton2.transition = (Selectable.Transition) 0;
    uiButton2.m_BtnID1 = 3;
    uiButton2.m_BtnID2 = 2;
    UIButtonHint uiButtonHint2 = ((Component) uiButton2).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint2.m_Handler = (MonoBehaviour) this;
    uiButtonHint2.ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
    uiButtonHint2.ScrollID = (byte) 1;
    UIButton uiButton3 = this.AGS_Form.GetChild(3).GetChild(2).GetChild(0).gameObject.AddComponent<UIButton>();
    uiButton3.m_Handler = (IUIButtonClickHandler) this;
    uiButton3.m_EffectType = e_EffectType.e_Normal;
    uiButton3.transition = (Selectable.Transition) 0;
    uiButton3.m_BtnID1 = 3;
    uiButton3.m_BtnID2 = 3;
    UIButtonHint uiButtonHint3 = ((Component) uiButton3).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint3.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint3.m_Handler = (MonoBehaviour) this;
    uiButtonHint3.ControlFadeOut = ((Component) GUIManager.Instance.m_Arena_Hint.m_RectTransform).gameObject;
    uiButtonHint3.ScrollID = (byte) 1;
    UIText component25 = this.AGS_Form.GetChild(4).GetComponent<UIText>();
    component25.font = ttfFont;
    component25.text = DataManager.Instance.mStringTable.GetStringByID(17033U);
    this.setPanel();
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.AGS_Form.GetChild(1).GetChild(4).GetComponent<UIText>();
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.AGS_Form.GetChild(1).GetChild(5).GetComponent<UIText>();
    if ((UnityEngine.Object) component3 != (UnityEngine.Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.AGS_Form.GetChild(1).GetChild(6).GetComponent<UIText>();
    if ((UnityEngine.Object) component4 != (UnityEngine.Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    UIText component5 = this.AGS_Form.GetChild(2).GetChild(0).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component5 != (UnityEngine.Object) null && ((Behaviour) component5).enabled)
    {
      ((Behaviour) component5).enabled = false;
      ((Behaviour) component5).enabled = true;
    }
    UIText component6 = this.AGS_Form.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component6 != (UnityEngine.Object) null && ((Behaviour) component6).enabled)
    {
      ((Behaviour) component6).enabled = false;
      ((Behaviour) component6).enabled = true;
    }
    UIText component7 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component7 != (UnityEngine.Object) null && ((Behaviour) component7).enabled)
    {
      ((Behaviour) component7).enabled = false;
      ((Behaviour) component7).enabled = true;
    }
    UIText component8 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component8 != (UnityEngine.Object) null && ((Behaviour) component8).enabled)
    {
      ((Behaviour) component8).enabled = false;
      ((Behaviour) component8).enabled = true;
    }
    UIText component9 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component9 != (UnityEngine.Object) null && ((Behaviour) component9).enabled)
    {
      ((Behaviour) component9).enabled = false;
      ((Behaviour) component9).enabled = true;
    }
    UIText component10 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(2).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component10 != (UnityEngine.Object) null && ((Behaviour) component10).enabled)
    {
      ((Behaviour) component10).enabled = false;
      ((Behaviour) component10).enabled = true;
    }
    UIText component11 = this.AGS_Form.GetChild(2).GetChild(3).GetChild(3).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component11 != (UnityEngine.Object) null && ((Behaviour) component11).enabled)
    {
      ((Behaviour) component11).enabled = false;
      ((Behaviour) component11).enabled = true;
    }
    UIText component12 = this.AGS_Form.GetChild(2).GetChild(4).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component12 != (UnityEngine.Object) null && ((Behaviour) component12).enabled)
    {
      ((Behaviour) component12).enabled = false;
      ((Behaviour) component12).enabled = true;
    }
    UIText component13 = this.AGS_Form.GetChild(2).GetChild(5).GetComponent<UIText>();
    if ((UnityEngine.Object) component13 != (UnityEngine.Object) null && ((Behaviour) component13).enabled)
    {
      ((Behaviour) component13).enabled = false;
      ((Behaviour) component13).enabled = true;
    }
    UIText component14 = this.AGS_Form.GetChild(3).GetChild(0).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component14 != (UnityEngine.Object) null && ((Behaviour) component14).enabled)
    {
      ((Behaviour) component14).enabled = false;
      ((Behaviour) component14).enabled = true;
    }
    UIText component15 = this.AGS_Form.GetChild(3).GetChild(1).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component15 != (UnityEngine.Object) null && ((Behaviour) component15).enabled)
    {
      ((Behaviour) component15).enabled = false;
      ((Behaviour) component15).enabled = true;
    }
    UIText component16 = this.AGS_Form.GetChild(3).GetChild(2).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component16 != (UnityEngine.Object) null && ((Behaviour) component16).enabled)
    {
      ((Behaviour) component16).enabled = false;
      ((Behaviour) component16).enabled = true;
    }
    UIText component17 = this.AGS_Form.GetChild(4).GetComponent<UIText>();
    if (!((UnityEngine.Object) component17 != (UnityEngine.Object) null) || !((Behaviour) component17).enabled)
      return;
    ((Behaviour) component17).enabled = false;
    ((Behaviour) component17).enabled = true;
  }

  public override void OnClose()
  {
    this.RankAnime.Destroy();
    for (int index = 0; index < this.RankStr.Length; ++index)
      StringManager.Instance.DeSpawnString(this.RankStr[index]);
    for (int index = 0; index < this.XStr.Length; ++index)
      StringManager.Instance.DeSpawnString(this.XStr[index]);
    StringManager.Instance.DeSpawnString(this.GiftBoxStr);
    StringManager.Instance.DeSpawnString(this.countDownStr);
    StringManager.Instance.DeSpawnString(this.HintStr);
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (this.bClose == 1)
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
    else if (this.bClose == 2)
      ActivityManager.Instance.AllianceWarSendReOpenMenu();
    if (this.RankAnime != null)
      this.RankAnime.Update();
    if ((UnityEngine.Object) this.glowLight != (UnityEngine.Object) null && ((Component) this.glowLight).gameObject.activeInHierarchy)
    {
      this.GetPointTime += Time.smoothDeltaTime;
      if ((double) this.GetPointTime >= 2.0)
        this.GetPointTime = 0.0f;
      float a = (double) this.GetPointTime <= 1.0 ? this.GetPointTime : 2f - this.GetPointTime;
      if ((double) a < 0.20000000298023224)
        a = 0.2f;
      ((Graphic) this.glowLight).color = new Color(1f, 1f, 1f, a);
    }
    if (bOnSecond && (UnityEngine.Object) this.TimeCountDown != (UnityEngine.Object) null && ((Component) this.TimeCountDown).gameObject.activeInHierarchy)
    {
      this.countDownStr.ClearString();
      long sec = ActivityManager.Instance.AllianceWarData.EventBeginTime + (long) ActivityManager.Instance.AllianceWarData.EventReqiureTIme - DataManager.Instance.ServerTime;
      if (sec < 0L)
        sec = 0L;
      GameConstants.GetTimeString(this.countDownStr, (uint) sec);
      this.TimeCountDown.text = this.countDownStr.ToString();
      this.TimeCountDown.cachedTextGenerator.Invalidate();
      this.TimeCountDown.SetAllDirty();
    }
    if (!ActivityManager.Instance.AW_bcalculateEnd && DataManager.Instance.ServerTime > this.nextCheckTime)
    {
      this.nextCheckTime = DataManager.Instance.ServerTime + 300L;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_OPENGETPRIZEUI;
      messagePacket.AddSeqId();
      messagePacket.Send();
    }
    if (!this.OpenSecendFlyer || (double) Time.time <= (double) this.nextFlyer)
      return;
    this.setSecendFlyer();
  }

  public void OnStateChange(EAllianceWarState oldState, EAllianceWarState NewState)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if ((UnityEngine.Object) menu == (UnityEngine.Object) null)
          break;
        switch (sender.m_BtnID2)
        {
          case 1:
            if (DataManager.Instance.RoleAlliance.Id == 0U)
              return;
            UIAlliVSAlliBoard.NewOpen = true;
            menu.OpenMenu(EGUIWindow.UI_AlliVSAlliBoard);
            return;
          case 2:
            if (DataManager.Instance.RoleAlliance.Id == 0U || ActivityManager.Instance.AW_NowAllianceEnterWar == (byte) 0)
              return;
            UIAlliVSGroupBoard.NewOpen = true;
            menu.OpenMenu(EGUIWindow.UI_AlliVSGroupBoard);
            return;
          case 3:
            ActivityManager.Instance.Send_REQUEST_ALLIANCEWAR_RANKPRIZE();
            return;
          default:
            return;
        }
      case 2:
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_GETPRIZE;
        messagePacket.AddSeqId();
        messagePacket.Send();
        break;
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    if (sender.m_BtnID1 != 1)
      return;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) menu == (UnityEngine.Object) null)
      return;
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(UIAllianceWar_Rank.RewardItem[sender.m_BtnID2]);
    if (recordByKey.EquipKind != (byte) 18 && recordByKey.EquipKind != (byte) 19)
      return;
    menu.OpenMenu(EGUIWindow.UI_OpenBox, 1, (int) UIAllianceWar_Rank.RewardItem[sender.m_BtnID2]);
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    if ((UnityEngine.Object) button == (UnityEngine.Object) null || button.m_BtnID1 != 3 || DataManager.Instance.RoleAlliance.Id == 0U)
      return;
    this.HintStr.ClearString();
    this.HintStr.IntToFormat((long) button.m_BtnID3);
    this.HintStr.IntToFormat((long) UIAllianceWar_Rank.RankLeastMemberCount[button.m_BtnID2 - 1]);
    this.HintStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(17074U));
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 300f, 20, this.HintStr, Vector2.zero);
  }

  public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide();

  public void setPanel()
  {
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    RectTransform component = this.AGS_Form.GetChild(0).GetComponent<RectTransform>();
    component.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 0.0f);
    component.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 0.0f);
    component.anchorMax = Vector2.one;
    component.anchorMin = Vector2.zero;
    ((Component) component).gameObject.AddComponent<ActivityWindow>().Initial(e_ActivityType.Ranking, (IActivityWindow) this);
    if (!UIAllianceWar_Rank.isDataReady && DataManager.Instance.RoleAlliance.Id != 0U)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_OPENGETPRIZEUI;
      messagePacket.AddSeqId();
      messagePacket.Send();
    }
    if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
      this.bClose = 1;
    else if (ActivityManager.Instance.AW_State != EAllianceWarState.EAWS_Replay)
      this.bClose = 2;
    this.RankPoint[0] = this.AGS_Form.GetChild(5).GetChild(0);
    this.RankPoint[1] = this.AGS_Form.GetChild(5).GetChild(1);
    this.RankPoint[2] = this.AGS_Form.GetChild(5).GetChild(2);
    if (this.RankAnime == null)
      this.RankAnime = new UIAlliance_Control();
    this.RankAnime.Initial(this.AGS_Form.GetChild(5).GetChild(3).GetComponent<Image>());
    this.ImgUpRect = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<RectTransform>();
    this.ImgDownRect = this.AGS_Form.GetChild(3).GetChild(4).GetComponent<RectTransform>();
    for (int index = 0; index < this.RankStr.Length; ++index)
      this.RankStr[index] = StringManager.Instance.SpawnString();
    for (int index = 0; index < this.XStr.Length; ++index)
      this.XStr[index] = StringManager.Instance.SpawnString();
    this.GiftBoxStr = StringManager.Instance.SpawnString(500);
    this.countDownStr = StringManager.Instance.SpawnString(500);
    this.HintStr = StringManager.Instance.SpawnString(500);
    this.glowLight = this.AGS_Form.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>();
    this.countDownStr.ClearString();
    GameConstants.GetTimeString(this.countDownStr, (uint) (ActivityManager.Instance.AllianceWarData.EventBeginTime + (long) ActivityManager.Instance.AllianceWarData.EventReqiureTIme - DataManager.Instance.ServerTime));
    this.TimeCountDown.text = this.countDownStr.ToString();
    this.TimeCountDown.cachedTextGenerator.Invalidate();
    this.TimeCountDown.SetAllDirty();
    if (!ActivityManager.Instance.AW_bcalculateEnd)
      this.nextCheckTime = DataManager.Instance.ServerTime + 300L;
    this.UpdateLayout();
    this.UpdateRank();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
      case NetworkNews.Refresh_AllianceWarState:
        if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
        {
          (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
          break;
        }
        if (ActivityManager.Instance.AW_State != EAllianceWarState.EAWS_Replay)
        {
          ActivityManager.Instance.AllianceWarSendReOpenMenu();
          break;
        }
        if (DataManager.Instance.RoleAlliance.Id == 0U)
        {
          this.UpdateLayout();
          this.UpdateRank();
          break;
        }
        if (UIAllianceWar_Rank.isDataReady)
          break;
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_OPENGETPRIZEUI;
        messagePacket.AddSeqId();
        messagePacket.Send();
        break;
      default:
        if (networkNews != NetworkNews.Login && networkNews != NetworkNews.Refresh_Alliance)
          break;
        goto case NetworkNews.Refresh_AllianceWarState;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.UpdateLayout();
        if (ActivityManager.Instance.AW_GetGift == (byte) 0)
          break;
        this.SetFlyer();
        break;
      case 2:
        if (ActivityManager.Instance.AW_State == EAllianceWarState.EAWS_None)
        {
          (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
          break;
        }
        if (ActivityManager.Instance.AW_State != EAllianceWarState.EAWS_Replay)
        {
          ActivityManager.Instance.AllianceWarSendReOpenMenu();
          break;
        }
        this.UpdateLayout();
        ActivityManager.Instance.UpDateAllianceWarTop();
        break;
      case 3:
        if (UIAllianceWar_Rank.isDataReady)
          break;
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_OPENGETPRIZEUI;
        messagePacket.AddSeqId();
        messagePacket.Send();
        break;
    }
  }

  public void UpdateLayout()
  {
    switch (UIAllianceWar_Rank.OpenKindCheck() + 1)
    {
      case 0:
        this.bClose = 1;
        break;
      case 1:
        this.AGS_Form.GetChild(2).GetChild(3).gameObject.SetActive(true);
        ((Graphic) this.AGS_Form.GetChild(1).GetChild(9).GetComponent<Image>()).color = Color.white;
        this.AGS_Form.GetChild(1).GetChild(9).GetComponent<uButtonScale>().enabled = true;
        ((Graphic) this.AGS_Form.GetChild(1).GetChild(7).GetComponent<Image>()).color = Color.white;
        this.AGS_Form.GetChild(1).GetChild(7).GetComponent<uButtonScale>().enabled = true;
        int num = 0;
        for (int index = 0; index < 4; ++index)
        {
          if (UIAllianceWar_Rank.RewardItem[index] != (ushort) 0)
          {
            Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(UIAllianceWar_Rank.RewardItem[index]);
            ++num;
            this.AGS_Form.GetChild(2).GetChild(3).GetChild(0 + index).gameObject.SetActive(true);
            GUIManager.Instance.InitianHeroItemImg(((Component) this.AGS_Form.GetChild(2).GetChild(3).GetChild(0 + index).GetChild(0).GetComponent<UIHIBtn>()).transform, eHeroOrItem.Item, UIAllianceWar_Rank.RewardItem[index], (byte) 0, UIAllianceWar_Rank.RewardItemRare[index], bShowText: false, bAutoShowHint: (recordByKey.EquipKind == (byte) 18 ? 1 : (recordByKey.EquipKind == (byte) 19 ? 1 : 0)) == 0);
            this.XStr[index].ClearString();
            this.XStr[index].IntToFormat((long) UIAllianceWar_Rank.RewardItemCount[index]);
            if (GUIManager.Instance.IsArabic)
              this.XStr[index].AppendFormat("{0}x");
            else
              this.XStr[index].AppendFormat("x{0}");
            UIText component = this.AGS_Form.GetChild(2).GetChild(3).GetChild(0 + index).GetChild(1).GetComponent<UIText>();
            component.text = this.XStr[index].ToString();
            component.cachedTextGenerator.Invalidate();
            component.SetAllDirty();
          }
          else
            this.AGS_Form.GetChild(2).GetChild(3).GetChild(0 + index).gameObject.SetActive(false);
        }
        switch (num)
        {
          case 1:
            this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
            break;
          case 2:
            this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(-65f, 0.0f);
            this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(65f, 0.0f);
            break;
          case 3:
            this.AGS_Form.GetChild(2).GetChild(3).GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(-65f, 50f);
            this.AGS_Form.GetChild(2).GetChild(3).GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(65f, 50f);
            break;
        }
        if (ActivityManager.Instance.AW_GetGift == (byte) 0)
        {
          this.AGS_Form.GetChild(2).GetChild(0).gameObject.SetActive(true);
          this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(true);
          this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(true);
          this.AGS_Form.GetChild(2).GetChild(1).gameObject.SetActive(false);
          break;
        }
        this.AGS_Form.GetChild(2).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(1).gameObject.SetActive(true);
        break;
      case 2:
      case 3:
        this.AGS_Form.GetChild(2).GetChild(3).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(1).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
        UIText component1 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
        ((Component) component1).gameObject.SetActive(true);
        component1.text = DataManager.Instance.mStringTable.GetStringByID(17024U);
        ((Graphic) this.AGS_Form.GetChild(1).GetChild(9).GetComponent<Image>()).color = Color.white;
        this.AGS_Form.GetChild(1).GetChild(9).GetComponent<uButtonScale>().enabled = true;
        ((Graphic) this.AGS_Form.GetChild(1).GetChild(7).GetComponent<Image>()).color = Color.white;
        this.AGS_Form.GetChild(1).GetChild(7).GetComponent<uButtonScale>().enabled = true;
        break;
      case 4:
        this.AGS_Form.GetChild(2).GetChild(3).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(1).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
        UIText component2 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
        ((Component) component2).gameObject.SetActive(true);
        component2.text = DataManager.Instance.mStringTable.GetStringByID(17023U);
        ((Graphic) this.AGS_Form.GetChild(1).GetChild(9).GetComponent<Image>()).color = Color.white;
        this.AGS_Form.GetChild(1).GetChild(9).GetComponent<uButtonScale>().enabled = true;
        ((Graphic) this.AGS_Form.GetChild(1).GetChild(7).GetComponent<Image>()).color = Color.white;
        this.AGS_Form.GetChild(1).GetChild(7).GetComponent<uButtonScale>().enabled = true;
        break;
      case 5:
        this.AGS_Form.GetChild(2).GetChild(3).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(1).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
        UIText component3 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
        ((Component) component3).gameObject.SetActive(true);
        component3.text = DataManager.Instance.mStringTable.GetStringByID(1594U);
        ((Graphic) this.AGS_Form.GetChild(1).GetChild(9).GetComponent<Image>()).color = Color.gray;
        this.AGS_Form.GetChild(1).GetChild(9).GetComponent<uButtonScale>().enabled = false;
        ((Graphic) this.AGS_Form.GetChild(1).GetChild(7).GetComponent<Image>()).color = Color.gray;
        this.AGS_Form.GetChild(1).GetChild(7).GetComponent<uButtonScale>().enabled = false;
        break;
      case 6:
        this.AGS_Form.GetChild(2).GetChild(3).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(1).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(5).gameObject.SetActive(false);
        UIText component4 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
        ((Component) component4).gameObject.SetActive(true);
        component4.text = DataManager.Instance.mStringTable.GetStringByID(14613U);
        ((Graphic) this.AGS_Form.GetChild(1).GetChild(9).GetComponent<Image>()).color = Color.white;
        this.AGS_Form.GetChild(1).GetChild(9).GetComponent<uButtonScale>().enabled = true;
        ((Graphic) this.AGS_Form.GetChild(1).GetChild(7).GetComponent<Image>()).color = Color.white;
        this.AGS_Form.GetChild(1).GetChild(7).GetComponent<uButtonScale>().enabled = true;
        break;
    }
    if (ActivityManager.Instance.AW_NowAllianceEnterWar == (byte) 0 || !ActivityManager.Instance.AW_bcalculateEnd)
    {
      ((Graphic) this.AGS_Form.GetChild(1).GetChild(8).GetComponent<Image>()).color = Color.gray;
      this.AGS_Form.GetChild(1).GetChild(8).GetComponent<uButtonScale>().enabled = false;
      this.AGS_Form.GetChild(4).gameObject.SetActive(false);
    }
    else
    {
      ((Graphic) this.AGS_Form.GetChild(1).GetChild(8).GetComponent<Image>()).color = Color.white;
      this.AGS_Form.GetChild(1).GetChild(8).GetComponent<uButtonScale>().enabled = true;
      this.AGS_Form.GetChild(4).gameObject.SetActive(true);
    }
    this.AGS_Form.GetChild(1).GetChild(9).GetChild(0).gameObject.SetActive(ActivityManager.Instance.AW_PrizeGroupID != (byte) 0);
  }

  public void UpdateRank()
  {
    float angle = 270f;
    float[] numArray = new float[2]{ 119f, 187f };
    byte num1 = (byte) Mathf.Clamp((int) ActivityManager.Instance.AW_NextRank, (int) ActivityManager.Instance.AW_MinRank, (int) ActivityManager.Instance.AW_MaxRank);
    byte num2 = (byte) Mathf.Clamp((int) ActivityManager.Instance.AW_Rank, (int) ActivityManager.Instance.AW_MinRank, (int) ActivityManager.Instance.AW_MaxRank);
    if (!ActivityManager.Instance.AW_bcalculateEnd)
      num1 = num2;
    bool flag = false;
    UIAlliance_Control.eRankState state = (int) num1 == (int) num2 ? UIAlliance_Control.eRankState.RankEqual : ((int) num1 <= (int) num2 ? ((int) num1 >= (int) num2 ? UIAlliance_Control.eRankState.RankEqual : UIAlliance_Control.eRankState.RankDown) : UIAlliance_Control.eRankState.RankUp);
    ushort result;
    if ((int) num1 != (int) num2)
    {
      if (!ushort.TryParse(PlayerPrefs.GetString("Alliance_RankAM_" + (object) DataManager.Instance.RoleAttr.UserId), out result))
      {
        if (state != UIAlliance_Control.eRankState.RankEqual)
          flag = true;
      }
      else if ((int) result / 100 != (int) num1 || (int) result % 100 != (int) num2)
        flag = true;
    }
    result = (ushort) ((uint) num1 * 100U + (uint) num2);
    PlayerPrefs.SetString("Alliance_RankAM_" + (object) DataManager.Instance.RoleAttr.UserId, result.ToString());
    this.RankAnime.SetAnimState(state);
    int index1 = (int) num2 != (int) ActivityManager.Instance.AW_MinRank ? ((int) num2 != (int) ActivityManager.Instance.AW_MaxRank ? 1 : 2) : 0;
    int index2;
    switch (state)
    {
      case UIAlliance_Control.eRankState.RankUp:
        index2 = index1 + 1;
        angle = 135f;
        break;
      case UIAlliance_Control.eRankState.RankDown:
        index2 = index1 - 1;
        angle = 315f;
        break;
      default:
        index2 = index1;
        break;
    }
    if (flag)
    {
      ((Transform) this.RankAnime.rectTransform).localPosition = new Vector3(this.RankPoint[index1].localPosition.x, this.RankPoint[index1].localPosition.y, 0.0f);
      this.RankAnime.MoveTo(this.RankPoint[index2], 0.0f, angle);
    }
    else
      ((Transform) this.RankAnime.rectTransform).localPosition = new Vector3(this.RankPoint[index2].localPosition.x, this.RankPoint[index2].localPosition.y, 0.0f);
    if (DataManager.Instance.RoleAlliance.Id != 0U)
    {
      switch (state)
      {
        case UIAlliance_Control.eRankState.RankUp:
          ((Component) this.ImgUpRect).gameObject.SetActive(true);
          this.ImgUpRect.anchoredPosition = new Vector2(this.ImgUpRect.anchoredPosition.x, numArray[index1] - -2f);
          break;
        case UIAlliance_Control.eRankState.RankDown:
          ((Component) this.ImgDownRect).gameObject.SetActive(true);
          this.ImgDownRect.anchoredPosition = new Vector2(this.ImgDownRect.anchoredPosition.x, numArray[index2] - -2f);
          break;
      }
    }
    else
    {
      ((Component) this.ImgUpRect).gameObject.SetActive(false);
      ((Component) this.ImgDownRect).gameObject.SetActive(false);
    }
    ((Component) this.RankAnime.rectTransform).gameObject.SetActive(DataManager.Instance.RoleAlliance.Id != 0U);
    if (!ActivityManager.Instance.AW_bcalculateEnd)
      ((Component) this.RankAnime.rectTransform).gameObject.SetActive(false);
    int num3 = (int) num2 - 1;
    if ((int) num2 == (int) ActivityManager.Instance.AW_MaxRank)
      num3 = (int) num2 - 2;
    else if ((int) num2 == (int) ActivityManager.Instance.AW_MinRank)
      num3 = (int) ActivityManager.Instance.AW_MinRank;
    for (int index3 = 0; index3 < this.RankStr.Length; ++index3)
    {
      UIText component1 = this.AGS_Form.GetChild(3).GetChild(0 + index3).GetChild(1).GetComponent<UIText>();
      this.RankStr[index3].ClearString();
      this.RankStr[index3].IntToFormat((long) (num3 + index3));
      this.RankStr[index3].AppendFormat("{0}");
      component1.text = this.RankStr[index3].ToString();
      component1.cachedTextGenerator.Invalidate();
      component1.SetAllDirty();
      this.AGS_Form.GetChild(3).GetChild(0 + index3).GetComponent<UISpritesArray>().SetSpriteIndex(Math.Min(4, (num3 + index3 - 1) / 5));
      UIButton component2 = this.AGS_Form.GetChild(3).GetChild(0 + index3).GetChild(0).GetComponent<UIButton>();
      component2.m_BtnID3 = num3 + index3;
      component2.m_Handler = (IUIButtonClickHandler) this;
      GUIManager.Instance.SetAllyWarRankImage(this.AGS_Form.GetChild(3).GetChild(0 + index3).GetChild(0).GetComponent<Image>(), (byte) (num3 + index3));
    }
  }

  private void SetFlyer()
  {
    GUIManager instance = GUIManager.Instance;
    Array.Clear((Array) instance.SE_Kind, 0, instance.SE_Kind.Length);
    Array.Clear((Array) instance.SE_ItemID, 0, instance.SE_ItemID.Length);
    for (int index = 0; index < 3; ++index)
    {
      if (UIAllianceWar_Rank.RewardItem[index] != (ushort) 0)
        instance.SE_ItemID[index] = UIAllianceWar_Rank.RewardItem[index];
    }
    instance.mStartV2 = new Vector2((float) ((double) instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 + 259.5), (float) ((double) instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 + 101.0));
    instance.m_SpeciallyEffect.AddIconShow(instance.mStartV2, instance.SE_Kind, instance.SE_ItemID);
    if (UIAllianceWar_Rank.RewardItem[3] != (ushort) 0)
    {
      this.OpenSecendFlyer = true;
      this.nextFlyer = Time.time + 1.5f;
    }
    AudioManager.Instance.PlaySFX((ushort) 11001);
  }

  private void setSecendFlyer()
  {
    this.OpenSecendFlyer = false;
    GUIManager instance = GUIManager.Instance;
    Array.Clear((Array) instance.SE_Kind, 0, instance.SE_Kind.Length);
    Array.Clear((Array) instance.m_SpeciallyEffect.mResValue, 0, instance.m_SpeciallyEffect.mResValue.Length);
    Array.Clear((Array) instance.SE_ItemID, 0, instance.SE_ItemID.Length);
    if (UIAllianceWar_Rank.RewardItem[3] != (ushort) 0)
      instance.SE_ItemID[0] = UIAllianceWar_Rank.RewardItem[3];
    instance.mStartV2 = new Vector2((float) ((double) instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 + 259.5), (float) ((double) instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 + 101.0));
    instance.m_SpeciallyEffect.AddIconShow(instance.mStartV2, instance.SE_Kind, instance.SE_ItemID);
  }

  public static void OpenUI()
  {
    if (DataManager.Instance.RoleAlliance.Id == 0U || UIAllianceWar_Rank.isDataReady && (int) UIAllianceWar_Rank.DataAllianceID == (int) DataManager.Instance.RoleAlliance.Id)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if ((UnityEngine.Object) menu == (UnityEngine.Object) null)
        return;
      ActivityManager.Instance.AllianceWarReopenCheck();
      menu.OpenMenu(EGUIWindow.UI_AllianceWar_Rank);
    }
    else
    {
      UIAllianceWar_Rank.isDataReady = false;
      UIAllianceWar_Rank.DataAllianceID = 0U;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCEWAR_OPENGETPRIZEUI;
      messagePacket.AddSeqId();
      messagePacket.Send();
      GUIManager.Instance.ShowUILock(EUILock.Activity);
    }
  }

  public static void DispatchOpen(MessagePacket MP)
  {
    byte num1 = MP.ReadByte();
    switch (num1)
    {
      case 0:
      case 1:
      case 5:
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if ((UnityEngine.Object) menu == (UnityEngine.Object) null)
          break;
        ActivityManager.Instance.AllianceWarReopenCheck();
        if (num1 == (byte) 1)
        {
          menu.OpenMenu(EGUIWindow.UI_AllianceWar_Rank);
          GUIManager.Instance.HideUILock(EUILock.Activity);
          break;
        }
        ActivityManager instance = ActivityManager.Instance;
        if (num1 == (byte) 5)
        {
          UIAllianceWar_Rank.isDataReady = false;
          instance.AW_bcalculateEnd = false;
          UIAllianceWar_Rank.DataAllianceID = DataManager.Instance.RoleAlliance.Id;
          int num2 = (int) MP.ReadByte();
          int num3 = (int) MP.ReadByte();
          instance.AW_MaxRank = MP.ReadByte();
          instance.AW_MinRank = MP.ReadByte();
          UIAllianceWar_Rank.RankLeastMemberCount[0] = MP.ReadByte();
          UIAllianceWar_Rank.RankLeastMemberCount[1] = MP.ReadByte();
          UIAllianceWar_Rank.RankLeastMemberCount[2] = MP.ReadByte();
        }
        else
        {
          instance.AW_NextRank = MP.ReadByte();
          LeaderBoardManager.Instance.AllianceWarGroupRank = (int) MP.ReadByte();
          instance.AW_MaxRank = MP.ReadByte();
          instance.AW_MinRank = MP.ReadByte();
          UIAllianceWar_Rank.isDataReady = true;
          instance.AW_bcalculateEnd = true;
          UIAllianceWar_Rank.DataAllianceID = DataManager.Instance.RoleAlliance.Id;
          UIAllianceWar_Rank.RankLeastMemberCount[0] = MP.ReadByte();
          UIAllianceWar_Rank.RankLeastMemberCount[1] = MP.ReadByte();
          UIAllianceWar_Rank.RankLeastMemberCount[2] = MP.ReadByte();
          int index1 = 0;
          for (int index2 = 0; index2 < 4; ++index2)
          {
            UIAllianceWar_Rank.RewardItemRare[index1] = MP.ReadByte();
            UIAllianceWar_Rank.RewardItem[index1] = MP.ReadUShort();
            UIAllianceWar_Rank.RewardItemCount[index1] = (ushort) MP.ReadByte();
            if (UIAllianceWar_Rank.RewardItem[index1] != (ushort) 0)
              ++index1;
          }
        }
        if ((UnityEngine.Object) (GUIManager.Instance.FindMenu(EGUIWindow.UI_AllianceWar_Rank) as UIAllianceWar_Rank) != (UnityEngine.Object) null)
          GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWar_Rank, 2);
        else
          menu.OpenMenu(EGUIWindow.UI_AllianceWar_Rank);
        GUIManager.Instance.HideUILock(EUILock.Activity);
        break;
      case 2:
        GUIManager.Instance.HideUILock(EUILock.Activity);
        break;
    }
  }

  public static void DispatchReward(MessagePacket MP)
  {
    if (MP.ReadByte() > (byte) 0)
      return;
    MP.ReadByte();
    for (int index = 0; index < 4; ++index)
      DataManager.Instance.SetCurItemQuantity(MP.ReadUShort(), MP.ReadUShort(), MP.ReadByte(), 0L);
    ActivityManager.Instance.AW_GetGift = (byte) 1;
    ActivityManager.Instance.CheckAWShowHint();
    ActivityManager.Instance.UpDateAllianceWarTop();
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_AllianceWar_Rank, 1);
    GUIManager.Instance.HideUILock(EUILock.Activity);
  }

  public static int OpenKindCheck()
  {
    ActivityManager instance = ActivityManager.Instance;
    if (DataManager.Instance.RoleAlliance.Id == 0U)
      return 4;
    if (!instance.AW_bcalculateEnd)
      return 5;
    if (instance.AW_NowAllianceEnterWar == (byte) 0)
      return 3;
    if ((int) instance.AW_SignUpAllianceID != (int) DataManager.Instance.RoleAlliance.Id)
      return 2;
    if (instance.AW_SignUpAllianceID == 0U)
      return 1;
    if (!UIAllianceWar_Rank.isDataReady)
      return 4;
    return instance.AW_State != EAllianceWarState.EAWS_Replay ? -1 : 0;
  }

  public enum UpdateKind
  {
    Data = 1,
    Reflash = 2,
    ReSendRequest = 3,
  }

  private enum e_AGS_UIAllianceWar_Rank_Editor
  {
    BaseUnitReplace,
    BaseLook,
    GiftBlock,
    Rank,
    Text,
    AnimPoint,
  }

  private enum e_AGS_BaseLook
  {
    Img_info,
    Bar1,
    Bar2,
    text_Count,
    text_empty,
    Text,
    Text_result,
    btn_Rank1,
    btn_Rank2,
    btn_Add,
  }

  private enum e_AGS_GiftBlock
  {
    UIButton,
    Img_Get,
    EndText,
    Reward,
    Img_RewardTime,
    Text,
  }

  private enum e_AGS_UIButton
  {
    Image,
    Text,
  }

  private enum e_AGS_Img_Get
  {
    Text,
  }

  private enum e_AGS_Reward
  {
    Item1,
    Item2,
    Item3,
    Item4,
  }

  private enum e_AGS_Item1
  {
    UIHIBtn,
    UIText,
  }

  private enum e_AGS_Img_RewardTime
  {
    Text,
  }

  private enum e_AGS_Rank
  {
    Rank2,
    Rank3,
    Rank4,
    Up,
    Down,
  }

  private enum e_AGS_Rank2
  {
    Image,
    Text,
  }

  private enum e_AGS_Rank3
  {
    Image,
    Text,
  }

  private enum e_AGS_Rank4
  {
    Image,
    Text,
  }

  private enum e_AGS_AnimPoint
  {
    Point2,
    Point3,
    Point4,
    Image,
  }
}
