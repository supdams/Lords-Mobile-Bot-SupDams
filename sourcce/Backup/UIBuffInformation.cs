// Decompiled with JetBrains decompiler
// Type: UIBuffInformation
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal class UIBuffInformation : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int MaxCstr = 3;
  private const int MaxScrollCount = 20;
  private ushort[] StrID = new ushort[11]
  {
    (ushort) 9945,
    (ushort) 9946,
    (ushort) 9947,
    (ushort) 9948,
    (ushort) 9949,
    (ushort) 9950,
    (ushort) 9951,
    (ushort) 9952,
    (ushort) 9953,
    (ushort) 9954,
    (ushort) 9955
  };
  private ushort[] StrID2 = new ushort[11]
  {
    (ushort) 9956,
    (ushort) 9957,
    (ushort) 9958,
    (ushort) 9959,
    (ushort) 9960,
    (ushort) 9961,
    (ushort) 9962,
    (ushort) 9963,
    (ushort) 9964,
    (ushort) 9965,
    (ushort) 9966
  };
  private CString[] m_DeshieldCStr = new CString[3];
  private Color DefaultColor = new Color(1f, 1f, 1f, 1f);
  private Color YallowColor = new Color(1f, 1f, 0.8f, 1f);
  private Color HaveWarBuffColor = new Color(0.0f, 1f, 0.0f, 1f);
  private Color NoHaveWarBuffColor = new Color(0.7f, 0.7f, 0.7f, 1f);
  private GUIManager GM;
  private DataManager DM;
  private Font TTF;
  private Door door;
  private UISpritesArray m_SpArray;
  private UIText m_TitleText;
  private UIText m_EmptyText;
  private UIButton m_Exit;
  private ScrollPanel m_ScrollPanel;
  private List<BuffInfoItem> m_Data;
  private BuffItemCom[] m_ScrollPanelData = new BuffItemCom[20];
  private bool bFirstInit = true;

  public override void OnOpen(int arg1, int arg2)
  {
    this.GM = GUIManager.Instance;
    this.DM = DataManager.Instance;
    this.TTF = this.GM.GetTTFFont();
    this.door = this.GM.FindMenu(EGUIWindow.Door) as Door;
    this.SpawnCStr();
    this.m_Data = new List<BuffInfoItem>();
    for (int index = 0; index < this.m_ScrollPanelData.Length; ++index)
      this.m_ScrollPanelData[index].Init();
    this.InitUI();
    this.SetData();
    this.UpdateScrollPanel();
  }

  public override void OnClose() => this.DeSpawnCStr();

  public override void UpdateUI(int arg1, int arg2)
  {
  }

  public override bool OnBackButtonClick() => false;

  public override void UpdateNetwork(byte[] meg)
  {
    switch ((NetworkNews) meg[0])
    {
      case NetworkNews.Refresh_AttribEffectVal:
      case NetworkNews.Refresh_BuffList:
        if (this.m_Data == null)
          break;
        this.m_Data.Clear();
        this.SetData();
        this.UpdateScrollPanel();
        break;
      case NetworkNews.Refresh_FontTextureRebuilt:
        this.Refresh_FontTexture();
        break;
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (!((Object) this.door != (Object) null))
      return;
    this.door.CloseMenu();
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (this.m_Data == null || dataIdx >= this.m_Data.Count || panelObjectIdx >= this.m_ScrollPanelData.Length)
      return;
    if ((Object) this.m_ScrollPanelData[panelObjectIdx].m_Colum[0] == (Object) null)
    {
      this.m_ScrollPanelData[panelObjectIdx].m_Colum[0] = item.transform.GetChild(0).gameObject;
      this.m_ScrollPanelData[panelObjectIdx].m_Colum[1] = item.transform.GetChild(1).gameObject;
      this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0] = item.transform.GetChild(0).GetComponent<RectTransform>();
      this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1] = item.transform.GetChild(1).GetComponent<RectTransform>();
      this.m_ScrollPanelData[panelObjectIdx].m_Image[0] = item.transform.GetChild(0).GetChild(0).GetComponent<Image>();
      this.m_ScrollPanelData[panelObjectIdx].m_Image[1] = item.transform.GetChild(1).GetChild(0).GetComponent<Image>();
      this.m_ScrollPanelData[panelObjectIdx].m_Outline[0] = item.transform.GetChild(0).GetChild(1).GetComponent<Outline>();
      this.m_ScrollPanelData[panelObjectIdx].m_Outline[1] = item.transform.GetChild(1).GetChild(1).GetComponent<Outline>();
      this.m_ScrollPanelData[panelObjectIdx].m_Shadow[0] = item.transform.GetChild(0).GetChild(1).GetComponent<Shadow>();
      this.m_ScrollPanelData[panelObjectIdx].m_Shadow[1] = item.transform.GetChild(1).GetChild(1).GetComponent<Shadow>();
      this.m_ScrollPanelData[panelObjectIdx].m_Text[0] = item.transform.GetChild(0).GetChild(1).GetComponent<UIText>();
      this.m_ScrollPanelData[panelObjectIdx].m_Text[1] = item.transform.GetChild(1).GetChild(1).GetComponent<UIText>();
      this.m_ScrollPanelData[panelObjectIdx].m_Text[0].font = this.TTF;
      this.m_ScrollPanelData[panelObjectIdx].m_Text[1].font = this.TTF;
    }
    if (this.m_Data[dataIdx].m_Type == (byte) 0)
      this.SetItemInformationType(dataIdx, panelObjectIdx);
    else if (this.m_Data[dataIdx].m_Type == (byte) 1)
      this.SetItemFirstTitleType(dataIdx, panelObjectIdx);
    else if (this.m_Data[dataIdx].m_Type == (byte) 2)
      this.SetItemSecTitleType(dataIdx, panelObjectIdx);
    else if (this.m_Data[dataIdx].m_Type == (byte) 4)
      this.SetItemTitleContent(dataIdx, panelObjectIdx);
    else
      this.SetItemCencontType(dataIdx, panelObjectIdx);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  private void SpawnCStr()
  {
    if (this.m_DeshieldCStr == null)
      return;
    for (int index = 0; index < this.m_DeshieldCStr.Length; ++index)
      this.m_DeshieldCStr[index] = StringManager.Instance.SpawnString(50);
  }

  private void DeSpawnCStr()
  {
    if (this.m_DeshieldCStr == null)
      return;
    for (int index = 0; index < this.m_DeshieldCStr.Length; ++index)
    {
      if (this.m_DeshieldCStr[index] != null)
      {
        StringManager.Instance.DeSpawnString(this.m_DeshieldCStr[index]);
        this.m_DeshieldCStr[index] = (CString) null;
      }
    }
  }

  private void InitUI()
  {
    this.m_SpArray = this.transform.gameObject.GetComponent<UISpritesArray>();
    this.m_TitleText = this.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.m_TitleText.font = this.TTF;
    this.m_TitleText.text = this.DM.mStringTable.GetStringByID(9938U);
    this.m_EmptyText = this.transform.GetChild(4).GetComponent<UIText>();
    this.m_EmptyText.font = this.TTF;
    Image component1 = this.transform.GetChild(3).GetComponent<Image>();
    component1.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component1).material = this.door.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (Object) component1)
      ((Behaviour) component1).enabled = false;
    UIButton component2 = this.transform.GetChild(3).GetChild(0).GetComponent<UIButton>();
    component2.m_BtnID1 = 1;
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component2.image).material = this.door.LoadMaterial();
    this.m_ScrollPanel = this.transform.GetChild(1).GetComponent<ScrollPanel>();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  private void SetData()
  {
    int num1 = 0;
    BuffInfoItem buffInfoItem1 = new BuffInfoItem();
    buffInfoItem1.Init();
    buffInfoItem1.m_Type = (byte) 0;
    buffInfoItem1.m_Width = 775f;
    buffInfoItem1.m_Height = this.GetTitleTextHeight() + 20f;
    buffInfoItem1.m_ColumNum = 1;
    buffInfoItem1.m_Column[0].ColumnWidth = 755f;
    buffInfoItem1.m_DataIdx = 0;
    this.m_Data.Add(buffInfoItem1);
    BuffInfoItem buffInfoItem2 = new BuffInfoItem();
    buffInfoItem2.Init();
    buffInfoItem2.m_Type = (byte) 1;
    buffInfoItem2.m_Width = 775f;
    buffInfoItem2.m_Height = 45f;
    buffInfoItem2.m_ColumNum = 1;
    buffInfoItem2.m_DataIdx = 0;
    this.m_Data.Add(buffInfoItem2);
    BuffInfoItem buffInfoItem3 = new BuffInfoItem();
    buffInfoItem3.Init();
    buffInfoItem3.m_Type = (byte) 4;
    buffInfoItem3.m_Width = 775f;
    buffInfoItem3.m_Height = 30f;
    buffInfoItem3.m_ColumNum = 1;
    buffInfoItem3.m_DataIdx = 0;
    buffInfoItem3.m_EffectType = GATTR_ENUM.EGE_DESHIELD_ATK;
    buffInfoItem3.m_EffectValue = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_DESHIELD_ATK);
    ref BuffInfoItem local1 = ref buffInfoItem3;
    int num2 = num1;
    int num3 = num2 + 1;
    local1.m_StrIdx = num2;
    this.m_Data.Add(buffInfoItem3);
    uint effectBaseVal1 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_DESHIELD_DEF);
    BuffInfoItem buffInfoItem4;
    if (effectBaseVal1 > 0U)
    {
      buffInfoItem4 = new BuffInfoItem();
      buffInfoItem4.Init();
      buffInfoItem4.m_Type = (byte) 4;
      buffInfoItem4.m_Width = 775f;
      buffInfoItem4.m_Height = 30f;
      buffInfoItem4.m_ColumNum = 1;
      buffInfoItem4.m_DataIdx = 0;
      buffInfoItem4.m_EffectType = GATTR_ENUM.EGE_DESHIELD_DEF;
      buffInfoItem4.m_EffectValue = effectBaseVal1;
      buffInfoItem4.m_StrIdx = num3++;
      this.m_Data.Add(buffInfoItem4);
    }
    uint effectBaseVal2 = DataManager.Instance.AttribVal.GetEffectBaseVal(GATTR_ENUM.EGE_DESHIELD_HEALTH);
    if (effectBaseVal2 > 0U)
    {
      buffInfoItem4 = new BuffInfoItem();
      buffInfoItem4.Init();
      buffInfoItem4.m_Type = (byte) 4;
      buffInfoItem4.m_Width = 775f;
      buffInfoItem4.m_Height = 30f;
      buffInfoItem4.m_ColumNum = 1;
      buffInfoItem4.m_DataIdx = 0;
      buffInfoItem4.m_EffectType = GATTR_ENUM.EGE_DESHIELD_HEALTH;
      buffInfoItem4.m_EffectValue = effectBaseVal2;
      ref BuffInfoItem local2 = ref buffInfoItem4;
      int num4 = num3;
      int num5 = num4 + 1;
      local2.m_StrIdx = num4;
      this.m_Data.Add(buffInfoItem4);
    }
    buffInfoItem4 = new BuffInfoItem();
    buffInfoItem4.Init();
    buffInfoItem4.m_Type = (byte) 2;
    buffInfoItem4.m_Width = 775f;
    buffInfoItem4.m_Height = 40f;
    buffInfoItem4.m_ColumNum = 2;
    buffInfoItem4.m_DataIdx = 0;
    buffInfoItem4.m_Column[0].ColumnWidth = 150f;
    buffInfoItem4.m_Column[1].ColumnWidth = 625f;
    this.m_Data.Add(buffInfoItem4);
    int num6 = 0;
    for (int index = 0; index < 11; ++index)
    {
      buffInfoItem4 = new BuffInfoItem();
      buffInfoItem4.Init();
      buffInfoItem4.m_Type = (byte) 3;
      buffInfoItem4.m_Width = 775f;
      buffInfoItem4.m_Height = 40f;
      buffInfoItem4.m_ColumNum = 2;
      buffInfoItem4.m_DataIdx = 0;
      buffInfoItem4.m_Column[0].ColumnWidth = 150f;
      buffInfoItem4.m_Column[1].ColumnWidth = 625f;
      buffInfoItem4.m_StrIdx = num6++;
      this.m_Data.Add(buffInfoItem4);
    }
  }

  private void UpdateScrollPanel()
  {
    if ((Object) this.m_ScrollPanel == (Object) null)
      return;
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_Data.Count; ++index)
      _DataHeight.Add(this.m_Data[index].m_Height);
    if (this.bFirstInit)
      this.m_ScrollPanel.IntiScrollPanel(775f, 0.0f, 0.0f, _DataHeight, 20, (IUpDateScrollPanel) this);
    else
      this.m_ScrollPanel.AddNewDataHeight(_DataHeight, false, false);
    this.bFirstInit = false;
  }

  private float GetTitleTextHeight()
  {
    this.m_EmptyText.text = this.DM.mStringTable.GetStringByID(9939U);
    this.m_EmptyText.SetAllDirty();
    this.m_EmptyText.cachedTextGenerator.Invalidate();
    return this.m_EmptyText.preferredHeight;
  }

  private void ItemEmpty(int panelObjectIdx)
  {
    for (int index = 0; index < 2; ++index)
    {
      ((Behaviour) this.m_ScrollPanelData[panelObjectIdx].m_Image[index]).enabled = false;
      ((Behaviour) this.m_ScrollPanelData[panelObjectIdx].m_Text[index]).enabled = false;
      this.m_ScrollPanelData[panelObjectIdx].m_Text[index].resizeTextForBestFit = true;
    }
  }

  private void EnableColum(int dataIdx, int panelObjectIdx)
  {
    int length = this.m_ScrollPanelData[panelObjectIdx].m_Colum.Length;
    int columNum = this.m_Data[dataIdx].m_ColumNum;
    for (int index = 0; index < columNum; ++index)
      this.m_ScrollPanelData[panelObjectIdx].m_Colum[index].SetActive(true);
    for (int index = columNum; index < length; ++index)
      this.m_ScrollPanelData[panelObjectIdx].m_Colum[index].SetActive(false);
  }

  private void SetColumText(
    bool bEnable,
    int panelObjectIdx,
    int textIdx,
    uint strID,
    Color c,
    Vector2 size,
    bool bShadow = false,
    bool bOutline = false,
    int fontSize = 18,
    bool bBestFit = true,
    float posX = 0,
    float posY = 0,
    TextAnchor textAnchor = TextAnchor.MiddleCenter)
  {
    ((Behaviour) this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx]).enabled = bEnable;
    ((Graphic) this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx]).rectTransform.sizeDelta = size;
    ((Graphic) this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx]).rectTransform.anchoredPosition = new Vector2(posX, posY);
    ((Graphic) this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx]).color = c;
    this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].fontSize = fontSize;
    this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].resizeTextMaxSize = fontSize;
    this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].alignment = textAnchor;
    this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].text = this.DM.mStringTable.GetStringByID(strID);
    this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].resizeTextForBestFit = bBestFit;
    this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].SetAllDirty();
    this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].cachedTextGenerator.Invalidate();
    ((Behaviour) this.m_ScrollPanelData[panelObjectIdx].m_Shadow[textIdx]).enabled = bShadow;
    ((Behaviour) this.m_ScrollPanelData[panelObjectIdx].m_Outline[textIdx]).enabled = bOutline;
  }

  private void SetEffectValueCloumText(
    bool bEnable,
    int panelObjectIdx,
    int textIdx,
    GATTR_ENUM effect,
    double effectValue,
    Color c,
    Vector2 size)
  {
    ((Behaviour) this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx]).enabled = bEnable;
    ((Graphic) this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx]).rectTransform.sizeDelta = size;
    ((Graphic) this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx]).rectTransform.anchoredPosition = new Vector2(10f, 0.0f);
    ((Graphic) this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx]).color = c;
    this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].fontSize = 18;
    this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].resizeTextMaxSize = 18;
    this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].alignment = TextAnchor.UpperLeft;
    this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].text = this.GetEffectStr(effect, effectValue).ToString();
    this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].resizeTextForBestFit = true;
    this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].SetAllDirty();
    this.m_ScrollPanelData[panelObjectIdx].m_Text[textIdx].cachedTextGenerator.Invalidate();
    ((Behaviour) this.m_ScrollPanelData[panelObjectIdx].m_Shadow[textIdx]).enabled = true;
    ((Behaviour) this.m_ScrollPanelData[panelObjectIdx].m_Outline[textIdx]).enabled = true;
  }

  private CString GetEffectStr(GATTR_ENUM effect, double effectValue)
  {
    CString effectStr = (CString) null;
    int num = 0;
    if (this.m_DeshieldCStr == null)
      return (CString) null;
    switch (effect)
    {
      case GATTR_ENUM.EGE_DESHIELD_ATK:
        num = 5;
        effectStr = this.m_DeshieldCStr[0];
        effectStr.ClearString();
        effectStr.Append(this.DM.mStringTable.GetStringByID(4326U));
        break;
      case GATTR_ENUM.EGE_DESHIELD_DEF:
        effectStr = this.m_DeshieldCStr[1];
        effectStr.ClearString();
        effectStr.Append(this.DM.mStringTable.GetStringByID(4327U));
        break;
      case GATTR_ENUM.EGE_DESHIELD_HEALTH:
        effectStr = this.m_DeshieldCStr[2];
        effectStr.ClearString();
        effectStr.Append(this.DM.mStringTable.GetStringByID(4328U));
        break;
    }
    double f = effectValue / 100.0 + (double) num;
    effectStr.DoubleToFormat(f, 2, false);
    if (this.GM.IsArabic)
      effectStr.AppendFormat("%{0}");
    else
      effectStr.AppendFormat("{0}%");
    return effectStr;
  }

  private void SetColumBackground(
    bool bEnable,
    int panelObjectIdx,
    int imageIdx,
    ushort spID,
    Vector2 size)
  {
    ((Behaviour) this.m_ScrollPanelData[panelObjectIdx].m_Image[imageIdx]).enabled = bEnable;
    ((Graphic) this.m_ScrollPanelData[panelObjectIdx].m_Image[imageIdx]).rectTransform.sizeDelta = size;
    this.m_ScrollPanelData[panelObjectIdx].m_Image[imageIdx].sprite = this.m_SpArray.GetSprite((int) spID);
  }

  private void SetItemInformationType(int dataIdx, int panelObjectIdx)
  {
    this.ItemEmpty(panelObjectIdx);
    this.EnableColum(dataIdx, panelObjectIdx);
    Vector2 size = new Vector2(775f, this.GetTitleTextHeight());
    this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0].sizeDelta = size;
    this.m_ScrollPanelData[panelObjectIdx].m_Colum[0].SetActive(true);
    this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].sizeDelta = size;
    this.m_ScrollPanelData[panelObjectIdx].m_Colum[1].SetActive(false);
    size = new Vector2(755f, this.m_Data[dataIdx].m_Height);
    this.SetColumText(true, panelObjectIdx, 0, 9939U, this.DefaultColor, size, true, true, 20, false, 10f, 0.0f, TextAnchor.MiddleLeft);
    this.SetColumText(false, panelObjectIdx, 1, 0U, this.DefaultColor, size, posX: 0.0f, posY: 0.0f);
    this.SetColumBackground(false, panelObjectIdx, 0, (ushort) 0, size);
    this.SetColumBackground(false, panelObjectIdx, 1, (ushort) 0, size);
  }

  private void SetItemFirstTitleType(int dataIdx, int panelObjectIdx)
  {
    ushort strID = !this.DM.bHaveWarBuff ? (ushort) 11049 : (ushort) 11050;
    this.ItemEmpty(panelObjectIdx);
    this.EnableColum(dataIdx, panelObjectIdx);
    Vector2 size1 = new Vector2(775f, this.m_Data[dataIdx].m_Height);
    Vector2 size2 = new Vector2(775f, 4f);
    this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0].sizeDelta = size1;
    this.m_ScrollPanelData[panelObjectIdx].m_Colum[0].SetActive(true);
    this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].sizeDelta = size1;
    this.m_ScrollPanelData[panelObjectIdx].m_Colum[1].SetActive(false);
    this.SetColumText(true, panelObjectIdx, 0, (uint) strID, this.DefaultColor, size1, true, true, 24, posX: 0.0f, posY: 0.0f);
    this.SetColumText(false, panelObjectIdx, 1, 0U, this.DefaultColor, size1, posX: 0.0f, posY: 0.0f);
    this.SetColumBackground(true, panelObjectIdx, 0, (ushort) 5, size2);
    this.SetColumBackground(false, panelObjectIdx, 1, (ushort) 0, size2);
  }

  private void SetItemSecTitleType(int dataIdx, int panelObjectIdx)
  {
    this.ItemEmpty(panelObjectIdx);
    this.EnableColum(dataIdx, panelObjectIdx);
    Vector2 size1 = new Vector2(this.m_Data[dataIdx].m_Column[0].ColumnWidth, this.m_Data[dataIdx].m_Height);
    this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0].sizeDelta = size1;
    this.m_ScrollPanelData[panelObjectIdx].m_Colum[0].SetActive(true);
    Vector2 size2 = new Vector2(this.m_Data[dataIdx].m_Column[1].ColumnWidth, this.m_Data[dataIdx].m_Height);
    this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].sizeDelta = size2;
    this.m_ScrollPanelData[panelObjectIdx].m_Colum[1].SetActive(true);
    Vector2 anchoredPosition = this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].anchoredPosition with
    {
      x = this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0].anchoredPosition.x + this.m_Data[dataIdx].m_Column[0].ColumnWidth
    };
    this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].anchoredPosition = anchoredPosition;
    this.SetColumText(true, panelObjectIdx, 0, 9941U, this.YallowColor, size1, fontSize: 24, posX: 0.0f, posY: 0.0f);
    this.SetColumText(true, panelObjectIdx, 1, 9942U, this.YallowColor, size2, fontSize: 24, posX: 0.0f, posY: 0.0f);
    this.SetColumBackground(true, panelObjectIdx, 0, (ushort) 4, size1);
    this.SetColumBackground(true, panelObjectIdx, 1, (ushort) 4, size2);
  }

  private void SetItemTitleContent(int dataIdx, int panelObjectIdx)
  {
    Color c = !this.DM.bHaveWarBuff ? this.NoHaveWarBuffColor : this.HaveWarBuffColor;
    this.ItemEmpty(panelObjectIdx);
    this.EnableColum(dataIdx, panelObjectIdx);
    Vector2 size1 = new Vector2(775f, this.m_Data[dataIdx].m_Height);
    Vector2 size2 = new Vector2(775f, 4f);
    this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0].sizeDelta = size1;
    this.m_ScrollPanelData[panelObjectIdx].m_Colum[0].SetActive(true);
    this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].sizeDelta = size1;
    this.m_ScrollPanelData[panelObjectIdx].m_Colum[1].SetActive(false);
    this.SetEffectValueCloumText(true, panelObjectIdx, 0, this.m_Data[dataIdx].m_EffectType, (double) this.m_Data[dataIdx].m_EffectValue, c, size1);
    this.SetEffectValueCloumText(false, panelObjectIdx, 1, this.m_Data[dataIdx].m_EffectType, (double) this.m_Data[dataIdx].m_EffectValue, c, size1);
    this.SetColumBackground(false, panelObjectIdx, 0, (ushort) 5, size2);
    this.SetColumBackground(false, panelObjectIdx, 1, (ushort) 0, size2);
  }

  private void SetItemCencontType(int dataIdx, int panelObjectIdx)
  {
    this.ItemEmpty(panelObjectIdx);
    this.EnableColum(dataIdx, panelObjectIdx);
    ushort spID1;
    ushort spID2;
    if (dataIdx % 2 == 0)
    {
      spID1 = (ushort) 0;
      spID2 = (ushort) 1;
    }
    else
    {
      spID1 = (ushort) 2;
      spID2 = (ushort) 3;
    }
    Vector2 size1 = new Vector2(this.m_Data[dataIdx].m_Column[0].ColumnWidth, this.m_Data[dataIdx].m_Height);
    this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0].sizeDelta = size1;
    this.m_ScrollPanelData[panelObjectIdx].m_Colum[0].SetActive(true);
    Vector2 size2 = new Vector2(this.m_Data[dataIdx].m_Column[1].ColumnWidth, this.m_Data[dataIdx].m_Height);
    this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].sizeDelta = size2;
    this.m_ScrollPanelData[panelObjectIdx].m_Colum[1].SetActive(true);
    Vector2 anchoredPosition = this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].anchoredPosition with
    {
      x = this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[0].anchoredPosition.x + this.m_Data[dataIdx].m_Column[0].ColumnWidth
    };
    this.m_ScrollPanelData[panelObjectIdx].m_ColumRect[1].anchoredPosition = anchoredPosition;
    this.SetColumText(true, panelObjectIdx, 0, (uint) this.StrID[this.m_Data[dataIdx].m_StrIdx], this.DefaultColor, size1, posX: 0.0f, posY: 0.0f);
    this.SetColumText(true, panelObjectIdx, 1, (uint) this.StrID2[this.m_Data[dataIdx].m_StrIdx], this.DefaultColor, size2, posX: 0.0f, posY: 0.0f);
    this.SetColumBackground(true, panelObjectIdx, 0, spID1, size1);
    this.SetColumBackground(true, panelObjectIdx, 1, spID2, size2);
  }

  private void Refresh_FontTexture()
  {
    if ((Object) this.m_TitleText != (Object) null && ((Behaviour) this.m_TitleText).enabled)
    {
      ((Behaviour) this.m_TitleText).enabled = false;
      ((Behaviour) this.m_TitleText).enabled = true;
    }
    if (this.m_ScrollPanelData == null)
      return;
    for (int index = 0; index < this.m_ScrollPanelData.Length; ++index)
    {
      if (this.m_ScrollPanelData[index].m_Text != null)
      {
        if ((Object) this.m_ScrollPanelData[index].m_Text[0] != (Object) null && ((Behaviour) this.m_ScrollPanelData[index].m_Text[0]).enabled)
        {
          ((Behaviour) this.m_ScrollPanelData[index].m_Text[0]).enabled = false;
          ((Behaviour) this.m_ScrollPanelData[index].m_Text[0]).enabled = true;
        }
        if ((Object) this.m_ScrollPanelData[index].m_Text[1] != (Object) null && ((Behaviour) this.m_ScrollPanelData[index].m_Text[1]).enabled)
        {
          ((Behaviour) this.m_ScrollPanelData[index].m_Text[1]).enabled = false;
          ((Behaviour) this.m_ScrollPanelData[index].m_Text[1]).enabled = true;
        }
      }
    }
  }
}
