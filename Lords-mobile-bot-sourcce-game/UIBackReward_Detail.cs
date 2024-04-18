// Decompiled with JetBrains decompiler
// Type: UIBackReward_Detail
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIBackReward_Detail : 
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
  private ComboBox tmpData;
  private UIText PackageName;
  private CScrollRect cScrollRect;
  private ScrollPanel Scroll;
  private List<float> NowHeightList = new List<float>();
  private byte ItemCount;
  private uint Point;
  private int AddCount;
  private bool[] bFindScrollComp = new bool[9];
  private UnitComp_BackReward_Detail[] ScrollComp = new UnitComp_BackReward_Detail[9];
  private CString[] CountStr = new CString[9];
  private CString[] NameStr = new CString[9];
  private Color ItemNameCrystalColor = new Color(1f, 0.9333f, 0.6196f);
  private Color ItemCountOriginColor = new Color(1f, 1f, 1f);
  private Color ItemCountOutLineOriginColor = new Color(0.3725f, 0.0862f, 0.0f);
  private Color ItemCountCrystalColor = new Color(0.2f, 0.921f, 0.404f);
  private Color ItemCountCrystalOutLineColor = new Color(0.1882f, 0.0862f, 0.06274f);
  private Vector2 OriginImagePos;
  private Vector2 OriginCountPos;
  private UIText BuyText;
  private UIText GatAllText;
  private UIText OnceText;

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
    this.m_transform.GetChild(14).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.m_transform.GetChild(14).GetChild(0).GetComponent<UIButton>().m_BtnID2 = 3;
    this.m_transform.GetChild(14).GetChild(0).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    this.m_transform.GetChild(14).GetComponent<CustomImage>().hander = (UILoadImageHander) this;
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(14).GetComponent<CustomImage>()).enabled = false;
    Transform child1 = this.m_transform.GetChild(13);
    child1.GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.BuyText = child1.GetChild(0).GetComponent<UIText>();
    this.BuyText.font = this.tmpFont;
    this.BuyText.text = this.DM.mStringTable.GetStringByID(10169U);
    this.PackageName = this.m_transform.GetChild(7).GetComponent<UIText>();
    this.PackageName.font = this.tmpFont;
    this.PackageName.text = this.DM.mStringTable.GetStringByID(10166U);
    this.GatAllText = this.m_transform.GetChild(10).GetComponent<UIText>();
    this.GatAllText.font = this.tmpFont;
    this.GatAllText.text = this.DM.mStringTable.GetStringByID(838U);
    this.OnceText = this.m_transform.GetChild(9).GetComponent<UIText>();
    this.OnceText.font = this.tmpFont;
    this.OnceText.text = this.DM.mStringTable.GetStringByID(10167U);
    Transform child2 = this.m_transform.GetChild(12);
    this.GM.InitianHeroItemImg(child2.GetChild(2), eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
    child2.GetChild(2).gameObject.AddComponent<IgnoreRaycast>();
    this.GM.InitLordEquipImg(child2.GetChild(3), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    child2.GetChild(3).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
    child2.GetChild(4).GetComponent<UIText>().font = this.tmpFont;
    child2.GetChild(5).GetComponent<UIText>().font = this.tmpFont;
    child2.GetChild(6).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
    this.Scroll = this.m_transform.GetChild(11).GetComponent<ScrollPanel>();
    this.Scroll.IntiScrollPanel(358f, 0.0f, 0.0f, this.NowHeightList, 9, (IUpDateScrollPanel) this);
    this.cScrollRect = this.Scroll.GetComponent<CScrollRect>();
    UIButtonHint.scrollRect = this.cScrollRect;
    this.UpDateList();
    this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
  }

  public override void OnClose()
  {
    for (int index = 0; index < 9; ++index)
    {
      if (this.CountStr[index] != null)
        StringManager.Instance.DeSpawnString(this.CountStr[index]);
      if (this.NameStr[index] != null)
        StringManager.Instance.DeSpawnString(this.NameStr[index]);
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        if (this.MM.BackRewardComboBoxID != (ushort) 0 || !(bool) (Object) this.door)
          break;
        this.door.CloseMenu();
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
        if (!((Object) this.PackageName != (Object) null) || !((Behaviour) this.PackageName).enabled)
          break;
        ((Behaviour) this.PackageName).enabled = false;
        ((Behaviour) this.PackageName).enabled = true;
        break;
    }
  }

  private void UpDateList()
  {
    this.tmpData = this.DM.ComboBoxTable.GetRecordByKey(this.MM.BackRewardComboBoxID);
    this.Point = 0U;
    this.MM.BackRewardItemDataCount = (byte) 0;
    for (int index = 0; index < this.tmpData.ItemData.Length; ++index)
    {
      if (this.tmpData.ItemData[index].ItemID != (ushort) 0)
      {
        Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.tmpData.ItemData[index].ItemID);
        if (recordByKey.EquipKind == (byte) 11 && recordByKey.PropertiesInfo[0].Propertieskey == (ushort) 6)
          this.Point += (uint) recordByKey.PropertiesInfo[1].Propertieskey * (uint) recordByKey.PropertiesInfo[1].PropertiesValue * (uint) this.tmpData.ItemData[index].ItemCount;
        else if ((int) this.MM.BackRewardItemDataCount < this.MM.BackRewardItemData.Length)
        {
          this.MM.BackRewardItemData[(int) this.MM.BackRewardItemDataCount] = (byte) index;
          ++this.MM.BackRewardItemDataCount;
        }
      }
    }
    this.AddCount = this.Point <= 0U ? 0 : 1;
    this.ItemCount = (byte) 0;
    this.NowHeightList.Clear();
    if (this.Point > 0U)
    {
      this.NowHeightList.Add(55f);
      ++this.ItemCount;
    }
    for (int index = 0; index < (int) this.MM.BackRewardItemDataCount; ++index)
      this.NowHeightList.Add(55f);
    this.ItemCount += this.MM.BackRewardItemDataCount;
    this.Scroll.AddNewDataHeight(this.NowHeightList);
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
    ushort num1 = 1;
    byte num2 = 0;
    uint x;
    if (this.Point > 0U && dataIdx == 0)
    {
      x = this.Point;
      this.ScrollComp[panelObjectIdx].DataIndex = -1;
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
    else
    {
      this.ScrollComp[panelObjectIdx].DataIndex = dataIdx - this.AddCount;
      int index = (int) this.MM.BackRewardItemData[dataIdx - this.AddCount];
      num1 = this.tmpData.ItemData[index].ItemID;
      x = (uint) this.tmpData.ItemData[index].ItemCount;
      num2 = this.tmpData.ItemData[index].Rank;
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
    if (dataIdx >= this.AddCount)
    {
      Equip recordByKey = DataManager.Instance.EquipTable.GetRecordByKey(num1);
      byte equipKind = recordByKey.EquipKind;
      this.ScrollComp[panelObjectIdx].Hint3.Parm1 = num1;
      this.ScrollComp[panelObjectIdx].Hint3.Parm2 = num2;
      bool flag = this.GM.IsLeadItem(equipKind);
      if (flag)
        GUIManager.Instance.ChangeLordEquipImg(((Component) this.ScrollComp[panelObjectIdx].LEBtn).transform, num1, num2, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      else
        GUIManager.Instance.ChangeHeroItemImg(((Component) this.ScrollComp[panelObjectIdx].HIBtn).transform, eHeroOrItem.Item, num1, (byte) 0, (byte) 0);
      ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(flag);
      ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(!flag);
      if (flag || !this.MM.CheckCanOpenDetail(num1))
        this.ScrollComp[panelObjectIdx].Hint3.enabled = true;
      else
        this.ScrollComp[panelObjectIdx].Hint3.enabled = false;
      ((Component) this.ScrollComp[panelObjectIdx].Btn3).gameObject.SetActive(this.ScrollComp[panelObjectIdx].Hint3.enabled);
      this.NameStr[panelObjectIdx].Length = 0;
      this.NameStr[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipName));
      this.NameStr[panelObjectIdx].AppendFormat("{0}");
      this.ScrollComp[panelObjectIdx].ItemName.text = this.NameStr[panelObjectIdx].ToString();
      ((Graphic) this.ScrollComp[panelObjectIdx].ItemName).color = this.MM.GetItemRankColor(num2);
      this.ScrollComp[panelObjectIdx].ItemName.SetAllDirty();
      this.ScrollComp[panelObjectIdx].ItemName.cachedTextGenerator.Invalidate();
    }
    this.CountStr[panelObjectIdx].Length = 0;
    StringManager.IntToStr(this.CountStr[panelObjectIdx], (long) x, bNumber: true);
    this.ScrollComp[panelObjectIdx].ItemCountText.text = this.CountStr[panelObjectIdx].ToString();
    this.ScrollComp[panelObjectIdx].ItemCountText.SetAllDirty();
    this.ScrollComp[panelObjectIdx].ItemCountText.cachedTextGenerator.Invalidate();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    int index = dataIndex - this.AddCount;
    if (index < 0 || index >= (int) this.MM.BackRewardItemDataCount)
      return;
    ushort itemId = this.tmpData.ItemData[(int) this.MM.BackRewardItemData[index]].ItemID;
    if (!this.MM.CheckCanOpenDetail(itemId) || !this.MM.OpenDetail(itemId))
      return;
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 1)
      return;
    if (sender.m_BtnID2 == 1)
      this.MM.Send_PUSHBACK_PRIZE();
    if (sender.m_BtnID2 != 3 || !(bool) (Object) this.door)
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
}
