// Decompiled with JetBrains decompiler
// Type: UIHeroUse
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 4857610B-EF43-43B0-884E-D10225C3A26E
// Assembly location: C:\Users\supdams\Desktop\Assembly-CSharp.dll.dll

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#nullable disable
public class UIHeroUse : GUIWindow, IUpDateScrollPanel, IUIButtonClickHandler
{
  private const int MaxScorllCount = 5;
  private UIText[] m_TitleText = new UIText[2];
  private ScrollPanel m_ScrollPanel;
  private Door door;
  private HeroExpObj[] m_HeroExpObj = new HeroExpObj[5];
  private UISpritesArray m_SpArray;
  private int m_FlashCount;
  private float m_FlashLeftOver;
  private bool bShowLvUp;
  private float LvUpCount;
  private bool[] bFinish = new bool[3];
  private byte m_BeginLv;
  private byte m_TagetLv;
  private float m_Leftover;
  private int m_LvUpHeroID;
  private int m_preLvUpHeroID;
  private float[] m_TickTime = new float[3]
  {
    0.008f,
    0.01f,
    0.01f
  };
  private float m_SliderValue;
  private float[] m_FalshImageEffectTime = new float[3]
  {
    0.8f,
    0.8f,
    1.2f
  };
  public float[] PageMoveSpeed = new float[2];
  private UIHeroUse.eUIHU_OpenKind OpenKind;

  public override void OnOpen(int arg1, int arg2)
  {
    DataManager instance1 = DataManager.Instance;
    Font ttfFont = GUIManager.Instance.GetTTFFont();
    this.door = GUIManager.Instance.FindMenu(EGUIWindow.Door) as Door;
    this.OpenKind = (UIHeroUse.eUIHU_OpenKind) arg1;
    if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.eHero)
    {
      this.m_SpArray = this.transform.GetComponent<UISpritesArray>();
      Image component1 = this.transform.GetChild(4).GetComponent<Image>();
      component1.sprite = this.door.LoadSprite("UI_main_close_base");
      ((MaskableGraphic) component1).material = this.door.LoadMaterial();
      if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (UnityEngine.Object) component1)
        ((Behaviour) component1).enabled = false;
      UIButton component2 = this.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
      component2.m_BtnID1 = 101;
      component2.m_Handler = (IUIButtonClickHandler) this;
      component2.image.sprite = this.door.LoadSprite("UI_main_close");
      ((MaskableGraphic) component2.image).material = this.door.LoadMaterial();
      this.m_TitleText[0] = this.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
      this.m_TitleText[0].font = ttfFont;
      this.m_TitleText[0].text = instance1.mStringTable.GetStringByID(529U);
      this.m_TitleText[1] = this.transform.GetChild(2).GetChild(0).GetComponent<UIText>();
      this.m_TitleText[1].font = ttfFont;
      this.m_TitleText[1].text = instance1.mStringTable.GetStringByID(530U);
      for (int index = 0; index < 4; ++index)
      {
        this.transform.GetChild(5).GetChild(index).GetComponent<UIButton>().SoundIndex = (byte) 64;
        GUIManager.Instance.InitianHeroItemImg(((Component) this.transform.GetChild(5).GetChild(index).GetChild(1).GetComponent<UIHIBtn>()).transform, eHeroOrItem.Hero, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
        if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
          this.transform.GetChild(5).GetChild(index).GetChild(2).GetComponent<Image>().sprite = this.m_SpArray.GetSprite(3);
        this.transform.GetChild(5).GetChild(index).GetChild(2).GetChild(0).GetComponent<UIText>().font = ttfFont;
        this.transform.GetChild(5).GetChild(index).GetChild(2).GetChild(1).GetComponent<UIText>().font = ttfFont;
        UIText component3 = this.transform.GetChild(5).GetChild(index).GetChild(6).GetComponent<UIText>();
        component3.font = ttfFont;
        component3.text = instance1.mStringTable.GetStringByID(1555U);
        if (GUIManager.Instance.IsArabic)
        {
          Image component4 = this.transform.GetChild(5).GetChild(index).GetChild(2).GetComponent<Image>();
          if ((UnityEngine.Object) component4 != (UnityEngine.Object) null)
            component4.sprite = this.m_SpArray.GetSprite(5);
        }
      }
      DataManager.SortHeroData();
      int curHeroDataCount = (int) DataManager.Instance.CurHeroDataCount;
      int num = curHeroDataCount % 4 != 0 ? curHeroDataCount / 4 + 1 : curHeroDataCount / 4;
      this.InitHeroExpObj();
      this.m_ScrollPanel = this.transform.GetChild(3).GetComponent<ScrollPanel>();
      List<float> _DataHeight = new List<float>();
      for (int index = 0; index < num; ++index)
        _DataHeight.Add(244f);
      this.m_ScrollPanel.IntiScrollPanel(496f, 0.0f, 1f, _DataHeight, 5, (IUpDateScrollPanel) this);
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 2);
    }
    else
    {
      if (this.OpenKind != UIHeroUse.eUIHU_OpenKind.ePet)
        return;
      PetManager instance2 = PetManager.Instance;
      instance2.SortPetData();
      this.m_SpArray = this.transform.GetComponent<UISpritesArray>();
      Image component5 = this.transform.GetChild(4).GetComponent<Image>();
      component5.sprite = this.door.LoadSprite("UI_main_close_base");
      ((MaskableGraphic) component5).material = this.door.LoadMaterial();
      if (GUIManager.Instance.bOpenOnIPhoneX && (bool) (UnityEngine.Object) component5)
        ((Behaviour) component5).enabled = false;
      UIButton component6 = this.transform.GetChild(4).GetChild(0).GetComponent<UIButton>();
      component6.m_BtnID1 = 101;
      component6.m_Handler = (IUIButtonClickHandler) this;
      component6.image.sprite = this.door.LoadSprite("UI_main_close");
      ((MaskableGraphic) component6.image).material = this.door.LoadMaterial();
      this.m_TitleText[0] = this.transform.GetChild(1).GetChild(0).GetComponent<UIText>();
      this.m_TitleText[0].font = ttfFont;
      this.m_TitleText[0].text = instance1.mStringTable.GetStringByID(16044U);
      this.m_TitleText[1] = this.transform.GetChild(2).GetChild(0).GetComponent<UIText>();
      this.m_TitleText[1].font = ttfFont;
      this.m_TitleText[1].text = instance1.mStringTable.GetStringByID(16045U);
      for (int index = 0; index < 4; ++index)
      {
        this.transform.GetChild(5).GetChild(index).GetComponent<UIButton>().SoundIndex = (byte) 64;
        GUIManager.Instance.InitianHeroItemImg(((Component) this.transform.GetChild(5).GetChild(index).GetChild(1).GetComponent<UIHIBtn>()).transform, eHeroOrItem.Pet, (ushort) 0, (byte) 0, (byte) 0, bShowText: false, bAutoShowHint: false);
        if (DataManager.Instance.UserLanguage == GameLanguage.GL_Chs)
          this.transform.GetChild(5).GetChild(index).GetChild(2).GetComponent<Image>().sprite = this.m_SpArray.GetSprite(3);
        this.transform.GetChild(5).GetChild(index).GetChild(2).GetChild(0).GetComponent<UIText>().font = ttfFont;
        this.transform.GetChild(5).GetChild(index).GetChild(2).GetChild(1).GetComponent<UIText>().font = ttfFont;
        UIText component7 = this.transform.GetChild(5).GetChild(index).GetChild(6).GetComponent<UIText>();
        component7.font = ttfFont;
        component7.text = instance1.mStringTable.GetStringByID(1555U);
        if (GUIManager.Instance.IsArabic)
        {
          Image component8 = this.transform.GetChild(5).GetChild(index).GetChild(2).GetComponent<Image>();
          if ((UnityEngine.Object) component8 != (UnityEngine.Object) null)
            component8.sprite = this.m_SpArray.GetSprite(5);
        }
      }
      int petDataCount = (int) instance2.PetDataCount;
      int num = petDataCount % 4 != 0 ? petDataCount / 4 + 1 : petDataCount / 4;
      this.InitHeroExpObj();
      this.m_ScrollPanel = this.transform.GetChild(3).GetComponent<ScrollPanel>();
      List<float> _DataHeight = new List<float>();
      for (int index = 0; index < num; ++index)
        _DataHeight.Add(244f);
      this.m_ScrollPanel.IntiScrollPanel(496f, 0.0f, 1f, _DataHeight, 5, (IUpDateScrollPanel) this);
      if (arg2 != 0)
      {
        for (int index = 0; index < (int) instance2.PetDataCount; ++index)
        {
          PetData petData = instance2.GetPetData((int) instance2.sortPetData[index]);
          if (petData != null && (int) petData.ID == arg2)
          {
            if (index >= 4)
            {
              this.m_ScrollPanel.GoTo(index / 4);
              break;
            }
            break;
          }
        }
        GUIManager.Instance.OpenContinuousUI(GUIManager.Instance.m_ItemInfo.m_ItemBtn.HIID, (int) instance2.PetUI_UseItemPetID);
      }
      GUIManager.Instance.UpdateUI(EGUIWindow.Door, 1, 4);
    }
  }

  public override void OnClose()
  {
    for (int index1 = 0; index1 < 5; ++index1)
    {
      for (int index2 = 0; index2 < 4; ++index2)
      {
        if (this.m_HeroExpObj[index1].m_Str[index2] != null)
        {
          StringManager.Instance.DeSpawnString(this.m_HeroExpObj[index1].m_Str[index2]);
          this.m_HeroExpObj[index1].m_Str[index2] = (CString) null;
        }
      }
    }
  }

  public override void UpdateUI(int arg1, int arg2)
  {
    if (arg1 != 0)
      return;
    this.StopHeroLvUp(this.m_LvUpHeroID);
    this.UpdateScrollPanel(false);
  }

  public override void UpdateNetwork(byte[] meg)
  {
    if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.eHero)
    {
      NetworkNews networkNews = (NetworkNews) meg[0];
      switch (networkNews)
      {
        case NetworkNews.Login:
        case NetworkNews.Refresh:
        case NetworkNews.Refresh_Hero:
          this.UpdateScrollPanel();
          break;
        case NetworkNews.Refresh_Item:
          byte tagetlv = meg[3];
          float leftover = GameConstants.ConvertBytesToFloat(meg, 4);
          ushort HeroID = GameConstants.ConvertBytesToUShort(meg, 8);
          byte beginlv = meg[2];
          Array.Clear((Array) meg, 2, 6);
          if (HeroID == (ushort) 0)
            break;
          this.m_BeginLv = (byte) 0;
          this.m_TagetLv = (byte) 0;
          this.m_Leftover = 0.0f;
          this.m_FlashCount = -1;
          this.SetHeroLvUp(beginlv, tagetlv, leftover, (int) HeroID);
          break;
        default:
          if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            break;
          this.Refresh_FontTexture();
          break;
      }
    }
    else
    {
      if (this.OpenKind != UIHeroUse.eUIHU_OpenKind.ePet)
        return;
      NetworkNews networkNews = (NetworkNews) meg[0];
      switch (networkNews)
      {
        case NetworkNews.Login:
        case NetworkNews.Refresh:
          this.StopHeroLvUp(this.m_LvUpHeroID);
          this.UpdateScrollPanel();
          break;
        default:
          if (networkNews != NetworkNews.Refresh_Item)
          {
            if (networkNews != NetworkNews.Refresh_FontTextureRebuilt)
            {
              if (networkNews != NetworkNews.Refresh_Pet)
                break;
              goto case NetworkNews.Login;
            }
            else
            {
              this.Refresh_FontTexture();
              break;
            }
          }
          else
          {
            byte tagetlv = meg[3];
            float leftover = GameConstants.ConvertBytesToFloat(meg, 4);
            ushort HeroID = GameConstants.ConvertBytesToUShort(meg, 8);
            byte beginlv = meg[2];
            Array.Clear((Array) meg, 2, 8);
            if (HeroID == (ushort) 0)
              break;
            this.m_BeginLv = (byte) 0;
            this.m_TagetLv = (byte) 0;
            this.m_Leftover = 0.0f;
            this.m_FlashCount = -1;
            this.SetHeroLvUp(beginlv, tagetlv, leftover, (int) HeroID);
            break;
          }
      }
    }
  }

  public override bool OnBackButtonClick() => false;

  public void InitHeroExpObj()
  {
    for (int index1 = 0; index1 < 5; ++index1)
    {
      this.m_HeroExpObj[index1].m_HeroHibtn = new UIHIBtn[4];
      this.m_HeroExpObj[index1].m_ScrollSlider = new Slider[4];
      this.m_HeroExpObj[index1].m_ScrollLvUpRT = new RectTransform[4];
      this.m_HeroExpObj[index1].m_ScrollLvUpText = new UIText[4];
      this.m_HeroExpObj[index1].m_ScrollLvText = new UIText[4];
      this.m_HeroExpObj[index1].m_FlashHandle = new Image[4];
      this.m_HeroExpObj[index1].ScrollHeroID = new ushort[4];
      this.m_HeroExpObj[index1].m_HeroNameText = new UIText[4];
      this.m_HeroExpObj[index1].m_Btn = new UIButton[4];
      this.m_HeroExpObj[index1].m_Str = new CString[4];
      for (int index2 = 0; index2 < 4; ++index2)
      {
        if (this.m_HeroExpObj[index1].m_Str[index2] == null)
          this.m_HeroExpObj[index1].m_Str[index2] = StringManager.Instance.SpawnString();
      }
      this.m_HeroExpObj[index1].m_FlashImage1 = new Image[4];
      this.m_HeroExpObj[index1].m_FlashImage2 = new Image[4];
      this.m_HeroExpObj[index1].m_FlashValue1 = new FlashValue[4];
      this.m_HeroExpObj[index1].m_FlashValue2 = new FlashValue[4];
      this.m_HeroExpObj[index1].m_FlashLvUpValue = new FlashValue[4];
      this.m_HeroExpObj[index1].m_IsFightingImg = new Image[4];
      this.m_HeroExpObj[index1].m_PetLock = new Image[4];
      this.m_HeroExpObj[index1].m_FillImage = new Image[4];
    }
  }

  private void Update()
  {
    bool flag = false;
    for (int index1 = 0; index1 < 5; ++index1)
    {
      for (int index2 = 0; index2 < 4; ++index2)
      {
        if (this.m_LvUpHeroID != 0 && this.m_LvUpHeroID == (int) this.m_HeroExpObj[index1].ScrollHeroID[index2])
        {
          this.m_TickTime[0] += Time.deltaTime;
          if ((double) this.m_TickTime[0] >= 0.0099999997764825821)
          {
            if ((bool) (UnityEngine.Object) this.m_HeroExpObj[index1].m_ScrollSlider[index2])
            {
              if (this.m_FlashCount >= 0)
              {
                this.m_preLvUpHeroID = this.m_LvUpHeroID;
                flag = true;
                if ((int) this.m_BeginLv == (int) this.m_TagetLv && (double) this.m_HeroExpObj[index1].m_ScrollSlider[index2].value < (double) this.m_FlashLeftOver)
                {
                  this.m_TickTime[0] = 0.0f;
                  this.m_HeroExpObj[index1].m_ScrollSlider[index2].value += 0.02f;
                  this.m_HeroExpObj[index1].m_ScrollSlider[index2].value = Mathf.Clamp(this.m_HeroExpObj[index1].m_ScrollSlider[index2].value, 0.0f, this.m_FlashLeftOver);
                }
                else
                {
                  this.m_TickTime[0] = 0.0f;
                  this.m_HeroExpObj[index1].m_ScrollSlider[index2].value += 0.02f;
                }
                this.m_SliderValue = this.m_HeroExpObj[index1].m_ScrollSlider[index2].value;
                if ((double) this.m_SliderValue >= 1.0)
                {
                  this.m_SliderValue = 0.0f;
                  this.m_HeroExpObj[index1].m_ScrollSlider[index2].value = 0.0f;
                  --this.m_FlashCount;
                  this.bShowLvUp = true;
                  ++this.LvUpCount;
                  ++this.m_BeginLv;
                  this.m_HeroExpObj[index1].m_Str[index2].ClearString();
                  StringManager.Instance.IntToFormat((long) this.m_BeginLv);
                  this.m_HeroExpObj[index1].m_Str[index2].AppendFormat("{0}");
                  this.m_HeroExpObj[index1].m_ScrollLvText[index2].text = this.m_HeroExpObj[index1].m_Str[index2].ToString();
                  this.m_HeroExpObj[index1].m_ScrollLvText[index2].SetAllDirty();
                  this.m_HeroExpObj[index1].m_ScrollLvText[index2].cachedTextGenerator.Invalidate();
                  AudioManager.Instance.PlayUISFX(UIKind.HeroLevelup);
                }
                if ((int) this.m_BeginLv == (int) this.m_TagetLv && (double) this.m_SliderValue >= (double) this.m_FlashLeftOver)
                {
                  this.m_FlashCount = -1;
                  if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.ePet)
                  {
                    PetData petData = PetManager.Instance.FindPetData((ushort) this.m_LvUpHeroID);
                    if (petData != null)
                    {
                      if (this.GetPetLock(petData.ID) != (byte) 0)
                        ((Behaviour) this.m_HeroExpObj[index1].m_PetLock[index2]).enabled = true;
                      else
                        ((Behaviour) this.m_HeroExpObj[index1].m_PetLock[index2]).enabled = false;
                      if (petData.Level < (byte) 60)
                      {
                        this.m_HeroExpObj[index1].m_FillImage[index2].sprite = this.m_SpArray.GetSprite(7);
                      }
                      else
                      {
                        this.m_HeroExpObj[index1].m_FillImage[index2].sprite = this.m_SpArray.GetSprite(8);
                        this.m_HeroExpObj[index1].m_ScrollSlider[index2].value = 1f;
                      }
                    }
                  }
                }
              }
            }
            else
              continue;
          }
          if (this.bShowLvUp)
          {
            if ((bool) (UnityEngine.Object) this.m_HeroExpObj[index1].m_ScrollLvUpRT[index2])
            {
              if ((double) this.LvUpCount > 0.0)
              {
                flag = true;
                if ((double) this.m_HeroExpObj[index1].m_FlashLvUpValue[index2].posTime >= (double) this.m_FalshImageEffectTime[2])
                {
                  this.bFinish[0] = true;
                  ((Behaviour) this.m_HeroExpObj[index1].m_ScrollLvUpText[index2]).enabled = false;
                }
                else
                {
                  this.bFinish[0] = false;
                  ((Behaviour) this.m_HeroExpObj[index1].m_ScrollLvUpText[index2]).enabled = true;
                  this.m_HeroExpObj[index1].m_FlashLvUpValue[index2].posTime += Time.deltaTime;
                  this.m_HeroExpObj[index1].m_FlashLvUpValue[index2].posY = this.SelectTween(this.m_HeroExpObj[index1].m_FlashLvUpValue[index2].posTime, -210f, 200f, this.m_FalshImageEffectTime[2]);
                  this.m_HeroExpObj[index1].m_ScrollLvUpRT[index2].anchoredPosition = this.m_HeroExpObj[index1].m_ScrollLvUpText[index2].ArabicFixPos(new Vector2(30f, this.m_HeroExpObj[index1].m_FlashLvUpValue[index2].posY));
                  this.m_HeroExpObj[index1].m_FlashLvUpValue[index2].colorA = this.SelectTween(this.m_HeroExpObj[index1].m_FlashLvUpValue[index2].posTime, 0.0f, 1f, this.m_FalshImageEffectTime[2]);
                  ((Graphic) this.m_HeroExpObj[index1].m_ScrollLvUpText[index2]).color = new Color(((Graphic) this.m_HeroExpObj[index1].m_ScrollLvUpText[index2]).color.r, ((Graphic) this.m_HeroExpObj[index1].m_ScrollLvUpText[index2]).color.g, ((Graphic) this.m_HeroExpObj[index1].m_ScrollLvUpText[index2]).color.b, this.m_HeroExpObj[index1].m_FlashLvUpValue[index2].colorA);
                }
                if ((double) this.m_HeroExpObj[index1].m_FlashValue1[index2].colorTime >= (double) this.m_FalshImageEffectTime[0])
                {
                  this.bFinish[1] = true;
                  ((Behaviour) this.m_HeroExpObj[index1].m_FlashImage1[index2]).enabled = false;
                }
                else
                {
                  this.bFinish[1] = false;
                  ((Behaviour) this.m_HeroExpObj[index1].m_FlashImage1[index2]).enabled = true;
                  this.m_HeroExpObj[index1].m_FlashValue1[index2].colorTime += Time.deltaTime;
                  this.m_HeroExpObj[index1].m_FlashValue1[index2].colorA = this.SelectTween(this.m_HeroExpObj[index1].m_FlashValue1[index2].colorTime, 0.0f, 2f, this.m_FalshImageEffectTime[0]);
                  if ((double) this.m_HeroExpObj[index1].m_FlashValue1[index2].colorA >= 1.0)
                    ((Graphic) this.m_HeroExpObj[index1].m_FlashImage1[index2]).color = new Color(1f, 1f, 1f, 2f - this.m_HeroExpObj[index1].m_FlashValue1[index2].colorA);
                  else
                    ((Graphic) this.m_HeroExpObj[index1].m_FlashImage1[index2]).color = new Color(1f, 1f, 1f, this.m_HeroExpObj[index1].m_FlashValue1[index2].colorA);
                }
                if ((double) this.m_HeroExpObj[index1].m_FlashValue2[index2].colorTime >= (double) this.m_FalshImageEffectTime[0])
                {
                  this.bFinish[2] = true;
                  ((Behaviour) this.m_HeroExpObj[index1].m_FlashImage2[index2]).enabled = false;
                }
                else
                {
                  this.bFinish[2] = false;
                  ((Behaviour) this.m_HeroExpObj[index1].m_FlashImage2[index2]).enabled = true;
                  this.m_HeroExpObj[index1].m_FlashValue2[index2].colorTime += Time.deltaTime;
                  this.m_HeroExpObj[index1].m_FlashValue2[index2].colorA = this.SelectTween(this.m_HeroExpObj[index1].m_FlashValue2[index2].colorTime, 0.0f, 2f, this.m_FalshImageEffectTime[0]);
                  if ((double) this.m_HeroExpObj[index1].m_FlashValue2[index2].colorA >= 1.0)
                    ((Graphic) this.m_HeroExpObj[index1].m_FlashImage2[index2]).color = new Color(1f, 1f, 1f, 2f - this.m_HeroExpObj[index1].m_FlashValue2[index2].colorA);
                  else
                    ((Graphic) this.m_HeroExpObj[index1].m_FlashImage2[index2]).color = new Color(1f, 1f, 1f, this.m_HeroExpObj[index1].m_FlashValue2[index2].colorA);
                  this.m_HeroExpObj[index1].m_FlashValue2[index2].posY = this.SelectTween(this.m_HeroExpObj[index1].m_FlashValue2[index2].colorTime, -40f, 180f, this.m_FalshImageEffectTime[0]);
                  ((Graphic) this.m_HeroExpObj[index1].m_FlashImage2[index2]).rectTransform.anchoredPosition = new Vector2(0.0f, this.m_HeroExpObj[index1].m_FlashValue2[index2].posY);
                }
                if (this.bFinish[0] && this.bFinish[1] && this.bFinish[2])
                {
                  --this.LvUpCount;
                  if (this.m_FlashCount == -1)
                  {
                    this.bShowLvUp = false;
                    this.LvUpCount = 0.0f;
                    if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.ePet)
                    {
                      PetData petData = PetManager.Instance.FindPetData((ushort) this.m_LvUpHeroID);
                      if (petData != null)
                      {
                        if (this.GetPetLock(petData.ID) != (byte) 0)
                          ((Behaviour) this.m_HeroExpObj[index1].m_PetLock[index2]).enabled = true;
                        else
                          ((Behaviour) this.m_HeroExpObj[index1].m_PetLock[index2]).enabled = false;
                      }
                    }
                  }
                  this.m_HeroExpObj[index1].m_FlashLvUpValue[index2].posTime = 0.0f;
                  this.m_HeroExpObj[index1].m_FlashValue1[index2].colorTime = 0.0f;
                  this.m_HeroExpObj[index1].m_FlashValue2[index2].colorTime = 0.0f;
                  break;
                }
                break;
              }
              break;
            }
          }
          else
            break;
        }
      }
    }
    if (flag)
      return;
    this.m_preLvUpHeroID = 0;
  }

  public float SelectTween(float t, float b, float c, float d)
  {
    t /= d;
    return b + c * t;
  }

  public void UpdateScrollPanel(bool bneedSort = true)
  {
    if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.eHero)
    {
      if (bneedSort)
        DataManager.SortHeroData();
      int curHeroDataCount = (int) DataManager.Instance.CurHeroDataCount;
      int num = curHeroDataCount % 4 != 0 ? curHeroDataCount / 4 + 1 : curHeroDataCount / 4;
      this.InitHeroExpObj();
      this.m_ScrollPanel = this.transform.GetChild(3).GetComponent<ScrollPanel>();
      List<float> _DataHeight = new List<float>();
      for (int index = 0; index < num; ++index)
        _DataHeight.Add(244f);
      this.m_ScrollPanel.AddNewDataHeight(_DataHeight, false);
    }
    else
    {
      if (this.OpenKind != UIHeroUse.eUIHU_OpenKind.ePet)
        return;
      if (bneedSort)
        PetManager.Instance.SortPetData();
      int petDataCount = (int) PetManager.Instance.PetDataCount;
      int num = petDataCount % 4 != 0 ? petDataCount / 4 + 1 : petDataCount / 4;
      this.InitHeroExpObj();
      this.m_ScrollPanel = this.transform.GetChild(3).GetComponent<ScrollPanel>();
      List<float> _DataHeight = new List<float>();
      for (int index = 0; index < num; ++index)
        _DataHeight.Add(244f);
      this.m_ScrollPanel.AddNewDataHeight(_DataHeight, false);
    }
  }

  public void OnButtonClick(UIButton sender)
  {
    if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.eHero)
    {
      if (sender.m_BtnID1 == 101)
      {
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          return;
        this.door.CloseMenu();
      }
      else
      {
        switch (DataManager.Instance.GetHeroState((ushort) sender.m_BtnID2))
        {
          case eHeroState.Captured:
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(818U), (ushort) byte.MaxValue);
            break;
          case eHeroState.Dead:
            GUIManager.Instance.AddHUDMessage(DataManager.Instance.mStringTable.GetStringByID(819U), (ushort) byte.MaxValue);
            break;
          default:
            if (sender.m_BtnID2 == this.m_preLvUpHeroID)
            {
              this.StopHeroLvUp(this.m_preLvUpHeroID);
              this.UpdateScrollPanel();
            }
            GUIManager.Instance.OpenContinuousUI(GUIManager.Instance.m_ItemInfo.m_ItemBtn.HIID, sender.m_BtnID2);
            break;
        }
      }
    }
    else
    {
      if (this.OpenKind != UIHeroUse.eUIHU_OpenKind.ePet)
        return;
      if (sender.m_BtnID1 == 101)
      {
        if (!((UnityEngine.Object) this.door != (UnityEngine.Object) null))
          return;
        this.door.CloseMenu();
      }
      else
      {
        PetManager instance1 = PetManager.Instance;
        ushort btnId2 = (ushort) sender.m_BtnID2;
        byte petLock = this.GetPetLock(btnId2);
        if (petLock != (byte) 0)
        {
          DataManager instance2 = DataManager.Instance;
          CString cstring = StringManager.Instance.StaticString1024();
          if (petLock == (byte) 1)
          {
            PetTbl recordByKey = instance1.PetTable.GetRecordByKey(btnId2);
            cstring.StringToFormat(instance2.mStringTable.GetStringByID((uint) recordByKey.Name));
            cstring.AppendFormat(instance2.mStringTable.GetStringByID(16040U));
            GUIManager.Instance.AddHUDMessage(cstring.ToString(), (ushort) byte.MaxValue);
          }
          else
          {
            if (petLock != (byte) 2)
              return;
            GUIManager.Instance.OpenMessageBox(instance2.mStringTable.GetStringByID(16082U), instance2.mStringTable.GetStringByID(16069U), instance2.mStringTable.GetStringByID(3968U), (GUIWindow) this, 1, (int) btnId2, true);
          }
        }
        else
        {
          if ((int) btnId2 == this.m_preLvUpHeroID)
          {
            this.StopHeroLvUp(this.m_preLvUpHeroID);
            this.UpdateScrollPanel();
          }
          GUIManager.Instance.OpenContinuousUI(GUIManager.Instance.m_ItemInfo.m_ItemBtn.HIID, sender.m_BtnID2);
        }
      }
    }
  }

  public void UpDateRowItem(GameObject item, int dataIdx, int panelObjectIdx, int panelId)
  {
    if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.eHero)
    {
      DataManager instance1 = DataManager.Instance;
      GUIManager instance2 = GUIManager.Instance;
      for (int index1 = 0; index1 < 4; ++index1)
      {
        int index2 = dataIdx * 4 + index1;
        uint key = instance1.sortHeroData[index2];
        if (instance1.curHeroData.ContainsKey(key))
        {
          CurHeroData curHeroData = instance1.curHeroData[key];
          this.m_HeroExpObj[panelObjectIdx].ScrollHeroID[index1] = (ushort) 0;
          Hero recordByKey = DataManager.Instance.HeroTable.GetRecordByKey(curHeroData.ID);
          if ((UnityEngine.Object) this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[index1] == (UnityEngine.Object) null)
          {
            this.m_HeroExpObj[panelObjectIdx].m_HeroHibtn[index1] = item.transform.GetChild(index1).GetChild(1).GetComponent<UIHIBtn>();
            Transform child1 = item.transform.GetChild(index1).GetChild(2);
            this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[index1] = child1.GetChild(0).GetComponent<UIText>();
            this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[index1].resizeTextForBestFit = true;
            this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[index1].resizeTextMaxSize = 22;
            Transform child2 = item.transform.GetChild(index1).GetChild(2);
            this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[index1] = child2.GetChild(1).GetComponent<UIText>();
            this.m_HeroExpObj[panelObjectIdx].m_Btn[index1] = item.transform.GetChild(index1).GetComponent<UIButton>();
            this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[index1] = item.transform.GetChild(index1).GetChild(3).GetComponent<Slider>();
            this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpRT[index1] = item.transform.GetChild(index1).GetChild(6).GetComponent<RectTransform>();
            this.m_HeroExpObj[panelObjectIdx].m_FlashImage1[index1] = item.transform.GetChild(index1).GetChild(4).GetComponent<Image>();
            this.m_HeroExpObj[panelObjectIdx].m_FlashImage2[index1] = item.transform.GetChild(index1).GetChild(5).GetComponent<Image>();
            this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpText[index1] = item.transform.GetChild(index1).GetChild(6).GetComponent<UIText>();
            this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[index1] = item.transform.GetChild(index1).GetChild(7).GetComponent<Image>();
            this.m_HeroExpObj[panelObjectIdx].m_PetLock[index1] = item.transform.GetChild(index1).GetChild(8).GetComponent<Image>();
            this.m_HeroExpObj[panelObjectIdx].m_FillImage[index1] = ((Component) this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[index1].fillRect).GetComponent<Image>();
          }
          this.m_HeroExpObj[panelObjectIdx].ScrollHeroID[index1] = recordByKey.HeroKey;
          instance2.ChangeHeroItemImg(((Component) this.m_HeroExpObj[panelObjectIdx].m_HeroHibtn[index1]).transform, eHeroOrItem.Hero, curHeroData.ID, curHeroData.Star, (byte) 0);
          this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[index1].text = DataManager.Instance.mStringTable.GetStringByID((uint) recordByKey.HeroTitle);
          this.m_HeroExpObj[panelObjectIdx].m_Str[index1].ClearString();
          StringManager.Instance.IntToFormat((long) curHeroData.Level);
          this.m_HeroExpObj[panelObjectIdx].m_Str[index1].AppendFormat("{0}");
          this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[index1].text = this.m_HeroExpObj[panelObjectIdx].m_Str[index1].ToString();
          this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[index1].SetAllDirty();
          this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[index1].cachedTextGenerator.Invalidate();
          ((Behaviour) this.m_HeroExpObj[panelObjectIdx].m_FlashImage1[index1]).enabled = false;
          ((Behaviour) this.m_HeroExpObj[panelObjectIdx].m_FlashImage2[index1]).enabled = false;
          ((Behaviour) this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpText[index1]).enabled = false;
          this.m_HeroExpObj[panelObjectIdx].m_FlashLvUpValue[index1].posTime = 0.0f;
          this.m_HeroExpObj[panelObjectIdx].m_FlashValue1[index1].colorTime = 0.0f;
          this.m_HeroExpObj[panelObjectIdx].m_FlashValue2[index1].colorTime = 0.0f;
          this.m_HeroExpObj[panelObjectIdx].m_Btn[index1].m_Handler = (IUIButtonClickHandler) this;
          this.m_HeroExpObj[panelObjectIdx].m_Btn[index1].m_BtnID1 = index2;
          this.m_HeroExpObj[panelObjectIdx].m_Btn[index1].m_BtnID2 = (int) recordByKey.HeroKey;
          uint heroExp = instance1.LevelUpTable.GetRecordByKey((ushort) curHeroData.Level).HeroExp;
          uint exp = curHeroData.Exp;
          this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[index1].value = (float) exp / (float) heroExp;
          this.m_HeroExpObj[panelObjectIdx].ScrollHeroID[index1] = recordByKey.HeroKey;
          this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpRT[index1].anchoredPosition = this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpText[index1].ArabicFixPos(new Vector2(44f, -98f));
          eHeroState heroState = instance1.GetHeroState(recordByKey.HeroKey);
          if (heroState == eHeroState.None)
          {
            ((Component) this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[index1]).gameObject.SetActive(false);
          }
          else
          {
            if (heroState == eHeroState.IsFighting)
              this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[index1].sprite = this.m_SpArray.GetSprite(0);
            if (heroState == eHeroState.Captured)
              this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[index1].sprite = this.m_SpArray.GetSprite(1);
            if (heroState == eHeroState.Dead)
              this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[index1].sprite = this.m_SpArray.GetSprite(2);
            ((Component) this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[index1]).gameObject.SetActive(true);
          }
        }
        if ((long) index2 < (long) instance1.CurHeroDataCount)
          item.transform.GetChild(index1).gameObject.SetActive(true);
        else
          item.transform.GetChild(index1).gameObject.SetActive(false);
      }
    }
    else
    {
      if (this.OpenKind != UIHeroUse.eUIHU_OpenKind.ePet)
        return;
      DataManager instance3 = DataManager.Instance;
      GUIManager instance4 = GUIManager.Instance;
      PetManager instance5 = PetManager.Instance;
      for (int index3 = 0; index3 < 4; ++index3)
      {
        int index4 = dataIdx * 4 + index3;
        if (index4 < (int) instance5.PetDataCount)
        {
          PetData petData = instance5.GetPetData((int) instance5.sortPetData[index4]);
          if (petData != null)
          {
            if ((UnityEngine.Object) this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[index3] == (UnityEngine.Object) null)
            {
              this.m_HeroExpObj[panelObjectIdx].m_HeroHibtn[index3] = item.transform.GetChild(index3).GetChild(1).GetComponent<UIHIBtn>();
              Transform child3 = item.transform.GetChild(index3).GetChild(2);
              this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[index3] = child3.GetChild(0).GetComponent<UIText>();
              this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[index3].resizeTextForBestFit = true;
              this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[index3].resizeTextMaxSize = 22;
              Transform child4 = item.transform.GetChild(index3).GetChild(2);
              this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[index3] = child4.GetChild(1).GetComponent<UIText>();
              this.m_HeroExpObj[panelObjectIdx].m_Btn[index3] = item.transform.GetChild(index3).GetComponent<UIButton>();
              this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[index3] = item.transform.GetChild(index3).GetChild(3).GetComponent<Slider>();
              this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpRT[index3] = item.transform.GetChild(index3).GetChild(6).GetComponent<RectTransform>();
              this.m_HeroExpObj[panelObjectIdx].m_FlashImage1[index3] = item.transform.GetChild(index3).GetChild(4).GetComponent<Image>();
              this.m_HeroExpObj[panelObjectIdx].m_FlashImage2[index3] = item.transform.GetChild(index3).GetChild(5).GetComponent<Image>();
              this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpText[index3] = item.transform.GetChild(index3).GetChild(6).GetComponent<UIText>();
              this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[index3] = item.transform.GetChild(index3).GetChild(7).GetComponent<Image>();
              this.m_HeroExpObj[panelObjectIdx].m_PetLock[index3] = item.transform.GetChild(index3).GetChild(8).GetComponent<Image>();
              this.m_HeroExpObj[panelObjectIdx].m_FillImage[index3] = ((Component) this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[index3].fillRect).GetComponent<Image>();
            }
            PetTbl recordByKey = instance5.PetTable.GetRecordByKey(petData.ID);
            this.m_HeroExpObj[panelObjectIdx].ScrollHeroID[index3] = petData.ID;
            instance4.ChangeHeroItemImg(((Component) this.m_HeroExpObj[panelObjectIdx].m_HeroHibtn[index3]).transform, eHeroOrItem.Pet, petData.ID, petData.Enhance, (byte) 0);
            this.m_HeroExpObj[panelObjectIdx].m_HeroNameText[index3].text = instance3.mStringTable.GetStringByID((uint) recordByKey.Name);
            this.m_HeroExpObj[panelObjectIdx].m_Str[index3].ClearString();
            this.m_HeroExpObj[panelObjectIdx].m_Str[index3].IntToFormat((long) petData.Level);
            this.m_HeroExpObj[panelObjectIdx].m_Str[index3].AppendFormat("{0}");
            this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[index3].text = this.m_HeroExpObj[panelObjectIdx].m_Str[index3].ToString();
            this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[index3].SetAllDirty();
            this.m_HeroExpObj[panelObjectIdx].m_ScrollLvText[index3].cachedTextGenerator.Invalidate();
            ((Behaviour) this.m_HeroExpObj[panelObjectIdx].m_FlashImage1[index3]).enabled = false;
            ((Behaviour) this.m_HeroExpObj[panelObjectIdx].m_FlashImage2[index3]).enabled = false;
            ((Behaviour) this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpText[index3]).enabled = false;
            this.m_HeroExpObj[panelObjectIdx].m_FlashLvUpValue[index3].posTime = 0.0f;
            this.m_HeroExpObj[panelObjectIdx].m_FlashValue1[index3].colorTime = 0.0f;
            this.m_HeroExpObj[panelObjectIdx].m_FlashValue2[index3].colorTime = 0.0f;
            this.m_HeroExpObj[panelObjectIdx].m_Btn[index3].m_Handler = (IUIButtonClickHandler) this;
            this.m_HeroExpObj[panelObjectIdx].m_Btn[index3].m_BtnID1 = index4;
            this.m_HeroExpObj[panelObjectIdx].m_Btn[index3].m_BtnID2 = (int) petData.ID;
            uint needExp = instance5.GetNeedExp(petData.Level, recordByKey.Rare);
            double num = needExp == 0U ? 0.0 : (double) petData.Exp / (double) needExp;
            this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[index3].value = (float) num;
            if (petData.Level < (byte) 60)
            {
              this.m_HeroExpObj[panelObjectIdx].m_FillImage[index3].sprite = this.m_SpArray.GetSprite(7);
            }
            else
            {
              this.m_HeroExpObj[panelObjectIdx].m_FillImage[index3].sprite = this.m_SpArray.GetSprite(8);
              this.m_HeroExpObj[panelObjectIdx].m_ScrollSlider[index3].value = 1f;
            }
            this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpRT[index3].anchoredPosition = this.m_HeroExpObj[panelObjectIdx].m_ScrollLvUpText[index3].ArabicFixPos(new Vector2(44f, -98f));
            if (petData.CheckState(PetManager.EPetState.Training))
            {
              this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[index3].sprite = this.m_SpArray.GetSprite(6);
              ((Component) this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[index3]).gameObject.SetActive(true);
            }
            else
              ((Component) this.m_HeroExpObj[panelObjectIdx].m_IsFightingImg[index3]).gameObject.SetActive(false);
            if (this.GetPetLock(petData.ID) != (byte) 0)
            {
              if (this.m_FlashCount != -1 && (double) this.LvUpCount != -1.0 && this.m_LvUpHeroID != 0 && this.m_LvUpHeroID == (int) petData.ID)
                ((Behaviour) this.m_HeroExpObj[panelObjectIdx].m_PetLock[index3]).enabled = false;
              else
                ((Behaviour) this.m_HeroExpObj[panelObjectIdx].m_PetLock[index3]).enabled = true;
            }
            else
              ((Behaviour) this.m_HeroExpObj[panelObjectIdx].m_PetLock[index3]).enabled = false;
          }
          item.transform.GetChild(index3).gameObject.SetActive(true);
        }
        else
          item.transform.GetChild(index3).gameObject.SetActive(false);
      }
    }
  }

  public void ButtonOnClick(GameObject gameObject, int dataIndex, int panelId)
  {
  }

  private void StopHeroLvUp(int HeroID)
  {
    for (int index1 = 0; index1 < 5; ++index1)
    {
      for (int index2 = 0; index2 < 4; ++index2)
      {
        if (HeroID != 0 && HeroID == (int) this.m_HeroExpObj[index1].ScrollHeroID[index2])
        {
          this.m_HeroExpObj[index1].m_FlashLvUpValue[index2].posTime = 0.0f;
          this.m_HeroExpObj[index1].m_FlashValue1[index2].colorTime = 0.0f;
          this.m_HeroExpObj[index1].m_FlashValue2[index2].colorTime = 0.0f;
          ((Behaviour) this.m_HeroExpObj[index1].m_FlashImage2[index2]).enabled = false;
          ((Behaviour) this.m_HeroExpObj[index1].m_FlashImage1[index2]).enabled = false;
          ((Behaviour) this.m_HeroExpObj[index1].m_ScrollLvUpText[index2]).enabled = false;
          this.m_LvUpHeroID = 0;
          this.m_preLvUpHeroID = 0;
          if (this.OpenKind == UIHeroUse.eUIHU_OpenKind.ePet)
          {
            PetData petData = PetManager.Instance.FindPetData((ushort) HeroID);
            if (petData != null)
            {
              if (this.GetPetLock(petData.ID) != (byte) 0)
                ((Behaviour) this.m_HeroExpObj[index1].m_PetLock[index2]).enabled = true;
              else
                ((Behaviour) this.m_HeroExpObj[index1].m_PetLock[index2]).enabled = false;
              if (petData.Level < (byte) 60)
              {
                this.m_HeroExpObj[index1].m_FillImage[index2].sprite = this.m_SpArray.GetSprite(7);
                break;
              }
              this.m_HeroExpObj[index1].m_FillImage[index2].sprite = this.m_SpArray.GetSprite(8);
              this.m_HeroExpObj[index1].m_ScrollSlider[index2].value = 1f;
              break;
            }
            break;
          }
          break;
        }
      }
    }
  }

  private void SetHeroLvUp(byte beginlv, byte tagetlv, float leftover, int HeroID = 1)
  {
    this.m_BeginLv = beginlv;
    this.m_TagetLv = tagetlv;
    this.m_Leftover = leftover;
    this.m_LvUpHeroID = HeroID;
    this.m_FlashCount = (int) tagetlv - (int) beginlv;
    this.m_FlashLeftOver = leftover;
  }

  private void Refresh_FontTexture()
  {
    if (this.m_TitleText != null)
    {
      for (int index = 0; index < this.m_TitleText.Length; ++index)
      {
        if ((UnityEngine.Object) this.m_TitleText[index] != (UnityEngine.Object) null && ((Behaviour) this.m_TitleText[index]).enabled)
        {
          ((Behaviour) this.m_TitleText[index]).enabled = false;
          ((Behaviour) this.m_TitleText[index]).enabled = true;
        }
      }
    }
    if (this.m_HeroExpObj == null)
      return;
    for (int index1 = 0; index1 < this.m_HeroExpObj.Length; ++index1)
    {
      for (int index2 = 0; index2 < this.m_HeroExpObj[index1].m_HeroHibtn.Length; ++index2)
      {
        if ((UnityEngine.Object) this.m_HeroExpObj[index1].m_HeroHibtn[index2] != (UnityEngine.Object) null && ((Behaviour) this.m_HeroExpObj[index1].m_HeroHibtn[index2]).enabled)
          this.m_HeroExpObj[index1].m_HeroHibtn[index2].Refresh_FontTexture();
      }
      for (int index3 = 0; index3 < this.m_HeroExpObj[index1].m_ScrollLvUpText.Length; ++index3)
      {
        if ((UnityEngine.Object) this.m_HeroExpObj[index1].m_ScrollLvUpText[index3] != (UnityEngine.Object) null && ((Behaviour) this.m_HeroExpObj[index1].m_ScrollLvUpText[index3]).enabled)
        {
          ((Behaviour) this.m_HeroExpObj[index1].m_ScrollLvUpText[index3]).enabled = false;
          ((Behaviour) this.m_HeroExpObj[index1].m_ScrollLvUpText[index3]).enabled = true;
        }
      }
      for (int index4 = 0; index4 < this.m_HeroExpObj[index1].m_ScrollLvText.Length; ++index4)
      {
        if ((UnityEngine.Object) this.m_HeroExpObj[index1].m_ScrollLvText[index4] != (UnityEngine.Object) null && ((Behaviour) this.m_HeroExpObj[index1].m_ScrollLvText[index4]).enabled)
        {
          ((Behaviour) this.m_HeroExpObj[index1].m_ScrollLvText[index4]).enabled = false;
          ((Behaviour) this.m_HeroExpObj[index1].m_ScrollLvText[index4]).enabled = true;
        }
      }
      for (int index5 = 0; index5 < this.m_HeroExpObj[index1].m_HeroNameText.Length; ++index5)
      {
        if ((UnityEngine.Object) this.m_HeroExpObj[index1].m_HeroNameText[index5] != (UnityEngine.Object) null && ((Behaviour) this.m_HeroExpObj[index1].m_HeroNameText[index5]).enabled)
        {
          ((Behaviour) this.m_HeroExpObj[index1].m_HeroNameText[index5]).enabled = false;
          ((Behaviour) this.m_HeroExpObj[index1].m_HeroNameText[index5]).enabled = true;
        }
      }
    }
  }

  private byte GetPetLock(ushort PetID)
  {
    PetManager instance = PetManager.Instance;
    PetData petData = instance.FindPetData(PetID);
    if (petData.CheckState(PetManager.EPetState.Evolution))
      return 1;
    if ((int) petData.Level >= (int) petData.GetMaxLevel(false))
    {
      PetTbl recordByKey = instance.PetTable.GetRecordByKey(petData.ID);
      uint needExp = instance.GetNeedExp(petData.Level, recordByKey.Rare);
      if ((int) petData.Exp == (int) needExp - 1)
        return 2;
    }
    return 0;
  }

  public override void OnOKCancelBoxClick(bool bOK, int arg1, int arg2)
  {
    if (!bOK || arg1 != 1)
      return;
    PetManager.Instance.OpenPetEvoPanel(arg2);
  }

  private enum eUIHU_OpenKind
  {
    eHero,
    ePet,
  }
}
