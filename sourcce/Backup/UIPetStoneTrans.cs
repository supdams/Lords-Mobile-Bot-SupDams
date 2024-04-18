// Decompiled with JetBrains decompiler
// Type: UIPetStoneTrans
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIPetStoneTrans : 
  GUIWindow,
  UILoadImageHander,
  IUIButtonClickHandler,
  IUICalculatorHandler,
  IUIUnitRSliderHandler
{
  private Transform m_transform;
  private DataManager DM;
  private GUIManager GM;
  private Door m_door;
  private ushort StoneID;
  private ushort TransID;
  private ushort UseCount;
  private ushort StoneCount;
  private ushort multiple = 1;
  private int GetCount;
  private UIText TitleText;
  private UIText LCountText;
  private UIText RCountText;
  private UIText SelectCountText;
  private UIText CountText;
  private UIText InfoText;
  private UIText Btntext;
  private UIText LHaveCountText;
  private UIText RHaveCountText;
  private CString LCountStr;
  private CString RCountStr;
  private CString CountStr;
  private CString ResourcesStr;
  private CString MessageStr;
  private CString LHaveCountStr;
  private CString RHaveCountStr;
  private Transform SliderT;
  private Transform LeftBtnT;
  private Transform RightBtnT;
  private UnitResourcesSlider m_Slider;
  private Equip tmpEquip;

  public Door door
  {
    get
    {
      if ((Object) this.m_door == (Object) null)
        this.m_door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      return this.m_door;
    }
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.m_transform = this.transform;
    Font ttfFont = this.GM.GetTTFFont();
    this.StoneID = (ushort) arg1;
    this.tmpEquip = this.DM.EquipTable.GetRecordByKey(this.StoneID);
    this.TransID = this.tmpEquip.SyntheticParts[1].SyntheticItem;
    this.multiple = this.tmpEquip.SyntheticParts[2].SyntheticItem <= (ushort) 0 ? (ushort) 1 : this.tmpEquip.SyntheticParts[2].SyntheticItem;
    this.m_transform.GetChild(17).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(17).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (this.GM.bOpenOnIPhoneX)
    {
      ((Behaviour) this.m_transform.GetChild(17).GetComponent<CustomImage>()).enabled = false;
      ((RectTransform) this.m_transform).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.m_transform).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0.0f);
    }
    this.m_transform.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(16).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.SliderT = this.m_transform.GetChild(15);
    this.LeftBtnT = this.m_transform.GetChild(5);
    this.GM.InitianHeroItemImg(this.LeftBtnT, eHeroOrItem.Item, this.StoneID, (byte) 0, (byte) 0, bShowText: false);
    this.RightBtnT = this.m_transform.GetChild(9);
    this.GM.InitianHeroItemImg(this.RightBtnT, eHeroOrItem.Item, this.TransID, (byte) 0, (byte) 0, bShowText: false);
    this.LHaveCountText = this.m_transform.GetChild(6).GetComponent<UIText>();
    this.LHaveCountText.font = ttfFont;
    this.LHaveCountStr = StringManager.Instance.SpawnString();
    this.LCountText = this.m_transform.GetChild(7).GetComponent<UIText>();
    this.LCountText.font = ttfFont;
    this.LCountStr = StringManager.Instance.SpawnString();
    this.RHaveCountText = this.m_transform.GetChild(10).GetComponent<UIText>();
    this.RHaveCountText.font = ttfFont;
    this.RHaveCountStr = StringManager.Instance.SpawnString();
    this.RCountText = this.m_transform.GetChild(11).GetComponent<UIText>();
    this.RCountText.font = ttfFont;
    this.RCountStr = StringManager.Instance.SpawnString();
    if (this.GM.IsArabic)
      this.m_transform.GetChild(13).gameObject.AddComponent<ArabicItemTextureRot>();
    this.CountText = this.m_transform.GetChild(14).GetComponent<UIText>();
    this.CountText.font = ttfFont;
    this.CountStr = StringManager.Instance.SpawnString();
    this.TitleText = this.m_transform.GetChild(2).GetComponent<UIText>();
    this.TitleText.font = ttfFont;
    this.TitleText.text = this.DM.mStringTable.GetStringByID(14584U);
    this.SelectCountText = this.m_transform.GetChild(12).GetComponent<UIText>();
    this.SelectCountText.font = ttfFont;
    this.SelectCountText.text = this.DM.mStringTable.GetStringByID(283U);
    this.InfoText = this.m_transform.GetChild(4).GetComponent<UIText>();
    this.InfoText.font = ttfFont;
    this.InfoText.text = this.DM.mStringTable.GetStringByID(14585U);
    ((Graphic) this.InfoText).color = Color.white;
    this.Btntext = this.m_transform.GetChild(16).GetChild(0).GetComponent<UIText>();
    this.Btntext.font = ttfFont;
    this.Btntext.text = this.DM.mStringTable.GetStringByID(14586U);
    this.ResourcesStr = StringManager.Instance.SpawnString();
    this.SliderT = this.m_transform.GetChild(15);
    this.GM.InitUnitResourcesSlider(this.SliderT, eUnitSlider.AutoUse, 0U, (uint) this.DM.GetCurItemQuantity(this.StoneID, (byte) 0), 0.7f);
    this.m_Slider = this.SliderT.GetComponent<UnitResourcesSlider>();
    this.m_Slider.m_Handler = (IUIUnitRSliderHandler) this;
    this.m_Slider.BtnInputText.m_Handler = (IUIButtonClickHandler) this;
    this.m_Slider.BtnInputText.m_BtnID1 = 2;
    this.m_Slider.m_inputText.fontSize = 24;
    this.GM.SetUnitResourcesSliderSize(this.SliderT, eUnitSliderSize.Input, -42.4f, 32.8f, 84f, 33f, 0.0f, 0.0f);
    this.SetHaveCount();
    this.SetStoneCount();
    ushort num = this.StoneCount <= (ushort) 0 ? (ushort) 0 : (ushort) 1;
    this.SetUseCount(num);
    this.SetSlider(num);
    this.GM.UpdateUI(EGUIWindow.UI_Pet, 8);
  }

  public override void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.LCountStr);
    StringManager.Instance.DeSpawnString(this.RCountStr);
    StringManager.Instance.DeSpawnString(this.CountStr);
    StringManager.Instance.DeSpawnString(this.ResourcesStr);
    StringManager.Instance.DeSpawnString(this.MessageStr);
    StringManager.Instance.DeSpawnString(this.LHaveCountStr);
    StringManager.Instance.DeSpawnString(this.RHaveCountStr);
    this.GM.UpdateUI(EGUIWindow.UI_Pet, 7);
  }

  public void OnCalculatorVauleChang(byte mkind, long mValue, UnitResourcesSlider URS)
  {
    URS.m_slider.value = (double) mValue;
    URS.SliderValueChange();
  }

  public void OnVauleChang(UnitResourcesSlider sender)
  {
    StringManager.IntToStr(this.ResourcesStr, sender.Value, bNumber: true);
    sender.m_inputText.text = this.ResourcesStr.ToString();
    sender.m_inputText.SetAllDirty();
    sender.m_inputText.cachedTextGenerator.Invalidate();
    this.SetUseCount((ushort) sender.Value);
  }

  public void OnTextChang(UnitResourcesSlider sender)
  {
    StringManager.IntToStr(this.ResourcesStr, sender.Value, bNumber: true);
    this.m_Slider.m_inputText.text = this.ResourcesStr.ToString();
    this.m_Slider.m_inputText.SetAllDirty();
    this.m_Slider.m_inputText.cachedTextGenerator.Invalidate();
    this.SetUseCount((ushort) sender.Value);
  }

  private void SetHaveCount()
  {
    this.LHaveCountStr.Length = 0;
    this.LHaveCountStr.IntToFormat((long) this.DM.GetCurItemQuantity(this.StoneID, (byte) 0), bNumber: true);
    this.LHaveCountStr.AppendFormat(this.DM.mStringTable.GetStringByID(79U));
    this.LHaveCountText.text = this.LHaveCountStr.ToString();
    this.LHaveCountText.SetAllDirty();
    this.LHaveCountText.cachedTextGenerator.Invalidate();
    this.RHaveCountStr.Length = 0;
    this.RHaveCountStr.IntToFormat((long) this.DM.GetCurItemQuantity(this.TransID, (byte) 0), bNumber: true);
    this.RHaveCountStr.AppendFormat(this.DM.mStringTable.GetStringByID(79U));
    this.RHaveCountText.text = this.RHaveCountStr.ToString();
    this.RHaveCountText.SetAllDirty();
    this.RHaveCountText.cachedTextGenerator.Invalidate();
  }

  private void SetUseCount(ushort tmpCount)
  {
    this.UseCount = tmpCount;
    this.LCountStr.Length = 0;
    this.LCountStr.IntToFormat((long) this.UseCount, bNumber: true);
    if (this.GM.IsArabic)
      this.LCountStr.AppendFormat("{0}x");
    else
      this.LCountStr.AppendFormat("x{0}");
    this.LCountText.text = this.LCountStr.ToString();
    this.LCountText.SetAllDirty();
    this.LCountText.cachedTextGenerator.Invalidate();
    this.GetCount = (int) this.UseCount * (int) this.multiple;
    this.RCountStr.Length = 0;
    this.RCountStr.IntToFormat((long) this.GetCount, bNumber: true);
    if (this.GM.IsArabic)
      this.RCountStr.AppendFormat("{0}x");
    else
      this.RCountStr.AppendFormat("x{0}");
    this.RCountText.text = this.RCountStr.ToString();
    this.RCountText.SetAllDirty();
    this.RCountText.cachedTextGenerator.Invalidate();
    this.SetBtnColor();
  }

  private void SetStoneCount()
  {
    this.StoneCount = this.DM.GetCurItemQuantity(this.StoneID, (byte) 0);
    if ((Object) this.CountText != (Object) null)
    {
      StringManager.IntToStr(this.CountStr, (long) this.StoneCount, bNumber: true);
      this.CountText.text = this.CountStr.ToString();
      this.CountText.SetAllDirty();
      this.CountText.cachedTextGenerator.Invalidate();
    }
    if ((Object) this.m_Slider != (Object) null)
    {
      this.m_Slider.m_slider.maxValue = (double) this.StoneCount;
      this.m_Slider.MaxValue = (long) this.StoneCount;
    }
    this.SetBtnColor();
  }

  private void SetSlider(ushort SetCount)
  {
    if (!((Object) this.m_Slider != (Object) null))
      return;
    this.m_Slider.m_slider.value = (double) SetCount;
    this.m_Slider.Value = (long) SetCount;
    this.ResourcesStr.Length = 0;
    StringManager.IntToStr(this.ResourcesStr, (long) SetCount, bNumber: true);
    this.m_Slider.m_inputText.text = this.ResourcesStr.ToString();
    this.m_Slider.m_inputText.SetAllDirty();
    this.m_Slider.m_inputText.cachedTextGenerator.Invalidate();
  }

  private void SetBtnColor()
  {
    if ((Object) this.Btntext == (Object) null)
      return;
    if (this.StoneCount == (ushort) 0 || this.UseCount == (ushort) 0)
      ((Graphic) this.Btntext).color = Color.red;
    else
      ((Graphic) this.Btntext).color = Color.white;
  }

  private void RefreshItemCount()
  {
    this.SetHaveCount();
    this.SetStoneCount();
    if ((int) this.UseCount <= (int) this.StoneCount)
      return;
    this.SetUseCount(this.StoneCount);
    this.SetSlider(this.StoneCount);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        this.RefreshItemCount();
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Item)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          if ((Object) this.TitleText != (Object) null && ((Behaviour) this.TitleText).enabled)
          {
            ((Behaviour) this.TitleText).enabled = false;
            ((Behaviour) this.TitleText).enabled = true;
          }
          if ((Object) this.LCountText != (Object) null && ((Behaviour) this.LCountText).enabled)
          {
            ((Behaviour) this.LCountText).enabled = false;
            ((Behaviour) this.LCountText).enabled = true;
          }
          if ((Object) this.RCountText != (Object) null && ((Behaviour) this.RCountText).enabled)
          {
            ((Behaviour) this.RCountText).enabled = false;
            ((Behaviour) this.RCountText).enabled = true;
          }
          if ((Object) this.SelectCountText != (Object) null && ((Behaviour) this.SelectCountText).enabled)
          {
            ((Behaviour) this.SelectCountText).enabled = false;
            ((Behaviour) this.SelectCountText).enabled = true;
          }
          if ((Object) this.CountText != (Object) null && ((Behaviour) this.CountText).enabled)
          {
            ((Behaviour) this.CountText).enabled = false;
            ((Behaviour) this.CountText).enabled = true;
          }
          if ((Object) this.InfoText != (Object) null && ((Behaviour) this.InfoText).enabled)
          {
            ((Behaviour) this.InfoText).enabled = false;
            ((Behaviour) this.InfoText).enabled = true;
          }
          if ((Object) this.Btntext != (Object) null && ((Behaviour) this.Btntext).enabled)
          {
            ((Behaviour) this.Btntext).enabled = false;
            ((Behaviour) this.Btntext).enabled = true;
          }
          if ((Object) this.LHaveCountText != (Object) null && ((Behaviour) this.LHaveCountText).enabled)
          {
            ((Behaviour) this.LHaveCountText).enabled = false;
            ((Behaviour) this.LHaveCountText).enabled = true;
          }
          if (!((Object) this.RHaveCountText != (Object) null) || !((Behaviour) this.RHaveCountText).enabled)
            break;
          ((Behaviour) this.RHaveCountText).enabled = false;
          ((Behaviour) this.RHaveCountText).enabled = true;
          break;
        }
        goto case NetworkNews.Login;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 1)
      return;
    this.SendTrans();
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      if (sender.m_BtnID2 == 1)
      {
        this.GM.CloseMenu(EGUIWindow.UI_PetStoneTrans);
      }
      else
      {
        if (sender.m_BtnID2 != 2)
          return;
        if (this.StoneCount == (ushort) 0)
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(14568U), (ushort) byte.MaxValue);
        else if (this.UseCount == (ushort) 0)
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(5703U), (ushort) byte.MaxValue);
        else if (this.GM.bCheckStoneTrans)
        {
          if (this.MessageStr == null)
            this.MessageStr = StringManager.Instance.SpawnString(300);
          this.MessageStr.Length = 0;
          CString cstring = StringManager.Instance.StaticString1024();
          UIItemInfo.SetNameProperties((UIText) null, (UIText) null, cstring, (CString) null, ref this.tmpEquip);
          this.MessageStr.StringToFormat(cstring);
          this.MessageStr.IntToFormat((long) this.UseCount);
          this.MessageStr.AppendFormat(this.DM.mStringTable.GetStringByID(14587U));
          this.GM.OpenCheckStoneTrans(this.MessageStr);
        }
        else
          this.SendTrans();
      }
    }
    else
    {
      if (sender.m_BtnID1 != 2)
        return;
      this.GM.m_UICalculator.m_CalculatorHandler = (IUICalculatorHandler) this;
      this.GM.m_UICalculator.OpenCalculator(this.m_Slider.MaxValue, this.m_Slider.Value, 260f, 100f, this.m_Slider, 0L);
    }
  }

  private void SendTrans()
  {
    if (this.UseCount == (ushort) 0)
      return;
    if ((int) this.DM.GetCurItemQuantity(this.TransID, (byte) 0) + this.GetCount >= (int) ushort.MaxValue)
    {
      this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(887U), (ushort) byte.MaxValue);
    }
    else
    {
      this.DM.UseItem(this.StoneID, this.UseCount, (ushort) 0, (ushort) 0, (ushort) 0, 0U, string.Empty);
      this.GM.CloseMenu(EGUIWindow.UI_PetStoneTrans);
    }
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    if (!(bool) (Object) this.door)
      return;
    img.sprite = this.door.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = this.door.LoadMaterial();
  }
}
