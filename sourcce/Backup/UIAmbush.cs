// Decompiled with JetBrains decompiler
// Type: UIAmbush
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIAmbush : 
  GUIWindow,
  IUpDateScrollPanel,
  IUIButtonClickHandler,
  IUIButtonDownUpHandler,
  IUIHIBtnClickHandler
{
  private const int Max_Item = 16;
  private const float ScrollHeight = 527f;
  private const float TitleTypeHeight = 38f;
  private const float TextTypeHeight = 32f;
  private const float HeroTypeHeight = 111f;
  private Font m_TTF;
  private GUIManager GM;
  private AmbushManager AM;
  private DataManager DM;
  private Door m_Door;
  private RectTransform m_PlayerNameRect;
  private UIText m_UITitle;
  private UIText m_PlayerName;
  private UIText m_DismissText;
  private ScrollPanel m_ScrollPanel;
  private UIHIBtn m_PlayerIcon;
  private UIButton m_DismissBtn;
  private UIButton m_ExitBtn;
  private UIButton m_InfoBtn;
  private bool bInitScrollPanel;
  private sScrollItem[] m_sScrollItem;
  private List<sScrollItemData> m_Data;
  private List<float> m_ListHeight;
  private float m_TickTime;
  private bool bLeaderHero;
  private Image m_FlashImage;
  private UISpritesArray m_SpritesArray;

  public override void OnOpen(int arg1, int arg2)
  {
    this.m_TTF = GUIManager.Instance.GetTTFFont();
    this.GM = GUIManager.Instance;
    this.AM = AmbushManager.Instance;
    this.DM = DataManager.Instance;
    this.m_Door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.m_sScrollItem = new sScrollItem[16];
    for (int index = 0; index < this.m_sScrollItem.Length; ++index)
      this.m_sScrollItem[index].Init();
    this.m_Data = new List<sScrollItemData>();
    this.m_ListHeight = new List<float>();
    this.InitUI();
    this.SetData();
    this.IniteScrollPanel();
    this.SetAmbushPlayerName();
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
  }

  public override void OnClose()
  {
    if (this.m_sScrollItem == null)
      return;
    for (int index = 0; index < this.m_sScrollItem.Length; ++index)
    {
      if (this.m_sScrollItem[index].CStr != null)
      {
        StringManager.Instance.DeSpawnString(this.m_sScrollItem[index].CStr);
        this.m_sScrollItem[index].CStr = (CString) null;
      }
      if (this.m_sScrollItem[index].ArmyIconStr != null)
      {
        StringManager.Instance.DeSpawnString(this.m_sScrollItem[index].ArmyIconStr);
        this.m_sScrollItem[index].ArmyIconStr = (CString) null;
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    switch (arg1)
    {
      case 0:
        this.UpdateScrollPanel();
        this.SetAmbushPlayerName();
        break;
      case 1:
        if (!(bool) (Object) this.m_Door)
          break;
        this.m_Door.CloseMenu();
        break;
      case 2:
        this.SetAmbushPlayerHead();
        break;
      case 3:
        this.SetAmbushPlayerName();
        break;
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    NetworkNews networkNews = (NetworkNews) meg[0];
    switch (networkNews)
    {
      case NetworkNews.Login:
      case NetworkNews.Refresh:
        if (AmbushManager.Instance.GetMaxTroop() > 0U)
        {
          this.UpdateUI(0, 0);
          break;
        }
        this.UpdateUI(1, 0);
        break;
      default:
        if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
          break;
        this.Refresh_FontTexture();
        break;
    }
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK)
      return;
    this.AM.SendDismissAmbush();
  }

  private void Update()
  {
    if (!this.bLeaderHero || !((Object) this.m_FlashImage != (Object) null))
      return;
    this.m_TickTime += Time.smoothDeltaTime;
    if ((double) this.m_TickTime < 0.0)
      return;
    if ((double) this.m_TickTime >= 2.0)
      this.m_TickTime = 0.0f;
    ((Graphic) this.m_FlashImage).color = new Color(1f, 1f, 1f, (double) this.m_TickTime <= 1.0 ? this.m_TickTime : 2f - this.m_TickTime);
  }

  private void InitUI()
  {
    this.m_SpritesArray = this.transform.GetComponent<UISpritesArray>();
    this.m_UITitle = this.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<UIText>();
    this.m_UITitle.font = this.m_TTF;
    this.m_UITitle.text = this.DM.mStringTable.GetStringByID(9726U);
    this.m_ScrollPanel = this.transform.GetChild(1).GetComponent<ScrollPanel>();
    this.m_PlayerIcon = this.transform.GetChild(3).GetComponent<UIHIBtn>();
    this.m_PlayerIcon.m_Handler = (IUIHIBtnClickHandler) this;
    this.GM.InitianHeroItemImg(((Component) this.m_PlayerIcon).transform, eHeroOrItem.Hero, this.AM.m_AmbushPlayerHead, (byte) 11, (byte) 0, bShowText: false, bAutoShowHint: false);
    this.m_DismissBtn = this.transform.GetChild(6).GetComponent<UIButton>();
    this.m_DismissBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_DismissBtn.m_BtnID1 = 1;
    this.m_DismissText = this.transform.GetChild(6).GetChild(0).GetComponent<UIText>();
    this.m_DismissText.font = this.m_TTF;
    this.m_DismissText.text = this.DM.mStringTable.GetStringByID(9727U);
    this.m_InfoBtn = this.transform.GetChild(7).GetComponent<UIButton>();
    this.m_InfoBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_InfoBtn.m_BtnID1 = 3;
    this.transform.GetChild(7).gameObject.AddComponent<ArabicItemTextureRot>();
    Image component1 = this.transform.GetChild(5).GetComponent<Image>();
    if ((bool) (Object) this.m_Door)
    {
      component1.sprite = this.m_Door.LoadSprite("UI_main_close_base");
      ((MaskableGraphic) component1).material = this.m_Door.LoadMaterial();
    }
    this.m_ExitBtn = this.transform.GetChild(5).GetChild(0).GetComponent<UIButton>();
    this.m_ExitBtn.m_Handler = (IUIButtonClickHandler) this;
    this.m_ExitBtn.m_BtnID1 = 0;
    if ((bool) (Object) this.m_Door)
    {
      this.m_ExitBtn.image.sprite = this.m_Door.LoadSprite("UI_main_close");
      ((MaskableGraphic) this.m_ExitBtn.image).material = this.m_Door.LoadMaterial();
    }
    this.m_PlayerNameRect = this.transform.GetChild(4).GetComponent<RectTransform>();
    this.m_PlayerName = this.transform.GetChild(4).GetChild(1).GetComponent<UIText>();
    this.m_PlayerName.font = this.m_TTF;
    UIButton component2 = this.transform.GetChild(4).GetComponent<UIButton>();
    component2.m_Handler = (IUIButtonClickHandler) this;
    component2.m_BtnID1 = 2;
  }

  private void SetData()
  {
    this.m_Data.Clear();
    this.m_ListHeight.Clear();
    uint num = 0;
    bool flag = false;
    sScrollItemData sScrollItemData1 = new sScrollItemData();
    int[] numArray1 = new int[4]{ 0, 4, 8, 12 };
    int[] numArray2 = new int[4]{ 3, 7, 11, 15 };
    sScrollItemData sScrollItemData2;
    for (int index1 = 0; index1 < 4; ++index1)
    {
      for (int index2 = numArray2[index1]; index2 >= numArray1[index1]; --index2)
      {
        if (this.AM.m_TroopData[index2] > 0U)
        {
          sScrollItemData2 = new sScrollItemData();
          sScrollItemData2.Type = eItem.TextType;
          sScrollItemData2.ArmyIdx = index2;
          sScrollItemData2.ArmyNum = this.AM.m_TroopData[index2];
          sScrollItemData2.Height = 32f;
          num += sScrollItemData2.ArmyNum;
          this.m_Data.Add(sScrollItemData2);
        }
      }
    }
    sScrollItemData2 = new sScrollItemData();
    sScrollItemData2.Type = eItem.TitleType;
    sScrollItemData2.Height = 38f;
    sScrollItemData2.StrID = (ushort) 9728;
    sScrollItemData2.StrID_Value = (ushort) 4010;
    sScrollItemData2.StrNum = num;
    this.m_Data.Insert(0, sScrollItemData2);
    for (int index = 0; index < 5; ++index)
    {
      if (this.AM.m_HeroInfo[index].HeroID != (ushort) 0)
        flag = true;
    }
    if (flag)
    {
      sScrollItemData2 = new sScrollItemData();
      sScrollItemData2.Type = eItem.TitleType;
      sScrollItemData2.Height = 38f;
      sScrollItemData2.StrID = (ushort) 4019;
      sScrollItemData2.StrID_Value = (ushort) 4011;
      sScrollItemData2.StrNum = 0U;
      for (int index = 0; index < 5; ++index)
      {
        if (this.AM.m_HeroInfo[index].HeroID != (ushort) 0)
        {
          ++sScrollItemData2.StrNum;
          if ((int) this.AM.m_HeroInfo[index].HeroID == (int) this.AM.m_AmbushPlayerHead)
            this.bLeaderHero = true;
        }
      }
      this.m_Data.Add(sScrollItemData2);
      sScrollItemData2 = new sScrollItemData();
      sScrollItemData2.Type = eItem.HeroType;
      sScrollItemData2.Height = 111f;
      this.m_Data.Add(sScrollItemData2);
    }
    for (int index = 0; index < this.m_Data.Count; ++index)
      this.m_ListHeight.Add(this.m_Data[index].Height);
  }

  private void IniteScrollPanel()
  {
    this.m_ScrollPanel.IntiScrollPanel(527f, 0.0f, 6f, this.m_ListHeight, 16, (IUpDateScrollPanel) this);
    this.bInitScrollPanel = true;
    if (!((Object) this.m_ScrollPanel != (Object) null))
      return;
    UIButtonHint.scrollRect = this.m_ScrollPanel.gameObject.GetComponent<CScrollRect>();
  }

  private void UpdateScrollPanel()
  {
    this.SetData();
    this.m_ScrollPanel.AddNewDataHeight(this.m_ListHeight, false);
  }

  private void SetAmbushPlayerName()
  {
    if ((Object) this.m_PlayerName == (Object) null)
      return;
    this.m_PlayerName.text = this.AM.m_AmbushPlayerName.ToString();
    this.m_PlayerName.SetAllDirty();
    this.m_PlayerName.cachedTextGenerator.Invalidate();
    this.m_PlayerName.cachedTextGeneratorForLayout.Invalidate();
    Vector2 sizeDelta = ((Graphic) this.m_PlayerName).rectTransform.sizeDelta with
    {
      x = (double) this.m_PlayerName.preferredWidth >= 245.0 ? 245f : this.m_PlayerName.preferredWidth
    };
    ((Graphic) this.m_PlayerName).rectTransform.sizeDelta = sizeDelta;
    sizeDelta = this.m_PlayerNameRect.sizeDelta with
    {
      x = (double) this.m_PlayerName.preferredWidth >= 245.0 ? 245f : this.m_PlayerName.preferredWidth
    };
    this.m_PlayerNameRect.sizeDelta = sizeDelta;
  }

  private void SetAmbushPlayerHead()
  {
    if ((Object) this.m_PlayerIcon == (Object) null)
      return;
    this.GM.ChangeHeroItemImg(((Component) this.m_PlayerIcon).transform, eHeroOrItem.Hero, this.AM.m_AmbushPlayerHead, (byte) 11, (byte) 0);
  }

  private void SetScrollItem(GameObject item, int panelObjectIdx, int dataIdx)
  {
    item.transform.GetChild(0).gameObject.SetActive(false);
    item.transform.GetChild(1).gameObject.SetActive(false);
    item.transform.GetChild(2).gameObject.SetActive(false);
    if (dataIdx >= this.m_Data.Count || panelObjectIdx >= 16)
      return;
    switch (this.m_Data[dataIdx].Type)
    {
      case eItem.TitleType:
        item.transform.GetChild(0).gameObject.SetActive(true);
        this.SetTitleType(this.m_sScrollItem[panelObjectIdx], dataIdx);
        break;
      case eItem.TextType:
        item.transform.GetChild(1).gameObject.SetActive(true);
        this.SetTextType(this.m_sScrollItem[panelObjectIdx], dataIdx);
        break;
      case eItem.HeroType:
        item.transform.GetChild(2).gameObject.SetActive(true);
        this.SetHeroType(this.m_sScrollItem[panelObjectIdx], dataIdx);
        break;
    }
  }

  private void SetTitleType(sScrollItem item, int dataIdx)
  {
    if (dataIdx >= this.m_Data.Count)
      return;
    item.TitleType.Text1.text = this.DM.mStringTable.GetStringByID((uint) this.m_Data[dataIdx].StrID);
    item.CStr.ClearString();
    item.CStr.StringToFormat(this.DM.mStringTable.GetStringByID((uint) this.m_Data[dataIdx].StrID_Value));
    item.CStr.IntToFormat((long) this.m_Data[dataIdx].StrNum, bNumber: true);
    item.CStr.AppendFormat("{0}{1}");
    item.TitleType.Text2.text = item.CStr.ToString();
  }

  private void SetTextType(sScrollItem item, int dataIdx)
  {
    int ArmyIdx = 0;
    if (dataIdx < this.m_Data.Count && dataIdx >= 0)
      ArmyIdx = this.m_Data[dataIdx].ArmyIdx;
    item.TextType.Text1.text = this.DM.mStringTable.GetStringByID((uint) this.GetArmyStringID(ArmyIdx));
    item.CStr.ClearString();
    item.CStr.IntToFormat((long) this.m_Data[dataIdx].ArmyNum, bNumber: true);
    item.CStr.AppendFormat("{0}");
    item.TextType.Text2.text = item.CStr.ToString();
    this.SetArmyIcon(item.TextType.IconImage, ArmyIdx, item.TextType.iconText, item.ArmyIconStr, item.TextType.Hint, item.TextType.BackgroundImage, item.TextType.Text1.preferredWidth);
    item.TextType.Text1.alignment = TextAnchor.MiddleLeft;
    item.TextType.Text2.alignment = TextAnchor.MiddleRight;
  }

  private void SetHeroType(sScrollItem item, int dataIdx)
  {
    for (int index = 0; index < 5; ++index)
    {
      if (this.AM.m_HeroInfo[index].HeroID != (ushort) 0)
      {
        Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(this.AM.m_HeroInfo[index].HeroID);
        item.HeroType.HeroImage[index].sprite = this.GM.m_IconSpriteAsset.LoadSprite(recordByKey.Graph);
        ((MaskableGraphic) item.HeroType.HeroImage[index]).material = this.GM.m_IconSpriteAsset.GetMaterial();
        if ((Object) item.HeroType.HeroImage[index].sprite == (Object) null)
        {
          item.HeroType.HeroImage[index].sprite = this.GM.m_ItemIconSpriteAsset.LoadSprite((ushort) 1130);
          ((MaskableGraphic) item.HeroType.HeroImage[index]).material = this.GM.m_ItemIconSpriteAsset.GetMaterial();
        }
        ((MaskableGraphic) item.HeroType.FrameImage[index]).material = this.GM.GetFrameMaterial();
        if (this.AM.m_HeroInfo[index].Star != (byte) 0)
          item.HeroType.FrameImage[index].sprite = this.GM.LoadFrameSprite(EFrameSprite.Hero, this.AM.m_HeroInfo[index].Star);
        if (this.AM.m_HeroInfo[index].Rank != (byte) 0)
          item.HeroType.RankImage[index].sprite = this.GM.LoadFrameSprite(EFrameSprite.Hero, (byte) ((uint) this.AM.m_HeroInfo[index].Rank + 100U));
        ((MaskableGraphic) item.HeroType.RankImage[index]).material = this.GM.GetFrameMaterial();
        if (index == 0)
        {
          if (this.bLeaderHero)
          {
            ((Behaviour) item.HeroType.LordsIcon1).enabled = true;
            ((Behaviour) item.HeroType.LordsIcon2).enabled = true;
          }
          else
          {
            ((Behaviour) item.HeroType.LordsIcon1).enabled = false;
            ((Behaviour) item.HeroType.LordsIcon2).enabled = false;
          }
          this.m_FlashImage = item.HeroType.LordsIcon2;
        }
        item.HeroType.Tf[index].gameObject.SetActive(true);
      }
      else
        item.HeroType.Tf[index].gameObject.SetActive(false);
    }
  }

  public ushort GetArmyStringID(int ArmyIdx)
  {
    return this.DM.SoldierDataTable.GetRecordByKey((ushort) (ArmyIdx + 1)).Name;
  }

  public void SetArmyIcon(
    Image image,
    int ArmyIdx,
    UIText IconText,
    CString str,
    UIButtonHint hint,
    Image background,
    float textWidth)
  {
    if ((Object) background == (Object) null || (Object) image == (Object) null || (Object) this.m_SpritesArray == (Object) null)
      return;
    Vector2 sizeDelta = ((Graphic) background).rectTransform.sizeDelta with
    {
      x = (double) textWidth <= 238.39999389648438 ? textWidth + 40f : 278.4f
    };
    ((Graphic) background).rectTransform.sizeDelta = sizeDelta;
    SoldierData recordByKey = this.DM.SoldierDataTable.GetRecordByKey((ushort) (ArmyIdx + 1));
    image.sprite = this.m_SpritesArray.GetSprite((int) recordByKey.SoldierKind);
    str.ClearString();
    str.IntToFormat((long) recordByKey.Tier);
    str.AppendFormat("{0}");
    IconText.text = str.ToString();
    hint.Parm1 = (ushort) ArmyIdx;
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (panelObjectIdx < 16 && !this.m_sScrollItem[panelObjectIdx].bInit)
    {
      this.m_sScrollItem[panelObjectIdx].TitleType.Text1 = item.transform.GetChild(0).GetChild(0).GetComponent<UIText>();
      this.m_sScrollItem[panelObjectIdx].TitleType.Text2 = item.transform.GetChild(0).GetChild(1).GetComponent<UIText>();
      this.m_sScrollItem[panelObjectIdx].TitleType.Text1.font = this.m_TTF;
      this.m_sScrollItem[panelObjectIdx].TitleType.Text2.font = this.m_TTF;
      this.m_sScrollItem[panelObjectIdx].TextType.Text1 = item.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
      this.m_sScrollItem[panelObjectIdx].TextType.Text2 = item.transform.GetChild(1).GetChild(1).GetComponent<UIText>();
      this.m_sScrollItem[panelObjectIdx].TextType.Text1.font = this.m_TTF;
      this.m_sScrollItem[panelObjectIdx].TextType.Text2.font = this.m_TTF;
      this.m_sScrollItem[panelObjectIdx].TextType.Hint = item.transform.GetChild(1).GetChild(2).gameObject.AddComponent<UIButtonHint>();
      this.m_sScrollItem[panelObjectIdx].TextType.Hint.m_eHint = EUIButtonHint.CountDown;
      this.m_sScrollItem[panelObjectIdx].TextType.Hint.DelayTime = 0.2f;
      this.m_sScrollItem[panelObjectIdx].TextType.Hint.m_Handler = (MonoBehaviour) this;
      this.m_sScrollItem[panelObjectIdx].TextType.Hint.Parm1 = (ushort) 0;
      this.m_sScrollItem[panelObjectIdx].TextType.BackgroundImage = item.transform.GetChild(1).GetChild(2).GetComponent<Image>();
      this.m_sScrollItem[panelObjectIdx].TextType.IconImage = item.transform.GetChild(1).GetChild(2).GetChild(0).GetComponent<Image>();
      this.m_sScrollItem[panelObjectIdx].TextType.iconText = item.transform.GetChild(1).GetChild(2).GetChild(1).GetComponent<UIText>();
      this.m_sScrollItem[panelObjectIdx].TextType.iconText.font = this.m_TTF;
      for (int index = 0; index < 5; ++index)
      {
        this.m_sScrollItem[panelObjectIdx].HeroType.Tf[index] = item.transform.GetChild(2).GetChild(index);
        this.m_sScrollItem[panelObjectIdx].HeroType.FrameImage[index] = item.transform.GetChild(2).GetChild(index).GetChild(1).GetComponent<Image>();
        this.m_sScrollItem[panelObjectIdx].HeroType.HeroImage[index] = item.transform.GetChild(2).GetChild(index).GetChild(0).GetComponent<Image>();
        this.m_sScrollItem[panelObjectIdx].HeroType.RankImage[index] = item.transform.GetChild(2).GetChild(index).GetChild(2).GetComponent<Image>();
        if (index == 0)
        {
          this.m_sScrollItem[panelObjectIdx].HeroType.LordsIcon1 = item.transform.GetChild(2).GetChild(index).GetChild(3).GetComponent<Image>();
          this.m_sScrollItem[panelObjectIdx].HeroType.LordsIcon2 = item.transform.GetChild(2).GetChild(index).GetChild(4).GetComponent<Image>();
        }
      }
      this.m_sScrollItem[panelObjectIdx].bInit = true;
    }
    this.SetScrollItem(item, panelObjectIdx, dataIdx);
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  public void OnButtonClick(UIButton sender)
  {
    switch (sender.m_BtnID1)
    {
      case 0:
        if (!(bool) (Object) this.m_Door)
          break;
        this.m_Door.CloseMenu();
        break;
      case 1:
        this.GM.OpenOKCancelBox((GUIWindow) this, this.DM.mStringTable.GetStringByID(9759U), this.DM.mStringTable.GetStringByID(9729U), YesText: this.DM.mStringTable.GetStringByID(4842U), NoText: this.DM.mStringTable.GetStringByID(4843U));
        break;
      case 2:
        if (!(bool) (Object) this.m_Door)
          break;
        this.m_Door.GoToPointCode(DataManager.MapDataController.OtherKingdomData.kingdomID, this.AM.m_AmbushPlayerCapitalPos.zoneID, this.AM.m_AmbushPlayerCapitalPos.pointID, (byte) 0);
        break;
      case 3:
        GUIManager.Instance.OpenMessageBoxEX(DataManager.Instance.mStringTable.GetStringByID(9129U), DataManager.Instance.mStringTable.GetStringByID(9768U), bInfo: true);
        break;
    }
  }

  public void OnHIButtonClick(UIHIBtn sender)
  {
    this.m_Door.GoToPointCode(DataManager.MapDataController.OtherKingdomData.kingdomID, this.AM.m_AmbushPlayerCapitalPos.zoneID, this.AM.m_AmbushPlayerCapitalPos.pointID, (byte) 0);
  }

  public void OnButtonDown(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Show(sender, UIHintStyle.eHintSimple, (byte) 3, 277f, 20, (int) sender.Parm1, 0, new Vector2(70f, 0.0f));
  }

  public void OnButtonUp(UIButtonHint sender)
  {
    GUIManager.Instance.m_Hint.Hide((bool) (Object) sender);
  }

  public void Refresh_FontTexture()
  {
    if ((Object) this.m_UITitle != (Object) null && ((Behaviour) this.m_UITitle).enabled)
    {
      ((Behaviour) this.m_UITitle).enabled = false;
      ((Behaviour) this.m_UITitle).enabled = true;
    }
    if ((Object) this.m_PlayerName != (Object) null && ((Behaviour) this.m_PlayerName).enabled)
    {
      ((Behaviour) this.m_PlayerName).enabled = false;
      ((Behaviour) this.m_PlayerName).enabled = true;
    }
    if ((Object) this.m_DismissText != (Object) null && ((Behaviour) this.m_DismissText).enabled)
    {
      ((Behaviour) this.m_DismissText).enabled = false;
      ((Behaviour) this.m_DismissText).enabled = true;
    }
    if (this.m_sScrollItem == null)
      return;
    for (int index = 0; index < this.m_sScrollItem.Length; ++index)
    {
      if ((Object) this.m_sScrollItem[index].TitleType.Text1 != (Object) null && ((Behaviour) this.m_sScrollItem[index].TitleType.Text1).enabled)
      {
        ((Behaviour) this.m_sScrollItem[index].TitleType.Text1).enabled = false;
        ((Behaviour) this.m_sScrollItem[index].TitleType.Text1).enabled = true;
      }
      if ((Object) this.m_sScrollItem[index].TitleType.Text2 != (Object) null && ((Behaviour) this.m_sScrollItem[index].TitleType.Text2).enabled)
      {
        ((Behaviour) this.m_sScrollItem[index].TitleType.Text2).enabled = false;
        ((Behaviour) this.m_sScrollItem[index].TitleType.Text2).enabled = true;
      }
      if ((Object) this.m_sScrollItem[index].TextType.Text1 != (Object) null && ((Behaviour) this.m_sScrollItem[index].TextType.Text1).enabled)
      {
        ((Behaviour) this.m_sScrollItem[index].TextType.Text1).enabled = false;
        ((Behaviour) this.m_sScrollItem[index].TextType.Text1).enabled = true;
      }
      if ((Object) this.m_sScrollItem[index].TextType.Text2 != (Object) null && ((Behaviour) this.m_sScrollItem[index].TextType.Text2).enabled)
      {
        ((Behaviour) this.m_sScrollItem[index].TextType.Text2).enabled = false;
        ((Behaviour) this.m_sScrollItem[index].TextType.Text2).enabled = true;
      }
      if ((Object) this.m_sScrollItem[index].TextType.iconText != (Object) null && ((Behaviour) this.m_sScrollItem[index].TextType.iconText).enabled)
      {
        ((Behaviour) this.m_sScrollItem[index].TextType.iconText).enabled = false;
        ((Behaviour) this.m_sScrollItem[index].TextType.iconText).enabled = true;
      }
    }
  }
}
