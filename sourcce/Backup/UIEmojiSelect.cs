// Decompiled with JetBrains decompiler
// Type: UIEmojiSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIEmojiSelect : GUIWindow, UILoadImageHander, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int UnitCount = 8;
  private Transform m_transform;
  private Transform UnitObjectT;
  private GUIManager GM = GUIManager.Instance;
  private DataManager DM = DataManager.Instance;
  private StringManager SM = StringManager.Instance;
  private UIText[] RBText = new UIText[14];
  private byte RBTextIndex;
  private CString m_OKString;
  private CString m_OKString_ItemCount;
  private CString PriceStr;
  private ushort ItemID = 1316;
  private uint price;
  private RectTransform SelectRT;
  private RectTransform[] PicRT = new RectTransform[8];
  private byte ECount;
  private EmojiUnit[] EUnit = new EmojiUnit[8];
  private bool[] bFindScrollComp = new bool[8];
  private EmojiUnitComp[] Scroll_Comp = new EmojiUnitComp[8];
  private List<float> NowHeightList = new List<float>();
  private ScrollPanel_Horizontal Scroll;
  private CScrollRect cScrollRect;
  private byte OpenType;
  private GameObject GiftItem;
  private GameObject BuyBtn;
  private GameObject UseBtn;
  private GameObject SpendBtn;
  private GameObject ItemInfoObj;
  private GameObject MoveBtnGO;
  private Image[] PointImg = new Image[3];
  private UIHIBtn GiftBtn;
  private Text PriceText;
  private Text ItemCountText;
  private Text NoKeyText;
  private bool bThirdParty;
  private float CheckMoveTime;
  private int EmojiCount;
  private int FindMoveIndex = -1;
  private bool NeedUpDate;
  private bool bNeedCheckMove;

  public override void OnOpen(int arg1, int arg2)
  {
    this.m_transform = this.transform;
    Font ttfFont = this.GM.GetTTFFont();
    this.m_transform.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(0).GetChild(1).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(0).GetChild(2).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(0).GetChild(4).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(0).GetChild(4).GetComponent<UIButton>().m_BtnID1 = 7;
    this.m_transform.GetChild(0).GetChild(8).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(0).GetChild(8).GetComponent<UIButton>().m_BtnID1 = 8;
    Transform child1 = this.m_transform.GetChild(0).GetChild(0);
    for (int index = 0; index < 8; ++index)
    {
      child1.GetChild(index).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
      child1.GetChild(index).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      this.PicRT[index] = child1.GetChild(index).GetComponent<RectTransform>();
      if (this.GM.IsArabic)
        ((Transform) this.PicRT[index]).localScale = new Vector3(-1f, 1f, 1f);
    }
    this.SelectRT = child1.GetChild(8).GetComponent<RectTransform>();
    child1.GetChild(8).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    Transform child2 = this.m_transform.GetChild(0);
    child2.GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    child2.GetChild(1).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    child2.GetChild(1).GetChild(2).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    child2.GetChild(2).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    child2.GetChild(3).GetChild(1).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    child2.GetChild(4).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    child2.GetChild(4).GetChild(2).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    child2.GetChild(5).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    child2.GetChild(6).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    Transform child3 = this.m_transform.GetChild(1);
    child3.GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    child3.GetChild(2).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.PointImg[0] = child3.GetChild(3).GetComponent<Image>();
    this.PointImg[1] = child3.GetChild(4).GetComponent<Image>();
    this.PointImg[2] = child3.GetChild(5).GetComponent<Image>();
    this.MoveBtnGO = this.m_transform.GetChild(0).GetChild(8).gameObject;
    this.MoveBtnGO.transform.GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.MoveBtnGO.transform.GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.MoveBtnGO.transform.GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.MoveBtnGO.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (this.GM.bOpenOnIPhoneX)
    {
      ((RectTransform) this.m_transform).offsetMin = new Vector2(-this.GM.IPhoneX_DeltaX, 0.0f);
      ((RectTransform) this.m_transform).offsetMax = new Vector2(this.GM.IPhoneX_DeltaX, 0.0f);
    }
    this.OpenType = (byte) arg1;
    this.GM.EmojiOpenType = this.OpenType;
    Transform child4 = this.m_transform.GetChild(0);
    if (this.OpenType == (byte) 2)
    {
      RectTransform component = child4.GetChild(2).GetComponent<RectTransform>();
      component.anchoredPosition = new Vector2(0.0f, component.anchoredPosition.y);
      component.sizeDelta = new Vector2(146f, 77f);
    }
    Transform child5 = this.m_transform.GetChild(0).GetChild(4);
    this.BuyBtn = child5.gameObject;
    if (this.bThirdParty)
    {
      child5.GetChild(0).gameObject.SetActive(false);
      child5.GetChild(2).gameObject.SetActive(true);
      child5.GetChild(3).gameObject.SetActive(true);
      this.PriceText = child5.GetChild(3).GetComponent<Text>();
      this.PriceText.font = ttfFont;
    }
    else
    {
      this.PriceText = child5.GetChild(0).GetComponent<Text>();
      this.PriceText.font = ttfFont;
    }
    if (this.GM.IsArabic)
      ((Transform) ((Graphic) this.PriceText).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    UIText component1 = child5.GetChild(1).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = this.DM.mStringTable.GetStringByID(284U);
    if (this.GM.IsArabic)
      ((Transform) ((Graphic) component1).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    this.RBText[(int) this.RBTextIndex] = component1;
    ++this.RBTextIndex;
    this.GiftItem = this.m_transform.GetChild(1).gameObject;
    this.GiftBtn = this.m_transform.GetChild(1).GetChild(1).GetComponent<UIHIBtn>();
    ((Component) this.GiftBtn).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UIHIBtn;
    this.GM.InitianHeroItemImg(((Component) this.GiftBtn).transform, eHeroOrItem.Item, this.ItemID, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    UIText component2 = this.m_transform.GetChild(1).GetChild(0).GetComponent<UIText>();
    component2.font = ttfFont;
    component2.text = this.DM.mStringTable.GetStringByID(12069U);
    this.RBText[(int) this.RBTextIndex] = component2;
    ++this.RBTextIndex;
    this.UseBtn = this.m_transform.GetChild(0).GetChild(2).gameObject;
    UIText component3 = this.m_transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
    component3.font = ttfFont;
    component3.text = this.DM.mStringTable.GetStringByID(94U);
    this.RBText[(int) this.RBTextIndex] = component3;
    ++this.RBTextIndex;
    this.SpendBtn = this.m_transform.GetChild(0).GetChild(1).gameObject;
    Transform child6 = this.m_transform.GetChild(0).GetChild(1);
    UIText component4 = child6.GetChild(0).GetComponent<UIText>();
    component4.font = ttfFont;
    component4.text = this.DM.mStringTable.GetStringByID(4062U);
    this.RBText[(int) this.RBTextIndex] = component4;
    ++this.RBTextIndex;
    this.price = this.DM.StoreData.GetRecordByKey(this.DM.TotalShopItemData.Find(this.ItemID)).Price;
    this.m_OKString = this.SM.SpawnString();
    this.m_OKString.IntToFormat((long) this.price, bNumber: true);
    this.m_OKString.AppendFormat("{0}");
    UIText component5 = child6.GetChild(1).GetComponent<UIText>();
    component5.font = ttfFont;
    component5.text = this.m_OKString.ToString();
    this.RBText[(int) this.RBTextIndex] = component5;
    ++this.RBTextIndex;
    this.ItemInfoObj = this.m_transform.GetChild(0).GetChild(3).gameObject;
    Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.ItemID);
    Transform child7 = this.m_transform.GetChild(0).GetChild(3);
    UIText component6 = child7.GetChild(0).GetComponent<UIText>();
    component6.font = ttfFont;
    component6.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipName);
    this.RBText[(int) this.RBTextIndex] = component6;
    ++this.RBTextIndex;
    this.ItemCountText = (Text) child7.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.ItemCountText.font = ttfFont;
    child7.GetChild(2).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UIHIBtn;
    this.GM.InitianHeroItemImg(child7.GetChild(2), eHeroOrItem.Item, this.ItemID, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    Transform child8 = this.m_transform.GetChild(0);
    this.GM.SortEmojiData();
    this.Scroll = child8.GetChild(6).GetComponent<ScrollPanel_Horizontal>();
    this.UnitObjectT = child8.GetChild(7);
    for (int index = 0; index < 8; ++index)
      this.bFindScrollComp[index] = false;
    this.EmojiCount = this.GM.EmojiIndex.Count + 1;
    this.NowHeightList.Clear();
    for (int index = 0; index < this.EmojiCount; ++index)
    {
      if (index == 0)
        this.NowHeightList.Add(88f);
      else
        this.NowHeightList.Add(82f);
    }
    this.Scroll.IntiScrollPanel(462f, 1f, 0.0f, this.NowHeightList, 8, (IUpDateScrollPanel) this);
    this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
    UIButtonHint.scrollRect = this.cScrollRect;
    if (this.GM.EmojiIndex.Count > 4)
      this.bNeedCheckMove = true;
    this.NoKeyText = (Text) this.m_transform.GetChild(2).GetComponent<UIText>();
    this.NoKeyText.font = ttfFont;
    this.NoKeyText.text = this.DM.mStringTable.GetStringByID(12071U);
    this.m_transform.GetChild(2).gameObject.SetActive(true);
    ((Behaviour) this.NoKeyText).enabled = false;
    this.SetIndex(this.GM.EmojiNowPackageIndex, true);
    if (this.GM.EmojiNowScrollIndex == -1)
      return;
    this.Scroll.GoTo(this.GM.EmojiNowScrollIndex, this.GM.EmojiNowContentPos);
  }

  public override void OnClose()
  {
    this.SM.DeSpawnString(this.m_OKString);
    this.SM.DeSpawnString(this.m_OKString_ItemCount);
    this.SM.DeSpawnString(this.PriceStr);
    for (int index = 0; index < (int) this.ECount && index < this.EUnit.Length; ++index)
    {
      if (this.EUnit[index] != null)
      {
        this.GM.pushEmojiIcon(this.EUnit[index]);
        this.EUnit[index] = (EmojiUnit) null;
      }
    }
    for (int index = 0; index < 8; ++index)
    {
      if (this.Scroll_Comp[index].EUnit != null)
      {
        ((Graphic) this.Scroll_Comp[index].EUnit.EmojiImage).color = Color.white;
        this.GM.pushEmojiIcon(this.Scroll_Comp[index].EUnit);
        this.Scroll_Comp[index].EUnit = (EmojiUnit) null;
      }
    }
    this.GM.CloseCheckCrystalBox();
    this.GM.EmojiNowScrollIndex = this.Scroll.GetTopIdx();
    this.GM.EmojiNowContentPos = this.cScrollRect.content.anchoredPosition.x;
    if (this.GM.EmojiNowScrollIndex != -1 || this.EmojiCount <= 0)
      return;
    this.GM.EmojiNowScrollIndex = 0;
    this.GM.EmojiNowContentPos = 0.0f;
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
      this.GM.CloseMenu(EGUIWindow.UIEmojiSelect);
    else if (sender.m_BtnID1 == 2)
      this.SendPackage();
    else if (sender.m_BtnID1 == 3)
    {
      if (this.DM.RoleAttr.Diamond >= this.price)
      {
        if (GUIManager.Instance.OpenCheckCrystal(this.price, (byte) 9))
          return;
        this.SendPackage();
      }
      else
        this.GM.OpenMessageBox(this.DM.mStringTable.GetStringByID(3966U), this.DM.mStringTable.GetStringByID(646U), this.DM.mStringTable.GetStringByID(3968U), (GUIWindow) this, 1, bCloseIDSet: true);
    }
    else if (sender.m_BtnID1 == 4)
    {
      this.GM.EmojiNowPicIndex = (ushort) (sender.m_BtnID2 - 1);
      this.SetSelect();
    }
    else if (sender.m_BtnID1 == 5)
      this.SetIndex(ushort.MaxValue);
    else if (sender.m_BtnID1 == 6)
      this.SetIndex((ushort) sender.m_BtnID2);
    else if (sender.m_BtnID1 == 7)
    {
      if (MallManager.Instance.CheckbWaitBuy_Emoji(true))
        return;
      Emote recordByKey = DataManager.MapDataController.EmoteTable.GetRecordByKey((ushort) ((uint) this.GM.EmojiNowPackageIndex + 1U));
      MallManager.Instance.SendCheckEmojiID = (ushort) ((uint) this.GM.EmojiNowPackageIndex + 1U);
      MallManager.Instance.Send_SPTREASURE_PREBUY_CHECK(ESpcialTreasureType.ESTST_Emote, recordByKey.ProductID);
    }
    else
    {
      if (sender.m_BtnID1 != 8 || this.FindMoveIndex == -1)
        return;
      this.Scroll.GoTo(this.FindMoveIndex);
      this.CheckShowMoveBtn();
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || arg1 != 1)
      return;
    MallManager.Instance.Send_Mall_Info();
    this.GM.CloseMenu(EGUIWindow.UIEmojiSelect);
  }

  public void SetIndex(ushort SelectIndex, bool OpenForce = false)
  {
    bool flag = (int) this.GM.EmojiNowPackageIndex == (int) SelectIndex;
    this.GM.EmojiNowPackageIndex = SelectIndex;
    if (!flag || OpenForce)
    {
      for (int index = 0; index < (int) this.ECount && index < this.EUnit.Length; ++index)
      {
        if (this.EUnit[index] != null)
        {
          this.GM.pushEmojiIcon(this.EUnit[index]);
          this.EUnit[index] = (EmojiUnit) null;
        }
      }
      this.ECount = this.GM.GetMapEmojiCount(SelectIndex);
      for (int PicIndex = 0; PicIndex < (int) this.ECount && PicIndex < this.PicRT.Length; ++PicIndex)
      {
        EmojiData recordByKey = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(this.GetEmojiKey(SelectIndex, PicIndex));
        this.EUnit[PicIndex] = this.GM.pullEmojiIcon(recordByKey.IconID, recordByKey.KeyFrame);
        this.EUnit[PicIndex].EmojiTransform.SetParent((Transform) this.PicRT[PicIndex], false);
        ((RectTransform) this.EUnit[PicIndex].EmojiTransform).anchoredPosition = Vector2.zero;
      }
      if (!OpenForce)
        this.GM.EmojiNowPicIndex = (ushort) 0;
      this.SetSelect();
      this.DM.SetEmojiSave((ushort) ((uint) SelectIndex + 1U));
      for (int index = 0; index < 8; ++index)
      {
        if (this.bFindScrollComp[index])
        {
          ((Behaviour) this.Scroll_Comp[index].SelectImage1).enabled = false;
          ((Behaviour) this.Scroll_Comp[index].SelectImage2).enabled = false;
          if (this.Scroll_Comp[index].Btn2.m_BtnID2 == (int) SelectIndex)
          {
            if (SelectIndex == ushort.MaxValue)
            {
              ((Behaviour) this.Scroll_Comp[index].SelectImage1).enabled = true;
            }
            else
            {
              ((Behaviour) this.Scroll_Comp[index].SelectImage2).enabled = true;
              this.Scroll_Comp[index].FlasfGO.SetActive(false);
            }
          }
        }
      }
    }
    this.SpendBtn.SetActive(false);
    this.ItemInfoObj.SetActive(false);
    this.UseBtn.SetActive(false);
    this.BuyBtn.SetActive(false);
    this.GiftItem.SetActive(false);
    if (SelectIndex == ushort.MaxValue || this.GM.HasEmotionPck((ushort) ((uint) SelectIndex + 1U)))
    {
      if (this.OpenType == (byte) 1)
      {
        ushort curItemQuantity = this.DM.GetCurItemQuantity(this.ItemID, (byte) 0);
        this.ItemInfoObj.SetActive(true);
        this.SetItemCount(curItemQuantity);
        if (curItemQuantity > (ushort) 0)
          this.UseBtn.SetActive(true);
        else
          this.SpendBtn.SetActive(true);
      }
      else if (this.OpenType == (byte) 2)
        this.UseBtn.SetActive(true);
      if (this.GM.EmojiNowPackageIndex != ushort.MaxValue || this.GM.SaveEmojiKey.Count != 0)
        return;
      this.UseBtn.SetActive(false);
      this.SpendBtn.SetActive(false);
      this.ItemInfoObj.SetActive(false);
    }
    else
    {
      this.BuyBtn.SetActive(true);
      this.GiftItem.SetActive(true);
      Emote recordByKey = DataManager.MapDataController.EmoteTable.GetRecordByKey((ushort) ((uint) SelectIndex + 1U));
      this.SetPrice(recordByKey.ProductID);
      this.GM.ChangeHeroItemImg(((Component) this.GiftBtn).transform, eHeroOrItem.Item, recordByKey.GiftID, (byte) 0, (byte) 0);
      ((Behaviour) this.PointImg[0]).enabled = false;
      ((Behaviour) this.PointImg[1]).enabled = false;
      ((Behaviour) this.PointImg[2]).enabled = false;
      if (this.GM.IsArabic)
      {
        if (recordByKey.GiftCount >= (byte) 100)
        {
          this.GM.SetPointTexture((byte) ((uint) recordByKey.GiftCount / 100U), this.PointImg[2]);
          ((Behaviour) this.PointImg[2]).enabled = true;
          this.GM.SetPointTexture((byte) ((int) recordByKey.GiftCount % 100 / 10), this.PointImg[1]);
          ((Behaviour) this.PointImg[1]).enabled = true;
          this.GM.SetPointTexture((byte) ((uint) recordByKey.GiftCount % 10U), this.PointImg[0]);
          ((Behaviour) this.PointImg[0]).enabled = true;
        }
        else if (recordByKey.GiftCount >= (byte) 10 && recordByKey.GiftCount <= (byte) 99)
        {
          this.GM.SetPointTexture((byte) ((uint) recordByKey.GiftCount / 10U), this.PointImg[1]);
          ((Behaviour) this.PointImg[1]).enabled = true;
          this.GM.SetPointTexture((byte) ((uint) recordByKey.GiftCount % 10U), this.PointImg[0]);
          ((Behaviour) this.PointImg[0]).enabled = true;
        }
        else
        {
          this.GM.SetPointTexture(recordByKey.GiftCount, this.PointImg[0]);
          ((Behaviour) this.PointImg[0]).enabled = true;
        }
      }
      else if (recordByKey.GiftCount >= (byte) 100)
      {
        this.GM.SetPointTexture((byte) ((uint) recordByKey.GiftCount / 100U), this.PointImg[0]);
        ((Behaviour) this.PointImg[0]).enabled = true;
        this.GM.SetPointTexture((byte) ((int) recordByKey.GiftCount % 100 / 10), this.PointImg[1]);
        ((Behaviour) this.PointImg[1]).enabled = true;
        this.GM.SetPointTexture((byte) ((uint) recordByKey.GiftCount % 10U), this.PointImg[2]);
        ((Behaviour) this.PointImg[2]).enabled = true;
      }
      else if (recordByKey.GiftCount >= (byte) 10 && recordByKey.GiftCount <= (byte) 99)
      {
        this.GM.SetPointTexture((byte) ((uint) recordByKey.GiftCount / 10U), this.PointImg[0]);
        ((Behaviour) this.PointImg[0]).enabled = true;
        this.GM.SetPointTexture((byte) ((uint) recordByKey.GiftCount % 10U), this.PointImg[1]);
        ((Behaviour) this.PointImg[1]).enabled = true;
      }
      else
      {
        this.GM.SetPointTexture(recordByKey.GiftCount, this.PointImg[0]);
        ((Behaviour) this.PointImg[0]).enabled = true;
      }
    }
  }

  public void SetSelect()
  {
    if (!(bool) (UnityEngine.Object) this.SelectRT || (int) this.GM.EmojiNowPicIndex >= this.PicRT.Length)
      return;
    if (this.GM.EmojiNowPackageIndex == ushort.MaxValue)
    {
      if (this.GM.SaveEmojiKey.Count == 0)
      {
        ((Component) this.SelectRT).gameObject.SetActive(false);
        ((Behaviour) this.NoKeyText).enabled = true;
        return;
      }
      if ((int) this.GM.EmojiNowPicIndex >= this.GM.SaveEmojiKey.Count)
        this.GM.EmojiNowPicIndex = (ushort) 0;
    }
    ((Component) this.SelectRT).gameObject.SetActive(true);
    ((Behaviour) this.NoKeyText).enabled = false;
    DataManager.MapDataController.EmojiDataTable.GetRecordByKey(this.GetEmojiKey(this.GM.EmojiNowPackageIndex, (int) this.GM.EmojiNowPicIndex));
    this.SelectRT.anchoredPosition = this.PicRT[(int) this.GM.EmojiNowPicIndex].anchoredPosition;
    this.SelectRT.sizeDelta = new Vector2(125f, 125f);
  }

  public void SetItemCount(ushort Count)
  {
    if ((UnityEngine.Object) this.ItemCountText == (UnityEngine.Object) null)
      return;
    if (this.m_OKString_ItemCount == null)
      this.m_OKString_ItemCount = this.SM.SpawnString();
    this.m_OKString_ItemCount.Length = 0;
    this.m_OKString_ItemCount.StringToFormat(this.DM.mStringTable.GetStringByID(281U));
    this.m_OKString_ItemCount.IntToFormat((long) Count, bNumber: true);
    this.m_OKString_ItemCount.AppendFormat("{0}{1}");
    this.ItemCountText.text = this.m_OKString_ItemCount.ToString();
    ((Graphic) this.ItemCountText).SetAllDirty();
    this.ItemCountText.cachedTextGenerator.Invalidate();
  }

  public void SetPrice(uint TreasureID)
  {
    if ((UnityEngine.Object) this.PriceText == (UnityEngine.Object) null)
      return;
    if (this.PriceStr == null)
      this.PriceStr = this.SM.SpawnString();
    TreasureID = MallManager.Instance.TreasureIDTransToNew(TreasureID);
    this.PriceStr.Length = 0;
    string paltformPriceById = MallManager.Instance.GetProductPaltformPriceByID((int) TreasureID);
    string productPriceById = MallManager.Instance.GetProductPriceByID((int) TreasureID);
    if (paltformPriceById != null && paltformPriceById != string.Empty)
    {
      this.PriceStr.Append(paltformPriceById);
    }
    else
    {
      if (productPriceById == null)
      {
        double f = 0.0;
        this.NeedUpDate = true;
        this.PriceStr.DoubleToFormat(f, 2);
      }
      else
        this.PriceStr.StringToFormat(productPriceById);
      string currency = MallManager.Instance.GetCurrency((int) TreasureID);
      if (currency != null)
      {
        this.PriceStr.StringToFormat(currency);
        if (MallManager.Instance.bChangePosCurrency(currency))
          this.PriceStr.AppendFormat("{0} {1}");
        else
          this.PriceStr.AppendFormat("{1} {0}");
      }
      else
        this.PriceStr.AppendFormat("${0}");
    }
    this.PriceText.text = this.PriceStr.ToString();
    ((Graphic) this.PriceText).SetAllDirty();
    this.PriceText.cachedTextGenerator.Invalidate();
  }

  public void CheckShowMoveBtn()
  {
    if (!this.DM.CheckShowOnGroundInfo())
    {
      this.FindMoveIndex = -1;
      this.bNeedCheckMove = false;
      this.MoveBtnGO.SetActive(false);
    }
    else
    {
      int beginIdx = this.Scroll.GetBeginIdx();
      for (int itemidx = beginIdx + 4; itemidx < this.EmojiCount; ++itemidx)
      {
        ushort num = this.GM.EmojiIndex[itemidx - 1];
        if (!this.DM.CheckEmojiSave(num) && !this.GM.HasEmotionPck(num) && !this.Scroll.CheckInPanel(itemidx, true))
        {
          this.FindMoveIndex = itemidx;
          this.MoveBtnGO.SetActive(true);
          return;
        }
      }
      this.FindMoveIndex = -1;
      this.MoveBtnGO.SetActive(false);
    }
  }

  public ushort GetEmojiKey(ushort PackageIndex, int PicIndex)
  {
    if (PackageIndex != ushort.MaxValue)
      return (ushort) (((int) PackageIndex << 7) + PicIndex + 1);
    return PicIndex < this.GM.SaveEmojiKey.Count ? this.GM.SaveEmojiKey[PicIndex] : (ushort) 0;
  }

  public void SendPackage()
  {
    if (this.OpenType == (byte) 1)
    {
      Door menu = this.GM.FindMenu(EGUIWindow.Door) as Door;
      if (!(bool) (UnityEngine.Object) menu || menu.m_GroundInfo == null)
        return;
      MessagePacket messagePacket = new MessagePacket((ushort) 1024);
      messagePacket.Protocol = Protocol._MSG_REQUEST_MAP_EMOTION;
      messagePacket.AddSeqId();
      messagePacket.Add(DataManager.MapDataController.FocusKingdomID);
      if (menu.m_GroundInfo.m_TeamPanelGameObject.activeSelf)
      {
        messagePacket.Add((byte) 13);
        if (menu.m_GroundInfo.m_MapPointID >= 0 && menu.m_GroundInfo.m_MapPointID < DataManager.MapDataController.MapLineTable.Count)
        {
          MapLine mapLine = DataManager.MapDataController.MapLineTable[menu.m_GroundInfo.m_MapPointID];
          messagePacket.Add(mapLine.lineID);
        }
      }
      else
      {
        if (menu.m_GroundInfo.m_MapPointID >= 0 && menu.m_GroundInfo.m_MapPointID < DataManager.MapDataController.LayoutMapInfo.Length)
        {
          MapPoint mapPoint = DataManager.MapDataController.LayoutMapInfo[(IntPtr) (uint) menu.m_GroundInfo.m_MapPointID];
          messagePacket.Add(mapPoint.pointKind);
        }
        ushort zoneID;
        byte pointID;
        GameConstants.MapIDToPointCode(menu.m_GroundInfo.m_MapPointID, out zoneID, out pointID);
        messagePacket.Add((byte) 0);
        messagePacket.Add(zoneID);
        messagePacket.Add(pointID);
      }
      messagePacket.Add(this.GetEmojiKey(this.GM.EmojiNowPackageIndex, (int) this.GM.EmojiNowPicIndex));
      messagePacket.Add(this.DM.TotalShopItemData.Find(this.ItemID));
      messagePacket.Send();
      this.SendChangeSave(this.GM.EmojiNowPackageIndex);
      if (this.DM.GetCurItemQuantity(this.ItemID, (byte) 0) <= (ushort) 0)
        this.DM.SetBuyAndUse((byte) 1);
      if (!menu.m_GroundInfo.m_TeamPanelGameObject.activeSelf)
        menu.m_GroundInfo.Close();
      this.GM.CloseMenu(EGUIWindow.UIEmojiSelect);
    }
    else
    {
      if (this.OpenType != (byte) 2)
        return;
      this.GM.UpdateUI(EGUIWindow.UI_Chat, 15, (int) this.GetEmojiKey(this.GM.EmojiNowPackageIndex, (int) this.GM.EmojiNowPicIndex));
      this.SendChangeSave(this.GM.EmojiNowPackageIndex);
      this.GM.CloseMenu(EGUIWindow.UIEmojiSelect);
    }
  }

  private void SendChangeSave(ushort Index)
  {
    if (Index == ushort.MaxValue)
      return;
    ushort emojiKey = this.GetEmojiKey(this.GM.EmojiNowPackageIndex, (int) this.GM.EmojiNowPicIndex);
    for (int index = 0; index < this.GM.SaveEmojiKey.Count; ++index)
    {
      if ((int) this.GM.SaveEmojiKey[index] == (int) emojiKey)
      {
        this.GM.SaveEmojiKey.RemoveAt(index);
        this.GM.SaveEmojiKey.Insert(0, emojiKey);
        return;
      }
    }
    if (this.GM.SaveEmojiKey.Count >= 8)
      this.GM.SaveEmojiKey.RemoveAt(this.GM.SaveEmojiKey.Count - 1);
    this.GM.SaveEmojiKey.Insert(0, emojiKey);
    this.GM.SaveEmojiSelectSave();
  }

  private void Update()
  {
    if (this.NeedUpDate && IGGGameSDK.Instance.bPaymentReady)
    {
      this.NeedUpDate = false;
      this.SetIndex(this.GM.EmojiNowPackageIndex);
    }
    if (!this.bNeedCheckMove)
      return;
    this.CheckMoveTime -= Time.deltaTime;
    if ((double) this.CheckMoveTime > 0.0)
      return;
    this.CheckMoveTime = 0.5f;
    this.CheckShowMoveBtn();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 2:
        this.SendPackage();
        break;
      case 3:
        this.GM.CloseMenu(EGUIWindow.UIEmojiSelect);
        break;
      case 4:
        int num = DataManager.MapDataController.EmoteTable.TableCount - 1;
        for (int index = 0; index < this.GM.EmojiIndex.Count; ++index)
        {
          ushort SelectIndex = (ushort) ((uint) this.GM.EmojiIndex[index] - 1U);
          if ((int) SelectIndex == num)
          {
            this.SetIndex(SelectIndex);
            this.Scroll.GoTo(index + 1);
          }
        }
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_Item:
        this.SetIndex(this.GM.EmojiNowPackageIndex);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        for (int index = 0; index < this.RBText.Length; ++index)
        {
          if ((UnityEngine.Object) this.RBText[index] != (UnityEngine.Object) null && ((Behaviour) this.RBText[index]).enabled)
          {
            ((Behaviour) this.RBText[index]).enabled = false;
            ((Behaviour) this.RBText[index]).enabled = true;
          }
        }
        if ((UnityEngine.Object) this.PriceText != (UnityEngine.Object) null && ((Behaviour) this.PriceText).enabled)
        {
          ((Behaviour) this.PriceText).enabled = false;
          ((Behaviour) this.PriceText).enabled = true;
        }
        if ((UnityEngine.Object) this.ItemCountText != (UnityEngine.Object) null && ((Behaviour) this.ItemCountText).enabled)
        {
          ((Behaviour) this.ItemCountText).enabled = false;
          ((Behaviour) this.ItemCountText).enabled = true;
        }
        if (!((UnityEngine.Object) this.NoKeyText != (UnityEngine.Object) null) || !((Behaviour) this.NoKeyText).enabled)
          break;
        ((Behaviour) this.NoKeyText).enabled = false;
        ((Behaviour) this.NoKeyText).enabled = true;
        break;
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelId != 0 || panelObjectIdx >= 8)
      return;
    if (!this.bFindScrollComp[panelObjectIdx])
    {
      this.bFindScrollComp[panelObjectIdx] = true;
      Transform transform = item.transform;
      if (this.GM.IsArabic)
        transform.GetChild(1).GetChild(1).localScale = new Vector3(-1f, 1f, 1f);
      transform.GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      transform.GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      transform.GetChild(0).GetChild(1).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      transform.GetChild(1).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      transform.GetChild(1).GetChild(1).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      transform.GetChild(1).GetChild(2).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      transform.GetChild(1).GetChild(3).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      transform.GetChild(1).GetChild(3).GetChild(0).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
      this.Scroll_Comp[panelObjectIdx].ItemGO1 = transform.GetChild(0).gameObject;
      this.Scroll_Comp[panelObjectIdx].ItemGO2 = transform.GetChild(1).gameObject;
      this.Scroll_Comp[panelObjectIdx].FlasfGO = transform.GetChild(1).GetChild(3).gameObject;
      this.Scroll_Comp[panelObjectIdx].Btn1 = transform.GetChild(0).GetChild(1).GetComponent<UIButton>();
      this.Scroll_Comp[panelObjectIdx].Btn1.m_Handler = (IUIButtonClickHandler) this;
      this.Scroll_Comp[panelObjectIdx].Btn2 = transform.GetChild(1).GetChild(1).GetComponent<UIButton>();
      this.Scroll_Comp[panelObjectIdx].Btn2.m_Handler = (IUIButtonClickHandler) this;
      this.Scroll_Comp[panelObjectIdx].SelectImage1 = transform.GetChild(0).GetChild(0).GetComponent<Image>();
      this.Scroll_Comp[panelObjectIdx].SelectImage2 = transform.GetChild(1).GetChild(0).GetComponent<Image>();
      ((Component) this.Scroll_Comp[panelObjectIdx].SelectImage1).gameObject.SetActive(true);
      ((Component) this.Scroll_Comp[panelObjectIdx].SelectImage2).gameObject.SetActive(true);
      ((Behaviour) this.Scroll_Comp[panelObjectIdx].SelectImage1).enabled = false;
      ((Behaviour) this.Scroll_Comp[panelObjectIdx].SelectImage2).enabled = false;
      this.Scroll_Comp[panelObjectIdx].ObjectT = transform.GetChild(1).GetChild(1);
      this.Scroll_Comp[panelObjectIdx].EUnit = (EmojiUnit) null;
    }
    if (dataIdx == 0)
    {
      this.Scroll_Comp[panelObjectIdx].ItemGO1.SetActive(true);
      this.Scroll_Comp[panelObjectIdx].ItemGO2.SetActive(false);
      if (this.GM.EmojiNowPackageIndex == ushort.MaxValue)
        ((Behaviour) this.Scroll_Comp[panelObjectIdx].SelectImage1).enabled = true;
      else
        ((Behaviour) this.Scroll_Comp[panelObjectIdx].SelectImage1).enabled = false;
      ((Behaviour) this.Scroll_Comp[panelObjectIdx].SelectImage2).enabled = false;
      this.Scroll_Comp[panelObjectIdx].Btn2.m_BtnID2 = (int) ushort.MaxValue;
    }
    else
    {
      --dataIdx;
      if (dataIdx < 0 || dataIdx >= this.GM.EmojiIndex.Count)
        return;
      this.Scroll_Comp[panelObjectIdx].ItemGO1.SetActive(false);
      this.Scroll_Comp[panelObjectIdx].ItemGO2.SetActive(true);
      ushort num1 = this.GM.EmojiIndex[dataIdx];
      this.Scroll_Comp[panelObjectIdx].Btn2.m_BtnID2 = (int) num1 - 1;
      if (this.Scroll_Comp[panelObjectIdx].EUnit != null)
      {
        ((Graphic) this.Scroll_Comp[panelObjectIdx].EUnit.EmojiImage).color = Color.white;
        this.GM.pushEmojiIcon(this.Scroll_Comp[panelObjectIdx].EUnit);
        this.Scroll_Comp[panelObjectIdx].EUnit = (EmojiUnit) null;
      }
      Emote recordByKey1 = DataManager.MapDataController.EmoteTable.GetRecordByKey(num1);
      EmojiData recordByKey2 = DataManager.MapDataController.EmojiDataTable.GetRecordByKey(this.GetEmojiKey((ushort) ((uint) num1 - 1U), (int) recordByKey1.SelectionPicNo - 1));
      this.Scroll_Comp[panelObjectIdx].EUnit = this.GM.pullEmojiIcon(recordByKey2.IconID, recordByKey2.KeyFrame);
      this.Scroll_Comp[panelObjectIdx].EUnit.DefaultSprite();
      float num2 = (float) recordByKey1.TabScale / 100f;
      if ((double) num2 > 0.1)
        this.Scroll_Comp[panelObjectIdx].EUnit.EmojiTransform.localScale = new Vector3(num2, num2, num2);
      this.Scroll_Comp[panelObjectIdx].EUnit.EmojiTransform.SetParent(this.Scroll_Comp[panelObjectIdx].ObjectT, false);
      bool flag = this.GM.HasEmotionPck(num1);
      if (flag)
        ((Graphic) this.Scroll_Comp[panelObjectIdx].EUnit.EmojiImage).color = Color.white;
      else
        ((Graphic) this.Scroll_Comp[panelObjectIdx].EUnit.EmojiImage).color = Color.gray;
      if (!this.DM.CheckEmojiSave(num1) && !flag)
        this.Scroll_Comp[panelObjectIdx].FlasfGO.SetActive(true);
      else
        this.Scroll_Comp[panelObjectIdx].FlasfGO.SetActive(false);
      if ((int) this.GM.EmojiNowPackageIndex == (int) num1 - 1)
        ((Behaviour) this.Scroll_Comp[panelObjectIdx].SelectImage2).enabled = true;
      else
        ((Behaviour) this.Scroll_Comp[panelObjectIdx].SelectImage2).enabled = false;
      ((Behaviour) this.Scroll_Comp[panelObjectIdx].SelectImage1).enabled = false;
    }
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    img.sprite = this.GM.LoadFrameSprite(ImageName);
    ((MaskableGraphic) img).material = this.GM.GetFrameMaterial();
  }
}
