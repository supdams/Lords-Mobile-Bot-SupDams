// Decompiled with JetBrains decompiler
// Type: UILordInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UILordInfo : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUILEBtnClickHandler
{
  private const int TitleSPKind = 10000;
  private const int WTitleSPKind = 10001;
  private const int FTitleSPKind = 10002;
  private Transform AGS_Form;
  private UISpritesArray AGS_bgPanel;
  private UISpritesArray AGS_btn_BuffInfo;
  private UISpritesArray AGS_HeadBGImage;
  private UISpritesArray AGS_GuildRank;
  private UISpritesArray AGS_GuildLogo;
  private UISpritesArray AGS_HeroBadge;
  private global::ScrollPanel AGS_ScrollPanel;
  private Transform Hero_Pos;
  private RectTransform Hero_PosRT;
  private RectTransform LightRT;
  private RectTransform[] UILEBtn;
  private Image HeroRank;
  private RectTransform headInfoPanel;
  private RectTransform SideBtnPanel;
  private RectTransform ItemPanel;
  private RectTransform TitlePanel;
  private RectTransform ScrollPanel;
  private RectTransform PopupPanel;
  private RectTransform HintPanel;
  private RectTransform JailerPanel;
  private RectTransform RescurePanel;
  private RectTransform CaptureBar;
  private UIBtnDrag HeroRotater;
  public RectTransform CoordBtnRT;
  private int AssetKey1;
  private int AssetKey2;
  private AssetBundle bundle;
  private AssetBundleRequest bundleRequest;
  private GameObject Holder1;
  private GameObject Holder2;
  private UILordInfo.eModelLoadingStep LoadingStep;
  private CString Header_NameText;
  private Door door;
  private DataManager DM;
  private EUILordInfoLayout OpenKind;
  private Hero sHero;
  private bool popUp;
  private bool scrollPanelInit;
  private List<float> SPHeights;
  private CString[] tmpLordString = new CString[18];
  private CString[] tmpString = new CString[18];
  private CString[] JailerStr = new CString[4];
  private CString hintString;
  private CString countDown;
  private CString PopStr;
  private CString EnStr;
  private CString TitleSPItemText;
  private CString TitleSPItemText2;
  private CString TitleSPItemText3;
  private List<eSPDisplayType> Barkind;
  private List<int> EnhanceShowedIdx;
  private bool isSameAlli;
  private int lastUpdateIdx = -1;
  private Image BarLight;
  private float GetPointTime;
  private float NextActionTime;
  private bool isMonsterOpen;
  private long MonsterTime = -1;
  private Image[] LEquipLight = new Image[8];
  private EUILordInfoLayout HasBeenPage;
  private bool StatDataReady;
  private bool freeRes;
  private bool executeUpdated;
  private bool poisonUpdated;
  public static bool OpenTransport = false;
  private RectTransform TitleSPItem;
  private RectTransform TitleSPItem2;
  private RectTransform TitleSPItem3;
  private int TitleSPItemIdx;
  private int TitleSPItemIdx2;
  private int TitleSPItemIdx3;
  private static readonly uint[,] RecordFields = new uint[48, 3]
  {
    {
      7301U,
      0U,
      0U
    },
    {
      7305U,
      1U,
      1U
    },
    {
      7306U,
      2U,
      2U
    },
    {
      7307U,
      1U,
      3U
    },
    {
      7308U,
      2U,
      4U
    },
    {
      7309U,
      1U,
      5U
    },
    {
      7310U,
      2U,
      6U
    },
    {
      7311U,
      1U,
      7U
    },
    {
      7312U,
      2U,
      8U
    },
    {
      7313U,
      1U,
      9U
    },
    {
      7314U,
      2U,
      10U
    },
    {
      7315U,
      1U,
      11U
    },
    {
      7316U,
      2U,
      12U
    },
    {
      7317U,
      1U,
      13U
    },
    {
      7318U,
      2U,
      14U
    },
    {
      7319U,
      1U,
      15U
    },
    {
      7320U,
      2U,
      16U
    },
    {
      11176U,
      1U,
      46U
    },
    {
      11177U,
      1U,
      47U
    },
    {
      7302U,
      0U,
      17U
    },
    {
      7321U,
      1U,
      18U
    },
    {
      7322U,
      2U,
      19U
    },
    {
      7323U,
      1U,
      20U
    },
    {
      7324U,
      2U,
      21U
    },
    {
      7325U,
      1U,
      22U
    },
    {
      7326U,
      2U,
      23U
    },
    {
      9371U,
      1U,
      44U
    },
    {
      11178U,
      1U,
      45U
    },
    {
      7303U,
      0U,
      24U
    },
    {
      7327U,
      1U,
      25U
    },
    {
      7328U,
      2U,
      26U
    },
    {
      7329U,
      1U,
      27U
    },
    {
      7330U,
      2U,
      28U
    },
    {
      7331U,
      1U,
      29U
    },
    {
      7332U,
      2U,
      30U
    },
    {
      7333U,
      1U,
      31U
    },
    {
      9125U,
      0U,
      40U
    },
    {
      9160U,
      1U,
      41U
    },
    {
      9159U,
      2U,
      42U
    },
    {
      9161U,
      1U,
      43U
    },
    {
      7304U,
      0U,
      32U
    },
    {
      7334U,
      1U,
      33U
    },
    {
      7336U,
      2U,
      34U
    },
    {
      7335U,
      1U,
      35U
    },
    {
      7337U,
      2U,
      36U
    },
    {
      7338U,
      1U,
      37U
    },
    {
      7340U,
      2U,
      38U
    },
    {
      7341U,
      1U,
      39U
    }
  };
  private UIButtonHint lastHint;
  private bool DefaultActionLateUpdate;

  public override void OnOpen(int arg1, int arg2)
  {
    this.OpenKind = (EUILordInfoLayout) arg1;
    GUIManager instance = GUIManager.Instance;
    this.DM = DataManager.Instance;
    this.door = instance.FindMenu(EGUIWindow.Door) as Door;
    for (int index = 0; index < this.tmpString.Length; ++index)
      this.tmpString[index] = StringManager.Instance.SpawnString(50);
    for (int index = 0; index < this.tmpLordString.Length; ++index)
      this.tmpLordString[index] = StringManager.Instance.SpawnString(100);
    for (int index = 0; index < this.JailerStr.Length; ++index)
      this.JailerStr[index] = StringManager.Instance.SpawnString();
    this.hintString = StringManager.Instance.SpawnString(300);
    this.countDown = StringManager.Instance.SpawnString();
    this.PopStr = StringManager.Instance.SpawnString();
    this.EnStr = StringManager.Instance.SpawnString();
    this.TitleSPItemText = StringManager.Instance.SpawnString(300);
    this.TitleSPItemText2 = StringManager.Instance.SpawnString(300);
    this.TitleSPItemText3 = StringManager.Instance.SpawnString(300);
    Font ttfFont = instance.GetTTFFont();
    this.AGS_Form = this.transform;
    this.AGS_bgPanel = this.AGS_Form.GetChild(0).GetComponent<UISpritesArray>();
    UIButton component1 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component1.image).material = this.door.LoadMaterial();
    component1.m_EffectType = e_EffectType.e_Scale;
    component1.transition = (Selectable.Transition) 0;
    Image component2 = this.AGS_Form.GetChild(1).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component2).material = this.door.LoadMaterial();
    ((Behaviour) component2).enabled = !GUIManager.Instance.bOpenOnIPhoneX;
    this.headInfoPanel = this.AGS_Form.GetChild(2).GetComponent<RectTransform>();
    this.AGS_btn_BuffInfo = this.AGS_Form.GetChild(2).GetChild(0).GetComponent<UISpritesArray>();
    UIButton component3 = this.AGS_Form.GetChild(2).GetChild(0).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_EffectType = e_EffectType.e_Scale;
    component3.transition = (Selectable.Transition) 0;
    this.AGS_HeadBGImage = this.AGS_Form.GetChild(2).GetChild(1).GetComponent<UISpritesArray>();
    this.AGS_HeadBGImage.gameObject.SetActive(false);
    UIText component4 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
    component4.font = ttfFont;
    component4.text = string.Empty;
    component4.SetCheckArabic(true);
    UIButton component5 = this.AGS_Form.GetChild(2).GetChild(3).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_EffectType = e_EffectType.e_Scale;
    component5.transition = (Selectable.Transition) 0;
    UIButton component6 = this.AGS_Form.GetChild(2).GetChild(4).GetComponent<UIButton>();
    component6.m_Handler = (IUIButtonClickHandler) this;
    component6.m_EffectType = e_EffectType.e_Scale;
    component6.transition = (Selectable.Transition) 0;
    UIText component7 = this.AGS_Form.GetChild(2).GetChild(5).GetComponent<UIText>();
    component7.font = ttfFont;
    component7.text = string.Empty;
    UIText component8 = this.AGS_Form.GetChild(2).GetChild(6).GetComponent<UIText>();
    component8.font = ttfFont;
    component8.text = string.Empty;
    UIButton component9 = this.AGS_Form.GetChild(2).GetChild(7).GetComponent<UIButton>();
    component9.m_Handler = (IUIButtonClickHandler) this;
    component9.m_EffectType = e_EffectType.e_Scale;
    this.AGS_GuildLogo = this.AGS_Form.GetChild(2).GetChild(7).GetChild(0).GetComponent<UISpritesArray>();
    UIButton component10 = this.AGS_Form.GetChild(2).GetChild(8).GetComponent<UIButton>();
    component10.m_Handler = (IUIButtonClickHandler) this;
    UIButtonHint uiButtonHint1 = ((Component) component10).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint1.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint1.m_Handler = (MonoBehaviour) this;
    this.AGS_GuildRank = this.AGS_Form.GetChild(2).GetChild(8).GetComponent<UISpritesArray>();
    UIButton component11 = this.AGS_Form.GetChild(2).GetChild(9).GetComponent<UIButton>();
    component11.m_Handler = (IUIButtonClickHandler) this;
    UIButtonHint uiButtonHint2 = ((Component) component11).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint2.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint2.m_Handler = (MonoBehaviour) this;
    UIButton component12 = this.AGS_Form.GetChild(2).GetChild(10).GetComponent<UIButton>();
    component12.m_Handler = (IUIButtonClickHandler) this;
    UIButtonHint uiButtonHint3 = ((Component) component12).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint3.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint3.m_Handler = (MonoBehaviour) this;
    UIText component13 = this.AGS_Form.GetChild(2).GetChild(11).GetComponent<UIText>();
    component13.font = ttfFont;
    component13.text = string.Empty;
    if (instance.IsArabic)
    {
      RectTransform component14 = ((Component) component12).gameObject.GetComponent<RectTransform>();
      ((Transform) component14).localScale = new Vector3(-1f, 1f, 1f);
      component14.anchoredPosition = new Vector2(component14.anchoredPosition.x + 40f, component14.anchoredPosition.y);
    }
    UIButton component15 = this.AGS_Form.GetChild(2).GetChild(12).GetComponent<UIButton>();
    component15.m_Handler = (IUIButtonClickHandler) this;
    UIButtonHint uiButtonHint4 = ((Component) component15).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint4.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint4.m_Handler = (MonoBehaviour) this;
    UIButton component16 = this.AGS_Form.GetChild(2).GetChild(13).GetComponent<UIButton>();
    component16.m_Handler = (IUIButtonClickHandler) this;
    UIButtonHint uiButtonHint5 = ((Component) component16).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint5.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint5.m_Handler = (MonoBehaviour) this;
    component16.m_BtnID1 = 6;
    component16.m_BtnID2 = 7;
    UIButton component17 = this.AGS_Form.GetChild(2).GetChild(14).GetComponent<UIButton>();
    component17.m_Handler = (IUIButtonClickHandler) this;
    UIButtonHint uiButtonHint6 = ((Component) component17).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint6.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint6.m_Handler = (MonoBehaviour) this;
    component17.m_BtnID1 = 6;
    component17.m_BtnID2 = 6;
    UIButton component18 = this.AGS_Form.GetChild(2).GetChild(15).GetComponent<UIButton>();
    component18.m_Handler = (IUIButtonClickHandler) this;
    UIButtonHint uiButtonHint7 = ((Component) component18).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint7.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint7.m_Handler = (MonoBehaviour) this;
    component18.m_BtnID1 = 6;
    component18.m_BtnID2 = 11;
    ((Component) component18).gameObject.SetActive(false);
    this.AGS_Form.GetChild(2).GetChild(16).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.SideBtnPanel = this.AGS_Form.GetChild(3).GetComponent<RectTransform>();
    UIButton component19 = this.AGS_Form.GetChild(3).GetChild(0).GetComponent<UIButton>();
    component19.m_Handler = (IUIButtonClickHandler) this;
    component19.m_EffectType = e_EffectType.e_Scale;
    component19.transition = (Selectable.Transition) 0;
    Image component20 = this.AGS_Form.GetChild(3).GetChild(0).GetChild(0).GetComponent<Image>();
    component20.sprite = this.door.LoadSprite("UI_main_redbox_01");
    ((MaskableGraphic) component20).material = this.door.LoadMaterial();
    component20.type = (Image.Type) 1;
    Image component21 = this.AGS_Form.GetChild(3).GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
    component21.sprite = this.door.LoadSprite("UI_main_mess_ex");
    ((MaskableGraphic) component21).material = this.door.LoadMaterial();
    UIButton component22 = this.AGS_Form.GetChild(3).GetChild(1).GetComponent<UIButton>();
    component22.m_Handler = (IUIButtonClickHandler) this;
    component22.m_EffectType = e_EffectType.e_Scale;
    component22.transition = (Selectable.Transition) 0;
    UIButton component23 = this.AGS_Form.GetChild(3).GetChild(2).GetComponent<UIButton>();
    component23.m_Handler = (IUIButtonClickHandler) this;
    component23.m_EffectType = e_EffectType.e_Scale;
    component23.transition = (Selectable.Transition) 0;
    UIButton component24 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<UIButton>();
    component24.m_Handler = (IUIButtonClickHandler) this;
    component24.m_EffectType = e_EffectType.e_Scale;
    component24.transition = (Selectable.Transition) 0;
    component24.m_BtnID2 = 9;
    this.CoordBtnRT = ((Component) component24).transform as RectTransform;
    this.ItemPanel = this.AGS_Form.GetChild(5).GetComponent<RectTransform>();
    this.UILEBtn = new RectTransform[8];
    for (int index = 0; index < 8; ++index)
    {
      this.UILEBtn[index] = this.AGS_Form.GetChild(5).GetChild(index + 16).GetComponent<RectTransform>();
      global::UILEBtn component25 = ((Component) this.UILEBtn[index]).GetComponent<global::UILEBtn>();
      component25.m_Handler = (IUILEBtnClickHandler) this;
      instance.InitLordEquipImg(((Component) this.UILEBtn[index]).transform, (ushort) 0, (byte) 0, setScale: true, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      if (this.OpenKind == EUILordInfoLayout.LordOther)
      {
        component25.SetEffectType(e_EffectType.e_Normal);
        ((Component) this.UILEBtn[index]).GetComponent<uButtonScale>().enabled = false;
      }
      UIButton component26 = this.AGS_Form.GetChild(5).GetChild(index + 8).GetComponent<UIButton>();
      component26.m_Handler = (IUIButtonClickHandler) this;
      if (this.OpenKind == EUILordInfoLayout.LordSelf)
        component26.m_EffectType = e_EffectType.e_Scale;
      component26.transition = (Selectable.Transition) 0;
      GameConstants.SetPivot(((Component) component26).GetComponent<RectTransform>(), new Vector2(0.5f, 0.5f));
    }
    UIButtonHint uiButtonHint8 = ((Component) this.AGS_Form.GetChild(5).GetChild(14).GetComponent<UIButton>()).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint8.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint8.m_Handler = (MonoBehaviour) this;
    UIButtonHint uiButtonHint9 = ((Component) this.AGS_Form.GetChild(5).GetChild(15).GetComponent<UIButton>()).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint9.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint9.m_Handler = (MonoBehaviour) this;
    UIButton component27 = this.AGS_Form.GetChild(6).GetChild(0).GetComponent<UIButton>();
    component27.m_Handler = (IUIButtonClickHandler) this;
    component27.m_BtnID1 = 6;
    component27.m_BtnID2 = 8;
    UIButtonHint uiButtonHint10 = ((Component) component27).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint10.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint10.m_Handler = (MonoBehaviour) this;
    UIButton component28 = this.AGS_Form.GetChild(6).GetChild(1).GetComponent<UIButton>();
    component28.m_Handler = (IUIButtonClickHandler) this;
    component28.m_BtnID1 = 6;
    component28.m_BtnID2 = 10;
    UIButtonHint uiButtonHint11 = ((Component) component28).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint11.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint11.m_Handler = (MonoBehaviour) this;
    UIButton component29 = this.AGS_Form.GetChild(6).GetChild(6).GetComponent<UIButton>();
    component29.m_Handler = (IUIButtonClickHandler) this;
    component29.m_BtnID1 = 6;
    component29.m_BtnID2 = 8;
    UIButtonHint uiButtonHint12 = ((Component) component29).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint12.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint12.m_Handler = (MonoBehaviour) this;
    if (instance.IsArabic)
    {
      RectTransform component30 = ((Component) component29).gameObject.GetComponent<RectTransform>();
      ((Transform) component30).localScale = new Vector3(-1f, 1f, 1f);
      component30.anchoredPosition = new Vector2(component30.anchoredPosition.x + 42f, component30.anchoredPosition.y);
    }
    UIButton component31 = this.AGS_Form.GetChild(6).GetChild(4).GetComponent<UIButton>();
    component31.m_Handler = (IUIButtonClickHandler) this;
    component31.m_EffectType = e_EffectType.e_Scale;
    component31.transition = (Selectable.Transition) 0;
    component31.m_BtnID1 = 9;
    component31.m_BtnID2 = 1;
    UIButton component32 = this.AGS_Form.GetChild(6).GetChild(5).GetComponent<UIButton>();
    component32.m_Handler = (IUIButtonClickHandler) this;
    component32.m_EffectType = e_EffectType.e_Scale;
    component32.transition = (Selectable.Transition) 0;
    component32.m_BtnID1 = 9;
    component32.m_BtnID2 = 2;
    UIText component33 = this.AGS_Form.GetChild(6).GetChild(7).GetComponent<UIText>();
    component33.text = string.Empty;
    component33.font = ttfFont;
    UIText component34 = this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>();
    component34.text = string.Empty;
    component34.font = ttfFont;
    UIButton component35 = this.AGS_Form.GetChild(7).GetComponent<UIButton>();
    component35.m_Handler = (IUIButtonClickHandler) this;
    UIButtonHint uiButtonHint13 = ((Component) component35).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint13.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint13.m_Handler = (MonoBehaviour) this;
    if (this.DM.UserLanguage == GameLanguage.GL_Chs)
      this.AGS_Form.GetChild(7).GetComponent<UISpritesArray>().SetSpriteIndex(1);
    if (instance.IsArabic)
    {
      RectTransform component36 = ((Component) component35).gameObject.GetComponent<RectTransform>();
      ((Transform) component36).localScale = new Vector3(-1f, 1f, 1f);
      component36.anchoredPosition = new Vector2(component36.anchoredPosition.x + 59f, component36.anchoredPosition.y);
    }
    UIText component37 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
    component37.font = ttfFont;
    component37.text = string.Empty;
    if (instance.IsArabic)
      ((Transform) ((Component) component37).gameObject.GetComponent<RectTransform>()).localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
    UIButton component38 = this.AGS_Form.GetChild(7).GetChild(1).GetComponent<UIButton>();
    component38.m_Handler = (IUIButtonClickHandler) this;
    component38.m_BtnID1 = 6;
    component38.m_BtnID2 = 25;
    UIButtonHint uiButtonHint14 = ((Component) component38).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint14.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint14.m_Handler = (MonoBehaviour) this;
    UIText component39 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetComponent<UIText>();
    component39.font = ttfFont;
    component39.text = string.Empty;
    if (instance.IsArabic)
      ((Transform) ((Component) component39).gameObject.GetComponent<RectTransform>()).localEulerAngles = new Vector3(0.0f, 180f, 0.0f);
    UIButton component40 = this.AGS_Form.GetChild(8).GetComponent<UIButton>();
    component40.m_Handler = (IUIButtonClickHandler) this;
    ((Component) component40).gameObject.SetActive(false);
    component40.transition = (Selectable.Transition) 0;
    component40.m_EffectType = e_EffectType.e_Scale;
    this.HeroRank = this.AGS_Form.GetChild(9).GetComponent<Image>();
    UIButton component41 = this.AGS_Form.GetChild(9).GetComponent<UIButton>();
    UIButtonHint uiButtonHint15 = this.AGS_Form.GetChild(9).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint15.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint15.m_Handler = (MonoBehaviour) this;
    component41.m_Handler = (IUIButtonClickHandler) this;
    this.AGS_HeroBadge = this.AGS_Form.GetChild(10).GetComponent<UISpritesArray>();
    UIButton component42 = this.AGS_Form.GetChild(10).GetComponent<UIButton>();
    UIButtonHint uiButtonHint16 = this.AGS_Form.GetChild(10).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint16.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint16.m_Handler = (MonoBehaviour) this;
    component42.m_Handler = (IUIButtonClickHandler) this;
    this.Hero_Pos = this.AGS_Form.GetChild(11);
    this.Hero_PosRT = this.Hero_Pos.GetComponent<RectTransform>();
    this.LightRT = this.AGS_Form.GetChild(12).GetComponent<RectTransform>();
    UIButton component43 = this.AGS_Form.GetChild(4).GetComponent<UIButton>();
    component43.m_Handler = (IUIButtonClickHandler) this;
    component43.m_BtnID1 = 10;
    this.HeroRotater = ((Component) component43).gameObject.AddComponent<UIBtnDrag>();
    this.HeroRotater.mHero = this.Hero_PosRT;
    this.TitlePanel = this.AGS_Form.GetChild(13).GetComponent<RectTransform>();
    ((Component) this.TitlePanel).gameObject.SetActive(false);
    UIButton component44 = this.AGS_Form.GetChild(13).GetChild(0).GetChild(0).GetComponent<UIButton>();
    component44.m_Handler = (IUIButtonClickHandler) this;
    component44.m_BtnID1 = 6;
    component44.m_BtnID2 = 22;
    UIButtonHint uiButtonHint17 = this.AGS_Form.GetChild(13).GetChild(0).GetChild(0).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint17.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint17.m_Handler = (MonoBehaviour) this;
    UIText component45 = this.AGS_Form.GetChild(13).GetChild(2).GetComponent<UIText>();
    component45.font = ttfFont;
    component45.text = string.Empty;
    component45.resizeTextForBestFit = true;
    component45.resizeTextMinSize = 10;
    component45.resizeTextMaxSize = 25;
    UIButton component46 = this.AGS_Form.GetChild(13).GetChild(3).GetChild(0).GetComponent<UIButton>();
    component46.m_Handler = (IUIButtonClickHandler) this;
    component46.m_BtnID1 = 6;
    component46.m_BtnID2 = 21;
    UIButtonHint uiButtonHint18 = this.AGS_Form.GetChild(13).GetChild(3).GetChild(0).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint18.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint18.m_Handler = (MonoBehaviour) this;
    UIText component47 = this.AGS_Form.GetChild(13).GetChild(5).GetComponent<UIText>();
    component47.font = ttfFont;
    component47.text = string.Empty;
    component47.resizeTextForBestFit = true;
    component47.resizeTextMinSize = 10;
    component47.resizeTextMaxSize = 25;
    UIButton component48 = this.AGS_Form.GetChild(13).GetChild(6).GetChild(0).GetComponent<UIButton>();
    component48.m_Handler = (IUIButtonClickHandler) this;
    component48.m_BtnID1 = 6;
    component48.m_BtnID2 = 21;
    UIButtonHint uiButtonHint19 = this.AGS_Form.GetChild(13).GetChild(6).GetChild(0).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint19.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint19.m_Handler = (MonoBehaviour) this;
    UIText component49 = this.AGS_Form.GetChild(13).GetChild(8).GetComponent<UIText>();
    component49.font = ttfFont;
    component49.text = string.Empty;
    component49.resizeTextForBestFit = true;
    component49.resizeTextMinSize = 10;
    component49.resizeTextMaxSize = 25;
    this.ScrollPanel = this.AGS_Form.GetChild(14).GetComponent<RectTransform>();
    this.AGS_ScrollPanel = this.AGS_Form.GetChild(14).GetChild(0).GetComponent<global::ScrollPanel>();
    UIText component50 = this.AGS_Form.GetChild(14).GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
    component50.font = ttfFont;
    component50.text = string.Empty;
    ((Component) component50).gameObject.AddComponent<Outline>();
    UIText component51 = this.AGS_Form.GetChild(14).GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
    component51.font = ttfFont;
    component51.text = this.DM.mStringTable.GetStringByID(7370U);
    ((Graphic) component51).color = (Color) new Color32(byte.MaxValue, byte.MaxValue, (byte) 153, byte.MaxValue);
    ((Component) component51).gameObject.AddComponent<Outline>();
    UIText component52 = this.AGS_Form.GetChild(14).GetChild(1).GetChild(1).GetChild(1).GetComponent<UIText>();
    component52.font = ttfFont;
    component52.text = string.Empty;
    UIText component53 = this.AGS_Form.GetChild(14).GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
    component53.font = ttfFont;
    component53.text = string.Empty;
    UIText component54 = this.AGS_Form.GetChild(14).GetChild(1).GetChild(1).GetChild(3).GetComponent<UIText>();
    component54.font = ttfFont;
    component54.text = string.Empty;
    ((Graphic) component54).color = (Color) new Color32((byte) 0, byte.MaxValue, (byte) 49, byte.MaxValue);
    this.AGS_Form.GetChild(14).GetChild(2).gameObject.SetActive(false);
    this.TitleSPItem = this.AGS_Form.GetChild(14).GetChild(2).GetComponent<RectTransform>();
    UIButton component55 = this.AGS_Form.GetChild(14).GetChild(2).GetChild(1).GetChild(0).GetComponent<UIButton>();
    component55.m_Handler = (IUIButtonClickHandler) this;
    component55.m_BtnID1 = 6;
    component55.m_BtnID2 = 26;
    UIButtonHint uiButtonHint20 = this.AGS_Form.GetChild(14).GetChild(2).GetChild(1).GetChild(0).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint20.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint20.m_Handler = (MonoBehaviour) this;
    uiButtonHint20.ScrollID = (byte) 1;
    UIText component56 = this.AGS_Form.GetChild(14).GetChild(2).GetChild(2).GetComponent<UIText>();
    component56.font = ttfFont;
    component56.text = string.Empty;
    UIText component57 = this.AGS_Form.GetChild(14).GetChild(2).GetChild(3).GetComponent<UIText>();
    component57.font = ttfFont;
    component57.text = string.Empty;
    this.TitleSPItem2 = this.AGS_Form.GetChild(14).GetChild(3).GetComponent<RectTransform>();
    UIButton component58 = this.AGS_Form.GetChild(14).GetChild(3).GetChild(1).GetChild(0).GetComponent<UIButton>();
    component58.m_Handler = (IUIButtonClickHandler) this;
    component58.m_BtnID1 = 6;
    component58.m_BtnID2 = 28;
    UIButtonHint uiButtonHint21 = this.AGS_Form.GetChild(14).GetChild(3).GetChild(1).GetChild(0).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint21.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint21.m_Handler = (MonoBehaviour) this;
    uiButtonHint21.ScrollID = (byte) 1;
    UIText component59 = this.AGS_Form.GetChild(14).GetChild(3).GetChild(2).GetComponent<UIText>();
    component59.font = ttfFont;
    component59.text = string.Empty;
    UIText component60 = this.AGS_Form.GetChild(14).GetChild(3).GetChild(3).GetComponent<UIText>();
    component60.font = ttfFont;
    component60.text = string.Empty;
    this.TitleSPItem3 = this.AGS_Form.GetChild(14).GetChild(4).GetComponent<RectTransform>();
    UIButton component61 = this.AGS_Form.GetChild(14).GetChild(4).GetChild(1).GetChild(0).GetComponent<UIButton>();
    component61.m_Handler = (IUIButtonClickHandler) this;
    component61.m_BtnID1 = 6;
    component61.m_BtnID2 = 27;
    UIButtonHint uiButtonHint22 = this.AGS_Form.GetChild(14).GetChild(4).GetChild(1).GetChild(0).gameObject.AddComponent<UIButtonHint>();
    uiButtonHint22.m_eHint = EUIButtonHint.DownUpHandler;
    uiButtonHint22.m_Handler = (MonoBehaviour) this;
    uiButtonHint22.ScrollID = (byte) 1;
    UIText component62 = this.AGS_Form.GetChild(14).GetChild(4).GetChild(2).GetComponent<UIText>();
    component62.font = ttfFont;
    component62.text = string.Empty;
    UIText component63 = this.AGS_Form.GetChild(14).GetChild(4).GetChild(3).GetComponent<UIText>();
    component63.font = ttfFont;
    component63.text = string.Empty;
    this.PopupPanel = this.AGS_Form.GetChild(18).GetComponent<RectTransform>();
    this.JailerPanel = this.AGS_Form.GetChild(15).GetComponent<RectTransform>();
    this.AGS_Form.GetChild(15).GetChild(2).GetComponent<UIHIBtn>().m_Handler = (IUIHIBtnClickHandler) this;
    UIButton component64 = this.AGS_Form.GetChild(15).GetChild(3).GetComponent<UIButton>();
    component64.m_Handler = (IUIButtonClickHandler) this;
    component64.m_EffectType = e_EffectType.e_Scale;
    component64.transition = (Selectable.Transition) 0;
    this.AGS_Form.GetChild(15).GetChild(4).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    UIText component65 = this.AGS_Form.GetChild(15).GetChild(5).GetComponent<UIText>();
    component65.font = ttfFont;
    component65.text = this.DM.mStringTable.GetStringByID(7774U);
    UIText component66 = this.AGS_Form.GetChild(15).GetChild(6).GetComponent<UIText>();
    component66.font = ttfFont;
    component66.text = string.Empty;
    UIText component67 = this.AGS_Form.GetChild(15).GetChild(7).GetComponent<UIText>();
    component67.font = ttfFont;
    component67.text = string.Empty;
    UIText component68 = this.AGS_Form.GetChild(15).GetChild(9).GetComponent<UIText>();
    component68.font = ttfFont;
    component68.text = this.DM.mStringTable.GetStringByID(7775U);
    UIText component69 = this.AGS_Form.GetChild(15).GetChild(10).GetComponent<UIText>();
    component69.font = ttfFont;
    component69.text = string.Empty;
    UIButton component70 = this.AGS_Form.GetChild(15).GetChild(12).GetComponent<UIButton>();
    component70.m_Handler = (IUIButtonClickHandler) this;
    component70.m_EffectType = e_EffectType.e_Scale;
    component70.transition = (Selectable.Transition) 0;
    UIText component71 = this.AGS_Form.GetChild(15).GetChild(12).GetChild(0).GetComponent<UIText>();
    component71.font = ttfFont;
    component71.text = this.DM.mStringTable.GetStringByID(7776U);
    UIText component72 = this.AGS_Form.GetChild(15).GetChild(15).GetComponent<UIText>();
    component72.font = ttfFont;
    component72.text = this.DM.mStringTable.GetStringByID(7764U);
    UIText component73 = this.AGS_Form.GetChild(15).GetChild(17).GetComponent<UIText>();
    component73.font = ttfFont;
    component73.text = string.Empty;
    UIButton component74 = this.AGS_Form.GetChild(15).GetChild(18).GetComponent<UIButton>();
    component74.m_Handler = (IUIButtonClickHandler) this;
    component74.m_EffectType = e_EffectType.e_Scale;
    component74.transition = (Selectable.Transition) 0;
    UIText component75 = this.AGS_Form.GetChild(15).GetChild(18).GetChild(0).GetComponent<UIText>();
    component75.font = ttfFont;
    component75.text = this.DM.mStringTable.GetStringByID(7773U);
    this.RescurePanel = this.AGS_Form.GetChild(16).GetComponent<RectTransform>();
    UIButton component76 = this.AGS_Form.GetChild(16).GetChild(0).GetComponent<UIButton>();
    component76.m_Handler = (IUIButtonClickHandler) this;
    component76.m_EffectType = e_EffectType.e_Scale;
    UIText component77 = this.AGS_Form.GetChild(16).GetChild(0).GetChild(0).GetComponent<UIText>();
    component77.font = ttfFont;
    component77.text = this.DM.mStringTable.GetStringByID(7785U);
    this.CaptureBar = this.AGS_Form.GetChild(17).GetComponent<RectTransform>();
    UIText component78 = this.AGS_Form.GetChild(17).GetChild(3).GetComponent<UIText>();
    component78.font = ttfFont;
    component78.text = string.Empty;
    UIText component79 = this.AGS_Form.GetChild(17).GetChild(4).GetComponent<UIText>();
    component79.font = ttfFont;
    component79.text = string.Empty;
    UIText component80 = this.AGS_Form.GetChild(17).GetChild(5).GetComponent<UIText>();
    component80.font = ttfFont;
    component80.text = this.DM.mStringTable.GetStringByID(7792U);
    ((Component) component80).gameObject.SetActive(false);
    UIButton component81 = this.AGS_Form.GetChild(17).GetChild(6).GetComponent<UIButton>();
    component81.m_Handler = (IUIButtonClickHandler) this;
    ((Component) component81).gameObject.SetActive(false);
    component81.m_BtnID1 = 2;
    component81.m_BtnID2 = 10;
    this.AGS_Form.GetChild(18).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    UIButton component82 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(0).GetComponent<UIButton>();
    component82.m_Handler = (IUIButtonClickHandler) this;
    component82.m_EffectType = e_EffectType.e_Scale;
    component82.transition = (Selectable.Transition) 0;
    UIText component83 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(0).GetChild(1).GetComponent<UIText>();
    component83.text = this.DM.mStringTable.GetStringByID(7227U);
    component83.font = ttfFont;
    UIButton component84 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(1).GetComponent<UIButton>();
    component84.m_Handler = (IUIButtonClickHandler) this;
    component84.m_EffectType = e_EffectType.e_Scale;
    component84.transition = (Selectable.Transition) 0;
    ((Component) component84).gameObject.SetActive(false);
    UIText component85 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(1).GetChild(1).GetComponent<UIText>();
    component85.text = this.DM.mStringTable.GetStringByID(7228U);
    component85.font = ttfFont;
    UIButton component86 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(2).GetComponent<UIButton>();
    component86.m_Handler = (IUIButtonClickHandler) this;
    component86.m_EffectType = e_EffectType.e_Scale;
    component86.transition = (Selectable.Transition) 0;
    UIText component87 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(2).GetChild(1).GetComponent<UIText>();
    component87.text = this.DM.mStringTable.GetStringByID(7229U);
    component87.font = ttfFont;
    this.HintPanel = this.AGS_Form.GetChild(19).GetComponent<RectTransform>();
    UIButton component88 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(3).GetComponent<UIButton>();
    component88.m_Handler = (IUIButtonClickHandler) this;
    component88.m_BtnID2 = 4;
    UIText component89 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(3).GetChild(1).GetComponent<UIText>();
    component89.text = this.DM.mStringTable.GetStringByID(4552U);
    component89.font = ttfFont;
    UIButton component90 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(4).GetComponent<UIButton>();
    component90.m_Handler = (IUIButtonClickHandler) this;
    component90.m_BtnID2 = 5;
    UIText component91 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(4).GetChild(1).GetComponent<UIText>();
    component91.text = this.DM.mStringTable.GetStringByID(4553U);
    component91.font = ttfFont;
    UIButton component92 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(5).GetComponent<UIButton>();
    component92.m_Handler = (IUIButtonClickHandler) this;
    component92.m_BtnID2 = 6;
    UIText component93 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(5).GetChild(1).GetComponent<UIText>();
    component93.font = ttfFont;
    component93.text = this.DM.mStringTable.GetStringByID(9348U);
    UIButton component94 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(6).GetComponent<UIButton>();
    component94.m_Handler = (IUIButtonClickHandler) this;
    component94.m_BtnID2 = 7;
    UIText component95 = this.AGS_Form.GetChild(18).GetChild(0).GetChild(6).GetChild(1).GetComponent<UIText>();
    component95.font = ttfFont;
    component95.text = this.DM.mStringTable.GetStringByID(9739U);
    UIText component96 = this.AGS_Form.GetChild(19).GetChild(1).GetComponent<UIText>();
    component96.font = ttfFont;
    component96.text = string.Empty;
    ((Behaviour) this.AGS_Form.GetChild(20).GetComponent<Image>()).enabled = false;
    UIText component97 = this.AGS_Form.GetChild(20).GetChild(0).GetComponent<UIText>();
    component97.text = this.DM.mStringTable.GetStringByID(7275U);
    component97.font = ttfFont;
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      RectTransform component98 = this.AGS_Form.GetChild(18).GetComponent<RectTransform>();
      component98.offsetMin = new Vector2(-GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
      component98.offsetMax = new Vector2(GUIManager.Instance.IPhoneX_DeltaX, 0.0f);
    }
    this.BarLight = ((Transform) this.CaptureBar).GetChild(0).GetComponent<Image>();
    this.Header_NameText = StringManager.Instance.SpawnString(300);
    for (int index = 0; index < 8; ++index)
    {
      ((Component) this.UILEBtn[index]).gameObject.SetActive(false);
      this.LEquipLight[index] = this.AGS_Form.GetChild(5).GetChild(index + 8).GetChild(0).GetComponent<Image>();
    }
    for (int index = 3; index < this.AGS_Form.childCount; ++index)
    {
      Vector3 localPosition = this.AGS_Form.GetChild(index).localPosition with
      {
        z = -1000f
      };
      this.AGS_Form.GetChild(index).localPosition = localPosition;
    }
    Vector3 localPosition1 = this.AGS_Form.GetChild(11).localPosition with
    {
      z = -500f
    };
    this.AGS_Form.GetChild(11).localPosition = localPosition1;
    this.AGS_Form.GetChild(12).localPosition = localPosition1;
    this.SetFormLayout(this.OpenKind);
    this.UpdateInfo();
    instance.UpdateUI(EGUIWindow.Door, 1, 2);
    if (this.OpenKind == EUILordInfoLayout.LordOther)
    {
      GUIManager.Instance.ShowUILock(EUILock.LordInfo);
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_PROFILE;
      messagePacket.AddSeqId();
      messagePacket.Add(this.DM.mLordName.ToString(), 13);
      messagePacket.Send();
    }
    LordEquipData.Instance().LoadLordEquip();
    LordEquipData.CheckEquipExpired();
    this.NextActionTime = Time.time + 5f;
  }

  public void Refresh_FontTexture()
  {
    UnityEngine.UI.Text component1 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component1 != (UnityEngine.Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UnityEngine.UI.Text component2 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(2).GetChild(5).GetComponent<UIText>();
    if ((UnityEngine.Object) component2 != (UnityEngine.Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    UnityEngine.UI.Text component3 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(2).GetChild(6).GetComponent<UIText>();
    if ((UnityEngine.Object) component3 != (UnityEngine.Object) null && ((Behaviour) component3).enabled)
    {
      ((Behaviour) component3).enabled = false;
      ((Behaviour) component3).enabled = true;
    }
    UnityEngine.UI.Text component4 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(2).GetChild(11).GetComponent<UIText>();
    if ((UnityEngine.Object) component4 != (UnityEngine.Object) null && ((Behaviour) component4).enabled)
    {
      ((Behaviour) component4).enabled = false;
      ((Behaviour) component4).enabled = true;
    }
    UnityEngine.UI.Text component5 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(6).GetChild(7).GetComponent<UIText>();
    if ((UnityEngine.Object) component5 != (UnityEngine.Object) null && ((Behaviour) component5).enabled)
    {
      ((Behaviour) component5).enabled = false;
      ((Behaviour) component5).enabled = true;
    }
    UnityEngine.UI.Text component6 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>();
    if ((UnityEngine.Object) component6 != (UnityEngine.Object) null && ((Behaviour) component6).enabled)
    {
      ((Behaviour) component6).enabled = false;
      ((Behaviour) component6).enabled = true;
    }
    UnityEngine.UI.Text component7 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component7 != (UnityEngine.Object) null && ((Behaviour) component7).enabled)
    {
      ((Behaviour) component7).enabled = false;
      ((Behaviour) component7).enabled = true;
    }
    UnityEngine.UI.Text component8 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component8 != (UnityEngine.Object) null && ((Behaviour) component8).enabled)
    {
      ((Behaviour) component8).enabled = false;
      ((Behaviour) component8).enabled = true;
    }
    UnityEngine.UI.Text component9 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(13).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component9 != (UnityEngine.Object) null && ((Behaviour) component9).enabled)
    {
      ((Behaviour) component9).enabled = false;
      ((Behaviour) component9).enabled = true;
    }
    UnityEngine.UI.Text component10 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(13).GetChild(5).GetComponent<UIText>();
    if ((UnityEngine.Object) component10 != (UnityEngine.Object) null && ((Behaviour) component10).enabled)
    {
      ((Behaviour) component10).enabled = false;
      ((Behaviour) component10).enabled = true;
    }
    UnityEngine.UI.Text component11 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(13).GetChild(8).GetComponent<UIText>();
    if ((UnityEngine.Object) component11 != (UnityEngine.Object) null && ((Behaviour) component11).enabled)
    {
      ((Behaviour) component11).enabled = false;
      ((Behaviour) component11).enabled = true;
    }
    UnityEngine.UI.Text component12 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(14).GetChild(1).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component12 != (UnityEngine.Object) null && ((Behaviour) component12).enabled)
    {
      ((Behaviour) component12).enabled = false;
      ((Behaviour) component12).enabled = true;
    }
    UnityEngine.UI.Text component13 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(14).GetChild(1).GetChild(0).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component13 != (UnityEngine.Object) null && ((Behaviour) component13).enabled)
    {
      ((Behaviour) component13).enabled = false;
      ((Behaviour) component13).enabled = true;
    }
    UnityEngine.UI.Text component14 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(14).GetChild(1).GetChild(1).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component14 != (UnityEngine.Object) null && ((Behaviour) component14).enabled)
    {
      ((Behaviour) component14).enabled = false;
      ((Behaviour) component14).enabled = true;
    }
    UnityEngine.UI.Text component15 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(14).GetChild(1).GetChild(1).GetChild(2).GetComponent<UIText>();
    if ((UnityEngine.Object) component15 != (UnityEngine.Object) null && ((Behaviour) component15).enabled)
    {
      ((Behaviour) component15).enabled = false;
      ((Behaviour) component15).enabled = true;
    }
    UnityEngine.UI.Text component16 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(14).GetChild(1).GetChild(1).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component16 != (UnityEngine.Object) null && ((Behaviour) component16).enabled)
    {
      ((Behaviour) component16).enabled = false;
      ((Behaviour) component16).enabled = true;
    }
    if ((UnityEngine.Object) this.TitleSPItem != (UnityEngine.Object) null)
    {
      ((Transform) this.TitleSPItem).GetChild(2).GetComponent<UIText>();
      if ((UnityEngine.Object) component16 != (UnityEngine.Object) null && ((Behaviour) component16).enabled)
      {
        ((Behaviour) component16).enabled = false;
        ((Behaviour) component16).enabled = true;
      }
      ((Transform) this.TitleSPItem).GetChild(3).GetComponent<UIText>();
      if ((UnityEngine.Object) component16 != (UnityEngine.Object) null && ((Behaviour) component16).enabled)
      {
        ((Behaviour) component16).enabled = false;
        ((Behaviour) component16).enabled = true;
      }
    }
    if ((UnityEngine.Object) this.TitleSPItem2 != (UnityEngine.Object) null)
    {
      ((Transform) this.TitleSPItem2).GetChild(2).GetComponent<UIText>();
      if ((UnityEngine.Object) component16 != (UnityEngine.Object) null && ((Behaviour) component16).enabled)
      {
        ((Behaviour) component16).enabled = false;
        ((Behaviour) component16).enabled = true;
      }
      ((Transform) this.TitleSPItem2).GetChild(3).GetComponent<UIText>();
      if ((UnityEngine.Object) component16 != (UnityEngine.Object) null && ((Behaviour) component16).enabled)
      {
        ((Behaviour) component16).enabled = false;
        ((Behaviour) component16).enabled = true;
      }
    }
    if ((UnityEngine.Object) this.TitleSPItem3 != (UnityEngine.Object) null)
    {
      ((Transform) this.TitleSPItem3).GetChild(2).GetComponent<UIText>();
      if ((UnityEngine.Object) component16 != (UnityEngine.Object) null && ((Behaviour) component16).enabled)
      {
        ((Behaviour) component16).enabled = false;
        ((Behaviour) component16).enabled = true;
      }
      ((Transform) this.TitleSPItem3).GetChild(3).GetComponent<UIText>();
      if ((UnityEngine.Object) component16 != (UnityEngine.Object) null && ((Behaviour) component16).enabled)
      {
        ((Behaviour) component16).enabled = false;
        ((Behaviour) component16).enabled = true;
      }
    }
    UnityEngine.UI.Text component17 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(15).GetChild(5).GetComponent<UIText>();
    if ((UnityEngine.Object) component17 != (UnityEngine.Object) null && ((Behaviour) component17).enabled)
    {
      ((Behaviour) component17).enabled = false;
      ((Behaviour) component17).enabled = true;
    }
    UnityEngine.UI.Text component18 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(15).GetChild(6).GetComponent<UIText>();
    if ((UnityEngine.Object) component18 != (UnityEngine.Object) null && ((Behaviour) component18).enabled)
    {
      ((Behaviour) component18).enabled = false;
      ((Behaviour) component18).enabled = true;
    }
    UnityEngine.UI.Text component19 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(15).GetChild(7).GetComponent<UIText>();
    if ((UnityEngine.Object) component19 != (UnityEngine.Object) null && ((Behaviour) component19).enabled)
    {
      ((Behaviour) component19).enabled = false;
      ((Behaviour) component19).enabled = true;
    }
    UnityEngine.UI.Text component20 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(15).GetChild(9).GetComponent<UIText>();
    if ((UnityEngine.Object) component20 != (UnityEngine.Object) null && ((Behaviour) component20).enabled)
    {
      ((Behaviour) component20).enabled = false;
      ((Behaviour) component20).enabled = true;
    }
    UnityEngine.UI.Text component21 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(15).GetChild(10).GetComponent<UIText>();
    if ((UnityEngine.Object) component21 != (UnityEngine.Object) null && ((Behaviour) component21).enabled)
    {
      ((Behaviour) component21).enabled = false;
      ((Behaviour) component21).enabled = true;
    }
    UnityEngine.UI.Text component22 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(15).GetChild(12).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component22 != (UnityEngine.Object) null && ((Behaviour) component22).enabled)
    {
      ((Behaviour) component22).enabled = false;
      ((Behaviour) component22).enabled = true;
    }
    UnityEngine.UI.Text component23 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(15).GetChild(15).GetComponent<UIText>();
    if ((UnityEngine.Object) component23 != (UnityEngine.Object) null && ((Behaviour) component23).enabled)
    {
      ((Behaviour) component23).enabled = false;
      ((Behaviour) component23).enabled = true;
    }
    UnityEngine.UI.Text component24 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(15).GetChild(17).GetComponent<UIText>();
    if ((UnityEngine.Object) component24 != (UnityEngine.Object) null && ((Behaviour) component24).enabled)
    {
      ((Behaviour) component24).enabled = false;
      ((Behaviour) component24).enabled = true;
    }
    UnityEngine.UI.Text component25 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(15).GetChild(18).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component25 != (UnityEngine.Object) null && ((Behaviour) component25).enabled)
    {
      ((Behaviour) component25).enabled = false;
      ((Behaviour) component25).enabled = true;
    }
    UnityEngine.UI.Text component26 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(16).GetChild(0).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component26 != (UnityEngine.Object) null && ((Behaviour) component26).enabled)
    {
      ((Behaviour) component26).enabled = false;
      ((Behaviour) component26).enabled = true;
    }
    UnityEngine.UI.Text component27 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(17).GetChild(3).GetComponent<UIText>();
    if ((UnityEngine.Object) component27 != (UnityEngine.Object) null && ((Behaviour) component27).enabled)
    {
      ((Behaviour) component27).enabled = false;
      ((Behaviour) component27).enabled = true;
    }
    UnityEngine.UI.Text component28 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(17).GetChild(4).GetComponent<UIText>();
    if ((UnityEngine.Object) component28 != (UnityEngine.Object) null && ((Behaviour) component28).enabled)
    {
      ((Behaviour) component28).enabled = false;
      ((Behaviour) component28).enabled = true;
    }
    UnityEngine.UI.Text component29 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(17).GetChild(5).GetComponent<UIText>();
    if ((UnityEngine.Object) component29 != (UnityEngine.Object) null && ((Behaviour) component29).enabled)
    {
      ((Behaviour) component29).enabled = false;
      ((Behaviour) component29).enabled = true;
    }
    UnityEngine.UI.Text component30 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(18).GetChild(0).GetChild(0).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component30 != (UnityEngine.Object) null && ((Behaviour) component30).enabled)
    {
      ((Behaviour) component30).enabled = false;
      ((Behaviour) component30).enabled = true;
    }
    UnityEngine.UI.Text component31 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(18).GetChild(0).GetChild(1).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component31 != (UnityEngine.Object) null && ((Behaviour) component31).enabled)
    {
      ((Behaviour) component31).enabled = false;
      ((Behaviour) component31).enabled = true;
    }
    UnityEngine.UI.Text component32 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(18).GetChild(0).GetChild(2).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component32 != (UnityEngine.Object) null && ((Behaviour) component32).enabled)
    {
      ((Behaviour) component32).enabled = false;
      ((Behaviour) component32).enabled = true;
    }
    UnityEngine.UI.Text component33 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(18).GetChild(0).GetChild(3).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component33 != (UnityEngine.Object) null && ((Behaviour) component33).enabled)
    {
      ((Behaviour) component33).enabled = false;
      ((Behaviour) component33).enabled = true;
    }
    UnityEngine.UI.Text component34 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(18).GetChild(0).GetChild(4).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component34 != (UnityEngine.Object) null && ((Behaviour) component34).enabled)
    {
      ((Behaviour) component34).enabled = false;
      ((Behaviour) component34).enabled = true;
    }
    UnityEngine.UI.Text component35 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(18).GetChild(0).GetChild(5).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component35 != (UnityEngine.Object) null && ((Behaviour) component35).enabled)
    {
      ((Behaviour) component35).enabled = false;
      ((Behaviour) component35).enabled = true;
    }
    UnityEngine.UI.Text component36 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(18).GetChild(0).GetChild(6).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component36 != (UnityEngine.Object) null && ((Behaviour) component36).enabled)
    {
      ((Behaviour) component36).enabled = false;
      ((Behaviour) component36).enabled = true;
    }
    UnityEngine.UI.Text component37 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(19).GetChild(1).GetComponent<UIText>();
    if ((UnityEngine.Object) component37 != (UnityEngine.Object) null && ((Behaviour) component37).enabled)
    {
      ((Behaviour) component37).enabled = false;
      ((Behaviour) component37).enabled = true;
    }
    UnityEngine.UI.Text component38 = (UnityEngine.UI.Text) this.AGS_Form.GetChild(20).GetChild(0).GetComponent<UIText>();
    if ((UnityEngine.Object) component38 != (UnityEngine.Object) null && ((Behaviour) component38).enabled)
    {
      ((Behaviour) component38).enabled = false;
      ((Behaviour) component38).enabled = true;
    }
    if ((UnityEngine.Object) this.AGS_ScrollPanel != (UnityEngine.Object) null && this.AGS_ScrollPanel.gameObject.activeInHierarchy)
    {
      Transform child1 = this.AGS_ScrollPanel.transform.GetChild(0);
      for (int index = 0; index < child1.childCount; ++index)
      {
        Transform child2 = child1.GetChild(index);
        if (child2.gameObject.activeInHierarchy)
        {
          if (child2.GetChild(0).gameObject.activeInHierarchy)
          {
            UnityEngine.UI.Text component39 = (UnityEngine.UI.Text) child2.GetChild(0).GetChild(0).GetComponent<UIText>();
            if ((UnityEngine.Object) component39 != (UnityEngine.Object) null && ((Behaviour) component39).enabled)
            {
              ((Behaviour) component39).enabled = false;
              ((Behaviour) component39).enabled = true;
            }
            UnityEngine.UI.Text component40 = (UnityEngine.UI.Text) child2.GetChild(0).GetChild(1).GetComponent<UIText>();
            if ((UnityEngine.Object) component40 != (UnityEngine.Object) null && ((Behaviour) component40).enabled)
            {
              ((Behaviour) component40).enabled = false;
              ((Behaviour) component40).enabled = true;
            }
          }
          if (child2.GetChild(1).gameObject.activeInHierarchy)
          {
            UnityEngine.UI.Text component41 = (UnityEngine.UI.Text) child2.GetChild(1).GetChild(1).GetComponent<UIText>();
            if ((UnityEngine.Object) component41 != (UnityEngine.Object) null && ((Behaviour) component41).enabled)
            {
              ((Behaviour) component41).enabled = false;
              ((Behaviour) component41).enabled = true;
            }
            UnityEngine.UI.Text component42 = (UnityEngine.UI.Text) child2.GetChild(1).GetChild(2).GetComponent<UIText>();
            if ((UnityEngine.Object) component42 != (UnityEngine.Object) null && ((Behaviour) component42).enabled)
            {
              ((Behaviour) component42).enabled = false;
              ((Behaviour) component42).enabled = true;
            }
            UnityEngine.UI.Text component43 = (UnityEngine.UI.Text) child2.GetChild(1).GetChild(3).GetComponent<UIText>();
            if ((UnityEngine.Object) component43 != (UnityEngine.Object) null && ((Behaviour) component43).enabled)
            {
              ((Behaviour) component43).enabled = false;
              ((Behaviour) component43).enabled = true;
            }
          }
        }
      }
    }
    for (int index = 0; index < 8; ++index)
      LordEquipData.ResetLordEquipFont((Transform) this.UILEBtn[index]);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        switch (sender.m_BtnID2)
        {
          case 0:
            switch (this.OpenKind)
            {
              case EUILordInfoLayout.RecordInfo:
              case EUILordInfoLayout.EnhanceInfo:
                this.SetFormLayout(EUILordInfoLayout.LordSelf);
                this.UpdateInfo();
                return;
              case EUILordInfoLayout.RecordInfoOther:
                this.SetFormLayout(EUILordInfoLayout.LordOther);
                this.UpdateInfo(1);
                return;
              default:
                this.door.CloseMenu();
                return;
            }
          case 1:
            this.SetPopUp(false);
            return;
          default:
            return;
        }
      case 1:
        switch (sender.m_BtnID2)
        {
          case 1:
            switch (this.OpenKind)
            {
              case EUILordInfoLayout.LordSelf:
                if (!this.StatDataReady)
                {
                  if (!GUIManager.Instance.ShowUILock(EUILock.LordInfo))
                    return;
                  MessagePacket messagePacket = new MessagePacket((ushort) 1024);
                  messagePacket.Protocol = Protocol._MSG_REQUEST_STATISTIC;
                  messagePacket.AddSeqId();
                  messagePacket.Add(this.DM.RoleAttr.Name.ToString(), 13);
                  messagePacket.Send();
                  return;
                }
                if (this.scrollPanelInit && this.HasBeenPage != EUILordInfoLayout.RecordInfo)
                  this.AGS_ScrollPanel.GoTo(0);
                this.UpdateInfo(3);
                return;
              case EUILordInfoLayout.LordOther:
                if (!this.StatDataReady)
                {
                  if (!GUIManager.Instance.ShowUILock(EUILock.LordInfo))
                    return;
                  MessagePacket messagePacket = new MessagePacket((ushort) 1024);
                  messagePacket.Protocol = Protocol._MSG_REQUEST_STATISTIC;
                  messagePacket.AddSeqId();
                  messagePacket.Add(this.DM.mLordProfile.PlayerName.ToString(), 13);
                  messagePacket.Send();
                  return;
                }
                this.UpdateInfo(3);
                return;
              case EUILordInfoLayout.RecordInfo:
                this.SetFormLayout(EUILordInfoLayout.LordSelf);
                this.UpdateInfo();
                return;
              case EUILordInfoLayout.RecordInfoOther:
                this.SetFormLayout(EUILordInfoLayout.LordOther);
                this.UpdateInfo(1);
                return;
              default:
                return;
            }
          case 2:
            if (NewbieManager.CheckRename(false))
              return;
            GUIManager.Instance.OpenMenu(EGUIWindow.UI_Name, bCameraMode: true, bSecWindow: true);
            return;
          case 3:
            this.AllianceClick();
            return;
          case 4:
            this.SetPopUp(true);
            return;
          case 5:
            return;
          default:
            return;
        }
      case 2:
        switch (sender.m_BtnID2)
        {
          case 1:
            GameConstants.GetBytes((ushort) 0, GUIManager.Instance.TalentSaved, 5);
            this.door.OpenMenu(EGUIWindow.UI_Talent);
            return;
          case 2:
            if (this.scrollPanelInit && this.HasBeenPage != EUILordInfoLayout.EnhanceInfo)
              this.AGS_ScrollPanel.GoTo(0);
            this.SetFormLayout(EUILordInfoLayout.EnhanceInfo);
            this.UpdateInfo();
            return;
          case 3:
            this.door.OpenMenu(EGUIWindow.UI_ReplaceLord);
            return;
          case 4:
            this.DM.Letter_ReplyName = this.DM.beCaptured.name.ToString();
            this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 2);
            return;
          case 5:
            this.door.GoToMapID(this.DM.beCaptured.KingdomID, this.DM.beCaptured.MapID, (byte) 0, (byte) 1);
            return;
          case 6:
            GUIManager.Instance.OpenMenu(EGUIWindow.UI_JailMoney, 1, bSecWindow: true);
            return;
          case 7:
            if (this.DM.beCaptured.Ransom > this.DM.Resource[4].Stock)
            {
              GUIManager.Instance.AddHUDMessage(this.DM.mStringTable.GetStringByID(7795U), (ushort) byte.MaxValue);
              return;
            }
            this.PopStr.ClearString();
            this.PopStr.IntToFormat((long) this.DM.beCaptured.Ransom);
            this.PopStr.AppendFormat(this.DM.mStringTable.GetStringByID(7778U));
            GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, DataManager.Instance.mStringTable.GetStringByID(7769U), this.PopStr.ToString(), 1);
            return;
          case 8:
            if (this.DM.beCaptured.StartActionTime + (long) this.DM.beCaptured.TotalTime - this.DM.ServerTime <= 0L)
            {
              if (!GUIManager.Instance.ShowUILock(EUILock.LordInfo))
                return;
              MessagePacket messagePacket = new MessagePacket((ushort) 1024);
              messagePacket.Protocol = Protocol._MSG_REQUEST_LORD_REVIVE;
              messagePacket.AddSeqId();
              messagePacket.Send();
              this.NextActionTime = 0.0f;
              return;
            }
            GUIManager.Instance.UseOrSpend((ushort) 1117, this.DM.mStringTable.GetStringByID(7785U), (ushort) 0, (ushort) 0, (ushort) 0, maxcount: (ushort) 0);
            return;
          case 9:
            UIFormationSelect.ArmyCoordIndexCache = this.DM.RoleAttr.NowArmyCoordIndex;
            this.door.OpenMenu(EGUIWindow.UI_FormationSelect);
            return;
          case 10:
            if (this.DM.beCaptured.StartActionTime + (long) this.DM.beCaptured.TotalTime - this.DM.ServerTime >= 108000L)
            {
              GUIManager.Instance.ShowUILock(EUILock.LordInfo);
              MessagePacket messagePacket = new MessagePacket((ushort) 1024);
              messagePacket.Protocol = Protocol._MSG_REQUEST_SUICIDENUM_BY_POWER_BOARD;
              messagePacket.AddSeqId();
              messagePacket.Add(this.DM.RoleAttr.Power);
              messagePacket.Send();
              return;
            }
            GUIManager.Instance.MsgStr.ClearString();
            GUIManager.Instance.MsgStr.IntToFormat(24L);
            GUIManager.Instance.MsgStr.AppendFormat(this.DM.mStringTable.GetStringByID(15001U));
            GUIManager.Instance.AddHUDMessage(GUIManager.Instance.MsgStr.ToString(), (ushort) byte.MaxValue);
            return;
          default:
            return;
        }
      case 3:
        switch (sender.m_BtnID2)
        {
          case 7:
            if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 15, (ushort) 0).Level < (byte) 17)
              return;
            break;
          case 8:
            if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 15, (ushort) 0).Level < (byte) 25)
              return;
            break;
        }
        if (this.OpenKind != EUILordInfoLayout.LordSelf)
          break;
        UILordEquip.waitForReturn = eUI_LordEquipReturnKind.None;
        this.door.OpenMenu(EGUIWindow.UI_LordEquip, arg2: sender.m_BtnID2);
        break;
      case 4:
        this.door.OpenMenu(EGUIWindow.UI_LordEquipSetSelect);
        break;
      case 5:
        switch (sender.m_BtnID2)
        {
          case 1:
            this.DM.Letter_ReplyName = this.DM.mLordProfile.PlayerName.ToString();
            this.door.OpenMenu(EGUIWindow.UI_LetterEditor, 2);
            return;
          case 2:
            if (this.DM.FindBlackList(this.DM.mLordProfile.PlayerName))
              this.DM.RemoveBlackList(this.DM.mLordProfile.PlayerName);
            else
              this.DM.AddBlackList(this.DM.mLordProfile.PlayerName, this.DM.mLordProfile.Head);
            this.SetPopUp(false);
            return;
          case 3:
            this.DM.SendAllinceInvite(this.DM.mLordProfile.PlayerName.ToString());
            this.SetPopUp(false);
            return;
          case 4:
            if (!GUIManager.Instance.CanResourceTransport() || !(bool) (UnityEngine.Object) this.door)
              return;
            UILordInfo.OpenTransport = true;
            DataManager.Instance.SendAllyPoint(this.DM.mLordProfile.PlayerName.ToString());
            return;
          case 5:
            if (!this.door.m_GroundInfo.ReinforceCheck() || !(bool) (UnityEngine.Object) this.door)
              return;
            DataManager.Instance.ReinforceCheckType = eReinforceCheck.OpenReinforce_NoLoc;
            DataManager.Instance.m_InForceName = this.DM.mLordProfile.PlayerName.ToString();
            DataManager.Instance.SendAllyInforceInfo(this.DM.mLordProfile.PlayerName.ToString());
            return;
          case 6:
            byte btnType = 0;
            if ((DataManager.MapDataController.IsKing() || DataManager.MapDataController.IsKingdomChief()) && (int) DataManager.MapDataController.kingdomData.kingdomID == (int) this.DM.mLordProfile.KindomID)
              ++btnType;
            if ((DataManager.MapDataController.IsWorldKing() || DataManager.MapDataController.IsWorldChief()) && this.DM.mLordProfile.WorldTitle != (ushort) 1)
              btnType += (byte) 2;
            if ((DataManager.MapDataController.IsNobilityKing() || DataManager.MapDataController.IsNobilityChief()) && ActivityManager.Instance.CheckCanonizationNoility(this.DM.mLordProfile.KindomID) && this.DM.mLordProfile.NobilityTitle != (ushort) 1)
              btnType += (byte) 4;
            switch (btnType)
            {
              case 1:
                TitleManager.Instance.OpenTitleSet(this.DM.mLordProfile.PlayerName);
                return;
              case 2:
                TitleManager.Instance.OpenTitleListW(this.DM.mLordProfile.PlayerName);
                return;
              case 3:
              case 5:
              case 6:
              case 7:
                GUIManager.Instance.OpenCanonizedPanel(this.DM.mLordProfile.PlayerName, (byte) 1, (int) btnType);
                return;
              case 4:
                TitleManager.Instance.OpenNobilityTitleSet(this.DM.mLordProfile.PlayerName);
                return;
              default:
                return;
            }
          case 7:
            if (!this.door.m_GroundInfo.CheckMarchEventDataCount())
              return;
            AmbushManager.Instance.SendAllyAmbushInfo(this.DM.mLordProfile.PlayerName.ToString());
            return;
          default:
            return;
        }
      case 9:
        switch (sender.m_BtnID2)
        {
          case 1:
            GUIManager.Instance.OpenItemKindFilterUI((ushort) 10, (byte) 30, (byte) 0);
            return;
          case 2:
            GUIManager.Instance.OpenItemKindFilterUI((ushort) 10, (byte) 33, (byte) 0);
            return;
          default:
            return;
        }
    }
  }

  public void OnLEButtonClick(global::UILEBtn sender)
  {
    if (sender.m_BtnID1 != 3 || this.OpenKind != EUILordInfoLayout.LordSelf)
      return;
    UILordEquip.waitForReturn = eUI_LordEquipReturnKind.None;
    this.door.OpenMenu(EGUIWindow.UI_LordEquip, arg2: sender.m_BtnID2);
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    this.door.CloseMenu();
    this.door.m_WindowStack.Add(new GUIWindowStackData()
    {
      bCameraMode = true,
      m_eWindow = EGUIWindow.UI_LordInfo,
      m_Arg1 = 1,
      m_Arg2 = 0
    });
    this.DM.ShowLordProfile(this.DM.beCaptured.name.ToString());
  }

  private void AllianceClick()
  {
    switch (this.OpenKind)
    {
      case EUILordInfoLayout.LordSelf:
      case EUILordInfoLayout.RecordInfo:
        this.door.AllianceOnClick();
        break;
      case EUILordInfoLayout.LordOther:
      case EUILordInfoLayout.RecordInfoOther:
        if (this.DM.mLordProfile.AlliID == 0U)
          break;
        if (this.isSameAlli)
        {
          if (this.DM.CheckPrizeFlag((byte) 9))
          {
            GUIManager.Instance.OpenSendGiftUI(this.DM.mLordProfile.AllianceTag, this.DM.mLordProfile.PlayerName);
            break;
          }
          this.door.AllianceOnClick();
          break;
        }
        this.DM.AllianceView.Id = this.DM.mLordProfile.AlliID;
        this.door.OpenMenu(EGUIWindow.UIAlliance_publicinfo, 5);
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2) => this.UpdateInfo(arg1, arg2);

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Refresh_ChangeLord:
      case NetworkNews.Refresh_VIP:
label_13:
        switch (this.OpenKind)
        {
          case EUILordInfoLayout.LordSelf:
          case EUILordInfoLayout.RecordInfo:
          case EUILordInfoLayout.EnhanceInfo:
            this.UpdateInfo();
            return;
          case EUILordInfoLayout.LordOther:
            return;
          case EUILordInfoLayout.RecordInfoOther:
            return;
          default:
            return;
        }
      case NetworkNews.Refresh_BuffList:
        if (this.OpenKind != EUILordInfoLayout.EnhanceInfo)
          break;
        this.UpdateInfo();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
      default:
        switch (networkNews)
        {
          case NetworkNews.Login:
            LordEquipData.Instance().LoadLordEquip();
            switch (this.OpenKind)
            {
              case EUILordInfoLayout.LordSelf:
              case EUILordInfoLayout.EnhanceInfo:
                this.UpdateInfo();
                return;
              default:
                return;
            }
          case NetworkNews.Refresh_Asset:
            if (meg[2] != (byte) 2 || (int) GameConstants.ConvertBytesToUInt(meg, 3) != (int) this.sHero.HeroKey)
              return;
            this.Create3DObjects();
            return;
          case NetworkNews.Refresh_Attr:
            goto label_13;
          default:
            if (networkNews != NetworkNews.Refresh_Building && networkNews != NetworkNews.Refresh_Technology)
              return;
            switch (this.OpenKind)
            {
              case EUILordInfoLayout.RecordInfo:
              case EUILordInfoLayout.EnhanceInfo:
                this.UpdateInfo();
                return;
              case EUILordInfoLayout.RecordInfoOther:
                return;
              default:
                return;
            }
        }
    }
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (bOnSecond)
    {
      if (this.OpenKind == EUILordInfoLayout.EnhanceInfo && this.AGS_ScrollPanel.GetTopIdx() < this.lastUpdateIdx && this.scrollPanelInit)
        this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeights, 515f, false);
      if (this.OpenKind == EUILordInfoLayout.LordSelf)
      {
        if (this.DM.beCaptured.nowCaptureStat != LoadCaptureState.None)
        {
          RectTransform component1 = ((Transform) this.CaptureBar).GetChild(2).GetComponent<RectTransform>();
          long sec = this.DM.beCaptured.StartActionTime + (long) this.DM.beCaptured.TotalTime - this.DM.ServerTime;
          if (sec <= 0L)
          {
            sec = 0L;
            if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Dead && !((Transform) this.CaptureBar).GetChild(5).gameObject.activeInHierarchy && !this.freeRes)
            {
              this.UpdateInfo_MyLord();
              this.freeRes = true;
            }
          }
          else
            this.freeRes = false;
          if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Captured)
          {
            RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0);
            switch (this.DM.beCaptured.prisonerStat)
            {
              case PrisonerState.WaitForRelease:
              case PrisonerState.Poisoned:
                float num1 = Mathf.Clamp01(1f - (float) sec / (float) this.DM.beCaptured.TotalTime);
                component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num1 * 305f);
                this.AGS_Form.GetChild(17).GetChild(6).gameObject.SetActive(false);
                if (this.DM.beCaptured.prisonerStat == PrisonerState.Poisoned)
                  this.poisonUpdated = false;
                this.AGS_Form.GetChild(17).GetChild(6).gameObject.SetActive(false);
                break;
              case PrisonerState.WaitForExecute:
                if (buildData.Level >= (byte) 17)
                {
                  GameObject gameObject = this.AGS_Form.GetChild(17).GetChild(6).gameObject;
                  gameObject.SetActive(true);
                  Image component2 = gameObject.GetComponent<Image>();
                  if (sec >= 108000L)
                    ((Graphic) component2).color = Color.white;
                  else
                    ((Graphic) component2).color = Color.gray;
                }
                else
                  this.AGS_Form.GetChild(17).GetChild(6).gameObject.SetActive(false);
                if (sec > 21600L)
                {
                  sec -= 21600L;
                  float num2 = Mathf.Clamp01(1f - (float) sec / (float) (this.DM.beCaptured.TotalTime - 21600U));
                  component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num2 * 305f);
                  this.executeUpdated = false;
                  break;
                }
                float num3 = Mathf.Clamp01(1f - (float) sec / 21600f);
                component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num3 * 305f);
                this.AGS_Form.GetChild(17).GetChild(6).gameObject.SetActive(false);
                if (!this.executeUpdated)
                {
                  this.UpdateInfo_MyLord();
                  this.executeUpdated = true;
                  break;
                }
                break;
            }
          }
          else
          {
            float num = Mathf.Clamp01(1f - (float) sec / (float) this.DM.beCaptured.TotalTime);
            component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num * 305f);
            this.AGS_Form.GetChild(17).GetChild(6).gameObject.SetActive(false);
          }
          UIText component3 = ((Transform) this.CaptureBar).GetChild(4).GetComponent<UIText>();
          this.countDown.ClearString();
          GameConstants.GetTimeString(this.countDown, (uint) sec, true, true);
          component3.text = this.countDown.ToString();
          component3.SetAllDirty();
          component3.cachedTextGenerator.Invalidate();
          ((Graphic) ((Transform) this.CaptureBar).GetChild(3).GetComponent<UIText>()).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 300f - component3.preferredWidth);
        }
        this.AGS_Form.GetChild(6).GetChild(2).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, Mathf.Clamp01((float) this.DM.RoleAttr.MonsterPoint / (float) this.DM.GetMaxMonsterPoint()) * 261f);
        UIText component = this.AGS_Form.GetChild(6).GetChild(7).GetComponent<UIText>();
        this.EnStr.ClearString();
        this.EnStr.IntToFormat((long) this.DM.RoleAttr.MonsterPoint, bNumber: true);
        this.EnStr.IntToFormat((long) this.DM.GetMaxMonsterPoint(), bNumber: true);
        if (!GUIManager.Instance.IsArabic)
          this.EnStr.AppendFormat("{0} / {1}");
        else
          this.EnStr.AppendFormat("{1} / {0}");
        component.text = this.EnStr.ToString();
        component.SetAllDirty();
        component.cachedTextGenerator.Invalidate();
      }
      if (!this.isMonsterOpen)
        return;
      UIText component4 = ((Transform) this.HintPanel).GetChild(1).GetComponent<UIText>();
      this.hintString.ClearString();
      this.hintString.Append(this.DM.mStringTable.GetStringByID(880U));
      this.hintString.Append("\n");
      if (this.DM.GetMaxMonsterPoint() > this.DM.RoleAttr.MonsterPoint)
      {
        if (this.MonsterTime == -1L)
          this.MonsterTime = (long) ((double) (this.DM.GetMaxMonsterPoint() - this.DM.RoleAttr.MonsterPoint) * ((double) this.DM.RoleAttr.MonsterPointRecoverFrequency / 1000.0));
        else
          --this.MonsterTime;
        int x1 = (int) this.MonsterTime / 3600;
        int x2 = (int) this.MonsterTime % 3600 / 60;
        int x3 = (int) this.MonsterTime % 60;
        this.hintString.IntToFormat((long) x1, 2);
        this.hintString.IntToFormat((long) x2, 2);
        this.hintString.IntToFormat((long) x3, 2);
        this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(881U));
      }
      else
        this.hintString.Append(this.DM.mStringTable.GetStringByID(882U));
      component4.text = this.hintString.ToString();
      component4.SetAllDirty();
      component4.cachedTextGenerator.Invalidate();
    }
    else
    {
      if (this.DM.beCaptured.nowCaptureStat != LoadCaptureState.Returning)
        return;
      ((Transform) this.CaptureBar).GetChild(2).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, Mathf.Clamp01(1f - ((float) (this.DM.beCaptured.StartActionTime + (long) this.DM.beCaptured.TotalTime) - (float) NetworkManager.ServerTime) / (float) this.DM.beCaptured.TotalTime) * 305f);
    }
  }

  private void SetFormLayout(EUILordInfoLayout layout)
  {
    this.OpenKind = layout;
    RectTransform[] rectTransformArray1 = new RectTransform[8];
    for (int index = 0; index < 8; ++index)
      rectTransformArray1[index] = this.AGS_Form.GetChild(5).GetChild(index).GetComponent<RectTransform>();
    RectTransform[] rectTransformArray2 = new RectTransform[8];
    for (int index = 0; index < 8; ++index)
      rectTransformArray2[index] = this.AGS_Form.GetChild(5).GetChild(index + 8).GetComponent<RectTransform>();
    ((Component) this.PopupPanel).gameObject.SetActive(false);
    ((Component) this.HintPanel).gameObject.SetActive(false);
    ((Component) this.JailerPanel).gameObject.SetActive(false);
    ((Component) this.RescurePanel).gameObject.SetActive(false);
    ((Component) this.CaptureBar).gameObject.SetActive(false);
    this.AGS_Form.GetChild(8).gameObject.SetActive(false);
    switch (layout)
    {
      case EUILordInfoLayout.LordSelf:
        ((Component) this.headInfoPanel).gameObject.SetActive(true);
        ((Component) this.SideBtnPanel).gameObject.SetActive(true);
        ((Component) this.ItemPanel).gameObject.SetActive(true);
        ((Component) this.ScrollPanel).gameObject.SetActive(false);
        ((Component) this.TitlePanel).gameObject.SetActive(false);
        this.AGS_HeroBadge.gameObject.SetActive(false);
        ((Component) this.HeroRank).gameObject.SetActive(false);
        this.Hero_Pos.gameObject.SetActive(false);
        this.AGS_GuildRank.gameObject.SetActive(false);
        this.AGS_Form.GetChild(20).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(7).gameObject.SetActive(true);
        this.AGS_Form.GetChild(7).gameObject.SetActive(true);
        this.AGS_Form.GetChild(6).gameObject.SetActive(true);
        this.AGS_bgPanel.SetSpriteIndex(0);
        this.AGS_GuildLogo.SetSpriteIndex(0);
        this.AGS_btn_BuffInfo.SetSpriteIndex(0);
        int[,] numArray1 = new int[8, 2]
        {
          {
            0,
            52
          },
          {
            0,
            -60
          },
          {
            62,
            -172
          },
          {
            62,
            164
          },
          {
            210,
            164
          },
          {
            272,
            52
          },
          {
            272,
            -60
          },
          {
            210,
            -172
          }
        };
        int[,] numArray2 = new int[8, 2]
        {
          {
            15,
            37
          },
          {
            15,
            -75
          },
          {
            77,
            -187
          },
          {
            77,
            149
          },
          {
            225,
            149
          },
          {
            287,
            37
          },
          {
            287,
            -75
          },
          {
            225,
            -187
          }
        };
        for (int index = 0; index < 8; ++index)
        {
          Vector2 vector2 = new Vector2((float) numArray1[index, 0], (float) numArray1[index, 1]);
          rectTransformArray1[index].anchoredPosition = vector2;
          vector2 = new Vector2((float) numArray2[index, 0], (float) numArray2[index, 1]) - new Vector2(-52.5f, 52.5f);
          rectTransformArray2[index].anchoredPosition = vector2;
          this.UILEBtn[index].anchoredPosition = vector2;
        }
        this.AGS_Form.GetChild(7).GetComponent<RectTransform>().anchoredPosition = !GUIManager.Instance.IsArabic ? new Vector2(-318f, 154f) : new Vector2(-259f, 154f);
        this.TitlePanel.anchoredPosition = new Vector2(-150f, 0.0f);
        this.Hero_PosRT.anchoredPosition = new Vector2(-150f, -280f);
        this.LightRT.anchoredPosition = new Vector2(-150f, -280f);
        break;
      case EUILordInfoLayout.LordOther:
        ((Component) this.headInfoPanel).gameObject.SetActive(true);
        ((Component) this.SideBtnPanel).gameObject.SetActive(false);
        ((Component) this.ItemPanel).gameObject.SetActive(true);
        ((Component) this.ScrollPanel).gameObject.SetActive(false);
        ((Component) this.TitlePanel).gameObject.SetActive(false);
        ((Component) this.HeroRank).gameObject.SetActive(false);
        this.AGS_HeroBadge.gameObject.SetActive(false);
        this.Hero_Pos.gameObject.SetActive(false);
        this.AGS_GuildRank.gameObject.SetActive(false);
        this.AGS_Form.GetChild(20).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(3).gameObject.SetActive(false);
        this.AGS_Form.GetChild(2).GetChild(7).gameObject.SetActive(false);
        this.AGS_Form.GetChild(6).gameObject.SetActive(false);
        this.AGS_Form.GetChild(7).gameObject.SetActive(false);
        this.AGS_Form.GetChild(12).GetChild(0).gameObject.SetActive(true);
        this.AGS_Form.GetChild(12).GetChild(1).gameObject.SetActive(false);
        this.AGS_bgPanel.SetSpriteIndex(1);
        this.AGS_GuildLogo.SetSpriteIndex(0);
        this.AGS_btn_BuffInfo.SetSpriteIndex(0);
        int[,] numArray3 = new int[8, 2]
        {
          {
            -388,
            52
          },
          {
            -388,
            -60
          },
          {
            -326,
            -172
          },
          {
            -326,
            164
          },
          {
            194,
            164
          },
          {
            256,
            52
          },
          {
            256,
            -60
          },
          {
            194,
            -172
          }
        };
        int[,] numArray4 = new int[8, 2]
        {
          {
            -373,
            37
          },
          {
            -373,
            -75
          },
          {
            -311,
            -187
          },
          {
            -311,
            149
          },
          {
            209,
            149
          },
          {
            277,
            37
          },
          {
            277,
            -75
          },
          {
            209,
            -187
          }
        };
        for (int index = 0; index < 8; ++index)
        {
          Vector2 vector2 = new Vector2((float) numArray3[index, 0], (float) numArray3[index, 1]);
          rectTransformArray1[index].anchoredPosition = vector2;
          vector2 = new Vector2((float) numArray4[index, 0], (float) numArray4[index, 1]) - new Vector2(-52.5f, 52.5f);
          rectTransformArray2[index].anchoredPosition = vector2;
          this.UILEBtn[index].anchoredPosition = vector2;
        }
        ((MaskableGraphic) this.HeroRank).material = GUIManager.Instance.GetFrameMaterial();
        this.AGS_Form.GetChild(7).GetComponent<RectTransform>().anchoredPosition = !GUIManager.Instance.IsArabic ? new Vector2(-189f, 160f) : new Vector2(-130f, 160f);
        this.TitlePanel.anchoredPosition = new Vector2(0.0f, 0.0f);
        this.Hero_PosRT.anchoredPosition = new Vector2(0.0f, -280f);
        this.LightRT.anchoredPosition = new Vector2(0.0f, -280f);
        break;
      case EUILordInfoLayout.RecordInfo:
        ((Component) this.headInfoPanel).gameObject.SetActive(true);
        ((Component) this.SideBtnPanel).gameObject.SetActive(false);
        ((Component) this.ItemPanel).gameObject.SetActive(false);
        ((Component) this.ScrollPanel).gameObject.SetActive(true);
        ((Component) this.TitlePanel).gameObject.SetActive(false);
        this.Hero_Pos.gameObject.SetActive(false);
        ((Component) this.HeroRank).gameObject.SetActive(false);
        this.AGS_HeroBadge.gameObject.SetActive(false);
        this.AGS_Form.GetChild(20).gameObject.SetActive(false);
        this.AGS_Form.GetChild(6).gameObject.SetActive(false);
        this.AGS_Form.GetChild(7).gameObject.SetActive(false);
        this.AGS_bgPanel.SetSpriteIndex(0);
        this.AGS_GuildLogo.SetSpriteIndex(0);
        this.AGS_btn_BuffInfo.SetSpriteIndex(1);
        this.AGS_ScrollPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-363f, 119f);
        ((Transform) this.ScrollPanel).GetChild(0).gameObject.SetActive(false);
        break;
      case EUILordInfoLayout.RecordInfoOther:
        ((Component) this.headInfoPanel).gameObject.SetActive(true);
        ((Component) this.SideBtnPanel).gameObject.SetActive(false);
        ((Component) this.ItemPanel).gameObject.SetActive(false);
        ((Component) this.ScrollPanel).gameObject.SetActive(true);
        ((Component) this.TitlePanel).gameObject.SetActive(false);
        this.Hero_Pos.gameObject.SetActive(false);
        ((Component) this.HeroRank).gameObject.SetActive(false);
        this.AGS_HeroBadge.gameObject.SetActive(false);
        this.AGS_Form.GetChild(20).gameObject.SetActive(false);
        this.AGS_Form.GetChild(6).gameObject.SetActive(false);
        this.AGS_Form.GetChild(7).gameObject.SetActive(false);
        this.AGS_bgPanel.SetSpriteIndex(1);
        this.AGS_btn_BuffInfo.SetSpriteIndex(1);
        this.AGS_ScrollPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-363f, 119f);
        this.Destory3DObject();
        break;
      case EUILordInfoLayout.EnhanceInfo:
        ((Component) this.headInfoPanel).gameObject.SetActive(false);
        ((Component) this.SideBtnPanel).gameObject.SetActive(false);
        ((Component) this.ItemPanel).gameObject.SetActive(false);
        ((Component) this.ScrollPanel).gameObject.SetActive(true);
        ((Component) this.TitlePanel).gameObject.SetActive(false);
        ((Component) this.HeroRank).gameObject.SetActive(false);
        this.AGS_HeroBadge.gameObject.SetActive(false);
        this.Hero_Pos.gameObject.SetActive(false);
        this.AGS_Form.GetChild(20).gameObject.SetActive(true);
        this.AGS_Form.GetChild(7).gameObject.SetActive(false);
        this.AGS_Form.GetChild(6).gameObject.SetActive(false);
        this.AGS_bgPanel.SetSpriteIndex(2);
        this.AGS_GuildLogo.SetSpriteIndex(0);
        this.AGS_ScrollPanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(-342f, 153f);
        break;
    }
  }

  public void UpdateInfo(int arg1 = 0, int arg2 = 0)
  {
    if (arg1 == 3)
    {
      switch (this.OpenKind)
      {
        case EUILordInfoLayout.LordSelf:
          this.SetFormLayout(EUILordInfoLayout.RecordInfo);
          break;
        case EUILordInfoLayout.LordOther:
          this.SetFormLayout(EUILordInfoLayout.RecordInfoOther);
          break;
      }
      this.UpdateInfo_Record();
    }
    else
    {
      switch (this.OpenKind)
      {
        case EUILordInfoLayout.LordSelf:
          this.UpdateInfo_MyLord();
          break;
        case EUILordInfoLayout.LordOther:
          if (arg1 == 0)
            break;
          this.UpdateInfo_Other();
          break;
        case EUILordInfoLayout.RecordInfo:
        case EUILordInfoLayout.RecordInfoOther:
          this.UpdateInfo_Record();
          break;
        case EUILordInfoLayout.EnhanceInfo:
          this.UpdateInfo_Enhance();
          break;
      }
    }
  }

  private void UpdateInfo_MyLord()
  {
    if (this.DM.beCaptured.nowCaptureStat != LoadCaptureState.Captured && (UnityEngine.Object) GUIManager.Instance.FindMenu(EGUIWindow.UI_JailMoney) != (UnityEngine.Object) null)
      GUIManager.Instance.CloseMenu(EGUIWindow.UI_JailMoney);
    this.UpdateInfo_MyHeader();
    this.AGS_Form.GetChild(3).GetChild(0).GetChild(0).gameObject.SetActive(this.DM.RoleTalentPoint > (ushort) 0);
    if ((int) this.DM.HeroTable.GetRecordByKey(this.DM.RoleAttr.Head).HeroKey != (int) this.sHero.HeroKey)
    {
      this.sHero = this.DM.HeroTable.GetRecordByKey(this.DM.RoleAttr.Head);
      this.Create3DObjects();
    }
    else
    {
      this.Hero_Pos.gameObject.SetActive(true);
      this.SetModelDefaultAction();
      if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Captured)
      {
        if (this.LoadingStep == UILordInfo.eModelLoadingStep.HeroReady)
        {
          CString Name = StringManager.Instance.StaticString1024();
          Name.Append("Role/cage");
          this.bundle = AssetManager.GetAssetBundle(Name, out this.AssetKey1);
          this.bundleRequest = this.bundle.LoadAsync("m", typeof (GameObject));
          this.LoadingStep = UILordInfo.eModelLoadingStep.WaitforCage;
        }
      }
      else if ((UnityEngine.Object) this.Holder2 != (UnityEngine.Object) null)
        this.Destory3DObject(true);
    }
    this.AGS_Form.GetChild(8).gameObject.SetActive(false);
    switch (this.DM.beCaptured.nowCaptureStat)
    {
      case LoadCaptureState.None:
        RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0);
        if (buildData.Level >= (byte) 20)
          this.AGS_Form.GetChild(8).gameObject.SetActive(true);
        if (buildData.Level >= (byte) 17)
        {
          this.AGS_Form.GetChild(3).GetChild(3).gameObject.SetActive(true);
          for (int index = 0; index < 3; ++index)
            this.AGS_Form.GetChild(3).GetChild(index).GetComponent<RectTransform>().anchoredPosition = new Vector2(-359f, 51.5f - (float) (index * 99));
        }
        else
        {
          this.AGS_Form.GetChild(3).GetChild(3).gameObject.SetActive(false);
          for (int index = 0; index < 3; ++index)
            this.AGS_Form.GetChild(3).GetChild(index).GetComponent<RectTransform>().anchoredPosition = new Vector2(-359f, 9.5f - (float) (index * 118));
        }
        ((Component) this.ItemPanel).gameObject.SetActive(true);
        ((Component) this.JailerPanel).gameObject.SetActive(false);
        ((Component) this.RescurePanel).gameObject.SetActive(false);
        ((Component) this.CaptureBar).gameObject.SetActive(false);
        this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(true);
        this.AGS_Form.GetChild(3).GetChild(2).gameObject.SetActive(true);
        this.Hero_PosRT.anchoredPosition = new Vector2(-150f, -280f);
        ((Transform) this.Hero_PosRT).localEulerAngles = Vector3.zero;
        this.AGS_Form.GetChild(12).GetChild(0).gameObject.SetActive(true);
        this.AGS_Form.GetChild(12).GetChild(1).gameObject.SetActive(false);
        for (int index = 0; index < 8; ++index)
        {
          if (LordEquipData.RoleEquipSerial[index] != 0U)
          {
            this.AGS_Form.GetChild(5).GetChild(index + 8).gameObject.SetActive(false);
            ((Component) this.UILEBtn[index]).gameObject.SetActive(true);
            GUIManager.Instance.ChangeLordEquipImg(((Component) this.UILEBtn[index]).transform, LordEquipData.RoleEquip[index]);
            if (DataManager.Instance.EquipTable.GetRecordByKey(LordEquipData.RoleEquip[index].ItemID).TimedType != (byte) 0)
              ((Component) this.UILEBtn[index]).transform.GetComponent<global::UILEBtn>().SetCountdown(LordEquipData.getEquipTime(LordEquipData.RoleEquipSerial[index]), true);
          }
          else
          {
            this.AGS_Form.GetChild(5).GetChild(index + 8).gameObject.SetActive(true);
            ((Component) this.UILEBtn[index]).gameObject.SetActive(false);
            int num = LordEquipData.CheckHaveEquipKind((byte) (index + 21));
            if (num > 0)
            {
              this.AGS_Form.GetChild(5).GetChild(index + 8).GetChild(0).gameObject.SetActive(num == 1);
              this.AGS_Form.GetChild(5).GetChild(index + 8).GetChild(1).gameObject.SetActive(true);
              this.AGS_Form.GetChild(5).GetChild(index + 8).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(2 - num);
            }
            else
            {
              this.AGS_Form.GetChild(5).GetChild(index + 8).GetChild(0).gameObject.SetActive(false);
              this.AGS_Form.GetChild(5).GetChild(index + 8).GetChild(1).gameObject.SetActive(false);
            }
          }
        }
        int num1 = LordEquipData.CheckHaveEquipKind((byte) 26);
        buildData = GUIManager.Instance.BuildingData.GetBuildData((ushort) 15, (ushort) 0);
        if (buildData.Level >= (byte) 17 && LordEquipData.RoleEquipSerial[6] == 0U)
        {
          this.AGS_Form.GetChild(5).GetChild(24).gameObject.SetActive(buildData.Level < (byte) 17);
          this.AGS_Form.GetChild(5).GetChild(14).GetChild(0).gameObject.SetActive(num1 == 1);
          this.AGS_Form.GetChild(5).GetChild(14).GetChild(1).gameObject.SetActive(num1 > 0);
          this.AGS_Form.GetChild(5).GetChild(14).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(2 - num1);
        }
        else
        {
          this.AGS_Form.GetChild(5).GetChild(24).gameObject.SetActive(buildData.Level < (byte) 17);
          this.AGS_Form.GetChild(5).GetChild(14).GetChild(0).gameObject.SetActive(false);
          this.AGS_Form.GetChild(5).GetChild(14).GetChild(1).gameObject.SetActive(false);
        }
        if (buildData.Level >= (byte) 25 && LordEquipData.RoleEquipSerial[7] == 0U)
        {
          this.AGS_Form.GetChild(5).GetChild(25).gameObject.SetActive(buildData.Level < (byte) 25);
          this.AGS_Form.GetChild(5).GetChild(15).GetChild(0).gameObject.SetActive(num1 == 1);
          this.AGS_Form.GetChild(5).GetChild(15).GetChild(1).gameObject.SetActive(num1 > 0);
          this.AGS_Form.GetChild(5).GetChild(15).GetChild(1).GetComponent<UISpritesArray>().SetSpriteIndex(2 - num1);
        }
        else
        {
          this.AGS_Form.GetChild(5).GetChild(25).gameObject.SetActive(buildData.Level < (byte) 25);
          this.AGS_Form.GetChild(5).GetChild(15).GetChild(0).gameObject.SetActive(false);
          this.AGS_Form.GetChild(5).GetChild(15).GetChild(1).gameObject.SetActive(false);
        }
        int num2 = 0;
        if (this.DM.RoleAttr.KingdomTitle > (ushort) 1)
        {
          TitleData recordByKey = this.DM.TitleData.GetRecordByKey(this.DM.RoleAttr.KingdomTitle);
          ((Component) this.TitlePanel).gameObject.SetActive(true);
          UIText component1 = ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).GetComponent<UIText>();
          RectTransform component2 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<RectTransform>();
          component1.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID);
          component1.SetAllDirty();
          component1.cachedTextGenerator.Invalidate();
          component1.cachedTextGeneratorForLayout.Invalidate();
          float num3 = (float) ((double) component1.preferredWidth / 2.0 + 35.0);
          if ((double) num3 > 140.0)
            num3 = 140f;
          component2.anchoredPosition = new Vector2(-num3, component2.anchoredPosition.y);
          Image component3 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<Image>();
          ((MaskableGraphic) component3).material = GUIManager.Instance.GetTitleMaterial();
          component3.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID);
          ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 21;
          ++num2;
        }
        if (this.DM.RoleAttr.NobilityTitle > (ushort) 1)
        {
          TitleData recordByKey = this.DM.TitleDataF.GetRecordByKey(this.DM.RoleAttr.NobilityTitle);
          ((Component) this.TitlePanel).gameObject.SetActive(true);
          UIText component4 = ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).GetComponent<UIText>();
          RectTransform component5 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<RectTransform>();
          component4.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID);
          component4.SetAllDirty();
          component4.cachedTextGenerator.Invalidate();
          component4.cachedTextGeneratorForLayout.Invalidate();
          float num4 = (float) ((double) component4.preferredWidth / 2.0 + 35.0);
          if ((double) num4 > 140.0)
            num4 = 140f;
          component5.anchoredPosition = new Vector2(-num4, component5.anchoredPosition.y);
          Image component6 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<Image>();
          ((MaskableGraphic) component6).material = GUIManager.Instance.GetTitleMaterial();
          component6.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.NobilityTitle);
          ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 22;
          ++num2;
        }
        if (this.DM.RoleAttr.WorldTitle_Personal > (ushort) 1)
        {
          TitleData recordByKey = this.DM.TitleDataW.GetRecordByKey(this.DM.RoleAttr.WorldTitle_Personal);
          ((Component) this.TitlePanel).gameObject.SetActive(true);
          UIText component7 = ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).GetComponent<UIText>();
          RectTransform component8 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<RectTransform>();
          component7.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID);
          component7.SetAllDirty();
          component7.cachedTextGenerator.Invalidate();
          component7.cachedTextGeneratorForLayout.Invalidate();
          float num5 = (float) ((double) component7.preferredWidth / 2.0 + 35.0);
          if ((double) num5 > 140.0)
            num5 = 140f;
          component8.anchoredPosition = new Vector2(-num5, component8.anchoredPosition.y);
          Image component9 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<Image>();
          ((MaskableGraphic) component9).material = GUIManager.Instance.GetTitleMaterial();
          component9.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.WorldTitle);
          ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 23;
          ++num2;
        }
        if (this.DM.RoleAttr.KingdomTitle == (ushort) 1)
        {
          TitleData recordByKey = this.DM.TitleData.GetRecordByKey(this.DM.RoleAttr.KingdomTitle);
          ((Component) this.TitlePanel).gameObject.SetActive(true);
          UIText component10 = ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).GetComponent<UIText>();
          RectTransform component11 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<RectTransform>();
          component10.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID);
          component10.SetAllDirty();
          component10.cachedTextGenerator.Invalidate();
          component10.cachedTextGeneratorForLayout.Invalidate();
          float num6 = (float) ((double) component10.preferredWidth / 2.0 + 35.0);
          if ((double) num6 > 140.0)
            num6 = 140f;
          component11.anchoredPosition = new Vector2(-num6, component11.anchoredPosition.y);
          Image component12 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<Image>();
          ((MaskableGraphic) component12).material = GUIManager.Instance.GetTitleMaterial();
          component12.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID);
          ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 21;
          ++num2;
        }
        if (this.DM.RoleAttr.NobilityTitle == (ushort) 1)
        {
          TitleData recordByKey = this.DM.TitleDataF.GetRecordByKey(this.DM.RoleAttr.NobilityTitle);
          ((Component) this.TitlePanel).gameObject.SetActive(true);
          UIText component13 = ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).GetComponent<UIText>();
          RectTransform component14 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<RectTransform>();
          component13.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID);
          component13.SetAllDirty();
          component13.cachedTextGenerator.Invalidate();
          component13.cachedTextGeneratorForLayout.Invalidate();
          float num7 = (float) ((double) component13.preferredWidth / 2.0 + 35.0);
          if ((double) num7 > 140.0)
            num7 = 140f;
          component14.anchoredPosition = new Vector2(-num7, component14.anchoredPosition.y);
          Image component15 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<Image>();
          ((MaskableGraphic) component15).material = GUIManager.Instance.GetTitleMaterial();
          component15.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.NobilityTitle);
          ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 22;
          ++num2;
        }
        if (this.DM.RoleAttr.WorldTitle_Personal == (ushort) 1)
        {
          TitleData recordByKey = this.DM.TitleDataW.GetRecordByKey(this.DM.RoleAttr.WorldTitle_Personal);
          ((Component) this.TitlePanel).gameObject.SetActive(true);
          UIText component16 = ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).GetComponent<UIText>();
          RectTransform component17 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<RectTransform>();
          component16.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID);
          component16.SetAllDirty();
          component16.cachedTextGenerator.Invalidate();
          component16.cachedTextGeneratorForLayout.Invalidate();
          float num8 = (float) ((double) component16.preferredWidth / 2.0 + 35.0);
          if ((double) num8 > 140.0)
            num8 = 140f;
          component17.anchoredPosition = new Vector2(-num8, component17.anchoredPosition.y);
          Image component18 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<Image>();
          ((MaskableGraphic) component18).material = GUIManager.Instance.GetTitleMaterial();
          component18.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.WorldTitle);
          ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).gameObject.SetActive(true);
          ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 23;
          ++num2;
        }
        if (((Component) this.TitlePanel).gameObject.activeInHierarchy)
        {
          for (int index = num2; index < 3; ++index)
          {
            ((Transform) this.TitlePanel).GetChild(2 + index * 3).gameObject.SetActive(false);
            ((Transform) this.TitlePanel).GetChild(0 + index * 3).gameObject.SetActive(false);
            ((Transform) this.TitlePanel).GetChild(1 + index * 3).gameObject.SetActive(false);
          }
        }
        if (num2 != 0)
          return;
        ((Component) this.TitlePanel).gameObject.SetActive(false);
        return;
      case LoadCaptureState.Captured:
        ((Component) this.ItemPanel).gameObject.SetActive(false);
        ((Component) this.JailerPanel).gameObject.SetActive(true);
        ((Component) this.RescurePanel).gameObject.SetActive(false);
        ((Component) this.CaptureBar).gameObject.SetActive(true);
        ((Component) this.TitlePanel).gameObject.SetActive(false);
        this.CaptureBar.anchoredPosition = new Vector2(0.0f, -21f);
        this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(3).GetChild(2).gameObject.SetActive(false);
        this.Hero_PosRT.anchoredPosition = new Vector2(-150f, -280f);
        ((Transform) this.Hero_PosRT).localEulerAngles = Vector3.zero;
        this.LightRT.anchoredPosition = new Vector2(-150f, -280f);
        this.AGS_Form.GetChild(12).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(12).GetChild(1).gameObject.SetActive(true);
        this.JailerStr[0].ClearString();
        GameConstants.GetNameString(this.JailerStr[0], this.DM.beCaptured.HomeKingdomID, this.DM.beCaptured.name, this.DM.beCaptured.AlliTag);
        UIText component19 = ((Transform) this.JailerPanel).GetChild(6).GetComponent<UIText>();
        component19.text = this.JailerStr[0].ToString();
        component19.SetAllDirty();
        component19.cachedTextGenerator.Invalidate();
        this.JailerStr[1].ClearString();
        GameConstants.GetKingdomXYString(this.JailerStr[1], this.DM.beCaptured.KingdomID, this.DM.beCaptured.MapID);
        UIText component20 = ((Transform) this.JailerPanel).GetChild(7).GetComponent<UIText>();
        component20.text = this.JailerStr[1].ToString();
        component20.SetAllDirty();
        component20.cachedTextGenerator.Invalidate();
        this.JailerStr[2].ClearString();
        UIText component21 = ((Transform) this.JailerPanel).GetChild(12).GetChild(0).GetComponent<UIText>();
        if (this.DM.beCaptured.Bounty > 0U)
        {
          this.JailerStr[2].IntToFormat((long) this.DM.beCaptured.Bounty, bNumber: true);
          this.JailerStr[2].AppendFormat("{0:N}");
          component21.text = this.DM.mStringTable.GetStringByID(7777U);
        }
        else
        {
          this.JailerStr[2].Append(this.DM.mStringTable.GetStringByID(7786U));
          component21.text = this.DM.mStringTable.GetStringByID(7776U);
        }
        UIText component22 = ((Transform) this.JailerPanel).GetChild(10).GetComponent<UIText>();
        component22.text = this.JailerStr[2].ToString();
        component22.SetAllDirty();
        component22.cachedTextGenerator.Invalidate();
        component22.cachedTextGeneratorForLayout.Invalidate();
        RectTransform component23 = ((Transform) this.JailerPanel).GetChild(11).GetComponent<RectTransform>();
        component23.anchoredPosition = new Vector2((float) ((double) ((Graphic) component22).rectTransform.anchoredPosition.x - (double) component22.preferredWidth - 40.0), component23.anchoredPosition.y);
        this.JailerStr[3].ClearString();
        if (this.DM.beCaptured.Ransom > 0U)
        {
          this.JailerStr[3].IntToFormat((long) this.DM.beCaptured.Ransom, bNumber: true);
          this.JailerStr[3].AppendFormat("{0:N}");
          ((Transform) this.JailerPanel).GetChild(18).gameObject.SetActive(true);
          ((Transform) this.JailerPanel).GetChild(14).gameObject.SetActive(true);
          ((Transform) this.JailerPanel).GetChild(15).gameObject.SetActive(true);
          ((Transform) this.JailerPanel).GetChild(17).gameObject.SetActive(true);
          ((Transform) this.JailerPanel).GetChild(16).gameObject.SetActive(true);
        }
        else
        {
          ((Transform) this.JailerPanel).GetChild(18).gameObject.SetActive(false);
          ((Transform) this.JailerPanel).GetChild(14).gameObject.SetActive(false);
          ((Transform) this.JailerPanel).GetChild(15).gameObject.SetActive(false);
          ((Transform) this.JailerPanel).GetChild(17).gameObject.SetActive(false);
          ((Transform) this.JailerPanel).GetChild(16).gameObject.SetActive(false);
        }
        UIText component24 = ((Transform) this.JailerPanel).GetChild(17).GetComponent<UIText>();
        component24.text = this.JailerStr[3].ToString();
        component24.SetAllDirty();
        component24.cachedTextGenerator.Invalidate();
        component24.cachedTextGeneratorForLayout.Invalidate();
        RectTransform component25 = ((Transform) this.JailerPanel).GetChild(16).GetComponent<RectTransform>();
        component25.anchoredPosition = new Vector2((float) ((double) ((Graphic) component24).rectTransform.anchoredPosition.x - (double) component24.preferredWidth - 40.0), component25.anchoredPosition.y);
        GUIManager.Instance.InitianHeroItemImg(((Transform) this.JailerPanel).GetChild(2), eHeroOrItem.Hero, this.DM.beCaptured.head, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
        this.DefaultActionLateUpdate = true;
        break;
      case LoadCaptureState.Returning:
        ((Component) this.ItemPanel).gameObject.SetActive(false);
        ((Component) this.JailerPanel).gameObject.SetActive(false);
        ((Component) this.RescurePanel).gameObject.SetActive(false);
        ((Component) this.CaptureBar).gameObject.SetActive(true);
        this.CaptureBar.anchoredPosition = new Vector2(158f, -338f);
        this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(3).GetChild(2).gameObject.SetActive(false);
        this.Hero_PosRT.anchoredPosition = new Vector2(0.0f, -280f);
        ((Transform) this.Hero_PosRT).localEulerAngles = Vector3.zero;
        this.LightRT.anchoredPosition = new Vector2(0.0f, -280f);
        this.AGS_Form.GetChild(12).GetChild(0).gameObject.SetActive(true);
        this.AGS_Form.GetChild(12).GetChild(1).gameObject.SetActive(false);
        break;
      case LoadCaptureState.Dead:
        ((Component) this.ItemPanel).gameObject.SetActive(false);
        ((Component) this.JailerPanel).gameObject.SetActive(false);
        ((Component) this.RescurePanel).gameObject.SetActive(true);
        ((Component) this.CaptureBar).gameObject.SetActive(true);
        this.CaptureBar.anchoredPosition = new Vector2(80f, -338f);
        this.AGS_Form.GetChild(3).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(3).GetChild(2).gameObject.SetActive(false);
        this.Hero_PosRT.anchoredPosition = new Vector2(0.0f, -100f);
        ((Transform) this.Hero_PosRT).localEulerAngles = new Vector3(320f, 0.0f, 0.0f);
        this.LightRT.anchoredPosition = new Vector2(0.0f, -100f);
        this.AGS_Form.GetChild(12).GetChild(0).gameObject.SetActive(false);
        this.AGS_Form.GetChild(12).GetChild(1).gameObject.SetActive(true);
        this.DefaultActionLateUpdate = true;
        break;
    }
    ((Transform) this.CaptureBar).GetChild(4).gameObject.SetActive(true);
    ((Transform) this.CaptureBar).GetChild(3).gameObject.SetActive(true);
    ((Transform) this.CaptureBar).GetChild(6).gameObject.SetActive(false);
    UISpritesArray component26 = ((Transform) this.CaptureBar).GetChild(2).GetComponent<UISpritesArray>();
    UIText component27 = ((Transform) this.CaptureBar).GetChild(3).GetComponent<UIText>();
    long sec = this.DM.beCaptured.StartActionTime + (long) this.DM.beCaptured.TotalTime - this.DM.ServerTime;
    RectTransform component28 = ((Transform) this.CaptureBar).GetChild(2).GetComponent<RectTransform>();
    switch (this.DM.beCaptured.nowCaptureStat)
    {
      case LoadCaptureState.Captured:
        switch (this.DM.beCaptured.prisonerStat)
        {
          case PrisonerState.WaitForRelease:
            component26.SetSpriteIndex(0);
            ((Transform) this.CaptureBar).GetChild(0).gameObject.SetActive(false);
            component27.text = this.DM.mStringTable.GetStringByID(7768U);
            float num9 = Mathf.Clamp01((float) (1.0 - (double) sec / (double) this.DM.beCaptured.TotalTime));
            component28.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num9 * 305f);
            break;
          case PrisonerState.WaitForExecute:
            if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 17 && sec > 108000L)
            {
              GameObject gameObject = this.AGS_Form.GetChild(17).GetChild(6).gameObject;
              gameObject.SetActive(true);
              Image component29 = gameObject.GetComponent<Image>();
              if (sec >= 108000L)
                ((Graphic) component29).color = Color.white;
              else
                ((Graphic) component29).color = Color.gray;
            }
            else
              this.AGS_Form.GetChild(17).GetChild(6).gameObject.SetActive(false);
            if (sec > 21600L)
            {
              component26.SetSpriteIndex(0);
              ((Transform) this.CaptureBar).GetChild(0).gameObject.SetActive(false);
              component27.text = this.DM.mStringTable.GetStringByID(7759U);
              float num10 = Mathf.Clamp01(1f - (float) (sec - 21600L) / (float) (this.DM.beCaptured.TotalTime - 21600U));
              component28.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num10 * 305f);
              this.executeUpdated = false;
              break;
            }
            component26.SetSpriteIndex(0);
            ((Transform) this.CaptureBar).GetChild(0).gameObject.SetActive(true);
            ((Transform) this.CaptureBar).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(0);
            component27.text = this.DM.mStringTable.GetStringByID(7758U);
            float num11 = Mathf.Clamp01(1f - (float) sec / 21600f);
            component28.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num11 * 305f);
            break;
          case PrisonerState.Poisoned:
            component26.SetSpriteIndex(1);
            ((Transform) this.CaptureBar).GetChild(0).gameObject.SetActive(true);
            ((Transform) this.CaptureBar).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(1);
            component27.text = this.DM.mStringTable.GetStringByID(15008U);
            float num12 = Mathf.Clamp01((float) (1.0 - (double) sec / (double) this.DM.beCaptured.TotalTime));
            component28.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num12 * 305f);
            if (sec > 108000L)
            {
              this.poisonUpdated = false;
              break;
            }
            if (!this.poisonUpdated)
            {
              this.poisonUpdated = true;
              GUIManager.Instance.CloseMenu(EGUIWindow.UI_SuicideBox);
              break;
            }
            break;
        }
        break;
      case LoadCaptureState.Returning:
        component26.SetSpriteIndex(0);
        ((Transform) this.CaptureBar).GetChild(0).gameObject.SetActive(false);
        component27.text = this.DM.mStringTable.GetStringByID(7787U);
        float num13 = Mathf.Clamp01(1f - (float) sec / (float) this.DM.beCaptured.TotalTime);
        component28.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num13 * 305f);
        break;
      case LoadCaptureState.Dead:
        component26.SetSpriteIndex(0);
        ((Transform) this.CaptureBar).GetChild(0).gameObject.SetActive(false);
        component27.text = this.DM.mStringTable.GetStringByID(7784U);
        component27 = ((Transform) this.RescurePanel).GetChild(0).GetChild(0).GetComponent<UIText>();
        if (sec <= 0L)
        {
          component27.text = this.DM.mStringTable.GetStringByID(7788U);
          ((Transform) this.CaptureBar).GetChild(5).gameObject.SetActive(true);
          ((Transform) this.CaptureBar).GetChild(4).gameObject.SetActive(false);
          ((Transform) this.CaptureBar).GetChild(3).gameObject.SetActive(false);
          break;
        }
        component27.text = this.DM.mStringTable.GetStringByID(7785U);
        ((Transform) this.CaptureBar).GetChild(5).gameObject.SetActive(false);
        float num14 = Mathf.Clamp01(1f - (float) sec / (float) this.DM.beCaptured.TotalTime);
        component28.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num14 * 305f);
        break;
    }
    component27.SetAllDirty();
    component27.cachedTextGenerator.Invalidate();
    UIText component30 = ((Transform) this.CaptureBar).GetChild(4).GetComponent<UIText>();
    this.countDown.ClearString();
    GameConstants.GetTimeString(this.countDown, (uint) sec, true, true);
    component30.text = this.countDown.ToString();
    component30.SetAllDirty();
    component30.cachedTextGenerator.Invalidate();
  }

  private void UpdateInfo_Other()
  {
    StringBuilder stringBuilder = new StringBuilder();
    this.isSameAlli = false;
    this.AGS_HeroBadge.gameObject.SetActive(true);
    this.AGS_Form.GetChild(7).gameObject.SetActive(true);
    stringBuilder.Length = 0;
    float num1 = 0.0f;
    UIText component1 = this.AGS_Form.GetChild(2).GetChild(11).GetComponent<UIText>();
    stringBuilder.Length = 0;
    stringBuilder.AppendFormat("{0:N0}", (object) this.DM.GetVIPLevel(this.DM.mLordProfile.VipPoint));
    component1.text = stringBuilder.ToString();
    UIText component2 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
    if ((int) DataManager.MapDataController.kingdomData.kingdomID != (int) this.DM.mLordProfile.KindomID)
    {
      ((Graphic) component2).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 390f);
      num1 -= 50f;
      this.AGS_Form.GetChild(2).GetChild(15).gameObject.SetActive(true);
    }
    else
      this.AGS_Form.GetChild(2).GetChild(15).gameObject.SetActive(false);
    Vector2 pos;
    if (this.DM.mLordProfile.AllianceTag != null && this.DM.mLordProfile.AllianceTag.Length > 0 && this.DM.mLordProfile.AlliID != 0U)
    {
      this.AGS_GuildRank.gameObject.SetActive(true);
      this.AGS_GuildRank.SetSpriteIndex((int) this.DM.mLordProfile.AlliRank);
      RectTransform component3 = this.AGS_GuildRank.GetComponent<RectTransform>();
      pos = component3.anchoredPosition with { x = -285f };
      component3.anchoredPosition = pos;
      if ((int) this.DM.RoleAlliance.Id == (int) this.DM.mLordProfile.AlliID)
      {
        if (DataManager.CompareStr(this.DM.RoleAttr.Name, this.DM.mLordProfile.PlayerName) != 0)
          this.isSameAlli = true;
        else
          this.AGS_Form.GetChild(2).GetChild(4).gameObject.SetActive(false);
      }
      if (this.isSameAlli && this.DM.CheckPrizeFlag((byte) 9))
      {
        this.AGS_GuildLogo.SetSpriteIndex(1);
        RectTransform component4 = this.AGS_GuildLogo.GetComponent<RectTransform>();
        component4.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 55f);
        component4.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 59f);
        component4.pivot = new Vector2(0.5f, 0.5f);
        component4.anchoredPosition = Vector2.zero;
      }
      this.AGS_Form.GetChild(2).GetChild(7).gameObject.SetActive(true);
    }
    else
    {
      this.AGS_GuildRank.gameObject.SetActive(false);
      if ((int) DataManager.MapDataController.kingdomData.kingdomID == (int) this.DM.mLordProfile.KindomID)
        num1 += 45f;
      this.AGS_Form.GetChild(2).GetChild(7).gameObject.SetActive(false);
    }
    this.Header_NameText.ClearString();
    if ((int) DataManager.MapDataController.kingdomData.kingdomID != (int) this.DM.mLordProfile.KindomID)
      GameConstants.FormatRoleName(this.Header_NameText, this.DM.mLordProfile.PlayerName, this.DM.mLordProfile.AllianceTag, bCheckedNickname: (byte) 0, KingdomID: this.DM.mLordProfile.KindomID, KingdomColor: "<color=#B7D963FF>");
    else
      GameConstants.FormatRoleName(this.Header_NameText, this.DM.mLordProfile.PlayerName, this.DM.mLordProfile.AllianceTag, bCheckedNickname: (byte) 0, KingdomID: (ushort) 0);
    component2.text = this.Header_NameText.ToString();
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
    RectTransform component5 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<RectTransform>();
    pos = component5.anchoredPosition with
    {
      x = -240f - num1
    };
    pos = component2.ArabicFixPos(pos);
    component5.anchoredPosition = pos;
    UIText component6 = this.AGS_Form.GetChild(2).GetChild(5).GetComponent<UIText>();
    stringBuilder.Length = 0;
    stringBuilder.AppendFormat("{0:N0}", (object) this.DM.mLordProfile.Power);
    component6.text = stringBuilder.ToString();
    UIText component7 = this.AGS_Form.GetChild(2).GetChild(6).GetComponent<UIText>();
    stringBuilder.Length = 0;
    stringBuilder.AppendFormat("{0:N0}", (object) this.DM.mLordProfile.Kills);
    component7.text = stringBuilder.ToString();
    UIText component8 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
    stringBuilder.Length = 0;
    stringBuilder.AppendFormat("{0:N0}", (object) this.DM.mLordProfile.Level);
    component8.text = stringBuilder.ToString();
    if (GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 25)
    {
      this.AGS_Form.GetChild(7).GetChild(1).gameObject.SetActive(true);
      UIText component9 = this.AGS_Form.GetChild(7).GetChild(1).GetChild(0).GetComponent<UIText>();
      stringBuilder.Length = 0;
      stringBuilder.AppendFormat("{0:N0}", (object) this.DM.mLordProfile.TotalCastleStar);
      component9.text = stringBuilder.ToString();
    }
    this.Hero_Pos.gameObject.SetActive(true);
    if ((int) this.DM.HeroTable.GetRecordByKey(this.DM.mLordProfile.Head).HeroKey != (int) this.sHero.HeroKey || (UnityEngine.Object) this.Holder1 == (UnityEngine.Object) null)
    {
      this.sHero = this.DM.HeroTable.GetRecordByKey(this.DM.mLordProfile.Head);
      this.Create3DObjects();
    }
    this.HeroRank.sprite = GUIManager.Instance.LoadFrameSprite(EFrameSprite.Hero, (byte) ((uint) this.DM.mLordProfile.Enhance + 100U));
    ((Component) this.HeroRank).gameObject.SetActive(true);
    if (this.DM.mLordProfile.Star > (byte) 0)
      this.AGS_HeroBadge.SetSpriteIndex((int) this.DM.mLordProfile.Star - 1);
    for (int index = 0; index < 8; ++index)
    {
      if (this.DM.mLordProfile.Equips[index].ItemID != (ushort) 0)
      {
        this.AGS_Form.GetChild(5).GetChild(index + 8).gameObject.SetActive(false);
        ((Component) this.UILEBtn[index]).gameObject.SetActive(true);
        GUIManager.Instance.ChangeLordEquipImg(((Component) this.UILEBtn[index]).transform, this.DM.mLordProfile.Equips[index].ItemID, this.DM.mLordProfile.Equips[index].color, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      }
      else
      {
        this.AGS_Form.GetChild(5).GetChild(index + 8).gameObject.SetActive(true);
        ((Component) this.UILEBtn[index]).gameObject.SetActive(false);
      }
    }
    this.AGS_Form.GetChild(5).GetChild(24).gameObject.SetActive(false);
    this.AGS_Form.GetChild(5).GetChild(25).gameObject.SetActive(false);
    int num2 = 0;
    if (this.DM.mLordProfile.Title > (ushort) 1)
    {
      TitleData recordByKey = this.DM.TitleData.GetRecordByKey(this.DM.mLordProfile.Title);
      ((Component) this.TitlePanel).gameObject.SetActive(true);
      UIText component10 = ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).GetComponent<UIText>();
      RectTransform component11 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<RectTransform>();
      component10.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID);
      component10.SetAllDirty();
      component10.cachedTextGenerator.Invalidate();
      component10.cachedTextGeneratorForLayout.Invalidate();
      float num3 = (float) ((double) component10.preferredWidth / 2.0 + 35.0);
      if ((double) num3 > 140.0)
        num3 = 140f;
      component11.anchoredPosition = new Vector2(-num3, component11.anchoredPosition.y);
      Image component12 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<Image>();
      ((MaskableGraphic) component12).material = GUIManager.Instance.GetTitleMaterial();
      component12.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID);
      ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 21;
      ++num2;
    }
    if (this.DM.mLordProfile.NobilityTitle > (ushort) 1)
    {
      TitleData recordByKey = this.DM.TitleDataF.GetRecordByKey(this.DM.mLordProfile.NobilityTitle);
      ((Component) this.TitlePanel).gameObject.SetActive(true);
      UIText component13 = ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).GetComponent<UIText>();
      RectTransform component14 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<RectTransform>();
      component13.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID);
      component13.SetAllDirty();
      component13.cachedTextGenerator.Invalidate();
      component13.cachedTextGeneratorForLayout.Invalidate();
      float num4 = (float) ((double) component13.preferredWidth / 2.0 + 35.0);
      if ((double) num4 > 140.0)
        num4 = 140f;
      component14.anchoredPosition = new Vector2(-num4, component14.anchoredPosition.y);
      Image component15 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<Image>();
      ((MaskableGraphic) component15).material = GUIManager.Instance.GetTitleMaterial();
      component15.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.NobilityTitle);
      ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 22;
      ++num2;
    }
    if (this.DM.mLordProfile.WorldTitle > (ushort) 1)
    {
      TitleData recordByKey = this.DM.TitleDataW.GetRecordByKey(this.DM.mLordProfile.WorldTitle);
      ((Component) this.TitlePanel).gameObject.SetActive(true);
      UIText component16 = ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).GetComponent<UIText>();
      RectTransform component17 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<RectTransform>();
      component16.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID);
      component16.SetAllDirty();
      component16.cachedTextGenerator.Invalidate();
      component16.cachedTextGeneratorForLayout.Invalidate();
      float num5 = (float) ((double) component16.preferredWidth / 2.0 + 35.0);
      if ((double) num5 > 140.0)
        num5 = 140f;
      component17.anchoredPosition = new Vector2(-num5, component17.anchoredPosition.y);
      Image component18 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<Image>();
      ((MaskableGraphic) component18).material = GUIManager.Instance.GetTitleMaterial();
      component18.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.WorldTitle);
      ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 23;
      ++num2;
    }
    if (this.DM.mLordProfile.Title == (ushort) 1)
    {
      TitleData recordByKey = this.DM.TitleData.GetRecordByKey(this.DM.mLordProfile.Title);
      ((Component) this.TitlePanel).gameObject.SetActive(true);
      UIText component19 = ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).GetComponent<UIText>();
      RectTransform component20 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<RectTransform>();
      component19.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID);
      component19.SetAllDirty();
      component19.cachedTextGenerator.Invalidate();
      component19.cachedTextGeneratorForLayout.Invalidate();
      float num6 = (float) ((double) component19.preferredWidth / 2.0 + 35.0);
      if ((double) num6 > 140.0)
        num6 = 140f;
      component20.anchoredPosition = new Vector2(-num6, component20.anchoredPosition.y);
      Image component21 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<Image>();
      ((MaskableGraphic) component21).material = GUIManager.Instance.GetTitleMaterial();
      component21.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID);
      ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 21;
      ++num2;
    }
    if (this.DM.mLordProfile.NobilityTitle == (ushort) 1)
    {
      TitleData recordByKey = this.DM.TitleDataF.GetRecordByKey(this.DM.mLordProfile.NobilityTitle);
      ((Component) this.TitlePanel).gameObject.SetActive(true);
      UIText component22 = ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).GetComponent<UIText>();
      RectTransform component23 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<RectTransform>();
      component22.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID);
      component22.SetAllDirty();
      component22.cachedTextGenerator.Invalidate();
      component22.cachedTextGeneratorForLayout.Invalidate();
      float num7 = (float) ((double) component22.preferredWidth / 2.0 + 35.0);
      if ((double) num7 > 140.0)
        num7 = 140f;
      component23.anchoredPosition = new Vector2(-num7, component23.anchoredPosition.y);
      Image component24 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<Image>();
      ((MaskableGraphic) component24).material = GUIManager.Instance.GetTitleMaterial();
      component24.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.NobilityTitle);
      ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 22;
      ++num2;
    }
    if (this.DM.mLordProfile.WorldTitle == (ushort) 1)
    {
      TitleData recordByKey = this.DM.TitleDataW.GetRecordByKey(this.DM.mLordProfile.WorldTitle);
      ((Component) this.TitlePanel).gameObject.SetActive(true);
      UIText component25 = ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).GetComponent<UIText>();
      RectTransform component26 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<RectTransform>();
      component25.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.StringID);
      component25.SetAllDirty();
      component25.cachedTextGenerator.Invalidate();
      component25.cachedTextGeneratorForLayout.Invalidate();
      float num8 = (float) ((double) component25.preferredWidth / 2.0 + 35.0);
      if ((double) num8 > 140.0)
        num8 = 140f;
      component26.anchoredPosition = new Vector2(-num8, component26.anchoredPosition.y);
      Image component27 = ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).GetComponent<Image>();
      ((MaskableGraphic) component27).material = GUIManager.Instance.GetTitleMaterial();
      component27.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey.IconID, eTitleKind.WorldTitle);
      ((Transform) this.TitlePanel).GetChild(2 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(1 + num2 * 3).gameObject.SetActive(true);
      ((Transform) this.TitlePanel).GetChild(0 + num2 * 3).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 23;
      ++num2;
    }
    if (((Component) this.TitlePanel).gameObject.activeInHierarchy)
    {
      for (int index = num2; index < 3; ++index)
      {
        ((Transform) this.TitlePanel).GetChild(2 + index * 3).gameObject.SetActive(false);
        ((Transform) this.TitlePanel).GetChild(0 + index * 3).gameObject.SetActive(false);
        ((Transform) this.TitlePanel).GetChild(1 + index * 3).gameObject.SetActive(false);
      }
    }
    if (num2 == 0)
      ((Component) this.TitlePanel).gameObject.SetActive(false);
    GUIManager.Instance.HideUILock(EUILock.LordInfo);
  }

  private void UpdateInfo_Record()
  {
    if (this.OpenKind == EUILordInfoLayout.RecordInfo)
      this.UpdateInfo_MyHeader();
    this.AGS_ScrollPanel.gameObject.SetActive(true);
    if (!this.scrollPanelInit)
    {
      this.scrollPanelInit = true;
      this.SPHeights = new List<float>();
      this.AGS_ScrollPanel.IntiScrollPanel(481f, 0.0f, 0.0f, this.SPHeights, 18, (IUpDateScrollPanel) this);
      UIButtonHint.scrollRect2 = this.AGS_ScrollPanel.GetComponent<CScrollRect>();
    }
    if (this.EnhanceShowedIdx == null)
      this.EnhanceShowedIdx = new List<int>();
    this.EnhanceShowedIdx.Clear();
    this.SPHeights.Clear();
    ushort InKey1 = this.OpenKind != EUILordInfoLayout.RecordInfo ? this.DM.mLordProfile.WorldTitle : this.DM.RoleAttr.WorldTitle_Personal;
    if (InKey1 == (ushort) 1)
    {
      this.EnhanceShowedIdx.Add(10001);
      TitleData recordByKey = this.DM.TitleDataW.GetRecordByKey(InKey1);
      int num = 0;
      for (int index = 0; index < 3; ++index)
      {
        if (recordByKey.Effects[index].EffectID != (ushort) 0)
        {
          if (this.TitleSPItemText.Length > 0)
            this.TitleSPItemText.Append("\n");
          if (this.DM.EffectData.GetRecordByKey(recordByKey.Effects[index].EffectID).ID > (ushort) 0)
            ++num;
        }
      }
      if (num > 2)
      {
        this.TitleSPItem2.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 140f);
        ((Transform) this.TitleSPItem2).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 140f);
        ((Transform) this.TitleSPItem2).GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 90f);
        this.SPHeights.Add(143f);
      }
      else
      {
        this.TitleSPItem2.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 110f);
        ((Transform) this.TitleSPItem2).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 110f);
        ((Transform) this.TitleSPItem2).GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 60f);
        this.SPHeights.Add(113f);
      }
    }
    ushort InKey2 = this.OpenKind != EUILordInfoLayout.RecordInfo ? this.DM.mLordProfile.NobilityTitle : this.DM.RoleAttr.NobilityTitle;
    if (InKey2 == (ushort) 1)
    {
      this.EnhanceShowedIdx.Add(10002);
      TitleData recordByKey = this.DM.TitleDataF.GetRecordByKey(InKey2);
      int num = 0;
      for (int index = 0; index < 3; ++index)
      {
        if (recordByKey.Effects[index].EffectID != (ushort) 0)
        {
          if (this.TitleSPItemText3.Length > 0)
            this.TitleSPItemText3.Append("\n");
          if (this.DM.EffectData.GetRecordByKey(recordByKey.Effects[index].EffectID).ID > (ushort) 0)
            ++num;
        }
      }
      if (num > 2)
      {
        this.TitleSPItem3.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 140f);
        ((Transform) this.TitleSPItem3).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 140f);
        ((Transform) this.TitleSPItem3).GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 90f);
        this.SPHeights.Add(143f);
      }
      else
      {
        this.TitleSPItem3.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 110f);
        ((Transform) this.TitleSPItem3).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 110f);
        ((Transform) this.TitleSPItem3).GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 60f);
        this.SPHeights.Add(113f);
      }
    }
    ushort num1 = this.OpenKind != EUILordInfoLayout.RecordInfo ? this.DM.mLordProfile.Title : this.DM.RoleAttr.KingdomTitle;
    if (num1 == (ushort) 1)
    {
      this.EnhanceShowedIdx.Add(10000);
      if (num1 == (ushort) 1)
      {
        this.TitleSPItem.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 140f);
        ((Transform) this.TitleSPItem).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 140f);
        ((Transform) this.TitleSPItem).GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 90f);
        this.SPHeights.Add(143f);
      }
      else
      {
        this.TitleSPItem.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 110f);
        ((Transform) this.TitleSPItem).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 110f);
        ((Transform) this.TitleSPItem).GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 60f);
        this.SPHeights.Add(113f);
      }
    }
    ushort InKey3 = this.OpenKind != EUILordInfoLayout.RecordInfo ? this.DM.mLordProfile.WorldTitle : this.DM.RoleAttr.WorldTitle_Personal;
    if (InKey3 > (ushort) 1)
    {
      this.EnhanceShowedIdx.Add(10001);
      TitleData recordByKey = this.DM.TitleDataW.GetRecordByKey(InKey3);
      int num2 = 0;
      for (int index = 0; index < 3; ++index)
      {
        if (recordByKey.Effects[index].EffectID != (ushort) 0)
        {
          if (this.TitleSPItemText.Length > 0)
            this.TitleSPItemText.Append("\n");
          if (this.DM.EffectData.GetRecordByKey(recordByKey.Effects[index].EffectID).ID > (ushort) 0)
            ++num2;
        }
      }
      if (num2 > 2)
      {
        this.TitleSPItem2.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 140f);
        ((Transform) this.TitleSPItem2).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 140f);
        ((Transform) this.TitleSPItem2).GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 90f);
        this.SPHeights.Add(143f);
      }
      else
      {
        this.TitleSPItem2.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 110f);
        ((Transform) this.TitleSPItem2).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 110f);
        ((Transform) this.TitleSPItem2).GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 60f);
        this.SPHeights.Add(113f);
      }
    }
    ushort InKey4 = this.OpenKind != EUILordInfoLayout.RecordInfo ? this.DM.mLordProfile.NobilityTitle : this.DM.RoleAttr.NobilityTitle;
    if (InKey4 > (ushort) 1)
    {
      this.EnhanceShowedIdx.Add(10002);
      TitleData recordByKey = this.DM.TitleDataF.GetRecordByKey(InKey4);
      int num3 = 0;
      for (int index = 0; index < 3; ++index)
      {
        if (recordByKey.Effects[index].EffectID != (ushort) 0)
        {
          if (this.TitleSPItemText3.Length > 0)
            this.TitleSPItemText3.Append("\n");
          if (this.DM.EffectData.GetRecordByKey(recordByKey.Effects[index].EffectID).ID > (ushort) 0)
            ++num3;
        }
      }
      if (num3 > 2)
      {
        this.TitleSPItem3.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 140f);
        ((Transform) this.TitleSPItem3).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 140f);
        ((Transform) this.TitleSPItem3).GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 90f);
        this.SPHeights.Add(143f);
      }
      else
      {
        this.TitleSPItem3.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 110f);
        ((Transform) this.TitleSPItem3).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 110f);
        ((Transform) this.TitleSPItem3).GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 60f);
        this.SPHeights.Add(113f);
      }
    }
    ushort num4 = this.OpenKind != EUILordInfoLayout.RecordInfo ? this.DM.mLordProfile.Title : this.DM.RoleAttr.KingdomTitle;
    if (num4 > (ushort) 1)
    {
      this.EnhanceShowedIdx.Add(10000);
      if (num4 == (ushort) 1)
      {
        this.TitleSPItem.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 140f);
        ((Transform) this.TitleSPItem).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 140f);
        ((Transform) this.TitleSPItem).GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 90f);
        this.SPHeights.Add(143f);
      }
      else
      {
        this.TitleSPItem.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 110f);
        ((Transform) this.TitleSPItem).GetChild(0).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 110f);
        ((Transform) this.TitleSPItem).GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 60f);
        this.SPHeights.Add(113f);
      }
    }
    for (int index = 0; index < UILordInfo.RecordFields.GetLength(0); ++index)
    {
      if (this.OpenKind == EUILordInfoLayout.RecordInfoOther & index == 19)
        index += 9;
      this.EnhanceShowedIdx.Add(index);
      if (UILordInfo.RecordFields[index, 1] == 0U)
        this.SPHeights.Add(42f);
      else
        this.SPHeights.Add(32f);
    }
    this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeights, 481f, false);
    this.AGS_ScrollPanel.GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 481f);
    if (this.HasBeenPage == EUILordInfoLayout.EnhanceInfo)
      this.AGS_ScrollPanel.GoTo(0);
    GUIManager.Instance.HideUILock(EUILock.LordInfo);
    this.StatDataReady = true;
    this.HasBeenPage = this.OpenKind;
  }

  private void UpdateInfo_Enhance()
  {
    this.AGS_ScrollPanel.gameObject.SetActive(true);
    if (!this.scrollPanelInit)
    {
      this.scrollPanelInit = true;
      this.SPHeights = new List<float>();
      this.AGS_ScrollPanel.IntiScrollPanel(515f, 0.0f, 0.0f, this.SPHeights, 18, (IUpDateScrollPanel) this);
      UIButtonHint.scrollRect2 = this.AGS_ScrollPanel.GetComponent<CScrollRect>();
    }
    if (this.EnhanceShowedIdx == null)
      this.EnhanceShowedIdx = new List<int>();
    if (this.Barkind == null)
      this.Barkind = new List<eSPDisplayType>();
    this.EnhanceShowedIdx.Clear();
    this.SPHeights.Clear();
    this.Barkind.Clear();
    ushort num = 0;
    this.lastUpdateIdx = -1;
    for (ushort Index1 = 0; (int) Index1 < this.DM.LordEnhanceTable.TableCount; ++Index1)
    {
      LordEnhanceTbl recordByIndex1 = this.DM.LordEnhanceTable.GetRecordByIndex((int) Index1);
      Debug.Log((object) ("let Type: " + (object) recordByIndex1.Type));
      if (recordByIndex1.Type == (byte) 4)
      {
        bool flag = false;
        for (int Index2 = (int) Index1 + 1; Index2 < this.DM.LordEnhanceTable.TableCount; ++Index2)
        {
          LordEnhanceTbl recordByIndex2 = this.DM.LordEnhanceTable.GetRecordByIndex(Index2);
          if (recordByIndex2.Type != (byte) 4)
          {
            if (recordByIndex2.Type == (byte) 1)
            {
              if (this.GetBuffTime((int) recordByIndex2.Effect1) == 0U)
                continue;
            }
            else if (recordByIndex2.Type == (byte) 3)
            {
              if (recordByIndex2.Effect2 > (ushort) 3)
                continue;
            }
            else if (recordByIndex2.Type > (byte) 4)
              continue;
            flag = true;
            break;
          }
          break;
        }
        if (!flag)
          continue;
      }
      if (recordByIndex1.Type == (byte) 1)
      {
        if (this.GetBuffTime((int) recordByIndex1.Effect1) != 0U)
          this.lastUpdateIdx = (int) Index1;
        else
          continue;
      }
      else if (recordByIndex1.Type == (byte) 3)
      {
        if (recordByIndex1.Effect2 > (ushort) 3)
          continue;
      }
      else if (recordByIndex1.Type > (byte) 4)
        continue;
      this.EnhanceShowedIdx.Add((int) Index1);
      if (recordByIndex1.Type == (byte) 4)
      {
        this.SPHeights.Add(42f);
        this.Barkind.Add(eSPDisplayType.Title);
        num = Index1;
      }
      else
      {
        if (((int) Index1 - (int) num) % 2 > 0)
          this.Barkind.Add(eSPDisplayType.content);
        else
          this.Barkind.Add(eSPDisplayType.HighLightContent);
        this.SPHeights.Add(32f);
      }
    }
    this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeights, 515f, false);
    this.AGS_ScrollPanel.GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 515f);
    ((Component) this.TitleSPItem).gameObject.SetActive(false);
    ((Component) this.TitleSPItem2).gameObject.SetActive(false);
    ((Component) this.TitleSPItem3).gameObject.SetActive(false);
    if (this.HasBeenPage != EUILordInfoLayout.EnhanceInfo)
      this.AGS_ScrollPanel.GoTo(0);
    this.HasBeenPage = this.OpenKind;
    GUIManager.Instance.HideUILock(EUILock.LordInfo);
  }

  private void UpdateInfo_MyHeader()
  {
    StringBuilder stringBuilder = new StringBuilder();
    stringBuilder.Length = 0;
    float num1 = 0.0f;
    UIText component1 = this.AGS_Form.GetChild(2).GetChild(11).GetComponent<UIText>();
    stringBuilder.Length = 0;
    stringBuilder.AppendFormat("{0:N0}", (object) this.DM.RoleAttr.VIPLevel);
    component1.text = stringBuilder.ToString();
    UIText component2 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<UIText>();
    if (this.DM.RoleAlliance.Id > 0U)
    {
      this.AGS_GuildRank.gameObject.SetActive(true);
      this.AGS_GuildRank.SetSpriteIndex((int) this.DM.RoleAlliance.Rank);
      RectTransform component3 = this.AGS_GuildRank.GetComponent<RectTransform>();
      Vector2 anchoredPosition = component3.anchoredPosition with
      {
        x = -285f
      };
      component3.anchoredPosition = anchoredPosition;
    }
    else
    {
      this.AGS_GuildRank.gameObject.SetActive(false);
      num1 += 45f;
    }
    ((Graphic) component2).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 460f + num1);
    this.Header_NameText.ClearString();
    if (this.DM.RoleAttr.NickName.Length > 0)
    {
      GameConstants.FormatRoleName(this.Header_NameText, this.DM.RoleAttr.Name, this.DM.RoleAlliance.Tag, this.DM.RoleAttr.NickName, (byte) 0, (ushort) 0, NickColor: "<color=#4CF5F5>");
    }
    else
    {
      CString Nickname = StringManager.Instance.StaticString1024();
      Nickname.ClearString();
      Nickname.Append(this.DM.mStringTable.GetStringByID(9096U));
      GameConstants.FormatRoleName(this.Header_NameText, this.DM.RoleAttr.Name, this.DM.RoleAlliance.Tag, Nickname, (byte) 0, (ushort) 0, NickColor: "<color=#4CF5F5>");
    }
    component2.text = this.Header_NameText.ToString();
    component2.SetAllDirty();
    component2.cachedTextGenerator.Invalidate();
    component2.cachedTextGeneratorForLayout.Invalidate();
    component2.UpdateArabicPos();
    RectTransform component4 = this.AGS_Form.GetChild(2).GetChild(2).GetComponent<RectTransform>();
    Vector2 pos = component4.anchoredPosition with
    {
      x = -240f - num1
    };
    pos = component2.ArabicFixPos(pos);
    component4.anchoredPosition = pos;
    RectTransform component5 = this.AGS_Form.GetChild(2).GetChild(3).GetComponent<RectTransform>();
    pos = component5.anchoredPosition with
    {
      x = Math.Min(230f, -210f - num1 + component2.preferredWidth)
    };
    component5.anchoredPosition = pos;
    UIText component6 = this.AGS_Form.GetChild(2).GetChild(5).GetComponent<UIText>();
    stringBuilder.Length = 0;
    stringBuilder.AppendFormat("{0:N0}", (object) this.DM.RoleAttr.Power);
    component6.text = stringBuilder.ToString();
    UIText component7 = this.AGS_Form.GetChild(2).GetChild(6).GetComponent<UIText>();
    stringBuilder.Length = 0;
    stringBuilder.AppendFormat("{0:N0}", (object) this.DM.RoleAttr.Kills);
    component7.text = stringBuilder.ToString();
    UIText component8 = this.AGS_Form.GetChild(7).GetChild(0).GetComponent<UIText>();
    stringBuilder.Length = 0;
    stringBuilder.AppendFormat("{0:N0}", (object) this.DM.RoleAttr.Level);
    component8.text = stringBuilder.ToString();
    UIText component9 = this.AGS_Form.GetChild(6).GetChild(8).GetComponent<UIText>();
    stringBuilder.Length = 0;
    if (!GUIManager.Instance.IsArabic)
      stringBuilder.AppendFormat("{0:N0} / {1:N0}", (object) this.DM.RoleAttr.Exp, (object) this.DM.LevelUpTable.GetRecordByKey((ushort) this.DM.RoleAttr.Level).KingdomExp);
    else
      stringBuilder.AppendFormat("{1:N0} / {0:N0}", (object) this.DM.RoleAttr.Exp, (object) this.DM.LevelUpTable.GetRecordByKey((ushort) this.DM.RoleAttr.Level).KingdomExp);
    component9.text = stringBuilder.ToString();
    float num2 = 250f * (float) this.DM.RoleAttr.Exp / (float) this.DM.LevelUpTable.GetRecordByKey((ushort) this.DM.RoleAttr.Level).KingdomExp;
    if ((double) num2 > 250.0)
      num2 = 250f;
    if (this.DM.RoleAttr.Level >= (byte) 60)
    {
      num2 = 250f;
      component9.text = this.DM.mStringTable.GetStringByID(7369U);
    }
    this.AGS_Form.GetChild(6).GetChild(3).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num2);
    this.AGS_Form.GetChild(6).GetChild(2).GetComponent<RectTransform>().SetSizeWithCurrentAnchors((RectTransform.Axis) 0, Mathf.Clamp01((float) this.DM.RoleAttr.MonsterPoint / (float) this.DM.GetMaxMonsterPoint()) * 261f);
    UIText component10 = this.AGS_Form.GetChild(6).GetChild(7).GetComponent<UIText>();
    this.EnStr.ClearString();
    this.EnStr.IntToFormat((long) this.DM.RoleAttr.MonsterPoint, bNumber: true);
    this.EnStr.IntToFormat((long) this.DM.GetMaxMonsterPoint(), bNumber: true);
    if (!GUIManager.Instance.IsArabic)
      this.EnStr.AppendFormat("{0} / {1}");
    else
      this.EnStr.AppendFormat("{1} / {0}");
    component10.text = this.EnStr.ToString();
    component10.SetAllDirty();
    component10.cachedTextGenerator.Invalidate();
  }

  public override void OnClose()
  {
    this.Destory3DObject();
    if (this.Header_NameText != null)
      StringManager.Instance.DeSpawnString(this.Header_NameText);
    for (int index = 0; index < this.tmpString.Length; ++index)
      StringManager.Instance.DeSpawnString(this.tmpString[index]);
    for (int index = 0; index < this.tmpLordString.Length; ++index)
      StringManager.Instance.DeSpawnString(this.tmpLordString[index]);
    for (int index = 0; index < this.JailerStr.Length; ++index)
      StringManager.Instance.DeSpawnString(this.JailerStr[index]);
    StringManager.Instance.DeSpawnString(this.hintString);
    StringManager.Instance.DeSpawnString(this.countDown);
    StringManager.Instance.DeSpawnString(this.PopStr);
    StringManager.Instance.DeSpawnString(this.EnStr);
    StringManager.Instance.DeSpawnString(this.TitleSPItemText);
    StringManager.Instance.DeSpawnString(this.TitleSPItemText2);
    StringManager.Instance.DeSpawnString(this.TitleSPItemText3);
    GUIManager.Instance.HideUILock(EUILock.LordInfo);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || arg1 != 1)
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_PAY_RANSOM;
    messagePacket.AddSeqId();
    messagePacket.Send();
    GUIManager.Instance.CloseMenu(EGUIWindow.UI_JailMoney);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    switch (this.OpenKind)
    {
      case EUILordInfoLayout.RecordInfo:
      case EUILordInfoLayout.RecordInfoOther:
        this.UpdateRecordRow(item, dataIdx, panelObjectIdx);
        break;
      case EUILordInfoLayout.EnhanceInfo:
        this.UpdateEffectRow(item, dataIdx, panelObjectIdx);
        break;
    }
  }

  private void UpdateRecordRow(GameObject item, int dataIdx, int panelObjectIdx)
  {
    int constStringID = this.EnhanceShowedIdx[dataIdx];
    UIText SecendText1 = (UIText) null;
    item.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
    item.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
    if (panelObjectIdx == this.TitleSPItemIdx && constStringID != 10000)
      ((Component) this.TitleSPItem).gameObject.SetActive(false);
    if (constStringID == 10000)
    {
      this.TitleSPItemIdx = panelObjectIdx;
      this.quickFillRow(item, eSPDisplayType.NoContent, 0U, out SecendText1);
      ((Transform) this.TitleSPItem).SetParent(item.transform);
      this.TitleSPItem.anchoredPosition = Vector2.zero;
      ((Component) this.TitleSPItem).gameObject.SetActive(true);
      TitleData recordByKey1 = this.DM.TitleData.GetRecordByKey(this.OpenKind != EUILordInfoLayout.RecordInfo ? this.DM.mLordProfile.Title : this.DM.RoleAttr.KingdomTitle);
      ((Transform) this.TitleSPItem).GetChild(2).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID((uint) recordByKey1.StringID);
      UIText component1 = ((Transform) this.TitleSPItem).GetChild(3).GetComponent<UIText>();
      this.tmpString[panelObjectIdx].ClearString();
      Image component2 = ((Transform) this.TitleSPItem).GetChild(1).GetComponent<Image>();
      ((MaskableGraphic) component2).material = GUIManager.Instance.GetTitleMaterial();
      component2.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey1.IconID);
      if (recordByKey1.isDebuff > (byte) 0)
        ((Transform) this.TitleSPItem).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(1);
      else
        ((Transform) this.TitleSPItem).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(0);
      this.TitleSPItemText.ClearString();
      for (int index = 0; index < 3; ++index)
      {
        if (recordByKey1.Effects[index].EffectID != (ushort) 0)
        {
          if (this.TitleSPItemText.Length > 0)
            this.TitleSPItemText.Append("\n");
          Effect recordByKey2 = this.DM.EffectData.GetRecordByKey(recordByKey1.Effects[index].EffectID);
          this.TitleSPItemText.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey2.InfoID));
          if (recordByKey1.Effects[index].Value > (ushort) 0)
          {
            if (recordByKey2.StatusIcon == (ushort) 0)
              this.TitleSPItemText.AppendFormat("<color=#35F76CFF>{0} +");
            else if (recordByKey2.StatusIcon == (ushort) 1)
              this.TitleSPItemText.AppendFormat("<color=#FF656EFF>{0} -");
            else if (recordByKey2.StatusIcon == (ushort) 2)
              this.TitleSPItemText.AppendFormat("<color=#FF656EFF>{0} +");
            if (recordByKey2.ValueID == (ushort) 0)
            {
              this.TitleSPItemText.IntToFormat((long) recordByKey1.Effects[index].Value);
              this.TitleSPItemText.AppendFormat("{0}");
            }
            else
            {
              this.TitleSPItemText.FloatToFormat((float) recordByKey1.Effects[index].Value / 100f, 2, false);
              this.TitleSPItemText.AppendFormat("{0}%");
            }
            this.TitleSPItemText.Append("</color>");
          }
          else
            this.TitleSPItemText.AppendFormat("<color=#35F76CFF>{0}</color>");
        }
      }
      component1.text = this.TitleSPItemText.ToString();
      component1.SetAllDirty();
      component1.cachedTextGenerator.Invalidate();
    }
    else
    {
      if (panelObjectIdx == this.TitleSPItemIdx2 && constStringID != 10001)
        ((Component) this.TitleSPItem2).gameObject.SetActive(false);
      if (constStringID == 10001)
      {
        this.TitleSPItemIdx2 = panelObjectIdx;
        this.quickFillRow(item, eSPDisplayType.NoContent, 0U, out SecendText1);
        ((Transform) this.TitleSPItem2).SetParent(item.transform);
        this.TitleSPItem2.anchoredPosition = Vector2.zero;
        ((Component) this.TitleSPItem2).gameObject.SetActive(true);
        TitleData recordByKey3 = this.DM.TitleDataW.GetRecordByKey(this.OpenKind != EUILordInfoLayout.RecordInfo ? this.DM.mLordProfile.WorldTitle : this.DM.RoleAttr.WorldTitle_Personal);
        ((Transform) this.TitleSPItem2).GetChild(2).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID((uint) recordByKey3.StringID);
        UIText component3 = ((Transform) this.TitleSPItem2).GetChild(3).GetComponent<UIText>();
        this.tmpString[panelObjectIdx].ClearString();
        Image component4 = ((Transform) this.TitleSPItem2).GetChild(1).GetComponent<Image>();
        ((MaskableGraphic) component4).material = GUIManager.Instance.GetTitleMaterial();
        component4.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey3.IconID, eTitleKind.WorldTitle);
        if (recordByKey3.isDebuff > (byte) 0)
          ((Transform) this.TitleSPItem2).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(1);
        else
          ((Transform) this.TitleSPItem2).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(0);
        this.TitleSPItemText2.ClearString();
        for (int index = 0; index < 3; ++index)
        {
          if (recordByKey3.Effects[index].EffectID != (ushort) 0)
          {
            if (this.TitleSPItemText2.Length > 0)
              this.TitleSPItemText2.Append("\n");
            Effect recordByKey4 = this.DM.EffectData.GetRecordByKey(recordByKey3.Effects[index].EffectID);
            this.TitleSPItemText2.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey4.InfoID));
            if (recordByKey3.Effects[index].Value > (ushort) 0)
            {
              if (recordByKey4.StatusIcon == (ushort) 0)
                this.TitleSPItemText2.AppendFormat("<color=#35F76CFF>{0} +");
              else if (recordByKey4.StatusIcon == (ushort) 1)
                this.TitleSPItemText2.AppendFormat("<color=#FF656EFF>{0} -");
              else if (recordByKey4.StatusIcon == (ushort) 2)
                this.TitleSPItemText2.AppendFormat("<color=#FF656EFF>{0} +");
              if (recordByKey4.ValueID == (ushort) 0)
              {
                this.TitleSPItemText2.IntToFormat((long) recordByKey3.Effects[index].Value);
                this.TitleSPItemText2.AppendFormat("{0}");
              }
              else
              {
                this.TitleSPItemText2.FloatToFormat((float) recordByKey3.Effects[index].Value / 100f, 2, false);
                this.TitleSPItemText2.AppendFormat("{0}%");
              }
              this.TitleSPItemText2.Append("</color>");
            }
            else
              this.TitleSPItemText2.AppendFormat("<color=#35F76CFF>{0}</color>");
          }
        }
        component3.text = this.TitleSPItemText2.ToString();
        component3.SetAllDirty();
        component3.cachedTextGenerator.Invalidate();
      }
      else
      {
        if (panelObjectIdx == this.TitleSPItemIdx3 && constStringID != 10002)
          ((Component) this.TitleSPItem3).gameObject.SetActive(false);
        if (constStringID == 10002)
        {
          this.TitleSPItemIdx3 = panelObjectIdx;
          this.quickFillRow(item, eSPDisplayType.NoContent, 0U, out SecendText1);
          ((Transform) this.TitleSPItem3).SetParent(item.transform);
          this.TitleSPItem3.anchoredPosition = Vector2.zero;
          ((Component) this.TitleSPItem3).gameObject.SetActive(true);
          TitleData recordByKey5 = this.DM.TitleDataF.GetRecordByKey(this.OpenKind != EUILordInfoLayout.RecordInfo ? this.DM.mLordProfile.NobilityTitle : this.DM.RoleAttr.NobilityTitle);
          ((Transform) this.TitleSPItem3).GetChild(2).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID((uint) recordByKey5.StringID);
          UIText component5 = ((Transform) this.TitleSPItem3).GetChild(3).GetComponent<UIText>();
          this.tmpString[panelObjectIdx].ClearString();
          Image component6 = ((Transform) this.TitleSPItem3).GetChild(1).GetComponent<Image>();
          ((MaskableGraphic) component6).material = GUIManager.Instance.GetTitleMaterial();
          component6.sprite = GUIManager.Instance.LoadTitleSprite(recordByKey5.IconID, eTitleKind.NobilityTitle);
          if (recordByKey5.isDebuff > (byte) 0)
            ((Transform) this.TitleSPItem3).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(1);
          else
            ((Transform) this.TitleSPItem3).GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(0);
          this.TitleSPItemText3.ClearString();
          for (int index = 0; index < 3; ++index)
          {
            if (recordByKey5.Effects[index].EffectID != (ushort) 0)
            {
              if (this.TitleSPItemText3.Length > 0)
                this.TitleSPItemText3.Append("\n");
              Effect recordByKey6 = this.DM.EffectData.GetRecordByKey(recordByKey5.Effects[index].EffectID);
              this.TitleSPItemText3.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey6.InfoID));
              if (recordByKey5.Effects[index].Value > (ushort) 0)
              {
                if (recordByKey6.StatusIcon == (ushort) 0)
                  this.TitleSPItemText3.AppendFormat("<color=#35F76CFF>{0} +");
                else if (recordByKey6.StatusIcon == (ushort) 1)
                  this.TitleSPItemText3.AppendFormat("<color=#FF656EFF>{0} -");
                else if (recordByKey6.StatusIcon == (ushort) 2)
                  this.TitleSPItemText3.AppendFormat("<color=#FF656EFF>{0} +");
                if (recordByKey6.ValueID == (ushort) 0)
                {
                  this.TitleSPItemText3.IntToFormat((long) recordByKey5.Effects[index].Value);
                  this.TitleSPItemText3.AppendFormat("{0}");
                }
                else
                {
                  this.TitleSPItemText3.FloatToFormat((float) recordByKey5.Effects[index].Value / 100f, 2, false);
                  this.TitleSPItemText3.AppendFormat("{0}%");
                }
                this.TitleSPItemText3.Append("</color>");
              }
              else
                this.TitleSPItemText3.AppendFormat("<color=#35F76CFF>{0}</color>");
            }
          }
          component5.text = this.TitleSPItemText3.ToString();
          component5.SetAllDirty();
          component5.cachedTextGenerator.Invalidate();
        }
        else
        {
          UIText SecendText2 = item.transform.GetChild(1).GetChild(2).GetComponent<UIText>();
          ((Graphic) SecendText2).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 350f);
          switch (UILordInfo.RecordFields[constStringID, 2])
          {
            case 0:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              break;
            case 1:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) (this.DM.mLordStat.BattleWin_Attack + this.DM.mLordStat.BattleWin_Defense), bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 2:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) (this.DM.mLordStat.BattleLose_Attack + this.DM.mLordStat.BattleLose_Defense), bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 3:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.BattleWin_Attack, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 4:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.BattleLose_Attack, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 5:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.BattleWin_Defense, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 6:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.BattleLose_Defense, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 7:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              float num = (float) (this.DM.mLordStat.BattleWin_Attack + this.DM.mLordStat.BattleLose_Attack + this.DM.mLordStat.BattleWin_Defense + this.DM.mLordStat.BattleLose_Defense);
              if ((double) num == 0.0)
                this.tmpString[panelObjectIdx].FloatToFormat(0.0f);
              else
                this.tmpString[panelObjectIdx].FloatToFormat((float) ((double) (this.DM.mLordStat.BattleWin_Attack + this.DM.mLordStat.BattleWin_Defense) / (double) num * 100.0), 2, false);
              if (!GUIManager.Instance.IsArabic)
                this.tmpString[panelObjectIdx].AppendFormat("{0}%");
              else
                this.tmpString[panelObjectIdx].AppendFormat("%{0}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 8:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.KillSoldiers, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 9:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.KillTraps, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 10:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.LoseSoldiers, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 11:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.LoseTraps, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 12:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.SoldierBeHurtCount, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 13:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.HurtSoldierCount, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 14:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.DestroySite, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 15:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.SiteBeDestroyed, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 16:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].uLongToFormat(this.DM.mLordStat.DamageEnemiesPowerCount, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 17:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              break;
            case 18:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.TroopPower), bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 19:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.TrapPower), bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 20:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.BuildingPower), bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 21:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.MissionPower), bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 22:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.TechPower), bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 23:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.LordPower), bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 24:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              break;
            case 25:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.CaptiveLords, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 26:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.KillLords, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 27:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.LordBeEscaped, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 28:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.LordEscape, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 29:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.LordBeCaptive, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 30:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.LordBeKilled, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 31:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.SaveLordRewordCount, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 32:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              break;
            case 33:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.HelpAlliance_FoodCount, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 34:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.HelpAlliance_RockCount, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 35:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.HelpAlliance_WoodCount, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 36:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.HelpAlliance_OreCount, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 37:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.HelpAlliance_GoldCount, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 38:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.HelpAlliance_TurboCount, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 39:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat(this.DM.mLordStat.GatherCount, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 40:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              break;
            case 41:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.ArenaRank, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 42:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.ArenaHistoryRank, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 43:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.ArenaWins, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 44:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.HeroPower), bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 45:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].uLongToFormat(this.DM.GetPowerByType(EPowerbyKind.PetPower), bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 46:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.PetSkillUsed, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            case 47:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], UILordInfo.RecordFields[constStringID, 0], out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              this.tmpString[panelObjectIdx].IntToFormat((long) this.DM.mLordStat.PetSkillBeenUsed, bNumber: true);
              this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
              SecendText2.text = this.tmpString[panelObjectIdx].ToString();
              SecendText2.SetAllDirty();
              SecendText2.cachedTextGenerator.Invalidate();
              break;
            default:
              this.quickFillRow(item, (eSPDisplayType) UILordInfo.RecordFields[constStringID, 1], (uint) constStringID, out SecendText2);
              this.tmpString[panelObjectIdx].ClearString();
              if (!((UnityEngine.Object) SecendText2 != (UnityEngine.Object) null))
                break;
              SecendText2.text = "---------";
              break;
          }
        }
      }
    }
  }

  private void UpdateEffectRow(GameObject item, int dataIdx, int panelObjectIdx)
  {
    LordEnhanceTbl recordByIndex = this.DM.LordEnhanceTable.GetRecordByIndex((int) (ushort) this.EnhanceShowedIdx[dataIdx]);
    UIText SecendText = item.transform.GetChild(1).GetChild(2).GetComponent<UIText>();
    ((Graphic) SecendText).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 150f);
    long num1 = 0;
    long num2 = 0;
    switch (recordByIndex.Type)
    {
      case 1:
        ItemBuff recordByKey1 = this.DM.ItemBuffTable.GetRecordByKey(recordByIndex.Effect1);
        this.quickFillRow(item, this.Barkind[dataIdx], (uint) recordByKey1.BuffNameID, out SecendText);
        num1 = (long) this.GetBuffTime((int) recordByIndex.Effect1);
        break;
      case 2:
        Effect recordByKey2 = this.DM.EffectData.GetRecordByKey(recordByIndex.Effect1);
        this.quickFillRow(item, this.Barkind[dataIdx], (uint) recordByKey2.InfoID, out SecendText);
        if (recordByIndex.LordEffect != (byte) 0)
        {
          num1 = (long) this.DM.AttribVal.GetEffectBaseValDueLord(recordByIndex.Effect1, false);
          num2 = (long) this.DM.AttribVal.GetEffectBaseValDueLord(recordByIndex.Effect1, true);
        }
        else
          num1 = (long) this.DM.AttribVal.GetEffectBaseValByEffectID(recordByIndex.Effect1);
        if (recordByIndex.Effect2 != (ushort) 0)
          num1 += (long) this.DM.AttribVal.GetEffectBaseValByEffectID(recordByIndex.Effect2);
        ushort id = recordByKey2.ID;
        switch (id)
        {
          case 242:
            num1 = num1 - (long) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 328) - (long) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 327);
            break;
          case 243:
            num1 = num1 - (long) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 329) - (long) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 327);
            break;
          case 244:
            num1 = num1 - (long) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 330) - (long) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 327);
            break;
          case 245:
            num1 = num1 - (long) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 331) - (long) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 327);
            break;
          case 246:
            num1 = num1 - (long) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 332) - (long) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 327);
            break;
          case 248:
            num1 -= (long) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 333);
            break;
          case 249:
            num1 -= (long) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 334);
            break;
          case 251:
            num1 -= (long) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 335);
            break;
          default:
            switch (id)
            {
              case 216:
                uint baseValByEffectId1 = this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 221);
                num1 -= (long) baseValByEffectId1;
                num2 -= (long) baseValByEffectId1;
                if (this.DM.bHaveWarBuff)
                {
                  uint baseValByEffectId2 = this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 349);
                  num1 += (long) baseValByEffectId2;
                  num2 += (long) baseValByEffectId2;
                  break;
                }
                break;
              case 217:
                uint baseValByEffectId3 = this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 222);
                num1 -= (long) baseValByEffectId3;
                num2 -= (long) baseValByEffectId3;
                if (this.DM.bHaveWarBuff)
                {
                  uint baseValByEffectId4 = this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 350);
                  num1 += (long) baseValByEffectId4;
                  num2 += (long) baseValByEffectId4;
                  break;
                }
                break;
              case 218:
                uint baseValByEffectId5 = this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 223);
                num1 -= (long) baseValByEffectId5;
                num2 -= (long) baseValByEffectId5;
                if (this.DM.bHaveWarBuff)
                {
                  uint baseValByEffectId6 = this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 351);
                  num1 += (long) baseValByEffectId6;
                  num2 += (long) baseValByEffectId6;
                  break;
                }
                break;
              case 220:
                num1 -= (long) this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 225);
                break;
            }
            break;
        }
        if (recordByIndex.LordEffect != (byte) 0)
        {
          double f1 = (double) num2 / 100.0;
          this.tmpLordString[panelObjectIdx].ClearString();
          if (f1 < 0.0)
          {
            double f2 = f1 * -1.0;
            this.tmpLordString[panelObjectIdx].DoubleToFormat(f2, 2, false);
            if (!GUIManager.Instance.IsArabic)
              this.tmpLordString[panelObjectIdx].AppendFormat("<color=#FF656EFF>-{0}%</color>");
            else
              this.tmpLordString[panelObjectIdx].AppendFormat("<color=#FF656EFF>%{0}-</color>");
          }
          else
          {
            this.tmpLordString[panelObjectIdx].DoubleToFormat(f1, 2, false);
            if (!GUIManager.Instance.IsArabic)
              this.tmpLordString[panelObjectIdx].AppendFormat("+{0}%");
            else
              this.tmpLordString[panelObjectIdx].AppendFormat("%{0}+");
          }
          item.transform.GetChild(1).GetChild(3).GetComponent<UIText>().text = this.tmpLordString[panelObjectIdx].ToString();
          item.transform.GetChild(1).GetChild(3).GetComponent<UIText>().SetAllDirty();
          item.transform.GetChild(1).GetChild(3).GetComponent<UIText>().cachedTextGenerator.Invalidate();
          break;
        }
        break;
      case 3:
        this.quickFillRow(item, this.Barkind[dataIdx], (uint) recordByIndex.Effect1, out SecendText);
        switch (recordByIndex.Effect2)
        {
          case 1:
            num1 = (long) this.DM.m_WallRepairMaxValue;
            break;
          case 2:
            num1 = (long) this.DM.GetMaxMonsterPoint();
            break;
          case 3:
            num1 = (long) (this.DM.AttribVal.GetEffectBaseValByEffectID((ushort) 320) + 5U);
            break;
        }
        break;
      case 4:
        this.quickFillRow(item, eSPDisplayType.Title, (uint) recordByIndex.Effect1, out SecendText);
        if (recordByIndex.LordEffect == (byte) 0)
        {
          item.transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
          return;
        }
        item.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
        return;
    }
    this.tmpString[panelObjectIdx].ClearString();
    switch (recordByIndex.ValueKind)
    {
      case 1:
        double f = (double) num1 / 100.0;
        this.tmpString[panelObjectIdx].DoubleToFormat(f, 2, false);
        if (f < 0.0)
        {
          if (!GUIManager.Instance.IsArabic)
          {
            this.tmpString[panelObjectIdx].AppendFormat("<color=#FF656EFF>{0}%</color>");
            break;
          }
          this.tmpString[panelObjectIdx].AppendFormat("<color=#FF656EFF>%{0}</color>");
          break;
        }
        if (!GUIManager.Instance.IsArabic)
        {
          this.tmpString[panelObjectIdx].AppendFormat("+{0}%");
          break;
        }
        this.tmpString[panelObjectIdx].AppendFormat("%{0}+");
        break;
      case 2:
        this.tmpString[panelObjectIdx].IntToFormat(num1, bNumber: true);
        this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
        break;
      case 3:
        this.tmpString[panelObjectIdx].Append("<color=#00FF00>");
        GameConstants.GetTimeString(this.tmpString[panelObjectIdx], (uint) num1);
        this.tmpString[panelObjectIdx].Append("</color>");
        break;
      case 4:
        if (!GUIManager.Instance.IsArabic)
        {
          this.tmpString[panelObjectIdx].Append('+');
          GameConstants.GetTimeString(this.tmpString[panelObjectIdx], (uint) num1);
          break;
        }
        GameConstants.GetTimeString(this.tmpString[panelObjectIdx], (uint) num1);
        this.tmpString[panelObjectIdx].Append('+');
        break;
      case 5:
        if (!GUIManager.Instance.IsArabic)
        {
          this.tmpString[panelObjectIdx].Append('+');
          this.tmpString[panelObjectIdx].IntToFormat(num1, bNumber: true);
          this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
          break;
        }
        this.tmpString[panelObjectIdx].IntToFormat(num1, bNumber: true);
        this.tmpString[panelObjectIdx].AppendFormat("{0:N}");
        this.tmpString[panelObjectIdx].Append('+');
        break;
      case 6:
        if (!GUIManager.Instance.IsArabic)
        {
          this.tmpString[panelObjectIdx].Append('+');
          GameConstants.GetTimeString(this.tmpString[panelObjectIdx], (uint) num1 * 60U);
          break;
        }
        GameConstants.GetTimeString(this.tmpString[panelObjectIdx], (uint) num1 * 60U);
        this.tmpString[panelObjectIdx].Append('+');
        break;
      default:
        this.tmpString[panelObjectIdx].Append('0');
        break;
    }
    SecendText.text = this.tmpString[panelObjectIdx].ToString();
    SecendText.SetAllDirty();
    SecendText.cachedTextGenerator.Invalidate();
    if (recordByIndex.LordEffect != (byte) 0)
      item.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
    else
      item.transform.GetChild(1).GetChild(3).gameObject.SetActive(false);
  }

  private uint GetBuffTime(int id)
  {
    int recvBuffDataIdxById = this.DM.GetRecvBuffDataIdxByID((ushort) (byte) id);
    if (recvBuffDataIdxById < 0)
      return 0;
    long num = this.DM.m_RecvItemBuffData[recvBuffDataIdxById].TargetTime - this.DM.ServerTime;
    return num > 0L ? (uint) num : 0U;
  }

  private void quickFillRow(
    GameObject item,
    eSPDisplayType type,
    uint constStringID,
    out UIText SecendText)
  {
    SecendText = (UIText) null;
    switch (type)
    {
      case eSPDisplayType.Title:
        item.transform.GetChild(0).gameObject.SetActive(true);
        item.transform.GetChild(1).gameObject.SetActive(false);
        item.transform.GetChild(0).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(constStringID);
        break;
      case eSPDisplayType.content:
        item.transform.GetChild(0).gameObject.SetActive(false);
        item.transform.GetChild(1).gameObject.SetActive(true);
        item.transform.GetChild(1).GetChild(0).gameObject.SetActive(false);
        item.transform.GetChild(1).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(constStringID);
        SecendText = item.transform.GetChild(1).GetChild(2).GetComponent<UIText>();
        break;
      case eSPDisplayType.HighLightContent:
        item.transform.GetChild(0).gameObject.SetActive(false);
        item.transform.GetChild(1).gameObject.SetActive(true);
        item.transform.GetChild(1).GetChild(0).gameObject.SetActive(true);
        item.transform.GetChild(1).GetChild(1).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(constStringID);
        SecendText = item.transform.GetChild(1).GetChild(2).GetComponent<UIText>();
        break;
      case eSPDisplayType.NoContent:
        item.transform.GetChild(0).gameObject.SetActive(false);
        item.transform.GetChild(1).gameObject.SetActive(false);
        break;
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    UIButton button = sender.m_Button as UIButton;
    switch (button.m_BtnID1)
    {
      case 3:
        if (button.m_BtnID2 < 6)
          break;
        goto case 6;
      case 6:
        UIText component1 = ((Transform) this.HintPanel).GetChild(1).GetComponent<UIText>();
        component1.alignment = TextAnchor.MiddleCenter;
        component1.AdjuestUI();
        RectTransform component2 = ((Transform) this.HintPanel).GetChild(0).GetComponent<RectTransform>();
        switch (button.m_BtnID1)
        {
          case 3:
            if (this.OpenKind != EUILordInfoLayout.LordSelf)
              return;
            component2.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 310f);
            ((Graphic) component1).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 300f);
            RoleBuildingData buildData = GUIManager.Instance.BuildingData.GetBuildData((ushort) 15, (ushort) 0);
            switch (button.m_BtnID2)
            {
              case 7:
                if (buildData.Level >= (byte) 17)
                  return;
                this.hintString.ClearString();
                this.hintString.Append(this.DM.mStringTable.GetStringByID(7401U));
                component1.text = this.hintString.ToString();
                break;
              case 8:
                if (buildData.Level >= (byte) 25)
                  return;
                this.hintString.ClearString();
                this.hintString.Append(this.DM.mStringTable.GetStringByID(7496U));
                component1.text = this.hintString.ToString();
                break;
            }
            component1.SetAllDirty();
            component1.cachedTextGenerator.Invalidate();
            component1.cachedTextGeneratorForLayout.Invalidate();
            float num1 = component1.preferredWidth;
            if ((double) num1 > 300.0)
              num1 = 300f;
            ((Graphic) component1).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num1);
            component2.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num1 + 30f);
            float preferredHeight = component1.preferredHeight;
            ((Graphic) component1).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, preferredHeight);
            component2.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, preferredHeight + 20f);
            sender.GetComponent<RectTransform>();
            this.HintPanel.anchoredPosition = new Vector2(192f, -35f);
            ((Component) this.HintPanel).gameObject.SetActive(true);
            break;
          case 6:
            component2.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 110f);
            ((Graphic) component1).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 100f);
            component1.alignment = !GUIManager.Instance.IsArabic ? TextAnchor.MiddleLeft : TextAnchor.MiddleRight;
            bool flag = false;
            switch (button.m_BtnID2)
            {
              case 1:
                this.hintString.ClearString();
                this.hintString.IntToFormat((long) this.DM.mLordProfile.Enhance);
                this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(7389U));
                component1.text = this.hintString.ToString();
                break;
              case 2:
                this.hintString.ClearString();
                this.hintString.StringToFormat(this.DM.mStringTable.GetStringByID((uint) (ushort) ((uint) this.DM.mLordProfile.Star + 7389U)));
                this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(7387U));
                component1.text = this.hintString.ToString();
                break;
              case 3:
              case 10:
                this.hintString.ClearString();
                this.hintString.Append(this.DM.mStringTable.GetStringByID(7349U));
                component1.text = this.hintString.ToString();
                break;
              case 4:
                this.hintString.ClearString();
                this.hintString.Append(this.DM.mStringTable.GetStringByID(7345U));
                component1.text = this.hintString.ToString();
                break;
              case 5:
                this.hintString.ClearString();
                this.hintString.Append(this.DM.mStringTable.GetStringByID(7346U));
                component1.text = this.hintString.ToString();
                break;
              case 6:
                this.hintString.ClearString();
                this.hintString.Append(this.DM.mStringTable.GetStringByID(7347U));
                component1.text = this.hintString.ToString();
                break;
              case 7:
                this.hintString.ClearString();
                this.hintString.Append(this.DM.mStringTable.GetStringByID(7348U));
                component1.text = this.hintString.ToString();
                break;
              case 8:
                component2.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 110f);
                component2.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 300f);
                ((Graphic) component1).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 110f);
                ((Graphic) component1).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, 250f);
                this.hintString.ClearString();
                this.hintString.Append(this.DM.mStringTable.GetStringByID(880U));
                this.hintString.Append("\n");
                if (this.DM.GetMaxMonsterPoint() > this.DM.RoleAttr.MonsterPoint)
                {
                  this.MonsterTime = (long) ((double) (this.DM.GetMaxMonsterPoint() - this.DM.RoleAttr.MonsterPoint) * ((double) this.DM.RoleAttr.MonsterPointRecoverFrequency / 1000.0));
                  int x1 = (int) this.MonsterTime / 3600;
                  int x2 = (int) this.MonsterTime % 3600 / 60;
                  int x3 = (int) this.MonsterTime % 60;
                  this.hintString.IntToFormat((long) x1, 2);
                  this.hintString.IntToFormat((long) x2, 2);
                  this.hintString.IntToFormat((long) x3, 2);
                  this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(881U));
                  this.isMonsterOpen = true;
                }
                else
                  this.hintString.Append(this.DM.mStringTable.GetStringByID(882U));
                component1.text = this.hintString.ToString();
                break;
              case 9:
                this.hintString.ClearString();
                this.hintString.Append(this.DM.mStringTable.GetStringByID(7698U));
                component1.text = this.hintString.ToString();
                break;
              case 11:
                this.hintString.ClearString();
                this.hintString.Append(this.DM.mStringTable.GetStringByID(9549U));
                this.hintString.Append("\n");
                this.hintString.Append(this.DM.mStringTable.GetStringByID(9551U));
                component1.text = this.hintString.ToString();
                break;
              case 12:
                return;
              case 13:
                return;
              case 14:
                return;
              case 15:
                return;
              case 16:
                return;
              case 17:
                return;
              case 18:
                return;
              case 19:
                return;
              case 20:
                return;
              case 21:
              case 26:
                TitleData recordByKey1;
                if (this.OpenKind != EUILordInfoLayout.LordOther && this.OpenKind != EUILordInfoLayout.RecordInfoOther)
                {
                  if (this.DM.RoleAttr.KingdomTitle == (ushort) 0)
                    return;
                  recordByKey1 = this.DM.TitleData.GetRecordByKey(this.DM.RoleAttr.KingdomTitle);
                }
                else
                {
                  if (this.DM.mLordProfile.Title == (ushort) 0)
                    return;
                  recordByKey1 = this.DM.TitleData.GetRecordByKey(this.DM.mLordProfile.Title);
                }
                this.hintString.ClearString();
                this.hintString.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey1.StringID));
                this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(9370U));
                component1.text = this.hintString.ToString();
                break;
              case 22:
              case 27:
                TitleData recordByKey2;
                if (this.OpenKind != EUILordInfoLayout.LordOther && this.OpenKind != EUILordInfoLayout.RecordInfoOther)
                {
                  if (this.DM.RoleAttr.NobilityTitle == (ushort) 0)
                    return;
                  recordByKey2 = this.DM.TitleDataF.GetRecordByKey(this.DM.RoleAttr.NobilityTitle);
                }
                else
                {
                  if (this.DM.mLordProfile.NobilityTitle == (ushort) 0)
                    return;
                  recordByKey2 = this.DM.TitleDataF.GetRecordByKey(this.DM.mLordProfile.NobilityTitle);
                }
                this.hintString.ClearString();
                this.hintString.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey2.StringID));
                this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(11152U));
                component1.text = this.hintString.ToString();
                break;
              case 23:
              case 28:
                TitleData recordByKey3;
                if (this.OpenKind != EUILordInfoLayout.LordOther && this.OpenKind != EUILordInfoLayout.RecordInfoOther)
                {
                  if (this.DM.RoleAttr.WorldTitle_Personal == (ushort) 0)
                    return;
                  recordByKey3 = this.DM.TitleDataW.GetRecordByKey(this.DM.RoleAttr.WorldTitle_Personal);
                }
                else
                {
                  if (this.DM.mLordProfile.WorldTitle == (ushort) 0)
                    return;
                  recordByKey3 = this.DM.TitleDataW.GetRecordByKey(this.DM.mLordProfile.WorldTitle);
                }
                this.hintString.ClearString();
                this.hintString.StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey3.StringID));
                this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(11032U));
                component1.text = this.hintString.ToString();
                break;
              case 24:
                return;
              case 25:
                this.hintString.ClearString();
                this.hintString.IntToFormat((long) this.DM.mLordProfile.TotalCastleStar);
                this.hintString.AppendFormat(this.DM.mStringTable.GetStringByID(11056U));
                component1.text = this.hintString.ToString();
                break;
              default:
                return;
            }
            float num2 = 0.0f;
            float num3 = 0.0f;
            if (!flag)
            {
              component1.SetAllDirty();
              component1.cachedTextGenerator.Invalidate();
              component1.cachedTextGeneratorForLayout.Invalidate();
              num2 = component1.preferredWidth;
              if ((double) num2 > 350.0)
                num2 = 300f;
              ((Graphic) component1).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num2);
              component2.SetSizeWithCurrentAnchors((RectTransform.Axis) 0, num2 + 30f);
              num3 = component1.preferredHeight;
              ((Graphic) component1).rectTransform.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, num3);
              component2.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, num3 + 20f);
            }
            Vector2 anchoredPosition1 = sender.GetComponent<RectTransform>().anchoredPosition;
            int btnId2 = button.m_BtnID2;
            switch (btnId2)
            {
              case 0:
              case 1:
              case 2:
              case 3:
                anchoredPosition1.x += (float) ((double) num2 / 2.0 - 40.0);
                anchoredPosition1.y -= (float) (20.0 + (double) num3 / 2.0);
                break;
              case 8:
              case 10:
                anchoredPosition1.x += (float) ((double) num2 / 2.0 - 280.0);
                anchoredPosition1.y += (float) (130.0 - (double) num3 / 2.0);
                break;
              default:
                switch (btnId2 - 21)
                {
                  case 0:
                  case 1:
                  case 2:
                    ((Component) this.HintPanel).gameObject.SetActive(true);
                    sender.GetTipPosition(this.HintPanel);
                    component1.SetAllDirty();
                    component1.cachedTextGenerator.Invalidate();
                    Vector2 anchoredPosition2 = this.HintPanel.anchoredPosition;
                    anchoredPosition2.x += 230f;
                    anchoredPosition2.y += num3 - 140f;
                    this.HintPanel.anchoredPosition = anchoredPosition2;
                    ((Component) this.HintPanel).transform.localPosition = ((Component) this.HintPanel).transform.localPosition with
                    {
                      z = -1000f
                    };
                    this.lastHint = sender;
                    return;
                  case 4:
                    ((Component) this.HintPanel).gameObject.SetActive(true);
                    sender.GetTipPosition(this.HintPanel);
                    component1.SetAllDirty();
                    component1.cachedTextGenerator.Invalidate();
                    Vector2 anchoredPosition3 = this.HintPanel.anchoredPosition;
                    anchoredPosition3.x += num2 - 60f;
                    this.HintPanel.anchoredPosition = anchoredPosition3;
                    ((Component) this.HintPanel).transform.localPosition = ((Component) this.HintPanel).transform.localPosition with
                    {
                      z = -1000f
                    };
                    this.lastHint = sender;
                    return;
                  case 5:
                  case 6:
                  case 7:
                    ((Component) this.HintPanel).gameObject.SetActive(true);
                    ((Transform) this.HintPanel).position = sender.transform.position;
                    component1.SetAllDirty();
                    component1.cachedTextGenerator.Invalidate();
                    Vector2 anchoredPosition4 = this.HintPanel.anchoredPosition;
                    anchoredPosition4.x += (float) ((double) num2 / 2.0 + 15.0);
                    anchoredPosition4.y += (float) ((double) num3 / 2.0 + 5.0);
                    this.HintPanel.anchoredPosition = anchoredPosition4;
                    ((Component) this.HintPanel).transform.localPosition = ((Component) this.HintPanel).transform.localPosition with
                    {
                      z = -1000f
                    };
                    this.lastHint = sender;
                    return;
                  default:
                    anchoredPosition1.x += num2 / 2f;
                    anchoredPosition1.y -= (float) (20.0 + (double) num3 / 2.0);
                    break;
                }
                break;
            }
            this.HintPanel.anchoredPosition = anchoredPosition1;
            ((Component) this.HintPanel).gameObject.SetActive(true);
            break;
        }
        component1.SetAllDirty();
        component1.cachedTextGenerator.Invalidate();
        this.lastHint = sender;
        break;
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    this.isMonsterOpen = false;
    if ((UnityEngine.Object) sender != (UnityEngine.Object) this.lastHint)
      return;
    ((Component) this.HintPanel).gameObject.SetActive(false);
  }

  public void Update()
  {
    this.GetPointTime += Time.smoothDeltaTime;
    if ((double) this.GetPointTime >= 2.0)
      this.GetPointTime = 0.0f;
    Color color = new Color(1f, 1f, 1f, (double) this.GetPointTime <= 1.0 ? this.GetPointTime : 2f - this.GetPointTime);
    if (((Component) this.BarLight).gameObject.activeInHierarchy)
      ((Graphic) this.BarLight).color = color;
    for (int index = 0; index < this.LEquipLight.Length; ++index)
    {
      if (((Component) this.LEquipLight[index]).gameObject.activeInHierarchy)
        ((Graphic) this.LEquipLight[index]).color = color;
    }
    if (!this.DefaultActionLateUpdate)
      ;
    switch (this.OpenKind)
    {
      case EUILordInfoLayout.RecordInfo:
        break;
      case EUILordInfoLayout.RecordInfoOther:
        break;
      case EUILordInfoLayout.EnhanceInfo:
        break;
      default:
        switch (this.LoadingStep)
        {
          case UILordInfo.eModelLoadingStep.WaitforHero:
            if (!this.bundleRequest.isDone)
              return;
            ((Component) this.Hero_PosRT).gameObject.SetActive(true);
            this.Holder1 = (GameObject) UnityEngine.Object.Instantiate(this.bundleRequest.asset);
            this.Holder1.transform.SetParent((Transform) this.Hero_PosRT, false);
            this.Holder1.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
            {
              eulerAngles = new Vector3(0.0f, (float) this.sHero.Camera_Horizontal, 0.0f)
            };
            this.Holder1.transform.localScale = new Vector3((float) this.sHero.CameraScaleRate, (float) this.sHero.CameraScaleRate, (float) this.sHero.CameraScaleRate);
            this.Holder1.transform.localPosition = Vector3.zero;
            GUIManager.Instance.SetLayer(this.Holder1, 5);
            Transform transform = this.Holder1.transform;
            if (!((UnityEngine.Object) transform != (UnityEngine.Object) null))
              return;
            transform.GetComponentInChildren<SkinnedMeshRenderer>().useLightProbes = false;
            transform.GetComponentInChildren<SkinnedMeshRenderer>().updateWhenOffscreen = true;
            Animation component1 = transform.GetComponent<Animation>();
            component1.cullingType = AnimationCullingType.AlwaysAnimate;
            component1[AnimationUnit.ANIM_STRING[0]].layer = 0;
            component1[AnimationUnit.ANIM_STRING[0]].wrapMode = WrapMode.Loop;
            component1[AnimationUnit.ANIM_STRING[1]].layer = 0;
            component1[AnimationUnit.ANIM_STRING[1]].wrapMode = WrapMode.Loop;
            component1[AnimationUnit.ANIM_STRING[2]].layer = 1;
            component1[AnimationUnit.ANIM_STRING[2]].wrapMode = WrapMode.Once;
            if ((UnityEngine.Object) component1.GetClip(AnimationUnit.ANIM_STRING[3]) != (UnityEngine.Object) null)
            {
              component1[AnimationUnit.ANIM_STRING[3]].layer = 1;
              component1[AnimationUnit.ANIM_STRING[3]].wrapMode = WrapMode.Once;
            }
            if ((UnityEngine.Object) component1.GetClip(AnimationUnit.ANIM_STRING[4]) != (UnityEngine.Object) null)
            {
              component1[AnimationUnit.ANIM_STRING[4]].layer = 1;
              component1[AnimationUnit.ANIM_STRING[4]].wrapMode = WrapMode.Once;
            }
            if ((UnityEngine.Object) component1.GetClip(AnimationUnit.ANIM_STRING[5]) != (UnityEngine.Object) null)
            {
              component1[AnimationUnit.ANIM_STRING[5]].layer = 1;
              component1[AnimationUnit.ANIM_STRING[5]].wrapMode = WrapMode.Once;
            }
            component1[AnimationUnit.ANIM_STRING[7]].layer = 1;
            component1[AnimationUnit.ANIM_STRING[7]].wrapMode = WrapMode.ClampForever;
            component1[AnimationUnit.ANIM_STRING[9]].layer = 1;
            component1[AnimationUnit.ANIM_STRING[9]].wrapMode = WrapMode.Loop;
            component1[AnimationUnit.ANIM_STRING[8]].layer = 1;
            component1[AnimationUnit.ANIM_STRING[8]].wrapMode = WrapMode.Once;
            component1.Play(AnimationUnit.ANIM_STRING[0]);
            this.LoadingStep = UILordInfo.eModelLoadingStep.HeroReady;
            this.SetModelDefaultAction();
            if (this.OpenKind != EUILordInfoLayout.LordSelf || this.DM.beCaptured.nowCaptureStat != LoadCaptureState.Captured)
              return;
            CString Name1 = StringManager.Instance.StaticString1024();
            Name1.Append("Role/cage");
            this.bundle = AssetManager.GetAssetBundle(Name1, out this.AssetKey1);
            this.bundleRequest = this.bundle.LoadAsync("m", typeof (GameObject));
            this.LoadingStep = UILordInfo.eModelLoadingStep.WaitforCage;
            return;
          case UILordInfo.eModelLoadingStep.HeroReady:
          case UILordInfo.eModelLoadingStep.Done:
            if ((UnityEngine.Object) this.Holder1 == (UnityEngine.Object) null || this.DM.beCaptured.nowCaptureStat != LoadCaptureState.None || (double) Time.time <= (double) this.NextActionTime)
              return;
            Animation component2 = this.Holder1.GetComponent<Animation>();
            this.NextActionTime = Time.time + 5f;
            component2.CrossFade(AnimationUnit.ANIM_STRING[0]);
            switch (UnityEngine.Random.Range(0, 5))
            {
              case 0:
                component2.CrossFade(AnimationUnit.ANIM_STRING[2]);
                return;
              case 1:
                if ((UnityEngine.Object) component2.GetClip(AnimationUnit.ANIM_STRING[3]) != (UnityEngine.Object) null)
                {
                  component2.CrossFade(AnimationUnit.ANIM_STRING[3]);
                  return;
                }
                component2.CrossFade(AnimationUnit.ANIM_STRING[1]);
                return;
              case 2:
                if ((UnityEngine.Object) component2.GetClip(AnimationUnit.ANIM_STRING[4]) != (UnityEngine.Object) null)
                {
                  component2.CrossFade(AnimationUnit.ANIM_STRING[4]);
                  return;
                }
                component2.CrossFade(AnimationUnit.ANIM_STRING[1]);
                return;
              case 3:
                if ((UnityEngine.Object) component2.GetClip(AnimationUnit.ANIM_STRING[5]) != (UnityEngine.Object) null)
                {
                  component2.CrossFade(AnimationUnit.ANIM_STRING[5]);
                  return;
                }
                component2.CrossFade(AnimationUnit.ANIM_STRING[1]);
                return;
              case 4:
                component2.CrossFade(AnimationUnit.ANIM_STRING[8]);
                return;
              case 5:
                component2.CrossFade(AnimationUnit.ANIM_STRING[1]);
                return;
              default:
                return;
            }
          case UILordInfo.eModelLoadingStep.WaitforCage:
            if (!this.bundleRequest.isDone)
              return;
            ((Component) this.Hero_PosRT).gameObject.SetActive(true);
            this.Holder2 = (GameObject) UnityEngine.Object.Instantiate(this.bundleRequest.asset);
            this.Holder2.transform.SetParent((Transform) this.Hero_PosRT, false);
            this.Holder2.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f)
            {
              eulerAngles = new Vector3(0.0f, 6f, 0.0f)
            };
            this.Holder2.transform.localScale = new Vector3(55f, 50f, 55f);
            this.Holder2.transform.localPosition = Vector3.zero;
            GUIManager.Instance.SetLayer(this.Holder2, 5);
            this.Holder2.GetComponentInChildren<MeshRenderer>().useLightProbes = false;
            CString Name2 = StringManager.Instance.StaticString1024();
            Name2.IntToFormat((long) this.sHero.Modle, 5);
            Name2.AppendFormat("Role/hero_{0}");
            this.bundle = AssetManager.GetAssetBundle(Name2, out this.AssetKey2);
            if ((UnityEngine.Object) this.bundle == (UnityEngine.Object) null)
            {
              this.LoadingStep = UILordInfo.eModelLoadingStep.Done;
              return;
            }
            this.bundleRequest = this.bundle.LoadAsync("m", typeof (GameObject));
            this.LoadingStep = UILordInfo.eModelLoadingStep.Done;
            return;
          default:
            return;
        }
    }
  }

  public void OnEnable() => this.SetModelDefaultAction();

  private void Create3DObjects()
  {
    this.Destory3DObject();
    CString Name = StringManager.Instance.StaticString1024();
    Name.IntToFormat((long) this.sHero.Modle, 5);
    Name.AppendFormat("Role/hero_{0}");
    if (!AssetManager.GetAssetBundleDownload(Name, AssetPath.Role, AssetType.Hero, this.sHero.Modle))
    {
      this.LoadingStep = UILordInfo.eModelLoadingStep.Done;
    }
    else
    {
      this.bundle = AssetManager.GetAssetBundle(Name, out this.AssetKey2);
      if ((UnityEngine.Object) this.bundle == (UnityEngine.Object) null)
      {
        this.LoadingStep = UILordInfo.eModelLoadingStep.Done;
      }
      else
      {
        this.bundleRequest = this.bundle.LoadAsync("m", typeof (GameObject));
        this.LoadingStep = UILordInfo.eModelLoadingStep.WaitforHero;
      }
    }
  }

  private void Destory3DObject(bool JailOnly = false)
  {
    if (!JailOnly)
    {
      if ((UnityEngine.Object) this.Holder1 != (UnityEngine.Object) null)
      {
        UnityEngine.Object.Destroy((UnityEngine.Object) this.Holder1);
        this.Holder1 = (GameObject) null;
      }
      if (this.AssetKey1 != 0)
        AssetManager.UnloadAssetBundle(this.AssetKey1, false);
    }
    if ((UnityEngine.Object) this.Holder2 != (UnityEngine.Object) null)
    {
      UnityEngine.Object.Destroy((UnityEngine.Object) this.Holder2);
      this.Holder2 = (GameObject) null;
    }
    if (this.AssetKey2 != 0)
      AssetManager.UnloadAssetBundle(this.AssetKey2, false);
    this.bundle = (AssetBundle) null;
    if (JailOnly)
      this.LoadingStep = UILordInfo.eModelLoadingStep.HeroReady;
    else
      this.LoadingStep = UILordInfo.eModelLoadingStep.Start;
  }

  private void SetModelDefaultAction()
  {
    if (this.LoadingStep < UILordInfo.eModelLoadingStep.HeroReady || (UnityEngine.Object) this.Holder1 == (UnityEngine.Object) null)
      return;
    if (this.OpenKind == EUILordInfoLayout.LordOther)
    {
      this.Holder1.GetComponent<Animation>().Play(AnimationUnit.ANIM_STRING[0]);
      this.HeroRotater.enabled = true;
      this.HeroRotater.transform.localPosition = new Vector3(0.0f, -60f, -1000f);
    }
    else
    {
      this.HeroRotater.transform.localPosition = new Vector3(-150f, -60f, -1000f);
      Quaternion quaternion = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
      quaternion.eulerAngles = new Vector3(0.0f, (float) this.sHero.Camera_Horizontal, 0.0f);
      this.Holder1.transform.localRotation = quaternion;
      this.Holder1.transform.localScale = new Vector3((float) this.sHero.CameraScaleRate, (float) this.sHero.CameraScaleRate, (float) this.sHero.CameraScaleRate);
      this.Holder1.transform.localPosition = Vector3.zero;
      this.HeroRotater.ReSetHero();
      switch (this.DM.beCaptured.nowCaptureStat)
      {
        case LoadCaptureState.None:
          this.Holder1.GetComponent<Animation>().Play(AnimationUnit.ANIM_STRING[0]);
          this.HeroRotater.enabled = true;
          break;
        case LoadCaptureState.Returning:
          this.Holder1.GetComponent<Animation>().Play(AnimationUnit.ANIM_STRING[1]);
          this.HeroRotater.enabled = false;
          break;
        case LoadCaptureState.Dead:
          Animation component = this.Holder1.GetComponent<Animation>();
          component.clip = component.GetClip(AnimationUnit.ANIM_STRING[7]);
          component.Play(AnimationUnit.ANIM_STRING[7], PlayMode.StopAll);
          component[AnimationUnit.ANIM_STRING[7]].normalizedTime = 1f;
          ((Transform) this.Hero_PosRT).localEulerAngles = new Vector3(320f, 0.0f, 0.0f);
          quaternion = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
          quaternion.eulerAngles = new Vector3(0.0f, (float) this.sHero.Camera_Angle_Prison, 0.0f);
          this.Holder1.transform.localRotation = quaternion;
          this.Holder1.transform.localScale = new Vector3((float) this.sHero.CameraScaleRate, (float) this.sHero.CameraScaleRate, (float) this.sHero.CameraScaleRate);
          this.Holder1.transform.localPosition = new Vector3((float) ((int) this.sHero.CameraYAxis_Prison - 500), 0.0f, (float) ((int) this.sHero.CameraXAxis_Prison - 500));
          this.HeroRotater.enabled = false;
          this.DefaultActionLateUpdate = false;
          break;
        default:
          this.Holder1.GetComponent<Animation>().Play(AnimationUnit.ANIM_STRING[9]);
          this.HeroRotater.enabled = false;
          break;
      }
    }
  }

  private void SetPopUp(bool bPop)
  {
    if (this.popUp == bPop)
      return;
    this.popUp = bPop;
    ((Component) this.PopupPanel).gameObject.SetActive(this.popUp);
    bool flag = DataManager.MapDataController.IsWorldKing() | DataManager.MapDataController.IsWorldChief();
    if ((DataManager.MapDataController.IsKing() || DataManager.MapDataController.IsKingdomChief()) && (int) DataManager.MapDataController.kingdomData.kingdomID == (int) this.DM.mLordProfile.KindomID)
      flag = true;
    if ((DataManager.MapDataController.IsNobilityKing() || DataManager.MapDataController.IsNobilityChief()) && ActivityManager.Instance.CheckCanonizationNoility(this.DM.mLordProfile.KindomID) && this.DM.mLordProfile.NobilityTitle != (ushort) 1)
      flag = true;
    int num1 = 0;
    if (this.DM.RoleAlliance.Rank < AllianceRank.RANK4 || this.DM.mLordProfile.AlliRank > (byte) 0)
    {
      ((Transform) this.PopupPanel).GetChild(0).GetChild(2).gameObject.SetActive(false);
      RectTransform component = ((Transform) this.PopupPanel).GetChild(0).GetComponent<RectTransform>();
      component.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 300f);
      component.anchoredPosition = Vector2.zero;
      ((Transform) this.PopupPanel).GetChild(0).GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(0.5f, -194.5f);
    }
    else
    {
      ((Transform) this.PopupPanel).GetChild(0).GetChild(2).gameObject.SetActive(true);
      RectTransform component = ((Transform) this.PopupPanel).GetChild(0).GetComponent<RectTransform>();
      component.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, 378f);
      component.anchoredPosition = Vector2.zero;
      ((Transform) this.PopupPanel).GetChild(0).GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(0.5f, -276.5f);
      ++num1;
    }
    int num2 = num1 + 1;
    ((Transform) this.PopupPanel).GetChild(0).GetChild(1).gameObject.SetActive(true);
    ((Transform) this.PopupPanel).GetChild(0).GetChild(1).GetChild(1).GetComponent<UIText>().text = !this.DM.FindBlackList(this.DM.mLordProfile.PlayerName) ? this.DM.mStringTable.GetStringByID(8212U) : this.DM.mStringTable.GetStringByID(8213U);
    int num3 = num2 + 1;
    if (this.DM.RoleAlliance.Rank > AllianceRank.NULL && (int) this.DM.RoleAlliance.Id == (int) this.DM.mLordProfile.AlliID && this.OpenKind == EUILordInfoLayout.LordOther)
    {
      ((Transform) this.PopupPanel).GetChild(0).GetChild(4).gameObject.SetActive(true);
      ((Transform) this.PopupPanel).GetChild(0).GetChild(3).gameObject.SetActive(true);
      int num4 = num3 + 2;
      ((Transform) this.PopupPanel).GetChild(0).GetChild(6).gameObject.SetActive(true);
      RectTransform component = ((Transform) this.PopupPanel).GetChild(0).GetChild(6).GetComponent<RectTransform>();
      ((Component) component).gameObject.SetActive(true);
      component.anchoredPosition = new Vector2(0.5f, -116f - (float) (78 * num4));
      num3 = num4 + 1;
    }
    else
    {
      ((Transform) this.PopupPanel).GetChild(0).GetChild(4).gameObject.SetActive(false);
      ((Transform) this.PopupPanel).GetChild(0).GetChild(3).gameObject.SetActive(false);
      ((Transform) this.PopupPanel).GetChild(0).GetChild(6).gameObject.SetActive(false);
    }
    if (flag && this.OpenKind == EUILordInfoLayout.LordOther)
    {
      RectTransform component = ((Transform) this.PopupPanel).GetChild(0).GetChild(5).GetComponent<RectTransform>();
      ((Component) component).gameObject.SetActive(true);
      component.anchoredPosition = new Vector2(0.5f, -116f - (float) (78 * num3));
      ++num3;
    }
    else
      ((Transform) this.PopupPanel).GetChild(0).GetChild(5).gameObject.SetActive(false);
    Debug.Log((object) ("Block count :" + (object) num3));
    RectTransform component1 = ((Transform) this.PopupPanel).GetChild(0).GetComponent<RectTransform>();
    component1.SetSizeWithCurrentAnchors((RectTransform.Axis) 1, (float) (136 + 78 * num3));
    component1.anchoredPosition = Vector2.zero;
  }

  public void OpenTitleGive()
  {
    bool flag1 = DataManager.MapDataController.IsKing();
    if (flag1)
      flag1 = (int) DataManager.MapDataController.kingdomData.kingdomID == (int) this.DM.mLordProfile.KindomID;
    bool flag2 = DataManager.MapDataController.IsWorldKing();
    if (flag1 && flag2)
      GUIManager.Instance.OpenCanonizedPanel(this.DM.mLordProfile.PlayerName, (byte) 1, 3);
    else if (flag1)
    {
      TitleManager.Instance.OpenTitleSet(this.DM.mLordProfile.PlayerName);
    }
    else
    {
      if (!flag2)
        return;
      TitleManager.Instance.OpenTitleListW(this.DM.mLordProfile.PlayerName);
    }
  }

  private enum e_AGS_UI_LordInfo_Editor
  {
    bgPanel,
    closeImg,
    HeaderLayer,
    SideBtnLayer,
    MoveRound,
    ItemLayer,
    EnBar,
    LevelIcon,
    ChangeBtn,
    HeroRank,
    HeroBadge,
    T3DObject,
    LightObject,
    TitlePanel,
    ScrollPanelLayer,
    JailerLayer,
    RescureLayer,
    CaptureBarLayer,
    PopupLayer,
    Hint,
    Titlebg,
    ESportSideLayer,
  }

  private enum e_AGS_Panel
  {
    Panellayer,
    PanelCover,
  }

  private enum e_AGS_HeaderLayer
  {
    btn_BuffInfo,
    HeadBGImage,
    NameText,
    RenameBtn,
    MessageBtn,
    PowerValue,
    KillCount,
    GuildInfoBtn,
    GuildRank,
    KillIcon,
    VIPIcon,
    VIPLevel,
    InfoIcon,
    KillHint,
    PowerHint,
    KingdomHint,
    ESProfileBtn,
  }

  private enum e_AGS_GuildInfoBtn
  {
    GuildLogo,
  }

  private enum e_AGS_SideBtnLayer
  {
    Btn1,
    Btn2,
    Btn3,
    Btn4,
  }

  private enum e_AGS_ItemLayer
  {
    Shadow1,
    Shadow2,
    Shadow3,
    Shadow4,
    Shadow5,
    Shadow6,
    Shadow7,
    Shadow8,
    Pos1,
    Pos2,
    Pos3,
    Pos4,
    Pos5,
    Pos6,
    Pos7,
    Pos8,
    UILEBtn1,
    UILEBtn2,
    UILEBtn3,
    UILEBtn4,
    UILEBtn5,
    UILEBtn6,
    UILEBtn7,
    UILEBtn8,
    Lock7,
    Lock8,
  }

  private enum e_AGS_EnBar
  {
    EnBarBack,
    ExpBarBack,
    EnBarValue,
    BarValue,
    EnButton,
    ExpButton,
    Image,
    ENText,
    ExpText,
  }

  private enum e_AGS_LevelIcon
  {
    LevelText,
    CastleLevelIcon,
  }

  private enum e_AGS_LightObject
  {
    LightGroup1,
    LightGroup2,
  }

  private enum e_AGS_TitlePanel
  {
    TitleLabel,
    TitleIcon,
    TitleName,
    TitleLabel2,
    TitleIcon2,
    TitleName2,
    TitleLabel3,
    TitleIcon3,
    TitleName3,
  }

  private enum e_AGS_ScrollPanelLayer
  {
    ScrollPanel,
    ScrollItem,
    TitlePanel,
    TitlePanel2,
    TitlePanel3,
  }

  private enum e_AGS_ScrollItem
  {
    TitleBar,
    NormalBar,
  }

  private enum e_AGS_TitleBar
  {
    Text,
    Text2,
  }

  private enum e_AGS_NormalBar
  {
    Bg,
    Text1,
    Text2,
    Text3,
  }

  private enum e_AGS_TitlePanel2
  {
    bg,
    icon,
    Text,
    Text2,
  }

  private enum e_AGS_JailerLayer
  {
    panelbg,
    HeadBg,
    Head,
    MailBtm,
    MapPointBtn,
    Holder,
    HolderName,
    HolderMapPos,
    HolderUnderLine,
    BountyText,
    BountyValue,
    Coin,
    BountyBtn,
    shadow,
    RensomBg,
    RensomText,
    RensomCoin,
    RensomValue,
    PayRensomBtn,
  }

  private enum e_AGS_CaptureBarLayer
  {
    BarLight,
    BarBg,
    Bar,
    BarStat,
    BarTime,
    Res,
    SpeedUp,
  }

  private enum e_AGS_PopupLayer
  {
    OverPanel,
  }

  private enum e_AGS_OverPanel
  {
    POPMail,
    POPBlock,
    POPAdd,
    POPResourceTransport,
    POPReinforce,
    POPRanking,
    POPReinforce2,
  }

  private enum e_AGS_POPMail
  {
    Image,
    Text,
  }

  private enum e_AGS_POPBlock
  {
    Image,
    Text,
  }

  private enum e_AGS_POPAdd
  {
    Image,
    Text,
  }

  private enum e_AGS_Hint
  {
    HintPanel,
    HintText,
  }

  private enum e_AGS_Titlebg
  {
    Title,
  }

  private enum e_AGS_ESportSideLayer
  {
    SideC1,
    SideC2,
    SideC3,
    SideC4,
  }

  private enum e_AGS_SideC1
  {
    BgLight,
    IconBg,
    IconLight,
  }

  private enum eModelLoadingStep
  {
    Start,
    WaitforHero,
    HeroReady,
    WaitforCage,
    Done,
  }
}
