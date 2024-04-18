// Decompiled with JetBrains decompiler
// Type: UILordEquip
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UILordEquip : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler, IUILEBtnClickHandler
{
  private Door door;
  private DataManager DM;
  private eUI_LordEquipOpenKind OpenKind;
  private UILordEquip.eUIOpenStat OpenStat;
  private UILordEquip.eUIOpenStat PopupKind;
  private byte PopUpColor;
  private UILordEquip.eItemFilterByKind FilterKind;
  private UILordEquip.eCollectType CollectType;
  private bool isCollectChange;
  private byte EquipSolt;
  private CString TitleText;
  private CString NoContentText;
  private CString ItemNameText;
  private CString ItemLevelText;
  private CString PopUpHeaderText;
  private CString TimedItemCountText;
  private CString[] GemBtnText = new CString[4];
  private CString[] EffDescText = new CString[10];
  private CString[] PopupEffectText = new CString[6];
  private CString[] PopupAmountText = new CString[5];
  private List<LordEquipEffectSet> effectList;
  private List<LordEquipEffectCompareSet> effectCompareList;
  private bool OnStartSelect = true;
  private bool ShowUnlockPanel;
  private bool isCombine = true;
  private List<float> SPHeight;
  private List<float> SideSPHeight;
  private List<ushort> FilterItem;
  private RectTransform Select;
  private RectTransform Forging;
  private bool isFocused;
  private static ushort EquipFocus;
  private static ushort EquipFocusSub;
  private ushort MaterialFocus;
  public static ushort itemIDFilter;
  public static ushort itemColorFilter;
  private bool lockEmptyForge;
  private int lockedIdx;
  private static int EquipTopIdx;
  private static int GemTopIdx;
  private static int MatTopIdx;
  private static float EquipTopPos;
  private static float GemTopPos;
  private static float MatTopPos;
  private ushort combineItemID;
  private byte combineColor;
  private ushort[] MaterCount = new ushort[5];
  public static eUI_LordEquipReturnKind waitForReturn;
  private static int EquipFilter;
  private bool MaterialFlash;
  private Image Light1;
  private Image Light2;
  private Image Light3;
  private Image SelectLight;
  private Image Flash;
  private Image LightBox1;
  private Image LightBox2;
  private Image MaterialLight;
  private RectTransform arrowPos;
  private Image POPLight1;
  private Image POPLight3;
  private bool selectedTimed;
  private Transform AGS_Form;
  private ScrollPanel AGS_ScrollArea;
  private RectTransform ScrollArea_RT;
  private UISpritesArray AGS_RareImg;
  private ScrollPanel AGS_ScrollPanel;
  private UISpritesArray AGS_ItemRare;
  private ScrollPanel AGS_ScrollPanel2;
  private UISpritesArray AGS_Forging;
  private float MoveTime;
  private float GetPointTime;
  private float AnimeTime;
  private float arrowTime;

  public override void OnOpen(int arg1, int arg2)
  {
    this.door = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    this.DM = DataManager.Instance;
    if (this.DM.mLordEquip == null)
      this.DM.mLordEquip = LordEquipData.Instance();
    this.OpenKind = (eUI_LordEquipOpenKind) arg1;
    this.EquipSolt = (byte) arg2;
    this.CollectType = UILordEquip.eCollectType.Equip;
    this.PopupKind = UILordEquip.eUIOpenStat.None;
    if (this.OpenKind == eUI_LordEquipOpenKind.CombineSelect)
      UILordEquip.waitForReturn = eUI_LordEquipReturnKind.None;
    this.TitleText = StringManager.Instance.SpawnString(100);
    this.NoContentText = StringManager.Instance.SpawnString(100);
    this.ItemNameText = StringManager.Instance.SpawnString(100);
    this.ItemLevelText = StringManager.Instance.SpawnString(50);
    this.PopUpHeaderText = StringManager.Instance.SpawnString(100);
    this.TimedItemCountText = StringManager.Instance.SpawnString(100);
    for (int index = 0; index < this.GemBtnText.Length; ++index)
      this.GemBtnText[index] = StringManager.Instance.SpawnString(100);
    for (int index = 0; index < this.EffDescText.Length; ++index)
      this.EffDescText[index] = StringManager.Instance.SpawnString(100);
    for (int index = 0; index < this.PopupEffectText.Length; ++index)
      this.PopupEffectText[index] = StringManager.Instance.SpawnString(100);
    for (int index = 0; index < this.PopupAmountText.Length; ++index)
      this.PopupAmountText[index] = StringManager.Instance.SpawnString(50);
    this.effectList = new List<LordEquipEffectSet>();
    this.SPHeight = new List<float>();
    this.SideSPHeight = new List<float>();
    this.FilterItem = new List<ushort>();
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = this.DM.mStringTable.GetStringByID(7404U);
    UIButton component2 = this.AGS_Form.GetChild(2).GetChild(0).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_EffectType = e_EffectType.e_Scale;
    ((Behaviour) this.AGS_Form.GetChild(2).GetComponent<Image>()).enabled = !GUIManager.Instance.bOpenOnIPhoneX;
    UIButton component3 = this.AGS_Form.GetChild(3).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 99;
    component3.m_EffectType = e_EffectType.e_Scale;
    ((Component) component3).gameObject.SetActive(false);
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component4 = ((Component) component3).gameObject.GetComponent<RectTransform>();
      ((Transform) component4).localScale = new Vector3(-1f, 1f, 1f);
      component4.anchoredPosition = new Vector2(component4.anchoredPosition.x + 44f, component4.anchoredPosition.y);
    }
    UIText component5 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
    component5.font = ttfFont;
    component5.text = string.Empty;
    UIButton component6 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).GetComponent<UIButton>();
    component6.m_Handler = (IUIButtonClickHandler) this;
    component6.m_BtnID1 = 8;
    UIText component7 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    component7.font = ttfFont;
    component7.text = this.DM.mStringTable.GetStringByID(7440U);
    Image component8 = this.AGS_Form.GetChild(6).GetChild(0).GetChild(1).GetComponent<Image>();
    component8.sprite = this.door.LoadSprite("UI_main_redbox_01");
    ((MaskableGraphic) component8).material = this.door.LoadMaterial();
    component8.type = (Image.Type) 1;
    Image component9 = this.AGS_Form.GetChild(6).GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
    component9.sprite = this.door.LoadSprite("UI_main_mess_ex");
    ((MaskableGraphic) component9).material = this.door.LoadMaterial();
    this.AGS_Form.GetChild(6).GetChild(1).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    UIText component10 = this.AGS_Form.GetChild(6).GetChild(1).GetChild(2).GetComponent<UIText>();
    component10.font = ttfFont;
    component10.text = this.DM.mStringTable.GetStringByID(7456U);
    UIButton component11 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetComponent<UIButton>();
    component11.m_Handler = (IUIButtonClickHandler) this;
    component11.m_BtnID1 = 6;
    component11.m_BtnID2 = 1;
    component11.m_EffectType = e_EffectType.e_Scale;
    UIText component12 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(1).GetComponent<UIText>();
    component12.font = ttfFont;
    component12.text = this.DM.mStringTable.GetStringByID(7457U);
    Image component13 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(2).GetComponent<Image>();
    component13.sprite = this.door.LoadSprite("UI_main_redbox_01");
    ((MaskableGraphic) component13).material = this.door.LoadMaterial();
    component13.type = (Image.Type) 1;
    Image component14 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>();
    component14.sprite = this.door.LoadSprite("UI_main_mess_ex");
    ((MaskableGraphic) component14).material = this.door.LoadMaterial();
    UIButton component15 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(1).GetComponent<UIButton>();
    component15.m_Handler = (IUIButtonClickHandler) this;
    component15.m_BtnID1 = 6;
    component15.m_BtnID2 = 2;
    component15.m_EffectType = e_EffectType.e_Scale;
    UIText component16 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(1).GetChild(1).GetComponent<UIText>();
    component16.font = ttfFont;
    component16.text = this.DM.mStringTable.GetStringByID(7458U);
    UIButton component17 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(2).GetComponent<UIButton>();
    component17.m_Handler = (IUIButtonClickHandler) this;
    component17.m_BtnID1 = 6;
    component17.m_BtnID2 = 3;
    component17.m_EffectType = e_EffectType.e_Scale;
    UIText component18 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(2).GetChild(1).GetComponent<UIText>();
    component18.font = ttfFont;
    component18.text = this.DM.mStringTable.GetStringByID(7459U);
    this.Light1 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
    this.Light2 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(1).GetChild(0).GetComponent<Image>();
    this.Light3 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>();
    UIText component19 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(4).GetComponent<UIText>();
    component19.font = ttfFont;
    component19.text = string.Empty;
    UIButton component20 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).GetComponent<UIButton>();
    component20.m_Handler = (IUIButtonClickHandler) this;
    component20.m_BtnID1 = 6;
    component20.m_BtnID2 = 4;
    UIText component21 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).GetChild(0).GetComponent<UIText>();
    component21.font = ttfFont;
    component21.text = string.Empty;
    UIButton component22 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).GetChild(1).GetComponent<UIButton>();
    component22.m_Handler = (IUIButtonClickHandler) this;
    component22.m_BtnID1 = 6;
    component22.m_BtnID2 = 4;
    component22.m_EffectType = e_EffectType.e_Scale;
    UIText component23 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).GetChild(2).GetComponent<UIText>();
    component23.font = ttfFont;
    component23.text = this.DM.mStringTable.GetStringByID(7464U);
    UIButton component24 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).GetComponent<UIButton>();
    component24.m_Handler = (IUIButtonClickHandler) this;
    component24.m_BtnID1 = 6;
    component24.m_BtnID2 = 5;
    component24.m_EffectType = e_EffectType.e_Scale;
    UIText component25 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(1).GetComponent<UIText>();
    component25.font = ttfFont;
    component25.text = string.Empty;
    this.AGS_RareImg = this.AGS_Form.GetChild(8).GetChild(1).GetChild(2).GetComponent<UISpritesArray>();
    UIText component26 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(3).GetComponent<UIText>();
    component26.font = ttfFont;
    component26.alignment = TextAnchor.MiddleLeft;
    component26.text = string.Empty;
    UIText component27 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).GetComponent<UIText>();
    component27.font = ttfFont;
    component27.text = string.Empty;
    component27.alignment = TextAnchor.UpperLeft;
    ((Component) component27).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 34f);
    component27.resizeTextMaxSize = 22;
    this.AGS_ScrollPanel = this.AGS_Form.GetChild(8).GetChild(1).GetChild(7).GetComponent<ScrollPanel>();
    UIText component28 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(8).GetChild(0).GetComponent<UIText>();
    component28.font = ttfFont;
    component28.text = string.Empty;
    UIText component29 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(8).GetChild(1).GetComponent<UIText>();
    component29.font = ttfFont;
    component29.text = string.Empty;
    UIButton component30 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetComponent<UIButton>();
    component30.m_Handler = (IUIButtonClickHandler) this;
    component30.m_BtnID1 = 1;
    component30.m_BtnID2 = 1;
    component30.m_EffectType = e_EffectType.e_Scale;
    UIText component31 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(1).GetComponent<UIText>();
    component31.font = ttfFont;
    component31.text = this.DM.mStringTable.GetStringByID(7468U);
    Image component32 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(2).GetComponent<Image>();
    component32.sprite = this.door.LoadSprite("UI_main_redbox_01");
    ((MaskableGraphic) component32).material = this.door.LoadMaterial();
    component32.type = (Image.Type) 1;
    Image component33 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(2).GetChild(0).GetComponent<Image>();
    component33.sprite = this.door.LoadSprite("UI_main_mess_ex");
    ((MaskableGraphic) component33).material = this.door.LoadMaterial();
    UIButton component34 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetComponent<UIButton>();
    component34.m_Handler = (IUIButtonClickHandler) this;
    component34.m_BtnID1 = 1;
    component34.m_BtnID2 = 2;
    component34.m_EffectType = e_EffectType.e_Scale;
    UIText component35 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetChild(1).GetComponent<UIText>();
    component35.font = ttfFont;
    component35.text = this.DM.mStringTable.GetStringByID(7469U);
    UIButton component36 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).GetComponent<UIButton>();
    component36.m_Handler = (IUIButtonClickHandler) this;
    component36.m_BtnID1 = 1;
    component36.m_BtnID2 = 3;
    component36.m_EffectType = e_EffectType.e_Scale;
    UIText component37 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).GetChild(1).GetComponent<UIText>();
    component37.font = ttfFont;
    component37.text = this.DM.mStringTable.GetStringByID(7475U);
    UIText component38 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(1).GetComponent<UIText>();
    component38.font = ttfFont;
    component38.text = string.Empty;
    UIText component39 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(3).GetComponent<UIText>();
    component39.font = ttfFont;
    component39.text = string.Empty;
    bool flag = !GameConstants.IsBigStyle();
    if (flag)
      component39.resizeTextMaxSize = 16;
    UIText component40 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(4).GetComponent<UIText>();
    component40.font = ttfFont;
    component40.text = string.Empty;
    if (flag)
      component40.resizeTextMaxSize = 16;
    UIText component41 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(5).GetComponent<UIText>();
    component41.font = ttfFont;
    component41.text = string.Empty;
    if (flag)
      component41.resizeTextMaxSize = 16;
    UIText component42 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(6).GetComponent<UIText>();
    component42.font = ttfFont;
    component42.text = string.Empty;
    if (flag)
      component42.resizeTextMaxSize = 16;
    UIText component43 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(7).GetComponent<UIText>();
    component43.font = ttfFont;
    component43.text = string.Empty;
    if (flag)
      component43.resizeTextMaxSize = 16;
    UIText component44 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(8).GetComponent<UIText>();
    component44.font = ttfFont;
    component44.text = string.Empty;
    if (flag)
      component44.resizeTextMaxSize = 16;
    UIButton component45 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(11).GetComponent<UIButton>();
    component45.m_Handler = (IUIButtonClickHandler) this;
    component45.m_BtnID1 = 4;
    component45.m_BtnID2 = 2;
    UIText component46 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(11).GetChild(0).GetComponent<UIText>();
    component46.font = ttfFont;
    component46.text = string.Empty;
    UIButton component47 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(11).GetChild(1).GetComponent<UIButton>();
    component47.m_Handler = (IUIButtonClickHandler) this;
    component47.m_BtnID1 = 4;
    component47.m_BtnID2 = 2;
    component47.m_EffectType = e_EffectType.e_Scale;
    UIText component48 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(11).GetChild(2).GetComponent<UIText>();
    component48.font = ttfFont;
    component48.text = this.DM.mStringTable.GetStringByID(7464U);
    UIText component49 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(10).GetComponent<UIText>();
    component49.font = ttfFont;
    component49.text = this.DM.mStringTable.GetStringByID(7479U);
    UIButton component50 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(12).GetComponent<UIButton>();
    component50.m_Handler = (IUIButtonClickHandler) this;
    component50.m_BtnID1 = 4;
    component50.m_BtnID2 = 1;
    component50.m_EffectType = e_EffectType.e_Scale;
    UIText component51 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(12).GetChild(0).GetComponent<UIText>();
    component51.font = ttfFont;
    component51.text = this.DM.mStringTable.GetStringByID(7471U);
    UILEBtn component52 = this.AGS_Form.GetChild(9).GetChild(1).GetComponent<UILEBtn>();
    component52.m_Handler = (IUILEBtnClickHandler) this;
    GUIManager.Instance.InitLordEquipImg(((Component) component52).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    ((Graphic) component52.OnEquip).rectTransform.anchorMin = new Vector2(0.63f, 0.63f);
    ((Graphic) component52.OnEquip).rectTransform.anchorMax = new Vector2(1f, 1f);
    ((Graphic) component52.OnEquip).rectTransform.offsetMin = Vector2.zero;
    ((Graphic) component52.OnEquip).rectTransform.offsetMax = Vector2.zero;
    UIButton component53 = this.AGS_Form.GetChild(9).GetChild(2).GetComponent<UIButton>();
    component53.m_Handler = (IUIButtonClickHandler) this;
    component53.m_BtnID1 = 3;
    component53.m_BtnID2 = 1;
    component53.m_EffectType = e_EffectType.e_Scale;
    UIText component54 = this.AGS_Form.GetChild(9).GetChild(2).GetChild(0).GetComponent<UIText>();
    component54.font = ttfFont;
    component54.text = this.DM.mStringTable.GetStringByID(7534U);
    UIText component55 = this.AGS_Form.GetChild(9).GetChild(4).GetComponent<UIText>();
    component55.font = ttfFont;
    component55.text = string.Empty;
    this.AGS_ItemRare = this.AGS_Form.GetChild(9).GetChild(5).GetComponent<UISpritesArray>();
    UIText component56 = this.AGS_Form.GetChild(9).GetChild(6).GetComponent<UIText>();
    component56.font = ttfFont;
    component56.text = string.Empty;
    UIButton component57 = this.AGS_Form.GetChild(9).GetChild(8).GetComponent<UIButton>();
    component57.m_Handler = (IUIButtonClickHandler) this;
    component57.m_BtnID1 = 3;
    component57.m_BtnID2 = 2;
    component57.m_EffectType = e_EffectType.e_Scale;
    UIText component58 = this.AGS_Form.GetChild(9).GetChild(8).GetChild(1).GetComponent<UIText>();
    component58.font = ttfFont;
    component58.text = this.DM.mStringTable.GetStringByID(7475U);
    Image component59 = this.AGS_Form.GetChild(9).GetChild(8).GetChild(2).GetComponent<Image>();
    component59.sprite = this.door.LoadSprite("UI_main_redbox_01");
    ((MaskableGraphic) component59).material = this.door.LoadMaterial();
    component59.type = (Image.Type) 1;
    Image component60 = this.AGS_Form.GetChild(9).GetChild(8).GetChild(2).GetChild(0).GetComponent<Image>();
    component60.sprite = this.door.LoadSprite("UI_main_mess_ex");
    ((MaskableGraphic) component60).material = this.door.LoadMaterial();
    UIButton component61 = this.AGS_Form.GetChild(9).GetChild(9).GetComponent<UIButton>();
    component61.m_Handler = (IUIButtonClickHandler) this;
    component61.m_BtnID1 = 3;
    component61.m_BtnID2 = 3;
    component61.m_EffectType = e_EffectType.e_Scale;
    UIText component62 = this.AGS_Form.GetChild(9).GetChild(9).GetChild(0).GetComponent<UIText>();
    component62.font = ttfFont;
    component62.text = this.DM.mStringTable.GetStringByID(7474U);
    this.AGS_ScrollPanel2 = this.AGS_Form.GetChild(9).GetChild(10).GetComponent<ScrollPanel>();
    UIText component63 = this.AGS_Form.GetChild(9).GetChild(11).GetChild(1).GetComponent<UIText>();
    component63.font = ttfFont;
    component63.text = string.Empty;
    UIText component64 = this.AGS_Form.GetChild(9).GetChild(11).GetChild(2).GetComponent<UIText>();
    component64.font = ttfFont;
    component64.text = string.Empty;
    UIText component65 = this.AGS_Form.GetChild(9).GetChild(12).GetChild(2).GetComponent<UIText>();
    component65.font = ttfFont;
    component65.text = this.DM.mStringTable.GetStringByID(7476U);
    UnityEngine.Object.Destroy((UnityEngine.Object) this.AGS_Form.GetChild(10).GetComponent<UIButton>());
    HelperUIButton helperUiButton = this.AGS_Form.GetChild(10).gameObject.AddComponent<HelperUIButton>();
    helperUiButton.m_Handler = (IUIButtonClickHandler) this;
    helperUiButton.m_BtnID1 = 0;
    helperUiButton.m_BtnID2 = 1;
    UnityEngine.Object.Destroy((UnityEngine.Object) this.AGS_Form.GetChild(10).GetChild(0).GetChild(0).GetComponent<IgnoreRaycast>());
    UIButton component66 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(1).GetComponent<UIButton>();
    component66.m_Handler = (IUIButtonClickHandler) this;
    component66.m_BtnID1 = 0;
    component66.m_BtnID2 = 1;
    component66.m_EffectType = e_EffectType.e_Scale;
    UILEBtn component67 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(2).GetComponent<UILEBtn>();
    GUIManager.Instance.InitLordEquipImg(((Component) component67).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    component67.m_Handler = (IUILEBtnClickHandler) this;
    UIText component68 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
    component68.font = ttfFont;
    component68.text = string.Empty;
    UIText component69 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(4).GetComponent<UIText>();
    component69.font = ttfFont;
    component69.text = string.Empty;
    UIText component70 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(8).GetComponent<UIText>();
    component70.font = ttfFont;
    component70.text = string.Empty;
    UIText component71 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetComponent<UIText>();
    component71.font = ttfFont;
    component71.text = string.Empty;
    UIText component72 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(10).GetComponent<UIText>();
    component72.font = ttfFont;
    component72.text = string.Empty;
    UIText component73 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(11).GetComponent<UIText>();
    component73.font = ttfFont;
    component73.text = string.Empty;
    UIText component74 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(12).GetComponent<UIText>();
    component74.font = ttfFont;
    component74.text = string.Empty;
    UIText component75 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(13).GetComponent<UIText>();
    component75.font = ttfFont;
    component75.text = string.Empty;
    UIText component76 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).GetComponent<UIText>();
    component76.font = ttfFont;
    component76.text = string.Empty;
    UIText component77 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(15).GetComponent<UIText>();
    component77.font = ttfFont;
    component77.text = string.Empty;
    UIText component78 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(16).GetComponent<UIText>();
    component78.font = ttfFont;
    component78.text = string.Empty;
    UIText component79 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(17).GetComponent<UIText>();
    component79.font = ttfFont;
    component79.text = string.Empty;
    UIText component80 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(18).GetComponent<UIText>();
    component80.font = ttfFont;
    component80.text = string.Empty;
    UIText component81 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(19).GetComponent<UIText>();
    component81.font = ttfFont;
    component81.text = string.Empty;
    UIText component82 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(1).GetComponent<UIText>();
    component82.font = ttfFont;
    component82.text = this.DM.mStringTable.GetStringByID(7465U);
    UILEBtn component83 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(2).GetComponent<UILEBtn>();
    GUIManager.Instance.InitLordEquipImg(((Component) component83).transform, (ushort) 0, (byte) 0, setScale: true, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    component83.m_Handler = (IUILEBtnClickHandler) this;
    component83.m_BtnID1 = 3;
    component83.m_BtnID2 = 1;
    UIText component84 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(2).GetChild(0).GetComponent<UIText>();
    component84.font = ttfFont;
    component84.text = string.Empty;
    UILEBtn component85 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(3).GetComponent<UILEBtn>();
    GUIManager.Instance.InitLordEquipImg(((Component) component85).transform, (ushort) 0, (byte) 0, setScale: true, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    component85.m_Handler = (IUILEBtnClickHandler) this;
    component85.m_BtnID1 = 3;
    component85.m_BtnID2 = 2;
    UIText component86 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(3).GetChild(0).GetComponent<UIText>();
    component86.font = ttfFont;
    component86.text = string.Empty;
    UILEBtn component87 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(4).GetComponent<UILEBtn>();
    GUIManager.Instance.InitLordEquipImg(((Component) component87).transform, (ushort) 0, (byte) 0, setScale: true, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    component87.m_Handler = (IUILEBtnClickHandler) this;
    component87.m_BtnID1 = 3;
    component87.m_BtnID2 = 3;
    UIText component88 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(4).GetChild(0).GetComponent<UIText>();
    component88.font = ttfFont;
    component88.text = string.Empty;
    UILEBtn component89 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(5).GetComponent<UILEBtn>();
    GUIManager.Instance.InitLordEquipImg(((Component) component89).transform, (ushort) 0, (byte) 0, setScale: true, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    component89.m_Handler = (IUILEBtnClickHandler) this;
    component89.m_BtnID1 = 3;
    component89.m_BtnID2 = 4;
    UIText component90 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(5).GetChild(0).GetComponent<UIText>();
    component90.font = ttfFont;
    component90.text = string.Empty;
    UILEBtn component91 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(6).GetComponent<UILEBtn>();
    GUIManager.Instance.InitLordEquipImg(((Component) component91).transform, (ushort) 0, (byte) 0, setScale: true, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    component91.m_Handler = (IUILEBtnClickHandler) this;
    component91.m_BtnID1 = 3;
    component91.m_BtnID2 = 5;
    UIText component92 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(6).GetChild(0).GetComponent<UIText>();
    component92.font = ttfFont;
    component92.text = string.Empty;
    this.LightBox1 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(7).GetChild(0).GetComponent<Image>();
    this.LightBox2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(7).GetChild(1).GetComponent<Image>();
    this.Flash = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(7).GetChild(3).GetComponent<Image>();
    this.MaterialLight = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(7).GetComponent<Image>();
    this.arrowPos = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(7).GetChild(2).GetComponent<RectTransform>();
    UIButton component93 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(21).GetComponent<UIButton>();
    component93.m_Handler = (IUIButtonClickHandler) this;
    component93.m_EffectType = e_EffectType.e_Scale;
    UIText component94 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(21).GetChild(0).GetComponent<UIText>();
    component94.font = ttfFont;
    component94.text = this.DM.mStringTable.GetStringByID(7450U);
    component93.m_BtnID1 = 5;
    component93.m_BtnID2 = 2;
    UIButton component95 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(22).GetComponent<UIButton>();
    component95.m_Handler = (IUIButtonClickHandler) this;
    component95.m_EffectType = e_EffectType.e_Scale;
    UIText component96 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(22).GetChild(0).GetComponent<UIText>();
    component96.font = ttfFont;
    component96.text = string.Empty;
    component95.m_BtnID1 = 5;
    component95.m_BtnID2 = 1;
    UIText component97 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(23).GetComponent<UIText>();
    component97.font = ttfFont;
    component97.text = string.Empty;
    UIButton component98 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(25).GetChild(0).GetComponent<UIButton>();
    component98.m_Handler = (IUIButtonClickHandler) this;
    component98.m_BtnID1 = 9;
    component98.m_BtnID2 = 1;
    UIButton component99 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(25).GetChild(4).GetComponent<UIButton>();
    component99.m_Handler = (IUIButtonClickHandler) this;
    component99.m_BtnID1 = 9;
    component99.m_BtnID2 = 2;
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      RectTransform component100 = this.AGS_Form.GetChild(10).GetComponent<RectTransform>();
      component100.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      component100.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    Image component101 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(25).GetChild(8).GetComponent<Image>();
    component101.sprite = this.door.LoadSprite("UI_main_redbox_01");
    ((MaskableGraphic) component101).material = this.door.LoadMaterial();
    component101.type = (Image.Type) 1;
    Image component102 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(25).GetChild(8).GetChild(0).GetComponent<Image>();
    component102.sprite = this.door.LoadSprite("UI_main_mess_ex");
    ((MaskableGraphic) component102).material = this.door.LoadMaterial();
    this.AGS_Form.GetChild(10).GetChild(0).GetChild(25).GetChild(8).gameObject.SetActive(false);
    this.POPLight1 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(25).GetChild(1).GetComponent<Image>();
    this.POPLight3 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(25).GetChild(5).GetComponent<Image>();
    this.Select = ((GameObject) UnityEngine.Object.Instantiate((UnityEngine.Object) this.AGS_Form.GetChild(7).gameObject)).GetComponent<RectTransform>();
    ((Component) this.Select).gameObject.SetActive(false);
    this.Forging = ((GameObject) UnityEngine.Object.Instantiate((UnityEngine.Object) this.AGS_Form.GetChild(11).gameObject)).GetComponent<RectTransform>();
    ((Component) this.Forging).gameObject.SetActive(false);
    ((Graphic) ((Component) this.Forging).GetComponent<Image>()).color = (Color) new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, (byte) 120);
    this.AGS_Forging = ((Transform) this.Forging).GetChild(0).GetComponent<UISpritesArray>();
    ((Graphic) this.LightBox1).color = new Color(1f, 1f, 1f, 0.0f);
    ((Graphic) this.LightBox2).color = new Color(1f, 1f, 1f, 0.0f);
    ((Graphic) this.Flash).color = new Color(1f, 1f, 1f, 0.0f);
    this.SetOpenStat(UILordEquip.eUIOpenStat.None);
    LordEquipData.CheckEquipExpired();
  }

  private void AfterLoader()
  {
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_ScrollArea = this.AGS_Form.GetChild(5).GetComponent<ScrollPanel>();
    UILEBtn component1 = this.AGS_Form.GetChild(6).GetChild(0).GetChild(0).GetComponent<UILEBtn>();
    component1.m_Handler = (IUILEBtnClickHandler) this;
    GUIManager.Instance.InitLordEquipImg(((Component) component1).transform, (ushort) 0, (byte) 0, setScale: this.OpenKind == eUI_LordEquipOpenKind.Collection, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    component1.transition = (Selectable.Transition) 0;
    Vector2 anchoredPosition = ((Component) component1).GetComponent<RectTransform>().anchoredPosition;
    for (int index = 1; index < 4; ++index)
    {
      RectTransform component2 = ((GameObject) UnityEngine.Object.Instantiate((UnityEngine.Object) ((Component) component1).gameObject)).GetComponent<RectTransform>();
      ((Transform) component2).SetParent(((Component) component1).transform.parent, false);
      component2.anchoredPosition = new Vector2(anchoredPosition.x + (float) (index * 117), anchoredPosition.y);
    }
    Transform child = this.AGS_Form.GetChild(6).GetChild(0).GetChild(1);
    child.SetAsLastSibling();
    RectTransform component3 = child.GetComponent<RectTransform>();
    ((Transform) component3).localScale = new Vector3(0.8f, 0.8f);
    component3.anchoredPosition = new Vector2(60f, 26f);
    anchoredPosition = component3.anchoredPosition;
    for (int index = 1; index < 4; ++index)
    {
      RectTransform component4 = ((GameObject) UnityEngine.Object.Instantiate((UnityEngine.Object) child.gameObject)).GetComponent<RectTransform>();
      ((Transform) component4).SetParent(((Component) component1).transform.parent, false);
      component4.anchoredPosition = new Vector2(anchoredPosition.x + (float) (index * 117), anchoredPosition.y);
    }
    component1.ReLinkScale();
    UILEBtn component5 = this.AGS_Form.GetChild(9).GetChild(7).GetChild(0).GetChild(0).GetComponent<UILEBtn>();
    component5.m_Handler = (IUILEBtnClickHandler) this;
    component5.m_BtnID1 = 2;
    component5.m_BtnID2 = 1;
    UIButton component6 = this.AGS_Form.GetChild(9).GetChild(7).GetChild(0).GetChild(2).GetComponent<UIButton>();
    component6.m_Handler = (IUIButtonClickHandler) this;
    component6.m_BtnID1 = 2;
    component6.m_BtnID2 = 1;
    component6.m_EffectType = e_EffectType.e_Scale;
    this.AGS_Form.GetChild(9).GetChild(7).GetChild(0).GetChild(2).GetComponent<UISpritesArray>().m_Image = component6.image;
    UIText component7 = this.AGS_Form.GetChild(9).GetChild(7).GetChild(0).GetChild(3).GetComponent<UIText>();
    component7.font = ttfFont;
    component7.text = this.DM.mStringTable.GetStringByID(7481U);
    GUIManager.Instance.InitLordEquipImg(((Component) component5).transform, (ushort) 0, (byte) 0, setScale: true, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    anchoredPosition = ((Component) component5).transform.parent.GetComponent<RectTransform>().anchoredPosition;
    for (int index = 1; index < 4; ++index)
    {
      RectTransform component8 = ((GameObject) UnityEngine.Object.Instantiate((UnityEngine.Object) ((Component) component5).transform.parent.gameObject)).transform.GetComponent<RectTransform>();
      ((Transform) component8).SetParent(((Component) component5).transform.parent.parent, false);
      component8.anchoredPosition = new Vector2(anchoredPosition.x + (float) (index * 151), anchoredPosition.y);
      component5 = ((Transform) component8).GetChild(0).GetComponent<UILEBtn>();
      component5.m_Handler = (IUILEBtnClickHandler) this;
      component5.m_BtnID1 = 2;
      component5.m_BtnID2 = index + 1;
      UIButton component9 = ((Transform) component8).GetChild(2).GetComponent<UIButton>();
      component9.m_Handler = (IUIButtonClickHandler) this;
      component9.m_BtnID1 = 2;
      component9.m_BtnID2 = index + 1;
      ((Transform) component8).GetChild(2).GetComponent<UISpritesArray>().m_Image = component9.image;
    }
    this.AGS_ScrollArea.IntiScrollPanel(488f, 0.0f, 0.0f, this.SPHeight, 6, (IUpDateScrollPanel) this);
    this.ScrollArea_RT = this.AGS_ScrollArea.transform.GetChild(0).GetComponent<RectTransform>();
    ((Transform) this.Select).SetParent(this.AGS_ScrollArea.transform.GetChild(0), false);
    ((Transform) this.Forging).SetParent(this.AGS_ScrollArea.transform.GetChild(0), false);
    this.SelectLight = ((Component) this.Select).GetComponent<Image>();
    this.AGS_ScrollPanel.IntiScrollPanel(273f, 0.0f, 0.0f, this.SPHeight, 10, (IUpDateScrollPanel) this);
    this.AGS_ScrollPanel2.IntiScrollPanel(228f, 0.0f, 0.0f, this.SPHeight, 10, (IUpDateScrollPanel) this);
    switch (UILordEquip.waitForReturn)
    {
      case eUI_LordEquipReturnKind.CollectionFilter:
        UILordEquip.EquipFilter = (int) UIEffectFilter.SeletedFilter;
        this.isFocused = false;
        UILordEquip.EquipFocus = (ushort) 0;
        UILordEquip.EquipFocusSub = (ushort) 0;
        this.SetOpenStat(UILordEquip.eUIOpenStat.Normal);
        break;
      case eUI_LordEquipReturnKind.GemEffectFilter:
        if (this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO != 0U)
        {
          this.SetOpenStat(UILordEquip.eUIOpenStat.GemSelect);
          RectTransform component10 = this.AGS_Form.GetChild(9).GetChild(1).GetComponent<RectTransform>();
          GUIManager.Instance.ChangeLordEquipImg((Transform) component10, this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus], eLordEquipDisplayKind.OnlyItem, this.DM.mLordEquip.isRoleEquipThis(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO));
          UILEBtn component11 = ((Component) component10).GetComponent<UILEBtn>();
          if ((UnityEngine.Object) component11 != (UnityEngine.Object) null)
          {
            component11.SetCountdown(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ExpireTime);
            break;
          }
          break;
        }
        this.SetOpenStat(UILordEquip.eUIOpenStat.Normal);
        break;
      case eUI_LordEquipReturnKind.ItemInfo:
        this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo);
        break;
      case eUI_LordEquipReturnKind.Collection_Gem:
        this.isFocused = false;
        UILordEquip.EquipFocus = (ushort) 0;
        UILordEquip.EquipFocusSub = (ushort) 0;
        this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.Gem);
        break;
      case eUI_LordEquipReturnKind.Collection_Mat:
        this.isFocused = false;
        UILordEquip.EquipFocus = (ushort) 0;
        UILordEquip.EquipFocusSub = (ushort) 0;
        this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.Material);
        break;
      default:
        this.isFocused = false;
        UILordEquip.EquipFocus = (ushort) 0;
        UILordEquip.EquipFocusSub = (ushort) 0;
        this.SetOpenStat(UILordEquip.eUIOpenStat.Normal);
        break;
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.TitleText);
    StringManager.Instance.DeSpawnString(this.NoContentText);
    StringManager.Instance.DeSpawnString(this.ItemNameText);
    StringManager.Instance.DeSpawnString(this.ItemLevelText);
    StringManager.Instance.DeSpawnString(this.PopUpHeaderText);
    StringManager.Instance.DeSpawnString(this.TimedItemCountText);
    for (int index = 0; index < this.GemBtnText.Length; ++index)
      StringManager.Instance.DeSpawnString(this.GemBtnText[index]);
    for (int index = 0; index < this.EffDescText.Length; ++index)
      StringManager.Instance.DeSpawnString(this.EffDescText[index]);
    for (int index = 0; index < this.PopupEffectText.Length; ++index)
      StringManager.Instance.DeSpawnString(this.PopupEffectText[index]);
    for (int index = 0; index < this.PopupAmountText.Length; ++index)
      StringManager.Instance.DeSpawnString(this.PopupAmountText[index]);
    UILordEquip.waitForReturn = eUI_LordEquipReturnKind.None;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (this.OpenStat)
    {
      case UILordEquip.eUIOpenStat.None:
      case UILordEquip.eUIOpenStat.PostSetStat:
        this.OpenStat = UILordEquip.eUIOpenStat.PostSetStat;
        return;
      case UILordEquip.eUIOpenStat.Normal:
        if (this.OpenKind == eUI_LordEquipOpenKind.Collection)
        {
          switch (this.CollectType)
          {
            case UILordEquip.eCollectType.Equip:
              UILordEquip.EquipTopIdx = this.AGS_ScrollArea.GetTopIdx();
              UILordEquip.EquipTopPos = this.ScrollArea_RT.anchoredPosition.y;
              break;
            case UILordEquip.eCollectType.Gem:
              UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
              UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
              break;
            case UILordEquip.eCollectType.Material:
              UILordEquip.MatTopIdx = this.AGS_ScrollArea.GetTopIdx();
              UILordEquip.MatTopPos = this.ScrollArea_RT.anchoredPosition.y;
              break;
          }
        }
        if ((this.OpenKind == eUI_LordEquipOpenKind.SelectSolt || this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt) && arg2 == 1)
        {
          this.OnStartSelect = true;
          if (this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ItemID == (ushort) 0)
            ((Component) this.Select).gameObject.SetActive(false);
        }
        this.SetupMainFilter(this.FilterKind);
        break;
      case UILordEquip.eUIOpenStat.ItemInfo:
        if (arg1 == 1)
        {
          this.SetOpenStat(this.OpenStat);
          break;
        }
        break;
      case UILordEquip.eUIOpenStat.GemSelect:
        if (arg1 == 2)
          this.SetupMainFilter(this.FilterKind);
        if (arg1 == 1 && this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ItemID == (ushort) 0)
        {
          this.SetOpenStat(UILordEquip.eUIOpenStat.Normal);
          break;
        }
        break;
      case UILordEquip.eUIOpenStat.GemCombine:
        if (arg1 == 2)
        {
          this.SetupMainFilter(this.FilterKind);
          break;
        }
        break;
      case UILordEquip.eUIOpenStat.MaterialCombine:
        if (arg1 == 3)
        {
          this.SetupMainFilter(this.FilterKind);
          break;
        }
        break;
    }
    if (this.AGS_Form.GetChild(10).gameObject.activeInHierarchy)
    {
      this.SetPopup(this.PopupKind, this.PopUpColor, this.combineColor);
      if (arg2 == 1)
        this.MaterialFlash = true;
    }
    this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(this.DM.mLordEquip.isEquipEvoReady);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (this.OpenStat == UILordEquip.eUIOpenStat.None || this.OpenStat == UILordEquip.eUIOpenStat.PostSetStat)
      return;
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        switch (this.OpenKind)
        {
          case eUI_LordEquipOpenKind.SelectSolt:
          case eUI_LordEquipOpenKind.SelectSetSolt:
            this.door.CloseMenu();
            return;
          case eUI_LordEquipOpenKind.Collection:
            switch (this.CollectType)
            {
              case UILordEquip.eCollectType.Equip:
                UILordEquip.EquipTopIdx = this.AGS_ScrollArea.GetTopIdx();
                UILordEquip.EquipTopPos = this.ScrollArea_RT.anchoredPosition.y;
                this.SetOpenStat(UILordEquip.eUIOpenStat.Normal);
                return;
              case UILordEquip.eCollectType.Gem:
                UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
                UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
                this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.Gem);
                return;
              case UILordEquip.eCollectType.Material:
                UILordEquip.MatTopIdx = this.AGS_ScrollArea.GetTopIdx();
                UILordEquip.MatTopPos = this.ScrollArea_RT.anchoredPosition.y;
                this.SetOpenStat(UILordEquip.eUIOpenStat.Normal, UILordEquip.eCollectType.Material);
                return;
              default:
                return;
            }
          case eUI_LordEquipOpenKind.CombineSelect:
            this.door.CloseMenu();
            return;
          default:
            return;
        }
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
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
            switch (this.OpenStat)
            {
              case UILordEquip.eUIOpenStat.Normal:
                if (this.OpenKind == eUI_LordEquipOpenKind.Collection)
                {
                  switch (this.CollectType)
                  {
                    case UILordEquip.eCollectType.Equip:
                      UILordEquip.EquipTopIdx = this.AGS_ScrollArea.GetTopIdx();
                      UILordEquip.EquipTopPos = this.ScrollArea_RT.anchoredPosition.y;
                      break;
                    case UILordEquip.eCollectType.Gem:
                      UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
                      UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
                      break;
                    case UILordEquip.eCollectType.Material:
                      UILordEquip.MatTopIdx = this.AGS_ScrollArea.GetTopIdx();
                      UILordEquip.MatTopPos = this.ScrollArea_RT.anchoredPosition.y;
                      break;
                  }
                }
                this.door.CloseMenu();
                return;
              case UILordEquip.eUIOpenStat.ItemInfo:
                this.isCollectChange = true;
                this.SetOpenStat(UILordEquip.eUIOpenStat.Normal);
                return;
              case UILordEquip.eUIOpenStat.GemSelect:
                ((Component) this.Select).gameObject.SetActive(false);
                UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
                UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
                this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo);
                return;
              default:
                return;
            }
          case 1:
            this.AGS_Form.GetChild(10).gameObject.SetActive(false);
            this.PopupKind = UILordEquip.eUIOpenStat.None;
            return;
          default:
            return;
        }
      case 1:
        switch (sender.m_BtnID2)
        {
          case 1:
            if (!this.isFocused)
              return;
            if (this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt && this.DM.RoleAttr.LordEquipEventData.ItemID != (ushort) 0 && this.DM.RoleAttr.LordEquipEventData.SerialNO != 0U && (int) this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO == (int) this.DM.RoleAttr.LordEquipEventData.SerialNO)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(261U), (ushort) byte.MaxValue);
              return;
            }
            this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo);
            return;
          case 2:
            if (!this.isFocused)
              return;
            if (this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt)
            {
              if ((int) UILordEquipSetEdit.showingSet.SerialNO[UILordEquipSetEdit.ChangingIdx] == (int) this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO)
              {
                UILordEquipSetEdit.showingSet.SerialNO[UILordEquipSetEdit.ChangingIdx] = 0U;
              }
              else
              {
                if ((int) this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ItemID).NeedLv > (int) this.DM.RoleAttr.Level)
                {
                  GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7504U), (ushort) byte.MaxValue);
                  return;
                }
                UILordEquipSetEdit.showingSet.SerialNO[UILordEquipSetEdit.ChangingIdx] = this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO;
              }
              this.door.CloseMenu();
              return;
            }
            if ((int) this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO == (int) LordEquipData.RoleEquipSerial[(int) this.EquipSolt - 1])
            {
              this.DM.mLordEquip.ChangeEquip((byte) ((uint) this.EquipSolt - 1U), 0U);
              return;
            }
            if ((int) this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ItemID).NeedLv > (int) this.DM.RoleAttr.Level)
            {
              GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7504U), (ushort) byte.MaxValue);
              return;
            }
            this.DM.mLordEquip.ChangeEquip((byte) ((uint) this.EquipSolt - 1U), this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO);
            return;
          case 3:
            if (!this.isFocused)
              return;
            UIAnvil.OpenKind = eUI_Anvil_OpenKind.UpgradeItem;
            UIAnvil.preSetIndex = UILordEquip.EquipFocus;
            this.door.CloseMenu();
            return;
          default:
            return;
        }
      case 2:
        if (sender.m_BtnID2 == 4)
        {
          GUIManager.Instance.OpenMessageBox(this.DM.mStringTable.GetStringByID(7523U), this.DM.mStringTable.GetStringByID(7520U));
          break;
        }
        if (this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].Gem[sender.m_BtnID2 - 1] == (ushort) 0)
        {
          UILordEquip.EquipFocusSub = (ushort) (byte) (sender.m_BtnID2 - 1);
          this.isCollectChange = true;
          this.SetOpenStat(UILordEquip.eUIOpenStat.GemSelect);
          break;
        }
        GUIManager.Instance.OpenGemRemoveUI(UILordEquip.EquipFocus, (byte) (sender.m_BtnID2 - 1));
        UILordEquip.waitForReturn = eUI_LordEquipReturnKind.ItemInfo;
        break;
      case 3:
        switch (sender.m_BtnID2)
        {
          case 1:
            if (!this.EquipOrTakeDown())
              return;
            this.door.ClearWindowStack();
            this.door.OpenMenu(EGUIWindow.UI_LordInfo, 1, bCameraMode: true);
            return;
          case 2:
            UIAnvil.preSetIndex = UILordEquip.EquipFocus;
            UIAnvil.SetOpen(eUI_Anvil_OpenKind.UpgradeItem, 0, 0);
            return;
          case 3:
            if (!this.isAbleDecompose((int) UILordEquip.EquipFocus))
              return;
            GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(7490U), this.DM.mStringTable.GetStringByID(7491U), 1);
            return;
          default:
            return;
        }
      case 4:
        switch (sender.m_BtnID2)
        {
          case 1:
            if (!((Component) this.Select).gameObject.activeInHierarchy)
              return;
            UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
            UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
            if (this.isAbleToImbueGame((int) UILordEquip.EquipFocus, this.DM.mLordEquip.LEGem[(int) this.MaterialFocus].ItemID, (byte) UILordEquip.EquipFocusSub))
            {
              this.DM.mLordEquip.InlayGem(this.DM.mLordEquip.LEGem[(int) this.MaterialFocus].ItemID, this.DM.mLordEquip.LEGem[(int) this.MaterialFocus].Color, this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO, (byte) UILordEquip.EquipFocusSub);
              ((Component) this.Select).gameObject.SetActive(false);
              this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo);
              return;
            }
            this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo);
            return;
          case 2:
            this.door.OpenMenu(EGUIWindow.UI_EffectFilter, 1, (int) UIEffectFilter.SeletedFilter);
            UILordEquip.waitForReturn = eUI_LordEquipReturnKind.GemEffectFilter;
            return;
          default:
            return;
        }
      case 5:
        switch (sender.m_BtnID2)
        {
          case 1:
            switch (this.PopupKind)
            {
              case UILordEquip.eUIOpenStat.GemCombine:
              case UILordEquip.eUIOpenStat.MaterialCombine:
                if (this.isCombine)
                {
                  if (LordEquipData.getItemQuantity(this.combineItemID, (byte) ((uint) this.combineColor - 1U)) < (ushort) 4)
                  {
                    GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455U), (ushort) byte.MaxValue);
                    return;
                  }
                  if ((int) this.MaterCount[(int) this.combineColor - 1] + 1 > (int) ushort.MaxValue)
                  {
                    GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7524U), (ushort) byte.MaxValue);
                    return;
                  }
                  this.DM.mLordEquip.upgradeMaterial(this.combineItemID, this.combineColor, (ushort) 1);
                  return;
                }
                if (LordEquipData.getItemQuantity(this.combineItemID, (byte) ((uint) this.combineColor + 1U)) < (ushort) 1)
                {
                  GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455U), (ushort) byte.MaxValue);
                  return;
                }
                if ((int) this.MaterCount[(int) this.combineColor - 1] + 4 > (int) ushort.MaxValue)
                {
                  GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7509U), (ushort) byte.MaxValue);
                  return;
                }
                this.DM.mLordEquip.DeComposeMaterial(this.combineItemID, (byte) ((uint) this.combineColor + 1U), (ushort) 1);
                return;
              default:
                this.AGS_Form.GetChild(10).gameObject.SetActive(false);
                this.PopupKind = UILordEquip.eUIOpenStat.None;
                return;
            }
          case 2:
            if (this.isCombine)
            {
              int itemQuantity = (int) LordEquipData.getItemQuantity(this.combineItemID, (byte) ((uint) this.combineColor - 1U));
              if (itemQuantity < 4)
              {
                GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455U), (ushort) byte.MaxValue);
                return;
              }
              int Quantity = (int) (ushort) (itemQuantity / 4);
              if ((int) this.MaterCount[(int) this.combineColor - 1] + Quantity > (int) ushort.MaxValue)
              {
                Quantity = (int) ushort.MaxValue - (int) this.MaterCount[(int) this.combineColor - 1];
                if (Quantity < 1)
                {
                  GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7524U), (ushort) byte.MaxValue);
                  return;
                }
              }
              this.DM.mLordEquip.upgradeMaterial(this.combineItemID, this.combineColor, (ushort) Quantity);
              return;
            }
            int Quantity1 = (int) LordEquipData.getItemQuantity(this.combineItemID, (byte) ((uint) this.combineColor + 1U));
            if (Quantity1 < 1)
            {
              GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7455U), (ushort) byte.MaxValue);
              return;
            }
            if ((int) this.MaterCount[(int) this.combineColor - 1] + Quantity1 * 4 > (int) ushort.MaxValue)
            {
              Quantity1 = ((int) ushort.MaxValue - (int) this.MaterCount[(int) this.combineColor - 1]) / 4;
              if (Quantity1 < 1)
              {
                GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7509U), (ushort) byte.MaxValue);
                return;
              }
            }
            this.DM.mLordEquip.DeComposeMaterial(this.combineItemID, (byte) ((uint) this.combineColor + 1U), (ushort) Quantity1);
            return;
          default:
            this.AGS_Form.GetChild(10).gameObject.SetActive(false);
            this.PopupKind = UILordEquip.eUIOpenStat.None;
            return;
        }
      case 6:
        switch (sender.m_BtnID2)
        {
          case 1:
          case 2:
          case 3:
            switch (this.CollectType)
            {
              case UILordEquip.eCollectType.Equip:
                UILordEquip.EquipTopIdx = this.AGS_ScrollArea.GetTopIdx();
                UILordEquip.EquipTopPos = this.ScrollArea_RT.anchoredPosition.y;
                break;
              case UILordEquip.eCollectType.Gem:
                UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
                UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
                break;
              case UILordEquip.eCollectType.Material:
                UILordEquip.MatTopIdx = this.AGS_ScrollArea.GetTopIdx();
                UILordEquip.MatTopPos = this.ScrollArea_RT.anchoredPosition.y;
                break;
            }
            this.SetCollectType((UILordEquip.eCollectType) sender.m_BtnID2);
            return;
          case 4:
            this.door.OpenMenu(EGUIWindow.UI_EffectFilter, arg2: (int) this.FilterKind);
            UILordEquip.waitForReturn = eUI_LordEquipReturnKind.CollectionFilter;
            return;
          case 5:
            switch (this.CollectType)
            {
              case UILordEquip.eCollectType.Equip:
                UILordEquip.EquipTopIdx = this.AGS_ScrollArea.GetTopIdx();
                UILordEquip.EquipTopPos = this.ScrollArea_RT.anchoredPosition.y;
                break;
              case UILordEquip.eCollectType.Gem:
                UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
                UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
                break;
              case UILordEquip.eCollectType.Material:
                UILordEquip.MatTopIdx = this.AGS_ScrollArea.GetTopIdx();
                UILordEquip.MatTopPos = this.ScrollArea_RT.anchoredPosition.y;
                break;
            }
            if (this.CollectType == UILordEquip.eCollectType.Gem)
            {
              GUIManager.Instance.OpenItemKindFilterUI((ushort) 18, (byte) 2, (byte) 0);
              UILordEquip.waitForReturn = eUI_LordEquipReturnKind.Collection_Gem;
              return;
            }
            GUIManager.Instance.OpenItemKindFilterUI((ushort) 18, (byte) 1, (byte) 0);
            UILordEquip.waitForReturn = eUI_LordEquipReturnKind.Collection_Mat;
            return;
          default:
            return;
        }
      case 7:
        GUIManager.Instance.UseOrSpend((ushort) 2010, this.DM.mStringTable.GetStringByID(4957U), (ushort) 0, (ushort) 0, (ushort) 0, maxcount: (ushort) 0);
        break;
      case 8:
        if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 15, (ushort) 0).Level < (byte) 1)
        {
          GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7533U), (ushort) byte.MaxValue);
          break;
        }
        if (this.EquipSolt != (byte) 0)
        {
          this.DM.mLordEquip.ForgeItem_mEquip = (byte) Mathf.Clamp((int) this.EquipSolt, 1, 6);
          this.DM.mLordEquip.ForgeItem_mColor = (byte) 4;
          this.door.OpenMenu(EGUIWindow.UI_Forge_Item);
          break;
        }
        this.DM.mLordEquip.ForgeItem_mEquip = (byte) Mathf.Clamp((int) (byte) this.FilterKind, 1, 6);
        this.DM.mLordEquip.ForgeItem_mColor = (byte) 4;
        this.door.OpenMenu(EGUIWindow.UI_Forge_Item);
        break;
      case 9:
        switch (sender.m_BtnID2)
        {
          case 1:
            this.isCombine = true;
            this.SetPopup(this.PopupKind, this.PopUpColor, this.combineColor);
            return;
          case 2:
            this.isCombine = false;
            this.SetPopup(this.PopupKind, this.PopUpColor, this.combineColor);
            return;
          default:
            return;
        }
      case 99:
        switch (this.OpenKind)
        {
          case eUI_LordEquipOpenKind.SelectSolt:
            GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7505U), DataManager.Instance.mStringTable.GetStringByID(7527U), bInfo: true);
            return;
          case eUI_LordEquipOpenKind.Collection:
            GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7404U), DataManager.Instance.mStringTable.GetStringByID(7526U), bInfo: true, BackExit: true);
            return;
          case eUI_LordEquipOpenKind.CombineSelect:
            GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(7430U), DataManager.Instance.mStringTable.GetStringByID(7527U), bInfo: true);
            return;
          default:
            return;
        }
    }
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
        switch (this.OpenStat)
        {
          case UILordEquip.eUIOpenStat.Normal:
            switch (this.OpenKind)
            {
              case eUI_LordEquipOpenKind.SelectSolt:
                if ((int) this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO != (int) LordEquipData.RoleEquipSerial[(int) this.EquipSolt - 1] && this.DM.mLordEquip.isRoleEquipThis(this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO))
                {
                  GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7444U), (ushort) byte.MaxValue);
                  return;
                }
                if (this.DM.RoleAttr.LordEquipEventData.ItemID != (ushort) 0 && (int) this.DM.RoleAttr.LordEquipEventData.SerialNO == (int) this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO)
                  return;
                if (this.DM.mLordEquip.isRoleEquipThis(this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO))
                  GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7444U), (ushort) byte.MaxValue);
                ((Transform) this.Select).position = ((Component) sender).transform.position;
                ((Component) this.Select).gameObject.SetActive(true);
                UILordEquip.EquipFocus = (ushort) sender.m_BtnID2;
                this.isFocused = true;
                this.SetSideInfo();
                return;
              case eUI_LordEquipOpenKind.Collection:
                switch (this.FilterKind)
                {
                  case UILordEquip.eItemFilterByKind.Gem:
                    this.MaterialFocus = (ushort) sender.m_BtnID2;
                    this.combineItemID = this.DM.mLordEquip.LEGem[(int) this.MaterialFocus].ItemID;
                    this.combineColor = this.DM.mLordEquip.LEGem[(int) this.MaterialFocus].Color;
                    UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
                    UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
                    this.isCombine = true;
                    this.SetOpenStat(UILordEquip.eUIOpenStat.GemCombine);
                    return;
                  case UILordEquip.eItemFilterByKind.Material:
                    this.MaterialFocus = (ushort) sender.m_BtnID2;
                    this.combineItemID = this.DM.mLordEquip.LEMaterial[(int) this.MaterialFocus].ItemID;
                    this.combineColor = this.DM.mLordEquip.LEMaterial[(int) this.MaterialFocus].Color;
                    UILordEquip.MatTopIdx = this.AGS_ScrollArea.GetTopIdx();
                    UILordEquip.MatTopPos = this.ScrollArea_RT.anchoredPosition.y;
                    this.isCombine = true;
                    this.SetOpenStat(UILordEquip.eUIOpenStat.MaterialCombine);
                    return;
                  default:
                    if (this.DM.mLordEquip.LordEquip[sender.m_BtnID2].ItemID == (ushort) 0)
                      return;
                    UILordEquip.EquipTopIdx = this.AGS_ScrollArea.GetTopIdx();
                    UILordEquip.EquipTopPos = this.ScrollArea_RT.anchoredPosition.y;
                    if (this.DM.RoleAttr.LordEquipEventData.ItemID != (ushort) 0 && (int) this.DM.RoleAttr.LordEquipEventData.SerialNO == (int) this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO)
                      UIAnvil.SetOpen(eUI_Anvil_OpenKind.NowForging, 0, 0);
                    UILordEquip.EquipFocus = (ushort) sender.m_BtnID2;
                    this.isFocused = true;
                    this.SetOpenStat(UILordEquip.eUIOpenStat.ItemInfo);
                    return;
                }
              case eUI_LordEquipOpenKind.CombineSelect:
                if (this.DM.RoleAttr.LordEquipEventData.ItemID != (ushort) 0 && (int) this.DM.RoleAttr.LordEquipEventData.SerialNO == (int) this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO)
                  return;
                ((Transform) this.Select).position = ((Component) sender).transform.position;
                ((Component) this.Select).gameObject.SetActive(true);
                UILordEquip.EquipFocus = (ushort) sender.m_BtnID2;
                this.isFocused = true;
                this.SetSideInfo();
                return;
              case eUI_LordEquipOpenKind.SelectSetSolt:
                if (UILordEquipSetEdit.showingSet.isInSet(this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO) && (int) UILordEquipSetEdit.showingSet.SerialNO[UILordEquipSetEdit.ChangingIdx] != (int) this.DM.mLordEquip.LordEquip[sender.m_BtnID2].SerialNO)
                  return;
                ((Transform) this.Select).position = ((Component) sender).transform.position;
                ((Component) this.Select).gameObject.SetActive(true);
                UILordEquip.EquipFocus = (ushort) sender.m_BtnID2;
                this.isFocused = true;
                this.SetSideInfo();
                return;
              default:
                return;
            }
          case UILordEquip.eUIOpenStat.ItemInfo:
            return;
          case UILordEquip.eUIOpenStat.GemSelect:
            ((Transform) this.Select).position = ((Component) sender).transform.position;
            this.MaterialFocus = (ushort) sender.m_BtnID2;
            ((Component) this.Select).gameObject.SetActive(true);
            this.SetGemInfo();
            return;
          default:
            return;
        }
      case 2:
        UILordEquip.EquipFocusSub = (ushort) sender.m_BtnID2;
        --UILordEquip.EquipFocusSub;
        if (this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].Gem[(int) UILordEquip.EquipFocusSub] == (ushort) 0)
          break;
        this.SetOpenStat(UILordEquip.eUIOpenStat.GemInfo);
        break;
      case 3:
        switch (this.CollectType)
        {
          case UILordEquip.eCollectType.Equip:
            UILordEquip.EquipTopIdx = this.AGS_ScrollArea.GetTopIdx();
            UILordEquip.EquipTopPos = this.ScrollArea_RT.anchoredPosition.y;
            break;
          case UILordEquip.eCollectType.Gem:
            UILordEquip.GemTopIdx = this.AGS_ScrollArea.GetTopIdx();
            UILordEquip.GemTopPos = this.ScrollArea_RT.anchoredPosition.y;
            break;
          case UILordEquip.eCollectType.Material:
            UILordEquip.MatTopIdx = this.AGS_ScrollArea.GetTopIdx();
            UILordEquip.MatTopPos = this.ScrollArea_RT.anchoredPosition.y;
            break;
        }
        this.SetPopup(this.PopupKind, this.PopUpColor, (byte) sender.m_BtnID2);
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || arg1 != 1)
      return;
    this.SetOpenStat(UILordEquip.eUIOpenStat.Normal);
    this.DM.mLordEquip.DeleteEquip(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    switch (panelId)
    {
      case 0:
        this.UpdateInvRow(item, dataIdx, panelObjectIdx);
        break;
      case 1:
        this.UpdateSideCompareRow(item, dataIdx, panelObjectIdx);
        break;
      case 2:
        this.UpdateEqInfoRow(item, dataIdx, panelObjectIdx);
        break;
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  private void SetOpenStat(UILordEquip.eUIOpenStat opStat, UILordEquip.eCollectType collect = UILordEquip.eCollectType.None)
  {
    switch (opStat)
    {
      case UILordEquip.eUIOpenStat.None:
        switch (this.OpenKind)
        {
          case eUI_LordEquipOpenKind.SelectSolt:
            int num = (int) this.EquipSolt;
            if (num > 6)
              num = 6;
            this.TitleText.ClearString();
            this.TitleText.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (num + 7430)));
            this.TitleText.AppendFormat(this.DM.mStringTable.GetStringByID(7467U));
            UIText component1 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
            component1.text = this.TitleText.ToString();
            component1.SetAllDirty();
            component1.cachedTextGenerator.Invalidate();
            break;
          case eUI_LordEquipOpenKind.Collection:
            this.TitleText.ClearString();
            this.TitleText.Append(this.DM.mStringTable.GetStringByID(7404U));
            UIText component2 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
            component2.text = this.TitleText.ToString();
            component2.SetAllDirty();
            component2.cachedTextGenerator.Invalidate();
            break;
          case eUI_LordEquipOpenKind.CombineSelect:
            this.TitleText.ClearString();
            this.TitleText.Append(this.DM.mStringTable.GetStringByID(7505U));
            UIText component3 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
            component3.text = this.TitleText.ToString();
            component3.SetAllDirty();
            component3.cachedTextGenerator.Invalidate();
            break;
        }
        break;
      case UILordEquip.eUIOpenStat.Normal:
        switch (this.OpenKind)
        {
          case eUI_LordEquipOpenKind.SelectSolt:
            this.AGS_Form.GetChild(4).gameObject.SetActive(true);
            this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
            this.AGS_Form.GetChild(5).gameObject.SetActive(true);
            this.AGS_Form.GetChild(8).gameObject.SetActive(true);
            this.AGS_Form.GetChild(9).gameObject.SetActive(false);
            this.AGS_Form.GetChild(10).gameObject.SetActive(false);
            this.AGS_Form.GetChild(8).GetChild(0).gameObject.SetActive(false);
            this.AGS_Form.GetChild(8).GetChild(1).gameObject.SetActive(true);
            this.AGS_Form.GetChild(8).GetChild(2).gameObject.SetActive(false);
            this.AGS_Form.GetChild(3).gameObject.SetActive(false);
            ((Component) this.Select).gameObject.SetActive(false);
            ((Component) this.Forging).gameObject.SetActive(false);
            int filter1 = (int) this.EquipSolt;
            if (filter1 > 6)
              filter1 = 6;
            this.TitleText.ClearString();
            this.TitleText.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (filter1 + 7430)));
            this.TitleText.AppendFormat(this.DM.mStringTable.GetStringByID(7467U));
            UIText component4 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
            component4.text = this.TitleText.ToString();
            component4.SetAllDirty();
            component4.cachedTextGenerator.Invalidate();
            this.OpenStat = opStat;
            this.SetupMainFilter((UILordEquip.eItemFilterByKind) filter1);
            break;
          case eUI_LordEquipOpenKind.Collection:
            this.AGS_Form.GetChild(4).gameObject.SetActive(true);
            this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
            this.AGS_Form.GetChild(5).gameObject.SetActive(true);
            this.AGS_Form.GetChild(8).gameObject.SetActive(true);
            this.AGS_Form.GetChild(9).gameObject.SetActive(false);
            this.AGS_Form.GetChild(10).gameObject.SetActive(false);
            this.AGS_Form.GetChild(8).GetChild(0).gameObject.SetActive(true);
            this.AGS_Form.GetChild(8).GetChild(1).gameObject.SetActive(false);
            this.AGS_Form.GetChild(8).GetChild(2).gameObject.SetActive(false);
            this.AGS_Form.GetChild(3).gameObject.SetActive(true);
            this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).gameObject.SetActive(false);
            this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(2).gameObject.SetActive(this.DM.mLordEquip.isEquipEvoReady);
            ((Component) this.Forging).gameObject.SetActive(false);
            if (collect == UILordEquip.eCollectType.None)
              this.SetCollectType(UILordEquip.eCollectType.Equip);
            else
              this.SetCollectType(collect);
            this.TitleText.ClearString();
            this.TitleText.Append(this.DM.mStringTable.GetStringByID(7404U));
            UIText component5 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
            component5.text = this.TitleText.ToString();
            component5.SetAllDirty();
            component5.cachedTextGenerator.Invalidate();
            this.OpenStat = opStat;
            break;
          case eUI_LordEquipOpenKind.CombineSelect:
            this.AGS_Form.GetChild(4).gameObject.SetActive(true);
            this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
            this.AGS_Form.GetChild(5).gameObject.SetActive(true);
            this.AGS_Form.GetChild(8).gameObject.SetActive(true);
            this.AGS_Form.GetChild(9).gameObject.SetActive(false);
            this.AGS_Form.GetChild(10).gameObject.SetActive(false);
            this.AGS_Form.GetChild(8).GetChild(0).gameObject.SetActive(false);
            this.AGS_Form.GetChild(8).GetChild(1).gameObject.SetActive(true);
            this.AGS_Form.GetChild(8).GetChild(2).gameObject.SetActive(false);
            this.AGS_Form.GetChild(3).gameObject.SetActive(true);
            ((Component) this.Select).gameObject.SetActive(false);
            ((Component) this.Forging).gameObject.SetActive(false);
            this.TitleText.ClearString();
            this.TitleText.Append(this.DM.mStringTable.GetStringByID(7505U));
            UIText component6 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
            component6.text = this.TitleText.ToString();
            component6.SetAllDirty();
            component6.cachedTextGenerator.Invalidate();
            this.OpenStat = opStat;
            this.SetupMainFilter(UILordEquip.eItemFilterByKind.IDFilter);
            break;
          case eUI_LordEquipOpenKind.SelectSetSolt:
            this.AGS_Form.GetChild(4).gameObject.SetActive(true);
            this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
            this.AGS_Form.GetChild(5).gameObject.SetActive(true);
            this.AGS_Form.GetChild(8).gameObject.SetActive(true);
            this.AGS_Form.GetChild(9).gameObject.SetActive(false);
            this.AGS_Form.GetChild(10).gameObject.SetActive(false);
            this.AGS_Form.GetChild(8).GetChild(0).gameObject.SetActive(false);
            this.AGS_Form.GetChild(8).GetChild(1).gameObject.SetActive(true);
            this.AGS_Form.GetChild(8).GetChild(2).gameObject.SetActive(false);
            this.AGS_Form.GetChild(3).gameObject.SetActive(false);
            ((Component) this.Select).gameObject.SetActive(false);
            ((Component) this.Forging).gameObject.SetActive(false);
            int filter2 = (int) this.EquipSolt;
            if (filter2 > 6)
              filter2 = 6;
            this.TitleText.ClearString();
            this.TitleText.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (filter2 + 7430)));
            this.TitleText.AppendFormat(this.DM.mStringTable.GetStringByID(7467U));
            UIText component7 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
            component7.text = this.TitleText.ToString();
            component7.SetAllDirty();
            component7.cachedTextGenerator.Invalidate();
            this.OpenStat = opStat;
            this.SetupMainFilter((UILordEquip.eItemFilterByKind) filter2);
            break;
        }
        break;
      case UILordEquip.eUIOpenStat.ItemInfo:
        if ((this.OpenKind == eUI_LordEquipOpenKind.SelectSolt || this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt) && opStat == UILordEquip.eUIOpenStat.Normal && !((Component) this.Select).gameObject.activeInHierarchy)
        {
          this.SetOpenStat(UILordEquip.eUIOpenStat.Normal);
          return;
        }
        if (this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ItemID == (ushort) 0)
        {
          this.SetOpenStat(UILordEquip.eUIOpenStat.Normal);
          return;
        }
        this.DM.mLordEquip.LoadLEMaterial();
        this.AGS_Form.GetChild(4).gameObject.SetActive(false);
        this.AGS_Form.GetChild(5).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).gameObject.SetActive(false);
        this.AGS_Form.GetChild(9).gameObject.SetActive(true);
        this.AGS_Form.GetChild(10).gameObject.SetActive(false);
        this.AGS_Form.GetChild(3).gameObject.SetActive(false);
        this.TitleText.ClearString();
        this.TitleText.Append(this.DM.mStringTable.GetStringByID(7470U));
        UIText component8 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
        component8.text = this.TitleText.ToString();
        component8.SetAllDirty();
        component8.cachedTextGenerator.Invalidate();
        this.SetupItemInfo();
        break;
      case UILordEquip.eUIOpenStat.GemSelect:
        this.AGS_Form.GetChild(4).gameObject.SetActive(true);
        this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
        this.AGS_Form.GetChild(5).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).gameObject.SetActive(true);
        this.AGS_Form.GetChild(9).gameObject.SetActive(false);
        this.AGS_Form.GetChild(10).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(1).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(2).gameObject.SetActive(true);
        this.AGS_Form.GetChild(3).gameObject.SetActive(false);
        ((Component) this.Select).gameObject.SetActive(false);
        ((Component) this.Forging).gameObject.SetActive(false);
        this.TitleText.ClearString();
        this.TitleText.Append(this.DM.mStringTable.GetStringByID(7478U));
        UIText component9 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
        component9.text = this.TitleText.ToString();
        component9.SetAllDirty();
        component9.cachedTextGenerator.Invalidate();
        UIText component10 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(11).GetChild(0).GetComponent<UIText>();
        if (UILordEquip.waitForReturn == eUI_LordEquipReturnKind.GemEffectFilter && UIEffectFilter.SeletedFilter != (ushort) 0)
        {
          component10.text = this.DM.mStringTable.GetStringByID((uint) this.DM.EffectData.GetRecordByKey(this.DM.LordEquipEffectFilter.GetRecordByIndex((int) (ushort) ((uint) UIEffectFilter.SeletedFilter - 1U)).effectID).InfoID);
          ((Graphic) component10).color = (Color) new Color32((byte) 0, byte.MaxValue, (byte) 0, byte.MaxValue);
          this.SetupMainFilter(UILordEquip.eItemFilterByKind.GemFilter);
          this.AGS_Form.GetChild(8).GetChild(2).GetChild(11).GetChild(2).gameObject.SetActive(true);
          break;
        }
        component10.text = this.DM.mStringTable.GetStringByID(7427U);
        ((Graphic) component10).color = Color.white;
        this.SetupMainFilter(UILordEquip.eItemFilterByKind.Gem);
        this.AGS_Form.GetChild(8).GetChild(2).GetChild(11).GetChild(2).gameObject.SetActive(false);
        break;
      case UILordEquip.eUIOpenStat.GemInfo:
        this.AGS_Form.GetChild(10).gameObject.SetActive(true);
        this.SetPopup(opStat, (byte) 0, (byte) 0);
        opStat = this.OpenStat;
        break;
      case UILordEquip.eUIOpenStat.GemCombine:
        this.AGS_Form.GetChild(10).gameObject.SetActive(true);
        this.SetPopup(opStat, (byte) 0, this.combineColor);
        opStat = this.OpenStat;
        break;
      case UILordEquip.eUIOpenStat.MaterialCombine:
        this.AGS_Form.GetChild(10).gameObject.SetActive(true);
        this.SetPopup(opStat, (byte) 0, this.combineColor);
        opStat = this.OpenStat;
        break;
    }
    this.OpenStat = opStat;
  }

  private void SetCollectType(UILordEquip.eCollectType type)
  {
    UIText component1 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(4).GetComponent<UIText>();
    this.isCollectChange = this.CollectType != type;
    this.CollectType = type;
    switch (type)
    {
      case UILordEquip.eCollectType.Equip:
        ((Component) this.Forging).gameObject.SetActive(false);
        this.SetupMainFilter((UILordEquip.eItemFilterByKind) UILordEquip.EquipFilter);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(3).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(4).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(2).GetChild(0).gameObject.SetActive(false);
        component1.text = this.DM.mStringTable.GetStringByID(7460U);
        UIText component2 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).GetChild(0).GetComponent<UIText>();
        if (GameConstants.IsBetween(UILordEquip.EquipFilter, 1, 6))
        {
          component2.text = this.DM.mStringTable.GetStringByID((uint) (UILordEquip.EquipFilter + 7430));
          ((Graphic) component2).color = (Color) new Color32((byte) 0, byte.MaxValue, (byte) 0, byte.MaxValue);
          this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).GetChild(2).gameObject.SetActive(true);
          break;
        }
        component2.text = this.DM.mStringTable.GetStringByID(7427U);
        ((Graphic) component2).color = Color.white;
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).GetChild(2).gameObject.SetActive(false);
        break;
      case UILordEquip.eCollectType.Gem:
        ((Component) this.Forging).gameObject.SetActive(false);
        this.SetupMainFilter(UILordEquip.eItemFilterByKind.Gem);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(3).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(4).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(2).GetChild(0).gameObject.SetActive(false);
        component1.text = this.DM.mStringTable.GetStringByID(7438U);
        UIEffectFilter.SeletedFilter = (ushort) 0;
        break;
      case UILordEquip.eCollectType.Material:
        ((Component) this.Forging).gameObject.SetActive(false);
        this.SetupMainFilter(UILordEquip.eItemFilterByKind.Material);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(6).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(3).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(4).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(1).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(0).GetChild(2).GetChild(0).gameObject.SetActive(true);
        component1.text = this.DM.mStringTable.GetStringByID(7438U);
        UIEffectFilter.SeletedFilter = (ushort) 0;
        break;
    }
  }

  private void SetSideInfo()
  {
    if (this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt)
      this.SetSideInfoForQuickChange();
    else if (!this.isFocused || this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ItemID == (ushort) 0)
    {
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(0).gameObject.SetActive(false);
      UIText component1 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(1).GetComponent<UIText>();
      this.ItemNameText.ClearString();
      component1.text = this.ItemNameText.ToString();
      component1.SetAllDirty();
      component1.cachedTextGenerator.Invalidate();
      UIText component2 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(3).GetComponent<UIText>();
      this.ItemLevelText.ClearString();
      component2.text = this.ItemLevelText.ToString();
      component2.SetAllDirty();
      component2.cachedTextGenerator.Invalidate();
      this.AGS_RareImg.gameObject.SetActive(false);
      this.SideSPHeight.Clear();
      this.AGS_ScrollPanel.AddNewDataHeight(this.SideSPHeight, 273f);
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(2).gameObject.SetActive(false);
      if (this.OpenKind == eUI_LordEquipOpenKind.CombineSelect && this.OpenStat == UILordEquip.eUIOpenStat.Normal)
      {
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).gameObject.SetActive(false);
      }
      else
      {
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).gameObject.SetActive(true);
      }
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(4).gameObject.SetActive(false);
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).gameObject.SetActive(false);
      this.selectedTimed = false;
    }
    else
    {
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(0).gameObject.SetActive(true);
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(2).gameObject.SetActive(this.DM.mLordEquip.CheckItemUpgradeReady(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus]));
      Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ItemID);
      UIText component3 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(1).GetComponent<UIText>();
      this.ItemNameText.ClearString();
      this.ItemNameText.Append(GameConstants.SItemRareHeader[(int) this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].Color]);
      this.ItemNameText.Append(this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipName));
      this.ItemNameText.Append("</color>");
      component3.text = this.ItemNameText.ToString();
      component3.SetAllDirty();
      component3.cachedTextGenerator.Invalidate();
      UIText component4 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(3).GetComponent<UIText>();
      this.ItemLevelText.ClearString();
      if ((int) recordByKey.NeedLv > (int) this.DM.RoleAttr.Level)
      {
        CString tmpS = StringManager.Instance.StaticString1024();
        tmpS.Append("<color=#FF0000FF>");
        tmpS.IntToFormat((long) recordByKey.NeedLv);
        tmpS.AppendFormat("{0}");
        tmpS.Append("</color>");
        this.ItemLevelText.StringToFormat(tmpS);
      }
      else
        this.ItemLevelText.IntToFormat((long) recordByKey.NeedLv);
      this.ItemLevelText.StringToFormat(LordEquipData.GetItemKindTalkID(recordByKey.EquipKind));
      this.ItemLevelText.AppendFormat(this.DM.mStringTable.GetStringByID(7437U));
      component4.text = this.ItemLevelText.ToString();
      component4.SetAllDirty();
      component4.cachedTextGenerator.Invalidate();
      this.AGS_RareImg.gameObject.SetActive(true);
      this.AGS_RareImg.SetSpriteIndex((int) this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].Color - 1);
      if (this.EquipSolt == (byte) 0)
        LordEquipData.GetEffectCompareList(new ItemLordEquip(), this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus], out this.effectCompareList);
      else
        LordEquipData.GetEffectCompareList(LordEquipData.RoleEquip[(int) this.EquipSolt - 1], this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus], out this.effectCompareList);
      LordEquipData.EffectTitleListCreater(this.effectCompareList);
      if (this.OpenKind == eUI_LordEquipOpenKind.CombineSelect && this.OpenStat == UILordEquip.eUIOpenStat.Normal)
      {
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).gameObject.SetActive(false);
      }
      else
      {
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).gameObject.SetActive(true);
        if (this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO == 0U || (int) this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO != (int) LordEquipData.RoleEquipSerial[(int) this.EquipSolt - 1])
        {
          this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetComponent<UISpritesArray>().SetSpriteIndex(0);
          this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7469U);
        }
        else
        {
          this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetComponent<UISpritesArray>().SetSpriteIndex(1);
          this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7494U);
        }
      }
      this.SideSPHeight.Clear();
      for (int index = 0; index < this.effectCompareList.Count; ++index)
      {
        if (this.effectCompareList[index].isTitel)
          this.SideSPHeight.Add(35f);
        else
          this.SideSPHeight.Add(32f);
      }
      if (this.SideSPHeight.Count > 1)
      {
        this.SideSPHeight.RemoveAt(this.SideSPHeight.Count - 1);
        this.SideSPHeight.Add(38f);
      }
      this.AGS_ScrollPanel.AddNewDataHeight(this.SideSPHeight);
      if (recordByKey.TimedType > (byte) 0)
      {
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(4).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).gameObject.SetActive(true);
        UIText component5 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).GetComponent<UIText>();
        RectTransform component6 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(7).GetComponent<RectTransform>();
        ((Transform) component6).localPosition = new Vector3(-1f, -1.5f, 0.0f);
        component6.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 250f);
        if (this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ExpireTime == 0L)
        {
          ((Graphic) component5).color = (Color) new Color32((byte) 53, (byte) 247, (byte) 108, byte.MaxValue);
          this.TimedItemCountText.ClearString();
          GameConstants.GetTimeString(this.TimedItemCountText, recordByKey.TimedTime);
          component5.text = this.TimedItemCountText.ToString();
          component5.cachedTextGenerator.Invalidate();
          component5.SetAllDirty();
          this.selectedTimed = false;
        }
        else
        {
          ((Graphic) component5).color = (Color) new Color32(byte.MaxValue, (byte) 101, (byte) 110, byte.MaxValue);
          this.TimedItemCountText.ClearString();
          GameConstants.GetTimeString(this.TimedItemCountText, (uint) Math.Max(0L, this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ExpireTime - this.DM.ServerTime));
          component5.text = this.TimedItemCountText.ToString();
          component5.cachedTextGenerator.Invalidate();
          component5.SetAllDirty();
          this.selectedTimed = true;
        }
      }
      else
      {
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(4).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).gameObject.SetActive(false);
        RectTransform component7 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(7).GetComponent<RectTransform>();
        ((Transform) component7).localPosition = new Vector3(-1f, 12.5f, 0.0f);
        component7.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 273f);
        this.selectedTimed = false;
      }
    }
  }

  private void SetSideInfoForQuickChange()
  {
    this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(3U);
    if (!this.isFocused || this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ItemID == (ushort) 0)
    {
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(0).gameObject.SetActive(false);
      UIText component1 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(1).GetComponent<UIText>();
      this.ItemNameText.ClearString();
      component1.text = this.ItemNameText.ToString();
      component1.SetAllDirty();
      component1.cachedTextGenerator.Invalidate();
      UIText component2 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(3).GetComponent<UIText>();
      this.ItemLevelText.ClearString();
      component2.text = this.ItemLevelText.ToString();
      component2.SetAllDirty();
      component2.cachedTextGenerator.Invalidate();
      this.AGS_RareImg.gameObject.SetActive(false);
      this.SideSPHeight.Clear();
      this.AGS_ScrollPanel.AddNewDataHeight(this.SideSPHeight, 273f);
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(2).gameObject.SetActive(false);
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).gameObject.SetActive(false);
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).gameObject.SetActive(true);
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).gameObject.SetActive(true);
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(4).gameObject.SetActive(false);
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).gameObject.SetActive(false);
      this.selectedTimed = false;
    }
    else
    {
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(0).gameObject.SetActive(true);
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(2).gameObject.SetActive(this.DM.mLordEquip.CheckItemUpgradeReady(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus]));
      Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ItemID);
      UIText component3 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(1).GetComponent<UIText>();
      this.ItemNameText.ClearString();
      this.ItemNameText.Append(GameConstants.SItemRareHeader[(int) this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].Color]);
      this.ItemNameText.Append(this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipName));
      this.ItemNameText.Append("</color>");
      component3.text = this.ItemNameText.ToString();
      component3.SetAllDirty();
      component3.cachedTextGenerator.Invalidate();
      UIText component4 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(3).GetComponent<UIText>();
      this.ItemLevelText.ClearString();
      if ((int) recordByKey.NeedLv > (int) this.DM.RoleAttr.Level)
      {
        CString tmpS = StringManager.Instance.StaticString1024();
        tmpS.Append("<color=#FF0000FF>");
        tmpS.IntToFormat((long) recordByKey.NeedLv);
        tmpS.AppendFormat("{0}");
        tmpS.Append("</color>");
        this.ItemLevelText.StringToFormat(tmpS);
      }
      else
        this.ItemLevelText.IntToFormat((long) recordByKey.NeedLv);
      this.ItemLevelText.StringToFormat(LordEquipData.GetItemKindTalkID(recordByKey.EquipKind));
      this.ItemLevelText.AppendFormat(this.DM.mStringTable.GetStringByID(7437U));
      component4.text = this.ItemLevelText.ToString();
      component4.SetAllDirty();
      component4.cachedTextGenerator.Invalidate();
      this.AGS_RareImg.gameObject.SetActive(true);
      this.AGS_RareImg.SetSpriteIndex((int) this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].Color - 1);
      if (UILordEquipSetEdit.showingSet.SerialNO[UILordEquipSetEdit.ChangingIdx] == 0U)
        LordEquipData.GetEffectCompareList(new ItemLordEquip(), this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus], out this.effectCompareList);
      else
        LordEquipData.GetEffectCompareList(this.DM.mLordEquip.LordEquip[UILordEquipSetEdit.SetDataIndex[UILordEquipSetEdit.ChangingIdx]], this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus], out this.effectCompareList);
      LordEquipData.EffectTitleListCreater(this.effectCompareList);
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).gameObject.SetActive(false);
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).gameObject.SetActive(true);
      this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).gameObject.SetActive(true);
      if (this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO == 0U || (int) this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO != (int) UILordEquipSetEdit.showingSet.SerialNO[UILordEquipSetEdit.ChangingIdx])
      {
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetComponent<UISpritesArray>().SetSpriteIndex(0);
      }
      else
      {
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetComponent<UISpritesArray>().SetSpriteIndex(1);
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7494U);
      }
      this.SideSPHeight.Clear();
      for (int index = 0; index < this.effectCompareList.Count; ++index)
      {
        if (this.effectCompareList[index].isTitel)
          this.SideSPHeight.Add(35f);
        else
          this.SideSPHeight.Add(32f);
      }
      if (this.SideSPHeight.Count > 1)
      {
        this.SideSPHeight.RemoveAt(this.SideSPHeight.Count - 1);
        this.SideSPHeight.Add(38f);
      }
      this.AGS_ScrollPanel.AddNewDataHeight(this.SideSPHeight);
      if (recordByKey.TimedType > (byte) 0)
      {
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(4).gameObject.SetActive(true);
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).gameObject.SetActive(true);
        UIText component5 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).GetComponent<UIText>();
        RectTransform component6 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(7).GetComponent<RectTransform>();
        ((Transform) component6).localPosition = new Vector3(-1f, -1.5f, 0.0f);
        component6.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 250f);
        if (this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ExpireTime == 0L)
        {
          ((Graphic) component5).color = (Color) new Color32((byte) 53, (byte) 247, (byte) 108, byte.MaxValue);
          this.TimedItemCountText.ClearString();
          GameConstants.GetTimeString(this.TimedItemCountText, recordByKey.TimedTime);
          component5.text = this.TimedItemCountText.ToString();
          component5.cachedTextGenerator.Invalidate();
          component5.SetAllDirty();
          this.selectedTimed = false;
        }
        else
        {
          ((Graphic) component5).color = (Color) new Color32(byte.MaxValue, (byte) 101, (byte) 110, byte.MaxValue);
          this.TimedItemCountText.ClearString();
          GameConstants.GetTimeString(this.TimedItemCountText, (uint) Math.Max(0L, this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ExpireTime - this.DM.ServerTime));
          component5.text = this.TimedItemCountText.ToString();
          component5.cachedTextGenerator.Invalidate();
          component5.SetAllDirty();
          this.selectedTimed = true;
        }
      }
      else
      {
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(4).gameObject.SetActive(false);
        this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).gameObject.SetActive(false);
        RectTransform component7 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(7).GetComponent<RectTransform>();
        ((Transform) component7).localPosition = new Vector3(-1f, 12.5f, 0.0f);
        component7.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 273f);
        this.selectedTimed = false;
      }
    }
  }

  private void SetGemInfo()
  {
    if (this.DM.mLordEquip.LEGem[(int) this.MaterialFocus].ItemID == (ushort) 0)
    {
      UIText component = this.AGS_Form.GetChild(8).GetChild(2).GetChild(1).GetComponent<UIText>();
      this.ItemNameText.ClearString();
      component.text = this.ItemNameText.ToString();
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
      this.AGS_RareImg.gameObject.SetActive(false);
      this.SideSPHeight.Clear();
      this.AGS_ScrollPanel.AddNewDataHeight(this.SideSPHeight, 273f);
    }
    else
    {
      Equip recordByKey1 = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LEGem[(int) this.MaterialFocus].ItemID);
      UIText component1 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(1).GetComponent<UIText>();
      this.ItemNameText.ClearString();
      this.ItemNameText.Append(GameConstants.SItemRareHeader[(int) this.DM.mLordEquip.LEGem[(int) this.MaterialFocus].Color]);
      this.ItemNameText.Append(this.DM.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
      this.ItemNameText.Append("</color>");
      component1.text = this.ItemNameText.ToString();
      component1.SetAllDirty();
      component1.cachedTextGenerator.Invalidate();
      this.effectList.Clear();
      LordEquipData.GetEffectList(this.DM.mLordEquip.LEGem[(int) this.MaterialFocus], this.effectList);
      for (int index = 0; index < 6; ++index)
      {
        UIText component2 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(3 + index).GetComponent<UIText>();
        this.PopupEffectText[index].ClearString();
        if (index < this.effectList.Count)
        {
          Effect recordByKey2 = this.DM.EffectData.GetRecordByKey(this.effectList[index].EffectID);
          this.PopupEffectText[index].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey2.InfoID));
          if (recordByKey2.ValueID == (ushort) 0)
          {
            this.PopupEffectText[index].IntToFormat((long) this.effectList[index].EffectValue);
            this.PopupEffectText[index].AppendFormat("{0} <color=#35F76CFF>+{1}</color>");
          }
          else
          {
            this.PopupEffectText[index].FloatToFormat((float) this.effectList[index].EffectValue / 100f, 2, false);
            this.PopupEffectText[index].AppendFormat("{0} <color=#35F76CFF>+{1}%</color>");
          }
        }
        component2.text = this.PopupEffectText[index].ToString();
        component2.SetAllDirty();
        component2.cachedTextGenerator.Invalidate();
      }
    }
  }

  private void SetPopup(UILordEquip.eUIOpenStat opStat, byte selectColor, byte SetSelect = 0)
  {
    switch (opStat)
    {
      case UILordEquip.eUIOpenStat.GemInfo:
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).gameObject.SetActive(false);
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(23).gameObject.SetActive(false);
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(24).gameObject.SetActive(true);
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(25).gameObject.SetActive(false);
        Transform child1 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(2);
        Equip recordByKey1 = DataManager.Instance.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].Gem[(int) UILordEquip.EquipFocusSub]);
        GUIManager.Instance.ChangeLordEquipImg(child1, recordByKey1.EquipKey, this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].GemColor[(int) UILordEquip.EquipFocusSub], gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        UIText component1 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(4).GetComponent<UIText>();
        this.PopUpHeaderText.ClearString();
        this.PopUpHeaderText.Append(GameConstants.SItemRareHeader[(int) this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].GemColor[(int) UILordEquip.EquipFocusSub]]);
        this.PopUpHeaderText.Append(this.DM.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
        this.PopUpHeaderText.Append("</color>");
        component1.text = this.PopUpHeaderText.ToString();
        component1.SetAllDirty();
        component1.cachedTextGenerator.Invalidate();
        RectTransform component2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(22).GetComponent<RectTransform>();
        component2.anchoredPosition = new Vector2(0.0f, -65f);
        UIText component3 = ((Transform) component2).GetChild(0).GetComponent<UIText>();
        component3.text = this.DM.mStringTable.GetStringByID(5026U);
        component3.SetAllDirty();
        component3.cachedTextGenerator.Invalidate();
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 360f);
        this.AGS_Form.GetChild(10).GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(0.0f, -100f);
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(21).gameObject.SetActive(false);
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(5).GetComponent<UISpritesArray>().SetSpriteIndex((int) this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].GemColor[(int) UILordEquip.EquipFocusSub] - 1);
        this.effectList.Clear();
        LordEquipData.GetEffectList(recordByKey1.EquipKey, this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].GemColor[(int) UILordEquip.EquipFocusSub], this.effectList);
        for (int index = 0; index < 6; ++index)
        {
          if (index < this.effectList.Count)
          {
            UIText component4 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(8 + index).GetComponent<UIText>();
            Effect recordByKey2 = this.DM.EffectData.GetRecordByKey(this.effectList[index].EffectID);
            component4.text = this.DM.mStringTable.GetStringByID((uint) recordByKey2.InfoID);
            ((Component) component4).gameObject.SetActive(true);
            UIText component5 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(14 + index).GetComponent<UIText>();
            this.PopupEffectText[index].ClearString();
            if (recordByKey2.ValueID == (ushort) 0)
            {
              this.PopupEffectText[index].IntToFormat((long) this.effectList[index].EffectValue);
              this.PopupEffectText[index].AppendFormat("{0}");
            }
            else
            {
              this.PopupEffectText[index].FloatToFormat((float) this.effectList[index].EffectValue / 100f, 2, false);
              if (!GUIManager.Instance.IsArabic)
                this.PopupEffectText[index].AppendFormat("{0}%");
              else
                this.PopupEffectText[index].AppendFormat("%{0}");
            }
            component5.text = this.PopupEffectText[index].ToString();
            ((Component) component5).gameObject.SetActive(true);
            component5.SetAllDirty();
            component5.cachedTextGenerator.Invalidate();
          }
          else
          {
            this.AGS_Form.GetChild(10).GetChild(0).GetChild(8 + index).GetComponent<UIText>().text = string.Empty;
            UIText component6 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(14 + index).GetComponent<UIText>();
            this.PopupEffectText[index].ClearString();
            component6.text = this.PopupEffectText[index].ToString();
            component6.SetAllDirty();
            component6.cachedTextGenerator.Invalidate();
          }
        }
        break;
      case UILordEquip.eUIOpenStat.GemCombine:
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).gameObject.SetActive(true);
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(23).gameObject.SetActive(true);
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(24).gameObject.SetActive(false);
        this.SetPopupFunction(this.isCombine);
        Transform child2 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(2);
        if (this.combineItemID != (ushort) 0)
        {
          GUIManager.Instance.ChangeLordEquipImg(child2, this.combineItemID, SetSelect, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
          Equip recordByKey3 = DataManager.Instance.EquipTable.GetRecordByKey(this.combineItemID);
          UIText component7 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(4).GetComponent<UIText>();
          this.PopUpHeaderText.ClearString();
          this.PopUpHeaderText.Append(GameConstants.SItemRareHeader[(int) SetSelect]);
          this.PopUpHeaderText.Append(this.DM.mStringTable.GetStringByID((uint) recordByKey3.EquipName));
          this.PopUpHeaderText.Append("</color>");
          component7.text = this.PopUpHeaderText.ToString();
          component7.SetAllDirty();
          component7.cachedTextGenerator.Invalidate();
          this.AGS_Form.GetChild(10).GetChild(0).GetChild(5).GetComponent<UISpritesArray>().SetSpriteIndex((int) SetSelect - 1);
          this.effectList.Clear();
          LordEquipData.GetEffectList(this.combineItemID, SetSelect, this.effectList);
          for (int index = 0; index < 6; ++index)
          {
            this.AGS_Form.GetChild(10).GetChild(0).GetChild(8 + index).gameObject.SetActive(false);
            this.AGS_Form.GetChild(10).GetChild(0).GetChild(14 + index).gameObject.SetActive(false);
            if (index < this.effectList.Count)
            {
              this.AGS_Form.GetChild(10).GetChild(0).GetChild(8 + index).gameObject.SetActive(true);
              this.AGS_Form.GetChild(10).GetChild(0).GetChild(14 + index).gameObject.SetActive(true);
              UIText component8 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(8 + index).GetComponent<UIText>();
              Effect recordByKey4 = this.DM.EffectData.GetRecordByKey(this.effectList[index].EffectID);
              component8.text = this.DM.mStringTable.GetStringByID((uint) recordByKey4.InfoID);
              UIText component9 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(14 + index).GetComponent<UIText>();
              if (recordByKey4.ValueID == (ushort) 0)
              {
                this.PopupEffectText[index].ClearString();
                this.PopupEffectText[index].FloatToFormat((float) this.effectList[index].EffectValue, 2, false);
                if (!GUIManager.Instance.IsArabic)
                  this.PopupEffectText[index].AppendFormat("+{0}");
                else
                  this.PopupEffectText[index].AppendFormat("{0}+");
              }
              else
              {
                this.PopupEffectText[index].ClearString();
                this.PopupEffectText[index].FloatToFormat((float) this.effectList[index].EffectValue / 100f, 2, false);
                if (!GUIManager.Instance.IsArabic)
                  this.PopupEffectText[index].AppendFormat("+{0}%");
                else
                  this.PopupEffectText[index].AppendFormat("%{0}");
              }
              component9.text = this.PopupEffectText[index].ToString();
              component9.SetAllDirty();
              component9.cachedTextGenerator.Invalidate();
            }
          }
          this.PopUpColor = selectColor;
        }
        if (SetSelect == (byte) 0)
          SetSelect = this.PopUpColor;
        if (this.isCombine)
        {
          if (!GameConstants.IsBetween((int) SetSelect, 2, 5))
            SetSelect = (byte) 2;
        }
        else if (!GameConstants.IsBetween((int) SetSelect, 1, 4))
          SetSelect = (byte) 4;
        this.combineColor = SetSelect;
        this.GetMaterialRareCount(false, this.combineItemID);
        if (this.isCombine)
        {
          for (int index = 0; index < 5; ++index)
          {
            Transform child3 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(2 + index);
            GUIManager.Instance.ChangeLordEquipImg(child3, this.combineItemID, (byte) (index + 1), gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
            UIText component10 = child3.GetChild(0).GetComponent<UIText>();
            this.PopupAmountText[index].ClearString();
            if (index + 2 != (int) SetSelect)
            {
              this.PopupAmountText[index].IntToFormat((long) this.MaterCount[index], bNumber: true);
              this.PopupAmountText[index].AppendFormat("{0:N}");
            }
            else
            {
              UIText component11 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(22).GetChild(0).GetComponent<UIText>();
              ushort x = this.MaterCount[index];
              if (x < (ushort) 4)
              {
                this.PopupAmountText[index].StringToFormat("<color=#FF5581FF>");
                ((Graphic) component11).color = (Color) new Color32(byte.MaxValue, (byte) 85, (byte) 129, byte.MaxValue);
              }
              else
              {
                this.PopupAmountText[index].StringToFormat("<color=#FFFFFFFF>");
                ((Graphic) component11).color = Color.white;
              }
              this.PopupAmountText[index].IntToFormat((long) x, bNumber: true);
              if (!GUIManager.Instance.IsArabic)
                this.PopupAmountText[index].AppendFormat("{0}{1}</color> / 4");
              else
                this.PopupAmountText[index].AppendFormat("4 / {0}{1}</color>");
            }
            component10.text = this.PopupAmountText[index].ToString();
            component10.SetAllDirty();
            component10.cachedTextGenerator.Invalidate();
          }
        }
        else
        {
          for (int index = 0; index < 5; ++index)
          {
            Transform child4 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(2 + index);
            GUIManager.Instance.ChangeLordEquipImg(child4, this.combineItemID, (byte) (index + 1), gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
            UIText component12 = child4.GetChild(0).GetComponent<UIText>();
            this.PopupAmountText[index].ClearString();
            if (index != (int) SetSelect)
            {
              this.PopupAmountText[index].IntToFormat((long) this.MaterCount[index], bNumber: true);
              this.PopupAmountText[index].AppendFormat("{0:N}");
            }
            else
            {
              UIText component13 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(22).GetChild(0).GetComponent<UIText>();
              ushort x = this.MaterCount[index];
              if (x < (ushort) 1)
              {
                this.PopupAmountText[index].StringToFormat("<color=#FF5581FF>");
                ((Graphic) component13).color = (Color) new Color32(byte.MaxValue, (byte) 85, (byte) 129, byte.MaxValue);
              }
              else
              {
                this.PopupAmountText[index].StringToFormat("<color=#FFFFFFFF>");
                ((Graphic) component13).color = Color.white;
              }
              this.PopupAmountText[index].IntToFormat((long) x, bNumber: true);
              if (!GUIManager.Instance.IsArabic)
                this.PopupAmountText[index].AppendFormat("{0}{1}</color> / 4");
              else
                this.PopupAmountText[index].AppendFormat("4 / {0}{1}</color>");
            }
            component12.text = this.PopupAmountText[index].ToString();
            component12.SetAllDirty();
            component12.cachedTextGenerator.Invalidate();
          }
        }
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 528f);
        this.AGS_Form.GetChild(10).GetChild(0).GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        RectTransform component14 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(22).GetComponent<RectTransform>();
        if ((!this.isCombine ? (this.MaterCount[(int) SetSelect] >= (ushort) 2 ? 1 : 0) : (this.MaterCount[(int) SetSelect - 2] >= (ushort) 8 ? 1 : 0)) != 0)
        {
          this.AGS_Form.GetChild(10).GetChild(0).GetChild(21).gameObject.SetActive(true);
          component14.anchoredPosition = new Vector2(115f, -230.5f);
        }
        else
        {
          this.AGS_Form.GetChild(10).GetChild(0).GetChild(21).gameObject.SetActive(false);
          component14.anchoredPosition = new Vector2(0.0f, -230.5f);
        }
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(23).gameObject.SetActive(false);
        RectTransform component15 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(7).GetComponent<RectTransform>();
        Vector2 vector2_1 = !this.isCombine ? this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(2 + (int) SetSelect).GetComponent<RectTransform>().anchoredPosition : this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(2 + (int) SetSelect - 1).GetComponent<RectTransform>().anchoredPosition;
        vector2_1.x -= 152f;
        vector2_1.y = component15.anchoredPosition.y;
        component15.anchoredPosition = vector2_1;
        break;
      case UILordEquip.eUIOpenStat.MaterialCombine:
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).gameObject.SetActive(true);
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(23).gameObject.SetActive(true);
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(24).gameObject.SetActive(false);
        this.SetPopupFunction(this.isCombine);
        Transform child5 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(2);
        if (this.combineItemID != (ushort) 0)
        {
          Equip recordByKey5 = DataManager.Instance.EquipTable.GetRecordByKey(this.combineItemID);
          GUIManager.Instance.ChangeLordEquipImg(child5, this.combineItemID, SetSelect, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
          UIText component16 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(4).GetComponent<UIText>();
          this.PopUpHeaderText.ClearString();
          this.PopUpHeaderText.Append(GameConstants.SItemRareHeader[(int) SetSelect]);
          this.PopUpHeaderText.Append(this.DM.mStringTable.GetStringByID((uint) recordByKey5.EquipName));
          this.PopUpHeaderText.Append("</color>");
          component16.text = this.PopUpHeaderText.ToString();
          component16.SetAllDirty();
          component16.cachedTextGenerator.Invalidate();
          this.AGS_Form.GetChild(10).GetChild(0).GetChild(5).GetComponent<UISpritesArray>().SetSpriteIndex((int) SetSelect - 1);
          this.AGS_Form.GetChild(10).GetChild(0).GetChild(23).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID((uint) recordByKey5.EquipInfo);
          this.PopUpColor = selectColor;
        }
        if (SetSelect == (byte) 0)
          SetSelect = this.PopUpColor;
        if (this.isCombine)
        {
          if (!GameConstants.IsBetween((int) SetSelect, 2, 5))
            SetSelect = (byte) 2;
        }
        else if (!GameConstants.IsBetween((int) SetSelect, 1, 4))
          SetSelect = (byte) 4;
        this.combineColor = SetSelect;
        for (int index = 0; index < 6; ++index)
        {
          this.AGS_Form.GetChild(10).GetChild(0).GetChild(8 + index).gameObject.SetActive(false);
          this.AGS_Form.GetChild(10).GetChild(0).GetChild(14 + index).gameObject.SetActive(false);
        }
        this.GetMaterialRareCount(true, this.combineItemID);
        if (this.isCombine)
        {
          for (int index = 0; index < 5; ++index)
          {
            Transform child6 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(2 + index);
            GUIManager.Instance.ChangeLordEquipImg(child6, this.combineItemID, (byte) (index + 1), gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
            UIText component17 = child6.GetChild(0).GetComponent<UIText>();
            this.PopupAmountText[index].ClearString();
            if (index + 2 != (int) SetSelect)
            {
              this.PopupAmountText[index].IntToFormat((long) this.MaterCount[index], bNumber: true);
              this.PopupAmountText[index].AppendFormat("{0:N}");
            }
            else
            {
              UIText component18 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(22).GetChild(0).GetComponent<UIText>();
              ushort x = this.MaterCount[index];
              if (x < (ushort) 4)
              {
                this.PopupAmountText[index].StringToFormat("<color=#FF5581FF>");
                ((Graphic) component18).color = (Color) new Color32(byte.MaxValue, (byte) 85, (byte) 129, byte.MaxValue);
              }
              else
              {
                this.PopupAmountText[index].StringToFormat("<color=#FFFFFFFF>");
                ((Graphic) component18).color = Color.white;
              }
              this.PopupAmountText[index].IntToFormat((long) x, bNumber: true);
              if (!GUIManager.Instance.IsArabic)
                this.PopupAmountText[index].AppendFormat("{0}{1}</color> / 4");
              else
                this.PopupAmountText[index].AppendFormat("4 / {0}{1}</color>");
            }
            component17.text = this.PopupAmountText[index].ToString();
            component17.SetAllDirty();
            component17.cachedTextGenerator.Invalidate();
          }
        }
        else
        {
          for (int index = 0; index < 5; ++index)
          {
            Transform child7 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(2 + index);
            GUIManager.Instance.ChangeLordEquipImg(child7, this.combineItemID, (byte) (index + 1), gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
            UIText component19 = child7.GetChild(0).GetComponent<UIText>();
            this.PopupAmountText[index].ClearString();
            if (index != (int) SetSelect)
            {
              this.PopupAmountText[index].IntToFormat((long) this.MaterCount[index], bNumber: true);
              this.PopupAmountText[index].AppendFormat("{0:N}");
            }
            else
            {
              UIText component20 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(22).GetChild(0).GetComponent<UIText>();
              ushort x = this.MaterCount[index];
              if (x < (ushort) 1)
              {
                this.PopupAmountText[index].StringToFormat("<color=#FF5581FF>");
                ((Graphic) component20).color = (Color) new Color32(byte.MaxValue, (byte) 85, (byte) 129, byte.MaxValue);
              }
              else
              {
                this.PopupAmountText[index].StringToFormat("<color=#FFFFFFFF>");
                ((Graphic) component20).color = Color.white;
              }
              this.PopupAmountText[index].IntToFormat((long) x, bNumber: true);
              if (!GUIManager.Instance.IsArabic)
                this.PopupAmountText[index].AppendFormat("{0}{1}</color> / 1");
              else
                this.PopupAmountText[index].AppendFormat("1 / {0}{1}</color>");
            }
            component19.text = this.PopupAmountText[index].ToString();
            component19.SetAllDirty();
            component19.cachedTextGenerator.Invalidate();
          }
        }
        this.AGS_Form.GetChild(10).GetChild(0).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 528f);
        this.AGS_Form.GetChild(10).GetChild(0).GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        RectTransform component21 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(22).GetComponent<RectTransform>();
        if ((!this.isCombine ? (this.MaterCount[(int) SetSelect] >= (ushort) 2 ? 1 : 0) : (this.MaterCount[(int) SetSelect - 2] >= (ushort) 8 ? 1 : 0)) != 0)
        {
          this.AGS_Form.GetChild(10).GetChild(0).GetChild(21).gameObject.SetActive(true);
          component21.anchoredPosition = new Vector2(115f, -230.5f);
        }
        else
        {
          this.AGS_Form.GetChild(10).GetChild(0).GetChild(21).gameObject.SetActive(false);
          component21.anchoredPosition = new Vector2(0.0f, -230.5f);
        }
        RectTransform component22 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(7).GetComponent<RectTransform>();
        Vector2 vector2_2 = !this.isCombine ? this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(2 + (int) SetSelect).GetComponent<RectTransform>().anchoredPosition : this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(2 + (int) SetSelect - 1).GetComponent<RectTransform>().anchoredPosition;
        vector2_2.x -= 152f;
        vector2_2.y = component22.anchoredPosition.y;
        component22.anchoredPosition = vector2_2;
        break;
    }
    this.PopupKind = opStat;
  }

  private void SetPopupFunction(bool isCombine)
  {
    this.AGS_Form.GetChild(10).GetChild(0).GetChild(25).gameObject.SetActive(true);
    this.isCombine = isCombine;
    if (isCombine)
    {
      this.AGS_Form.GetChild(10).GetChild(0).GetChild(25).GetChild(1).gameObject.SetActive(true);
      this.AGS_Form.GetChild(10).GetChild(0).GetChild(25).GetChild(5).gameObject.SetActive(false);
      this.AGS_Form.GetChild(10).GetChild(0).GetChild(22).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7451U);
      this.AGS_Form.GetChild(10).GetChild(0).GetChild(21).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7450U);
      this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7466U);
      ((Transform) this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(7).GetChild(2).GetComponent<RectTransform>()).localScale = Vector3.one;
      ((Transform) this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(7).GetChild(3).GetComponent<RectTransform>()).localScale = Vector3.one;
    }
    else
    {
      this.AGS_Form.GetChild(10).GetChild(0).GetChild(25).GetChild(1).gameObject.SetActive(false);
      this.AGS_Form.GetChild(10).GetChild(0).GetChild(25).GetChild(5).gameObject.SetActive(true);
      this.AGS_Form.GetChild(10).GetChild(0).GetChild(22).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(9547U);
      this.AGS_Form.GetChild(10).GetChild(0).GetChild(21).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7530U);
      this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(7532U);
      ((Transform) this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(7).GetChild(2).GetComponent<RectTransform>()).localScale = new Vector3(-1f, 1f, 1f);
      ((Transform) this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(7).GetChild(3).GetComponent<RectTransform>()).localScale = new Vector3(-1f, 1f, 1f);
    }
  }

  private void SetupItemInfo()
  {
    RectTransform component1 = this.AGS_Form.GetChild(9).GetChild(1).GetComponent<RectTransform>();
    ((Component) component1).GetComponent<UILEBtn>().SetCountdown(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ExpireTime);
    bool isEquip = this.DM.mLordEquip.isRoleEquipThis(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO);
    GUIManager.Instance.ChangeLordEquipImg((Transform) component1, this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus], eLordEquipDisplayKind.OnlyItem, isEquip);
    UIText component2 = this.AGS_Form.GetChild(9).GetChild(2).GetChild(0).GetComponent<UIText>();
    if (isEquip)
    {
      this.AGS_Form.GetChild(9).GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(1);
      component2.text = this.DM.mStringTable.GetStringByID(7494U);
    }
    else
    {
      this.AGS_Form.GetChild(9).GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(0);
      component2.text = this.DM.mStringTable.GetStringByID(7469U);
    }
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
    for (int index = 0; index < 4; ++index)
    {
      RectTransform component3 = this.AGS_Form.GetChild(9).GetChild(7).GetChild(index).GetComponent<RectTransform>();
      UIText component4 = ((Transform) component3).GetChild(3).GetComponent<UIText>();
      if (index == 3)
      {
        GUIManager.Instance.ChangeLordEquipImg(((Transform) component3).GetChild(0), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        this.GemBtnText[index].ClearString();
        this.GemBtnText[index].Append(this.DM.mStringTable.GetStringByID(7473U));
        ((Transform) component3).GetChild(1).gameObject.SetActive(true);
        ((Transform) component3).GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(3);
      }
      else if (this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].Gem[index] == (ushort) 0)
      {
        GUIManager.Instance.ChangeLordEquipImg(((Transform) component3).GetChild(0), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        this.GemBtnText[index].ClearString();
        this.GemBtnText[index].Append(this.DM.mStringTable.GetStringByID(7471U));
        ((Transform) component3).GetChild(1).gameObject.SetActive(false);
        ((Transform) component3).GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(2);
      }
      else
      {
        this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].Gem[index]);
        GUIManager.Instance.ChangeLordEquipImg(((Transform) component3).GetChild(0), this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].Gem[index], this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].GemColor[index], eLordEquipDisplayKind.Gems_Name, (ushort) 0, (ushort) 0, (ushort) 0, (ushort) 0, (ushort) 0);
        this.GemBtnText[index].ClearString();
        this.GemBtnText[index].Append(this.DM.mStringTable.GetStringByID(7472U));
        ((Transform) component3).GetChild(1).gameObject.SetActive(false);
        ((Transform) component3).GetChild(2).GetComponent<UISpritesArray>().SetSpriteIndex(0);
      }
      component4.text = this.GemBtnText[index].ToString();
      component4.SetAllDirty();
      component4.cachedTextGenerator.Invalidate();
    }
    Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ItemID);
    UIText component5 = this.AGS_Form.GetChild(9).GetChild(4).GetComponent<UIText>();
    this.ItemNameText.ClearString();
    this.ItemNameText.Append(GameConstants.SItemRareHeader[(int) this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].Color]);
    this.ItemNameText.Append(this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipName));
    this.ItemNameText.Append("</color>");
    component5.text = this.ItemNameText.ToString();
    component5.SetAllDirty();
    component5.cachedTextGenerator.Invalidate();
    this.AGS_ItemRare.SetSpriteIndex((int) this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].Color - 1);
    UIText component6 = this.AGS_Form.GetChild(9).GetChild(6).GetComponent<UIText>();
    this.ItemLevelText.ClearString();
    if ((int) recordByKey.NeedLv > (int) this.DM.RoleAttr.Level)
    {
      CString tmpS = StringManager.Instance.StaticString1024();
      tmpS.Append("<color=#FF0000FF>");
      tmpS.IntToFormat((long) recordByKey.NeedLv);
      tmpS.AppendFormat("{0}");
      tmpS.Append("</color>");
      this.ItemLevelText.StringToFormat(tmpS);
    }
    else
      this.ItemLevelText.IntToFormat((long) recordByKey.NeedLv);
    this.ItemLevelText.StringToFormat(LordEquipData.GetItemKindTalkID(recordByKey.EquipKind));
    this.ItemLevelText.AppendFormat(this.DM.mStringTable.GetStringByID(7437U));
    component6.text = this.ItemLevelText.ToString();
    component6.SetAllDirty();
    component6.cachedTextGenerator.Invalidate();
    this.effectList.Clear();
    LordEquipData.GetEffectList(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus], this.effectList, (byte) 0);
    if (this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].Color == (byte) 5)
    {
      this.AGS_Form.GetChild(9).GetChild(8).gameObject.SetActive(false);
      this.AGS_Form.GetChild(9).GetChild(12).gameObject.SetActive(true);
    }
    else
    {
      this.AGS_Form.GetChild(9).GetChild(8).gameObject.SetActive(true);
      this.AGS_Form.GetChild(9).GetChild(12).gameObject.SetActive(false);
    }
    this.AGS_Form.GetChild(9).GetChild(8).GetChild(2).gameObject.SetActive(this.DM.mLordEquip.CheckItemUpgradeReady(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus]));
    this.SPHeight.Clear();
    if (this.effectList.Count > 0)
    {
      for (int index = 0; index < this.effectList.Count - 1; ++index)
        this.SPHeight.Add(26f);
      this.SPHeight.Add(32f);
    }
    this.AGS_ScrollPanel2.AddNewDataHeight(this.SPHeight, 228f);
  }

  private void UpdateInvRow(GameObject item, int dataIdx, int panelObjectIdx)
  {
    if (dataIdx + 1 == this.SPHeight.Count && this.ShowUnlockPanel)
    {
      item.transform.GetChild(0).gameObject.SetActive(false);
      item.transform.GetChild(1).gameObject.SetActive(true);
      UIButton component = item.transform.GetChild(1).GetChild(0).GetComponent<UIButton>();
      component.m_Handler = (IUIButtonClickHandler) this;
      component.m_BtnID1 = 7;
    }
    else
    {
      for (int index1 = 0; index1 < 4; ++index1)
      {
        ushort index2 = (ushort) (dataIdx * 4 + index1);
        UILEBtn component = item.transform.GetChild(0).GetChild(index1).GetComponent<UILEBtn>();
        component.m_Handler = (IUILEBtnClickHandler) this;
        component.m_BtnID1 = 1;
        component.m_BtnID2 = 0;
        component.ReLinkScale();
        Transform child = item.transform.GetChild(0).GetChild(index1 + 4);
        if ((int) index2 < this.FilterItem.Count)
        {
          component.m_BtnID2 = (int) this.FilterItem[(int) index2];
          switch (this.FilterKind)
          {
            case UILordEquip.eItemFilterByKind.Gem:
            case UILordEquip.eItemFilterByKind.GemFilter:
              GUIManager.Instance.ChangeLordEquipImg(((Component) component).transform, this.DM.mLordEquip.LEGem[(int) this.FilterItem[(int) index2]]);
              child.gameObject.SetActive(false);
              break;
            case UILordEquip.eItemFilterByKind.Material:
              GUIManager.Instance.ChangeLordEquipImg(((Component) component).transform, this.DM.mLordEquip.LEMaterial[(int) this.FilterItem[(int) index2]]);
              child.gameObject.SetActive(false);
              break;
            default:
              if (this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt)
                GUIManager.Instance.ChangeLordEquipImg(((Component) component).transform, this.DM.mLordEquip.LordEquip[(int) this.FilterItem[(int) index2]], isEquip: UILordEquipSetEdit.showingSet.isInSet(this.DM.mLordEquip.LordEquip[(int) this.FilterItem[(int) index2]].SerialNO));
              else
                GUIManager.Instance.ChangeLordEquipImg(((Component) component).transform, this.DM.mLordEquip.LordEquip[(int) this.FilterItem[(int) index2]], isEquip: this.DM.mLordEquip.isRoleEquipThis(this.DM.mLordEquip.LordEquip[(int) this.FilterItem[(int) index2]].SerialNO));
              component.SetCountdown(this.DM.mLordEquip.LordEquip[(int) this.FilterItem[(int) index2]].ExpireTime);
              child.gameObject.SetActive(this.OpenKind == eUI_LordEquipOpenKind.Collection && this.DM.mLordEquip.CheckItemUpgradeReady(this.DM.mLordEquip.LordEquip[(int) this.FilterItem[(int) index2]]));
              if (this.OpenStat == UILordEquip.eUIOpenStat.Normal)
              {
                if (this.OpenKind != eUI_LordEquipOpenKind.Collection && (int) this.FilterItem[(int) index2] == (int) UILordEquip.EquipFocus && this.isFocused)
                {
                  ((Transform) this.Select).position = ((Component) component).transform.position;
                  ((Component) this.Select).gameObject.SetActive(true);
                }
                if (this.DM.RoleAttr.LordEquipEventData.ItemID != (ushort) 0 && this.DM.RoleAttr.LordEquipEventData.SerialNO != 0U && (int) this.DM.mLordEquip.LordEquip[(int) this.FilterItem[(int) index2]].SerialNO == (int) this.DM.RoleAttr.LordEquipEventData.SerialNO)
                {
                  ((Transform) this.Forging).position = ((Component) component).transform.position;
                  ((Component) this.Forging).gameObject.SetActive(true);
                }
                if (this.lockEmptyForge && (int) this.FilterItem[(int) index2] == this.lockedIdx)
                {
                  GUIManager.Instance.ChangeLordEquipImg(((Component) component).transform, this.DM.RoleAttr.LordEquipEventData);
                  ((Transform) this.Forging).position = ((Component) component).transform.position;
                  ((Component) this.Forging).gameObject.SetActive(true);
                  break;
                }
                break;
              }
              break;
          }
        }
        ((Component) component).gameObject.SetActive((int) index2 < this.FilterItem.Count);
        if (this.OpenKind != eUI_LordEquipOpenKind.Collection || (int) index2 >= this.FilterItem.Count)
          child.gameObject.SetActive(false);
      }
      item.transform.GetChild(0).gameObject.SetActive(true);
      item.transform.GetChild(1).gameObject.SetActive(false);
    }
  }

  private void UpdateSideCompareRow(GameObject item, int dataIdx, int panelObjectIdx)
  {
    Effect recordByKey = this.DM.EffectData.GetRecordByKey(this.effectCompareList[dataIdx].EffectID);
    if (this.effectCompareList[dataIdx].isTitel)
    {
      UIText component = item.transform.GetChild(0).GetComponent<UIText>();
      item.transform.GetChild(0).gameObject.SetActive(true);
      item.transform.GetChild(1).gameObject.SetActive(false);
      component.text = this.DM.mStringTable.GetStringByID((uint) (ushort) (8484U + (uint) this.effectCompareList[dataIdx].group));
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
    }
    else
    {
      UIText component = item.transform.GetChild(1).GetComponent<UIText>();
      item.transform.GetChild(0).gameObject.SetActive(false);
      item.transform.GetChild(1).gameObject.SetActive(true);
      this.EffDescText[panelObjectIdx].ClearString();
      this.EffDescText[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey.InfoID));
      if (this.effectCompareList[dataIdx].isEven)
        this.EffDescText[panelObjectIdx].StringToFormat("<color=#FFFFFF>");
      else if (this.effectCompareList[dataIdx].EffectValue < 0)
        this.EffDescText[panelObjectIdx].StringToFormat("<color=#FF656EFF>");
      else
        this.EffDescText[panelObjectIdx].StringToFormat("<color=#35F76CFF>+");
      if (recordByKey.ValueID == (ushort) 0)
      {
        this.EffDescText[panelObjectIdx].IntToFormat((long) this.effectCompareList[dataIdx].EffectValue);
        this.EffDescText[panelObjectIdx].AppendFormat("<color=#FFEC87FF>{0}</color> {1} {2}</color>");
      }
      else
      {
        float f = (float) this.effectCompareList[dataIdx].EffectValue / 100f;
        this.EffDescText[panelObjectIdx].FloatToFormat(f, 2, false);
        this.EffDescText[panelObjectIdx].AppendFormat("<color=#FFEC87FF>{0}</color> {1} {2}%</color>");
      }
      component.text = this.EffDescText[panelObjectIdx].ToString();
      component.SetAllDirty();
      component.cachedTextGenerator.Invalidate();
      if (GameConstants.IsBigStyle())
        return;
      component.resizeTextMaxSize = 16;
    }
  }

  private void UpdateEqInfoRow(GameObject item, int dataIdx, int panelObjectIdx)
  {
    Effect recordByKey = this.DM.EffectData.GetRecordByKey(this.effectList[dataIdx].EffectID);
    UIText component1 = item.transform.GetChild(1).GetComponent<UIText>();
    ((Graphic) component1).color = (Color) new Color32((byte) 233, (byte) 207, (byte) 167, byte.MaxValue);
    component1.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.InfoID);
    UIText component2 = item.transform.GetChild(2).GetComponent<UIText>();
    ((Graphic) component2).color = (Color) new Color32((byte) 233, (byte) 207, (byte) 167, byte.MaxValue);
    this.EffDescText[panelObjectIdx].ClearString();
    if (recordByKey.ValueID == (ushort) 0)
    {
      this.EffDescText[panelObjectIdx].IntToFormat((long) this.effectList[dataIdx].EffectValue);
      this.EffDescText[panelObjectIdx].AppendFormat("{0}");
    }
    else
    {
      this.EffDescText[panelObjectIdx].FloatToFormat((float) this.effectList[dataIdx].EffectValue / 100f, 2, false);
      if (!GUIManager.Instance.IsArabic)
        this.EffDescText[panelObjectIdx].AppendFormat("{0}%");
      else
        this.EffDescText[panelObjectIdx].AppendFormat("%{0}");
    }
    component2.text = this.EffDescText[panelObjectIdx].ToString();
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
    item.transform.GetChild(0).gameObject.SetActive(dataIdx % 2 == 1);
  }

  private void SetupMainFilter(UILordEquip.eItemFilterByKind filter)
  {
    this.ShowUnlockPanel = false;
    this.FilterKind = filter;
    this.lockEmptyForge = false;
    switch (filter)
    {
      case UILordEquip.eItemFilterByKind.AllEquip:
        if (this.DM.mLordEquip.LoadLordEquip())
          break;
        this.FilterItem.Clear();
        for (ushort index = 0; (int) index < (int) this.DM.RoleAttr.LordEquipBagSize; ++index)
        {
          if (this.DM.mLordEquip.LordEquip[(int) index].ItemID != (ushort) 0)
            this.FilterItem.Add(index);
        }
        LordEquipData.Instance().SetDictionary(false);
        this.FilterItem.Sort(new Comparison<ushort>(LordEquipData.ItemSort));
        bool flag = this.DM.RoleAttr.LordEquipEventData.ItemID != (ushort) 0 && this.DM.RoleAttr.LordEquipEventData.SerialNO == 0U;
        for (ushort index = 0; (int) index < (int) this.DM.RoleAttr.LordEquipBagSize; ++index)
        {
          if (this.DM.mLordEquip.LordEquip[(int) index].ItemID == (ushort) 0)
          {
            if (flag)
            {
              flag = false;
              this.lockEmptyForge = true;
              this.lockedIdx = (int) index;
            }
            this.FilterItem.Add(index);
          }
        }
        int num1 = this.FilterItem.Count / 4;
        if (this.FilterItem.Count % 4 != 0)
          ++num1;
        this.SPHeight.Clear();
        for (int index = 0; index < num1; ++index)
          this.SPHeight.Add(117f);
        if (this.DM.RoleAttr.LordEquipBagSize < (byte) 200 && this.OpenKind == eUI_LordEquipOpenKind.Collection)
        {
          this.SPHeight.Add(160f);
          this.ShowUnlockPanel = true;
        }
        if (this.SPHeight.Count >= 4 && (double) this.SPHeight[this.SPHeight.Count - 1] < 130.0)
        {
          this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
          this.SPHeight.Add(130f);
        }
        ((Component) this.Forging).gameObject.SetActive(false);
        this.AGS_ScrollArea.gameObject.SetActive(true);
        this.AGS_ScrollArea.AddNewDataHeight(this.SPHeight, 488f);
        this.AGS_ScrollArea.GoTo(UILordEquip.EquipTopIdx, UILordEquip.EquipTopPos);
        this.AGS_Form.GetChild(4).GetChild(0).gameObject.SetActive(false);
        break;
      case UILordEquip.eItemFilterByKind.Head:
      case UILordEquip.eItemFilterByKind.Body:
      case UILordEquip.eItemFilterByKind.Lag:
      case UILordEquip.eItemFilterByKind.Weapon:
      case UILordEquip.eItemFilterByKind.OffHand:
      case UILordEquip.eItemFilterByKind.Accessories:
        if (this.DM.mLordEquip.LoadLordEquip())
          break;
        this.FilterItem.Clear();
        for (ushort index = 0; (int) index < (int) this.DM.RoleAttr.LordEquipBagSize; ++index)
        {
          if ((int) this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int) index].ItemID).EquipKind == (int) (byte) filter + 20)
            this.FilterItem.Add(index);
        }
        LordEquipData.Instance().SetDictionary(true);
        this.FilterItem.Sort(new Comparison<ushort>(LordEquipData.ItemSort));
        int index1 = 0;
        if (this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt)
        {
          if (filter == UILordEquip.eItemFilterByKind.Accessories)
          {
            for (int index2 = 0; index2 < this.FilterItem.Count; ++index2)
            {
              if ((int) UILordEquipSetEdit.showingSet.SerialNO[(int) (byte) filter - 1] == (int) this.DM.mLordEquip.LordEquip[(int) this.FilterItem[index2]].SerialNO)
              {
                ushort num2 = this.FilterItem[index2];
                this.FilterItem.RemoveAt(index2);
                this.FilterItem.Insert(index1, num2);
                ++index1;
              }
            }
            for (int index3 = 0; index3 < this.FilterItem.Count; ++index3)
            {
              if ((int) UILordEquipSetEdit.showingSet.SerialNO[(int) (byte) filter] == (int) this.DM.mLordEquip.LordEquip[(int) this.FilterItem[index3]].SerialNO)
              {
                ushort num3 = this.FilterItem[index3];
                this.FilterItem.RemoveAt(index3);
                this.FilterItem.Insert(index1, num3);
                ++index1;
              }
            }
            for (int index4 = 0; index4 < this.FilterItem.Count; ++index4)
            {
              if ((int) UILordEquipSetEdit.showingSet.SerialNO[(int) (byte) filter + 1] == (int) this.DM.mLordEquip.LordEquip[(int) this.FilterItem[index4]].SerialNO)
              {
                ushort num4 = this.FilterItem[index4];
                this.FilterItem.RemoveAt(index4);
                this.FilterItem.Insert(index1, num4);
                ++index1;
              }
            }
          }
          else
          {
            for (int index5 = 0; index5 < this.FilterItem.Count; ++index5)
            {
              if ((int) UILordEquipSetEdit.showingSet.SerialNO[(int) (byte) filter - 1] == (int) this.DM.mLordEquip.LordEquip[(int) this.FilterItem[index5]].SerialNO)
              {
                ushort num5 = this.FilterItem[index5];
                this.FilterItem.RemoveAt(index5);
                this.FilterItem.Insert(index1, num5);
                ++index1;
              }
            }
          }
        }
        else if (filter == UILordEquip.eItemFilterByKind.Accessories)
        {
          for (int index6 = 0; index6 < this.FilterItem.Count; ++index6)
          {
            if ((int) LordEquipData.RoleEquipSerial[(int) (byte) filter - 1] == (int) this.DM.mLordEquip.LordEquip[(int) this.FilterItem[index6]].SerialNO)
            {
              ushort num6 = this.FilterItem[index6];
              this.FilterItem.RemoveAt(index6);
              this.FilterItem.Insert(index1, num6);
              ++index1;
            }
          }
          for (int index7 = 0; index7 < this.FilterItem.Count; ++index7)
          {
            if ((int) LordEquipData.RoleEquipSerial[(int) (byte) filter] == (int) this.DM.mLordEquip.LordEquip[(int) this.FilterItem[index7]].SerialNO)
            {
              ushort num7 = this.FilterItem[index7];
              this.FilterItem.RemoveAt(index7);
              this.FilterItem.Insert(index1, num7);
              ++index1;
            }
          }
          for (int index8 = 0; index8 < this.FilterItem.Count; ++index8)
          {
            if ((int) LordEquipData.RoleEquipSerial[(int) (byte) filter + 1] == (int) this.DM.mLordEquip.LordEquip[(int) this.FilterItem[index8]].SerialNO)
            {
              ushort num8 = this.FilterItem[index8];
              this.FilterItem.RemoveAt(index8);
              this.FilterItem.Insert(index1, num8);
              ++index1;
            }
          }
        }
        else
        {
          for (int index9 = 0; index9 < this.FilterItem.Count; ++index9)
          {
            if ((int) LordEquipData.RoleEquipSerial[(int) (byte) filter - 1] == (int) this.DM.mLordEquip.LordEquip[(int) this.FilterItem[index9]].SerialNO)
            {
              ushort num9 = this.FilterItem[index9];
              this.FilterItem.RemoveAt(index9);
              this.FilterItem.Insert(index1, num9);
              ++index1;
            }
          }
        }
        int num10 = this.FilterItem.Count / 4;
        if (this.FilterItem.Count % 4 != 0)
          ++num10;
        this.SPHeight.Clear();
        for (int index10 = 0; index10 < num10; ++index10)
          this.SPHeight.Add(117f);
        if (this.SPHeight.Count >= 4 && (double) this.SPHeight[this.SPHeight.Count - 1] < 130.0)
        {
          this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
          this.SPHeight.Add(130f);
        }
        this.AGS_Form.GetChild(4).GetChild(0).gameObject.SetActive(this.FilterItem.Count == 0);
        if (this.FilterItem.Count == 0)
        {
          UIText component = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
          this.NoContentText.ClearString();
          this.NoContentText.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (7430 + filter)));
          this.NoContentText.AppendFormat(this.DM.mStringTable.GetStringByID(7463U));
          component.text = this.NoContentText.ToString();
          component.SetAllDirty();
          component.cachedTextGenerator.Invalidate();
          this.AGS_Form.GetChild(5).gameObject.SetActive(false);
          this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(true);
          if ((UnityEngine.Object) this.Select != (UnityEngine.Object) null)
          {
            ((Component) this.Select).gameObject.SetActive(false);
            this.isFocused = false;
          }
        }
        else if (this.OnStartSelect && this.OpenKind == eUI_LordEquipOpenKind.SelectSolt)
        {
          for (int index11 = 0; index11 < this.FilterItem.Count; ++index11)
          {
            if ((int) LordEquipData.RoleEquipSerial[(int) this.EquipSolt - 1] == (int) this.DM.mLordEquip.LordEquip[(int) this.FilterItem[index11]].SerialNO)
            {
              UILordEquip.EquipFocus = this.FilterItem[index11];
              this.isFocused = true;
            }
          }
          if (!this.isFocused)
          {
            for (int index12 = 0; index12 < this.FilterItem.Count; ++index12)
            {
              if ((int) this.DM.RoleAttr.LordEquipEventData.SerialNO != (int) this.DM.mLordEquip.LordEquip[(int) this.FilterItem[index12]].SerialNO && !this.DM.mLordEquip.isRoleEquipThis(this.DM.mLordEquip.LordEquip[(int) this.FilterItem[index12]].SerialNO))
              {
                UILordEquip.EquipFocus = this.FilterItem[index12];
                this.isFocused = true;
                break;
              }
            }
          }
          this.OnStartSelect = false;
        }
        else if (this.OnStartSelect && this.OpenKind == eUI_LordEquipOpenKind.SelectSetSolt)
        {
          for (int index13 = 0; index13 < this.FilterItem.Count; ++index13)
          {
            if ((int) UILordEquipSetEdit.showingSet.SerialNO[UILordEquipSetEdit.ChangingIdx] == (int) this.DM.mLordEquip.LordEquip[(int) this.FilterItem[index13]].SerialNO)
            {
              UILordEquip.EquipFocus = this.FilterItem[index13];
              this.isFocused = true;
            }
          }
          if (!this.isFocused)
          {
            for (int index14 = 0; index14 < this.FilterItem.Count; ++index14)
            {
              if (!UILordEquipSetEdit.showingSet.isInSet(this.DM.mLordEquip.LordEquip[(int) this.FilterItem[index14]].SerialNO))
              {
                UILordEquip.EquipFocus = this.FilterItem[index14];
                this.isFocused = true;
                break;
              }
            }
          }
          this.OnStartSelect = false;
        }
        ((Component) this.Forging).gameObject.SetActive(false);
        this.AGS_ScrollArea.AddNewDataHeight(this.SPHeight, 488f);
        if (this.FilterItem.Count > 0)
        {
          this.AGS_Form.GetChild(5).gameObject.SetActive(true);
          this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
        }
        if (this.OpenKind != eUI_LordEquipOpenKind.SelectSolt && this.OpenKind != eUI_LordEquipOpenKind.SelectSetSolt)
          break;
        this.SetSideInfo();
        break;
      case UILordEquip.eItemFilterByKind.Gem:
        if (this.DM.mLordEquip.LoadLEGem())
          break;
        this.FilterItem.Clear();
        for (ushort index15 = 0; (int) index15 < this.DM.mLordEquip.LEGem.Length; ++index15)
        {
          if (this.DM.mLordEquip.LEGem[(int) index15].ItemID != (ushort) 0)
            this.FilterItem.Add(index15);
        }
        this.FilterItem.Sort(new Comparison<ushort>(LordEquipData.GemSort));
        int num11 = this.FilterItem.Count / 4;
        if (this.FilterItem.Count % 4 != 0)
          ++num11;
        this.SPHeight.Clear();
        for (int index16 = 0; index16 < num11; ++index16)
          this.SPHeight.Add(117f);
        if (this.SPHeight.Count >= 4 && (double) this.SPHeight[this.SPHeight.Count - 1] < 130.0)
        {
          this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
          this.SPHeight.Add(130f);
        }
        this.AGS_ScrollArea.AddNewDataHeight(this.SPHeight, 488f, this.isCollectChange);
        this.isCollectChange = false;
        this.AGS_ScrollArea.gameObject.SetActive(this.FilterItem.Count != 0);
        this.AGS_ScrollArea.GoTo(UILordEquip.GemTopIdx, UILordEquip.GemTopPos);
        this.AGS_Form.GetChild(4).GetChild(0).gameObject.SetActive(this.FilterItem.Count == 0);
        if (this.FilterItem.Count != 0)
          break;
        this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
        UIText component1 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
        this.NoContentText.ClearString();
        this.NoContentText.StringToFormat(this.DM.mStringTable.GetStringByID(7458U));
        this.NoContentText.AppendFormat(this.DM.mStringTable.GetStringByID(7463U));
        component1.text = this.NoContentText.ToString();
        component1.SetAllDirty();
        component1.cachedTextGenerator.Invalidate();
        break;
      case UILordEquip.eItemFilterByKind.Material:
        if (this.DM.mLordEquip.LoadLEMaterial())
          break;
        this.FilterItem.Clear();
        for (ushort index17 = 0; (int) index17 < this.DM.mLordEquip.LEMaterial.Length; ++index17)
        {
          if (this.DM.mLordEquip.LEMaterial[(int) index17].ItemID != (ushort) 0)
            this.FilterItem.Add(index17);
        }
        this.FilterItem.Sort(new Comparison<ushort>(LordEquipData.MatSort));
        int num12 = this.FilterItem.Count / 4;
        if (this.FilterItem.Count % 4 != 0)
          ++num12;
        this.SPHeight.Clear();
        for (int index18 = 0; index18 < num12; ++index18)
          this.SPHeight.Add(117f);
        if (this.SPHeight.Count >= 4 && (double) this.SPHeight[this.SPHeight.Count - 1] < 130.0)
        {
          this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
          this.SPHeight.Add(130f);
        }
        this.AGS_ScrollArea.AddNewDataHeight(this.SPHeight, 488f, this.isCollectChange);
        this.isCollectChange = false;
        this.AGS_ScrollArea.gameObject.SetActive(this.FilterItem.Count != 0);
        this.AGS_ScrollArea.GoTo(UILordEquip.MatTopIdx, UILordEquip.MatTopPos);
        this.AGS_Form.GetChild(4).GetChild(0).gameObject.SetActive(this.FilterItem.Count == 0);
        if (this.FilterItem.Count != 0)
          break;
        this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
        UIText component2 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
        this.NoContentText.ClearString();
        this.NoContentText.StringToFormat(this.DM.mStringTable.GetStringByID(7459U));
        this.NoContentText.AppendFormat(this.DM.mStringTable.GetStringByID(7463U));
        component2.text = this.NoContentText.ToString();
        component2.SetAllDirty();
        component2.cachedTextGenerator.Invalidate();
        break;
      case UILordEquip.eItemFilterByKind.GemFilter:
        if (UIEffectFilter.SeletedFilter == (ushort) 0)
        {
          this.SetupMainFilter(UILordEquip.eItemFilterByKind.Gem);
          break;
        }
        this.FilterItem.Clear();
        ushort effectId = this.DM.LordEquipEffectFilter.GetRecordByIndex((int) UIEffectFilter.SeletedFilter - 1).effectID;
        for (ushort index19 = 0; (int) index19 < this.DM.mLordEquip.LEGem.Length; ++index19)
        {
          if (this.DM.mLordEquip.LEGem[(int) index19].ItemID != (ushort) 0)
          {
            Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LEGem[(int) index19].ItemID);
            for (int index20 = 0; index20 < 6; ++index20)
            {
              if (recordByKey.PropertiesInfo[index20].Propertieskey != (ushort) 0 && (int) this.DM.LordEquipEffectTable.GetRecordByKey(recordByKey.PropertiesInfo[index20].Propertieskey).EffectID == (int) effectId)
              {
                this.FilterItem.Add(index19);
                break;
              }
            }
          }
        }
        this.FilterItem.Sort(new Comparison<ushort>(LordEquipData.GemSort));
        int num13 = this.FilterItem.Count / 4;
        if (this.FilterItem.Count % 4 != 0)
          ++num13;
        this.SPHeight.Clear();
        for (int index21 = 0; index21 < num13; ++index21)
          this.SPHeight.Add(117f);
        if (this.SPHeight.Count >= 4 && (double) this.SPHeight[this.SPHeight.Count - 1] < 130.0)
        {
          this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
          this.SPHeight.Add(130f);
        }
        this.AGS_ScrollArea.AddNewDataHeight(this.SPHeight, 488f);
        this.AGS_Form.GetChild(4).GetChild(0).gameObject.SetActive(this.FilterItem.Count == 0);
        if (this.FilterItem.Count != 0)
          break;
        this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).gameObject.SetActive(false);
        UIText component3 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
        this.NoContentText.ClearString();
        this.NoContentText.AppendFormat(this.DM.mStringTable.GetStringByID(7495U));
        component3.text = this.NoContentText.ToString();
        component3.SetAllDirty();
        component3.cachedTextGenerator.Invalidate();
        break;
      case UILordEquip.eItemFilterByKind.IDFilter:
        this.FilterItem.Clear();
        for (ushort index22 = 0; (int) index22 < (int) this.DM.RoleAttr.LordEquipBagSize; ++index22)
        {
          if ((int) this.DM.mLordEquip.LordEquip[(int) index22].ItemID == (int) UILordEquip.itemIDFilter && (int) this.DM.mLordEquip.LordEquip[(int) index22].Color == (int) UILordEquip.itemColorFilter)
            this.FilterItem.Add(index22);
        }
        if (!this.isFocused)
        {
          UILordEquip.EquipFocus = this.FilterItem[0];
          this.isFocused = true;
        }
        int num14 = this.FilterItem.Count / 4;
        if (this.FilterItem.Count % 4 != 0)
          ++num14;
        this.SPHeight.Clear();
        for (int index23 = 0; index23 < num14; ++index23)
          this.SPHeight.Add(117f);
        if (this.SPHeight.Count >= 4 && (double) this.SPHeight[this.SPHeight.Count - 1] < 130.0)
        {
          this.SPHeight.RemoveAt(this.SPHeight.Count - 1);
          this.SPHeight.Add(130f);
        }
        ((Component) this.Forging).gameObject.SetActive(false);
        this.AGS_ScrollArea.AddNewDataHeight(this.SPHeight, 488f);
        this.AGS_Form.GetChild(4).GetChild(0).gameObject.SetActive(this.FilterItem.Count == 0);
        if (this.FilterItem.Count == 0)
        {
          UIText component4 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
          this.NoContentText.ClearString();
          this.NoContentText.StringToFormat(this.DM.mStringTable.GetStringByID(7458U));
          this.NoContentText.AppendFormat(this.DM.mStringTable.GetStringByID(7463U));
          component4.text = this.NoContentText.ToString();
          component4.SetAllDirty();
          component4.cachedTextGenerator.Invalidate();
        }
        this.SetSideInfo();
        break;
    }
  }

  private void GetMaterialRareCount(bool material, ushort itemID)
  {
    for (int index = 0; index < this.MaterCount.Length; ++index)
      this.MaterCount[index] = (ushort) 0;
    if (material)
    {
      for (int index = 0; index < this.DM.mLordEquip.LEMaterial.Length; ++index)
      {
        if ((int) this.DM.mLordEquip.LEMaterial[index].ItemID == (int) itemID)
          this.MaterCount[(int) this.DM.mLordEquip.LEMaterial[index].Color - 1] = this.DM.mLordEquip.LEMaterial[index].Quantity;
      }
    }
    else
    {
      for (int index = 0; index < this.DM.mLordEquip.LEGem.Length; ++index)
      {
        if ((int) this.DM.mLordEquip.LEGem[index].ItemID == (int) itemID)
          this.MaterCount[(int) this.DM.mLordEquip.LEGem[index].Color - 1] = this.DM.mLordEquip.LEGem[index].Quantity;
      }
    }
  }

  private bool isAbleDecompose(int selectItem, bool PopMessage = true)
  {
    if (this.DM.mLordEquip.isRoleEquipThis(this.DM.mLordEquip.LordEquip[selectItem].SerialNO))
    {
      GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(7490U), DataManager.Instance.mStringTable.GetStringByID(7511U));
      return false;
    }
    Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[selectItem].ItemID);
    bool flag = false;
    for (int index = 0; index < 4; ++index)
    {
      ushort syntheticItem = recordByKey.SyntheticParts[index].SyntheticItem;
      if (syntheticItem > (ushort) 0)
        flag = true;
      if ((int) LordEquipData.getItemQuantity(syntheticItem, this.DM.mLordEquip.LordEquip[selectItem].Color) + (int) recordByKey.SyntheticParts[index].SyntheticItemNum > (int) ushort.MaxValue)
      {
        GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(7490U), DataManager.Instance.mStringTable.GetStringByID(7509U));
        return false;
      }
    }
    if (flag)
      return true;
    if (PopMessage)
      GUIManager.Instance.OpenMessageBox(DataManager.Instance.mStringTable.GetStringByID(7490U), DataManager.Instance.mStringTable.GetStringByID(9575U));
    return false;
  }

  private bool isAbleToImbueGame(int selectItem, ushort GemID, byte solt)
  {
    for (int index = 0; index < 4; ++index)
    {
      if (index != (int) solt && (int) this.DM.mLordEquip.LordEquip[selectItem].Gem[index] == (int) GemID)
      {
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7512U), (ushort) byte.MaxValue);
        return false;
      }
    }
    return true;
  }

  private bool EquipOrTakeDown()
  {
    if (this.DM.beCaptured.nowCaptureStat != LoadCaptureState.None)
    {
      GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(9696U), (ushort) byte.MaxValue);
      return false;
    }
    for (int equipPos = 0; equipPos < LordEquipData.RoleEquipSerial.Length; ++equipPos)
    {
      if ((int) LordEquipData.RoleEquipSerial[equipPos] == (int) this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO)
      {
        this.DM.mLordEquip.ChangeEquip((byte) equipPos, 0U);
        return true;
      }
    }
    if ((int) this.DM.EquipTable.GetRecordByKey(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ItemID).NeedLv > (int) this.DM.RoleAttr.Level)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(7504U), (ushort) byte.MaxValue);
      return false;
    }
    int equipPos1 = this.DM.mLordEquip.GetEquipPos(this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ItemID);
    if (equipPos1 < 0)
      return false;
    if (equipPos1 < 5)
    {
      this.DM.mLordEquip.ChangeEquip((byte) equipPos1, this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO);
      return true;
    }
    if (LordEquipData.RoleEquipSerial[5] == 0U)
    {
      this.DM.mLordEquip.ChangeEquip((byte) equipPos1, this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO);
      return true;
    }
    RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData((ushort) 15, (ushort) 0);
    if (buildData.Level >= (byte) 17 && LordEquipData.RoleEquipSerial[6] == 0U)
    {
      this.DM.mLordEquip.ChangeEquip((byte) 6, this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO);
      return true;
    }
    if (buildData.Level >= (byte) 25 && LordEquipData.RoleEquipSerial[7] == 0U)
    {
      this.DM.mLordEquip.ChangeEquip((byte) 7, this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO);
      return true;
    }
    this.DM.mLordEquip.ChangeEquip((byte) equipPos1, this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].SerialNO);
    return true;
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UIText component3 = this.AGS_Form.GetChild(4).GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component3 != (UnityEngine.Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UIText component4 = this.AGS_Form.GetChild(6).GetChild(1).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component4 != (UnityEngine.Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    UIText component5 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component5 != (UnityEngine.Object) null && ((Behaviour) component5).enabled)
    {
      ((Behaviour) component5).enabled = false;
      ((Behaviour) component5).enabled = true;
    }
    UIText component6 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component6 != (UnityEngine.Object) null && ((Behaviour) component6).enabled)
    {
      ((Behaviour) component6).enabled = false;
      ((Behaviour) component6).enabled = true;
    }
    UIText component7 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component7 != (UnityEngine.Object) null && ((Behaviour) component7).enabled)
    {
      ((Behaviour) component7).enabled = false;
      ((Behaviour) component7).enabled = true;
    }
    UIText component8 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(4).GetComponent<UIText>();
    if ((UnityEngine.Object) component8 != (UnityEngine.Object) null && ((Behaviour) component8).enabled)
    {
      ((Behaviour) component8).enabled = false;
      ((Behaviour) component8).enabled = true;
    }
    UIText component9 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component9 != (UnityEngine.Object) null && ((Behaviour) component9).enabled)
    {
      ((Behaviour) component9).enabled = false;
      ((Behaviour) component9).enabled = true;
    }
    UIText component10 = this.AGS_Form.GetChild(8).GetChild(0).GetChild(5).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component10 != (UnityEngine.Object) null && ((Behaviour) component10).enabled)
    {
      ((Behaviour) component10).enabled = false;
      ((Behaviour) component10).enabled = true;
    }
    UIText component11 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component11 != (UnityEngine.Object) null && ((Behaviour) component11).enabled)
    {
      ((Behaviour) component11).enabled = false;
      ((Behaviour) component11).enabled = true;
    }
    UIText component12 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component12 != (UnityEngine.Object) null && ((Behaviour) component12).enabled)
    {
      ((Behaviour) component12).enabled = false;
      ((Behaviour) component12).enabled = true;
    }
    UIText component13 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).GetComponent<UIText>();
    if ((UnityEngine.Object) component13 != (UnityEngine.Object) null && ((Behaviour) component13).enabled)
    {
      ((Behaviour) component13).enabled = false;
      ((Behaviour) component13).enabled = true;
    }
    UIText component14 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(9).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component14 != (UnityEngine.Object) null && ((Behaviour) component14).enabled)
    {
      ((Behaviour) component14).enabled = false;
      ((Behaviour) component14).enabled = true;
    }
    UIText component15 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(10).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component15 != (UnityEngine.Object) null && ((Behaviour) component15).enabled)
    {
      ((Behaviour) component15).enabled = false;
      ((Behaviour) component15).enabled = true;
    }
    UIText component16 = this.AGS_Form.GetChild(8).GetChild(1).GetChild(11).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component16 != (UnityEngine.Object) null && ((Behaviour) component16).enabled)
    {
      ((Behaviour) component16).enabled = false;
      ((Behaviour) component16).enabled = true;
    }
    UIText component17 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component17 != (UnityEngine.Object) null && ((Behaviour) component17).enabled)
    {
      ((Behaviour) component17).enabled = false;
      ((Behaviour) component17).enabled = true;
    }
    UIText component18 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component18 != (UnityEngine.Object) null && ((Behaviour) component18).enabled)
    {
      ((Behaviour) component18).enabled = false;
      ((Behaviour) component18).enabled = true;
    }
    UIText component19 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(4).GetComponent<UIText>();
    if ((UnityEngine.Object) component19 != (UnityEngine.Object) null && ((Behaviour) component19).enabled)
    {
      ((Behaviour) component19).enabled = false;
      ((Behaviour) component19).enabled = true;
    }
    UIText component20 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(5).GetComponent<UIText>();
    if ((UnityEngine.Object) component20 != (UnityEngine.Object) null && ((Behaviour) component20).enabled)
    {
      ((Behaviour) component20).enabled = false;
      ((Behaviour) component20).enabled = true;
    }
    UIText component21 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(6).GetComponent<UIText>();
    if ((UnityEngine.Object) component21 != (UnityEngine.Object) null && ((Behaviour) component21).enabled)
    {
      ((Behaviour) component21).enabled = false;
      ((Behaviour) component21).enabled = true;
    }
    UIText component22 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(7).GetComponent<UIText>();
    if ((UnityEngine.Object) component22 != (UnityEngine.Object) null && ((Behaviour) component22).enabled)
    {
      ((Behaviour) component22).enabled = false;
      ((Behaviour) component22).enabled = true;
    }
    UIText component23 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(8).GetComponent<UIText>();
    if ((UnityEngine.Object) component23 != (UnityEngine.Object) null && ((Behaviour) component23).enabled)
    {
      ((Behaviour) component23).enabled = false;
      ((Behaviour) component23).enabled = true;
    }
    UIText component24 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(10).GetComponent<UIText>();
    if ((UnityEngine.Object) component24 != (UnityEngine.Object) null && ((Behaviour) component24).enabled)
    {
      ((Behaviour) component24).enabled = false;
      ((Behaviour) component24).enabled = true;
    }
    UIText component25 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(11).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component25 != (UnityEngine.Object) null && ((Behaviour) component25).enabled)
    {
      ((Behaviour) component25).enabled = false;
      ((Behaviour) component25).enabled = true;
    }
    UIText component26 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(11).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component26 != (UnityEngine.Object) null && ((Behaviour) component26).enabled)
    {
      ((Behaviour) component26).enabled = false;
      ((Behaviour) component26).enabled = true;
    }
    UIText component27 = this.AGS_Form.GetChild(8).GetChild(2).GetChild(12).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component27 != (UnityEngine.Object) null && ((Behaviour) component27).enabled)
    {
      ((Behaviour) component27).enabled = false;
      ((Behaviour) component27).enabled = true;
    }
    UIText component28 = this.AGS_Form.GetChild(9).GetChild(2).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component28 != (UnityEngine.Object) null && ((Behaviour) component28).enabled)
    {
      ((Behaviour) component28).enabled = false;
      ((Behaviour) component28).enabled = true;
    }
    UIText component29 = this.AGS_Form.GetChild(9).GetChild(4).GetComponent<UIText>();
    if ((UnityEngine.Object) component29 != (UnityEngine.Object) null && ((Behaviour) component29).enabled)
    {
      ((Behaviour) component29).enabled = false;
      ((Behaviour) component29).enabled = true;
    }
    UIText component30 = this.AGS_Form.GetChild(9).GetChild(6).GetComponent<UIText>();
    if ((UnityEngine.Object) component30 != (UnityEngine.Object) null && ((Behaviour) component30).enabled)
    {
      ((Behaviour) component30).enabled = false;
      ((Behaviour) component30).enabled = true;
    }
    UIText component31 = this.AGS_Form.GetChild(9).GetChild(7).GetChild(0).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component31 != (UnityEngine.Object) null && ((Behaviour) component31).enabled)
    {
      ((Behaviour) component31).enabled = false;
      ((Behaviour) component31).enabled = true;
    }
    UIText component32 = this.AGS_Form.GetChild(9).GetChild(8).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component32 != (UnityEngine.Object) null && ((Behaviour) component32).enabled)
    {
      ((Behaviour) component32).enabled = false;
      ((Behaviour) component32).enabled = true;
    }
    UIText component33 = this.AGS_Form.GetChild(9).GetChild(9).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component33 != (UnityEngine.Object) null && ((Behaviour) component33).enabled)
    {
      ((Behaviour) component33).enabled = false;
      ((Behaviour) component33).enabled = true;
    }
    UIText component34 = this.AGS_Form.GetChild(9).GetChild(11).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component34 != (UnityEngine.Object) null && ((Behaviour) component34).enabled)
    {
      ((Behaviour) component34).enabled = false;
      ((Behaviour) component34).enabled = true;
    }
    UIText component35 = this.AGS_Form.GetChild(9).GetChild(11).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component35 != (UnityEngine.Object) null && ((Behaviour) component35).enabled)
    {
      ((Behaviour) component35).enabled = false;
      ((Behaviour) component35).enabled = true;
    }
    UIText component36 = this.AGS_Form.GetChild(9).GetChild(12).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component36 != (UnityEngine.Object) null && ((Behaviour) component36).enabled)
    {
      ((Behaviour) component36).enabled = false;
      ((Behaviour) component36).enabled = true;
    }
    UIText component37 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component37 != (UnityEngine.Object) null && ((Behaviour) component37).enabled)
    {
      ((Behaviour) component37).enabled = false;
      ((Behaviour) component37).enabled = true;
    }
    UIText component38 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(4).GetComponent<UIText>();
    if ((UnityEngine.Object) component38 != (UnityEngine.Object) null && ((Behaviour) component38).enabled)
    {
      ((Behaviour) component38).enabled = false;
      ((Behaviour) component38).enabled = true;
    }
    UIText component39 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(8).GetComponent<UIText>();
    if ((UnityEngine.Object) component39 != (UnityEngine.Object) null && ((Behaviour) component39).enabled)
    {
      ((Behaviour) component39).enabled = false;
      ((Behaviour) component39).enabled = true;
    }
    UIText component40 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(9).GetComponent<UIText>();
    if ((UnityEngine.Object) component40 != (UnityEngine.Object) null && ((Behaviour) component40).enabled)
    {
      ((Behaviour) component40).enabled = false;
      ((Behaviour) component40).enabled = true;
    }
    UIText component41 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(10).GetComponent<UIText>();
    if ((UnityEngine.Object) component41 != (UnityEngine.Object) null && ((Behaviour) component41).enabled)
    {
      ((Behaviour) component41).enabled = false;
      ((Behaviour) component41).enabled = true;
    }
    UIText component42 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(11).GetComponent<UIText>();
    if ((UnityEngine.Object) component42 != (UnityEngine.Object) null && ((Behaviour) component42).enabled)
    {
      ((Behaviour) component42).enabled = false;
      ((Behaviour) component42).enabled = true;
    }
    UIText component43 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(12).GetComponent<UIText>();
    if ((UnityEngine.Object) component43 != (UnityEngine.Object) null && ((Behaviour) component43).enabled)
    {
      ((Behaviour) component43).enabled = false;
      ((Behaviour) component43).enabled = true;
    }
    UIText component44 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(13).GetComponent<UIText>();
    if ((UnityEngine.Object) component44 != (UnityEngine.Object) null && ((Behaviour) component44).enabled)
    {
      ((Behaviour) component44).enabled = false;
      ((Behaviour) component44).enabled = true;
    }
    UIText component45 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(14).GetComponent<UIText>();
    if ((UnityEngine.Object) component45 != (UnityEngine.Object) null && ((Behaviour) component45).enabled)
    {
      ((Behaviour) component45).enabled = false;
      ((Behaviour) component45).enabled = true;
    }
    UIText component46 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(15).GetComponent<UIText>();
    if ((UnityEngine.Object) component46 != (UnityEngine.Object) null && ((Behaviour) component46).enabled)
    {
      ((Behaviour) component46).enabled = false;
      ((Behaviour) component46).enabled = true;
    }
    UIText component47 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(16).GetComponent<UIText>();
    if ((UnityEngine.Object) component47 != (UnityEngine.Object) null && ((Behaviour) component47).enabled)
    {
      ((Behaviour) component47).enabled = false;
      ((Behaviour) component47).enabled = true;
    }
    UIText component48 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(17).GetComponent<UIText>();
    if ((UnityEngine.Object) component48 != (UnityEngine.Object) null && ((Behaviour) component48).enabled)
    {
      ((Behaviour) component48).enabled = false;
      ((Behaviour) component48).enabled = true;
    }
    UIText component49 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(18).GetComponent<UIText>();
    if ((UnityEngine.Object) component49 != (UnityEngine.Object) null && ((Behaviour) component49).enabled)
    {
      ((Behaviour) component49).enabled = false;
      ((Behaviour) component49).enabled = true;
    }
    UIText component50 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(19).GetComponent<UIText>();
    if ((UnityEngine.Object) component50 != (UnityEngine.Object) null && ((Behaviour) component50).enabled)
    {
      ((Behaviour) component50).enabled = false;
      ((Behaviour) component50).enabled = true;
    }
    UIText component51 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component51 != (UnityEngine.Object) null && ((Behaviour) component51).enabled)
    {
      ((Behaviour) component51).enabled = false;
      ((Behaviour) component51).enabled = true;
    }
    UIText component52 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(2).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component52 != (UnityEngine.Object) null && ((Behaviour) component52).enabled)
    {
      ((Behaviour) component52).enabled = false;
      ((Behaviour) component52).enabled = true;
    }
    UIText component53 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(3).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component53 != (UnityEngine.Object) null && ((Behaviour) component53).enabled)
    {
      ((Behaviour) component53).enabled = false;
      ((Behaviour) component53).enabled = true;
    }
    UIText component54 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(4).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component54 != (UnityEngine.Object) null && ((Behaviour) component54).enabled)
    {
      ((Behaviour) component54).enabled = false;
      ((Behaviour) component54).enabled = true;
    }
    UIText component55 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(5).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component55 != (UnityEngine.Object) null && ((Behaviour) component55).enabled)
    {
      ((Behaviour) component55).enabled = false;
      ((Behaviour) component55).enabled = true;
    }
    UIText component56 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(20).GetChild(6).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component56 != (UnityEngine.Object) null && ((Behaviour) component56).enabled)
    {
      ((Behaviour) component56).enabled = false;
      ((Behaviour) component56).enabled = true;
    }
    UIText component57 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(21).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component57 != (UnityEngine.Object) null && ((Behaviour) component57).enabled)
    {
      ((Behaviour) component57).enabled = false;
      ((Behaviour) component57).enabled = true;
    }
    UIText component58 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(22).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component58 != (UnityEngine.Object) null && ((Behaviour) component58).enabled)
    {
      ((Behaviour) component58).enabled = false;
      ((Behaviour) component58).enabled = true;
    }
    UIText component59 = this.AGS_Form.GetChild(10).GetChild(0).GetChild(23).GetComponent<UIText>();
    if ((UnityEngine.Object) component59 != (UnityEngine.Object) null && ((Behaviour) component59).enabled)
    {
      ((Behaviour) component59).enabled = false;
      ((Behaviour) component59).enabled = true;
    }
    if ((UnityEngine.Object) this.AGS_ScrollArea != (UnityEngine.Object) null && this.AGS_ScrollArea.gameObject.activeInHierarchy && this.AGS_ScrollArea.transform.childCount > 1)
    {
      Transform child1 = this.AGS_ScrollArea.transform.GetChild(0);
      for (int index1 = 0; index1 < child1.childCount && index1 < 6; ++index1)
      {
        Transform child2 = child1.GetChild(index1);
        if (child2.gameObject.activeInHierarchy)
        {
          if (child2.GetChild(0).gameObject.activeInHierarchy)
          {
            for (int index2 = 0; index2 < 4; ++index2)
              LordEquipData.ResetLordEquipFont(child2.GetChild(0).GetChild(index2));
          }
          if (child2.GetChild(1).gameObject.activeInHierarchy)
          {
            UIText component60 = child2.GetChild(1).GetChild(2).GetComponent<UIText>();
            if ((UnityEngine.Object) component60 != (UnityEngine.Object) null && ((Behaviour) component60).enabled)
            {
              ((Behaviour) component60).enabled = false;
              ((Behaviour) component60).enabled = true;
            }
          }
        }
      }
    }
    if ((UnityEngine.Object) this.AGS_ScrollPanel != (UnityEngine.Object) null && this.AGS_ScrollPanel.gameObject.activeInHierarchy && this.AGS_ScrollPanel.transform.childCount > 1)
    {
      Transform child3 = this.AGS_ScrollPanel.transform.GetChild(0);
      for (int index = 0; index < child3.childCount; ++index)
      {
        Transform child4 = child3.GetChild(index);
        if (child4.gameObject.activeInHierarchy)
        {
          if (child4.GetChild(0).gameObject.activeInHierarchy)
          {
            UIText component61 = child4.GetChild(0).GetComponent<UIText>();
            if ((UnityEngine.Object) component61 != (UnityEngine.Object) null && ((Behaviour) component61).enabled)
            {
              ((Behaviour) component61).enabled = false;
              ((Behaviour) component61).enabled = true;
            }
          }
          if (child4.GetChild(1).gameObject.activeInHierarchy)
          {
            UIText component62 = child4.GetChild(1).GetComponent<UIText>();
            if ((UnityEngine.Object) component62 != (UnityEngine.Object) null && ((Behaviour) component62).enabled)
            {
              ((Behaviour) component62).enabled = false;
              ((Behaviour) component62).enabled = true;
            }
          }
        }
      }
    }
    if (!((UnityEngine.Object) this.AGS_ScrollPanel2 != (UnityEngine.Object) null) || !this.AGS_ScrollPanel2.gameObject.activeInHierarchy || this.AGS_ScrollPanel2.transform.childCount <= 1)
      return;
    Transform child5 = this.AGS_ScrollPanel2.transform.GetChild(0);
    for (int index = 0; index < child5.childCount; ++index)
    {
      Transform child6 = child5.GetChild(index);
      if (child6.gameObject.activeInHierarchy)
      {
        if (child6.GetChild(1).gameObject.activeInHierarchy)
        {
          UIText component63 = child6.GetChild(1).GetComponent<UIText>();
          if ((UnityEngine.Object) component63 != (UnityEngine.Object) null && ((Behaviour) component63).enabled)
          {
            ((Behaviour) component63).enabled = false;
            ((Behaviour) component63).enabled = true;
          }
        }
        if (child6.GetChild(2).gameObject.activeInHierarchy)
        {
          UIText component64 = child6.GetChild(2).GetComponent<UIText>();
          if ((UnityEngine.Object) component64 != (UnityEngine.Object) null && ((Behaviour) component64).enabled)
          {
            ((Behaviour) component64).enabled = false;
            ((Behaviour) component64).enabled = true;
          }
        }
      }
    }
  }

  public void Update()
  {
    switch (this.OpenStat)
    {
      case UILordEquip.eUIOpenStat.None:
      case UILordEquip.eUIOpenStat.PostSetStat:
        this.AfterLoader();
        break;
      default:
        this.GetPointTime += Time.smoothDeltaTime / 2f;
        if ((double) this.GetPointTime >= 1.7000000476837158)
          this.GetPointTime = 0.3f;
        Color color = new Color(1f, 1f, 1f, (double) this.GetPointTime <= 1.0 ? this.GetPointTime : 2f - this.GetPointTime);
        ((Graphic) this.Light1).color = color;
        ((Graphic) this.Light2).color = color;
        ((Graphic) this.Light3).color = color;
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
        if (this.MaterialFlash)
        {
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
          if ((double) this.MoveTime >= 0.40000000596046448)
          {
            this.MoveTime = 0.0f;
            this.MaterialFlash = false;
          }
        }
        if (!this.AGS_Forging.gameObject.activeInHierarchy)
          break;
        this.AnimeTime += Time.smoothDeltaTime;
        if ((double) this.AnimeTime < 0.30000001192092896)
        {
          this.AGS_Forging.SetSpriteIndex(0);
          break;
        }
        if ((double) this.AnimeTime < 0.40000000596046448)
        {
          this.AGS_Forging.SetSpriteIndex(1);
          break;
        }
        if ((double) this.AnimeTime < 0.800000011920929)
        {
          this.AGS_Forging.SetSpriteIndex(2);
          break;
        }
        this.AnimeTime = 0.0f;
        break;
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (!bOnSecond || !this.selectedTimed)
      return;
    this.TimedItemCountText.ClearString();
    GameConstants.GetTimeString(this.TimedItemCountText, (uint) Math.Max(0L, this.DM.mLordEquip.LordEquip[(int) UILordEquip.EquipFocus].ExpireTime - this.DM.ServerTime));
    UIText component = this.AGS_Form.GetChild(8).GetChild(1).GetChild(5).GetComponent<UIText>();
    component.text = this.TimedItemCountText.ToString();
    component.cachedTextGenerator.Invalidate();
    component.SetAllDirty();
  }

  private enum eUIOpenStat
  {
    None,
    Normal,
    ItemInfo,
    GemSelect,
    GemInfo,
    GemCombine,
    MaterialCombine,
    PostSetStat,
  }

  private enum eItemFilterByKind
  {
    AllEquip,
    Head,
    Body,
    Lag,
    Weapon,
    OffHand,
    Accessories,
    Gem,
    Material,
    GemFilter,
    IDFilter,
  }

  private enum eCollectType
  {
    None,
    Equip,
    Gem,
    Material,
  }

  private enum e_AGS_UI_LordEquip_Editor
  {
    BGFrame,
    BGFrameTitle,
    exitImage,
    Infobtn,
    ScrollBg,
    ScrollArea,
    ScrollItem,
    Select,
    SideBg,
    GemDetail,
    Cover,
    Forging,
  }

  private enum e_AGS_ScrollItem
  {
    BlockHold,
    lockedHolder,
  }

  private enum e_AGS_lockedHolder
  {
    LockBtn,
    Lock,
    LockText,
  }

  private enum e_AGS_SideBg
  {
    Collection,
    Exchange,
    GemMosaic,
    VDivider,
  }

  private enum e_AGS_Collection
  {
    EquipmentBtn,
    GemBtn,
    MaterialBtn,
    FilterBg,
    FilterText,
    FilterBtn,
    Acquire,
  }

  private enum e_AGS_Acquire
  {
    AcquireImage,
  }

  private enum e_AGS_Exchange
  {
    NameBg,
    NameText,
    RareImg,
    LevelText,
    ClockImg,
    ClockText,
    ScrollPanelBg,
    ScrollPanel,
    ScrollItem,
    InspectBtn,
    EquipBtn,
    EvoBtn,
  }

  private enum e_AGS_ScrollItem2
  {
    Text,
    Text2,
  }

  private enum e_AGS_InspectBtn
  {
    Image,
    Text,
    Mark,
  }

  private enum e_AGS_EquipBtn
  {
    Image,
    Text,
  }

  private enum e_AGS_GemMosaic
  {
    ItemBg,
    ItemName,
    EffBg,
    EffText1,
    EffText2,
    EffText3,
    EffText4,
    EffText5,
    EffText6,
    FilterBg,
    FilterText,
    FilterBtn,
    EquipBtn,
  }

  private enum e_AGS_FilterBtn
  {
    FilterBtnText,
    FilterBtn2,
    FilterExtText,
  }

  private enum e_AGS_GemDetail
  {
    UpperBg,
    UILEBtn,
    SourceBtn,
    ItemBg,
    ItemName,
    ItemRare,
    LevelText,
    Gems,
    EvoBtn,
    RecycleBtn,
    ScrollPanel2,
    ScrollPanelItem,
    FullLevel,
    Image,
  }

  private enum e_AGS_GemHolder
  {
    Gem1,
    lockImg,
    UIButton,
    BtnText,
  }

  private enum e_AGS_EvoBtn
  {
    Image,
    Text,
    Mark,
  }

  private enum e_AGS_RecycleBtn
  {
    Text,
    Image,
  }

  private enum e_AGS_ScrollPanelItem
  {
    Image,
    EffName,
    EffText,
  }

  private enum e_AGS_FullLevel
  {
    Light,
    Star,
    Text,
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
    Image,
    EffText1,
    EffText2,
    EffText3,
    EffText4,
    EffText5,
    EffText6,
    EffVal1,
    EffVal2,
    EffVal3,
    EffVal4,
    EffVal5,
    EffVal6,
    Upgrade,
    CombineAll,
    CombineBtn,
    TextArea,
    ImageDiv,
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
