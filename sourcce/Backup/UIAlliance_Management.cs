// Decompiled with JetBrains decompiler
// Type: UIAlliance_Management
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable disable
public class UIAlliance_Management : GUIWindow, IUIButtonClickHandler
{
  private Transform GameT;
  private Transform ChangeT;
  private Transform AdvancedT;
  private Transform SloganT;
  private Transform DisbandT;
  private UIButton btn_EXIT;
  private UIButton btn_Publicinfo;
  private UIButton btn_AlliancEXIT;
  private UIButton btn_Recruit;
  private UIButton btn_Abdicate;
  private UIButton btn_Disband;
  private UIButton btn_I;
  private UIButton[] btn_Change = new UIButton[8];
  private UIButton btn_SloganEXIT;
  private UIButton btn_OK;
  private UIButton btn_DisbandEXIT;
  private UIButton btn_DisbandOK;
  private UIButton btn_DisbandCancel;
  private Image tmpImg;
  private UIText text_Recruit;
  private UIText text_Slogan;
  private UIText text_Limit;
  private UIText[] text_Change = new UIText[8];
  private UIText[] text_tmpStr = new UIText[17];
  private CString Cstr_Limit;
  private CString Cstr_CDTime;
  private UIEmojiInput mInput;
  private UIText text_Input1;
  private DataManager DM;
  private GUIManager GUIM;
  private Font TTFont;
  private Door door;
  private int RankLv;
  private bool bPublicRecruit = true;
  private Color Color_R = new Color(1f, 0.4f, 0.4f, 1f);
  private Color Color_G = new Color(0.6f, 1f, 0.4f, 1f);
  private Material m_Mat;
  private Material m_FMat;
  private UISpritesArray SArray;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    if (this.DM.RoleAlliance.Id == 0U)
    {
      this.door.CloseMenu();
    }
    else
    {
      this.Cstr_Limit = StringManager.Instance.SpawnString();
      this.Cstr_CDTime = StringManager.Instance.SpawnString();
      this.m_Mat = this.door.LoadMaterial();
      this.m_FMat = this.GUIM.GetFrameMaterial();
      this.RankLv = (int) this.DM.RoleAlliance.Rank;
      this.text_tmpStr[0] = this.GameT.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[0].font = this.TTFont;
      this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(458U);
      this.btn_I = this.GameT.GetChild(0).GetChild(1).GetChild(1).GetComponent<UIButton>();
      if (this.GUIM.IsArabic)
        ((Component) this.btn_I).gameObject.AddComponent<ArabicItemTextureRot>();
      this.btn_I.m_Handler = (IUIButtonClickHandler) this;
      this.btn_I.m_BtnID1 = 14;
      this.btn_I.m_EffectType = e_EffectType.e_Scale;
      this.btn_I.transition = (Selectable.Transition) 0;
      this.text_tmpStr[1] = this.GameT.GetChild(1).GetChild(3).GetComponent<UIText>();
      this.text_tmpStr[1].font = this.TTFont;
      this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(459U);
      this.btn_Publicinfo = this.GameT.GetChild(1).GetChild(0).GetComponent<UIButton>();
      this.btn_Publicinfo.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Publicinfo.m_BtnID1 = 1;
      this.btn_Publicinfo.m_EffectType = e_EffectType.e_Scale;
      this.btn_Publicinfo.transition = (Selectable.Transition) 0;
      this.text_tmpStr[2] = this.GameT.GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
      this.text_tmpStr[2].font = this.TTFont;
      this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(460U);
      this.btn_AlliancEXIT = this.GameT.GetChild(1).GetChild(1).GetComponent<UIButton>();
      this.btn_AlliancEXIT.m_Handler = (IUIButtonClickHandler) this;
      this.btn_AlliancEXIT.m_BtnID1 = 2;
      this.btn_AlliancEXIT.m_EffectType = e_EffectType.e_Scale;
      this.btn_AlliancEXIT.transition = (Selectable.Transition) 0;
      this.text_tmpStr[3] = this.GameT.GetChild(1).GetChild(1).GetChild(1).GetComponent<UIText>();
      this.text_tmpStr[3].font = this.TTFont;
      this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(463U);
      this.btn_Recruit = this.GameT.GetChild(1).GetChild(2).GetComponent<UIButton>();
      this.btn_Recruit.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Recruit.m_BtnID1 = 3;
      this.btn_Recruit.m_EffectType = e_EffectType.e_Scale;
      this.btn_Recruit.transition = (Selectable.Transition) 0;
      this.text_Recruit = this.GameT.GetChild(1).GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
      this.text_Recruit.font = this.TTFont;
      if (this.DM.RoleAlliance.Approval == (byte) 0)
        this.CheckRecruit(true);
      else
        this.CheckRecruit(false);
      this.text_tmpStr[4] = this.GameT.GetChild(1).GetChild(2).GetChild(2).GetComponent<UIText>();
      this.text_tmpStr[4].font = this.TTFont;
      this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(532U);
      this.ChangeT = this.GameT.GetChild(2);
      this.text_tmpStr[5] = this.ChangeT.GetChild(8).GetComponent<UIText>();
      this.text_tmpStr[5].font = this.TTFont;
      this.text_tmpStr[5].text = this.DM.mStringTable.GetStringByID(464U);
      for (int index = 0; index < 8; ++index)
      {
        this.btn_Change[index] = this.ChangeT.GetChild(index).GetComponent<UIButton>();
        this.btn_Change[index].m_Handler = (IUIButtonClickHandler) this;
        this.btn_Change[index].m_BtnID1 = 4 + index;
        this.btn_Change[index].m_EffectType = e_EffectType.e_Scale;
        this.btn_Change[index].transition = (Selectable.Transition) 0;
        this.text_Change[index] = this.ChangeT.GetChild(index).GetChild(1).GetComponent<UIText>();
        this.text_Change[index].font = this.TTFont;
        this.text_Change[index].text = index != 7 ? this.DM.mStringTable.GetStringByID((uint) (ushort) (465 + index)) : this.DM.mStringTable.GetStringByID(9567U);
      }
      this.AdvancedT = this.GameT.GetChild(3);
      this.text_tmpStr[6] = this.AdvancedT.GetChild(2).GetComponent<UIText>();
      this.text_tmpStr[6].font = this.TTFont;
      this.text_tmpStr[6].text = this.DM.mStringTable.GetStringByID(473U);
      this.btn_Abdicate = this.AdvancedT.GetChild(0).GetComponent<UIButton>();
      this.btn_Abdicate.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Abdicate.m_BtnID1 = 12;
      this.btn_Abdicate.m_EffectType = e_EffectType.e_Scale;
      this.btn_Abdicate.transition = (Selectable.Transition) 0;
      this.text_tmpStr[7] = this.AdvancedT.GetChild(0).GetChild(1).GetComponent<UIText>();
      this.text_tmpStr[7].font = this.TTFont;
      this.text_tmpStr[7].text = this.DM.mStringTable.GetStringByID(474U);
      this.btn_Disband = this.AdvancedT.GetChild(1).GetComponent<UIButton>();
      this.btn_Disband.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Disband.m_BtnID1 = 13;
      this.btn_Disband.m_EffectType = e_EffectType.e_Scale;
      this.btn_Disband.transition = (Selectable.Transition) 0;
      this.text_tmpStr[8] = this.AdvancedT.GetChild(1).GetChild(1).GetComponent<UIText>();
      this.text_tmpStr[8].font = this.TTFont;
      this.text_tmpStr[8].text = this.DM.mStringTable.GetStringByID(475U);
      CString SpriteName = StringManager.Instance.StaticString1024();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_close_base");
      this.tmpImg = this.GameT.GetChild(4).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
      if (this.GUIM.bOpenOnIPhoneX)
        ((Behaviour) this.tmpImg).enabled = false;
      this.btn_EXIT = this.GameT.GetChild(4).GetChild(0).GetComponent<UIButton>();
      this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
      this.btn_EXIT.m_BtnID1 = 0;
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_close");
      this.btn_EXIT.image.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.btn_EXIT.image).material = this.m_Mat;
      this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
      this.btn_EXIT.transition = (Selectable.Transition) 0;
      this.SloganT = this.GameT.GetChild(5);
      this.tmpImg = this.SloganT.GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_black");
      this.tmpImg.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
      if (this.GUIM.bOpenOnIPhoneX)
      {
        ((Graphic) this.tmpImg).rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
        ((Graphic) this.tmpImg).rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
      }
      this.tmpImg = this.SloganT.GetChild(0).GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_box_009");
      this.tmpImg.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
      this.tmpImg = this.SloganT.GetChild(1).GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_con_title_orange");
      this.tmpImg.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
      this.tmpImg = this.SloganT.GetChild(2).GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_con_title_blue_01");
      this.tmpImg.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
      this.text_tmpStr[9] = this.SloganT.GetChild(2).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[9].font = this.TTFont;
      this.text_tmpStr[9].text = this.DM.mStringTable.GetStringByID(456U);
      this.tmpImg = this.SloganT.GetChild(3).GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_strip_05");
      this.tmpImg.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
      this.mInput = this.SloganT.GetChild(3).GetComponent<UIEmojiInput>();
      this.mInput.textComponent.font = this.TTFont;
      this.mInput.textComponent.fontSize = 24;
      this.text_Input1 = this.mInput.placeholder as UIText;
      this.text_Input1.font = this.TTFont;
      this.text_Input1.text = this.DM.mStringTable.GetStringByID(455U);
      if (this.DM.RoleAlliance.Header.Length != 0)
        this.mInput.text = this.DM.RoleAlliance.Header;
      this.mInput.shouldHideMobileInput = false;
      this.text_Slogan = this.SloganT.GetChild(3).GetChild(1).GetComponent<UIText>();
      this.text_Slogan.font = this.TTFont;
      // ISSUE: method pointer
      this.mInput.onValueChange.AddListener(new UnityAction<string>((object) this, __methodptr(\u003COnOpen\u003Em__F0)));
      this.mInput.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
      this.btn_SloganEXIT = this.SloganT.GetChild(4).GetComponent<UIButton>();
      this.btn_SloganEXIT.m_Handler = (IUIButtonClickHandler) this;
      this.btn_SloganEXIT.m_BtnID1 = 15;
      this.btn_SloganEXIT.m_EffectType = e_EffectType.e_Scale;
      this.btn_SloganEXIT.transition = (Selectable.Transition) 0;
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_close");
      this.btn_SloganEXIT.image.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.btn_SloganEXIT.image).material = this.m_Mat;
      this.btn_OK = this.SloganT.GetChild(5).GetComponent<UIButton>();
      this.btn_OK.m_Handler = (IUIButtonClickHandler) this;
      this.btn_OK.m_BtnID1 = 16;
      this.btn_OK.m_EffectType = e_EffectType.e_Scale;
      this.btn_OK.transition = (Selectable.Transition) 0;
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_but_y_01");
      this.btn_OK.image.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.btn_OK.image).material = this.m_Mat;
      this.text_tmpStr[10] = this.SloganT.GetChild(5).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[10].font = this.TTFont;
      this.text_tmpStr[10].text = this.DM.mStringTable.GetStringByID(457U);
      this.text_Limit = this.SloganT.GetChild(6).GetComponent<UIText>();
      this.text_Limit.font = this.TTFont;
      this.Cstr_Limit.ClearString();
      this.Cstr_Limit.IntToFormat(20L);
      this.Cstr_Limit.AppendFormat(this.DM.mStringTable.GetStringByID(4614U));
      this.text_Limit.text = this.Cstr_Limit.ToString();
      this.text_Limit.SetAllDirty();
      this.text_Limit.cachedTextGenerator.Invalidate();
      this.text_tmpStr[11] = this.SloganT.GetChild(7).GetComponent<UIText>();
      this.text_tmpStr[11].font = this.TTFont;
      this.text_tmpStr[11].text = this.DM.mStringTable.GetStringByID(451U);
      this.DisbandT = this.GameT.GetChild(6);
      this.tmpImg = this.DisbandT.GetComponent<Image>();
      ((Graphic) this.tmpImg).color = new Color(1f, 1f, 1f, 0.647f);
      if (this.GUIM.bOpenOnIPhoneX)
      {
        ((Graphic) this.tmpImg).rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
        ((Graphic) this.tmpImg).rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
      }
      this.tmpImg = this.DisbandT.GetChild(0).GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_box_007");
      this.tmpImg.sprite = this.GUIM.LoadFrameSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.m_FMat;
      this.tmpImg = this.DisbandT.GetChild(0).GetChild(0).GetComponent<Image>();
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_title_01");
      this.tmpImg.sprite = this.GUIM.LoadFrameSprite(SpriteName);
      ((MaskableGraphic) this.tmpImg).material = this.m_FMat;
      this.text_tmpStr[12] = this.DisbandT.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[12].font = this.TTFont;
      this.text_tmpStr[12].text = this.DM.mStringTable.GetStringByID(508U);
      this.btn_DisbandCancel = this.DisbandT.GetChild(0).GetChild(2).GetComponent<UIButton>();
      this.btn_DisbandCancel.m_Handler = (IUIButtonClickHandler) this;
      this.btn_DisbandCancel.m_BtnID1 = 19;
      this.btn_DisbandCancel.m_EffectType = e_EffectType.e_Scale;
      this.btn_DisbandCancel.transition = (Selectable.Transition) 0;
      this.text_tmpStr[13] = this.DisbandT.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[13].font = this.TTFont;
      this.text_tmpStr[13].text = this.DM.mStringTable.GetStringByID(513U);
      this.btn_DisbandOK = this.DisbandT.GetChild(0).GetChild(3).GetComponent<UIButton>();
      this.btn_DisbandOK.m_Handler = (IUIButtonClickHandler) this;
      this.btn_DisbandOK.m_BtnID1 = 18;
      this.btn_DisbandOK.m_EffectType = e_EffectType.e_Scale;
      this.btn_DisbandOK.transition = (Selectable.Transition) 0;
      ((Behaviour) this.btn_DisbandOK).enabled = false;
      this.text_tmpStr[14] = this.DisbandT.GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[14].font = this.TTFont;
      this.text_tmpStr[14].text = this.DM.mStringTable.GetStringByID(475U);
      this.text_tmpStr[15] = this.DisbandT.GetChild(0).GetChild(4).GetComponent<UIText>();
      this.text_tmpStr[15].font = this.TTFont;
      this.text_tmpStr[15].text = this.DM.mStringTable.GetStringByID(9656U);
      this.text_tmpStr[16] = this.DisbandT.GetChild(0).GetChild(5).GetComponent<UIText>();
      this.text_tmpStr[16].font = this.TTFont;
      this.btn_DisbandEXIT = this.DisbandT.GetChild(1).GetComponent<UIButton>();
      this.btn_DisbandEXIT.m_Handler = (IUIButtonClickHandler) this;
      this.btn_DisbandEXIT.m_BtnID1 = 17;
      this.btn_DisbandEXIT.m_EffectType = e_EffectType.e_Scale;
      this.btn_DisbandEXIT.transition = (Selectable.Transition) 0;
      SpriteName.ClearString();
      SpriteName.AppendFormat("UI_main_close");
      this.btn_DisbandEXIT.image.sprite = this.door.LoadSprite(SpriteName);
      ((MaskableGraphic) this.btn_DisbandEXIT.image).material = this.m_Mat;
      this.CheckRankShow(this.RankLv);
      this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    }
  }

  public override void OnClose()
  {
    if (this.Cstr_Limit != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Limit);
    if (this.Cstr_CDTime == null)
      return;
    StringManager.Instance.DeSpawnString(this.Cstr_CDTime);
  }

  public void CheckRecruit(bool bpublic)
  {
    this.bPublicRecruit = bpublic;
    if (this.bPublicRecruit)
    {
      this.text_Recruit.text = this.DM.mStringTable.GetStringByID(462U);
      ((Graphic) this.text_Recruit).color = this.Color_G;
    }
    else
    {
      this.text_Recruit.text = this.DM.mStringTable.GetStringByID(461U);
      ((Graphic) this.text_Recruit).color = this.Color_R;
    }
  }

  public void CheckRankShow(int mRank)
  {
    ((Component) this.btn_Recruit).gameObject.SetActive(false);
    this.AdvancedT.gameObject.SetActive(false);
    switch (mRank)
    {
      case 1:
      case 2:
      case 3:
        ((Component) this.btn_AlliancEXIT).gameObject.SetActive(true);
        this.ChangeT.gameObject.SetActive(false);
        this.SloganT.transform.SetParent(this.GameT, false);
        this.SloganT.transform.SetSiblingIndex(5);
        this.SloganT.gameObject.SetActive(false);
        if (!((Object) this.DisbandT != (Object) null) || !this.DisbandT.gameObject.activeSelf)
          break;
        this.SetDisbandShow(false);
        break;
      case 4:
        ((Component) this.btn_AlliancEXIT).gameObject.SetActive(true);
        this.ChangeT.gameObject.SetActive(true);
        for (int index = 0; index < 3; ++index)
          ((Component) this.btn_Change[index]).gameObject.SetActive(true);
        for (int index = 3; index < 8; ++index)
          ((Component) this.btn_Change[index]).gameObject.SetActive(false);
        if (!((Object) this.DisbandT != (Object) null) || !this.DisbandT.gameObject.activeSelf)
          break;
        this.SetDisbandShow(false);
        break;
      case 5:
        this.ChangeT.gameObject.SetActive(true);
        for (int index = 0; index < 8; ++index)
          ((Component) this.btn_Change[index]).gameObject.SetActive(true);
        ((Component) this.btn_Recruit).gameObject.SetActive(true);
        this.AdvancedT.gameObject.SetActive(true);
        ((Component) this.btn_AlliancEXIT).gameObject.SetActive(false);
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 1:
        this.DM.AllianceView.Id = this.DM.RoleAlliance.Id;
        this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo);
        break;
      case 2:
        if (MobilizationManager.Instance.mMissionID != (ushort) 0 && MobilizationManager.Instance.mMissionStatus == (byte) 0)
        {
          this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(505U), this.DM.mStringTable.GetStringByID(16091U), 8, YesText: this.DM.mStringTable.GetStringByID(3U), NoText: this.DM.mStringTable.GetStringByID(4773U));
          break;
        }
        this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(505U), this.DM.mStringTable.GetStringByID(506U), 4, YesText: this.DM.mStringTable.GetStringByID(507U), NoText: this.DM.mStringTable.GetStringByID(4773U));
        break;
      case 3:
        if (!GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage))
          break;
        MessagePacket messagePacket1 = new MessagePacket((ushort) 1024);
        messagePacket1.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_NEEDAPPLY;
        messagePacket1.AddSeqId();
        byte data1 = 0;
        if (this.bPublicRecruit)
          data1 = (byte) 1;
        messagePacket1.Add(data1);
        messagePacket1.Send();
        break;
      case 4:
        this.SloganT.transform.SetParent((Transform) this.GUIM.m_SecWindowLayer, false);
        this.SloganT.gameObject.SetActive(true);
        break;
      case 5:
        this.door.CloseMenu();
        this.GUIM.UpdateUI(EGUIWindow.UI_Alliance_Info, 2);
        break;
      case 6:
        this.DM.AllianceView.Id = this.DM.RoleAlliance.Id;
        this.DM.AllianceView.Language = this.DM.RoleAlliance.Language;
        this.DM.AllianceView.Tag = this.DM.RoleAlliance.Tag.ToString();
        this.DM.AllianceView.Name = this.DM.RoleAlliance.Name.ToString();
        this.DM.AllianceView.Notice = this.DM.RoleAlliance.Notice;
        this.DM.AllianceView.Header = this.DM.RoleAlliance.Header;
        this.DM.AllianceView.Leader = this.DM.RoleAlliance.Leader.ToString();
        this.DM.AllianceView.Power = this.DM.RoleAlliance.Power;
        this.DM.AllianceView.Emblem = this.DM.RoleAlliance.Emblem;
        this.DM.AllianceView.Member = this.DM.RoleAlliance.Member;
        this.DM.AllianceView.Approval = this.DM.RoleAlliance.Approval;
        this.DM.AllianceView.GiftLv = this.DM.RoleAlliance.GiftLv;
        this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo);
        this.GUIM.UpdateUI(EGUIWindow.UIAlliance_publicinfo, 5);
        break;
      case 7:
        this.DM.CurSelectLanguage = this.DM.RoleAlliance.Language;
        this.door.OpenMenu(EGUIWindow.UI_LanguageSelect, 1);
        break;
      case 8:
        this.GUIM.UseOrSpend((ushort) 1007, this.DM.mStringTable.GetStringByID(4957U), (ushort) 0, (ushort) 0, (ushort) 0, maxcount: (ushort) 0);
        break;
      case 9:
        this.GUIM.UseOrSpend((ushort) 1120, this.DM.mStringTable.GetStringByID(4957U), (ushort) 0, (ushort) 0, (ushort) 0, maxcount: (ushort) 0);
        break;
      case 10:
        this.DM.CurSelectBadge = this.DM.RoleAlliance.Emblem;
        this.door.OpenMenu(EGUIWindow.UIAlliance_Badge, 100);
        break;
      case 11:
        if (ActivityManager.Instance.IsInKvK((ushort) 0))
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9571U), (ushort) byte.MaxValue);
          break;
        }
        CString cstring = StringManager.Instance.StaticString1024();
        cstring.ClearString();
        if ((int) this.DM.RoleAlliance.KingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID)
        {
          cstring.IntToFormat((long) this.DM.RoleAlliance.KingdomID);
          cstring.IntToFormat((long) DataManager.MapDataController.kingdomData.kingdomID);
          cstring.AppendFormat(this.DM.mStringTable.GetStringByID(9569U));
          GUIManager.Instance.OpenSpendWindow_Normal((GUIWindow) this, this.DM.mStringTable.GetStringByID(9567U), cstring.ToString(), 1000, 6, Buttontext: this.DM.mStringTable.GetStringByID(9146U));
          break;
        }
        cstring.IntToFormat((long) DataManager.MapDataController.kingdomData.kingdomID);
        cstring.AppendFormat(this.DM.mStringTable.GetStringByID(9570U));
        GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(9567U), cstring.ToString(), this.DM.mStringTable.GetStringByID(3U));
        break;
      case 12:
        if (DataManager.MapDataController.IsKing())
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9366U), (ushort) byte.MaxValue);
          break;
        }
        if (this.CheckWonderID())
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9369U), (ushort) byte.MaxValue);
          break;
        }
        this.door.OpenMenu(EGUIWindow.UI_Alliance_List, 2);
        break;
      case 13:
        if (DataManager.MapDataController.IsKing())
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9366U), (ushort) byte.MaxValue);
          break;
        }
        if (this.CheckWonderID())
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9369U), (ushort) byte.MaxValue);
          break;
        }
        this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(520U), this.DM.mStringTable.GetStringByID(521U), 1, YesText: this.DM.mStringTable.GetStringByID(522U), NoText: this.DM.mStringTable.GetStringByID(4773U));
        break;
      case 14:
        this.door.OpenMenu(EGUIWindow.UI_Alliance_Permission);
        break;
      case 15:
        this.SloganT.transform.SetParent(this.GameT, false);
        this.SloganT.transform.SetSiblingIndex(5);
        this.SloganT.gameObject.SetActive(false);
        break;
      case 16:
        if (GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage) && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
        {
          char[] charArray = this.text_Slogan.text.ToCharArray();
          if (this.DM.m_BannedWord != null)
            this.DM.m_BannedWord.CheckBannedWord(charArray);
          byte[] bytes = Encoding.UTF8.GetBytes(charArray, 0, this.text_Slogan.text.Length);
          MessagePacket messagePacket2 = new MessagePacket((ushort) 1024);
          messagePacket2.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_SLOGAN;
          messagePacket2.AddSeqId();
          messagePacket2.Add((byte) bytes.Length);
          messagePacket2.Add(bytes, len: 20);
          messagePacket2.Send();
          break;
        }
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
        break;
      case 17:
      case 19:
        this.SetDisbandShow(false);
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9649U), (ushort) byte.MaxValue);
        break;
      case 18:
        if (!((Object) this.btn_DisbandOK.image.sprite == (Object) this.SArray.m_Sprites[0]) || this.DM.mAllianceDisband != (byte) 0)
          break;
        byte data2 = 2;
        if (!GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage))
          break;
        MessagePacket messagePacket3 = new MessagePacket((ushort) 1024);
        messagePacket3.Protocol = Protocol._MSG_REQUEST_ALLIANCE_QUIT;
        messagePacket3.AddSeqId();
        messagePacket3.Add(data2);
        messagePacket3.Send();
        break;
    }
  }

  public bool CheckWonderID()
  {
    bool flag = false;
    for (int index = 0; index < this.DM.m_Wonders.Count; ++index)
    {
      if (this.DM.m_Wonders[index].WonderID == (byte) 0)
      {
        flag = true;
        break;
      }
    }
    return flag;
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 1:
        this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(523U), this.DM.mStringTable.GetStringByID(527U), 2);
        break;
      case 2:
        this.SetDisbandShow();
        break;
      case 3:
        byte data = 1;
        if (!GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage))
          break;
        MessagePacket messagePacket1 = new MessagePacket((ushort) 1024);
        messagePacket1.Protocol = Protocol._MSG_REQUEST_ALLIANCE_QUIT;
        messagePacket1.AddSeqId();
        messagePacket1.Add(data);
        messagePacket1.Send();
        break;
      case 4:
        this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(508U), this.DM.mStringTable.GetStringByID(509U), 3);
        break;
      case 6:
        if (this.DM.RoleAttr.Diamond >= 1000U)
        {
          GUIManager.Instance.ShowUILock(EUILock.AllianceChangHomeKingdom);
          MessagePacket messagePacket2 = new MessagePacket((ushort) 1024);
          messagePacket2.Protocol = Protocol._MSG_REQUEST_ALLIANCE_CHANGE_HOMEKINGDOM;
          messagePacket2.AddSeqId();
          messagePacket2.Send();
          break;
        }
        this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966U), this.DM.mStringTable.GetStringByID(646U), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 7, bCloseIDSet: true);
        break;
      case 7:
        MallManager.Instance.Send_Mall_Info();
        break;
      case 8:
        this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(505U), this.DM.mStringTable.GetStringByID(506U), 4, YesText: this.DM.mStringTable.GetStringByID(507U), NoText: this.DM.mStringTable.GetStringByID(4773U));
        break;
    }
  }

  public void SetDisbandShow(bool bshow = true)
  {
    if (bshow)
    {
      this.DM.mAllianceDisband = (byte) 60;
      this.Cstr_CDTime.ClearString();
      this.Cstr_CDTime.IntToFormat(1L, 2, true);
      this.Cstr_CDTime.IntToFormat(0L, 2, true);
      this.Cstr_CDTime.AppendFormat(this.DM.mStringTable.GetStringByID(9650U));
      this.text_tmpStr[16].text = this.Cstr_CDTime.ToString();
      this.text_tmpStr[16].SetAllDirty();
      this.text_tmpStr[16].cachedTextGenerator.Invalidate();
      this.btn_DisbandOK.image.sprite = this.SArray.m_Sprites[1];
      this.DisbandT.transform.SetParent((Transform) this.GUIM.m_SecWindowLayer, false);
      this.DisbandT.gameObject.SetActive(true);
      this.GUIM.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    }
    else
    {
      this.DisbandT.transform.SetParent(this.GameT, false);
      this.DisbandT.transform.SetSiblingIndex(6);
      this.DisbandT.gameObject.SetActive(false);
      this.GUIM.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        if (this.DM.RoleAlliance.Id == 0U)
        {
          if ((Object) this.SloganT != (Object) null && this.SloganT.gameObject.activeSelf)
          {
            this.SloganT.transform.SetParent(this.GameT, false);
            this.SloganT.transform.SetSiblingIndex(5);
            this.SloganT.gameObject.SetActive(false);
          }
          if ((Object) this.DisbandT != (Object) null && this.DisbandT.gameObject.activeSelf)
            this.SetDisbandShow(false);
          this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_Management);
          break;
        }
        this.CheckRankShow(this.RankLv);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Alliance)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.Refresh_FontTexture();
          break;
        }
        if (this.DM.RoleAlliance.Id == 0U)
        {
          if ((Object) this.SloganT != (Object) null && this.SloganT.gameObject.activeSelf)
          {
            this.SloganT.transform.SetParent(this.GameT, false);
            this.SloganT.transform.SetSiblingIndex(5);
            this.SloganT.gameObject.SetActive(false);
          }
          if ((Object) this.DisbandT != (Object) null && this.DisbandT.gameObject.activeSelf)
            this.SetDisbandShow(false);
          this.door.CloseMenu_Alliance(EGUIWindow.UI_Alliance_Management);
          break;
        }
        this.CheckRankShow((int) this.DM.RoleAlliance.Rank);
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Recruit != (Object) null && ((Behaviour) this.text_Recruit).enabled)
    {
      ((Behaviour) this.text_Recruit).enabled = false;
      ((Behaviour) this.text_Recruit).enabled = true;
    }
    if ((Object) this.text_Slogan != (Object) null && ((Behaviour) this.text_Slogan).enabled)
    {
      ((Behaviour) this.text_Slogan).enabled = false;
      ((Behaviour) this.text_Slogan).enabled = true;
    }
    if ((Object) this.text_Limit != (Object) null && ((Behaviour) this.text_Limit).enabled)
    {
      ((Behaviour) this.text_Limit).enabled = false;
      ((Behaviour) this.text_Limit).enabled = true;
    }
    if ((Object) this.text_Input1 != (Object) null && ((Behaviour) this.text_Input1).enabled)
    {
      ((Behaviour) this.text_Input1).enabled = false;
      ((Behaviour) this.text_Input1).enabled = true;
    }
    if ((Object) this.mInput != (Object) null && ((Behaviour) this.mInput.textComponent).enabled)
    {
      ((Behaviour) this.mInput.textComponent).enabled = false;
      ((Behaviour) this.mInput.textComponent).enabled = true;
    }
    for (int index = 0; index < 8; ++index)
    {
      if ((Object) this.text_Change[index] != (Object) null && ((Behaviour) this.text_Change[index]).enabled)
      {
        ((Behaviour) this.text_Change[index]).enabled = false;
        ((Behaviour) this.text_Change[index]).enabled = true;
      }
    }
    for (int index = 0; index < 17; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.CheckRankShow(this.RankLv);
        break;
      case 2:
        bool bpublic = false;
        if (this.DM.RoleAlliance.Approval == (byte) 0)
          bpublic = true;
        this.CheckRecruit(bpublic);
        break;
      case 3:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 4:
        this.SloganT.transform.SetParent(this.GameT, false);
        this.SloganT.transform.SetSiblingIndex(5);
        this.SloganT.gameObject.SetActive(false);
        break;
    }
  }

  public void ChangText(string ID)
  {
    int byteCount = Encoding.UTF8.GetByteCount(ID);
    this.Cstr_Limit.ClearString();
    this.Cstr_Limit.IntToFormat((long) (20 - byteCount));
    this.Cstr_Limit.AppendFormat(this.DM.mStringTable.GetStringByID(4614U));
    this.text_Limit.text = this.Cstr_Limit.ToString();
    this.text_Limit.SetAllDirty();
    this.text_Limit.cachedTextGenerator.Invalidate();
  }

  protected char OnValidateInput(string text, int index, char check)
  {
    return check >= ' ' && check <= '~' ? check : char.MinValue;
  }

  public override bool OnBackButtonClick()
  {
    if (this.SloganT.gameObject.activeSelf)
    {
      this.SloganT.transform.SetParent(this.GameT, false);
      this.SloganT.transform.SetSiblingIndex(5);
      this.SloganT.gameObject.SetActive(false);
      return false;
    }
    if (!((Object) this.DisbandT != (Object) null) || !this.DisbandT.gameObject.activeSelf)
      return false;
    this.SetDisbandShow(false);
    this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9649U), (ushort) byte.MaxValue);
    return true;
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!bOnSecond || !((Object) this.DisbandT != (Object) null) || !this.DisbandT.gameObject.activeSelf)
      return;
    if (this.DM.mAllianceDisband > (byte) 0)
      --this.DM.mAllianceDisband;
    if (this.DM.mAllianceDisband == (byte) 0 && (Object) this.btn_DisbandOK.image.sprite != (Object) this.SArray.m_Sprites[0])
    {
      ((Behaviour) this.btn_DisbandOK).enabled = true;
      this.btn_DisbandOK.image.sprite = this.SArray.m_Sprites[0];
    }
    this.Cstr_CDTime.ClearString();
    this.Cstr_CDTime.IntToFormat(0L, 2, true);
    this.Cstr_CDTime.IntToFormat((long) this.DM.mAllianceDisband, 2, true);
    this.Cstr_CDTime.AppendFormat(this.DM.mStringTable.GetStringByID(9650U));
    this.text_tmpStr[16].text = this.Cstr_CDTime.ToString();
    this.text_tmpStr[16].SetAllDirty();
    this.text_tmpStr[16].cachedTextGenerator.Invalidate();
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
