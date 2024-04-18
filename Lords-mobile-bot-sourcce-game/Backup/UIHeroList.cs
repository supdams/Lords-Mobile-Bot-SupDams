// Decompiled with JetBrains decompiler
// Type: UIHeroList
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
public class UIHeroList : GUIWindow, IUpDateRowItem, IUIButtonClickHandler
{
  private const int MaxTabBtnFlashCount = 3;
  private const int MaxTempTextNum = 20;
  private UIHeroList.e_HeroListPageTpye PageType;
  private StringBuilder sb = new StringBuilder();
  private ScrollView scrollView;
  public CScrollRect scrollRect;
  public RectTransform scrolCont;
  public RectTransform MessageTrans;
  private Color DisableColor = new Color(0.7f, 0.7f, 0.7f, 0.7f);
  private Color EnableColor = new Color(1f, 1f, 1f, 1f);
  public UIButton exitButton;
  private UIButton ownedPageButton;
  private UIButton noOwnedPageButton;
  private Image ownedPageImage;
  private Image noOwnedPageImage;
  private Image itemPageImage;
  private UIButton itemPageButton;
  private UIText noRecruitmentText;
  private Transform ExpTf;
  private UISpritesArray spriteArray;
  private Sprite[] heroTypeSprite = new Sprite[3];
  private Sprite[] equipSprite = new Sprite[3];
  private fragmentObject[] fragmentHeroID;
  private fragmentObject[] fragmentHeroIDMax;
  private int fragmentHeroIDCount;
  private int fragmentHeroIDMaxCount;
  private ushort RecruitHeroID;
  private bool bFlash;
  private float flashCount;
  private Image[] flashImage = new Image[16];
  private float flashTime;
  private int tabBtnFlashIndex;
  private Image[] tabBtnFlashImage = new Image[3];
  private float tabBtnColorA = 1f;
  private float tabBtnTime;
  private Image[] scrollBlack = new Image[2];
  private Material frameMat;
  private Image BtnExclamationImage;
  public Transform checkPanel;
  private RectTransform itemPage;
  private UIButton[] itemTabButton = new UIButton[5];
  private UIText[] TabText = new UIText[5];
  private UIText NoItemText;
  private CanvasGroup[] TabButtonA = new CanvasGroup[5];
  private Color TabTextColor;
  private ScrollView itemView;
  private CScrollRect itemScrollRect;
  private RectTransform itemCont;
  private bool bInitItemView;
  private byte itemTabIndex;
  private bool bInitScrollView;
  private List<UIHIBtn> ItemHIBtn = new List<UIHIBtn>();
  private List<HeroEquip> EqipData = new List<HeroEquip>();
  private bool bHaveRecruit;
  private UIText[] m_TempNameText = new UIText[20];
  private UIText[] m_TempNumText = new UIText[20];
  private UIHIBtn[] m_TempHibtn = new UIHIBtn[20];

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager.SortHeroData();
    this.SetFragmentHeroData();
    if (NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP))
    {
      DataManager instance = DataManager.Instance;
      Array.Copy((Array) instance.sortHeroData, (Array) NewbieManager.Get().sortHeroDataCache, instance.MaxCurHeroData);
      int index = Array.IndexOf<uint>(instance.sortHeroData, 1U);
      if (index != -1)
      {
        instance.sortHeroData[index] = instance.sortHeroData[0];
        instance.sortHeroData[0] = 1U;
      }
    }
    this.SetEqipData();
    this.PageType = UIHeroList.e_HeroListPageTpye.OwnedPage;
    this.bInitScrollView = false;
    this.spriteArray = this.gameObject.transform.GetComponent<UISpritesArray>();
    this.heroTypeSprite[0] = this.spriteArray.GetSprite(3);
    this.heroTypeSprite[1] = this.spriteArray.GetSprite(4);
    this.heroTypeSprite[2] = this.spriteArray.GetSprite(5);
    this.equipSprite[0] = this.spriteArray.GetSprite(0);
    this.equipSprite[1] = this.spriteArray.GetSprite(1);
    this.equipSprite[2] = this.spriteArray.GetSprite(2);
    Image component1 = this.gameObject.transform.GetChild(1).GetComponent<Image>();
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (UnityEngine.Object) menu)
    {
      component1.sprite = menu.LoadSprite("UI_main_close_base");
      ((MaskableGraphic) component1).material = menu.LoadMaterial();
      if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (UnityEngine.Object) component1)
        ((Behaviour) component1).enabled = false;
    }
    this.exitButton = this.gameObject.transform.GetChild(1).GetChild(0).GetComponent<UIButton>();
    this.exitButton.m_Handler = (IUIButtonClickHandler) this;
    this.exitButton.m_BtnID1 = 1;
    this.exitButton.image.sprite = menu.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.exitButton.image).material = menu.LoadMaterial();
    Transform child1 = this.gameObject.transform.GetChild(5);
    this.ownedPageButton = child1.GetComponent<UIButton>();
    this.ownedPageButton.m_Handler = (IUIButtonClickHandler) this;
    this.ownedPageButton.m_BtnID1 = 2;
    this.ownedPageButton.SoundIndex = (byte) 3;
    this.tabBtnFlashImage[0] = child1.GetChild(0).GetComponent<Image>();
    Transform child2 = this.gameObject.transform.GetChild(8);
    this.noOwnedPageButton = child2.GetComponent<UIButton>();
    this.noOwnedPageButton.m_Handler = (IUIButtonClickHandler) this;
    this.noOwnedPageButton.m_BtnID1 = 3;
    this.noOwnedPageButton.SoundIndex = (byte) 3;
    this.tabBtnFlashImage[1] = child2.GetChild(0).GetComponent<Image>();
    this.ownedPageImage = this.gameObject.transform.GetChild(7).GetComponent<Image>();
    this.noOwnedPageImage = this.gameObject.transform.GetChild(9).GetComponent<Image>();
    this.itemPageImage = this.gameObject.transform.GetChild(11).GetComponent<Image>();
    Transform child3 = this.transform.GetChild(10);
    this.itemPageButton = child3.GetComponent<UIButton>();
    this.itemPageButton.m_Handler = (IUIButtonClickHandler) this;
    this.itemPageButton.m_BtnID1 = 4;
    this.itemPageButton.SoundIndex = (byte) 3;
    this.tabBtnFlashImage[2] = child3.GetChild(0).GetComponent<Image>();
    this.frameMat = GUIManager.Instance.GetFrameMaterial();
    for (int index = 0; index < 2; ++index)
    {
      Transform child4 = this.transform.GetChild(14 + index);
      this.scrollBlack[index] = child4.GetComponent<Image>();
      this.scrollBlack[index].sprite = GUIManager.Instance.LoadFrameSprite("UI_shared_black");
      ((MaskableGraphic) this.scrollBlack[index]).material = this.frameMat;
    }
    Transform child5 = this.gameObject.transform.GetChild(3);
    if ((bool) (UnityEngine.Object) child5)
      this.scrollView = child5.GetComponent<ScrollView>();
    if ((bool) (UnityEngine.Object) this.scrollView)
    {
      GUIManager.Instance.InitianHeroItemImg(this.scrollView.customItem.transform.GetChild(0).GetChild(1), eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
      for (int index = 0; index < 6; ++index)
        GUIManager.Instance.InitianHeroItemImg(this.scrollView.customItem.transform.GetChild(0).GetChild(3 + index).GetChild(0), eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false);
      UIText component2 = this.scrollView.customItem.transform.GetChild(0).GetChild(13).GetComponent<UIText>();
      if ((UnityEngine.Object) component2 != (UnityEngine.Object) null)
      {
        component2.resizeTextForBestFit = true;
        component2.resizeTextMinSize = 10;
        component2.resizeTextMaxSize = 22;
      }
      this.scrollView.gameObject.SetActive(true);
    }
    this.PageType = (UIHeroList.e_HeroListPageTpye) ((int) GUIManager.Instance.HeroListSaved & 3);
    if (NewbieManager.IsWorking())
      this.PageType = UIHeroList.e_HeroListPageTpye.OwnedPage;
    this.itemTabIndex = (byte) ((uint) GUIManager.Instance.HeroListSaved >> 2);
    this.itemPage = (RectTransform) this.transform.GetChild(4);
    for (int index = 0; index < this.itemTabButton.Length; ++index)
    {
      Transform child6 = ((Transform) this.itemPage).GetChild(index + 3);
      this.itemTabButton[index] = child6.GetComponent<UIButton>();
      this.itemTabButton[index].m_Handler = (IUIButtonClickHandler) this;
      this.TabButtonA[index] = child6.GetChild(0).GetComponent<CanvasGroup>();
      Transform child7 = child6.GetChild(1);
      RectTransform rectTransform = child7 as RectTransform;
      Vector2 sizeDelta = rectTransform.sizeDelta with
      {
        x = -20.5f
      };
      rectTransform.sizeDelta = sizeDelta;
      this.TabText[index] = child7.GetComponent<UIText>();
      this.TabText[index].font = GUIManager.Instance.GetTTFFont();
      this.TabText[index].text = DataManager.Instance.mStringTable.GetStringByID((uint) (253 + this.itemTabButton[index].m_BtnID2));
      this.TabText[index].fontStyle = FontStyle.Normal;
    }
    this.TabTextColor = ((Graphic) this.TabText[0]).color;
    this.noRecruitmentText = this.gameObject.transform.GetChild(16).GetComponent<UIText>();
    this.noRecruitmentText.font = GUIManager.Instance.GetTTFFont();
    this.noRecruitmentText.text = DataManager.Instance.mStringTable.GetStringByID(492U);
    this.ExpTf = this.gameObject.transform.GetChild(17);
    UIText component3 = this.ExpTf.GetChild(1).GetChild(2).GetComponent<UIText>();
    component3.font = GUIManager.Instance.GetTTFFont();
    component3.text = DataManager.Instance.mStringTable.GetStringByID(739U);
    UIButton component4 = this.ExpTf.GetChild(1).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_BtnID1 = 97;
    this.CheckExpItem();
    this.BtnExclamationImage = this.gameObject.transform.GetChild(18).GetComponent<Image>();
    if ((bool) (UnityEngine.Object) menu && menu.m_FuncBtnCount[0] != 0)
      ((Component) this.BtnExclamationImage).gameObject.SetActive(true);
    else
      ((Component) this.BtnExclamationImage).gameObject.SetActive(false);
    this.InitOpenCheckBox();
    if (!GUIManager.Instance.m_IsOpenedUISynthesis)
    {
      this.SetPage(this.PageType);
    }
    else
    {
      this.PageType = UIHeroList.e_HeroListPageTpye.NoOwnedPage;
      this.SetPage(this.PageType);
    }
    if (!NewbieManager.CheckTeach(ETeachKind.PUTON_EQUIP, (object) this))
      NewbieManager.CheckTeach(ETeachKind.NEW_HERO, (object) this);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  private void InitScrollView()
  {
    this.bInitScrollView = false;
    float posY;
    float[] ownedPagePosYarray;
    float height;
    int[] ownedPageIdArray;
    ScrollViewIndexValue ownedPageScrollValue;
    int _initDataSize;
    int num;
    if (this.PageType == UIHeroList.e_HeroListPageTpye.OwnedPage)
    {
      posY = DataManager.Instance.OwnedPagePosY;
      ownedPagePosYarray = DataManager.Instance.OwnedPagePosYArray;
      height = DataManager.Instance.OwnedPageContentHeight;
      ownedPageIdArray = DataManager.Instance.OwnedPageIDArray;
      ownedPageScrollValue = DataManager.Instance.OwnedPageScrollValue;
      _initDataSize = (int) Mathf.Clamp((float) ((long) DataManager.Instance.CurHeroDataCount + (long) this.fragmentHeroIDMaxCount), 0.0f, 15f);
      num = (int) DataManager.Instance.CurHeroDataCount + this.fragmentHeroIDMaxCount;
    }
    else
    {
      posY = DataManager.Instance.NoOwnedPagePosY;
      ownedPagePosYarray = DataManager.Instance.NoOwnedPagePosYArray;
      height = DataManager.Instance.NoOwnedPageContentYHeight;
      ownedPageIdArray = DataManager.Instance.NoOwnedPageIDArray;
      ownedPageScrollValue = DataManager.Instance.NoOwnedPageScrollValue;
      _initDataSize = Mathf.Clamp(this.fragmentHeroIDCount, 0, 15);
      num = this.fragmentHeroIDCount;
    }
    if (ownedPagePosYarray == null || ownedPageIdArray == null)
    {
      this.scrollView.AddHender((IUpDateRowItem) this, false, _initDataSize, num);
      this.scrollView.SetContentSize(num);
    }
    else
    {
      this.scrollView.AddHender((IUpDateRowItem) this, false, _initDataSize, num, posY, ownedPagePosYarray, height, ownedPageIdArray, ownedPageScrollValue);
      this.scrollView.SetContentSize(num);
      this.scrollView.SetContentPos(posY);
      this.scrollView.UpDateAllItem();
    }
    Transform child = this.gameObject.transform.GetChild(3);
    this.scrolCont = child.GetChild(0).GetComponent<RectTransform>();
    this.scrollRect = child.GetComponent<CScrollRect>();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
      case NetworkNews.Refresh_Item:
        this.UpdateNetworkNews(true);
        break;
      case NetworkNews.Refresh_Hero:
        this.UpdateNetworkNews(false);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_HeroExclamation)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.Refresh_FontTexture();
          break;
        }
        goto case NetworkNews.Login;
    }
  }

  public void UpdateNetworkNews(bool bNeedSetEqipData)
  {
    if (!NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP))
      DataManager.SortHeroData();
    this.SetFragmentHeroData();
    if (bNeedSetEqipData)
      this.SetEqipData();
    if (this.PageType == UIHeroList.e_HeroListPageTpye.OwnedPage)
    {
      this.CheckExpItem();
      this.OnButtonClick(this.ownedPageButton);
    }
    else if (this.PageType == UIHeroList.e_HeroListPageTpye.NoOwnedPage)
      this.OnButtonClick(this.noOwnedPageButton);
    else
      this.UpdateItemPage();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 0)
      return;
    if ((GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).m_FuncBtnCount[0] != 0)
      ((Component) this.BtnExclamationImage).gameObject.SetActive(true);
    else
      ((Component) this.BtnExclamationImage).gameObject.SetActive(false);
  }

  private void SetEqipData()
  {
    DataManager instance = DataManager.Instance;
    ushort num1 = 0;
    this.EqipData.Clear();
    for (int index1 = 0; (long) index1 < (long) instance.CurHeroDataCount; ++index1)
    {
      HeroEquip heroEquip = new HeroEquip(0);
      uint key = instance.sortHeroData[index1];
      if (instance.curHeroData.ContainsKey(key))
      {
        CurHeroData curHeroData = instance.curHeroData[key];
        for (int index2 = 0; index2 < 6; ++index2)
        {
          Enhance recordByKey1 = DataManager.Instance.EnhanceTable.GetRecordByKey(curHeroData.ID);
          int index3 = ((int) curHeroData.Enhance - 1) * 6 + index2;
          if (index3 >= 0 && recordByKey1.EnhanceNumber != null && index3 < recordByKey1.EnhanceNumber.Length)
            num1 = recordByKey1.EnhanceNumber[index3];
          Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(num1);
          int num2 = (int) curHeroData.Equip >> index2 & 1;
          heroEquip.IsEquip[index2] = num2 != 0;
          heroEquip.EquipItemID[index2] = num1;
          heroEquip.IsFindItemComposite[index2] = DataManager.Instance.FindItemComposite(num1);
          heroEquip.EquipNeedLv[index2] = (ushort) recordByKey2.NeedLv;
        }
      }
      this.EqipData.Add(heroEquip);
    }
  }

  private void SetFragmentHeroData()
  {
    if (NewbieManager.IsTeachWorking(ETeachKind.PUTON_EQUIP))
    {
      this.fragmentHeroIDMaxCount = 0;
    }
    else
    {
      ushort[] numArray = new ushort[5]
      {
        (ushort) 10,
        (ushort) 30,
        (ushort) 80,
        (ushort) 180,
        (ushort) 330
      };
      ushort num1 = 0;
      List<ushort> ushortList = new List<ushort>();
      this.fragmentHeroIDCount = 0;
      this.fragmentHeroIDMaxCount = 0;
      DataManager.Instance.SortCurItemData();
      ushort num2 = DataManager.Instance.sortItemDataStart[4];
      ushort length = DataManager.Instance.sortItemDataCount[4];
      this.bHaveRecruit = false;
      ushort num3 = (ushort) Mathf.Clamp(DataManager.Instance.HeroTable.TableCount, 0, 100);
      Hero recordByKey1;
      for (ushort InKey = 0; (int) InKey < (int) num3; ++InKey)
      {
        recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(InKey);
        if (recordByKey1.bShowHeroStone == (byte) 1)
        {
          ushort heroKey = recordByKey1.HeroKey;
          if (!DataManager.Instance.curHeroData.ContainsKey((uint) recordByKey1.HeroKey) && DataManager.Instance.GetCurItemQuantity(recordByKey1.SoulStone, (byte) 0) <= (ushort) 0)
          {
            ushortList.Add(heroKey);
            ++num1;
          }
        }
      }
      this.fragmentHeroID = new fragmentObject[(int) length + (int) num1];
      this.fragmentHeroIDMax = new fragmentObject[(int) length];
      for (int index = (int) num2; index < (int) length + (int) num2; ++index)
      {
        ushort num4 = DataManager.Instance.sortItemData[index];
        Equip recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(num4);
        if (!DataManager.Instance.curHeroData.ContainsKey((uint) recordByKey2.SyntheticParts[0].SyntheticItem))
        {
          recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(recordByKey2.SyntheticParts[0].SyntheticItem);
          ushort num5 = numArray[(int) recordByKey1.defaultStar - 1];
          ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(num4, (byte) 0);
          if ((int) curItemQuantity < (int) num5)
          {
            this.fragmentHeroID[this.fragmentHeroIDCount] = new fragmentObject();
            this.fragmentHeroID[this.fragmentHeroIDCount].HeroID = recordByKey2.SyntheticParts[0].SyntheticItem;
            this.fragmentHeroID[this.fragmentHeroIDCount].HeroStone = curItemQuantity;
            this.fragmentHeroID[this.fragmentHeroIDCount].MaxHeroStone = num5;
            ++this.fragmentHeroIDCount;
          }
          else
          {
            this.fragmentHeroIDMax[this.fragmentHeroIDMaxCount] = new fragmentObject();
            this.fragmentHeroIDMax[this.fragmentHeroIDMaxCount].HeroID = recordByKey2.SyntheticParts[0].SyntheticItem;
            this.fragmentHeroIDMax[this.fragmentHeroIDMaxCount].HeroStone = curItemQuantity;
            this.fragmentHeroIDMax[this.fragmentHeroIDMaxCount].MaxHeroStone = num5;
            ++this.fragmentHeroIDMaxCount;
            this.bHaveRecruit = true;
          }
        }
      }
      for (ushort index = 0; (int) index < (int) num1; ++index)
      {
        recordByKey1 = DataManager.Instance.HeroTable.GetRecordByKey(ushortList[(int) index]);
        ushort num6 = numArray[(int) recordByKey1.defaultStar - 1];
        this.fragmentHeroID[this.fragmentHeroIDCount] = new fragmentObject();
        this.fragmentHeroID[this.fragmentHeroIDCount].HeroID = ushortList[(int) index];
        this.fragmentHeroID[this.fragmentHeroIDCount].HeroStone = (ushort) 0;
        this.fragmentHeroID[this.fragmentHeroIDCount].MaxHeroStone = num6;
        ++this.fragmentHeroIDCount;
      }
    }
  }

  private void SetItemByID(GameObject item, uint idx)
  {
    Hero hero;
    hero.HeroName = (ushort) 0;
    Image component1 = item.transform.GetChild(15).GetComponent<Image>();
    ((Component) component1).gameObject.SetActive(false);
    if (this.PageType == UIHeroList.e_HeroListPageTpye.OwnedPage)
    {
      UIHIBtn component2 = item.transform.GetChild(1).GetComponent<UIHIBtn>();
      if ((long) idx >= (long) this.fragmentHeroIDMaxCount)
      {
        uint curHeroDataIdx = (uint) ((ulong) idx - (ulong) this.fragmentHeroIDMaxCount);
        uint key = DataManager.Instance.sortHeroData[(IntPtr) curHeroDataIdx];
        if (!DataManager.Instance.curHeroData.ContainsKey(key))
          return;
        CurHeroData curHeroData = DataManager.Instance.curHeroData[key];
        Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(curHeroData.ID);
        byte heroType = recordByKey.HeroType;
        GUIManager.Instance.ChangeHeroItemImg(((Component) component2).transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, curHeroData.Enhance, (int) curHeroData.Level);
        this.SetItemEquipments(item, curHeroDataIdx, curHeroData.Level);
        if (heroType >= (byte) 1 && (int) heroType <= this.heroTypeSprite.Length)
          item.transform.GetChild(11).GetComponent<Image>().sprite = this.heroTypeSprite[(int) heroType - 1];
        string stringById = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.HeroTitle);
        UIText component3 = item.transform.GetChild(12).GetComponent<UIText>();
        component3.font = GUIManager.Instance.GetTTFFont();
        component3.text = stringById;
        ((Graphic) component2.HIImage).color = this.EnableColor;
        ((Graphic) component2.CircleImage).color = this.EnableColor;
        item.transform.GetChild(2).GetComponent<Image>().sprite = this.spriteArray.GetSprite(14);
        eHeroState heroState = DataManager.Instance.GetHeroState(curHeroData.ID);
        if (heroState == eHeroState.None)
          return;
        if (heroState == eHeroState.IsFighting)
          component1.sprite = this.spriteArray.GetSprite(18);
        if (heroState == eHeroState.Captured)
          component1.sprite = this.spriteArray.GetSprite(19);
        if (heroState == eHeroState.Dead)
          component1.sprite = this.spriteArray.GetSprite(20);
        ((Component) component1).gameObject.SetActive(true);
      }
      else
      {
        if ((long) idx >= (long) this.fragmentHeroIDMax.Length)
          return;
        Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.fragmentHeroIDMax[(IntPtr) idx].HeroID);
        GUIManager.Instance.ChangeHeroItemImg(((Component) component2).transform, eHeroOrItem.Hero, this.fragmentHeroIDMax[(IntPtr) idx].HeroID, recordByKey.defaultStar, (byte) 0);
        this.SetItemFragments(item, this.fragmentHeroIDMax[(IntPtr) idx].HeroStone, this.fragmentHeroIDMax[(IntPtr) idx].MaxHeroStone);
        ((Graphic) component2.HIImage).color = this.EnableColor;
        ((Graphic) component2.CircleImage).color = this.EnableColor;
        item.transform.GetChild(2).GetComponent<Image>().sprite = this.spriteArray.GetSprite(14);
        item.transform.GetChild(9).GetComponent<Image>().sprite = this.spriteArray.GetSprite(12);
        byte heroType = recordByKey.HeroType;
        if (heroType >= (byte) 1 && (int) heroType <= this.heroTypeSprite.Length)
          item.transform.GetChild(11).GetComponent<Image>().sprite = this.heroTypeSprite[(int) heroType - 1];
        string stringById = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.HeroTitle);
        UIText component4 = item.transform.GetChild(12).GetComponent<UIText>();
        component4.font = GUIManager.Instance.GetTTFFont();
        component4.text = stringById;
      }
    }
    else
    {
      if ((long) this.fragmentHeroIDCount <= (long) idx)
        return;
      Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.fragmentHeroID[(IntPtr) idx].HeroID);
      byte heroType = recordByKey.HeroType;
      UIHIBtn component5 = item.transform.GetChild(1).GetComponent<UIHIBtn>();
      GUIManager.Instance.ChangeHeroItemImg(((Component) component5).transform, eHeroOrItem.Hero, recordByKey.HeroKey, recordByKey.defaultStar, (byte) 0);
      if (heroType >= (byte) 1 && (int) heroType <= this.heroTypeSprite.Length)
        item.transform.GetChild(11).GetComponent<Image>().sprite = this.heroTypeSprite[(int) heroType - 1];
      string stringById = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.HeroTitle);
      UIText component6 = item.transform.GetChild(12).GetComponent<UIText>();
      component6.font = GUIManager.Instance.GetTTFFont();
      component6.text = stringById;
      this.SetItemFragments(item, this.fragmentHeroID[(IntPtr) idx].HeroStone, this.fragmentHeroID[(IntPtr) idx].MaxHeroStone);
      item.transform.GetChild(2).GetComponent<Image>().sprite = this.spriteArray.GetSprite(15);
      ((Graphic) component5.HIImage).color = this.DisableColor;
      ((Graphic) component5.CircleImage).color = this.DisableColor;
    }
  }

  private void SetItemEquipments(GameObject item, byte Equip, ushort herID, byte enhance)
  {
    bool flag = false;
    for (int index = 0; index < 6; ++index)
    {
      int num1 = (int) Equip >> index & 1;
      Transform child1 = item.transform.GetChild(3 + index);
      Image component1 = child1.GetComponent<Image>();
      child1.gameObject.SetActive(true);
      Transform child2 = child1.transform.GetChild(0);
      UIHIBtn component2 = child2.GetComponent<UIHIBtn>();
      item.transform.GetChild(9).gameObject.SetActive(false);
      item.transform.GetChild(13).gameObject.SetActive(false);
      ushort num2 = DataManager.Instance.EnhanceTable.GetRecordByKey(herID).EnhanceNumber[((int) enhance - 1) * 6 + index];
      byte needLv = DataManager.Instance.EquipTable.GetRecordByKey(num2).NeedLv;
      if (num1 == 0)
      {
        if (DataManager.Instance.FindItemComposite(num2))
        {
          if ((int) DataManager.Instance.curHeroData[(uint) herID].Level >= (int) needLv)
          {
            component1.sprite = this.equipSprite[1];
            flag = true;
          }
          else
            component1.sprite = this.equipSprite[2];
        }
        else
          component1.sprite = this.equipSprite[0];
        ((Component) component2).gameObject.SetActive(false);
      }
      else
      {
        ((Component) component2).gameObject.SetActive(true);
        GUIManager.Instance.ChangeHeroItemImg(child2, eHeroOrItem.Item, num2, (byte) 0, (byte) 0);
      }
    }
    Image component = item.transform.GetChild(14).GetComponent<Image>();
    if (flag)
      ((Component) component).gameObject.SetActive(true);
    else
      ((Component) component).gameObject.SetActive(false);
    ((Component) item.transform.GetChild(10).GetComponent<Image>()).gameObject.SetActive(false);
    ((Component) item.transform.GetChild(9).GetComponent<Image>()).gameObject.SetActive(false);
  }

  private void SetItemEquipments(GameObject item, uint curHeroDataIdx, byte curHeroLevel)
  {
    bool flag1 = false;
    bool flag2 = false;
    bool flag3 = true;
    bool flag4 = false;
    curHeroDataIdx = (uint) Mathf.Clamp((float) curHeroDataIdx, 0.0f, (float) (this.EqipData.Count - 1));
    HeroEquip heroEquip = this.EqipData[(int) curHeroDataIdx];
    byte[] numArray1 = new byte[4]
    {
      (byte) 0,
      (byte) 0,
      (byte) 20,
      (byte) 40
    };
    ushort[] numArray2 = new ushort[4];
    uint key1 = DataManager.Instance.sortHeroData[(IntPtr) curHeroDataIdx];
    CurHeroData curHeroData;
    if (DataManager.Instance.curHeroData.ContainsKey(key1))
    {
      curHeroData = DataManager.Instance.curHeroData[key1];
      byte enhance = curHeroData.Enhance;
      if (enhance == (byte) 0 || enhance >= (byte) 8)
        flag3 = false;
      if (DataManager.Instance.queueBarData[11].bActive && (int) DataManager.Instance.RoleAttr.EnhanceEventHeroID == (int) curHeroData.ID)
        flag3 = false;
    }
    for (int index = 0; index < 6; ++index)
    {
      Transform child1 = item.transform.GetChild(3 + index);
      Image component1 = child1.GetComponent<Image>();
      child1.gameObject.SetActive(true);
      Transform child2 = child1.transform.GetChild(0);
      UIHIBtn component2 = child2.GetComponent<UIHIBtn>();
      item.transform.GetChild(9).gameObject.SetActive(false);
      item.transform.GetChild(13).gameObject.SetActive(false);
      if (!heroEquip.IsEquip[index])
      {
        if (heroEquip.IsFindItemComposite[index])
        {
          if ((int) curHeroLevel >= (int) heroEquip.EquipNeedLv[index])
          {
            flag1 = true;
            component1.sprite = this.equipSprite[1];
          }
          else
            component1.sprite = this.equipSprite[2];
        }
        else
          component1.sprite = this.equipSprite[0];
        ((Component) component2).gameObject.SetActive(false);
        flag3 = false;
        ((Behaviour) component1).enabled = true;
      }
      else
      {
        ((Component) component2).gameObject.SetActive(true);
        GUIManager.Instance.ChangeHeroItemImg(child2, eHeroOrItem.Item, heroEquip.EquipItemID[index], (byte) 0, (byte) 0);
        ((Behaviour) component1).enabled = false;
      }
    }
    Image component = item.transform.GetChild(14).GetComponent<Image>();
    uint key2 = DataManager.Instance.sortHeroData[(IntPtr) curHeroDataIdx];
    if (DataManager.Instance.curHeroData.ContainsKey(key2))
    {
      curHeroData = DataManager.Instance.curHeroData[key2];
      ushort curItemQuantity = DataManager.Instance.GetCurItemQuantity(DataManager.Instance.HeroTable.GetRecordByKey(curHeroData.ID).SoulStone, (byte) 0);
      int index = Mathf.Clamp((int) curHeroData.Star, 0, DataManager.Instance.Medal.Length - 1);
      bool flag5 = (int) DataManager.Instance.RoleAttr.StarUpEventHeroID == (int) curHeroData.ID && DataManager.Instance.queueBarData[12].bActive;
      if (curHeroData.Star < (byte) 5 && (int) curItemQuantity >= (int) DataManager.Instance.Medal[index] && !flag5)
        flag2 = true;
    }
    if (flag1 || flag2 || flag3 || flag4)
      ((Component) component).gameObject.SetActive(true);
    else
      ((Component) component).gameObject.SetActive(false);
    ((Component) item.transform.GetChild(10).GetComponent<Image>()).gameObject.SetActive(false);
    ((Component) item.transform.GetChild(9).GetComponent<Image>()).gameObject.SetActive(false);
  }

  private void SetItemFragments(GameObject item, ushort fragment, ushort maxFragment)
  {
    for (int index = 0; index < 6; ++index)
      item.transform.GetChild(3 + index).gameObject.SetActive(false);
    Image component1 = item.transform.GetChild(9).GetComponent<Image>();
    ((Component) component1).gameObject.SetActive(true);
    Image component2 = item.transform.GetChild(10).GetComponent<Image>();
    ((Component) component2).gameObject.SetActive(false);
    this.sb.Length = 0;
    this.sb.AppendFormat("{0}/{1}", (object) fragment, (object) maxFragment);
    Transform child = item.transform.GetChild(13);
    UIText component3 = child.GetComponent<UIText>();
    component3.font = GUIManager.Instance.GetTTFFont();
    child.gameObject.SetActive(true);
    Image component4 = item.transform.GetChild(14).GetComponent<Image>();
    if ((int) fragment < (int) maxFragment)
    {
      component3.text = this.sb.ToString();
      component1.sprite = this.spriteArray.GetSprite(13);
      this.bFlash = false;
      ((Component) component2).gameObject.SetActive(false);
      ((Component) component4).gameObject.SetActive(false);
    }
    else
    {
      component3.text = DataManager.Instance.mStringTable.GetStringByID(1U);
      component1.sprite = this.spriteArray.GetSprite(14);
      ((Component) component2).gameObject.SetActive(true);
      this.bFlash = true;
      if (this.bHaveRecruit)
        ((Component) component4).gameObject.SetActive(true);
      else
        ((Component) component4).gameObject.SetActive(false);
    }
  }

  private void Update()
  {
    if (this.bFlash)
    {
      this.flashTime += Time.deltaTime;
      if ((double) this.flashTime >= 0.05000000074505806)
      {
        this.flashCount += 0.1f;
        if ((double) this.flashCount >= 2.0)
          this.flashCount = 0.0f;
        float a = (double) this.flashCount <= 1.0 ? this.flashCount : 2f - this.flashCount;
        for (int index = 0; index < 16; ++index)
        {
          if ((UnityEngine.Object) this.flashImage[index] != (UnityEngine.Object) null)
            ((Graphic) this.flashImage[index]).color = new Color(1f, 1f, 1f, a);
        }
        this.flashTime = 0.0f;
      }
    }
    if (this.tabBtnFlashIndex < 3 && (UnityEngine.Object) this.tabBtnFlashImage[this.tabBtnFlashIndex] != (UnityEngine.Object) null)
    {
      this.tabBtnTime += Time.deltaTime;
      if ((double) this.tabBtnTime >= 0.05000000074505806)
      {
        this.tabBtnColorA += 0.05f;
        if ((double) this.tabBtnColorA >= 2.0)
          this.tabBtnColorA = 0.0f;
        ((Graphic) this.tabBtnFlashImage[this.tabBtnFlashIndex]).color = new Color(1f, 1f, 1f, (double) this.tabBtnColorA <= 1.0 ? this.tabBtnColorA : 2f - this.tabBtnColorA);
        this.tabBtnTime = 0.0f;
      }
    }
    if (!((Component) this.itemPage).gameObject.activeSelf || (int) this.itemTabIndex >= this.TabButtonA.Length)
      return;
    this.TabButtonA[(int) this.itemTabIndex].alpha = (double) this.tabBtnColorA <= 1.0 ? this.tabBtnColorA : 2f - this.tabBtnColorA;
  }

  private void SetPage(UIHeroList.e_HeroListPageTpye type)
  {
    this.PageType = type;
    if (this.fragmentHeroIDCount == 0 && this.PageType == UIHeroList.e_HeroListPageTpye.NoOwnedPage)
      ((Component) this.noRecruitmentText).gameObject.SetActive(true);
    else
      ((Component) this.noRecruitmentText).gameObject.SetActive(false);
    switch (type)
    {
      case UIHeroList.e_HeroListPageTpye.OwnedPage:
        if (!this.bInitScrollView)
          this.InitScrollView();
        this.ownedPageImage.sprite = this.spriteArray.GetSprite(8);
        this.noOwnedPageImage.sprite = !GUIManager.Instance.IsArabic ? this.spriteArray.GetSprite(10) : this.spriteArray.GetSprite(21);
        this.itemPageImage.sprite = this.spriteArray.GetSprite(17);
        this.scrollRect.StopMovement();
        this.scrollView.UpdateScrollRect();
        this.CheckExpItem();
        this.scrollView.gameObject.SetActive(true);
        ((Component) this.itemPage).gameObject.SetActive(false);
        break;
      case UIHeroList.e_HeroListPageTpye.NoOwnedPage:
        if (!this.bInitScrollView)
          this.InitScrollView();
        this.ownedPageImage.sprite = this.spriteArray.GetSprite(8);
        this.noOwnedPageImage.sprite = !GUIManager.Instance.IsArabic ? this.spriteArray.GetSprite(10) : this.spriteArray.GetSprite(21);
        this.itemPageImage.sprite = this.spriteArray.GetSprite(17);
        this.scrollRect.StopMovement();
        this.scrollView.UpdateScrollRect();
        this.ExpTf.gameObject.SetActive(false);
        if (this.fragmentHeroIDCount > 0)
          this.scrollView.gameObject.SetActive(true);
        ((Component) this.itemPage).gameObject.SetActive(false);
        break;
      default:
        this.ownedPageImage.sprite = this.spriteArray.GetSprite(8);
        this.noOwnedPageImage.sprite = !GUIManager.Instance.IsArabic ? this.spriteArray.GetSprite(10) : this.spriteArray.GetSprite(21);
        this.itemPageImage.sprite = this.spriteArray.GetSprite(17);
        this.ExpTf.gameObject.SetActive(false);
        this.scrollView.gameObject.SetActive(false);
        ((Component) this.itemPage).gameObject.SetActive(true);
        this.UpdateItemPage();
        break;
    }
    this.SetTabBtnColor(this.PageType);
  }

  private void SetTabBtnColor(UIHeroList.e_HeroListPageTpye type)
  {
    this.tabBtnColorA = 1f;
    this.tabBtnTime = 0.0f;
    for (int index = 0; index < 3; ++index)
      ((Behaviour) this.tabBtnFlashImage[index]).enabled = false;
    switch (type)
    {
      case UIHeroList.e_HeroListPageTpye.OwnedPage:
        this.tabBtnFlashIndex = 0;
        break;
      case UIHeroList.e_HeroListPageTpye.NoOwnedPage:
        this.tabBtnFlashIndex = 1;
        break;
      default:
        this.tabBtnFlashIndex = 2;
        break;
    }
    ((Behaviour) this.tabBtnFlashImage[this.tabBtnFlashIndex]).enabled = true;
    ((Graphic) this.tabBtnFlashImage[this.tabBtnFlashIndex]).color = new Color(1f, 1f, 1f, 1f);
  }

  public void Initialized()
  {
    for (int index = 0; index < 16; ++index)
    {
      Transform child = this.gameObject.transform.GetChild(3).GetChild(0).GetChild(index).GetChild(0).GetChild(10);
      this.flashImage[index] = child.GetComponent<Image>();
    }
    ((Component) this.scrollBlack[0]).gameObject.SetActive(false);
    ((Component) this.scrollBlack[1]).gameObject.SetActive(false);
    if (this.PageType == UIHeroList.e_HeroListPageTpye.OwnedPage)
    {
      this.SetPage(this.PageType);
      this.scrollView.SetContentSize((int) DataManager.Instance.CurHeroDataCount + this.fragmentHeroIDMaxCount);
    }
    else
    {
      if (this.fragmentHeroIDCount < 0)
        return;
      this.SetPage(this.PageType);
      if (GUIManager.Instance.m_UISynthesisID != (ushort) 0)
        GUIManager.Instance.OpenUISynthesis((int) GUIManager.Instance.m_UISynthesisID);
      this.scrollView.SetContentSize(this.fragmentHeroIDCount);
    }
  }

  public void UpDateRowItem(GameObject[] gameObjs, int[] indexs)
  {
    if ((UnityEngine.Object) gameObjs[0].transform.parent.parent == (UnityEngine.Object) this.scrollView.transform)
    {
      uint num = (uint) ((ulong) DataManager.Instance.CurHeroDataCount + (ulong) this.fragmentHeroIDMaxCount);
      int length = gameObjs.Length;
      for (int index = 0; index < length; ++index)
      {
        if (this.PageType != UIHeroList.e_HeroListPageTpye.OwnedPage || (long) indexs[index] < (long) num)
        {
          UIButton component = gameObjs[index].transform.GetChild(0).transform.GetComponent<UIButton>();
          component.m_BtnID1 = indexs[index] + 200;
          component.m_Handler = (IUIButtonClickHandler) this;
          this.SetItemByID(gameObjs[index].transform.GetChild(0).gameObject, (uint) indexs[index]);
          if (indexs[index] < this.m_TempNameText.Length)
            this.m_TempNameText[indexs[index]] = gameObjs[index].transform.GetChild(0).GetChild(12).GetComponent<UIText>();
          if (indexs[index] < this.m_TempNameText.Length)
            this.m_TempNumText[indexs[index]] = gameObjs[index].transform.GetChild(0).GetChild(12).GetComponent<UIText>();
          if (indexs[index] < this.m_TempHibtn.Length)
            this.m_TempHibtn[index] = gameObjs[index].transform.GetChild(0).GetChild(1).GetComponent<UIHIBtn>();
        }
      }
    }
    else if (!this.bInitItemView)
    {
      for (int index = 0; index < gameObjs.Length; ++index)
      {
        GUIManager.Instance.InitianHeroItemImg(gameObjs[index].transform.GetChild(0), eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
        gameObjs[index].AddComponent<uButtonScale>();
        RectTransform transform = gameObjs[index].transform as RectTransform;
        transform.pivot = new Vector2(0.5f, 0.5f);
        Vector2 anchoredPosition = transform.anchoredPosition;
        anchoredPosition.Set(anchoredPosition.x + 40f, anchoredPosition.y - 40f);
        transform.anchoredPosition = anchoredPosition;
        ((Component) transform).GetComponent<ScrollItem>().SoundIndex = (byte) 64;
        this.ItemHIBtn.Add(gameObjs[index].transform.GetChild(0).GetComponent<UIHIBtn>());
      }
    }
    else
    {
      ushort num1 = 0;
      switch (this.itemTabIndex)
      {
        case 0:
          num1 = DataManager.Instance.sortItemDataStart[5];
          break;
        case 1:
          num1 = DataManager.Instance.sortItemDataStart[3];
          break;
        case 2:
          num1 = DataManager.Instance.sortItemDataStart[2];
          break;
        case 3:
          num1 = DataManager.Instance.sortItemDataStart[4];
          break;
        case 4:
          num1 = DataManager.Instance.sortItemDataStart[0];
          break;
      }
      for (int index = 0; index < gameObjs.Length; ++index)
      {
        ushort num2 = DataManager.Instance.sortItemData[(int) num1 + indexs[index]];
        GUIManager.Instance.ChangeHeroItemImg(gameObjs[index].transform.GetChild(0), eHeroOrItem.Item, num2, (byte) 0, (byte) 0, (int) DataManager.Instance.GetCurItemQuantity(num2, (byte) 0));
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((UnityEngine.Object) gameObject.transform.parent.parent == (UnityEngine.Object) this.scrollView.transform)
    {
      if (this.PageType == UIHeroList.e_HeroListPageTpye.OwnedPage)
      {
        if (dataIndex < this.fragmentHeroIDMaxCount)
          this.OpenCheckBox(dataIndex);
        else
          menu.OpenMenu(EGUIWindow.UI_Hero_Info, dataIndex - this.fragmentHeroIDMaxCount, bCameraMode: true);
      }
      else
        GUIManager.Instance.OpenUISynthesis((int) DataManager.Instance.HeroTable.GetRecordByKey(this.fragmentHeroID[dataIndex].HeroID).SoulStone);
    }
    else
      GUIManager.Instance.m_ItemInfo.Show(EUIItemInfo.ItemList, gameObject.transform.GetChild(0).GetComponent<UIHIBtn>().HIID, (ushort) 0, (byte) 0);
  }

  private void InitOpenCheckBox()
  {
    this.checkPanel = this.gameObject.transform.GetChild(13);
    UIButton component1 = this.checkPanel.GetChild(7).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 98;
    UIButton component2 = this.checkPanel.GetChild(8).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 99;
    this.checkPanel.GetChild(8).GetComponent<UIButton>();
    GUIManager.Instance.InitianHeroItemImg(((Component) this.checkPanel.GetChild(5).GetComponent<UIHIBtn>()).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
    UIText component3 = this.checkPanel.GetChild(9).GetComponent<UIText>();
    component3.font = GUIManager.Instance.GetTTFFont();
    component3.text = DataManager.Instance.mStringTable.GetStringByID(3U);
    UIText component4 = this.checkPanel.GetChild(10).GetComponent<UIText>();
    component4.font = GUIManager.Instance.GetTTFFont();
    component4.text = DataManager.Instance.mStringTable.GetStringByID(4U);
    UIText component5 = this.checkPanel.GetChild(12).GetComponent<UIText>();
    component5.font = GUIManager.Instance.GetTTFFont();
    this.sb.Length = 0;
    this.sb.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(2U), (object) 5000);
    component5.text = this.sb.ToString();
  }

  private void OpenCheckBox(int dataIndex)
  {
    this.RecruitHeroID = this.fragmentHeroIDMax[dataIndex].HeroID;
    UIHIBtn component1 = this.checkPanel.GetChild(5).GetComponent<UIHIBtn>();
    Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.fragmentHeroIDMax[dataIndex].HeroID);
    GUIManager.Instance.ChangeHeroItemImg(((Component) component1).transform, eHeroOrItem.Hero, this.fragmentHeroIDMax[dataIndex].HeroID, recordByKey.defaultStar, (byte) 0, 1);
    UIText component2 = this.checkPanel.GetChild(11).GetComponent<UIText>();
    component2.font = GUIManager.Instance.GetTTFFont();
    component2.text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.HeroTitle);
    component2.resizeTextForBestFit = true;
    component2.resizeTextMinSize = 10;
    component2.resizeTextMaxSize = 22;
    this.checkPanel.gameObject.SetActive(true);
  }

  public void OnScroll(RectTransform rt)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    DataManager instance = DataManager.Instance;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (sender.m_BtnID1 >= 200)
    {
      int dataIndex = sender.m_BtnID1 - 200;
      if (this.PageType == UIHeroList.e_HeroListPageTpye.OwnedPage)
      {
        if (dataIndex < this.fragmentHeroIDMaxCount)
        {
          this.OpenCheckBox(dataIndex);
        }
        else
        {
          if (!(bool) (UnityEngine.Object) menu)
            return;
          menu.OpenMenu(EGUIWindow.UI_Hero_Info, dataIndex - this.fragmentHeroIDMaxCount, bCameraMode: true);
        }
      }
      else
        GUIManager.Instance.OpenUISynthesis((int) DataManager.Instance.HeroTable.GetRecordByKey(this.fragmentHeroID[dataIndex].HeroID).SoulStone);
    }
    else
    {
      switch (sender.m_BtnID1)
      {
        case 1:
          if (!((UnityEngine.Object) menu != (UnityEngine.Object) null))
            break;
          menu.CloseMenu();
          break;
        case 2:
          if (!((UnityEngine.Object) this.scrollView != (UnityEngine.Object) null) || this.scrollView.IsInitState())
            break;
          this.SaveUIState(this.PageType);
          this.PageType = UIHeroList.e_HeroListPageTpye.OwnedPage;
          this.SetPage(this.PageType);
          this.scrollView.SetContentSize((int) instance.CurHeroDataCount + this.fragmentHeroIDMaxCount);
          this.scrollView.SetContentPos(DataManager.Instance.OwnedPagePosY);
          this.scrollView.UpDateAllItem();
          break;
        case 3:
          if (!((UnityEngine.Object) this.scrollView != (UnityEngine.Object) null) || this.scrollView.IsInitState())
            break;
          this.SaveUIState(this.PageType);
          this.PageType = UIHeroList.e_HeroListPageTpye.NoOwnedPage;
          this.SetPage(this.PageType);
          this.scrollView.SetContentSize(this.fragmentHeroIDCount);
          this.scrollView.SetContentPos(DataManager.Instance.NoOwnedPagePosY);
          this.scrollView.UpDateAllItem();
          break;
        case 4:
          this.SaveUIState(this.PageType);
          if (!((UnityEngine.Object) this.scrollView != (UnityEngine.Object) null) || this.scrollView.IsInitState())
            break;
          this.SetPage(UIHeroList.e_HeroListPageTpye.ItemPage);
          break;
        case 97:
          if (!(bool) (UnityEngine.Object) menu)
            break;
          menu.OpenMenu(EGUIWindow.UI_BagFilter, 4);
          break;
        case 98:
          if (this.RecruitHeroID == (ushort) 0 || !instance.CheckHero3DMesh(this.RecruitHeroID))
          {
            GUIManager.Instance.AddHUDMessage(instance.mStringTable.GetStringByID(8350U), (ushort) byte.MaxValue);
            break;
          }
          MessagePacket messagePacket = new MessagePacket((ushort) 1024);
          messagePacket.Protocol = Protocol._MSG_REQUEST_HEROCREATE;
          messagePacket.AddSeqId();
          messagePacket.Add(this.RecruitHeroID);
          messagePacket.Send();
          GUIManager.Instance.ShowUILock(EUILock.HeroList);
          this.checkPanel.gameObject.SetActive(false);
          break;
        case 99:
          this.checkPanel.gameObject.SetActive(false);
          break;
        case 100:
          if (sender.m_BtnID2 == (int) this.itemTabIndex)
            break;
          this.TabButtonA[(int) this.itemTabIndex].alpha = 0.0f;
          ((Graphic) this.TabText[(int) this.itemTabIndex]).color = this.TabTextColor;
          this.itemTabIndex = (byte) sender.m_BtnID2;
          ((Graphic) this.TabText[(int) this.itemTabIndex]).color = Color.white;
          this.UpdateItemPage();
          break;
      }
    }
  }

  private void UpdateItemPage()
  {
    int size = 0;
    DataManager.Instance.SortCurItemData();
    if (!this.bInitItemView)
      ((Graphic) this.TabText[(int) this.itemTabIndex]).color = Color.white;
    switch (this.itemTabIndex)
    {
      case 0:
        size = (int) DataManager.Instance.sortItemDataCount[5] + (int) DataManager.Instance.sortItemDataCount[6];
        break;
      case 1:
        size = (int) DataManager.Instance.sortItemDataCount[3];
        break;
      case 2:
        size = (int) DataManager.Instance.sortItemDataCount[2];
        break;
      case 3:
        size = (int) DataManager.Instance.sortItemDataCount[4];
        break;
      case 4:
        size = (int) DataManager.Instance.sortItemDataCount[0] + (int) DataManager.Instance.sortItemDataCount[1];
        break;
    }
    if (!this.bInitItemView)
    {
      Transform child = ((Transform) this.itemPage).GetChild(1);
      this.itemView = child.GetComponent<ScrollView>();
      this.itemView.AddHender((IUpDateRowItem) this);
      this.bInitItemView = true;
      this.itemCont = child.GetChild(0).GetComponent<RectTransform>();
      this.itemScrollRect = child.GetComponent<CScrollRect>();
      ((Transform) this.itemPage).GetChild(1).GetComponent<RectTransform>().anchoredPosition = new Vector2(-23f, -77.54f);
      this.MessageTrans = ((Transform) this.itemPage).GetChild(8).GetComponent<RectTransform>();
      this.NoItemText = ((Transform) this.MessageTrans).GetChild(0).GetComponent<UIText>();
      this.NoItemText.font = GUIManager.Instance.GetTTFFont();
      this.NoItemText.text = DataManager.Instance.mStringTable.GetStringByID(744U);
      this.MessageTrans.sizeDelta = this.MessageTrans.sizeDelta with
      {
        x = this.NoItemText.preferredWidth + 165f
      };
    }
    this.itemScrollRect.StopMovement();
    this.itemCont.anchoredPosition = this.itemCont.anchoredPosition with
    {
      y = 0.0f
    };
    this.itemView.SetContentSize(size);
    this.itemView.UpDateAllItem();
    this.ItemHIBtn.Clear();
    if (size == 0)
      ((Component) this.MessageTrans).gameObject.SetActive(true);
    else
      ((Component) this.MessageTrans).gameObject.SetActive(false);
  }

  public override void OnClose()
  {
    if ((UnityEngine.Object) this.scrollView != (UnityEngine.Object) null && this.scrollView.CheckInitScroll())
      this.SaveUIState(this.PageType);
    GUIManager.Instance.HeroListSaved = (byte) (this.PageType + ((int) this.itemTabIndex << 2));
    GUIManager.Instance.m_UISynthesisID = (ushort) 0;
  }

  public void SaveUIState(UIHeroList.e_HeroListPageTpye type)
  {
    if (type == UIHeroList.e_HeroListPageTpye.OwnedPage && this.scrollView.GetItemsPos() != null && this.scrollView.GetItemsBtnID() != null)
    {
      DataManager.Instance.OwnedPagePosYArray = this.scrollView.GetItemsPos();
      DataManager.Instance.OwnedPageIDArray = this.scrollView.GetItemsBtnID();
      DataManager.Instance.OwnedPageScrollValue = this.scrollView.GetScrollViewIndexValue();
      DataManager.Instance.OwnedPagePosY = this.scrolCont.anchoredPosition.y;
      DataManager.Instance.OwnedPageContentHeight = this.scrolCont.sizeDelta.y;
    }
    if (type != UIHeroList.e_HeroListPageTpye.NoOwnedPage || this.scrollView.GetItemsPos() == null || this.scrollView.GetItemsBtnID() == null)
      return;
    DataManager.Instance.NoOwnedPagePosYArray = this.scrollView.GetItemsPos();
    DataManager.Instance.NoOwnedPageIDArray = this.scrollView.GetItemsBtnID();
    DataManager.Instance.NoOwnedPageScrollValue = this.scrollView.GetScrollViewIndexValue();
    DataManager.Instance.NoOwnedPagePosY = this.scrolCont.anchoredPosition.y;
    DataManager.Instance.NoOwnedPageContentYHeight = this.scrolCont.sizeDelta.y;
  }

  public void CheckExpItem()
  {
    DataManager.Instance.SortResourceFilterData();
    if (DataManager.Instance.sortItemDataCount[15] > (ushort) 0)
      this.ExpTf.gameObject.SetActive(true);
    else
      this.ExpTf.gameObject.SetActive(false);
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.noRecruitmentText != (UnityEngine.Object) null && ((Behaviour) this.noRecruitmentText).enabled)
    {
      ((Behaviour) this.noRecruitmentText).enabled = false;
      ((Behaviour) this.noRecruitmentText).enabled = true;
    }
    if (this.TabText != null)
    {
      for (int index = 0; index < this.TabText.Length; ++index)
      {
        if ((UnityEngine.Object) this.TabText[index] != (UnityEngine.Object) null && ((Behaviour) this.TabText[index]).enabled)
        {
          ((Behaviour) this.TabText[index]).enabled = false;
          ((Behaviour) this.TabText[index]).enabled = true;
        }
      }
    }
    if ((UnityEngine.Object) this.NoItemText != (UnityEngine.Object) null && ((Behaviour) this.NoItemText).enabled)
    {
      ((Behaviour) this.NoItemText).enabled = false;
      ((Behaviour) this.NoItemText).enabled = true;
    }
    if (this.m_TempNameText != null)
    {
      for (int index = 0; index < this.m_TempNameText.Length; ++index)
      {
        if ((UnityEngine.Object) this.m_TempNameText[index] != (UnityEngine.Object) null && ((Behaviour) this.m_TempNameText[index]).enabled)
        {
          ((Behaviour) this.m_TempNameText[index]).enabled = false;
          ((Behaviour) this.m_TempNameText[index]).enabled = true;
        }
      }
    }
    if (this.m_TempNumText != null)
    {
      for (int index = 0; index < this.m_TempNumText.Length; ++index)
      {
        if ((UnityEngine.Object) this.m_TempNumText[index] != (UnityEngine.Object) null && ((Behaviour) this.m_TempNumText[index]).enabled)
        {
          ((Behaviour) this.m_TempNumText[index]).enabled = false;
          ((Behaviour) this.m_TempNumText[index]).enabled = true;
        }
      }
    }
    for (int index = 0; index < this.ItemHIBtn.Count; ++index)
      this.ItemHIBtn[index].Refresh_FontTexture();
    if (this.m_TempHibtn == null)
      return;
    for (int index = 0; index < this.m_TempHibtn.Length; ++index)
    {
      if ((UnityEngine.Object) this.m_TempHibtn[index] != (UnityEngine.Object) null && ((Behaviour) this.m_TempHibtn[index]).enabled)
      {
        this.m_TempHibtn[index].Refresh_FontTexture();
        this.m_TempHibtn[index].Refresh_FontTexture();
      }
    }
  }

  public enum e_HeroListPageTpye
  {
    OwnedPage,
    NoOwnedPage,
    ItemPage,
  }

  public enum e_item
  {
    HeroIconBg,
    HeroIcon,
    NameImage,
    Equipment0,
    Equipment1,
    Equipment2,
    Equipment3,
    Equipment4,
    Equipment5,
    FragmentImage,
    FragmentFlash,
    TypeImg,
    Name,
    FragmentNum,
    ExclamationImage,
    IsFightingImg,
  }

  public enum e_CheckPanel
  {
    Image,
    Arrow0,
    Arrow1,
    Arrow2,
    Arrow3,
    UIHIBtn,
    NameImage,
    OKBtn,
    CancleBtn,
    OKText,
    CancelText,
    RecruitName,
    CheckMsg,
  }
}
