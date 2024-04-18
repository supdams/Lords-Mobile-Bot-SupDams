// Decompiled with JetBrains decompiler
// Type: UIAlliance_Permission
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAlliance_Permission : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int MaxTempTextNum = 2;
  private const int MaxRowItemTexttNum = 19;
  private ScrollPanel m_ScrollPanel;
  private uint[] strArray = new uint[19]
  {
    4775U,
    4628U,
    4776U,
    4777U,
    4778U,
    4779U,
    4780U,
    4783U,
    4784U,
    4785U,
    10071U,
    12635U,
    4786U,
    4787U,
    4788U,
    4789U,
    4790U,
    4791U,
    9567U
  };
  private Door door;
  private UIText[] m_TempText = new UIText[2];
  private int m_TempTextIdx;
  private UIText[] m_RowItemText = new UIText[19];

  public override void OnOpen(int arg1, int arg2)
  {
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    UIText component1 = this.transform.GetChild(5).GetChild(0).GetComponent<UIText>();
    component1.font = GUIManager.Instance.GetTTFFont();
    component1.text = DataManager.Instance.mStringTable.GetStringByID(528U);
    this.m_TempText[this.m_TempTextIdx++] = component1;
    Image component2 = this.transform.GetChild(13).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component2).material = this.door.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (Object) component2)
      ((Behaviour) component2).enabled = false;
    UIButton component3 = this.transform.GetChild(13).GetChild(0).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 1;
    component3.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component3.image).material = this.door.LoadMaterial();
    UIText component4 = this.transform.GetChild(12).GetChild(0).GetComponent<UIText>();
    component4.font = GUIManager.Instance.GetTTFFont();
    this.m_TempText[this.m_TempTextIdx++] = component4;
    this.m_ScrollPanel = this.transform.GetChild(11).GetComponent<ScrollPanel>();
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < 18; ++index)
      _DataHeight.Add(41f);
    this.m_ScrollPanel.IntiScrollPanel(440f, 0.0f, 0.0f, _DataHeight, 12, (IUpDateScrollPanel) this);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 != 1 || !(bool) (Object) this.door)
      return;
    this.door.CloseMenu();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (dataIdx >= 19 || dataIdx < 0)
      return;
    UIText component = item.transform.GetChild(0).GetComponent<UIText>();
    if (dataIdx < this.m_RowItemText.Length)
      this.m_RowItemText[dataIdx] = component;
    if (dataIdx < this.strArray.Length)
      component.text = DataManager.Instance.mStringTable.GetStringByID(this.strArray[dataIdx]);
    item.transform.GetChild(2).gameObject.SetActive(true);
    if (dataIdx <= 11)
      item.transform.GetChild(3).gameObject.SetActive(true);
    else
      item.transform.GetChild(3).gameObject.SetActive(false);
    if (dataIdx <= 3)
      item.transform.GetChild(4).gameObject.SetActive(true);
    else
      item.transform.GetChild(4).gameObject.SetActive(false);
    if (dataIdx == 0 || dataIdx == 1)
      item.transform.GetChild(5).gameObject.SetActive(true);
    else
      item.transform.GetChild(5).gameObject.SetActive(false);
    if (dataIdx == 0)
      item.transform.GetChild(6).gameObject.SetActive(true);
    else
      item.transform.GetChild(6).gameObject.SetActive(false);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void Refresh_FontTexture()
  {
    if (this.m_TempText != null)
    {
      for (int index = 0; index < this.m_TempText.Length; ++index)
      {
        if ((Object) this.m_TempText[index] != (Object) null && ((Behaviour) this.m_TempText[index]).enabled)
        {
          ((Behaviour) this.m_TempText[index]).enabled = false;
          ((Behaviour) this.m_TempText[index]).enabled = true;
        }
      }
    }
    if (this.m_RowItemText == null)
      return;
    for (int index = 0; index < this.m_RowItemText.Length; ++index)
    {
      if ((Object) this.m_RowItemText[index] != (Object) null && ((Behaviour) this.m_RowItemText[index]).enabled)
      {
        ((Behaviour) this.m_RowItemText[index]).enabled = false;
        ((Behaviour) this.m_RowItemText[index]).enabled = true;
      }
    }
  }
}
