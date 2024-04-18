// Decompiled with JetBrains decompiler
// Type: UIMerchantman
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIMerchantman : 
  GUIWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private const int PCount = 5;
  private const int ResourceCount = 5;
  private DataManager DM;
  private GUIManager GUIM;
  private MerchantmanManager MM;
  private Transform GameT;
  private Door door;
  private Font TTFont;
  private UIButton btn_EXIT;
  private UIButton btn_I;
  private UIButton btn_CDTime;
  private UIButton[] btn_Lock = new UIButton[5];
  private UIButton[] btn_Exchange = new UIButton[5];
  private UIButton[] btn_Star_Hint = new UIButton[5];
  private UIButton[] btn_Res = new UIButton[5];
  private UIHIBtn[] btn_Item = new UIHIBtn[5];
  private Image Img_Hint;
  private Image[] Img_ItemBG = new Image[5];
  private Image[] Img_Exchange_Res = new Image[5];
  private Image[] Img_Resources = new Image[5];
  private Image[] Img_Exchange = new Image[5];
  private Image[][] Img_Exchange_Star = new Image[5][];
  private Image[] Img_Star_Hint = new Image[5];
  private UIText text_Title;
  private UIText text_Time;
  private UIText text_Hint;
  private UIText[] text_Resources = new UIText[5];
  private UIText[] text_ItemNum = new UIText[5];
  private UIText[] text_ItemName = new UIText[5];
  private UIText[] text_ItemResourcesValue = new UIText[5];
  private UIText[] text_ItemExchange = new UIText[5];
  private UIText[] text_ItemExchangeValue = new UIText[5];
  private UIText[] text_Item = new UIText[5];
  private UIText[] text_Star_Hint = new UIText[5];
  private CString Cstr_Time;
  private CString[] Cstr_Resources = new CString[5];
  private CString[] Cstr_ItemNum = new CString[5];
  private CString[] Cstr_ItemExchangeValue = new CString[5];
  private CString[] Cstr_ItemResourcesValue = new CString[5];
  private Text extra_Price;
  private Text extra_text_ItemExchangeValue;
  private CString extra_PriceStr;
  private GameObject[] PGO = new GameObject[5];
  private bool NeedUpDate;
  private int tmpT = 45;
  private byte tmpLock;
  private byte mExchange;
  private Equip tmpEq;
  private TimerTypeMission Data;
  private UISpritesArray SArray;

  public override void OnOpen(int arg1, int arg2)
  {
    this.Cstr_Time = StringManager.Instance.SpawnString();
    for (int index = 0; index < 5; ++index)
      this.Cstr_Resources[index] = StringManager.Instance.SpawnString();
    for (int index = 0; index < 5; ++index)
    {
      this.Cstr_ItemNum[index] = StringManager.Instance.SpawnString();
      this.Cstr_ItemExchangeValue[index] = StringManager.Instance.SpawnString();
      this.Cstr_ItemResourcesValue[index] = StringManager.Instance.SpawnString();
    }
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.MM = MerchantmanManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    Material material = this.door.LoadMaterial();
    Transform child1 = this.GameT.GetChild(0);
    Image[] imageArray = new Image[5];
    for (int index = 0; index < 5; ++index)
    {
      Transform child2 = child1.GetChild(0).GetChild(1 + index);
      this.btn_Res[index] = child2.GetComponent<UIButton>();
      this.btn_Res[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Res[index].m_BtnID1 = 5;
      this.btn_Res[index].m_BtnID2 = index;
      this.btn_Res[index].m_EffectType = e_EffectType.e_Scale;
      this.btn_Res[index].transition = (Selectable.Transition) 0;
      Transform child3 = child1.GetChild(0).GetChild(1 + index).GetChild(0);
      imageArray[index] = child3.GetComponent<Image>();
      imageArray[index].sprite = this.SArray.m_Sprites[index];
      imageArray[index].SetNativeSize();
      Transform child4 = child1.GetChild(0).GetChild(1 + index).GetChild(1);
      this.text_Resources[index] = child4.GetComponent<UIText>();
      this.text_Resources[index].font = this.TTFont;
      this.Cstr_Resources[index].ClearString();
      StringManager.IntToStr(this.Cstr_Resources[index], (long) this.DM.Resource[index].Stock, bNumber: true);
      this.text_Resources[index].text = this.Cstr_Resources[index].ToString();
    }
    this.btn_I = child1.GetChild(0).GetChild(6).GetComponent<UIButton>();
    if (this.GUIM.IsArabic)
      ((Component) this.btn_I).gameObject.AddComponent<ArabicItemTextureRot>();
    this.btn_I.m_Handler = (IUIButtonClickHandler) this;
    this.btn_I.m_BtnID1 = 1;
    this.btn_I.m_EffectType = e_EffectType.e_Scale;
    this.btn_I.transition = (Selectable.Transition) 0;
    this.text_Title = child1.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.text_Title.text = this.DM.mStringTable.GetStringByID(1479U);
    this.Img_Hint = child1.GetChild(8).GetComponent<Image>();
    this.text_Hint = child1.GetChild(8).GetChild(0).GetComponent<UIText>();
    this.text_Hint.font = this.TTFont;
    this.text_Hint.text = this.DM.mStringTable.GetStringByID(1480U);
    this.text_Hint.cachedTextGeneratorForLayout.Invalidate();
    if ((double) this.text_Hint.preferredHeight > (double) ((Graphic) this.text_Hint).rectTransform.sizeDelta.y)
      ((Graphic) this.Img_Hint).rectTransform.sizeDelta = new Vector2(((Graphic) this.Img_Hint).rectTransform.sizeDelta.x, this.text_Hint.preferredHeight + 10f);
    this.btn_CDTime = child1.GetChild(2).GetChild(0).GetComponent<UIButton>();
    this.btn_CDTime.m_Handler = (IUIButtonClickHandler) this;
    this.btn_CDTime.m_BtnID1 = 2;
    UIButtonHint uiButtonHint1 = ((Component) this.btn_CDTime).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    uiButtonHint1.ControlFadeOut = ((Component) this.Img_Hint).gameObject;
    this.text_Time = child1.GetChild(2).GetChild(2).GetComponent<UIText>();
    this.text_Time.font = this.TTFont;
    this.Data = DataManager.MissionDataManager.GetTimerMissionData(_eMissionType.Affair);
    this.Cstr_Time.ClearString();
    this.Cstr_Time.Append(DataManager.MissionDataManager.FormatMissionTime((uint) Math.Max(this.Data.ResetTime - DataManager.Instance.ServerTime, 0L)));
    this.text_Time.text = this.Cstr_Time.ToString();
    for (int index1 = 0; index1 < 4; ++index1)
    {
      this.Img_Exchange_Star[index1] = new Image[3];
      Transform child5 = child1.GetChild(3 + index1);
      this.PGO[index1] = child5.gameObject;
      this.Img_ItemBG[index1] = child5.GetChild(0).GetComponent<Image>();
      this.btn_Lock[index1] = child5.GetChild(0).GetChild(0).GetComponent<UIButton>();
      this.btn_Lock[index1].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Lock[index1].m_BtnID1 = 3;
      this.btn_Lock[index1].m_BtnID2 = index1;
      this.btn_Lock[index1].m_EffectType = e_EffectType.e_Scale;
      this.btn_Lock[index1].transition = (Selectable.Transition) 0;
      if (((int) this.MM.TradeLocks >> index1 & 1) == 0)
      {
        this.Img_ItemBG[index1].sprite = this.SArray.m_Sprites[5];
        this.btn_Lock[index1].image.sprite = this.SArray.m_Sprites[7];
      }
      else
      {
        this.Img_ItemBG[index1].sprite = this.SArray.m_Sprites[6];
        this.btn_Lock[index1].image.sprite = this.SArray.m_Sprites[8];
      }
      this.btn_Item[index1] = child5.GetChild(1).GetComponent<UIHIBtn>();
      this.GUIM.InitianHeroItemImg(((Component) this.btn_Item[index1]).transform, eHeroOrItem.Item, this.MM.MerchantmanData[index1].itemID, (byte) 0, (byte) 0, (int) this.MM.MerchantmanData[index1].itemCount);
      this.btn_Exchange[index1] = child5.GetChild(2).GetComponent<UIButton>();
      this.btn_Exchange[index1].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Exchange[index1].m_BtnID1 = 4;
      this.btn_Exchange[index1].m_BtnID2 = index1;
      this.btn_Exchange[index1].m_EffectType = e_EffectType.e_Scale;
      this.btn_Exchange[index1].transition = (Selectable.Transition) 0;
      this.Img_Exchange_Res[index1] = child5.GetChild(2).GetChild(0).GetComponent<Image>();
      this.Img_Exchange_Res[index1].sprite = this.SArray.m_Sprites[(int) this.MM.MerchantmanData[index1].ResourceKind];
      this.Img_Exchange_Res[index1].SetNativeSize();
      this.text_ItemExchangeValue[index1] = child5.GetChild(2).GetChild(1).GetComponent<UIText>();
      this.text_ItemExchangeValue[index1].font = this.TTFont;
      this.Cstr_ItemExchangeValue[index1].ClearString();
      StringManager.IntToStr(this.Cstr_ItemExchangeValue[index1], (long) this.MM.MerchantmanData[index1].ResourceCount, bNumber: true);
      this.text_ItemExchangeValue[index1].text = this.Cstr_ItemExchangeValue[index1].ToString();
      this.text_ItemExchange[index1] = child5.GetChild(2).GetChild(2).GetComponent<UIText>();
      this.text_ItemExchange[index1].font = this.TTFont;
      this.text_ItemExchange[index1].text = this.DM.mStringTable.GetStringByID(1485U);
      this.btn_Exchange[index1].m_Text = this.text_ItemExchange[index1];
      if (this.MM.MerchantmanData[index1].ResourceCount > this.DM.Resource[(int) this.MM.MerchantmanData[index1].ResourceKind].Stock)
        this.btn_Exchange[index1].ForTextChange(e_BtnType.e_ChangeText);
      else
        this.btn_Exchange[index1].ForTextChange(e_BtnType.e_Normal);
      this.text_ItemNum[index1] = child5.GetChild(3).GetComponent<UIText>();
      this.text_ItemNum[index1].font = this.TTFont;
      this.Cstr_ItemNum[index1].ClearString();
      this.Cstr_ItemNum[index1].IntToFormat((long) this.MM.MerchantmanData[index1].itemCount);
      if (this.GUIM.IsArabic)
        this.Cstr_ItemNum[index1].AppendFormat("{0}x");
      else
        this.Cstr_ItemNum[index1].AppendFormat("x{0}");
      this.text_ItemNum[index1].text = this.Cstr_ItemNum[index1].ToString();
      this.text_ItemName[index1] = child5.GetChild(4).GetComponent<UIText>();
      this.text_ItemName[index1].font = this.TTFont;
      this.Img_Resources[index1] = child5.GetChild(5).GetComponent<Image>();
      this.text_ItemResourcesValue[index1] = child5.GetChild(5).GetChild(0).GetComponent<UIText>();
      this.text_ItemResourcesValue[index1].font = this.TTFont;
      this.Img_Exchange[index1] = child5.GetChild(6).GetChild(0).GetComponent<Image>();
      if (this.GUIM.IsArabic)
        ((Component) this.Img_Exchange[index1]).transform.localScale = new Vector3(-1f, ((Component) this.Img_Exchange[index1]).transform.localScale.y, ((Component) this.Img_Exchange[index1]).transform.localScale.z);
      this.text_Item[index1] = child5.GetChild(6).GetChild(1).GetComponent<UIText>();
      this.text_Item[index1].font = this.TTFont;
      this.text_Item[index1].text = this.DM.mStringTable.GetStringByID(1486U);
      this.tmpEq = this.DM.EquipTable.GetRecordByKey(this.MM.MerchantmanData[index1].itemID);
      this.text_ItemName[index1].text = this.DM.mStringTable.GetStringByID((uint) this.tmpEq.EquipName);
      if (this.tmpEq.EquipKind == (byte) 11)
      {
        ((Component) this.text_ItemName[index1]).gameObject.SetActive(false);
        ((Component) this.Img_Resources[index1]).gameObject.SetActive(true);
        this.Img_Resources[index1].sprite = this.tmpEq.PropertiesInfo[0].Propertieskey <= (ushort) 0 || this.tmpEq.PropertiesInfo[0].Propertieskey >= (ushort) 6 ? this.SArray.m_Sprites[0] : this.SArray.m_Sprites[(int) this.tmpEq.PropertiesInfo[0].Propertieskey - 1];
        this.Img_Resources[index1].SetNativeSize();
        this.Cstr_ItemResourcesValue[index1].ClearString();
        StringManager.IntToStr(this.Cstr_ItemResourcesValue[index1], (long) ((int) this.MM.MerchantmanData[index1].itemCount * (int) this.tmpEq.PropertiesInfo[1].Propertieskey * (int) this.tmpEq.PropertiesInfo[1].PropertiesValue), bNumber: true);
        this.text_ItemResourcesValue[index1].text = this.Cstr_ItemResourcesValue[index1].ToString();
      }
      this.Img_Star_Hint[index1] = child5.GetChild(8).GetComponent<Image>();
      this.text_Star_Hint[index1] = child5.GetChild(8).GetChild(0).GetComponent<UIText>();
      this.text_Star_Hint[index1].font = this.TTFont;
      this.text_Star_Hint[index1].text = this.DM.mStringTable.GetStringByID(1040U);
      this.text_Star_Hint[index1].cachedTextGeneratorForLayout.Invalidate();
      if ((double) this.text_Star_Hint[index1].preferredWidth > (double) ((Graphic) this.text_Star_Hint[index1]).rectTransform.sizeDelta.y)
        ((Graphic) this.Img_Star_Hint[index1]).rectTransform.sizeDelta = new Vector2(this.text_Star_Hint[index1].preferredWidth + 16f, ((Graphic) this.Img_Star_Hint[index1]).rectTransform.sizeDelta.y);
      this.btn_Star_Hint[index1] = child5.GetChild(7).GetComponent<UIButton>();
      this.btn_Star_Hint[index1].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Star_Hint[index1].m_BtnID1 = 6;
      this.btn_Star_Hint[index1].m_BtnID2 = index1;
      UIButtonHint uiButtonHint2 = ((Component) this.btn_Star_Hint[index1]).gameObject.AddComponent<UIButtonHint>();
      uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
      uiButtonHint2.m_Handler = (MonoBehaviour) this;
      uiButtonHint2.ControlFadeOut = ((Component) this.Img_Star_Hint[index1]).gameObject;
      this.Img_Exchange_Star[index1][0] = child5.GetChild(7).GetChild(0).GetComponent<Image>();
      this.Img_Exchange_Star[index1][1] = child5.GetChild(7).GetChild(1).GetComponent<Image>();
      this.Img_Exchange_Star[index1][2] = child5.GetChild(7).GetChild(2).GetComponent<Image>();
      int num = 1;
      if (this.MM.MerchantmanData[index1].Rare < (byte) 2)
        num = 1;
      else if (this.MM.MerchantmanData[index1].Rare < (byte) 3)
        num = 2;
      else if (this.MM.MerchantmanData[index1].Rare >= (byte) 3)
        num = 3;
      for (int index2 = 0; index2 < num; ++index2)
        ((Component) this.Img_Exchange_Star[index1][index2]).gameObject.SetActive(true);
      if (((int) this.MM.TradeStatus >> index1 & 1) == 0)
      {
        ((Component) this.btn_Exchange[index1]).gameObject.SetActive(true);
        ((Component) this.Img_Exchange[index1]).transform.parent.gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.btn_Exchange[index1]).gameObject.SetActive(false);
        ((Component) this.Img_Exchange[index1]).transform.parent.gameObject.SetActive(true);
        ((Component) this.btn_Lock[index1]).gameObject.SetActive(false);
        this.Img_ItemBG[index1].sprite = this.SArray.m_Sprites[5];
        this.btn_Lock[index1].image.sprite = this.SArray.m_Sprites[7];
      }
    }
    this.InitialP5();
    this.CheckExtraData();
    Image component = this.GameT.GetChild(1).GetComponent<Image>();
    component.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component).material = material;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) component).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(1).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = material;
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    if (!this.MM.bNeedUpDateExtra)
      return;
    this.MM.SendReQusetBlackMarket_Data();
  }

  private void InitialP5()
  {
    // ISSUE: unable to decompile the method.
  }

  public override void OnClose()
  {
    if (this.Cstr_Time != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Time);
    for (int index = 0; index < 5; ++index)
    {
      if (this.Cstr_Resources[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_Resources[index]);
    }
    for (int index = 0; index < 5; ++index)
    {
      if (this.Cstr_ItemNum[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemNum[index]);
      if (this.Cstr_ItemExchangeValue[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemExchangeValue[index]);
      if (this.Cstr_ItemResourcesValue[index] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemResourcesValue[index]);
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!bOnSecond)
      return;
    this.Cstr_Time.ClearString();
    this.Cstr_Time.Append(DataManager.MissionDataManager.FormatMissionTime((uint) Math.Max(this.Data.ResetTime - DataManager.Instance.ServerTime, 0L)));
    this.text_Time.text = this.Cstr_Time.ToString();
    this.text_Time.SetAllDirty();
    this.text_Time.cachedTextGenerator.Invalidate();
    if (!this.NeedUpDate || !IGGGameSDK.Instance.bPaymentReady)
      return;
    this.NeedUpDate = false;
    this.CheckExtraData();
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
        this.GUIM.OpenMessageBoxEX(this.DM.mStringTable.GetStringByID(1041U), this.DM.mStringTable.GetStringByID(1042U), bInfo: true, BackExit: true);
        break;
      case 3:
        if (((int) this.MM.TradeLocks >> sender.m_BtnID2 & 1) == 0)
        {
          this.tmpLock = (byte) sender.m_BtnID2;
          if (!this.DM.MySysSetting.bMerchantman)
          {
            this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(1481U), this.DM.mStringTable.GetStringByID(1482U), 1, YesText: this.DM.mStringTable.GetStringByID(3737U), NoText: this.DM.mStringTable.GetStringByID(3736U));
            break;
          }
          this.MM.TradeLocks += (byte) (1U << (int) this.tmpLock);
          this.MM.SendReQusetBlackMarket_Lock(this.MM.TradeLocks);
          break;
        }
        this.tmpLock = (byte) sender.m_BtnID2;
        this.MM.TradeLocks -= (byte) (1 << sender.m_BtnID2);
        this.MM.SendReQusetBlackMarket_Lock(this.MM.TradeLocks);
        break;
      case 4:
        if (this.DM.Resource[(int) this.MM.MerchantmanData[sender.m_BtnID2].ResourceKind].Stock < this.MM.MerchantmanData[sender.m_BtnID2].ResourceCount)
        {
          this.mExchange = (byte) sender.m_BtnID2;
          CString cstring1 = StringManager.Instance.StaticString1024();
          CString cstring2 = StringManager.Instance.StaticString1024();
          cstring1.StringToFormat(this.DM.mStringTable.GetStringByID(3952U + (uint) this.MM.MerchantmanData[sender.m_BtnID2].ResourceKind));
          cstring1.AppendFormat(this.DM.mStringTable.GetStringByID(1545U));
          cstring2.StringToFormat(this.DM.mStringTable.GetStringByID(3952U + (uint) this.MM.MerchantmanData[sender.m_BtnID2].ResourceKind));
          cstring2.AppendFormat(this.DM.mStringTable.GetStringByID(1546U));
          this.GUIM.OpenMessageBox(cstring1.ToString(), cstring2.ToString(), this.DM.mStringTable.GetStringByID(5723U), (GUIWindow) this, 2, bCloseIDSet: true);
          break;
        }
        RectTransform component1 = ((Component) sender).transform.parent.GetComponent<RectTransform>();
        RectTransform component2 = ((Component) sender).transform.parent.parent.GetComponent<RectTransform>();
        this.GUIM.mStartV2 = new Vector2((float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 + (double) component1.anchoredPosition.x + (double) component2.anchoredPosition.x - (double) component2.sizeDelta.x / 2.0 + 71.5), (float) ((double) this.GUIM.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 - (double) component1.anchoredPosition.y - (double) component2.anchoredPosition.y - (double) component2.sizeDelta.y / 2.0 + 53.0));
        this.mExchange = (byte) sender.m_BtnID2;
        this.MM.SendReQusetBlackMarket_Buy((byte) sender.m_BtnID2);
        break;
      case 5:
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, 1 + (sender.m_BtnID2 << 16));
        break;
      case 7:
        if (this.MM.CheckbWaitBuy(true))
          break;
        this.MM.SendReQusetBlackMarket_Buy(this.MM.MerchantmanExtraData.TradePos, bPay: true);
        break;
      case 8:
        if (this.MM.CheckbWaitBuy(true))
          break;
        if (((int) this.MM.MerchantmanExtraData.LocksBought & 1) == 0)
        {
          this.tmpLock = (byte) 4;
          if (!this.DM.MySysSetting.bMerchantman)
          {
            this.GUIM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(1481U), this.DM.mStringTable.GetStringByID(1482U), 1, YesText: this.DM.mStringTable.GetStringByID(3737U), NoText: this.DM.mStringTable.GetStringByID(3736U));
            break;
          }
          this.MM.SendReQusetBlackMarket_ExtraLock((byte) 1);
          break;
        }
        this.tmpLock = (byte) 4;
        this.MM.SendReQusetBlackMarket_ExtraLock((byte) 0);
        break;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    switch ((GUIMerchantman) button.m_BtnID1)
    {
      case GUIMerchantman.btn_CDTime:
        ((Component) this.Img_Hint).gameObject.SetActive(true);
        break;
      case GUIMerchantman.btn_Star_Hint:
        ((Component) this.Img_Star_Hint[button.m_BtnID2]).gameObject.SetActive(true);
        break;
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    switch ((GUIMerchantman) button.m_BtnID1)
    {
      case GUIMerchantman.btn_CDTime:
        ((Component) this.Img_Hint).gameObject.SetActive(false);
        break;
      case GUIMerchantman.btn_Star_Hint:
        ((Component) this.Img_Star_Hint[button.m_BtnID2]).gameObject.SetActive(false);
        break;
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    this.door.OpenMenu(EGUIWindow.UI_OpenBox, 3, (int) sender.HIID);
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 1:
        if (this.tmpLock >= (byte) 4)
        {
          this.MM.SendReQusetBlackMarket_ExtraLock((byte) 1);
        }
        else
        {
          this.MM.TradeLocks += (byte) (1U << (int) this.tmpLock);
          this.MM.SendReQusetBlackMarket_Lock(this.MM.TradeLocks);
        }
        this.DM.MySysSetting.bMerchantman = true;
        PlayerPrefs.SetString("Other_bMerchantman", this.DM.MySysSetting.bMerchantman.ToString());
        break;
      case 2:
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          break;
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, 1 + (5 + (int) this.MM.MerchantmanData[(int) this.mExchange].ResourceKind << 16), (int) this.MM.MerchantmanData[(int) this.mExchange].ResourceCount);
        break;
    }
  }

  public void ReSetData()
  {
    for (int index1 = 0; index1 < 4; ++index1)
    {
      this.PGO[index1].SetActive(true);
      this.GUIM.ChangeHeroItemImg(((Component) this.btn_Item[index1]).transform, eHeroOrItem.Item, this.MM.MerchantmanData[index1].itemID, (byte) 0, (byte) 0, (int) this.MM.MerchantmanData[index1].itemCount);
      int num = 1;
      if (this.MM.MerchantmanData[index1].Rare < (byte) 2)
        num = 1;
      else if (this.MM.MerchantmanData[index1].Rare < (byte) 3)
        num = 2;
      else if (this.MM.MerchantmanData[index1].Rare >= (byte) 3)
        num = 3;
      for (int index2 = 0; index2 < num; ++index2)
        ((Component) this.Img_Exchange_Star[index1][index2]).gameObject.SetActive(true);
      for (int index3 = num; index3 < 3; ++index3)
        ((Component) this.Img_Exchange_Star[index1][index3]).gameObject.SetActive(false);
      if (((int) this.MM.TradeLocks >> index1 & 1) == 0)
      {
        this.Img_ItemBG[index1].sprite = this.SArray.m_Sprites[5];
        this.btn_Lock[index1].image.sprite = this.SArray.m_Sprites[7];
      }
      else
      {
        this.Img_ItemBG[index1].sprite = this.SArray.m_Sprites[6];
        this.btn_Lock[index1].image.sprite = this.SArray.m_Sprites[8];
      }
      if (((int) this.MM.TradeStatus >> index1 & 1) == 0)
      {
        ((Component) this.btn_Exchange[index1]).gameObject.SetActive(true);
        ((Component) this.Img_Exchange[index1]).transform.parent.gameObject.SetActive(false);
        ((Component) this.btn_Lock[index1]).gameObject.SetActive(true);
        if (this.MM.MerchantmanData[index1].ResourceCount > this.DM.Resource[(int) this.MM.MerchantmanData[index1].ResourceKind].Stock)
          this.btn_Exchange[index1].ForTextChange(e_BtnType.e_ChangeText);
        else
          this.btn_Exchange[index1].ForTextChange(e_BtnType.e_Normal);
      }
      else
      {
        ((Component) this.btn_Exchange[index1]).gameObject.SetActive(false);
        ((Component) this.Img_Exchange[index1]).transform.parent.gameObject.SetActive(true);
        ((Component) this.btn_Lock[index1]).gameObject.SetActive(false);
        this.Img_ItemBG[index1].sprite = this.SArray.m_Sprites[5];
        this.btn_Lock[index1].image.sprite = this.SArray.m_Sprites[7];
      }
      this.tmpEq = this.DM.EquipTable.GetRecordByKey(this.MM.MerchantmanData[index1].itemID);
      this.text_ItemName[index1].text = this.DM.mStringTable.GetStringByID((uint) this.tmpEq.EquipName);
      this.text_ItemName[index1].SetAllDirty();
      this.text_ItemName[index1].cachedTextGenerator.Invalidate();
      if (this.tmpEq.EquipKind != (byte) 11)
      {
        ((Component) this.text_ItemName[index1]).gameObject.SetActive(true);
        ((Component) this.Img_Resources[index1]).gameObject.SetActive(false);
      }
      else
      {
        ((Component) this.text_ItemName[index1]).gameObject.SetActive(false);
        ((Component) this.Img_Resources[index1]).gameObject.SetActive(true);
        this.Img_Resources[index1].sprite = this.tmpEq.PropertiesInfo[0].Propertieskey <= (ushort) 0 || this.tmpEq.PropertiesInfo[0].Propertieskey >= (ushort) 6 ? this.SArray.m_Sprites[0] : this.SArray.m_Sprites[(int) this.tmpEq.PropertiesInfo[0].Propertieskey - 1];
        this.Img_Resources[index1].SetNativeSize();
        this.Cstr_ItemResourcesValue[index1].ClearString();
        StringManager.IntToStr(this.Cstr_ItemResourcesValue[index1], (long) ((int) this.MM.MerchantmanData[index1].itemCount * (int) this.tmpEq.PropertiesInfo[1].Propertieskey * (int) this.tmpEq.PropertiesInfo[1].PropertiesValue), bNumber: true);
        this.text_ItemResourcesValue[index1].text = this.Cstr_ItemResourcesValue[index1].ToString();
        this.text_ItemResourcesValue[index1].SetAllDirty();
        this.text_ItemResourcesValue[index1].cachedTextGenerator.Invalidate();
      }
      this.Img_Exchange_Res[index1].sprite = this.SArray.m_Sprites[(int) this.MM.MerchantmanData[index1].ResourceKind];
      this.Img_Exchange_Res[index1].SetNativeSize();
      this.Cstr_ItemExchangeValue[index1].ClearString();
      StringManager.IntToStr(this.Cstr_ItemExchangeValue[index1], (long) this.MM.MerchantmanData[index1].ResourceCount, bNumber: true);
      this.text_ItemExchangeValue[index1].text = this.Cstr_ItemExchangeValue[index1].ToString();
      this.text_ItemExchangeValue[index1].SetAllDirty();
      this.text_ItemExchangeValue[index1].cachedTextGenerator.Invalidate();
      this.Cstr_ItemNum[index1].ClearString();
      this.Cstr_ItemNum[index1].IntToFormat((long) this.MM.MerchantmanData[index1].itemCount);
      if (this.GUIM.IsArabic)
        this.Cstr_ItemNum[index1].AppendFormat("{0}x");
      else
        this.Cstr_ItemNum[index1].AppendFormat("x{0}");
      this.text_ItemNum[index1].text = this.Cstr_ItemNum[index1].ToString();
      this.text_ItemNum[index1].SetAllDirty();
      this.text_ItemNum[index1].cachedTextGenerator.Invalidate();
    }
  }

  public void CheckExtraData()
  {
    if ((UnityEngine.Object) this.btn_Item[0] == (UnityEngine.Object) null || this.MM.ExtraData != (byte) 1 || this.MM.MerchantmanExtraData.TradePos >= (byte) 4)
    {
      this.PGO[4].SetActive(false);
    }
    else
    {
      int index1 = 4;
      this.PGO[index1].SetActive(true);
      this.PGO[(int) this.MM.MerchantmanExtraData.TradePos].SetActive(false);
      ((RectTransform) this.PGO[index1].transform).anchoredPosition = ((RectTransform) this.PGO[(int) this.MM.MerchantmanExtraData.TradePos].transform).anchoredPosition;
      this.GUIM.ChangeHeroItemImg(((Component) this.btn_Item[index1]).transform, eHeroOrItem.Item, this.MM.MerchantmanExtraData.itemID, (byte) 0, (byte) 0);
      int discount = (int) this.MM.MerchantmanExtraData.Discount;
      for (int index2 = 0; index2 < discount; ++index2)
        ((Component) this.Img_Exchange_Star[index1][index2]).gameObject.SetActive(true);
      for (int index3 = discount; index3 < 3; ++index3)
        ((Component) this.Img_Exchange_Star[index1][index3]).gameObject.SetActive(false);
      if (((int) this.MM.MerchantmanExtraData.LocksBought & 1) == 0)
      {
        this.Img_ItemBG[index1].sprite = this.SArray.m_Sprites[9];
        this.btn_Lock[index1].image.sprite = this.SArray.m_Sprites[7];
      }
      else
      {
        this.Img_ItemBG[index1].sprite = this.SArray.m_Sprites[10];
        this.btn_Lock[index1].image.sprite = this.SArray.m_Sprites[8];
      }
      if (((int) this.MM.MerchantmanExtraData.LocksBought >> 1 & 1) == 0)
      {
        ((Component) this.btn_Exchange[index1]).gameObject.SetActive(true);
        ((Component) this.Img_Exchange[index1]).transform.parent.gameObject.SetActive(false);
        ((Component) this.btn_Lock[index1]).gameObject.SetActive(true);
      }
      else
      {
        ((Component) this.btn_Exchange[index1]).gameObject.SetActive(false);
        ((Component) this.Img_Exchange[index1]).transform.parent.gameObject.SetActive(true);
        ((Component) this.btn_Lock[index1]).gameObject.SetActive(false);
        this.Img_ItemBG[index1].sprite = this.SArray.m_Sprites[9];
        this.btn_Lock[index1].image.sprite = this.SArray.m_Sprites[7];
      }
      this.tmpEq = this.DM.EquipTable.GetRecordByKey(this.MM.MerchantmanExtraData.itemID);
      this.text_ItemName[index1].text = this.DM.mStringTable.GetStringByID((uint) this.tmpEq.EquipName);
      this.text_ItemName[index1].SetAllDirty();
      this.text_ItemName[index1].cachedTextGenerator.Invalidate();
      this.Cstr_ItemNum[index1].ClearString();
      this.Cstr_ItemNum[index1].IntToFormat(1L);
      if (this.GUIM.IsArabic)
        this.Cstr_ItemNum[index1].AppendFormat("{0}x");
      else
        this.Cstr_ItemNum[index1].AppendFormat("x{0}");
      this.text_ItemNum[index1].text = this.Cstr_ItemNum[index1].ToString();
      this.text_ItemNum[index1].SetAllDirty();
      this.text_ItemNum[index1].cachedTextGenerator.Invalidate();
      MallManager instance = MallManager.Instance;
      string paltformPriceById = instance.GetProductPaltformPriceByID((int) instance.SmallID);
      string productPriceById = instance.GetProductPriceByID((int) instance.SmallID);
      this.extra_PriceStr.Length = 0;
      if (paltformPriceById != null && paltformPriceById != string.Empty)
      {
        this.extra_PriceStr.Append(paltformPriceById);
      }
      else
      {
        if (productPriceById != null)
        {
          this.extra_PriceStr.StringToFormat(productPriceById);
        }
        else
        {
          this.extra_PriceStr.StringToFormat(string.Empty);
          this.NeedUpDate = true;
        }
        string currency = instance.GetCurrency((int) instance.SmallID);
        if (currency != null)
        {
          this.extra_PriceStr.StringToFormat(currency);
          if (instance.bChangePosCurrency(currency))
            this.extra_PriceStr.AppendFormat("{0} {1}");
          else
            this.extra_PriceStr.AppendFormat("{1} {0}");
        }
      }
      this.extra_Price.text = this.extra_PriceStr.ToString();
      ((Graphic) this.extra_Price).SetAllDirty();
      this.extra_Price.cachedTextGenerator.Invalidate();
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.ReSetData();
        this.CheckExtraData();
        break;
      case 2:
        ((Component) this.btn_Exchange[(int) this.mExchange]).gameObject.SetActive(false);
        ((Component) this.Img_Exchange[(int) this.mExchange]).transform.parent.gameObject.SetActive(true);
        ((Component) this.btn_Lock[(int) this.mExchange]).gameObject.SetActive(false);
        this.Img_ItemBG[(int) this.mExchange].sprite = this.SArray.m_Sprites[5];
        this.btn_Lock[(int) this.mExchange].image.sprite = this.SArray.m_Sprites[7];
        ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(this.MM.MerchantmanData[(int) this.mExchange].itemID, (byte) 0);
        if (curItemQuantity < ushort.MaxValue)
          DataManager.Instance.SetCurItemQuantity(this.MM.MerchantmanData[(int) this.mExchange].itemID, (ushort) ((uint) curItemQuantity + (uint) this.MM.MerchantmanData[(int) this.mExchange].itemCount), (byte) 0, 0L);
        AudioManager.Instance.PlayUISFX(UIKind.HUDTreasure);
        GUIManager.Instance.m_SpeciallyEffect.AddIconShow(false, this.GUIM.mStartV2, SpeciallyEffect_Kind.Item, ItemID: this.MM.MerchantmanData[(int) this.mExchange].itemID, EndTime: 2f);
        break;
      case 3:
        if (((int) this.MM.TradeLocks >> (int) this.tmpLock & 1) == 0)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1484U), (ushort) byte.MaxValue);
          this.Img_ItemBG[(int) this.tmpLock].sprite = this.SArray.m_Sprites[5];
          this.btn_Lock[(int) this.tmpLock].image.sprite = this.SArray.m_Sprites[7];
          break;
        }
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(1483U), (ushort) byte.MaxValue);
        this.Img_ItemBG[(int) this.tmpLock].sprite = this.SArray.m_Sprites[6];
        this.btn_Lock[(int) this.tmpLock].image.sprite = this.SArray.m_Sprites[8];
        break;
      case 4:
        CString cstring1 = StringManager.Instance.StaticString1024();
        CString cstring2 = StringManager.Instance.StaticString1024();
        cstring1.StringToFormat(this.DM.mStringTable.GetStringByID(3952U + (uint) this.MM.MerchantmanData[(int) this.mExchange].ResourceKind));
        cstring1.AppendFormat(this.DM.mStringTable.GetStringByID(1545U));
        cstring2.StringToFormat(this.DM.mStringTable.GetStringByID(3952U + (uint) this.MM.MerchantmanData[(int) this.mExchange].ResourceKind));
        cstring2.AppendFormat(this.DM.mStringTable.GetStringByID(1546U));
        this.GUIM.OpenMessageBox(cstring1.ToString(), cstring2.ToString(), this.DM.mStringTable.GetStringByID(5723U), (GUIWindow) this, 2, bCloseIDSet: true);
        break;
      case 5:
        AudioManager.Instance.PlayMP3SFX((ushort) 41011);
        break;
      case 6:
        this.MM.SendReQusetBlackMarket_Data();
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_Resource:
        for (int index = 0; index < 5; ++index)
        {
          this.Cstr_Resources[index].ClearString();
          StringManager.IntToStr(this.Cstr_Resources[index], (long) this.DM.Resource[index].Stock, bNumber: true);
          this.text_Resources[index].text = this.Cstr_Resources[index].ToString();
          this.text_Resources[index].SetAllDirty();
          this.text_Resources[index].cachedTextGenerator.Invalidate();
        }
        for (int index = 0; index < 4; ++index)
        {
          if ((UnityEngine.Object) this.btn_Exchange[index] != (UnityEngine.Object) null)
          {
            if (this.MM.MerchantmanData[index].ResourceCount > this.DM.Resource[(int) this.MM.MerchantmanData[index].ResourceKind].Stock)
              this.btn_Exchange[index].ForTextChange(e_BtnType.e_ChangeText);
            else
              this.btn_Exchange[index].ForTextChange(e_BtnType.e_Normal);
          }
        }
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.extra_Price != (UnityEngine.Object) null && ((Behaviour) this.extra_Price).enabled)
    {
      ((Behaviour) this.extra_Price).enabled = false;
      ((Behaviour) this.extra_Price).enabled = true;
    }
    if ((UnityEngine.Object) this.extra_text_ItemExchangeValue != (UnityEngine.Object) null && ((Behaviour) this.extra_text_ItemExchangeValue).enabled)
    {
      ((Behaviour) this.extra_text_ItemExchangeValue).enabled = false;
      ((Behaviour) this.extra_text_ItemExchangeValue).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Title != (UnityEngine.Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Time != (UnityEngine.Object) null && ((Behaviour) this.text_Time).enabled)
    {
      ((Behaviour) this.text_Time).enabled = false;
      ((Behaviour) this.text_Time).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Hint != (UnityEngine.Object) null && ((Behaviour) this.text_Hint).enabled)
    {
      ((Behaviour) this.text_Hint).enabled = false;
      ((Behaviour) this.text_Hint).enabled = true;
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((UnityEngine.Object) this.text_Resources[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Resources[index]).enabled)
      {
        ((Behaviour) this.text_Resources[index]).enabled = false;
        ((Behaviour) this.text_Resources[index]).enabled = true;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((UnityEngine.Object) this.text_ItemNum[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemNum[index]).enabled)
      {
        ((Behaviour) this.text_ItemNum[index]).enabled = false;
        ((Behaviour) this.text_ItemNum[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ItemName[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemName[index]).enabled)
      {
        ((Behaviour) this.text_ItemName[index]).enabled = false;
        ((Behaviour) this.text_ItemName[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ItemResourcesValue[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemResourcesValue[index]).enabled)
      {
        ((Behaviour) this.text_ItemResourcesValue[index]).enabled = false;
        ((Behaviour) this.text_ItemResourcesValue[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ItemExchange[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemExchange[index]).enabled)
      {
        ((Behaviour) this.text_ItemExchange[index]).enabled = false;
        ((Behaviour) this.text_ItemExchange[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_ItemExchangeValue[index] != (UnityEngine.Object) null && ((Behaviour) this.text_ItemExchangeValue[index]).enabled)
      {
        ((Behaviour) this.text_ItemExchangeValue[index]).enabled = false;
        ((Behaviour) this.text_ItemExchangeValue[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Item[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Item[index]).enabled)
      {
        ((Behaviour) this.text_Item[index]).enabled = false;
        ((Behaviour) this.text_Item[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.text_Star_Hint[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Star_Hint[index]).enabled)
      {
        ((Behaviour) this.text_Star_Hint[index]).enabled = false;
        ((Behaviour) this.text_Star_Hint[index]).enabled = true;
      }
      if ((UnityEngine.Object) this.btn_Item[index] != (UnityEngine.Object) null && ((Behaviour) this.btn_Item[index]).enabled)
        this.btn_Item[index].Refresh_FontTexture();
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
