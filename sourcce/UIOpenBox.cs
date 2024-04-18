// Decompiled with JetBrains decompiler
// Type: UIOpenBox
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIOpenBox : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler,
  IUILEBtnClickHandler
{
  private const int UnitCount = 9;
  private const int FBItemCount = 4;
  private Transform m_transform;
  private DataManager DM;
  private GUIManager GM;
  private Font tmpFont;
  private UIText TitleNameText;
  private UIText GetAllText;
  private UIText GetAllText2;
  private Color GatAllColor;
  private Color GatOneColor = new Color(1f, 1f, 0.0f);
  private GameObject TitleImage1;
  private GameObject TitleImage2;
  private GameObject ForgeBtn;
  private Image BackImage;
  private Image RTImage1;
  private Image RTImage2;
  private ScrollPanel Scroll;
  private List<float> NowHeightList = new List<float>();
  private GiftBox tmpGB;
  private LotteryBox tmpLB;
  private ComboBox tmpCB;
  private Equip tmpEquip;
  private byte OpenKind;
  private byte BeginRank;
  private byte EndRank;
  private int ItemCount;
  private ushort SetIndex;
  private ushort OpenID;
  private ushort BoxID;
  private bool[] bFindScrollComp = new bool[9];
  private UnitComp_OpenBox[] ScrollComp = new UnitComp_OpenBox[9];
  private CString[] PriceStr = new CString[9];
  private CString[] NameStr = new CString[9];
  private CString[] RankStr = new CString[9];
  private CString TitleStr;
  private GameObject FBGO;
  private UIText FBTitleText;
  private GameObject[] FBItemGO = new GameObject[4];
  private UIHIBtn[] FBHIBtn = new UIHIBtn[4];
  private UILEBtn[] FBLEBtn = new UILEBtn[4];
  private UIText[] FBCountText = new UIText[4];
  private CString[] FBCountStr = new CString[4];
  private List<OpenStruct> OpenData = new List<OpenStruct>();

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.m_transform = this.transform;
    this.tmpFont = this.GM.GetTTFFont();
    this.m_transform.GetChild(12).GetChild(0).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    if (this.GM.bOpenOnIPhoneX)
      ((Behaviour) this.m_transform.GetChild(12).GetComponent<Image>()).enabled = false;
    this.BackImage = this.m_transform.GetChild(1).GetComponent<Image>();
    this.m_transform.GetChild(11).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    this.TitleImage1 = this.m_transform.GetChild(2).gameObject;
    this.TitleImage2 = this.m_transform.GetChild(3).gameObject;
    this.ForgeBtn = this.m_transform.GetChild(11).gameObject;
    this.RTImage1 = this.m_transform.GetChild(2).GetChild(1).GetComponent<Image>();
    this.RTImage2 = this.m_transform.GetChild(2).GetChild(2).GetComponent<Image>();
    this.TitleNameText = this.m_transform.GetChild(6).GetComponent<UIText>();
    this.TitleNameText.font = this.tmpFont;
    this.TitleStr = StringManager.Instance.SpawnString(100);
    this.GetAllText = this.m_transform.GetChild(7).GetComponent<UIText>();
    this.GetAllText.font = this.tmpFont;
    this.GatAllColor = ((Graphic) this.GetAllText).color;
    this.GetAllText2 = this.m_transform.GetChild(8).GetComponent<UIText>();
    this.GetAllText2.font = this.tmpFont;
    this.GetAllText2.text = this.DM.mStringTable.GetStringByID(14664U);
    ((Graphic) this.GetAllText2).color = this.GatOneColor;
    this.GM.InitianHeroItemImg(this.m_transform.GetChild(5), eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0, bShowText: false);
    Transform child1 = this.m_transform.GetChild(10);
    this.GM.InitianHeroItemImg(child1.GetChild(1), eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
    child1.GetChild(1).gameObject.AddComponent<IgnoreRaycast>();
    this.GM.InitLordEquipImg(child1.GetChild(2), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    child1.GetChild(2).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.UILeBtn;
    child1.GetChild(3).GetChild(0).GetComponent<UIText>().font = this.tmpFont;
    child1.GetChild(4).GetComponent<UIText>().font = this.tmpFont;
    child1.GetChild(5).GetComponent<UIText>().font = this.tmpFont;
    child1.GetChild(6).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
    this.Scroll = this.m_transform.GetChild(9).GetComponent<ScrollPanel>();
    this.Scroll.IntiScrollPanel(358f, 0.0f, 0.0f, this.NowHeightList, 9, (IUpDateScrollPanel) this);
    UIButtonHint.scrollRect = this.Scroll.GetComponent<CScrollRect>();
    Transform child2 = this.m_transform.GetChild(13);
    this.FBGO = child2.gameObject;
    this.FBTitleText = child2.GetChild(0).GetComponent<UIText>();
    this.FBTitleText.font = this.tmpFont;
    this.FBTitleText.text = this.DM.mStringTable.GetStringByID(12191U);
    for (int index = 0; index < 4; ++index)
    {
      this.FBItemGO[index] = child2.GetChild(index + 1).gameObject;
      this.FBHIBtn[index] = child2.GetChild(index + 1).GetChild(0).GetComponent<UIHIBtn>();
      this.FBHIBtn[index].m_Handler = (IUIHIBtnClickHandler) this;
      this.GM.InitianHeroItemImg(((Component) this.FBHIBtn[index]).transform, eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
      this.FBLEBtn[index] = child2.GetChild(index + 1).GetChild(1).GetComponent<UILEBtn>();
      this.FBLEBtn[index].m_Handler = (IUILEBtnClickHandler) this;
      this.GM.InitLordEquipImg(((Component) this.FBLEBtn[index]).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
      this.FBCountText[index] = child2.GetChild(index + 1).GetChild(2).GetComponent<UIText>();
      this.FBCountText[index].font = this.tmpFont;
      this.FBCountStr[index] = StringManager.Instance.SpawnString();
    }
    this.RefreshList((byte) arg1, (ushort) arg2);
    if (BattleController.IsGambleMode)
      ((Component) this.GM.m_ChatBox).gameObject.SetActive(false);
    this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
  }

  public override void OnClose()
  {
    if (this.TitleStr == null)
      return;
    StringManager.Instance.DeSpawnString(this.TitleStr);
    this.TitleStr = (CString) null;
    for (int index = 0; index < 9; ++index)
    {
      if (this.PriceStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.PriceStr[index]);
        this.PriceStr[index] = (CString) null;
      }
      if (this.NameStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.NameStr[index]);
        this.NameStr[index] = (CString) null;
      }
      if (this.RankStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.RankStr[index]);
        this.RankStr[index] = (CString) null;
      }
    }
    for (int index = 0; index < 4; ++index)
    {
      if (this.FBCountStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.FBCountStr[index]);
        this.FBCountStr[index] = (CString) null;
      }
    }
    if (!BattleController.IsGambleMode)
      return;
    ((Component) this.GM.m_ChatBox).gameObject.SetActive(true);
  }

  private void RefreshList(byte Kind, ushort ItemID)
  {
    this.SetIndex = (ushort) 0;
    this.OpenKind = Kind;
    this.OpenID = this.BoxID = ItemID;
    this.ForgeBtn.SetActive(false);
    this.FBGO.SetActive(false);
    if (this.OpenKind == (byte) 1 || this.OpenKind == (byte) 4)
    {
      ushort InKey = ItemID;
      FBMissionTbl recordByKey1;
      if (this.OpenKind == (byte) 4)
      {
        recordByKey1 = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(InKey);
        this.BoxID = ItemID = recordByKey1.FriendPrice;
      }
      this.TitleImage1.SetActive(true);
      ((Behaviour) this.RTImage1).enabled = true;
      ((Component) this.GetAllText2).gameObject.SetActive(false);
      ((Graphic) this.BackImage).color = (Color) new Color32((byte) 42, (byte) 185, (byte) 109, byte.MaxValue);
      this.tmpEquip = this.DM.EquipTable.GetRecordByKey(ItemID);
      this.NowHeightList.Clear();
      if (this.tmpEquip.EquipKind == (byte) 18)
      {
        if (this.tmpEquip.PropertiesInfo[0].Propertieskey == (ushort) 1)
        {
          this.BeginRank = (byte) 1;
          this.EndRank = (byte) 3;
        }
        else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == (ushort) 2)
        {
          this.BeginRank = (byte) 2;
          this.EndRank = (byte) 4;
        }
        else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == (ushort) 3)
        {
          this.BeginRank = (byte) 1;
          this.EndRank = (byte) 5;
        }
        else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == (ushort) 4)
        {
          this.BeginRank = (byte) this.tmpEquip.PropertiesInfo[5].Propertieskey;
          this.EndRank = (byte) this.tmpEquip.PropertiesInfo[5].PropertiesValue;
        }
        else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == (ushort) 5)
        {
          ((Component) this.GetAllText2).gameObject.SetActive(true);
          ((Behaviour) this.RTImage1).enabled = false;
          ((Behaviour) this.RTImage2).enabled = true;
          this.BeginRank = (byte) 0;
          this.EndRank = (byte) 0;
        }
        else
        {
          this.BeginRank = (byte) 0;
          this.EndRank = (byte) 0;
        }
        this.TitleStr.Length = 0;
        if (this.tmpEquip.PropertiesInfo[0].PropertiesValue == (ushort) 0)
        {
          this.TitleStr.StringToFormat(MallManager.Instance.GetItemRankName(this.EndRank));
          this.TitleStr.AppendFormat(this.DM.mStringTable.GetStringByID(7739U));
        }
        this.TitleStr.Append(this.DM.mStringTable.GetStringByID((uint) this.tmpEquip.EquipName));
        this.TitleNameText.text = this.TitleStr.ToString();
        this.TitleNameText.SetAllDirty();
        this.TitleNameText.cachedTextGenerator.Invalidate();
        if (this.IsGiftBox(this.BoxID))
        {
          this.tmpGB = this.DM.GiftBoxTable.GetRecordByKey(this.tmpEquip.PropertiesInfo[1].Propertieskey);
          this.ItemCount = 0;
          for (int index = 0; index < this.tmpGB.ItemData.Length; ++index)
          {
            if (this.tmpGB.ItemData[index].ItemID != (ushort) 0)
            {
              ++this.ItemCount;
              this.NowHeightList.Add(60f);
            }
          }
        }
        else
        {
          this.tmpLB = this.DM.LotteryBoxTable.GetRecordByKey(this.tmpEquip.PropertiesInfo[1].Propertieskey);
          this.SetIndex = this.tmpLB.SetIndex;
          if (this.SetIndex != (ushort) 0)
            this.ForgeBtn.SetActive(true);
          this.ItemCount = 0;
          for (int index = 0; index < this.tmpLB.ItemData.Length; ++index)
          {
            if (this.tmpLB.ItemData[index].ItemID != (ushort) 0)
            {
              ++this.ItemCount;
              this.NowHeightList.Add(60f);
            }
          }
        }
        this.GetAllText.text = this.DM.mStringTable.GetStringByID(837U);
        ((Graphic) this.GetAllText).color = this.GatOneColor;
      }
      else if (this.tmpEquip.EquipKind == (byte) 19)
      {
        this.TitleNameText.text = this.DM.mStringTable.GetStringByID((uint) this.tmpEquip.EquipName);
        this.tmpCB = this.DM.ComboBoxTable.GetRecordByKey(this.tmpEquip.PropertiesInfo[1].Propertieskey);
        this.SetIndex = this.tmpCB.SetIndex;
        if (this.SetIndex != (ushort) 0)
          this.ForgeBtn.SetActive(true);
        this.ItemCount = 0;
        for (int index = 0; index < this.tmpCB.ItemData.Length; ++index)
        {
          if (this.tmpCB.ItemData[index].ItemID != (ushort) 0)
          {
            ++this.ItemCount;
            this.NowHeightList.Add(60f);
          }
        }
        this.GetAllText.text = this.DM.mStringTable.GetStringByID(838U);
        ((Graphic) this.GetAllText).color = this.GatAllColor;
      }
      if (this.OpenKind == (byte) 4)
      {
        this.GetAllText.text = this.DM.mStringTable.GetStringByID(12190U);
        ((Graphic) this.GetAllText).color = this.GatAllColor;
        recordByKey1 = DataManager.FBMissionDataManager.FBMissionTable.GetRecordByKey(InKey);
        ComboBox recordByKey2 = this.DM.ComboBoxTable.GetRecordByKey(this.DM.EquipTable.GetRecordByKey(recordByKey1.OwnPrice).PropertiesInfo[1].Propertieskey);
        for (int index = 0; index < 4 && index < recordByKey2.ItemData.Length; ++index)
        {
          if (recordByKey2.ItemData[index].ItemID != (ushort) 0)
          {
            bool flag = this.GM.IsLeadItem(this.DM.EquipTable.GetRecordByKey(recordByKey2.ItemData[index].ItemID).EquipKind);
            ushort itemId = recordByKey2.ItemData[index].ItemID;
            ushort itemCount = recordByKey2.ItemData[index].ItemCount;
            byte rank = this.tmpCB.ItemData[index].Rank;
            if (flag)
              GUIManager.Instance.ChangeLordEquipImg(((Component) this.FBLEBtn[index]).transform, itemId, rank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
            else
              GUIManager.Instance.ChangeHeroItemImg(((Component) this.FBHIBtn[index]).transform, eHeroOrItem.Item, itemId, (byte) 0, (byte) 0);
            ((Component) this.FBHIBtn[index]).gameObject.SetActive(!flag);
            ((Component) this.FBLEBtn[index]).gameObject.SetActive(flag);
            this.FBCountStr[index].Length = 0;
            this.FBCountStr[index].IntToFormat((long) itemCount);
            if (this.GM.IsArabic)
              this.FBCountStr[index].AppendFormat("{0}x");
            else
              this.FBCountStr[index].AppendFormat("x{0}");
            this.FBCountText[index].text = this.FBCountStr[index].ToString();
            this.FBCountText[index].SetAllDirty();
            this.FBCountText[index].cachedTextGenerator.Invalidate();
            this.FBItemGO[index].SetActive(true);
          }
          else
            this.FBItemGO[index].SetActive(false);
        }
        this.FBGO.SetActive(true);
      }
    }
    else if (this.OpenKind == (byte) 2)
    {
      this.TitleImage2.SetActive(true);
      ((Graphic) this.BackImage).color = (Color) new Color32((byte) 42, (byte) 150, (byte) 185, byte.MaxValue);
      this.tmpEquip = this.DM.EquipTable.GetRecordByKey(ItemID);
      this.TitleStr.Length = 0;
      if (this.tmpEquip.EquipKind == (byte) 18)
      {
        if (this.tmpEquip.PropertiesInfo[0].Propertieskey == (ushort) 1)
        {
          this.BeginRank = (byte) 1;
          this.EndRank = (byte) 3;
        }
        else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == (ushort) 2)
        {
          this.BeginRank = (byte) 2;
          this.EndRank = (byte) 4;
        }
        else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == (ushort) 3)
        {
          this.BeginRank = (byte) 1;
          this.EndRank = (byte) 5;
        }
        else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == (ushort) 4)
        {
          this.BeginRank = (byte) this.tmpEquip.PropertiesInfo[5].Propertieskey;
          this.EndRank = (byte) this.tmpEquip.PropertiesInfo[5].PropertiesValue;
        }
        else
        {
          this.BeginRank = (byte) 0;
          this.EndRank = (byte) 0;
        }
        if (this.tmpEquip.PropertiesInfo[0].PropertiesValue == (ushort) 0)
        {
          this.TitleStr.StringToFormat(MallManager.Instance.GetItemRankName(this.EndRank));
          this.TitleStr.AppendFormat(this.DM.mStringTable.GetStringByID(7739U));
        }
      }
      this.TitleStr.Append(this.DM.mStringTable.GetStringByID((uint) this.tmpEquip.EquipName));
      this.TitleStr.Append(' ');
      this.TitleStr.IntToFormat((long) this.GM.OpenBoxCount);
      if (this.GM.IsArabic)
        this.TitleStr.AppendFormat("{0}x");
      else
        this.TitleStr.AppendFormat("x{0}");
      this.TitleNameText.text = this.TitleStr.ToString();
      this.TitleNameText.SetAllDirty();
      this.TitleNameText.cachedTextGenerator.Invalidate();
      this.NowHeightList.Clear();
      this.ItemCount = this.GM.CommonItemData.Count;
      for (int index = 0; index < this.ItemCount; ++index)
        this.NowHeightList.Add(60f);
      this.GetAllText.text = this.DM.mStringTable.GetStringByID(839U);
      ((Graphic) this.GetAllText).color = this.GatAllColor;
    }
    else if (this.OpenKind == (byte) 3)
    {
      this.TitleImage1.SetActive(true);
      ((Behaviour) this.RTImage1).enabled = true;
      ((Graphic) this.BackImage).color = (Color) new Color32((byte) 42, (byte) 185, (byte) 109, byte.MaxValue);
      this.tmpEquip = this.DM.EquipTable.GetRecordByKey(ItemID);
      this.NowHeightList.Clear();
      this.TitleNameText.text = this.DM.mStringTable.GetStringByID((uint) this.tmpEquip.EquipName);
      MerchantmanManager instance = MerchantmanManager.Instance;
      this.ItemCount = 0;
      for (int index = 0; index < (int) instance.MerchantmanExtraData.DataLen; ++index)
      {
        if (instance.MerchantmanExtraData.ItemContain[index].ItemID != (ushort) 0)
        {
          ++this.ItemCount;
          this.NowHeightList.Add(60f);
        }
      }
      this.GetAllText.text = this.DM.mStringTable.GetStringByID(838U);
      ((Graphic) this.GetAllText).color = this.GatAllColor;
      if (instance.bNeedUpDateExtra)
        instance.SendReQusetBlackMarket_Data();
    }
    this.GM.ChangeHeroItemImg(this.m_transform.GetChild(5), eHeroOrItem.Item, this.BoxID, (byte) 0, (byte) 0);
    this.Scroll.AddNewDataHeight(this.NowHeightList);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    if ((Object) this.TitleNameText != (Object) null && ((Behaviour) this.TitleNameText).enabled)
    {
      ((Behaviour) this.TitleNameText).enabled = false;
      ((Behaviour) this.TitleNameText).enabled = true;
    }
    if ((Object) this.GetAllText != (Object) null && ((Behaviour) this.GetAllText).enabled)
    {
      ((Behaviour) this.GetAllText).enabled = false;
      ((Behaviour) this.GetAllText).enabled = true;
    }
    if ((Object) this.GetAllText2 != (Object) null && ((Behaviour) this.GetAllText2).enabled)
    {
      ((Behaviour) this.GetAllText2).enabled = false;
      ((Behaviour) this.GetAllText2).enabled = true;
    }
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
        if ((Object) this.ScrollComp[index].RankText != (Object) null && ((Behaviour) this.ScrollComp[index].RankText).enabled)
        {
          ((Behaviour) this.ScrollComp[index].RankText).enabled = false;
          ((Behaviour) this.ScrollComp[index].RankText).enabled = true;
        }
        if ((Object) this.ScrollComp[index].HIBtn != (Object) null)
          this.ScrollComp[index].HIBtn.Refresh_FontTexture();
      }
    }
    if ((Object) this.FBTitleText != (Object) null && ((Behaviour) this.FBTitleText).enabled)
    {
      ((Behaviour) this.FBTitleText).enabled = false;
      ((Behaviour) this.FBTitleText).enabled = true;
    }
    for (int index = 0; index < 4; ++index)
    {
      if ((Object) this.FBHIBtn[index] != (Object) null)
        this.FBHIBtn[index].Refresh_FontTexture();
      if ((Object) this.FBCountText[index] != (Object) null && ((Behaviour) this.FBCountText[index]).enabled)
      {
        ((Behaviour) this.FBCountText[index]).enabled = false;
        ((Behaviour) this.FBCountText[index]).enabled = true;
      }
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelObjectIdx >= 9)
      return;
    if (!this.bFindScrollComp[panelObjectIdx])
    {
      this.bFindScrollComp[panelObjectIdx] = true;
      this.ScrollComp[panelObjectIdx].LineImage = item.transform.GetChild(0).GetComponent<Image>();
      this.ScrollComp[panelObjectIdx].HIBtn = item.transform.GetChild(1).GetComponent<UIHIBtn>();
      this.ScrollComp[panelObjectIdx].HIBtn.m_Handler = (IUIHIBtnClickHandler) this;
      this.ScrollComp[panelObjectIdx].LEBtn = item.transform.GetChild(2).GetComponent<UILEBtn>();
      this.ScrollComp[panelObjectIdx].LEBtn.m_Handler = (IUILEBtnClickHandler) this;
      this.ScrollComp[panelObjectIdx].ItemName = item.transform.GetChild(4).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].ItemCountText = item.transform.GetChild(5).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].RankImg = item.transform.GetChild(3).GetComponent<Image>();
      this.ScrollComp[panelObjectIdx].RankText = item.transform.GetChild(3).GetChild(0).GetComponent<UIText>();
      this.ScrollComp[panelObjectIdx].Btn3 = item.transform.GetChild(6).GetComponent<UIButton>();
      this.ScrollComp[panelObjectIdx].Hint3 = item.transform.GetChild(6).GetComponent<UIButtonHint>();
      this.ScrollComp[panelObjectIdx].Hint3.m_Handler = (MonoBehaviour) this;
      this.ScrollComp[panelObjectIdx].Hint3.DelayTime = 0.2f;
      this.PriceStr[panelObjectIdx] = StringManager.Instance.SpawnString();
      this.NameStr[panelObjectIdx] = StringManager.Instance.SpawnString(150);
      this.RankStr[panelObjectIdx] = StringManager.Instance.SpawnString();
    }
    if (dataIdx < 0)
      return;
    ushort num1 = 1;
    ushort x = 1;
    byte num2 = 1;
    bool flag = false;
    this.NameStr[panelObjectIdx].Length = 0;
    this.ScrollComp[panelObjectIdx].HIBtn.m_BtnID2 = panelObjectIdx;
    if (this.OpenKind == (byte) 1 || this.OpenKind == (byte) 4)
    {
      ((Graphic) this.ScrollComp[panelObjectIdx].LineImage).color = (Color) new Color32((byte) 94, (byte) 183, (byte) 138, byte.MaxValue);
      if (this.tmpEquip.EquipKind == (byte) 18)
      {
        if (this.IsGiftBox(this.BoxID))
        {
          if (dataIdx >= this.tmpGB.ItemData.Length)
            return;
          num1 = this.tmpGB.ItemData[dataIdx].ItemID;
          x = this.tmpGB.ItemData[dataIdx].ItemCount;
        }
        else
        {
          if (dataIdx >= this.tmpLB.ItemData.Length)
            return;
          num1 = this.tmpLB.ItemData[dataIdx].ItemID;
          x = this.tmpLB.ItemData[dataIdx].ItemCount;
        }
        Equip recordByKey1 = this.DM.EquipTable.GetRecordByKey(num1);
        flag = this.GM.IsLeadItem(recordByKey1.EquipKind);
        this.NameStr[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
        if (flag)
        {
          if (this.EndRank == (byte) 0)
          {
            this.NameStr[panelObjectIdx].StringToFormat(MallManager.Instance.GetItemRankName(this.BeginRank));
            this.NameStr[panelObjectIdx].AppendFormat("({0})");
          }
          else
          {
            this.NameStr[panelObjectIdx].StringToFormat(MallManager.Instance.GetItemRankName(this.BeginRank));
            this.NameStr[panelObjectIdx].StringToFormat(MallManager.Instance.GetItemRankName(this.EndRank));
            this.NameStr[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7738U));
          }
        }
        if (recordByKey1.EquipKind == (byte) 30)
        {
          PetTbl recordByKey2 = PetManager.Instance.PetTable.GetRecordByKey(recordByKey1.SyntheticParts[0].SyntheticItem);
          this.RankStr[panelObjectIdx].Length = 0;
          StringManager.IntToStr(this.RankStr[panelObjectIdx], (long) recordByKey2.Rare);
          this.ScrollComp[panelObjectIdx].RankText.text = this.RankStr[panelObjectIdx].ToString();
          this.ScrollComp[panelObjectIdx].RankText.SetAllDirty();
          this.ScrollComp[panelObjectIdx].RankText.cachedTextGenerator.Invalidate();
          ((Component) this.ScrollComp[panelObjectIdx].RankImg).gameObject.SetActive(true);
        }
        else
          ((Component) this.ScrollComp[panelObjectIdx].RankImg).gameObject.SetActive(false);
      }
      else
      {
        if (this.tmpEquip.EquipKind != (byte) 19 || dataIdx >= this.tmpCB.ItemData.Length)
          return;
        num1 = this.tmpCB.ItemData[dataIdx].ItemID;
        x = this.tmpCB.ItemData[dataIdx].ItemCount;
        num2 = this.tmpCB.ItemData[dataIdx].Rank;
        Equip recordByKey = this.DM.EquipTable.GetRecordByKey(num1);
        flag = this.GM.IsLeadItem(recordByKey.EquipKind);
        if (this.tmpCB.ItemData[dataIdx].Rank != (byte) 0)
        {
          this.NameStr[panelObjectIdx].StringToFormat(MallManager.Instance.GetItemRankName(this.tmpCB.ItemData[dataIdx].Rank));
          this.NameStr[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7739U));
        }
        else if (recordByKey.EquipKind == (byte) 18 && this.tmpEquip.PropertiesInfo[0].Propertieskey != (ushort) 6)
        {
          byte ItemRank = 1;
          if (this.tmpEquip.PropertiesInfo[0].Propertieskey == (ushort) 1)
            ItemRank = (byte) 3;
          else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == (ushort) 2)
            ItemRank = (byte) 4;
          else if (this.tmpEquip.PropertiesInfo[0].Propertieskey == (ushort) 3)
            ItemRank = (byte) 5;
          this.NameStr[panelObjectIdx].StringToFormat(MallManager.Instance.GetItemRankName(ItemRank));
          this.NameStr[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7739U));
        }
        this.NameStr[panelObjectIdx].Append(this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipName));
      }
    }
    else if (this.OpenKind == (byte) 2)
    {
      ((Graphic) this.ScrollComp[panelObjectIdx].LineImage).color = (Color) new Color32((byte) 94, (byte) 165, (byte) 183, byte.MaxValue);
      if (dataIdx >= this.GM.CommonItemData.Count)
        return;
      num1 = this.GM.CommonItemData[dataIdx].ItemID;
      x = this.GM.CommonItemData[dataIdx].Num;
      num2 = this.GM.CommonItemData[dataIdx].ItemRank;
      Equip recordByKey = this.DM.EquipTable.GetRecordByKey(num1);
      flag = this.GM.IsLeadItem(recordByKey.EquipKind);
      if (this.GM.CommonItemData[dataIdx].ItemRank != (byte) 0)
      {
        this.NameStr[panelObjectIdx].StringToFormat(MallManager.Instance.GetItemRankName(num2));
        this.NameStr[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7739U));
      }
      CString nameStr = StringManager.Instance.StaticString1024();
      UIItemInfo.SetNameProperties((UIText) null, (UIText) null, nameStr, (CString) null, ref recordByKey);
      this.NameStr[panelObjectIdx].Append(nameStr);
    }
    else if (this.OpenKind == (byte) 3)
    {
      ((Graphic) this.ScrollComp[panelObjectIdx].LineImage).color = (Color) new Color32((byte) 94, (byte) 165, (byte) 183, byte.MaxValue);
      MerchantmanManager instance = MerchantmanManager.Instance;
      if (dataIdx >= (int) instance.MerchantmanExtraData.DataLen)
        return;
      num1 = instance.MerchantmanExtraData.ItemContain[dataIdx].ItemID;
      x = instance.MerchantmanExtraData.ItemContain[dataIdx].Num;
      num2 = instance.MerchantmanExtraData.ItemContain[dataIdx].ItemRank;
      Equip recordByKey = this.DM.EquipTable.GetRecordByKey(num1);
      flag = this.GM.IsLeadItem(recordByKey.EquipKind);
      if (num2 != (byte) 0)
      {
        this.NameStr[panelObjectIdx].StringToFormat(MallManager.Instance.GetItemRankName(num2));
        this.NameStr[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7739U));
      }
      CString nameStr = StringManager.Instance.StaticString1024();
      UIItemInfo.SetNameProperties((UIText) null, (UIText) null, nameStr, (CString) null, ref recordByKey);
      this.NameStr[panelObjectIdx].Append(nameStr);
    }
    if (flag)
      GUIManager.Instance.ChangeLordEquipImg(((Component) this.ScrollComp[panelObjectIdx].LEBtn).transform, num1, num2, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    else
      GUIManager.Instance.ChangeHeroItemImg(((Component) this.ScrollComp[panelObjectIdx].HIBtn).transform, eHeroOrItem.Item, num1, (byte) 0, (byte) 0);
    ((Component) this.ScrollComp[panelObjectIdx].LEBtn).gameObject.SetActive(flag);
    ((Component) this.ScrollComp[panelObjectIdx].HIBtn).gameObject.SetActive(!flag);
    this.ScrollComp[panelObjectIdx].Hint3.Parm1 = num1;
    this.ScrollComp[panelObjectIdx].Hint3.Parm2 = num2;
    if (flag || !MallManager.Instance.CheckCanOpenDetail(num1) && !PetManager.Instance.IsFakePetItem(num1))
      this.ScrollComp[panelObjectIdx].Hint3.enabled = true;
    else
      this.ScrollComp[panelObjectIdx].Hint3.enabled = false;
    ((Component) this.ScrollComp[panelObjectIdx].Btn3).gameObject.SetActive(this.ScrollComp[panelObjectIdx].Hint3.enabled);
    this.ScrollComp[panelObjectIdx].ItemName.text = this.NameStr[panelObjectIdx].ToString();
    this.ScrollComp[panelObjectIdx].ItemName.SetAllDirty();
    this.ScrollComp[panelObjectIdx].ItemName.cachedTextGenerator.Invalidate();
    this.PriceStr[panelObjectIdx].Length = 0;
    StringManager.IntToStr(this.PriceStr[panelObjectIdx], (long) x, bNumber: true);
    this.ScrollComp[panelObjectIdx].ItemCountText.text = this.PriceStr[panelObjectIdx].ToString();
    this.ScrollComp[panelObjectIdx].ItemCountText.SetAllDirty();
    this.ScrollComp[panelObjectIdx].ItemCountText.cachedTextGenerator.Invalidate();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    if (dataIndex < 0)
      return;
    ushort tmpItemID = 1;
    if (this.OpenKind == (byte) 1 || this.OpenKind == (byte) 4)
    {
      if (this.tmpEquip.EquipKind == (byte) 18)
      {
        if (this.IsGiftBox(this.BoxID))
        {
          if (dataIndex >= this.tmpGB.ItemData.Length)
            return;
          tmpItemID = this.tmpGB.ItemData[dataIndex].ItemID;
        }
        else
        {
          if (dataIndex >= this.tmpLB.ItemData.Length)
            return;
          tmpItemID = this.tmpLB.ItemData[dataIndex].ItemID;
        }
      }
      else
      {
        if (this.tmpEquip.EquipKind != (byte) 19 || dataIndex >= this.tmpCB.ItemData.Length)
          return;
        tmpItemID = this.tmpCB.ItemData[dataIndex].ItemID;
      }
    }
    else if (this.OpenKind == (byte) 2)
    {
      if (dataIndex >= this.GM.CommonItemData.Count)
        return;
      tmpItemID = this.GM.CommonItemData[dataIndex].ItemID;
    }
    else if (this.OpenKind == (byte) 3)
    {
      MerchantmanManager instance = MerchantmanManager.Instance;
      if (dataIndex >= (int) instance.MerchantmanExtraData.DataLen)
        return;
      tmpItemID = instance.MerchantmanExtraData.ItemContain[dataIndex].ItemID;
    }
    if (!this.OpenNext(tmpItemID))
      return;
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 1)
      return;
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (sender.m_BtnID2 == 2)
    {
      if (this.GM.BuildingData.GetBuildData((ushort) 15, (ushort) 0).Level < (byte) 1)
      {
        this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(7533U), (ushort) byte.MaxValue);
      }
      else
      {
        if (this.DM.mLordEquip == null)
          this.DM.mLordEquip = LordEquipData.Instance();
        if (!(bool) (Object) menu)
          return;
        this.DM.mLordEquip.OpenForgeSet(this.SetIndex, (byte) 4);
      }
    }
    else
    {
      if (sender.m_BtnID2 != 3)
        return;
      if (this.OpenData.Count > 0)
      {
        int index = this.OpenData.Count - 1;
        this.RefreshList(this.OpenData[index].OpenKind, this.OpenData[index].OpenID);
        this.OpenData.RemoveAt(index);
      }
      else if (BattleController.IsGambleMode)
      {
        GamblingManager.Instance.CloseMenu();
      }
      else
      {
        if (!(bool) (Object) menu)
          return;
        menu.CloseMenu();
      }
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    if (!this.OpenNext(this.ScrollComp[sender.m_BtnID2].HIBtn.HIID))
      return;
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
    if (!this.OpenNext(this.ScrollComp[sender.m_BtnID2].LEBtn.LEID))
      return;
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
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

  private bool OpenNext(ushort tmpItemID)
  {
    if (PetManager.Instance.IsFakePetItem(tmpItemID))
    {
      PetManager.Instance.OpenPetMaxShowUI((int) DataManager.Instance.EquipTable.GetRecordByKey(tmpItemID).SyntheticParts[0].SyntheticItem);
      return true;
    }
    if (!MallManager.Instance.CheckCanOpenDetail(tmpItemID))
      return false;
    this.OpenData.Add(new OpenStruct()
    {
      OpenKind = this.OpenKind,
      OpenID = this.OpenID
    });
    this.RefreshList((byte) 1, tmpItemID);
    return true;
  }

  private bool IsGiftBox(ushort tmpItemID)
  {
    Equip recordByKey = this.DM.EquipTable.GetRecordByKey(tmpItemID);
    return recordByKey.PropertiesInfo[2].Propertieskey == (ushort) 1 || recordByKey.PropertiesInfo[2].Propertieskey == (ushort) 2;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        if (this.OpenKind != (byte) 3)
          break;
        MerchantmanManager.Instance.SendReQusetBlackMarket_Data();
        break;
      case 2:
        if (this.OpenKind != (byte) 3)
          break;
        this.RefreshList(this.OpenKind, this.OpenID);
        break;
      case 3:
        if (this.OpenKind != (byte) 3)
          break;
        if (BattleController.IsGambleMode)
        {
          GUIManager.Instance.CloseMenu(this.m_eWindow);
          GUIManager.Instance.OpenMenu(EGUIWindow.UI_MonsterCrypt, bCameraMode: true);
          break;
        }
        Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
        if (!(bool) (Object) menu)
          break;
        menu.CloseMenu();
        break;
    }
  }
}
