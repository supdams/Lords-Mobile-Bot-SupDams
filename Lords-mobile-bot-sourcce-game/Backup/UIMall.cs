// Decompiled with JetBrains decompiler
// Type: UIMall
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIMall : 
  GUIWindow,
  UILoadImageHander,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private const int UnitCount = 5;
  private Transform m_transform;
  private Transform UnitObjectT;
  private Transform LightT;
  private DataManager DM;
  private GUIManager GM;
  private MallManager MM;
  private Font tmpFont;
  private CScrollRect cScrollRect;
  private ScrollPanel Scroll;
  private List<float> NowHeightList = new List<float>();
  private bool[] bFindScrollComp = new bool[5];
  private UnitComp_Mall[] ScrollComp = new UnitComp_Mall[5];
  private CString[] TimeStr = new CString[5];
  private CString[] CrystalStr = new CString[5];
  private CString[] CrystalStr2 = new CString[5];
  private CString[] PriceStr = new CString[5];
  private CString[][] ItemCountStr = new CString[5][];
  private CString NowCrystalStr;
  private CString FGStr;
  private CString[] DisStr = new CString[5];
  private CString[] PriceStr2 = new CString[5];
  private UIText LiveChatText;
  private UIText HintText;
  private UIText FGText;
  private bool bMain;
  private GameObject ArrowObj;
  private GameObject HintObj;
  private GameObject FGGO;
  private uTweenPosition ArrowPos;
  private bool bShowArrow;
  private float CheckTimer;
  private float BeginPos;
  private bool NeedUpDate;
  private bool IsJapan = DataManager.Instance.UserLanguage == GameLanguage.GL_Jpn;
  private CString[] JHintStr = new CString[2];
  private GameObject JPHintObject;
  private UIText[] JPText = new UIText[5];
  private Color TimeTextColor = new Color(1f, 0.9411f, 0.5568f);
  private bool bResourceRed;
  private float ResourceRedTime;
  private Image FGImage1;
  private Image FGImage2;
  private RectTransform FGRC;
  private Image EffectImage1;
  private Image EffectImage2;
  private RectTransform EffectRC;
  private Transform EffectPos;
  private Image FGEffImage1;
  private Image FGEffImage2;
  private UIText FGEffText;
  private CString FGEffStr;
  private bool bPlayGetCrystal;
  private float GetCrystalTime = 1.3f;
  private float GetCrystalNowTime;
  private float EffectTimer;
  private float FGTimer;
  private float EffectScale;
  private float Effectalpha;
  private Vector2 bezierEnd = Vector2.zero;
  private GameObject EffectParticle;
  private bool EffectReverse;
  private bool bOpenShowEffect;
  private float OpenShowTime = 0.5f;

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Mall);
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.MM = MallManager.Instance;
    this.m_transform = this.transform;
    this.tmpFont = this.GM.GetTTFFont();
    this.m_transform.GetChild(4).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(4).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(4).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(4).GetComponent<CustomImage>()).enabled = false;
    this.m_transform.GetChild(5).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.LiveChatText = this.m_transform.GetChild(5).GetChild(0).GetComponent<UIText>();
    this.LiveChatText.font = this.tmpFont;
    this.m_transform.GetChild(5).gameObject.AddComponent<ArabicItemTextureRot>();
    this.LightT = this.m_transform.GetChild(9);
    this.m_transform.GetChild(10).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.FGGO = this.m_transform.GetChild(10).gameObject;
    this.FGGO.AddComponent<ArabicItemTextureRot>();
    this.FGRC = this.m_transform.GetChild(10).GetComponent<RectTransform>();
    this.FGImage1 = this.m_transform.GetChild(10).GetChild(0).GetComponent<Image>();
    this.FGImage2 = this.m_transform.GetChild(10).GetChild(0).GetChild(0).GetComponent<Image>();
    this.FGText = this.m_transform.GetChild(10).GetChild(0).GetChild(1).GetComponent<UIText>();
    this.FGText.font = this.tmpFont;
    this.FGStr = StringManager.Instance.SpawnString();
    this.FGEffImage1 = this.m_transform.GetChild(10).GetChild(0).GetChild(2).GetComponent<Image>();
    this.FGEffImage2 = this.m_transform.GetChild(10).GetChild(0).GetChild(3).GetComponent<Image>();
    this.FGEffText = this.m_transform.GetChild(10).GetChild(0).GetChild(4).GetComponent<UIText>();
    this.FGEffText.font = this.tmpFont;
    this.FGEffStr = StringManager.Instance.SpawnString();
    if (this.DM.UserLanguage == GameLanguage.GL_Eng || this.DM.UserLanguage == GameLanguage.GL_Idn)
    {
      this.LiveChatText.text = this.DM.mStringTable.GetStringByID(8458U);
    }
    else
    {
      this.m_transform.GetChild(5).GetComponent<UISpritesArray>().SetSpriteIndex(1);
      this.LiveChatText.text = this.DM.mStringTable.GetStringByID(7098U);
    }
    this.HintObj = this.m_transform.GetChild(6).gameObject;
    this.HintText = this.HintObj.transform.GetChild(0).GetComponent<UIText>();
    this.HintText.font = this.tmpFont;
    this.HintText.text = this.DM.mStringTable.GetStringByID(907U);
    Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
    if ((Object) menu != (Object) null)
    {
      Image component = this.HintObj.transform.GetComponent<Image>();
      component.sprite = menu.LoadSprite("UI_main_display");
      ((MaskableGraphic) component).material = menu.LoadMaterial();
    }
    this.ArrowObj = this.m_transform.GetChild(7).gameObject;
    this.ArrowPos = this.m_transform.GetChild(7).GetComponent<uTweenPosition>();
    if (this.IsJapan)
    {
      Transform child = this.m_transform.GetChild(8);
      this.JPHintObject = child.gameObject;
      this.JPText[0] = child.GetChild(0).GetComponent<UIText>();
      this.JPText[0].font = this.tmpFont;
      this.JPText[0].text = this.DM.mStringTable.GetStringByID(913U);
      this.JPText[1] = child.GetChild(1).GetComponent<UIText>();
      this.JPText[1].font = this.tmpFont;
      this.JPText[1].text = this.DM.mStringTable.GetStringByID(914U);
      this.JPText[2] = child.GetChild(2).GetComponent<UIText>();
      this.JPText[2].font = this.tmpFont;
      this.JHintStr[0] = StringManager.Instance.SpawnString(100);
      this.JHintStr[0].IntToFormat((long) this.DM.RoleAttr.PaidCrystal, bNumber: true);
      this.JHintStr[0].AppendFormat(this.DM.mStringTable.GetStringByID(915U));
      this.JPText[2].text = this.JHintStr[0].ToString();
      this.JPText[2].SetAllDirty();
      this.JPText[2].cachedTextGenerator.Invalidate();
      this.JPText[3] = child.GetChild(3).GetComponent<UIText>();
      this.JPText[3].font = this.tmpFont;
      this.JHintStr[1] = StringManager.Instance.SpawnString(100);
      this.JHintStr[1].IntToFormat((long) (this.DM.RoleAttr.Diamond - this.DM.RoleAttr.PaidCrystal), bNumber: true);
      this.JHintStr[1].AppendFormat(this.DM.mStringTable.GetStringByID(916U));
      this.JPText[3].text = this.JHintStr[1].ToString();
      this.JPText[3].SetAllDirty();
      this.JPText[3].cachedTextGenerator.Invalidate();
      this.JPText[4] = child.GetChild(4).GetComponent<UIText>();
      this.JPText[4].font = this.tmpFont;
      this.JPText[4].text = this.DM.mStringTable.GetStringByID(917U);
    }
    this.UnitObjectT = this.m_transform.GetChild(3);
    Transform child1 = this.UnitObjectT.GetChild(1);
    child1.GetChild(0).GetComponent<UIText>().font = this.tmpFont;
    child1.GetChild(2).GetComponent<UIText>().font = this.tmpFont;
    UIText component1 = child1.GetChild(3).GetComponent<UIText>();
    component1.font = this.tmpFont;
    ((Behaviour) component1).enabled = false;
    ((Component) component1).gameObject.SetActive(true);
    child1.GetChild(5).GetChild(0).GetComponent<UIText>().font = this.tmpFont;
    child1.GetChild(10).GetComponent<UIText>().font = this.tmpFont;
    child1.GetChild(12).GetComponent<UIText>().font = this.tmpFont;
    UIText component2 = child1.GetChild(13).GetComponent<UIText>();
    component2.font = this.tmpFont;
    component2.text = this.DM.mStringTable.GetStringByID(876U);
    UIText component3 = child1.GetChild(8).GetComponent<UIText>();
    component3.font = this.tmpFont;
    component3.text = this.DM.mStringTable.GetStringByID(838U);
    UIText component4 = child1.GetChild(15).GetChild(0).GetComponent<UIText>();
    component4.font = this.tmpFont;
    component4.text = this.DM.mStringTable.GetStringByID(877U);
    Text component5 = child1.GetChild(16).GetChild(0).GetComponent<Text>();
    component5.font = this.tmpFont;
    if (this.GM.IsArabic)
      ((Transform) ((Graphic) component5).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    UIText component6 = child1.GetChild(16).GetChild(1).GetComponent<UIText>();
    component6.font = this.tmpFont;
    component6.text = this.DM.mStringTable.GetStringByID(866U);
    Text component7 = child1.GetChild(16).GetChild(3).GetComponent<Text>();
    component7.font = this.tmpFont;
    if (this.GM.IsArabic)
      ((Transform) ((Graphic) component7).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    child1.GetChild(16).GetChild(4).GetChild(0).GetComponent<UIText>().font = this.tmpFont;
    Text component8 = child1.GetChild(16).GetChild(4).GetChild(1).GetComponent<Text>();
    component8.font = this.tmpFont;
    if (this.GM.IsArabic)
      ((Transform) ((Graphic) component8).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    Text component9 = child1.GetChild(16).GetChild(4).GetChild(2).GetComponent<Text>();
    component9.font = this.tmpFont;
    if (this.GM.IsArabic)
      ((Transform) ((Graphic) component9).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    Transform child2 = this.UnitObjectT.GetChild(1).GetChild(14);
    this.GM.InitianHeroItemImg(child2.GetChild(0), eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
    this.GM.InitianHeroItemImg(child2.GetChild(2), eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
    this.GM.InitianHeroItemImg(child2.GetChild(4), eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
    this.GM.InitLordEquipImg(child2.GetChild(1), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    this.GM.InitLordEquipImg(child2.GetChild(3), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    this.GM.InitLordEquipImg(child2.GetChild(5), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    child2.GetChild(12).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
    child2.GetChild(13).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
    child2.GetChild(14).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
    child2.GetChild(6).GetComponent<UIText>().font = this.tmpFont;
    child2.GetChild(9).GetComponent<UIText>().font = this.tmpFont;
    child2.GetChild(7).GetComponent<UIText>().font = this.tmpFont;
    child2.GetChild(10).GetComponent<UIText>().font = this.tmpFont;
    child2.GetChild(8).GetComponent<UIText>().font = this.tmpFont;
    child2.GetChild(11).GetComponent<UIText>().font = this.tmpFont;
    this.UnitObjectT.GetChild(2).GetChild(0).GetComponent<UIText>().font = this.tmpFont;
    float x = ((Component) this.GM.m_UICanvas).transform.GetComponent<RectTransform>().sizeDelta.x;
    this.UnitObjectT.GetChild(3).GetComponent<RectTransform>().sizeDelta = new Vector2(x, 358f);
    Transform child3 = this.UnitObjectT.GetChild(4);
    GUIManager.Instance.InitianHeroItemImg(child3.GetChild(7), eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
    child3.GetChild(10).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
    child3.GetChild(1).GetComponent<UIText>().font = this.tmpFont;
    child3.GetChild(4).GetComponent<UIText>().font = this.tmpFont;
    child3.GetChild(8).GetComponent<UIText>().font = this.tmpFont;
    child3.GetChild(9).GetComponent<UIText>().font = this.tmpFont;
    Text component10 = child3.GetChild(11).GetChild(0).GetComponent<Text>();
    component10.font = this.tmpFont;
    if (this.GM.IsArabic)
      ((Transform) ((Graphic) component10).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    UIText component11 = child3.GetChild(11).GetChild(1).GetComponent<UIText>();
    component11.font = this.tmpFont;
    component11.text = this.DM.mStringTable.GetStringByID(866U);
    Text component12 = child3.GetChild(11).GetChild(2).GetComponent<Text>();
    component12.font = this.tmpFont;
    if (this.GM.IsArabic)
      ((Transform) ((Graphic) component12).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    if (this.IsJapan)
      this.UnitObjectT.GetChild(5).GetChild(5).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
    for (int index = 0; index < 5; ++index)
      this.ScrollComp[index].DataIndex = -1;
    this.Scroll = this.m_transform.GetChild(0).GetComponent<ScrollPanel>();
    if (this.GM.bOpenOnIPhoneX)
      ((RectTransform) this.Scroll.transform).offsetMin = new Vector2(-53f, -640f);
    this.Scroll.IntiScrollPanel(640f, 0.0f, 0.0f, this.NowHeightList, 5, (IUpDateScrollPanel) this);
    this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
    UIButtonHint.scrollRect = this.cScrollRect;
    if (arg1 == 1)
      this.bMain = true;
    if (NewbieManager.CheckTeach(ETeachKind.TREASBOX_UPGRADE))
    {
      this.MM.MallUIIndex = 0;
      this.MM.MallUIPos = 0.0f;
    }
    this.UpDateList();
    if (this.MM.ForgeIndex != -1)
    {
      this.Scroll.GoTo(this.MM.ForgeIndex + 1);
      this.MM.ForgeIndex = -1;
      menu.ClearWindowStack(EGUIWindow.UI_Forge_ActivityItem, EGUIWindow.UI_Anvil);
    }
    if (!this.bMain && this.MM.bFirstArrow)
    {
      this.SetArrow(true);
      this.BeginPos = this.cScrollRect.content.anchoredPosition.y;
    }
    this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
    if (!this.MM.bAskListData)
    {
      this.MM.bSendMallInfo = true;
      GUIManager.Instance.ShowUILock(EUILock.Mall);
    }
    for (int index = 0; index < this.MM.MallDataList.Count; ++index)
    {
      if (!this.MM.MallDataList[index].bAskListData)
      {
        this.MM.Send_Mall_Info();
        break;
      }
    }
    if (this.MM.FullGift_bShowEffect)
      this.bOpenShowEffect = true;
    this.SetFGBtn();
  }

  public override void OnClose()
  {
    if (this.IsJapan)
    {
      for (int index = 0; index < this.JHintStr.Length; ++index)
      {
        if (this.JHintStr[index] != null)
          StringManager.Instance.DeSpawnString(this.JHintStr[index]);
      }
    }
    for (int index1 = 0; index1 < 5; ++index1)
    {
      if (this.TimeStr[index1] != null)
        StringManager.Instance.DeSpawnString(this.TimeStr[index1]);
      if (this.CrystalStr[index1] != null)
        StringManager.Instance.DeSpawnString(this.CrystalStr[index1]);
      if (this.CrystalStr2[index1] != null)
        StringManager.Instance.DeSpawnString(this.CrystalStr2[index1]);
      if (this.PriceStr[index1] != null)
        StringManager.Instance.DeSpawnString(this.PriceStr[index1]);
      if (this.DisStr[index1] != null)
        StringManager.Instance.DeSpawnString(this.DisStr[index1]);
      if (this.PriceStr2[index1] != null)
        StringManager.Instance.DeSpawnString(this.PriceStr2[index1]);
      for (int index2 = 0; index2 < 3; ++index2)
      {
        if (this.ItemCountStr[index1] != null && this.ItemCountStr[index1][index2] != null)
          StringManager.Instance.DeSpawnString(this.ItemCountStr[index1][index2]);
      }
    }
    if (this.NowCrystalStr != null)
      StringManager.Instance.DeSpawnString(this.NowCrystalStr);
    StringManager.Instance.DeSpawnString(this.FGStr);
    StringManager.Instance.DeSpawnString(this.FGEffStr);
    for (int index = 0; index < this.MM.MallDataList.Count; ++index)
    {
      if (this.MM.MallDataList[index].Type != ETreasureType.ETST_Crystal)
        this.MM.MallDataList[index].UnloadAB();
    }
    this.SavePos();
    if (this.MM.MallUIIndex == -1 && this.MM.MallDataList.Count > 0)
    {
      this.MM.MallUIIndex = 0;
      this.MM.MallUIPos = 0.0f;
    }
    if ((Object) this.EffectParticle != (Object) null)
    {
      if (this.EffectParticle.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
        this.EffectParticle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
      this.EffectParticle = (GameObject) null;
    }
    GUIManager.Instance.pDVMgr.EndMoveBossText();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh:
        if (this.bMain)
          break;
        this.UpDateMyCrystal();
        this.UpDateJPPoint();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        if (this.IsJapan)
        {
          for (int index = 0; index < this.JPText.Length; ++index)
          {
            if ((Object) this.JPText[index] != (Object) null && ((Behaviour) this.JPText[index]).enabled)
            {
              ((Behaviour) this.JPText[index]).enabled = false;
              ((Behaviour) this.JPText[index]).enabled = true;
            }
          }
        }
        if ((Object) this.LiveChatText != (Object) null && ((Behaviour) this.LiveChatText).enabled)
        {
          ((Behaviour) this.LiveChatText).enabled = false;
          ((Behaviour) this.LiveChatText).enabled = true;
        }
        if ((Object) this.HintText != (Object) null && ((Behaviour) this.HintText).enabled)
        {
          ((Behaviour) this.HintText).enabled = false;
          ((Behaviour) this.HintText).enabled = true;
        }
        if ((Object) this.FGText != (Object) null && ((Behaviour) this.FGText).enabled)
        {
          ((Behaviour) this.FGText).enabled = false;
          ((Behaviour) this.FGText).enabled = true;
        }
        if ((Object) this.FGEffText != (Object) null && ((Behaviour) this.FGEffText).enabled)
        {
          ((Behaviour) this.FGEffText).enabled = false;
          ((Behaviour) this.FGEffText).enabled = true;
        }
        for (int index1 = 0; index1 < 5; ++index1)
        {
          if (this.bFindScrollComp[index1])
          {
            if ((Object) this.ScrollComp[index1].InfoText != (Object) null && ((Behaviour) this.ScrollComp[index1].InfoText).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].InfoText).enabled = false;
              ((Behaviour) this.ScrollComp[index1].InfoText).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].TitleText != (Object) null && ((Behaviour) this.ScrollComp[index1].TitleText).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].TitleText).enabled = false;
              ((Behaviour) this.ScrollComp[index1].TitleText).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].TimeText != (Object) null && ((Behaviour) this.ScrollComp[index1].TimeText).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].TimeText).enabled = false;
              ((Behaviour) this.ScrollComp[index1].TimeText).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].Image1Text != (Object) null && ((Behaviour) this.ScrollComp[index1].Image1Text).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].Image1Text).enabled = false;
              ((Behaviour) this.ScrollComp[index1].Image1Text).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].CrystalText != (Object) null && ((Behaviour) this.ScrollComp[index1].CrystalText).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].CrystalText).enabled = false;
              ((Behaviour) this.ScrollComp[index1].CrystalText).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].CrystalText2 != (Object) null && ((Behaviour) this.ScrollComp[index1].CrystalText2).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].CrystalText2).enabled = false;
              ((Behaviour) this.ScrollComp[index1].CrystalText2).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].CrystalText22 != (Object) null && ((Behaviour) this.ScrollComp[index1].CrystalText22).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].CrystalText22).enabled = false;
              ((Behaviour) this.ScrollComp[index1].CrystalText22).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].BuyText != (Object) null && ((Behaviour) this.ScrollComp[index1].BuyText).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].BuyText).enabled = false;
              ((Behaviour) this.ScrollComp[index1].BuyText).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].GetAllText != (Object) null && ((Behaviour) this.ScrollComp[index1].GetAllText).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].GetAllText).enabled = false;
              ((Behaviour) this.ScrollComp[index1].GetAllText).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].TitleText_2 != (Object) null && ((Behaviour) this.ScrollComp[index1].TitleText_2).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].TitleText_2).enabled = false;
              ((Behaviour) this.ScrollComp[index1].TitleText_2).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].CrystalText_2 != (Object) null && ((Behaviour) this.ScrollComp[index1].CrystalText_2).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].CrystalText_2).enabled = false;
              ((Behaviour) this.ScrollComp[index1].CrystalText_2).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].ItemText_2 != (Object) null && ((Behaviour) this.ScrollComp[index1].ItemText_2).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].ItemText_2).enabled = false;
              ((Behaviour) this.ScrollComp[index1].ItemText_2).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].ItemCountText_2 != (Object) null && ((Behaviour) this.ScrollComp[index1].ItemCountText_2).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].ItemCountText_2).enabled = false;
              ((Behaviour) this.ScrollComp[index1].ItemCountText_2).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].BuyText_2 != (Object) null && ((Behaviour) this.ScrollComp[index1].BuyText_2).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].BuyText_2).enabled = false;
              ((Behaviour) this.ScrollComp[index1].BuyText_2).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].CrystalText3 != (Object) null && ((Behaviour) this.ScrollComp[index1].CrystalText3).enabled)
            {
              ((Behaviour) this.ScrollComp[index1].CrystalText3).enabled = false;
              ((Behaviour) this.ScrollComp[index1].CrystalText3).enabled = true;
            }
            if ((Object) this.ScrollComp[index1].HIBtn2 != (Object) null)
              this.ScrollComp[index1].HIBtn2.Refresh_FontTexture();
            for (int index2 = 0; index2 < 3; ++index2)
            {
              if ((Object) this.ScrollComp[index1].ItemText[index2] != (Object) null && ((Behaviour) this.ScrollComp[index1].ItemText[index2]).enabled)
              {
                ((Behaviour) this.ScrollComp[index1].ItemText[index2]).enabled = false;
                ((Behaviour) this.ScrollComp[index1].ItemText[index2]).enabled = true;
              }
              if ((Object) this.ScrollComp[index1].ItemCountText[index2] != (Object) null && ((Behaviour) this.ScrollComp[index1].ItemCountText[index2]).enabled)
              {
                ((Behaviour) this.ScrollComp[index1].ItemCountText[index2]).enabled = false;
                ((Behaviour) this.ScrollComp[index1].ItemCountText[index2]).enabled = true;
              }
              if ((Object) this.ScrollComp[index1].HIBtn1[index2] != (Object) null)
                this.ScrollComp[index1].HIBtn1[index2].Refresh_FontTexture();
            }
          }
        }
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        this.UpdateTime();
        if (!this.MM.bNeedUpDateItemPtice)
          break;
        this.UpDatePriceAndCrystal();
        this.MM.bNeedUpDateItemPtice = false;
        break;
      case 1:
        this.SavePos();
        this.UpDateList();
        break;
      case 2:
        this.SavePos();
        this.MM.Send_Mall_Info();
        break;
      case 4:
        this.SavePos();
        this.MM.AutoMall = true;
        break;
      case 5:
        this.UpDateScrollItem();
        break;
      case 7:
        if (this.bMain)
          break;
        this.UpDateJPPoint();
        break;
      case 8:
        this.SetFGBtn();
        break;
      case 9:
        this.BeginEffect();
        break;
      case 10:
        this.BeginGetCrystal(arg2);
        break;
      case 11:
        this.BeginEffect(true);
        break;
    }
  }

  private void Update()
  {
    if (this.bOpenShowEffect)
    {
      this.OpenShowTime -= Time.deltaTime;
      if ((double) this.OpenShowTime >= 0.0)
        return;
      this.bOpenShowEffect = false;
      this.BeginEffect();
    }
    else
    {
      if (this.bShowArrow)
      {
        this.CheckTimer -= Time.deltaTime;
        if ((double) this.CheckTimer <= 0.0)
        {
          this.CheckTimer = 0.5f;
          if ((double) Mathf.Abs(this.BeginPos - this.cScrollRect.content.anchoredPosition.y) > 200.0)
            this.SetArrow(false);
        }
      }
      if (this.NeedUpDate && IGGGameSDK.Instance.bPaymentReady)
      {
        this.NeedUpDate = false;
        this.UpDatePriceAndCrystal();
      }
      this.ResourceRedTime += Time.deltaTime;
      if ((double) this.ResourceRedTime >= 0.5)
      {
        this.ResourceRedTime = 0.0f;
        this.bResourceRed = !this.bResourceRed;
        for (int index = 0; index < 5; ++index)
        {
          if (this.bFindScrollComp[index] && this.ScrollComp[index].DataIndex != -1)
          {
            int dataIndex = this.ScrollComp[index].DataIndex;
            if (dataIndex >= 0 && dataIndex < this.MM.MallDataList.Count && this.MM.MallDataList[dataIndex].Type == ETreasureType.ETST_SHLevelUp && this.MM.MallDataList[dataIndex].EndTime > 0L)
            {
              if (this.bResourceRed)
                ((Graphic) this.ScrollComp[index].TimeText2).color = Color.red;
              else
                ((Graphic) this.ScrollComp[index].TimeText2).color = Color.white;
            }
          }
        }
      }
      if ((Object) this.LightT != (Object) null)
        this.LightT.Rotate(Vector3.forward * Time.smoothDeltaTime * -50f);
      if (this.bPlayGetCrystal)
      {
        this.GetCrystalNowTime += Time.deltaTime;
        if ((double) this.GetCrystalNowTime > (double) this.GetCrystalTime)
        {
          this.EndGetCrystal();
        }
        else
        {
          float t = this.GetCrystalNowTime / this.GetCrystalTime;
          float a = Mathf.Lerp(0.2f, 1.8f, t);
          if ((double) a > 1.0)
            a = 2f - a;
          ((Graphic) this.FGEffImage1).color = new Color(1f, 1f, 1f, a);
          ((Graphic) this.FGEffImage2).color = new Color(1f, 1f, 1f, a);
          ((Graphic) this.FGEffText).color = new Color(((Graphic) this.FGEffText).color.r, ((Graphic) this.FGEffText).color.g, ((Graphic) this.FGEffText).color.b, a);
          ((Graphic) this.FGEffText).rectTransform.anchoredPosition = new Vector2(0.0f, Mathf.Lerp(10f, 85f, t));
          ((Graphic) this.FGEffImage2).rectTransform.anchoredPosition = new Vector2(0.0f, Mathf.Lerp(15f, 96f, t));
        }
      }
      if (!(bool) (Object) this.EffectRC)
        return;
      if (!this.EffectReverse)
      {
        this.EffectTimer += Time.smoothDeltaTime;
        this.FGTimer += Time.smoothDeltaTime;
        if ((double) this.EffectTimer < 0.25999999046325684)
        {
          this.EffectScale = Mathf.Lerp(0.0f, 2.1f, this.EffectTimer / 0.26f);
          this.Effectalpha = Mathf.Lerp(0.0f, 0.57f, this.EffectTimer / 0.26f);
          ((Transform) this.EffectRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.EffectImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.EffectImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else if ((double) this.EffectTimer < 0.46000000834465027)
        {
          this.EffectScale = Mathf.Lerp(2.1f, 1f, (float) (((double) this.EffectTimer - 0.25999999046325684) / 0.20000000298023224));
          this.Effectalpha = Mathf.Lerp(0.57f, 1f, (float) (((double) this.EffectTimer - 0.25999999046325684) / 0.20000000298023224));
          ((Transform) this.EffectRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.EffectImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.EffectImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else if ((double) this.EffectTimer < 0.81999999284744263)
        {
          this.EffectScale = 1f;
          this.Effectalpha = 1f;
          ((Transform) this.EffectRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.EffectImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.EffectImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else if ((double) this.EffectTimer < 1.0)
        {
          this.EffectScale = Mathf.Lerp(1f, 0.92f, (float) (((double) this.EffectTimer - 0.81999999284744263) / 0.18000000715255737));
          this.Effectalpha = Mathf.Lerp(1f, 0.83f, (float) (((double) this.EffectTimer - 0.81999999284744263) / 0.18000000715255737));
          ((Transform) this.EffectRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.EffectImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.EffectImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else if ((double) this.EffectTimer < 1.1299999952316284)
        {
          this.EffectScale = Mathf.Lerp(0.92f, 0.86f, (float) (((double) this.EffectTimer - 1.0) / 0.12999999523162842));
          this.Effectalpha = Mathf.Lerp(0.83f, 0.7f, (float) (((double) this.EffectTimer - 1.0) / 0.12999999523162842));
          ((Transform) this.EffectRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.EffectImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.EffectImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
          this.bezierEnd = Vector2.zero + new Vector2(6f, -5f);
          this.EffectRC.anchoredPosition = Vector2.Lerp(Vector2.zero, this.bezierEnd, (float) (((double) this.EffectTimer - 1.0) / 0.12999999523162842));
        }
        else if ((double) this.EffectTimer < 1.8200000524520874)
        {
          this.EffectScale = Mathf.Lerp(0.86f, 0.6f, (float) (((double) this.EffectTimer - 1.1299999952316284) / 0.68999999761581421));
          this.Effectalpha = Mathf.Lerp(0.7f, 0.17f, (float) (((double) this.EffectTimer - 1.1299999952316284) / 0.68999999761581421));
          ((Transform) this.EffectRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.EffectImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.EffectImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
          this.bezierEnd = Vector2.zero - new Vector2((float) ((double) GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 - 38.0), (float) -((double) GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 - 49.0));
          this.EffectRC.anchoredPosition = Vector2.Lerp(Vector2.zero + new Vector2(6f, -5f), this.bezierEnd, (float) (((double) this.EffectTimer - 1.1299999952316284) / 0.68999999761581421));
        }
        else if ((double) this.EffectTimer >= 1.8200000524520874)
        {
          ((Component) this.EffectRC).gameObject.SetActive(false);
          this.EffectPos.gameObject.SetActive(false);
        }
        if ((double) this.FGTimer > 1.4600000381469727 && !this.FGGO.activeSelf)
        {
          this.FGGO.SetActive(true);
          AudioManager.Instance.PlayUISFX(UIKind.Crystal_Arrivals);
        }
        else if (this.FGGO.activeSelf && (double) this.FGTimer < 1.6599999666213989)
        {
          this.EffectScale = Mathf.Lerp(0.0f, 1.5f, (float) (((double) this.FGTimer - 1.4600000381469727) / 0.20000000298023224));
          ((Transform) this.FGRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          this.Effectalpha = Mathf.Lerp(0.0f, 0.6f, (float) (((double) this.FGTimer - 1.4600000381469727) / 0.20000000298023224));
          ((Graphic) this.FGImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.FGImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else if (this.FGGO.activeSelf && (double) this.FGTimer < 1.7899999618530273)
        {
          this.EffectScale = Mathf.Lerp(1.5f, 1f, (float) (((double) this.FGTimer - 1.6599999666213989) / 0.12999999523162842));
          ((Transform) this.FGRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          this.Effectalpha = Mathf.Lerp(0.6f, 1f, (float) (((double) this.FGTimer - 1.6599999666213989) / 0.12999999523162842));
          ((Graphic) this.FGImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.FGImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else if (this.FGGO.activeSelf && (double) this.FGTimer < 1.8899999856948853)
        {
          this.EffectScale = Mathf.Lerp(1f, 1.2f, (float) (((double) this.FGTimer - 1.7899999618530273) / 0.10000000149011612));
          ((Transform) this.FGRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          this.Effectalpha = Mathf.Lerp(1f, 1.2f, (float) (((double) this.FGTimer - 1.7899999618530273) / 0.10000000149011612));
          ((Graphic) this.FGImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.FGImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else if (this.FGGO.activeSelf && (double) this.FGTimer < 1.9199999570846558)
        {
          this.EffectScale = Mathf.Lerp(1.2f, 1f, (float) (((double) this.FGTimer - 1.8899999856948853) / 0.029999999329447746));
          ((Transform) this.FGRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          this.Effectalpha = Mathf.Lerp(1.2f, 1f, (float) (((double) this.FGTimer - 1.8899999856948853) / 0.029999999329447746));
          ((Graphic) this.FGImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.FGImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else
        {
          if (!this.FGGO.activeSelf || (double) this.FGTimer <= 1.9199999570846558)
            return;
          this.EndEffect();
        }
      }
      else
      {
        this.EffectTimer += Time.smoothDeltaTime;
        this.FGTimer += Time.smoothDeltaTime;
        if ((double) this.EffectTimer < 0.68999999761581421)
        {
          this.EffectScale = Mathf.Lerp(0.6f, 0.86f, this.EffectTimer / 0.69f);
          this.Effectalpha = Mathf.Lerp(0.17f, 0.7f, this.EffectTimer / 0.69f);
          ((Transform) this.EffectRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.EffectImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.EffectImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
          this.bezierEnd = Vector2.zero + new Vector2(6f, -5f) - new Vector2((float) ((double) GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 - 38.0), (float) -((double) GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 - 49.0));
          this.EffectRC.anchoredPosition = Vector2.Lerp(this.bezierEnd, Vector2.zero + new Vector2(6f, -5f), this.EffectTimer / 0.69f);
        }
        else if ((double) this.EffectTimer < 0.81999999284744263)
        {
          this.EffectScale = Mathf.Lerp(0.86f, 0.92f, (float) (((double) this.EffectTimer - 0.68999999761581421) / 0.12999999523162842));
          this.Effectalpha = Mathf.Lerp(0.7f, 0.83f, (float) (((double) this.EffectTimer - 0.68999999761581421) / 0.12999999523162842));
          ((Transform) this.EffectRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.EffectImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.EffectImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
          this.bezierEnd = Vector2.zero + new Vector2(6f, -5f);
          this.EffectRC.anchoredPosition = Vector2.Lerp(this.bezierEnd, Vector2.zero, (float) (((double) this.EffectTimer - 0.68999999761581421) / 0.12999999523162842));
        }
        else if ((double) this.EffectTimer < 1.0)
        {
          this.EffectScale = Mathf.Lerp(0.92f, 1f, (float) (((double) this.EffectTimer - 0.81999999284744263) / 0.18000000715255737));
          this.Effectalpha = Mathf.Lerp(0.83f, 1f, (float) (((double) this.EffectTimer - 0.81999999284744263) / 0.18000000715255737));
          ((Transform) this.EffectRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.EffectImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.EffectImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
          if ((Object) this.EffectParticle == (Object) null)
          {
            this.EffectParticle = ParticleManager.Instance.Spawn((ushort) 433, this.EffectPos.transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
            this.EffectParticle.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
            this.EffectParticle.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
            GUIManager.Instance.SetLayer(this.EffectParticle, 5);
            AudioManager.Instance.PlayUISFX(UIKind.DominanceLevelup);
          }
        }
        else if ((double) this.EffectTimer < 1.3600000143051147)
        {
          this.EffectScale = 1f;
          this.Effectalpha = 1f;
          ((Transform) this.EffectRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.EffectImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.EffectImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else if ((double) this.EffectTimer < 1.559999942779541)
        {
          this.EffectScale = Mathf.Lerp(1f, 2.1f, (float) (((double) this.EffectTimer - 1.3600000143051147) / 0.20000000298023224));
          this.Effectalpha = Mathf.Lerp(1f, 0.57f, (float) (((double) this.EffectTimer - 1.3600000143051147) / 0.20000000298023224));
          ((Transform) this.EffectRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.EffectImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.EffectImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else if ((double) this.EffectTimer < 1.8200000524520874)
        {
          this.EffectScale = Mathf.Lerp(2.1f, 0.0f, (float) (((double) this.EffectTimer - 1.559999942779541) / 0.25999999046325684));
          this.Effectalpha = Mathf.Lerp(0.57f, 0.0f, (float) (((double) this.EffectTimer - 1.559999942779541) / 0.25999999046325684));
          ((Transform) this.EffectRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.EffectImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.EffectImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else if ((double) this.EffectTimer > 1.8200000524520874)
        {
          ((Component) this.EffectRC).gameObject.SetActive(false);
          this.EffectPos.gameObject.SetActive(false);
          this.EndEffect();
        }
        if ((double) this.FGTimer < 0.029999999329447746)
        {
          this.EffectScale = Mathf.Lerp(1f, 1.2f, this.FGTimer / 0.03f);
          this.Effectalpha = Mathf.Lerp(1f, 1.2f, this.FGTimer / 0.03f);
          ((Transform) this.FGRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.FGImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.FGImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else if ((double) this.FGTimer < 0.12999999523162842)
        {
          this.EffectScale = Mathf.Lerp(1.2f, 1f, (float) (((double) this.FGTimer - 0.029999999329447746) / 0.10000000149011612));
          this.Effectalpha = Mathf.Lerp(1.2f, 1f, (float) (((double) this.FGTimer - 0.029999999329447746) / 0.10000000149011612));
          ((Transform) this.FGRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.FGImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.FGImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else if ((double) this.FGTimer < 0.25999999046325684)
        {
          this.EffectScale = Mathf.Lerp(1f, 1.5f, (float) (((double) this.FGTimer - 0.12999999523162842) / 0.12999999523162842));
          this.Effectalpha = Mathf.Lerp(1f, 0.6f, (float) (((double) this.FGTimer - 0.12999999523162842) / 0.12999999523162842));
          ((Transform) this.FGRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.FGImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.FGImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else if ((double) this.FGTimer < 0.46000000834465027)
        {
          this.EffectScale = Mathf.Lerp(1.5f, 0.0f, (float) (((double) this.FGTimer - 0.25999999046325684) / 0.20000000298023224));
          this.Effectalpha = Mathf.Lerp(0.6f, 0.0f, (float) (((double) this.FGTimer - 0.25999999046325684) / 0.20000000298023224));
          ((Transform) this.FGRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
          ((Graphic) this.FGImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
          ((Graphic) this.FGImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
        }
        else
        {
          if ((double) this.FGTimer <= 0.46000000834465027)
            return;
          this.FGGO.SetActive(false);
        }
      }
    }
  }

  private void UpDateMyCrystal()
  {
    for (int index = 0; index < 5; ++index)
    {
      if (this.bFindScrollComp[index] && this.ScrollComp[index].bTitleCrystal)
      {
        this.NowCrystalStr.Length = 0;
        StringManager.IntToStr(this.NowCrystalStr, (long) this.DM.RoleAttr.Diamond, bNumber: true);
        this.ScrollComp[index].CrystalText3.text = this.NowCrystalStr.ToString();
        this.ScrollComp[index].CrystalText3.SetAllDirty();
        this.ScrollComp[index].CrystalText3.cachedTextGenerator.Invalidate();
        break;
      }
    }
  }

  private void UpDateJPPoint()
  {
    if (!this.IsJapan)
      return;
    if ((Object) this.JPText[2] != (Object) null)
    {
      this.JHintStr[0].Length = 0;
      this.JHintStr[0].IntToFormat((long) this.DM.RoleAttr.PaidCrystal, bNumber: true);
      this.JHintStr[0].AppendFormat(this.DM.mStringTable.GetStringByID(915U));
      this.JPText[2].text = this.JHintStr[0].ToString();
      this.JPText[2].SetAllDirty();
      this.JPText[2].cachedTextGenerator.Invalidate();
    }
    if (!((Object) this.JPText[3] != (Object) null))
      return;
    this.JHintStr[1].Length = 0;
    this.JHintStr[1].IntToFormat((long) (this.DM.RoleAttr.Diamond - this.DM.RoleAttr.PaidCrystal), bNumber: true);
    this.JHintStr[1].AppendFormat(this.DM.mStringTable.GetStringByID(916U));
    this.JPText[3].text = this.JHintStr[1].ToString();
    this.JPText[3].SetAllDirty();
    this.JPText[3].cachedTextGenerator.Invalidate();
  }

  private void UpDatePriceAndCrystal()
  {
    for (int index = 0; index < 5; ++index)
    {
      if (this.bFindScrollComp[index] && this.ScrollComp[index].DataIndex != -1)
      {
        int dataIndex = this.ScrollComp[index].DataIndex;
        if (dataIndex >= 0 && dataIndex < this.MM.MallDataList.Count)
        {
          int treasureId = (int) this.MM.MallDataList[dataIndex].TreasureID;
          int point = 0;
          this.MM.GetProductPointByID(treasureId, out point);
          this.CrystalStr[index].Length = 0;
          this.CrystalStr[index].IntToFormat((long) point, bNumber: true);
          this.CrystalStr[index].AppendFormat("{0}");
          this.ScrollComp[index].CrystalText.text = this.CrystalStr[index].ToString();
          this.ScrollComp[index].CrystalText.SetAllDirty();
          this.ScrollComp[index].CrystalText.cachedTextGenerator.Invalidate();
          this.MM.SetPriceStr(this.PriceStr[index], treasureId, Discount: (byte) 0);
          if (this.MM.MallDataList[dataIndex].Discount > (byte) 0)
          {
            this.MM.SetPriceStr(this.PriceStr2[index], treasureId, true, this.MM.MallDataList[dataIndex].Discount);
            this.ScrollComp[index].Lable_PriceText1.text = this.PriceStr2[index].ToString();
            ((Graphic) this.ScrollComp[index].Lable_PriceText1).SetAllDirty();
            this.ScrollComp[index].Lable_PriceText1.cachedTextGenerator.Invalidate();
            this.ScrollComp[index].Lable_PriceText2.text = this.PriceStr[index].ToString();
            ((Graphic) this.ScrollComp[index].Lable_PriceText2).SetAllDirty();
            this.ScrollComp[index].Lable_PriceText2.cachedTextGenerator.Invalidate();
          }
          else
          {
            this.ScrollComp[index].BuyText.text = this.PriceStr[index].ToString();
            ((Graphic) this.ScrollComp[index].BuyText).SetAllDirty();
            this.ScrollComp[index].BuyText.cachedTextGenerator.Invalidate();
          }
        }
      }
    }
  }

  private void UpdateTime()
  {
    for (int index = 0; index < 5; ++index)
    {
      if (this.bFindScrollComp[index] && this.ScrollComp[index].DataIndex != -1)
      {
        int dataIndex = this.ScrollComp[index].DataIndex;
        if (dataIndex >= 0 && dataIndex < this.MM.MallDataList.Count && this.MM.MallDataList[dataIndex].Type != ETreasureType.ETST_Crystal && this.MM.MallDataList[dataIndex].EndTime > 0L)
        {
          this.TimeStr[index].Length = 0;
          if (this.MM.MallDataList[dataIndex].Type == ETreasureType.ETST_SHLevelUp)
          {
            GameConstants.GetTimeString(this.TimeStr[index], this.MM.MallDataList[dataIndex].uTime, bShowDay: false);
            this.ScrollComp[index].TimeText2.text = this.TimeStr[index].ToString();
            this.ScrollComp[index].TimeText2.SetAllDirty();
            this.ScrollComp[index].TimeText2.cachedTextGenerator.Invalidate();
          }
          else
          {
            GameConstants.GetTimeString(this.TimeStr[index], this.MM.MallDataList[dataIndex].uTime);
            this.ScrollComp[index].TimeText.text = this.TimeStr[index].ToString();
            this.ScrollComp[index].TimeText.SetAllDirty();
            this.ScrollComp[index].TimeText.cachedTextGenerator.Invalidate();
          }
        }
      }
    }
    this.SetFGTime();
  }

  private void UpDateList()
  {
    this.NowHeightList.Clear();
    if (this.bMain)
    {
      this.NowHeightList.Add(640f);
      this.Scroll.transform.GetComponent<CScrollRect>().vertical = false;
    }
    else
    {
      this.NowHeightList.Add(46f);
      this.Scroll.transform.GetComponent<CScrollRect>().vertical = true;
      for (int index = 0; index < this.MM.MallDataList.Count; ++index)
      {
        if (this.MM.MallDataList[index].Type != ETreasureType.ETST_Crystal)
          this.NowHeightList.Add(640f);
        else
          this.NowHeightList.Add(358f);
      }
    }
    this.Scroll.AddNewDataHeight(this.NowHeightList);
    this.Scroll.transform.GetComponent<CScrollRect>().movementType = CScrollRect.MovementType.Clamped;
    ((Behaviour) this.Scroll.transform.GetComponent<Mask>()).enabled = false;
    for (int index = 0; index < 5; ++index)
    {
      RectTransform component = this.Scroll.transform.GetChild(0).GetChild(index).GetComponent<RectTransform>();
      component.anchorMax = new Vector2(0.5f, 1f);
      component.anchorMin = new Vector2(0.5f, 1f);
      component.pivot = new Vector2(0.5f, 1f);
      component.anchoredPosition = new Vector2(0.0f, component.anchoredPosition.y);
    }
    RectTransform component1 = this.Scroll.transform.GetChild(0).GetComponent<RectTransform>();
    component1.sizeDelta = new Vector2(((RectTransform) ((Component) this.GM.m_UICanvas).transform).sizeDelta.x, component1.sizeDelta.y);
    if (this.MM.MallUIIndex != -1)
      this.Scroll.GoTo(this.MM.MallUIIndex, this.MM.MallUIPos);
    this.UpdateTime();
  }

  private void SetBackNameInfo(int ScrollIndex, int DataIndex)
  {
    MallDataType mallData = this.MM.MallDataList[DataIndex];
    if (mallData.Type == ETreasureType.ETST_Crystal)
      return;
    if (mallData.bDownLoadPic)
    {
      if (mallData.bUpDatePic)
      {
        mallData.UnloadAB();
        mallData.bUpDatePic = false;
      }
      if (mallData.m_AssetBundleKey == 0)
        mallData.InitialAB();
      this.ScrollComp[ScrollIndex].BackImage1.sprite = mallData.m_BackImage1;
      ((MaskableGraphic) this.ScrollComp[ScrollIndex].BackImage1).material = mallData.m_Material;
      ((Behaviour) this.ScrollComp[ScrollIndex].BackImage1).enabled = true;
    }
    else
      ((Behaviour) this.ScrollComp[ScrollIndex].BackImage1).enabled = false;
    if (mallData.bDownLoadStr)
    {
      if (mallData.bUpDateStr)
      {
        mallData.UnloadStrAB();
        mallData.bUpDateStr = false;
      }
      if (mallData.m_StrAssetBundleKey == 0)
        mallData.InitialABString();
      if (!((Object) mallData.DownLoadStr != (Object) null))
        return;
      byte index = (byte) (this.DM.UserLanguage - (byte) 1);
      if ((int) index >= mallData.DownLoadStr.Content.Length || mallData.DownLoadStr.Content[(int) index] == string.Empty)
        index = (byte) 0;
      this.ScrollComp[ScrollIndex].InfoText.text = mallData.DownLoadStr.Content[(int) index].Replace("\\n", "\n");
      this.ScrollComp[ScrollIndex].TitleText.text = mallData.DownLoadStr.Header[(int) index];
    }
    else
    {
      this.ScrollComp[ScrollIndex].InfoText.text = string.Empty;
      this.ScrollComp[ScrollIndex].TitleText.text = string.Empty;
    }
  }

  private void SetArrow(bool bShow)
  {
    if (bShow)
    {
      Vector3 localPosition1 = this.ArrowObj.transform.localPosition;
      Vector3 localPosition2 = this.HintObj.transform.localPosition;
      if (this.MM.MallDataList.Count > 0 && this.MM.MallDataList[0].PosType == (byte) 1)
      {
        localPosition1 += new Vector3(351f, 0.0f, 0.0f);
        this.HintObj.transform.localPosition = localPosition2 + new Vector3(351f, 0.0f, 0.0f);
      }
      this.ArrowPos.from = localPosition1;
      this.ArrowPos.to = localPosition1 + new Vector3(0.0f, 200f, 0.0f);
      this.ArrowObj.SetActive(true);
      this.HintObj.SetActive(true);
      this.bShowArrow = true;
    }
    else
    {
      this.HintObj.SetActive(false);
      this.ArrowObj.SetActive(false);
      this.bShowArrow = false;
      this.MM.bFirstArrow = false;
    }
  }

  private void SetFGBtn()
  {
    if ((Object) this.FGGO == (Object) null || (Object) this.LightT == (Object) null)
      return;
    if (this.bOpenShowEffect || (bool) (Object) this.EffectRC || this.MM.FullGift_Deadline == 0L)
    {
      this.FGGO.SetActive(false);
      this.LightT.gameObject.SetActive(false);
    }
    else
    {
      this.FGGO.SetActive(true);
      this.LightT.gameObject.SetActive(true);
      this.SetFGTime();
    }
  }

  private void SetFGTime()
  {
    if ((Object) this.FGText == (Object) null || this.MM.FullGift_Deadline == 0L)
      return;
    this.FGStr.Length = 0;
    GameConstants.GetTimeString(this.FGStr, (uint) (this.MM.FullGift_Deadline - this.DM.ServerTime), hideTimeIfDays: true);
    this.FGText.text = this.FGStr.ToString();
    this.FGText.SetAllDirty();
    this.FGText.cachedTextGenerator.Invalidate();
    this.FGImage2.fillAmount = this.MM.FullGift_MaxCrystal != 0U ? (float) this.MM.FullGift_NowCrystal / (float) this.MM.FullGift_MaxCrystal : 0.0f;
  }

  private void UpDateScrollItem()
  {
    for (int ScrollIndex = 0; ScrollIndex < 5; ++ScrollIndex)
    {
      if (this.bFindScrollComp[ScrollIndex] && this.ScrollComp[ScrollIndex].DataIndex >= 0 && this.ScrollComp[ScrollIndex].DataIndex < this.MM.MallDataList.Count)
        this.SetBackNameInfo(ScrollIndex, this.ScrollComp[ScrollIndex].DataIndex);
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      if (sender.m_BtnID2 == 1)
      {
        if (sender.m_BtnID3 < 0 || sender.m_BtnID3 >= this.MM.MallDataList.Count)
          return;
        this.MM.Send_Mall_Combobox(this.MM.MallDataList[sender.m_BtnID3].SN);
      }
      else
      {
        if (sender.m_BtnID2 != 2 || this.MM.CheckbWaitBuy(true) || sender.m_BtnID3 < 0 || sender.m_BtnID3 >= this.MM.MallDataList.Count)
          return;
        this.MM.Send_Mall_Check(this.MM.MallDataList[sender.m_BtnID3].SN);
      }
    }
    else if (sender.m_BtnID1 == 2)
    {
      if (sender.m_BtnID2 != 1 || this.MM.CheckbWaitBuy(true) || sender.m_BtnID3 < 0 || sender.m_BtnID3 >= this.MM.MallDataList.Count)
        return;
      this.MM.Send_Mall_Check(this.MM.MallDataList[sender.m_BtnID3].SN);
    }
    else if (sender.m_BtnID1 == 3)
    {
      if (sender.m_BtnID2 != 1)
        return;
      this.CloseSelf();
    }
    else if (sender.m_BtnID1 == 4)
    {
      if (!this.MM.OpenDetail((ushort) sender.m_BtnID2))
        return;
      AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
    }
    else if (sender.m_BtnID1 == 5)
    {
      if (this.DM.UserLanguage == GameLanguage.GL_Eng || this.DM.UserLanguage == GameLanguage.GL_Idn)
        IGGSDKPlugin.SupportLiveOnShop_GlobalEdition((byte) this.DM.UserLanguage);
      else
        IGGSDKPlugin.SubmitQuestion();
    }
    else if (sender.m_BtnID1 == 6 || sender.m_BtnID1 == 9)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!(bool) (Object) menu)
        return;
      menu.ClearWindowStack(EGUIWindow.UI_Mall);
      menu.OpenMenu(EGUIWindow.UI_BagFilter, arg2: 2);
    }
    else if (sender.m_BtnID1 == 11)
    {
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!(bool) (Object) menu)
        return;
      menu.OpenMenu(EGUIWindow.UI_Mall_FG, bCameraMode: true);
    }
    else
    {
      if (sender.m_BtnID1 != 12)
        return;
      string str1 = "http://lordsmobile.igg.com/project/probability/?game_id=";
      int index = Mathf.Clamp((int) this.DM.UserLanguage, 1, GameConstants.GlobalEditionGameID.Length - 1);
      string str2 = GameConstants.GlobalEditionGameID[index];
      Application.OpenURL(str1 + str2);
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    if (!this.MM.OpenDetail(sender.HIID))
      return;
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (Object) menu)
      return;
    img.sprite = menu.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = menu.LoadMaterial();
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelObjectIdx >= 5)
      return;
    if (!this.bFindScrollComp[panelObjectIdx])
    {
      int length = 3;
      this.bFindScrollComp[panelObjectIdx] = true;
      Transform transform = item.transform;
      this.ScrollComp[panelObjectIdx].MyGO = item;
      this.ScrollComp[panelObjectIdx].BackImage1 = transform.GetChild(0).GetComponent<Image>();
      if (this.GM.IsArabic)
        ((Transform) ((Graphic) this.ScrollComp[panelObjectIdx].BackImage1).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
      this.ScrollComp[panelObjectIdx].BackImage2 = transform.GetChild(3).GetComponent<Image>();
      this.ScrollComp[panelObjectIdx].InfoImage = transform.GetChild(2).GetComponent<Image>();
      this.ScrollComp[panelObjectIdx].InfoText = transform.GetChild(2).GetChild(0).GetComponent<UIText>();
      Transform child1 = transform.GetChild(1);
      this.ScrollComp[panelObjectIdx].Panel1RC = child1.GetComponent<RectTransform>();
      this.ScrollComp[panelObjectIdx].TitleText = child1.GetChild(0).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].TimeImage = child1.GetChild(1).GetComponent<Image>();
      this.ScrollComp[panelObjectIdx].TimeText = child1.GetChild(2).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].TimeText2 = child1.GetChild(3).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].StampImage = child1.GetChild(4).GetComponent<Image>();
      this.ScrollComp[panelObjectIdx].StampHintBtn = child1.GetChild(4).GetComponent<UIButton>();
      this.ScrollComp[panelObjectIdx].StampHintBtn.m_Handler = (IUIButtonClickHandler) this;
      this.ScrollComp[panelObjectIdx].StampHintBtn.m_BtnID1 = 100;
      this.ScrollComp[panelObjectIdx].StampHint = ((Component) this.ScrollComp[panelObjectIdx].StampImage).gameObject.AddComponent<UIButtonHint>();
      this.ScrollComp[panelObjectIdx].StampHint.m_eHint = EUIButtonHint.CountDown;
      this.ScrollComp[panelObjectIdx].StampHint.m_DownUpHandler = (IUIButtonDownUpHandler) this;
      this.ScrollComp[panelObjectIdx].StampHint.Parm2 = (byte) 100;
      this.ScrollComp[panelObjectIdx].StampHint.DelayTime = 0.2f;
      this.ScrollComp[panelObjectIdx].StampSA = !this.GM.IsArabic ? child1.GetChild(4).GetComponent<UISpritesArray>() : child1.GetComponent<UISpritesArray>();
      this.ScrollComp[panelObjectIdx].Image1 = child1.GetChild(5).GetComponent<Image>();
      this.ScrollComp[panelObjectIdx].ScaleImage1 = child1.GetChild(5).GetComponent<uTweenScale>();
      this.ScrollComp[panelObjectIdx].ScaleImage1.duration = 0.4f;
      this.ScrollComp[panelObjectIdx].BuyOnceSA = child1.GetChild(5).GetComponent<UISpritesArray>();
      this.ScrollComp[panelObjectIdx].Image1Text = child1.GetChild(5).GetChild(0).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].Image2L = child1.GetChild(6).GetComponent<Image>();
      this.ScrollComp[panelObjectIdx].RateSA = child1.GetChild(6).GetComponent<UISpritesArray>();
      this.ScrollComp[panelObjectIdx].Image2R = child1.GetChild(7).GetComponent<Image>();
      this.ScrollComp[panelObjectIdx].CrystalText = child1.GetChild(10).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].CrystalImg2 = child1.GetChild(11).GetComponent<Image>();
      this.ScrollComp[panelObjectIdx].CrystalText2 = child1.GetChild(12).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].CrystalText22 = child1.GetChild(13).GetComponent<UIText>();
      child1.GetChild(15).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      child1.GetChild(16).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.ScrollComp[panelObjectIdx].MoreBtn = child1.GetChild(15).GetComponent<UIButton>();
      this.ScrollComp[panelObjectIdx].BuyBtn = child1.GetChild(16).GetComponent<UIButton>();
      this.ScrollComp[panelObjectIdx].BuyText = child1.GetChild(16).GetChild(0).GetComponent<Text>();
      this.ScrollComp[panelObjectIdx].GetAllText = child1.GetChild(8).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].BuyGO1 = child1.GetChild(16).GetChild(0).gameObject;
      this.ScrollComp[panelObjectIdx].BuyGO2 = child1.GetChild(16).GetChild(1).gameObject;
      this.ScrollComp[panelObjectIdx].LableGO = child1.GetChild(16).GetChild(4).gameObject;
      this.ScrollComp[panelObjectIdx].LableGO = child1.GetChild(16).GetChild(4).gameObject;
      this.ScrollComp[panelObjectIdx].Lable_DisText = child1.GetChild(16).GetChild(4).GetChild(0).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].Lable_PriceText1 = child1.GetChild(16).GetChild(4).GetChild(1).GetComponent<Text>();
      this.ScrollComp[panelObjectIdx].Lable_PriceText2 = child1.GetChild(16).GetChild(4).GetChild(2).GetComponent<Text>();
      Transform child2 = transform.GetChild(1).GetChild(14);
      this.ScrollComp[panelObjectIdx].AllItemRC = child2.GetComponent<RectTransform>();
      this.ScrollComp[panelObjectIdx].AllItemOriginPos = this.ScrollComp[panelObjectIdx].AllItemRC.anchoredPosition;
      this.ScrollComp[panelObjectIdx].ItemT = new Transform[length];
      this.ScrollComp[panelObjectIdx].ItemT2 = new Transform[length];
      this.ScrollComp[panelObjectIdx].ItemText = new UIText[length];
      this.ScrollComp[panelObjectIdx].ItemCountText = new UIText[length];
      this.ScrollComp[panelObjectIdx].Btn1 = new UIButton[length];
      this.ScrollComp[panelObjectIdx].Hint1 = new UIButtonHint[length];
      this.ScrollComp[panelObjectIdx].HIBtn1 = new UIHIBtn[length];
      for (int index = 0; index < length; ++index)
      {
        this.ScrollComp[panelObjectIdx].ItemT[index] = child2.GetChild(0 + index * 2);
        this.ScrollComp[panelObjectIdx].ItemT2[index] = child2.GetChild(1 + index * 2);
        this.ScrollComp[panelObjectIdx].ItemText[index] = child2.GetChild(6 + index).GetComponent<UIText>();
        this.ScrollComp[panelObjectIdx].ItemCountText[index] = child2.GetChild(9 + index).GetComponent<UIText>();
        this.ScrollComp[panelObjectIdx].ItemT[index].GetComponent<UIHIBtn>().m_Handler = (IUIHIBtnClickHandler) this;
        this.ScrollComp[panelObjectIdx].HIBtn1[index] = this.ScrollComp[panelObjectIdx].ItemT[index].GetComponent<UIHIBtn>();
        this.ScrollComp[panelObjectIdx].Btn1[index] = child2.GetChild(12 + index).GetComponent<UIButton>();
        this.ScrollComp[panelObjectIdx].Btn1[index].m_Handler = (IUIButtonClickHandler) this;
        this.ScrollComp[panelObjectIdx].Btn1[index].m_BtnID1 = 4;
        this.ScrollComp[panelObjectIdx].Hint1[index] = child2.GetChild(12 + index).GetComponent<UIButtonHint>();
        this.ScrollComp[panelObjectIdx].Hint1[index].m_Handler = (MonoBehaviour) this;
        this.ScrollComp[panelObjectIdx].Hint1[index].DelayTime = 0.2f;
      }
      Transform child3 = transform.GetChild(4);
      this.ScrollComp[panelObjectIdx].Panel2RC = child3.GetComponent<RectTransform>();
      this.ScrollComp[panelObjectIdx].TitleText_2 = child3.GetChild(1).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].CrystalText_2 = child3.GetChild(4).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].ItemT_2 = child3.GetChild(7);
      this.ScrollComp[panelObjectIdx].ItemText_2 = child3.GetChild(8).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].ItemCountText_2 = child3.GetChild(9).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].BuyBtn_2 = child3.GetChild(11).GetComponent<UIButton>();
      this.ScrollComp[panelObjectIdx].BuyText_2 = child3.GetChild(11).GetChild(0).GetComponent<Text>();
      child3.GetChild(11).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.ScrollComp[panelObjectIdx].ItemT_2.GetComponent<UIHIBtn>().m_Handler = (IUIHIBtnClickHandler) this;
      this.ScrollComp[panelObjectIdx].HIBtn2 = this.ScrollComp[panelObjectIdx].ItemT_2.GetComponent<UIHIBtn>();
      this.ScrollComp[panelObjectIdx].Btn2 = child3.GetChild(10).GetComponent<UIButton>();
      this.ScrollComp[panelObjectIdx].Btn2.m_Handler = (IUIButtonClickHandler) this;
      this.ScrollComp[panelObjectIdx].Btn2.m_BtnID1 = 4;
      this.ScrollComp[panelObjectIdx].Hint2 = child3.GetChild(10).GetComponent<UIButtonHint>();
      this.ScrollComp[panelObjectIdx].Hint2.m_Handler = (MonoBehaviour) this;
      this.ScrollComp[panelObjectIdx].Hint2.DelayTime = 0.2f;
      Transform child4 = transform.GetChild(5);
      this.ScrollComp[panelObjectIdx].Panel3RC = child4.GetComponent<RectTransform>();
      this.ScrollComp[panelObjectIdx].CrystalText3 = child4.GetChild(3).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].CrystalText3.font = this.tmpFont;
      this.ScrollComp[panelObjectIdx].Btn3 = child4.GetChild(4).GetComponent<UIButton>();
      this.ScrollComp[panelObjectIdx].Btn3.m_Handler = (IUIButtonClickHandler) this;
      this.ScrollComp[panelObjectIdx].Btn3.m_BtnID1 = 6;
      this.NowCrystalStr = StringManager.Instance.SpawnString();
      if (this.IsJapan)
      {
        child4.GetChild(5).gameObject.SetActive(true);
        child4.GetChild(5).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        UIButtonHint component = child4.GetChild(5).GetComponent<UIButtonHint>();
        component.m_Handler = (MonoBehaviour) this;
        component.DelayTime = 0.2f;
        component.Parm1 = (ushort) 0;
        component.Parm2 = byte.MaxValue;
      }
      child4.GetChild(6).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      this.TimeStr[panelObjectIdx] = StringManager.Instance.SpawnString();
      this.CrystalStr[panelObjectIdx] = StringManager.Instance.SpawnString();
      this.CrystalStr2[panelObjectIdx] = StringManager.Instance.SpawnString();
      this.PriceStr[panelObjectIdx] = StringManager.Instance.SpawnString();
      this.DisStr[panelObjectIdx] = StringManager.Instance.SpawnString();
      this.PriceStr2[panelObjectIdx] = StringManager.Instance.SpawnString();
      this.ItemCountStr[panelObjectIdx] = new CString[3];
      for (int index = 0; index < 3; ++index)
        this.ItemCountStr[panelObjectIdx][index] = StringManager.Instance.SpawnString();
    }
    if (this.bMain)
    {
      if (dataIdx != 0)
        return;
      dataIdx = this.MM.FindIndexBySN(this.MM.MainData.SN);
    }
    else
    {
      if (dataIdx == 0)
      {
        ((Component) this.ScrollComp[panelObjectIdx].Panel1RC).gameObject.SetActive(false);
        ((Component) this.ScrollComp[panelObjectIdx].BackImage1).gameObject.SetActive(false);
        ((Component) this.ScrollComp[panelObjectIdx].InfoImage).gameObject.SetActive(false);
        ((Component) this.ScrollComp[panelObjectIdx].Panel2RC).gameObject.SetActive(false);
        ((Component) this.ScrollComp[panelObjectIdx].BackImage2).gameObject.SetActive(false);
        ((Component) this.ScrollComp[panelObjectIdx].Panel3RC).gameObject.SetActive(true);
        this.NowCrystalStr.Length = 0;
        StringManager.IntToStr(this.NowCrystalStr, (long) this.DM.RoleAttr.Diamond, bNumber: true);
        this.ScrollComp[panelObjectIdx].CrystalText3.text = this.NowCrystalStr.ToString();
        this.ScrollComp[panelObjectIdx].CrystalText3.SetAllDirty();
        this.ScrollComp[panelObjectIdx].CrystalText3.cachedTextGenerator.Invalidate();
        this.ScrollComp[panelObjectIdx].bTitleCrystal = true;
        return;
      }
      ((Component) this.ScrollComp[panelObjectIdx].Panel3RC).gameObject.SetActive(false);
      this.ScrollComp[panelObjectIdx].bTitleCrystal = false;
      --dataIdx;
    }
    List<MallDataType> mallDataList = this.MM.MallDataList;
    if (dataIdx < 0 || dataIdx >= mallDataList.Count)
      return;
    MallDataType mallData = this.MM.MallDataList[dataIdx];
    this.MM.CalculateTime(dataIdx);
    this.ScrollComp[panelObjectIdx].DataIndex = dataIdx;
    this.ScrollComp[panelObjectIdx].MoreBtn.m_BtnID3 = dataIdx;
    this.ScrollComp[panelObjectIdx].BuyBtn.m_BtnID3 = dataIdx;
    this.ScrollComp[panelObjectIdx].BuyBtn_2.m_BtnID3 = dataIdx;
    ETreasureType type = mallData.Type;
    if (type != ETreasureType.ETST_Crystal)
    {
      ((Component) this.ScrollComp[panelObjectIdx].Panel1RC).gameObject.SetActive(true);
      ((Component) this.ScrollComp[panelObjectIdx].BackImage1).gameObject.SetActive(true);
      ((Component) this.ScrollComp[panelObjectIdx].InfoImage).gameObject.SetActive(true);
      ((Component) this.ScrollComp[panelObjectIdx].Panel2RC).gameObject.SetActive(false);
      ((Component) this.ScrollComp[panelObjectIdx].BackImage2).gameObject.SetActive(false);
      if (this.GM.IsArabic)
      {
        if (mallData.PosType == (byte) 2)
        {
          this.ScrollComp[panelObjectIdx].Panel1RC.anchoredPosition = new Vector2(-130f, 0.0f);
          ((Graphic) this.ScrollComp[panelObjectIdx].InfoImage).rectTransform.anchoredPosition = new Vector2(252f, -134f);
          ((Graphic) this.ScrollComp[panelObjectIdx].StampImage).rectTransform.anchoredPosition = new Vector2(254f, 44f);
        }
        else if (mallData.PosType == (byte) 1)
        {
          this.ScrollComp[panelObjectIdx].Panel1RC.anchoredPosition = new Vector2(128f, 0.0f);
          ((Graphic) this.ScrollComp[panelObjectIdx].InfoImage).rectTransform.anchoredPosition = new Vector2(-266f, -134f);
          ((Graphic) this.ScrollComp[panelObjectIdx].StampImage).rectTransform.anchoredPosition = new Vector2(-257.2f, 22f);
        }
      }
      else if (mallData.PosType == (byte) 1)
      {
        this.ScrollComp[panelObjectIdx].Panel1RC.anchoredPosition = new Vector2(-120f, 0.0f);
        ((Graphic) this.ScrollComp[panelObjectIdx].InfoImage).rectTransform.anchoredPosition = new Vector2(262f, -134f);
        ((Graphic) this.ScrollComp[panelObjectIdx].StampImage).rectTransform.anchoredPosition = new Vector2(254f, 44f);
      }
      else if (mallData.PosType == (byte) 2)
      {
        this.ScrollComp[panelObjectIdx].Panel1RC.anchoredPosition = new Vector2(138f, 0.0f);
        ((Graphic) this.ScrollComp[panelObjectIdx].InfoImage).rectTransform.anchoredPosition = new Vector2(-256f, -134f);
        ((Graphic) this.ScrollComp[panelObjectIdx].StampImage).rectTransform.anchoredPosition = new Vector2(-257.2f, 22f);
      }
      if (mallData.StampPic != (ushort) 0 && (int) mallData.StampPic - 1 < this.ScrollComp[panelObjectIdx].StampSA.m_Sprites.Length)
      {
        ((Component) this.ScrollComp[panelObjectIdx].StampImage).gameObject.SetActive(true);
        this.ScrollComp[panelObjectIdx].StampSA.SetSpriteIndex((int) mallData.StampPic - 1);
        this.ScrollComp[panelObjectIdx].StampHint.Parm1 = mallData.StampHint;
      }
      else
      {
        ((Component) this.ScrollComp[panelObjectIdx].StampImage).gameObject.SetActive(false);
        this.ScrollComp[panelObjectIdx].StampHint.Parm1 = (ushort) 0;
      }
      this.SetBackNameInfo(panelObjectIdx, dataIdx);
      if (mallData.Type == ETreasureType.ETST_SHLevelUp)
      {
        ((Behaviour) this.ScrollComp[panelObjectIdx].TimeText).enabled = false;
        ((Behaviour) this.ScrollComp[panelObjectIdx].TimeImage).enabled = false;
        if (mallData.EndTime > 0L)
        {
          ((Behaviour) this.ScrollComp[panelObjectIdx].TimeText2).enabled = true;
          this.TimeStr[panelObjectIdx].Length = 0;
          GameConstants.GetTimeString(this.TimeStr[panelObjectIdx], mallData.uTime, bShowDay: false);
          this.ScrollComp[panelObjectIdx].TimeText2.text = this.TimeStr[panelObjectIdx].ToString();
          this.ScrollComp[panelObjectIdx].TimeText2.SetAllDirty();
          this.ScrollComp[panelObjectIdx].TimeText2.cachedTextGenerator.Invalidate();
        }
        else
          ((Behaviour) this.ScrollComp[panelObjectIdx].TimeText2).enabled = false;
      }
      else
      {
        ((Behaviour) this.ScrollComp[panelObjectIdx].TimeText2).enabled = false;
        if (mallData.EndTime > 0L)
        {
          ((Behaviour) this.ScrollComp[panelObjectIdx].TimeText).enabled = true;
          ((Behaviour) this.ScrollComp[panelObjectIdx].TimeImage).enabled = true;
          this.TimeStr[panelObjectIdx].Length = 0;
          GameConstants.GetTimeString(this.TimeStr[panelObjectIdx], mallData.uTime);
          this.ScrollComp[panelObjectIdx].TimeText.text = this.TimeStr[panelObjectIdx].ToString();
          this.ScrollComp[panelObjectIdx].TimeText.SetAllDirty();
          this.ScrollComp[panelObjectIdx].TimeText.cachedTextGenerator.Invalidate();
        }
        else
        {
          ((Behaviour) this.ScrollComp[panelObjectIdx].TimeText).enabled = false;
          ((Behaviour) this.ScrollComp[panelObjectIdx].TimeImage).enabled = false;
        }
      }
      this.ScrollComp[panelObjectIdx].GetAllText.text = type != ETreasureType.ETST_Month ? this.DM.mStringTable.GetStringByID(838U) : this.DM.mStringTable.GetStringByID(919U);
      this.ScrollComp[panelObjectIdx].ScaleImage1.enabled = false;
      ((Transform) ((Graphic) this.ScrollComp[panelObjectIdx].Image1).rectTransform).localScale = Vector3.one;
      switch (type)
      {
        case ETreasureType.ETST_Month:
          ((Behaviour) this.ScrollComp[panelObjectIdx].Image1).enabled = true;
          ((Behaviour) this.ScrollComp[panelObjectIdx].Image1Text).enabled = true;
          this.ScrollComp[panelObjectIdx].Image1Text.text = this.DM.mStringTable.GetStringByID(918U);
          this.ScrollComp[panelObjectIdx].BuyOnceSA.SetSpriteIndex((int) mallData.BuyOncePic);
          if ((Object) this.ScrollComp[panelObjectIdx].Image1.sprite == (Object) null)
          {
            this.ScrollComp[panelObjectIdx].BuyOnceSA.SetSpriteIndex(0);
            break;
          }
          break;
        case ETreasureType.ETST_SHLevelUp:
          this.ScrollComp[panelObjectIdx].ScaleImage1.enabled = true;
          ((Behaviour) this.ScrollComp[panelObjectIdx].Image1).enabled = true;
          ((Behaviour) this.ScrollComp[panelObjectIdx].Image1Text).enabled = true;
          this.ScrollComp[panelObjectIdx].Image1Text.text = this.DM.mStringTable.GetStringByID(10075U);
          this.ScrollComp[panelObjectIdx].BuyOnceSA.SetSpriteIndex((int) mallData.BuyOncePic);
          if ((Object) this.ScrollComp[panelObjectIdx].Image1.sprite == (Object) null)
          {
            this.ScrollComp[panelObjectIdx].BuyOnceSA.SetSpriteIndex(0);
            break;
          }
          break;
        default:
          if (mallData.bBuyOnce == (byte) 1)
          {
            ((Behaviour) this.ScrollComp[panelObjectIdx].Image1).enabled = true;
            ((Behaviour) this.ScrollComp[panelObjectIdx].Image1Text).enabled = true;
            this.ScrollComp[panelObjectIdx].Image1Text.text = this.DM.mStringTable.GetStringByID(865U);
            this.ScrollComp[panelObjectIdx].BuyOnceSA.SetSpriteIndex((int) mallData.BuyOncePic);
            if ((Object) this.ScrollComp[panelObjectIdx].Image1.sprite == (Object) null)
            {
              this.ScrollComp[panelObjectIdx].BuyOnceSA.SetSpriteIndex(0);
              break;
            }
            break;
          }
          ((Behaviour) this.ScrollComp[panelObjectIdx].Image1).enabled = false;
          ((Behaviour) this.ScrollComp[panelObjectIdx].Image1Text).enabled = false;
          break;
      }
      if (mallData.BonusRate > (byte) 0)
      {
        ((Behaviour) this.ScrollComp[panelObjectIdx].Image2L).enabled = true;
        ((Behaviour) this.ScrollComp[panelObjectIdx].Image2R).enabled = true;
        this.ScrollComp[panelObjectIdx].RateSA.SetSpriteIndex((int) mallData.BonusRate - 1);
      }
      else
      {
        ((Behaviour) this.ScrollComp[panelObjectIdx].Image2L).enabled = false;
        ((Behaviour) this.ScrollComp[panelObjectIdx].Image2R).enabled = false;
      }
      int point = 0;
      if (!this.MM.GetProductPointByID((int) mallData.TreasureID, out point))
        this.NeedUpDate = true;
      this.CrystalStr[panelObjectIdx].Length = 0;
      if (type == ETreasureType.ETST_Month)
        this.CrystalStr[panelObjectIdx].IntToFormat((long) (mallData.BonusCrystal * 30U), bNumber: true);
      else
        this.CrystalStr[panelObjectIdx].IntToFormat((long) point, bNumber: true);
      this.CrystalStr[panelObjectIdx].AppendFormat("{0}");
      this.ScrollComp[panelObjectIdx].CrystalText.text = this.CrystalStr[panelObjectIdx].ToString();
      this.ScrollComp[panelObjectIdx].CrystalText.SetAllDirty();
      this.ScrollComp[panelObjectIdx].CrystalText.cachedTextGenerator.Invalidate();
      this.CrystalStr2[panelObjectIdx].Length = 0;
      this.CrystalStr2[panelObjectIdx].IntToFormat((long) mallData.BonusCrystal, bNumber: true);
      this.CrystalStr2[panelObjectIdx].AppendFormat("{0}");
      this.ScrollComp[panelObjectIdx].CrystalText2.text = this.CrystalStr2[panelObjectIdx].ToString();
      this.ScrollComp[panelObjectIdx].CrystalText2.SetAllDirty();
      this.ScrollComp[panelObjectIdx].CrystalText2.cachedTextGenerator.Invalidate();
      this.NeedUpDate = this.MM.SetPriceStr(this.PriceStr[panelObjectIdx], (int) mallData.TreasureID, Discount: (byte) 0) || this.NeedUpDate;
      if (mallData.Discount > (byte) 0)
      {
        this.ScrollComp[panelObjectIdx].LableGO.SetActive(true);
        this.ScrollComp[panelObjectIdx].BuyGO1.SetActive(false);
        this.ScrollComp[panelObjectIdx].BuyGO2.SetActive(false);
        this.DisStr[panelObjectIdx].Length = 0;
        this.DisStr[panelObjectIdx].IntToFormat((long) mallData.Discount);
        this.DisStr[panelObjectIdx].AppendFormat("-{0}%");
        this.ScrollComp[panelObjectIdx].Lable_DisText.text = this.DisStr[panelObjectIdx].ToString();
        this.ScrollComp[panelObjectIdx].Lable_DisText.SetAllDirty();
        this.ScrollComp[panelObjectIdx].Lable_DisText.cachedTextGenerator.Invalidate();
        this.MM.SetPriceStr(this.PriceStr2[panelObjectIdx], (int) mallData.TreasureID, true, mallData.Discount);
        this.ScrollComp[panelObjectIdx].Lable_PriceText1.text = this.PriceStr2[panelObjectIdx].ToString();
        ((Graphic) this.ScrollComp[panelObjectIdx].Lable_PriceText1).SetAllDirty();
        this.ScrollComp[panelObjectIdx].Lable_PriceText1.cachedTextGenerator.Invalidate();
        this.ScrollComp[panelObjectIdx].Lable_PriceText2.text = this.PriceStr[panelObjectIdx].ToString();
        ((Graphic) this.ScrollComp[panelObjectIdx].Lable_PriceText2).SetAllDirty();
        this.ScrollComp[panelObjectIdx].Lable_PriceText2.cachedTextGenerator.Invalidate();
      }
      else
      {
        this.ScrollComp[panelObjectIdx].LableGO.SetActive(false);
        this.ScrollComp[panelObjectIdx].BuyGO1.SetActive(true);
        this.ScrollComp[panelObjectIdx].BuyGO2.SetActive(true);
        this.ScrollComp[panelObjectIdx].BuyText.text = this.PriceStr[panelObjectIdx].ToString();
        ((Graphic) this.ScrollComp[panelObjectIdx].BuyText).SetAllDirty();
        this.ScrollComp[panelObjectIdx].BuyText.cachedTextGenerator.Invalidate();
      }
      for (int index = 0; index < 3; ++index)
      {
        if (index == 2)
        {
          if (mallData.BonusCrystal == 0U || mallData.Type == ETreasureType.ETST_Month)
          {
            ((Component) this.ScrollComp[panelObjectIdx].ItemText[index]).gameObject.SetActive(true);
            ((Component) this.ScrollComp[panelObjectIdx].ItemCountText[index]).gameObject.SetActive(true);
          }
          else
          {
            ((Component) this.ScrollComp[panelObjectIdx].ItemText[index]).gameObject.SetActive(false);
            ((Component) this.ScrollComp[panelObjectIdx].ItemCountText[index]).gameObject.SetActive(false);
            this.ScrollComp[panelObjectIdx].ItemT[index].gameObject.SetActive(false);
            this.ScrollComp[panelObjectIdx].ItemT2[index].gameObject.SetActive(false);
            continue;
          }
        }
        Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(mallData.BriefItem[index].ItemID);
        byte equipKind = recordByKey.EquipKind;
        this.ScrollComp[panelObjectIdx].Btn1[index].m_BtnID2 = (int) mallData.BriefItem[index].ItemID;
        this.ScrollComp[panelObjectIdx].Hint1[index].Parm1 = mallData.BriefItem[index].ItemID;
        this.ScrollComp[panelObjectIdx].Hint1[index].Parm2 = mallData.BriefItem[index].ItemRank;
        bool flag = this.GM.IsLeadItem(equipKind);
        if (flag)
          GUIManager.Instance.ChangeLordEquipImg(this.ScrollComp[panelObjectIdx].ItemT2[index], mallData.BriefItem[index].ItemID, mallData.BriefItem[index].ItemRank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        else
          GUIManager.Instance.ChangeHeroItemImg(this.ScrollComp[panelObjectIdx].ItemT[index], eHeroOrItem.Item, mallData.BriefItem[index].ItemID, (byte) 0, (byte) 0);
        if (flag || !this.MM.CheckCanOpenDetail(mallData.BriefItem[index].ItemID))
          this.ScrollComp[panelObjectIdx].Hint1[index].enabled = true;
        else
          this.ScrollComp[panelObjectIdx].Hint1[index].enabled = false;
        this.ScrollComp[panelObjectIdx].ItemT[index].gameObject.SetActive(!flag);
        this.ScrollComp[panelObjectIdx].ItemT2[index].gameObject.SetActive(flag);
        this.ScrollComp[panelObjectIdx].ItemText[index].text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.EquipName);
        ((Graphic) this.ScrollComp[panelObjectIdx].ItemText[index]).color = this.MM.GetItemRankColor(mallData.BriefItem[index].ItemRank);
        this.ItemCountStr[panelObjectIdx][index].Length = 0;
        if (type == ETreasureType.ETST_Month)
          StringManager.IntToStr(this.ItemCountStr[panelObjectIdx][index], (long) ((int) mallData.BriefItem[index].Num * 30), bNumber: true);
        else
          StringManager.IntToStr(this.ItemCountStr[panelObjectIdx][index], (long) mallData.BriefItem[index].Num, bNumber: true);
        this.ScrollComp[panelObjectIdx].ItemCountText[index].text = this.ItemCountStr[panelObjectIdx][index].ToString();
        this.ScrollComp[panelObjectIdx].ItemCountText[index].SetAllDirty();
        this.ScrollComp[panelObjectIdx].ItemCountText[index].cachedTextGenerator.Invalidate();
      }
      if (mallData.BonusCrystal == 0U || type == ETreasureType.ETST_Month)
      {
        ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg2).enabled = false;
        ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalText2).enabled = false;
        ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalText22).enabled = false;
        this.ScrollComp[panelObjectIdx].AllItemRC.anchoredPosition = this.ScrollComp[panelObjectIdx].AllItemOriginPos + new Vector2(0.0f, 62f);
      }
      else
      {
        ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg2).enabled = true;
        ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalText2).enabled = true;
        ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalText22).enabled = true;
        this.ScrollComp[panelObjectIdx].AllItemRC.anchoredPosition = this.ScrollComp[panelObjectIdx].AllItemOriginPos;
      }
    }
    else
    {
      ((Component) this.ScrollComp[panelObjectIdx].Panel1RC).gameObject.SetActive(false);
      ((Component) this.ScrollComp[panelObjectIdx].BackImage1).gameObject.SetActive(false);
      ((Component) this.ScrollComp[panelObjectIdx].InfoImage).gameObject.SetActive(false);
      ((Component) this.ScrollComp[panelObjectIdx].Panel2RC).gameObject.SetActive(true);
      ((Component) this.ScrollComp[panelObjectIdx].BackImage2).gameObject.SetActive(true);
      this.ScrollComp[panelObjectIdx].TitleText_2.text = this.DM.mStringTable.GetStringByID((uint) mallData.StrPackageID);
      int point = 0;
      if (!this.MM.GetProductPointByID((int) mallData.TreasureID, out point))
        this.NeedUpDate = true;
      this.CrystalStr[panelObjectIdx].Length = 0;
      this.CrystalStr[panelObjectIdx].IntToFormat((long) point + (long) mallData.BonusCrystal, bNumber: true);
      this.CrystalStr[panelObjectIdx].AppendFormat("{0}");
      this.ScrollComp[panelObjectIdx].CrystalText_2.text = this.CrystalStr[panelObjectIdx].ToString();
      this.ScrollComp[panelObjectIdx].CrystalText_2.SetAllDirty();
      this.ScrollComp[panelObjectIdx].CrystalText_2.cachedTextGenerator.Invalidate();
      this.NeedUpDate = this.MM.SetPriceStr(this.PriceStr[panelObjectIdx], (int) mallData.TreasureID, Discount: (byte) 0);
      this.ScrollComp[panelObjectIdx].BuyText_2.text = this.PriceStr[panelObjectIdx].ToString();
      ((Graphic) this.ScrollComp[panelObjectIdx].BuyText_2).SetAllDirty();
      this.ScrollComp[panelObjectIdx].BuyText_2.cachedTextGenerator.Invalidate();
      Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(mallData.BriefItem[0].ItemID);
      this.ScrollComp[panelObjectIdx].Btn2.m_BtnID2 = (int) mallData.BriefItem[0].ItemID;
      this.ScrollComp[panelObjectIdx].Hint2.Parm1 = mallData.BriefItem[0].ItemID;
      this.ScrollComp[panelObjectIdx].Hint2.Parm2 = mallData.BriefItem[0].ItemRank;
      GUIManager.Instance.ChangeHeroItemImg(this.ScrollComp[panelObjectIdx].ItemT_2, eHeroOrItem.Item, mallData.BriefItem[0].ItemID, (byte) 0, (byte) 0);
      if (!this.MM.CheckCanOpenDetail(mallData.BriefItem[0].ItemID))
        this.ScrollComp[panelObjectIdx].Hint2.enabled = true;
      else
        this.ScrollComp[panelObjectIdx].Hint2.enabled = false;
      this.ScrollComp[panelObjectIdx].ItemText_2.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.EquipName);
      this.ItemCountStr[panelObjectIdx][0].Length = 0;
      StringManager.IntToStr(this.ItemCountStr[panelObjectIdx][0], (long) mallData.BriefItem[0].Num, bNumber: true);
      this.ScrollComp[panelObjectIdx].ItemCountText_2.text = this.ItemCountStr[panelObjectIdx][0].ToString();
      this.ScrollComp[panelObjectIdx].ItemCountText_2.SetAllDirty();
      this.ScrollComp[panelObjectIdx].ItemCountText_2.cachedTextGenerator.Invalidate();
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (sender.Parm2 == (byte) 100 && sender.Parm1 != (ushort) 0)
      this.GM.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 0, 277f, 20, (int) sender.Parm1, 0, Vector2.zero);
    else if (this.IsJapan && sender.Parm1 == (ushort) 0 && sender.Parm2 == byte.MaxValue)
    {
      this.JPHintObject.gameObject.SetActive(true);
    }
    else
    {
      if (this.GM.IsLeadItem(DataManager.Instance.EquipTable.GetRecordByKey(sender.Parm1).EquipKind))
      {
        sender.SetFadeOutObject(EUIButtonHint.UILeBtn);
        this.GM.m_LordInfo.Show(sender, sender.Parm1, sender.Parm2);
      }
      else
      {
        sender.SetFadeOutObject(EUIButtonHint.UIHIBtn);
        this.GM.m_SimpleItemInfo.Show(sender, sender.Parm1);
      }
      AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
    }
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if (sender.Parm2 == (byte) 100)
      this.GM.m_Hint.Hide();
    else if (this.IsJapan && sender.Parm1 == (ushort) 0 && sender.Parm2 == byte.MaxValue)
      this.JPHintObject.gameObject.SetActive(false);
    else if (this.GM.IsLeadItem(DataManager.Instance.EquipTable.GetRecordByKey(sender.Parm1).EquipKind))
      this.GM.m_LordInfo.Hide(sender);
    else
      GUIManager.Instance.m_SimpleItemInfo.Hide(sender);
  }

  private void CloseSelf()
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (Object) menu)
      menu.CloseMenu();
    this.GM.UIQueueLockRelease(EGUIQueueLock.UIQL_Mall);
  }

  public override bool OnBackButtonClick()
  {
    this.CloseSelf();
    return true;
  }

  private void SavePos()
  {
    this.MM.MallUIIndex = this.Scroll.GetTopIdx();
    this.MM.MallUIPos = this.cScrollRect.content.anchoredPosition.y;
  }

  private void BeginEffect(bool bReverse = false)
  {
    if ((bool) (Object) this.EffectRC)
    {
      this.EffectRC = (RectTransform) null;
      this.EffectTimer = 0.0f;
      this.FGTimer = 0.0f;
      if ((Object) this.EffectParticle != (Object) null)
      {
        if (this.EffectParticle.activeSelf && (Object) ParticleManager.Instance.AllEffectObject != (Object) null)
          this.EffectParticle.transform.SetParent(ParticleManager.Instance.AllEffectObject.transform, false);
        this.EffectParticle = (GameObject) null;
      }
    }
    this.EffectReverse = bReverse;
    if (!this.EffectReverse)
    {
      this.MM.SetShowEffect(false);
      this.EffectRC = this.m_transform.GetChild(11).GetComponent<RectTransform>();
      this.EffectImage1 = this.m_transform.GetChild(11).GetComponent<Image>();
      this.EffectImage2 = this.m_transform.GetChild(11).GetChild(0).GetComponent<Image>();
      this.EffectRC.anchoredPosition = Vector2.zero;
      this.EffectScale = 0.0f;
      ((Transform) this.EffectRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
      this.Effectalpha = 0.0f;
      ((Graphic) this.EffectImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
      ((Graphic) this.EffectImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
      ((Transform) this.FGRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
      ((Graphic) this.FGImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
      ((Graphic) this.FGImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
      this.EffectPos = (Transform) this.m_transform.GetChild(12).GetComponent<RectTransform>();
      this.EffectPos.gameObject.SetActive(true);
      this.EffectPos.localPosition = new Vector3(0.0f, 0.0f, -700f);
      ((Component) this.EffectRC).gameObject.SetActive(true);
      this.EffectParticle = ParticleManager.Instance.Spawn((ushort) 433, this.EffectPos.transform, new Vector3(0.0f, 0.0f, 0.0f), 1f, true);
      this.EffectParticle.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
      this.EffectParticle.transform.localRotation = new Quaternion(0.0f, 0.0f, 0.0f, 0.0f);
      GUIManager.Instance.SetLayer(this.EffectParticle, 5);
      AudioManager.Instance.PlayUISFX(UIKind.Crystal_Show);
      this.SetFGBtn();
    }
    else
    {
      this.EffectRC = this.m_transform.GetChild(11).GetComponent<RectTransform>();
      this.EffectImage1 = this.m_transform.GetChild(11).GetComponent<Image>();
      this.EffectImage2 = this.m_transform.GetChild(11).GetChild(0).GetComponent<Image>();
      this.EffectRC.anchoredPosition = new Vector2((float) ((double) GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.x / 2.0 - 38.0), (float) -((double) GUIManager.Instance.m_SpeciallyEffect.mCanvasRT.sizeDelta.y / 2.0 - 49.0));
      this.EffectScale = 0.6f;
      ((Transform) this.EffectRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
      this.Effectalpha = 0.17f;
      ((Graphic) this.EffectImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
      ((Graphic) this.EffectImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
      this.EffectScale = 1f;
      ((Transform) this.FGRC).localScale = new Vector3(this.EffectScale, this.EffectScale, this.EffectScale);
      this.Effectalpha = 1f;
      ((Graphic) this.FGImage1).color = new Color(1f, 1f, 1f, this.Effectalpha);
      ((Graphic) this.FGImage2).color = new Color(1f, 1f, 1f, this.Effectalpha);
      this.EffectPos = (Transform) this.m_transform.GetChild(12).GetComponent<RectTransform>();
      this.EffectPos.gameObject.SetActive(true);
      this.EffectPos.localPosition = new Vector3(0.0f, 0.0f, -700f);
      ((Component) this.EffectRC).gameObject.SetActive(true);
      this.FGGO.SetActive(true);
      GUIManager.Instance.pDVMgr.ShowMallGetItemText();
    }
  }

  private void EndEffect()
  {
    this.EffectRC = (RectTransform) null;
    this.EffectTimer = 0.0f;
    this.FGTimer = 0.0f;
    this.EffectParticle = (GameObject) null;
    ((Transform) this.FGRC).localScale = new Vector3(1f, 1f, 1f);
    ((Graphic) this.FGImage1).color = new Color(1f, 1f, 1f, 1f);
    ((Graphic) this.FGImage2).color = new Color(1f, 1f, 1f, 1f);
    this.SetFGBtn();
    GUIManager.Instance.pDVMgr.BeginMoveBossText();
  }

  private void BeginGetCrystal(int getCrystal)
  {
    if (this.bPlayGetCrystal)
      this.EndGetCrystal();
    this.bPlayGetCrystal = true;
    ((Graphic) this.FGEffImage1).color = new Color(1f, 1f, 1f, 0.2f);
    ((Graphic) this.FGEffImage2).color = new Color(1f, 1f, 1f, 0.2f);
    ((Graphic) this.FGEffImage2).rectTransform.anchoredPosition = new Vector2(0.0f, 15f);
    ((Graphic) this.FGEffText).color = new Color(((Graphic) this.FGEffText).color.r, ((Graphic) this.FGEffText).color.g, ((Graphic) this.FGEffText).color.b, 0.2f);
    ((Graphic) this.FGEffText).rectTransform.anchoredPosition = new Vector2(0.0f, 10f);
    this.FGEffStr.Length = 0;
    this.FGEffStr.IntToFormat((long) getCrystal);
    this.FGEffStr.AppendFormat("+{0}");
    this.FGEffText.text = this.FGEffStr.ToString();
    this.FGEffText.SetAllDirty();
    this.FGEffText.cachedTextGenerator.Invalidate();
    ((Component) this.FGEffText).gameObject.SetActive(true);
    ((Component) this.FGEffImage1).gameObject.SetActive(true);
    ((Component) this.FGEffImage2).gameObject.SetActive(true);
    AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
  }

  private void EndGetCrystal()
  {
    this.bPlayGetCrystal = false;
    this.GetCrystalNowTime = 0.0f;
    ((Component) this.FGEffText).gameObject.SetActive(false);
    ((Component) this.FGEffImage1).gameObject.SetActive(false);
    ((Component) this.FGEffImage2).gameObject.SetActive(false);
  }
}
