// Decompiled with JetBrains decompiler
// Type: UIMall_FG_Detail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIMall_FG_Detail : 
  GUIWindow,
  UILoadImageHander,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUILEBtnClickHandler
{
  private const int UnitCount = 11;
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
  private bool[] bFindScrollComp = new bool[11];
  private UnitComp_Mall_FG_Detail[] ScrollComp = new UnitComp_Mall_FG_Detail[11];
  private CString[] CountStr = new CString[11];
  private CString[] NameStr = new CString[11];
  private CString PriceStr;
  private int UIIndex = -1;
  private float UIPos;
  private UIText GatAllText;
  private bool bResourceRed;
  private float ResourceRedTime;
  private bool bClose;

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
    this.m_transform.GetChild(10).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(10).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 3;
    this.m_transform.GetChild(10).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(10).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(10).GetComponent<CustomImage>()).enabled = false;
    this.PackageName = this.m_transform.GetChild(4).GetComponent<UIText>();
    this.PackageName.font = this.tmpFont;
    this.PackageName.text = this.DM.mStringTable.GetStringByID(17509U);
    this.GatAllText = this.m_transform.GetChild(7).GetComponent<UIText>();
    this.GatAllText.font = this.tmpFont;
    this.GatAllText.text = this.DM.mStringTable.GetStringByID(838U);
    this.TimeStr = StringManager.Instance.SpawnString();
    this.TimeText = this.m_transform.GetChild(6).GetComponent<UIText>();
    this.TimeText.font = this.tmpFont;
    Transform child = this.m_transform.GetChild(9);
    this.GM.InitianHeroItemImg(child.GetChild(2), eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    child.GetChild(2).gameObject.AddComponent<IgnoreRaycast>();
    this.GM.InitLordEquipImg(child.GetChild(3), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    child.GetChild(3).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
    child.GetChild(4).GetComponent<UIText>().font = this.tmpFont;
    child.GetChild(5).GetComponent<UIText>().font = this.tmpFont;
    child.GetChild(6).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
    this.Scroll = this.m_transform.GetChild(8).GetComponent<ScrollPanel>();
    this.Scroll.IntiScrollPanel(458f, 0.0f, 0.0f, this.NowHeightList, 11, (IUpDateScrollPanel) this);
    this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
    UIButtonHint.scrollRect = this.cScrollRect;
    this.UpDateList();
    this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
    if (this.MM.FullGift_Deadline == 0L)
    {
      this.bClose = true;
    }
    else
    {
      if (this.MM.FullGift_TreasureItemCount != (byte) 0)
        return;
      this.MM.Send_TREASUREBACK_PRIZEINFO();
    }
  }

  public override void OnClose()
  {
    if (this.TimeStr != null)
      StringManager.Instance.DeSpawnString(this.TimeStr);
    for (int index = 0; index < 11; ++index)
    {
      if (this.CountStr[index] != null)
        StringManager.Instance.DeSpawnString(this.CountStr[index]);
      if (this.NameStr[index] != null)
        StringManager.Instance.DeSpawnString(this.NameStr[index]);
    }
    StringManager.Instance.DeSpawnString(this.PriceStr);
  }

  private void Update()
  {
    if (this.bClose)
    {
      this.bClose = false;
      if (!(bool) (Object) this.door)
        return;
      this.door.CloseMenu();
    }
    else
    {
      if (!((Object) this.TimeText != (Object) null))
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
  }

  private void UpdateTime()
  {
    if ((Object) this.TimeText == (Object) null)
      return;
    this.TimeStr.Length = 0;
    GameConstants.GetTimeString(this.TimeStr, this.MM.FullGift_Deadline > this.DM.ServerTime ? (uint) (this.MM.FullGift_Deadline - this.DM.ServerTime) : 0U);
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
        for (int index = 0; index < 11; ++index)
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
        if ((Object) this.GatAllText != (Object) null && ((Behaviour) this.GatAllText).enabled)
        {
          ((Behaviour) this.GatAllText).enabled = false;
          ((Behaviour) this.GatAllText).enabled = true;
        }
        if ((Object) this.PackageName != (Object) null && ((Behaviour) this.PackageName).enabled)
        {
          ((Behaviour) this.PackageName).enabled = false;
          ((Behaviour) this.PackageName).enabled = true;
        }
        if (!((Object) this.TimeText != (Object) null) || !((Behaviour) this.TimeText).enabled)
          break;
        ((Behaviour) this.TimeText).enabled = false;
        ((Behaviour) this.TimeText).enabled = true;
        break;
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        this.UpdateTime();
        break;
      case 1:
        if (this.MM.FullGift_Deadline != 0L || !(bool) (Object) this.door)
          break;
        this.door.CloseMenu();
        break;
      case 2:
        if (!(bool) (Object) this.door)
          break;
        if (this.MM.FullGift_Deadline == 0L)
        {
          this.door.CloseMenu();
          break;
        }
        this.MM.Send_TREASUREBACK_PRIZEINFO();
        break;
      case 3:
        this.UpDateList();
        break;
    }
  }

  private void UpDateList()
  {
    this.NowHeightList.Clear();
    for (int index = 0; index < (int) this.MM.FullGift_TreasureItemCount; ++index)
    {
      if (this.MM.FullGift_TreasureItem[index].ItemID != (ushort) 0)
        this.NowHeightList.Add(55f);
    }
    this.Scroll.AddNewDataHeight(this.NowHeightList);
    if (this.UIIndex != -1)
      this.Scroll.GoTo(this.UIIndex, this.UIPos);
    this.UpdateTime();
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelObjectIdx >= 11)
      return;
    Vector2 zero = Vector2.zero;
    if (!this.bFindScrollComp[panelObjectIdx])
    {
      this.bFindScrollComp[panelObjectIdx] = true;
      ((Behaviour) item.transform.GetChild(1).GetComponent<Image>()).enabled = false;
      this.ScrollComp[panelObjectIdx].HIBtn = item.transform.GetChild(2).GetComponent<UIHIBtn>();
      this.ScrollComp[panelObjectIdx].HIBtn.m_Handler = (IUIHIBtnClickHandler) this;
      this.ScrollComp[panelObjectIdx].Hint = item.transform.GetChild(2).GetComponent<UIButtonHint>();
      this.ScrollComp[panelObjectIdx].LEBtn = item.transform.GetChild(3).GetComponent<UILEBtn>();
      this.ScrollComp[panelObjectIdx].LEBtn.m_Handler = (IUILEBtnClickHandler) this;
      this.ScrollComp[panelObjectIdx].ItemName = item.transform.GetChild(4).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].ItemCountText = item.transform.GetChild(5).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].LineImage = item.transform.GetChild(0).GetComponent<Image>();
      this.ScrollComp[panelObjectIdx].Btn3 = item.transform.GetChild(6).GetComponent<UIButton>();
      this.ScrollComp[panelObjectIdx].Hint3 = item.transform.GetChild(6).GetComponent<UIButtonHint>();
      this.ScrollComp[panelObjectIdx].Hint3.m_Handler = (MonoBehaviour) this;
      this.ScrollComp[panelObjectIdx].Hint3.DelayTime = 0.2f;
      this.CountStr[panelObjectIdx] = StringManager.Instance.SpawnString();
      this.NameStr[panelObjectIdx] = StringManager.Instance.SpawnString(150);
      if (this.GM.IsArabic)
        this.ScrollComp[panelObjectIdx].ItemCountText.AdjuestUI();
    }
    if (dataIdx < 0 || dataIdx >= (int) this.MM.FullGift_TreasureItemCount)
      return;
    this.ScrollComp[panelObjectIdx].DataIndex = -1;
    ushort itemId = this.MM.FullGift_TreasureItem[dataIdx].ItemID;
    uint num = (uint) this.MM.FullGift_TreasureItem[dataIdx].Num;
    byte itemRank = this.MM.FullGift_TreasureItem[dataIdx].ItemRank;
    Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(itemId);
    byte equipKind = recordByKey.EquipKind;
    this.ScrollComp[panelObjectIdx].Hint3.Parm1 = itemId;
    this.ScrollComp[panelObjectIdx].Hint3.Parm2 = itemRank;
    bool flag = this.GM.IsLeadItem(equipKind);
    if (flag)
      GUIManager.Instance.ChangeLordEquipImg(((Component) this.ScrollComp[panelObjectIdx].LEBtn).transform, itemId, itemRank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    else
      GUIManager.Instance.ChangeHeroItemImg(((Component) this.ScrollComp[panelObjectIdx].HIBtn).transform, eHeroOrItem.Item, itemId, (byte) 0, (byte) 0);
    ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(flag);
    ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(!flag);
    if (flag || !this.MM.CheckCanOpenDetail(itemId))
      this.ScrollComp[panelObjectIdx].Hint3.enabled = true;
    else
      this.ScrollComp[panelObjectIdx].Hint3.enabled = false;
    ((Component) this.ScrollComp[panelObjectIdx].Btn3).gameObject.SetActive(this.ScrollComp[panelObjectIdx].Hint3.enabled);
    this.NameStr[panelObjectIdx].Length = 0;
    this.NameStr[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipName));
    this.NameStr[panelObjectIdx].AppendFormat("{0}");
    this.ScrollComp[panelObjectIdx].ItemName.text = this.NameStr[panelObjectIdx].ToString();
    ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = this.MM.GetItemRankColor(itemRank);
    this.ScrollComp[panelObjectIdx].ItemName.SetAllDirty();
    this.ScrollComp[panelObjectIdx].ItemName.cachedTextGenerator.Invalidate();
    this.CountStr[panelObjectIdx].Length = 0;
    StringManager.IntToStr(this.CountStr[panelObjectIdx], (long) num, bNumber: true);
    this.ScrollComp[panelObjectIdx].ItemCountText.text = this.CountStr[panelObjectIdx].ToString();
    this.ScrollComp[panelObjectIdx].ItemCountText.SetAllDirty();
    this.ScrollComp[panelObjectIdx].ItemCountText.cachedTextGenerator.Invalidate();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    if (dataIndex < 0 || dataIndex >= (int) this.MM.FullGift_TreasureItemCount)
      return;
    ushort itemId = this.MM.FullGift_TreasureItem[dataIndex].ItemID;
    if (!this.MM.CheckCanOpenDetail(itemId) || !this.MM.OpenDetail(itemId))
      return;
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 1 || sender.m_BtnID2 != 3 || !(bool) (Object) this.door)
      return;
    this.door.CloseMenu();
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

  private void SavePos()
  {
    this.UIIndex = this.Scroll.GetTopIdx();
    this.UIPos = this.cScrollRect.content.anchoredPosition.y;
  }
}
