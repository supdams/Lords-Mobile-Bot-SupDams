// Decompiled with JetBrains decompiler
// Type: UIArmyInfo
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIArmyInfo : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int MaxCreate = 5;
  private const int TextMax = 12;
  private DataManager DM = DataManager.Instance;
  private ScrollPanel m_ScrollPanel;
  private List<sArmyData> m_Data;
  private ArmyInfoObect[] m_ItemObj = new ArmyInfoObect[5];
  private Door door;
  private Material m_Mat;
  private CString m_EmptyStr;
  private CString m_CheckMsgStr;
  private UISpritesArray m_SpArray;
  private float m_TimeTick;
  private float m_ResTextChangeTime = 1.5f;
  private byte m_ResTextType;
  private float colorA;
  private int mTextCount;
  private UIText[] m_tmptext = new UIText[12];
  private eArmyUIType UIType;

  public override void OnOpen(int arg1, int arg2)
  {
    this.UIType = arg1 != 1 ? eArmyUIType.eTroopArmyMod : eArmyUIType.eHideArmyMod;
    this.m_Mat = GUIManager.Instance.AddSpriteAsset("UI_armypic");
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.m_Data = new List<sArmyData>();
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.m_SpArray = this.transform.GetComponent<UISpritesArray>();
    this.m_EmptyStr = StringManager.Instance.SpawnString();
    this.m_CheckMsgStr = StringManager.Instance.SpawnString();
    this.m_EmptyStr.ClearString();
    this.m_CheckMsgStr.ClearString();
    this.m_tmptext[this.mTextCount] = this.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    this.m_tmptext[this.mTextCount].text = this.UIType != eArmyUIType.eTroopArmyMod ? this.DM.mStringTable.GetStringByID(9046U) : this.DM.mStringTable.GetStringByID(534U);
    ++this.mTextCount;
    UIButton component1 = this.transform.GetChild(1).GetChild(1).GetComponent<UIButton>();
    component1.m_BtnID1 = 101;
    component1.m_Handler = (IUIButtonClickHandler) this;
    Transform child1 = this.transform.GetChild(4);
    this.m_tmptext[this.mTextCount] = child1.GetChild(1).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = child1.GetChild(2).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    ++this.mTextCount;
    Transform child2 = child1.GetChild(3);
    this.m_tmptext[this.mTextCount] = child2.GetChild(1).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = child2.GetChild(2).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    ++this.mTextCount;
    Transform child3 = child1.GetChild(4);
    this.m_tmptext[this.mTextCount] = child3.GetChild(3).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = child3.GetChild(4).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    ++this.mTextCount;
    Transform child4 = child1.GetChild(5);
    this.m_tmptext[this.mTextCount] = child4.GetChild(1).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = child4.GetChild(2).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = child1.GetChild(8).GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = child1.GetChild(9).GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = child1.GetChild(10).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = ttfFont;
    ++this.mTextCount;
    if (GUIManager.Instance.IsArabic)
      child1.GetChild(7).gameObject.AddComponent<ArabicItemTextureRot>();
    this.m_ScrollPanel = this.transform.GetChild(2).GetComponent<ScrollPanel>();
    this.SetData();
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_Data.Count; ++index)
      _DataHeight.Add(140f);
    this.m_ScrollPanel.IntiScrollPanel(517f, 0.0f, 10f, _DataHeight, 5, (IUpDateScrollPanel) this);
    Image component2 = this.transform.GetChild(5).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component2).material = this.door.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (Object) component2)
      ((Behaviour) component2).enabled = false;
    UIButton component3 = this.transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 100;
    component3.image.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component3.image).material = this.door.LoadMaterial();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    for (int index = 0; index < 5; ++index)
    {
      if (this.m_ItemObj[index] != null)
      {
        if (this.m_ItemObj[index].m_Text1Str != null)
          StringManager.Instance.DeSpawnString(this.m_ItemObj[index].m_Text1Str);
        if (this.m_ItemObj[index].m_Text2Str != null)
          StringManager.Instance.DeSpawnString(this.m_ItemObj[index].m_Text2Str);
        if (this.m_ItemObj[index].m_Slider1TitleStr != null)
          StringManager.Instance.DeSpawnString(this.m_ItemObj[index].m_Slider1TitleStr);
        if (this.m_ItemObj[index].m_Slider1TimeStr != null)
          StringManager.Instance.DeSpawnString(this.m_ItemObj[index].m_Slider1TimeStr);
        if (this.m_ItemObj[index].m_TempTime != null)
          StringManager.Instance.DeSpawnString(this.m_ItemObj[index].m_TempTime);
        if (this.m_ItemObj[index].m_IconText != null)
          StringManager.Instance.DeSpawnString(this.m_ItemObj[index].m_IconText);
        this.m_ItemObj[index].m_Text1Str = (CString) null;
        this.m_ItemObj[index].m_Text2Str = (CString) null;
        this.m_ItemObj[index].m_Slider1TitleStr = (CString) null;
        this.m_ItemObj[index].m_Slider1TimeStr = (CString) null;
      }
    }
    if (this.m_EmptyStr != null)
      StringManager.Instance.DeSpawnString(this.m_EmptyStr);
    if (this.m_CheckMsgStr != null)
      StringManager.Instance.DeSpawnString(this.m_CheckMsgStr);
    GUIManager.Instance.RemoveSpriteAsset("UI_armypic");
    GUIManager.Instance.CloseOKCancelBox();
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (this.UIType == eArmyUIType.eHideArmyMod)
    {
      switch (arg1)
      {
        case 1:
          this.door.CloseMenu();
          break;
        case 2:
          this.SetData();
          List<float> _DataHeight1 = new List<float>();
          for (int index = 0; index < this.m_Data.Count; ++index)
            _DataHeight1.Add(140f);
          if (this.m_Data.Count == 0)
          {
            this.door.CloseMenu();
            break;
          }
          this.m_ScrollPanel.AddNewDataHeight(_DataHeight1, false);
          break;
      }
    }
    else
    {
      if (this.UIType != eArmyUIType.eTroopArmyMod)
        return;
      this.SetData();
      List<float> _DataHeight2 = new List<float>();
      for (int index = 0; index < this.m_Data.Count; ++index)
        _DataHeight2.Add(140f);
      if (this.m_Data.Count == 0)
        this.door.CloseMenu();
      else
        this.m_ScrollPanel.AddNewDataHeight(_DataHeight2, false);
    }
  }

  public override bool OnBackButtonClick() => false;

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    switch (arg1)
    {
      case 0:
        DataManager.Instance.sendCancelRally();
        break;
      case 1:
        DataManager.Instance.TroopeTakeBack(arg2, EMarchEventType.EMET_InforceStanby);
        break;
      case 2:
        DataManager.Instance.TroopeTakeBack(arg2, EMarchEventType.EMET_Camp);
        break;
      case 3:
        AmbushManager.Instance.SendAmbushReturn((byte) arg2);
        break;
    }
  }

  private void Update()
  {
    this.m_TimeTick += Time.deltaTime;
    if ((double) this.m_TimeTick >= (double) this.m_ResTextChangeTime * 2.0)
    {
      this.m_TimeTick = 0.0f;
      this.m_ResTextType = this.m_ResTextType != (byte) 0 ? (byte) 0 : (byte) 1;
    }
    this.colorA = (double) this.m_TimeTick < (double) this.m_ResTextChangeTime ? Mathf.Lerp(0.0f, 2f, this.m_TimeTick / this.m_ResTextChangeTime) : Mathf.Lerp(0.0f, 2f, (this.m_ResTextChangeTime * 2f - this.m_TimeTick) / this.m_ResTextChangeTime);
    if (this.m_Data.Count <= 0)
      return;
    for (int panelObjectIdx = 0; panelObjectIdx < 5; ++panelObjectIdx)
    {
      if (this.m_ItemObj[panelObjectIdx] != null)
      {
        int dataIdx = this.m_ItemObj[panelObjectIdx].m_dataIdx;
        if (dataIdx < this.m_Data.Count)
        {
          if (this.UIType == eArmyUIType.eHideArmyMod)
            this.CalculateSlider_HideArmy(0);
          else if (this.m_Data[dataIdx].m_DataType == eArmyDataType.LordReturn)
            this.CalculateSlider_Lord(panelObjectIdx);
          else if (this.m_ItemObj[panelObjectIdx].m_dataIdx != -1)
          {
            if (this.m_ItemObj[panelObjectIdx].m_SliderType == (byte) 3)
              this.CalculateResSlider(this.m_ItemObj[panelObjectIdx].m_dataIdx, panelObjectIdx);
            else if (this.m_ItemObj[panelObjectIdx].m_SliderType == (byte) 2)
              this.CalculateOtherResSlider(this.m_ItemObj[panelObjectIdx].m_dataIdx, panelObjectIdx);
            else if (this.m_ItemObj[panelObjectIdx].m_SliderType == (byte) 1)
              this.CalculateSlider(this.m_ItemObj[panelObjectIdx].m_dataIdx, panelObjectIdx);
          }
        }
      }
    }
  }

  private void SetScrollItem(int dataIdx, int panelObjectIdx, GameObject item)
  {
    UIButton[] uiButtonArray = new UIButton[4];
    int index1 = this.m_Data[dataIdx].m_Index;
    bool flag = false;
    ushort leaderId = DataManager.Instance.GetLeaderID();
    for (int index2 = 0; index2 < this.DM.MarchEventData[index1].HeroID.Length; ++index2)
    {
      if ((int) leaderId == (int) this.DM.MarchEventData[index1].HeroID[index2])
      {
        flag = true;
        break;
      }
    }
    ((Behaviour) item.transform.GetChild(11).GetComponent<Image>()).enabled = flag;
    ushort zoneId = this.DM.MarchEventData[index1].Point.zoneID;
    byte pointId = this.DM.MarchEventData[index1].Point.pointID;
    POINT_KIND pointKind = DataManager.Instance.MarchEventData[index1].PointKind;
    if (this.m_ItemObj[panelObjectIdx] == null)
      this.m_ItemObj[panelObjectIdx] = new ArmyInfoObect();
    if ((Object) this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon == (Object) null)
    {
      this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon = item.transform.GetChild(0).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1 = item.transform.GetChild(1).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2 = item.transform.GetChild(2).GetComponent<UIText>();
      Transform child1 = item.transform.GetChild(3);
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value = child1.GetChild(0).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title = child1.GetChild(1).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time = child1.GetChild(2).GetComponent<UIText>();
      Transform child2 = item.transform.GetChild(4);
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value1 = child2.GetChild(0).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value2 = child2.GetChild(1).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Title = child2.GetChild(2).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Time = child2.GetChild(3).GetComponent<UIText>();
      Transform child3 = item.transform.GetChild(5);
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Value = child3.GetChild(0).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Title = child3.GetChild(1).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time = child3.GetChild(2).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_Slider1 = item.transform.GetChild(3);
      this.m_ItemObj[panelObjectIdx].m_Slider2 = item.transform.GetChild(4);
      this.m_ItemObj[panelObjectIdx].m_Slider3 = item.transform.GetChild(5);
      Transform child4 = item.transform.GetChild(10);
      this.m_ItemObj[panelObjectIdx].m_ScrollIconText = child4.GetComponent<UIText>();
    }
    this.m_ItemObj[panelObjectIdx].PointKind = this.DM.MarchEventData[index1].PointKind;
    this.m_ItemObj[panelObjectIdx].m_Type = this.DM.MarchEventData[index1].Type;
    this.m_ItemObj[panelObjectIdx].bHost = this.DM.MarchEventData[index1].bRallyHost;
    uiButtonArray[0] = item.transform.GetChild(6).GetComponent<UIButton>();
    uiButtonArray[0].m_Handler = (IUIButtonClickHandler) this;
    uiButtonArray[0].m_BtnID1 = dataIdx;
    uiButtonArray[0].m_BtnID2 = 6;
    uiButtonArray[1] = item.transform.GetChild(7).GetComponent<UIButton>();
    uiButtonArray[1].m_Handler = (IUIButtonClickHandler) this;
    uiButtonArray[1].m_BtnID1 = dataIdx;
    uiButtonArray[1].m_BtnID2 = 7;
    uiButtonArray[2] = item.transform.GetChild(8).GetComponent<UIButton>();
    uiButtonArray[2].m_Handler = (IUIButtonClickHandler) this;
    uiButtonArray[2].m_BtnID1 = dataIdx;
    uiButtonArray[2].m_BtnID2 = 8;
    item.transform.GetChild(8).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(547U);
    uiButtonArray[3] = item.transform.GetChild(9).GetComponent<UIButton>();
    uiButtonArray[3].m_Handler = (IUIButtonClickHandler) this;
    uiButtonArray[3].m_BtnID1 = dataIdx;
    uiButtonArray[3].m_BtnID2 = 9;
    item.transform.GetChild(9).GetChild(0).GetComponent<UIText>().text = this.m_ItemObj[panelObjectIdx].m_Type < EMarchEventType.EMET_RallyStanby || this.m_ItemObj[panelObjectIdx].m_Type > EMarchEventType.EMET_DeliverMarching ? this.DM.mStringTable.GetStringByID(538U) : ((this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyStanby || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyMarching || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyAttack) && this.m_ItemObj[panelObjectIdx].bHost == (byte) 1 || this.m_ItemObj[panelObjectIdx].bHost == (byte) 4 ? this.DM.mStringTable.GetStringByID(541U) : this.DM.mStringTable.GetStringByID(548U));
    if (this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_Gathering || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_Camp || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_InforceStanby || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyStanby)
      ((Component) uiButtonArray[1]).gameObject.SetActive(false);
    else
      ((Component) uiButtonArray[1]).gameObject.SetActive(true);
    if (this.m_ItemObj[panelObjectIdx].m_Type >= EMarchEventType.EMET_AttackReturn && this.m_ItemObj[panelObjectIdx].m_Type <= EMarchEventType.EMET_HitMonsterRetreat || (this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyStanby || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyMarching || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyAttack) && (this.m_ItemObj[panelObjectIdx].bHost == (byte) 0 || this.m_ItemObj[panelObjectIdx].bHost == (byte) 3))
    {
      ((Component) uiButtonArray[3]).gameObject.SetActive(false);
      ((Component) uiButtonArray[2]).transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(288f, 0.0f);
    }
    else
    {
      ((Component) uiButtonArray[3]).gameObject.SetActive(true);
      ((Component) uiButtonArray[2]).transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(288f, 34.5f);
    }
    if (this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_ScoutMarching || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_ScoutReturn || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_DeliverMarching || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_DeliverReturn)
    {
      ((Component) uiButtonArray[0]).gameObject.SetActive(false);
      ((Behaviour) this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2).enabled = false;
    }
    else
    {
      ((Component) uiButtonArray[0]).gameObject.SetActive(true);
      ((Behaviour) this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2).enabled = true;
    }
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon.sprite = this.GetIconSprite(this.m_ItemObj[panelObjectIdx].m_Type, this.m_ItemObj[panelObjectIdx].bHost);
    ((MaskableGraphic) this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon).material = this.m_Mat;
    this.SetMpaPointName(this.m_ItemObj[panelObjectIdx].m_Text1Str, index1);
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.text = this.m_ItemObj[panelObjectIdx].m_Text1Str.ToString();
    if (this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyReturn)
      ((Component) this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1).gameObject.SetActive(false);
    else
      ((Component) this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1).gameObject.SetActive(true);
    this.SetArmyNumName(this.m_ItemObj[panelObjectIdx].m_Text2Str, index1);
    if (this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_HitMonsterMarching || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_HitMonsterReturn || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_HitMonsterRetreat)
      ((Component) this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2).gameObject.SetActive(false);
    else
      ((Component) this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2).gameObject.SetActive(true);
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.text = this.m_ItemObj[panelObjectIdx].m_Text2Str.ToString();
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.SetAllDirty();
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.cachedTextGenerator.Invalidate();
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.SetAllDirty();
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.cachedTextGenerator.Invalidate();
    if ((this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_Camp || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_CampReturn) && this.m_ItemObj[panelObjectIdx].PointKind == POINT_KIND.PK_YOLK)
    {
      byte desPointLevel = this.DM.MarchEventData[dataIdx].DesPointLevel;
      this.SetIconText(this.m_ItemObj[panelObjectIdx].m_ScrollIconText, this.m_ItemObj[panelObjectIdx].m_Type, this.m_ItemObj[panelObjectIdx].PointKind, desPointLevel, this.m_ItemObj[panelObjectIdx].m_IconText, this.m_ItemObj[panelObjectIdx].bHost);
    }
    else
      this.SetIconText(this.m_ItemObj[panelObjectIdx].m_ScrollIconText, this.m_ItemObj[panelObjectIdx].m_Type, this.m_ItemObj[panelObjectIdx].PointKind, (byte) 0, bRallyHost: this.m_ItemObj[panelObjectIdx].bHost);
    this.m_ItemObj[panelObjectIdx].m_dataIdx = dataIdx;
    if (this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_Camp || this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_InforceStanby)
    {
      this.m_ItemObj[panelObjectIdx].m_Slider1.gameObject.SetActive(false);
      this.m_ItemObj[panelObjectIdx].m_Slider2.gameObject.SetActive(false);
      this.m_ItemObj[panelObjectIdx].m_Slider3.gameObject.SetActive(false);
      this.m_ItemObj[panelObjectIdx].m_SliderType = (byte) 3;
      ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title).rectTransform.anchoredPosition = new Vector2(104.13f, 0.0f);
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.alignment = TextAnchor.MiddleRight;
      ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title).rectTransform.sizeDelta = new Vector2(142.15f, 29f);
      ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time).rectTransform.anchoredPosition = new Vector2(80.6f, 0.5f);
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.alignment = TextAnchor.MiddleLeft;
      ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time).rectTransform.sizeDelta = new Vector2(129.3f, 29f);
      this.m_ItemObj[panelObjectIdx].m_MaxOverload = 0U;
    }
    else
    {
      if (pointKind == POINT_KIND.PK_CRYSTAL && this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_Gathering)
      {
        this.m_ItemObj[panelObjectIdx].m_Slider1.gameObject.SetActive(false);
        this.m_ItemObj[panelObjectIdx].m_Slider2.gameObject.SetActive(true);
        this.m_ItemObj[panelObjectIdx].m_Slider3.gameObject.SetActive(true);
        this.m_ItemObj[panelObjectIdx].m_SliderType = (byte) 3;
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.m_EmptyStr.ToString();
        ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time).rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.alignment = TextAnchor.MiddleCenter;
        ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time).rectTransform.sizeDelta = new Vector2(360f, 29f);
      }
      else if (pointKind >= POINT_KIND.PK_FOOD && pointKind <= POINT_KIND.PK_GOLD && this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_Gathering)
      {
        this.m_ItemObj[panelObjectIdx].m_Slider1.gameObject.SetActive(true);
        ((Behaviour) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time).enabled = false;
        this.m_ItemObj[panelObjectIdx].m_Slider2.gameObject.SetActive(false);
        this.m_ItemObj[panelObjectIdx].m_Slider3.gameObject.SetActive(false);
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.m_EmptyStr.ToString();
        this.m_ItemObj[panelObjectIdx].m_SliderType = (byte) 2;
        ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title).rectTransform.anchoredPosition = new Vector2(0.0f, 0.0f);
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.alignment = TextAnchor.MiddleCenter;
        ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title).rectTransform.sizeDelta = new Vector2(350f, 29f);
        ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time).rectTransform.anchoredPosition = new Vector2(80.6f, 0.5f);
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.alignment = TextAnchor.MiddleLeft;
        ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time).rectTransform.sizeDelta = new Vector2(129.3f, 29f);
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value.sprite = this.m_SpArray.GetSprite(1);
      }
      else
      {
        this.m_ItemObj[panelObjectIdx].m_Slider1.gameObject.SetActive(true);
        ((Behaviour) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time).enabled = true;
        this.m_ItemObj[panelObjectIdx].m_Slider2.gameObject.SetActive(false);
        this.m_ItemObj[panelObjectIdx].m_Slider3.gameObject.SetActive(false);
        this.m_ItemObj[panelObjectIdx].m_SliderType = (byte) 1;
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.DM.mStringTable.GetStringByID(546U);
        ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title).rectTransform.anchoredPosition = new Vector2(-104.13f, 0.0f);
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.alignment = TextAnchor.MiddleRight;
        ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title).rectTransform.sizeDelta = new Vector2(142.15f, 29f);
        ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time).rectTransform.anchoredPosition = new Vector2(80.6f, 0.5f);
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.alignment = TextAnchor.MiddleLeft;
        ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time).rectTransform.sizeDelta = new Vector2(129.3f, 29f);
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value.sprite = this.m_SpArray.GetSprite(0);
      }
      this.m_ItemObj[panelObjectIdx].m_ResStartTime = DataManager.Instance.MarchEventTime[index1].BeginTime;
      long requireTime = (long) DataManager.Instance.MarchEventTime[index1].RequireTime;
      this.m_ItemObj[panelObjectIdx].m_MaxOverload = DataManager.Instance.MarchEventData[index1].MaxOverLoad;
      this.m_ItemObj[panelObjectIdx].m_ResRate = (float) this.m_ItemObj[panelObjectIdx].m_MaxOverload / (float) requireTime;
    }
  }

  private void SetScrollItem_Lord(int dataIdx, int panelObjectIdx, GameObject item)
  {
    UIButton[] uiButtonArray = new UIButton[4];
    if (this.m_ItemObj[panelObjectIdx] == null)
      this.m_ItemObj[panelObjectIdx] = new ArmyInfoObect();
    if ((Object) this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon == (Object) null)
    {
      this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon = item.transform.GetChild(0).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1 = item.transform.GetChild(1).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2 = item.transform.GetChild(2).GetComponent<UIText>();
      Transform child1 = item.transform.GetChild(3);
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value = child1.GetChild(0).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title = child1.GetChild(1).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time = child1.GetChild(2).GetComponent<UIText>();
      Transform child2 = item.transform.GetChild(4);
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value1 = child2.GetChild(0).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value2 = child2.GetChild(1).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Title = child2.GetChild(2).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Time = child2.GetChild(3).GetComponent<UIText>();
      Transform child3 = item.transform.GetChild(5);
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Value = child3.GetChild(0).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Title = child3.GetChild(1).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time = child3.GetChild(2).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_Slider1 = item.transform.GetChild(3);
      this.m_ItemObj[panelObjectIdx].m_Slider2 = item.transform.GetChild(4);
      this.m_ItemObj[panelObjectIdx].m_Slider3 = item.transform.GetChild(5);
      Transform child4 = item.transform.GetChild(10);
      this.m_ItemObj[panelObjectIdx].m_ScrollIconText = child4.GetComponent<UIText>();
    }
    uiButtonArray[0] = item.transform.GetChild(6).GetComponent<UIButton>();
    uiButtonArray[0].m_Handler = (IUIButtonClickHandler) this;
    uiButtonArray[0].m_BtnID1 = dataIdx;
    uiButtonArray[0].m_BtnID2 = 6;
    uiButtonArray[1] = item.transform.GetChild(7).GetComponent<UIButton>();
    uiButtonArray[1].m_Handler = (IUIButtonClickHandler) this;
    uiButtonArray[1].m_BtnID1 = dataIdx;
    uiButtonArray[1].m_BtnID2 = 7;
    uiButtonArray[2] = item.transform.GetChild(8).GetComponent<UIButton>();
    uiButtonArray[2].m_Handler = (IUIButtonClickHandler) this;
    uiButtonArray[2].m_BtnID1 = dataIdx;
    uiButtonArray[2].m_BtnID2 = 8;
    ((Component) uiButtonArray[2]).transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(288f, 0.0f);
    item.transform.GetChild(8).GetChild(0).GetComponent<UIText>().text = this.DM.mStringTable.GetStringByID(547U);
    uiButtonArray[3] = item.transform.GetChild(9).GetComponent<UIButton>();
    uiButtonArray[3].m_Handler = (IUIButtonClickHandler) this;
    uiButtonArray[3].m_BtnID1 = dataIdx;
    uiButtonArray[3].m_BtnID2 = 9;
    ((Component) uiButtonArray[0]).gameObject.SetActive(false);
    ((Component) uiButtonArray[1]).gameObject.SetActive(true);
    ((Component) uiButtonArray[2]).gameObject.SetActive(true);
    ((Component) uiButtonArray[3]).gameObject.SetActive(false);
    this.SetLordPointName(this.m_ItemObj[panelObjectIdx].m_Text1Str);
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.text = string.Empty;
    this.m_ItemObj[panelObjectIdx].m_Type = EMarchEventType.EMET_LordReturn;
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon.sprite = this.GetIconSprite(this.m_ItemObj[panelObjectIdx].m_Type, this.m_ItemObj[panelObjectIdx].bHost);
    ((MaskableGraphic) this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon).material = this.m_Mat;
    this.SetIconText(this.m_ItemObj[panelObjectIdx].m_ScrollIconText, this.m_ItemObj[panelObjectIdx].m_Type, this.m_ItemObj[panelObjectIdx].PointKind, (byte) 0, bRallyHost: this.m_ItemObj[panelObjectIdx].bHost);
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.text = this.m_ItemObj[panelObjectIdx].m_Text1Str.ToString();
    this.m_ItemObj[panelObjectIdx].m_ScrollIconText.SetAllDirty();
    this.m_ItemObj[panelObjectIdx].m_dataIdx = dataIdx;
  }

  private void SetScrollItem_HideArmy(int dataIdx, int panelObjectIdx, GameObject item)
  {
    UIButton[] uiButtonArray = new UIButton[4];
    if (this.m_ItemObj[panelObjectIdx] == null)
      this.m_ItemObj[panelObjectIdx] = new ArmyInfoObect();
    if ((Object) this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon == (Object) null)
    {
      this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon = item.transform.GetChild(0).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1 = item.transform.GetChild(1).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2 = item.transform.GetChild(2).GetComponent<UIText>();
      Transform child1 = item.transform.GetChild(3);
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value = child1.GetChild(0).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title = child1.GetChild(1).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time = child1.GetChild(2).GetComponent<UIText>();
      Transform child2 = item.transform.GetChild(4);
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value1 = child2.GetChild(0).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value2 = child2.GetChild(1).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Title = child2.GetChild(2).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Time = child2.GetChild(3).GetComponent<UIText>();
      Transform child3 = item.transform.GetChild(5);
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Value = child3.GetChild(0).GetComponent<Image>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Title = child3.GetChild(1).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time = child3.GetChild(2).GetComponent<UIText>();
      this.m_ItemObj[panelObjectIdx].m_Slider1 = item.transform.GetChild(3);
      this.m_ItemObj[panelObjectIdx].m_Slider2 = item.transform.GetChild(4);
      this.m_ItemObj[panelObjectIdx].m_Slider3 = item.transform.GetChild(5);
      Transform child4 = item.transform.GetChild(10);
      this.m_ItemObj[panelObjectIdx].m_ScrollIconText = child4.GetComponent<UIText>();
    }
    ((Behaviour) item.transform.GetChild(11).GetComponent<Image>()).enabled = HideArmyManager.Instance.IsLordInShelter();
    uiButtonArray[0] = item.transform.GetChild(6).GetComponent<UIButton>();
    uiButtonArray[0].m_Handler = (IUIButtonClickHandler) this;
    uiButtonArray[0].m_BtnID1 = dataIdx;
    uiButtonArray[0].m_BtnID2 = 6;
    uiButtonArray[1] = item.transform.GetChild(7).GetComponent<UIButton>();
    uiButtonArray[1].m_Handler = (IUIButtonClickHandler) this;
    uiButtonArray[1].m_BtnID1 = dataIdx;
    uiButtonArray[1].m_BtnID2 = 7;
    uiButtonArray[2] = item.transform.GetChild(8).GetComponent<UIButton>();
    uiButtonArray[2].m_Handler = (IUIButtonClickHandler) this;
    uiButtonArray[2].m_BtnID1 = dataIdx;
    uiButtonArray[2].m_BtnID2 = 8;
    item.transform.GetChild(8).GetChild(0).GetComponent<UIText>();
    uiButtonArray[3] = item.transform.GetChild(9).GetComponent<UIButton>();
    UIText component = item.transform.GetChild(9).GetChild(0).GetComponent<UIText>();
    component.text = this.DM.mStringTable.GetStringByID(548U);
    uiButtonArray[3].m_Handler = (IUIButtonClickHandler) this;
    uiButtonArray[3].m_BtnID1 = dataIdx;
    uiButtonArray[3].m_BtnID2 = 9;
    ((Component) uiButtonArray[3]).transform.GetComponent<RectTransform>().anchoredPosition = new Vector2(288f, 0.0f);
    ((Component) uiButtonArray[0]).gameObject.SetActive(true);
    ((Component) uiButtonArray[1]).gameObject.SetActive(false);
    ((Component) uiButtonArray[2]).gameObject.SetActive(false);
    ((Component) uiButtonArray[3]).gameObject.SetActive(true);
    component.text = this.DM.mStringTable.GetStringByID(548U);
    this.SetHiedArmyPointName(this.m_ItemObj[panelObjectIdx].m_Text1Str);
    this.SetHideArmyNumName(this.m_ItemObj[panelObjectIdx].m_Text2Str);
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.text = this.m_ItemObj[panelObjectIdx].m_Text2Str.ToString();
    this.m_ItemObj[panelObjectIdx].m_Type = EMarchEventType.EMET_Camp;
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon.sprite = this.GetIconSprite(this.m_ItemObj[panelObjectIdx].m_Type, this.m_ItemObj[panelObjectIdx].bHost);
    ((MaskableGraphic) this.m_ItemObj[panelObjectIdx].m_ScrollSliderIcon).material = this.m_Mat;
    this.m_ItemObj[panelObjectIdx].m_ScrollIconText.text = this.DM.mStringTable.GetStringByID(8590U);
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.text = this.m_ItemObj[panelObjectIdx].m_Text1Str.ToString();
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.SetAllDirty();
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderText1.cachedTextGenerator.Invalidate();
    this.m_ItemObj[panelObjectIdx].m_ScrollIconText.SetAllDirty();
    this.m_ItemObj[panelObjectIdx].m_ScrollIconText.cachedTextGenerator.Invalidate();
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.SetAllDirty();
    this.m_ItemObj[panelObjectIdx].m_ScrollSliderText2.cachedTextGenerator.Invalidate();
    this.m_ItemObj[panelObjectIdx].m_dataIdx = dataIdx;
  }

  private void SetMpaPointName(CString str, int dataIdx)
  {
    StringManager instance = StringManager.Instance;
    PointCode point = this.DM.MarchEventData[dataIdx].Point;
    str.ClearString();
    EMarchEventType type = this.DM.MarchEventData[dataIdx].Type;
    POINT_KIND pointKind = this.DM.MarchEventData[dataIdx].PointKind;
    byte bRallyHost = this.DM.MarchEventData[dataIdx].bRallyHost;
    byte desPointLevel = this.DM.MarchEventData[dataIdx].DesPointLevel;
    Vector2 vector2 = pointKind != POINT_KIND.PK_YOLK ? GameConstants.getTileMapPosbyPointCode(point.zoneID, point.pointID) : DataManager.MapDataController.GetYolkPos((ushort) desPointLevel, DataManager.MapDataController.FocusKingdomID);
    CString tmpS = StringManager.Instance.StaticString1024();
    tmpS.IntToFormat((long) desPointLevel);
    tmpS.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(12021U));
    if (type < EMarchEventType.EMET_AttackReturn)
      instance.StringToFormat(this.DM.mStringTable.GetStringByID(544U));
    else
      instance.StringToFormat(this.DM.mStringTable.GetStringByID(543U));
    switch (pointKind)
    {
      case POINT_KIND.PK_NONE:
      case POINT_KIND.PK_NPC:
        instance.StringToFormat(this.DM.mStringTable.GetStringByID(4579U));
        instance.FloatToFormat(vector2.x);
        instance.FloatToFormat(vector2.y);
        str.AppendFormat("{0} : {1}(X : {2} Y : {3})");
        break;
      case POINT_KIND.PK_FOOD:
        instance.StringToFormat(this.DM.mStringTable.GetStringByID(6031U));
        instance.StringToFormat(this.DM.mStringTable.GetStringByID(32U));
        instance.IntToFormat((long) desPointLevel);
        instance.FloatToFormat(vector2.x);
        instance.FloatToFormat(vector2.y);
        str.AppendFormat("{0} : {1} {2}{3}(X : {4} Y : {5})");
        break;
      case POINT_KIND.PK_STONE:
        instance.StringToFormat(this.DM.mStringTable.GetStringByID(6028U));
        instance.StringToFormat(this.DM.mStringTable.GetStringByID(32U));
        instance.IntToFormat((long) desPointLevel);
        instance.FloatToFormat(vector2.x);
        instance.FloatToFormat(vector2.y);
        str.AppendFormat("{0} : {1} {2}{3}(X : {4} Y : {5})");
        break;
      case POINT_KIND.PK_IRON:
        instance.StringToFormat(this.DM.mStringTable.GetStringByID(6030U));
        instance.StringToFormat(this.DM.mStringTable.GetStringByID(32U));
        instance.IntToFormat((long) desPointLevel);
        instance.FloatToFormat(vector2.x);
        instance.FloatToFormat(vector2.y);
        str.AppendFormat("{0} : {1} {2}{3}(X : {4} Y : {5})");
        break;
      case POINT_KIND.PK_WOOD:
        instance.StringToFormat(this.DM.mStringTable.GetStringByID(6029U));
        instance.StringToFormat(this.DM.mStringTable.GetStringByID(32U));
        instance.IntToFormat((long) desPointLevel);
        instance.FloatToFormat(vector2.x);
        instance.FloatToFormat(vector2.y);
        str.AppendFormat("{0} : {1} {2}{3}(X : {4} Y : {5})");
        break;
      case POINT_KIND.PK_GOLD:
        instance.StringToFormat(this.DM.mStringTable.GetStringByID(6033U));
        instance.StringToFormat(this.DM.mStringTable.GetStringByID(32U));
        instance.IntToFormat((long) desPointLevel);
        instance.FloatToFormat(vector2.x);
        instance.FloatToFormat(vector2.y);
        str.AppendFormat("{0} : {1} {2}{3}(X : {4} Y : {5})");
        break;
      case POINT_KIND.PK_CRYSTAL:
        instance.StringToFormat(this.DM.mStringTable.GetStringByID(6032U));
        instance.StringToFormat(this.DM.mStringTable.GetStringByID(32U));
        instance.IntToFormat((long) desPointLevel);
        instance.FloatToFormat(vector2.x);
        instance.FloatToFormat(vector2.y);
        str.AppendFormat("{0} : {1} {2}{3}(X : {4} Y : {5})");
        break;
      case POINT_KIND.PK_CITY:
        if (bRallyHost == (byte) 3 && type != EMarchEventType.EMET_RallyMarching && type != EMarchEventType.EMET_RallyStanby || bRallyHost == (byte) 4)
        {
          instance.StringToFormat(tmpS);
          instance.FloatToFormat(vector2.x);
          instance.FloatToFormat(vector2.y);
          str.AppendFormat("{0} : {1}(X : {2} Y : {3})");
          break;
        }
        instance.StringToFormat(this.DM.MarchEventData[dataIdx].DesPlayerName);
        instance.FloatToFormat(vector2.x);
        instance.FloatToFormat(vector2.y);
        str.AppendFormat("{0} : {1}(X : {2} Y : {3})");
        break;
      case POINT_KIND.PK_CAMP:
        instance.StringToFormat(this.DM.mStringTable.GetStringByID(4540U));
        instance.FloatToFormat(vector2.x);
        instance.FloatToFormat(vector2.y);
        str.AppendFormat("{0} : {1}(X : {2} Y : {3})");
        break;
      case POINT_KIND.PK_YOLK:
        instance.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) desPointLevel, DataManager.MapDataController.OtherKingdomData.kingdomID));
        instance.FloatToFormat(vector2.x);
        instance.FloatToFormat(vector2.y);
        str.AppendFormat("{0} : {1}(X : {2} Y : {3})");
        break;
    }
  }

  private void SetLordPointName(CString str)
  {
    StringManager instance = StringManager.Instance;
    PointCode pointCode;
    GameConstants.MapIDToPointCode(this.DM.beCaptured.MapID, out pointCode.zoneID, out pointCode.pointID);
    Vector2 mapPosbyPointCode = GameConstants.getTileMapPosbyPointCode(pointCode.zoneID, pointCode.pointID);
    str.ClearString();
    instance.StringToFormat(this.DM.mStringTable.GetStringByID(543U));
    instance.StringToFormat(this.DM.beCaptured.name);
    instance.FloatToFormat(mapPosbyPointCode.x);
    instance.FloatToFormat(mapPosbyPointCode.y);
    str.AppendFormat("{0} : {1}(X : {2} Y : {3})");
  }

  private void SetHiedArmyPointName(CString str)
  {
    StringManager instance = StringManager.Instance;
    PointCode pointCode;
    GameConstants.MapIDToPointCode(this.DM.beCaptured.MapID, out pointCode.zoneID, out pointCode.pointID);
    GameConstants.getTileMapPosbyPointCode(pointCode.zoneID, pointCode.pointID);
    str.ClearString();
    instance.StringToFormat(this.DM.mStringTable.GetStringByID(544U));
    instance.StringToFormat(this.DM.mStringTable.GetStringByID(9046U));
    str.AppendFormat("{0} : {1}");
  }

  private void SetArmyNumName(CString str, int dataIdx)
  {
    str.ClearString();
    long x = 0;
    for (int index1 = 0; index1 < 4; ++index1)
    {
      for (int index2 = 0; index2 < 4; ++index2)
        x += (long) this.DM.MarchEventData[dataIdx].TroopData[index1][index2];
    }
    StringManager.Instance.StringToFormat(this.DM.mStringTable.GetStringByID(545U));
    StringManager.Instance.IntToFormat(x, bNumber: true);
    str.AppendFormat("{0} : {1}");
  }

  private void SetHideArmyNumName(CString str)
  {
    str.ClearString();
    StringManager.Instance.StringToFormat(this.DM.mStringTable.GetStringByID(545U));
    StringManager.Instance.IntToFormat(HideArmyManager.Instance.GetTotalHideArmy(), bNumber: true);
    str.AppendFormat("{0} : {1}");
  }

  private void SetIconText(
    UIText text,
    EMarchEventType Type,
    POINT_KIND PointKind,
    byte wonderId = 0,
    CString cStr = null,
    byte bRallyHost = 0)
  {
    switch (Type)
    {
      case EMarchEventType.EMET_Camp:
        if (PointKind == POINT_KIND.PK_YOLK)
        {
          if (cStr != null)
          {
            cStr.ClearString();
            if (wonderId == (byte) 0)
              cStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
            else if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID != (int) ActivityManager.Instance.KOWKingdomID)
              cStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309U));
            else
              cStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
            cStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9301U));
            text.text = cStr.ToString();
            text.SetAllDirty();
            text.cachedTextGenerator.Invalidate();
            break;
          }
          break;
        }
        text.text = bRallyHost != (byte) 1 ? DataManager.Instance.mStringTable.GetStringByID(553U) : DataManager.Instance.mStringTable.GetStringByID(9733U);
        break;
      case EMarchEventType.EMET_Gathering:
        text.text = DataManager.Instance.mStringTable.GetStringByID(556U);
        break;
      case EMarchEventType.EMET_InforceStanby:
        text.text = DataManager.Instance.mStringTable.GetStringByID(560U);
        break;
      case EMarchEventType.EMET_RallyStanby:
        text.text = DataManager.Instance.mStringTable.GetStringByID(565U);
        break;
      case EMarchEventType.EMET_AttackMarching:
        text.text = DataManager.Instance.mStringTable.GetStringByID(549U);
        break;
      case EMarchEventType.EMET_CampMarching:
        switch (bRallyHost)
        {
          case 1:
            text.text = DataManager.Instance.mStringTable.GetStringByID(9734U);
            break;
          case 2:
            text.text = DataManager.Instance.mStringTable.GetStringByID(9908U);
            break;
          default:
            text.text = DataManager.Instance.mStringTable.GetStringByID(551U);
            break;
        }
        break;
      case EMarchEventType.EMET_GatherMarching:
        text.text = DataManager.Instance.mStringTable.GetStringByID(554U);
        break;
      case EMarchEventType.EMET_ScoutMarching:
        text.text = DataManager.Instance.mStringTable.GetStringByID(561U);
        break;
      case EMarchEventType.EMET_HitMonsterMarching:
        text.text = DataManager.Instance.mStringTable.GetStringByID(8345U);
        break;
      case EMarchEventType.EMET_InforceMarching:
        text.text = DataManager.Instance.mStringTable.GetStringByID(558U);
        break;
      case EMarchEventType.EMET_RallyMarching:
        text.text = DataManager.Instance.mStringTable.GetStringByID(567U);
        break;
      case EMarchEventType.EMET_RallyAttack:
        text.text = DataManager.Instance.mStringTable.GetStringByID(569U);
        break;
      case EMarchEventType.EMET_DeliverMarching:
        text.text = DataManager.Instance.mStringTable.GetStringByID(563U);
        break;
      case EMarchEventType.EMET_AttackReturn:
        text.text = DataManager.Instance.mStringTable.GetStringByID(550U);
        break;
      case EMarchEventType.EMET_CampReturn:
        if (PointKind == POINT_KIND.PK_YOLK)
        {
          if (cStr != null)
          {
            cStr.ClearString();
            if (wonderId == (byte) 0)
              cStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
            else if ((int) DataManager.MapDataController.OtherKingdomData.kingdomID != (int) ActivityManager.Instance.KOWKingdomID)
              cStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9309U));
            else
              cStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(9308U));
            cStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(9302U));
            text.text = cStr.ToString();
            text.SetAllDirty();
            text.cachedTextGenerator.Invalidate();
            break;
          }
          break;
        }
        text.text = bRallyHost != (byte) 1 ? DataManager.Instance.mStringTable.GetStringByID(552U) : DataManager.Instance.mStringTable.GetStringByID(9735U);
        break;
      case EMarchEventType.EMET_GatherReturn:
        text.text = DataManager.Instance.mStringTable.GetStringByID(555U);
        break;
      case EMarchEventType.EMET_RallyReturn:
        text.text = DataManager.Instance.mStringTable.GetStringByID(568U);
        break;
      case EMarchEventType.EMET_ScoutReturn:
        text.text = DataManager.Instance.mStringTable.GetStringByID(562U);
        break;
      case EMarchEventType.EMET_HitMonsterReturn:
      case EMarchEventType.EMET_HitMonsterRetreat:
        text.text = DataManager.Instance.mStringTable.GetStringByID(8346U);
        break;
      case EMarchEventType.EMET_InfroceReturn:
        text.text = DataManager.Instance.mStringTable.GetStringByID(559U);
        break;
      case EMarchEventType.EMET_DeliverReturn:
        text.text = DataManager.Instance.mStringTable.GetStringByID(564U);
        break;
      case EMarchEventType.EMET_LordReturn:
        text.text = DataManager.Instance.mStringTable.GetStringByID(864U);
        break;
      case EMarchEventType.EMET_AttackRetreat:
        text.text = DataManager.Instance.mStringTable.GetStringByID(550U);
        break;
      case EMarchEventType.EMET_CampRetreat:
        text.text = bRallyHost != (byte) 1 ? DataManager.Instance.mStringTable.GetStringByID(552U) : DataManager.Instance.mStringTable.GetStringByID(9735U);
        break;
      case EMarchEventType.EMET_GatherRetreat:
        text.text = DataManager.Instance.mStringTable.GetStringByID(555U);
        break;
      case EMarchEventType.EMET_RallyRetreat:
        text.text = DataManager.Instance.mStringTable.GetStringByID(568U);
        break;
    }
    Vector2 sizeDelta = ((Graphic) text).rectTransform.sizeDelta with
    {
      x = (double) text.preferredWidth <= 160.0 ? text.preferredWidth : 160f
    };
    ((Graphic) text).rectTransform.sizeDelta = sizeDelta;
  }

  private int GetBtnState(EMarchEventType Type) => 2;

  private Sprite GetIconSprite(EMarchEventType Type, byte bRallyHost = 0)
  {
    switch (Type)
    {
      case EMarchEventType.EMET_Camp:
        return bRallyHost == (byte) 1 ? GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_12") : GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_05");
      case EMarchEventType.EMET_Gathering:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_05");
      case EMarchEventType.EMET_InforceStanby:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_01");
      case EMarchEventType.EMET_RallyStanby:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_06");
      case EMarchEventType.EMET_AttackMarching:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_03");
      case EMarchEventType.EMET_CampMarching:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_03");
      case EMarchEventType.EMET_GatherMarching:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_03");
      case EMarchEventType.EMET_ScoutMarching:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_02");
      case EMarchEventType.EMET_HitMonsterMarching:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_09");
      case EMarchEventType.EMET_InforceMarching:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_03");
      case EMarchEventType.EMET_RallyMarching:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_03");
      case EMarchEventType.EMET_RallyAttack:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_07");
      case EMarchEventType.EMET_DeliverMarching:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_08");
      case EMarchEventType.EMET_AttackReturn:
      case EMarchEventType.EMET_AttackRetreat:
      case EMarchEventType.EMET_CampRetreat:
      case EMarchEventType.EMET_GatherRetreat:
      case EMarchEventType.EMET_RallyRetreat:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
      case EMarchEventType.EMET_CampReturn:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
      case EMarchEventType.EMET_GatherReturn:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
      case EMarchEventType.EMET_RallyReturn:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
      case EMarchEventType.EMET_ScoutReturn:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
      case EMarchEventType.EMET_HitMonsterReturn:
      case EMarchEventType.EMET_HitMonsterRetreat:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_10");
      case EMarchEventType.EMET_InfroceReturn:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
      case EMarchEventType.EMET_DeliverReturn:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_04");
      case EMarchEventType.EMET_LordReturn:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_11");
      default:
        return GUIManager.Instance.LoadSprite("UI_armypic", "UI_army_pic_01");
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (dataIdx < 0 || dataIdx >= this.m_Data.Count)
      return;
    if (this.UIType == eArmyUIType.eHideArmyMod)
      this.SetScrollItem_HideArmy(dataIdx, panelObjectIdx, item);
    else if (this.m_Data[dataIdx].m_DataType == eArmyDataType.LordReturn)
      this.SetScrollItem_Lord(dataIdx, panelObjectIdx, item);
    else
      this.SetScrollItem(dataIdx, panelObjectIdx, item);
  }

  public void CalculateSlider(int dataIdx, int panelObjectIdx)
  {
    if (dataIdx >= this.m_Data.Count)
      return;
    int index = this.m_Data[dataIdx].m_Index;
    if (index >= this.DM.MarchEventTime.Length)
      return;
    long beginTime = this.DM.MarchEventTime[index].BeginTime;
    uint requireTime = this.DM.MarchEventTime[index].RequireTime;
    float num = Mathf.Clamp(((float) NetworkManager.ServerTime - (float) beginTime) / (float) requireTime, 0.0f, 1f);
    long time = (long) Mathf.Clamp((float) ((long) requireTime - (this.DM.ServerTime - beginTime)), 0.0f, (float) requireTime);
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value).rectTransform.sizeDelta = new Vector2(338f * num, 17f);
    this.SetTimeText(this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr, time);
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.text = this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.ToString();
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.SetAllDirty();
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.cachedTextGenerator.Invalidate();
    if (this.m_ItemObj[panelObjectIdx].m_Type == EMarchEventType.EMET_RallyStanby)
    {
      if ((double) num >= 0.99900001287460327)
      {
        if (!((Component) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time).gameObject.activeSelf)
          return;
        ((Component) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time).gameObject.SetActive(false);
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.DM.mStringTable.GetStringByID(4909U);
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.SetAllDirty();
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.cachedTextGenerator.Invalidate();
      }
      else
      {
        if (((Component) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time).gameObject.activeSelf)
          return;
        ((Component) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time).gameObject.SetActive(true);
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.DM.mStringTable.GetStringByID(546U);
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.SetAllDirty();
        this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.cachedTextGenerator.Invalidate();
      }
    }
    else
    {
      if (((Component) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time).gameObject.activeSelf)
        return;
      ((Component) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time).gameObject.SetActive(true);
    }
  }

  public void CalculateOtherResSlider(int dataIdx, int panelObjectIdx)
  {
    long resStartTime = this.m_ItemObj[panelObjectIdx].m_ResStartTime;
    float resRate = this.m_ItemObj[panelObjectIdx].m_ResRate;
    uint maxOverload = this.m_ItemObj[panelObjectIdx].m_MaxOverload;
    uint x = 0;
    if (NetworkManager.ServerTime >= (double) resStartTime)
      x = (uint) ((NetworkManager.ServerTime - (double) resStartTime) * (double) resRate);
    uint sec = (uint) ((double) maxOverload / (double) resRate) - (uint) ((double) x / (double) resRate);
    float num = Mathf.Clamp((float) x / (float) maxOverload, 0.0f, 1f);
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value).rectTransform.sizeDelta = new Vector2(338f * num, 17f);
    this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.ClearString();
    this.m_ItemObj[panelObjectIdx].m_TempTime.ClearString();
    if (this.m_ResTextType == (byte) 0)
    {
      this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(557U));
      this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.IntToFormat((long) x, bNumber: true);
      this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.IntToFormat((long) maxOverload, bNumber: true);
      this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.AppendFormat("{0} : {1} / {2}");
    }
    else
    {
      GameConstants.GetTimeString(this.m_ItemObj[panelObjectIdx].m_TempTime, sec);
      this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(817U));
      this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.StringToFormat(this.m_ItemObj[panelObjectIdx].m_TempTime);
      this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.AppendFormat("{0} : {1} ");
    }
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title).color = new Color(1f, 1f, 1f, this.colorA);
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.m_ItemObj[panelObjectIdx].m_Slider1TitleStr.ToString();
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.SetAllDirty();
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.cachedTextGenerator.Invalidate();
  }

  public void CalculateResSlider(int dataIdx, int panelObjectIdx)
  {
    long resStartTime = this.m_ItemObj[panelObjectIdx].m_ResStartTime;
    float resRate = this.m_ItemObj[panelObjectIdx].m_ResRate;
    uint x1 = this.m_ItemObj[panelObjectIdx].m_MaxOverload;
    float x2 = 0.0f;
    if (NetworkManager.ServerTime < (double) resStartTime)
      return;
    if (NetworkManager.ServerTime >= (double) resStartTime)
      x2 = ((float) NetworkManager.ServerTime - (float) resStartTime) * resRate;
    float sec = (float) ((double) x1 / (double) resRate - (NetworkManager.ServerTime - (double) resStartTime));
    float num1 = x2 / (float) x1;
    if ((double) num1 > 1.0)
      num1 = 1f;
    if (x1 <= 0U)
      x1 = 1U;
    float num2 = (float) x1 / resRate / (float) x1;
    float num3 = ((float) NetworkManager.ServerTime - (float) resStartTime) % num2 / num2;
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value1.fillAmount = num3;
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider2Value2.fillAmount = num3;
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Value).rectTransform.sizeDelta = new Vector2(338f * num1, 17f);
    this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.ClearString();
    this.m_ItemObj[panelObjectIdx].m_TempTime.ClearString();
    if ((double) x2 >= (double) x1)
      return;
    if (this.m_ResTextType == (byte) 0)
    {
      this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(691U));
      this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.IntToFormat((long) (uint) x2, bNumber: true);
      this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.IntToFormat((long) x1, bNumber: true);
      this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.AppendFormat("{0} {1} / {2}");
    }
    else
    {
      GameConstants.GetTimeString(this.m_ItemObj[panelObjectIdx].m_TempTime, (uint) sec);
      this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.StringToFormat(DataManager.Instance.mStringTable.GetStringByID(817U));
      this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.StringToFormat(this.m_ItemObj[panelObjectIdx].m_TempTime);
      this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.AppendFormat("{0} : {1} ");
    }
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time).color = new Color(1f, 1f, 1f, this.colorA);
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.text = this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.ToString();
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.SetAllDirty();
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.cachedTextGenerator.Invalidate();
  }

  public void CalculateSlider_Lord(int panelObjectIdx)
  {
    long startActionTime = this.DM.beCaptured.StartActionTime;
    uint totalTime = this.DM.beCaptured.TotalTime;
    if (totalTime == 0U)
      return;
    float num = Mathf.Clamp(((float) NetworkManager.ServerTime - (float) startActionTime) / (float) totalTime, 0.0f, 1f);
    long time = (long) Mathf.Clamp((float) ((long) totalTime - (this.DM.ServerTime - startActionTime)), 0.0f, (float) totalTime);
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value).rectTransform.sizeDelta = new Vector2(338f * num, 17f);
    this.SetTimeText(this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr, time);
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.text = this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.ToString();
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.SetAllDirty();
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.cachedTextGenerator.Invalidate();
    if (!((Component) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time).gameObject.activeSelf)
      ((Component) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time).gameObject.SetActive(true);
    this.m_ItemObj[panelObjectIdx].m_Slider1.gameObject.SetActive(true);
    ((Behaviour) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time).enabled = true;
    this.m_ItemObj[panelObjectIdx].m_Slider2.gameObject.SetActive(false);
    this.m_ItemObj[panelObjectIdx].m_Slider3.gameObject.SetActive(false);
    this.m_ItemObj[panelObjectIdx].m_SliderType = (byte) 1;
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.DM.mStringTable.GetStringByID(546U);
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title).rectTransform.anchoredPosition = new Vector2(-104.13f, 0.0f);
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.alignment = TextAnchor.MiddleRight;
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title).rectTransform.sizeDelta = new Vector2(142.15f, 29f);
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time).rectTransform.anchoredPosition = new Vector2(80.6f, 0.5f);
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.alignment = TextAnchor.MiddleLeft;
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time).rectTransform.sizeDelta = new Vector2(129.3f, 29f);
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value.sprite = this.m_SpArray.GetSprite(0);
  }

  public void CalculateSlider_HideArmy(int panelObjectIdx)
  {
    TimeEventDataType shelterTime = HideArmyManager.Instance.GetShelterTime();
    long beginTime = shelterTime.BeginTime;
    uint requireTime = shelterTime.RequireTime;
    if (requireTime == 0U)
      return;
    float num = Mathf.Clamp(((float) NetworkManager.ServerTime - (float) beginTime) / (float) requireTime, 0.0f, 1f);
    long time = (long) Mathf.Clamp((float) ((long) requireTime - (this.DM.ServerTime - beginTime)), 0.0f, (float) requireTime);
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value).rectTransform.sizeDelta = new Vector2(338f * num, 17f);
    this.SetTimeText(this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr, time);
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.text = this.m_ItemObj[panelObjectIdx].m_Slider1TimeStr.ToString();
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.SetAllDirty();
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time.cachedTextGenerator.Invalidate();
    if (!((Component) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time).gameObject.activeSelf)
      ((Component) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time).gameObject.SetActive(true);
    this.m_ItemObj[panelObjectIdx].m_Slider1.gameObject.SetActive(true);
    ((Behaviour) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Time).enabled = true;
    this.m_ItemObj[panelObjectIdx].m_Slider2.gameObject.SetActive(false);
    this.m_ItemObj[panelObjectIdx].m_Slider3.gameObject.SetActive(false);
    this.m_ItemObj[panelObjectIdx].m_SliderType = (byte) 2;
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.text = this.DM.mStringTable.GetStringByID(8591U);
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title).rectTransform.anchoredPosition = new Vector2(-104.13f, 0.0f);
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title.alignment = TextAnchor.MiddleRight;
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Title).rectTransform.sizeDelta = new Vector2(142.15f, 29f);
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time).rectTransform.anchoredPosition = new Vector2(80.6f, 0.5f);
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time.alignment = TextAnchor.MiddleLeft;
    ((Graphic) this.m_ItemObj[panelObjectIdx].m_ScrollSlider3Time).rectTransform.sizeDelta = new Vector2(129.3f, 29f);
    this.m_ItemObj[panelObjectIdx].m_ScrollSlider1Value.sprite = this.m_SpArray.GetSprite(1);
  }

  public void SetTimeText(CString str, long time)
  {
    int x1 = (int) time % 60;
    int x2 = (int) (time / 60L) % 60;
    int x3 = (int) (time % 86400L) / 3600;
    int x4 = (int) time / 86400;
    if (x4 > 0)
    {
      StringManager.Instance.IntToFormat((long) x4);
      StringManager.Instance.IntToFormat((long) x3, 2);
      StringManager.Instance.IntToFormat((long) x2, 2);
      StringManager.Instance.IntToFormat((long) x1, 2);
      str.ClearString();
      str.AppendFormat("{0}:{1}:{2}:{3}");
    }
    else if (x3 > 0)
    {
      StringManager.Instance.IntToFormat((long) x3);
      StringManager.Instance.IntToFormat((long) x2, 2);
      StringManager.Instance.IntToFormat((long) x1, 2);
      str.ClearString();
      str.AppendFormat("{0}:{1}:{2}");
    }
    else
    {
      StringManager.Instance.IntToFormat((long) x2, 2);
      StringManager.Instance.IntToFormat((long) x1, 2);
      str.ClearString();
      str.AppendFormat("{0}:{1}");
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    if ((bool) (Object) this.door && sender.m_BtnID1 >= 0 && sender.m_BtnID1 <= 7)
    {
      if (sender.m_BtnID2 == 6)
      {
        if (this.UIType == eArmyUIType.eHideArmyMod)
          this.door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 6);
        else if (sender.m_BtnID1 < this.m_Data.Count && sender.m_BtnID1 >= 0)
          this.door.OpenMenu(EGUIWindow.UI_DevelopmentDetails, 1, this.m_Data[sender.m_BtnID1].m_Index);
      }
      if (sender.m_BtnID2 == 7)
      {
        if (sender.m_BtnID1 < this.m_Data.Count && sender.m_BtnID1 >= 0)
        {
          if (this.m_Data[sender.m_BtnID1].m_DataType == eArmyDataType.LordReturn)
            this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, 30);
          else
            this.door.OpenMenu(EGUIWindow.UI_BagFilter, 2, this.m_Data[sender.m_BtnID1].m_Index + 2);
        }
      }
      if (sender.m_BtnID2 == 8 && sender.m_BtnID1 < this.m_Data.Count)
      {
        if (this.m_Data[sender.m_BtnID1].m_DataType == eArmyDataType.LordReturn)
          this.door.GoToGroup(8, (byte) 0);
        else
          this.door.GoToGroup(this.m_Data[sender.m_BtnID1].m_Index, (byte) 0);
      }
      if (sender.m_BtnID2 == 9)
      {
        if (this.UIType == eArmyUIType.eHideArmyMod)
          HideArmyManager.Instance.SendReleaseShelterTroop();
        else if (this.UIType == eArmyUIType.eTroopArmyMod)
        {
          int index = this.m_Data[sender.m_BtnID1].m_Index;
          if ((this.DM.MarchEventData[index].bRallyHost == (byte) 1 || this.DM.MarchEventData[index].bRallyHost == (byte) 4) && (this.DM.MarchEventData[index].Type == EMarchEventType.EMET_RallyStanby || this.DM.MarchEventData[index].Type == EMarchEventType.EMET_RallyMarching || this.DM.MarchEventData[index].Type == EMarchEventType.EMET_RallyAttack))
            GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4975U), this.DM.mStringTable.GetStringByID(4976U), YesText: this.DM.mStringTable.GetStringByID(4977U), NoText: this.DM.mStringTable.GetStringByID(4978U));
          else if (this.DM.MarchEventData[index].Type >= EMarchEventType.EMET_Standby && this.DM.MarchEventData[index].Type <= EMarchEventType.EMET_RallyStanby)
          {
            int mapId = GameConstants.PointCodeToMapID(this.DM.MarchEventData[index].Point.zoneID, this.DM.MarchEventData[index].Point.pointID);
            if (this.DM.MarchEventData[index].Type == EMarchEventType.EMET_InforceStanby)
              GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(4844U), this.DM.mStringTable.GetStringByID(4845U), 1, mapId, this.DM.mStringTable.GetStringByID(4846U), this.DM.mStringTable.GetStringByID(4847U));
            else if (this.DM.MarchEventData[index].PointKind == POINT_KIND.PK_YOLK && this.DM.MarchEventData[index].Type == EMarchEventType.EMET_Camp)
            {
              this.m_CheckMsgStr.ClearString();
              StringManager.Instance.StaticString1024();
              this.m_CheckMsgStr.StringToFormat(DataManager.MapDataController.GetYolkName((ushort) this.DM.MarchEventData[index].DesPointLevel, DataManager.MapDataController.FocusKingdomID));
              this.m_CheckMsgStr.AppendFormat(DataManager.Instance.mStringTable.GetStringByID(8572U));
              GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(8571U), this.m_CheckMsgStr.ToString(), 2, mapId, this.DM.mStringTable.GetStringByID(4846U), this.DM.mStringTable.GetStringByID(4847U));
            }
            else if (this.DM.MarchEventData[index].IsAmbushCamp())
              GUIManager.Instance.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(9736U), this.DM.mStringTable.GetStringByID(9737U), 3, index, this.DM.mStringTable.GetStringByID(4842U), this.DM.mStringTable.GetStringByID(4843U));
            else
              DataManager.Instance.TroopeTakeBack(mapId, this.DM.MarchEventData[index].Type);
          }
          else if (this.DM.MarchEventData[index].Type >= EMarchEventType.EMET_AttackMarching && this.DM.MarchEventData[index].Type <= EMarchEventType.EMET_DeliverMarching)
            DataManager.Instance.TroopeTakeBack((byte) index);
        }
      }
      if (sender.m_BtnID2 != 10)
        ;
    }
    else
    {
      if (sender.m_BtnID1 != 100)
        return;
      this.door.CloseMenu();
    }
  }

  private void SetData()
  {
    this.m_Data.Clear();
    if (this.UIType == eArmyUIType.eTroopArmyMod)
    {
      sArmyData sArmyData;
      if (this.DM.beCaptured.nowCaptureStat == LoadCaptureState.Returning)
      {
        sArmyData = new sArmyData();
        sArmyData.m_DataType = eArmyDataType.LordReturn;
        this.m_Data.Add(sArmyData);
      }
      for (int index = 0; index < 8; ++index)
      {
        if (this.DM.MarchEventData[index].Type != EMarchEventType.EMET_Standby)
        {
          sArmyData = new sArmyData();
          sArmyData.m_DataType = eArmyDataType.MarchEvent;
          sArmyData.m_Index = index;
          this.m_Data.Add(sArmyData);
        }
      }
    }
    else
      this.m_Data.Add(new sArmyData()
      {
        m_DataType = eArmyDataType.HideArmy
      });
  }

  private uint GetMaxOverload(int _MapPointID, float _rate)
  {
    GameConstants.getTileMapPosbySpriteID(_MapPointID);
    uint maxOverload = 0;
    for (int index = 0; index < (int) DataManager.Instance.MaxMarchEventNum; ++index)
    {
      if (DataManager.Instance.MarchEventData[index].Type == EMarchEventType.EMET_Gathering && GameConstants.PointCodeToMapID(DataManager.Instance.MarchEventData[index].Point.zoneID, DataManager.Instance.MarchEventData[index].Point.pointID) == _MapPointID)
      {
        maxOverload = (uint) ((double) DataManager.Instance.MarchEventTime[index].RequireTime * (double) _rate);
        break;
      }
    }
    return maxOverload;
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    this.Refresh_FontTexture();
  }

  public void Refresh_FontTexture()
  {
    for (int index = 0; index < 12; ++index)
    {
      if ((Object) this.m_tmptext[index] != (Object) null && ((Behaviour) this.m_tmptext[index]).enabled)
      {
        ((Behaviour) this.m_tmptext[index]).enabled = false;
        ((Behaviour) this.m_tmptext[index]).enabled = true;
      }
    }
    for (int index = 0; index < 5; ++index)
    {
      if (this.m_ItemObj[index] != null)
      {
        if ((Object) this.m_ItemObj[index].m_ScrollSliderText1 != (Object) null && ((Behaviour) this.m_ItemObj[index].m_ScrollSliderText1).enabled)
        {
          ((Behaviour) this.m_ItemObj[index].m_ScrollSliderText1).enabled = false;
          ((Behaviour) this.m_ItemObj[index].m_ScrollSliderText1).enabled = true;
        }
        if ((Object) this.m_ItemObj[index].m_ScrollSliderText2 != (Object) null && ((Behaviour) this.m_ItemObj[index].m_ScrollSliderText2).enabled)
        {
          ((Behaviour) this.m_ItemObj[index].m_ScrollSliderText2).enabled = false;
          ((Behaviour) this.m_ItemObj[index].m_ScrollSliderText2).enabled = true;
        }
        if ((Object) this.m_ItemObj[index].m_ScrollSlider1Title != (Object) null && ((Behaviour) this.m_ItemObj[index].m_ScrollSlider1Title).enabled)
        {
          ((Behaviour) this.m_ItemObj[index].m_ScrollSlider1Title).enabled = false;
          ((Behaviour) this.m_ItemObj[index].m_ScrollSlider1Title).enabled = true;
        }
        if ((Object) this.m_ItemObj[index].m_ScrollSlider1Time != (Object) null && ((Behaviour) this.m_ItemObj[index].m_ScrollSlider1Time).enabled)
        {
          ((Behaviour) this.m_ItemObj[index].m_ScrollSlider1Time).enabled = false;
          ((Behaviour) this.m_ItemObj[index].m_ScrollSlider1Time).enabled = true;
        }
        if ((Object) this.m_ItemObj[index].m_ScrollSlider2Title != (Object) null && ((Behaviour) this.m_ItemObj[index].m_ScrollSlider2Title).enabled)
        {
          ((Behaviour) this.m_ItemObj[index].m_ScrollSlider2Title).enabled = false;
          ((Behaviour) this.m_ItemObj[index].m_ScrollSlider2Title).enabled = true;
        }
        if ((Object) this.m_ItemObj[index].m_ScrollSlider2Time != (Object) null && ((Behaviour) this.m_ItemObj[index].m_ScrollSlider2Time).enabled)
        {
          ((Behaviour) this.m_ItemObj[index].m_ScrollSlider2Time).enabled = false;
          ((Behaviour) this.m_ItemObj[index].m_ScrollSlider2Time).enabled = true;
        }
        if ((Object) this.m_ItemObj[index].m_ScrollSlider3Title != (Object) null && ((Behaviour) this.m_ItemObj[index].m_ScrollSlider3Title).enabled)
        {
          ((Behaviour) this.m_ItemObj[index].m_ScrollSlider3Title).enabled = false;
          ((Behaviour) this.m_ItemObj[index].m_ScrollSlider3Title).enabled = true;
        }
        if ((Object) this.m_ItemObj[index].m_ScrollSlider3Time != (Object) null && ((Behaviour) this.m_ItemObj[index].m_ScrollSlider3Time).enabled)
        {
          ((Behaviour) this.m_ItemObj[index].m_ScrollSlider3Time).enabled = false;
          ((Behaviour) this.m_ItemObj[index].m_ScrollSlider3Time).enabled = true;
        }
        if ((Object) this.m_ItemObj[index].m_ScrollIconText != (Object) null && ((Behaviour) this.m_ItemObj[index].m_ScrollIconText).enabled)
        {
          ((Behaviour) this.m_ItemObj[index].m_ScrollIconText).enabled = false;
          ((Behaviour) this.m_ItemObj[index].m_ScrollIconText).enabled = true;
        }
      }
    }
  }
}
