// Decompiled with JetBrains decompiler
// Type: UIEffectFilter
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIEffectFilter : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const float SPUnitHeight = 66f;
  private Transform AGS_Form;
  private ScrollPanel AGS_ScrollPanel;
  private eUI_EffectFilter_OpenKind OpenKind;
  public static ushort SeletedFilter;
  private List<float> SPHeight;
  private ushort Selected;
  private Door door;
  private bool SetEffect;

  private void Update()
  {
  }

  public override void OnOpen(int arg1, int arg2)
  {
    this.OpenKind = (eUI_EffectFilter_OpenKind) arg1;
    this.SPHeight = new List<float>();
    this.Selected = (ushort) arg2;
    UIEffectFilter.SeletedFilter = this.Selected;
    this.door = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    this.AGS_ScrollPanel = this.AGS_Form.GetChild(2).GetComponent<ScrollPanel>();
    UIText component1 = this.AGS_Form.GetChild(3).GetChild(1).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = string.Empty;
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component2 = this.AGS_Form.GetChild(3).GetChild(3).GetComponent<RectTransform>();
      ((Transform) component2).localScale = new Vector3(-1f, 1f, 1f);
      component2.anchoredPosition = new Vector2(component2.anchoredPosition.x + 47f, component2.anchoredPosition.y);
    }
    UIButton component3 = this.AGS_Form.GetChild(5).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_EffectType = e_EffectType.e_Scale;
    UIText component4 = this.AGS_Form.GetChild(5).GetChild(0).GetComponent<UIText>();
    component4.font = ttfFont;
    component4.text = DataManager.Instance.mStringTable.GetStringByID(5026U);
    UIButton component5 = this.AGS_Form.GetChild(6).GetChild(0).GetComponent<UIButton>();
    component5.m_Handler = (IUIButtonClickHandler) this;
    component5.m_EffectType = e_EffectType.e_Scale;
    Image component6 = this.AGS_Form.GetChild(6).GetComponent<Image>();
    component6.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component6).material = this.door.LoadMaterial();
    ((Behaviour) component6).enabled = !GUIManager.Instance.bOpenOnIPhoneX;
    Image component7 = this.AGS_Form.GetChild(6).GetChild(0).GetComponent<Image>();
    component7.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component7).material = this.door.LoadMaterial();
    switch (this.OpenKind)
    {
      case eUI_EffectFilter_OpenKind.ItemTypeFilter:
        UIText component8 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
        component8.font = ttfFont;
        component8.text = DataManager.Instance.mStringTable.GetStringByID(7460U);
        this.SPHeight.Add(66f);
        for (int index = 0; index < 6; ++index)
          this.SPHeight.Add(66f);
        break;
      case eUI_EffectFilter_OpenKind.EffectTypeFilter:
        this.SPHeight.Add(66f);
        UIText component9 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
        component9.font = ttfFont;
        component9.text = DataManager.Instance.mStringTable.GetStringByID(7411U);
        for (int index = 0; index < DataManager.Instance.LordEquipEffectFilter.TableCount; ++index)
          this.SPHeight.Add(66f);
        break;
    }
    this.AGS_ScrollPanel.IntiScrollPanel(424f, 0.0f, 0.0f, this.SPHeight, 9, (IUpDateScrollPanel) this);
    this.AGS_ScrollPanel.GoTo((int) this.Selected);
  }

  public override void OnClose()
  {
    if (this.SetEffect)
    {
      UIEffectFilter.SeletedFilter = this.Selected;
      if (this.OpenKind != eUI_EffectFilter_OpenKind.EffectTypeFilter)
        return;
      DataManager.Instance.mLordEquip.ForgeItem_mSeletedFilter = UIEffectFilter.SeletedFilter;
    }
    else
      UIEffectFilter.SeletedFilter = (ushort) 0;
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((int) this.Selected == dataIdx)
    {
      item.transform.GetChild(3).gameObject.SetActive(true);
      item.transform.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(1);
    }
    else
    {
      item.transform.GetChild(3).gameObject.SetActive(false);
      item.transform.GetChild(0).GetComponent<UISpritesArray>().SetSpriteIndex(0);
    }
    UIButton component = item.transform.GetChild(0).GetComponent<UIButton>();
    component.m_BtnID1 = 1;
    component.m_BtnID2 = dataIdx;
    component.m_Handler = (IUIButtonClickHandler) this;
    if (dataIdx == 0)
    {
      item.transform.GetChild(1).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID(7412U);
    }
    else
    {
      switch (this.OpenKind)
      {
        case eUI_EffectFilter_OpenKind.ItemTypeFilter:
          this.UpdateRowItemType(item, dataIdx, panelObjectIdx);
          break;
        case eUI_EffectFilter_OpenKind.EffectTypeFilter:
          this.UpdateRowEffectType(item, dataIdx, panelObjectIdx);
          break;
      }
    }
  }

  private void UpdateRowEffectType(GameObject item, int dataIdx, int panelObjectIdx)
  {
    item.transform.GetChild(1).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID((uint) DataManager.Instance.EffectData.GetRecordByKey(DataManager.Instance.LordEquipEffectFilter.GetRecordByIndex((int) (ushort) (dataIdx - 1)).effectID).InfoID);
  }

  private void UpdateRowItemType(GameObject item, int dataIdx, int panelObjectIdx)
  {
    item.transform.GetChild(1).GetComponent<UIText>().text = DataManager.Instance.mStringTable.GetStringByID((uint) (ushort) (7430 + dataIdx));
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(5).GetChild(0).GetComponent<UIText>();
    if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    UIText component2 = this.AGS_Form.GetChild(1).GetChild(0).GetComponent<UIText>();
    if ((Object) component2 != (Object) null && ((Behaviour) component2).enabled)
    {
      ((Behaviour) component2).enabled = false;
      ((Behaviour) component2).enabled = true;
    }
    if (!((Object) this.AGS_ScrollPanel != (Object) null))
      return;
    this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeight, false);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        switch (sender.m_BtnID2)
        {
          case 0:
            this.door.CloseMenu();
            return;
          case 1:
            this.SetEffect = true;
            this.door.CloseMenu();
            return;
          default:
            return;
        }
      case 1:
        this.Selected = (ushort) sender.m_BtnID2;
        this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeight, false);
        break;
    }
  }

  private enum e_AGS_UI_EffectFilter_Editor
  {
    BGFrame = 0,
    BGFrameTitle = 1,
    ScrollPanel = 2,
    ScrollPanelItem = 3,
    Image = 4,
    Okbtn = 5,
    exitImage = 6,
    BGFrameRight = 11, // 0x0000000B
  }

  private enum e_AGS_ScrollPanelItem
  {
    UIButton,
    Text,
    CheckBg,
    Check,
  }
}
