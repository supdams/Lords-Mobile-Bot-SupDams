// Decompiled with JetBrains decompiler
// Type: UIForge_Item
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIForge_Item : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUILEBtnClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private Transform GameT;
  private Transform Tmp;
  private Transform SelectEquipT;
  private Transform SelectColorT;
  private ScrollPanel m_ScrollPanel;
  private RectTransform[] ItemBG_RC = new RectTransform[6];
  private RectTransform[] ItemLine_RC = new RectTransform[6];
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[6];
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private Door door;
  private UIButton btn_EXIT;
  private UIButton[] btn_Equip = new UIButton[6];
  private UIButton[] btn_Color = new UIButton[5];
  private UIButton[] btn_ForgingEquip = new UIButton[6];
  private UIButton btn_LvFilter;
  private UIButton btn_Filter;
  private UILEBtn tmpLebtn;
  private UILEBtn[] tmp_ItemLebtn = new UILEBtn[6];
  private Image BG;
  private Image Img_Yes;
  private Image Img_SelectEquip;
  private Image Img_SelectColor;
  private Image tmpImg;
  private Image[] tmpImg_ItemEnough = new Image[6];
  private Image[] tmpImg_ItemIcon = new Image[6];
  private Image[][] tmpImg_Items = new Image[6][];
  private UIText text_Select;
  private UIText[] text_tmpStr = new UIText[5];
  private UIText[] text_Filter = new UIText[2];
  private UIText[] text_ItemName = new UIText[6];
  private UIText[] text_ItemLv = new UIText[6];
  private UIText[] text_Itembtn = new UIText[6];
  private UIText[][] text_ItemEffect = new UIText[6][];
  private UIText[][] text_ItemEffect_V = new UIText[6][];
  private CString[][] Cstr_Effect = new CString[6][];
  private CString[][] Cstr_Effect_V = new CString[6][];
  private CString[] Cstr_ItemLv = new CString[6];
  private CString[] Cstr_ItemName = new CString[6];
  private CString Cstr_Filter;
  private Material m_Mat;
  private List<float> tmplist = new List<float>();
  public List<ushort> tmplistData = new List<ushort>();
  private List<ushort> tmplistHead = new List<ushort>();
  private List<ushort> tmplistBody = new List<ushort>();
  private List<ushort> tmplistshoe = new List<ushort>();
  private List<ushort> tmplistArms = new List<ushort>();
  private List<ushort> tmplistSecondArms = new List<ushort>();
  private List<ushort> tmplistAccessories = new List<ushort>();
  private List<LordEquipEffectSet> effectList = new List<LordEquipEffectSet>();
  public SortItemComparer mSortItem = new SortItemComparer();
  private bool bLvFilter = true;
  private byte mEquip = byte.MaxValue;
  public byte mColor = 4;
  private ushort mFilterSelect;
  private ushort mFilterSelectEffectID;
  private bool bEqDataReq;
  private bool bMaterialDataReq;
  private float ShowTimeSelectEquip;
  private float ShowTimeSelectColor;
  private Equip tmpEQ;
  private Color mChangColor = new Color(0.9137f, 0.8117f, 0.6549f);
  private UISpritesArray SArray;
  private byte tmpCount;
  private byte tmpEnoughCount;
  private bool bShowMainEquip;

  public override void OnOpen(int arg1, int arg2)
  {
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    if (this.DM.mLordEquip == null)
      this.DM.mLordEquip = LordEquipData.Instance();
    if (!this.DM.mLordEquip.LoadLordEquip())
    {
      this.bEqDataReq = true;
      if (!this.DM.mLordEquip.LoadLEMaterial())
        this.bMaterialDataReq = true;
    }
    for (int index1 = 0; index1 < 6; ++index1)
    {
      this.tmpImg_Items[index1] = new Image[4];
      this.text_ItemEffect[index1] = new UIText[6];
      this.text_ItemEffect_V[index1] = new UIText[6];
      this.Cstr_Effect[index1] = new CString[6];
      this.Cstr_Effect_V[index1] = new CString[6];
      for (int index2 = 0; index2 < 6; ++index2)
      {
        this.Cstr_Effect[index1][index2] = StringManager.Instance.SpawnString();
        this.Cstr_Effect_V[index1][index2] = StringManager.Instance.SpawnString();
      }
      this.Cstr_ItemLv[index1] = StringManager.Instance.SpawnString(100);
      this.Cstr_ItemName[index1] = StringManager.Instance.SpawnString();
    }
    this.Cstr_Filter = StringManager.Instance.SpawnString();
    ushort indexByKey1 = this.DM.EquipTable.GetIndexByKey((ushort) 4001);
    ushort indexByKey2 = this.DM.EquipTable.GetIndexByKey((ushort) 5000);
    for (int Index = (int) indexByKey1; Index < (int) indexByKey2; ++Index)
    {
      this.tmpEQ = this.DM.EquipTable.GetRecordByIndex((int) (ushort) Index);
      switch (this.tmpEQ.EquipKind)
      {
        case 21:
          this.tmplistHead.Add((ushort) Index);
          break;
        case 22:
          this.tmplistBody.Add((ushort) Index);
          break;
        case 23:
          this.tmplistshoe.Add((ushort) Index);
          break;
        case 24:
          this.tmplistArms.Add((ushort) Index);
          break;
        case 25:
          this.tmplistSecondArms.Add((ushort) Index);
          break;
        case 26:
          this.tmplistAccessories.Add((ushort) Index);
          break;
      }
    }
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.GameT = this.gameObject.transform;
    this.m_Mat = this.door.LoadMaterial();
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.Tmp = this.GameT.GetChild(0).GetChild(0).GetChild(0);
    this.text_tmpStr[0] = this.Tmp.GetComponent<UIText>();
    this.text_tmpStr[0].font = this.TTFont;
    this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7402U);
    this.Tmp = this.GameT.GetChild(1);
    this.BG = this.Tmp.GetComponent<Image>();
    this.Tmp = this.GameT.GetChild(1).GetChild(0);
    this.text_Select = this.Tmp.GetComponent<UIText>();
    this.text_Select.font = this.TTFont;
    this.text_Select.text = this.DM.mStringTable.GetStringByID(7405U);
    this.Tmp = this.GameT.GetChild(2);
    this.text_tmpStr[1] = this.Tmp.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[1].font = this.TTFont;
    this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(7406U);
    this.text_tmpStr[2] = this.Tmp.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[2].font = this.TTFont;
    this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(7407U);
    this.text_tmpStr[3] = this.Tmp.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[3].font = this.TTFont;
    this.text_tmpStr[3].text = this.DM.mStringTable.GetStringByID(7408U);
    for (int index = 0; index < 6; ++index)
    {
      Transform child = this.Tmp.GetChild(3 + index);
      this.btn_Equip[index] = child.GetComponent<UIButton>();
      this.btn_Equip[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Equip[index].m_BtnID1 = 1 + index;
      this.btn_Equip[index].m_EffectType = e_EffectType.e_Scale;
      this.btn_Equip[index].transition = (Selectable.Transition) 0;
    }
    for (int index = 0; index < 5; ++index)
    {
      Transform child = this.Tmp.GetChild(14 + index);
      this.btn_Color[index] = child.GetComponent<UIButton>();
      this.btn_Color[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Color[index].m_BtnID1 = 7 + index;
      this.btn_Color[index].m_EffectType = e_EffectType.e_Scale;
      this.btn_Color[index].transition = (Selectable.Transition) 0;
    }
    this.SelectEquipT = this.Tmp.GetChild(3).GetChild(0);
    this.Img_SelectEquip = this.Tmp.GetChild(3).GetChild(0).GetComponent<Image>();
    this.SelectColorT = this.Tmp.GetChild(14).GetChild(0);
    this.Img_SelectColor = this.Tmp.GetChild(14).GetChild(0).GetComponent<Image>();
    this.btn_LvFilter = this.Tmp.GetChild(19).GetComponent<UIButton>();
    this.btn_LvFilter.m_Handler = (IUIButtonClickHandler) this;
    this.btn_LvFilter.m_BtnID1 = 12;
    this.Img_Yes = this.Tmp.GetChild(19).GetChild(0).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.Img_Yes).gameObject.AddComponent<ArabicItemTextureRot>();
    this.text_tmpStr[4] = this.Tmp.GetChild(19).GetChild(1).GetComponent<UIText>();
    this.text_tmpStr[4].font = this.TTFont;
    this.text_tmpStr[4].text = this.DM.mStringTable.GetStringByID(7409U);
    this.btn_Filter = this.Tmp.GetChild(20).GetComponent<UIButton>();
    this.btn_Filter.m_Handler = (IUIButtonClickHandler) this;
    this.btn_Filter.m_BtnID1 = 13;
    this.text_Filter[0] = this.Tmp.GetChild(20).GetChild(2).GetComponent<UIText>();
    this.text_Filter[0].font = this.TTFont;
    this.text_Filter[0].text = this.DM.mStringTable.GetStringByID(7427U);
    this.text_Filter[1] = this.Tmp.GetChild(20).GetChild(3).GetComponent<UIText>();
    this.text_Filter[1].font = this.TTFont;
    this.text_Filter[1].text = this.DM.mStringTable.GetStringByID(7464U);
    UIButton component1 = this.Tmp.GetChild(21).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 13;
    component1.m_EffectType = e_EffectType.e_Scale;
    component1.transition = (Selectable.Transition) 0;
    this.Tmp = this.GameT.GetChild(3);
    this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
    this.Tmp = this.GameT.GetChild(4);
    this.tmpLebtn = this.Tmp.GetChild(2).GetComponent<UILEBtn>();
    this.tmpLebtn.m_Handler = (IUILEBtnClickHandler) this;
    this.GUIM.InitLordEquipImg(((Component) this.tmpLebtn).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    this.tmpImg = this.Tmp.GetChild(3).GetChild(5).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.tmpImg).gameObject.AddComponent<ArabicItemTextureRot>();
    this.Tmp.GetChild(3).GetChild(6).GetComponent<UIText>().font = this.TTFont;
    this.Tmp.GetChild(3).GetChild(7).GetComponent<UIText>().font = this.TTFont;
    this.Tmp.GetChild(3).GetChild(8).GetComponent<UIText>().font = this.TTFont;
    UIButton component2 = this.Tmp.GetChild(4).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 14;
    component2.m_EffectType = e_EffectType.e_Scale;
    component2.transition = (Selectable.Transition) 0;
    UIText component3 = this.Tmp.GetChild(4).GetChild(0).GetComponent<UIText>();
    component3.font = this.TTFont;
    component3.text = this.DM.mStringTable.GetStringByID(7410U);
    for (int index = 0; index < 6; ++index)
    {
      this.Tmp.GetChild(6 + index).GetChild(0).GetComponent<UIText>().font = this.TTFont;
      this.Tmp.GetChild(6 + index).GetChild(1).GetComponent<UIText>().font = this.TTFont;
    }
    this.tmplist.Clear();
    for (int index = 0; index < 6; ++index)
      this.tmplist.Add(212f);
    this.m_ScrollPanel.IntiScrollPanel(490f, 11f, 0.0f, this.tmplist, 6, (IUpDateScrollPanel) this);
    this.tmpImg = this.GameT.GetChild(5).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(5).GetChild(0).GetComponent<UIButton>();
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.btn_EXIT.image).material = this.m_Mat;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    if (this.bEqDataReq && this.bMaterialDataReq)
      this.CheckReOpen();
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public void CheckReOpen()
  {
    if (this.DM.mLordEquip == null || this.DM.mLordEquip.ForgeItem_mEquip == (byte) 0)
      return;
    UIEffectFilter.SeletedFilter = this.DM.mLordEquip.ForgeItem_mSeletedFilter;
    if (UIEffectFilter.SeletedFilter != (ushort) 0)
    {
      this.mFilterSelect = UIEffectFilter.SeletedFilter;
      this.mFilterSelectEffectID = this.DM.LordEquipEffectFilter.GetRecordByIndex((int) (ushort) ((uint) this.mFilterSelect - 1U)).effectID;
      this.Cstr_Filter.ClearString();
      GameConstants.GetEffectValue(this.Cstr_Filter, this.mFilterSelectEffectID, 0U, (byte) 8, 0.0f);
      this.text_Filter[0].text = this.Cstr_Filter.ToString();
      this.text_Filter[0].SetAllDirty();
      this.text_Filter[0].cachedTextGenerator.Invalidate();
      ((Graphic) this.text_Filter[0]).color = Color.green;
      ((Component) this.text_Filter[1]).gameObject.SetActive(true);
    }
    this.bLvFilter = this.DM.mLordEquip.ForgeItem_bLvFilter;
    ((Component) this.Img_Yes).gameObject.SetActive(this.bLvFilter);
    this.mEquip = (byte) ((uint) this.DM.mLordEquip.ForgeItem_mEquip - 1U);
    this.mColor = this.DM.mLordEquip.ForgeItem_mColor;
    this.SelectEquipT.gameObject.SetActive(true);
    this.SelectColorT.gameObject.SetActive(true);
    this.ShowTimeSelectEquip = 0.0f;
    this.ShowTimeSelectColor = 0.0f;
    this.SelectColorT.SetParent(((Component) this.btn_Color[(int) this.mColor]).transform, false);
    this.SelectEquipT.SetParent(((Component) this.btn_Equip[(int) this.mEquip]).transform, false);
    this.SetEquipList(this.mEquip);
    this.m_ScrollPanel.GoTo(this.DM.mLordEquip.ForgeItem_ScrollIdx);
  }

  public void SetEquipList(byte Equip)
  {
    this.tmplist.Clear();
    this.tmplistData.Clear();
    switch (this.mEquip)
    {
      case 0:
        for (int index = 0; index < this.tmplistHead.Count; ++index)
          this.ItemListFilter(this.tmplistHead[index]);
        break;
      case 1:
        for (int index = 0; index < this.tmplistBody.Count; ++index)
          this.ItemListFilter(this.tmplistBody[index]);
        break;
      case 2:
        for (int index = 0; index < this.tmplistshoe.Count; ++index)
          this.ItemListFilter(this.tmplistshoe[index]);
        break;
      case 3:
        for (int index = 0; index < this.tmplistArms.Count; ++index)
          this.ItemListFilter(this.tmplistArms[index]);
        break;
      case 4:
        for (int index = 0; index < this.tmplistSecondArms.Count; ++index)
          this.ItemListFilter(this.tmplistSecondArms[index]);
        break;
      case 5:
        for (int index = 0; index < this.tmplistAccessories.Count; ++index)
          this.ItemListFilter(this.tmplistAccessories[index]);
        break;
    }
    if (this.tmplistData.Count > 0)
    {
      this.mSortItem.SortType = (byte) 0;
      this.mSortItem.SortLv = !this.bLvFilter ? (byte) 1 : (byte) 0;
      this.mSortItem.SortColor = this.mColor;
      this.tmplistData.Sort((IComparer<ushort>) this.mSortItem);
      for (int index = 0; index < this.tmplistData.Count; ++index)
        this.SetListHeight(this.tmplistData[index]);
      this.m_ScrollPanel.AddNewDataHeight(this.tmplist);
      this.m_ScrollPanel.gameObject.SetActive(true);
      ((Component) this.BG).gameObject.SetActive(false);
    }
    else
    {
      this.m_ScrollPanel.gameObject.SetActive(false);
      ((Component) this.BG).gameObject.SetActive(true);
      this.text_Select.text = this.DM.mStringTable.GetStringByID(7495U);
    }
  }

  public bool CheckEquipOpen(MallEquipmant tmpME)
  {
    bool flag = false;
    int hour = GameConstants.GetDateTime(this.DM.ServerTime).ToUniversalTime().Hour;
    int num1 = 0;
    if (hour - 5 < 0)
      num1 = -1;
    int num2 = (int) tmpME.EquipData[1] * 30 + (int) tmpME.EquipData[2];
    int num3 = GameConstants.GetDateTime(this.DM.ServerTime).ToUniversalTime().Month * 30 + GameConstants.GetDateTime(this.DM.ServerTime).ToUniversalTime().Day + num1;
    if ((int) tmpME.EquipData[0] == GameConstants.GetDateTime(this.DM.ServerTime).ToUniversalTime().Year - 2000 && num2 <= num3 || (int) tmpME.EquipData[0] < GameConstants.GetDateTime(this.DM.ServerTime).ToUniversalTime().Year - 2000)
      flag = true;
    return flag;
  }

  public void ItemListFilter(ushort Idx)
  {
    bool flag1 = false;
    this.tmpEQ = this.DM.EquipTable.GetRecordByIndex((int) Idx);
    LordEquipEffectFilterData recordByIndex = this.DM.LordEquipEffectFilter.GetRecordByIndex((int) (ushort) ((uint) this.mFilterSelect - 1U));
    bool flag2 = false;
    if (this.tmpEQ.ActivitySuitIndex > (byte) 0)
    {
      if (!this.CheckEquipOpen(this.DM.MallEquipmantTable.GetRecordByKey((ushort) this.tmpEQ.ActivitySuitIndex)))
        return;
      MallEquipmant recordByKey1 = this.DM.MallEquipmantTable.GetRecordByKey((ushort) this.tmpEQ.ActivitySuitIndex);
      for (int index = 0; index < 10; ++index)
      {
        if ((int) recordByKey1.ItemId[index] == (int) this.tmpEQ.EquipKey)
        {
          flag2 = true;
          break;
        }
      }
      if (!flag2 && this.DM.ActivityEquipListIdx.Count > 0)
      {
        for (int index1 = 0; index1 < this.DM.ActivityEquipListIdx.Count; ++index1)
        {
          if ((int) this.tmpEQ.ActivitySuitIndex == (int) this.DM.ActivityEquipListIdx[index1].Index)
          {
            MallEquipmant recordByKey2 = this.DM.MallEquipmantTable.GetRecordByKey(this.DM.ActivityEquipListIdx[index1].Key);
            for (int index2 = 0; index2 < 10; ++index2)
            {
              if ((int) this.tmpEQ.EquipKey == (int) recordByKey2.ItemId[index2])
              {
                flag2 = true;
                break;
              }
            }
          }
        }
      }
    }
    else
      flag2 = true;
    if (!flag2)
      return;
    for (int index = 0; index < 6; ++index)
    {
      ushort propertieskey = this.tmpEQ.PropertiesInfo[index].Propertieskey;
      if (propertieskey != (ushort) 0 && this.tmpEQ.ForgingExp != 0U)
      {
        LordEquipEffectData recordByKey = this.DM.LordEquipEffectTable.GetRecordByKey(propertieskey);
        if (!flag1 && (this.mFilterSelect == (ushort) 0 || this.mFilterSelect > (ushort) 0 && (int) recordByKey.EffectID == (int) recordByIndex.effectID))
          flag1 = true;
      }
    }
    if (!flag1)
      return;
    this.tmplistData.Add(Idx);
  }

  public void SetListHeight(ushort Idx)
  {
    this.tmpEQ = this.DM.EquipTable.GetRecordByIndex((int) Idx);
    int num = 0;
    for (int index = 0; index < 6; ++index)
    {
      if (this.tmpEQ.PropertiesInfo[index].Propertieskey != (ushort) 0)
        ++num;
    }
    this.tmplist.Add((float) (98 + num * 24));
  }

  public void ChangSort()
  {
    this.tmplist.Clear();
    for (int index1 = 0; index1 < this.tmplistData.Count; ++index1)
    {
      this.tmpEQ = this.DM.EquipTable.GetRecordByIndex((int) this.tmplistData[index1]);
      int num = 0;
      for (int index2 = 0; index2 < 6; ++index2)
      {
        if (this.tmpEQ.PropertiesInfo[index2].Propertieskey != (ushort) 0)
          ++num;
      }
      this.tmplist.Add((float) (98 + num * 24));
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) this.tmpItem[panelObjectIdx] == (Object) null)
    {
      this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
      this.ItemBG_RC[panelObjectIdx] = item.transform.GetChild(0).GetComponent<RectTransform>();
      this.ItemLine_RC[panelObjectIdx] = item.transform.GetChild(6).GetComponent<RectTransform>();
      this.tmp_ItemLebtn[panelObjectIdx] = item.transform.GetChild(2).GetComponent<UILEBtn>();
      this.tmpImg_ItemEnough[panelObjectIdx] = item.transform.GetChild(3).GetChild(5).GetComponent<Image>();
      this.btn_ForgingEquip[panelObjectIdx] = item.transform.GetChild(4).GetComponent<UIButton>();
      this.btn_ForgingEquip[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
      this.text_Itembtn[panelObjectIdx] = item.transform.GetChild(4).GetChild(0).GetComponent<UIText>();
      this.text_ItemName[panelObjectIdx] = item.transform.GetChild(3).GetChild(6).GetComponent<UIText>();
      this.text_ItemLv[panelObjectIdx] = item.transform.GetChild(3).GetChild(7).GetComponent<UIText>();
      this.tmpImg_ItemIcon[panelObjectIdx] = item.transform.GetChild(3).GetChild(0).GetComponent<Image>();
      for (int index = 0; index < 4; ++index)
        this.tmpImg_Items[panelObjectIdx][index] = item.transform.GetChild(3).GetChild(1 + index).GetComponent<Image>();
      for (int index = 0; index < 6; ++index)
      {
        this.text_ItemEffect[panelObjectIdx][index] = item.transform.GetChild(6 + index).GetChild(0).GetComponent<UIText>();
        this.text_ItemEffect_V[panelObjectIdx][index] = item.transform.GetChild(6 + index).GetChild(1).GetComponent<UIText>();
      }
    }
    if (this.tmplistData.Count <= dataIdx)
      return;
    this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
    this.tmpEQ = this.DM.EquipTable.GetRecordByIndex((int) this.tmplistData[dataIdx]);
    this.GUIM.ChangeLordEquipImg(((Component) this.tmp_ItemLebtn[panelObjectIdx]).transform, this.tmpEQ.EquipKey, (byte) ((uint) this.mColor + 1U), gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    this.Cstr_ItemName[panelObjectIdx].ClearString();
    GameConstants.GetColoredLordEquipString(this.Cstr_ItemName[panelObjectIdx], this.tmpEQ.EquipKey, (byte) ((uint) this.mColor + 1U));
    this.text_ItemName[panelObjectIdx].text = this.Cstr_ItemName[panelObjectIdx].ToString();
    this.text_ItemName[panelObjectIdx].SetAllDirty();
    this.text_ItemName[panelObjectIdx].cachedTextGenerator.Invalidate();
    this.Cstr_ItemLv[panelObjectIdx].ClearString();
    if ((int) this.tmpEQ.NeedLv <= (int) this.DM.RoleAttr.Level)
    {
      this.Cstr_ItemLv[panelObjectIdx].IntToFormat((long) this.tmpEQ.NeedLv, bNumber: true);
    }
    else
    {
      CString tmpS = StringManager.Instance.StaticString1024();
      tmpS.ClearString();
      tmpS.IntToFormat((long) this.tmpEQ.NeedLv, bNumber: true);
      tmpS.AppendFormat("<color=#FF5581FF>{0}</color>");
      this.Cstr_ItemLv[panelObjectIdx].StringToFormat(tmpS);
    }
    this.Cstr_ItemLv[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) (ushort) (7431U + (uint) this.mEquip)));
    this.Cstr_ItemLv[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(7437U));
    this.text_ItemLv[panelObjectIdx].text = this.Cstr_ItemLv[panelObjectIdx].ToString();
    this.text_ItemLv[panelObjectIdx].SetAllDirty();
    this.text_ItemLv[panelObjectIdx].cachedTextGenerator.Invalidate();
    this.effectList.Clear();
    LordEquipData.GetEffectList(this.tmpEQ.EquipKey, (byte) ((uint) this.mColor + 1U), this.effectList);
    for (int index = 0; index < this.effectList.Count; ++index)
    {
      this.Cstr_Effect[panelObjectIdx][index].ClearString();
      GameConstants.GetEffectValue(this.Cstr_Effect[panelObjectIdx][index], this.effectList[index].EffectID, 0U, (byte) 8, 0.0f);
      this.text_ItemEffect[panelObjectIdx][index].text = this.Cstr_Effect[panelObjectIdx][index].ToString();
      this.text_ItemEffect[panelObjectIdx][index].SetAllDirty();
      this.text_ItemEffect[panelObjectIdx][index].cachedTextGenerator.Invalidate();
      if (this.mFilterSelect != (ushort) 0 && (int) this.mFilterSelectEffectID == (int) this.effectList[index].EffectID)
        ((Graphic) this.text_ItemEffect[panelObjectIdx][index]).color = Color.green;
      else
        ((Graphic) this.text_ItemEffect[panelObjectIdx][index]).color = this.mChangColor;
      this.Cstr_Effect_V[panelObjectIdx][index].ClearString();
      GameConstants.GetEffectValue(this.Cstr_Effect_V[panelObjectIdx][index], this.effectList[index].EffectID, (uint) this.effectList[index].EffectValue, (byte) 3, 0.0f);
      this.text_ItemEffect_V[panelObjectIdx][index].text = this.Cstr_Effect_V[panelObjectIdx][index].ToString();
      this.text_ItemEffect_V[panelObjectIdx][index].SetAllDirty();
      this.text_ItemEffect_V[panelObjectIdx][index].cachedTextGenerator.Invalidate();
    }
    int count = this.effectList.Count;
    for (int index = 0; index < count; ++index)
      item.transform.GetChild(6 + index).gameObject.SetActive(true);
    for (int index = count; index < 6; ++index)
      item.transform.GetChild(6 + index).gameObject.SetActive(false);
    this.ItemBG_RC[panelObjectIdx].sizeDelta = new Vector2(this.ItemBG_RC[panelObjectIdx].sizeDelta.x, (float) (92 + count * 24));
    this.ItemLine_RC[panelObjectIdx].sizeDelta = new Vector2(this.ItemLine_RC[panelObjectIdx].sizeDelta.x, (float) (17 + (count - 1) * 24));
    this.tmpCount = (byte) 0;
    this.tmpEnoughCount = (byte) 0;
    this.bShowMainEquip = false;
    ((Component) this.tmpImg_ItemIcon[panelObjectIdx]).gameObject.SetActive(false);
    if (this.mColor >= (byte) 1)
    {
      if (LordEquipData.getItemQuantity(this.tmpEQ.EquipKey, this.mColor) > (ushort) 0)
      {
        this.tmpImg_ItemIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[(int) this.mEquip * 2];
        this.bShowMainEquip = true;
      }
      else
        this.tmpImg_ItemIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[(int) this.mEquip * 2 + 1];
    }
    for (int index = 0; index < 4; ++index)
    {
      if (this.tmpEQ.SyntheticParts[index].SyntheticItem > (ushort) 0)
      {
        ++this.tmpCount;
        if (this.DM.mLordEquip.CheckMaterialEnough(this.tmpEQ.SyntheticParts[index].SyntheticItem, (byte) ((uint) this.mColor + 1U), (ushort) this.tmpEQ.SyntheticParts[index].SyntheticItemNum, true))
          ++this.tmpEnoughCount;
      }
      if (index == 0)
      {
        if (this.mColor >= (byte) 1)
          ((Graphic) this.tmpImg_Items[panelObjectIdx][index]).rectTransform.anchoredPosition = new Vector2(-22f, ((Graphic) this.tmpImg_Items[panelObjectIdx][index]).rectTransform.anchoredPosition.y);
        else
          ((Graphic) this.tmpImg_Items[panelObjectIdx][index]).rectTransform.anchoredPosition = new Vector2(-50f, ((Graphic) this.tmpImg_Items[panelObjectIdx][index]).rectTransform.anchoredPosition.y);
      }
      else
        ((Graphic) this.tmpImg_Items[panelObjectIdx][index]).rectTransform.anchoredPosition = new Vector2(((Graphic) this.tmpImg_Items[panelObjectIdx][index - 1]).rectTransform.anchoredPosition.x + 40f, ((Graphic) this.tmpImg_Items[panelObjectIdx][index]).rectTransform.anchoredPosition.y);
    }
    bool flag = false;
    if ((this.mColor >= (byte) 1 && this.bShowMainEquip || this.mColor == (byte) 0) && this.tmpCount > (byte) 0 && (int) this.tmpCount == (int) this.tmpEnoughCount)
    {
      ((Component) this.tmpImg_ItemEnough[panelObjectIdx]).gameObject.SetActive(true);
      flag = true;
      this.tmpCount = (byte) 0;
    }
    else
    {
      ((Component) this.tmpImg_ItemEnough[panelObjectIdx]).gameObject.SetActive(false);
      if (this.mColor >= (byte) 1)
        ((Component) this.tmpImg_ItemIcon[panelObjectIdx]).gameObject.SetActive(true);
    }
    if (!flag)
    {
      for (int index = 0; index < (int) this.tmpCount; ++index)
      {
        ((Component) this.tmpImg_Items[panelObjectIdx][index]).gameObject.SetActive(true);
        this.tmpImg_Items[panelObjectIdx][index].sprite = (int) this.tmpEnoughCount <= index ? this.SArray.m_Sprites[12] : this.SArray.m_Sprites[13];
      }
    }
    for (int tmpCount = (int) this.tmpCount; tmpCount < 4; ++tmpCount)
    {
      ((Component) this.tmpImg_Items[panelObjectIdx][tmpCount]).gameObject.SetActive(false);
      this.tmpImg_Items[panelObjectIdx][tmpCount].sprite = this.SArray.m_Sprites[12];
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void OnClose()
  {
    for (int index1 = 0; index1 < 6; ++index1)
    {
      if (this.Cstr_ItemLv[index1] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemLv[index1]);
      if (this.Cstr_ItemName[index1] != null)
        StringManager.Instance.DeSpawnString(this.Cstr_ItemName[index1]);
      for (int index2 = 0; index2 < 6; ++index2)
      {
        if (this.Cstr_Effect[index1][index2] != null)
          StringManager.Instance.DeSpawnString(this.Cstr_Effect[index1][index2]);
        if (this.Cstr_Effect_V[index1][index2] != null)
          StringManager.Instance.DeSpawnString(this.Cstr_Effect_V[index1][index2]);
      }
    }
    if (this.Cstr_Filter != null)
      StringManager.Instance.DeSpawnString(this.Cstr_Filter);
    UIEffectFilter.SeletedFilter = (ushort) 0;
    if (this.mEquip == byte.MaxValue)
      return;
    this.DM.mLordEquip.ForgeItem_bLvFilter = this.bLvFilter;
    this.DM.mLordEquip.ForgeItem_mEquip = (byte) ((uint) this.mEquip + 1U);
    this.DM.mLordEquip.ForgeItem_mColor = this.mColor;
    this.DM.mLordEquip.ForgeItem_mSeletedFilter = this.mFilterSelect;
    this.DM.mLordEquip.ForgeItem_ScrollIdx = this.m_ScrollPanel.GetTopIdx();
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (!((Object) this.door != (Object) null))
          break;
        this.door.CloseMenu();
        break;
      case 1:
      case 2:
      case 3:
      case 4:
      case 5:
      case 6:
        if ((int) (byte) (sender.m_BtnID1 - 1) == (int) this.mEquip)
          break;
        this.mEquip = (byte) (sender.m_BtnID1 - 1);
        if (!this.SelectEquipT.gameObject.activeSelf)
        {
          this.SelectEquipT.gameObject.SetActive(true);
          this.SelectColorT.gameObject.SetActive(true);
          this.ShowTimeSelectEquip = 0.0f;
          this.ShowTimeSelectColor = 0.0f;
          this.mColor = (byte) 4;
          this.SelectColorT.SetParent(((Component) this.btn_Color[(int) this.mColor]).transform, false);
        }
        this.SelectEquipT.SetParent(((Component) this.btn_Equip[(int) this.mEquip]).transform, false);
        this.SetEquipList(this.mEquip);
        this.DM.mLordEquip.ForgeItem_bLvFilter = this.bLvFilter;
        this.DM.mLordEquip.ForgeItem_mEquip = (byte) ((uint) this.mEquip + 1U);
        this.DM.mLordEquip.ForgeItem_mColor = this.mColor;
        this.DM.mLordEquip.ForgeItem_mSeletedFilter = this.mFilterSelect;
        break;
      case 7:
      case 8:
      case 9:
      case 10:
      case 11:
        if (this.mEquip == byte.MaxValue)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(7493U), (ushort) byte.MaxValue);
          break;
        }
        this.mColor = (byte) (sender.m_BtnID1 - 7);
        this.SelectColorT.SetParent(((Component) this.btn_Color[(int) this.mColor]).transform, false);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        this.DM.mLordEquip.ForgeItem_bLvFilter = this.bLvFilter;
        this.DM.mLordEquip.ForgeItem_mEquip = (byte) ((uint) this.mEquip + 1U);
        this.DM.mLordEquip.ForgeItem_mColor = this.mColor;
        this.DM.mLordEquip.ForgeItem_mSeletedFilter = this.mFilterSelect;
        break;
      case 12:
        if (this.mEquip == byte.MaxValue)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(7493U), (ushort) byte.MaxValue);
          break;
        }
        this.bLvFilter = !this.bLvFilter;
        ((Component) this.Img_Yes).gameObject.SetActive(this.bLvFilter);
        this.mSortItem.SortType = (byte) 0;
        this.mSortItem.SortLv = !this.bLvFilter ? (byte) 1 : (byte) 0;
        this.mSortItem.SortColor = this.mColor;
        this.tmplistData.Sort((IComparer<ushort>) this.mSortItem);
        this.ChangSort();
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist);
        this.DM.mLordEquip.ForgeItem_bLvFilter = this.bLvFilter;
        this.DM.mLordEquip.ForgeItem_mEquip = (byte) ((uint) this.mEquip + 1U);
        this.DM.mLordEquip.ForgeItem_mColor = this.mColor;
        this.DM.mLordEquip.ForgeItem_mSeletedFilter = this.mFilterSelect;
        break;
      case 13:
        if (this.mEquip == byte.MaxValue)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(7493U), (ushort) byte.MaxValue);
          break;
        }
        this.door.OpenMenu(EGUIWindow.UI_EffectFilter, 1, (int) this.mFilterSelect);
        break;
      case 14:
        this.Tmp = ((Component) sender).gameObject.transform.parent;
        this.tmpEQ = this.DM.EquipTable.GetRecordByIndex((int) this.tmplistData[this.Tmp.GetComponent<ScrollPanelItem>().m_BtnID1]);
        UIAnvil.SetOpen(eUI_Anvil_OpenKind.ForgeNewItem, (int) this.tmpEQ.EquipKey, 1 + (int) this.mColor);
        break;
    }
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
  }

  public void ReSetList(int Idx) => this.tmplist.Clear();

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if (this.DM.mLordEquip.LoadLordEquip())
          break;
        this.bEqDataReq = true;
        if (!this.DM.mLordEquip.LoadLEMaterial())
        {
          this.bMaterialDataReq = true;
          break;
        }
        if (!this.bEqDataReq || !this.bMaterialDataReq)
          break;
        this.CheckReOpen();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.text_Select != (Object) null && ((Behaviour) this.text_Select).enabled)
    {
      ((Behaviour) this.text_Select).enabled = false;
      ((Behaviour) this.text_Select).enabled = true;
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((Object) this.text_Filter[index] != (Object) null && ((Behaviour) this.text_Filter[index]).enabled)
      {
        ((Behaviour) this.text_Filter[index]).enabled = false;
        ((Behaviour) this.text_Filter[index]).enabled = true;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
    for (int index1 = 0; index1 < 5; ++index1)
    {
      if ((Object) this.text_ItemName[index1] != (Object) null && ((Behaviour) this.text_ItemName[index1]).enabled)
      {
        ((Behaviour) this.text_ItemName[index1]).enabled = false;
        ((Behaviour) this.text_ItemName[index1]).enabled = true;
      }
      if ((Object) this.text_ItemLv[index1] != (Object) null && ((Behaviour) this.text_ItemLv[index1]).enabled)
      {
        ((Behaviour) this.text_ItemLv[index1]).enabled = false;
        ((Behaviour) this.text_ItemLv[index1]).enabled = true;
      }
      if ((Object) this.text_Itembtn[index1] != (Object) null && ((Behaviour) this.text_Itembtn[index1]).enabled)
      {
        ((Behaviour) this.text_Itembtn[index1]).enabled = false;
        ((Behaviour) this.text_Itembtn[index1]).enabled = true;
      }
      for (int index2 = 0; index2 < 6; ++index2)
      {
        if ((Object) this.text_ItemEffect[index1][index2] != (Object) null && ((Behaviour) this.text_ItemEffect[index1][index2]).enabled)
        {
          ((Behaviour) this.text_ItemEffect[index1][index2]).enabled = false;
          ((Behaviour) this.text_ItemEffect[index1][index2]).enabled = true;
        }
        if ((Object) this.text_ItemEffect_V[index1][index2] != (Object) null && ((Behaviour) this.text_ItemEffect_V[index1][index2]).enabled)
        {
          ((Behaviour) this.text_ItemEffect_V[index1][index2]).enabled = false;
          ((Behaviour) this.text_ItemEffect_V[index1][index2]).enabled = true;
        }
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 1:
        if (this.bEqDataReq || this.DM.mLordEquip.LoadLordEquip())
          break;
        this.bEqDataReq = true;
        if (!this.bMaterialDataReq && !this.DM.mLordEquip.LoadLEMaterial())
          this.bMaterialDataReq = true;
        if (!this.bEqDataReq || !this.bMaterialDataReq)
          break;
        this.CheckReOpen();
        break;
      case 2:
        if (this.DM.mLordEquip.LoadLordEquip() || this.DM.mLordEquip.LoadLEMaterial())
          break;
        this.CheckReOpen();
        break;
    }
  }

  private void Start()
  {
  }

  private void Update()
  {
    if (this.SelectEquipT.gameObject.activeSelf)
    {
      this.ShowTimeSelectEquip += Time.smoothDeltaTime;
      if ((double) this.ShowTimeSelectEquip >= 0.0)
      {
        if ((double) this.ShowTimeSelectEquip >= 2.0)
          this.ShowTimeSelectEquip = 0.0f;
        ((Graphic) this.Img_SelectEquip).color = new Color(1f, 1f, 1f, (double) this.ShowTimeSelectEquip <= 1.0 ? this.ShowTimeSelectEquip : 2f - this.ShowTimeSelectEquip);
      }
    }
    if (!this.SelectColorT.gameObject.activeSelf)
      return;
    this.ShowTimeSelectColor += Time.smoothDeltaTime;
    if ((double) this.ShowTimeSelectColor < 0.0)
      return;
    if ((double) this.ShowTimeSelectColor >= 2.0)
      this.ShowTimeSelectColor = 0.0f;
    ((Graphic) this.Img_SelectColor).color = new Color(1f, 1f, 1f, (double) this.ShowTimeSelectColor <= 1.0 ? this.ShowTimeSelectColor : 2f - this.ShowTimeSelectColor);
  }
}
