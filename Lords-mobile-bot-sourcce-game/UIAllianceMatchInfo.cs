// Decompiled with JetBrains decompiler
// Type: UIAllianceMatchInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAllianceMatchInfo : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int MaxPanelObject = 20;
  private const uint MaxData = 38;
  private UIAllianceMatchInfo.sMatchInfo[] m_PanelObjects = new UIAllianceMatchInfo.sMatchInfo[20];
  private UIAllianceMatchInfo.sMatchInfoData[] m_Data = new UIAllianceMatchInfo.sMatchInfoData[new IntPtr(38)];
  private uint TitleStrID = 17040;
  private uint[] m_StrIDs = new uint[38]
  {
    17076U,
    0U,
    17041U,
    17042U,
    17043U,
    17044U,
    17045U,
    0U,
    17046U,
    17047U,
    17048U,
    17049U,
    17050U,
    17070U,
    0U,
    17051U,
    17052U,
    17053U,
    0U,
    17054U,
    17055U,
    17056U,
    17057U,
    0U,
    17058U,
    17059U,
    17060U,
    17061U,
    17062U,
    0U,
    17063U,
    17064U,
    17065U,
    0U,
    17066U,
    17067U,
    17068U,
    17069U
  };
  private ScrollPanel m_ScrollPanel;
  private UIButton m_Exit;
  private UIText m_TitleText;
  private UIText m_GetHightText;
  private Door door;
  private GUIManager GM;
  private string AssName = "UIActivity3";
  private bool bOpen;

  public override void OnOpen(int arg1, int arg2)
  {
    this.GM = GUIManager.Instance;
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.GM.AddSpriteAsset(this.AssName);
    Material material = this.GM.LoadMaterial(this.AssName, "UI_act_content_m");
    Image component1 = this.transform.GetChild(0).GetChild(0).GetComponent<Image>();
    component1.sprite = this.GM.LoadSprite(this.AssName, "UI_act_box_002");
    ((MaskableGraphic) component1).material = material;
    Image component2 = this.transform.GetChild(1).GetComponent<Image>();
    component2.sprite = this.GM.LoadSprite(this.AssName, "UI_act_box_009");
    ((MaskableGraphic) component2).material = material;
    this.m_TitleText = this.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.m_TitleText.font = this.GM.GetTTFFont();
    this.m_TitleText.text = DataManager.Instance.mStringTable.GetStringByID(this.TitleStrID);
    Image component3 = this.transform.GetChild(2).GetComponent<Image>();
    component3.sprite = this.GM.LoadSprite(this.AssName, "UI_act_alpha_001");
    ((MaskableGraphic) component3).material = material;
    this.m_ScrollPanel = this.transform.GetChild(2).GetComponent<ScrollPanel>();
    this.m_GetHightText = this.transform.GetChild(4).GetComponent<UIText>();
    this.m_GetHightText.font = this.GM.GetTTFFont();
    Image component4 = this.transform.GetChild(5).GetComponent<Image>();
    component4.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component4).material = this.door.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (UnityEngine.Object) component4)
      ((Behaviour) component4).enabled = false;
    this.m_Exit = this.transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
    this.m_Exit.m_BtnID1 = 0;
    this.m_Exit.m_Handler = (IUIButtonClickHandler) this;
    this.m_Exit.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) this.m_Exit.image).material = this.door.LoadMaterial();
    this.SetData();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    this.bOpen = true;
  }

  public override void OnClose()
  {
    if (this.m_PanelObjects != null)
    {
      for (int index = 0; index < 20; ++index)
        this.m_PanelObjects[index].Destroy();
    }
    this.GM.RemoveSpriteAsset(this.AssName);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelObjectIdx >= this.m_PanelObjects.Length || panelObjectIdx < 0)
      return;
    if ((UnityEngine.Object) this.m_PanelObjects[panelObjectIdx].InfoText == (UnityEngine.Object) null)
    {
      this.m_PanelObjects[panelObjectIdx].InfoText = item.transform.GetChild(0).GetComponent<UIText>();
      this.m_PanelObjects[panelObjectIdx].InfoText.font = GUIManager.Instance.GetTTFFont();
    }
    this.SetScrollItem(dataIdx, panelObjectIdx);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    if (!this.bOpen)
      return;
    this.door.CloseMenu();
  }

  public override bool OnBackButtonClick() => false;

  private void SetData()
  {
    if (this.m_Data != null)
    {
      for (int index = 0; index < 38 && index < this.m_StrIDs.Length; ++index)
      {
        this.m_Data[index].StrID = this.m_StrIDs[index];
        this.m_Data[index].Type = this.m_StrIDs[index] != 0U ? UIAllianceMatchInfo.MatchInfoType.StrInfo : UIAllianceMatchInfo.MatchInfoType.None;
        this.m_Data[index].TextHeight = this.GetPreferredHeight(this.m_StrIDs[index]);
      }
      if ((UnityEngine.Object) this.m_ScrollPanel != (UnityEngine.Object) null)
      {
        List<float> _DataHeight = new List<float>();
        for (int index = 0; index < this.m_Data.Length; ++index)
          _DataHeight.Add(this.m_Data[index].TextHeight);
        this.m_ScrollPanel.IntiScrollPanel(509f, 0.0f, 5f, _DataHeight, 20, (IUpDateScrollPanel) this);
      }
    }
    if (!((UnityEngine.Object) this.m_GetHightText != (UnityEngine.Object) null))
      return;
    ((Component) this.m_GetHightText).gameObject.SetActive(false);
  }

  private float GetPreferredHeight(uint StrID)
  {
    if (!((UnityEngine.Object) this.m_GetHightText != (UnityEngine.Object) null))
      return 0.0f;
    this.m_GetHightText.text = DataManager.Instance.mStringTable.GetStringByID(StrID);
    return this.m_GetHightText.preferredHeight;
  }

  private void SetScrollItem(int dataIdx, int panelObjectIdx)
  {
    if (dataIdx >= this.m_Data.Length || dataIdx < 0)
      return;
    this.m_PanelObjects[panelObjectIdx].SetTextByStrID(this.m_Data[dataIdx]);
  }

  private void Refresh_FontTexture()
  {
    if (!this.bOpen)
      return;
    if (this.m_PanelObjects != null)
    {
      for (int index = 0; index < 20; ++index)
      {
        if ((UnityEngine.Object) this.m_PanelObjects[index].InfoText != (UnityEngine.Object) null && ((Behaviour) this.m_PanelObjects[index].InfoText).enabled)
        {
          ((Behaviour) this.m_PanelObjects[index].InfoText).enabled = false;
          ((Behaviour) this.m_PanelObjects[index].InfoText).enabled = true;
        }
      }
    }
    if (!((UnityEngine.Object) this.m_TitleText != (UnityEngine.Object) null) || !((Behaviour) this.m_TitleText).enabled)
      return;
    ((Behaviour) this.m_TitleText).enabled = false;
    ((Behaviour) this.m_TitleText).enabled = true;
  }

  private enum MatchInfoType
  {
    None,
    StrInfo,
    Max,
  }

  private struct sMatchInfoData
  {
    public UIAllianceMatchInfo.MatchInfoType Type;
    public uint StrID;
    public float TextHeight;

    public void Init()
    {
      this.Type = UIAllianceMatchInfo.MatchInfoType.StrInfo;
      this.StrID = 0U;
      this.TextHeight = 0.0f;
    }
  }

  private struct sMatchInfo
  {
    public UIText InfoText;
    public CString Str;

    public void Init()
    {
      this.InfoText = (UIText) null;
      this.Str = StringManager.Instance.SpawnString();
    }

    public void SetTextByStrID(UIAllianceMatchInfo.sMatchInfoData data)
    {
      if (data.Type == UIAllianceMatchInfo.MatchInfoType.StrInfo)
      {
        ((Graphic) this.InfoText).rectTransform.sizeDelta = ((Graphic) this.InfoText).rectTransform.sizeDelta with
        {
          y = data.TextHeight
        };
        this.InfoText.text = DataManager.Instance.mStringTable.GetStringByID(data.StrID);
      }
      else
        this.InfoText.text = string.Empty;
    }

    public void Destroy()
    {
      if (this.Str == null)
        return;
      StringManager.Instance.DeSpawnString(this.Str);
    }
  }

  private enum eUIAllianceMatchInfo
  {
    BGPanel,
    Title,
    ScrollPanel,
    Item,
    HeightText,
    Exit,
  }
}
