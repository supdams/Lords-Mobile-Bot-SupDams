// Decompiled with JetBrains decompiler
// Type: UIAlliance_publicinfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UIAlliance_publicinfo : GUIWindow, IUIButtonClickHandler, IUIButtonDownUpHandler
{
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Tmp2;
  private Transform BadgeT;
  private RectTransform TranslationRT;
  private UIButton btn_EXIT;
  private UIButton btn_Msg;
  private UIButton btn_Member;
  private UIButton btn_Data;
  private UIButton btn_Letter;
  private UIButton btn_Join;
  private UIButton btn_InputField;
  private UIButton btn_InputField2;
  private UIButton btn_Input_OK;
  private UIButton btn_Input_C;
  private UIButton btn_Input_Edit;
  private UIButton btn_KHint;
  private UIButton btn_Translation;
  private UIRunningText img_text;
  private Image tmpImg;
  private Image Img_Join;
  private Image img_InputBG;
  private Image img_KHint;
  private Image Img_Translate;
  private UIText text_Alliance_K;
  private UIText text_AllianceChief;
  private UIText text_AllianceStrength;
  private UIText text_AllianceMember;
  private UIText text_AllianceLanguage;
  private UIText[] text_Propaganda = new UIText[2];
  private UIText text_Gife;
  private UIText text_join;
  private UIText text_join_btn;
  private UIText text_AllianceName;
  private UIText text_InputCheck;
  private UIText text_Input1;
  private UIText[] text_tmpStr = new UIText[10];
  private UIText text_Trans;
  private UIText text_Translation;
  private UIEmojiInput mInput;
  private CString Cstr_Alliance_K;
  private CString Cstr_AllianceName;
  private CString Cstr_AllianceChief;
  private CString Cstr_AllianceStrength;
  private CString Cstr_AllianceMember;
  private CString Cstr_GifeLV;
  private CString Cstr_AllianceLanguage;
  private CString Cstr_Null;
  private CString Cstr_Translation;
  private StringBuilder tmpString = new StringBuilder();
  private DataManager DM;
  private GUIManager GUIM;
  private UISpritesArray SArray;
  private Font TTFont;
  private Door door;
  private bool bNeedApplication = true;
  private byte mState;
  private Color Color_Red = new Color(1f, 0.639f, 0.6039f, 1f);
  private Color Color_Green = new Color(0.6f, 1f, 0.4f, 1f);
  private bool bOpen = true;
  private int mType;
  private bool bShowTranslate;

  public override void OnOpen(int arg1, int arg2)
  {
    this.mType = arg1;
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    if (this.DM.RoleAlliance.Id == 0U && this.mType != 5)
    {
      this.door.CloseMenu();
    }
    else
    {
      this.Cstr_Alliance_K = StringManager.Instance.SpawnString();
      this.Cstr_AllianceName = StringManager.Instance.SpawnString();
      this.Cstr_AllianceChief = StringManager.Instance.SpawnString();
      this.Cstr_AllianceStrength = StringManager.Instance.SpawnString();
      this.Cstr_AllianceMember = StringManager.Instance.SpawnString();
      this.Cstr_GifeLV = StringManager.Instance.SpawnString();
      this.Cstr_AllianceLanguage = StringManager.Instance.SpawnString();
      this.Cstr_Null = StringManager.Instance.SpawnString();
      this.Cstr_Translation = StringManager.Instance.SpawnString(50);
      this.tmpImg = this.GameT.GetChild(0).GetComponent<Image>();
      this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
      ((MaskableGraphic) this.tmpImg).material = this.door.LoadMaterial();
      if (this.GUIM.bOpenOnIPhoneX)
        ((Behaviour) this.tmpImg).enabled = false;
      this.btn_EXIT = this.GameT.GetChild(0).GetChild(0).GetComponent<UIButton>();
      this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
      this.btn_EXIT.m_BtnID1 = 0;
      this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
      ((MaskableGraphic) this.btn_EXIT.image).material = this.door.LoadMaterial();
      this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
      this.btn_EXIT.transition = (Selectable.Transition) 0;
      this.Tmp = this.GameT.GetChild(1);
      this.Tmp1 = this.Tmp.GetChild(2);
      this.Tmp2 = this.Tmp1.GetChild(0);
      this.text_tmpStr[0] = this.Tmp2.GetComponent<UIText>();
      this.text_tmpStr[0].font = this.TTFont;
      this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(4641U);
      this.Tmp1 = this.Tmp.GetChild(3);
      this.Tmp2 = this.Tmp1.GetChild(0);
      this.text_AllianceChief = this.Tmp2.GetComponent<UIText>();
      this.text_AllianceChief.font = this.TTFont;
      this.Cstr_AllianceChief.ClearString();
      this.Cstr_AllianceChief.StringToFormat(this.DM.AllianceView.Leader);
      this.Cstr_AllianceChief.AppendFormat(this.DM.mStringTable.GetStringByID(4625U));
      this.text_AllianceChief.text = this.Cstr_AllianceChief.ToString();
      ((Component) this.text_AllianceChief).gameObject.SetActive(false);
      this.Tmp1 = this.Tmp.GetChild(4);
      this.Tmp2 = this.Tmp1.GetChild(0);
      this.text_AllianceStrength = this.Tmp2.GetComponent<UIText>();
      this.text_AllianceStrength.font = this.TTFont;
      this.Cstr_AllianceStrength.ClearString();
      this.Cstr_AllianceStrength.uLongToFormat(this.DM.AllianceView.Power, bNumber: true);
      this.Cstr_AllianceStrength.AppendFormat(this.DM.mStringTable.GetStringByID(4626U));
      this.text_AllianceStrength.text = this.Cstr_AllianceStrength.ToString();
      ((Component) this.text_AllianceStrength).gameObject.SetActive(false);
      this.Tmp1 = this.Tmp.GetChild(5);
      this.Tmp2 = this.Tmp1.GetChild(0);
      this.text_AllianceMember = this.Tmp2.GetComponent<UIText>();
      this.text_AllianceMember.font = this.TTFont;
      this.Cstr_AllianceMember.ClearString();
      this.Cstr_AllianceMember.IntToFormat((long) this.DM.AllianceView.Member);
      this.Cstr_AllianceMember.AppendFormat(this.DM.mStringTable.GetStringByID(4627U));
      this.text_AllianceMember.text = this.Cstr_AllianceMember.ToString();
      ((Component) this.text_AllianceMember).gameObject.SetActive(false);
      this.Tmp1 = this.Tmp.GetChild(6);
      this.Tmp2 = this.Tmp1.GetChild(0);
      this.text_AllianceLanguage = this.Tmp2.GetComponent<UIText>();
      this.text_AllianceLanguage.font = this.TTFont;
      this.Cstr_AllianceLanguage.ClearString();
      this.Cstr_AllianceLanguage.StringToFormat(this.DM.GetLanguageStr(this.DM.AllianceView.Language));
      this.Cstr_AllianceLanguage.AppendFormat(this.DM.mStringTable.GetStringByID(4642U));
      this.text_AllianceLanguage.text = this.Cstr_AllianceLanguage.ToString();
      ((Component) this.text_AllianceLanguage).gameObject.SetActive(false);
      this.Tmp1 = this.Tmp.GetChild(7);
      this.Tmp2 = this.Tmp1.GetChild(0);
      this.text_Propaganda[0] = this.Tmp2.GetComponent<UIText>();
      this.text_Propaganda[0].font = this.TTFont;
      RectTransform component1 = this.Tmp2.GetComponent<RectTransform>();
      this.tmpString.Length = 0;
      this.tmpString.Append(this.DM.AllianceView.Header);
      this.text_Propaganda[0].text = this.tmpString.ToString();
      ((Component) this.text_Propaganda[0]).gameObject.SetActive(false);
      this.Tmp2 = this.Tmp1.GetChild(1);
      this.text_Propaganda[1] = this.Tmp2.GetComponent<UIText>();
      this.text_Propaganda[1].font = this.TTFont;
      this.text_Propaganda[1].text = this.tmpString.ToString();
      ((Component) this.text_Propaganda[1]).gameObject.SetActive(false);
      RectTransform component2 = this.Tmp2.GetComponent<RectTransform>();
      this.img_text = this.Tmp1.GetComponent<UIRunningText>();
      this.img_text.tmpLength = !this.GUIM.IsArabic ? 281f : 562f;
      this.img_text.m_RunningText1 = this.text_Propaganda[0];
      this.img_text.m_RunRT1 = ((Graphic) this.text_Propaganda[0]).rectTransform;
      this.img_text.m_RunningText2 = this.text_Propaganda[1];
      this.img_text.m_RunRT2 = ((Graphic) this.text_Propaganda[1]).rectTransform;
      if ((double) this.text_Propaganda[0].preferredWidth > 281.0)
      {
        component1.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth, component1.sizeDelta.y);
        if (this.GUIM.IsArabic)
          this.text_Propaganda[0].UpdateArabicPos();
        component2.anchoredPosition = new Vector2(this.text_Propaganda[0].preferredWidth, component2.anchoredPosition.y);
        component2.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth, component2.sizeDelta.y);
        if (this.GUIM.IsArabic)
          this.text_Propaganda[1].UpdateArabicPos();
        this.img_text.tmpLength = this.text_Propaganda[0].preferredWidth;
      }
      if ((int) this.DM.AllianceView.Id != (int) this.DM.RoleAlliance.Id)
      {
        if (this.DM.AllianceView.Header == null || this.DM.AllianceView.Header.Length == 0)
          this.img_text.gameObject.SetActive(false);
        else
          this.img_text.gameObject.SetActive(true);
      }
      else if (this.DM.RoleAlliance.Header == null || this.DM.RoleAlliance.Header.Length == 0)
        this.img_text.gameObject.SetActive(false);
      else
        this.img_text.gameObject.SetActive(true);
      this.BadgeT = this.Tmp.GetChild(9);
      this.Tmp1 = this.Tmp.GetChild(10);
      this.Tmp2 = this.Tmp1.GetChild(0);
      this.text_Gife = this.Tmp2.GetComponent<UIText>();
      this.text_Gife.font = this.TTFont;
      this.Cstr_GifeLV.ClearString();
      this.Cstr_GifeLV.IntToFormat((long) this.DM.AllianceView.GiftLv);
      this.Cstr_GifeLV.AppendFormat(this.DM.mStringTable.GetStringByID(4631U));
      this.text_Gife.text = this.Cstr_GifeLV.ToString();
      ((Component) this.text_Gife).gameObject.SetActive(false);
      this.Tmp1 = this.Tmp.GetChild(11);
      this.Img_Join = this.Tmp1.GetComponent<Image>();
      this.Tmp2 = this.Tmp1.GetChild(0);
      this.text_join = this.Tmp2.GetComponent<UIText>();
      this.text_join.font = this.TTFont;
      ((Component) this.text_join).gameObject.SetActive(false);
      this.Tmp1 = this.Tmp.GetChild(12);
      this.Tmp2 = this.Tmp1.GetChild(0);
      this.mInput = this.Tmp2.GetComponent<UIEmojiInput>();
      this.mInput.textComponent.font = this.TTFont;
      this.text_Input1 = this.mInput.placeholder as UIText;
      this.text_Input1.font = this.TTFont;
      // ISSUE: method pointer
      this.mInput.onEndEdit.AddListener(new UnityAction<string>((object) this, __methodptr(\u003COnOpen\u003Em__F1)));
      this.mInput.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
      ((Component) this.mInput.textComponent).gameObject.AddComponent<UITextBoundCheck>();
      if (this.DM.AllianceView.Notice != null && this.DM.AllianceView.Notice.Length != 0 && (int) this.DM.AllianceView.Id == (int) this.DM.RoleAlliance.Id)
        this.mInput.text = this.DM.AllianceView.Notice;
      if ((int) this.DM.AllianceView.Id == (int) this.DM.RoleAlliance.Id && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
        this.text_Input1.text = this.DM.mStringTable.GetStringByID(773U);
      this.text_Trans = this.Tmp.GetChild(12).GetChild(1).GetComponent<UIText>();
      this.text_Trans.font = this.TTFont;
      this.text_Trans.text = this.mInput.text;
      this.text_Trans.SetCheckArabic(true);
      ((Component) this.text_Trans).gameObject.AddComponent<UITextBoundCheck>();
      this.btn_InputField = this.Tmp.GetChild(13).GetComponent<UIButton>();
      this.btn_InputField.m_Handler = (IUIButtonClickHandler) this;
      this.btn_InputField.m_BtnID1 = 6;
      this.btn_InputField2 = this.Tmp.GetChild(14).GetComponent<UIButton>();
      this.btn_InputField2.m_Handler = (IUIButtonClickHandler) this;
      this.btn_InputField2.m_BtnID1 = 6;
      if ((int) this.DM.AllianceView.Id != (int) this.DM.RoleAlliance.Id || this.DM.RoleAlliance.Rank < AllianceRank.RANK4)
      {
        this.mInput.interactable = false;
        ((Component) this.btn_InputField).gameObject.SetActive(false);
        ((Component) this.btn_InputField2).gameObject.SetActive(false);
      }
      this.Tmp1 = this.Tmp.GetChild(15);
      this.btn_KHint = this.Tmp1.GetComponent<UIButton>();
      this.btn_KHint.m_Handler = (IUIButtonClickHandler) this;
      this.btn_KHint.m_BtnID1 = 10;
      UIButtonHint uiButtonHint = ((Component) this.btn_KHint).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint.m_Handler = (MonoBehaviour) this;
      this.img_KHint = this.Tmp.GetChild(18).GetComponent<Image>();
      uiButtonHint.ControlFadeOut = ((Component) this.img_KHint).gameObject;
      this.text_tmpStr[8] = this.Tmp.GetChild(18).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[8].font = this.TTFont;
      this.text_tmpStr[8].text = this.DM.mStringTable.GetStringByID(9549U);
      this.text_tmpStr[8].cachedTextGeneratorForLayout.Invalidate();
      ((Graphic) this.text_tmpStr[8]).rectTransform.sizeDelta = new Vector2(this.text_tmpStr[8].preferredWidth, ((Graphic) this.text_tmpStr[8]).rectTransform.sizeDelta.y);
      if (this.GUIM.IsArabic)
        this.text_tmpStr[8].UpdateArabicPos();
      this.text_tmpStr[9] = this.Tmp.GetChild(18).GetChild(1).GetComponent<UIText>();
      this.text_tmpStr[9].font = this.TTFont;
      this.text_tmpStr[9].text = this.DM.mStringTable.GetStringByID(9550U);
      this.text_tmpStr[9].cachedTextGeneratorForLayout.Invalidate();
      if ((double) this.text_tmpStr[9].preferredWidth > (double) ((Graphic) this.text_tmpStr[9]).rectTransform.sizeDelta.x)
      {
        ((Graphic) this.img_KHint).rectTransform.sizeDelta = new Vector2(this.text_tmpStr[9].preferredWidth + 12f, ((Graphic) this.img_KHint).rectTransform.sizeDelta.y);
        ((Graphic) this.text_tmpStr[9]).rectTransform.sizeDelta = new Vector2(this.text_tmpStr[9].preferredWidth, ((Graphic) this.text_tmpStr[9]).rectTransform.sizeDelta.y);
        if (this.GUIM.IsArabic)
          this.text_tmpStr[9].UpdateArabicPos();
      }
      this.Tmp1 = this.Tmp.GetChild(19);
      this.TranslationRT = this.Tmp1.GetComponent<RectTransform>();
      this.btn_Translation = this.Tmp1.GetChild(0).GetComponent<UIButton>();
      this.btn_Translation.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Translation.m_BtnID1 = 11;
      this.Img_Translate = this.Tmp1.GetChild(1).GetComponent<Image>();
      this.text_Translation = this.Tmp1.GetChild(2).GetComponent<UIText>();
      this.text_Translation.font = this.TTFont;
      this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052U);
      if ((double) this.text_Translation.preferredWidth > (double) ((Graphic) this.text_Translation).rectTransform.sizeDelta.x)
        ((Graphic) this.text_Translation).rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, ((Graphic) this.text_Translation).rectTransform.sizeDelta.y);
      if (this.GUIM.IsArabic)
        this.text_Translation.UpdateArabicPos();
      this.text_Trans.resizeTextForBestFit = false;
      this.text_Trans.cachedTextGeneratorForLayout.Invalidate();
      ((Component) this.text_Trans).gameObject.SetActive(false);
      this.TranslationRT.anchoredPosition = new Vector2(this.TranslationRT.anchoredPosition.x, -237.5f - this.text_Trans.preferredHeight);
      ((Component) this.TranslationRT).gameObject.SetActive(false);
      this.Tmp1 = this.Tmp.GetChild(16);
      this.text_AllianceName = this.Tmp1.GetComponent<UIText>();
      this.text_AllianceName.font = this.TTFont;
      this.Cstr_AllianceName.ClearString();
      CString Name = StringManager.Instance.StaticString1024();
      Name.ClearString();
      CString Tag = StringManager.Instance.StaticString1024();
      Tag.ClearString();
      Name.Append(this.DM.AllianceView.Name);
      Tag.Append(this.DM.AllianceView.Tag);
      GameConstants.FormatRoleName(this.Cstr_AllianceName, Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
      this.text_AllianceName.text = this.Cstr_AllianceName.ToString();
      ((Component) this.text_AllianceName).gameObject.SetActive(false);
      this.Tmp1 = this.Tmp.GetChild(17);
      this.text_Alliance_K = this.Tmp1.GetComponent<UIText>();
      this.text_Alliance_K.font = this.TTFont;
      this.Cstr_Alliance_K.ClearString();
      this.Cstr_Alliance_K.IntToFormat((long) this.DM.AllianceView.KingdomID);
      if (this.GUIM.IsArabic)
        this.Cstr_Alliance_K.AppendFormat("{0}#");
      else
        this.Cstr_Alliance_K.AppendFormat("#{0}");
      this.text_Alliance_K.text = this.Cstr_Alliance_K.ToString();
      ((Component) this.text_Alliance_K).gameObject.SetActive(false);
      this.Tmp = this.GameT.GetChild(2);
      this.btn_Msg = this.Tmp.GetComponent<UIButton>();
      this.btn_Msg.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Msg.m_BtnID1 = 1;
      this.btn_Msg.m_EffectType = e_EffectType.e_Scale;
      this.btn_Msg.transition = (Selectable.Transition) 0;
      this.Tmp1 = this.Tmp.GetChild(1);
      this.text_tmpStr[1] = this.Tmp1.GetComponent<UIText>();
      this.text_tmpStr[1].font = this.TTFont;
      this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(4637U);
      this.Tmp = this.GameT.GetChild(3);
      this.btn_Member = this.Tmp.GetComponent<UIButton>();
      this.btn_Member.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Member.m_BtnID1 = 2;
      this.btn_Member.m_EffectType = e_EffectType.e_Scale;
      this.btn_Member.transition = (Selectable.Transition) 0;
      this.Tmp1 = this.Tmp.GetChild(1);
      this.text_tmpStr[2] = this.Tmp1.GetComponent<UIText>();
      this.text_tmpStr[2].font = this.TTFont;
      this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(4629U);
      this.Tmp = this.GameT.GetChild(4);
      this.btn_Data = this.Tmp.GetComponent<UIButton>();
      this.btn_Data.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Data.m_BtnID1 = 3;
      this.btn_Data.m_EffectType = e_EffectType.e_Scale;
      this.btn_Data.transition = (Selectable.Transition) 0;
      this.Tmp1 = this.Tmp.GetChild(1);
      this.text_tmpStr[3] = this.Tmp1.GetComponent<UIText>();
      this.text_tmpStr[3].font = this.TTFont;
      this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(4639U);
      this.Tmp = this.GameT.GetChild(5);
      this.btn_Letter = this.Tmp.GetComponent<UIButton>();
      this.btn_Letter.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Letter.m_BtnID1 = 4;
      this.btn_Letter.m_EffectType = e_EffectType.e_Scale;
      this.btn_Letter.transition = (Selectable.Transition) 0;
      this.Tmp1 = this.Tmp.GetChild(1);
      this.text_tmpStr[4] = this.Tmp1.GetComponent<UIText>();
      this.text_tmpStr[4].font = this.TTFont;
      this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(4645U);
      this.Tmp = this.GameT.GetChild(6);
      this.btn_Join = this.Tmp.GetComponent<UIButton>();
      this.btn_Join.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Join.m_BtnID1 = 5;
      this.btn_Join.m_EffectType = e_EffectType.e_Scale;
      this.btn_Join.transition = (Selectable.Transition) 0;
      this.Tmp1 = this.Tmp.GetChild(1);
      this.text_join_btn = this.Tmp1.GetComponent<UIText>();
      this.text_join_btn.font = this.TTFont;
      if (this.DM.RoleAlliance.Id != 0U)
        ((Component) this.btn_Join).gameObject.SetActive(false);
      this.Tmp = this.GameT.GetChild(7);
      this.img_InputBG = this.Tmp.GetComponent<Image>();
      if (this.GUIM.bOpenOnIPhoneX)
      {
        ((Graphic) this.img_InputBG).rectTransform.offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
        ((Graphic) this.img_InputBG).rectTransform.offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
      }
      this.btn_Input_Edit = this.Tmp.GetChild(0).GetComponent<UIButton>();
      this.btn_Input_Edit.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Input_Edit.m_BtnID1 = 9;
      this.btn_Input_Edit.m_EffectType = e_EffectType.e_Scale;
      this.btn_Input_Edit.transition = (Selectable.Transition) 0;
      this.text_InputCheck = this.Tmp.GetChild(0).GetChild(0).GetComponent<UIText>();
      this.text_InputCheck.font = this.TTFont;
      this.text_InputCheck.SetCheckArabic(true);
      this.btn_Input_OK = this.Tmp.GetChild(2).GetComponent<UIButton>();
      this.btn_Input_OK.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Input_OK.m_BtnID1 = 7;
      this.btn_Input_OK.m_EffectType = e_EffectType.e_Scale;
      this.btn_Input_OK.transition = (Selectable.Transition) 0;
      this.text_tmpStr[5] = this.Tmp.GetChild(2).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[5].font = this.TTFont;
      this.text_tmpStr[5].text = this.DM.mStringTable.GetStringByID(512U);
      this.btn_Input_C = this.Tmp.GetChild(3).GetComponent<UIButton>();
      this.btn_Input_C.m_Handler = (IUIButtonClickHandler) this;
      this.btn_Input_C.m_BtnID1 = 8;
      this.btn_Input_C.m_EffectType = e_EffectType.e_Scale;
      this.btn_Input_C.transition = (Selectable.Transition) 0;
      this.text_tmpStr[6] = this.Tmp.GetChild(3).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[6].font = this.TTFont;
      this.text_tmpStr[6].text = this.DM.mStringTable.GetStringByID(513U);
      this.text_tmpStr[7] = this.Tmp.GetChild(4).GetChild(0).GetComponent<UIText>();
      this.text_tmpStr[7].font = this.TTFont;
      this.text_tmpStr[7].text = this.DM.mStringTable.GetStringByID(774U);
      if (this.mState == (byte) 0)
        this.text_join_btn.text = this.DM.mStringTable.GetStringByID(4646U);
      else if (this.mState == (byte) 1)
        this.text_join_btn.text = this.DM.mStringTable.GetStringByID(4647U);
      else if (this.mState == (byte) 2)
        this.text_join_btn.text = this.DM.mStringTable.GetStringByID(4648U);
      else
        ((Component) this.btn_Letter).gameObject.SetActive(false);
      this.bNeedApplication = this.DM.AllianceView.Approval != (byte) 0;
      if (this.bNeedApplication)
      {
        this.text_join.text = this.DM.mStringTable.GetStringByID(4643U);
        ((Graphic) this.text_join).color = this.Color_Red;
        this.Img_Join.sprite = this.SArray.m_Sprites[0];
        this.btn_Join.image.sprite = this.SArray.m_Sprites[3];
      }
      else
      {
        this.text_join.text = this.DM.mStringTable.GetStringByID(4644U);
        ((Graphic) this.text_join).color = this.Color_Green;
        this.Img_Join.sprite = this.SArray.m_Sprites[1];
        this.btn_Join.image.sprite = this.SArray.m_Sprites[2];
      }
      this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    }
  }

  public void ChangText(string ID)
  {
    this.text_InputCheck.text = ID;
    this.text_InputCheck.SetAllDirty();
    this.text_InputCheck.cachedTextGenerator.Invalidate();
    this.mInput.text = StringManager.InputTemp;
    this.mInput.text = ID;
    this.OpenInputCheck(true);
  }

  protected char OnValidateInput(string text, int index, char check)
  {
    if (Encoding.UTF8.GetByteCount(text) + Encoding.UTF8.GetByteCount(check.ToString()) > 756)
      return char.MinValue;
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.Append(text);
    cstring.Append(check.ToString());
    this.text_InputCheck.text = cstring.ToString();
    this.text_InputCheck.SetAllDirty();
    this.text_InputCheck.cachedTextGenerator.Invalidate();
    return (double) this.text_InputCheck.preferredHeight > 234.0 ? char.MinValue : check;
  }

  public override void OnClose()
  {
    if (this.Cstr_Alliance_K != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Alliance_K);
    if (this.Cstr_AllianceName != null)
      StringManager.Instance.DeSpawnString(this.Cstr_AllianceName);
    if (this.Cstr_AllianceChief != null)
      StringManager.Instance.DeSpawnString(this.Cstr_AllianceChief);
    if (this.Cstr_AllianceStrength != null)
      StringManager.Instance.DeSpawnString(this.Cstr_AllianceStrength);
    if (this.Cstr_AllianceMember != null)
      StringManager.Instance.DeSpawnString(this.Cstr_AllianceMember);
    if (this.Cstr_GifeLV != null)
      StringManager.Instance.DeSpawnString(this.Cstr_GifeLV);
    if (this.Cstr_AllianceLanguage != null)
      StringManager.Instance.DeSpawnString(this.Cstr_AllianceLanguage);
    if (this.Cstr_Null != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Null);
    if (this.Cstr_Translation != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Translation);
    if (!((Object) this.mInput != (Object) null))
      return;
    ((UnityEventBase) this.mInput.onEndEdit).RemoveAllListeners();
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
        this.DM.AskMessageBoard(this.DM.AllianceView.Id);
        break;
      case 2:
        this.door.OpenMenu(EGUIWindow.UI_Alliance_List, 3, (int) this.DM.AllianceView.Id);
        break;
      case 3:
        UILeaderBoard.NewOpen = true;
        this.door.OpenMenu(EGUIWindow.UI_LeaderBoard, 1, (int) this.DM.AllianceView.Id);
        break;
      case 4:
        this.DM.Letter_ReplyName = this.DM.AllianceView.Leader;
        this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 2);
        break;
      case 5:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.AllianceOnJoin(this.DM.AllianceView.Id, this.DM.AllianceView.Approval);
        break;
      case 6:
        if (!((Component) this.mInput).gameObject.activeSelf)
          ((Component) this.mInput).gameObject.SetActive(true);
        this.mInput.ActivateInputField();
        if (!((Component) this.text_Trans).gameObject.activeSelf)
          break;
        ((Component) this.text_Trans).gameObject.SetActive(false);
        break;
      case 7:
        if (this.DM.RoleAlliance.Rank < AllianceRank.RANK4)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(4753U), (ushort) byte.MaxValue);
          this.door.CloseMenu();
          break;
        }
        if (this.DM.RoleAlliance.Id != 0U && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4 && GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage))
        {
          char[] charArray = this.mInput.text.ToCharArray();
          if (this.DM.m_BannedWord != null)
            this.DM.m_BannedWord.CheckBannedWord(charArray);
          byte[] bytes = Encoding.UTF8.GetBytes(charArray);
          MessagePacket messagePacket = new MessagePacket((ushort) 1311);
          messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_BRIEF;
          messagePacket.AddSeqId();
          messagePacket.Add((ushort) bytes.Length);
          messagePacket.Add(bytes, len: 1300);
          byte data = !ArabicTransfer.Instance.IsArabicStr(this.mInput.text) ? (byte) 1 : (byte) 2;
          messagePacket.Add(data);
          messagePacket.Send();
        }
        this.OpenInputCheck(false);
        break;
      case 8:
        if (((Component) this.mInput).gameObject.activeSelf)
          ((Component) this.mInput).gameObject.SetActive(false);
        this.mInput.text = this.DM.AllianceView.Notice;
        if (!((Component) this.text_Trans).gameObject.activeSelf)
          ((Component) this.text_Trans).gameObject.SetActive(true);
        this.bShowTranslate = true;
        this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052U);
        this.text_Translation.SetAllDirty();
        this.text_Translation.cachedTextGenerator.Invalidate();
        this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
        this.TranslationRT.anchoredPosition = -237.5 - (double) this.text_Trans.preferredHeight <= -470.0 ? new Vector2(this.TranslationRT.anchoredPosition.x, -470f) : new Vector2(this.TranslationRT.anchoredPosition.x, -237.5f - this.text_Trans.preferredHeight);
        if ((double) this.text_Translation.preferredWidth > (double) ((Graphic) this.text_Translation).rectTransform.sizeDelta.x)
          ((Graphic) this.text_Translation).rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, ((Graphic) this.text_Translation).rectTransform.sizeDelta.y);
        if (this.GUIM.IsArabic)
          this.text_Translation.UpdateArabicPos();
        this.OpenInputCheck(false);
        break;
      case 9:
        this.OpenInputCheck(false);
        this.mInput.ActivateInputField();
        if (!((Component) this.text_Trans).gameObject.activeSelf)
          break;
        ((Component) this.text_Trans).gameObject.SetActive(false);
        break;
      case 11:
        if (this.DM.bWaitTranslate_AA)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(8459U), (ushort) byte.MaxValue);
          break;
        }
        if (IGGGameSDK.Instance.GetTranslateStatus() && this.DM.bNeedTranslate_AA_P && !this.DM.bTranslate_AA_P && !this.DM.bWaitTranslate_AA)
        {
          ((Component) this.btn_Translation).gameObject.SetActive(false);
          ((Component) this.Img_Translate).gameObject.SetActive(true);
          this.DM.bWaitTranslate_AA = true;
          this.DM.bTransAA = false;
          IGGSDKPlugin.Translate_AA(this.DM.AllianceView.Notice);
          break;
        }
        if (!this.bShowTranslate)
        {
          this.text_Trans.text = this.DM.AllianceView.Notice;
          this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052U);
          this.bShowTranslate = true;
        }
        else
        {
          this.text_Trans.text = IGGGameSDK.Instance.TranslateStringOut_AA_Public.ToString();
          this.Cstr_Translation.ClearString();
          this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte) this.DM.mAA_P_L));
          this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054U));
          this.text_Translation.text = this.Cstr_Translation.ToString();
          this.bShowTranslate = false;
        }
        this.text_Trans.SetAllDirty();
        this.text_Trans.cachedTextGenerator.Invalidate();
        this.text_Trans.cachedTextGeneratorForLayout.Invalidate();
        this.text_Translation.SetAllDirty();
        this.text_Translation.cachedTextGenerator.Invalidate();
        this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
        this.TranslationRT.anchoredPosition = -237.5 - (double) this.text_Trans.preferredHeight <= -470.0 ? new Vector2(this.TranslationRT.anchoredPosition.x, -470f) : new Vector2(this.TranslationRT.anchoredPosition.x, -237.5f - this.text_Trans.preferredHeight);
        if ((double) this.text_Translation.preferredWidth > (double) ((Graphic) this.text_Translation).rectTransform.sizeDelta.x)
          ((Graphic) this.text_Translation).rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, ((Graphic) this.text_Translation).rectTransform.sizeDelta.y);
        if (!this.GUIM.IsArabic)
          break;
        this.text_Translation.UpdateArabicPos();
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if ((sender.m_Button as UIButton).m_BtnID1 != 10)
      return;
    ((Component) this.img_KHint).gameObject.SetActive(true);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if ((sender.m_Button as UIButton).m_BtnID1 != 10)
      return;
    ((Component) this.img_KHint).gameObject.SetActive(false);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        if (this.DM.RoleAlliance.Id != 0U || this.mType == 5)
          break;
        if ((Object) this.img_InputBG != (Object) null)
          this.OpenInputCheck(false);
        this.door.CloseMenu_Alliance(EGUIWindow.UIAlliance_publicinfo);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Alliance)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.Refresh_FontTexture();
          break;
        }
        if (this.DM.RoleAlliance.Id == 0U && this.mType != 5)
        {
          this.door.CloseMenu_Alliance(EGUIWindow.UIAlliance_publicinfo);
          break;
        }
        if ((int) this.DM.RoleAlliance.Id != (int) this.DM.AllianceView.Id || this.Cstr_Alliance_K == null || !((Object) this.text_Alliance_K != (Object) null) || !((Object) this.btn_KHint != (Object) null))
          break;
        this.Cstr_Alliance_K.ClearString();
        this.Cstr_Alliance_K.IntToFormat((long) this.DM.RoleAlliance.KingdomID);
        if (this.GUIM.IsArabic)
          this.Cstr_Alliance_K.AppendFormat("{0}#");
        else
          this.Cstr_Alliance_K.AppendFormat("#{0}");
        this.text_Alliance_K.text = this.Cstr_Alliance_K.ToString();
        this.text_Alliance_K.SetAllDirty();
        this.text_Alliance_K.cachedTextGenerator.Invalidate();
        if ((int) this.DM.RoleAlliance.KingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID)
        {
          ((Component) this.text_Alliance_K).gameObject.SetActive(true);
          ((Component) this.btn_KHint).gameObject.SetActive(true);
          break;
        }
        ((Component) this.text_Alliance_K).gameObject.SetActive(false);
        ((Component) this.btn_KHint).gameObject.SetActive(false);
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_AllianceChief != (Object) null && ((Behaviour) this.text_AllianceChief).enabled)
    {
      ((Behaviour) this.text_AllianceChief).enabled = false;
      ((Behaviour) this.text_AllianceChief).enabled = true;
    }
    if ((Object) this.text_AllianceStrength != (Object) null && ((Behaviour) this.text_AllianceStrength).enabled)
    {
      ((Behaviour) this.text_AllianceStrength).enabled = false;
      ((Behaviour) this.text_AllianceStrength).enabled = true;
    }
    if ((Object) this.text_AllianceMember != (Object) null && ((Behaviour) this.text_AllianceMember).enabled)
    {
      ((Behaviour) this.text_AllianceMember).enabled = false;
      ((Behaviour) this.text_AllianceMember).enabled = true;
    }
    if ((Object) this.text_AllianceLanguage != (Object) null && ((Behaviour) this.text_AllianceLanguage).enabled)
    {
      ((Behaviour) this.text_AllianceLanguage).enabled = false;
      ((Behaviour) this.text_AllianceLanguage).enabled = true;
    }
    if ((Object) this.text_Gife != (Object) null && ((Behaviour) this.text_Gife).enabled)
    {
      ((Behaviour) this.text_Gife).enabled = false;
      ((Behaviour) this.text_Gife).enabled = true;
    }
    if ((Object) this.text_join != (Object) null && ((Behaviour) this.text_join).enabled)
    {
      ((Behaviour) this.text_join).enabled = false;
      ((Behaviour) this.text_join).enabled = true;
    }
    if ((Object) this.text_join_btn != (Object) null && ((Behaviour) this.text_join_btn).enabled)
    {
      ((Behaviour) this.text_join_btn).enabled = false;
      ((Behaviour) this.text_join_btn).enabled = true;
    }
    if ((Object) this.text_AllianceName != (Object) null && ((Behaviour) this.text_AllianceName).enabled)
    {
      ((Behaviour) this.text_AllianceName).enabled = false;
      ((Behaviour) this.text_AllianceName).enabled = true;
    }
    if ((Object) this.text_InputCheck != (Object) null && ((Behaviour) this.text_InputCheck).enabled)
    {
      ((Behaviour) this.text_InputCheck).enabled = false;
      ((Behaviour) this.text_InputCheck).enabled = true;
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
    if ((Object) this.img_text != (Object) null)
    {
      if ((Object) this.img_text.m_RunningText1 != (Object) null && ((Behaviour) this.img_text.m_RunningText1).enabled)
      {
        ((Behaviour) this.img_text.m_RunningText1).enabled = false;
        ((Behaviour) this.img_text.m_RunningText1).enabled = true;
      }
      if ((Object) this.img_text.m_RunningText2 != (Object) null && ((Behaviour) this.img_text.m_RunningText2).enabled)
      {
        ((Behaviour) this.img_text.m_RunningText2).enabled = false;
        ((Behaviour) this.img_text.m_RunningText2).enabled = true;
      }
    }
    if ((Object) this.text_Trans != (Object) null && ((Behaviour) this.text_Trans).enabled)
    {
      ((Behaviour) this.text_Trans).enabled = false;
      ((Behaviour) this.text_Trans).enabled = true;
    }
    if ((Object) this.text_Translation != (Object) null && ((Behaviour) this.text_Translation).enabled)
    {
      ((Behaviour) this.text_Translation).enabled = false;
      ((Behaviour) this.text_Translation).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_Propaganda[index] != (Object) null && ((Behaviour) this.text_Propaganda[index]).enabled)
      {
        ((Behaviour) this.text_Propaganda[index]).enabled = false;
        ((Behaviour) this.text_Propaganda[index]).enabled = true;
      }
    }
    for (int index = 0; index < 10; ++index)
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
        this.Cstr_AllianceChief.ClearString();
        this.Cstr_AllianceChief.StringToFormat(this.DM.AllianceView.Leader);
        this.Cstr_AllianceChief.AppendFormat(this.DM.mStringTable.GetStringByID(4625U));
        this.text_AllianceChief.text = this.Cstr_AllianceChief.ToString();
        this.text_AllianceChief.SetAllDirty();
        this.text_AllianceChief.cachedTextGenerator.Invalidate();
        ((Component) this.text_AllianceChief).gameObject.SetActive(true);
        this.Cstr_AllianceStrength.ClearString();
        this.Cstr_AllianceStrength.uLongToFormat(this.DM.AllianceView.Power, bNumber: true);
        this.Cstr_AllianceStrength.AppendFormat(this.DM.mStringTable.GetStringByID(4626U));
        this.text_AllianceStrength.text = this.Cstr_AllianceStrength.ToString();
        this.text_AllianceStrength.SetAllDirty();
        this.text_AllianceStrength.cachedTextGenerator.Invalidate();
        ((Component) this.text_AllianceStrength).gameObject.SetActive(true);
        this.Cstr_AllianceMember.ClearString();
        this.Cstr_AllianceMember.IntToFormat((long) this.DM.AllianceView.Member);
        this.Cstr_AllianceMember.AppendFormat(this.DM.mStringTable.GetStringByID(4627U));
        this.text_AllianceMember.text = this.Cstr_AllianceMember.ToString();
        this.text_AllianceMember.SetAllDirty();
        this.text_AllianceMember.cachedTextGenerator.Invalidate();
        ((Component) this.text_AllianceMember).gameObject.SetActive(true);
        this.Cstr_AllianceLanguage.ClearString();
        this.Cstr_AllianceLanguage.StringToFormat(this.DM.GetLanguageStr(this.DM.AllianceView.Language));
        this.Cstr_AllianceLanguage.AppendFormat(this.DM.mStringTable.GetStringByID(4642U));
        this.text_AllianceLanguage.text = this.Cstr_AllianceLanguage.ToString();
        this.text_AllianceLanguage.SetAllDirty();
        this.text_AllianceLanguage.cachedTextGenerator.Invalidate();
        ((Component) this.text_AllianceLanguage).gameObject.SetActive(true);
        this.Cstr_GifeLV.ClearString();
        this.Cstr_GifeLV.IntToFormat((long) this.DM.AllianceView.GiftLv);
        this.Cstr_GifeLV.AppendFormat(this.DM.mStringTable.GetStringByID(4631U));
        this.text_Gife.text = this.Cstr_GifeLV.ToString();
        this.text_Gife.SetAllDirty();
        this.text_Gife.cachedTextGenerator.Invalidate();
        ((Component) this.text_Gife).gameObject.SetActive(true);
        this.bNeedApplication = this.DM.AllianceView.Approval != (byte) 0;
        if (this.bNeedApplication)
        {
          this.text_join.text = this.DM.mStringTable.GetStringByID(4643U);
          ((Graphic) this.text_join).color = this.Color_Red;
          this.Img_Join.sprite = this.SArray.m_Sprites[0];
          this.btn_Join.image.sprite = this.SArray.m_Sprites[3];
          this.text_join_btn.text = this.DM.mStringTable.GetStringByID(4647U);
        }
        else
        {
          this.text_join.text = this.DM.mStringTable.GetStringByID(4644U);
          ((Graphic) this.text_join).color = this.Color_Green;
          this.Img_Join.sprite = this.SArray.m_Sprites[1];
          this.btn_Join.image.sprite = this.SArray.m_Sprites[2];
          this.text_join_btn.text = this.DM.mStringTable.GetStringByID(4646U);
        }
        ((Component) this.text_join).gameObject.SetActive(true);
        this.text_join.SetAllDirty();
        this.text_join.cachedTextGenerator.Invalidate();
        if (this.DM.RoleAlliance.ApplyList != null)
        {
          bool flag = false;
          for (int index = 0; index < this.DM.RoleAlliance.ApplyList.Length; ++index)
          {
            if ((int) this.DM.RoleAlliance.ApplyList[index] == (int) this.DM.AllianceView.Id)
            {
              flag = true;
              break;
            }
          }
          if (flag)
          {
            this.text_join_btn.text = this.DM.mStringTable.GetStringByID(4648U);
            this.btn_Join.image.sprite = this.SArray.m_Sprites[4];
          }
        }
        this.text_join_btn.SetAllDirty();
        this.text_join_btn.cachedTextGenerator.Invalidate();
        if (this.DM.AllianceView.Notice != null)
        {
          this.Cstr_Null.ClearString();
          this.mInput.text = this.Cstr_Null.ToString();
          if (this.DM.AllianceView.Notice.Length != 0)
            this.mInput.text = this.DM.AllianceView.Notice;
          else if ((int) this.DM.AllianceView.Id == (int) this.DM.RoleAlliance.Id && this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
          {
            this.text_Input1.text = this.DM.mStringTable.GetStringByID(773U);
            this.mInput.text = this.DM.mStringTable.GetStringByID(773U);
          }
          else
            this.text_Input1.text = this.Cstr_Null.ToString();
          this.text_Trans.text = this.mInput.text;
          this.text_Trans.resizeTextForBestFit = false;
          this.text_Trans.SetAllDirty();
          this.text_Trans.cachedTextGenerator.Invalidate();
          this.text_Trans.cachedTextGeneratorForLayout.Invalidate();
          ((Component) this.text_Trans).gameObject.SetActive(false);
          this.TranslationRT.anchoredPosition = -237.5 - (double) this.text_Trans.preferredHeight <= -470.0 ? new Vector2(this.TranslationRT.anchoredPosition.x, -470f) : new Vector2(this.TranslationRT.anchoredPosition.x, -237.5f - this.text_Trans.preferredHeight);
          if (IGGGameSDK.Instance.GetTranslateStatus() && this.DM.AllianceView.Notice != null && this.DM.AllianceView.Notice.Length > 0)
            ((Component) this.TranslationRT).gameObject.SetActive(true);
          else
            ((Component) this.TranslationRT).gameObject.SetActive(false);
          this.DM.bNeedTranslate_AA_P = true;
        }
        if ((int) this.DM.AllianceView.Id == (int) this.DM.RoleAlliance.Id && this.DM.RoleAlliance.Rank < AllianceRank.RANK4)
          this.mInput.DeactivateInputField();
        this.Cstr_AllianceName.ClearString();
        CString Name = StringManager.Instance.StaticString1024();
        Name.ClearString();
        CString Tag = StringManager.Instance.StaticString1024();
        Tag.ClearString();
        Name.Append(this.DM.AllianceView.Name);
        Tag.Append(this.DM.AllianceView.Tag);
        GameConstants.FormatRoleName(this.Cstr_AllianceName, Name, Tag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
        this.text_AllianceName.text = this.Cstr_AllianceName.ToString();
        this.text_AllianceName.SetAllDirty();
        this.text_AllianceName.cachedTextGenerator.Invalidate();
        ((Component) this.text_AllianceName).gameObject.SetActive(true);
        this.GUIM.InitBadgeTotem(this.BadgeT, this.DM.AllianceView.Emblem);
        RectTransform component1 = ((Component) this.text_Propaganda[0]).transform.GetComponent<RectTransform>();
        this.tmpString.Length = 0;
        this.tmpString.Append(this.DM.AllianceView.Header);
        this.text_Propaganda[0].text = this.tmpString.ToString();
        ((Component) this.text_Propaganda[0]).gameObject.SetActive(true);
        this.text_Propaganda[1].text = this.tmpString.ToString();
        ((Component) this.text_Propaganda[1]).gameObject.SetActive(true);
        RectTransform component2 = ((Component) this.text_Propaganda[1]).GetComponent<RectTransform>();
        if ((double) this.text_Propaganda[0].preferredWidth > 281.0)
        {
          component1.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth, component1.sizeDelta.y);
          if (this.GUIM.IsArabic)
            this.text_Propaganda[0].UpdateArabicPos();
          component2.anchoredPosition = new Vector2(this.text_Propaganda[0].preferredWidth, component2.anchoredPosition.y);
          component2.sizeDelta = new Vector2(this.text_Propaganda[0].preferredWidth, component2.sizeDelta.y);
          if (this.GUIM.IsArabic)
            this.text_Propaganda[1].UpdateArabicPos();
          this.img_text.tmpLength = this.text_Propaganda[0].preferredWidth;
        }
        if ((int) this.DM.AllianceView.Id != (int) this.DM.RoleAlliance.Id)
        {
          if (this.DM.AllianceView.Header == null || this.DM.AllianceView.Header.Length == 0)
            this.img_text.gameObject.SetActive(false);
          else
            this.img_text.gameObject.SetActive(true);
        }
        else if (this.DM.RoleAlliance.Header == null || this.DM.RoleAlliance.Header.Length == 0)
          this.img_text.gameObject.SetActive(false);
        else
          this.img_text.gameObject.SetActive(true);
        this.Cstr_Alliance_K.ClearString();
        this.Cstr_Alliance_K.IntToFormat((long) this.DM.AllianceView.KingdomID);
        if (this.GUIM.IsArabic)
          this.Cstr_Alliance_K.AppendFormat("{0}#");
        else
          this.Cstr_Alliance_K.AppendFormat("#{0}");
        this.text_Alliance_K.text = this.Cstr_Alliance_K.ToString();
        this.text_Alliance_K.SetAllDirty();
        this.text_Alliance_K.cachedTextGenerator.Invalidate();
        if ((int) this.DM.AllianceView.KingdomID != (int) DataManager.MapDataController.kingdomData.kingdomID)
        {
          ((Component) this.text_Alliance_K).gameObject.SetActive(true);
          ((Component) this.btn_KHint).gameObject.SetActive(true);
          break;
        }
        ((Component) this.text_Alliance_K).gameObject.SetActive(false);
        ((Component) this.btn_KHint).gameObject.SetActive(false);
        break;
      case 2:
        this.text_join_btn.text = this.DM.mStringTable.GetStringByID(4648U);
        this.btn_Join.image.sprite = this.SArray.m_Sprites[4];
        this.text_join_btn.SetAllDirty();
        this.text_join_btn.cachedTextGenerator.Invalidate();
        break;
      case 3:
        if ((int) this.DM.AllianceView.Id != (int) this.DM.RoleAlliance.Id)
          break;
        this.mInput.text = this.DM.RoleAlliance.Notice;
        this.DM.AllianceView.Notice = this.DM.RoleAlliance.Notice;
        this.text_Trans.text = this.mInput.text;
        this.text_Trans.resizeTextForBestFit = false;
        this.text_Trans.SetAllDirty();
        this.text_Trans.cachedTextGenerator.Invalidate();
        this.text_Trans.cachedTextGeneratorForLayout.Invalidate();
        ((Component) this.text_Trans).gameObject.SetActive(false);
        this.TranslationRT.anchoredPosition = -237.5 - (double) this.text_Trans.preferredHeight <= -470.0 ? new Vector2(this.TranslationRT.anchoredPosition.x, -470f) : new Vector2(this.TranslationRT.anchoredPosition.x, -237.5f - this.text_Trans.preferredHeight);
        if (IGGGameSDK.Instance.GetTranslateStatus() && this.DM.AllianceView.Notice != null && this.DM.AllianceView.Notice.Length > 0)
          ((Component) this.TranslationRT).gameObject.SetActive(true);
        else
          ((Component) this.TranslationRT).gameObject.SetActive(false);
        this.DM.bNeedTranslate_AA_P = true;
        this.bShowTranslate = false;
        if (!IGGGameSDK.Instance.GetTranslateStatus())
          break;
        if (!this.bShowTranslate)
        {
          this.text_Trans.text = this.DM.AllianceView.Notice;
          this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052U);
          this.bShowTranslate = true;
        }
        else
        {
          this.text_Trans.text = IGGGameSDK.Instance.TranslateStringOut_AA_Public.ToString();
          this.Cstr_Translation.ClearString();
          this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte) this.DM.mAA_P_L));
          this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054U));
          this.text_Translation.text = this.Cstr_Translation.ToString();
          this.bShowTranslate = false;
        }
        this.text_Trans.SetAllDirty();
        this.text_Trans.cachedTextGenerator.Invalidate();
        this.text_Translation.SetAllDirty();
        this.text_Translation.cachedTextGenerator.Invalidate();
        this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
        if ((double) this.text_Translation.preferredWidth > (double) ((Graphic) this.text_Translation).rectTransform.sizeDelta.x)
          ((Graphic) this.text_Translation).rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, ((Graphic) this.text_Translation).rectTransform.sizeDelta.y);
        if (!this.GUIM.IsArabic)
          break;
        this.text_Translation.UpdateArabicPos();
        break;
      case 4:
        if ((int) this.DM.AllianceView.Id != (int) this.DM.RoleAlliance.Id)
          break;
        this.Cstr_AllianceLanguage.ClearString();
        this.Cstr_AllianceLanguage.StringToFormat(this.DM.GetLanguageStr(this.DM.RoleAlliance.Language));
        this.Cstr_AllianceLanguage.AppendFormat(this.DM.mStringTable.GetStringByID(4642U));
        this.text_AllianceLanguage.text = this.Cstr_AllianceLanguage.ToString();
        this.text_AllianceLanguage.SetAllDirty();
        this.text_AllianceLanguage.cachedTextGenerator.Invalidate();
        break;
      case 5:
        this.mInput.ActivateInputField();
        if (!((Component) this.text_Trans).gameObject.activeSelf)
          break;
        ((Component) this.text_Trans).gameObject.SetActive(false);
        break;
      case 6:
        this.door.CloseMenu();
        break;
      case 7:
        this.bShowTranslate = false;
        ((Component) this.mInput).gameObject.SetActive(false);
        this.text_Trans.text = IGGGameSDK.Instance.TranslateStringOut_AA_Public.ToString();
        this.text_Trans.resizeTextForBestFit = true;
        this.text_Trans.resizeTextMaxSize = 17;
        ((Component) this.text_Trans).gameObject.SetActive(true);
        this.text_Trans.cachedTextGeneratorForLayout.Invalidate();
        this.TranslationRT.anchoredPosition = -237.5 - (double) this.text_Trans.preferredHeight <= -470.0 ? new Vector2(this.TranslationRT.anchoredPosition.x, -470f) : new Vector2(this.TranslationRT.anchoredPosition.x, -237.5f - this.text_Trans.preferredHeight);
        ((Component) this.btn_Translation).gameObject.SetActive(true);
        ((Component) this.Img_Translate).gameObject.SetActive(false);
        this.Cstr_Translation.ClearString();
        this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte) this.DM.mAA_P_L));
        this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054U));
        this.text_Translation.text = this.Cstr_Translation.ToString();
        this.text_Translation.SetAllDirty();
        this.text_Translation.cachedTextGenerator.Invalidate();
        this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
        if ((double) this.text_Translation.preferredWidth > (double) ((Graphic) this.text_Translation).rectTransform.sizeDelta.x)
          ((Graphic) this.text_Translation).rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, ((Graphic) this.text_Translation).rectTransform.sizeDelta.y);
        if (!this.GUIM.IsArabic)
          break;
        this.text_Translation.UpdateArabicPos();
        break;
      case 8:
        ((Component) this.btn_Translation).gameObject.SetActive(true);
        ((Component) this.Img_Translate).gameObject.SetActive(false);
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9077U), (ushort) byte.MaxValue);
        break;
      case 9:
        if ((int) this.DM.RoleAlliance.Id != (int) this.DM.AllianceView.Id)
          break;
        if (this.DM.RoleAlliance.Rank < AllianceRank.RANK4)
        {
          this.mInput.DeactivateInputField();
          ((Component) this.btn_InputField).gameObject.SetActive(false);
          ((Component) this.btn_InputField2).gameObject.SetActive(false);
          if ((Object) this.img_InputBG != (Object) null)
            this.OpenInputCheck(false);
          if (!this.DM.bNeedTranslate_AA_P && ((Component) this.mInput).gameObject.activeSelf)
            ((Component) this.mInput).gameObject.SetActive(false);
          if (!this.DM.bNeedTranslate_AA_P && !((Component) this.text_Trans).gameObject.activeSelf)
            ((Component) this.text_Trans).gameObject.SetActive(true);
          this.mInput.interactable = false;
        }
        else
        {
          this.mInput.interactable = true;
          ((Component) this.btn_InputField).gameObject.SetActive(true);
          ((Component) this.btn_InputField2).gameObject.SetActive(true);
        }
        if (this.DM.AllianceView.Notice != null)
          break;
        if (this.DM.RoleAlliance.Rank >= AllianceRank.RANK4)
        {
          this.text_Input1.text = this.DM.mStringTable.GetStringByID(773U);
          break;
        }
        this.Cstr_Null.ClearString();
        this.text_Input1.text = this.Cstr_Null.ToString();
        this.mInput.text = this.Cstr_Null.ToString();
        this.text_Trans.text = this.mInput.text;
        break;
    }
  }

  public void OpenInputCheck(bool bOpen)
  {
    if (bOpen)
    {
      ((Component) this.img_InputBG).transform.SetParent((Transform) this.GUIM.m_SecWindowLayer, false);
      ((Component) this.img_InputBG).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.img_InputBG).transform.SetParent(this.GameT, false);
      ((Component) this.img_InputBG).transform.SetSiblingIndex(5);
      ((Component) this.img_InputBG).gameObject.SetActive(false);
    }
  }

  public override bool OnBackButtonClick()
  {
    if (((UIBehaviour) this.img_InputBG).IsActive())
      this.OpenInputCheck(false);
    return false;
  }

  private void Update()
  {
    if (this.bOpen)
    {
      this.DM.SendAlliancePublicInfo(this.DM.AllianceView.Id, this.DM.AllianceView.Tag, (byte) 0);
      this.bOpen = false;
    }
    if (this.DM.bTranslate_AA_P)
    {
      this.GUIM.UpdateUI(EGUIWindow.UIAlliance_publicinfo, 7);
      this.DM.bTranslate_AA_P = false;
      this.DM.bNeedTranslate_AA_P = false;
    }
    if (!this.DM.bTranslate_AA_PFailed)
      return;
    this.GUIM.UpdateUI(EGUIWindow.UIAlliance_publicinfo, 8);
    this.DM.bTranslate_AA_PFailed = false;
  }
}
