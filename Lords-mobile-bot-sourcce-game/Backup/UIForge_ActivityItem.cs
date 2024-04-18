// Decompiled with JetBrains decompiler
// Type: UIForge_ActivityItem
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIForge_ActivityItem : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUILEBtnClickHandler
{
  private DataManager DM;
  private GUIManager GUIM;
  private Transform GameT;
  private Transform Tmp;
  private Transform SelectColorT;
  private ScrollPanel m_ScrollPanel;
  private ScrollPanel m_ScrollPanel_Activity;
  private RectTransform[] ItemBG_RC = new RectTransform[6];
  private RectTransform[] ItemLine_RC = new RectTransform[6];
  private ScrollPanelItem[] tmpItem = new ScrollPanelItem[6];
  private ScrollPanelItem[] tmpItem_A = new ScrollPanelItem[7];
  private RectTransform mContentRT;
  private Font TTFont = GUIManager.Instance.GetTTFFont();
  private Door door;
  private UISpritesArray SArray;
  private UIButton btn_EXIT;
  private UIButton[] btn_Color = new UIButton[5];
  private UIButton[] btn_ForgingEquip = new UIButton[6];
  private UIButton[] btn_ActivityEquip = new UIButton[7];
  private UILEBtn tmpLebtn;
  private UILEBtn[] tmp_ItemLebtn = new UILEBtn[6];
  private Image BG;
  private Image Img_SelectColor;
  private Image tmpImg;
  private Image[] tmpImg_ItemEnough = new Image[6];
  private Image[] tmpImg_btn = new Image[7];
  private Image[] tmpImgSelect_btn = new Image[7];
  private Image[] tmpImg_ItemIcon = new Image[6];
  private Image[][] tmpImg_Items = new Image[6][];
  private UIText text_Select;
  private UIText[] text_tmpStr = new UIText[3];
  private UIText[] text_Item_A_Name = new UIText[7];
  private UIText[] text_ItemName = new UIText[6];
  private UIText[] text_ItemLv = new UIText[6];
  private UIText[] text_Itembtn = new UIText[6];
  private UIText[][] text_ItemEffect = new UIText[6][];
  private UIText[][] text_ItemEffect_V = new UIText[6][];
  private CString[][] Cstr_Effect = new CString[6][];
  private CString[][] Cstr_Effect_V = new CString[6][];
  private CString[] Cstr_ItemLv = new CString[6];
  private CString[] Cstr_ItemName = new CString[6];
  private Material m_Mat;
  private Material m_ListMat;
  private List<float> tmplist_A = new List<float>();
  private List<float> tmplist = new List<float>();
  public List<ushort> tmplistData = new List<ushort>();
  private List<LordEquipEffectSet> effectList = new List<LordEquipEffectSet>();
  public SortItemComparer mSortItem = new SortItemComparer();
  private List<Sprite> tmpSpritelist = new List<Sprite>();
  public List<ushort> tmplistEquip = new List<ushort>();
  private Equip tmpEQ;
  private MallEquipmant tmpME;
  public byte mColor = 4;
  public byte mActivityIdx = byte.MaxValue;
  private bool bEqDataReq;
  private bool bMaterialDataReq;
  private int mABeKey;
  private float ShowTimeSelectColor;
  private float ItemActivitySelect;
  private int mItemActivityIdx = -1;
  private int mItemActivityIdx2 = -1;
  private byte tmpCount;
  private byte tmpEnoughCount;
  private bool bShowMainEquip;
  private int TableCount;
  private AssetBundle mAB;

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
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.GameT = this.gameObject.transform;
    this.SArray = this.GameT.GetComponent<UISpritesArray>();
    this.m_Mat = this.door.LoadMaterial();
    this.tmplistEquip.Clear();
    this.TableCount = this.DM.ActivitylistEquip.Count;
    for (int index = 0; index < this.TableCount; ++index)
      this.tmplistEquip.Add(this.DM.ActivitylistEquip[index]);
    CString cstring = StringManager.Instance.StaticString1024();
    cstring.Append("UI/UI_forge_equip_pop");
    this.mAB = AssetManager.GetAssetBundle(cstring, out this.mABeKey);
    if ((Object) this.mAB != (Object) null)
    {
      this.m_ListMat = this.mAB.Load("UI_forge_equip_pop_m", typeof (Material)) as Material;
      Object[] objectArray = this.mAB.LoadAll(typeof (Sprite));
      for (int index3 = 0; index3 < this.TableCount; ++index3)
      {
        cstring.ClearString();
        this.tmpME = this.DM.MallEquipmantTable.GetRecordByKey(this.tmplistEquip[index3]);
        cstring.IntToFormat((long) this.tmpME.EquipIcon, 3);
        cstring.AppendFormat("UI_fc_sbut_{0}");
        for (int index4 = 0; index4 < objectArray.Length; ++index4)
        {
          if (DataManager.CompareStr(objectArray[index4].name, cstring) == 0)
            this.tmpSpritelist.Add((Sprite) objectArray[index4]);
        }
      }
    }
    this.Tmp = this.GameT.GetChild(0).GetChild(0).GetChild(0);
    this.text_tmpStr[0] = this.Tmp.GetComponent<UIText>();
    this.text_tmpStr[0].font = this.TTFont;
    this.text_tmpStr[0].text = this.DM.mStringTable.GetStringByID(7403U);
    this.Tmp = this.GameT.GetChild(1);
    this.BG = this.Tmp.GetComponent<Image>();
    this.Tmp = this.GameT.GetChild(1).GetChild(0);
    this.text_Select = this.Tmp.GetComponent<UIText>();
    this.text_Select.font = this.TTFont;
    this.text_Select.text = this.DM.mStringTable.GetStringByID(7428U);
    this.Tmp = this.GameT.GetChild(2);
    for (int index = 0; index < 5; ++index)
    {
      Transform child = this.Tmp.GetChild(7 + index);
      this.btn_Color[index] = child.GetComponent<UIButton>();
      this.btn_Color[index].m_Handler = (IUIButtonClickHandler) this;
      this.btn_Color[index].m_BtnID1 = 1 + index;
      this.btn_Color[index].m_EffectType = e_EffectType.e_Scale;
      this.btn_Color[index].transition = (Selectable.Transition) 0;
    }
    this.SelectColorT = this.Tmp.GetChild(7).GetChild(0);
    this.Img_SelectColor = this.Tmp.GetChild(7).GetChild(0).GetComponent<Image>();
    this.text_tmpStr[1] = this.Tmp.GetChild(0).GetChild(0).GetComponent<UIText>();
    this.text_tmpStr[1].font = this.TTFont;
    this.text_tmpStr[1].text = this.DM.mStringTable.GetStringByID(7407U);
    this.Tmp = this.Tmp.GetChild(1).GetChild(0);
    this.text_tmpStr[2] = this.Tmp.GetComponent<UIText>();
    this.text_tmpStr[2].font = this.TTFont;
    this.text_tmpStr[2].text = this.DM.mStringTable.GetStringByID(7429U);
    this.Tmp = this.GameT.GetChild(3).GetChild(0);
    this.m_ScrollPanel_Activity = this.Tmp.GetComponent<ScrollPanel>();
    this.m_ScrollPanel_Activity.m_ScrollPanelID = 1;
    this.Tmp = this.GameT.GetChild(3).GetChild(1).GetChild(0);
    this.Tmp.GetComponent<UIButton>().m_BtnID1 = 7;
    this.tmpImg = this.GameT.GetChild(3).GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();
    if (this.m_AssetBundleKey != 0 && (Object) this.m_ListMat != (Object) null)
      ((MaskableGraphic) this.tmpImg).material = this.m_ListMat;
    this.Tmp = this.GameT.GetChild(3).GetChild(1).GetChild(0).GetChild(0).GetChild(0);
    this.Tmp.GetComponent<UIText>().font = this.TTFont;
    for (int index = 0; index < this.TableCount; ++index)
      this.tmplist_A.Add(79f);
    this.m_ScrollPanel_Activity.IntiScrollPanel(363f, 0.0f, 0.0f, this.tmplist_A, 7, (IUpDateScrollPanel) this);
    this.mContentRT = this.m_ScrollPanel_Activity.transform.GetChild(0).GetComponent<RectTransform>();
    this.Tmp = this.GameT.GetChild(4);
    this.m_ScrollPanel = this.Tmp.GetComponent<ScrollPanel>();
    this.m_ScrollPanel.m_ScrollPanelID = 2;
    this.Tmp = this.GameT.GetChild(5);
    this.tmpLebtn = this.Tmp.GetChild(2).GetComponent<UILEBtn>();
    this.tmpLebtn.m_Handler = (IUILEBtnClickHandler) this;
    this.GUIM.InitLordEquipImg(((Component) this.tmpLebtn).transform, (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    this.Tmp.GetChild(3).GetChild(5).GetComponent<UIText>().font = this.TTFont;
    this.Tmp.GetChild(3).GetChild(6).GetComponent<UIText>().font = this.TTFont;
    this.Tmp.GetChild(3).GetChild(7).GetComponent<UIText>().font = this.TTFont;
    this.tmpImg = this.Tmp.GetChild(4).GetComponent<Image>();
    if (this.GUIM.IsArabic)
      ((Component) this.tmpImg).transform.localScale = new Vector3(-1f, ((Component) this.tmpImg).transform.localScale.y, ((Component) this.tmpImg).transform.localScale.z);
    UIButton component1 = this.Tmp.GetChild(5).GetComponent<UIButton>();
    component1.m_Handler = (IUIButtonClickHandler) this;
    component1.m_BtnID1 = 6;
    component1.m_EffectType = e_EffectType.e_Scale;
    component1.transition = (Selectable.Transition) 0;
    UIText component2 = this.Tmp.GetChild(5).GetChild(0).GetComponent<UIText>();
    component2.font = this.TTFont;
    component2.text = this.DM.mStringTable.GetStringByID(7410U);
    for (int index = 0; index < 6; ++index)
    {
      this.Tmp.GetChild(7 + index).GetChild(0).GetComponent<UIText>().font = this.TTFont;
      this.Tmp.GetChild(7 + index).GetChild(1).GetComponent<UIText>().font = this.TTFont;
    }
    this.tmplist.Clear();
    for (int index = 0; index < 6; ++index)
      this.tmplist.Add(212f);
    this.m_ScrollPanel.IntiScrollPanel(490f, 11f, 0.0f, this.tmplist, 6, (IUpDateScrollPanel) this);
    this.tmpImg = this.GameT.GetChild(6).GetComponent<Image>();
    this.tmpImg.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) this.tmpImg).material = this.m_Mat;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.btn_EXIT = this.GameT.GetChild(6).GetChild(0).GetComponent<UIButton>();
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

  public void CheckReOpen(bool brelogin = false)
  {
    if (this.DM.mLordEquip == null || this.DM.mLordEquip.ForgeActivity_mKind == (byte) 0 || (int) this.DM.mLordEquip.ForgeActivity_mKind > this.tmplistEquip.Count)
      return;
    this.mActivityIdx = this.DM.mLordEquip.ForgeActivity_mKind;
    this.mColor = this.DM.mLordEquip.ForgeActivity_mColor;
    this.tmplist.Clear();
    this.tmplistData.Clear();
    this.mItemActivityIdx = (int) this.mActivityIdx - 1;
    this.mItemActivityIdx2 = ((int) this.mActivityIdx - 1) % 7;
    this.tmpME = this.DM.MallEquipmantTable.GetRecordByKey(this.tmplistEquip[(int) this.mActivityIdx - 1]);
    for (int index = 0; index < 10; ++index)
    {
      if (this.tmpME.ItemId[index] != (ushort) 0)
        this.tmplistData.Add(this.tmpME.ItemId[index]);
    }
    if (this.DM.ActivityEquipListIdx.Count > 0)
    {
      for (int index1 = 0; index1 < this.DM.ActivityEquipListIdx.Count; ++index1)
      {
        MallEquipmant recordByKey = this.DM.MallEquipmantTable.GetRecordByKey(this.DM.ActivityEquipListIdx[index1].Key);
        if ((int) recordByKey.EquipIcon == (int) this.tmpME.EquipIcon)
        {
          for (int index2 = 0; index2 < 10; ++index2)
          {
            if (recordByKey.ItemId[index2] != (ushort) 0)
              this.tmplistData.Add(recordByKey.ItemId[index2]);
          }
        }
      }
    }
    this.SelectColorT.gameObject.SetActive(true);
    this.ShowTimeSelectColor = 0.0f;
    this.SelectColorT.SetParent(((Component) this.btn_Color[(int) this.mColor]).transform, false);
    this.mSortItem.SortType = (byte) 1;
    this.mSortItem.SortColor = this.mColor;
    this.tmplistData.Sort((IComparer<ushort>) this.mSortItem);
    for (int index = 0; index < this.tmplistData.Count; ++index)
      this.SetListHeight(this.tmplistData[index]);
    this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
    this.m_ScrollPanel.gameObject.SetActive(true);
    ((Component) this.BG).gameObject.SetActive(false);
    this.m_ScrollPanel.GoTo(this.DM.mLordEquip.ForgeActivity_ScrollIdx);
    if (brelogin)
      return;
    this.m_ScrollPanel_Activity.GoTo(this.DM.mLordEquip.ForgeActivity_KindScrollIdx, this.DM.mLordEquip.ForgeActivity_KindScroll_Y);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelId == 1)
    {
      if ((Object) this.tmpItem_A[panelObjectIdx] == (Object) null)
      {
        this.tmpItem_A[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
        this.tmpItem_A[panelObjectIdx].m_BtnID2 = panelObjectIdx;
        this.btn_ActivityEquip[panelObjectIdx] = item.transform.GetChild(0).GetComponent<UIButton>();
        this.btn_ActivityEquip[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
        this.tmpImg_btn[panelObjectIdx] = item.transform.GetChild(0).GetChild(0).GetComponent<Image>();
        this.text_Item_A_Name[panelObjectIdx] = item.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<UIText>();
        this.tmpImgSelect_btn[panelObjectIdx] = item.transform.GetChild(0).GetChild(1).GetComponent<Image>();
      }
      if (this.tmpSpritelist.Count > dataIdx)
        this.tmpImg_btn[panelObjectIdx].sprite = this.tmpSpritelist[dataIdx];
      if ((Object) this.tmpImg_btn[panelObjectIdx].sprite == (Object) null)
        ((Graphic) this.tmpImg_btn[panelObjectIdx]).color = new Color(1f, 1f, 1f, 0.0f);
      else
        ((Graphic) this.tmpImg_btn[panelObjectIdx]).color = new Color(1f, 1f, 1f, 1f);
      this.tmpME = this.DM.MallEquipmantTable.GetRecordByKey(this.tmplistEquip[dataIdx]);
      this.text_Item_A_Name[panelObjectIdx].text = this.DM.mStringTable.GetStringByID((uint) this.tmpME.EquipName);
      if (this.mItemActivityIdx == dataIdx)
      {
        ((Component) this.tmpImgSelect_btn[panelObjectIdx]).gameObject.SetActive(true);
        this.ItemActivitySelect = 0.0f;
        this.mItemActivityIdx2 = panelObjectIdx;
      }
      else
      {
        ((Component) this.tmpImgSelect_btn[panelObjectIdx]).gameObject.SetActive(false);
        ((Graphic) this.tmpImgSelect_btn[panelObjectIdx]).color = new Color(1f, 1f, 1f, 0.0f);
      }
    }
    else
    {
      if ((Object) this.tmpItem[panelObjectIdx] == (Object) null)
      {
        this.tmpItem[panelObjectIdx] = item.GetComponent<ScrollPanelItem>();
        this.ItemBG_RC[panelObjectIdx] = item.transform.GetChild(0).GetComponent<RectTransform>();
        this.ItemLine_RC[panelObjectIdx] = item.transform.GetChild(6).GetComponent<RectTransform>();
        this.tmp_ItemLebtn[panelObjectIdx] = item.transform.GetChild(2).GetComponent<UILEBtn>();
        this.tmpImg_ItemEnough[panelObjectIdx] = item.transform.GetChild(4).GetComponent<Image>();
        this.btn_ForgingEquip[panelObjectIdx] = item.transform.GetChild(5).GetComponent<UIButton>();
        this.btn_ForgingEquip[panelObjectIdx].m_Handler = (IUIButtonClickHandler) this;
        this.text_Itembtn[panelObjectIdx] = item.transform.GetChild(5).GetChild(0).GetComponent<UIText>();
        this.text_ItemName[panelObjectIdx] = item.transform.GetChild(3).GetChild(5).GetComponent<UIText>();
        this.text_ItemLv[panelObjectIdx] = item.transform.GetChild(3).GetChild(6).GetComponent<UIText>();
        this.tmpImg_ItemIcon[panelObjectIdx] = item.transform.GetChild(3).GetChild(0).GetComponent<Image>();
        for (int index = 0; index < 4; ++index)
          this.tmpImg_Items[panelObjectIdx][index] = item.transform.GetChild(3).GetChild(1 + index).GetComponent<Image>();
        for (int index = 0; index < 6; ++index)
        {
          this.text_ItemEffect[panelObjectIdx][index] = item.transform.GetChild(7 + index).GetChild(0).GetComponent<UIText>();
          this.text_ItemEffect_V[panelObjectIdx][index] = item.transform.GetChild(7 + index).GetChild(1).GetComponent<UIText>();
        }
      }
      if (this.tmplistData.Count <= dataIdx)
        return;
      this.tmpItem[panelObjectIdx].m_BtnID2 = panelObjectIdx;
      this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.tmplistData[dataIdx]);
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
      this.Cstr_ItemLv[panelObjectIdx].StringToFormat(this.DM.mStringTable.GetStringByID((uint) (ushort) (7410U + (uint) this.tmpEQ.EquipKind)));
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
        this.Cstr_Effect_V[panelObjectIdx][index].ClearString();
        GameConstants.GetEffectValue(this.Cstr_Effect_V[panelObjectIdx][index], this.effectList[index].EffectID, (uint) this.effectList[index].EffectValue, (byte) 3, 0.0f);
        this.text_ItemEffect_V[panelObjectIdx][index].text = this.Cstr_Effect_V[panelObjectIdx][index].ToString();
        this.text_ItemEffect_V[panelObjectIdx][index].SetAllDirty();
        this.text_ItemEffect_V[panelObjectIdx][index].cachedTextGenerator.Invalidate();
      }
      int count = this.effectList.Count;
      for (int index = 0; index < count; ++index)
        item.transform.GetChild(7 + index).gameObject.SetActive(true);
      for (int index = count; index < 6; ++index)
        item.transform.GetChild(7 + index).gameObject.SetActive(false);
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
          this.tmpImg_ItemIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[((int) this.tmpEQ.EquipKind - 21) * 2];
          this.bShowMainEquip = true;
        }
        else
          this.tmpImg_ItemIcon[panelObjectIdx].sprite = this.SArray.m_Sprites[((int) this.tmpEQ.EquipKind - 21) * 2 + 1];
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
    if (this.mActivityIdx != byte.MaxValue)
    {
      this.DM.mLordEquip.ForgeActivity_mColor = this.mColor;
      this.DM.mLordEquip.ForgeActivity_mKind = this.mActivityIdx;
      this.DM.mLordEquip.ForgeActivity_ScrollIdx = this.m_ScrollPanel.GetTopIdx();
      if (this.DM.mLordEquip.ForgeActivity_ScrollIdx < 0)
        this.DM.mLordEquip.ForgeActivity_ScrollIdx = 0;
      this.DM.mLordEquip.ForgeActivity_KindScrollIdx = this.m_ScrollPanel_Activity.GetTopIdx();
      if (this.DM.mLordEquip.ForgeActivity_KindScrollIdx < 0)
        this.DM.mLordEquip.ForgeActivity_KindScrollIdx = 0;
      this.DM.mLordEquip.ForgeActivity_KindScroll_Y = this.mContentRT.anchoredPosition.y;
    }
    if (this.mABeKey == 0)
      return;
    this.m_ListMat = (Material) null;
    this.tmpSpritelist.Clear();
    AssetManager.UnloadAssetBundle(this.mABeKey);
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
        if (this.mActivityIdx == byte.MaxValue)
        {
          this.GUIM.AddHUDMessage(this.DM.mStringTable.GetStringByID(7508U), (ushort) byte.MaxValue);
          break;
        }
        this.mColor = (byte) (sender.m_BtnID1 - 1);
        this.SelectColorT.SetParent(((Component) this.btn_Color[(int) this.mColor]).transform, false);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist, false);
        this.DM.mLordEquip.ForgeActivity_mColor = this.mColor;
        this.DM.mLordEquip.ForgeActivity_mKind = this.mActivityIdx;
        break;
      case 6:
        this.Tmp = ((Component) sender).gameObject.transform.parent;
        this.tmpEQ = this.DM.EquipTable.GetRecordByKey(this.tmplistData[this.Tmp.GetComponent<ScrollPanelItem>().m_BtnID1]);
        UIAnvil.SetOpen(eUI_Anvil_OpenKind.ForgeNewItem, (int) this.tmpEQ.EquipKey, 1 + (int) this.mColor);
        break;
      case 7:
        this.Tmp = ((Component) sender).gameObject.transform.parent;
        int btnId1 = this.Tmp.GetComponent<ScrollPanelItem>().m_BtnID1;
        if (this.mItemActivityIdx != -1)
        {
          ((Component) this.tmpImgSelect_btn[this.mItemActivityIdx2]).gameObject.SetActive(false);
          ((Graphic) this.tmpImgSelect_btn[this.mItemActivityIdx2]).color = new Color(1f, 1f, 1f, 0.0f);
        }
        this.mItemActivityIdx = btnId1;
        this.mItemActivityIdx2 = this.Tmp.GetComponent<ScrollPanelItem>().m_BtnID2;
        ((Component) this.tmpImgSelect_btn[this.mItemActivityIdx2]).gameObject.SetActive(true);
        this.ItemActivitySelect = 0.0f;
        this.mActivityIdx = (byte) (btnId1 + 1);
        if ((int) this.DM.mLordEquip.ForgeActivity_mKind == (int) this.mActivityIdx)
          break;
        this.tmplist.Clear();
        this.tmplistData.Clear();
        this.tmpME = this.DM.MallEquipmantTable.GetRecordByKey(this.tmplistEquip[btnId1]);
        for (int index = 0; index < 10; ++index)
        {
          if (this.tmpME.ItemId[index] != (ushort) 0)
            this.tmplistData.Add(this.tmpME.ItemId[index]);
        }
        if (this.DM.ActivityEquipListIdx.Count > 0)
        {
          for (int index1 = 0; index1 < this.DM.ActivityEquipListIdx.Count; ++index1)
          {
            MallEquipmant recordByKey = this.DM.MallEquipmantTable.GetRecordByKey(this.DM.ActivityEquipListIdx[index1].Key);
            if ((int) recordByKey.EquipIcon == (int) this.tmpME.EquipIcon)
            {
              for (int index2 = 0; index2 < 10; ++index2)
              {
                if (recordByKey.ItemId[index2] != (ushort) 0)
                  this.tmplistData.Add(recordByKey.ItemId[index2]);
              }
            }
          }
        }
        this.SelectColorT.gameObject.SetActive(true);
        this.ShowTimeSelectColor = 0.0f;
        this.SelectColorT.SetParent(((Component) this.btn_Color[(int) this.mColor]).transform, false);
        this.mSortItem.SortType = (byte) 1;
        this.mSortItem.SortColor = this.mColor;
        this.tmplistData.Sort((IComparer<ushort>) this.mSortItem);
        for (int index = 0; index < this.tmplistData.Count; ++index)
          this.SetListHeight(this.tmplistData[index]);
        this.m_ScrollPanel.AddNewDataHeight(this.tmplist);
        this.m_ScrollPanel.gameObject.SetActive(true);
        ((Component) this.BG).gameObject.SetActive(false);
        this.DM.mLordEquip.ForgeActivity_mColor = this.mColor;
        this.DM.mLordEquip.ForgeActivity_mKind = this.mActivityIdx;
        break;
    }
  }

  public void SetListHeight(ushort Idx)
  {
    this.tmpEQ = this.DM.EquipTable.GetRecordByKey(Idx);
    int num = 0;
    for (int index = 0; index < 6; ++index)
    {
      if (this.tmpEQ.PropertiesInfo[index].Propertieskey != (ushort) 0)
        ++num;
    }
    this.tmplist.Add((float) (98 + num * 24));
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        if (this.DM.mLordEquip.LoadLordEquip())
          break;
        this.bEqDataReq = true;
        if (!this.DM.mLordEquip.LoadLEMaterial())
          this.bMaterialDataReq = true;
        if (!this.bEqDataReq || !this.bMaterialDataReq)
          break;
        this.CheckReOpen(true);
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
    for (int index = 0; index < 3; ++index)
    {
      if ((Object) this.text_tmpStr[index] != (Object) null && ((Behaviour) this.text_tmpStr[index]).enabled)
      {
        ((Behaviour) this.text_tmpStr[index]).enabled = false;
        ((Behaviour) this.text_tmpStr[index]).enabled = true;
      }
    }
    for (int index1 = 0; index1 < 6; ++index1)
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
    for (int index = 0; index < 7; ++index)
    {
      if ((Object) this.text_Item_A_Name[index] != (Object) null && ((Behaviour) this.text_Item_A_Name[index]).enabled)
      {
        ((Behaviour) this.text_Item_A_Name[index]).enabled = false;
        ((Behaviour) this.text_Item_A_Name[index]).enabled = true;
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
        {
          this.bMaterialDataReq = true;
          break;
        }
        if (!this.bEqDataReq || !this.bMaterialDataReq)
          break;
        this.CheckReOpen();
        break;
      case 2:
        if (this.DM.mLordEquip.LoadLordEquip() || this.DM.mLordEquip.LoadLEMaterial())
          break;
        this.CheckReOpen();
        break;
      case 3:
        this.tmplistEquip.Clear();
        this.tmpSpritelist.Clear();
        this.TableCount = this.DM.ActivitylistEquip.Count;
        for (int index = 0; index < this.TableCount; ++index)
          this.tmplistEquip.Add(this.DM.ActivitylistEquip[index]);
        CString StrB = StringManager.Instance.StaticString1024();
        if ((Object) this.mAB != (Object) null)
        {
          Object[] objectArray = this.mAB.LoadAll(typeof (Sprite));
          for (int index1 = 0; index1 < this.TableCount; ++index1)
          {
            StrB.ClearString();
            this.tmpME = this.DM.MallEquipmantTable.GetRecordByKey(this.tmplistEquip[index1]);
            StrB.IntToFormat((long) this.tmpME.EquipIcon, 3);
            StrB.AppendFormat("UI_fc_sbut_{0}");
            for (int index2 = 0; index2 < objectArray.Length; ++index2)
            {
              if (DataManager.CompareStr(objectArray[index2].name, StrB) == 0)
                this.tmpSpritelist.Add((Sprite) objectArray[index2]);
            }
          }
        }
        this.tmplist_A.Clear();
        for (int index = 0; index < this.TableCount; ++index)
          this.tmplist_A.Add(79f);
        this.m_ScrollPanel_Activity.AddNewDataHeight(this.tmplist_A, false);
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
    if (this.SelectColorT.gameObject.activeSelf)
    {
      this.ShowTimeSelectColor += Time.smoothDeltaTime;
      if ((double) this.ShowTimeSelectColor >= 0.0)
      {
        if ((double) this.ShowTimeSelectColor >= 2.0)
          this.ShowTimeSelectColor = 0.0f;
        ((Graphic) this.Img_SelectColor).color = new Color(1f, 1f, 1f, (double) this.ShowTimeSelectColor <= 1.0 ? this.ShowTimeSelectColor : 2f - this.ShowTimeSelectColor);
      }
    }
    for (int index = 0; index < 7; ++index)
    {
      if ((Object) this.tmpImgSelect_btn[index] != (Object) null && ((Component) this.tmpImgSelect_btn[index]).gameObject.activeSelf)
      {
        this.ItemActivitySelect += Time.smoothDeltaTime;
        if ((double) this.ItemActivitySelect >= 0.0)
        {
          if ((double) this.ItemActivitySelect >= 2.0)
            this.ItemActivitySelect = 0.0f;
          float a = (double) this.ItemActivitySelect <= 1.0 ? this.ItemActivitySelect : 2f - this.ItemActivitySelect;
          ((Graphic) this.tmpImgSelect_btn[index]).color = new Color(1f, 1f, 1f, a);
        }
      }
    }
  }
}
