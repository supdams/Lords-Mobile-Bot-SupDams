// Decompiled with JetBrains decompiler
// Type: UIPetBag
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIPetBag : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonScaleHandler2,
  IUIButtonClickHandler,
  IUIHIBtnUpDownHandler
{
  private const byte ItemCountHSize = 8;
  private ScrollPanel PetScroll;
  private RectTransform PetScrollRect;
  private List<float> ScrollHeight = new List<float>();
  private UIHIBtn[] ItemArray;
  private UIHIBtn SelBtn;
  private UIText MsgText;
  private UIText TitleText;
  private GameObject NoItemObj;
  private UIPetBag.ClickType CurTag;
  private ushort Start;
  private ushort Count;
  private Color TageColor;
  private byte bInit = 2;
  private UIPetBag._Tag[] Tag;
  private float tabBtnColorA = 1f;
  private float tabBtnTime;

  void IUIButtonClickHandler.OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 4)
      (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu();
    else
      this.UpdateTag((UIPetBag.ClickType) sender.m_BtnID1);
  }

  void IUIHIBtnUpDownHandler.OnHIButtonDown(UIHIBtn sender) => this.SelBtn = sender;

  void IUIHIBtnUpDownHandler.OnHIButtonUp(UIHIBtn sender)
  {
  }

  void IUIButtonScaleHandler2.OnFinish()
  {
    if (!((Object) this.SelBtn != (Object) null))
      return;
    GUIManager.Instance.m_ItemInfo.Show(EUIItemInfo.ItemList, this.SelBtn.HIID, (ushort) 0, (byte) 0);
  }

  void IUpDateScrollPanel.UpDateRowItem(
    GameObject item,
    int dataIdx,
    int panelObjectIdx,
    int panelId)
  {
    int num1 = dataIdx * 8;
    int num2 = panelObjectIdx * 8;
    ushort[] sortPetItemData = PetManager.Instance.sortPetItemData;
    for (int index = 0; index < 8; ++index)
    {
      if ((Object) this.ItemArray[num2 + index] == (Object) null)
      {
        this.ItemArray[num2 + index] = item.transform.GetChild(index).GetComponent<UIHIBtn>();
        this.ItemArray[num2 + index].m_UpDownHandler = (IUIHIBtnUpDownHandler) this;
        ((Component) this.ItemArray[num2 + index]).gameObject.AddComponent<EventPatchery>().SetEvnetObj(this.PetScroll.GetComponent<CScrollRect>());
        ((Component) this.ItemArray[num2 + index]).GetComponent<uButtonScale>().m_Handler = (IUIButtonScaleHandler2) this;
      }
      if (num1 + index < (int) this.Count)
      {
        ((Component) this.ItemArray[num2 + index]).gameObject.SetActive(true);
        ushort itemId = PetManager.Instance.GetItemData((int) sortPetItemData[(int) this.Start + num1 + index]).ItemID;
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.ItemArray[num2 + index]).transform, eHeroOrItem.Item, itemId, (byte) 0, (byte) 0, (int) DataManager.Instance.GetCurItemQuantity(itemId, (byte) 0));
      }
      else
        ((Component) this.ItemArray[num2 + index]).gameObject.SetActive(false);
    }
  }

  void IUpDateScrollPanel.ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnOpen(int arg1, int arg2)
  {
    GUIManager instance = GUIManager.Instance;
    Font ttfFont = instance.GetTTFFont();
    Image component1 = this.transform.GetChild(8).GetComponent<Image>();
    StringTable mStringTable = DataManager.Instance.mStringTable;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if ((bool) (Object) menu)
    {
      if (instance.bOpenOnIPhoneX)
      {
        ((Behaviour) component1).enabled = false;
      }
      else
      {
        component1.sprite = menu.LoadSprite("UI_main_close_base");
        ((MaskableGraphic) component1).material = menu.LoadMaterial();
      }
      UIButton component2 = this.transform.GetChild(8).GetChild(0).GetComponent<UIButton>();
      component2.m_BtnID1 = 4;
      component2.m_Handler = (IUIButtonClickHandler) this;
      Image image = component2.image;
      image.sprite = menu.LoadSprite("UI_main_close");
      ((MaskableGraphic) image).material = menu.LoadMaterial();
    }
    this.TitleText = this.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.TitleText.font = ttfFont;
    this.TitleText.text = mStringTable.GetStringByID(16079U);
    this.Tag = new UIPetBag._Tag[4];
    for (int index = 0; index < this.Tag.Length; ++index)
    {
      UIButton component3 = this.transform.GetChild(3 + index).GetComponent<UIButton>();
      component3.m_BtnID1 = 0 + index;
      component3.m_Handler = (IUIButtonClickHandler) this;
      this.Tag[index].Alpha = this.transform.GetChild(3 + index).GetChild(0).GetComponent<CanvasGroup>();
      this.Tag[index].Caption = this.transform.GetChild(3 + index).GetChild(1).GetComponent<UIText>();
      this.Tag[index].Caption.font = ttfFont;
    }
    this.TageColor = ((Graphic) this.Tag[0].Caption).color;
    this.CurTag = (UIPetBag.ClickType) PetManager.Instance.UISave[0];
    if (this.CurTag > UIPetBag.ClickType.Tage4)
      this.CurTag = UIPetBag.ClickType.Tage4;
    this.Tag[0].Caption.text = mStringTable.GetStringByID(253U);
    this.Tag[1].Caption.text = mStringTable.GetStringByID(14654U);
    this.Tag[2].Caption.text = mStringTable.GetStringByID(879U);
    this.Tag[3].Caption.text = mStringTable.GetStringByID(16050U);
    this.NoItemObj = this.transform.GetChild(7).gameObject;
    this.MsgText = this.transform.GetChild(7).GetChild(0).GetComponent<UIText>();
    this.MsgText.font = ttfFont;
    this.MsgText.text = mStringTable.GetStringByID(744U);
    int childCount = this.transform.GetChild(2).childCount;
    for (int index = 0; index < childCount; ++index)
    {
      instance.InitianHeroItemImg(this.transform.GetChild(2).GetChild(index), eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false, bScaleBtn: true);
      Object.DestroyImmediate((Object) this.transform.GetChild(2).GetChild(index).GetComponent<IgnoreRaycast>(), false);
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
  }

  public override void OnClose()
  {
    if (!((Object) this.PetScrollRect != (Object) null))
      return;
    PetManager instance = PetManager.Instance;
    instance.UISave[0] = (byte) this.CurTag;
    instance.UISave[1] = (byte) this.PetScroll.GetBeginIdx();
    GameConstants.GetBytes(this.PetScrollRect.anchoredPosition.y, instance.UISave, 2);
  }

  private void UpdateTag(UIPetBag.ClickType tag, bool bForce = false)
  {
    if (!bForce && tag == this.CurTag)
      return;
    PetManager.Instance.SortPetItemData();
    if (tag != this.CurTag)
    {
      this.Tag[(int) this.CurTag].Alpha.alpha = 0.0f;
      ((Graphic) this.Tag[(int) this.CurTag].Caption).color = this.TageColor;
      this.tabBtnColorA = 1f;
      this.tabBtnTime = 0.0f;
    }
    this.CurTag = tag;
    ((Graphic) this.Tag[(int) this.CurTag].Caption).color = Color.white;
    if (this.bInit > (byte) 0)
      return;
    this.Count = (ushort) 0;
    if (this.CurTag == UIPetBag.ClickType.Tage1)
    {
      this.Start = DataManager.Instance.sortItemDataStart[5];
      this.Count = DataManager.Instance.sortItemDataCount[5];
    }
    else if (this.CurTag == UIPetBag.ClickType.Tage2)
    {
      this.Start = DataManager.Instance.sortItemDataStart[0];
      this.Count = DataManager.Instance.sortItemDataCount[0];
    }
    else if (this.CurTag == UIPetBag.ClickType.Tage3)
    {
      this.Start = DataManager.Instance.sortItemDataStart[1];
      this.Count = DataManager.Instance.sortItemDataCount[1];
    }
    if (this.CurTag == UIPetBag.ClickType.Tage4)
    {
      this.Start = DataManager.Instance.sortItemDataStart[28];
      this.Count = DataManager.Instance.sortItemDataCount[28];
    }
    if (this.Count > (ushort) 0)
    {
      ushort count = this.Count;
      ushort num = (ushort) (((int) count >> 3) + (((int) count & 7) <= 0 ? 0 : 1));
      this.ScrollHeight.Clear();
      for (int index = 0; index < (int) num; ++index)
        this.ScrollHeight.Add(80f);
      this.PetScroll.gameObject.SetActive(true);
      this.NoItemObj.SetActive(false);
      if (bForce)
      {
        Vector2 anchoredPosition = this.PetScrollRect.anchoredPosition;
        int beginIdx = this.PetScroll.GetBeginIdx();
        this.PetScroll.AddNewDataHeight(this.ScrollHeight);
        this.PetScroll.GoTo(beginIdx, anchoredPosition.y);
      }
      else
        this.PetScroll.AddNewDataHeight(this.ScrollHeight);
    }
    else
    {
      this.PetScroll.gameObject.SetActive(false);
      this.NoItemObj.SetActive(true);
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (this.bInit > (byte) 0)
      return;
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh_Item:
        this.UpdateTag(this.CurTag, true);
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        for (int index = 0; index < this.ItemArray.Length; ++index)
        {
          if ((Object) this.ItemArray[index] != (Object) null)
            this.ItemArray[index].Refresh_FontTexture();
        }
        for (int index = 0; index < this.Tag.Length; ++index)
        {
          ((Behaviour) this.Tag[index].Caption).enabled = false;
          ((Behaviour) this.Tag[index].Caption).enabled = true;
        }
        ((Behaviour) this.MsgText).enabled = false;
        ((Behaviour) this.MsgText).enabled = true;
        ((Behaviour) this.TitleText).enabled = false;
        ((Behaviour) this.TitleText).enabled = true;
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (PetManager.Instance.PetDataCount != (ushort) 0)
      return;
    StringTable mStringTable = DataManager.Instance.mStringTable;
    GUIManager.Instance.OpenMessageBox(mStringTable.GetStringByID(17138U), mStringTable.GetStringByID(17139U), mStringTable.GetStringByID(3968U), (GUIWindow) this, 22, (int) byte.MaxValue, true, BackExit: true);
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || arg2 != (int) byte.MaxValue)
      return;
    GUIManager.Instance.BuildingData.ManorGuild((ushort) arg1);
    (GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door).CloseMenu(true);
  }

  public override void UpdateTime(bool bOnSecond)
  {
    if (this.bInit > (byte) 0)
    {
      --this.bInit;
      if (this.bInit == (byte) 0)
      {
        this.ItemArray = new UIHIBtn[64];
        this.PetScroll = this.transform.GetChild(1).GetComponent<ScrollPanel>();
        this.PetScroll.IntiScrollPanel(465.3f, 3f, 9f, this.ScrollHeight, 8, (IUpDateScrollPanel) this);
        this.PetScrollRect = this.PetScroll.transform.GetChild(0).GetComponent<RectTransform>();
        this.UpdateTag(this.CurTag, true);
        if (this.PetScroll.gameObject.activeSelf)
          this.PetScroll.GoTo((int) PetManager.Instance.UISave[1], (this.PetScrollRect.anchoredPosition with
          {
            y = GameConstants.ConvertBytesToFloat(PetManager.Instance.UISave, 2)
          }).y);
        for (int index = 0; index < this.Tag.Length; ++index)
        {
          ((Behaviour) this.Tag[index].Caption).enabled = false;
          ((Behaviour) this.Tag[index].Caption).enabled = true;
        }
        ((Behaviour) this.MsgText).enabled = false;
        ((Behaviour) this.MsgText).enabled = true;
        ((Behaviour) this.TitleText).enabled = false;
        ((Behaviour) this.TitleText).enabled = true;
      }
    }
    this.tabBtnTime += Time.deltaTime;
    if ((double) this.tabBtnTime < 0.05000000074505806)
      return;
    this.tabBtnColorA += 0.05f;
    if ((double) this.tabBtnColorA >= 2.0)
      this.tabBtnColorA = 0.0f;
    this.Tag[(int) this.CurTag].Alpha.alpha = (double) this.tabBtnColorA <= 1.0 ? this.tabBtnColorA : 2f - this.tabBtnColorA;
    this.tabBtnTime = 0.0f;
  }

  private enum UIControl
  {
    Background,
    ItemView,
    Item,
    Tage1,
    Tage2,
    Tage3,
    Tage4,
    Message,
    Exit,
  }

  private enum ClickType
  {
    Tage1,
    Tage2,
    Tage3,
    Tage4,
    Exit,
  }

  private struct _Tag
  {
    public CanvasGroup Alpha;
    public UIText Caption;
  }
}
