// Decompiled with JetBrains decompiler
// Type: UIKingdom_Classifieds
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Text;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable disable
public class UIKingdom_Classifieds : GUIWindow, IUIButtonClickHandler
{
  private Transform GameT;
  private Transform KingdomT;
  private Transform ClassifiedsT;
  private Transform EditT;
  private DataManager DM;
  private GUIManager GUIM;
  private Font TTFont;
  private Door door;
  private UIButton btn_EXIT;
  private UIButton btn_Input_OK;
  private UIButton btn_Input_C;
  private UIButton btn_Input_Edit;
  private UIButton btn_Input;
  private UIButton btn_Mail;
  private UIButton btn_Black;
  private UIButton btn_Translation;
  private UIButton btn_I;
  private Image Img_Translate;
  private UIEmojiInput mInput;
  private UIText text_Input1;
  private UIText text_Input2;
  private UIText text_Title;
  private UIText text_Mail;
  private UIText text_Input_C;
  private UIText text_Input_OK;
  private UIText text_Translation;
  private UIText text_InputCheck;
  private CString Cstr_Translation;
  private CString InputCString;
  private byte mKingdom;
  private bool bInput;
  private bool InputCheck;
  private bool bShowTranslate;
  private bool bOpenEnd;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.Cstr_Translation = StringManager.Instance.SpawnString(100);
    this.InputCString = StringManager.Instance.SpawnString(1200);
    if (this.GUIM.bOpenOnIPhoneX)
    {
      this.GameT.GetComponent<RectTransform>().offsetMin = new Vector2(-this.GUIM.IPhoneX_DeltaX, 0.0f);
      this.GameT.GetComponent<RectTransform>().offsetMax = new Vector2(this.GUIM.IPhoneX_DeltaX, 0.0f);
    }
    if (!DataManager.MapDataController.IsInMyAllianceKingdom() || !DataManager.MapDataController.IsKing())
      this.mKingdom = (byte) 1;
    this.btn_Black = this.GameT.GetChild(0).GetComponent<UIButton>();
    this.btn_Black.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Black.m_BtnID1 = 6;
    this.text_Title = this.GameT.GetChild(3).GetChild(1).GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.DM.mStringTable.GetStringByID(1444U);
    this.btn_EXIT = this.GameT.GetChild(4).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.door.LoadMaterial();
    if (this.GUIM.bOpenOnIPhoneX)
      this.GameT.GetChild(4).GetComponent<RectTransform>().anchoredPosition = new Vector2(-92f, -42f);
    this.mInput = this.GameT.GetChild(5).GetComponent<UIEmojiInput>();
    // ISSUE: method pointer
    this.mInput.onEndEdit.AddListener(new UnityAction<string>((object) this, __methodptr(\u003COnOpen\u003Em__F2)));
    this.text_Input1 = this.mInput.textComponent;
    this.text_Input1.font = this.TTFont;
    this.text_Input2 = this.mInput.placeholder as UIText;
    this.text_Input2.font = this.TTFont;
    this.mInput.onValidateInput = new UIEmojiInput.OnValidateInput(this.OnValidateInput);
    this.KingdomT = this.GameT.GetChild(6);
    this.btn_Input_Edit = this.KingdomT.GetChild(0).GetComponent<UIButton>();
    this.btn_Input_Edit.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Input_Edit.m_BtnID1 = 2;
    this.btn_Input = this.KingdomT.GetChild(1).GetComponent<UIButton>();
    this.btn_Input.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Input.m_BtnID1 = 3;
    this.btn_Mail = this.KingdomT.GetChild(2).GetComponent<UIButton>();
    this.btn_Mail.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Mail.m_BtnID1 = 1;
    this.btn_Mail.m_EffectType = e_EffectType.e_Scale;
    this.btn_Mail.transition = (Selectable.Transition) 0;
    this.text_Mail = this.KingdomT.GetChild(2).GetChild(1).GetComponent<UIText>();
    this.text_Mail.font = this.TTFont;
    this.text_Mail.text = this.DM.mStringTable.GetStringByID(1445U);
    this.ClassifiedsT = this.GameT.GetChild(7);
    this.ClassifiedsT.GetComponent<RectTransform>().anchoredPosition = new Vector2(1f, 170f);
    this.btn_Translation = this.ClassifiedsT.GetChild(0).GetComponent<UIButton>();
    this.btn_Translation.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Translation.m_BtnID1 = 7;
    this.Img_Translate = this.ClassifiedsT.GetChild(1).GetComponent<Image>();
    this.text_Translation = this.ClassifiedsT.GetChild(2).GetComponent<UIText>();
    this.text_Translation.font = this.TTFont;
    this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052U);
    ((Graphic) this.text_Translation).color = new Color(0.69f, 0.596f, 0.498f);
    if ((double) this.text_Translation.preferredWidth > (double) ((Graphic) this.text_Translation).rectTransform.sizeDelta.x)
      ((Graphic) this.text_Translation).rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, ((Graphic) this.text_Translation).rectTransform.sizeDelta.y);
    if (this.GUIM.IsArabic)
      this.text_Translation.UpdateArabicPos();
    this.EditT = this.GameT.GetChild(8);
    this.btn_Input_C = this.EditT.GetChild(0).GetComponent<UIButton>();
    this.btn_Input_C.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Input_C.m_BtnID1 = 5;
    this.btn_Input_C.m_EffectType = e_EffectType.e_Scale;
    this.btn_Input_C.transition = (Selectable.Transition) 0;
    this.text_Input_C = this.EditT.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_Input_C.font = this.TTFont;
    this.text_Input_C.text = this.DM.mStringTable.GetStringByID(513U);
    this.btn_Input_OK = this.EditT.GetChild(1).GetComponent<UIButton>();
    this.btn_Input_OK.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Input_OK.m_BtnID1 = 4;
    this.btn_Input_OK.m_EffectType = e_EffectType.e_Scale;
    this.btn_Input_OK.transition = (Selectable.Transition) 0;
    this.text_Input_OK = this.EditT.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_Input_OK.font = this.TTFont;
    this.text_Input_OK.text = this.DM.mStringTable.GetStringByID(1448U);
    this.text_InputCheck = this.GameT.GetChild(9).GetComponent<UIText>();
    this.text_InputCheck.font = this.TTFont;
    this.text_InputCheck.alignment = TextAnchor.UpperLeft;
    this.btn_I = this.GameT.GetChild(10).GetComponent<UIButton>();
    if (this.GUIM.IsArabic)
      ((Component) this.btn_I).gameObject.AddComponent<ArabicItemTextureRot>();
    this.btn_I.m_Handler = (IUIButtonClickHandler) this;
    this.btn_I.m_BtnID1 = 8;
    this.btn_I.m_EffectType = e_EffectType.e_Scale;
    this.btn_I.transition = (Selectable.Transition) 0;
    if (this.DM.mKingdomClassifieds != string.Empty)
    {
      this.mInput.text = StringManager.InputTemp;
      this.mInput.text = this.DM.mKingdomClassifieds;
    }
    ((Behaviour) this.mInput).enabled = false;
    if (this.mKingdom == (byte) 0)
    {
      this.KingdomT.gameObject.SetActive(true);
      if (this.DM.mKingdomClassifieds == string.Empty)
        this.text_Input2.text = this.DM.mStringTable.GetStringByID(1446U);
      ((Component) this.btn_I).gameObject.SetActive(true);
    }
    else
      ((Component) this.btn_I).gameObject.SetActive(false);
    this.SetShowClassifiedsT();
    this.bOpenEnd = true;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 1);
    UIButton component = this.transform.GetChild(0).GetComponent<UIButton>();
    component.m_Handler = (IUIButtonClickHandler) this;
    component.m_BtnID1 = 0;
    Object.Destroy((Object) this.transform.GetChild(1).GetComponent<IgnoreRaycast>());
    Object.Destroy((Object) this.transform.GetChild(2).GetComponent<IgnoreRaycast>());
  }

  public void ChangText(string ID)
  {
    this.text_InputCheck.text = ID;
    this.text_InputCheck.SetAllDirty();
    this.text_InputCheck.cachedTextGenerator.Invalidate();
    this.text_InputCheck.cachedTextGeneratorForLayout.Invalidate();
    this.mInput.text = StringManager.InputTemp;
    this.mInput.text = ID;
    this.OpenInputCheck(true);
    this.InputCheck = true;
  }

  protected char OnValidateInput(string text, int index, char check)
  {
    if (Encoding.UTF8.GetByteCount(text) + Encoding.UTF8.GetByteCount(check.ToString()) > 1024)
      return char.MinValue;
    this.InputCString.Length = 0;
    this.InputCString.Append(text);
    this.InputCString.Append(check.ToString());
    this.text_InputCheck.text = this.InputCString.ToString();
    this.text_InputCheck.SetAllDirty();
    this.text_InputCheck.cachedTextGenerator.Invalidate();
    this.text_InputCheck.cachedTextGeneratorForLayout.Invalidate();
    return (double) this.text_InputCheck.preferredHeight > 320.0 ? char.MinValue : check;
  }

  public override void OnClose()
  {
    if (this.Cstr_Translation != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Translation);
    if (this.InputCString == null)
      return;
    StringManager.Instance.DeSpawnString(this.InputCString);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (this.bInput && !this.InputCheck && sender.m_BtnID1 == 6)
    {
      this.OpenInputCheck(true);
      ((Behaviour) this.mInput).enabled = false;
    }
    else
    {
      switch (sender.m_BtnID1)
      {
        case 0:
          if (!((Object) this.door != (Object) null))
            break;
          this.door.CloseMenu();
          break;
        case 1:
          if (!DataManager.MapDataController.CheckKingFunction(eKingFunction.eAnnouncement))
            break;
          if (this.text_Input1.text.Length == 0 || this.text_Input1.text == this.DM.mStringTable.GetStringByID(1446U))
          {
            this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1447U), (ushort) byte.MaxValue);
            break;
          }
          GUIManager.Instance.OpenSpendWindow_Normal((GUIWindow) this, this.DM.mStringTable.GetStringByID(1445U), this.DM.mStringTable.GetStringByID(1450U), 200, Buttontext: this.DM.mStringTable.GetStringByID(1451U));
          break;
        case 2:
          if (!DataManager.MapDataController.CheckKingFunction(eKingFunction.eAnnouncement))
            break;
          ((Behaviour) this.mInput).enabled = true;
          this.mInput.ActivateInputField();
          this.bInput = true;
          this.KingdomT.gameObject.SetActive(false);
          break;
        case 3:
          if (!DataManager.MapDataController.CheckKingFunction(eKingFunction.eAnnouncement))
            break;
          ((Behaviour) this.mInput).enabled = true;
          this.mInput.ActivateInputField();
          this.bInput = true;
          this.KingdomT.gameObject.SetActive(false);
          this.EditT.gameObject.SetActive(false);
          break;
        case 4:
          if (!DataManager.MapDataController.CheckKingFunction(eKingFunction.eAnnouncement))
            break;
          if (this.text_Input1.text.Length == 0 || this.text_Input1.text == this.DM.mStringTable.GetStringByID(1446U))
          {
            this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(1447U), (ushort) byte.MaxValue);
            break;
          }
          this.DM.SendModifyKingdomBullitin(this.mInput.text);
          break;
        case 5:
          ((Behaviour) this.mInput).enabled = false;
          this.OpenInputCheck(false);
          this.bInput = false;
          this.KingdomT.gameObject.SetActive(true);
          this.mInput.text = StringManager.InputTemp;
          if (this.DM.mKingdomClassifieds != string.Empty)
          {
            this.mInput.text = this.DM.mKingdomClassifieds;
            break;
          }
          this.mInput.text = string.Empty;
          break;
        case 7:
          if (this.DM.bNeedTranslateClassifieds && !this.DM.bTranslateClassifieds && !this.DM.bWaitTranslateClassifieds)
          {
            ((Component) this.btn_Translation).gameObject.SetActive(false);
            ((Component) this.Img_Translate).gameObject.SetActive(true);
            this.DM.bWaitTranslateClassifieds = true;
            IGGSDKPlugin.Translate_KA(this.DM.mKingdomClassifieds);
            break;
          }
          if (!this.bShowTranslate)
          {
            this.mInput.text = StringManager.InputTemp;
            this.mInput.text = this.DM.mKingdomClassifieds;
            this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052U);
            this.bShowTranslate = true;
            this.text_Input1.resizeTextForBestFit = false;
          }
          else
          {
            this.mInput.text = StringManager.InputTemp;
            this.mInput.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
            this.text_InputCheck.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
            this.text_InputCheck.SetAllDirty();
            this.text_InputCheck.cachedTextGenerator.Invalidate();
            this.text_InputCheck.cachedTextGeneratorForLayout.Invalidate();
            if ((double) this.text_InputCheck.preferredHeight > 320.0)
            {
              this.text_Input1.resizeTextForBestFit = true;
              this.text_Input1.resizeTextMaxSize = 17;
              this.text_Input1.resizeTextMinSize = 10;
              this.text_Input1.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
              this.text_Input1.SetAllDirty();
              this.text_Input1.cachedTextGenerator.Invalidate();
              this.text_Input1.cachedTextGeneratorForLayout.Invalidate();
            }
            this.Cstr_Translation.ClearString();
            this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte) this.DM.mKingdomClassifieds_L));
            this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054U));
            this.text_Translation.text = this.Cstr_Translation.ToString();
            this.bShowTranslate = false;
          }
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
          this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(1444U), this.DM.mStringTable.GetStringByID(1477U), bInfo: true, BackExit: true);
          break;
      }
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 0:
        if (this.DM.RoleAttr.Diamond >= 200U)
        {
          this.DM.SendMailBullitin();
          break;
        }
        this.GUIM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966U), this.DM.mStringTable.GetStringByID(646U), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 1, bCloseIDSet: true);
        break;
      case 1:
        MallManager.Instance.Send_Mall_Info();
        break;
    }
  }

  private void SetShowClassifiedsT()
  {
    if (this.mKingdom != (byte) 0 && GUIManager.Instance.CheckNeedTranslate(this.DM.mKingdomClassifieds))
      this.ClassifiedsT.gameObject.SetActive(true);
    else
      this.ClassifiedsT.gameObject.SetActive(false);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Title != (Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((Object) this.text_Input1 != (Object) null && ((Behaviour) this.text_Input1).enabled)
    {
      ((Behaviour) this.text_Input1).enabled = false;
      ((Behaviour) this.text_Input1).enabled = true;
    }
    if ((Object) this.text_Input2 != (Object) null && ((Behaviour) this.text_Input2).enabled)
    {
      ((Behaviour) this.text_Input2).enabled = false;
      ((Behaviour) this.text_Input2).enabled = true;
    }
    if ((Object) this.text_Mail != (Object) null && ((Behaviour) this.text_Mail).enabled)
    {
      ((Behaviour) this.text_Mail).enabled = false;
      ((Behaviour) this.text_Mail).enabled = true;
    }
    if ((Object) this.text_Input_C != (Object) null && ((Behaviour) this.text_Input_C).enabled)
    {
      ((Behaviour) this.text_Input_C).enabled = false;
      ((Behaviour) this.text_Input_C).enabled = true;
    }
    if ((Object) this.text_Input_OK != (Object) null && ((Behaviour) this.text_Input_OK).enabled)
    {
      ((Behaviour) this.text_Input_OK).enabled = false;
      ((Behaviour) this.text_Input_OK).enabled = true;
    }
    if ((Object) this.text_Translation != (Object) null && ((Behaviour) this.text_Translation).enabled)
    {
      ((Behaviour) this.text_Translation).enabled = false;
      ((Behaviour) this.text_Translation).enabled = true;
    }
    if (!((Object) this.text_InputCheck != (Object) null) || !((Behaviour) this.text_InputCheck).enabled)
      return;
    ((Behaviour) this.text_InputCheck).enabled = false;
    ((Behaviour) this.text_InputCheck).enabled = true;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        if (!this.bOpenEnd)
          break;
        if ((Object) this.EditT != (Object) null)
          this.OpenInputCheck(false);
        this.bInput = false;
        ((Behaviour) this.mInput).enabled = false;
        if (!((Object) this.KingdomT != (Object) null))
          break;
        this.KingdomT.gameObject.SetActive(true);
        break;
      case 1:
        if (!this.bOpenEnd)
          break;
        if ((Object) this.mInput != (Object) null)
        {
          this.mInput.text = StringManager.InputTemp;
          this.mInput.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
          this.text_InputCheck.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
          this.text_InputCheck.SetAllDirty();
          this.text_InputCheck.cachedTextGenerator.Invalidate();
          this.text_InputCheck.cachedTextGeneratorForLayout.Invalidate();
          if ((double) this.text_InputCheck.preferredHeight > 320.0)
          {
            this.text_Input1.resizeTextForBestFit = true;
            this.text_Input1.resizeTextMaxSize = 17;
            this.text_Input1.resizeTextMinSize = 10;
            this.text_Input1.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
            this.text_Input1.SetAllDirty();
            this.text_Input1.cachedTextGenerator.Invalidate();
            this.text_Input1.cachedTextGeneratorForLayout.Invalidate();
          }
        }
        ((Component) this.btn_Translation).gameObject.SetActive(true);
        ((Component) this.Img_Translate).gameObject.SetActive(false);
        this.Cstr_Translation.ClearString();
        this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte) this.DM.mKingdomClassifieds_L));
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
      case 2:
        if (!this.bOpenEnd)
          break;
        ((Component) this.btn_Translation).gameObject.SetActive(true);
        ((Component) this.Img_Translate).gameObject.SetActive(false);
        ((Component) this.btn_Translation).gameObject.SetActive(true);
        ((Component) this.Img_Translate).gameObject.SetActive(false);
        this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(9077U), (ushort) byte.MaxValue);
        break;
      case 3:
        if (!this.bOpenEnd)
          break;
        if (this.DM.mKingdomClassifieds == string.Empty)
        {
          this.text_Input2.text = this.DM.mStringTable.GetStringByID(1446U);
          break;
        }
        this.mInput.text = StringManager.InputTemp;
        this.mInput.text = this.DM.mKingdomClassifieds;
        break;
      case 4:
        if (!this.bOpenEnd)
          break;
        this.SetShowClassifiedsT();
        if (this.DM.bNeedTranslateClassifieds)
          this.bShowTranslate = false;
        if (!this.bShowTranslate)
        {
          this.mInput.text = StringManager.InputTemp;
          this.mInput.text = this.DM.mKingdomClassifieds;
          this.text_Translation.text = this.DM.mStringTable.GetStringByID(9052U);
          this.text_Input1.resizeTextForBestFit = false;
        }
        else
        {
          this.mInput.text = StringManager.InputTemp;
          this.mInput.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
          this.text_InputCheck.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
          this.text_InputCheck.SetAllDirty();
          this.text_InputCheck.cachedTextGenerator.Invalidate();
          this.text_InputCheck.cachedTextGeneratorForLayout.Invalidate();
          if ((double) this.text_InputCheck.preferredHeight > 320.0)
          {
            this.text_Input1.resizeTextForBestFit = true;
            this.text_Input1.resizeTextMaxSize = 17;
            this.text_Input1.resizeTextMinSize = 10;
            this.text_Input1.text = IGGGameSDK.Instance.TranslateStringOut_KA.ToString();
            this.text_Input1.SetAllDirty();
            this.text_Input1.cachedTextGenerator.Invalidate();
            this.text_Input1.cachedTextGeneratorForLayout.Invalidate();
          }
          this.Cstr_Translation.ClearString();
          this.Cstr_Translation.StringToFormat(IGGGameSDK.Instance.GetLanguageStringID((byte) this.DM.mKingdomClassifieds_L));
          this.Cstr_Translation.AppendFormat(this.DM.mStringTable.GetStringByID(9054U));
          this.text_Translation.text = this.Cstr_Translation.ToString();
        }
        this.text_Translation.SetAllDirty();
        this.text_Translation.cachedTextGenerator.Invalidate();
        this.text_Translation.cachedTextGeneratorForLayout.Invalidate();
        if ((double) this.text_Translation.preferredWidth > (double) ((Graphic) this.text_Translation).rectTransform.sizeDelta.x)
          ((Graphic) this.text_Translation).rectTransform.sizeDelta = new Vector2(this.text_Translation.preferredWidth + 2f, ((Graphic) this.text_Translation).rectTransform.sizeDelta.y);
        if (!this.GUIM.IsArabic)
          break;
        this.text_Translation.UpdateArabicPos();
        break;
      case 5:
        this.DM.SendKingdomBullitin_Info();
        if (this.mKingdom == (byte) 0)
        {
          if (!this.bInput)
            this.KingdomT.gameObject.SetActive(true);
          ((Component) this.btn_I).gameObject.SetActive(true);
        }
        else
        {
          this.KingdomT.gameObject.SetActive(false);
          ((Behaviour) this.mInput).enabled = false;
          ((Component) this.btn_I).gameObject.SetActive(false);
        }
        this.SetShowClassifiedsT();
        break;
    }
  }

  public void OpenInputCheck(bool bShow)
  {
    this.InputCheck = bShow;
    this.EditT.gameObject.SetActive(bShow);
  }

  public override bool OnBackButtonClick()
  {
    if (!this.bInput && !this.EditT.gameObject.activeSelf)
      return false;
    this.OpenInputCheck(false);
    this.bInput = false;
    this.KingdomT.gameObject.SetActive(true);
    return true;
  }

  private void Start()
  {
  }

  private void Update()
  {
    if (this.DM.bTranslateClassifieds)
    {
      this.GUIM.UpdateUI(EGUIWindow.UI_Kingdom_Classifieds, 1);
      this.DM.bTranslateClassifieds = false;
      this.DM.bNeedTranslateClassifieds = false;
    }
    if (!this.DM.bTranslateClassifiedsFailed)
      return;
    this.GUIM.UpdateUI(EGUIWindow.UI_Kingdom_Classifieds, 2);
    this.DM.bTranslateClassifiedsFailed = false;
  }
}
