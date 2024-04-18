// Decompiled with JetBrains decompiler
// Type: UICastleStrengthen
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

#nullable disable
public class UICastleStrengthen : 
  UICastleSkinWindow,
  UILoadImageHander,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUIUnitRSliderHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private Font TTFont;
  private Door door;
  private UISpritesArray SArray;
  private Transform GameT;
  private Transform Tf1;
  private Transform Tf2;
  private Transform Tmp;
  private Transform Tmp1;
  private Transform Tmp2;
  private Transform Tf_Checkbox;
  private UnitResourcesSlider m_UnitRS;
  private UIButton btn_CastleHint;
  private UIButton btn_Strengthen;
  private UIButton btn_Check;
  private UIButton btn_Check_Ok;
  private UIButton btn_Check_Cancal;
  private Image Img_CastleBG;
  private Image Img_CastleMax;
  private Image Img_BtnLock;
  private Image Img_SkinUse;
  private Image[] Img_CastleHint = new Image[2];
  private Image[] Img_Strengthen = new Image[5];
  private CustomImage CImg_Check;
  private UIText text_Name;
  private UIText text_Strengthen;
  private UIText text_ItemQty;
  private UIText[] text_Item = new UIText[2];
  private UIText[] text_Effect = new UIText[2];
  private UIText[] text_Value = new UIText[2];
  private UIText[] text_Slider = new UIText[2];
  private UIText[] text_ShowEffect = new UIText[2];
  private UIText text_Check_title;
  private UIText text_Check_Info;
  private UIText text_Check_btn_Ok;
  private UIText text_Check_btn_Cancel;
  private UIText text_Check;
  private UIText text_CastleMaxRank;
  private UIHIBtn btn_Item;
  private CString Cstr;
  private CString Cstr_Item;
  private CString[] Cstr_Value = new CString[2];
  private CString[] Cstr_Silder = new CString[3];
  private CString[] Cstr_ShowEffect = new CString[2];
  private CString Cstr_CheckInfo;
  private bool bItemQty = true;
  private ushort mItemMax;
  private uint mMaxValue = 100;
  private ushort mNeedItemQty;
  private ushort mItemQty;
  private ushort mStrengthenrate;
  private GameObject mParticleEffect;
  private GameObject mParticleEffect2;
  private GameObject mParticleEffect3;
  private GameObject mParticleEffect4;
  public int mShowEffectNum;
  public float mShowEffectTime;
  private bool bCheck;
  private CastleSkinTbl tmpCa;
  private byte tmpCaE;
  private CastleEnhanceTbl tmpCaED;
  private Equip tmpEquip;
  private float Img_HintTime;
  private byte mSpeciallyEffect;
  private Vector2 mV2Start = Vector2.zero;
  public float mShowEffectTime2;
  public float mShowEffectTime3;
  public float mShowEffectTime4;
  private bool bshowText;

  public override void OnOpen(int arg1, int arg2)
  {
    // ISSUE: unable to decompile the method.
  }

  public override void Initial()
  {
    this.ListSortType = CastleSkin._SortType.Own;
    base.Initial();
  }

  public void SetCastleData(bool bOpen = true, bool bZero = false)
  {
    if ((int) this.GUIM.BuildingData.CastleID == (int) this.SelectedCastleID)
      ((Component) this.Img_SkinUse).gameObject.SetActive(true);
    else
      ((Component) this.Img_SkinUse).gameObject.SetActive(false);
    this.tmpCa = this.GUIM.BuildingData.castleSkin.CastleSkinTable.GetRecordByKey(this.SelectedCastleID);
    this.tmpCaE = this.GUIM.BuildingData.castleSkin.GetCastleEnhance((byte) this.tmpCa.ID);
    this.Img_CastleBG.sprite = this.GUIM.BuildingData.castleSkin.GetUISprite(this.tmpCa.Graphic, this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level);
    ((MaskableGraphic) this.Img_CastleBG).material = this.GUIM.BuildingData.castleSkin.GetUIMaterial(this.tmpCa.Graphic, this.GUIM.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level);
    this.Img_CastleBG.SetNativeSize();
    ((Transform) ((Graphic) this.Img_CastleBG).rectTransform).localScale = new Vector3((float) this.tmpCa.EnhancePercentage / 100f, (float) this.tmpCa.EnhancePercentage / 100f, (float) this.tmpCa.EnhancePercentage / 100f);
    this.SetChangCastleRank((int) this.tmpCaE);
    this.text_Name.text = this.DM.mStringTable.GetStringByID((uint) this.tmpCa.Name);
    this.text_Name.cachedTextGeneratorForLayout.Invalidate();
    float num = this.text_Name.preferredWidth;
    if ((double) num > 280.0)
      num = 280f;
    ((Graphic) this.text_Name).rectTransform.sizeDelta = new Vector2(num + 1f, ((Graphic) this.text_Name).rectTransform.sizeDelta.y);
    RectTransform component = ((Component) this.btn_CastleHint).GetComponent<RectTransform>();
    component.sizeDelta = (double) num + 68.0 <= 183.0 ? new Vector2(250f, component.sizeDelta.y) : new Vector2((float) (250.0 + ((double) num + 1.0 - 183.0)) + ((Graphic) this.Img_CastleHint[0]).rectTransform.sizeDelta.x, component.sizeDelta.y);
    ((Graphic) this.Img_CastleHint[0]).rectTransform.anchoredPosition = new Vector2((float) (-215.0 - (double) num / 2.0 - (double) ((Graphic) this.Img_CastleHint[0]).rectTransform.sizeDelta.x / 2.0), ((Graphic) this.Img_CastleHint[0]).rectTransform.anchoredPosition.y);
    this.text_Effect[0].text = this.DM.mStringTable.GetStringByID((uint) this.DM.EffectData.GetRecordByKey(this.tmpCa.Effect[0]).InfoID);
    this.text_Effect[1].text = this.DM.mStringTable.GetStringByID((uint) this.DM.EffectData.GetRecordByKey(this.tmpCa.Effect[1]).InfoID);
    this.UpdataCastle(bOpen, bZero);
  }

  public void UpdataCastle(bool bOpen = true, bool bZero = false)
  {
    this.Cstr_Value[0].ClearString();
    this.Cstr_Value[1].ClearString();
    CString cstring1 = StringManager.Instance.StaticString1024();
    CString cstring2 = StringManager.Instance.StaticString1024();
    cstring1.ClearString();
    cstring2.ClearString();
    this.mItemMax = (ushort) 0;
    this.tmpCaE = this.GUIM.BuildingData.castleSkin.GetCastleEnhance((byte) this.tmpCa.ID);
    this.tmpCaED = this.GUIM.BuildingData.castleSkin.GetCastleEnhanceData((byte) this.tmpCa.ID, this.tmpCaE);
    if (this.tmpCaE < (byte) 5)
    {
      CastleEnhanceTbl castleEnhanceData = this.GUIM.BuildingData.castleSkin.GetCastleEnhanceData((byte) this.tmpCa.ID, (byte) ((uint) this.tmpCaE + 1U));
      this.mItemMax = castleEnhanceData.EnhanceTotalNum;
      GameConstants.GetEffectValue(cstring1, this.tmpCa.Effect[0], (uint) this.tmpCaED.Value[0], (byte) 12, 0.0f);
      GameConstants.GetEffectValue(cstring2, this.tmpCa.Effect[0], (uint) castleEnhanceData.Value[0], (byte) 12, 0.0f);
      this.Cstr_Value[0].StringToFormat(cstring1);
      this.Cstr_Value[0].StringToFormat(cstring2);
      this.Cstr_Value[0].AppendFormat(this.DM.mStringTable.GetStringByID(14574U));
      cstring1.ClearString();
      cstring2.ClearString();
      GameConstants.GetEffectValue(cstring1, this.tmpCa.Effect[1], (uint) this.tmpCaED.Value[1], (byte) 12, 0.0f);
      GameConstants.GetEffectValue(cstring2, this.tmpCa.Effect[1], (uint) castleEnhanceData.Value[1], (byte) 12, 0.0f);
      this.Cstr_Value[1].StringToFormat(cstring1);
      this.Cstr_Value[1].StringToFormat(cstring2);
      this.Cstr_Value[1].AppendFormat(this.DM.mStringTable.GetStringByID(14574U));
    }
    else
    {
      GameConstants.GetEffectValue(this.Cstr_Value[0], this.tmpCa.Effect[0], (uint) this.tmpCaED.Value[0], (byte) 12, 0.0f);
      GameConstants.GetEffectValue(this.Cstr_Value[1], this.tmpCa.Effect[1], (uint) this.tmpCaED.Value[1], (byte) 12, 0.0f);
    }
    this.text_Value[0].text = this.Cstr_Value[0].ToString();
    this.text_Value[0].SetAllDirty();
    this.text_Value[0].cachedTextGenerator.Invalidate();
    this.text_Value[1].text = this.Cstr_Value[1].ToString();
    this.text_Value[1].SetAllDirty();
    this.text_Value[1].cachedTextGenerator.Invalidate();
    if (bOpen)
      return;
    if (bZero)
      this.mNeedItemQty = (ushort) 0;
    this.mMaxValue = 100U;
    if ((uint) this.mItemMax < this.mMaxValue)
    {
      this.bItemQty = true;
      this.mMaxValue = (uint) this.mItemMax;
    }
    else
    {
      this.bItemQty = false;
      this.mMaxValue = 100U;
    }
    this.m_UnitRS.m_slider.value = (double) this.mNeedItemQty;
    this.m_UnitRS.MaxValue = (long) this.mMaxValue;
    this.m_UnitRS.m_slider.maxValue = (double) this.mMaxValue;
    this.Cstr_Silder[0].ClearString();
    this.Cstr_Silder[0].IntToFormat((long) this.mNeedItemQty, bNumber: true);
    this.Cstr_Silder[0].IntToFormat((long) this.mItemMax, bNumber: true);
    if (this.mNeedItemQty == (ushort) 0)
    {
      if (this.GUIM.IsArabic)
        this.Cstr_Silder[0].AppendFormat("{1} / {0}");
      else
        this.Cstr_Silder[0].AppendFormat("{0} / {1}");
    }
    else if (this.GUIM.IsArabic)
      this.Cstr_Silder[0].AppendFormat("{1} / <color=#00FF00>{0}</color>");
    else
      this.Cstr_Silder[0].AppendFormat("<color=#00FF00>{0}</color> / {1}");
    this.text_Slider[0].text = this.Cstr_Silder[0].ToString();
    this.text_Slider[0].SetAllDirty();
    this.text_Slider[0].cachedTextGenerator.Invalidate();
    this.Cstr_Silder[1].ClearString();
    this.Cstr_Silder[2].ClearString();
    this.Cstr_Silder[1].IntToFormat((long) this.mStrengthenrate, bNumber: true);
    this.Cstr_Silder[1].AppendFormat("{0}%");
    this.Cstr_Silder[2].StringToFormat(this.Cstr_Silder[1]);
    this.Cstr_Silder[2].AppendFormat(this.DM.mStringTable.GetStringByID(14569U));
    this.text_Slider[1].text = this.Cstr_Silder[2].ToString();
    this.text_Slider[1].SetAllDirty();
    this.text_Slider[1].cachedTextGenerator.Invalidate();
    this.CheckCastleRank();
  }

  public void CheckCastleRank()
  {
    if (this.tmpCaE < (byte) 5)
    {
      this.Tf1.gameObject.SetActive(true);
      this.Tf2.gameObject.SetActive(false);
    }
    else
    {
      this.Tf1.gameObject.SetActive(false);
      this.Tf2.gameObject.SetActive(true);
    }
  }

  public void SetChangCastleRank(int mRank)
  {
    for (int index = 0; index < mRank; ++index)
      this.Img_Strengthen[index].sprite = this.SArray.m_Sprites[0];
    for (int index = mRank; index < 5; ++index)
      this.Img_Strengthen[index].sprite = this.SArray.m_Sprites[1];
  }

  public void AddShowEffect()
  {
    if (this.mSpeciallyEffect != (byte) 1)
      return;
    this.Cstr_ShowEffect[0].ClearString();
    this.Cstr_ShowEffect[1].ClearString();
    this.tmpCaE = this.GUIM.BuildingData.castleSkin.GetCastleEnhance((byte) this.tmpCa.ID);
    this.tmpCaED = this.GUIM.BuildingData.castleSkin.GetCastleEnhanceData((byte) this.tmpCa.ID, this.tmpCaE);
    CastleEnhanceTbl castleEnhanceData = this.GUIM.BuildingData.castleSkin.GetCastleEnhanceData((byte) this.tmpCa.ID, (byte) ((uint) this.tmpCaE - 1U));
    GameConstants.GetEffectValue(this.Cstr_ShowEffect[0], this.tmpCa.Effect[0], (uint) this.tmpCaED.Value[0] - (uint) castleEnhanceData.Value[0], (byte) 13, 0.0f);
    GameConstants.GetEffectValue(this.Cstr_ShowEffect[1], this.tmpCa.Effect[1], (uint) this.tmpCaED.Value[1] - (uint) castleEnhanceData.Value[1], (byte) 13, 0.0f);
    this.text_ShowEffect[0].text = this.Cstr_ShowEffect[0].ToString();
    this.text_ShowEffect[0].SetAllDirty();
    this.text_ShowEffect[0].cachedTextGenerator.Invalidate();
    this.text_ShowEffect[0].cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_ShowEffect[0].preferredWidth > (double) ((Graphic) this.text_ShowEffect[0]).rectTransform.sizeDelta.x)
      ((Graphic) this.text_ShowEffect[0]).rectTransform.sizeDelta = new Vector2(this.text_ShowEffect[0].preferredWidth + 1f, ((Graphic) this.text_ShowEffect[0]).rectTransform.sizeDelta.y);
    this.text_ShowEffect[1].text = this.Cstr_ShowEffect[1].ToString();
    this.text_ShowEffect[1].SetAllDirty();
    this.text_ShowEffect[1].cachedTextGenerator.Invalidate();
    this.text_ShowEffect[1].cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_ShowEffect[1].preferredWidth > (double) ((Graphic) this.text_ShowEffect[1]).rectTransform.sizeDelta.x)
      ((Graphic) this.text_ShowEffect[1]).rectTransform.sizeDelta = new Vector2(this.text_ShowEffect[1].preferredWidth + 1f, ((Graphic) this.text_ShowEffect[1]).rectTransform.sizeDelta.y);
    if (this.GameT.gameObject.activeSelf)
    {
      float num = 0.0f;
      if (this.GUIM.bOpenOnIPhoneX)
        num = this.GUIM.IPhoneX_DeltaX;
      this.mV2Start = new Vector2(this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2f, this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2f);
      this.GUIM.m_SpeciallyEffect.UI_bezieEnd = new Vector2((float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 - 296.0) + (float) (((int) this.tmpCaE - 1) * 42) - num, (float) (-((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0) + 134.0));
      this.GUIM.m_SpeciallyEffect.AddIconShow(false, this.mV2Start, SpeciallyEffect_Kind.CastleStrengrten, ItemID: (ushort) 0, EndTime: 1f);
    }
    else
    {
      this.mShowEffectNum += 2;
      this.mShowEffectTime3 = 0.7f;
      this.GUIM.pDVMgr.ShowCastleStrengthenText((ushort) 14564, false);
    }
  }

  public void ClearShowEffect()
  {
    this.mShowEffectTime2 = 0.0f;
    if ((double) this.mShowEffectTime3 > 0.0)
      GUIManager.Instance.pDVMgr.EndMoveBossText();
    this.mShowEffectTime3 = 0.0f;
    this.mShowEffectNum = 0;
    for (int index = 0; index < 2; ++index)
    {
      this.text_ShowEffect[index].text = string.Empty;
      this.text_ShowEffect[index].SetAllDirty();
      this.text_ShowEffect[index].cachedTextGenerator.Invalidate();
      ((Component) this.text_ShowEffect[index]).gameObject.SetActive(false);
      ((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition.x, -112f);
      ((Graphic) this.text_ShowEffect[index]).color = new Color(0.4f, 0.83f, 0.4f, 1f);
    }
  }

  public override void OnClose()
  {
    base.OnClose();
    if ((Object) this.Tf_Checkbox != (Object) null)
      Object.Destroy((Object) this.Tf_Checkbox.gameObject);
    if (this.Cstr != null)
      StringManager.Instance.DeSpawnString(this.Cstr);
    if (this.Cstr_Item != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Item);
    if (this.Cstr_CheckInfo != null)
      StringManager.Instance.DeSpawnString(this.Cstr_CheckInfo);
    for (int index = 0; index < 2; ++index)
    {
      if (this.Cstr_Value[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Value[index]);
      if (this.Cstr_ShowEffect[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ShowEffect[index]);
    }
    for (int index = 0; index < 2; ++index)
    {
      if (this.Cstr_Silder[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Silder[index]);
    }
    if ((Object) this.mParticleEffect != (Object) null)
    {
      ParticleManager.Instance.DeSpawn(this.mParticleEffect);
      this.mParticleEffect = (GameObject) null;
    }
    if ((Object) this.mParticleEffect2 != (Object) null && this.mParticleEffect2.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
    {
      this.mParticleEffect2.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
      this.mParticleEffect2.gameObject.SetActive(false);
    }
    if ((Object) this.mParticleEffect3 != (Object) null && this.mParticleEffect3.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
    {
      this.mParticleEffect3.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
      this.mParticleEffect3.gameObject.SetActive(false);
    }
    if ((Object) this.mParticleEffect4 != (Object) null && this.mParticleEffect4.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
    {
      this.mParticleEffect4.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
      this.mParticleEffect4.gameObject.SetActive(false);
    }
    if ((double) this.mShowEffectTime3 <= 0.0)
      return;
    GUIManager.Instance.pDVMgr.EndMoveBossText();
  }

  public override void OnInfoClick(UIButton sender)
  {
    this.Cstr.ClearString();
    this.Cstr.Append(this.DM.mStringTable.GetStringByID(14570U));
    this.Cstr.Append("\n");
    this.Cstr.Append(this.DM.mStringTable.GetStringByID(14571U));
    this.Cstr.Append("\n");
    this.Cstr.Append(this.DM.mStringTable.GetStringByID(14572U));
    this.Cstr.Append("\n");
    this.Cstr.Append(this.DM.mStringTable.GetStringByID(14573U));
    this.Cstr.Append("\n");
    this.Cstr.Append(this.DM.mStringTable.GetStringByID(14575U));
    this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(14561U), this.Cstr.ToString(), bInfo: true, BackExit: true);
  }

  public override void ClassticalCastleChanged()
  {
    this.Img_CastleBG.sprite = this.GUIM.BuildingData.castleSkin.GetUISprite((byte) 0, this.CastleLv);
    ((MaskableGraphic) this.Img_CastleBG).material = this.GUIM.BuildingData.castleSkin.GetUIMaterial((byte) 0, this.CastleLv);
  }

  public override void ReOnOpen()
  {
    base.ReOnOpen();
    this.SetCastleData(false);
    if ((Object) this.Img_BtnLock != (Object) null && ((Component) this.Img_BtnLock).gameObject.activeSelf)
      ((Component) this.Img_BtnLock).gameObject.SetActive(false);
    base.UpdateUI(0, 0);
  }

  public void OnVauleChang(UnitResourcesSlider sender)
  {
    this.Cstr_Silder[0].ClearString();
    this.Cstr_Silder[1].ClearString();
    this.Cstr_Silder[2].ClearString();
    this.mNeedItemQty = (ushort) 0;
    this.mStrengthenrate = (ushort) 0;
    if (!this.bItemQty)
    {
      double num1 = (double) sender.Value * ((double) this.mItemMax / (double) this.mMaxValue);
      ushort num2 = (ushort) num1;
      this.mNeedItemQty = num1 <= (double) num2 ? num2 : (ushort) ((uint) num2 + 1U);
      this.mStrengthenrate = (ushort) sender.Value;
    }
    else
    {
      this.mNeedItemQty = (ushort) sender.Value;
      this.mStrengthenrate = (ushort) ((double) sender.Value / (double) this.mItemMax * 100.0);
    }
    this.Cstr_Silder[0].IntToFormat((long) this.mNeedItemQty, bNumber: true);
    this.Cstr_Silder[0].IntToFormat((long) this.mItemMax, bNumber: true);
    if ((int) this.mNeedItemQty > (int) this.mItemQty)
    {
      if (this.GUIM.IsArabic)
        this.Cstr_Silder[0].AppendFormat("{1} / <color=#FF0000>{0}</color>");
      else
        this.Cstr_Silder[0].AppendFormat("<color=#FF0000>{0}</color> / {1}");
      this.btn_Strengthen.ForTextChange(e_BtnType.e_ChangeText);
    }
    else
    {
      if (this.mNeedItemQty == (ushort) 0)
      {
        if (this.GUIM.IsArabic)
          this.Cstr_Silder[0].AppendFormat("{1} / {0}");
        else
          this.Cstr_Silder[0].AppendFormat("{0} / {1}");
      }
      else if (this.GUIM.IsArabic)
        this.Cstr_Silder[0].AppendFormat("{1} / <color=#00FF00>{0}</color>");
      else
        this.Cstr_Silder[0].AppendFormat("<color=#00FF00>{0}</color> / {1}");
      this.btn_Strengthen.ForTextChange(e_BtnType.e_Normal);
    }
    this.text_Slider[0].text = this.Cstr_Silder[0].ToString();
    this.text_Slider[0].SetAllDirty();
    this.text_Slider[0].cachedTextGenerator.Invalidate();
    this.Cstr_Silder[1].IntToFormat((long) this.mStrengthenrate, bNumber: true);
    this.Cstr_Silder[1].AppendFormat("{0}%");
    this.Cstr_Silder[2].StringToFormat(this.Cstr_Silder[1]);
    this.Cstr_Silder[2].AppendFormat(this.DM.mStringTable.GetStringByID(14569U));
    this.text_Slider[1].text = this.Cstr_Silder[2].ToString();
    this.text_Slider[1].SetAllDirty();
    this.text_Slider[1].cachedTextGenerator.Invalidate();
  }

  public void OnTextChang(UnitResourcesSlider sender)
  {
  }

  public override void OnButtonClick(UIButton sender)
  {
    // ISSUE: unable to decompile the method.
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    sender.GetTipPosition(this.Hint.ThisTransform);
    this.Hint.Show(this.SelectedCastleID);
  }

  public void OnButtonUp(UIButtonHint sender) => this.Hint.Hide();

  public void OnHIButtonClick(UIHIBtn sender)
  {
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    img.sprite = GUIManager.Instance.LoadFrameSprite(ImageName);
    ((MaskableGraphic) img).material = GUIManager.Instance.GetFrameMaterial();
  }

  public override bool OnBackButtonClick()
  {
    if (!this.Tf_Checkbox.gameObject.activeSelf)
      return false;
    this.Tf_Checkbox.gameObject.SetActive(false);
    this.bCheck = false;
    ((Component) this.CImg_Check).gameObject.SetActive(this.bCheck);
    return true;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    base.UpdateNetwork(meg);
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.SetCastleData(false);
        if ((Object) this.Img_BtnLock != (Object) null && (double) this.mShowEffectTime3 == 0.0 && !this.bshowText && this.mShowEffectNum == 0)
          ((Component) this.Img_BtnLock).gameObject.SetActive(false);
        base.UpdateUI(0, 0);
        break;
      case NetworkNews.Refresh_Item:
        this.mItemQty = this.DM.GetCurItemQuantity((ushort) 1326, (byte) 1);
        this.Cstr_Item.ClearString();
        this.Cstr_Item.IntToFormat((long) this.mItemQty, bNumber: true);
        this.Cstr_Item.AppendFormat(this.DM.mStringTable.GetStringByID(79U));
        this.text_Item[1].text = this.Cstr_Item.ToString();
        this.text_Item[1].SetAllDirty();
        this.text_Item[1].cachedTextGenerator.Invalidate();
        this.Cstr_Silder[0].ClearString();
        this.Cstr_Silder[0].IntToFormat((long) this.mNeedItemQty, bNumber: true);
        this.Cstr_Silder[0].IntToFormat((long) this.mItemMax, bNumber: true);
        if ((int) this.mNeedItemQty > (int) this.mItemQty)
        {
          if (this.GUIM.IsArabic)
            this.Cstr_Silder[0].AppendFormat("{1} / <color=#FF0000>{0}</color>");
          else
            this.Cstr_Silder[0].AppendFormat("<color=#FF0000>{0}</color> / {1}");
        }
        else if (this.mNeedItemQty == (ushort) 0)
        {
          if (this.GUIM.IsArabic)
            this.Cstr_Silder[0].AppendFormat("{1} / {0}");
          else
            this.Cstr_Silder[0].AppendFormat("{0} / {1}");
        }
        else if (this.GUIM.IsArabic)
          this.Cstr_Silder[0].AppendFormat("{1} / <color=#00FF00>{0}</color>");
        else
          this.Cstr_Silder[0].AppendFormat("<color=#00FF00>{0}</color> / {1}");
        this.text_Slider[0].text = this.Cstr_Silder[0].ToString();
        this.text_Slider[0].SetAllDirty();
        this.text_Slider[0].cachedTextGenerator.Invalidate();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public override void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    if (!((Object) this.Img_BtnLock != (Object) null) || ((Component) this.Img_BtnLock).gameObject.activeSelf)
      return;
    base.ButtonOnClick(gameObject, dataIndex, panelId);
    this.mStrengthenrate = (ushort) 0;
    this.SetCastleData(false, true);
    if (!((Object) this.Img_BtnLock != (Object) null) || !((Component) this.Img_BtnLock).gameObject.activeSelf)
      return;
    ((Component) this.Img_BtnLock).gameObject.SetActive(false);
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Name != (Object) null && ((Behaviour) this.text_Name).enabled)
    {
      ((Behaviour) this.text_Name).enabled = false;
      ((Behaviour) this.text_Name).enabled = true;
    }
    if ((Object) this.text_Strengthen != (Object) null && ((Behaviour) this.text_Strengthen).enabled)
    {
      ((Behaviour) this.text_Strengthen).enabled = false;
      ((Behaviour) this.text_Strengthen).enabled = true;
    }
    if ((Object) this.text_ItemQty != (Object) null && ((Behaviour) this.text_ItemQty).enabled)
    {
      ((Behaviour) this.text_ItemQty).enabled = false;
      ((Behaviour) this.text_ItemQty).enabled = true;
    }
    if ((Object) this.text_Check_title != (Object) null && ((Behaviour) this.text_Check_title).enabled)
    {
      ((Behaviour) this.text_Check_title).enabled = false;
      ((Behaviour) this.text_Check_title).enabled = true;
    }
    if ((Object) this.text_Check_Info != (Object) null && ((Behaviour) this.text_Check_Info).enabled)
    {
      ((Behaviour) this.text_Check_Info).enabled = false;
      ((Behaviour) this.text_Check_Info).enabled = true;
    }
    if ((Object) this.text_Check_btn_Ok != (Object) null && ((Behaviour) this.text_Check_btn_Ok).enabled)
    {
      ((Behaviour) this.text_Check_btn_Ok).enabled = false;
      ((Behaviour) this.text_Check_btn_Ok).enabled = true;
    }
    if ((Object) this.text_Check_btn_Cancel != (Object) null && ((Behaviour) this.text_Check_btn_Cancel).enabled)
    {
      ((Behaviour) this.text_Check_btn_Cancel).enabled = false;
      ((Behaviour) this.text_Check_btn_Cancel).enabled = true;
    }
    if ((Object) this.text_Check != (Object) null && ((Behaviour) this.text_Check).enabled)
    {
      ((Behaviour) this.text_Check).enabled = false;
      ((Behaviour) this.text_Check).enabled = true;
    }
    if ((Object) this.text_CastleMaxRank != (Object) null && ((Behaviour) this.text_CastleMaxRank).enabled)
    {
      ((Behaviour) this.text_CastleMaxRank).enabled = false;
      ((Behaviour) this.text_CastleMaxRank).enabled = true;
    }
    if ((Object) this.btn_Item != (Object) null && ((Behaviour) this.btn_Item).enabled)
      this.btn_Item.Refresh_FontTexture();
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_Item[index] != (Object) null && ((Behaviour) this.text_Item[index]).enabled)
      {
        ((Behaviour) this.text_Item[index]).enabled = false;
        ((Behaviour) this.text_Item[index]).enabled = true;
      }
      if ((Object) this.text_Effect[index] != (Object) null && ((Behaviour) this.text_Effect[index]).enabled)
      {
        ((Behaviour) this.text_Effect[index]).enabled = false;
        ((Behaviour) this.text_Effect[index]).enabled = true;
      }
      if ((Object) this.text_Value[index] != (Object) null && ((Behaviour) this.text_Value[index]).enabled)
      {
        ((Behaviour) this.text_Value[index]).enabled = false;
        ((Behaviour) this.text_Value[index]).enabled = true;
      }
      if ((Object) this.text_Slider[index] != (Object) null && ((Behaviour) this.text_Slider[index]).enabled)
      {
        ((Behaviour) this.text_Slider[index]).enabled = false;
        ((Behaviour) this.text_Slider[index]).enabled = true;
      }
      if ((Object) this.text_ShowEffect[index] != (Object) null && ((Behaviour) this.text_ShowEffect[index]).enabled)
      {
        ((Behaviour) this.text_ShowEffect[index]).enabled = false;
        ((Behaviour) this.text_ShowEffect[index]).enabled = true;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.mParticleEffect4 = ParticleManager.Instance.Spawn((ushort) 427, this.GameT, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
        this.GUIM.SetLayer(this.mParticleEffect4, 5);
        this.mParticleEffect4.transform.localPosition = new Vector3(0.0f, 0.0f, -800f);
        this.mParticleEffect4.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        this.bshowText = true;
        this.mShowEffectTime4 = 0.5f;
        this.mShowEffectTime = 0.0f;
        this.mShowEffectNum = 0;
        this.mSpeciallyEffect = (byte) 1;
        this.ClearShowEffect();
        this.GUIM.m_SpeciallyEffect.ClearAllEffect();
        ((Component) this.Img_BtnLock).gameObject.SetActive(true);
        AudioManager.Instance.PlayMP3SFX((ushort) 41037);
        break;
      case 2:
        if (this.mSpeciallyEffect != (byte) 1)
          break;
        this.mParticleEffect2 = ParticleManager.Instance.Spawn((ushort) 372, ((Component) this.Img_CastleBG).transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
        this.GUIM.SetLayer(this.mParticleEffect2, 5);
        this.mParticleEffect2.transform.localPosition = new Vector3(0.0f, 0.0f, -800f);
        this.mParticleEffect2.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        this.mShowEffectTime3 = 0.7f;
        this.mShowEffectNum += 2;
        this.GUIM.pDVMgr.ShowCastleStrengthenText((ushort) 14564, false);
        this.mStrengthenrate = (ushort) 0;
        this.UpdataCastle(false, true);
        this.SetChangCastleRank((int) this.tmpCaE);
        base.UpdateUI(arg1, arg2);
        AudioManager.Instance.PlayUISFX(UIKind.CastleStrength);
        break;
      case 3:
        this.mParticleEffect4 = ParticleManager.Instance.Spawn((ushort) 427, this.GameT, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
        this.GUIM.SetLayer(this.mParticleEffect4, 5);
        this.mParticleEffect4.transform.localPosition = new Vector3(0.0f, 0.0f, -800f);
        this.mParticleEffect4.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        this.bshowText = true;
        this.mShowEffectTime4 = 0.5f;
        this.mShowEffectTime = 0.0f;
        this.mShowEffectNum = 0;
        this.mSpeciallyEffect = (byte) 2;
        this.ClearShowEffect();
        this.GUIM.m_SpeciallyEffect.ClearAllEffect();
        ((Component) this.Img_BtnLock).gameObject.SetActive(true);
        AudioManager.Instance.PlayMP3SFX((ushort) 41038);
        break;
      case 4:
        this.SetCastleData(false);
        if ((Object) this.Img_BtnLock != (Object) null && (double) this.mShowEffectTime3 == 0.0 && !this.bshowText && this.mShowEffectNum == 0)
          ((Component) this.Img_BtnLock).gameObject.SetActive(false);
        base.UpdateUI(0, 0);
        break;
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    base.UpdateTime(bOnSecond);
    if (bOnSecond)
      return;
    if ((Object) this.Img_CastleHint[1] != (Object) null && ((UIBehaviour) this.Img_CastleHint[1]).IsActive())
    {
      this.Img_HintTime += Time.smoothDeltaTime;
      if ((double) this.Img_HintTime >= 0.0)
      {
        if ((double) this.Img_HintTime >= 2.0)
          this.Img_HintTime = 0.0f;
        ((Graphic) this.Img_CastleHint[1]).color = new Color(1f, 1f, 1f, (double) this.Img_HintTime <= 1.0 ? this.Img_HintTime : 2f - this.Img_HintTime);
      }
    }
    if ((Object) this.Tf2 != (Object) null && this.Tf2.gameObject.activeSelf)
      ((Component) this.Img_CastleMax).transform.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
    if ((double) this.mShowEffectTime4 > 0.0)
    {
      this.mShowEffectTime4 -= Time.smoothDeltaTime;
      if ((double) this.mShowEffectTime4 < 0.0)
      {
        if ((Object) this.mParticleEffect == (Object) null)
        {
          this.mParticleEffect = ParticleManager.Instance.Spawn((ushort) 423, this.GameT, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
          this.GUIM.SetLayer(this.mParticleEffect, 5);
          this.mParticleEffect.transform.localPosition = new Vector3(0.0f, 0.0f, -800f);
          this.mParticleEffect.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
        }
        else
          this.mParticleEffect.gameObject.SetActive(true);
      }
    }
    if (this.bshowText)
    {
      this.mShowEffectTime += Time.smoothDeltaTime;
      if ((double) this.mShowEffectTime >= 1.5 && this.mShowEffectNum == 0)
      {
        this.AddShowEffect();
        this.bshowText = false;
        if ((Object) this.mParticleEffect != (Object) null && this.mParticleEffect.gameObject.activeSelf)
          this.mParticleEffect.gameObject.SetActive(false);
        if (this.mSpeciallyEffect == (byte) 1)
          this.mParticleEffect3 = ParticleManager.Instance.Spawn((ushort) 424, this.GameT, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
        else if (this.mSpeciallyEffect == (byte) 2)
        {
          this.mParticleEffect3 = ParticleManager.Instance.Spawn((ushort) 425, this.GameT, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
          this.GUIM.pDVMgr.ShowCastleStrengthenText((ushort) 14565, true);
          this.mShowEffectTime3 = 0.7f;
        }
        this.GUIM.SetLayer(this.mParticleEffect3, 5);
        this.mParticleEffect3.transform.localPosition = new Vector3(0.0f, 0.0f, -800f);
        this.mParticleEffect3.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
      }
    }
    if (this.mShowEffectNum > 0)
    {
      this.mShowEffectTime2 += Time.smoothDeltaTime;
      for (int index = 0; index < 2; ++index)
      {
        if ((Object) this.text_ShowEffect[index] != (Object) null)
        {
          if (((UIBehaviour) this.text_ShowEffect[index]).IsActive())
          {
            if ((double) ((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition.y >= 70.0 && (double) ((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition.y < 100.0)
              ((Graphic) this.text_ShowEffect[index]).color = new Color(0.4f, 0.83f, 0.4f, (float) ((100.0 - (double) ((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition.y) / 30.0));
            else if ((double) ((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition.y >= 100.0)
            {
              ((Component) this.text_ShowEffect[index]).gameObject.SetActive(false);
              --this.mShowEffectNum;
            }
            ((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition.x, (float) (((double) this.mShowEffectTime2 - (double) index * 0.20000000298023224) * 200.0 - 112.0));
          }
          else if ((double) this.mShowEffectTime2 >= (double) index * 0.20000000298023224 && (double) ((Graphic) this.text_ShowEffect[index]).rectTransform.anchoredPosition.y == -112.0)
            ((Component) this.text_ShowEffect[index]).gameObject.SetActive(true);
        }
      }
    }
    if ((double) this.mShowEffectTime3 <= 0.0)
      return;
    this.mShowEffectTime3 -= Time.smoothDeltaTime;
    if ((double) this.mShowEffectTime3 >= 0.0)
      return;
    if (this.mSpeciallyEffect == (byte) 1)
      GUIManager.Instance.pDVMgr.BeginMoveBossText();
    else if (this.mSpeciallyEffect == (byte) 2)
      GUIManager.Instance.pDVMgr.BeginMoveBossText(300f);
    if ((Object) this.Img_BtnLock != (Object) null)
      ((Component) this.Img_BtnLock).gameObject.SetActive(false);
    this.mSpeciallyEffect = (byte) 0;
  }
}
