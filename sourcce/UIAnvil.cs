// Decompiled with JetBrains decompiler
// Type: UIAnvil
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAnvil : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUILEBtnClickHandler
{
  private Transform AGS_Form;
  private UISpritesArray AGS_RareImg;
  private ScrollPanel AGS_ScrollPanel;
  private Door door;
  private DataManager DM;
  private Image ForgeLight;
  private Image SelectLight;
  private Image MaterialLight;
  private RectTransform arrowPos;
  private Image SmallForgeLight;
  private RectTransform BigForgeLight;
  private Image Flash;
  private Image LightBox1;
  private Image LightBox2;
  private Image[] ItemLight = new Image[5];
  private Image POPLight1;
  private Image POPLight3;
  private bool MaterialFlash;
  private bool ForgintLightEff;
  private bool ForgeStart;
  private bool ForgeStop;
  private bool ItemMagnet;
  private bool isLoading = true;
  private bool isCombine;
  private ushort[] MaterCount = new ushort[5];
  public static eUI_Anvil_OpenKind OpenKind;
  public static ushort preSetIndex;
  public static ushort preSetID;
  public static ushort returnID;
  public static byte returnColor;
  private byte preSetColor;
  private byte currentColor;
  private ushort SelectMatID;
  private byte SelectMatColor;
  private ushort SelectMatReqNum;
  private CString ItemNameText;
  private CString ItemLevelText;
  private CString goldCost;
  private CString moneyCost;
  private CString timeCost;
  private CString timeRemain;
  private CString focusName;
  private CString forgingItemName;
  private CString PopString;
  private CString[] RequestCount = new CString[5];
  private CString[] EffDescText = new CString[6];
  private CString[] CombineCount = new CString[5];
  private CString PopUpHeaderText;
  private List<LordEquipEffectSet> effectList;
  private List<float> SPHeight;
  private uint NeedDiamon;
  private float MoveTime;
  private float ForgeLightTime;
  private float HintTime;
  private float ForgingLightTime;
  private float ForgeStartTime;
  private float arrowTime;

  public override void OnOpen(int arg1, int arg2)
  {
    this.door = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    this.DM = DataManager.Instance;
    if (this.DM.mLordEquip == null)
      this.DM.mLordEquip = LordEquipData.Instance();
    this.ItemNameText = StringManager.Instance.SpawnString(100);
    this.ItemLevelText = StringManager.Instance.SpawnString(50);
    this.goldCost = StringManager.Instance.SpawnString(100);
    this.moneyCost = StringManager.Instance.SpawnString(100);
    this.timeCost = StringManager.Instance.SpawnString();
    this.timeRemain = StringManager.Instance.SpawnString();
    this.focusName = StringManager.Instance.SpawnString(50);
    this.forgingItemName = StringManager.Instance.SpawnString(50);
    this.PopString = StringManager.Instance.SpawnString(300);
    this.PopUpHeaderText = StringManager.Instance.SpawnString(50);
    for (int index = 0; index < this.RequestCount.Length; ++index)
      this.RequestCount[index] = StringManager.Instance.SpawnString();
    for (int index = 0; index < this.EffDescText.Length; ++index)
      this.EffDescText[index] = StringManager.Instance.SpawnString(200);
    for (int index = 0; index < this.CombineCount.Length; ++index)
      this.CombineCount[index] = StringManager.Instance.SpawnString();
    this.SPHeight = new List<float>();
    this.effectList = new List<LordEquipEffectSet>();
    if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.ForgeNewItem)
    {
      UIAnvil.preSetID = (ushort) arg1;
      this.preSetColor = (byte) arg2;
    }
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = this.DM.mStringTable.GetStringByID(7430U);
    Image component2 = this.AGS_Form.GetChild(2).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component2).material = this.door.LoadMaterial();
    ((Behaviour) component2).enabled = !GUIManager.Instance.bOpenOnIPhoneX;
    Image component3 = this.AGS_Form.GetChild(2).GetChild(0).GetComponent<Image>();
    component3.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component3).material = this.door.LoadMaterial();
    UIButton component4 = this.AGS_Form.GetChild(2).GetChild(0).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_EffectType = e_EffectType.e_Scale;
    UIButton component5 = this.AGS_Form.GetChild(3).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_BtnID1 = 99;
    component5.m_EffectType = e_EffectType.e_Scale;
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component6 = ((Component) component5).gameObject.GetComponent<RectTransform>();
      ((Transform) component6).localScale = new Vector3(-1f, 1f, 1f);
      component6.anchoredPosition = new Vector2(component6.anchoredPosition.x + 44f, component6.anchoredPosition.y);
    }
    UIText component7 = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIText>();
    component7.font = ttfFont;
    component7.text = string.Empty;
    this.AGS_RareImg = this.AGS_Form.GetChild(6).GetChild(2).GetComponent<UISpritesArray>();
    UIText component8 = this.AGS_Form.GetChild(6).GetChild(3).GetComponent<UIText>();
    component8.font = ttfFont;
    component8.text = string.Empty;
    this.AGS_ScrollPanel = this.AGS_Form.GetChild(6).GetChild(4).GetComponent<ScrollPanel>();
    UIText component9 = this.AGS_Form.GetChild(6).GetChild(5).GetChild(0).GetComponent<UIText>();
    component9.font = ttfFont;
    component9.text = string.Empty;
    UIText component10 = this.AGS_Form.GetChild(6).GetChild(6).GetChild(0).GetComponent<UIText>();
    component10.font = ttfFont;
    component10.text = this.DM.mStringTable.GetStringByID(7438U);
    UIButton component11 = this.AGS_Form.GetChild(6).GetChild(7).GetComponent<UIButton>();
    component11.m_Handler = (IUIButtonClickHandler) this;
    component11.m_BtnID1 = 0;
    component11.m_BtnID2 = 1;
    component11.m_EffectType = e_EffectType.e_Scale;
    this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    this.AGS_Form.GetChild(7).GetChild(1).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    this.AGS_Form.GetChild(7).GetChild(2).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    this.AGS_Form.GetChild(7).GetChild(3).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    this.AGS_Form.GetChild(7).GetChild(4).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    UIButton component12 = this.AGS_Form.GetChild(7).GetChild(6).GetComponent<UIButton>();
    component12.m_Handler = (IUIButtonClickHandler) this;
    component12.m_BtnID1 = 0;
    component12.m_BtnID2 = 2;
    component12.m_EffectType = e_EffectType.e_Scale;
    this.SelectLight = this.AGS_Form.GetChild(7).GetChild(5).GetComponent<Image>();
    this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    this.ForgeLight = this.AGS_Form.GetChild(8).GetChild(2).GetComponent<Image>();
    this.BigForgeLight = this.AGS_Form.GetChild(8).GetChild(4).GetComponent<RectTransform>();
    this.SmallForgeLight = this.AGS_Form.GetChild(8).GetChild(3).GetComponent<Image>();
    UIText component13 = this.AGS_Form.GetChild(8).GetChild(1).GetComponent<UIText>();
    component13.font = ttfFont;
    component13.text = string.Empty;
    UIText component14 = this.AGS_Form.GetChild(9).GetChild(0).GetComponent<UIText>();
    component14.font = ttfFont;
    component14.text = string.Empty;
    UIText component15 = this.AGS_Form.GetChild(9).GetChild(3).GetComponent<UIText>();
    component15.font = ttfFont;
    component15.text = this.DM.mStringTable.GetStringByID(261U);
    UIText component16 = this.AGS_Form.GetChild(9).GetChild(4).GetComponent<UIText>();
    component16.font = ttfFont;
    component16.text = string.Empty;
    UIButton component17 = this.AGS_Form.GetChild(9).GetChild(5).GetComponent<UIButton>();
    component17.m_Handler = (IUIButtonClickHandler) this;
    component17.m_BtnID1 = 3;
    component17.m_BtnID2 = 2;
    component17.m_EffectType = e_EffectType.e_Scale;
    UIButton component18 = this.AGS_Form.GetChild(9).GetChild(6).GetComponent<UIButton>();
    component18.m_Handler = (IUIButtonClickHandler) this;
    component18.m_BtnID1 = 3;
    component18.m_BtnID2 = 1;
    component18.m_EffectType = e_EffectType.e_Scale;
    if (GUIManager.Instance.IsArabic)
      ((Transform) ((Component) component18).transform.GetComponent<RectTransform>()).localScale = new Vector3(-1f, 1f, 1f);
    this.AGS_Form.GetChild(10).GetChild(0).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    UIText component19 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(0).GetComponent<UIText>();
    component19.font = ttfFont;
    component19.text = string.Empty;
    this.AGS_Form.GetChild(10).GetChild(1).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    UIText component20 = this.AGS_Form.GetChild(10).GetChild(1).GetChild(0).GetComponent<UIText>();
    component20.font = ttfFont;
    component20.text = string.Empty;
    this.AGS_Form.GetChild(10).GetChild(2).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    UIText component21 = this.AGS_Form.GetChild(10).GetChild(2).GetChild(0).GetComponent<UIText>();
    component21.font = ttfFont;
    component21.text = string.Empty;
    this.AGS_Form.GetChild(10).GetChild(3).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    UIText component22 = this.AGS_Form.GetChild(10).GetChild(3).GetChild(0).GetComponent<UIText>();
    component22.font = ttfFont;
    component22.text = string.Empty;
    this.AGS_Form.GetChild(10).GetChild(4).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    UIText component23 = this.AGS_Form.GetChild(10).GetChild(4).GetChild(0).GetComponent<UIText>();
    component23.font = ttfFont;
    component23.text = string.Empty;
    UIButton component24 = this.AGS_Form.GetChild(10).GetChild(10).GetComponent<UIButton>();
    component24.m_Handler = (IUIButtonClickHandler) this;
    component24.m_EffectType = e_EffectType.e_Scale;
    component24.m_BtnID1 = 7;
    UIText component25 = this.AGS_Form.GetChild(10).GetChild(10).GetChild(1).GetComponent<UIText>();
    component25.font = ttfFont;
    component25.text = string.Empty;
    Image component26 = this.AGS_Form.GetChild(10).GetChild(10).GetChild(2).GetComponent<Image>();
    component26.sprite = this.door.LoadSprite("UI_con_icon_05");
    ((MaskableGraphic) component26).material = this.door.LoadMaterial();
    component26.SetNativeSize();
    ((Component) component26).gameObject.SetActive(true);
    for (int index = 0; index < 5; ++index)
      this.ItemLight[index] = this.AGS_Form.GetChild(10).GetChild(5 + index).GetComponent<Image>();
    UIButton component27 = this.AGS_Form.GetChild(11).GetChild(0).GetComponent<UIButton>();
    component27.m_Handler = (IUIButtonClickHandler) this;
    component27.m_BtnID1 = 1;
    component27.m_BtnID2 = 2;
    component27.m_EffectType = e_EffectType.e_Scale;
    UIText component28 = this.AGS_Form.GetChild(11).GetChild(0).GetChild(2).GetComponent<UIText>();
    component28.font = ttfFont;
    component28.text = string.Empty;
    UIText component29 = this.AGS_Form.GetChild(11).GetChild(0).GetChild(3).GetComponent<UIText>();
    component29.font = ttfFont;
    component29.text = this.DM.mStringTable.GetStringByID(7439U);
    UIButton component30 = this.AGS_Form.GetChild(11).GetChild(1).GetComponent<UIButton>();
    component30.m_Handler = (IUIButtonClickHandler) this;
    component30.m_BtnID1 = 1;
    component30.m_BtnID2 = 1;
    component30.m_EffectType = e_EffectType.e_Scale;
    UIText component31 = this.AGS_Form.GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>();
    component31.font = ttfFont;
    component31.text = this.DM.mStringTable.GetStringByID(7440U);
    UIText component32 = this.AGS_Form.GetChild(11).GetChild(1).GetChild(2).GetComponent<UIText>();
    component32.font = ttfFont;
    component32.text = string.Empty;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.AGS_Form.GetChild(12).GetComponent<UIButton>());
    HelperUIButton helperUiButton = this.AGS_Form.GetChild(12).gameObject.AddComponent<HelperUIButton>();
    helperUiButton.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton.m_BtnID1 = 4;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.AGS_Form.GetChild(12).GetChild(0).GetChild(0).GetComponent<IgnoreRaycast>());
    this.Flash = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(3).GetComponent<Image>();
    this.LightBox1 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(0).GetComponent<Image>();
    this.LightBox2 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(1).GetComponent<Image>();
    this.MaterialLight = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetComponent<Image>();
    this.arrowPos = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(2).GetComponent<RectTransform>();
    UIButton component33 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(1).GetComponent<UIButton>();
    component33.m_Handler = (IUIButtonClickHandler) this;
    component33.m_BtnID1 = 4;
    component33.m_EffectType = e_EffectType.e_Scale;
    Image component34 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(1).GetComponent<Image>();
    component34.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component34).material = this.door.LoadMaterial();
    UILEBtn component35 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(2).GetComponent<UILEBtn>();
    component35.m_Handler = (IUILEBtnClickHandler) this;
    component35.transition = (Selectable.Transition) 0;
    UIText component36 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(4).GetComponent<UIText>();
    component36.font = ttfFont;
    component36.text = string.Empty;
    UIText component37 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(1).GetComponent<UIText>();
    component37.font = ttfFont;
    component37.text = string.Empty;
    this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(2).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    component33.m_BtnID1 = 4;
    component33.m_BtnID2 = 1;
    UIText component38 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(2).GetChild(0).GetComponent<UIText>();
    component38.font = ttfFont;
    component38.text = string.Empty;
    this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(3).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    component33.m_BtnID1 = 4;
    component33.m_BtnID2 = 2;
    UIText component39 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(3).GetChild(0).GetComponent<UIText>();
    component39.font = ttfFont;
    component39.text = string.Empty;
    this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(4).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    component33.m_BtnID1 = 4;
    component33.m_BtnID2 = 3;
    UIText component40 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(4).GetChild(0).GetComponent<UIText>();
    component40.font = ttfFont;
    component40.text = string.Empty;
    this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(5).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    component33.m_BtnID1 = 4;
    component33.m_BtnID2 = 4;
    UIText component41 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(5).GetChild(0).GetComponent<UIText>();
    component41.font = ttfFont;
    component41.text = string.Empty;
    this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(6).GetComponent<UILEBtn>().m_Handler = (IUILEBtnClickHandler) this;
    component33.m_BtnID1 = 4;
    component33.m_BtnID2 = 5;
    UIText component42 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(6).GetChild(0).GetComponent<UIText>();
    component42.font = ttfFont;
    component42.text = string.Empty;
    UIButton component43 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).GetComponent<UIButton>();
    component43.m_Handler = (IUIButtonClickHandler) this;
    component43.m_BtnID1 = 5;
    component43.m_BtnID2 = 2;
    component43.m_EffectType = e_EffectType.e_Scale;
    UIText component44 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).GetChild(0).GetComponent<UIText>();
    component44.font = ttfFont;
    component44.text = string.Empty;
    UIButton component45 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetComponent<UIButton>();
    component45.m_Handler = (IUIButtonClickHandler) this;
    component45.m_BtnID1 = 5;
    component45.m_BtnID2 = 1;
    component45.m_EffectType = e_EffectType.e_Scale;
    UIText component46 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetChild(0).GetComponent<UIText>();
    component46.font = ttfFont;
    component46.text = string.Empty;
    UIText component47 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(10).GetComponent<UIText>();
    component47.font = ttfFont;
    component47.text = string.Empty;
    UIButton component48 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(0).GetComponent<UIButton>();
    component48.m_Handler = (IUIButtonClickHandler) this;
    component48.m_BtnID1 = 6;
    component48.m_BtnID2 = 1;
    UIButton component49 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(4).GetComponent<UIButton>();
    component49.m_Handler = (IUIButtonClickHandler) this;
    component49.m_BtnID1 = 6;
    component49.m_BtnID2 = 2;
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      RectTransform component50 = this.AGS_Form.GetChild(12).GetComponent<RectTransform>();
      component50.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      component50.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    Image component51 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(8).GetComponent<Image>();
    component51.sprite = this.door.LoadSprite("UI_main_redbox_01");
    ((MaskableGraphic) component51).material = this.door.LoadMaterial();
    component51.type = (Image.Type) 1;
    Image component52 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(8).GetChild(0).GetComponent<Image>();
    component52.sprite = this.door.LoadSprite("UI_main_mess_ex");
    ((MaskableGraphic) component52).material = this.door.LoadMaterial();
    this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(8).gameObject.SetActive(false);
    this.DM.mLordEquip.LoadLordEquip(true);
    this.AGS_Form.GetChild(6).gameObject.SetActive(true);
    this.AGS_Form.GetChild(12).gameObject.SetActive(false);
    this.POPLight1 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(1).GetComponent<Image>();
    this.POPLight3 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(5).GetComponent<Image>();
    ((Graphic) this.LightBox1).color = new Color(1f, 1f, 1f, 0.0f);
    ((Graphic) this.LightBox2).color = new Color(1f, 1f, 1f, 0.0f);
    ((Graphic) this.Flash).color = new Color(1f, 1f, 1f, 0.0f);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    switch (UIAnvil.OpenKind)
    {
      case eUI_Anvil_OpenKind.ForgeNewItem:
      case eUI_Anvil_OpenKind.NowForging:
        this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7430U);
        this.AGS_Form.GetChild(11).GetChild(0).GetChild(3).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7439U);
        this.AGS_Form.GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7440U);
        break;
      case eUI_Anvil_OpenKind.UpgradeItem:
        this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7537U);
        this.AGS_Form.GetChild(11).GetChild(0).GetChild(3).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7535U);
        this.AGS_Form.GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7475U);
        break;
    }
  }

  public override void OnClose()
  {
    UIAnvil.returnColor = (byte) 0;
    UIAnvil.returnID = (ushort) 0;
    StringManager.Instance.DeSpawnString(this.ItemNameText);
    StringManager.Instance.DeSpawnString(this.ItemLevelText);
    StringManager.Instance.DeSpawnString(this.goldCost);
    StringManager.Instance.DeSpawnString(this.moneyCost);
    StringManager.Instance.DeSpawnString(this.timeCost);
    StringManager.Instance.DeSpawnString(this.timeRemain);
    StringManager.Instance.DeSpawnString(this.focusName);
    StringManager.Instance.DeSpawnString(this.forgingItemName);
    StringManager.Instance.DeSpawnString(this.PopString);
    StringManager.Instance.DeSpawnString(this.PopUpHeaderText);
    for (int index = 0; index < this.RequestCount.Length; ++index)
      StringManager.Instance.DeSpawnString(this.RequestCount[index]);
    for (int index = 0; index < this.EffDescText.Length; ++index)
      StringManager.Instance.DeSpawnString(this.EffDescText[index]);
    for (int index = 0; index < this.CombineCount.Length; ++index)
      StringManager.Instance.DeSpawnString(this.CombineCount[index]);
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!bOnSecond)
      return;
    this.SetForgingTimeBar();
    this.ShowMoney();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        this.SetPopUp(this.currentColor);
        this.MaterialFlash = true;
        break;
      case 2:
        UIAnvil.OpenKind = eUI_Anvil_OpenKind.NowForging;
        this.SetOpenKind(UIAnvil.OpenKind);
        this.SetView(this.DM.RoleAttr.LordEquipEventData.ItemID, this.DM.RoleAttr.LordEquipEventData.Color);
        this.StartForge(true);
        break;
      case 3:
        if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.NowForging)
        {
          if (arg2 >= 0)
          {
            UIAnvil.OpenKind = eUI_Anvil_OpenKind.UpgradeItem;
            UIAnvil.preSetIndex = (ushort) arg2;
            UIAnvil.preSetID = this.DM.mLordEquip.LordEquip[(int) UIAnvil.preSetIndex].ItemID;
            this.preSetColor = this.DM.mLordEquip.LordEquip[(int) UIAnvil.preSetIndex].Color;
            ++this.preSetColor;
            this.currentColor = this.preSetColor;
          }
          else
          {
            UIAnvil.OpenKind = eUI_Anvil_OpenKind.ForgeNewItem;
            this.currentColor = (byte) 1;
          }
        }
        if (!this.isLoading)
        {
          this.SetOpenKind(UIAnvil.OpenKind);
          this.SetView(UIAnvil.preSetID, this.currentColor);
          this.SetSideItem();
        }
        this.StartForge(false);
        break;
      case 5:
        if (arg2 >= 0)
        {
          UIAnvil.OpenKind = eUI_Anvil_OpenKind.UpgradeItem;
          UIAnvil.preSetIndex = (ushort) arg2;
          UIAnvil.preSetID = this.DM.mLordEquip.LordEquip[(int) UIAnvil.preSetIndex].ItemID;
          this.preSetColor = this.DM.mLordEquip.LordEquip[(int) UIAnvil.preSetIndex].Color;
          ++this.preSetColor;
          this.currentColor = this.preSetColor;
        }
        else
          UIAnvil.OpenKind = eUI_Anvil_OpenKind.ForgeNewItem;
        this.SetOpenKind(UIAnvil.OpenKind);
        this.SetView(UIAnvil.preSetID, this.currentColor);
        this.SetSideItem();
        this.StartForge(true);
        this.ForgeStop = true;
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.door.CloseMenu();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.AGS_Form.GetChild(6).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component3 != (UnityEngine.Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.AGS_Form.GetChild(6).GetChild(6).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component4 != (UnityEngine.Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    UIText component5 = this.AGS_Form.GetChild(8).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component5 != (UnityEngine.Object) null && ((Behaviour) component5).enabled)
    {
      ((Behaviour) component5).enabled = false;
      ((Behaviour) component5).enabled = true;
    }
    UIText component6 = this.AGS_Form.GetChild(9).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component6 != (UnityEngine.Object) null && ((Behaviour) component6).enabled)
    {
      ((Behaviour) component6).enabled = false;
      ((Behaviour) component6).enabled = true;
    }
    UIText component7 = this.AGS_Form.GetChild(9).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component7 != (UnityEngine.Object) null && ((Behaviour) component7).enabled)
    {
      ((Behaviour) component7).enabled = false;
      ((Behaviour) component7).enabled = true;
    }
    UIText component8 = this.AGS_Form.GetChild(9).GetChild(4).GetComponent<UIText>();
    if ((UnityEngine.Object) component8 != (UnityEngine.Object) null && ((Behaviour) component8).enabled)
    {
      ((Behaviour) component8).enabled = false;
      ((Behaviour) component8).enabled = true;
    }
    UIText component9 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component9 != (UnityEngine.Object) null && ((Behaviour) component9).enabled)
    {
      ((Behaviour) component9).enabled = false;
      ((Behaviour) component9).enabled = true;
    }
    UIText component10 = this.AGS_Form.GetChild(10).GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component10 != (UnityEngine.Object) null && ((Behaviour) component10).enabled)
    {
      ((Behaviour) component10).enabled = false;
      ((Behaviour) component10).enabled = true;
    }
    UIText component11 = this.AGS_Form.GetChild(10).GetChild(2).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component11 != (UnityEngine.Object) null && ((Behaviour) component11).enabled)
    {
      ((Behaviour) component11).enabled = false;
      ((Behaviour) component11).enabled = true;
    }
    UIText component12 = this.AGS_Form.GetChild(10).GetChild(3).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component12 != (UnityEngine.Object) null && ((Behaviour) component12).enabled)
    {
      ((Behaviour) component12).enabled = false;
      ((Behaviour) component12).enabled = true;
    }
    UIText component13 = this.AGS_Form.GetChild(10).GetChild(4).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component13 != (UnityEngine.Object) null && ((Behaviour) component13).enabled)
    {
      ((Behaviour) component13).enabled = false;
      ((Behaviour) component13).enabled = true;
    }
    UIText component14 = this.AGS_Form.GetChild(10).GetChild(10).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component14 != (UnityEngine.Object) null && ((Behaviour) component14).enabled)
    {
      ((Behaviour) component14).enabled = false;
      ((Behaviour) component14).enabled = true;
    }
    UIText component15 = this.AGS_Form.GetChild(11).GetChild(0).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component15 != (UnityEngine.Object) null && ((Behaviour) component15).enabled)
    {
      ((Behaviour) component15).enabled = false;
      ((Behaviour) component15).enabled = true;
    }
    UIText component16 = this.AGS_Form.GetChild(11).GetChild(0).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component16 != (UnityEngine.Object) null && ((Behaviour) component16).enabled)
    {
      ((Behaviour) component16).enabled = false;
      ((Behaviour) component16).enabled = true;
    }
    UIText component17 = this.AGS_Form.GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component17 != (UnityEngine.Object) null && ((Behaviour) component17).enabled)
    {
      ((Behaviour) component17).enabled = false;
      ((Behaviour) component17).enabled = true;
    }
    UIText component18 = this.AGS_Form.GetChild(11).GetChild(1).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component18 != (UnityEngine.Object) null && ((Behaviour) component18).enabled)
    {
      ((Behaviour) component18).enabled = false;
      ((Behaviour) component18).enabled = true;
    }
    UIText component19 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(4).GetComponent<UIText>();
    if ((UnityEngine.Object) component19 != (UnityEngine.Object) null && ((Behaviour) component19).enabled)
    {
      ((Behaviour) component19).enabled = false;
      ((Behaviour) component19).enabled = true;
    }
    UIText component20 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component20 != (UnityEngine.Object) null && ((Behaviour) component20).enabled)
    {
      ((Behaviour) component20).enabled = false;
      ((Behaviour) component20).enabled = true;
    }
    UIText component21 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(2).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component21 != (UnityEngine.Object) null && ((Behaviour) component21).enabled)
    {
      ((Behaviour) component21).enabled = false;
      ((Behaviour) component21).enabled = true;
    }
    UIText component22 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(3).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component22 != (UnityEngine.Object) null && ((Behaviour) component22).enabled)
    {
      ((Behaviour) component22).enabled = false;
      ((Behaviour) component22).enabled = true;
    }
    UIText component23 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(4).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component23 != (UnityEngine.Object) null && ((Behaviour) component23).enabled)
    {
      ((Behaviour) component23).enabled = false;
      ((Behaviour) component23).enabled = true;
    }
    UIText component24 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(5).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component24 != (UnityEngine.Object) null && ((Behaviour) component24).enabled)
    {
      ((Behaviour) component24).enabled = false;
      ((Behaviour) component24).enabled = true;
    }
    UIText component25 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(6).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component25 != (UnityEngine.Object) null && ((Behaviour) component25).enabled)
    {
      ((Behaviour) component25).enabled = false;
      ((Behaviour) component25).enabled = true;
    }
    UIText component26 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component26 != (UnityEngine.Object) null && ((Behaviour) component26).enabled)
    {
      ((Behaviour) component26).enabled = false;
      ((Behaviour) component26).enabled = true;
    }
    UIText component27 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component27 != (UnityEngine.Object) null && ((Behaviour) component27).enabled)
    {
      ((Behaviour) component27).enabled = false;
      ((Behaviour) component27).enabled = true;
    }
    UIText component28 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(10).GetComponent<UIText>();
    if ((UnityEngine.Object) component28 != (UnityEngine.Object) null && ((Behaviour) component28).enabled)
    {
      ((Behaviour) component28).enabled = false;
      ((Behaviour) component28).enabled = true;
    }
    if (!((UnityEngine.Object) this.AGS_ScrollPanel != (UnityEngine.Object) null) || !this.AGS_ScrollPanel.gameObject.activeInHierarchy || this.AGS_ScrollPanel.transform.childCount <= 1)
      return;
    Transform child1 = this.AGS_ScrollPanel.transform.GetChild(0);
    for (int index = 0; index < child1.childCount; ++index)
    {
      Transform child2 = child1.GetChild(index);
      if ((UnityEngine.Object) child2 != (UnityEngine.Object) null && child2.gameObject.activeInHierarchy && child2.childCount > 1)
      {
        UIText component29 = child2.GetChild(0).GetComponent<UIText>();
        if ((UnityEngine.Object) component29 != (UnityEngine.Object) null && ((Behaviour) component29).enabled)
        {
          ((Behaviour) component29).enabled = false;
          ((Behaviour) component29).enabled = true;
        }
      }
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 1:
        uint Serial = 0;
        if (this.currentColor > (byte) 1)
          Serial = this.DM.mLordEquip.LordEquip[(int) UIAnvil.preSetIndex].SerialNO;
        this.DM.mLordEquip.CombineEquip(UIAnvil.preSetID, Serial);
        break;
      case 2:
        uint num = 0;
        if (this.currentColor > (byte) 1)
          num = this.DM.mLordEquip.LordEquip[(int) UIAnvil.preSetIndex].SerialNO;
        if (GUIManager.Instance.OpenCheckCrystal(this.NeedDiamon, (byte) 6, (int) UIAnvil.preSetID, (int) num))
          break;
        this.DM.mLordEquip.QuickCombine(UIAnvil.preSetID, num);
        break;
      case 3:
        MallManager.Instance.Send_Mall_Info();
        break;
      case 4:
        ushort itemQuantity = LordEquipData.getItemQuantity(this.SelectMatID, (byte) ((uint) this.SelectMatColor - 1U));
        if (itemQuantity < (ushort) 4)
        {
          GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7455U), (ushort) byte.MaxValue);
          break;
        }
        this.DM.mLordEquip.upgradeMaterial(this.SelectMatID, this.SelectMatColor, (ushort) ((uint) itemQuantity / 4U));
        break;
      case 5:
        LordEquipData.CancelCombine();
        break;
    }
  }

  private void AfterLoader()
  {
    this.isLoading = this.DM.mLordEquip.LoadLEMaterial();
    if (this.isLoading)
      return;
    GUIManager.Instance.InitLordEquipImg(((Component) this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UILEBtn>()).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    for (int index = 0; index < 5; ++index)
    {
      UILEBtn component = this.AGS_Form.GetChild(7).GetChild(0 + index).GetComponent<UILEBtn>();
      GUIManager.Instance.InitLordEquipImg(((Component) component).transform, (ushort) 0, (byte) 0, setScale: true, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      component.m_Handler = (IUILEBtnClickHandler) this;
    }
    for (int index = 0; index < 5; ++index)
    {
      UILEBtn component = this.AGS_Form.GetChild(10).GetChild(0 + index).GetComponent<UILEBtn>();
      GUIManager.Instance.InitLordEquipImg(((Component) component).transform, (ushort) 0, (byte) 0, setScale: true, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      component.m_Handler = (IUILEBtnClickHandler) this;
    }
    UILEBtn component1 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(2).GetComponent<UILEBtn>();
    GUIManager.Instance.InitLordEquipImg(((Component) component1).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    component1.m_Handler = (IUILEBtnClickHandler) this;
    for (int index = 0; index < 5; ++index)
    {
      UILEBtn component2 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(2 + index).GetComponent<UILEBtn>();
      GUIManager.Instance.InitLordEquipImg(((Component) component2).transform, (ushort) 0, (byte) 0, setScale: true, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      component2.m_Handler = (IUILEBtnClickHandler) this;
    }
    this.AGS_ScrollPanel.IntiScrollPanel(274f, 0.0f, 0.0f, this.SPHeight, 6, (IUpDateScrollPanel) this);
    this.SetOpenKind(UIAnvil.OpenKind);
    switch (UIAnvil.OpenKind)
    {
      case eUI_Anvil_OpenKind.ForgeNewItem:
        if (UIAnvil.returnColor == (byte) 0)
        {
          this.currentColor = this.preSetColor;
          this.SetView(UIAnvil.preSetID, this.currentColor);
        }
        else
        {
          this.currentColor = UIAnvil.returnColor;
          UIAnvil.preSetID = UIAnvil.returnID;
          this.SetView(UIAnvil.returnID, this.currentColor);
        }
        this.SetSideItem();
        break;
      case eUI_Anvil_OpenKind.UpgradeItem:
        UIAnvil.preSetID = this.DM.mLordEquip.LordEquip[(int) UIAnvil.preSetIndex].ItemID;
        this.preSetColor = (byte) ((uint) this.DM.mLordEquip.LordEquip[(int) UIAnvil.preSetIndex].Color + 1U);
        this.currentColor = this.preSetColor;
        this.SetView(UIAnvil.preSetID, this.preSetColor);
        this.SetSideItem();
        break;
      case eUI_Anvil_OpenKind.NowForging:
        UIAnvil.preSetID = this.DM.RoleAttr.LordEquipEventData.ItemID;
        this.preSetColor = this.DM.RoleAttr.LordEquipEventData.Color;
        this.currentColor = this.DM.RoleAttr.LordEquipEventData.Color;
        if (UIAnvil.preSetID == (ushort) 0)
          this.door.CloseMenu();
        if (this.DM.RoleAttr.LordEquipEventData.SerialNO != 0U && (int) this.DM.mLordEquip.LordEquip[(int) UIAnvil.preSetIndex].SerialNO != (int) this.DM.RoleAttr.LordEquipEventData.SerialNO)
        {
          for (ushort index = 0; (int) index < (int) this.DM.RoleAttr.LordEquipBagSize; ++index)
          {
            if ((int) this.DM.mLordEquip.LordEquip[(int) index].SerialNO == (int) this.DM.RoleAttr.LordEquipEventData.SerialNO)
              UIAnvil.preSetIndex = index;
          }
        }
        this.SetView(this.DM.RoleAttr.LordEquipEventData.ItemID, this.DM.RoleAttr.LordEquipEventData.Color);
        this.SetSideItem();
        this.StartForge(true);
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        switch (sender.m_BtnID2)
        {
          case 0:
            this.door.CloseMenu();
            return;
          case 1:
            LordEquipData.OpenItemSource(UIAnvil.preSetID);
            UIAnvil.returnColor = this.currentColor;
            UIAnvil.returnID = UIAnvil.preSetID;
            return;
          case 2:
            this.SetView(UIAnvil.preSetID, this.currentColor);
            return;
          default:
            return;
        }
      case 1:
        uint Serial = 0;
        if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.ForgeNewItem && this.currentColor > (byte) 1)
        {
          int firstIndex = this.GetFirstIndex(UIAnvil.preSetID, (byte) ((uint) this.currentColor - 1U));
          if (firstIndex < 0)
          {
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7443U), (ushort) byte.MaxValue);
            break;
          }
          UIAnvil.preSetIndex = (ushort) firstIndex;
        }
        if (this.currentColor > (byte) 1)
          Serial = this.DM.mLordEquip.LordEquip[(int) UIAnvil.preSetIndex].SerialNO;
        switch (sender.m_BtnID2)
        {
          case 1:
            if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.UpgradeItem && (int) this.currentColor != (int) this.preSetColor)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7536U), (ushort) byte.MaxValue);
              return;
            }
            if (!this.isCombineReady((int) UIAnvil.preSetIndex, UIAnvil.preSetID, this.currentColor, false, true))
              return;
            if (this.DM.mLordEquip.isRoleEquipThis(Serial))
            {
              GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(7475U), this.DM.mStringTable.GetStringByID(7498U), 1);
              return;
            }
            this.DM.mLordEquip.CombineEquip(UIAnvil.preSetID, Serial);
            return;
          case 2:
            if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.UpgradeItem && (int) this.currentColor != (int) this.preSetColor)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7536U), (ushort) byte.MaxValue);
              return;
            }
            if (!this.isCombineReady((int) UIAnvil.preSetIndex, UIAnvil.preSetID, this.currentColor, true, true))
              return;
            this.PopString.ClearString();
            this.PopString.StringToFormat(this.moneyCost);
            if (this.DM.mLordEquip.isRoleEquipThis(Serial))
            {
              this.PopString.AppendFormat(this.DM.mStringTable.GetStringByID(7500U));
              GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(7502U), this.PopString.ToString(), 2);
              return;
            }
            this.PopString.AppendFormat(this.DM.mStringTable.GetStringByID(7499U));
            GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(7502U), this.PopString.ToString(), 2);
            return;
          default:
            return;
        }
      case 2:
        switch (sender.m_BtnID2)
        {
          case 1:
            if (LordEquipData.getItemQuantity(this.SelectMatID, (byte) ((uint) this.SelectMatColor - 1U)) < (ushort) 4)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7455U), (ushort) byte.MaxValue);
              return;
            }
            this.DM.mLordEquip.upgradeMaterial(this.SelectMatID, this.SelectMatColor, (ushort) 1);
            return;
          case 2:
            GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(7450U), this.DM.mStringTable.GetStringByID(7452U), 4);
            return;
          default:
            return;
        }
      case 3:
        switch (sender.m_BtnID2)
        {
          case 1:
            this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 18);
            UIAnvil.returnColor = this.currentColor;
            UIAnvil.returnID = UIAnvil.preSetID;
            return;
          case 2:
            GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(7514U), this.DM.mStringTable.GetStringByID(7513U), 5);
            return;
          default:
            return;
        }
      case 4:
        this.AGS_Form.GetChild(12).gameObject.SetActive(false);
        this.SetView(UIAnvil.preSetID, this.currentColor);
        break;
      case 5:
        switch (sender.m_BtnID2)
        {
          case 1:
            if (this.isCombine)
            {
              if (LordEquipData.getItemQuantity(this.SelectMatID, (byte) ((uint) this.SelectMatColor - 1U)) < (ushort) 4)
              {
                GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455U), (ushort) byte.MaxValue);
                return;
              }
              if ((int) this.MaterCount[(int) this.SelectMatColor - 1] + 1 > (int) ushort.MaxValue)
              {
                GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7524U), (ushort) byte.MaxValue);
                return;
              }
              this.DM.mLordEquip.upgradeMaterial(this.SelectMatID, this.SelectMatColor, (ushort) 1);
              return;
            }
            if (LordEquipData.getItemQuantity(this.SelectMatID, (byte) ((uint) this.SelectMatColor + 1U)) < (ushort) 1)
            {
              GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455U), (ushort) byte.MaxValue);
              return;
            }
            if ((int) this.MaterCount[(int) this.SelectMatColor - 1] + 4 > (int) ushort.MaxValue)
            {
              GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7509U), (ushort) byte.MaxValue);
              return;
            }
            this.DM.mLordEquip.DeComposeMaterial(this.SelectMatID, (byte) ((uint) this.SelectMatColor + 1U), (ushort) 1);
            return;
          case 2:
            if (this.isCombine)
            {
              int itemQuantity = (int) LordEquipData.getItemQuantity(this.SelectMatID, (byte) ((uint) this.SelectMatColor - 1U));
              if (itemQuantity < 4)
              {
                GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455U), (ushort) byte.MaxValue);
                return;
              }
              int Quantity = (int) (ushort) (itemQuantity / 4);
              if ((int) this.MaterCount[(int) this.SelectMatColor - 1] + Quantity > (int) ushort.MaxValue)
              {
                Quantity = (int) ushort.MaxValue - (int) this.MaterCount[(int) this.SelectMatColor - 1];
                if (Quantity < 1)
                {
                  GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7524U), (ushort) byte.MaxValue);
                  return;
                }
              }
              this.DM.mLordEquip.upgradeMaterial(this.SelectMatID, this.SelectMatColor, (ushort) Quantity);
              return;
            }
            int Quantity1 = (int) LordEquipData.getItemQuantity(this.SelectMatID, (byte) ((uint) this.SelectMatColor + 1U));
            if (Quantity1 < 1)
            {
              GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455U), (ushort) byte.MaxValue);
              return;
            }
            if ((int) this.MaterCount[(int) this.SelectMatColor - 1] + Quantity1 * 4 > (int) ushort.MaxValue)
            {
              Quantity1 = ((int) ushort.MaxValue - (int) this.MaterCount[(int) this.SelectMatColor - 1]) / 4;
              if (Quantity1 < 1)
              {
                GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7509U), (ushort) byte.MaxValue);
                return;
              }
            }
            this.DM.mLordEquip.DeComposeMaterial(this.SelectMatID, (byte) ((uint) this.SelectMatColor + 1U), (ushort) Quantity1);
            return;
          default:
            return;
        }
      case 6:
        switch (sender.m_BtnID2)
        {
          case 1:
            this.isCombine = true;
            this.SetPopUp(this.SelectMatColor);
            return;
          case 2:
            this.isCombine = false;
            this.SetPopUp(this.SelectMatColor);
            return;
          default:
            return;
        }
      case 7:
        this.door.OpenMenu(EGUIWindow.UI_BagFilter, 589825, (int) (uint) Math.Ceiling((double) this.DM.EquipTable.GetRecordByKey(UIAnvil.preSetID).MixPrice * this.DM.mLordEquip.forgeGold[(int) this.currentColor]));
        UIAnvil.returnColor = this.currentColor;
        UIAnvil.returnID = UIAnvil.preSetID;
        break;
      case 99:
        GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7430U), DataManager.Instance.mStringTable.GetStringByID(7527U), bInfo: true);
        break;
    }
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
    if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.NowForging)
      return;
    switch (sender.m_BtnID1)
    {
      case 1:
        this.SelectMatColor = (byte) sender.m_BtnID4;
        this.SetView((ushort) sender.m_BtnID3, (byte) sender.m_BtnID4);
        break;
      case 2:
        this.isCombine = true;
        this.SelectMatID = (ushort) sender.m_BtnID3;
        this.SelectMatColor = (byte) sender.m_BtnID4;
        this.SelectMatReqNum = (ushort) sender.m_BtnID2;
        this.SetPopUp((byte) sender.m_BtnID4);
        break;
      case 3:
        UILordEquip.itemIDFilter = (ushort) sender.m_BtnID3;
        UILordEquip.itemColorFilter = (ushort) sender.m_BtnID4;
        this.door.OpenMenu(EGUIWindow.UI_LordEquip, 2);
        UIAnvil.returnColor = this.currentColor;
        UIAnvil.returnID = UIAnvil.preSetID;
        break;
      case 4:
        this.SelectMatColor = (byte) sender.m_BtnID4;
        this.SetPopUp((byte) sender.m_BtnID4);
        break;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    Effect recordByKey = this.DM.EffectData.GetRecordByKey(this.effectList[dataIdx].EffectID);
    UIText component = item.transform.GetChild(0).GetComponent<UIText>();
    this.EffDescText[panelObjectIdx].ClearString();
    this.EffDescText[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey.InfoID));
    this.EffDescText[panelObjectIdx].StringToFormat("<color=#35F76CFF>+");
    if (recordByKey.ValueID == (ushort) 0)
    {
      this.EffDescText[panelObjectIdx].IntToFormat((long) this.effectList[dataIdx].EffectValue);
      this.EffDescText[panelObjectIdx].AppendFormat("<color=#FFEC87FF>{0}</color> {1}{2}</color>");
    }
    else
    {
      float f = (float) this.effectList[dataIdx].EffectValue / 100f;
      this.EffDescText[panelObjectIdx].FloatToFormat(f, 2, false);
      this.EffDescText[panelObjectIdx].AppendFormat("<color=#FFEC87FF>{0}</color> {1}{2}%</color>");
    }
    component.text = this.EffDescText[panelObjectIdx].ToString();
    if (!GameConstants.IsBigStyle())
      component.resizeTextMaxSize = 16;
    component.SetAllDirty();
    component.cachedTextGenerator.Invalidate();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void SetView(ushort ItemID, byte color)
  {
    bool flag = false;
    if (color == (byte) 6)
    {
      color = (byte) 5;
      flag = true;
    }
    Equip recordByKey = this.DM.EquipTable.GetRecordByKey(ItemID);
    GUIManager.Instance.ChangeLordEquipImg(((Component) this.AGS_Form.GetChild(8).GetChild(0).GetComponent<UILEBtn>()).transform, ItemID, color, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    UIText component1 = this.AGS_Form.GetChild(8).GetChild(1).GetComponent<UIText>();
    this.focusName.ClearString();
    this.focusName.Append(GameConstants.SItemRareHeader[(int) color]);
    this.focusName.Append(this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipName));
    this.focusName.Append("</color>");
    component1.text = this.focusName.ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    this.currentColor = color;
    if (flag)
    {
      this.AGS_Form.GetChild(10).gameObject.SetActive(false);
      this.AGS_Form.GetChild(11).gameObject.SetActive(false);
      this.AGS_Form.GetChild(9).gameObject.SetActive(true);
      this.AGS_Form.GetChild(7).gameObject.SetActive(false);
      this.AGS_Form.GetChild(9).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7477U);
      for (int index = 1; index < this.AGS_Form.GetChild(9).childCount; ++index)
        this.AGS_Form.GetChild(9).gameObject.SetActive(false);
    }
    else
    {
      if (recordByKey.EquipKind != (byte) 20)
      {
        this.SetSideItem();
        if (this.DM.RoleAttr.LordEquipEventData.ItemID != (ushort) 0)
        {
          this.AGS_Form.GetChild(10).gameObject.SetActive(true);
          this.AGS_Form.GetChild(11).gameObject.SetActive(false);
          this.AGS_Form.GetChild(9).gameObject.SetActive(true);
          this.SetForgingTimeBar();
        }
        else
        {
          this.AGS_Form.GetChild(10).gameObject.SetActive(true);
          this.AGS_Form.GetChild(11).gameObject.SetActive(true);
          this.AGS_Form.GetChild(9).gameObject.SetActive(false);
        }
        this.AGS_Form.GetChild(7).gameObject.SetActive(UIAnvil.OpenKind != eUI_Anvil_OpenKind.NowForging);
        for (int index = 0; index < 4; ++index)
        {
          UILEBtn component2 = this.AGS_Form.GetChild(10).GetChild(0 + index).GetComponent<UILEBtn>();
          if (recordByKey.SyntheticParts[index].SyntheticItem == (ushort) 0)
          {
            ((Component) component2).gameObject.SetActive(false);
            GUIManager.Instance.ChangeLordEquipImg(((Component) component2).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
            component2.m_BtnID1 = 0;
            ((Component) component2).transform.GetChild(0).GetComponent<UIText>().text = string.Empty;
            this.AGS_Form.GetChild(10).GetChild(5 + index).gameObject.SetActive(false);
          }
          else
          {
            ((Component) component2).gameObject.SetActive(true);
            GUIManager.Instance.ChangeLordEquipImg(((Component) component2).transform, recordByKey.SyntheticParts[index].SyntheticItem, color, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
            component2.m_BtnID1 = 2;
            component2.m_BtnID2 = (int) recordByKey.SyntheticParts[index].SyntheticItemNum;
            component2.m_BtnID3 = (int) recordByKey.SyntheticParts[index].SyntheticItem;
            component2.m_BtnID4 = (int) color;
            UIText component3 = ((Component) component2).transform.GetChild(0).GetComponent<UIText>();
            this.RequestCount[index].ClearString();
            ushort itemQuantity = LordEquipData.getItemQuantity(recordByKey.SyntheticParts[index].SyntheticItem, color);
            if (UIAnvil.OpenKind != eUI_Anvil_OpenKind.NowForging)
            {
              if ((int) itemQuantity < (int) recordByKey.SyntheticParts[index].SyntheticItemNum)
              {
                this.RequestCount[index].StringToFormat("<color=#FF5581FF>");
                if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.UpgradeItem && (int) color != (int) this.preSetColor)
                  this.AGS_Form.GetChild(10).GetChild(5 + index).gameObject.SetActive(false);
                else
                  this.AGS_Form.GetChild(10).GetChild(5 + index).gameObject.SetActive(true);
              }
              else
              {
                this.RequestCount[index].StringToFormat("<color=#FFFFFFFF>");
                this.AGS_Form.GetChild(10).GetChild(5 + index).gameObject.SetActive(false);
              }
              this.RequestCount[index].IntToFormat((long) itemQuantity, bNumber: true);
              this.RequestCount[index].IntToFormat((long) recordByKey.SyntheticParts[index].SyntheticItemNum);
              if (!GUIManager.Instance.IsArabic)
                this.RequestCount[index].AppendFormat("{0}{1}</color> / {2}");
              else
                this.RequestCount[index].AppendFormat("{2} / {0}{1}</color>");
              component3.text = this.RequestCount[index].ToString();
            }
            else
            {
              this.AGS_Form.GetChild(10).GetChild(5 + index).gameObject.SetActive(false);
              component3.text = string.Empty;
            }
            component3.SetAllDirty();
            component3.cachedTextGenerator.Invalidate();
          }
        }
        UILEBtn component4 = this.AGS_Form.GetChild(10).GetChild(4).GetComponent<UILEBtn>();
        UIText component5 = ((Component) component4).transform.GetChild(0).GetComponent<UIText>();
        if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.NowForging && color > (byte) 1 || UIAnvil.OpenKind == eUI_Anvil_OpenKind.UpgradeItem && (int) color == (int) this.preSetColor)
        {
          ((Component) component4).gameObject.SetActive(true);
          if (this.DM.mLordEquip.LordEquip[(int) UIAnvil.preSetIndex].haveGem())
            GUIManager.Instance.ChangeLordEquipImg(((Component) component4).transform, this.DM.mLordEquip.LordEquip[(int) UIAnvil.preSetIndex]);
          else
            GUIManager.Instance.ChangeLordEquipImg(((Component) component4).transform, this.DM.mLordEquip.LordEquip[(int) UIAnvil.preSetIndex], eLordEquipDisplayKind.OnlyItem);
          component4.m_BtnID1 = 0;
          component4.m_BtnID3 = (int) ItemID;
          component4.m_BtnID4 = (int) color - 1;
          this.RequestCount[4].ClearString();
          this.AGS_Form.GetChild(10).GetChild(9).gameObject.SetActive(false);
          component5.text = string.Empty;
        }
        else if (color > (byte) 1)
        {
          ((Component) component4).gameObject.SetActive(true);
          GUIManager.Instance.ChangeLordEquipImg(((Component) component4).transform, ItemID, (byte) ((uint) color - 1U), gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
          component4.m_BtnID1 = 1;
          component4.m_BtnID3 = (int) ItemID;
          component4.m_BtnID4 = (int) color - 1;
          this.RequestCount[4].ClearString();
          ushort itemQuantity = LordEquipData.getItemQuantity(ItemID, (byte) ((uint) color - 1U));
          if (itemQuantity < (ushort) 1)
          {
            this.RequestCount[4].StringToFormat("<color=#FF5581FF>");
            this.AGS_Form.GetChild(10).GetChild(9).gameObject.SetActive(false);
          }
          else
          {
            this.RequestCount[4].StringToFormat("<color=#FFFFFFFF>");
            int firstIndex = this.GetFirstIndex(ItemID, (byte) ((uint) color - 1U));
            if (this.DM.mLordEquip.LordEquip[firstIndex].haveGem())
              GUIManager.Instance.ChangeLordEquipImg(((Component) component4).transform, this.DM.mLordEquip.LordEquip[firstIndex]);
            else
              GUIManager.Instance.ChangeLordEquipImg(((Component) component4).transform, this.DM.mLordEquip.LordEquip[firstIndex], eLordEquipDisplayKind.OnlyItem);
            if (itemQuantity > (ushort) 1 && UIAnvil.OpenKind != eUI_Anvil_OpenKind.UpgradeItem)
            {
              this.AGS_Form.GetChild(10).GetChild(9).gameObject.SetActive(true);
              component4.m_BtnID1 = 3;
            }
            else
              this.AGS_Form.GetChild(10).GetChild(9).gameObject.SetActive(false);
          }
          this.RequestCount[4].IntToFormat((long) itemQuantity, bNumber: true);
          if (!GUIManager.Instance.IsArabic)
            this.RequestCount[4].AppendFormat("{0}{1}</color> / 1");
          else
            this.RequestCount[4].AppendFormat("1 / {0}{1}</color>");
          component5.text = this.RequestCount[4].ToString();
          component5.SetAllDirty();
          component5.cachedTextGenerator.Invalidate();
        }
        else
        {
          component5.text = string.Empty;
          ((Component) component4).gameObject.SetActive(false);
          this.AGS_Form.GetChild(10).GetChild(9).gameObject.SetActive(false);
        }
        if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.NowForging)
          this.AGS_Form.GetChild(10).GetChild(10).gameObject.SetActive(false);
        else
          this.AGS_Form.GetChild(10).GetChild(10).gameObject.SetActive(true);
        this.ShowMoney();
      }
      else
      {
        this.SelectMatID = ItemID;
        this.isCombine = true;
        this.SetPopUp(color);
      }
      for (int index = 0; index < 5; ++index)
      {
        UILEBtn component6 = this.AGS_Form.GetChild(7).GetChild(0 + index).GetComponent<UILEBtn>();
        switch (UIAnvil.OpenKind)
        {
          case eUI_Anvil_OpenKind.ForgeNewItem:
            if (recordByKey.EquipKind == (byte) 20 && index + 1 < (int) color)
            {
              ((Component) component6).gameObject.SetActive(false);
              component6.m_BtnID1 = 0;
              break;
            }
            ((Component) component6).gameObject.SetActive(true);
            GUIManager.Instance.ChangeLordEquipImg(((Component) component6).transform, UIAnvil.preSetID, (byte) (index + 1), gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
            component6.m_BtnID1 = 1;
            component6.m_BtnID3 = (int) UIAnvil.preSetID;
            component6.m_BtnID4 = index + 1;
            break;
          case eUI_Anvil_OpenKind.UpgradeItem:
            if (index + 1 < (int) this.preSetColor)
            {
              ((Component) component6).gameObject.SetActive(false);
              component6.m_BtnID1 = 0;
              break;
            }
            ((Component) component6).gameObject.SetActive(true);
            GUIManager.Instance.ChangeLordEquipImg(((Component) component6).transform, UIAnvil.preSetID, (byte) (index + 1), gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
            component6.m_BtnID1 = 1;
            component6.m_BtnID3 = (int) UIAnvil.preSetID;
            component6.m_BtnID4 = index + 1;
            break;
        }
      }
      if (recordByKey.EquipKind == (byte) 20)
      {
        this.AGS_Form.GetChild(7).GetChild(6).gameObject.SetActive(true);
        UILEBtn component7 = this.AGS_Form.GetChild(7).GetChild(0 + (int) color - 2).GetComponent<UILEBtn>();
        ((Component) component7).gameObject.SetActive(true);
        GUIManager.Instance.ChangeLordEquipImg(((Component) component7).transform, ItemID, color, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        component7.m_BtnID1 = 1;
        component7.m_BtnID3 = (int) ItemID;
        component7.m_BtnID4 = (int) color;
        this.AGS_Form.GetChild(7).GetChild(5).GetComponent<RectTransform>().anchoredPosition = ((Component) component7).transform.GetComponent<RectTransform>().anchoredPosition;
      }
      else
      {
        this.AGS_Form.GetChild(7).GetChild(6).gameObject.SetActive(false);
        this.AGS_Form.GetChild(7).GetChild(5).GetComponent<RectTransform>().anchoredPosition = this.AGS_Form.GetChild(7).GetChild(0 + (int) color - 1).GetComponent<RectTransform>().anchoredPosition;
      }
    }
  }

  public void SetPopUp(byte color)
  {
    this.SetPopupFunction(this.isCombine);
    this.GetMaterialRareCount(this.SelectMatID);
    if (this.isCombine)
    {
      if (!GameConstants.IsBetween((int) this.SelectMatColor, 2, 5))
        this.SelectMatColor = (byte) 2;
    }
    else if (!GameConstants.IsBetween((int) this.SelectMatColor, 1, 4))
      this.SelectMatColor = (byte) 4;
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(this.SelectMatID);
    GUIManager.Instance.ChangeLordEquipImg((Transform) this.AGS_Form.GetChild(12).GetChild(0).GetChild(2).GetComponent<RectTransform>(), this.SelectMatID, this.currentColor, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    this.AGS_Form.GetChild(12).GetChild(0).GetChild(10).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipInfo);
    UIText component1 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(4).GetComponent<UIText>();
    this.PopUpHeaderText.ClearString();
    this.PopUpHeaderText.Append(GameConstants.SItemRareHeader[(int) this.currentColor]);
    this.PopUpHeaderText.Append(this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipName));
    this.PopUpHeaderText.Append("</color>");
    component1.text = this.PopUpHeaderText.ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    this.AGS_Form.GetChild(12).GetChild(0).GetChild(5).GetComponent<UISpritesArray>().SetSpriteIndex((int) this.currentColor - 1);
    if (this.isCombine)
    {
      for (int index = 0; index < 5; ++index)
      {
        UILEBtn component2 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(2 + index).GetComponent<UILEBtn>();
        UIText component3 = ((Component) component2).transform.GetChild(0).GetComponent<UIText>();
        ((Component) component2).gameObject.SetActive(true);
        GUIManager.Instance.ChangeLordEquipImg(((Component) component2).transform, this.SelectMatID, (byte) (index + 1), gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        component2.m_BtnID1 = 4;
        component2.m_BtnID3 = (int) this.SelectMatID;
        component2.m_BtnID4 = index + 1;
        this.CombineCount[index].ClearString();
        if (index + 2 != (int) this.SelectMatColor)
        {
          this.CombineCount[index].IntToFormat((long) this.MaterCount[index], bNumber: true);
          this.CombineCount[index].AppendFormat("{0:N}");
        }
        else
        {
          UIText component4 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetChild(0).GetComponent<UIText>();
          RectTransform component5 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetComponent<RectTransform>();
          ushort x = this.MaterCount[index];
          if (x < (ushort) 4)
          {
            this.CombineCount[index].StringToFormat("<color=#FF5581FF>");
            ((Graphic) component4).color = (Color) new Color32(byte.MaxValue, (byte) 85, (byte) 129, byte.MaxValue);
          }
          else
          {
            this.CombineCount[index].StringToFormat("<color=#FFFFFFFF>");
            ((Graphic) component4).color = Color.white;
          }
          this.CombineCount[index].IntToFormat((long) x, bNumber: true);
          if (!GUIManager.Instance.IsArabic)
            this.CombineCount[index].AppendFormat("{0}{1}</color> / 4");
          else
            this.CombineCount[index].AppendFormat("4 / {0}{1}</color>");
          if (this.MaterCount[index] >= (ushort) 8)
          {
            this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).gameObject.SetActive(true);
            component5.anchoredPosition = new Vector2(115f, -230.5f);
          }
          else
          {
            this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).gameObject.SetActive(false);
            component5.anchoredPosition = new Vector2(0.0f, -230.5f);
          }
        }
        component3.text = this.CombineCount[index].ToString();
        component3.SetAllDirty();
        component3.cachedTextGenerator.Invalidate();
      }
    }
    else
    {
      for (int index = 0; index < 5; ++index)
      {
        UILEBtn component6 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(2 + index).GetComponent<UILEBtn>();
        UIText component7 = ((Component) component6).transform.GetChild(0).GetComponent<UIText>();
        ((Component) component6).gameObject.SetActive(true);
        GUIManager.Instance.ChangeLordEquipImg(((Component) component6).transform, this.SelectMatID, (byte) (index + 1), gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        component6.m_BtnID1 = 4;
        component6.m_BtnID3 = (int) this.SelectMatID;
        component6.m_BtnID4 = index + 1;
        this.CombineCount[index].ClearString();
        if (index != (int) this.SelectMatColor)
        {
          this.CombineCount[index].IntToFormat((long) this.MaterCount[index], bNumber: true);
          this.CombineCount[index].AppendFormat("{0:N}");
        }
        else
        {
          UIText component8 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetChild(0).GetComponent<UIText>();
          RectTransform component9 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetComponent<RectTransform>();
          ushort x = this.MaterCount[index];
          if (x < (ushort) 1)
          {
            this.CombineCount[index].StringToFormat("<color=#FF5581FF>");
            ((Graphic) component8).color = (Color) new Color32(byte.MaxValue, (byte) 85, (byte) 129, byte.MaxValue);
          }
          else
          {
            this.CombineCount[index].StringToFormat("<color=#FFFFFFFF>");
            ((Graphic) component8).color = Color.white;
          }
          this.CombineCount[index].IntToFormat((long) x, bNumber: true);
          if (!GUIManager.Instance.IsArabic)
            this.CombineCount[index].AppendFormat("{0}{1}</color> / 1");
          else
            this.CombineCount[index].AppendFormat("1 / {0}{1}</color>");
          if (this.MaterCount[index] >= (ushort) 2)
          {
            this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).gameObject.SetActive(true);
            component9.anchoredPosition = new Vector2(115f, -230.5f);
          }
          else
          {
            this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).gameObject.SetActive(false);
            component9.anchoredPosition = new Vector2(0.0f, -230.5f);
          }
        }
        component7.text = this.CombineCount[index].ToString();
        component7.SetAllDirty();
        component7.cachedTextGenerator.Invalidate();
      }
    }
    RectTransform component10 = this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetComponent<RectTransform>();
    Vector2 vector2 = !this.isCombine ? this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(2 + (int) this.SelectMatColor).GetComponent<RectTransform>().anchoredPosition : this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(2 + (int) this.SelectMatColor - 1).GetComponent<RectTransform>().anchoredPosition;
    vector2.x -= 152f;
    vector2.y = component10.anchoredPosition.y;
    component10.anchoredPosition = vector2;
    if (!this.isLowerMaterialEnough(this.currentColor, this.SelectMatReqNum) && this.isHigherMaterialEnough(this.currentColor, this.SelectMatReqNum))
      this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(8).gameObject.SetActive(true);
    else
      this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(8).gameObject.SetActive(false);
    this.AGS_Form.GetChild(12).gameObject.SetActive(true);
  }

  private void SetPopupFunction(bool isCombine)
  {
    this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).gameObject.SetActive(true);
    this.isCombine = isCombine;
    if (isCombine)
    {
      this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(1).gameObject.SetActive(true);
      this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(5).gameObject.SetActive(false);
      this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7451U);
      this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7450U);
      this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7466U);
      ((Transform) this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(2).GetComponent<RectTransform>()).localScale = Vector3.one;
      ((Transform) this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(3).GetComponent<RectTransform>()).localScale = Vector3.one;
    }
    else
    {
      this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(1).gameObject.SetActive(false);
      this.AGS_Form.GetChild(12).GetChild(0).GetChild(12).GetChild(5).gameObject.SetActive(true);
      this.AGS_Form.GetChild(12).GetChild(0).GetChild(9).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(9547U);
      this.AGS_Form.GetChild(12).GetChild(0).GetChild(8).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7530U);
      this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7532U);
      ((Transform) this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(2).GetComponent<RectTransform>()).localScale = new Vector3(-1f, 1f, 1f);
      ((Transform) this.AGS_Form.GetChild(12).GetChild(0).GetChild(7).GetChild(7).GetChild(3).GetComponent<RectTransform>()).localScale = new Vector3(-1f, 1f, 1f);
    }
  }

  public void SetSideItem()
  {
    Equip recordByKey1 = this.DM.EquipTable.GetRecordByKey(UIAnvil.preSetID);
    UIText component1 = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIText>();
    this.ItemNameText.ClearString();
    this.ItemNameText.Append(GameConstants.SItemRareHeader[(int) this.currentColor]);
    this.ItemNameText.Append(this.DM.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
    this.ItemNameText.Append("</color>");
    component1.text = this.ItemNameText.ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    UIText component2 = this.AGS_Form.GetChild(6).GetChild(3).GetComponent<UIText>();
    this.ItemLevelText.ClearString();
    if ((int) recordByKey1.NeedLv > (int) this.DM.RoleAttr.Level)
    {
      CString tmpS = StringManager.Instance.StaticString1024();
      tmpS.Append("<color=#FF0000FF>");
      tmpS.IntToFormat((long) recordByKey1.NeedLv);
      tmpS.AppendFormat("{0}");
      tmpS.Append("</color>");
      this.ItemLevelText.StringToFormat(tmpS);
    }
    else
      this.ItemLevelText.IntToFormat((long) recordByKey1.NeedLv);
    this.ItemLevelText.StringToFormat(LordEquipData.GetItemKindTalkID(recordByKey1.EquipKind));
    this.ItemLevelText.AppendFormat(this.DM.mStringTable.GetStringByID(7437U));
    component2.text = this.ItemLevelText.ToString();
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
    this.AGS_RareImg.gameObject.SetActive(true);
    this.AGS_RareImg.SetSpriteIndex((int) this.currentColor - 1);
    this.effectList.Clear();
    LordEquipData.GetEffectList(UIAnvil.preSetID, this.currentColor, this.effectList);
    this.SPHeight.Clear();
    for (int index = 0; index < this.effectList.Count; ++index)
      this.SPHeight.Add(28f);
    this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeight, 274f);
    UIText component3 = this.AGS_Form.GetChild(9).GetChild(0).GetComponent<UIText>();
    if (UIAnvil.OpenKind == eUI_Anvil_OpenKind.NowForging)
    {
      this.AGS_Form.GetChild(9).GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
      component3.text = string.Empty;
      component3.SetAllDirty();
      component3.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.AGS_Form.GetChild(9).GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, -10f);
      Equip recordByKey2 = this.DM.EquipTable.GetRecordByKey(this.DM.RoleAttr.LordEquipEventData.ItemID);
      this.forgingItemName.ClearString();
      this.forgingItemName.Append(GameConstants.SItemRareHeader[(int) this.DM.RoleAttr.LordEquipEventData.Color]);
      this.forgingItemName.Append(this.DM.mStringTable.GetStringByID((uint) recordByKey2.EquipName));
      this.forgingItemName.Append("</color>");
      component3.text = this.forgingItemName.ToString();
      component3.SetAllDirty();
      component3.cachedTextGenerator.Invalidate();
    }
  }

  public void SetForgingTimeBar()
  {
    RectTransform component1 = this.AGS_Form.GetChild(9).GetChild(2).GetComponent<RectTransform>();
    UIText component2 = this.AGS_Form.GetChild(9).GetChild(4).GetComponent<UIText>();
    long sec = this.DM.RoleAttr.LordEquipEventTime.BeginTime + (long) this.DM.RoleAttr.LordEquipEventTime.RequireTime - this.DM.ServerTime;
    if (sec < 0L)
      sec = 0L;
    float num = Mathf.Min((float) (1.0 - (double) sec / (double) this.DM.RoleAttr.LordEquipEventTime.RequireTime), 1f) * 210f;
    this.timeRemain.ClearString();
    GameConstants.GetTimeString(this.timeRemain, (uint) sec, hideTimeIfDays: true, withArabic: true);
    component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num);
    component2.text = this.timeRemain.ToString();
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
    float preferredWidth = component2.preferredWidth;
    this.AGS_Form.GetChild(9).GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 200f - preferredWidth);
  }

  public void SetOpenKind(eUI_Anvil_OpenKind OpenKind)
  {
    UIAnvil.OpenKind = OpenKind;
    switch (OpenKind - 1)
    {
      case eUI_Anvil_OpenKind.None:
      case eUI_Anvil_OpenKind.ForgeNewItem:
        this.AGS_Form.GetChild(8).gameObject.SetActive(true);
        this.AGS_Form.GetChild(9).gameObject.SetActive(false);
        this.AGS_Form.GetChild(10).gameObject.SetActive(true);
        this.AGS_Form.GetChild(11).gameObject.SetActive(true);
        break;
      case eUI_Anvil_OpenKind.UpgradeItem:
        this.AGS_Form.GetChild(8).gameObject.SetActive(true);
        this.AGS_Form.GetChild(9).gameObject.SetActive(true);
        this.AGS_Form.GetChild(10).gameObject.SetActive(true);
        this.AGS_Form.GetChild(11).gameObject.SetActive(false);
        break;
    }
    switch (OpenKind - 1)
    {
      case eUI_Anvil_OpenKind.None:
      case eUI_Anvil_OpenKind.UpgradeItem:
        this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7430U);
        this.AGS_Form.GetChild(11).GetChild(0).GetChild(3).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7439U);
        this.AGS_Form.GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7440U);
        break;
      case eUI_Anvil_OpenKind.ForgeNewItem:
        this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7537U);
        this.AGS_Form.GetChild(11).GetChild(0).GetChild(3).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7535U);
        this.AGS_Form.GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7475U);
        break;
    }
  }

  private void GetMaterialRareCount(ushort itemID)
  {
    for (int index = 0; index < this.MaterCount.Length; ++index)
      this.MaterCount[index] = (ushort) 0;
    for (int index = 0; index < this.DM.mLordEquip.LEMaterial.Length; ++index)
    {
      if ((int) this.DM.mLordEquip.LEMaterial[index].ItemID == (int) itemID)
        this.MaterCount[(int) this.DM.mLordEquip.LEMaterial[index].Color - 1] = this.DM.mLordEquip.LEMaterial[index].Quantity;
    }
  }

  private bool isLowerMaterialEnough(byte color, ushort reqNum)
  {
    --color;
    if (GameConstants.IsBetween((int) color, 0, 4))
    {
      if ((int) this.MaterCount[(int) color] >= (int) reqNum)
        return true;
      int num = 0;
      for (int index = (int) color; index >= 0; --index)
        num = num * 4 + (int) this.MaterCount[index];
      if (Math.Pow(4.0, (double) color) * (double) reqNum <= (double) num)
        return true;
    }
    return false;
  }

  private bool isHigherMaterialEnough(byte color, ushort reqNum)
  {
    --color;
    if (GameConstants.IsBetween((int) color, 0, 4))
    {
      if ((int) this.MaterCount[(int) color] >= (int) reqNum)
        return true;
      int num = 0;
      for (int index = 4; index >= (int) color; --index)
        num = num * 4 + (int) this.MaterCount[index];
      if ((int) reqNum <= num)
        return true;
    }
    return false;
  }

  private int GetFirstIndex(ushort itemID, byte color)
  {
    uint num = 0;
    if (color > (byte) 0)
    {
      for (int index = 0; index < 8; ++index)
      {
        if ((int) LordEquipData.RoleEquip[index].ItemID == (int) UIAnvil.preSetID && (int) LordEquipData.RoleEquip[index].Color == (int) color)
        {
          num = LordEquipData.RoleEquipSerial[index];
          break;
        }
      }
      for (ushort firstIndex = 0; (int) firstIndex < (int) this.DM.RoleAttr.LordEquipBagSize; ++firstIndex)
      {
        if ((int) this.DM.mLordEquip.LordEquip[(int) firstIndex].ItemID == (int) UIAnvil.preSetID && (int) this.DM.mLordEquip.LordEquip[(int) firstIndex].Color == (int) color && (num == 0U || (int) num == (int) this.DM.mLordEquip.LordEquip[(int) firstIndex].SerialNO))
          return (int) firstIndex;
      }
    }
    return -1;
  }

  private bool isCombineReady(
    int selectIdx,
    ushort itemID,
    byte color,
    bool MoneyCombine,
    bool PopMessage = false)
  {
    switch (UIAnvil.OpenKind)
    {
      case eUI_Anvil_OpenKind.ForgeNewItem:
        if (color > (byte) 1 && LordEquipData.getItemQuantity(itemID, (byte) ((uint) color - 1U)) == (ushort) 0)
        {
          if (PopMessage)
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7443U), (ushort) byte.MaxValue);
          return false;
        }
        if (color == (byte) 1 && !this.DM.mLordEquip.HaveEquipSpace())
        {
          if (PopMessage)
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7497U), (ushort) byte.MaxValue);
          return false;
        }
        break;
      case eUI_Anvil_OpenKind.UpgradeItem:
        if ((int) this.DM.mLordEquip.LordEquip[selectIdx].Color + 1 != (int) color)
          return false;
        break;
    }
    if (this.DM.RoleAttr.LordEquipEventData.ItemID != (ushort) 0)
      return false;
    Equip recordByKey = this.DM.EquipTable.GetRecordByKey(itemID);
    if (!this.DM.mLordEquip.isItemCombineReady(itemID, color))
    {
      if (PopMessage)
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7442U), (ushort) byte.MaxValue);
      return false;
    }
    if (MoneyCombine)
    {
      if (this.NeedDiamon > this.DM.RoleAttr.Diamond)
      {
        if (PopMessage)
          GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(3966U), DataManager.Instance.mStringTable.GetStringByID(646U), DataManager.Instance.mStringTable.GetStringByID(3968U), (GUIWindow) this, 3, bCloseIDSet: true);
        return false;
      }
    }
    else if ((double) (uint) ((double) recordByKey.MixPrice * this.DM.mLordEquip.forgeGold[(int) color]) > this.DM.Resource[4].CurrentStock)
    {
      if (PopMessage)
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7446U), (ushort) byte.MaxValue);
      return false;
    }
    return true;
  }

  private void ShowMoney()
  {
    Equip recordByKey = this.DM.EquipTable.GetRecordByKey(UIAnvil.preSetID);
    if (this.currentColor > (byte) 5)
      return;
    uint x = (uint) Math.Ceiling((double) recordByKey.MixPrice * this.DM.mLordEquip.forgeGold[(int) this.currentColor]);
    UIText component1 = this.AGS_Form.GetChild(10).GetChild(10).GetChild(1).GetComponent<UIText>();
    this.goldCost.ClearString();
    this.goldCost.IntToFormat((long) this.DM.Resource[4].Stock, bNumber: true);
    this.goldCost.IntToFormat((long) x, bNumber: true);
    if (this.DM.Resource[4].Stock < x)
      this.goldCost.StringToFormat("<color=#FF5581FF>");
    else
      this.goldCost.StringToFormat("<color=#FFFFFFFF>");
    if (!GUIManager.Instance.IsArabic)
      this.goldCost.AppendFormat("{2}{0}</color> / {1}");
    else
      this.goldCost.AppendFormat("{1} / {2}{0}</color>");
    component1.text = this.goldCost.ToString();
    component1.SetAllDirty();
    component1.cachedTextGenerator.Invalidate();
    component1.cachedTextGeneratorForLayout.Invalidate();
    RectTransform component2 = this.AGS_Form.GetChild(10).GetChild(10).GetChild(0).GetComponent<RectTransform>();
    Vector2 anchoredPosition1 = ((Graphic) component1).rectTransform.anchoredPosition;
    anchoredPosition1.x -= (float) ((double) component1.preferredWidth / 2.0 + 20.0);
    component2.anchoredPosition = anchoredPosition1;
    RectTransform component3 = this.AGS_Form.GetChild(10).GetChild(10).GetChild(2).GetComponent<RectTransform>();
    Vector2 anchoredPosition2 = ((Graphic) component1).rectTransform.anchoredPosition;
    anchoredPosition2.x += (float) ((double) component1.preferredWidth / 2.0 + 24.0);
    component3.anchoredPosition = anchoredPosition2;
    ((Component) component3).gameObject.SetActive(this.DM.Resource[4].Stock < x);
    this.NeedDiamon = (uint) Math.Ceiling((double) recordByKey.MixTime * this.DM.mLordEquip.forgeTime[(int) this.currentColor] * 10000.0 / (10000.0 + (double) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 250)));
    UIText component4 = this.AGS_Form.GetChild(11).GetChild(1).GetChild(2).GetComponent<UIText>();
    this.timeCost.ClearString();
    this.timeCost.Append(this.DM.mStringTable.GetStringByID(7441U));
    this.timeCost.Append(" ");
    GameConstants.GetTimeString(this.timeCost, this.NeedDiamon, withArabic: true);
    component4.text = this.timeCost.ToString();
    component4.SetAllDirty();
    component4.cachedTextGenerator.Invalidate();
    uint Num = this.DM.Resource[4].Stock <= x ? x - this.DM.Resource[4].Stock : 0U;
    this.NeedDiamon = this.DM.GetResourceExchange(PriceListType.Time, this.NeedDiamon) + this.DM.GetResourceExchange(PriceListType.Money, Num);
    UIText component5 = this.AGS_Form.GetChild(11).GetChild(0).GetChild(2).GetComponent<UIText>();
    this.moneyCost.ClearString();
    this.moneyCost.IntToFormat((long) this.NeedDiamon, bNumber: true);
    this.moneyCost.AppendFormat("{0}");
    component5.text = this.moneyCost.ToString();
    component5.SetAllDirty();
    component5.cachedTextGenerator.Invalidate();
    UIText component6 = this.AGS_Form.GetChild(11).GetChild(1).GetChild(1).GetComponent<UIText>();
    if (this.isCombineReady((int) UIAnvil.preSetIndex, UIAnvil.preSetID, this.currentColor, false))
      ((Graphic) component6).color = (Color) new Color32(byte.MaxValue, (byte) 247, (byte) 153, byte.MaxValue);
    else
      ((Graphic) component6).color = (Color) new Color32(byte.MaxValue, (byte) 85, (byte) 129, byte.MaxValue);
    UIText component7 = this.AGS_Form.GetChild(11).GetChild(0).GetChild(3).GetComponent<UIText>();
    if (this.isCombineReady((int) UIAnvil.preSetIndex, UIAnvil.preSetID, this.currentColor, true))
      ((Graphic) component7).color = (Color) new Color32(byte.MaxValue, (byte) 247, (byte) 153, byte.MaxValue);
    else
      ((Graphic) component7).color = (Color) new Color32(byte.MaxValue, (byte) 85, (byte) 129, byte.MaxValue);
  }

  private void StartForge(bool Start)
  {
    if (Start)
    {
      this.ItemMagnet = true;
      this.ForgeStart = true;
      ((Component) this.SmallForgeLight).gameObject.SetActive(true);
    }
    else
      this.ForgeStop = true;
  }

  private void resetItemPos()
  {
    for (int index = 0; index < 5; ++index)
    {
      Color color = new Color(1f, 1f, 1f, 1f);
      UILEBtn component = this.AGS_Form.GetChild(10).GetChild(0 + index).GetComponent<UILEBtn>();
      ((Component) component.LEImage).transform.localPosition = Vector3.zero;
      ((Graphic) component.LEImage).color = color;
    }
  }

  public static void SetOpen(eUI_Anvil_OpenKind iOpenKind, int ItemId, int ItemColor)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    UIAnvil.OpenKind = iOpenKind;
    UIAnvil.returnID = (ushort) 0;
    UIAnvil.returnColor = (byte) 0;
    menu.OpenMenu(EGUIWindow.UI_Anvil, ItemId, ItemColor);
  }

  public void Update()
  {
    if (this.isLoading)
    {
      this.isLoading = false;
      this.AfterLoader();
    }
    this.ForgeLightTime += Time.smoothDeltaTime / 2f;
    if ((double) this.ForgeLightTime >= 1.5)
      this.ForgeLightTime = 0.5f;
    Color color = new Color(1f, 1f, 1f, (double) this.ForgeLightTime <= 1.0 ? this.ForgeLightTime : 2f - this.ForgeLightTime);
    ((Graphic) this.ForgeLight).color = color;
    ((Graphic) this.SelectLight).color = color;
    ((Graphic) this.MaterialLight).color = color;
    ((Graphic) this.POPLight1).color = color;
    ((Graphic) this.POPLight3).color = color;
    this.arrowTime += Time.smoothDeltaTime * 40f;
    if ((double) this.arrowTime >= 40.0)
      this.arrowTime = 0.0f;
    float num = (double) this.arrowTime <= 20.0 ? this.arrowTime : 40f - this.arrowTime;
    if ((double) num < 0.0)
      num = 0.0f;
    this.arrowPos.anchoredPosition = new Vector2(10f - num, this.arrowPos.anchoredPosition.y);
    this.HintTime += Time.smoothDeltaTime / 2f;
    if ((double) this.HintTime >= 2.0)
      this.HintTime = 0.0f;
    color = new Color(1f, 1f, 1f, (double) this.HintTime <= 1.0 ? this.HintTime : 2f - this.HintTime);
    for (int index = 0; index < 5; ++index)
      ((Graphic) this.ItemLight[index]).color = color;
    if (this.ForgintLightEff)
    {
      this.ForgingLightTime += Time.smoothDeltaTime * 1.5f;
      if ((double) this.ForgingLightTime >= 1.0)
        this.ForgingLightTime = 0.0f;
      ((Transform) this.BigForgeLight).localScale = Vector3.one * (1f - this.ForgingLightTime);
    }
    if (this.ForgeStart)
    {
      this.ForgeStartTime += Time.smoothDeltaTime * 1.5f;
      if ((double) this.ForgeStartTime >= 2.0)
      {
        this.ForgeStartTime = 0.0f;
        this.ItemMagnet = false;
        this.resetItemPos();
        if (this.ForgeStop)
        {
          this.ForgeStart = false;
          this.ForgeStop = false;
          this.ForgintLightEff = false;
          ((Component) this.BigForgeLight).gameObject.SetActive(false);
        }
      }
      if (this.ItemMagnet)
      {
        Vector3 position = ((Component) this.SmallForgeLight).transform.position;
        for (int index = 0; index < 5; ++index)
        {
          UILEBtn component = this.AGS_Form.GetChild(10).GetChild(0 + index).GetComponent<UILEBtn>();
          Vector3 vector3 = Vector3.Lerp(((Component) component.image).transform.position, position, this.ForgeStartTime);
          ((Component) component.LEImage).transform.position = vector3;
        }
        if ((double) this.ForgeStartTime > 1.0)
        {
          color = new Color(1f, 1f, 1f, 0.0f);
          for (int index = 0; index < 5; ++index)
          {
            UILEBtn component = this.AGS_Form.GetChild(10).GetChild(0 + index).GetComponent<UILEBtn>();
            ((Component) component.LEImage).transform.localPosition = Vector3.zero;
            ((Graphic) component.LEImage).color = color;
          }
          this.ItemMagnet = false;
        }
      }
      if ((double) this.ForgeStartTime >= 1.0)
      {
        this.ForgintLightEff = true;
        ((Component) this.BigForgeLight).gameObject.SetActive(true);
      }
      color = new Color(1f, 1f, 1f, (double) this.ForgeStartTime <= 1.0 ? this.ForgeStartTime : 2f - this.ForgeStartTime);
      ((Graphic) this.SmallForgeLight).color = color;
    }
    if (!this.MaterialFlash)
      return;
    this.MoveTime += Time.smoothDeltaTime;
    if ((double) this.MoveTime < 0.30000001192092896)
    {
      if (this.isCombine)
        ((Graphic) this.Flash).rectTransform.anchoredPosition = new Vector2(Mathf.Lerp(-50f, 100f, this.MoveTime / 0.3f), 5f);
      else
        ((Graphic) this.Flash).rectTransform.anchoredPosition = new Vector2(Mathf.Lerp(50f, -100f, this.MoveTime / 0.3f), 5f);
      ((Graphic) this.Flash).color = Color.white;
      float a = (float) ((0.30000001192092896 - (double) this.MoveTime) / 0.30000001192092896);
      ((Graphic) this.LightBox1).color = new Color(1f, 1f, 1f, a);
      ((Graphic) this.LightBox2).color = new Color(1f, 1f, 1f, a);
    }
    if ((double) this.MoveTime > 0.2)
      ((Graphic) this.Flash).color = new Color(1f, 1f, 1f, (float) ((0.30000001192092896 - (double) this.MoveTime) * 10.0));
    if ((double) this.MoveTime < 0.40000000596046448)
      return;
    this.MoveTime = 0.0f;
    this.MaterialFlash = false;
  }

  private enum e_AGS_UI_ForgeAnvil_Editor
  {
    BGFrame,
    BGFrameTitle,
    exitImage,
    Infobtn,
    Image,
    BGImage,
    ItemInfo,
    ItemLine,
    ForgingItem,
    ForgingPanel,
    ItemCombine,
    ItemCombinePanel,
    Cover,
  }

  private enum e_AGS_ItemInfo
  {
    NameBg,
    NameText,
    RareImg,
    LevelText,
    ScrollPanel,
    ScrollItem,
    Image,
    EquipBtn,
  }

  private enum e_AGS_EquipBtn
  {
    Image,
  }

  private enum e_AGS_ItemLine
  {
    UILEBtn1,
    UILEBtn2,
    UILEBtn3,
    UILEBtn4,
    UILEBtn5,
    Light,
    BackBtn,
  }

  private enum e_AGS_ForgingItem
  {
    TargetItem,
    TargetName,
    Light,
    Light2,
    Light3,
  }

  private enum e_AGS_ForgingPanel
  {
    ItemName,
    BarBg,
    Bar,
    BarDesc,
    BarTime,
    CancelBtn,
    FastBtn,
  }

  private enum e_AGS_ItemCombine
  {
    Mat1,
    Mat2,
    Mat3,
    Mat4,
    oldItem,
    Light1,
    Light2,
    Light3,
    Light4,
    Light5,
    AddMoney,
  }

  private enum e_AGS_AddMoney
  {
    Icon,
    Money,
    Plus,
  }

  private enum e_AGS_ItemCombinePanel
  {
    QuickBtn,
    ForgeBtn,
  }

  private enum e_AGS_QuickBtn
  {
    Icon,
    cover,
    Money,
    Name,
  }

  private enum e_AGS_ForgeBtn
  {
    cover,
    Name,
    TimeText,
  }

  private enum e_AGS_PopUp
  {
    PopBg,
    CloseBtn,
    UILEBtn,
    TitleBg,
    ItemName,
    ItemRare,
    EffBg,
    Upgrade,
    CombineAll,
    CombineBtn,
    TextArea,
    Image,
    MaterialPanel,
  }

  private enum e_AGS_Upgrade
  {
    Desc,
    DescText,
    Mat1,
    Mat2,
    Mat3,
    Mat4,
    Mat5,
    Select,
  }

  private enum e_AGS_Select
  {
    Flash1,
    Flash2,
    Image,
    LightEff,
  }

  private enum e_AGS_MaterialPanel
  {
    combinebg,
    combine,
    Image1bg,
    Image1,
    breakDownbg,
    breakDown,
    Image2bg,
    Image2,
    Mark,
  }
}
