// Decompiled with JetBrains decompiler
// Type: UIMall_Detail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIMall_Detail : 
  GUIWindow,
  UILoadImageHander,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUILEBtnClickHandler
{
  private const int UnitCount = 9;
  private Transform m_transform;
  private DataManager DM;
  private GUIManager GM;
  private MallManager MM;
  private Font tmpFont;
  private Door m_door;
  private CString TimeStr;
  private UIText TimeText;
  private Image Back;
  private UIText PackageName;
  private CScrollRect cScrollRect;
  private ScrollPanel Scroll;
  private List<float> NowHeightList = new List<float>();
  private int DataIndex;
  private MallDataType tmpData;
  private ushort SN;
  private byte ItemCount;
  private bool[] bFindScrollComp = new bool[9];
  private UnitComp_MallDetail[] ScrollComp = new UnitComp_MallDetail[9];
  private CString[] CountStr = new CString[9];
  private CString[] NameStr = new CString[9];
  private CString PriceStr;
  private CString DisStr;
  private CString PriceStr2;
  private Color ItemNameCrystalColor = new Color(1f, 0.9333f, 0.6196f);
  private Color ItemCountOriginColor = new Color(1f, 1f, 1f);
  private Color ItemCountOutLineOriginColor = new Color(0.3725f, 0.0862f, 0.0f);
  private Color ItemCountCrystalColor = new Color(0.2f, 0.921f, 0.404f);
  private Color ItemCountCrystalOutLineColor = new Color(0.1882f, 0.0862f, 0.06274f);
  private Vector2 OriginImagePos;
  private Vector2 OriginCountPos;
  private bool NeedUpDate;
  private int UIIndex = -1;
  private float UIPos;
  private Text PriceText;
  private UIText BuyText;
  private UIText GatAllText;
  private UIText OnceText;
  private bool bLastItem;
  private byte AllianceGiftCount;
  private Color TimeTextColor = new Color(1f, 0.9411f, 0.5568f);
  private bool bResourceRed;
  private float ResourceRedTime;
  private bool bLVUPPack;
  public UIText Lable_DisText;
  public Text Lable_PriceText1;
  public Text Lable_PriceText2;
  private bool OpenEnd;

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
    this.MM = MallManager.Instance;
    this.m_transform = this.transform;
    this.tmpFont = this.GM.GetTTFFont();
    this.DataIndex = arg1;
    this.tmpData = this.MM.MallDataList[arg1];
    this.SN = this.tmpData.SN;
    this.bLastItem = this.CheckShowLastItem();
    this.Back = this.m_transform.GetChild(2).GetComponent<Image>();
    ((Graphic) this.m_transform.GetChild(4).GetComponent<Image>()).color = this.tmpData.FrameColor;
    this.m_transform.GetChild(21).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(21).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 3;
    this.m_transform.GetChild(21).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(21).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(21).GetComponent<CustomImage>()).enabled = false;
    this.m_transform.GetChild(19).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    if (this.tmpData.SetNo == (ushort) 0 || this.tmpData.SetNo == ushort.MaxValue)
      this.m_transform.GetChild(19).gameObject.SetActive(false);
    Transform child1 = this.m_transform.GetChild(20);
    child1.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.BuyText = child1.GetChild(1).GetComponent<UIText>();
    this.BuyText.font = this.tmpFont;
    this.BuyText.text = this.DM.mStringTable.GetStringByID(866U);
    this.PriceStr = StringManager.Instance.SpawnString();
    this.NeedUpDate = this.MM.SetPriceStr(this.PriceStr, (int) this.tmpData.TreasureID, Discount: (byte) 0);
    this.PriceText = child1.GetChild(0).GetComponent<Text>();
    this.PriceText.font = this.tmpFont;
    if (this.GM.IsArabic)
      ((Transform) ((Graphic) this.PriceText).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    if (this.tmpData.Discount > (byte) 0)
    {
      child1.GetChild(0).gameObject.SetActive(false);
      child1.GetChild(1).gameObject.SetActive(false);
      child1.GetChild(4).gameObject.SetActive(true);
      this.Lable_DisText = child1.GetChild(4).GetChild(0).GetComponent<UIText>();
      this.Lable_DisText.font = this.tmpFont;
      this.DisStr = StringManager.Instance.SpawnString();
      this.DisStr.Length = 0;
      this.DisStr.IntToFormat((long) this.tmpData.Discount);
      this.DisStr.AppendFormat("-{0}%");
      this.Lable_DisText.text = this.DisStr.ToString();
      this.Lable_DisText.SetAllDirty();
      this.Lable_DisText.cachedTextGenerator.Invalidate();
      this.Lable_PriceText1 = child1.GetChild(4).GetChild(1).GetComponent<Text>();
      this.Lable_PriceText1.font = this.tmpFont;
      if (this.GM.IsArabic)
        ((Transform) ((Graphic) this.Lable_PriceText1).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
      this.PriceStr2 = StringManager.Instance.SpawnString();
      this.MM.SetPriceStr(this.PriceStr2, (int) this.tmpData.TreasureID, true, this.tmpData.Discount);
      this.Lable_PriceText1.text = this.PriceStr2.ToString();
      ((Graphic) this.Lable_PriceText1).SetAllDirty();
      this.Lable_PriceText1.cachedTextGenerator.Invalidate();
      this.Lable_PriceText2 = child1.GetChild(4).GetChild(2).GetComponent<Text>();
      this.Lable_PriceText2.font = this.tmpFont;
      if (this.GM.IsArabic)
        ((Transform) ((Graphic) this.Lable_PriceText2).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
      this.Lable_PriceText2.text = this.PriceStr.ToString();
      ((Graphic) this.Lable_PriceText2).SetAllDirty();
      this.Lable_PriceText2.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.PriceText.text = this.PriceStr.ToString();
      ((Graphic) this.PriceText).SetAllDirty();
      this.PriceText.cachedTextGenerator.Invalidate();
    }
    if (this.tmpData.BonusRate > (byte) 0)
    {
      this.m_transform.GetChild(14).GetComponent<UISpritesArray>().SetSpriteIndex((int) this.tmpData.BonusRate - 1);
    }
    else
    {
      ((Behaviour) this.m_transform.GetChild(14).GetComponent<Image>()).enabled = false;
      ((Behaviour) this.m_transform.GetChild(15).GetComponent<Image>()).enabled = false;
    }
    this.PackageName = this.m_transform.GetChild(7).GetComponent<UIText>();
    this.PackageName.font = this.tmpFont;
    this.GatAllText = this.m_transform.GetChild(16).GetComponent<UIText>();
    this.GatAllText.font = this.tmpFont;
    this.GatAllText.text = this.tmpData.Type != ETreasureType.ETST_Month ? this.DM.mStringTable.GetStringByID(838U) : this.DM.mStringTable.GetStringByID(919U);
    if (this.tmpData.Type == ETreasureType.ETST_Month)
    {
      this.OnceText = this.m_transform.GetChild(13).GetComponent<UIText>();
      this.OnceText.font = this.tmpFont;
      this.OnceText.text = this.DM.mStringTable.GetStringByID(918U);
    }
    else if (this.tmpData.Type == ETreasureType.ETST_SHLevelUp)
    {
      this.OnceText = this.m_transform.GetChild(13).GetComponent<UIText>();
      this.OnceText.font = this.tmpFont;
      this.OnceText.text = this.DM.mStringTable.GetStringByID(10075U);
    }
    else if (this.tmpData.bBuyOnce == (byte) 1)
    {
      this.OnceText = this.m_transform.GetChild(13).GetComponent<UIText>();
      this.OnceText.font = this.tmpFont;
      this.OnceText.text = this.DM.mStringTable.GetStringByID(865U);
    }
    else
    {
      this.m_transform.GetChild(13).gameObject.SetActive(false);
      this.m_transform.GetChild(12).gameObject.SetActive(false);
    }
    this.TimeStr = StringManager.Instance.SpawnString();
    this.SetTimeTextAndPic();
    Transform child2 = this.m_transform.GetChild(18);
    this.GM.InitianHeroItemImg(child2.GetChild(2), eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    child2.GetChild(2).gameObject.AddComponent<IgnoreRaycast>();
    this.GM.InitLordEquipImg(child2.GetChild(3), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    child2.GetChild(3).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
    child2.GetChild(4).GetComponent<UIText>().font = this.tmpFont;
    child2.GetChild(5).GetComponent<UIText>().font = this.tmpFont;
    child2.GetChild(6).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
    this.SetBackName();
    this.Scroll = this.m_transform.GetChild(17).GetComponent<ScrollPanel>();
    this.Scroll.IntiScrollPanel(358f, 0.0f, 0.0f, this.NowHeightList, 9, (IUpDateScrollPanel) this);
    this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
    UIButtonHint.scrollRect = this.cScrollRect;
    this.UpDateList();
    this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
    if (!this.tmpData.bAskDetailData)
    {
      if (this.MM.FindIndexBySN(this.tmpData.SN) != -1)
      {
        this.MM.bSendMallInfo = true;
        this.MM.AutoDetailSN = this.tmpData.SN;
        GUIManager.Instance.ShowUILock(EUILock.Mall);
      }
      else if ((Object) this.door != (Object) null)
        this.door.CloseMenu();
    }
    this.OpenEnd = true;
  }

  public override void OnClose()
  {
    if (this.TimeStr != null)
      StringManager.Instance.DeSpawnString(this.TimeStr);
    for (int index = 0; index < 9; ++index)
    {
      if (this.CountStr[index] != null)
        StringManager.Instance.DeSpawnString(this.CountStr[index]);
      if (this.NameStr[index] != null)
        StringManager.Instance.DeSpawnString(this.NameStr[index]);
    }
    StringManager.Instance.DeSpawnString(this.PriceStr);
    StringManager.Instance.DeSpawnString(this.DisStr);
    StringManager.Instance.DeSpawnString(this.PriceStr2);
    this.tmpData.UnloadAB();
  }

  private void UpDatePriceAndCrystal()
  {
    if (!this.OpenEnd)
      return;
    this.MM.SetPriceStr(this.PriceStr, (int) this.tmpData.TreasureID, Discount: (byte) 0);
    if (this.tmpData.Discount > (byte) 0)
    {
      this.MM.SetPriceStr(this.PriceStr2, (int) this.tmpData.TreasureID, true, this.tmpData.Discount);
      this.Lable_PriceText1.text = this.PriceStr2.ToString();
      ((Graphic) this.Lable_PriceText1).SetAllDirty();
      this.Lable_PriceText1.cachedTextGenerator.Invalidate();
      this.Lable_PriceText2.text = this.PriceStr.ToString();
      ((Graphic) this.Lable_PriceText2).SetAllDirty();
      this.Lable_PriceText2.cachedTextGenerator.Invalidate();
    }
    else
    {
      this.PriceText.text = this.PriceStr.ToString();
      ((Graphic) this.PriceText).SetAllDirty();
      this.PriceText.cachedTextGenerator.Invalidate();
    }
    for (int index = 0; index < 9; ++index)
    {
      if (this.bFindScrollComp[index] && this.ScrollComp[index].DataIndex == 0)
      {
        int point = 0;
        this.MM.GetProductPointByID((int) this.tmpData.TreasureID, out point);
        this.CountStr[index].Length = 0;
        StringManager.IntToStr(this.CountStr[index], (long) (uint) point, bNumber: true);
        this.ScrollComp[index].ItemCountText.text = this.CountStr[index].ToString();
        this.ScrollComp[index].ItemCountText.SetAllDirty();
        this.ScrollComp[index].ItemCountText.cachedTextGenerator.Invalidate();
      }
    }
  }

  private void Update()
  {
    if (this.NeedUpDate && IGGGameSDK.Instance.bPaymentReady)
    {
      this.NeedUpDate = false;
      this.UpDatePriceAndCrystal();
    }
    if (!this.bLVUPPack || !((Object) this.TimeText != (Object) null))
      return;
    this.ResourceRedTime += Time.deltaTime;
    if ((double) this.ResourceRedTime < 0.5)
      return;
    this.ResourceRedTime = 0.0f;
    this.bResourceRed = !this.bResourceRed;
    if (this.bResourceRed)
      ((Graphic) this.TimeText).color = Color.red;
    else
      ((Graphic) this.TimeText).color = Color.white;
  }

  private void UpdateTime()
  {
    if ((Object) this.TimeText == (Object) null)
      return;
    this.TimeStr.Length = 0;
    if (this.bLVUPPack)
      GameConstants.GetTimeString(this.TimeStr, this.tmpData.uTime, bShowDay: false);
    else
      GameConstants.GetTimeString(this.TimeStr, this.tmpData.uTime);
    this.TimeText.text = this.TimeStr.ToString();
    this.TimeText.SetAllDirty();
    this.TimeText.cachedTextGenerator.Invalidate();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
        break;
      case NetworkNews.Refresh:
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        for (int index = 0; index < 9; ++index)
        {
          if (this.bFindScrollComp[index])
          {
            if ((Object) this.ScrollComp[index].ItemName != (Object) null && ((Behaviour) this.ScrollComp[index].ItemName).enabled)
            {
              ((Behaviour) this.ScrollComp[index].ItemName).enabled = false;
              ((Behaviour) this.ScrollComp[index].ItemName).enabled = true;
            }
            if ((Object) this.ScrollComp[index].ItemCountText != (Object) null && ((Behaviour) this.ScrollComp[index].ItemCountText).enabled)
            {
              ((Behaviour) this.ScrollComp[index].ItemCountText).enabled = false;
              ((Behaviour) this.ScrollComp[index].ItemCountText).enabled = true;
            }
            if ((Object) this.ScrollComp[index].HIBtn != (Object) null)
              this.ScrollComp[index].HIBtn.Refresh_FontTexture();
          }
        }
        if ((Object) this.PriceText != (Object) null && ((Behaviour) this.PriceText).enabled)
        {
          ((Behaviour) this.PriceText).enabled = false;
          ((Behaviour) this.PriceText).enabled = true;
        }
        if ((Object) this.BuyText != (Object) null && ((Behaviour) this.BuyText).enabled)
        {
          ((Behaviour) this.BuyText).enabled = false;
          ((Behaviour) this.BuyText).enabled = true;
        }
        if ((Object) this.GatAllText != (Object) null && ((Behaviour) this.GatAllText).enabled)
        {
          ((Behaviour) this.GatAllText).enabled = false;
          ((Behaviour) this.GatAllText).enabled = true;
        }
        if ((Object) this.OnceText != (Object) null && ((Behaviour) this.OnceText).enabled)
        {
          ((Behaviour) this.OnceText).enabled = false;
          ((Behaviour) this.OnceText).enabled = true;
        }
        if ((Object) this.PackageName != (Object) null && ((Behaviour) this.PackageName).enabled)
        {
          ((Behaviour) this.PackageName).enabled = false;
          ((Behaviour) this.PackageName).enabled = true;
        }
        if ((Object) this.TimeText != (Object) null && ((Behaviour) this.TimeText).enabled)
        {
          ((Behaviour) this.TimeText).enabled = false;
          ((Behaviour) this.TimeText).enabled = true;
        }
        if ((Object) this.Lable_DisText != (Object) null && ((Behaviour) this.Lable_DisText).enabled)
        {
          ((Behaviour) this.Lable_DisText).enabled = false;
          ((Behaviour) this.Lable_DisText).enabled = true;
        }
        if ((Object) this.Lable_PriceText1 != (Object) null && ((Behaviour) this.Lable_PriceText1).enabled)
        {
          ((Behaviour) this.Lable_PriceText1).enabled = false;
          ((Behaviour) this.Lable_PriceText1).enabled = true;
        }
        if (!((Object) this.Lable_PriceText2 != (Object) null) || !((Behaviour) this.Lable_PriceText2).enabled)
          break;
        ((Behaviour) this.Lable_PriceText2).enabled = false;
        ((Behaviour) this.Lable_PriceText2).enabled = true;
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
        if (this.DataIndex != arg2 || !(bool) (Object) this.door)
          break;
        this.door.CloseMenu();
        break;
      case 4:
        this.MM.AutoDetailSN = this.SN;
        break;
      case 5:
        this.SetBackName();
        break;
      case 6:
        this.bLastItem = this.CheckShowLastItem();
        if ((Object) this.m_transform != (Object) null && this.tmpData != null)
        {
          this.DataIndex = this.MM.FindIndexBySN(this.SN);
          this.tmpData = this.MM.MallDataList[this.DataIndex];
          this.SetTimeTextAndPic();
          ((Graphic) this.m_transform.GetChild(4).GetComponent<Image>()).color = this.tmpData.FrameColor;
        }
        this.SavePos();
        this.UpDateList();
        this.SetBackName();
        break;
    }
  }

  private void UpDateList()
  {
    this.ItemCount = (byte) 0;
    this.NowHeightList.Clear();
    this.NowHeightList.Add(55f);
    ++this.ItemCount;
    if (this.tmpData.BonusCrystal > 0U && this.tmpData.Type != ETreasureType.ETST_Month)
    {
      this.NowHeightList.Add(55f);
      ++this.ItemCount;
    }
    for (int index = 0; index < (int) this.tmpData.DataLen; ++index)
    {
      if (this.tmpData.Item[index].ItemID != (ushort) 0)
      {
        this.NowHeightList.Add(55f);
        ++this.ItemCount;
      }
    }
    this.AllianceGiftCount = (byte) 0;
    for (int index = 0; index < this.tmpData.AllianceGift.Length; ++index)
    {
      if (this.tmpData.AllianceGift[index].ItemID != (ushort) 0)
      {
        this.NowHeightList.Add(55f);
        ++this.ItemCount;
        ++this.AllianceGiftCount;
      }
    }
    if (this.bLastItem)
    {
      this.NowHeightList.Add(55f);
      this.NowHeightList.Add(55f);
      ++this.ItemCount;
      ++this.ItemCount;
    }
    this.Scroll.AddNewDataHeight(this.NowHeightList);
    if (this.UIIndex != -1)
      this.Scroll.GoTo(this.UIIndex, this.UIPos);
    this.UpdateTime();
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelObjectIdx >= 9)
      return;
    Vector2 zero = Vector2.zero;
    if (!this.bFindScrollComp[panelObjectIdx])
    {
      this.bFindScrollComp[panelObjectIdx] = true;
      this.ScrollComp[panelObjectIdx].CrystalImg = item.transform.GetChild(1).GetComponent<Image>();
      this.ScrollComp[panelObjectIdx].HIBtn = item.transform.GetChild(2).GetComponent<UIHIBtn>();
      this.ScrollComp[panelObjectIdx].HIBtn.m_Handler = (IUIHIBtnClickHandler) this;
      this.ScrollComp[panelObjectIdx].Hint = item.transform.GetChild(2).GetComponent<UIButtonHint>();
      this.ScrollComp[panelObjectIdx].LEBtn = item.transform.GetChild(3).GetComponent<UILEBtn>();
      this.ScrollComp[panelObjectIdx].LEBtn.m_Handler = (IUILEBtnClickHandler) this;
      this.ScrollComp[panelObjectIdx].ItemName = item.transform.GetChild(4).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].ItemCountRC = item.transform.GetChild(5).GetComponent<RectTransform>();
      this.ScrollComp[panelObjectIdx].ItemCountText = item.transform.GetChild(5).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].ItemCountOutline = item.transform.GetChild(5).GetComponent<Outline>();
      this.ScrollComp[panelObjectIdx].LineImage = item.transform.GetChild(0).GetComponent<Image>();
      this.ScrollComp[panelObjectIdx].Btn3 = item.transform.GetChild(6).GetComponent<UIButton>();
      this.ScrollComp[panelObjectIdx].Hint3 = item.transform.GetChild(6).GetComponent<UIButtonHint>();
      this.ScrollComp[panelObjectIdx].Hint3.m_Handler = (MonoBehaviour) this;
      this.ScrollComp[panelObjectIdx].Hint3.DelayTime = 0.2f;
      this.OriginImagePos = ((Graphic) this.ScrollComp[panelObjectIdx].CrystalImg).rectTransform.anchoredPosition;
      this.OriginCountPos = this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition;
      this.CountStr[panelObjectIdx] = StringManager.Instance.SpawnString();
      this.NameStr[panelObjectIdx] = StringManager.Instance.SpawnString(150);
      if (this.GM.IsArabic)
        this.ScrollComp[panelObjectIdx].ItemCountText.AdjuestUI();
    }
    if (dataIdx < 0 || dataIdx > (int) this.ItemCount)
      return;
    int num1 = this.tmpData.BonusCrystal <= 0U || this.tmpData.Type == ETreasureType.ETST_Month ? 0 : 1;
    ushort num2 = 1;
    byte num3 = 0;
    this.ScrollComp[panelObjectIdx].DataIndex = -1;
    uint x;
    if (this.tmpData.AllianceGiftShowTop == (byte) 1)
    {
      if (dataIdx == 0)
      {
        int point = 0;
        if (!this.MM.GetProductPointByID((int) this.tmpData.TreasureID, out point))
          this.NeedUpDate = true;
        x = this.tmpData.Type != ETreasureType.ETST_Month ? (uint) point : this.tmpData.BonusCrystal * 30U;
        this.ScrollComp[panelObjectIdx].DataIndex = dataIdx;
        this.ScrollComp[panelObjectIdx].ItemName.text = string.Empty;
        ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = true;
        ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(false);
        ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(false);
        ((Component) this.ScrollComp[panelObjectIdx].Btn3).gameObject.SetActive(false);
        ((Graphic) this.ScrollComp[panelObjectIdx].CrystalImg).rectTransform.anchoredPosition = this.OriginImagePos + new Vector2(218f, 0.0f);
        this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleCenter;
        ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = this.ItemNameCrystalColor;
        Vector2 vector2 = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos + new Vector2(-15f, 0.0f));
        this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = vector2;
      }
      else if (num1 == 1 && dataIdx == 1)
      {
        x = this.tmpData.BonusCrystal;
        ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = true;
        ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(false);
        ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(false);
        ((Component) this.ScrollComp[panelObjectIdx].Btn3).gameObject.SetActive(false);
        ((Graphic) this.ScrollComp[panelObjectIdx].CrystalImg).rectTransform.anchoredPosition = this.OriginImagePos;
        this.ScrollComp[panelObjectIdx].ItemName.fontSize = 28;
        this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 28;
        ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = this.ItemCountCrystalColor;
        ((Shadow) this.ScrollComp[panelObjectIdx].ItemCountOutline).effectColor = this.ItemCountCrystalOutLineColor;
        Vector2 vector2 = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos);
        this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = vector2;
        this.ScrollComp[panelObjectIdx].ItemCountText.alignment = !this.GM.IsArabic ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft;
        ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = this.ItemNameCrystalColor;
      }
      else if (dataIdx > num1 && dataIdx < (int) this.AllianceGiftCount + (num1 + 1))
      {
        int index = dataIdx - (num1 + 1);
        num2 = this.tmpData.AllianceGift[index].ItemID;
        x = (uint) this.tmpData.AllianceGift[index].Num;
        ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = false;
        ((Graphic) this.ScrollComp[panelObjectIdx].CrystalImg).rectTransform.anchoredPosition = this.OriginImagePos;
        this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
        this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
        ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = this.ItemCountOriginColor;
        ((Shadow) this.ScrollComp[panelObjectIdx].ItemCountOutline).effectColor = this.ItemCountOutLineOriginColor;
        Vector2 vector2 = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos);
        this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = vector2;
        this.ScrollComp[panelObjectIdx].ItemCountText.alignment = !this.GM.IsArabic ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft;
        ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = this.ItemCountOriginColor;
      }
      else
      {
        if (this.bLastItem && dataIdx == (int) this.ItemCount - 1)
        {
          num2 = (ushort) 1255;
          x = 1U;
        }
        else if (this.bLastItem && dataIdx == (int) this.ItemCount - 2)
        {
          num2 = (ushort) 1309;
          x = 1U;
        }
        else
        {
          int index = dataIdx - (num1 + 1) - (int) this.AllianceGiftCount;
          num2 = this.tmpData.Item[index].ItemID;
          x = this.tmpData.Type != ETreasureType.ETST_Month ? (uint) this.tmpData.Item[index].Num : (uint) this.tmpData.Item[index].Num * 30U;
          num3 = this.tmpData.Item[index].ItemRank;
        }
        ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = false;
        ((Graphic) this.ScrollComp[panelObjectIdx].CrystalImg).rectTransform.anchoredPosition = this.OriginImagePos;
        this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
        this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
        ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = this.ItemCountOriginColor;
        ((Shadow) this.ScrollComp[panelObjectIdx].ItemCountOutline).effectColor = this.ItemCountOutLineOriginColor;
        Vector2 vector2 = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos);
        this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = vector2;
        this.ScrollComp[panelObjectIdx].ItemCountText.alignment = !this.GM.IsArabic ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft;
        ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = this.ItemCountOriginColor;
      }
    }
    else if (dataIdx == 0)
    {
      int point = 0;
      if (!this.MM.GetProductPointByID((int) this.tmpData.TreasureID, out point))
        this.NeedUpDate = true;
      x = this.tmpData.Type != ETreasureType.ETST_Month ? (uint) point : this.tmpData.BonusCrystal * 30U;
      this.ScrollComp[panelObjectIdx].DataIndex = dataIdx;
      this.ScrollComp[panelObjectIdx].ItemName.text = string.Empty;
      ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = true;
      ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(false);
      ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(false);
      ((Component) this.ScrollComp[panelObjectIdx].Btn3).gameObject.SetActive(false);
      ((Graphic) this.ScrollComp[panelObjectIdx].CrystalImg).rectTransform.anchoredPosition = this.OriginImagePos + new Vector2(218f, 0.0f);
      this.ScrollComp[panelObjectIdx].ItemCountText.alignment = TextAnchor.MiddleCenter;
      ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = this.ItemNameCrystalColor;
      Vector2 vector2 = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos + new Vector2(-15f, 0.0f));
      this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = vector2;
    }
    else if (num1 == 1 && dataIdx == 1)
    {
      x = this.tmpData.BonusCrystal;
      ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = true;
      ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(false);
      ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(false);
      ((Component) this.ScrollComp[panelObjectIdx].Btn3).gameObject.SetActive(false);
      ((Graphic) this.ScrollComp[panelObjectIdx].CrystalImg).rectTransform.anchoredPosition = this.OriginImagePos;
      this.ScrollComp[panelObjectIdx].ItemName.fontSize = 28;
      this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 28;
      ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = this.ItemCountCrystalColor;
      ((Shadow) this.ScrollComp[panelObjectIdx].ItemCountOutline).effectColor = this.ItemCountCrystalOutLineColor;
      Vector2 vector2 = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos);
      this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = vector2;
      this.ScrollComp[panelObjectIdx].ItemCountText.alignment = !this.GM.IsArabic ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft;
      ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = this.ItemNameCrystalColor;
    }
    else if (dataIdx > num1 && dataIdx < (int) this.tmpData.DataLen + (num1 + 1))
    {
      int index = dataIdx - (num1 + 1);
      num2 = this.tmpData.Item[index].ItemID;
      x = this.tmpData.Type != ETreasureType.ETST_Month ? (uint) this.tmpData.Item[index].Num : (uint) this.tmpData.Item[index].Num * 30U;
      num3 = this.tmpData.Item[index].ItemRank;
      ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = false;
      ((Graphic) this.ScrollComp[panelObjectIdx].CrystalImg).rectTransform.anchoredPosition = this.OriginImagePos;
      this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
      this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
      ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = this.ItemCountOriginColor;
      ((Shadow) this.ScrollComp[panelObjectIdx].ItemCountOutline).effectColor = this.ItemCountOutLineOriginColor;
      Vector2 vector2 = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos);
      this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = vector2;
      this.ScrollComp[panelObjectIdx].ItemCountText.alignment = !this.GM.IsArabic ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft;
      ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = this.ItemCountOriginColor;
    }
    else
    {
      if (this.bLastItem && dataIdx == (int) this.ItemCount - 1)
      {
        num2 = (ushort) 1255;
        x = 1U;
      }
      else if (this.bLastItem && dataIdx == (int) this.ItemCount - 2)
      {
        num2 = (ushort) 1309;
        x = 1U;
      }
      else
      {
        int index = dataIdx - (num1 + 1) - (int) this.tmpData.DataLen;
        num2 = this.tmpData.AllianceGift[index].ItemID;
        x = (uint) this.tmpData.AllianceGift[index].Num;
      }
      ((Behaviour) this.ScrollComp[panelObjectIdx].CrystalImg).enabled = false;
      ((Graphic) this.ScrollComp[panelObjectIdx].CrystalImg).rectTransform.anchoredPosition = this.OriginImagePos;
      this.ScrollComp[panelObjectIdx].ItemName.fontSize = 24;
      this.ScrollComp[panelObjectIdx].ItemCountText.fontSize = 34;
      ((Graphic) this.ScrollComp[panelObjectIdx].ItemCountText).color = this.ItemCountOriginColor;
      ((Shadow) this.ScrollComp[panelObjectIdx].ItemCountOutline).effectColor = this.ItemCountOutLineOriginColor;
      Vector2 vector2 = this.ScrollComp[panelObjectIdx].ItemCountText.ArabicFixPos(this.OriginCountPos);
      this.ScrollComp[panelObjectIdx].ItemCountRC.anchoredPosition = vector2;
      this.ScrollComp[panelObjectIdx].ItemCountText.alignment = !this.GM.IsArabic ? TextAnchor.MiddleRight : TextAnchor.MiddleLeft;
      ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = this.ItemCountOriginColor;
    }
    ((Graphic) this.ScrollComp[panelObjectIdx].LineImage).color = new Color(this.tmpData.LineColor.r, this.tmpData.LineColor.g, this.tmpData.LineColor.b);
    if (num1 == 1 && dataIdx == 1)
    {
      this.NameStr[panelObjectIdx].Length = 0;
      StringManager.IntToStr(this.NameStr[panelObjectIdx], (long) x, bNumber: true);
      this.ScrollComp[panelObjectIdx].ItemName.text = this.NameStr[panelObjectIdx].ToString();
      this.ScrollComp[panelObjectIdx].ItemName.SetAllDirty();
      this.ScrollComp[panelObjectIdx].ItemName.cachedTextGenerator.Invalidate();
      this.ScrollComp[panelObjectIdx].ItemName.fontSize = 28;
      this.ScrollComp[panelObjectIdx].ItemCountText.text = this.DM.mStringTable.GetStringByID(876U);
    }
    else
    {
      if (dataIdx > 0)
      {
        Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(num2);
        byte equipKind = recordByKey.EquipKind;
        this.ScrollComp[panelObjectIdx].Hint3.Parm1 = num2;
        this.ScrollComp[panelObjectIdx].Hint3.Parm2 = num3;
        bool flag = this.GM.IsLeadItem(equipKind);
        if (flag)
          GUIManager.Instance.ChangeLordEquipImg(((Component) this.ScrollComp[panelObjectIdx].LEBtn).transform, num2, num3, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        else
          GUIManager.Instance.ChangeHeroItemImg(((Component) this.ScrollComp[panelObjectIdx].HIBtn).transform, eHeroOrItem.Item, num2, (byte) 0, (byte) 0);
        ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(flag);
        ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(!flag);
        if (flag || !this.MM.CheckCanOpenDetail(num2))
          this.ScrollComp[panelObjectIdx].Hint3.enabled = true;
        else
          this.ScrollComp[panelObjectIdx].Hint3.enabled = false;
        ((Component) this.ScrollComp[panelObjectIdx].Btn3).gameObject.SetActive(this.ScrollComp[panelObjectIdx].Hint3.enabled);
        this.NameStr[panelObjectIdx].Length = 0;
        this.NameStr[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipName));
        this.NameStr[panelObjectIdx].AppendFormat("{0}");
        this.ScrollComp[panelObjectIdx].ItemName.text = this.NameStr[panelObjectIdx].ToString();
        ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = this.MM.GetItemRankColor(num3);
        this.ScrollComp[panelObjectIdx].ItemName.SetAllDirty();
        this.ScrollComp[panelObjectIdx].ItemName.cachedTextGenerator.Invalidate();
      }
      this.CountStr[panelObjectIdx].Length = 0;
      StringManager.IntToStr(this.CountStr[panelObjectIdx], (long) x, bNumber: true);
      this.ScrollComp[panelObjectIdx].ItemCountText.text = this.CountStr[panelObjectIdx].ToString();
      this.ScrollComp[panelObjectIdx].ItemCountText.SetAllDirty();
      this.ScrollComp[panelObjectIdx].ItemCountText.cachedTextGenerator.Invalidate();
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    int num = this.tmpData.BonusCrystal <= 0U || this.tmpData.Type == ETreasureType.ETST_Month ? 0 : 1;
    if (dataIndex < num + 1 || dataIndex > (int) this.ItemCount)
      return;
    ushort HIID = this.tmpData.AllianceGiftShowTop != (byte) 1 ? (dataIndex <= num || dataIndex >= (int) this.tmpData.DataLen + (num + 1) ? (!this.bLastItem || dataIndex != (int) this.ItemCount - 1 ? (!this.bLastItem || dataIndex != (int) this.ItemCount - 2 ? this.tmpData.AllianceGift[dataIndex - (num + 1) - (int) this.tmpData.DataLen].ItemID : (ushort) 1309) : (ushort) 1255) : this.tmpData.Item[dataIndex - (num + 1)].ItemID) : (dataIndex <= num || dataIndex >= (int) this.AllianceGiftCount + (num + 1) ? (!this.bLastItem || dataIndex != (int) this.ItemCount - 1 ? (!this.bLastItem || dataIndex != (int) this.ItemCount - 2 ? this.tmpData.Item[dataIndex - (num + 1) - (int) this.AllianceGiftCount].ItemID : (ushort) 1309) : (ushort) 1255) : this.tmpData.AllianceGift[dataIndex - (num + 1)].ItemID);
    if (!this.MM.CheckCanOpenDetail(HIID) || !this.MM.OpenDetail(HIID))
      return;
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      if (sender.m_BtnID2 == 1)
      {
        if (this.MM.CheckbWaitBuy(true))
          return;
        this.MM.Send_Mall_Check(this.tmpData.SN);
      }
      if (sender.m_BtnID2 == 2)
      {
        if (this.GM.BuildingData.GetBuildData((ushort) 15, (ushort) 0).Level < (byte) 1)
        {
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(7533U), (ushort) byte.MaxValue);
          return;
        }
        if (this.DM.mLordEquip == null)
          this.DM.mLordEquip = LordEquipData.Instance();
        if ((bool) (Object) this.door)
        {
          this.door.ClearWindowStack(EGUIWindow.UI_Mall, EGUIWindow.UI_Mall_Detail);
          this.DM.mLordEquip.OpenForgeSet(this.tmpData.SetNo, (byte) 4);
        }
      }
      if (sender.m_BtnID2 != 3 || !(bool) (Object) this.door)
        return;
      this.door.CloseMenu();
    }
    else if (sender.m_BtnID1 != 2)
      ;
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    if (!this.MM.OpenDetail(sender.HIID))
      return;
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
  }

  public void OnButtonDown(UIButtonHint sender)
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

  public void OnButtonUp(UIButtonHint sender)
  {
    if (this.GM.IsLeadItem(DataManager.Instance.EquipTable.GetRecordByKey(sender.Parm1).EquipKind))
      this.GM.m_LordInfo.Hide(sender);
    else
      GUIManager.Instance.m_SimpleItemInfo.Hide(sender);
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    if (!(bool) (Object) this.door)
      return;
    img.sprite = this.door.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = this.door.LoadMaterial();
  }

  public void SetTimeTextAndPic()
  {
    if ((Object) this.m_transform == (Object) null || this.tmpData == null)
      return;
    this.TimeStr.Length = 0;
    if (this.tmpData.Type == ETreasureType.ETST_SHLevelUp)
    {
      this.bLVUPPack = true;
      ((Behaviour) this.m_transform.GetChild(10).GetComponent<UIText>()).enabled = false;
      ((Behaviour) this.m_transform.GetChild(9).GetComponent<Image>()).enabled = false;
      this.m_transform.GetChild(11).gameObject.SetActive(true);
      GameConstants.GetTimeString(this.TimeStr, this.tmpData.uTime, bShowDay: false);
      this.TimeText = this.m_transform.GetChild(11).GetComponent<UIText>();
    }
    else
    {
      this.bLVUPPack = false;
      ((Behaviour) this.m_transform.GetChild(10).GetComponent<UIText>()).enabled = this.tmpData.EndTime != 0L;
      ((Behaviour) this.m_transform.GetChild(9).GetComponent<Image>()).enabled = this.tmpData.EndTime != 0L;
      this.m_transform.GetChild(11).gameObject.SetActive(false);
      GameConstants.GetTimeString(this.TimeStr, (uint) (this.tmpData.EndTime - this.DM.ServerTime));
      this.TimeText = this.m_transform.GetChild(10).GetComponent<UIText>();
    }
    this.TimeText.font = this.tmpFont;
    this.TimeText.text = this.TimeStr.ToString();
    this.TimeText.SetAllDirty();
    this.TimeText.cachedTextGenerator.Invalidate();
  }

  public void SetBackName()
  {
    if (this.tmpData.bDownLoadPic)
    {
      if (this.tmpData.bUpDatePic)
      {
        this.tmpData.UnloadAB();
        this.tmpData.bUpDatePic = false;
      }
      if (this.tmpData.m_AssetBundleKey == 0)
        this.tmpData.InitialAB();
      this.Back.sprite = this.tmpData.m_BackImage2;
      ((MaskableGraphic) this.Back).material = this.tmpData.m_Material;
      ((Component) this.Back).gameObject.SetActive(true);
    }
    if (this.tmpData.bDownLoadStr)
    {
      if (this.tmpData.bUpDateStr)
      {
        this.tmpData.UnloadStrAB();
        this.tmpData.bUpDateStr = false;
      }
      if (this.tmpData.m_StrAssetBundleKey == 0)
        this.tmpData.InitialABString();
      if (!((Object) this.tmpData.DownLoadStr != (Object) null))
        return;
      byte index = (byte) (this.DM.UserLanguage - (byte) 1);
      if ((int) index >= this.tmpData.DownLoadStr.Header.Length || this.tmpData.DownLoadStr.Header[(int) index] == string.Empty)
        index = (byte) 0;
      this.PackageName.text = this.tmpData.DownLoadStr.Header[(int) index];
    }
    else
      this.PackageName.text = string.Empty;
  }

  private void SavePos()
  {
    this.UIIndex = this.Scroll.GetTopIdx();
    this.UIPos = this.cScrollRect.content.anchoredPosition.y;
  }

  private bool CheckShowLastItem()
  {
    if (this.tmpData != null && !this.DM.CheckPrizeFlag((byte) 9))
    {
      uint treasureId = this.tmpData.TreasureID;
      switch (treasureId)
      {
        case 11650:
        case 11651:
        case 11652:
        case 11653:
        case 11654:
        case 11655:
        case 11656:
        case 11657:
        case 11658:
        case 11659:
        case 11663:
label_4:
          return true;
        default:
          switch (treasureId)
          {
            case 14057:
            case 14058:
            case 14059:
            case 14060:
            case 14061:
            case 14149:
            case 14150:
            case 14151:
            case 14247:
            case 14248:
            case 14249:
              goto label_4;
            default:
              if (treasureId == 11608U || treasureId == 11609U || treasureId == 11575U || treasureId == 11595U || treasureId == 11599U)
                goto label_4;
              else
                break;
          }
          break;
      }
    }
    return false;
  }
}
