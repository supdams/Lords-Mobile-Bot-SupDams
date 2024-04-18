// Decompiled with JetBrains decompiler
// Type: UILanguageSelect
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UILanguageSelect : 
  GUIWindow,
  UILoadImageHander,
  IUpDateScrollPanel,
  IUIButtonClickHandler
{
  private const byte TotalLanguageCount = 42;
  private ScrollPanel Scroll;
  private List<float> ItemsHeight = new List<float>();
  private byte CurSelIndex;
  private byte ProtocolType;
  private UIText[] RefreshText = new UIText[3];
  private RectTransform ScrollRect;
  private CString TitleStr;
  private byte[] LangueIDTable = new byte[42]
  {
    (byte) 1,
    (byte) 7,
    (byte) 12,
    (byte) 15,
    (byte) 16,
    (byte) 33,
    (byte) 37,
    (byte) 21,
    (byte) 42,
    (byte) 40,
    (byte) 39,
    (byte) 22,
    (byte) 31,
    (byte) 24,
    (byte) 23,
    (byte) 41,
    (byte) 27,
    (byte) 2,
    (byte) 3,
    (byte) 4,
    (byte) 5,
    (byte) 6,
    (byte) 8,
    (byte) 9,
    (byte) 10,
    (byte) 11,
    (byte) 13,
    (byte) 14,
    (byte) 17,
    (byte) 18,
    (byte) 19,
    (byte) 20,
    (byte) 25,
    (byte) 26,
    (byte) 28,
    (byte) 29,
    (byte) 30,
    (byte) 32,
    (byte) 34,
    (byte) 35,
    (byte) 36,
    (byte) 38
  };
  private ushort[] TranslationLangueIDTable = new ushort[44]
  {
    (ushort) 4413,
    (ushort) 4425,
    (ushort) 12,
    (ushort) 15,
    (ushort) 16,
    (ushort) 33,
    (ushort) 37,
    (ushort) 4424,
    (ushort) 21,
    (ushort) 42,
    (ushort) 40,
    (ushort) 39,
    (ushort) 22,
    (ushort) 31,
    (ushort) 24,
    (ushort) 2,
    (ushort) 3,
    (ushort) 4,
    (ushort) 5,
    (ushort) 6,
    (ushort) 8,
    (ushort) 9,
    (ushort) 10,
    (ushort) 11,
    (ushort) 13,
    (ushort) 14,
    (ushort) 17,
    (ushort) 18,
    (ushort) 19,
    (ushort) 20,
    (ushort) 23,
    (ushort) 25,
    (ushort) 26,
    (ushort) 27,
    (ushort) 28,
    (ushort) 29,
    (ushort) 30,
    (ushort) 32,
    (ushort) 34,
    (ushort) 35,
    (ushort) 36,
    (ushort) 38,
    (ushort) 41,
    (ushort) 4403
  };
  private UILanguageSelect.ItemEdit[] ScrollItem;
  private byte ItemCount = 9;
  private UISpritesArray SpriteArray;
  private string[] mLanguage = new string[18];
  private int tmpLanguageIdx = -1;
  private int mLanguageCount;
  private ulong tmpLanguageTranslation;
  private bool bLangueage = true;
  private bool bAllSet = true;

  public override void OnOpen(int arg1, int arg2)
  {
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    DataManager instance = DataManager.Instance;
    this.ProtocolType = (byte) arg1;
    this.CurSelIndex = instance.CurSelectLanguage;
    this.TitleStr = StringManager.Instance.SpawnString();
    switch (DataManager.Instance.UserLanguage)
    {
      case GameLanguage.GL_Eng:
        this.tmpLanguageIdx = 1;
        break;
      case GameLanguage.GL_Cht:
        this.tmpLanguageIdx = 0;
        break;
      case GameLanguage.GL_Fre:
        this.tmpLanguageIdx = 2;
        break;
      case GameLanguage.GL_Gem:
        this.tmpLanguageIdx = 3;
        break;
      case GameLanguage.GL_Spa:
        this.tmpLanguageIdx = 5;
        break;
      case GameLanguage.GL_Rus:
        this.tmpLanguageIdx = 4;
        break;
      case GameLanguage.GL_Chs:
        this.tmpLanguageIdx = 6;
        break;
      case GameLanguage.GL_Idn:
        this.tmpLanguageIdx = 7;
        break;
      case GameLanguage.GL_Vet:
        this.tmpLanguageIdx = 8;
        break;
      case GameLanguage.GL_Tur:
        this.tmpLanguageIdx = 9;
        break;
      case GameLanguage.GL_Tha:
        this.tmpLanguageIdx = 10;
        break;
      case GameLanguage.GL_Ita:
        this.tmpLanguageIdx = 11;
        break;
      case GameLanguage.GL_Pot:
        this.tmpLanguageIdx = 12;
        break;
      case GameLanguage.GL_Kor:
        this.tmpLanguageIdx = 13;
        break;
      case GameLanguage.GL_Jpn:
        this.tmpLanguageIdx = 14;
        break;
      case GameLanguage.GL_Ukr:
        this.tmpLanguageIdx = 15;
        break;
      case GameLanguage.GL_Mys:
        this.tmpLanguageIdx = 16;
        break;
      case GameLanguage.GL_Arb:
        this.tmpLanguageIdx = 17;
        break;
    }
    GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    this.RefreshText[0] = this.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
    this.RefreshText[0].font = ttfFont;
    this.RefreshText[2] = this.transform.GetChild(2).GetChild(0).GetComponent<UIText>();
    this.RefreshText[2].font = ttfFont;
    this.RefreshText[0].text = this.ProtocolType >= (byte) 2 ? (this.ProtocolType != (byte) 3 ? instance.mStringTable.GetStringByID(9016U) : instance.mStringTable.GetStringByID(9050U)) : instance.mStringTable.GetStringByID(4649U);
    Image component1 = this.transform.GetChild(6).GetComponent<Image>();
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (GUIManager.Instance.bOpenOnIPhoneX)
    {
      ((Behaviour) component1).enabled = false;
    }
    else
    {
      component1.sprite = menu.LoadSprite("UI_main_close_base");
      ((MaskableGraphic) component1).material = menu.LoadMaterial();
    }
    Image component2 = this.transform.GetChild(6).GetChild(0).GetComponent<Image>();
    component2.sprite = menu.LoadSprite("UI_main_close");
    ((MaskableGraphic) component2).material = menu.LoadMaterial();
    UIButton component3 = this.transform.GetChild(6).GetChild(0).GetComponent<UIButton>();
    component3.m_BtnID1 = 0;
    component3.m_Handler = (IUIButtonClickHandler) this;
    UIButton component4 = this.transform.GetChild(3).GetComponent<UIButton>();
    component4.m_Handler = (IUIButtonClickHandler) this;
    component4.m_BtnID1 = 1;
    this.RefreshText[1] = this.transform.GetChild(3).GetChild(0).GetComponent<UIText>();
    this.RefreshText[1].font = ttfFont;
    this.ScrollRect = this.transform.GetChild(4).GetComponent<RectTransform>();
    if (this.ProtocolType < (byte) 2)
      this.RefreshText[1].text = instance.mStringTable.GetStringByID(4650U);
    else if (this.ProtocolType == (byte) 3)
    {
      this.ScrollRect.anchoredPosition = new Vector2(4.5f, -39f);
      this.ScrollRect.sizeDelta = new Vector2(805f, 364f);
      this.RefreshText[1].text = instance.mStringTable.GetStringByID(3U);
      this.transform.GetChild(2).gameObject.SetActive(true);
      this.RefreshText[2].text = instance.mStringTable.GetStringByID(9051U);
      this.tmpLanguageTranslation = instance.MySysSetting.mLanguageTranslation;
      this.bLangueage = instance.MySysSetting.bLanguageOther;
      this.bAllSet = this.tmpLanguageTranslation == ulong.MaxValue && this.bLangueage;
    }
    else
    {
      this.RefreshText[1].text = instance.mStringTable.GetStringByID(3U);
      for (int index = 0; index < 6; ++index)
        this.mLanguage[index] = instance.mStringTable.GetStringByID((uint) (9017 + index));
      this.mLanguage[6] = instance.mStringTable.GetStringByID(9045U);
      this.mLanguage[7] = instance.mStringTable.GetStringByID(9056U);
      this.mLanguage[8] = instance.mStringTable.GetStringByID(9057U);
      this.mLanguage[9] = instance.mStringTable.GetStringByID(9060U);
      this.mLanguage[10] = instance.mStringTable.GetStringByID(9055U);
      this.mLanguage[11] = instance.mStringTable.GetStringByID(9058U);
      this.mLanguage[12] = instance.mStringTable.GetStringByID(9059U);
      this.mLanguage[13] = instance.mStringTable.GetStringByID(9061U);
      this.mLanguage[14] = instance.mStringTable.GetStringByID(9100U);
      this.mLanguage[15] = instance.mStringTable.GetStringByID(9519U);
      this.mLanguage[16] = instance.mStringTable.GetStringByID(9520U);
      this.mLanguage[17] = instance.mStringTable.GetStringByID(9504U);
      if (!GUIManager.Instance.IsArabic)
      {
        string str = this.mLanguage[17];
        if (ArabicTransfer.Instance.IsArabicStr(str))
        {
          ArabicTransfer.Instance.Transfer(str, this.TitleStr);
          this.mLanguage[17] = this.TitleStr.ToString();
        }
      }
    }
    Transform child = this.transform.GetChild(5);
    child.GetChild(0).GetComponent<UIText>().font = ttfFont;
    if (GUIManager.Instance.IsArabic)
      ((Transform) child.GetChild(1).GetChild(0).GetComponent<RectTransform>()).localScale = new Vector3(-1f, 1f, 1f);
    this.Scroll = this.transform.GetChild(4).GetComponent<ScrollPanel>();
    this.SpriteArray = this.transform.GetChild(4).GetComponent<UISpritesArray>();
    this.ScrollItem = new UILanguageSelect.ItemEdit[(int) this.ItemCount];
    for (byte index = 0; (int) index < (int) this.ItemCount; ++index)
      this.ItemsHeight.Add(66f);
    this.Scroll.IntiScrollPanel(435f, 0.0f, 0.0f, this.ItemsHeight, (int) this.ItemCount, (IUpDateScrollPanel) this);
  }

  public void OnButtonClick(UIButton sender)
  {
    if (sender.m_BtnID1 == 1 && this.ProtocolType == (byte) 1 && (int) this.CurSelIndex == (int) DataManager.Instance.CurSelectLanguage)
    {
      GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(707U), (ushort) byte.MaxValue);
    }
    else
    {
      if (sender.m_BtnID1 == 1)
      {
        if (this.ProtocolType < (byte) 2)
          DataManager.Instance.CurSelectLanguage = this.CurSelIndex;
        else if (this.ProtocolType == (byte) 3)
        {
          DataManager.Instance.MySysSetting.mLanguageTranslation = this.tmpLanguageTranslation;
          DataManager.Instance.MySysSetting.bLanguageOther = this.bLangueage;
          PlayerPrefs.SetString("Other_LanguageTranslation", DataManager.Instance.MySysSetting.mLanguageTranslation.ToString());
          PlayerPrefs.SetString("Other_LanguageOther", DataManager.Instance.MySysSetting.bLanguageOther.ToString());
          DataManager.Instance.ClearAllHeight();
        }
        else if (this.tmpLanguageIdx >= 0)
        {
          byte num = 0;
          switch (this.tmpLanguageIdx)
          {
            case 0:
              num = (byte) 2;
              break;
            case 1:
              num = (byte) 1;
              break;
            case 2:
              num = (byte) 3;
              break;
            case 3:
              num = (byte) 4;
              break;
            case 4:
              num = (byte) 6;
              break;
            case 5:
              num = (byte) 5;
              break;
            case 6:
              num = (byte) 7;
              break;
            case 7:
              num = (byte) 8;
              break;
            case 8:
              num = (byte) 9;
              break;
            case 9:
              num = (byte) 10;
              break;
            case 10:
              num = (byte) 11;
              break;
            case 11:
              num = (byte) 12;
              break;
            case 12:
              num = (byte) 13;
              break;
            case 13:
              num = (byte) 14;
              break;
            case 14:
              num = (byte) 15;
              break;
            case 15:
              num = (byte) 16;
              break;
            case 16:
              num = (byte) 17;
              break;
            case 17:
              num = (byte) 18;
              break;
          }
          if ((GameLanguage) num == DataManager.Instance.UserLanguage)
          {
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(9024U), (ushort) byte.MaxValue);
            return;
          }
          DataManager.Instance.MySysSetting.mUserLanguage = num;
          PlayerPrefs.SetString("Other_Language", DataManager.Instance.MySysSetting.mUserLanguage.ToString());
          IGGSDKPlugin.NotificationUninitialize();
          UpdateController.OnExit(9023U);
        }
      }
      Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
      if (!(bool) (Object) menu)
        return;
      menu.CloseMenu();
    }
  }

  public override void OnClose()
  {
    StringManager.Instance.DeSpawnString(this.TitleStr);
    DataManager instance = DataManager.Instance;
    if (this.ProtocolType != (byte) 1 || (int) instance.RoleAlliance.Language == (int) instance.CurSelectLanguage || !GUIManager.Instance.ShowUILock(EUILock.Alliance_Manage))
      return;
    MessagePacket messagePacket = new MessagePacket((ushort) 1024);
    messagePacket.Protocol = Protocol._MSG_REQUEST_ALLIANCE_MODIFY_LANGUAGE;
    messagePacket.AddSeqId();
    messagePacket.Add(instance.CurSelectLanguage);
    messagePacket.Send();
  }

  public bool CheckShowbyIdx(int Idx)
  {
    bool flag = false;
    int num = 0;
    switch (Idx)
    {
      case 0:
        num = 256;
        flag = this.bAllSet;
        break;
      case 1:
        num = 5;
        break;
      case 2:
        num = 10;
        break;
      case 3:
        num = 13;
        break;
      case 4:
        num = 14;
        break;
      case 5:
        num = 31;
        break;
      case 6:
        num = 35;
        break;
      case 7:
        num = 41;
        break;
      case 8:
        num = 19;
        break;
      case 9:
        num = 40;
        break;
      case 10:
        num = 38;
        break;
      case 11:
        num = 37;
        break;
      case 12:
        num = 20;
        break;
      case 13:
        num = 29;
        break;
      case 14:
        num = 22;
        break;
      case 15:
      case 16:
      case 17:
      case 18:
      case 19:
        num = Idx - 15;
        break;
      case 20:
      case 21:
      case 22:
      case 23:
        num = Idx - 14;
        break;
      case 24:
      case 25:
        num = Idx - 13;
        break;
      case 26:
      case 27:
      case 28:
      case 29:
        num = Idx - 11;
        break;
      case 30:
        num = 21;
        break;
      case 31:
      case 32:
      case 33:
      case 34:
      case 35:
      case 36:
        num = Idx - 8;
        break;
      case 37:
        num = 30;
        break;
      case 38:
      case 39:
      case 40:
        num = Idx - 6;
        break;
      case 41:
        num = 36;
        break;
      case 42:
        num = 39;
        break;
      case 43:
        num = (int) byte.MaxValue;
        flag = this.bLangueage;
        break;
    }
    if (num < (int) byte.MaxValue)
      flag = ((long) (this.tmpLanguageTranslation >> num) & 1L) == 1L;
    return flag;
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if ((Object) this.ScrollItem[panelObjectIdx].Title == (Object) null)
    {
      Transform transform = item.transform;
      transform.GetComponent<ScrollPanelItem>().m_BtnID2 = panelObjectIdx;
      this.ScrollItem[panelObjectIdx].Title = transform.GetChild(0).GetComponent<UIText>();
      this.ScrollItem[panelObjectIdx].BgImg = transform.GetComponent<Image>();
      this.ScrollItem[panelObjectIdx].Check = transform.GetChild(1).GetChild(0).GetComponent<Image>();
      if (dataIdx == (int) this.ItemCount - 1)
        this.UpdateItemData();
    }
    if (this.ProtocolType < (byte) 2)
      this.ScrollItem[panelObjectIdx].Title.text = DataManager.Instance.GetLanguageStr(this.LangueIDTable[dataIdx]);
    else if (this.ProtocolType == (byte) 3)
      this.ScrollItem[panelObjectIdx].Title.text = DataManager.Instance.GetLanguageStr(this.TranslationLangueIDTable[dataIdx]);
    else if (dataIdx < this.mLanguageCount)
      this.ScrollItem[panelObjectIdx].Title.text = this.mLanguage[dataIdx];
    this.ScrollItem[panelObjectIdx].Index = dataIdx;
    if (this.ProtocolType < (byte) 2)
    {
      if ((int) this.CurSelIndex == (int) this.LangueIDTable[dataIdx])
      {
        ((Behaviour) this.ScrollItem[panelObjectIdx].Check).enabled = true;
        this.ScrollItem[panelObjectIdx].BgImg.sprite = this.SpriteArray.GetSprite(1);
      }
      else
      {
        ((Behaviour) this.ScrollItem[panelObjectIdx].Check).enabled = false;
        this.ScrollItem[panelObjectIdx].BgImg.sprite = this.SpriteArray.GetSprite(0);
      }
    }
    else if (this.ProtocolType == (byte) 3)
    {
      if (this.CheckShowbyIdx(dataIdx))
      {
        ((Behaviour) this.ScrollItem[panelObjectIdx].Check).enabled = true;
        this.ScrollItem[panelObjectIdx].BgImg.sprite = this.SpriteArray.GetSprite(1);
      }
      else
      {
        ((Behaviour) this.ScrollItem[panelObjectIdx].Check).enabled = false;
        this.ScrollItem[panelObjectIdx].BgImg.sprite = this.SpriteArray.GetSprite(0);
      }
    }
    else if (this.tmpLanguageIdx == dataIdx)
    {
      ((Behaviour) this.ScrollItem[panelObjectIdx].Check).enabled = true;
      this.ScrollItem[panelObjectIdx].BgImg.sprite = this.SpriteArray.GetSprite(1);
    }
    else
    {
      ((Behaviour) this.ScrollItem[panelObjectIdx].Check).enabled = false;
      this.ScrollItem[panelObjectIdx].BgImg.sprite = this.SpriteArray.GetSprite(0);
    }
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (meg[0] != (byte) 35)
      return;
    for (int index = 0; index < this.ScrollItem.Length; ++index)
    {
      if (!((Object) this.ScrollItem[index].Title == (Object) null))
      {
        ((Behaviour) this.ScrollItem[index].Title).enabled = false;
        ((Behaviour) this.ScrollItem[index].Title).enabled = true;
      }
    }
    for (int index = 0; index < this.RefreshText.Length; ++index)
    {
      ((Behaviour) this.RefreshText[index]).enabled = false;
      ((Behaviour) this.RefreshText[index]).enabled = true;
    }
  }

  private void UpdateItemData()
  {
    if (this.ProtocolType < (byte) 2)
    {
      for (byte index = 0; (int) index < 42 - (int) this.ItemCount; ++index)
        this.ItemsHeight.Add(66f);
      this.Scroll.AddNewDataHeight(this.ItemsHeight);
      this.Scroll.gameObject.SetActive(true);
      byte num = 0;
      for (byte index = 0; (int) index < this.LangueIDTable.Length; ++index)
      {
        if ((int) this.CurSelIndex == (int) this.LangueIDTable[(int) index])
        {
          num = index;
          break;
        }
      }
      if (num < (byte) 6)
        return;
      this.Scroll.GoTo((int) num - 1);
    }
    else if (this.ProtocolType == (byte) 3)
    {
      for (byte index = 0; (int) index < 44 - (int) this.ItemCount; ++index)
        this.ItemsHeight.Add(66f);
      this.Scroll.AddNewDataHeight(this.ItemsHeight);
      this.Scroll.gameObject.SetActive(true);
    }
    else
    {
      if (byte.TryParse(PlayerPrefs.GetString("Other_Language"), out DataManager.Instance.MySysSetting.mUserLanguage))
      {
        switch (DataManager.Instance.MySysSetting.mUserLanguage)
        {
          case 1:
            this.tmpLanguageIdx = 1;
            break;
          case 2:
            this.tmpLanguageIdx = 0;
            break;
          case 3:
            this.tmpLanguageIdx = 2;
            break;
          case 4:
            this.tmpLanguageIdx = 3;
            break;
          case 5:
            this.tmpLanguageIdx = 5;
            break;
          case 6:
            this.tmpLanguageIdx = 4;
            break;
          case 7:
            this.tmpLanguageIdx = 6;
            break;
          case 8:
            this.tmpLanguageIdx = 7;
            break;
          case 9:
            this.tmpLanguageIdx = 8;
            break;
          case 10:
            this.tmpLanguageIdx = 9;
            break;
          case 11:
            this.tmpLanguageIdx = 10;
            break;
          case 12:
            this.tmpLanguageIdx = 11;
            break;
          case 13:
            this.tmpLanguageIdx = 12;
            break;
          case 14:
            this.tmpLanguageIdx = 13;
            break;
          case 15:
            this.tmpLanguageIdx = 14;
            break;
          case 16:
            this.tmpLanguageIdx = 15;
            break;
          case 17:
            this.tmpLanguageIdx = 16;
            break;
          case 18:
            this.tmpLanguageIdx = 17;
            break;
        }
      }
      this.ItemsHeight.Clear();
      this.mLanguageCount = 18;
      for (byte index = 0; (int) index < this.mLanguageCount; ++index)
        this.ItemsHeight.Add(66f);
      this.Scroll.AddNewDataHeight(this.ItemsHeight);
      this.Scroll.gameObject.SetActive(true);
    }
  }

  public ulong GetValuebyIdx(int Idx)
  {
    int num = 0;
    ulong valuebyIdx = 0;
    switch (Idx)
    {
      case 1:
        num = 5;
        break;
      case 2:
        num = 10;
        break;
      case 3:
        num = 13;
        break;
      case 4:
        num = 14;
        break;
      case 5:
        num = 31;
        break;
      case 6:
        num = 35;
        break;
      case 7:
        num = 41;
        break;
      case 8:
        num = 19;
        break;
      case 9:
        num = 40;
        break;
      case 10:
        num = 38;
        break;
      case 11:
        num = 37;
        break;
      case 12:
        num = 20;
        break;
      case 13:
        num = 29;
        break;
      case 14:
        num = 22;
        break;
      case 15:
      case 16:
      case 17:
      case 18:
      case 19:
        num = Idx - 15;
        break;
      case 20:
      case 21:
      case 22:
      case 23:
        num = Idx - 14;
        break;
      case 24:
      case 25:
        num = Idx - 13;
        break;
      case 26:
      case 27:
      case 28:
      case 29:
        num = Idx - 11;
        break;
      case 30:
        num = 21;
        break;
      case 31:
      case 32:
      case 33:
      case 34:
      case 35:
      case 36:
        num = Idx - 8;
        break;
      case 37:
        num = 30;
        break;
      case 38:
      case 39:
      case 40:
        num = Idx - 6;
        break;
      case 41:
        num = 36;
        break;
      case 42:
        num = 39;
        break;
      case 43:
        num = (int) byte.MaxValue;
        valuebyIdx = (ulong) byte.MaxValue;
        break;
    }
    if (num < (int) byte.MaxValue)
      valuebyIdx = 1UL << num;
    return valuebyIdx;
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
    if (this.ProtocolType == (byte) 3)
    {
      int btnId2 = gameObject.transform.GetComponent<ScrollPanelItem>().m_BtnID2;
      if (this.ScrollItem[btnId2].Index == 0)
      {
        this.bAllSet = !this.bAllSet;
        if (this.bAllSet)
        {
          this.bLangueage = true;
          this.tmpLanguageTranslation = ulong.MaxValue;
          AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
        }
        else
        {
          this.bLangueage = false;
          this.tmpLanguageTranslation = 0UL;
        }
        for (byte index = 0; (int) index < this.ScrollItem.Length; ++index)
        {
          ((Behaviour) this.ScrollItem[(int) index].Check).enabled = this.bAllSet;
          this.ScrollItem[(int) index].BgImg.sprite = !this.bAllSet ? this.SpriteArray.GetSprite(0) : this.SpriteArray.GetSprite(1);
        }
      }
      else
      {
        ulong valuebyIdx = this.GetValuebyIdx(this.ScrollItem[btnId2].Index);
        if (this.CheckShowbyIdx(this.ScrollItem[btnId2].Index))
        {
          ((Behaviour) this.ScrollItem[btnId2].Check).enabled = false;
          this.ScrollItem[btnId2].BgImg.sprite = this.SpriteArray.GetSprite(0);
          if (valuebyIdx != (ulong) byte.MaxValue)
            this.tmpLanguageTranslation -= valuebyIdx;
          else
            this.bLangueage = false;
        }
        else
        {
          ((Behaviour) this.ScrollItem[btnId2].Check).enabled = true;
          this.ScrollItem[btnId2].BgImg.sprite = this.SpriteArray.GetSprite(1);
          AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
          if (valuebyIdx != (ulong) byte.MaxValue)
            this.tmpLanguageTranslation += valuebyIdx;
          else
            this.bLangueage = true;
        }
        this.bAllSet = this.tmpLanguageTranslation == ulong.MaxValue && this.bLangueage;
        for (byte index = 0; (int) index < this.ScrollItem.Length; ++index)
        {
          if (this.ScrollItem[(int) index].Index == 0)
          {
            ((Behaviour) this.ScrollItem[(int) index].Check).enabled = this.bAllSet;
            this.ScrollItem[(int) index].BgImg.sprite = !this.bAllSet ? this.SpriteArray.GetSprite(0) : this.SpriteArray.GetSprite(1);
          }
        }
      }
    }
    else
    {
      for (byte index = 0; (int) index < this.ScrollItem.Length; ++index)
      {
        if (this.ScrollItem[(int) index].Index == dataIndex)
        {
          ((Behaviour) this.ScrollItem[(int) index].Check).enabled = true;
          this.ScrollItem[(int) index].BgImg.sprite = this.SpriteArray.GetSprite(1);
          this.CurSelIndex = this.LangueIDTable[dataIndex];
          if (this.ProtocolType == (byte) 2)
            this.tmpLanguageIdx = dataIndex;
          AudioManager.Instance.PlayUISFXIndex(UIClickSoundIndex.Normal);
        }
        else
        {
          ((Behaviour) this.ScrollItem[(int) index].Check).enabled = false;
          this.ScrollItem[(int) index].BgImg.sprite = this.SpriteArray.GetSprite(0);
        }
      }
    }
  }

  public void LoadCustomImage(Image img, string ImageName, string TextureName)
  {
    Door menu = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    if (!(bool) (Object) menu)
      return;
    img.sprite = menu.LoadSprite(ImageName);
    ((MaskableGraphic) img).material = menu.LoadMaterial();
  }

  private enum UIControl
  {
    Background,
    Title,
    ImageTitle,
    Accept,
    Scroll,
    Item,
    Close,
  }

  private struct ItemEdit
  {
    public int Index;
    public UIText Title;
    public Image BgImg;
    public Image Check;
  }
}
