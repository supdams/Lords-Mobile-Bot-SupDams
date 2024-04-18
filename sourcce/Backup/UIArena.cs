// Decompiled with JetBrains decompiler
// Type: UIArena
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIArena : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private ArenaManager AM;
  private ActivityManager ActM;
  private Transform GameT;
  private Transform K1_T;
  private Transform K2_T;
  private Door door;
  private Font TTFont;
  private UIButton btn_EXIT;
  public UIButton btn_Defend;
  private UIButton btn_I;
  private UIButton btn_Award;
  private UIButton btn_Count;
  private UIButton btn_ReSet;
  private UIButton btn_Replay;
  private UIButton btn_Rank;
  private UIButton btn_Astrology;
  private UIButton btn_StrengthHint;
  private UIButton[] btn_Challenge = new UIButton[3];
  private UIButton[] btn_Hint = new UIButton[3];
  private UIButton[] btn_DefendHero = new UIButton[5];
  private UIHIBtn[] btn_Hero = new UIHIBtn[5];
  private UIHIBtn[] btn_Opponent = new UIHIBtn[3];
  private Image Img_ReplayNum;
  private Image Img_StrengthHint;
  private Image Img_Award;
  private Image Img_ArenaPlacedrop;
  private Image[] Img_Hero = new Image[5];
  private Image[] Img_HeroStar = new Image[5];
  private Image[] Img_Rank = new Image[3];
  private Image[] Img_OS = new Image[3];
  private UIText text_Title;
  private UIText text_ReplayNum;
  private UIText text_Defend;
  private UIText text_Strength;
  private UIText text_StrengthHint;
  private UIText text_ReSet;
  private UIText[] text_Propaganda = new UIText[2];
  private UIText[] text_Award = new UIText[2];
  private UIText[] text_Count = new UIText[2];
  private UIText[] text_CD = new UIText[2];
  private UIText[] text_Rank = new UIText[3];
  private UIText[] text_OS = new UIText[3];
  private UIText[] text_Challenge = new UIText[3];
  private UIText[] text_Challenge_Name = new UIText[3];
  private UIText[] text_Close = new UIText[3];
  private CString Cstr_ReplayNum;
  private CString Cstr_Propaganda;
  private CString Cstr_Strength;
  private CString Cstr_Rank;
  private CString Cstr_Count;
  private CString Cstr_CD;
  private CString Cstr_CDTime;
  private CString[] Cstr_TargetName = new CString[3];
  private CString[] Cstr_TargetRank = new CString[3];
  private CString[] Cstr_TargetStrength = new CString[3];
  private UIRunningText img_text;
  private bool bSetHero;
  private CurHeroData mcurHeroData;
  private bool bCDReSet;
  private byte CDReSetTime;
  private bool bChallengeCD;
  private bool bChallengeCount;
  private float mArenaPlacedropX = 90f;
  private float mArenaPlacedropCD;

  public override void OnOpen(int arg1, int arg2)
  {
    this.Cstr_ReplayNum = StringManager.Instance.SpawnString();
    this.Cstr_Propaganda = StringManager.Instance.SpawnString(200);
    this.Cstr_Strength = StringManager.Instance.SpawnString();
    this.Cstr_Rank = StringManager.Instance.SpawnString();
    this.Cstr_Count = StringManager.Instance.SpawnString();
    this.Cstr_CD = StringManager.Instance.SpawnString(100);
    this.Cstr_CDTime = StringManager.Instance.SpawnString();
    for (int index = 0; index < 3; ++index)
    {
      this.Cstr_TargetName[index] = StringManager.Instance.SpawnString();
      this.Cstr_TargetRank[index] = StringManager.Instance.SpawnString();
      this.Cstr_TargetStrength[index] = StringManager.Instance.SpawnString();
    }
    this.DM = DataManager.Instance;
    this.AM = ArenaManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.ActM = ActivityManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.AM.bArenaKVK = this.ActM.IsInKvK((ushort) 0);
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    Material material = this.door.LoadMaterial();
    Transform child1 = this.GameT.GetChild(0);
    this.text_Title = child1.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.DM.mStringTable.GetStringByID(9102U);
    this.btn_Astrology = child1.GetChild(4).GetComponent<UIButton>();
    this.btn_Astrology.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Astrology.m_BtnID1 = 13;
    this.btn_Astrology.m_EffectType = e_EffectType.e_Scale;
    this.btn_Astrology.transition = (Selectable.Transition) 0;
    this.btn_Rank = child1.GetChild(5).GetComponent<UIButton>();
    this.btn_Rank.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Rank.m_BtnID1 = 11;
    this.btn_Rank.m_EffectType = e_EffectType.e_Scale;
    this.btn_Rank.transition = (Selectable.Transition) 0;
    child1.GetChild(5).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
    this.btn_Replay = child1.GetChild(6).GetComponent<UIButton>();
    this.btn_Replay.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Replay.m_BtnID1 = 10;
    this.btn_Replay.m_EffectType = e_EffectType.e_Scale;
    this.btn_Replay.transition = (Selectable.Transition) 0;
    child1.GetChild(6).GetChild(0).gameObject.AddComponent<ArabicItemTextureRot>();
    this.Img_ReplayNum = child1.GetChild(6).GetChild(1).GetComponent<Image>();
    this.text_ReplayNum = child1.GetChild(6).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_ReplayNum.font = this.TTFont;
    this.Cstr_ReplayNum.ClearString();
    this.Cstr_ReplayNum.IntToFormat((long) this.AM.m_ArenaNewReportNum);
    this.Cstr_ReplayNum.AppendFormat("{0}");
    this.text_ReplayNum.text = this.Cstr_ReplayNum.ToString();
    ((Graphic) this.Img_ReplayNum).rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_ReplayNum.preferredWidth), ((Graphic) this.Img_ReplayNum).rectTransform.sizeDelta.y);
    if (this.AM.m_ArenaNewReportNum > (byte) 0)
      ((Component) this.Img_ReplayNum).gameObject.SetActive(true);
    else
      ((Component) this.Img_ReplayNum).gameObject.SetActive(false);
    this.img_text = child1.GetChild(7).GetComponent<UIRunningText>();
    this.img_text.tmpLength = 453f;
    Transform child2 = child1.GetChild(7).GetChild(0);
    this.text_Propaganda[0] = child2.GetComponent<UIText>();
    RectTransform component1 = child2.GetComponent<RectTransform>();
    this.text_Propaganda[0].font = this.TTFont;
    this.Cstr_Propaganda.ClearString();
    CString cstring1 = StringManager.Instance.StaticString1024();
    CString cstring2 = StringManager.Instance.StaticString1024();
    CString cstring3 = StringManager.Instance.StaticString1024();
    cstring1.ClearString();
    cstring2.ClearString();
    cstring3.ClearString();
    this.AM.GetHeroAstrology(cstring1, cstring2);
    if (this.AM.m_NowArenaTopicID[0] != (byte) 0 && this.AM.m_NowArenaTopicID[1] != (byte) 0)
    {
      cstring3.StringToFormat(cstring1);
      cstring3.StringToFormat(cstring2);
      cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9118U));
    }
    else
    {
      if (this.AM.m_NowArenaTopicID[0] != (byte) 0)
        cstring3.StringToFormat(cstring1);
      else
        cstring3.StringToFormat(cstring2);
      cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9154U));
    }
    this.Cstr_Propaganda.Append(cstring3);
    this.Cstr_Propaganda.Append("     ");
    cstring1.ClearString();
    cstring2.ClearString();
    cstring3.ClearString();
    if (this.AM.m_NowTopicEffect[0].Effect != (ushort) 0 && this.AM.m_NowTopicEffect[1].Effect != (ushort) 0)
    {
      GameConstants.GetEffectValue(cstring1, this.AM.m_NowTopicEffect[0].Effect, (uint) this.AM.m_NowTopicEffect[0].Value, (byte) 10, 0.0f);
      GameConstants.GetEffectValue(cstring2, this.AM.m_NowTopicEffect[1].Effect, (uint) this.AM.m_NowTopicEffect[1].Value, (byte) 10, 0.0f);
      cstring3.StringToFormat(cstring1);
      cstring3.StringToFormat(cstring2);
      cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9119U));
      cstring3.Append(" ");
    }
    else
    {
      if (this.AM.m_NowTopicEffect[0].Effect != (ushort) 0)
        GameConstants.GetEffectValue(cstring1, this.AM.m_NowTopicEffect[0].Effect, (uint) this.AM.m_NowTopicEffect[0].Value, (byte) 10, 0.0f);
      else
        GameConstants.GetEffectValue(cstring1, this.AM.m_NowTopicEffect[1].Effect, (uint) this.AM.m_NowTopicEffect[1].Value, (byte) 10, 0.0f);
      cstring3.StringToFormat(cstring1);
      cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9155U));
      cstring3.Append(" ");
    }
    this.Cstr_Propaganda.Append(cstring3);
    this.text_Propaganda[0].text = this.Cstr_Propaganda.ToString();
    Transform child3 = child1.GetChild(7).GetChild(1);
    this.text_Propaganda[1] = child3.GetComponent<UIText>();
    RectTransform component2 = child3.GetComponent<RectTransform>();
    this.text_Propaganda[1].font = this.TTFont;
    this.text_Propaganda[1].text = this.Cstr_Propaganda.ToString();
    component1.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth + 160f, component1.sizeDelta.y);
    component2.anchoredPosition = new Vector2(this.text_Propaganda[0].preferredWidth + 160f, component2.anchoredPosition.y);
    component2.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth + 160f, component2.sizeDelta.y);
    this.img_text.tmpLength = this.text_Propaganda[0].preferredWidth + 160f;
    for (int index = 0; index < 5; ++index)
    {
      this.btn_Hero[index] = child1.GetChild(8 + index).GetChild(0).GetComponent<UIHIBtn>();
      this.btn_DefendHero[index] = child1.GetChild(13 + index).GetComponent<UIButton>();
      this.btn_DefendHero[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_DefendHero[index].m_BtnID1 = 9;
      this.Img_Hero[index] = child1.GetChild(13 + index).GetChild(0).GetComponent<Image>();
      this.Img_Hero[index].sprite = this.GUIM.LoadFrameSprite("hf000");
      ((MaskableGraphic) this.Img_Hero[index]).material = this.GUIM.GetFrameMaterial();
      ((Component) child1.GetChild(13 + index).GetChild(0).GetChild(0).GetComponent<Image>()).gameObject.SetActive(false);
      this.Img_HeroStar[index] = child1.GetChild(13 + index).GetChild(1).GetComponent<Image>();
      if (DataManager.Instance.curHeroData.ContainsKey((uint) this.AM.m_ArenaDefHero[index]))
      {
        this.mcurHeroData = DataManager.Instance.curHeroData[(uint) this.AM.m_ArenaDefHero[index]];
        ((Component) this.btn_Hero[index]).gameObject.SetActive(true);
        this.GUIM.InitianHeroItemImg(((Component) this.btn_Hero[index]).transform, eHeroOrItem.Hero, this.AM.m_ArenaDefHero[index], this.mcurHeroData.Star, this.mcurHeroData.Enhance, (int) this.mcurHeroData.Level);
        if (this.AM.CheckHeroAstrology(this.AM.m_ArenaDefHero[index]))
          ((Component) this.Img_HeroStar[index]).gameObject.SetActive(true);
        this.bSetHero = true;
      }
      else
      {
        this.GUIM.InitianHeroItemImg(((Component) this.btn_Hero[index]).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 0, (byte) 0);
        ((Component) this.btn_Hero[index]).gameObject.SetActive(false);
        ((Component) this.Img_Hero[index]).gameObject.SetActive(true);
      }
    }
    this.btn_Defend = child1.GetChild(18).GetComponent<UIButton>();
    this.btn_Defend.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Defend.m_BtnID1 = 1;
    this.btn_Defend.m_EffectType = e_EffectType.e_Scale;
    this.btn_Defend.transition = (Selectable.Transition) 0;
    this.text_Defend = child1.GetChild(18).GetChild(0).GetComponent<UIText>();
    this.text_Defend.font = this.TTFont;
    this.text_Defend.text = this.DM.mStringTable.GetStringByID(9103U);
    this.btn_I = child1.GetChild(19).GetComponent<UIButton>();
    if (this.GUIM.IsArabic)
      ((Component) this.btn_I).gameObject.AddComponent<ArabicItemTextureRot>();
    this.btn_I.m_Handler = (IUIButtonClickHandler) this;
    this.btn_I.m_BtnID1 = 2;
    this.btn_I.m_EffectType = e_EffectType.e_Scale;
    this.btn_I.transition = (Selectable.Transition) 0;
    this.text_Strength = child1.GetChild(20).GetChild(0).GetComponent<UIText>();
    this.text_Strength.font = this.TTFont;
    this.Cstr_Strength.ClearString();
    this.Cstr_Strength.IntToFormat((long) this.GetAllPower(), bNumber: true);
    this.Cstr_Strength.AppendFormat("{0}");
    this.text_Strength.text = this.Cstr_Strength.ToString();
    Transform child4 = this.GameT.GetChild(1);
    this.K1_T = child4.GetChild(1);
    this.K2_T = child4.GetChild(2);
    this.K1_T.gameObject.SetActive(true);
    CString Name = StringManager.Instance.StaticString1024();
    CString Tag = StringManager.Instance.StaticString1024();
    for (int TargetIdx = 0; TargetIdx < 3; ++TargetIdx)
    {
      this.btn_Opponent[TargetIdx] = this.K1_T.GetChild(2 + TargetIdx).GetChild(0).GetComponent<UIHIBtn>();
      this.GUIM.InitianHeroItemImg(((Component) this.btn_Opponent[TargetIdx]).transform, eHeroOrItem.Hero, this.AM.m_ArenaTarget[TargetIdx].Head, (byte) 11, (byte) 0);
      this.Img_Rank[TargetIdx] = this.K1_T.GetChild(5 + TargetIdx).GetComponent<Image>();
      if (this.GUIM.IsArabic)
        ((Component) this.Img_Rank[TargetIdx]).gameObject.AddComponent<ArabicItemTextureRot>();
      this.text_Rank[TargetIdx] = this.K1_T.GetChild(5 + TargetIdx).GetChild(0).GetComponent<UIText>();
      this.text_Rank[TargetIdx].font = this.TTFont;
      this.Cstr_TargetRank[TargetIdx].ClearString();
      this.Cstr_TargetRank[TargetIdx].IntToFormat((long) this.AM.m_ArenaTarget[TargetIdx].Place, bNumber: true);
      this.Cstr_TargetRank[TargetIdx].AppendFormat("{0}");
      this.text_Rank[TargetIdx].text = this.Cstr_TargetRank[TargetIdx].ToString();
      this.Img_OS[TargetIdx] = this.K1_T.GetChild(8 + TargetIdx).GetComponent<Image>();
      this.text_OS[TargetIdx] = this.K1_T.GetChild(8 + TargetIdx).GetChild(0).GetComponent<UIText>();
      this.text_OS[TargetIdx].font = this.TTFont;
      this.Cstr_TargetStrength[TargetIdx].ClearString();
      this.Cstr_TargetStrength[TargetIdx].IntToFormat((long) this.AM.GetAllPower((byte) 1, TargetIdx), bNumber: true);
      this.Cstr_TargetStrength[TargetIdx].AppendFormat("{0}");
      this.text_OS[TargetIdx].text = this.Cstr_TargetStrength[TargetIdx].ToString();
      this.btn_Hint[TargetIdx] = this.K1_T.GetChild(11 + TargetIdx).GetComponent<UIButton>();
      this.btn_Hint[TargetIdx].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Hint[TargetIdx].m_BtnID1 = 12;
      this.btn_Hint[TargetIdx].m_BtnID2 = TargetIdx;
      UIButtonHint uiButtonHint = ((Component) this.btn_Hint[TargetIdx]).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint.m_eHint = EUIButtonHint.UIArena_Hint;
      uiButtonHint.Parm2 = (byte) TargetIdx;
      uiButtonHint.m_Handler = (MonoBehaviour) this;
      uiButtonHint.ControlFadeOut = ((Component) this.GUIM.m_Arena_Hint.m_RectTransform).gameObject;
      this.btn_Challenge[TargetIdx] = this.K1_T.GetChild(14 + TargetIdx).GetComponent<UIButton>();
      this.btn_Challenge[TargetIdx].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Challenge[TargetIdx].m_BtnID1 = 3 + TargetIdx;
      this.btn_Challenge[TargetIdx].m_EffectType = e_EffectType.e_Scale;
      this.btn_Challenge[TargetIdx].transition = (Selectable.Transition) 0;
      this.text_Challenge[TargetIdx] = this.K1_T.GetChild(14 + TargetIdx).GetChild(0).GetComponent<UIText>();
      this.text_Challenge[TargetIdx].font = this.TTFont;
      this.text_Challenge[TargetIdx].text = this.DM.mStringTable.GetStringByID(9108U);
      this.btn_Challenge[TargetIdx].m_Text = this.text_Challenge[TargetIdx];
      this.text_Challenge_Name[TargetIdx] = this.K1_T.GetChild(17 + TargetIdx).GetComponent<UIText>();
      this.text_Challenge_Name[TargetIdx].font = this.TTFont;
      this.Cstr_TargetName[TargetIdx].ClearString();
      Name.ClearString();
      Tag.ClearString();
      Name.Append(this.AM.m_ArenaTarget[TargetIdx].Name);
      if (this.AM.m_ArenaTarget[TargetIdx].AllianceTagTag != string.Empty)
      {
        Tag.Append(this.AM.m_ArenaTarget[TargetIdx].AllianceTagTag);
        GameConstants.FormatRoleName(this.Cstr_TargetName[TargetIdx], Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      }
      else
        GameConstants.FormatRoleName(this.Cstr_TargetName[TargetIdx], Name, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      this.text_Challenge_Name[TargetIdx].text = this.Cstr_TargetName[TargetIdx].ToString();
    }
    for (int index = 0; index < 3; ++index)
    {
      this.text_Close[index] = this.K2_T.GetChild(1 + index).GetComponent<UIText>();
      this.text_Close[index].font = this.TTFont;
    }
    if (this.AM.CheckArenaClose() > (ushort) 0)
      this.text_Close[0].text = this.DM.mStringTable.GetStringByID((uint) this.AM.CheckArenaClose());
    this.Cstr_CD.ClearString();
    this.Cstr_CDTime.ClearString();
    if (this.AM.bArenaKVK)
    {
      long num1 = this.ActM.KvKActivityData[4].EventBeginTime + (long) this.ActM.KvKActivityData[4].EventReqiureTIme - this.DM.ServerTime;
      if (num1 <= 0L || num1 / 86400L > 0L)
        num1 = 0L;
      this.Cstr_CDTime.IntToFormat(num1 / 3600L, 2);
      long num2 = num1 % 3600L;
      this.Cstr_CDTime.IntToFormat(num2 / 60L, 2);
      this.Cstr_CDTime.IntToFormat(num2 % 60L, 2);
      this.Cstr_CDTime.AppendFormat("{0}:{1}:{2}");
      this.Cstr_CD.StringToFormat(this.Cstr_CDTime);
      this.Cstr_CD.AppendFormat(this.DM.mStringTable.GetStringByID(9110U));
    }
    else if (this.AM.CheckArenaClose() > (ushort) 0)
    {
      long num3 = this.CheckKOWCountTime();
      if (num3 / 86400L > 0L)
      {
        this.Cstr_CDTime.IntToFormat(num3 / 86400L);
        long num4 = num3 % 86400L;
        this.Cstr_CDTime.IntToFormat(num4 / 3600L, 2);
        long num5 = num4 % 3600L;
        this.Cstr_CDTime.IntToFormat(num5 / 60L, 2);
        this.Cstr_CDTime.IntToFormat(num5 % 60L, 2);
        if (this.GUIM.IsArabic)
          this.Cstr_CDTime.AppendFormat("{1}:{2}:{3} {0}d");
        else
          this.Cstr_CDTime.AppendFormat("{0}d {1}:{2}:{3}");
      }
      else
      {
        this.Cstr_CDTime.IntToFormat(num3 / 3600L, 2);
        long num6 = num3 % 3600L;
        this.Cstr_CDTime.IntToFormat(num6 / 60L, 2);
        this.Cstr_CDTime.IntToFormat(num6 % 60L, 2);
        this.Cstr_CDTime.AppendFormat("{0}:{1}:{2}");
      }
      this.Cstr_CD.StringToFormat(this.Cstr_CDTime);
      this.Cstr_CD.AppendFormat(this.DM.mStringTable.GetStringByID(9110U));
    }
    this.text_Close[1].text = this.Cstr_CD.ToString();
    this.text_Close[1].SetAllDirty();
    this.text_Close[1].cachedTextGenerator.Invalidate();
    this.text_Close[2].text = this.DM.mStringTable.GetStringByID(9120U);
    if (this.AM.CheckArenaClose() > (ushort) 0)
    {
      this.K1_T.gameObject.SetActive(false);
      this.K2_T.gameObject.SetActive(true);
      ((Component) this.text_Close[0]).gameObject.SetActive(true);
      ((Component) this.text_Close[1]).gameObject.SetActive(true);
      ((Component) this.text_Close[2]).gameObject.SetActive(false);
      this.img_text.gameObject.SetActive(false);
    }
    else
    {
      this.img_text.gameObject.SetActive(true);
      if (this.bSetHero)
      {
        this.K1_T.gameObject.SetActive(true);
        this.K2_T.gameObject.SetActive(false);
      }
      else
      {
        this.K1_T.gameObject.SetActive(false);
        this.K2_T.gameObject.SetActive(true);
        ((Component) this.text_Close[0]).gameObject.SetActive(false);
        ((Component) this.text_Close[1]).gameObject.SetActive(false);
        ((Component) this.text_Close[2]).gameObject.SetActive(true);
      }
    }
    this.btn_Award = child4.GetChild(3).GetComponent<UIButton>();
    this.btn_Award.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Award.m_BtnID1 = 6;
    this.btn_Award.m_EffectType = e_EffectType.e_Scale;
    this.btn_Award.transition = (Selectable.Transition) 0;
    this.btn_Count = child4.GetChild(4).GetComponent<UIButton>();
    this.btn_Count.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Count.m_BtnID1 = 7;
    this.btn_Count.m_EffectType = e_EffectType.e_Scale;
    this.btn_Count.transition = (Selectable.Transition) 0;
    this.btn_ReSet = child4.GetChild(6).GetComponent<UIButton>();
    this.btn_ReSet.m_Handler = (IUIButtonClickHandler) this;
    this.btn_ReSet.m_BtnID1 = 8;
    this.btn_ReSet.m_EffectType = e_EffectType.e_Scale;
    this.btn_ReSet.transition = (Selectable.Transition) 0;
    this.text_ReSet = child4.GetChild(6).GetChild(0).GetComponent<UIText>();
    this.text_ReSet.font = this.TTFont;
    this.text_ReSet.text = this.DM.mStringTable.GetStringByID(9106U);
    this.btn_ReSet.m_Text = this.text_ReSet;
    if (this.bSetHero)
      this.btn_ReSet.ForTextChange(e_BtnType.e_Normal);
    else
      this.btn_ReSet.ForTextChange(e_BtnType.e_ChangeText);
    for (int index = 0; index < 2; ++index)
    {
      this.text_Award[index] = child4.GetChild(7).GetChild(index + 1).GetComponent<UIText>();
      this.text_Award[index].font = this.TTFont;
    }
    this.text_Award[0].text = this.DM.mStringTable.GetStringByID(9104U);
    this.Cstr_Rank.ClearString();
    this.Cstr_Rank.IntToFormat((long) this.AM.m_ArenaPlace, bNumber: true);
    this.Cstr_Rank.AppendFormat("{0}");
    this.text_Award[1].text = this.Cstr_Rank.ToString();
    this.text_Award[1].SetAllDirty();
    this.text_Award[1].cachedTextGenerator.Invalidate();
    this.text_Award[1].cachedTextGeneratorForLayout.Invalidate();
    this.Img_ArenaPlacedrop = child4.GetChild(7).GetChild(0).GetComponent<Image>();
    this.mArenaPlacedropX = 90f;
    if ((double) this.text_Award[1].preferredWidth < 110.0)
      this.mArenaPlacedropX = (float) ((double) this.text_Award[1].preferredWidth / 2.0 + 35.0);
    ((Graphic) this.Img_ArenaPlacedrop).rectTransform.anchoredPosition = new Vector2(-this.mArenaPlacedropX, ((Graphic) this.Img_ArenaPlacedrop).rectTransform.anchoredPosition.y);
    if (this.DM.CheckPrizeFlag((byte) 20))
    {
      ((Component) this.Img_ArenaPlacedrop).gameObject.SetActive(true);
      this.AM.m_ArenaPlacedropTime = 4f;
      this.AM.bShowArenaPlacedrop = true;
      this.AM.SendArena_UIClear();
    }
    for (int index = 0; index < 2; ++index)
    {
      this.text_Count[index] = child4.GetChild(8).GetChild(index).GetComponent<UIText>();
      this.text_Count[index].font = this.TTFont;
    }
    this.text_Count[0].text = this.DM.mStringTable.GetStringByID(9105U);
    this.Cstr_Count.ClearString();
    if (5 - (int) this.AM.m_ArenaTodayChallenge + (int) this.AM.m_ArenaExtraChallenge == 0)
    {
      CString tmpS = StringManager.Instance.StaticString1024();
      tmpS.ClearString();
      tmpS.IntToFormat(0L);
      tmpS.AppendFormat("<color=#9F1C1C>{0}</color>");
      this.Cstr_Count.StringToFormat(tmpS);
      ((Component) this.btn_Count).gameObject.SetActive(true);
    }
    else
    {
      this.Cstr_Count.IntToFormat((long) (5 - (int) this.AM.m_ArenaTodayChallenge + (int) this.AM.m_ArenaExtraChallenge));
      ((Component) this.btn_Count).gameObject.SetActive(false);
    }
    if (this.GUIM.IsArabic)
      this.Cstr_Count.AppendFormat("5/{0}");
    else
      this.Cstr_Count.AppendFormat("{0}/5");
    this.text_Count[1].text = this.Cstr_Count.ToString();
    ((Component) this.btn_ReSet).gameObject.SetActive(true);
    this.Img_Award = child4.GetChild(10).GetComponent<Image>();
    if (this.AM.m_ArenaCrystalPrize > 0U)
      ((Component) this.Img_Award).gameObject.SetActive(true);
    else
      ((Component) this.Img_Award).gameObject.SetActive(false);
    Transform child5 = child4.GetChild(11);
    this.btn_StrengthHint = child5.GetComponent<UIButton>();
    this.btn_StrengthHint.m_Handler = (IUIButtonClickHandler) this;
    this.btn_StrengthHint.m_BtnID1 = 14;
    UIButtonHint uiButtonHint1 = ((Component) this.btn_StrengthHint).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    this.Img_StrengthHint = child5.GetChild(0).GetComponent<Image>();
    uiButtonHint1.ControlFadeOut = ((Component) this.Img_StrengthHint).gameObject;
    this.text_StrengthHint = child5.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_StrengthHint.font = this.TTFont;
    this.text_StrengthHint.text = this.DM.mStringTable.GetStringByID(19U);
    if ((double) this.text_StrengthHint.preferredWidth > 343.0)
    {
      ((Graphic) this.text_StrengthHint).rectTransform.sizeDelta = new Vector2(((Graphic) this.text_StrengthHint).rectTransform.sizeDelta.x, this.text_StrengthHint.preferredHeight + 1f);
      ((Graphic) this.Img_StrengthHint).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_StrengthHint).rectTransform.sizeDelta.x, this.text_StrengthHint.preferredHeight + 5f);
    }
    Image component3 = this.GameT.GetChild(2).GetComponent<Image>();
    component3.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component3).material = material;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) component3).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(2).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = material;
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    if (NewbieManager.IsTeachWorking(ETeachKind.ARENA))
      NewbieManager.CheckTeach(ETeachKind.ARENA, (object) this);
    if (!this.bSetHero)
      return;
    this.AM.SendArena_Refresh_Target((byte) 2);
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (this.K1_T.gameObject.activeSelf)
    {
      ((Component) this.btn_ReSet).gameObject.SetActive(true);
      if (this.bCDReSet)
      {
        if (this.CDReSetTime > (byte) 0)
          --this.CDReSetTime;
        else
          this.bCDReSet = false;
      }
    }
    if (bOnSecond && ((Component) this.text_Close[1]).gameObject.activeSelf)
    {
      this.Cstr_CD.ClearString();
      this.Cstr_CDTime.ClearString();
      if (this.AM.bArenaKVK)
      {
        long num1 = this.ActM.KvKActivityData[4].EventBeginTime + (long) this.ActM.KvKActivityData[4].EventReqiureTIme - this.DM.ServerTime;
        if (num1 <= 0L || num1 / 86400L > 0L)
          num1 = 0L;
        this.Cstr_CDTime.IntToFormat(num1 / 3600L, 2);
        long num2 = num1 % 3600L;
        this.Cstr_CDTime.IntToFormat(num2 / 60L, 2);
        this.Cstr_CDTime.IntToFormat(num2 % 60L, 2);
        this.Cstr_CDTime.AppendFormat("{0}:{1}:{2}");
        this.Cstr_CD.StringToFormat(this.Cstr_CDTime);
        this.Cstr_CD.AppendFormat(this.DM.mStringTable.GetStringByID(9110U));
      }
      else if (this.AM.CheckArenaClose() > (ushort) 0)
      {
        long num3 = this.CheckKOWCountTime();
        long num4 = num3;
        if (num3 / 86400L > 0L)
        {
          this.Cstr_CDTime.IntToFormat(num3 / 86400L);
          long num5 = num3 % 86400L;
          this.Cstr_CDTime.IntToFormat(num5 / 3600L, 2);
          long num6 = num5 % 3600L;
          this.Cstr_CDTime.IntToFormat(num6 / 60L, 2);
          this.Cstr_CDTime.IntToFormat(num6 % 60L, 2);
          if (this.GUIM.IsArabic)
            this.Cstr_CDTime.AppendFormat("{1}:{2}:{3} {0}d");
          else
            this.Cstr_CDTime.AppendFormat("{0}d {1}:{2}:{3}");
        }
        else
        {
          this.Cstr_CDTime.IntToFormat(num3 / 3600L, 2);
          long num7 = num3 % 3600L;
          this.Cstr_CDTime.IntToFormat(num7 / 60L, 2);
          this.Cstr_CDTime.IntToFormat(num7 % 60L, 2);
          this.Cstr_CDTime.AppendFormat("{0}:{1}:{2}");
        }
        if (num4 == 0L)
        {
          this.AM.SendArena_Refresh_Target((byte) 2);
          this.SetK1_Data();
        }
        this.Cstr_CD.StringToFormat(this.Cstr_CDTime);
        this.Cstr_CD.AppendFormat(this.DM.mStringTable.GetStringByID(9110U));
      }
      this.text_Close[1].text = this.Cstr_CD.ToString();
      this.text_Close[1].SetAllDirty();
      this.text_Close[1].cachedTextGenerator.Invalidate();
    }
    if (!this.GameT.gameObject.activeSelf || !((UnityEngine.Object) this.Img_ArenaPlacedrop != (UnityEngine.Object) null) || !((UIBehaviour) this.Img_ArenaPlacedrop).IsActive() || !this.AM.bShowArenaPlacedrop)
      return;
    this.mArenaPlacedropCD += Time.smoothDeltaTime;
    if ((double) this.mArenaPlacedropCD >= 1.0)
    {
      this.AM.m_ArenaPlacedropTime -= this.mArenaPlacedropCD;
      if ((double) this.AM.m_ArenaPlacedropTime < 0.0)
        this.AM.bShowArenaPlacedrop = false;
      this.mArenaPlacedropCD = 0.0f;
    }
    ((Graphic) this.Img_ArenaPlacedrop).color = new Color(1f, 1f, 1f, (double) this.mArenaPlacedropCD <= 0.5 ? this.mArenaPlacedropCD * 2f : (float) (2.0 - (double) this.mArenaPlacedropCD * 2.0));
    ((Graphic) this.Img_ArenaPlacedrop).rectTransform.anchoredPosition = new Vector2(((Graphic) this.Img_ArenaPlacedrop).rectTransform.anchoredPosition.x, (float) (-44.0 - (double) this.mArenaPlacedropCD / 1.0 * 20.0));
  }

  private uint GetAllPower()
  {
    int length = this.AM.m_ArenaDefHero.Length;
    uint allPower = 0;
    for (int index = 0; index < length; ++index)
      allPower += this.GetPower(this.AM.m_ArenaDefHero[index]);
    return allPower;
  }

  private uint GetPower(ushort heroId)
  {
    uint power = 0;
    if (!DataManager.Instance.curHeroData.ContainsKey((uint) heroId))
      return power;
    CurHeroData curHeroData = DataManager.Instance.curHeroData[(uint) heroId];
    CalcAttrDataType CalcAttrData = new CalcAttrDataType();
    byte[] SkillLV = new byte[4];
    ushort[] pAttr1 = new ushort[28];
    ushort[] pAttr2 = new ushort[28];
    uint HP1 = 0;
    CalcAttrData.SkillLV1 = curHeroData.SkillLV[0];
    CalcAttrData.SkillLV2 = curHeroData.SkillLV[1];
    CalcAttrData.SkillLV3 = curHeroData.SkillLV[2];
    CalcAttrData.SkillLV4 = curHeroData.SkillLV[3];
    for (int index = 0; index < 4; ++index)
      SkillLV[index] = curHeroData.SkillLV[index];
    CalcAttrData.LV = curHeroData.Level;
    CalcAttrData.Star = curHeroData.Star;
    CalcAttrData.Enhance = curHeroData.Enhance;
    CalcAttrData.Equip = curHeroData.Equip;
    uint HP2 = 0;
    Array.Clear((Array) pAttr1, 0, pAttr1.Length);
    BSInvokeUtil.getInstance.setCalculateHeroEquipEffect(heroId, curHeroData.Enhance, curHeroData.Equip, ref HP2, pAttr1);
    Array.Clear((Array) pAttr2, 0, pAttr2.Length);
    BSInvokeUtil.getInstance.setCalculateAttribute(heroId, ref CalcAttrData, ref HP1, pAttr2);
    return BSInvokeUtil.getInstance.updateFightScore(heroId, HP1, pAttr2, SkillLV);
  }

  public override void OnClose()
  {
    if (this.Cstr_ReplayNum != null)
      StringManager.Instance.DeSpawnString(this.Cstr_ReplayNum);
    if (this.Cstr_Propaganda != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Propaganda);
    if (this.Cstr_Strength != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Strength);
    if (this.Cstr_Rank != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Rank);
    if (this.Cstr_Count != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Count);
    if (this.Cstr_CD != null)
      StringManager.Instance.DeSpawnString(this.Cstr_CD);
    if (this.Cstr_CDTime != null)
      StringManager.Instance.DeSpawnString(this.Cstr_CDTime);
    for (int index = 0; index < 3; ++index)
    {
      if (this.Cstr_TargetName[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_TargetName[index]);
      if (this.Cstr_TargetRank[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_TargetRank[index]);
      if (this.Cstr_TargetStrength[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_TargetStrength[index]);
    }
    if ((double) this.AM.m_ArenaPlacedropTime > 0.0)
      this.AM.m_ArenaPlacedropTime = 0.0f;
    if (!this.AM.bShowArenaPlacedrop)
      return;
    this.AM.bShowArenaPlacedrop = false;
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 1:
        if (this.AM.CheckArenaClose() > (ushort) 0)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID((uint) this.AM.CheckArenaClose()), (ushort) byte.MaxValue);
          break;
        }
        this.door.OpenMenu(EGUIWindow.UI_BattleHeroSelect, arg2: -1, bCameraMode: true);
        break;
      case 2:
        this.door.OpenMenu(EGUIWindow.UI_Arena_I);
        break;
      case 3:
      case 4:
      case 5:
        this.AM.m_ArenaTargetIdx = (byte) (sender.m_BtnID1 - 3);
        if (5 - (int) this.AM.m_ArenaTodayChallenge + (int) this.AM.m_ArenaExtraChallenge == 0)
        {
          int Cost = (int) this.AM.m_ArenaTodayResetChallenge < this.AM.m_TodayChallengeCost.Length ? (int) this.AM.m_TodayChallengeCost[(int) this.AM.m_ArenaTodayResetChallenge] : (int) this.AM.m_TodayChallengeCost[11];
          GUIManager.Instance.OpenSpendWindow_Normal((GUIWindow) this, this.DM.mStringTable.GetStringByID(9144U), this.DM.mStringTable.GetStringByID(9145U), Cost, 3, Buttontext: this.DM.mStringTable.GetStringByID(9146U));
          break;
        }
        this.door.OpenMenu(EGUIWindow.UI_BattleHeroSelect, (int) this.AM.m_ArenaTargetIdx, -2, true);
        break;
      case 6:
        GUIManager.Instance.OpenUI_Queued_Restricted(EGUIWindow.UI_TreasureBox, 9, openMode: (byte) 0);
        break;
      case 7:
        if (this.AM.CheckArenaClose() > (ushort) 0)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID((uint) this.AM.CheckArenaClose()), (ushort) byte.MaxValue);
          break;
        }
        int Cost1 = (int) this.AM.m_ArenaTodayResetChallenge < this.AM.m_TodayChallengeCost.Length ? (int) this.AM.m_TodayChallengeCost[(int) this.AM.m_ArenaTodayResetChallenge] : (int) this.AM.m_TodayChallengeCost[11];
        GUIManager.Instance.OpenSpendWindow_Normal((GUIWindow) this, this.DM.mStringTable.GetStringByID(9144U), this.DM.mStringTable.GetStringByID(9145U), Cost1, 1, Buttontext: this.DM.mStringTable.GetStringByID(9146U));
        break;
      case 8:
        if (this.AM.CheckArenaClose() > (ushort) 0)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID((uint) this.AM.CheckArenaClose()), (ushort) byte.MaxValue);
          break;
        }
        if (this.bCDReSet)
          break;
        if (this.bSetHero)
        {
          this.bCDReSet = true;
          this.CDReSetTime = (byte) 1;
          this.AM.SendArena_Refresh_Target((byte) 1);
          break;
        }
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9120U), (ushort) byte.MaxValue);
        break;
      case 9:
        if (this.AM.CheckArenaClose() > (ushort) 0)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID((uint) this.AM.CheckArenaClose()), (ushort) byte.MaxValue);
          break;
        }
        this.door.OpenMenu(EGUIWindow.UI_BattleHeroSelect, arg2: -1, bCameraMode: true);
        break;
      case 10:
        if (!this.bSetHero)
          break;
        this.door.OpenMenu(EGUIWindow.UI_Arena_Replay);
        break;
      case 11:
        if (this.AM.CheckArenaClose() > (ushort) 0)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID((uint) this.AM.CheckArenaClose()), (ushort) byte.MaxValue);
          break;
        }
        UILeaderBoard.NewOpen = true;
        this.door.OpenMenu(EGUIWindow.UI_LeaderBoard, 3);
        break;
      case 13:
        this.door.OpenMenu(EGUIWindow.UI_Arena_Info);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    UIButton component = sender.transform.GetComponent<UIButton>();
    switch (component.m_BtnID1)
    {
      case 12:
        sender.m_ForcePos = true;
        sender.GetTipPosition(this.GUIM.m_Arena_Hint.m_RectTransform);
        this.AM.m_ArenaTargetHint = this.AM.m_ArenaTarget[(int) (byte) component.m_BtnID2];
        this.GUIM.m_Arena_Hint.Show(sender.transform.GetComponent<UIButtonHint>(), 120f, (float) (50 - 100 * component.m_BtnID2), (byte) 0);
        break;
      case 14:
        ((Component) this.Img_StrengthHint).gameObject.SetActive(true);
        break;
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    switch (sender.transform.GetComponent<UIButton>().m_BtnID1)
    {
      case 12:
        this.GUIM.m_Arena_Hint.Hide(sender);
        break;
      case 14:
        ((Component) this.Img_StrengthHint).gameObject.SetActive(false);
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 1:
        int price1 = (int) this.AM.m_ArenaTodayResetChallenge < this.AM.m_TodayChallengeCost.Length ? (int) this.AM.m_TodayChallengeCost[(int) this.AM.m_ArenaTodayResetChallenge] : (int) this.AM.m_TodayChallengeCost[11];
        if ((long) this.DM.RoleAttr.Diamond >= (long) price1)
        {
          if (GUIManager.Instance.OpenCheckCrystal((uint) price1, (byte) 2))
            break;
          this.AM.SendArena_ReSet_TodayChallenge();
          break;
        }
        CString cstring1 = StringManager.Instance.StaticString1024();
        cstring1.ClearString();
        cstring1.StringToFormat(this.DM.mStringTable.GetStringByID(9144U));
        cstring1.AppendFormat(this.DM.mStringTable.GetStringByID(3857U));
        this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966U), cstring1.ToString(), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 5, bCloseIDSet: true);
        break;
      case 2:
        if (this.DM.RoleAttr.Diamond >= 120U)
        {
          this.AM.SendArena_ReSet_Challenge_CD();
          break;
        }
        CString cstring2 = StringManager.Instance.StaticString1024();
        cstring2.ClearString();
        cstring2.StringToFormat(this.DM.mStringTable.GetStringByID(9147U));
        cstring2.AppendFormat(this.DM.mStringTable.GetStringByID(3857U));
        this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966U), cstring2.ToString(), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 5, bCloseIDSet: true);
        break;
      case 3:
        int price2 = (int) this.AM.m_ArenaTodayResetChallenge < this.AM.m_TodayChallengeCost.Length ? (int) this.AM.m_TodayChallengeCost[(int) this.AM.m_ArenaTodayResetChallenge] : (int) this.AM.m_TodayChallengeCost[11];
        if ((long) this.DM.RoleAttr.Diamond >= (long) price2)
        {
          if (!GUIManager.Instance.OpenCheckCrystal((uint) price2, (byte) 2))
            this.AM.SendArena_ReSet_TodayChallenge();
          this.bChallengeCount = true;
          break;
        }
        CString cstring3 = StringManager.Instance.StaticString1024();
        cstring3.ClearString();
        cstring3.StringToFormat(this.DM.mStringTable.GetStringByID(9144U));
        cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(3857U));
        this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966U), cstring3.ToString(), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 5, bCloseIDSet: true);
        break;
      case 4:
        if (this.DM.RoleAttr.Diamond >= 120U)
        {
          this.AM.SendArena_ReSet_Challenge_CD();
          this.bChallengeCD = true;
          break;
        }
        CString cstring4 = StringManager.Instance.StaticString1024();
        cstring4.ClearString();
        cstring4.StringToFormat(this.DM.mStringTable.GetStringByID(9147U));
        cstring4.AppendFormat(this.DM.mStringTable.GetStringByID(3857U));
        this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966U), cstring4.ToString(), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 5, bCloseIDSet: true);
        break;
      case 5:
        MallManager.Instance.Send_Mall_Info();
        break;
    }
  }

  public void SetTodayChallenge()
  {
    CString tmpS = StringManager.Instance.StaticString1024();
    this.Cstr_Count.ClearString();
    if (5 - (int) this.AM.m_ArenaTodayChallenge + (int) this.AM.m_ArenaExtraChallenge == 0)
    {
      tmpS.ClearString();
      tmpS.IntToFormat(0L);
      tmpS.AppendFormat("<color=#9F1C1C>{0}</color>");
      this.Cstr_Count.StringToFormat(tmpS);
      ((Component) this.btn_Count).gameObject.SetActive(true);
    }
    else
    {
      this.Cstr_Count.IntToFormat((long) (5 - (int) this.AM.m_ArenaTodayChallenge + (int) this.AM.m_ArenaExtraChallenge));
      ((Component) this.btn_Count).gameObject.SetActive(false);
    }
    if (this.GUIM.IsArabic)
      this.Cstr_Count.AppendFormat("5/{0}");
    else
      this.Cstr_Count.AppendFormat("{0}/5");
    this.text_Count[1].text = this.Cstr_Count.ToString();
    this.text_Count[1].SetAllDirty();
    this.text_Count[1].cachedTextGenerator.Invalidate();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.SetTodayChallenge();
        if (!this.bChallengeCount)
          break;
        this.bChallengeCount = false;
        this.door.OpenMenu(EGUIWindow.UI_BattleHeroSelect, (int) this.AM.m_ArenaTargetIdx, -2, true);
        break;
      case 2:
        this.SetTodayChallenge();
        ((Component) this.btn_ReSet).gameObject.SetActive(true);
        if (!this.bChallengeCD)
          break;
        this.bChallengeCD = false;
        if (5 - (int) this.AM.m_ArenaTodayChallenge + (int) this.AM.m_ArenaExtraChallenge == 0)
          break;
        this.door.OpenMenu(EGUIWindow.UI_BattleHeroSelect, (int) this.AM.m_ArenaTargetIdx, -2, true);
        break;
      case 3:
        this.Cstr_Rank.ClearString();
        this.Cstr_Rank.IntToFormat((long) this.AM.m_ArenaPlace, bNumber: true);
        this.Cstr_Rank.AppendFormat("{0}");
        this.text_Award[1].text = this.Cstr_Rank.ToString();
        this.text_Award[1].SetAllDirty();
        this.text_Award[1].cachedTextGenerator.Invalidate();
        this.text_Award[1].cachedTextGeneratorForLayout.Invalidate();
        this.mArenaPlacedropX = 90f;
        if ((double) this.text_Award[1].preferredWidth < 110.0)
          this.mArenaPlacedropX = (float) ((double) this.text_Award[1].preferredWidth / 2.0 + 35.0);
        ((Graphic) this.Img_ArenaPlacedrop).rectTransform.anchoredPosition = new Vector2(-this.mArenaPlacedropX, ((Graphic) this.Img_ArenaPlacedrop).rectTransform.anchoredPosition.y);
        break;
      case 4:
        CString Name1 = StringManager.Instance.StaticString1024();
        CString Tag1 = StringManager.Instance.StaticString1024();
        for (int TargetIdx = 0; TargetIdx < 3; ++TargetIdx)
        {
          this.GUIM.ChangeHeroItemImg(((Component) this.btn_Opponent[TargetIdx]).transform, eHeroOrItem.Hero, this.AM.m_ArenaTarget[TargetIdx].Head, (byte) 11, (byte) 0);
          this.Cstr_TargetRank[TargetIdx].ClearString();
          this.Cstr_TargetRank[TargetIdx].IntToFormat((long) this.AM.m_ArenaTarget[TargetIdx].Place, bNumber: true);
          this.Cstr_TargetRank[TargetIdx].AppendFormat("{0}");
          this.text_Rank[TargetIdx].text = this.Cstr_TargetRank[TargetIdx].ToString();
          this.text_Rank[TargetIdx].SetAllDirty();
          this.text_Rank[TargetIdx].cachedTextGenerator.Invalidate();
          this.Cstr_TargetStrength[TargetIdx].ClearString();
          this.Cstr_TargetStrength[TargetIdx].IntToFormat((long) this.AM.GetAllPower((byte) 1, TargetIdx), bNumber: true);
          this.Cstr_TargetStrength[TargetIdx].AppendFormat("{0}");
          this.text_OS[TargetIdx].text = this.Cstr_TargetStrength[TargetIdx].ToString();
          this.text_OS[TargetIdx].SetAllDirty();
          this.text_OS[TargetIdx].cachedTextGenerator.Invalidate();
          this.Cstr_TargetName[TargetIdx].ClearString();
          Name1.ClearString();
          Tag1.ClearString();
          Name1.Append(this.AM.m_ArenaTarget[TargetIdx].Name);
          if (this.AM.m_ArenaTarget[TargetIdx].AllianceTagTag != string.Empty)
          {
            Tag1.Append(this.AM.m_ArenaTarget[TargetIdx].AllianceTagTag);
            GameConstants.FormatRoleName(this.Cstr_TargetName[TargetIdx], Name1, Tag1, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
          }
          else
            GameConstants.FormatRoleName(this.Cstr_TargetName[TargetIdx], Name1, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
          this.text_Challenge_Name[TargetIdx].text = this.Cstr_TargetName[TargetIdx].ToString();
          this.text_Challenge_Name[TargetIdx].SetAllDirty();
          this.text_Challenge_Name[TargetIdx].cachedTextGenerator.Invalidate();
        }
        break;
      case 5:
        this.Cstr_ReplayNum.ClearString();
        this.Cstr_ReplayNum.IntToFormat((long) this.AM.m_ArenaNewReportNum);
        this.Cstr_ReplayNum.AppendFormat("{0}");
        this.text_ReplayNum.text = this.Cstr_ReplayNum.ToString();
        this.text_ReplayNum.SetAllDirty();
        this.text_ReplayNum.cachedTextGenerator.Invalidate();
        this.text_ReplayNum.cachedTextGeneratorForLayout.Invalidate();
        ((Graphic) this.Img_ReplayNum).rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_ReplayNum.preferredWidth), ((Graphic) this.Img_ReplayNum).rectTransform.sizeDelta.y);
        if (this.AM.m_ArenaNewReportNum > (byte) 0)
          ((Component) this.Img_ReplayNum).gameObject.SetActive(true);
        else
          ((Component) this.Img_ReplayNum).gameObject.SetActive(false);
        this.Cstr_Rank.ClearString();
        this.Cstr_Rank.IntToFormat((long) this.AM.m_ArenaPlace, bNumber: true);
        this.Cstr_Rank.AppendFormat("{0}");
        this.text_Award[1].text = this.Cstr_Rank.ToString();
        this.text_Award[1].SetAllDirty();
        this.text_Award[1].cachedTextGenerator.Invalidate();
        this.text_Award[1].cachedTextGeneratorForLayout.Invalidate();
        this.mArenaPlacedropX = 90f;
        if ((double) this.text_Award[1].preferredWidth < 110.0)
          this.mArenaPlacedropX = (float) ((double) this.text_Award[1].preferredWidth / 2.0 + 35.0);
        ((Graphic) this.Img_ArenaPlacedrop).rectTransform.anchoredPosition = new Vector2(-this.mArenaPlacedropX, ((Graphic) this.Img_ArenaPlacedrop).rectTransform.anchoredPosition.y);
        break;
      case 6:
        this.AM.bArenaKVK = this.ActM.IsInKvK((ushort) 0);
        if (this.AM.CheckArenaClose() > (ushort) 0)
        {
          this.K1_T.gameObject.SetActive(false);
          this.K2_T.gameObject.SetActive(true);
          this.text_Close[0].text = this.DM.mStringTable.GetStringByID((uint) this.AM.CheckArenaClose());
          this.text_Close[0].SetAllDirty();
          this.text_Close[0].cachedTextGenerator.Invalidate();
          ((Component) this.text_Close[0]).gameObject.SetActive(true);
          ((Component) this.text_Close[1]).gameObject.SetActive(true);
          ((Component) this.text_Close[2]).gameObject.SetActive(false);
          break;
        }
        this.SetK1_Data();
        break;
      case 7:
        this.bSetHero = false;
        for (int index = 0; index < 5; ++index)
        {
          ((Component) this.Img_HeroStar[index]).gameObject.SetActive(false);
          if (DataManager.Instance.curHeroData.ContainsKey((uint) this.AM.m_ArenaDefHero[index]))
          {
            this.mcurHeroData = DataManager.Instance.curHeroData[(uint) this.AM.m_ArenaDefHero[index]];
            ((Component) this.btn_Hero[index]).gameObject.SetActive(true);
            this.GUIM.InitianHeroItemImg(((Component) this.btn_Hero[index]).transform, eHeroOrItem.Hero, this.AM.m_ArenaDefHero[index], this.mcurHeroData.Star, this.mcurHeroData.Enhance, (int) this.mcurHeroData.Level);
            if (this.AM.CheckHeroAstrology(this.AM.m_ArenaDefHero[index]))
              ((Component) this.Img_HeroStar[index]).gameObject.SetActive(true);
            this.bSetHero = true;
            ((Component) this.Img_Hero[index]).gameObject.SetActive(false);
          }
          else
          {
            ((Component) this.btn_Hero[index]).gameObject.SetActive(false);
            ((Component) this.Img_Hero[index]).gameObject.SetActive(true);
          }
        }
        break;
      case 8:
        this.GUIM.ChangeHeroItemImg(((Component) this.btn_Opponent[arg2]).transform, eHeroOrItem.Hero, this.AM.m_ArenaTarget[arg2].Head, (byte) 11, (byte) 0);
        this.Cstr_TargetRank[arg2].ClearString();
        this.Cstr_TargetRank[arg2].IntToFormat((long) this.AM.m_ArenaTarget[arg2].Place, bNumber: true);
        this.Cstr_TargetRank[arg2].AppendFormat("{0}");
        this.text_Rank[arg2].text = this.Cstr_TargetRank[arg2].ToString();
        this.text_Rank[arg2].SetAllDirty();
        this.text_Rank[arg2].cachedTextGenerator.Invalidate();
        this.Cstr_TargetStrength[arg2].ClearString();
        this.Cstr_TargetStrength[arg2].IntToFormat((long) this.AM.GetAllPower((byte) 1, arg2), bNumber: true);
        this.Cstr_TargetStrength[arg2].AppendFormat("{0}");
        this.text_OS[arg2].text = this.Cstr_TargetStrength[arg2].ToString();
        this.text_OS[arg2].SetAllDirty();
        this.text_OS[arg2].cachedTextGenerator.Invalidate();
        this.Cstr_TargetName[arg2].ClearString();
        CString Name2 = StringManager.Instance.StaticString1024();
        CString Tag2 = StringManager.Instance.StaticString1024();
        Name2.ClearString();
        Tag2.ClearString();
        Name2.Append(this.AM.m_ArenaTarget[arg2].Name);
        if (this.AM.m_ArenaTarget[arg2].AllianceTagTag != string.Empty)
        {
          Tag2.Append(this.AM.m_ArenaTarget[arg2].AllianceTagTag);
          GameConstants.FormatRoleName(this.Cstr_TargetName[arg2], Name2, Tag2, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
        }
        else
          GameConstants.FormatRoleName(this.Cstr_TargetName[arg2], Name2, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
        this.text_Challenge_Name[arg2].text = this.Cstr_TargetName[arg2].ToString();
        this.text_Challenge_Name[arg2].SetAllDirty();
        this.text_Challenge_Name[arg2].cachedTextGenerator.Invalidate();
        break;
      case 9:
        if (this.AM.m_ArenaCrystalPrize > 0U)
        {
          ((Component) this.Img_Award).gameObject.SetActive(true);
          break;
        }
        ((Component) this.Img_Award).gameObject.SetActive(false);
        break;
      case 10:
        this.AM.bArenaKVK = this.ActM.IsInKvK((ushort) 0);
        if (this.AM.CheckArenaClose() > (ushort) 0)
        {
          this.K1_T.gameObject.SetActive(false);
          this.K2_T.gameObject.SetActive(true);
          this.text_Close[0].text = this.DM.mStringTable.GetStringByID((uint) this.AM.CheckArenaClose());
          this.text_Close[0].SetAllDirty();
          this.text_Close[0].cachedTextGenerator.Invalidate();
          ((Component) this.text_Close[0]).gameObject.SetActive(true);
          ((Component) this.text_Close[1]).gameObject.SetActive(true);
          ((Component) this.text_Close[2]).gameObject.SetActive(false);
        }
        else
          this.SetK1_Data();
        ((Component) this.GUIM.m_Arena_Hint.m_RectTransform).gameObject.SetActive(false);
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9162U), (ushort) byte.MaxValue);
        break;
      case 11:
        if (!((UnityEngine.Object) this.Img_ArenaPlacedrop != (UnityEngine.Object) null) || !this.DM.CheckPrizeFlag((byte) 20))
          break;
        ((Component) this.Img_ArenaPlacedrop).gameObject.SetActive(true);
        this.AM.SendArena_UIClear();
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.AM.bArenaKVK = this.ActM.IsInKvK((ushort) 0);
        if (this.AM.CheckArenaClose() > (ushort) 0)
        {
          this.K1_T.gameObject.SetActive(false);
          this.K2_T.gameObject.SetActive(true);
          break;
        }
        this.SetK1_Data();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void SetK1_Data()
  {
    this.Cstr_Propaganda.ClearString();
    CString cstring1 = StringManager.Instance.StaticString1024();
    CString cstring2 = StringManager.Instance.StaticString1024();
    CString cstring3 = StringManager.Instance.StaticString1024();
    cstring1.ClearString();
    cstring2.ClearString();
    cstring3.ClearString();
    this.AM.GetHeroAstrology(cstring1, cstring2);
    if (this.AM.m_NowArenaTopicID[0] != (byte) 0 && this.AM.m_NowArenaTopicID[1] != (byte) 0)
    {
      cstring3.StringToFormat(cstring1);
      cstring3.StringToFormat(cstring2);
      cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9118U));
    }
    else
    {
      if (this.AM.m_NowArenaTopicID[0] != (byte) 0)
        cstring3.StringToFormat(cstring1);
      else
        cstring3.StringToFormat(cstring2);
      cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9154U));
    }
    this.Cstr_Propaganda.Append(cstring3);
    this.Cstr_Propaganda.Append("     ");
    cstring1.ClearString();
    cstring2.ClearString();
    cstring3.ClearString();
    if (this.AM.m_NowTopicEffect[0].Effect != (ushort) 0 && this.AM.m_NowTopicEffect[1].Effect != (ushort) 0)
    {
      GameConstants.GetEffectValue(cstring1, this.AM.m_NowTopicEffect[0].Effect, (uint) this.AM.m_NowTopicEffect[0].Value, (byte) 10, 0.0f);
      GameConstants.GetEffectValue(cstring2, this.AM.m_NowTopicEffect[1].Effect, (uint) this.AM.m_NowTopicEffect[1].Value, (byte) 10, 0.0f);
      cstring3.StringToFormat(cstring1);
      cstring3.StringToFormat(cstring2);
      cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9119U));
      cstring3.Append(" ");
    }
    else
    {
      if (this.AM.m_NowTopicEffect[0].Effect != (ushort) 0)
        GameConstants.GetEffectValue(cstring1, this.AM.m_NowTopicEffect[0].Effect, (uint) this.AM.m_NowTopicEffect[0].Value, (byte) 10, 0.0f);
      else
        GameConstants.GetEffectValue(cstring1, this.AM.m_NowTopicEffect[1].Effect, (uint) this.AM.m_NowTopicEffect[1].Value, (byte) 10, 0.0f);
      cstring3.StringToFormat(cstring1);
      cstring3.AppendFormat(this.DM.mStringTable.GetStringByID(9155U));
      cstring3.Append(" ");
    }
    this.Cstr_Propaganda.Append(cstring3);
    this.text_Propaganda[0].text = this.Cstr_Propaganda.ToString();
    this.text_Propaganda[1].font = this.TTFont;
    this.text_Propaganda[1].text = this.Cstr_Propaganda.ToString();
    ((Graphic) this.text_Propaganda[0]).rectTransform.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth + 160f, ((Graphic) this.text_Propaganda[0]).rectTransform.sizeDelta.y);
    ((Graphic) this.text_Propaganda[1]).rectTransform.anchoredPosition = new Vector2(this.text_Propaganda[0].preferredWidth + 160f, ((Graphic) this.text_Propaganda[1]).rectTransform.anchoredPosition.y);
    ((Graphic) this.text_Propaganda[1]).rectTransform.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth + 160f, ((Graphic) this.text_Propaganda[1]).rectTransform.sizeDelta.y);
    this.img_text.tmpLength = this.text_Propaganda[0].preferredWidth + 160f;
    for (int index = 0; index < 2; ++index)
    {
      this.text_Propaganda[index].SetAllDirty();
      this.text_Propaganda[index].cachedTextGenerator.Invalidate();
    }
    this.bSetHero = false;
    for (int index = 0; index < 5; ++index)
    {
      ((Component) this.Img_HeroStar[index]).gameObject.SetActive(false);
      if (DataManager.Instance.curHeroData.ContainsKey((uint) this.AM.m_ArenaDefHero[index]))
      {
        this.mcurHeroData = DataManager.Instance.curHeroData[(uint) this.AM.m_ArenaDefHero[index]];
        ((Component) this.btn_Hero[index]).gameObject.SetActive(true);
        this.GUIM.ChangeHeroItemImg(((Component) this.btn_Hero[index]).transform, eHeroOrItem.Hero, this.AM.m_ArenaDefHero[index], this.mcurHeroData.Star, this.mcurHeroData.Enhance, (int) this.mcurHeroData.Level);
        if (this.AM.CheckHeroAstrology(this.AM.m_ArenaDefHero[index]))
          ((Component) this.Img_HeroStar[index]).gameObject.SetActive(true);
        this.bSetHero = true;
        ((Component) this.Img_Hero[index]).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.btn_Hero[index]).gameObject.SetActive(false);
        ((Component) this.Img_Hero[index]).gameObject.SetActive(true);
      }
    }
    this.Cstr_Count.ClearString();
    if (5 - (int) this.AM.m_ArenaTodayChallenge + (int) this.AM.m_ArenaExtraChallenge == 0)
    {
      cstring1.ClearString();
      cstring1.IntToFormat(0L);
      cstring1.AppendFormat("<color=#9F1C1C>{0}</color>");
      this.Cstr_Count.StringToFormat(cstring1);
      ((Component) this.btn_Count).gameObject.SetActive(true);
    }
    else
    {
      this.Cstr_Count.IntToFormat((long) (5 - (int) this.AM.m_ArenaTodayChallenge + (int) this.AM.m_ArenaExtraChallenge));
      ((Component) this.btn_Count).gameObject.SetActive(false);
    }
    if (this.GUIM.IsArabic)
      this.Cstr_Count.AppendFormat("5/{0}");
    else
      this.Cstr_Count.AppendFormat("{0}/5");
    this.text_Count[1].text = this.Cstr_Count.ToString();
    this.text_Count[1].SetAllDirty();
    this.text_Count[1].cachedTextGenerator.Invalidate();
    this.Cstr_Rank.ClearString();
    this.Cstr_Rank.IntToFormat((long) this.AM.m_ArenaPlace, bNumber: true);
    this.Cstr_Rank.AppendFormat("{0}");
    this.text_Award[1].text = this.Cstr_Rank.ToString();
    this.text_Award[1].SetAllDirty();
    this.text_Award[1].cachedTextGenerator.Invalidate();
    this.text_Award[1].cachedTextGeneratorForLayout.Invalidate();
    this.mArenaPlacedropX = 90f;
    if ((double) this.text_Award[1].preferredWidth < 110.0)
      this.mArenaPlacedropX = (float) ((double) this.text_Award[1].preferredWidth / 2.0 + 35.0);
    ((Graphic) this.Img_ArenaPlacedrop).rectTransform.anchoredPosition = new Vector2(-this.mArenaPlacedropX, ((Graphic) this.Img_ArenaPlacedrop).rectTransform.anchoredPosition.y);
    CString Name = StringManager.Instance.StaticString1024();
    CString Tag = StringManager.Instance.StaticString1024();
    for (int TargetIdx = 0; TargetIdx < 3; ++TargetIdx)
    {
      this.GUIM.ChangeHeroItemImg(((Component) this.btn_Opponent[TargetIdx]).transform, eHeroOrItem.Hero, this.AM.m_ArenaTarget[TargetIdx].Head, (byte) 11, (byte) 0);
      this.Cstr_TargetRank[TargetIdx].ClearString();
      this.Cstr_TargetRank[TargetIdx].IntToFormat((long) this.AM.m_ArenaTarget[TargetIdx].Place, bNumber: true);
      this.Cstr_TargetRank[TargetIdx].AppendFormat("{0}");
      this.text_Rank[TargetIdx].text = this.Cstr_TargetRank[TargetIdx].ToString();
      this.text_Rank[TargetIdx].SetAllDirty();
      this.text_Rank[TargetIdx].cachedTextGenerator.Invalidate();
      this.Cstr_TargetStrength[TargetIdx].ClearString();
      this.Cstr_TargetStrength[TargetIdx].IntToFormat((long) this.AM.GetAllPower((byte) 1, TargetIdx), bNumber: true);
      this.Cstr_TargetStrength[TargetIdx].AppendFormat("{0}");
      this.text_OS[TargetIdx].text = this.Cstr_TargetStrength[TargetIdx].ToString();
      this.text_OS[TargetIdx].SetAllDirty();
      this.text_OS[TargetIdx].cachedTextGenerator.Invalidate();
      this.Cstr_TargetName[TargetIdx].ClearString();
      Name.ClearString();
      Tag.ClearString();
      Name.Append(this.AM.m_ArenaTarget[TargetIdx].Name);
      if (this.AM.m_ArenaTarget[TargetIdx].AllianceTagTag != string.Empty)
      {
        Tag.Append(this.AM.m_ArenaTarget[TargetIdx].AllianceTagTag);
        GameConstants.FormatRoleName(this.Cstr_TargetName[TargetIdx], Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      }
      else
        GameConstants.FormatRoleName(this.Cstr_TargetName[TargetIdx], Name, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      this.text_Challenge_Name[TargetIdx].text = this.Cstr_TargetName[TargetIdx].ToString();
      this.text_Challenge_Name[TargetIdx].SetAllDirty();
      this.text_Challenge_Name[TargetIdx].cachedTextGenerator.Invalidate();
    }
    this.Cstr_ReplayNum.ClearString();
    this.Cstr_ReplayNum.IntToFormat((long) this.AM.m_ArenaNewReportNum);
    this.Cstr_ReplayNum.AppendFormat("{0}");
    this.text_ReplayNum.text = this.Cstr_ReplayNum.ToString();
    this.text_ReplayNum.SetAllDirty();
    this.text_ReplayNum.cachedTextGenerator.Invalidate();
    this.text_ReplayNum.cachedTextGeneratorForLayout.Invalidate();
    ((Graphic) this.Img_ReplayNum).rectTransform.sizeDelta = new Vector2(Door.GetRedBackWidth(this.text_ReplayNum.preferredWidth), ((Graphic) this.Img_ReplayNum).rectTransform.sizeDelta.y);
    if (this.AM.m_ArenaNewReportNum > (byte) 0)
      ((Component) this.Img_ReplayNum).gameObject.SetActive(true);
    else
      ((Component) this.Img_ReplayNum).gameObject.SetActive(false);
    if (this.bSetHero)
    {
      this.K1_T.gameObject.SetActive(true);
      this.K2_T.gameObject.SetActive(false);
      this.btn_ReSet.ForTextChange(e_BtnType.e_Normal);
    }
    else
    {
      this.K1_T.gameObject.SetActive(false);
      this.K2_T.gameObject.SetActive(true);
      ((Component) this.text_Close[0]).gameObject.SetActive(false);
      ((Component) this.text_Close[1]).gameObject.SetActive(false);
      ((Component) this.text_Close[2]).gameObject.SetActive(true);
      this.btn_ReSet.ForTextChange(e_BtnType.e_ChangeText);
    }
    if (this.AM.m_ArenaCrystalPrize > 0U)
      ((Component) this.Img_Award).gameObject.SetActive(true);
    else
      ((Component) this.Img_Award).gameObject.SetActive(false);
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.text_Title != (UnityEngine.Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((UnityEngine.Object) this.text_ReplayNum != (UnityEngine.Object) null && ((Behaviour) this.text_ReplayNum).enabled)
    {
      ((Behaviour) this.text_ReplayNum).enabled = false;
      ((Behaviour) this.text_ReplayNum).enabled = true;
    }
    if ((UnityEngine.Object) this.img_text != (UnityEngine.Object) null)
    {
      if ((UnityEngine.Object) this.img_text.m_RunningText1 != (UnityEngine.Object) null && ((Behaviour) this.img_text.m_RunningText1).enabled)
      {
        ((Behaviour) this.img_text.m_RunningText1).enabled = false;
        ((Behaviour) this.img_text.m_RunningText1).enabled = true;
      }
      if ((UnityEngine.Object) this.img_text.m_RunningText2 != (UnityEngine.Object) null && ((Behaviour) this.img_text.m_RunningText2).enabled)
      {
        ((Behaviour) this.img_text.m_RunningText2).enabled = false;
        ((Behaviour) this.img_text.m_RunningText2).enabled = true;
      }
    }
    if ((UnityEngine.Object) this.text_Defend != (UnityEngine.Object) null && ((Behaviour) this.text_Defend).enabled)
    {
      ((Behaviour) this.text_Defend).enabled = false;
      ((Behaviour) this.text_Defend).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Strength != (UnityEngine.Object) null && ((Behaviour) this.text_Strength).enabled)
    {
      ((Behaviour) this.text_Strength).enabled = false;
      ((Behaviour) this.text_Strength).enabled = true;
    }
    if ((UnityEngine.Object) this.text_ReSet != (UnityEngine.Object) null && ((Behaviour) this.text_ReSet).enabled)
    {
      ((Behaviour) this.text_ReSet).enabled = false;
      ((Behaviour) this.text_ReSet).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((UnityEngine.Object) this.text_Propaganda[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Propaganda[index]).enabled)
      {
        ((Behaviour) this.text_Propaganda[index]).enabled = false;
        ((Behaviour) this.text_Propaganda[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Award[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Award[index]).enabled)
      {
        ((Behaviour) this.text_Award[index]).enabled = false;
        ((Behaviour) this.text_Award[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Count[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Count[index]).enabled)
      {
        ((Behaviour) this.text_Count[index]).enabled = false;
        ((Behaviour) this.text_Count[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_CD[index] != (UnityEngine.Object) null && ((Behaviour) this.text_CD[index]).enabled)
      {
        ((Behaviour) this.text_CD[index]).enabled = false;
        ((Behaviour) this.text_CD[index]).enabled = true;
      }
    }
    for (int index = 0; index < 3; ++index)
    {
      if ((UnityEngine.Object) this.text_Rank[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Rank[index]).enabled)
      {
        ((Behaviour) this.text_Rank[index]).enabled = false;
        ((Behaviour) this.text_Rank[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_OS[index] != (UnityEngine.Object) null && ((Behaviour) this.text_OS[index]).enabled)
      {
        ((Behaviour) this.text_OS[index]).enabled = false;
        ((Behaviour) this.text_OS[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Close[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Close[index]).enabled)
      {
        ((Behaviour) this.text_Close[index]).enabled = false;
        ((Behaviour) this.text_Close[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Challenge[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Challenge[index]).enabled)
      {
        ((Behaviour) this.text_Challenge[index]).enabled = false;
        ((Behaviour) this.text_Challenge[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Challenge_Name[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Challenge_Name[index]).enabled)
      {
        ((Behaviour) this.text_Challenge_Name[index]).enabled = false;
        ((Behaviour) this.text_Challenge_Name[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.btn_Opponent[index] != (UnityEngine.Object) null && ((Behaviour) this.btn_Opponent[index]).enabled)
        this.btn_Opponent[index].Refresh_FontTexture();
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((UnityEngine.Object) this.btn_Hero[index] != (UnityEngine.Object) null && ((Behaviour) this.btn_Hero[index]).enabled)
        this.btn_Hero[index].Refresh_FontTexture();
    }
  }

  public long CheckKOWCountTime()
  {
    long num = 0;
    if (this.AM.m_ArenaClose_CDTime != 0L && (this.AM.m_ArenaClose_ActivityType == EActivityType.EAT_KingOfTheWorld || this.AM.m_ArenaClose_ActivityType == EActivityType.EAT_FederalEvent))
      num = this.AM.m_ArenaClose_CDTime - DataManager.Instance.ServerTime;
    if (num < 0L)
      num = 0L;
    return num;
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
