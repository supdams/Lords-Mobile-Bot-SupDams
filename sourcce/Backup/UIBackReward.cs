// Decompiled with JetBrains decompiler
// Type: UIBackReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using uTools;

#nullable disable
public class UIBackReward : 
  GUIWindow,
  UILoadImageHander,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private Transform m_transform;
  private Transform UnitObjectT;
  private DataManager DM;
  private GUIManager GM;
  private MallManager MM;
  private StringManager SM;
  private Font tmpFont;
  private Door m_door;
  public Image BackImage1;
  public Image BackImage2;
  public Image InfoImage;
  public UIText InfoText;
  public UIText TitleText;
  public Image Image1;
  public uTweenScale ScaleImage1;
  public UISpritesArray BuyOnceSA;
  public UIText Image1Text;
  public UISpritesArray RateSA;
  public UIText CrystalText;
  public Image CrystalImage;
  public RectTransform AllItemRC;
  public Transform[] ItemT;
  public Transform[] ItemT2;
  public UIText[] ItemText;
  public UIText[] ItemCountText;
  public UIButton[] Btn1;
  public UIButtonHint[] Hint1;
  private List<UIText> RefreshTextArray = new List<UIText>();
  private CString CrystalStr;
  private CString[] ItemCountStr = new CString[3];
  private int ItemCount = 3;

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
    GUIManager.Instance.UIQueueLock(EGUIQueueLock.UIQL_Mall);
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.MM = MallManager.Instance;
    this.SM = StringManager.Instance;
    this.m_transform = this.transform;
    this.tmpFont = this.GM.GetTTFFont();
    this.UnitObjectT = this.m_transform.GetChild(2);
    Transform child1 = this.UnitObjectT.GetChild(1);
    Transform child2 = child1.GetChild(5);
    if (this.GM.IsArabic)
      child1.GetComponent<RectTransform>().anchoredPosition = new Vector2(-130f, 0.0f);
    this.BackImage1 = this.UnitObjectT.GetChild(0).GetComponent<Image>();
    if (this.GM.IsArabic)
      ((Transform) ((Graphic) this.BackImage1).rectTransform).localScale = new Vector3(-1f, 1f, 1f);
    this.TitleText = child1.GetChild(0).GetComponent<UIText>();
    this.TitleText.font = this.tmpFont;
    this.TitleText.text = this.DM.mStringTable.GetStringByID(10166U);
    this.Image1 = child1.GetChild(1).GetComponent<Image>();
    this.ScaleImage1 = child1.GetChild(1).GetComponent<uTweenScale>();
    this.BuyOnceSA = child1.GetChild(1).GetComponent<UISpritesArray>();
    this.Image1Text = child1.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.Image1Text.font = this.tmpFont;
    this.Image1Text.text = this.DM.mStringTable.GetStringByID(10167U);
    ((Behaviour) this.Image1).enabled = true;
    ((Behaviour) this.Image1Text).enabled = true;
    this.CrystalImage = child1.GetChild(3).GetComponent<Image>();
    this.CrystalText = child1.GetChild(4).GetComponent<UIText>();
    this.CrystalText.font = this.tmpFont;
    this.CrystalStr = this.SM.SpawnString();
    UIText component1 = child1.GetChild(2).GetComponent<UIText>();
    component1.font = this.tmpFont;
    component1.text = this.DM.mStringTable.GetStringByID(838U);
    this.RefreshTextArray.Add(component1);
    child1.GetChild(6).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    UIText component2 = child1.GetChild(6).GetChild(0).GetComponent<UIText>();
    component2.font = this.tmpFont;
    component2.text = this.DM.mStringTable.GetStringByID(877U);
    this.RefreshTextArray.Add(component2);
    child1.GetChild(7).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    UIText component3 = child1.GetChild(7).GetChild(0).GetComponent<UIText>();
    component3.font = this.tmpFont;
    component3.text = this.DM.mStringTable.GetStringByID(10169U);
    this.RefreshTextArray.Add(component3);
    Transform child3 = this.UnitObjectT.GetChild(1).GetChild(5);
    this.GM.InitianHeroItemImg(child3.GetChild(0), eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
    this.GM.InitianHeroItemImg(child3.GetChild(2), eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
    this.GM.InitianHeroItemImg(child3.GetChild(4), eHeroOrItem.Item, (ushort) 1, (byte) 0, (byte) 0, bShowText: false);
    this.GM.InitLordEquipImg(child3.GetChild(1), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    this.GM.InitLordEquipImg(child3.GetChild(3), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    this.GM.InitLordEquipImg(child3.GetChild(5), (ushort) 0, (byte) 0, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    child3.GetChild(12).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
    child3.GetChild(13).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
    child3.GetChild(14).gameObject.AddComponent<UIButtonHint>().m_eHint = EUIButtonHint.CountDown;
    child3.GetChild(6).GetComponent<UIText>().font = this.tmpFont;
    child3.GetChild(9).GetComponent<UIText>().font = this.tmpFont;
    child3.GetChild(7).GetComponent<UIText>().font = this.tmpFont;
    child3.GetChild(10).GetComponent<UIText>().font = this.tmpFont;
    child3.GetChild(8).GetComponent<UIText>().font = this.tmpFont;
    child3.GetChild(11).GetComponent<UIText>().font = this.tmpFont;
    Transform child4 = this.UnitObjectT.GetChild(2);
    this.InfoText = child4.GetChild(0).GetComponent<UIText>();
    this.InfoText.font = this.tmpFont;
    this.InfoText.text = this.DM.mStringTable.GetStringByID(10168U);
    this.InfoImage = child4.GetComponent<Image>();
    if (this.GM.IsArabic)
      ((Graphic) this.InfoImage).rectTransform.anchoredPosition = new Vector2(252f, -134f);
    this.ItemT = new Transform[this.ItemCount];
    this.ItemT2 = new Transform[this.ItemCount];
    this.ItemText = new UIText[this.ItemCount];
    this.ItemCountText = new UIText[this.ItemCount];
    this.Btn1 = new UIButton[this.ItemCount];
    this.Hint1 = new UIButtonHint[this.ItemCount];
    for (int index = 0; index < this.ItemCount; ++index)
    {
      this.ItemT[index] = child2.GetChild(0 + index * 2);
      this.ItemT[index].GetComponent<UIHIBtn>().m_Handler = (IUIHIBtnClickHandler) this;
      this.ItemT2[index] = child2.GetChild(1 + index * 2);
      this.ItemText[index] = child2.GetChild(6 + index).GetComponent<UIText>();
      this.ItemCountText[index] = child2.GetChild(9 + index).GetComponent<UIText>();
      this.ItemCountStr[index] = this.SM.SpawnString();
      this.Btn1[index] = child2.GetChild(12 + index).GetComponent<UIButton>();
      this.Btn1[index].m_Handler = (IUIButtonClickHandler) this;
      this.Btn1[index].m_BtnID1 = 4;
      this.Hint1[index] = child2.GetChild(12 + index).GetComponent<UIButtonHint>();
      this.Hint1[index].m_Handler = (MonoBehaviour) this;
      this.Hint1[index].DelayTime = 0.2f;
    }
    this.RefreshAll();
    this.GM.UpdateUI(EGUIWindow.Door, 1, 1);
  }

  public override void OnClose()
  {
    if (this.CrystalStr != null)
      this.SM.DeSpawnString(this.CrystalStr);
    for (int index = 0; index < this.ItemCount; ++index)
    {
      if (this.ItemCountStr[index] != null)
        this.SM.DeSpawnString(this.ItemCountStr[index]);
    }
  }

  public void RefreshAll()
  {
    ComboBox recordByKey1 = this.DM.ComboBoxTable.GetRecordByKey(this.MM.BackRewardComboBoxID);
    uint x = 0;
    Equip recordByKey2;
    for (int index = 0; index < recordByKey1.ItemData.Length; ++index)
    {
      recordByKey2 = this.DM.EquipTable.GetRecordByKey(recordByKey1.ItemData[index].ItemID);
      if (recordByKey2.EquipKind == (byte) 11 && recordByKey2.PropertiesInfo[0].Propertieskey == (ushort) 6)
        x += (uint) recordByKey2.PropertiesInfo[1].Propertieskey * (uint) recordByKey2.PropertiesInfo[1].PropertiesValue * (uint) recordByKey1.ItemData[index].ItemCount;
    }
    if (x > 0U)
    {
      this.CrystalStr.Length = 0;
      this.CrystalStr.uLongToFormat((ulong) x, bNumber: true);
      this.CrystalStr.AppendFormat("{0}");
      this.CrystalText.text = this.CrystalStr.ToString();
      this.CrystalText.SetAllDirty();
      this.CrystalText.cachedTextGenerator.Invalidate();
      ((Component) this.CrystalText).gameObject.SetActive(true);
      ((Component) this.CrystalImage).gameObject.SetActive(true);
    }
    else
    {
      ((Component) this.CrystalText).gameObject.SetActive(false);
      ((Component) this.CrystalImage).gameObject.SetActive(false);
    }
    int index1 = 0;
    for (int index2 = 0; index1 < this.ItemCount && index2 < recordByKey1.ItemData.Length; ++index2)
    {
      recordByKey2 = DataManager.Instance.EquipTable.GetRecordByKey(recordByKey1.ItemData[index2].ItemID);
      if (recordByKey2.EquipKind != (byte) 11 || recordByKey2.PropertiesInfo[0].Propertieskey != (ushort) 6)
      {
        byte equipKind = recordByKey2.EquipKind;
        this.Btn1[index1].m_BtnID2 = (int) recordByKey1.ItemData[index2].ItemID;
        this.Hint1[index1].Parm1 = recordByKey1.ItemData[index2].ItemID;
        this.Hint1[index1].Parm2 = recordByKey1.ItemData[index2].Rank;
        bool flag = this.GM.IsLeadItem(equipKind);
        if (flag)
          GUIManager.Instance.ChangeLordEquipImg(this.ItemT2[index1], recordByKey1.ItemData[index2].ItemID, recordByKey1.ItemData[index2].Rank, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
        else
          GUIManager.Instance.ChangeHeroItemImg(this.ItemT[index1], eHeroOrItem.Item, recordByKey1.ItemData[index2].ItemID, (byte) 0, (byte) 0);
        if (flag || !this.MM.CheckCanOpenDetail(recordByKey1.ItemData[index2].ItemID))
          this.Hint1[index1].enabled = true;
        else
          this.Hint1[index1].enabled = false;
        this.ItemT[index1].gameObject.SetActive(!flag);
        this.ItemT2[index1].gameObject.SetActive(flag);
        this.ItemText[index1].text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey2.EquipName);
        ((Graphic) this.ItemText[index1]).color = this.MM.GetItemRankColor(recordByKey1.ItemData[index2].Rank);
        this.ItemCountStr[index1].Length = 0;
        StringManager.IntToStr(this.ItemCountStr[index1], (long) recordByKey1.ItemData[index2].ItemCount, bNumber: true);
        this.ItemCountText[index1].text = this.ItemCountStr[index1].ToString();
        this.ItemCountText[index1].SetAllDirty();
        this.ItemCountText[index1].cachedTextGenerator.Invalidate();
        ++index1;
      }
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        if (this.MM.BackRewardComboBoxID != (ushort) 0)
          break;
        if ((bool) (Object) this.door)
          this.door.CloseMenu();
        this.GM.UIQueueLockRelease(EGUIQueueLock.UIQL_Mall);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        for (int index = 0; index < this.RefreshTextArray.Count; ++index)
        {
          if ((Object) this.RefreshTextArray[index] != (Object) null && ((Behaviour) this.RefreshTextArray[index]).enabled)
          {
            ((Behaviour) this.RefreshTextArray[index]).enabled = false;
            ((Behaviour) this.RefreshTextArray[index]).enabled = true;
          }
        }
        if ((Object) this.InfoText != (Object) null && ((Behaviour) this.InfoText).enabled)
        {
          ((Behaviour) this.InfoText).enabled = false;
          ((Behaviour) this.InfoText).enabled = true;
        }
        if ((Object) this.TitleText != (Object) null && ((Behaviour) this.TitleText).enabled)
        {
          ((Behaviour) this.TitleText).enabled = false;
          ((Behaviour) this.TitleText).enabled = true;
        }
        if ((Object) this.Image1Text != (Object) null && ((Behaviour) this.Image1Text).enabled)
        {
          ((Behaviour) this.Image1Text).enabled = false;
          ((Behaviour) this.Image1Text).enabled = true;
        }
        if ((Object) this.CrystalText != (Object) null && ((Behaviour) this.CrystalText).enabled)
        {
          ((Behaviour) this.CrystalText).enabled = false;
          ((Behaviour) this.CrystalText).enabled = true;
        }
        for (int index = 0; index < this.ItemCount; ++index)
        {
          if ((Object) this.ItemText[index] != (Object) null && ((Behaviour) this.ItemText[index]).enabled)
          {
            ((Behaviour) this.ItemText[index]).enabled = false;
            ((Behaviour) this.ItemText[index]).enabled = true;
          }
          if ((Object) this.ItemCountText[index] != (Object) null && ((Behaviour) this.ItemCountText[index]).enabled)
          {
            ((Behaviour) this.ItemCountText[index]).enabled = false;
            ((Behaviour) this.ItemCountText[index]).enabled = true;
          }
        }
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1)
    {
      if (sender.m_BtnID2 == 1)
      {
        if (!(bool) (Object) this.door)
          return;
        this.door.OpenMenu(EGUIWindow.UIBackReward_Detail);
      }
      else
      {
        if (sender.m_BtnID2 != 2)
          return;
        this.MM.Send_PUSHBACK_PRIZE();
      }
    }
    else
    {
      if (sender.m_BtnID1 != 4 || !this.MM.OpenDetail((ushort) sender.m_BtnID2))
        return;
      AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    if (!this.MM.OpenDetail(sender.HIID))
      return;
    AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    if (!(bool) (Object) this.door)
      return;
    img.sprite = this.door.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = this.door.LoadMaterial();
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (this.GM.IsLeadItem(this.DM.EquipTable.GetRecordByKey(sender.Parm1).EquipKind))
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
    if (this.GM.IsLeadItem(this.DM.EquipTable.GetRecordByKey(sender.Parm1).EquipKind))
      this.GM.m_LordInfo.Hide(sender);
    else
      this.GM.m_SimpleItemInfo.Hide(sender);
  }

  public override bool OnBackButtonClick() => true;
}
