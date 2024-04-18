// Decompiled with JetBrains decompiler
// Type: Rally
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class Rally : 
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUTimeBarOnTimer
{
  protected int DataIndex;
  protected int LoadBeginIndex;
  protected float LoadContY;
  protected float DeltaTime;
  protected RectTransform RightScrollCont;
  protected RectTransform RightMessage;
  protected RectTransform TopUnderLine;
  protected RectTransform LeftUnderLine;
  protected Transform TopHero;
  protected Transform LeftHero;
  protected Transform transform;
  protected UIText TitleText;
  protected UIText TopText;
  protected UIText TopCountryText;
  protected UIText TopNameText;
  protected UIText LeftText;
  protected UIText LeftNameText;
  protected UIText LeftJoinText;
  protected UIText LeftCancelText;
  protected UIText RightTitleText;
  protected UIText RightMessageText;
  protected UIHIBtn TopHeroBtn;
  protected UIHIBtn LeftHeroBtn;
  private CString LeftnameStr;
  private CString RightTitleStr;
  private CString TopNameStr;
  private CString TopCountryStr;
  protected CString MessageStr;
  protected CString TopTextStr;
  protected CString LeftTextStr;
  protected Image LeftJoinImg;
  protected Image LeftCancelImg;
  protected Image RightFlagAttack;
  protected Image RightFlagDefense;
  protected Image LeftFilterImg;
  protected Image LeftFilterOnImg;
  protected CanvasGroup FilterEff;
  protected RallyTimeBar TopBar;
  protected RallyTimeBar LeftBar;
  protected GameObject TopAttackIcon;
  protected GameObject TopTargetIcon;
  protected GameObject LeftAttackIcon;
  protected GameObject LeftTargetIcon;
  protected GameObject TopCountry;
  protected GameObject TopLayerBlue;
  protected UIButton FilterBtn;
  protected UIButton JoinBtn;
  protected UIButton CancelBtn;
  protected UIButton TopUnderLineBtn;
  protected UIButton LeftUnderLineBtn;
  protected UIButton RallySpeedupBtn;
  protected UIButton InfoBtn;
  protected UIButton StaticBtn;
  protected uButtonScale JoinScale;
  protected uButtonScale CancelScale;
  protected UISpritesArray SPriteArray;
  protected UISpritesArray ArmySpriteArray;
  protected ScrollPanel RallyScroll;
  protected byte DelayInit = 1;
  protected List<float> ItemsHeight = new List<float>();
  protected List<byte> ItemsExtend = new List<byte>();
  protected Rally.RallyItem[] ItemEdit;
  protected string RallyTitleStr;
  protected int Parm1;
  protected Rally.RallyArmyHint ArmyStatisticHint;

  public Rally(Transform transform, int dataindex)
  {
    this.transform = transform;
    this.DataIndex = dataindex;
  }

  public virtual void OnOpen(int arg1, int arg2)
  {
    GUIManager instance1 = GUIManager.Instance;
    Font ttfFont = instance1.GetTTFFont();
    instance1.UpdateUI(EGUIWindow.Door, 1, 2);
    this.SPriteArray = this.transform.GetComponent<UISpritesArray>();
    this.TitleText = this.transform.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.TitleText.font = ttfFont;
    this.TopHero = this.transform.GetChild(1).GetChild(2).GetChild(0);
    this.TopText = this.transform.GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
    this.TopText.font = ttfFont;
    this.TopAttackIcon = this.transform.GetChild(1).GetChild(1).GetChild(1).gameObject;
    this.TopTargetIcon = this.transform.GetChild(1).GetChild(1).GetChild(0).gameObject;
    this.TopCountry = this.transform.GetChild(1).GetChild(3).gameObject;
    this.TopCountryText = this.transform.GetChild(1).GetChild(3).GetComponent<UIText>();
    this.TopCountryText.font = ttfFont;
    this.TopNameText = this.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
    this.TopNameText.font = ttfFont;
    this.TopUnderLine = this.transform.GetChild(1).GetChild(4).GetChild(0).GetComponent<RectTransform>();
    this.TopUnderLineBtn = ((Component) this.TopUnderLine).GetComponent<UIButton>();
    this.TopUnderLineBtn.m_BtnID1 = 5;
    this.TopUnderLineBtn.m_Handler = (IUIButtonClickHandler) this;
    this.transform.GetChild(1).GetChild(5).GetChild(3).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(1).GetChild(5).GetChild(4).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(1).GetChild(5).GetChild(5).GetComponent<UIText>().font = ttfFont;
    this.TopBar = new RallyTimeBar(this.transform.GetChild(1).GetChild(5).GetComponent<UITimeBar>(), 1);
    this.TopBar.Hander = (IUTimeBarOnTimer) this;
    this.TopLayerBlue = this.transform.GetChild(1).GetChild(0).gameObject;
    this.InfoBtn = this.transform.GetChild(1).GetChild(6).GetComponent<UIButton>();
    this.InfoBtn.m_BtnID1 = 11;
    this.InfoBtn.m_Handler = (IUIButtonClickHandler) this;
    this.LeftHero = this.transform.GetChild(3).GetChild(4).GetChild(0);
    this.LeftText = this.transform.GetChild(3).GetChild(1).GetChild(2).GetComponent<UIText>();
    this.LeftText.font = ttfFont;
    ((Graphic) this.LeftText).color = Color.white;
    this.LeftAttackIcon = this.transform.GetChild(3).GetChild(1).GetChild(1).gameObject;
    this.LeftTargetIcon = this.transform.GetChild(3).GetChild(1).GetChild(0).gameObject;
    this.transform.GetChild(3).GetChild(2).GetChild(3).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(3).GetChild(2).GetChild(4).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(3).GetChild(2).GetChild(5).GetComponent<UIText>().font = ttfFont;
    this.LeftBar = new RallyTimeBar(this.transform.GetChild(3).GetChild(2).GetComponent<UITimeBar>(), 3);
    this.LeftBar.Hander = (IUTimeBarOnTimer) this;
    this.LeftFilterImg = this.transform.GetChild(3).GetChild(5).GetComponent<Image>();
    this.LeftFilterOnImg = this.transform.GetChild(3).GetChild(5).GetChild(0).GetComponent<Image>();
    this.FilterBtn = this.transform.GetChild(3).GetChild(5).GetComponent<UIButton>();
    this.FilterBtn.m_BtnID1 = 0;
    this.FilterBtn.m_Handler = (IUIButtonClickHandler) this;
    this.FilterEff = this.transform.GetChild(3).GetChild(5).GetChild(0).GetComponent<CanvasGroup>();
    this.LeftNameText = this.transform.GetChild(3).GetChild(6).GetComponent<UIText>();
    this.LeftNameText.font = ttfFont;
    this.LeftUnderLine = this.transform.GetChild(3).GetChild(6).GetChild(0).GetComponent<RectTransform>();
    this.LeftUnderLineBtn = ((Component) this.LeftUnderLine).GetComponent<UIButton>();
    this.LeftUnderLineBtn.m_BtnID1 = 5;
    this.LeftUnderLineBtn.m_Handler = (IUIButtonClickHandler) this;
    this.RallySpeedupBtn = this.transform.GetChild(3).GetChild(3).GetComponent<UIButton>();
    this.RallySpeedupBtn.m_BtnID1 = 10;
    this.RallySpeedupBtn.m_Handler = (IUIButtonClickHandler) this;
    if (instance1.IsArabic)
      ((Component) this.RallySpeedupBtn).transform.localScale = new Vector3(-1f, 1f, 1f);
    Color color = new Color(0.141f, 0.063f, 0.0f);
    this.LeftJoinText = this.transform.GetChild(3).GetChild(7).GetChild(0).GetComponent<UIText>();
    ((Shadow) ((Component) this.LeftJoinText).gameObject.AddComponent<Outline>()).effectColor = color;
    this.LeftJoinText.font = ttfFont;
    this.LeftJoinImg = this.transform.GetChild(3).GetChild(7).GetComponent<Image>();
    ((Component) this.LeftJoinImg).gameObject.SetActive(false);
    this.JoinBtn = this.transform.GetChild(3).GetChild(7).GetComponent<UIButton>();
    this.JoinBtn.m_BtnID1 = 2;
    this.JoinBtn.m_Handler = (IUIButtonClickHandler) this;
    this.LeftCancelText = this.transform.GetChild(3).GetChild(8).GetChild(0).GetComponent<UIText>();
    ((Shadow) ((Component) this.LeftCancelText).gameObject.AddComponent<Outline>()).effectColor = color;
    this.LeftCancelText.font = ttfFont;
    this.LeftCancelImg = this.transform.GetChild(3).GetChild(8).GetComponent<Image>();
    ((Component) this.LeftCancelImg).gameObject.SetActive(false);
    this.CancelBtn = this.transform.GetChild(3).GetChild(8).GetComponent<UIButton>();
    this.CancelBtn.m_BtnID1 = 3;
    this.CancelBtn.m_Handler = (IUIButtonClickHandler) this;
    this.ArmySpriteArray = this.transform.GetChild(4).GetChild(5).GetComponent<UISpritesArray>();
    this.ArmyStatisticHint = new Rally.RallyArmyHint(this.transform.GetChild(6), ttfFont, this.ArmySpriteArray);
    UIButtonHint uiButtonHint = this.transform.GetChild(4).GetChild(0).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint.ControlFadeOut = ((Component) this.ArmyStatisticHint.rectTransform).gameObject;
    this.StaticBtn = this.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
    this.StaticBtn.m_BtnID1 = 15;
    this.RightTitleText = this.transform.GetChild(4).GetChild(2).GetComponent<UIText>();
    this.RightTitleText.font = ttfFont;
    this.RightMessage = this.transform.GetChild(4).GetChild(4).GetComponent<RectTransform>();
    this.RightMessageText = ((Transform) this.RightMessage).GetChild(0).GetComponent<UIText>();
    this.RightMessageText.font = ttfFont;
    this.RightFlagAttack = this.transform.GetChild(4).GetChild(1).GetComponent<Image>();
    this.RightFlagDefense = this.transform.GetChild(4).GetChild(1).GetChild(0).GetComponent<Image>();
    this.RallyScroll = this.transform.GetChild(4).GetChild(5).GetChild(0).GetComponent<ScrollPanel>();
    this.transform.GetChild(4).GetChild(6).GetChild(1).gameObject.AddComponent<IgnoreRaycast>();
    this.transform.GetChild(4).GetChild(6).GetChild(1).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(6).GetChild(5).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(6).GetChild(6).GetComponent<UIText>().font = ttfFont;
    int childCount = this.transform.GetChild(4).GetChild(6).GetChild(8).GetChild(0).childCount;
    for (int index = 0; index < childCount; ++index)
    {
      this.transform.GetChild(4).GetChild(6).GetChild(8).GetChild(0).GetChild(index).GetComponent<UIText>().font = ttfFont;
      this.transform.GetChild(4).GetChild(6).GetChild(8).GetChild(0).GetChild(index).GetChild(0).GetComponent<Text>().font = ttfFont;
      this.transform.GetChild(4).GetChild(6).GetChild(8).GetChild(1).GetChild(index).GetChild(1).GetComponent<Text>().font = ttfFont;
      if (instance1.IsArabic)
      {
        RectTransform component1 = this.transform.GetChild(4).GetChild(6).GetChild(8).GetChild(0).GetChild(index).GetChild(0).GetComponent<RectTransform>();
        component1.anchoredPosition = new Vector2(-68f, component1.anchoredPosition.y);
        ((Component) component1).GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        RectTransform component2 = this.transform.GetChild(4).GetChild(6).GetChild(8).GetChild(1).GetChild(index).GetChild(1).GetComponent<RectTransform>();
        ((Transform) component2).localScale = new Vector3(-1f, 1f, 1f);
        component2.anchoredPosition = new Vector2(component2.anchoredPosition.x + component2.rect.width, component2.anchoredPosition.y);
      }
    }
    this.transform.GetChild(4).GetChild(6).GetChild(2).GetChild(3).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(6).GetChild(2).GetChild(4).GetComponent<UIText>().font = ttfFont;
    this.transform.GetChild(4).GetChild(6).GetChild(2).GetChild(5).GetComponent<UIText>().font = ttfFont;
    Image component3 = this.transform.GetChild(5).GetComponent<Image>();
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      ((Behaviour) component3).enabled = false;
    }
    else
    {
      component3.sprite = menu.LoadSprite("UI_main_close_base");
      ((MaskableGraphic) component3).material = menu.LoadMaterial();
    }
    Image component4 = this.transform.GetChild(5).GetChild(0).GetComponent<Image>();
    component4.sprite = menu.LoadSprite("UI_main_close");
    ((MaskableGraphic) component4).material = menu.LoadMaterial();
    UIButton component5 = this.transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
    component5.m_BtnID1 = 1;
    component5.m_Handler = (IUIButtonClickHandler) this;
    StringManager instance2 = StringManager.Instance;
    this.LeftnameStr = instance2.SpawnString();
    this.RightTitleStr = instance2.SpawnString(100);
    this.TopNameStr = instance2.SpawnString(100);
    this.TopCountryStr = instance2.SpawnString(100);
    this.TopTextStr = instance2.SpawnString();
    this.LeftTextStr = instance2.SpawnString();
    this.MessageStr = instance2.SpawnString(800);
    this.Parm1 = arg1;
    if (arg1 == 102)
      return;
    bool flag = true;
    DataManager instance3 = DataManager.Instance;
    if (arg1 == 100)
    {
      if (instance3.WarhallProtocol > (ushort) 0 && instance3.WarhallProtocol != (ushort) 2476 && instance3.WarlobbyDetail != null && (int) instance3.WarlobbyDetail.SelfParticipateTroopIndex == arg2)
      {
        flag = false;
      }
      else
      {
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.AddSeqId();
        messagePacket.Add((uint) arg2);
        messagePacket.Protocol = Protocol._MSG_REQUEST_JOINED_RALLY_DETAIL;
        messagePacket.Send();
        instance3.WarhallDetailType = (byte) arg2;
        instance3.WarhallProtocol = (ushort) messagePacket.Protocol;
      }
    }
    else if (arg1 == 101)
    {
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_WONDERTEAM_INFO;
      messagePacket.AddSeqId();
      messagePacket.Add((byte) arg2);
      messagePacket.Send();
      instance3.WarhallProtocol = (ushort) messagePacket.Protocol;
      flag = true;
    }
    else if (instance3.WarhallProtocol > (ushort) 0 && instance3.WarhallProtocol != (ushort) 2476 && instance3.WarlobbyDetail != null && (int) instance3.WarhallDetailType == (int) (byte) arg1)
    {
      flag = false;
    }
    else
    {
      arg2 = -32769 & arg2;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.AddSeqId();
      messagePacket.Add((byte) arg1);
      messagePacket.Add((uint) arg2);
      messagePacket.Protocol = Protocol._MSG_REQUEST_WARHALL_LIST_DETAIL;
      messagePacket.Send();
      instance3.WarhallDetailType = (byte) arg1;
      instance3.WarhallProtocol = (ushort) messagePacket.Protocol;
    }
    if (!flag)
      return;
    if (instance3.WarlobbyDetail != null)
      instance3.WarlobbyDetail.AllyNameID = 0;
    instance3.EmptyRallyDetail();
    Array.Clear((Array) instance1.RallySaved, 0, instance1.RallySaved.Length);
    instance3.WarTroopStatistic.Clear();
  }

  public virtual void Init()
  {
    GUIManager instance = GUIManager.Instance;
    instance.InitianHeroItemImg(this.TopHero, eHeroOrItem.Hero, (ushort) 5, (byte) 1, (byte) 2, 10, false, false);
    instance.InitianHeroItemImg(this.LeftHero, eHeroOrItem.Hero, (ushort) 5, (byte) 1, (byte) 2, 10, false, false);
    this.TopHeroBtn = this.TopHero.GetComponent<UIHIBtn>();
    this.TopHeroBtn.m_Handler = (IUIHIBtnClickHandler) this;
    this.LeftHeroBtn = this.LeftHero.GetComponent<UIHIBtn>();
    this.LeftHeroBtn.m_Handler = (IUIHIBtnClickHandler) this;
    this.RightMessageText.text = DataManager.Instance.mStringTable.GetStringByID(4824U);
    this.RightMessage.sizeDelta = this.RightMessage.sizeDelta with
    {
      x = this.RightMessageText.preferredWidth + 165f
    };
    this.LoadBeginIndex = (int) instance.RallySaved[0];
    this.LoadContY = GameConstants.ConvertBytesToFloat(instance.RallySaved, 1);
    byte _PanelObjectsCount = 6;
    this.ItemEdit = new Rally.RallyItem[(int) _PanelObjectsCount];
    for (byte index = 0; (int) index < (int) _PanelObjectsCount; ++index)
    {
      this.ItemsExtend.Add((byte) 0);
      this.ItemsHeight.Add(80f);
    }
    this.RallyScroll.IntiScrollPanel(352f, 0.0f, 0.0f, this.ItemsHeight, (int) _PanelObjectsCount, (IUpDateScrollPanel) this);
    UIButtonHint.scrollRect = this.RallyScroll.transform.GetComponent<CScrollRect>();
    this.RightScrollCont = this.RallyScroll.transform.GetChild(0).GetComponent<RectTransform>();
    this.UpdateRallyData();
  }

  public virtual void UpdateTime(bool bOnSecond)
  {
    if (this.DelayInit > (byte) 0)
    {
      --this.DelayInit;
      if (this.DelayInit != (byte) 0)
        return;
      this.Init();
    }
    else
    {
      this.TopBar.Update();
      this.LeftBar.Update();
      for (int index = 0; index < this.ItemEdit.Length; ++index)
        this.ItemEdit[index].Update();
      if (!((Component) this.LeftFilterImg).gameObject.activeSelf)
        return;
      this.DeltaTime += Time.deltaTime;
      if ((double) this.DeltaTime >= 2.0)
        this.DeltaTime = 0.0f;
      this.FilterEff.alpha = (double) this.DeltaTime <= 1.0 ? this.DeltaTime : 2f - this.DeltaTime;
    }
  }

  public virtual void OnClose()
  {
    this.TopBar.Destroy();
    this.LeftBar.Destroy();
    StringManager instance1 = StringManager.Instance;
    instance1.DeSpawnString(this.LeftnameStr);
    instance1.DeSpawnString(this.RightTitleStr);
    instance1.DeSpawnString(this.TopNameStr);
    instance1.DeSpawnString(this.TopCountryStr);
    instance1.DeSpawnString(this.TopTextStr);
    instance1.DeSpawnString(this.LeftTextStr);
    instance1.DeSpawnString(this.MessageStr);
    if (this.ItemEdit != null)
    {
      for (int index = 0; index < this.ItemEdit.Length; ++index)
      {
        if (this.ItemEdit[index] != null)
          this.ItemEdit[index].OnClose();
      }
      GUIManager instance2 = GUIManager.Instance;
      instance2.RallySaved[0] = (byte) this.RallyScroll.GetBeginIdx();
      GameConstants.GetBytes(this.RightScrollCont.anchoredPosition.y, instance2.RallySaved, 1);
    }
    this.ArmyStatisticHint.OnClose();
  }

  public virtual void OnTimer(UITimeBar sender)
  {
  }

  public void KickMemberConfirm(ushort Index, byte WonderID)
  {
    int num = (int) Index << 16 | (int) WonderID;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    GUIManager.Instance.OpenOKCancelBox(GUIManager.Instance.FindMenu(EGUIWindow.UI_Rally), mStringTable.GetStringByID(4096U), mStringTable.GetStringByID(9913U), 13, num, mStringTable.GetStringByID(4977U), mStringTable.GetStringByID(4978U));
  }

  public virtual void KickMember(ushort Index, byte WonderID)
  {
  }

  public void OnNotify(UITimeBar sender)
  {
  }

  public void Onfunc(UITimeBar sender)
  {
  }

  public void OnCancel(UITimeBar sender)
  {
  }

  public virtual void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
  }

  protected void SetText(
    Rally.TextType Type,
    int Parm1 = 0,
    CString Parm2 = null,
    int Parm3 = 0,
    CString Parm4 = null,
    ushort KingdomCompare = 0)
  {
    bool flag = false;
    UIText uiText;
    CString FromattedName;
    switch (Type)
    {
      case Rally.TextType.TopCountry:
        uiText = this.TopCountryText;
        FromattedName = this.TopCountryStr;
        FromattedName.ClearString();
        FromattedName.IntToFormat((long) Parm1);
        if (GUIManager.Instance.IsArabic)
        {
          FromattedName.AppendFormat("{0}#");
          break;
        }
        FromattedName.AppendFormat("#{0}");
        break;
      case Rally.TextType.TopName:
        if (ActivityManager.Instance.IsInKvK((ushort) 0) && KingdomCompare > (ushort) 0 && (int) KingdomCompare != (int) DataManager.MapDataController.kingdomData.kingdomID)
          flag = true;
        FromattedName = this.TopNameStr;
        uiText = this.TopNameText;
        FromattedName.ClearString();
        if (flag)
          ((Graphic) uiText).color = new Color(1f, 0.529f, 0.557f);
        if (Parm4 != null)
        {
          if (Parm4.Length > 0)
          {
            if (flag)
            {
              GameConstants.FormatRoleName(FromattedName, Parm2, Parm4, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0, NameColor: "<color=#FF878E>", TagColor: "<color=#FF878E>");
              break;
            }
            GameConstants.FormatRoleName(FromattedName, Parm2, Parm4, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0, TagColor: "<color=#FFCC00>");
            break;
          }
          FromattedName.Append(Parm2);
          break;
        }
        FromattedName.Append(Parm2);
        break;
      case Rally.TextType.LeftName:
        uiText = this.LeftNameText;
        FromattedName = Parm2;
        break;
      case Rally.TextType.RightTitle:
        uiText = this.RightTitleText;
        FromattedName = this.RightTitleStr;
        FromattedName.ClearString();
        FromattedName.Append(Parm2);
        FromattedName.IntToFormat((long) Parm1, bNumber: true);
        FromattedName.IntToFormat((long) Parm3, bNumber: true);
        FromattedName.AppendFormat("{0} / {1}");
        break;
      case Rally.TextType.TopWonders:
        if (ActivityManager.Instance.IsInKvK((ushort) 0) && Parm1 > 0 && Parm1 != (int) DataManager.MapDataController.kingdomData.kingdomID)
          flag = true;
        uiText = this.TopCountryText;
        FromattedName = this.TopCountryStr;
        FromattedName.ClearString();
        FromattedName.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) Parm3, (ushort) 0));
        if (flag)
        {
          FromattedName.AppendFormat("<color=#FF878E>{0}</color>");
          break;
        }
        FromattedName.AppendFormat("<color=#FFFFFF>{0}</color>");
        break;
      default:
        return;
    }
    uiText.text = FromattedName.ToString();
    uiText.SetAllDirty();
    uiText.cachedTextGenerator.Invalidate();
    uiText.cachedTextGeneratorForLayout.Invalidate();
  }

  public byte GetTroopKind()
  {
    return DataManager.Instance.WarlobbyDetail != null ? DataManager.Instance.WarlobbyDetail.Kind : (byte) 0;
  }

  public void TextRefresh()
  {
    if ((UnityEngine.Object) this.TitleText != (UnityEngine.Object) null)
    {
      ((Behaviour) this.TitleText).enabled = false;
      ((Behaviour) this.TitleText).enabled = true;
    }
    if ((UnityEngine.Object) this.TopText != (UnityEngine.Object) null)
    {
      ((Behaviour) this.TopText).enabled = false;
      ((Behaviour) this.TopText).enabled = true;
    }
    if ((UnityEngine.Object) this.TopCountryText != (UnityEngine.Object) null)
    {
      ((Behaviour) this.TopCountryText).enabled = false;
      ((Behaviour) this.TopCountryText).enabled = true;
    }
    if ((UnityEngine.Object) this.TopNameText != (UnityEngine.Object) null)
    {
      ((Behaviour) this.TopNameText).enabled = false;
      ((Behaviour) this.TopNameText).enabled = true;
    }
    if ((UnityEngine.Object) this.LeftText != (UnityEngine.Object) null)
    {
      ((Behaviour) this.LeftText).enabled = false;
      ((Behaviour) this.LeftText).enabled = true;
    }
    if ((UnityEngine.Object) this.LeftNameText != (UnityEngine.Object) null)
    {
      ((Behaviour) this.LeftNameText).enabled = false;
      ((Behaviour) this.LeftNameText).enabled = true;
    }
    if ((UnityEngine.Object) this.LeftJoinText != (UnityEngine.Object) null)
    {
      ((Behaviour) this.LeftJoinText).enabled = false;
      ((Behaviour) this.LeftJoinText).enabled = true;
    }
    if ((UnityEngine.Object) this.LeftCancelText != (UnityEngine.Object) null)
    {
      ((Behaviour) this.LeftCancelText).enabled = false;
      ((Behaviour) this.LeftCancelText).enabled = true;
    }
    if ((UnityEngine.Object) this.RightTitleText != (UnityEngine.Object) null)
    {
      ((Behaviour) this.RightTitleText).enabled = false;
      ((Behaviour) this.RightTitleText).enabled = true;
    }
    if ((UnityEngine.Object) this.RightMessageText != (UnityEngine.Object) null)
    {
      ((Behaviour) this.RightMessageText).enabled = false;
      ((Behaviour) this.RightMessageText).enabled = true;
    }
    if (this.ItemEdit != null)
    {
      for (int index = 0; index < this.ItemEdit.Length && this.ItemEdit[index] != null; ++index)
        this.ItemEdit[index].TextRefresh();
    }
    if (this.TopBar != null)
      this.TopBar.TextRefresh();
    if (this.LeftBar != null)
      this.LeftBar.TextRefresh();
    this.ArmyStatisticHint.TextRefresh();
  }

  public virtual void UpdateUI(int arg1, int arg2)
  {
    if (this.DelayInit > (byte) 0)
    {
      this.Init();
      this.DelayInit = (byte) 0;
    }
    this.LoadBeginIndex = (int) (byte) this.RallyScroll.GetBeginIdx();
    this.LoadContY = this.RightScrollCont.anchoredPosition.y;
    this.ArmyStatisticHint.Show((UIButtonHint) null);
  }

  public virtual void UpdateRallyData()
  {
  }

  public void UpdateItemDataHeight(int panelObjectIdx)
  {
    int dataIndex = this.ItemEdit[panelObjectIdx].DataIndex;
    this.ItemsExtend[dataIndex] = !((Component) this.ItemEdit[panelObjectIdx].Extend).gameObject.activeSelf ? (byte) 0 : (byte) 1;
    this.ItemsHeight[dataIndex] = this.ItemEdit[panelObjectIdx].GetItemHeight();
    float y = this.RightScrollCont.anchoredPosition.y;
    this.RallyScroll.AddNewDataHeight(this.ItemsHeight);
    if ((double) y <= 0.0)
      return;
    this.RallyScroll.GoTo(dataIndex, y);
  }

  public virtual void OnButtonClick(UIButton sender)
  {
    switch ((Rally.ClickType) sender.m_BtnID1)
    {
      case Rally.ClickType.Close:
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
          break;
        menu.CloseMenu();
        break;
      case Rally.ClickType.Jump:
        (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).GoToMapID((ushort) sender.m_BtnID3, sender.m_BtnID2, (byte) 0, (byte) 1);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender) => this.ArmyStatisticHint.Show(sender);

  public void OnButtonUp(UIButtonHint sender) => this.ArmyStatisticHint.Hide();

  public virtual void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (this.ItemEdit[panelObjectIdx] == null)
      this.ItemEdit[panelObjectIdx] = new Rally.RallyItem(this.SPriteArray, this.ArmySpriteArray, item.transform, this);
    else
      this.ItemEdit[panelObjectIdx].SetRallyItem(dataIdx, panelObjectIdx, this.ItemsExtend[dataIdx]);
  }

  public virtual void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    for (int index = 0; index < this.ItemEdit.Length; ++index)
    {
      if (((Component) this.ItemEdit[index].ThisRect).gameObject.activeSelf && this.ItemEdit[index].DataIndex == dataIndex)
      {
        AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
        this.ItemEdit[index].OnButtonClick((UIButton) null);
        break;
      }
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).GoToMapID((ushort) sender.m_BtnID2, sender.m_BtnID1, (byte) 0, (byte) 1);
  }

  protected void CloseMenuCheck()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
      return;
    if (this.transform.gameObject.activeSelf)
    {
      menu.CloseMenu();
    }
    else
    {
      GUIManager.Instance.CloseMenu(EGUIWindow.UI_Rally);
      DataManager.Instance.RemoveDoorUIStack(EGUIWindow.UI_Rally);
    }
  }

  protected enum UIControl
  {
    Background,
    TopLayer,
    Title,
    LeftLayer,
    RightLayer,
    Close,
    Hint,
  }

  private enum TopControl
  {
    Blue,
    Target,
    Hero,
    Country,
    Name,
    Bar,
    Info,
  }

  private enum LeftControl
  {
    Image,
    Sponsor,
    Bar,
    Speedup,
    Hero,
    Filter,
    Name,
    Join,
    Cancel,
  }

  private enum RightControl
  {
    Static,
    Flag,
    Title,
    Image,
    Message,
    Scroll,
    Item,
    Hint,
  }

  private enum ItemControl
  {
    List,
    Name,
    Bar,
    Icon,
    Speedup,
    RallyText,
    RallyTitleText,
    Kick,
    Extend,
  }

  public enum ClickType
  {
    Filter,
    Close,
    Join,
    Cancel,
    StartNow,
    Jump,
    JoinWonders,
    CancelWonders,
    CancelJoin,
    WonderDefFilter,
    RallySpeed,
    Info,
    ChangeLeader,
    Kick,
    JoinNPC,
    Static,
  }

  public enum TextType
  {
    TopCountry,
    TopName,
    LeftName,
    RightTitle,
    TopWonders,
  }

  public enum eSpriteArray
  {
    DefenceBtn,
    DefenceBtnOn,
    ExtendBtn,
    ExtendBtnOn,
    JoinBtn,
    CancelBtn,
  }

  public enum RallyProtocol
  {
    Mask = 32768, // 0x00008000
    OwnTroop = 32768, // 0x00008000
  }

  protected class RallyItem : IUIButtonClickHandler, IUIButtonDownUpHandler, IUTimeBarOnTimer
  {
    private Rally ParentInst;
    private UISpritesArray SpriteArray;
    private UISpritesArray ArmySpriteArray;
    public RectTransform Extend;
    public RectTransform ThisRect;
    public RectTransform KickBtnRect;
    private UIButton SpeedupBtn;
    private Image ListImg;
    private UIText NameText;
    private UIText RallyNumText;
    private UIText RallyTitleText;
    private CString RallyNumStr;
    private RallyTimeBar Bar;
    public int DataIndex;
    public int PanelIndex;
    private Rally.RallyItem.ArmyList[] ArmyData = new Rally.RallyItem.ArmyList[16];

    public RallyItem(
      UISpritesArray SpriteArray,
      UISpritesArray ArmySpriteArray,
      Transform Item,
      Rally Inst)
    {
      this.SpriteArray = SpriteArray;
      this.ArmySpriteArray = ArmySpriteArray;
      this.ParentInst = Inst;
      this.ThisRect = Item.GetComponent<RectTransform>();
      this.ListImg = Item.GetChild(0).GetComponent<Image>();
      UIButton component1 = Item.GetChild(0).GetComponent<UIButton>();
      component1.m_BtnID1 = 0;
      component1.m_Handler = (IUIButtonClickHandler) this;
      this.NameText = Item.GetChild(1).GetComponent<UIText>();
      this.Bar = new RallyTimeBar(Item.GetChild(2).GetComponent<UITimeBar>());
      this.SpeedupBtn = Item.GetChild(4).GetComponent<UIButton>();
      this.SpeedupBtn.m_BtnID1 = 1;
      this.SpeedupBtn.m_Handler = (IUIButtonClickHandler) this;
      if (GUIManager.Instance.IsArabic)
        ((Component) this.SpeedupBtn).transform.localScale = new Vector3(-1f, 1f, 1f);
      this.KickBtnRect = Item.GetChild(7).GetComponent<RectTransform>();
      UIButton component2 = Item.GetChild(7).GetComponent<UIButton>();
      component2.m_BtnID1 = 2;
      component2.m_Handler = (IUIButtonClickHandler) this;
      this.RallyNumText = Item.GetChild(5).GetComponent<UIText>();
      this.Extend = Item.GetChild(8).GetComponent<RectTransform>();
      this.RallyTitleText = Item.GetChild(6).GetComponent<UIText>();
      ((Graphic) this.RallyTitleText).rectTransform.anchoredPosition = new Vector2(293f, -44f);
      for (int index = 0; index < 16; ++index)
      {
        this.ArmyData[index].ArmyTypeText = ((Transform) this.Extend).GetChild(0).GetChild(index).GetComponent<UIText>();
        this.ArmyData[index].ArmyNumText = ((Transform) this.Extend).GetChild(0).GetChild(index).GetChild(0).GetComponent<Text>();
        this.ArmyData[index].ArmyNumStr = StringManager.Instance.SpawnString();
        this.ArmyData[index].ArmyRankStr = StringManager.Instance.SpawnString();
        this.ArmyData[index].HintRect = ((Transform) this.Extend).GetChild(1).GetChild(index).GetComponent<RectTransform>();
        this.ArmyData[index].ArmyHint = ((Component) this.ArmyData[index].HintRect).gameObject.AddComponent<UIButtonHint>();
        this.ArmyData[index].ArmyHint.m_eHint = EUIButtonHint.CountDown;
        this.ArmyData[index].ArmyHint.DelayTime = 0.2f;
        this.ArmyData[index].ArmyHint.m_DownUpHandler = (IUIButtonDownUpHandler) this;
        this.ArmyData[index].ArmyRankText = ((Transform) this.Extend).GetChild(1).GetChild(index).GetChild(1).GetComponent<Text>();
        this.ArmyData[index].ArmyIcon = ((Transform) this.Extend).GetChild(1).GetChild(index).GetChild(0).GetComponent<Image>();
      }
      this.Bar.TimeBar.m_Handler = (IUTimeBarOnTimer) this;
      this.RallyNumStr = StringManager.Instance.SpawnString();
    }

    public void SetRallyItem(int DataIndex, int PanelIndex, byte Extend)
    {
      this.DataIndex = DataIndex;
      this.PanelIndex = PanelIndex;
      this.SpeedupBtn.m_BtnID2 = DataIndex;
      DataManager instance = DataManager.Instance;
      if (Extend == (byte) 1)
      {
        ((Component) this.Extend).gameObject.SetActive(true);
        this.SetArymNum(DataManager.Instance.WarTroop[DataIndex].TroopSize);
      }
      else
        ((Component) this.Extend).gameObject.SetActive(false);
      this.UpdateKickBtnState(Extend);
      this.ListImg.sprite = this.SpriteArray.GetSprite(2 + (int) Extend);
      if (instance.WarTroop.Count <= DataIndex)
        return;
      WarlobbyTroop warlobbyTroop = instance.WarTroop[DataIndex];
      if (warlobbyTroop == null)
        return;
      this.NameText.text = warlobbyTroop.AllyName.ToString();
      this.NameText.SetAllDirty();
      this.NameText.cachedTextGenerator.Invalidate();
      this.RallyNumStr.ClearString();
      this.RallyNumStr.IntToFormat((long) warlobbyTroop.TotalTroopNum, bNumber: true);
      this.RallyNumStr.AppendFormat("{0}");
      this.RallyNumText.text = this.RallyNumStr.ToString();
      this.RallyNumText.SetAllDirty();
      this.RallyNumText.cachedTextGenerator.Invalidate();
      if (warlobbyTroop.MarchTime.BeginTime > 0L && warlobbyTroop.MarchTime.RequireTime > 0U)
      {
        if (warlobbyTroop.MarchTime.BeginTime + (long) warlobbyTroop.MarchTime.RequireTime > instance.ServerTime)
        {
          this.SetTimeBarVisibility(true);
          this.Bar.SetTimebar((byte) 0, warlobbyTroop.MarchTime.BeginTime, warlobbyTroop.MarchTime.BeginTime + (long) warlobbyTroop.MarchTime.RequireTime, 0L);
          this.Bar.Title.text = instance.mStringTable.GetStringByID(4914U);
        }
        else
          this.SetTimeBarVisibility(false);
      }
      else
        this.SetTimeBarVisibility(false);
      byte index1 = 0;
      byte num = 1;
      for (int index2 = 0; index2 < 16; ++index2)
      {
        int rank = (16 - index2 >> 2) + Mathf.Clamp(16 - index2 & 3, 0, 1);
        int id = rank + (index2 & 3) * 4 - 1;
        if (((int) warlobbyTroop.TroopFlag >> id & 1) == 1)
        {
          SoldierData recordByKey = instance.SoldierDataTable.GetRecordByKey((ushort) (id + 1));
          this.ArmyData[(int) index1].ArmyTypeText.text = instance.mStringTable.GetStringByID((uint) recordByKey.Name);
          this.ArmyData[(int) index1].ArmyNumStr.ClearString();
          this.ArmyData[(int) index1].ArmyNumStr.IntToFormat((long) warlobbyTroop.TroopData[id >> 2][id & 3], bNumber: true);
          this.ArmyData[(int) index1].ArmyNumStr.AppendFormat("{0}");
          this.ArmyData[(int) index1].ArmyNumText.text = this.ArmyData[(int) index1].ArmyNumStr.ToString();
          ((Graphic) this.ArmyData[(int) index1].ArmyNumText).SetAllDirty();
          this.ArmyData[(int) index1].ArmyNumText.cachedTextGenerator.Invalidate();
          this.ArmyData[(int) index1].SetArmyHint((short) id, rank, this.ArmySpriteArray);
          ++index1;
        }
        else
        {
          this.ArmyData[16 - (int) num].SetArmyHint(short.MaxValue, 0, this.ArmySpriteArray);
          this.ArmyData[16 - (int) num].ArmyTypeText.text = string.Empty;
          this.ArmyData[16 - (int) num++].ArmyNumText.text = string.Empty;
        }
      }
    }

    private void UpdateKickBtnState(byte Extend)
    {
      DataManager instance = DataManager.Instance;
      if (instance.WarlobbyDetail.AttackOrDefense == (byte) 1)
      {
        if (Extend == (byte) 1)
        {
          if (instance.WarlobbyDetail.WonderID != byte.MaxValue && instance.WarTroop.Count > 1 && instance.WarTroop[0].AllyNameID == instance.RoleAttr.Name.GetHashCode(false))
            ((Component) this.KickBtnRect).gameObject.SetActive(true);
          else if (instance.WarlobbyDetail.WonderID == byte.MaxValue && instance.WarlobbyDetail.AllyNameID == instance.RoleAttr.Name.GetHashCode(false))
            ((Component) this.KickBtnRect).gameObject.SetActive(true);
          else
            ((Component) this.KickBtnRect).gameObject.SetActive(false);
        }
        else
          ((Component) this.KickBtnRect).gameObject.SetActive(false);
      }
      else if (instance.WarlobbyDetail.AttackOrDefense == (byte) 0)
      {
        if (this.DataIndex == 0)
        {
          ((Component) this.KickBtnRect).gameObject.SetActive(false);
        }
        else
        {
          if ((int) instance.MaxMarchEventNum <= (int) instance.WarlobbyDetail.SelfParticipateTroopIndex)
            return;
          if (Extend == (byte) 1 && instance.WarlobbyDetail.Kind == (byte) 0 && (instance.MarchEventData[(int) instance.WarlobbyDetail.SelfParticipateTroopIndex].bRallyHost == (byte) 1 || instance.MarchEventData[(int) instance.WarlobbyDetail.SelfParticipateTroopIndex].bRallyHost == (byte) 4))
            ((Component) this.KickBtnRect).gameObject.SetActive(true);
          else
            ((Component) this.KickBtnRect).gameObject.SetActive(false);
        }
      }
      else if (this.DataIndex == 0 || Extend == (byte) 0 || instance.WarlobbyDetail.AllyNameID != instance.RoleAttr.Name.GetHashCode(false))
        ((Component) this.KickBtnRect).gameObject.SetActive(false);
      else
        ((Component) this.KickBtnRect).gameObject.SetActive(true);
    }

    public void SetTimeBarVisibility(bool bShow)
    {
      if (bShow)
      {
        this.Bar.gameObject.SetActive(true);
        ((Component) this.SpeedupBtn).gameObject.SetActive(true);
        this.RallyTitleText.text = string.Empty;
      }
      else
      {
        this.Bar.gameObject.SetActive(false);
        ((Component) this.SpeedupBtn).gameObject.SetActive(false);
        this.RallyTitleText.text = this.ParentInst.RallyTitleStr;
      }
    }

    public void OnButtonClick(UIButton sender)
    {
      if ((UnityEngine.Object) sender == (UnityEngine.Object) null)
      {
        ((Component) this.Extend).gameObject.SetActive(!((Component) this.Extend).gameObject.activeSelf);
        int num = !((Component) this.Extend).gameObject.activeSelf ? 0 : 1;
        if (((Component) this.Extend).gameObject.activeSelf)
          this.UpdateKickBtnState((byte) 1);
        else
          this.UpdateKickBtnState((byte) 0);
        this.ListImg.sprite = this.SpriteArray.GetSprite(2 + num);
        this.SetArymNum(DataManager.Instance.WarTroop[this.DataIndex].TroopSize);
        this.ParentInst.UpdateItemDataHeight(this.PanelIndex);
      }
      else
      {
        switch (sender.m_BtnID1)
        {
          case 0:
            ((Component) this.Extend).gameObject.SetActive(!((Component) this.Extend).gameObject.activeSelf);
            this.ListImg.sprite = this.SpriteArray.GetSprite(2 + (!((Component) this.Extend).gameObject.activeSelf ? 0 : 1));
            this.SetArymNum(DataManager.Instance.WarTroop[this.DataIndex].TroopSize);
            this.ParentInst.UpdateItemDataHeight(this.PanelIndex);
            break;
          case 1:
            (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).OpenMenu(EGUIWindow.UI_BagFilter, 2, sender.m_BtnID2 + 100);
            break;
          case 2:
            this.ParentInst.KickMemberConfirm((ushort) this.DataIndex, DataManager.Instance.WarlobbyDetail.WonderID);
            break;
        }
      }
    }

    private void SetArymNum(byte Num)
    {
      this.ThisRect.sizeDelta = this.ThisRect.sizeDelta with
      {
        y = (float) (98.0 + (double) Num * 26.0)
      };
      this.KickBtnRect.anchoredPosition = new Vector2(this.KickBtnRect.anchoredPosition.x, (float) (-95 - 26 * (int) --Num));
    }

    public float GetItemHeight()
    {
      if (!((Component) this.Extend).gameObject.activeSelf)
        this.SetArymNum((byte) 0);
      return this.ThisRect.sizeDelta.y;
    }

    public void TextRefresh()
    {
      ((Behaviour) this.NameText).enabled = false;
      ((Behaviour) this.RallyNumText).enabled = false;
      ((Behaviour) this.RallyTitleText).enabled = false;
      ((Behaviour) this.NameText).enabled = true;
      ((Behaviour) this.RallyNumText).enabled = true;
      ((Behaviour) this.RallyTitleText).enabled = true;
      for (int index = 0; index < this.ArmyData.Length; ++index)
      {
        ((Behaviour) this.ArmyData[index].ArmyNumText).enabled = false;
        ((Behaviour) this.ArmyData[index].ArmyTypeText).enabled = false;
        ((Behaviour) this.ArmyData[index].ArmyNumText).enabled = true;
        ((Behaviour) this.ArmyData[index].ArmyTypeText).enabled = true;
      }
      this.Bar.TextRefresh();
    }

    public void OnClose()
    {
      this.Bar.Destroy();
      StringManager.Instance.DeSpawnString(this.RallyNumStr);
      for (int index = 0; index < this.ArmyData.Length; ++index)
      {
        StringManager.Instance.DeSpawnString(this.ArmyData[index].ArmyNumStr);
        StringManager.Instance.DeSpawnString(this.ArmyData[index].ArmyRankStr);
      }
    }

    public void Update() => this.Bar.Update();

    public void OnTimer(UITimeBar sender)
    {
    }

    public void OnNotify(UITimeBar sender)
    {
    }

    public void Onfunc(UITimeBar sender)
    {
    }

    public void OnCancel(UITimeBar sender)
    {
    }

    public void OnButtonDown(UIButtonHint sender)
    {
      GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 3, 277f, 20, (int) sender.Parm1, 0, new Vector2(70f, 0.0f));
    }

    public void OnButtonUp(UIButtonHint sender) => GUIManager.Instance.m_Hint.Hide(true);

    private struct ArmyList
    {
      public UIText ArmyTypeText;
      public Text ArmyNumText;
      public CString ArmyNumStr;
      public CString ArmyRankStr;
      public UIButtonHint ArmyHint;
      public Image ArmyIcon;
      public Text ArmyRankText;
      public RectTransform HintRect;

      public void SetArmyHint(short id, int rank, UISpritesArray spriteArray)
      {
        if (id == short.MaxValue)
        {
          this.HintRect.sizeDelta = new Vector2(0.0f, this.HintRect.sizeDelta.y);
          ((Behaviour) this.ArmyIcon).enabled = false;
          this.ArmyHint.enabled = false;
          this.ArmyRankText.text = string.Empty;
        }
        else
        {
          this.ArmyTypeText.cachedTextGeneratorForLayout.Invalidate();
          this.HintRect.sizeDelta = new Vector2(this.ArmyTypeText.preferredWidth + 33f, this.HintRect.sizeDelta.y);
          this.ArmyRankStr.ClearString();
          this.ArmyRankStr.IntToFormat((long) rank);
          this.ArmyRankStr.AppendFormat("{0}");
          this.ArmyRankText.text = this.ArmyRankStr.ToString();
          ((Graphic) this.ArmyRankText).SetAllDirty();
          this.ArmyRankText.cachedTextGenerator.Invalidate();
          ((Behaviour) this.ArmyIcon).enabled = true;
          this.ArmyIcon.sprite = spriteArray.GetSprite((int) id >> 2);
          this.ArmyHint.enabled = true;
          this.ArmyHint.Parm1 = (ushort) id;
        }
      }
    }

    private enum ClickType
    {
      List,
      Speedup,
      Kick,
    }
  }

  protected struct RallyArmyHint
  {
    public RectTransform rectTransform;
    private GameObject gameobject;
    private Rally.RallyArmyHint.ArmyInfo[] Army;
    private UIText TitleText;
    private UIText MsgText;
    private float DefHeight;
    private UIButtonHint Hint;

    public RallyArmyHint(Transform transform, Font font, UISpritesArray IconArray)
    {
      this.gameobject = transform.gameObject;
      this.Army = new Rally.RallyArmyHint.ArmyInfo[16];
      for (int index = 0; index < 16; ++index)
        this.Army[index] = new Rally.RallyArmyHint.ArmyInfo(transform.GetChild(0).GetChild(index + 2), font, IconArray);
      Image component = transform.GetChild(0).GetComponent<Image>();
      this.rectTransform = ((Graphic) component).rectTransform;
      ((MaskableGraphic) component).material = GUIManager.Instance.GetFrameMaterial();
      component.sprite = GUIManager.Instance.LoadFrameSprite("UI_main_box_099");
      this.TitleText = transform.GetChild(0).GetChild(0).GetComponent<UIText>();
      this.TitleText.font = font;
      this.TitleText.text = DataManager.Instance.mStringTable.GetStringByID(4925U);
      this.MsgText = transform.GetChild(0).GetChild(1).GetComponent<UIText>();
      this.MsgText.font = font;
      this.MsgText.text = DataManager.Instance.mStringTable.GetStringByID(4824U);
      this.DefHeight = ((Graphic) this.TitleText).rectTransform.rect.height * 2f;
      this.Hint = (UIButtonHint) null;
      transform.SetParent((Transform) GUIManager.Instance.m_ItemInfoLayer, false);
    }

    public void Show(UIButtonHint sender)
    {
      if ((UnityEngine.Object) sender == (UnityEngine.Object) null && !this.gameobject.activeSelf)
        return;
      DataManager instance = DataManager.Instance;
      byte index1 = 0;
      byte num1 = 1;
      uint[][] troop = instance.WarTroopStatistic.GetTroop();
      uint num2 = 0;
      if (instance.WarlobbyDetail != null)
        num2 = instance.WarlobbyDetail.AllyCurrTroop;
      for (int index2 = 0; index2 < 16; ++index2)
      {
        int rank = (16 - index2 >> 2) + Mathf.Clamp(16 - index2 & 3, 0, 1);
        int id = rank + (index2 & 3) * 4 - 1;
        if (troop[id >> 2][id & 3] > 0U)
        {
          uint percentage = num2 <= 0U ? 0U : troop[id >> 2][id & 3] * 1000U / num2;
          this.Army[(int) index1].Set(id, rank, troop[id >> 2][id & 3], percentage);
          if (index1 > (byte) 0)
            this.Army[(int) index1].rectTransform.anchoredPosition = new Vector2(this.Army[0].rectTransform.anchoredPosition.x, this.Army[0].rectTransform.anchoredPosition.y - this.Army[0].rectTransform.sizeDelta.y * (float) index1);
          ++index1;
        }
        else
          this.Army[16 - (int) num1++].Hide();
      }
      if (index1 == (byte) 0)
      {
        ((Component) this.MsgText).gameObject.SetActive(true);
        this.rectTransform.sizeDelta = new Vector2(this.rectTransform.sizeDelta.x, 83f);
      }
      else
      {
        ((Component) this.MsgText).gameObject.SetActive(false);
        this.rectTransform.sizeDelta = new Vector2(this.rectTransform.sizeDelta.x, this.DefHeight + (float) index1 * this.Army[0].rectTransform.sizeDelta.y);
      }
      this.gameobject.SetActive(true);
      if ((UnityEngine.Object) sender != (UnityEngine.Object) null)
      {
        this.Hint = sender;
        this.Hint.GetTipPosition(this.rectTransform);
      }
      else
      {
        if (!((UnityEngine.Object) this.Hint != (UnityEngine.Object) null))
          return;
        this.Hint.GetTipPosition(this.rectTransform);
      }
    }

    public void Hide()
    {
      if (!((UnityEngine.Object) this.gameobject != (UnityEngine.Object) null))
        return;
      this.gameobject.SetActive(false);
    }

    public void TextRefresh()
    {
      ((Behaviour) this.TitleText).enabled = false;
      ((Behaviour) this.TitleText).enabled = true;
      ((Behaviour) this.MsgText).enabled = false;
      ((Behaviour) this.MsgText).enabled = true;
      for (int index = 0; index < 16; ++index)
        this.Army[index].TextRefresh();
    }

    public void OnClose()
    {
      for (int index = 0; index < 16; ++index)
        this.Army[index].OnClose();
      UnityEngine.Object.Destroy((UnityEngine.Object) this.gameobject);
      this.gameobject = (GameObject) null;
    }

    private struct ArmyInfo
    {
      public RectTransform rectTransform;
      private GameObject gameobject;
      private Image Icon;
      private UIText RankText;
      private UIText NameText;
      private UIText QtyText;
      private UIText PercentText;
      private CString RankStr;
      private CString QtyStr;
      private CString PercentStr;
      private UISpritesArray IconArray;

      public ArmyInfo(Transform transform, Font font, UISpritesArray IconArray)
      {
        this.gameobject = transform.gameObject;
        this.rectTransform = transform as RectTransform;
        this.PercentText = transform.GetChild(0).GetComponent<UIText>();
        this.PercentText.font = font;
        this.Icon = transform.GetChild(1).GetComponent<Image>();
        this.RankText = transform.GetChild(2).GetComponent<UIText>();
        this.RankText.font = font;
        this.NameText = transform.GetChild(3).GetComponent<UIText>();
        this.NameText.font = font;
        this.QtyText = transform.GetChild(4).GetComponent<UIText>();
        this.QtyText.font = font;
        this.RankStr = StringManager.Instance.SpawnString();
        this.QtyStr = StringManager.Instance.SpawnString();
        this.PercentStr = StringManager.Instance.SpawnString();
        this.IconArray = IconArray;
      }

      public void Set(int id, int rank, uint qty, uint percentage)
      {
        this.gameobject.SetActive(true);
        this.PercentStr.ClearString();
        this.PercentStr.DoubleToFormat((double) percentage / 10.0);
        if (GUIManager.Instance.IsArabic)
          this.PercentStr.AppendFormat("%{0}");
        else
          this.PercentStr.AppendFormat("{0}%");
        this.PercentText.text = this.PercentStr.ToString();
        this.PercentText.SetAllDirty();
        this.PercentText.cachedTextGenerator.Invalidate();
        this.Icon.sprite = this.IconArray.GetSprite(id >> 2);
        this.RankStr.ClearString();
        this.RankStr.IntToFormat((long) rank);
        this.RankStr.AppendFormat("{0}");
        this.RankText.text = this.RankStr.ToString();
        this.RankText.SetAllDirty();
        this.RankText.cachedTextGenerator.Invalidate();
        this.NameText.text = DataManager.Instance.mStringTable.GetStringByID((uint) DataManager.Instance.SoldierDataTable.GetRecordByKey((ushort) (id + 1)).Name);
        this.QtyStr.ClearString();
        this.QtyStr.IntToFormat((long) qty, bNumber: true);
        this.QtyStr.AppendFormat("{0}");
        this.QtyText.text = this.QtyStr.ToString();
        this.QtyText.SetAllDirty();
        this.QtyText.cachedTextGenerator.Invalidate();
      }

      public void Hide() => this.gameobject.SetActive(false);

      public void TextRefresh()
      {
        ((Behaviour) this.PercentText).enabled = false;
        ((Behaviour) this.PercentText).enabled = true;
        ((Behaviour) this.RankText).enabled = false;
        ((Behaviour) this.RankText).enabled = true;
        ((Behaviour) this.NameText).enabled = false;
        ((Behaviour) this.NameText).enabled = true;
        ((Behaviour) this.QtyText).enabled = false;
        ((Behaviour) this.QtyText).enabled = true;
      }

      public void OnClose()
      {
        StringManager.Instance.DeSpawnString(this.PercentStr);
        StringManager.Instance.DeSpawnString(this.RankStr);
        StringManager.Instance.DeSpawnString(this.QtyStr);
      }
    }
  }
}
