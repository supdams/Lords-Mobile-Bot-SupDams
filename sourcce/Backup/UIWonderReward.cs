// Decompiled with JetBrains decompiler
// Type: UIWonderReward
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIWonderReward : 
  GUIWindow,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUILEBtnClickHandler
{
  private Transform GameT;
  private Transform Tmp;
  private Transform Tmp1;
  private DataManager DM;
  private GUIManager GUIM;
  private ActivityManager ActM;
  private Font TTFont;
  private Door door;
  private Material mMaT;
  private UIButton btn_EXIT;
  private Image tmpImg;
  private UIText text_Title;
  private UIText text_Info;
  private UIText[] text_Str = new UIText[5];
  private UIHIBtn[] btn_Itme = new UIHIBtn[2];
  private UILEBtn btn_Item_L;
  private CString[] m_CStr = new CString[5];
  private ushort[] ItemID = new ushort[3];
  private UIButtonHint tmphint;
  private int mOpenType;

  public override void OnOpen(int arg1, int arg2)
  {
    this.mOpenType = arg1;
    this.DM = DataManager.Instance;
    this.GUIM = GUIManager.Instance;
    this.ActM = ActivityManager.Instance;
    this.GameT = this.gameObject.transform;
    this.TTFont = this.GUIM.GetTTFFont();
    this.door = this.GUIM.FindMenu(EGUIWindow.Door) as Door;
    this.mMaT = this.door.LoadMaterial();
    CString SpriteName = StringManager.Instance.StaticString1024();
    for (int index = 0; index < 5; ++index)
      this.m_CStr[index] = StringManager.Instance.SpawnString(50);
    this.Tmp = this.GameT.GetChild(1);
    this.Tmp1 = this.Tmp.GetChild(0);
    this.text_Info = this.Tmp1.GetComponent<UIText>();
    this.text_Info.font = this.TTFont;
    this.Tmp = this.GameT.GetChild(2);
    this.Tmp1 = this.Tmp.GetChild(0);
    this.text_Title = this.Tmp1.GetComponent<UIText>();
    this.text_Title.font = this.TTFont;
    this.Tmp = this.GameT.GetChild(4);
    this.Tmp1 = this.Tmp.GetChild(2);
    this.btn_Item_L = this.Tmp1.GetComponent<UILEBtn>();
    Array.Clear((Array) this.ItemID, 0, this.ItemID.Length);
    int x1 = 0;
    int x2 = 0;
    byte color = 0;
    if (this.mOpenType == 0)
    {
      KOFPrizeData recordByKey = this.DM.KOFPrize.GetRecordByKey(ActivityManager.Instance.KOWData.EventPrizeID);
      if (recordByKey.PrizeItem != null)
      {
        for (int index = 0; index < 3; ++index)
          this.ItemID[index] = recordByKey.PrizeItem[index].ItemID;
        color = recordByKey.PrizeItem[0].ItemRank;
        x1 = (int) recordByKey.PrizeItem[1].ItemNum;
        x2 = (int) recordByKey.PrizeItem[2].ItemNum;
      }
      this.text_Info.text = this.DM.mStringTable.GetStringByID(11022U);
      this.text_Title.text = this.DM.mStringTable.GetStringByID(11026U);
    }
    else
    {
      for (int index = 0; index < 3; ++index)
        this.ItemID[index] = this.ActM.RewardRankingPrize[index].ItemID;
      color = this.ActM.RewardRankingPrize[0].Rank;
      x1 = (int) this.ActM.RewardRankingPrize[1].Num;
      x2 = (int) this.ActM.RewardRankingPrize[2].Num;
      this.text_Info.text = this.DM.mStringTable.GetStringByID(11083U);
      this.text_Title.text = this.DM.mStringTable.GetStringByID(11058U);
    }
    Equip recordByKey1 = this.DM.EquipTable.GetRecordByKey(this.ItemID[0]);
    this.GUIM.InitLordEquipImg(((Component) this.btn_Item_L).transform, this.ItemID[0], color, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    this.tmphint = ((Component) this.btn_Item_L).gameObject.AddComponent<UIButtonHint>();
    this.tmphint.m_eHint = EUIButtonHint.UILeBtn;
    this.tmphint.m_DownUpHandler = (IUIButtonDownUpHandler) this;
    this.tmphint.Parm1 = recordByKey1.EquipKey;
    this.tmphint.Parm2 = color;
    for (int index = 0; index < 2; ++index)
    {
      this.Tmp1 = this.Tmp.GetChild(5 + index);
      this.btn_Itme[index] = this.Tmp1.GetComponent<UIHIBtn>();
      this.GUIM.InitianHeroItemImg(((Component) this.btn_Itme[index]).transform, eHeroOrItem.Item, (ushort) 0, (byte) 0, (byte) 0);
    }
    for (int index = 0; index < 5; ++index)
    {
      this.Tmp1 = this.Tmp.GetChild(7 + index);
      this.text_Str[index] = this.Tmp1.GetComponent<UIText>();
      this.text_Str[index].font = this.TTFont;
    }
    this.m_CStr[4].ClearString();
    this.m_CStr[4].Append(this.DM.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
    this.text_Str[4].text = this.m_CStr[4].ToString();
    this.text_Str[4].SetAllDirty();
    this.text_Str[4].cachedTextGenerator.Invalidate();
    this.m_CStr[0].ClearString();
    this.m_CStr[0].IntToFormat((long) x1, bNumber: true);
    if (this.GUIM.IsArabic)
      this.m_CStr[0].AppendFormat("{0}x");
    else
      this.m_CStr[0].AppendFormat("x{0}");
    this.text_Str[0].text = this.m_CStr[0].ToString();
    this.text_Str[0].SetAllDirty();
    this.text_Str[0].cachedTextGenerator.Invalidate();
    recordByKey1 = this.DM.EquipTable.GetRecordByKey(this.ItemID[1]);
    byte equipKind1 = recordByKey1.EquipKind;
    this.m_CStr[1].ClearString();
    this.GUIM.ChangeHeroItemImg(((Component) this.btn_Itme[0]).transform, eHeroOrItem.Item, this.ItemID[1], (byte) 0, (byte) 0);
    if (equipKind1 == (byte) 11)
    {
      this.m_CStr[1].StringToFormat(this.GetItemStr(recordByKey1.PropertiesInfo[0].Propertieskey));
      this.m_CStr[1].IntToFormat((long) ((int) recordByKey1.PropertiesInfo[1].Propertieskey * (int) recordByKey1.PropertiesInfo[1].PropertiesValue * x1), bNumber: true);
      if (this.GUIM.IsArabic)
        this.m_CStr[1].AppendFormat("{1} {0}");
      else
        this.m_CStr[1].AppendFormat("{0} {1}");
    }
    this.text_Str[1].text = this.m_CStr[1].ToString();
    this.text_Str[1].SetAllDirty();
    this.text_Str[1].cachedTextGenerator.Invalidate();
    this.m_CStr[2].ClearString();
    this.m_CStr[2].IntToFormat((long) x2, bNumber: true);
    if (this.GUIM.IsArabic)
      this.m_CStr[2].AppendFormat("{0}x");
    else
      this.m_CStr[2].AppendFormat("x{0}");
    this.text_Str[2].text = this.m_CStr[2].ToString();
    this.text_Str[2].SetAllDirty();
    this.text_Str[2].cachedTextGenerator.Invalidate();
    recordByKey1 = this.DM.EquipTable.GetRecordByKey(this.ItemID[2]);
    byte equipKind2 = recordByKey1.EquipKind;
    this.m_CStr[3].ClearString();
    this.GUIM.ChangeHeroItemImg(((Component) this.btn_Itme[1]).transform, eHeroOrItem.Item, this.ItemID[2], (byte) 0, (byte) 0);
    if (equipKind2 == (byte) 11)
    {
      this.m_CStr[3].StringToFormat(this.GetItemStr(recordByKey1.PropertiesInfo[0].Propertieskey));
      this.m_CStr[3].IntToFormat((long) ((int) recordByKey1.PropertiesInfo[1].Propertieskey * (int) recordByKey1.PropertiesInfo[1].PropertiesValue * x2), bNumber: true);
      if (this.GUIM.IsArabic)
        this.m_CStr[3].AppendFormat("{1} {0}");
      else
        this.m_CStr[3].AppendFormat("{0} {1}");
    }
    this.text_Str[3].text = this.m_CStr[3].ToString();
    this.text_Str[3].SetAllDirty();
    this.text_Str[3].cachedTextGenerator.Invalidate();
    this.Tmp = this.GameT.GetChild(5);
    this.tmpImg = this.Tmp.GetComponent<Image>();
    SpriteName.ClearString();
    SpriteName.AppendFormat("UI_main_close_base");
    this.tmpImg.sprite = this.door.LoadSprite(SpriteName);
    ((MaskableGraphic) this.tmpImg).material = this.mMaT;
    if (this.GUIM.bOpenOnIPhoneX)
      ((Behaviour) this.tmpImg).enabled = false;
    this.Tmp = this.GameT.GetChild(5).GetChild(0);
    this.btn_EXIT = this.Tmp.GetComponent<UIButton>();
    SpriteName.ClearString();
    SpriteName.AppendFormat("UI_main_close");
    this.btn_EXIT.image.sprite = this.door.LoadSprite(SpriteName);
    ((MaskableGraphic) this.btn_EXIT.image).material = this.mMaT;
    this.btn_EXIT.m_Handler = (IUIButtonClickHandler) this;
    this.btn_EXIT.m_BtnID1 = 0;
    this.btn_EXIT.m_EffectType = e_EffectType.e_Scale;
    this.btn_EXIT.transition = (Selectable.Transition) 0;
    this.GUIM.UpdateUI(EGUIWindow.Door, 1, 2);
    if (this.mOpenType != 0)
      return;
    GUIManager.Instance.m_LordInfo.HideEquipVal = true;
  }

  public override void OnClose()
  {
    GUIManager.Instance.m_LordInfo.HideEquipVal = false;
    for (int index = 0; index < 5; ++index)
    {
      if (this.m_CStr[index] != null)
        StringManager.Instance.DeSpawnString(this.m_CStr[index]);
    }
  }

  public void RefreshItem()
  {
    Array.Clear((Array) this.ItemID, 0, this.ItemID.Length);
    int x1 = 0;
    int x2 = 0;
    byte color = 0;
    if (this.mOpenType == 0)
    {
      KOFPrizeData recordByKey = this.DM.KOFPrize.GetRecordByKey(ActivityManager.Instance.KOWData.EventPrizeID);
      if (recordByKey.PrizeItem != null)
      {
        for (int index = 0; index < 3; ++index)
          this.ItemID[index] = recordByKey.PrizeItem[index].ItemID;
        color = recordByKey.PrizeItem[0].ItemRank;
        x1 = (int) recordByKey.PrizeItem[1].ItemNum;
        x2 = (int) recordByKey.PrizeItem[2].ItemNum;
      }
    }
    else
    {
      for (int index = 0; index < 3; ++index)
        this.ItemID[index] = this.ActM.RewardRankingPrize[index].ItemID;
      color = this.ActM.RewardRankingPrize[0].Rank;
      x1 = (int) this.ActM.RewardRankingPrize[1].Num;
      x2 = (int) this.ActM.RewardRankingPrize[2].Num;
    }
    Equip recordByKey1 = this.DM.EquipTable.GetRecordByKey(this.ItemID[0]);
    this.GUIM.ChangeLordEquipImg(((Component) this.btn_Item_L).transform, this.ItemID[0], color, gem1: (ushort) 0, gem2: (ushort) 0, gem3: (ushort) 0, gem4: (ushort) 0, Quantity: (ushort) 0);
    this.tmphint.Parm1 = recordByKey1.EquipKey;
    this.tmphint.Parm2 = color;
    this.m_CStr[4].ClearString();
    this.m_CStr[4].Append(this.DM.mStringTable.GetStringByID((uint) recordByKey1.EquipName));
    this.text_Str[4].text = this.m_CStr[4].ToString();
    this.text_Str[4].SetAllDirty();
    this.text_Str[4].cachedTextGenerator.Invalidate();
    this.m_CStr[0].ClearString();
    this.m_CStr[0].IntToFormat((long) x1, bNumber: true);
    if (this.GUIM.IsArabic)
      this.m_CStr[0].AppendFormat("{0}x");
    else
      this.m_CStr[0].AppendFormat("x{0}");
    this.text_Str[0].text = this.m_CStr[0].ToString();
    this.text_Str[0].SetAllDirty();
    this.text_Str[0].cachedTextGenerator.Invalidate();
    recordByKey1 = this.DM.EquipTable.GetRecordByKey(this.ItemID[1]);
    byte equipKind1 = recordByKey1.EquipKind;
    this.m_CStr[1].ClearString();
    this.GUIM.ChangeHeroItemImg(((Component) this.btn_Itme[0]).transform, eHeroOrItem.Item, this.ItemID[1], (byte) 0, (byte) 0);
    if (equipKind1 == (byte) 11)
    {
      this.m_CStr[1].StringToFormat(this.GetItemStr(recordByKey1.PropertiesInfo[0].Propertieskey));
      this.m_CStr[1].IntToFormat((long) ((int) recordByKey1.PropertiesInfo[1].Propertieskey * (int) recordByKey1.PropertiesInfo[1].PropertiesValue * x1), bNumber: true);
      if (this.GUIM.IsArabic)
        this.m_CStr[1].AppendFormat("{1} {0}");
      else
        this.m_CStr[1].AppendFormat("{0} {1}");
    }
    this.text_Str[1].text = this.m_CStr[1].ToString();
    this.text_Str[1].SetAllDirty();
    this.text_Str[1].cachedTextGenerator.Invalidate();
    this.m_CStr[2].ClearString();
    this.m_CStr[2].IntToFormat((long) x2, bNumber: true);
    if (this.GUIM.IsArabic)
      this.m_CStr[2].AppendFormat("{0}x");
    else
      this.m_CStr[2].AppendFormat("x{0}");
    this.text_Str[2].text = this.m_CStr[2].ToString();
    this.text_Str[2].SetAllDirty();
    this.text_Str[2].cachedTextGenerator.Invalidate();
    recordByKey1 = this.DM.EquipTable.GetRecordByKey(this.ItemID[2]);
    byte equipKind2 = recordByKey1.EquipKind;
    this.m_CStr[3].ClearString();
    this.GUIM.ChangeHeroItemImg(((Component) this.btn_Itme[1]).transform, eHeroOrItem.Item, this.ItemID[2], (byte) 0, (byte) 0);
    if (equipKind2 == (byte) 11)
    {
      this.m_CStr[3].StringToFormat(this.GetItemStr(recordByKey1.PropertiesInfo[0].Propertieskey));
      this.m_CStr[3].IntToFormat((long) ((int) recordByKey1.PropertiesInfo[1].Propertieskey * (int) recordByKey1.PropertiesInfo[1].PropertiesValue * x2), bNumber: true);
      if (this.GUIM.IsArabic)
        this.m_CStr[3].AppendFormat("{1} {0}");
      else
        this.m_CStr[3].AppendFormat("{0} {1}");
    }
    this.text_Str[3].text = this.m_CStr[3].ToString();
    this.text_Str[3].SetAllDirty();
    this.text_Str[3].cachedTextGenerator.Invalidate();
  }

  public string GetItemStr(ushort mkey)
  {
    string itemStr = string.Empty;
    switch (mkey)
    {
      case 1:
        itemStr = this.DM.mStringTable.GetStringByID(3951U + (uint) mkey);
        break;
      case 2:
        itemStr = this.DM.mStringTable.GetStringByID(3951U + (uint) mkey);
        break;
      case 3:
        itemStr = this.DM.mStringTable.GetStringByID(3951U + (uint) mkey);
        break;
      case 4:
        itemStr = this.DM.mStringTable.GetStringByID(3951U + (uint) mkey);
        break;
      case 5:
        itemStr = this.DM.mStringTable.GetStringByID(3951U + (uint) mkey);
        break;
      case 6:
        itemStr = this.DM.mStringTable.GetStringByID(9991U);
        break;
    }
    return itemStr;
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 0 || !((UnityEngine.Object) this.door != (UnityEngine.Object) null))
      return;
    this.door.CloseMenu();
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    if (!this.GUIM.IsLeadItem(DataManager.Instance.EquipTable.GetRecordByKey(sender.Parm1).EquipKind))
      return;
    sender.SetFadeOutObject(EUIButtonHint.UILeBtn);
    this.GUIM.m_LordInfo.Show(sender, sender.Parm1, sender.Parm2);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    if (!this.GUIM.IsLeadItem(DataManager.Instance.EquipTable.GetRecordByKey(sender.Parm1).EquipKind))
      return;
    this.GUIM.m_LordInfo.Hide(sender);
  }

  public void OnLEButtonClick(UILEBtn sender)
  {
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 0)
      return;
    this.RefreshItem();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.RefreshItem();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void Refresh_FontTexture()
  {
    if ((UnityEngine.Object) this.text_Title != (UnityEngine.Object) null && ((Behaviour) this.text_Title).enabled)
    {
      ((Behaviour) this.text_Title).enabled = false;
      ((Behaviour) this.text_Title).enabled = true;
    }
    if ((UnityEngine.Object) this.text_Info != (UnityEngine.Object) null && ((Behaviour) this.text_Info).enabled)
    {
      ((Behaviour) this.text_Info).enabled = false;
      ((Behaviour) this.text_Info).enabled = true;
    }
    for (int index = 0; index < 5; ++index)
    {
      if ((UnityEngine.Object) this.text_Str[index] != (UnityEngine.Object) null && ((Behaviour) this.text_Str[index]).enabled)
      {
        ((Behaviour) this.text_Str[index]).enabled = false;
        ((Behaviour) this.text_Str[index]).enabled = true;
      }
    }
    for (int index = 0; index < 2; ++index)
    {
      if ((UnityEngine.Object) this.btn_Itme[index] != (UnityEngine.Object) null && ((Behaviour) this.btn_Itme[index]).enabled)
        this.btn_Itme[index].Refresh_FontTexture();
    }
    if (!((UnityEngine.Object) this.btn_Item_L != (UnityEngine.Object) null) || !((Behaviour) this.btn_Item_L).enabled)
      return;
    LordEquipData.ResetLordEquipFont(this.btn_Item_L);
  }

  private void Start()
  {
  }

  private void Update()
  {
  }
}
