// Decompiled with JetBrains decompiler
// Type: UIFilterBase
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIFilterBase : UIBagFilterBase
{
  protected ScrollPanel FilterScrollView;
  protected CScrollRect FilterScrollRect;
  protected RectTransform ScrollContent;
  protected List<float> ItemsHeight = new List<float>();
  protected List<ushort> ItemsData = new List<ushort>();
  protected UISpritesArray FilterSpriteArr;
  protected UISpritesArray ResourceSpriteArr;
  protected Material ResourceMat;
  protected string OwnerStr;
  protected Image Crystal;
  protected Material BagMaterial;
  protected RectTransform MessageTrans;
  protected int ScrollItemCount = 5;
  protected GameObject SortObj;
  protected byte SortType;
  protected UISpritesArray SortSpriteArray;
  protected UIFilterBase.ItemEdit[] FilterItem;
  public UIText MainText;
  protected UIFilterBase._SendItemData SendItemData;
  protected byte PassInit = 2;

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager instance1 = GUIManager.Instance;
    DataManager instance2 = DataManager.Instance;
    Font ttfFont = instance1.GetTTFFont();
    base.OnOpen(arg1, arg2);
    this.ThisTransform = this.transform.GetChild(1);
    this.ThisTransform.gameObject.SetActive(true);
    this.FilterSpriteArr = this.ThisTransform.GetChild(6).GetComponent<UISpritesArray>();
    this.ResourceSpriteArr = this.ThisTransform.GetChild(6).GetChild(0).GetComponent<UISpritesArray>();
    this.ResourceMat = ((MaskableGraphic) this.ThisTransform.GetChild(6).GetChild(0).GetComponent<Image>()).material;
    UIButton component1 = this.ThisTransform.GetChild(4).GetChild(0).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 1001;
    if (instance1.bOpenOnIPhoneX)
      ((Behaviour) this.ThisTransform.GetChild(4).GetComponent<Image>()).enabled = false;
    instance1.UpdateUI(EGUIWindow.Door, 1, 2);
    this.MainText = this.ThisTransform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.MainText.font = ttfFont;
    this.AddRefreshText((Text) this.MainText);
    this.OwnerStr = instance2.mStringTable.GetStringByID(281U);
    this.MessageTrans = this.ThisTransform.GetChild(2).GetComponent<RectTransform>();
    UIText component2 = ((Transform) this.MessageTrans).GetChild(0).GetComponent<UIText>();
    component2.font = ttfFont;
    component2.text = instance2.mStringTable.GetStringByID(744U);
    this.AddRefreshText((Text) component2);
    this.MessageTrans.sizeDelta = this.MessageTrans.sizeDelta with
    {
      x = component2.preferredWidth + 165f
    };
    this.SortObj = this.ThisTransform.GetChild(7).gameObject;
    this.SortSpriteArray = this.ThisTransform.GetChild(7).GetComponent<UISpritesArray>();
    UIButton component3 = this.ThisTransform.GetChild(7).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 1006;
    Transform child = this.ThisTransform.GetChild(5);
    instance1.InitianHeroItemImg(child.GetChild(0), eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false, bClickSound: false);
    child.GetChild(2).GetComponent<UIText>().font = ttfFont;
    this.Crystal = child.GetChild(3).GetChild(0).GetComponent<Image>();
    instance1.m_ItemInfo.LoadCustomImage(this.Crystal, "UI_main_money_02", (string) null);
    this.Crystal.SetNativeSize();
    child.GetChild(3).GetChild(1).GetComponent<UIText>().font = ttfFont;
    child.GetChild(3).GetChild(2).GetComponent<UIText>().font = ttfFont;
    child.GetChild(4).GetComponent<UIText>().font = ttfFont;
    child.GetChild(5).GetComponent<UIText>().font = ttfFont;
    child.GetChild(6).GetChild(0).GetComponent<UIText>().font = ttfFont;
  }

  public virtual void Init()
  {
    this.FilterScrollView = this.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<ScrollPanel>();
    for (byte index = 0; (int) index < this.ScrollItemCount; ++index)
      this.ItemsHeight.Add(128f);
    this.FilterItem = new UIFilterBase.ItemEdit[5];
    this.FilterScrollView.IntiScrollPanel(452f, 0.0f, 0.0f, this.ItemsHeight, this.ScrollItemCount, (IUpDateScrollPanel) this);
    this.FilterScrollRect = this.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<CScrollRect>();
    this.ScrollContent = this.transform.GetChild(1).GetChild(3).GetChild(0).GetChild(0).GetComponent<RectTransform>();
    this.transform.GetChild(1).GetChild(3).gameObject.SetActive(true);
    if (!this.SortObj.activeSelf)
      return;
    ((Behaviour) this.SortSpriteArray.m_Image).enabled = true;
    if (!byte.TryParse(PlayerPrefs.GetString("SpeedUp_Sort"), out this.SortType))
    {
      this.SortType = (byte) 0;
      PlayerPrefs.SetString("SpeedUp_Sort", this.SortType.ToString());
    }
    if (this.SortType > (byte) 1)
      this.SortType = (byte) 1;
    this.SortSpriteArray.SetSpriteIndex((int) this.SortType);
  }

  public Transform SetFunc(Transform func)
  {
    func.SetParent(this.ThisTransform.GetChild(1));
    return this.ThisTransform.GetChild(1).GetChild(0);
  }

  protected void SetItemType(int ItemArrayIndex, UIFilterBase.eItemType UseType)
  {
    switch (UseType)
    {
      case UIFilterBase.eItemType.Use:
        this.FilterItem[ItemArrayIndex].ItemTrans.gameObject.SetActive(true);
        ((Component) this.FilterItem[ItemArrayIndex].OtherImgRect).gameObject.SetActive(false);
        this.FilterItem[ItemArrayIndex].recttransform.sizeDelta = new Vector2(776f, 128f);
        ((Graphic) this.FilterItem[ItemArrayIndex].Content).rectTransform.sizeDelta = new Vector2(420f, 77f);
        this.FilterItem[ItemArrayIndex].BuyImage.sprite = this.FilterSpriteArr.GetSprite(0);
        Vector2 anchoredPosition1 = this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition;
        anchoredPosition1.Set(669f, -35.5f);
        this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition = anchoredPosition1;
        anchoredPosition1.Set(131f, 57f);
        this.FilterItem[ItemArrayIndex].BuyTrans.sizeDelta = anchoredPosition1;
        ((Component) this.FilterItem[ItemArrayIndex].BuyCrystalTrans).gameObject.SetActive(false);
        ((Behaviour) this.FilterItem[ItemArrayIndex].BuyPrice).enabled = false;
        this.FilterItem[ItemArrayIndex].BuyCaption.text = DataManager.Instance.mStringTable.GetStringByID(94U);
        this.FilterItem[ItemArrayIndex].BuyBtn.m_BtnID1 = 1002;
        anchoredPosition1.Set(65.5f, -28.5f);
        this.FilterItem[ItemArrayIndex].BuyCaptionTrans.anchoredPosition = anchoredPosition1;
        anchoredPosition1.Set(131f, 57f);
        this.FilterItem[ItemArrayIndex].BuyCaptionTrans.sizeDelta = anchoredPosition1;
        ((Component) this.FilterItem[ItemArrayIndex].AutouseBtnTrans).gameObject.SetActive(true);
        if (!((Component) this.FilterItem[ItemArrayIndex].Lock).gameObject.activeSelf)
          break;
        ((Component) this.FilterItem[ItemArrayIndex].Lock).gameObject.SetActive(false);
        break;
      case UIFilterBase.eItemType.BuyAndUse:
        this.FilterItem[ItemArrayIndex].ItemTrans.gameObject.SetActive(true);
        ((Component) this.FilterItem[ItemArrayIndex].OtherImgRect).gameObject.SetActive(false);
        this.FilterItem[ItemArrayIndex].recttransform.sizeDelta = new Vector2(776f, 128f);
        ((Graphic) this.FilterItem[ItemArrayIndex].Content).rectTransform.sizeDelta = new Vector2(420f, 77f);
        this.FilterItem[ItemArrayIndex].BuyImage.sprite = this.FilterSpriteArr.GetSprite(1);
        Vector2 anchoredPosition2 = this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition;
        anchoredPosition2.Set(655f, -49.5f);
        this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition = anchoredPosition2;
        anchoredPosition2.Set(160f, 77f);
        this.FilterItem[ItemArrayIndex].BuyTrans.sizeDelta = anchoredPosition2;
        ((Component) this.FilterItem[ItemArrayIndex].BuyCrystalTrans).gameObject.SetActive(true);
        ((Behaviour) this.FilterItem[ItemArrayIndex].BuyPrice).enabled = true;
        this.FilterItem[ItemArrayIndex].BuyCaption.text = DataManager.Instance.mStringTable.GetStringByID(4516U);
        this.FilterItem[ItemArrayIndex].BuyBtn.m_BtnID1 = 1004;
        anchoredPosition2.Set(79f, -56.1f);
        this.FilterItem[ItemArrayIndex].BuyCaptionTrans.anchoredPosition = anchoredPosition2;
        Vector2 sizeDelta = this.FilterItem[ItemArrayIndex].BuyCaptionTrans.sizeDelta;
        sizeDelta.Set(160f, 32f);
        this.FilterItem[ItemArrayIndex].BuyCaptionTrans.sizeDelta = sizeDelta;
        ((Component) this.FilterItem[ItemArrayIndex].AutouseBtnTrans).gameObject.SetActive(false);
        if (!((Component) this.FilterItem[ItemArrayIndex].Lock).gameObject.activeSelf)
          break;
        ((Component) this.FilterItem[ItemArrayIndex].Lock).gameObject.SetActive(false);
        break;
      case UIFilterBase.eItemType.PetTraining:
        this.FilterItem[ItemArrayIndex].ItemTrans.gameObject.SetActive(false);
        ((Component) this.FilterItem[ItemArrayIndex].OtherImgRect).gameObject.SetActive(true);
        this.FilterItem[ItemArrayIndex].recttransform.sizeDelta = new Vector2(776f, 128f);
        ((Graphic) this.FilterItem[ItemArrayIndex].Content).rectTransform.sizeDelta = new Vector2(420f, 77f);
        this.FilterItem[ItemArrayIndex].BuyImage.sprite = this.FilterSpriteArr.GetSprite(0);
        Vector2 anchoredPosition3 = this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition;
        anchoredPosition3.Set(669f, -64.3f);
        this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition = anchoredPosition3;
        anchoredPosition3.Set(131f, 57f);
        this.FilterItem[ItemArrayIndex].BuyTrans.sizeDelta = anchoredPosition3;
        ((Component) this.FilterItem[ItemArrayIndex].BuyCrystalTrans).gameObject.SetActive(false);
        this.FilterItem[ItemArrayIndex].Name.text = string.Empty;
        this.FilterItem[ItemArrayIndex].Owner.text = string.Empty;
        ((Behaviour) this.FilterItem[ItemArrayIndex].BuyPrice).enabled = false;
        this.FilterItem[ItemArrayIndex].BuyCaption.text = DataManager.Instance.mStringTable.GetStringByID(156U);
        this.FilterItem[ItemArrayIndex].BuyBtn.m_BtnID1 = 1005;
        this.FilterItem[ItemArrayIndex].BuyBtn.m_BtnID2 = 23;
        anchoredPosition3.Set(65.5f, -28.5f);
        this.FilterItem[ItemArrayIndex].BuyCaptionTrans.anchoredPosition = anchoredPosition3;
        anchoredPosition3.Set(131f, 57f);
        this.FilterItem[ItemArrayIndex].BuyCaptionTrans.sizeDelta = anchoredPosition3;
        ((Component) this.FilterItem[ItemArrayIndex].AutouseBtnTrans).gameObject.SetActive(false);
        if (((Component) this.FilterItem[ItemArrayIndex].Lock).gameObject.activeSelf)
          ((Component) this.FilterItem[ItemArrayIndex].Lock).gameObject.SetActive(false);
        this.FilterItem[ItemArrayIndex].OtherImg.sprite = GUIManager.Instance.BuildingData.GetBuildSprite((ushort) 23, (byte) 25);
        ((MaskableGraphic) this.FilterItem[ItemArrayIndex].OtherImg).material = GUIManager.Instance.MapSpriteUIMaterial;
        this.FilterItem[ItemArrayIndex].OtherImg.SetNativeSize();
        ((Transform) this.FilterItem[ItemArrayIndex].OtherImgRect).localScale = new Vector3(0.54f, 0.54f, 0.54f);
        this.FilterItem[ItemArrayIndex].OtherImgRect.anchoredPosition = new Vector2(-298f, -1.4f);
        this.FilterItem[ItemArrayIndex].Content.text = DataManager.Instance.mStringTable.GetStringByID(16092U);
        break;
      case UIFilterBase.eItemType.Grain:
      case UIFilterBase.eItemType.Rock:
      case UIFilterBase.eItemType.Wood:
      case UIFilterBase.eItemType.Iron:
      case UIFilterBase.eItemType.Gold:
        this.FilterItem[ItemArrayIndex].ItemTrans.gameObject.SetActive(false);
        ((Component) this.FilterItem[ItemArrayIndex].OtherImgRect).gameObject.SetActive(true);
        this.FilterItem[ItemArrayIndex].BuyImage.sprite = this.FilterSpriteArr.GetSprite(0);
        this.FilterItem[ItemArrayIndex].recttransform.sizeDelta = new Vector2(776f, 109f);
        ((Graphic) this.FilterItem[ItemArrayIndex].Content).rectTransform.sizeDelta = new Vector2(420f, 66f);
        Vector2 anchoredPosition4 = this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition;
        anchoredPosition4.Set(667.5f, -51.5f);
        this.FilterItem[ItemArrayIndex].BuyTrans.anchoredPosition = anchoredPosition4;
        anchoredPosition4.Set(109f, 47f);
        this.FilterItem[ItemArrayIndex].BuyTrans.sizeDelta = anchoredPosition4;
        ((Component) this.FilterItem[ItemArrayIndex].BuyCrystalTrans).gameObject.SetActive(false);
        this.FilterItem[ItemArrayIndex].Name.text = string.Empty;
        this.FilterItem[ItemArrayIndex].Owner.text = string.Empty;
        ((Behaviour) this.FilterItem[ItemArrayIndex].BuyPrice).enabled = false;
        this.FilterItem[ItemArrayIndex].BuyCaption.text = DataManager.Instance.mStringTable.GetStringByID(156U);
        this.FilterItem[ItemArrayIndex].BuyBtn.m_BtnID1 = 1005;
        anchoredPosition4.Set(54.5f, -24f);
        this.FilterItem[ItemArrayIndex].BuyCaptionTrans.anchoredPosition = anchoredPosition4;
        anchoredPosition4.Set(109f, 47f);
        this.FilterItem[ItemArrayIndex].BuyCaptionTrans.sizeDelta = anchoredPosition4;
        ((Component) this.FilterItem[ItemArrayIndex].AutouseBtnTrans).gameObject.SetActive(false);
        if (((Component) this.FilterItem[ItemArrayIndex].Lock).gameObject.activeSelf)
          ((Component) this.FilterItem[ItemArrayIndex].Lock).gameObject.SetActive(false);
        int index = (int) (UseType - 3);
        this.FilterItem[ItemArrayIndex].OtherImg.sprite = this.ResourceSpriteArr.GetSprite(index);
        ((MaskableGraphic) this.FilterItem[ItemArrayIndex].OtherImg).material = this.ResourceMat;
        this.FilterItem[ItemArrayIndex].OtherImg.SetNativeSize();
        if (GUIManager.Instance.IsArabic)
          ((Transform) this.FilterItem[ItemArrayIndex].OtherImgRect).localScale = new Vector3(-1f, 1f, 1f);
        else
          ((Transform) this.FilterItem[ItemArrayIndex].OtherImgRect).localScale = Vector3.one;
        this.FilterItem[ItemArrayIndex].OtherImgRect.anchoredPosition = new Vector2(-305.5f, 0.0f);
        this.FilterItem[ItemArrayIndex].Name.text = string.Empty;
        this.FilterItem[ItemArrayIndex].Content.text = DataManager.Instance.mStringTable.GetStringByID((uint) (14596 + index));
        break;
    }
  }

  public override void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1001:
        if (BattleController.IsGambleMode)
        {
          GamblingManager.Instance.CloseMenu();
          break;
        }
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!((Object) menu != (Object) null))
          break;
        menu.CloseMenu();
        break;
      case 1002:
      case 1004:
      case 1005:
        this.SendPack(sender);
        break;
      case 1003:
        GUIManager.Instance.UpdateUI(EGUIWindow.UI_BagFilter, 3, (int) this.FilterItem[sender.m_BtnID2].KeyID);
        break;
      case 1006:
        this.SortType = (byte) ((uint) ++this.SortType & 1U);
        this.SortSpriteArray.SetSpriteIndex((int) this.SortType);
        PlayerPrefs.SetString("SpeedUp_Sort", this.SortType.ToString());
        GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(14707U + (uint) this.SortType), (ushort) byte.MaxValue);
        this.SendPack(sender);
        break;
    }
  }

  public virtual void SendPack(UIButton sender)
  {
  }

  public virtual void CheckBuy(
    byte Type,
    ushort Key,
    ushort ItemID,
    bool BuyAndUse = false,
    GUIWindow win = null,
    int arg1 = 0,
    int arg2 = 0,
    uint Parameter3 = 0)
  {
    if (GUIManager.Instance.OpenCheckCrystal(DataManager.Instance.StoreData.GetRecordByKey(Key).Price, (byte) 1, 65537))
    {
      this.SendItemData.Type = Type;
      this.SendItemData.Key = Key;
      this.SendItemData.ItemID = ItemID;
      this.SendItemData.BuyAndUse = BuyAndUse;
      this.SendItemData.win = win;
      this.SendItemData.arg1 = arg1;
      this.SendItemData.arg2 = arg2;
      this.SendItemData.arg3 = Parameter3;
    }
    else
      DataManager.Instance.sendBuyItem(Type, Key, ItemID, BuyAndUse, win, arg1, arg2, Parameter3, string.Empty, Qty: (ushort) 1);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (this.PassInit > (byte) 0)
    {
      this.Init();
      this.PassInit = (byte) 0;
    }
    if (meg[0] == (byte) 35)
    {
      for (int index = 0; index < this.FilterItem.Length && !((Object) this.FilterItem[index].ItemBtn == (Object) null); ++index)
      {
        if (((Component) this.FilterItem[index].ItemBtn).gameObject.activeSelf)
          this.FilterItem[index].ItemBtn.Refresh_FontTexture();
      }
    }
    base.UpdateNetwork(meg);
  }

  public override void UpdateUI(int arge1, int arge2)
  {
    if (arge1 != 65537)
      return;
    DataManager.Instance.sendBuyItem(this.SendItemData.Type, this.SendItemData.Key, this.SendItemData.ItemID, this.SendItemData.BuyAndUse, this.SendItemData.win, this.SendItemData.arg1, this.SendItemData.arg2, this.SendItemData.arg3, string.Empty, Qty: (ushort) 1);
  }

  public override void UpDateRowItem(
    GameObject item,
    int dataIdx,
    int panelObjectIdx,
    int panelId)
  {
    if (!((Object) this.FilterItem[panelObjectIdx].ItemTrans == (Object) null))
      return;
    this.FilterItem[panelObjectIdx].recttransform = item.transform as RectTransform;
    this.FilterItem[panelObjectIdx].BkImage = item.GetComponent<Image>();
    this.FilterItem[panelObjectIdx].ItemTrans = (Transform) item.transform.GetChild(0).GetComponent<RectTransform>();
    this.FilterItem[panelObjectIdx].OtherImgRect = item.transform.GetChild(1).GetComponent<RectTransform>();
    this.FilterItem[panelObjectIdx].OtherImg = ((Component) this.FilterItem[panelObjectIdx].OtherImgRect).GetComponent<Image>();
    this.AddRefreshText((Text) this.FilterItem[panelObjectIdx].ItemTrans.GetChild(5).GetComponent<UIText>());
    this.FilterItem[panelObjectIdx].ItemBtn = this.FilterItem[panelObjectIdx].ItemTrans.GetComponent<UIHIBtn>();
    this.FilterItem[panelObjectIdx].ItemBtn.m_Handler = (IUIHIBtnClickHandler) this;
    this.FilterItem[panelObjectIdx].InfoTrans = this.FilterItem[panelObjectIdx].ItemTrans.GetChild(0);
    this.FilterItem[panelObjectIdx].InfoTrans.SetAsLastSibling();
    this.FilterItem[panelObjectIdx].Owner = item.transform.GetChild(2).GetComponent<UIText>();
    this.FilterItem[panelObjectIdx].Name = item.transform.GetChild(4).GetComponent<UIText>();
    this.FilterItem[panelObjectIdx].Content = item.transform.GetChild(5).GetComponent<UIText>();
    this.AddRefreshText((Text) this.FilterItem[panelObjectIdx].Owner);
    this.AddRefreshText((Text) this.FilterItem[panelObjectIdx].Name);
    this.AddRefreshText((Text) this.FilterItem[panelObjectIdx].Content);
    this.FilterItem[panelObjectIdx].BuyTrans = item.transform.GetChild(3).GetComponent<RectTransform>();
    this.FilterItem[panelObjectIdx].BuyBtn = item.transform.GetChild(3).GetComponent<UIButton>();
    this.FilterItem[panelObjectIdx].BuyBtn.m_Handler = (IUIButtonClickHandler) this;
    this.FilterItem[panelObjectIdx].BuyBtn.m_BtnID2 = panelObjectIdx;
    this.FilterItem[panelObjectIdx].BuyImage = item.transform.GetChild(3).GetComponent<Image>();
    this.FilterItem[panelObjectIdx].PriceImg = item.transform.GetChild(3).GetChild(0).GetComponent<Image>();
    this.FilterItem[panelObjectIdx].BuyCrystalTrans = item.transform.GetChild(3).GetChild(0).GetComponent<RectTransform>();
    this.FilterItem[panelObjectIdx].BuyPrice = item.transform.GetChild(3).GetChild(1).GetComponent<UIText>();
    this.AddRefreshText((Text) this.FilterItem[panelObjectIdx].BuyPrice);
    this.FilterItem[panelObjectIdx].BuyCaptionTrans = item.transform.GetChild(3).GetChild(2).GetComponent<RectTransform>();
    this.FilterItem[panelObjectIdx].BuyCaption = item.transform.GetChild(3).GetChild(2).GetComponent<UIText>();
    this.AddRefreshText((Text) this.FilterItem[panelObjectIdx].BuyCaption);
    this.FilterItem[panelObjectIdx].Lock = item.transform.GetChild(3).GetChild(3).GetComponent<Image>();
    this.FilterItem[panelObjectIdx].OwnerStr = StringManager.Instance.SpawnString();
    this.FilterItem[panelObjectIdx].BuyPriceStr = StringManager.Instance.SpawnString();
    this.FilterItem[panelObjectIdx].NameStr = StringManager.Instance.SpawnString(100);
    UIText component1 = item.transform.GetChild(6).GetChild(0).GetComponent<UIText>();
    this.AddRefreshText((Text) component1);
    component1.text = DataManager.Instance.mStringTable.GetStringByID(282U);
    this.FilterItem[panelObjectIdx].AutouseBtnTrans = item.transform.GetChild(6).GetComponent<RectTransform>();
    UIButton component2 = ((Component) this.FilterItem[panelObjectIdx].AutouseBtnTrans).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 1003;
    component2.m_BtnID2 = panelObjectIdx;
  }

  public override void OnClose()
  {
    base.OnClose();
    if (this.FilterItem == null)
      return;
    for (int index = 0; index < this.FilterItem.Length; ++index)
    {
      StringManager.Instance.DeSpawnString(this.FilterItem[index].OwnerStr);
      StringManager.Instance.DeSpawnString(this.FilterItem[index].BuyPriceStr);
      StringManager.Instance.DeSpawnString(this.FilterItem[index].NameStr);
    }
  }

  public override void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public virtual void SetItemData(
    ushort[] ItemData,
    ushort Start,
    ushort Count,
    bool Replace = false,
    byte sort = 0,
    int sortbeginIdx = 0)
  {
    if (Replace)
    {
      this.ItemsHeight.Clear();
      this.ItemsData.Clear();
    }
    for (ushort index = Start; (int) index != (int) Start + (int) Count; ++index)
    {
      if (this.CheckItemRule(ItemData[(int) index]))
      {
        this.ItemsHeight.Add(128f);
        if (sort == (byte) 0)
          this.ItemsData.Add(ItemData[(int) index]);
        else
          this.ItemsData.Insert(sortbeginIdx, ItemData[(int) index]);
      }
    }
  }

  public virtual void SetItemData(PetItem[] ItemData, ushort Start, ushort Count, bool Replace = false)
  {
    if (Replace)
    {
      this.ItemsHeight.Clear();
      this.ItemsData.Clear();
    }
    PetManager instance = PetManager.Instance;
    for (ushort index1 = Start; (int) index1 != (int) Start + (int) Count; ++index1)
    {
      ushort index2 = instance.sortPetItemData[(int) index1];
      if (ItemData[(int) index2] != null && this.CheckItemRule(ItemData[(int) index2].ItemID))
      {
        this.ItemsHeight.Add(128f);
        this.ItemsData.Add(ItemData[(int) index2].ItemID);
      }
    }
  }

  public virtual bool CheckItemRule(ushort id) => true;

  public void UpdateScrollItemsCount()
  {
    if (!this.FilterScrollView.gameObject.activeSelf)
      return;
    this.FilterScrollView.AddNewDataHeight(this.ItemsHeight);
    if (this.ItemsHeight.Count == 0)
      ((Component) this.MessageTrans).gameObject.SetActive(true);
    else
      ((Component) this.MessageTrans).gameObject.SetActive(false);
  }

  public override void Update()
  {
    if (this.PassInit <= (byte) 0)
      return;
    --this.PassInit;
    if (this.PassInit != (byte) 0)
      return;
    this.Init();
  }

  protected enum eItemType
  {
    Use,
    BuyAndUse,
    PetTraining,
    Grain,
    Rock,
    Wood,
    Iron,
    Gold,
  }

  protected struct ItemEdit
  {
    public ushort KeyID;
    public Transform ItemTrans;
    public Transform InfoTrans;
    public UIHIBtn ItemBtn;
    public UIText Owner;
    public UIText Name;
    public UIText Content;
    public Image BkImage;
    public Image BuyImage;
    public Image PriceImg;
    public Image OtherImg;
    public RectTransform BuyCrystalTrans;
    public RectTransform OtherImgRect;
    public RectTransform recttransform;
    public UIButton BuyBtn;
    public RectTransform BuyTrans;
    public RectTransform BuyCaptionTrans;
    public UIText BuyCaption;
    public UIText BuyPrice;
    public Image Lock;
    public RectTransform AutouseBtnTrans;
    public CString NameStr;
    public CString OwnerStr;
    public CString BuyPriceStr;
  }

  protected struct _SendItemData
  {
    public byte Type;
    public byte Check;
    public ushort Key;
    public ushort ItemID;
    public bool BuyAndUse;
    public GUIWindow win;
    public int arg1;
    public int arg2;
    public uint arg3;
  }

  protected enum FilterBaseClickType
  {
    Exit = 1001, // 0x000003E9
    Use = 1002, // 0x000003EA
    AutoUse = 1003, // 0x000003EB
    Buy = 1004, // 0x000003EC
    Goto = 1005, // 0x000003ED
    Sort = 1006, // 0x000003EE
  }

  protected enum UIControl
  {
    Background,
    Func,
    Message,
    ScrollContent,
    Close,
    FilterItem,
    SpriteArray,
    Sort,
  }

  protected enum FilterItemControl
  {
    ObjPic,
    OtherPic,
    Owner,
    Buy,
    Name,
    Content,
    AutoUse,
  }
}
