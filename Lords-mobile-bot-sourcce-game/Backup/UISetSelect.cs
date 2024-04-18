// Decompiled with JetBrains decompiler
// Type: UISetSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UISetSelect : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private Transform AGS_Form;
  private ScrollPanel AGS_ScrollPanel;
  private Door door;
  private DataManager DM;
  private bool isLoading;
  private List<float> SPHeight;
  private RectTransform[] Equips;
  private CString[] SetNames = new CString[8];
  private CString CloseText;
  private RectTransform NO;
  private int NOonIdx;
  public static float memPos;

  public override void OnOpen(int arg1, int arg2)
  {
    this.door = (Door) GUIManager.Instance.FindMenu(EGUIWindow.Door);
    this.DM = DataManager.Instance;
    if (this.DM.mLordEquip == null)
      this.DM.mLordEquip = LordEquipData.Instance();
    this.SPHeight = new List<float>();
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.AGS_Form = this.transform;
    UIText component1 = this.AGS_Form.GetChild(0).GetChild(2).GetComponent<UIText>();
    component1.font = ttfFont;
    component1.text = this.DM.mStringTable.GetStringByID(8600U);
    this.AGS_ScrollPanel = this.AGS_Form.GetChild(1).GetComponent<ScrollPanel>();
    UIText component2 = this.AGS_Form.GetChild(2).GetChild(0).GetChild(0).GetComponent<UIText>();
    component2.font = ttfFont;
    component2.text = string.Empty;
    this.AGS_Form.GetChild(2).GetChild(0).GetChild(1).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    UIText component3 = this.AGS_Form.GetChild(2).GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    component3.font = ttfFont;
    component3.text = this.DM.mStringTable.GetStringByID(924U);
    this.AGS_Form.GetChild(2).GetChild(0).GetChild(2).GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
    UIText component4 = this.AGS_Form.GetChild(2).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
    component4.font = ttfFont;
    component4.text = this.DM.mStringTable.GetStringByID(925U);
    this.CloseText = StringManager.Instance.SpawnString(150);
    this.CloseText.StringToFormat(this.DM.mStringTable.GetStringByID(8600U));
    this.CloseText.AppendFormat(this.DM.mStringTable.GetStringByID(3775U));
    UIText component5 = this.AGS_Form.GetChild(3).GetChild(0).GetComponent<UIText>();
    component5.font = ttfFont;
    component5.text = this.CloseText.ToString();
    component5.SetAllDirty();
    component5.cachedTextGenerator.Invalidate();
    UIButton component6 = this.AGS_Form.GetChild(3).GetChild(1).GetComponent<UIButton>();
    component6.m_Handler = (IUIButtonClickHandler) this;
    component6.m_BtnID1 = 3;
    UIText component7 = this.AGS_Form.GetChild(3).GetChild(1).GetChild(0).GetComponent<UIText>();
    component7.font = ttfFont;
    component7.text = this.DM.mStringTable.GetStringByID(3776U);
    UIButton component8 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<UIButton>();
    component8.m_Handler = (IUIButtonClickHandler) this;
    component8.m_BtnID1 = 99;
    Image component9 = this.AGS_Form.GetChild(4).GetComponent<Image>();
    component9.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component9).material = this.door.LoadMaterial();
    ((Behaviour) component9).enabled = !GUIManager.Instance.bOpenOnIPhoneX;
    Image component10 = this.AGS_Form.GetChild(4).GetChild(0).GetComponent<Image>();
    component10.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component10).material = this.door.LoadMaterial();
    this.NO = this.AGS_Form.GetChild(3).GetComponent<RectTransform>();
    this.isLoading = true;
  }

  public override void OnClose()
  {
    UISetSelect.memPos = this.AGS_ScrollPanel.GetContentPos();
    for (int index = 0; index < this.SetNames.Length; ++index)
      StringManager.Instance.DeSpawnString(this.SetNames[index]);
    StringManager.Instance.DeSpawnString(this.CloseText);
  }

  public void Update()
  {
    if (!this.isLoading)
      return;
    this.isLoading = false;
    this.AfterLoader();
  }

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Login:
        this.door.CloseMenu();
        break;
      case NetworkNews.Refresh_Technology:
        this.reFlashScrollPanel();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  private void AfterLoader()
  {
    if (this.Equips == null)
      this.Equips = new RectTransform[8];
    LordEquipData.Instance().CheckQuickSets();
    for (int index = 0; index < this.SetNames.Length; ++index)
      this.SetNames[index] = StringManager.Instance.SpawnString(100);
    this.SPHeight.Clear();
    this.AGS_ScrollPanel.IntiScrollPanel(445f, 0.0f, 0.0f, this.SPHeight, 8, (IUpDateScrollPanel) this);
    this.reFlashScrollPanel();
    this.AGS_ScrollPanel.GoTo(0, UISetSelect.memPos);
    this.AGS_ScrollPanel.gameObject.SetActive(true);
    this.isLoading = false;
  }

  private void reFlashScrollPanel()
  {
    this.SPHeight.Clear();
    TechDataTbl recordByKey = this.DM.TechData.GetRecordByKey((ushort) 116);
    LordEquipData.Instance().LordEquipSetsCount = (int) DataManager.Instance.GetTechLevel((ushort) 116);
    for (int index = 0; index < LordEquipData.Instance().LordEquipSetsCount; ++index)
    {
      if (LordEquipData.Instance().LordEquipSets[index] == null)
      {
        LordEquipData.Instance().LordEquipSets[index] = new LordEquipSet();
        LordEquipData.Instance().LordEquipSets[index].Name = StringManager.Instance.SpawnString();
      }
      this.SPHeight.Add(94f);
    }
    if (LordEquipData.Instance().LordEquipSetsCount < (int) recordByKey.LevelMax)
      this.SPHeight.Add(94f);
    this.AGS_ScrollPanel.AddNewDataHeight(this.SPHeight, false);
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 1:
        if (this.DM.RoleAttr.LordEquipEventData.SerialNO != 0U)
        {
          for (int index = 0; index < 8; ++index)
          {
            if ((int) LordEquipData.Instance().LordEquipSets[sender.m_BtnID2].SerialNO[index] == (int) this.DM.RoleAttr.LordEquipEventData.SerialNO)
            {
              GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(5893U), this.DM.mStringTable.GetStringByID(9708U), sender.m_BtnID2);
              return;
            }
          }
        }
        MessagePacket messagePacket = new MessagePacket((ushort) 1024);
        messagePacket.Protocol = Protocol._MSG_REQUEST_LORDEQUIP_CHANGE;
        messagePacket.AddSeqId();
        messagePacket.Add((byte) sender.m_BtnID2);
        messagePacket.Send();
        GUIManager.Instance.ShowUILock(EUILock.LordInfo);
        break;
      case 2:
        UILordEquipSetEdit.loadSet(sender.m_BtnID2);
        this.door.OpenMenu(EGUIWindow.UI_LordEquipSetEdit);
        break;
      case 3:
        GUIManager.Instance.OpenTechTree((ushort) 116, true);
        break;
      case 99:
        this.door.CloseMenu();
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_LORDEQUIP_CHANGE;
    messagePacket.AddSeqId();
    messagePacket.Add((byte) arg1);
    messagePacket.Send();
    GUIManager.Instance.ShowUILock(EUILock.LordInfo);
  }

  public void ButtonOnClick(GameObject sender, int parm1, int parm2)
  {
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (dataIdx >= LordEquipData.Instance().LordEquipSetsCount)
    {
      ((Transform) this.NO).SetParent(item.transform);
      this.NO.anchoredPosition = Vector2.zero;
      ((Component) this.NO).gameObject.SetActive(true);
      item.transform.GetChild(0).gameObject.SetActive(false);
      this.NOonIdx = panelObjectIdx;
    }
    else
    {
      if (this.NOonIdx == panelObjectIdx)
      {
        ((Component) this.NO).gameObject.SetActive(false);
        item.transform.GetChild(0).gameObject.SetActive(true);
      }
      if (LordEquipData.Instance().LordEquipSets[dataIdx] == null)
      {
        LordEquipData.Instance().LordEquipSets[dataIdx] = new LordEquipSet();
        LordEquipData.Instance().LordEquipSets[dataIdx].Name = StringManager.Instance.SpawnString();
      }
      UIText component1 = item.transform.GetChild(0).GetChild(0).GetComponent<UIText>();
      component1.SetCheckArabic(true);
      if (LordEquipData.Instance().LordEquipSets[dataIdx].Name.Length > 0)
      {
        component1.text = LordEquipData.Instance().LordEquipSets[dataIdx].Name.ToString();
      }
      else
      {
        this.SetNames[panelObjectIdx].ClearString();
        this.SetNames[panelObjectIdx].IntToFormat((long) (dataIdx + 1));
        this.SetNames[panelObjectIdx].AppendFormat(this.DM.mStringTable.GetStringByID(928U));
        component1.text = this.SetNames[panelObjectIdx].ToString();
      }
      component1.SetAllDirty();
      component1.cachedTextGenerator.Invalidate();
      UIButton component2 = item.transform.GetChild(0).GetChild(1).GetComponent<UIButton>();
      component2.m_Handler = (IUIButtonClickHandler) this;
      component2.m_BtnID2 = dataIdx;
      UIText component3 = ((Component) component2).transform.GetChild(0).GetComponent<UIText>();
      if (LordEquipData.Instance().LordEquipSets[dataIdx].isSetEmpty())
      {
        component2.m_BtnID1 = 0;
        ((Graphic) component2.image).color = Color.gray;
        ((Graphic) component3).color = new Color(0.898f, 0.0f, 0.31f);
      }
      else
      {
        component2.m_BtnID1 = 1;
        ((Graphic) component2.image).color = Color.white;
        ((Graphic) component3).color = Color.white;
      }
      item.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(924U);
      UIButton component4 = item.transform.GetChild(0).GetChild(2).GetComponent<UIButton>();
      component4.m_Handler = (IUIButtonClickHandler) this;
      component4.m_BtnID1 = 2;
      component4.m_BtnID2 = dataIdx;
      item.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(925U);
    }
  }

  public void Refresh_FontTexture()
  {
    UIText component1 = this.AGS_Form.GetChild(0).GetChild(2).GetComponent<UIText>();
    if ((Object) component1 != (Object) null && ((Behaviour) component1).enabled)
    {
      ((Behaviour) component1).enabled = false;
      ((Behaviour) component1).enabled = true;
    }
    if ((Object) this.AGS_ScrollPanel != (Object) null && this.AGS_ScrollPanel.gameObject.activeInHierarchy)
    {
      Transform child1 = this.AGS_ScrollPanel.transform.GetChild(1);
      for (int index = 0; index < child1.childCount; ++index)
      {
        Transform child2 = child1.GetChild(index);
        if (child2.gameObject.activeInHierarchy)
        {
          UIText component2 = child2.GetChild(0).GetChild(0).GetComponent<UIText>();
          if ((Object) component2 != (Object) null && ((Behaviour) component2).enabled)
          {
            ((Behaviour) component2).enabled = false;
            ((Behaviour) component2).enabled = true;
          }
          UIText component3 = child2.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
          if ((Object) component3 != (Object) null && ((Behaviour) component3).enabled)
          {
            ((Behaviour) component3).enabled = false;
            ((Behaviour) component3).enabled = true;
          }
          UIText component4 = child2.GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
          if ((Object) component4 != (Object) null && ((Behaviour) component4).enabled)
          {
            ((Behaviour) component4).enabled = false;
            ((Behaviour) component4).enabled = true;
          }
        }
      }
    }
    UIText component5 = ((Transform) this.NO).GetChild(0).GetComponent<UIText>();
    if ((Object) component5 != (Object) null && ((Behaviour) component5).enabled)
    {
      ((Behaviour) component5).enabled = false;
      ((Behaviour) component5).enabled = true;
    }
    UIText component6 = ((Transform) this.NO).GetChild(1).GetChild(0).GetComponent<UIText>();
    if (!((Object) component6 != (Object) null) || !((Behaviour) component6).enabled)
      return;
    ((Behaviour) component6).enabled = false;
    ((Behaviour) component6).enabled = true;
  }

  private enum e_AGS_UITalentSave_Editor
  {
    Background,
    Scroll,
    Item,
    No,
    Close,
  }

  private enum e_AGS_Background
  {
    Image,
    Image2,
    Text,
  }

  private enum e_AGS_Scroll
  {
    Image,
  }

  private enum e_AGS_Item
  {
    Yes,
  }

  private enum e_AGS_Yes
  {
    Text,
    ApplyBtn,
    SetupBtn,
  }

  private enum e_AGS_ApplyBtn
  {
    Text,
  }

  private enum e_AGS_SetupBtn
  {
    Text,
  }

  private enum e_AGS_No
  {
    Text,
    UIButton,
    Image,
  }

  private enum e_AGS_UIButton
  {
    Text,
  }

  private enum e_AGS_Close
  {
    CloseBtn,
  }
}
