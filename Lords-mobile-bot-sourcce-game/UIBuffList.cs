// Decompiled with JetBrains decompiler
// Type: UIBuffList
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIBuffList : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int MaxScrollCount = 7;
  private const int MaxTitleType = 3;
  private const int WorldTitleIdx = 9999;
  private const float TitleItemH = 140f;
  private const float TitleItemH2 = 176f;
  private const int TextMax = 2;
  private DataManager DM;
  private GUIManager GM;
  private Font TTF;
  private Door m_door;
  private ScrollPanel m_ScrollPanel;
  private RectTransform m_ScrollContentRT;
  private BuffItemObj[] m_BuffItem;
  private UISpritesArray m_SpriteArray;
  private UIText m_CDText;
  private CString m_CDCStr;
  private byte[] m_TitleType;
  private float ColorA;
  private float ColorTime;
  private float FlashTime = 1.6f;
  private Color GoogEffColor = new Color(0.2078f, 0.9686f, 0.4235f);
  private Color BadEffColor = new Color(1f, 0.3294f, 0.4157f);
  public List<ushort> m_Data;
  private eBuffListUIType m_UIType;
  private int mTextCount;
  private UIText[] m_tmptext = new UIText[2];

  public override void OnOpen(int arg1, int arg2)
  {
    this.m_UIType = (eBuffListUIType) arg1;
    this.DM = DataManager.Instance;
    this.GM = GUIManager.Instance;
    this.TTF = this.GM.GetTTFFont();
    this.m_door = this.GM.FindMenu(EGUIWindow.Door) as Door;
    this.m_BuffItem = new BuffItemObj[7];
    for (int index = 0; index < 7; ++index)
      this.m_BuffItem[index].Item = new ItemObj[3];
    for (int index1 = 0; index1 < 7; ++index1)
    {
      for (int index2 = 0; index2 < 3; ++index2)
      {
        if (this.m_BuffItem[index1].Item[index2].TimeStr == null)
          this.m_BuffItem[index1].Item[index2].TimeStr = StringManager.Instance.SpawnString();
        if (this.m_BuffItem[index1].Item[index2].InfoStr1 == null)
          this.m_BuffItem[index1].Item[index2].InfoStr1 = StringManager.Instance.SpawnString();
        if (this.m_BuffItem[index1].Item[index2].InfoStr2 == null)
          this.m_BuffItem[index1].Item[index2].InfoStr2 = StringManager.Instance.SpawnString();
        if (this.m_BuffItem[index1].Item[index2].InfoStr3 == null)
          this.m_BuffItem[index1].Item[index2].InfoStr3 = StringManager.Instance.SpawnString();
      }
    }
    this.m_CDCStr = StringManager.Instance.SpawnString();
    this.m_TitleType = new byte[this.DM.MaxBuffTableCount];
    Array.Clear((Array) this.m_TitleType, 0, this.DM.MaxBuffTableCount);
    this.m_Data = new List<ushort>();
    this.SetTitleType();
    this.m_SpriteArray = this.transform.GetComponent<UISpritesArray>();
    this.m_tmptext[this.mTextCount] = this.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    if (this.m_UIType == eBuffListUIType.BuffList)
      this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(6093U);
    else if (this.m_UIType == eBuffListUIType.AttackBuffList)
      this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(8202U);
    else if (this.m_UIType == eBuffListUIType.DefendBuffList)
      this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(8204U);
    else if (this.m_UIType == eBuffListUIType.KingdomBuff)
      this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(1453U);
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = this.transform.GetChild(0).GetChild(3).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    if (this.m_UIType == eBuffListUIType.BuffList)
      this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(6098U);
    else if (this.m_UIType == eBuffListUIType.AttackBuffList)
      this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(8203U);
    else if (this.m_UIType == eBuffListUIType.DefendBuffList)
      this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(8205U);
    else if (this.m_UIType == eBuffListUIType.KingdomBuff)
      this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(1454U);
    ++this.mTextCount;
    Image component1 = this.transform.GetChild(3).GetComponent<Image>();
    component1.sprite = this.m_door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component1).material = this.m_door.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (UnityEngine.Object) component1)
      ((Behaviour) component1).enabled = false;
    UIButton component2 = this.transform.GetChild(3).GetChild(0).GetComponent<UIButton>();
    component2.image.sprite = this.m_door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component2.image).material = this.m_door.LoadMaterial();
    component2.m_BtnID1 = 999;
    component2.m_Handler = (IUIButtonClickHandler) this;
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform component3 = this.transform.GetChild(2).GetChild(0).GetChild(2).GetComponent<RectTransform>();
      Vector2 anchoredPosition = component3.anchoredPosition with
      {
        x = 93f
      };
      component3.anchoredPosition = anchoredPosition;
      Vector3 localScale1 = ((Transform) component3).localScale with
      {
        x = -1f
      };
      ((Transform) component3).localScale = localScale1;
      RectTransform component4 = this.transform.GetChild(2).GetChild(1).GetChild(2).GetComponent<RectTransform>();
      anchoredPosition = component4.anchoredPosition with
      {
        x = 93f
      };
      component4.anchoredPosition = anchoredPosition;
      Vector3 localScale2 = ((Transform) component4).localScale with
      {
        x = -1f
      };
      ((Transform) component4).localScale = localScale2;
    }
    this.m_ScrollPanel = this.transform.GetChild(1).GetComponent<ScrollPanel>();
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_Data.Count; ++index)
    {
      if (this.m_Data[index] == (ushort) 9999)
        _DataHeight.Add(this.GetTitleItemH());
      else if (this.m_TitleType[(int) this.m_Data[index]] > (byte) 0)
        _DataHeight.Add(113f);
      else
        _DataHeight.Add(78f);
    }
    this.m_ScrollPanel.IntiScrollPanel(470f, 0.0f, 0.0f, _DataHeight, 7, (IUpDateScrollPanel) this);
    this.m_ScrollContentRT = this.m_ScrollPanel.transform.GetChild(0).GetComponent<RectTransform>();
    if (this.DM.m_BuffScrollIndex != 0 && (double) this.DM.m_BuffScrollPos > 0.0 && !NewbieManager.IsTeachWorking(ETeachKind.DESHIELD))
      this.m_ScrollPanel.GoTo(this.DM.m_BuffScrollIndex, this.DM.m_BuffScrollPos);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    for (int index1 = 0; index1 < 7; ++index1)
    {
      for (int index2 = 0; index2 < 3; ++index2)
      {
        if (this.m_BuffItem[index1].Item[index2].TimeStr != null)
          StringManager.Instance.DeSpawnString(this.m_BuffItem[index1].Item[index2].TimeStr);
        if (this.m_BuffItem[index1].Item[index2].InfoStr1 != null)
          StringManager.Instance.DeSpawnString(this.m_BuffItem[index1].Item[index2].InfoStr1);
        if (this.m_BuffItem[index1].Item[index2].InfoStr2 != null)
          StringManager.Instance.DeSpawnString(this.m_BuffItem[index1].Item[index2].InfoStr2);
        if (this.m_BuffItem[index1].Item[index2].InfoStr3 != null)
          StringManager.Instance.DeSpawnString(this.m_BuffItem[index1].Item[index2].InfoStr3);
      }
    }
    StringManager.Instance.DeSpawnString(this.m_CDCStr);
    this.DM.m_BuffScrollIndex = this.m_ScrollPanel.GetTopIdx();
    this.DM.m_BuffScrollPos = this.m_ScrollContentRT.anchoredPosition.y;
  }

  public override void UpdateUI(int arg1, int arg2)
  {
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        if (NewbieManager.IsTeachWorking(ETeachKind.DESHIELD))
          break;
        this.SetTitleType();
        List<float> _DataHeight = new List<float>();
        for (int index = 0; index < this.m_Data.Count; ++index)
        {
          if (this.m_Data[index] == (ushort) 9999)
            _DataHeight.Add(this.GetTitleItemH());
          else if (this.m_TitleType[(int) this.m_Data[index]] > (byte) 0)
            _DataHeight.Add(113f);
          else
            _DataHeight.Add(78f);
        }
        this.m_ScrollPanel.AddNewDataHeight(_DataHeight, false);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_Item && networkNews != NetworkNews.Refresh_BuffList)
        {
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.Refresh_FontTexture();
          break;
        }
        goto case NetworkNews.Login;
    }
  }

  public void Refresh_FontTexture()
  {
    for (int index = 0; index < 2; ++index)
    {
      if ((UnityEngine.Object) this.m_tmptext[index] != (UnityEngine.Object) null && ((Behaviour) this.m_tmptext[index]).enabled)
      {
        ((Behaviour) this.m_tmptext[index]).enabled = false;
        ((Behaviour) this.m_tmptext[index]).enabled = true;
      }
    }
    for (int index1 = 0; index1 < 7; ++index1)
    {
      if (this.m_BuffItem[index1].Item != null)
      {
        for (int index2 = 0; index2 < 2; ++index2)
        {
          if ((UnityEngine.Object) this.m_BuffItem[index1].Item[index2].Title != (UnityEngine.Object) null && ((Behaviour) this.m_BuffItem[index1].Item[index2].Title).enabled)
          {
            ((Behaviour) this.m_BuffItem[index1].Item[index2].Title).enabled = false;
            ((Behaviour) this.m_BuffItem[index1].Item[index2].Title).enabled = true;
          }
          if ((UnityEngine.Object) this.m_BuffItem[index1].Item[index2].Title2 != (UnityEngine.Object) null && ((Behaviour) this.m_BuffItem[index1].Item[index2].Title2).enabled)
          {
            ((Behaviour) this.m_BuffItem[index1].Item[index2].Title2).enabled = false;
            ((Behaviour) this.m_BuffItem[index1].Item[index2].Title2).enabled = true;
          }
          if ((UnityEngine.Object) this.m_BuffItem[index1].Item[index2].ItemName != (UnityEngine.Object) null && ((Behaviour) this.m_BuffItem[index1].Item[index2].ItemName).enabled)
          {
            ((Behaviour) this.m_BuffItem[index1].Item[index2].ItemName).enabled = false;
            ((Behaviour) this.m_BuffItem[index1].Item[index2].ItemName).enabled = true;
          }
          if ((UnityEngine.Object) this.m_BuffItem[index1].Item[index2].ItemInFo != (UnityEngine.Object) null && ((Behaviour) this.m_BuffItem[index1].Item[index2].ItemInFo).enabled)
          {
            ((Behaviour) this.m_BuffItem[index1].Item[index2].ItemInFo).enabled = false;
            ((Behaviour) this.m_BuffItem[index1].Item[index2].ItemInFo).enabled = true;
          }
          if ((UnityEngine.Object) this.m_BuffItem[index1].Item[index2].ItemInFo2 != (UnityEngine.Object) null && ((Behaviour) this.m_BuffItem[index1].Item[index2].ItemInFo2).enabled)
          {
            ((Behaviour) this.m_BuffItem[index1].Item[index2].ItemInFo2).enabled = false;
            ((Behaviour) this.m_BuffItem[index1].Item[index2].ItemInFo2).enabled = true;
          }
          if ((UnityEngine.Object) this.m_BuffItem[index1].Item[index2].ItemInFo3 != (UnityEngine.Object) null && ((Behaviour) this.m_BuffItem[index1].Item[index2].ItemInFo3).enabled)
          {
            ((Behaviour) this.m_BuffItem[index1].Item[index2].ItemInFo3).enabled = false;
            ((Behaviour) this.m_BuffItem[index1].Item[index2].ItemInFo3).enabled = true;
          }
          if ((UnityEngine.Object) this.m_BuffItem[index1].Item[index2].TimeFlash != (UnityEngine.Object) null && ((Behaviour) this.m_BuffItem[index1].Item[index2].TimeFlash).enabled)
          {
            ((Behaviour) this.m_BuffItem[index1].Item[index2].TimeFlash).enabled = false;
            ((Behaviour) this.m_BuffItem[index1].Item[index2].TimeFlash).enabled = true;
          }
          if ((UnityEngine.Object) this.m_BuffItem[index1].Item[index2].TimeSlider != (UnityEngine.Object) null && ((Behaviour) this.m_BuffItem[index1].Item[index2].TimeSlider).enabled)
          {
            ((Behaviour) this.m_BuffItem[index1].Item[index2].TimeSlider).enabled = false;
            ((Behaviour) this.m_BuffItem[index1].Item[index2].TimeSlider).enabled = true;
          }
          if ((UnityEngine.Object) this.m_BuffItem[index1].Item[index2].TimeTitle != (UnityEngine.Object) null && ((Behaviour) this.m_BuffItem[index1].Item[index2].TimeTitle).enabled)
          {
            ((Behaviour) this.m_BuffItem[index1].Item[index2].TimeTitle).enabled = false;
            ((Behaviour) this.m_BuffItem[index1].Item[index2].TimeTitle).enabled = true;
          }
          if ((UnityEngine.Object) this.m_BuffItem[index1].Item[index2].TimeText != (UnityEngine.Object) null && ((Behaviour) this.m_BuffItem[index1].Item[index2].TimeText).enabled)
          {
            ((Behaviour) this.m_BuffItem[index1].Item[index2].TimeText).enabled = false;
            ((Behaviour) this.m_BuffItem[index1].Item[index2].TimeText).enabled = true;
          }
        }
      }
    }
  }

  public void Update()
  {
    this.ColorTime += Time.deltaTime;
    if ((double) this.ColorTime >= (double) this.FlashTime)
      this.ColorTime = 0.0f;
    this.ColorA = this.ATween(this.ColorTime, 0.0f, 2f, this.FlashTime);
    this.UpdateTime();
    this.UpdateSlider();
    this.UpdateSliderAlpha();
    this.UpdateCDTime(DataManager.Instance.KingCoolEndTime);
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (dataIdx < 0 || dataIdx >= this.m_Data.Count)
      return;
    if ((UnityEngine.Object) this.m_BuffItem[panelObjectIdx].Item[0].ItemFrame == (UnityEngine.Object) null)
    {
      this.m_BuffItem[panelObjectIdx].Item[0].gameObject = item.transform.GetChild(0).gameObject;
      this.m_BuffItem[panelObjectIdx].Item[0].ItemBg = item.transform.GetChild(0).GetChild(0).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[0].ItemBgIcon = item.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[0].ItemIconRect = item.transform.GetChild(0).GetChild(2).GetComponent<RectTransform>();
      this.m_BuffItem[panelObjectIdx].Item[0].ItemImage = item.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[0].ItemFrame = item.transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[0].Title = item.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[0].Title.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[0].Title2 = item.transform.GetChild(0).GetChild(1).GetChild(1).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[0].Title2.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[0].CDText = item.transform.GetChild(0).GetChild(1).GetChild(2).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[0].CDText.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[0].CDIcon = item.transform.GetChild(0).GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[0].ItemName = item.transform.GetChild(0).GetChild(3).GetChild(0).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[0].ItemName.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[0].ItemInFo = item.transform.GetChild(0).GetChild(3).GetChild(1).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[0].ItemInFo.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[0].Btn = item.transform.GetChild(0).GetChild(0).GetComponent<UIButton>();
      this.m_BuffItem[panelObjectIdx].Item[0].Btn.m_Handler = (IUIButtonClickHandler) this;
      this.m_BuffItem[panelObjectIdx].Item[0].TimeFlash = item.transform.GetChild(0).GetChild(4).GetChild(0).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[0].TimeSlider = item.transform.GetChild(0).GetChild(4).GetChild(1).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[0].TimeTitle = item.transform.GetChild(0).GetChild(4).GetChild(2).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[0].TimeTitle.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[0].TimeTitle.text = this.DM.mStringTable.GetStringByID(6097U);
      this.m_BuffItem[panelObjectIdx].Item[0].TimeText = item.transform.GetChild(0).GetChild(4).GetChild(3).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[0].TimeText.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[1].gameObject = item.transform.GetChild(1).gameObject;
      this.m_BuffItem[panelObjectIdx].Item[1].ItemBg = item.transform.GetChild(1).GetChild(0).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[1].ItemBgIcon = item.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[1].ItemIconRect = item.transform.GetChild(1).GetChild(2).GetComponent<RectTransform>();
      this.m_BuffItem[panelObjectIdx].Item[1].ItemImage = item.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[1].ItemFrame = item.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[1].Title = item.transform.GetChild(1).GetChild(1).GetChild(0).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[1].Title.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[1].Title2 = this.m_BuffItem[panelObjectIdx].Item[1].Title;
      this.m_BuffItem[panelObjectIdx].Item[1].ItemName = item.transform.GetChild(1).GetChild(3).GetChild(0).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[1].ItemName.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[1].ItemInFo = item.transform.GetChild(1).GetChild(3).GetChild(1).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[1].ItemInFo.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[1].Btn = item.transform.GetChild(1).GetChild(0).GetComponent<UIButton>();
      this.m_BuffItem[panelObjectIdx].Item[1].Btn.m_Handler = (IUIButtonClickHandler) this;
      this.m_BuffItem[panelObjectIdx].Item[1].TimeFlash = item.transform.GetChild(1).GetChild(4).GetChild(0).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[1].TimeSlider = item.transform.GetChild(1).GetChild(4).GetChild(1).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[1].TimeTitle = item.transform.GetChild(1).GetChild(4).GetChild(2).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[1].TimeTitle.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[1].TimeTitle.text = this.DM.mStringTable.GetStringByID(6097U);
      this.m_BuffItem[panelObjectIdx].Item[1].TimeText = item.transform.GetChild(1).GetChild(4).GetChild(3).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[1].TimeText.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[2].gameObject = item.transform.GetChild(2).gameObject;
      this.m_BuffItem[panelObjectIdx].Item[2].ItemBg = item.transform.GetChild(2).GetChild(0).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[2].ItemBgIcon = item.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[2].ItemIconRect = item.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>();
      this.m_BuffItem[panelObjectIdx].Item[2].ItemImage = item.transform.GetChild(2).GetChild(2).GetChild(0).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[2].ItemFrame = item.transform.GetChild(2).GetChild(2).GetChild(1).GetComponent<Image>();
      this.m_BuffItem[panelObjectIdx].Item[2].Title = item.transform.GetChild(2).GetChild(1).GetChild(0).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[2].Title.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[2].Title2 = this.m_BuffItem[panelObjectIdx].Item[1].Title;
      this.m_BuffItem[panelObjectIdx].Item[2].ItemName = item.transform.GetChild(2).GetChild(3).GetChild(0).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[2].ItemName.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo = item.transform.GetChild(2).GetChild(3).GetChild(1).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2 = item.transform.GetChild(2).GetChild(3).GetChild(2).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3 = item.transform.GetChild(2).GetChild(3).GetChild(3).GetComponent<UIText>();
      this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3.font = this.TTF;
      this.m_BuffItem[panelObjectIdx].Item[2].Btn = item.transform.GetChild(2).GetChild(0).GetComponent<UIButton>();
      this.m_BuffItem[panelObjectIdx].Item[2].Btn.m_Handler = (IUIButtonClickHandler) this;
    }
    if (this.m_Data[dataIdx] == (ushort) 9999)
    {
      float titleItemH = this.GetTitleItemH();
      item.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(738f, titleItemH);
      this.m_BuffItem[panelObjectIdx].Item[2].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(738f, titleItemH);
      this.m_BuffItem[panelObjectIdx].Item[0].gameObject.SetActive(false);
      this.m_BuffItem[panelObjectIdx].Item[1].gameObject.SetActive(false);
      this.m_BuffItem[panelObjectIdx].Item[2].gameObject.SetActive(true);
      ((Component) this.m_BuffItem[panelObjectIdx].Item[2].ItemBg).gameObject.SetActive(true);
      ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[2].ItemBgIcon).enabled = false;
      TitleData recordByKey1 = this.DM.TitleDataN.GetRecordByKey(this.DM.RoleAttr.WorldTitle_Country);
      this.m_BuffItem[panelObjectIdx].Item[2].ItemImage.sprite = this.GM.LoadTitleSprite(recordByKey1.IconID, eTitleKind.KingdomTitle);
      ((MaskableGraphic) this.m_BuffItem[panelObjectIdx].Item[2].ItemImage).material = this.GM.GetTitleMaterial();
      ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[2].ItemFrame).enabled = false;
      GameConstants.GetEffectValue(this.m_BuffItem[panelObjectIdx].Item[2].InfoStr1, recordByKey1.Effects[0].EffectID, (uint) recordByKey1.Effects[0].Value, (byte) 11, 0.0f);
      this.m_BuffItem[panelObjectIdx].Item[2].ItemName.text = this.DM.mStringTable.GetStringByID((uint) recordByKey1.StringID);
      this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo.text = this.m_BuffItem[panelObjectIdx].Item[2].InfoStr1.ToString();
      this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo.SetAllDirty();
      this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo.cachedTextGenerator.Invalidate();
      Effect recordByKey2 = DataManager.Instance.EffectData.GetRecordByKey(recordByKey1.Effects[0].EffectID);
      if (recordByKey2.StatusIcon == (ushort) 0)
        ((Graphic) this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo).color = this.GoogEffColor;
      else
        ((Graphic) this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo).color = this.BadEffColor;
      if (recordByKey1.Effects[1].EffectID > (ushort) 0)
      {
        GameConstants.GetEffectValue(this.m_BuffItem[panelObjectIdx].Item[2].InfoStr2, recordByKey1.Effects[1].EffectID, (uint) recordByKey1.Effects[1].Value, (byte) 11, 0.0f);
        this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2.text = this.m_BuffItem[panelObjectIdx].Item[2].InfoStr2.ToString();
        this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2.SetAllDirty();
        this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2.cachedTextGenerator.Invalidate();
        ((Component) this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2).gameObject.SetActive(true);
        recordByKey2 = DataManager.Instance.EffectData.GetRecordByKey(recordByKey1.Effects[1].EffectID);
        if (recordByKey2.StatusIcon == (ushort) 0)
          ((Graphic) this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2).color = this.GoogEffColor;
        else
          ((Graphic) this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2).color = this.BadEffColor;
      }
      else
        ((Component) this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo2).gameObject.SetActive(false);
      if ((double) titleItemH == 176.0)
      {
        ((Component) this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3).gameObject.SetActive(true);
        GameConstants.GetEffectValue(this.m_BuffItem[panelObjectIdx].Item[2].InfoStr3, recordByKey1.Effects[2].EffectID, (uint) recordByKey1.Effects[2].Value, (byte) 11, 0.0f);
        this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3.text = this.m_BuffItem[panelObjectIdx].Item[2].InfoStr3.ToString();
        this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3.SetAllDirty();
        this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3.cachedTextGenerator.Invalidate();
        item.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector2(35.7f, -75.5f);
        recordByKey2 = DataManager.Instance.EffectData.GetRecordByKey(recordByKey1.Effects[2].EffectID);
        if (recordByKey2.StatusIcon == (ushort) 0)
          ((Graphic) this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3).color = this.GoogEffColor;
        else
          ((Graphic) this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3).color = this.BadEffColor;
      }
      else
      {
        item.transform.GetChild(2).GetChild(2).GetComponent<RectTransform>().anchoredPosition = new Vector2(35.7f, -57.5f);
        ((Component) this.m_BuffItem[panelObjectIdx].Item[2].ItemInFo3).gameObject.SetActive(false);
      }
      this.m_BuffItem[panelObjectIdx].Item[2].Title.text = this.DM.mStringTable.GetStringByID(11027U);
      ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[2].Title2).enabled = false;
      Vector2 sizeDelta = ((Graphic) this.m_BuffItem[panelObjectIdx].Item[0].ItemBg).rectTransform.sizeDelta with
      {
        y = titleItemH - 35f
      };
      ((Graphic) this.m_BuffItem[panelObjectIdx].Item[2].ItemBg).rectTransform.sizeDelta = sizeDelta;
      ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[2].Btn).enabled = false;
      if (recordByKey1.isDebuff == (byte) 1)
        this.m_BuffItem[panelObjectIdx].Item[2].ItemBg.sprite = this.m_SpriteArray.GetSprite(2);
      else
        this.m_BuffItem[panelObjectIdx].Item[2].ItemBg.sprite = this.m_SpriteArray.GetSprite(3);
    }
    else
    {
      if (dataIdx >= this.m_Data.Count || (int) this.m_Data[dataIdx] >= this.DM.MaxBuffTableCount)
        return;
      int Index = (int) this.DM.m_SortBuffData[(int) this.m_Data[dataIdx]];
      ItemBuff recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(Index);
      byte buffKind = recordByIndex.BuffKind;
      if (this.m_TitleType[(int) this.m_Data[dataIdx]] > (byte) 0)
      {
        item.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(738f, 113f);
        this.m_BuffItem[panelObjectIdx].Item[0].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(738f, 113f);
        this.m_BuffItem[panelObjectIdx].Item[0].gameObject.SetActive(true);
        this.m_BuffItem[panelObjectIdx].Item[1].gameObject.SetActive(false);
        this.m_BuffItem[panelObjectIdx].Item[2].gameObject.SetActive(false);
        if (buffKind == (byte) 1)
        {
          this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(6094U);
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].Title2).enabled = false;
        }
        if (buffKind == (byte) 2)
        {
          this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(6095U);
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].Title2).enabled = false;
        }
        if (buffKind == (byte) 3)
        {
          this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(6096U);
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].Title2).enabled = true;
        }
        if (buffKind == (byte) 4)
        {
          this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(7646U);
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].Title2).enabled = false;
        }
        if (buffKind == (byte) 5)
        {
          this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(1455U);
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].Title2).enabled = false;
        }
        if (buffKind == (byte) 6)
        {
          this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(977U);
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].Title2).enabled = false;
        }
        if (buffKind == (byte) 7)
        {
          this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(9934U);
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].Title2).enabled = false;
        }
        if (buffKind == (byte) 8)
        {
          this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(11014U);
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].Title2).enabled = false;
        }
        if (buffKind == (byte) 9)
        {
          this.m_BuffItem[panelObjectIdx].Item[0].Title.text = this.DM.mStringTable.GetStringByID(11095U);
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].Title2).enabled = false;
        }
        this.m_BuffItem[panelObjectIdx].Item[0].Title2.text = this.DM.mStringTable.GetStringByID(6099U);
        this.m_BuffItem[panelObjectIdx].Item[0].ItemName.text = !this.DM.bHaveWarBuff || recordByIndex.BuffKind != (byte) 1 ? this.DM.mStringTable.GetStringByID((uint) recordByIndex.BuffNameID) : this.DM.mStringTable.GetStringByID(9937U);
        this.m_BuffItem[panelObjectIdx].Item[0].ItemInFo.text = this.DM.mStringTable.GetStringByID((uint) recordByIndex.BuffInfoID);
        this.m_BuffItem[panelObjectIdx].Item[0].ItemImage.sprite = this.GM.m_ItemIconSpriteAsset.LoadSprite(recordByIndex.IconID);
        ((MaskableGraphic) this.m_BuffItem[panelObjectIdx].Item[0].ItemImage).material = this.GM.m_ItemIconSpriteAsset.GetMaterial();
        this.m_BuffItem[panelObjectIdx].Item[0].ItemFrame.sprite = this.GM.LoadFrameSprite("if003");
        ((MaskableGraphic) this.m_BuffItem[panelObjectIdx].Item[0].ItemFrame).material = this.GM.GetFrameMaterial();
        this.m_BuffItem[panelObjectIdx].Item[0].Btn.m_BtnID1 = Index;
        this.m_BuffItem[panelObjectIdx].Item[0].TableIdx = Index;
        ((Graphic) this.m_BuffItem[panelObjectIdx].Item[0].ItemName).color = new Color(1f, 0.93f, 0.62f, (float) byte.MaxValue);
        if (this.DM.m_RecvItemBuffData[Index].bEnable)
        {
          item.transform.GetChild(0).GetChild(4).gameObject.SetActive(true);
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].ItemInFo).enabled = false;
          Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.m_RecvItemBuffData[Index].ItemID);
          ((Graphic) this.m_BuffItem[panelObjectIdx].Item[0].ItemName).color = new Color(0.0f, 1f, 0.19f, (float) byte.MaxValue);
          this.m_BuffItem[panelObjectIdx].Item[0].ItemName.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipName);
          this.m_BuffItem[panelObjectIdx].Item[0].ItemName.SetAllDirty();
          this.m_BuffItem[panelObjectIdx].Item[0].ItemName.cachedTextGenerator.Invalidate();
        }
        else
        {
          item.transform.GetChild(0).GetChild(4).gameObject.SetActive(false);
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].ItemInFo).enabled = true;
        }
        ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].Btn).enabled = true;
        ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].ItemBgIcon).enabled = true;
        if (buffKind == (byte) 5 || buffKind == (byte) 6 || buffKind == (byte) 8 || buffKind == (byte) 9)
        {
          this.m_BuffItem[panelObjectIdx].Item[0].ItemBg.sprite = this.m_SpriteArray.GetSprite(1);
          this.m_CDText = this.m_BuffItem[panelObjectIdx].Item[0].CDText;
          Vector2 sizeDelta = ((Graphic) this.m_BuffItem[panelObjectIdx].Item[0].ItemBg).rectTransform.sizeDelta with
          {
            x = 778f
          };
          ((Graphic) this.m_BuffItem[panelObjectIdx].Item[0].ItemBg).rectTransform.sizeDelta = sizeDelta;
          Vector2 anchoredPosition = ((Graphic) this.m_BuffItem[panelObjectIdx].Item[0].ItemBg).rectTransform.anchoredPosition with
          {
            x = 0.0f
          };
          ((Graphic) this.m_BuffItem[panelObjectIdx].Item[0].ItemBg).rectTransform.anchoredPosition = anchoredPosition;
          if (this.m_UIType != eBuffListUIType.BuffList)
            return;
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].Btn).enabled = false;
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[0].ItemBgIcon).enabled = false;
        }
        else
        {
          this.m_BuffItem[panelObjectIdx].Item[0].ItemBg.sprite = this.m_SpriteArray.GetSprite(0);
          Vector2 sizeDelta = ((Graphic) this.m_BuffItem[panelObjectIdx].Item[0].ItemBg).rectTransform.sizeDelta with
          {
            x = 776f
          };
          ((Graphic) this.m_BuffItem[panelObjectIdx].Item[0].ItemBg).rectTransform.sizeDelta = sizeDelta;
          Vector2 anchoredPosition = ((Graphic) this.m_BuffItem[panelObjectIdx].Item[0].ItemBg).rectTransform.anchoredPosition with
          {
            x = 2f
          };
          ((Graphic) this.m_BuffItem[panelObjectIdx].Item[0].ItemBg).rectTransform.anchoredPosition = anchoredPosition;
        }
      }
      else
      {
        item.gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(738f, 78f);
        this.m_BuffItem[panelObjectIdx].Item[1].gameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(738f, 78f);
        this.m_BuffItem[panelObjectIdx].Item[0].gameObject.SetActive(false);
        this.m_BuffItem[panelObjectIdx].Item[1].gameObject.SetActive(true);
        this.m_BuffItem[panelObjectIdx].Item[2].gameObject.SetActive(false);
        this.m_BuffItem[panelObjectIdx].Item[1].ItemName.text = this.DM.mStringTable.GetStringByID((uint) recordByIndex.BuffNameID);
        this.m_BuffItem[panelObjectIdx].Item[1].ItemInFo.text = this.DM.mStringTable.GetStringByID((uint) recordByIndex.BuffInfoID);
        this.m_BuffItem[panelObjectIdx].Item[1].ItemImage.sprite = this.GM.m_ItemIconSpriteAsset.LoadSprite(recordByIndex.IconID);
        ((MaskableGraphic) this.m_BuffItem[panelObjectIdx].Item[1].ItemImage).material = this.GM.m_ItemIconSpriteAsset.GetMaterial();
        this.m_BuffItem[panelObjectIdx].Item[1].ItemFrame.sprite = this.GM.LoadFrameSprite("if003");
        ((MaskableGraphic) this.m_BuffItem[panelObjectIdx].Item[1].ItemFrame).material = this.GM.GetFrameMaterial();
        this.m_BuffItem[panelObjectIdx].Item[1].Btn.m_BtnID1 = Index;
        this.m_BuffItem[panelObjectIdx].Item[1].TableIdx = Index;
        ((Graphic) this.m_BuffItem[panelObjectIdx].Item[1].ItemName).color = new Color(1f, 0.93f, 0.62f, (float) byte.MaxValue);
        if (this.DM.m_RecvItemBuffData[Index].bEnable)
        {
          item.transform.GetChild(1).GetChild(4).gameObject.SetActive(true);
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[1].ItemInFo).enabled = false;
          Equip recordByKey = this.DM.EquipTable.GetRecordByKey(this.DM.m_RecvItemBuffData[Index].ItemID);
          ((Graphic) this.m_BuffItem[panelObjectIdx].Item[1].ItemName).color = new Color(0.0f, 1f, 0.19f, (float) byte.MaxValue);
          this.m_BuffItem[panelObjectIdx].Item[1].ItemName.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.EquipName);
          this.m_BuffItem[panelObjectIdx].Item[1].ItemName.SetAllDirty();
          this.m_BuffItem[panelObjectIdx].Item[1].ItemName.cachedTextGenerator.Invalidate();
        }
        else
        {
          item.transform.GetChild(1).GetChild(4).gameObject.SetActive(false);
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[1].ItemInFo).enabled = true;
        }
        this.m_BuffItem[panelObjectIdx].Item[1].Btn.interactable = true;
        ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[1].ItemBgIcon).enabled = true;
        if (buffKind == (byte) 5 || buffKind == (byte) 6)
        {
          this.m_BuffItem[panelObjectIdx].Item[1].ItemBg.sprite = this.m_SpriteArray.GetSprite(1);
          Vector2 sizeDelta = ((Graphic) this.m_BuffItem[panelObjectIdx].Item[1].ItemBg).rectTransform.sizeDelta with
          {
            x = 778f
          };
          ((Graphic) this.m_BuffItem[panelObjectIdx].Item[1].ItemBg).rectTransform.sizeDelta = sizeDelta;
          Vector2 anchoredPosition = ((Graphic) this.m_BuffItem[panelObjectIdx].Item[1].ItemBg).rectTransform.anchoredPosition with
          {
            x = 0.0f
          };
          ((Graphic) this.m_BuffItem[panelObjectIdx].Item[1].ItemBg).rectTransform.anchoredPosition = anchoredPosition;
          if (this.m_UIType != eBuffListUIType.BuffList)
            return;
          this.m_BuffItem[panelObjectIdx].Item[1].Btn.interactable = false;
          ((Behaviour) this.m_BuffItem[panelObjectIdx].Item[1].ItemBgIcon).enabled = false;
        }
        else
        {
          Vector2 vector2 = ((Graphic) this.m_BuffItem[panelObjectIdx].Item[1].ItemBg).rectTransform.sizeDelta with
          {
            x = 776f
          };
          ((Graphic) this.m_BuffItem[panelObjectIdx].Item[1].ItemBg).rectTransform.sizeDelta = vector2;
          vector2 = ((Graphic) this.m_BuffItem[panelObjectIdx].Item[1].ItemBg).rectTransform.anchoredPosition with
          {
            x = 2f
          };
          ((Graphic) this.m_BuffItem[panelObjectIdx].Item[1].ItemBg).rectTransform.anchoredPosition = vector2;
          this.m_BuffItem[panelObjectIdx].Item[1].ItemBg.sprite = this.m_SpriteArray.GetSprite(0);
        }
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 999)
      this.m_door.CloseMenu();
    else if (this.DM.ItemBuffTable.GetRecordByIndex(sender.m_BtnID1).BuffKind == (byte) 7)
      this.m_door.OpenMenu(EGUIWindow.UI_BuffInformation);
    else
      this.m_door.OpenMenu(EGUIWindow.UI_BagFilter, 5, sender.m_BtnID1);
  }

  public void SetTitleType()
  {
    byte num1 = 7;
    byte num2 = 6;
    byte num3 = 8;
    byte num4 = 9;
    byte num5 = 5;
    byte[] numArray1 = new byte[9]
    {
      (byte) 8,
      (byte) 9,
      (byte) 7,
      (byte) 6,
      (byte) 5,
      (byte) 1,
      (byte) 3,
      (byte) 4,
      (byte) 2
    };
    byte[] numArray2 = new byte[2]{ (byte) 3, (byte) 4 };
    byte[] numArray3 = new byte[3]
    {
      (byte) 1,
      (byte) 3,
      (byte) 4
    };
    ushort[] numArray4 = new ushort[3]
    {
      (ushort) 2,
      (ushort) 3,
      (ushort) 6
    };
    ushort[] numArray5 = new ushort[5]
    {
      (ushort) 1,
      (ushort) 2,
      (ushort) 3,
      (ushort) 4,
      (ushort) 8
    };
    this.DM.SortCurItemDataForBag();
    this.DM.SortStoreData();
    this.m_Data.Clear();
    bool flag1 = GUIManager.Instance.BuildingData.GetBuildData((ushort) 8, (ushort) 0).Level >= (byte) 9;
    int num6 = 0;
    if (this.m_UIType == eBuffListUIType.BuffList)
    {
      if (this.DM.RoleAttr.WorldTitle_Country > (ushort) 0)
      {
        this.m_Data.Add((ushort) 9999);
        ++num6;
      }
      if (this.DM.m_KingdomBattleIdx >= 0 && this.DM.m_KingdomBattleIdx < this.DM.m_RecvItemBuffData.Length && this.DM.m_RecvItemBuffData[this.DM.m_KingdomBattleIdx].bEnable)
      {
        this.m_Data.Add((ushort) this.DM.m_KingdomBattleIdx);
        ++num6;
      }
      if (this.DM.m_RecvWorldBattleIdx >= 0 && this.DM.m_RecvWorldBattleIdx < this.DM.m_RecvItemBuffData.Length && this.DM.m_RecvItemBuffData[this.DM.m_RecvWorldBattleIdx].bEnable)
      {
        this.m_Data.Add((ushort) this.DM.m_RecvWorldBattleIdx);
        ++num6;
      }
      if (this.DM.m_NobilityBattleIdx >= 0 && this.DM.m_NobilityBattleIdx < this.DM.m_RecvItemBuffData.Length && this.DM.m_RecvItemBuffData[this.DM.m_NobilityBattleIdx].bEnable)
      {
        this.m_Data.Add((ushort) this.DM.m_NobilityBattleIdx);
        ++num6;
      }
      ItemBuff recordByIndex;
      for (int Index = 0; Index < this.DM.MaxBuffTableCount; ++Index)
      {
        recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(Index);
        if ((int) recordByIndex.BuffKind == (int) num5)
        {
          if (this.DM.m_RecvItemBuffData[Index].bEnable)
            this.m_Data.Insert(num6++, (ushort) Index);
        }
        else if ((int) recordByIndex.BuffKind == (int) num1 && flag1)
          this.m_Data.Insert(num6++, (ushort) Index);
        else if (this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind) && (int) num3 != (int) recordByIndex.BuffKind && (int) num2 != (int) recordByIndex.BuffKind && (int) num4 != (int) recordByIndex.BuffKind)
          this.m_Data.Add((ushort) Index);
      }
      for (int index = 0; index < numArray1.Length; ++index)
      {
        for (int Index = 0; Index < this.DM.MaxBuffTableCount; ++Index)
        {
          recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(Index);
          if (((int) recordByIndex.BuffKind == (int) num1 && flag1 || (int) recordByIndex.BuffKind == (int) num3 || (int) recordByIndex.BuffKind == (int) num4 || this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind)) && (int) numArray1[index] == (int) recordByIndex.BuffKind)
          {
            this.m_TitleType[Index] = numArray1[index];
            break;
          }
        }
      }
    }
    else if (this.m_UIType == eBuffListUIType.AttackBuffList)
    {
      ItemBuff recordByIndex;
      for (int Index = 0; Index < this.DM.MaxBuffTableCount; ++Index)
      {
        bool flag2 = false;
        recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(Index);
        for (int index = 0; index < numArray4.Length; ++index)
        {
          if ((int) numArray4[index] == (int) recordByIndex.BuffID)
          {
            flag2 = true;
            break;
          }
        }
        if (flag2 && this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind))
          this.m_Data.Add((ushort) Index);
      }
      for (int index1 = 0; index1 < numArray2.Length; ++index1)
      {
        for (int index2 = 0; index2 < this.m_Data.Count; ++index2)
        {
          int Index = (int) this.m_Data[index2];
          recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(Index);
          if (recordByIndex.BuffKind != (byte) 0 && this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind) && (int) numArray2[index1] == (int) recordByIndex.BuffKind)
          {
            this.m_TitleType[Index] = numArray2[index1];
            break;
          }
        }
      }
    }
    else if (this.m_UIType == eBuffListUIType.DefendBuffList)
    {
      ItemBuff recordByIndex;
      for (int Index = 0; Index < this.DM.MaxBuffTableCount; ++Index)
      {
        bool flag3 = false;
        recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(Index);
        for (int index = 0; index < numArray5.Length; ++index)
        {
          if ((int) numArray5[index] == (int) recordByIndex.BuffID)
          {
            flag3 = true;
            break;
          }
        }
        if (flag3 && this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind))
          this.m_Data.Add((ushort) Index);
      }
      for (int index3 = 0; index3 < numArray3.Length; ++index3)
      {
        for (int index4 = 0; index4 < this.m_Data.Count; ++index4)
        {
          int Index = (int) this.m_Data[index4];
          recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(Index);
          if (this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind) && recordByIndex.BuffKind != (byte) 0 && (int) numArray3[index3] == (int) recordByIndex.BuffKind)
          {
            this.m_TitleType[Index] = numArray3[index3];
            break;
          }
        }
      }
    }
    else
    {
      if (this.m_UIType != eBuffListUIType.KingdomBuff)
        return;
      ItemBuff recordByIndex;
      for (int Index = 0; Index < this.DM.MaxBuffTableCount; ++Index)
      {
        recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(Index);
        if (this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind))
          this.m_Data.Add((ushort) Index);
      }
      for (int index = 0; index < numArray1.Length; ++index)
      {
        for (int Index = 0; Index < this.DM.MaxBuffTableCount; ++Index)
        {
          recordByIndex = this.DM.ItemBuffTable.GetRecordByIndex(Index);
          if (this.CheckBuffByID(recordByIndex.BuffID, recordByIndex.BuffKind) && (int) numArray1[index] == (int) num5)
          {
            this.m_TitleType[Index] = numArray1[index];
            break;
          }
        }
      }
    }
  }

  public bool CheckBuffByID(ushort id, byte buffKind)
  {
    Equip recordByKey1 = this.DM.EquipTable.GetRecordByKey(this.DM.ItemBuffTable.GetRecordByKey(id).BuffItemID);
    byte equipKind = recordByKey1.EquipKind;
    ushort propertieskey = recordByKey1.PropertiesInfo[0].Propertieskey;
    if (equipKind <= (byte) 0 || propertieskey <= (ushort) 0)
      return false;
    if (this.m_UIType == eBuffListUIType.KingdomBuff)
      return buffKind == (byte) 5;
    if (this.DM.m_RecvItemBuffData[this.DM.GetRecvBuffDataIdxByID(id)].bEnable)
      return true;
    if (recordByKey1.EquipKind == (byte) 12 && recordByKey1.PropertiesInfo[0].Propertieskey == (ushort) 33)
      return DataManager.StageDataController.StageRecord[2] >= (ushort) 8;
    ushort num1 = this.DM.sortItemDataCount[(int) equipKind - 1];
    if (num1 != (ushort) 0)
    {
      ushort num2 = this.DM.sortItemDataStart[(int) equipKind - 1];
      for (int index = (int) num2; index < (int) num2 + (int) num1; ++index)
      {
        if ((int) this.DM.EquipTable.GetRecordByKey(this.DM.sortItemData[index]).PropertiesInfo[0].Propertieskey == (int) propertieskey)
          return true;
      }
    }
    ushort num3 = this.DM.SortSotreDataCount[(int) equipKind];
    if (num3 != (ushort) 0)
    {
      ushort num4 = this.DM.SortSotreDataStart[(int) equipKind];
      for (int index = (int) num4; index < (int) num4 + (int) num3; ++index)
      {
        StoreTbl recordByKey2 = DataManager.Instance.StoreData.GetRecordByKey(this.DM.SortSotreData[index]);
        if (recordByKey2.Price != 0U && recordByKey2.Filter < (byte) 2 && (int) this.DM.EquipTable.GetRecordByKey(recordByKey2.ItemID).PropertiesInfo[0].Propertieskey == (int) propertieskey)
          return true;
      }
    }
    return false;
  }

  public bool CheckBuffByKind(byte kind)
  {
    if (this.m_UIType == eBuffListUIType.KingdomBuff)
    {
      if (kind != (byte) 5)
        return false;
    }
    else if (kind == (byte) 5)
      return false;
    return true;
  }

  public void SetTime(int dd, int hh, int mm, int ss, CString _tempString, UIText text)
  {
    if ((UnityEngine.Object) text == (UnityEngine.Object) null)
      return;
    if (dd >= 0 && hh >= 0 && mm >= 0 && ss >= 0)
    {
      _tempString.ClearString();
      if (dd > 0)
      {
        _tempString.IntToFormat((long) dd);
        _tempString.AppendFormat("{0}d ");
      }
      if (dd > 0 || hh > 0)
      {
        _tempString.IntToFormat((long) hh, 2);
        _tempString.AppendFormat("{0}:");
      }
      _tempString.IntToFormat((long) mm, 2);
      _tempString.IntToFormat((long) ss, 2);
      _tempString.AppendFormat("{0}:{1}");
    }
    text.text = _tempString.ToString();
    text.SetAllDirty();
    text.cachedTextGenerator.Invalidate();
    text.cachedTextGeneratorForLayout.Invalidate();
  }

  public void UpdateTime()
  {
    for (int index1 = 0; index1 < 7; ++index1)
    {
      for (int index2 = 0; index2 < 2; ++index2)
      {
        int tableIdx = this.m_BuffItem[index1].Item[index2].TableIdx;
        if (tableIdx < this.DM.MaxBuffTableCount && tableIdx >= 0 && this.DM.m_RecvItemBuffData[tableIdx].bEnable && (UnityEngine.Object) this.m_BuffItem[index1].Item[index2].TimeText != (UnityEngine.Object) null)
        {
          long num = this.DM.m_RecvItemBuffData[tableIdx].TargetTime - this.DM.ServerTime;
          if (num >= 0L)
          {
            int ss = (int) num % 60;
            int mm = (int) (num / 60L) % 60;
            int hh = (int) (num / 3600L) % 24;
            this.SetTime((int) num / 86400, hh, mm, ss, this.m_BuffItem[index1].Item[index2].TimeStr, this.m_BuffItem[index1].Item[index2].TimeText);
          }
        }
      }
    }
  }

  public void UpdateSlider()
  {
    for (int index1 = 0; index1 < 7; ++index1)
    {
      for (int index2 = 0; index2 < 2; ++index2)
      {
        int tableIdx = this.m_BuffItem[index1].Item[index2].TableIdx;
        if (tableIdx < this.DM.MaxBuffTableCount && tableIdx >= 0 && this.DM.m_RecvItemBuffData[tableIdx].bEnable && (UnityEngine.Object) this.m_BuffItem[index1].Item[index2].TimeSlider != (UnityEngine.Object) null)
        {
          double num1 = NetworkManager.ServerTime - (double) this.DM.m_RecvItemBuffData[tableIdx].BeginTime;
          long num2 = this.DM.m_RecvItemBuffData[tableIdx].TargetTime - this.DM.m_RecvItemBuffData[tableIdx].BeginTime;
          if ((double) num2 > 0.0)
          {
            double num3 = num1 / (double) num2;
            if (num3 >= 1.0)
              num3 = 1.0;
            ((Graphic) this.m_BuffItem[index1].Item[index2].TimeSlider).rectTransform.sizeDelta = new Vector2((float) (341.20001220703125 * num3), ((Graphic) this.m_BuffItem[index1].Item[index2].TimeSlider).rectTransform.sizeDelta.y);
          }
        }
      }
    }
  }

  public void UpdateSliderAlpha()
  {
    for (int index1 = 0; index1 < 7; ++index1)
    {
      for (int index2 = 0; index2 < 2; ++index2)
      {
        int tableIdx = this.m_BuffItem[index1].Item[index2].TableIdx;
        if (tableIdx < this.DM.MaxBuffTableCount && tableIdx >= 0 && this.DM.m_RecvItemBuffData[tableIdx].bEnable && (UnityEngine.Object) this.m_BuffItem[index1].Item[index2].TimeFlash != (UnityEngine.Object) null)
        {
          if ((double) this.ColorA > 1.0)
            ((Graphic) this.m_BuffItem[index1].Item[index2].TimeFlash).color = new Color(1f, 1f, 1f, 2f - this.ColorA);
          else
            ((Graphic) this.m_BuffItem[index1].Item[index2].TimeFlash).color = new Color(1f, 1f, 1f, this.ColorA);
        }
      }
    }
  }

  public float ATween(float t, float b, float c, float d)
  {
    t /= d;
    return b + c * t;
  }

  public void UpdateCDTime(long CDTime)
  {
    if ((UnityEngine.Object) this.m_CDText == (UnityEngine.Object) null)
      return;
    if (this.m_UIType == eBuffListUIType.KingdomBuff && CDTime > this.DM.ServerTime)
    {
      long num = CDTime - this.DM.ServerTime;
      if (num >= 0L)
      {
        int ss = (int) num % 60;
        int mm = (int) (num / 60L) % 60;
        int hh = (int) (num / 3600L) % 24;
        this.SetTime((int) num / 86400, hh, mm, ss, this.m_CDCStr, this.m_CDText);
        ((Graphic) this.m_CDText).rectTransform.sizeDelta = ((Graphic) this.m_CDText).rectTransform.sizeDelta with
        {
          x = this.m_CDText.preferredWidth
        };
      }
      if (((Component) this.m_CDText).gameObject.activeSelf)
        return;
      ((Component) this.m_CDText).gameObject.SetActive(true);
    }
    else
    {
      if (!((Component) this.m_CDText).gameObject.activeSelf)
        return;
      ((Component) this.m_CDText).gameObject.SetActive(false);
    }
  }

  private float GetTitleItemH() => this.HaveEffect3() ? 176f : 140f;

  private bool HaveEffect3()
  {
    return this.DM.TitleDataN.GetRecordByKey(this.DM.RoleAttr.WorldTitle_Country).Effects[2].EffectID != (ushort) 0;
  }
}
