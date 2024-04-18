// Decompiled with JetBrains decompiler
// Type: UIPetLevelUp
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal class UIPetLevelUp : GUIWindow, IUIButtonClickHandler
{
  private const float SLIDER_WIDTH = 234f;
  private const float SLIDER_TIME = 2f;
  private const float SCALE_TIME = 0.5f;
  private const float MOVETIME = 0.5f;
  private Vector2 BEGIN;
  private Vector2 END;
  private Vector2 EXP_BEGIN;
  private Vector2 EXP_END;
  private ushort m_PetID;
  private Pet3DLoader m_PetModel;
  private Transform m_SkillPanel;
  private Transform m_LvPanel;
  private Transform m_EffectTextTf;
  private Transform m_SliderTf;
  private UIText m_TitleName;
  private UIText m_PetName;
  private UIText m_SkillName;
  private UIText m_PetLv;
  private UIText m_ExpText;
  private UIText m_EffectTextLV;
  private UIText m_EffectTextExp;
  private Image m_BlueBg;
  private Image m_RedBg;
  private Image m_Slider;
  private Image m_Skill;
  private Image m_SkillFrame;
  private UISpritesArray m_Sp;
  private CString[] m_Str;
  private byte m_BeginLv;
  private byte m_EndLv;
  private float m_BeginExpRate;
  private float m_EndExpRate;
  private ushort m_PetSkillID;
  private byte m_Skillidx;
  private float[] time;
  private float rate;
  private Vector2 size;
  private Vector3 scaleSize;
  private float scale;
  private Vector2 pos;
  private float maxTime;
  private UIPetLevelUp.ExpState m_State;
  private UIPetLevelUp.ELvState m_State_Lv;
  private UIPetLevelUp.EExpState m_State_Exp;
  private UIPetLevelUp.EExpState m_State_Exp2;
  private UIPetLevelUp.EUIType m_UIType;
  private bool[] m_PlayUISFX = new bool[3];
  private byte m_SFXKey = byte.MaxValue;
  private Door door;

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_UI_notAllowPopUps);
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.m_PetID = (ushort) arg1;
    this.m_PetModel = new Pet3DLoader(this.transform.GetChild(2), this.m_PetID);
    this.m_PetModel.LoadPet();
    this.time = new float[4];
    this.time[0] = 0.0f;
    this.time[1] = 0.0f;
    this.time[2] = 0.0f;
    this.time[3] = 0.0f;
    this.m_State = UIPetLevelUp.ExpState.End;
    this.m_State_Lv = UIPetLevelUp.ELvState.None;
    this.m_State_Exp = UIPetLevelUp.EExpState.None;
    this.m_State_Exp2 = UIPetLevelUp.EExpState.None;
    this.m_PlayUISFX[0] = false;
    this.m_PlayUISFX[1] = false;
    this.m_PlayUISFX[2] = false;
    this.m_UIType = (UIPetLevelUp.EUIType) arg2;
    this.Spawn();
    this.InitUI(this.m_PetID);
    this.SetExpValue();
    this.SetLvText();
    GUIManager.Instance.m_UICanvas.renderMode = (RenderMode) 1;
    GUIManager.Instance.SetCanvasChanged();
  }

  public override void OnClose()
  {
    if (this.m_PetModel != null)
      this.m_PetModel.Destory();
    this.DeSpawn();
    if (this.m_SFXKey != byte.MaxValue)
    {
      AudioManager.Instance.StopSFX(this.m_SFXKey);
      this.m_SFXKey = byte.MaxValue;
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.UI_PetTrainingCenter, 9);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.RefreshFontTexture();
  }

  public override bool OnBackButtonClick() => false;

  public void Update()
  {
    if (this.m_PetModel != null)
      this.m_PetModel.Update();
    if (this.m_State_Lv != UIPetLevelUp.ELvState.Scale)
      this.UpdateSlider();
    this.UpdateLv();
    this.UpdateLvValue();
    this.UpdateExpValue();
  }

  public void OnButtonClick(UIButton sender)
  {
    GUIManager.Instance.CloseMenu(EGUIWindow.UI_PetLevelUp);
    GUIManager.Instance.UIQueueLockRelease(EGUIQueueLock.UIQL_UI_notAllowPopUps);
  }

  public void UpdateSlider()
  {
    if (!((Object) this.m_Slider != (Object) null) || this.m_State == UIPetLevelUp.ExpState.End)
      return;
    this.time[0] += Time.deltaTime;
    if ((int) this.m_BeginLv > (int) this.m_EndLv + 1)
      return;
    this.maxTime = (float) (2.0 * (1.0 - (double) this.m_BeginExpRate / 1.0));
    if (this.m_State == UIPetLevelUp.ExpState.Begin)
    {
      this.rate = Mathf.Lerp(this.m_BeginExpRate, 1f, this.time[0] / this.maxTime);
      if (!this.m_PlayUISFX[0])
      {
        AudioManager.Instance.PlaySFXLoop((ushort) 40069, out this.m_SFXKey);
        this.m_PlayUISFX[0] = true;
      }
      this.size = ((Graphic) this.m_Slider).rectTransform.sizeDelta;
      this.size.x = 234f * this.rate;
      this.size.x = Mathf.Clamp(this.size.x, 0.0f, 234f);
      ((Graphic) this.m_Slider).rectTransform.sizeDelta = this.size;
      if ((double) this.rate >= 1.0)
      {
        this.time[0] = 0.0f;
        ++this.m_BeginLv;
        this.m_State_Lv = UIPetLevelUp.ELvState.Scale;
        this.m_State_Exp = UIPetLevelUp.EExpState.Move;
        this.m_State = (int) this.m_BeginLv < (int) this.m_EndLv ? UIPetLevelUp.ExpState.Middle : UIPetLevelUp.ExpState.Last;
        this.SetLvText();
        this.SetEffectLvPos();
        this.CheckSliderSprite();
        if (this.m_SFXKey != byte.MaxValue)
        {
          AudioManager.Instance.StopSFX(this.m_SFXKey, false);
          this.m_SFXKey = byte.MaxValue;
        }
        AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
      }
    }
    else if (this.m_State == UIPetLevelUp.ExpState.Middle)
    {
      if (!this.m_PlayUISFX[1])
      {
        if (this.m_SFXKey != byte.MaxValue)
        {
          AudioManager.Instance.StopSFX(this.m_SFXKey, false);
          this.m_SFXKey = byte.MaxValue;
        }
        AudioManager.Instance.PlaySFXLoop((ushort) 40069, out this.m_SFXKey);
        this.m_PlayUISFX[1] = true;
      }
      this.rate = Mathf.Lerp(0.0f, 1f, this.time[0] / 2f);
      this.size = ((Graphic) this.m_Slider).rectTransform.sizeDelta;
      this.size.x = 234f * this.rate;
      this.size.x = Mathf.Clamp(this.size.x, 0.0f, 234f);
      ((Graphic) this.m_Slider).rectTransform.sizeDelta = this.size;
      if ((double) this.rate >= 1.0)
      {
        this.time[0] = 0.0f;
        ++this.m_BeginLv;
        this.m_State_Lv = UIPetLevelUp.ELvState.Scale;
        this.m_State_Exp = UIPetLevelUp.EExpState.Move;
        if ((int) this.m_EndLv == (int) this.m_BeginLv)
          this.m_State = UIPetLevelUp.ExpState.Last;
        this.CheckSliderSprite();
        this.SetLvText();
        this.SetEffectLvPos();
        this.m_PlayUISFX[1] = false;
        if (this.m_SFXKey != byte.MaxValue)
        {
          AudioManager.Instance.StopSFX(this.m_SFXKey, false);
          this.m_SFXKey = byte.MaxValue;
        }
        AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
      }
    }
    else if (this.m_State == UIPetLevelUp.ExpState.Last)
    {
      this.maxTime = (float) (2.0 * ((double) this.m_EndExpRate / 1.0));
      if (!this.m_PlayUISFX[2])
      {
        if (this.m_SFXKey != byte.MaxValue)
        {
          AudioManager.Instance.StopSFX(this.m_SFXKey, false);
          this.m_SFXKey = byte.MaxValue;
        }
        AudioManager.Instance.PlaySFXLoop((ushort) 40069, out this.m_SFXKey);
        this.m_PlayUISFX[2] = true;
      }
      this.rate = Mathf.Lerp(0.0f, this.m_EndExpRate, this.time[0] / this.maxTime);
      this.size = ((Graphic) this.m_Slider).rectTransform.sizeDelta;
      this.size.x = 234f * this.rate;
      this.size.x = Mathf.Clamp(this.size.x, 0.0f, 234f);
      ((Graphic) this.m_Slider).rectTransform.sizeDelta = this.size;
      this.CheckSliderSprite();
      if ((double) this.time[0] >= (double) this.maxTime)
      {
        this.time[0] = 0.0f;
        this.m_State = UIPetLevelUp.ExpState.End;
        if (this.m_SFXKey != byte.MaxValue)
        {
          AudioManager.Instance.StopSFX(this.m_SFXKey, false);
          this.m_SFXKey = byte.MaxValue;
        }
      }
    }
    this.UpdateExpText(this.rate);
  }

  public void UpdateLv()
  {
    RectTransform rectTransform = this.m_UIType != UIPetLevelUp.EUIType.PetLvUp ? ((Graphic) this.m_SkillName).rectTransform : (RectTransform) this.m_LvPanel;
    if (!((Object) rectTransform != (Object) null) || this.m_State_Lv == UIPetLevelUp.ELvState.None)
      return;
    this.time[1] += Time.deltaTime;
    this.scale = Mathf.Lerp(1f, 2f, this.time[1] / 0.5f);
    this.scaleSize = ((Transform) rectTransform).localScale;
    if ((double) this.scale > 1.0)
    {
      this.scaleSize.x = (float) (1.0 + (2.0 - (double) this.scale));
      if (GUIManager.Instance.IsArabic)
        this.scaleSize.x *= -1f;
      this.scaleSize.y = (float) (1.0 + (2.0 - (double) this.scale));
      this.scaleSize.z = (float) (1.0 + (2.0 - (double) this.scale));
    }
    else
    {
      this.scaleSize.x = 1f + this.scale;
      if (GUIManager.Instance.IsArabic)
        this.scaleSize.x *= -1f;
      this.scaleSize.y = 1f + this.scale;
      this.scaleSize.z = 1f + this.scale;
    }
    ((Transform) rectTransform).localScale = this.scaleSize;
    if ((double) this.scale < 2.0)
      return;
    this.time[1] = 0.0f;
    this.m_State_Lv = UIPetLevelUp.ELvState.None;
  }

  public void UpdateLvValue()
  {
    RectTransform rectTransform = ((Graphic) this.m_EffectTextLV).rectTransform;
    if (this.m_State_Exp == UIPetLevelUp.EExpState.None)
      return;
    this.time[2] += Time.deltaTime;
    this.pos = Vector2.Lerp(this.BEGIN, this.END, this.time[2] / 0.5f);
    rectTransform.anchoredPosition = this.pos;
    if ((double) this.pos.y < (double) this.END.y)
      return;
    this.time[2] = 0.0f;
    this.m_State_Exp = UIPetLevelUp.EExpState.None;
  }

  public void UpdateExpValue()
  {
    RectTransform rectTransform = ((Graphic) this.m_EffectTextExp).rectTransform;
    if (this.m_State_Exp2 == UIPetLevelUp.EExpState.None)
      return;
    this.time[3] += Time.deltaTime;
    this.pos = Vector2.Lerp(this.EXP_BEGIN, this.EXP_END, this.time[3] / 0.5f);
    rectTransform.anchoredPosition = this.pos;
    if ((double) this.pos.y < (double) this.END.y)
      return;
    this.time[3] = 0.0f;
    this.m_State_Exp2 = UIPetLevelUp.EExpState.None;
  }

  public void UpdateExpText(float rate)
  {
    if ((int) this.m_BeginLv < (this.m_UIType != UIPetLevelUp.EUIType.PetLvUp ? 10 : 60))
    {
      this.m_Str[3].ClearString();
      this.m_Str[3].FloatToFormat(rate * 100f, 2);
      if (GUIManager.Instance.IsArabic)
        this.m_Str[3].AppendFormat("%{0}");
      else
        this.m_Str[3].AppendFormat("{0}%");
      this.m_ExpText.text = this.m_Str[3].ToString();
    }
    else
      this.m_ExpText.text = DataManager.Instance.mStringTable.GetStringByID(1507U);
    this.m_ExpText.SetAllDirty();
    this.m_ExpText.cachedTextGenerator.Invalidate();
  }

  public void CheckSliderSprite()
  {
    if ((int) this.m_BeginLv < (this.m_UIType != UIPetLevelUp.EUIType.PetLvUp ? 10 : 60) || !((Object) this.m_Slider != (Object) null))
      return;
    this.size.x = 234f;
    ((Graphic) this.m_Slider).rectTransform.sizeDelta = this.size;
    this.m_Slider.sprite = this.m_Sp.GetSprite(1);
  }

  public void Spawn()
  {
    this.m_Str = new CString[5];
    for (int index = 0; index < this.m_Str.Length; ++index)
      this.m_Str[index] = StringManager.Instance.SpawnString();
  }

  public void DeSpawn()
  {
    if (this.m_Str == null)
      return;
    for (int index = 0; index < this.m_Str.Length; ++index)
    {
      if (this.m_Str[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.m_Str[index]);
        this.m_Str[index] = (CString) null;
      }
    }
  }

  public void SetLvText()
  {
    if (this.m_UIType == UIPetLevelUp.EUIType.PetLvUp)
    {
      if (!((Object) this.m_PetLv != (Object) null))
        return;
      this.m_Str[0].ClearString();
      this.m_Str[0].IntToFormat((long) this.m_BeginLv);
      this.m_Str[0].AppendFormat("Lv.{0}");
      this.m_PetLv.text = this.m_Str[0].ToString();
      this.m_PetLv.SetAllDirty();
      this.m_PetLv.cachedTextGenerator.Invalidate();
    }
    else
    {
      if (!((Object) this.m_SkillName != (Object) null))
        return;
      PetSkillTbl recordByKey = PetManager.Instance.PetSkillTable.GetRecordByKey(this.m_PetSkillID);
      this.m_Str[2].ClearString();
      this.m_Str[2].IntToFormat((long) this.m_BeginLv);
      this.m_Str[2].StringToFormat(DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.Name));
      this.m_Str[2].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(268U));
      this.m_SkillName.text = this.m_Str[2].ToString();
      this.m_SkillName.SetAllDirty();
      this.m_SkillName.cachedTextGenerator.Invalidate();
    }
  }

  private void SetEffectLvPos()
  {
    ((Component) this.m_EffectTextLV).gameObject.SetActive(true);
    ((Graphic) this.m_EffectTextLV).rectTransform.anchoredPosition = this.BEGIN;
  }

  public void SetEffectExpText(byte lv)
  {
    PetManager instance = PetManager.Instance;
    PetData petData = instance.FindPetData(this.m_PetID);
    if (petData == null)
      return;
    PetTbl recordByKey = instance.PetTable.GetRecordByKey(petData.ID);
    instance.PetExpTable.GetRecordByKey((ushort) lv);
    uint x = this.m_UIType != UIPetLevelUp.EUIType.PetLvUp ? instance.GetPetSkillMaxExp(this.m_PetID, this.m_Skillidx) : instance.GetNeedExp(lv, recordByKey.Rare);
    if (!((Object) this.m_EffectTextLV != (Object) null) || !((Object) this.m_EffectTextExp != (Object) null))
      return;
    this.m_Str[4].ClearString();
    if ((int) lv == (int) instance.m_PetBeginLv)
      this.m_Str[4].IntToFormat((long) (x - instance.m_BeginExp));
    else if ((int) lv == (int) instance.m_PetEndLv)
      this.m_Str[4].IntToFormat((long) instance.m_EndExp);
    else
      this.m_Str[4].IntToFormat((long) x);
    this.m_Str[4].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(55U));
    this.m_EffectTextExp.text = this.m_Str[4].ToString();
    this.m_EffectTextExp.SetAllDirty();
    this.m_EffectTextExp.cachedTextGenerator.Invalidate();
  }

  public void RefreshFontTexture()
  {
    if ((Object) this.m_TitleName != (Object) null && ((Behaviour) this.m_TitleName).enabled)
    {
      ((Behaviour) this.m_TitleName).enabled = false;
      ((Behaviour) this.m_TitleName).enabled = true;
    }
    if ((Object) this.m_PetName != (Object) null && ((Behaviour) this.m_PetName).enabled)
    {
      ((Behaviour) this.m_PetName).enabled = false;
      ((Behaviour) this.m_PetName).enabled = true;
    }
    if ((Object) this.m_SkillName != (Object) null && ((Behaviour) this.m_SkillName).enabled)
    {
      ((Behaviour) this.m_SkillName).enabled = false;
      ((Behaviour) this.m_SkillName).enabled = true;
    }
    if ((Object) this.m_PetLv != (Object) null && ((Behaviour) this.m_PetLv).enabled)
    {
      ((Behaviour) this.m_PetLv).enabled = false;
      ((Behaviour) this.m_PetLv).enabled = true;
    }
    if ((Object) this.m_ExpText != (Object) null && ((Behaviour) this.m_ExpText).enabled)
    {
      ((Behaviour) this.m_ExpText).enabled = false;
      ((Behaviour) this.m_ExpText).enabled = true;
    }
    if ((Object) this.m_EffectTextLV != (Object) null && ((Behaviour) this.m_EffectTextLV).enabled)
    {
      ((Behaviour) this.m_EffectTextLV).enabled = false;
      ((Behaviour) this.m_EffectTextLV).enabled = true;
    }
    if (!((Object) this.m_EffectTextExp != (Object) null) || !((Behaviour) this.m_EffectTextExp).enabled)
      return;
    ((Behaviour) this.m_EffectTextExp).enabled = false;
    ((Behaviour) this.m_EffectTextExp).enabled = true;
  }

  public void InitUI(ushort petID)
  {
    this.m_Sp = this.transform.gameObject.GetComponent<UISpritesArray>();
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      Transform child = this.transform.GetChild(0);
      ((RectTransform) child).offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) child).offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    this.transform.GetChild(0).GetComponent<UIButton>();
    Transform child1 = this.transform.GetChild(1);
    this.m_BlueBg = child1.GetChild(0).GetComponent<Image>();
    this.m_RedBg = child1.GetChild(1).GetComponent<Image>();
    this.m_TitleName = child1.GetChild(4).GetComponent<UIText>();
    this.m_TitleName.font = GUIManager.Instance.GetTTFFont();
    this.m_SliderTf = this.transform.GetChild(3).GetChild(0);
    this.m_Slider = this.m_SliderTf.GetChild(0).GetComponent<Image>();
    this.m_ExpText = this.m_SliderTf.GetChild(1).GetComponent<UIText>();
    this.m_ExpText.font = GUIManager.Instance.GetTTFFont();
    Transform child2 = this.transform.GetChild(4);
    this.m_PetName = child2.GetChild(0).GetComponent<UIText>();
    this.m_PetName.font = GUIManager.Instance.GetTTFFont();
    this.m_PetName.text = PetManager.Instance.GetPetNameByID(petID);
    this.m_SkillName = child2.GetChild(1).GetComponent<UIText>();
    this.m_SkillName.font = GUIManager.Instance.GetTTFFont();
    Transform child3 = this.transform.GetChild(5);
    this.m_LvPanel = child3.GetChild(0);
    this.m_PetLv = this.m_LvPanel.GetChild(0).GetComponent<UIText>();
    this.m_PetLv.font = GUIManager.Instance.GetTTFFont();
    this.m_SkillPanel = child3.GetChild(1);
    this.m_Skill = this.m_SkillPanel.GetChild(0).GetComponent<Image>();
    this.m_SkillFrame = this.m_SkillPanel.GetChild(0).GetChild(0).GetComponent<Image>();
    Transform child4 = this.transform.GetChild(6);
    this.m_EffectTextTf = child4;
    this.m_EffectTextTf.gameObject.SetActive(true);
    this.m_EffectTextLV = child4.GetChild(1).GetComponent<UIText>();
    this.m_EffectTextLV.font = GUIManager.Instance.GetTTFFont();
    this.m_EffectTextLV.text = DataManager.Instance.mStringTable.GetStringByID(1555U);
    ((Component) this.m_EffectTextLV).gameObject.SetActive(false);
    this.m_EffectTextExp = child4.GetChild(0).GetComponent<UIText>();
    this.m_EffectTextExp.font = GUIManager.Instance.GetTTFFont();
    ((Component) this.m_EffectTextExp).gameObject.SetActive(false);
    UIButton component = this.transform.GetChild(9).GetComponent<UIButton>();
    component.m_Handler = (IUIButtonClickHandler) this;
    component.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component.image).material = this.door.LoadMaterial();
    if (this.m_UIType == UIPetLevelUp.EUIType.SkillLvUp)
    {
      this.BEGIN = new Vector2(-1f, -222f);
      this.END = new Vector2(-1f, -45f);
      this.EXP_BEGIN = new Vector2(-1f, -252f);
      this.EXP_END = new Vector2(-1f, -80f);
      this.m_TitleName.text = DataManager.Instance.mStringTable.GetStringByID(17096U);
      this.m_SkillPanel.gameObject.SetActive(true);
      this.m_LvPanel.gameObject.SetActive(false);
      ((Component) this.m_PetName).gameObject.SetActive(false);
      ((Component) this.m_Skill).gameObject.SetActive(true);
      ((Component) this.m_SkillName).gameObject.SetActive(true);
      ((Behaviour) this.m_BlueBg).enabled = true;
      ((Behaviour) this.m_RedBg).enabled = false;
      this.m_SliderTf.GetComponent<RectTransform>().anchoredPosition = new Vector2(-1f, -225.5f);
    }
    else
    {
      this.BEGIN = new Vector2(-1f, -222f);
      this.END = new Vector2(-1f, -122f);
      this.EXP_BEGIN = new Vector2(-1f, -252f);
      this.EXP_END = new Vector2(-1f, -152f);
      this.m_TitleName.text = DataManager.Instance.mStringTable.GetStringByID(17094U);
      this.m_SkillPanel.gameObject.SetActive(false);
      this.m_LvPanel.gameObject.SetActive(true);
      ((Component) this.m_PetName).gameObject.SetActive(true);
      ((Component) this.m_Skill).gameObject.SetActive(false);
      ((Component) this.m_SkillName).gameObject.SetActive(false);
      ((Behaviour) this.m_BlueBg).enabled = false;
      ((Behaviour) this.m_RedBg).enabled = true;
    }
  }

  public void SetExpValue()
  {
    if (this.m_PetID == (ushort) 0)
      return;
    this.m_BeginLv = PetManager.Instance.m_PetBeginLv;
    this.m_EndLv = PetManager.Instance.m_PetEndLv;
    uint beginExp = PetManager.Instance.m_BeginExp;
    uint endExp = PetManager.Instance.m_EndExp;
    this.m_PetSkillID = PetManager.Instance.m_PetSkillLvUpID;
    PetTbl recordByKey1 = PetManager.Instance.PetTable.GetRecordByKey(this.m_PetID);
    uint num1;
    uint num2;
    if (this.m_UIType == UIPetLevelUp.EUIType.PetLvUp)
    {
      num1 = PetManager.Instance.GetNeedExp(this.m_BeginLv, recordByKey1.Rare);
      num2 = PetManager.Instance.GetNeedExp(this.m_EndLv, recordByKey1.Rare);
    }
    else
    {
      num1 = PetManager.Instance.GetPetSkillMaxExpByID(this.m_PetSkillID, this.m_BeginLv);
      num2 = PetManager.Instance.GetPetSkillMaxExpByID(this.m_PetSkillID, this.m_EndLv);
      for (byte index = 0; (int) index < recordByKey1.PetSkill.Length; ++index)
      {
        if ((int) recordByKey1.PetSkill[(int) index] == (int) this.m_PetSkillID)
          this.m_Skillidx = index;
      }
    }
    if (num1 > 0U && num2 > 0U)
    {
      this.m_BeginExpRate = (float) beginExp / (float) num1;
      this.m_EndExpRate = (float) endExp / (float) num2;
    }
    else
    {
      this.m_BeginExpRate = 0.0f;
      this.m_EndExpRate = 0.0f;
    }
    uint x = 0;
    for (byte beginLv = this.m_BeginLv; (int) beginLv <= (int) this.m_EndLv; ++beginLv)
    {
      if ((int) beginLv == (int) this.m_BeginLv)
      {
        uint num3 = this.m_UIType != UIPetLevelUp.EUIType.PetLvUp ? PetManager.Instance.GetPetSkillMaxExpByID(this.m_PetSkillID, beginLv) : PetManager.Instance.GetNeedExp(beginLv, recordByKey1.Rare);
        x += num3 - beginExp;
      }
      else if ((int) beginLv == (int) this.m_EndLv)
        x += endExp;
      else if (this.m_UIType == UIPetLevelUp.EUIType.PetLvUp)
        x += PetManager.Instance.GetNeedExp(beginLv, recordByKey1.Rare);
      else
        x += PetManager.Instance.GetPetSkillMaxExpByID(this.m_PetSkillID, beginLv);
    }
    if ((Object) this.m_EffectTextLV != (Object) null && (Object) this.m_EffectTextExp != (Object) null)
    {
      ((Graphic) this.m_EffectTextLV).rectTransform.anchoredPosition = this.BEGIN;
      ((Graphic) this.m_EffectTextExp).rectTransform.anchoredPosition = this.EXP_BEGIN;
      ((Component) this.m_EffectTextExp).gameObject.SetActive(true);
      this.m_Str[4].ClearString();
      this.m_Str[4].IntToFormat((long) x, bNumber: true);
      this.m_Str[4].AppendFormat(DataManager.Instance.mStringTable.GetStringByID(55U));
      this.m_EffectTextExp.text = this.m_Str[4].ToString();
      this.m_EffectTextExp.SetAllDirty();
      this.m_EffectTextExp.cachedTextGenerator.Invalidate();
    }
    PetSkillTbl recordByKey2 = PetManager.Instance.PetSkillTable.GetRecordByKey(this.m_PetSkillID);
    CString SpriteName = StringManager.Instance.StaticString1024();
    SpriteName.Append('s');
    SpriteName.IntToFormat((long) recordByKey2.Icon, 5);
    SpriteName.AppendFormat("{0}");
    this.m_Skill.sprite = GUIManager.Instance.LoadSkillSprite(SpriteName);
    ((MaskableGraphic) this.m_Skill).material = GUIManager.Instance.GetSkillMaterial();
    this.m_SkillFrame.sprite = GUIManager.Instance.LoadFrameSprite("sk");
    ((MaskableGraphic) this.m_SkillFrame).material = GUIManager.Instance.GetFrameMaterial();
    this.m_State = UIPetLevelUp.ExpState.Begin;
    this.m_State_Lv = UIPetLevelUp.ELvState.None;
    this.m_State_Exp2 = UIPetLevelUp.EExpState.Move;
  }

  private enum ExpState
  {
    Begin,
    Middle,
    Last,
    End,
  }

  private enum EExpState
  {
    None,
    Move,
  }

  private enum ELvState
  {
    None,
    Scale,
  }

  private enum ECstr
  {
    LvText,
    Name,
    SkillName,
    ExpText,
    EffectExpText,
    Max,
  }

  private enum EUIType
  {
    PetLvUp,
    SkillLvUp,
  }

  private enum EUIPetLevelUp
  {
    BgBtn,
    BgPanel,
    PetModel,
    ExpSlider,
    Name,
    Icon,
    EffectText,
    Pointlight_1,
    Pointlight_2,
    ExitBtn,
  }
}
