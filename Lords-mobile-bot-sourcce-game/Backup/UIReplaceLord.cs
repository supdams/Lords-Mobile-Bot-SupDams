// Decompiled with JetBrains decompiler
// Type: UIReplaceLord
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
internal class UIReplaceLord : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler
{
  private const int m_MaxPanelObject = 8;
  private const int TextMax = 9;
  private GUIManager GM;
  private DataManager DM;
  private Door door;
  private Font TTF;
  private List<SoldierScrollItem> m_Data;
  private UIHIBtn m_OriginaHIBtn;
  private UIHIBtn m_ChangeHIBtn;
  private Image m_OriginaIcon1;
  private Image m_OriginaIcon2;
  private Image m_ChangeIcon1;
  private Image m_ChangeIcon2;
  private UIText m_OriginaName;
  private UIText m_OriginaArmyText;
  private UIText m_OriginaArmyNumText;
  private UIText m_ChangeName;
  private UIText m_ChangeArmyText;
  private UIText m_ChangeArmyNumText;
  private ScrollPanel m_ScrollPanel;
  private UISpritesArray m_SpritesArray;
  private Transform m_SkillHintPanel;
  private Transform[] m_SkillMaskTf;
  private UIText m_HeroNameText;
  private UIText m_HeroArmsText;
  private UIText m_HeroMaxNum;
  private Image m_HeroEnhanceIcon;
  private UIHIBtn m_HeroIcon;
  private UIText[] m_SkliiNameText;
  private UIText[] m_SkillInfoText;
  private Image[] m_SkillImage;
  private Image[] m_SkillFrame;
  private ScrollPanelObject[] m_ScrollObj;
  private int NowSelectIdx;
  private int NowLeft;
  private ushort m_SelectHeroID;
  private bool bLordIsFight;
  private CString m_SpriteStr;
  private CString m_OriginaArmyNumStr;
  private CString m_ChangeArmyNumStr;
  private CString m_HeroMaxNumStr;
  private CString[] m_SkillInfoStr;
  private int mTextCount;
  private UIText[] m_tmptext = new UIText[9];

  public override void OnOpen(int arg1, int arg2)
  {
    this.GM = GUIManager.Instance;
    this.DM = DataManager.Instance;
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.TTF = this.GM.GetTTFFont();
    GUIManager.Instance.AddSpriteAsset("UI_frame");
    this.DM.SetSortNonFightHeroID();
    this.DM.SetSortFightHeroID();
    this.m_SpriteStr = StringManager.Instance.SpawnString();
    this.m_OriginaArmyNumStr = StringManager.Instance.SpawnString();
    this.m_ChangeArmyNumStr = StringManager.Instance.SpawnString();
    this.m_HeroMaxNumStr = StringManager.Instance.SpawnString();
    this.m_SkillInfoStr = new CString[4];
    for (int index = 0; index < this.m_SkillInfoStr.Length; ++index)
      this.m_SkillInfoStr[index] = StringManager.Instance.SpawnString();
    this.m_Data = new List<SoldierScrollItem>();
    this.m_ScrollObj = new ScrollPanelObject[8];
    for (int index = 0; index < 8; ++index)
      this.m_ScrollObj[index].PanelItem = new SoldierPanelObject[2];
    this.m_SpritesArray = this.transform.GetComponent<UISpritesArray>();
    Image component1 = this.transform.GetChild(8).GetComponent<Image>();
    component1.sprite = this.door.LoadSprite("UI_main_close_base");
    ((MaskableGraphic) component1).material = this.door.LoadMaterial();
    if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (Object) component1)
      ((Behaviour) component1).enabled = false;
    Image component2 = this.transform.GetChild(8).GetChild(0).GetComponent<Image>();
    component2.sprite = this.door.LoadSprite("UI_main_close");
    ((MaskableGraphic) component2).material = this.door.LoadMaterial();
    UIButton component3 = this.transform.GetChild(8).GetChild(0).GetComponent<UIButton>();
    component3.m_Handler = (IUIButtonClickHandler) this;
    component3.m_BtnID1 = 999;
    this.m_tmptext[this.mTextCount] = this.transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(731U);
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = this.transform.GetChild(0).GetChild(3).GetChild(2).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(733U);
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = this.transform.GetChild(0).GetChild(8).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(730U);
    ++this.mTextCount;
    UIButton component4 = this.transform.GetChild(7).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_BtnID1 = 998;
    this.m_tmptext[this.mTextCount] = this.transform.GetChild(7).GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(189U);
    ++this.mTextCount;
    this.m_OriginaHIBtn = this.transform.GetChild(1).GetChild(0).GetComponent<UIHIBtn>();
    this.GM.InitianHeroItemImg(((Component) this.m_OriginaHIBtn).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 1, 1, bAutoShowHint: false);
    this.m_ChangeHIBtn = this.transform.GetChild(2).GetChild(0).GetComponent<UIHIBtn>();
    this.GM.InitianHeroItemImg(((Component) this.m_ChangeHIBtn).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 1, (byte) 1, 1, bAutoShowHint: false);
    this.m_OriginaIcon1 = this.transform.GetChild(1).GetChild(1).GetComponent<Image>();
    this.m_OriginaIcon2 = this.transform.GetChild(1).GetChild(2).GetComponent<Image>();
    this.m_OriginaName = this.transform.GetChild(1).GetChild(3).GetComponent<UIText>();
    this.m_OriginaName.font = this.TTF;
    this.m_OriginaArmyText = this.transform.GetChild(1).GetChild(4).GetComponent<UIText>();
    this.m_OriginaArmyText.font = this.TTF;
    this.m_OriginaArmyNumText = this.transform.GetChild(1).GetChild(5).GetComponent<UIText>();
    this.m_OriginaArmyNumText.font = this.TTF;
    this.m_ChangeIcon1 = this.transform.GetChild(2).GetChild(1).GetComponent<Image>();
    this.m_ChangeIcon2 = this.transform.GetChild(2).GetChild(2).GetComponent<Image>();
    this.m_ChangeName = this.transform.GetChild(2).GetChild(3).GetComponent<UIText>();
    this.m_ChangeName.font = this.TTF;
    this.m_ChangeArmyText = this.transform.GetChild(2).GetChild(4).GetComponent<UIText>();
    this.m_ChangeArmyText.font = this.TTF;
    this.m_ChangeArmyNumText = this.transform.GetChild(2).GetChild(5).GetComponent<UIText>();
    this.m_ChangeArmyNumText.font = this.TTF;
    this.GM.InitianHeroItemImg(((Component) this.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(0).GetComponent<UIHIBtn>()).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 0, (byte) 0, bAutoShowHint: false);
    this.GM.InitianHeroItemImg(((Component) this.transform.GetChild(6).GetChild(0).GetChild(1).GetChild(0).GetComponent<UIHIBtn>()).transform, eHeroOrItem.Hero, (ushort) 1, (byte) 0, (byte) 0, bAutoShowHint: false);
    this.m_tmptext[this.mTextCount] = this.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(3).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = this.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(4).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = this.transform.GetChild(6).GetChild(0).GetChild(1).GetChild(3).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = this.transform.GetChild(6).GetChild(0).GetChild(1).GetChild(4).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    ++this.mTextCount;
    this.m_tmptext[this.mTextCount] = this.transform.GetChild(6).GetChild(0).GetChild(2).GetChild(0).GetComponent<UIText>();
    this.m_tmptext[this.mTextCount].font = this.TTF;
    this.m_tmptext[this.mTextCount].text = this.DM.mStringTable.GetStringByID(341U);
    ++this.mTextCount;
    if (GUIManager.Instance.IsArabic)
    {
      RectTransform rectTransform1 = ((Graphic) this.transform.GetChild(6).GetChild(0).GetChild(0).GetChild(7).GetComponent<Image>()).rectTransform;
      Vector3 localScale = ((Transform) rectTransform1).localScale with
      {
        x = -1f
      };
      ((Transform) rectTransform1).localScale = localScale;
      RectTransform rectTransform2 = ((Graphic) this.transform.GetChild(6).GetChild(0).GetChild(1).GetChild(7).GetComponent<Image>()).rectTransform;
      localScale = ((Transform) rectTransform2).localScale with
      {
        x = -1f
      };
      ((Transform) rectTransform2).localScale = localScale;
    }
    this.m_SkillHintPanel = this.transform.GetChild(9);
    this.m_HeroIcon = this.m_SkillHintPanel.GetChild(0).GetChild(1).GetComponent<UIHIBtn>();
    this.GM.InitianHeroItemImg(((Component) this.m_HeroIcon).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bAutoShowHint: false);
    this.m_HeroNameText = this.m_SkillHintPanel.GetChild(0).GetChild(3).GetComponent<UIText>();
    this.m_HeroNameText.font = this.TTF;
    this.m_HeroArmsText = this.m_SkillHintPanel.GetChild(0).GetChild(4).GetComponent<UIText>();
    this.m_HeroArmsText.font = this.TTF;
    this.m_HeroMaxNum = this.m_SkillHintPanel.GetChild(0).GetChild(5).GetComponent<UIText>();
    this.m_HeroMaxNum.font = this.TTF;
    this.m_HeroEnhanceIcon = this.m_SkillHintPanel.GetChild(0).GetChild(2).GetComponent<Image>();
    ((MaskableGraphic) this.m_HeroEnhanceIcon).material = this.GetEnhanceMat();
    this.m_SkillImage = new Image[4];
    this.m_SkillFrame = new Image[4];
    this.m_SkillMaskTf = new Transform[4];
    this.m_SkliiNameText = new UIText[4];
    this.m_SkillInfoText = new UIText[4];
    for (int index = 0; index < 4; ++index)
    {
      Transform child = this.m_SkillHintPanel.GetChild(index + 1);
      this.m_SkillImage[index] = child.GetChild(1).GetComponent<Image>();
      this.m_SkillFrame[index] = this.m_SkillHintPanel.GetChild(index + 1).GetChild(1).GetChild(0).GetComponent<Image>();
      this.m_SkliiNameText[index] = this.m_SkillHintPanel.GetChild(index + 1).GetChild(2).GetComponent<UIText>();
      this.m_SkliiNameText[index].font = this.TTF;
      this.m_SkillInfoText[index] = this.m_SkillHintPanel.GetChild(index + 1).GetChild(3).GetComponent<UIText>();
      this.m_SkillInfoText[index].font = this.TTF;
      this.m_SkillMaskTf[index] = this.m_SkillHintPanel.GetChild(index + 1).GetChild(4);
    }
    this.SetData((ushort) 0);
    this.m_ScrollPanel = this.transform.GetChild(4).GetComponent<ScrollPanel>();
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_Data.Count; ++index)
      _DataHeight.Add(this.m_Data[index].Height);
    this.m_ScrollPanel.IntiScrollPanel(497f, 10f, 6f, _DataHeight, 8, (IUpDateScrollPanel) this);
    UIButtonHint.scrollRect = this.m_ScrollPanel.GetComponent<CScrollRect>();
    this.SetChangeLord((ushort) 0, (byte) 0, (byte) 0, (ushort) 0, (byte) 0, (byte) 0);
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    GUIManager.Instance.RemoveSpriteAsset("UI_frame");
    StringManager.Instance.DeSpawnString(this.m_SpriteStr);
    StringManager.Instance.DeSpawnString(this.m_OriginaArmyNumStr);
    StringManager.Instance.DeSpawnString(this.m_ChangeArmyNumStr);
    if (this.m_HeroMaxNumStr != null)
    {
      StringManager.Instance.DeSpawnString(this.m_HeroMaxNumStr);
      this.m_HeroMaxNumStr = (CString) null;
    }
    if (this.m_SkillInfoStr != null)
    {
      for (int index = 0; index < this.m_SkillInfoStr.Length; ++index)
      {
        if (this.m_SkillInfoStr[index] != null)
        {
          StringManager.Instance.DeSpawnString(this.m_SkillInfoStr[index]);
          this.m_SkillInfoStr[index] = (CString) null;
        }
      }
    }
    for (int index1 = 0; index1 < this.m_ScrollObj.Length; ++index1)
    {
      for (int index2 = 0; index2 < 2; ++index2)
      {
        if (this.m_ScrollObj[index1].PanelItem[index2].MaxNumStr != null)
          StringManager.Instance.DeSpawnString(this.m_ScrollObj[index1].PanelItem[index2].MaxNumStr);
      }
    }
    this.Despawn();
    this.m_Data.Clear();
    this.m_Data = (List<SoldierScrollItem>) null;
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
        this.DM.SetSortNonFightHeroID();
        this.DM.SetSortFightHeroID();
        this.Despawn();
        if (meg[0] == (byte) 29)
          this.SetData(this.m_SelectHeroID);
        else
          this.SetData((ushort) 0);
        this.UpdateScroll();
        this.SetChangeLord((ushort) 0, (byte) 0, (byte) 0, (ushort) 0, (byte) 0, (byte) 0);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_ChangeLord)
        {
          if (networkNews != NetworkNews.Refresh_TroopHome)
          {
            if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
              break;
            this.Refresh_FontTexture();
            break;
          }
          goto case NetworkNews.Login;
        }
        else
        {
          if (meg[1] == (byte) 0)
            this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(734U), (ushort) byte.MaxValue);
          if (!(bool) (Object) this.door)
            break;
          this.door.CloseMenu();
          break;
        }
    }
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.m_OriginaName != (Object) null && ((Behaviour) this.m_OriginaName).enabled)
    {
      ((Behaviour) this.m_OriginaName).enabled = false;
      ((Behaviour) this.m_OriginaName).enabled = true;
    }
    if ((Object) this.m_OriginaArmyText != (Object) null && ((Behaviour) this.m_OriginaArmyText).enabled)
    {
      ((Behaviour) this.m_OriginaArmyText).enabled = false;
      ((Behaviour) this.m_OriginaArmyText).enabled = true;
    }
    if ((Object) this.m_OriginaArmyNumText != (Object) null && ((Behaviour) this.m_OriginaArmyNumText).enabled)
    {
      ((Behaviour) this.m_OriginaArmyNumText).enabled = false;
      ((Behaviour) this.m_OriginaArmyNumText).enabled = true;
    }
    if ((Object) this.m_ChangeName != (Object) null && ((Behaviour) this.m_ChangeName).enabled)
    {
      ((Behaviour) this.m_ChangeName).enabled = false;
      ((Behaviour) this.m_ChangeName).enabled = true;
    }
    if ((Object) this.m_ChangeArmyText != (Object) null && ((Behaviour) this.m_ChangeArmyText).enabled)
    {
      ((Behaviour) this.m_ChangeArmyText).enabled = false;
      ((Behaviour) this.m_ChangeArmyText).enabled = true;
    }
    if ((Object) this.m_ChangeArmyNumText != (Object) null && ((Behaviour) this.m_ChangeArmyNumText).enabled)
    {
      ((Behaviour) this.m_ChangeArmyNumText).enabled = false;
      ((Behaviour) this.m_ChangeArmyNumText).enabled = true;
    }
    for (int index = 0; index < 9; ++index)
    {
      if ((Object) this.m_tmptext[index] != (Object) null && ((Behaviour) this.m_tmptext[index]).enabled)
      {
        ((Behaviour) this.m_tmptext[index]).enabled = false;
        ((Behaviour) this.m_tmptext[index]).enabled = true;
      }
    }
    if (this.m_ScrollObj != null)
    {
      for (int index1 = 0; index1 < this.m_ScrollObj.Length; ++index1)
      {
        if (this.m_ScrollObj[index1].PanelItem != null)
        {
          for (int index2 = 0; index2 < this.m_ScrollObj[index1].PanelItem.Length; ++index2)
          {
            if ((Object) this.m_ScrollObj[index1].PanelItem[index2].HeroBtn != (Object) null && ((Behaviour) this.m_ScrollObj[index1].PanelItem[index2].HeroBtn).enabled)
              this.m_ScrollObj[index1].PanelItem[index2].HeroBtn.Refresh_FontTexture();
            if ((Object) this.m_ScrollObj[index1].PanelItem[index2].MaxNumText != (Object) null && (Object) this.m_ScrollObj[index1].PanelItem[index2].MaxNumText != (Object) null)
            {
              ((Behaviour) this.m_ScrollObj[index1].PanelItem[index2].MaxNumText).enabled = false;
              ((Behaviour) this.m_ScrollObj[index1].PanelItem[index2].MaxNumText).enabled = true;
            }
            if ((Object) this.m_ScrollObj[index1].PanelItem[index2].ArmsText != (Object) null && (Object) this.m_ScrollObj[index1].PanelItem[index2].ArmsText != (Object) null)
            {
              ((Behaviour) this.m_ScrollObj[index1].PanelItem[index2].ArmsText).enabled = false;
              ((Behaviour) this.m_ScrollObj[index1].PanelItem[index2].ArmsText).enabled = true;
            }
          }
        }
      }
    }
    if ((Object) this.m_HeroNameText != (Object) null && ((Behaviour) this.m_HeroNameText).enabled)
    {
      ((Behaviour) this.m_HeroNameText).enabled = false;
      ((Behaviour) this.m_HeroNameText).enabled = true;
    }
    if ((Object) this.m_HeroArmsText != (Object) null && ((Behaviour) this.m_HeroArmsText).enabled)
    {
      ((Behaviour) this.m_HeroArmsText).enabled = false;
      ((Behaviour) this.m_HeroArmsText).enabled = true;
    }
    if ((Object) this.m_HeroMaxNum != (Object) null && ((Behaviour) this.m_HeroMaxNum).enabled)
    {
      ((Behaviour) this.m_HeroMaxNum).enabled = false;
      ((Behaviour) this.m_HeroMaxNum).enabled = true;
    }
    if (this.m_SkliiNameText != null)
    {
      for (int index = 0; index < this.m_SkliiNameText.Length; ++index)
      {
        if ((Object) this.m_SkliiNameText[index] != (Object) null && ((Behaviour) this.m_SkliiNameText[index]).enabled)
        {
          ((Behaviour) this.m_SkliiNameText[index]).enabled = false;
          ((Behaviour) this.m_SkliiNameText[index]).enabled = true;
        }
      }
    }
    if (this.m_SkillInfoText != null)
    {
      for (int index = 0; index < this.m_SkillInfoText.Length; ++index)
      {
        if ((Object) this.m_SkillInfoText[index] != (Object) null && ((Behaviour) this.m_SkillInfoText[index]).enabled)
        {
          ((Behaviour) this.m_SkillInfoText[index]).enabled = false;
          ((Behaviour) this.m_SkillInfoText[index]).enabled = true;
        }
      }
    }
    if ((bool) (Object) this.m_HeroIcon)
      this.m_HeroIcon.Refresh_FontTexture();
    if ((bool) (Object) this.m_OriginaHIBtn)
      this.m_OriginaHIBtn.Refresh_FontTexture();
    if (!(bool) (Object) this.m_ChangeHIBtn)
      return;
    this.m_ChangeHIBtn.Refresh_FontTexture();
  }

  public void OnButtonClick(UIButton sender)
  {
    int btnId1 = sender.m_BtnID1;
    int btnId3 = sender.m_BtnID3;
    if (sender.m_BtnID1 == 999)
    {
      if (!(bool) (Object) this.door)
        return;
      this.door.CloseMenu();
    }
    else if (sender.m_BtnID1 == 998)
    {
      if (this.m_SelectHeroID == (ushort) 0)
        return;
      if (!this.bLordIsFight)
        this.DM.SendChangeLord(this.m_SelectHeroID);
      else
        this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(727U), (ushort) byte.MaxValue);
    }
    else
    {
      if (btnId1 < 0 || btnId1 >= 100 || btnId1 >= this.m_Data.Count || btnId3 < 0 || btnId3 >= 2)
        return;
      bool bIsFight = this.m_Data[btnId1].Item[btnId3].bIsFight;
      bool bSelect = this.m_Data[btnId1].Item[btnId3].bSelect;
      bool bIsLords = this.m_Data[btnId1].Item[btnId3].bIsLords;
      if (!bIsFight)
      {
        if (!bIsLords)
        {
          ushort heroId = this.m_Data[btnId1].Item[btnId3].HeroID;
          byte arms = this.m_Data[btnId1].Item[btnId3].Arms;
          byte enhance = this.m_Data[btnId1].Item[btnId3].Enhance;
          ushort maxNum = this.m_Data[btnId1].Item[btnId3].MaxNum;
          byte star = this.m_Data[btnId1].Item[btnId3].Star;
          byte lv = this.m_Data[btnId1].Item[btnId3].Lv;
          if (!bSelect)
          {
            if (this.NowSelectIdx >= 0 && this.NowSelectIdx < this.m_Data.Count && this.NowLeft >= 0 && this.NowLeft < 2 && this.m_Data[this.NowSelectIdx].Item[this.NowLeft].bSelect)
              this.m_Data[this.NowSelectIdx].Item[this.NowLeft].bSelect = false;
            this.m_SelectHeroID = heroId;
            this.SetChangeLord(heroId, arms, enhance, maxNum, star, lv);
            this.m_Data[btnId1].Item[btnId3].bSelect = true;
          }
          else
          {
            this.m_Data[btnId1].Item[btnId3].bSelect = false;
            this.SetChangeLord((ushort) 0, (byte) 0, (byte) 0, (ushort) 0, (byte) 0, (byte) 0);
            this.m_SelectHeroID = (ushort) 0;
          }
          this.NowSelectIdx = btnId1;
          this.NowLeft = btnId3;
          this.UpdateScroll();
        }
        else
          this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(732U), (ushort) byte.MaxValue);
      }
      else
        this.GM.AddHUDMessage(this.DM.mStringTable.GetStringByID(708U), (ushort) byte.MaxValue);
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    Transform[] transformArray = new Transform[2];
    ScrollPanelItem component1 = item.transform.GetComponent<ScrollPanelItem>();
    component1.m_BtnID1 = dataIdx;
    component1.m_BtnID2 = panelObjectIdx;
    if ((Object) this.m_ScrollObj[panelObjectIdx].PanelItem[0].HeroBtn == (Object) null)
    {
      for (int index = 0; index < 2; ++index)
      {
        transformArray[index] = item.transform.GetChild(0).GetChild(index);
        transformArray[index].GetComponent<UIButton>().m_Handler = (IUIButtonClickHandler) this;
        this.m_ScrollObj[panelObjectIdx].PanelItem[index].HeroBtn = transformArray[index].GetChild(0).GetComponent<UIHIBtn>();
        UIButtonHint uiButtonHint = transformArray[index].GetChild(0).gameObject.AddComponent<UIButtonHint>();
        uiButtonHint.m_Handler = (MonoBehaviour) this;
        uiButtonHint.m_eHint = EUIButtonHint.DownUpHandler;
        this.m_ScrollObj[panelObjectIdx].PanelItem[index].EnhanceIcon = transformArray[index].GetChild(2).GetComponent<Image>();
        ((MaskableGraphic) this.m_ScrollObj[panelObjectIdx].PanelItem[index].EnhanceIcon).material = this.GetEnhanceMat();
        this.m_ScrollObj[panelObjectIdx].PanelItem[index].ArmsIcons = transformArray[index].GetChild(1).GetComponent<Image>();
        this.m_ScrollObj[panelObjectIdx].PanelItem[index].ArmsText = transformArray[index].GetChild(3).GetComponent<UIText>();
        this.m_ScrollObj[panelObjectIdx].PanelItem[index].ArmsText.font = this.TTF;
        this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumText = transformArray[index].GetChild(4).GetComponent<UIText>();
        this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumText.font = this.TTF;
        this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaskImage = transformArray[index].GetChild(5).GetComponent<Image>();
        this.m_ScrollObj[panelObjectIdx].PanelItem[index].SelectImage = transformArray[index].GetChild(7).GetComponent<Image>();
        this.m_ScrollObj[panelObjectIdx].PanelItem[index].FightImage = transformArray[index].GetChild(6).GetComponent<Image>();
        this.m_ScrollObj[panelObjectIdx].ItemTf1 = item.transform.GetChild(0).GetChild(0);
        this.m_ScrollObj[panelObjectIdx].ItemTf2 = item.transform.GetChild(0).GetChild(1);
        this.m_ScrollObj[panelObjectIdx].Line = item.transform.GetChild(0).GetChild(2);
        this.m_ScrollObj[panelObjectIdx].FinalText = item.transform.GetChild(0).GetChild(3);
        this.m_ScrollObj[panelObjectIdx].Line.GetChild(0).GetComponent<UIText>().font = this.TTF;
      }
    }
    for (int index = 0; index < 2; ++index)
    {
      transformArray[index] = item.transform.GetChild(0).GetChild(index);
      this.m_Data[dataIdx].panelObjectIdx = panelObjectIdx;
      if (this.m_Data[dataIdx].Item[index].Type == (byte) 1)
      {
        this.m_ScrollObj[panelObjectIdx].Line.gameObject.SetActive(true);
        this.m_ScrollObj[panelObjectIdx].FinalText.gameObject.SetActive(false);
        this.m_ScrollObj[panelObjectIdx].ItemTf1.gameObject.SetActive(false);
        this.m_ScrollObj[panelObjectIdx].ItemTf2.gameObject.SetActive(false);
      }
      else
      {
        this.m_ScrollObj[panelObjectIdx].Line.gameObject.SetActive(false);
        this.m_ScrollObj[panelObjectIdx].FinalText.gameObject.SetActive(false);
        this.m_ScrollObj[panelObjectIdx].ItemTf1.gameObject.SetActive(true);
        this.m_ScrollObj[panelObjectIdx].ItemTf2.gameObject.SetActive(true);
        if (this.m_Data[dataIdx].Item[index].Enable)
        {
          if (!transformArray[index].gameObject.activeSelf)
            transformArray[index].gameObject.SetActive(true);
          uint heroId = (uint) this.m_Data[dataIdx].Item[index].HeroID;
          if (index == 0)
          {
            GameObject gameObject = item.transform.GetChild(0).GetChild(0).GetChild(8).gameObject;
            if ((int) heroId == (int) this.DM.GetLeaderID())
              gameObject.SetActive(true);
            else
              gameObject.SetActive(false);
          }
          UIButton component2 = transformArray[index].GetComponent<UIButton>();
          component2.m_BtnID1 = dataIdx;
          component2.m_BtnID2 = panelObjectIdx;
          component2.m_BtnID3 = index;
          this.GM.ChangeHeroItemImg(((Component) this.m_ScrollObj[panelObjectIdx].PanelItem[index].HeroBtn).transform, eHeroOrItem.Hero, (ushort) heroId, this.m_Data[dataIdx].Item[index].Star, (byte) 0, (int) this.m_Data[dataIdx].Item[index].Lv);
          this.m_ScrollObj[panelObjectIdx].PanelItem[index].EnhanceIcon.sprite = this.GetEnhanceIcon(this.m_Data[dataIdx].Item[index].Enhance);
          this.m_ScrollObj[panelObjectIdx].PanelItem[index].ArmsIcons.sprite = this.GetArmsIcon(this.m_Data[dataIdx].Item[index].Arms);
          this.m_ScrollObj[panelObjectIdx].PanelItem[index].ArmsText = transformArray[index].GetChild(3).GetComponent<UIText>();
          this.m_ScrollObj[panelObjectIdx].PanelItem[index].ArmsText.text = this.GetArmsStr(this.m_Data[dataIdx].Item[index].Arms);
          this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumText = transformArray[index].GetChild(4).GetComponent<UIText>();
          if (this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumStr == null)
            this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumStr = StringManager.Instance.SpawnString();
          this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumStr.ClearString();
          StringManager.Instance.IntToFormat((long) this.m_Data[dataIdx].Item[index].MaxNum, bNumber: true);
          this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumStr.AppendFormat("{0}");
          this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumText.text = this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumStr.ToString();
          this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumText.SetAllDirty();
          this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaxNumText.cachedTextGenerator.Invalidate();
          if (this.m_Data[dataIdx].Item[index].bSelect || this.m_Data[dataIdx].Item[index].bIsFight || this.m_Data[dataIdx].Item[index].bIsLords)
          {
            ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaskImage).enabled = true;
            if (this.m_Data[dataIdx].Item[index].bSelect && this.m_Data[dataIdx].Item[index].bIsFight)
            {
              ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].SelectImage).enabled = true;
              ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].FightImage).enabled = true;
            }
            else if (this.m_Data[dataIdx].Item[index].bSelect && !this.m_Data[dataIdx].Item[index].bIsFight && !this.m_Data[dataIdx].Item[index].bIsLords)
            {
              ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].SelectImage).enabled = true;
              ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].FightImage).enabled = false;
            }
            else if (this.m_Data[dataIdx].Item[index].bIsFight && !this.m_Data[dataIdx].Item[index].bSelect && !this.m_Data[dataIdx].Item[index].bIsLords)
            {
              ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].FightImage).enabled = true;
              ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].SelectImage).enabled = false;
            }
            else if (this.m_Data[dataIdx].Item[index].bIsLords && !this.m_Data[dataIdx].Item[index].bSelect && !this.m_Data[dataIdx].Item[index].bIsFight)
            {
              ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].FightImage).enabled = false;
              ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].SelectImage).enabled = false;
            }
            else if (this.m_Data[dataIdx].Item[index].bIsLords && this.m_Data[dataIdx].Item[index].bIsFight && !this.m_Data[dataIdx].Item[index].bSelect)
            {
              ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].FightImage).enabled = true;
              ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].SelectImage).enabled = false;
            }
          }
          else
          {
            ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].MaskImage).enabled = false;
            ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].SelectImage).enabled = false;
            ((Behaviour) this.m_ScrollObj[panelObjectIdx].PanelItem[index].FightImage).enabled = false;
          }
        }
        else if (transformArray[index].gameObject.activeSelf)
          transformArray[index].gameObject.SetActive(false);
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  private void SetData(ushort SelectHeroID = 0)
  {
    SoldierScrollItem t = (SoldierScrollItem) null;
    ushort leaderId = this.DM.GetLeaderID();
    this.m_Data.Clear();
    this.bLordIsFight = false;
    for (int index1 = 0; (long) index1 < (long) this.DM.NonFightHeroCount; ++index1)
    {
      int index2 = index1 % 2;
      uint num = this.DM.SortNonFightHeroID[index1];
      if (index2 == 0)
      {
        t = this.GM.m_HeroList_Soldier_ItemDataPool2.spawn();
        t.Item[0].Enable = false;
        t.Item[0].Type = (byte) 0;
        t.Item[1].Enable = false;
        t.Item[1].Type = (byte) 0;
        t.Item[0].HeroID = (ushort) 0;
        t.Item[1].HeroID = (ushort) 0;
        t.Item[0].bIsLords = false;
        t.Item[1].bIsLords = false;
      }
      t.Height = 80f;
      if (DataManager.Instance.curHeroData.ContainsKey(num))
      {
        Hero recordByKey = this.DM.HeroTable.GetRecordByKey((ushort) num);
        t.Item[index2].HeroID = (ushort) num;
        t.Item[index2].Enable = true;
        CurHeroData curHeroData = DataManager.Instance.curHeroData[num];
        t.Item[index2].Lv = curHeroData.Level;
        t.Item[index2].Enhance = curHeroData.Enhance;
        t.Item[index2].Arms = recordByKey.SoldierKind;
        t.Item[index2].Star = curHeroData.Star;
        t.Item[index2].MaxNum = this.DM.RankSoldiers[(int) curHeroData.Enhance];
        t.Item[index2].bIsLords = false;
        t.Item[index2].bSelect = false;
        t.Item[index2].bIsFight = false;
        t.Item[index2].Type = (byte) 0;
        if ((int) num == (int) leaderId)
        {
          t.Item[index2].bIsLords = true;
          this.SetOriginalLord((ushort) num, t.Item[index2].Arms, t.Item[index2].Enhance, t.Item[index2].MaxNum, t.Item[index2].Star, t.Item[index2].Lv);
        }
        if ((int) SelectHeroID == (int) num)
        {
          t.Item[index2].bSelect = true;
          this.SetChangeLord((ushort) num, t.Item[index2].Arms, t.Item[index2].Enhance, t.Item[index2].MaxNum, t.Item[index2].Star, t.Item[index2].Lv);
          this.NowSelectIdx = this.m_Data.Count;
          this.NowLeft = index2;
        }
        if (index2 == 1 || (long) index1 == (long) (this.DM.NonFightHeroCount - 1U))
          this.m_Data.Add(t);
      }
      else if (index2 == 1 || (long) index1 == (long) (this.DM.NonFightHeroCount - 1U))
        this.GM.m_HeroList_Soldier_ItemDataPool2.despawn(t);
    }
    if (this.DM.FightHeroCount > 0U)
    {
      t = this.GM.m_HeroList_Soldier_ItemDataPool2.spawn();
      t.Item[0].Type = (byte) 1;
      t.Item[1].Type = (byte) 1;
      t.Item[0].HeroID = (ushort) 0;
      t.Item[1].HeroID = (ushort) 0;
      t.Item[0].Enable = true;
      t.Item[1].Enable = true;
      t.Item[0].bIsLords = false;
      t.Item[1].bIsLords = false;
      t.Height = 50f;
      this.m_Data.Add(t);
    }
    for (int index3 = 0; (long) index3 < (long) this.DM.FightHeroCount; ++index3)
    {
      int index4 = index3 % 2;
      uint num = this.DM.SortFightHeroID[index3];
      if (index4 == 0)
      {
        t = this.GM.m_HeroList_Soldier_ItemDataPool2.spawn();
        t.Item[0].Enable = false;
        t.Item[0].Type = (byte) 0;
        t.Item[1].Enable = false;
        t.Item[1].Type = (byte) 0;
        t.Item[0].HeroID = (ushort) 0;
        t.Item[1].HeroID = (ushort) 0;
        t.Item[0].bIsLords = false;
        t.Item[1].bIsLords = false;
      }
      t.Item[index4].Type = (byte) 0;
      t.Item[index4].HeroID = (ushort) num;
      t.Height = 80f;
      if (DataManager.Instance.curHeroData.ContainsKey(num))
      {
        t.Item[index4].HeroID = (ushort) num;
        Hero recordByKey = this.DM.HeroTable.GetRecordByKey((ushort) num);
        t.Item[index4].Enable = true;
        CurHeroData curHeroData = DataManager.Instance.curHeroData[num];
        t.Item[index4].Lv = curHeroData.Level;
        t.Item[index4].Enhance = curHeroData.Enhance;
        t.Item[index4].Arms = recordByKey.SoldierKind;
        t.Item[index4].Star = curHeroData.Star;
        t.Item[index4].MaxNum = this.DM.RankSoldiers[(int) curHeroData.Enhance];
        t.Item[index4].bIsLords = false;
        t.Item[index4].bSelect = false;
        t.Item[index4].bIsFight = true;
        t.Item[index4].Type = (byte) 0;
        if ((int) num == (int) leaderId)
        {
          this.bLordIsFight = true;
          t.Item[index4].bIsLords = true;
          ((Component) this.m_OriginaHIBtn).gameObject.SetActive(true);
          this.SetOriginalLord((ushort) num, t.Item[index4].Arms, t.Item[index4].Enhance, t.Item[index4].MaxNum, t.Item[index4].Star, t.Item[index4].Lv);
        }
        if (index4 == 1 || (long) index3 == (long) (this.DM.FightHeroCount - 1U))
          this.m_Data.Add(t);
      }
      else if (index4 == 1 || (long) index3 == (long) (this.DM.FightHeroCount - 1U))
        this.GM.m_HeroList_Soldier_ItemDataPool2.despawn(t);
    }
  }

  private void UpdateScroll(bool bMoveToFirst = false)
  {
    List<float> _DataHeight = new List<float>();
    for (int index = 0; index < this.m_Data.Count; ++index)
      _DataHeight.Add(this.m_Data[index].Height);
    this.m_ScrollPanel.AddNewDataHeight(_DataHeight, bMoveToFirst);
  }

  private Sprite GetEnhanceIcon(byte Enhance)
  {
    this.m_SpriteStr.ClearString();
    StringManager.Instance.IntToFormat((long) ((int) Enhance + 100));
    this.m_SpriteStr.AppendFormat("hf{0}");
    return GUIManager.Instance.LoadSprite("UI_frame", this.m_SpriteStr);
  }

  private Material GetEnhanceMat() => GUIManager.Instance.GetFrameMaterial();

  private Sprite GetArmsIcon(byte arms) => this.m_SpritesArray.GetSprite((int) arms);

  private string GetArmsStr(byte arms)
  {
    return DataManager.Instance.mStringTable.GetStringByID(3841U + (uint) arms);
  }

  private void SetOriginalLord(
    ushort HeroID,
    byte Arms,
    byte enhance,
    ushort MaxNum,
    byte Star,
    byte Level)
  {
    Hero recordByKey = this.DM.HeroTable.GetRecordByKey(HeroID);
    this.GM.ChangeHeroItemImg(((Component) this.m_OriginaHIBtn).transform, eHeroOrItem.Hero, HeroID, Star, enhance, (int) Level);
    this.m_OriginaIcon1.sprite = this.GetArmsIcon(Arms);
    this.m_OriginaIcon2.sprite = this.GetEnhanceIcon(enhance);
    ((MaskableGraphic) this.m_OriginaIcon2).material = this.GetEnhanceMat();
    this.m_OriginaName.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.HeroTitle);
    this.m_OriginaArmyText.text = this.GetArmsStr(Arms);
    this.m_OriginaArmyNumStr.ClearString();
    this.m_OriginaArmyNumStr.IntToFormat((long) MaxNum, bNumber: true);
    this.m_OriginaArmyNumStr.AppendFormat("{0}");
    this.m_OriginaArmyNumText.text = this.m_OriginaArmyNumStr.ToString();
  }

  private void SetChangeLord(
    ushort HeroID,
    byte Arms,
    byte enhance,
    ushort MaxNum,
    byte Star,
    byte Level)
  {
    if ((int) this.DM.GetLeaderID() == (int) HeroID || HeroID == (ushort) 0)
    {
      ((Component) this.m_ChangeHIBtn).gameObject.SetActive(false);
      ((Behaviour) this.m_ChangeIcon1).enabled = false;
      ((Behaviour) this.m_ChangeIcon2).enabled = false;
      ((Behaviour) this.m_ChangeName).enabled = false;
      ((Behaviour) this.m_ChangeArmyText).enabled = false;
      ((Behaviour) this.m_ChangeArmyNumText).enabled = false;
    }
    else
    {
      ((Component) this.m_ChangeHIBtn).gameObject.SetActive(true);
      ((Behaviour) this.m_ChangeIcon1).enabled = true;
      ((Behaviour) this.m_ChangeIcon2).enabled = true;
      ((Behaviour) this.m_ChangeName).enabled = true;
      ((Behaviour) this.m_ChangeArmyText).enabled = true;
      ((Behaviour) this.m_ChangeArmyNumText).enabled = true;
      Hero recordByKey = this.DM.HeroTable.GetRecordByKey(HeroID);
      this.GM.ChangeHeroItemImg(((Component) this.m_ChangeHIBtn).transform, eHeroOrItem.Hero, HeroID, Star, enhance, (int) Level);
      this.m_ChangeIcon1.sprite = this.GetArmsIcon(Arms);
      this.m_ChangeIcon2.sprite = this.GetEnhanceIcon(enhance);
      ((MaskableGraphic) this.m_ChangeIcon2).material = this.GetEnhanceMat();
      this.m_ChangeName.text = this.DM.mStringTable.GetStringByID((uint) recordByKey.HeroTitle);
      this.m_ChangeArmyText.text = this.GetArmsStr(Arms);
      this.m_ChangeArmyNumStr.ClearString();
      this.m_ChangeArmyNumStr.IntToFormat((long) MaxNum, bNumber: true);
      this.m_ChangeArmyNumStr.AppendFormat("{0}");
      this.m_ChangeArmyNumText.text = this.m_ChangeArmyNumStr.ToString();
      this.m_ChangeArmyNumText.SetAllDirty();
      this.m_ChangeArmyNumText.cachedTextGenerator.Invalidate();
    }
  }

  private void Despawn()
  {
    for (int index = this.m_Data.Count - 1; index >= 0; --index)
    {
      this.m_Data[index].Item[0].Type = (byte) 0;
      this.m_Data[index].Item[1].Type = (byte) 0;
      this.GM.m_HeroList_Soldier_ItemDataPool2.despawn(this.m_Data[index]);
    }
  }

  private void SetSkillHint(ushort heroID, byte enhance, int MaxNum, byte Arms)
  {
    byte[] numArray1 = new byte[5]
    {
      (byte) 1,
      (byte) 2,
      (byte) 4,
      (byte) 8,
      (byte) 20
    };
    Hero recordByKey1 = this.DM.HeroTable.GetRecordByKey(heroID);
    ushort[] numArray2 = new ushort[4]
    {
      recordByKey1.GroupSkill1,
      recordByKey1.GroupSkill2,
      recordByKey1.GroupSkill3,
      recordByKey1.GroupSkill4
    };
    CurHeroData curHeroData = this.DM.curHeroData[(uint) heroID];
    this.GM.ChangeHeroItemImg(((Component) this.m_HeroIcon).transform, eHeroOrItem.Hero, heroID, curHeroData.Star, (byte) 0);
    this.m_HeroNameText.text = this.DM.mStringTable.GetStringByID((uint) recordByKey1.HeroTitle);
    this.m_HeroArmsText.text = this.GetArmsStr(Arms);
    this.m_HeroEnhanceIcon.sprite = this.GetEnhanceIcon(enhance);
    this.m_HeroMaxNumStr.ClearString();
    StringManager.Instance.IntToFormat((long) MaxNum, bNumber: true);
    this.m_HeroMaxNumStr.AppendFormat("{0}");
    this.m_HeroMaxNum.text = this.m_HeroMaxNumStr.ToString();
    for (int idx = 0; idx < 4; ++idx)
    {
      Skill recordByKey2 = this.DM.SkillTable.GetRecordByKey(numArray2[idx]);
      CString SpriteName = StringManager.Instance.StaticString1024();
      SpriteName.ClearString();
      SpriteName.IntToFormat((long) recordByKey2.SkillIcon, 5);
      SpriteName.AppendFormat("s{0}");
      this.m_SkillImage[idx].sprite = this.GM.LoadSkillSprite(SpriteName);
      ((MaskableGraphic) this.m_SkillImage[idx]).material = this.GM.GetSkillMaterial();
      this.m_SkillFrame[idx].sprite = this.GM.LoadFrameSprite("sk");
      ((MaskableGraphic) this.m_SkillFrame[idx]).material = this.GM.GetFrameMaterial();
      this.m_SkliiNameText[idx].text = this.DM.mStringTable.GetStringByID((uint) recordByKey2.SkillName);
      this.m_SkillInfoStr[idx].ClearString();
      float mValue = (float) recordByKey2.HurtValue + (float) ((int) numArray1[(int) curHeroData.Star - 1] * (int) recordByKey2.HurtIncreaseValue) / 1000f;
      if (recordByKey2.HurtKind == (byte) 1)
      {
        GameConstants.GetEffectValue(this.m_SkillInfoStr[idx], recordByKey2.HurtAddition, 0U, (byte) 7, 0.0f);
        this.m_SkillInfoStr[idx].IntToFormat((long) ((int) numArray1[(int) curHeroData.Star - 1] * (int) recordByKey2.HurtIncreaseValue));
        this.m_SkillInfoStr[idx].AppendFormat("{0}");
        this.m_SkillInfoText[idx].text = this.m_SkillInfoStr[idx].ToString();
      }
      else
      {
        if (recordByKey2.SkillType == (byte) 10)
          GameConstants.GetEffectValue(this.m_SkillInfoStr[idx], recordByKey2.HurtAddition, (uint) mValue, (byte) 1, 0.0f);
        else
          GameConstants.GetEffectValue(this.m_SkillInfoStr[idx], recordByKey2.HurtAddition, 0U, (byte) 6, mValue * 100f);
        this.m_SkillInfoText[idx].text = this.m_SkillInfoStr[idx].ToString();
      }
      if (curHeroData.SkillLV[idx] == (byte) 0)
      {
        this.SetMaskColor(idx, true);
        this.m_SkillMaskTf[idx].gameObject.SetActive(true);
      }
      else
      {
        this.SetMaskColor(idx, false);
        this.m_SkillMaskTf[idx].gameObject.SetActive(false);
      }
    }
  }

  private void SetMaskColor(int idx, bool bDarkColor)
  {
    Color color1 = new Color(0.5f, 0.5f, 0.5f, 1f);
    Color color2 = new Color(1f, 1f, 1f, 1f);
    if (bDarkColor)
    {
      ((Graphic) this.m_SkillImage[idx]).color = color1;
      ((Graphic) this.m_SkillFrame[idx]).color = color1;
      ((Graphic) this.m_SkliiNameText[idx]).color = color1;
      ((Graphic) this.m_SkillInfoText[idx]).color = color1;
    }
    else
    {
      ((Graphic) this.m_SkillImage[idx]).color = color2;
      ((Graphic) this.m_SkillFrame[idx]).color = color2;
      ((Graphic) this.m_SkliiNameText[idx]).color = color2;
      ((Graphic) this.m_SkillInfoText[idx]).color = color2;
    }
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    int btnId1 = sender.transform.parent.GetComponent<UIButton>().m_BtnID1;
    int btnId3 = sender.transform.parent.GetComponent<UIButton>().m_BtnID3;
    this.SetSkillHint(this.m_Data[btnId1].Item[btnId3].HeroID, this.m_Data[btnId1].Item[btnId3].Enhance, (int) this.m_Data[btnId1].Item[btnId3].MaxNum, this.m_Data[btnId1].Item[btnId3].Arms);
    this.m_SkillHintPanel.gameObject.SetActive(true);
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    sender.bCountDown = false;
    sender.m_Time = 0.0f;
    this.m_SkillHintPanel.gameObject.SetActive(false);
  }
}
